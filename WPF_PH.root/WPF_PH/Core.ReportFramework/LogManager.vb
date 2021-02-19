
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.IO
Imports System.Data.OracleClient
Imports System.Diagnostics
Imports System.Security
Imports System.Security.Permissions
Imports System.Text
Imports System.Web

Namespace Core.ReportFramework
    Public Class LogManager

#Region "Declarations"

#Region "Variables"

        Private m_strErrorLogFile As String = String.Empty
        Private m_strReportLogFile As String = String.Empty
        Private m_strUserPath As String = String.Empty

        Private m_intLogType As Integer = 0

        Private m_astrParameters As Object = Nothing
        Private m_astrScreenParameters() As String
        Private m_strConnString As String = String.Empty
        Private m_strProgramName As String = String.Empty
        Private m_strUserDir As String = String.Empty
        Private m_strReportId As String = String.Empty
        Private m_strReportFileName As String = String.Empty
        Private m_strReportDir As String = String.Empty
        Private m_strReportTitle As String = String.Empty
        Private m_strReportFormat As String = String.Empty
        Private m_strReportLanguage As String = String.Empty
        Private m_strReportRunBy As String = String.Empty
        Private m_dtReportRunDate As Date
        Private m_dtReportRunTime As Date
        Private m_dtReportProcessTime As Double = 0
        Private m_blnEmailNotification As Boolean = False

        Private Const cDEFAULT_LOGTYPE As Integer = 0
        Private Const cERROR_LOGTYPE As Integer = 1
        Private Const cREPORT_LOGTYPE As Integer = 2

#Region "Enums"

        Public Enum LogTypes
            DefaultLog = 0
            ErrorLog = 1
            ReportLog = 2
        End Enum

#End Region

#End Region

#End Region

#Region " Constructors "

        Public Sub New()
            MyBase.New()
        End Sub

        'Public Sub New(ByVal strErrorLogFile As String)
        '    MyBase.New()

        '    m_strErrorLogFile = strErrorLogFile
        '    m_strUserPath = ""

        'End Sub

        Public Sub New(ByVal strLogFile As String)
            MyBase.New()

            'If Not strReportName Is Nothing Then
            'If strReportName.Trim <> String.Empty Then
            'm_strReportId = strReportName
            'End If
            'End If

            m_strReportLogFile = strLogFile

            'Select Case intLogType
            'Case cREPORT_LOGTYPE
            'm_strReportLogPath = strLogPath
            'Case cERROR_LOGTYPE
            'm_strErrorLogPath = strLogPath
            'Case cDEFAULT_LOGTYPE
            '
            'End Select

            'Me.LogType = intLogType

        End Sub

        Public Sub New(ByVal strLogFile As String, ByVal intLogType As Integer, Optional ByVal strReportName As String = "")
            MyBase.New()

            If Not strReportName Is Nothing Then
                If strReportName.Trim <> String.Empty Then
                    m_strReportId = strReportName
                End If
            End If

            Select Case intLogType
                Case cREPORT_LOGTYPE
                    m_strReportLogFile = strLogFile
                Case cERROR_LOGTYPE
                    m_strErrorLogFile = strLogFile
                Case cDEFAULT_LOGTYPE
                    '
            End Select

            Me.LogType = intLogType

        End Sub

        'Public Sub New(ByVal strReportUserPath As String, ByVal strErrorLogPath As String, _
        '               ByVal intLogType As Integer, Optional ByVal astrParameters As Object = Nothing)

        '    MyBase.New()

        '    m_strUserPath = strReportUserPath
        '    m_strErrorLogPath = strErrorLogPath

        '    Me.LogType = intLogType

        '    InitializeParameters(astrParameters)

        'End Sub

#End Region

#Region "Properties"

        Private Property LogType() As Integer
            Get
                Return m_intLogType
            End Get

            Set(ByVal Value As Integer)
                m_intLogType = Value
            End Set
        End Property

#End Region

#Region "Methods"

#Region "Private"

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

        '<FileIOPermissionAttribute(SecurityAction.Assert)>
        <SecuritySafeCritical>
        Private Sub WriteHeaderInfo(ByVal swLogFile As TextWriter)

            Dim item As Object = Nothing
            Dim intCount As Integer = 1

            Dim FileIOPermission As New FileIOPermission(PermissionState.Unrestricted)

            Try
                FileIOPermission.Assert()

                ' Create a specific header for the different types of log files.
                Select Case LogType
                    Case cREPORT_LOGTYPE
                        swLogFile.WriteLine("                   Renaissance Report Log")
                        swLogFile.WriteLine("")
                        swLogFile.WriteLine("-----------------------------------------------------------------")
                        swLogFile.WriteLine("Program Name:  " & vbTab & m_strReportId)
                        swLogFile.WriteLine("Run Started At: {0} On: {1}", DateTime.Now.ToShortTimeString(), DateTime.Now.ToLongDateString())

                        If Not m_astrScreenParameters Is Nothing Then
                            swLogFile.WriteLine("Report Parameter Information: ")
                            swLogFile.WriteLine("")
                            swLogFile.WriteLine("Name                  Value")
                            swLogFile.WriteLine("-----------------------------------------------------------------")

                            For Each item In m_astrScreenParameters
                                If Not item Is Nothing Then
                                    swLogFile.WriteLine("Screen Parameter " & intCount.ToString() & ": " & vbTab & item.ToString())
                                End If
                                intCount += 1
                            Next item
                        End If

                        swLogFile.WriteLine("-----------------------------------------------------------------")

                    Case cERROR_LOGTYPE
                        swLogFile.WriteLine("                   Renaissance Report Log")
                        swLogFile.WriteLine("")
                        swLogFile.WriteLine("         Log started at {0} on {1}.", DateTime.Now.ToShortTimeString(), DateTime.Now.ToLongDateString())
                        swLogFile.WriteLine("-----------------------------------------------------------------")

                    Case cDEFAULT_LOGTYPE
                        swLogFile.WriteLine("               Renaissance Report Log")
                        swLogFile.WriteLine("")
                        swLogFile.WriteLine("         Log started at {0} on {1}.", DateTime.Now.ToShortTimeString(), DateTime.Now.ToLongDateString())
                        swLogFile.WriteLine("-----------------------------------------------------------------")

                End Select

                swLogFile.Flush()

            Catch ex As Exception
                CreateErrorCode(ex)
            End Try

        End Sub

