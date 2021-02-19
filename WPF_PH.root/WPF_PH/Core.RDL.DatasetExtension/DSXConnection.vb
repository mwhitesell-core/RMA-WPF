Option Explicit On

Imports Microsoft.ReportingServices.DataProcessing
Imports System.Security.Principal

Public Class DSXConnection
    Implements Microsoft.ReportingServices.DataProcessing.IDbConnectionExtension

    Private m_configuration As String = String.Empty
    Private m_connectionOpened As Boolean = False
    Private m_connectionUser As WindowsIdentity = Nothing
    Private m_connString As String
    Private m_connTimeout As Integer = 15    ' IDbConnection.ConnectionTimeout defaults to 15 seconds.
    Private m_impersonate As String = String.Empty
    Private m_integratedSecurity As Boolean = False
    Private m_locName As String = "Renaissance Architect Reports Extension"
    Private m_state As ConnectionState = ConnectionState.Closed
    Private m_password As String = String.Empty
    Private m_reportAssembly As String = String.Empty
    Private m_userName As String = String.Empty

    ' Default constructor.
    Public Sub New()

    End Sub

    ' Connection string constructor overload.
    Public Sub New(ByVal connString As String)

        m_connString = connString

    End Sub

#Region " Properties "

    Public Property ConnectionString() As String Implements Microsoft.ReportingServices.DataProcessing.IDbConnectionExtension.ConnectionString
        Get
            Return m_connString
        End Get
        Set(ByVal Value As String)
            m_connString = Value
        End Set
    End Property

    Public ReadOnly Property ValidateConnectString() As String

        Get
            Dim strConnectString As String

            strConnectString = m_connString

            If Not strConnectString.ToUpper().Contains("USER=") And Not strConnectString.ToUpper().Contains("USER ID=") Then
                If Not strConnectString.EndsWith(";") Then
                    strConnectString = strConnectString + ";"
                End If
                strConnectString = strConnectString + "User=" + m_userName

                If Not strConnectString.ToUpper().Contains("PASSWORD=" + m_password) Then
                    If Not strConnectString.EndsWith(";") Then
                        strConnectString = strConnectString + ";"
                    End If
                    strConnectString = strConnectString + "Password=" + m_password
                End If
            End If

            Return strConnectString
        End Get

    End Property

    Public Property IntegratedSecurity() As Boolean Implements IDbConnectionExtension.IntegratedSecurity
        Get
            Return m_integratedSecurity
        End Get
        Set(ByVal value As Boolean)
            m_integratedSecurity = value
        End Set
    End Property

    Public ReadOnly Property ConnectionTimeout() As Integer Implements Microsoft.ReportingServices.DataProcessing.IDbConnectionExtension.ConnectionTimeout
        Get
            Return m_connTimeout
        End Get
    End Property

    Public ReadOnly Property State() As ConnectionState
        Get
            Return m_state
        End Get
    End Property

    Public ReadOnly Property LocalizedName() As String Implements Microsoft.ReportingServices.DataProcessing.IDbConnectionExtension.LocalizedName
        Get
            Return m_locName
        End Get
    End Property

    WriteOnly Property UserName() As String Implements IDbConnectionExtension.UserName
        Set(ByVal value As String)
            m_userName = value
        End Set
    End Property

    WriteOnly Property Password() As String Implements IDbConnectionExtension.Password
        Set(ByVal value As String)
            m_password = value
        End Set
    End Property

    WriteOnly Property Impersonate() As String Implements IDbConnectionExtension.Impersonate
        Set(ByVal value As String)
            m_impersonate = value
        End Set
    End Property

    Friend ReadOnly Property ConnectionUser() As WindowsIdentity
        Get
            ' m_connectionUser is valid only during open connection
            If Not m_connectionOpened Then
                Throw New Exception("Connection Not Open")
            End If

            Return m_connectionUser
        End Get
    End Property

#End Region

    Public Sub Open() Implements Microsoft.ReportingServices.DataProcessing.IDbConnectionExtension.Open

        If Not m_connectionOpened Then
            If m_integratedSecurity Then
                m_connectionUser = WindowsIdentity.GetCurrent()
            Else
                m_connectionUser = Nothing
            End If

            m_connectionOpened = True
        End If

    End Sub

    Public Sub Close() Implements Microsoft.ReportingServices.DataProcessing.IDbConnectionExtension.Close

        If Not (m_connectionUser Is Nothing) Then
            m_connectionUser.Dispose()
        End If

        m_connectionOpened = False

    End Sub

    ' Implemented. Inherited from IExtension through IDbConnection.
    Public Sub SetConfiguration(ByVal configuration As String) Implements Microsoft.ReportingServices.DataProcessing.IDbConnectionExtension.SetConfiguration

        m_configuration = configuration

    End Sub

    Public Function BeginTransaction() As Microsoft.ReportingServices.DataProcessing.IDbTransaction Implements Microsoft.ReportingServices.DataProcessing.IDbConnectionExtension.BeginTransaction
        Return Nothing
    End Function

    Public Function CreateCommand() As Microsoft.ReportingServices.DataProcessing.IDbCommand Implements Microsoft.ReportingServices.DataProcessing.IDbConnectionExtension.CreateCommand

        strConfiguration = m_configuration

        ' Create a Command object and pass in the
        ' Connection object to provide config info.
        Return New DSXCommand(Me, strConfiguration)

    End Function

    Public Sub Dispose() Implements IDisposable.Dispose

    End Sub

End Class 'DSXConnection 

