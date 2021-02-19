'===============================================================================
' Microsoft Caching Application Block for .NET
' http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dnpag/html/CachingBlock.asp
'
' CacheManager.vb
' This class manages all the activities of the Cache Application Block like
' adding, updating, getting, flushing and removing the data pertaining to the
' Cache Data Store.
'
'===============================================================================
' Copyright (C) 2003 Microsoft Corporation
' All rights reserved.
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
' OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
' LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR
' FITNESS FOR A PARTICULAR PURPOSE.
'===============================================================================
Imports System.Configuration
Imports System.Runtime.Remoting
Imports Core.Framework.Cache.Storages
Imports Core.ExceptionManagement
Imports Core.Framework.Cache.Expirations

' Used for handling Exceptions

' Used for accessing the storage classes

' <summary>
'		This class manages all the activities of the 
'		Cache Application Block like adding, updating, 
'		getting, flushing and removing the data 
'		pertaining to the Cache Data Store.
' </summary>

Public NotInheritable Class CacheManager

#Region "Private members"

    Private manageCacheService As CacheService
    Private Shared manageCacheStorage As ICacheStorage

    ' Creating a static instance
    Private Shared cachManager As CacheManager = New CacheManager()

#End Region

#Region "Property"

    Public Shared ReadOnly Property CacheStorage() As ICacheStorage

        Get
            Return manageCacheStorage
        End Get
    End Property

#End Region

#Region "Constructor"

    ' <summary>
    '		Class constructor to read the storage information
    '		from the App.config file.
    ' </summary>

    Private Sub New()
        Try
            ' Read storage mode from config file
            If Not Equals (CacheConfiguration.Config. _
                              StorageInformation, Nothing) Then
                Dim mode As String = CacheConfiguration.Config. _
                        StorageInformation (CacheResources.ResourceManager ( _
                                                                            "RES_Mode"))

                If (Not Equals (mode, Nothing)) AndAlso _
                   Equals (mode.ToLower, CacheResources. _
                              ResourceManager ("RES_OutProc")) Then
                    Dim remotingUrl As String = CacheConfiguration.Config. _
                            StorageInformation (CacheResources.ResourceManager ( _
                                                                                "RES_RemotingUrl"))

                    If Equals (remotingUrl, Nothing) OrElse _
                       Equals (remotingUrl.Length, 0) Then
                        Throw New ConfigurationErrorsException (CacheResources. _
                                                                   ResourceManager ( _
                                                                                    "RES_ExceptionInvalidConfigurationStorageProviderURL"))
                    End If

                    ' Configure the Remoting framework
                    RemotingConfiguration.RegisterWellKnownClientType ( _
                                                                       GetType (CacheService), remotingUrl)
                End If

                ' Initialize the CacheStorage
                manageCacheStorage = CacheConfiguration.Config. _
                    StorageInformation.CreateInstance()

            Else
                ' Initialize the default CacheStorage
                manageCacheStorage = New SingletonCacheStorage()

            End If

            ' Initialize the CacheService 
            manageCacheService = CacheService.GetCacheService()
            manageCacheService.InitializeLifetimeService()

        Catch genException As Exception
            ExceptionManager.Publish (genException)
            Throw
        End Try
    End Sub

#End Region

#Region "Indexer"

    ' <summary>
    '		Gets the value for the key.
    ' </summary>

    Default Public ReadOnly Property Item (ByVal key As String) As Object

        Get
            Return Me.GetData (key)
        End Get
    End Property

#End Region

#Region "Public Methods"

    ' <summary>
    '		This method is used to return the singleton instance of
    '		the CacheManager object.
    ' </summary>
    ' <remarks>
    '		CacheManager manager = CacheManager.GetCacheManager()
    ' </remarks>
    ' <returns>
    '		Returns the singleton instance of the CacheManager object
    ' </returns>
    Public Shared Function GetCacheManager() As CacheManager

        Return cachManager

    End Function

