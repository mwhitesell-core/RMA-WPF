'===============================================================================
' Microsoft Caching Application Block for .NET
' http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dnpag/html/CachingBlock.asp
'
' CacheConfigurationHandler.vb
' The Configuration Section Handler for the "CacheManagerSettings" section of
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
Imports System.Configuration
Imports System.Xml
Imports Core.ExceptionManagement

' Used for handling Exceptions

#Region "CacheConfigurationHandler"

' <summary>
'		The Configuration Section Handler for the "CacheManagerSettings"
'		section of the config file. 
' </summary>

Public Class CacheConfigurationHandler
    Implements IConfigurationSectionHandler

#Region "Public constructor"

    ' <summary>
    '		Create a new instance of the class.
    ' </summary>

    Public Sub New()
    End Sub

#End Region

#Region "IConfigurationSectionHandler implementation"

    ' <summary>
    '		Implemented by all configuration section handlers
    '		to parse the XML of the configuration section. 
    '		The returned object is added to the configuration
    '		collection and is accessed by GetConfig.
    ' </summary>
    ' <param name="parent">
    '		The configuration settings in a corresponding
    '		parent configuration section 
    ' </param>
    ' <param name="context">
    '		An HttpConfigurationContext when Create is called
    '		from the ASP.NET configuration system. Otherwise,
    '		this parameter is reserved and is a null reference.  
    ' </param>
    ' <param name="section">
    '		The XmlNode that contains the configuration 
    '		information from the configuration file. 
    '		Provides direct access to the XML contents
    '		of the configuration section.
    ' </param>
    ' <returns>
    '		The object of CacheConfigurationSettings
    ' </returns>
    Function Create (ByVal parent As Object, ByVal context As Object, _
                     ByVal section As XmlNode) As Object _
        Implements IConfigurationSectionHandler.Create

        Try
            If Equals (section, Nothing) Then
                Throw New ArgumentNullException ("section", CacheResources. _
                                                    ResourceManager ("RES_ExceptionNullSection"))
            End If

            ' Read all the information from the config file
            Dim storageInfo As XmlNode = section.SelectSingleNode ( _
                                                                   CacheResources.ResourceManager ("RES_StorageInfo"))
            Dim scavengingInfo As XmlNode = section.SelectSingleNode ( _
                                                                      CacheResources.ResourceManager ( _
                                                                                                      "RES_ScavengingInfo"))
            Dim expirationInfo As XmlNode = section.SelectSingleNode ( _
                                                                      CacheResources.ResourceManager ( _
                                                                                                      "RES_ExpirationInfo"))
            Dim dataProtectionInfo As XmlNode = section.SelectSingleNode ( _
                                                                          CacheResources.ResourceManager ( _
                                                                                                          "RES_DataProtectionInfo"))

            Dim config As New CacheConfigurationSettings (storageInfo, _
                                                          scavengingInfo, expirationInfo, dataProtectionInfo)
            Return config

        Catch genException As Exception
            ExceptionManager.Publish (genException)
            Throw
        End Try
    End Function

#End Region
End Class

#End Region
