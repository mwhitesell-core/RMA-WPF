'===============================================================================
' Microsoft Caching Application Block for .NET
' http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dnpag/html/CachingBlock.asp
'
' AbsoluteTime.vb
' This class tests if a data item was expired using a absolute time schema.
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
    '		This class tests if a data item was expired using
    '		a absolute time schema.
    ' </summary>
    <Serializable()> _
    Public Class AbsoluteTime
        Implements ISerializable, ICacheItemExpiration

#Region "Private members"

        Private absoluteExpirationTime As DateTime
        Private isExpired As Boolean
        Private keyValue As String

#End Region

#Region "Constructors"

        ' <summary>
        '		Create a new instance of the class.
        ' </summary>
        Public Sub New()
        End Sub

        ' <summary>
        '		Create an instance of the class with a time value
        '		as input and convert it to UTC.
        ' </summary>
        ' <param name="absoluteTime">
        '		The time to be checked for expiration
        ' </param>
        Public Sub New (ByVal absoluteTime As DateTime)

            Try
                If absoluteTime > DateTime.Now Then
                    ' Convert to UTC in order to compensate for time zones	
                    absoluteExpirationTime = absoluteTime.ToUniversalTime
                Else
                    Throw New ArgumentOutOfRangeException ("absoluteTime", _
                                                           CacheResources.ResourceManager ( _
                                                                                           "RES_ExceptionRangeAbsoluteTime"))
                End If
            Catch genException As Exception
                ExceptionManager.Publish (genException)
                Throw
            End Try

        End Sub

#End Region

#Region "ICacheItemExpiration Implementation"

        ' <summary>
        '		This method sets the external dependency key.
        ' </summary>
        Sub Key (ByVal keyVal As String) Implements ICacheItemExpiration.Key

            If Equals (keyVal, Nothing) Then
                Throw New ArgumentNullException ("keyVal", CacheResources. _
                                                    ResourceManager ("RES_ExceptionNullKey"))
            End If

            If keyVal.Length = 0 Then
                Throw New ArgumentOutOfRangeException ("keyVal", _
                                                       CacheResources.ResourceManager ("RES_ExceptionEmptyKey"))
            End If

            keyValue = keyVal

        End Sub

        ' <summary>
        '		Checks whether the item has expired or not.
        ' </summary>
        ' <remarks>
        '		isExpired = ICacheItemExpiration.HasExpired()
        ' </remarks>
        ' <returns>
        '		"True", if the data item has expired or "false", if the 
        '		data item has not expired
        ' </returns>
        Function HasExpired() As Boolean Implements _
                                             ICacheItemExpiration.HasExpired

            Try
                ' Convert to UTC in order to compensate for time zones		
                Dim nowDateTime As DateTime = DateTime.Now.ToUniversalTime()

                ' Check expiration
                If nowDateTime.Ticks > absoluteExpirationTime.Ticks Then
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

        ' <summary>
        '		Notifies that the item was recently used.
        ' </summary>

        Sub Notify() Implements ICacheItemExpiration.Notify
        End Sub

        ' <summary>
        '   	Event to indicate the cache item expiration.
        ' </summary>

        Public Event Change As ItemDependencyChangeEventHandler _
            Implements ICacheItemExpiration.change

#End Region

#Region "Implementation of ISerializable"

        ' <summary>
        '		Deserialization constructor.
        ' </summary>

        Protected Sub New (ByVal info As SerializationInfo, _
                           ByVal context As StreamingContext)

            Try
                absoluteExpirationTime = Convert.ToDateTime (info.GetValue ( _
                                                                            "absoluteExpiration", GetType (DateTime)), _
                                                             DateTimeFormatInfo.CurrentInfo)
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
                             SerializationFormatter := True), _
            SecurityPermissionAttribute (SecurityAction.LinkDemand, _
                                         SerializationFormatter := True)> _
        Public Sub GetObjectData (ByVal info As SerializationInfo, _
                                  ByVal context As StreamingContext) _
            Implements ISerializable.GetObjectData

            Try
                info.AddValue ("absoluteExpiration", absoluteExpirationTime)

            Catch genException As Exception
                ExceptionManager.Publish (genException)
                Throw

            End Try

        End Sub

#End Region
    End Class
End Namespace

