#Region "  Imports  "


Imports System.ComponentModel
Imports System.Windows
Imports System.Windows.Controls
Imports Core.Framework.Core.Framework
Imports System.Drawing
Imports System.Collections.Specialized
Imports System.Text
Imports System.Xml
Imports System.Reflection
Imports System.IO
Imports Core.Framework
Imports ResourceTypes = Core.Globalization.Core.Globalization.ResourceTypes
Imports System.Windows.Visibility
Imports System.Windows.Threading
Imports System.Windows.Data
Imports System.Windows.Input
Imports System.Globalization
Imports System.Windows.Markup
Imports System.Threading
Imports System.Windows.Controls.Primitives
Imports System.Windows.Media

#End Region


Namespace Core.Windows.UI
    ''' ----------------------------------------------------------------------------
    ''' 
    ''' Class	: DateControl
    ''' 
    ''' ----------------------------------------------------------------------------
    ''' 
    ''' <summary>
    ''' 	Date Control used in the Renaissance Architect Framework.
    ''' </summary>
    ''' <remarks>
    '''     The Renaissance Architect DateControl is an input control that allows
    '''     the user to enter a date value.
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <Bindable(True),
        Description("Date Control for Core."),
        DefaultValue(""),
        EditorBrowsable(EditorBrowsableState.Always)>
    Public Class DateControl
        Inherits FieldObjectDateBox

#Region "  Private  "

        Private WithEvents m_btnButton As Object
        Private dpt As System.Windows.Controls.Primitives.DatePickerTextBox
        Public invaliddate As Boolean
        Private m_strDateFormat As String = ""
        Private m_strSeparator As String = ""
        <EditorBrowsable(EditorBrowsableState.Advanced)> Protected Friend m_blnCurrentRow As Boolean = False

#End Region

#Region "  Properties  "



        Private Sub datePicker_IsEnabledChanged(sender As Object, e As DependencyPropertyChangedEventArgs) Handles Me.IsEnabledChanged

            Dim datePicker As DatePicker = TryCast(sender, DatePicker)
            VisualStateManager.GoToState(datePicker, "Normal", True)
        End Sub

        ''' --- RenderedID ---------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False),
            Browsable(False),
            DefaultValue(""),
            EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Overrides ReadOnly Property RenderedID() As String
            Get
                Return FieldID
            End Get
        End Property

        Private _valueChanged As Boolean
        ''' --- ValueChanged -------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False),
            Browsable(False),
            DefaultValue(False),
            EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Overrides Property ValueChanged() As Boolean
            Get
                Return _valueChanged
            End Get
            Set(ByVal Value As Boolean)
                _valueChanged = Value
            End Set
        End Property

        ''' --- EnableForDesigner --------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False),
            Browsable(False),
            DefaultValue(""),
            EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Property EnableForDesigner() As Microsoft.VisualBasic.TriState
            Get
                Return ApplicationState.Current.CorePage.RenderDefaultTextBoxesForDesigner
            End Get
            Set(ByVal Value As Microsoft.VisualBasic.TriState)

                If Value <> TriState.UseDefault Then
                    ApplicationState.Current.CorePage.RenderDefaultTextBoxesForDesigner = False
                End If
            End Set
        End Property

        Public HighlightOccurence As Hashtable

        <EditorBrowsable(EditorBrowsableState.Never)> Private m_blnHighlight As Boolean = False
        ''' --- Highlight -----------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of Highlight.
        ''' </summary>
        ''' <remarks>
        '''     The Highlight property of the Textbox.
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Browsable(False),
            DefaultValue(False),
            Description("Specifies whether the textbox is Highlighted."),
            EditorBrowsable(EditorBrowsableState.Never)>
        Public Property Highlight() As Boolean
            Get
                Return m_blnHighlight
            End Get
            Set(ByVal value As Boolean)
                m_blnHighlight = value
            End Set
        End Property

        Private m_strLookupCharacter As String = String.Empty
        ''' --- LookupCharacter ----------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	The character to be used to invoke a lookup screen.
        ''' </summary>
        ''' <value>
        '''     A String representing a character to invoke a lookup screen.
        ''' </value>
        ''' <remarks>
        '''     If specified, this character will be used to invoke a lookup screen, 
        '''     otherwise it will use the default character specified in the application.
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False),
            Browsable(True),
            Description _
                (
                 "If specified, this character will be used to invoke a lookup screen, otherwise it will use the default character specified in the application."),
            Category("Navigation"),
            DefaultValue(""),
            EditorBrowsable(EditorBrowsableState.Always)>
        Public Property LookupCharacter() As String
            Get
                Return m_strLookupCharacter
            End Get
            Set(ByVal Value As String)
                m_strLookupCharacter = Value
            End Set
        End Property
        Private m_blnUseLookupCharacter As Boolean
        ''' --- UseLookupCharacter -------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Determines whether to use a lookup character to call a lookup screen or not.
        ''' </summary>
        ''' <value>
        '''     A Boolean indicating whether to use a character for lookup screen. The default
        '''     value is set to "False".
        ''' </value>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False),
            Browsable(True),
            Description("Determines whether to use a lookup character to call a lookup screen or not."),
            Category("Navigation"),
            DefaultValue(False),
            EditorBrowsable(EditorBrowsableState.Always)>
        Public Property UseLookupCharacter() As Boolean
            Get
                Return m_blnUseLookupCharacter
            End Get
            Set(ByVal Value As Boolean)
                m_blnUseLookupCharacter = Value
            End Set
        End Property

        Private _OldText As String = ""
        ''' --- OldText ------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	The OldText value of the Textbox.
        ''' </summary>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False),
            Browsable(False),
            DefaultValue(""),
            EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Property OldText() As String

            Get
                Return _OldText
            End Get

            Set(ByVal Value As String)
                _OldText = Value
            End Set
        End Property

        ''' --- AcceptProcessingOldText --------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	The AcceptProcessingOldText value of the Textbox (static until designer completion).
        ''' </summary>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False),
            Browsable(False),
            DefaultValue(""),
            EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Property AcceptProcessingOldText() As String

            Get
                Return _AcceptProcessingOldText
            End Get

            Set(ByVal Value As String)
                _AcceptProcessingOldText = Value
            End Set
        End Property

        Private _AcceptProcessingOldText As String

        ''' --- DataType -----------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of DataType.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Browsable(False),
            EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Overrides Property DataType() As DataTypes
            Get
                Return MyBase.DataType
            End Get
            Set(ByVal Value As DataTypes)
                MyBase.DataType = DataTypes.Date
            End Set
        End Property



        ''' --- DateFormat ---------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	The format of the date in which it is to be displayed.
        ''' </summary>
        ''' <value>
        '''     A String containing the format to be applied to the DateControl.
        ''' </value>
        ''' <example>
        '''     <code>
        '''         myDateControl.DateFormat = "MM/dd/yyyy"
        '''     </code>
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False),
            LoadDictionary(True),
            Description("The format the date is displayed."),
            Category("Core"),
            DefaultValue(""),
            EditorBrowsable(EditorBrowsableState.Always)>
        Public Property DateFormat() As String
            Get
                If (m_strDateFormat = "") Then

                End If
                Return m_strDateFormat
            End Get
            Set(ByVal Value As String)
                If Not Value Is Nothing AndAlso Value.Trim <> "" Then
                    Dim strTemp As String
                    Dim chrChar As Char
                    strTemp = Value.ToLower.Replace("m", "M").Trim
                    m_strDateFormat = strTemp

                    If m_strSeparator.Length = 0 Then
                        ' Try and find the date separator.
                        For Each chrChar In strTemp
                            Select Case chrChar
                                Case "M"
                                Case "d"
                                Case "y"
                                Case Else
                                    Separator = CStr(chrChar)
                                    Exit For
                            End Select
                        Next
                    End If
                Else
                    m_strDateFormat = Value
                End If
            End Set
        End Property



        ''' --- Separator ----------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	The Separator used to format the Date.
        ''' </summary>
        ''' <value>
        '''     A String containing the character to be used to deliniate the date.
        ''' </value>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False),
            LoadDictionary(True),
            Browsable(True),
            Category("Core"),
            Description("Date Separator."),
            DefaultValue(""),
            EditorBrowsable(EditorBrowsableState.Always)>
        Public Property Separator() As String
            Get
                Return m_strSeparator
            End Get
            Set(ByVal Value As String)
                m_strSeparator = Value.Substring(0, 1)
            End Set
        End Property


