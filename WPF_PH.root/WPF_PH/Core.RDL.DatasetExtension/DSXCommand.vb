Option Explicit On

Imports Core.LogManagement

Public Class DSXCommand
    Implements Microsoft.ReportingServices.DataProcessing.IDbCommand
    Implements Microsoft.ReportingServices.DataProcessing.IDbCommandAnalysis

    Private m_cmdText As String = String.Empty
    Private m_cmdTimeout As Integer = 30    ' IDbCommand.CommandTimeout defaults to 30 seconds.
    Private m_cmdType As Microsoft.ReportingServices.DataProcessing.CommandType
    Private m_connection As DSXConnection
    Private m_configuration As String = String.Empty
    Private m_parameters As New DSXParameterCollection
    Private m_parameterCount As Integer = 0
    Private m_project As String = String.Empty
    Private m_reportAssembly As String = String.Empty
    Public m_CurrentDirectory As String = String.Empty

    ' Default constructor.
    Public Sub New()

    End Sub 'New

    ' Command text constructor overload.
    Public Sub New(ByVal cmdText As String)

        Dim arrText() As String

        arrText = cmdText.Split("~")

        If arrText.GetUpperBound(0) = 1 Then
            m_project = arrText(0).ToString
            m_cmdText = arrText(1).ToString
        Else
            m_cmdText = arrText(0).ToString
        End If

    End Sub 'New

    ' Connection object constructor overload.
    Public Sub New(ByVal connection As DSXConnection)
        m_connection = connection
    End Sub 'New

    ' Command text and connection constructor overload.
    Public Sub New(ByVal cmdText As String, ByVal connection As DSXConnection)

        Dim arrText() As String

        arrText = cmdText.Split("~")

        If arrText.GetUpperBound(0) = 1 Then
            m_project = arrText(0).ToString
            m_cmdText = arrText(1).ToString
        Else
            m_cmdText = arrText(0).ToString
        End If

        m_connection = connection

    End Sub 'New

    ' Connection and report assembly path constructor overload.
    Public Sub New(ByVal connection As DSXConnection, ByVal strConfig As String)

        m_configuration = strConfig
        m_connection = connection

    End Sub 'New

#Region " Properties "

    Public Property CommandText() As String Implements Microsoft.ReportingServices.DataProcessing.IDbCommand.CommandText
        Get
            Return m_cmdText
        End Get
        Set(ByVal Value As String)
            m_cmdText = Value
        End Set
    End Property

    Public Property CommandTimeout() As Integer Implements Microsoft.ReportingServices.DataProcessing.IDbCommand.CommandTimeout
        Get
            Return m_cmdTimeout
        End Get
        Set(ByVal Value As Integer)
            m_cmdTimeout = Value
        End Set
    End Property

    Public Property CommandType() As Microsoft.ReportingServices.DataProcessing.CommandType Implements Microsoft.ReportingServices.DataProcessing.IDbCommand.CommandType
        Get
            Return m_cmdType
        End Get
        Set(ByVal Value As Microsoft.ReportingServices.DataProcessing.CommandType)
            m_cmdType = Value
        End Set
    End Property

    Public ReadOnly Property Parameters() As Microsoft.ReportingServices.DataProcessing.IDataParameterCollection Implements Microsoft.ReportingServices.DataProcessing.IDbCommand.Parameters
        Get
            Return m_parameters
        End Get
    End Property

    Public WriteOnly Property NewParameters() As Microsoft.ReportingServices.DataProcessing.IDataParameterCollection
        Set(ByVal Value As Microsoft.ReportingServices.DataProcessing.IDataParameterCollection)
            m_parameters = Value
        End Set
    End Property

    Public Property Transaction() As Microsoft.ReportingServices.DataProcessing.IDbTransaction Implements Microsoft.ReportingServices.DataProcessing.IDbCommand.Transaction
        Get
            Return Nothing
        End Get
        Set(ByVal Value As Microsoft.ReportingServices.DataProcessing.IDbTransaction)
            Throw New NotSupportedException
        End Set
    End Property

