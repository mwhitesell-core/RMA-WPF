'===============================================================================
' Microsoft Caching Application Block for .NET
' http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dnpag/html/CachingBlock.asp
'
' CacheItem.vb
' This class is used to get or set the value and metadata of a cache item
'
'===============================================================================
' Copyright (C) 2003 Microsoft Corporation
' All rights reserved.
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
' OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
' LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR
' FITNESS FOR A PARTICULAR PURPOSE.
'===============================================================================
Imports Core.ExceptionManagement

' Used for handling Exceptions

' <summary>
'		This class represents a cache item.
'		A cache item has a value and metadata
'		which can be set or got using this class.
' </summary>
<Serializable()> _
Public Class CacheItem

#Region "Member Variables"

    Private itemKey As String
    Private itemValue As Object
    Private itemPriority As CacheItemPriority
    Private itemExpirations As ICacheItemExpiration()

#End Region

#Region "Constructor"

    ' <summary>
    '		Default constructor.
    ' </summary>

    Public Sub New()
        itemPriority = CacheItemPriority.Normal
    End Sub

#End Region

#Region "Properties"

    ' <summary>
    '		Gets or Sets the item key.
    ' </summary>

    Public Property Key() As String

        Get
            Return itemKey
        End Get

        Set (ByVal Value As String)
            Try
                If Equals (Value, Nothing) Then
                    Throw New ArgumentNullException ("itemKey", _
                                                     CacheResources.ResourceManager ( _
                                                                                     "RES_ExceptionNullItemKey"))
                End If

                If Value.Length = 0 Then
                    Throw New ArgumentOutOfRangeException ("itemKey", _
                                                           CacheResources.ResourceManager ( _
                                                                                           "RES_ExceptionEmptyItemKey"))
                End If
                itemKey = Value
            Catch genException As Exception
                ExceptionManager.Publish (genException)
                Throw
            End Try
        End Set
    End Property

    ' <summary>
    '		Gets or Sets the item value.
    ' </summary>

    Public Property Value() As Object

        Get
            Return itemValue
        End Get

        Set (ByVal Value As Object)
            Try
                itemValue = Value
            Catch genException As Exception
                ExceptionManager.Publish (genException)
                Throw
            End Try
        End Set
    End Property

    ' <summary>
    '		Gets or Sets the item priority.
    ' </summary>

    Public Property Priority() As CacheItemPriority

        Get
            Return itemPriority
        End Get

        Set (ByVal Value As CacheItemPriority)
            Try
                itemPriority = Value
            Catch genException As Exception
                ExceptionManager.Publish (genException)
                Throw
            End Try
        End Set
    End Property

    ' <summary>
    '		Gets or Sets the item expirations.
    ' </summary>

    Public Property Expirations() As ICacheItemExpiration()

        Get
            Return itemExpirations
        End Get

        Set (ByVal value As ICacheItemExpiration())

            itemExpirations = value
        End Set
    End Property

#End Region
End Class
