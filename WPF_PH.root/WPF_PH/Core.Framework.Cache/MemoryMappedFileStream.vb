'===============================================================================
' Microsoft Caching Application Block for .NET
' http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dnpag/html/CachingBlock.asp
'
' MemoryMappedFileStream.vb
' This class provides methods to create, provide file access, write, read and
' remove a memory mapped file from the store.
'
'===============================================================================
' Copyright (C) 2003 Microsoft Corporation
' All rights reserved.
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
' OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
' LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR
' FITNESS FOR A PARTICULAR PURPOSE.
'===============================================================================


Imports System.IO
Imports System.Resources
Imports System.Reflection
Imports System.Runtime.InteropServices

' <summary>
'		This class provides methods to create, provide file
'		access, write, read and remove a memory mapped file
'		from the store.
' </summary>
<Serializable()> _
Public Class MemoryMappedFileStream
    Inherits Stream

#Region "Field & constant declaration"

    Private Shared rm As New ResourceManager (GetType (MemoryMappedFileStream). _
                                                  Namespace + ".MemoryMappedFileText", Assembly.GetExecutingAssembly())

    Private memProtection As MemoryProtection
    Private objectName As String
    Private mapLength As Long
    Private dataPosition As Long
    Private viewOffSet As Integer
    Private viewLength As Integer

    Private isReadable As Boolean
    Private isWritable As Boolean
    Private isSeekable As Boolean

    Private mapHandle As Integer
    Private mapViewPointer As IntPtr

#End Region

#Region "Constructors"

    Private Sub New (ByVal mapHandler As Integer, _
                     ByVal protection As MemoryProtection)

        If mapHandler = 0 Then
            Throw (New ArgumentOutOfRangeException ("mapHandler", _
                                                    rm.GetString ("ArgumentOutOfRange_MapHandler")))
        End If

        isReadable = True
        isWritable = True
        isSeekable = True
        mapHandle = mapHandler
        mapLength = 0
        memProtection = protection

    End Sub


    Public Sub New (ByVal name As String, ByVal protection As MemoryProtection)
        MyClass.New (name, 0, protection)
    End Sub


    Public Sub New (ByVal name As String, ByVal maxLength As Long, _
                    ByVal protection As MemoryProtection)

        If Equals (name, Nothing) OrElse name.Length = 0 Then
            Throw (New ArgumentException (rm.GetString ( _
                                                        "Argument_Name"), "name"))
        End If

        If (maxLength < 0) Then
            Throw (New ArgumentOutOfRangeException ("memoryLength", _
                                                    rm.GetString ("ArgumentOutOfRange_MaxLength")))
        End If

        objectName = name

        If protection < MemoryProtection.PageNoAccess OrElse _
           protection > MemoryProtection.SecReserve Then
            Throw New ArgumentOutOfRangeException ("protection", rm.GetString ( _
                                                                               "ArgumentOutOfRange_Enum"))
        End If

        If Equals (maxLength, 0) Then
            maxLength = Convert.ToInt32 (rm.GetString ("Default_Length_Size"))
        Else
            mapLength = maxLength
        End If

        memProtection = protection

        isReadable = True
        isWritable = True
        isSeekable = True

        ' Initialize mapViewPointer
        mapViewPointer = New IntPtr (- 1)

        Dim securityAttribute As MemoryMappedFileHelper.SECURITY_ATTRIBUTES

        mapHandle = MemoryMappedFileHelper.CreateFileMapping (&HFFFFFFFF, _
                                                              securityAttribute, memProtection, 0, mapLength, objectName)

        If mapHandle = 0 Then
            Dim lastError As Long = MemoryMappedFileHelper.GetLastError()
            Throw New IOException (MemoryMappedFileHelper. _
                                      GetWin32ErrorMessage (lastError))
        End If

    End Sub

#End Region

