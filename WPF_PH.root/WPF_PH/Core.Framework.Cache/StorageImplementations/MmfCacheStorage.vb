'===============================================================================
' Microsoft Caching Application Block for .NET
' http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dnpag/html/CachingBlock.asp
'
' MmfCacheStorage.vb
' This class is used to cache data into a shared memory file stream.
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
Imports System.IO
Imports System.Configuration
Imports System.Runtime.Serialization.Formatters.Binary
Imports Core.ExceptionManagement
Imports System.Globalization
Imports System.Threading

' Used for Memory Mapped Files
'Imports Microsoft.ApplicationBlocks.MemoryMappedFile
' Used for Caching Operations
' Used for Data Protection
' Used for Handling Exception

Namespace Storages
    ' <summary>
    '		Sample storage provider used to cache data into
    '		a shared memory file stream.
    ' </summary>
    ' <remarks>
    '		This provider uses the following attributes on the XML file:
    ' <list type="">
    '		<item>
    '		<b>Assembly</b> 
    '		Used to specify the provider assembly (Required)
    '		</item>
    '		<item>
    '		<b>ClassName</b> 
    '		Used to specify the provider class name (Required)
    '		</item>
    '		<item>
    '		<b>BasePath</b> 
    '		Used to specify the folder where the files will be stored
    '		</item>
    '		<item>
    '		<b>Encrypted</b> 
    '		Specifies if the cache item must be encrypted before
    '		it is stored (Optional)
    '		</item>
    '		<item>
    '		<b>Validated</b>
    '		Specifies if a cache item validation must be done to 
    '		ensure data integrity (Optional)
    '		</item>
    ' </list>
    ' </remarks>
    <Serializable()> _
    Public Class MmfCacheStorage
        Implements ICacheStorage, IMmfReference

#Region "Constants"

        Private Const LENGTH As Integer = 4
        Private Const MMF_OBJECT_NAME As String = "mmf_Dictionary"

#End Region

#Region "Field members"

        Private isEncrypted As Boolean
        Private isValidated As Boolean
        ' Dictionary to store mmf objects
        Private handleTable As HybridDictionary
        Dim dictionaryMmfs As MemoryMappedFileStream
        Dim hybridDictionarySize As Integer

#End Region

#Region "Properties"

        ' <summary>
        '       Gets the storage size.
        ' </summary>

        ReadOnly Property Size() As Integer Implements ICacheStorage.Size
            Get
                Try
                    SyncLock handleTable
                        handleTable = CType (GetDictionary (MMF_OBJECT_NAME), _
                            HybridDictionary)
                        Return handleTable.Count
                    End SyncLock
                Catch genException As Exception
                    ExceptionManager.Publish (genException)
                    Throw
                End Try
            End Get
        End Property

#End Region

#Region "Constructor"

        ' <summary>
        '       Default Constructor.
        ' </summary>
        Public Sub New()
        End Sub

        'New

#End Region

#Region "Implementation of ICacheStorage"

