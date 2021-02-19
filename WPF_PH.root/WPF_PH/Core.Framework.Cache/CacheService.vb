'===============================================================================
' Microsoft Caching Application Block for .NET
' http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dnpag/html/CachingBlock.asp
'
' CacheService.vb
' This class controls the cache items lifetime for an instance.
'
'===============================================================================
' Copyright (C) 2003 Microsoft Corporation
' All rights reserved.
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
' OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
' LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR
' FITNESS FOR A PARTICULAR PURPOSE.
'===============================================================================
Imports System.Collections.Specialized
Imports System.Configuration
Imports Core.Framework.Cache.Scavenging
Imports System.Threading
Imports Core.ExceptionManagement
Imports System.Runtime.Remoting.Messaging


' Used for handling Exceptions

' Used for accessing the LruScavenging class

' Used for accessing the Storage classes

' <summary>
'		This class controls the cache items lifetime.
' </summary>
Public NotInheritable Class CacheService
    Inherits MarshalByRefObject

#Region "Private Members"

    Private cacheStorage As ICacheStorage
    Private cacheMetadata As ICacheMetadata
    Private mmfReference As IMmfReference
    Private storageScavengingImplementation As IScavengingAlgorithm

    Private itemsExpiration As HybridDictionary
    Friend cacheItemsPriority As HybridDictionary
    Private itemsOnRemoveCallbacks As HybridDictionary
    Private itemsMmfHandles As HybridDictionary

    ' Static instance of cache service
    Public Shared cachService As New CacheService()

#End Region

#Region "Private Constants"

    Private Shared CONVERT_TO_MILLISECONDS_VALUE As Integer = 1000

#End Region

#Region "InitializeLifetimeService"

    ' <summary>
    '		Obtains a lifetime service object to control the 
    '		lifetime policy for this instance.
    ' </summary>
    Public Overrides Function InitializeLifetimeService() As Object

        Return Nothing

    End Function

#End Region

#Region "Constructor"

    ' <summary>
    '		Constructor to initialize the scavenging and 
    '		expiration process.
    ' </summary>
    Private Sub New()

        Try
            Dim mode As String

            ' Init the metadata local stores
            itemsExpiration = New HybridDictionary (False)
            cacheItemsPriority = New HybridDictionary (False)
            itemsOnRemoveCallbacks = New HybridDictionary (False)
            itemsMmfHandles = New HybridDictionary (False)

            If Not Equals (CacheConfiguration.Config. _
                              StorageInformation, Nothing) Then

                ' Create a pointer to the required storage
                cacheStorage = CacheConfiguration.Config. _
                    StorageInformation.CreateInstance()

                ' Get the mode from the config file
                mode = CacheConfiguration.Config.StorageInformation ( _
                                                                     CacheResources.ResourceManager ("RES_Mode"))

                If Not Equals (mode, Nothing) AndAlso _
                   mode.Length <> 0 Then

                    If Equals (mode.ToLower, CacheResources. _
                                  ResourceManager ("RES_InProc")) Then
                        cacheStorage = CacheManager.CacheStorage
                    ElseIf (Not Equals (mode.ToLower, CacheResources. _
                                           ResourceManager ("RES_OutProc"))) Then
                        Throw New ConfigurationErrorsException (CacheResources. _
                                                                   ResourceManager ("RES_ExceptionInvalidMode"))
                    End If
                Else
                    Throw New ConfigurationErrorsException (CacheResources. _
                                                               ResourceManager ("RES_ExceptionNullOrEmptyMode"))
                End If

            Else
                Throw New ConfigurationErrorsException (CacheResources. _
                                                           ResourceManager ("RES_ConfigurationInfoUnavailable"))
            End If

            If Not Equals (CacheConfiguration.Config. _
                              ScavengingInformation, Nothing) Then
                ' Initialize scavenging process
                storageScavengingImplementation = CacheConfiguration.Config. _
                    ScavengingInformation.CreateInstance (Me, cacheStorage, _
                                                          cacheMetadata)
            Else
                ' Initialize default scavenging process
                storageScavengingImplementation = New LruScavenging()
                storageScavengingImplementation.Init (Me, cacheStorage, _
                                                      Nothing, Nothing)
            End If

            ' Load the meta data from the persistent store
            LoadMetadataFromStorage()

            ' Get the Mmf reference if cache storage 
            ' implements IMmfReference
            If TypeOf cacheStorage Is IMmfReference Then
                mmfReference = CType (cacheStorage, IMmfReference)
            Else
                mmfReference = Nothing
            End If

            ' Start a background thread and start monitoring
            ' for expirations
            Dim expirationThreadStart As New ThreadStart (AddressOf _
                                                             Me.MonitorForExpirations)
            Dim expirationThread As New Thread (expirationThreadStart)
            expirationThread.IsBackground = True
            expirationThread.Start()
        Catch genException As Exception
            ExceptionManager.Publish (genException)
            Throw
        End Try
    End Sub

    ' <summary>
    '		This method is used to return the singleton instance of
    '		the CacheService object.
    ' </summary>
    ' <remarks>
    '		CacheService cachService = CacheService.GetCacheService()
    ' </remarks>
    ' <returns>
    '		Returns the singleton instance of the CacheService object
    ' </returns>
    Public Shared Function GetCacheService() As CacheService
        Return cachService
    End Function

