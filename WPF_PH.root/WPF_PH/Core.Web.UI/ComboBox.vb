#Region " Imports "

Imports System.ComponentModel
Imports System.Web.UI.Design
Imports System.Drawing.Design
Imports System.Collections.Specialized
Imports Core.Framework.Core.Framework
Imports System.Windows.Threading
Imports System.Windows.Controls
Imports System.Windows
Imports Core.Windows.UI.Core.Windows.UI
Imports System.Windows.Media
Imports Core.Framework.Common

#End Region

Namespace Core.Windows.UI
    '-	In the combo box we need to hit tab twice to move to the next field
    '-	We need to set ImageURL to /images/dropdown.jpg depending on how deep the the
    '   form is under the Application Root directory
    '-	We only store the "SelectedValue" and "SelectedText" in ViewState and not all 
    '   the DropDown list items i.e. DropDown list items will always be populated either 
    '   from Database, the user code or from the Dictionary


    ''' ----------------------------------------------------------------------------
    ''' 
    ''' Class	: ComboBox
    ''' 
    ''' ----------------------------------------------------------------------------
    ''' 
    ''' <summary>
    ''' 	This class defines the Renaissance Architect ComboBox control.
    ''' </summary>
    ''' <remarks>
    '''     The Renaissance Architect ComboBox control is an input control that allows
    '''     the user to select a value from a predefined list or to enter thier own text.
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(EditorBrowsableState.Always)>
    Public Class ComboBox
        Inherits FieldObjectComboBox

        Private m_colDropDownItems As DropDownItemCollection
        Private m_strSelectedValue As String
        Private m_blnSelectedValueChanged As Boolean
        Private m_strImageUrl As String
        <EditorBrowsable(EditorBrowsableState.Advanced)> Protected Friend m_blnCurrentRow As Boolean = False

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
            Visibility = System.Windows.Visibility.Visible
            HorizontalAlignment = HorizontalAlignment.Left
            SetResourceReference(StyleProperty, "CoreComboBoxStyle")
            IsEditable = True
        End Sub

