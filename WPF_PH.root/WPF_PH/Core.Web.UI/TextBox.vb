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

#End Region

Namespace Core.Windows.UI
    ''' ----------------------------------------------------------------------------
    ''' 
    ''' Class	: TextBox
    ''' 
    ''' ----------------------------------------------------------------------------
    ''' 
    ''' <summary>
    ''' 	This class defines the Renaissance Architect TextBox control.
    ''' </summary>
    ''' <remarks>
    '''     The Renaissance Architect TextBox control is an input control that allows
    '''     the user to enter text.
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/22/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <Bindable(True),
        Description("Container for all visual web controls that are generated in CORE's applications"),
        DefaultValue(""),
        EditorBrowsable(EditorBrowsableState.Advanced)>
    Public Class TextBox
        Inherits FieldObjectTextBox

#Region "  Private  "





        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        '''     This member supports the Renaissance Architect Framework infrastructure and 
        '''     is not intended to be used directly from your code.
        ''' </summary>
        ''' 
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Protected Friend m_blnCurrentRow As Boolean = False

        Private m_strValue As String = ""
        'Private m_lblLiteralSpace As New System.Web.UI.LiteralControl("&nbsp;")
        Protected m_blnEnabled As BooleanTypes = BooleanTypes.NotSet
        Private m_lptLabelPosition As LabelPositionTypes = LabelPositionTypes.NotSet
        Private m_blnRightJustify As BooleanTypes = BooleanTypes.NotSet
        Private m_intPopupWidth As Integer = 0
        Private m_intPopupHeight As Integer = 0
        Private m_intPopupLeft As Integer = 0
        Private m_intPopupTop As Integer = 0
        Private m_intItemSize As Integer = 0
        Private m_strLabel As String = ""
        Private m_strLookupCharacter As String = String.Empty
        Private m_blnUseLookupCharacter As Boolean
        Private m_strTargetUrl As String = ""
        Private m_intDecimal As Integer = 0
        Private m_blnIsLabel As Boolean = False
        <EditorBrowsable(EditorBrowsableState.Never)> Private m_blnHighlight As Boolean = False
        Public HighlightOccurence As Hashtable
        '--------------- 
        ' By default ViewState is disabled on Text Box Control; we also made other changes.
        ' We changed this during Performance Testing, to minimize the Total ViewState Size on a Page
        ' April 28, 2004 12:01:41 PM
        '--------------- 
        Private m_blnEnableViewState As Boolean = False



        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        '''     This member supports the Renaissance Architect Framework infrastructure and 
        '''     is not intended to be used directly from your code.
        ''' </summary>
        ''' 
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Public m_blnInFieldValidation As Boolean = True

        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        '''     This member supports the Renaissance Architect Framework infrastructure and 
        '''     is not intended to be used directly from your code.
        ''' </summary>
        ''' 
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Public m_blnIsGridControl As Boolean = False



#End Region