#Region "Add method overloads"

    ' <summary>
    '		Adds an element with the specified key and value
    '		into the cache.
    ' </summary>
    ' <remarks>
    '		Add(key, keyData)
    ' </remarks>
    ' <param name="key">
    '		The unique key used to identify the value stored
    ' </param>
    ' <param name="keyData">
    '		The value to be stored
    ' </param>

    Public Overloads Sub Add (ByVal key As String, ByVal keyData As Object)

        Try
            If Equals (key, Nothing) Then
                Throw New ArgumentNullException ("key", CacheResources. _
                                                    ResourceManager ("RES_ExceptionNullKey"))
            End If

            If key.Length = 0 Then
                Throw New ArgumentOutOfRangeException ("key", CacheResources. _
                                                          ResourceManager ("RES_ExceptionEmptyKey"))
            End If

            If Equals (keyData, Nothing) Then
                Throw New ArgumentNullException ("keyData", CacheResources. _
                                                    ResourceManager ("RES_ExceptionNullValue"))
            End If

            ' Synchronize for threads
            SyncLock Me

                ' Add key and value to the cache storage
                manageCacheStorage.Add (key, keyData)

                ' Add key and default priority to CacheService
                ' for scavenging reasons
                AddMetadataToCacheService (key, _
                                           Nothing, _
                                           CacheItemPriority.Normal, _
                                           Nothing)
            End SyncLock

        Catch genException As Exception
            ExceptionManager.Publish (genException)
            Throw
        End Try

    End Sub

    ' <summary>
    '		Adds an element with the specified key,
    '		value and metadata into the storage.
    ' </summary>
    ' <remarks>
    '		Add(key, keyData, expiration, priority, onRemoveCallback)
    ' </remarks>
    ' <param name="key">
    '		The unique key used to identify the value stored
    ' </param>
    ' <param name="keyData">
    '		The value to be stored
    ' </param>
    ' <param name="expiration">
    '		Specifies the absolute expiration Date/Time for the item
    ' </param>
    ' <param name="priority">
    '		Specifies the item priority levels
    ' </param>
    ' <param name="onRemoveCallback">
    '		To be called when the item is removed
    ' </param>

    Public Overloads Sub Add (ByVal key As String, ByVal keyData As Object, _
                              ByVal expiration As DateTime, _
                              ByVal priority As CacheItemPriority, _
                              ByVal onRemoveCallback As CacheItemRemovedCallback)
        Dim expirations(0) As ICacheItemExpiration
        expirations (0) = New AbsoluteTime (expiration)

        Me.Add (key, keyData, expirations, priority, onRemoveCallback)
    End Sub

    ' <summary>
    '		Adds an element with the specified key,
    '		value and metadata into the storage.
    ' </summary>
    ' <remarks>
    '		Add(key, keyData, expiration, priority, onRemoveCallback)
    ' </remarks>
    ' <param name="key">
    '		The unique key used to identify the value stored
    ' </param>
    ' <param name="keyData">
    '		The value to be stored
    ' </param>
    ' <param name="expirations">
    '		Specifies the single expiration as ICacheItemExpiration for the item
    ' </param>
    ' <param name="priority">
    '		Specifies the item priority levels
    ' </param>
    ' <param name="onRemoveCallback">
    '		To be called when the item is removed
    ' </param>

    Public Overloads Sub Add (ByVal key As String, ByVal keyData As Object, _
                              ByVal expiration As ICacheItemExpiration, _
                              ByVal priority As CacheItemPriority, _
                              ByVal onRemoveCallback As CacheItemRemovedCallback)
        Dim expirations(0) As ICacheItemExpiration
        expirations (0) = expiration

        Me.Add (key, keyData, expirations, priority, onRemoveCallback)
    End Sub

    ' <summary>
    '		Adds an element with the specified key,
    '		value and metadata into the storage.
    ' </summary>
    ' <remarks>
    '		Add(key, keyData, expirations, priority, onRemoveCallback)
    ' </remarks>
    ' <param name="key">
    '		The unique key used to identify the value stored
    ' </param>
    ' <param name="keyData">
    '		The value to be stored
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

    Public Overloads Sub Add (ByVal key As String, ByVal keyData As Object, _
                              ByVal expirations() As ICacheItemExpiration, _
                              ByVal priority As CacheItemPriority, _
                              ByVal onRemoveCallback As CacheItemRemovedCallback)

        Try
            If Equals (key, Nothing) Then
                Throw New ArgumentNullException ("key", CacheResources. _
                                                    ResourceManager ("RES_ExceptionNullKey"))
            End If

            If key.Length = 0 Then
                Throw New ArgumentOutOfRangeException ("key", CacheResources. _
                                                          ResourceManager ("RES_ExceptionEmptyKey"))
            End If

            If Equals (keyData, Nothing) Then
                Throw New ArgumentNullException ("keyData", CacheResources. _
                                                    ResourceManager ("RES_ExceptionNullValue"))
            End If

            ' Synchronize for threads
            SyncLock Me
                ' Add the value to the store
                manageCacheStorage.Add (key, keyData)

                ' Add the metadata to the CacheService
                manageCacheService.BeginAdd (key, expirations, priority, _
                                             onRemoveCallback, Nothing, Nothing)
            End SyncLock
        Catch genException As Exception
            ExceptionManager.Publish (genException)
            Throw
        End Try

    End Sub

#End Region

