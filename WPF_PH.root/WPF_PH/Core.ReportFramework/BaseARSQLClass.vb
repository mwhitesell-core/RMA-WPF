Imports Core.DataAccess
Imports Core.DataAccess.SqlServer
Imports Core.ExceptionManagement
Imports Core.Framework
Imports Core.Framework.Core.Framework

Imports System.Data.SqlClient

Imports System.Collections
Imports System.Data
Imports System.Diagnostics
Imports System.IO
Imports System.Security
Imports System.Security.Permissions
Imports System.Text
Imports System.Xml
Imports System.Web

Imports System.Collections.Specialized
Imports System.Configuration.ConfigurationSettings

Namespace Core.ReportFramework

    Public Module BaseARSQLClass

#Region " Declarations "

#Region " Variables "

        ' Report
        Public m_strReportName As String
        Private m_DataSet As DataSet
        Private m_DataTable As DataTable
        Private m_SortedDataTable As DataTable
        Private m_strSort As String

        ' INFORMIX Transaction/Connection.
        Public m_cnnQUERY As SqlConnection
        Public m_cnnTRANS As SqlConnection
        Public m_trnTRANS As SqlTransaction

        Private m_SessionManager As SessionInfo
        Private m_strSessionId As String = String.Empty

        ' Subfiles...
        Private m_blnSubFile As Boolean = False
        Private m_blnSubFileAppend As Boolean = False

        Private m_strSubFileName As String = String.Empty
        Private m_strSubFileAT As String = String.Empty

        Private m_sftSubFileType As SubFileType = Nothing

        ' Temp Files...
        Private m_blnTempFile As Boolean = False
        'Public m_blnDebug As Boolean = False

        Private htControls As Hashtable = Nothing
        Private htControlsIndex As Hashtable = Nothing
        Private htSubFileSummary As New Hashtable

        ' Miscellaneous
        Private m_intControlCount As Integer = 0
        Private m_RangeStart As String = String.Empty
        Private m_RangeEnd As String = String.Empty

        Private m_prevControl As String = String.Empty
        Private m_currControl As String = String.Empty
        Private m_prevValues As String = String.Empty
        Private m_currValues As String = String.Empty

        Private colDictionaryKeys As HybridDictionary  ' Used to hold 5 Characters Language-Culture which is the key and corresponding Index that can be used in an Array
        Private dicCoreDictionary() As CoreDictionary  ' Used to store the Core Dictionaries

        Public m_objSession As SessionState.HttpSessionState

#End Region

#Region " Enums "

        Public Enum DataType As Integer
            VarChar = 0
            Character = 1
            [Integer] = 2
            SignedInteger = 3
            [Date] = 4
            DateTime = 5
            Numeric = 6
            Float = 7
        End Enum

        Public Enum SummaryType
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

        Public Structure stcControl
            Dim Name As String
            Dim DataType As DataType
            Dim Size As Integer
            Dim SummaryType As SummaryType
        End Structure

#End Region

