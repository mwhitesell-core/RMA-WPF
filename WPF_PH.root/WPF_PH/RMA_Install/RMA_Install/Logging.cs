using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Configuration;
using System.Net;
using System.IO;

namespace RMA_Install
{
    class Logging
    {
        /// <summary>
        /// Logs errors\confirmation\status messages about calling operations.
        /// </summary>
        /// <param name="message">Message to be logged</param>
        static public void Log(string message)
        {
            LogInFile(message);
            //Mail(message);
        }
        
        /// <summary>
        /// Logs in file (See config file for some values).
        /// </summary>
        /// <param name="message">Message to be logged.</param>
        static private void LogInFile(string message)
        {
            File.AppendAllText(ConfigurationSettings.AppSettings["LogFilePath"], message + "\r\n");
            //try
            //{
            //    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ConfigurationSettings.AppSettings["LogFilePath"]);
            //    request.Method = WebRequestMethods.Ftp.UploadFile;
            //    request.Credentials = new NetworkCredential("RamyM", "HM3qJw4N0h", "WorkFlowSrv");
            //    Stream ftpStrem = request.GetRequestStream();

            //    int length = 1024;
            //    byte[] buffer = new byte[length];
            //    ftpStrem.Write(new ASCIIEncoding().GetBytes(message), 0,
            //        new ASCIIEncoding().GetBytes(message).Length);
            //    ftpStrem.Close();

            //}
            //catch (Exception er)
            //{
            //    Console.WriteLine(er.Message);
            //}
        }
    }
}
