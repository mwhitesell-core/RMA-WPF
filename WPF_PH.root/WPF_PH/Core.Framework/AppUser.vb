Imports System



Public Class AppUser


#Region "Properties"

#Region "Columns"

    Private RowCheckSum As Integer
    Private _ADUserName As String
    Private _AppUserStatusLookupID As System.Nullable(Of Integer)
    Private _FirstName As String
    Private _ID As Integer
    Private _IsADUser As String
    Private _LastName As String

    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(value As Integer)
            If _ID <> value Then
                _ID = value
            End If
        End Set
    End Property

    Public Property FirstName() As String
        Get
            Return _FirstName
        End Get
        Set(value As String)
            If _FirstName <> value Then
                _FirstName = value
            End If
        End Set
    End Property

    Public Property LastName() As String
        Get
            Return _LastName
        End Get
        Set(value As String)
            If _LastName <> value Then
                _LastName = value
            End If
        End Set
    End Property

    Public Property IsADUser() As String
        Get
            Return _IsADUser
        End Get
        Set(value As String)
            If _IsADUser <> value Then
                _IsADUser = value
            End If
        End Set
    End Property

    Public Property ADUserName() As String
        Get
            Return _ADUserName
        End Get
        Set(value As String)
            If _ADUserName <> value Then
                _ADUserName = value
            End If
        End Set
    End Property



#End Region



#End Region


End Class



