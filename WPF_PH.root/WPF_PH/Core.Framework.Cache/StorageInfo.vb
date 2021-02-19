'===============================================================================
' Microsoft Caching Application Block for .NET
' http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dnpag/html/CachingBlock.asp
'
' StorageInfo.vb
' Class that defines the storage provider settings within the cache
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

#Region "Storage information"

' <summary>
'		This class defines the storage provider settings within the
'		cache configuration settings in the config file.
' </summary>

Friend Class StorageInfo
    Inherits ProviderBaseClass

#Region "Public constructor"

    Public Sub New (ByVal storageInfo As XmlNode)

        MyBase.New (storageInfo)

    End Sub

#End Region

#Region "Public methods"

    ' <summary>
    '		Gets a new ICacheStorage instance.
    ' </summary>
    ' <returns>
    '		Returns a interface mapping for the ICacheStorage
    '		interface type
    ' </returns>
    Public Function CreateInstance() As ICacheStorage

        Try
            ' Returns an interface mapping for the specified
            ' interface type
            providerType.GetInterfaceMap (GetType (ICacheStorage))
        Catch
            Throw New Exception (String.Format (CultureInfo. _
                                                   CurrentCulture, CacheResources.ResourceManager ( _
                                                                                                   "RES_ExceptionInvalidConfigurationInvalidProviderInterface"), _
                                                Me.GetType().Name, providerAssemblyName, providerClassName, _
                                                "ICacheStorage"))
        End Try

        ' Create the provider instance
        Try
            Dim providerInstance As Object = Activator.CreateInstance ( _
                                                                       providerType)
            Dim cacheStorage As ICacheStorage = CType (providerInstance, _
                    ICacheStorage)
            cacheStorage.Init (configProviderInfo)
            Return cacheStorage
        Catch genException As Exception
            Throw New Exception (String.Format (CultureInfo. _
                                                   CurrentCulture, CacheResources.ResourceManager ( _
                                                                                                   "RES_ExceptionInvalidConfigurationProviderInformationCantCreateInstance"), _
                                                Me.GetType().Name, providerAssemblyName, providerClassName, _
                                                "ICacheStorage"), genException)
        End Try

    End Function

#End Region
End Class

#End Region