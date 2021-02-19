#Region "  Imports  "

Imports System
Imports System.IO
Imports System.Windows.Controls
Imports System.ComponentModel
Imports Core.Framework.Core.Framework
Imports Core.Framework.Core.Framework.QDesign
Imports Core.Globalization
Imports Core.ExceptionManagement

#End Region


Namespace Core.Windows.UI

    ''' -----------------------------------------------------------------------------
    ''' Project	 : Core.Windows.UI
    ''' Class	 : Web.UI.FieldObjectBase
    ''' 
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    '''     Container for all visual web controls that are generated in CORE's applications.
    ''' </summary>
    ''' <remarks>
    '''     The FieldObjectBase is the base class used for the Renaissance Architect 
    '''     server controls.  
    ''' </remarks>
    ''' <history>
    ''' 	[Chris]	05/04/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <Bindable(True), _
    Description("Container for all visual web controls that are generated in CORE's applications"), _
    DefaultValue(""), _
    EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
    Public MustInherit Class FieldObjectBase
        Inherits UserControl
        Implements IFieldObject

#Region "  Private  "

        'Private m_lblLabel As New System.Web.UI.WebControls.Label
        Private m_intDataType As DataTypes = DataTypes.NotSet
        Private m_blnBWZ As BooleanTypes = BooleanTypes.NotSet
        Private m_blnAutoNext As BooleanTypes = BooleanTypes.NotSet
        Private m_blnUseDictionary As Boolean = False
        Private m_strFieldName As String = String.Empty
        Private m_strDatabaseName As String = String.Empty
        Private m_strTableName As String = String.Empty
        Private m_strColumnName As String = String.Empty
        Private m_strDictionary As String = String.Empty
        Private m_strFieldID As String = String.Empty
        Private m_intShiftCase As ShiftTypes = ShiftTypes.NotSet

        Private m_strLeadingSign As String = String.Empty
        Private m_strFill As String = String.Empty
        Private m_blnVisible As BooleanTypes = BooleanTypes.NotSet
        'Private m_lptLabelPosition As LabelPositionTypes = LabelPositionTypes.NotSet
        Private m_strFloat As String = String.Empty
        Private m_strTrailingSign As String = String.Empty
        Private m_blnRequired As BooleanTypes = BooleanTypes.NotSet
        Private m_blnChoose As Boolean = False
        Private m_BehDisplay As BehaviorTypes = BehaviorTypes.NotSet
        Private m_BehOmit As BehaviorTypes = BehaviorTypes.NotSet
        Private m_blnNoChange As BooleanTypes = BooleanTypes.NotSet
        Private m_blnNoCorrect As BooleanTypes = BooleanTypes.NotSet
        Private m_blnNoEntry As BooleanTypes = BooleanTypes.NotSet
        Private m_blnNoSelect As BooleanTypes = BooleanTypes.NotSet
        Private m_blnPreDisplay As BooleanTypes = BooleanTypes.NotSet
        Private m_blnNoWarn As BooleanTypes = BooleanTypes.NotSet
        Private m_blnDuplicate As BooleanTypes = BooleanTypes.NotSet
        Private m_blnFixed As BooleanTypes = BooleanTypes.NotSet
        Private m_blnFixedValue As Boolean = False
        Private m_blnSilent As BooleanTypes = BooleanTypes.NotSet
        Private m_blnHidden As BooleanTypes = BooleanTypes.NotSet
        Private m_strDefault As String = String.Empty
        Private m_strEntryIf As String = String.Empty
        Private m_blnUnderLyingDataTypes As DataTypes
        Private m_strPattern As String = String.Empty
        Private m_strPicture As String = String.Empty
        Private m_blnIsDefine As Boolean = False
        Private intRow As Integer


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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Protected m_strInputScale As String

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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Protected m_strOutputScale As String

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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Protected m_strSignificance As String

        Private m_triUseScaling As TriState = TriState.UseDefault

        Private m_strToolTip As String = String.Empty
        'Public m_colDictionaryOverride As New Collections.Specialized.StringDictionary
        Private m_blnDisplayAsLabel As Boolean = False
        Private m_blnNoLabel As Boolean = False
        Private m_blnRefresh As Boolean = False
        Private m_strHeading As String = String.Empty
        Private m_objValues As RangeList
        Private m_strValues As String
        Private m_blnTemplateElement As Boolean = False

        ' AcceptProcessing members.
        Private m_blnRequestWasPerformed As Boolean = False
        Private m_blnRequestPromptOK As Boolean = False
        Private m_blnSetAcceptRequestPrompt As Boolean = False  ' Field has the Accept/Request/Prompt being executed on it.
        Private m_blnValueChangedByUser As Boolean = False      ' The value for this field was changed by the user. (Non-persistent compared to ValueChanged)
        Private m_blnIsDesignerAccept As Boolean = False        ' Used for AcceptProcessing to indicate that this field is an ACCEPT within a Designer procedure.

        ' Used for AcceptProcessing to indicate that this field has just had a DISPLAY done.  This will be used
        ' by the Validate to then use SubmittedValue instead of the text value, as the DISPLAY may have changed
        ' the text value.
        Private m_blnDisplayExecuted As Boolean = False

        ' Used to indicate this field's record buffer is a received value.
        Private m_blnIsReceived As Boolean = False

        Protected Friend m_IsBoundToTemporary As Boolean
#End Region