#End Region

#Region "  Methods  "


        ''' --- LoadDefaultsFromDictionary -----------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of LoadDefaultsFromDictionary.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Overrides Sub LoadDefaultsFromDictionary()

            Dim objRange As RangeList = New RangeList
            Dim arrStrRange() As String
            Dim arrDblRange() As String
            Dim objDictionaryHashTable As Hashtable

            ' Try...Catch is to ensure element exists.
            Try
                objDictionaryHashTable = ApplicationState.Current.CorePage.GetDictionaryHashTable(Dictionary)
                If objDictionaryHashTable Is Nothing Then
                    'Get the value for "Label" from Globalization
                    'SetDefaultValueForProperty(Me.Label, "")

                    'Get the value for "ToolTip" from Globalization
                    SetDefaultValueForProperty(Me.ToolTip, "")

                    Exit Sub

                End If
                With objDictionaryHashTable

                    ''TODO:Get Values from dictionary
                    'If Me.Values Is Nothing Then
                    '    Me.Values = .GetValues(Dictionary)
                    'End If

                    'Get the default value for "BWZ" from Dictionary
                    If Me.BWZ = BooleanTypes.NotSet Then
                        If CBool(.Item(CInt(Global.Core.Framework.Core.Framework.FieldAttributes.BwzFlag))) Then
                            Me.BWZ = BooleanTypes.True
                        Else
                            Me.BWZ = BooleanTypes.False
                        End If
                    End If



                    'Get the default value for "ElementSize" from Dictionary

                    'Get the default value for "UnderLyingDataType" from Dictionary
                    If Me.UnderLyingDataType = DataTypes.NotSet Then
                        Me.UnderLyingDataType =
                            CType(.Item(CInt(Global.Core.Framework.Core.Framework.FieldAttributes.ItemDataTypeCode)),
                                ItemDataTypes)
                    End If

                    'Get the default value for "Heading" from Dictionary
                    SetDefaultValueForProperty(Me.Heading,
                                                CStr(
                                                   .Item(
                                                          CInt(
                                                             Global.Core.Framework.Core.Framework.FieldAttributes.
                                                             Heading))))

                    'Get the default value for "Fill" from Dictionary
                    SetDefaultValueForProperty(Me.Fill,
                                                CStr(
                                                   .Item(
                                                          CInt(
                                                             Global.Core.Framework.Core.Framework.FieldAttributes.Fill))))

                    'Get the default value for "Float" from Dictionary
                    SetDefaultValueForProperty(Me.Float,
                                                CStr(
                                                   .Item(
                                                          CInt(
                                                             Global.Core.Framework.Core.Framework.FieldAttributes.
                                                             FloatValue))))

                    'Get the default value for "Label" from Dictionary
                    'SetDefaultValueForProperty(Me.Label, _
                    '                            CStr( _
                    '                               .Item( _
                    '                                      CInt( _
                    '                                         Global.Core.Framework.Core.Framework.FieldAttributes.Label))))
                    'If Me.Label = String.Empty AndAlso Me.FieldName.IndexOf(".") > 0 Then
                    '    Me.Label = StrConv(Me.Dictionary.Replace("_", " "), VbStrConv.ProperCase)
                    'End If

                    'Get the default value for "ToolTip" from Dictionary
                    SetDefaultValueForProperty(Me.ToolTip,
                                                CStr(
                                                   .Item(
                                                          CInt(
                                                             Global.Core.Framework.Core.Framework.FieldAttributes.Help))))

                    'Get the default value for "Default" from Dictionary
                    SetDefaultValueForProperty(Me.Default,
                                                CStr(
                                                   .Item(
                                                          CInt(
                                                             Global.Core.Framework.Core.Framework.FieldAttributes.
                                                             DefaultValue))))



                    'Get the default value for "DataType" from Dictionary
                    If Me.DataType = DataTypes.NotSet Then
                        Me.DataType =
                            CType(.Item(CInt(Global.Core.Framework.Core.Framework.FieldAttributes.ElementTypeCode)),
                                DataTypes)
                    End If


                    'Get the default value for "LeadingSign" from Dictionary
                    SetDefaultValueForProperty(Me.LeadingSign,
                                                CStr(
                                                   .Item(
                                                          CInt(
                                                             Global.Core.Framework.Core.Framework.FieldAttributes.
                                                             LeadingSign))))

                    'Get the default value for "OutputScale" from Dictionary
                    If Me.m_strOutputScale Is Nothing Then
                        Me.m_strOutputScale =
                            CType(.Item(CInt(Global.Core.Framework.Core.Framework.FieldAttributes.OutputScale)),
                                String)
                    End If

                    'Get the default value for "Pattern" from Dictionary
                    SetDefaultValueForProperty(Me.Pattern,
                                                CStr(
                                                   .Item(
                                                          CInt(
                                                             Global.Core.Framework.Core.Framework.FieldAttributes.
                                                             PatternValue))))

                    'Get the default value for "Picture" from Dictionary
                    SetDefaultValueForProperty(Me.Picture,
                                                CStr(
                                                   .Item(
                                                          CInt(
                                                             Global.Core.Framework.Core.Framework.FieldAttributes.
                                                             Picture))))

                    'Get the default value for "ShiftType" from Dictionary
                    If Me.ShiftType = ShiftTypes.NotSet Then
                        Me.ShiftType =
                            CType(.Item(CInt(Global.Core.Framework.Core.Framework.FieldAttributes.ShiftInputCode)),
                                ShiftTypes)
                    End If

                    'Get the default value for "Separator" from Dictionary

                    'Get the default value for "Significance" from Dictionary. 
                    'Following code ignores "0" Significance set on Field, and will use, Significance defined in Dictionary
                    If Me.m_strSignificance Is Nothing OrElse m_strSignificance.Equals("0") Then
                        Me.m_strSignificance =
                            CType(.Item(CInt(Global.Core.Framework.Core.Framework.FieldAttributes.Significance)),
                                String)
                    End If

                    'Get the default value for "TrailingSign" from Dictionary
                    SetDefaultValueForProperty(Me.TrailingSign,
                                                CStr(
                                                   .Item(
                                                          CInt(
                                                             Global.Core.Framework.Core.Framework.FieldAttributes.
                                                             TrailingSign))))

                    'Get the default value for "Description" from Dictionary
                    SetDefaultValueForProperty(Me.Description,
                                                CStr(
                                                   .Item(
                                                          CInt(
                                                             Global.Core.Framework.Core.Framework.FieldAttributes.Description))))

                    If FieldValues Is Nothing OrElse FieldValues.Trim.Equals(String.Empty) Then
                        Dim _
                            strValues As String =
                                CStr(.Item(CInt(Global.Core.Framework.Core.Framework.FieldAttributes.Values)))
                        If strValues <> "" Then
                            If Me.DataType = DataTypes.Numeric Then
                                arrStrRange = Split(strValues, ",")
                                For i As Integer = 0 To arrStrRange.Length - 1
                                    If arrStrRange(i).IndexOf("(") >= 0 AndAlso arrStrRange(i).IndexOf(")") >= 0 _
                                        Then
                                        'e.g. "(-999.999)-(999.99)" OR "(999.99)"
                                        Dim arrRange As String() = GetValueRange(arrStrRange(i))
                                        If arrRange(1) Is Nothing Then
                                            objRange.AddRange(CType(arrRange(0), Decimal))
                                        Else
                                            arrDblRange = Split(arrStrRange(i), "-")
                                            objRange.AddRange(CType(arrRange(0), Decimal),
                                                               CType(arrRange(1), Decimal))
                                        End If
                                        arrRange = Nothing
                                    ElseIf arrStrRange(i).IndexOf("-") <> -1 Then
                                        arrDblRange = Split(arrStrRange(i), "-")
                                        objRange.AddRange(CType(arrDblRange(0), Decimal),
                                                           CType(arrDblRange(1), Decimal))
                                    Else
                                        objRange.AddRange(CType(arrStrRange(i), Decimal))
                                    End If
                                Next
                            Else
                                arrStrRange = Split(strValues, ",")
                                For i As Integer = 0 To UBound(arrStrRange)
                                    If arrStrRange(i).IndexOf("(") >= 0 AndAlso arrStrRange(i).IndexOf(")") >= 0 _
                                        Then
                                        'e.g. "(A)-(D)" OR "(A)"
                                        Dim arrRange As String() = GetValueRange(arrStrRange(i))
                                        If arrRange(1) Is Nothing Then
                                            objRange.AddRange(arrRange(0))
                                        Else
                                            arrDblRange = Split(arrStrRange(i), "-")
                                            objRange.AddRange(arrRange(0), arrRange(1))
                                        End If
                                        arrRange = Nothing
                                    ElseIf arrStrRange(i).IndexOf("-") <> -1 Then
                                        arrDblRange = Split(arrStrRange(i), "-")
                                        objRange.AddRange(arrDblRange(0), arrDblRange(1))
                                    Else
                                        objRange.AddRange(arrStrRange(i))
                                    End If
                                Next
                            End If
                            Me.Values = objRange
                        End If
                    End If
                End With
                objDictionaryHashTable = Nothing



            Catch ex As Exception

                ' Do nothing.  Dictionary element doesn't exist.

            End Try

        End Sub



        Private Sub PageModeLogic()
            Const cPopupEvent As String = "onFocus"



            If Not ToolTip Is Nothing AndAlso ToolTip.Trim().Length = 0 Then
                SetValue(ToolTipService.IsEnabledProperty, False)
            Else
                SetValue(ToolTipService.IsEnabledProperty, True)
            End If

            Try
                With Me

                    If Not ToolTip Is Nothing AndAlso Me.ToolTip.Length > 2 AndAlso Me.ToolTip.Substring(0, 2) = "::" Then

                        Me.ToolTip = ApplicationState.Current.CorePage.GetString(Me.ToolTip.Substring(2), ResourceTypes.Label)

                    End If

                    If ApplicationState.Current.CorePage.HasErrorInFind Then

                        ' If we have an error in the Find procedure (other than "No Records Found", then
                        ' make the controls read only.
                        .IsEnabled = False

                        '.CssClassTextBox = "ROFieldValue"
                        '.TabIndex = -1

                    Else

                        ' Accept processing.
                        ' Moved from TextBox_Load.

                        '--------------- 
                        'Beside ReadOnly, now also checking CssClassTextBox.
                        'Changed mainly to disable combobox from opening when Combo Box 
                        'is readonly, however it seems to be applicable with all TextBox Controls.
                        'October 03, 2005 17:01
                        ''--------------- 
                        'If _
                        '    (Visible AndAlso Not (Me.ReadOnly OrElse CssClassTextBox = "ROFieldValue")) OrElse _
                        '    IsDesignerAccept OrElse SetAcceptRequestPrompt Then

                        '    .InFieldValidation = False
                        '    .AddInnerControlAttribute("onmousedown", "setFocusUsingMouse(this);")
                        '    .AddInnerControlAttribute("onKeyDown", "keyDown(this);")
                        '    .AddInnerControlAttribute("onFocus", "this.select(); return GotFocus(this);")
                        '    If .SetAcceptRequestPrompt Then
                        '        .RemoveInnerControlAttribute("onchange")
                        '        .AddInnerControlAttribute("onchange", "DataChanged();")
                        '    Else
                        '        .AddInnerControlAttribute("onchange", "DataChanged(); ChangeEvent(this);")
                        '    End If

                        '    '.AddInnerControlAttribute("FieldID", .FieldID)
                        '    '.Page.RegisterRequiresPostBack(Me)
                        'End If

                        '.AddInnerControlAttribute("FieldName", .FieldName)

                        If ApplicationState.Current.CorePage.NavigationType = NavigationTypes.Cancel Then
                            SetAcceptRequestPrompt = False
                        End If


                        If _
                            .IsDesignerAccept OrElse .SetAcceptRequestPrompt OrElse
                            ((ApplicationState.Current.CorePage.HasError AndAlso ApplicationState.Current.CorePage.m_strRequestedControlFocusOverRide = Me.Name)) Then

                            .DisplayAsLabel = False
                            '.CssClassTextBox = ""
                            .Visibility = Visible
                            '.SetAcceptRequestPrompt = False


                            If ApplicationState.Current.CorePage.HasError Then
                                If IsEnabled Then
                                    Dim bc As New BrushConverter()
                                    dpt.Background = New SolidColorBrush(Colors.Red)
                                    dpt.Foreground = New SolidColorBrush(Colors.White)

                                    Me.Background = New SolidColorBrush(Colors.Red)
                                    Me.Foreground = New SolidColorBrush(Colors.White)

                                    Dim dt As DispatcherTimer = New Threading.DispatcherTimer()
                                    AddHandler dt.Tick, AddressOf SetFocus
                                    dt.Interval = New TimeSpan(0, 0, 0, 0, 200)
                                    dt.Start()
                                End If
                            Else
                                .IsEnabled = True
                                .Focus()
                            End If



                        Else

                            ' If the control has fixed = true then make the control Read-Only and
                            ' ignore the rest of the logic
                            ' NOTE: The OMIT setting is ignored in this case.
                            If .Fixed = BooleanTypes.True Then
                                .IsEnabled = False
                            Else

                                If ApplicationState.Current.CorePage.RenderDefaultTextBoxesForDesigner Then
                                    'Using m_blnUseDefault shared property we are resetting each 
                                    'textbox to use the default properties
                                    .EnableForDesigner = Microsoft.VisualBasic.TriState.UseDefault
                                End If

                                Select Case ApplicationState.Current.CorePage.Mode

                                    Case PageModeTypes.Correct
                                        If _
                                            .NoCorrect = BooleanTypes.True OrElse IsOmitInEntry() OrElse
                                            IsDisplayInEntry() Then
                                            .IsEnabled = False
                                            '.TabIndex = -1
                                        End If

                                    Case PageModeTypes.Change
                                        Select Case .EnableForDesigner
                                            Case Microsoft.VisualBasic.TriState.True
                                                .IsEnabled = True
                                                .DisplayAsLabel = False
                                                '.CssClassTextBox = ""
                                                'Case Microsoft.VisualBasic.TriState.False
                                                '    .EnableForDesigner = Microsoft.VisualBasic.TriState.False
                                                '    .IsReadonly = True
                                                '.CssClassTextBox = "ROFieldValue"
                                            Case Else
                                                If .NoChange = BooleanTypes.True And Not ApplicationState.Current.CorePage.AppendMode Then
                                                    .IsEnabled = False
                                                    '.CssClassTextBox = "ROFieldValue"
                                                Else
                                                    Select Case .Display
                                                        Case BehaviorTypes.Change, BehaviorTypes.ChangeEntryFind,
                                                            BehaviorTypes.ChangeEntry, BehaviorTypes.ChangeFind
                                                            .IsEnabled = False
                                                            '.TabIndex = -1
                                                            '.CssClassTextBox = "ROFieldValue"
                                                        Case Else
                                                            If Me.IsOmitInEntry Then
                                                                'Display  this textbox as a label/ReadOnly
                                                                DisplayAsLabel = True
                                                            Else
                                                                .IsEnabled = True
                                                            End If
                                                    End Select
                                                End If
                                        End Select
                                        If .Silent Then
                                            .Visibility = Visibility.Collapsed
                                        ElseIf .Omit = BehaviorTypes.Find Or .Omit = BehaviorTypes.EntryFind Then
                                            .IsEnabled = False
                                        ElseIf Not .Silent Then
                                            .Visibility = Visible
                                        End If

                                    Case PageModeTypes.Entry
                                        Select Case .EnableForDesigner
                                            Case Microsoft.VisualBasic.TriState.True
                                                .IsEnabled = True
                                                .DisplayAsLabel = False
                                                '.CssClassTextBox = ""
                                                'Case Microsoft.VisualBasic.TriState.False
                                                '    .EnableForDesigner = Microsoft.VisualBasic.TriState.False
                                                '    .IsReadonly = True
                                                '.CssClassTextBox = "ROFieldValue"
                                            Case Else
                                                If .NoEntry = BooleanTypes.True Then
                                                    .IsEnabled = False
                                                    '.TabIndex = -1
                                                Else
                                                    Select Case .Display
                                                        Case BehaviorTypes.Entry, BehaviorTypes.EntryFind,
                                                            BehaviorTypes.ChangeEntry, BehaviorTypes.ChangeEntryFind
                                                            .IsEnabled = False
                                                            '.TabIndex = -1
                                                        Case Else
                                                            .IsEnabled = True
                                                    End Select
                                                End If
                                        End Select
                                        If .Silent Then
                                            .Visibility = Visibility.Collapsed
                                        ElseIf .Omit = BehaviorTypes.Entry Or .Omit = BehaviorTypes.EntryFind Then
                                            .IsEnabled = False
                                        ElseIf Not .Silent Then
                                            .Visibility = Visible
                                        End If

                                    Case PageModeTypes.Find
                                        Select Case .Display
                                            Case BehaviorTypes.Find, BehaviorTypes.EntryFind, BehaviorTypes.ChangeFind,
                                                BehaviorTypes.ChangeEntryFind
                                                .IsEnabled = False
                                                '.TabIndex = -1
                                            Case Else
                                                .IsEnabled = True
                                                'If Not .m_blnBypassPageModeLogic Then .[ReadOnly] = False
                                        End Select

                                        If .Silent Then
                                            .Visibility = Visibility.Collapsed
                                        ElseIf .Omit = BehaviorTypes.Find Or .Omit = BehaviorTypes.EntryFind Then
                                            .IsEnabled = False
                                        ElseIf Not .Silent Then
                                            .Visibility = Visible
                                        End If

                                    Case PageModeTypes.Select
                                        Dim strFile As String = .FieldName
                                        If strFile.IndexOf(".") > 0 Then
                                            strFile = strFile.Substring(0, strFile.IndexOf("."))
                                        Else
                                            strFile = ""
                                        End If

                                        If .NoSelect = BooleanTypes.True OrElse strFile <> ApplicationState.Current.CorePage.PrimaryFile Then
                                            .IsEnabled = False
                                            '.CssClassTextBox = "ROFieldValue"
                                            '.TabIndex = -1
                                        End If

                                        If .Silent Then
                                            .Visibility = Visibility.Collapsed
                                        ElseIf .Omit = BehaviorTypes.Find Or .Omit = BehaviorTypes.EntryFind Then
                                            .IsEnabled = False
                                        ElseIf Not .Silent Then
                                            .Visibility = Visible
                                        End If

                                    Case Else
                                        .IsEnabled = False
                                        '.CssClassTextBox = "ROFieldValue"
                                        '.TabIndex = -1
                                        If .Silent Then
                                            .Visibility = Visibility.Collapsed
                                        ElseIf Not .Silent Then
                                            .Visibility = Visible
                                        End If

                                        ' Added for Delete to clear the value on the screen.
                                        'If .Page.NavigationType = NavigationTypes.Delete Then
                                        If _
                                            (Not .Fixed) AndAlso
                                            ((ApplicationState.Current.CorePage.NavigationType = NavigationTypes.Delete AndAlso
                                              (Not .DisplayExecuted)) OrElse
                                             (ApplicationState.Current.CorePage.Mode = PageModeTypes.NoMode AndAlso
                                              (ApplicationState.Current.CorePage.NavigationType = NavigationTypes.Cancel OrElse
                                               ApplicationState.Current.CorePage.NavigationType = NavigationTypes.Delete) AndAlso
                                              .PreDisplay <> BooleanTypes.True AndAlso Not .DisplayExecuted)) Then
                                            .Text = Nothing
                                        End If

                                End Select
                            End If

                            If .DisplayAsLabel Then

                                .IsEnabled = False


                                '.CssClassTextBox = "ROFieldValue"
                                '.TabIndex = -1

                            Else
                                'This must be done to overcome viewstate
                                'to reset to original values
                                '.InFieldValidation = .m_blnInFieldValidation
                                ' If the ID starts with "fnc", it's a action menu dropdown.  Don't set 
                                '' the tab index.
                                'If .ID.StartsWith("fnc") Then
                                '    '.TabIndex = -1
                                '    If .AccessKey.Length > 0 Then
                                '        If Page.m_strActionDropdowns.Length > 0 Then Page.m_strActionDropdowns &= "~"
                                '        Page.m_strActionDropdowns &= .AccessKey & "|" & .m_txtTextBox.UniqueID
                                '    End If
                                'Else
                                '    .TabIndex = .m_intTabIndex
                                'End If
                            End If
                        End If

                        If .Visibility = Visible And .IsEnabled And Not .DisplayAsLabel Then
                            ApplicationState.Current.CorePage.ControlList.Add(Me)
                        End If
                    End If
                    ' If Page.HasErrorInFind


                    ' Create the onBlur code.


                    Dim blnError As Boolean = False
                    Dim strClass As String = String.Empty


                    If (ApplicationState.Current.CorePage.HasError AndAlso ApplicationState.Current.CorePage.m_strRequestedControlFocusOverRide = Me.RenderedID) Then
                        If Highlight Then
                            If Me.RenderedID.StartsWith("dtl") Then
                                If _
                                    HighlightOccurence.Contains(
                                                                 CInt(Me.RenderedID.Split("$")(1).Replace("ctl", ""))) _
                                    Then
                                    strClass = "Highlight"
                                End If
                            Else
                                strClass = "Highlight"
                            End If
                        Else
                            If _
                                Me.Required = BooleanTypes.True AndAlso
                                (ApplicationState.Current.CorePage.Mode = PageModeTypes.Correct OrElse ApplicationState.Current.CorePage.Mode = PageModeTypes.Change OrElse
                                 ApplicationState.Current.CorePage.Mode = PageModeTypes.Entry) Then
                                strClass = "Required"
                            Else
                                strClass = "TextBox"
                            End If
                        End If
                        blnError = True
                        '.AddInnerControlAttribute("onBlur", _
                        '                           m_txtTextBox.Attributes.Item("onBlur") + " LoseFocus(this,'" + _
                        '                           strClass + "');")
                    End If


                    If Highlight Then
                        If Me.RenderedID.StartsWith("dtl") Then
                            If HighlightOccurence.ContainsKey(CInt(Me.RenderedID.Split("$")(1).Replace("ctl", ""))) _
                                Then
                                'If .CssClassTextBox = "ROFieldValue" Then
                                '    .CssClassTextBox = "ROHighlight"
                                'Else
                                '    .CssClassTextBox = "Highlight"
                                'End If
                            End If
                        Else
                            'If .CssClassTextBox = "ROFieldValue" Then
                            '    .CssClassTextBox = "ROHighlight"
                            'Else
                            '    .CssClassTextBox = "Highlight"
                            'End If
                        End If
                    End If



                    'If AuotNext is set to True, write the attribute as True, else write as False
                    'If (Me.AutoNext) Then
                    '    .AddInnerControlAttribute("AutoNext", "True")
                    'Else
                    '    .AddInnerControlAttribute("AutoNext", "False")
                    'End If

                End With

            Catch
            End Try




            If _
                (Not ApplicationState.Current.CorePage.UseAcceptProcessing OrElse
                 (ApplicationState.Current.CorePage.UseAcceptProcessing AndAlso (ApplicationState.Current.CorePage.EnableNumberedDesigners OrElse Me.SetAcceptRequestPrompt))) _
                Then


            End If

            ' Add the code to generate the SetLookupValue.
            If UseLookupCharacter AndAlso ApplicationState.Current.CorePage.Mode <> PageModeTypes.NoMode AndAlso (IsEnabled) Then
                Dim intCount As Int16
                Dim strUniqueControlId As String = String.Empty

            End If

            ' Create the code to set focus to first field.
            If Not ApplicationState.Current.CorePage.UseAcceptProcessing Then
                If TabIndex = 1 Then
                    If _
                        (ApplicationState.Current.CorePage.Mode = PageModeTypes.Entry Or ApplicationState.Current.CorePage.Mode = PageModeTypes.Find) And
                        Not ApplicationState.Current.CorePage.IsExecutingInFieldValidation Then

                    End If
                End If
            End If

            If Not (ApplicationState.Current.CorePage.HasError AndAlso ApplicationState.Current.CorePage.m_strRequestedControlFocusOverRide = Me.Name) Then

                Dim dpt As DatePickerTextBox = DirectCast(Me, DateControl).FindChildByType(Of System.Windows.Controls.Primitives.DatePickerTextBox)()

                If Fixed Then
                    SetResourceReference(StyleProperty, "LabelCoreDateControl")

                    IsTabStop = False
                Else
                    If Not IsEnabled Then

                        Dim bc As New BrushConverter()
                        dpt.Background = New SolidColorBrush(Colors.White)
                        dpt.Foreground = New SolidColorBrush(Colors.Black)

                        Me.Background = New SolidColorBrush(Colors.White)
                        Me.Foreground = New SolidColorBrush(Colors.Black)


                        DirectCast(Me, DateControl).FindChildByType(Of Button)().Visibility = Visibility.Hidden

                        IsTabStop = False
                    ElseIf Required AndAlso ApplicationState.Current.CorePage.Mode <> PageModeTypes.Find AndAlso
                        ApplicationState.Current.CorePage.Mode <> PageModeTypes.NoMode Then

                        Dim bc As New BrushConverter()
                        dpt.Background = New SolidColorBrush(Colors.AliceBlue)
                        dpt.Foreground = New SolidColorBrush(Colors.Black)

                        Me.Background = New SolidColorBrush(Colors.AliceBlue)
                        Me.Foreground = New SolidColorBrush(Colors.Black)

                        DirectCast(Me, DateControl).FindChildByType(Of Button)().Visibility = Visibility.Visible

                        IsTabStop = True
                    Else


                        Dim bc As New BrushConverter()
                        dpt.Background = New SolidColorBrush(Colors.White)
                        dpt.Foreground = New SolidColorBrush(Colors.Black)

                        Me.Background = New SolidColorBrush(Colors.White)
                        Me.Foreground = New SolidColorBrush(Colors.Black)

                        DirectCast(Me, DateControl).FindChildByType(Of Button)().Visibility = Visibility.Visible

                        IsTabStop = True
                    End If
                End If

            End If

        End Sub


        Public Sub SetFocus(sender As Object, e As EventArgs)
            Dim dt = TryCast(sender, DispatcherTimer)
            If dt IsNot Nothing Then
                dt.[Stop]()
            End If
            dt = Nothing
            Me.Focus()
        End Sub

        ''' --- PrepareForDisplayInGrid --------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of PrepareForDisplayInGrid.
        ''' </summary>
        ''' <param name="IsCurrentRow"></param>
        ''' <param name="ClearContent"></param>
        ''' <param name="Designer"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Protected Friend Overrides Sub PrepareForDisplayInGrid(ByVal IsCurrentRow As Boolean,
                                                                ByVal ClearContent As Boolean,
                                                                Optional ByVal Designer As Designer = Nothing)
            With Me
                If (Not Designer Is Nothing) AndAlso (Designer.DisableOtherControls) Then
                    Dim objDesigner As Designer
                    objDesigner = ApplicationState.Current.CorePage.CurrentDesigner

                    If IsCurrentRow AndAlso objDesigner.HasAccept(Name) Then
                        .EnableForDesigner = Microsoft.VisualBasic.TriState.True
                    Else

                        .DisplayAsLabel = True
                        ' .CssClassTextBox = "ROFieldValue"
                        .IsEnabled = False
                        .EnableForDesigner = Microsoft.VisualBasic.TriState.False

                    End If
                    objDesigner = Nothing
                Else

                    If ClearContent Then .ClearValues()
                    If IsCurrentRow AndAlso Me.Display.ToString.ToUpper.IndexOf(ApplicationState.Current.CorePage.Mode.ToString.ToUpper) < 0 Then
                        .DisplayAsLabel = False
                        ' .CssClassTextBox = ""
                        If ApplicationState.Current.CorePage.UseAcceptProcessing Then
                            .IsEnabled = True
                        Else
                            .EnableForDesigner = Microsoft.VisualBasic.TriState.True
                        End If
                    Else
                        If _
                            ApplicationState.Current.CorePage.IsAppend AndAlso ApplicationState.Current.CorePage.Mode.ToString = "Change" AndAlso
                            Me.Display.ToString.ToUpper.IndexOf("ENTRY") < 0 AndAlso IsCurrentRow Then
                            .DisplayAsLabel = False
                            ' .CssClassTextBox = ""
                            If ApplicationState.Current.CorePage.UseAcceptProcessing Then
                                .IsEnabled = True
                            End If
                            .EnableForDesigner = Microsoft.VisualBasic.TriState.True
                        Else
                            .DisplayAsLabel = True
                            '.CssClassTextBox = "ROFieldValue"

                            If Not ApplicationState.Current.CorePage.UseAcceptProcessing Then
                                .EnableForDesigner = Microsoft.VisualBasic.TriState.False
                            End If
                        End If
                    End If
                End If
            End With
            m_blnCurrentRow = IsCurrentRow
        End Sub


        ''' --- ClearValues --------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of ClearValues.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Protected Friend Overridable Sub ClearValues()

            'This procedure is added to clear values 
            'in response to ClearControls Event raised in a Page.
            If Not (Me.Fixed = BooleanTypes.True) AndAlso Not Me.FixedValue Then
                Me.Text = Nothing
                Me.SubmittedValue = Nothing
                Me.OldSubmittedValue = Nothing
                Me.RequestValue = Nothing
                Me.OldText = ""
                Me.AcceptProcessingOldText = ""
                ValueChangedByUser = False
                invaliddate = False
            End If



        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Instantiates a new instance of a DateControl.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Sub New()
            MyBase.New()
            ' AddPreDateChildControls()


            SetResourceReference(StyleProperty, "CoreDateControl")

            DataType = DataTypes.Date

            'Dim format As String

            'If DateFormat <> "" OrElse ApplicationState.Current.DateFormat <> "" Then
            '    If DateFormat = "" Then
            '        format = ApplicationState.Current.DateFormat
            '    Else
            '        format = DateFormat
            '    End If

            '    Dim cultureInfo = New CultureInfo("en")
            '    Dim dateInfo = New DateTimeFormatInfo() With {
            '        .ShortDatePattern = format
            '    }
            '    cultureInfo.DateTimeFormat = dateInfo
            '    'Culture = cultureInfo





            'End If





        End Sub




        ''' --- AddPreDateChildControls --------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Adds the controls to the composite control.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Protected Sub AddPreDateChildControls()

            'Controls.Add(New System.Web.UI.LiteralControl("<Table border=0 ><TR><TD Align='Left' valign='top'>"))

        End Sub





        ' ''' --- LoadDefaultsFromDictionary -----------------------------------------
        ' ''' <exclude/>
        ' ''' 
        ' ''' <summary>
        ' ''' 	Summary of LoadDefaultsFromDictionary.
        ' ''' </summary>
        ' ''' <remarks>
        ' ''' </remarks>
        ' ''' <history>
        ' ''' 	[Campbell]	6/16/2005	Created
        ' ''' </history>
        ' ''' --- End of Comments ----------------------------------------------------
        '<EditorBrowsable(EditorBrowsableState.Advanced)> _
        'Public Overrides Sub LoadDefaultsFromDictionary()

        '    Dim objRange As RangeList = New RangeList
        '    Dim arrStrRange() As String
        '    Dim arrDblRange() As String
        '    Dim objDictionaryItem As CoreDictionaryItem

        '    ' Try...Catch is to ensure element exists.
        '    Try
        '        With ApplicationState.Current.CorePage
        '            objDictionaryItem = .GetDictionaryItem(Dictionary)
        '            If objDictionaryItem Is Nothing Then
        '                Exit Sub
        '            End If
        '            With objDictionaryItem

        '                ''TODO:Get Values from dictionary
        '                'If Me.Values Is Nothing Then
        '                '    Me.Values = .GetValues(Dictionary)
        '                'End If

        '                'Get the default value for "BWZ" from Dictionary
        '                If Me.BWZ = BooleanTypes.NotSet Then
        '                    If .BwzFlag Then
        '                        Me.BWZ = BooleanTypes.True
        '                    Else
        '                        Me.BWZ = BooleanTypes.False
        '                    End If
        '                End If

        '                'Get the default value for "DecimalPosition" from Dictionary

        '                'Get the default value for "ElementSize" from Dictionary

        '                'Get the default value for "UnderLyingDataType" from Dictionary
        '                If Me.UnderLyingDataType = DataTypes.NotSet Then
        '                    Me.UnderLyingDataType = .ItemDatatypeCode
        '                    '(Dictionary)
        '                End If

        '                'Get the default value for "DateFormat" from Dictionary
        '                SetDefaultValueForProperty(Me.DateFormat, .DateFormatCode)
        '                '(Dictionary))

        '                'Get the default value for "Heading" from Dictionary
        '                SetDefaultValueForProperty(Me.Heading, .Heading)
        '                '(Dictionary))

        '                'Get the default value for "Fill" from Dictionary
        '                SetDefaultValueForProperty(Me.Fill, .Fill)
        '                '(Dictionary))

        '                ''Get the default value for "Label" from Dictionary
        '                'SetDefaultValueForProperty(Me.Label, .Label)
        '                '(Dictionary))
        '                'If Me.Label = String.Empty AndAlso Me.FieldName.IndexOf(".") > 0 Then
        '                '    Me.Label = StrConv(Me.Dictionary.Replace("_", " "), VbStrConv.ProperCase)
        '                'End If

        '                'Get the default value for "ToolTip" from Dictionary
        '                SetDefaultValueForProperty(Me.ToolTip, .Help)
        '                '(Dictionary))

        '                'Get the default value for "Default" from Dictionary
        '                SetDefaultValueForProperty(Me.Default, .DefaultValue)
        '                '(Dictionary))

        '                'Get the default value for "InputScale" from Dictionary

        '                'Get the default value for "DataType" from Dictionary
        '                If Me.DataType = DataTypes.NotSet Then
        '                    Me.DataType = .ElementTypeCode
        '                    '(Dictionary)
        '                End If



        '                'Get the default value for "LeadingSign" from Dictionary
        '                SetDefaultValueForProperty(Me.LeadingSign, .LeadingSign)
        '                '(Dictionary))

        '                'Get the default value for "OutputScale" from Dictionary

        '                'Get the default value for "Pattern" from Dictionary
        '                SetDefaultValueForProperty(Me.Pattern, .PatternValue)
        '                '(Dictionary))

        '                'Get the default value for "Picture" from Dictionary
        '                SetDefaultValueForProperty(Me.Picture, .Picture)
        '                '(Dictionary))

        '                'Get the default value for "ShiftType" from Dictionary
        '                If Me.ShiftType = ShiftTypes.NotSet Then
        '                    Me.ShiftType = .ShiftInputCode
        '                End If

        '                'Get the default value for "Separator" from Dictionary
        '                SetDefaultValueForProperty(Me.Separator, .Separator)
        '                '(Dictionary))

        '                'Get the default value for "Significance" from Dictionary
        '                SetDefaultValueForProperty(Me.Significance, .Significance)
        '                '(Dictionary))

        '                'Get the default value for "TrailingSign" from Dictionary
        '                SetDefaultValueForProperty(Me.TrailingSign, .TrailingSign)
        '                '(Dictionary))

        '                'Get the default value for "Description" from Dictionary

        '                If .Values <> "" Then
        '                    arrStrRange = Split(.Values.Replace("(", "").Replace(")", ""), ",")
        '                    For i As Integer = 0 To UBound(arrStrRange)
        '                        If arrStrRange(i).IndexOf("-") <> -1 Then
        '                            arrDblRange = Split(arrStrRange(i), "-")
        '                            objRange.AddRange(CType(arrDblRange(0), Decimal), _
        '                                               CType(arrDblRange(1), Decimal))
        '                        Else
        '                            objRange.AddRange(CType(arrStrRange(i), Decimal))
        '                        End If
        '                    Next
        '                    Me.Values = objRange
        '                End If

        '            End With
        '            objDictionaryItem.Dispose()
        '            objDictionaryItem = Nothing
        '        End With

        '    Catch ex As Exception

        '        ' Do nothing.  Dictionary element doesn't exist.

        '    End Try

        'End Sub



