'Imports System.Web
'Imports System.Web.UI

Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.ComponentModel
Imports System.Drawing.Design



Namespace Core.Windows.UI

    ''' ----------------------------------------------------------------------------
    ''' 
    ''' Class	: ImageButton
    ''' 
    ''' ----------------------------------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of ImageButton.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/22/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <ToolboxItem(False), _
    EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
    Public Class ImageButton
        Inherits System.Web.UI.WebControls.WebControl
        Implements INamingContainer
        Implements IPostBackEventHandler

        ''' --- Click --------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of Click.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Event Click(ByVal sender As Object, ByVal e As CommandEventArgs)

        ''' --- Command ------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of Command.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Event Command(ByVal sender As Object, ByVal e As CommandEventArgs)

        Protected WithEvents m_ImageButton As New System.Web.UI.WebControls.HyperLink
        'Protected WithEvents m_submit As New System.Web.UI.WebControls.ImageButton

        Private m_CommandEventArgs As New CommandEventArgs("", "")
        Private m_strCommandArgument As String

#Region "Methods"

        ''' --- New ----------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of New.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Sub New()
            MyBase.New()
            
            m_ImageButton.TabIndex = 0
            m_strCommandArgument = ""
            m_CommandEventArgs = New CommandEventArgs("", "")
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of New.
        ''' </summary>
        ''' <param name="ID"></param>
        ''' <param name="ImageURL"></param>
        ''' <param name="CommandName"></param>
        ''' <param name="CommandArgument"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Sub New(ByVal ID As String, ByVal ImageURL As String, Optional ByVal CommandName As String = "", Optional ByVal CommandArgument As String = "")
            MyBase.New()
            
            Me.ID = ID
            Me.ImageURL = ImageURL
            Me.CommandArgument = CommandArgument
            m_strCommandArgument = CommandArgument
            m_CommandEventArgs = New CommandEventArgs(CommandName, CommandArgument)

            Me.TabIndex = 0

        End Sub

        'Adds the controls to the composite control
        ''' --- CreateChildControls ------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of CreateChildControls.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Protected Overrides Sub CreateChildControls()
            Controls.Add(m_ImageButton)
        End Sub

#End Region

#Region "Properties"

        ''' --- ImageURL -----------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of ImageURL.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False), _
       LoadDictionary(False), _
       Description("The URL of the Image to be on the Button Face."), _
       DefaultValue(""), _
       Category("Core"), _
        Editor(GetType(System.Web.UI.Design.ImageUrlEditor), GetType(UITypeEditor)), _
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Property ImageURL() As String
            Get
                
                Return m_ImageButton.ImageUrl
            End Get
            Set(ByVal Value As String)
                
                m_ImageButton.ImageUrl = Value
            End Set
        End Property

        ''' --- CommandName --------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of CommandName.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False), _
        Description("Gets the name for the command"), _
        Category("Core"), _
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Property CommandName() As String
            Get
                Return m_CommandEventArgs.CommandName
            End Get
            Set(ByVal Value As String)
                Dim oldArg As Object = m_CommandEventArgs.CommandArgument

                m_CommandEventArgs = New CommandEventArgs(Value, oldArg)

            End Set
        End Property

        ''' --- CommandArgument ----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of CommandArgument.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False), _
        Description("Gets the argument for the command"), _
        Category("Core"), _
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Property CommandArgument() As Object
            Get
                Return m_CommandEventArgs.CommandArgument()
            End Get
            Set(ByVal Value As Object)

                Dim oldName As String = m_CommandEventArgs.CommandName

                m_CommandEventArgs = New CommandEventArgs(oldName, Value)

            End Set
        End Property

#End Region

        ''' --- RaisePostBackEvent -------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of RaisePostBackEvent.
        ''' </summary>
        ''' <param name="eventArgument"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Sub RaisePostBackEvent(ByVal eventArgument As String) Implements System.Web.UI.IPostBackEventHandler.RaisePostBackEvent

            OnCommand(m_CommandEventArgs)

        End Sub

        ''' --- ImageButton_Load ---------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of ImageButton_Load.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Private Sub ImageButton_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Me.Enabled Then
                m_ImageButton.NavigateUrl = m_ImageButton.Page.ClientScript.GetPostBackClientHyperlink(Me, m_strCommandArgument)
            End If
        End Sub

        ''' --- OnCommand ----------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of OnCommand.
        ''' </summary>
        ''' <param name="e"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Protected Overridable Sub OnCommand(ByVal e As CommandEventArgs)

            RaiseEvent Command(Me, e)

        End Sub

        ''' --- UpdateNavigateUrl --------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of UpdateNavigateUrl.
        ''' </summary>
        ''' <param name="CommandArgument"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Sub UpdateNavigateUrl(ByVal CommandArgument As String)
            If Me.Enabled Then
                m_ImageButton.NavigateUrl = m_ImageButton.Page.ClientScript.GetPostBackClientHyperlink(Me, CommandArgument)
            End If
        End Sub

    End Class

End Namespace
