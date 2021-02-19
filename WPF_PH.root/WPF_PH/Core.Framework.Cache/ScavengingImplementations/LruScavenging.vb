'===============================================================================
' Microsoft Caching Application Block for .NET
' http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dnpag/html/CachingBlock.asp
'
' LruScavenging.vb
' This class manages scavenging operations by removing the cache items using
' the LRU (Least Recently Used) algorithm to ensure that the cache storage size
' does not exceed a certain limit.
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
Imports System.Xml
Imports System.Configuration
Imports System.Globalization
Imports Core.ExceptionManagement

' Used for Handling Exceptions

Namespace Scavenging
    ' <summary>
    '		A Least recently used scavenging algorithm implementation.
    ' </summary>

    Public Class LruScavenging
        Implements IScavengingAlgorithm

#Region "Member variables"

        Private storageUtilization As Double
        Private itemsLastUsed As HybridDictionary
        Private itemsPriority As HybridDictionary
        Private cachingService As CacheService
        Private cacheStorage As ICacheStorage
        Private cacheMetadata As ICacheMetadata

#End Region

#Region "Constructor"

        ' <summary>
        '		Constructor.
        ' </summary>

        Public Sub New()
        End Sub

#End Region

#Region "Implementation of IScavengingAlgorithm"

#Region "Init"

        ' <summary>
        '		Initializes the scavenging algorithm.
        ' </summary>
        ' <remarks>
        '		IScavengingAlgorithm.Init ( cachingService,
        '			cacheStorage, cacheMetadata, configSection )
        ' </remarks>
        ' <param name="cachingService">
        '		Instance of CacheService
        ' </param>
        ' <param name="cacheStorage">
        '		Instance of ICacheStorage
        ' </param>
        ' <param name="cacheMetadata">
        '		Instance of ICacheMetadata
        ' </param>
        ' <param name="configSection">
        '		Represents a single node in the XML document
        ' </param>
        Sub Init (ByVal cachingService As CacheService, _
                  ByVal cacheStorage As ICacheStorage, ByVal cacheMetadata As _
                     ICacheMetadata, ByVal configSection As XmlNode) _
            Implements IScavengingAlgorithm.Init

            Try
                Const PERCENATGE_CONVERTER As Integer = 100
                Dim maxCacheStorageSize As Integer
                Dim cacheUtilizationToScavenge As Integer

                If Equals (cachingService, Nothing) Then
                    Throw New ArgumentNullException ("cachingService", _
                                                     CacheResources.ResourceManager ( _
                                                                                     "RES_ExceptionNullCacheService"))
                End If

                If Equals (cacheStorage, Nothing) Then
                    Throw New ArgumentNullException ("cacheStorage", _
                                                     CacheResources.ResourceManager ( _
                                                                                     "RES_ExceptionNullCacheStorage"))
                End If

                Me.cachingService = cachingService
                Me.itemsPriority = cachingService.cacheItemsPriority
                Me.cacheStorage = cacheStorage
                Me.cacheMetadata = cacheMetadata

                itemsLastUsed = New HybridDictionary (False)

                If Not Equals (configSection, Nothing) Then

                    ' Read scavenging config
                    Dim tmpNode As XmlNode = configSection.SelectSingleNode ( _
                                                                             CacheResources.ResourceManager ( _
                                                                                                             "RES_MaximumSize"))
                    Dim storageSize As String
                    Dim storage As Double

                    If Equals (tmpNode, Nothing) Then
                        tmpNode = configSection.SelectSingleNode ( _
                                                                  CacheResources.ResourceManager ( _
                                                                                                  "RES_TempMaximumSize"))
                        If Not Equals (tmpNode, Nothing) Then
                            storageSize = tmpNode.InnerText
                        Else
                            Throw New ConfigurationErrorsException (CacheResources. _
                                                                       ResourceManager ( _
                                                                                        "RES_ExceptionNullMaxStorageSize"))
                        End If
                    Else
                        storageSize = tmpNode.Value
                    End If

                    If storageSize.Length = 0 Then
                        Throw New ConfigurationErrorsException (CacheResources. _
                                                                   ResourceManager ( _
                                                                                    "RES_ExceptionEmptyMaxStorageSize"))
                    End If

                    If Double.TryParse (storageSize, NumberStyles.Integer, Nothing, storage) Then

                        If storage > Integer.MaxValue Then
                            Throw New ConfigurationErrorsException ( _
                                                                    CacheResources.ResourceManager ( _
                                                                                                    "RES_ExceptionMaxMaxStorageSize"))
                        End If

                        maxCacheStorageSize = Integer.Parse (storageSize)

                        If maxCacheStorageSize < 1 Then
                            Throw New ConfigurationErrorsException ( _
                                                                    CacheResources.ResourceManager ( _
                                                                                                    "RES_ExceptionMinMaxStorageSize"))
                        End If
                    Else
                        Throw New ConfigurationErrorsException ( _
                                                                CacheResources.ResourceManager ( _
                                                                                                "RES_ExceptionInvalidMaxStorageSize"))
                    End If

                    tmpNode = configSection.SelectSingleNode (CacheResources. _
                                                                 ResourceManager ("RES_UtilizationForScavenging"))
                    Dim utilization As String
                    Dim scavengingUtilization As Double

                    If Equals (tmpNode, Nothing) Then
                        tmpNode = configSection.SelectSingleNode ( _
                                                                  CacheResources.ResourceManager ( _
                                                                                                  "RES_TempUtilizationForScavenging"))
                        If Not Equals (tmpNode, Nothing) Then
                            utilization = tmpNode.InnerText
                        Else
                            Throw New ConfigurationErrorsException (CacheResources. _
                                                                       ResourceManager ( _
                                                                                        "RES_ExceptionNullUtilization"))
                        End If
                    Else
                        utilization = tmpNode.Value
                    End If

                    If utilization.Length = 0 Then
                        Throw New ConfigurationErrorsException (CacheResources. _
                                                                   ResourceManager ( _
                                                                                    "RES_ExceptionEmptyUtilization"))
                    End If

                    If Double.TryParse (utilization, NumberStyles.Integer, Nothing, _
                                        scavengingUtilization) Then

                        If scavengingUtilization > Integer.MaxValue Then
                            Throw New ConfigurationErrorsException ( _
                                                                    CacheResources.ResourceManager ( _
                                                                                                    "RES_ExceptionMaxUtilization"))
                        End If

                        cacheUtilizationToScavenge = Integer.Parse (utilization)

                        If cacheUtilizationToScavenge < 1 Then
                            Throw New ConfigurationErrorsException ( _
                                                                    CacheResources.ResourceManager ( _
                                                                                                    "RES_ExceptionMinUtilization"))
                        End If
                    Else
                        Throw New ConfigurationErrorsException ( _
                                                                CacheResources.ResourceManager ( _
                                                                                                "RES_ExceptionInvalidUtilization"))
                    End If
                Else
                    ' Default values
                    maxCacheStorageSize = Convert.ToInt32 (CacheResources. _
                                                              ResourceManager ("RES_MaxCacheStorageSize"))
                    cacheUtilizationToScavenge = Convert.ToInt32 ( _
                                                                  CacheResources.ResourceManager ( _
                                                                                                  "RES_CacheUtilizationToScavenge"))
                End If

                storageUtilization = maxCacheStorageSize* _
                                     cacheUtilizationToScavenge/PERCENATGE_CONVERTER

            Catch genException As Exception
                ExceptionManager.Publish (genException)
                Throw
            End Try

        End Sub