#Region "Init"

        ' <summary>
        '       Inits the storage provider.
        ' </summary>
        ' <remarks>
        '	    ICacheStorage.Init( config );
        ' </remarks>
        ' <param name="config">
        '	    The configuration file node
        ' </param>
        Sub Init (ByVal config As XmlNode) Implements _
                                               ICacheStorage.Init
            Try

                Dim validatedString As String
                Dim encryptedString As String
                Dim mmfDictionarySize As String
                Dim storage As Double

                Const CONST_TRUE As String = "true"
                Const CONST_FALSE As String = "false"

                If Equals (config, Nothing) Then
                    Throw New ArgumentNullException ("config", _
                                                     CacheResources.ResourceManager ( _
                                                                                     "RES_ExceptionNullConfigSection"))
                End If

                If (Not Equals (config.Attributes ( _
                                                   CacheResources.ResourceManager ("RES_ConfigValidated")), _
                                Nothing)) Then
                    validatedString = config.Attributes (CacheResources. _
                                                            ResourceManager ("RES_ConfigValidated")).Value
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

                If (Not Equals (config.Attributes ( _
                                                   CacheResources.ResourceManager ("RES_ConfigEncrypted")), _
                                Nothing)) Then
                    encryptedString = config.Attributes (CacheResources. _
                                                            ResourceManager ("RES_ConfigEncrypted")).Value
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

                ' Get the Dictionary size
                If (Not Equals (config.Attributes ( _
                                                   CacheResources.ResourceManager ( _
                                                                                   "RES_ConfigMmfDictionarySize")), _
                                Nothing)) Then

                    mmfDictionarySize = config.Attributes (CacheResources. _
                                                              ResourceManager ("RES_ConfigMmfDictionarySize")).Value

                Else
                    Throw (New ConfigurationErrorsException (CacheResources. _
                                                                ResourceManager ( _
                                                                                 "RES_ExceptionEmptyNodeMmfDictionarySize")))
                End If

                If (mmfDictionarySize.Length = 0) Then

                    Throw (New ConfigurationErrorsException (CacheResources. _
                                                                ResourceManager ( _
                                                                                 "RES_ExceptionEmptyDictionarySize")))
                End If

                If Double.TryParse (mmfDictionarySize, NumberStyles.Integer, _
                                    Nothing, storage) Then

                    If (storage > Integer.MaxValue) Then
                        Throw (New ConfigurationErrorsException (CacheResources. _
                                                                    ResourceManager ( _
                                                                                     "RES_ExceptionMaxDictionarySize")))
                    End If
                    hybridDictionarySize = Integer.Parse (mmfDictionarySize)
                    If (hybridDictionarySize < 1) Then
                        Throw (New ConfigurationErrorsException (CacheResources. _
                                                                    ResourceManager ( _
                                                                                     "RES_ExceptionMinDictionarySize")))
                    End If

                Else
                    Throw (New ConfigurationErrorsException (CacheResources. _
                                                                ResourceManager ( _
                                                                                 "RES_ExceptionInvalidDictionarySize")))
                End If

                ' Check whether the dictionary object is available in
                ' the shared memory (created by some other process)

                ' Synchronize the access
                SyncLock Me
                    Dim handle As Integer = _
                            MemoryMappedFileStream.OpenDictionary ( _
                                                                   MMF_OBJECT_NAME, _
                                                                   MemoryProtection.PageReadWrite)

                    ' Create Hybrid dictionary object
                    handleTable = New HybridDictionary()
                    If handle = 0 Then
                        ' Add the dictionary to shared memory because 
                        ' it is not available already
                        AddDictionary (MMF_OBJECT_NAME)
                    End If
                End SyncLock

            Catch genException As Exception
                ExceptionManager.Publish (genException)
                Throw
            End Try
        End Sub

        'ICacheStorage.Init

#End Region

