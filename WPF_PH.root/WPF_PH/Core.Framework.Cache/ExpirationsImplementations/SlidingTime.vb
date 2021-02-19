'===============================================================================
' Microsoft Caching Application Block for .NET
' http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dnpag/html/CachingBlock.asp
'
' SlidingTime.vb
' This class provides tests if a item was expired using a time slice schema.
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

' Used for Handling Exceptions

Namespace Expirations
    ' <summary>
    '		This provider tests if an item was expired using a 
    '		time slice schema.
    ' </summary>

    <Serializable()> _
    Public Class SlidingTime
        Implements ISerializable, ICacheItemExpiration

#Region "Private members"

        Private timeLastUsed As DateTime
        Private itemSlidingExpiration As TimeSpan
        Private expirationTicks As Long

#End Region

#Region "Constructor"

        ' <summary>
        '		Create an instance of this class with the
        '		timespan for expiration.
        ' </summary>
        ' <param name="slidingExpiration">
        '		Expiration time span
        ' </param>
        Public Sub New (ByVal slidingExpiration As TimeSpan)
            Try
                ' Check the expiration for null
                If Equals (slidingExpiration, Nothing) Then
                    Throw New ArgumentNullException ( _
                                                     "slidingExpiration", CacheResources.ResourceManager ( _
                                                                                                          "RES_ExceptionNullSlidingExpiration"))
                End If

                If slidingExpiration.TotalSeconds >= 1 Then
                    itemSlidingExpiration = slidingExpiration
                Else
                    Throw New ArgumentOutOfRangeException ( _
                                                           "slidingExpiration", CacheResources.ResourceManager ( _
                                                                                                                "RES_ExceptionRangeSlidingExpiration"))
                End If
            Catch genException As Exception
                ExceptionManager.Publish (genException)
                Throw
            End Try
        End Sub

#End Region

#Region "Implementation of ICacheItemExpiration"

        ' <summary>
        '		This method sets the external dependency key.
        ' </summary>
        Sub Key (ByVal keyValue As String) Implements ICacheItemExpiration.Key

        End Sub

        ' <summary>
        '		Event to indicate the cache item expiration.
        ' </summary>
        Public Event change As ItemDependencyChangeEventHandler _
            Implements ICacheItemExpiration.change

        ' <summary>
        '		Specifies if item has expired or not.
        ' </summary>
        Function IsExpired() As Boolean Implements _
                                            ICacheItemExpiration.HasExpired

            Dim isItemExpired As Integer = CheckSlidingExpiration ( _
                                                                   DateTime.Now, timeLastUsed, itemSlidingExpiration)
            Return isItemExpired

        End Function

        ' <summary>
        '		Notifies that the item was recently used.
        ' </summary>
        Sub Notify() Implements ICacheItemExpiration.Notify

            timeLastUsed = DateTime.Now

        End Sub

#End Region

#Region "Private functions"

        ' <summary>
        '		Checks whether the sliding time has expired.
        ' </summary>
        ' <remarks>
        '		CheckSlidingExpiration(DateTime.Now, timeLastUsed, 
        '           itemSlidingExpiration)
        ' </remarks>
        ' <param name="nowDateTime">
        '		Current time
        ' </param>
        ' <param name="lastUsed">
        '		The last time when the item has been used
        ' </param>
        ' <param name="slidingExpiration">
        '		The span of sliding expiration
        ' </param>
        ' <returns>
        '		True if the item was expired, otherwise false
        ' </returns>
        Private Function CheckSlidingExpiration ( _
                                                 ByVal nowDateTime As DateTime, _
                                                 ByVal lastUsed As DateTime, _
                                                 ByVal slidingExpiration As TimeSpan) _
            As Boolean

            Try
                ' Variable Declarations
                Dim tmpNowDateTime As DateTime
                Dim tmpLastUsed As DateTime
                Dim isExpired As Boolean = False

                ' Convert to UTC in order to compensate for time zones
                tmpNowDateTime = nowDateTime.ToUniversalTime()

                ' Calculate the ticks only once
                If Not Equals (expirationTicks, 0) Then

                    ' Convert to UTC in order to compensate for time zones
                    tmpLastUsed = lastUsed.ToUniversalTime()

                    expirationTicks = tmpLastUsed.Ticks + _
                                      slidingExpiration.Ticks
                End If

                If tmpNowDateTime.Ticks > expirationTicks Then
                    isExpired = True
                Else
                    isExpired = False
                End If
                Return isExpired

            Catch genException As Exception
                ExceptionManager.Publish (genException)
                Throw
            End Try

        End Function

#End Region

#Region "ISerializable implementation "

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
                timeLastUsed = Convert.ToDateTime (info.GetValue ("lastUsed", _
                                                                  GetType (DateTime)), DateTimeFormatInfo.CurrentInfo)
                itemSlidingExpiration = CType (info.GetValue ( _
                                                              "slidingExpiration", GetType (TimeSpan)), TimeSpan)

            Catch genException As Exception
                ExceptionManager.Publish (genException)
                Throw
            End Try

        End Sub

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
                info.AddValue ("slidingExpiration", itemSlidingExpiration)
                info.AddValue ("lastUsed", timeLastUsed)

            Catch genException As Exception
                ExceptionManager.Publish (genException)
                Throw
            End Try

        End Sub

#End Region
    End Class
End Namespace
