Imports System.ComponentModel
Imports System.Windows
Imports System.Windows.Controls

Namespace Core.Windows.UI
    Public Class CoreTreeViewItem
        Inherits TreeViewItem
        Private _notroles As String
        Private _roles As String
        Private _mode As String
        Private _textkey As string

        Public Sub New()
     

        End Sub

          Public Property TextKey() As String
            Get
                Return _textkey
            End Get
            Set(value As String)
                If _textkey <> value Then
                    _textkey = value
                End If
            End Set
        End Property

        Public Property Mode() As String
            Get
                Return _mode
            End Get
            Set(value As String)
                If _mode <> value Then
                    _mode = value
                End If
            End Set
        End Property

        Public Property Roles() As String
            Get
                Return _roles
            End Get
            Set(value As String)
                If _roles <> value Then
                    _roles = value
                End If
            End Set
        End Property

        Public Property NotRoles() As String
            Get
                Return _notroles
            End Get
            Set(value As String)
                If _notroles <> value Then
                    _notroles = value
                End If
            End Set
        End Property

        'Private Sub CoreTreeViewItemUnloaded(sender As Object, e As RoutedEventArgs) Handles Me.Unloaded
        '    IsLoadOnDemandEnabled = True
        'End Sub

        Private Sub CoreTreeViewItemLoaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
            Visibility = Visibility.Visible

        End Sub
    End Class
End Namespace


