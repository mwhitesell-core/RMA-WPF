'===============================================================================
' Microsoft Caching Application Block for .NET
' http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dnpag/html/CachingBlock.asp
'
' Win32DPAPI.vb
' The DPAPI wrapper class.
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
Imports Core.ExceptionManagement

' Used for Handling Exceptions

' Used for all the caching operations

Namespace DataProtection

#Region "Enum Declarations"

    ' <summary>
    '		Specifies which key will be used to encrypt an item.
    ' </summary>
    Friend Enum DPAPIStore

        Machine = 1
        User
    End Enum

#End Region

#Region "DPAPI Wrapper class"

    ' <summary>
    '		The DPAPI wrapper.
    ' </summary>
    Friend Class Win32DPAPI

#Region "Private Members"

        Private dataProtectionStore As DPAPIStore = DPAPIStore.Machine

#End Region

#Region "Constants"

        Private Const CRYPTPROTECT_UI_FORBIDDEN As Integer = &H1
        Private Const CRYPTPROTECT_LOCAL_MACHINE As Integer = &H4

#End Region

#Region "P/Invoke structures"

        <StructLayout (LayoutKind.Sequential, CharSet := CharSet.Unicode)> _
        Friend Structure DATA_BLOB
            Public cipherBlobData As Integer
            Public plainBlobData As IntPtr
        End Structure

        <StructLayout (LayoutKind.Sequential, CharSet := CharSet.Unicode)> _
        Friend Structure CRYPTPROTECT_PROMPTSTRUCT
            Public cipherBlobSize As Integer
            Public dwPromptFlags As Integer
            Public hwndApp As IntPtr
            Public szPrompt As String
        End Structure

#End Region

#Region "External methods"

        <DllImport ("Crypt32.dll", SetLastError := True, CharSet := CharSet.Auto)> _
        Private Shared Function CryptProtectData (ByRef pDataIn As DATA_BLOB, _
                                                  ByVal szDataDescr As String, ByRef pOptionalEntropy As DATA_BLOB, _
                                                  ByVal pvReserved As IntPtr, ByRef pPromptStruct As _
                                                     CRYPTPROTECT_PROMPTSTRUCT, ByVal dwFlag As Integer, _
                                                  ByRef pDataOut As DATA_BLOB) As Boolean
        End Function

        <DllImport ("Crypt32.dll", SetLastError := True, CharSet := CharSet.Auto)> _
        Private Shared Function CryptUnprotectData (ByRef pDataIn As DATA_BLOB, _
                                                    ByVal szDataDescr As String, ByRef pOptionalEntropy As DATA_BLOB, _
                                                    ByVal pvReserved As IntPtr, ByRef pPromptStruct As _
                                                       CRYPTPROTECT_PROMPTSTRUCT, ByVal dwFlag As Integer, _
                                                    ByRef pDataOut As DATA_BLOB) As Boolean
        End Function


        Private Declare Function FormatMessage Lib "kernel32.dll" ( _
                                                                   ByVal dwFlag As Integer, ByRef lpSource As IntPtr, _
                                                                   ByVal dwMessageId As Integer, _
                                                                   ByVal dwLanguageId As Integer, _
                                                                   ByRef lpBuffer As String, ByVal nSize As Integer, _
                                                                   ByVal Arguments As IntPtr) As Integer

#End Region

#Region "Constructor"

        ' <summary>
        '		Create a new instance of the class.
        ' </summary>
        Public Sub New()
        End Sub

        ' <summary>
        '		Create an instance of the class with store
        '		as input 
        ' </summary>
        ' <param name="store">
        '		The DPAPIStore enumerator
        ' </param>
        Public Sub New (ByVal store As DPAPIStore)

            dataProtectionStore = store

        End Sub

#End Region

#Region "Public methods"

