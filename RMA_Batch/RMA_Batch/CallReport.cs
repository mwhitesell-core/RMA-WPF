
using Core.DataAccess.Oracle;
using Core.DataAccess.SqlServer;
using Core.Framework;
using Core.Framework.Core.Framework;
using Pdf2Text;

using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml;

public class CallReport : System.Web.Services.WebService
{

    #region " Variable Declarations "

    public Boolean IsMP = false;
    private string m_strSessionId;
    private string m_strSQL;
    private string m_strConnString;
    private string m_strDatabaseType;
    private string m_strDefaultSchema;

    private string m_strReportDir;
    private string m_strReportAssemblyPath;
    private string m_strDeployedReportURL;

    private string m_strReport;
    private string m_strReportCompletionPath;
    private string[] m_astrScreenParameters;

    private stcReportParameters m_astrParameters;
    private RMA_Batch.RS2005.ParameterValue[] m_RS_Parameters;

    private RMA_Batch.RE2005.ParameterValue[] m_RES_Parameters;
    private string m_strReportId;
    private string m_strProgramName;
    private string m_strReportTitle;
    private string m_strReportFileName;
    private string m_strReportFormat;
    private string m_strReportLanguage;
    private string m_strReportRunBy;

    private string m_strReportIdentifier;
    private string m_strAcctName;

    private string m_strAcctPassword;
    private System.DateTime m_dtReportRunDate;

    private System.DateTime m_dtReportRunTime;

    private double m_dtReportProcessTime;

    public const string cPDF = ".pdf";
    public const string cHTML = ".html";
    public const string cXLS = ".xls";
    public const string cRTF = ".rtf";

    public const string cLOG = ".log";
    public const string cREPORT_GENERATING = "0001";

    public const string cREPORT_COMPLETED = "0002";
    public const string cDRAFT = "0001";

    public const string cFINAL = "0002";

    public const string cCORE_SETTINGS = "coreSettings/projects/";
    public const string cCOMPLETED_REPORTS_DIR = "Reports";

    public const string cCOMPLETED_LOG_DIR = "Logs\\";

    public const string cWEBSERVICE_LOG_DIR = "rptLogs\\";
    public const string cREPORT_SCHEDULE_PATH = "rptSchedule\\";

    public const string cREPORT_SCHEDULE_PROGRAM = "CreateReport.exe";

    public const string cREPORT_FRAMEWORK = "Core.ReportFramework.dll";
    public const string cWEBSERVICE_LOG_NAME = "WebService.log";
    public const string cPREVIEW_LOG_NAME = "PreviewReport.log";
    public const string cSCHEDULE_LOG_NAME = "ScheduleReport.log";

    public const string cRUN_LOG_NAME = "RunReport.log";
    public string strCompletedReportsRoot;
    public string strReportCollectionRoot;

    public string strReportMessageQueue;

    public string strReportUsersDir;
    public string strAppErrorLog;
    public string strErrorLogPath;

    // Structure to hold Report parameters sent from application to webservice/report.
    public struct stcReportParameters
    {
        public string strSessionId;
        public string strDatabaseType;
        public string strConnString;
        public string strDefaultSchema;
        public string strDeployedReportURL;
        public string strReportCompletionPath;
        public string[] astrScreenParameters;
        public string strReportId;
        public string strReportFileName;
        public string strReportTitle;
        public string strReportIdentifier;
        public string strReportFormat;
        public string strReportLanguage;
        public string strReportRunBy;
        public System.DateTime dtReportRunDate;
        public System.DateTime dtReportRunTime;
        public double dtReportProcessTime;
    }

    public struct stcReportControls
    {
        public stcReportControl[] arrReportControls;
    }

    public struct stcReportControl
    {
        public string Format;
        public string Name;
        public string Range;
        public ShiftTypes ShiftType;
        public int Size;
        public DataTypes Type;
    }

    #endregion

    #region " Run and Schedule Reports "

