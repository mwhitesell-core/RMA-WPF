

#Region "Publishing Interfaces"

Imports System.Collections.Specialized
Imports System.Xml

''' -----------------------------------------------------------------------------
''' Project	 : Core.ExceptionManagement.Interfaces
''' Interface	 : ExceptionManagement.IExceptionPublisher
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Interface to publish exception information.  All exception information is passed as the chain of exception objects.
''' </summary>
''' <history>
''' 	[patrick]	2005/01/05	Created
''' </history>
''' -----------------------------------------------------------------------------
    Public Interface IExceptionPublisher
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Method used to publish exception information and additional information.
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <param name="additionalInfo"></param>
    ''' <param name="configSettings"></param>
    ''' <remarks>exception - The exception object whose information should be published.<br/>
    ''' additionalInfo - A collection of additional data that should be published along with the exception information.<br/>
    ''' configSettings - A collection of name/value attributes specified in the config settings. 
    ''' </remarks>
    ''' <history>
    ''' 	[patrick]	2005/01/05	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Sub Publish (ByVal exception As Exception, ByVal additionalInfo As NameValueCollection, _
                 ByVal configSettings As NameValueCollection)
End Interface

'IPublishException

''' -----------------------------------------------------------------------------
''' Project	 : Core.ExceptionManagement.Interfaces
''' Interface	 : ExceptionManagement.IExceptionXmlPublisher
''' 
''' -----------------------------------------------------------------------------
''' <summary>
'''  Interface to publish exception information.  All exception information is passed as XML.
''' </summary>
''' <history>
''' 	[patrick]	2005/01/05	Created
''' </history>
''' -----------------------------------------------------------------------------
    Public Interface IExceptionXmlPublisher
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Method used to publish exception information and any additional information in XML.
    ''' </summary>
    ''' <param name="exceptionInfo"></param>
    ''' <param name="configSettings"></param>
    ''' <remarks>exceptionInfo - An XML Document containing the all exception information.<br/>
    ''' configSettings - A collection of name/value attributes specified in the config settings.
    ''' </remarks>
    ''' <history>
    ''' 	[patrick]	2005/01/05	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Sub Publish (ByVal exceptionInfo As XmlDocument, ByVal configSettings As NameValueCollection)
End Interface

'IPublishXMLException

#End Region