#Region "Remove"


        ' <summary>
        '       Removes the element with the specified key.
        ' </summary>
        ' <remarks>
        '	    ICacheStorage.Remove( key );
        ' </remarks>
        ' <param name="key">
        '	    The unique key to identify the value
        ' </param>
        Sub Remove (ByVal key As String) Implements ICacheStorage.Remove

            If Equals (key, Nothing) Then
                Throw New ArgumentNullException ("key", _
                                                 CacheResources.ResourceManager ( _
                                                                                 "RES_ExceptionNullKey"))
            End If

            If key.Length = 0 Then
                Throw New ArgumentOutOfRangeException ("key", _
                                                       CacheResources.ResourceManager ( _
                                                                                       "RES_ExceptionEmptyKey"))
            End If

            ' Synchronize access to the memory just in case 
            ' some other thread is reading while another 
            ' removes the cache item
            Dim mutexSync As New Mutex (False, GetHandleName (key))
            Try
                mutexSync.WaitOne()
                SyncLock handleTable
                    ' Get the memory mapped file stream object
                    handleTable = CType (GetDictionary (MMF_OBJECT_NAME), _
                        HybridDictionary)
                    Dim mmfs As MemoryMappedFileStream = _
                            CType (handleTable (key), MemoryMappedFileStream)

                    If Not Equals (mmfs, Nothing) Then
                        ' Call the CloseHandle method
                        mmfs.CloseMapHandle()
                        mmfs.Dispose()
                    End If

                    ' Remove the key from the dictionary
                    handleTable.Remove (key)

                    AddDictionary (MMF_OBJECT_NAME)
                End SyncLock
            Catch genException As Exception
                ExceptionManager.Publish (genException)
                Throw
            Finally
                mutexSync.ReleaseMutex()
            End Try
        End Sub

        'ICacheStorage.Remove 

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
        '       Gets the element with the specified key.
        ' </summary>
        ' <remarks>
        '	    ICacheStorage.GetData(key);
        ' </remarks>
        ' <param name="key">
        '	    The unique key to identify the value
        ' </param>
        ' <returns>
        '	    The value retrieved
        ' </returns>
        Function GetData (ByVal key As String) As Object _
            Implements ICacheStorage.GetData
            Try
                Dim returnValue As Object = Nothing

                If Equals (key, Nothing) Then
                    Throw New ArgumentNullException ("key", _
                                                     CacheResources.ResourceManager ("RES_ExceptionNullKey"))
                End If
                If key.Length = 0 Then
                    Throw New ArgumentOutOfRangeException ("key", _
                                                           CacheResources.ResourceManager ("RES_ExceptionEmptyKey"))
                End If

                Dim totalSize As Integer = 0

                ' Check whether the data is available in the cache

                SyncLock handleTable
                    handleTable = CType (GetDictionary (MMF_OBJECT_NAME), _
                        HybridDictionary)
                End SyncLock
                If Not handleTable.Contains (key) Then
                    Return Nothing
                End If

                ' Synchronize access to the memory
                Dim mutexSync As New Mutex (False, GetHandleName (key))
                Try

                    mutexSync.WaitOne()
                    Dim mmfs As MemoryMappedFileStream = _
                            MemoryMappedFileStream.OpenExisting ( _
                                                                 GetKeyName (key), _
                                                                 MemoryProtection.PageReadWrite)

                    Try
                        mmfs.MapViewToProcessMemory (0, LENGTH)

                        Dim memoryReader As New BinaryReader (mmfs)
                        ' Read the data length
                        totalSize = memoryReader.ReadInt32()
                    Finally
                        mmfs.CloseMapHandle()
                        mmfs.Dispose()
                    End Try

                    mmfs = MemoryMappedFileStream.OpenExisting ( _
                                                                GetKeyName (key), _
                                                                MemoryProtection.PageReadWrite)
                    Try
                        mmfs.MapViewToProcessMemory (0, totalSize + LENGTH)

                        Dim memoryReader As New BinaryReader (mmfs)

                        ' Read the data length
                        totalSize = memoryReader.ReadInt32()
                        If totalSize = 0 Then
                            Return Nothing
                        End If

                        Dim memStream As New MemoryStream (totalSize)

                        ' Read the data from the stream
                        CopyStreams (mmfs, memStream, totalSize)

                        If isEncrypted OrElse isValidated Then
                            Dim binaryObject As Byte() = memStream.ToArray()

                            If isEncrypted Then
                                binaryObject = DataProtectionManager. _
                                    Decrypt (binaryObject)
                            End If

                            If isValidated Then
                                binaryObject = DataProtectionManager. _
                                    RemoveMAC (binaryObject)
                            End If

                            memStream = New MemoryStream (binaryObject)
                        End If

                        memStream.Seek (0, SeekOrigin.Begin)
                        returnValue = New _
                            BinaryFormatter().Deserialize (memStream)
                        memStream.Close()

                        Return returnValue

                    Finally
                        mmfs.CloseMapHandle()
                        mmfs.Dispose()
                    End Try
                Finally
                    mutexSync.ReleaseMutex()
                End Try
            Catch genException As Exception
                ExceptionManager.Publish (genException)
                Throw
            End Try
        End Function

        'ICacheStorage.GetData

#End Region

#Region "Update"

        ' <summary>
        ' 	    Updates the element with the specified key.
        ' </summary>
        ' <remarks>
        '	    ICacheStorage.Update(key, keyData);
        ' </remarks>
        ' <param name="key">
        '	    The unique key to identify the value
        ' </param>
        ' <param name="keyData">
        '	    The value to be updated
        ' </param>
        Sub Update (ByVal key As String, ByVal keyData As Object) _
            Implements ICacheStorage.Update

            Dim memStream As New MemoryStream()
            Dim binaryObject As Byte() = Nothing

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

                ' Serialization
                Dim binFormatter As New BinaryFormatter()
                binFormatter.Serialize (memStream, keyData)
                memStream.Seek (0, SeekOrigin.Begin)

                If isEncrypted OrElse isValidated Then
                    binaryObject = memStream.ToArray()

                    If isValidated Then
                        binaryObject = _
                            DataProtectionManager.AppendMAC (binaryObject)
                    End If

                    If isEncrypted Then
                        binaryObject = _
                            DataProtectionManager.Encrypt (binaryObject)
                    End If

                    memStream = New MemoryStream (binaryObject)
                End If

                Dim mmfs As New MemoryMappedFileStream (GetKeyName (key), _
                                                        memStream.Length + LENGTH, _
                                                        MemoryProtection.PageReadWrite)
                Try

                    Dim mutexSync As New Mutex (False, GetHandleName (key))

                    Try
                        mutexSync.WaitOne()

                        mmfs.MapViewToProcessMemory (0, _
                                                     CInt (memStream.Length) + LENGTH)

                        ' Write the data length
                        Dim memoryWriter As New BinaryWriter (mmfs)

                        memoryWriter.Write (CInt (memStream.Length))

                        ' Write the data
                        CopyStreams (memStream, _
                                     mmfs, _
                                     CInt (memStream.Length))

                        ' Update the memory mapped object to the hash table
                        SyncLock handleTable

                            handleTable = CType (GetDictionary (MMF_OBJECT_NAME), _
                                HybridDictionary)

                            ' Remove the key and add again
                            handleTable.Remove (key)
                            handleTable.Add (key, mmfs)

                            AddDictionary (MMF_OBJECT_NAME)
                        End SyncLock

                    Finally
                        mutexSync.ReleaseMutex()
                        mmfs.CloseMapHandle()
                        mmfs.Dispose()
                    End Try
                Finally
                    mmfs.Dispose()
                End Try

                memStream.Close()
            Catch genException As Exception
                ExceptionManager.Publish (genException)
                Throw
            End Try
        End Sub

        'ICacheStorage.Update