#End Region

#Region "Execute"

        ' <summary>
        '		Executes the algorithm.
        ' </summary>
        ' <remarks>
        '		IScavengingAlgorithm.Execute()
        ' </remarks>
        Sub Execute() Implements IScavengingAlgorithm.Execute

            Try
                ' Get storage size
                Dim storageSize As Integer = cacheStorage.Size

                If storageSize >= storageUtilization Then
                    ' Start removing
                    While storageSize >= storageUtilization
                        Dim key As String = GetLruItem()
                        ' Remove the item
                        cacheStorage.Remove (key)

                        If Not Equals (cacheMetadata, Nothing) Then
                            SyncLock cacheMetadata
                                cacheMetadata.Remove (key)
                            End SyncLock
                        End If

                        cachingService.RemoveItem (key, _
                                                   CacheItemRemoveCause.Scavenged)
                        SyncLock itemsLastUsed
                            itemsLastUsed.Remove (key)
                        End SyncLock
                        SyncLock itemsPriority
                            itemsPriority.Remove (key)
                        End SyncLock
                        storageSize = cacheStorage.Size
                    End While
                End If
            Catch genException As Exception
                ExceptionManager.Publish (genException)
                Throw
            End Try

        End Sub

#End Region

#Region "Notify"

        ' <summary>
        '		Notifies that the element with the specified 
        '		key was recently used.
        ' </summary>
        ' <remarks>
        '		IScavengingAlgorithm.Notify( string key )
        ' </remarks>
        ' <param name="key">
        '		The unique key to identify the value
        ' </param>
        Sub Notify (ByVal key As String) Implements IScavengingAlgorithm.Notify

            Try

                If Equals (key, Nothing) Then
                    Throw New ArgumentNullException ("key", CacheResources. _
                                                        ResourceManager ("RES_ExceptionNullKey"))
                End If

                If key.Length = 0 Then
                    Throw New ArgumentOutOfRangeException ("key", _
                                                           CacheResources.ResourceManager ( _
                                                                                           "RES_ExceptionEmptyKey"))
                End If
                SyncLock itemsLastUsed
                    If itemsLastUsed.Contains (key) Then
                        itemsLastUsed (key) = DateTime.Now
                    End If
                End SyncLock
            Catch genException As Exception
                ExceptionManager.Publish (genException)
                Throw
            End Try

        End Sub

