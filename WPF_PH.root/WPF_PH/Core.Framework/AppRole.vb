Imports System


Partial Public Class AppRole


#Region "Properties"

#Region "Columns"


    Private _Code As String
    Private _EnglishName As String
    Private _FrenchName As String
    Private _ID As Integer
     Private _Priority As Int32

     Public Property Priority() As Int32 
        Get
            Return _Priority
        End Get
        Set(value As Int32)
            If _Priority <> value Then
                _Priority = value
            End If
        End Set
    End Property

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

    Public Property Code() As String
        Get
            Return _Code
        End Get
        Set(value As String)
            If _Code <> value Then
                _Code = value
            End If
        End Set
    End Property

    Public Property EnglishName() As String
        Get
            Return _EnglishName
        End Get
        Set(value As String)
            If _EnglishName <> value Then
                _EnglishName = value
            End If
        End Set
    End Property

    Public Property FrenchName() As String
        Get
            Return _FrenchName
        End Get
        Set(value As String)
            If _FrenchName <> value Then
                _FrenchName = value
            End If
        End Set
    End Property



#End Region



#End Region


End Class