    public bool RunReport(stcReportParameters stcParameters, string strProjectName)
    {
        byte[] arrReport = null;
        bool blnSuccess = false;
        double dtTime = 0;
        DateTime dtNow;
        string strExtension = string.Empty;


        try
        {
            SetParameters(stcParameters);

            // Get the present date and time.
            dtNow = DateTime.Now;
            dtTime = Convert.ToDouble(dtNow.Hour.ToString("00") + dtNow.Minute.ToString("00") + dtNow.Second.ToString("00"));

            //if (SetupReport(dtTime))
            //{
            RenderReport(arrReport, strProjectName);
            //}
        }

        catch (SoapException e)
        {
            blnSuccess = false;
        }

        catch (Exception ex)
        {

            blnSuccess = false;
        }

        finally
        {

        }

        return blnSuccess;
    }

    protected virtual bool IsFileLocked(FileInfo file)
    {
        FileStream stream = null;

        try
        {
            stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
        }

        catch (IOException)
        {
            return true;
        }

        finally
        {
            if (stream != null)
                stream.Close();
        }

        //file is not locked
        return false;
    }

    private bool RenderReport(byte[] arrReport, string strProjectName)
    {
        // Render arguments
        RMA_Batch.RE2005.ReportExecutionService res = new RMA_Batch.RE2005.ReportExecutionService();
        RMA_Batch.RS2005.ReportingService2005 rs = new RMA_Batch.RS2005.ReportingService2005();
        RMA_Batch.RE2005.Warning[] warnings = null;
        RMA_Batch.RE2005.ExecutionInfo execInfo = new RMA_Batch.RE2005.ExecutionInfo();
        RMA_Batch.RE2005.ExecutionHeader execHeader = new RMA_Batch.RE2005.ExecutionHeader();

        bool blnSuccess = false;

        double dtTime = 0;

        string[] streamIDs = null;

        string devInfo = "<DeviceInfo><Toolbar>False</Toolbar></DeviceInfo>";
        string encoding = string.Empty;
        string extension = string.Empty;
        string format = string.Empty;
        string historyID = null;
        string mimeType = string.Empty;
        string SessionId = string.Empty;
        string strExtension = string.Empty;
        string reportName = string.Empty;
        string reportPath = string.Empty;
        string rdlName = string.Empty;
        string formfeed = string.Empty;

        try
        {
            arrReport = null;

            res.Credentials = System.Net.CredentialCache.DefaultCredentials;
            res.Url = ConfigurationManager.AppSettings["RE2005"];

            rs.Credentials = System.Net.CredentialCache.DefaultCredentials;
            rs.Url = ConfigurationManager.AppSettings["RS2005"];

            // Determine the location of the Report dll to run.
            // Return a list of catalog items in the report server database
            RMA_Batch.RS2005.CatalogItem[] items = rs.ListChildren("/", true);

            if (Environment.GetEnvironmentVariable("RMABILL_VERS", EnvironmentVariableTarget.Process).ToUpper() == "MP")
            {
                foreach (RMA_Batch.RS2005.CatalogItem c in items)
                {
                    if (c.Type == RMA_Batch.RS2005.ItemTypeEnum.Report)
                    {
                        if (c.Name.ToUpper() == "MP_" + m_strReportId.ToUpper())
                        {
                            m_strDeployedReportURL = c.Path;
                            IsMP = true;

                            break;
                        }
                    }
                }

            }

            if (m_strDeployedReportURL.IndexOf(m_strReportId.ToUpper()) == -1)
                {

                foreach (RMA_Batch.RS2005.CatalogItem c in items)
                {
                    if (c.Type == RMA_Batch.RS2005.ItemTypeEnum.Report)
                    {
                        if (c.Name.ToUpper() == m_strReportId.ToUpper())
                        {
                            m_strDeployedReportURL = c.Path;
                            break;
                        }
                    }
                }
            }
            execInfo = res.LoadReport(m_strDeployedReportURL, historyID);

            // Set report parameters being passed to the report.
            int parmlength = execInfo.Parameters.Length;
            SetReportParameterValues(m_astrScreenParameters, ref parmlength);
            res.SetExecutionParameters(m_RES_Parameters, "en-us");

            SessionId = res.ExecutionHeaderValue.ExecutionID;
            execInfo = res.GetExecutionInfo();

            format = GetRenderFormat();
            res.Timeout = 999999999;

            arrReport = res.Render(format, devInfo, out extension, out mimeType, out encoding, out warnings, out streamIDs);

            reportName = m_strReportFileName;
            reportPath = Directory.GetCurrentDirectory();

            if (!reportPath.Trim().EndsWith("\\"))
            {
                reportPath += "\\";
            }

            switch (m_strReportFormat)
            {
                case "":
                case "PDF":
                    strExtension = ".pdf";
                    m_strReport = reportPath + reportName + strExtension;

                    using (FileStream stream = new FileStream(m_strReport, FileMode.Create, FileAccess.ReadWrite, FileShare.None, arrReport.Length))
                    {
                        stream.Write(arrReport, 0, arrReport.Length);
                        stream.Close();
                        stream.Dispose();
                    }
                    break;

                case "EXCEL":
                    strExtension = ".xls";
                    break;

                case "TXT":
                    strExtension = ".pdf";
                    m_strReport = reportPath + reportName + strExtension;

                    FileStream strm = File.Create(m_strReport, arrReport.Length);
                    strm.Write(arrReport, 0, arrReport.Length);
                    strm.Close();

                    if (System.Configuration.ConfigurationManager.AppSettings["UseBitMiracle"] == null || System.Configuration.ConfigurationManager.AppSettings["UseBitMiracle"].ToString().ToUpper() == "FALSE")
                    {
                        Pdf2Text.Pdf2Text.Convert(m_strReport);
                    }
                    else
                    {
                        ProcessStartInfo startInfo = new ProcessStartInfo();
                        startInfo.FileName = "Core.PDFToText.exe";
                        startInfo.Arguments = m_strReport + " " + "true";


                        if (QDesign.NULL(reportName).IndexOf("spool_file") == -1)
                        {
                            startInfo.WorkingDirectory = reportPath;
                        }
                        else
                        {
                            startInfo.WorkingDirectory = m_strReportCompletionPath;
                        }

                        startInfo.RedirectStandardOutput = true;
                        startInfo.RedirectStandardError = true;
                        startInfo.CreateNoWindow = true;
                        startInfo.UseShellExecute = false;
                        startInfo.WindowStyle = ProcessWindowStyle.Hidden;

                        try
                        {
                            using (Process exeProcess = Process.Start(startInfo))
                            {
                                exeProcess.WaitForExit();
                            }
                        }

                        catch (SoapException e)
                        {
                            blnSuccess = false;
                        }

                        catch (Exception ex)
                        {
                            blnSuccess = false;
                        }
                    }

                    break;

                default:
                    strExtension = "";
                    break;
            }



            // Update database to show report has been generated.
            //if (UpdateReport(false, dtTime))
            //{
            blnSuccess = true;
            //}
        }

        catch (Exception ex)
        {


            execInfo = null;
            res = null;
            rs = null;

            blnSuccess = false;
        }



        execInfo = null;
        res = null;
        rs = null;

        return blnSuccess;

    }

