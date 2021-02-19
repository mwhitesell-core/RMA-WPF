using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading;


namespace Core.Exceptions
{
    public static class ExceptionLogging
    {
        public static bool HandleException(Exception ex)
        {
            LogMessage(FormatExceptionMessage(ex));
            return true;
        }

        /// <summary>
        /// Logs an exception message to either the database or event log if database write fails
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>       
        public static string LogMessage(string message)
        {
            try
            {
                try
                {
                    // First we try and write to the database.  If there are any issues, 
                    // then we send an email instead.
                    WriteToDatabase(message);
                }
                catch
                {
                    try
                    {
                        // Writing to the database has failed.  Send an email.
                        SendMail(message);
                    }
                    catch
                    {
                        // Sending an email failed, let's log to the Event Log.
                        WriteToEventLog(message);
                    }
                }

                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        private static void WriteToEventLog(string message)
        {
            var configurationItems = (NameValueCollection) ConfigurationManager.GetSection("appSettings");
            string source = configurationItems["EventLogSource"];
            EventLog.WriteEntry(source, message, EventLogEntryType.Error);
        }

        private static void SendMail(string message)
        {
            var configurationItems = (NameValueCollection) ConfigurationManager.GetSection("appSettings");
            string host = configurationItems["SmtpHost"];
            int port = Convert.ToInt32(configurationItems["SmtpPort"]);
            string user = configurationItems["SmtpUser"];
            string pswd = configurationItems["SmtpPswd"];
            string emailTo = configurationItems["SupportEmail"];
            string emailFrom = configurationItems["SmtpEmail"];
            string subjectStart = configurationItems["SubjectStart"];
            string bodyStart = configurationItems["BodyStart"];

            // Create the mail message
            var mail = new MailMessage {From = new MailAddress(emailFrom)};

            // Set the addresses
            mail.To.Add(emailTo);

            // Set the content
            mail.Subject = subjectStart + DateTime.Now;
            mail.Body = bodyStart + message;

            // Send the message
            var smtp = new SmtpClient(host, port) {Credentials = new NetworkCredential(user, pswd)};
            smtp.Send(mail);
        }

        private static void WriteToDatabase(string message)
        {
            string ConnectionString;// = DALState.Current.LoggingConnection;
            string severity = "";
            if (message.StartsWith("Logout"))
                severity = "Logout";
            else if (message.StartsWith("Login"))
                severity = "Login";
            else if (message.StartsWith("Upgraded"))
                severity = "Upgraded";
            else
                severity = "Error";
            var Sql = new StringBuilder("");
            Sql.Append("INSERT INTO [dbo].[Log]");
            Sql.Append("([EventID]");
            Sql.Append(",[Priority]");
            Sql.Append(",[Severity]");
            Sql.Append(",[Title]");
            Sql.Append(",[Timestamp]");
            Sql.Append(",[MachineName]");
            Sql.Append(",[AppDomainName]");
            Sql.Append(",[ProcessID]");
            Sql.Append(",[ProcessName]");
            Sql.Append(",[ThreadName]");
            Sql.Append(",[Win32ThreadId]");
            Sql.Append(",[Message]");
            Sql.Append(",[FormattedMessage])");
            Sql.Append("VALUES");
            Sql.Append("(100");
            Sql.Append(",0");
            Sql.Append(",'").Append(severity).Append("'");
            Sql.Append(",'Enterprise Library Exception Handling'");
            Sql.Append(",'").Append(DateTime.Now.ToString("s")).Append("'");
            Sql.Append(",'").Append(Process.GetCurrentProcess().MachineName).Append("'");
            Sql.Append(",'").Append(Environment.UserDomainName + "\\" + Environment.UserName).Append("'");
            Sql.Append(",'").Append(Process.GetCurrentProcess().Id.ToString()).Append("'");
            Sql.Append(",'").Append(Process.GetCurrentProcess().ProcessName).Append("'");
            Sql.Append(",null");
            Sql.Append(",'0'");
            Sql.Append(",'").Append(message.Replace("'", "").PadRight(1500, ' ').Substring(0, 1500)).Append("'");
            Sql.Append(",'").Append(message.Replace("'", "")).Append("')");

            //SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, Sql.ToString());
        }

        private static string FormatExceptionMessage(Exception ex)
        {
            int exceptionCount = 1;
            const string textSeparator = " ";
            Exception currentException = ex;
            var formattedMessage = new StringBuilder(string.Empty);
            var additionalInfo = new Dictionary<string, string>();

            // Set up initial information.
            additionalInfo.Add("FullName", Assembly.GetExecutingAssembly().FullName);
            additionalInfo.Add("AppDomainName", AppDomain.CurrentDomain.FriendlyName);
            additionalInfo.Add("ThreadIdentity", Thread.CurrentThread.ManagedThreadId.ToString());
            additionalInfo.Add("ThreadName", Thread.CurrentThread.Name);

            do
            {
                // Write title information for the exception object.
                formattedMessage.Append("Timestamp: " + DateTime.Now);
                formattedMessage.AppendFormat("{0}{0}{1}) Exception Information{0}{2}", "\r\n", exceptionCount,
                                              textSeparator);
                formattedMessage.AppendFormat("{0}Exception Type: {1}", "\r\n", currentException.GetType().FullName);

                // Loop through the public properties of the exception object and record their value.
                PropertyInfo[] propertyInfo = currentException.GetType().GetProperties();

                foreach (PropertyInfo property in propertyInfo)
                {
                    // Do not log information for the InnerException or StackTrace. This information is 
                    // captured later in the process.
                    if (property.Name != "InnerException" & property.Name != "StackTrace")
                    {
                        if (property.GetValue(currentException, null) == null)
                        {
                            formattedMessage.AppendFormat("{0}{1}: NULL", "\r\n", property.Name);
                        }
                        else
                        {
                            // Loop through the collection of AdditionalInformation if the exception type is a BaseApplicationException.
                            if (property.Name == "AdditionalInformation" && currentException is Exception)
                            {
                                // Verify the collection is not null.
                                if ((property.GetValue(currentException, null) != null))
                                {
                                    // Cast the collection into a local variable.
                                    additionalInfo =
                                        (Dictionary<string, string>) property.GetValue(currentException, null);

                                    // Check if the collection contains values.
                                    if (additionalInfo.Count > 0)
                                    {
                                        formattedMessage.AppendFormat("{0}AdditionalInformation:", "\r\n");

                                        // Loop through the collection adding the information to the string builder.
                                        foreach (var info in additionalInfo)
                                        {
                                            formattedMessage.AppendFormat("{0}{1}: {2}", "\r\n", info.Key, info.Value);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                // Otherwise just write the ToString() value of the property.
                                formattedMessage.AppendFormat("{0}{1}: {2}", "\r\n", property.Name,
                                                              property.GetValue(currentException, null));
                            }
                        }
                    }
                }

                // Record the StackTrace with separate label.
                if ((currentException.StackTrace != null))
                {
                    //
                    formattedMessage.AppendFormat("{0}{0}StackTrace Information{0}{1}", "\r\n", textSeparator);
                    formattedMessage.AppendFormat("{0}{1}", "\r\n", currentException.StackTrace);
                }

                // Reset the temp exception object and iterate the counter.
                currentException = currentException.InnerException;
                exceptionCount += 1;
            } while ((currentException != null));

            // get summary, if possible
            string errorSummary = string.Empty;
            try
            {
                errorSummary = ex.ToString();
            }
            catch (Exception)
            {
                // ignore
            }

            // Return the formatted message.
            return formattedMessage + "\r\n" + errorSummary;
        }

        public static void GenerateLogRecord(string batch_logfile, string value, string batch_version)
        {
            var sw = new StreamWriter(batch_logfile, true, Encoding.Default);
            bool fail = false;

            for (int i = 0; i < 9999; i++)
            {
                fail = false;

                try
                {
                    sw.WriteLine(batch_version + " (" + DateTime.Now + "): " + value);
                }
                catch
                {
                    fail = true;
                }

                if (fail == false)
                {
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                    break;
                }
            }
        }
    }


}