#Region " Constructors "

        ''' --- New ----------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Sub New()
            MyBase.New()
            'TabIndex = 0
            Visibility = Visible
            HorizontalAlignment = HorizontalAlignment.Left
            SetResourceReference(StyleProperty, "CoreTextBoxStyle")

        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Sub New(ByVal Variable As CoreCharacter)
            Bind(Variable)
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Sub New(ByVal Variable As CoreDecimal)
            Bind(Variable)
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Sub New(ByVal Variable As CoreInteger)
            Bind(Variable)
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Sub New(ByVal Variable As CoreBaseType)
            Bind(Variable)
        End Sub

#End Region

#Region "  Properties  "

        Public Shadows Property IsReadonly
            Get
                Return MyBase.IsReadOnly
            End Get
            Set(value)
                MyBase.IsReadOnly = value
                If MyBase.IsReadOnly Then
                    IsTabStop = False
                    SetResourceReference(StyleProperty, "DisableCoreTextBoxStyle")
                Else
                    IsTabStop = True
                    SetResourceReference(StyleProperty, "CoreTextBoxStyle")
                End If

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

        Private _OldText As String
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
        Private _AcceptProcessingOldText As String = ""


        ''' --- ItemSize ----------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	The item size of the value of the TextBox.
        ''' </summary>
        ''' <value>
        '''     An Integer representing the size of the value. The default
        '''     value is 0 indicating the property is not set.
        ''' </value>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False),
            EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Property ItemSize() As Integer
            Get

                Return m_intItemSize
            End Get
            Set(ByVal Value As Integer)

                m_intItemSize = Value
            End Set
        End Property



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




        ''' --- RightJustify -------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Contains the value whether to Right Justify the text within the control.
        ''' </summary>
        ''' <value>
        '''     One of the BooleanTypes. The default value is "NotSet" meaning the 
        '''     value will not be right justified.
        ''' </value>
        ''' <remarks>
        '''     Use the <B>RightJustify</B> property to set the alignment of the text
        '''     contained in the TextBox to be right justified.
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False),
            Description("Right justify the textbox."),
            Category("Core"),
            DefaultValue(GetType(BooleanTypes), "NotSet"),
            EditorBrowsable(EditorBrowsableState.Always)>
        Public Property RightJustify() As BooleanTypes
            Get
                Return m_blnRightJustify
            End Get
            Set(ByVal Value As BooleanTypes)
                m_blnRightJustify = Value

            End Set
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

        ''' --- PopupHeight --------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	The height of the Textbox popup window.
        ''' </summary>
        ''' <value>
        '''     An Integer representing the height of the popup window. 
        ''' </value>
        ''' <remarks>
        '''     <note>
        '''         A popup is only created if the PopupWidth or PopupHeight of the control
        '''         is > 0.
        '''     </note>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False),
            Description _
                (
                 "The height of the Textbox popup window.  Note: A popup is only created if PopupWidth or PopupHeight is > 0."),
            Category("Core"),
            DefaultValue(0),
            EditorBrowsable(EditorBrowsableState.Always)>
        Public Property PopupHeight() As Integer
            Get
                Return m_intPopupHeight
            End Get
            Set(ByVal Value As Integer)
                If Value < 0 Then
                    m_intPopupHeight = 0
                Else
                    m_intPopupHeight = Value
                End If

            End Set
        End Property

        ''' --- PopupWidth ---------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	The width of the Textbox popup window.
        ''' </summary>
        ''' <value>
        '''     An Integer representing the width of the popup window. 
        ''' </value>
        ''' <remarks>
        '''     <note>
        '''         A popup is only created if the PopupWidth or PopupHeight of the control
        '''         is > 0.
        '''     </note>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False),
            Description _
                (
                 "The width of the Textbox popup window.  Note: A popup is only created if PopupWidth or PopupHeight is > 0."),
            Category("Core"),
            DefaultValue(0),
            EditorBrowsable(EditorBrowsableState.Always)>
        Public Property PopupWidth() As Integer
            Get
                Return m_intPopupWidth
            End Get
            Set(ByVal Value As Integer)
                If Value < 0 Then
                    m_intPopupWidth = 0
                Else
                    m_intPopupWidth = Value
                End If

            End Set
        End Property

        ''' --- PopupLeft ----------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	The left location of the TextBox popup window.
        ''' </summary>
        ''' <value>
        '''     An Integer representing the left location of the popup window. 
        ''' </value>
        ''' <remarks>
        '''     <note>
        '''         A popup is only created if the PopupWidth or PopupHeight of the control
        '''         is > 0.
        '''     </note>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False),
            Description("The left location of the TextBox popup window."),
            Category("Core"),
            DefaultValue(0),
            EditorBrowsable(EditorBrowsableState.Always)>
        Public Property PopupLeft() As Integer
            Get
                Return m_intPopupLeft
            End Get
            Set(ByVal Value As Integer)
                If Value < 0 Then
                    m_intPopupLeft = 0
                Else
                    m_intPopupLeft = Value
                End If
            End Set
        End Property

        ''' --- PopupTop -----------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	The top location of the TextBox popup window.
        ''' </summary>
        ''' <value>
        '''     An Integer representing the top location of the popup window. 
        ''' </value>
        ''' <remarks>
        '''     <note>
        '''         A popup is only created if the PopupWidth or PopupHeight of the control
        '''         is > 0.
        '''     </note>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False),
            Description("The top location of the TextBox popup window."),
            Category("Core"),
            DefaultValue(0),
            EditorBrowsable(EditorBrowsableState.Always)>
        Public Property PopupTop() As Integer
            Get
                Return m_intPopupTop
            End Get
            Set(ByVal Value As Integer)
                If Value < 0 Then
                    m_intPopupTop = 0
                Else
                    m_intPopupTop = Value
                End If
            End Set
        End Property






        ''' --- Decimal ------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	The Decimal Value of the TextBox.
        ''' </summary>
        ''' <value>
        '''     An Integer representing a decimal value.
        ''' </value>
        ''' <remarks>
        '''     Use the <B>Decimal</B> property when using calculations requiring 
        '''     large numbers of significant integral and fractional digits 
        '''     and no round-off errors.
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False),
            Browsable(True),
            Description("The Decimal Value of the TextBox"),
            Category("Core"),
            DefaultValue(0),
            EditorBrowsable(EditorBrowsableState.Always)>
        Public Property [Decimal]() As Integer
            Get
                Return m_intDecimal
            End Get
            Set(ByVal Value As Integer)
                m_intDecimal = Value
            End Set
        End Property

        ''' --- IsLabel ------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Is the Text Box used as a Label.
        ''' </summary>
        ''' <value>
        '''     A boolean.
        ''' </value>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False),
            Description("Is the Text Box used as a Label."),
            Category("Core"),
            DefaultValue(GetType(BooleanTypes), "NotSet"),
            EditorBrowsable(EditorBrowsableState.Always)>
        Public Property IsLabel() As BooleanTypes
            Get
                Return m_blnIsLabel
            End Get
            Set(ByVal Value As BooleanTypes)
                m_blnIsLabel = Value
            End Set
        End Property

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