#Region " Properties "

        ''' --- Session ------------------------------------------------------------
        ''' <exclude />
        ''' 
        ''' <summary>
        ''' 	Summary of Session.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        Public ReadOnly Property Session() As SessionState.HttpSessionState
            Get
                Return m_objSession
            End Get
        End Property

        Property Sort() As String
            Get
                Return m_strSort
            End Get
            Set(ByVal value As String)
                m_strSort = value
            End Set
        End Property

        Property SubFile() As Boolean
            Get
                Return m_blnSubFile
            End Get
            Set(ByVal value As Boolean)
                m_blnSubFile = value
            End Set
        End Property

        Property SubFile_Append() As Boolean
            Get
                Return m_blnSubFileAppend
            End Get
            Set(ByVal value As Boolean)
                m_blnSubFileAppend = value
            End Set
        End Property

        Property SubFile_AT() As String
            Get
                Return m_strSubFileAT
            End Get
            Set(ByVal value As String)
                m_strSubFileAT = value
            End Set
        End Property

        Property SubFile_Name() As String
            Get
                Return m_strSubFileName
            End Get
            Set(ByVal value As String)
                m_strSubFileName = value
            End Set
        End Property

        Property SubFile_Type() As SubFileType
            Get
                Return m_sftSubFileType
            End Get
            Set(ByVal value As SubFileType)
                m_sftSubFileType = value
            End Set
        End Property

        Property TempFile() As Boolean
            Get
                Return m_blnTempFile
            End Get
            Set(ByVal value As Boolean)
                m_blnTempFile = value
            End Set
        End Property

        Private Property DebugReport(Optional ByVal strLogPath As String = cDEFAULT_LOG_PATH + cDEFAULT_LOG) As Boolean
            Get
                Return m_blnDebug
            End Get
            Set(ByVal value As Boolean)
                m_blnDebug = value

                If value Then
                    If strReportLogPath.Trim = "" Then
                        rptLog = New LogManager(strLogPath, 2, ReportName)      ' cREPORT_LOG
                    Else
                        rptLog = New LogManager(strReportLogPath, 2, ReportName)
                    End If

                    rptLog.OpenLogFile()
                End If
            End Set
        End Property

        Public Property ReportName() As String
            Get
                Return m_strReportName
            End Get
            Set(ByVal value As String)
                m_strReportName = value
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

        Public WriteOnly Property SessionManager() As String
            Set(ByVal value As String)
                ' Create new session manager.
                m_SessionManager = New SessionInfo(TriState.UseDefault, value)
            End Set
        End Property

#End Region

#End Region

#Region " Methods "

#Region " Public "

        Public Sub InitializeReport(ByVal strReportname As String)

            Try

                m_objSession = HttpContext.Current.Session

                ' Initialize Report Settings.
                InitializeFromReportConfig(m_objSession("ReportConfig") & "\Report.config","")

                ReportName = strReportname.Substring(strReportname.IndexOf(".") + 1)

                'DebugReport() = blnDebug

                SessionManager = strSessionManagerLocation

                ' Initialize Table Creation.
                blnTableCreated = False

                If DebugReport Then
                    rptLog.WriteToLogFile("Initialize Report...")
                End If

                'If DebugReport Then
                '    rptLog.WriteToLogFile("Connection String..." + strConnString)
                'End If

                Try
                    m_cnnTRANS = New SqlConnection(strConnString)
                    m_cnnTRANS.Open()

                    m_trnTRANS = m_cnnTRANS.BeginTransaction

                    m_cnnQUERY = New SqlConnection(strConnString)
                    m_cnnQUERY.Open()

                Catch SqlEx As SqlException
                    If DebugReport Then
                        rptLog.WriteToLogFile("ERROR: SqlException..." + SqlEx.Errors.ToString)
                    End If

                    Throw SqlEx

                Catch ex As Exception
                    If DebugReport Then
                        rptLog.WriteToLogFile("ERROR: Create New Transaction..." + ex.Message)
                    End If

                    Throw ex

                End Try

                If DebugReport Then
                    rptLog.WriteToLogFile(vbTab + "New Informix Connection Created.")
                End If

                ' Create Control hashtables.
                htControls = New Hashtable
                htControlsIndex = New Hashtable
                m_intControlCount = 0

            Catch ex As Exception
                ' Write the exception to the log file.
                RecordReportError(strReportLogPath, ex)

            End Try

        End Sub

        Public Sub CloseReport()

            Try
                If DebugReport Then
                    rptLog.WriteToLogFile("Close Report...")
                End If

                Try
                    m_trnTRANS = Nothing

                    If m_cnnTRANS.State <> ConnectionState.Closed Then
                        m_cnnTRANS.Close()
                    End If

                    m_cnnTRANS.Dispose()

                    If m_cnnTRANS.State <> ConnectionState.Closed Then
                        m_cnnTRANS.Close()
                    End If

                    m_cnnTRANS.Dispose()

                Catch ex As Exception
                    If DebugReport Then
                        rptLog.WriteToLogFile("ERROR: Closing Connections..." + ex.Message)
                    End If

                    Throw ex

                End Try

                ' Clear Control hashtables.
                htControls = Nothing
                htControlsIndex = Nothing

            Catch ex As Exception
                ' Write the exception to the log file.
                RecordReportError(strReportLogPath, ex)

            End Try

        End Sub

        Public Sub CompleteData()

            Try
                If m_blnSubFile OrElse m_blnTempFile Then
                    If SubFile_AT.Trim <> String.Empty Then
                        WriteLastDataRow()
                    End If

                    ' Sort the data in the Session or in the PERMANENT
                    ' table in the Database.
                    ' Sort data within TEMPORARY table in Database.
                    SortData()

                    m_DataSet = New DataSet(ReportName)
                    m_DataSet.Tables.Add(m_DataTable)

                    ' Store the Session datatable into the Session by means of the 
                    ' SessionManager.
                    If m_sftSubFileType = SubFileType.Temp Then
                        m_SessionManager.SetSession(m_strSubFileName, m_DataTable, m_strSessionId)
                    End If
                Else
                    ' If there is no data returned then return a single record
                    ' to indicate that the NoReport should be displayed.
                    'If ReportData Is Nothing OrElse ReportData.Tables(0).Rows.Count = 0 Then
                    ' Sort data within TEMPORARY table in Database.
                    SortData()
                End If

                If DebugReport Then
                    rptLog.WriteToLogFile("Completed Processing Data.")
                End If

            Catch ex As Exception
                ' Write the exception to the log file.
                RecordReportError(strReportLogPath, ex)

            Finally
                If DebugReport Then
                    rptLog.CloseLogFile()
                End If

            End Try

        End Sub

        Private Sub WriteLastDataRow()

            Dim strControlValues As String = String.Empty

            Try
                If m_currValues.Trim <> String.Empty Then
                    If m_sftSubFileType = SubFileType.Temp Then
                        ' Store subfile data into Session.
                        InsertDataRow(m_currValues)
                    Else
                        ' Store subfile data into Database.
                        InsertData(m_currValues, False)
                    End If
                End If

            Catch ex As Exception
                ' Write the exception to the log file.
                RecordReportError(strReportLogPath, ex)

            End Try

        End Sub

        Public Sub AddReportControl(ByVal Name As String, ByVal DataType As DataType, Optional ByVal Size As Integer = 1)

            Dim control As stcControl

            Try
                If Not htControls.Contains(Name) Then
                    ' Mandatory properties.
                    control.Name = Name
                    control.DataType = DataType

                    If Size < 1 Then
                        control.Size = 1
                    Else
                        control.Size = Size
                    End If

                    ' Add control to collection.
                    htControls.Add(Name, control)

                    m_intControlCount += 1

                    ' Add to index in order to reference the controls in Order later on.
                    htControlsIndex.Add(m_intControlCount, Name)
                End If

            Catch ex As Exception


            Finally
                control = Nothing

            End Try

        End Sub

        Public Sub CreateSessionDataTable()

            Dim dtColumn As DataColumn
            Dim ColumnDataType As Type = Nothing
            Dim control As stcControl = Nothing

            Dim strColumnName As String = String.Empty
            Dim intCount As Integer = 0

            m_DataTable = New DataTable

            Try
                For intCount = 1 To htControls.Count
                    ' Retreive control information.
                    control = CType(htControls.Item(htControlsIndex(intCount)), stcControl)

                    ' Determine control datatype.
                    Select Case control.DataType
                        Case DataType.Character, DataType.VarChar
                            ColumnDataType = System.Type.GetType("System.String")

                        Case DataType.Date, DataType.DateTime
                            ColumnDataType = System.Type.GetType("System.DateTime")

                        Case DataType.Integer, DataType.SignedInteger
                            ColumnDataType = System.Type.GetType("System.Integer")

                        Case DataType.Numeric, DataType.Float
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
                RecordReportError(strReportLogPath, ex)

            End Try

        End Sub

        Public Sub InsertData(ByVal strValues As String)

            If m_blnSubFile OrElse m_blnTempFile Then
                ' Insert data into subfile...
                If InsertCondition(strValues) Then
                    If m_sftSubFileType = SubFileType.Temp OrElse m_blnTempFile Then
                        ' Store subfile data into Session.
                        InsertDataRow(strValues)
                    Else
                        ' Store subfile data into Database.
                        InsertData(strValues, False)
                    End If
                End If
            Else
                ' Insert data into temp table in database.
                InsertData(strValues, True)
            End If

        End Sub

        Public Function GetDataTable() As DataTable


            Dim rtdattable As DataTable
            Try
                'rtdattable = Session(strSubfileName.Substring(strSubfileName.LastIndexOf("\") + 1))
                'Session.Remove(strSubfileName.Substring(strSubfileName.LastIndexOf("\") + 1))
                rtdattable = Session("hsSubfile").Item(strSubfileName.Substring(strSubfileName.LastIndexOf("\") + 1))
                Session("hsSubfile").Remove(strSubfileName.Substring(strSubfileName.LastIndexOf("\") + 1))


                If IsNothing(rtdattable) Then
                    Return New DataTable
                End If
                Return rtdattable
            Catch ex As Exception
                Return New DataTable
            Finally
                If Not IsNothing(rtdattable) Then
                    rtdattable.Dispose()
                End If
            End Try

            'Return GetDataBaseDataTable()

        End Function


        Public Function GetDataBaseDataTable() As DataTable

            Dim sbSQL As New StringBuilder("")
            Dim rtdattable As DataTable
            sbSQL.Append(" SELECT * FROM ").Append(strSubfileName.Substring(strSubfileName.LastIndexOf("\") + 1)).Append("_").Append(Session.SessionID).Append(" ")
            Try
                rtdattable = SqlHelper.ExecuteDataTable(m_trnTRANS, CommandType.Text, sbSQL.ToString)
                Return rtdattable
            Catch ex As Exception
                Return New DataTable
            Finally
                If Not IsNothing(rtdattable) Then
                    rtdattable.Dispose()
                End If
            End Try

        End Function

        Public Function GetTextTable() As DataTable

            Dim strFilePath As String = ""
            Dim strFileColumn As String = ""

            Dim sr As StreamReader
            Dim dt As New DataTable
            Dim dtTemp As New DataTable
            Dim strText As String = String.Empty
            Dim arrStructure() As String
            Dim intPlaceholder As Integer = 0
            Dim intLinelength As Integer = 0
            Dim hsLength As New Hashtable
            Dim strTextName As String = String.Empty
            Dim strName As String = String.Empty

            Dim dc As DataColumn
            Dim rw As DataRow

            Try

                strTextName = strSubfileName.Replace("JS", "SD")
                strFileColumn = strSubfileName & "_TableStructure.txt"


                sr = New StreamReader(strFileColumn)



                strText = sr.ReadLine

                Do While Not IsNothing(strText)
                    arrStructure = strText.Split(",")

                    dc = New DataColumn()
                    dc.ColumnName = arrStructure(0)

                    dc.DataType = System.Type.GetType(arrStructure(1))
                    hsLength.Add(arrStructure(0), arrStructure(2))

                    dt.Columns.Add(dc)

                    intLinelength = intLinelength + VAL(arrStructure(2))

                    strText = sr.ReadLine
                Loop

                sr.Close()

                If File.Exists(strTextName) Then
                    sr = New StreamReader(strTextName)

                    strText = sr.ReadLine

                    Do While Not IsNothing(strText)

                        strText = strText.PadRight(intLinelength)

                        rw = dt.NewRow
                        intPlaceholder = 0

                        For i As Integer = 0 To dt.Columns.Count - 1

                            If dt.Columns(i).DataType.ToString = "System.Decimal" Then
                                rw.Item(dt.Columns(i).ColumnName) = VAL(strText.Substring(intPlaceholder, hsLength(dt.Columns(i).ColumnName)))
                            Else
                                rw.Item(dt.Columns(i).ColumnName) = strText.Substring(intPlaceholder, hsLength(dt.Columns(i).ColumnName))
                            End If
                            intPlaceholder = intPlaceholder + hsLength(dt.Columns(i).ColumnName)

                        Next

                        dt.Rows.Add(rw)

                        strText = sr.ReadLine

                    Loop

                    sr.Close()
                    sr.Dispose()
                    sr = Nothing

                End If

                Return dt

            Catch ex As Exception
                Return dt
            End Try

        End Function


        Public Function AccessFlatFile(ByVal strSubFileName As String, ByRef rdr As Reader, Optional ByVal strWhere As String = "", Optional ByVal strOrder As String = "") As DataTable

            Dim dt As New DataTable
            Dim dtTemp As New DataTable

            Dim dtRows() As DataRow
            Dim dc As DataColumn
            Dim rw As DataRow

            Dim strFile As String = SessionInfo.GetSystemVal("FlatFilePath", "0001", m_strSessionId)

            If strFile.EndsWith("\") Then
                strFile = strFile & strSubFileName.Replace("JS", "SD")
            Else
                strFile = strFile & "\" & strSubFileName.Replace("JS", "SD")
            End If

            If strFile.Contains("SD492009") Then
                dc = New DataColumn()
                dc.ColumnName = "INSTRUMENT"
                dc.DataType = System.Type.GetType("System.String")
                dt.Columns.Add(dc)

                dc = New DataColumn()
                dc.ColumnName = "RECDATE"
                dc.DataType = System.Type.GetType("System.Decimal")
                dt.Columns.Add(dc)

                dc = New DataColumn()
                dc.ColumnName = "DOCTYPE"
                dc.DataType = System.Type.GetType("System.String")
                dt.Columns.Add(dc)

                dc = New DataColumn()
                dc.ColumnName = "IRSAMT"
                dc.DataType = System.Type.GetType("System.Decimal")
                dt.Columns.Add(dc)

                dc = New DataColumn()
                dc.ColumnName = "IRSCODE"
                dc.DataType = System.Type.GetType("System.String")
                dt.Columns.Add(dc)
            ElseIf strFile.Contains("SD492010") Then
                dc = New DataColumn()
                dc.ColumnName = "INSTRUMENT"
                dc.DataType = System.Type.GetType("System.String")
                dt.Columns.Add(dc)

                dc = New DataColumn()
                dc.ColumnName = "DOCTYPE"
                dc.DataType = System.Type.GetType("System.String")
                dt.Columns.Add(dc)

                dc = New DataColumn()
                dc.ColumnName = "GINAME"
                dc.DataType = System.Type.GetType("System.String")
                dt.Columns.Add(dc)

                dc = New DataColumn()
                dc.ColumnName = "GINAMEEXT"
                dc.DataType = System.Type.GetType("System.String")
                dt.Columns.Add(dc)

                dc = New DataColumn()
                dc.ColumnName = "GINAMETYPE"
                dc.DataType = System.Type.GetType("System.String")
                dt.Columns.Add(dc)

                dc = New DataColumn()
                dc.ColumnName = "RECDATE"
                dc.DataType = System.Type.GetType("System.Decimal")
                dt.Columns.Add(dc)
            End If

            Dim sr As New StreamReader(strFile)
            Dim strText As String = String.Empty

            strText = sr.ReadLine

            Do While Not IsNothing(strText)

                If strFile.Contains("SD492009") Then
                    strText = strText.PadRight(34, " ")
                ElseIf strFile.Contains("SD492010") Then
                    strText = strText.PadRight(98, " ")
                End If

                rdr.m_blnAccessOK = True

                If dt.Columns.Count > 0 Then
                    rw = dt.NewRow

                    If strFile.Contains("SD492009") Then
                        rw.Item("INSTRUMENT") = strText.Substring(0, 12)
                        rw.Item("RECDATE") = VAL(strText.Substring(12, 8))
                        rw.Item("DOCTYPE") = strText.Substring(20, 2)
                        rw.Item("IRSAMT") = VAL(strText.Substring(22, 10))
                        rw.Item("IRSCODE") = strText.Substring(32, 2)
                    ElseIf strFile.Contains("SD492010") Then
                        rw.Item("INSTRUMENT") = strText.Substring(0, 12)
                        rw.Item("DOCTYPE") = strText.Substring(12, 2)
                        rw.Item("GINAME") = strText.Substring(14, 70)
                        rw.Item("GINAMEEXT") = strText.Substring(84, 4)
                        rw.Item("GINAMETYPE") = strText.Substring(88, 2)
                        rw.Item("RECDATE") = VAL(strText.Substring(90, 8))
                    End If

                    dt.Rows.Add(rw)

                    strText = sr.ReadLine
                Else
                    Exit Do
                End If
            Loop

            Dim intIndex As Integer = 0


            If Not dt Is Nothing And dt.Columns.Count > 0 Then
                If (strWhere.Trim <> "" Or strOrder <> "") Then
                    If strWhere.Trim <> "" Then
                        strWhere = strWhere.Trim.Replace("WHERE ", "")
                    End If

                    If strOrder.Trim <> "" Then
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
                    dt.TableName = strSubFileName
                End If
            End If

            Return dt

        End Function

        Public Function AccessSubFile(ByVal strSubFileName As String, Optional ByVal strWhere As String = "", Optional ByVal strOrder As String = "") As DataTable

            Dim dt As New DataTable
            Dim dtTemp As New DataTable

            Dim dtRows() As DataRow

            Dim intIndex As Integer = 0

            ' Retreive temp file from session.
            dt = CType(m_SessionManager.GetSession(strSubFileName, m_strSessionId), DataTable)

            If m_blnDebug Then
                rptLog.WriteToLogFile(vbTab + "SessionID: " + m_strSessionId)
                ReadSubFile(dt)
            End If

            If Not dt Is Nothing Then
                If (strWhere.Trim <> "" Or strOrder <> "") Then
                    If strWhere.Trim <> "" Then
                        strWhere = strWhere.Trim.Replace("WHERE ", "")
                    End If

                    If strOrder.Trim <> "" Then
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
                    dt.TableName = strSubFileName
                End If
            End If

            Return dt

        End Function

        Public Function AccessTempFile(ByVal strTableName As String, Optional ByVal strWhere As String = "", Optional ByVal strOrder As String = "") As DataTable

            Dim dt As New DataTable
            Dim dtTemp As New DataTable

            Dim dtRows() As DataRow

            Dim intIndex As Integer = 0

            ' Retreive temp file from session.
            dt = CType(m_SessionManager.GetSession(strTableName, m_strSessionId), DataTable)

            If m_blnDebug Then
                rptLog.WriteToLogFile(vbTab + "SessionID: " + m_strSessionId)
                ReadTempFile(dt)
            End If

            If Not dt Is Nothing Then
                If (strWhere.Trim <> "" Or strOrder <> "") Then
                    If strWhere.Trim <> "" Then
                        strWhere = strWhere.Trim.Replace("WHERE ", "")
                    End If

                    If strOrder.Trim <> "" Then
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

            Return dt

        End Function

        Public Function GetRangeSQL(ByVal Name As String, ByVal intDataType As DataTypes, ByVal blnWhere As Boolean) As String

            Dim sbSQL As New StringBuilder(String.Empty)

            If blnWhere Then
                sbSQL.Append(" WHERE ")
            Else
                sbSQL.Append(" AND ")
            End If

            If m_RangeStart.Trim <> String.Empty And m_RangeEnd.Trim <> String.Empty Then
                Select Case intDataType
                    Case DataTypes.Character, DataType.VarChar
                        sbSQL.Append("(").Append(Name).Append(" >= ").Append(StringToField(m_RangeStart)).Append(" AND ")
                        sbSQL.Append(Name).Append(" <= ").Append(StringToField(m_RangeEnd)).Append(")")

                    Case DataTypes.Date, DataType.DateTime
                        sbSQL.Append("(").Append(AddDateFunction(Name)).Append(" >= ").Append(AddDateFunction(m_RangeStart)).Append(" AND ")
                        sbSQL.Append(AddDateFunction(Name)).Append(" <= ").Append(AddDateFunction(m_RangeEnd)).Append(")")

                    Case DataType.Float, DataType.Integer, DataTypes.Numeric, DataType.SignedInteger
                        sbSQL.Append("(").Append(Name).Append(" >= ").Append(m_RangeStart).Append(" AND ")
                        sbSQL.Append(Name).Append(" <= ").Append(m_RangeEnd).Append(")")

                End Select
            ElseIf m_RangeStart.Trim <> String.Empty Then
                Select Case intDataType
                    Case DataType.Character, DataType.VarChar
                        sbSQL.Append(Name).Append(" = ").Append(StringToField(m_RangeStart))

                    Case DataType.Date, DataType.DateTime
                        sbSQL.Append(AddDateFunction(Name)).Append(" = ").Append(AddDateFunction(m_RangeStart))

                    Case DataType.Float, DataType.Integer, DataType.Numeric, DataType.SignedInteger
                        sbSQL.Append(Name).Append(" = ").Append(m_RangeStart)

                End Select
            Else
                sbSQL.Remove(0, sbSQL.Length)
            End If

            Return sbSQL.ToString

        End Function

        Public Sub AssignReportParameter(ByVal strKey As String, ByVal strValue As String)

            Dim intCount As Integer = 1

            Try

                Select Case strKey.ToUpper
                    Case "DATABASETYPE"
                        strDatabaseType = strValue

                    Case "CONNSTRING"
                        strConnString = strValue

                    Case "SCREENPARAMETERS"
                        astrScreenParameters = strValue.Split(",")

                    Case "SESSIONID"
                        m_strSessionId = strValue

                    Case "REPORTFORMAT"
                        strReportFormat = strValue

                    Case "REPORTFILENAME"
                        strReportFileName = strValue

                    Case "REPORTLANGUAGE"
                        strLanguage = strValue

                    Case "REPORTRUNBY"
                        strUserID = strValue

                    Case "SUBFILENAME"
                        strSubfileName = strValue

                End Select

            Catch ex As Exception
                RecordReportError(GetLogFilePath(""), ex)

            End Try

        End Sub

        Public Sub AssignParameters(ByVal strParameters As String)

            Dim arrParams() As String
            Dim charSeparators() As Char = {"~"c}
            Dim intCount As Integer = 0

            arrParams = strParameters.Split(charSeparators)

            Do While intCount < arrParams.Length
                Select Case intCount
                    Case 0
                        astrScreenParameters = arrParams(intCount).Split(charSeparators)

                    Case 1
                        strConnString = arrParams(intCount).ToString
                End Select

                intCount += 1
            Loop

        End Sub

        Public Function Use(ByVal sbfName As String, ByVal strVariable As String) As String

            Dim strValue As String = String.Empty
            Dim dt As New DataTable

            Try
                ' Retreive temp file from session.
                dt = CType(m_SessionManager.GetSession(sbfName, m_strSessionId), DataTable)

                If m_blnDebug Then
                    rptLog.WriteToLogFile(vbTab + "SessionID: " + m_strSessionId)
                    ReadTempFile(dt)
                End If

                If Not dt Is Nothing Then
                    For i As Integer = 0 To dt.Rows.Count - 1
                        For j As Integer = 0 To dt.Columns.Count - 1
                            If dt.Columns.Item(j).ColumnName = strVariable Then
                                strValue = dt.Rows(i).Item(j)
                                Exit For
                            End If
                        Next
                    Next
                End If

            Catch ex As Exception

            Finally
                If Not dt Is Nothing Then
                    dt.Dispose()
                    dt = Nothing
                End If

            End Try

            Return strValue

        End Function

#End Region

#Region " Private "

        Public Sub GetDictionaryInfo(ByVal ItemName As String, ByRef ItemSize As Integer)

            If ItemName.Length > 0 Then
                ' Get the missing dictionary values.
                Dim objDictionaryHashTable As Hashtable

                objDictionaryHashTable = GetDictionaryHashTable(ItemName)

                If Not objDictionaryHashTable Is Nothing Then
                    ItemSize = CStr(objDictionaryHashTable.Item(CInt(Framework.Core.Framework.FieldAttributes.ItemSize)))
                End If
            End If

        End Sub

        Public Sub GetDictionaryInfo(ByVal ItemName As String, ByRef Picture As String)

            If ItemName.Length > 0 Then
                ' Get the missing dictionary values.
                Dim bwz As Boolean = False
                Dim trailingSign As String = String.Empty
                Dim leadingSign As String = String.Empty
                Dim significance As Integer = 0
                Dim outputScale As Integer = 0
                Dim fillCharacter As String = String.Empty
                Dim floatCharacter As String = String.Empty
                Dim itemSize As Integer = 0
                Dim strItemDataType As String = String.Empty
                GetDictionaryInfo(ItemName, bwz, trailingSign, leadingSign, Picture, significance, outputScale, fillCharacter, floatCharacter, itemSize, strItemDataType)
            End If

        End Sub

        Public Sub GetDictionaryInfo(ByVal ItemName As String, ByRef BWZ As Boolean, ByRef TrailingSign As String, _
                                    ByRef LeadingSign As String, ByRef Picture As String, ByRef Significance As Integer, _
                                    ByRef OutputScale As Integer, ByRef FillCharacter As String, ByRef FloatCharacter As String, _
                                    ByRef ItemSize As Integer, ByRef ItemDataType As String)

            If ItemName.Length > 0 Then
                Dim objDictionaryHashTable As Hashtable

                objDictionaryHashTable = GetDictionaryHashTable(ItemName)

                If Not objDictionaryHashTable Is Nothing Then
                    With objDictionaryHashTable
                        If BWZ = False Then
                            If CBool(.Item(CInt(Framework.Core.Framework.FieldAttributes.BwzFlag))) Then
                                BWZ = True
                            Else
                                BWZ = False
                            End If
                        End If
                        If LeadingSign.Length = 0 Then
                            LeadingSign = CStr(.Item(CInt(Framework.Core.Framework.FieldAttributes.LeadingSign)))
                        End If
                        If TrailingSign.Length = 0 Then
                            TrailingSign = CStr(.Item(CInt(Framework.Core.Framework.FieldAttributes.TrailingSign)))
                        End If
                        If Picture.Length = 0 Then
                            Picture = .Item(CInt(FieldAttributes.Picture))
                        End If
                        If Significance = 0 Then
                            Significance = .Item(CInt(Framework.Core.Framework.FieldAttributes.Significance))
                        End If
                        If OutputScale = 0 Then
                            OutputScale = .Item(CInt(Framework.Core.Framework.FieldAttributes.OutputScale))
                        End If
                        If FillCharacter.Length = 0 Then
                            FillCharacter = CStr(.Item(CInt(Framework.Core.Framework.FieldAttributes.Fill)))
                        End If
                        If FloatCharacter.Length = 0 Then
                            FloatCharacter = CStr(.Item(CInt(Framework.Core.Framework.FieldAttributes.FloatValue)))
                        End If
                        If ItemSize = 0 Then
                            ItemSize = CInt(.Item(CInt(Framework.Core.Framework.FieldAttributes.ItemSize)))
                        End If
                        If ItemDataType.Length = 0 Then
                            ItemDataType = CType(.Item(CInt(Framework.Core.Framework.FieldAttributes.ItemDataTypeCode)), ItemDataTypes)
                        End If
                    End With
                End If
            End If

        End Sub

        Public Sub GetDictionaryInfo(ByVal ItemName As String, ByRef DateFormat As String, ByRef Separator As String)

            If ItemName.Length > 0 Then
                Dim objDictionaryHashTable As Hashtable

                objDictionaryHashTable = GetDictionaryHashTable(ItemName)

                If Not objDictionaryHashTable Is Nothing Then
                    With objDictionaryHashTable
                        If DateFormat.Length = 0 Then
                            DateFormat = .Item(CInt(Framework.Core.Framework.FieldAttributes.DateFormatCode))
                        End If
                        If Separator.Length = 0 Then
                            Separator = CStr(.Item(CInt(Framework.Core.Framework.FieldAttributes.Separator)))
                        End If
                    End With
                End If
            End If

        End Sub

        ''' --- GetDictionaryHashTable ---------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of GetDictionaryHashTable.
        ''' </summary>
        ''' <param name="FieldId"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        Public Function GetDictionaryHashTable(ByVal FieldId As String) As Hashtable
            Return GetDictionaryHashTable(Session("Language"), FieldId)
        End Function

        ''' --- GetDictionaryHashTable ---------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of GetDictionaryHashTable.
        ''' </summary>
        ''' <param name="Language"></param>
        ''' <param name="FieldId"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        Public Function GetDictionaryHashTable(ByVal Language As String, ByVal FieldId As String) As Hashtable
            If dicCoreDictionary Is Nothing Then
                LoadDictionaries()
            End If



            Return dicCoreDictionary(0).GetDictionaryHashTable(FieldId)

            If colDictionaryKeys.Contains(Language.ToUpper) Then
                Return dicCoreDictionary(CInt(colDictionaryKeys.Item(Language.ToUpper))).GetDictionaryHashTable(FieldId)
            Else
                Return Nothing
            End If
        End Function

        ''' --- LoadDictionaries ---------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of LoadDictionaries.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        Public Sub LoadDictionaries()

            Dim arrDictionaryLang As String = Session("DictionaryLang")
            Dim arrDictionaryPath As String = Session("DictionaryPath")
            Dim objDictionaries(0) As CoreDictionary

            objDictionaries(0) = New CoreDictionary(arrDictionaryPath)
            dicCoreDictionary = objDictionaries

        End Sub

        Private Function CreateTableSQL(ByVal sbCreateTableSQL As StringBuilder, ByVal blnTempTable As Boolean) As String

            Dim sbSQL As StringBuilder = New StringBuilder(String.Empty)
            Dim control As stcControl = Nothing
            Dim intCount As Integer = 0

            Try
                If blnTempTable Then
                    sbSQL.Append("CREATE TABLE ").Append(ReportName).Append("_TEMP (")
                Else
                    sbSQL.Append("CREATE TABLE ").Append(ReportName).Append(" (")
                End If

                For intCount = 1 To htControls.Count
                    control = CType(htControls.Item(htControlsIndex(intCount)), stcControl)

                    With sbSQL
                        .Append(control.Name).Append(" ")

                        Select Case control.DataType
                            Case DataType.Character, DataType.VarChar
                                .Append("VARCHAR(").Append(control.Size).Append(")")

                            Case DataType.Date, DataType.DateTime
                                .Append("DATE")

                            Case DataType.Integer
                                .Append("INT")

                            Case DataType.SignedInteger
                                .Append("BIGINT")

                            Case DataType.Numeric
                                .Append("NUMERIC(").Append(control.Size).Append(")")

                            Case DataType.Float
                                .Append("FLOAT")

                        End Select

                        If intCount < htControls.Count Then
                            .Append(", ")
                        End If
                    End With
                Next

                sbSQL.Append(")")

            Catch ex As Exception
                ' Write the exception to the log file.
                RecordReportError(strReportLogPath, ex)

            End Try

            Return sbSQL.ToString

        End Function

        Private Function InsertCondition(ByRef strValues As String) As Boolean

            Dim blnCondition As Boolean = False
            Dim arrValues() As String

            Dim intControlIndex As Integer = 0
            Dim intCount As Integer = 0

            Dim control As stcControl

            Try
                If m_strSubFileAT.Trim = String.Empty Then
                    blnCondition = True
                Else
                    arrValues = strValues.Split("~")

                    ' Array index is 0 based therefore we must subtract
                    ' 1 from the Control structure to get correct index.
                    intControlIndex = ReturnSubFileAtIndex() - 1

                    ' Initialize previous control first time called.
                    If m_prevControl.Trim = String.Empty Then
                        m_prevControl = arrValues(intControlIndex).ToString
                        m_prevValues = strValues
                    End If

                    ' Update currently passed in control.
                    m_currControl = arrValues(intControlIndex).ToString

                    If m_currControl.Trim <> m_prevControl.Trim Then
                        htSubFileSummary.Clear()
                    End If

                    ' Perform summary operation on specified fields.
                    'For intCount = 1 To htControls.Count
                    '    control = CType(htControls.Item(htControlsIndex(intCount)), stcControl)

                    '    If control.SummaryType <> SummaryType.UNDEFINED Then
                    '        strValues = PerformSummaryOperation(control, arrValues, intCount - 1)
                    '    End If
                    'Next

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
                End If

            Catch ex As Exception
                ' Write the exception to the log file.
                RecordReportError(strReportLogPath, ex)

            End Try

            Return blnCondition

        End Function

        Private Function PerformSummaryOperation(ByVal control As stcControl, ByRef arrValues() As String, ByVal intIndex As Integer) As String

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
                RecordReportError(strReportLogPath, ex)

            End Try

            Return sbValues.ToString

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

                    If strControlName = m_strSubFileAT Then
                        Exit For
                    End If
                Next

            Catch ex As Exception
                ' Write the exception to the log file.
                RecordReportError(strReportLogPath, ex)

            End Try

            Return intCount

        End Function

        Private Sub CreateTable(ByVal sbCreateTableSQL As StringBuilder)

            Dim sbSQL As New StringBuilder(String.Empty)

            Dim blnTableExists As Boolean = False
            Dim blnSessionTableExists As Boolean = False

            Try
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
                        ' Check to see if TEMPORARY Table exists.
                        blnTableExists = TableSetup("#" + ReportName + "_TEMP", strConnString)
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
                                ' DELETE table data, since were are not appending to it.
                                sbSQL.Append("DELETE FROM ").Append(ReportName)
                            End If
                        End If
                    Else
                        ' DELETE Temporary table.
                        sbSQL.Append("DELETE FROM #").Append(ReportName).Append("_TEMP ")
                    End If

                    Try
                        If sbSQL.ToString.Trim <> String.Empty Then
                            SqlHelper.ExecuteNonQuery(m_trnTRANS, CommandType.Text, sbSQL.ToString)
                        End If

                    Catch ex As Exception
                        Throw ex

                    End Try
                Else
                    Try
                        ' Table does not exists, therefore create it.
                        If m_blnSubFile OrElse m_blnTempFile Then
                            If m_sftSubFileType = SubFileType.Keep And Not m_blnTempFile Then
                                ' Create a PERMANANT table in database.
                                SqlHelper.ExecuteNonQuery(m_trnTRANS, CommandType.Text, CreateTableSQL(sbCreateTableSQL, False))
                            Else
                                ' Create a TEMPORARY table in Session.
                                CreateSessionDataTable()
                            End If
                        Else
                            ' Creating the TEMPORARY table in the database.
                            SqlHelper.ExecuteNonQuery(m_trnTRANS, CommandType.Text, CreateTableSQL(sbCreateTableSQL, True))
                        End If

                    Catch ex As Exception
                        Throw ex

                    End Try
                End If

            Catch ex As Exception
                ' Write the exception to the log file.
                RecordReportError(strReportLogPath, ex)

            Finally
                sbSQL = Nothing

            End Try

        End Sub

        Private Sub InsertData(ByVal strControlValues As String, ByVal blnTemp As Boolean)

            Dim sbSQL As New StringBuilder(String.Empty)

            Try

                With sbSQL
                    .Append("INSERT INTO ")

                    .Append(ReportName)

                    If blnTemp Then
                        .Append("_TEMP")
                    End If

                    If strControlValues.Contains("~") Then
                        strControlValues = strControlValues.Replace("~", ",")
                    End If

                    .Append(" VALUES( ").Append(strControlValues).Append(")")
                End With

                ' Store data into Database.
                SqlHelper.ExecuteNonQuery(m_trnTRANS, CommandType.Text, sbSQL.ToString)

            Catch ex As Exception
                ' Write the exception to the log file.
                RecordReportError(strReportLogPath, ex)

            Finally
                sbSQL = Nothing

            End Try

        End Sub

        Private Sub InsertDataRow(ByVal strControlValues As String)

            Dim dtRow As DataRow
            Dim arrValues() As String
            Dim strValue As String = String.Empty

            Try
                ' Insert control values into an array.
                If strControlValues.Contains("~") Then
                    arrValues = strControlValues.Split("~")
                Else
                    ReDim arrValues(0)
                    arrValues(0) = strControlValues
                End If

                dtRow = m_DataTable.NewRow

                ' Iterate through the columns in the new row and insert values.
                If arrValues.GetUpperBound(0) = m_DataTable.Columns.Count - 1 Then
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
                End If

                If m_blnDebug Then
                    ReadDataRow(dtRow)
                End If

                ' Add new row with populated values to the datatable.
                m_DataTable.Rows.Add(dtRow)

            Catch ex As Exception
                ' Write the exception to the log file.
                RecordReportError(strReportLogPath, ex)

            Finally
                arrValues = Nothing

            End Try

        End Sub

        Private Sub SortData()

            Dim strControlValues As String = String.Empty

            Try
                ' Determine if we are dealing with a subfile.
                If m_blnSubFile OrElse m_blnTempFile Then
                    If m_sftSubFileType = SubFileType.Temp OrElse m_blnTempFile Then
                        SortDataTable()
                    Else
                        SortTable(False)
                    End If
                Else
                    SortTable(True)
                End If

            Catch ex As Exception
                ' Write the exception to the log file.
                RecordReportError(strReportLogPath, ex)

            End Try

        End Sub

        Private Sub SortDataTable()

            Dim strTableName As String = String.Empty
            Dim arrColumns As String()
            Dim intCount As Integer = 0
            Dim strColumn As String = String.Empty

            Try
                If Not m_DataTable Is Nothing And m_DataTable.Columns.Count > 0 Then
                    strTableName = m_DataTable.TableName
                    m_SortedDataTable = m_DataTable.Copy
                    m_DataTable.Clear()

                    Dim dtView As New DataView(m_SortedDataTable)
                    arrColumns = Sort.Split(","c)

                    For intCount = 0 To arrColumns.GetUpperBound(0)
                        strColumn = arrColumns(intCount)
                        strColumn = strColumn.Replace(" ASC", "").Trim
                        strColumn = strColumn.Replace(" DESC", "").Trim

                        If Not m_DataTable.Columns.Contains(strColumn) Then
                            Exit Try
                        End If
                    Next

                    dtView.Sort = Sort

                    m_DataTable = dtView.ToTable()
                    m_DataTable.TableName = strTableName
                End If

            Catch ex As Exception
                ' Write the exception to the log file.
                RecordReportError(strReportLogPath, ex)

            End Try

        End Sub

        Private Sub SortTable(ByVal blnTemp As Boolean)

            Dim sbCreateTableSQL As New StringBuilder(String.Empty)

            Dim strControlValues As String = String.Empty

            Try
                If blnTemp Then
                    If blnTableCreated Then
                        ' Execute Reader for TEMPORARY table in Database.
                        'ReportData = SqlHelper.ExecuteReader(m_trnTRANS, CommandType.Text, GetDataSQL(ReportName, Sort, blnTemp))
                    Else
                        If htControls.Count >= 0 Then
                            ' Determine table def'n, then create the table.
                            '   strControlValues = GetControlValues(sbCreateTableSQL)
                            ' CreateTable(sbCreateTableSQL)

                            ' Execute Reader for TEMPORARY table in Database.
                            '  ReportData = SqlHelper.ExecuteReader(m_trnTRANS, CommandType.Text, GetDataSQL(ReportName, Sort, blnTemp))
                        End If
                    End If
                Else
                    ' Sorting of PERMANENT Subfile table in Database.
                    ' TODO:
                End If

            Catch ex As Exception
                ' Write the exception to the log file.
                RecordReportError(strReportLogPath, ex)

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
                RecordReportError(strReportLogPath, ex)

            End Try

        End Sub

#End Region

        'Private Function GetControlValues(ByRef sbCreateTableSQL As StringBuilder) As String

        '    Dim sbSQL As New StringBuilder(String.Empty)
        '    Dim sbTables As New StringBuilder(String.Empty)
        '    Dim strValue As String = String.Empty
        '    Dim strTableName As String = String.Empty
        '    Dim strControlValues As String = String.Empty

        '    Dim intCount As Integer = 0
        '    Dim control As stcControl

        '    Dim htTables As New Hashtable

        '    Try
        '        sbCreateTableSQL.Append("SELECT ")

        '        For intCount = 1 To htControls.Count
        '            control = CType(htControls.Item(htControlsIndex(intCount)), stcControl)

        '            strValue = ReturnControlValue(control.Name, control.Size)

        '            If control.Name.Contains(".") Then
        '                sbCreateTableSQL.Append(control.Name + " Col" + intCount.ToString)

        '                strTableName = control.Name.Substring(0, control.Name.LastIndexOf("."c))

        '                If Not htTables.Contains(strTableName) Then
        '                    htTables.Add(strTableName, strTableName + ", ")
        '                End If
        '            Else
        '                sbCreateTableSQL.Append("''" + " Col" + intCount.ToString)
        '            End If

        '            sbSQL.Append(strValue)

        '            If intCount < htControls.Count Then
        '                sbSQL.Append("~ ")
        '                sbCreateTableSQL.Append(", ")
        '            End If
        '        Next

        '        ' Determine the table names of controls.
        '        For Each de As DictionaryEntry In htTables
        '            sbTables.Append(de.Value)
        '        Next

        '        If sbTables.Length > 0 Then
        '            ' Remove the last ', ' added to the string.
        '            sbTables.Remove(Len(sbTables.ToString) - 2, 2)

        '            ' Complete the Select statement.
        '            sbCreateTableSQL.Append(" FROM ").Append(sbTables.ToString).Append(" WHERE 0 = 1")
        '        Else
        '            ' All controls are defines, therefore return empty string.
        '            sbCreateTableSQL.Remove(0, sbCreateTableSQL.Length)
        '        End If

        '        strControlValues = sbSQL.ToString

        '    Catch ex As Exception
        '        ' Write the exception to the log file.
        '        RecordReportError(strReportLogPath, ex)

        '    Finally
        '        sbTables = Nothing
        '        sbSQL = Nothing
        '        htTables = Nothing

        '    End Try

        '    Return strControlValues

        'End Function

#End Region

#Region " Debugging "

        Public Sub ReadDataRow(ByVal dtRow As DataRow)

            Dim sbValues As New StringBuilder(String.Empty)
            Dim strValue As String = String.Empty

            Try
                If DebugReport Then
                    If Not dtRow Is Nothing Then
                        With sbValues
                            For Each strValue In dtRow.ItemArray
                                .Append(vbTab)
                                .Append(strValue).Append("~")
                            Next
                        End With
                    End If

                    rptLog.WriteToLogFile(sbValues.ToString)
                End If

            Catch ex As Exception

            Finally
                sbValues = Nothing
            End Try

        End Sub

        Public Sub ReadSubFile(Optional ByVal dt As DataTable = Nothing)

            Dim intCount As Integer = 0

            Dim sbValues As New StringBuilder(String.Empty)

            Try
                If DebugReport Then
                    If dt Is Nothing Then
                        dt = CType(m_SessionManager.GetSession(m_strSubFileName, m_strSessionId), DataTable)
                    End If

                    If Not dt Is Nothing Then
                        For i As Integer = 0 To dt.Rows.Count - 1
                            With sbValues
                                .Append("Row #" + (i + 1).ToString).Append(" ")
                                For j As Integer = 0 To dt.Columns.Count - 1
                                    .Append(vbTab)
                                    .Append(dt.Columns.Item(j).ColumnName).Append(": ")
                                    .Append(dt.Rows(i).Item(j)).Append(" ")
                                    .Append(vbNewLine)
                                Next
                                .Append(vbNewLine)
                            End With

                            intCount += 1
                        Next
                    End If

                    rptLog.WriteToLogFile(sbValues.ToString)
                    rptLog.WriteToLogFile(vbNewLine)
                    rptLog.WriteToLogFile(vbTab + "Rows Received(sf): " + intCount.ToString)
                End If

            Catch ex As Exception

            Finally
                If Not dt Is Nothing Then
                    dt.Dispose()
                    dt = Nothing
                End If

                sbValues = Nothing
            End Try

        End Sub

        Public Sub ReadTempFile(ByVal dt As DataTable)

            Dim intCount As Integer = 0

            Dim sbValues As New StringBuilder(String.Empty)

            Try
                If DebugReport Then
                    If Not dt Is Nothing Then
                        With sbValues
                            .Append("Data recieved from Temp table...")
                            .Append(vbNewLine)
                            For i As Integer = 0 To dt.Rows.Count - 1
                                .Append(vbTab)
                                .Append("Row #" + (i + 1).ToString).Append(" ")
                                For j As Integer = 0 To dt.Columns.Count - 1
                                    .Append(vbTab)
                                    .Append(dt.Columns.Item(j).ColumnName).Append(": ")
                                    .Append(dt.Rows(i).Item(j)).Append(" ")
                                    .Append(vbNewLine)
                                Next
                                .Append(vbNewLine)

                                intCount += 1
                            Next
                        End With
                    End If

                    rptLog.WriteToLogFile(sbValues.ToString)
                    rptLog.WriteToLogFile(vbNewLine)
                    rptLog.WriteToLogFile(vbTab + "Rows Received (tf): " + intCount.ToString)
                End If

            Catch ex As Exception

            Finally
                sbValues = Nothing

            End Try

        End Sub

#End Region

    End Module

End Namespace


