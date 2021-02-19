'===============================================================================
' Microsoft Caching Application Block for .NET
' http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dnpag/html/CachingBlock.asp
'
' ExtendedFormatTime.vb
' This class provides tests if a data item was expired using a extended format.
'
'===============================================================================
' Copyright (C) 2003 Microsoft Corporation
' All rights reserved.
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
' OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
' LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR
' FITNESS FOR A PARTICULAR PURPOSE.
'===============================================================================
Imports System.Runtime.Serialization
Imports System.Security.Permissions
Imports Core.ExceptionManagement
Imports System.Globalization
Imports System.Text


' Used for Handling Exceptions

Namespace Expirations
    ' <summary>
    '		This provider tests if an item was expired using a extended 
    '       format.
    ' </summary>

    <Serializable()> _
    Public Class ExtendedFormatTime
        Implements ISerializable, ICacheItemExpiration

#Region "Private Members"

        Private extendedFormat As String
        Private lastUsedTime As DateTime
        Private isItemExpired As Boolean

#End Region

#Region "Constructor"

        ' <summary>
        '		Creates an instance of the class.
        ' </summary>
        Public Sub New()
        End Sub

        ' <summary>
        '		Convert the input format to the extented time format.
        ' </summary>
        ' <param name="format">
        '		This contains the expiration information
        ' </param>
        Public Sub New (ByVal timeFormat As String)
            Try
                If Equals (timeFormat, Nothing) Then
                    Throw New ArgumentNullException ("timeFormat", _
                                                     CacheResources.ResourceManager ( _
                                                                                     "RES_ExceptionNullTimeFormat"))
                End If

                If timeFormat.Length = 0 Then
                    Throw New ArgumentNullException ("timeFormat", _
                                                     CacheResources.ResourceManager ( _
                                                                                     "RES_ExceptionRangeTimeFormat"))
                End If

                ' Validate the format
                Dim format As New extendedFormat (timeFormat)

                ' Get the modified extended format
                extendedFormat = GetModifiedFormat (timeFormat)

                ' Convert to UTC in order to compensate for time zones		
                lastUsedTime = DateTime.Now.ToUniversalTime()
            Catch genException As Exception
                ExceptionManager.Publish (genException)
                Throw
            End Try

        End Sub

#End Region

#Region "Implementation of ICacheItemExpiration"

        ' <summary>
        '		Checks whether the if item has expired or not.
        ' </summary>
        ' <remarks>
        '		ICacheItemExpiration.HasExpired()
        ' </remarks>
        ' <returns>
        '		True if the item was expired, otherwise false
        ' </returns>
        Function IsExpired() As Boolean Implements _
                                            ICacheItemExpiration.HasExpired

            Try
                ' Convert to UTC in order to compensate for time zones		
                Dim nowDateTime As DateTime = DateTime.Now.ToUniversalTime()

                ' Check expiration
                If ExtendedFormatHelper.IsExtendedExpired (extendedFormat, _
                                                           lastUsedTime, nowDateTime) Then
                    isItemExpired = True
                Else
                    isItemExpired = False
                End If
                Return isItemExpired

            Catch genException As Exception
                ExceptionManager.Publish (genException)
                Throw

            End Try

        End Function

        ' <summary>
        '		Notifies that the item was recently used.
        ' </summary>
        Sub Notify() Implements ICacheItemExpiration.Notify
        End Sub

        ' <summary>
        '		This method sets the external dependency key.
        ' </summary>
        Sub Key (ByVal keyValue As String) Implements _
                                               ICacheItemExpiration.Key

        End Sub

        ' <summary>
        '		Event to indicate the cache item expiration.
        ' </summary>
        Public Event change As ItemDependencyChangeEventHandler _
            Implements ICacheItemExpiration.change

#End Region

#Region "ISerializable implementation "

#Region "Public Method"

        ' <summary>
        '		This method performs the serialziaton of members of the 
        '		current class.
        ' </summary>
        ' <param name="info">
        '		A SerializationInfo object which is deserialized by the 
        '		formatter and then passed to current constructor
        ' </param>
        ' <param name="context">
        '		A StreamingContext that describes the source of the 
        '		serialized stream from where the Serialization object 
        '		is retrieved
        ' </param>
        <SecurityPermission (SecurityAction.Demand, _
                             SerializationFormatter := True), SecurityPermissionAttribute ( _
                                                                                           SecurityAction.LinkDemand, _
                                                                                           SerializationFormatter := _
                                                                                              True)> _
        Public Sub GetObjectData (ByVal info As SerializationInfo, _
                                  ByVal context As StreamingContext) Implements _
                                                                         ISerializable.GetObjectData

            Try
                info.AddValue ("extendedFormat", extendedFormat)
                info.AddValue ("lastUsedTime", lastUsedTime)

            Catch genException As Exception
                ExceptionManager.Publish (genException)
                Throw
            End Try

        End Sub

#End Region

#Region "Protected Method"

        ' <summary>
        '		This method performs the deserialziaton of members of the 
        '		current class.
        ' </summary>
        ' <param name="info">
        '		A SerializationInfo object which is deserialized by the 
        '		formatter and then passed to current constructor
        ' </param>
        ' <param name="context">
        '		A StreamingContext that describes the source of the 
        '		serialized stream from where the Serialization object 
        '		is retrieved
        ' </param>
        Protected Sub New (ByVal info As SerializationInfo, _
                           ByVal context As StreamingContext)

            Try
                extendedFormat = info.GetString ("extendedFormat")
                lastUsedTime = Convert.ToDateTime (info.GetValue ( _
                                                                  "lastUsedTime", GetType (DateTime)), _
                                                   DateTimeFormatInfo.CurrentInfo)
            Catch genException As Exception
                ExceptionManager.Publish (genException)
                Throw
            End Try

        End Sub

#End Region

#Region "Private methods"

        ' <summary>
        '	    This function modifies the format passed from the client. If the 
        '	    minute format is wild card character, it converts it to current minute
        '	    plus one so that the cache item expires after a minute.
        ' </summary>
        ' <remarks>
        '	    string modifiedFormat = GetModifiedFormat(format);
        ' </remarks>
        ' <param name="format">
        '       The format to be modified
        ' </param>
        ' <returns>
        '	    Returns the modified extended format
        ' </returns>
        Private Function GetModifiedFormat (ByVal format As String) As String

            Const MAX_MINUTE As Integer = 59
            Dim modifiedFormat As New StringBuilder()

            ' Check whether the first character is wild card
            If (format.IndexOf ( _
                                CacheResources.ResourceManager ("RES_WildcardAll")) = 0) Then

                Dim nowMinute As Integer = _
                        DateTime.Now.ToUniversalTime().Minute + 1
                ' Replace the first character with the current 
                ' minute value + 1. If it is greater than 59 use zero. 
                ' i.e it will expire in the next hour.
                If (nowMinute > MAX_MINUTE) Then
                    nowMinute = 0
                End If
                modifiedFormat.Append (nowMinute.ToString())
                modifiedFormat.Append ( _
                                       format.Substring (1, format.Length - 1))
                Return modifiedFormat.ToString()
            Else
                Return format
            End If
        End Function

#End Region

#End Region
    End Class
End Namespace