#End Region

#Region "Add Functions"

#Region "Add"

    ' <summary>
    '		Adds a new item with the specified metadata to the
    '		cache service.  If a CacheItemRemovedCallback is specified,
    '		then it will be called when the item is removed.
    ' </summary>
    ' <remarks>
    '		Add( key, expirations, priority, onRemoveCallback )
    ' </remarks>
    ' <param name="key">
    '		The unique key used to identify the value stored
    ' </param>
    ' <param name="expirations">
    '		Specifies the expirations for the item
    ' </param>
    ' <param name="priority">
    '		Specifies the item priority levels
    ' </param>
    ' <param name="onRemoveCallback">
    '		To be called when the item is removed
    ' </param>
    Public Sub Add (ByVal keyVal As String, ByVal expirations() _
                       As ICacheItemExpiration, ByVal priority As CacheItemPriority, _
                    ByVal onRemoveCallback As CacheItemRemovedCallback)

        Try
            If Equals (keyVal, Nothing) Then
                Throw New ArgumentNullException ("keyVal", CacheResources. _
                                                    ResourceManager ("RES_ExceptionNullKey"))
            End If

            If keyVal.Length = 0 Then
                Throw New ArgumentOutOfRangeException ("keyVal", _
                                                       CacheResources.ResourceManager ( _
                                                                                       "RES_ExceptionEmptyKey"))
            End If

            If Not Equals (expirations, Nothing) Then
                Dim counter As Integer
                For counter = 0 To expirations.Length - 1
                    If (Equals (expirations (counter), Nothing)) Then
                        Throw New ArgumentNullException ( _
                                                         "expirations array item", CacheResources. _
                                                            ResourceManager ("RES_ExceptionExpirationsItem"))
                    End If
                Next counter
            End If

            ' Check if the item's metadata exists, if it does - remove
            ' the previous item's metadata
            SyncLock itemsExpiration
                itemsExpiration.Remove (keyVal)
            End SyncLock
            SyncLock cacheItemsPriority
                cacheItemsPriority.Remove (keyVal)
            End SyncLock
            SyncLock itemsOnRemoveCallbacks
                itemsOnRemoveCallbacks.Remove (keyVal)
            End SyncLock
            SyncLock itemsMmfHandles
                itemsMmfHandles.Remove (keyVal)
            End SyncLock

            ' Insert the new metadata

            ' If the storage implements the IMmfReference
            ' interface - Add the MMFS object in the hash table
            If Not Equals (mmfReference, Nothing) Then
                SyncLock itemsMmfHandles
                    itemsMmfHandles.Add (keyVal, _
                                         mmfReference.AddReference (keyVal))
                End SyncLock
            End If

            If Not Equals (expirations, Nothing) Then

                ' Insert the key to each expiration class provided
                Dim expCounter As Integer
                For expCounter = 0 To expirations.Length - 1
                    expirations (expCounter).Key (keyVal)

                    ' Register to the change event
                    AddHandler expirations (expCounter).change, AddressOf _
                        Me.ItemDependencyChanged
                Next expCounter

                ' Insert the array to the expirations collection
                SyncLock itemsExpiration
                    itemsExpiration.Add (keyVal, expirations)
                End SyncLock
            End If

            If Not Equals (onRemoveCallback, Nothing) Then
                SyncLock itemsOnRemoveCallbacks
                    itemsOnRemoveCallbacks (keyVal) = onRemoveCallback
                End SyncLock
            End If

            SyncLock cacheItemsPriority
                cacheItemsPriority.Add (keyVal, priority)
            End SyncLock

            ' If the storage implements the ICacheMetadata 
            ' interface - Add the Metadata to it as well
            If Not Equals (cacheMetadata, Nothing) Then
                cacheMetadata.Add (keyVal, expirations, priority)
            End If

            ' Add the new key to the scavenging class
            storageScavengingImplementation.Add (keyVal, priority)

            ' Notifying the addition of key to Cacheservice 
            ' so that the Cacheservice will take the time the
            ' data is added as the last time used for calculating
            ' the sliding expirations
            Notify (keyVal)

            storageScavengingImplementation.Execute()

        Catch genException As Exception
            ExceptionManager.Publish (genException)
        End Try

    End Sub