#End Region

#Region "Add"


        ' <summary>
        '	    Adds an element with the specified key and value into the shared 
        '	    memory stream.
        ' </summary>
        ' <remarks>
        '	    ICacheStorage.Add(key, keyData);
        ' </remarks>
        ' <param name="key">
        '	    The unique key to identify the value
        ' </param>
        ' <param name="keyData">
        '	    The value to be added
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

                ' Serializes the value in order to store it 
                Dim memStream As New MemoryStream()
                Dim binaryObject As Byte() = Nothing
                Dim bFormatter As New BinaryFormatter()
                bFormatter.Serialize (memStream, keyData)

                If isEncrypted OrElse isValidated Then
                    binaryObject = memStream.ToArray()

                    ' Appends a mac value for data validation
                    If isValidated Then
                        binaryObject = _
                            DataProtectionManager.AppendMAC (binaryObject)
                    End If

                    ' Encrypts the value
                    If isEncrypted Then
                        binaryObject = _
                            DataProtectionManager.Encrypt (binaryObject)
                    End If

                    memStream = New MemoryStream (binaryObject)
                End If

                memStream.Seek (0, SeekOrigin.Begin)

                Dim mmfs As New MemoryMappedFileStream (GetKeyName (key), _
                                                        memStream.Length + LENGTH, MemoryProtection.PageReadWrite)
                Try

                    Dim mutexSync As New Mutex (False, GetHandleName (key))
                    Try
                        mutexSync.WaitOne()

                        mmfs.MapViewToProcessMemory (0, _
                                                     CInt (memStream.Length) + LENGTH)

                        ' Write the data length
                        Dim memoryWriter As New BinaryWriter (mmfs)
                        memoryWriter.Write (CInt (memStream.Length))

                        ' Write the data
                        CopyStreams (memStream, mmfs, CInt (memStream.Length))

                        ' Add the memory mapped object to the hash table
                        SyncLock handleTable

                            handleTable = CType (GetDictionary (MMF_OBJECT_NAME), _
                                HybridDictionary)

                            If Not handleTable.Contains (key) Then
                                handleTable.Add (key, mmfs)
                            End If

                            AddDictionary (MMF_OBJECT_NAME)
                        End SyncLock
                    Finally
                        mutexSync.ReleaseMutex()
                        mmfs.Dispose()
                    End Try
                Finally
                    mmfs.Dispose()
                End Try

                memStream.Close()
            Catch genException As Exception
                ExceptionManager.Publish (genException)
                Throw
            End Try
        End Sub

        'ICacheStorage.Add

#End Region

#Region "Flush"

        ' <summary>
        '	    Removes all elements from the storage.
        ' </summary>
        ' <remarks>
        '	    ICacheStorage.Flush();
        ' </remarks>
        Sub Flush() Implements ICacheStorage.Flush
            Try
                RemoveAllKeys()
            Catch genException As Exception
                ExceptionManager.Publish (genException)
                Throw
            End Try
        End Sub

        'ICacheStorage.Flush

#End Region

#End Region

