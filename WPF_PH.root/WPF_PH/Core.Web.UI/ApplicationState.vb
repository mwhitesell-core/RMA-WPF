Imports System.Collections.ObjectModel
Imports System.Configuration
Imports System.IO
Imports System.Windows.Controls
Imports System.Windows
Imports Core.Framework

Namespace Core.Windows.UI
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

       
        Public Property IsQA as Boolean 
         Public Property Application As Hashtable = New Hashtable
         Public Property Session As Hashtable = New Hashtable 
        Public Property PassingObjects As Hashtable = New Hashtable
        Public Property TrackingObjects As Hashtable
        Public Property ScreenLevel As Integer
        Public Property CreateWhere As Boolean
         Public Property CancelPost As Boolean
        Public Property TempTable As Hashtable = New Hashtable

        Private _dateFormat As String = ConfigurationManager.AppSettings("DateFormat")
        Private _dateSeparator As String = ConfigurationManager.AppSettings("DateSeparator")

        Public Property dtNow As String

        Private _lastAddedConstituent As Integer = -1

        Private _currentUser As AppUser = New AppUser
        Public Property CurrentUser() As AppUser
            Get
                Return _currentUser
            End Get
            Set(value As AppUser)
                _currentUser = value
            End Set
        End Property

        Public CurrentRoles As New ObservableCollection(Of AppRole)
        Public Property Navigate As Boolean

         Public Property CallScreen As string

        Private _corepage As Page
        ''' --- CorePage -----------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of CorePage.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        Public Property CorePage() As Page
            Get
                Return _corepage
            End Get
            Set(value As Page)
                _corepage = value
            End Set
        End Property

        Private _tempDir As String

        Private _userName As String = String.Empty

        Public Property DateFormat() As String
            Get
                Return _dateFormat
            End Get
            Set(value As String)
                SyncLock _dateFormat
                    _dateFormat = value
                End SyncLock
            End Set
        End Property



        Public ReadOnly Property TempDir() As String
            Get
                If _tempDir Is Nothing Then
                    _tempDir = Path.GetTempPath() + "Rmaapp\"
                    If Not Directory.Exists(_tempDir) Then
                        Directory.CreateDirectory(_tempDir)
                    End If
                End If
                Return _tempDir
            End Get
        End Property



        Public Property UserName() As String
            Get
                Return _userName
            End Get
            Set(value As String)
                SyncLock _userName
                    _userName = value
                End SyncLock
            End Set
        End Property





        Public ReadOnly Property UserNameWithoutDomain() As String
            Get
                Return _userName.Substring(_userName.LastIndexOf("\") + 1)
            End Get
        End Property

        Public Property MainX() As Double
            Get
                Return m_MainX
            End Get
            Set(value As Double)
                m_MainX = value
            End Set
        End Property
        Private m_MainX As Double
        Public Property MainY() As Double
            Get
                Return m_MainY
            End Get
            Set(value As Double)
                m_MainY = value
            End Set
        End Property
        Private m_MainY As Double

        Public Property MainHeight() As Double
            Get
                Return m_MainHeight
            End Get
            Set(value As Double)
                m_MainHeight = value
            End Set
        End Property
        Private m_MainHeight As Double
        Public Property MainWidth() As Double
            Get
                Return m_MainWidth
            End Get
            Set(value As Double)
                m_MainWidth = value
            End Set
        End Property
        Private m_MainWidth As Double

        Public Property Keys() As String
            Get
                Return m_Keys
            End Get
            Set(value As String)
                m_Keys = value
            End Set
        End Property
        Private m_Keys As String


        Public Property LastAddedConstituent() As Integer
            Get
                Return _lastAddedConstituent
            End Get
            Set(value As Integer)
                _lastAddedConstituent = value
            End Set
        End Property

        Private m_ShowMenu As Boolean
        Public Property ShowMenu() As Boolean
            Get
                Return m_ShowMenu
            End Get
            Set(value As Boolean)
                m_ShowMenu = value
            End Set
        End Property

        Private m_Selected As Integer
        Public Property Selected() As Integer
            Get
                Return m_Selected
            End Get
            Set(value As Integer)
                m_Selected = value
            End Set
        End Property

        Private m_trview As TreeView
        Public Property trview() As TreeView
            Get
                Return m_trview
            End Get
            Set(value As TreeView)
                m_trview = value
            End Set
        End Property

        Public Property Filter() As String
            Get
                Return m_Filter
            End Get
            Set(value As String)
                m_Filter = value
            End Set
        End Property
        Private m_Filter As String
        Public Property HasError() As Boolean
            Get
                Return m_HasError
            End Get
            Set(value As Boolean)
                m_HasError = value
            End Set
        End Property
        Private m_HasError As Boolean
        Public Property FieldNameError() As String
            Get
                Return m_FieldNameError
            End Get
            Set(value As String)
                m_FieldNameError = value
            End Set
        End Property
        Private m_FieldNameError As String
        Public Property UndoHasFocus() As Boolean
            Get
                Return m_UndoHasFocus
            End Get
            Set(value As Boolean)
                m_UndoHasFocus = value
            End Set
        End Property
        Private m_UndoHasFocus As Boolean


        Public Property CurrentScreen() As Window
            Get
                Return m_CurrentScreen
            End Get
            Set(value As Window)
                m_CurrentScreen = value
            End Set
        End Property
        Private m_CurrentScreen As Window
        Public Property PreviousCurrentScreen() As Window
            Get
                Return m_PreviousCurrentScreen
            End Get
            Set(value As Window)
                m_PreviousCurrentScreen = value
            End Set
        End Property
        Private m_PreviousCurrentScreen As Window
        Public Property IsProcessing() As Boolean
            Get
                Return m_IsProcessing
            End Get
            Set(value As Boolean)
                m_IsProcessing = value
            End Set
        End Property
        Private m_IsProcessing As Boolean
        Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
            target = value
            Return value
        End Function



        Private _lookupCharacter As String
        Public Property LookupCharacter As String
            Get
                Return _lookupCharacter
            End Get
            Set(value As String)
                _lookupCharacter = value
            End Set
        End Property

        Private _GenericRetrievalCharacter As String
        Public Property GenericRetrievalCharacter As String
            Get
                Return _GenericRetrievalCharacter
            End Get
            Set(value As String)
                _GenericRetrievalCharacter = value
            End Set
        End Property

         Private _language As String
        Public Property Language As String
            Get
                Return _language
            End Get
            Set(value As String)
                _language = value
            End Set
        End Property

          Private _HelpScreens As Hashtable
        Public Property HelpScreens As Hashtable
            Get
                Return _HelpScreens
            End Get
            Set(value As Hashtable)
                _HelpScreens = value
            End Set
        End Property




    End Class


End Namespace