#End Region

#Region "BeginAdd"

    ' <summary>
    '		Begins an asynchronous request for adding a new item.
    ' </summary>
    ' <remarks>
    '		result = BeginAdd( key, expirations, priority, 
    '			 onRemoveCallback, callback, asyncState )
    ' </remarks>
    ' <param name="key">
    '		The unique key used to identify the value stored
    ' </param>
    ' <param name="expirations">
    '		Specifies the expirations for the item
    ' </param>
    ' <param name="priority">
    '		Specifies the item priority levels
    ' </param>
    ' <param name="onRemoveCallback">
    '		To be called when the item is removed
    ' </param>
    ' <param name="callback">
    '		Method to be called when Async operation is completed
    ' </param>
    ' <param name="asyncState">
    '		Property to get the last parameter of a BeginInvoke
    '		method call
    ' </param>
    ' <returns>
    '		The status of an asynchronous operation
    ' </returns>
    Public Sub BeginAdd (ByVal key As String, ByVal expirations() _
                            As ICacheItemExpiration, ByVal priority As CacheItemPriority, _
                         ByVal onRemoveCallback As CacheItemRemovedCallback, _
                         ByVal callback As AsyncCallback, ByVal asyncState As Object)

        Try

            If Equals (key, Nothing) Then
                Throw New ArgumentNullException ("key", CacheResources. _
                                                    ResourceManager ("RES_ExceptionNullKey"))
            End If

            If key.Length = 0 Then
                Throw New ArgumentOutOfRangeException ("key", CacheResources. _
                                                          ResourceManager ("RES_ExceptionEmptyKey"))
            End If

            If Not Equals (expirations, Nothing) Then
                Dim counter As Integer
                For counter = 0 To expirations.Length - 1
                    If (Equals (expirations (counter), Nothing)) Then
                        Throw New ArgumentNullException ( _
                                                         "expirations array item", CacheResources. _
                                                            ResourceManager ("RES_ExceptionExpirationsItem"))
                    End If
                Next counter
            End If

            Dim handleAdd As AddDataHandler = _
                    New AddDataHandler (AddressOf Me.Add)
            Dim asyncResult As IAsyncResult = handleAdd.BeginInvoke ( _
                                                                     key, expirations, priority, _
                                                                     onRemoveCallback, _
                                                                     New AsyncCallback (AddressOf EndAdd), _
                                                                     asyncState)
            Dim handle As WaitHandle = asyncResult.AsyncWaitHandle()
            handle.WaitOne()

        Catch genException As Exception
            ExceptionManager.Publish (genException)
        End Try

    End Sub

#End Region