#Region "  Properties  "

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
        <Bindable(False), _
        Browsable(False), _
        DefaultValue(False), _
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Friend Property IsReceived() As Boolean
            Get
                Return m_blnIsReceived
            End Get
            Set(ByVal Value As Boolean)
                m_blnIsReceived = Value
            End Set
        End Property

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
        <Bindable(False), _
        Browsable(False), _
        DefaultValue(False), _
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Friend Property IsDefine() As Boolean
            Get
                Return m_blnIsDefine
            End Get
            Set(ByVal Value As Boolean)
                m_blnIsDefine = Value
            End Set
        End Property

        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        '''     Stores whether the Display method was executed on this field during the current
        '''     postback.
        ''' </summary>
        ''' <value></value>
        ''' <remarks>
        '''     This value is set internally by the framework and indicates that during the
        '''     current postback, the Display method was executed on the current field.  
        ''' </remarks>
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <Bindable(False), _
        Browsable(False), _
        DefaultValue(False), _
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Friend Property DisplayExecuted() As Boolean
            Get
                Return m_blnDisplayExecuted
            End Get
            Set(ByVal Value As Boolean)
                m_blnDisplayExecuted = Value
            End Set
        End Property

        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        '''     Indicates that this field is receiving focus due to an Accept, RequestPrompt 
        '''     method.
        ''' </summary>
        ''' <value></value>
        ''' <remarks>
        '''     The <B>SetAcceptRequestPrompt</B> property is set internally by the framework.  
        '''     It is used to ensure that the proper postback event is generated for this field.
        ''' </remarks>
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <Bindable(False), _
        Browsable(False), _
        DefaultValue(False), _
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Friend Property SetAcceptRequestPrompt() As Boolean
            Get
                Return m_blnSetAcceptRequestPrompt
            End Get
            Set(ByVal Value As Boolean)
                m_blnSetAcceptRequestPrompt = Value
            End Set
        End Property

        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        '''     Indicates that this field is an Accept field on a named designer.
        ''' </summary>
        ''' <value></value>
        ''' <remarks>
        '''     The <B>IsDesignerAccept</B> property is used to indicate that an Accept method is used
        '''     on this field using a named designer procedure.  This ensures that the field
        '''     becomes enabled during the execution of the designer.
        ''' </remarks>
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <Bindable(False), _
        Browsable(False), _
        DefaultValue(False), _
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Property IsDesignerAccept() As Boolean
            Get
                Return m_blnIsDesignerAccept
            End Get
            Set(ByVal Value As Boolean)
                m_blnIsDesignerAccept = Value
            End Set
        End Property

        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        '''     Indicates that a Request/Prompt was performed on the current field.  
        ''' </summary>
        ''' <value></value>
        ''' <remarks>
        '''     The <B>RequestWasPerformed</B> property is used internally to indicate that 
        '''     a Request/Prompt method was executed against the current field.
        ''' </remarks>
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <Bindable(False), _
        Browsable(False), _
        DefaultValue(""), _
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Property RequestWasPerformed() As Boolean
            Get
                Return m_blnRequestWasPerformed
            End Get
            Set(ByVal Value As Boolean)
                m_blnRequestWasPerformed = Value
            End Set
        End Property

        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        '''     Stores the value for PromptOK for the first request.
        ''' </summary>
        ''' <value></value>
        ''' <remarks>
        '''     The <B>RequestPromptOK</B> property indicates the PromptOK value for the 
        '''     first request performed during a given iteration.  Subsequent Requests
        '''     executed will use this value for PromptOK.
        ''' </remarks>
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <Bindable(False), _
        Browsable(False), _
        DefaultValue(""), _
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Friend Property RequestPromptOk() As Boolean
            Get
                Return m_blnRequestPromptOK
            End Get
            Set(ByVal Value As Boolean)
                m_blnRequestPromptOK = Value
            End Set
        End Property


        ''' --- FieldID ------------------------------------------------------------
        '''
        ''' <summary>
        '''     The numbered designer that executes on this field. (ie. Designer_02).
        ''' </summary>
        ''' <value>
        '''     A String containing the ID of the current Field.
        ''' </value>
        ''' <remarks>
        '''     Use the <B>FieldID</B> property to indicate which default designer procedure
        '''     will execute against a specific field.  Multiple fields with the same FieldID
        '''     value will be executed as a block.  For screens without a grid, this property
        '''     will be blank if no numbered designer procedure is coded.
        ''' </remarks>
        ''' <example></example>
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False), _
        Description("The numbered designer that executes on this field (ie. Designer_02)."), _
        Category("Core"), _
        DefaultValue(""), _
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Property FieldID() As String Implements IFieldObject.FieldID
            Get
                Return m_strFieldID
            End Get
            Set(ByVal Value As String)
                m_strFieldID = Value
            End Set
        End Property

        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        '''     Stores the value that is currently in the field and uses this value as the 
        '''     OldValue.
        ''' </summary>
        ''' <value></value>
        ''' <remarks>
        '''     The <B>SubmittedValue</B> property is used internally by the framework.  This
        '''     property stores the value that was entered in the field.  
        ''' </remarks>
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <Bindable(False), _
        Browsable(False), _
        DefaultValue(""), _
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Friend Property SubmittedValue() As String
            Get
                Return String.Empty
            End Get
            Set(ByVal Value As String)

            End Set
        End Property

        Private m_MultiAccept As Boolean = False
        <Bindable(False), _
        Browsable(False), _
        DefaultValue(""), _
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Property MultiAccept() As Boolean
            Get
                Return m_MultiAccept
            End Get
            Set(ByVal Value As Boolean)
                m_MultiAccept = Value
            End Set
        End Property

        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        '''     Stores the value that was in submitted value to replace an invalid value 
        '''     if an error occurs (using the ErrorMessage or Severe methods).
        ''' </summary>
        ''' <value></value>
        ''' <remarks>
        '''     The <B>OldSubmittedValue</B> property is used internally by the framework.  
        '''     This property resets the value to the field if an error is thrown (using the
        '''     ErrorMessage or Severe methods).
        ''' </remarks>
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <Bindable(False), _
        Browsable(False), _
        DefaultValue(""), _
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Friend Property OldSubmittedValue() As String
            Get
                Return String.Empty
            End Get
            Set(ByVal Value As String)

            End Set
        End Property

        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        '''     Stores the value that was entered in the field in Find mode using the 
        '''     RequestPrompt method.
        ''' </summary>
        ''' <value></value>
        ''' <remarks>
        '''     The <B>RequestValue</B> property is used internally by the framework.  This
        '''     property stores the Request value that was entered during the Find phase.  
        '''     Subsequent Requests during this Find iteration will use this value.
        ''' </remarks>
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <Bindable(False), _
        Browsable(False), _
        DefaultValue(""), _
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Property RequestValue() As String
            Get
                Return String.Empty
            End Get
            Set(ByVal Value As String)

            End Set
        End Property

        ''' --- FieldName ----------------------------------------------------------
        '''
        ''' <summary>
        '''     Variable name or element name of the field.  For elements, this will be in the 
        '''     format TableName.ElementName.
        ''' </summary>
        ''' <value>
        '''     A String containing the variable or element name to assign to control.
        ''' </value>
        ''' <remarks>
        '''     Use the <B>FieldName</B> property to set the name of the field using the variable
        '''     or element name.  For fields that are based on elements from the database, 
        '''     the syntax will be Tablename.ElementName.  This property is used to retrieve the 
        '''     appropriate dictionary information (only for elements).
        ''' </remarks>
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False), _
        Description("Variable name or element name of the field.  For elements, this will be in the format TableName.ElementName, and is used by the dictionary."), _
        Category("Core"), _
        DefaultValue(""), _
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Property FieldName() As String Implements IFieldObject.FieldName
            Get


                Return m_strFieldName
            End Get
            Set(ByVal Value As String)

                Try

                    m_strFieldName = Value.Trim
                    Dim arrFieldName() As String
                    arrFieldName = m_strFieldName.Split("."c)
                    With arrFieldName
                        Select Case .GetUpperBound(0)
                            Case 0  ' Assumed Temporary Field
                                m_strDatabaseName = .GetValue(0)

                                If m_blnUseDictionary Then
                                    m_strDictionary = m_strDatabaseName.ToUpper
                                End If
                            Case 1  ' Assumed TableName and ColumnName
                                m_strTableName = .GetValue(0).ToString.Trim.ToUpper
                                m_strColumnName = .GetValue(1).ToString.Trim.ToUpper
                                m_strDictionary = m_strColumnName
                            Case 2  ' Assumed Database, TableName and ColumnName
                                m_strDatabaseName = .GetValue(0).ToString.Trim.ToUpper
                                m_strTableName = .GetValue(1).ToString.Trim.ToUpper
                                m_strColumnName = .GetValue(2).ToString.Trim.ToUpper
                                m_strDictionary = m_strDatabaseName + "." + m_strColumnName
                        End Select
                    End With
                    arrFieldName = Nothing

                Catch ex As Exception
                    m_strFieldName = String.Empty
                    m_strDatabaseName = String.Empty
                    m_strTableName = String.Empty
                    m_strDictionary = String.Empty
                End Try
                m_strFieldName = Value.Trim
            End Set
        End Property

        ''' --- Refresh ----------------------------------------------------------
        '''
        ''' <summary>
        '''     If Refresh is set to True the field will Refresh after a runscreen call.
        ''' </summary>
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False), _
        Description("If Refresh is set to True the field will Refresh after a runscreen call."), _
        Category("Core"), _
        DefaultValue(""), _
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Property Refresh() As Boolean
            Get
                Return m_blnRefresh
            End Get
            Set(ByVal Value As Boolean)
                m_blnRefresh = Value
            End Set
        End Property




        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        '''     TableName of the control. 
        ''' </summary>
        ''' <value></value>
        ''' <remarks>
        '''     The <B>TableName</B> property is used internally in the framework, and is 
        '''     determined from the <B>FieldName</B> property.  This property will be blank
        '''     if the field is based on a variable, and will contain the name of the table
        '''     if the field is based on an element in the database.
        ''' </remarks>
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <Bindable(False), _
        Description("TableName of the Textbox.  Read-Only property."), _
        Browsable(False), _
        DefaultValue(""), _
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Friend ReadOnly Property TableName() As String Implements IFieldObject.TableName
            Get

                Return m_strTableName
            End Get
        End Property

        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        '''     Dictionary element used by this control. This is a Read-Only property.
        ''' </summary>
        ''' <value></value>
        ''' <remarks>
        '''     The <B>Dictionary</B> property is used internally by the framework to indicate
        '''     the dictionary element to use for this field.  This value is dependant on the
        '''     value in FieldName, and is blank if the field is based on a variable.
        ''' </remarks>
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <Bindable(False), _
        Description("Dictionary of the Textbox. Read-Only property."), _
        Browsable(False), _
        DefaultValue(""), _
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Friend ReadOnly Property Dictionary() As String Implements IFieldObject.Dictionary
            Get

                Return m_strDictionary
            End Get
        End Property

        ''' --- DataType -----------------------------------------------------------
        '''
        ''' <summary>
        '''     DataType of the field (Character, Numeric or Date).
        ''' </summary>
        ''' <value>
        '''     One of the allowable DataTypes, either a Character, Numeric or Date.
        ''' </value>
        ''' <remarks>
        '''     Use the <B>Datatype</B> property to indicate how the field should be validated
        '''     and formatted.  
        ''' </remarks>
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False), _
        Description("DataType of the field (Character, Numeric or Date). "), _
        Category("Core"), _
        DefaultValue(GetType(DataTypes), "NotSet"), _
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Overridable Property DataType() As DataTypes Implements IFieldObject.DataType
            Get

                Return m_intDataType
            End Get
            Set(ByVal Value As DataTypes)

                m_intDataType = Value
            End Set
        End Property

        ''' --- InputScale --------------------------------------------------------
        '''
        ''' <summary>
        '''     Specifies the input scale to use for entered values (numeric fields only).
        ''' </summary>
        ''' <value>
        '''     A String representing a numeric value.
        ''' </value>
        ''' <remarks>
        '''     Use the <B>InputScale</B> property to set the scaling factor that is to be
        '''     used when values are entered for numeric items.
        ''' </remarks>
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False), _
        Description("Specifies the input scale to use for entered values (numeric fields only)."), _
        Category("Core"), _
        Browsable(True), _
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Property InputScale() As String Implements IFieldObject.InputScale
            Get

                Return m_strInputScale
            End Get
            Set(ByVal Value As String)

                If Value Is Nothing OrElse Value.Trim = String.Empty Then
                    m_strInputScale = Nothing
                ElseIf IsNumeric(Value) Then
                    m_strInputScale = Value.Trim
                End If
            End Set
        End Property

        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        '''     If set to True, applies scaling defined on "InputScale" and "OutputScale", 
        '''     this setting will override the Application Level Setting "UseScaling".
        ''' </summary>
        ''' <value></value>
        ''' <remarks>
        '''     The default value is "UseDefault" which will use Application Level Setting 
        '''     "UseScaling".
        ''' </remarks>
        ''' <history>
        ''' 	[Mayur]	06/24/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <Bindable(False), _
        Description("Specified whether to use InputScale and OutputScale defined or field or not."), _
        Category("Core"), _
        DefaultValue(GetType(TriState), "UseDefault"), _
        Browsable(True), _
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Property UseScaling() As TriState
            Get

                If m_triUseScaling = TriState.UseDefault Then
                    If ApplicationState.Current.CorePage.UseScaling Then
                        m_triUseScaling = TriState.True
                    Else
                        m_triUseScaling = TriState.False
                    End If
                End If
                Return m_triUseScaling
            End Get
            Set(ByVal Value As TriState)

                m_triUseScaling = Value
            End Set
        End Property

        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <history>
        ''' 	[Campbell]	06/24/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Friend Function GetInputScale() As Int32
            If Me.m_strInputScale Is Nothing OrElse Me.m_strInputScale.Trim.Length = 0 Then
                Return 0
            Else
                Return CInt(Me.m_strInputScale)
            End If
        End Function

        ''' --- OutputScale --------------------------------------------------------
        '''
        ''' <summary>
        '''     Specifies the output scaling to use for displayed values (numeric fields only).
        ''' </summary>
        ''' <value>
        '''     A String representing a numeric value.
        ''' </value>
        ''' <remarks>
        '''     Use the <B>OutputScale</B> property to set the output scaling factor.  The value 
        '''     to be displayed will be scaled by this factor.
        '''     <para>
        '''         <note>
        '''             This property can only be applied to numeric fields.
        '''         </note>
        '''     </para>
        ''' </remarks>
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False), _
        Description("Specifies the output scaling to use for displayed values (numeric fields only)."), _
        Category("Core"), _
        Browsable(True), _
        DefaultValue(0), _
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Property OutputScale() As String Implements IFieldObject.OutputScale
            Get

                Return m_strOutputScale
            End Get
            Set(ByVal Value As String)

                If Value Is Nothing OrElse Value.Trim = String.Empty Then
                    m_strOutputScale = Nothing
                ElseIf IsNumeric(Value) Then
                    m_strOutputScale = Value.Trim
                End If
            End Set
        End Property

        ''' --- GetOutputScale -----------------------------------------------------
        ''' <exclude/>
        '''
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Friend Function GetOutputScale() As Int32
            If Me.m_strOutputScale Is Nothing OrElse Me.m_strOutputScale.Trim.Length = 0 Then
                Return 0
            Else
                Return CInt(Me.m_strOutputScale)
            End If
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        '''     Specifies the range(s) of acceptable values for a field.
        ''' </summary>
        ''' <value>
        '''     Example: A-D,H-L<br/>
        '''              1-10,15,20
        ''' </value>
        ''' <remarks>
        '''     The <B>Values</B> property is used internally by the framework.  The 
        '''     <B>FieldValues</B> property (which has validation code) is used as the basis 
        '''     for this property.  This property uses a RangeList to allow easy access to 
        '''     the values stored. <br/><br/>
        '''     <note>
        '''         Use the <B>FieldValues</B> property to set the specified values.  
        '''     </note>
        ''' </remarks>
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <Bindable(False), _
        Description("Specifies the range(s) of acceptable values for a field."), _
        Category("Core"), _
        Browsable(False), _
        DefaultValue(""), _
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Friend Overridable Property Values() As RangeList
            Get

                Return m_objValues
            End Get
            Set(ByVal Value As RangeList)

                m_objValues = Value
            End Set
        End Property

        ''' --- FieldValues -------------------------------------------------------
        '''
        ''' <summary>
        '''     Specifies the range(s) of acceptable values for a field.
        ''' </summary>
        ''' <value>
        '''     A String representing a range of values.
        ''' </value>
        ''' <remarks>
        '''     Use the <B>FieldValues</B> property to list a set of valid values that can be 
        '''     entered into the current field.  The value entered by the user will then be 
        '''     checked against this list to verify that a valid value was entered.  
        ''' </remarks>
        ''' <example>
        '''     <para>
        '''         A-D,H-L
        '''     </para>
        '''     <para>
        '''         1-10,15,20
        '''     </para>
        ''' </example>
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False), _
        Description("Specifies the range(s) of acceptable values for a field."), _
        Category("Core"), _
        Browsable(True), _
        DefaultValue(""), _
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Overridable Property FieldValues() As String
            Get
                Return m_strValues
            End Get
            Set(ByVal Value As String)
                Dim arrStrRange() As String
                Dim arrDblRange() As String
                Dim objRange As RangeList = New RangeList
                If Me.DataType = DataTypes.Numeric Then
                    If Not Value Is Nothing AndAlso Not Value.Trim.Equals(String.Empty) Then
                        arrStrRange = Split(Value.Replace("(", "").Replace(")", ""), ",")
                        For i As Integer = 0 To UBound(arrStrRange)
                            If arrStrRange(i).IndexOf("-", 1) > 0 Then
                                If arrStrRange(i).IndexOf("-") = 0 Then  ' First value is negative.
                                    arrDblRange = Split(arrStrRange(i).Substring(1), "-")
                                    objRange.AddRange(CType("-" + arrDblRange(0), Decimal), CType(arrDblRange(1), Decimal))
                                Else
                                    arrDblRange = Split(arrStrRange(i), "-")
                                    objRange.AddRange(CType(arrDblRange(0), Decimal), CType(arrDblRange(1), Decimal))
                                End If
                            Else
                                objRange.AddRange(CType(arrStrRange(i), Decimal))
                            End If
                        Next
                    End If
                Else
                    arrStrRange = Split(Value.Replace("(", "").Replace(")", ""), ",")
                    For i As Integer = 0 To UBound(arrStrRange)
                        If arrStrRange(i).IndexOf("-") <> -1 Then
                            arrDblRange = Split(arrStrRange(i), "-")
                            If arrDblRange(0).ToString.Length = 0 Then
                                objRange.AddRange(" ", arrDblRange(1))
                            Else
                                objRange.AddRange(arrDblRange(0), arrDblRange(1))
                            End If
                        Else
                            objRange.AddRange(arrStrRange(i))
                        End If
                    Next
                End If
                m_strValues = Value
                Values = objRange
            End Set
        End Property

       

        ''' --- BWZ ---------------------------------------------------------------
        '''
        ''' <summary>
        '''     Indicates that the field should be displayed as a blank when the value 
        '''     in the field is zero.
        ''' </summary>
        ''' <value>
        '''     One of the BooleanTypes. If value is "NotSet" then the value will be taken 
        '''     from the dictionary if one exists.
        ''' </value>
        ''' <remarks>
        '''     Use the <B>BWZ</B> (Blank When Zero) property to suppress displaying the value
        '''     in the field if the value is zero.  This is valid for numeric fields only.
        ''' </remarks>
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False), _
        Description("Blank when zero flag indicates that the item is displayed as blanks if its value is 0."), _
        Category("Core"), _
        DefaultValue(GetType(BooleanTypes), "NotSet"), _
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Overridable Property BWZ() As BooleanTypes Implements IFieldObject.BWZ
            Get
                Return m_blnBWZ
            End Get

            Set(ByVal Value As BooleanTypes)
                m_blnBWZ = Value
            End Set
        End Property

        ''' --- AutoNext ---------------------------------------------------------------
        '''
        ''' <summary>
        '''     Move to the next field when input size of the field is reached.
        ''' field is complete.
        ''' </summary>
        ''' <value>
        '''     One of the BooleanTypes. If value is "NotSet" then the value will be taken 
        '''     from the dictionary if one exists.
        ''' </value>
        ''' <remarks>
        '''     Use the <B>AutoNext</B> property to move the cursor to the
        ''' next field when the current one is filled
        ''' </remarks>
        ''' <history>
        ''' 	[Glenn]	8/28/2007	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False), _
        Description("AutoNext flag indicates that the cursor will move to the next field when the input size current one is filled"), _
        Category("Core"), _
        DefaultValue(GetType(BooleanTypes), "NotSet"), _
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Overridable Property AutoNext() As BooleanTypes Implements IFieldObject.AutoNext
            Get
                Return m_blnAutoNext
            End Get

            Set(ByVal Value As BooleanTypes)
                m_blnAutoNext = Value
            End Set
        End Property

        ''' --- UseDictionary ---------------------------------------------------------------
        '''
        ''' <summary>
        '''     Indicates that temporary field should use dictionary field of that same name.
        ''' field is complete.
        ''' </summary>
        ''' <value>
        '''     One of the BooleanTypes. Default is False.
        ''' </value>
        ''' <remarks>
        '''     Use the <B>AutoNext</B> property to move the cursor to the
        ''' next field when the current one is filled
        ''' </remarks>
        ''' <history>
        ''' 	[GlennA]	29-Oct-2007	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False), _
        Description("UseDictionary flag indicates that a temp field will use a Dictionary defined field with the same name"), _
        Category("Core"), _
        DefaultValue(GetType(Boolean), "False"), _
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Overridable Property UseDictionary() As Boolean Implements IFieldObject.UseDictionary
            Get

                Return m_blnUseDictionary
            End Get

            Set(ByVal Value As Boolean)

                m_blnUseDictionary = Value
                ' Since this property appears after the FieldName has been set, the m_strDictionary 
                ' will be blank, so set it here.
                If Value = True AndAlso m_strDictionary.Length = 0 AndAlso m_strFieldName.IndexOf(".") = -1 Then
                    m_strDictionary = m_strFieldName
                End If
            End Set
        End Property

        ''' --- ShiftType ----------------------------------------------------------
        '''
        ''' <summary>
        '''     Indicates whether the value entered should be changed to uppercase, lowercase 
        '''     or left as is.
        ''' </summary>
        ''' <value>
        '''     One of the ShiftTypes. If value is "NotSet" then the value will be taken 
        '''     from the dictionary if one exists.
        ''' </value>
        ''' <remarks>
        '''     Use the <B>ShiftType</B> property to Upshift, Downshift or leave the value 
        '''     as is (NoShift).
        ''' </remarks>
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False), _
        Description("Will shift the case of the Text in the control."), _
        Category("Core"), _
        DefaultValue(GetType(ShiftTypes), "NotSet"), _
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Overridable Property ShiftType() As ShiftTypes Implements IFieldObject.ShiftType
            Get
                Return m_intShiftCase
            End Get
            Set(ByVal Value As ShiftTypes)
                m_intShiftCase = Value
            End Set
        End Property

        ''' --- LeadingSign -------------------------------------------------------
        '''
        ''' <summary>
        '''     Specifies a single character that is placed to the left of the most significant
        '''     digit to indicate that the numeric value of the field is a negative number.
        ''' </summary>
        ''' <value>
        '''     A String representing the character to be used to indicate a negative number.
        ''' </value>
        ''' <remarks>
        '''     Use the <B>LeadingSign</B> property to display the leading sign character to the 
        '''     left of the most significant digit in order to indicate that the value displayed
        '''     is a negative number.
        '''     <para>
        '''         <note>
        '''             Sufficient substitution characters (^) or non-submstitution characters
        '''             must be added to the <B>Picture</B> if the picture property is used.
        '''         </note>
        '''     </para>
        ''' </remarks>
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False), _
        Description("Specifies a single character that is placed to the left of the most significant digit to indicate that the numeric value of the textbox is a negative number."), _
        Category("Core"), _
        DefaultValue(""), _
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Overridable Property LeadingSign() As String Implements IFieldObject.LeadingSign
            Get
                Return m_strLeadingSign
            End Get
            Set(ByVal Value As String)
                m_strLeadingSign = Value.Substring(0, 1)
                'Me.Text = m_strValue
            End Set
        End Property

        ''' --- Fill -------------------------------------------------------------
        '''
        ''' <summary>
        '''     Specifies the character used to 'fill' unused space to the left of the most 
        '''     significant digit. 
        ''' </summary>
        ''' <value>
        '''     A String representing the character to be used to fill in the unused space.
        ''' </value>
        ''' <remarks>
        '''     Use the <B>Fill</B> property to set the character that is to be used to fill
        '''     unused space to the left of the most significant digit.
        '''     <para>
        '''         <note>
        '''             Float character and Leading sign must be taken into account.
        '''         </note>
        '''     </para>
        ''' </remarks>
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False), _
        Description("Specifies the character used to 'fill' unused space to the left of the most significant digit. Note: Float character and Leading sign are taken into account."), _
        Category("Core"), _
        DefaultValue(""), _
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Overridable Property Fill() As String Implements IFieldObject.Fill
            Get

                Return m_strFill
            End Get
            Set(ByVal Value As String)

                m_strFill = Value.Substring(0, 1)
                ' Me.Text = m_strValue
            End Set
        End Property



        ''' --- ToolTip -----------------------------------------------------------
        '''
        ''' <summary>
        '''     Sets or retrieves the ToolTip that is displayed when the cursor hovers over the control.
        ''' </summary>
        ''' <value>
        '''     A single line of text describing the purpose of the control. 
        ''' </value>
        ''' <remarks>
        '''     The tool tip is hidden most of the time, appearing only when the user 
        '''     places the cursor over a control on the screen and leaves it there 
        '''     for approximately one-half second. The tool tip will appear near where
        '''     the cursor is located and will disappear when the user clicks a mouse 
        '''     button or moves the cursor away from the control.
        ''' </remarks>
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Property ToolTip() As String Implements IFieldObject.ToolTip
            Get
                Return m_strToolTip
            End Get
            Set(ByVal Value As String)
                'MyBase.ToolTip = Value
                m_strToolTip = Value
            End Set
        End Property

        ''' --- Heading ------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False), _
        Description("Heading displayed for grid column."), _
        Category("Core"), _
        Browsable(False), _
        DefaultValue(""), _
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Property Heading() As String Implements IFieldObject.Heading
            Get

                Return m_strHeading
            End Get
            Set(ByVal Value As String)

                m_strHeading = Value
            End Set
        End Property

       

        ''' --- Float --------------------------------------------------------------
        '''
        ''' <summary>
        '''     Specifies the float character to appear to the left of the most significant digit.
        ''' </summary>
        ''' <value>
        '''     A String representing the float character to be displayed.
        ''' </value>
        ''' <remarks>
        '''     Use the <B>Float</B> property to set the character that will be displayed to 
        '''     the left of the most significant digit (ie. $ for currency fields).
        '''     <para>
        '''         <note>
        '''             Sufficient substitution characters (^) must be added to the <B>Picture</B> 
        '''             if the picture property is used.
        '''         </note>
        '''     </para>
        ''' </remarks>
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False), _
        Description("Specifies the float character to appear to the left of the most significant digit."), _
        Category("Core"), _
        DefaultValue(""), _
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Overridable Property Float() As String Implements IFieldObject.Float
            Get
                Return m_strFloat
            End Get
            Set(ByVal Value As String)
                m_strFloat = Value.Substring(0, 1)

            End Set
        End Property

        ''' --- TrailingSign -------------------------------------------------------
        '''
        ''' <summary>
        '''     Specifies up to 2 characters that are placed to the right most digit to indicate 
        '''     that the numeric value of the field is a negative number.
        ''' </summary>
        ''' <value>
        '''     A String representing the characters to be displayed.
        ''' </value>
        ''' <remarks>
        '''     Use the <B>TrailingSign</B> property to set the character(s) that will be displayed to 
        '''     the right most digit to indicate that the vlaue of the field is a negative number.
        '''     <para>
        '''         <note>
        '''             Sufficient nonsubstitution characters (^) must be added to the <B>Picture</B> if the
        '''             picture property is used.
        '''         </note>
        '''     </para>
        ''' </remarks>
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False), _
        Description("Specifies up to 2 characters that are placed to the right most digit to indicate that the numeric value of the field is a negative number."), _
        Category("Core"), _
        DefaultValue(""), _
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Overridable Property TrailingSign() As String Implements IFieldObject.TrailingSign
            Get
                Return m_strTrailingSign
            End Get
            Set(ByVal Value As String)
                m_strTrailingSign = Value.Substring(0, 2)
            End Set
        End Property

        ''' --- Required ----------------------------------------------------------
        '''
        ''' <summary>
        '''     Indicates that a value is required for this field when entering a new record.
        ''' </summary>
        ''' <value>
        '''     A Boolean Type indicating if this field is required or not. The default value
        '''     is "NotSet" meaning the value may be found in the dictionary.
        ''' </value>
        ''' <remarks>
        '''     Use the <B>Required</B> property to indicate that this field requires a value
        '''     when entering new records.
        ''' </remarks>
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False), _
        Description("Indicates that a value is required for this field when entering a new record."), _
        Category("Core"), _
        DefaultValue(GetType(BooleanTypes), "NotSet"), _
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Property Required() As BooleanTypes Implements IFieldObject.Required
            Get
                Return m_blnRequired
            End Get
            Set(ByVal Value As BooleanTypes)
                m_blnRequired = Value
            End Set
        End Property

        ''' --- Choose ----------------------------------------------------------
        '''
        ''' <summary>
        '''     Indicates that this field is a Choose field.
        ''' </summary>
        ''' <value>
        '''     A Boolean value indicating if this field is a Choose or not. 
        ''' </value>
        ''' <remarks>
        '''     This property should only be used on the ParmPrompt screen.
        ''' </remarks>
        ''' <history>
        ''' 	[Chris]	09/05/2007	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Property Choose() As Boolean
            Get
                Return m_blnChoose
            End Get
            Set(ByVal Value As Boolean)
                m_blnChoose = Value
            End Set
        End Property

        ''' --- Display ------------------------------------------------------------
        '''
        ''' <summary>
        '''     Displays the control as read-only in Entry, Find or Change mode.
        ''' </summary>
        ''' <value>
        '''     One of the Behavior types representing the mode. The default value
        '''     is "NotSet" meaning the value may be found in the dictionary.
        ''' </value>
        ''' <remarks>
        '''     Use the <B>Display</B> property to indicate that this field should be a read-only
        '''     field during the Find/Entry/Change phases.
        ''' </remarks>
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False), _
        Description("Displays the control as a read-only control in Entry, Find or Change mode."), _
        Category("Core"), _
        DefaultValue(GetType(BehaviorTypes), "NotSet"), _
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Property Display() As BehaviorTypes Implements IFieldObject.Display
            Get
                Return m_BehDisplay
            End Get
            Set(ByVal Value As BehaviorTypes)
                m_BehDisplay = Value
            End Set
        End Property

        ''' --- Omit ---------------------------------------------------------------
        '''
        ''' <summary>
        '''     States that the data on the screen cannot be entered or displayed on the  
        '''     screen unless forced through procedural code.
        ''' </summary>
        ''' <value>
        '''     One of the Behavior types representing the mode. The default value
        '''     is "NotSet" meaning the value may be found in the dictionary.
        ''' </value>
        ''' <remarks>
        '''     Use the <B>Omit</B> property to hide the field during the Find/Entry/Change
        '''     phases.
        ''' </remarks>
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False), _
        Description("States that the data on the screen cannot be entered or displayed on the screen unless forced through procedural code."), _
        Category("Core"), _
        DefaultValue(GetType(BehaviorTypes), "NotSet"), _
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Property Omit() As BehaviorTypes Implements IFieldObject.Omit
            Get
                Return m_BehOmit
            End Get
            Set(ByVal Value As BehaviorTypes)
                m_BehOmit = Value
            End Set
        End Property

        ''' --- Duplicate ----------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False), _
        Description("Duplicates the value for this field from a previous occurrence of the field on the screen if the user doesn’t enter a value"), _
        Category("Core"), _
        Browsable(True), _
        DefaultValue(GetType(BooleanTypes), "NotSet"), _
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Property Duplicate() As BooleanTypes Implements IFieldObject.Duplicate
            Get
                Return m_blnDuplicate
            End Get
            Set(ByVal Value As BooleanTypes)
                m_blnDuplicate = Value
            End Set
        End Property

        ''' --- Fixed --------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        '''     Permanently displays the current value for this field when the screen first 
        '''     appears.
        ''' </summary>
        ''' <value>
        '''     One of the Boolean types. The default value is "NotSet" meaning the 
        '''     value may or may not be found in the dictionary.
        ''' </value>
        ''' <remarks>
        '''     Use the <B>Fixed</B> property to indicate that the value of the screen is 
        '''     displayed when the screen first appears.  This field is also not updatable
        '''     by default unless forced through procedural code.
        ''' </remarks>
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Protected Property FixedValue() As Boolean
            Get
                Return m_blnFixedValue
            End Get
            Set(ByVal Value As Boolean)
                m_blnFixedValue = Value
            End Set
        End Property

        ''' --- Fixed --------------------------------------------------------------
        '''
        ''' <summary>
        '''     Permanently displays the current value for this field when the screen first 
        '''     appears.
        ''' </summary>
        ''' <value>
        '''     One of the Boolean types. The default value is "NotSet" meaning the 
        '''     value may or may not be found in the dictionary.
        ''' </value>
        ''' <remarks>
        '''     Use the <B>Fixed</B> property to indicate that the value of the screen is 
        '''     displayed when the screen first appears.  This field is also not updatable
        '''     by default unless forced through procedural code.
        ''' </remarks>
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False), _
        Description("Permanently displays the current value for this field when the screen first appears."), _
        Category("Core"), _
        DefaultValue(GetType(BooleanTypes), "NotSet"), _
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Property Fixed() As BooleanTypes Implements IFieldObject.Fixed
            Get
                Return m_blnFixed
            End Get
            Set(ByVal Value As BooleanTypes)
                m_blnFixed = Value
            End Set
        End Property

        ''' --- Silent -------------------------------------------------------------
        '''
        ''' <summary>
        '''     Specifies that the field should not appear on the screen.
        ''' </summary>
        ''' <value>
        '''     One of the Boolean types. The default value is "NotSet" meaning the 
        '''     value may or may not be found in the dictionary.
        ''' </value>
        ''' <remarks>
        '''     Use the <B>Silent</B> property to hide a field on the screen.  This option is
        '''     used for processing purposes when used in conjunction with a block other fields.
        ''' </remarks>
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False), _
        Description("Specifies that the field doesn’t appear on the screen."), _
        Category("Core"), _
        DefaultValue(GetType(BooleanTypes), "NotSet"), _
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Property Silent() As BooleanTypes Implements IFieldObject.Silent
            Get
                Return m_blnSilent
            End Get
            Set(ByVal Value As BooleanTypes)
                m_blnSilent = Value
                Select Case Value
                    Case BooleanTypes.True
                        MyBase.Visibility = False
                    Case Else
                        MyBase.Visibility = True
                End Select
            End Set
        End Property

        ''' --- Hidden -------------------------------------------------------------
        '''
        ''' <summary>
        '''     Specifies that the field should be invisible on the screen.
        ''' </summary>
        ''' <value>
        '''     One of the Boolean types. The default value is "NotSet" meaning the 
        '''     value may or may not be found in the dictionary.
        ''' </value>
        ''' <remarks>
        '''     Use the <B>Hidden</B> property to hide a field on the screen.  
        ''' </remarks>
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False), _
        Description("Specifies that the field should be hidden (invisible) on the screen."), _
        Category("Core"), _
        DefaultValue(GetType(BooleanTypes), "NotSet"), _
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Property Hidden() As BooleanTypes Implements IFieldObject.Hidden
            Get
                Return m_blnHidden
            End Get
            Set(ByVal Value As BooleanTypes)
                m_blnHidden = Value
                Select Case Value
                    Case BooleanTypes.True
                        MyBase.Visibility = False
                    Case Else
                        MyBase.Visibility = True
                End Select
            End Set
        End Property

        ''' --- NoChange -----------------------------------------------------------
        '''
        ''' <summary>
        '''     Permits the user to only enter a value when in Entry mode.
        ''' </summary>
        ''' <value>
        '''     One of the Boolean types. The default value is "NotSet" meaning the 
        '''     value may or may not be found in the dictionary.
        ''' </value>
        ''' <remarks>
        '''     Use the <B>NoChange</B> property to disallow the user from changing the value
        '''     in this field for existing records.  This field allows data entry when adding
        '''     new records.
        '''     <para>
        '''         <note>
        '''             The "ROFieldValue" class is used to set the style for this field.
        '''         </note>
        '''     </para>
        ''' </remarks>
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False), _
        Description("The user can only enter a value when in Entry mode."), _
        Category("Core"), _
        DefaultValue(GetType(BooleanTypes), "NotSet"), _
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Property NoChange() As BooleanTypes Implements IFieldObject.NoChange
            Get
                Return m_blnNoChange
            End Get
            Set(ByVal Value As BooleanTypes)
                m_blnNoChange = Value
            End Set
        End Property

        ''' --- NoCorrect ----------------------------------------------------------
        '''
        ''' <summary>
        '''     States that once a value has been entered in Entry mode, it cannot be 
        '''     changed until the record has been saved.
        ''' </summary>
        ''' <value>
        '''     One of the Boolean types. The default value is "NotSet" meaning the 
        '''     value may or may not be found in the dictionary.
        ''' </value>
        ''' <remarks>
        '''     Use the <B>NoCorrect</B> property to set the field to read-only during Correct
        '''     mode. This means that once the Entry sequence has completed, this value cannot
        '''     be changed until the record has been saved.
        '''     <para>
        '''         <note>
        '''             The "ROFieldValue" class is used to set the style for this field.
        '''         </note>
        '''     </para>
        ''' </remarks>
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False), _
        Description("States that once a value has been entered in Entry mode, it cannot be changed until the record has been saved."), _
        Category("Core"), _
        DefaultValue(GetType(BooleanTypes), "NotSet"), _
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Property NoCorrect() As BooleanTypes Implements IFieldObject.NoCorrect
            Get
                Return m_blnNoCorrect
            End Get
            Set(ByVal Value As BooleanTypes)
                m_blnNoCorrect = Value
            End Set
        End Property

        ''' --- NoEntry ------------------------------------------------------------
        '''
        ''' <summary>
        '''     Specifies that this field is read-only in Entry mode.
        ''' </summary>
        ''' <value>
        '''     One of the Boolean types. The default value is "NotSet" meaning the 
        '''     value may or may not be found in the dictionary.
        ''' </value>
        ''' <remarks>
        '''     Use the <B>NoEntry</B> property in order to set this field to read-only
        '''     during Entry mode.  
        '''     <para>
        '''         <note>
        '''             The "ROFieldValue" class is used to set the style for this field.
        '''         </note>
        '''     </para>
        ''' </remarks>
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False), _
        Description("Specifies that this field is read-only in Entry mode."), _
        Category("Core"), _
        DefaultValue(GetType(BooleanTypes), "NotSet"), _
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Property NoEntry() As BooleanTypes Implements IFieldObject.NoEntry
            Get
                Return m_blnNoEntry
            End Get
            Set(ByVal Value As BooleanTypes)
                m_blnNoEntry = Value
            End Set
        End Property

        ''' --- NoSelect -----------------------------------------------------------
        '''
        ''' <summary>
        '''     Specifies that this field is read-only in Select (Find) mode.
        ''' </summary>
        ''' <value>
        '''     One of the Boolean types. The default value is "NotSet" meaning the 
        '''     value may or may not be found in the dictionary.
        ''' </value>
        ''' <remarks>
        '''     Use the <B>NoSelect</B> property to set this field to read-only during Select
        '''     (Find) mode. 
        '''     <para>
        '''         <note>
        '''             The "ROFieldValue" class is used to set the style for this field.
        '''         </note>
        '''     </para>
        ''' </remarks>
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False), _
        Description("Specifies that this field is read-only in Select (Find) mode."), _
        Category("Core"), _
        DefaultValue(GetType(BooleanTypes), "NotSet"), _
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Property NoSelect() As BooleanTypes Implements IFieldObject.NoSelect
            Get
                Return m_blnNoSelect
            End Get
            Set(ByVal Value As BooleanTypes)
                m_blnNoSelect = Value
            End Set
        End Property

        ''' --- PreDisplay ---------------------------------------------------------
        '''
        ''' <summary>
        '''     Display any initial value for this field as soon as the screen appears,
        '''     or if the mode is changed, or if the cluster is initialized.  
        ''' </summary>
        ''' <value>
        '''     One of the Boolean types. The default value is "NotSet" meaning the 
        '''     value may or may not be found in the dictionary.
        ''' </value>
        ''' <remarks>
        '''     Use the <B>PreDisplay</B> property to indicate that the value should be 
        '''     displayed as soon as the screen appears, when the mode is changed, or the
        '''     cluster is initialized.
        '''     <para>
        '''         <note>
        '''             Assumed for ALL fields on a slave screen.
        '''         </note>
        '''     </para>
        ''' </remarks>
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False), _
        Description("Display any initial value for this field on the form as soon as the screen appears, if the mode is changed, or if the cluster is initialized.  (Assumed for ALL fields on a slave screen)"), _
        Category("Core"), _
        DefaultValue(GetType(BooleanTypes), "NotSet"), _
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Property PreDisplay() As BooleanTypes Implements IFieldObject.PreDisplay
            Get
                Return m_blnPreDisplay
            End Get
            Set(ByVal Value As BooleanTypes)
                m_blnPreDisplay = Value
            End Set
        End Property

        ''' --- NoWarn -------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Suppresses the display of messages.
        ''' </summary>
        ''' <value>
        '''     One of the Boolean types. The default value is "NotSet" meaning the 
        '''     value may or may not be found in the dictionary.
        ''' </value>
        ''' <remarks>
        '''     Use the <B>NoWarn</B> property to indicate that no messages should be 
        '''     displayed on the screen. 
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False), _
        Description("Suppresses the display of messages."), _
        Category("Core"), _
        DefaultValue(GetType(BooleanTypes), "NotSet"), _
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Property NoWarn() As BooleanTypes Implements IFieldObject.NoWarn
            Get
                Return m_blnNoWarn
            End Get
            Set(ByVal Value As BooleanTypes)
                m_blnNoWarn = Value
            End Set
        End Property

        ''' --- Default ------------------------------------------------------------
        '''
        ''' <summary>
        '''     The default value to be used when in Entry mode and no item has previously 
        '''     been entered into the field.  
        ''' </summary>
        ''' <value>
        '''     A String containing the field's default value.
        ''' </value>
        ''' <remarks>
        '''     Use the <B>Default</B> property to set the value that is to be used as the default
        '''     value for this field if the user doesn't enter anything into this field during
        '''     Entry processing.  If Required is also set to True, the Default option 
        '''     is ignored.
        ''' </remarks>
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False), _
        Description("The default value to be displayed when in Entry mode and no item has previously been entered into the field. If Required is also set to True, the Default option is ignored."), _
        Category("Core"), _
        DefaultValue(""), _
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Property [Default]() As String Implements IFieldObject.Default
            Get
                Return m_strDefault
            End Get
            Set(ByVal Value As String)
                m_strDefault = Value
            End Set
        End Property

        ''' --- EntryIf ------------------------------------------------------------
        '''
        ''' <summary>
        '''     Field is required in Entry mode if the specified condition is met.
        ''' </summary>
        ''' <value>
        '''     A String containing the condition to be met.
        ''' </value>
        ''' <remarks>
        '''     Use the <B>EntryIf</B> property to indicate that a value is to be entered into
        '''     this field only if the current condition is met during Entry processing.
        ''' </remarks>
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False), _
        Description("Field is required in Entry mode if the specified condition is met."), _
        Category("Core"), _
        DefaultValue(""), _
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Property EntryIf() As String Implements IFieldObject.EntryIf
            Get
                Return m_strEntryIf
            End Get
            Set(ByVal Value As String)
                m_strEntryIf = Value
            End Set
        End Property

        ''' --- Pattern ------------------------------------------------------------
        '''
        ''' <summary>
        '''     Specifies a string of characters and metacharacters that provides a general 
        '''     description of values.
        ''' </summary>
        ''' <value>
        '''     A String containing the general description of values.
        ''' </value>
        ''' <remarks>
        '''     Use the <B>Pattern</B> property to st the string of characters and metacharacters
        '''     that provides a pattern that the entered data must adhere to in order to be 
        '''     valid.
        ''' </remarks>
        ''' <example>
        '''
        ''' </example>
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False), _
        Description("Specifies a string of characters and metacharacters that provides a general description of values."), _
        Category("Core"), _
        DefaultValue(""), _
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Overridable Property Pattern() As String Implements IFieldObject.Pattern
            Get
                Return m_strPattern
            End Get
            Set(ByVal Value As String)
                m_strPattern = Value
            End Set
        End Property

        ''' --- Picture ------------------------------------------------------------
        '''
        ''' <summary>
        '''     Establishes the output picture to be used to format the item value for display.
        ''' </summary>
        ''' <value>
        '''     A String containing the output picture format.
        ''' </value>
        ''' <remarks>
        '''     Use the <B>Picture</B> property to set the format that is to be used to display
        '''     the value.  
        ''' </remarks>
        ''' <example>
        '''
        ''' </example>
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False), _
        Description("Establishes the output picture to be used to format the item value for display."), _
        Category("Core"), _
        DefaultValue(""), _
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Overridable Property Picture() As String Implements IFieldObject.Picture
            Get
                Return m_strPicture
            End Get
            Set(ByVal Value As String)
                m_strPicture = Value
            End Set
        End Property

        ''' --- Significance -------------------------------------------------------
        '''
        ''' <summary>
        '''     Establishes the minimum number of decimal points to be displayed.  
        ''' </summary>
        ''' <value>
        '''     A String representing the number of decimal points.
        ''' </value>
        ''' <remarks>
        '''     Use the <B>Significance</B> property to set the minimum number of decimal points
        '''     to be displayed.  It is used to display leading non-substitution characters and 
        '''     leading zeros.
        ''' </remarks>
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False), _
        Description("Establishes the minimum number (n) of characters displayed. It is generally used to force the display of leading nonsubstitution characters and leading zeros."), _
        Category("Core"), _
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Overridable Property Significance() As String Implements IFieldObject.Significance
            Get

                Return m_strSignificance
            End Get
            Set(ByVal Value As String)

                If Value Is Nothing OrElse Value.Trim = String.Empty Then
                    m_strSignificance = Nothing
                ElseIf IsNumeric(Value) Then
                    m_strSignificance = Value.Trim
                End If
            End Set
        End Property

        ''' --- GetSignificance ----------------------------------------------------
        ''' <exclude/>
        '''
        ''' <history>
        ''' 	[Campbell]	7/19/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Friend Function GetSignificance() As Int32
            If Me.m_strSignificance Is Nothing OrElse Me.m_strSignificance.Trim.Length = 0 Then
                Return 0
            Else
                Return CInt(Me.m_strSignificance)
            End If
        End Function

        ''' --- UnderLyingDataType -------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	DataType of the underlying item (variable or element) for this field.
        ''' </summary>
        ''' <value>
        '''     One of the DataTypes. The default value is "NotSet".
        ''' </value>
        ''' <remarks>
        '''     The datatype can be one of Character, Numeric or Date. The default value 
        '''     is initialized to "NotSet" meaning the property has not been set or the 
        '''     value may or may not be found in the dictionary.
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False), _
        Description("DataType of the underlying item (variable or element) for this field."), _
        Category("Core"), _
        DefaultValue(GetType(DataTypes), "NotSet"), _
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Property UnderLyingDataType() As ItemDataTypes Implements IFieldObject.UnderLyingDataType
            Get
                Return m_blnUnderLyingDataTypes
            End Get
            Set(ByVal Value As ItemDataTypes)
                m_blnUnderLyingDataTypes = Value
            End Set
        End Property

       

       

        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        '''     This member supports the Renaissance Architect Framework infrastructure and is 
        '''     not intended to be used directly from your code.
        ''' </summary>
        ''' <value></value>
        ''' <remarks>
        '''     This property indicates that the values was changed in the current field by the user.
        '''     This property differs from the ValueChanged property in that ValueChanged stays persistent
        '''     throughout the current mode, while this property is keeps it's value only until after the
        '''     Validation is run.  Once a new control has the Accept focus, this value is reset.  This is used
        '''     to determine whether to use the value from the Text property versus the SubmittedValue property.
        ''' </remarks>
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <Browsable(False), _
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Property ValueChangedByUser() As Boolean
            Get
                Return m_blnValueChangedByUser
            End Get
            Set(ByVal Value As Boolean)
                m_blnValueChangedByUser = Value
            End Set
        End Property

        ''' --- RenderedID ---------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of RenderedID.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public MustOverride ReadOnly Property RenderedID() As String

        ''' --- ValueChanged -------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of ValueChanged.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public MustOverride Property ValueChanged() As Boolean Implements IFieldObject.ValueChanged




        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        '''     This member supports the Renaissance Architect Framework infrastructure and is 
        '''     not intended to be used directly from your code.
        ''' </summary>
        '''
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <Browsable(False), _
        DefaultValue(False), _
        Description("Specifies whether the field should be shown as a label."), _
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Property DisplayAsLabel() As Boolean Implements IFieldObject.DisplayAsLabel
            Get
                Return m_blnDisplayAsLabel
            End Get
            Set(ByVal Value As Boolean)
                m_blnDisplayAsLabel = Value
            End Set
        End Property

        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        '''     This member supports the Renaissance Architect Framework infrastructure and is 
        '''     not intended to be used directly from your code.
        ''' </summary>
        '''
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <Browsable(False), _
        DefaultValue(False), _
        Description("Specifies whether the field should be shown as a label."), _
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Property TemplateElement() As Boolean
            Get
                Return m_blnTemplateElement
            End Get
            Set(ByVal Value As Boolean)
                m_blnTemplateElement = Value
            End Set
        End Property


       

        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        '''     This member supports the Renaissance Architect Framework infrastructure and is 
        '''     not intended to be used directly from your code.
        ''' </summary>
        ''' 
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <Browsable(False), _
        EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Overridable Property Row() As Integer
            Get
                Return intRow
            End Get
            Set(ByVal Value As Integer)
                intRow = Value
            End Set
        End Property

