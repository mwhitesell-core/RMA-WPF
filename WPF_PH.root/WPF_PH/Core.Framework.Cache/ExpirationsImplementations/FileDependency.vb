'===============================================================================
' Microsoft Caching Application Block for .NET
' http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dnpag/html/CachingBlock.asp
'
' FileDependency.vb
' This class tracks a file cache dependency.
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
Imports System.IO
Imports Core.ExceptionManagement

' Used for Handling Exceptions

Namespace Expirations
    ' <summary>
    '		This class tracks a file cache dependency.
    ' </summary>

    <Serializable()> _
    Public Class FileDependency
        Implements ISerializable, ICacheItemExpiration

#Region "Private members"

        Private keyValue As String
        Private dependencyFileName As String
        Private lastAccessedTime As DateTime

#End Region

#Region "Constructor"

        ' <summary>
        '       Constructor which accepts the qualified name of the file.
        ' </summary>
        ' <param name="fullFileName">
        '       The fully qualified name of the file
        ' </param>
        Public Sub New (ByVal fullFileName As String)
            Try
                Dim path As String
                Dim fileName As String

                If Equals (fullFileName, Nothing) Then
                    Throw New ArgumentNullException ("fullFileName", _
                                                     CacheResources.ResourceManager ( _
                                                                                     "RES_ExceptionNullFileName"))
                End If

                If fullFileName.Length = 0 Then
                    Throw New ArgumentOutOfRangeException ("fullFileName", _
                                                           CacheResources.ResourceManager ( _
                                                                                           "RES_ExceptionEmptyFileName"))
                End If

                If Not File.Exists (fullFileName) Then
                    Throw New ArgumentException (CacheResources. _
                                                    ResourceManager ("RES_ExceptionInvalidFileName"))
                End If

                ' Validate File
                Dim fileInformation As New FileInfo (fullFileName)
                If Not fileInformation.Exists Then
                    Throw New FileNotFoundException()
                End If

                ' Get Path from full file name
                path = IO.Path.GetDirectoryName (fullFileName)
                ' Get file name from full file name
                fileName = IO.Path.GetFileName (fullFileName)

                dependencyFileName = fullFileName

                ' Set the last accessed time
                lastAccessedTime = File.GetLastAccessTime (fullFileName)

            Catch genException As Exception
                ExceptionManager.Publish (genException)
                Throw
            End Try

        End Sub

#End Region

#Region "ICacheItemExpiration Implementation"

        ' <summary>
        '		Event to indicate the cache item expiration.
        ' </summary>

        Public Event Change As ItemDependencyChangeEventHandler _
            Implements ICacheItemExpiration.change

        ' <summary>
        '		This method sets the external dependency key.
        ' </summary>

        Sub Key (ByVal keyVal As String) Implements ICacheItemExpiration.Key

            Try
                If Equals (keyVal, Nothing) Then
                    Throw New ArgumentNullException ("keyVal", CacheResources. _
                                                        ResourceManager ("RES_ExceptionNullKey"))
                End If

                If keyVal.Length = 0 Then
                    Throw New ArgumentOutOfRangeException ("keyVal", _
                                                           CacheResources.ResourceManager ("RES_ExceptionEmptyKey"))
                End If

                keyValue = keyVal

            Catch genException As Exception
                ExceptionManager.Publish (genException)
                Throw
            End Try

        End Sub

        ' <summary>
        '		Specifies if item has expired or not.
        ' </summary>

        Function HasExpired() As Boolean Implements _
                                             ICacheItemExpiration.HasExpired

            ' Compare the Filedependency object's last accessed time 
            ' value with the last accessed time value. If they are not
            ' equal return true, otherwise false.
            If (DateTime.Compare (lastAccessedTime, _
                                  File.GetLastAccessTime (dependencyFileName)) <> 0) Then
                Return True
            Else
                Return False
            End If

        End Function

        ' <summary>
        '		Notifies that the item was recently used.
        ' </summary>

        Sub Notify() Implements ICacheItemExpiration.Notify
        End Sub

#End Region

#Region "Serialization functions"

#Region "Public method"

        ' <summary>
        '		This method performs the serializaton of members of the 
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
            ' Adds the file name and last accessed time 
            ' into the SerializationInfo, 
            ' where it is associated with the name key
            info.AddValue ("fileName", dependencyFileName)
            info.AddValue ("lastAccessedTime", lastAccessedTime)

        End Sub

#End Region

#Region "Constructor"

        ' <summary>
        '		This method performs the deserialization of members of the 
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
                ' Getting the value of file name and
                ' last accessed time
                dependencyFileName = info.GetString ("fileName")
                lastAccessedTime = Convert.ToDateTime ( _
                                                       info.GetValue ("lastAccessedTime", _
                                                                      GetType (DateTime)))

            Catch genException As Exception
                ExceptionManager.Publish (genException)
                Throw
            End Try

        End Sub

#End Region

#End Region
    End Class
End Namespace