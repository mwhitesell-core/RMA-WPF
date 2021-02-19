Imports Core.DataAccess.Oracle
Imports Core.Framework
Imports Core.Framework.Core.Framework
Imports Core.Framework.Core.Framework.QDesign
Imports Core.LogManagement
Imports Core.RDL.DataSetExtension
Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Data.OracleClient
Imports System.Diagnostics
Imports System.IO
Imports System.Reflection
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Security
Imports System.Security.Permissions
Imports System.Text
Imports System.Xml
Imports System.Collections.Specialized
Imports System.Collections

Namespace Core.ReportFramework

    Public Module ReportFunctions

#Region "Declarations"

#Region "Variables"

        ' Variables needed throughout the Report.
        Public strLanguage As String = String.Empty
        Public strDocumentId As String = String.Empty
        Public strReportTable As String = String.Empty
        Public strConnString As String = String.Empty
        Public strUserID As String = String.Empty
        Public strDictionary As String = String.Empty
        Public strReportFormat As String = String.Empty
        Public strDatabaseType As String = String.Empty
        Public strReportErrorLog As String = String.Empty
        Public strReportLogFile As String = String.Empty
        Public strReportLogPath As String = String.Empty
        Public strReportFileName As String = String.Empty
        Public strTitle As String = String.Empty
        Public strSysName As String = String.Empty
        Public strSubfileName As String = String.Empty

        Public m_strDefaultCentury As String = String.Empty
        Public m_strInputCenturyFrom As String = String.Empty
        Public m_strDateFormat As String = String.Empty
        Public m_strFlatFileDictionary As String = String.Empty
        Public m_strDateSeparator As String = String.Empty
        Public m_strFlatFilePath As String = String.Empty
        Public m_strSubfileSchema As String = String.Empty


        Public TextFiles As Hashtable = New Hashtable

        Public m_strGenericRetrievalCharacter As String = String.Empty

        Public RangeStart As String = String.Empty
        Public RangeEnd As String = String.Empty

        Public strSQLDataSource As String = String.Empty
        Public strInitialCatalog As String = String.Empty
        Public strSQLSettings As String = String.Empty
        Public strSessionManagerLocation As String = String.Empty
        Public strSessionID As String = String.Empty
        Public strCustomer As String = String.Empty

        Public blnUseDBSchema As Boolean = False

        Public astrScreenParameters() As String

        Public Const cNOT_FOUND As Integer = -1

        Public Const cPDF As String = ".pdf"
        Public Const cHTML As String = ".html"
        Public Const cXLS As String = ".xls"
        Public Const cRTF As String = ".rtf"
        Public Const cLOG As String = ".log"

        Public Const cREPORT_CONFIG As String = "Report.config"
        Public Const cDEFAULT_LOG As String = "ReportFramework.log"
        Public Const cDEFAULT_LOG_PATH As String = "C:\Temp\Renaissance Reports\"
        Public Const cUSERS_LOG As String = "Logs\"
        Public Const cUSERS_REPORTS As String = "Reports\"

        Public Const cDEFAULT_ERROR_LOG As String = "AppErrorReport"
        Public Const cDEFAULT_REPORT_NAME As String = "Unknown_Report_"

        Public Const cORACLE As String = "Oracle"
        Public Const cSQLSERVER As String = "SQLServer"
        Public Const cINFORMIX As String = "Informix"

        Public Const cDBO As String = ".dbo."
        Public Const cTEMP_SCHEMA As String = "TEMPORARY"

        Private Const cApplicationScope As String = "0003"

        Public intNumberedSessionID As Int32

        Public rptLog As LogManager = Nothing

        Public blnTableCreated As Boolean = False
        Public m_blnDebug As Boolean = False

#End Region

#End Region

#Region "Properties"

        Public Property DebugReport() As Boolean
            Get
                'Return m_blnDebug
                Return blnDebug
            End Get

            Set(ByVal value As Boolean)
                'Dim strLogFile As String

                'If strReportLogPath.Trim = String.Empty Then
                '    strLogFile = cDEFAULT_LOG_PATH + cDEFAULT_LOG
                'Else
                '    strLogFile = strReportLogFile
                'End If

                'm_blnDebug = value
                blnDebug = value
                rptLog = New LogManager(strLogFile, LogTypes.ErrorLog, strStatistics)
                If value Then
                    m_blnDebug = rptLog.OpenLogFile()
                End If
            End Set
        End Property

        Public Property AddToDatabase() As Boolean

#End Region

#Region "Methods"

#Region "Private"

        Private Function ParametersPassed() As Boolean

            If Not astrScreenParameters Is Nothing Then
                If astrScreenParameters.Length > 0 Then
                    For Each parameter As String In astrScreenParameters
                        If parameter Is Nothing Then
                            Return False
                        End If
                    Next
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If

        End Function

#End Region

