'===============================================================================
' Microsoft Caching Application Block for .NET
' http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dnpag/html/CachingBlock.asp
'
' SingletonCacheStorage.vb
' This class is used to cache data into memory.
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
Imports System.Runtime.Serialization.Formatters.Binary
Imports Core.ExceptionManagement
Imports System.IO

' Used for Handling Exceptions

' Used for Data Protection of the data being cached

Namespace Storages
    ' <summary>
    '		Sample storage provider used to cache data into memory.
    ' </summary>
    ' <remarks>
    '		This provider uses the following attributes on the XML file:
    ' <list type="">
    '		<item><b>Assembly</b> 
    '			Used to specify the provider assembly (Required)
    '	   	</item>
    '		<item><b>ClassName</b> 
    '   		Used to specify the provider class name (Required)
    '		</item>
    '		<item><b>Encrypted</b> 
    '			Specifies if the cache item must be encrypted before 
    '			it is stored (Optional)
    '		</item>
    '		<item><b>Validated</b> 
    '			Specifies if a cache item validation must be done 
    '			to ensure data integrity (Optional)
    '		</item>
    ' </list>
    ' </remarks>

    Public Class SingletonCacheStorage
        Implements ICacheStorage

#Region "Private Members"

        Private cacheStorage As New HybridDictionary()
        Private isValidated As Boolean
        Private isEncrypted As Boolean

#End Region

#Region "Constructor"

        ' <summary>
        '		Default Constructor.
        ' </summary>

        Public Sub New()
        End Sub

#End Region

#Region "Properties"

        ' <summary>
        '		Gets the number of elements actually contained in storage.
        ' </summary>

        ReadOnly Property Size() As Integer Implements ICacheStorage.Size

            Get
                Return cacheStorage.Values.Count
            End Get
        End Property

#End Region

#Region "Implementation of ICacheStorage"

#Region "Init"

        ' <summary>
        '		Initializes the storage provider.
        ' </summary>
        ' <remarks>
        '		ICacheStorage.Init( configSection )
        ' </remarks>
        ' <param name="configSection">
        '   	Represents a single node in the XML document
        ' </param>

        Sub Init (ByVal configSection As XmlNode) Implements _
                                                      ICacheStorage.Init

            Try

                ' Variable Declarations
                Dim validatedString As String
                Dim encryptedString As String
                Const CONST_TRUE As String = "true"
                Const CONST_FALSE As String = "false"

                If Equals (configSection, Nothing) Then
                    Throw (New ArgumentNullException ("configSection", _
                                                      CacheResources.ResourceManager ( _
                                                                                      "RES_ExceptionNullConfigSection")))
                End If

                If (Not Equals (configSection.Attributes ( _
                                                          CacheResources.ResourceManager ("RES_ConfigValidated")), _
                                Nothing)) Then
                    validatedString = configSection.Attributes ( _
                                                                CacheResources.ResourceManager ( _
                                                                                                "RES_ConfigValidated")). _
                        Value
                Else
                    Throw New ConfigurationErrorsException (CacheResources. _
                                                               ResourceManager ("RES_ExceptionEmptyNodeValidated"))
                End If

                If validatedString Is Nothing Then
                    Throw New ConfigurationErrorsException (CacheResources. _
                                                               ResourceManager ("RES_ExceptionNullValidated"))
                ElseIf validatedString.Length = 0 Then
                    Throw New ConfigurationErrorsException (CacheResources. _
                                                               ResourceManager ("RES_ExceptionEmptyValidated"))
                ElseIf Not (Equals (validatedString.ToLower, _
                                    CONST_TRUE) OrElse Equals (validatedString. _
                                                                  ToLower, CONST_FALSE)) Then
                    Throw New ConfigurationErrorsException (CacheResources. _
                                                               ResourceManager ("RES_ExceptionInvalidValidated"))
                Else
                    isValidated = Boolean.Parse (validatedString.ToLower ( _
                                                                          CultureInfo.CurrentCulture))
                End If

                If (Not Equals (configSection.Attributes ( _
                                                          CacheResources.ResourceManager ("RES_ConfigEncrypted")), _
                                Nothing)) Then
                    encryptedString = configSection.Attributes ( _
                                                                CacheResources.ResourceManager ( _
                                                                                                "RES_ConfigEncrypted")). _
                        Value
                Else
                    Throw New ConfigurationErrorsException (CacheResources. _
                                                               ResourceManager ("RES_ExceptionEmptyNodeEncrypted"))
                End If

                If encryptedString Is Nothing Then
                    Throw New ConfigurationErrorsException (CacheResources. _
                                                               ResourceManager ("RES_ExceptionNullEncrypted"))
                ElseIf encryptedString.Length = 0 Then
                    Throw New ConfigurationErrorsException (CacheResources. _
                                                               ResourceManager ("RES_ExceptionEmptyEncrypted"))
                ElseIf Not (Equals (encryptedString.ToLower, _
                                    CONST_TRUE) OrElse Equals (encryptedString. _
                                                                  ToLower, CONST_FALSE)) Then
                    Throw New ConfigurationErrorsException (CacheResources. _
                                                               ResourceManager ("RES_ExceptionInvalidEncrypted"))
                Else
                    isEncrypted = Boolean.Parse (encryptedString.ToLower ( _
                                                                          CultureInfo.CurrentCulture))
                End If

            Catch genException As Exception
                ExceptionManager.Publish (genException)
                Throw
            End Try

        End Sub

#End Region

