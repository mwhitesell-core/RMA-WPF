'===============================================================================
' Microsoft Caching Application Block for .NET
' http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dnpag/html/CachingBlock.asp
'
' CacheConfiguration.vb
' Helper class to obtain cache configuration from config file.
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
Imports Core.ExceptionManagement

' Used for Handling Exceptions

' <summary>
'		Helper class to obtain cache configuration from config file.
' </summary>

Friend Class CacheConfiguration
    Private Shared configSetting As CacheConfigurationSettings

#Region "Constructor"

    ' <summary>
    '		The private constructor prevents class from getting created.
    ' </summary>

    Private Sub New()
    End Sub

#End Region

#Region "Properties"

    ' <summary>
    '		Gets the cache configuration.
    ' </summary>

    Public Shared ReadOnly Property Config() As CacheConfigurationSettings

        Get
            Try
                ' Validation of input arguments
                If Equals (configSetting, Nothing) Then
                    configSetting = CType (ConfigurationManager.GetSection ( _
                                                                            CacheResources.ResourceManager ( _
                                                                                                            "RES_CacheManagerSettings")), _
                        CacheConfigurationSettings)

                    If Equals (configSetting, Nothing) Then
                        configSetting = New CacheConfigurationSettings ( _
                                                                        Nothing, Nothing, Nothing, Nothing)
                    End If
                End If

            Catch genException As Exception
                ExceptionManager.Publish (genException)
                Throw
            End Try

            Return configSetting
        End Get
    End Property

#End Region
End Class