    #endregion

    #region " Report Utilities "

    #region " Report Set Methods "


    private void SetParameters(stcReportParameters stcParameters)
    {
        try
        {
            stcReportParameters _with1 = stcParameters;
            // Application settings.
            m_strSessionId = _with1.strSessionId;
            m_strDatabaseType = _with1.strDatabaseType;
            m_strConnString = _with1.strConnString;
            m_strDefaultSchema = _with1.strDefaultSchema;
            m_strDeployedReportURL = _with1.strDeployedReportURL;
            m_strReportCompletionPath = _with1.strReportCompletionPath;

            // Specific user input for desired report.
            m_astrScreenParameters = _with1.astrScreenParameters;

            // Report specific information.
            m_strReportId = _with1.strReportId;
            m_strReportFileName = _with1.strReportFileName;
            m_strReportFormat = _with1.strReportFormat;
            m_strReportTitle = _with1.strReportTitle;
            m_strReportIdentifier = _with1.strReportIdentifier;
            m_strReportLanguage = _with1.strReportLanguage;
            m_strReportRunBy = _with1.strReportRunBy;
            m_dtReportRunTime = _with1.dtReportRunTime;
            m_dtReportRunDate = _with1.dtReportRunDate;

            // This time is used when report is scheduled. It represents
            // the time the report was scheduled not when it actually ran.
            m_dtReportProcessTime = _with1.dtReportProcessTime;

        }
        catch (Exception ex)
        {

        }

    }


