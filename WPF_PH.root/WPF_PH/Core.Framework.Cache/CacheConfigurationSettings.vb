'===============================================================================
' Microsoft Caching Application Block for .NET
' http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dnpag/html/CachingBlock.asp
'
' CacheConfigurationSettings.vb
' Class that defines the settings within the cache configuration settings in
' the config file.
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
Imports Core.ExceptionManagement

' Used for handling Exceptions

#Region "CacheConfigurationSettings"

' <summary>
'		This class defines  the settings within the cache
'		configuration settings in the config file.
' </summary>

Friend Class CacheConfigurationSettings

#Region "Member Variables"

    Private configStorageSettings As StorageInfo
    Private configScavengingSettings As ScavengingInfo
    Private configExpirationSettings As ExpirationInfo
    Private configDataProtectionSettings As DataProtectionInfo

#End Region

#Region "Constructor"

    ' <summary>
    '		Constructor to define the cache configuration
    '		settings.	
    ' </summary>

    Friend Sub New (ByVal storageInfo As XmlNode, _
                    ByVal scavengingInfo As XmlNode, ByVal expirationInfo As XmlNode, _
                    ByVal dataProtectionInfo As XmlNode)

        Try
            If Not Equals (storageInfo, Nothing) Then
                configStorageSettings = New storageInfo (storageInfo)
            End If

            If Not Equals (scavengingInfo, Nothing) Then
                configScavengingSettings = New scavengingInfo (scavengingInfo)
            End If

            If Not Equals (expirationInfo, Nothing) Then
                configExpirationSettings = New expirationInfo (expirationInfo)
            End If

            If Not Equals (dataProtectionInfo, Nothing) Then
                configDataProtectionSettings = New dataProtectionInfo ( _
                                                                       dataProtectionInfo)
            End If

        Catch genException As Exception
            ExceptionManager.Publish (genException)
            Throw
        End Try

    End Sub

#End Region

#Region "Properties"

    ' <summary>
    '		Gets the storage provider settings.
    ' </summary>

    Friend ReadOnly Property StorageInformation() As StorageInfo

        Get
            Return configStorageSettings
        End Get
    End Property

    ' <summary>
    '		Gets the scavenging algorithm settings.
    ' </summary>

    Friend ReadOnly Property ScavengingInformation() As ScavengingInfo

        Get
            Return configScavengingSettings
        End Get
    End Property

    ' <summary>
    '   	Gets the expiration settings.
    ' </summary>

    Friend ReadOnly Property ExpirationInformation() As ExpirationInfo

        Get
            Return configExpirationSettings
        End Get
    End Property

    ' <summary>
    '		Gets the data protection settings.
    ' </summary>

    Friend ReadOnly Property DataProtectionInformation() As _
        DataProtectionInfo

        Get
            Return configDataProtectionSettings
        End Get
    End Property

#End Region
End Class

#End Region
