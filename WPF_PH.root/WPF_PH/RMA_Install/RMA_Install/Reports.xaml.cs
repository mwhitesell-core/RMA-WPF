using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO.Compression;
using System.Resources;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Core;
using RMA_Install.localhost;
using System.Web.Services.Protocols;
using System.Threading;

namespace RMA_Install
{
    /// <summary>
    /// Interaction logic for Welcome1.xaml
    /// </summary>
    public partial class Reports : UserControl
    {
        public Reports()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            try
            {



                ApplicationState.Current.reportserver = txtdirectory.Text;
                ApplicationState.Current.webservice = txtdirectory2.Text;

                if (radioButton1.IsChecked == true)
                {

                    Assembly _assembly = Assembly.GetExecutingAssembly();


                    if (txtdirectory.Text.Trim() != "")
                    {
                        Stream inStream = _assembly.GetManifestResourceStream("RMA_Install.Zips.Core_Reports.zip");

                        UnzipFromStreamReports(inStream, txtdirectory.Text + "\\bin");
                    }

                    if (txtdirectory2.Text.Trim() != "")
                    {
                        Stream inStream = _assembly.GetManifestResourceStream("RMA_Install.Zips.RDL.zip");

                        UnzipFromStreamRDL(inStream, ApplicationState.Current.install_directory + "");

                        CreateReports(GetReports(ApplicationState.Current.install_directory + "\\RDL\\"));



                        DeleteDirectory(ApplicationState.Current.install_directory + "\\RDL\\");
                    }


                    CheckConfigFiles();
                    AddReportconfig();

                }


                this.Content = new Batch();

            }
            catch (Exception ex)
            {
                var confirm = new ConfirmationDialog("Error", ex.Message, "", DialogButtons.Ok);

                confirm.Closed += delegate
                {
                    if (confirm.DialogResult != null &&
                        confirm.DialogResult == true)
                    {
                        System.Windows.Application.Current.Shutdown();
                    }
                };

                confirm.Owner = Application.Current.MainWindow;
                confirm.ShowDialog();
            }

        }



        private void AddReportconfig()
        {

            var file = ApplicationState.Current.reportserver + "\\bin\\" + "Report.config";
            var sb = new StringBuilder("");

            sb.Append("<?xml version=\"1.0\" encoding=\"utf-8\" ?>").Append(Environment.NewLine);
            sb.Append("<appSettings>").Append(Environment.NewLine);
            sb.Append("  <add key=\"AuthenticationDatabase\" value=\"SQL Server\" />").Append(Environment.NewLine);
            sb.Append("  <add key=\"DateFormat\" value=\"YYYYMMDD\" />").Append(Environment.NewLine);
            sb.Append("  <add key=\"EnglishCulture\" value=\"en-US\" />").Append(Environment.NewLine);
            sb.Append("  <add key=\"DateSeparator\" value=\"/\" />").Append(Environment.NewLine);
            sb.Append("  <add key=\"Debug\" value=\"False\" />").Append(Environment.NewLine);
            sb.Append("  <add key=\"DefaultCentury\" value=\"2000\" />").Append(Environment.NewLine);
            sb.Append("  <add key=\"FlatFileDictionary\" value=\"").Append(ApplicationState.Current.install_directory).Append("\\FlatFileDictionary\" />").Append(Environment.NewLine);
            sb.Append("  <add key=\"FlatFilePath\" value=\"[CurrentDirectory]\" />").Append(Environment.NewLine);
            sb.Append("  <add key=\"GenericRetrievalCharacter\" value=\"@\" />").Append(Environment.NewLine);
            sb.Append("  <add key=\"InputCenturyFrom\" value=\"19,80\" />").Append(Environment.NewLine);
            sb.Append("  <add key=\"LogPath\" value=\"").Append(ApplicationState.Current.install_directory).Append("\\LogFiles\" />").Append(Environment.NewLine);
            sb.Append("  <add key=\"LookupCharacter\" value=\"=\" />").Append(Environment.NewLine);
            sb.Append("  <add key=\"SessionManager\" value=\"localhost:15124\"/>").Append(Environment.NewLine);
            sb.Append("  <add key=\"SubFileSchema\" value=\"TemporaryData\" />").Append(Environment.NewLine);
            sb.Append("  <add key=\"SysName\" value=\"Regional Medical Associates - Hamilton\" />").Append(Environment.NewLine);
            sb.Append("  <add key=\"Title\" value=\"RMA\" />").Append(Environment.NewLine);
            sb.Append("</appSettings>").Append(Environment.NewLine);


            var sw = new StreamWriter(file);
            sw.Write(sb.ToString());
            sw.Flush();
            sw.Dispose();

        }

