'===============================================================================
' Microsoft Caching Application Block for .NET
' http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dnpag/html/CachingBlock.asp
'
' ScavengingInfo.vb
' Class that defines the scavenging algorithm settings within the cache
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
Imports System.Configuration

#Region "Scavenging information"

' <summary>
'		This class that defines the scavenging algorithm settings within 
'		the cache configuration settings in the config file.
' </summary>

Friend Class ScavengingInfo
    Inherits ProviderBaseClass

#Region "Public constructor"

    ' <summary>
    '       Default constructor.
    ' </summary>
    ' <param>
    '       Xmlnode which provides the scavenging information
    ' </param>
    Public Sub New (ByVal scavengingInfo As XmlNode)
        MyBase.New (scavengingInfo)
    End Sub

#End Region


#Region "Public methods"

    ' <summary>
    '		Gets a new IScavengingAlgorithm instance.
    ' </summary>
    ' <remark>
    '       CreateInstance( cacheService, cacheStorage , cacheMetadata )
    ' </remark>
    ' <param name="cacheService">
    '		Instance of CacheService
    ' </param>
    ' <param name="cacheStorage">
    '		Instance of ICacheStorage
    ' </param>
    ' <param name="cacheMetadata">
    '		Instance of ICacheMetadata
    ' </param>
    ' <returns>
    '		The instance of the scavenging algorithm
    ' </returns>

    Public Function CreateInstance (ByVal cacheService As CacheService, _
                                    ByVal cacheStorage As ICacheStorage, _
                                    ByVal cacheMetadata As ICacheMetadata) As IScavengingAlgorithm

        Try
            If Equals (cacheService, Nothing) Then
                Throw (New ArgumentNullException ("cacheService", _
                                                  CacheResources.ResourceManager ( _
                                                                                  "RES_ExceptionNullCacheService")))
            End If

            If Equals (cacheStorage, Nothing) Then
                Throw (New ArgumentNullException ("cacheStorage", _
                                                  CacheResources.ResourceManager ( _
                                                                                  "RES_ExceptionNullCacheStorage")))
            End If

            ' Returns an interface mapping for the specified
            ' interface type
            providerType.GetInterfaceMap (GetType (IScavengingAlgorithm))
        Catch
            Throw New Exception (String.Format (CultureInfo. _
                                                   CurrentCulture, CacheResources.ResourceManager ( _
                                                                                                   "RES_ExceptionInvalidConfigurationInvalidProviderInterface"), _
                                                Me.GetType().Name, providerAssemblyName, providerClassName, _
                                                "IScavengingAlgorithm"))
        End Try

        ' Create the provider instance
        Try
            Dim providerInstance As Object = Activator.CreateInstance ( _
                                                                       providerType)
            Dim scavengingAlgorithm As IScavengingAlgorithm = _
                    CType (providerInstance, IScavengingAlgorithm)
            scavengingAlgorithm.Init (cacheService, cacheStorage, _
                                      cacheMetadata, configProviderInfo)
            Return scavengingAlgorithm

        Catch genException As Exception
            Throw New ConfigurationErrorsException (String.Format (CultureInfo. _
                                                                      CurrentCulture, CacheResources.ResourceManager ( _
                                                                                                                      "RES_ExceptionInvalidConfigurationProviderInformationCantCreateInstance"), _
                                                                   Me.GetType().Name, providerAssemblyName, _
                                                                   providerClassName, _
                                                                   "IScavengingAlgorithm"), genException)
        End Try

    End Function

#End Region
End Class

#End Region
