using Core.Framework;
using Core.Windows.UI.Core.Windows.UI;
using RMA_Batch.RE2005;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using rma.Views;
using System.Threading;
using Core.Framework.Core.Framework;
using System.Data.SqlClient;
using Core.DataAccess.SqlServer;
using System.Data;

namespace RMA_Batch
{
    class Program
    {
        private static string ConnectEnviroment;
        static void Main(string[] args)
        {

            try
            {



                if (args.Length == 0)
                {
                    Console.WriteLine("Missing Parameters");
                    return;
                }

                string version = ConfigurationManager.AppSettings["Version"].ToString();
                if (version.Length > 0)
                {
                    version = " v." + version;
                }


                foreach (string a in args)
                {
                    if (a.ToUpper() == "-V")
                    {
                        Console.WriteLine("Build Date: " + new FileInfo(Assembly.GetExecutingAssembly().Location).LastWriteTime);
                        Console.WriteLine(version);
                        return;
                    }
                }


                ConnectEnviroment = args[0].ToString().ToUpper();
                string Type = args[1].ToString().ToUpper();
                string Name = args[2].ToString().ToUpper();
                string RepFileName = string.Empty;


                try
                {
                    var qs = ConfigurationManager.AppSettings["QuizStats"].ToString();
                    DirectoryInfo hdDirectoryInWhichToSearch = new DirectoryInfo(qs);

                    FileInfo[] filesInDir = hdDirectoryInWhichToSearch.GetFiles("*.txt");

                    if (!Directory.Exists(qs + "_Old"))
                    {
                        Directory.CreateDirectory(qs + "_Old");
                    }

                    foreach (FileInfo foundFile in filesInDir)
                    {
                        File.Move(foundFile.FullName, foundFile.FullName.Replace(qs, qs + "_Old"));
                    }
                }
                catch { }




                if (Type == "QUIZ")
                {
                    if (args.Length > 3)
                    {
                        if (args[3].ToString().ToUpper().StartsWith("DISC_"))
                            RepFileName = args[3].ToString().ToUpper().Replace("DISC_", "");
                        else
                            RepFileName = args[2].ToString().ToUpper();
                    }
                    else
                        RepFileName = args[2].ToString().ToUpper();
                }

                Console.WriteLine("Running: " + args[1].ToString().ToUpper() + " " + Name + " " +
                    DateTime.Now.Day.ToString().PadLeft(2, '0') + "/" +
                    DateTime.Now.Month.ToString().PadLeft(2, '0') + "/" +
                    DateTime.Now.Year.ToString().PadLeft(2, '0') + " " +
                     DateTime.Now.ToLongTimeString());

                Console.WriteLine(version);



                //Console.WriteLine("Environment: " + ConnectEnviroment);

                if (ConnectEnviroment == "101C")
                {
                    Core.Framework.Core.Windows.Framework.ApplicationState.Current.CurrentConnectionStrings = "ConnectionString1";

                    if (Environment.GetEnvironmentVariable("RMABILL_VERS", EnvironmentVariableTarget.Process) == null)
                    {
                        Environment.SetEnvironmentVariable("RMABILL_VERS", "101C");
                    }

                }
                else if (ConnectEnviroment == "101CD2")
                {
                    Core.Framework.Core.Windows.Framework.ApplicationState.Current.CurrentConnectionStrings = "ConnectionString2";

                    if (Environment.GetEnvironmentVariable("RMABILL_VERS", EnvironmentVariableTarget.Process) == null)
                    {
                        Environment.SetEnvironmentVariable("RMABILL_VERS", "101C");
                    }

                }
                else if (ConnectEnviroment == "101CD3")
                {
                    Core.Framework.Core.Windows.Framework.ApplicationState.Current.CurrentConnectionStrings = "ConnectionString3";

                    if (Environment.GetEnvironmentVariable("RMABILL_VERS", EnvironmentVariableTarget.Process) == null)
                    {
                        Environment.SetEnvironmentVariable("RMABILL_VERS", "101C");
                    }

                }
                else if (ConnectEnviroment == "101CD4")
                {
                    Core.Framework.Core.Windows.Framework.ApplicationState.Current.CurrentConnectionStrings = "ConnectionString4";

                    if (Environment.GetEnvironmentVariable("RMABILL_VERS", EnvironmentVariableTarget.Process) == null)
                    {
                        Environment.SetEnvironmentVariable("RMABILL_VERS", "101C");
                    }

                }
                else if (ConnectEnviroment == "101CD5")
                {
                    Core.Framework.Core.Windows.Framework.ApplicationState.Current.CurrentConnectionStrings = "ConnectionString5";

                    if (Environment.GetEnvironmentVariable("RMABILL_VERS", EnvironmentVariableTarget.Process) == null)
                    {
                        Environment.SetEnvironmentVariable("RMABILL_VERS", "101C");
                    }

                }
                else if (ConnectEnviroment == "101")
                {
                    Core.Framework.Core.Windows.Framework.ApplicationState.Current.CurrentConnectionStrings = "ConnectionString9";

                    if (Environment.GetEnvironmentVariable("RMABILL_VERS", EnvironmentVariableTarget.Process) == null)
                    {
                        Environment.SetEnvironmentVariable("RMABILL_VERS", "101");
                    }

                }
                else if (ConnectEnviroment == "MP")
                {
                    Core.Framework.Core.Windows.Framework.ApplicationState.Current.CurrentConnectionStrings = "ConnectionString6";

                    if (Environment.GetEnvironmentVariable("RMABILL_VERS", EnvironmentVariableTarget.Process) == null)
                    {
                        Environment.SetEnvironmentVariable("RMABILL_VERS", "MP");
                    }

                }
                else if (ConnectEnviroment == "SOLO")
                {
                    Core.Framework.Core.Windows.Framework.ApplicationState.Current.CurrentConnectionStrings = "ConnectionString7";

                    if (Environment.GetEnvironmentVariable("RMABILL_VERS", EnvironmentVariableTarget.Process) == null)
                    {
                        Environment.SetEnvironmentVariable("RMABILL_VERS", "SOLO");
                    }
                }
                else if (ConnectEnviroment == "SOLOD2")
                {
                    Core.Framework.Core.Windows.Framework.ApplicationState.Current.CurrentConnectionStrings = "ConnectionString8";

                    if (Environment.GetEnvironmentVariable("RMABILL_VERS", EnvironmentVariableTarget.Process) == null)
                    {
                        Environment.SetEnvironmentVariable("RMABILL_VERS", "SOLO");
                    }
                }




                SqlDataReader drdReader = null;
                string strSQL;
                Decimal dblDate;

                try
                {
                    strSQL = "SELECT DATE FROM [INDEXED].[CORE_DEBUG_SYSDATE]";
                    drdReader = SqlHelper.ExecuteReader(Common.GetSqlConnectionString(), CommandType.Text, strSQL);
                    if (drdReader.Read())
                    {
                        dblDate = Convert.ToDecimal(drdReader[0]);
                        drdReader.Close();
                        Console.WriteLine("SysDate: " + dblDate);
                    }

                    drdReader.Close();
                }
                catch (Exception ex)
                {
                    if (!(drdReader == null))
                    {
                        if (!drdReader.IsClosed)
                        {
                            drdReader.Close();
                        }

                    }

                }

                if (!(drdReader == null))
                {
                    if (!drdReader.IsClosed)
                    {
                        drdReader.Close();
                    }

                }


                string[] Parms = null;

                if (Type == "COBOL" && (Name == "R123A" || Name == "R153A"))
                {
                    var parms = args[3];

                    parms = parms.Substring(2);
                    parms = parms.Substring(0, parms.Length - 1);

                    Parms = parms.Replace("\r", "").Split('\n');

                    for (int i = 0; i <= Parms.Length - 2; i++)
                    {
                        Console.WriteLine("Parm " + (i + 1) + ": " + Parms[i].ToString());
                    }

                }
                else
                {
                    if (args.Length > 3)
                    {
                        Parms = new string[args.Length - 3];

                        for (int i = 3; i <= args.Length - 1; i++)
                        {
                            Parms[i - 3] = args[i];
                            Console.WriteLine("Parm " + (i - 2) + ": " + args[i].ToString());
                        }
                    }
                }

                if (Type == "QUIZ")
                {
                    if (args.Length > 3)
                    {
                        if (args[3].ToString().ToUpper().StartsWith("DISC_"))
                        {
                            if (args.Length > 4)
                            {
                                Parms = new string[args.Length - 4];

                                for (int i = 4; i <= args.Length - 1; i++)
                                {
                                    Parms[i - 4] = args[i].Replace("SELECTIF_", "").Replace("^", " ");
                                    Console.WriteLine("Parm " + (i - 3) + ": " + args[i].ToString().Replace("SELECTIF_", "").Replace("^", " "));
                                }
                            }
                        }
                    }
                    else
                    {
                        if (args.Length > 3)
                        {
                            Parms = new string[args.Length - 3];

                            for (int i = 3; i <= args.Length - 1; i++)
                            {
                                Parms[i - 3] = args[i].Replace("SELECTIF_", "").Replace("^", " ");
                                Console.WriteLine("Parm " + (i - 2) + ": " + args[i].ToString().Replace("SELECTIF_", "").Replace("^", " "));
                            }
                        }
                    }
                }


                if (Type == "QTP")
                {
                    RunQTP(Name, Parms);

                }
                else if (Type == "QUIZ")
                {
                    CallQUIZ("", Name, RepFileName, Parms);
                }
                else if (Type == "TRUNCATE")
                {
                    CallTRUNCATE(Name);
                }
                else if (Type == "COBOL")
                {
                    switch (Name.ToUpper())
                    {
                        case "NEWU703":
                            RunCOBOL(Name, Parms);
                            break;
                        case "R040":
                            RunCOBOL(Name, Parms);
                            break;
                        case "U030A":
                            RunCOBOL(Name, Parms);
                            break;
                        case "U140":
                            RunCOBOL(Name, Parms);
                            break;
                        case "U030C":
                            RunCOBOL(Name, Parms);
                            break;
                        case "R004A":
                            RunCOBOL(Name, Parms);
                            break;
                        case "R004B":
                            RunCOBOL(Name, Parms);
                            break;
                        case "R004C":
                            RunCOBOL(Name, Parms);
                            break;
                        case "R005":
                            RunCOBOL(Name, Parms);
                            break;
                        case "R011":
                            RunCOBOL(Name, Parms);
                            break;
                        case "R012":
                            RunCOBOL(Name, Parms);
                            break;
                        case "R013":
                            RunCOBOL(Name, Parms);
                            break;
                        case "R014":
                            RunCOBOL(Name, Parms);
                            break;
                        case "R014SUM":
                            RunCOBOL(Name, Parms);
                            break;
                        case "R051A":
                            RunCOBOL(Name, Parms);
                            break;
                        case "R051B":
                            RunCOBOL(Name, Parms);
                            break;
                        case "R051C":
                            RunCOBOL(Name, Parms);
                            break;
                        case "R070A":
                            RunCOBOL(Name, Parms);
                            break;
                        case "R070B":
                            RunCOBOL(Name, Parms);
                            break;
                        case "R070C":
                            RunCOBOL(Name, Parms);
                            break;
                        case "U021A":
                            RunCOBOL(Name, Parms);
                            break;
                        case "R001":
                            RunCOBOL(Name, Parms);
                            break;
                        case "R001B":
                            RunCOBOL(Name, Parms);
                            break;
                        case "R002A":
                            RunCOBOL(Name, Parms);
                            break;
                        case "R002B":
                            RunCOBOL(Name, Parms);
                            break;
                        case "R004_CYCLE":
                            RunCOBOL(Name, Parms);
                            break;
                        case "R071":
                            RunCOBOL(Name, Parms);
                            break;
                        case "R073":
                            RunCOBOL(Name, Parms);
                            break;
                        case "U888":
                            RunCOBOL(Name, Parms);
                            break;
                        case "NEWU701":
                            RunCOBOL(Name, Parms);
                            break;
                        case "U701OSCAR":
                            RunCOBOL(Name, Parms);
                            break;
                        case "U703OSCAR":
                            RunCOBOL(Name, Parms);
                            break;
                        case "U993":
                            RunCOBOL(Name, Parms);
                            break;
                        case "U040":
                            RunCOBOL(Name, Parms);
                            break;
                        case "U041":
                            RunCOBOL(Name, Parms);
                            break;
                        case "U011":
                            RunCOBOL(Name, Parms);
                            break;
                        default:
                            RunQTP(Name, Parms);
                            break;
                    }
                }

                Console.WriteLine("Completed " + args[1].ToString().ToUpper() + " " + Name + " " +
                    DateTime.Now.Day.ToString().PadLeft(2, '0') + "/" +
                    DateTime.Now.Month.ToString().PadLeft(2, '0') + "/" +
                    DateTime.Now.Year.ToString().PadLeft(2, '0') + " " +
                     DateTime.Now.ToLongTimeString());
                Console.WriteLine("");


            }
            catch (Exception ex)
            {
                var sw = new StreamWriter("core_trace.log", true);
                sw.WriteLine("********************************************************************************************************************************");
                sw.WriteLine(DateTime.Now.ToShortDateString() + "   " + DateTime.Now.ToShortTimeString());
                sw.WriteLine(ex.Message);
                sw.WriteLine();
                sw.WriteLine(ex.StackTrace.ToString());

                sw.WriteLine("********************************************************************************************************************************");

                sw.Flush();
                sw.Dispose();
            }
        }