#Region "EndAdd"

    ' <summary>
    '		Ends a pending asynchronous add request.
    ' </summary>
    ' <remarks>
    '		EndAdd( asyncResult )
    ' </remarks>
    ' <param name="asyncResult">
    '		Represents the status of an asynchronous operation
    ' </param>
    Friend Sub EndAdd (ByVal asynResult As IAsyncResult)

        Try
            If Equals (asynResult, Nothing) Then
                Throw New ArgumentNullException ("asyncResult", _
                                                 CacheResources.ResourceManager ( _
                                                                                 "RES_ExceptionNullAsyncResult"))
            End If

            Dim result As AsyncResult = _
                    CType (asynResult, AsyncResult)
            Dim handleAdd As AddDataHandler = _
                    CType (result.AsyncDelegate, AddDataHandler)

            handleAdd.EndInvoke (asynResult)

        Catch genException As Exception
            ExceptionManager.Publish (genException)
        End Try
    End Sub

#End Region

#End Region

#Region "GetData Functions"

    ' <summary>
    '		Gets a item with the specified key to the cache service.
    ' </summary>
    ' <remarks>
    '		CacheItem Get(string key)
    ' </remarks>
    ' <param name="key">
    '		The unique key used to identify the value and metadata stored  		
    ' </param>
    ' <returns>
    '		The cache item metadata
    ' </returns>
    Public Function GetData (ByVal key As String) As CacheItem

        Try
            If Equals (key, Nothing) Then
                Throw New ArgumentNullException ("key", CacheResources. _
                                                    ResourceManager ("RES_ExceptionNullKey"))
            End If

            If key.Length = 0 Then
                Throw New ArgumentOutOfRangeException ("key", CacheResources. _
                                                          ResourceManager ("RES_ExceptionEmptyKey"))
            End If

            ' Create a new CacheItem class
            Dim cacheItemMetadata As New CacheItem()

            ' Insert expirations, dependencies and priority
            cacheItemMetadata.Expirations = CType (itemsExpiration (key), _
                ICacheItemExpiration())

            If cacheItemsPriority.Contains (key) Then
                cacheItemMetadata.Priority = CType (cacheItemsPriority (key), _
                    CacheItemPriority)
            End If
            Return cacheItemMetadata

        Catch genException As Exception
            ExceptionManager.Publish (genException)
            Return Nothing
        End Try

    End Function

#End Region

#Region "Flush Functions"

#Region "Flush"

    ' <summary>
    '		Clears all items from the cache service.
    ' </summary>
    ' <remarks>
    '		Flush()
    ' </remarks>
    Public Sub Flush()
        Try
            ' Flush everything, if the storage implements ICacheMetadata
            ' flush it as well
            SyncLock itemsExpiration
                itemsExpiration.Clear()
            End SyncLock
            storageScavengingImplementation.Flush()

            If Not Equals (cacheMetadata, Nothing) Then
                cacheMetadata.Flush()
            End If

            SyncLock itemsOnRemoveCallbacks
                itemsOnRemoveCallbacks.Clear()
            End SyncLock

            ' If the cache storage implements IMmfReference,
            ' during flush close all the memory mapped objects
            ' and clear the HybridDictionary
            If Not Equals (mmfReference, Nothing) Then
                SyncLock itemsMmfHandles
                    Dim entry As DictionaryEntry
                    For Each entry In itemsMmfHandles
                        If entry.Value <> Nothing Then
                            mmfReference.RemoveReference (entry.Value)
                        End If
                    Next entry
                    itemsMmfHandles.Clear()
                End SyncLock
            End If

        Catch genException As Exception
            ExceptionManager.Publish (genException)
        End Try

    End Sub

#End Region

#Region "BeginFlush"

    ' <summary>
    '		Begins an asynchronous request for clear all items
    '		from the cache service.
    ' </summary>
    ' <remarks>
    '		result = BeginFlush( callback, asyncState )
    ' </remarks>
    ' <param name="callback">
    '		Method to be called when Async operation is completed
    ' </param>
    ' <param name="asyncState">
    '		Property to get the last parameter of a BeginInvoke method call
    ' </param>
    ' <returns>
    '		The status of an asynchronous operation
    ' </returns>
    Public Function BeginFlush (ByVal callback As AsyncCallback, _
                                ByVal asyncState As Object) As IAsyncResult

        Try

            Dim handleFlush As FlushHandler = _
                    New FlushHandler (AddressOf Me.Flush)
            handleFlush.BeginInvoke (New AsyncCallback (AddressOf EndFlush), _
                                     asyncState)

        Catch genException As Exception
            ExceptionManager.Publish (genException)
            Return Nothing
        End Try

        Return Nothing
    End Function