#Region "Implementation of IMmfStorage"

        ' <summary>
        '	    Opens the already existing file mapping object. It returns
        '	    the MemoryMappedFileStream object which contains a 
        '	    handle to the opened file mapping object.
        ' </summary>
        ' <remarks>
        '	    IMmfReference.AddReference(key)
        ' </remarks>
        ' <param name="key">
        '	    The unique key to identify the value
        ' </param>
        Function AddReference (ByVal key As String) As Object _
            Implements IMmfReference.AddReference

            Dim mutexSync As Mutex = New Mutex (False, GetHandleName (key))
            Try
                mutexSync.WaitOne()
                Dim mmfs As MemoryMappedFileStream = _
                        MemoryMappedFileStream.OpenExisting ( _
                                                             GetKeyName (key), _
                                                             MemoryProtection.PageReadWrite)

                Return mmfs

            Finally
                mutexSync.ReleaseMutex()
            End Try
        End Function

        ' <summary>
        '	    Removes the reference by calling the closehandle function.
        ' </summary>
        ' <remarks>
        '	    IMmfReference.RemoveReference(memoryMap);
        ' </remarks>
        ' <param name="memoryMap">
        '       The MemoryMappedFileStream object which 
        '       contains the handle to close
        ' </param>
        Sub RemoveReference (ByVal memoryMap As Object) _
            Implements IMmfReference.RemoveReference

            Dim mmfs As MemoryMappedFileStream = _
                    CType (memoryMap, MemoryMappedFileStream)
            If Not Equals (mmfs, Nothing) Then
                mmfs.CloseMapHandle()
            End If
        End Sub

#End Region

