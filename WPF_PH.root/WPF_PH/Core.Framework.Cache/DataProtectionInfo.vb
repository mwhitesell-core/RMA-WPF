'===============================================================================
' Microsoft Caching Application Block for .NET
' http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dnpag/html/CachingBlock.asp
'
' DataProtectionInfo.vb
' Class that defines the data protection provider settings within the cache
' configuration settings in the config file.
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
Imports System.Globalization

#Region "DataProtection information"

' <summary>
'		This class defines the data protection provider 
'		settings within the cache configuration settings
'		in the config file.
' </summary>

Friend Class DataProtectionInfo
    Inherits ProviderBaseClass

#Region "Public constructor"

    ' <summary>
    '		Creates an instance of this class by reading
    '		the data protection provider settings in the 
    '		cnfig file.
    ' </summary>
    ' <param name="dataProtectionInfo">
    '		The protection information for the data 
    ' </param>
    Public Sub New (ByVal dataProtectionInfo As XmlNode)

        MyBase.New (dataProtectionInfo)

    End Sub

#End Region

#Region "Public methods"

    ' <summary>
    '		Gets a new IDataProtection instance.
    ' </summary>
    ' <remarks>
    '		dataProtection = CreateInstance()
    ' </remarks>
    ' <returns>
    '		The instance of the IDataProtection interface
    ' </returns>
    Public Function CreateInstance() As IDataProtection

        ' Check the provider for the implementation
        ' of the desired interface
        Try
            providerType.GetInterfaceMap (GetType (IDataProtection))
        Catch
            Throw New Exception (String.Format (CultureInfo. _
                                                   CurrentCulture, CacheResources.ResourceManager ( _
                                                                                                   "RES_ExceptionInvalidConfigurationInvalidProviderInterface"), _
                                                Me.GetType().Name, providerAssemblyName, providerClassName, _
                                                "IDataProtection"))
        End Try

        ' Create the provider instance
        Try
            Dim providerInstance As Object = Activator.CreateInstance ( _
                                                                       providerType)
            Dim dataProtection As IDataProtection = CType (providerInstance, _
                    IDataProtection)
            dataProtection.Init (configProviderInfo)
            Return dataProtection

        Catch genException As Exception
            Throw New Exception (String.Format ( _
                                                CultureInfo.CurrentCulture, CacheResources.ResourceManager ( _
                                                                                                            "RES_ExceptionInvalidConfigurationProviderInformationCantCreateInstance"), _
                                                Me.GetType().Name, providerAssemblyName, providerClassName, _
                                                "IDataProtection"), genException)
        End Try

    End Function

#End Region
End Class

#End Region