#End Region

#Region "EndFlush"

    ' <summary>
    '		Ends a pending asynchronous flush request.
    ' </summary>
    ' <remarks>
    '		EndFlush( asyncResult )
    ' </remarks>
    ' <param name="asyncResult">
    '		Represents the status of an asynchronous operation
    ' </param>
    Friend Sub EndFlush (ByVal asynResult As IAsyncResult)

        Try
            If Equals (asynResult, Nothing) Then
                Throw New ArgumentNullException ("asyncResult", _
                                                 CacheResources.ResourceManager ( _
                                                                                 "RES_ExceptionNullAsyncResult"))
            End If

            Dim result As AsyncResult = _
                    CType (asynResult, AsyncResult)
            Dim handleFlush As FlushHandler = _
                    CType (result.AsyncDelegate, FlushHandler)

            handleFlush.EndInvoke (asynResult)

        Catch genException As Exception
            ExceptionManager.Publish (genException)
        End Try

    End Sub

#End Region

#End Region

#Region "Notify Functions"

#Region "Notify"

    ' <summary>
    '		Notifies that the item with the specified key
    '		was recently used.
    ' </summary>
    ' <remarks>
    '		Notify( key )
    ' </remarks>
    ' <param name="key">
    '		The unique key used to identify the value and 
    '		the metadata stored 
    ' </param>
    Public Sub Notify (ByVal key As String)

        Try
            If Equals (key, Nothing) Then
                Throw New ArgumentNullException ("key", CacheResources. _
                                                    ResourceManager ("RES_ExceptionNullKey"))
            End If

            If key.Length = 0 Then
                Throw New ArgumentOutOfRangeException ("key", CacheResources. _
                                                          ResourceManager ("RES_ExceptionEmptyKey"))
            End If

            ' Notify the item's expiration classes and
            ' the scavenging class
            storageScavengingImplementation.Notify (key)
            If itemsExpiration.Contains (key) Then
                Dim itemExpirations() As ICacheItemExpiration
                itemExpirations = CType (itemsExpiration (key), _
                    ICacheItemExpiration())

                Dim counter As Integer
                For counter = 0 To itemExpirations.Length - 1
                    itemExpirations (counter).Notify()
                Next counter
            End If
        Catch genException As Exception
            ExceptionManager.Publish (genException)
        End Try

    End Sub

#End Region

#Region "BeginNotify"

    ' <summary>
    '		Begins an asynchronous request for notify that a
    '		item was recently used.
    ' </summary>
    ' <remarks>
    '		result = BeginNotify( key, callback, asyncState )
    ' </remarks>
    ' <param name="key">
    '		The unique key used to identify the value and 
    '		the metadata stored 
    ' </param>
    ' <param name="callback">
    '		Method to be called when Async operation is completed
    ' </param>
    ' <param name="asyncState">
    '		Property to get the last parameter of a BeginInvoke
    '		method call
    ' </param>
    ' <returns>
    '		The status of an asynchronous operation
    ' </returns>

    Public Sub BeginNotify (ByVal key As String, _
                            ByVal callback As AsyncCallback, ByVal asyncState As Object)

        Try
            If Equals (key, Nothing) Then
                Throw New ArgumentNullException ("key", CacheResources. _
                                                    ResourceManager ("RES_ExceptionNullKey"))
            End If

            If key.Length = 0 Then
                Throw New ArgumentOutOfRangeException ("key", CacheResources. _
                                                          ResourceManager ("RES_ExceptionEmptyKey"))
            End If

            Dim handleNotify as NotifyHandler = _
                    New NotifyHandler (AddressOf Me.Notify)
            handleNotify.BeginInvoke (key, New AsyncCallback ( _
                                                              AddressOf EndNotify), asyncState)

        Catch genException As Exception
            ExceptionManager.Publish (genException)
        End Try

    End Sub

#End Region