#Region "Public"

        Public Function Center(strExpression As String, intLength As Integer) As String

            Dim intSpaces As Integer
            Dim newValue As String = String.Empty

            Try
                strExpression = strExpression.PadRight(intLength, " ")
                intSpaces = strExpression.Length - strExpression.Trim().Length

                Dim strSpaces As New String(" "c, intSpaces \ 2)

                ' If we have an even number of spaces.
                If intSpaces Mod 2 = 0 Then
                    newValue = strSpaces & strExpression.Trim() & strSpaces
                Else
                    newValue = strSpaces & strExpression.Trim() & strSpaces & " "
                End If

            Catch ex As Exception
                RecordReportError(GetLogFilePath(""), ex)
            End Try

            Return newValue

        End Function
        Public Function CreateDir(ByVal strNewDir As String) As Boolean

            Dim strPath As String = String.Empty
            Dim strTempDir As String = String.Empty
            Dim strServerName As String = String.Empty
            Dim strDriveName As String = String.Empty

            Dim blnSuccess As Boolean = False
            Dim blnDirExists As Boolean = False

            Dim intCounter As Integer = 0
            Dim intPos As Integer = 0

            Try
                CreateDir = False

                If InStr(1, strNewDir, "\\") = 1 Then
                    intPos = InStr(3, strNewDir, "\")
                    strServerName = Mid(strNewDir, 3, intPos - 3)
                    strDriveName = Mid(strNewDir, intPos + 1, 1)
                    strPath = Mid(strNewDir, intPos + 3)
                Else
                    strPath = strNewDir
                End If

                If Right$(strPath, 1) <> "\" Then
                    strPath = strPath & "\"
                End If

                intCounter = 1

                Do Until InStr(intCounter, strPath, "\") = 0
                    intCounter = InStr(intCounter, strPath, "\")

                    If strServerName <> "" Then
                        strTempDir = "\\" & strServerName & "\" & strDriveName & "\" & Left(strPath, intCounter)
                    Else
                        strTempDir = Left(strPath, intCounter - 1)
                    End If

                    blnDirExists = Directory.Exists(strTempDir)

                    If Not blnDirExists Then
                        Directory.CreateDirectory(strTempDir)
                        blnSuccess = True
                    End If
                    intCounter = intCounter + 1
                Loop

                CreateDir = blnSuccess

            Catch ex As Exception
                RecordReportError(GetLogFilePath(""), ex)
            End Try

        End Function

        Public Function DateToField(ByVal Value As Date) As String

            Dim strSQL As StringBuilder = New StringBuilder(String.Empty)

            Try
                If strDatabaseType = cORACLE Or strDatabaseType.Trim = "" Then
                    strSQL.Append("TO_DATE(")
                    strSQL.Append(Core.Framework.StringToField(Microsoft.VisualBasic.Strings.Format(Value, "yyyy/MM/dd")))
                    strSQL.Append(", 'YYYY/MM/DD')")
                ElseIf strDatabaseType = cSQLSERVER Then
                    strSQL.Append("CAST(")

                    If Value = cNullDate Or Value = cZeroDate Then
                        strSQL.Append("''")
                    Else
                        strSQL.Append(Core.Framework.StringToField(Microsoft.VisualBasic.Strings.Format(Value, "yyyyMMdd")))
                    End If

                    strSQL.Append(" AS Datetime)")
                End If

            Catch ex As Exception

            End Try

            Return strSQL.ToString

        End Function

        Public Function ExecuteAccessData(ByVal ReportHasParameters As Boolean) As Boolean

            If (Not ReportHasParameters) OrElse (ReportHasParameters AndAlso ParametersPassed()) Then
                If DebugReport Then
                    rptLog.WriteToLogFile(vbTab + vbTab + vbTab + vbTab + "ReportHasParameters: " & ReportHasParameters)
                    If astrScreenParameters Is Nothing Then
                        rptLog.WriteToLogFile(vbTab + vbTab + vbTab + vbTab + "astrScreenParameters is Nothing")
                    Else
                        rptLog.WriteToLogFile(vbTab + vbTab + vbTab + vbTab + "astrScreenParameters Length: " & astrScreenParameters.Length)
                    End If
                End If

                Return True
            Else
                If DebugReport Then
                    rptLog.WriteToLogFile(vbTab + vbTab + vbTab + vbTab + "ReportHasParameters: " & ReportHasParameters)
                    If astrScreenParameters Is Nothing Then
                        rptLog.WriteToLogFile(vbTab + vbTab + vbTab + vbTab + "astrScreenParameters is Nothing")
                    Else
                        rptLog.WriteToLogFile(vbTab + vbTab + vbTab + vbTab + "astrScreenParameters Length: " & astrScreenParameters.Length)
                    End If
                End If

                Return False
            End If

        End Function

        Public Function GetLogFilePath(ByVal strReportUsersDir As String) As String

            Dim strLogFilePath As String = String.Empty
            Dim strLogFileDir As String = String.Empty
            Dim strLogFileName As String = String.Empty

            Try
                If Trim(strReportUsersDir) <> Trim("") Then
                    If Right$(strReportUsersDir, 1) <> "\" Then strReportUsersDir = strReportUsersDir & "\"

                    strLogFileDir = strReportUsersDir & cUSERS_LOG

                    ' If the Log directory does not exist then create it.
                    If Not Directory.Exists(strLogFileDir) Then
                        CreateDir(strLogFileDir)
                    End If
                Else
                    ' There is no Users directory passed in, set the current directory as the target.
                    strLogFileDir = CurDir()
                End If

                If Right$(strLogFileDir, 1) <> "\" Then strLogFileDir = strLogFileDir & "\"

                ' Determine the Log's file name.
                If Trim(strReportFileName) <> Trim("") Then
                    strLogFileName = strReportFileName & cLOG
                Else
                    strLogFileName = cDEFAULT_ERROR_LOG & Format(Now(), "_yyyyMMdd_HHmmss") & cLOG
                End If

                ' The completed Log file path (full path and file name).
                strLogFilePath = strLogFileDir & strLogFileName

            Catch ex As Exception
                RecordReportError(CurDir() & "\" & cDEFAULT_ERROR_LOG & Format(Now(), "_yyyyMMdd_HHmmss") & cLOG, ex)

            End Try

            Return strLogFilePath

        End Function

        Public Function GetReportFilePath(ByVal strReportUsersDir As String) As String

            Dim strReportFilePath As String = String.Empty
            Dim strReportFileDir As String = String.Empty
            Dim strReportName As String = String.Empty

            Try
                If Trim(strReportUsersDir) <> Trim("") Then
                    If Right$(strReportUsersDir, 1) <> "\" Then strReportUsersDir = strReportUsersDir & "\"

                    strReportFileDir = strReportUsersDir & cUSERS_REPORTS

                    ' If the Report directory does not exist then create it.
                    If Not Directory.Exists(strReportFileDir) Then
                        CreateDir(strReportFileDir)
                    End If
                Else
                    ' There is no Users directory passed in, set the current directory as the target.
                    strReportFileDir = CurDir()
                End If

                If Right$(strReportFileDir, 1) <> "\" Then strReportFileDir = strReportFileDir & "\"

                ' Determine the Reports file name.
                If Trim(strReportFileName) <> Trim("") Then
                    strReportName = strReportFileName & strReportFormat
                Else
                    strReportName = cDEFAULT_REPORT_NAME & Format(Now(), "_yyyyMMdd_HHmmss") & cPDF
                End If

                ' The completed Report file path (full path and file name).
                strReportFilePath = strReportFileDir & strReportName


            Catch ex As Exception
                RecordReportError(GetLogFilePath(""), ex)
            End Try

            Return strReportFilePath

        End Function

        Public Function GetSystemVal(ByVal Name As String, Optional ByVal TypeCode As String = "") As String

            Return SessionInfo.GetSystemVal(Name, TypeCode, strSessionID)

        End Function

        Public Function GetTimeValue(ByVal dteDate As Date) As Decimal

            ' Return the date as a number.
            Dim x As Decimal = dteDate.Millisecond()

            ' If the Millisecond value is 0, add 00.
            If dteDate.Millisecond = 0 Then
                Return CDec(Format(dteDate.Hour, "00") & Format(dteDate.Minute, "00") & Format(dteDate.Second, "00") & "00")
            Else
                Return CDec(Format(dteDate.Hour, "00") & Format(dteDate.Minute, "00") & Format(dteDate.Second, "00") & dteDate.Millisecond.ToString.Substring(0, 2))
            End If

        End Function

        '<FileIOPermissionAttribute(SecurityAction.Assert)> _
        <SecuritySafeCritical>
        Public Sub InitializeFromReportConfig(ByVal strConfigFile As String, strCurrentDirectory As String)

            Dim strKey As String = String.Empty
            Dim strValue As String = String.Empty

            Dim FilePermission As New FileIOPermission(PermissionState.Unrestricted)

            Dim xmlDoc As New XmlDocument

            Try
                FilePermission.Assert()

                Try
                    xmlDoc.Load(strConfigFile)

                    Dim Parent As XmlElement = xmlDoc.DocumentElement
                    Dim Child As XmlElement

                    For Each Child In Parent
                        strKey = Child.Attributes("key").Value
                        strValue = Child.Attributes("value").Value

                        If Parent.Name.Trim.ToUpper = "APPSETTINGS" Then
                            Select Case strKey
                                Case "AuthenticationDatabase"
                                    If strValue.Trim.Length = 0 Or strValue = cORACLE Then
                                        strDatabaseType = cORACLE
                                    ElseIf strValue = cSQL_SERVER Then
                                        strDatabaseType = cSQLSERVER
                                    ElseIf strValue = cINFORMIX Then
                                        strDatabaseType = cINFORMIX
                                    End If

                                Case "DateFormat"
                                    If strValue.Length > 0 Then
                                        m_strDateFormat = strValue
                                    Else
                                        m_strDateFormat = "YYYYMMDD"
                                    End If

                                Case "FlatFileDictionary"
                                    If strValue.Length > 0 Then
                                        m_strFlatFileDictionary = strValue
                                    Else
                                        m_strFlatFileDictionary = ""
                                    End If

                                Case "DateSeparator"
                                    If strValue.Length > 0 Then
                                        m_strDateSeparator = strValue
                                    Else
                                        m_strDateSeparator = "/"
                                    End If

                                'Case "Debug"
                                '    If strValue.Length > 0 Then
                                '        m_blnDebug = strValue
                                '    Else
                                '        m_blnDebug = False
                                '    End If

                                Case "DefaultCentury"
                                    If strValue.Length > 0 Then
                                        m_strDefaultCentury = strValue
                                    End If

                                Case "FlatFilePath"
                                    m_strFlatFilePath = strCurrentDirectory


                                Case "GenericRetrievalCharacter"
                                    If strValue.Length = 0 Then
                                        m_strGenericRetrievalCharacter = "@"
                                    Else
                                        m_strGenericRetrievalCharacter = strValue
                                    End If

                                Case "InitialCatalog"
                                    If strValue.Trim.Length = 0 Then
                                        strInitialCatalog = "Initial Catalog=" + cTEMP_SCHEMA + ";"
                                    Else
                                        strInitialCatalog = strValue
                                    End If

                                Case "InputCenturyFrom"
                                    If strValue.Length > 0 Then
                                        m_strInputCenturyFrom = strValue
                                    End If

                                'Case "LogPath"
                                '    If strValue.Trim.Length = 0 Then
                                '        strReportLogPath = cDEFAULT_LOG_PATH
                                '    Else
                                '        If strValue.EndsWith("\") Then
                                '            strReportLogPath = strValue
                                '        Else
                                '            strReportLogPath = strValue + "\"
                                '        End If
                                '    End If

                                Case "LookupCharacter"

                                Case "SessionManager"
                                    If strValue.Trim.Length = 0 Then
                                        strSessionManagerLocation = "localhost:15124"
                                    Else
                                        strSessionManagerLocation = strValue
                                    End If

                                Case "SQLDataSource"
                                    If strValue.Trim.Length <> 0 Then
                                        strSQLDataSource = strValue
                                    End If

                                Case "SQLSettings"
                                    If strValue.Trim.Length = 0 Then
                                        strSQLSettings = "Integrated Security='false';"
                                    Else
                                        strSQLSettings = strValue
                                    End If

                                Case "SubFileSchema"
                                    If strValue.Length > 0 Then
                                        m_strSubfileSchema = strValue
                                    End If

                                Case "Title"
                                    If strValue.Trim.Length = 0 Then
                                        strTitle = "Renaissance Architect Reports"
                                    Else
                                        strTitle = strValue
                                    End If

                                Case "Customer"
                                    If strValue.Trim.Length <> 0 Then
                                        strCustomer = strValue
                                    End If

                                Case "UseDBSchema"
                                    If strValue.ToUpper = "TRUE" Then
                                        blnUseDBSchema = True
                                    End If
                            End Select
                        End If
                    Next

                Catch ex As Exception

                End Try

            Catch ex As Exception

            Finally
                xmlDoc = Nothing

            End Try

        End Sub

        Public Function OutputValue(ByVal ItemName As String, ByVal Value As Object) As String

            If IsNothing(Value) Then
                Return ""
            ElseIf Value.GetType.ToString = "System.String" Then
                Return OutputValue(ItemName, CStr(Value))
            ElseIf Value.GetType.ToString = "System.Decimal" OrElse Value.GetType.ToString = "System.Double" Then
                Return OutputValue(ItemName, CDec(Value))
            ElseIf Value.GetType.ToString = "System.DateTime" Then
                Return OutputValue(ItemName, CDate(Value))
            End If

            Return ""

        End Function

        ' STRING...
        Public Function OutputValue(ByVal ItemName As String, ByVal Value As String) As String

            Return Value

        End Function

        ' STRING with PICTURE...
        Public Function OutputValue(ByVal ItemName As String, ByVal Value As String, ByVal Picture As String) As String

            Dim formattedValue As String = String.Empty

            Try
                If Not Value Is Nothing Then
                    formattedValue = Value

                    ' Get the missing dictionary values.
                    GetDictionaryInfo(ItemName, Picture)

                    If Picture.Length = 0 Then Picture = ""
                    ApplyCharacterFormatting(formattedValue, Picture)
                End If

            Catch ex As Exception
                formattedValue = Value

            End Try

            Return formattedValue

        End Function

        Public Function OutputValue(ByVal ItemName As String, ByVal Value As Object, ByVal Picture As String) As String

            If IsNothing(Value) Then
                Return ""
            ElseIf Value.GetType.ToString = "System.String" Then
                Return OutputValue(ItemName, CStr(Value), Picture)
            ElseIf Value.GetType.ToString = "System.Decimal" OrElse Value.GetType.ToString = "System.Double" Then
                Return OutputValue(ItemName, CDec(Value), Picture)
            ElseIf Value.GetType.ToString = "System.DateTime" Then
                Return OutputValue(ItemName, CDate(Value), Picture)
            End If

            Return ""

        End Function

        ' STRING with BWZ...
        Public Function OutputValue(ByVal ItemName As String, ByVal Value As String, ByVal Picture As String, ByVal Size As Integer,
                                    ByVal BWZ As Boolean) As String

            Dim formattedValue As String = String.Empty

            Try
                formattedValue = CStr(Value)

                ' Get the missing dictionary values.
                Dim trailingSign As String = String.Empty
                Dim leadingSign As String = String.Empty
                Dim significance As Integer = 0
                Dim outputScale As Integer = 0
                Dim fillCharacter As String = String.Empty
                Dim floatCharacter As String = String.Empty
                Dim itemSize As Integer = 0
                Dim strItemDataType As String = String.Empty
                GetDictionaryInfo(ItemName, BWZ, trailingSign, leadingSign, Picture, significance, outputScale, fillCharacter, floatCharacter, itemSize, strItemDataType)

                ApplyNumericFormatting(ItemName, formattedValue, BWZ, trailingSign, leadingSign, Picture, significance,
                    fillCharacter, floatCharacter, Size, itemSize, strItemDataType)

            Catch ex As Exception
                formattedValue = CStr(Value)

            End Try

            Return formattedValue

        End Function

        Public Function OutputValue(ByVal ItemName As String, ByVal Value As Object, ByVal Picture As String, ByVal Size As Integer,
                                    ByVal BWZ As Boolean) As String

            If IsNothing(Value) Then
                Return ""
            ElseIf Value.GetType.ToString = "System.String" Then
                Return OutputValue(ItemName, CStr(Value), Picture, Size, BWZ)
            ElseIf Value.GetType.ToString = "System.Decimal" OrElse Value.GetType.ToString = "System.Double" Then
                Return OutputValue(ItemName, CDec(Value), Picture, Size, BWZ)
            ElseIf Value.GetType.ToString = "System.DateTime" Then
                Return OutputValue(ItemName, CDate(Value), Picture, Size, BWZ)
            End If

            Return ""

        End Function

        ' DECIMAL for systime...
        Public Function OutputValue(ByVal ItemName As String, ByVal Value As Decimal, ByVal Picture As String, ByVal Size As Integer) As String

            Dim formattedValue As String = String.Empty
            Dim decTime As Decimal = 0D
            Dim ItemDataType As ItemDataTypes = ItemDataTypes.NotSet

            Try
                ' Determine if we need to add 0 to first postion.
                If Value.ToString.Length = 8 Then
                    decTime = CDec(Substring(Value.ToString, 1, 4))
                ElseIf Value.ToString.Length = 7 Then
                    decTime = CDec(Substring(Value.ToString, 1, 3))
                End If

                ' Get the missing dictionary values.
                GetDictionaryInfo(ItemName, Picture)

                If Picture.Length > 0 And Len(decTime) = 4 Then
                    Picture = Picture.Replace("^", "#")
                    formattedValue = Format(decTime, Picture)
                Else
                    formattedValue = Format(decTime, "0#:##")
                End If

            Catch ex As Exception
                formattedValue = CStr(Value)

            End Try

            Return formattedValue

        End Function

        ' DECIMAL for systime...
        Public Function OutputValue(ByVal ItemName As String, ByVal Value As Decimal, ByVal Picture As String) As String

            Dim formattedValue As String = String.Empty
            Dim ItemDataType As ItemDataTypes = ItemDataTypes.NotSet

            Try
                ' Get the missing dictionary values.
                Dim trailingSign As String = String.Empty
                Dim leadingSign As String = String.Empty
                Dim significance As Integer = 0
                Dim outputScale As Integer = 0
                Dim fillCharacter As String = String.Empty
                Dim floatCharacter As String = String.Empty
                Dim itemSize As Integer = 0
                Dim strItemDataType As String = String.Empty
                Dim bwz As Boolean = False
                GetDictionaryInfo(ItemName, bwz, trailingSign, leadingSign, Picture, significance, outputScale, fillCharacter, floatCharacter, itemSize, strItemDataType)

                ItemDataType = RetrieveItemDataType(strItemDataType)

                formattedValue = CStr(Value)
                ApplyNumericFormatting(ItemName, formattedValue, bwz, trailingSign, leadingSign, Picture, significance,
                    fillCharacter, floatCharacter, itemSize, itemSize, ItemDataType)

            Catch ex As Exception
                formattedValue = CStr(Value)

            End Try

            Return formattedValue

        End Function

        ' DECIMAL...
        Public Function OutputValue(ByVal ItemName As String, ByVal Value As Decimal, ByVal BWZ As Boolean, ByVal TrailingSign As String,
                                    ByVal LeadingSign As String, ByVal Picture As String, ByVal Significance As Integer,
                                    ByVal OutputScale As Integer, ByVal FillCharacter As String, ByVal FloatCharacter As String, ByVal Size As Integer,
                                    ByVal ItemSize As Integer, ByVal strItemDataType As String) As String

            Dim formattedValue As String = String.Empty
            Dim ItemDataType As ItemDataTypes = ItemDataTypes.NotSet

            Try
                ' Apply output scale to value.
                Value *= (10 ^ OutputScale)
                formattedValue = CStr(Value)

                ' Get the missing dictionary values.
                GetDictionaryInfo(ItemName, BWZ, TrailingSign, LeadingSign, Picture, Significance, OutputScale, FillCharacter, FloatCharacter, ItemSize, strItemDataType)

                ItemDataType = RetrieveItemDataType(strItemDataType)

                ApplyNumericFormatting(ItemName, formattedValue, BWZ, TrailingSign, LeadingSign, Picture, Significance,
                    FillCharacter, FloatCharacter, Size, ItemSize, ItemDataType)

            Catch ex As Exception
                formattedValue = CStr(Value)

            End Try

            Return formattedValue

        End Function

        ' STRING as decimal...
        Public Function OutputValue(ByVal ItemName As String, ByVal strValue As String, ByVal BWZ As Boolean, ByVal TrailingSign As String,
                                    ByVal LeadingSign As String, ByVal Picture As String, ByVal Significance As Integer,
                                    ByVal OutputScale As Integer, ByVal FillCharacter As String, ByVal FloatCharacter As String, ByVal Size As Integer,
                                    ByVal ItemSize As Integer, ByVal strItemDataType As String) As String

            Dim formattedValue As String = String.Empty
            Dim ItemDataType As ItemDataTypes = ItemDataTypes.NotSet
            Dim Value As Decimal = 0D

            Try
                If strValue.Trim.Length > 0 Then
                    Value = CDec(strValue)
                End If

                ' Apply output scale to value.
                Value *= (10 ^ OutputScale)
                formattedValue = CStr(Value)

                ' Get the missing dictionary values.
                GetDictionaryInfo(ItemName, BWZ, TrailingSign, LeadingSign, Picture, Significance, OutputScale, FillCharacter, FloatCharacter, ItemSize, strItemDataType)

                ItemDataType = RetrieveItemDataType(strItemDataType)

                ApplyNumericFormatting(ItemName, formattedValue, BWZ, TrailingSign, LeadingSign, Picture, Significance,
                    FillCharacter, FloatCharacter, Size, ItemSize, ItemDataType)

            Catch ex As Exception
                formattedValue = CStr(Value)

            End Try

            Return formattedValue

        End Function

        ' SINGLE...
        Public Function OutputValue(ByVal ItemName As String, ByVal Value As Single, ByVal BWZ As Boolean, ByVal TrailingSign As String,
                                    ByVal LeadingSign As String, ByVal Picture As String, ByVal Significance As Integer,
                                    ByVal OutputScale As Integer, ByVal FillCharacter As String, ByVal FloatCharacter As String, ByVal Size As Integer,
                                    ByVal ItemSize As Integer, ByVal strItemDataType As String) As String

            Dim formattedValue As String = String.Empty
            Dim ItemDataType As ItemDataTypes = ItemDataTypes.NotSet

            Try
                ' Apply output scale to value.
                Value *= (10 ^ OutputScale)
                formattedValue = CStr(Value)

                ' Get the missing dictionary values.
                GetDictionaryInfo(ItemName, BWZ, TrailingSign, LeadingSign, Picture, Significance, OutputScale, FillCharacter, FloatCharacter, ItemSize, strItemDataType)

                ItemDataType = RetrieveItemDataType(strItemDataType)

                ApplyNumericFormatting(ItemName, formattedValue, BWZ, TrailingSign, LeadingSign, Picture, Significance,
                    FillCharacter, FloatCharacter, Size, ItemSize, ItemDataType)

            Catch ex As Exception
                formattedValue = CStr(Value)

            End Try

            Return formattedValue

        End Function

        ' DOUBLE...
        Public Function OutputValue(ByVal ItemName As String, ByVal Value As Double, ByVal BWZ As Boolean, ByVal TrailingSign As String,
                                    ByVal LeadingSign As String, ByVal Picture As String, ByVal Significance As Integer,
                                    ByVal OutputScale As Integer, ByVal FillCharacter As String, ByVal FloatCharacter As String, ByVal Size As Integer,
                                    ByVal ItemSize As Integer, ByVal strItemDataType As String) As String

            Dim formattedValue As String = String.Empty
            Dim ItemDataType As ItemDataTypes = ItemDataTypes.NotSet

            Try
                ' Get the missing dictionary values.
                GetDictionaryInfo(ItemName, BWZ, TrailingSign, LeadingSign, Picture, Significance, OutputScale, FillCharacter, FloatCharacter, ItemSize, strItemDataType)

                ' Apply output scale to value.
                Value = Math.Round(Value, OutputScale)
                Value *= (10 ^ OutputScale)
                formattedValue = CStr(Value)

                ItemDataType = RetrieveItemDataType(strItemDataType)

                ApplyNumericFormatting(ItemName, formattedValue, BWZ, TrailingSign, LeadingSign, Picture, Significance,
                    FillCharacter, FloatCharacter, Size, ItemSize, ItemDataType)

            Catch ex As Exception
                formattedValue = CStr(Value)

            End Try

            Return formattedValue

        End Function

        ' INTEGER...
        Public Function OutputValue(ByVal ItemName As String, ByVal Value As Integer, ByVal BWZ As Boolean, ByVal TrailingSign As String,
                                        ByVal LeadingSign As String, ByVal Picture As String, ByVal Significance As Integer,
                                        ByVal OutputScale As Integer, ByVal FillCharacter As String, ByVal FloatCharacter As String, ByVal Size As Integer,
                                        ByVal ItemSize As Integer, ByVal strItemDataType As String) As String

            Dim formattedValue As String = String.Empty
            Dim ItemDataType As ItemDataTypes = ItemDataTypes.NotSet

            Try
                ' Get the missing dictionary values.
                GetDictionaryInfo(ItemName, BWZ, TrailingSign, LeadingSign, Picture, Significance, OutputScale, FillCharacter, FloatCharacter, ItemSize, strItemDataType)

                ' Apply output scale to value.
                Value *= (10 ^ OutputScale)
                formattedValue = CStr(Value)

                ItemDataType = RetrieveItemDataType(strItemDataType)

                ApplyNumericFormatting(ItemName, formattedValue, BWZ, TrailingSign, LeadingSign, Picture, Significance,
                    FillCharacter, FloatCharacter, Size, ItemSize, ItemDataType)

            Catch ex As Exception
                formattedValue = CStr(Value)

            End Try

            Return formattedValue

        End Function

        Public Function OutputValue(ByVal ItemName As String, ByVal Value As Object, ByVal BWZ As Boolean, ByVal TrailingSign As String,
                                    ByVal LeadingSign As String, ByVal Picture As String, ByVal Significance As Integer,
                                    ByVal OutputScale As Integer, ByVal FillCharacter As String, ByVal FloatCharacter As String, ByVal Size As Integer,
                                    ByVal ItemSize As Integer, ByVal strItemDataType As String) As String

            If IsNothing(Value) Then
                Return ""
            ElseIf Value.GetType.ToString = "System.String" Then
                Return OutputValue(ItemName, CStr(Value), BWZ, TrailingSign, LeadingSign, Picture, Significance, OutputScale, FillCharacter, FloatCharacter, Size, ItemSize, strItemDataType)
            ElseIf Value.GetType.ToString = "System.Decimal" OrElse Value.GetType.ToString = "System.Double" Then
                Return OutputValue(ItemName, CDec(Value), BWZ, TrailingSign, LeadingSign, Picture, Significance, OutputScale, FillCharacter, FloatCharacter, Size, ItemSize, strItemDataType)
            ElseIf Value.GetType.ToString = "System.Integer" Then
                Return OutputValue(ItemName, CDec(Value), BWZ, TrailingSign, LeadingSign, Picture, Significance, OutputScale, FillCharacter, FloatCharacter, Size, ItemSize, strItemDataType)
            ElseIf Value.GetType.ToString = "System.DateTime" Then
                Return OutputValue(ItemName, CDate(Value), BWZ, TrailingSign, LeadingSign, Picture, Significance, OutputScale, FillCharacter, FloatCharacter, Size, ItemSize, strItemDataType)
            End If

            Return ""

        End Function

        Public Function OutputValue(ByVal ItemName As String, ByVal strValue As String, ByVal Format As String, ByVal Separator As String,
                                    Optional ByVal BWZ As Boolean = True) As String

            ' Get the missing dictionary values.
            GetDictionaryInfo(ItemName, Format, Separator)

            If strValue.Trim = "0" OrElse strValue.Trim = "" Then Return ""
            Dim formattedValue As String = String.Empty
            Dim dateFormat As String = Format
            If strValue.IndexOf(".") > 0 Then
                strValue = strValue.Substring(0, strValue.IndexOf("."))
            End If
            If strValue.Length < 7 Then
                dateFormat = dateFormat.Replace("yyyy", "yy")
            End If
            Dim Value As New Date()
            If strValue.Trim.Length > 0 Then
                Value = New Date(CInt(strValue.Substring(0, 4)), CInt(strValue.Substring(4, 2)), CInt(strValue.Substring(6, 2)))
            End If

            Try
                If (Value = #12:00:00 AM# OrElse Value = #1/1/1900#) AndAlso BWZ Then
                    formattedValue = ""
                Else
                    If dateFormat.Length = 0 Then
                        dateFormat = "yyyy/MM/dd"
                    Else
                        ' Ensure proper case for Year, Month and Day attributes.
                        dateFormat = dateFormat.Replace("Y", "y").Replace("D", "d").Replace("m", "M")

                        If Not dateFormat.Contains("/") Then
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
                            End If
                        End If
                    End If

                    formattedValue = CDate(Value).ToString(dateFormat)

                    If Separator.Length > 0 Then
                        formattedValue = formattedValue.Replace("/", Separator)
                    End If
                End If

            Catch ex As Exception
                formattedValue = CStr(Value)

            End Try

            Return formattedValue

        End Function

        ' DATE...
        Public Function OutputValue(ByVal ItemName As String, ByVal dcValue As Decimal, ByVal Format As String, ByVal Separator As String,
                                    Optional ByVal BWZ As Boolean = True) As String

            ' Get the missing dictionary values.
            GetDictionaryInfo(ItemName, Format, Separator)

            Dim formattedValue As String = String.Empty
            Dim dateFormat As String = Format
            Dim strValue As String = String.Empty
            Dim Value As Date

            If dcValue = 0 Then
                Value = New Date(0)
            Else
                If dcValue.ToString.IndexOf(".") > 0 Then
                    strValue = dcValue.ToString.Substring(0, dcValue.ToString.IndexOf("."))
                Else
                    strValue = dcValue.ToString
                End If

                If strValue.Length < 7 Then
                    strValue = strValue.PadLeft(6, "0")
                    dateFormat = dateFormat.Replace("yyyy", "yy")

                    If strValue.Substring(0, 2) = "00" Then
                        Value = New Date(2000, CInt(strValue.Substring(2, 2)), CInt(strValue.Substring(2, 2)))
                    Else
                        Value = New Date(CInt(strValue.Substring(0, 2)), CInt(strValue.Substring(2, 2)), CInt(strValue.Substring(2, 2)))
                    End If
                Else
                    Value = New Date(CInt(strValue.Substring(0, 4)), CInt(strValue.Substring(4, 2)), CInt(strValue.Substring(6, 2)))
                End If
            End If

            Try
                If (Value = #12:00:00 AM# OrElse Value = #1/1/1900#) AndAlso BWZ Then
                    formattedValue = ""
                Else
                    If dateFormat.Length = 0 Then
                        dateFormat = "yyyy/MM/dd"
                    Else
                        ' Ensure proper case for Year, Month and Day attributes.
                        dateFormat = dateFormat.Replace("Y", "y").Replace("D", "d").Replace("m", "M")

                        If Not dateFormat.Contains("/") Then
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
                            End If
                        End If
                    End If

                    formattedValue = CDate(Value).ToString(dateFormat)

                    If Separator.Length > 0 Then
                        formattedValue = formattedValue.Replace("/", Separator)
                    End If
                End If

            Catch ex As Exception
                formattedValue = CStr(Value)

            End Try

            Return formattedValue

        End Function

        ' DATE...
        Public Function OutputValue(ByVal ItemName As String, ByVal Value As Object, ByVal Format As String, ByVal Separator As String,
                                    Optional ByVal BWZ As Boolean = True) As String

            If IsNothing(Value) Then
                Return ""
            ElseIf Value.GetType.ToString = "System.String" Then
                Return OutputValue(ItemName, CStr(Value), Format, Separator, BWZ)
            ElseIf Value.GetType.ToString = "System.Decimal" OrElse Value.GetType.ToString = "System.Double" Then
                Return OutputValue(ItemName, CDec(Value), Format, Separator, BWZ)
            ElseIf Value.GetType.ToString = "System.DateTime" Then
                Return OutputValue(ItemName, CDate(Value), Format, Separator, BWZ)
            End If

            Return ""

        End Function

        Public Function OutputValue(ByVal ItemName As String, ByVal Value As Date, ByVal Format As String, ByVal Separator As String,
                                    Optional ByVal BWZ As Boolean = True) As String

            ' Get the missing dictionary values.
            GetDictionaryInfo(ItemName, Format, Separator)

            Dim formattedValue As String = String.Empty
            Dim dateFormat As String = Format

            Try
                If (Value = #12:00:00 AM# OrElse Value = #1/1/1900#) AndAlso BWZ Then
                    formattedValue = ""
                Else
                    If dateFormat.Length = 0 Then
                        dateFormat = "yyyy/MM/dd"
                    Else
                        ' Ensure proper case for Year, Month and Day attributes.
                        dateFormat = dateFormat.Replace("Y", "y").Replace("D", "d").Replace("m", "M")

                        If Not dateFormat.Contains("/") Then
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
                            End If
                        End If
                    End If

                    formattedValue = CDate(Value).ToString(dateFormat)

                    If Separator.Length > 0 Then
                        formattedValue = formattedValue.Replace("/", Separator)
                    End If
                End If

            Catch ex As Exception
                formattedValue = CStr(Value)

            End Try

            Return formattedValue

        End Function

        Public Sub RecordReportError(ByVal strLogPath As String, ByVal exError As Exception)

            'Dim rptErrorLogManager As LogManager

            Try
                'If DebugReport Then
                'rptLog.WriteToLogFile("Start ReportFunctions.RecordReportError")
                'End If

                '#If TARGET_DB = "INFORMIX" Then
                '                rptErrorLogManager = New LogManager(strLogPath, LogTypes.ErrorLog, m_strReportName)
                '#Else
                'rptErrorLogManager = New LogManager(strLogPath, LogTypes.ErrorLog)
                '#End If

                'rptErrorLogManager.CreateErrorCode(exError)
                'rptErrorLogManager = Nothing

                If DebugReport Then
                    rptLog.CreateErrorCode(exError)
                End If

                 If exError.Message.IndexOf("does not belong to table") >= 0 Then
                     rptLog.WriteToStatsFile(exError.Message, Environment.GetEnvironmentVariable("ReportName", EnvironmentVariableTarget.Process) )
                End If

                If exError.Message.IndexOf("Records Written: 0") >= 0 Then
                    Throw New Exception("Records Written: 0")
                End If

            Catch ex As Exception

                If exError.Message.IndexOf("Records Written: 0") >= 0 Then
                    Throw New Exception("Records Written: 0")
                Else
                    RecordReportError(GetLogFilePath(""), ex)
                End If

            End Try

            'If DebugReport Then
            'rptLog.WriteToLogFile("End ReportFunctions.RecordReportError")
            'End If

        End Sub

        Public Function RemoveSpaces(ByVal strExpression As String) As String

            Dim intCount As Integer
            Dim intPosition As Integer

            intPosition = strExpression.IndexOf(" ")

            Do While intPosition > 0
                intCount = intPosition
                strExpression = strExpression.Remove(intCount, 1)
                intPosition = strExpression.IndexOf(" ", intCount)
            Loop

            Return strExpression.ToString

        End Function

        Public Function RetrieveItemDataType(ByVal strItemDataType As String) As ItemDataTypes

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

        Public Sub SetRange(ByVal strValue As String)

            Dim arrValue As String()

            arrValue = strValue.Split("-"c)

            If arrValue.Length <> 0 Then
                Select Case arrValue.GetUpperBound(0)
                    Case 0
                        RangeStart = arrValue.GetValue(0).ToString
                        RangeEnd = String.Empty

                    Case 1
                        RangeStart = arrValue.GetValue(0).ToString
                        RangeEnd = arrValue.GetValue(1).ToString

                    Case Else
                        RangeStart = String.Empty
                        RangeEnd = String.Empty

                End Select
            Else
                RangeStart = String.Empty
                RangeEnd = String.Empty
            End If

            arrValue = Nothing

        End Sub

        Public Function WrapSingleQuotes(Value As String) As String

            ' Determine if the value is an empty string.
            If Value.Trim = String.Empty Then
                Return "' '"
            Else
                ' Replace the single quote with two single quotes.
                ' Add the single quote at the beginning and end of
                ' the value passed in if not called from a stored procedure.
                Return "'" & Value.Replace("'", "''") & "'"
            End If

        End Function
        '*************************************************************
        'PURPOSE: Write Entry to Event Log using VB.NET
        'PARAMETERS: Entry - Value to Write
        '            AppName - Name of Client Application. Needed 
        '              because before writing to event log, you must 
        '              have a named EventLog source. 
        '            EventType - Entry Type, from EventLogEntryType 
        '              Structure e.g., EventLogEntryType.Warning, 
        '              EventLogEntryType.Error
        '            LogName: Name of Log (System, Application; 
        '              Security is read-only) If you 
        '              specify a non-existent log, the log will be
        '              created

        'RETURNS:   True if successful, false if not

        'EXAMPLES: 
        '1. Simple Example, Accepting All Defaults
        '    WriteToEventLog "Hello Event Log"

        '2.  Specify EventSource, EventType, and LogName
        '    WriteToEventLog("Danger, Danger, Danger", "MyVbApp", _
        '                      EventLogEntryType.Warning, "System")
        '
        'NOTE:     EventSources are tightly tied to their log. 
        '          So don't use the same source name for different 
        '          logs, and vice versa
        '******************************************************
        Public Function WriteToEventLog(ByVal Entry As String,
                                        Optional ByVal AppName As String = "VB.NET Application",
                                        Optional ByVal EventType As _
                                        EventLogEntryType = EventLogEntryType.Information,
                                        Optional ByVal LogName As String = "Application") As Boolean

            Dim objEventLog As New EventLog()

            Try
                'Register the App as an Event Source
                If Not objEventLog.SourceExists(AppName) Then

                    objEventLog.CreateEventSource(AppName, LogName)
                End If

                objEventLog.Source = AppName

                'WriteEntry is overloaded; this is one
                'of 10 ways to call it
                objEventLog.WriteEntry(Entry, EventType)

                Return True

            Catch Ex As Exception
                Return False

            End Try

        End Function

        Public Sub WriteToLogFile(ByVal message As String)

            If DebugReport Then
                rptLog.WriteToLogFile(message)
            End If

        End Sub

#End Region

#End Region

    End Module

End Namespace
