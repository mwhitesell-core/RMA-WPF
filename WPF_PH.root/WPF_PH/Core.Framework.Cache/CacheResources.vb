'===============================================================================
' Microsoft Caching Application Block for .NET
' http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dnpag/html/CachingBlock.asp
'
' CacheResources.vb
' This class is used to access the constants defined in the Resources file.
'
'===============================================================================
' Copyright (C) 2003 Microsoft Corporation
' All rights reserved.
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
' OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
' LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR
' FITNESS FOR A PARTICULAR PURPOSE.
'===============================================================================
Imports System.Resources
Imports System.Globalization
Imports Core.ExceptionManagement
Imports System.Reflection

' Used for handling Exceptions

' <summary>
'		This class is used to access the constants defined in the
'		resources file.
' </summary>

Public Class CacheResources
    ' Member Variables
    Private Shared resource As CacheResources
    Private cachingResourceManager As ResourceManager
    Private constantValue As String

#Region "Properties"

    ' <summary>
    '		Indexer to get the value of the key.
    ' </summary>
    Default Public ReadOnly Property Item (ByVal key As String) As String

        Get
            Try
                constantValue = cachingResourceManager.GetString (key, _
                                                                  CultureInfo.CurrentCulture)

                Return constantValue
            Catch genException As Exception
                ExceptionManager.Publish (genException)
                Throw
            End Try

        End Get
    End Property

    ' <summary>
    '		Gets the resource instance variable.
    ' </summary>
    Public Shared ReadOnly Property ResourceManager() As CacheResources

        Get
            Try
                If Equals (resource, Nothing) Then
                    resource = New CacheResources()
                    Return resource
                Else
                    Return resource
                End If
            Catch genException As Exception
                ExceptionManager.Publish (genException)
                Throw
            End Try

        End Get
    End Property

#End Region

#Region "Instance part"

    ' <summary>
    '		Constructor to initialize the resource manager 
    '		instance variable.
    ' </summary>
    Private Sub New()

        Try
            Const RESOURCE_FILE As String = ".CacheManagerText"

            cachingResourceManager = New ResourceManager ( _
                                                          GetType (CacheManager).Namespace + RESOURCE_FILE, _
                                                          Assembly.GetExecutingAssembly())
        Catch genException As Exception
            ExceptionManager.Publish (genException)
            Throw
        End Try

    End Sub

#End Region
End Class
