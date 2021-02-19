'===============================================================================
' Microsoft Caching Application Block for .NET
' http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dnpag/html/CachingBlock.asp
'
' DefaultDataProtection.vb
' Sample data protection provider.  This provider uses DPAPI to encrypt items
' and SHA algorithm to validate them.
'
'===============================================================================
' Copyright (C) 2003 Microsoft Corporation
' All rights reserved.
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
' OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
' LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR
' FITNESS FOR A PARTICULAR PURPOSE.
'===============================================================================
Imports System.Security.Cryptography
Imports System.Xml
Imports Core.ExceptionManagement

' Used for Handling Exceptions

' Used for all the caching operations

Namespace DataProtection

#Region "DataProtection provider"

    ' <summary>
    '		Sample data protection provider.
    '		This provider uses DPAPI to encrypt items
    '		and SHA algorithm to validate them.
    ' </summary>
    ' <remarks>
    '		This provider uses the following attributes on the XML file:
    ' <list type="">
    '		<item>
    '		<b>Assembly</b> 
    '   	Used to specify the provider assembly (Required)
    '		</item>
    '		<item>
    '		<b>ClassName</b> 
    '		Used to specify the provider class name (Required)
    '	    </item>
    '		<item>
    '		<b>ValidationKey</b> 
    '		Used to specify validation key (Optional). 
    '		If this attribute isnt specified, then the
    '		provider uses a random key.
    '		</item>
    '		<item>
    '		<b>Validation</b> 
    '		Used to specify the typeof encryption used for
    '		data validation (Optional). 
    '   	If this attribute isnt specified, then the provider
    '		uses a SHA1 algorithm.
    '		</item>
    ' </list>
    ' </remarks>

    Public Class DefaultDataProtection
        Implements IDataProtection

#Region "Private members"

        Private win32DataProtectionAPI As Win32DPAPI
        Private validationAlgorithm As KeyedHashAlgorithm

#End Region

#Region "Public constructor"

        Public Sub New()
        End Sub

#End Region

#Region "Implementation of IDataProtection"

#Region "Init"

        ' <summary>
        '		Initializes the data protection provider.
        ' </summary>
        ' <remarks>
        '		IDataProtection.Init( configSection )
        ' </remarks>
        ' <param name="configSection">
        '		Represents the "DataProtectionInfo" node
        '		in the app.config file
        ' </param>
        Sub Init (ByVal configSection As XmlNode) Implements _
                                                      IDataProtection.Init

            Try
                ' Variable Declarations
                Dim validationKey As String = ""
                Dim validation As String = ""

                If Not Equals (configSection, Nothing) AndAlso Not _
                                                               Equals (configSection.Attributes (CacheResources. _
                                                                                                    ResourceManager ( _
                                                                                                                     "RES_ValidationKey")), _
                                                                       Nothing) Then
                    validationKey = configSection.Attributes (CacheResources. _
                                                                 ResourceManager ("RES_ValidationKey")).Value
                End If

                If Not Equals (configSection, Nothing) AndAlso Not _
                                                               Equals (configSection.Attributes (CacheResources. _
                                                                                                    ResourceManager ( _
                                                                                                                     "RES_Validation")), _
                                                                       Nothing) Then
                    validation = configSection.Attributes (CacheResources. _
                                                              ResourceManager ("RES_Validation")).Value
                End If

                If Not Equals (validation, Nothing) Then
                    validationAlgorithm = CreateAlgorithmFromName (validation)
                    If Equals (validationAlgorithm, Nothing) Then
                        Throw New Exception (CacheResources. _
                                                ResourceManager ( _
                                                                 "RES_ExceptionInvalidConfigurationDefaultDataProtectionValidation"))
                    End If
                Else
                    validationAlgorithm = New HMACSHA1()
                End If

                If Not Equals (validationKey, Nothing) Then
                    ' Throw exception if the validation key length is zero
                    If (validationKey.Trim().Length = 0) Then
                        Throw New Exception (CacheResources. _
                                                ResourceManager ( _
                                                                 "RES_InvalidBaseString"))
                    End If
                    validationAlgorithm.Key = Convert.FromBase64String ( _
                                                                        validationKey)
                End If

                win32DataProtectionAPI = New Win32DPAPI()

            Catch genException As Exception
                ExceptionManager.Publish (genException)
                Throw
            End Try

        End Sub

