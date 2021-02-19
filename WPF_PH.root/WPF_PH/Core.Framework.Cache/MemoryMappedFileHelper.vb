'===============================================================================
' Microsoft Caching Application Block for .NET
' http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dnpag/html/CachingBlock.asp
'
' MemoryMappedFileHelper.vb
' Memory mapped file helper class that provides the Win32 functions and the
' conversion methods
'
'===============================================================================
' Copyright (C) 2003 Microsoft Corporation
' All rights reserved.
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
' OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
' LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR
' FITNESS FOR A PARTICULAR PURPOSE.
'===============================================================================


Imports System.Runtime.InteropServices
Imports System.Text
Imports System.IO

#Region "Enumeration for Win32 macros"

<Flags()> _
Public Enum MemoryProtection As Long

    PageNoAccess = &H1
    PageReadOnly = &H2
    PageReadWrite = &H4
    PageWriteCopy = &H8
    SecImage = &H1000000
    SecReserve = &H4000000
    SecCommit = &H8000000
    SecNoCache = &H10000000
End Enum


<Flags()> _
Friend Enum Win32FileMapAccess As Integer

    FILE_MAP_COPY = &H1
    FILE_MAP_WRITE = &H2
    FILE_MAP_READ = &H4
    FILE_MAP_ALL_ACCESS = &HF0000 Or FILE_MAP_COPY Or FILE_MAP_WRITE Or _
                          FILE_MAP_READ Or &H8 Or &H10
End Enum


<Flags()> _
Friend Enum Win32FileAccess As Integer

    GENERIC_READ = &H80000000
    GENERIC_WRITE = &H40000000
    GENERIC_EXECUTE = &H20000000
    GENERIC_ALL = &H10000000
End Enum


<Flags()> _
Friend Enum Win32FileMode As Integer

    CREATE_NEW = 1
    CREATE_ALWAYS = 2
    OPEN_EXISTING = 3
    OPEN_ALWAYS = 4
    TRUNCATE_EXISTING = 5
End Enum


<Flags()> _
Friend Enum Win32FileShare As Integer

    FILE_SHARE_READ = &H1
    FILE_SHARE_WRITE = &H2
    FILE_SHARE_DELETE = &H4
End Enum


<Flags()> _
Friend Enum Win32FileAttributes As Integer

    FILE_ATTRIBUTE_READONLY = &H1
    FILE_ATTRIBUTE_HIDDEN = &H2
    FILE_ATTRIBUTE_SYSTEM = &H4
    FILE_ATTRIBUTE_DIRECTORY = &H10
    FILE_ATTRIBUTE_ARCHIVE = &H20
    FILE_ATTRIBUTE_DEVICE = &H40
    FILE_ATTRIBUTE_NORMAL = &H80
    FILE_ATTRIBUTE_TEMPORARY = &H100
    FILE_ATTRIBUTE_SPARSE_FILE = &H200
    FILE_ATTRIBUTE_REPARSE_POINT = &H400
    FILE_ATTRIBUTE_COMPRESSED = &H800
    FILE_ATTRIBUTE_OFFLINE = &H1000
    FILE_ATTRIBUTE_NOT_CONTENT_INDEXED = &H2000
    FILE_ATTRIBUTE_ENCRYPTED = &H4000
End Enum

#End Region

#Region "Win32 functions and conversion methods"

' <summary>
'		Memory mapped file helper class that provides
'		the Win32 functions and the conversion methods.
' </summary>