        private void CheckConfigFiles()
        {

            var sr = new StreamReader(txtdirectory.Text + "\\rsreportserver.config");
            var text = sr.ReadLine();

            bool foundext = false;

            while (text != null)
            {
                if (text.IndexOf("\"CORE_DATA_EXTENSION\"") >= 0)
                {
                    foundext = true;
                    break;
                }

                text = sr.ReadLine();

            }

            sr.Dispose();

            if (!foundext)
            {
                sr = new StreamReader(txtdirectory.Text + "\\rsreportserver.config");
                text = sr.ReadLine();
                var sb = new StringBuilder("");

                while (text != null)
                {

                    if (text.Trim() == "<Data>")
                    {
                        sb.Append(text).Append(Environment.NewLine);
                        sb.Append("			<Extension Name=\"CORE_DATA_EXTENSION\" Type=\"Core.RDL.DataSetExtension.DSXConnection, Core.RDLDataExtension\">").Append(Environment.NewLine);
                        sb.Append("				<Configuration>").Append(Environment.NewLine);
                        sb.Append("					<ExtensionData>").Append(Environment.NewLine);
                        sb.Append("						<Projects>").Append(Environment.NewLine);
                        sb.Append("							<rmaBilling>").Append(Environment.NewLine);
                        sb.Append("								<ReportAssemblyPath>").Append(txtdirectory.Text).Append("\\bin\\RMA_DATA.dll</ReportAssemblyPath>").Append(Environment.NewLine);
                        sb.Append("								<Debug>False</Debug>").Append(Environment.NewLine);
                        sb.Append("								<LogFile>").Append(ApplicationState.Current.install_directory).Append("\\alpha\\rmabill\\ReportLogs\\Debug.txt</LogFile>").Append(Environment.NewLine);
                        sb.Append("								<Statistics>").Append(ApplicationState.Current.install_directory).Append("\\alpha\\rmabill\\QuizStats</Statistics>").Append(Environment.NewLine);
                        sb.Append("							</rmaBilling>").Append(Environment.NewLine);
                        sb.Append("						</Projects>").Append(Environment.NewLine);
                        sb.Append("					</ExtensionData>").Append(Environment.NewLine);
                        sb.Append("				</Configuration>").Append(Environment.NewLine);
                        sb.Append("			</Extension>").Append(Environment.NewLine);
                    }
                    else
                    {
                        sb.Append(text).Append(Environment.NewLine);
                    }

                    text = sr.ReadLine();
                }

                sr.Dispose();

                var sw = new StreamWriter(txtdirectory.Text + "\\rsreportserver.config", false);
                sw.Write(sb.ToString());
                sw.Flush();
                sw.Dispose();
            }


            bool blnRMA_DATA = false;
            bool blnRDLDataExtension = false;
            bool blnLogManagement = false;
            bool blnDataAccess = false;
            bool blnExceptionManagement = false;
            bool blnInterfaces = false;
            bool blnFramework = false;
            bool blnGlobalization = false;
            bool blnReportFramework = false;
            bool blnSessionManager = false;


            sr = new StreamReader(txtdirectory.Text + "\\rssrvpolicy.config");
            text = sr.ReadLine();



            while (text != null)
            {
                if (text.IndexOf("RMA_DATA.dll\"") >= 0)
                {
                    blnRMA_DATA = true;
                    break;
                }
                else if (text.IndexOf("RDLDataExtension.dll\"") >= 0)
                {
                    blnRDLDataExtension = true;
                    break;
                }
                else if (text.IndexOf("LogManagement.dll\"") >= 0)
                {
                    blnLogManagement = true;
                    break;
                }
                else if (text.IndexOf("DataAccess.dll\"") >= 0)
                {
                    blnDataAccess = true;
                    break;
                }
                else if (text.IndexOf("ExceptionManagement.dll\"") >= 0)
                {
                    blnExceptionManagement = true;
                    break;
                }
                else if (text.IndexOf("Interfaces.dll\"") >= 0)
                {
                    blnInterfaces = true;
                    break;
                }
                else if (text.IndexOf("Framework.dll\"") >= 0)
                {
                    blnFramework = true;
                    break;
                }
                else if (text.IndexOf("Globalization.dll\"") >= 0)
                {
                    blnGlobalization = true;
                    break;
                }
                else if (text.IndexOf("ReportFramework.dll\"") >= 0)
                {
                    blnReportFramework = true;
                    break;
                }
                else if (text.IndexOf("SessionManager.dll\"") >= 0)
                {
                    blnSessionManager = true;
                    break;
                }

                text = sr.ReadLine();

            }

            sr.Dispose();


            bool FirstMatchCodeGroup = false;
            bool FirstMatchCodeGroup2 = false;

            if (!blnRMA_DATA
                && !blnRDLDataExtension
                  && !blnLogManagement
                    && !blnDataAccess
                      && !blnExceptionManagement
                        && !blnInterfaces
                          && !blnFramework
                            && !blnGlobalization
                              && !blnReportFramework
                                && !blnSessionManager
                )
            {
                sr = new StreamReader(txtdirectory.Text + "\\rssrvpolicy.config");
                text = sr.ReadLine();
                var sb = new StringBuilder("");

                while (text != null)
                {

                    if (text.IndexOf("class=\"FirstMatchCodeGroup\"") >= 0)
                    {
                        sb.Append(text).Append(Environment.NewLine);

                        if (FirstMatchCodeGroup)
                            FirstMatchCodeGroup2 = true;

                        FirstMatchCodeGroup = true;

                    }
                    else if (FirstMatchCodeGroup2)
                    {

                        if (text.IndexOf("<CodeGroup") >= 0)
                        {
                            FirstMatchCodeGroup2 = false;

                            if (!blnRDLDataExtension)
                            {
                                sb.Append("		<CodeGroup").Append(Environment.NewLine);
                                sb.Append("                             class=\"UnionCodeGroup\"").Append(Environment.NewLine);
                                sb.Append("                             version=\"1\"").Append(Environment.NewLine);
                                sb.Append("                             PermissionSetName=\"FullTrust\"").Append(Environment.NewLine);
                                sb.Append("                             Description=\"This code group grants Core.RDLDataExtension full trust.\">").Append(Environment.NewLine);
                                sb.Append("                <IMembershipCondition").Append(Environment.NewLine);
                                sb.Append("                        class=\"UrlMembershipCondition\"").Append(Environment.NewLine);
                                sb.Append("                        version=\"1\"").Append(Environment.NewLine);
                                sb.Append("                        Url=\"").Append(txtdirectory.Text).Append("\\bin\\Core.RDLDataExtension.dll\"").Append(Environment.NewLine);
                                sb.Append("	                       />").Append(Environment.NewLine);
                                sb.Append("              </CodeGroup>").Append(Environment.NewLine);
                            }

                            if (!blnLogManagement)
                            {
                                sb.Append("              <CodeGroup").Append(Environment.NewLine);
                                sb.Append("                             class=\"UnionCodeGroup\"").Append(Environment.NewLine);
                                sb.Append("                             version=\"1\"").Append(Environment.NewLine);
                                sb.Append("                             PermissionSetName=\"FullTrust\"").Append(Environment.NewLine);
                                sb.Append("                             Description=\"This code group grants Core.Core.LogManagement.dll full trust.\">").Append(Environment.NewLine);
                                sb.Append("                <IMembershipCondition").Append(Environment.NewLine);
                                sb.Append("                        class=\"UrlMembershipCondition\"").Append(Environment.NewLine);
                                sb.Append("                        version=\"1\"").Append(Environment.NewLine);
                                sb.Append("                        Url=\"").Append(txtdirectory.Text).Append("\\bin\\Core.LogManagement.dll\"").Append(Environment.NewLine);
                                sb.Append("	                       />").Append(Environment.NewLine);
                                sb.Append("              </CodeGroup>").Append(Environment.NewLine);
                            }

                            if (!blnRMA_DATA)
                            {
                                sb.Append("              <CodeGroup").Append(Environment.NewLine);
                                sb.Append("                      class=\"UnionCodeGroup\"").Append(Environment.NewLine);
                                sb.Append("                      version=\"1\"").Append(Environment.NewLine);
                                sb.Append("                      PermissionSetName=\"FullTrust\"").Append(Environment.NewLine);
                                sb.Append("                      Description=\"This code group grants RMA_DATA full trust.\">").Append(Environment.NewLine);
                                sb.Append("                <IMembershipCondition").Append(Environment.NewLine);
                                sb.Append("                        class=\"UrlMembershipCondition\"").Append(Environment.NewLine);
                                sb.Append("                        version=\"1\"").Append(Environment.NewLine);
                                sb.Append("                        Url=\"").Append(txtdirectory.Text).Append("\\bin\\RMA_DATA.dll\"").Append(Environment.NewLine);
                                sb.Append("	                       />").Append(Environment.NewLine);
                                sb.Append("              </CodeGroup>").Append(Environment.NewLine);
                            }

                            if (!blnDataAccess)
                            {
                                sb.Append("              <CodeGroup").Append(Environment.NewLine);
                                sb.Append("                      class=\"UnionCodeGroup\"").Append(Environment.NewLine);
                                sb.Append("                      version=\"1\"").Append(Environment.NewLine);
                                sb.Append("                      PermissionSetName=\"FullTrust\"").Append(Environment.NewLine);
                                sb.Append("                      Description=\"This code group grants Core.DataAccess full trust.\">").Append(Environment.NewLine);
                                sb.Append("                <IMembershipCondition").Append(Environment.NewLine);
                                sb.Append("                        class=\"UrlMembershipCondition\"").Append(Environment.NewLine);
                                sb.Append("                        version=\"1\"").Append(Environment.NewLine);
                                sb.Append("                        Url=\"").Append(txtdirectory.Text).Append("\\bin\\Core.DataAccess.dll\"").Append(Environment.NewLine);
                                sb.Append("	                       />").Append(Environment.NewLine);
                                sb.Append("              </CodeGroup>").Append(Environment.NewLine);
                            }

                            if (!blnExceptionManagement)
                            {
                                sb.Append("              <CodeGroup").Append(Environment.NewLine);
                                sb.Append("                      class=\"UnionCodeGroup\"").Append(Environment.NewLine);
                                sb.Append("                      version=\"1\"").Append(Environment.NewLine);
                                sb.Append("                      PermissionSetName=\"FullTrust\"").Append(Environment.NewLine);
                                sb.Append("                      Description=\"This code group grants Core.ExceptionManagement full trust.\">").Append(Environment.NewLine);
                                sb.Append("                <IMembershipCondition").Append(Environment.NewLine);
                                sb.Append("                        class=\"UrlMembershipCondition\"").Append(Environment.NewLine);
                                sb.Append("                        version=\"1\"").Append(Environment.NewLine);
                                sb.Append("                        Url=\"").Append(txtdirectory.Text).Append("\\bin\\Core.ExceptionManagement.dll\"").Append(Environment.NewLine);
                                sb.Append("	                       />").Append(Environment.NewLine);
                                sb.Append("              </CodeGroup>").Append(Environment.NewLine);
                            }

                            if (!blnInterfaces)
                            {
                                sb.Append("              <CodeGroup").Append(Environment.NewLine);
                                sb.Append("                      class=\"UnionCodeGroup\"").Append(Environment.NewLine);
                                sb.Append("                      version=\"1\"").Append(Environment.NewLine);
                                sb.Append("                      PermissionSetName=\"FullTrust\"").Append(Environment.NewLine);
                                sb.Append("                      Description=\"This code group grants Core.ExceptionManagement.Interfaces full trust.\">").Append(Environment.NewLine);
                                sb.Append("                <IMembershipCondition").Append(Environment.NewLine);
                                sb.Append("                        class=\"UrlMembershipCondition\"").Append(Environment.NewLine);
                                sb.Append("                        version=\"1\"").Append(Environment.NewLine);
                                sb.Append("                        Url=\"").Append(txtdirectory.Text).Append("\\bin\\Core.ExceptionManagement.Interfaces.dll\"").Append(Environment.NewLine);
                                sb.Append("	                       />").Append(Environment.NewLine);
                                sb.Append("              </CodeGroup>").Append(Environment.NewLine);
                            }

                            if (!blnFramework)
                            {
                                sb.Append("              <CodeGroup").Append(Environment.NewLine);
                                sb.Append("                      class=\"UnionCodeGroup\"").Append(Environment.NewLine);
                                sb.Append("                      version=\"1\"").Append(Environment.NewLine);
                                sb.Append("                      PermissionSetName=\"FullTrust\"").Append(Environment.NewLine);
                                sb.Append("                      Description=\"This code group grants Core.Framework full trust.\">").Append(Environment.NewLine);
                                sb.Append("                <IMembershipCondition").Append(Environment.NewLine);
                                sb.Append("                        class=\"UrlMembershipCondition\"").Append(Environment.NewLine);
                                sb.Append("                        version=\"1\"").Append(Environment.NewLine);
                                sb.Append("                        Url=\"").Append(txtdirectory.Text).Append("\\bin\\Core.Framework.dll\"").Append(Environment.NewLine);
                                sb.Append("	                       />").Append(Environment.NewLine);
                                sb.Append("              </CodeGroup>").Append(Environment.NewLine);
                            }


                            if (!blnGlobalization)
                            {
                                sb.Append("              <CodeGroup").Append(Environment.NewLine);
                                sb.Append("                      class=\"UnionCodeGroup\"").Append(Environment.NewLine);
                                sb.Append("                      version=\"1\"").Append(Environment.NewLine);
                                sb.Append("                      PermissionSetName=\"FullTrust\"").Append(Environment.NewLine);
                                sb.Append("                      Description=\"This code group grants Core.Globalization full trust.\">").Append(Environment.NewLine);
                                sb.Append("                <IMembershipCondition").Append(Environment.NewLine);
                                sb.Append("                        class=\"UrlMembershipCondition\"").Append(Environment.NewLine);
                                sb.Append("                        version=\"1\"").Append(Environment.NewLine);
                                sb.Append("                        Url=\"").Append(txtdirectory.Text).Append("\\bin\\Core.Globalization.dll\"").Append(Environment.NewLine);
                                sb.Append("	                       />").Append(Environment.NewLine);
                                sb.Append("              </CodeGroup>").Append(Environment.NewLine);
                            }

                            if (!blnReportFramework)
                            {
                                sb.Append("              <CodeGroup").Append(Environment.NewLine);
                                sb.Append("                      class=\"UnionCodeGroup\"").Append(Environment.NewLine);
                                sb.Append("                      version=\"1\"").Append(Environment.NewLine);
                                sb.Append("                      PermissionSetName=\"FullTrust\"").Append(Environment.NewLine);
                                sb.Append("                      Description=\"This code group grants Core.ReportFramework full trust.\">").Append(Environment.NewLine);
                                sb.Append("                <IMembershipCondition").Append(Environment.NewLine);
                                sb.Append("                        class=\"UrlMembershipCondition\"").Append(Environment.NewLine);
                                sb.Append("                        version=\"1\"").Append(Environment.NewLine);
                                sb.Append("                        Url=\"").Append(txtdirectory.Text).Append("\\bin\\Core.ReportFramework.dll\"").Append(Environment.NewLine);
                                sb.Append("	                       />").Append(Environment.NewLine);
                                sb.Append("              </CodeGroup>").Append(Environment.NewLine);
                            }


                            if (!blnSessionManager)
                            {
                                sb.Append("              <CodeGroup").Append(Environment.NewLine);
                                sb.Append("                      class=\"UnionCodeGroup\"").Append(Environment.NewLine);
                                sb.Append("                      version=\"1\"").Append(Environment.NewLine);
                                sb.Append("                      PermissionSetName=\"FullTrust\"").Append(Environment.NewLine);
                                sb.Append("                      Description=\"This code group grants Core.SessionManager full trust.\">").Append(Environment.NewLine);
                                sb.Append("                <IMembershipCondition").Append(Environment.NewLine);
                                sb.Append("                        class=\"UrlMembershipCondition\"").Append(Environment.NewLine);
                                sb.Append("                        version=\"1\"").Append(Environment.NewLine);
                                sb.Append("                        Url=\"").Append(txtdirectory.Text).Append("\\bin\\Core.SessionManager.dll\"").Append(Environment.NewLine);
                                sb.Append("	                       />").Append(Environment.NewLine);
                                sb.Append("              </CodeGroup>").Append(Environment.NewLine);
                            }

                            sb.Append(text).Append(Environment.NewLine);
                        }
                        else
                        {
                            sb.Append(text).Append(Environment.NewLine);
                        }
                    }
                    else
                    {
                        sb.Append(text).Append(Environment.NewLine);
                    }

                    text = sr.ReadLine();
                }

                sr.Dispose();

                var sw = new StreamWriter(txtdirectory.Text + "\\rssrvpolicy.config", false);
                sw.Write(sb.ToString());
                sw.Flush();
                sw.Dispose();
            }



        }