#End Region

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

        ''' --- GetDropDownItems ---------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Retrieves DropDownItems in ComboBox.
        ''' </summary>
        ''' <param name="DropDownItems">A collection of DropDownItems.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Event GetDropDownItems(ByVal DropDownItems As DropDownItemCollection)

        ''' --- DropDownItems ------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of DropDownItems.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public ReadOnly Property DropDownItems() As DropDownItemCollection
            Get
                If m_colDropDownItems Is Nothing Then
                    m_colDropDownItems = New DropDownItemCollection
                End If
                Return m_colDropDownItems
            End Get
        End Property

        '' --- RenderedID ---------------------------------------------------------
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

        ''' --- RaiseGetDropDownItemsDB ----------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of RaiseGetDropDownItemsDB.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Protected Friend Sub RaiseGetDropDownItemsDB()
            'Allow the user to add/remove Drop Items through code
            RaiseEvent GetDropDownItems(DropDownItems)
            If DropDownItems.Count > 0 Then
                ApplicationState.Current.CorePage.UserComboValues.Add(DropDownItems)
                ApplicationState.Current.CorePage.UserComboColumnNames.Add(Me.Dictionary)
            End If
        End Sub

        ''' --- RaiseGetDropDownItems ----------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of RaiseGetDropDownItems.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Protected Friend Sub RaiseGetDropDownItems()
            'Allow the user to add/remove Drop Items through code
            'RaiseEvent GetDropDownItems(DropDownItems)
            Dim strFieldText As String = String.Empty
            Dim strMessage As String = String.Empty

            'If "Values" property has values and there is no DropDownItems then 
            'populate DropDownItems from "Values"
            If DropDownItems.Count = 0 AndAlso ((Not Me.Values Is Nothing) AndAlso Me.Values.Count > 0) Then
                'TODO: DropDownItems from the Values needs to be tested
                With Me.Values
                    For intValueItem As Integer = 0 To .Count - 1
                        If IsArray(.Item(intValueItem)) Then
                            If .Item(intValueItem)(0).GetType.Equals(GetType(String)) Then
                                Dim strStart As String
                                Dim strEnd As String
                                Dim intAscValue As Integer
                                strStart = CStr(.Item(intValueItem)(0))
                                strEnd = CStr(.Item(intValueItem)(1))
                                'Populate DropDownItems based on the First ASCII character in the range
                                'Note: In case if Values represents a range of String Code e.g.
                                'if Value range is 'AAA-CCZ', only two drop down items will be populated
                                'which are "A" and "B" and NOT "AAA", "AAB", ... "ABA", "ABB" ... "CCA" ... "CCZ"
                                For intAscValue = Asc(strStart) To Asc(strEnd)
                                    m_colDropDownItems.Add(CStr(Chr(intAscValue)), CStr(Chr(intAscValue)))
                                Next
                            ElseIf IsNumeric(.Item(intValueItem)(0)) Then
                                Dim intStart As String
                                Dim intEnd As String
                                Dim intValue As Integer
                                intStart = CInt(.Item(intValueItem)(0))
                                intEnd = CInt(.Item(intValueItem)(1))
                                'Populate DropDownItems with the numbers in range incremented by 1
                                'Note: In case if Values represents a range of decimal values e.g.
                                '12.5-50, only two drop down items will be populated
                                'with 12.5, 13.5, 14.5 ... 49.5 and NOT with
                                '12.5, 12.51, 12.52 (by now you see the problem, its endless if
                                'if you start counting 12.501, 12.502) ... 12.6, 12.7, 12.8 ... 50
                                For intValue = intStart To intEnd
                                    strFieldText = CStr(intValue)
                                    If Picture.Length > 0 Then
                                        Dim elementName As String = String.Empty
                                        If FieldName.IndexOf(".") > -1 Then _
                                            elementName = FieldName.Substring(FieldName.IndexOf(".") + 1)
                                        strMessage =
                                            ApplyNumericFormatting(elementName, strFieldText, BWZ, TrailingSign,
                                                                    LeadingSign, Picture,
                                                                    GetSignificance, Fill, Float, 0, 0,
                                                                    UnderLyingDataType, 0)
                                    End If
                                    m_colDropDownItems.Add(strFieldText, CStr(intValue))
                                Next
                            End If
                        ElseIf .Item(intValueItem).GetType.Equals(GetType(String)) Then
                            m_colDropDownItems.Add(CStr(.Item(intValueItem)), CStr(.Item(intValueItem)))
                        ElseIf IsNumeric(.Item(intValueItem)) Then
                            strFieldText = CStr(.Item(intValueItem))
                            Dim intSize As Integer = 0
                            If Me.FieldName.IndexOf(".") = -1 Then intSize = 0
                            If Picture.Length > 0 OrElse Fill.Length > 0 Then
                                Dim elementName As String = String.Empty
                                If FieldName.IndexOf(".") > -1 Then _
                                    elementName = FieldName.Substring(FieldName.IndexOf(".") + 1)
                                strMessage =
                                    ApplyNumericFormatting(elementName, strFieldText, BWZ, TrailingSign, LeadingSign,
                                                            Picture,
                                                            GetSignificance, Fill, Float, 0, intSize,
                                                            UnderLyingDataType, Me.DataType, 0)
                            End If
                            If UnderLyingDataType = ItemDataTypes.Character Then
                                m_colDropDownItems.Add(strFieldText,
                                                        CStr(.Item(intValueItem)).PadLeft(intSize, Fill))
                            Else
                                m_colDropDownItems.Add(strFieldText, CStr(.Item(intValueItem)))
                            End If
                        Else
                            'Invalid Data????
                        End If
                    Next
                End With
            End If

            With ApplicationState.Current.CorePage
                If DropDownItems.Count = 0 Then
                    If _
                        ((Not Me.FieldName.Equals(String.Empty)) AndAlso
                         (Not .MetaComboColumnNames.Contains(Me.Dictionary))) Then
                        'Add ComboColumn's name to a page level collection, later used to retrieve
                        'values from the Database
                        .MetaComboColumnNames.Add(Me.Dictionary)

                        'If Combo Values are already added in ComboValues, remove it
                        With .UserComboValues
                            If .Contains(Me.Dictionary) Then
                                .Remove(Me.Dictionary)
                            End If
                        End With
                        With .UserComboColumnNames
                            If .Contains(Me.Dictionary) Then
                                .Remove(Me.Dictionary)
                            End If
                        End With
                    End If
                Else
                    If Not .UserComboColumnNames.Contains(Me.Dictionary) Then
                        With .UserComboValues
                            'If combo values are populated from the screen, add those values
                            'to a page level collection later used to populate client-side code to
                            'populate combo values
                            .Add(m_colDropDownItems)
                        End With
                        .UserComboColumnNames.Add(Me.Dictionary)
                    End If

                    With .MetaComboColumnNames
                        'If combo values are passed from screen, remove the
                        'column name from the collection which is used to retrieve combo values from
                        'the database
                        If .Contains(Me.Dictionary) Then
                            .Remove(Me.Dictionary)
                        End If
                    End With
                End If
            End With
        End Sub

        ''' --- SelectedText -------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of SelectedText.
        ''' </summary>
        ''' <remarks>The SelectValue value of the ComboBox
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Browsable(False),
            EditorBrowsable(EditorBrowsableState.Advanced)>
        Public ReadOnly Property SelectedText() As String
            Get
                Return m_colDropDownItems.Text(SelectedValue)
            End Get
        End Property

        ''' --- SelectedValue ------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Gets or sets the value of the ComboBox control.
        ''' </summary>
        ''' <value>
        '''     A String containing the text value to assign as the selected text.
        ''' </value>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Browsable(False),
            EditorBrowsable(EditorBrowsableState.Always)>
        Public Property SelectedValue(Optional ByVal ValueChanged As Boolean = True) As String
            Get

                If m_strSelectedValue Is Nothing Then
                    Return String.Empty
                End If
                Return m_strSelectedValue
            End Get
            Set(ByVal Value As String)

                m_strSelectedValue = Value
                m_blnSelectedValueChanged = ValueChanged
            End Set
        End Property

        ''' --- ImageURL -----------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	The URL of the Image to be for ComboBox.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False),
            LoadDictionary(True),
            Description("The URL of the Image to be for ComboBox"),
            DefaultValue(""),
            Category("Core"),
            Editor(GetType(ImageUrlEditor), GetType(UITypeEditor)),
            EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Property ImageURL() As String
            Get
                If m_strImageUrl Is Nothing OrElse m_strImageUrl.Equals(String.Empty) Then
                    m_strImageUrl = "../images/dropdown.jpg"
                End If
                Return m_strImageUrl
            End Get
            Set(ByVal Value As String)
                m_strImageUrl = Value
            End Set
        End Property





        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Sub Combo_Loaded(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Loaded

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
                            objRange.Add("")
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

                ElseIf Picture.Length = 0 Then
                    ' If we have a leading sign or trailing sign, then increment the maxlength by 1 
                    ' to ensure that the minus sign can be entered.

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
        Private Sub ComboBox_Unload(ByVal sender As Object, ByVal e As EventArgs) 'Handles MyBase.Unload
            With ApplicationState.Current.CorePage
                RemoveHandler .ClearControls, AddressOf ClearValues
                RemoveHandler .ResetValueChanged, AddressOf ResetValueChanged
            End With



        End Sub


        Private Sub menu_open() Handles Me.PreviewMouseRightButtonDown
            SetAcceptRequestPrompt = False
        End Sub


        Private Sub Blur() Handles Me.PreviewLostKeyboardFocus

         

            If Not IsEnabled OrElse ApplicationState.Current.Navigate Then
                Exit Sub
            End If

            If ApplicationState.Current.CorePage.NavigationType = NavigationTypes.Cancel Then
                Exit Sub
            End If



            If ApplicationState.Current.CorePage.HasError AndAlso (ApplicationState.Current.CorePage.m_strRequestedControlFocusOverRide <> "" AndAlso
                ApplicationState.Current.CorePage.m_strRequestedControlFocusOverRide <> Me.Name) Then
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

            Dim dt As DispatcherTimer = New System.Windows.Threading.DispatcherTimer()
            AddHandler dt.Tick, AddressOf OnBlur
            dt.Interval = New TimeSpan(0, 0, 0, 0, 20)
            dt.Start()

        End Sub

    

        Public Sub BlurFocus()

            OnBlur(Nothing, Nothing)
         
        End Sub

        Public Sub OnBlur(sender As Object, e As EventArgs)
            Dim dt = TryCast(sender, DispatcherTimer)
            If dt IsNot Nothing Then
                dt.[Stop]()
            End If
            dt = Nothing

            Dim elementWithFocus As UIElement = System.Windows.Input.Keyboard.FocusedElement

            If ApplicationState.Current.CorePage.Mode = PageModeTypes.Entry AndAlso IsNothing(elementWithFocus) Then
                Exit Sub
            Else
                If Not IsNothing(elementWithFocus) AndAlso elementWithFocus.GetType.ToString = "Core.Windows.UI.Core.Windows.UI.ComboBox" AndAlso DirectCast(elementWithFocus, ComboBox).Name = Me.Name Then
                    Exit Sub
                End If
                If Not IsNothing(elementWithFocus) AndAlso (elementWithFocus.GetType.ToString = "System.Windows.FrameworkElement" OrElse elementWithFocus.GetType.ToString = "System.Windows.Controls.TextBox") AndAlso DirectCast(elementWithFocus, System.Windows.FrameworkElement).Name = "PART_EditableTextBox" Then
                    Dim parent As ComboBox = FindParent(Of ComboBox)(elementWithFocus)
                    If Me.Name = parent.Name AndAlso Text = OldText Then
                        Exit Sub
                    End If
                End If
            End If


            If SetAcceptRequestPrompt = False AndAlso Text = OldText Then
                Exit Sub
            End If


            If Text <> OldText Then
                SubmittedValue = Text
                ValueChanged = True
                ValueChangedByUser = True
            End If

            If (ApplicationState.Current.CorePage.RequireTerminate) Then
                Exit Sub
            End If


            If Not IsNothing(elementWithFocus) AndAlso Not SetAcceptRequestPrompt Then
                If ApplicationState.Current.CorePage.ToolbarAction = ToolbarIcons.Cancel _
               OrElse DirectCast(elementWithFocus, System.Windows.FrameworkElement).Name = "PART_EditableTextBox" _
               OrElse (elementWithFocus.GetType.ToString = "Core.Windows.UI.Core.Windows.UI.ComboBox" AndAlso DirectCast(elementWithFocus, ComboBox).Name = Me.Name) Then
                    If Not ValueChangedByUser Then
                        SetAcceptRequestPrompt = True
                        Exit Sub
                    Else
                        SetAcceptRequestPrompt = False
                    End If
                Else
                    SetAcceptRequestPrompt = False
                End If
            Else
                SetAcceptRequestPrompt = False
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

        Public Shared Function FindParent(Of T As DependencyObject)(child As DependencyObject) As T
            'get parent item
            Dim parentObject As DependencyObject = VisualTreeHelper.GetParent(child)

            'we've reached the end of the tree
            If parentObject Is Nothing Then
                Return Nothing
            End If

            'check if the parent matches the type we're looking for
            Dim parent = TryCast(parentObject, T)
            If parent IsNot Nothing Then
                Return parent
            Else
                Return FindParent(Of T)(parentObject)
            End If
        End Function

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
                        .IsEnabled = False

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
                            .Visibility = System.Windows.Visibility.Visible
                            '.SetAcceptRequestPrompt = False


                            If ApplicationState.Current.CorePage.HasError Then
                                If IsEnabled Then
                                    SetResourceReference(StyleProperty, "CoreErrorComboBoxStyle")
                                    .Focus()
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
                                            ''.TabIndex = -1
                                        End If

                                    Case PageModeTypes.Change
                                        Select Case .EnableForDesigner
                                            Case Microsoft.VisualBasic.TriState.True
                                                .IsEnabled = True
                                                .DisplayAsLabel = False
                                                '.CssClassTextBox = ""
                                                'Case Microsoft.VisualBasic.TriState.False
                                                '    .EnableForDesigner = Microsoft.VisualBasic.TriState.False
                                                '    .IsEnabled = False
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
                                                            ''.TabIndex = -1
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
                                        If .Omit = BehaviorTypes.Find Or .Omit = BehaviorTypes.EntryFind Then
                                            .IsEnabled = False
                                        ElseIf Not .Silent Then
                                            .Visibility = System.Windows.Visibility.Visible
                                        ElseIf .Silent Then
                                            .Visibility = System.Windows.Visibility.Collapsed
                                        End If

                                    Case PageModeTypes.Entry
                                        Select Case .EnableForDesigner
                                            Case Microsoft.VisualBasic.TriState.True
                                                .IsEnabled = True
                                                .DisplayAsLabel = False
                                                '.CssClassTextBox = ""
                                                'Case Microsoft.VisualBasic.TriState.False
                                                '    .EnableForDesigner = Microsoft.VisualBasic.TriState.False
                                                '    .IsEnabled = False
                                                '.CssClassTextBox = "ROFieldValue"
                                            Case Else
                                                If .NoEntry = BooleanTypes.True Then
                                                    .IsEnabled = False
                                                    ''.TabIndex = -1
                                                Else
                                                    Select Case .Display
                                                        Case BehaviorTypes.Entry, BehaviorTypes.EntryFind,
                                                            BehaviorTypes.ChangeEntry, BehaviorTypes.ChangeEntryFind
                                                            .IsEnabled = False
                                                            ''.TabIndex = -1
                                                        Case Else
                                                            .IsEnabled = True
                                                    End Select
                                                End If
                                        End Select
                                        If .Omit = BehaviorTypes.Entry Or .Omit = BehaviorTypes.EntryFind Then
                                            .IsEnabled = False
                                        ElseIf Not .Silent Then
                                            .Visibility = System.Windows.Visibility.Visible
                                        ElseIf .Silent Then
                                            .Visibility = System.Windows.Visibility.Collapsed
                                        End If

                                    Case PageModeTypes.Find
                                        Select Case .Display
                                            Case BehaviorTypes.Find, BehaviorTypes.EntryFind, BehaviorTypes.ChangeFind,
                                                BehaviorTypes.ChangeEntryFind
                                                .IsEnabled = False
                                                ''.TabIndex = -1
                                            Case Else
                                                .IsEnabled = True
                                                'If Not .m_blnBypassPageModeLogic Then .[ReadOnly] = False
                                        End Select

                                        If .Omit = BehaviorTypes.Find Or .Omit = BehaviorTypes.EntryFind Then
                                            .IsEnabled = False
                                        ElseIf Not .Silent Then
                                            .Visibility = System.Windows.Visibility.Visible
                                        ElseIf .Silent Then
                                            .Visibility = System.Windows.Visibility.Collapsed
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
                                            ''.TabIndex = -1
                                        End If

                                        If .Omit = BehaviorTypes.Find Or .Omit = BehaviorTypes.EntryFind Then
                                            .IsEnabled = False
                                        ElseIf Not .Silent Then
                                            .Visibility = System.Windows.Visibility.Visible
                                        ElseIf .Silent Then
                                            .Visibility = System.Windows.Visibility.Collapsed
                                        End If

                                    Case Else
                                        .IsEnabled = False
                                        '.CssClassTextBox = "ROFieldValue"
                                        ''.TabIndex = -1
                                        If Not .Silent Then
                                            .Visibility = System.Windows.Visibility.Visible
                                        ElseIf .Silent Then
                                            .Visibility = System.Windows.Visibility.Collapsed
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

                                .IsEnabled = False

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

                        If .Visibility = System.Windows.Visibility.Visible And .IsEnabled And Not .DisplayAsLabel Then
                            ApplicationState.Current.CorePage.ControlList.Add(Me)
                        End If
                    End If
                    ' If Page.HasErrorInFind


                    ' Create the onBlur code.


                    Dim blnError As Boolean = False
                    Dim strClass As String = String.Empty


                    If (ApplicationState.Current.CorePage.HasError AndAlso ApplicationState.Current.CorePage.m_strRequestedControlFocusOverRide = Me.RenderedID) Then

                        If _
                            Me.Required = BooleanTypes.True AndAlso
                            (ApplicationState.Current.CorePage.Mode = PageModeTypes.Correct OrElse ApplicationState.Current.CorePage.Mode = PageModeTypes.Change OrElse
                             ApplicationState.Current.CorePage.Mode = PageModeTypes.Entry) Then
                            strClass = "Required"
                        Else
                            strClass = "TextBox"
                        End If

                        blnError = True
                        '.AddInnerControlAttribute("onBlur", _
                        '                           m_txtTextBox.Attributes.Item("onBlur") + " LoseFocus(this,'" + _
                        '                           strClass + "');")
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
                If Not IsEnabled Then
                    SetResourceReference(StyleProperty, "DisableCoreComboBoxStyle")
                ElseIf Required AndAlso ApplicationState.Current.CorePage.Mode <> PageModeTypes.Find AndAlso
                    ApplicationState.Current.CorePage.Mode <> PageModeTypes.NoMode Then
                    SetResourceReference(StyleProperty, "CoreRequiredComboBoxStyle")
                Else
                    SetResourceReference(StyleProperty, "CoreComboBoxStyle")
                End If
            End If

        End Sub




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




        ''' --- GetUpdatedComboItems -----------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of GetUpdatedComboItems.
        ''' </summary>
        ''' <param name="ComboColumnNames"></param>
        ''' <param name="ComboColumnValues"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Sub GetUpdatedComboItems(ByVal ComboColumnNames As ArrayList, ByVal ComboColumnValues As ArrayList)
            'Used to Generate required script to display combo box on client
            Dim strComboBoxName As String
            strComboBoxName = Me.Dictionary
            If strComboBoxName Is String.Empty Then
                strComboBoxName = Me.FieldName
            End If
            If Not m_colDropDownItems Is Nothing AndAlso Not ComboColumnNames.Contains(strComboBoxName) Then
                'Add ComboBox Items to the array list of column names only if it is not there
                With m_colDropDownItems
                    ComboColumnNames.Add(strComboBoxName)
                    ComboColumnValues.Add(m_colDropDownItems)
                End With
            End If
        End Sub

        ''' --- GenerateComboValues ------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of GenerateComboValues.
        ''' </summary>
        ''' <param name="ComboValuesTable"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Sub GenerateComboValues(ByVal ComboValuesTable As DataTable)
            'Generate combo box with the MetaDropDown Table values
            Dim intCount As Integer
            With ApplicationState.Current.CorePage.UserComboColumnNames
                If Not .Contains(Me.Dictionary) Then
                    With ComboValuesTable
                        intCount = .Rows.Count - 1
                        For intRow As Integer = 0 To intCount
                            If Me.Dictionary = CStr(.Rows(intRow).Item("FIELD_NAME")) Then
                                m_colDropDownItems.Add(CStr(.Rows(intRow).Item("DROP_DESCRIPTION")),
                                                        CStr(.Rows(intRow).Item("DROP_VALUE")))
                            End If
                        Next
                    End With
                End If
            End With
        End Sub



        ''' --- ClearValues --------------------------------------------------------
        ''' <exclude />
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
                Me.Text = ""
                Me.SubmittedValue = ""
                Me.OldSubmittedValue = ""
                Me.RequestValue = ""
                Me.OldText = ""
                Me.AcceptProcessingOldText = ""
                Me.SelectedValue(ValueChanged) = String.Empty
                ValueChangedByUser = False
            End If

        End Sub




    End Class
End Namespace
