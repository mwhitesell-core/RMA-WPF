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
    <EditorBrowsable(EditorBrowsableState.Advanced)>
    Public Class HelpScreens
        Implements IDisposable

        Public TestDictionaryValue As String

        Private hstDictionaryItems As Hashtable
        Private Disposed As Boolean

        Public Sub New(ByVal DictionaryFileName As String)
            TestDictionaryValue = "Help Screen Values from: " + DictionaryFileName.Replace("Dictionary","Help")
            hstDictionaryItems = New Hashtable
            LoadDictionary(DictionaryFileName.Replace("Dictionary","Help"))
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
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Sub LoadDictionary(ByVal DictionaryFileName As String)
            'Note: Using XmlTextReader, instead of XMLDocument to make the loading faster 
            'At present its not strictly observing the Encoding specifiec in the XML File,
            'XmlTextReader always the default Encoding which is Windows-1252
            Dim objDictionaryXML As XmlTextReader
            If File.Exists(DictionaryFileName) Then
                objDictionaryXML = New XmlTextReader(DictionaryFileName)
                PopulateDictionaryItems(objDictionaryXML)
            Else
                'TODO: to be replaced with Exception Code that can display localized error message
                Throw New CustomApplicationException("Dictionary File Not found!")
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
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Sub PopulateDictionaryItems(ByVal DictionaryXMLReader As XmlTextReader)
            With DictionaryXMLReader
                Dim objDictionaryItemValues As Hashtable
                Dim strDictionaryItemName As String = ""

                Do While .Read
                    Select Case .NodeType
                        Case XmlNodeType.Element
                            'Debug.Write(("<" + Name))
                            If .Name.ToUpper.Equals("ELEMENT") Then
                                objDictionaryItemValues = New Hashtable(31)
                                'Debug.Write("Element: ")
                                'Debug.WriteLine(.Name)

                                While .MoveToNextAttribute()
                                    Select Case .Name
                                        Case "SCREEN_NAME"
                                            strDictionaryItemName = .Value
                                            objDictionaryItemValues.Add(CInt(FieldAttributes.ElementName),
                                                                         strDictionaryItemName)
                                        Case "TEXT"
                                            objDictionaryItemValues.Add(CInt(FieldAttributes.AlternateElementName),
                                                                         .Value)

                                    End Select
                                End While
                                If Not hstDictionaryItems.Contains(strDictionaryItemName) Then
                                    hstDictionaryItems.Add(strDictionaryItemName, objDictionaryItemValues)
                                End If

                            End If
                    End Select
                Loop
                objDictionaryItemValues = Nothing
            End With
        End Sub

       



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
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetDictionaryHashTable(ByVal FieldId As String) As Hashtable
            Return CType(hstDictionaryItems.Item(FieldId), Hashtable)
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
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetDictionaryItem(ByVal FieldId As String) As HelpScreensItem
            Dim objDictionaryItem As New HelpScreensItem
            Dim htDictionary As Hashtable
            htDictionary = CType(hstDictionaryItems.Item(FieldId), Hashtable)

            If htDictionary Is Nothing Then
                Return Nothing
            End If
            With objDictionaryItem
                .strScreenName = CStr(htDictionary.Item(0))
                .strText = CStr(htDictionary.Item(1))



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
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetElementName(ByVal FieldId As String) As String
            Return CStr(CType(hstDictionaryItems.Item(FieldId), Hashtable).Item(CInt(FieldAttributes.ElementName)))
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
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetAlternateElementName(ByVal FieldId As String) As String
            Return _
                CStr(
                    CType(hstDictionaryItems.Item(FieldId), Hashtable).Item(
                                                                               CInt(
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
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetBwzFlag(ByVal FieldId As String) As Boolean
            Return CBool(CType(hstDictionaryItems.Item(FieldId), Hashtable).Item(CInt(FieldAttributes.BwzFlag)))
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
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetDecimalPosition(ByVal FieldId As String) As Integer
            Return _
                CInt(CType(hstDictionaryItems.Item(FieldId), Hashtable).Item(CInt(FieldAttributes.DecimalPosition)))
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
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetElementSize(ByVal FieldId As String) As Integer
            Return CInt(CType(hstDictionaryItems.Item(FieldId), Hashtable).Item(CInt(FieldAttributes.ElementSize)))
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
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetElementTypeCode(ByVal FieldId As String) As DataTypes 'Check with Silviu later Discuss
            Return _
                CType(
                    CType(hstDictionaryItems.Item(FieldId), Hashtable).Item(CInt(FieldAttributes.ElementTypeCode)),
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
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetHeading(ByVal FieldId As String) As String
            Return CStr(CType(hstDictionaryItems.Item(FieldId), Hashtable).Item(CInt(FieldAttributes.Heading)))
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
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetFill(ByVal FieldId As String) As String
            Return CStr(CType(hstDictionaryItems.Item(FieldId), Hashtable).Item(CInt(FieldAttributes.Fill)))
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
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetFloatValue(ByVal FieldId As String) As String
            Return CStr(CType(hstDictionaryItems.Item(FieldId), Hashtable).Item(CInt(FieldAttributes.FloatValue)))
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
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetDateFormatCode(ByVal FieldId As String) As String
            Return _
                CStr(CType(hstDictionaryItems.Item(FieldId), Hashtable).Item(CInt(FieldAttributes.DateFormatCode)))
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
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetLabel(ByVal FieldId As String) As String
            Return CStr(CType(hstDictionaryItems.Item(FieldId), Hashtable).Item(CInt(FieldAttributes.Label)))
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
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetHelp(ByVal FieldId As String) As String
            Return CStr(CType(hstDictionaryItems.Item(FieldId), Hashtable).Item(CInt(FieldAttributes.Help)))
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
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetDefaultValue(ByVal FieldId As String) As String
            Return _
                CStr(CType(hstDictionaryItems.Item(FieldId), Hashtable).Item(CInt(FieldAttributes.DefaultValue)))
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
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetInputScale(ByVal FieldId As String) As String
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
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetItemDatatypeCode(ByVal FieldId As String) As DataTypes
            Return _
                CType(CType(hstDictionaryItems.Item(FieldId), Hashtable).Item(FieldAttributes.ItemDataTypeCode),
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
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetItemSize(ByVal FieldId As String) As Integer
            Return CInt(CType(hstDictionaryItems.Item(FieldId), Hashtable).Item(CInt(FieldAttributes.ItemSize)))
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
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetLeadingSign(ByVal FieldId As String) As String
            Return CStr(CType(hstDictionaryItems.Item(FieldId), Hashtable).Item(CInt(FieldAttributes.LeadingSign)))
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
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetOutputScale(ByVal FieldId As String) As String
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
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetPatternValue(ByVal FieldId As String) As String
            Return _
                CStr(CType(hstDictionaryItems.Item(FieldId), Hashtable).Item(CInt(FieldAttributes.PatternValue)))
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
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetPicture(ByVal FieldId As String) As String
            Return CStr(CType(hstDictionaryItems.Item(FieldId), Hashtable).Item(CInt(FieldAttributes.Picture)))
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
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetShiftInputCode(ByVal FieldId As String) As ShiftTypes
            Return _
                CType(CType(hstDictionaryItems.Item(FieldId), Hashtable).Item(CInt(FieldAttributes.ShiftInputCode)),
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
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetSeparator(ByVal FieldId As String) As String
            Return CStr(CType(hstDictionaryItems.Item(FieldId), Hashtable).Item(CInt(FieldAttributes.Separator)))
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
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetSignificance(ByVal FieldId As String) As Integer
            Return _
                CInt(CType(hstDictionaryItems.Item(FieldId), Hashtable).Item(CInt(FieldAttributes.Significance)))
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
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetTrailingSign(ByVal FieldId As String) As String
            Return _
                CStr(CType(hstDictionaryItems.Item(FieldId), Hashtable).Item(CInt(FieldAttributes.TrailingSign)))
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
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetDescription(ByVal FieldId As String) As String
            Return CStr(CType(hstDictionaryItems.Item(FieldId), Hashtable).Item(CInt(FieldAttributes.Description)))
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
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetValues(ByVal FieldId As String) As String
            Return CStr(CType(hstDictionaryItems.Item(FieldId), Hashtable).Item(CInt(FieldAttributes.Values)))
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
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetControltype(ByVal FieldId As String) As String
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
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetLabelIsHyperLink(ByVal FieldId As String) As String
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
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetLabelUrl(ByVal FieldId As String) As String
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
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetDisplayClass(ByVal FieldId As String) As String
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
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetUsage(ByVal FieldId As String) As String
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
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Protected Overridable Overloads Sub Dispose(ByVal Disposing As Boolean)
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
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Overloads Sub Dispose() Implements IDisposable.Dispose
            Dispose(True)
            ' Take CoreDictionary off of the finalization queue
            ' to prevent finalization code for CoreDictionary
            ' from executing a second time.
            GC.SuppressFinalize(Me)
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
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Protected Overrides Sub Finalize()
            ' Do not re-create Dispose clean-up code here.
            ' Calling Dispose(false) is optimal in terms of
            ' readability and maintainability.
            Dispose(False)
        End Sub

#End Region
    End Class



#Region " Dictionary Item Class "


    <EditorBrowsable(EditorBrowsableState.Advanced)>
    Public Class HelpScreensItem
        Implements IDisposable

        Friend strScreenName As String
        Friend strText As String


        ' Track whether Dispose has been called.
        Private Disposed As Boolean = False

        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public ReadOnly Property ScreenName() As String
            Get
                Return strScreenName
            End Get
        End Property

        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public ReadOnly Property Text() As String
            Get
                Return strText
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
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Protected Overridable Overloads Sub Dispose(ByVal Disposing As Boolean)
            ' Check to see if Dispose has already been called.
            If Not (Me.Disposed) Then
                ' If Disposing equals true, dispose all managed 
                ' and unmanaged resources.
                If (Disposing) Then
                    ' Dispose managed resources.
                    strScreenName = Nothing
                    strText = Nothing

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
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Overloads Sub Dispose() Implements IDisposable.Dispose
            Dispose(True)
            ' Take CoreDictionaryItem off of the finalization queue
            ' to prevent finalization code for CoreDictionaryItem
            ' from executing a second time.
            GC.SuppressFinalize(Me)
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
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Protected Overrides Sub Finalize()
            ' Do not re-create Dispose clean-up code here.
            ' Calling Dispose(false) is optimal in terms of
            ' readability and maintainability.
            Dispose(False)
        End Sub

#End Region
    End Class

#End Region
End Namespace