#Region "EndNotify"

    ' <summary>
    '		Ends a pending asynchronous notify request.
    ' </summary>
    ' <remarks>
    '		EndNotify( asyncResult )
    ' </remarks>
    ' <param name="asyncResult">
    '		Represents the status of an asynchronous operation
    ' </param>
    Friend Sub EndNotify (ByVal asynResult As IAsyncResult)

        Try
            If Equals (asynResult, Nothing) Then
                Throw New ArgumentNullException ("asyncResult", _
                                                 CacheResources.ResourceManager ( _
                                                                                 "RES_ExceptionNullAsyncResult"))
            End If

            Dim result As AsyncResult = _
                    CType (asynResult, AsyncResult)
            Dim handleNotify As NotifyHandler = _
                    CType (result.AsyncDelegate, NotifyHandler)
            handleNotify.EndInvoke (asynResult)

        Catch genException As Exception
            ExceptionManager.Publish (genException)
        End Try

    End Sub

#End Region

#End Region

#Region "Remove Functions"

#Region "Remove"

    ' <summary>
    '		Removes the item with the specified key from
    '		the cache service.
    ' </summary>
    ' <remarks>
    '		Remove( key )
    ' </remarks>
    ' <param name="key">
    '		The unique key used to identify the value and 
    '		the metadata stored 
    ' </param>
    Public Sub Remove (ByVal key As String)

        Try
            If Equals (key, Nothing) Then
                Throw New ArgumentNullException ("key", CacheResources. _
                                                    ResourceManager ("RES_ExceptionNullKey"))
            End If

            If key.Length = 0 Then
                Throw New ArgumentOutOfRangeException ("key", CacheResources. _
                                                          ResourceManager ("RES_ExceptionEmptyKey"))
            End If

            ' Remove all metadata from the CacheService, if the storage
            ' implements ICacheMetadata remove item's metadata from there
            ' as well
            RemoveItem (key, CacheItemRemoveCause.Removed)

        Catch genException As Exception
            ExceptionManager.Publish (genException)
        End Try

    End Sub

#End Region

#Region "BeginRemove"

    ' <summary>
    '		Begins an asynchronous request for remove a item.
    ' </summary>
    ' <remarks>
    '		result = BeginRemove( key, callback, asyncState )
    ' </remarks>
    ' <param name="key">
    '		The unique key used to identify the value and 
    '		the metadata stored 
    ' </param>
    ' <param name="callback">
    '		Method to be called when asynchronous operation is completed
    ' </param>
    ' <param name="asyncState">
    '		Property to get the last parameter of a BeginInvoke
    '		method call
    ' </param>
    ' <returns>
    '		The status of an asynchronous operation
    ' </returns>
    Public Sub BeginRemove (ByVal key As String, ByVal callback _
                               As AsyncCallback, ByVal asyncState As Object)

        Try
            If Equals (key, Nothing) Then
                Throw New ArgumentNullException ("key", CacheResources. _
                                                    ResourceManager ("RES_ExceptionNullKey"))
            End If

            If key.Length = 0 Then
                Throw New ArgumentOutOfRangeException ("key", CacheResources. _
                                                          ResourceManager ("RES_ExceptionEmptyKey"))
            End If

            Dim handleRemove As RemoveDataHandler = _
                    New RemoveDataHandler (AddressOf Me.Remove)
            handleRemove.BeginInvoke (key, New AsyncCallback ( _
                                                              AddressOf EndRemove), asyncState)

        Catch genException As Exception
            ExceptionManager.Publish (genException)
        End Try

    End Sub

#End Region

#Region "EndRemove"

    ' <summary>
    '		Ends a pending asynchronous remove request.
    ' </summary>
    ' <remarks>
    '		EndRemove( asyncResult )
    ' </remarks>
    ' <param name="asyncResult">
    '		Represents the status of an asynchronous operation
    ' </param>

    Friend Sub EndRemove (ByVal asynResult As IAsyncResult)

        Try
            If Equals (asynResult, Nothing) Then
                Throw New ArgumentNullException ("asyncResult", _
                                                 CacheResources.ResourceManager ( _
                                                                                 "RES_ExceptionNullAsyncResult"))
            End If

            Dim result As AsyncResult = _
                    CType (asynResult, AsyncResult)
            Dim handleRemove As RemoveDataHandler = _
                    CType (result.AsyncDelegate, RemoveDataHandler)
            handleRemove.EndInvoke (asynResult)

        Catch genException As Exception
            ExceptionManager.Publish (genException)
        End Try
    End Sub

