'===============================================================================
' Microsoft Caching Application Block for .NET
' http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dnpag/html/CachingBlock.asp
'
' DataProtectionManager.vb
' This class simplifies the use of the cryptographic functions.
'
'===============================================================================
' Copyright (C) 2003 Microsoft Corporation
' All rights reserved.
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
' OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
' LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR
' FITNESS FOR A PARTICULAR PURPOSE.
'===============================================================================
Imports System.Runtime.Serialization.Formatters.Binary
Imports Core.Framework.Cache.DataProtection
Imports Core.ExceptionManagement
Imports System.IO

' Used for handling Exceptions

#Region "DataProtection class"

' <summary>
'		This class simplifies the use of the cryptographic functions.
' </summary>

Friend NotInheritable Class DataProtectionManager
    ' Private Members
    Private Shared dataProtection As IDataProtection

#Region "MACValue struct"

    ' <summary>
    '		To store the value before and after using the MACTriples algorithm.
    ' </summary>

    <Serializable()> _
    Private Structure MACValue
        Public Value() As Byte
        Public MAC() As Byte
    End Structure

#End Region

#Region "Constructor"

    ' <summary>
    '		Constructor to read the data protection 
    '		information from the config file.
    ' </summary>

    Shared Sub New()

        Try
            ' Read storage mode from config file
            If Not (CacheConfiguration.Config.DataProtectionInformation _
                    Is Nothing) Then

                ' Initialize the Data Protection provider
                dataProtection = CacheConfiguration.Config. _
                    DataProtectionInformation.CreateInstance()
            Else
                ' Initialize the default DataProtection provider
                dataProtection = New DefaultDataProtection()
                dataProtection.Init (Nothing)
            End If
        Catch genException As Exception
            ExceptionManager.Publish (genException)
            Throw
        End Try

    End Sub

    ' <summary>
    '       Prevents creation of the instance of this class.
    ' </summary>
    Private Sub New()
    End Sub

#End Region

#Region "Public Methods"

#Region "Encrypt"

    ' <summary>
    '		Encrypts a raw of bytes.
    ' </summary>
    ' <remarks>
    '		encryptedData = Encrypt( plainValue )
    ' </remarks>
    ' <param name="plainValue">
    '		The data to be encrypted
    ' </param>
    ' <returns>
    '		The encrypted data
    ' </returns>
    Public Shared Function Encrypt (ByVal plainValue() As Byte) As Byte()

        Try
            Dim encryptedData As Byte()

            If Equals (plainValue, Nothing) Then
                Throw New ArgumentNullException ("plainValue", _
                                                 CacheResources.ResourceManager ( _
                                                                                 "RES_ExceptionNullPlainValue"))
            End If
            encryptedData = dataProtection.Encrypt (plainValue)
            Return encryptedData

        Catch genException As Exception
            ExceptionManager.Publish (genException)
            Throw
        End Try

    End Function

#End Region

#Region "Decrypt"

    ' <summary>
    '		Decrypts a raw of bytes.
    ' </summary>
    ' <remarks>
    '		decryptedData = Decrypt( cipherValue )
    ' </remarks>
    ' <param name="cipherValue">
    '		The data to be decrypted
    ' </param>
    ' <returns>
    '		The decrypted data
    ' </returns>
    Public Shared Function Decrypt (ByVal cipherValue() As Byte) As Byte()

        Try
            Dim decryptedData As Byte()
            If Equals (cipherValue, Nothing) Then
                Throw New ArgumentNullException ("cipherValue", _
                                                 CacheResources.ResourceManager ( _
                                                                                 "RES_ExceptionNullCipherValue"))
            End If
            decryptedData = dataProtection.Decrypt (cipherValue)
            Return decryptedData

        Catch genException As Exception
            ExceptionManager.Publish (genException)
            Throw
        End Try


    End Function

#End Region

#Region "AppendMAC"

    ' <summary>
    '		Appends a message authenticate code to plain value.
    '		Compute the MAC by hashing the value with the
    '		configured validation key.
    ' </summary>
    ' <remarks>
    '		codeMAC = AppendMAC( plainValue )
    ' </remarks>
    ' <param name="plainValue">
    '		The data to be converted to the MAC code
    ' </param>
    ' <returns>
    '		The MAC code is used to ensure data integrity
    ' </returns>

    Public Shared Function AppendMAC (ByVal plainValue() As Byte) As Byte()

        Try
            Dim hashCode As Byte()
            If Equals (plainValue, Nothing) Then
                Throw New ArgumentNullException ("plainValue", _
                                                 CacheResources.ResourceManager ( _
                                                                                 "RES_ExceptionNullPlainValue"))
            End If

            Dim macVal As New MACValue()
            macVal.Value = plainValue
            macVal.MAC = dataProtection.ComputeHash (plainValue)

            Dim memStream As New MemoryStream()
            Dim var As New BinaryFormatter()
            var.Serialize (memStream, macVal)
            hashCode = memStream.ToArray()
            memStream.Close()
            Return hashCode

        Catch genException As Exception
            ExceptionManager.Publish (genException)
            Throw
        End Try

    End Function

#End Region

#Region "RemoveMAC"

    ' <summary>
    '		Gets the plain value. This method takes the plain value
    '		and produces a hash. The resulting hash is compared with
    '		the existing hash and if they match the value is considered
    '		valid.
    ' </summary>
    ' <remarks>
    '		codeMAC = RemoveMAC( binaryMacValue )
    ' </remarks>
    ' <param name="binaryMacValue">
    '		The MAC code to be compared
    ' </param>
    ' <returns>
    '		The MAC code if the comparison of hashes is valid
    ' </returns>

    Public Shared Function RemoveMAC (ByVal binaryMacValue() As Byte) As Byte()

        Try
            Dim hashCode As Byte()
            If Equals (binaryMacValue, Nothing) Then
                Throw New ArgumentNullException ("binaryMacValue", _
                                                 CacheResources.ResourceManager ( _
                                                                                 "RES_ExceptionNullBinaryMACValue"))
            End If

            Dim memStream As New MemoryStream (binaryMacValue)
            Dim macVal As MACValue = CType (New BinaryFormatter(). _
                    Deserialize (memStream), MACValue)
            memStream.Close()

            Dim hash As Byte() = dataProtection.ComputeHash (macVal.Value)

            ' Compares the original hash with the new hash			
            Dim index As Integer
            For index = 0 To hash.Length - 1
                If hash (index) <> macVal.MAC (index) Then
                    Throw New Exception (CacheResources.ResourceManager ( _
                                                                         "RES_ExceptionDataValidation"))
                End If
            Next index
            hashCode = macVal.Value
            Return hashCode

        Catch genException As Exception
            ExceptionManager.Publish (genException)
            Throw
        End Try

    End Function

#End Region

#End Region
End Class

#End Region