        private static Report[] GetReports(string folder)
        {
            var rdlreports = Directory.GetFiles(folder).Where(q => q.EndsWith(".rdl"));
            List<Report> reports = new List<Report>();

            foreach (var r in rdlreports)
            {
                var name = r.Substring(r.LastIndexOf("\\") + 1);
                name = name.Substring(0, name.IndexOf("."));


                Report tempReport;

                tempReport = new Report(name, "/Reports", r, "RenaissanceReports");
                reports.Add(tempReport);


            }


            return reports.ToArray();
        }

        private static void CreateReports(Report[] reports)
        {
            ReportingService2005 rsc =
                new ReportingService2005();

            rsc.Url = ApplicationState.Current.webservice + "/ReportService2005.asmx";

            rsc.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;



            foreach (Report aReport in reports)
            {

                Byte[] definition = null;
                Warning[] warnings = null;
                    
                try
                {
                    FileStream stream = File.OpenRead(aReport.Path);
                    definition = new Byte[stream.Length];
                    stream.Read(definition, 0, (int)stream.Length);
                    stream.Close();
                }

                catch (IOException e)
                {
                    //Logging.Log(e.Message);
                }

                try
                {

                    try
                    {
                        rsc.DeleteItem(aReport.Folder + "/" + aReport.Name);
                        Thread.Sleep(200);
                    }
                    catch (Exception e)
                    {

                    }

                    rsc.CreateReport(aReport.Name, aReport.Folder, true, definition, null);

                    #region Setting Report Data Source
                    //DataSourceReference reference = new DataSourceReference();
                    //reference.Reference = "RenaissanceReports"; // aReport.DataSource;
                    //DataSource[] dataSources = new DataSource[1];
                    //DataSource ds = new DataSource();
                    //ds.Item = (DataSourceDefinitionOrReference)reference;
                    //ds.Name = "/Data Sources" + "/" + "RenaissanceReports";
                    //dataSources[0] = ds;


                    //rsc.SetItemDataSources(aReport.Folder + "/" + aReport.Name, dataSources);//sets report to datasource


                    Thread.Sleep(400);



                    #endregion



                }
                catch (Exception e)
                {
                    Thread.Sleep(800);

                    try
                    {

                        try
                        {
                            rsc.DeleteItem(aReport.Folder + "/" + aReport.Name);
                            Thread.Sleep(200);
                        }
                        catch (Exception e1)
                        {

                        }


                        rsc.CreateReport(aReport.Name, aReport.Folder, true, definition, null);

                        #region Setting Report Data Source
                        DataSourceReference reference = new DataSourceReference();
                        reference.Reference = aReport.DataSource;
                        DataSource[] dataSources = new DataSource[1];
                        DataSource ds = new DataSource();
                        ds.Item = (DataSourceDefinitionOrReference)reference;
                        ds.Name = aReport.DataSource.Split('/').Last();
                        dataSources[0] = ds;
                        //rsc.SetReportDataSources(aReport.Folder + "/" + aReport.Name, dataSources);
                        #endregion
                    }
                    catch (Exception ex)
                    {
                    }

                    Thread.Sleep(400);

                }

            }

          

        }



