
Imports Core.DataAccess
Imports Core.DataAccess.SqlServer
Imports Core.Framework
Imports Core.Framework.Core.Framework
Imports Core.Framework.Core.Security
Imports Core.Globalization
Imports Core.ReportFramework
Imports Microsoft.Win32
Imports System.Collections
Imports System.Collections.Specialized
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OracleClient
Imports System.Diagnostics
Imports System.IO
Imports System.Security
Imports System.Security.Permissions
Imports System.Reflection
Imports System.Text
Imports System.Xml
Imports System.Web

Namespace Core.ReportFramework

    Public Class BaseRDLClass

#Region "Declarations"

#Region "Variables"

        ' Data Helpers.
        Private m_reader As New Reader
        Private m_DataSet As DataSet
        Private m_DataTable As DataTable
        Private m_SortedDataTable As DataTable
        Private m_TextTable As DataTable
        ' SQLServer Connections.
        Public m_cnnQUERY As New SqlConnection
        Public m_cnnTRANS_UPDATE As SqlConnection
        Public m_trnTRANS_UPDATE As SqlTransaction
        Private m_blnCOMMIT As Boolean = False

        ' Session
        Private m_SessionManager As SessionInfo
        Private m_strSessionId As String = String.Empty
        Public m_objSession As SessionState.HttpSessionState

        ' Report
        Private m_strReportName As String
        Private m_blnReportHasParameters As Boolean
        Private m_strConfig As String

        ' SQL
        Private m_strDefaultSchema As String = String.Empty
        Private m_strDatabase As String = String.Empty
        Private m_strLanguage As String = String.Empty
        Private m_strReportedBy As String = String.Empty
        Private m_strCurrentDirectory As String = String.Empty
        Private strTableOwner As String
        Private m_strSort As String
        Private m_blnDeleteTable As Boolean = False

        ' SubFiles
        Private m_blnSubFile As Boolean = False
        Private m_blnSubFileAppend As Boolean = False

        Private m_blnOperationAt As Boolean = False

        Private m_strSubFileName As String = String.Empty
        Private m_strSubFileAT As String = String.Empty

        Private m_SubTotal As String = String.Empty

        Private m_sftSubFileType As SubFileType

        ' Temp Files
        Private m_blnTempFile As Boolean = False

        ' Controls
        Private htControls As New Hashtable
        Private arrControls As New ArrayList
        Private htControlsIndex As New Hashtable
        Private htNoReportControls As New Hashtable
        Private htNoReportControlsIndex As New Hashtable

        Private htSubFileSummary As New Hashtable
        Private htSubOperationSummary As New Hashtable
        Private htSubTotal As New Hashtable

        Private m_prevControl As String = String.Empty
        Private m_currControl As String = String.Empty
        Private m_prevValues As String = String.Empty
        Private m_currValues As String = String.Empty

        ' Miscellaneous
        Private m_intControlCount As Integer = 0
        Private m_intNoReportCount As Integer = 0
        Private m_RangeStart As String = String.Empty
        Private m_RangeEnd As String = String.Empty

        Private m_ReadRecordCount As Int32 = 0
        Private m_RecordCount As Int32 = 0
        Private m_FileName As String = String.Empty
#End Region

#Region " Enums "

        ' RDL Report Sections.
        Public Enum ReportSection As Int16
            INITIAL_HEADING = 0
            FINAL_FOOTING = 1
            PAGE_HEADING = 2
            PAGE_FOOTING = 3
            HEADING_AT = 4
            FOOTING_AT = 5
            REPORT = 6
            SUMMARY = 7
            NO_REPORT = 8
            UNDEFINED = 9
        End Enum

        Public Enum DataTypes As Int16
            VarChar = 0
            Character = 1
            [Integer] = 2
            SignedInteger = 3
            [Date] = 4
            DateTime = 5
            Numeric = 6
            Float = 7
        End Enum

        Public Enum SummaryType As Int16
            AVERAGE = 0
            COUNT = 1
            MAXIMUM = 2
            MINIMUM = 3
            PERCENT = 4
            RATIO = 5
            SUBTOTAL = 6
            TOTAL = 7
            UNDEFINED = 8
        End Enum

#End Region

#Region " Structures "

        Public Structure stcControl
            Dim Section As ReportSection
            Dim Name As String
            Dim DataType As DataTypes
            Dim Size As Integer
            Dim DecimalSize As Integer
            Dim BWZ As BooleanTypes
            Dim FillCharacter As String
            Dim FloatCharacter As String
            Dim Format As String
            Dim Heading As String
            Dim LeadingSign As String
            Dim TrailingSign As String
            Dim OutputScale As Integer
            Dim Picture As String
            Dim Separator As String
            Dim Significance As Integer
            Dim SummaryType As SummaryType
            Dim SubOperationAt As String
            Dim AliasName As String
        End Structure

#End Region

#End Region

