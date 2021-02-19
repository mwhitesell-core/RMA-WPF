Imports System.Collections.ObjectModel
Imports System.Configuration
Imports System.IO
Imports System.Windows

Namespace Core.Windows.Framework
    Public NotInheritable Class ApplicationState
#Region "Singleton Behavior"

        Private Shared _current As ApplicationState

        Public Shared Property Current() As ApplicationState
            Get
                Return If(_current, (InlineAssignHelper(_current, New ApplicationState())))
            End Get
            Friend Set(value As ApplicationState)
                _current = value
            End Set
        End Property

#End Region

        Public CurrentRoles As New ObservableCollection(Of AppRole)
        Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
            target = value
            Return value
        End Function

        Private _designersecurity As New Hashtable()
        Public Property designersecurity() As Hashtable
            Get
                Return _designersecurity
            End Get
            Set
                _designersecurity = Value
            End Set
        End Property

        Private _menusecurity As New Hashtable()
        Public Property menusecurity() As Hashtable
            Get
                Return _menusecurity
            End Get
            Set
                _menusecurity = Value
            End Set
        End Property

        Private _cache As New Hashtable()
        Public Property cache() As Hashtable
            Get
                Return _cache
            End Get
            Set
                _cache = Value
            End Set
        End Property

        Private _ConnectionStrings As New Hashtable()
        Public Property ConnectionStrings() As Hashtable
            Get
                Return _ConnectionStrings
            End Get
            Set
                _ConnectionStrings = Value
            End Set
        End Property

        Private _CurrentConnectionStrings As String
        Public Property CurrentConnectionStrings() As String
            Get
                Return _CurrentConnectionStrings
            End Get
            Set
                _CurrentConnectionStrings = Value
            End Set
        End Property


        Private _pb_data As String
        Public Property pb_data() As String
            Get
                Return _pb_data
            End Get
            Set
                _pb_data = Value
            End Set
        End Property

        Private _createempty As Boolean
        Public Property Createempty() As Boolean
            Get
                Return _createempty
            End Get
            Set
                _createempty = Value
            End Set
        End Property



    End Class


End Namespace

