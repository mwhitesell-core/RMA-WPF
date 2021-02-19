Imports System.Runtime.Serialization
Imports Core.Globalization.Core.Globalization
Imports System.Resources
Imports System.Reflection
Imports System.Collections.Specialized
Imports System.Security.Permissions
Imports System.Security
Imports System.Threading
Imports System.Security.Principal


''' -----------------------------------------------------------------------------
''' Project	 : Core.ExceptionManagement
''' Class	 : ExceptionManagement.BaseApplicationException
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Base Application Exception Class. You can use this as the base exception object from which to derive your applications exception hierarchy.
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[patrick]	2005/01/04	Created
''' </history>
''' -----------------------------------------------------------------------------
    <Serializable()> _
Public Class BaseApplicationException
    Inherits ApplicationException

#Region "Constructors"

    ''' -----------------------------------------------------------------------------
    ''' <summary>Constructor with no params.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[patrick]	2005/01/04	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub New()
        MyBase.New()
        InitializeEnvironmentInformation()
    End Sub

    'New


    ''' -----------------------------------------------------------------------------
    ''' <summary>Constructor allowing the Message property to be set.
    ''' </summary>
    ''' <param name="message"></param>
    ''' <remarks>message - String setting the message of the exception.
    ''' </remarks>
    ''' <history>
    ''' 	[patrick]	2005/01/04	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub New (ByVal message As String)
        MyBase.New (message)
        m_Message = MyBase.Message
        InitializeEnvironmentInformation()
    End Sub

    'New


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Constructor allowing the Message and InnerException property to be set.
    ''' </summary>
    ''' <param name="message"></param>
    ''' <param name="inner"></param>
    ''' <remarks>message - String setting the message of the exception.<br/>inner - Sets a reference to the InnerException. </remarks>
    ''' <history>
    ''' 	[patrick]	2005/01/04	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub New (ByVal message As String, ByVal inner As Exception)
        MyBase.New (message, inner)
        m_Message = MyBase.Message
        InitializeEnvironmentInformation()
    End Sub

    'New
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Constructor allowing the ErrorCode property to be set.
    ''' </summary>
    ''' <param name="ErrorCode"></param>
    ''' <remarks>ErrorCode - Integer setting the message of the exception.</remarks>
    ''' <history>
    ''' 	[patrick]	2005/01/04	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub New (ByVal ErrorCode As Integer)

        MyBase.New (CStr (ErrorCode))
        m_Message = ErrorCode
        'm_GlobalizationManager = HttpContext.Current.Cache(HttpContext.Current.Session("Language").ToString.ToUpper)
        'm_Message = m_GlobalizationManager.GetString(ErrorCode,ResourceTypes.Message)

    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Constructor allowing the ErrorCode and InnerException property to be set.
    ''' </summary>
    ''' <param name="ErrorCode"></param>
    ''' <param name="inner"></param>
    ''' <remarks>ErrorCode - Integer setting the message of the exception.<br/>inner - Sets a reference to the InnerException. </remarks>
    ''' <history>
    ''' 	[patrick]	2005/01/04	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub New (ByVal ErrorCode As Integer, ByVal inner As Exception)
        MyBase.New (CStr (ErrorCode), inner)
        m_Message = m_GlobalizationManager.GetString (ErrorCode, ResourceTypes.Message)

    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Constructor used for deserialization of the exception class.
    ''' </summary>
    ''' <param name="info"></param>
    ''' <param name="context"></param>
    ''' <remarks>info - Represents the SerializationInfo of the exception.<br/>context - Represents the context information of the exception.</remarks>
    ''' <history>
    ''' 	[patrick]	2005/01/04	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Protected Sub New (ByVal info As SerializationInfo, ByVal context As StreamingContext)
        MyBase.New (info, context)
        m_Message = MyBase.Message
        m_machineName = info.GetString ("machineName")
        m_createdDateTime = info.GetDateTime ("createdDateTime")
        m_appDomainName = info.GetString ("appDomainName")
        m_threadIdentity = info.GetString ("threadIdentity")
        m_windowsIdentity = info.GetString ("windowsIdentity")
        m_additionalInformation = _
            CType (info.GetValue ("additionalInformation", GetType (NameValueCollection)), NameValueCollection)
    End Sub

    'New

#End Region

#Region "Declare Member Variables"

    ' Member variable declarations
    Private m_machineName As String
    Private m_createdDateTime As DateTime = DateTime.Now
    Private m_appDomainName As String
    Private m_threadIdentity As String
    Private m_windowsIdentity As String
    Private m_ErrorCode As Integer
    Private m_GlobalizationManager As GlobalizationManager
    Private m_Message As String


    Private Shared _
        m_resourceManager As _
            New ResourceManager (GetType (ExceptionManager).Namespace + ".ExceptionManagerText", _
                                 Assembly.GetAssembly (GetType (ExceptionManager)))

    ' Collection provided to store any extra information associated with the exception.
    Private m_additionalInformation As New NameValueCollection