#Region "Stream class implementation"

    ' <summary>
    '		Gets the status whether the memory mapped 
    '		file has read access.
    ' </summary>

    Public Overrides ReadOnly Property CanRead() As Boolean

        Get
            Return Not Equals (mapViewPointer, _
                               IntPtr.Zero) AndAlso isReadable
        End Get
    End Property

    ' <summary>
    '		Gets the status whether the memory mapped 
    '		file has seek access.
    ' </summary>

    Public Overrides ReadOnly Property CanSeek() As Boolean

        Get
            Return Not Equals (mapViewPointer, _
                               IntPtr.Zero) AndAlso isSeekable
        End Get
    End Property

    ' <summary>
    '		Gets the status whether the memory mapped 
    '		file has write access.
    ' </summary>

    Public Overrides ReadOnly Property CanWrite() As Boolean

        Get
            Return Not Equals (mapViewPointer, _
                               IntPtr.Zero) AndAlso isWritable
        End Get
    End Property

    ' <summary>
    '		Removes all the memory mapped files from the store.
    ' </summary>

    Public Overrides Sub Flush()

        MemoryMappedFileHelper.FlushViewOfFile (mapViewPointer, viewLength)

    End Sub

    ' <summary>
    '		Gets the length of the memory mapped file.
    ' </summary>

    Public Overrides ReadOnly Property Length() As Long

        Get
            Return viewLength
        End Get
    End Property

    ' <summary>
    '		Gets the position of the memory mapped file.
    ' </summary>

    Public Overrides Property Position() As Long

        Get
            Return dataPosition
        End Get

        Set (ByVal value As Long)
            dataPosition = value
        End Set
    End Property

    ' <summary>
    '		Reads the number of bytes from the buffer.
    ' </summary>
    ' <remarks>
    '		tempCount = Read( buffer, offset, count )
    ' </remarks>
    ' <param name="buffer">
    '		The data to be written
    ' </param>
    ' <param name="offset">
    '		The start position
    ' </param>
    ' <param name="count">
    '		The length of the binary stream to be written
    ' </param>

    Public Overrides Function Read (ByVal buffer() As Byte, _
                                    ByVal offset As Integer, ByVal count As Integer) As Integer

        If Equals (buffer, Nothing) Then
            Throw (New ArgumentNullException ("buffer", _
                                              rm.GetString ("ArgumentNull_Buffer")))
        End If

        If (offset < 0) Then
            Throw (New ArgumentOutOfRangeException ("offSet", _
                                                    rm.GetString ("ArgumentOutOfRange_OffSet")))
        End If

        If (count < 0) Then
            Throw (New ArgumentOutOfRangeException ("count", _
                                                    rm.GetString ("ArgumentOutOfRange_Count")))
        End If

        Dim tempCount As Integer = count
        If (dataPosition + count) > viewLength Then
            tempCount = viewLength - CInt (dataPosition)
        End If

        Marshal.Copy (New IntPtr (mapViewPointer.ToInt32() + dataPosition), _
                      buffer, offset, tempCount)

        dataPosition += tempCount
        Return tempCount

    End Function

    ' <summary>
    '		Sets a position within the stream of bytes.
    ' </summary>
    '		seekPosition = Seek( offset, origin )
    ' <param name="offset">
    '		The offset position
    ' </param>
    ' <param name="origin">
    '		Origin position of the file
    ' </param>

    Public Overrides Function Seek (ByVal offset As Long, _
                                    ByVal origin As SeekOrigin) As Long

        If (offset < 0) Then
            Throw (New ArgumentOutOfRangeException ("offSet", _
                                                    rm.GetString ("ArgumentOutOfRange_OffSet")))
        End If

        Select Case origin
            Case SeekOrigin.Begin
                dataPosition = offset
            Case SeekOrigin.Current
                dataPosition += offset
            Case SeekOrigin.End
                dataPosition = viewLength - offset
        End Select

        Return dataPosition

    End Function

    ' <summary>
    '		Set the length of the memory mapped file.
    ' </summary>
    ' <remarks>
    '		SetLength( memoryLength )
    ' </remarks>
    ' <param name="memoryLength">
    '		The length of the file
    ' </param>
    Public Overrides Sub SetLength (ByVal memoryLength As Long)

        If (memoryLength < 0) Then
            Throw (New ArgumentOutOfRangeException ("memoryLength", _
                                                    rm.GetString ("ArgumentOutOfRange_MemoryLength")))
        End If

        MapViewToProcessMemory (viewOffSet, CInt (memoryLength))

    End Sub

    ' <summary>
    '		Write the binary data into the memory mapped file.
    ' </summary>
    ' <remarks>
    '		Write( buffer, offset, count )
    ' </remarks>
    ' <param name="buffer">
    '		The data to be written
    ' </param>
    ' <param name="offset">
    '		The start position
    ' </param>
    ' <param name="count">
    '		The length of the binary stream to be written
    ' </param>
    Public Overrides Sub Write (ByVal buffer() As Byte, _
                                ByVal offset As Integer, ByVal count As Integer)

        If Equals (buffer, Nothing) Then
            Throw (New ArgumentNullException ("buffer", _
                                              rm.GetString ("ArgumentNull_Buffer")))
        End If

        If (offset < 0) Then
            Throw (New ArgumentOutOfRangeException ("offSet", _
                                                    rm.GetString ("ArgumentOutOfRange_OffSet")))
        End If

        If (count < 0) Then
            Throw (New ArgumentOutOfRangeException ("count", _
                                                    rm.GetString ("ArgumentOutOfRange_Count")))
        End If

        If dataPosition + count > viewLength Then
            Throw New IOException (rm.GetString ("Cant_write_end_stream"))
        End If

        Marshal.Copy (buffer, offset, New IntPtr (mapViewPointer.ToInt32() + _
                                                  dataPosition), count)

        dataPosition += count

    End Sub

    ' <summary>
    '		Close the memory mapped file.
    ' </summary>    
    ' <remarks>
    '		Close()
    ' </remarks>
    Public Overrides Sub Close()

        If Not Equals (mapViewPointer, IntPtr.Zero) Then
            MemoryMappedFileHelper.UnmapViewOfFile (mapViewPointer)
        End If

        MyBase.Close()
        GC.SuppressFinalize (Me)

    End Sub

    ' <summary>
    '		Close the memory mapped handle.
    ' </summary>    
    ' <remarks>
    '		CloseMapHandle()
    ' </remarks>
    Public Sub CloseMapHandle()
        If Not Equals (mapHandle, IntPtr.Zero) Then
            MemoryMappedFileHelper.CloseHandle (New IntPtr (mapHandle))
        End If
    End Sub

