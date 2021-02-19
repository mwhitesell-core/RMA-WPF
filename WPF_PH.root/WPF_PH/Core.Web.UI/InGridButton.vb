Imports Core.Framework.Core.Framework
Imports Core.Framework.Core.Framework.QDesign
Imports System.Windows.Controls
Imports System.ComponentModel
Imports Telerik.Windows.Controls
Imports System.Windows.Threading
Imports System.Windows
Imports System.Drawing
Imports System.Windows.Media

Namespace Core.Windows.UI

    'GridButton is designed to be used inside the DataList Control 
    ''' ----------------------------------------------------------------------------
    ''' 
    ''' Class	: GridButton
    ''' 
    ''' ----------------------------------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of GridButton.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <ToolboxItem(False),
    EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Class InGridButton
        Inherits Button


        ''' --- New ----------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of New.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Sub New()
            MyBase.New()
            'CssClass = "EnableGridButton"
            TabIndex = -1  'By Default no tab index, in case user needs TabIndex, should be overrided in Screen itself
            Me.IsEnabled = False
            Opacity = 0.55
            Background = New SolidColorBrush(Colors.Gray)
        End Sub


        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Sub InGridButton_Loaded(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Loaded

            If Not IsNothing(ApplicationState.Current.CorePage) Then
                With ApplicationState.Current.CorePage
                    AddHandler .DisplayControl, AddressOf PageModeLogic
                End With
            End If


        End Sub


        Private Sub PageModeLogic()

        End Sub


        ''' --- GetGridButtonType --------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of GetGridButtonType.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Private Function GetGridButtonType() As DataListButtons
            Select Case Name.ToUpper
                Case "BTNGRIDROWNEW"  'Clears Grid and enable first row as new Row
                    Return DataListButtons.NewRecordButton
                Case "BTNGRIDROWEDIT" 'Includes Add and Edit both 
                    Return DataListButtons.EditRecordButton
                Case "BTNGRIDROWDELETE"
                    Return DataListButtons.DeleteRecordButton
                Case Else
                    Return DataListButtons.NotSet
            End Select
        End Function


        Private m_strFieldID As String = String.Empty
        <Bindable(False),
       Description("The numbered designer that executes on this field (ie. Designer_02)."),
       Category("Core"),
       DefaultValue(""),
       EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Property FieldID() As String
            Get
                Return m_strFieldID
            End Get
            Set(ByVal Value As String)
                m_strFieldID = Value
            End Set
        End Property

        Public Property CommandName() As String
            Get
                Return _CommandName
            End Get
            Set(ByVal Value As String)
                _CommandName = Value
            End Set
        End Property
        Private _CommandName As String

        Public Property CommandArgument() As String
            Get
                Return _CommandArgument
            End Get
            Set(ByVal Value As String)
                _CommandArgument = Value
            End Set
        End Property
        Private _CommandArgument As String



        Private Sub Clicked() Handles Me.Click



            ApplicationState.Current.CorePage.NavigationType = NavigationTypes.None
            Dim dt As DispatcherTimer = New DispatcherTimer
            AddHandler dt.Tick, AddressOf OnClick
            dt.Interval = New TimeSpan(0, 0, 0, 0, 200)
            dt.Start()

        End Sub

        Public Sub OnClick(sender As Object, e As EventArgs)
            Dim dt = TryCast(sender, DispatcherTimer)
            If dt IsNot Nothing Then
                dt.[Stop]()
            End If
            dt = Nothing

            ApplicationState.Current.CorePage.PageActionObject = me
            ApplicationState.Current.CorePage.InGridFieldID = FieldID 
            ApplicationState.Current.CorePage.PageActionType = PageActionType.DataListButtonClick
            ApplicationState.Current.CorePage.Page_Load(me)
            
           
        End Sub
    End Class





End Namespace

