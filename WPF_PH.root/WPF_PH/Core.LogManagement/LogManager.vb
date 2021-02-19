
Imports Microsoft.VisualBasic

Imports System
Imports System.Collections
Imports System.IO
Imports System.Data.OracleClient
Imports System.Diagnostics
Imports System.Text
Imports System.Web

Public Class LogManager

#Region " Variable Declarations "

    Private m_strErrorLogPath As String
    Private m_strReportLogPath As String
    Private m_strUserPath As String
    Private m_strStatisticsPath As String
    Private m_strDate As String

    Private m_intLogType As Integer

    Private m_astrParameters As Object
    Private m_astrScreenParameters() As String
    Private m_strConnString As String
    Private m_strProgramName As String
    Private m_strUserDir As String
    Private m_strReportId As String
    Private m_strReportFileName As String
    Private m_strReportDir As String
    Private m_strReportTitle As String
    Private m_strReportFormat As String
    Private m_strReportLanguage As String
    Private m_strReportRunBy As String
    Private m_dtReportRunDate As Date
    Private m_dtReportRunTime As Date
    Private m_dtReportProcessTime As Double
    Private m_blnEmailNotification As Boolean

    Public Const cDEFAULT_LOG As Integer = 0
    Public Const cERROR_LOG As Integer = 1
    Public Const cREPORT_LOG As Integer = 2

#End Region

#Region " Constructors "

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal strErrorLogPath As String)
        MyBase.New()

        m_strErrorLogPath = strErrorLogPath
        m_strUserPath = ""

    End Sub

    Public Sub New(ByVal strLogPath As String, ByVal intLogType As Integer, strStatistics As String, Optional ByVal astrParameters As Object = Nothing)
        MyBase.New()

        If Not IsNothing(astrParameters) Then
            InitializeParameters(astrParameters)
            m_astrParameters = astrParameters
        Else
            ' No parameters passed in.
            m_strUserPath = ""
        End If

        Select Case intLogType
            Case cREPORT_LOG
                m_strReportLogPath = strLogPath
            Case cERROR_LOG
                m_strErrorLogPath = strLogPath
            Case cDEFAULT_LOG
                '
        End Select

        If m_strErrorLogPath.Trim = ""
            m_strErrorLogPath = m_strReportLogPath
        End If

        m_strStatisticsPath = strStatistics

        Me.LogType = intLogType

    End Sub

    Public Sub New(ByVal strReportUserPath As String, ByVal strErrorLogPath As String,
                   ByVal intLogType As Integer, strStatistics As String, Optional ByVal astrParameters As Object = Nothing)

        MyBase.New()

        m_strUserPath = strReportUserPath
        m_strErrorLogPath = strErrorLogPath
        Me.LogType = intLogType

        m_strStatisticsPath = strStatistics

          If m_strErrorLogPath.Trim = ""
            m_strErrorLogPath = m_strReportLogPath
        End If

        InitializeParameters(astrParameters)

    End Sub

#End Region

    Private Property LogType() As Integer
        Get
            Return m_intLogType
        End Get
        Set(ByVal Value As Integer)
            m_intLogType = Value
        End Set
    End Property

    Private Sub InitializeParameters(ByRef astcParameters As Object)

        Try

            If Not IsNothing(astcParameters) Then
                With astcParameters
                    m_strConnString = .strConnString
                    m_astrScreenParameters = .astrScreenParameters
                    m_strReportId = .strReportId
                    m_strReportFileName = .strReportFileName
                    m_strReportTitle = .strReportTitle
                    m_strReportLanguage = .strReportLanguage
                    m_strReportRunBy = .strReportRunBy
                    m_dtReportRunTime = .dtReportRunTime
                    m_dtReportRunDate = .dtReportRunDate
                    m_dtReportProcessTime = .dtReportProcessTime
                End With
            End If

            m_astrParameters = astcParameters

        Catch ex As Exception
            CreateErrorCode(ex)

        End Try

    End Sub