#Region "Encrypt"

        ' <summary>
        '		Encrypts a raw of bytes.
        ' </summary>
        ' <remarks>
        '		cipherText = Encrypt( plainText )
        ' </remarks>
        ' <param name="plainText">
        '		The data to be encrypted
        ' </param>
        ' <returns>
        '		The encrypted data
        ' </returns>
        Public Overloads Function Encrypt (ByVal plainText() As Byte) As Byte()

            Try
                Dim encryptedData As Byte()
                If Equals (plainText, Nothing) Then
                    Throw New ArgumentNullException ("plainText", _
                                                     CacheResources.ResourceManager ( _
                                                                                     "RES_ExceptionNullPlainText"))
                End If

                encryptedData = Encrypt (plainText, Nothing)
                Return encryptedData

            Catch genException As Exception
                ExceptionManager.Publish (genException)
                Throw
            End Try

        End Function

        ' <summary>
        '		Encrypts a raw of bytes.
        ' </summary>
        ' <remarks>
        '		cipherText = Encrypt( plainText, optionalEntropy )
        ' </remarks>
        ' <param name="plainText">
        '		The data to be encrypted
        ' </param>
        ' <param name="optionalEntropy">
        '		Password or other additional entropy used when the data
        '		was encrypted.  If an optional entropy was used in the
        '		encryption phase, then same entropy	must be used for the
        '		decryption phase.
        ' </param>
        ' <returns>
        '		The encrypted data
        ' </returns>
        Public Overloads Function Encrypt (ByVal plainText() As Byte, _
                                           ByVal optionalEntropy() As Byte) As Byte()

            Dim plainTextBlob As DATA_BLOB
            Dim cipherTextBlob As DATA_BLOB
            Dim entropyBlob As DATA_BLOB

            Try
                Dim isValue As Boolean
                Dim bytesSize As Integer
                Dim prompt As New CRYPTPROTECT_PROMPTSTRUCT()
                InitPromptstruct (prompt)
                Dim dwFlag As Integer
                Dim cipherText As Byte()

                If Equals (plainText, Nothing) Then
                    Throw New ArgumentNullException ("plainText", _
                                                     CacheResources.ResourceManager ( _
                                                                                     "RES_ExceptionNullPlainText"))
                End If

                Try
                    bytesSize = plainText.Length
                    plainTextBlob.plainBlobData = Marshal.AllocHGlobal ( _
                                                                        bytesSize)

                    If Equals (IntPtr.Zero, _
                               plainTextBlob.plainBlobData) Then
                        Throw New Exception (CacheResources.ResourceManager ( _
                                                                             "RES_FailedToAllocatePlainTextBuffer"))
                    End If

                    plainTextBlob.cipherBlobData = bytesSize

                    ' Copy to unmanaged area 
                    Marshal.Copy (plainText, 0, plainTextBlob.plainBlobData, _
                                  bytesSize)

                Catch encryptException As Exception
                    Throw New Exception (CacheResources.ResourceManager ( _
                                                                         "RES_ExceptionMarshallingData"), _
                                         encryptException)
                End Try

                If Not Equals (DPAPIStore.Machine, _
                               dataProtectionStore) Then

                    ' Using the machine store, should be providing entropy
                    dwFlag = CRYPTPROTECT_LOCAL_MACHINE Or _
                             CRYPTPROTECT_UI_FORBIDDEN

                    ' Check to see if the entropy is null
                    If Equals (optionalEntropy, Nothing) Then
                        ' Allocate something
                        optionalEntropy = New Byte(- 1) {}
                    End If

                    Try
                        bytesSize = optionalEntropy.Length
                        entropyBlob.plainBlobData = Marshal.AllocHGlobal ( _
                                                                          optionalEntropy.Length)

                        If Not Equals (IntPtr.Zero, _
                                       entropyBlob.plainBlobData) Then
                            Throw New Exception (CacheResources. _
                                                    ResourceManager ( _
                                                                     "RES_FailedToAllocateEntropyDataBuffer"))
                        End If

                        ' Copy to unmanaged area
                        Marshal.Copy (optionalEntropy, 0, _
                                      entropyBlob.plainBlobData, _
                                      bytesSize)
                        entropyBlob.cipherBlobData = bytesSize

                    Catch encryptException As Exception
                        Throw New Exception (CacheResources.ResourceManager ( _
                                                                             "RES_ExceptionEntropyMarshallingData"), _
                                             encryptException)
                    End Try
                Else

                    ' Using the user store
                    dwFlag = CRYPTPROTECT_UI_FORBIDDEN
                End If
                isValue = CryptProtectData (plainTextBlob, "", entropyBlob, _
                                            IntPtr.Zero, prompt, dwFlag, cipherTextBlob)

                If Equals (isValue, False) Then
                    Throw New Exception (CacheResources.ResourceManager ( _
                                                                         "RES_EncryptionFailed") + _
                                         GetErrorMessage (Marshal. _
                                                             GetLastWin32Error()))
                End If

                cipherText = New Byte(cipherTextBlob.cipherBlobData) {}

                ' Copy back to managed area
                Marshal.Copy (cipherTextBlob.plainBlobData, cipherText, 0, _
                              cipherTextBlob.cipherBlobData)
                Return cipherText

            Catch encryptException As Exception
                Throw New Exception (CacheResources.ResourceManager ( _
                                                                     "RES_EncryptionFailed") + encryptException.Message)
            Finally
                If Not Equals (IntPtr.Zero, _
                               cipherTextBlob.plainBlobData) Then
                    Marshal.FreeHGlobal (cipherTextBlob.plainBlobData)
                End If

                If Not Equals (IntPtr.Zero, _
                               entropyBlob.plainBlobData) Then
                    Marshal.FreeHGlobal (entropyBlob.plainBlobData)
                End If
                If Not Equals (IntPtr.Zero, _
                               plainTextBlob.plainBlobData) Then
                    Marshal.FreeHGlobal (plainTextBlob.plainBlobData)
                End If
            End Try

        End Function

