Imports Core.Framework.Core.Framework
Imports Core.Framework.Core.Framework.QDesign
Imports System.ComponentModel

Namespace Core.Windows.UI

    ''' --- IFieldObject -------------------------------------------------------
    ''' 
    ''' <summary>
    ''' 	Summary of IFieldObject.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
    Public Interface IFieldObject

#Region "  Properties  "

        ''' --- DisplayAsLabel -----------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Used by DataList to simulate labels for non-edit rows.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Property DisplayAsLabel() As Boolean

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
        ''' will execute against a specific field.  Multiple fields with the same FieldID
        ''' value will be executed as a block.  For screens without a grid, this property
        ''' will be blank if no numbered designer procedure is coded.
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Property FieldID() As String

        ''' --- FieldName ----------------------------------------------------------
        ''' 
        ''' <summary>
        '''     Variable name or element name of the field.  For elements, this will be in the 
        ''' format TableName.ElementName.
        ''' </summary>
        ''' <value></value>
        ''' <remarks>
        '''     Use the <B>FieldName</B> property to set the name of the field using the variable
        ''' or element name.  For fields that are based on elements from the database, 
        ''' the syntax will be Tablename.ElementName.  This property is used to retrieve the 
        ''' appropriate dictionary information (only for elements).
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Property FieldName() As String

        ''' --- Heading ------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of Heading.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Property Heading() As String


        ''' --- TableName ----------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	The TableName value of the Textbox.
        ''' </summary>
        ''' <remarks>This property is determined from the FieldName
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        ReadOnly Property TableName() As String

        ''' --- Dictionary ---------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	The Dictionary value of the current Field.
        ''' </summary>
        ''' <remarks>This property is determined from the FieldName.
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        ReadOnly Property Dictionary() As String

        ''' --- DataType -----------------------------------------------------------
        ''' 
        ''' <summary>
        '''     DataType of the field (Character, Numeric or Date).
        ''' </summary>
        ''' <remarks>
        '''     Use the <B>Datatype</B> property to indicate how the field should be validated
        ''' and formatted.  
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Property DataType() As DataTypes

        ''' --- UnderLyingDataType -------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	DataType of the underlying item (variable or element) for this field.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Property UnderLyingDataType() As ItemDataTypes

        ''' --- BWZ ----------------------------------------------------------------
        ''' 
        ''' <summary>
        '''     Indicates that the field should be displayed as a blank when the value in the
        ''' field is zero.
        ''' </summary>
        ''' <remarks>
        '''     Use the <B>BWZ</B> (Blank When Zero) property to suppress displaying the value
        ''' in the field if the value is zero.  This is valid for numeric fields only.
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Property BWZ() As BooleanTypes


        ''' --- AutoNext ----------------------------------------------------------------
        ''' 
        ''' <summary>
        '''     Move to the next field when input size of the field is reached.
        ''' </summary>
        ''' <remarks>
        '''     Use the <B>AutoNext</B> property to move the cursor to the
        ''' next field when the current one is filled
        ''' </remarks>
        ''' <history>
        ''' 	[Glenn]	8/28/2007	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Property AutoNext() As BooleanTypes

        ''' --- UseDictionary ----------------------------------------------------------------
        ''' 
        ''' <summary>
        '''     Use Dictionary with a non-Dictionary field
        ''' </summary>
        ''' <remarks>
        '''     Setting this property will cause a non-dictionary field to look in the dictionary for a field with the same name
        ''' and then use its dicitonary settings
        ''' </remarks>
        ''' <history>
        ''' 	[GlennA]	29-Oct-2007	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Property UseDictionary() As Boolean

        ''' --- ShiftType ----------------------------------------------------------
        ''' 
        ''' <summary>
        '''     Indicates whether the value entered should be changed to uppercase, lowercase 
        ''' or left as is.
        ''' </summary>
        ''' <remarks>
        '''     Use the <B>ShiftType</B> property to Upshift, Downshift or leave the value 
        ''' as is (NoShift).
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Property ShiftType() As ShiftTypes

        ''' --- LeadingSign --------------------------------------------------------
        ''' 
        ''' <summary>
        '''     Specifies a single character that is placed to the left of the most significant
        ''' digit to indicate that the numeric value of the field is a negative number.
        ''' </summary>
        ''' <remarks>
        '''     Use the <B>LeadingSign</B> property to display the leading sign character to the 
        ''' left of the most significant digit in order to indicate that the value displayed
        ''' is a negative number.
        '''<para>
        ''' <note>
        '''     Sufficient substitution characters (^) or non-substitution characters
        ''' must be added to the <B>Picture</B> if the picture property is used.
        ''' </note>
        '''</para>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Property LeadingSign() As String

        ''' --- Fill ---------------------------------------------------------------
        ''' 
        ''' <summary>
        '''     Specifies the character used to 'fill' unused space to the left of the most 
        ''' significant digit. 
        ''' </summary>
        ''' <remarks>
        '''     Use the <B>Fill</B> property to set the character that is to be used to fill
        ''' unused space to the left of the most significant digit.
        '''<para>
        ''' <note>
        '''     Float character and Leading sign are taken into account.
        ''' </note>
        '''</para>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Property Fill() As String