#Region " Log File Operations "

    Public Function OpenLogFile() As Boolean

        Dim swLogFile As StreamWriter
        Dim strLogPath As String = String.Empty

        Dim blnSuccess As Boolean

        Try
            blnSuccess = False

            ' Determine which type of log we want to open.
            Select Case Me.LogType
                Case cREPORT_LOG
                    strLogPath = m_strReportLogPath
                Case cERROR_LOG
                    strLogPath = m_strErrorLogPath
                Case cDEFAULT_LOG
                    '
            End Select

            ' Determine if the log exists already.
            If Not File.Exists(strLogPath) AndAlso strLogPath <> "" Then
                swLogFile = File.CreateText(strLogPath)
                WriteHeaderInfo(swLogFile)

                swLogFile.Close()

                blnSuccess = True
            End If

            Return blnSuccess

        Catch ex As Exception
            CreateErrorCode(ex)
        End Try

    End Function

    Private Sub WriteHeaderInfo(ByVal swLogFile As TextWriter)

        Dim item As Object
        Dim intCount As Integer = 1

        Try
            ' Create a specific header for the different types of log files.
            Select Case LogType

                Case cREPORT_LOG
                    swLogFile.WriteLine("                     " & m_strReportTitle)
                    swLogFile.WriteLine("")
                    swLogFile.WriteLine("           {0} {1}", DateTime.Now.ToShortTimeString(), DateTime.Now.ToLongDateString())
                    swLogFile.WriteLine("-----------------------------------------------------------------")
                    swLogFile.WriteLine("Program Name:  " & vbTab & m_strProgramName)
                    swLogFile.WriteLine("User:          " & vbTab & m_strReportRunBy)
                    swLogFile.WriteLine("")
                    swLogFile.WriteLine("Report Parameter Information ")
                    swLogFile.WriteLine("")
                    swLogFile.WriteLine("Name                  Value")
                    swLogFile.WriteLine("-----------------------------------------------------------------")

                    For Each item In m_astrScreenParameters
                        If Not item Is Nothing Then
                            swLogFile.WriteLine("Screen Parameter " & intCount.ToString() & ": " & vbTab & item.ToString())
                        End If
                        intCount += 1
                    Next item

                    swLogFile.WriteLine("")
                    swLogFile.WriteLine("Report Language:      " & vbTab & m_strReportLanguage)
                    swLogFile.WriteLine("Report Run Time:      " & vbTab & Format(m_dtReportRunTime, "hh:mm tt"))
                    swLogFile.WriteLine("Report Run Date:      " & vbTab & Format(m_dtReportRunDate, "MM/dd/yyyy"))
                    swLogFile.WriteLine("-----------------------------------------------------------------")

                Case cERROR_LOG
                    swLogFile.WriteLine("                      Report Error Log")
                    swLogFile.WriteLine("")
                    swLogFile.WriteLine("         Log started at {0} on {1}.", DateTime.Now.ToShortTimeString(), DateTime.Now.ToLongDateString())
                    swLogFile.WriteLine("-----------------------------------------------------------------")

                Case cDEFAULT_LOG
                    swLogFile.WriteLine("               Report WebService Default Log")
                    swLogFile.WriteLine("")
                    swLogFile.WriteLine("         Log started at {0} on {1}.", DateTime.Now.ToShortTimeString(), DateTime.Now.ToLongDateString())
                    swLogFile.WriteLine("-----------------------------------------------------------------")

            End Select

            swLogFile.Flush()

        Catch ex As Exception
            CreateErrorCode(ex)
        End Try

    End Sub

    Public Sub WriteToLogFile(ByVal strText As String)

        Dim swLogFile As StreamWriter
        Dim strLogPath As String

        Try
            ' Determine the path to place the log file depending on it's type.
            Select Case LogType
                Case cREPORT_LOG
                    strLogPath = m_strReportLogPath

                Case cERROR_LOG
                    strLogPath = m_strErrorLogPath
            End Select

            If strLogPath = "" Then
                Return
            End If
            ' Open log file to write info into.
            swLogFile = File.AppendText(strLogPath)
            'swLogFile.Write("Log Entry : ")
            'swLogFile.WriteLine("{0} {1}", DateTime.Now.ToShortTimeString(), DateTime.Now.ToLongDateString())
            swLogFile.WriteLine(ControlChars.Tab & "{0}", strText)

            swLogFile.Close()

        Catch ex As Exception
            CreateErrorCode(ex)
        End Try

    End Sub

    Public Sub WriteToStatsFile(ByVal strText As String, strName As String)

        Dim swLogFile As StreamWriter

        Try

            If m_strDate = "" Then
                m_strDate = "_" & Now.Year.ToString &
                                                               Now.Month.ToString.PadLeft(2, "0") &
                                                               Now.Day.ToString.PadLeft(2, "0") &
                                                               Now.TimeOfDay.Hours.ToString.PadLeft(2, "0") &
                                                               Now.TimeOfDay.Minutes.ToString.PadLeft(2, "0") &
                                                               Now.TimeOfDay.Seconds.ToString.PadLeft(2, "0") &
                                                               Now.TimeOfDay.Milliseconds.ToString.PadLeft(3, "0")
            End If

            ' Open log file to write info into.
            swLogFile = File.AppendText(m_strStatisticsPath.Replace("UserID", Environment.UserName) + "\" + strName.ToUpper() + m_strDate + ".txt")

            swLogFile.WriteLine(strText)

            swLogFile.Close()

        Catch ex As Exception
            CreateErrorCode(ex)
        End Try

    End Sub

    Public Sub CloseLogFile()

        Dim swLogFile As StreamWriter
        Dim strLogPath As String

        Try
            ' Determine the path of the log file to complete writing of information.
            Select Case LogType
                Case cREPORT_LOG
                    strLogPath = m_strReportLogPath

                Case cERROR_LOG
                    strLogPath = m_strErrorLogPath
            End Select

            swLogFile = File.AppendText(strLogPath)
            swLogFile.Write(ControlChars.CrLf & "Log Completed : ")
            swLogFile.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString())
            swLogFile.WriteLine("{0}", " ")

            swLogFile.Close()

        Catch ex As Exception
            CreateErrorCode(ex)
        End Try

    End Sub

#End Region

#Region " Output to Error Log "

    Public Sub CreateErrorCode(ByVal rptException As Exception)

        Dim swLogFile As StreamWriter

        Try
            If Trim(m_strErrorLogPath) <> Trim("") Then
                swLogFile = File.AppendText(m_strErrorLogPath)

                swLogFile.Write("Log Entry : ")
                swLogFile.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString())
                swLogFile.WriteLine(" Error Source:      " & vbTab & rptException.Source.ToString)
                swLogFile.WriteLine(" Error Description: " & vbTab & Replace(rptException.Message.ToString, Chr(10), vbCrLf))
                swLogFile.WriteLine(" Error Stack Trace: " & vbTab & Replace(rptException.StackTrace.ToString, Chr(10), vbCrLf))

                swLogFile.WriteLine("--------------------------------------------------------")

                swLogFile.Flush()
                swLogFile.Close()
            End If

        Catch ex As Exception
            Debug.WriteLine(ex.Message().ToString())
        End Try

    End Sub

#End Region

End Class
