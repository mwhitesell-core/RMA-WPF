'===============================================================================
' Microsoft Caching Application Block for .NET
' http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dnpag/html/CachingBlock.asp
'
' ExpirationInfo.vb
' Class that defines the expiration provider settings within the cache
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
Imports System.Configuration
Imports System.Globalization
Imports Core.ExceptionManagement

' Used for handling Exceptions

#Region "Expiration information"

' <summary>
'		This class defines the expiration provider settings within
'		the cache configuration settings in the config file.
' </summary>

Friend Class ExpirationInfo

#Region "Field members"

    Private expirationInterval As Integer

#End Region

#Region "Public constructor"

    ' <summary>
    '		Constructor to read the expiration information from
    '		the config file.
    ' </summary>

    Public Sub New (ByVal expirationInfo As XmlNode)

        Try
            If Equals (expirationInfo, Nothing) Then
                Throw New ArgumentNullException ("expirationInfo", _
                                                 CacheResources.ResourceManager ( _
                                                                                 "RES_ExceptionNullExpirationInfo"))
            End If

            ' Check the expiration information
            If Equals (expirationInfo.Attributes (CacheResources. _
                                                     ResourceManager ("RES_Interval")), Nothing) Then
                Throw New ConfigurationErrorsException (CacheResources. _
                                                           ResourceManager ( _
                                                                            "RES_ExceptionNullConfigurationExpirationInfo"))
            End If

            Dim intervalString As String = expirationInfo.Attributes ( _
                                                                      CacheResources.ResourceManager ("RES_Interval")). _
                    Value

            ' Check the interval
            If intervalString.Length = 0 Then
                Throw New ConfigurationErrorsException (CacheResources. _
                                                           ResourceManager ( _
                                                                            "RES_ExceptionEmptyConfigurationExpirationInfo"))
            End If

            Dim intervalValue As Double
            If Double.TryParse (intervalString, NumberStyles.Integer, Nothing, intervalValue) Then

                If intervalValue > Integer.MaxValue Then
                    Throw New ConfigurationErrorsException (CacheResources. _
                                                               ResourceManager ( _
                                                                                "RES_ExceptionMaxConfigurationExpirationInfo"))
                End If
                expirationInterval = Integer.Parse (intervalString, _
                                                    NumberFormatInfo.CurrentInfo)
                If expirationInterval < 1 Then
                    Throw New ConfigurationErrorsException (CacheResources. _
                                                               ResourceManager ( _
                                                                                "RES_ExceptionMinConfigurationExpirationInfo"))
                End If
            Else
                Throw New ConfigurationErrorsException (CacheResources. _
                                                           ResourceManager ( _
                                                                            "RES_ExceptionInvalidConfigurationExpirationInfo"))
            End If

        Catch genException As Exception
            ExceptionManager.Publish (genException)
            Throw
        End Try

    End Sub

#End Region

#Region "Properties"

    ' <summary>
    '		Gets the expiration interval.
    ' </summary>
    Public ReadOnly Property Interval() As Integer

        Get
            Return expirationInterval
        End Get
    End Property

#End Region
End Class

#End Region