Friend Class MemoryMappedFileHelper
    Private Const FORMAT_MESSAGE_FROM_SYSTEM As Long = &H1000

    Public Structure SECURITY_ATTRIBUTES
        Public nLength As Integer
        Public lpSecurityDescriptor As Integer
        Public bInheritHandle As Integer
    End Structure

    ' <summary>
    '       hFile - handle to file
    '       lpAttributes - security
    '       flProtect - protection
    '       dwMaximumSizeHigh - high-order DWORD of size
    '       dwMaximumSizeLow -  low-order DWORD of size
    '       lpName - object name
    '</summary>

    Declare Ansi Function CreateFileMapping _
        Lib "kernel32" Alias "CreateFileMappingA" _
        (ByVal hFile As Integer, _
         ByRef lpFileMappigAttributes As SECURITY_ATTRIBUTES, _
         ByVal flProtect As Integer, _
         ByVal dwMaximumSizeHigh As Integer, _
         ByVal dwMaximumSizeLow As Integer, _
         ByVal lpName As String) As Integer

    ' <summary>
    '       lpFileName - file name
    '       dwDesiredAccess -  access mode
    '       dwShareMode - share mode
    '       lpSecurityAttributes - SD
    '       dwCreationDisposition - how to create
    '       dwFlagsAndAttributes - file attributes
    '       hTemplateFile - handle to template file
    ' </summary>

    <DllImport ("kernel32", CharSet := CharSet.Ansi, SetLastError := True)> _
    Public Shared Function CreateFile (ByVal lpFileName As String, _
                                       ByVal dwDesiredAccess As Win32FileAccess, _
                                       ByVal dwShareMode As Win32FileShare, _
                                       ByVal lpSecurityAttributes As IntPtr, _
                                       ByVal dwCreationDisposition As Win32FileMode, _
                                       ByVal dwFlagsAndAttributes As Win32FileAttributes, _
                                       ByVal hTemplateFile As IntPtr) As IntPtr
    End Function

    ' <summary>
    '       dwDesiredAccess - access mode
    '       bInheritHandle - inherit flag
    '       lpName - object name
    ' </summary>
    Declare Ansi Function OpenFileMapping Lib "kernel32" Alias "OpenFileMappingA" _
        (ByVal dwDesiredAccess As Integer, _
         ByVal bInheritHandle As Integer, _
         ByVal lpName As String) As Integer


    ' <summary>
    '       hFileMappingObject - handle to file-mapping object
    '       dwDesiredAccess - access mode
    '       dwFileOffsetHigh - high-order DWORD of offset
    '       dwFileOffsetLow - low-order DWORD of offset
    '       dwNumberOfBytesToMap - number of bytes to map
    ' </summary>

    Declare Auto Function MapViewOfFile Lib "kernel32" Alias "MapViewOfFile" _
        (ByVal hFileMappingObject As Integer, _
         ByVal dwDesiredAccess As Integer, _
         ByVal dwFileOffsetHigh As Integer, _
         ByVal dwFileOffsetLow As Integer, _
         ByVal dwNumberOfBytesToMap As Integer) As IntPtr


    ' <summary>
    '       lpBaseAddress - starting address
    '       dwNumberOfBytesToFlush - number of bytes in range
    ' </summary>

    <DllImport ("kernel32")> _
    Public Shared Function FlushViewOfFile (ByVal lpBaseAddress As IntPtr, _
                                            ByVal dwNumberOfBytesToFlush As Long) As Boolean
    End Function

    ' <summary>
    '       lpBaseAddress - starting address
    ' </summary>

    <DllImport ("kernel32")> _
    Public Shared Function UnmapViewOfFile (ByVal lpBaseAddress As IntPtr) _
        As Boolean
    End Function


    <DllImport ("kernel32")> _
    Public Shared Function GetLastError() As Long
    End Function

    ' <summary>
    '       hFile - handle to file
    ' </summary>

    <DllImport ("kernel32", SetLastError := True)> _
    Public Shared Function CloseHandle (ByVal hFile As IntPtr) As Boolean
    End Function

    ' <summary>
    '       dwFlags - source and processing options
    '       lpSource - message source
    '       dwMessageId - message identifier
    '       dwLanguageId - language identifier
    '       lpBuffer - message buffer
    '       nSize - maximum size of message buffer
    '       Arguments - array of message inserts
    ' </summary>

    <DllImport ("kernel32")> _
    Public Shared Function FormatMessage (ByVal dwFlags As Long, _
                                          ByVal lpSource As IntPtr, ByVal dwMessageId As Long, _
                                          ByVal dwLanguageId As Long, ByVal lpBuffer As StringBuilder, _
                                          ByVal nSize As Long, ByVal Arguments As IntPtr) As Long
    End Function

    Private Sub New()
    End Sub

    Public Shared Function GetWin32FileMapAccess ( _
                                                  ByVal protection As MemoryProtection) As Win32FileMapAccess

        Select Case protection
            Case MemoryProtection.PageReadOnly
                Return Win32FileMapAccess.FILE_MAP_READ
            Case MemoryProtection.PageWriteCopy
                Return Win32FileMapAccess.FILE_MAP_WRITE
            Case Else
                Return Win32FileMapAccess.FILE_MAP_ALL_ACCESS
        End Select

    End Function


    Public Shared Function GetWin32FileAccess (ByVal access As FileAccess) _
        As Win32FileAccess

        Select Case access
            Case FileAccess.Read
                Return Win32FileAccess.GENERIC_READ
            Case FileAccess.Write
                Return Win32FileAccess.GENERIC_WRITE
            Case FileAccess.ReadWrite
                Return Win32FileAccess.GENERIC_READ Or _
                       Win32FileAccess.GENERIC_WRITE
            Case Else
                Return Win32FileAccess.GENERIC_READ
        End Select

    End Function


    Public Shared Function GetWin32FileMode (ByVal mode As FileMode) _
        As Win32FileMode

        Select Case mode
            Case FileMode.Append
                Return Win32FileMode.OPEN_ALWAYS
            Case FileMode.Create
                Return Win32FileMode.CREATE_ALWAYS
            Case FileMode.CreateNew
                Return Win32FileMode.CREATE_NEW
            Case FileMode.Open
                Return Win32FileMode.OPEN_EXISTING
            Case FileMode.OpenOrCreate
                Return Win32FileMode.OPEN_ALWAYS
            Case FileMode.Truncate
                Return Win32FileMode.TRUNCATE_EXISTING
            Case Else
                Return Win32FileMode.OPEN_ALWAYS
        End Select

    End Function


    Public Shared Function GetWin32FileShare (ByVal share As FileShare) _
        As Win32FileShare

        Select Case share
            Case FileShare.None
                Return 0
            Case FileShare.Write
                Return Win32FileShare.FILE_SHARE_WRITE
            Case FileShare.Read
                Return Win32FileShare.FILE_SHARE_READ
            Case FileShare.ReadWrite
                Return Win32FileShare.FILE_SHARE_READ Or _
                       Win32FileShare.FILE_SHARE_WRITE
            Case Else
                Return 0
        End Select

    End Function


    Public Shared Function GetWin32ErrorMessage (ByVal errorNumber As Long) _
        As String

        Dim buff As New StringBuilder (1024)
        Dim len As Long = FormatMessage (FORMAT_MESSAGE_FROM_SYSTEM, _
                                         IntPtr.Zero, errorNumber, 0, buff, 1024, IntPtr.Zero)
        Return buff.ToString (0, CInt (len))

    End Function
End Class

#End Region