'

        



        ''' --- ToolTip ------------------------------------------------------------
        ''' 
        ''' <summary>
        '''     Sets or retrieves the ToolTip that displays when the cursor hovers over the control.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Property ToolTip() As String

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
        Property ValueChanged() As Boolean

        'The visible property of the Textbox
        'Note: This control was shadowed to a BooleanTypes inorder to have a 'zeroed' state for dictionary loading determination
        '  Property Visible() As Boolean

        'TabIndex of the text box
        'Note: This is a shadows to hide the webscontrols tabindex property
        ' Property TabIndex() As Short


        ''' --- Float --------------------------------------------------------------
        ''' 
        ''' <summary>
        '''     Specifies the float character to appear to the left of the most significant digit.
        ''' </summary>
        ''' <remarks>
        '''     Use the <B>Float</B> property to set the character that will be displayed to 
        ''' the left of the most significant digit (ie. $ for currency fields).
        '''<para>
        ''' <note>
        '''     Sufficient substitution characters (^) must be added to the <B>Picture</B> if the
        ''' picture property is used.
        ''' </note>
        '''</para>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Property Float() As String

        ''' --- TrailingSign -------------------------------------------------------
        ''' 
        ''' <summary>
        '''     Specifies up to 2 characters that are placed to the right most digit to indicate 
        ''' that the numeric value of the field is a negative number.
        ''' </summary>
        ''' <remarks>
        '''     Use the <B>TrailingSign</B> property to set the character(s) that will be displayed to 
        ''' the right most digit to indicate that the vlaue of the field is a negative number.
        '''<para>
        ''' <note>
        '''     Sufficient nonsubstitution characters (^) must be added to the <B>Picture</B> if the
        ''' picture property is used.
        ''' </note>
        '''</para>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Property TrailingSign() As String

        'The Required Flag for the textbox
        ''' --- Required -----------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of Required.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Property Required() As BooleanTypes

        ''' --- Display ------------------------------------------------------------
        ''' 
        ''' <summary>
        '''     Displays the control as a read-only control in Entry, Find or Change mode.
        ''' </summary>
        ''' <remarks>
        '''     Use the <B>Display</B> property to indicate that this field should be a read-only
        ''' field during the Find/Entry/Change phases.
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Property Display() As BehaviorTypes

        'Omit [ON ENTRY|FIND] – States that the data on the screen can not be entered or 
        'displayed on the screen unless forced through procedural code.  
        'NOTE: On FIND prevents display and entry during FIND, CHANGE and SELECT modes
        ''' --- Omit ---------------------------------------------------------------
        ''' 
        ''' <summary>
        '''     States that the data on the screen cannot be entered or displayed on the screen 
        ''' unless forced through procedural code.
        ''' </summary>
        ''' <remarks>
        '''     Use the <B>Omit</B> property to hide the field during the Find/Entry/Change.
        ''' phases.
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Property Omit() As BehaviorTypes

        'The user can only enter a value when in ENTRY mode.  
        'Once the FILE (relation) has been saved, this value cannot be changed 
        'unless the record is deleted and then re-added.
        ''' --- NoChange -----------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of NoChange.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Property NoChange() As BooleanTypes

        ''' --- Fixed --------------------------------------------------------------
        ''' 
        ''' <summary>
        '''     Permanently displays the current value for this field when the screen first 
        ''' appears.
        ''' </summary>
        ''' <remarks>
        '''     Use the <B>Fixed</B> property to indicate that the value of the screen is 
        ''' displayed when the screen first appears.  This field is also not updatable
        ''' by default unless forced through procedural code.
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Property Fixed() As BooleanTypes

        ''' --- Duplicate ----------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of Duplicate.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Property Duplicate() As BooleanTypes

        ''' --- Silent -------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of Silent.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Property Silent() As BooleanTypes

        ''' --- Hidden -------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of Hidden.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Property Hidden() As BooleanTypes

        'States that once a value has been entered in ENTRY mode, it cannot be 
        'changed until the record has been saved.
        ''' --- NoCorrect ----------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of NoCorrect.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Property NoCorrect() As BooleanTypes

        'Specifies that this field is read-only (Looks like a label) in ENTRY mode.
        ''' --- NoEntry ------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of NoEntry.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Property NoEntry() As BooleanTypes

        'Specifies that this field is read-only (Looks like a label) in SELECT (FIND) mode.
        ''' --- NoSelect -----------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of NoSelect.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Property NoSelect() As BooleanTypes

        'Display any initial value for this field on the form as soon as the screen appears, if the mode is changed, or if the cluster is initialized.  (Assumed for ALL fields on a slave screen)
        ''' --- PreDisplay ---------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of PreDisplay.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Property PreDisplay() As BooleanTypes

        'Suppresses the display of messages
        ''' --- NoWarn -------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of NoWarn.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Property NoWarn() As BooleanTypes

        ''' --- Default ------------------------------------------------------------
        ''' 
        ''' <summary>
        '''     The default value to be used when in Entry mode and no item has previously 
        ''' been entered into the field.  
        ''' </summary>
        ''' <remarks>
        '''     Use the <B>Default</B> property to set the value that is to be used as the default
        ''' value for this field if the user doesn't enter anything into this field during
        ''' Entry processing.  If Required is also set to True, the Default option is ignored.
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Property [Default]() As String

        ''' --- EntryIf ------------------------------------------------------------
        ''' 
        ''' <summary>
        '''     Field is required in Entry mode if the specified condition is met.
        ''' </summary>
        ''' <remarks>
        '''     Use the <B>EntryIf</B> property to indicate that a value is to be entered into
        ''' this field only if the current condition is met during Entry processing.
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Property EntryIf() As String

        ''' --- Pattern ------------------------------------------------------------
        ''' 
        ''' <summary>
        '''     Specifies a string of characters and metacharacters that provides a general 
        ''' description of values.
        ''' </summary>
        ''' <remarks>
        '''     Use the <B>Pattern</B> property to st the string of characters and metacharacters
        ''' that provides a pattern that the entered data must adhere to in order to be 
        ''' valid.
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Property Pattern() As String

        ''' --- InputScale ---------------------------------------------------------
        ''' 
        ''' <summary>
        '''     Specifies the input scale to use for entered values (numeric fields only).
        ''' </summary>
        ''' <remarks>
        '''     Use the <B>InputScale</B> property to set the scaling factor that is to be
        ''' used when values are entered for numeric items.
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Property InputScale() As String

        ''' --- OutputScale --------------------------------------------------------
        ''' 
        ''' <summary>
        '''     Specifies the output scaling to use for displayed values (numeric fields only).
        ''' </summary>
        ''' <remarks>
        '''     Use the <B>OutputScale</B> property to set the output scaling factor.  The value 
        ''' to be displayed will be scaled by this factor.
        '''<para>
        ''' <note>
        '''     This property is only applied to numeric fields.
        ''' </note>
        '''</para>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Property OutputScale() As String

        ''' --- Picture ------------------------------------------------------------
        ''' 
        ''' <summary>
        '''     Establishes the output picture to be used to format the item value for display.
        ''' </summary>
        ''' <remarks>
        '''     Use the <B>Picture</B> property to set the format that is to be used to display
        ''' the value.  
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Property Picture() As String

        ''' --- Significance -------------------------------------------------------
        ''' 
        ''' <summary>
        '''     Establishes the minimum number of decimal points to be displayed.  
        ''' </summary>
        ''' <remarks>
        '''     Use the <B>Significance</B> property to set the minimum number of decimal points
        ''' to be displayed.  It is used to display leading non-substitution characters and 
        ''' leading zeros.
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Property Significance() As String

        

#End Region

#Region "  Methods  "

       

        ''' --- LoadValues ---------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Loads the defaults from the dictionary.
        ''' </summary>
        ''' <remarks>
        ''' <note>
        '''     FieldName Property must be set inorder for this method to use the correct dictionary.
        ''' </note>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Sub LoadValues()

#End Region

    End Interface

End Namespace
