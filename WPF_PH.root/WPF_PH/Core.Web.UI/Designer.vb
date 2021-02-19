#Region "  Imports  "

Imports System.ComponentModel
Imports Core.Framework.Core.Framework
Imports System.Drawing.Design
Imports System.Xml
Imports System.Windows.Controls
Imports System.Windows.Visibility
Imports System.Windows.Media
Imports System.Windows.Threading


#End Region

Namespace Core.Windows.UI
    ''' ----------------------------------------------------------------------------
    ''' 
    ''' Class	: Designer
    ''' 
    ''' ----------------------------------------------------------------------------
    ''' 
    ''' <summary>
    ''' 	The designer class is a hyperlink control used to trigger the execution
    '''     of a method with the associated name.  
    ''' </summary>
    ''' <remarks>
    ''' The designer control is used to initiate the execution of a method within
    ''' the screen.  This method can be used to open lower-level screens or as a means
    ''' to perform specific processing.
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(EditorBrowsableState.Always)>
    Public Class Designer
        Inherits Button

        Private m_strAcceptVerbList As String = ""
        Private m_blnCurrentControlState As Boolean = False
        Private m_alCurrentControlsSetToReadOnly As ArrayList
        Private m_NoData As Boolean
        Private m_InActive As Boolean
        Private m_blnExecuteDefaultClick As Boolean = True
        Private m_blnLoadState As Boolean = True
        Private m_triKeepEditButtonEnabledInGrid As Microsoft.VisualBasic.TriState = Microsoft.VisualBasic.TriState.UseDefault
        Private m_triKeepDeleteButtonEnabledInGrid As Microsoft.VisualBasic.TriState = Microsoft.VisualBasic.TriState.UseDefault
        Private m_intResetDesignerMode As ResetDesigner = ResetDesigner.InSamePostBack
        Private m_blnCurrentDesigner As Boolean = False
        Private m_blnIsNumberedDesigner As Boolean = False
        Private m_blnNoDesigner As Boolean = False
        ' Used to ensure that these designers are hidden at runtime.
        Private m_blnIsFunctionKey As Boolean = False
        Private m_blnHasPostCommand As Boolean = False
        Private m_blnIsSubScreen As Boolean = False
        ' Indicates that this designer is a SubScreen.
        Private m_AlignText As AlignText = Global.Core.Framework.Core.Framework.AlignText.NotSet
        Private m_blnDefaultFirstRowInGrid As Boolean
        Private m_blnDisableDesigners As Boolean
        Private m_blnDisableControls As Boolean
        Private m_bytFunctionKeys As FunctionKeys = FunctionKeys.NotSet

        'm_blnClicked variable is used as a flag to determine whether RaiseClick is executed or not
        'Please note, we are not storing m_blnClicked in ViewState 
        Private m_blnClicked As Boolean = False
        Protected Friend m_intDesignerClickStatus As DesignerStatus = DesignerStatus.NotClicked
        Protected Friend m_intCurrentItemIndex As Integer
        'Used in Grid and Composite screen







        ''' --- BeforeClick --------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Code to be executed Before the main Click event is called.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Event BeforeClick(ByVal sender As Designer, ByRef CancelDesignerClick As Boolean,
                              ByVal e As DesignerEventArgs)

        ''' --- PreCommands --------------------------------------------------------
        ''' 
        ''' <summary>
        ''' This event is used to execute specific logic prior to executing the current 
        ''' click event.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Event PreCommands(ByVal sender As Object, ByVal e As EventArgs)

        ''' --- PostCommands -------------------------------------------------------
        ''' 
        ''' <summary>
        ''' This event is used to execute specific logic upon successful completion of the 
        ''' click event.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Event PostCommands(ByVal sender As Object, ByVal e As EventArgs)

        'Shadowed so that we can raise event through RaiseClick method
        '
        'Note: Unlike standard .Net Click events, this click event will be fired
        'During Base Page's Load Event. This is done to avoid extra code to Save/Retrieve State and
        'this is also necessary for a Grid/Composite screen in which grid controls gets
        'prepared for display from Base Page's PerformOperationMethod
        ''' --- Click --------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' This event handles the clicking of the designer link.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Shadows Event Click(ByVal sender As Object, ByVal e As EventArgs)



        ''' --- IsNumberedDesigner -------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Identifies this designer as a numbered designer associated with a control or group of controls.
        ''' </summary>
        ''' <remarks>This property is required to ensure that numbered designers (for fields) are hidden at runtime.
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False),
            Browsable(True),
            Description _
                ("Identifies this designer as a numbered designer associated with a control or group of controls."),
            Category("Core"),
            DefaultValue(False),
            EditorBrowsable(EditorBrowsableState.Always)>
        Public Property IsNumberedDesigner() As Boolean
            Get
                Return m_blnIsNumberedDesigner
            End Get
            Set(ByVal Value As Boolean)
                m_blnIsNumberedDesigner = Value
            End Set
        End Property

        Public Property NoDesigner() As Boolean
            Get
                Return m_blnNoDesigner
            End Get
            Set(ByVal Value As Boolean)
                m_blnNoDesigner = Value
            End Set
        End Property

        ''' --- IsFunctionKey -------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Identifies this designer as a functon key.
        ''' </summary>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False),
            Browsable(True),
            Description("Identifies this designer as a function key."),
            Category("Core"),
            DefaultValue(False),
            EditorBrowsable(EditorBrowsableState.Always)>
        Public Property IsFunctionKey() As Boolean
            Get
                Return m_blnIsFunctionKey
            End Get
            Set(ByVal Value As Boolean)
                m_blnIsFunctionKey = Value
            End Set
        End Property

        ''' --- HasPostCommand -------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Set to True if a PostCommand is coded.
        ''' </summary>
        ''' <history>
        ''' 	[Chris]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False),
            Browsable(True),
            Description("Set to True if a PostCommand is coded."),
            Category("Core"),
            DefaultValue(False),
            EditorBrowsable(EditorBrowsableState.Always)>
        Public Property HasPostCommand() As Boolean
            Get
                Return m_blnHasPostCommand
            End Get
            Set(ByVal Value As Boolean)
                m_blnHasPostCommand = Value
            End Set
        End Property

        ''' --- IsSubScreen --------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Identifies this designer as a designer associated to a SubScreen.
        ''' </summary>
        ''' <remarks>This property is used to determine when to enable or disable this control.  
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False),
            Browsable(True),
            Description("Identifies this designer as a SubScreen."),
            Category("Core"),
            DefaultValue(False),
            EditorBrowsable(EditorBrowsableState.Always)>
        Public Property IsSubScreen() As Boolean
            Get
                Return m_blnIsSubScreen
            End Get
            Set(ByVal Value As Boolean)
                m_blnIsSubScreen = Value
            End Set
        End Property


        ''' --- AlignText --------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Identifies this designer as a designer associated to a SubScreen.
        ''' </summary>
        ''' <remarks>This property is used to determine when to enable or disable this control.  
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False),
            Browsable(True),
            Description("Aligns the Text"),
            Category("Core"),
            DefaultValue(False),
            EditorBrowsable(EditorBrowsableState.Always)>
        Public Property AlignText() As AlignText
            Get
                Return m_AlignText
            End Get
            Set(ByVal Value As AlignText)
                m_AlignText = Value
            End Set
        End Property


        ''' --- AcceptVerbList -----------------------------------------------------
        ''' 
        ''' <summary>
        '''  If the screen's property UseAcceptProcessing is set to False, and a Designer method prompts for input from the user using the Accept method, then 
        ''' this property should be set to include a semi-colon separated list of fields that are prompted for.  This will ensure that these fields are enabled.
        '''  This property has no effect when UseAcceptProcessing is set to True.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <example>
        ''' dsrDesigner_GO.AcceptVerbList = "fldEMPLOYEE_EMPLOYEE_ID;fldEMPLOYEE_EMPLOYEE_NAME"
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False),
            Browsable(True),
            Description("The list of controls on the form for which there is ACCEPT verb processing."),
            Category("Core"),
            DefaultValue(""),
            EditorBrowsable(EditorBrowsableState.Always)>
        Public Property AcceptVerbList() As String
            Get
                Return m_strAcceptVerbList
            End Get
            Set(ByVal Value As String)
                m_strAcceptVerbList = Value
            End Set
        End Property

        ''' --- DisableOtherControls -----------------------------------------------
        ''' 
        ''' <summary>
        ''' Gets or sets a boolean value indicating that other controls are to be disabled while running a Designer method that has Accept method calls.
        ''' </summary>
        ''' <remarks>This property has no effect when UseAcceptProcessing is set to True.  When set to False, if there is an AcceptVerbList specified, this property will return True.
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False),
            Browsable(True),
            Description _
                (
                 "Specifies if the other controls are disabled. Note: If there is AcceptVerbList specified, it will always return True, otherwise it returns False by default."),
            Category("Core"),
            DefaultValue(False),
            EditorBrowsable(EditorBrowsableState.Always)>
        Public Property DisableOtherControls() As Boolean
            Get
                ' Only disable other controls when NOT in AcceptProcessing.
                If not IsNothing(ApplicationState.Current.CorePage) andalso Not ApplicationState.Current.CorePage.UseAcceptProcessing Then
                    If m_strAcceptVerbList.Trim <> "" Then
                        Return True
                        'Always disable other controls if there is Accepted Verb List
                    End If
                End If

                Return m_blnDisableControls
            End Get
            Set(ByVal Value As Boolean)
                m_blnDisableControls = Value
            End Set
        End Property

        ''' --- KeepEditButtonEnabledInGrid ----------------------------------------
        ''' 
        ''' <summary>
        ''' 	Sets the state for the Edit Button In Grid after running a designer.
        ''' </summary>
        ''' <remarks>Setting True enables Edit Button after running the associated code for 
        ''' the designer. Setting False disables the Edit buttons in grid after running asscotiated 
        ''' code with designer. Use Default leaves the Edit Button in a same mode as it was 
        ''' before running the Designer Code.
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Browsable(True),
            Description _
                (
                 "Setting True enables Edit Button after running the associated code for the designer. Setting False disables the Edit buttons in grid after running asscotiated code with designer. Use Default leaves the Edit Button in a same mode as it was before running the Designer Code."),
            Category("Core"),
            DefaultValue(GetType(Microsoft.VisualBasic.TriState), "UseDefault"),
            EditorBrowsable(EditorBrowsableState.Always)>
        Public Property KeepEditButtonEnabledInGrid() As Microsoft.VisualBasic.TriState
            Get
                Return m_triKeepEditButtonEnabledInGrid
            End Get
            Set(ByVal Value As Microsoft.VisualBasic.TriState)
                m_triKeepEditButtonEnabledInGrid = Value
            End Set
        End Property

        ''' --- ResetDesignerMode --------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' ResetDesignerMode only applies to screens where UseAcceptProcessing is set to False.
        ''' The following are possible values and its effect on screens using when UseAcceptProcessing is False.
        ''' OnSubmit = Once set, stays in Designer mode, untill Submit or Cancel is pressed.
        ''' InSamePostBack = Reset in same postback, suitable for designer that only performs some business logic and does not prompt for values.
        ''' InNextPostBack - Presently not available.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Browsable(True),
            Description("Reset Designer Mode"),
            Category("Core"),
            DefaultValue(GetType(ResetDesigner), "InSamePostBack"),
            EditorBrowsable(EditorBrowsableState.Always)>
        Public Property ResetDesignerMode() As ResetDesigner
            'Note: At present "InNextPostBack" is not used. However in future it will reset the Designer Mode in next postback, may be, suitable for designers that executes Run Screen
            Get
                Return m_intResetDesignerMode
            End Get
            Set(ByVal Value As ResetDesigner)
                m_intResetDesignerMode = Value
            End Set
        End Property

        ''' --- KeepDeleteButtonEnabledInGrid --------------------------------------
        ''' 
        ''' <summary>
        ''' 	Sets the state for the Delete Button In Grid after running a designer.
        ''' </summary>
        ''' <remarks>Setting True enables Delete Button after running the associated code 
        ''' for the designer. Setting False disables the Delete buttons in grid after running 
        ''' associated code with designer. Use Default leaves the Delete Button in a same mode 
        ''' as it was before running the Designer Code.
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Browsable(True),
            Description _
                (
                 "Setting True enables Delete Button after running the associated code for the designer. Setting False disables the Delete buttons in grid after running asscotiated code with designer. Use Default leaves the Delete Button in a same mode as it was before running the Designer Code."),
            Category("Core"),
            DefaultValue(GetType(Microsoft.VisualBasic.TriState), "UseDefault"),
            EditorBrowsable(EditorBrowsableState.Always)>
        Public Property KeepDeleteButtonEnabledInGrid() As Microsoft.VisualBasic.TriState
            Get
                Return m_triKeepDeleteButtonEnabledInGrid
            End Get
            Set(ByVal Value As Microsoft.VisualBasic.TriState)
                m_triKeepDeleteButtonEnabledInGrid = Value
            End Set
        End Property

        ''' --- NoData -------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Gets or sets a boolean indicating that this Designer will be enabled even
        ''' if there is no data on the screen.
        ''' </summary>
        ''' <remarks>
        ''' The NoData option ensures that this Designer control will be enabled even when
        ''' there is no data on the screen (ie. the user doesn't have to perform a Find or
        ''' enter a new record prior to accessing this control).
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False),
            Browsable(True),
            Description("Selects the NODATA option for this Designer"),
            Category("Core"),
            DefaultValue(False),
            EditorBrowsable(EditorBrowsableState.Always)>
        Public Property NoData() As Boolean
            Get
                Return m_NoData
            End Get
            Set(ByVal Value As Boolean)
                m_NoData = Value
            End Set
        End Property

        ''' --- InActive -------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Disables the Designer.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False),
            Browsable(True),
            Description("Disables the Designer"),
            Category("Core"),
            DefaultValue(False),
            EditorBrowsable(EditorBrowsableState.Always)>
        Public Property InActive() As Boolean
            Get
                Return m_InActive
            End Get
            Set(ByVal Value As Boolean)
                m_InActive = Value
            End Set
        End Property

        ' Set ExecuteDefaultClick to True to handle enabling and disabling Controls on the page
        ' set ExecuteDefaultClick to False to override the default behaviour 
        ''' --- ExecuteDefaultClick ------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of ExecuteDefaultClick.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False),
            Browsable(True),
            Description("Determines whether to excute default Click event handler code or not"),
            Category("Core"),
            DefaultValue(True),
            EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Property ExecuteDefaultClick() As Boolean
            Get
                Return m_blnExecuteDefaultClick
            End Get
            Set(ByVal Value As Boolean)
                m_blnExecuteDefaultClick = Value
            End Set
        End Property

        ''' --- CurrentControlReadOnlyState ----------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of CurrentControlReadOnlyState.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False),
            Browsable(False),
            DefaultValue(False),
            EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Property CurrentControlReadOnlyState() As Boolean
            Get
                Return m_blnCurrentControlState
            End Get
            Set(ByVal Value As Boolean)
                m_blnCurrentControlState = Value

                Dim array As String() = m_strAcceptVerbList.Split(";")


                Dim control As Control

                'For Each control In Page.Controls
                '    SetCoreControls(control, array, Value)
                'Next
            End Set
        End Property

        ''' --- DisableOtherDesigners ----------------------------------------------
        ''' <summary>
        ''' Gets or sets a value indicating that all other designers will be disabled while executing the current Designer method.
        ''' </summary>
        ''' <remarks>If the screen's UseAcceptProcessing is set to False and the AcceptVerbList property has is specified, it will always return True, otherwise it returns False.
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False),
            Browsable(True),
            Description _
                (
                 "Specifies if the other designers are disabled. Note: If there is AcceptVerbList specified, it will always return True, otherwise it returns False by default."),
            Category("Core"),
            DefaultValue(False),
            EditorBrowsable(EditorBrowsableState.Always)>
        Public Property DisableOtherDesigners() As Boolean
            Get
                ' Only disable other designers when NOT in AcceptProcessing.
                If Not IsNothing(ApplicationState.Current) AndAlso Not ApplicationState.Current.CorePage.UseAcceptProcessing Then
                    If m_strAcceptVerbList.Trim <> "" Then
                        Return True
                        'Always disable other Designers if there is Accepted Verb List
                    End If
                End If

                Return m_blnDisableDesigners
            End Get
            Set(ByVal Value As Boolean)
                m_blnDisableDesigners = Value
            End Set
        End Property

        ''' --- DefaultFirstRowInGrid ----------------------------------------------
        ''' 
        ''' <summary>
        '''     Used to determine whether an instance of the designer operates on a row in the grid or not.
        ''' </summary>
        ''' <remarks>
        ''' <para>Not all designers will operate on grid/DataList as such, Setting DefaultFirstRowInGrid property 
        ''' to True will enable the first row in a grid whenever Designer is selected without
        ''' selecting a Row in a Grid/Composite Screen.</para>
        ''' This property is also used to determine whether an instance of the designer operates on grid or not.
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <
            Description _
                (
                 "Enables the first row in a grid whenever a designer is selected without selecting a Row in a Grid/Composite Screen. This property is now also used to determine whether the designer operates on grid or not"),
            Category("Core"),
            DefaultValue(False),
            EditorBrowsable(EditorBrowsableState.Always)>
        Public Property DefaultFirstRowInGrid() As Boolean
            Get
                Return m_blnDefaultFirstRowInGrid
            End Get
            Set(ByVal Value As Boolean)
                m_blnDefaultFirstRowInGrid = Value
            End Set
        End Property

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of a Designer.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Sub New()
            MyBase.New()
            Me.Content = Me.Name
            SetResourceReference(StyleProperty, "CoreDesignerStyle")
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of a Designer.
        ''' </summary>
        ''' <param name="LinkCommandName"></param>
        ''' <param name="LinkCommandArgument"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Sub New(ByVal LinkCommandName As String, ByVal LinkCommandArgument As String)

            MyBase.New()
            TabIndex = 0
            Content = Me.Name
            SetResourceReference(StyleProperty, "CoreDesignerStyle")
        End Sub


        Private Sub Blur() Handles Me.PreviewMouseLeftButtonUp

            If ApplicationState.Current.CorePage.HasError AndAlso ApplicationState.Current.CorePage.m_strRequestedControlFocusOverRide <> Me.Name Then
                Exit Sub
            End If

            If NoDesigner Then
                ApplicationState.Current.CorePage.PageActionObject = Me
            End If

            ApplicationState.Current.CorePage.NavigationType = NavigationTypes.None
            Dim dt As DispatcherTimer = New DispatcherTimer()
            AddHandler dt.Tick, AddressOf OnBlur
            dt.Interval = New TimeSpan(0, 0, 0, 0, 400)
            dt.Start()

        End Sub

        Private m_strToolTip As String
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)>
        Public Overloads Property ToolTip() As String
            Get
                Return m_strToolTip
            End Get
            Set(ByVal Value As String)
                'MyBase.ToolTip = Value
                m_strToolTip = Value
                If m_strToolTip.Length = 0 Then
                    SetValue(ToolTipService.IsEnabledProperty, False)
                Else
                    SetValue(ToolTipService.IsEnabledProperty, True)
                End If
            End Set
        End Property

        Public Sub OnBlur(sender As Object, e As EventArgs)
            Dim dt = TryCast(sender, DispatcherTimer)
            If dt IsNot Nothing Then
                dt.[Stop]()
            End If
            dt = Nothing

            ApplicationState.Current.CorePage.PageActionType = PageActionType.DesignerClick
            ApplicationState.Current.CorePage.Page_Load(Me)
        End Sub
        ''' --- Designer_PreRender -------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of Designer_PreRender.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Sub Designer_PreRender() Handles Me.Loaded

            If ApplicationState.Current.CorePage Is Nothing Then Return

            ' If we have a numbered designer, then make it invisible.
            If IsNumberedDesigner Then
                Me.Visibility = Collapsed
            End If

            If ApplicationState.Current.CorePage.HasErrorInFind Then

                ' If we have an error in the Find procedure (other than "No Records Found", then
                ' make the controls read only.
                Me.IsEnabled = False

            Else

                If Me.InActive Then
                    Me.IsEnabled = False
                Else
                    If NoData Then

                        If _
                            ApplicationState.Current.CorePage.Mode = PageModeTypes.Find OrElse
                            (ApplicationState.Current.CorePage.UseAcceptProcessing AndAlso (ApplicationState.Current.CorePage.Mode = PageModeTypes.Entry)) Then
                            Me.IsEnabled = False
                        Else
                            Me.IsEnabled = True
                        End If

                    ElseIf _
                        (ApplicationState.Current.CorePage.Mode = PageModeTypes.Change OrElse
                         ((Not ApplicationState.Current.CorePage.UseAcceptProcessing AndAlso ApplicationState.Current.CorePage.Mode = PageModeTypes.Entry) OrElse
                          (ApplicationState.Current.CorePage.UseAcceptProcessing AndAlso ApplicationState.Current.CorePage.Mode = PageModeTypes.Correct))) Then
                        Me.IsEnabled = True
                    Else
                        Me.IsEnabled = False
                    End If

                    ' If we are running a procedure, don't enable designers until the procedure
                    ' has finished executing.  
                    If Not ApplicationState.Current.CorePage.EnableNumberedDesigners AndAlso ApplicationState.Current.CorePage.UseAcceptProcessing Then
                        IsEnabled = False
                    End If

                    If IsFunctionKey Then
                        IsEnabled = True
                    End If
                End If



            End If
            ' If Page.HasErrorInFind

            If IsEnabled Then
                If FunctionKey <> FunctionKeys.NotSet Then
                    ApplicationState.Current.CorePage.SetFunctionKeyForDesigner(FunctionKey - 1, Me.Name)
                End If

            Else
                If FunctionKey <> FunctionKeys.NotSet Then
                    ApplicationState.Current.CorePage.SetFunctionKeyForDesigner(FunctionKey - 1, String.Empty)
                End If

            End If


            If Not IsNothing(Framework.Core.Windows.Framework.ApplicationState.Current.designersecurity) AndAlso
                Framework.Core.Windows.Framework.ApplicationState.Current.designersecurity.Contains(ApplicationState.Current.CorePage.FormName) Then

                If DirectCast(Framework.Core.Windows.Framework.ApplicationState.Current.designersecurity(ApplicationState.Current.CorePage.FormName), Hashtable).Contains(Me.Name.Replace("dsrDesigner_", "")) Then

                    If DirectCast(Framework.Core.Windows.Framework.ApplicationState.Current.designersecurity(ApplicationState.Current.CorePage.FormName), Hashtable)(Me.Name.Replace("dsrDesigner_", "")) = 0 Then
                        IsEnabled = False
                    End If
                End If

            End If


        End Sub

        ''' --- SetCoreControls ----------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of SetCoreControls.
        ''' </summary>
        ''' <param name="Control"></param>
        ''' <param name="AcceptVerbControlList"></param>
        ''' <param name="ReadOnlyState"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Function SetCoreControls(ByVal Control As Control, ByVal AcceptVerbControlList As String(),
                                          ByVal ReadOnlyState As Boolean)
            Dim objControlType As Type
            objControlType = Control.GetType
            Dim objParentControlType As Type = Nothing
            If Not Control.Parent Is Nothing Then objParentControlType = Control.Parent.GetType

            If objControlType.GetInterface("IFieldObject", True) Is Nothing Then
                Dim newcontrol As Control

                'For Each newcontrol In Control.Controls
                '    SetCoreControls(newcontrol, AcceptVerbControlList, ReadOnlyState)
                'Next
            Else
                Dim x As New CaseInsensitiveComparer

                'If Page.UseAcceptProcessing Then
                '    If objParentControlType.ToString <> "System.Web.UI.WebControls.DataListItem" Then
                '        If Array.BinarySearch (AcceptVerbControlList, Control.ID, x) > - 1 Then
                '            CType (Control, FieldObjectBase).IsDesignerAccept = ReadOnlyState
                '        End If
                '    End If
                'End If

                'If ReadOnlyState Then
                '    'Setting the controls to readonly. Only set controls to ReadOnly which are not already Readonly and are not in the AcceptVerb ArrayList
                '    If objParentControlType.ToString = "System.Web.UI.WebControls.DataListItem" Then
                '        'Grid controls gets handled in PreRender event of specific control
                '    ElseIf _
                '        Not CType(Control, FieldObjectBase).ReadOnly And _
                '        (Not Array.BinarySearch(AcceptVerbControlList, Control.Name, x) > -1) Then
                '        CType(Control, FieldObjectBase).ReadOnly = True
                '        AddIntoCurrentControlSet(Control.Name)
                '    End If
                'Else
                '    'Setting the controls back to false, search the previous state arraylist and see if there is a control in there that we set to readonly
                '    'and remove it from the arraylist
                '    If m_alCurrentControlsSetToReadOnly.Contains(Control.Name) Then
                '        CType(Control, FieldObjectBase).ReadOnly = False
                '        m_alCurrentControlsSetToReadOnly.Remove(Control.Name)
                '    End If
                'End If

            End If
            objControlType = Nothing
            objParentControlType = Nothing
            Return Nothing
        End Function

        ''' --- HasAccept ----------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Returns True when AcceptVerbList is set, otherwise returns False.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function HasAccept() As Boolean
            Return m_strAcceptVerbList.Trim.Length > 0
        End Function

        ''' --- HasAccept ----------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Returns True if the ControlId is set in AcceptVerbList, otherwise returns False.
        ''' </summary>
        ''' <param name="ControlId">A String containing the identity of the Control 
        ''' which the Designer is associated with.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function HasAccept(ByVal ControlId As String) As Boolean
            Dim ControlIDArray As String() = m_strAcceptVerbList.Split(";")
            Dim objComparer As New CaseInsensitiveComparer
            Dim blnReturnValue As Boolean = False
            If Array.BinarySearch(ControlIDArray, ControlId, objComparer) >= 0 Then
                blnReturnValue = True
            End If
            ControlIDArray = Nothing
            objComparer = Nothing
            Return blnReturnValue
        End Function

        ''' --- HasAcceptInGrid ----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Returns a boolean indicating that this designer has an Accept method call on at least one field in the grid.
        ''' </summary>
        ''' <remarks>
        ''' This property will return True if the property DefaultFirstRowInGrid is set to True and the AcceptVerbList property is set.
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function HasAcceptInGrid() As Boolean
            'DefaultFirstRowInGrid is used to determine that Designer has "Accept" on at least one Grid-Field
            Return m_strAcceptVerbList.Trim.Length > 0 AndAlso (Me.DefaultFirstRowInGrid)
        End Function

        ''' --- AddIntoCurrentControlSet -------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of AddIntoCurrentControlSet.
        ''' </summary>
        ''' <param name="ControlId"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Sub AddIntoCurrentControlSet(ByVal ControlId As String)
            If m_alCurrentControlsSetToReadOnly Is Nothing Then

                If m_alCurrentControlsSetToReadOnly Is Nothing Then
                    m_alCurrentControlsSetToReadOnly = New ArrayList
                End If
            End If
            m_alCurrentControlsSetToReadOnly.Add(ControlId)
        End Sub

        ''' --- ControlsLoad -------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of ControlsLoad.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="eventargs"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Sub ControlsLoad(ByVal sender As Object, ByVal eventargs As Object)
            ' For this code Init event was too early and Load Event was too late 
            ' For such code use This Method which will be

            If sender Is Nothing Then Exit Sub
            Dim designername As String

            Select Case sender.GetType.ToString
                Case "Core.Windows.UI.Core.Windows.UI.DateControl"
                    designername = "dsr" + DirectCast(sender, DateControl).FieldID
                Case "Core.Windows.UI.Core.Windows.UI.TextBox"
                    designername = "dsr" + DirectCast(sender, TextBox).FieldID
                Case "Core.Windows.UI.Core.Windows.UI.ComboBox"
                    designername = "dsr" + DirectCast(sender, ComboBox).FieldID
            End Select


            Select Case Name
                Case designername
                    With ApplicationState.Current.CorePage
                        m_blnCurrentDesigner = True
                        'Regardless whether user can switch designer, we need to Set or Remove Designer Name
                        .DesignerName = Me.Name
                        .PageActionObject = Me
                        .CurrentDesigner = Me
                        .m_blnDisableOtherDesigners = DisableOtherDesigners
                        .m_blnDefaultFirstRowInGrid = DefaultFirstRowInGrid

                    End With
                    'Case ApplicationState.Current.CorePage.GridDesigner
                    '    If ApplicationState.Current.CorePage.Request("__EventTarget") = "btnGridRowEdit" Then
                    '        With ApplicationState.Current.CorePage
                    '            .DesignerMode = True
                    '            m_blnCurrentDesigner = True
                    '            'Regardless whether user can switch designer, we need to Set or Remove Designer Name
                    '            .PageActionType = PageActionType.DesignerClick
                    '            .DesignerName = Me.Name
                    '            .PageActionObject = Me
                    '            .CurrentDesigner = Me
                    '            .m_blnDisableOtherDesigners = DisableOtherDesigners
                    '            .m_blnDefaultFirstRowInGrid = DefaultFirstRowInGrid
                    '        End With
                    '    End If
                Case ApplicationState.Current.CorePage.DesignerName
                    m_blnCurrentDesigner = True
                    With ApplicationState.Current.CorePage
                        .CurrentDesigner = Me
                        .m_blnDisableOtherDesigners = DisableOtherDesigners
                    End With
            End Select
        End Sub

        ''' --- RaiseBeforeClick ---------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of RaiseBeforeClick.
        ''' </summary>
        ''' <param name="DesignerCancel"></param>
        ''' <param name="e"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Sub RaiseBeforeClick(ByRef DesignerCancel As Boolean, ByVal e As DesignerEventArgs)
            'At present RaiseBeforeClick and RaiseClick is being called from DataList Control and also from Page
            'as such m_intDesignerClickStatus flag prevents the DesignerClick and DesignerBeforeClick event from firing twice
            If m_intDesignerClickStatus = DesignerStatus.NotClicked Then
                'We have separated RaiseBeforeClick and RaiseClick methods so that 
                'DataList control can use DesignerCancel flag before moving record position in a 
                'corresponding FileObject and/or Occurrence in an Array
                RaiseEvent BeforeClick(Me, DesignerCancel, e)
                If DesignerCancel Then
                    'm_intDesignerClickStatus flag is used to determine whether user has cancelled the event or not
                    m_intDesignerClickStatus = DesignerStatus.Cancelled
                End If
            End If
        End Sub

        ''' --- RaiseClick ---------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of RaiseClick.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Sub RaiseClick()

            Try


                ApplicationState.Current.CorePage.RunningDesigner = CType(Me, Core.Windows.UI.Designer)

                'At present RaiseBeforeClick and RaiseClick is being called from DataList Control and also from Page
                'as such m_intDesignerClickStatus flag prevents the DesignerClick and DesignerBeforeClick event from firing twice

                If ApplicationState.Current.CorePage.UseAcceptProcessing Then
                    If m_blnExecuteDefaultClick Then
                        If m_strAcceptVerbList.Length > 0 Then
                            Me.CurrentControlReadOnlyState = True
                        End If
                    End If

                    ApplicationState.Current.CorePage.ExecutingDesigner = True
                    Dim pushLengthStart As Integer = ApplicationState.Current.CorePage.PushStack.Length
                    Dim pushLengthEnd As Integer = 0
                    If ApplicationState.Current.CorePage.EventArgument <> "PostCommand" Then
                        If Not ApplicationState.Current.CorePage.PreCommandExecuted Then

                            ' Ensure we reset prior to calling PreCommand.
                            ApplicationState.Current.CorePage.m_blnUpdateCmdCalled = False

                            ' Raise the PreCommands event.
                            RaiseEvent PreCommands(Me, EventArgs.Empty)

                            ' Set the mode in case we have an UpdateCommand in the 
                            ' PreCommand for this designer that changes the mode.
                            ' This way in we can set the value back after the postback
                            ' if the Click event called a run screen.
                            'Page.PreCmdMode = Page.Mode

                            ' Only if the UpdateCommand (UpdateStay) is called do we want to save state and reset the flag.
                            If ApplicationState.Current.CorePage.m_blnUpdateCmdCalled Then
                                ' Set PreCommandExecuted to true.  This ensures that if we
                                ' call a RunScreen or Accept verb in the designer, that 
                                ' we don't call the PreCommand again.
                                ApplicationState.Current.CorePage.PreCommandExecuted = True

                                ' Since we may have hit a runscreen, accept or something, remove the 
                                ' flags to reset counters.  This ensures that when re-posting a designer,
                                ' that the flags have proper values.  If a runscreen was executed in the PreCommand for example,
                                ' and then also in the Click event, the count would have been incremented to 2, but since we don't 
                                ' re-run the PreCommand, the count going into the click on the postback would be 1 and the wrong 
                                ' state information would be read.
                                ApplicationState.Current.CorePage.RemoveFlags(True)
                            End If

                        End If

                        ' In case the PreCommand had an UpdateCommmand call.
                        'Page.Mode = Page.PreCmdMode

                        'See Notes on definition of Shadowed Click event
                        RaiseEvent Click(Me, EventArgs.Empty)
                        pushLengthEnd = ApplicationState.Current.CorePage.PushStack.Length
                    End If
                    If ApplicationState.Current.CorePage.PushStack.Length > 0 AndAlso Me.HasPostCommand AndAlso (pushLengthStart <> pushLengthEnd) Then
                        ApplicationState.Current.CorePage.PushPostCommand(Name)
                    Else
                        RaiseEvent PostCommands(Me, EventArgs.Empty)
                    End If
                    ApplicationState.Current.CorePage.UpdateProcessingCalled = False
                    ' Ensure that UpdateProcessing is set back to false.  When true, during postbacks, we don't call the update again until this value is False.
                    ApplicationState.Current.CorePage.ExecutingDesigner = False
                    ApplicationState.Current.CorePage.PreCommandExecuted = False

                    If Not Me.IsNumberedDesigner AndAlso Me.DefaultFirstRowInGrid Then ApplicationState.Current.CorePage.RemoveFlags(True)
                    ApplicationState.Current.CorePage.m_fldAcceptField = Nothing
                    ' Remove the last Accept field.

                    If m_blnExecuteDefaultClick Then
                        If m_strAcceptVerbList.Length > 0 Then
                            Dim control As Control
                            Dim array As String() = m_strAcceptVerbList.Split(";")

                            ' Loop through the non-grid controls and set the IsDesignerAccept back to FALSE.
                            ' NOTE: Grid controls are handled by the grid itself.
                            'For Each control In Page.Controls
                            '    SetIsDesignerAcceptToFalse(control, array)
                            'Next

                        End If
                    End If
                Else
                    If m_intDesignerClickStatus = DesignerStatus.NotClicked Then
                        If m_blnExecuteDefaultClick Then
                            If m_strAcceptVerbList.Length > 0 Then
                                Me.CurrentControlReadOnlyState = True
                            End If
                        End If

                        'See Notes on definition of Shadowed Click event
                        RaiseEvent Click(Me, EventArgs.Empty)
                    End If
                    m_intDesignerClickStatus = DesignerStatus.Clicked
                End If

                ApplicationState.Current.CorePage.PageActionType = PageActionType.NotSet
                'Page.RemoveScreenSession("LstOcc_" + Name)

                ApplicationState.Current.CorePage.RunningDesigner = Nothing

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private _textkey As String
        Public Property TextKey() As String
            Get
                Return _textkey
            End Get
            Set(value As String)
                If _textkey <> value Then
                    _textkey = value
                End If
            End Set
        End Property


        ''' --- SetIsDesignerAcceptToFalse -----------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of SetIsDesignerAcceptToFalse.
        ''' </summary>
        ''' <param name="Control"></param>
        ''' <param name="AcceptVerbControlList"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Function SetIsDesignerAcceptToFalse(ByVal Control As Control, ByVal AcceptVerbControlList As String())

            Dim objControlType As Type
            Dim x As New CaseInsensitiveComparer
            Dim objParentControlType As Type = Nothing

            If Not Control.Parent Is Nothing Then objParentControlType = Control.Parent.GetType
            objControlType = Control.GetType
            'If objControlType.GetInterface("IFieldObject", True) Is Nothing Then
            '    Dim newcontrol As Control

            '    For Each newcontrol In Control.Controls
            '        SetIsDesignerAcceptToFalse(newcontrol, AcceptVerbControlList)
            '    Next
            'Else
            '    If objParentControlType.ToString <> "System.Web.UI.WebControls.DataListItem" Then
            '        If Array.BinarySearch(AcceptVerbControlList, Control.ID, x) > -1 Then
            '            CType(Control, FieldObjectBase).IsDesignerAccept = False
            '        End If
            '    End If
            'End If
            Return Nothing
        End Function

        ''' --- Designer_Init ------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of Designer_Init.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
        Private Sub Designer_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Loaded
            If Not IsNothing(ApplicationState.Current.CorePage) Then
                AddHandler ApplicationState.Current.CorePage.ControlsLoad, AddressOf ControlsLoad
                AddHandler ApplicationState.Current.CorePage.LoadValues, AddressOf LoadValues
                AddHandler ApplicationState.Current.CorePage.DisplayControl, AddressOf Designer_PreRender
            End If
        End Sub

        ''' --- LoadValues ---------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of LoadValues.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Sub LoadValues()


        End Sub



        <DefaultValue(GetType(FunctionKeys), "NotSet")>
        Public Property FunctionKey() As FunctionKeys
            Get
                Return m_bytFunctionKeys
            End Get
            Set(ByVal Value As FunctionKeys)
                m_bytFunctionKeys = Value
            End Set
        End Property
    End Class

    ''' ----------------------------------------------------------------------------
    ''' 
    ''' Class	: DesignerEventArgs
    ''' 
    ''' ----------------------------------------------------------------------------
    ''' <exclude />
    ''' 
    ''' <summary>
    ''' 	Summary of DesignerEventArgs.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(EditorBrowsableState.Advanced)>
    Public Class DesignerEventArgs
        Inherits EventArgs

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
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Sub New()
            MyBase.New()
            ItemIndex = -1
            CommandArgument = ""
            CommandName = ""
            DataListItem = Nothing
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of New.
        ''' </summary>
        ''' <param name="objDataListItem"></param>
        ''' <param name="strCommandName"></param>
        ''' <param name="strCommandArgument"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Sub New(objDataListItem As GridViewRowPresenter, ByVal strCommandName As String,
                        ByVal strCommandArgument As String)
            MyBase.New()
            'ItemIndex = objDataListItem.index
            CommandName = strCommandName
            CommandArgument = strCommandArgument
            DataListItem = objDataListItem
        End Sub

        Public ItemIndex As Integer
        Public CommandArgument As String
        Public CommandName As String
        Public DataListItem As GridViewRowPresenter
    End Class
End Namespace