    private void SetReportParameterValues(string[] astrParameters, ref int intNumberOfReportParms)
    {
        RMA_Batch.RE2005.ParameterValue[] parameters;
        if (astrParameters == null)
        {
            parameters = new RMA_Batch.RE2005.ParameterValue[6];
        }
        else
        {
            parameters = new RMA_Batch.RE2005.ParameterValue[astrParameters.Length + 6];
        }


        try
        {
            int intCount = 6;
            int intParameters = 6;

            // Default report parameters.
            parameters[0] = new RMA_Batch.RE2005.ParameterValue();
            parameters[0].Name = "SESSION_ID";
            parameters[0].Value = "1";

            // Default report parameters.
            parameters[1] = new RMA_Batch.RE2005.ParameterValue();
            parameters[1].Name = "DEFAULT_SCHEMA";
            parameters[1].Value = m_strDefaultSchema;

            // Default report parameters.
            parameters[2] = new RMA_Batch.RE2005.ParameterValue();
            parameters[2].Name = "LANGUAGE";
            parameters[2].Value = m_strReportLanguage;

            // Default report parameters.
            parameters[3] = new RMA_Batch.RE2005.ParameterValue();
            parameters[3].Name = "REPORTED_BY";
            parameters[3].Value = "Admin";

            // Default report parameters.
            parameters[4] = new RMA_Batch.RE2005.ParameterValue();
            parameters[4].Name = "CURRENTDIRECTORY";
            parameters[4].Value = Directory.GetCurrentDirectory();

            parameters[5] = new RMA_Batch.RE2005.ParameterValue();
            parameters[5].Name = "CONNECTSTRING";
            parameters[5].Value = Common.GetSqlConnectionString();

            if (intNumberOfReportParms > 6)
            {
                if (astrParameters != null)
                {
                    foreach (string value in astrParameters)
                    {
                        if (value != null)
                        {
                            parameters[intCount] = new RMA_Batch.RE2005.ParameterValue();
                            parameters[intCount].Name = "PARM_" + (intCount - 5).ToString();
                            parameters[intCount].Value = value;

                            intParameters += 1;
                            intCount += 1;
                        }
                    }
                }
            }

            Array.Resize(ref parameters, intParameters);

        }
        catch (Exception ex)
        {
        }

        m_RES_Parameters = parameters;

    }






    #endregion

    #region " Report Get Methods "

    public string GetRenderFormat()
    {

        if (m_strReportFormat != string.Empty)
        {
            if (m_strReportFormat != "TXT")
            {
                if (m_strReportFormat.StartsWith("."))
                {
                    return m_strReportFormat.Substring(1).ToUpper();
                }
                else
                {
                    return m_strReportFormat.ToUpper();
                }
            }
            else
            {
                return "PDF";
            }
        }
        else
        {
            return "PDF";
            // Default export format.
        }

        //if (m_strReportFormat != string.Empty)
        //{
        //    if (m_strReportFormat.StartsWith("."))
        //    {
        //        if (m_strReportFormat.Substring(1).ToUpper() == "TXT")
        //        {
        //            return "PDF";
        //        }
        //        else
        //        {
        //            return m_strReportFormat.Substring(1).ToUpper();
        //        }
        //    }
        //    else
        //    {
        //        if (m_strReportFormat.ToUpper() == "TXT")
        //        {
        //            return "PDF";
        //        }
        //        else
        //        {
        //            return m_strReportFormat.ToUpper();
        //        }
        //    }
        //}
        //else
        //{
        //    return "PDF";
        //    // Default export format.
        //}

    }








    [WebMethod(Description = " Retrieves the URL of the configured ReportServer. ")]
    public string GetReportServerUrl(string strProjectName)
    {

        string strURL = string.Empty;
        string RS_Url = string.Empty;

        NameValueCollection nvcProjectSettings = null;

        try
        {
            nvcProjectSettings = (NameValueCollection)System.Configuration.ConfigurationManager.GetSection(cCORE_SETTINGS + strProjectName);

            RS_Url = nvcProjectSettings["ReportService2005.ReportService2005"];

            if (RS_Url.EndsWith(".asmx"))
            {
                strURL = RS_Url.Substring(0, RS_Url.LastIndexOf("\\"));
            }
            else
            {
                strURL = RS_Url;
            }

        }
        catch (Exception ex)
        {


        }

        return strURL;

    }

