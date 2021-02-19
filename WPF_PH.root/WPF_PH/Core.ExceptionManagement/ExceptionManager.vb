Imports System.Collections.Specialized
Imports System.Xml
Imports System.Configuration
Imports Core.ExceptionManagement.Interfaces
Imports System.Resources
Imports System.Reflection
Imports System.Web
Imports System.Security
Imports Core.ExceptionManagement.My.Resources
Imports System.Threading
Imports System.Security.Principal
Imports System.Runtime.Serialization
Imports System.Text


#Region "ExceptionManager Class"

''' -----------------------------------------------------------------------------
''' Project	 : Core.ExceptionManagement
''' Class	 : ExceptionManagement.ExceptionManager
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' The Exception Manager class manages the publishing of exception information based on settings in the configuration file.
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[patrick]	2005/01/04	Created
''' </history>
''' -----------------------------------------------------------------------------
Public NotInheritable Class ExceptionManager
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Private constructor to restrict an instance of this class from being created.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[patrick]	2005/01/04	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub New()
    End Sub

    'New

    ' Member variable declarations
    Private Shared EXCEPTIONMANAGER_NAME As String = GetType(ExceptionManager).Name
    Private Shared EXCEPTIONMANAGEMENT_CONFIG_SECTION As String = "exceptionManagement"


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Static method to publish the exception information.
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <remarks>exception - The exception object whose information should be published.
    ''' </remarks>
    ''' <history>
    ''' 	[patrick]	2005/01/04	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Overloads Shared Sub Publish(ByVal exception As Exception)
        Publish(exception, Nothing)
    End Sub

    'Publish


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    '''  Static method to publish the exception information and any additional information.
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <param name="additionalInfo"></param>
    ''' <remarks>exception - The exception object whose information should be published.<br/>
    ''' additionalInfo - A collection of additional data that should be published along with the exception information.
    ''' </remarks>
    ''' <history>
    ''' 	[patrick]	2005/01/04	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Overloads Shared Sub Publish(ByVal exception As Exception, ByVal additionalInfo As NameValueCollection)

        Dim config As ExceptionManagementSettings
        Dim Publisher As PublisherSettings

        Try

            ExceptionLogging.LogMessage(exception.Message)



            '' Create the Additional Information collection if it does not exist.
            'If additionalInfo Is Nothing Then additionalInfo = New NameValueCollection()

            'If (HttpContext.Current.Session("USERID") & "").Length > 0 Then
            '    additionalInfo.Add(EXCEPTIONMANAGER_NAME + ".Login User", HttpContext.Current.Session("USERID") & "")
            'End If

            'If (HttpContext.Current.Request.ServerVariables("REMOTE_ADDR").ToString() & "").Length > 0 Then
            '    additionalInfo.Add(EXCEPTIONMANAGER_NAME + ".IP Address",
            '                        HttpContext.Current.Request.ServerVariables("REMOTE_ADDR").ToString() & "")
            'End If

            'Try
            '    additionalInfo.Add(EXCEPTIONMANAGER_NAME + ".MachineName", Environment.MachineName)
            'Catch e As SecurityException
            '    additionalInfo.Add(EXCEPTIONMANAGER_NAME + ".MachineName",
            '                        ExceptionManagerText.RES_EXCEPTIONMANAGEMENT_PERMISSION_DENIED)
            'Catch
            '    additionalInfo.Add(EXCEPTIONMANAGER_NAME + ".MachineName",
            '                        ExceptionManagerText.RES_EXCEPTIONMANAGEMENT_INFOACCESS_EXCEPTION)
            'End Try

            'Try
            '    additionalInfo.Add(EXCEPTIONMANAGER_NAME + ".TimeStamp", DateTime.Now.ToString())
            'Catch e As SecurityException
            '    additionalInfo.Add(EXCEPTIONMANAGER_NAME + ".TimeStamp",
            '                        ExceptionManagerText.RES_EXCEPTIONMANAGEMENT_PERMISSION_DENIED)
            'Catch
            '    additionalInfo.Add(EXCEPTIONMANAGER_NAME + ".TimeStamp",
            '                        ExceptionManagerText.RES_EXCEPTIONMANAGEMENT_INFOACCESS_EXCEPTION)
            'End Try

            'Try
            '    additionalInfo.Add(EXCEPTIONMANAGER_NAME + ".FullName", Assembly.GetExecutingAssembly().FullName)

            'Catch e As SecurityException
            '    additionalInfo.Add(EXCEPTIONMANAGER_NAME + ".FullName",
            '                        ExceptionManagerText.RES_EXCEPTIONMANAGEMENT_PERMISSION_DENIED)
            'Catch
            '    additionalInfo.Add(EXCEPTIONMANAGER_NAME + ".FullName",
            '                        ExceptionManagerText.RES_EXCEPTIONMANAGEMENT_INFOACCESS_EXCEPTION)
            'End Try

            'Try
            '    additionalInfo.Add(EXCEPTIONMANAGER_NAME + ".AppDomainName", AppDomain.CurrentDomain.FriendlyName)
            'Catch e As SecurityException
            '    additionalInfo.Add(EXCEPTIONMANAGER_NAME + ".AppDomainName",
            '                        ExceptionManagerText.RES_EXCEPTIONMANAGEMENT_PERMISSION_DENIED)
            'Catch
            '    additionalInfo.Add(EXCEPTIONMANAGER_NAME + ".AppDomainName",
            '                        ExceptionManagerText.RES_EXCEPTIONMANAGEMENT_INFOACCESS_EXCEPTION)
            'End Try

            'Try
            '    additionalInfo.Add(EXCEPTIONMANAGER_NAME + ".ThreadIdentity", Thread.CurrentPrincipal.Identity.Name)
            'Catch e As SecurityException
            '    additionalInfo.Add(EXCEPTIONMANAGER_NAME + ".ThreadIdentity",
            '                        ExceptionManagerText.RES_EXCEPTIONMANAGEMENT_PERMISSION_DENIED)
            'Catch
            '    additionalInfo.Add(EXCEPTIONMANAGER_NAME + ".ThreadIdentity",
            '                        ExceptionManagerText.RES_EXCEPTIONMANAGEMENT_INFOACCESS_EXCEPTION)
            'End Try

            'Try
            '    additionalInfo.Add(EXCEPTIONMANAGER_NAME + ".WindowsIdentity", WindowsIdentity.GetCurrent().Name)
            'Catch e As SecurityException
            '    additionalInfo.Add(EXCEPTIONMANAGER_NAME + ".WindowsIdentity",
            '                        ExceptionManagerText.RES_EXCEPTIONMANAGEMENT_PERMISSION_DENIED)
            'Catch
            '    additionalInfo.Add(EXCEPTIONMANAGER_NAME + ".WindowsIdentity",
            '                        ExceptionManagerText.RES_EXCEPTIONMANAGEMENT_INFOACCESS_EXCEPTION)
            'End Try


            '' Check for any settings in config file.
            'If ConfigurationManager.GetSection(EXCEPTIONMANAGEMENT_CONFIG_SECTION) Is Nothing Then

            '    ' Publish the exception and additional information to the default publisher if no settings are present.
            '    PublishToDefaultPublisher(exception, additionalInfo)
            'Else
            '    ' Get settings from config file
            '    config =
            '        CType(ConfigurationManager.GetSection(EXCEPTIONMANAGEMENT_CONFIG_SECTION),
            '            ExceptionManagementSettings)

            '    ' If the mode is not equal to "off" call the Publishers, otherwise do nothing.
            '    If config.Mode = ExceptionManagementMode.On Then
            '        ' If no publishers are specified, use the default publisher.
            '        If config.Publishers Is Nothing OrElse config.Publishers.Count = 0 Then
            '            ' Publish the exception and additional information to the default publisher if no mode is specified.
            '            PublishToDefaultPublisher(exception, additionalInfo)
            '        Else

            '            ' Loop through the publisher components specified in the config file.
            '            For Each Publisher In config.Publishers '

            '                ' Call the Publisher component specified in the config file.
            '                Try
            '                    ' Verify the publishers mode is not set to "OFF".
            '                    ' This publisher will be called even if the mode is not specified.  
            '                    ' The mode must explicitly be set to OFF to not be called.
            '                    If Publisher.Mode = PublisherMode.On Then
            '                        If _
            '                            exception Is Nothing OrElse
            '                            Not Publisher.IsExceptionFiltered(exception.GetType()) Then
            '                            ' Publish the exception and any additional information
            '                            PublishToCustomPublisher(exception, additionalInfo, Publisher)
            '                        End If
            '                    End If
            '                    ' Catches any failure to call a custom publisher.
            '                Catch e As Exception
            '                    ' Publish the exception thrown within the ExceptionManager.
            '                    PublishInternalException(e, Nothing)

            '                    ' Publish the original exception and additional information to the default publisher.
            '                    PublishToDefaultPublisher(exception, additionalInfo)
            '                End Try
            '            Next Publisher
            '            ' End Catch block.
            '        End If
            '    End If
            '    ' End foreach loop through publishers.
            'End If
            '

        Catch e As Exception '
            ' Publish the exception thrown when trying to call the custom publisher.
            PublishInternalException(e, Nothing)

            ' Publish the original exception and additional information to the default publisher.
            PublishToDefaultPublisher(exception, additionalInfo)
        End Try
    End Sub

    'Publish


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Private static helper method to publish the exception information to a custom publisher.
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <param name="additionalInfo"></param>
    ''' <param name="publisher"></param>
    ''' <remarks>exception - The exception object whose information should be published.<br/>
    ''' additionalInfo - A collection of additional data that should be published along with the exception information.<br/>
    ''' publisher - The PublisherSettings that contains the values of the publishers configuration.
    ''' </remarks>
    ''' <history>
    ''' 	[patrick]	2005/01/04	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Shared Sub PublishToCustomPublisher(ByVal exception As Exception,
                                                 ByVal additionalInfo As NameValueCollection,
                                                 ByVal publisher As PublisherSettings)

        Dim XMLPublisher As IExceptionXmlPublisher
        Dim m_Publisher As IExceptionPublisher

        Try
            ' Check if the exception format is "xml".
            If publisher.ExceptionFormat = PublisherFormat.Xml Then
                ' If it is load the Interfaces.IExceptionXmlPublisher interface on the custom publisher.
                ' Instantiate the class
                XMLPublisher = CType(Activate(publisher.AssemblyName, publisher.TypeName), IExceptionXmlPublisher)

                ' Publish the exception and any additional information
                XMLPublisher.Publish(SerializeToXML(exception, additionalInfo), publisher.OtherAttributes)
                ' Otherwise load the Interfaces.IExceptionPublisher interface on the custom publisher.
            Else

                ' Instantiate the class
                m_Publisher = CType(Activate(publisher.AssemblyName, publisher.TypeName), IExceptionPublisher)

                ' Publish the exception and any additional information
                m_Publisher.Publish(exception, additionalInfo, publisher.OtherAttributes)
            End If
        Catch e As Exception
            Dim _
                publisherException As CustomPublisherException =
                    New CustomPublisherException(ExceptionManagerText.RES_CUSTOM_PUBLISHER_FAILURE_MESSAGE,
                                                  publisher.AssemblyName, publisher.TypeName, publisher.ExceptionFormat,
                                                  e)
            publisherException.AdditionalInformation.Add(publisher.OtherAttributes)

            Throw publisherException
        End Try
    End Sub

    'PublishToCustomPublisher


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Private static helper method to publish the exception information to the default publisher.
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <param name="additionalInfo"></param>
    ''' <remarks>exception - The exception object whose information should be published.<br/>
    ''' additionalInfo - A collection of additional data that should be published along with the exception information.
    ''' </remarks>
    ''' <history>
    ''' 	[patrick]	2005/01/04	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Shared Sub PublishToDefaultPublisher(ByVal exception As Exception,
                                                  ByVal additionalInfo As NameValueCollection)
        ' Get the Default Publisher
        Dim Publisher As New DefaultPublisher()

        ' Publish the exception and any additional information
        Publisher.Publish(exception, additionalInfo, Nothing)
    End Sub

    'PublishToDefaultPublisher


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Private static helper method to publish the exception information to the default publisher.
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <param name="additionalInfo"></param>
    ''' <remarks>exception - The exception object whose information should be published. <br/>
    ''' additionalInfo - A collection of additional data that should be published along with the exception information.
    ''' </remarks>
    ''' <history>
    ''' 	[patrick]	2005/01/04	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Protected Friend Shared Sub PublishInternalException(ByVal exception As Exception,
                                                          ByVal additionalInfo As NameValueCollection)
        ' Get the Default Publisher
        Dim _
            Publisher As _
                New DefaultPublisher("Application", ExceptionManagerText.RES_EXCEPTIONMANAGER_INTERNAL_EXCEPTIONS)

        ' Publish the exception and any additional information
        Publisher.Publish(exception, additionalInfo, Nothing)
    End Sub

    'PublishInternalException


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' rivate helper function to assist in run-time activations
    ''' </summary>
    ''' <param name="assembly"></param>
    ''' <param name="typeName"></param>
    ''' <returns>Instance of the type specified in the input parameters.</returns>
    ''' <remarks>assembly - Name of the assembly file (w/out extension)<br/>
    ''' typeName - Name of the type to create.
    ''' </remarks>
    ''' <history>
    ''' 	[patrick]	2005/01/04	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Shared Function Activate(ByVal [assembly] As String, ByVal typeName As String) As Object
        Return AppDomain.CurrentDomain.CreateInstanceAndUnwrap([assembly], typeName)
    End Function

    'Activate


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Public static helper method to serialize the exception information into XML.
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <param name="additionalInfo"></param>
    ''' <returns></returns>
    ''' <remarks>exception - The exception object whose information should be published.<br/>
    ''' additionalInfo - A collection of additional data that should be published along with the exception information.
    ''' </remarks>
    ''' <history>
    ''' 	[patrick]	2005/01/04	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function SerializeToXML(ByVal exception As Exception, ByVal additionalInfo As NameValueCollection) _
        As XmlDocument

        Try
            ' Variables representing the XmlElement names.
            Dim xmlNodeName_ROOT As String = ExceptionManagerText.RES_XML_ROOT
            Dim xmlNodeName_ADDITIONAL_INFORMATION As String = ExceptionManagerText.RES_XML_ADDITIONAL_INFORMATION
            Dim xmlNodeName_EXCEPTION As String = ExceptionManagerText.RES_XML_EXCEPTION
            Dim xmlNodeName_STACK_TRACE As String = ExceptionManagerText.RES_XML_STACK_TRACE

            ' Create a new XmlDocument.
            Dim xmlDoc As New XmlDocument()

            ' Create the root node.
            Dim m_root As XmlElement = xmlDoc.CreateElement(xmlNodeName_ROOT)
            xmlDoc.AppendChild(m_root)

            ' Variables to hold values while looping through the exception chain.
            Dim element As XmlElement
            Dim exceptionAddInfoElement As XmlElement
            Dim stackTraceElement As XmlElement
            Dim stackTraceText As XmlText
            Dim attribute As XmlAttribute

            Dim i As String
            Dim currentException As Exception
            ' Temp variable to hold InnerException object during the loop.
            Dim parentElement As XmlElement = Nothing
            ' Temp variable to hold the parent exception node during the loop.
            Dim aryPublicProperties As PropertyInfo()
            Dim currentAdditionalInfo As NameValueCollection
            Dim p As PropertyInfo

            ' Check if the collection has values.
            If Not (additionalInfo Is Nothing) AndAlso additionalInfo.Count > 0 Then

                ' Create the element for the collection.
                element = xmlDoc.CreateElement(xmlNodeName_ADDITIONAL_INFORMATION)

                ' Loop through the collection and add the values as attributes on the element.

                For Each i In additionalInfo
                    attribute = xmlDoc.CreateAttribute(i.Replace(" ", "_"))
                    attribute.Value = additionalInfo.Get(i)
                    element.Attributes.Append(attribute)
                Next i

                ' Add the element to the root.
                m_root.AppendChild(element)
            End If


            If exception Is Nothing Then
                ' Create an empty exception element.
                element = xmlDoc.CreateElement(xmlNodeName_EXCEPTION)

                ' Append to the root node.
                m_root.AppendChild(element)
            Else
                currentException = exception
                'Temp variable to hold InnerException object during the loop.
                'Loop through each exception class in the chain of exception objects and record its information
                Do
                    ' Create the exception element.
                    element = xmlDoc.CreateElement(xmlNodeName_EXCEPTION)

                    ' Add the exceptionType as an attribute.
                    attribute = xmlDoc.CreateAttribute("ExceptionType")
                    attribute.Value = currentException.GetType().FullName
                    element.Attributes.Append(attribute)

                    ' Loop through the public properties of the exception object and record their value.
                    aryPublicProperties = currentException.GetType().GetProperties()
                    '

                    For Each p In aryPublicProperties
                        ' Do not log information for the InnerException or StackTrace. This information is 
                        ' captured later in the process.
                        If p.Name <> "InnerException" And p.Name <> "StackTrace" Then
                            ' Only record properties whose value is not null.
                            If Not (p.GetValue(currentException, Nothing) Is Nothing) Then
                                ' Check if the property is AdditionalInformation and the exception type is a BaseApplicationException.
                                If _
                                    p.Name = "AdditionalInformation" And
                                    TypeOf currentException Is BaseApplicationException Then
                                    ' Verify the collection is not null.
                                    If Not (p.GetValue(currentException, Nothing) Is Nothing) Then
                                        ' Cast the collection into a local variable.
                                        currentAdditionalInfo =
                                            CType(p.GetValue(currentException, Nothing), NameValueCollection)

                                        ' Verify the collection has values.
                                        If currentAdditionalInfo.Count > 0 Then
                                            ' Create element.
                                            exceptionAddInfoElement =
                                                xmlDoc.CreateElement(xmlNodeName_ADDITIONAL_INFORMATION)

                                            ' Loop through the collection and add values as attributes.
                                            For Each i In currentAdditionalInfo
                                                attribute = xmlDoc.CreateAttribute(i.Replace(" ", "_"))
                                                attribute.Value = currentAdditionalInfo.Get(i)
                                                exceptionAddInfoElement.Attributes.Append(attribute)
                                            Next i

                                            element.AppendChild(exceptionAddInfoElement)
                                        End If
                                    End If
                                    ' Otherwise just add the ToString() value of the property as an attribute.
                                Else
                                    attribute = xmlDoc.CreateAttribute(p.Name)
                                    attribute.Value = p.GetValue(currentException, Nothing).ToString()
                                    element.Attributes.Append(attribute)
                                End If
                            End If
                        End If
                    Next p

                    ' Record the StackTrace within a separate element.
                    If Not (currentException.StackTrace Is Nothing) Then

                        ' Create Stack Trace Element.
                        stackTraceElement = xmlDoc.CreateElement(xmlNodeName_STACK_TRACE)

                        stackTraceText = xmlDoc.CreateTextNode(currentException.StackTrace.ToString())

                        stackTraceElement.AppendChild(stackTraceText)

                        element.AppendChild(stackTraceElement)
                    End If

                    ' Check if this is the first exception in the chain.
                    If parentElement Is Nothing Then
                        ' Append to the root node.
                        m_root.AppendChild(element)
                    Else
                        ' Append to the parent exception object in the exception chain.
                        parentElement.AppendChild(element)
                    End If

                    ' Reset the temp variables.
                    parentElement = element
                    currentException = currentException.InnerException
                Loop While Not (currentException Is Nothing)
            End If
            ' Continue looping until we reach the end of the exception chain.

            ' Return the XmlDocument.
            Return xmlDoc

        Catch e As Exception
            Throw _
                New SerializationException(ExceptionManagerText.RES_EXCEPTIONMANAGEMENT_XMLSERIALIZATION_EXCEPTION, e)
        End Try

    End Function

    'SerializeToXML