#End Region

#Region "  Methods  "



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
            Me.Text = ""
            Me.SubmittedValue = ""
            Me.OldSubmittedValue = ""
            Me.RequestValue = ""
            Me.OldText = ""
            Me.AcceptProcessingOldText = ""
            ValueChangedByUser = False



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
                Me.OldSubmittedValue = ""
                Me.SubmittedValue = ""
                Me.AcceptProcessingOldText = Me.OldText
            End If

            ' When terminating append while on the first field, clear the values
            ' for the current row.
            If ClearTextValue Then
                If Me.Name.IndexOf("$ctl" & sender.Occurrence.ToString & "$fldGrd") > 0 Then
                    Me.Text = ""
                    Me.OldText = ""
                End If
            End If

        End Sub



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
                    'SetDefaultValueForProperty(Me.ToolTip, "")

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

                    'Get the default value for "DecimalPosition" from Dictionary
                    Dim strDecimal As String
                    strDecimal =
                        CStr(.Item(CInt(Global.Core.Framework.Core.Framework.FieldAttributes.DecimalPosition)))
                    If Not (strDecimal Is Nothing OrElse strDecimal.Trim.Equals(String.Empty)) AndAlso Me.Decimal = 0 _
                        Then
                        Me.Decimal = CInt(strDecimal)
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

                    'Get the default value for "InputScale" from Dictionary, if it is not specified on Field
                    If Me.m_strInputScale Is Nothing Then
                        Me.m_strInputScale =
                            CType(.Item(CInt(Global.Core.Framework.Core.Framework.FieldAttributes.InputScale)),
                                String)

                        'Use the Decmal as the default value for "InputScale", if it is not specified on Field
                        If Me.m_strInputScale Is Nothing Then
                            Me.m_strInputScale = strDecimal
                        End If
                    End If

                    'Get the default value for "DataType" from Dictionary
                    If Me.DataType = DataTypes.NotSet Then
                        Me.DataType =
                            CType(.Item(CInt(Global.Core.Framework.Core.Framework.FieldAttributes.ElementTypeCode)),
                                DataTypes)
                    End If

                    'Get the default value for "MaxLength" from Dictionary
                    If Me.MaxLength = 0 Then
                        Me.MaxLength =
                            CInt(.Item(CInt(Global.Core.Framework.Core.Framework.FieldAttributes.ItemSize)))
                    End If

                    ' Get the ItemSize (physical size) from the dictionary.
                    Me.ItemSize = CInt(.Item(CInt(Global.Core.Framework.Core.Framework.FieldAttributes.ItemSize)))

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

                If Picture <> String.Empty Then
                    Dim intCount As Integer
                    If _
                        (LeadingSign.Length > 0 OrElse TrailingSign.Length > 0) AndAlso Picture.Length > 0 AndAlso
                        Picture.Trim.Length < Picture.Length Then intCount += 1
                    Dim intPictureLength As Integer = Occurs(Picture, "^")
                    If Picture.IndexOf(".") > 0 Then intPictureLength += 1
                    ' Add a space for the decimal position.
                    If MaxLength < (intPictureLength + intCount) Then
                        If MaxLength < intPictureLength Then MaxLength = intPictureLength

                        ' If we have a leading sign or trailing sign, then increment the maxlength by 1 if not accounted for
                        ' by the picture to ensure that the minus sign can be entered.
                        If _
                            (LeadingSign.Length > 0 OrElse TrailingSign.Length > 0) AndAlso
                            Not Me.UnderLyingDataType = ItemDataTypes.UnsignedNumeric Then
                            MaxLength += 1
                        End If
                    End If
                ElseIf Picture.Length = 0 Then
                    ' If we have a leading sign or trailing sign, then increment the maxlength by 1 
                    ' to ensure that the minus sign can be entered.
                    If LeadingSign.Length > 0 OrElse TrailingSign.Length > 0 Then
                        MaxLength += 1
                    End If
                End If

            Catch ex As Exception

                ' Do nothing.  Dictionary element doesn't exist.

            End Try

        End Sub

        ''' --- TextBox_Unload -----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Sub TextBox_Unload(ByVal sender As Object, ByVal e As EventArgs) 'Handles MyBase.Unload
            With ApplicationState.Current.CorePage
                RemoveHandler .ClearControls, AddressOf ClearValues
                RemoveHandler .ResetValueChanged, AddressOf ResetValueChanged
            End With

            m_lptLabelPosition = Nothing
            m_blnRightJustify = Nothing

        End Sub

#End Region

#Region "  Events  "

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

        ''' --- LoadOverrides ------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of LoadOverrides.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Sub LoadOverrides() Handles MyBase.LoadGlobalizationOverrides




            If Picture <> String.Empty Then
                Dim intCount As Integer
                If _
                    (LeadingSign.Length > 0 OrElse TrailingSign.Length > 0) AndAlso Picture.Length > 0 AndAlso
                    Picture.Trim.Length < Picture.Length Then intCount += 1
                Dim intPictureLength As Integer = Occurs(Picture, "^")
                If Picture.IndexOf(".") > 0 Then intPictureLength += 1
                ' Add a space for the decimal position.
                If MaxLength < (intPictureLength + intCount) Then
                    If MaxLength < intPictureLength Then MaxLength = intPictureLength

                    ' If we have a leading sign or trailing sign, then increment the maxlength by 1 if not accounted for
                    ' by the picture to ensure that the minus sign can be entered.
                    If (LeadingSign.Length > 0 OrElse TrailingSign.Length > 0) Then
                        MaxLength += 1
                    End If
                End If
            ElseIf Picture.Length = 0 Then
                ' If we have a leading sign or trailing sign, then increment the maxlength by 1 
                ' to ensure that the minus sign can be entered.
                If LeadingSign.Length > 0 OrElse TrailingSign.Length > 0 Then
                    MaxLength += 1
                End If
            End If

        End Sub


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


        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Sub TextBox_Loaded(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Loaded

            If Not IsNothing(ApplicationState.Current.CorePage) Then
                With ApplicationState.Current.CorePage
                    AddHandler .ClearControls, AddressOf ClearValues
                    AddHandler .ResetValueChanged, AddressOf ResetValueChanged
                    AddHandler .DisplayControl, AddressOf PageModeLogic
                    AddHandler .ClearValues, AddressOf RemoveValues

                End With
            End If

            If Not ApplicationState.Current.CorePage Is Nothing Then
                LoadValues()
                PageModeLogic()
            End If
        End Sub

        Private Sub HasFocus() Handles Me.GotFocus
            SelectAll()
        End Sub

        Private menuopen As Boolean = False
        Private Sub menu_open() Handles Me.PreviewMouseRightButtonDown
            SetAcceptRequestPrompt = False
        End Sub


        Private Sub Blur() Handles Me.PreviewLostKeyboardFocus

           
            If IsReadonly OrElse ApplicationState.Current.Navigate Then
                Exit Sub
            End If


            If SetAcceptRequestPrompt = False AndAlso Text = OldText Then
                Exit Sub
            End If
            SetAcceptRequestPrompt = False

            If Text <> OldText Then
                SubmittedValue = Text
                ValueChanged = True
                ValueChangedByUser = True
            End If

            If ApplicationState.Current.CorePage.HasError AndAlso (ApplicationState.Current.CorePage.m_strRequestedControlFocusOverRide <> "" AndAlso
                ApplicationState.Current.CorePage.m_strRequestedControlFocusOverRide <> Me.Name) Then
                Exit Sub
            End If

            If ApplicationState.Current.CorePage.NavigationType = NavigationTypes.Cancel Then
                Exit Sub
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

    
        Public Sub BlurFocus()
            If Text <> OldText Then
                SubmittedValue = Text
                ValueChanged = True
                ValueChangedByUser = True
            End If
            OnBlur(Nothing, Nothing)
           
        End Sub

        Public Sub OnBlur(sender As Object, e As EventArgs)
            Dim dt = TryCast(sender, DispatcherTimer)
            If dt IsNot Nothing Then
                dt.[Stop]()
            End If
            dt = Nothing



            Dim elementWithFocus As UIElement = System.Windows.Input.Keyboard.FocusedElement
            If ApplicationState.Current.CorePage.ToolbarAction = ToolbarIcons.Cancel Then
                Exit Sub
            End If

            'If elementWithFocus.GetType.ToString.IndexOf("Core") = -1 Then
            '    Exit Sub
            'End If

            If (ApplicationState.Current.CorePage.RequireTerminate) Then
                Exit Sub
            End If

            ApplicationState.Current.CorePage.ToolbarAction = ToolbarIcons.NotSet


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

        Private Sub RemoveValues()

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
                        .IsReadonly = True

                        '.CssClassTextBox = "ROFieldValue"
                        '''.TabIndex = -1

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
                                If Not IsReadonly Then
                                    SetResourceReference(StyleProperty, "CoreErrorTextBoxStyle")
                                    .Focus()
                                End If
                            Else
                                .IsReadonly = False
                                .Focus()
                            End If



                        Else

                            ' If the control has fixed = true then make the control Read-Only and
                            ' ignore the rest of the logic
                            ' NOTE: The OMIT setting is ignored in this case.
                            If .Fixed = BooleanTypes.True Then
                                .IsReadonly = True
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
                                            .IsReadonly = True
                                            ''.TabIndex = -1
                                        End If

                                    Case PageModeTypes.Change
                                        Select Case .EnableForDesigner
                                            Case Microsoft.VisualBasic.TriState.True
                                                .IsReadonly = False
                                                .DisplayAsLabel = False
                                                '.CssClassTextBox = ""
                                                'Case Microsoft.VisualBasic.TriState.False
                                                '    .EnableForDesigner = Microsoft.VisualBasic.TriState.False
                                                '    .IsReadonly = True
                                                '.CssClassTextBox = "ROFieldValue"
                                            Case Else
                                                If .NoChange = BooleanTypes.True And Not ApplicationState.Current.CorePage.AppendMode Then
                                                    .IsReadonly = True
                                                    '.CssClassTextBox = "ROFieldValue"
                                                Else
                                                    Select Case .Display
                                                        Case BehaviorTypes.Change, BehaviorTypes.ChangeEntryFind,
                                                            BehaviorTypes.ChangeEntry, BehaviorTypes.ChangeFind
                                                            .IsReadonly = True
                                                            ''.TabIndex = -1
                                                            '.CssClassTextBox = "ROFieldValue"
                                                        Case Else
                                                            If Me.IsOmitInEntry Then
                                                                'Display  this textbox as a label/ReadOnly
                                                                DisplayAsLabel = True
                                                            Else
                                                                .IsReadonly = False
                                                            End If
                                                    End Select
                                                End If
                                        End Select
                                        If .Omit = BehaviorTypes.Find Or .Omit = BehaviorTypes.EntryFind Then
                                            .IsReadonly = True
                                        ElseIf Not .Silent Then
                                            .Visibility = Visible
                                        ElseIf .Silent Then
                                            .Visibility = Collapsed
                                        End If

                                    Case PageModeTypes.Entry
                                        Select Case .EnableForDesigner
                                            Case Microsoft.VisualBasic.TriState.True
                                                .IsReadonly = False
                                                .DisplayAsLabel = False
                                                '.CssClassTextBox = ""
                                                'Case Microsoft.VisualBasic.TriState.False
                                                '    .EnableForDesigner = Microsoft.VisualBasic.TriState.False
                                                '    .IsReadonly = True
                                                '.CssClassTextBox = "ROFieldValue"
                                            Case Else
                                                If .NoEntry = BooleanTypes.True Then
                                                    .IsReadonly = True
                                                    ''.TabIndex = -1
                                                Else
                                                    Select Case .Display
                                                        Case BehaviorTypes.Entry, BehaviorTypes.EntryFind,
                                                            BehaviorTypes.ChangeEntry, BehaviorTypes.ChangeEntryFind
                                                            .IsReadonly = True
                                                            ''.TabIndex = -1
                                                        Case Else
                                                            .IsReadonly = False
                                                    End Select
                                                End If
                                        End Select
                                        If .Omit = BehaviorTypes.Entry Or .Omit = BehaviorTypes.EntryFind Then
                                            .IsReadonly = True
                                        ElseIf Not .Silent Then
                                            .Visibility = Visible
                                        ElseIf .Silent Then
                                            .Visibility = Collapsed
                                        End If

                                    Case PageModeTypes.Find
                                        Select Case .Display
                                            Case BehaviorTypes.Find, BehaviorTypes.EntryFind, BehaviorTypes.ChangeFind,
                                                BehaviorTypes.ChangeEntryFind
                                                .IsReadonly = True
                                                ''.TabIndex = -1
                                            Case Else
                                                .IsReadonly = False
                                                'If Not .m_blnBypassPageModeLogic Then .[ReadOnly] = False
                                        End Select

                                        If .Omit = BehaviorTypes.Find Or .Omit = BehaviorTypes.EntryFind Then
                                            .IsReadonly = True
                                        ElseIf Not .Silent Then
                                            .Visibility = Visible
                                        ElseIf .Silent Then
                                            .Visibility = Collapsed
                                        End If

                                    Case PageModeTypes.Select
                                        Dim strFile As String = .FieldName
                                        If strFile.IndexOf(".") > 0 Then
                                            strFile = strFile.Substring(0, strFile.IndexOf("."))
                                        Else
                                            strFile = ""
                                        End If

                                        If .NoSelect = BooleanTypes.True OrElse strFile <> ApplicationState.Current.CorePage.PrimaryFile Then
                                            .IsReadonly = True
                                            '.CssClassTextBox = "ROFieldValue"
                                            ''.TabIndex = -1
                                        End If

                                        If .Omit = BehaviorTypes.Find Or .Omit = BehaviorTypes.EntryFind Then
                                            .IsReadonly = True
                                        ElseIf Not .Silent Then
                                            .Visibility = Visible
                                        ElseIf .Silent Then
                                            .Visibility = Collapsed
                                        End If

                                    Case Else
                                        .IsReadonly = True
                                        '.CssClassTextBox = "ROFieldValue"
                                        ''.TabIndex = -1
                                        If Not .Silent Then
                                            .Visibility = Visible
                                        ElseIf .Silent Then
                                            .Visibility = Collapsed
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
                                            .Text = ""
                                        End If

                                End Select
                            End If

                            If .DisplayAsLabel Then

                                .IsReadonly = True

                                '.CssClassTextBox = "ROFieldValue"
                                ''.TabIndex = -1

                            Else
                                'This must be done to overcome viewstate
                                'to reset to original values
                                '.InFieldValidation = .m_blnInFieldValidation
                                ' If the ID starts with "fnc", it's a action menu dropdown.  Don't set 
                                '' the tab index.
                                'If .ID.StartsWith("fnc") Then
                                '    ''.TabIndex = -1
                                '    If .AccessKey.Length > 0 Then
                                '        If Page.m_strActionDropdowns.Length > 0 Then Page.m_strActionDropdowns &= "~"
                                '        Page.m_strActionDropdowns &= .AccessKey & "|" & .m_txtTextBox.UniqueID
                                '    End If
                                'Else
                                '    .TabIndex = .m_intTabIndex
                                'End If
                            End If
                        End If

                        If .Visibility = Visible And Not .IsReadonly And Not .DisplayAsLabel Then
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


            If Me.DataType = DataTypes.Numeric Then
                RightJustify = BooleanTypes.True
                TextAlignment = TextAlignment.Right
            End If

            If _
                (Not ApplicationState.Current.CorePage.UseAcceptProcessing OrElse
                 (ApplicationState.Current.CorePage.UseAcceptProcessing AndAlso (ApplicationState.Current.CorePage.EnableNumberedDesigners OrElse Me.SetAcceptRequestPrompt))) _
                Then

                If _
                    (m_intPopupHeight > 0 Or m_intPopupWidth > 0) And (Not IsReadonly) And (Me.Visibility = Visible) And
                    (Not (Me.Silent = BooleanTypes.True)) Then
                    Dim objOnEvent As New StringBuilder("")


                End If
            End If

            ' Add the code to generate the SetLookupValue.
            If UseLookupCharacter AndAlso ApplicationState.Current.CorePage.Mode <> PageModeTypes.NoMode AndAlso (Not Me.IsReadonly) Then
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
                If Fixed OrElse IsLabel Then
                    SetResourceReference(StyleProperty, "LabelCoreTextBoxStyle")
                Else
                    If IsReadonly Then
                        SetResourceReference(StyleProperty, "DisableCoreTextBoxStyle")
                    ElseIf Required AndAlso ApplicationState.Current.CorePage.Mode <> PageModeTypes.Find AndAlso
                        ApplicationState.Current.CorePage.Mode <> PageModeTypes.NoMode Then
                        SetResourceReference(StyleProperty, "CoreRequiredTextBoxStyle")
                    Else
                        SetResourceReference(StyleProperty, "CoreTextBoxStyle")
                    End If

                End If

            End If

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
                        .IsReadonly = True
                        .EnableForDesigner = Microsoft.VisualBasic.TriState.False

                    End If
                    objDesigner = Nothing
                Else

                    If ClearContent Then .ClearValues()
                    If IsCurrentRow AndAlso Me.Display.ToString.ToUpper.IndexOf(ApplicationState.Current.CorePage.Mode.ToString.ToUpper) < 0 Then
                        .DisplayAsLabel = False
                        ' .CssClassTextBox = ""
                        If ApplicationState.Current.CorePage.UseAcceptProcessing Then
                            .IsReadonly = False
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
                                .IsReadonly = False
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

        ''' --- GetLookupCharacter -------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of GetLookupCharacter.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/22/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Friend Function GetLookupCharacter() As String
            If Me.UseLookupCharacter Then
                Return Me.LookupCharacter

            Else
                Return String.Empty
            End If
        End Function

#End Region

        Private Function OnBlur() As Object
            Throw New NotImplementedException
        End Function

    End Class

End Namespace