#End Region

#Region "Encrypt"

        ' <summary>
        '		Encrypts a raw of bytes.
        ' </summary>
        ' <remarks>
        '		cipherText = IDataProtection.Encrypt( plainValue )
        ' </remarks>
        ' <param name="plainValue">
        '		The data to be encrypted
        ' </param>
        ' <returns>
        '		The encrypted data
        ' </returns>
        Function Encrypt (ByVal plainValue() As Byte) As Byte() _
            Implements IDataProtection.Encrypt

            Try
                Dim encryptedData As Byte()
                If Equals (plainValue, Nothing) Then
                    Throw New ArgumentNullException ("plainValue", _
                                                     CacheResources.ResourceManager ( _
                                                                                     "RES_ExceptionNullPlainValue"))
                End If

                encryptedData = win32DataProtectionAPI.Encrypt (plainValue)
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
        '		plainText = IDataProtection.Decrypt( cipherValue )
        ' </remarks>
        ' <param name="cipherValue">
        '		The data to be decrypted
        ' </param>
        ' <returns>
        '		The decrypted data
        ' </returns>
        Function Decrypt (ByVal cipherValue() As Byte) As Byte() _
            Implements IDataProtection.Decrypt

            Try
                Dim decryptedData As Byte()
                If Equals (cipherValue, Nothing) Then
                    Throw New ArgumentNullException ("cipherValue", _
                                                     CacheResources.ResourceManager ( _
                                                                                     "RES_ExceptionNullCipherValue"))
                End If
                decryptedData = win32DataProtectionAPI.Decrypt (cipherValue)
                Return decryptedData
            Catch genException As Exception
                ExceptionManager.Publish (genException)
            End Try

            Return Nothing

        End Function

#End Region

#Region "ComputeHash"

        ' <summary>
        '		Computes a hash for data validation.
        ' </summary>
        ' <remarks>
        '		hashCode = IDataProtection.ComputeHash( plainText )
        ' </remarks>
        ' <param name="plainText">
        '		The raw bytes to be converted into hash code
        ' </param>
        ' <returns>
        '		The hash code generated using "HMACSHA1" or
        '		"MACtripleDES" algorithm
        ' </returns>
        Function ComputeHash (ByVal plainText() As Byte) As Byte() _
            Implements IDataProtection.ComputeHash

            Try
                Dim hashCode As Byte()
                If Equals (plainText, Nothing) Then
                    Throw New ArgumentNullException ("plainText", _
                                                     CacheResources.ResourceManager ( _
                                                                                     "RES_ExceptionNullPlainText"))
                End If
                hashCode = validationAlgorithm.ComputeHash (plainText)
                Return hashCode

            Catch genException As Exception
                ExceptionManager.Publish (genException)
                Throw
            End Try

        End Function

#End Region

#End Region

#Region "Private methods"

        ' <summary>
        '		Create the algorithm for validation of data.
        ' </summary>
        ' <remarks>
        '		algorithm = CreateAlgorithmFromName( name )
        ' </remarks>
        ' <param name="name">
        '		The validation algorithm name read from the
        '		"DataProtectionInfo" of the app.config file		
        ' </param>
        ' <returns>
        '		The hash algorithm name i.e. either "HMACSHA1"
        '		or "MACTripleDES"
        ' </returns>
        Private Function CreateAlgorithmFromName (ByVal name As String) _
            As KeyedHashAlgorithm

            Try
                If Equals (name, Nothing) Then
                    Throw New ArgumentNullException ("name", CacheResources. _
                                                        ResourceManager ("RES_ExceptionNullName"))
                End If

                If name.Length = 0 Then
                    Throw New ArgumentOutOfRangeException ("name", _
                                                           CacheResources.ResourceManager ( _
                                                                                           "RES_ExceptionEmptyName"))
                End If

                Select Case name
                    Case "SHA1"
                        Return New HMACSHA1()
                    Case "3DES"
                        Return New MACTripleDES()
                    Case Else
                        Return Nothing
                End Select

            Catch genException As Exception
                ExceptionManager.Publish (genException)
                Throw
            End Try

        End Function

#End Region
    End Class

#End Region
End Namespace