        private static bool CallTRUNCATE(string table)
        {

            try
            {
                var sql = new StringBuilder(" truncate table [").Append(ConnectEnviroment).Append("].[INDEXED].[").Append(table).Append("]");
                var results = Core.DataAccess.SqlServer.SqlHelper.ExecuteNonQuery(Common.GetSqlConnectionString(), System.Data.CommandType.Text, sql.ToString());
            }
            catch
            {
                try
                {
                    var sql = new StringBuilder(" truncate table [").Append(ConnectEnviroment).Append("].[SEQUENTIAL].[").Append(table).Append("]");
                    var results = Core.DataAccess.SqlServer.SqlHelper.ExecuteNonQuery(Common.GetSqlConnectionString(), System.Data.CommandType.Text, sql.ToString());
                }
                catch
                {

                }
            }



            return true;
        }

        private static bool CallQUIZ(string ReportFormat, string Name, string ReportFileName, string[] arrParms)
        {

            CallReport.stcReportParameters stcParameters = new CallReport.stcReportParameters();
            CallReport objCallReport = new CallReport();

            DateTime time = DateTime.Now;

            try
            {
                switch (Name)
                {
                    default:
                        ReportFormat = "TXT";
                        break;
                }

                // Set properties from web.config.
                SetReportConfigProperties("RMA", ref stcParameters);

                stcParameters.astrScreenParameters = arrParms;
                stcParameters.strReportFileName = ReportFileName;
                stcParameters.strReportId = Name.Trim();
                stcParameters.strReportFormat = ReportFormat;
                stcParameters.strReportLanguage = "EN";
                stcParameters.strDefaultSchema = ConnectEnviroment;
                stcParameters.dtReportRunDate = System.DateTime.Today.Date;
                stcParameters.dtReportRunTime = DateTime.Now;

                objCallReport.RunReport(stcParameters, "RMA");

                string partialName = Name;
                if (partialName.Split('_').Count() > 0)
                {
                    partialName = partialName.Split('_')[0];
                }

                if (objCallReport.IsMP)
                {
                    partialName = "MP_" + partialName;
                }

                var qs = ConfigurationManager.AppSettings["QuizStats"].ToString();
                DirectoryInfo hdDirectoryInWhichToSearch = new DirectoryInfo(qs);
                FileInfo[] filesInDir = hdDirectoryInWhichToSearch.GetFiles(partialName + "*.txt");




                foreach (FileInfo foundFile in filesInDir.Where(q => q.CreationTime >= time).OrderBy(q => q.CreationTime))
                {
                    var sr = new StreamReader(foundFile.FullName);
                    var stats = sr.ReadToEnd();
                    if (stats.IndexOf("Records Written: 0") >= 0)
                    {
                        if (File.Exists(stcParameters.strReportCompletionPath + ReportFileName + ".txt"))
                        {
                            File.Delete(stcParameters.strReportCompletionPath + ReportFileName + ".txt");
                        }
                        if (File.Exists(stcParameters.strReportCompletionPath + ReportFileName + ".pdf"))
                        {
                            File.Delete(stcParameters.strReportCompletionPath + ReportFileName + ".pdf");
                        }
                    }
                    Console.WriteLine(stats);
                    sr.Dispose();


                    try
                    {
                        File.Move(foundFile.FullName, foundFile.FullName.Replace(qs, qs + "_Old"));
                    }
                    catch { }

                }

                if (File.Exists(stcParameters.strReportCompletionPath + ReportFileName + ".txt"))
                {
                    var sr = new StreamReader(stcParameters.strReportCompletionPath + ReportFileName + ".txt");

                    if (sr.ReadToEnd().Trim() == "" || sr.ReadToEnd().StartsWith("~SUBFILE~"))
                    {
                        sr.Close();
                        sr.Dispose();
                        File.Delete(stcParameters.strReportCompletionPath + ReportFileName + ".txt");
                        if (File.Exists(stcParameters.strReportCompletionPath + ReportFileName + ".pdf"))
                        {
                            File.Delete(stcParameters.strReportCompletionPath + ReportFileName + ".pdf");
                        }
                    }
                    else
                    {
                        sr.Close();
                        sr.Dispose();
                    }
                }



                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                objCallReport = null;


            }

        }