#End Region

#Region "Decrypt"

        ' <summary>
        '		Decrypts a raw of bytes.
        ' </summary>
        ' <remarks>
        '		plainText = Decrypt( cipherText )
        ' </remarks>
        ' <param name="cipherText">
        '		The data to be decrypted
        ' </param>
        ' <returns>
        '		The decrypted data
        ' </returns>
        Public Overloads Function Decrypt (ByVal cipherText() As Byte) _
            As Byte()

            Try
                Dim decryptedData As Byte()
                If Equals (cipherText, Nothing) Then
                    Throw New ArgumentNullException ("cipherText", _
                                                     CacheResources.ResourceManager ( _
                                                                                     "RES_ExceptionNullCipherText"))
                End If

                decryptedData = Decrypt (cipherText, Nothing)
                Return decryptedData
            Catch genException As Exception
                ExceptionManager.Publish (genException)
                Throw
            End Try

        End Function

        ' <summary>
        '		Decrypts a raw of bytes.
        ' </summary>
        ' <remarks>
        '		plainText = Decrypt(cipherText, optionalEntropy)
        ' </remarks>
        ' <param name="cipherText">
        '		The data to be decrypted
        ' </param>
        ' <param name="optionalEntropy">
        '		Password or other additional entropy used when the data
        '		was encrypted.  if an optional entropy was used in the
        '		encryption phase, that same entropy	must be used for the
        '		decryption phase.
        ' </param>
        ' <returns>
        '		The decrypted data
        ' </returns>
        Public Overloads Function Decrypt (ByVal cipherText() As Byte, _
                                           ByVal optionalEntropy() As Byte) As Byte()

            Dim plainTextBlob As DATA_BLOB
            Dim cipherBlob As DATA_BLOB
            Dim entropyBlob As DATA_BLOB
            Try
                Dim isValue As Boolean
                Dim prompt As New CRYPTPROTECT_PROMPTSTRUCT()
                InitPromptstruct (prompt)
                Dim cipherTextSize As Integer
                Dim dwFlag As Integer
                Dim bytesSize As Integer
                Dim plainText As Byte()

                If Equals (cipherText, Nothing) Then
                    Throw New ArgumentNullException ("cipherText", _
                                                     CacheResources.ResourceManager ( _
                                                                                     "RES_ExceptionNullCipherText"))
                End If

                Try
                    cipherTextSize = cipherText.Length
                    cipherBlob.plainBlobData = Marshal.AllocHGlobal ( _
                                                                     cipherTextSize)

                    If Equals (IntPtr.Zero, _
                               cipherBlob.plainBlobData) Then
                        Throw New Exception (CacheResources.ResourceManager ( _
                                                                             "RES_FailedToAllocateCipherTextBuffer"))
                    End If

                    cipherBlob.cipherBlobData = cipherTextSize

                    ' Copy to unmanaged area
                    Marshal.Copy (cipherText, 0, cipherBlob.plainBlobData, _
                                  cipherBlob.cipherBlobData)
                Catch decryptException As Exception
                    Throw New Exception (CacheResources.ResourceManager ( _
                                                                         "RES_ExceptionMarshallingData"), _
                                         decryptException)
                End Try

                If Equals (DPAPIStore.Machine, _
                           dataProtectionStore) Then

                    ' Using the machine store, should be providing entropy
                    dwFlag = CRYPTPROTECT_LOCAL_MACHINE Or _
                             CRYPTPROTECT_UI_FORBIDDEN

                    ' Check to see if the entropy is null
                    If optionalEntropy Is Nothing Then

                        ' Allocate something
                        optionalEntropy = New Byte(- 1) {}
                    End If

                    Try
                        bytesSize = optionalEntropy.Length
                        entropyBlob.plainBlobData = Marshal.AllocHGlobal ( _
                                                                          bytesSize)
                        If Equals (IntPtr.Zero, _
                                   entropyBlob.plainBlobData) Then
                            Throw New Exception (CacheResources. _
                                                    ResourceManager ( _
                                                                     "RES_FailedToAllocateEntropyDataBuffer"))
                        End If
                        entropyBlob.cipherBlobData = bytesSize

                        ' Copy to unmanaged area
                        Marshal.Copy (optionalEntropy, 0, _
                                      entropyBlob.plainBlobData, bytesSize)
                    Catch decryptException As Exception
                        Throw New Exception (CacheResources.ResourceManager ( _
                                                                             "RES_ExceptionEntropyMarshallingData"), _
                                             decryptException)
                    End Try

                Else
                    ' Using the user store
                    dwFlag = CRYPTPROTECT_UI_FORBIDDEN
                End If

                isValue = CryptUnprotectData (cipherBlob, Nothing, _
                                              entropyBlob, IntPtr.Zero, prompt, dwFlag, plainTextBlob)

                If Equals (isValue, False) Then
                    Throw New Exception (CacheResources.ResourceManager ( _
                                                                         "RES_DecryptionFailed") + _
                                         GetErrorMessage (Marshal. _
                                                             GetLastWin32Error()))
                End If

                plainText = New Byte(plainTextBlob.cipherBlobData) {}

                ' Copy to managed area
                Marshal.Copy (plainTextBlob.plainBlobData, plainText, 0, _
                              plainTextBlob.cipherBlobData)
                Return plainText

            Catch decryptException As Exception
                Throw New Exception (CacheResources.ResourceManager ( _
                                                                     "RES_DecryptionFailed") + decryptException.Message)
            Finally
                If Not Equals (IntPtr.Zero, _
                               cipherBlob.plainBlobData) Then
                    Marshal.FreeHGlobal (cipherBlob.plainBlobData)
                End If

                If Not Equals (IntPtr.Zero, _
                               entropyBlob.plainBlobData) Then
                    Marshal.FreeHGlobal (entropyBlob.plainBlobData)
                End If

                If Not Equals (IntPtr.Zero, _
                               plainTextBlob.plainBlobData) Then
                    Marshal.FreeHGlobal (plainTextBlob.plainBlobData)
                End If
            End Try

        End Function

