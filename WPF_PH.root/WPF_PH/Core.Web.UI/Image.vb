Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.ComponentModel
Imports System.Drawing.Design
Imports Core.Framework.Core.Framework
Imports Core.Framework.Core.Framework.QDesign

Namespace Core.Windows.UI

   
    <ToolboxItem(True), _
    EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
   Public Class Image
        Inherits System.Web.UI.WebControls.WebControl
        Implements IPostBackDataHandler
        Implements INamingContainer

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
        Public Event Click(ByVal sender As Object, ByVal e As EventArgs)

        ''' --- m_Image ------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Protected WithEvents m_Image As New System.Web.UI.WebControls.Image


        Private m_strEnabledCssClassDefault As String = "ToolbarDefault"
        Private m_strEnabledCssClassHover As String = "ToolbarHover"
        Private m_strDisabledCssClass As String = ""

        ''' --- ObjectStateMedium --------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Protected ObjectStateMedium As StateMedium = StateMedium.SessionOnServer

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
            
            'Me.Height = New Unit(20)
            'Me.Width = New Unit(90)
            'm_Image'.TabIndex = -1
            m_Image.ID = "Image"
            Me.EnableViewState = False
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
            Controls.Add(m_Image)
        End Sub

        ''' --- LoadPostData -------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of LoadPostData.
        ''' </summary>
        ''' <param name="postDataKey"></param>
        ''' <param name="postCollection"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Function LoadPostData(ByVal postDataKey As String, ByVal postCollection As System.Collections.Specialized.NameValueCollection) As Boolean Implements System.Web.UI.IPostBackDataHandler.LoadPostData

        End Function

        ''' --- RaisePostDataChangedEvent ------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of RaisePostDataChangedEvent.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Sub RaisePostDataChangedEvent() Implements System.Web.UI.IPostBackDataHandler.RaisePostDataChangedEvent
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
       LoadDictionary(True), _
       Description("The URL of the Image to be on the Button Face."), _
       DefaultValue(""), _
       Category("Core"), _
        Editor(GetType(System.Web.UI.Design.ImageUrlEditor), GetType(UITypeEditor)), _
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Property ImageURL() As String
            Get

                Return m_Image.ImageUrl
            End Get
            Set(ByVal Value As String)

                If Not IsNothing(HttpContext.Current) Then
                    m_Image.ImageUrl = Value
                Else

                    m_Image.ImageUrl = Value

                End If
            End Set
        End Property

        ''' --- CssClass -----------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of CssClass.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False), _
       LoadDictionary(False), _
       Description("The CssClass for the ToolBarImageButton."), _
       DefaultValue(""), _
       Category("Core"), _
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Private Shadows Property CssClass() As String
            'Note: this property is not exposed to the developer 
            'rather EnabledCssClassDefault, EnabledCssClassHover and DisabledCssClass should be used
            Get

                Return MyBase.CssClass
            End Get
            Set(ByVal Value As String)

                MyBase.CssClass = Value
                m_Image.CssClass = Value
            End Set
        End Property

#End Region

        ''' --- ToolBarImageButton_PreRender ---------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of ToolBarImageButton_PreRender.
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
        Private Sub ToolBarImageButton_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.PreRender
            'm_Image'.TabIndex = -1
            m_Image.Style.Add("vertical-align", "middle")
            Me.CssClass = m_strDisabledCssClass
            m_Image.Visible = True
        End Sub

        ''' --- ToolBarImageButton_Load --------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of ToolBarImageButton_Load.
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
        Private Sub ToolBarImageButton_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Page.RegisterRequiresPostBack(Me)
        End Sub


        <Bindable(False), _
        Browsable(False), _
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Friend Property PageSession(ByVal PageSessionKey As String) As Object
            Get
                Dim strPageSessionKey As String = "TOOLBAR" + "_" + PageSessionKey
                Select Case ObjectStateMedium
                    Case StateMedium.SessionOnServer
                        'Return Page.Session(strPageSessionKey)
                        Return ViewState(strPageSessionKey)
                    Case StateMedium.PageOnClient
                        Return ViewState(strPageSessionKey)
                    Case StateMedium.DatabaseOnServer
                        'Needs an implementation
                    Case StateMedium.DiskOnServer
                        'Needs an implementation
                End Select
                Return Nothing
            End Get

            Set(ByVal Value As Object)
                Dim strPageSessionKey As String = "TOOLBAR" + "_" + PageSessionKey
                Select Case ObjectStateMedium
                    Case StateMedium.SessionOnServer
                        'Page.Session(strPageSessionKey) = Value
                        ViewState(strPageSessionKey) = Value
                    Case StateMedium.PageOnClient
                        ViewState(strPageSessionKey) = Value
                    Case StateMedium.DatabaseOnServer
                        'Needs an implementation
                    Case StateMedium.DiskOnServer
                        'Needs an implementation
                End Select
            End Set
        End Property

        ''' --- FieldSession -------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of FieldSession.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public ReadOnly Property FieldSession() As Hashtable
            Get
                Dim htFieldSession As Hashtable
                htFieldSession = CType(Me.PageSession(Me.UniqueID), Hashtable)
                If htFieldSession Is Nothing Then
                    htFieldSession = New Hashtable(10)
                    Me.PageSession(Me.UniqueID) = htFieldSession
                End If
                Return htFieldSession
            End Get
        End Property



    End Class

End Namespace

