#Region "  Imports  "

Imports System.ComponentModel
Imports Core.Framework.Core.Framework
Imports System.Windows.Controls.Control


#End Region

Namespace Core.Windows.UI
    ''' ----------------------------------------------------------------------------
    ''' 
    ''' Class	: SubScreen
    ''' 
    ''' ----------------------------------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of SubScreen.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/22/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
    Public Class SubScreen
        Inherits LinkButton

        ''' --- BeforeClick --------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of BeforeClick.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
            <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Event BeforeClick (ByVal sender As SubScreen, ByRef SubScreenEventArgs As Boolean, _
                                  ByVal e As SubScreenEventArgs)

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
            <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Shadows Event Click (ByVal sender As SubScreen, ByVal e As SubScreenEventArgs)

        ''' --- AfterClick ---------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of AfterClick.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
            <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Event AfterClick (ByVal sender As SubScreen, ByVal e As SubScreenEventArgs)

        Private sseSubScreenEventArgs As SubScreenEventArgs
        Private m_strSubScreenName As String = String.Empty

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
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Sub New()
            MyBase.New()
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of New.
        ''' </summary>
        ''' <param name="SubScreenName"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Sub New (ByVal SubScreenName As String)
            MyBase.New()
            Me.SubScreenName = SubScreenName
        End Sub

        ''' --- SubScreenName ------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of SubScreenName.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Property SubScreenName() As String
            Get
                Return m_strSubScreenName
            End Get
            Set (ByVal Value As String)
                m_strSubScreenName = Value
            End Set
        End Property

        

        ''' --- ControlsLoad -------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of ControlsLoad.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="eventargs"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Private Sub ControlsLoad (ByVal sender As Object, ByVal eventargs As Object)
            ' For this code Init event was too early and Load Event was too late 
            ' For such code use This Method which will be
            
        End Sub

        ''' --- RaiseBeforeClick ---------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of RaiseBeforeClick.
        ''' </summary>
        ''' <param name="Cancel"></param>
        ''' <param name="SubScreenArgs"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Sub RaiseBeforeClick (ByRef Cancel As Boolean, ByVal SubScreenArgs As SubScreenEventArgs)
            RaiseEvent BeforeClick (Me, Cancel, SubScreenArgs)
        End Sub

        ''' --- RaiseClick ---------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of RaiseClick.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Sub RaiseClick()
            Dim blnCancel As Boolean = False
            Dim SubScreenArgs As New SubScreenEventArgs (m_strSubScreenName)
            RaiseEvent BeforeClick (Me, blnCancel, SubScreenArgs)
            If Not blnCancel Then
                RaiseEvent Click (Me, SubScreenArgs)
                RaiseAfterClick (SubScreenArgs)
            End If

        End Sub

        ''' --- RaiseAfterClick ----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of RaiseAfterClick.
        ''' </summary>
        ''' <param name="SubScreenArgs"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Sub RaiseAfterClick (ByVal SubScreenArgs As SubScreenEventArgs)
            RaiseEvent AfterClick (Me, SubScreenArgs)
        End Sub

        

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
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Property CorePage() As Page
            Get
                Return _page
            End Get
            Set (ByVal Value As Page)
                _page = Value
            End Set
        End Property
        Private _page As Page

        ''' --- SubScreen_Init -----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of SubScreen_Init.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Private Sub SubScreen_Init (ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Init
            AddHandler Me.CorePage.ControlsLoad, AddressOf ControlsLoad
        End Sub
    End Class

    ''' ----------------------------------------------------------------------------
    ''' 
    ''' Class	: SubScreenEventArgs
    ''' 
    ''' ----------------------------------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of SubScreenEventArgs.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/22/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
    Public Class SubScreenEventArgs
        Inherits EventArgs

        Private m_colParameters As Collection
        Private m_strSubScreenName As String

        ''' --- New ----------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of New.
        ''' </summary>
        ''' <param name="SubScreenName"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Sub New (ByVal SubScreenName As String)
            m_strSubScreenName = SubScreenName
        End Sub

        ''' --- Parameters ---------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of Parameters.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Property Parameters() As Collection
            Get
                Return m_colParameters
            End Get
            Set (ByVal Value As Collection)
                m_colParameters = Value
            End Set
        End Property
    End Class

    'Public Class SubScreen
    '    Inherits Core.Windows.UI.LinkButton

    '    Public Overrides Property Text() As String
    '        Get
    '            Return MyBase.Text
    '        End Get
    '        Set(ByVal Value As String)
    '            MyBase.Text = Value
    '        End Set
    '    End Property

    '    Public Overrides Property ID() As String
    '        Get
    '            Return MyBase.ID
    '        End Get
    '        Set(ByVal Value As String)
    '            MyBase.ID = Value
    '        End Set
    '    End Property

    '    Protected Overrides Sub Render(ByVal writer As System.Web.UI.HtmlTextWriter)
    '        MyBase.Render(writer)
    '    End Sub

    '    Public Sub New()
    '        MyBase.New()
    '    End Sub
    'End Class
End Namespace