        public void UnzipReportsFromStreamRDL(Stream zipStream, string outFolder)
        {

            ZipInputStream zipInputStream = new ZipInputStream(zipStream);
            ZipEntry zipEntry = zipInputStream.GetNextEntry();
            while (zipEntry != null)
            {
                String entryFileName = zipEntry.Name;
                // to remove the folder from the entry:- entryFileName = Path.GetFileName(entryFileName);
                // Optionally match entrynames against a selection list here to skip as desired.
                // The unpacked length is available in the zipEntry.Size property.

                byte[] buffer = new byte[4096];     // 4K is optimum

                // Manipulate the output filename here as desired.
                String fullZipToPath = System.IO.Path.Combine(outFolder, entryFileName);
                string directoryName = System.IO.Path.GetDirectoryName(fullZipToPath).Replace("\\Core_Reports", "");
                if (directoryName.Length > 0)
                    Directory.CreateDirectory(directoryName);

                // Skip directory entry
                string fileName = System.IO.Path.GetFileName(fullZipToPath);
                if (fileName.Length == 0)
                {
                    zipEntry = zipInputStream.GetNextEntry();
                    continue;
                }

                // Unzip file in buffered chunks. This is just as fast as unpacking to a buffer the full size
                // of the file, but does not waste memory.
                // The "using" will close the stream even if an exception occurs.
                using (FileStream streamWriter = File.Create(fullZipToPath.Replace("\\Core_Reports", "")))
                {
                    StreamUtils.Copy(zipInputStream, streamWriter, buffer);
                }
                zipEntry = zipInputStream.GetNextEntry();
            }
        }