#Region "Add"

        ' <summary>
        '		Adds an element with the specified key and value into memory.
        ' </summary>
        ' <remarks>
        '		ICacheStorage.Add( key, keyData )
        ' </remarks>
        ' <param name="key">
        '		The unique to identify a value
        ' </param>
        ' <param name="keyData">
        '		The value to be stored
        ' </param>

        Sub Add (ByVal key As String, ByVal keyData As Object) _
            Implements ICacheStorage.Add

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

                If Equals (keyData, Nothing) Then
                    Throw New ArgumentNullException ("keyData", _
                                                     CacheResources.ResourceManager ( _
                                                                                     "RES_ExceptionNullValue"))
                End If

                CType (Me, ICacheStorage).Update (key, keyData)
            Catch genException As Exception
                ExceptionManager.Publish (genException)
                Throw
            End Try

        End Sub

#End Region

#Region "Flush"

        ' <summary>
        '		Removes all elements from the storage.
        ' </summary>
        ' <remarks>
        '		ICacheStorage.Flush()
        ' </remarks>

        Sub Flush() Implements ICacheStorage.Flush

            Try
                ' The HybridDictionary must be synchronized on write access
                SyncLock cacheStorage
                    cacheStorage.Clear()
                End SyncLock

            Catch genException As Exception
                ExceptionManager.Publish (genException)
                Throw
            End Try

        End Sub

#End Region

#Region "GetData"

        ' <summary>
        '       Gets the GetDataTable with the specified key.
        ' </summary>
        ' <remarks>
        '	    ICacheStorage.GetDataTable(key);
        ' </remarks>
        ' <param name="key">
        '	    The unique key to identify the value
        ' </param>
        ' <returns>
        '		The cached DataTable
        ' </returns>
        Function GetDataTable (ByVal key As String) As DataTable Implements ICacheStorage.GetDataTable
            Return CType (GetData (key), DataTable)
        End Function

        ' <summary>
        '		Gets the element with the specified key.
        ' </summary>
        ' <remarks>
        '		returnValue = ICacheStorage.GetData ( key )
        ' </remarks>
        ' <param name="key">
        '		The unique key to identify a value
        ' </param>

        Function GetData (ByVal key As String) As Object _
            Implements ICacheStorage.GetData

            Try
                If Equals (key, Nothing) Then
                    Throw New ArgumentNullException ("keyVal", CacheResources. _
                                                        ResourceManager ("RES_ExceptionNullKey"))
                End If

                If key.Length = 0 Then
                    Throw New ArgumentOutOfRangeException ("keyVal", _
                                                           CacheResources.ResourceManager ( _
                                                                                           "RES_ExceptionEmptyKey"))
                End If

                Dim returnValue As Object
                returnValue = cacheStorage (key)
                If Not (returnValue Is Nothing) AndAlso _
                   (isEncrypted OrElse isValidated) Then

                    ' The value is serialized and must be restored
                    Dim binaryObject As Byte() = CType (returnValue, Byte())
                    If isEncrypted Then
                        binaryObject = DataProtectionManager.Decrypt ( _
                                                                      binaryObject)
                    End If

                    If isValidated Then
                        binaryObject = DataProtectionManager.RemoveMAC ( _
                                                                        binaryObject)
                    End If

                    Dim memStream As New MemoryStream (binaryObject)

                    returnValue = New BinaryFormatter().Deserialize (memStream)
                    memStream.Close()
                End If
                Return returnValue
            Catch genException As Exception
                ExceptionManager.Publish (genException)
                Throw
            End Try

        End Function

#End Region

#Region "Remove"

        ' <summary>
        '		Removes the element with the specified key.
        ' </summary>
        ' <remarks>
        '		ICacheStorage.Remove( key )
        ' </remarks>
        ' <param name="key">
        '		The unique to identify a value
        ' </param>

        Sub Remove (ByVal key As String) Implements ICacheStorage.Remove

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

                ' The HybridDictionary must be synchronized on write access
                SyncLock cacheStorage
                    cacheStorage.Remove (key)
                End SyncLock

            Catch genException As Exception
                ExceptionManager.Publish (genException)
                Throw
            End Try

        End Sub

#End Region

#Region "Update"

        ' <summary>
        '		Updates the element with the specified key.
        ' </summary>
        ' <remarks>
        '		ICacheStorage.Update( key, keyData )
        ' </remarks>
        ' <param name="key">
        '		The unique to identify a value
        ' </param>
        ' <param name="keyData">
        '		The value to be updated
        ' </param>

        Sub Update (ByVal key As String, ByVal keyData As Object) _
            Implements ICacheStorage.Update

            Dim memStream As MemoryStream = New MemoryStream

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

                If Equals (keyData, Nothing) Then
                    Throw New ArgumentNullException ("keyData", _
                                                     CacheResources.ResourceManager ( _
                                                                                     "RES_ExceptionNullValue"))
                End If

                Dim binaryObject() As Byte
                Dim binformatter As New BinaryFormatter()
                memStream = New MemoryStream()
                If isEncrypted OrElse isValidated Then

                    ' If the value is encrypted or signed then it
                    ' must be serialized
                    memStream = New MemoryStream()
                    binformatter.Serialize (memStream, keyData)

                    binaryObject = memStream.ToArray()

                    ' Appends a mac value for data validation
                    If isValidated Then
                        binaryObject = DataProtectionManager.AppendMAC ( _
                                                                        binaryObject)
                    End If

                    If isEncrypted Then
                        binaryObject = DataProtectionManager.Encrypt ( _
                                                                      binaryObject)
                    End If

                    SyncLock cacheStorage
                        cacheStorage (key) = binaryObject
                    End SyncLock
                Else
                    ' The HybridDictionary must be synchronized
                    ' on write access
                    SyncLock cacheStorage
                        cacheStorage (key) = keyData
                    End SyncLock
                End If
            Catch genException As Exception
                ExceptionManager.Publish (genException)
                Throw
            Finally
                memStream.Close()
            End Try

        End Sub

#End Region

#End Region
    End Class
End Namespace
