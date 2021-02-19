Imports System.ComponentModel
Imports System.Xml
Imports System.Configuration
Imports System.IO
Imports Core.ExceptionManagement

Namespace Core.Framework
    ''' ----------------------------------------------------------------------------
    ''' 
    ''' Class	: CoreDictionary
    ''' 
    ''' ----------------------------------------------------------------------------
    ''' <exclude />
    ''' 
    ''' <summary>
    ''' 	Summary of CoreDictionary.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
    Public Class CoreDictionary
        Implements IDisposable

        Public TestDictionaryValue As String

        Private hstDictionaryItems As Hashtable
        Private Disposed As Boolean

        Public Sub New (ByVal DictionaryFileName As String)
            TestDictionaryValue = "Dictionary Values from: " + DictionaryFileName
            hstDictionaryItems = New Hashtable
            LoadDictionary (DictionaryFileName)
        End Sub

        ''' --- LoadDictionary -----------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of LoadDictionary.
        ''' </summary>
        ''' <param name="DictionaryFileName"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Private Sub LoadDictionary (ByVal DictionaryFileName As String)
            'Note: Using XmlTextReader, instead of XMLDocument to make the loading faster 
            'At present its not strictly observing the Encoding specifiec in the XML File,
            'XmlTextReader always the default Encoding which is Windows-1252
            Dim objDictionaryXML As XmlTextReader
            If File.Exists (DictionaryFileName) Then
                objDictionaryXML = New XmlTextReader (DictionaryFileName)
                PopulateDictionaryItems (objDictionaryXML)
            Else
                'TODO: to be replaced with Exception Code that can display localized error message
                Throw New CustomApplicationException ("Dictionary File Not found!")
            End If
            objDictionaryXML.Close()
            objDictionaryXML = Nothing
        End Sub

        ''' --- PopulateDictionaryItems --------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of PopulateDictionaryItems.
        ''' </summary>
        ''' <param name="DictionaryXMLReader"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Private Sub PopulateDictionaryItems (ByVal DictionaryXMLReader As XmlTextReader)
            With DictionaryXMLReader
                Dim objDictionaryItemValues As Hashtable
                Dim strDictionaryItemName As String = ""

                Do While .Read
                    Select Case .NodeType
                        Case XmlNodeType.Element
                            'Debug.Write(("<" + Name))
                            If .Name.ToUpper.Equals ("ELEMENT") Then
                                objDictionaryItemValues = New Hashtable (31)
                                'Debug.Write("Element: ")
                                'Debug.WriteLine(.Name)

                                While .MoveToNextAttribute()
                                    Select Case .Name
                                        Case "ELEMENT_NAME"
                                            strDictionaryItemName = .Value
                                            objDictionaryItemValues.Add (CInt (FieldAttributes.ElementName), _
                                                                         strDictionaryItemName)
                                        Case "ALTERNATE_ELEMENT_NAME"
                                            objDictionaryItemValues.Add (CInt (FieldAttributes.AlternateElementName), _
                                                                         .Value)
                                        Case "BWZ_FLAG"
                                            If .Value = "" Then
                                                objDictionaryItemValues.Add (CInt (FieldAttributes.BwzFlag), False)
                                            Else
                                                objDictionaryItemValues.Add (CInt (FieldAttributes.BwzFlag), _
                                                                             CBool (.Value))
                                            End If
                                        Case "DECIMAL_POSITION"
                                            objDictionaryItemValues.Add (CInt (FieldAttributes.DecimalPosition), .Value)
                                        Case "ELEMENT_SIZE"
                                            objDictionaryItemValues.Add (CInt (FieldAttributes.ElementSize), .Value)
                                        Case "ELEMENT_TYPE_CODE"
                                            objDictionaryItemValues.Add (CInt (FieldAttributes.ElementTypeCode), _
                                                                         GetDataType (.Value))
                                        Case "HEADING"
                                            objDictionaryItemValues.Add (CInt (FieldAttributes.Heading), .Value)
                                        Case "FILL"
                                            objDictionaryItemValues.Add (CInt (FieldAttributes.Fill), .Value)
                                        Case "FLOAT_VALUE"
                                            objDictionaryItemValues.Add (CInt (FieldAttributes.FloatValue), .Value)
                                        Case "DATE_FORMAT_CODE"
                                            objDictionaryItemValues.Add (CInt (FieldAttributes.DateFormatCode), .Value)
                                        Case "LABEL"
                                            objDictionaryItemValues.Add (CInt (FieldAttributes.Label), .Value)
                                        Case "HELP"
                                            objDictionaryItemValues.Add (CInt (FieldAttributes.Help), .Value)
                                        Case "INITIAL_VALUE"
                                            objDictionaryItemValues.Add (CInt (FieldAttributes.DefaultValue), .Value)
                                        Case "INPUT_SCALE"
                                            objDictionaryItemValues.Add (CInt (FieldAttributes.InputScale), .Value)
                                        Case "ITEM_DATATYPE_CODE"
                                            objDictionaryItemValues.Add (CInt (FieldAttributes.ItemDataTypeCode), _
                                                                         GetDataType (.Value))
                                        Case "ITEM_SIZE"
                                            objDictionaryItemValues.Add (CInt (FieldAttributes.ItemSize), CInt (.Value))
                                        Case "LEADING_SIGN"
                                            objDictionaryItemValues.Add (CInt (FieldAttributes.LeadingSign), .Value)
                                        Case "OUTPUT_SCALE"
                                            objDictionaryItemValues.Add (CInt (FieldAttributes.OutputScale), .Value)
                                        Case "PATTERN_VALUE"
                                            objDictionaryItemValues.Add (CInt (FieldAttributes.PatternValue), .Value)
                                        Case "PICTURE"
                                            objDictionaryItemValues.Add (CInt (FieldAttributes.Picture), .Value)
                                        Case "SHIFTINPUT_CODE"
                                            objDictionaryItemValues.Add (CInt (FieldAttributes.ShiftInputCode), _
                                                                         GetShiftType (.Value))
                                        Case "SEPARATOR"
                                            objDictionaryItemValues.Add (CInt (FieldAttributes.Separator), .Value)
                                        Case "SIGNIFICANCE"
                                            objDictionaryItemValues.Add (CInt (FieldAttributes.Significance), .Value)
                                        Case "TRAILING_SIGN"
                                            objDictionaryItemValues.Add (CInt (FieldAttributes.TrailingSign), .Value)
                                        Case "DESCRIPTION"
                                            objDictionaryItemValues.Add (CInt (FieldAttributes.Description), .Value)
                                        Case "VALUES"
                                            objDictionaryItemValues.Add (CInt (FieldAttributes.Values), .Value)
                                        Case "CONTROLTYPE"
                                            ' Not used
                                            '    objDictionaryItemValues.Add(CInt(FieldAttributes.ControlType), .Value)
                                        Case "LABELISHYPERLINK"
                                            ' Not used
                                            '    objDictionaryItemValues.Add(CInt(FieldAttributes.LabelIsHyperLink), .Value)
                                        Case "LABELURL"
                                            ' Not used
                                            '    objDictionaryItemValues.Add(CInt(FieldAttributes.LabelUrl), .Value)
                                        Case "DISPLAYCLASS"
                                            ' Not used
                                            '    objDictionaryItemValues.Add(CInt(FieldAttributes.DisplayClass), .Value)
                                        Case "USAGE"
                                            ' Not used
                                            '    objDictionaryItemValues.Add(CInt(FieldAttributes.Usage), .Value)
                                    End Select
                                End While
                                If Not hstDictionaryItems.Contains(strDictionaryItemName)
                                     hstDictionaryItems.Add (strDictionaryItemName, objDictionaryItemValues)
                                End If
                               
                            End If
                    End Select
                Loop
                objDictionaryItemValues = Nothing
            End With
        End Sub

        ''' --- GetDataType --------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetDataType.
        ''' </summary>
        ''' <param name="DataType"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Private Function GetDataType (ByVal DataType As String) As Byte
            Select Case DataType.ToLower
                Case "character"
                    Return CByte (DataTypes.Character)
                Case "numeric"
                    Return CByte (DataTypes.Numeric)
                Case "date"
                    Return CByte (DataTypes.Date)
                Case "integer"
                    Return CByte (ItemDataTypes.Integer)
                Case "signedinteger"
                    Return CByte (ItemDataTypes.SignedInteger)
                Case "unsignednumeric"
                    Return CByte (ItemDataTypes.UnsignedNumeric)
                Case Else
                    Return CByte (DataTypes.NotSet)
            End Select
        End Function

        ''' --- GetShiftType -------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetShiftType.
        ''' </summary>
        ''' <param name="ShiftType"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Private Function GetShiftType (ByVal ShiftType As String) As Byte
            Select Case ShiftType.ToLower
                Case "downshift"
                    Return CByte (ShiftTypes.DownShift)
                Case "noshift"
                    Return CByte (ShiftTypes.NoShift)
                Case "upshift"
                    Return CByte (ShiftTypes.UpShift)
                Case Else
                    Return ShiftTypes.NotSet
            End Select
        End Function

        ''' --- GetDictionaryHashTable ---------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetDictionaryHashTable.
        ''' </summary>
        ''' <param name="FieldId"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Function GetDictionaryHashTable (ByVal FieldId As String) As Hashtable
            Return CType (hstDictionaryItems.Item (FieldId), Hashtable)
        End Function

        ''' --- GetDictionaryItem --------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetDictionaryItem.
        ''' </summary>
        ''' <param name="FieldId"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Function GetDictionaryItem (ByVal FieldId As String) As CoreDictionaryItem
            Dim objDictionaryItem As New CoreDictionaryItem
            Dim htDictionary As Hashtable
            htDictionary = CType (hstDictionaryItems.Item (FieldId), Hashtable)

            If htDictionary Is Nothing Then
                Return Nothing
            End If
            With objDictionaryItem
                .strElementName = CStr (htDictionary.Item (CInt (FieldAttributes.ElementName)))
                .strAlternateElementName = CStr (htDictionary.Item (CInt (FieldAttributes.AlternateElementName)))
                .blnBwzFlag = CBool (htDictionary.Item (CInt (FieldAttributes.BwzFlag)))
                .intDecimalPosition = CInt (htDictionary.Item (CInt (FieldAttributes.DecimalPosition)))
                .intElementSize = CInt (htDictionary.Item (CInt (FieldAttributes.ElementSize)))
                .intElementTypeCode = CType (htDictionary.Item (CInt (FieldAttributes.ElementTypeCode)), DataTypes)
                .strHeading = CStr (htDictionary.Item (CInt (FieldAttributes.Heading)))
                .strFill = CStr (htDictionary.Item (CInt (FieldAttributes.Fill)))
                .strFloatValue = CStr (htDictionary.Item (CInt (FieldAttributes.FloatValue)))
                .strDateFormatCode = CStr (htDictionary.Item (CInt (FieldAttributes.DateFormatCode)))
                .strLabel = CStr (htDictionary.Item (CInt (FieldAttributes.Label)))
                .strHelp = CStr (htDictionary.Item (CInt (FieldAttributes.Help)))
                .strDefaultValue = CStr (htDictionary.Item (CInt (FieldAttributes.DefaultValue)))
                .strInputScale = CStr (htDictionary.Item (CInt (FieldAttributes.InputScale)))
                .intItemDatatypeCode = CType (htDictionary.Item (CInt (FieldAttributes.ItemDataTypeCode)), DataTypes)
                .intItemSize = CInt (htDictionary.Item (CInt (FieldAttributes.ItemSize)))
                .strLeadingSign = CStr (htDictionary.Item (CInt (FieldAttributes.LeadingSign)))
                .strOutputScale = CStr (htDictionary.Item (CInt (FieldAttributes.OutputScale)))
                .strPatternValue = CStr (htDictionary.Item (CInt (FieldAttributes.PatternValue)))
                .strPicture = CStr (htDictionary.Item (CInt (FieldAttributes.Picture)))
                .intShiftInputCode = CType (htDictionary.Item (CInt (FieldAttributes.ShiftInputCode)), ShiftTypes)
                .strSeparator = CStr (htDictionary.Item (CInt (FieldAttributes.Separator)))
                .intSignificance = CInt (htDictionary.Item (CInt (FieldAttributes.Significance)))
                .strTrailingSign = CStr (htDictionary.Item (CInt (FieldAttributes.TrailingSign)))
                .strDescription = CStr (htDictionary.Item (CInt (FieldAttributes.Description)))
                .strValues = CStr (htDictionary.Item (CInt (FieldAttributes.Values)))

                '.strControltype = String.Empty
                ''Return CStr(htDictionary.Item(CInt(FieldAttributes.ControlType)))

                '.blnLabelIsHyperLink = False
                ''Return CStr(htDictionary.Item(CInt(FieldAttributes.LabelIsHyperLink)))

                '.strLabelUrl = String.Empty
                ''Return CStr(htDictionary.Item(CInt(FieldAttributes.LabelUrl)))

                '.strDisplayClass = String.Empty
                ''Return CStr(htDictionary.Item(CInt(FieldAttributes.DisplayClass)))

                '.strUsage = String.Empty
                ''Return CStr(htDictionary.Item(CInt(FieldAttributes.Usage)))
            End With
            htDictionary = Nothing
            Return objDictionaryItem
        End Function

#Region " Get Dictionary Item's Attribute functions "

        ''' --- GetElementName -----------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetElementName.
        ''' </summary>
        ''' <param name="FieldId"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Function GetElementName (ByVal FieldId As String) As String
            Return CStr (CType (hstDictionaryItems.Item (FieldId), Hashtable).Item (CInt (FieldAttributes.ElementName)))
        End Function

        ''' --- GetAlternateElementName --------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetAlternateElementName.
        ''' </summary>
        ''' <param name="FieldId"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Function GetAlternateElementName (ByVal FieldId As String) As String
            Return _
                CStr ( _
                    CType (hstDictionaryItems.Item (FieldId), Hashtable).Item ( _
                                                                               CInt ( _
                                                                                  FieldAttributes.AlternateElementName)))
        End Function

        ''' --- GetBwzFlag ---------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetBwzFlag.
        ''' </summary>
        ''' <param name="FieldId"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Function GetBwzFlag (ByVal FieldId As String) As Boolean
            Return CBool (CType (hstDictionaryItems.Item (FieldId), Hashtable).Item (CInt (FieldAttributes.BwzFlag)))
        End Function

        ''' --- GetDecimalPosition -------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetDecimalPosition.
        ''' </summary>
        ''' <param name="FieldId"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Function GetDecimalPosition (ByVal FieldId As String) As Integer
            Return _
                CInt (CType (hstDictionaryItems.Item (FieldId), Hashtable).Item (CInt (FieldAttributes.DecimalPosition)))
        End Function

        ''' --- GetElementSize -----------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetElementSize.
        ''' </summary>
        ''' <param name="FieldId"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Function GetElementSize (ByVal FieldId As String) As Integer
            Return CInt (CType (hstDictionaryItems.Item (FieldId), Hashtable).Item (CInt (FieldAttributes.ElementSize)))
        End Function

        ''' --- GetElementTypeCode -------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetElementTypeCode.
        ''' </summary>
        ''' <param name="FieldId"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Function GetElementTypeCode (ByVal FieldId As String) As DataTypes 'Check with Silviu later Discuss
            Return _
                CType ( _
                    CType (hstDictionaryItems.Item (FieldId), Hashtable).Item (CInt (FieldAttributes.ElementTypeCode)), _
                    DataTypes)
        End Function

        ''' --- GetHeading ---------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetHeading.
        ''' </summary>
        ''' <param name="FieldId"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Function GetHeading (ByVal FieldId As String) As String
            Return CStr (CType (hstDictionaryItems.Item (FieldId), Hashtable).Item (CInt (FieldAttributes.Heading)))
        End Function

        ''' --- GetFill ------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetFill.
        ''' </summary>
        ''' <param name="FieldId"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Function GetFill (ByVal FieldId As String) As String
            Return CStr (CType (hstDictionaryItems.Item (FieldId), Hashtable).Item (CInt (FieldAttributes.Fill)))
        End Function

        ''' --- GetFloatValue ------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetFloatValue.
        ''' </summary>
        ''' <param name="FieldId"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Function GetFloatValue (ByVal FieldId As String) As String
            Return CStr (CType (hstDictionaryItems.Item (FieldId), Hashtable).Item (CInt (FieldAttributes.FloatValue)))
        End Function

        ''' --- GetDateFormatCode --------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetDateFormatCode.
        ''' </summary>
        ''' <param name="FieldId"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Function GetDateFormatCode (ByVal FieldId As String) As String
            Return _
                CStr (CType (hstDictionaryItems.Item (FieldId), Hashtable).Item (CInt (FieldAttributes.DateFormatCode)))
        End Function

        ''' --- GetLabel -----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetLabel.
        ''' </summary>
        ''' <param name="FieldId"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Function GetLabel (ByVal FieldId As String) As String
            Return CStr (CType (hstDictionaryItems.Item (FieldId), Hashtable).Item (CInt (FieldAttributes.Label)))
        End Function

        ''' --- GetHelp ------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetHelp.
        ''' </summary>
        ''' <param name="FieldId"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Function GetHelp (ByVal FieldId As String) As String
            Return CStr (CType (hstDictionaryItems.Item (FieldId), Hashtable).Item (CInt (FieldAttributes.Help)))
        End Function

        ''' --- GetDefaultValue ----------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetDefaultValue.
        ''' </summary>
        ''' <param name="FieldId"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Function GetDefaultValue (ByVal FieldId As String) As String
            Return _
                CStr (CType (hstDictionaryItems.Item (FieldId), Hashtable).Item (CInt (FieldAttributes.DefaultValue)))
        End Function

        ''' --- GetInputScale ------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetInputScale.
        ''' </summary>
        ''' <param name="FieldId"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Function GetInputScale (ByVal FieldId As String) As String
            ' Not used
            Return String.Empty
            'Return CStr(CType(hstDictionaryItems.Item(FieldId), Hashtable).Item(CInt(FieldAttributes.InputScale)))
        End Function

        ''' --- GetItemDatatypeCode ------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetItemDatatypeCode.
        ''' </summary>
        ''' <param name="FieldId"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Function GetItemDatatypeCode (ByVal FieldId As String) As DataTypes
            Return _
                CType (CType (hstDictionaryItems.Item (FieldId), Hashtable).Item (FieldAttributes.ItemDataTypeCode), _
                    DataTypes)
        End Function

        ''' --- GetItemSize --------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetItemSize.
        ''' </summary>
        ''' <param name="FieldId"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Function GetItemSize (ByVal FieldId As String) As Integer
            Return CInt (CType (hstDictionaryItems.Item (FieldId), Hashtable).Item (CInt (FieldAttributes.ItemSize)))
        End Function

        ''' --- GetLeadingSign -----------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetLeadingSign.
        ''' </summary>
        ''' <param name="FieldId"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Function GetLeadingSign (ByVal FieldId As String) As String
            Return CStr (CType (hstDictionaryItems.Item (FieldId), Hashtable).Item (CInt (FieldAttributes.LeadingSign)))
        End Function

        ''' --- GetOutputScale -----------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetOutputScale.
        ''' </summary>
        ''' <param name="FieldId"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Function GetOutputScale (ByVal FieldId As String) As String
            ' Not used
            Return String.Empty
            'Return CStr(CType(hstDictionaryItems.Item(FieldId), Hashtable).Item(CInt(FieldAttributes.OutputScale)))
        End Function

        ''' --- GetPatternValue ----------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetPatternValue.
        ''' </summary>
        ''' <param name="FieldId"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Function GetPatternValue (ByVal FieldId As String) As String
            Return _
                CStr (CType (hstDictionaryItems.Item (FieldId), Hashtable).Item (CInt (FieldAttributes.PatternValue)))
        End Function

        ''' --- GetPicture ---------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetPicture.
        ''' </summary>
        ''' <param name="FieldId"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Function GetPicture (ByVal FieldId As String) As String
            Return CStr (CType (hstDictionaryItems.Item (FieldId), Hashtable).Item (CInt (FieldAttributes.Picture)))
        End Function

        ''' --- GetShiftInputCode --------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetShiftInputCode.
        ''' </summary>
        ''' <param name="FieldId"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Function GetShiftInputCode (ByVal FieldId As String) As ShiftTypes
            Return _
                CType (CType (hstDictionaryItems.Item (FieldId), Hashtable).Item (CInt (FieldAttributes.ShiftInputCode)), _
                    ShiftTypes)
        End Function

        ''' --- GetSeparator -------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetSeparator.
        ''' </summary>
        ''' <param name="FieldId"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Function GetSeparator (ByVal FieldId As String) As String
            Return CStr (CType (hstDictionaryItems.Item (FieldId), Hashtable).Item (CInt (FieldAttributes.Separator)))
        End Function

        ''' --- GetSignificance ----------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetSignificance.
        ''' </summary>
        ''' <param name="FieldId"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Function GetSignificance (ByVal FieldId As String) As Integer
            Return _
                CInt (CType (hstDictionaryItems.Item (FieldId), Hashtable).Item (CInt (FieldAttributes.Significance)))
        End Function

        ''' --- GetTrailingSign ----------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetTrailingSign.
        ''' </summary>
        ''' <param name="FieldId"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Function GetTrailingSign (ByVal FieldId As String) As String
            Return _
                CStr (CType (hstDictionaryItems.Item (FieldId), Hashtable).Item (CInt (FieldAttributes.TrailingSign)))
        End Function

        ''' --- GetDescription -----------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetDescription.
        ''' </summary>
        ''' <param name="FieldId"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Function GetDescription (ByVal FieldId As String) As String
            Return CStr (CType (hstDictionaryItems.Item (FieldId), Hashtable).Item (CInt (FieldAttributes.Description)))
        End Function

        ''' --- GetValues ----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetValues.
        ''' </summary>
        ''' <param name="FieldId"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Function GetValues (ByVal FieldId As String) As String
            Return CStr (CType (hstDictionaryItems.Item (FieldId), Hashtable).Item (CInt (FieldAttributes.Values)))
        End Function

        ''' --- GetControltype -----------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetControltype.
        ''' </summary>
        ''' <param name="FieldId"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Function GetControltype (ByVal FieldId As String) As String
            ' Not used
            Return String.Empty
            'Return CStr(CType(hstDictionaryItems.Item(FieldId), Hashtable).Item(CInt(FieldAttributes.ControlType)))
        End Function

        ''' --- GetLabelIsHyperLink ------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetLabelIsHyperLink.
        ''' </summary>
        ''' <param name="FieldId"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Function GetLabelIsHyperLink (ByVal FieldId As String) As String
            ' Not used
            Return String.Empty
            'Return CStr(CType(hstDictionaryItems.Item(FieldId), Hashtable).Item(CInt(FieldAttributes.LabelIsHyperLink)))
        End Function

        ''' --- GetLabelUrl --------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetLabelUrl.
        ''' </summary>
        ''' <param name="FieldId"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Function GetLabelUrl (ByVal FieldId As String) As String
            ' Not used
            Return String.Empty
            'Return CStr(CType(hstDictionaryItems.Item(FieldId), Hashtable).Item(CInt(FieldAttributes.LabelUrl)))
        End Function

        ''' --- GetDisplayClass ----------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetDisplayClass.
        ''' </summary>
        ''' <param name="FieldId"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Function GetDisplayClass (ByVal FieldId As String) As String
            ' Not used
            Return String.Empty
            'Return CStr(CType(hstDictionaryItems.Item(FieldId), Hashtable).Item(CInt(FieldAttributes.DisplayClass)))
        End Function

        ''' --- GetUsage -----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of GetUsage.
        ''' </summary>
        ''' <param name="FieldId"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Function GetUsage (ByVal FieldId As String) As String
            ' Not used
            Return String.Empty
            'Return CStr(CType(hstDictionaryItems.Item(FieldId), Hashtable).Item(CInt(FieldAttributes.Usage)))
        End Function