        public void UnzipFromStreamRDL(Stream zipStream, string outFolder)
        {

            ZipInputStream zipInputStream = new ZipInputStream(zipStream);
            ZipEntry zipEntry = zipInputStream.GetNextEntry();
            while (zipEntry != null)
            {
                String entryFileName = zipEntry.Name;
                // to remove the folder from the entry:- entryFileName = Path.GetFileName(entryFileName);
                // Optionally match entrynames against a selection list here to skip as desired.
                // The unpacked length is available in the zipEntry.Size property.

                byte[] buffer = new byte[4096];     // 4K is optimum

                // Manipulate the output filename here as desired.
                String fullZipToPath = System.IO.Path.Combine(outFolder, entryFileName);
                string directoryName = System.IO.Path.GetDirectoryName(fullZipToPath).Replace("\\Core_Reports", "");


                // Skip directory entry
                string fileName = System.IO.Path.GetFileName(fullZipToPath);
                if (fileName.Length == 0)
                {
                    zipEntry = zipInputStream.GetNextEntry();
                    continue;
                }

                Directory.CreateDirectory(ApplicationState.Current.install_directory + "\\RDL\\");

                // Unzip file in buffered chunks. This is just as fast as unpacking to a buffer the full size
                // of the file, but does not waste memory.
                // The "using" will close the stream even if an exception occurs.
                using (FileStream streamWriter = File.Create(ApplicationState.Current.install_directory + "\\RDL\\" + fileName))
                {
                    StreamUtils.Copy(zipInputStream, streamWriter, buffer);
                }



                zipEntry = zipInputStream.GetNextEntry();
            }
        }