#End Region

#End Region

#Region "Private methods"

#Region "InitPromptstruct"

        ' <summary>
        '		Initialize the value for the Promptstruct.
        ' </summary>
        ' <remarks>
        '		InitPromptstruct( ref promptStruct )
        ' </remarks>
        ' <param name="promptStruct">
        '		Reference of the Promptstruct
        ' </param>
        Private Sub InitPromptstruct (ByRef promptStruct As _
                                         CRYPTPROTECT_PROMPTSTRUCT)
            Try
                promptStruct.cipherBlobSize = Marshal.SizeOf (GetType ( _
                                                                 CRYPTPROTECT_PROMPTSTRUCT))
                promptStruct.dwPromptFlags = 0
                promptStruct.hwndApp = IntPtr.Zero
                promptStruct.szPrompt = Nothing
            Catch genException As Exception
                ExceptionManager.Publish (genException)
                Throw
            End Try

        End Sub

#End Region

#Region "GetErrorMessage"

        ' <summary>
        '		Gets the error message.
        ' </summary>
        ' <remarks>
        '		lpMsgBuf = GetErrorMessage( errorCode )
        ' </remarks>
        ' <param name="errorCode">
        '		The error code for which the message has to be retrieved
        ' </param>
        ' <returns>
        '		The error message
        ' </returns>
        Private Shared Function GetErrorMessage (ByVal errorCode As Integer) _
            As String

            Try

                Dim FORMAT_MESSAGE_ALLOCATE_BUFFER As Integer = &H100
                Dim FORMAT_MESSAGE_IGNORE_INSERTS As Integer = &H200
                Dim FORMAT_MESSAGE_FROM_SYSTEM As Integer = &H1000
                Dim messageSize As Integer = 255
                Dim lpMsgBuf As String = ""
                Dim dwFlag As Integer = FORMAT_MESSAGE_ALLOCATE_BUFFER Or _
                                        FORMAT_MESSAGE_FROM_SYSTEM Or _
                                        FORMAT_MESSAGE_IGNORE_INSERTS
                Dim ptrlpSource As New IntPtr()
                Dim prtArguments As New IntPtr()

                Dim isValue As Integer = FormatMessage (dwFlag, ptrlpSource, _
                                                        errorCode, 0, lpMsgBuf, messageSize, prtArguments)

                If Not Equals (isValue, 0) Then
                    Throw New Exception (CacheResources.ResourceManager ( _
                                                                         "RES_FailedToFormatMessage") + errorCode)
                End If
                Return lpMsgBuf

            Catch genException As Exception
                ExceptionManager.Publish (genException)
                Throw
            End Try

        End Function

#End Region

#End Region
    End Class

#End Region
End Namespace