        private static bool SetReportConfigProperties(string strProjectName, ref CallReport.stcReportParameters stcParameters)
        {



            try
            {
                if (strProjectName.Trim() != string.Empty)
                {


                    stcParameters.strDatabaseType = Common.cSQL_SERVER;


                    stcParameters.strConnString = Common.GetSqlConnectionString();
                    stcParameters.strDefaultSchema = ConfigurationManager.AppSettings["ReportQTPSchema"].ToString();
                    stcParameters.strDeployedReportURL = ConfigurationManager.AppSettings["DeployedReportURL"].ToString();


                    if (Directory.GetCurrentDirectory().Trim().EndsWith("\\"))
                    {
                        stcParameters.strReportCompletionPath = Directory.GetCurrentDirectory() + "";
                    }
                    else
                    {
                        stcParameters.strReportCompletionPath = Directory.GetCurrentDirectory() + "\\" + "";
                    }

                }

                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
            finally
            {


            }

        }


        private static bool RunQTP(string QTPName, object[] Parms)
        {


            ApplicationState.Current.Application = new Hashtable();
            ApplicationState.Current.Session = new Hashtable();
            ApplicationState.Current.Session["IsQtpObj"] = true;
            Application.Utilities.Factory objFactory = new Application.Utilities.Factory();

            // Get a new component object. 



            Core.Windows.UI.Core.Windows.BaseClassControl objClass = null;
            MethodInfo mi = null;

            if (Parms != null && Parms.Length > 0)
            {
                Common.Parms = Parms;
            }

            if (Environment.GetEnvironmentVariable("RMABILL_VERS", EnvironmentVariableTarget.Process).ToUpper() == "MP")
            {
                try
                {
                    mi = typeof(Application.Utilities.Factory).GetMethod("Create" + "Mp_" + QTPName);
                    objClass = (Core.Windows.UI.Core.Windows.BaseClassControl)mi.Invoke(objFactory, new object[] { 1 });
                }
                catch
                {
                    mi = typeof(Application.Utilities.Factory).GetMethod("Create" + QTPName);
                    objClass = (Core.Windows.UI.Core.Windows.BaseClassControl)mi.Invoke(objFactory, new object[] { 1 });
                }

            }
            else
            {
                mi = typeof(Application.Utilities.Factory).GetMethod("Create" + QTPName);
                objClass = (Core.Windows.UI.Core.Windows.BaseClassControl)mi.Invoke(objFactory, new object[] { 1 });
            }

            string UserID = string.Empty;
            System.DateTime StartTime = default(System.DateTime);
            System.DateTime LastAccessTime = default(System.DateTime);
            bool IsActive = false;
            int NumberedSessionID = 0;

            Common.JobConnectionString = Common.GetSqlConnectionString();



            try
            {
                objClass.RunQTPBase(NumberedSessionID, "", Parms);

                return true;


            }
            catch (Exception ex)
            {
                return false;

            }
            finally
            {

            }
        }

        private static bool RunCOBOL(string ViewModelName, object[] Parms)
        {
            Common.JobConnectionString = Common.GetSqlConnectionString();

            try
            {
                switch (ViewModelName.ToUpper())
                {
                    case "NEWU703":
                        Newu703ViewModel objNewu703ViewModel = null;
                        objNewu703ViewModel = new Newu703ViewModel();
                        objNewu703ViewModel.mainline();
                        objNewu703ViewModel = null;
                        break;
                    case "R040":
                        R040ViewModel objR040ViewModel = null;
                        objR040ViewModel = new R040ViewModel();
                        objR040ViewModel.mainline();
                        objR040ViewModel = null;
                        break;
                    case "U030A":
                        u030aViewModel obju030aViewModel = null;
                        obju030aViewModel = new u030aViewModel(Parms[0].ToString(), Convert.ToInt32(Parms[1]), Parms[2].ToString(), Parms[3].ToString(), Parms[4].ToString());
                        obju030aViewModel = null;
                        break;
                    case "U140":
                        U140ViewModel objU140ViewModel = null;
                        objU140ViewModel = new U140ViewModel();
                        objU140ViewModel = null;
                        break;
                    case "U030C":
                        U030cViewModel objU030cViewModel = null;
                        objU030cViewModel = new U030cViewModel();
                        objU030cViewModel.mainline_section();
                        objU030cViewModel = null;
                        break;
                    case "R004A":
                        R004aViewModel objR004aViewModel = null;
                        objR004aViewModel = new R004aViewModel();
                        objR004aViewModel.mainline(Convert.ToInt32(Parms[0].ToString()), Parms[1].ToString());
                        objR004aViewModel = null;
                        break;
                    case "R004B":
                        R004bViewModel objR004bViewModel = null;
                        objR004bViewModel = new R004bViewModel();
                        objR004bViewModel.mainline();
                        objR004bViewModel = null;
                        break;
                    case "R004C":
                        R004cViewModel objR004cViewModel = null;
                        objR004cViewModel = new R004cViewModel();
                        objR004cViewModel.mainline(Parms[0].ToString());
                        break;
                    case "R005":
                        R005ViewModel objR005ViewModel = null;
                        objR005ViewModel = new R005ViewModel();
                        objR005ViewModel.mainline(Parms[0].ToString(), Parms[1].ToString());
                        objR005ViewModel = null;
                        break;
                    case "R011":
                        R011ViewModel objR011ViewModel = null;
                        objR011ViewModel = new R011ViewModel();
                        objR011ViewModel.mainline_section(Parms[0].ToString(), Parms[1].ToString());
                        objR011ViewModel = null;
                        break;
                    case "R012":
                        R012ViewModel objR012ViewModel = null;
                        objR012ViewModel = new R012ViewModel();
                        objR012ViewModel.mainline_section(Parms[0].ToString(), Parms[1].ToString());
                        objR012ViewModel = null;
                        break;
                    case "R013":
                        R013ViewModel objR013ViewModel = null;
                        objR013ViewModel = new R013ViewModel();
                        objR013ViewModel.mainline_section(Parms[0].ToString(), Parms[1].ToString());
                        objR013ViewModel = null;
                        break;
                    case "R014":
                        R014ViewModel objR014ViewModel = null;
                        objR014ViewModel = new R014ViewModel();
                        objR014ViewModel.mainline();
                        objR014ViewModel = null;
                        break;
                    case "R014SUM":
                        R014sumViewModel objR014sumViewModel = null;
                        objR014sumViewModel = new R014sumViewModel();
                        objR014sumViewModel.Mainline();
                        objR014sumViewModel = null;
                        break;
                    case "R051A":
                        R051aViewModel objR051aViewModel = null;
                        objR051aViewModel = new R051aViewModel();
                        objR051aViewModel.mainline(Parms[0].ToString(), Parms[1].ToString());
                        objR051aViewModel = null;
                        break;
                    case "R051B":
                        R051bViewModel objR051bViewModel = null;
                        objR051bViewModel = new R051bViewModel();
                        objR051bViewModel.mainline();
                        objR051bViewModel = null;
                        break;
                    case "R051C":
                        R051cViewModel objR051cViewModel = null;
                        objR051cViewModel = new R051cViewModel();
                        objR051cViewModel.mainline();
                        objR051cViewModel = null;
                        break;
                    case "R070A":
                        R070aViewModel objR070aViewModel = null;
                        objR070aViewModel = new R070aViewModel();
                        objR070aViewModel.mainline_section(Parms[0].ToString(), Parms[1].ToString());
                        objR070aViewModel = null;
                        break;
                    case "R070B":
                        R070bViewModel objR070bViewModel = null;
                        objR070bViewModel = new R070bViewModel();
                        objR070bViewModel.mainline();
                        objR070bViewModel = null;
                        break;
                    case "R070C":
                        R070cViewModel objR070cViewModel = null;
                        objR070cViewModel = new R070cViewModel();
                        objR070cViewModel.mainline();
                        objR070cViewModel = null;
                        break;
                    case "U021A":
                        U021aViewModel objU021aViewModel = null;
                        objU021aViewModel = new U021aViewModel();
                        objU021aViewModel.mainline(Parms[0].ToString(), Convert.ToInt32(Parms[1]), Parms[2].ToString(), Parms[3].ToString());
                        objU021aViewModel = null;
                        break;
                    case "R001":
                        R001ViewModel objR001ViewModel = null;
                        objR001ViewModel = new R001ViewModel();
                        objR001ViewModel.mainline();
                        objR001ViewModel = null;
                        break;
                    case "R001B":
                        R001bViewModel objR001bViewModel = null;
                        objR001bViewModel = new R001bViewModel();
                        objR001bViewModel.mainline();
                        objR001bViewModel = null;
                        break;
                    case "R002A":
                        R002aViewModel objR002aViewModel = null;
                        objR002aViewModel = new R002aViewModel();
                        objR002aViewModel.mainline();
                        objR002aViewModel = null;
                        break;
                    case "R002B":
                        R002bViewModel objR002bViewModel = null;
                        objR002bViewModel = new R002bViewModel();
                        // objR002bViewModel.mainline(Parms[0].ToString());
                        objR002bViewModel.mainline();
                        objR002bViewModel = null;
                        break;
                    case "R004_CYCLE":
                        R004_cycleViewModel objR004_cycleViewModel = null;
                        objR004_cycleViewModel = new R004_cycleViewModel();
                        objR004_cycleViewModel.mainline();
                        objR004_cycleViewModel = null;
                        break;
                    case "R071":
                        R071ViewModel objR071ViewModel = null;
                        objR071ViewModel = new R071ViewModel();
                        objR071ViewModel.mainline(Convert.ToInt32(Parms[0]), Parms[1].ToString());
                        objR071ViewModel = null;
                        break;
                    case "R073":
                        R073ViewModel objR073ViewModel = null;
                        objR073ViewModel = new R073ViewModel();
                        objR073ViewModel.mainline_section();
                        objR073ViewModel = null;
                        break;
                    case "U888":
                        U888ViewModel objU888ViewModel = null;
                        objU888ViewModel = new U888ViewModel();
                        objU888ViewModel.mainline();
                        objU888ViewModel = null;
                        break;
                    case "NEWU701":
                        Newu701ViewModel objNewu701ViewModel = null;
                        objNewu701ViewModel = new Newu701ViewModel();
                        objNewu701ViewModel.mainline_section();
                        objNewu701ViewModel = null;
                        break;
                    case "U701OSCAR":
                        U701oscarViewModel objU701oscarViewModel = null;
                        objU701oscarViewModel = new U701oscarViewModel();
                        objU701oscarViewModel.mainline_section();
                        objU701oscarViewModel = null;
                        break;
                    case "U703OSCAR":
                        U703oscarViewModel objU703oscarViewModel = null;
                        objU703oscarViewModel = new U703oscarViewModel();
                        objU703oscarViewModel.mainline();
                        objU703oscarViewModel = null;
                        break;
                    case "U993":
                        U993ViewModel objU993ViewModel = null;
                        objU993ViewModel = new U993ViewModel();
                        objU993ViewModel.mainline();
                        objU993ViewModel = null;
                        break;
                    case "U040":
                        U040ViewModel objU040ViewModel = null;
                        objU040ViewModel = new U040ViewModel();
                        objU040ViewModel.mainline();
                        objU040ViewModel = null;
                        break;
                    case "U041":
                        U041ViewModel objU041ViewModel = null;
                        objU041ViewModel = new U041ViewModel();
                        objU041ViewModel.mainline();
                        objU041ViewModel = null;
                        break;
                    case "U011":
                        U011ViewModel objU011ViewModel = null;
                        objU011ViewModel = new U011ViewModel();
                        objU011ViewModel.mainline();
                        objU011ViewModel = null;
                        break;
                }

                return true;    
            }
            catch (Exception ex)
            {
                return false;

            }
            finally
            {

            }
        }
    }
}