#Region "Properties"
        Public Property ConfigFile() As String
            Get
                Return m_strConfig
            End Get

            Set(ByVal value As String)
                Dim strConfigPath As String = String.Empty

                ' value is the ReportAssembly path.
                strConfigPath = Substring(value, 1, value.LastIndexOf("\")) + "\" + cREPORT_CONFIG

                m_strConfig = strConfigPath
            End Set
        End Property

        Public WriteOnly Property Range() As String
            Set(ByVal value As String)
                Dim arrValue As String()

                m_RangeStart = String.Empty
                m_RangeEnd = String.Empty

                arrValue = value.Split("-"c)

                If arrValue.Length <> 0 Then
                    Select Case arrValue.GetUpperBound(0)
                        Case 0
                            m_RangeStart = arrValue.GetValue(0).ToString
                            m_RangeEnd = String.Empty

                        Case 1
                            m_RangeStart = arrValue.GetValue(0).ToString
                            m_RangeEnd = arrValue.GetValue(1).ToString

                        Case Else
                            m_RangeStart = String.Empty
                            m_RangeEnd = String.Empty

                    End Select
                Else
                    m_RangeStart = String.Empty
                    m_RangeEnd = String.Empty
                End If

                arrValue = Nothing
            End Set
        End Property

        Public Property ReportData() As DataSet
            Get
                Return m_DataSet
            End Get

            Set(ByVal value As DataSet)
                m_DataSet = value
            End Set
        End Property

        Public Property ReportHasParameters() As Boolean
            Get
                Return m_blnReportHasParameters
            End Get

            Set(ByVal value As Boolean)
                m_blnReportHasParameters = value
            End Set
        End Property

        Public Property ReportName() As String
            Get
                Return m_strReportName
            End Get

            Set(ByVal value As String)
                m_strReportName = value
                Environment.SetEnvironmentVariable("ReportName", value)
            End Set
        End Property

        Public WriteOnly Property SessionManager() As String
            Set(ByVal value As String)
                ' Create new session manager.
                m_SessionManager = New SessionInfo(TriState.UseDefault, value)
            End Set
        End Property

        Public Property Sort() As String
            Get
                Return m_strSort
            End Get

            Set(ByVal value As String)
                m_strSort = value
            End Set
        End Property

        Public Property SubFile() As Boolean
            Get
                Return m_blnSubFile
            End Get

            Set(ByVal value As Boolean)
                m_blnSubFile = value
            End Set
        End Property

        Public Property SubFileAppend() As Boolean
            Get
                Return m_blnSubFileAppend
            End Get

            Set(ByVal value As Boolean)
                m_blnSubFileAppend = value
            End Set
        End Property

        Public Property SubFileAT() As String
            Get
                Return m_strSubFileAT
            End Get

            Set(ByVal value As String)
                m_strSubFileAT = value
            End Set
        End Property





        Public Property SubFileName() As String
            Get
                Return m_strSubFileName
            End Get

            Set(ByVal value As String)
                m_strSubFileName = value
            End Set
        End Property

        Public Property SubFileType() As SubFileType
            Get
                Return m_sftSubFileType
            End Get

            Set(ByVal value As SubFileType)
                m_sftSubFileType = value
            End Set
        End Property

        Public Property TempFile() As Boolean
            Get
                Return m_blnTempFile
            End Get

            Set(ByVal value As Boolean)
                m_blnTempFile = value
                m_sftSubFileType = SubFileType.Temp
            End Set
        End Property

        Public Property UserID() As String
            Get
                Return Core.Framework.Core.Security.SecurityManager.GetCurrentUser
            End Get

            Set(value As String)

            End Set
        End Property

#End Region

#Region "Methods"

#Region " Private "

        Private Sub AddNoReportRecord()

            Dim drNoReport As DataRow

            Dim control As stcControl = Nothing

            Dim sbCreateTableSQL As New StringBuilder(String.Empty)

            Dim strValue As String = String.Empty
            Dim strControlValues As String = String.Empty
            Dim strColumnName As String = String.Empty
            Dim strDateValue As String = String.Empty

            Dim intSize As Integer = 0
            Dim intCount As Integer = 0

            Dim blnTemp As Boolean = False

            Try
                rptLog.WriteToLogFile(vbTab + vbTab + vbTab + vbTab + "Add no report record")

                If htControls.Count >= 0 Then
                    ' Determine table def'n, then create the table.
                    strControlValues = GetControlValues(sbCreateTableSQL, False)
                    CreateTable(sbCreateTableSQL)

                    ' Determine if we are dealing with a subfile.
                    If m_blnSubFile OrElse m_blnTempFile Then
                        If m_sftSubFileType = SubFileType.Temp Then
                            If m_blnTempFile Then
                                m_DataSet = New DataSet(ReportName)
                                m_DataSet.Tables.Add(m_DataTable)
                            Else
                                ' DataTable
                                Exit Sub
                            End If
                        Else
                            m_DataSet = New DataSet(ReportName)
                            m_DataSet.Tables.Add(m_DataTable)
                        End If
                    Else
                        blnTemp = True
                        ReportData = SqlHelper.ExecuteDataset(m_trnTRANS_UPDATE, CommandType.Text, GetDataSQL(ReportName, Sort, blnTemp))
                    End If
                End If

                drNoReport = m_DataSet.Tables(0).NewRow

                For intCount = 1 To htNoReportControls.Count
                    control = CType(htNoReportControls.Item(htNoReportControlsIndex(intCount)), stcControl)

                    strColumnName = control.Name

                    If strColumnName.IndexOf(".") > -1 Then
                        strColumnName = strColumnName.Substring(strColumnName.LastIndexOf(".") + 1)
                    End If

                    intSize = control.Size

                    If strColumnName.Trim = "NOREPORT" Then
                        drNoReport.Item(strColumnName) = ReturnNoReportSQL(ReportSection.NO_REPORT, intSize)
                    Else

                        If control.DataType = DataTypes.Date Then
                            strDateValue = ReturnControlValue(strColumnName, intSize)
                            strDateValue = strDateValue.Replace("'", "")
                            drNoReport.Item(strColumnName) = GetDateFromYYYYMMDDDecimal(strDateValue)
                        ElseIf control.DataType = DataTypes.Numeric Then
                            drNoReport.Item(strColumnName) = 0
                        Else
                            strValue = ReturnControlValue(strColumnName, intSize)

                            If strValue.StartsWith("'") Then
                                strValue = strValue.Remove(0, 1)
                            End If
                            If strValue.EndsWith("'") Then
                                strValue = strValue.Remove(strValue.Length - 1, 1)
                            End If

                            drNoReport.Item(strColumnName) = strValue
                        End If
                    End If
                Next

                m_DataSet.Tables(0).Rows.Add(drNoReport)

            Catch ex As Exception
                ' Write the exception to the log file.
                RecordReportError(strReportLogFile, ex)

            Finally
                If Not sbCreateTableSQL Is Nothing Then
                    sbCreateTableSQL = Nothing
                End If

            End Try

        End Sub

        Private Sub CompleteProcess()

            Try
                If m_blnCOMMIT Then
                    m_trnTRANS_UPDATE.Commit()
                End If

                m_trnTRANS_UPDATE.Dispose()

                If m_cnnTRANS_UPDATE.State <> ConnectionState.Closed Then
                    m_cnnTRANS_UPDATE.Close()
                End If

                m_cnnTRANS_UPDATE.Dispose()

                If m_cnnQUERY.State <> ConnectionState.Closed Then
                    m_cnnQUERY.Close()
                    m_cnnQUERY.Dispose()
                End If

            Catch ex As Exception
                ' Write the exception to the log file.
                RecordReportError(strReportLogFile, ex)

            End Try

        End Sub

        <SqlClientPermissionAttribute(SecurityAction.Assert)>
        Private Sub CreateTable(ByVal sbCreateTableSQL As StringBuilder)

            Dim sbSQL As New StringBuilder(String.Empty)

            Dim blnTableExists As Boolean = False
            Dim blnSessionTableExists As Boolean = False

            Dim SqlPermission As New SqlClientPermission(PermissionState.Unrestricted)

            Try
                SqlPermission.Assert()

                Try
                    If m_blnSubFile OrElse m_blnTempFile Then
                        ' Check to see if PERMANANT Table(SubFile) exists.
                        blnTableExists = TableSetup(m_strSubFileName, strConnString)

                        Try
                            If Not blnTableExists Then
                                If m_strSubFileName = "" Then
                                    m_strSubFileName = ReportName
                                End If

                                ' Check to see if SESSION Table exists.
                                m_DataTable = CType(m_SessionManager.GetSession(m_strSubFileName, m_strSessionId), DataTable)

                                If m_DataTable Is Nothing OrElse m_DataTable.Rows.Count = 0 Then
                                    blnSessionTableExists = False
                                Else
                                    blnSessionTableExists = True
                                End If
                            End If

                        Catch ex As Exception

                        End Try
                    Else
                        If AddToDatabase Then
                            blnTableExists = TableSetup(ReportName + "_TEMP", strConnString)
                        Else
                            blnTableExists = TableSetup("#" + ReportName + "_TEMP", strConnString)
                        End If

                    End If

                Catch ex As Exception
                    blnTableExists = False
                    blnSessionTableExists = False

                End Try

                If blnTableExists OrElse blnSessionTableExists Then
                    ' Table exists...
                    If m_blnSubFile OrElse m_blnTempFile Then
                        If Not m_blnSubFileAppend Then
                            If blnSessionTableExists Then
                                m_SessionManager.Remove(m_strSubFileName, m_strSessionId)

                                ' Create a New TEMPORARY table in Session.
                                CreateSessionDataTable()
                            Else
                                If blnUseDBSchema Then
                                    If m_blnDeleteTable Or (Not m_blnSubFileAppend) Then
                                        ' DELETE table data, since were are not appending to it.
                                        sbSQL.Append("DELETE FROM ").Append(m_strDatabase).Append(".").Append(m_strSubFileName)
                                        m_blnDeleteTable = False
                                    End If
                                Else
                                    If m_blnDeleteTable Or (Not m_blnSubFileAppend) Then
                                        ' DELETE table data, since were are not appending to it.
                                        sbSQL.Append("DELETE FROM ").Append(m_strDefaultSchema).Append(cDBO).Append(m_strSubFileName)
                                        m_blnDeleteTable = False
                                    End If
                                End If
                            End If
                        End If
                    Else
                        ' Drop Temporary table if exists.
                        sbSQL.Append("IF OBJECT_ID('tempDB..#").Append(ReportName).Append("_TEMP') IS NOT NULL").Append(vbNewLine)
                        sbSQL.Append("DELETE FROM #").Append(ReportName).Append("_TEMP ")
                    End If

                    Try
                        If sbSQL.ToString.Trim <> String.Empty Then
                            SqlHelper.ExecuteNonQuery(m_trnTRANS_UPDATE, CommandType.Text, sbSQL.ToString)
                        End If

                    Catch ex As SqlException
                        Throw ex

                    End Try
                Else
                    Try
                        ' Table does not exists, therefore create it.
                        If m_blnSubFile OrElse m_blnTempFile Then
                            If m_sftSubFileType = SubFileType.Keep And Not m_blnTempFile Then
                                ' Create a Permanent table in database.
                                SqlHelper.ExecuteNonQuery(m_trnTRANS_UPDATE, CommandType.Text, CreateTableSQL(sbCreateTableSQL, False))
                                m_blnCOMMIT = True
                                m_blnDeleteTable = True
                            Else
                                ' Create a TEMPORARY table in Session.
                                CreateSessionDataTable()
                            End If
                        Else
                            ' Creating the TEMPORARY table in the database.
                            SqlHelper.ExecuteNonQuery(m_trnTRANS_UPDATE, CommandType.Text, CreateTableSQL(sbCreateTableSQL, True))
                            ' Create the index using the primary key index of the tablename stored in PrimaryKeyTable. If there is no
                            ' primary key, no index will be created.
                        End If

                    Catch ex As SqlException
                        Throw ex

                    End Try
                End If

            Catch ex As Exception
                ' Write the exception to the log file.
                RecordReportError(strReportLogFile, ex)

            Finally
                sbSQL = Nothing

            End Try

        End Sub

        Private Function GetControlValues(ByRef sbCreateTableSQL As StringBuilder, ByVal blnRecordsFound As Boolean) As String

            Dim sbSQL As New StringBuilder(String.Empty)
            Dim sbTables As New StringBuilder(String.Empty)
            Dim strValue As String = String.Empty
            Dim strTableName As String = String.Empty
            Dim strControlValues As String = String.Empty

            Dim intCount As Integer = 0
            Dim control As stcControl

            Dim htTables As New Hashtable

            Try
                sbCreateTableSQL.Append("SELECT ")

                If DebugReport Then
                    rptLog.WriteToLogFile("")
                End If

                For intCount = 1 To htControls.Count
                    control = CType(htControls.Item(htControlsIndex(intCount)), stcControl)

                    If DebugReport Then
                        rptLog.WriteToLogFile(vbTab + vbTab + vbTab + vbTab + "GetControlValues: control: " & control.Name)
                    End If

                    If control.Name = "NOREPORT" Then
                        If blnRecordsFound Then
                            sbSQL.Append(ReturnNoReportSQL(ReportSection.REPORT, control.Size))
                        Else
                            sbSQL.Append(ReturnNoReportSQL(ReportSection.NO_REPORT, control.Size))
                        End If
                        sbCreateTableSQL.Append("''" + " Col" + intCount.ToString)
                    Else
                        strValue = ReturnControlValue(control.Name, control.Size)


                        If DebugReport Then
                            rptLog.WriteToLogFile(vbTab + vbTab + vbTab + vbTab + "GetControlValues: value: " & strValue)
                        End If

                        If control.Name.Contains(".") Then
                            sbCreateTableSQL.Append(control.Name + " Col" + intCount.ToString)

                            strTableName = control.Name.Substring(0, control.Name.LastIndexOf("."c))

                            If Not htTables.Contains(strTableName) Then
                                htTables.Add(strTableName, strTableName + ", ")
                            End If
                        Else
                            sbCreateTableSQL.Append("''" + " Col" + intCount.ToString)
                        End If
                        sbSQL.Append(strValue)
                    End If

                    If intCount < htControls.Count Then
                        sbSQL.Append("Ü")
                        sbCreateTableSQL.Append(", ")
                    End If
                Next

                ' Determine the table names of controls.
                For Each de As DictionaryEntry In htTables
                    sbTables.Append(de.Value)
                Next

                If sbTables.Length > 0 Then
                    ' Remove the last ', ' added to the string.
                    sbTables.Remove(Len(sbTables.ToString) - 2, 2)

                    ' Complete the Select statement.
                    sbCreateTableSQL.Append(" FROM ").Append(sbTables.ToString).Append(" WHERE 0 = 1")
                Else
                    ' All controls are defines, therefore return empty string.
                    sbCreateTableSQL.Remove(0, sbCreateTableSQL.Length)
                End If

                strControlValues = sbSQL.ToString

            Catch ex As Exception
                ' Write the exception to the log file.
                RecordReportError(strReportLogFile, ex)

            Finally
                sbTables = Nothing
                sbSQL = Nothing
                htTables = Nothing

            End Try

            Return strControlValues

        End Function

        Private Function GetSummaryType(ByVal dataType As DataTypes) As Type

            Dim objType As Object = Nothing

            Select Case dataType
                Case DataTypes.Character
                    objType = String.Empty

                Case DataTypes.Date, DataTypes.DateTime
                    objType = Date.Now

                Case DataTypes.Float
                    objType = 0.0

                Case DataTypes.Integer, DataTypes.Numeric
                    objType = 0

                Case DataTypes.VarChar
                    objType = String.Empty

            End Select

            Return objType.GetType

        End Function

        '<FileIOPermissionAttribute(SecurityAction.Assert)> _
        <SecuritySafeCritical>
        Private Sub InitializeProcess()

            Dim FileIOPermission As New FileIOPermission(PermissionState.Unrestricted)

            Try
                FileIOPermission.Assert()

                If DebugReport Then
                    rptLog.WriteToLogFile(vbTab + vbTab + vbTab + vbTab + "Start BaseRDLClass.InitializeProcess")
                End If

                ' Initialize Report Settings.
                InitializeFromReportConfig(ConfigFile, m_strCurrentDirectory)

            Catch ex As Exception
                ' Write the exception to the log file.
                RecordReportError(strReportLogFile, ex)

            End Try

            If DebugReport Then
                rptLog.WriteToLogFile(vbTab + vbTab + vbTab + vbTab + "End BaseRDLClass.InitializeProcess")
            End If
        End Sub

        Private Function InsertCondition(ByRef strValues As String) As Boolean

            Dim blnCondition As Boolean = False

            Dim intControlIndex As Integer = 0
            Dim intOperationIndex As Integer = 0
            Dim intCount As Integer = 0

            Dim control As stcControl

            Dim arrValues() As String

            Try
                If SubFileAT.Trim <> String.Empty Then
                    ' Array index is 0 based therefore we must subtract
                    ' 2 from the Control structure to get correct index.
                    intControlIndex = ReturnSubFileAtIndex() - 2

                    SetSummaryControl(strValues, intControlIndex)

                    intOperationIndex = ReturnOperationAtIndex()

                    If intOperationIndex <> 0 Then
                        intOperationIndex = intOperationIndex - 2
                        SetOperationSummaryControl(strValues, intOperationIndex)
                    End If

                    m_currValues = strValues

                    ' if the current control does not equal the previous then
                    ' we must add the previous value to the table.
                    If m_currControl.Trim <> m_prevControl.Trim Then
                        strValues = m_prevValues

                        m_prevControl = m_currControl
                        m_prevValues = m_currValues

                        blnCondition = True
                    Else
                        m_prevValues = strValues
                        blnCondition = False
                    End If
                Else
                    intOperationIndex = ReturnOperationAtIndex()

                    If intOperationIndex <> 0 Then
                        ' Array index is 0 based therefore we must subtract
                        ' 1 from the Control structure to get correct index.
                        intOperationIndex = intOperationIndex - 1

                        arrValues = SetOperationSummaryControl(strValues, intOperationIndex).Split("Ü")

                        m_currValues = strValues

                        ' if the current control does not equal the previous then
                        ' we must add the previous value to the table.
                        If m_currControl.Trim <> m_prevControl.Trim Then
                            htSubOperationSummary.Clear()

                            ' Perform summary operation on specified fields.
                            For intCount = 1 To htControls.Count
                                control = CType(htControls.Item(htControlsIndex(intCount)), stcControl)

                                If control.SubOperationAt.Trim <> String.Empty Then
                                    strValues = PerformOperationSummary(control, arrValues, intCount - 1)
                                End If
                            Next

                            strValues = m_prevValues

                            m_prevControl = m_currControl
                            m_prevValues = m_currValues

                            blnCondition = True
                        Else
                            m_prevValues = strValues
                            blnCondition = False
                        End If
                    Else
                        blnCondition = True
                    End If
                End If

            Catch ex As Exception
                ' Write the exception to the log file.
                RecordReportError(strReportLogFile, ex)

            End Try

            Return blnCondition

        End Function

        <SqlClientPermissionAttribute(SecurityAction.Assert)>
        Private Sub InsertData(ByVal strControlValues As String, ByVal blnTemp As Boolean)

            Dim sbSQL As New StringBuilder(String.Empty)

            Dim SqlPermission As New SqlClientPermission(PermissionState.Unrestricted)

            Try
                SqlPermission.Assert()

                With sbSQL
                    .Append("INSERT INTO ")

                    If blnTemp Then
                        If Not AddToDatabase Then
                            .Append("#")
                        End If

                    End If

                    If m_blnSubFile Then
                        .Append(m_strSubFileName)
                    Else
                        .Append(ReportName)
                    End If

                    If blnTemp Then
                        .Append("_TEMP")
                    End If

                    If strControlValues.Contains("Ü") Then
                        strControlValues = strControlValues.Replace("Ü", ",")
                    End If

                    .Append(" VALUES( ").Append(strControlValues).Append(")")
                End With

                ' Store data into Database.
                SqlHelper.ExecuteNonQuery(m_trnTRANS_UPDATE, CommandType.Text, sbSQL.ToString)

            Catch ex As Exception
                ' Write the exception to the log file.
                RecordReportError(strReportLogFile, ex)

            Finally
                sbSQL = Nothing

            End Try

        End Sub

        Private Sub InsertDataRow(ByVal strControlValues As String)

            Dim dtRow As DataRow
            Dim arrValues() As String = Nothing
            Dim strValue As String = String.Empty

            Try
                ' Insert control values into an array.
                arrValues = strControlValues.Split("Ü")

                dtRow = m_DataTable.NewRow

                ' Iterate through the columns in the new row and insert values.
                For j As Integer = 0 To m_DataTable.Columns.Count - 1
                    strValue = arrValues(j).ToString.Trim

                    If strValue.StartsWith("'") Then
                        strValue = strValue.Remove(0, 1)
                    End If

                    If strValue.EndsWith("'") Then
                        strValue = strValue.Remove(strValue.Length - 1, 1)
                    End If

                    If Not (m_DataTable.Columns(j).DataType.ToString = "System.DateTime" AndAlso (strValue = "0" OrElse strValue = "")) Then
                        If strValue.ToUpper.Contains("DATETIME") Then
                            dtRow.Item(m_DataTable.Columns(j).Ordinal) = GetDateFromYYYYMMDDDecimal(strValue.Substring(6, 8))
                        ElseIf (m_DataTable.Columns(j).DataType.ToString = "System.Decimal" AndAlso strValue.Trim = "") Then
                            dtRow.Item(m_DataTable.Columns(j).Ordinal) = 0D
                        Else
                            dtRow.Item(m_DataTable.Columns(j).Ordinal) = strValue
                        End If
                    End If
                Next

                ' Add new row with populated values to the datatable.
                m_DataTable.Rows.Add(dtRow)

            Catch ex As Exception
                ' Write the exception to the log file.
                RecordReportError(strReportLogFile, ex)

            Finally
                arrValues = Nothing

            End Try

        End Sub

        Private Sub InsertIntoDBTable(values As String)

            Dim arrValues As String() = values.Split("Ü")
            Dim control As stcControl

            Dim sw As StreamWriter
            Dim cnt As Integer
            Dim strValue As String
            Dim dc As DataColumn
            Dim rw As DataRow
            Dim controltype As String = ""
            Dim ColumnName As String

            Try

                If m_TextTable Is Nothing Then
                    m_TextTable = New DataTable

                    For cnt = 1 To htControls.Count
                        control = CType(htControls.Item(htControlsIndex(cnt)), stcControl)

                        If control.Name <> "NOREPORT" Then

                            dc = New DataColumn()

                            ColumnName = control.Name.Split(".")(control.Name.Split(".").Length - 1)


                            dc.ColumnName = ColumnName
                            controltype = control.DataType.ToString
                            If controltype = "Character" Then
                                controltype = "String"
                            ElseIf controltype = "Numeric" Then
                                controltype = "Decimal"
                            ElseIf controltype = "Integer" Then
                                controltype = "Decimal"
                            ElseIf controltype = "Date" Then
                                controltype = "DateTime"
                            End If
                            If Not controltype.StartsWith("System") Then
                                controltype = "System." + controltype
                            End If

                            dc.DataType = Type.GetType(controltype)

                            m_TextTable.Columns.Add(dc)
                        End If
                    Next
                End If

                rw = m_TextTable.NewRow

                For cnt = 1 To htControls.Count
                    control = CType(htControls.Item(htControlsIndex(cnt)), stcControl)

                    If control.Name <> "NOREPORT" Then

                        ColumnName = control.Name
                        ColumnName = control.Name.Split(".")(ColumnName.Split(".").Length - 1)
                        strValue = arrValues(cnt - 1)

                        Select Case control.DataType.ToString
                            Case "System.Character", "Character"

                                If strValue.Trim.Length > 1 AndAlso (strValue.Trim.Substring(0, 1) = "'" AndAlso strValue.Substring(strValue.Trim.Length - 1, 1) = "'") Then
                                    strValue = strValue.Trim.Substring(1)
                                    strValue = strValue.Trim.Substring(0, strValue.Trim.Length - 1)
                                End If

                                strValue = strValue.Replace("''", "'")

                                rw.Item(ColumnName) = strValue

                            Case "System.DateTime", "DateTime", "Date"
                                rw.Item(ColumnName) = strValue.Substring(0, 4) + "/" + strValue.Substring(4, 2) + "/" + strValue.Substring(6, 2)

                            Case "System.Numeric", "Numeric", "Integer", "Int64", "Decimal", "System.Integer", "System.Int64", "System.Decimal"
                                Dim tmpVal As String = strValue.Trim
                                Dim tmpsize As String = GetSubSize(control.Size, control.DataType.ToString)

                                If Not SubFile AndAlso control.SummaryType = SummaryType.SUBTOTAL Then
                                    rw.Item(ColumnName) = PerformSubtotal(ColumnName, tmpVal)
                                Else
                                    rw.Item(ColumnName) = tmpVal
                                End If
                        End Select

                        'If control.DataType.ToString = "System.DateTime" Then
                        '    fileText.Append(arrValues(cnt - 1).PadRight(8, ""))
                        'Else
                        '    fileText.Append(control.Size.ToString)
                        'End If
                    End If
                Next

                m_TextTable.Rows.Add(rw)

            Catch ex As Exception
                ' Write the exception to the log file.
                RecordReportError(strReportLogFile, ex)

            End Try

        End Sub

        Private Sub InsertIntoTextFile()

            Dim control As stcControl
            Dim strValue As String
            Dim fileText As StringBuilder = New StringBuilder(String.Empty)
            Dim sfFileName As String = SubFileName + ".sf"

            Dim valueat As String = ""
            Dim nextvalueat As String = ""

            Dim st As Hashtable = New Hashtable
            Dim ct As Hashtable = New Hashtable

            Dim resetSubTotal As Boolean = False

            Try
                If DebugReport Then
                    rptLog.WriteToLogFile(vbTab + vbTab + vbTab + vbTab + "Insert into Text File")
                End If

                If (Not m_strFlatFilePath.EndsWith("\")) Then
                    m_strFlatFilePath = m_strFlatFilePath + "\"
                End If

                sfFileName = m_strFlatFilePath.Replace("UserID", Environment.UserName) + sfFileName

                If DebugReport Then
                    rptLog.WriteToLogFile(vbTab + vbTab + vbTab + vbTab + "File Name: " & sfFileName)
                End If

                Dim addcarriage As Boolean
                If SubFileAppend Then
                    If File.Exists(sfFileName) Then
                        Dim sr As StreamReader = New StreamReader(sfFileName)
                        If Not sr.ReadToEnd.EndsWith(vbNewLine) Then
                            addcarriage = True
                        End If
                        sr.Dispose()
                    End If
                End If

                Dim sw = New StreamWriter(sfFileName, True)

                If Not IsNothing(m_TextTable) Then

                    If Sort.Length > 0 Then

                        Dim dtTemp As DataTable

                        dtTemp = m_TextTable.Clone()
                        Dim tmpDataRow As DataRow() = m_TextTable.[Select]("", Sort)

                        For i As Integer = 0 To tmpDataRow.Length - 1
                            dtTemp.Rows.Add(tmpDataRow(i).ItemArray)
                        Next
                        m_TextTable = New DataTable
                        m_TextTable = dtTemp
                    End If

                    For i As Integer = 0 To m_TextTable.Rows.Count - 1
                        For j As Integer = 0 To m_TextTable.Columns.Count - 1

                            For Each Item As Object In htControls
                                If DirectCast(DirectCast(Item, System.Collections.DictionaryEntry).Value, Core.ReportFramework.BaseRDLClass.stcControl).Name.EndsWith("." + m_TextTable.Columns(j).ColumnName) OrElse
                                    DirectCast(DirectCast(Item, System.Collections.DictionaryEntry).Value, Core.ReportFramework.BaseRDLClass.stcControl).Name = (m_TextTable.Columns(j).ColumnName) Then
                                    control = DirectCast(DirectCast(Item, System.Collections.DictionaryEntry).Value, Core.ReportFramework.BaseRDLClass.stcControl)
                                    Exit For
                                End If
                            Next

                            strValue = m_TextTable.Rows(i)(j).ToString

                            Select Case control.DataType.ToString
                                Case "System.Character", "Character", "VarChar"

                                    If strValue.Trim.Length > 1 AndAlso (strValue.Trim.Substring(0, 1) = "'" AndAlso strValue.Substring(strValue.Trim.Length - 1, 1) = "'") Then
                                        strValue = strValue.Trim.Substring(1)
                                        strValue = strValue.Trim.Substring(0, strValue.Trim.Length - 1)
                                    End If

                                    strValue = strValue.Replace("''", "'")

                                    fileText.Append(strValue.PadRight(control.Size, " "))

                                Case "System.DateTime", "DateTime", "Date"
                                    fileText.Append(strValue.PadRight(8, ""))

                                Case "System.Numeric", "Numeric", "Integer", "Int64", "Decimal", "System.Integer", "System.Int64", "System.Decimal"
                                    Dim tmpVal As String = strValue.Trim

                                    Dim tmpsize As String = GetSubSize(control.Size, control.DataType.ToString)

                                    If control.SummaryType = SummaryType.SUBTOTAL Then
                                        st(control.Name) = st(control.Name) + Convert.ToDecimal(tmpVal)
                                        tmpVal = st(control.Name).ToString
                                    ElseIf control.SummaryType = SummaryType.COUNT Then
                                        ct(control.Name) = ct(control.Name) + Convert.ToDecimal(tmpVal)
                                        tmpVal = ct(control.Name).ToString
                                    End If


                                    If tmpVal.Trim.StartsWith("-") Then
                                        tmpVal = tmpVal.Replace("-", "")
                                        tmpVal =
                                            tmpVal.PadLeft(tmpsize - 1, "0").
                                                Substring(0, tmpsize - 1)
                                        tmpVal = "-" & tmpVal
                                    Else
                                        tmpVal =
                                            tmpVal.PadLeft(tmpsize - 1, "0").
                                                Substring(0, tmpsize - 1)
                                        tmpVal = "+" & tmpVal
                                    End If

                                    strValue = tmpVal

                                    fileText.Append(tmpVal)
                            End Select
                        Next

                        If SubFileAT.Length > 0 Then
                            Dim foundat As Boolean = False

                            valueat = ""
                            nextvalueat = ""


                            For j As Integer = 0 To m_TextTable.Columns.Count - 1
                                If Not foundat Then
                                    valueat = valueat + m_TextTable.Rows(i)(j).ToString
                                    If m_TextTable.Columns(j).ColumnName = SubFileAT Then
                                        foundat = True
                                        Exit For
                                    End If
                                End If
                            Next

                            If m_TextTable.Rows.Count - 1 > i Then
                                foundat = False
                                For j As Integer = 0 To m_TextTable.Columns.Count - 1
                                    If Not foundat Then
                                        nextvalueat = nextvalueat + m_TextTable.Rows(i + 1)(j).ToString
                                        If m_TextTable.Columns(j).ColumnName = SubFileAT Then
                                            foundat = True
                                            Exit For
                                        End If
                                    End If
                                Next

                                If valueat <> nextvalueat Then
                                    If SubFileAppend = True Then
                                        sw.Write(vbNewLine + fileText.ToString)
                                    Else
                                        sw.Write(fileText.ToString + vbNewLine)
                                    End If

                                    For j As Integer = 0 To m_TextTable.Columns.Count - 1
                                        If Not IsNothing(st(m_TextTable.Columns(j).ColumnName)) Then
                                            st(m_TextTable.Columns(j).ColumnName) = 0
                                        End If
                                        If Not IsNothing(ct(m_TextTable.Columns(j).ColumnName)) Then
                                            ct(m_TextTable.Columns(j).ColumnName) = 0
                                        End If
                                    Next

                                    st = New Hashtable
                                    ct = New Hashtable

                                Else
                                    m_RecordCount = m_RecordCount - 1
                                End If
                            Else
                                If addcarriage Then
                                    sw.Write(vbNewLine + fileText.ToString)
                                    addcarriage = True
                                Else
                                    sw.Write(fileText.ToString)
                                    addcarriage = True
                                End If
                            End If
                        Else
                            If addcarriage Then
                                sw.Write(vbNewLine + fileText.ToString)
                                addcarriage = True
                            Else
                                sw.Write(fileText.ToString)
                                addcarriage = True
                            End If
                        End If

                        fileText = New StringBuilder("")
                    Next
                End If

                sw.Flush()
                sw.Close()
                sw.Dispose()

                If DebugReport Then
                    rptLog.WriteToLogFile(vbTab + vbTab + vbTab + vbTab + "Finished inserted records into subfile")
                End If

            Catch ex As Exception
                If DebugReport Then
                    rptLog.WriteToLogFile(vbTab + vbTab + vbTab + vbTab + "Error: " & ex.Message)
                End If
            End Try

        End Sub

        Private Sub InsertIntoTextFile(values As String)

            Dim arrValues As String() = values.Split("Ü")
            Dim control As stcControl
            Dim sfFileName As String = SubFileName + ".sf"
            Dim fileText As StringBuilder = New StringBuilder(String.Empty)
            Dim sw As StreamWriter
            Dim cnt As Integer
            Dim strValue As String
            Try
                If (Not m_strFlatFilePath.EndsWith("\")) Then
                    m_strFlatFilePath = m_strFlatFilePath + "\"
                End If

                sfFileName = m_strFlatFilePath.Replace("UserID", Environment.UserName) + sfFileName





                For cnt = 1 To htControls.Count
                    control = CType(htControls.Item(htControlsIndex(cnt)), stcControl)

                    If control.Name <> "NOREPORT" Then

                        strValue = arrValues(cnt - 1)

                        Select Case control.DataType.ToString
                            Case "System.Character", "Character"

                                If strValue.Trim.Length > 1 AndAlso (strValue.Trim.Substring(0, 1) = "'" AndAlso strValue.Substring(strValue.Trim.Length - 1, 1) = "'") Then
                                    strValue = strValue.Trim.Substring(1)
                                    strValue = strValue.Trim.Substring(0, strValue.Trim.Length - 1)
                                End If

                                strValue = strValue.Replace("''", "'")

                                fileText.Append(strValue.PadRight(control.Size, " "))

                            Case "System.DateTime", "DateTime", "Date"
                                fileText.Append(strValue.PadRight(8, ""))

                            Case "System.Numeric", "Numeric", "Integer", "Int64", "Decimal", "System.Integer", "System.Int64", "System.Decimal"
                                Dim tmpVal As String = strValue.Trim

                                Dim tmpsize As String = GetSubSize(control.Size, control.DataType.ToString)

                                If tmpVal.Trim.StartsWith("-") Then
                                    tmpVal = tmpVal.Replace("-", "")
                                    tmpVal =
                                        tmpVal.PadLeft(tmpsize - 1, "0").
                                            Substring(0, tmpsize - 1)
                                    tmpVal = "-" & tmpVal
                                Else
                                    tmpVal =
                                        tmpVal.PadLeft(tmpsize - 1, "0").
                                            Substring(0, tmpsize - 1)
                                    tmpVal = "+" & tmpVal
                                End If


                                fileText.Append(tmpVal)
                        End Select
                        'If control.DataType.ToString = "System.DateTime" Then
                        '    fileText.Append(arrValues(cnt - 1).PadRight(8, ""))
                        'Else
                        '    fileText.Append(control.Size.ToString)
                        'End If
                    End If
                Next

                sw = New StreamWriter(sfFileName, True)
                sw.Write(fileText.ToString + vbNewLine)
                sw.Flush()
                sw.Close()

                sw = New StreamWriter(sfFileName + "debug", True)
                sw.Write(fileText.ToString + vbNewLine)
                sw.Flush()
                sw.Close()

                sw.Dispose()

            Catch ex As Exception
                ' Write the exception to the log file.
                RecordReportError(strReportLogFile, ex)

            End Try

        End Sub

        Private Function IsRangeDate(ByVal strDate As String) As Boolean

            Dim blnDate As Boolean = False

            Try
                If IsDate(GetDateFromYYYYMMDDDecimal(strDate)) Then
                    If IsValidDate(CInt(Substring(strDate, 0, 4)), CInt(Substring(strDate, 4, 2)), CInt(Substring(strDate, 6, 2))) Then
                        blnDate = True
                    End If
                End If

            Catch ex As Exception
                ' Write the exception to the log file.
                RecordReportError(strReportLogFile, ex)

            End Try

            Return blnDate

        End Function

        Private Function IsRangeNumeric(ByVal strNumber As String) As Boolean

            Dim blnNumber As Boolean = False
            Dim arrNumber() As Char

            Try
                arrNumber = strNumber.Trim.ToCharArray

                For Each valChar As Char In arrNumber
                    Select Case valChar
                        Case "0"c, "1"c, "2"c, "3"c, "4"c, "5"c, "6"c, "7"c, "8"c, "9"c
                            blnNumber = True

                        Case Else
                            blnNumber = False
                            Exit For

                    End Select
                Next

            Catch ex As Exception
                ' Write the exception to the log file.
                RecordReportError(strReportLogFile, ex)

            End Try

            Return blnNumber

        End Function

        Private Function PerformSubtotal(ByVal columnName As String, value As String) As String

            Dim strRetValue As String

            Try
                If htSubTotal.ContainsKey(columnName) Then
                    htSubTotal.Item(columnName) += CDec(value)
                    strRetValue = ASCII(htSubTotal.Item(columnName))
                Else
                    htSubTotal.Add(columnName, CDec(value))
                    strRetValue = value
                End If

            Catch ex As Exception
                ' Write the exception to the log file.
                RecordReportError(strReportLogFile, ex)

            End Try

            Return strRetValue

        End Function

        Private Function PerformOperationSummary(ByVal control As stcControl, ByRef arrValues() As String, ByVal intIndex As Integer) As String

            Dim sbValues As New StringBuilder(String.Empty)

            Dim strValue As String = String.Empty
            Dim intCount As Integer = 0

            Try
                Select Case control.SummaryType
                    Case SummaryType.AVERAGE

                    Case SummaryType.COUNT

                    Case SummaryType.MAXIMUM

                    Case SummaryType.MINIMUM

                    Case SummaryType.PERCENT

                    Case SummaryType.RATIO

                    Case SummaryType.SUBTOTAL
                        If htSubOperationSummary.ContainsKey(control.Name) Then
                            htSubOperationSummary.Item(control.Name) += CDec(arrValues(intIndex))
                        Else
                            htSubOperationSummary.Add(control.Name, CDec(arrValues(intIndex)))
                        End If

                    Case SummaryType.TOTAL

                End Select

                If arrValues(intIndex) <> htSubOperationSummary.Item(control.Name) Then
                    arrValues(intIndex) = htSubOperationSummary.Item(control.Name)
                End If

                For Each strValue In arrValues
                    sbValues.Append(strValue.Trim + "~")
                Next

                ' Remove last '~'.
                sbValues.Remove(sbValues.Length - 1, 1)

            Catch ex As Exception
                ' Write the exception to the log file.
                RecordReportError(strReportLogFile, ex)

            End Try

            Return sbValues.ToString

        End Function

        Private Function PerformSubfileSummary(ByVal control As stcControl, ByRef arrValues() As String, ByVal intIndex As Integer) As String

            Dim sbValues As New StringBuilder(String.Empty)

            Dim strValue As String = String.Empty
            Dim intCount As Integer = 0

            Try
                Select Case control.SummaryType
                    Case SummaryType.AVERAGE

                    Case SummaryType.COUNT

                    Case SummaryType.MAXIMUM

                    Case SummaryType.MINIMUM

                    Case SummaryType.PERCENT

                    Case SummaryType.RATIO

                    Case SummaryType.SUBTOTAL
                        If htSubFileSummary.ContainsKey(control.Name) Then
                            htSubFileSummary.Item(control.Name) += CDec(arrValues(intIndex))
                        Else
                            htSubFileSummary.Add(control.Name, CDec(arrValues(intIndex)))
                        End If

                    Case SummaryType.TOTAL

                End Select

                If arrValues(intIndex) <> htSubFileSummary.Item(control.Name) Then
                    arrValues(intIndex) = htSubFileSummary.Item(control.Name)
                End If

                For Each strValue In arrValues
                    sbValues.Append(strValue.Trim + "~")
                Next

                ' Remove last '~'.
                sbValues.Remove(sbValues.Length - 1, 1)

            Catch ex As Exception
                ' Write the exception to the log file.
                RecordReportError(strReportLogFile, ex)

            End Try

            Return sbValues.ToString

        End Function

        Private Function ReturnNoReportSQL(ByRef Section As ReportSection, ByVal Size As Integer) As String

            Dim strText As String = String.Empty

            Try
                If Section = ReportSection.NO_REPORT Then
                    strText = "Y"
                Else
                    If m_blnTempFile Then
                        strText = "N"
                    Else
                        strText = StringToField("N", Size)
                    End If
                End If

            Catch ex As Exception
                ' Write the exception to the log file.
                RecordReportError(strReportLogFile, ex)

            End Try

            Return strText

        End Function

        Private Function ReturnOperationAtIndex() As Integer

            Dim value As String = String.Empty
            Dim control As stcControl
            Dim intCount As Integer = 0
            Dim intControl As Integer = 0

            Dim strControlName As String = String.Empty
            Dim strOperationAt As String = String.Empty

            Try
                m_blnOperationAt = False

                For intControl = 1 To htControls.Count
                    control = CType(htControls.Item(htControlsIndex(intControl)), stcControl)

                    If Not control.SubOperationAt = Nothing Then
                        If control.SubOperationAt.Trim <> String.Empty Then
                            If control.SubOperationAt.LastIndexOf("."c) > 0 Then
                                strOperationAt = Mid$(control.SubOperationAt, control.SubOperationAt.LastIndexOf("."c) + 2)       ' Position of last . in the control name.
                            Else
                                strOperationAt = control.SubOperationAt
                            End If

                            For intCount = 1 To htControls.Count
                                control = CType(htControls.Item(htControlsIndex(intCount)), stcControl)

                                If control.Name.LastIndexOf("."c) > 0 Then
                                    strControlName = Mid$(control.Name, control.Name.LastIndexOf("."c) + 2)       ' Position of last . in the control name.
                                Else
                                    strControlName = control.Name
                                End If

                                If strControlName = strOperationAt Then
                                    m_blnOperationAt = True
                                    Exit For
                                End If
                            Next

                            Exit For
                        End If
                    End If
                Next

                If Not m_blnOperationAt Then
                    intCount = 0
                End If

            Catch ex As Exception
                ' Write the exception to the log file.
                RecordReportError(strReportLogFile, ex)

            End Try

            Return intCount

        End Function

        Private Function ReturnSubFileAtIndex() As Integer

            Dim value As String = String.Empty
            Dim control As stcControl
            Dim intCount As Integer = 0
            Dim strControlName As String = String.Empty

            Try
                For intCount = 1 To htControls.Count
                    control = CType(htControls.Item(htControlsIndex(intCount)), stcControl)

                    If control.Name.LastIndexOf("."c) > 0 Then
                        strControlName = Mid$(control.Name, control.Name.LastIndexOf("."c) + 2)       ' Position of last . in the control name.
                    Else
                        strControlName = control.Name
                    End If

                    If strControlName = SubFileAT Then
                        Exit For
                    End If
                Next

            Catch ex As Exception
                ' Write the exception to the log file.
                RecordReportError(strReportLogFile, ex)

            End Try

            Return intCount

        End Function

        Private Function SetOperationSummaryControl(ByRef strValues As String, ByVal intIndex As Integer) As String

            Dim arrValues() As String

            Try
                arrValues = strValues.Split("Ü")

                ' Initialize previous control first time called.
                If m_prevControl.Trim = String.Empty Then
                    m_prevControl = arrValues(intIndex).ToString
                    m_prevValues = strValues
                End If

                ' Update currently passed in control.
                m_currControl = arrValues(intIndex).ToString


            Catch ex As Exception
                ' Write the exception to the log file.
                RecordReportError(strReportLogFile, ex)

            Finally

            End Try

            Return strValues

        End Function

        Private Function SetSummaryControl(ByRef strValues As String, ByVal intIndex As Integer) As String

            Dim arrValues() As String

            Dim intCount As Integer = 0

            Dim control As stcControl
            Dim i As Integer = 0
            Try
                arrValues = strValues.Split("Ü")

                ' Initialize previous control first time called.
                If m_prevControl.Trim = String.Empty Then
                    m_prevControl = ""
                    For i = 1 To intIndex
                        m_prevControl = m_prevControl + arrValues(i).ToString
                    Next

                    'm_prevControl = arrValues(intIndex).ToString
                    m_prevValues = strValues
                End If

                ' Update currently passed in control.
                m_currControl = ""
                For i = 1 To intIndex
                    m_currControl = m_currControl + arrValues(i).ToString
                Next
                'm_currControl = arrValues(intIndex).ToString

                If m_currControl.Trim <> m_prevControl.Trim Then
                    htSubFileSummary.Clear()
                End If

                ' Perform summary operation on specified fields.
                For intCount = 1 To htControls.Count
                    control = CType(htControls.Item(htControlsIndex(intCount)), stcControl)

                    If control.SummaryType <> SummaryType.UNDEFINED Then
                        strValues = PerformSubfileSummary(control, arrValues, intCount - 1)
                    End If
                Next

            Catch ex As Exception
                ' Write the exception to the log file.
                RecordReportError(strReportLogFile, ex)

            Finally

            End Try

            Return strValues

        End Function

        Private Sub SortDataTable()

            Dim strTableName As String = String.Empty

            Try
                If Not m_DataTable Is Nothing Then

                    strTableName = m_DataTable.TableName
                    m_SortedDataTable = m_DataTable.Copy
                    m_DataTable.Clear()

                    Dim dtView As New DataView(m_SortedDataTable)

                    dtView.Sort = Sort

                    m_DataTable = dtView.ToTable()
                    m_DataTable.TableName = strTableName

                    If DebugReport Then
                        rptLog.WriteToLogFile(vbTab + vbTab + vbTab + vbTab + vbTab + "Records Read: " & m_DataTable.Rows.Count)

                    End If
                End If



            Catch ex As Exception
                ' Write the exception to the log file.
                RecordReportError(strReportLogFile, ex)

            End Try

        End Sub

        <SqlClientPermissionAttribute(SecurityAction.Assert)>
        Private Sub SortTable(ByVal blnTemp As Boolean)

            Dim sbCreateTableSQL As New StringBuilder(String.Empty)

            Dim strControlValues As String = String.Empty

            Dim SqlPermission As New SqlClientPermission(PermissionState.Unrestricted)

            Try
                SqlPermission.Assert()

                If blnTemp Then
                    If blnTableCreated Then
                        Try

                            ' Execute Reader for TEMPORARY table in Database.
                            ReportData = SqlHelper.ExecuteDataset(m_trnTRANS_UPDATE, CommandType.Text, GetDataSQL(ReportName, Sort, blnTemp))

                            If DebugReport Then
                                rptLog.WriteToLogFile(vbTab + vbTab + vbTab + vbTab + vbTab + "Records Read: " & ReportData.Tables(0).Rows.Count)

                            End If

                        Catch ex As Exception

                        End Try
                    Else
                        If htControls.Count >= 0 Then
                            ' Determine table def'n, then create the table.
                            strControlValues = GetControlValues(sbCreateTableSQL, True)

                            CreateTable(sbCreateTableSQL)

                            Try
                                ' Execute Reader for TEMPORARY table in Database.
                                ReportData = SqlHelper.ExecuteDataset(m_trnTRANS_UPDATE, CommandType.Text, GetDataSQL(ReportName, Sort, blnTemp))

                                If DebugReport Then
                                    rptLog.WriteToLogFile(vbTab + vbTab + vbTab + vbTab + vbTab + "Records Read: " & ReportData.Tables(0).Rows.Count)

                                End If

                            Catch ex As Exception

                            End Try
                        End If
                    End If
                Else
                    ReportData = Nothing
                End If

            Catch ex As Exception
                ' Write the exception to the log file.
                RecordReportError(strReportLogFile, ex)

            End Try

        End Sub

        Private Sub SortTempFile(ByRef dt As DataTable, ByVal strSQL As String)

            Dim dtTemp As New DataTable

            Try
                dtTemp = dt.Copy
                dt.Clear()

                Dim dtView As New DataView(dtTemp)

                strSQL = strSQL.Trim.Replace("ORDER BY ", "")
                dtView.Sort = strSQL

                dt = dtView.ToTable()

            Catch ex As Exception
                ' Write the exception to the log file.
                RecordReportError(strReportLogFile, ex)

            End Try

        End Sub

#End Region

#Region "Public"

        Public Overridable Sub AccessData()

        End Sub

        Public Sub AddControl(ByVal Section As ReportSection, ByVal Name As String, ByVal DataType As DataTypes, Optional ByVal Size As Integer = 1,
                                 Optional ByVal SummaryType As SummaryType = SummaryType.UNDEFINED, Optional ByVal SubOperationAt As String = "")

            'Optional ByVal BWZ As String = "", Optional ByVal FillCharacter As String = "", Optional ByVal FloatCharacter As String = "",
            'Optional ByVal Format As String = "", Optional ByVal Heading As String = "", Optional ByVal LeadingSign As String = "",
            'Optional ByVal TrailingSign As String = "", Optional ByVal OutputScale As String = "", Optional ByVal Picture As String = "",
            'Optional ByVal Separator As String = "", Optional ByVal Significance As String = "", Optional ByVal SummaryType As SummaryType = SummaryType.UNDEFINED,
            'Optional ByVal SubOperationAt As String = "")

            Dim control As New stcControl
            Dim sw As StreamWriter

            If SubFileName.Trim() <> "" Then
                Dim sfdFileName As String = SubFileName + ".sfd"
                sfdFileName = m_strFlatFilePath.Replace("UserID", Environment.UserName) + "\" + sfdFileName
                sw = New StreamWriter(sfdFileName, True)
            End If


            Try
                If DebugReport Then
                    rptLog.WriteToLogFile(vbTab + vbTab + vbTab + vbTab + "Start BaseRDLClass.AddControl")
                    rptLog.WriteToLogFile(vbTab + vbTab + vbTab + vbTab + "Control Name: " & Name)
                End If

                Select Case CType(Section, ReportSection)
                    Case ReportSection.NO_REPORT
                        If Not htNoReportControls.Contains(Name) Then
                            ' Mandatory properties.
                            control.Section = Section
                            control.Name = Name
                            control.DataType = DataType

                            If Size < 1 Then
                                control.Size = 1
                            Else
                                control.Size = Size
                            End If

                            ' Optional properties.
                            ' BWZ - Blank When Zero.
                            'If BWZ.Length = 0 Then
                            '    control.BWZ = BooleanTypes.NotSet
                            'Else
                            '    control.BWZ = CBool(BWZ)
                            'End If

                            'control.FillCharacter = FillCharacter
                            'control.FloatCharacter = FloatCharacter
                            'control.Format = Format()
                            'control.Heading = Heading
                            'control.LeadingSign = LeadingSign
                            'control.TrailingSign = TrailingSign

                            'If OutputScale.Length > 0 Then
                            '    control.OutputScale = CInt(OutputScale)
                            'Else
                            '    control.OutputScale = 0
                            'End If

                            'control.Picture = Picture
                            'control.Separator = Separator

                            'If Significance.Length > 0 Then
                            '    control.Significance = CInt(Significance)
                            'Else
                            '    control.Significance = 0
                            'End If

                            control.SummaryType = SummaryType
                            control.SubOperationAt = SubOperationAt

                            'control.AliasName = AliasName

                            ' Add control to collection.
                            htNoReportControls.Add(Name, control)

                            m_intNoReportCount += 1

                            ' Add to index in order to reference the controls in Order later on.
                            htNoReportControlsIndex.Add(m_intNoReportCount, Name)
                        End If

                    Case Else
                        If Not htControls.Contains(Name) Then
                            ' Mandatory properties.
                            control.Section = Section
                            control.Name = Name
                            control.DataType = DataType

                            If Size < 1 Then
                                control.Size = 1
                            Else
                                control.Size = Size
                            End If

                            ' Optional properties.
                            ' BWZ - Blank When Zero.
                            'If BWZ.Length = 0 Then
                            '    control.BWZ = BooleanTypes.NotSet
                            'Else
                            '    control.BWZ = CBool(BWZ)
                            'End If

                            'control.FillCharacter = FillCharacter
                            'control.FloatCharacter = FloatCharacter
                            'control.Format = Format()
                            'control.Heading = Heading
                            'control.LeadingSign = LeadingSign
                            'control.TrailingSign = TrailingSign

                            'If OutputScale.Length > 0 Then
                            '    control.OutputScale = CInt(OutputScale)
                            'Else
                            '    control.OutputScale = 0
                            'End If

                            'control.Picture = Picture
                            'control.Separator = Separator

                            'If Significance.Length > 0 Then
                            '    control.Significance = CInt(Significance)
                            'Else
                            '    control.Significance = 0
                            'End If

                            control.SummaryType = SummaryType
                            control.SubOperationAt = SubOperationAt
                            'control.AliasName = AliasName

                            ' Add control to collection.
                            htControls.Add(Name, control)
                            arrControls.Add(Name)

                            If SubFileName.Trim() <> "" Then
                                Select Case control.DataType.ToString()
                                    Case "Character"
                                        sw.WriteLine(control.Name.ToString().Substring(control.Name.ToString().LastIndexOf(".") + 1) + ",System.String," + control.Size.ToString())
                                    Case "Decimal", "Numeric"
                                        sw.WriteLine(control.Name.ToString().Substring(control.Name.ToString().LastIndexOf(".") + 1) + ",System.Decimal," + (control.Size + 1).ToString())
                                End Select
                            End If

                            'If the control is from the PAGE_HEADING or INITIAL_HEADING sections, add to NoReport hashtable
                            If Section = ReportSection.PAGE_HEADING Or Section = ReportSection.INITIAL_HEADING Then
                                htNoReportControls.Add(Name, control)
                                m_intNoReportCount += 1

                                ' Add to index in order to reference the controls in Order later on.
                                htNoReportControlsIndex.Add(m_intNoReportCount, Name)
                            End If

                            m_intControlCount += 1

                            ' Add to index in order to reference the controls in Order later on.
                            htControlsIndex.Add(m_intControlCount, Name)
                        End If
                End Select

                If sw Is Nothing Then
                Else
                    sw.Flush()
                    sw.Close()
                    sw.Dispose()
                End If

            Catch ex As Exception
                ' Write the exception to the log file.
                RecordReportError(strReportLogFile, ex)

                If sw Is Nothing Then
                Else
                    sw.Close()
                    sw.Dispose()
                End If

            Finally
                control = Nothing

            End Try

            If DebugReport Then
                rptLog.WriteToLogFile(vbTab + vbTab + vbTab + vbTab + "End BaseRDLClass.AddControl")
            End If
        End Sub

        Public Overridable Sub CloseFiles()

        End Sub

        Public Overridable Sub CloseReaders()

        End Sub

        Protected Friend Overridable Sub CloseTransactionObjects()
        End Sub

        <SqlClientPermissionAttribute(SecurityAction.Assert)>
        Public Sub CreateSessionDataTable()

            Dim dtColumn As DataColumn
            Dim ColumnDataType As Type = Nothing
            Dim control As stcControl = Nothing

            Dim strColumnName As String = String.Empty
            Dim intCount As Integer = 0

            Dim SqlPermission As New SqlClientPermission(PermissionState.Unrestricted)

            m_DataTable = New DataTable

            Try
                SqlPermission.Assert()

                For intCount = 1 To htControls.Count
                    ' Retreive control information.
                    control = CType(htControls.Item(htControlsIndex(intCount)), stcControl)

                    ' Determine control datatype.
                    Select Case control.DataType
                        Case DataTypes.Character, DataTypes.VarChar
                            ColumnDataType = System.Type.GetType("System.String")

                        Case DataTypes.Date, DataTypes.DateTime
                            ColumnDataType = System.Type.GetType("System.DateTime")

                        Case DataTypes.Integer, DataTypes.SignedInteger
                            ColumnDataType = System.Type.GetType("System.Integer")

                        Case DataTypes.Numeric, DataTypes.Float
                            ColumnDataType = System.Type.GetType("System.Decimal")

                    End Select

                    ' Determine the column name.
                    If control.Name.IndexOf(".") > 0 Then
                        strColumnName = control.Name.Substring(control.Name.LastIndexOf(".") + 1)
                    Else
                        strColumnName = control.Name
                    End If

                    If Not m_DataTable.Columns.Contains(strColumnName) Then
                        dtColumn = New DataColumn()

                        dtColumn.ColumnName = strColumnName
                        dtColumn.DataType = ColumnDataType

                        m_DataTable.Columns.Add(dtColumn)
                    End If
                Next

            Catch ex As Exception
                ' Write the exception to the log file.
                RecordReportError(strReportLogFile, ex)

            End Try

        End Sub

        <SqlClientPermissionAttribute(SecurityAction.Assert)>
        Public Function CreateTableSQL(ByVal sbCreateTableSQL As StringBuilder, ByVal blnTempTable As Boolean) As String

            Dim sbSQL As StringBuilder = New StringBuilder(String.Empty)
            Dim control As stcControl = Nothing
            Dim intCount As Integer = 0

            Dim SqlPermission As New SqlClientPermission(PermissionState.Unrestricted)

            Dim dtSchema As DataTable = Nothing
            Dim rdr As SqlDataReader

            Dim fileName As String = String.Empty
            Dim columnName As String = String.Empty
            Dim columnDataType As String = String.Empty
            Dim line As String = String.Empty
            Dim strSQL As StringBuilder = New StringBuilder(String.Empty)
            Dim columnSize As Int16 = 0

            Dim sr As StreamReader

            Try
                SqlPermission.Assert()

                'If sbCreateTableSQL.ToString.Trim.Length > 0 Then
                '    If DebugReport Then
                '        rptLog.WriteToLogFile("Create Table SQL: " + sbCreateTableSQL.ToString)
                '    End If

                '    rdr = SqlHelper.ExecuteReader(m_cnnQUERY, CommandType.Text, sbCreateTableSQL.ToString)
                '    dtSchema = rdr.GetSchemaTable()
                '    rdr.Close()
                'End If

                If blnTempTable Then

                    If AddToDatabase Then
                        sbSQL.Append("CREATE TABLE ").Append(ReportName).Append("_TEMP (")
                    Else
                        sbSQL.Append("CREATE TABLE #").Append(ReportName).Append("_TEMP (")
                    End If

                Else
                    If m_blnSubFile Then
                        If blnUseDBSchema Then
                            sbSQL.Append("CREATE TABLE ").Append(m_strDatabase).Append(".").Append(m_strSubFileName).Append(" (")
                        Else
                            sbSQL.Append("CREATE TABLE ").Append(m_strDefaultSchema).Append(cDBO).Append(m_strSubFileName).Append(" (")
                        End If
                    Else
                        sbSQL.Append("CREATE TABLE ").Append(m_strDefaultSchema).Append(cDBO).Append(ReportName).Append(" (")
                    End If
                End If

                For intCount = 1 To htControls.Count
                    control = CType(htControls.Item(htControlsIndex(intCount)), stcControl)

                    With sbSQL
                        If control.Name.IndexOf(".") > 0 Then
                            'Check the control is not already in sbSQL
                            If (sbSQL.ToString.IndexOf(" " & control.Name.Substring(control.Name.LastIndexOf(".") + 1) & " ") = -1) Or (sbSQL.ToString.IndexOf(" " & control.Name.Substring(control.Name.LastIndexOf(".") + 1) & " ") > -1 And control.AliasName <> String.Empty) Then
                                If control.AliasName <> String.Empty Then
                                    .Append(control.AliasName).Append(" ")
                                Else
                                    .Append(control.Name.Substring(control.Name.LastIndexOf(".") + 1)).Append(" ")
                                End If

                                fileName = control.Name.Substring(control.Name.IndexOf(".") + 1)
                                If fileName.IndexOf(".") >= 0 Then
                                    fileName = fileName.Substring(0, fileName.IndexOf("."))
                                End If

                                columnName = control.Name.Substring(control.Name.LastIndexOf(".") + 1)
                                columnDataType = control.DataType
                                columnSize = control.Size

                                'If control.Name.IndexOf("TEMPORARYDATA") > -1 Then
                                '    'Get schema information from text file

                                '    'Read the sfd file
                                '    sr = New StreamReader(m_strFlatFilePath.Replace("UserID", Environment.UserName) + "\" + fileName + ".sfd")

                                '    Do
                                '        line = sr.ReadLine()

                                '        If line Is Nothing Then
                                '            Exit Do
                                '        ElseIf line.IndexOf(columnName) > -1 Then
                                '            columnDataType = line.Substring(line.IndexOf(",") + 1)
                                '            columnDataType = columnDataType.Substring(0, columnDataType.IndexOf(","))
                                '            columnSize = line.Substring(line.LastIndexOf(",") + 1)

                                '            Exit Do
                                '        End If
                                '    Loop

                                '    sr.Close()
                                'Else
                                '    'Get schema information from database
                                '    strSQL.Append("SELECT DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, NUMERIC_PRECISION ")
                                '    strSQL.Append("FROM INFORMATION_SCHEMA.COLUMNS ")
                                '    strSQL.Append("WHERE TABLE_NAME = " + Common.StringToField(fileName) + " ")
                                '    strSQL.Append("AND COLUMN_NAME = " + Common.StringToField(columnName))

                                '    rdr = SqlHelper.ExecuteReader(m_cnnQUERY, CommandType.Text, strSQL.ToString)
                                '    rdr.Read()

                                '    columnDataType = rdr.GetValue(rdr.GetOrdinal("DATA_TYPE"))

                                '    If columnDataType = "varchar" Then
                                '        columnSize = rdr.GetValue(rdr.GetOrdinal("CHARACTER_MAXIMUM_LENGTH"))
                                '    Else
                                '        columnSize = rdr.GetValue(rdr.GetOrdinal("NUMERIC_PRECISION"))
                                '    End If

                                '    columnDataType = "System." + columnDataType

                                '    rdr.Close()
                                'End If

                                Select Case control.DataType.ToString
                                    Case "Character", "Varchar"
                                        .Append("VARCHAR(").Append(columnSize).Append(") COLLATE Latin1_General_BIN")

                                    Case "Date", "DateTime"
                                        .Append("DATETIME")

                                    Case "Integer", "SignedInteger"
                                        .Append("BIGINT")

                                    Case "Numeric"
                                        .Append("NUMERIC(").Append(columnSize).Append(")")

                                    Case "Float"
                                        .Append("FLOAT")
                                End Select

                                'Select Case dtSchema.Rows(intCount - 1).Item(12).ToString
                                '    Case "System.String"
                                '        .Append("VARCHAR(").Append(dtSchema.Rows(intCount - 1).Item(2)).Append(")")

                                '    Case "System.DateTime"
                                '        .Append("DATETIME")

                                '    Case "System.Integer"
                                '        .Append("INT")

                                '    Case "System.Int32", "System.Int64"
                                '        .Append("BIGINT")

                                '    Case "System.Numeric", "System.Decimal"
                                '        .Append("NUMERIC(").Append(dtSchema.Rows(intCount - 1).Item(2)).Append(")")

                                '    Case "System.Float", "System.Double"
                                '        .Append("FLOAT")
                                'End Select

                                If intCount < htControls.Count Then
                                    .Append(", ")
                                End If
                            End If
                        Else
                            If sbSQL.ToString.IndexOf(" " & control.Name & " ") = -1 Or sbSQL.ToString.IndexOf("(" & control.Name & " ") = -1 Then
                                If control.AliasName <> String.Empty Then
                                    .Append(control.AliasName).Append(" ")
                                Else
                                    .Append(control.Name).Append(" ")
                                End If

                                Select Case control.DataType
                                    Case DataTypes.Character, DataTypes.VarChar
                                        .Append("VARCHAR(").Append(control.Size).Append(") COLLATE Latin1_General_BIN")

                                    Case DataTypes.Date, DataTypes.DateTime
                                        .Append("DATETIME")

                                    Case DataTypes.Integer
                                        .Append("INT")

                                    Case DataTypes.SignedInteger
                                        .Append("BIGINT")

                                    Case DataTypes.Numeric
                                        '.Append("NUMERIC(").Append(control.Size).Append(")")
                                        .Append("NUMERIC(").Append(control.Size).Append(")")

                                    Case DataTypes.Float
                                        .Append("FLOAT")
                                End Select
                            End If

                            If intCount < htControls.Count Then
                                .Append(", ")
                            End If
                        End If
                    End With
                Next

                sbSQL.Append(")")

            Catch ex As Exception
                ' Write the exception to the log file.
                RecordReportError(strReportLogFile, ex)

            End Try

            Return sbSQL.ToString

        End Function

        Public Overridable Sub DeclareReportControls()

        End Sub

        Public Overridable Sub Dispose()

        End Sub

        <SqlClientPermissionAttribute(SecurityAction.Assert)>
        Public Function ExecuteTempFile(ByVal strTableName As String, Optional ByVal strWhere As String = "", Optional ByVal strOrder As String = "") As DataTable

            Dim dt As New DataTable
            Dim dtTemp As New DataTable
            Dim dtRows() As DataRow

            Dim intIndex As Integer = 0

            Try
                ' Retreive temp file from session.
                dt = CType(m_SessionManager.GetSession(strTableName, m_strSessionId), DataTable)

                If Not dt Is Nothing Then
                    strWhere = strWhere.Trim
                    strOrder = strOrder.Trim

                    If (strWhere <> "" Or strOrder <> "") Then
                        If strWhere <> "" And strWhere.StartsWith("WHERE ") Then
                            strWhere = strWhere.Trim.Replace("WHERE ", "")
                        End If

                        If strOrder <> "" And strOrder.StartsWith("ORDER BY ") Then
                            strOrder = strOrder.Trim.Replace("ORDER BY ", "")
                        End If

                        dtRows = dt.Select(strWhere, strOrder)

                        dtTemp = dt.Clone()

                        ' Add new rows with selected values to the datatable.
                        For intIndex = 0 To dtRows.GetUpperBound(0)
                            dtTemp.ImportRow(dtRows(intIndex))
                        Next

                        dt.Clear()

                        ' Copy the selected data back into original datatable.
                        dt = dtTemp.Copy
                        dt.TableName = strTableName
                    End If
                End If

            Catch ex As Exception
                ' Write the exception to the log file.
                RecordReportError(strReportLogFile, ex)

            End Try

            Return dt

        End Function

        <SqlClientPermissionAttribute(SecurityAction.Assert)>
        Public Function GetRangeSQL(ByVal Name As String, ByVal intDataType As DataTypes, ByVal blnWhere As Boolean) As String

            Dim sbSQL As New StringBuilder(String.Empty)

            Try
                If blnWhere Then
                    sbSQL.Append(" WHERE ")
                Else
                    sbSQL.Append(" AND ")
                End If

                If m_RangeStart.Trim <> String.Empty And m_RangeEnd.Trim <> String.Empty Then
                    Select Case intDataType
                        Case DataTypes.Character, DataTypes.VarChar
                            sbSQL.Append("(").Append(Name).Append(" >= ").Append(StringToField(m_RangeStart)).Append(" AND ")
                            sbSQL.Append(Name).Append(" <= ").Append(StringToField(m_RangeEnd)).Append(")")

                        Case DataTypes.Date, DataTypes.DateTime
                            sbSQL.Append("(").Append(AddDateFunction(Name)).Append(" >= ").Append(AddDateFunction(m_RangeStart)).Append(" AND ")
                            sbSQL.Append(AddDateFunction(Name)).Append(" <= ").Append(AddDateFunction(m_RangeEnd)).Append(")")

                        Case DataTypes.Float, DataTypes.Integer, DataTypes.Numeric, DataTypes.SignedInteger
                            sbSQL.Append("(").Append(Name).Append(" >= ").Append(m_RangeStart).Append(" AND ")
                            sbSQL.Append(Name).Append(" <= ").Append(m_RangeEnd).Append(")")

                    End Select
                ElseIf m_RangeStart.Trim <> String.Empty Then
                    Select Case intDataType
                        Case DataTypes.Character, DataTypes.VarChar
                            sbSQL.Append(Name).Append(" = ").Append(StringToField(m_RangeStart))

                        Case DataTypes.Date, DataTypes.DateTime
                            sbSQL.Append(AddDateFunction(Name)).Append(" = ").Append(AddDateFunction(m_RangeStart))

                        Case DataTypes.Float, DataTypes.Integer, DataTypes.Numeric, DataTypes.SignedInteger
                            sbSQL.Append(Name).Append(" = ").Append(m_RangeStart)

                    End Select
                Else
                    sbSQL.Remove(0, sbSQL.Length)
                End If

            Catch ex As Exception
                ' Write the exception to the log file.
                RecordReportError(strReportLogFile, ex)

            End Try

            Return sbSQL.ToString

        End Function

        Public Overridable Sub InitializeFiles()

        End Sub

        Public Overridable Sub InitializeTransactionObjects()

        End Sub

        <SqlClientPermissionAttribute(SecurityAction.Assert)>
        Public Sub ProcessData(ByVal ConnectionString As String, ByVal arrParameters() As String)

            Dim s As String
            'For Each s In arrParameters
            'rptLog.WriteToLogFile(s)
            'Next

            Dim SqlPermission As New SqlClientPermission(PermissionState.Unrestricted)

            Try
                SqlPermission.Assert()

                If DebugReport Then
                    rptLog.WriteToLogFile(vbTab + vbTab + vbTab + vbTab + "Start BaseRDLClass.ProcessData")
                    'rptLog.WriteToLogFile("ConnectionString: " + ConnectionString)
                End If

                'Set the connection string
                If ConnectionString.Contains("MultipleActiveResultSets") Then
                    strConnString = ConnectionString
                Else
                    strConnString = ConnectionString + ";MultipleActiveResultSets=True"
                End If

                Try
                    ' Open new SQL connection for Transaction.
                    m_cnnTRANS_UPDATE = New SqlConnection(strConnString)
                    m_cnnTRANS_UPDATE.Open()

                    m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction

                Catch sqlEx As SqlException
                    Throw sqlEx

                Catch ex As Exception
                    Throw ex

                End Try

                Try
                    ' Open new SQL Connection for Querying.
                    m_cnnQUERY = New SqlConnection(strConnString)
                    m_cnnQUERY.Open()

                Catch sqlEx As SqlException
                    Throw sqlEx

                Catch ex As Exception
                    Throw ex

                End Try


                TextFiles = New Hashtable()

                If arrParameters.GetUpperBound(0) > 0 Then
                    ' Retrieve session id, default schema as the first 
                    ' and second passed in parameters.
                    m_strSessionId = arrParameters(0).ToString()
                    ReportFunctions.strSessionID = m_strSessionId
                    m_strDefaultSchema = arrParameters(1).ToString()
                    m_strLanguage = arrParameters(2).ToString()
                    m_strReportedBy = arrParameters(3).ToString()
                    ReportFunctions.strUserID = m_strReportedBy
                    m_strCurrentDirectory = arrParameters(4).ToString()

                    ' Copy remaining parameters to the user selected parameter array.
                    If arrParameters.GetLength(0) > 5 Then
                        Array.Resize(astrScreenParameters, arrParameters.GetLength(0) - 5)
                        Array.Copy(arrParameters, 5, astrScreenParameters, 0, arrParameters.GetLength(0) - 5)
                    End If
                End If

                m_strDatabase = strConnString.Substring(strConnString.IndexOf("Catalog=") + 8)
                m_strDatabase = m_strDatabase.Substring(0, m_strDatabase.IndexOf(";"))

                InitializeProcess()
                SessionManager = strSessionManagerLocation

                ' Initialize Table Creation.
                blnTableCreated = False

                ' Clear Control hashtables.
                htControls.Clear()
                htControlsIndex.Clear()
                htNoReportControls.Clear()
                htNoReportControlsIndex.Clear()
                htSubFileSummary.Clear()
                htSubOperationSummary.Clear()

                ' Add NoReport control to DataSet Structure.
                AddControl(ReportSection.NO_REPORT, "NOREPORT", DataTypes.Character, 1)
                AddControl(ReportSection.REPORT, "NOREPORT", DataTypes.Character, 1)

                Dim sfdFileName As String = SubFileName + ".sfd"

                sfdFileName = m_strFlatFilePath.Replace("UserID", Environment.UserName) + "\" + sfdFileName

                If File.Exists(sfdFileName) Then
                    File.Delete(sfdFileName)
                End If

                ' Add remaining report controls.
                DeclareReportControls()

                If DebugReport Then
                    rptLog.WriteToLogFile(vbTab + vbTab + vbTab + vbTab + "Execute -   If ExecuteAccessData(ReportHasParameters)")
                End If

                ' Process Data Retrieval.
                If ExecuteAccessData(ReportHasParameters) Then
                    If DebugReport Then
                        rptLog.WriteToLogFile(vbTab + vbTab + vbTab + vbTab + "Accessing Data")
                    End If

                    'If a subfile, create the empty file.
                    If SubFile = True Then
                        If DebugReport Then
                            rptLog.WriteToLogFile(vbTab + vbTab + vbTab + vbTab + "Create empty subfile - " + SubFileName)
                        End If
                        Dim control As stcControl
                        Dim controlName As String
                        Dim sfFileName As String = SubFileName + ".sf"
                        Dim fileText As StringBuilder = New StringBuilder(String.Empty)
                        Dim sw As StreamWriter
                        Dim cnt As Integer

                        If (Not m_strFlatFilePath.EndsWith("\")) Then
                            m_strFlatFilePath = m_strFlatFilePath + "\"
                        End If

                        sfFileName = m_strFlatFilePath.Replace("UserID", Environment.UserName) + sfFileName

                        If SubFileAppend = False Then
                            If File.Exists(sfFileName) Then
                                File.Delete(sfFileName)
                            End If

                            If File.Exists(sfFileName + "debug") Then
                                File.Delete(sfFileName + "debug")
                            End If

                            If File.Exists(sfdFileName) Then
                                File.Delete(sfdFileName)
                            End If

                            For cnt = 1 To htControls.Count
                                control = CType(htControls.Item(htControlsIndex(cnt)), stcControl)

                                If control.Name <> "NOREPORT" Then
                                    If control.Name.LastIndexOf("."c) > 0 Then
                                        controlName = Mid$(control.Name, control.Name.LastIndexOf("."c) + 2)       ' Position of last . in the control name.
                                    Else
                                        controlName = control.Name
                                    End If

                                    fileText.Append(controlName)
                                    fileText.Append(",")

                                    Select Case control.DataType.ToString
                                        Case "Numeric"
                                            fileText.Append("System.Decimal")
                                        Case "Decimal"
                                            fileText.Append("System.Decimal")
                                        Case "Integer"
                                            fileText.Append("System.Integer")
                                        Case "System.DateTime"
                                            fileText.Append("System.DateTime")
                                        Case Else
                                            fileText.Append("System.String")
                                    End Select


                                    fileText.Append(",")
                                    If control.DataType.ToString = "System.DateTime" Then
                                        fileText.Append("8")
                                    ElseIf control.DataType.ToString = "Numeric" OrElse control.DataType.ToString = "Integer" OrElse control.DataType.ToString = "Decimal" Then
                                        fileText.Append(GetSubSize(control.Size.ToString, control.DataType.ToString))
                                    Else
                                        fileText.Append(control.Size.ToString)
                                    End If
                                    fileText.Append(vbNewLine)
                                End If
                            Next

                            'My.Computer.FileSystem.WriteAllText(strFileColumn, strFileText.ToString, False)
                            sw = New StreamWriter(sfdFileName, False)
                            sw.Write(fileText.ToString)
                            sw.Flush()
                            sw.Close()

                            sw = New StreamWriter(sfFileName, False)
                            sw.Write("")
                            sw.Flush()
                            sw.Close()

                            sw.Dispose()

                            If DebugReport Then
                                rptLog.WriteToLogFile(vbTab + vbTab + vbTab + vbTab + "Subfile created")
                            End If
                        End If
                    End If

                    If DebugReport Then
                        rptLog.WriteToLogFile(vbTab + vbTab + vbTab + vbTab + "Execute - AccessData")
                    End If

                    AccessData()

                    If DebugReport Then
                        rptLog.WriteToLogFile(vbTab + vbTab + vbTab + vbTab + "End execute - AccessData")
                    End If
                End If

                If m_blnSubFile OrElse m_blnTempFile Then
                    If SubFileAT.Trim <> String.Empty Then
                        WriteLastDataRow()
                    End If

                    ' Sort the data in the Session or in the PERMANENT
                    ' table in the Database.
                    If blnTableCreated Or m_RecordCount > 0 Then
                        ' Sort data within TEMPORARY table in Database.
                        If DebugReport Then
                            rptLog.WriteToLogFile(vbTab + vbTab + vbTab + vbTab + "Execute BaseRDLClass.SortData")
                        End If

                        SortData()

                        If DebugReport Then
                            rptLog.WriteToLogFile(vbTab + vbTab + vbTab + vbTab + "End execute BaseRDLClass.SortData")
                        End If

                        If m_sftSubFileType = SubFileType.Temp Or m_blnTempFile Then
                            m_DataSet = New DataSet(ReportName)
                            m_DataSet.Tables.Add(m_DataTable)
                        End If
                    Else
                            If m_sftSubFileType <> Core.Framework.Core.Framework.SubFileType.Keep Then
                            AddNoReportRecord()
                        End If
                    End If

                    If DebugReport Then
                        rptLog.WriteToLogFile(vbTab + vbTab + vbTab + vbTab + "Execute - BaseRDLClass.InsertIntoTextFile")
                    End If

                    InsertIntoTextFile()

                    If DebugReport Then
                        rptLog.WriteToLogFile(vbTab + vbTab + vbTab + vbTab + "End execute - BaseRDLClass.InsertIntoTextFile")
                    End If

                    ' Store the Session datatable into the Session by means of the 
                    ' SessionManager.
                    If m_sftSubFileType = SubFileType.Temp Then
                        m_SessionManager.SetSession(m_strSubFileName, m_DataTable, m_strSessionId)
                    End If
                Else
                    If m_blnOperationAt Then
                        If DebugReport Then
                            rptLog.WriteToLogFile(vbTab + vbTab + vbTab + vbTab + "Execute - BaseRDLClass.WriteLastData")
                        End If

                        WriteLastData()

                        If DebugReport Then
                            rptLog.WriteToLogFile(vbTab + vbTab + vbTab + vbTab + "End execute - BaseRDLClass.WriteLastData")
                        End If
                    End If

                    ' If there is no data returned then return a single record
                    ' to indicate that the NoReport should be displayed.
                    'If ReportData Is Nothing OrElse ReportData.Tables(0).Rows.Count = 0 Then
                    If blnTableCreated Or m_RecordCount > 0 Then
                        If DebugReport Then
                            rptLog.WriteToLogFile(vbTab + vbTab + vbTab + vbTab + "Execute BaseRDLClass.SortData")
                        End If

                        SortData()

                        If DebugReport Then
                            rptLog.WriteToLogFile(vbTab + vbTab + vbTab + vbTab + "End execute BaseRDLClass.SortData")
                        End If
                    Else
                        AddNoReportRecord()
                    End If
                End If

                If m_sftSubFileType = Core.Framework.Core.Framework.SubFileType.Keep Then
                    m_blnCOMMIT = True
                End If

                rptLog.WriteToStatsFile("Records Read: " & m_ReadRecordCount, Me.GetType.Name)
                rptLog.WriteToStatsFile("Records Written: " & m_RecordCount, Me.GetType.Name)

            Catch ex As SecurityException
                ' Write the exception to the log file.
                RecordReportError(strReportLogFile, ex)

            Catch ex As AccessViolationException
                ' Write the exception to the log file.
                RecordReportError(strReportLogFile, ex)

            Catch ex As Exception
                ' Write the exception to the log file.
                RecordReportError(strReportLogFile, ex)

            Finally
                CloseReaders()
                CompleteProcess()

            End Try

            If m_RecordCount = 0 AndAlso Not m_blnSubFile Then
                Throw New Exception(vbTab + vbTab + vbTab + vbTab + "Records Written: 0")
            End If

            If DebugReport Then
                rptLog.WriteToLogFile(vbTab + vbTab + vbTab + vbTab + "End BaseRDLCLass.ProcessData")
            End If

        End Sub

        Public Function GetSubSize(size As Integer, datatype As String) As Integer

            If datatype = "System.Integer" OrElse datatype = "System.Int64" Then

                Select Case size
                    Case 1
                        Return 6
                    Case 2
                        Return 6
                    Case 3
                        Return 6
                    Case 4
                        Return 6

                    Case 5
                        Return 11
                    Case 6
                        Return 11
                    Case 7
                        Return 11
                    Case 8
                        Return 11
                    Case 9
                        Return 11

                    Case 10
                        Return 16
                    Case 11
                        Return 16
                    Case 12
                        Return 16
                    Case 13
                        Return 16
                    Case 14
                        Return 16

                    Case Else
                        Return 21


                End Select

            Else
                Return size + 1

            End If



        End Function

        Public Overridable Function ReturnControlValue(ByVal strValue As String, ByVal intSize As Integer) As String

            Return String.Empty

        End Function

        Public Overridable Function SelectIf() As Boolean

            Return True

        End Function

        <SqlClientPermissionAttribute(SecurityAction.Assert)>
        Public Sub SortData()

            Dim strControlValues As String = String.Empty

            Dim SqlPermission As New SqlClientPermission(PermissionState.Unrestricted)

            Try
                SqlPermission.Assert()

                ' Determine if we are dealing with a subfile.
                If m_blnSubFile OrElse m_blnTempFile Then
                    If m_sftSubFileType = SubFileType.Temp OrElse m_blnTempFile Then
                        If DebugReport Then
                            rptLog.WriteToLogFile(vbTab + vbTab + vbTab + vbTab + vbTab + "Execute BaseRDLClass.SortDataTable")
                        End If

                        SortDataTable()

                        If DebugReport Then
                            rptLog.WriteToLogFile(vbTab + vbTab + vbTab + vbTab + vbTab + "End execute BaseRDLClass.SortDataTable")
                        End If
                    Else
                        If DebugReport Then
                            rptLog.WriteToLogFile(vbTab + vbTab + vbTab + vbTab + vbTab + "Execute BaseRDLClass.SortTable(False)")
                        End If

                        SortTable(False)

                        If DebugReport Then
                            rptLog.WriteToLogFile(vbTab + vbTab + vbTab + vbTab + vbTab + "End execute BaseRDLClass.SortTable(False)")
                        End If
                    End If
                Else
                    If DebugReport Then
                        rptLog.WriteToLogFile(vbTab + vbTab + vbTab + vbTab + vbTab + "Execute BaseRDLClass.SortTable(True)")
                    End If

                    SortTable(True)

                    If DebugReport Then
                        rptLog.WriteToLogFile(vbTab + vbTab + vbTab + vbTab + vbTab + "End execute BaseRDLClass.SortTable(True)")
                    End If
                End If

            Catch ex As Exception
                ' Write the exception to the log file.
                RecordReportError(strReportLogFile, ex)

            End Try

        End Sub

        Public Overridable Sub TRANS_UPDATE()

        End Sub

        <SqlClientPermissionAttribute(SecurityAction.Assert)>
        Public Sub WriteData()

            Dim strControlValues As String = String.Empty
            Dim sbCreateTableSQL As New StringBuilder(String.Empty)

            Dim SqlPermission As New SqlClientPermission(PermissionState.Unrestricted)

            Try
                SqlPermission.Assert()

                m_ReadRecordCount += 1

                If SelectIf() Then
                    If htControls.Count >= 0 Then
                        ' Retrieve control values to insert.
                        strControlValues = GetControlValues(sbCreateTableSQL, True)

                        If DebugReport Then
                            rptLog.WriteToLogFile("WriteData: strControlValues: " & strControlValues)
                        End If



                        'If a subfile, populate the text file, else create the temp table
                        If SubFile = True Then
                            InsertIntoDBTable(strControlValues)
                            m_RecordCount += 1
                        Else
                            ' Create table to insert values into.
                            If Not blnTableCreated Then
                                CreateTable(sbCreateTableSQL)
                                blnTableCreated = True
                            End If

                            ' Determine if we are dealing with a subfile.
                            If m_blnSubFile OrElse m_blnTempFile Then
                                ' Insert data into subfile...
                                If InsertCondition(strControlValues) Then
                                    If m_sftSubFileType = SubFileType.Temp OrElse m_blnTempFile Then
                                        ' Store subfile data into Session.
                                        InsertDataRow(strControlValues)
                                    Else
                                        ' Store subfile data into Database.
                                        InsertData(strControlValues, False)
                                    End If

                                    m_RecordCount += 1

                                End If
                            Else
                                If InsertCondition(strControlValues) Then
                                    ' Insert data into temp table in database.
                                    InsertData(strControlValues, True)

                                    m_RecordCount += 1

                                End If
                            End If
                        End If
                    End If
                End If

            Catch ex As Exception
                ' Write the exception to the log file.
                RecordReportError(strReportLogFile, ex)

            End Try

        End Sub

        <SqlClientPermissionAttribute(SecurityAction.Assert)>
        Public Sub WriteLastData()

            Dim SqlPermission As New SqlClientPermission(PermissionState.Unrestricted)

            Try
                SqlPermission.Assert()

                If m_currValues.Trim <> String.Empty Then
                    ' Store Temp data into Database.
                    InsertData(m_currValues, True)
                End If

            Catch ex As Exception
                ' Write the exception to the log file.
                RecordReportError(strReportLogFile, ex)

            End Try

        End Sub

        <SqlClientPermissionAttribute(SecurityAction.Assert)>
        Public Sub WriteLastDataRow()

            Dim SqlPermission As New SqlClientPermission(PermissionState.Unrestricted)

            Try
                SqlPermission.Assert()

                If m_currValues.Trim <> String.Empty Then
                    If m_sftSubFileType = SubFileType.Temp Then
                        ' Store subfile data into Session.
                        InsertDataRow(m_currValues)
                    Else
                        If SubFile = True Then
                            InsertIntoTextFile(m_currValues)
                            m_RecordCount += 1
                        Else
                            InsertData(m_currValues, False)
                        End If
                        ' Store subfile data into Database.

                    End If
                End If

            Catch ex As Exception
                ' Write the exception to the log file.
                RecordReportError(strReportLogFile, ex)

            End Try

        End Sub

#End Region

#End Region

    End Class

End Namespace
