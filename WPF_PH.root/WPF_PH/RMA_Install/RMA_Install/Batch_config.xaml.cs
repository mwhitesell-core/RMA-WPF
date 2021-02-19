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
using System.Security.Cryptography;
using System.Configuration;

namespace RMA_Install
{
    /// <summary>
    /// Interaction logic for Welcome1.xaml
    /// </summary>
    public partial class Batch_config : UserControl
    {
        public Batch_config()
        {
            InitializeComponent();

        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {

            ApplicationState.Current.install_batch = txtdirectory.Text;

            if (radioButton1.IsChecked == true)
            {

                build_config();

            }

            this.Content = new Complete();

        }



        private void build_config()
        {

            var sb = new StringBuilder("");

            sb.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>").Append(Environment.NewLine);
            sb.Append("<configuration>").Append(Environment.NewLine);
            sb.Append("  <configSections>").Append(Environment.NewLine);
            sb.Append("    <sectionGroup name=\"coreAppSettings\">").Append(Environment.NewLine);
            sb.Append("      <section name=\"Dictionaries\" type=\"Core.Framework.Core.Framework.ConfigSettingsReader,Core.Framework\" />").Append(Environment.NewLine);
            sb.Append("    </sectionGroup>").Append(Environment.NewLine);
            sb.Append("    <sectionGroup name=\"applicationSettings\" type=\"System.Configuration.ApplicationSettingsGroup, System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089\">").Append(Environment.NewLine);
            sb.Append("      <section name=\"RMA_Batch.Properties.Settings\" type=\"System.Configuration.ClientSettingsSection, System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089\" requirePermission=\"false\" />").Append(Environment.NewLine);
            sb.Append("    </sectionGroup>").Append(Environment.NewLine);
            sb.Append("  </configSections>").Append(Environment.NewLine);
            sb.Append("  <startup>").Append(Environment.NewLine);
            sb.Append("    <supportedRuntime version=\"v4.0\" sku=\".NETFramework,Version=v4.6.1\" />").Append(Environment.NewLine);
            sb.Append("  </startup>").Append(Environment.NewLine);
            sb.Append("  <appSettings>").Append(Environment.NewLine);
            sb.Append("    <add key=\"JobOutPut\" value=\"false\" />").Append(Environment.NewLine);
            sb.Append("    <add key=\"AlwaysUseSystemConnectionString\" value=\"true\" />").Append(Environment.NewLine);
            sb.Append("    <add key=\"SessionManager\" value=\"localhost:15124\" />").Append(Environment.NewLine);
            sb.Append("    <add key=\"UseMultipleConnectStrings\" value=\"True\" />").Append(Environment.NewLine);
            sb.Append("    <add key=\"AuthenticationDatabase\" value=\"SQL Server\" />").Append(Environment.NewLine);
            sb.Append("    <add key=\"SQLServerUseSchemas\" value=\"True\" />").Append(Environment.NewLine);
            sb.Append("    <add key=\"KeepSubFile\" value=\"true\" />").Append(Environment.NewLine);
            sb.Append("    <add key=\"SubFileSchema\" value=\"TEMPORARYDATA\" />").Append(Environment.NewLine);
            sb.Append("    <add key=\"SubfileKeepToText\" value=\"true\" />").Append(Environment.NewLine);
            sb.Append("    <add key=\"Culture\" value=\"SQL_Latin1_General_CP1_CI_AS\" />").Append(Environment.NewLine);
            sb.Append("    <add key=\"DeployedReportURL\" value=\"/Reports/\" />").Append(Environment.NewLine);
            sb.Append("    <add key=\"ReportQTPSchema\" value=\"101C\" />").Append(Environment.NewLine);
            sb.Append("    <add key=\"ClientSettingsProvider.ServiceUri\" value=\"\" />").Append(Environment.NewLine);
            sb.Append("    <add key=\"Version\" value=\"").Append(ConfigurationSettings.AppSettings["Version"].ToString()).Append("\" />").Append(Environment.NewLine);
            sb.Append("").Append(Environment.NewLine);
            sb.Append("").Append(Environment.NewLine);
            sb.Append("").Append(Environment.NewLine);
            sb.Append("").Append(Environment.NewLine);
            sb.Append("    <add key=\"ConnectionString1\" value=\"Initial Catalog=101C;Data Source=").Append(txtdirectory.Text).Append(";User ID=sa;Password=").Append(Encrypt(txtdirectory2.Text)).Append(";Integrated Security='false';\" />").Append(Environment.NewLine);
            sb.Append("    <add key=\"ConnectionString2\" value=\"Initial Catalog=MP;Data Source=").Append(txtdirectory.Text).Append(";User ID=sa;Password=").Append(Encrypt(txtdirectory2.Text)).Append(";Integrated Security='false';\" />").Append(Environment.NewLine);
            sb.Append("    <add key=\"ConnectionString3\" value=\"Initial Catalog=SOLO;Data Source=").Append(txtdirectory.Text).Append(";User ID=sa;Password=").Append(Encrypt(txtdirectory2.Text)).Append(";Integrated Security='false';\" />").Append(Environment.NewLine);

            sb.Append("    <add key=\"ConnectionString4\" value=\"Initial Catalog=101CD2;Data Source=").Append(txtdirectory.Text).Append(";User ID=sa;Password=").Append(Encrypt(txtdirectory2.Text)).Append(";Integrated Security='false';\" />").Append(Environment.NewLine);
            sb.Append("    <add key=\"ConnectionString5\" value=\"Initial Catalog=SOLOD2;Data Source=").Append(txtdirectory.Text).Append(";User ID=sa;Password=").Append(Encrypt(txtdirectory2.Text)).Append(";Integrated Security='false';\" />").Append(Environment.NewLine);
            sb.Append("    <add key=\"ConnectionString6\" value=\"Initial Catalog=101CD3;Data Source=").Append(txtdirectory.Text).Append(";User ID=sa;Password=").Append(Encrypt(txtdirectory2.Text)).Append(";Integrated Security='false';\" />").Append(Environment.NewLine);
            sb.Append("    <add key=\"ConnectionString7\" value=\"Initial Catalog=101CD4;Data Source=").Append(txtdirectory.Text).Append(";User ID=sa;Password=").Append(Encrypt(txtdirectory2.Text)).Append(";Integrated Security='false';\" />").Append(Environment.NewLine);
            sb.Append("    <add key=\"ConnectionString8\" value=\"Initial Catalog=101CD5;Data Source=").Append(txtdirectory.Text).Append(";User ID=sa;Password=").Append(Encrypt(txtdirectory2.Text)).Append(";Integrated Security='false';\" />").Append(Environment.NewLine);

            sb.Append("    <add key=\"LoggingConnectionString\" value=\"Initial Catalog=Logging;Data Source=").Append(txtdirectory.Text).Append(";User ID=sa;Password=").Append(Encrypt(txtdirectory2.Text)).Append(";Integrated Security='false';\" />").Append(Environment.NewLine);
            sb.Append("    <add key=\"SecurityConnectionString\" value=\"Initial Catalog=Security;Data Source=").Append(txtdirectory.Text).Append(";User ID=sa;Password=").Append(Encrypt(txtdirectory2.Text)).Append(";Integrated Security='false';\" />").Append(Environment.NewLine);

            sb.Append("    <add key=\"Default_Batch_File_Directory\" value=\"").Append(ApplicationState.Current.install_directory).Append("\\Batch_Files\"/>").Append(Environment.NewLine);
            sb.Append("    <add key=\"QuizStats\" value=\"").Append(ApplicationState.Current.install_directory).Append("\\alpha\\rmabill\\QuizStats\"/>").Append(Environment.NewLine);
            sb.Append("    <add key=\"FlatFilePath\" value=\"").Append(ApplicationState.Current.install_directory).Append("\\Subfiles\" />").Append(Environment.NewLine);
            sb.Append("    <add key=\"ReportPath\" value=\"").Append(ApplicationState.Current.install_directory).Append("\\UserID\" />").Append(Environment.NewLine);
            sb.Append("    <add key=\"RE2005\" value=\"").Append(ApplicationState.Current.webservice).Append("/ReportExecution2005.asmx").Append("\" />").Append(Environment.NewLine);
            sb.Append("    <add key=\"RS2005\" value=\"").Append(ApplicationState.Current.webservice).Append("/ReportService2005.asmx").Append("\" />").Append(Environment.NewLine);
            sb.Append("    <add key=\"FlatFileDictionary\" value=\"").Append(ApplicationState.Current.install_directory).Append("\\FlatFileDictionary\" />").Append(Environment.NewLine);
            //sb.Append("    <add key=\"UseBitMiracle\" value=\"True\" />").Append(Environment.NewLine);

            sb.Append("").Append(Environment.NewLine);
            sb.Append("").Append(Environment.NewLine);
            sb.Append("  </appSettings>").Append(Environment.NewLine);
            sb.Append("").Append(Environment.NewLine);
            sb.Append("  <coreAppSettings>").Append(Environment.NewLine);
            sb.Append("    <Dictionaries>").Append(Environment.NewLine);
            sb.Append("").Append(Environment.NewLine);
            sb.Append("      <add key=\"en-ca\" value=\"").Append(ApplicationState.Current.install_directory).Append("\\RMA_Batch\\CoreXML\\Dictionary_EN-CA.xml\" />").Append(Environment.NewLine);
            sb.Append("").Append(Environment.NewLine);
            sb.Append("    </Dictionaries>").Append(Environment.NewLine);
            sb.Append("").Append(Environment.NewLine);
            sb.Append("  </coreAppSettings>").Append(Environment.NewLine);
            sb.Append("").Append(Environment.NewLine);
            sb.Append("  <system.serviceModel>").Append(Environment.NewLine);
            sb.Append("    <bindings />").Append(Environment.NewLine);
            sb.Append("    <client />").Append(Environment.NewLine);
            sb.Append("  </system.serviceModel>").Append(Environment.NewLine);
            sb.Append("").Append(Environment.NewLine);
            sb.Append("  <applicationSettings>").Append(Environment.NewLine);
            sb.Append("    <RMA_Batch.Properties.Settings>").Append(Environment.NewLine);
            sb.Append("").Append(Environment.NewLine);
            sb.Append("      <setting name=\"RMA_Batch_RE2005_ReportExecutionService\" serializeAs=\"String\">").Append(Environment.NewLine);
            sb.Append("        <value>").Append(ApplicationState.Current.webservice).Append("/ReportExecution2005.asmx</value>").Append(Environment.NewLine);
            sb.Append("      </setting>").Append(Environment.NewLine);
            sb.Append("      <setting name=\"RMA_Batch_RS2005_ReportingService2005\" serializeAs=\"String\">").Append(Environment.NewLine);
            sb.Append("        <value>").Append(ApplicationState.Current.webservice).Append("/ReportService2005.asmx</value>").Append(Environment.NewLine);
            sb.Append("      </setting>").Append(Environment.NewLine);
            sb.Append("").Append(Environment.NewLine);
            sb.Append("    </RMA_Batch.Properties.Settings>").Append(Environment.NewLine);
            sb.Append("  </applicationSettings>").Append(Environment.NewLine);
            sb.Append("").Append(Environment.NewLine);
            sb.Append("  <system.web>").Append(Environment.NewLine);
            sb.Append("    <membership defaultProvider=\"ClientAuthenticationMembershipProvider\">").Append(Environment.NewLine);
            sb.Append("      <providers>").Append(Environment.NewLine);
            sb.Append("        <add name=\"ClientAuthenticationMembershipProvider\" type=\"System.Web.ClientServices.Providers.ClientFormsAuthenticationMembershipProvider, System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\" serviceUri=\"\" />").Append(Environment.NewLine);
            sb.Append("      </providers>").Append(Environment.NewLine);
            sb.Append("    </membership>").Append(Environment.NewLine);
            sb.Append("    <roleManager defaultProvider=\"ClientRoleProvider\" enabled=\"true\">").Append(Environment.NewLine);
            sb.Append("      <providers>").Append(Environment.NewLine);
            sb.Append("        <add name=\"ClientRoleProvider\" type=\"System.Web.ClientServices.Providers.ClientRoleProvider, System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\" serviceUri=\"\" cacheTimeout=\"86400\" />").Append(Environment.NewLine);
            sb.Append("      </providers>").Append(Environment.NewLine);
            sb.Append("    </roleManager>").Append(Environment.NewLine);
            sb.Append("  </system.web>").Append(Environment.NewLine);
            sb.Append("</configuration>").Append(Environment.NewLine);

            var sw = new StreamWriter(ApplicationState.Current.install_directory + "\\RMA_Batch\\RMA_Batch.exe.config", false);
            sw.Write(sb.ToString());
            sw.Flush();
            sw.Dispose();

        }


        public static byte[] Key = {
                                       23,
                                       22,
                                       86,
                                       33,
                                       11,
                                       3,
                                       67,
                                       21,
                                       21,
                                       53,
                                       8,
                                       98,
                                       249,
                                       43,
                                       98,
                                       103,
                                       38,
                                       104,
                                       105,
                                       43,
                                       222,
                                       34,
                                       45,
                                       89
                                   };

        public static byte[] Iv = {
                                      45,
                                      11,
                                      45,
                                      37,
                                      42,
                                      68,
                                      102,
                                      79
                                  };
        public static string Encrypt(string PlainText)
        {
            // Declare a UTF8Encoding object so we may use the GetByte 
            // method to transform the plainText into a Byte array. 
            var utf8encoder = new UTF8Encoding();
            byte[] inputInBytes = utf8encoder.GetBytes(PlainText);

            // Create a new TripleDES service provider 
            var tdesProvider = new TripleDESCryptoServiceProvider();

            // The ICryptTransform interface uses the TripleDES 
            // crypt provider along with encryption key and init vector 
            // information 

            ICryptoTransform cryptoTransform = null;

            cryptoTransform = tdesProvider.CreateEncryptor(Key, Iv);


            // All cryptographic functions need a stream to output the 
            // encrypted information. Here we declare a memory stream 
            // for this purpose. 
            var encryptedStream = new MemoryStream();
            var cryptStream = new CryptoStream(encryptedStream, cryptoTransform, CryptoStreamMode.Write);
            string strResult = null;

            // Write the encrypted information to the stream. Flush the information 
            // when done to ensure everything is out of the buffer. 
            cryptStream.Write(inputInBytes, 0, inputInBytes.Length);
            cryptStream.FlushFinalBlock();
            encryptedStream.Position = 0;

            // Read the stream back into a Byte array and return it to the calling 
            // method. 
            var bytResultBytes = new byte[Convert.ToInt16(encryptedStream.Length)];

            encryptedStream.Read(bytResultBytes, 0, Convert.ToInt16(encryptedStream.Length));
            cryptStream.Close();
            encryptedStream.Close();
            strResult = Convert.ToBase64String(bytResultBytes);
            return strResult;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new Batch();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void radioButton1_Click(object sender, RoutedEventArgs e)
        {
            radioButton.IsChecked = false;
            txtdirectory.IsEnabled = true;
            txtdirectory2.IsEnabled = true;
        }

        private void radioButton_Click(object sender, RoutedEventArgs e)
        {
            radioButton1.IsChecked = false;
            txtdirectory.IsEnabled = false;
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
    }
}