End Class

'ExceptionManager

#End Region

#Region "DefaultPublisher Class"


''' -----------------------------------------------------------------------------
''' Project	 : Core.ExceptionManagement
''' Class	 : ExceptionManagement.DefaultPublisher
''' 
''' -----------------------------------------------------------------------------
''' <summary>
'''  Component used as the default publishing component if one is not specified in the config file.
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[patrick]	2005/01/04	Created
''' </history>
''' -----------------------------------------------------------------------------
Public NotInheritable Class DefaultPublisher
    Implements IExceptionPublisher


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Default Constructor.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[patrick]	2005/01/04	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub New()
    End Sub

    'New 


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Constructor allowing the log name and application names to be set.
    ''' </summary>
    ''' <param name="logName"></param>
    ''' <param name="applicationName"></param>
    ''' <remarks>logName - The name of the log for the DefaultPublisher to use.<br/>
    ''' applicationName - The name of the application.  This is used as the Source name in the event log. 
    ''' </remarks>
    ''' <history>
    ''' 	[patrick]	2005/01/04	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub New(ByVal logName As String, ByVal applicationName As String)
        Me.logName = logName
        Me.applicationName = applicationName
    End Sub

    'New

    Private Shared _
        m_resourceManager As _
            New ResourceManager(GetType(ExceptionManager).Namespace + ".ExceptionManagerText",
                                 Assembly.GetAssembly(GetType(ExceptionManager)))

    ' Member variable declarations
    Private logName As String = "Application"
    Private applicationName As String = m_resourceManager.GetString("RES_EXCEPTIONMANAGER_PUBLISHED_EXCEPTIONS")
    Private TEXT_SEPARATOR As String = "*********************************************"


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Method used to publish exception information and additional information.
    ''' </summary>
    ''' <param name="exception"></param>
    ''' <param name="additionalInfo"></param>
    ''' <param name="configSettings"></param>
    ''' <remarks>exception - The exception object whose information should be published.<br/>
    ''' additionalInfo - A collection of additional data that should be published along with the exception information.<br/>
    ''' configSettings - A collection of any additional attributes provided in the config settings for the custom publisher.
    ''' </remarks>
    ''' <history>
    ''' 	[patrick]	2005/01/04	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub Publish(ByVal exception As Exception, ByVal additionalInfo As NameValueCollection,
                        ByVal configSettings As NameValueCollection) Implements IExceptionPublisher.Publish

        ' Create StringBuilder to maintain publishing information.
        Dim strInfo As New StringBuilder
        Dim i As String
        Dim currentException As Exception
        Dim intExceptionCount As Integer = 1
        ' Count variable to track the number of exceptions in the chain.
        Dim aryPublicProperties As PropertyInfo()
        Dim currentAdditionalInfo As NameValueCollection
        Dim p As PropertyInfo
        Dim j As Integer
        Dim k As Integer

        ' Load Config values if they are provided.
        If Not (configSettings Is Nothing) Then
            If Not (configSettings("applicationName") Is Nothing) AndAlso configSettings("applicationName").Length > 0 _
                Then
                applicationName = configSettings("applicationName")
            End If
            If Not (configSettings("logName") Is Nothing) AndAlso configSettings("logName").Length > 0 Then
                logName = configSettings("logName")
            End If
        End If

        ' Verify that the Source exists before gathering exception information.
        VerifyValidSource()

        ' Record the contents of the AdditionalInfo collection.
        If Not (additionalInfo Is Nothing) Then

            ' Record General information.
            strInfo.AppendFormat("{0}General Information {0}{1}{0}Additional Info:", Environment.NewLine,
                                  TEXT_SEPARATOR)

            For Each i In additionalInfo
                strInfo.AppendFormat("{0}{1}: {2}", Environment.NewLine, i, additionalInfo.Get(i))
            Next i
        End If

        If exception Is Nothing Then
            strInfo.AppendFormat("{0}{0}No Exception object has been provided..{0}", Environment.NewLine)
        Else
            ' Loop through each exception class in the chain of exception objects.

            ' Temp variable to hold InnerException object during the loop.
            currentException = exception
            '

            Do
                ' Write title information for the exception object.
                strInfo.AppendFormat("{0}{0}{1}) Exception Information{0}{2}", Environment.NewLine,
                                      intExceptionCount.ToString(), TEXT_SEPARATOR)
                strInfo.AppendFormat("{0}Exception Type: {1}", Environment.NewLine, currentException.GetType().FullName)

                ' Loop through the public properties of the exception object and record their value.
                aryPublicProperties = currentException.GetType().GetProperties()
                '

                For Each p In aryPublicProperties
                    ' Do not log information for the InnerException or StackTrace. This information is 
                    ' captured later in the process.
                    If p.Name <> "InnerException" And p.Name <> "StackTrace" Then
                        If p.GetValue(currentException, Nothing) Is Nothing Then
                            strInfo.AppendFormat("{0}{1}: NULL", Environment.NewLine, p.Name)
                        Else
                            ' Loop through the collection of AdditionalInformation if the exception type is a BaseApplicationException.
                            If p.Name = "AdditionalInformation" And TypeOf currentException Is BaseApplicationException _
                                Then
                                ' Verify the collection is not null.
                                If Not (p.GetValue(currentException, Nothing) Is Nothing) Then
                                    ' Cast the collection into a local variable.
                                    currentAdditionalInfo =
                                        CType(p.GetValue(currentException, Nothing), NameValueCollection)

                                    ' Check if the collection contains values.
                                    If currentAdditionalInfo.Count > 0 Then
                                        strInfo.AppendFormat("{0}AdditionalInformation:", Environment.NewLine)

                                        ' Loop through the collection adding the information to the string builder.
                                        k = currentAdditionalInfo.Count - 1
                                        For j = 0 To k
                                            strInfo.AppendFormat("{0}{1}: {2}", Environment.NewLine,
                                                                  currentAdditionalInfo.GetKey(j),
                                                                  currentAdditionalInfo(j))
                                        Next
                                    End If
                                End If
                                ' Otherwise just write the ToString() value of the property.
                            Else
                                strInfo.AppendFormat("{0}{1}: {2}", Environment.NewLine, p.Name,
                                                      p.GetValue(currentException, Nothing))
                            End If
                        End If
                    End If
                Next p

                ' Record the StackTrace with separate label.
                If Not (currentException.StackTrace Is Nothing) Then '
                    strInfo.AppendFormat("{0}{0}StackTrace Information{0}{1}", Environment.NewLine, TEXT_SEPARATOR)
                    strInfo.AppendFormat("{0}{1}", Environment.NewLine, currentException.StackTrace)
                End If

                ' Reset the temp exception object and iterate the counter.
                currentException = currentException.InnerException
                intExceptionCount += 1
            Loop While Not (currentException Is Nothing)
        End If
        '

        ' Write the entry to the event log.   
        WriteToLog(strInfo.ToString(), EventLogEntryType.Error)
    End Sub

    'Publish


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Helper function to write an entry to the Event Log.
    ''' </summary>
    ''' <param name="entry"></param>
    ''' <param name="type"></param>
    ''' <remarks>entry - The entry to enter into the Event Log.<br/>
    ''' type - The EventLogEntryType to be used when the entry is logged to the Event Log.
    ''' </remarks>
    ''' <history>
    ''' 	[patrick]	2005/01/04	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub WriteToLog(ByVal entry As String, ByVal type As EventLogEntryType)
        Try
            ' Write the entry to the Event Log.
            Const ENTRY_LENGTH As Integer = 32766
            If entry.Length > ENTRY_LENGTH Then
                Dim newEntry As String = String.Empty
                Do While entry.Length > 0
                    If entry.Length > ENTRY_LENGTH Then
                        newEntry = entry.Substring(0, ENTRY_LENGTH)
                        entry = entry.Substring(ENTRY_LENGTH)
                    Else
                        newEntry = entry
                        entry = ""
                    End If
                    EventLog.WriteEntry(applicationName, newEntry, type)
                Loop
            Else
                EventLog.WriteEntry(applicationName, entry, type)
            End If
        Catch e As SecurityException
            Throw _
                New SecurityException(
                                       String.Format(
                                                      m_resourceManager.GetString(
                                                                                   "RES_DEFAULTPUBLISHER_EVENTLOG_DENIED"),
                                                      applicationName), e)
        End Try
    End Sub

    'WriteToLog

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    '''  Determines whether an event source is registered on the local computer.   
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[patrick]	2005/01/04	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub VerifyValidSource()
        Try
            If Not EventLog.SourceExists(applicationName) Then
                EventLog.CreateEventSource(applicationName, logName)
            End If
        Catch e As SecurityException
            Throw _
                New SecurityException(
                                       String.Format(
                                                      m_resourceManager.GetString(
                                                                                   "RES_DEFAULTPUBLISHER_EVENTLOG_DENIED"),
                                                      applicationName), e)
        End Try
    End Sub
End Class

'DefaultPublisher

#End Region