#End Region

#Region "  Methods  "

       

       
        ''' --- SetDefaultValueForProperty -----------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of SetDefaultValueForProperty.
        ''' </summary>
        ''' <param name="Key"></param>
        ''' <param name="DictionaryValue"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Protected Function SetDefaultValueForProperty(ByRef Key As String, ByVal DictionaryValue As String) As String
            Select Case Key.Length
                Case 0
                    Key = DictionaryValue
                Case Is > 2
                    If (Key.Substring(0, 2) = "::") Then
                        'Set the property to the Globalization Manager value
                        Key = ApplicationState.Current.CorePage.GlobalizationManager.GetString(Key.Substring(2), Globalization.Core.Globalization.ResourceTypes.Label)
                    End If
            End Select
            Return Nothing
        End Function

        ''' --- Reset --------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of Reset.
        ''' </summary>
        ''' <param name="Value"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Protected Friend Overridable Sub Reset(Optional ByVal Value As String = "")
            SubmittedValue = Value
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
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Overridable Sub LoadDefaultsFromDictionary()

        End Sub

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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Protected Function GetValueRange(ByVal RangeValue As String) As String()
            Dim strValue As String
            Dim arrRange(1) As String
            Dim s, e As Integer

            s = RangeValue.IndexOf("(")
            e = 0
            If s >= 0 Then
                e = RangeValue.IndexOf(")", s)
                If e > s Then
                    strValue = RangeValue.Substring(s + 1, e - s - 1)
                    arrRange(0) = strValue
                End If
            End If

            RangeValue = RangeValue.Substring(e + 1)
            s = RangeValue.IndexOf("(")
            e = 0
            If s >= 0 Then
                e = RangeValue.IndexOf(")", s)
                If e > s Then
                    strValue = RangeValue.Substring(s + 1, e - s - 1)
                    arrRange(1) = strValue
                End If
            End If
            Return arrRange
        End Function

        'Loads the defaults from the dictionary
        'NOTE: FieldName Property must be set inorder for this method to use the correct dictionary
        'Public  Sub LoadDictionaryValues(ByVal LanguageCode As String) Implements IFieldObject.LoadDictionaryValues
        '    If m_strDictionary <> "" Then
        '        Dim objDictionary As New Core.PowerHouse.Dictionary(m_strDictionary, LanguageCode) 'objGlobalization.CurrentLanguage)
        '        LoadFromDictionary(objDictionary, Me)
        '    End If
        'End Sub

        ''' --- LoadValues ---------------------------------------------------------
        ''' <exclude/>
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
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Friend Sub LoadValues() Implements IFieldObject.LoadValues
            If m_strDictionary <> String.Empty Then
                LoadDefaultsFromDictionary()
            Else
                RaiseEvent LoadGlobalizationOverrides()
            End If
        End Sub


        ''' --- RaiseOutput --------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of RaiseOutput.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Friend Sub RaiseOutput()
            RaiseEvent Output()
        End Sub

        ''' --- RaiseInput ---------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of RaiseInput.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Friend Sub RaiseInput()
            RaiseEvent Input()
        End Sub

        ''' --- RaiseProcess -------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of RaiseProcess.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Friend Sub RaiseProcess()
            RaiseEvent Process()
        End Sub

        ''' --- RaiseEdit ----------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of RaiseEdit.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Friend Sub RaiseEdit()
            RaiseEvent Edit()
        End Sub

        ''' --- RaiseLookupOn ------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of RaiseLookupOn.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Friend Sub RaiseLookupOn()
            RaiseEvent LookupOn()
        End Sub

        ''' --- RaiseLookupNotOn ---------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of RaiseLookupNotOn.
        ''' </summary>
        ''' <param name="LookupNotOnExecuted"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Friend Sub RaiseLookupNotOn(ByRef LookupNotOnExecuted As Boolean)
            RaiseEvent LookupNotOn(LookupNotOnExecuted)
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Instaniates a new instance of the FieldObjectBase class.
        ''' </summary>
        ''' <remarks>
        '''     Is the base class used for the Renaissance Architect server controls. 
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Sub New()
            m_blnDisplayAsLabel = False
        End Sub



        ''' --- RaiseGetRecordBuffer -----------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of RaiseGetRecordBuffer.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Protected Friend Overridable Function RaiseGetNewRecordStatus() As Boolean

            Return GetNewRecordStatus()

        End Function

        ''' --- RaiseGetFileType -----------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of RaiseGetFileType.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Protected Friend Overridable Function RaiseGetFileType() As FileTypes

            Return GetFileTypeValue()

        End Function

        ''' --- RaiseGetRecordBuffer -----------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of RaiseGetRecordBuffer.
        ''' </summary>
        ''' <param name="FieldText"></param>
        ''' <param name="FieldValue"></param>
        ''' <param name="DataType"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Protected Friend Overridable Sub RaiseGetRecordBuffer(ByRef FieldText As String, ByRef FieldValue As Decimal, ByVal DataType As DataTypes)
            'Following If condition should be removed once GetRecordValue is working
            If Not GetRecordValue Is Nothing Then
                Dim objGetterArgs As GetterArgs
                Dim m_intUnderlyingDataType As DataTypes

                If Me.UnderLyingDataType = ItemDataTypes.Integer OrElse Me.UnderLyingDataType = ItemDataTypes.SignedInteger OrElse Me.UnderLyingDataType = ItemDataTypes.UnsignedNumeric Then
                    m_intUnderlyingDataType = DataTypes.Numeric
                Else
                    m_intUnderlyingDataType = Me.UnderLyingDataType
                End If

                objGetterArgs = New GetterArgs
                With objGetterArgs
                    .DatabaseName = m_strDatabaseName
                    .TableName = m_strTableName
                    .ColumnName = m_strColumnName
                    .DataType = DataType
                    .UnderlyingDataType = m_intUnderlyingDataType
                    .FieldText = FieldText
                    .FieldValue = FieldValue
                    GetRecordValue(Me, objGetterArgs)
                    FieldText = .FieldText
                    FieldValue = .FieldValue
                End With
                objGetterArgs.Dispose()
                objGetterArgs = Nothing
            Else
                'TODO: This else part is an old code, we don't need this else part if, "If" part of this code works well
                RaiseEvent GetRecordBuffer(FieldText, FieldValue, DataType)
            End If
        End Sub

        ''' --- RaiseSetRecordBuffer -----------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of RaiseSetRecordBuffer.
        ''' </summary>
        ''' <param name="FieldText"></param>
        ''' <param name="FieldValue"></param>
        ''' <param name="DataType"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Protected Friend Overridable Sub RaiseSetRecordBuffer(ByRef FieldText As String, ByRef FieldValue As Decimal, ByVal DataType As DataTypes, Optional ByVal IsRequest As Boolean = False)
            'Following If condition should be removed once SetRecordValue is working
            If Not SetRecordValue Is Nothing Then
                Dim objSetterArgs As SetterArgs
                Dim m_intUnderlyingDataType As DataTypes

                If Me.UnderLyingDataType = ItemDataTypes.Integer OrElse Me.UnderLyingDataType = ItemDataTypes.SignedInteger OrElse Me.UnderLyingDataType = ItemDataTypes.UnsignedNumeric Then
                    m_intUnderlyingDataType = DataTypes.Numeric
                Else
                    m_intUnderlyingDataType = Me.UnderLyingDataType
                End If

                objSetterArgs = New SetterArgs
                With objSetterArgs
                    .DatabaseName = m_strDatabaseName
                    .TableName = m_strTableName
                    .ColumnName = m_strColumnName
                    .DataType = DataType
                    .UnderlyingDataType = m_intUnderlyingDataType
                    .FieldText = FieldText
                    .FieldValue = FieldValue
                    .PageMode = ApplicationState.Current.CorePage.Mode
                    If IsRequest Then .IsRequest = IsRequest
                    SetRecordValue(Me, objSetterArgs)
                    FieldText = .FieldText
                    FieldValue = .FieldValue
                End With
                objSetterArgs.Dispose()
                objSetterArgs = Nothing
            Else
                'TODO: This else part is an old code, we don't need this else part if, "If" part of this code works well
                RaiseEvent SetRecordBuffer(FieldText, FieldValue, DataType)
            End If
        End Sub

        ''' --- RaiseSetEditFlag -----------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of RaiseSetEditFlag.
        ''' </summary>
        ''' <param name="ClearFlag"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Protected Friend Overridable Sub RaiseSetEditFlag(ByVal ClearFlag As Boolean)

            If ClearFlag Then
                SetEditFlagValue("")
            Else
                If m_strColumnName.Length = 0 Then
                    SetEditFlagValue(FieldName)
                Else
                    SetEditFlagValue(m_strColumnName)
                End If
            End If

        End Sub

        ''' --- PrepareForDesigner -------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of PrepareForDesigner.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Protected Friend Overridable Sub PrepareForDesigner()
            'Should be overrided in derived class
        End Sub

        ''' --- PrepareForDisplayInGrid --------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of PrepareForDisplayInGrid.
        ''' </summary>
        ''' <param name="intCurrentRowIndex"></param>
        ''' <param name="ClearContent"></param>
        ''' <param name="DisplayForDesigner"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Protected Friend Overridable Sub PrepareForDisplayInGrid(ByVal intCurrentRowIndex As Boolean, ByVal ClearContent As Boolean, Optional ByVal DisplayForDesigner As Core.Windows.UI.Designer = Nothing)
            'Should be overrided in derived class
        End Sub

        ''' --- ClearRequestValues -------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of ClearRequestValues.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Protected Friend Overridable Sub ClearRequestValues()

            'This procedure is added to clear RequestValue
            'in response to ClearRequestValues Event raised in a Page.
            Me.RequestValue = ""

        End Sub

        ''' --- UpdateRequestBuffer ------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of UpdateRequestBuffer.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Protected Friend Overridable Sub UpdateRequestBuffer()
            'This procedure is added to update underlying buffer with the RequestValue
            'This procedure gets called in response to UpdateRequestBuffer Event raised in a Page.
            Dim strRequestValue As String = Me.RequestValue
            Dim m_intUnderlyingDataType As DataTypes

            If Me.UnderLyingDataType = ItemDataTypes.Integer OrElse Me.UnderLyingDataType = ItemDataTypes.SignedInteger OrElse Me.UnderLyingDataType = ItemDataTypes.UnsignedNumeric Then
                m_intUnderlyingDataType = DataTypes.Numeric
            Else
                m_intUnderlyingDataType = Me.UnderLyingDataType
            End If

            If Not SetRecordValue Is Nothing AndAlso strRequestValue <> String.Empty Then
                Dim objSetterArgs As SetterArgs
                objSetterArgs = New SetterArgs
                With objSetterArgs
                    .DatabaseName = m_strDatabaseName
                    .TableName = m_strTableName
                    .ColumnName = m_strColumnName
                    .DataType = m_intDataType
                    .UnderlyingDataType = m_intUnderlyingDataType
                    .FieldText = strRequestValue
                    If (m_intUnderlyingDataType = DataTypes.Numeric OrElse m_intUnderlyingDataType = DataTypes.Date) AndAlso IsNumeric(strRequestValue) Then
                        .FieldValue = CDbl(strRequestValue)
                    Else
                        .FieldValue = 0
                    End If
                    SetRecordValue.Invoke(Me, objSetterArgs)
                End With
            End If
            strRequestValue = Nothing
        End Sub

        ''' --- IsOmitInEntry ------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of IsOmitInEntry.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Protected Function IsOmitInEntry() As Boolean
            'If Page.IsInEntry() Then
            '    Return (Me.Omit = BehaviorTypes.Entry OrElse Me.Omit = BehaviorTypes.EntryFind OrElse Me.Omit = BehaviorTypes.ChangeEntry OrElse Me.Omit = BehaviorTypes.ChangeEntryFind)
            'End If
        End Function

        ''' --- IsDisplayInEntry ---------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of IsDisplayInEntry.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Protected Function IsDisplayInEntry() As Boolean
            'If Page.IsInEntry() Then
            '    Return (Me.Display = BehaviorTypes.Entry OrElse Me.Display = BehaviorTypes.EntryFind OrElse Me.Display = BehaviorTypes.ChangeEntry OrElse Me.Display = BehaviorTypes.ChangeEntryFind)
            'End If
        End Function

#Region " Bind Methods "

        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        '''     This member supports the Renaissance Architect Framework infrastructure and is 
        '''     not intended to be used directly from your code.
        ''' </summary>
        ''' 
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Sub Bind(ByVal Variable As CoreCharacter)
            With Variable
                ' If the value is received, set fixed to True so that when the user
                ' clicks the FIND button (or ADD, etc), the values don't get cleared.  
                If .HasReceivedValue Then
                    Me.FixedValue = True
                End If
                GetRecordValue = .GetRecordBuffer
                SetRecordValue = .SetRecordBuffer
                SetEditFlagValue = .SetEditFlagValue
                IsReceived = .HasReceivedValue
            End With
            m_IsBoundToTemporary = True
        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        '''     This member supports the Renaissance Architect Framework infrastructure and is 
        '''     not intended to be used directly from your code.
        ''' </summary>
        ''' 
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Sub Bind(ByVal Variable As CoreDecimal)
            With Variable
                ' If the value is received, set fixed to True so that when the user
                ' clicks the FIND button (or ADD, etc), the values don't get cleared.  
                If .HasReceivedValue Then
                    Me.FixedValue = True
                End If
                GetRecordValue = .GetRecordBuffer
                SetRecordValue = .SetRecordBuffer
                SetEditFlagValue = .SetEditFlagValue
                IsReceived = .HasReceivedValue
            End With
            m_IsBoundToTemporary = True
        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        '''     This member supports the Renaissance Architect Framework infrastructure and is 
        '''     not intended to be used directly from your code.
        ''' </summary>
        ''' 
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Sub Bind(ByVal Variable As CoreInteger)
            With Variable
                ' If the value is received, set fixed to True so that when the user
                ' clicks the FIND button (or ADD, etc), the values don't get cleared.  
                If .HasReceivedValue Then
                    Me.FixedValue = True
                End If
                GetRecordValue = .GetRecordBuffer
                SetRecordValue = .SetRecordBuffer
                SetEditFlagValue = .SetEditFlagValue
                IsReceived = .HasReceivedValue
            End With
            m_IsBoundToTemporary = True
        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        '''     This member supports the Renaissance Architect Framework infrastructure and is 
        '''     not intended to be used directly from your code.
        ''' </summary>
        ''' 
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Sub Bind(ByVal Variable As CoreBaseType)
            With Variable
                ' If the value is received, set fixed to True so that when the user
                ' clicks the FIND button (or ADD, etc), the values don't get cleared.  
                If .HasReceivedValue Then
                    Me.FixedValue = True
                End If
                GetRecordValue = .GetRecordBuffer
                SetRecordValue = .SetRecordBuffer
                SetEditFlagValue = .SetEditFlagValue
                IsReceived = .HasReceivedValue
            End With
            m_IsBoundToTemporary = True
        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        '''     This member supports the Renaissance Architect Framework infrastructure and is 
        '''     not intended to be used directly from your code.
        ''' </summary>
        ''' 
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Sub Bind(ByVal FileObject As BaseFileObject)
            With FileObject
                ' For MASTER files, set fixed to True so that when the user
                ' clicks the FIND button (or ADD, etc), the values don't get cleared.  
                If .Type = FileTypes.Master Then
                    Me.FixedValue = True
                End If
                GetRecordValue = .GetRecordBuffer
                SetRecordValue = .SetRecordBuffer
                SetEditFlagValue = .SetEditFlagValue
                GetNewRecordStatus = .GetNewRecordStatus
                GetFileTypeValue = .GetFileTypeValue
            End With
        End Sub

#End Region

#Region " Bind Define Methods "

        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        '''     This member supports the Renaissance Architect Framework infrastructure and is 
        '''     not intended to be used directly from your code.
        ''' </summary>
        ''' 
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Sub Bind(ByVal Variable As DCharacter)
            IsDefine = True
            With Variable
                GetRecordValue = .GetRecordBuffer
            End With
        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        '''     This member supports the Renaissance Architect Framework infrastructure and is 
        '''     not intended to be used directly from your code.
        ''' </summary>
        ''' 
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Sub Bind(ByVal Variable As DDecimal)
            IsDefine = True
            With Variable
                GetRecordValue = .GetRecordBuffer
            End With
        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        '''     This member supports the Renaissance Architect Framework infrastructure and is 
        '''     not intended to be used directly from your code.
        ''' </summary>
        ''' 
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Sub Bind(ByVal Variable As DInteger)
            IsDefine = True
            With Variable
                GetRecordValue = .GetRecordBuffer
            End With
        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        '''     This member supports the Renaissance Architect Framework infrastructure and is 
        '''     not intended to be used directly from your code.
        ''' </summary>
        ''' 
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Sub Bind(ByVal Variable As DDate)
            IsDefine = True
            With Variable
                GetRecordValue = .GetRecordBuffer
            End With
        End Sub

#End Region

#End Region

#Region "  Events  "

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' The Input event handles data conversion for a value entered prior to editing.
        ''' </summary>
        ''' <remarks>
        ''' The Input event can be used to change the value (or lack of value) entered by the
        ''' user.  The predefined member variable FieldText is used to determine the value entered by the
        ''' user, and this value can be changed prior to editing.  This event is called after being 
        ''' prompted in a field based on the Accept or RequestPrompt method.
        ''' </remarks>
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Event Input()

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' The Output event handles performing data conversion prior to displaying the value 
        ''' in a field.
        ''' </summary>
        ''' <remarks>
        ''' The Output event can be used to change data prior to displaying the value.  This event 
        ''' is raised prior to the application of formatting options.  It is raised in response to
        ''' the Accept, RequestPrompt or Display methods.  In order to change the value, the predefined
        ''' member variable FieldText must be altered.  
        ''' <note>Use the predefined member variable <B>FieldText</B> to alter the current value.</note>
        ''' </remarks>
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Event Output()

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' The Process event performs processing after a value was entered.
        ''' </summary>
        ''' <remarks>
        ''' The Process event is used to perform additional processing such as performing calculations and is initiated
        ''' based on an entered value as a result of the Accept or Edit methods.  Use the 
        ''' predefined member variables FieldText or FieldValue (numeric or date fields) to update the current value.
        ''' Referencing the underlying record buffers (ie. the value from the associated File class or Temporary class)
        ''' is not recommended as the FieldText or FieldValue values have already been moved into those record buffers
        ''' during the validation phase (as a result of the Accept or Edit methods), and may therefore not be current.  
        ''' The Process event is executed after the successful completion of the Edit event.
        ''' <note>Use the predefined member variable <B>FieldText</B> to alter the current value.</note>
        ''' </remarks>
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Event Process()

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' The Edit event performs editing on a value in a field.
        ''' </summary>
        ''' <remarks>
        ''' The Edit event can be is used to perform editing of values.  This event is initiated as a result of being
        ''' called during the validation process of the Edit method, or as a result of an entered or changed value entered
        ''' in a field in response to the Accept method.  During the processing phase of the Accept method, Edit event is 
        ''' raised if the predefined member variable FieldText is not empty at the end of the Input event.  Default values also 
        ''' do not trigger the Edit event.
        ''' <note>Use the predefined member variables <B>FieldText</B> or  <B>FieldValue</B> to compare the current value
        ''' with existing or old values.  To access the old value, use the OldValue function.</note>
        ''' </remarks>
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Event Edit()

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' The LookupOn event handles logic for checking if the entered value exists.
        ''' </summary>
        ''' <remarks>
        ''' Use the LookupOn event to handle logic for checking if the entered value exists.
        ''' Logic must be added to raise an error in response to not finding a matching value.
        ''' <note>
        ''' In the example below, if the MANAGER record is found, then the fleMANAGER class will
        ''' now contain this record.  This record will now be used when referencing a value from 
        ''' the fleMANAGER class until a new retrieval is performed.
        ''' </note>
        ''' </remarks>
        ''' <example>
        '''    Private Sub fldEMPLOYEE_MGR_ID_LookupOn() Handles fldEMPLOYEE_MGR_ID.LookupOn <br/>
        ''' <br/>
        '''    Try <br/>
        ''' <br/>
        '''        Dim strSQL As StringBuilder = New StringBuilder(" WHERE ") <br/>
        '''        strSQL.Append(" MANAGER.EMPLOYEE_ID = ").Append(StringToField(FIELDTEXT)) <br/>
        ''' <br/>
        '''        fleMANAGER.GetData(strSQL.ToString,  GetDataOptions.IsOptional) <br/>
        '''        If Not AccessOk Then <br/>
        '''            Warning("This manager does not exist.")  <br/>
        '''        End If <br/>
        '''    Catch ex As CustomApplicationException <br/>
        ''' <br/>
        '''        Throw ex <br/>
        ''' <br/>
        '''    Catch ex As Exception <br/>
        ''' <br/>
        '''        ExceptionManager.Publish(ex) <br/>
        '''        Throw ex <br/>
        ''' <br/>
        '''    End Try <br/>
        ''' <br/>
        '''End Sub
        ''' </example>
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Event LookupOn()

        ''' --- LookupNotOn --------------------------------------------------------
        ''' <summary>
        ''' The LookupNotOn event handles logic for checking if the entered value does not exist.
        ''' </summary>
        ''' <remarks>
        ''' Use the LookupNotOn event to handle logic for checking that the entered value exists.
        ''' Logic must be added to raise an error in response to finding a matching value.
        ''' </remarks>
        ''' <example>
        '''    Private Sub fldEMPLOYEE_MGR_ID_LookupOn() Handles fldEMPLOYEE_MGR_ID.LookupOn <br/>
        ''' <br/>
        '''    Try <br/>
        ''' <br/>
        '''        Dim blnAlreadyExists As Boolean <br/>
        '''        Dim strSQL As StringBuilder = New StringBuilder("SELECT EMPLOYEE_ID ") <br/>
        '''        strSQL.Append(" FROM ") <br/>
        '''        strSQL.Append(" EMPLOYEE ") <br/>
        '''        strSQL.Append(" WHERE ") <br/>
        '''        strSQL.Append("     EMPLOYEE.EMPLOYEE_ID = ").Append(StringToField(FIELDTEXT)) <br/>
        ''' <br/>
        '''        Dim rdr As OracleDataReader = OracleHelper.ExecuteReader(m_trnTRANS_UPDATE, CommandType.Text, strSQL.ToString) <br/>
        '''        If rdr.Read OrElse Not LookupNotOn(fleEMPLOYEE, "EMPLOYEE_ID", FIELDTEXT) Then <br/>
        '''            blnAlreadyExists = True <br/>
        '''        End If <br/>
        '''        rdr.Close() <br/>
        '''        rdr.Dispose() <br/>
        ''' <br/>
        '''        If blnAlreadyExists Then <br/>
        '''            ErrorMessage("This EMPLOYEE record already exists.") <br/>
        '''        End If <br/>
        '''    Catch ex As CustomApplicationException <br/>
        ''' <br/>
        '''        Throw ex <br/>
        ''' <br/>
        '''    Catch ex As Exception <br/>
        ''' <br/>
        '''        ExceptionManager.Publish(ex) <br/>
        '''        Throw ex <br/>
        ''' <br/>
        '''    End Try <br/>
        ''' <br/>
        '''End Sub
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Event LookupNotOn(ByRef LookupNotOnExecuted As Boolean)

        ''' --- LoadGlobalizationOverrides -----------------------------------------
        ''' <exclude/>
        ''' 
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Friend Event LoadGlobalizationOverrides()

        ''' --- GetRecordBuffer ----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Event GetRecordBuffer(ByRef FieldText As String, ByRef FieldValue As Decimal, ByVal DataType As DataTypes)

        ''' --- SetRecordBuffer ----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Event SetRecordBuffer(ByRef FieldText As String, ByRef FieldValue As Decimal, ByVal DataType As DataTypes)