#End Region

#Region "Custom methods"

#Region "MapViewToProcessMemory"

    ' <summary>
    '		View the length and the offset of the memory
    '		mapped file.
    ' </summary>
    ' <remarks>
    '		MapViewToProcessMemory( offSet, count )
    ' </remarks>
    ' <param name="offSet">
    '		The start position
    ' </param>
    ' <param name="count">
    '		The length of the binary stream
    ' </param>

    Public Sub MapViewToProcessMemory (ByVal offSet As Integer, _
                                       ByVal count As Integer)
        Const MEMORY_UNAVAILABLE As Integer = 5

        If (offSet < 0) Then
            Throw (New ArgumentOutOfRangeException ("offSet", _
                                                    rm.GetString ("ArgumentOutOfRange_OffSet")))
        End If

        If (count < 0) Then
            Throw (New ArgumentOutOfRangeException ("count", _
                                                    rm.GetString ("ArgumentOutOfRange_Count")))
        End If

        If Equals (mapViewPointer, IntPtr.Zero) Then
            MemoryMappedFileHelper.UnmapViewOfFile (mapViewPointer)
        End If

        mapViewPointer = MemoryMappedFileHelper.MapViewOfFile (mapHandle, _
                                                               MemoryMappedFileHelper.GetWin32FileMapAccess ( _
                                                                                                             memProtection), _
                                                               CType (offSet, Long), 0, CType (count, Long))

        If Equals (mapViewPointer, IntPtr.Zero) Then
            ' If GetLastError returns 5 throw specific exception
            If MemoryMappedFileHelper.GetLastError() = MEMORY_UNAVAILABLE Then
                Throw New Exception (rm.GetString ("RES_MemoryUnavailable"))
            Else
                Throw New IOException (MemoryMappedFileHelper. _
                                          GetWin32ErrorMessage (MemoryMappedFileHelper. _
                                                                   GetLastError()))
            End If
        End If

        viewOffSet = offSet
        viewLength = count
    End Sub

#End Region