#End Region

    Public Sub Cancel() Implements Microsoft.ReportingServices.DataProcessing.IDbCommand.Cancel
        Throw New NotSupportedException
    End Sub

    Public Function GetParameters() As Microsoft.ReportingServices.DataProcessing.IDataParameterCollection Implements Microsoft.ReportingServices.DataProcessing.IDbCommandAnalysis.GetParameters

        Dim parameters As New DSXParameterCollection
        Dim intCount As Integer = 1

        If blnDebug Then
            rptManager.WriteToLogFile("Command - GetParameters")
        End If

        If m_parameterCount = 0 Then
            ' Add default report parameters
            parameters.Add(New DSXParameter("SESSION_ID", ""))
            parameters.Add(New DSXParameter("DEFAULT_SCHEMA", ""))
            parameters.Add(New DSXParameter("LANGUAGE", ""))
            parameters.Add(New DSXParameter("REPORTED_BY", ""))
            parameters.Add(New DSXParameter("CURRENTDIRECTORY", ""))

            m_parameterCount += 5
        End If

        Do While m_parameterCount <= 25
            parameters.Add(New DSXParameter("@PARM_" + intCount.ToString, ""))

            m_parameterCount += 1
            intCount += 1
        Loop

        Return parameters

    End Function

    Public Function CreateParameter() As Microsoft.ReportingServices.DataProcessing.IDataParameter Implements Microsoft.ReportingServices.DataProcessing.IDbCommand.CreateParameter

        Return CType(New DSXParameter(), Microsoft.ReportingServices.DataProcessing.IDataParameter)

    End Function

    Public Function ExecuteReader(ByVal behavior As Microsoft.ReportingServices.DataProcessing.CommandBehavior) As Microsoft.ReportingServices.DataProcessing.IDataReader Implements Microsoft.ReportingServices.DataProcessing.IDbCommand.ExecuteReader

        Dim strCommandText As String = String.Empty
        Dim rdr As DSXDataReader = Nothing
        Dim strReport As String = String.Empty
        Dim intCount As Integer = 1

        Try
            InitializeExtension(CommandText())

            If blnDebug Then
                rptManager = New LogManager(strLogFile, LogTypes.ErrorLog, strStatistics)
                rptManager.OpenLogFile()

                rptManager.WriteToLogFile("")

                strReport = Mid$(strReportAssembly, strReportAssembly.LastIndexOf("\") + 2).ToUpper
                strReport = strReport.Replace(".DLL", "")

                rptManager.WriteToLogFile("*** " + strCmdText + " ***")
                rptManager.WriteToLogFile("")
                rptManager.WriteToLogFile("Start Command")

                For Each parm As DSXParameter In m_parameters
                    rptManager.WriteToLogFile(vbTab + vbTab + "Parmeter" + intCount.ToString + ": " + parm.Value.ToString)
                    intCount += 1
                Next
                rptManager.WriteToLogFile("")
            End If

            ' Create the DataReader.
            rdr = New DSXDataReader(strCmdText)

            If m_parameters.Count = 0 Then
                GetParameters()
            End If

            'm_CurrentDirectory = m_parameters.Item(4).ToString()

            rdr.CreateDataSet(m_connection, m_parameters, strReportAssembly)

            If blnDebug Then
                rptManager.WriteToLogFile("End Command")
                rptManager.WriteToLogFile("")
                rptManager.WriteToLogFile("*** END REPORT ***")
                If Not rptManager Is Nothing Then
                    rptManager.CloseLogFile()
                End If
            End If

            ' Return the DataReader to RDL Server or Designer
            Return rdr

        Catch e As Exception
            If blnDebug Then
                rptManager.WriteToLogFile(vbTab + "ERROR - DSXCommand:ExecuteReader")
                rptManager.WriteToLogFile(vbTab + vbTab + e.Message.ToString)
            End If

            Throw New Exception(e.Message)

        End Try

    End Function

    Public Sub Dispose() Implements Microsoft.ReportingServices.DataProcessing.IDbCommand.Dispose

    End Sub

End Class
