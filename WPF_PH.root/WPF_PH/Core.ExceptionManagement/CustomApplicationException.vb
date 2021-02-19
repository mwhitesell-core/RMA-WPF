Imports System.Runtime.Serialization
Imports System.Security.Permissions


''' -----------------------------------------------------------------------------
''' Project	 : Core.ExceptionManagement
''' Class	 : ExceptionManagement.CustomApplicationException
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Exception handler used to display custom errors raised through business logic.
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[patrick]	2005/01/04	Created
''' </history>
''' -----------------------------------------------------------------------------
    <Serializable()> _
Public Class CustomApplicationException
    Inherits BaseApplicationException
    ' private variable for OS Version property
    Private m_OSVersion As String = Environment.OSVersion.ToString()
    Private m_Message As String
    Private m_BaseException As BaseApplicationException

    'Added folowing Message Information as Custom Application Error contains only "Error" as a message,
    'once it passes through AddMessage, In order to access the original error message along with
    'MessageInformation, I added following three Fields
    Public MessageType As String
    'TODO: Should be MessageTypes
    Public MessageNumber As String
    Public MessageText As String


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Default constructor
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[patrick]	2005/01/04	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub New()
        MyBase.New()
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Constructor allowing the ErrorCode Message to be set.
    ''' </summary>
    ''' <param name="Message"></param>
    ''' <remarks>Message - Represents the description of the exception.
    ''' </remarks>
    ''' <history>
    ''' 	[patrick]	2005/01/04	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub New (ByVal Message As String)

        MyBase.New (Message)

    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Constructor allowing the Message, MessageType, MessageNumber and MessageText property to be set.
    ''' </summary>
    ''' <param name="Message"></param>
    ''' <param name="MessageType"></param>
    ''' <param name="MessageNumber"></param>
    ''' <param name="MessageText"></param>
    ''' <remarks>
    ''' Message - Represents the description of the exception.<br/>
    ''' MessageType - Represents the type of the exception.<br/>
    ''' MessageNumber - Represents the number of the exception.<br/>
    ''' MessageText - Represents the text of the exception.<br/>
    ''' </remarks>
    ''' <history>
    ''' 	[patrick]	2005/01/04	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub New (ByVal Message As String, ByVal MessageType As String, ByVal MessageNumber As String, _
                    ByVal MessageText As String)

        MyBase.New (Message)
        Me.MessageText = MessageText
        Me.MessageNumber = MessageNumber
        Me.MessageType = MessageType

    End Sub

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

        MyBase.New (ErrorCode)

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

        MyBase.New (ErrorCode, inner)

    End Sub

    ' constructor with message and inner exception

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
        m_OSVersion = info.GetString ("m_OSVersion")

    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Serialize this class' state and then call the base class GetObjectData
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
        ' Serialize this class' state and then call the base class GetObjectData
        info.AddValue ("m_OSVersion", m_OSVersion, GetType (String))
        MyBase.GetObjectData (info, context)
    End Sub


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' ReadOnly OS Version property
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[patrick]	2005/01/04	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public ReadOnly Property OSVersion()
        Get
            Return m_OSVersion
        End Get
    End Property
End Class