#Region "GetData method "

    ' <summary>
    '		Gets the element with the specified key.
    ' </summary>
    ' <remarks>
    '		result = GetData(string key)
    ' </remarks>
    ' <param name="key">
    '		The unique key used to identify the value stored
    ' </param>
    ' <returns>
    '		The cache item value
    ' </returns>
    Public Function GetData (ByVal key As String) As Object

        Try
            If Equals (key, Nothing) Then
                Throw New ArgumentNullException ("key", CacheResources. _
                                                    ResourceManager ("RES_ExceptionNullKey"))
            End If

            If key.Length = 0 Then
                Throw New ArgumentOutOfRangeException ("key", CacheResources. _
                                                          ResourceManager ("RES_ExceptionEmptyKey"))
            End If

            SyncLock Me

                ' Asynch Notify CacheService
                manageCacheService.BeginNotify (key, Nothing, Nothing)

                ' Get data from storage
                Dim result As Object
                result = manageCacheStorage.GetData (key)
                Return result
            End SyncLock

        Catch genException As Exception
            ExceptionManager.Publish (genException)
            Throw
        End Try

    End Function

#End Region

#Region "GetItem method "

    ' <summary>
    '		Gets the cache item with the specified key.
    ' </summary>
    ' <remarks>
    '		itemValue = GetItem(key)
    ' </remarks>
    ' <param name="key">
    '		The unique key used to identify the value stored
    ' </param>
    ' <returns>
    '		The cache item value and its metadata
    ' </returns>
    Public Function GetItem (ByVal key As String) As CacheItem

        Try
            If Equals (key, Nothing) Then
                Throw New ArgumentNullException ("key", CacheResources. _
                                                    ResourceManager ("RES_ExceptionNullKey"))
            End If

            If key.Length = 0 Then
                Throw New ArgumentOutOfRangeException ("key", CacheResources. _
                                                          ResourceManager ("RES_ExceptionEmptyKey"))
            End If

            Dim cacheItemMetadata As CacheItem

            SyncLock Me
                ' Get the item's metadata from the CacheService
                Dim item As CacheItem = manageCacheService.GetData (key)

                If Not Equals (item, Nothing) Then

                    ' Get the item's data from the CacheStorage
                    item.Value = manageCacheStorage.GetData (key)

                    ' Add the key
                    item.Key = key
                    cacheItemMetadata = item

                    ' Notify CacheService
                    manageCacheService.BeginNotify (key, Nothing, Nothing)

                    Return cacheItemMetadata

                End If
            End SyncLock
            Return Nothing

        Catch genException As Exception
            ExceptionManager.Publish (genException)
            Return Nothing
            Throw
        End Try

    End Function

#End Region

#Region "Remove method"

    ' <summary>
    '		Removes the element with the specified key.
    ' </summary>
    ' <remarks>
    '		Remove(key)
    ' </remarks>
    ' <param name="key">
    '		The unique key used to identify the value stored
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

            SyncLock Me
                ' Remove the item's data from the storage
                manageCacheStorage.Remove (key)

                ' Call the CacheService's Asynch Remove method
                ' to remove the item's expirations, dependencies
                ' and its priority
                manageCacheService.BeginRemove (key, Nothing, Nothing)
            End SyncLock

        Catch genException As Exception
            ExceptionManager.Publish (genException)
            Throw
        End Try

    End Sub

#End Region

#Region "Flush method"

    ' <summary>
    '		Clears all elements from the cache.
    ' </summary>
    ' <remarks>
    '		Flush()
    ' </remarks>
    Public Sub Flush()

        Try
            SyncLock Me
                ' Remove all the cache items from storage
                manageCacheStorage.Flush()

                ' Call the CacheService's Asynch Remove method
                ' to flush the item's expirations, dependencies
                ' and its priority for the cache items 
                manageCacheService.BeginFlush (Nothing, Nothing)
            End SyncLock

        Catch genException As Exception
            ExceptionManager.Publish (genException)
            Throw
        End Try

    End Sub

#End Region

#End Region

#Region "Private Methods"

#Region "AddMetadataToCacheService"

    ' <summary>
    '		Add the metadata to the CacheService.
    ' </summary>
    ' <remarks>
    '		AddMetadataToCacheService( key, expirations, 
    '			priority, onRemoveCallback )
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
    Private Sub AddMetadataToCacheService (ByVal key As String, _
                                           ByVal expirations() As ICacheItemExpiration, _
                                           ByVal priority As CacheItemPriority, _
                                           ByVal onRemoveCallback As CacheItemRemovedCallback)

        Try
            If Equals (key, Nothing) Then
                Throw New ArgumentNullException ("key", CacheResources. _
                                                    ResourceManager ("RES_ExceptionNullKey"))
            End If

            If key.Length = 0 Then
                Throw New ArgumentOutOfRangeException ("key", CacheResources. _
                                                          ResourceManager ("RES_ExceptionEmptyKey"))
            End If

            ' Call the CacheService's Asynch Add method to 
            ' add the metadata
            manageCacheService.BeginAdd (key, expirations, priority, _
                                         onRemoveCallback, Nothing, Nothing)

        Catch genException As Exception
            ExceptionManager.Publish (genException)
            Throw
        End Try

    End Sub