        public void UnzipReportsFromStreamReports(Stream zipStream, string outFolder)
        {

            ZipInputStream zipInputStream = new ZipInputStream(zipStream);
            ZipEntry zipEntry = zipInputStream.GetNextEntry();
            while (zipEntry != null)
            {
                String entryFileName = zipEntry.Name;
                // to remove the folder from the entry:- entryFileName = Path.GetFileName(entryFileName);
                // Optionally match entrynames against a selection list here to skip as desired.
                // The unpacked length is available in the zipEntry.Size property.

                byte[] buffer = new byte[4096];     // 4K is optimum

                // Manipulate the output filename here as desired.
                String fullZipToPath = System.IO.Path.Combine(outFolder, entryFileName);
                string directoryName = System.IO.Path.GetDirectoryName(fullZipToPath).Replace("\\Core_Reports", "");
                if (directoryName.Length > 0)
                    Directory.CreateDirectory(directoryName);

                // Skip directory entry
                string fileName = System.IO.Path.GetFileName(fullZipToPath);
                if (fileName.Length == 0)
                {
                    zipEntry = zipInputStream.GetNextEntry();
                    continue;
                }

                // Unzip file in buffered chunks. This is just as fast as unpacking to a buffer the full size
                // of the file, but does not waste memory.
                // The "using" will close the stream even if an exception occurs.
                using (FileStream streamWriter = File.Create(fullZipToPath.Replace("\\Core_Reports", "")))
                {
                    StreamUtils.Copy(zipInputStream, streamWriter, buffer);
                }
                zipEntry = zipInputStream.GetNextEntry();
            }
        }

