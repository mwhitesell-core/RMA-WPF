'===============================================================================
' Microsoft Caching Application Block for .NET
' http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dnpag/html/CachingBlock.asp
'
' InterfaceDefinitions.vb
' This class has all the interfaces with their method definitions required for
' the caching operations.
'
'===============================================================================
' Copyright (C) 2003 Microsoft Corporation
' All rights reserved.
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
' OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
' LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR
' FITNESS FOR A PARTICULAR PURPOSE.
'===============================================================================


Imports System.Xml

#Region "ICacheItemExpiration"

' <summary>
'		Allows end users to implement their own cache item
'		expiration schema.
' </summary>

Public Interface ICacheItemExpiration
    ' <summary>
    '		This method is used to provide two types of expirations. 
    '		The expirations based on an asynchronous notification 
    '		(which are not polled), and the expirations based on a
    '		polling thread which calls the HasExpired method.
    ' </summary>

#Region "Synchronous expiration"

    ' <summary>
    '		Specifies if item has expired or not.
    ' </summary>

    Function HasExpired() As Boolean

    ' <summary>
    '		Notifies that the item was recently used.
    ' </summary>

    Sub Notify()

#End Region

#Region "Asynchronous expiration (user for external dependencies)"

    ' <summary>
    '		This method sets the external dependency key.
    ' </summary>
    Sub Key (ByVal keyValue As String)

    ' <summary>
    '		Event to indicate the cache item expiration.
    ' </summary>
    Event change As ItemDependencyChangeEventHandler

#End Region
End Interface

#End Region

#Region "ICacheMetadata"

' <summary>
'		Allows end users to implement their own cache metadata
'		management schema.
' </summary> 
Public Interface ICacheMetadata
    ' <summary>
    '		Adds new data to the cache metadata storage.
    ' </summary>
    Sub Add (ByVal key As String, ByVal expirations() As ICacheItemExpiration, _
             ByVal priority As CacheItemPriority)

    ' <summary>
    '		Removes the element with the specified key from 
    '		the metadata storage.
    ' </summary>
    Sub Remove (ByVal key As String)

    ' <summary>
    '		Gets all metadata from the metadata storage.
    ' </summary>
    Function GetMetadata() As Hashtable

    ' <summary>
    '		Removes all metadata from the metadata storage.
    ' </summary>
    Sub Flush()
End Interface

#End Region

#Region "IScavengingAlgorithm"

' <summary>
'		Allows end users to implement their own scavenging algorithm.
' </summary>
Public Interface IScavengingAlgorithm
    ' <summary>
    '		Initializes the scavenging algorithm.
    ' </summary>
    Sub Init (ByVal cacheService As CacheService, _
              ByVal cacheStorage As ICacheStorage, _
              ByVal cacheMetadata As ICacheMetadata, ByVal config As XmlNode)

    ' <summary>
    '		Notifies that the element with the specified key
    '		was recently used.
    ' </summary>
    Sub Notify (ByVal key As String)

    ' <summary>
    '		Executes the algorithm.
    ' </summary>
    Sub Execute()

    ' <summary>
    '		Adds a new element to the item algorithm list. 
    '		This list is used when the algorithm is executed.
    ' </summary>
    Sub Add (ByVal key As String, ByVal priority As CacheItemPriority)

    ' <summary>
    '		Removes the element with the specified key from
    '		the item algorithm list.
    ' </summary>
    Sub Remove (ByVal key As String)

    ' <summary>
    '		Removes all elements from the item algorithm list.
    ' </summary>
    Sub Flush()
End Interface

#End Region

#Region "ICacheStorage"

' <summary>
'		Allows end users to implement their own cache management storage.
'		All storage providers must implement this interface.
' </summary>
Public Interface ICacheStorage
    ' <summary>
    '		Inits the storage provider. 
    ' </summary>
    Sub Init (ByVal config As XmlNode)

    ' <summary>
    '		Adds an element with the specified key and value
    '   	into the storage.
    ' </summary>
    Sub Add (ByVal key As String, ByVal keyData As Object)

    ' <summary>
    '		Removes all elements from the storage.
    ' </summary>
    Sub Flush()

    ' <summary>
    '		Gets the element with the specified key.
    ' </summary>
    Function GetData (ByVal key As String) As Object

    ' <summary>
    '		Gets the DataTable with the specified key.
    ' </summary>
    Function GetDataTable (ByVal key As String) As DataTable

    ' <summary>
    '		Removes the element with the specified key.
    ' </summary>
    Sub Remove (ByVal key As String)

    ' <summary>
    '		Updates the element with the specified key.
    ' </summary>
    Sub Update (ByVal key As String, ByVal keyData As Object)

    ' <summary>
    '		Gets the number of elements actually contained in the storage.
    ' </summary>
    ReadOnly Property Size() As Integer
End Interface

#End Region

#Region "IDataProtection"

' <summary>
'		Allows end users to implement their own cache
'		item protection schema.
' </summary>
Public Interface IDataProtection
    ' <summary>
    '		Inits the data protection provider.
    ' </summary>
    Sub Init (ByVal config As XmlNode)

    ' <summary>
    '		Encrypts a raw of bytes.
    ' </summary>
    Function Encrypt (ByVal plainValue() As Byte) As Byte()

    ' <summary>
    '		Decrypts a raw of bytes.
    ' </summary>
    Function Decrypt (ByVal cipherValue() As Byte) As Byte()

    ' <summary>
    '		Computes a hash for data validation.
    ' </summary>
    Function ComputeHash (ByVal plainValue() As Byte) As Byte()
End Interface

#End Region

#Region "IMmfReference"

' <summary>
'	    To increment or decrement the reference count of the 
'	    memory mapped file object.
' </summary>
Public Interface IMmfReference
    ' <summary>
    '	    Increase the reference count value by one.
    ' </summary>
    Function AddReference (ByVal key As String) As Object

    ' <summary>
    '	    Decrease the reference count by one.
    ' </summary>
    Sub RemoveReference (ByVal mmfs As Object)
End Interface

#End Region