#End Region

#Region "AddMetadataToCacheServiceCallback"

    ' <summary>
    '		The callback method to which AsyncResult is passed 
    '		when specified as part of the begin operation of 
    '		adding the metadata to the CacheService.
    ' </summary>
    ' <remarks>
    '		AddMetadataToCacheServiceCallback( result )
    ' </remarks>
    ' <param name="result">
    '		Represents the status of an asynchronous operation
    ' </param>
    Private Sub AddMetadataToCacheServiceCallback (ByVal result As IAsyncResult)

        Try
            If Equals (result, Nothing) Then
                Throw New ArgumentNullException ("result", CacheResources. _
                                                    ResourceManager ("RES_ExceptionNullAsyncResult"))
            End If

            ' Ends the pending asynchronous add request
            manageCacheService.EndAdd (result)

        Catch genException As Exception
            ExceptionManager.Publish (genException)
            Throw
        End Try

    End Sub

#End Region

#Region "GetCacheItemDataCallback"

    ' <summary>
    '		The callback method to which AsyncResult is passed 
    '		when specified as part of the begin operation of 
    '		gettting the data from the CacheService.
    ' </summary>
    ' <remarks>
    '		GetCacheItemDataCallback( result )
    ' </remarks>
    ' <param name="result">
    '		Represents the status of an asynchronous operation
    ' </param>
    Private Sub GetCacheItemDataCallback (ByVal result As IAsyncResult)

        Try
            If Equals (result, Nothing) Then
                Throw New ArgumentNullException ("result", CacheResources. _
                                                    ResourceManager ("RES_ExceptionNullAsyncResult"))
            End If

            ' Ends the pending asynchronous notify request
            manageCacheService.EndNotify (result)

        Catch genException As Exception
            ExceptionManager.Publish (genException)
            Throw
        End Try

    End Sub

#End Region

#Region "GetCacheItemCallback"

    ' <summary>
    '		The callback method to which AsyncResult is passed 
    '		when specified as part of the begin operation of 
    '		gettting the metadata from the CacheService.
    ' </summary>
    ' <remarks>
    '		GetCacheItemCallback( result )
    ' </remarks>
    ' <param name="result">
    '		Represents the status of an asynchronous operation
    ' </param>
    Private Sub GetCacheItemCallback (ByVal result As IAsyncResult)

        Try

            If Equals (result, Nothing) Then
                Throw New ArgumentNullException ("result", CacheResources. _
                                                    ResourceManager ("RES_ExceptionNullAsyncResult"))
            End If

            ' Ends the pending asynchronous notify request
            manageCacheService.EndNotify (result)

        Catch genException As Exception
            ExceptionManager.Publish (genException)
            Throw
        End Try

    End Sub

#End Region

#Region "RemoveCacheItemMetadataCallback"

    ' <summary>
    '		The callback method to which AsyncResult is passed 
    '		when specified as part of the begin operation of 
    '		removing the metadata from the CacheService.
    ' </summary>
    ' <remarks>
    '		RemoveCacheItemMetadataCallback( result )
    ' </remarks>
    ' <param name="result">
    '		Represents the status of an asynchronous operation
    ' </param>
    Private Sub RemoveCacheItemMetadataCallback (ByVal result As IAsyncResult)

        Try
            If Equals (result, Nothing) Then
                Throw New ArgumentNullException ("result", CacheResources. _
                                                    ResourceManager ("RES_ExceptionNullAsyncResult"))
            End If

            ' Ends the pending asynchronous remove request
            manageCacheService.EndRemove (result)

        Catch genException As Exception
            ExceptionManager.Publish (genException)
            Throw
        End Try

    End Sub

#End Region

#Region "FlushCacheCallback"

    ' <summary>
    '		The callback method to which AsyncResult is passed 
    '		when specified as part of the begin operation of 
    '		flushing the metadata from the CacheService.
    ' </summary>
    ' <remarks>
    '		FlushCacheCallback( result )
    ' </remarks>
    ' <param name="result">
    '		Represents the status of an asynchronous operation
    ' </param>
    Private Sub FlushCacheCallback (ByVal result As IAsyncResult)
        Try

            If Equals (result, Nothing) Then
                Throw New ArgumentNullException ("result", CacheResources. _
                                                    ResourceManager ("RES_ExceptionNullAsyncResult"))
            End If

            ' Ends the pending asynchronous flush request
            manageCacheService.EndFlush (result)
        Catch genException As Exception
            ExceptionManager.Publish (genException)
            Throw
        End Try

    End Sub

#End Region

#End Region
End Class