        public void UnzipFromStreamReports(Stream zipStream, string outFolder)
        {

            ZipInputStream zipInputStream = new ZipInputStream(zipStream);
            ZipEntry zipEntry = zipInputStream.GetNextEntry();
            while (zipEntry != null)
            {
                String entryFileName = zipEntry.Name;
                // to remove the folder from the entry:- entryFileName = Path.GetFileName(entryFileName);
                // Optionally match entrynames against a selection list here to skip as desired.
                // The unpacked length is available in the zipEntry.Size property.

                byte[] buffer = new byte[4096];     // 4K is optimum

                // Manipulate the output filename here as desired.
                String fullZipToPath = System.IO.Path.Combine(outFolder, entryFileName);
                string directoryName = System.IO.Path.GetDirectoryName(fullZipToPath).Replace("\\Core_Reports", "");


                // Skip directory entry
                string fileName = System.IO.Path.GetFileName(fullZipToPath);
                if (fileName.Length == 0)
                {
                    zipEntry = zipInputStream.GetNextEntry();
                    continue;
                }



                // Unzip file in buffered chunks. This is just as fast as unpacking to a buffer the full size
                // of the file, but does not waste memory.
                // The "using" will close the stream even if an exception occurs.
                using (FileStream streamWriter = File.Create(outFolder + "\\" + fileName))
                {
                    StreamUtils.Copy(zipInputStream, streamWriter, buffer);
                }



                zipEntry = zipInputStream.GetNextEntry();
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new Directories();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void radioButton1_Click(object sender, RoutedEventArgs e)
        {
            radioButton.IsChecked = false;
            btnbrowse.IsEnabled = true;
            txtdirectory.IsEnabled = true;
            btnbrowse2.IsEnabled = true;
            txtdirectory2.IsEnabled = true;
        }

        private void radioButton_Click(object sender, RoutedEventArgs e)
        {
            radioButton1.IsChecked = false;
            btnbrowse.IsEnabled = false;
            txtdirectory.IsEnabled = false;
            btnbrowse2.IsEnabled = false;
            txtdirectory2.IsEnabled = false;
        }

        private void btnbrowse_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                txtdirectory.Text = dialog.SelectedPath;
            }
        }

        public static void DeleteDirectory(string target_dir)
        {
            string[] files = Directory.GetFiles(target_dir);
            string[] dirs = Directory.GetDirectories(target_dir);

            foreach (string file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }

            foreach (string dir in dirs)
            {
                DeleteDirectory(dir);
            }

            Directory.Delete(target_dir, false);
        }

        private void btnbrowse2_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                txtdirectory2.Text = dialog.SelectedPath;
            }
        }
    }
}