#End Region

#Region "RemoveItem"

    ' <summary>
    '		Remove the metadata from the local store.
    ' </summary>
    ' <remarks>
    '		RemoveItem( key, cause )
    ' </remarks>
    ' <param name="key">
    '		The unique key to identify the value and the metadata
    '		of a cache item
    ' </param>
    ' <param name="cause">
    '		Specifies the causes by which an item was
    '		removed from the cache
    ' </param>
    Friend Sub RemoveItem (ByVal key As String, ByVal cause As _
                              CacheItemRemoveCause)
        Try

            If Equals (key, Nothing) Then
                Throw New ArgumentNullException ("key", CacheResources. _
                                                    ResourceManager ("RES_ExceptionNullKey"))
            End If
            If key.Length = 0 Then
                Throw New ArgumentOutOfRangeException ("key", CacheResources. _
                                                          ResourceManager ("RES_ExceptionEmptyKey"))
            End If

            ' Remove the expirations
            If itemsExpiration.Contains (key) Then
                SyncLock itemsExpiration
                    itemsExpiration.Remove (key)
                End SyncLock
            End If

            ' Remove the metadata
            If Not Equals (cacheMetadata, Nothing) Then
                cacheMetadata.Remove (key)
            End If

            ' Remove the reference to the mmf object
            If Not Equals (mmfReference, Nothing) Then
                If (itemsMmfHandles.Contains (key)) Then
                    SyncLock (itemsMmfHandles)
                        Dim keyValue As Object = itemsMmfHandles (key)
                        If Not Equals (keyValue, Nothing) Then
                            mmfReference.RemoveReference (keyValue)
                        End If
                        itemsMmfHandles.Remove (key)
                    End SyncLock
                End If
            End If

            ' Remove the Priority
            SyncLock cacheItemsPriority
                cacheItemsPriority.Remove (key)
            End SyncLock

            ' Remove the scavenging implementations
            storageScavengingImplementation.Remove (key)

            ' Remove the callback methods 
            If itemsOnRemoveCallbacks.Contains (key) Then
                Dim callBack As CacheItemRemovedCallback = CType ( _
                        itemsOnRemoveCallbacks (key), CacheItemRemovedCallback)

                callBack (key, cause)
                SyncLock itemsOnRemoveCallbacks
                    itemsOnRemoveCallbacks.Remove (key)
                End SyncLock
            End If
        Catch genException As Exception
            ExceptionManager.Publish (genException)
        End Try

    End Sub

#End Region

#End Region

#Region "Private Functions"

#Region "MonitorForExpirations"

    ' <summary>
    '		Monitoring the expirations of the cache items.
    ' </summary>
    ' <remarks>
    '		MonitorForExpirations ()
    ' </remarks>
    Private Sub MonitorForExpirations()

        Try
            Dim checkIntervalInSeconds As Integer
            Dim checkIntervalInMilliseconds As Integer
            Dim counter As Integer
            Dim isExpired As Boolean
            Dim key As String

            If Not Equals (CacheConfiguration.Config. _
                              ExpirationInformation, Nothing) Then
                ' Get expiration check interval from config file
                checkIntervalInSeconds = CacheConfiguration.Config. _
                    ExpirationInformation.Interval
                checkIntervalInMilliseconds = checkIntervalInSeconds* _
                                              CONVERT_TO_MILLISECONDS_VALUE
            Else
                checkIntervalInSeconds = Convert.ToInt32 (CacheResources. _
                                                             ResourceManager ("RES_DefaultExpirationInterval"))
                checkIntervalInMilliseconds = checkIntervalInSeconds* _
                                              CONVERT_TO_MILLISECONDS_VALUE
            End If

            While True
                Dim expiredItems As New ArrayList()

                ' The use of enumerations is not a thread safe operation
                SyncLock itemsExpiration

                    ' Iterate over the expirations list and
                    ' check for expired items
                    Dim dictionary As DictionaryEntry
                    For Each dictionary In itemsExpiration
                        Dim exp As ICacheItemExpiration() = CType (dictionary. _
                                Value, ICacheItemExpiration())
                        isExpired = False
                        counter = 0
                        While Not isExpired AndAlso counter < exp.Length
                            If exp (counter).HasExpired() Then
                                isExpired = True
                                key = dictionary.Key.ToString()
                                expiredItems.Add (key)
                            End If
                            counter += 1
                        End While
                    Next dictionary
                End SyncLock
                For counter = 0 To expiredItems.Count - 1
                    cacheStorage.Remove (expiredItems (counter).ToString())
                    RemoveItem (expiredItems (counter).ToString(), _
                                CacheItemRemoveCause.Expired)
                Next counter

                ' Clear the content of expired items array list
                expiredItems.Clear()

                Thread.Sleep (checkIntervalInMilliseconds)
            End While
        Catch genException As Exception
            ExceptionManager.Publish (genException)
            Throw
        End Try

    End Sub