#Region "SetMaxLength"

    ' <summary>
    '		Set the maximum length of the file.
    ' </summary>
    ' <remarks>
    '		SetMaxLength( maxLength )
    ' </remarks>
    ' <param name="maxLength">
    '		Specifies the length to be set
    ' </param>

    Public Sub SetMaxLength (ByVal maxLength As Long)

        If (maxLength < 0) Then
            Throw (New ArgumentOutOfRangeException ("memoryLength", _
                                                    rm.GetString ("ArgumentOutOfRange_MaxLength")))
        End If

        If Not Equals (mapViewPointer, IntPtr.Zero) Then
            MemoryMappedFileHelper.UnmapViewOfFile (mapViewPointer)
        End If

        MemoryMappedFileHelper.CloseHandle (New IntPtr (mapHandle))
        mapLength = maxLength

        Dim securityAttribute As MemoryMappedFileHelper.SECURITY_ATTRIBUTES

        mapHandle = MemoryMappedFileHelper.CreateFileMapping (&HFFFFFFFF, _
                                                              securityAttribute, memProtection, 0, mapLength, objectName)

        If Equals (mapHandle, IntPtr.Zero) Then
            Throw New IOException (MemoryMappedFileHelper. _
                                      GetWin32ErrorMessage (MemoryMappedFileHelper. _
                                                               GetLastError()))
        End If

        Me.MapViewToProcessMemory (viewOffSet, viewLength)

    End Sub

#End Region

#Region "OpenExisting"

    ' <summary>
    '		Open the existing memory mapped file.
    ' </summary>
    ' <remarks>
    '		mmfs = OpenExisting( name, protection  )
    ' </remarks>
    ' <param name="name">
    '		The name of the file
    ' </param>
    ' <param name="protection">
    '		The protection rights of the file
    ' </param>
    ' <returns>
    '		An instance of MemoryMappedFileStream class 
    ' </returns>

    Public Shared Function OpenExisting (ByVal name As String, _
                                         ByVal protection As MemoryProtection) As MemoryMappedFileStream

        If Equals (name, Nothing) OrElse name.Length = 0 Then
            Throw (New ArgumentException (rm.GetString ( _
                                                        "Argument_Name"), "name"))
        End If

        Dim mapHandler As Integer = MemoryMappedFileHelper.OpenFileMapping ( _
                                                                            MemoryMappedFileHelper.GetWin32FileMapAccess ( _
                                                                                                                          protection), _
                                                                            False, _
                                                                            name)

        If mapHandler = - 1 Then
            Throw New IOException (MemoryMappedFileHelper. _
                                      GetWin32ErrorMessage (MemoryMappedFileHelper. _
                                                               GetLastError()))
        End If

        Return New MemoryMappedFileStream (mapHandler, protection)

    End Function

    ' <summary>
    '       Open the dictionary object if it is available. This method is
    '       specifically used in the MmfStorage to find out the existance of
    '       the HybridDictionary object.
    ' </summary>
    ' <remarks>
    '		Dim handle as Integer = OpenDictionary( name, protection  )
    ' </remarks>
    ' <param name="name">
    '		The name of the file
    ' </param>
    ' <param name="protection">
    '		The protection rights of the file
    ' </param>
    ' <returns>
    '		The Handle of the dictionary object
    ' </returns>

    Public Shared Function OpenDictionary (ByVal name As String, _
                                           ByVal protection As MemoryProtection) As Integer

        Dim mapHandler As Integer = MemoryMappedFileHelper.OpenFileMapping ( _
                                                                            MemoryMappedFileHelper.GetWin32FileMapAccess ( _
                                                                                                                          protection), _
                                                                            False, _
                                                                            name)

        Return mapHandler

    End Function

#End Region

#End Region

#Region "Custom properties"

    ' <summary>
    '		Gets the maximum length of the file.
    ' </summary>

    Public ReadOnly Property MaxLength() As Long

        Get
            Return mapLength
        End Get
    End Property

#End Region

#Region "IDisposable implementation"


    ' <summary>
    '		Dispose the instance of the memory mapped
    '		file.
    ' </summary>

    Public Shadows Sub Dispose()

        Close()

    End Sub

#End Region
End Class
