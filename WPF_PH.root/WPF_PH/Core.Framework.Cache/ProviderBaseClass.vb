'===============================================================================
' Microsoft Caching Application Block for .NET
' http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dnpag/html/CachingBlock.asp
'
' ProviderBaseClass.vb
' Base class for all providers settings within the cache configuration settings
' in the config file.
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
Imports System.Configuration
Imports System.Globalization
Imports System.Reflection
Imports Core.ExceptionManagement

' Used for Handling exceptions

#Region "Provider class"

' <summary>
'		Base class for all providers settings within the
'		cache configuration settings in the config file.
' </summary>

Friend MustInherit Class ProviderBaseClass

#Region "Declare field members"

    ' <summary>
    '		The XmlNode for the provider definition on the XML
    '		configuration file.
    ' </summary>
    Protected configProviderInfo As XmlNode

    ' <summary>
    '		The provider's assembly name.
    ' </summary>
    Protected providerAssemblyName As String

    ' <summary>
    '		The provider's class name.
    ' </summary>
    Protected providerClassName As String

    ' <summary>
    '		The provider's type.
    ' </summary>
    Protected providerType As Type

#End Region

#Region "Constructor"

    ' <summary>
    '		Constructor to read all the provider settings
    '		from the config file.
    ' </summary>

    Protected Sub New (ByVal providerInfo As XmlNode)

        Try
            If Equals (providerInfo, Nothing) Then
                Throw (New ArgumentNullException ("providerInfo", _
                                                  CacheResources.ResourceManager ( _
                                                                                  "RES_ExceptionNullProviderInfo")))
            End If

            configProviderInfo = providerInfo

            ' Check assembly name
            If Equals (configProviderInfo.Attributes (CacheResources. _
                                                         ResourceManager ("RES_AssemblyName")), Nothing) Then
                Throw New ConfigurationErrorsException (String.Format (CultureInfo. _
                                                                          CurrentCulture, _
                                                                       CacheResources.ResourceManager ( _
                                                                                                       "RES_ExceptionInvalidConfigurationProviderTypeInformationAssembly"), _
                                                                       Me.GetType().Name))
            End If

            ' Check class name
            If Equals (configProviderInfo.Attributes (CacheResources. _
                                                         ResourceManager ("RES_ClassName")), Nothing) Then
                Throw New ConfigurationErrorsException (String.Format (CultureInfo. _
                                                                          CurrentCulture, _
                                                                       CacheResources.ResourceManager ( _
                                                                                                       "RES_ExceptionInvalidConfigurationProviderTypeInformationClassName"), _
                                                                       Me.GetType().Name))
            End If

            providerAssemblyName = configProviderInfo.Attributes ( _
                                                                  CacheResources.ResourceManager ("RES_AssemblyName")). _
                Value
            ' Check the assembly name provider
            If providerAssemblyName.Length = 0 Then
                Throw New ConfigurationErrorsException (String.Format (CultureInfo. _
                                                                          CurrentCulture, _
                                                                       CacheResources.ResourceManager ( _
                                                                                                       "RES_ExceptionInvalidConfigurationProviderTypeInformationAssembly"), _
                                                                       Me.GetType().Name))
            End If

            ' Check the class name provider
            providerClassName = configProviderInfo.Attributes (CacheResources. _
                                                                  ResourceManager ("RES_ClassName")).Value
            If providerClassName.Length = 0 Then
                Throw New ConfigurationErrorsException (String.Format (CultureInfo. _
                                                                          CurrentCulture, _
                                                                       CacheResources.ResourceManager ( _
                                                                                                       "RES_ExceptionInvalidConfigurationProviderTypeInformationClassName"), _
                                                                       Me.GetType().Name))
            End If

            ' Check the provider type
            Dim assemblyInstance As Assembly = _
                    [Assembly].Load (providerAssemblyName)
            providerType = assemblyInstance.GetType (providerClassName, True)
        Catch genException As Exception
            Throw New Exception (String.Format (CultureInfo. _
                                                   CurrentCulture, CacheResources.ResourceManager ( _
                                                                                                   "RES_ExceptionInvalidConfigurationProviderInformation"), _
                                                Me.GetType().Name, providerAssemblyName, providerClassName), _
                                 genException)
        End Try

    End Sub

#End Region

#Region "Public properties"

    ' <summary>
    '		Gets the provider's assembly name.
    ' </summary>
    Public ReadOnly Property AssemblyName() As String
        Get
            Return providerAssemblyName
        End Get
    End Property

    ' <summary>
    '		Gets the provider's class name.
    ' </summary>
    Public ReadOnly Property ClassName() As String

        Get
            Return providerClassName
        End Get
    End Property

    ' <summary>
    '		Gets the value of the property.
    ' </summary>
    Default Public ReadOnly Property Item (ByVal propertyName As String) _
        As String

        Get
            Try
                Dim customProperty As XmlNode
                Dim propertyValue As String = ""

                If propertyName.Length = 0 Then
                    Throw New ArgumentOutOfRangeException ("propertyName", _
                                                           CacheResources.ResourceManager ( _
                                                                                           "RES_ExceptionEmptyPropertyName"))
                End If

                If Equals (propertyName, Nothing) Then
                    Throw New ArgumentNullException ("propertyName", _
                                                     CacheResources.ResourceManager ( _
                                                                                     "RES_ExceptionNullPropertyName"))
                End If

                customProperty = configProviderInfo.SelectSingleNode (( _
                                                                         CacheResources.ResourceManager ( _
                                                                                                         "RES_CharacterForPropertyValue") + _
                                                                         propertyName))

                If Not Equals (customProperty, Nothing) Then
                    propertyValue = customProperty.Value
                End If

                customProperty = configProviderInfo.SelectSingleNode (( _
                                                                         CacheResources.ResourceManager ( _
                                                                                                         "RES_CharacterForPropertyInnerText") + _
                                                                         propertyName))

                If Not Equals (customProperty, Nothing) Then
                    propertyValue = customProperty.InnerText
                End If
                Return propertyValue

            Catch genException As Exception
                ExceptionManager.Publish (genException)
                Throw
            End Try

        End Get
    End Property

#End Region
End Class

#End Region
