using Core.Framework;
using Core.RDL.DataSetExtension;
using Core.ReportFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ExecuteDataClass
{
    public partial class TestRDLReportAssembly : Form
    {
        private void TestRDLReportAssembly_Load(object sender, EventArgs e)
        {
            StreamReader sr;
            string line = string.Empty;

            try
            {
                //Check if the setup.config file exists
                if (File.Exists("Setup.config"))
                {
                    sr = new StreamReader("Setup.config");

                    //Read the config file
                    line = sr.ReadLine();
                    while (line != null)
                    {
                        switch (line.Substring(0, line.IndexOf(">")).Trim().ToUpper())
                        {
                            case "CONFIGFILE":
                                txtConfigurationFile.Text = line.Substring(line.IndexOf(">") + 1).Trim();
                                break;

                            case "CONNECTIONSTRING":
                                txtConnectionString.Text = line.Substring(line.IndexOf(">") + 1).Trim();
                                break;

                            case "DATFILELOCATION":
                                txtDATFileLocation.Text = line.Substring(line.IndexOf(">") + 1).Trim();
                                break;

                            case "FLATFILEDICTIONARY":
                                txtFlatFileDictionary.Text = line.Substring(line.IndexOf(">") + 1).Trim();
                                break;

                            case "PARAMETER1":
                                txtParameter1.Text = line.Substring(line.IndexOf(">") + 1).Trim();
                                break;

                            case "PARAMETER2":
                                txtParameter2.Text = line.Substring(line.IndexOf(">") + 1).Trim();
                                break;

                            case "PARAMETER3":
                                txtParameter3.Text = line.Substring(line.IndexOf(">") + 1).Trim();
                                break;

                            case "PARAMETER4":
                                txtParameter4.Text = line.Substring(line.IndexOf(">") + 1).Trim();
                                break;

                            case "PARAMETER5":
                                txtParameter5.Text = line.Substring(line.IndexOf(">") + 1).Trim();
                                break;

                            case "PARAMETER6":
                                txtParameter6.Text = line.Substring(line.IndexOf(">") + 1).Trim();
                                break;

                            case "PARAMETER7":
                                txtParameter7.Text = line.Substring(line.IndexOf(">") + 1).Trim();
                                break;

                            case "PARAMETER8":
                                txtParameter8.Text = line.Substring(line.IndexOf(">") + 1).Trim();
                                break;

                            case "PARAMETER9":
                                txtParameter9.Text = line.Substring(line.IndexOf(">") + 1).Trim();
                                break;

                            case "PARAMETER10":
                                txtParameter10.Text = line.Substring(line.IndexOf(">") + 1).Trim();
                                break;

                            case "PARAMETER11":
                                txtParameter11.Text = line.Substring(line.IndexOf(">") + 1).Trim();
                                break;

                            case "PARAMETER12":
                                txtParameter12.Text = line.Substring(line.IndexOf(">") + 1).Trim();
                                break;

                            case "PARAMETER13":
                                txtParameter13.Text = line.Substring(line.IndexOf(">") + 1).Trim();
                                break;

                            case "PARAMETER14":
                                txtParameter14.Text = line.Substring(line.IndexOf(">") + 1).Trim();
                                break;

                            case "PARAMETER15":
                                txtParameter15.Text = line.Substring(line.IndexOf(">") + 1).Trim();
                                break;

                            case "PARAMETER16":
                                txtParameter16.Text = line.Substring(line.IndexOf(">") + 1).Trim();
                                break;

                            case "PARAMETER17":
                                txtParameter17.Text = line.Substring(line.IndexOf(">") + 1).Trim();
                                break;

                            case "PARAMETER18":
                                txtParameter18.Text = line.Substring(line.IndexOf(">") + 1).Trim();
                                break;

                            case "PARAMETER19":
                                txtParameter19.Text = line.Substring(line.IndexOf(">") + 1).Trim();
                                break;

                            case "PARAMETER20":
                                txtParameter20.Text = line.Substring(line.IndexOf(">") + 1).Trim();
                                break;

                            case "PARAMETER21":
                                txtParameter21.Text = line.Substring(line.IndexOf(">") + 1).Trim();
                                break;

                            case "PARAMETER22":
                                txtParameter22.Text = line.Substring(line.IndexOf(">") + 1).Trim();
                                break;

                            case "PARAMETER23":
                                txtParameter23.Text = line.Substring(line.IndexOf(">") + 1).Trim();
                                break;

                            case "PARAMETER24":
                                txtParameter24.Text = line.Substring(line.IndexOf(">") + 1).Trim();
                                break;

                            case "PARAMETER25":
                                txtParameter25.Text = line.Substring(line.IndexOf(">") + 1).Trim();
                                break;

                            case "PARAMETER26":
                                txtParameter26.Text = line.Substring(line.IndexOf(">") + 1).Trim();
                                break;

                            case "PARAMETER27":
                                txtParameter27.Text = line.Substring(line.IndexOf(">") + 1).Trim();
                                break;

                            case "PARAMETER28":
                                txtParameter28.Text = line.Substring(line.IndexOf(">") + 1).Trim();
                                break;

                            case "PARAMETER29":
                                txtParameter29.Text = line.Substring(line.IndexOf(">") + 1).Trim();
                                break;

                            case "PARAMETER30":
                                txtParameter30.Text = line.Substring(line.IndexOf(">") + 1).Trim();
                                break;

                            case "PROJECT":
                                txtProject.Text = line.Substring(line.IndexOf(">") + 1).Trim();
                                break;

                            case "REPORTASSEMBLY":
                                txtReportAssembly.Text = line.Substring(line.IndexOf(">") + 1).Trim();
                                break;

                            case "TEXTFILEFOLDER":
                                txtTextFileLocation.Text = line.Substring(line.IndexOf(">") + 1).Trim();
                                break;

                            case "USERDLEXTENSION":
                                if (line.Substring(line.IndexOf(">") + 1).Trim() == "Yes")
                                {
                                    chkUseRDLExtension.Checked = true;
                                }
                                else
                                {
                                    chkUseRDLExtension.Checked = false;
                                }
                                break;

                            case "WRITELOGFILE":
                                if (line.Substring(line.IndexOf(">") + 1).Trim() == "Yes")
                                {
                                    chkWriteToTextFile.Checked = true;
                                }
                                else
                                {
                                    chkWriteToTextFile.Checked = false;
                                }
                                break;
                        }

                        line = sr.ReadLine();
                    }

  
                    sr.Close();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public TestRDLReportAssembly()
        {
            InitializeComponent();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            //Save the config settings
            SaveConfigSettings();

            try
            {

                //Check necessary fields have value.
                if (FieldsPopulated())
                {
                    cmboDataClass.SelectedIndex = cmboDataClass.FindString(cmboDataClass.Text.ToUpper());

                    Core.RDL.DataSetExtension.DSXConnection objDSXConnection;
                    Core.RDL.DataSetExtension.DSXCommand objDSXCommand = new Core.RDL.DataSetExtension.DSXCommand();
                    Core.RDL.DataSetExtension.DSXParameter objDSXParameter = new Core.RDL.DataSetExtension.DSXParameter();
                    Core.RDL.DataSetExtension.DSXParameterCollection objDSXParameterCollection;

                    ReportFunctions.strReportLogPath = string.Empty;

                    Microsoft.ReportingServices.DataProcessing.IDataReader irdr;

                    string[] arrParameters = new String[35];
                    string parm = String.Empty;

                    objDSXParameterCollection = new DSXParameterCollection();

                    System.Data.DataSet drdr = new System.Data.DataSet();

                    //Set the size of the array based on the number of parameters entered.
                    for (int i = 1; i <= 35; i++)
                    {
                        parm = string.Empty;

                        switch (i)
                        {
                            case 1:
                                arrParameters[0] = "1";
                                objDSXParameterCollection.Add("SESSION", "1");
                                break;
                            case 2:
                                arrParameters[1] = "101C";
                                objDSXParameterCollection.Add("DEFAULT_SCHEMA", "101C");
                                break;
                            case 3:
                                arrParameters[2] = "EN";
                                objDSXParameterCollection.Add("LANGUAGE", "EN");
                                break;
                            case 4:
                                arrParameters[3] = "TESTER";
                                objDSXParameterCollection.Add("REPORTED_BY", "TESTER");
                                break;
                            case 5:
                                arrParameters[4] = txtDATFileLocation.Text;
                                objDSXParameterCollection.Add("CURRENTDIRECTORY", txtDATFileLocation.Text);
                                break;
                            case 6:
                                arrParameters[5] = txtParameter1.Text;
                                objDSXParameterCollection.Add("PARM_1", txtParameter1.Text);
                                break;
                            case 7:
                                arrParameters[6] = txtParameter2.Text;
                                objDSXParameterCollection.Add("PARM_2", txtParameter2.Text);
                                break;
                            case 8:
                                arrParameters[7] = txtParameter3.Text;
                                objDSXParameterCollection.Add("PARM_3", txtParameter3.Text);
                                break;
                            case 9:
                                arrParameters[8] = txtParameter4.Text;
                                objDSXParameterCollection.Add("PARM_4", txtParameter4.Text);
                                break;
                            case 10:
                                arrParameters[9] = txtParameter5.Text;
                                objDSXParameterCollection.Add("PARM_5", txtParameter5.Text);
                                break;
                            case 11:
                                arrParameters[10] = txtParameter6.Text;
                                objDSXParameterCollection.Add("PARM_6", txtParameter6.Text);
                                break;
                            case 12:
                                arrParameters[11] = txtParameter7.Text;
                                objDSXParameterCollection.Add("PARM_7", txtParameter7.Text);
                                break;
                            case 13:
                                arrParameters[12] = txtParameter8.Text;
                                objDSXParameterCollection.Add("PARM_8", txtParameter8.Text);
                                break;
                            case 14:
                                arrParameters[13] = txtParameter9.Text;
                                objDSXParameterCollection.Add("PARM_9", txtParameter9.Text);
                                break;
                            case 15:
                                arrParameters[14] = txtParameter10.Text;
                                objDSXParameterCollection.Add("PARM_10", txtParameter10.Text);
                                break;
                            case 16:
                                arrParameters[15] = txtParameter11.Text;
                                objDSXParameterCollection.Add("PARM_11", txtParameter11.Text);
                                break;
                            case 17:
                                arrParameters[16] = txtParameter12.Text;
                                objDSXParameterCollection.Add("PARM_12", txtParameter12.Text);
                                break;
                            case 18:
                                arrParameters[17] = txtParameter13.Text;
                                objDSXParameterCollection.Add("PARM_13", txtParameter13.Text);
                                break;
                            case 19:
                                arrParameters[18] = txtParameter14.Text;
                                objDSXParameterCollection.Add("PARM_14", txtParameter14.Text);
                                break;
                            case 20:
                                arrParameters[19] = txtParameter15.Text;
                                objDSXParameterCollection.Add("PARM_15", txtParameter15.Text);
                                break;
                            case 21:
                                arrParameters[20] = txtParameter16.Text;
                                objDSXParameterCollection.Add("PARM_16", txtParameter16.Text);
                                break;
                            case 22:
                                arrParameters[21] = txtParameter17.Text;
                                objDSXParameterCollection.Add("PARM_17", txtParameter17.Text);
                                break;
                            case 23:
                                arrParameters[22] = txtParameter18.Text;
                                objDSXParameterCollection.Add("PARM_18", txtParameter18.Text);
                                break;
                            case 24:
                                arrParameters[23] = txtParameter19.Text;
                                objDSXParameterCollection.Add("PARM_19", txtParameter19.Text);
                                break;
                            case 25:
                                arrParameters[24] = txtParameter20.Text;
                                objDSXParameterCollection.Add("PARM_20", txtParameter20.Text);
                                break;
                            case 26:
                                arrParameters[25] = txtParameter21.Text;
                                objDSXParameterCollection.Add("PARM_21", txtParameter21.Text);
                                break;
                            case 27:
                                arrParameters[26] = txtParameter22.Text;
                                objDSXParameterCollection.Add("PARM_22", txtParameter22.Text);
                                break;
                            case 28:
                                arrParameters[27] = txtParameter23.Text;
                                objDSXParameterCollection.Add("PARM_23", txtParameter23.Text);
                                break;
                            case 29:
                                arrParameters[28] = txtParameter24.Text;
                                objDSXParameterCollection.Add("PARM_24", txtParameter24.Text);
                                break;
                            case 30:
                                arrParameters[29] = txtParameter25.Text;
                                objDSXParameterCollection.Add("PARM_25", txtParameter25.Text);
                                break;
                            case 31:
                                arrParameters[30] = txtParameter26.Text;
                                objDSXParameterCollection.Add("PARM_26", txtParameter26.Text);
                                break;
                            case 32:
                                arrParameters[31] = txtParameter27.Text;
                                objDSXParameterCollection.Add("PARM_27", txtParameter27.Text);
                                break;
                            case 33:
                                arrParameters[32] = txtParameter28.Text;
                                objDSXParameterCollection.Add("PARM_28", txtParameter28.Text);
                                break;
                            case 34:
                                arrParameters[33] = txtParameter29.Text;
                                objDSXParameterCollection.Add("PARM_29", txtParameter29.Text);
                                break;
                            case 35:
                                arrParameters[34] = txtParameter30.Text;
                                objDSXParameterCollection.Add("PARM_30", txtParameter30.Text);
                                break;
                        }

                    }

                    ReportFunctions.m_strFlatFileDictionary = txtFlatFileDictionary.Text;
                    ReportFunctions.m_strFlatFilePath = txtDATFileLocation.Text;

                    string filePath = txtTextFileLocation.Text;

                    if (filePath.EndsWith("\\") == false)
                        filePath += "\\";

                    //m_strGenericRetrievalCharacter = String.Empty;

                    if (chkUseRDLExtension.Checked == true)
                    {
                        objDSXConnection = new Core.RDL.DataSetExtension.DSXConnection();
                        objDSXConnection.ConnectionString = txtConnectionString.Text;

                        //Get the configuration
                        string configuration;
                        XmlDocument xmlDoc = new XmlDocument();

                        xmlDoc.Load(txtConfigurationFile.Text);
                        XmlNode node = xmlDoc.DocumentElement.SelectSingleNode("/Configuration/Extensions/Data/Extension/Configuration/ExtensionData");

                        configuration = node.OuterXml;

                        objDSXConnection.SetConfiguration(configuration);
                        objDSXConnection.CreateCommand();

                        objDSXCommand = new Core.RDL.DataSetExtension.DSXCommand(objDSXConnection, configuration);
                        objDSXCommand.CommandType = Microsoft.ReportingServices.DataProcessing.CommandType.Text;
                        objDSXCommand.CommandText = txtProject.Text + "~" + cmboDataClass.SelectedItem.ToString();
                        objDSXCommand.NewParameters = objDSXParameterCollection;

                        irdr = objDSXCommand.ExecuteReader(Microsoft.ReportingServices.DataProcessing.CommandBehavior.SchemaOnly);

                        if (chkWriteToTextFile.Checked == true)
                            WriteExtensionDataToFile(irdr, filePath + cmboDataClass.SelectedItem.ToString() + ".txt");
                    }
                    else
                    {
                        ReportFunctions.strDatabaseType = "SQLServer";


                        drdr = new System.Data.DataSet();

                        //Execute the data class
                        switch (cmboDataClass.SelectedItem.ToString().ToUpper())
                        {
                            case "ABE":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.ABE obj = new RMA_DATA.ABE();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "ADDRLABELS":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.ADDRLABELS obj = new RMA_DATA.ADDRLABELS();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "ADVOUT":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.ADVOUT obj = new RMA_DATA.ADVOUT();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "AUDIT_F050HIST":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.AUDIT_F050HIST obj = new RMA_DATA.AUDIT_F050HIST();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "AUDIT_F050TPHIST":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.AUDIT_F050TPHIST obj = new RMA_DATA.AUDIT_F050TPHIST();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "AUDITDOC1":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.AUDITDOC1 obj = new RMA_DATA.AUDITDOC1();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "AUDITDOC2":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.AUDITDOC2 obj = new RMA_DATA.AUDITDOC2();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "BALLOT":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.BALLOT obj = new RMA_DATA.BALLOT();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "BILLINGLIST":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.BILLINGLIST obj = new RMA_DATA.BILLINGLIST();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "CHECK_F001_F002_ALL_1":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.CHECK_F001_F002_ALL_1 obj = new RMA_DATA.CHECK_F001_F002_ALL_1();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "CHECK_F001_F002_ALL_2":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.CHECK_F001_F002_ALL_2 obj = new RMA_DATA.CHECK_F001_F002_ALL_2();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;
                            case "CHECK_F001_F002_ALL_3":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.CHECK_F001_F002_ALL_3 obj = new RMA_DATA.CHECK_F001_F002_ALL_3();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;
                            case "CHECK_F001_F002_ALL_4":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.CHECK_F001_F002_ALL_4 obj = new RMA_DATA.CHECK_F001_F002_ALL_4();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;
                            case "CHECK_F001_F002_ALL_5":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.CHECK_F001_F002_ALL_5 obj = new RMA_DATA.CHECK_F001_F002_ALL_5();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;
                            case "CHECK_F001_F002_ALL_6":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.CHECK_F001_F002_ALL_6 obj = new RMA_DATA.CHECK_F001_F002_ALL_6();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;
                            case "CHECK_F001_F002_ALL_7":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.CHECK_F001_F002_ALL_7 obj = new RMA_DATA.CHECK_F001_F002_ALL_7();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;
                            case "CHECK_F001_F002_ALL_8":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.CHECK_F001_F002_ALL_8 obj = new RMA_DATA.CHECK_F001_F002_ALL_8();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;
                            case "CHECK_F001_F002_ALL_9":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.CHECK_F001_F002_ALL_9 obj = new RMA_DATA.CHECK_F001_F002_ALL_9();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;
                            case "CHECK_F001_F002_ALL_10":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.CHECK_F001_F002_ALL_10 obj = new RMA_DATA.CHECK_F001_F002_ALL_10();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;
                            case "CHECKF002_ADJ_SUB_TYPE__PASS1":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.CHECKF002_ADJ_SUB_TYPE__PASS1 obj = new RMA_DATA.CHECKF002_ADJ_SUB_TYPE__PASS1();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;
                            case "CHECKF002_ADJ_SUB_TYPE__PASS2":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.CHECKF002_ADJ_SUB_TYPE__PASS2 obj = new RMA_DATA.CHECKF002_ADJ_SUB_TYPE__PASS2();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;
                            case "CHECKF002_ADJ_SUB_TYPE__PASS3":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.CHECKF002_ADJ_SUB_TYPE__PASS3 obj = new RMA_DATA.CHECKF002_ADJ_SUB_TYPE__PASS3();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;
                            case "CHECK_SUSP_DTL":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.CHECK_SUSP_DTL obj = new RMA_DATA.CHECK_SUSP_DTL();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "COSTING_F119":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.COSTING_F119HIST obj = new RMA_DATA.COSTING_F119HIST();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "COSTING11":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.COSTING11 obj = new RMA_DATA.COSTING11();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "CREATE_CLAIMS_SUBA":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.CREATE_CLAIMS_SUBA obj = new RMA_DATA.CREATE_CLAIMS_SUBA();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "CREATE_CLAIMS_SUBB":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.CREATE_CLAIMS_SUBB obj = new RMA_DATA.CREATE_CLAIMS_SUBB();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "CREATE_CLAIMS_SUBC":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.CREATE_CLAIMS_SUBC obj = new RMA_DATA.CREATE_CLAIMS_SUBC();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "DEBUGU114":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.DEBUGU114 obj = new RMA_DATA.DEBUGU114();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "DEBUGU116CD1":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.DEBUGU116CD1 obj = new RMA_DATA.DEBUGU116CD1();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "DEBUGU116CD2":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.DEBUGU116CD2 obj = new RMA_DATA.DEBUGU116CD2();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "DEBUGU116CD34":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.DEBUGU116CD34 obj = new RMA_DATA.DEBUGU116CD34();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "DIFFAMT":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.DIFFAMT obj = new RMA_DATA.DIFFAMT();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "DIFFDATE":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.DIFFDATE obj = new RMA_DATA.DIFFDATE();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "DOCPAYCODE":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.DOCPAYCODE obj = new RMA_DATA.DOCPAYCODE();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "DOCPAYCODE1":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.DOCPAYCODE1 obj = new RMA_DATA.DOCPAYCODE1();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "DOCREV":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.DOCREV obj = new RMA_DATA.DOCREV();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "DOCREVALL":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.DOCREVALL obj = new RMA_DATA.DOCREVALL();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "DOCTORLIST":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.DOCTORLIST obj = new RMA_DATA.DOCTORLIST();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "DRCHAUDHARY_REJECTS":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.DRCHAUDHARY_REJECTS obj = new RMA_DATA.DRCHAUDHARY_REJECTS();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "DUMP_TECH1":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.DUMP_TECH1 obj = new RMA_DATA.DUMP_TECH1();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "DUMP_TECH2":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.DUMP_TECH2 obj = new RMA_DATA.DUMP_TECH2();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "DUMPF119":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.DUMPF119 obj = new RMA_DATA.DUMPF119();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "DUMPF119YTD":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.DUMPF119YTD obj = new RMA_DATA.DUMPF119YTD();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "EMERGENCY_PAYROLL_CLMHDRID_1":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.EMERGENCY_PAYROLL_CLMHDRID_1 obj = new RMA_DATA.EMERGENCY_PAYROLL_CLMHDRID_1();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "EMERGENCY_PAYROLL_CLMHDRID_2":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.EMERGENCY_PAYROLL_CLMHDRID_2 obj = new RMA_DATA.EMERGENCY_PAYROLL_CLMHDRID_2();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "EMERGENCY_PAYROLL_CLMHDRID_3":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.EMERGENCY_PAYROLL_CLMHDRID_3 obj = new RMA_DATA.EMERGENCY_PAYROLL_CLMHDRID_3();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "F087_PEDS_REJECTS_BY_ERRCODE":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.F087_PEDS_REJECTS_BY_ERRCODE obj = new RMA_DATA.F087_PEDS_REJECTS_BY_ERRCODE();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "G040_CODE":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.G040_CODE obj = new RMA_DATA.G040_CODE();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "G271_CODE":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.G271_CODE obj = new RMA_DATA.G271_CODE();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "GERIATRIC":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.GERIATRIC obj = new RMA_DATA.GERIATRIC();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "GSTREJ":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.GSTREJ obj = new RMA_DATA.GSTREJ();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "K037_CODE":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.K037_CODE obj = new RMA_DATA.K037_CODE();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "KATHYF001STATUS":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.KATHYF001STATUS obj = new RMA_DATA.KATHYF001STATUS();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "MARYACADEM":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.MARYACADEM obj = new RMA_DATA.MARYACADEM();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "MARYDEPCHR":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.MARYDEPCHR obj = new RMA_DATA.MARYDEPCHR();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "MARYGSTTAX":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.MARYGSTTAX obj = new RMA_DATA.MARYGSTTAX();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "MARYPERC":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.MARYPERC obj = new RMA_DATA.MARYPERC();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "MARYRMACHR":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.MARYRMACHR obj = new RMA_DATA.MARYRMACHR();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "MARYSHIFT":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.MARYSHIFT obj = new RMA_DATA.MARYSHIFT();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "MP_PAYMENTS":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.MP_PAYMENTS obj = new RMA_DATA.MP_PAYMENTS();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "MP_R119A":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.MP_R119A obj = new RMA_DATA.MP_R119A();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "MP_R119B":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.MP_R119B obj = new RMA_DATA.MP_R119B();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "MP_R119C":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.MP_R119C obj = new RMA_DATA.MP_R119C();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "MP_R121A":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.MP_R121A obj = new RMA_DATA.MP_R121A();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "MP_R121B":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.MP_R121B obj = new RMA_DATA.MP_R121B();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "MP_R121C":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.MP_R121C obj = new RMA_DATA.MP_R121C();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "MP_R121D":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.MP_R121D obj = new RMA_DATA.MP_R121D();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "MP_R121E":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.MP_R121E obj = new RMA_DATA.MP_R121E();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "MP_R121F":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.MP_R121F obj = new RMA_DATA.MP_R121F();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "MP_R137A":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.MP_R137A obj = new RMA_DATA.MP_R137A();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;
                            case "MP_R137B":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.MP_R137B obj = new RMA_DATA.MP_R137B();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "MP_UTL0101":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.MP_UTL0101 obj = new RMA_DATA.MP_UTL0101();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "MP_UTL0201_1":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.MP_UTL0201_1 obj = new RMA_DATA.MP_UTL0201_1();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "MP_UTL0201_2":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.MP_UTL0201_2 obj = new RMA_DATA.MP_UTL0201_2();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "MP_UTL0201_3":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.MP_UTL0201_3 obj = new RMA_DATA.MP_UTL0201_3();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "OVPAY":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.OVPAY obj = new RMA_DATA.OVPAY();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "PAYCODE1A_CEILINGS":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.PAYCODE1A_CEILINGS obj = new RMA_DATA.PAYCODE1A_CEILINGS();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "PAYEFT":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.PAYEFT obj = new RMA_DATA.PAYEFT();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "PAYROLLLIST":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.PAYROLLLIST obj = new RMA_DATA.PAYROLLLIST();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "PROXY":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.PROXY obj = new RMA_DATA.PROXY();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R004A":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R004A obj = new RMA_DATA.R004A();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R004ATP":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R004ATP obj = new RMA_DATA.R004ATP();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R004ATP_70":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R004ATP_70 obj = new RMA_DATA.R004ATP_70();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R004B":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R004B obj = new RMA_DATA.R004B();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R004BTP":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R004BTP obj = new RMA_DATA.R004BTP();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R004BTP_70":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R004BTP_70 obj = new RMA_DATA.R004BTP_70();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R004BTP_PORTAL":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R004BTP_PORTAL obj = new RMA_DATA.R004BTP_PORTAL();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R004C":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R004C obj = new RMA_DATA.R004C();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R004C_PORTAL":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R004C_PORTAL obj = new RMA_DATA.R004C_PORTAL();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R004C_PORTAL_SS":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R004C_PORTAL_SS obj = new RMA_DATA.R004C_PORTAL_SS();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R004CTP":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R004CTP obj = new RMA_DATA.R004CTP();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R004CTP_70":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R004CTP_70 obj = new RMA_DATA.R004CTP_70();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R004D":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R004D obj = new RMA_DATA.R004D();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R004DTP":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R004DTP obj = new RMA_DATA.R004DTP();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R004DTP_70":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R004DTP_70 obj = new RMA_DATA.R004DTP_70();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R005A_CSV":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    drdr = new System.Data.DataSet();
                                    RMA_DATA.R005A_CSV obj = new RMA_DATA.R005A_CSV();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R005ATP":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R005ATP obj = new RMA_DATA.R005ATP();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R005ATP_70":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R005ATP_70 obj = new RMA_DATA.R005ATP_70();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R005B_CSV":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    drdr = new System.Data.DataSet();
                                    RMA_DATA.R005B_CSV obj = new RMA_DATA.R005B_CSV();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R005BTP":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R005BTP obj = new RMA_DATA.R005BTP();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R005BTP_70":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R005BTP_70 obj = new RMA_DATA.R005BTP_70();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R005C_CSV":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    drdr = new System.Data.DataSet();
                                    RMA_DATA.R005C_CSV obj = new RMA_DATA.R005C_CSV();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R005CTP":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R005CTP obj = new RMA_DATA.R005CTP();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R005CTP_70":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R005CTP_70 obj = new RMA_DATA.R005CTP_70();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R005DTP":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R005DTP obj = new RMA_DATA.R005DTP();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R005DTP_70":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R005DTP_70 obj = new RMA_DATA.R005DTP_70();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R006ATP":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R006ATP obj = new RMA_DATA.R006ATP();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R006ATP_70":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R006ATP_70 obj = new RMA_DATA.R006ATP_70();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R006BTP":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R006BTP obj = new RMA_DATA.R006BTP();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R006BTP_70":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R006BTP_70 obj = new RMA_DATA.R006BTP_70();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R006CTP":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R006CTP obj = new RMA_DATA.R006CTP();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R006CTP_70":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R006CTP_70 obj = new RMA_DATA.R006CTP_70();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R006DTP":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R006DTP obj = new RMA_DATA.R006DTP();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R006DTP_70":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R006DTP_70 obj = new RMA_DATA.R006DTP_70();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R010CYCLE_1":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R010CYCLE_1 obj = new RMA_DATA.R010CYCLE_1();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R010CYCLE_2":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R010CYCLE_2 obj = new RMA_DATA.R010CYCLE_2();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R010CYCLE_3":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R010CYCLE_3 obj = new RMA_DATA.R010CYCLE_3();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R010CYCLE_4":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R010CYCLE_4 obj = new RMA_DATA.R010CYCLE_4();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R010DAILY_1":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R010DAILY_1 obj = new RMA_DATA.R010DAILY_1();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R010DAILY_2":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R010DAILY_2 obj = new RMA_DATA.R010DAILY_2();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R011A":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R011A obj = new RMA_DATA.R011A();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R011A_70":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R011A_70 obj = new RMA_DATA.R011A_70();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R011A_CSV":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R011A_CSV obj = new RMA_DATA.R011A_CSV();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R011B":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R011B obj = new RMA_DATA.R011B();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R011B_70":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R011B_70 obj = new RMA_DATA.R011B_70();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R011B_CSV":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R011B_CSV obj = new RMA_DATA.R011B_CSV();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R011C":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R011C obj = new RMA_DATA.R011C();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R011C_70":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R011C_70 obj = new RMA_DATA.R011C_70();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R011C_CSV":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R011C_CSV obj = new RMA_DATA.R011C_CSV();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R011D_CSV":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R011D_CSV obj = new RMA_DATA.R011D_CSV();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R011MOHR":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R011MOHR obj = new RMA_DATA.R011MOHR();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R012ATP":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R012ATP obj = new RMA_DATA.R012ATP();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R012ATP_70":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R012ATP_70 obj = new RMA_DATA.R012ATP_70();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R012BTP":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R012BTP obj = new RMA_DATA.R012BTP();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R012BTP_70":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R012BTP_70 obj = new RMA_DATA.R012BTP_70();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R012CTP":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R012CTP obj = new RMA_DATA.R012CTP();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R012CTP_70":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R012CTP_70 obj = new RMA_DATA.R012CTP_70();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R013ATP":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R013ATP obj = new RMA_DATA.R013ATP();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R013ATP_70":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R013ATP_70 obj = new RMA_DATA.R013ATP_70();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R013BTP":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R013BTP obj = new RMA_DATA.R013BTP();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R013BTP_70":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R013BTP_70 obj = new RMA_DATA.R013BTP_70();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R013CTP":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R013CTP obj = new RMA_DATA.R013CTP();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R013CTP_70":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R013CTP_70 obj = new RMA_DATA.R013CTP_70();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R015ATP":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R015ATP obj = new RMA_DATA.R015ATP();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R015ATP_70":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R015ATP_70 obj = new RMA_DATA.R015ATP_70();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R015BTP":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R015BTP obj = new RMA_DATA.R015BTP();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R015BTP_70":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R015BTP_70 obj = new RMA_DATA.R015BTP_70();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R015CTP":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R015CTP obj = new RMA_DATA.R015CTP();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R015CTP_70":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R015CTP_70 obj = new RMA_DATA.R015CTP_70();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R018":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R018 obj = new RMA_DATA.R018();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R020A2":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R020A2 obj = new RMA_DATA.R020A2();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R020A3":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R020A3 obj = new RMA_DATA.R020A3();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R020D":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R020D obj = new RMA_DATA.R020D();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R020E1":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R020E1 obj = new RMA_DATA.R020E1();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R020E2":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R020E2 obj = new RMA_DATA.R020E2();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R020E3":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R020E3 obj = new RMA_DATA.R020E3();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R020E4":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R020E4 obj = new RMA_DATA.R020E4();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R020E5":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R020E5 obj = new RMA_DATA.R020E5();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R020E6":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R020E6 obj = new RMA_DATA.R020E6();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R020F":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R020F obj = new RMA_DATA.R020F();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R021A_1":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R021A_1 obj = new RMA_DATA.R021A_1();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R021A_2":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R021A_2 obj = new RMA_DATA.R021A_2();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R021A_3":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R021A_3 obj = new RMA_DATA.R021A_3();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R021B":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R021B obj = new RMA_DATA.R021B();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R021C":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R021C obj = new RMA_DATA.R021C();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R022A2":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R022A2 obj = new RMA_DATA.R022A2();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R022A3":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R022A3 obj = new RMA_DATA.R022A3();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R022A4":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R022A4 obj = new RMA_DATA.R022A4();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R022A5":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R022A5 obj = new RMA_DATA.R022A5();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R022A6":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R022A6 obj = new RMA_DATA.R022A6();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R022A7":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R022A7 obj = new RMA_DATA.R022A7();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R022A8":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R022A8 obj = new RMA_DATA.R022A8();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R022A9":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R022A9 obj = new RMA_DATA.R022A9();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R022D":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R022D obj = new RMA_DATA.R022D();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R022E1":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R022E1 obj = new RMA_DATA.R022E1();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R022E2":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R022E2 obj = new RMA_DATA.R022E2();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R022E3":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R022E3 obj = new RMA_DATA.R022E3();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R022E4":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R022E4 obj = new RMA_DATA.R022E4();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R022E5":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R022E5 obj = new RMA_DATA.R022E5();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R022E6":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R022E6 obj = new RMA_DATA.R022E6();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R022F_1":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R022F_1 obj = new RMA_DATA.R022F_1();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R022F_2":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R022F_2 obj = new RMA_DATA.R022F_2();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R022G_1":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R022G_1 obj = new RMA_DATA.R022G_1();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R022G_2":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R022G_2 obj = new RMA_DATA.R022G_2();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R030D1":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R030D1 obj = new RMA_DATA.R030D1();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R030D2":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R030D2 obj = new RMA_DATA.R030D2();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R030E1":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R030E1 obj = new RMA_DATA.R030E1();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R030E2":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R030E2 obj = new RMA_DATA.R030E2();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R030F1":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R030F1 obj = new RMA_DATA.R030F1();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R030F2":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R030F2 obj = new RMA_DATA.R030F2();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R030H":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R030H obj = new RMA_DATA.R030H();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R030I_2":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R030I_2 obj = new RMA_DATA.R030I_2();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R030I_3":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R030I_3 obj = new RMA_DATA.R030I_3();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R030J":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R030J obj = new RMA_DATA.R030J();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R030K":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R030K obj = new RMA_DATA.R030K();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R030K_CSV":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R030K_CSV obj = new RMA_DATA.R030K_CSV();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R030L":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R030L obj = new RMA_DATA.R030L();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R030M":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R030M obj = new RMA_DATA.R030M();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R030N":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R030N obj = new RMA_DATA.R030N();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R030Q":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R030Q obj = new RMA_DATA.R030Q();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R030R1":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R030R1 obj = new RMA_DATA.R030R1();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R030R2":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R030R2 obj = new RMA_DATA.R030R2();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R030R3":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R030R3 obj = new RMA_DATA.R030R3();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R031_BEFORE_UPDATE_1":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R031_BEFORE_UPDATE_1 obj = new RMA_DATA.R031_BEFORE_UPDATE_1();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R031_BEFORE_UPDATE_2":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R031_BEFORE_UPDATE_2 obj = new RMA_DATA.R031_BEFORE_UPDATE_2();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R031_BEFORE_UPDATE_3":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R031_BEFORE_UPDATE_3 obj = new RMA_DATA.R031_BEFORE_UPDATE_3();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R031A":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R031A obj = new RMA_DATA.R031A();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;


                            case "R031A_AGEP":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R031A_AGEP obj = new RMA_DATA.R031A_AGEP();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R031B_AGEP_1":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R031B_AGEP_1 obj = new RMA_DATA.R031B_AGEP_1();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R031B_AGEP_2":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R031B_AGEP_2 obj = new RMA_DATA.R031B_AGEP_2();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R031C_1":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R031C_1 obj = new RMA_DATA.R031C_1();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R031C_2":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R031C_2 obj = new RMA_DATA.R031C_2();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R035B":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R035B obj = new RMA_DATA.R035B();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R051A_TP_PER":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R051A_TP_PER obj = new RMA_DATA.R051A_TP_PER();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R051A_TP_PER_70":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R051A_TP_PER_70 obj = new RMA_DATA.R051A_TP_PER_70();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R051B_TP_PER":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R051B_TP_PER obj = new RMA_DATA.R051B_TP_PER();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R051B_TP_PER_70":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R051B_TP_PER_70 obj = new RMA_DATA.R051B_TP_PER_70();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R051CA_PORTAL":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R051CA_PORTAL obj = new RMA_DATA.R051CA_PORTAL();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R051CAATP":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R051CAATP obj = new RMA_DATA.R051CAATP();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R051CAATP_70":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R051CAATP_70 obj = new RMA_DATA.R051CAATP_70();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R051CABTP":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R051CABTP obj = new RMA_DATA.R051CABTP();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R051CABTP_70":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R051CABTP_70 obj = new RMA_DATA.R051CABTP_70();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R051CACTP":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R051CACTP obj = new RMA_DATA.R051CACTP();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R051CACTP_70":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R051CACTP_70 obj = new RMA_DATA.R051CACTP_70();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R051CATP_PORTAL":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R051CATP_PORTAL obj = new RMA_DATA.R051CATP_PORTAL();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R051CB_PORTAL":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R051CB_PORTAL obj = new RMA_DATA.R051CB_PORTAL();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R051CBATP":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R051CBATP obj = new RMA_DATA.R051CBATP();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R051CBATP_70":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R051CBATP_70 obj = new RMA_DATA.R051CBATP_70();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R051CBBTP":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R051CBBTP obj = new RMA_DATA.R051CBBTP();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R051CBBTP_70":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R051CBBTP_70 obj = new RMA_DATA.R051CBBTP_70();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R051CBCTP":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R051CBCTP obj = new RMA_DATA.R051CBCTP();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R051CBCTP_70":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R051CBCTP_70 obj = new RMA_DATA.R051CBCTP_70();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R051CBTP_PORTAL":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R051CBTP_PORTAL obj = new RMA_DATA.R051CBTP_PORTAL();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R070A_CSV":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R070A_CSV obj = new RMA_DATA.R070A_CSV();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R070ATP":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R070ATP obj = new RMA_DATA.R070ATP();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R070ATP_70":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R070ATP_70 obj = new RMA_DATA.R070ATP_70();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R070B_CSV":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R070B_CSV obj = new RMA_DATA.R070B_CSV();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R070BTP":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R070BTP obj = new RMA_DATA.R070BTP();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R070BTP_70":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R070BTP_70 obj = new RMA_DATA.R070BTP_70();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R070C_CSV":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R070C_CSV obj = new RMA_DATA.R070C_CSV();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R070CTP":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R070CTP obj = new RMA_DATA.R070CTP();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R070CTP_70":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R070CTP_70 obj = new RMA_DATA.R070CTP_70();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R070DTP":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R070DTP obj = new RMA_DATA.R070DTP();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R070DTP_70":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R070DTP_70 obj = new RMA_DATA.R070DTP_70();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R085A":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R085A obj = new RMA_DATA.R085A();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R085E_1":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R085E_1 obj = new RMA_DATA.R085E_1();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R085E_2":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R085E_2 obj = new RMA_DATA.R085E_2();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R085E_3":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R085E_3 obj = new RMA_DATA.R085E_3();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R086":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R086 obj = new RMA_DATA.R086();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R087":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R087 obj = new RMA_DATA.R087();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R088":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R088 obj = new RMA_DATA.R088();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R088A":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R088A obj = new RMA_DATA.R088A();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R089":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R089 obj = new RMA_DATA.R089();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R089_PORTAL":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R089_PORTAL obj = new RMA_DATA.R089_PORTAL();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R093A":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R093A obj = new RMA_DATA.R093A();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R093B":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R093B obj = new RMA_DATA.R093B();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R093C":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R093C obj = new RMA_DATA.R093C();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R093D":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R093D obj = new RMA_DATA.R093D();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R095A":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R095A obj = new RMA_DATA.R095A();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R095B":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R095B obj = new RMA_DATA.R095B();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R095C":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R095C obj = new RMA_DATA.R095C();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R111B":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R111B obj = new RMA_DATA.R111B();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R113":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R113 obj = new RMA_DATA.R113();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R119A":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R119A obj = new RMA_DATA.R119A();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R119B":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R119B obj = new RMA_DATA.R119B();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R119C":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R119C obj = new RMA_DATA.R119C();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R120":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R120 obj = new RMA_DATA.R120();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R121A":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R121A obj = new RMA_DATA.R121A();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R121B":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R121B obj = new RMA_DATA.R121B();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R121B_COMPANY":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R121B_COMPANY obj = new RMA_DATA.R121B_COMPANY();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R121C":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R121C obj = new RMA_DATA.R121C();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R121D":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R121D obj = new RMA_DATA.R121D();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R121E":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R121E obj = new RMA_DATA.R121E();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R121F":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R121F obj = new RMA_DATA.R121F();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R123D1":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R123D1 obj = new RMA_DATA.R123D1();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R123D1A":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R123D1A obj = new RMA_DATA.R123D1A();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R124A":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R124A obj = new RMA_DATA.R124A();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R124A_MP":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R124A_MP obj = new RMA_DATA.R124A_MP();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R124A_PAYCODE7":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R124A_PAYCODE7 obj = new RMA_DATA.R124A_PAYCODE7();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R124A_XLS":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R124A_XLS obj = new RMA_DATA.R124A_XLS();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R124B_MP":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R124B_MP obj = new RMA_DATA.R124B_MP();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R124B_MP_31":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R124B_MP_31 obj = new RMA_DATA.R124B_MP_31();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R124B_PAYCODE7":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R124B_PAYCODE7 obj = new RMA_DATA.R124B_PAYCODE7();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R124B_RMA":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R124B_RMA obj = new RMA_DATA.R124B_RMA();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R124B_XLS":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R124B_XLS obj = new RMA_DATA.R124B_XLS();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R124C_1":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R124C_1 obj = new RMA_DATA.R124C_1();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R124C_2":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R124C_2 obj = new RMA_DATA.R124C_2();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R124C_3":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R124C_3 obj = new RMA_DATA.R124C_3();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R124C_4":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R124C_4 obj = new RMA_DATA.R124C_4();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R125":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R125 obj = new RMA_DATA.R125();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R126_1":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R126_1 obj = new RMA_DATA.R126_1();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R126_2":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R126_2 obj = new RMA_DATA.R126_2();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R126_3":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R126_3 obj = new RMA_DATA.R126_3();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R127":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R127 obj = new RMA_DATA.R127();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R128B":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R128B obj = new RMA_DATA.R128B();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R128B_CSV":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R128B_CSV obj = new RMA_DATA.R128B_CSV();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R132":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R132 obj = new RMA_DATA.R132();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R134A":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R134A obj = new RMA_DATA.R134A();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R134B":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R134B obj = new RMA_DATA.R134B();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R135A":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R135A obj = new RMA_DATA.R135A();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R135B":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R135B obj = new RMA_DATA.R135B();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R136":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R136 obj = new RMA_DATA.R136();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R137A":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R137A obj = new RMA_DATA.R137A();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R137B":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R137B obj = new RMA_DATA.R137B();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R138_CSV":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R138_CSV obj = new RMA_DATA.R138_CSV();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R139_CSV":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R139_CSV obj = new RMA_DATA.R139_CSV();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R140_A1F":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R140_A1F obj = new RMA_DATA.R140_A1F();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R140_A2G":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R140_A2G obj = new RMA_DATA.R140_A2G();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R140_A2S":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R140_A2S obj = new RMA_DATA.R140_A2S();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R140_A3":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R140_A3 obj = new RMA_DATA.R140_A3();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R140_A3C":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R140_A3C obj = new RMA_DATA.R140_A3C();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R140_A4":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R140_A4 obj = new RMA_DATA.R140_A4();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R140_A4T":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R140_A4T obj = new RMA_DATA.R140_A4T();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R140_A5":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R140_A5 obj = new RMA_DATA.R140_A5();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R140_B2":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R140_B2 obj = new RMA_DATA.R140_B2();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R140_B3":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R140_B3 obj = new RMA_DATA.R140_B3();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R140_E":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R140_E obj = new RMA_DATA.R140_E();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R140W3":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R140W3 obj = new RMA_DATA.R140W3();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R141B1":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R141B1 obj = new RMA_DATA.R141B1();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R141B2":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R141B2 obj = new RMA_DATA.R141B2();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R141D":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R141D obj = new RMA_DATA.R141D();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R150_PAYEFT_CHECK_PASS1":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R150_PAYEFT_CHECK__PASS1 obj = new RMA_DATA.R150_PAYEFT_CHECK__PASS1();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R150D_DETAIL_PASS1":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R150D_DETAIL__PASS1 obj = new RMA_DATA.R150D_DETAIL__PASS1();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R150D_DETAIL_PASS2":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R150D_DETAIL__PASS2 obj = new RMA_DATA.R150D_DETAIL__PASS2();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R150D_DETAIL_PASS3":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R150D_DETAIL__PASS3 obj = new RMA_DATA.R150D_DETAIL__PASS3();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R150D_DETAIL_PASS4":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R150D_DETAIL__PASS4 obj = new RMA_DATA.R150D_DETAIL__PASS4();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R150D_DETAIL_PASS5":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R150D_DETAIL__PASS5 obj = new RMA_DATA.R150D_DETAIL__PASS5();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R150D_DETAIL_PASS6":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R150D_DETAIL__PASS6 obj = new RMA_DATA.R150D_DETAIL__PASS6();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R150D_DETAIL_PASS7":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R150D_DETAIL__PASS7 obj = new RMA_DATA.R150D_DETAIL__PASS7();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R150D_DETAIL_PASS8":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R150D_DETAIL__PASS8 obj = new RMA_DATA.R150D_DETAIL__PASS8();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R150D_DETAIL_PASS9":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R150D_DETAIL__PASS9 obj = new RMA_DATA.R150D_DETAIL__PASS9();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R150D_DETAIL_PASS10":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R150D_DETAIL__PASS10 obj = new RMA_DATA.R150D_DETAIL__PASS10();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R150D_DETAIL_PASS11":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R150D_DETAIL__PASS11 obj = new RMA_DATA.R150D_DETAIL__PASS11();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R151":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R151 obj = new RMA_DATA.R151();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R151_SUMMARY":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R151_SUMMARY obj = new RMA_DATA.R151_SUMMARY();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R151D":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R151D obj = new RMA_DATA.R151D();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R151E":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R151E obj = new RMA_DATA.R151E();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R151F":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R151F obj = new RMA_DATA.R151F();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R211":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R211 obj = new RMA_DATA.R211();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R702":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R702 obj = new RMA_DATA.R702();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R707":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R707 obj = new RMA_DATA.R707();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R709A":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R709A obj = new RMA_DATA.R709A();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R709B":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R709B obj = new RMA_DATA.R709B();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R710":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R710 obj = new RMA_DATA.R710();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R712":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R712 obj = new RMA_DATA.R712();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                           case "R715":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R715 obj = new RMA_DATA.R715();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R716A":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R716A obj = new RMA_DATA.R716A();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R716B":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R716B obj = new RMA_DATA.R716B();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R716C1":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R716C1 obj = new RMA_DATA.R716C1();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R716C2":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R716C2 obj = new RMA_DATA.R716C2();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R717":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R717 obj = new RMA_DATA.R717();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R717_SUMMARY":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R717_SUMMARY obj = new RMA_DATA.R717_SUMMARY();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R801A":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R801A obj = new RMA_DATA.R801A();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R801B":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R801B obj = new RMA_DATA.R801B();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R801C":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R801C obj = new RMA_DATA.R801C();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R990":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R990 obj = new RMA_DATA.R990();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R997_CLINIC22_84J_A":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R997_CLINIC22_84J_A obj = new RMA_DATA.R997_CLINIC22_84J_A();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R997_CLINIC22_84J_B":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R997_CLINIC22_84J_B obj = new RMA_DATA.R997_CLINIC22_84J_B();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R997_PAID":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R997_PAID obj = new RMA_DATA.R997_PAID();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R997_PORTAL_A":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R997_PORTAL_A obj = new RMA_DATA.R997_PORTAL_A();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R997_PORTAL_B":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R997_PORTAL_B obj = new RMA_DATA.R997_PORTAL_B();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R997_PORTAL_SS":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R997_PORTAL_SS obj = new RMA_DATA.R997_PORTAL_SS();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R997_TOTAL":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R997_TOTAL obj = new RMA_DATA.R997_TOTAL();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R997A":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R997A obj = new RMA_DATA.R997A();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R997B":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R997B obj = new RMA_DATA.R997B();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R997C":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R997C obj = new RMA_DATA.R997C();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R997D":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R997D obj = new RMA_DATA.R997D();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R997E":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R997E obj = new RMA_DATA.R997E();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R997F":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R997F obj = new RMA_DATA.R997F();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R997F_SUMM":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R997F_SUMM obj = new RMA_DATA.R997F_SUMM();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R997G":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R997G obj = new RMA_DATA.R997G();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R997G_SUMM":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R997G_SUMM obj = new RMA_DATA.R997G_SUMM();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R997H":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R997H obj = new RMA_DATA.R997H();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R997I":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R997I obj = new RMA_DATA.R997I();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R997J":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R997J obj = new RMA_DATA.R997J();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R997K":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R997K obj = new RMA_DATA.R997K();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "R997K_SUMM":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.R997K_SUMM obj = new RMA_DATA.R997K_SUMM();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "REJECT":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.REJECT obj = new RMA_DATA.REJECT();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "RMAPRICE":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.RMAPRICE obj = new RMA_DATA.RMAPRICE();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "RU701_ACR":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.RU701_ACR obj = new RMA_DATA.RU701_ACR();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "SIGNATURELABELS":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.SIGNATURELABELS obj = new RMA_DATA.SIGNATURELABELS();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "SOLO_PAYMENTS":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.SOLO_PAYMENTS obj = new RMA_DATA.SOLO_PAYMENTS();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "SUSPEND_AGENT":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.SUSPEND_AGENT obj = new RMA_DATA.SUSPEND_AGENT();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "SUSPEND_AGENT_DETAIL":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.SUSPEND_AGENT_DETAIL obj = new RMA_DATA.SUSPEND_AGENT_DETAIL();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "SUSPEND_DESC":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.SUSPEND_DESC obj = new RMA_DATA.SUSPEND_DESC();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "SUSPEND_DTL_EMR":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.SUSPEND_DTL_EMR obj = new RMA_DATA.SUSPEND_DTL_EMR();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "SUSPEND_DTL1":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.SUSPEND_DTL1 obj = new RMA_DATA.SUSPEND_DTL1();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "SUSPEND_DTL2":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.SUSPEND_DTL2 obj = new RMA_DATA.SUSPEND_DTL2();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "SUSPEND_FEE":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.SUSPEND_FEE obj = new RMA_DATA.SUSPEND_FEE();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "SUSPEND_STATUS":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.SUSPEND_STATUS obj = new RMA_DATA.SUSPEND_STATUS();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "SUSPEND_SUFFIX":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.SUSPEND_SUFFIX obj = new RMA_DATA.SUSPEND_SUFFIX();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "SUSPEND_TOTAL1":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.SUSPEND_TOTAL1 obj = new RMA_DATA.SUSPEND_TOTAL1();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "SUSPEND_TOTAL2":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.SUSPEND_TOTAL2 obj = new RMA_DATA.SUSPEND_TOTAL2();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "T4A_ADDRLABELS_1":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.T4A_ADDRLABELS_1 obj = new RMA_DATA.T4A_ADDRLABELS_1();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "T4A_ADDRLABELS_2":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.T4A_ADDRLABELS_2 obj = new RMA_DATA.T4A_ADDRLABELS_2();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "T4A_ADDRLABELS_3":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.T4A_ADDRLABELS_3 obj = new RMA_DATA.T4A_ADDRLABELS_3();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "U030AA3":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.U030AA3 obj = new RMA_DATA.U030AA3();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "U100_B":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.U100_B obj = new RMA_DATA.U100_B();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "U100_B_SRC_PASS1":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.U100_B_SRC_PASS1 obj = new RMA_DATA.U100_B_SRC_PASS1();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "U100_B_SRC_PASS2":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.U100_B_SRC_PASS2 obj = new RMA_DATA.U100_B_SRC_PASS2();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "U100_B_SRC_PASS3":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.U100_B_SRC_PASS3 obj = new RMA_DATA.U100_B_SRC_PASS3();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "U100_B_SRC_PASS4":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.U100_B_SRC_PASS4 obj = new RMA_DATA.U100_B_SRC_PASS4();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "U100_B_SRC_PASS5":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.U100_B_SRC_PASS5 obj = new RMA_DATA.U100_B_SRC_PASS5();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "U100_B_SRC_PASS6":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.U100_B_SRC_PASS6 obj = new RMA_DATA.U100_B_SRC_PASS6();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "U100_C":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.U100_C obj = new RMA_DATA.U100_C();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "U100_C_SRC":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.U100_C_SRC obj = new RMA_DATA.U100_C_SRC();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "U100_D":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.U100_D obj = new RMA_DATA.U100_D();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "U100_E":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.U100_E obj = new RMA_DATA.U100_E();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "U100_F":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.U100_F obj = new RMA_DATA.U100_F();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "U111A":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.U111A obj = new RMA_DATA.U111A();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "U140_K":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.U140_K obj = new RMA_DATA.U140_K();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "UTL00013A":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.UTL00013A obj = new RMA_DATA.UTL00013A();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "UTL00013B":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.UTL00013B obj = new RMA_DATA.UTL00013B();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "UTL0006":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.UTL0006 obj = new RMA_DATA.UTL0006();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "UTL0006_70":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.UTL0006_70 obj = new RMA_DATA.UTL0006_70();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "UTL0006A":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.UTL0006A obj = new RMA_DATA.UTL0006A();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "UTL0006A_70":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.UTL0006A_70 obj = new RMA_DATA.UTL0006A_70();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "UTL0007":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.UTL0007 obj = new RMA_DATA.UTL0007();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "UTL0007_70":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.UTL0007_70 obj = new RMA_DATA.UTL0007_70();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "UTL0007A_70":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.UTL0007A_70 obj = new RMA_DATA.UTL0007A_70();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "UTL0011":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.UTL0011 obj = new RMA_DATA.UTL0011();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "UTL0011A":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.UTL0011A obj = new RMA_DATA.UTL0011A();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "UTL0013":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.UTL0013 obj = new RMA_DATA.UTL0013();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "UTL0020D":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.UTL0020D obj = new RMA_DATA.UTL0020D();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "UTL0101":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.UTL0101 obj = new RMA_DATA.UTL0101();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "UTL0201_1":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.UTL0201_1 obj = new RMA_DATA.UTL0201_1();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "UTL0201_2":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.UTL0201_2 obj = new RMA_DATA.UTL0201_2();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "UTL0201_3":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.UTL0201_3 obj = new RMA_DATA.UTL0201_3();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "UTL0F020_OHIP_SIN":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.UTL0F020_OHIP_SIN obj = new RMA_DATA.UTL0F020_OHIP_SIN();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "WEB":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.WEB obj = new RMA_DATA.WEB();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "WEB_BEFORE_AFTER":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.WEB_BEFORE_AFTER obj = new RMA_DATA.WEB_BEFORE_AFTER();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "WEBHST":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.WEBHST obj = new RMA_DATA.WEBHST();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "WEBOMAFEE":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.WEBOMAFEE obj = new RMA_DATA.WEBOMAFEE();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "YASCLARE_1":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.YASCLARE_1 obj = new RMA_DATA.YASCLARE_1();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "YASCLARE_2":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.YASCLARE_2 obj = new RMA_DATA.YASCLARE_2();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            case "YASCLARE_3":
                                if (chkUseRDLExtension.Checked != true)
                                {
                                    RMA_DATA.YASCLARE_3 obj = new RMA_DATA.YASCLARE_3();
                                    drdr = obj.GetDataSet(txtConnectionString.Text, arrParameters, txtReportAssembly.Text, true);
                                }
                                break;

                            default:
                                MessageBox.Show("Could not run assembly " + cmboDataClass.SelectedValue + ". Assembly is not in 'switch' statement.");
                                break;
                        }

                        //Write date to text file.
                        if (chkWriteToTextFile.Checked == true)
                            WriteClassDataToFile(drdr, filePath + cmboDataClass.SelectedItem.ToString() + ".txt");
                    }

                    Cursor.Current = Cursors.Default;

                    MessageBox.Show("Finished executing code.");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            SaveConfigSettings();
            Application.Exit();
        }

        private bool FieldsPopulated()
        {
            bool retvalue = true;

            if (txtConnectionString.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Connection string cannot be empty.");
                retvalue = false;
            }

            if (cmboDataClass.Text == null)
            {
                MessageBox.Show("Data class must be entered or selected from dropdown.");
                retvalue = false;
            }
            else if (cmboDataClass.FindString(cmboDataClass.Text) == -1)
            {
                MessageBox.Show("Data class entered is not in the dropdown.");
                retvalue = false;
            }

            if (txtReportAssembly.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Report Assembly cannot be empty.");
                retvalue = false;
            }

            return retvalue;
        }

        private void WriteExtensionDataToFile(Microsoft.ReportingServices.DataProcessing.IDataReader rdr, String fileName)
        {
            StreamWriter sw;
            string columnHeading = String.Empty;
            string currentRec = String.Empty;

            //If the file exists, deleted it.
            if (File.Exists(fileName))
                File.Delete(fileName);

            sw = new StreamWriter(fileName, true, System.Text.Encoding.Default);

            //Get the column headings
            for (int i = 0; i < rdr.FieldCount; i++)
            {
                if (i < rdr.FieldCount - 1)
                    columnHeading += rdr.GetName(i) + ",";
                else
                    columnHeading += rdr.GetName(i);
            }

            sw.WriteLine(columnHeading);

            //Get the data
            if (rdr.FieldCount > 0)
            {
                while (rdr.Read())
                {
                    currentRec = String.Empty;
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        if (i < rdr.FieldCount - 1)
                            currentRec += rdr.GetValue(i) + ",";
                        else
                            currentRec += rdr.GetValue(i);
                    }

                    sw.WriteLine(currentRec);
                }
            }

            sw.Flush();
            sw.Close();
            sw.Dispose();
        }

        private void WriteClassDataToFile(System.Data.DataSet rdr, String fileName)
        {
            StreamWriter sw;
            string currentRec = String.Empty;
            int colCount;

            //If the file exists, deleted it.
            if (File.Exists(fileName))
                File.Delete(fileName);

            sw = new StreamWriter(fileName, true, System.Text.Encoding.Default);

            if (rdr != null)
            {
                //Get the data
                foreach (DataRow row in rdr.Tables[0].Rows)
                {
                    currentRec = String.Empty;
                    colCount = 1;
                    foreach (DataColumn col in rdr.Tables[0].Columns)
                    {
                        currentRec += row[col];
                        if (colCount < rdr.Tables[0].Columns.Count)
                            currentRec += ",";

                        colCount += 1;
                    }

                    sw.WriteLine(currentRec);
                }
            }
            else
            {
                sw.WriteLine("No records retrieve");
            }

            sw.Flush();
            sw.Close();
            sw.Dispose();
        }

        private void SaveConfigSettings()
        {
            StreamWriter sw;
            StringBuilder sb = new StringBuilder(string.Empty);

            try
            {
                //Setup.config
                sb.Append("ConfigFile > ").Append(txtConfigurationFile.Text).Append(Environment.NewLine);
                sb.Append("ConnectionString > ").Append(txtConnectionString.Text).Append(Environment.NewLine);
                sb.Append("DATFileLocation > ").Append(txtDATFileLocation.Text).Append(Environment.NewLine);
                sb.Append("FlatFileDictionary > ").Append(txtFlatFileDictionary.Text).Append(Environment.NewLine);
                sb.Append("Project > ").Append(txtProject.Text).Append(Environment.NewLine);
                sb.Append("ReportAssembly > ").Append(txtReportAssembly.Text).Append(Environment.NewLine);
                sb.Append("TextFileFolder > ").Append(txtTextFileLocation.Text).Append(Environment.NewLine);

                sb.Append("UseRDLExtension > ");
                if (chkUseRDLExtension.Checked == true)
                {
                    sb.Append("Yes");
                }
                else
                {
                    sb.Append("No");
                }
                sb.Append(Environment.NewLine);

                sb.Append("WriteLogFile > ");
                if (chkWriteToTextFile.Checked == true)
                {
                    sb.Append("Yes");
                }
                else
                {
                    sb.Append("No");
                }
                sb.Append(Environment.NewLine);

                sb.Append("Parameter1 > ").Append(txtParameter1.Text).Append(Environment.NewLine);
                sb.Append("Parameter2 > ").Append(txtParameter2.Text).Append(Environment.NewLine);
                sb.Append("Parameter3 > ").Append(txtParameter3.Text).Append(Environment.NewLine);
                sb.Append("Parameter4 > ").Append(txtParameter4.Text).Append(Environment.NewLine);
                sb.Append("Parameter5 > ").Append(txtParameter5.Text).Append(Environment.NewLine);
                sb.Append("Parameter6 > ").Append(txtParameter6.Text).Append(Environment.NewLine);
                sb.Append("Parameter7 > ").Append(txtParameter7.Text).Append(Environment.NewLine);
                sb.Append("Parameter8 > ").Append(txtParameter8.Text).Append(Environment.NewLine);
                sb.Append("Parameter9 > ").Append(txtParameter9.Text).Append(Environment.NewLine);
                sb.Append("Parameter10 > ").Append(txtParameter10.Text).Append(Environment.NewLine);
                sb.Append("Parameter11 > ").Append(txtParameter11.Text).Append(Environment.NewLine);
                sb.Append("Parameter12 > ").Append(txtParameter12.Text).Append(Environment.NewLine);
                sb.Append("Parameter13 > ").Append(txtParameter13.Text).Append(Environment.NewLine);
                sb.Append("Parameter14 > ").Append(txtParameter14.Text).Append(Environment.NewLine);
                sb.Append("Parameter15 > ").Append(txtParameter15.Text).Append(Environment.NewLine);
                sb.Append("Parameter16 > ").Append(txtParameter16.Text).Append(Environment.NewLine);
                sb.Append("Parameter17 > ").Append(txtParameter17.Text).Append(Environment.NewLine);
                sb.Append("Parameter18 > ").Append(txtParameter18.Text).Append(Environment.NewLine);
                sb.Append("Parameter19 > ").Append(txtParameter19.Text).Append(Environment.NewLine);
                sb.Append("Parameter20 > ").Append(txtParameter20.Text).Append(Environment.NewLine);
                sb.Append("Parameter21 > ").Append(txtParameter21.Text).Append(Environment.NewLine);
                sb.Append("Parameter22 > ").Append(txtParameter22.Text).Append(Environment.NewLine);
                sb.Append("Parameter23 > ").Append(txtParameter23.Text).Append(Environment.NewLine);
                sb.Append("Parameter24 > ").Append(txtParameter24.Text).Append(Environment.NewLine);
                sb.Append("Parameter25 > ").Append(txtParameter25.Text).Append(Environment.NewLine);
                sb.Append("Parameter26 > ").Append(txtParameter26.Text).Append(Environment.NewLine);
                sb.Append("Parameter27 > ").Append(txtParameter27.Text).Append(Environment.NewLine);
                sb.Append("Parameter28 > ").Append(txtParameter28.Text).Append(Environment.NewLine);
                sb.Append("Parameter29 > ").Append(txtParameter29.Text).Append(Environment.NewLine);
                sb.Append("Parameter30 > ").Append(txtParameter30.Text).Append(Environment.NewLine);

                sw = new StreamWriter("Setup.config");
                sw.Write(sb.ToString());
                sw.Flush();
                sw.Close();

                //Assemblies.config
                sb = new StringBuilder(string.Empty);

                for (int i = 0; i < cmboDataClass.Items.Count; i++)
                {
                    sb.Append(cmboDataClass.Items[i]);

                    if (i < cmboDataClass.Items.Count - 1)
                        sb.Append(Environment.NewLine);
                }

                sw = new StreamWriter("Assemblies.config");
                sw.Write(sb.ToString());
                sw.Flush();
                sw.Close();
                sw.Dispose();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmboDataClass_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtConnectionString_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void cmboDataClass_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
