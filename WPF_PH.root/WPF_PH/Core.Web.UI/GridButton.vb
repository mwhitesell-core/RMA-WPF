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
    <ToolboxItem(False), _
    EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
    Public Class GridButton
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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Sub New()
            MyBase.New()
            'CssClass = "EnableGridButton"
            TabIndex = -1  'By Default no tab index, in case user needs TabIndex, should be overrided in Screen itself
            Me.IsEnabled = False
            Background = New SolidColorBrush(Colors.Gray)
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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
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

            ApplicationState.Current.CorePage.ClearSequence()

            If ApplicationState.Current.CorePage.Mode = PageModeTypes.NoMode AndAlso Me.Name = "btnGridRowNew"
                
                 ApplicationState.Current.CorePage.NavigationType = NavigationTypes.Entry
            End If
           

            ApplicationState.Current.CorePage.Page_Load(Me)
        End Sub
    End Class



    ''' ----------------------------------------------------------------------------
    ''' 
    ''' Class	: GridButtonEventArgs
    ''' 
    ''' ----------------------------------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of GridButtonEventArgs.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
    Public Class GridButtonEventArgs
        Inherits EventArgs

        Public RowIndex As Integer
        Public CommandArgument As String
        Public CommandName As String
        Public DataListItem As GridViewRowPresenter
        Public RowStatus As Windows.UI.RowStatus
        Public GridButton As Windows.UI.GridButton

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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Sub New()
            MyBase.New()
            RowIndex = -1
            CommandArgument = ""
            CommandName = ""
            DataListItem = Nothing
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of New.
        ''' </summary>
        ''' <param name="objDataListItem"></param>
        ''' <param name="objGridButton"></param>
        ''' <param name="objRowStatus"></param>
        ''' <param name="strCommandName"></param>
        ''' <param name="strCommandArgument"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Sub New(ByVal objDataListItem As GridViewRowPresenter, ByVal objGridButton As Windows.UI.GridButton, ByVal objRowStatus As Windows.UI.RowStatus, ByVal strCommandName As String, ByVal strCommandArgument As String)
            MyBase.New()

            With objDataListItem
                'If objGridButton Is Nothing Then objGridButton = .FindControl("btnGridRowEdit")
                'If objRowStatus Is Nothing Then objRowStatus = .FindControl("btnGridRowStatus")
            End With
            With objGridButton
                If strCommandName Is Nothing OrElse strCommandArgument Is Nothing Then
                    strCommandName = .CommandName
                    strCommandArgument = .CommandArgument
                End If
            End With
            CommandName = strCommandName
            CommandArgument = strCommandArgument
            DataListItem = objDataListItem
            'RowIndex = objDataListItem.ItemIndex
            RowStatus = objRowStatus
            GridButton = objGridButton
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of New.
        ''' </summary>
        ''' <param name="objDataListItem"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Sub New(ByVal objDataListItem As GridViewRowPresenter)
            MyBase.New()

            With objDataListItem
                'If GridButton Is Nothing Then GridButton = .FindControl("btnGridRowEdit")
                'If RowStatus Is Nothing Then RowStatus = .FindControl("btnGridRowStatus")
            End With
            With GridButton
                CommandName = .CommandName
                CommandArgument = .CommandArgument
            End With
            DataListItem = objDataListItem
            'RowIndex = objDataListItem.ItemIndex
            RowStatus = RowStatus
        End Sub

    End Class



End Namespace