#End Region


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Override the GetObjectData method to serialize custom values.
    ''' </summary>
    ''' <param name="info"></param>
    ''' <param name="context"></param>
    ''' <remarks>info - Represents the SerializationInfo of the exception.<br/>context - Represents the context information of the exception.</remarks>
    ''' <history>
    ''' 	[patrick]	2005/01/04	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <SecurityPermission (SecurityAction.Demand, SerializationFormatter := True)> _
    Public Overrides Sub GetObjectData (ByVal info As SerializationInfo, ByVal context As StreamingContext)
        info.AddValue ("machineName", m_machineName, GetType (String))
        info.AddValue ("createdDateTime", m_createdDateTime)
        info.AddValue ("appDomainName", m_appDomainName, GetType (String))
        info.AddValue ("threadIdentity", m_threadIdentity, GetType (String))
        info.AddValue ("windowsIdentity", m_windowsIdentity, GetType (String))
        info.AddValue ("additionalInformation", m_additionalInformation, GetType (NameValueCollection))
        MyBase.GetObjectData (info, context)
    End Sub

    'GetObjectData

#Region "Public Properties"

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Machine name where the exception occurred.
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[patrick]	2005/01/04	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public ReadOnly Property MachineName() As String
        Get
            Return m_machineName
        End Get
    End Property


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    '''  Date and Time the exception was created.
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[patrick]	2005/01/04	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public ReadOnly Property CreatedDateTime() As DateTime
        Get
            Return m_createdDateTime
        End Get
    End Property


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' AppDomain name where the exception occurred.
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[patrick]	2005/01/04	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public ReadOnly Property AppDomainName() As String
        Get
            Return m_appDomainName
        End Get
    End Property


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Identity of the executing thread on which the exception was created.
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[patrick]	2005/01/04	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public ReadOnly Property ThreadIdentityName() As String
        Get
            Return m_threadIdentity
        End Get
    End Property


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Windows identity under which the code was running.
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[patrick]	2005/01/04	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public ReadOnly Property WindowsIdentityName() As String
        Get
            Return m_windowsIdentity
        End Get
    End Property


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Collection allowing additional information to be added to the exception.
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[patrick]	2005/01/04	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public ReadOnly Property AdditionalInformation() As NameValueCollection
        Get
            Return m_additionalInformation
        End Get
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Identity under which Errorcode of the exception
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[patrick]	2005/01/04	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public ReadOnly Property ErrorCode() As Integer
        Get
            Return m_ErrorCode
        End Get
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Description of the exception
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[patrick]	2005/01/04	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Overrides ReadOnly Property Message() As String
        Get
            Return m_Message
        End Get
    End Property

#End Region


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Initialization function that gathers environment information safely.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[patrick]	2005/01/04	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub InitializeEnvironmentInformation()
        Try
            m_machineName = Environment.MachineName
        Catch e As SecurityException
            m_machineName = m_resourceManager.GetString ("RES_EXCEPTIONMANAGEMENT_PERMISSION_DENIED")
        Catch
            m_machineName = m_resourceManager.GetString ("RES_EXCEPTIONMANAGEMENT_INFOACCESS_EXCEPTION")
        End Try

        Try
            m_threadIdentity = Thread.CurrentPrincipal.Identity.Name
        Catch e As SecurityException
            m_threadIdentity = m_resourceManager.GetString ("RES_EXCEPTIONMANAGEMENT_PERMISSION_DENIED")
        Catch
            m_threadIdentity = m_resourceManager.GetString ("RES_EXCEPTIONMANAGEMENT_INFOACCESS_EXCEPTION")
        End Try

        Try
            m_windowsIdentity = WindowsIdentity.GetCurrent().Name
        Catch e As SecurityException
            m_windowsIdentity = m_resourceManager.GetString ("RES_EXCEPTIONMANAGEMENT_PERMISSION_DENIED")
        Catch
            m_windowsIdentity = m_resourceManager.GetString ("RES_EXCEPTIONMANAGEMENT_INFOACCESS_EXCEPTION")
        End Try

        Try
            m_appDomainName = AppDomain.CurrentDomain.FriendlyName
        Catch e As SecurityException
            m_appDomainName = m_resourceManager.GetString ("RES_EXCEPTIONMANAGEMENT_PERMISSION_DENIED")
        Catch
            m_appDomainName = m_resourceManager.GetString ("RES_EXCEPTIONMANAGEMENT_INFOACCESS_EXCEPTION")
        End Try
    End Sub
End Class

'BaseApplicationException 