#End Region

#Region "  Events  "

        ''' --- RaiseDataChanged ---------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of RaiseDataChanged.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Protected Friend Sub RaiseDataChanged()
            'At present used in case of Accept Processing
            RaiseEvent DataChanged(Me, EventArgs.Empty)
        End Sub

        ''' --- DataChanged --------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of DataChanged.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Event DataChanged(ByVal sender As Object, ByVal e As EventArgs)

      
        Private Sub menu_open() Handles Me.PreviewMouseRightButtonDown
             SetAcceptRequestPrompt = False
        End Sub

        Private Sub Blur() Handles Me.PreviewLostKeyboardFocus

            Dim elementWithFocus As UIElement = System.Windows.Input.Keyboard.FocusedElement
            If elementWithFocus.GetType.ToString = "System.Windows.Controls.Primitives.DatePickerTextBox" Then
                dpt = elementWithFocus
            End If

            If IsDropDownOpen OrElse Not IsEnabled OrElse ApplicationState.Current.Navigate Then
                Exit Sub
            End If

            If ApplicationState.Current.CorePage.NavigationType = NavigationTypes.Cancel Then
                Exit Sub
            End If

            If ApplicationState.Current.CorePage.HasError AndAlso ApplicationState.Current.CorePage.m_strRequestedControlFocusOverRide <> Me.Name Then
                Exit Sub
            End If

            If ApplicationState.Current.CorePage.HasError AndAlso ApplicationState.Current.CorePage.m_strRequestedControlFocusOverRide = Me.Name AndAlso Text = "" AndAlso ApplicationState.Current.CorePage.DateError Then

                Dim dt2 As DispatcherTimer = New Threading.DispatcherTimer()
                AddHandler dt2.Tick, AddressOf DateError
                dt2.Interval = New TimeSpan(0, 0, 0, 0, 20)
                dt2.Start()

                Exit Sub
            End If

            Dim strDateFormat = ApplicationState.Current.CorePage.GetDefaultDateFormat()

            If strDateFormat = "dd/MM/yyyy" Then

                If Text <> "" Then
                    If Text.Length <> 8 AndAlso Text.Length <> 10 AndAlso Text.IndexOf("/") = -1 Then
                        invaliddate = True
                    ElseIf Text.Length = 8 Then
                        Try
                            Dim check As Date = New DateTime(Text.Substring(4, 4), Text.Substring(2, 2), Text.Substring(0, 2))
                            Text = Text.Substring(0, 2) + "/" + Text.Substring(2, 2) + "/" + Text.Substring(4, 4)
                        Catch ex As Exception
                            invaliddate = True
                        End Try
                    ElseIf Text.Length = 10 Then
                        Try
                            Dim check As Date = New DateTime(Text.Substring(6, 4), Text.Substring(3, 2), Text.Substring(0, 2))
                            Text = Text.Substring(0, 2) + "/" + Text.Substring(3, 2) + "/" + Text.Substring(6, 4)
                        Catch ex As Exception
                            invaliddate = True
                        End Try
                    End If
                End If
            Else
                If Text <> "" Then
                    If Text.Length <> 8 AndAlso Text.Length <> 10 AndAlso Text.IndexOf("/") = -1 Then
                        invaliddate = True
                    ElseIf Text.Length = 8 Then
                        Try
                            Dim check As Date = New DateTime(Text.Substring(0, 4), Text.Substring(4, 2), Text.Substring(6, 2))
                            Text = Text.Substring(0, 4) + "/" + Text.Substring(4, 2) + "/" + Text.Substring(6, 2)
                        Catch ex As Exception
                            invaliddate = True
                        End Try
                    ElseIf Text.Length = 10 Then
                        Try
                            Dim check As Date = New DateTime(Text.Substring(0, 4), Text.Substring(5, 2), Text.Substring(8, 2))
                            Text = Text.Substring(0, 4) + "/" + Text.Substring(5, 2) + "/" + Text.Substring(8, 2)
                        Catch ex As Exception
                            invaliddate = True
                        End Try
                    End If
                End If
            End If



            If Not IsNothing(ApplicationState.Current.CorePage.RunningDesigner) Then
                ApplicationState.Current.CorePage.PageActionType = PageActionType.DesignerClick
                ApplicationState.Current.CorePage.NavigationType = NavigationTypes.None
            Else
                If ApplicationState.Current.CorePage.Mode = PageModeTypes.Entry Then
                    ApplicationState.Current.CorePage.NavigationType = NavigationTypes.Entry
                    ApplicationState.Current.CorePage.CallPerformOperation = True
                Else
                    ApplicationState.Current.CorePage.NavigationType = NavigationTypes.None
                End If
            End If

            Dim dt As DispatcherTimer = New Threading.DispatcherTimer()
            AddHandler dt.Tick, AddressOf OnBlur
            dt.Interval = New TimeSpan(0, 0, 0, 0, 20)
            dt.Start()

        End Sub

        Public Sub DateError(sender As Object, e As EventArgs)
            Dim dt = TryCast(sender, DispatcherTimer)
            If dt IsNot Nothing Then
                dt.[Stop]()
            End If
            dt = Nothing

            ApplicationState.Current.CorePage.DateError = False
            DirectCast(Me, DateControl).FindChildByType(Of System.Windows.Controls.Primitives.DatePickerTextBox)().Focus()
        End Sub


        Public Sub OnBlur(sender As Object, e As EventArgs)
            Dim dt = TryCast(sender, DispatcherTimer)
            If dt IsNot Nothing Then
                dt.[Stop]()
            End If
            dt = Nothing
                       

            Dim elementWithFocus As UIElement = System.Windows.Input.Keyboard.FocusedElement

            If Not IsNothing(elementWithFocus) AndAlso (elementWithFocus.GetType.ToString = "System.Windows.Controls.Primitives.DatePickerTextBox") Then
                If elementWithFocus.GetType.ToString = "System.Windows.Controls.Primitives.CalendarDayButton" Then

                    If DirectCast(elementWithFocus, System.Windows.Controls.Primitives.CalendarDayButton).ParentOfType(Of DateControl)().Name = Me.Name Then
                        Exit Sub
                    End If
                End If
                If DirectCast(elementWithFocus, System.Windows.Controls.Primitives.DatePickerTextBox).ParentOfType(Of DateControl)().Name = Me.Name Then
                    dpt = elementWithFocus
                    Exit Sub
                End If

            End If

            If Not IsNothing(elementWithFocus) AndAlso elementWithFocus.GetType().ToString = "Core.Windows.UI.Core.Windows.UI.DateControl" Then
                If DirectCast(elementWithFocus, DateControl).Name = Me.Name Then
                    Exit Sub
                End If
            End If

            If SetAcceptRequestPrompt = False AndAlso Text = OldText AndAlso Not invaliddate Then
                Exit Sub
            End If
            SetAcceptRequestPrompt = False

            If IsNothing(Text) Then
                Text = ""
            End If

            If (Text <> OldText) OrElse
                (Not Text Is Nothing AndAlso OldText Is Nothing) OrElse
                (Not OldText Is Nothing AndAlso Text Is Nothing) Then
                SubmittedValue = Text
                ValueChanged = True
                ValueChangedByUser = True
            End If

            If ApplicationState.Current.CorePage.ToolbarAction = ToolbarIcons.Cancel Then
                Exit Sub
            End If


            If (ApplicationState.Current.CorePage.RequireTerminate) Then
                Exit Sub
            End If





            If Not IsNothing(ApplicationState.Current.CorePage.RunningDesigner) Then
                ApplicationState.Current.CorePage.PageActionType = PageActionType.DesignerClick
                ApplicationState.Current.CorePage.Page_Load(ApplicationState.Current.CorePage.RunningDesigner)
            Else
                If ApplicationState.Current.CorePage.Mode = PageModeTypes.Entry Then
                    ApplicationState.Current.CorePage.NavigationType = NavigationTypes.Entry
                    ApplicationState.Current.CorePage.CallPerformOperation = True
                    If Me.Name.ToLower.StartsWith("fldgrd") Then
                        ApplicationState.Current.CorePage.PageActionType = PageActionType.DataListButtonClick
                        ApplicationState.Current.CorePage.NavigationType = NavigationTypes.None
                    End If
                    ApplicationState.Current.CorePage.Page_Load()
                Else
                    ApplicationState.Current.CorePage.Page_Load(Me)

                    If ApplicationState.Current.CorePage.m_colMessages.Count > 0 Then

                        Dim message As String
                        Dim autoclose As Boolean = True
                        Dim m As stcMessage
                        For Each m In ApplicationState.Current.CorePage.m_colMessages
                            message = message + m.Text
                            If m.Type = MessageTypes.Severe OrElse m.Type = MessageTypes.Error Then
                                autoclose = False
                            End If
                        Next


                        Try
                            ApplicationState.Current.CorePage.DisplayAlert(message, autoclose)                      
                        Catch ex As Exception                           
                            Throw ex
                        End Try

                        ApplicationState.Current.CorePage.m_colMessages = New ArrayList


                    End If
                End If

            End If

        End Sub

        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Sub DateControl_Loaded(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Loaded

            If Not IsNothing(ApplicationState.Current.CorePage) Then
                With ApplicationState.Current.CorePage
                    AddHandler .ClearControls, AddressOf ClearValues
                    AddHandler .ResetValueChanged, AddressOf ResetValueChanged
                    AddHandler .DisplayControl, AddressOf PageModeLogic

                End With
            End If

            If Not ApplicationState.Current.CorePage Is Nothing Then
                LoadValues()
                PageModeLogic()
            End If
        End Sub

        ''' --- ResetValueChanged --------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of ResetValueChanged.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Protected Overridable Sub ResetValueChanged(ByVal sender As Page, ByVal ClearTextValue As Boolean)

            If _
                (ClearTextValue AndAlso
                 Me.Name.IndexOf("$ctl" & sender.Occurrence.ToString.PadLeft(2, "0") & "$fldGrd") > 0) OrElse
                Not ClearTextValue Then
                Me.ValueChanged = False
                Me.OldSubmittedValue = Nothing
                Me.SubmittedValue = Nothing
                Me.AcceptProcessingOldText = Me.OldText
            End If

            ' When terminating append while on the first field, clear the values
            ' for the current row.
            If ClearTextValue Then
                If Me.Name.IndexOf("$ctl" & sender.Occurrence.ToString & "$fldGrd") > 0 Then
                    Me.Text = Nothing

                    Me.OldText = Nothing
                End If
            End If

        End Sub


        ''' --- DateControl_PreRender ----------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of DateControl_PreRender.
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
        Private Sub DateControl_PreRender(ByVal sender As Object, ByVal e As EventArgs) ' Handles MyBase.PreRender

            ' Add a onMouseOver attribute to the calendar image to ensure 
            ' that the cursor turns into a hand.
            m_btnButton.Attributes.Add("onMouseOver", "this.style.cursor = 'pointer';")
            m_btnButton.ID = "cal" + Me.RenderedID

            ' Add the Name attribute for AcceptProcessing.

        End Sub



#End Region
    End Class
End Namespace

