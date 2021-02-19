Imports System.ComponentModel
Imports System.Web.Caching
Imports System.Configuration
Imports Core.Globalization.Core.Globalization
Imports System.Web.UI.HtmlControls
Imports Core.Framework.Core.Framework
Imports System.Web
Imports Core.Framework.Core.Security
Imports System.Collections.Specialized
Imports Core.Framework
Imports Core.ExceptionManagement

Namespace Core.Windows.UI
    ''' ----------------------------------------------------------------------------
    ''' 
    ''' Class	: ApplicationPage
    ''' 
    ''' ----------------------------------------------------------------------------
    ''' 
    ''' <summary>
    ''' 	This ApplicationPage is the base page that contains Globalization logic as well as functionality to display messages
    ''' and save session information that is available to the application.
    ''' </summary>
    ''' <remarks>
    ''' NOTE: This page is used by Default.aspx (default login page), Calendar and other Renaissance Architect forms.
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	7/4/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Always)> _
    Public Class ApplicationPage
        Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        ''' --- InitializeComponent ------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of InitializeComponent.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <DebuggerStepThrough(), _
            EditorBrowsable (EditorBrowsableState.Advanced)> _
        Private Sub InitializeComponent()

        End Sub

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        ''' --- designerPlaceholderDeclaration -------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of designerPlaceholderDeclaration.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> Private designerPlaceholderDeclaration As Object

        ''' --- Page_Init ----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of Page_Init.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Private Sub Page_Init (ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()

            'CoreWebTrace("Page_Load", "Before SetGlobalizationManager")
            'SetGlobalizationManager()
            'CoreWebTrace("Page_Load", "After SetGlobalizationManager")

            '------- To be used with new Session Manager
            ''Instantiate a calls to communicate with Session State
            'SessionInformation = New SessionInformation(Me.Session.SessionID, Me.FormName, Me.Level)

            'RetrieveGlobalSessions()
            '------- To be used with new Session Manager

            'Dim Flag As Boolean = SetCoreStyleSheet("gnaStyles.css", 1)
            'gna Dim Flag As Boolean = DelCoreStyleSheet()
        End Sub

#End Region

        '<EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Protected GlobalizationManager As GlobalizationManager

        ''' --- CoreBodyTag ------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Allows access to the attributes of the BODY tag.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Always)> Protected Friend WithEvents CoreBodyTag As HtmlContainerControl

        ''' --- m_strPageName ------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of m_strPageName.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> Private m_strPageName As String

        ''' --- onRemove -----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of onRemove.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> Private onRemove As CacheItemRemovedCallback

        ''' --- m_blnLanguageChanged -----------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of m_blnLanguageChanged.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> Private m_blnLanguageChanged As New Boolean

        ' Used for Session Manager Component.
        ''' --- m_csScreen ---------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of m_csScreen.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> Private m_csScreen As Hashtable

        ''' --- m_csParameters -----------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of m_csParameters.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> Private m_csParameters As Hashtable

        ''' --- m_csGlobal ---------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of m_csGlobal.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> Private m_csGlobal As Hashtable

       

        ''' --- m_intScreenLevel ---------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of m_intScreenLevel.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> Private m_intScreenLevel As Integer = - 1

        ''' --- m_intNextScreenLevel -----------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of m_intNextScreenLevel.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> Private m_intNextScreenLevel As Integer = - 1

        ' Used for the State Manager Component.
        ''' --- RetrieveGlobalSessions ---------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of RetrieveGlobalSessions.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Private Sub RetrieveGlobalSessions()
            '------- To be used with new Session Manager
            'm_csGlobal = SessionInformation.GetSessionStateCollection
            '------- To be used with new Session Manager
        End Sub

        ' Used for the State Manager Component.
        ''' --- SaveGlobalSessions -------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of SaveGlobalSessions.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Private Sub SaveGlobalSessions()
            '------- To be used with new Session Manager
            'If Not m_csGlobal Is Nothing Then SessionInformation.SaveSessionStateCollection(m_csGlobal)
            '------- To be used with new Session Manager
        End Sub

        ''' --- GlobalSession ------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Gets or sets a value in session that is available to every screen in the application for the current session using a key-value pair.
        ''' </summary>
        ''' <param name="Key">A unique identifier used to save and retrieve the value</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Always)> _
        Protected Friend Property GlobalSession (ByVal Key As String) As Object
            Get
                Return Session (Key)
            End Get
            Set (ByVal Value As Object)
                Session (Key) = Value
            End Set
        End Property

        ''' --- RemoveGlobalSession ------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Deletes the global session key.
        ''' </summary>
        ''' <param name="Key"></param>
        ''' <remarks>
        '''     This property sets/returns session information for a specific key.  
        ''' </remarks>
        ''' <history>
        ''' 	[GlennA]	13/Sep/2007	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Browsable (False), _
            EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Sub RemoveGlobalSession (ByVal Key As String)
            Session.Remove (Key)
        End Sub

        ''' --- Language -----------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Gets or sets the current language.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Always)> _
        Public Property Language() As String
            Get
                Return GlobalizationManager.SupportedLanguage
            End Get
            Set (ByVal Value As String)
                Session.Add ("Language", Value.ToLower)
            End Set
        End Property

        ''' --- CoreStyleSheet ------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Set or return the name of the custom stylesheet to use.
        ''' </summary>
        ''' <remarks>
        '''     This property sets/returns name of the stylesheet to use.
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	16/07/2007	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        Protected Property CoreStyleSheet() As String
            Get
                'Check if there is a Style Sheet flag in web.config
                If Not ConfigurationManager.AppSettings ("MultipleStyleSheets") Is Nothing Then
                    'If Custom style sheets have been enabled...
                    '(otherwise, the stylesheet used will be whatever has been set on the aspx form)
                    If ConfigurationManager.AppSettings ("MultipleStyleSheets") = "True" Then
                        'If style sheet session variable has been set modify the href setting on the aspx form
                        If Not GlobalSession ("CoreStyleSheet") Is Nothing Then
                            Return GlobalSession ("CoreStyleSheet")
                        Else
                            'style sheet session var has not been set; check if style sheet cookie has been set
                            If Not Request.Cookies ("CoreStyleSheet") Is Nothing Then
                                'Set style sheet session variable & modify the href setting on the aspx form
                                Dim styleSheet As String = Request.Cookies ("CoreStyleSheet").Value
                                GlobalSession ("CoreStyleSheet") = styleSheet
                                Return styleSheet
                            End If
                            'cookie exists
                        End If
                        'session var found
                    End If
                    'Multiple stylesheets flag set
                End If
                'Multiple stylesheets flag exists
                Return Nothing
            End Get
            Set (ByVal value As String)
                GlobalSession ("CoreStyleSheet") = value
            End Set
        End Property

        ''' --- SetGlobalizationManager --------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of SetGlobalizationManager.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Protected Sub SetGlobalizationManager()
            Dim strLanguage As String
            Dim strDefault As String = String.Empty
            Dim blnLangFound As Boolean = False
            Dim arrLanguage() As String

            If Session ("Language") Is Nothing Then
                If Request.UserLanguages Is Nothing Then
                    strLanguage = "en-ca"
                    ReDim arrLanguage(0)
                    arrLanguage (0) = "en-ca"
                    Session ("arrLanguage") = arrLanguage
                Else
                    strLanguage = Request.UserLanguages (0)

                    If Session ("arrLanguage") Is Nothing Then
                        LoadLanguage()
                    End If
                    arrLanguage = Session ("arrLanguage")
                    For i As Integer = 0 To UBound (arrLanguage)
                        If strDefault = "" Then
                            strDefault = arrLanguage (i)
                        End If
                        If arrLanguage (i).ToUpper = strLanguage.ToUpper Then blnLangFound = True
                    Next
                    If Not blnLangFound Then strLanguage = strDefault
                End If
                'GlobalizationManager = New GlobalizationManager (strLanguage)
                Language = strLanguage
                'language-culture
            Else
                'GlobalizationManager = New GlobalizationManager (Session ("Language").ToString)
            End If
        End Sub


        ''' --- SetCoreStyleSheet --------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Creates a cookie and session var containing name of StyleSheet to use.
        ''' 
        ''' </summary>
        ''' <remarks>
        ''' params:
        '''   - strStyleSheetName: FQP of stylesheet to use
        '''   - intDaysDuration: Life of cookie in days
        ''' </remarks>
        ''' <history>
        ''' 	[glenn]	17-jul-2007	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Function SetCoreStyleSheet (ByVal strStyleSheetName As String, ByVal intDaysDuration As Int16) As Boolean
            Dim myCookie As New HttpCookie ("CoreStyleSheet")

            myCookie.Value = strStyleSheetName
            '           myCookie.Expires = DateTime.Now.AddDays(intDaysDuration)
            myCookie.Expires = DateTime.Now.AddDays (intDaysDuration)
            Response.Cookies.Add (myCookie)
            Session ("CoreStyleSheet") = strStyleSheetName

            Return True

        End Function

        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Function DeleteCoreStyleSheet() As Boolean

            Response.Cookies ("CoreStyleSheet").Expires = DateTime.Now.AddDays (- 1)

            Return True

        End Function

        ''' --- RoleBasedMenus -------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of RoleBasedMenus.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Protected Function RoleBasedMenus() As Boolean
            If Not ConfigurationManager.AppSettings ("RoleBasedMenus") Is Nothing Then
                If ConfigurationManager.AppSettings ("RoleBasedMenus").ToString.ToUpper.Equals ("TRUE") Then
                    Return True
                Else
                    Return False
                End If
            End If
            Return False
        End Function

        ''' --- UserBasedMenus -------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of UserBasedMenus.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Protected Function UserBasedMenus() As Boolean
            If Not ConfigurationManager.AppSettings ("UserBasedMenus") Is Nothing Then
                If ConfigurationManager.AppSettings ("UserBasedMenus").ToString.ToUpper.Equals ("TRUE") Then
                    Return True
                Else
                    Return False
                End If
            End If
            Return False
        End Function

        ''' --- UserID -------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of UserID.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Protected Function UserID() As String

            Return SecurityManager.GetCurrentUser

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Returns the logged-on user's account if provided.
        ''' </summary>
        ''' <value></value>
        ''' <remarks>
        ''' </remarks>
        ''' <example>T_TEMP.Value = SignOnAccount()</example>
        ''' <history>
        ''' 	[mayur]	3/18/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Always)> _
        Protected ReadOnly Property SignOnAccount() As String
            Get
                Return SecurityManager.GetCurrentAccount
            End Get
        End Property

        ''' --- MenuRole -------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of MenuRole.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Protected Function MenuRole() As String

            If Not GlobalSession ("UserRoles") Is Nothing Then
                Return GlobalSession ("UserRoles").ToString.Split ("|") (0)
            Else
                Return String.Empty
            End If

        End Function

        ''' --- UserBelongsToRole -------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Returns a boolean indicating whether the user belongs to a specific role.
        ''' </summary>
        ''' <param name="Role">A string value naming the role to check.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Always)> _
        Public Function UserBelongsToRole (ByVal Role As String) As Boolean

            If Not GlobalSession ("UserRoles") Is Nothing Then
                Return ("|" & GlobalSession ("UserRoles").ToString & "|").IndexOf ("|" & Role & "|") > - 1
            Else
                Return False
            End If

        End Function

       

        

        ''' --- LoadLanguage -------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of LoadLanguage.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Protected Sub LoadLanguage()

            Dim _
                nvcLanguageSettings As NameValueCollection = _
                    ConfigurationManager.GetSection ("coreAppSettings/Dictionaries")
            With nvcLanguageSettings
                Dim arrLanguage(.Count - 1) As String
                For i As Integer = 0 To .Count - 1
                    arrLanguage (i) = nvcLanguageSettings.Keys.Item (i).ToString
                Next
                Session ("arrLanguage") = arrLanguage
            End With

        End Sub

        ''' --- GetString ----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetString.
        ''' </summary>
        ''' <param name="key"></param>
        ''' <param name="ResourceType"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Function GetString (ByVal key As String, _
                                   ByVal ResourceType As Global.Core.Globalization.Core.Globalization.ResourceTypes) _
            As String

            Return GlobalizationManager.GetString (key, ResourceType)

        End Function

        ''' --- AddMessage ---------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Adds a message to the messages collection.
        ''' </summary>
        ''' <param name="Message"></param>
        ''' <param name="Type"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Protected Friend Function AddMessage (ByVal Message As String, ByVal Type As MessageTypes) As String

            Dim strMessageNumber As String
            Dim strNumber As String = String.Empty
            Dim strMessage As String = String.Empty
            Dim intPosition As Integer
            Dim strSubstitution As String = String.Empty

            Try
                ' Determine if there is a substitution.
                intPosition = Message.IndexOf ("$")
                If intPosition > - 1 Then
                    strMessageNumber = Message.Substring (0, intPosition)
                    strSubstitution = Message.Substring (intPosition + 1)
                Else
                    strMessageNumber = Message
                End If

                ' Retrieve the message number.
                If Message.IndexOf ("MSG") > - 1 Then
                    strNumber = strMessageNumber.Substring (3)
                Else
                    strNumber = strMessageNumber
                End If

                ' Get the message from the resource file.
                If strMessageNumber.Trim.Length > 0 Then
                    strMessage = _
                        GetString (strMessageNumber, Global.Core.Framework.Core.Framework.ResourceTypes.Message)
                    If strMessage Is Nothing Then strMessage = ""
                End If

                ' Replace the substitution characters with the values.
                If Not strSubstitution Is Nothing Then
                    If strMessage.Length > 0 Then
                        Try
                            strMessage = String.Format (strMessage, strSubstitution.Split ("$"))
                        Catch ex As FormatException
                            strMessage = "Wrong number of substitution parameters."
                        Catch ex As Exception
                            strMessage = ex.Message
                        End Try
                    Else
                        strMessage = strSubstitution.Replace ("$", "")
                    End If
                End If

                If Type = MessageTypes.Error Then
                    'Me.HasError = True
                    Framework.ThrowCustomApplicationException(cAddMessageError, Type.ToString, strNumber, strMessage)
                End If

            Catch ex As CustomApplicationException

                Throw ex

            Catch ex As Exception

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish (ex)
                Throw ex

            End Try
            Return strMessage

        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Compares a string to a pattern.
        ''' </summary>
        ''' <param name="Value">A string of characters to compare against a pattern.</param>
        ''' <param name="Pattern">A string representing a specific pattern to match against the passed in value.</param>
        ''' <returns>A Boolean</returns>
        ''' <remarks>
        ''' Will return True, if the pattern matches the string and False, if not.
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	4/5/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Always)> _
        Protected Function MatchPattern (ByVal Value As String, ByVal Pattern As String) As Boolean

            Try
                Return EvalRegularExpressionAsPowerHousePattern (Value, GetRegularExpresssionPattern (Pattern))
            Catch ex As CustomApplicationException
                If ex.Message.Equals ("Invalid pattern!") Then 'IM.InvalidPattern
                    Return True
                Else
                    Throw ex
                End If
            End Try

        End Function

        ''' --- LanguageCode -------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Two Letter ISO Language Code property.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Browsable (False), _
            EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public ReadOnly Property LanguageCode() As String
            Get
                Return GlobalizationManager.LanguageCode
            End Get
        End Property

        ''' --- Page_Load ----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of Page_Load.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Private Sub Page_Load (ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            'CoreWebTrace("Page_Load", "Before SetGlobalizationManager")

            'Page level security checks
            'We use application page both in Menu and also in Default.aspx
            'In there is a new request and page's name is default.aspx, we bypass the redirection
            'Note: If this code ever need to change, also make similar changes
            'in Core.Windows.UI.Page's Load event handler
            Dim objSecurityManager As New SecurityManager
            If IsNothing (Session ("UserInfo")) OrElse Not objSecurityManager.CorrectIPAddress Then
                objSecurityManager.EnsureLogin()
            End If
            objSecurityManager = Nothing

            If Me.Request ("hidLang") <> "" Then
                Session ("Language") = Me.Request ("hidLang").ToLower
            End If
            SetGlobalizationManager()
            'CoreWebTrace("Page_Load", "After SetGlobalizationManager")
            'If m_blnLanguageChanged Then
            '    'TODO: whenver we change a language this hidden varibale should have valid language code from client itself
            '    'value containing Language-Culture e.g. en-ca
            '    Language = Me.Request("hidLang").ToLower
            '    SetGlobalizationManager()
            'End 

            'Get ref to aspx page
            If CoreBodyTag Is Nothing Then
                CoreBodyTag = CType (Me.FindControl ("BodyTag"), HtmlGenericControl)
            End If

        End Sub

        ''' --- LanguageChanged ----------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of LanguageChanged.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Browsable (False), _
            EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Property LanguageChanged() As Boolean
            Get
                Return m_blnLanguageChanged
            End Get
            Set (ByVal Value As Boolean)
                m_blnLanguageChanged = Value
            End Set
        End Property

        ''' --- Page ---------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of Page.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Shadows Property Page() As ApplicationPage
            Get
                Return MyBase.Page
            End Get
            Set (ByVal Value As ApplicationPage)
                MyBase.Page = Value
            End Set
        End Property

        ''' --- FormName -----------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Gets or sets the name of the current screen.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Always)> _
        Public Property FormName() As String
            Get
                Return m_strPageName
            End Get
            Set (ByVal Value As String)
                m_strPageName = Value
            End Set
        End Property

        ''' --- Level --------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Gets or sets the screen level for the current screen.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Browsable (False), _
            EditorBrowsable (EditorBrowsableState.Always)> _
        Public ReadOnly Property Level() As Integer
            Get
                If Me.m_intScreenLevel = - 1 Then
                    m_intScreenLevel = CInt (ViewState ("ScreenLevel"))
                    m_intNextScreenLevel = m_intScreenLevel + 1
                End If
                Return m_intScreenLevel
            End Get
        End Property

        ''' --- NextScreenLevel ----------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Screen Level for the Called Screen.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Browsable (False), _
            EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public ReadOnly Property NextScreenLevel() As Integer
            Get
                Return m_intNextScreenLevel
            End Get
        End Property

        Private Sub Page_PreRender (ByVal sender As Object, ByVal e As EventArgs) Handles Me.PreRender

            ' Check to see if we need to use a different style sheet.
            Dim customStyleSheet As String = CoreStyleSheet
            If Not customStyleSheet Is Nothing Then
                If Not CoreBodyTag Is Nothing Then
                    Dim strOldPageBodyOnloadTag2 As String = CoreBodyTag.Attributes ("onload")
                    Dim strCoreStyleSheetSetting = "StyleLink.href='" & AddVirtualPath() & customStyleSheet & "'; "
                    CoreBodyTag.Attributes ("onload") = strCoreStyleSheetSetting + strOldPageBodyOnloadTag2
                End If
            End If

        End Sub

        Protected Function AddVirtualPath() As String
            Dim count As Integer = 0
            Dim path As String = Request.Path
            If path.StartsWith ("/") Then path = path.Substring (1)

            count = path.Length - path.Replace ("/", "").Length - 1

            path = String.Empty
            For i As Integer = 1 To count
                path &= "../"
            Next
            Return path

        End Function
    End Class
End Namespace