#End Region

#Region " Dispose and Finalize DictionaryItem "

        ' Dispose(Disposing As Boolean) executes in two distinct scenarios.
        ' If Disposing is true, the method has been called directly 
        ' or indirectly by a user's code. Managed and unmanaged resources 
        ' can be Disposed.
        ' If Disposing equals false, the method has been called by the runtime
        ' from inside the finalizer and you should not reference other    
        ' objects. Only unmanaged resources can be Disposed.
        ''' --- Dispose ------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of Dispose.
        ''' </summary>
        ''' <param name="Disposing"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Protected Overridable Overloads Sub Dispose (ByVal Disposing As Boolean)
            ' Check to see if Dispose has already been called.
            If Not (Me.Disposed) Then
                ' If Disposing equals true, dispose all managed 
                ' and unmanaged resources.
                If (Disposing) Then
                    ' Dispose managed resources.
                    TestDictionaryValue = Nothing
                    hstDictionaryItems.Clear()
                    hstDictionaryItems = Nothing
                End If
            End If
            Me.Disposed = True
        End Sub

        ' Implement IDisposable.
        ' Do not make this method Overridable.
        ' A derived class should not be able to override this method.
        ''' --- Dispose ------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of Dispose.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Overloads Sub Dispose() Implements IDisposable.Dispose
            Dispose (True)
            ' Take CoreDictionary off of the finalization queue
            ' to prevent finalization code for CoreDictionary
            ' from executing a second time.
            GC.SuppressFinalize (Me)
        End Sub

        ' This Finalize method will run only if the 
        ' Dispose method does not get called.
        ''' --- Finalize -----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of Finalize.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Protected Overrides Sub Finalize()
            ' Do not re-create Dispose clean-up code here.
            ' Calling Dispose(false) is optimal in terms of
            ' readability and maintainability.
            Dispose (False)
        End Sub

#End Region
    End Class

    ''' ----------------------------------------------------------------------------
    ''' 
    ''' Class	: ConfigSettingsReader
    ''' 
    ''' ----------------------------------------------------------------------------
    ''' <exclude />
    ''' 
    ''' <summary>
    ''' 	Summary of ConfigSettingsReader.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
    Public Class ConfigSettingsReader
        Inherits NameValueSectionHandler
        'We are using the default the implementation
    End Class