    public string GetUsersDir()
    {
        string functionReturnValue = null;

        string strUsersDir = string.Empty;
        bool blnCreate = false;

        try
        {
            // Determine the path of where the user can store their reports.
            if (!m_strReportCompletionPath.EndsWith("\\"))
            {
                // Add a \ to path if not present as last character.
                strUsersDir = m_strReportCompletionPath + "\\" + m_strReportRunBy.ToUpper();
            }
            else
            {
                strUsersDir = m_strReportCompletionPath + m_strReportRunBy.ToUpper();
            }

            // If this is the first report generated by the user then create the Directory.
            if (!Directory.Exists(strUsersDir))
            {
                blnCreate = CreateUsersDir(strUsersDir);
                if (!blnCreate)
                {
                    functionReturnValue = "";
                    return functionReturnValue;
                }
            }

            // Add a \ to path if not present as last character.
            if (!strUsersDir.EndsWith("\\"))
            {
                strUsersDir = strUsersDir + "\\";
            }

        }
        catch (Exception ex)
        {

        }

        return strUsersDir;
        return functionReturnValue;

    }



    public string GetCompletedReportPath()
    {

        string strReportPath = string.Empty;

        try
        {
            strReportPath = GetUsersDir() + cCOMPLETED_REPORTS_DIR;

        }
        catch (Exception ex)
        {

        }

        return strReportPath;

    }

    #endregion




    private bool SetupReport(double dtTime)
    {

        int intRetVal = 0;
        bool blnSuccess = false;

        StringBuilder strSQL = new StringBuilder(string.Empty);

        try
        {
            blnSuccess = false;

            strSQL.Append("INSERT INTO ").Append(m_strDefaultSchema).Append(".dbo.RENAISSANCE_REPORTS (");
            strSQL.Append("run_by, run_date, run_time, report_id, report_title, report_file_name, report_format, ");
            strSQL.Append("draft_flag, report_status) ");
            strSQL.Append("VALUES (");
            strSQL.Append("'" + (m_strReportRunBy.Trim())).Append("', ");
            strSQL.Append("'" + (m_dtReportRunDate.ToString("dd-MMM-yy"))).Append("', ");
            strSQL.Append(dtTime).Append(", ");
            strSQL.Append("'" + (m_strReportId)).Append("', ");
            strSQL.Append(Common.StringToField(m_strReportTitle)).Append(", ");
            strSQL.Append(Common.StringToField(m_strReportFileName)).Append(", ");
            strSQL.Append(Common.StringToField(m_strReportFormat)).Append(", ");
            strSQL.Append(Common.StringToField(cFINAL)).Append(", ");
            strSQL.Append(Common.StringToField(cREPORT_GENERATING)).Append(")");

            intRetVal = SqlHelper.ExecuteNonQuery(m_strConnString, CommandType.Text, strSQL.ToString());

            blnSuccess = true;
        }

        catch (Exception ex)
        {
            blnSuccess = false;
        }

        finally
        {
            strSQL = null;
        }

        return blnSuccess;

    }

