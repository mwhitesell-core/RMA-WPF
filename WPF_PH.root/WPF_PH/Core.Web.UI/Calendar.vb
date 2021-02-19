Option Strict On
Option Explicit On

Imports System.ComponentModel
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web
Imports System.Web.UI.Design
Imports System.Text
Imports System.IO

Namespace Core.Windows.UI
    ''' ----------------------------------------------------------------------------
    ''' 
    ''' Class	: Calendar
    ''' 
    ''' ----------------------------------------------------------------------------
    ''' <exclude />
    ''' 
    ''' <summary>
    ''' 	Summary of Calendar.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <Designer("Core.Windows.UI.CalendarDesigner, Core.Windows.UI"), _
        ToolboxItem(False), _
        ToolboxData("<{0}:Calendar runat=server></{0}:Calendar>"), _
        EditorBrowsable(EditorBrowsableState.Never)> _
    Public Class Calendar
        Inherits WebControl

        ''' --- AfterMonthShow -----------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of AfterMonthShow.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Never)> _
        Public Event AfterMonthShow As EventHandler

        ''' --- BeforeMonthShow ----------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of BeforeMonthShow.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Never)> _
        Public Event BeforeMonthShow As EventHandler

        ''' --- OnAfterMonthShow ---------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of OnAfterMonthShow.
        ''' </summary>
        ''' <param name="e"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Never)> _
        Protected Overridable Sub OnAfterMonthShow(ByVal e As EventArgs)
            RaiseEvent AfterMonthShow(Me, e)
        End Sub

        ''' --- OnBeforeMonthShow --------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of OnBeforeMonthShow.
        ''' </summary>
        ''' <param name="e"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Never)> _
        Protected Overridable Sub OnBeforeMonthShow(ByVal e As EventArgs)
            RaiseEvent BeforeMonthShow(Me, e)
        End Sub

        ''' --- CalendarLanguages --------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of CalendarLanguages.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Never)> _
        Enum CalendarLanguages
            [Default] = 0
            French = 1
            German = 2
            Dutch = 3
            Portuguese = 4
            Spanish = 5
            Swedish = 6
            English = 7
        End Enum

        Private Const sDoubleQuote As String = """"

        Private m_Height As Integer = 0
        Private m_MonthBackColor As String = ""
        Private m_ShowToday As Boolean = False
        Private m_HighlightTodayColor As String = ""
        Private m_Tag As String = ""
        Private m_TitleBackColor As String = ""
        Private m_TitleForeColor As String = ""
        Private m_TrailingForeColor As String = ""
        Private m_Width As Integer = 96
        Private m_RedirectURL As String = ""
        Private m_RedirectTarget As String = ""
        Private m_ForceDHTML As Boolean = False
        Private m_DHTML As String = ""
        Private m_NavDHTML As String = ""
        Private m_ForceNavDHTML As Boolean = False
        Private m_URL As String = ""
        Private m_Class As String = ""
        Private m_QueryString As String = ""
        Private m_StartDate As String = ""
        Private m_ComponentID As String = ""
        Private m_ImagePath As String = ""
        Private m_DateFormat As String = ""

        Private m_LanguageSetting As CalendarLanguages = CalendarLanguages.Default
        Private m_ViewSource As Boolean

        Private m_Source As String
        Private m_Visible As Boolean = True
        Private m_Position As String
        Private m_NavigateYears As Boolean
        Private m_AutoPostBack As Boolean
        Private m_RunWithinSession As Boolean
        Private Response As HtmlTextWriter
        Private Request As HttpRequest

        ''' --- RunWithinSession ---------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of RunWithinSession.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Description("Allows session objects to maintain state when used with the component."), _
            Category("Core"), _
            DefaultValue(False), _
            EditorBrowsable(EditorBrowsableState.Never)> _
        Public Property RunWithinSession() As Boolean
            Get
                Return m_RunWithinSession
            End Get
            Set(ByVal Value As Boolean)
                m_RunWithinSession = Value
            End Set
        End Property

        ''' --- AutoPostBack -------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of AutoPostBack.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Description("Allows posting of form fields possible on the component when set = True."), _
            Category("Core"), _
            DefaultValue(False), _
            EditorBrowsable(EditorBrowsableState.Never)> _
        Public Property AutoPostBack() As Boolean
            Get
                Return m_AutoPostBack
            End Get
            Set(ByVal Value As Boolean)
                m_AutoPostBack = Value
            End Set
        End Property

        ''' --- NavigateYears ------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of NavigateYears.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Description("Adds Year Navigate to the Calendar as well as Month Navigation."), _
            Category("Core"), _
            DefaultValue(False), _
            EditorBrowsable(EditorBrowsableState.Never)> _
        Public Property NavigateYears() As Boolean
            Get
                Return m_NavigateYears
            End Get
            Set(ByVal Value As Boolean)
                m_NavigateYears = Value
            End Set
        End Property

        ''' --- Position -----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of Position.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Description("Sets the position of the whole Calendar."), _
            Category("Core"), _
            DefaultValue(""), _
            EditorBrowsable(EditorBrowsableState.Never)> _
        Public Property Position() As String
            Get
                Return m_Position
            End Get
            Set(ByVal Value As String)
                m_Position = Value
            End Set
        End Property

        ''' --- MonthVisible -------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of MonthVisible.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Description("Sets whether the Calendar is visible in the browser or not."), _
            Category("Core"), _
            DefaultValue(True), _
            EditorBrowsable(EditorBrowsableState.Never)> _
        Public Property MonthVisible() As Boolean
            Get
                Return m_Visible
            End Get
            Set(ByVal Value As Boolean)
                m_Visible = Value
            End Set
        End Property

        ''' --- LanguageSetting ----------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of LanguageSetting.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        < _
            Description _
                ( _
                 "Sets which language the Calendar should display. ( = 0 defaults to the regional settings on the server) Other options are: =1 (French) = 2 (German) = 3 (Dutch) = 4 (Portuguese) = 5 (Spanish) = 6 (Swedish) = 7 (English)."), _
            Category("Core"), _
            DefaultValue(GetType(CalendarLanguages), "Default"), _
            EditorBrowsable(EditorBrowsableState.Never)> _
        Public Property LanguageSetting() As CalendarLanguages
            Get
                Return m_LanguageSetting
            End Get
            Set(ByVal Value As CalendarLanguages)
                m_LanguageSetting = Value
            End Set
        End Property

        ''' --- QueryString --------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of QueryString.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Never)> _
        Public WriteOnly Property QueryString() As String
            Set(ByVal Value As String)
                If Trim(Value) <> "" Then
                    m_QueryString = m_QueryString & "&" & Value
                End If
            End Set
        End Property

        ''' --- ImagePath ----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of ImagePath.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Description("Sets the location of the folder where the images are to be used by the Calendar."), _
            Category("Core"), _
            DefaultValue(""), _
            EditorBrowsable(EditorBrowsableState.Never)> _
        Public Property ImagePath() As String
            Get
                Return m_ImagePath
            End Get
            Set(ByVal Value As String)
                m_ImagePath = Value
                If Len(m_ImagePath) > 0 Then
                    If Right(m_ImagePath, 1) <> "/" Then m_ImagePath = m_ImagePath & "/"
                End If
            End Set
        End Property

        ''' --- ComponentID --------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of ComponentID.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Description("Sets the ID of the Calendar so that it you can have more than one Calendar on one page."), _
            Category("Core"), _
            DefaultValue(""), _
            EditorBrowsable(EditorBrowsableState.Never)> _
        Public Property ComponentID() As String
            Get
                Return m_ComponentID
            End Get
            Set(ByVal Value As String)
                m_ComponentID = Value
            End Set
        End Property

        ''' --- HighlightTodayColor ------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of HighlightTodayColor.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Description("Sets the background color the Calendar uses on todays date."), _
            Category("Core"), _
            DefaultValue(""), _
            EditorBrowsable(EditorBrowsableState.Never)> _
        Public Property HighlightTodayColor() As String
            Get
                Return m_HighlightTodayColor
            End Get
            Set(ByVal Value As String)
                m_HighlightTodayColor = Value
            End Set
        End Property

        ''' --- ForceDHTML ---------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of ForceDHTML.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        < _
            Description _
                ( _
                 "Sets whether to only use the NavDHTML Property value and not the Calendars own link (URL) when Navigating Months/Years."), _
            Category("Core"), _
            DefaultValue(False), _
            EditorBrowsable(EditorBrowsableState.Never)> _
        Public Property ForceDHTML() As Boolean
            Get
                Return m_ForceDHTML
            End Get
            Set(ByVal Value As Boolean)
                m_ForceDHTML = Value
            End Set
        End Property

        ''' --- DHTML --------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of DHTML.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Description("Adds user defined DHTML to each Calendar day numbers."), _
            Category("Core"), _
            DefaultValue(""), _
            EditorBrowsable(EditorBrowsableState.Never)> _
        Public Property DHTML() As String
            Get
                Return m_DHTML
            End Get
            Set(ByVal Value As String)
                m_DHTML = Value
            End Set
        End Property

        ''' --- ForceNavDHTML ------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of ForceNavDHTML.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        < _
            Description _
                ( _
                 "Sets whether to only use the NavDHTML Property value and not the Calendars own link (URL) when Navigating Months/Years."), _
            Category("Core"), _
            DefaultValue(False), _
            EditorBrowsable(EditorBrowsableState.Never)> _
        Public Property ForceNavDHTML() As Boolean
            Get
                Return m_ForceNavDHTML
            End Get
            Set(ByVal Value As Boolean)
                m_ForceNavDHTML = Value
            End Set
        End Property

        ''' --- NavDHTML -----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of NavDHTML.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Description("Adds user defined DHTML to the navigation links on the Calendar."), _
            Category("Core"), _
            DefaultValue(""), _
            EditorBrowsable(EditorBrowsableState.Never)> _
        Public Property NavDHTML() As String
            Get
                Return m_NavDHTML
            End Get
            Set(ByVal Value As String)
                m_NavDHTML = Value
            End Set
        End Property

        ''' --- RedirectURL --------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of RedirectURL.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        < _
            Description _
                ( _
                 "Sets the URL to send the Calendar Date to when a date is selected. If left blank the URL is returned to the same page."), _
            Category("Core"), _
            DefaultValue(""), _
            EditorBrowsable(EditorBrowsableState.Never)> _
        Public Property RedirectURL() As String
            Get
                Return m_RedirectURL
            End Get
            Set(ByVal Value As String)
                m_RedirectURL = Value
            End Set
        End Property

        ''' --- RedirectTarget -----------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of RedirectTarget.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Description("Sets the Target Frame if any to send the RedirectURL Property (URL) to."), _
            Category("Core"), _
            DefaultValue(""), _
            EditorBrowsable(EditorBrowsableState.Never)> _
        Public Property RedirectTarget() As String
            Get
                Return m_RedirectTarget
            End Get
            Set(ByVal Value As String)
                m_RedirectTarget = Value
            End Set
        End Property

        ''' --- CssClass -----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of CssClass.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        < _
            Description _
                ( _
                 "Sets which stylesheet class name to use on the Calendar either from a .css file or inline within the asp page."), _
            Category("Core"), _
            DefaultValue(""), _
            EditorBrowsable(EditorBrowsableState.Never)> _
        Public Shadows Property CssClass() As String
            Get
                Return m_Class
            End Get
            Set(ByVal Value As String)
                m_Class = Value
            End Set
        End Property

        ''' --- MonthWidth ---------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of MonthWidth.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Description("Sets the default width of the Calendar."), _
            Category("Core"), _
            DefaultValue(180), _
            EditorBrowsable(EditorBrowsableState.Never)> _
        Public Property MonthWidth() As Integer
            Get
                Return m_Width
            End Get
            Set(ByVal Value As Integer)
                m_Width = Value
            End Set
        End Property

        ''' --- TrailingForeColor --------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of TrailingForeColor.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        < _
            Description _
                ("Sets the forecolor of the Calendars delta days section that represent trailing and leading months."), _
            Category("Core"), _
            DefaultValue(""), _
            EditorBrowsable(EditorBrowsableState.Never)> _
        Public Property TrailingForeColor() As String
            Get
                Return m_TrailingForeColor
            End Get
            Set(ByVal Value As String)
                m_TrailingForeColor = Value
            End Set
        End Property

        ''' --- TitleForeColor -----------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of TitleForeColor.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Description("Sets the foreground color of the Calendars Navigation section at the top."), _
            Category("Core"), _
            DefaultValue(""), _
            EditorBrowsable(EditorBrowsableState.Never)> _
        Public Property TitleForeColor() As String
            Get
                Return m_TitleForeColor
            End Get
            Set(ByVal Value As String)
                m_TitleForeColor = Value
            End Set
        End Property

        ''' --- TitleBackColor -----------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of TitleBackColor.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Description("Sets the background color of the Calendars Navigation section at the top."), _
            Category("Core"), _
            DefaultValue(""), _
            EditorBrowsable(EditorBrowsableState.Never)> _
        Public Property TitleBackColor() As String
            Get
                Return m_TitleBackColor
            End Get
            Set(ByVal Value As String)
                m_TitleBackColor = Value
            End Set
        End Property

        ''' --- Tag ----------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of Tag.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Description("This is used to hold generic data if required on the Calendar, for example a text description."), _
            Category("Core"), _
            DefaultValue(""), _
            EditorBrowsable(EditorBrowsableState.Never)> _
        Public Property Tag() As String
            Get
                Return m_Tag
            End Get
            Set(ByVal Value As String)
                m_Tag = Value
            End Set
        End Property

        ''' --- ShowToday ----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of ShowToday.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Description("When set = True displays todays date (clickable) at the bottom right of the Calendar."), _
            Category("Core"), _
            DefaultValue(False), _
            EditorBrowsable(EditorBrowsableState.Never)> _
        Public Property ShowToday() As Boolean
            Get
                Return m_ShowToday
            End Get
            Set(ByVal Value As Boolean)
                m_ShowToday = Value
            End Set
        End Property

        ''' --- MonthBackColor -----------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of MonthBackColor.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Description("Sets the BackColor of the whole Calendar."), _
            Category("Core"), _
            DefaultValue(""), _
            EditorBrowsable(EditorBrowsableState.Never)> _
        Public Property MonthBackColor() As String
            Get
                Return m_MonthBackColor
            End Get
            Set(ByVal Value As String)
                m_MonthBackColor = Value
            End Set
        End Property

        ''' --- MonthHeight --------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of MonthHeight.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Description("Sets the default height of the Calendar (Calendar.MonthHeight=0 will autosize itself)"), _
            Category("Core"), _
            DefaultValue(0), _
            EditorBrowsable(EditorBrowsableState.Never)> _
        Public Property MonthHeight() As Integer
            Get
                Return m_Height
            End Get
            Set(ByVal Value As Integer)
                m_Height = Value
            End Set
        End Property

        ''' --- StartDate ----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of StartDate.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Description("Sets the start date the Calendar should start on, if left blank the current month is displayed."), _
            Category("Core"), _
            DefaultValue(""), _
            EditorBrowsable(EditorBrowsableState.Never)> _
        Public Property StartDate() As String
            Get
                Return m_StartDate
            End Get
            Set(ByVal Value As String)
                m_StartDate = Value
            End Set
        End Property

        ''' --- DateFormat ---------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of DateFormat.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Description("Sets the return format of the date, if left blank the current culture date format is used."), _
            Category("Core"), _
            DefaultValue(""), _
            EditorBrowsable(EditorBrowsableState.Never)> _
        Public Property DateFormat() As String
            Get
                Return m_DateFormat
            End Get
            Set(ByVal Value As String)
                m_DateFormat = Value.ToLower.Replace("m", "M").Trim
            End Set
        End Property

        ''' --- Render -------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of Render.
        ''' </summary>
        ''' <param name="output"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Never)> _
        Protected Overrides Sub Render(ByVal output As HtmlTextWriter)
            Response = output
            Request = HttpContext.Current.Request
            If Not m_ViewSource Then
                If m_Position = "" Then
                    Call RenderPosition()
                End If
                Call Show()
                If Not m_RunWithinSession Then
                    Call Drop()
                End If
            End If
        End Sub

        ''' --- RenderPosition -----------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of RenderPosition.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Never)> _
        Private Sub RenderPosition()
            Dim sPositionTag As String
            Dim sLeftTag As String
            Dim sTopTag As String
            Dim sZIndexTag As String

            sPositionTag = Me.Style("POSITION")
            If (sPositionTag = "") Then
                sPositionTag = Me.Style("position")
            End If
            sLeftTag = Me.Style("LEFT")
            If (sLeftTag = "") Then
                sLeftTag = Me.Style("left")
            End If
            sTopTag = Me.Style("TOP")
            If (sTopTag = "") Then
                sTopTag = Me.Style("top")
            End If
            sZIndexTag = Me.Style("Z-INDEX")
            If (sZIndexTag = "") Then
                sZIndexTag = Me.Style("z-index")
            End If
            m_Position = ""

            If sPositionTag <> "" Or sZIndexTag <> "" Then
                If sZIndexTag <> "" Then
                    m_Position = m_Position & "z-index:" & sZIndexTag
                End If
                If sPositionTag <> "" Then
                    If sZIndexTag <> "" Then
                        m_Position = m_Position & "; "
                    End If
                    m_Position = m_Position & "position:" & sPositionTag
                End If
                If sLeftTag <> "" And sPositionTag <> "" Then
                    m_Position = m_Position & "; left:" & sLeftTag
                End If
                If sTopTag <> "" And sPositionTag <> "" Then
                    m_Position = m_Position & "; top:" & sTopTag
                End If
            End If

        End Sub

        ''' --- GetFormName --------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetFormName.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Never)> _
        Private Function GetFormName() As String
            If Parent.ID = "" Then
                Return "_ctl0"
            Else
                Return Parent.ID
            End If
        End Function

        ''' --- ViewSource ---------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of ViewSource.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Never)> _
        Public Function ViewSource() As String
            m_ViewSource = True
            Request = HttpContext.Current.Request
            If m_Position = "" Then
                Call RenderPosition()
            End If
            Call Show()
            ViewSource = m_Source
            If Not m_RunWithinSession Then
                Call Drop()
            End If
        End Function

        ''' --- Show ---------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of Show.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Never)> _
        Private Sub Show()

            Dim x As Integer

            If m_ViewSource Then
                If Not m_Visible Then
                    m_Source = "<div id=mv_vis style=" & sDoubleQuote & "display:none" & sDoubleQuote & ">"
                Else
                    m_Source = "<div id=mv_vis >"
                End If
                If m_Position <> "" Then
                    m_Source = m_Source & "<div id=mv_pos style=" & sDoubleQuote & m_Position & sDoubleQuote & ">"
                Else
                    m_Source = m_Source & "<div id=mv_pos >"
                End If
            Else
                If Not m_Visible Then
                    Response.Write("<div id=mv_vis style=" & sDoubleQuote & "display:none" & sDoubleQuote & ">")
                Else
                    Response.Write("<div id=mv_vis >")
                End If
                If m_Position <> "" Then
                    Response.Write("<div id=mv_pos style=" & sDoubleQuote & m_Position & sDoubleQuote & ">")
                Else
                    Response.Write("<div id=mv_pos >")
                End If
            End If

            m_URL = Request.ServerVariables("URL")
            For x = Len(m_URL) To 1 Step -1
                If Mid(m_URL, x, 1) = "/" Then
                    m_URL = Right(m_URL, Len(m_URL) - x)
                    Exit For
                End If
            Next

            x = InStr(1, Request.ServerVariables("HTTP_USER_AGENT"), "Opera")
            If x <> 0 Then
                If m_LanguageSetting = CalendarLanguages.Default Then m_LanguageSetting = CalendarLanguages.English
            End If

            Call CreateMonthView()

            If m_ViewSource Then
                m_Source = m_Source & "</div>"
                m_Source = m_Source & "</div>"
            Else
                Response.Write("</div>")
                Response.Write("</div>")
            End If

        End Sub

        ''' --- GetDaysInMonth -----------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetDaysInMonth.
        ''' </summary>
        ''' <param name="lMonth"></param>
        ''' <param name="lYear"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Never)> _
        Private Function GetDaysInMonth(ByVal lMonth As Integer, ByVal lYear As Integer) As Integer

            Return Date.DaysInMonth(lYear, lMonth)

        End Function

        ''' --- SubtractOneMonth ---------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of SubtractOneMonth.
        ''' </summary>
        ''' <param name="dDate"></param>
        ''' <param name="vDay"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Never)> _
        Private Function SubtractOneMonth(ByVal dDate As Date, Optional ByVal vDay As Integer = 0) As String

            Dim deltaDays As Integer
            If vDay <> 0 Then
                deltaDays = vDay - Day(dDate)
            Else
                deltaDays = 0
            End If
            Return dDate.AddMonths(-1).AddDays(deltaDays).ToShortDateString

        End Function

        ''' --- AddOneMonth --------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of AddOneMonth.
        ''' </summary>
        ''' <param name="dDate"></param>
        ''' <param name="vDay"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Never)> _
        Private Function AddOneMonth(ByVal dDate As Date, Optional ByVal vDay As Integer = 0) As String

            Dim deltaDays As Integer
            If vDay <> 0 Then
                deltaDays = vDay - dDate.Day
            Else
                deltaDays = 0
            End If
            Return dDate.AddMonths(1).AddDays(deltaDays).ToShortDateString

        End Function

        ''' --- SubtractOneYear ----------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of SubtractOneYear.
        ''' </summary>
        ''' <param name="dDate"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Never)> _
        Private Function SubtractOneYear(ByVal dDate As Date) As String

            Return dDate.AddYears(-1).ToShortDateString

        End Function

        ''' --- AddOneYear ---------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of AddOneYear.
        ''' </summary>
        ''' <param name="dDate"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Never)> _
        Private Function AddOneYear(ByVal dDate As Date) As String

            Return dDate.AddYears(1).ToShortDateString

        End Function

        ''' --- CreateMonthView ----------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of CreateMonthView.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Never)> _
        Private Sub CreateMonthView()

            Dim dDate As Date
            Dim lDaysInMonth As Integer
            Dim lDaysOfWeek As Integer
            Dim lPosition As Integer
            Dim lCurrent As Integer
            Dim dSubDate As Date
            Dim lSubDays As Integer
            Dim sTarget As String = String.Empty
            Dim sDateCurrent As String
            Dim sHTML As New StringBuilder("")
            Dim sTodayColor As String = String.Empty
            Dim sTmpDHTML As String
            Dim x As Integer
            Dim sNavDHTML As String
            Dim sReturnDate As String

            If m_ComponentID = "" Then
                m_ComponentID = "MV"
            End If

            If IsDate(Request.QueryString(m_ComponentID)) Then
                dDate = CDate(Request.QueryString(m_ComponentID))
            Else
                If IsDate(m_StartDate) Then
                    dDate = CDate(m_StartDate)
                Else
                    dDate = Today
                End If
            End If

            If m_DateFormat.Length <> 0 Then
                QueryString = "DateFormat=" + m_DateFormat
            End If

            lDaysInMonth = GetDaysInMonth(dDate.Month, dDate.Year)
            lDaysOfWeek = New Date(dDate.Year, dDate.Month, 1).DayOfWeek() + 1

            If m_MonthBackColor = "" Then
                m_MonthBackColor = "#FFFFFF"
            End If

            If m_TitleBackColor = "" Then
                m_TitleBackColor = "#C0C0C0"
            End If

            If m_TitleForeColor = "" Then
                m_TitleForeColor = "#000000"
            End If

            If m_TrailingForeColor = "" Then
                m_TrailingForeColor = "#C0C0C0"
            End If

            If m_RedirectURL = "" Then
                m_RedirectURL = m_URL
            End If

            If m_RedirectTarget <> "" Then
                sTarget = "TARGET=" & sDoubleQuote & m_RedirectTarget & sDoubleQuote
            End If

            If m_Width = 0 Then m_Width = 96

            If m_QueryString <> "" Then
                If Left(m_QueryString, 1) <> "&" Then
                    m_QueryString = "&" & m_QueryString
                End If
            End If

            ' calendar ready to render raise event if required.
            RaiseEvent BeforeMonthShow(Me, EventArgs.Empty)

            sHTML.Append("<TABLE WIDTH=").Append(sDoubleQuote).Append(m_Width).Append("%").Append(sDoubleQuote). _
                Append(" HEIGHT=").Append(sDoubleQuote).Append(m_Height).Append(sDoubleQuote).Append( _
                                                                                                          " BORDER=1 CELLPADDING=0 CELLSPACING=0  BORDERCOLOR=#C0C0C0>")
            sHTML.Append("<TR><TD>")

            sHTML.Append("<TABLE WIDTH=100% BORDER=0 HEIGHT=28 CELLPADDING=0 CELLSPACING=0 >")
            sHTML.Append("<TR BGCOLOR=").Append(sDoubleQuote).Append(m_TitleBackColor).Append(sDoubleQuote).Append( _
                                                                                                                        ">")

            sNavDHTML = Replace(m_NavDHTML, "#PAGE#", m_URL)
            sNavDHTML = _
                Replace(sNavDHTML, "#QUERYSTRING#", _
                         "?" & m_ComponentID & "=" & SubtractOneMonth(dDate) & m_QueryString)

            If m_ForceNavDHTML Then
                sHTML.Append("<TD ALIGN=CENTER WIDTH=30>")
                If m_NavigateYears Then
                    sHTML.Append("<A ID=mv_nav_").Append(SubtractOneYear(dDate)).Append(" CLASS=").Append( _
                                                                                                               sDoubleQuote) _
                        .Append(m_Class).Append(sDoubleQuote).Append(" ").Append(sNavDHTML).Append(" ><FONT COLOR=") _
                        .Append(sDoubleQuote).Append(m_TitleForeColor).Append(sDoubleQuote).Append( _
                                                                                                       "><B>&nbsp;<&nbsp;</B></FONT></A>")
                End If
                sHTML.Append("<A ID=mv_nav_").Append(SubtractOneMonth(dDate)).Append(" CLASS=").Append(sDoubleQuote) _
                    .Append(m_Class).Append(sDoubleQuote).Append(" ").Append(sNavDHTML).Append(" ><FONT COLOR="). _
                    Append(sDoubleQuote).Append(m_TitleForeColor).Append(sDoubleQuote).Append( _
                                                                                                  "><B>&nbsp;<&nbsp;</B></FONT></A>")
                sHTML.Append("</TD>")
            Else
                If m_AutoPostBack Then
                    sHTML.Append("<TD ALIGN=CENTER WIDTH=30>")
                    If m_NavigateYears Then
                        sHTML.Append("<A ID=mv_nav_").Append(SubtractOneYear(dDate)).Append(" CLASS=").Append( _
                                                                                                                   sDoubleQuote) _
                            .Append(m_Class).Append(sDoubleQuote).Append(" HREF=").Append(sDoubleQuote).Append( _
                                                                                                                    "javascript:document.") _
                            .Append(GetFormName()).Append(".action='").Append(m_URL).Append("?").Append( _
                                                                                                             m_ComponentID) _
                            .Append("=").Append(SubtractOneYear(dDate)).Append(m_QueryString).Append("';").Append( _
                                                                                                                        Page _
                                                                                                                           . _
                                                                                                                           ClientScript _
                                                                                                                           . _
                                                                                                                           GetPostBackEventReference( _
                                                                                                                                                      Me, _
                                                                                                                                                      "")) _
                            .Append(sDoubleQuote).Append(" ").Append(sNavDHTML).Append(" ><FONT COLOR=").Append( _
                                                                                                                     sDoubleQuote) _
                            .Append(m_TitleForeColor).Append(sDoubleQuote).Append("><B>&nbsp;<&nbsp;</B></FONT></A>")
                    End If
                    sHTML.Append("<A ID=mv_nav_").Append(SubtractOneMonth(dDate)).Append(" CLASS=").Append( _
                                                                                                                sDoubleQuote) _
                        .Append(m_Class).Append(sDoubleQuote).Append(" HREF=").Append(sDoubleQuote).Append( _
                                                                                                                "javascript:document.") _
                        .Append(GetFormName()).Append(".action='").Append(m_URL).Append("?").Append(m_ComponentID). _
                        Append("=").Append(SubtractOneMonth(dDate)).Append(m_QueryString).Append("';").Append( _
                                                                                                                    Page _
                                                                                                                       . _
                                                                                                                       ClientScript _
                                                                                                                       . _
                                                                                                                       GetPostBackEventReference( _
                                                                                                                                                  Me, _
                                                                                                                                                  "")) _
                        .Append(sDoubleQuote).Append(" ").Append(sNavDHTML).Append(" ><FONT COLOR=").Append( _
                                                                                                                 sDoubleQuote) _
                        .Append(m_TitleForeColor).Append(sDoubleQuote).Append("><B>&nbsp;<&nbsp;</B></FONT></A>")
                    sHTML.Append("</TD>")
                Else
                    sHTML.Append("<TD ALIGN=CENTER WIDTH=30>")
                    If m_NavigateYears Then
                        sHTML.Append("<A ID=mv_nav_").Append(SubtractOneYear(dDate)).Append(" CLASS=").Append( _
                                                                                                                   sDoubleQuote) _
                            .Append(m_Class).Append(sDoubleQuote).Append(" HREF=").Append(sDoubleQuote).Append( _
                                                                                                                    m_URL) _
                            .Append("?").Append(m_ComponentID).Append("=").Append(SubtractOneYear(dDate)).Append( _
                                                                                                                       m_QueryString) _
                            .Append(sDoubleQuote).Append(" ").Append(sNavDHTML).Append(" ><FONT COLOR=").Append( _
                                                                                                                     sDoubleQuote) _
                            .Append(m_TitleForeColor).Append(sDoubleQuote).Append("><B>&nbsp;<&nbsp;</B></FONT></A>")
                    End If
                    sHTML.Append("<A ID=mv_nav_").Append(SubtractOneMonth(dDate)).Append(" CLASS=").Append( _
                                                                                                                sDoubleQuote) _
                        .Append(m_Class).Append(sDoubleQuote).Append(" HREF=").Append(sDoubleQuote).Append(m_URL). _
                        Append("?").Append(m_ComponentID).Append("=").Append(SubtractOneMonth(dDate)).Append( _
                                                                                                                   m_QueryString) _
                        .Append(sDoubleQuote).Append(" ").Append(sNavDHTML).Append(" ><FONT COLOR=").Append( _
                                                                                                                 sDoubleQuote) _
                        .Append(m_TitleForeColor).Append(sDoubleQuote).Append("><B>&nbsp;<&nbsp;</B></FONT></A>")
                    sHTML.Append("</TD>")
                End If
            End If

            sHTML.Append("<TD CLASS=").Append(sDoubleQuote).Append(m_Class).Append(sDoubleQuote).Append( _
                                                                                                             " ALIGN=CENTER WIDTH=") _
                .Append(sDoubleQuote).Append(m_Width - 31).Append("%").Append(sDoubleQuote).Append( _
                                                                                                        "><B><FONT COLOR=") _
                .Append(sDoubleQuote).Append(m_TitleForeColor).Append(sDoubleQuote).Append(">").Append( _
                                                                                                            ForceMonthName( _
                                                                                                                            dDate _
                                                                                                                               . _
                                                                                                                               Month)) _
                .Append(" ").Append(dDate.Year).Append("</FONT></B></TD>")

            sNavDHTML = Replace(m_NavDHTML, "#PAGE#", m_URL)
            sNavDHTML = _
                Replace(sNavDHTML, "#QUERYSTRING#", "?" & m_ComponentID & "=" & AddOneMonth(dDate) & m_QueryString)

            If m_ForceNavDHTML Then
                sHTML.Append("<TD ALIGN=CENTER WIDTH=30>")
                sHTML.Append("<A ID=mv_nav_").Append(AddOneMonth(dDate)).Append(" CLASS=").Append(sDoubleQuote). _
                    Append(m_Class).Append(sDoubleQuote).Append(" ").Append(sNavDHTML).Append(" ><FONT COLOR="). _
                    Append(sDoubleQuote).Append(m_TitleForeColor).Append(sDoubleQuote).Append( _
                                                                                                  "><B>&nbsp;>&nbsp;</B></FONT></A>")
                If m_NavigateYears Then
                    sHTML.Append("<A ID=mv_nav_").Append(AddOneYear(dDate)).Append(" CLASS=").Append(sDoubleQuote). _
                        Append(m_Class).Append(sDoubleQuote).Append(" ").Append(sNavDHTML).Append(" ><FONT COLOR=") _
                        .Append(sDoubleQuote).Append(m_TitleForeColor).Append(sDoubleQuote).Append( _
                                                                                                       "><B>&nbsp;>&nbsp;</B></FONT></A>")
                End If
                sHTML.Append("</TD>")
            Else
                If m_AutoPostBack Then
                    sHTML.Append("<TD ALIGN=CENTER WIDTH=30>")
                    sHTML.Append("<A ID=mv_nav_").Append(AddOneMonth(dDate)).Append(" CLASS=").Append(sDoubleQuote) _
                        .Append(m_Class).Append(sDoubleQuote).Append(" HREF=").Append(sDoubleQuote).Append( _
                                                                                                                "javascript:document.") _
                        .Append(GetFormName()).Append(".action='").Append(m_URL).Append("?").Append(m_ComponentID). _
                        Append("=").Append(AddOneMonth(dDate)).Append(m_QueryString).Append("';").Append( _
                                                                                                               Page. _
                                                                                                                  ClientScript _
                                                                                                                  . _
                                                                                                                  GetPostBackEventReference( _
                                                                                                                                             Me, _
                                                                                                                                             "")) _
                        .Append(sDoubleQuote).Append(" ").Append(sNavDHTML).Append(" ><FONT COLOR=").Append( _
                                                                                                                 sDoubleQuote) _
                        .Append(m_TitleForeColor).Append(sDoubleQuote).Append("><B>&nbsp;>&nbsp;</B></FONT></A>")
                    If m_NavigateYears Then
                        sHTML.Append("<A ID=mv_nav_").Append(AddOneYear(dDate)).Append(" CLASS=").Append( _
                                                                                                              sDoubleQuote) _
                            .Append(m_Class).Append(sDoubleQuote).Append(" HREF=").Append(sDoubleQuote).Append( _
                                                                                                                    "javascript:document.") _
                            .Append(GetFormName()).Append(".action='").Append(m_URL).Append("?").Append( _
                                                                                                             m_ComponentID) _
                            .Append("=").Append(AddOneYear(dDate)).Append(m_QueryString).Append("';").Append( _
                                                                                                                   Page. _
                                                                                                                      ClientScript _
                                                                                                                      . _
                                                                                                                      GetPostBackEventReference( _
                                                                                                                                                 Me, _
                                                                                                                                                 "")) _
                            .Append(sDoubleQuote).Append(" ").Append(sNavDHTML).Append(" ><FONT COLOR=").Append( _
                                                                                                                     sDoubleQuote) _
                            .Append(m_TitleForeColor).Append(sDoubleQuote).Append("><B>&nbsp;>&nbsp;</B></FONT></A>")
                    End If
                    sHTML.Append("</TD>")
                Else
                    sHTML.Append("<TD ALIGN=CENTER WIDTH=30>")
                    sHTML.Append("<A ID=mv_nav_").Append(AddOneMonth(dDate)).Append(" CLASS=").Append(sDoubleQuote) _
                        .Append(m_Class).Append(sDoubleQuote).Append(" HREF=").Append(sDoubleQuote).Append(m_URL). _
                        Append("?").Append(m_ComponentID).Append("=").Append(AddOneMonth(dDate)).Append( _
                                                                                                              m_QueryString) _
                        .Append(sDoubleQuote).Append(" ").Append(sNavDHTML).Append(" ><FONT COLOR=").Append( _
                                                                                                                 sDoubleQuote) _
                        .Append(m_TitleForeColor).Append(sDoubleQuote).Append("><B>&nbsp;>&nbsp;</B></FONT></A>")
                    If m_NavigateYears Then
                        sHTML.Append("<A ID=mv_nav_").Append(AddOneYear(dDate)).Append(" CLASS=").Append( _
                                                                                                              sDoubleQuote) _
                            .Append(m_Class).Append(sDoubleQuote).Append(" HREF=").Append(sDoubleQuote).Append( _
                                                                                                                    m_URL) _
                            .Append("?").Append(m_ComponentID).Append("=").Append(AddOneYear(dDate)).Append( _
                                                                                                                  m_QueryString) _
                            .Append(sDoubleQuote).Append(" ").Append(sNavDHTML).Append(" ><FONT COLOR=").Append( _
                                                                                                                     sDoubleQuote) _
                            .Append(m_TitleForeColor).Append(sDoubleQuote).Append("><B>&nbsp;>&nbsp;</B></FONT></A>")
                    End If
                    sHTML.Append("</TD>")
                End If
            End If

            sHTML.Append("</TR>")
            sHTML.Append("</TABLE>")
            sHTML.Append("<TABLE BGCOLOR=").Append(m_MonthBackColor).Append(" WIDTH=100% HEIGHT=").Append( _
                                                                                                              sDoubleQuote) _
                .Append(m_Height - 50).Append(sDoubleQuote).Append(" BORDER=0 CELLPADDING=0 CELLSPACING=1 >")
            sHTML.Append("<TR>")

            sHTML.Append("<TD CLASS=").Append(sDoubleQuote).Append(m_Class).Append(sDoubleQuote).Append( _
                                                                                                             " ALIGN=CENTER><FONT COLOR=") _
                .Append(sDoubleQuote).Append(m_TitleBackColor).Append(sDoubleQuote).Append(">").Append( _
                                                                                                            ForceDayName( _
                                                                                                                          1)) _
                .Append("</FONT></TD>")
            sHTML.Append("<TD CLASS=").Append(sDoubleQuote).Append(m_Class).Append(sDoubleQuote).Append( _
                                                                                                             " ALIGN=CENTER><FONT COLOR=") _
                .Append(sDoubleQuote).Append(m_TitleBackColor).Append(sDoubleQuote).Append(">").Append( _
                                                                                                            ForceDayName( _
                                                                                                                          2)) _
                .Append("</FONT></TD>")
            sHTML.Append("<TD CLASS=").Append(sDoubleQuote).Append(m_Class).Append(sDoubleQuote).Append( _
                                                                                                             " ALIGN=CENTER><FONT COLOR=") _
                .Append(sDoubleQuote).Append(m_TitleBackColor).Append(sDoubleQuote).Append(">").Append( _
                                                                                                            ForceDayName( _
                                                                                                                          3)) _
                .Append("</FONT></TD>")
            sHTML.Append("<TD CLASS=").Append(sDoubleQuote).Append(m_Class).Append(sDoubleQuote).Append( _
                                                                                                             " ALIGN=CENTER><FONT COLOR=") _
                .Append(sDoubleQuote).Append(m_TitleBackColor).Append(sDoubleQuote).Append(">").Append( _
                                                                                                            ForceDayName( _
                                                                                                                          4)) _
                .Append("</FONT></TD>")
            sHTML.Append("<TD CLASS=").Append(sDoubleQuote).Append(m_Class).Append(sDoubleQuote).Append( _
                                                                                                             " ALIGN=CENTER><FONT COLOR=") _
                .Append(sDoubleQuote).Append(m_TitleBackColor).Append(sDoubleQuote).Append(">").Append( _
                                                                                                            ForceDayName( _
                                                                                                                          5)) _
                .Append("</FONT></TD>")
            sHTML.Append("<TD CLASS=").Append(sDoubleQuote).Append(m_Class).Append(sDoubleQuote).Append( _
                                                                                                             " ALIGN=CENTER><FONT COLOR=") _
                .Append(sDoubleQuote).Append(m_TitleBackColor).Append(sDoubleQuote).Append(">").Append( _
                                                                                                            ForceDayName( _
                                                                                                                          6)) _
                .Append("</FONT></TD>")
            sHTML.Append("<TD CLASS=").Append(sDoubleQuote).Append(m_Class).Append(sDoubleQuote).Append( _
                                                                                                             " ALIGN=CENTER><FONT COLOR=") _
                .Append(sDoubleQuote).Append(m_TitleBackColor).Append(sDoubleQuote).Append(">").Append( _
                                                                                                            ForceDayName( _
                                                                                                                          7)) _
                .Append("</FONT></TD>")
            sHTML.Append("</TR>")
            sHTML.Append("<TR>")

            If m_ViewSource Then
                m_Source = sHTML.ToString()
            Else
                Response.Write(sHTML.ToString())
            End If
            sHTML.Length = 0

            If lDaysOfWeek <> 1 Then
                lPosition = 1
                dSubDate = CDate(SubtractOneMonth(dDate))
                lSubDays = GetDaysInMonth(dSubDate.Month, dSubDate.Year)
                lSubDays = lSubDays - lDaysOfWeek + 2
                Do While lPosition < lDaysOfWeek
                    If m_AutoPostBack And (Not m_ForceNavDHTML) Then
                        sHTML.Append("<TD CLASS=").Append(sDoubleQuote).Append(m_Class).Append(sDoubleQuote).Append( _
                                                                                                                         " ALIGN=CENTER><A STYLE=") _
                            .Append(sDoubleQuote).Append("text-decoration:none").Append(sDoubleQuote).Append( _
                                                                                                                 " HREF=") _
                            .Append(sDoubleQuote).Append("javascript:document.").Append(GetFormName()).Append( _
                                                                                                                  ".action='") _
                            .Append(m_URL).Append("?").Append(m_ComponentID).Append("=").Append( _
                                                                                                     SubtractOneMonth( _
                                                                                                                       dDate, _
                                                                                                                       lSubDays)) _
                            .Append(m_QueryString).Append("';").Append( _
                                                                          Page.ClientScript.GetPostBackEventReference( _
                                                                                                                       Me, _
                                                                                                                       "")) _
                            .Append(sDoubleQuote).Append("><FONT COLOR=").Append(sDoubleQuote).Append( _
                                                                                                          m_TrailingForeColor) _
                            .Append(sDoubleQuote).Append(">").Append(lSubDays).Append("</FONT></A></TD>")
                    Else
                        sHTML.Append("<TD CLASS=").Append(sDoubleQuote).Append(m_Class).Append(sDoubleQuote).Append( _
                                                                                                                         " ALIGN=CENTER><A STYLE=") _
                            .Append(sDoubleQuote).Append("text-decoration:none").Append(sDoubleQuote).Append( _
                                                                                                                 " HREF=") _
                            .Append(sDoubleQuote).Append(m_URL).Append("?").Append(m_ComponentID).Append("="). _
                            Append(SubtractOneMonth(dDate, lSubDays)).Append(m_QueryString).Append(sDoubleQuote). _
                            Append("><FONT COLOR=").Append(sDoubleQuote).Append(m_TrailingForeColor).Append( _
                                                                                                                sDoubleQuote) _
                            .Append(">").Append(lSubDays).Append("</FONT></A></TD>")
                    End If
                    lPosition = lPosition + 1
                    lSubDays = lSubDays + 1
                Loop
            End If

            If Trim(m_HighlightTodayColor) <> "" Then
                sTodayColor = " BGCOLOR=" & m_HighlightTodayColor
            End If
            If m_ShowToday Then
                x = InStr(1, Request.ServerVariables("HTTP_USER_AGENT"), "Nav")
                If x = 0 Then
                    sTodayColor = sTodayColor & " WIDTH=26 BACKGROUND=" & m_ImagePath & "mv_today.gif "
                End If
            End If

            ' start on the first day of the month
            Dim currentDate As Date
            currentDate = DateAdd(DateInterval.Day, 1 - dDate.Day, dDate)

            lCurrent = 1
            lPosition = lDaysOfWeek
            Do While lCurrent <= lDaysInMonth
                If lPosition = 1 Then
                    sHTML.Append("<TR>")
                End If

                ' convert current date to string and push date forward a day
                sDateCurrent = _
                    currentDate.ToString( _
                                          UI.Page.GetDefaultDateFormat.Replace("D", "d").Replace("m", "M").Replace( _
                                                                                                                      "Y", _
                                                                                                                      "y"))
                If m_DateFormat.Length <> 0 Then
                    sReturnDate = Format(currentDate, m_DateFormat)
                Else
                    sReturnDate = sDateCurrent
                End If
                currentDate = DateAdd(DateInterval.Day, 1, currentDate)

                sTmpDHTML = ""
                sTmpDHTML = Replace(m_DHTML, "#MV#", sReturnDate)
                sTmpDHTML = Replace(sTmpDHTML, "#PAGE#", m_URL)
                sTmpDHTML = _
                    Replace(sTmpDHTML, "#QUERYSTRING#", "?" & m_ComponentID & "=" & sDateCurrent & m_QueryString)

                If m_ForceDHTML Then
                    If lCurrent = Today.Day And dDate.Month = Today.Month And dDate.Year = Today.Year Then
                        sHTML.Append("<TD ").Append(sTodayColor).Append(" ALIGN=CENTER><A ID=mv_").Append( _
                                                                                                              sDateCurrent) _
                            .Append(" CLASS=").Append(sDoubleQuote).Append(m_Class).Append(sDoubleQuote).Append(" ") _
                            .Append(sTmpDHTML).Append(" >").Append(lCurrent).Append("</A></TD>")
                    Else
                        sHTML.Append("<TD ALIGN=CENTER><A ID=mv_").Append(sDateCurrent).Append(" CLASS=").Append( _
                                                                                                                     sDoubleQuote) _
                            .Append(m_Class).Append(sDoubleQuote).Append(" ").Append(sTmpDHTML).Append(" >").Append( _
                                                                                                                          lCurrent) _
                            .Append("</A></TD>")
                    End If
                Else
                    If m_AutoPostBack Then
                        If lCurrent = Today.Day And dDate.Month = Today.Month And dDate.Year = Today.Year Then
                            sHTML.Append("<TD ").Append(sTodayColor).Append(" ALIGN=CENTER><A ID=mv_").Append( _
                                                                                                                  sDateCurrent) _
                                .Append(" CLASS=").Append(sDoubleQuote).Append(m_Class).Append(sDoubleQuote).Append( _
                                                                                                                         " ") _
                                .Append(sTarget).Append(" HREF=").Append(sDoubleQuote).Append("javascript:document.") _
                                .Append(GetFormName()).Append(".action='").Append(m_RedirectURL).Append("?").Append( _
                                                                                                                         m_ComponentID) _
                                .Append("=").Append(sDateCurrent).Append(m_QueryString).Append("';").Append( _
                                                                                                                 Page. _
                                                                                                                    ClientScript _
                                                                                                                    . _
                                                                                                                    GetPostBackEventReference( _
                                                                                                                                               Me, _
                                                                                                                                               "")) _
                                .Append(sDoubleQuote).Append(" ").Append(sTmpDHTML).Append(" >").Append(lCurrent). _
                                Append("</A></TD>")
                        Else
                            sHTML.Append("<TD ALIGN=CENTER><A ID=mv_").Append(sDateCurrent).Append(" CLASS=").Append( _
                                                                                                                         sDoubleQuote) _
                                .Append(m_Class).Append(sDoubleQuote).Append(" ").Append(sTarget).Append(" HREF="). _
                                Append(sDoubleQuote).Append("javascript:document.").Append(GetFormName()).Append( _
                                                                                                                     ".action='") _
                                .Append(m_RedirectURL).Append("?").Append(m_ComponentID).Append("=").Append( _
                                                                                                                 sDateCurrent) _
                                .Append(m_QueryString).Append("';").Append( _
                                                                              Page.ClientScript. _
                                                                                 GetPostBackEventReference(Me, "")). _
                                Append(sDoubleQuote).Append(" ").Append(sTmpDHTML).Append(" >").Append(lCurrent). _
                                Append("</A></TD>")
                        End If
                    Else
                        If lCurrent = Today.Day And dDate.Month = Today.Month And dDate.Year = Today.Year Then
                            sHTML.Append("<TD ").Append(sTodayColor).Append(" ALIGN=CENTER><A ID=mv_").Append( _
                                                                                                                  sDateCurrent) _
                                .Append(" CLASS=").Append(sDoubleQuote).Append(m_Class).Append(sDoubleQuote).Append( _
                                                                                                                         " ") _
                                .Append(sTarget).Append(" HREF=").Append(sDoubleQuote).Append(m_RedirectURL).Append( _
                                                                                                                         "?") _
                                .Append(m_ComponentID).Append("=").Append(sDateCurrent).Append(m_QueryString).Append( _
                                                                                                                          sDoubleQuote) _
                                .Append(" ").Append(sTmpDHTML).Append(" >").Append(lCurrent).Append("</A></TD>")
                        Else
                            sHTML.Append("<TD ALIGN=CENTER><A ID=mv_").Append(sDateCurrent).Append(" CLASS=").Append( _
                                                                                                                         sDoubleQuote) _
                                .Append(m_Class).Append(sDoubleQuote).Append(" ").Append(sTarget).Append(" HREF="). _
                                Append(sDoubleQuote).Append(m_RedirectURL).Append("?").Append(m_ComponentID).Append( _
                                                                                                                         "=") _
                                .Append(sDateCurrent).Append(m_QueryString).Append(sDoubleQuote).Append(" ").Append( _
                                                                                                                         sTmpDHTML) _
                                .Append(" >").Append(lCurrent).Append("</A></TD>")
                        End If
                    End If
                End If

                If lPosition = 7 Then
                    sHTML.Append("</TR>")
                    lPosition = 0
                End If
                lCurrent = lCurrent + 1
                lPosition = lPosition + 1
            Loop

            If m_ViewSource Then
                m_Source = m_Source & sHTML.ToString()
            Else
                Response.Write(sHTML.ToString())
            End If
            sHTML.Length = 0

            If lPosition <> 1 Then
                lCurrent = 1
                Do While lPosition <= 7
                    If m_AutoPostBack And (Not m_ForceNavDHTML) Then
                        sHTML.Append("<TD CLASS=").Append(sDoubleQuote).Append(m_Class).Append(sDoubleQuote).Append( _
                                                                                                                         " ALIGN=CENTER><A STYLE=") _
                            .Append(sDoubleQuote).Append("text-decoration:none").Append(sDoubleQuote).Append( _
                                                                                                                 " HREF=") _
                            .Append(sDoubleQuote).Append("javascript:document.").Append(GetFormName()).Append( _
                                                                                                                  ".action='") _
                            .Append(m_URL).Append("?").Append(m_ComponentID).Append("=").Append( _
                                                                                                     AddOneMonth(dDate, _
                                                                                                                  lCurrent)) _
                            .Append(m_QueryString).Append("';").Append( _
                                                                          Page.ClientScript.GetPostBackEventReference( _
                                                                                                                       Me, _
                                                                                                                       "")) _
                            .Append(sDoubleQuote).Append("><FONT COLOR=").Append(sDoubleQuote).Append( _
                                                                                                          m_TrailingForeColor) _
                            .Append(sDoubleQuote).Append(">").Append(lCurrent).Append("</FONT></A></TD>")
                    Else
                        sHTML.Append("<TD CLASS=").Append(sDoubleQuote).Append(m_Class).Append(sDoubleQuote).Append( _
                                                                                                                         " ALIGN=CENTER><A STYLE=") _
                            .Append(sDoubleQuote).Append("text-decoration:none").Append(sDoubleQuote).Append( _
                                                                                                                 " HREF=") _
                            .Append(sDoubleQuote).Append(m_URL).Append("?").Append(m_ComponentID).Append("="). _
                            Append(AddOneMonth(dDate, lCurrent)).Append(m_QueryString).Append(sDoubleQuote).Append( _
                                                                                                                        "><FONT COLOR=") _
                            .Append(sDoubleQuote).Append(m_TrailingForeColor).Append(sDoubleQuote).Append(">"). _
                            Append(lCurrent).Append("</FONT></A></TD>")
                    End If
                    lPosition = lPosition + 1
                    lCurrent = lCurrent + 1
                Loop
                sHTML.Append("</TR>")
            End If

            sHTML.Append("</TABLE>")
            If m_ShowToday Then
                sHTML.Append("<TABLE BGCOLOR=").Append(m_MonthBackColor).Append( _
                                                                                   " WIDTH=100% BORDER=0 CELLPADDING=0 CELLSPACING=2 >")
                sHTML.Append("<TR>")
                sHTML.Append("<TD CLASS=").Append(sDoubleQuote).Append(m_Class).Append(sDoubleQuote).Append( _
                                                                                                                 " ALIGN=RIGHT><A STYLE=") _
                    .Append(sDoubleQuote).Append("text-decoration:none").Append(sDoubleQuote).Append(" HREF="). _
                    Append(sDoubleQuote).Append(m_URL).Append("?").Append(m_ComponentID).Append("=").Append( _
                                                                                                                  Today. _
                                                                                                                     ToShortDateString) _
                    .Append(m_QueryString).Append(sDoubleQuote).Append("><FONT COLOR=").Append(sDoubleQuote).Append( _
                                                                                                                         "#000000") _
                    .Append(sDoubleQuote).Append("><B>").Append(ForceTodayName()).Append("&nbsp;").Append( _
                                                                                                               Today. _
                                                                                                                  ToShortDateString) _
                    .Append("&nbsp;</B></FONT></A></TD>")
                sHTML.Append("</TR>")
                sHTML.Append("</TABLE>")
            End If
            sHTML.Append("</TD></TR>")
            sHTML.Append("</TABLE>")

            If m_ViewSource Then
                m_Source = m_Source & sHTML.ToString()
            Else
                Response.Write(sHTML.ToString())
            End If
            sHTML.Length = 0

            ' calendar rendered raise event if required.
            RaiseEvent AfterMonthShow(Me, EventArgs.Empty)

        End Sub

        ''' --- ForceMonthName -----------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of ForceMonthName.
        ''' </summary>
        ''' <param name="lMonth"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Never)> _
        Private Function ForceMonthName(ByRef lMonth As Integer) As String

            ForceMonthName = String.Empty

            Select Case m_LanguageSetting
                Case CalendarLanguages.Default
                    ForceMonthName = MonthName(lMonth)
                Case CalendarLanguages.French
                    Select Case lMonth
                        Case 1
                            ForceMonthName = "Janvier"
                        Case 2
                            ForceMonthName = "Février"
                        Case 3
                            ForceMonthName = "Mars"
                        Case 4
                            ForceMonthName = "Avril"
                        Case 5
                            ForceMonthName = "Mai"
                        Case 6
                            ForceMonthName = "Juin"
                        Case 7
                            ForceMonthName = "Juillet"
                        Case 8
                            ForceMonthName = "Août"
                        Case 9
                            ForceMonthName = "Septembre"
                        Case 10
                            ForceMonthName = "Octobre"
                        Case 11
                            ForceMonthName = "Novembre"
                        Case 12
                            ForceMonthName = "Décembre"
                    End Select
                Case CalendarLanguages.German
                    Select Case lMonth
                        Case 1
                            ForceMonthName = "Januar"
                        Case 2
                            ForceMonthName = "Febuar"
                        Case 3
                            ForceMonthName = "März"
                        Case 4
                            ForceMonthName = "April"
                        Case 5
                            ForceMonthName = "Mai"
                        Case 6
                            ForceMonthName = "Juni"
                        Case 7
                            ForceMonthName = "Juli"
                        Case 8
                            ForceMonthName = "August"
                        Case 9
                            ForceMonthName = "September"
                        Case 10
                            ForceMonthName = "Oktober"
                        Case 11
                            ForceMonthName = "November"
                        Case 12
                            ForceMonthName = "Dezember"
                    End Select
                Case CalendarLanguages.Dutch
                    Select Case lMonth
                        Case 1
                            ForceMonthName = "Januari"
                        Case 2
                            ForceMonthName = "Febuari"
                        Case 3
                            ForceMonthName = "Maart"
                        Case 4
                            ForceMonthName = "April"
                        Case 5
                            ForceMonthName = "Mei"
                        Case 6
                            ForceMonthName = "Juni"
                        Case 7
                            ForceMonthName = "Juli"
                        Case 8
                            ForceMonthName = "Augustus"
                        Case 9
                            ForceMonthName = "September"
                        Case 10
                            ForceMonthName = "Oktober"
                        Case 11
                            ForceMonthName = "November"
                        Case 12
                            ForceMonthName = "December"
                    End Select
                Case CalendarLanguages.Portuguese
                    Select Case lMonth
                        Case 1
                            ForceMonthName = "Janeiro"
                        Case 2
                            ForceMonthName = "Fevereiro"
                        Case 3
                            ForceMonthName = "Março"
                        Case 4
                            ForceMonthName = "Abril"
                        Case 5
                            ForceMonthName = "Maio"
                        Case 6
                            ForceMonthName = "Junho"
                        Case 7
                            ForceMonthName = "Julho"
                        Case 8
                            ForceMonthName = "Agosto"
                        Case 9
                            ForceMonthName = "Setembro"
                        Case 10
                            ForceMonthName = "Outubro"
                        Case 11
                            ForceMonthName = "Novembro"
                        Case 12
                            ForceMonthName = "Dezembro"
                    End Select
                Case CalendarLanguages.Spanish
                    Select Case lMonth
                        Case 1
                            ForceMonthName = "Enero"
                        Case 2
                            ForceMonthName = "Febrero"
                        Case 3
                            ForceMonthName = "Marzo"
                        Case 4
                            ForceMonthName = "Abril"
                        Case 5
                            ForceMonthName = "Mayo"
                        Case 6
                            ForceMonthName = "Junio"
                        Case 7
                            ForceMonthName = "Julio"
                        Case 8
                            ForceMonthName = "Agosto"
                        Case 9
                            ForceMonthName = "Septiembre"
                        Case 10
                            ForceMonthName = "Outubre"
                        Case 11
                            ForceMonthName = "Noviembre"
                        Case 12
                            ForceMonthName = "Diciembre"
                    End Select
                Case CalendarLanguages.Swedish
                    Select Case lMonth
                        Case 1
                            ForceMonthName = "Januari"
                        Case 2
                            ForceMonthName = "Februari"
                        Case 3
                            ForceMonthName = "Mars"
                        Case 4
                            ForceMonthName = "April"
                        Case 5
                            ForceMonthName = "Maj"
                        Case 6
                            ForceMonthName = "Juni"
                        Case 7
                            ForceMonthName = "Juli"
                        Case 8
                            ForceMonthName = "Augusti"
                        Case 9
                            ForceMonthName = "September"
                        Case 10
                            ForceMonthName = "Oktober"
                        Case 11
                            ForceMonthName = "November"
                        Case 12
                            ForceMonthName = "December"
                    End Select
                Case CalendarLanguages.English
                    Select Case lMonth
                        Case 1
                            ForceMonthName = "January"
                        Case 2
                            ForceMonthName = "February"
                        Case 3
                            ForceMonthName = "March"
                        Case 4
                            ForceMonthName = "April"
                        Case 5
                            ForceMonthName = "May"
                        Case 6
                            ForceMonthName = "June"
                        Case 7
                            ForceMonthName = "July"
                        Case 8
                            ForceMonthName = "August"
                        Case 9
                            ForceMonthName = "September"
                        Case 10
                            ForceMonthName = "October"
                        Case 11
                            ForceMonthName = "November"
                        Case 12
                            ForceMonthName = "December"
                    End Select
            End Select
            Return ForceMonthName
        End Function

        ''' --- ForceDayName -------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of ForceDayName.
        ''' </summary>
        ''' <param name="lDay"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Never)> _
        Private Function ForceDayName(ByRef lDay As Integer) As String

            Select Case m_LanguageSetting
                Case CalendarLanguages.Default
                    ForceDayName = WeekdayName(lDay, True)
                Case CalendarLanguages.English
                    Select Case lDay
                        Case 2
                            ForceDayName = "Mon"
                        Case 3
                            ForceDayName = "Tue"
                        Case 4
                            ForceDayName = "Wed"
                        Case 5
                            ForceDayName = "Thu"
                        Case 6
                            ForceDayName = "Fri"
                        Case 7
                            ForceDayName = "Sat"
                        Case 1
                            ForceDayName = "Sun"
                    End Select
                Case CalendarLanguages.French, CalendarLanguages.Spanish
                    Select Case lDay
                        Case 2
                            ForceDayName = "Lun"
                        Case 3
                            ForceDayName = "Mar"
                        Case 4
                            ForceDayName = "Mer"
                        Case 5
                            ForceDayName = "Jeu"
                        Case 6
                            ForceDayName = "Ven"
                        Case 7
                            ForceDayName = "Sam"
                        Case 1
                            ForceDayName = "Dim"
                    End Select
                Case CalendarLanguages.German
                    Select Case lDay
                        Case 2
                            ForceDayName = "M"
                        Case 3
                            ForceDayName = "D"
                        Case 4
                            ForceDayName = "M"
                        Case 5
                            ForceDayName = "D"
                        Case 6
                            ForceDayName = "F"
                        Case 7
                            ForceDayName = "S"
                        Case 1
                            ForceDayName = "S"
                    End Select
                Case CalendarLanguages.Dutch
                    Select Case lDay
                        Case 2
                            ForceDayName = "M"
                        Case 3
                            ForceDayName = "D"
                        Case 4
                            ForceDayName = "W"
                        Case 5
                            ForceDayName = "D"
                        Case 6
                            ForceDayName = "V"
                        Case 7
                            ForceDayName = "Z"
                        Case 1
                            ForceDayName = "Z"
                    End Select
                Case CalendarLanguages.Portuguese
                    Select Case lDay
                        Case 2
                            ForceDayName = "S"
                        Case 3
                            ForceDayName = "T"
                        Case 4
                            ForceDayName = "Q"
                        Case 5
                            ForceDayName = "Q"
                        Case 6
                            ForceDayName = "S"
                        Case 7
                            ForceDayName = "S"
                        Case 1
                            ForceDayName = "D"
                    End Select
                Case CalendarLanguages.Swedish
                    Select Case lDay
                        Case 2
                            ForceDayName = "M"
                        Case 3
                            ForceDayName = "T"
                        Case 4
                            ForceDayName = "O"
                        Case 5
                            ForceDayName = "T"
                        Case 6
                            ForceDayName = "F"
                        Case 7
                            ForceDayName = "L"
                        Case 1
                            ForceDayName = "S"
                    End Select
            End Select
            Return Nothing
        End Function

        ''' --- ForceTodayName -----------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of ForceTodayName.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Never)> _
        Private Function ForceTodayName() As String

            Select Case m_LanguageSetting
                Case CalendarLanguages.Default, CalendarLanguages.English
                    Return "Today"
                Case CalendarLanguages.French
                    Return "Aujourd 'hui"
                Case CalendarLanguages.Spanish
                    Return "Hoy"
                Case CalendarLanguages.German
                    Return "Heute"
                Case CalendarLanguages.Dutch
                    Return "Vandaag"
                Case CalendarLanguages.Portuguese
                    Return "Hoje"
                Case CalendarLanguages.Swedish
                    Return "Idag"
            End Select
            Return Nothing
        End Function

        ''' --- KeepComponent ------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of KeepComponent.
        ''' </summary>
        ''' <param name="ComponentID"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Never)> _
        Public Sub KeepComponent(ByRef ComponentID As String)

            Dim sComID As String
            sComID = ComponentID
            Request = HttpContext.Current.Request
            If Trim(sComID) = "" Then Exit Sub
            If Trim(m_QueryString) <> "" Then
                If Right(m_QueryString, 1) <> "&" Then
                    m_QueryString = m_QueryString & "&"
                End If
            End If

            m_QueryString = m_QueryString & sComID & "=" & Request.QueryString(sComID)

        End Sub

        ''' --- Drop ---------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of Drop.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Never)> _
        Private Sub Drop()
            Response = Nothing
            Request = Nothing
            Dispose()
        End Sub

        ''' --- Class_Initialize_Renamed -------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of Class_Initialize_Renamed.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Never)> _
        Private Sub Class_Initialize_Renamed()
            m_Visible = True
            m_Width = 96
            m_Height = 0
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' <exclude />
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
        <EditorBrowsable(EditorBrowsableState.Never)> _
        Public Sub New()
            MyBase.New()
            Class_Initialize_Renamed()

        End Sub
    End Class

    ''' ----------------------------------------------------------------------------
    ''' 
    ''' Class	: CalendarDesigner
    ''' 
    ''' ----------------------------------------------------------------------------
    ''' <exclude />
    ''' 
    ''' <summary>
    ''' 	Summary of CalendarDesigner.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(EditorBrowsableState.Never)> _
    Public Class CalendarDesigner
        Inherits ControlDesigner


    End Class
End Namespace