#End Region

#Region "ItemDependencyChanged"

    ' <summary>
    '		Raising dependency change event invokes the event handler
    '		through the ItemDependencyChange delegate.
    ' </summary>
    ' <remarks>
    '		ItemDependencyChanged ( key )
    ' </remarks>
    ' <param name="key">
    '		The unique key to identify the value and
    '		the metadata stored
    ' </param>
    Private Sub ItemDependencyChanged (ByVal sender As Object, _
                                       ByVal e As CacheEventArgs)

        Try
            Dim key As String = e.KeyValue
            If Equals (key, Nothing) Then
                Throw New ArgumentNullException ("key", CacheResources. _
                                                    ResourceManager ("RES_ExceptionNullKey"))
            End If
            If key.Length = 0 Then
                Throw New ArgumentOutOfRangeException ("key", CacheResources. _
                                                          ResourceManager ("RES_ExceptionEmptyKey"))
            End If

            cacheStorage.Remove (key)
            RemoveItem (key, CacheItemRemoveCause.Expired)
        Catch genException As Exception
            ExceptionManager.Publish (genException)
            Throw
        End Try

    End Sub

#End Region

#Region "LoadMetadataFromStorage"

    ' <summary>
    '		Get the metadata of cache items from local store.
    ' </summary>
    ' <remarks>
    '		LoadMetadataFromStorage()
    ' </remarks>
    Private Sub LoadMetadataFromStorage()
        Try

            If TypeOf cacheStorage Is ICacheMetadata Then
                cacheMetadata = CType (cacheStorage, ICacheMetadata)
            Else
                cacheMetadata = Nothing
            End If

            If Not Equals (cacheMetadata, Nothing) Then
                Dim metadata As Hashtable = cacheMetadata.GetMetadata()

                Dim entry As DictionaryEntry

                For Each entry In metadata

                    ' Check types and load expirations, priorities
                    ' and scavenging classes
                    Dim metaEntry As DictionaryEntry = _
                            CType (entry.Value, DictionaryEntry)

                    If Equals (metaEntry.Value.GetType(), _
                               GetType (ICacheItemExpiration())) Then
                        If Not itemsExpiration.Contains (metaEntry.Key) Then
                            SyncLock itemsExpiration
                                itemsExpiration.Add (metaEntry.Key, CType ( _
                                                        metaEntry.Value, ICacheItemExpiration()))
                            End SyncLock
                        End If

                    ElseIf Equals (metaEntry.Value.GetType(), _
                                   GetType (CacheItemPriority)) Then
                        cacheItemsPriority.Add (metaEntry.Key, _
                                                CType (metaEntry.Value, CacheItemPriority))

                        storageScavengingImplementation.Add (metaEntry.Key. _
                                                                ToString(), CType (metaEntry.Value, CacheItemPriority))
                    End If
                Next entry

            End If
        Catch genException As Exception
            ExceptionManager.Publish (genException)
            Throw
        End Try

    End Sub

#End Region

#End Region
End Class