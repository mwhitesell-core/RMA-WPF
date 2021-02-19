Imports System
Imports System.Collections.Generic
Imports System.Collections.Specialized
Imports System.Configuration
Imports System.Data
Imports System.Diagnostics
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Reflection
Imports System.Security.Cryptography
Imports System.Text
Imports System.Threading
Imports Core.DataAccess.SqlServer

Public Class ExceptionLogging

    Public Shared Function HandleException(ByVal ex As Exception) As Boolean
        ExceptionLogging.LogMessage(ExceptionLogging.FormatExceptionMessage(ex))
        Return True
    End Function

    ''' <summary>
    ''' Logs an exception message to either the database or event log if database write fails
    ''' </summary>
    ''' <param name="message"></param>
    ''' <returns></returns>       
    Public Shared Function LogMessage(ByVal message As String) As String
        Try
            Try
                ' First we try and write to the database.  If there are any issues, 
                ' then we send an email instead.
                ExceptionLogging.WriteToDatabase(message)
            Catch
                'Try
                '    ' Writing to the database has failed.  Send an email.
                '    ExceptionLogging.SendMail(message)
                'Catch
                '    ' Sending an email failed, let's log to the Event Log.
                '    ExceptionLogging.WriteToEventLog(message)
                'End Try

                ExceptionLogging.WriteToEventLog(message)

            End Try

            Return String.Empty
        Catch ex As Exception
            Return ("Error: " + ex.Message)
        End Try

    End Function

    Private Shared Sub WriteToEventLog(ByVal message As String)
        Dim configurationItems = CType(ConfigurationManager.GetSection("appSettings"), NameValueCollection)
        Dim source As String = configurationItems("EventLogSource")
        EventLog.WriteEntry(source, message, EventLogEntryType.Error)
    End Sub

    Private Shared Sub SendMail(ByVal message As String)
        Dim configurationItems = CType(ConfigurationManager.GetSection("appSettings"), NameValueCollection)
        Dim host As String = configurationItems("SmtpHost")
        Dim port As Integer = Convert.ToInt32(configurationItems("SmtpPort"))
        Dim user As String = configurationItems("SmtpUser")
        Dim pswd As String = configurationItems("SmtpPswd")
        Dim emailTo As String = configurationItems("SupportEmail")
        Dim emailFrom As String = configurationItems("SmtpEmail")
        Dim subjectStart As String = configurationItems("SubjectStart")
        Dim bodyStart As String = configurationItems("BodyStart")
        ' Create the mail message
        Dim mail As MailMessage = New MailMessage()
        mail.From = New MailAddress(emailFrom)
        ' Set the addresses
        mail.To.Add(emailTo)
        ' Set the content
        mail.Subject = (subjectStart + DateTime.Now)
        mail.Body = (bodyStart + message)
        ' Send the message
        Dim smtp = New SmtpClient(host, port)
        smtp.Send(mail)
    End Sub

    Private Shared Key As Byte() = {23, 22, 86, 33, 11, 3,
   67, 21, 21, 53, 8, 98,
   249, 43, 98, 103, 38, 104,
   105, 43, 222, 34, 45, 89}

    Private Shared Iv As Byte() = {45, 11, 45, 37, 42, 68,
        102, 79}

    Private Shared Function ConnectionStringDecrypt(ConnectionString As String) As String
      
        Dim password As String = ConnectionString.Substring(ConnectionString.ToUpper().IndexOf("PASSWORD") + 8)
        password = password.Substring(password.IndexOf("=") + 1)
        password = password.Substring(0, password.IndexOf(";"))

        Return ConnectionString.Replace(password, Decrypt(password))
    End Function

    Private Shared Function Decrypt(EncryptedString As String) As String
        ' UTFEncoding is used to transform the decrypted Byte Array 
        ' information back into a string. 
        Dim utf8encoder = New UTF8Encoding()
        Dim tdesProvider = New TripleDESCryptoServiceProvider()
        Dim bytInputBytes As Byte() = Nothing
        ' As before we must provide the encryption/decryption key along with 
        ' the init vector. 
        Dim cryptoTransform As ICryptoTransform = Nothing
        cryptoTransform = tdesProvider.CreateDecryptor(Key, Iv)


        ' Provide a memory stream to decrypt information into 
        Dim decryptedStream = New MemoryStream()
        Dim cryptStream = New CryptoStream(decryptedStream, cryptoTransform, CryptoStreamMode.Write)

        bytInputBytes = Convert.FromBase64String(EncryptedString)
        cryptStream.Write(bytInputBytes, 0, bytInputBytes.Length)
        cryptStream.FlushFinalBlock()
        decryptedStream.Position = 0

        ' Read the memory stream and convert it back into a string 
        Dim result = New Byte(Convert.ToInt16(decryptedStream.Length) - 1) {}
        decryptedStream.Read(result, 0, Convert.ToInt16(decryptedStream.Length))
        cryptStream.Close()
        decryptedStream.Close()

        Return utf8encoder.GetString(result)
    End Function

    Private Shared Sub WriteToDatabase(ByVal message As String)
        Dim ConnectionString As String = ConnectionStringDecrypt(ConfigurationManager.AppSettings("LoggingConnectionString").ToString )

     

        Dim severity As String = ""
        If message.StartsWith("Logout") Then
            severity = "Logout"
        ElseIf message.StartsWith("Login") Then
            severity = "Login"
        ElseIf message.StartsWith("Upgraded") Then
            severity = "Upgraded"
        Else
            severity = "Error"
        End If

        Dim Sql = New StringBuilder("")
        Sql.Append("INSERT INTO [dbo].[Log]")
        Sql.Append("([EventID]")
        Sql.Append(",[Priority]")
        Sql.Append(",[Severity]")
        Sql.Append(",[Title]")
        Sql.Append(",[Timestamp]")
        Sql.Append(",[MachineName]")
        Sql.Append(",[AppDomainName]")
        Sql.Append(",[ProcessID]")
        Sql.Append(",[ProcessName]")
        Sql.Append(",[ThreadName]")
        Sql.Append(",[Win32ThreadId]")
        Sql.Append(",[Message]")
        Sql.Append(",[FormattedMessage])")
        Sql.Append("VALUES")
        Sql.Append("(100")
        Sql.Append(",0")
        Sql.Append(",'").Append(severity).Append("'")
        Sql.Append(",'Enterprise Library Exception Handling'")
        Sql.Append(",'").Append(DateTime.Now.ToString("s")).Append("'")
        Sql.Append(",'").Append(Process.GetCurrentProcess.MachineName).Append("'")
        Sql.Append(",'").Append((Environment.UserDomainName + ("\" + Environment.UserName))).Append("'")
        Sql.Append(",'").Append(Process.GetCurrentProcess.Id.ToString).Append("'")
        Sql.Append(",'").Append(Process.GetCurrentProcess.ProcessName).Append("'")
        Sql.Append(",null")
        Sql.Append(",'0'")
        Sql.Append(",'").Append(message.Replace("'", "").PadRight(1500, Microsoft.VisualBasic.ChrW(32)).Substring(0, 1500)).Append("'")
        Sql.Append(",'").Append(message.Replace("'", "")).Append("')")
        SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, Sql.ToString())
    End Sub

    Private Shared Function FormatExceptionMessage(ByVal ex As Exception) As String
        Dim exceptionCount As Integer = 1
        Const textSeparator As String = " "
        Dim currentException As Exception = ex
        Dim formattedMessage = New StringBuilder(String.Empty)
        Dim additionalInfo = New Dictionary(Of String, String)
        ' Set up initial information.
        additionalInfo.Add("FullName", Assembly.GetExecutingAssembly.FullName)
        additionalInfo.Add("AppDomainName", AppDomain.CurrentDomain.FriendlyName)
        additionalInfo.Add("ThreadIdentity", Thread.CurrentThread.ManagedThreadId.ToString)
        additionalInfo.Add("ThreadName", Thread.CurrentThread.Name)


        ' Write title information for the exception object.
        formattedMessage.Append(("Timestamp: " + DateTime.Now))
        formattedMessage.AppendFormat("{0}{0}{1}) Exception Information{0}{2}", "" & vbCrLf, exceptionCount, textSeparator)
        formattedMessage.AppendFormat("{0}Exception Type: {1}", "" & vbCrLf, currentException.GetType.FullName)
        ' Loop through the public properties of the exception object and record their value.
        Dim propertyInfo() As PropertyInfo = currentException.GetType.GetProperties
        For Each [property] As PropertyInfo In propertyInfo
            ' Do not log information for the InnerException or StackTrace. This information is 
            ' captured later in the process.
            If [property].Name <> "InnerException" And [property].Name <> "StackTrace" Then
                If [property].GetValue(currentException, Nothing) Is Nothing Then
                    formattedMessage.AppendFormat("{0}{1}: NULL", vbCr & vbLf, [property].Name)
                Else
                    ' Loop through the collection of AdditionalInformation if the exception type is a BaseApplicationException.
                    If [property].Name = "AdditionalInformation" AndAlso TypeOf currentException Is Exception Then
                        ' Verify the collection is not null.
                        If ([property].GetValue(currentException, Nothing) IsNot Nothing) Then
                            ' Cast the collection into a local variable.
                            'additionalInfo = DirectCast([property].GetValue(currentException, Nothing), Dictionary(Of String, String))

                            ' Check if the collection contains values.
                            If additionalInfo.Count > 0 Then
                                formattedMessage.AppendFormat("{0}AdditionalInformation:", vbCr & vbLf)

                                ' Loop through the collection adding the information to the string builder.
                                For Each info As Object In additionalInfo
                                    formattedMessage.AppendFormat("{0}{1}: {2}", vbCr & vbLf, info.Key, info.Value)
                                Next
                            End If
                        End If
                    Else
                        ' Otherwise just write the ToString() value of the property.
                        formattedMessage.AppendFormat("{0}{1}: {2}", vbCr & vbLf, [property].Name, [property].GetValue(currentException, Nothing))
                    End If
                End If
            End If
        Next

        ' Record the StackTrace with separate label.
        If (Not (currentException.StackTrace) Is Nothing) Then
            '
            formattedMessage.AppendFormat("{0}{0}StackTrace Information{0}{1}", "" & vbCrLf, textSeparator)
            formattedMessage.AppendFormat("{0}{1}", "" & vbCrLf, currentException.StackTrace)
        End If

        ' Reset the temp exception object and iterate the counter.
        currentException = currentException.InnerException
        exceptionCount = (exceptionCount + 1)



        Dim errorSummary As String = String.Empty
        Try
            errorSummary = ex.ToString
        Catch e As Exception
            ' ignore
        End Try

        ' Return the formatted message.
        Return (formattedMessage.ToString & ("" & vbCrLf & errorSummary))
    End Function

    Public Shared Sub GenerateLogRecord(ByVal batch_logfile As String, ByVal value As String, ByVal batch_version As String)
        Dim sw = New StreamWriter(batch_logfile, True, Encoding.Default)
        Dim fail As Boolean = False
        Dim i As Integer = 0
        Do While (i < 9999)
            fail = False
            Try
                sw.WriteLine((batch_version + (" (" _
                                + (DateTime.Now + ("): " + value)))))
            Catch
                fail = True
            End Try

            If (fail = False) Then
                sw.Flush
                sw.Close
                sw.Dispose
                Exit Do
            End If

            i = (i + 1)
        Loop

    End Sub
End Class
