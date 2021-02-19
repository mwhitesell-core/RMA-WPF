Imports Core.Framework.Core.Framework
Imports Microsoft.Win32
Imports System.Collections
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Math
Imports System.Reflection
Imports System.Security
Imports System.Security.Permissions
Imports System.Threading
Imports System.Xml
Imports System.Xml.XmlNode

Namespace Core.ReportFramework

    Public Class Formatter

#Region "Declarations"

#Region "Variables"

        Public Shared m_htFieldValues As New Hashtable
        Public m_intPageCount As Integer = 1

        Private Const DateFormatType As Integer = 1
        Private Const TimeFormatType As Integer = 2
        Private Const DateTimeFormatType As Integer = 3

#End Region

#End Region

#Region "Methods"

#Region "Private"

        '<FileIOPermissionAttribute(SecurityAction.Assert)>
        <SecuritySafeCritical>
        Private Function FormatDateTimeValue(ByVal Value As String, ByVal Format As Integer, Optional ByVal strDateFormat As String = "", Optional ByVal BWZ As Boolean = True) As String

            Dim FileIOPermission As New FileIOPermission(PermissionState.Unrestricted)

            Dim configFile As String = String.Empty
            Dim configValue As String = String.Empty
            Dim dateFormat As String = String.Empty
            Dim dateSeparator As String = String.Empty
            Dim dateValue As Date
            Dim day As String = String.Empty
            Dim formattedValue As String = String.Empty
            Dim key As String = String.Empty
            Dim month As String = String.Empty
            Dim timeValue As String = String.Empty
            Dim year As String = String.Empty

            Dim xmlDoc As New XmlDocument

            Dim Value2 As Date

            Try
                FileIOPermission.Assert()

                'Get the configFile. Check if the report is executed from Reporting Services or the VS Report Previewer
                If Assembly.GetExecutingAssembly().Location.IndexOf("Reporting Services") > -1 Then
                    configFile = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location.Substring(0, Assembly.GetExecutingAssembly().Location.IndexOf("Reporting Services"))) & "\Reporting Services\ReportServer\bin\" & cREPORT_CONFIG
                Else
                    configFile = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) & "\" & cREPORT_CONFIG
                End If

                If (Value = "19000101" Or Value = "00010101" Or Value = "0" Or Value.ToUpper() = "NULL") AndAlso BWZ Then
                    formattedValue = ""
                Else
                    'Get the date format and separator from Report.config
                    xmlDoc.Load(configFile)

                    Dim Parent As XmlElement = xmlDoc.DocumentElement
                    Dim Child As XmlElement

                    For Each Child In Parent
                        key = Child.Attributes("key").Value
                        configValue = Child.Attributes("value").Value

                        If Parent.Name.Trim.ToUpper = "APPSETTINGS" Then
                            Select Case key
                                Case "DateFormat"
                                    If configValue.Length > 0 Then
                                        m_strDateFormat = configValue
                                    Else
                                        m_strDateFormat = "YYYYMMDD"
                                    End If

                                Case "DateSeparator"
                                    If configValue.Length > 0 Then
                                        m_strDateSeparator = configValue
                                    End If
                            End Select
                        End If
                    Next

                    'Check if a date format was passed in
                    If strDateFormat <> String.Empty Then
                        dateFormat = strDateFormat
                    Else
                        dateFormat = m_strDateFormat
                    End If
                    dateSeparator = m_strDateSeparator

                    'If Value.IndexOf("/") = -1 Then
                    '    Select Case System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern()
                    '        Case "M/d/yyyy"
                    '            Value2 = "#" + Value.Substring(4, 2) & "/" & Value.Substring(6, 2) & "/" & Value.Substring(0, 4) + "#"
                    '        Case "M/d/yy"
                    '            Value2 = "#" + Value.Substring(4, 2) & "/" & Value.Substring(6, 2) & "/" & Value.Substring(2, 2) + "#"
                    '        Case "MM/dd/yy"
                    '            Value2 = "#" + Value.Substring(4, 2) & "/" & Value.Substring(6, 2) & "/" & Value.Substring(2, 2) + "#"
                    '        Case "MM/dd/yyyy"
                    '            Value2 = "#" + Value.Substring(4, 2) & "/" & Value.Substring(6, 2) & "/" & Value.Substring(0, 4) + "#"
                    '        Case "yy/MM/dd"
                    '            Value2 = "#" + Value.Substring(2, 2) & "/" & Value.Substring(4, 2) & "/" & Value.Substring(6, 2) + "#"
                    '        Case "yyyy-MM-dd"
                    '            Value2 = "#" + Value.Substring(0, 4) & "-" & Value.Substring(4, 2) & "-" & Value.Substring(6, 2) + "#"
                    '        Case "dd-MMM-yy"
                    '            Value2 = "#" + Value.Substring(6, 2) & "-" & Value.Substring(4, 2) & "-" & Value.Substring(2, 2) + "#"
                    '        Case "dd-MMM-yyyy"
                    '            Value2 = "#" + Value.Substring(6, 2) & "-" & Value.Substring(4, 2) & "-" & Value.Substring(0, 4) + "#"
                    '    End Select
                    'Else
                    Value2 = "#" + Value + "#"
                    'End If

                    'Get the date and time value
                    'Select Case dateFormat
                    '    Case "DDMMYYYY"
                    '        Value3 = Value2.Day.ToString.PadLeft(2, "0") + Value2.Month.ToString.PadLeft(2, "0") + Value2.Year.ToString
                    '    Case "MMDDYYYY"
                    '        Value3 = Value2.Month.ToString.PadLeft(2, "0") + Value2.Day.ToString.PadLeft(2, "0") + Value2.Year.ToString
                    '    Case "YYYYMMDD"
                    '        Value3 = Value2.Year.ToString + Value2.Month.ToString.PadLeft(2, "0") + Value2.Day.ToString.PadLeft(2, "0")
                    'End Select

                    'dateValue = Date.ParseExact(Value3, dateFormat, System.Globalization.CultureInfo.InvariantCulture)
                    'year = dateValue.Year
                    'month = dateValue.Month
                    'day = dateValue.Day

                    year = Value2.Year
                    month = Value2.Month
                    day = Value2.Day

                    If InStr(strDateFormat, "^") Then
                        Dim position As Integer = 0
                        Dim dateValueString As String = year.ToString() + month.PadLeft(2, "0").ToString() + day.PadLeft(2, "0").ToString()
                        For Each c As Char In strDateFormat
                            If (c = "^") Then
                                position += 1
                                formattedValue += dateValueString.Substring(position - 1, 1)
                            Else
                                formattedValue += c
                            End If
                        Next
                    Else

                        'timeValue = CStr(CDate(Value).TimeOfDay.ToString.Substring(0, CDate(Value).TimeOfDay.ToString.LastIndexOf(":")))
                        If CStr(dateValue.TimeOfDay.ToString.Substring(0, dateValue.TimeOfDay.ToString.LastIndexOf(":"))) = "00:00" Then
                            timeValue = CStr(Now.TimeOfDay.ToString.Substring(0, Now.TimeOfDay.ToString.LastIndexOf(":")))
                        Else
                            timeValue = CStr(dateValue.TimeOfDay.ToString.Substring(0, dateValue.TimeOfDay.ToString.LastIndexOf(":")))
                        End If

                        If dateFormat = String.Empty Then
                            dateFormat = "yyyy/MM/dd"
                        Else
                            If dateSeparator = String.Empty Then
                                dateSeparator = "/"
                            End If
                            ' Ensure proper case for Year, Month and Day attributes.
                            dateFormat = dateFormat.Replace("Y", "y").Replace("D", "d").Replace("m", "M")

                            If InStr(dateFormat, "yM") > 0 Then                                 ' yyyyMMdd, yyMMdd, etc...
                                dateFormat = dateFormat.Insert(dateFormat.IndexOf("yM") + 1, "/")
                                dateFormat = dateFormat.Insert(dateFormat.IndexOf("Md") + 1, "/")
                            ElseIf InStr(dateFormat, "yd") > 0 Then                             ' yyyyddMM, yyddMM, etc...
                                dateFormat = dateFormat.Insert(dateFormat.IndexOf("yd") + 1, "/")
                                dateFormat = dateFormat.Insert(dateFormat.IndexOf("dM") + 1, "/")
                            ElseIf InStr(dateFormat, "dy") > 0 Then                             ' MMddyyyy, MMddyy, etc...
                                dateFormat = dateFormat.Insert(dateFormat.IndexOf("dy") + 1, "/")
                                dateFormat = dateFormat.Insert(dateFormat.IndexOf("Md") + 1, "/")
                            ElseIf InStr(dateFormat, "dM") > 0 Then                             ' ddMMyyyy, ddMMyy, etc...
                                dateFormat = dateFormat.Insert(dateFormat.IndexOf("dM") + 1, "/")
                                dateFormat = dateFormat.Insert(dateFormat.IndexOf("My") + 1, "/")
                            ElseIf InStr(dateFormat, "My") > 0 Then                             ' MMyy
                                dateFormat = dateFormat.Insert(dateFormat.IndexOf("My") + 1, "/")
                            End If
                        End If

                        Select Case Format
                            Case DateFormatType
                                formattedValue = GetDateFromYYYYMMDDDecimal(CStr(year) & CStr(month).PadLeft(2, "0") & CStr(day).PadLeft(2, "0")).ToString(dateFormat)
                                formattedValue = formattedValue.Replace("/", dateSeparator)

                            Case TimeFormatType
                                formattedValue = timeValue

                            Case DateTimeFormatType
                                formattedValue = GetDateFromYYYYMMDDDecimal(CStr(year) & CStr(month).PadLeft(2, "0") & CStr(day).PadLeft(2, "0")).ToString(dateFormat)
                                formattedValue = formattedValue.Replace("/", dateSeparator)
                                formattedValue = formattedValue & " " & timeValue
                        End Select
                    End If
                End If

            Catch ex As Exception
                If Format = DateFormatType Then
                    'formattedValue = CStr(Value.Substring(0, Value.IndexOf(" ")))
                    'formattedValue = ex.Message
                    formattedValue = CStr(Value)
                ElseIf Format = TimeFormatType Then
                    'formattedValue = ex.Message
                    formattedValue = CStr(Value.Substring(Value.Substring(":") - 2))
                Else
                    'formattedValue = ex.Message
                    formattedValue = CStr(Value)
                End If

            End Try

            Return formattedValue

        End Function

        'Format a numeric value for a define variable.
        <SecurityCritical>
        Private Function FormatNumberValue(ByVal Value As Decimal, ByVal BWZ As Boolean, ByVal TrailingSign As String, ByVal LeadingSign As String, ByVal Picture As String,
                                            ByVal Significance As Integer, ByVal OutputScale As Integer, ByVal FillCharacter As String, ByVal FloatCharacter As String,
                                            ByVal Size As Integer, ByVal ItemSize As Integer, ByVal strItemDataType As String) As String

            Dim formattedValue As String = String.Empty
            Dim ItemDataType As ItemDataTypes = ItemDataTypes.NotSet

            Try
                ' Apply output scale to value.
                Value *= (10 ^ OutputScale)
                formattedValue = CStr(Value)

                'ItemDataType = GetItemDataType(strItemDataType)
                Select Case strItemDataType.ToUpper
                    Case "CHARACTER"
                        ItemDataType = ItemDataTypes.Character

                    Case "DATE"
                        ItemDataType = ItemDataTypes.Date

                    Case "INTEGER"
                        ItemDataType = ItemDataTypes.Integer

                    Case "NUMERIC"
                        ItemDataType = ItemDataTypes.Numeric

                    Case "SIGNEDINTEGER"
                        ItemDataType = ItemDataTypes.SignedInteger

                    Case Else
                        ItemDataType = ItemDataTypes.NotSet

                End Select

                ApplyNumericFormatting("ELEMENT", formattedValue, BWZ, TrailingSign, LeadingSign, Picture, Significance, FillCharacter, FloatCharacter, Size, ItemSize, ItemDataType)

            Catch ex As Exception
                'formattedValue = CStr(Value)
                formattedValue = ex.Message

            End Try

            Return formattedValue

        End Function

        '<FileIOPermissionAttribute(SecurityAction.Assert)>
        <SecuritySafeCritical>
        Private Function ReadXMLFile(fileName As String) As XmlDocument

            Dim FileIOPermission As New FileIOPermission(PermissionState.Unrestricted)
            Dim xmlDocName As String = fileName

            Try
                FileIOPermission.Assert()

                Dim xmlDoc As XmlDocument = New XmlDocument()
                xmlDoc.Load(xmlDocName)

                Return xmlDoc

            Catch ex As Exception
                Return Nothing

            End Try

        End Function

        <SecuritySafeCritical>
        Private Function SysName() As String

            Dim FileIOPermission As New FileIOPermission(PermissionState.Unrestricted)
            Dim pathOfReportingServices As String = String.Empty
            Dim strKey As String
            Dim strValue As String

            FileIOPermission.Assert()

            If strSysName.Trim = String.Empty Then
                Dim xmlDoc As New XmlDocument

                If Assembly.GetExecutingAssembly().Location.IndexOf("Reporting Services") > -1 Then
                    pathOfReportingServices = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location.Substring(0, Assembly.GetExecutingAssembly().Location.IndexOf("Reporting Services"))) & "\Reporting Services\ReportServer\bin\"
                Else
                    pathOfReportingServices = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
                End If

                If Not pathOfReportingServices.EndsWith("\") Then
                    pathOfReportingServices += "\"
                End If

                xmlDoc.Load(pathOfReportingServices & cREPORT_CONFIG)

                Dim Parent As XmlElement = xmlDoc.DocumentElement
                Dim Child As XmlElement

                For Each Child In Parent
                    strKey = Child.Attributes("key").Value
                    strValue = Child.Attributes("value").Value

                    If Parent.Name.Trim.ToUpper = "APPSETTINGS" Then
                        Select Case strKey
                            Case "SysName"
                                If strValue.Trim.Length = 0 Then
                                    strSysName = "Renaissance Architect Reports"
                                Else
                                    strSysName = strValue
                                End If
                        End Select
                    End If
                Next
            End If

            Return strSysName

        End Function

#End Region

#Region "Public"

        Public Function FormatDateTimeValue(ByVal Value As String, ByVal Format As Integer, ByVal DateFormat As String) As String

            Dim returnValue As String = String.Empty

            Try
                Dim dateValue As Core.ReportFramework.Formatter = New Core.ReportFramework.Formatter


                returnValue = dateValue.FormatDateTimeValue(Value, Format, DateFormat, True)

            Catch ex As Exception
                'returnValue = Value
                returnValue = ex.Message

            End Try

            Return returnValue

        End Function

        Public Function FormatNumericValue(ByVal Value As Decimal, ByVal BWZ As String, ByVal TrailingSign As String,
                                           ByVal LeadingSign As String, ByVal Picture As String, ByVal Significance As Integer,
                                           ByVal OutputScale As Integer, ByVal FillCharacter As String, ByVal FloatCharacter As String, ByVal Size As Integer,
                                           ByVal ItemSize As Integer, ByVal ItemDataType As String) As String

            Dim returnValue As String = String.Empty         


            Try
                'Dim numValue As Core.ReportFramework.Formatter = New Core.ReportFramework.Formatter
                'returnValue = numValue.FormatNumberValue(Value, CBool(BWZ), TrailingSign, LeadingSign, Picture, Significance, OutputScale, FillCharacter, FloatCharacter, Size, ItemSize, ItemDataType)
                returnValue = FormatNumberValue(Value, CBool(BWZ), TrailingSign, LeadingSign, Picture, Significance, OutputScale, FillCharacter, FloatCharacter, Size, ItemSize, ItemDataType)

            Catch ex As Exception
                returnValue = CStr(Value)
            End Try

            Return returnValue

        End Function

       

        Public Function FormatStringValue(ByVal Value As String, ByVal Picture As String) As String

            Dim formattedValue As String = String.Empty

            Try
                If Not Value Is Nothing Then
                    formattedValue = Value

                    ApplyCharacterFormatting(formattedValue, Picture)

                    If formattedValue.Length < Picture.Length Then
                        formattedValue = formattedValue.PadRight(Picture.Length, " ")
                    End If
                End If

            Catch ex As Exception
                formattedValue = Value

            End Try

            Return formattedValue

        End Function

        '' STRING...
        'Public Function FormatValue(ByVal Value As String, ByVal Picture As String) As String

        '    Dim formattedValue As String = String.Empty

        '    Try
        '        If Not Value Is Nothing Then
        '            formattedValue = Value

        '            ApplyCharacterFormatting(formattedValue, Picture)
        '        End If

        '    Catch ex As Exception
        '        formattedValue = Value

        '    End Try

        '    Return formattedValue

        'End Function

        '' STRING with BWZ...
        'Public Function FormatValue(ByVal Value As String, ByVal Picture As String, ByVal Size As Integer, _
        '                            ByVal BWZ As Boolean) As String

        '    Dim formattedValue As String = String.Empty
        '    Dim ItemDataType As ItemDataTypes = ItemDataTypes.NotSet
        '    Dim TrailingSign As String = String.Empty
        '    Dim LeadingSign As String = String.Empty
        '    Dim Significance As Integer = 0
        '    Dim FillCharacter As String = String.Empty
        '    Dim FloatCharacter As String = String.Empty
        '    Dim ItemSize As Integer

        '    Try
        '        formattedValue = CStr(Value)

        '        ApplyNumericFormatting("ELEMENT", formattedValue, BWZ, TrailingSign, LeadingSign, Picture, Significance, _
        '            FillCharacter, FloatCharacter, Size, ItemSize, ItemDataType)

        '    Catch ex As Exception
        '        formattedValue = CStr(Value)

        '    End Try

        '    Return formattedValue

        'End Function

        '' DECIMAL for systime...
        'Public Function FormatValue(ByVal Value As Decimal, ByVal Picture As String, ByVal Size As Integer) As String

        '    Dim formattedValue As String = String.Empty
        '    Dim decTime As Decimal = 0D
        '    Dim ItemDataType As ItemDataTypes = ItemDataTypes.NotSet

        '    Try
        '        ' Determine if we need to add 0 to first postion.
        '        If Value.ToString.Length = 8 Then
        '            decTime = CDec(Substring(Value.ToString, 1, 4))
        '        ElseIf Value.ToString.Length = 7 Then
        '            decTime = CDec(Substring(Value.ToString, 1, 3))
        '        End If

        '        If Picture.Length > 0 And Len(decTime) = 4 Then
        '            Picture = Picture.Replace("^", "#")
        '            formattedValue = Format(decTime, Picture)
        '        Else
        '            formattedValue = Format(decTime, "0#:##")
        '        End If

        '    Catch ex As Exception
        '        formattedValue = CStr(Value)

        '    End Try

        '    Return formattedValue

        'End Function

        '' DECIMAL...
        'Public Function FormatValue(ByVal Value As Decimal, ByVal BWZ As Boolean, ByVal TrailingSign As String, _
        '                            ByVal LeadingSign As String, ByVal Picture As String, ByVal Significance As Integer, _
        '                            ByVal OutputScale As Integer, ByVal FillCharacter As String, ByVal FloatCharacter As String, ByVal Size As Integer, _
        '                            ByVal ItemSize As Integer, ByVal strItemDataType As String) As String

        '    Dim formattedValue As String = String.Empty
        '    Dim ItemDataType As ItemDataTypes = ItemDataTypes.NotSet

        '    Try
        '        ' Apply output scale to value.
        '        Value *= (10 ^ OutputScale)
        '        formattedValue = CStr(Value)

        '        ItemDataType = GetItemDataType(strItemDataType)

        '        ApplyNumericFormatting("ELEMENT", formattedValue, BWZ, TrailingSign, LeadingSign, Picture, Significance, _
        '            FillCharacter, FloatCharacter, Size, ItemSize, ItemDataType)

        '    Catch ex As Exception
        '        formattedValue = CStr(Value)

        '    End Try

        '    Return formattedValue

        'End Function

        '' SINGLE...
        'Public Function FormatValue(ByVal Value As Single, ByVal BWZ As Boolean, ByVal TrailingSign As String, _
        '                            ByVal LeadingSign As String, ByVal Picture As String, ByVal Significance As Integer, _
        '                            ByVal OutputScale As Integer, ByVal FillCharacter As String, ByVal FloatCharacter As String, ByVal Size As Integer, _
        '                            ByVal ItemSize As Integer, ByVal strItemDataType As String) As String

        '    Dim formattedValue As String = String.Empty
        '    Dim ItemDataType As ItemDataTypes = ItemDataTypes.NotSet

        '    Try
        '        ' Apply output scale to value.
        '        Value *= (10 ^ OutputScale)
        '        formattedValue = CStr(Value)

        '        ItemDataType = GetItemDataType(strItemDataType)

        '        ApplyNumericFormatting("ELEMENT", formattedValue, BWZ, TrailingSign, LeadingSign, Picture, Significance, _
        '            FillCharacter, FloatCharacter, Size, ItemSize, ItemDataType)

        '    Catch ex As Exception
        '        formattedValue = CStr(Value)

        '    End Try

        '    Return formattedValue

        'End Function

        '' DOUBLE...
        'Public Function FormatValue(ByVal Value As Double, ByVal BWZ As Boolean, ByVal TrailingSign As String, _
        '                            ByVal LeadingSign As String, ByVal Picture As String, ByVal Significance As Integer, _
        '                            ByVal OutputScale As Integer, ByVal FillCharacter As String, ByVal FloatCharacter As String, ByVal Size As Integer, _
        '                            ByVal ItemSize As Integer, ByVal strItemDataType As String) As String

        '    Dim formattedValue As String = String.Empty
        '    Dim ItemDataType As ItemDataTypes = ItemDataTypes.NotSet

        '    Try
        '        ' Apply output scale to value.
        '        Value = Math.Round(Value, OutputScale)
        '        Value *= (10 ^ OutputScale)
        '        formattedValue = CStr(Value)

        '        ItemDataType = GetItemDataType(strItemDataType)

        '        ApplyNumericFormatting("ELEMENT", formattedValue, BWZ, TrailingSign, LeadingSign, Picture, Significance, _
        '            FillCharacter, FloatCharacter, Size, ItemSize, ItemDataType)

        '    Catch ex As Exception
        '        formattedValue = CStr(Value)

        '    End Try

        '    Return formattedValue

        'End Function

        '' INTEGER...
        'Public Function FormatValue(ByVal Value As Integer, ByVal BWZ As Boolean, ByVal TrailingSign As String, _
        '                                ByVal LeadingSign As String, ByVal Picture As String, ByVal Significance As Integer, _
        '                                ByVal OutputScale As Integer, ByVal FillCharacter As String, ByVal FloatCharacter As String, ByVal Size As Integer, _
        '                                ByVal ItemSize As Integer, ByVal strItemDataType As String) As String

        '    Dim formattedValue As String = String.Empty
        '    Dim ItemDataType As ItemDataTypes = ItemDataTypes.NotSet

        '    Try
        '        ' Apply output scale to value.
        '        Value *= (10 ^ OutputScale)
        '        formattedValue = CStr(Value)

        '        ItemDataType = GetItemDataType(strItemDataType)

        '        ApplyNumericFormatting("ELEMENT", formattedValue, BWZ, TrailingSign, LeadingSign, Picture, Significance, _
        '            FillCharacter, FloatCharacter, Size, ItemSize, ItemDataType)

        '    Catch ex As Exception
        '        formattedValue = CStr(Value)

        '    End Try

        '    Return formattedValue

        'End Function

        'Public Function FormatValue(ByVal Value As Integer, ByVal BWZ As Boolean, ByVal TrailingSign As String, _
        '                                ByVal LeadingSign As String, ByVal Picture As String, ByVal Significance As Integer, _
        '                                ByVal OutputScale As Integer, ByVal FillCharacter As String, ByVal FloatCharacter As String, ByVal Size As Integer, _
        '                                ByVal ItemSize As Integer) As String

        '    Dim formattedValue As String = String.Empty
        '    Dim ItemDataType As ItemDataTypes = ItemDataTypes.NotSet

        '    Try
        '        ' Apply output scale to value.
        '        Value *= (10 ^ OutputScale)
        '        formattedValue = CStr(Value)


        '        ApplyNumericFormatting("ELEMENT", formattedValue, BWZ, TrailingSign, LeadingSign, Picture, Significance, _
        '            FillCharacter, FloatCharacter, Size, ItemSize, ItemDataType)

        '    Catch ex As Exception
        '        formattedValue = CStr(Value)

        '    End Try

        '    Return formattedValue

        'End Function

        '' DATE...
        'Public Function FormatValue(ByVal Value As Date, ByVal Format As String, ByVal Separator As String, _
        '                            Optional ByVal BWZ As Boolean = True) As String

        '    Dim formattedValue As String = String.Empty
        '    Dim dateFormat As String = Format

        '    Try
        '        If (Value = #12:00:00 AM# OrElse Value = #1/1/1900#) AndAlso BWZ Then
        '            formattedValue = ""
        '        Else
        '            If dateFormat.Length = 0 Then
        '                dateFormat = "yyyy/MM/dd"
        '            Else
        '                ' Ensure proper case for Year, Month and Day attributes.
        '                dateFormat = dateFormat.Replace("Y", "y").Replace("D", "d").Replace("m", "M")

        '                If Not dateFormat.Contains("/") Then
        '                    If InStr(dateFormat, "yM") > 0 Then                                 ' yyyyMMdd, yyMMdd, etc...
        '                        dateFormat = dateFormat.Insert(dateFormat.IndexOf("yM") + 1, "/")
        '                        dateFormat = dateFormat.Insert(dateFormat.IndexOf("Md") + 1, "/")
        '                    ElseIf InStr(dateFormat, "yd") > 0 Then                             ' yyyyddMM, yyddMM, etc...
        '                        dateFormat = dateFormat.Insert(dateFormat.IndexOf("yd") + 1, "/")
        '                        dateFormat = dateFormat.Insert(dateFormat.IndexOf("dM") + 1, "/")
        '                    ElseIf InStr(dateFormat, "dy") > 0 Then                             ' MMddyyyy, MMddyy, etc...
        '                        dateFormat = dateFormat.Insert(dateFormat.IndexOf("dy") + 1, "/")
        '                        dateFormat = dateFormat.Insert(dateFormat.IndexOf("Md") + 1, "/")
        '                    ElseIf InStr(dateFormat, "dM") > 0 Then                             ' ddMMyyyy, ddMMyy, etc...
        '                        dateFormat = dateFormat.Insert(dateFormat.IndexOf("dM") + 1, "/")
        '                        dateFormat = dateFormat.Insert(dateFormat.IndexOf("My") + 1, "/")
        '                    End If
        '                End If
        '            End If

        '            formattedValue = CDate(Value).ToString(dateFormat)

        '            If Separator.Length > 0 Then
        '                formattedValue = formattedValue.Replace("/", Separator)
        '            End If
        '        End If

        '    Catch ex As Exception
        '        formattedValue = CStr(Value)

        '    End Try

        '    Return formattedValue

        'End Function

        '' DATE...
        'Public Function FormatValue(ByVal Value As Decimal, ByVal Format As String, ByVal Separator As String, _
        '                            Optional ByVal BWZ As Boolean = True) As String

        '    Dim formattedValue As String = String.Empty
        '    Dim dateFormat As String = Format

        '    Try
        '        If (Value = 0D) AndAlso BWZ Then
        '            formattedValue = ""
        '        Else
        '            If dateFormat.Length = 0 Then
        '                dateFormat = "yyyy/MM/dd"
        '            Else
        '                ' Ensure proper case for Year, Month and Day attributes.
        '                dateFormat = dateFormat.Replace("Y", "y").Replace("D", "d").Replace("m", "M")

        '                If Not dateFormat.Contains("/") Then
        '                    If InStr(dateFormat, "yM") > 0 Then                                 ' yyyyMMdd, yyMMdd, etc...
        '                        dateFormat = dateFormat.Insert(dateFormat.IndexOf("yM") + 1, "/")
        '                        dateFormat = dateFormat.Insert(dateFormat.IndexOf("Md") + 1, "/")
        '                    ElseIf InStr(dateFormat, "yd") > 0 Then                             ' yyyyddMM, yyddMM, etc...
        '                        dateFormat = dateFormat.Insert(dateFormat.IndexOf("yd") + 1, "/")
        '                        dateFormat = dateFormat.Insert(dateFormat.IndexOf("dM") + 1, "/")
        '                    ElseIf InStr(dateFormat, "dy") > 0 Then                             ' MMddyyyy, MMddyy, etc...
        '                        dateFormat = dateFormat.Insert(dateFormat.IndexOf("dy") + 1, "/")
        '                        dateFormat = dateFormat.Insert(dateFormat.IndexOf("Md") + 1, "/")
        '                    ElseIf InStr(dateFormat, "dM") > 0 Then                             ' ddMMyyyy, ddMMyy, etc...
        '                        dateFormat = dateFormat.Insert(dateFormat.IndexOf("dM") + 1, "/")
        '                        dateFormat = dateFormat.Insert(dateFormat.IndexOf("My") + 1, "/")
        '                    End If
        '                End If
        '            End If

        '            formattedValue = GetDateFromYYYYMMDDDecimal(Value).ToString(dateFormat)

        '            If Separator.Length > 0 Then
        '                formattedValue = formattedValue.Replace("/", Separator)
        '            End If
        '        End If

        '    Catch ex As Exception
        '        formattedValue = CStr(Value)

        '    End Try

        '    Return formattedValue

        'End Function

        'Public Function GetFieldValue(ByVal strPageNumber As String, ByVal strName As String, ByVal strFormatValues As String) As String

        '    Dim objValue As String = Nothing
        '    Dim strFieldValue As String = Nothing
        '    Dim arrFormat() As String

        '    Dim strFieldName As String = String.Empty

        '    Try
        '        strFieldName = strPageNumber + "_" + strName
        '        objValue = m_htFieldValues.Item(strFieldName)

        '        arrFormat = strFormatValues.Split(",")

        '        Select Case arrFormat.GetUpperBound(0)
        '            Case 0
        '                strFieldValue = FormatValue(objValue, arrFormat.GetValue(0))

        '            Case 1
        '                If arrFormat.GetValue(0).ToString.Contains("^") Then
        '                    strFieldValue = FormatValue(CDec(objValue), arrFormat.GetValue(0), CInt(arrFormat.GetValue(1)))
        '                Else
        '                    strFieldValue = FormatValue(CDate(objValue), arrFormat.GetValue(0).ToString.Trim, arrFormat.GetValue(1).ToString.Trim)
        '                End If

        '            Case 2
        '                strFieldValue = FormatValue(CDate(objValue), arrFormat.GetValue(0), arrFormat.GetValue(1), arrFormat.GetValue(2))

        '            Case 9
        '                Select Case arrFormat(10).ToString
        '                    Case "Single"
        '                        strFieldValue = FormatValue(CDbl(objValue), arrFormat.GetValue(0), arrFormat.GetValue(1), arrFormat.GetValue(2), arrFormat.GetValue(3), arrFormat.GetValue(4), arrFormat.GetValue(5), arrFormat.GetValue(6), arrFormat.GetValue(7), arrFormat.GetValue(8), arrFormat.GetValue(9), arrFormat.GetValue(10))

        '                    Case "Double"
        '                        strFieldValue = FormatValue(CDbl(objValue), arrFormat.GetValue(0), arrFormat.GetValue(1), arrFormat.GetValue(2), arrFormat.GetValue(3), arrFormat.GetValue(4), arrFormat.GetValue(5), arrFormat.GetValue(6), arrFormat.GetValue(7), arrFormat.GetValue(8), arrFormat.GetValue(9), arrFormat.GetValue(10))

        '                    Case "Integer"
        '                        strFieldValue = FormatValue(CInt(objValue), arrFormat.GetValue(0), arrFormat.GetValue(1), arrFormat.GetValue(2), arrFormat.GetValue(3), arrFormat.GetValue(4), arrFormat.GetValue(5), arrFormat.GetValue(6), arrFormat.GetValue(7), arrFormat.GetValue(8), arrFormat.GetValue(9), arrFormat.GetValue(10))

        '                    Case "Decimal", "Float"
        '                        strFieldValue = FormatValue(CDec(objValue), arrFormat.GetValue(0), arrFormat.GetValue(1), arrFormat.GetValue(2), arrFormat.GetValue(3), arrFormat.GetValue(4), arrFormat.GetValue(5), arrFormat.GetValue(6), arrFormat.GetValue(7), arrFormat.GetValue(8), arrFormat.GetValue(9), arrFormat.GetValue(10))

        '                    Case Else
        '                        strFieldValue = FormatValue(CDec(objValue), arrFormat.GetValue(0), arrFormat.GetValue(1), arrFormat.GetValue(2), arrFormat.GetValue(3), arrFormat.GetValue(4), arrFormat.GetValue(5), arrFormat.GetValue(6), arrFormat.GetValue(7), arrFormat.GetValue(8), arrFormat.GetValue(9), arrFormat.GetValue(10))

        '                End Select
        '        End Select

        '    Catch ex As Exception

        '    End Try

        '    Return strFieldValue

        'End Function

        Public Function GetItemDataType(ByVal strItemDataType As String) As ItemDataTypes

            Dim ItemDataType As ItemDataTypes = ItemDataTypes.NotSet

            Try
                Select Case strItemDataType.ToUpper
                    Case "CHARACTER"
                        ItemDataType = ItemDataTypes.Character

                    Case "DATE"
                        ItemDataType = ItemDataTypes.Date

                    Case "INTEGER"
                        ItemDataType = ItemDataTypes.Integer

                    Case "NUMERIC"
                        ItemDataType = ItemDataTypes.Numeric

                    Case "SIGNEDINTEGER"
                        ItemDataType = ItemDataTypes.SignedInteger

                    Case Else
                        ItemDataType = ItemDataTypes.NotSet

                End Select

            Catch ex As Exception
                ItemDataType = ItemDataTypes.NotSet

            End Try

            Return ItemDataType

        End Function

        '<SecuritySafeCritical>
        <FileIOPermissionAttribute(SecurityAction.Assert)>
        Public Function GetSysName() As String

            Return SysName()

        End Function

        'Public Function HideSection(ByVal strNoReport As String) As Boolean

        '    Dim blnHide As Boolean = False

        '    Try
        '        If Not strNoReport = Nothing Then
        '            If strNoReport.ToUpper.Trim = "N" Then
        '                blnHide = False
        '            Else
        '                blnHide = True
        '            End If
        '        End If

        '    Catch ex As Exception
        '        blnHide = False

        '    End Try

        '    Return blnHide

        'End Function

        'Public Function SetFieldValue(ByVal strFieldName As String, ByVal objValue As Object) As Boolean

        '    Try
        '        If Not m_htFieldValues.Contains(m_intPageCount.ToString + "_" + strFieldName) Then
        '            strFieldName = m_intPageCount.ToString + "_" + strFieldName
        '            m_htFieldValues.Add(strFieldName, objValue)
        '        Else
        '            m_intPageCount += 1

        '            strFieldName = m_intPageCount.ToString + "_" + strFieldName
        '            m_htFieldValues.Add(strFieldName, objValue)
        '        End If

        '    Catch ex As Exception
        '        Return False

        '    End Try

        '    Return True

        'End Function

#End Region

#End Region

    End Class
End Namespace