#End Region

#Region "Add"

        ' <summary>
        '		Adds a new element to the item algorithm list. 
        '		This list is used when the algorithm is executed.
        ' </summary>
        ' <remarks>
        '		IScavengingAlgorithm.Add ( key, priority )
        ' </remarks>
        ' <param name="key">
        '		The unique to identify the value
        ' </param>
        ' <param name="priority">
        '		Specifies the cache item priority levels
        ' </param>
        Sub Add (ByVal key As String, ByVal priority As CacheItemPriority) _
            Implements IScavengingAlgorithm.Add

            Try
                If Equals (key, Nothing) Then
                    Throw New ArgumentNullException ("key", CacheResources. _
                                                        ResourceManager ("RES_ExceptionNullKey"))
                End If

                If key.Length = 0 Then
                    Throw New ArgumentOutOfRangeException ("key", _
                                                           CacheResources.ResourceManager ( _
                                                                                           "RES_ExceptionEmptyKey"))
                End If
                SyncLock itemsLastUsed
                    itemsLastUsed (key) = DateTime.Now
                End SyncLock
                SyncLock itemsPriority
                    itemsPriority (key) = priority
                End SyncLock
            Catch genException As Exception
                ExceptionManager.Publish (genException)
                Throw
            End Try

        End Sub

#End Region

#Region "Remove"

        ' <summary>
        '		Removes the element with the specied key from the 
        '		item algorithm list.
        ' </summary>
        ' <remarks>
        '		IScavengingAlgorithm.Remove ( string key )
        ' </remarks>
        ' <param name="key">
        '		The unique key to identify the value
        ' </param>
        Sub Remove (ByVal key As String) Implements IScavengingAlgorithm.Remove

            Try
                If Equals (key, Nothing) Then
                    Throw New ArgumentNullException ("key", CacheResources. _
                                                        ResourceManager ("RES_ExceptionNullKey"))
                End If

                If key.Length = 0 Then
                    Throw New ArgumentOutOfRangeException ("key", _
                                                           CacheResources.ResourceManager ( _
                                                                                           "RES_ExceptionEmptyKey"))
                End If
                SyncLock (itemsLastUsed)
                    itemsLastUsed.Remove (key)
                End SyncLock
                SyncLock itemsPriority
                    itemsPriority.Remove (key)
                End SyncLock
            Catch genException As Exception
                ExceptionManager.Publish (genException)
                Throw
            End Try

        End Sub

#End Region

#Region "Flush"

        ' <summary>
        '		Removes all elements from the item algorithm list.
        ' </summary>
        ' <remarks>
        '		IScavengingAlgorithm.Flush ()
        ' </remarks>
        Sub Flush() Implements IScavengingAlgorithm.Flush

            Try
                SyncLock itemsLastUsed
                    itemsLastUsed.Clear()
                End SyncLock
                SyncLock itemsPriority
                    itemsPriority.Clear()
                End SyncLock
            Catch genException As Exception
                ExceptionManager.Publish (genException)
                Throw
            End Try

        End Sub

#End Region

#End Region

#Region "Private method"

        ' <summary>
        '		Gets the Least recently used item.
        ' </summary>
        ' <remarks>
        '		lruItemKey = GetLruItem ()
        ' </remarks>
        ' <returns>
        '		The key that has to be removed
        ' </returns>
        Private Function GetLruItem() As String

            Try
                Dim lruItemKey As String = ""
                Dim tmpDateTime As DateTime = DateTime.Now

                Dim dictEntry As DictionaryEntry

                SyncLock itemsLastUsed
                    For Each dictEntry In itemsLastUsed
                        If DateTime.Compare (tmpDateTime, CType (dictEntry.Value, _
                                                DateTime)) > 0 Then
                            tmpDateTime = CType (dictEntry.Value, DateTime)
                            lruItemKey = dictEntry.Key.ToString()
                        End If
                    Next dictEntry
                End SyncLock
                Return lruItemKey

            Catch genException As Exception
                ExceptionManager.Publish (genException)
                Throw
            End Try

        End Function

#End Region
    End Class
End Namespace