#Region "Private methods"

        ' <summary>
        '		Gets the complete key name.
        ' </summary>
        ' <remarks>
        '		fileName = GetKeyName( key )
        ' </remarks>
        ' <param name="key">
        '		The unique key to identify the value
        ' </param>
        Function GetKeyName (ByVal key As String) As String

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
                Const INVALID_CHAR As String = """/\?*|:"
                If key.IndexOfAny (INVALID_CHAR.ToCharArray()) >= 0 Then
                    Throw New Exception (CacheResources. _
                                            ResourceManager ("RES_ExceptionInvalidChar"))
                End If
                Dim fileName As String
                fileName = CacheResources.ResourceManager ( _
                                                           "RES_KeyFileName") + key
                Return fileName
            Catch genException As Exception
                ExceptionManager.Publish (genException)
                Throw
            End Try

        End Function

        ' <summary>
        '		Gets a mutex handle name.
        ' </summary>
        ' <remarks>
        '		filepath = GetHandleName( key )
        ' </remarks>
        ' <param name="key">
        '		The unique key to identify the value
        ' </param>
        Function GetHandleName (ByVal key As String) As String

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
                Dim mutexName As String = CacheResources. _
                        ResourceManager ("RES_MutexName")
                Return mutexName + key
            Catch genException As Exception
                ExceptionManager.Publish (genException)
                Throw
            End Try

        End Function

        ' <summary>
        '		Copies a number of elements from the first 
        '		stream to the second stream.
        ' </summary>
        ' <remarks>
        '		CopyStreams( from, to, count )
        ' </remarks>
        ' <param name="from">
        '		Indicates the start point of file
        ' </param>
        ' <param name="to">
        '		Indicates the end point of file
        ' </param>
        ' <param name="count">
        '		Length of the byte stream to be copied
        ' </param>
        Sub CopyStreams (ByVal from As Stream, ByVal [to] As Stream, _
                         ByVal count As Integer)

            Try

                Dim readed As Integer
                Dim totalReaded As Integer
                Dim tempBuffer(Convert.ToInt32 (CacheResources. _
                                                   ResourceManager ("RES_BufferSize"))) As Byte

                While totalReaded < from.Length AndAlso totalReaded < count
                    readed = from.Read (tempBuffer, 0, _
                                        tempBuffer.Length)

                    [to].Write (tempBuffer, 0, IIf (readed > count, _
                                                    count, readed))

                    totalReaded += readed
                End While

            Catch genException As Exception
                ExceptionManager.Publish (genException)
                Throw
            End Try

        End Sub

        ' <summary>
        '       This method removes all the cache files in the disk.
        ' </summary>
        ' <remarks>
        '	    RemoveAllKeys();
        ' </remarks>
        Private Sub RemoveAllKeys()
            ' Synchronize access
            Dim mutexSync As New Mutex()
            Try
                mutexSync.WaitOne()
                SyncLock handleTable

                    handleTable = CType (GetDictionary (MMF_OBJECT_NAME), _
                        HybridDictionary)
                    Dim key As Object
                    For Each key In handleTable.Keys
                        Dim mmfs As MemoryMappedFileStream = _
                                CType (handleTable (key), MemoryMappedFileStream)
                        If Not Equals (mmfs, Nothing) Then
                            mmfs.CloseMapHandle()
                            mmfs.Dispose()
                        End If
                    Next key
                    ' Clear the contents

                    handleTable.Clear()
                    AddDictionary (MMF_OBJECT_NAME)
                End SyncLock
            Catch genException As Exception
                ExceptionManager.Publish (genException)
                Throw
            Finally
                mutexSync.ReleaseMutex()
            End Try
        End Sub

        'RemoveAllKeys


        ' <summary>
        '	    Adds the Hybrid dictionary object to the shared memory.
        ' </summary>
        ' <remarks>
        '	    AddDictionary(key);
        ' </remarks>
        ' <param name="key">
        '	    The unique key to identify the dictionary
        ' </param>
        Private Sub AddDictionary (ByVal key As String)

            ' Close the dictionary Handle
            If Not Equals (dictionaryMmfs, Nothing) Then
                dictionaryMmfs.CloseMapHandle()
                dictionaryMmfs.Dispose()
            End If

            ' Serializes the value in order to store it 
            Dim memStream As New MemoryStream()
            Dim bFormatter As New BinaryFormatter()
            bFormatter.Serialize (memStream, handleTable)

            memStream.Seek (0, SeekOrigin.Begin)

            Dim dictMmfs As New MemoryMappedFileStream (key, _
                                                        hybridDictionarySize, MemoryProtection.PageReadWrite)
            Try

                Dim mutexSync As New Mutex (False, GetHandleName (key))
                Try
                    mutexSync.WaitOne()

                    dictMmfs.MapViewToProcessMemory (0, _
                                                     CInt (memStream.Length) + LENGTH)

                    ' Write the data length
                    Dim memoryWriter As New BinaryWriter (dictMmfs)
                    memoryWriter.Write (CInt (memStream.Length))

                    ' Write the data
                    CopyStreams (memStream, dictMmfs, CInt (memStream.Length))

                Finally
                    mutexSync.ReleaseMutex()
                End Try
            Finally
                dictMmfs.Dispose()
            End Try

            memStream.Close()
        End Sub

        ' <summary>
        '	    Gets the Hybrid dictionary object from the shared memory.
        ' </summary>
        ' <remarks>
        '	    HybridDictionary dictionary = GetDictionary(key);
        ' </remarks>
        ' <param name="key">
        '	    The unique key to identify dictionary
        ' </param>
        Private Function GetDictionary (ByVal key As String) As Object

            Dim returnValue As Object = Nothing

            Dim totalSize As Integer = 0

            Dim mutexSync As New Mutex (False, GetHandleName (key))
            Try
                mutexSync.WaitOne()
                ' Open the existing file mapping object for reading
                Dim dictMmfs As MemoryMappedFileStream = _
                        MemoryMappedFileStream.OpenExisting ( _
                                                             key, _
                                                             MemoryProtection.PageReadWrite)

                Try

                    dictMmfs.MapViewToProcessMemory (0, LENGTH)

                    Dim memoryReader As New BinaryReader (dictMmfs)
                    ' Read the data length
                    totalSize = memoryReader.ReadInt32()
                Finally
                    dictMmfs.CloseMapHandle()
                    dictMmfs.Dispose()
                End Try


                dictMmfs = MemoryMappedFileStream.OpenExisting ( _
                                                                key, _
                                                                MemoryProtection.PageReadWrite)
                Try
                    dictMmfs.MapViewToProcessMemory (0, totalSize + LENGTH)

                    Dim memoryReader As New BinaryReader (dictMmfs)

                    ' Read the data length
                    totalSize = memoryReader.ReadInt32()
                    If totalSize = 0 Then
                        Return Nothing
                    End If

                    Dim memStream As New MemoryStream (totalSize)

                    ' Read the data from the stream
                    CopyStreams (dictMmfs, memStream, totalSize)

                    memStream.Seek (0, SeekOrigin.Begin)
                    returnValue = New _
                        BinaryFormatter().Deserialize (memStream)
                    memStream.Close()

                    Return returnValue
                Finally
                    dictMmfs.CloseMapHandle()
                    dictMmfs.Dispose()
                End Try
            Finally
                mutexSync.ReleaseMutex()
            End Try

        End Function

#End Region
    End Class

    'MmfCacheStorage
End Namespace

'Core.Framework.Cache.Storages