#End Region

        ''' --- FieldObjectBase_Init -----------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of FieldObjectBase_Init.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks>
        '''     Add Handler to PageLoadDictionaries Event
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Private Sub FieldObjectBase_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Loaded
            'AddHandler CType(sender.parent.parent.parent.Page, Core.Windows.UI.Page).LoadValues, AddressOf Me.LoadValues
            If Not IsNothing(ApplicationState.Current.CorePage) Then

                With ApplicationState.Current.CorePage
                    AddHandler .LoadValues, AddressOf Me.LoadValues
                    'AddHandler .SetRunScreenFlags, AddressOf Me.SetRunScreenFlags
                    AddHandler .ClearRequestValues, AddressOf ClearRequestValues
                    AddHandler .UpdateRequestBuffer, AddressOf UpdateRequestBuffer

                End With

            End If
        End Sub

        ''' --- OnUnload -----------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of OnUnload.
        ''' </summary>
        ''' <param name="e"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Protected Sub OnUnload(ByVal e As System.EventArgs)
            With ApplicationState.Current.CorePage
                Try
                    RemoveHandler .LoadValues, AddressOf Me.LoadValues
                    RemoveHandler .ClearRequestValues, AddressOf ClearRequestValues
                    RemoveHandler .UpdateRequestBuffer, AddressOf UpdateRequestBuffer
                Catch ex As Exception
                End Try

                GetRecordValue = Nothing
                SetRecordValue = Nothing
                m_intDataType = Nothing
                m_intShiftCase = Nothing
                m_blnVisible = Nothing
                m_blnRequired = Nothing
                m_BehDisplay = Nothing
                m_BehOmit = Nothing
                m_blnNoChange = Nothing
                m_blnNoCorrect = Nothing
                m_blnNoEntry = Nothing
                m_blnNoSelect = Nothing
                m_blnNoCorrect = Nothing
                m_blnPreDisplay = Nothing
                m_blnNoWarn = Nothing
                m_blnDuplicate = Nothing
                m_blnFixed = Nothing
                m_blnSilent = Nothing
                m_blnUnderLyingDataTypes = Nothing
                m_objValues = Nothing
            End With

        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        '''     This member supports the Renaissance Architect Framework infrastructure and is 
        '''     not intended to be used directly from your code.
        ''' </summary>
        ''' <remarks>
        '''     At present we are replacing existing implementation of GetRecordBuffer and SetRecordBuffer
        '''     and changing only CMGT225 for testing. Once we have this Getter, Setter working we should
        '''     change following names from ...Value to ...Buffer for consistancy.
        ''' </remarks>
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Protected GetRecordValue As Getter 'Name should be replaced with GetRecordBuffer

        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        '''     This member supports the Renaissance Architect Framework infrastructure and is 
        '''     not intended to be used directly from your code.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Protected SetRecordValue As Setter         'Name should be replaced with SetRecordBuffer

        ''' --- SetEditFlagValue ----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of SetEditFlagValue.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public SetEditFlagValue As SetEditFlag

        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        '''     This member supports the Renaissance Architect Framework infrastructure and is 
        '''     not intended to be used directly from your code.
        ''' </summary>
        ''' <remarks>
        '''     At present we are replacing existing implementation of GetRecordBuffer and SetRecordBuffer
        '''     and changing only CMGT225 for testing. Once we have this Getter, Setter working we should
        '''     change following names from ...Value to ...Buffer for consistancy.
        ''' </remarks>
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Protected GetNewRecordStatus As GetNewStatus

        ''' -----------------------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        '''     This member supports the Renaissance Architect Framework infrastructure and is 
        '''     not intended to be used directly from your code.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Protected GetFileTypeValue As GetFileType
    End Class

End Namespace
