Imports System.ComponentModel

Namespace Core.Framework
    ''' ----------------------------------------------------------------------------
    ''' 
    ''' Class	: HelpSystem
    ''' 
    ''' ----------------------------------------------------------------------------
    ''' 
    ''' <summary>
    ''' 	The HelpSystem class encapsulates the help information required by the framework.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Always)> _
    Public Class HelpSystem
        ''' --- mURL ---------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of mURL.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> Private mURL As String

        ''' --- mBrowserOptions ----------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of mBrowserOptions.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> Private mBrowserOptions As String

        ''' --- mWindowState -------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of mWindowState.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> Private mWindowState As WindowTypes

        ''' --- URL ----------------------------------------------------------------
        ''' 
        ''' <summary>
        '''     The URL that identifies where the help files are located.
        ''' </summary>
        ''' <remarks>
        '''     This URL contains placeholders for the Language and Screen name.  These
        '''     are used to change the help being displayed based on the language 
        '''     being used by the current user (multilingual applications only) and the 
        '''     screen for which to display the help.  This property is set in Global.asax.
        ''' </remarks>
        ''' <note>This property is set in Global.asax.
        ''' </note>
        ''' <example>
        '''     Help.URL = "http://localhost/MYAPP/help/{LANGUAGE}/{SCREEN}.htm"  <br/>
        '''     <br/>
        '''     URL = Help.URL <br/>
        '''     URL = URL.Replace("{LANGUAGE}", Page.Language) <br/>
        '''     URL = URL.Replace("{SCREEN}", Page.FormName) <br/>
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Always)> _
        Public Property URL() As String
            Get
                Return mURL
            End Get
            Set (ByVal Value As String)
                mURL = Value
            End Set
        End Property

        ''' --- BrowserOptions -----------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Add the options to indicate whether the browser should have the status bar
        '''     displayed, as well as the position and dimensions of the form.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <example>Help.BrowserOptions = "status:no;help:no;center:yes;resizable:yes;dialogWidth:600px;dialogHeight:450px" <br/>
        ''' </example>
        ''' <note>This property is set in Global.asax.
        ''' </note>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Always)> _
        Public Property BrowserOptions() As String
            Get
                Return mBrowserOptions
            End Get
            Set (ByVal Value As String)
                mBrowserOptions = Value
            End Set
        End Property

        ''' --- WindowState --------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Indicates whether the window should be a modal or non-modal form.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <example>Help.WindowState = Core.Framework.WindowTypes.Modal
        ''' </example>
        ''' <note>This property is set in Global.asax.
        ''' </note>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Always)> _
        Public Property WindowState() As WindowTypes
            Get
                Return mWindowState
            End Get
            Set (ByVal Value As WindowTypes)
                mWindowState = Value
            End Set
        End Property
    End Class
End Namespace