#End Region

#Region "Public"

        '<FileIOPermissionAttribute(SecurityAction.Assert)>
        <SecuritySafeCritical>
        Public Sub CloseLogFile()

            Dim swLogFile As StreamWriter
            'Dim strLogFile As String = String.Empty

            Dim FileIOPermission As New FileIOPermission(PermissionState.Unrestricted)

            Try
                FileIOPermission.Assert()
                ' Determine the path of the log file to complete writing of information.
                'Select Case LogType
                'Case cREPORT_LOGTYPE
                'strLogFile = m_strReportLogFile

                'Case cERROR_LOGTYPE
                'strLogPath = m_strErrorLogPath
                'End Select

                swLogFile = File.AppendText(m_strReportLogFile)
                swLogFile.Write(ControlChars.CrLf & "Run Ended At: {0} On: {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString())
                swLogFile.WriteLine("--------------------------------------------------------")
                swLogFile.WriteLine(ControlChars.CrLf & "{0}", " ")

                swLogFile.Close()

            Catch ex As Exception
                CreateErrorCode(ex)
            End Try

        End Sub

        '<FileIOPermissionAttribute(SecurityAction.Assert)>
        <SecuritySafeCritical>
        Public Sub CreateErrorCode(ByVal rptException As Exception)

            Dim swLogFile As StreamWriter
            'Dim strLogFile As String = String.Empty

            Dim FileIOPermission As New FileIOPermission(PermissionState.Unrestricted)

            Try
                FileIOPermission.Assert()

                'Select Case LogType
                'Case cREPORT_LOGTYPE
                'strLogFile = m_strReportLogFile

                'Case cERROR_LOGTYPE
                'strLogFile = m_strErrorLogFile
                'End Select

                swLogFile = File.AppendText(m_strReportLogFile)

                'swLogFile.Write("Log Entry : ")
                'swLogFile.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString())
                swLogFile.WriteLine("----------------------------------------------------------------------------")
                swLogFile.WriteLine(" Error Source:      " & rptException.Source.ToString)
                swLogFile.WriteLine(" Error Description: " & Replace(rptException.Message.ToString, Chr(10), vbCrLf))
                swLogFile.WriteLine(" Error Stack Trace: " & Replace(rptException.StackTrace.ToString, Chr(10), vbCrLf))

                swLogFile.WriteLine("----------------------------------------------------------------------------")

                swLogFile.Flush()
                swLogFile.Close()

            Catch ex As Exception
                Debug.WriteLine(ex.Message().ToString())

            End Try

        End Sub

        '<FileIOPermissionAttribute(SecurityAction.Assert)>
        <SecuritySafeCritical>
        Public Function OpenLogFile() As Boolean

            Dim swLogFile As StreamWriter
            'Dim strLogFile As String = String.Empty

            Dim blnSuccess As Boolean

            Dim FileIOPermission As New FileIOPermission(PermissionState.Unrestricted)

            Try
                FileIOPermission.Assert()
                blnSuccess = False

                ' Determine which type of log we want to open.
                'Select Case Me.LogType
                'Case cREPORT_LOGTYPE
                'strLogFile = m_strReportLogFile
                'Case cERROR_LOGTYPE
                'strLogFile = m_strErrorLogFile
                'Case cDEFAULT_LOGTYPE
                '
                'End Select

                ' Determine if the log exists already.
                If Not File.Exists(m_strReportLogFile) Then
                    swLogFile = File.CreateText(m_strReportLogFile)
                    WriteHeaderInfo(swLogFile)
                    swLogFile.Close()
                Else
                    swLogFile = File.AppendText(m_strReportLogFile)
                    WriteHeaderInfo(swLogFile)
                    swLogFile.Close()
                End If

                blnSuccess = True

            Catch ex As Exception
                CreateErrorCode(ex)

            End Try

            Return blnSuccess

        End Function

        '<FileIOPermissionAttribute(SecurityAction.Assert)>
        <SecuritySafeCritical>
        Public Sub WriteToLogFile(ByVal strText As String)

            Dim swLogFile As StreamWriter
            'Dim strLogFile As String = String.Empty

            Dim FileIOPermission As New FileIOPermission(PermissionState.Unrestricted)

            Try
                FileIOPermission.Assert()
                ' Determine the path to place the log file depending on it's type.
                'Select Case LogType
                'Case cREPORT_LOGTYPE
                'strLogFile = m_strReportLogFile

                'Case cERROR_LOGTYPE
                'strLogFile = m_strErrorLogFile
                'End Select

                ' Open log file to write info into.
                swLogFile = File.AppendText(m_strReportLogFile)
                swLogFile.WriteLine(ControlChars.Tab & "{0}", strText)

                swLogFile.Close()

            Catch ex As Exception
                CreateErrorCode(ex)
            End Try

        End Sub

#End Region

#End Region

    End Class

End Namespace