    private bool UpdateReport(bool blnScheduledReport, double dtRunTime)
    {

        bool blnSuccess = false;
        int intNumOfRows = 0;

        System.DateTime dtNow = default(System.DateTime);
        System.DateTime dtRunDate = default(System.DateTime);

        StringBuilder strSQL = new StringBuilder("");
        StringBuilder strReportPath = new StringBuilder("");

        try
        {
            blnSuccess = false;

            // The current date.
            dtNow = System.DateTime.Now;

            // The date when the generation of the report was initiated.
            dtRunDate = new System.DateTime(m_dtReportRunDate.Ticks);

            intNumOfRows = 0;



            strSQL.Append("UPDATE ").Append(m_strDefaultSchema).Append(".dbo.RENAISSANCE_REPORTS");



            strSQL.Append(" SET report_status = ").Append(Common.StringToField(cREPORT_COMPLETED));
            strSQL.Append(", run_date = ").Append(Common.StringToField(dtNow.Date.ToString("dd-MMM-yy")));
            strSQL.Append(", run_time = ").Append(Common.StringToField(dtNow.Hour.ToString("00") + dtNow.Minute.ToString("00") + dtNow.Second.ToString("00")));
            strSQL.Append(", report_format = ").Append(Common.StringToField(m_strReportFormat));
            strSQL.Append(" WHERE run_by = ").Append(Common.StringToField(m_strReportRunBy));
            strSQL.Append(" AND run_date = ").Append(Common.StringToField(dtRunDate.Date.ToString("dd-MMM-yy")));

            if (blnScheduledReport)
            {
                strSQL.Append(" AND run_time = ").Append(Common.StringToField(m_dtReportProcessTime.ToString()));
            }
            else
            {
                strSQL.Append(" AND run_time = ").Append(Common.StringToField(dtRunTime.ToString()));
            }

            switch (m_strDatabaseType)
            {
                case Common.cORACLE:
                    intNumOfRows = OracleHelper.ExecuteNonQuery(m_strConnString, CommandType.Text, strSQL.ToString());

                    break;
                case Common.cSQL_SERVER:
                    intNumOfRows = SqlHelper.ExecuteNonQuery(m_strConnString, CommandType.Text, strSQL.ToString());

                    break;
                default:
                    // Throw error...
                    intNumOfRows = 0;
                    break;
            }

            if (intNumOfRows == 1)
            {
                blnSuccess = true;
            }

        }
        catch (Exception ex)
        {

            blnSuccess = false;

        }

        return blnSuccess;

    }

    public bool ReportAssemblyFound()
    {

        bool blnFound = false;

        try
        {
            blnFound = false;

            if (File.Exists(m_strReportAssemblyPath))
            {
                blnFound = true;
            }

        }
        catch (Exception ex)
        {


        }

        return blnFound;

    }



    #endregion

    #region " Directory Utilities "

    public bool CreateDir(string strNewDir)
    {
        bool functionReturnValue = false;

        string strPath = string.Empty;
        string strTempDir = string.Empty;
        string strServerName = string.Empty;
        string strDriveName = string.Empty;

        bool blnSuccess = false;
        bool blnDirExists = false;

        int intCounter = 0;
        int intPos = 0;

        try
        {
            functionReturnValue = false;

            if (strNewDir.IndexOf("\\") >= 0)
            {
                intPos = strNewDir.IndexOf("\\");
                strServerName = strNewDir.Substring(2, intPos - 3);
                strDriveName = strNewDir.Substring(2, intPos + 1);
                strPath = strNewDir.Substring(2, intPos + 3);
            }
            else
            {
                strPath = strNewDir;
            }

            if (!strPath.EndsWith("\\"))
            {
                strPath = strPath + "\\";
            }

            intCounter = 1;

            while (strPath.Substring(intCounter).IndexOf("\\") != -1)
            {
                intCounter = strPath.Substring(intCounter).IndexOf("\\");

                if (!string.IsNullOrEmpty(strServerName))
                {
                    strTempDir = "\\\\" + strServerName + "\\" + strDriveName + "\\" + strPath.Substring(0, intCounter);
                }
                else
                {
                    strTempDir = strPath.Substring(0, intCounter - 1);
                }

                blnDirExists = Directory.Exists(strTempDir);

                if (!blnDirExists)
                {
                    Directory.CreateDirectory(strTempDir);
                    blnSuccess = true;
                }
                intCounter = intCounter + 1;
            }

            functionReturnValue = blnSuccess;
            return functionReturnValue;


        }
        catch (Exception ex)
        {


        }
        return functionReturnValue;

    }

    public bool CreateUsersDir(string strNewDir)
    {
        bool functionReturnValue = false;

        try
        {
            functionReturnValue = false;

            if (!strNewDir.EndsWith("\\"))
            {
                strNewDir = strNewDir + "\\";
            }

            Directory.CreateDirectory(strNewDir + "Reports");
            //Directory.CreateDirectory(strNewDir & "Logs")

            functionReturnValue = true;

        }
        catch (Exception ex)
        {


        }
        return functionReturnValue;

    }

  

    #endregion

}