#Region " Dictionary Item Class "

    ''' ----------------------------------------------------------------------------
    ''' 
    ''' Class	: CoreDictionaryItem
    ''' 
    ''' ----------------------------------------------------------------------------
    ''' <exclude />
    ''' 
    ''' <summary>
    ''' 	Summary of CoreDictionaryItem.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
    Public Class CoreDictionaryItem
        Implements IDisposable

        Friend strElementName As String
        Friend strAlternateElementName As String
        Friend blnBwzFlag As Boolean
        Friend intDecimalPosition As Integer
        Friend intElementSize As Integer
        Friend intElementTypeCode As DataTypes
        Friend strHeading As String
        Friend strFill As String
        Friend strFloatValue As String
        Friend strDateFormatCode As String
        Friend strLabel As String
        Friend strHelp As String
        Friend strDefaultValue As String
        Friend strInputScale As String
        Friend intItemDatatypeCode As DataTypes
        Friend intItemSize As Integer
        Friend strLeadingSign As String
        Friend strOutputScale As String
        Friend strPatternValue As String
        Friend strPicture As String
        Friend intShiftInputCode As ShiftTypes
        Friend strSeparator As String
        Friend intSignificance As Integer
        Friend strTrailingSign As String
        Friend strDescription As String
        Friend strValues As String
        Friend strControltype As String
        Friend blnLabelIsHyperLink As Boolean
        Friend strLabelUrl As String
        Friend strDisplayClass As String
        Friend strUsage As String

        ' Track whether Dispose has been called.
        Private Disposed As Boolean = False

        ''' --- ElementName --------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of ElementName.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public ReadOnly Property ElementName() As String
            Get
                Return strElementName
            End Get
        End Property

        ''' --- AlternateElementName -----------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of AlternateElementName.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public ReadOnly Property AlternateElementName() As String
            Get
                Return strAlternateElementName
            End Get
        End Property

        ''' --- BwzFlag ------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of BwzFlag.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public ReadOnly Property BwzFlag() As Boolean
            Get
                Return blnBwzFlag
            End Get
        End Property

        ''' --- DecimalPosition ----------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of DecimalPosition.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public ReadOnly Property DecimalPosition() As Integer
            Get
                Return intDecimalPosition
            End Get
        End Property

        ''' --- ElementSize --------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of ElementSize.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public ReadOnly Property ElementSize() As Integer
            Get
                Return intElementSize
            End Get
        End Property

        ''' --- ElementTypeCode ----------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of ElementTypeCode.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public ReadOnly Property ElementTypeCode() As DataTypes
            Get
                Return intElementTypeCode
            End Get
        End Property

        ''' --- Heading ------------------------------------------------------------
        ''' <exclude />
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
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public ReadOnly Property Heading() As String
            Get
                Return strHeading
            End Get
        End Property

        ''' --- Fill ---------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of Fill.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public ReadOnly Property Fill() As String
            Get
                Return strFill
            End Get
        End Property

        ''' --- FloatValue ---------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of FloatValue.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public ReadOnly Property FloatValue() As String
            Get
                Return strFloatValue
            End Get
        End Property

        ''' --- DateFormatCode -----------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of DateFormatCode.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public ReadOnly Property DateFormatCode() As String
            Get
                Return strDateFormatCode
            End Get
        End Property

        ''' --- Label --------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of Label.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public ReadOnly Property Label() As String
            Get
                Return strLabel
            End Get
        End Property

        ''' --- Help ---------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of Help.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public ReadOnly Property Help() As String
            Get
                Return strHelp
            End Get
        End Property

        ''' --- DefaultValue -------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of DefaultValue.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public ReadOnly Property DefaultValue() As String
            Get
                Return strDefaultValue
            End Get
        End Property

        ''' --- InputScale ---------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of InputScale.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public ReadOnly Property InputScale() As String
            ' Not used
            Get
                Return strInputScale
            End Get
        End Property

        ''' --- ItemDatatypeCode ---------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of ItemDatatypeCode.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public ReadOnly Property ItemDatatypeCode() As ItemDataTypes
            Get
                Return intItemDatatypeCode
            End Get
        End Property

        ''' --- ItemSize -----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of ItemSize.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public ReadOnly Property ItemSize() As Integer
            Get
                Return intItemSize
            End Get
        End Property

        ''' --- LeadingSign --------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of LeadingSign.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public ReadOnly Property LeadingSign() As String
            Get
                Return strLeadingSign
            End Get
        End Property

        ''' --- OutputScale --------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of OutputScale.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public ReadOnly Property OutputScale() As String
            ' Not used
            Get
                Return strOutputScale
            End Get
        End Property

        ''' --- PatternValue -------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of PatternValue.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public ReadOnly Property PatternValue() As String
            Get
                Return strPatternValue
            End Get
        End Property

        ''' --- Picture ------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of Picture.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public ReadOnly Property Picture() As String
            Get
                Return strPicture
            End Get
        End Property

        ''' --- ShiftInputCode -----------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of ShiftInputCode.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public ReadOnly Property ShiftInputCode() As ShiftTypes
            Get
                Return intShiftInputCode
            End Get
        End Property

        ''' --- Separator ----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of Separator.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public ReadOnly Property Separator() As String
            Get
                Return strSeparator
            End Get
        End Property

        ''' --- Significance -------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of Significance.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public ReadOnly Property Significance() As Integer
            Get
                Return intSignificance
            End Get
        End Property

        ''' --- TrailingSign -------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of TrailingSign.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public ReadOnly Property TrailingSign() As String
            Get
                Return strTrailingSign
            End Get
        End Property

        ''' --- Description --------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of Description.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public ReadOnly Property Description() As String
            Get
                Return strDescription
            End Get
        End Property

        ''' --- Values -------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of Values.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public ReadOnly Property Values() As String
            Get
                Return strValues
            End Get
        End Property

        ''' --- Controltype --------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of Controltype.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public ReadOnly Property Controltype() As String
            ' Not used
            Get
                Return strControltype
            End Get
        End Property

        ''' --- LabelIsHyperLink ---------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of LabelIsHyperLink.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public ReadOnly Property LabelIsHyperLink() As Boolean
            ' Not used
            Get
                Return blnLabelIsHyperLink
            End Get
        End Property

        ''' --- LabelUrl -----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of LabelUrl.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public ReadOnly Property LabelUrl() As String
            ' Not used
            Get
                Return strLabelUrl
            End Get
        End Property

        ''' --- DisplayClass -------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of DisplayClass.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public ReadOnly Property DisplayClass() As String
            ' Not used
            Get
                Return strDisplayClass
            End Get
        End Property

        ''' --- Usage --------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of Usage.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public ReadOnly Property Usage() As String
            ' Not used
            Get
                Return strUsage
            End Get
        End Property

#Region " Dispose and Finalize DictionaryItem "

        ' Dispose(Disposing As Boolean) executes in two distinct scenarios.
        ' If Disposing is true, the method has been called directly 
        ' or indirectly by a user's code. Managed and unmanaged resources 
        ' can be Disposed.
        ' If Disposing equals false, the method has been called by the runtime
        ' from inside the finalizer and you should not reference other    
        ' objects. Only unmanaged resources can be Disposed.
        ''' --- Dispose ------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of Dispose.
        ''' </summary>
        ''' <param name="Disposing"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Protected Overridable Overloads Sub Dispose (ByVal Disposing As Boolean)
            ' Check to see if Dispose has already been called.
            If Not (Me.Disposed) Then
                ' If Disposing equals true, dispose all managed 
                ' and unmanaged resources.
                If (Disposing) Then
                    ' Dispose managed resources.
                    strElementName = Nothing
                    strAlternateElementName = Nothing
                    blnBwzFlag = Nothing
                    intDecimalPosition = Nothing
                    intElementSize = Nothing
                    intElementTypeCode = Nothing
                    strHeading = Nothing
                    strFill = Nothing
                    strFloatValue = Nothing
                    strDateFormatCode = Nothing
                    strLabel = Nothing
                    strHelp = Nothing
                    strDefaultValue = Nothing
                    strInputScale = Nothing
                    intItemDatatypeCode = Nothing
                    intItemSize = Nothing
                    strLeadingSign = Nothing
                    strOutputScale = Nothing
                    strPatternValue = Nothing
                    strPicture = Nothing
                    intShiftInputCode = Nothing
                    strSeparator = Nothing
                    intSignificance = Nothing
                    strTrailingSign = Nothing
                    strDescription = Nothing
                    strValues = Nothing
                    strControltype = Nothing
                    blnLabelIsHyperLink = Nothing
                    strLabelUrl = Nothing
                    strDisplayClass = Nothing
                    strUsage = Nothing
                End If
            End If
            Me.Disposed = True
        End Sub

        ' Implement IDisposable.
        ' Do not make this method Overridable.
        ' A derived class should not be able to override this method.
        ''' --- Dispose ------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of Dispose.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Public Overloads Sub Dispose() Implements IDisposable.Dispose
            Dispose (True)
            ' Take CoreDictionaryItem off of the finalization queue
            ' to prevent finalization code for CoreDictionaryItem
            ' from executing a second time.
            GC.SuppressFinalize (Me)
        End Sub

        ' This Finalize method will run only if the 
        ' Dispose method does not get called.
        ''' --- Finalize -----------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of Finalize.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable (EditorBrowsableState.Advanced)> _
        Protected Overrides Sub Finalize()
            ' Do not re-create Dispose clean-up code here.
            ' Calling Dispose(false) is optimal in terms of
            ' readability and maintainability.
            Dispose (False)
        End Sub

#End Region
    End Class

#End Region
End Namespace
