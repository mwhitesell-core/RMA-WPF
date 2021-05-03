using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Data.SqlTypes;

namespace DataTransferUtility
{
    public partial class Form1 : Form
    {
        #region Declarations

        private ArrayList punch = new ArrayList();

        private bool claimsMstrDtlDescLoaded = false;
        private bool claimsMstrDtlLoaded = false;
        private bool claimsMstrHdrLoaded = false;
        private bool constantsMstrRec1Loaded = false;
        private bool constantsMstrRec2Loaded = false;
        private bool constantsMstrRec3Loaded = false;
        private bool constantsMstrRec4Loaded = false;
        private bool constantsMstrRec5Loaded = false;
        private bool constantsMstrRec6Loaded = false;
        private bool constantsMstrRec7Loaded = false;
        private bool formLoading = false;
        private bool iconstMstrRecLoaded = false;
        private bool stopProcessing = false;

        private enum datatypes
        {
            Character,
            Integer,
            PHDate,
            VMSDate,
            Zoned,
            Numeric
        }

        private enum items
        {
            FileName = 0,
            Database = 1,
            Relation = 2,
            Column = 3,
            DataType = 4,
            Size = 5,
            DecimalPosition = 6,
            Picture = 7,
            Signed = 8,
            DateFormat = 9,
            InputScale = 10,
            OutputScale = 11,
            Occurs = 12,
            ParentFlag = 13,
            RedefinedElement = 14,
            RecordLength = 15
        }

        private Hashtable columnCounts = new Hashtable();
        private Hashtable columns = new Hashtable();
        private Hashtable htDocClinicNbr = new Hashtable();
        private Hashtable pkcheck = new Hashtable();
        private Hashtable tables = new Hashtable();
        private Hashtable tableInformation = new Hashtable();

        private int errCount = 0;
        private int recAddedCount = 0;
        private int totalCount = 0;

        private List<string> relationlist = new List<string>();
        private List<string> tablelist = new List<string>();

        private SqlConnection cn = null;

        private string importSchemaFile = string.Empty;
        private string logFile = string.Empty;
        private string ptable = string.Empty;
        private string pcolumn = string.Empty;

        private StringBuilder sbError = new StringBuilder(string.Empty);
        private StringBuilder sbrLog = new StringBuilder(string.Empty);

        #endregion

        #region Events
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                columns.Clear();

                if (File.Exists("Output.log"))
                {
                    File.Delete("Output.log");
                }

                if (txtDatabase.Text.ToUpper() == "101C")
                {
                    if (File.Exists("Output_101C.log"))
                    {
                        File.Delete("Output_101C.log");
                    }
                }
                else if (txtDatabase.Text.ToUpper() == "MP")
                {
                    if (File.Exists("Output_MP.log"))
                    {
                        File.Delete("Output_MP.log");
                    }
                }
                else if (txtDatabase.Text.ToUpper() == "SOLO")
                {
                    if (File.Exists("Output_SOLO.log"))
                    {
                        File.Delete("Output_SOLO.log");
                    }
                }

                Cursor.Current = Cursors.WaitCursor;
                stopProcessing = false;
                lblStatus.ForeColor = System.Drawing.Color.Black;
                lblStatus.Text = "";

                txtLog.Text = string.Empty;
                RefreshLog("Start Time: " + DateTime.Now.ToString());

                //Save the current settings
                SaveCurrentSettings();

                //If chkStructureOnly is check and there are file selected display message
                if (chkStructureOnly.Checked == true)
                {
                    DialogResult dr = MessageBox.Show("Having the 'Create Data Structure' checkbox checked will created the database structure and not load any data. Any current data in the database will be lost." + Environment.NewLine + Environment.NewLine + "Do you wish to continue and only create the data structure?", "Warning", MessageBoxButtons.YesNo);

                    if (dr == DialogResult.Yes)
                    {
                        lstTables.SelectedItems.Clear();
                        chkSysDebugDate.Checked = false;
                        txtSysDebugDate.Text = "";
                        CreateDatabaseStructure();
                    }
                }
                else if (lstTables.SelectedItems.Count == 0)
                {
                    //Create the database
                    //CreateDatabaseStructure();

                    if (cmboLegacyDB.Text == "101C" || cmboLegacyDB.Text == "MP" || cmboLegacyDB.Text == "SOLO")
                    {
                        if (!stopProcessing)
                        {
                            LoadDataTables();

                            if (txtSysDebugDate.Text.Trim().Length > 0)
                            {
                                if (File.Exists(txtScriptsLocation.Text + "InsertCoreDebugSysDate.sql"))
                                {
                                    StreamReader sr2 = new StreamReader(txtScriptsLocation.Text + "InsertCoreDebugSysDate.sql");
                                    StringBuilder sb2 = new StringBuilder(string.Empty);

                                    while (!sr2.EndOfStream)
                                    {
                                        sb2.Append(sr2.ReadLine().Replace("%SYSDEBUGDATE%", txtSysDebugDate.Text));
                                    }

                                    if (OpenConnection(txtDatabase.Text))
                                    {
                                        RefreshStatus("Inserting record into Core_Debug_SysDate...");
                                        SqlCommand cm = new SqlCommand(sb2.ToString(), cn);
                                        cm.ExecuteNonQuery();
                                        CloseConnection();
                                        RefreshLog("Executed InsertCoreDebugSysDate.sql");
                                    }
                                }
                            }

                            if (txtDatabase.Text.ToUpper().IndexOf("101") > -1)
                            {
                                if (File.Exists(txtScriptsLocation.Text + "UpdateF020_Doctor_Extra.sql"))
                                {
                                    StreamReader sr2 = new StreamReader(txtScriptsLocation.Text + "UpdateF020_Doctor_Extra.sql");
                                    StringBuilder sb2 = new StringBuilder(string.Empty);

                                    while (!sr2.EndOfStream)
                                    {
                                        sb2.Append(sr2.ReadLine());
                                    }

                                    if (OpenConnection(txtDatabase.Text))
                                    {
                                        RefreshStatus("Updating F020_DOCTOR_EXTRA...");
                                        SqlCommand cm = new SqlCommand(sb2.ToString(), cn);
                                        cm.ExecuteNonQuery();
                                        CloseConnection();
                                        RefreshLog("Executed UpdateF020_Doctor_Extra.sql");
                                    }
                                }

                                if (File.Exists(txtScriptsLocation.Text + "UpdateF010_Pat_Mstr.sql"))
                                {
                                    StreamReader sr2 = new StreamReader(txtScriptsLocation.Text + "UpdateF010_Pat_Mstr.sql");
                                    StringBuilder sb2 = new StringBuilder(string.Empty);

                                    while (!sr2.EndOfStream)
                                    {
                                        sb2.Append(sr2.ReadLine());
                                    }

                                    if (OpenConnection(txtDatabase.Text))
                                    {
                                        RefreshStatus("Updating F010_PAT_MSTR...");
                                        SqlCommand cm = new SqlCommand(sb2.ToString(), cn);
                                        cm.ExecuteNonQuery();
                                        CloseConnection();
                                        RefreshLog("Executed UpdateF010_Pat_Mstr.sql");
                                    }
                                }
                            }

                            Cursor.Current = Cursors.Default;
                            txtLog.Enabled = true;
                            RefreshStatus("Data transfer is complete.");
                            RefreshRead("");
                            RefreshAdded("");
                            RefreshRejected("");
                            RefreshLog("Stop Time: " + DateTime.Now.ToString());

                            if (txtDatabase.Text.ToUpper() == "101C")
                            {
                                StreamWriter sw2 = new StreamWriter("Output_101C.log", true, System.Text.Encoding.Default);
                                sw2.Write(txtLog.Text);
                                sw2.Flush();
                                sw2.Close();
                                sw2.Dispose();
                            }
                            else if (txtDatabase.Text.ToUpper() == "MP")
                            {
                                StreamWriter sw2 = new StreamWriter("Output_MP.log", true, System.Text.Encoding.Default);
                                sw2.Write(txtLog.Text);
                                sw2.Flush();
                                sw2.Close();
                                sw2.Dispose();
                            }
                            else if (txtDatabase.Text.ToUpper() == "SOLO")
                            {
                                StreamWriter sw2 = new StreamWriter("Output_SOLO.log", true, System.Text.Encoding.Default);
                                sw2.Write(txtLog.Text);
                                sw2.Flush();
                                sw2.Close();
                                sw2.Dispose();
                            }

                        }
                        else
                        {
                            RefreshLog("Stop Time: " + DateTime.Now.ToString());
                        }
                    }

                    Cursor.Current = Cursors.Default;
                    txtLog.Enabled = true;
                }
                else
                {
                    if (cmboLegacyDB.Text == "101C" || cmboLegacyDB.Text == "MP" || cmboLegacyDB.Text == "SOLO")
                    {
                        if (!stopProcessing)
                        {
                            LoadDataTables();

                            if (txtSysDebugDate.Text.Trim().Length > 0)
                            {
                                if (File.Exists(txtScriptsLocation + "InsertCoreDebugSysDate.sql"))
                                {
                                    StreamReader sr2 = new StreamReader(txtScriptsLocation.Text + "InsertCoreDebugSysDate.sql");
                                    StringBuilder sb2 = new StringBuilder(string.Empty);

                                    while (!sr2.EndOfStream)
                                    {
                                        sb2.Append(sr2.ReadLine().Replace("%SYSDEBUGDATE%", txtSysDebugDate.Text));
                                    }

                                    if (OpenConnection(txtDatabase.Text))
                                    {
                                        RefreshStatus("Inserting record into Core_Debug_SysDate...");
                                        SqlCommand cm = new SqlCommand(sb2.ToString(), cn);
                                        cm.ExecuteNonQuery();
                                        CloseConnection();
                                        RefreshLog("Executed InsertCoreDebugSysDate.sql");
                                    }
                                }
                            }
                        }
                    }

                    Cursor.Current = Cursors.Default;
                    txtLog.Enabled = true;
                    RefreshStatus("Data transfer is complete.");
                    RefreshRead("");
                    RefreshAdded("");
                    RefreshRejected("");
                    RefreshLog("Stop Time: " + DateTime.Now.ToString());

                    if (txtDatabase.Text.ToUpper() == "101C")
                    {
                        StreamWriter sw2 = new StreamWriter("Output_101C.log", true, System.Text.Encoding.Default);
                        sw2.Write(txtLog.Text);
                        sw2.Flush();
                        sw2.Close();
                        sw2.Dispose();
                    }
                    else if (txtDatabase.Text.ToUpper() == "MP")
                    {
                        StreamWriter sw2 = new StreamWriter("Output_MP.log", true, System.Text.Encoding.Default);
                        sw2.Write(txtLog.Text);
                        sw2.Flush();
                        sw2.Close();
                        sw2.Dispose();
                    }
                    else if (txtDatabase.Text.ToUpper() == "SOLO")
                    {
                        StreamWriter sw2 = new StreamWriter("Output_SOLO.log", true, System.Text.Encoding.Default);
                        sw2.Write(txtLog.Text);
                        sw2.Flush();
                        sw2.Close();
                        sw2.Dispose();
                    }
                }
            }

            catch (Exception ex)
            {
                RefreshLog("Error: " + ex.Message);
                RefreshLog("Stop Time: " + DateTime.Now.ToString());

                if (txtDatabase.Text.ToUpper() == "101C")
                {
                    StreamWriter sw2 = new StreamWriter("Output_101C.log", true, System.Text.Encoding.Default);
                    sw2.Write(txtLog.Text);
                    sw2.Flush();
                    sw2.Close();
                    sw2.Dispose();
                }
                else if (txtDatabase.Text.ToUpper() == "MP")
                {
                    StreamWriter sw2 = new StreamWriter("Output_MP.log", true, System.Text.Encoding.Default);
                    sw2.Write(txtLog.Text);
                    sw2.Flush();
                    sw2.Close();
                    sw2.Dispose();
                }
                else if (txtDatabase.Text.ToUpper() == "SOLO")
                {
                    StreamWriter sw2 = new StreamWriter("Output_SOLO.log", true, System.Text.Encoding.Default);
                    sw2.Write(txtLog.Text);
                    sw2.Flush();
                    sw2.Close();
                    sw2.Dispose();
                }

                MessageBox.Show(ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            SaveCurrentSettings();
            Application.Exit();
        }

        private void cmboLegacyDB_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmboLegacyDB.Text)
            {
                case "101C":
                    txtDatabase.Enabled = true;
                    lstTables.Enabled = true;
                    chkStructureOnly.Enabled = true;
                    chkSysDebugDate.Enabled = true;

                    if (chkSysDebugDate.Checked == true)
                        txtSysDebugDate.Enabled = true;
                    else
                        txtSysDebugDate.Enabled = false;

                    if (txtDatabase.Text == "Security" || txtDatabase.Text == "Logging")
                        txtDatabase.Text = String.Empty;
                    importSchemaFile = "import_schema_101C";
                    break;
                case "Logging":
                    txtDatabase.Text = "Logging";
                    txtDatabase.Enabled = false;
                    lstTables.Enabled = false;
                    chkStructureOnly.Checked = false;
                    chkStructureOnly.Enabled = false;
                    chkSysDebugDate.Checked = false;
                    chkSysDebugDate.Enabled = false;
                    txtSysDebugDate.Text = "";
                    txtSysDebugDate.Enabled = false;
                    break;
                case "MP":
                    txtDatabase.Enabled = true;
                    lstTables.Enabled = true;
                    chkStructureOnly.Enabled = true;
                    chkSysDebugDate.Enabled = true;

                    if (chkSysDebugDate.Checked == true)
                        txtSysDebugDate.Enabled = true;
                    else
                        txtSysDebugDate.Enabled = false;

                    if (txtDatabase.Text == "Security" || txtDatabase.Text == "Logging")
                        txtDatabase.Text = String.Empty;
                    importSchemaFile = "import_schema_mp";
                    break;
                case "Security":
                    txtDatabase.Text = "Security";
                    txtDatabase.Enabled = false;
                    lstTables.Enabled = false;
                    chkStructureOnly.Checked = false;
                    chkStructureOnly.Enabled = false;
                    chkSysDebugDate.Checked = false;
                    chkSysDebugDate.Enabled = false;
                    txtSysDebugDate.Text = "";
                    txtSysDebugDate.Enabled = false;
                    break;
                case "SOLO":
                    txtDatabase.Enabled = true;
                    lstTables.Enabled = true;
                    chkStructureOnly.Enabled = true;
                    chkSysDebugDate.Enabled = true;

                    if (chkSysDebugDate.Checked == true)
                        txtSysDebugDate.Enabled = true;
                    else
                        txtSysDebugDate.Enabled = false;

                    if (txtDatabase.Text == "Security" || txtDatabase.Text == "Logging")
                        txtDatabase.Text = String.Empty;
                    importSchemaFile = "import_schema_solo";
                    break;
            }

            if (txtFileName.Text.Trim() != string.Empty)
            {
                if (cmboLegacyDB.SelectedItem.ToString() == "101C" || cmboLegacyDB.SelectedItem.ToString() == "MP" || cmboLegacyDB.SelectedItem.ToString() == "SOLO")
                {
                    if (File.Exists(txtFileName.Text + importSchemaFile + ".Core") == true)
                    {
                        LoadTablesToList();
                    }
                    else
                    {
                        MessageBox.Show("The dat File Location field does not have the file '" + importSchemaFile + ".Core.' Either add the file to the folder, or point to a different folder where the file exists.");
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            formLoading = true;
            LoadSettings();

            if (txtUser.Text.Trim() != string.Empty)
            {
                this.ActiveControl = txtPassword;
            }

            if (txtFileName.Text.Trim() == string.Empty)
            {
                string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase.Replace("file:///", ""));
                if (path.EndsWith("\\"))
                {
                    path += "Data";
                }
                else
                {
                    path += "\\Data";
                }
                txtFileName.Text = path + "\\";
            }

            txtLog.Enabled = false;
            AcceptButton = Button1;
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            Text = "Data Transfer Utiltity (Version" + version.Major + "." + version.Minor + "." + version.Build + "." + version.MinorRevision + ")";
            formLoading = false;
        }

        private void txtMinimumYearCutoff_LostFocus(object sender, EventArgs e)
        {
            if (txtMinimumYearCutoff.Text == string.Empty)
            {
                MessageBox.Show("Minimum value is 20.");
                this.ActiveControl = txtMinimumYearCutoff;
                txtMinimumYearCutoff.SelectionStart = 0;
                txtMinimumYearCutoff.SelectionLength = txtMinimumYearCutoff.Text.Length;
            }
            else if (Convert.ToInt16(txtMinimumYearCutoff.Text) < 20)
            {
                MessageBox.Show("Minimum value is 20.");
                this.ActiveControl = txtMinimumYearCutoff;
                txtMinimumYearCutoff.SelectionStart = 0;
                txtMinimumYearCutoff.SelectionLength = txtMinimumYearCutoff.Text.Length;
            }
        }

        private void txtFileName_LostFocus(object sender, EventArgs e)
        {
            if (!formLoading)
            {
                if (txtFileName.Text.Trim() != string.Empty)
                {
                    if (File.Exists(txtFileName.Text + importSchemaFile + ".Core") == true)
                    {
                        LoadTablesToList();
                    }
                    else
                    {
                        MessageBox.Show("The dat File Location field does not have the file '" + importSchemaFile + ".Core'. Either add the file to the folder, or point to a different folder where the file exists.");
                    }
                }
            }
        }

        #endregion

        #region Methods

        private void AddColumn(ref int startPosition
            , ref int size
            , ref string[] column
            , ref string value
            , ref decimal? numberValue
            , ref string signed
            , ref DateTime? dateValue
            , ref DataTable dt
            , ref string columnName
            , ref int factor
            , ref int count
            , byte[] buffer)
        {
            int offset = startPosition;
            startPosition += size;
            
            try
            {
                switch (column[(int)items.DataType])
                {
                    case "Integer":
                        if (column[(int)items.DataType] == datatypes.Integer.ToString())
                        {
                            bool nullval = true;
                            for (int p = 0; p <= size - 1; p++)
                            {
                                if (value.Substring(p, 1) == "\0")
                                {
                                    nullval = true;
                                }
                                else
                                {
                                    nullval = false;
                                    break;
                                }
                            }

                            if (nullval == true)
                            {
                                //numberValue = (decimal?)null;
                                numberValue = 0;
                            }
                            else
                            {
                                var a = buffer[offset++];
                                var b = buffer[offset++];
                                var c = buffer[offset++];
                                var d = buffer[offset];
                                Int32 v = (a << 24) | (b << 16) | (c << 8) | d;

                                numberValue = v;
                            }
                        }
                        break;

                    case "PHDate":
                        dateValue = GetDateFromString(value);
                        break;

                    case "VMSDate":
                        value = Reverse(value);
                        numberValue = AsciiToDecimal(value, true);
                        numberValue = numberValue / 10000000;
                        System.DateTime convertedDate = new DateTime(1858, 11, 17).AddSeconds((double)numberValue);
                        numberValue = Convert.ToInt32(convertedDate.ToString("yyyyMMdd"));
                        break;

                    case "Numeric":

                    case "Zoned":
                        if (dt.Columns[columnName].DataType.FullName == "System.DateTime")
                        {
                            if (value.Contains('\0') && value.Trim('\0').Length == 0)
                            {
                                //numberValue = (decimal?)null;
                                numberValue = 0;
                            }
                            else
                            {
                                dateValue = GetDateFromString(value);
                            }
                        }
                        else
                        {
                            if ((value.Contains('\0') && value.Trim('\0').Length == 0) || value.Trim().Length == 0)
                            {
                                //numberValue = (decimal?)null;
                                numberValue = 0;
                            }
                            else
                            {
                                if (value.IndexOf("\\u") >= 0)
                                {
                                    value = value.Replace("\0", "");
                                    numberValue = AsciiToDecimal(value, signed.ToUpper() == "UNSIGNED");
                                }
                                else
                                {
                                    if (chkPortableSubFile.Checked)
                                        numberValue = Convert.ToDecimal(value);
                                    else
                                        numberValue = ConvertZoned(value, signed.ToUpper() == "SIGNED");
                                }
                            }
                        }
                        break;

                    case "Character":
                        // Remove the leading/trailing quotes.
                        if (value.StartsWith("\"") && value.EndsWith("\""))
                            value = value.Substring(1, value.Length - 2);

                        value = value.TrimEnd();

                        if (value.Length == 0)
                            value = " ";
                        break;
                }

                switch (column[(int)items.DataType])
                {
                    case "Character":
                        if (columnName == "TYPE")
                            dt.Rows[count]["CORE_TYPE"] = value;
                        else
                            dt.Rows[count][columnName] = value;
                        break;

                    case "Integer":
                        if (numberValue.HasValue)
                        {
                            if (dt.Columns[columnName].DataType.FullName == "System.DateTime")
                                dt.Rows[count][columnName] = GetDateFromString(numberValue.ToString());
                            else
                                dt.Rows[count][columnName] = numberValue.Value;
                        }
                        else
                        {
                            dt.Rows[count][columnName] = DBNull.Value;
                        }
                        break;

                    case "PHDate":
                        if (!(dateValue == null) & !(dateValue == new System.DateTime()) & !(dateValue == System.DateTime.MinValue))
                            dt.Rows[count][columnName] = dateValue;
                        else
                            dt.Rows[count][columnName] = DBNull.Value;
                        break;

                    case "VMSDate":
                        if (dt.Columns[columnName].DataType.FullName == "System.DateTime")
                            dt.Rows[count][columnName] = GetDateFromString(numberValue.ToString());
                        else
                            dt.Rows[count][columnName] = numberValue;
                        break;

                    case "Numeric":

                    case "Zoned":
                        if (dt.Columns[columnName].DataType.FullName == "System.DateTime")
                        {
                            if (!(dateValue == null) & !(dateValue == new System.DateTime()) & !(dateValue == System.DateTime.MinValue))
                            {
                                dt.Rows[count][columnName] = dateValue;
                            }
                            else
                            {
                                dt.Rows[count][columnName] = DBNull.Value;
                            }
                        }
                        else
                        {
                            if (numberValue.HasValue)
                                dt.Rows[count][columnName] = numberValue;
                            else
                                dt.Rows[count][columnName] = DBNull.Value;
                        }
                        break;

                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                if (column[(int)items.DataType] == "Zoned")
                {
                    dt.Rows[count][columnName] = 0;
                }
                else
                {
                    throw e;
                }
            }
        }

        private void AddSeqNo(decimal? numberValue, ref DataTable dtbl, string columnName, int count)
        {
            try
            {
                if (numberValue.HasValue)
                {
                    if (dtbl.Columns[columnName].DataType.FullName == "System.DateTime")
                        dtbl.Rows[count][columnName] = GetDateFromString(numberValue.ToString());
                    else
                        dtbl.Rows[count][columnName] = numberValue.Value;
                }
                else
                {
                    dtbl.Rows[count][columnName] = DBNull.Value;
                }
            }

            catch (Exception e)
            {
                throw e;
            }
        }

        private decimal AsciiToDecimal(string Value, bool Unsigned = false)
        {
            byte[] byteArray = null;
            string hexString = string.Empty;
            int counter = 0;

            if (Value.Trim().Length == 0)
            {
                return 0m;
            }
            else
            {
                // Get the byte array using database encoding.
                byteArray = System.Text.Encoding.Unicode.GetBytes(Value);

                // Convert to "windows-1250"
                byteArray = System.Text.Encoding.Convert(System.Text.Encoding.Unicode, System.Text.Encoding.Default, byteArray);

                // Convert to hex string.
                for (counter = 0; counter <= byteArray.Length - 1; counter++)
                {
                    int valueToConvert = byteArray[counter];
                    string hexValue = valueToConvert.ToString("X");
                    hexString += hexValue.PadLeft(2, '0');
                }

                if (!Unsigned && IsNegativeNumber(hexString))

                {
                    return Convert.ToInt64(hexString, 16); //Val("&h" & hexString)
                }
                else
                {
                    return Convert.ToInt64(hexString, 16);
                }
            }
        }

        private void CloseConnection()
        {
            cn.Close();
            cn.Dispose();
        }

        private decimal ConvertZoned(string value, bool signed = false)
        {
            try
            {
                int result;
                if (value.Trim() != "" & Regex.IsMatch(value.Trim(), @"\d"))
                    if (value.Substring(value.Length - 1, 1).Trim() != "")
                        result = int.Parse(value.Substring(value.Length - 1, 1));
            }
            catch
            {

                if (!punch.Contains(ptable + "~" + pcolumn))
                    punch.Add(ptable + "~" + pcolumn);

                signed = true;
            }

            if (signed)
            {
                if (value.Trim() == "")
                    value = "0";
                int overpunchDigit = GetOverpunchDigit(value.Substring(value.Length - 1, 1));
                bool isPositive = GetOverpunchSign(value.Substring(value.Length - 1, 1));

                if (isPositive)
                    return Convert.ToDecimal(value.Substring(0, value.Length - 1) + overpunchDigit);
                else
                    return Convert.ToDecimal(value.Substring(0, value.Length - 1) + overpunchDigit) * -1;
            }
            else
            {
                try
                {
                    if (!IsNumeric(value))
                    {
                        decimal decimalValue = 0;
                        for (int i = 0; i <= value.Length - 1; i++)
                        {
                            if (Convert.ToInt32(value.Substring(i, 1)) != 0 && Convert.ToInt32(value.Substring(i, 1)) != 32)
                            {
                                decimalValue = Convert.ToDecimal(value);
                            }
                        }

                        return decimalValue;
                    }
                    else
                    {
                        return Convert.ToDecimal(value);
                    }
                }

                catch (Exception ex)
                {
                    return 0;
                }
            }
        }

        private void CreateDatabase()
        {
            StreamReader sr = new StreamReader(txtScriptsLocation.Text + "CreateDatabase.sql");
            StreamReader sr2 = new StreamReader(txtScriptsLocation.Text + "KillProcesses.sql");
            SqlCommand cm = new SqlCommand();

            try
            {
                if (File.Exists(txtScriptsLocation.Text + "CreateDatabase.sql"))
                {
                    if (File.Exists(txtScriptsLocation.Text + "KillProcesses.sql"))
                    {
                        StringBuilder sb = new StringBuilder(string.Empty);
                        string line = string.Empty;

                        if (! txtDatabaseLocation.Text.EndsWith("\\"))
                        {
                            txtDatabaseLocation.Text += "\\";
                        }

                        while (!sr.EndOfStream)
                        {
                            line = sr.ReadLine();
                            sb.Append(line.Replace("%DatabaseName%", txtDatabase.Text).Replace("%SQLServerLocation%", txtDatabaseLocation.Text).Replace("\\\\", "\\")).Append(Environment.NewLine);
                        }

                        line = string.Empty;
                        StringBuilder sb2 = new StringBuilder(string.Empty);

                        while (!sr2.EndOfStream)
                        {
                            line = sr2.ReadLine();
                            sb2.Append(line.Replace("%DatabaseName%", txtDatabase.Text)).Append(Environment.NewLine);
                        }

                        if (OpenConnection("MASTER"))
                        {
                            //Kill all processes to the database being created.
                            RefreshStatus("Creating Database...");
                            cm = new SqlCommand(sb2.ToString(), cn);
                            cm.ExecuteNonQuery();

                            cm = new SqlCommand(sb.ToString(), cn);
                            cm.ExecuteNonQuery();
                            cm.Dispose();
                            CloseConnection();
                        }
                    }
                    else
                    {
                        MessageBox.Show("File " + txtScriptsLocation.Text + "KillProcesses.sql does not exist.");
                        stopProcessing = true;
                        Cursor.Current = Cursors.Default;
                    }
                }
                else
                {
                    MessageBox.Show("File " + txtScriptsLocation.Text + "CreateDatabase.sql does not exist.");
                    stopProcessing = true;
                    Cursor.Current = Cursors.Default;
                }
            }

            catch (SqlException ex)
            {
                if (txtDatabase.Text.ToUpper() == "101C")
                {
                    StreamWriter sw2 = new StreamWriter("Output_101C.log", true, System.Text.Encoding.Default);
                    sw2.Write(txtLog.Text);
                    sw2.Flush();
                    sw2.Close();
                    sw2.Dispose();
                }
                else if (txtDatabase.Text.ToUpper() == "MP")
                {
                    StreamWriter sw2 = new StreamWriter("Output_MP.log", true, System.Text.Encoding.Default);
                    sw2.Write(txtLog.Text);
                    sw2.Flush();
                    sw2.Close();
                    sw2.Dispose();
                }
                else if (txtDatabase.Text.ToUpper() == "SOLO")
                {
                    StreamWriter sw2 = new StreamWriter("Output_SOLO.log", true, System.Text.Encoding.Default);
                    sw2.Write(txtLog.Text);
                    sw2.Flush();
                    sw2.Close();
                    sw2.Dispose();
                }

                cm.Dispose();
                CloseConnection();
                stopProcessing = true;
            }

            catch (Exception ex)
            {
                if (txtDatabase.Text.ToUpper() == "101C")
                {
                    StreamWriter sw2 = new StreamWriter("Output_101C.log", true, System.Text.Encoding.Default);
                    sw2.Write(txtLog.Text);
                    sw2.Flush();
                    sw2.Close();
                    sw2.Dispose();
                }
                else if (txtDatabase.Text.ToUpper() == "MP")
                {
                    StreamWriter sw2 = new StreamWriter("Output_MP.log", true, System.Text.Encoding.Default);
                    sw2.Write(txtLog.Text);
                    sw2.Flush();
                    sw2.Close();
                    sw2.Dispose();
                }
                else if (txtDatabase.Text.ToUpper() == "SOLO")
                {
                    StreamWriter sw2 = new StreamWriter("Output_SOLO.log", true, System.Text.Encoding.Default);
                    sw2.Write(txtLog.Text);
                    sw2.Flush();
                    sw2.Close();
                    sw2.Dispose();
                }

                cm.Dispose();
                CloseConnection();
                stopProcessing = true;
            }

            finally
            {
                sr.Close();
                sr.Dispose();
                sr2.Close();
                sr2.Dispose();
            }
        }

        private void CreateDatabaseStructure()
        {
            //Create the database
            //CreateDatabase();

            if (cmboLegacyDB.Text == "101C" || cmboLegacyDB.Text == "MP" || cmboLegacyDB.Text == "SOLO")
            {
                if (!stopProcessing)
                {
                    CreateSchema("DIRECT");

                    if (!stopProcessing)
                    {
                        CreateSchema("INDEXED");
                        CreateSchema("SEQUENTIAL");
                        CreateSchema("TEMPORARYDATA");
                        CreateSchema("22");
                        CreateSchema("23");
                        CreateSchema("24");
                        CreateSchema("25");
                        CreateSchema("26");
                        CreateSchema("30");
                        CreateSchema("31");
                        CreateSchema("32");
                        CreateSchema("33");
                        CreateSchema("34");
                        CreateSchema("35");
                        CreateSchema("36");
                        CreateSchema("37");
                        CreateSchema("40");
                        CreateSchema("41");
                        CreateSchema("42");
                        CreateSchema("43");
                        CreateSchema("44");
                        CreateSchema("45");
                        CreateSchema("46");
                        CreateSchema("48");
                        CreateSchema("60");
                        CreateSchema("61");
                        CreateSchema("62");
                        CreateSchema("63");
                        CreateSchema("64");
                        CreateSchema("65");
                        CreateSchema("66");
                        CreateSchema("68");
                        CreateSchema("69");
                        CreateSchema("70");
                        CreateSchema("71");
                        CreateSchema("72");
                        CreateSchema("73");
                        CreateSchema("74");
                        CreateSchema("75");
                        CreateSchema("78");
                        CreateSchema("79");
                        CreateSchema("80");
                        CreateSchema("81");
                        CreateSchema("82");
                        CreateSchema("83");
                        CreateSchema("84");
                        CreateSchema("85");
                        CreateSchema("86");
                        CreateSchema("87");
                        CreateSchema("88");
                        CreateSchema("89");
                        CreateSchema("90");
                        CreateSchema("91");
                        CreateSchema("92");
                        CreateSchema("93");
                        CreateSchema("94");
                        CreateSchema("95");
                        CreateSchema("96");
                        CreateSchema("98");
                    }

                    CreateTables("Direct");
                    CreateTables("Indexed");
                    CreateTables("Sequential");
                    CreateTables("TemporaryData");
                    CreateStoredProcedures();
                    CreateViews();
                }
            }
            else if (cmboLegacyDB.Text == "Logging")
            {
                CreateTables("Logging");
            }
            else if (cmboLegacyDB.Text == "Security")
            {
                CreateTables("Security");
            }

            if (stopProcessing == true)
            {
                lblStatus.ForeColor = System.Drawing.Color.Red;
                RefreshStatus("An error occurred while creating the database. Check the Output.log for details.");
                RefreshRead("");
                RefreshAdded("");
                RefreshRejected("");
                RefreshLog("Stop Time: " + DateTime.Now.ToString());
            }
            else
            {
                RefreshStatus("Creation of the database structure is complete.");
                RefreshRead("");
                RefreshAdded("");
                RefreshRejected("");
            }
        }

        protected DataRow CreateNewRowObject(ref DataTable dt)
        {

            DataRow drwDataRow = null;
            int intFieldCount = 0;

            // Create a new row object.
            drwDataRow = dt.NewRow();

            // Initialize the fields with the appropriate PowerHouse defaults based on data type.
            for (intFieldCount = 0; intFieldCount <= dt.Columns.Count - 1; intFieldCount++)
            {
                switch (dt.Columns[intFieldCount].DataType.ToString())
                {
                    case "System.String":
                        if (dt.Columns[intFieldCount].ColumnName != "ROW_ID")
                        {
                            drwDataRow[intFieldCount] = string.Empty;
                        }
                        break;
                    case "System.DateTime":
                        drwDataRow[intFieldCount] = DBNull.Value;
                        break;
                    case "System.Decimal":
                    case "System.Int16":
                    case "System.Int32":
                    case "System.Int64":
                    case "System.Boolean":
                    case "System.Double":
                        drwDataRow[intFieldCount] = 0;
                        break;
                }
            }

            return drwDataRow;
        }

        private void CreateSchema(string schemaName)
        {
            StreamReader sr = new StreamReader(txtScriptsLocation.Text + "CreateSchema.sql");

            try
            {
                if (File.Exists(txtScriptsLocation.Text + "CreateSchema.sql"))
                {
                    StringBuilder sb = new StringBuilder(string.Empty);
                    string line = string.Empty;
                    SqlCommand cm = new SqlCommand();

                    while (!sr.EndOfStream)
                    {
                        line = sr.ReadLine();
                        sb.Append(line.Replace("%DatabaseName%", txtDatabase.Text).Replace("%Schema%", schemaName).Replace("\"", "")).Append(Environment.NewLine);
                    }

                    if (OpenConnection(txtDatabase.Text))
                    {
                        RefreshStatus("Creating Schemas...");
                        cm = new SqlCommand(sb.ToString(), cn);
                        cm.ExecuteNonQuery();
                        CloseConnection();
                    }
                }
                else
                {
                    MessageBox.Show("File " + txtScriptsLocation.Text + "CreateSchema.sql does not exist.");
                    stopProcessing = true;
                    Cursor.Current = Cursors.Default;
                }
            }

            catch (SqlException ex)
            {
                if (txtDatabase.Text.ToUpper() == "101C")
                {
                    StreamWriter sw2 = new StreamWriter("Output_101C.log", true, System.Text.Encoding.Default);
                    sw2.Write(txtLog.Text);
                    sw2.Flush();
                    sw2.Close();
                    sw2.Dispose();
                }
                else if (txtDatabase.Text.ToUpper() == "MP")
                {
                    StreamWriter sw2 = new StreamWriter("Output_MP.log", true, System.Text.Encoding.Default);
                    sw2.Write(txtLog.Text);
                    sw2.Flush();
                    sw2.Close();
                    sw2.Dispose();
                }
                else if (txtDatabase.Text.ToUpper() == "SOLO")
                {
                    StreamWriter sw2 = new StreamWriter("Output_SOLO.log", true, System.Text.Encoding.Default);
                    sw2.Write(txtLog.Text);
                    sw2.Flush();
                    sw2.Close();
                    sw2.Dispose();
                }

                stopProcessing = true;
            }

            catch (Exception ex)
            {
                if (txtDatabase.Text.ToUpper() == "101C")
                {
                    StreamWriter sw2 = new StreamWriter("Output_101C.log", true, System.Text.Encoding.Default);
                    sw2.Write(txtLog.Text);
                    sw2.Flush();
                    sw2.Close();
                    sw2.Dispose();
                }
                else if (txtDatabase.Text.ToUpper() == "MP")
                {
                    StreamWriter sw2 = new StreamWriter("Output_MP.log", true, System.Text.Encoding.Default);
                    sw2.Write(txtLog.Text);
                    sw2.Flush();
                    sw2.Close();
                    sw2.Dispose();
                }
                else if (txtDatabase.Text.ToUpper() == "SOLO")
                {
                    StreamWriter sw2 = new StreamWriter("Output_SOLO.log", true, System.Text.Encoding.Default);
                    sw2.Write(txtLog.Text);
                    sw2.Flush();
                    sw2.Close();
                    sw2.Dispose();
                }

                stopProcessing = true;
            }

            sr.Close();
            sr.Dispose();
        }

        private void CreateStoredProcedures()
        {
            StreamReader sr = new StreamReader(txtScriptsLocation.Text + "CreateStoredProcedures.sql");

            try
            {
                if (File.Exists(txtScriptsLocation.Text + "CreateStoredProcedures.sql"))
                {
                    StringBuilder sb = new StringBuilder(string.Empty);
                    string line = string.Empty;
                    SqlCommand cm = new SqlCommand();

                    while (!sr.EndOfStream)
                    {
                        line = sr.ReadLine();
                        sb.Append(line.Replace("%DatabaseName%", txtDatabase.Text)).Append(Environment.NewLine);
                    }

                    if (OpenConnection(txtDatabase.Text))
                    {
                        RefreshStatus("Creating Stored Procedures...");
                        cm = new SqlCommand(sb.ToString(), cn);
                        cm.ExecuteNonQuery();
                        CloseConnection();
                    }
                }
                else
                {
                    MessageBox.Show("File " + txtScriptsLocation.Text + "CreateStoredProcedures.sql does not exist.");
                    stopProcessing = true;
                    Cursor.Current = Cursors.Default;
                }

                if (cmboLegacyDB.Text == "101C")
                {
                    sr = new StreamReader(txtScriptsLocation.Text + "Create101CStoredProcedures.sql");

                    if (File.Exists(txtScriptsLocation.Text + "Create101CStoredProcedures.sql"))
                    {
                        StringBuilder sb = new StringBuilder(string.Empty);
                        string line = string.Empty;
                        SqlCommand cm = new SqlCommand();

                        while (!sr.EndOfStream)
                        {
                            line = sr.ReadLine();
                            sb.Append(line.Replace("%DatabaseName%", txtDatabase.Text)).Append(Environment.NewLine);
                        }

                        if (OpenConnection(txtDatabase.Text))
                        {
                            RefreshStatus("Creating Stored Procedures...");
                            cm = new SqlCommand(sb.ToString(), cn);
                            cm.ExecuteNonQuery();
                            CloseConnection();
                        }
                    }
                    else
                    {
                        MessageBox.Show("File " + txtScriptsLocation.Text + "Create101CStoredProcedures.sql does not exist.");
                        stopProcessing = true;
                        Cursor.Current = Cursors.Default;
                    }
                }
            }

            catch (SqlException ex)
            {
                if (txtDatabase.Text.ToUpper() == "101C")
                {
                    StreamWriter sw2 = new StreamWriter("Output_101C.log", true, System.Text.Encoding.Default);
                    sw2.Write(txtLog.Text);
                    sw2.Flush();
                    sw2.Close();
                    sw2.Dispose();
                }
                else if (txtDatabase.Text.ToUpper() == "MP")
                {
                    StreamWriter sw2 = new StreamWriter("Output_MP.log", true, System.Text.Encoding.Default);
                    sw2.Write(txtLog.Text);
                    sw2.Flush();
                    sw2.Close();
                    sw2.Dispose();
                }
                else if (txtDatabase.Text.ToUpper() == "SOLO")
                {
                    StreamWriter sw2 = new StreamWriter("Output_SOLO.log", true, System.Text.Encoding.Default);
                    sw2.Write(txtLog.Text);
                    sw2.Flush();
                    sw2.Close();
                    sw2.Dispose();
                }

                stopProcessing = true;
            }

            catch (Exception ex)
            {
                if (txtDatabase.Text.ToUpper() == "101C")
                {
                    StreamWriter sw2 = new StreamWriter("Output_101C.log", true, System.Text.Encoding.Default);
                    sw2.Write(txtLog.Text);
                    sw2.Flush();
                    sw2.Close();
                    sw2.Dispose();
                }
                else if (txtDatabase.Text.ToUpper() == "MP")
                {
                    StreamWriter sw2 = new StreamWriter("Output_MP.log", true, System.Text.Encoding.Default);
                    sw2.Write(txtLog.Text);
                    sw2.Flush();
                    sw2.Close();
                    sw2.Dispose();
                }
                else if (txtDatabase.Text.ToUpper() == "SOLO")
                {
                    StreamWriter sw2 = new StreamWriter("Output_SOLO.log", true, System.Text.Encoding.Default);
                    sw2.Write(txtLog.Text);
                    sw2.Flush();
                    sw2.Close();
                    sw2.Dispose();
                }

                stopProcessing = true;
            }

            sr.Close();
            sr.Dispose();
        }

        private void CreateTables(string schema)
        {
            StringBuilder sb = new StringBuilder(string.Empty);
            StreamReader sr = new StreamReader(txtScriptsLocation.Text + "Create" + schema + "Tables.sql");
            StreamReader sr2 = new StreamReader(txtScriptsLocation.Text + "InsertSecurityRecords.sql");
            string table = string.Empty;
            SqlCommand cm = new SqlCommand();
            string sqlTable = string.Empty;
            string line = string.Empty;

            try
            {
                if (lstTables.SelectedIndex == -1)
                {
                    if (File.Exists(txtScriptsLocation.Text + "Create" + schema + "Tables.sql"))
                    {
                        sb = new StringBuilder(string.Empty);
                        line = string.Empty;

                        while (!sr.EndOfStream)
                        {
                            line = sr.ReadLine();
                            sb.Append(line.Replace("%DatabaseName%", txtDatabase.Text).Replace("\"", "")).Append(Environment.NewLine);
                        }

                        if (OpenConnection(txtDatabase.Text))
                        {
                            RefreshStatus("Creating Tables...");
                            cm = new SqlCommand(sb.ToString(), cn);
                            cm.ExecuteNonQuery();
                            cm.Dispose();
                            CloseConnection();
                        }

                        if (schema.ToUpper() == "SECURITY")
                        {
                            //Insert records into the Renaissance tables
                            sb = new StringBuilder(string.Empty);
                            line = string.Empty;

                            while (!sr2.EndOfStream)
                            {
                                line = sr2.ReadLine();
                                sb.Append(line.Replace("%DatabaseName%", txtDatabase.Text).Replace("\"", "")).Append(Environment.NewLine);
                            }

                            if (OpenConnection(txtDatabase.Text))
                            {
                                cm = new SqlCommand(sb.ToString(), cn);
                                cm.ExecuteNonQuery();
                                cm.Dispose();
                                CloseConnection();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("File " + txtScriptsLocation.Text + "Create" + schema + "Tables.sql does not exist.");
                        stopProcessing = true;
                        Cursor.Current = Cursors.Default;
                    }
                }
                else
                {
                    if (chkStructureOnly.Checked == false)
                    {
                        foreach (string item in lstTables.SelectedItems)
                        {
                            //Get the SQL Table Name
                            //sqlTable = relationlist.Find(i => i.Contains(item));
                            //sqlTable = sqlTable.Substring(sqlTable.IndexOf("~~") + 2);
                            sqlTable = item.Substring(0, item.IndexOf(" ")).Trim();

                            RefreshStatus("Truncating table " + sqlTable + "...");
                            OpenConnection(txtDatabase.Text);
                            cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + sqlTable + "]", cn);
                            cm.ExecuteNonQuery();
                            cm.Dispose();
                            CloseConnection();
                        }
                    }
                }
            }

            catch (SqlException ex)
            {
                if (txtDatabase.Text.ToUpper() == "101C")
                {
                    StreamWriter sw2 = new StreamWriter("Output_101C.log", true, System.Text.Encoding.Default);
                    sw2.Write(txtLog.Text);
                    sw2.Flush();
                    sw2.Close();
                    sw2.Dispose();
                }
                else if (txtDatabase.Text.ToUpper() == "MP")
                {
                    StreamWriter sw2 = new StreamWriter("Output_MP.log", true, System.Text.Encoding.Default);
                    sw2.Write(txtLog.Text);
                    sw2.Flush();
                    sw2.Close();
                    sw2.Dispose();
                }
                else if (txtDatabase.Text.ToUpper() == "SOLO")
                {
                    StreamWriter sw2 = new StreamWriter("Output_SOLO.log", true, System.Text.Encoding.Default);
                    sw2.Write(txtLog.Text);
                    sw2.Flush();
                    sw2.Close();
                    sw2.Dispose();
                }

                stopProcessing = true;
            }

            catch (Exception ex)
            {
                if (txtDatabase.Text.ToUpper() == "101C")
                {
                    StreamWriter sw2 = new StreamWriter("Output_101C.log", true, System.Text.Encoding.Default);
                    sw2.Write(txtLog.Text);
                    sw2.Flush();
                    sw2.Close();
                    sw2.Dispose();
                }
                else if (txtDatabase.Text.ToUpper() == "MP")
                {
                    StreamWriter sw2 = new StreamWriter("Output_MP.log", true, System.Text.Encoding.Default);
                    sw2.Write(txtLog.Text);
                    sw2.Flush();
                    sw2.Close();
                    sw2.Dispose();
                }
                else if (txtDatabase.Text.ToUpper() == "SOLO")
                {
                    StreamWriter sw2 = new StreamWriter("Output_SOLO.log", true, System.Text.Encoding.Default);
                    sw2.Write(txtLog.Text);
                    sw2.Flush();
                    sw2.Close();
                    sw2.Dispose();
                }

                stopProcessing = true;
            }

            sr.Close();
            sr.Dispose();
        }

        private void CreateViews()
        {
            StreamReader sr = new StreamReader(txtScriptsLocation.Text + "CreateViews.sql");

            try
            {
                if (File.Exists(txtScriptsLocation.Text + "CreateViews.sql"))
                {
                    StringBuilder sb = new StringBuilder(string.Empty);
                    string line = string.Empty;
                    SqlCommand cm = new SqlCommand();

                    while (!sr.EndOfStream)
                    {
                        line = sr.ReadLine();
                        sb.Append(line.Replace("%SQLServer%", txtServer.Text).Replace("%DatabaseName%", txtDatabase.Text).Replace("%ScriptLocation%", txtScriptsLocation.Text)).Append(Environment.NewLine);
                    }

                    if (OpenConnection(txtDatabase.Text))
                    {
                        RefreshStatus("Creating Views...");

                        cm = new SqlCommand(sb.ToString(), cn);
                        cm.ExecuteNonQuery();
                        CloseConnection();
                    }
                }
                else
                {
                    MessageBox.Show("File " + txtScriptsLocation.Text + "CreateViews.sql does not exist.");
                    stopProcessing = true;
                    Cursor.Current = Cursors.Default;
                }
            }

            catch (SqlException ex)
            {
                if (txtDatabase.Text.ToUpper() == "101C")
                {
                    StreamWriter sw2 = new StreamWriter("Output_101C.log", true, System.Text.Encoding.Default);
                    sw2.Write(txtLog.Text);
                    sw2.Flush();
                    sw2.Close();
                    sw2.Dispose();
                }
                else if (txtDatabase.Text.ToUpper() == "MP")
                {
                    StreamWriter sw2 = new StreamWriter("Output_MP.log", true, System.Text.Encoding.Default);
                    sw2.Write(txtLog.Text);
                    sw2.Flush();
                    sw2.Close();
                    sw2.Dispose();
                }
                else if (txtDatabase.Text.ToUpper() == "SOLO")
                {
                    StreamWriter sw2 = new StreamWriter("Output_SOLO.log", true, System.Text.Encoding.Default);
                    sw2.Write(txtLog.Text);
                    sw2.Flush();
                    sw2.Close();
                    sw2.Dispose();
                }

                stopProcessing = true;
            }

            catch (Exception ex)
            {
                if (txtDatabase.Text.ToUpper() == "101C")
                {
                    StreamWriter sw2 = new StreamWriter("Output_101C.log", true, System.Text.Encoding.Default);
                    sw2.Write(txtLog.Text);
                    sw2.Flush();
                    sw2.Close();
                    sw2.Dispose();
                }
                else if (txtDatabase.Text.ToUpper() == "MP")
                {
                    StreamWriter sw2 = new StreamWriter("Output_MP.log", true, System.Text.Encoding.Default);
                    sw2.Write(txtLog.Text);
                    sw2.Flush();
                    sw2.Close();
                    sw2.Dispose();
                }
                else if (txtDatabase.Text.ToUpper() == "SOLO")
                {
                    StreamWriter sw2 = new StreamWriter("Output_SOLO.log", true, System.Text.Encoding.Default);
                    sw2.Write(txtLog.Text);
                    sw2.Flush();
                    sw2.Close();
                    sw2.Dispose();
                }

                stopProcessing = true;
            }

            sr.Close();
            sr.Dispose();
        }

        private byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        private DateTime? GetDateFromString(string value)
        {
            if (value.Length == 6)
            {
                if (value != "000000")
                {
                    if (Convert.ToInt16(value.Substring(0, 2)) > Convert.ToInt16(txtMinimumYearCutoff.Text))
                        value = "19" + value;
                    else
                        value = "20" + value;
                }
            }
            else if (value.Length == 0)
            {
                value = "0";
            }

            int numberValue = Convert.ToInt32(value);
            DateTime? dateValue = (DateTime?)null;

            if (numberValue != 0)
            {
                if (numberValue != 0)
                {
                    int year = 0;
                    int month = 0;
                    int day = 0;

                    year = Convert.ToInt32(value.Substring(0, 4));
                    month = Convert.ToInt32(value.Substring(4, 2));
                    day = Convert.ToInt32(value.Substring(6, 2));

                    dateValue = new System.DateTime(year, month, day);
                }
            }

            return dateValue;
        }

        private int GetOverpunchDigit(string value)
        {
            switch (value)
            {
                case "{":
                    return 0;
                case "A":
                    return 1;
                case "B":
                    return 2;
                case "C":
                    return 3;
                case "D":
                    return 4;
                case "E":
                    return 5;
                case "F":
                    return 6;
                case "G":
                    return 7;
                case "H":
                    return 8;
                case "I":
                    return 9;
                case "}":
                    return 0;
                case "J":
                    return 1;
                case "K":
                    return 2;
                case "L":
                    return 3;
                case "M":
                    return 4;
                case "N":
                    return 5;
                case "O":
                    return 6;
                case "P":
                    return 7;
                case "Q":
                    return 8;
                case "R":
                    return 9;
                case "p":
                    return 0;
                case "q":
                    return 1;
                case "r":
                    return 2;
                case "s":
                    return 3;
                case "t":
                    return 4;
                case "u":
                    return 5;
                case "v":
                    return 6;
                case "w":
                    return 7;
                case "x":
                    return 8;
                case "y":
                    return 9;
                default:
                    return 0;
            }
        }

        private bool GetOverpunchSign(string value)
        {
            switch (value)
            {
                case "p":
                    return false;
                case "q":
                    return false;
                case "r":
                    return false;
                case "s":
                    return false;
                case "t":
                    return false;
                case "u":
                    return false;
                case "v":
                    return false;
                case "w":
                    return false;
                case "x":
                    return false;
                case "y":
                    return false;
                case "{":
                    return true;
                case "A":
                    return true;
                case "B":
                    return true;
                case "C":
                    return true;
                case "D":
                    return true;
                case "E":
                    return true;
                case "F":
                    return true;
                case "G":
                    return true;
                case "H":
                    return true;
                case "I":
                    return true;
                case "}":
                    return false;
                case "J":
                    return false;
                case "K":
                    return false;
                case "L":
                    return false;
                case "M":
                    return false;
                case "N":
                    return false;
                case "O":
                    return false;
                case "P":
                    return false;
                case "Q":
                    return false;
                case "R":
                    return false;
                default:
                    return false;
            }
        }

        private void HandleBcpException(ref SqlBulkCopy bulkCopy, Exception ex, string tableName)
        {
            if (ex.Message.Contains("Received an invalid column length from the bcp client for colid"))
            {
                string pattern = @"\d+";
                Match match = Regex.Match(ex.Message.ToString(), pattern);
                var index = Convert.ToInt32(match.Value) - 1;

                FieldInfo fi = typeof(SqlBulkCopy).GetField("_sortedColumnMappings", BindingFlags.NonPublic | BindingFlags.Instance);
                var sortedColumns = fi.GetValue(bulkCopy);
                var items = (Object[])sortedColumns.GetType().GetField("_items", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(sortedColumns);

                FieldInfo itemdata = items[index].GetType().GetField("_metadata", BindingFlags.NonPublic | BindingFlags.Instance);
                var metadata = itemdata.GetValue(items[index]);

                var col = metadata.GetType().GetField("column", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).GetValue(metadata);
                var length = metadata.GetType().GetField("length", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).GetValue(metadata);
                string err = string.Format("Column: {0} contains data with a length greater than: {1}", col, length);
            }
            RefreshLog(tableName + ": " + ex.Message);
        }

        private void InsertData(string fileName, string schema, string table, int recordLength, string columnString)
        {
            ArrayList check_doc_clinic_nbr = new ArrayList();
            ArrayList check_doc_clinic_nbr2 = new ArrayList();
            ArrayList check_doc_clinic_nbr3 = new ArrayList();
            ArrayList check_doc_clinic_nbr4 = new ArrayList();
            ArrayList check_doc_loc = new ArrayList();
            ArrayList check_doc_loc2 = new ArrayList();
            ArrayList parentChildren = new ArrayList();

            char[] buffer = new char[recordLength];

            DataTable dt = new DataTable();
            DataTable dt_doc_clinic_nbr = new DataTable();
            DataTable dt_doc_clinic_nbr2 = new DataTable();
            DataTable dt_doc_clinic_nbr3 = new DataTable();
            DataTable dt_doc_clinic_nbr4 = new DataTable();
            DataTable dt_doc_loc = new DataTable();
            DataTable dt_doc_loc2 = new DataTable();
            DataTable dt_oscar_provider_no = new DataTable();

            DateTime? dateValue = default(System.DateTime);

            decimal? doc_clinic_nbr = 0;
            decimal? doc_clinic_nbr1 = 0;
            decimal? doc_clinic_nbr2 = 0;
            decimal? doc_clinic_nbr3 = 0;
            decimal? doc_clinic_nbr4 = 0;
            decimal? doc_clinic_nbr5 = 0;
            decimal? doc_clinic_nbr6 = 0;
            decimal? doc_clinic_seq_no = 0;
            decimal? doc_loc_seq_no = 0;
            decimal? numberValue = 0;

            int count_doc_clinic_nbr = 0;
            int count_doc_clinic_nbr3 = 0;
            int count_doc_clinic_nbr4 = 0;
            int count_doc_loc = 0;
            int count_doc_loc2 = 0;
            int factor = 0;
            int occurs = 0;
            int parentsize = 0;
            int parentoccurs = 0;
            int recReadCount = 0;
            int rejected = 0;
            int size = 0;
            int startPosition = 0;

            string cName = string.Empty;
            string columnName = string.Empty;
            string columnName2 = string.Empty;
            string database = txtDatabase.Text;
            string docloc = string.Empty;
            string fullFileName = txtFileName.Text;
            string line = string.Empty;
            string oscar_provider_no = string.Empty;
            string parent = "";
            string redefineElement = "";
            string signed = string.Empty;
            string tableName = table.Replace("-", "_");
            string tName = string.Empty;
            string value = string.Empty;
            string whereClause = string.Empty;

            string[] ar = columnString.Split(',');
            string[] column = null;
            string[] recordArray = { };

            StringBuilder sb = new StringBuilder(recordLength, recordLength);

            var doc_nbr = "";

            fullFileName += fileName;

            if (fullFileName.EndsWith("ADJ_CLAIM_FILE_BK"))
            {
                SqlCommand cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[" + tableName + "]", cn);
                cm.ExecuteNonQuery();

                Load_ADJ_CLAIM_FILE_BK(ref dt, schema, table, fileName, recordLength, columnString, ref recReadCount);

                // Perform the bulk copy.
                PerformBulkCopy(ref dt, database, schema, tableName);
                RefreshAdded(string.Format(string.Format("{0:n0}", totalCount) + " records inserted into " + tableName + " so far..."));

                // Perform a final count.
                string noRecords = string.Empty;
                cm = new SqlCommand("SELECT Count(-1) FROM [" + txtDatabase.Text.ToString() + "].[" + schema + "].[" + tableName + "]", cn);
                noRecords = Convert.ToInt32(cm.ExecuteScalar()).ToString();
                RefreshLog(tableName + ": " + noRecords + " inserted out of " + recReadCount.ToString() + " read" + (noRecords == totalCount.ToString() || rejected > 0 ? "" : " ****"));
                RefreshAdded(string.Format(string.Format("{0:n0}", noRecords) + " records inserted into table " + tableName));
            }
            else
            {
                if (!File.Exists(fullFileName))
                {

                    if (!fullFileName.EndsWith(".DAT", StringComparison.CurrentCultureIgnoreCase))
                        fullFileName += ".DAT";
                    if (!File.Exists(fullFileName))
                    {
                        RefreshLog("Missing dat file for " + table);
                        return;
                    }
                }

                RefreshRead("");
                RefreshAdded("");
                RefreshRejected("");
                recAddedCount = 0;
                recReadCount = 0;
                totalCount = 0;

                var binFile = new BinaryReader(new FileStream(fullFileName, FileMode.Open));

                SqlCommand cm = new SqlCommand("SELECT * FROM [" + txtDatabase.Text.ToString() + "].[" + schema + "].[" + tableName + "] WHERE 0 = 1", cn);
                SqlDataAdapter da = new SqlDataAdapter(cm);

                try
                {
                    da.Fill(dt);
                }
                catch (SqlException)
                {
                    RefreshLog(tableName + ": Missing table ****");
                    return;
                }

                // Make sure the table is empty.
                cm.Dispose();
                da.Dispose();
                cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[" + tableName + "]", cn);
                cm.ExecuteNonQuery();


                if (tableName == "F002_CLAIMS_MSTR_HDR")
                {
                    if (claimsMstrDtlLoaded == false)
                    {
                        // Make sure the table is empty.
                        cm.Dispose();
                        da.Dispose();
                        cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[F002_CLAIMS_MSTR_DTL]", cn);
                        cm.ExecuteNonQuery();
                    }

                    if (claimsMstrDtlDescLoaded == false)
                    {
                        // Make sure the table is empty.
                        cm.Dispose();
                        da.Dispose();
                        cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[F002_CLAIMS_MSTR_DESC]", cn);
                        cm.ExecuteNonQuery();
                    }
                }
                else if (tableName == "F002_CLAIMS_MSTR_DESC")
                {
                    if (claimsMstrHdrLoaded == false)
                    {
                        // Make sure the table is empty.
                        cm.Dispose();
                        da.Dispose();
                        cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[F002_CLAIMS_MSTR_HDR]", cn);
                        cm.ExecuteNonQuery();
                    }

                    if (claimsMstrDtlLoaded == false)
                    {
                        // Make sure the table is empty.
                        cm.Dispose();
                        da.Dispose();
                        cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[F002_CLAIMS_MSTR_DTL]", cn);
                        cm.ExecuteNonQuery();
                    }
                }
                else if (tableName == "F002_CLAIMS_MSTR_DTL")
                {
                    if (claimsMstrHdrLoaded == false)
                    {
                        // Make sure the table is empty.
                        cm.Dispose();
                        da.Dispose();
                        cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[F002_CLAIMS_MSTR_HDR]", cn);
                        cm.ExecuteNonQuery();
                    }

                    if (claimsMstrDtlDescLoaded == false)
                    {
                        // Make sure the table is empty.
                        cm.Dispose();
                        da.Dispose();
                        cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[F002_CLAIMS_MSTR_DESC]", cn);
                        cm.ExecuteNonQuery();
                    }
                }
                else if (tableName == "ICONST_MSTR_REC")
                {
                    if (constantsMstrRec1Loaded == false)
                    {
                        // Make sure the table is empty.
                        cm.Dispose();
                        da.Dispose();
                        cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[CONSTANTS_MSTR_REC_1]", cn);
                        cm.ExecuteNonQuery();
                    }

                    if (constantsMstrRec2Loaded == false)
                    {
                        // Make sure the table is empty.
                        cm.Dispose();
                        da.Dispose();
                        cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[CONSTANTS_MSTR_REC_2]", cn);
                        cm.ExecuteNonQuery();
                    }

                    if (constantsMstrRec3Loaded == false)
                    {
                        // Make sure the table is empty.
                        cm.Dispose();
                        da.Dispose();
                        cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[CONSTANTS_MSTR_REC_3]", cn);
                        cm.ExecuteNonQuery();
                    }

                    if (constantsMstrRec4Loaded == false)
                    {
                        // Make sure the table is empty.
                        cm.Dispose();
                        da.Dispose();
                        cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[CONSTANTS_MSTR_REC_4]", cn);
                        cm.ExecuteNonQuery();
                    }

                    if (constantsMstrRec5Loaded == false)
                    {
                        // Make sure the table is empty.
                        cm.Dispose();
                        da.Dispose();
                        cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[CONSTANTS_MSTR_REC_5]", cn);
                        cm.ExecuteNonQuery();
                    }

                    if (constantsMstrRec6Loaded == false)
                    {
                        // Make sure the table is empty.
                        cm.Dispose();
                        da.Dispose();
                        cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[CONSTANTS_MSTR_REC_6]", cn);
                        cm.ExecuteNonQuery();
                    }

                    if (constantsMstrRec7Loaded == false)
                    {
                        // Make sure the table is empty.
                        cm.Dispose();
                        da.Dispose();
                        cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[CONSTANTS_MSTR_REC_7]", cn);
                        cm.ExecuteNonQuery();
                    }
                }
                else if (tableName == "CONSTANTS_MSTR_REC_1")
                {
                    if (iconstMstrRecLoaded == false)
                    {
                        // Make sure the table is empty.
                        cm.Dispose();
                        da.Dispose();
                        cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[ICONST_MSTR_REC]", cn);
                        cm.ExecuteNonQuery();
                    }

                    if (constantsMstrRec2Loaded == false)
                    {
                        // Make sure the table is empty.
                        cm.Dispose();
                        da.Dispose();
                        cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[CONSTANTS_MSTR_REC_2]", cn);
                        cm.ExecuteNonQuery();
                    }

                    if (constantsMstrRec3Loaded == false)
                    {
                        // Make sure the table is empty.
                        cm.Dispose();
                        da.Dispose();
                        cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[CONSTANTS_MSTR_REC_3]", cn);
                        cm.ExecuteNonQuery();
                    }

                    if (constantsMstrRec4Loaded == false)
                    {
                        // Make sure the table is empty.
                        cm.Dispose();
                        da.Dispose();
                        cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[CONSTANTS_MSTR_REC_4]", cn);
                        cm.ExecuteNonQuery();
                    }

                    if (constantsMstrRec5Loaded == false)
                    {
                        // Make sure the table is empty.
                        cm.Dispose();
                        da.Dispose();
                        cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[CONSTANTS_MSTR_REC_5]", cn);
                        cm.ExecuteNonQuery();
                    }

                    if (constantsMstrRec6Loaded == false)
                    {
                        // Make sure the table is empty.
                        cm.Dispose();
                        da.Dispose();
                        cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[CONSTANTS_MSTR_REC_6]", cn);
                        cm.ExecuteNonQuery();
                    }

                    if (constantsMstrRec7Loaded == false)
                    {
                        // Make sure the table is empty.
                        cm.Dispose();
                        da.Dispose();
                        cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[CONSTANTS_MSTR_REC_7]", cn);
                        cm.ExecuteNonQuery();
                    }
                }
                else if (tableName == "CONSTANTS_MSTR_REC_2")
                {
                    if (iconstMstrRecLoaded == false)
                    {
                        // Make sure the table is empty.
                        cm.Dispose();
                        da.Dispose();
                        cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[ICONST_MSTR_REC]", cn);
                        cm.ExecuteNonQuery();
                    }

                    if (constantsMstrRec1Loaded == false)
                    {
                        // Make sure the table is empty.
                        cm.Dispose();
                        da.Dispose();
                        cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[CONSTANTS_MSTR_REC_1]", cn);
                        cm.ExecuteNonQuery();
                    }

                    if (constantsMstrRec3Loaded == false)
                    {
                        // Make sure the table is empty.
                        cm.Dispose();
                        da.Dispose();
                        cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[CONSTANTS_MSTR_REC_3]", cn);
                        cm.ExecuteNonQuery();
                    }

                    if (constantsMstrRec4Loaded == false)
                    {
                        // Make sure the table is empty.
                        cm.Dispose();
                        da.Dispose();
                        cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[CONSTANTS_MSTR_REC_4]", cn);
                        cm.ExecuteNonQuery();
                    }

                    if (constantsMstrRec5Loaded == false)
                    {
                        // Make sure the table is empty.
                        cm.Dispose();
                        da.Dispose();
                        cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[CONSTANTS_MSTR_REC_5]", cn);
                        cm.ExecuteNonQuery();
                    }

                    if (constantsMstrRec6Loaded == false)
                    {
                        // Make sure the table is empty.
                        cm.Dispose();
                        da.Dispose();
                        cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[CONSTANTS_MSTR_REC_6]", cn);
                        cm.ExecuteNonQuery();
                    }

                    if (constantsMstrRec7Loaded == false)
                    {
                        // Make sure the table is empty.
                        cm.Dispose();
                        da.Dispose();
                        cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[CONSTANTS_MSTR_REC_7]", cn);
                        cm.ExecuteNonQuery();
                    }
                }
                else if (tableName == "CONSTANTS_MSTR_REC_3")
                {
                    if (iconstMstrRecLoaded == false)
                    {
                        // Make sure the table is empty.
                        cm.Dispose();
                        da.Dispose();
                        cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[ICONST_MSTR_REC]", cn);
                        cm.ExecuteNonQuery();
                    }

                    if (constantsMstrRec1Loaded == false)
                    {
                        // Make sure the table is empty.
                        cm.Dispose();
                        da.Dispose();
                        cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[CONSTANTS_MSTR_REC_1]", cn);
                        cm.ExecuteNonQuery();
                    }

                    if (constantsMstrRec2Loaded == false)
                    {
                        // Make sure the table is empty.
                        cm.Dispose();
                        da.Dispose();
                        cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[CONSTANTS_MSTR_REC_2]", cn);
                        cm.ExecuteNonQuery();
                    }

                    if (constantsMstrRec4Loaded == false)
                    {
                        // Make sure the table is empty.
                        cm.Dispose();
                        da.Dispose();
                        cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[CONSTANTS_MSTR_REC_4]", cn);
                        cm.ExecuteNonQuery();
                    }

                    if (constantsMstrRec5Loaded == false)
                    {
                        // Make sure the table is empty.
                        cm.Dispose();
                        da.Dispose();
                        cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[CONSTANTS_MSTR_REC_5]", cn);
                        cm.ExecuteNonQuery();
                    }

                    if (constantsMstrRec6Loaded == false)
                    {
                        // Make sure the table is empty.
                        cm.Dispose();
                        da.Dispose();
                        cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[CONSTANTS_MSTR_REC_6]", cn);
                        cm.ExecuteNonQuery();
                    }

                    if (constantsMstrRec7Loaded == false)
                    {
                        // Make sure the table is empty.
                        cm.Dispose();
                        da.Dispose();
                        cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[CONSTANTS_MSTR_REC_7]", cn);
                        cm.ExecuteNonQuery();
                    }
                }
                else if (tableName == "CONSTANTS_MSTR_REC_4")
                {
                    if (iconstMstrRecLoaded == false)
                    {
                        // Make sure the table is empty.
                        cm.Dispose();
                        da.Dispose();
                        cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[ICONST_MSTR_REC]", cn);
                        cm.ExecuteNonQuery();
                    }

                    if (constantsMstrRec1Loaded == false)
                    {
                        // Make sure the table is empty.
                        cm.Dispose();
                        da.Dispose();
                        cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[CONSTANTS_MSTR_REC_1]", cn);
                        cm.ExecuteNonQuery();
                    }

                    if (constantsMstrRec2Loaded == false)
                    {
                        // Make sure the table is empty.
                        cm.Dispose();
                        da.Dispose();
                        cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[CONSTANTS_MSTR_REC_2]", cn);
                        cm.ExecuteNonQuery();
                    }

                    if (constantsMstrRec3Loaded == false)
                    {
                        // Make sure the table is empty.
                        cm.Dispose();
                        da.Dispose();
                        cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[CONSTANTS_MSTR_REC_3]", cn);
                        cm.ExecuteNonQuery();
                    }

                    if (constantsMstrRec5Loaded == false)
                    {
                        // Make sure the table is empty.
                        cm.Dispose();
                        da.Dispose();
                        cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[CONSTANTS_MSTR_REC_5]", cn);
                        cm.ExecuteNonQuery();
                    }

                    if (constantsMstrRec6Loaded == false)
                    {
                        // Make sure the table is empty.
                        cm.Dispose();
                        da.Dispose();
                        cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[CONSTANTS_MSTR_REC_6]", cn);
                        cm.ExecuteNonQuery();
                    }

                    if (constantsMstrRec7Loaded == false)
                    {
                        // Make sure the table is empty.
                        cm.Dispose();
                        da.Dispose();
                        cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[CONSTANTS_MSTR_REC_7]", cn);
                        cm.ExecuteNonQuery();
                    }
                }
                else if (tableName == "CONSTANTS_MSTR_REC_5")
                {
                    if (iconstMstrRecLoaded == false)
                    {
                        // Make sure the table is empty.
                        cm.Dispose();
                        da.Dispose();
                        cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[ICONST_MSTR_REC]", cn);
                        cm.ExecuteNonQuery();
                    }

                    if (constantsMstrRec1Loaded == false)
                    {
                        // Make sure the table is empty.
                        cm.Dispose();
                        da.Dispose();
                        cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[CONSTANTS_MSTR_REC_1]", cn);
                        cm.ExecuteNonQuery();
                    }

                    if (constantsMstrRec2Loaded == false)
                    {
                        // Make sure the table is empty.
                        cm.Dispose();
                        da.Dispose();
                        cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[CONSTANTS_MSTR_REC_2]", cn);
                        cm.ExecuteNonQuery();
                    }

                    if (constantsMstrRec3Loaded == false)
                    {
                        // Make sure the table is empty.
                        cm.Dispose();
                        da.Dispose();
                        cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[CONSTANTS_MSTR_REC_3]", cn);
                        cm.ExecuteNonQuery();
                    }

                    if (constantsMstrRec4Loaded == false)
                    {
                        // Make sure the table is empty.
                        cm.Dispose();
                        da.Dispose();
                        cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[CONSTANTS_MSTR_REC_4]", cn);
                        cm.ExecuteNonQuery();
                    }

                    if (constantsMstrRec6Loaded == false)
                    {
                        // Make sure the table is empty.
                        cm.Dispose();
                        da.Dispose();
                        cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[CONSTANTS_MSTR_REC_6]", cn);
                        cm.ExecuteNonQuery();
                    }

                    if (constantsMstrRec7Loaded == false)
                    {
                        // Make sure the table is empty.
                        cm.Dispose();
                        da.Dispose();
                        cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[CONSTANTS_MSTR_REC_7]", cn);
                        cm.ExecuteNonQuery();
                    }
                }
                else if (tableName == "CONSTANTS_MSTR_REC_6")
                {
                    if (iconstMstrRecLoaded == false)
                    {
                        // Make sure the table is empty.
                        cm.Dispose();
                        da.Dispose();
                        cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[ICONST_MSTR_REC]", cn);
                        cm.ExecuteNonQuery();
                    }

                    if (constantsMstrRec1Loaded == false)
                    {
                        // Make sure the table is empty.
                        cm.Dispose();
                        da.Dispose();
                        cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[CONSTANTS_MSTR_REC_1]", cn);
                        cm.ExecuteNonQuery();
                    }

                    if (constantsMstrRec2Loaded == false)
                    {
                        // Make sure the table is empty.
                        cm.Dispose();
                        da.Dispose();
                        cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[CONSTANTS_MSTR_REC_2]", cn);
                        cm.ExecuteNonQuery();
                    }

                    if (constantsMstrRec3Loaded == false)
                    {
                        // Make sure the table is empty.
                        cm.Dispose();
                        da.Dispose();
                        cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[CONSTANTS_MSTR_REC_3]", cn);
                        cm.ExecuteNonQuery();
                    }

                    if (constantsMstrRec4Loaded == false)
                    {
                        // Make sure the table is empty.
                        cm.Dispose();
                        da.Dispose();
                        cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[CONSTANTS_MSTR_REC_4]", cn);
                        cm.ExecuteNonQuery();
                    }

                    if (constantsMstrRec5Loaded == false)
                    {
                        // Make sure the table is empty.
                        cm.Dispose();
                        da.Dispose();
                        cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[CONSTANTS_MSTR_REC_5]", cn);
                        cm.ExecuteNonQuery();
                    }

                    if (constantsMstrRec7Loaded == false)
                    {
                        // Make sure the table is empty.
                        cm.Dispose();
                        da.Dispose();
                        cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[CONSTANTS_MSTR_REC_7]", cn);
                        cm.ExecuteNonQuery();
                    }
                }
                else if (tableName == "CONSTANTS_MSTR_REC_7")
                {
                    if (iconstMstrRecLoaded == false)
                    {
                        // Make sure the table is empty.
                        cm.Dispose();
                        da.Dispose();
                        cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[ICONST_MSTR_REC]", cn);
                        cm.ExecuteNonQuery();
                    }

                    if (constantsMstrRec1Loaded == false)
                    {
                        // Make sure the table is empty.
                        cm.Dispose();
                        da.Dispose();
                        cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[CONSTANTS_MSTR_REC_1]", cn);
                        cm.ExecuteNonQuery();
                    }

                    if (constantsMstrRec2Loaded == false)
                    {
                        // Make sure the table is empty.
                        cm.Dispose();
                        da.Dispose();
                        cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[CONSTANTS_MSTR_REC_2]", cn);
                        cm.ExecuteNonQuery();
                    }

                    if (constantsMstrRec3Loaded == false)
                    {
                        // Make sure the table is empty.
                        cm.Dispose();
                        da.Dispose();
                        cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[CONSTANTS_MSTR_REC_3]", cn);
                        cm.ExecuteNonQuery();
                    }

                    if (constantsMstrRec4Loaded == false)
                    {
                        // Make sure the table is empty.
                        cm.Dispose();
                        da.Dispose();
                        cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[CONSTANTS_MSTR_REC_4]", cn);
                        cm.ExecuteNonQuery();
                    }

                    if (constantsMstrRec5Loaded == false)
                    {
                        // Make sure the table is empty.
                        cm.Dispose();
                        da.Dispose();
                        cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[CONSTANTS_MSTR_REC_5]", cn);
                        cm.ExecuteNonQuery();
                    }

                    if (constantsMstrRec6Loaded == false)
                    {
                        // Make sure the table is empty.
                        cm.Dispose();
                        da.Dispose();
                        cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[CONSTANTS_MSTR_REC_6]", cn);
                        cm.ExecuteNonQuery();
                    }
                }
                else if (tableName == "F020_DOCTOR_MSTR")
                {
                    // Make sure the table is empty.
                    cm.Dispose();
                    da.Dispose();
                    cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[F020C_DOC_CLINIC_NEXT_BATCH_NBR]", cn);
                    cm.ExecuteNonQuery();

                    // Make sure the table is empty.
                    cm.Dispose();
                    da.Dispose();
                    cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[F020L_DOC_LOCATIONS]", cn);
                    cm.ExecuteNonQuery();

                    // Make sure the table is empty.
                    cm.Dispose();
                    da.Dispose();
                    cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[F020_DOCTOR_EXTRA]", cn);
                    cm.ExecuteNonQuery();
                }
                else if (tableName == "F200_OSCAR_PROVIDER")
                {
                    // Make sure the table is empty.
                    cm.Dispose();
                    da.Dispose();
                    cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[F200C_OSCAR_PROVIDER_NEXT_BATCH_NBR]", cn);
                    cm.ExecuteNonQuery();
                }
                else if (tableName == "F020_DOCTOR_AUDIT")
                {
                    // Make sure the table is empty.
                    cm.Dispose();
                    da.Dispose();
                    cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[F020C_DOCTOR_AUDIT_NEXT_BATCH_NBR]", cn);
                    cm.ExecuteNonQuery();

                    // Make sure the table is empty.
                    cm.Dispose();
                    da.Dispose();
                    cm = new SqlCommand("TRUNCATE TABLE [" + txtDatabase.Text.ToString() + "].[" + schema + "].[F020L_DOCTOR_AUDIT_LOCATIONS]", cn);
                    cm.ExecuteNonQuery();
                }

                while (true)
                {
                    doc_clinic_nbr1 = 0;
                    doc_clinic_nbr2 = 0;
                    doc_clinic_nbr3 = 0;
                    doc_clinic_nbr4 = 0;
                    doc_clinic_nbr5 = 0;
                    doc_clinic_nbr6 = 0;

                    var buf = binFile.ReadBytes(recordLength);

                    if (buf.Length < recordLength)
                    {
                        break;
                    }
                    else
                    {
                        line = string.Empty;
                        for (int i = 0; i < buf.Length; i++)
                        {
                            line += (char)buf[i];
                        }
                    }

                    if (line.IndexOf("MACDONGAR") > -1)
                    {
                        int ii = 1;
                    }

                    recReadCount += 1;
                    //totalCount += 1;

                    // Ensure that the large files load without 'Out of Memory' errors...
                    if (recAddedCount == 100000)
                    {
                        recAddedCount = 0;


                        // Perform the bulk copy.
                        PerformBulkCopy(ref dt, database, schema, tableName);
                        RefreshAdded(string.Format(string.Format("{0:n0}", totalCount - rejected) + " records inserted into " + tableName + " so far..."));

                        if (tableName == "F002_CLAIMS_MSTR_HDR")
                        {
                            claimsMstrHdrLoaded = true;
                        }

                        if (tableName == "F002_CLAIMS_MSTR_DTL")
                        {
                            claimsMstrDtlLoaded = true;
                        }

                        if (tableName == "F002_CLAIMS_MSTR_DESC")
                        {
                            claimsMstrDtlDescLoaded = true;
                        }

                        if (tableName == "ICONST_MSTR_REC")
                        {
                            iconstMstrRecLoaded = true;
                        }

                        if (tableName == "CONSTANTS_MSTR_REC_1")
                        {
                            constantsMstrRec1Loaded = true;
                        }

                        if (tableName == "CONSTANTS_MSTR_REC_2")
                        {
                            constantsMstrRec2Loaded = true;
                        }

                        if (tableName == "CONSTANTS_MSTR_REC_3")
                        {
                            constantsMstrRec3Loaded = true;
                        }
                        if (tableName == "CONSTANTS_MSTR_REC_4")
                        {
                            constantsMstrRec4Loaded = true;
                        }
                        if (tableName == "CONSTANTS_MSTR_REC_5")
                        {
                            constantsMstrRec5Loaded = true;
                        }
                        if (tableName == "CONSTANTS_MSTR_REC_6")
                        {
                            constantsMstrRec6Loaded = true;
                        }
                        if (tableName == "CONSTANTS_MSTR_REC_7")
                        {
                            constantsMstrRec7Loaded = true;
                        }

                        if (dt_doc_clinic_nbr.Rows.Count > 0)
                        {
                            PerformBulkCopy(ref dt_doc_clinic_nbr, database, schema, "F020C_DOC_CLINIC_NEXT_BATCH_NBR");
                            RefreshAdded(string.Format(string.Format("{0:n0}", totalCount - rejected) + " records inserted into " + tableName + " so far..."));
                        }
                        if (dt_doc_loc.Rows.Count > 0)
                        {
                            PerformBulkCopy(ref dt_doc_loc, database, schema, "F020L_DOC_LOCATIONS");
                            RefreshAdded(string.Format(string.Format("{0:n0}", totalCount - rejected) + " records inserted into " + tableName + " so far..."));
                        }

                        if (dt_doc_clinic_nbr3.Rows.Count > 0)
                        {
                            PerformBulkCopy(ref dt_doc_clinic_nbr3, database, schema, "F200C_OSCAR_PROVIDER_NEXT_BATCH_NBR");
                            RefreshAdded(string.Format(string.Format("{0:n0}", totalCount - rejected) + " records inserted into " + tableName + " so far..."));
                        }

                        if (dt_doc_clinic_nbr4.Rows.Count > 0)
                        {
                            PerformBulkCopy(ref dt_doc_clinic_nbr4, database, schema, "F020C_DOC_AUDIT_NEXT_BATCH_NBR");
                            RefreshAdded(string.Format(string.Format("{0:n0}", totalCount - rejected) + " records inserted into " + tableName + " so far..."));
                        }

                        if (dt_doc_loc2.Rows.Count > 0)
                        {
                            PerformBulkCopy(ref dt_doc_loc2, database, schema, "F020L_DOC_AUDIT_LOCATIONS");
                            RefreshAdded(string.Format(string.Format("{0:n0}", totalCount - rejected) + " records inserted into " + tableName + " so far..."));
                        }

                        GC.Collect();

                    }

                    if (!chkPortableSubFile.Checked)
                        startPosition = 0;

                    if (tableName.StartsWith("CONSTANTS_MSTR_REC_"))
                    {
                        if (line.Substring(1, 1) != tableName.Replace("CONSTANTS_MSTR_REC_", ""))
                        {
                            recReadCount -= 1;
                            continue;
                        }
                    }

                    while (line.StartsWith("\0"))
                    {
                        line = line.Substring(1);
                    }

                    if (line.Replace("\0", "").Trim() == "")
                    {
                        recReadCount -= 1;
                        continue;
                    }

                    try
                    {
                        switch (tableName.ToUpper())
                        {
                            case "F002_CLAIMS_MSTR_DESC":
                                {
                                    if (line.Substring(194, 1) == "B" && line.Substring(205, 4) == "ZZZZ")
                                    {
                                        //valid record, do nothing
                                    }
                                    else
                                    {
                                        recReadCount -= 1;
                                        continue;
                                    }
                                    break;
                                }

                            case "F002_CLAIMS_MSTR_DTL":
                                {
                                    if (line.Substring(194, 1) == "B" && line.Substring(205, 5) != "00000" && line.Substring(205, 4) != "ZZZZ")
                                    {
                                        //valid record, do nothing
                                    }
                                    else
                                    {
                                        recReadCount -= 1;
                                        continue;
                                    }
                                }
                                break;

                            case "F002_CLAIMS_MSTR_HDR":
                                {
                                    if (line.Substring(194, 1) == "B" && line.Substring(205, 5) == "00000")
                                    {
                                        //valid record, do nothing
                                    }
                                    else
                                    {
                                        recReadCount -= 1;
                                        continue;
                                    }
                                }
                                break;

                            case "CONSTANTS_MSTR_REC_1":
                                {
                                    if (!(line.Substring(0, 2) == "01"))
                                    {
                                        recReadCount -= 1;
                                        continue;
                                    }
                                    break;
                                }

                            case "CONSTANTS_MSTR_REC_2":
                                {
                                    if (!(line.Substring(0, 2) == "02"))
                                    {
                                        recReadCount -= 1;
                                        continue;
                                    }
                                    break;
                                }

                            case "CONSTANTS_MSTR_REC_3":
                                {
                                    if (!(line.Substring(0, 2) == "03"))
                                    {
                                        recReadCount -= 1;
                                        continue;
                                    }
                                    break;
                                }

                            case "CONSTANTS_MSTR_REC_4":
                                {
                                    if (!(line.Substring(0, 2) == "04"))
                                    {
                                        recReadCount -= 1;
                                        continue;
                                    }
                                    break;
                                }

                            case "CONSTANTS_MSTR_REC_5":
                                {
                                    if (!(line.Substring(0, 2) == "05"))
                                    {
                                        recReadCount -= 1;
                                        continue;
                                    }
                                    break;
                                }

                            case "CONSTANTS_MSTR_REC_6":
                                {
                                    if (!(line.Substring(0, 2) == "06"))
                                    {
                                        recReadCount -= 1;
                                        continue;
                                    }
                                    break;
                                }

                            case "CONSTANTS_MSTR_REC_7":
                                {
                                    if (!(line.Substring(0, 2) == "07"))
                                    {
                                        recReadCount -= 1;
                                        continue;
                                    }
                                    break;
                                }

                            case "ICONST_MSTR_REC":
                                {
                                    if (!(Convert.ToInt32(line.Substring(0, 2)) >= 22 && Convert.ToInt32(line.Substring(0, 2)) <= 99))
                                    {
                                        recReadCount -= 1;
                                        continue;
                                    }
                                    break;
                                }
                        }
                    }

                    catch (Exception ex)
                    {
                        LogErrorLine(ex.Message, tableName, columnName, size, startPosition, line, value);
                        break;
                    }

                    dt.Rows.Add(CreateNewRowObject(ref dt));

                    if (chkIsDelimited.Checked)
                        recordArray = SplitLineBasedOnDelimiter(table, line, ar);

                    if (recReadCount % 1000 == 0)
                        RefreshRead(string.Format("{0:n0}", recReadCount) + " records read from " + tableName);

                    try
                    {

                        // Loop through the columns.
                        for (int i = 0; i <= ar.Length - 1; i++)
                        {
                            columnName = ar[i];
                            column = columns[columnName].ToString().Split('~');
                            columnName = columnName.Replace("-", "_");
                            parent = column[(int)items.ParentFlag].Trim();
                            redefineElement = column[(int)items.RedefinedElement].Trim();
                            signed = column[(int)items.Signed].Trim();
                            occurs = 0;

                            //If loading the MP database and the table is F119_DOCTOR_YTD, the column is COMP_CODE,
                            //insert a blank space in the DOC_OHIP_NBR before inserting the COMP_CODE value.
                            //This table in 101C has the DOC_OHIP_NBR column and is part of the primary key.
                            if (cmboLegacyDB.SelectedItem.ToString() == "MP" && tableName.ToUpper() == "F119_DOCTOR_YTD" && columnName.ToUpper() == "DOC_OHIP_NBR")
                            {
                                value = "0";
                                size = 6;

                                int tmpStartPosition = startPosition;

                                AddColumn(ref startPosition, ref size, ref column, ref value, ref numberValue, ref signed, ref dateValue, ref dt, ref columnName, ref factor, ref recAddedCount, buf);

                                startPosition = tmpStartPosition;
                            }
                            else
                            {

                                // Exceptions (ie. structures, redefines)
                                if (redefineElement.Length == 0 && parent.Length == 0)
                                {
                                    size = Convert.ToInt32(column[(int)items.Size]);

                                    if (parentsize > 0)
                                    {
                                        parentChildren.Add(columnName + "~" + signed + "~" + size);
                                        parentsize = parentsize - size;

                                        if (parentsize == 0)
                                        {
                                            for (int q = 1; q <= parentoccurs; q++)
                                            {
                                                foreach (string c in parentChildren)
                                                {
                                                    columnName = c.Split('~')[0];
                                                    column = columns[columnName].ToString().Split('~');
                                                    columnName = columnName + q.ToString();
                                                    signed = c.Split('~')[1];
                                                    size = Convert.ToInt32(c.Split('~')[2]);

                                                    //Check if the first character is null.
                                                    if (chkIsDelimited.Checked)
                                                        if (recordArray[i].StartsWith("\0"))
                                                        {
                                                            value = "\0";
                                                        }
                                                        else
                                                        {
                                                            value = recordArray[i];
                                                        }
                                                    else
                                                        if (line.Substring(startPosition, size).StartsWith("\0"))
                                                    {
                                                        value = "\0";
                                                    }
                                                    else
                                                    {
                                                        value = line.Substring(startPosition, size);
                                                    }

                                                    value = value.TrimEnd();

                                                    AddColumn(ref startPosition, ref size, ref column, ref value, ref numberValue, ref signed, ref dateValue, ref dt, ref columnName, ref factor, ref recAddedCount, buf);
                                                }
                                            }

                                            parentChildren = new ArrayList();
                                        }
                                    }
                                    else
                                    {
                                        ptable = tableName;
                                        pcolumn = columnName;

                                        if (!string.IsNullOrEmpty(column[(int)items.Occurs].Trim()))
                                        {
                                            occurs = Convert.ToInt32(column[(int)items.Occurs].Trim());

                                            if (occurs > 0)
                                                occurs = occurs * 1;
                                        }

                                        if (occurs == 0)
                                        {
                                            if (startPosition < recordLength - 1)
                                            {
                                                if (chkPortableSubFile.Checked && (column[(int)items.DataType] == "Zoned" ||
                                                    column[(int)items.DataType] == "Integer"))
                                                {

                                                    if (column[(int)items.DataType] == "Zoned")
                                                    {
                                                        size += 1;
                                                    }

                                                    if (column[(int)items.DataType] == "Integer")
                                                    {
                                                        size += 1;
                                                    }


                                                    if (chkIsDelimited.Checked)
                                                        if (recordArray[i].StartsWith("\0"))
                                                        {
                                                            value = "\0";
                                                        }
                                                        else
                                                        {
                                                            value = recordArray[i];
                                                        }
                                                    else
                                                        if (line.Substring(startPosition, size).StartsWith("\0"))
                                                    {
                                                        value = "\0";
                                                    }
                                                    else
                                                    {
                                                        value = line.Substring(startPosition, size);
                                                    }
                                                }
                                                else
                                                {
                                                    if (chkIsDelimited.Checked)
                                                        if (recordArray[i].StartsWith("\0"))
                                                        {
                                                            value = "\0";
                                                        }
                                                        else
                                                        {
                                                            value = recordArray[i];
                                                        }
                                                    else
                                                    {
                                                        value = line.Substring(startPosition, size);
                                                    }
                                                }

                                                if (tableName == "F020_DOCTOR_MSTR" && columnName.StartsWith("DOC_CLINIC_NBR"))
                                                {
                                                    if (value.Trim() == "")
                                                    {
                                                        startPosition = startPosition + size;
                                                    }
                                                    else
                                                    {
                                                        check_doc_clinic_nbr.Add(doc_nbr + value);

                                                        cm = new SqlCommand("SELECT * FROM [" + txtDatabase.Text.ToString() + "].[" + schema + "].[F020C_DOC_CLINIC_NEXT_BATCH_NBR] WHERE 0 = 1", cn);
                                                        da = new SqlDataAdapter(cm);
                                                        da.Fill(dt_doc_clinic_nbr);

                                                        dt_doc_clinic_nbr.Rows.Add(CreateNewRowObject(ref dt_doc_clinic_nbr));
                                                        count_doc_clinic_nbr = dt_doc_clinic_nbr.Rows.Count - 1;

                                                        var s = 0;
                                                        var si = 3;
                                                        var cna = "DOC_NBR";
                                                        var col = columns[cna].ToString().Split('~');
                                                        var f = 0;
                                                        var sig = "";
                                                        AddColumn(ref s, ref si, ref col, ref doc_nbr, ref numberValue, ref sig, ref dateValue, ref dt_doc_clinic_nbr, ref cna, ref f, ref count_doc_clinic_nbr, buf);
                                                        cName = "DOC_CLINIC_NBR";
                                                        AddColumn(ref startPosition, ref size, ref column, ref value, ref numberValue, ref signed, ref dateValue, ref dt_doc_clinic_nbr, ref cName, ref factor, ref count_doc_clinic_nbr, buf);
                                                        doc_clinic_nbr = numberValue;

                                                        switch (columnName)
                                                        {
                                                            case "DOC_CLINIC_NBR":
                                                                doc_clinic_nbr1 = numberValue;
                                                                doc_clinic_seq_no = 1;
                                                                break;
                                                            case "DOC_CLINIC_NBR_2":
                                                                doc_clinic_nbr2 = numberValue;
                                                                doc_clinic_seq_no = 2;
                                                                break;
                                                            case "DOC_CLINIC_NBR_3":
                                                                doc_clinic_nbr3 = numberValue;
                                                                doc_clinic_seq_no = 3;
                                                                break;
                                                            case "DOC_CLINIC_NBR_4":
                                                                doc_clinic_nbr4 = numberValue;
                                                                doc_clinic_seq_no = 4;
                                                                break;
                                                            case "DOC_CLINIC_NBR_5":
                                                                doc_clinic_nbr5 = numberValue;
                                                                doc_clinic_seq_no = 5;
                                                                break;
                                                            case "DOC_CLINIC_NBR_6":
                                                                doc_clinic_nbr6 = numberValue;
                                                                doc_clinic_seq_no = 6;
                                                                break;
                                                        }

                                                        columnName2 = "SEQ_NO";
                                                        AddSeqNo(doc_clinic_seq_no, ref dt_doc_clinic_nbr, columnName2, count_doc_clinic_nbr);
                                                    }
                                                }
                                                else if (tableName == "F020_DOCTOR_MSTR" && columnName.StartsWith("DOC_NX_AVAIL_BATCH"))
                                                {
                                                    if (value == "000" || value.Trim() == "" || check_doc_clinic_nbr.Contains(doc_nbr + value))
                                                    {
                                                        startPosition = startPosition + size;
                                                    }
                                                    else
                                                    {
                                                        switch (columnName)
                                                        {
                                                            case "DOC_NX_AVAIL_BATCH":
                                                                doc_clinic_nbr = doc_clinic_nbr1;
                                                                doc_clinic_seq_no = 1;
                                                                break;
                                                            case "DOC_NX_AVAIL_BATCH_2":
                                                                doc_clinic_nbr = doc_clinic_nbr2;
                                                                doc_clinic_seq_no = 2;
                                                                break;
                                                            case "DOC_NX_AVAIL_BATCH_3":
                                                                doc_clinic_nbr = doc_clinic_nbr3;
                                                                doc_clinic_seq_no = 3;
                                                                break;
                                                            case "DOC_NX_AVAIL_BATCH_4":
                                                                doc_clinic_nbr = doc_clinic_nbr4;
                                                                doc_clinic_seq_no = 4;
                                                                break;
                                                            case "DOC_NX_AVAIL_BATCH_5":
                                                                doc_clinic_nbr = doc_clinic_nbr5;
                                                                doc_clinic_seq_no = 5;
                                                                break;
                                                            case "DOC_NX_AVAIL_BATCH_6":
                                                                doc_clinic_nbr = doc_clinic_nbr6;
                                                                doc_clinic_seq_no = 6;
                                                                break;
                                                        }

                                                        columnName2 = "DOC_NX_AVAIL_BATCH";

                                                        //if (doc_clinic_nbr == null)
                                                        //{
                                                        //    whereClause = "DOC_NBR = '" + doc_nbr + "' AND DOC_CLINIC_NBR IS NULL";
                                                        //}
                                                        //else
                                                        //{
                                                        //    whereClause = "DOC_NBR = '" + doc_nbr + "' AND DOC_CLINIC_NBR = " + doc_clinic_nbr;
                                                        //}
                                                        whereClause = "DOC_NBR = '" + doc_nbr + "' AND SEQ_NO = " + doc_clinic_seq_no;
                                                        UpdateColumn(ref startPosition, ref size, ref column, ref value, ref numberValue, ref signed, ref dateValue, ref dt_doc_clinic_nbr, ref columnName2, ref factor, ref whereClause);
                                                    }
                                                }
                                                else if (tableName == "F020_DOCTOR_MSTR" && columnName.StartsWith("DOC_LOC"))
                                                {
                                                    if (value.Trim() == "" || check_doc_loc.Contains(doc_nbr + value))
                                                    {
                                                        startPosition = startPosition + size;
                                                    }
                                                    else
                                                    {
                                                        check_doc_loc.Add(doc_nbr + value);

                                                        if (!columnName.Contains("_S"))
                                                        {
                                                            cm = new SqlCommand("SELECT * FROM [" + txtDatabase.Text.ToString() + "].[" + schema + "].[F020L_DOC_LOCATIONS] WHERE 0 = 1", cn);
                                                            da = new SqlDataAdapter(cm);
                                                            da.Fill(dt_doc_loc);

                                                            dt_doc_loc.Rows.Add(CreateNewRowObject(ref dt_doc_loc));
                                                            count_doc_loc = dt_doc_loc.Rows.Count - 1;

                                                            var s = 0;
                                                            var si = 3;
                                                            var cna = "DOC_NBR";
                                                            var col = columns[cna].ToString().Split('~');
                                                            var f = 0;
                                                            var sig = "";
                                                            AddColumn(ref s, ref si, ref col, ref doc_nbr, ref numberValue, ref sig, ref dateValue, ref dt_doc_loc, ref cna, ref f, ref count_doc_loc, buf);
                                                            columnName2 = "DOC_LOC";
                                                            AddColumn(ref startPosition, ref size, ref column, ref value, ref numberValue, ref signed, ref dateValue, ref dt_doc_loc, ref columnName2, ref factor, ref count_doc_loc, buf);

                                                            switch (columnName)
                                                            {
                                                                case "DOC_LOC_1":
                                                                    doc_loc_seq_no = 1;
                                                                    break;
                                                                case "DOC_LOC_2":
                                                                    doc_loc_seq_no = 2;
                                                                    break;
                                                                case "DOC_LOC_3":
                                                                    doc_loc_seq_no = 3;
                                                                    break;
                                                                case "DOC_LOC_4":
                                                                    doc_loc_seq_no = 4;
                                                                    break;
                                                                case "DOC_LOC_5":
                                                                    doc_loc_seq_no = 5;
                                                                    break;
                                                                case "DOC_LOC_6":
                                                                    doc_loc_seq_no = 6;
                                                                    break;
                                                                case "DOC_LOC_7":
                                                                    doc_loc_seq_no = 7;
                                                                    break;
                                                                case "DOC_LOC_8":
                                                                    doc_loc_seq_no = 8;
                                                                    break;
                                                                case "DOC_LOC_9":
                                                                    doc_loc_seq_no = 9;
                                                                    break;
                                                                case "DOC_LOC_10":
                                                                    doc_loc_seq_no = 10;
                                                                    break;
                                                                case "DOC_LOC_11":
                                                                    doc_loc_seq_no = 11;
                                                                    break;
                                                                case "DOC_LOC_12":
                                                                    doc_loc_seq_no = 12;
                                                                    break;
                                                                case "DOC_LOC_13":
                                                                    doc_loc_seq_no = 13;
                                                                    break;
                                                                case "DOC_LOC_14":
                                                                    doc_loc_seq_no = 14;
                                                                    break;
                                                                case "DOC_LOC_15":
                                                                    doc_loc_seq_no = 15;
                                                                    break;
                                                                case "DOC_LOC_16":
                                                                    doc_loc_seq_no = 16;
                                                                    break;
                                                                case "DOC_LOC_17":
                                                                    doc_loc_seq_no = 17;
                                                                    break;
                                                                case "DOC_LOC_18":
                                                                    doc_loc_seq_no = 18;
                                                                    break;
                                                                case "DOC_LOC_19":
                                                                    doc_loc_seq_no = 19;
                                                                    break;
                                                                case "DOC_LOC_20":
                                                                    doc_loc_seq_no = 20;
                                                                    break;
                                                                case "DOC_LOC_21":
                                                                    doc_loc_seq_no = 21;
                                                                    break;
                                                                case "DOC_LOC_22":
                                                                    doc_loc_seq_no = 22;
                                                                    break;
                                                                case "DOC_LOC_23":
                                                                    doc_loc_seq_no = 23;
                                                                    break;
                                                                case "DOC_LOC_24":
                                                                    doc_loc_seq_no = 24;
                                                                    break;
                                                                case "DOC_LOC_25":
                                                                    doc_loc_seq_no = 25;
                                                                    break;
                                                                case "DOC_LOC_26":
                                                                    doc_loc_seq_no = 26;
                                                                    break;
                                                                case "DOC_LOC_27":
                                                                    doc_loc_seq_no = 27;
                                                                    break;
                                                                case "DOC_LOC_28":
                                                                    doc_loc_seq_no = 28;
                                                                    break;
                                                                case "DOC_LOC_29":
                                                                    doc_loc_seq_no = 29;
                                                                    break;
                                                                case "DOC_LOC_30":
                                                                    doc_loc_seq_no = 30;
                                                                    break;
                                                            }

                                                            columnName2 = "SEQ_NO";
                                                            whereClause = "DOC_NBR = '" + doc_nbr + "' AND DOC_LOC = '" + value + "'";
                                                            UpdateSeqNo(doc_loc_seq_no, ref dt_doc_loc, columnName2, whereClause);
                                                        }
                                                        else
                                                        {
                                                            switch (columnName)
                                                            {
                                                                case "DOC_LOC_1_S1":
                                                                case "DOC_LOC_1_S2":
                                                                case "DOC_LOC_1_S3":
                                                                    doc_loc_seq_no = 1;
                                                                    break;
                                                                case "DOC_LOC_2_S1":
                                                                case "DOC_LOC_2_S2":
                                                                case "DOC_LOC_2_S3":
                                                                    doc_loc_seq_no = 2;
                                                                    break;
                                                                case "DOC_LOC_3_S1":
                                                                case "DOC_LOC_3_S2":
                                                                case "DOC_LOC_3_S3":
                                                                    doc_loc_seq_no = 3;
                                                                    break;
                                                                case "DOC_LOC_4_S1":
                                                                case "DOC_LOC_4_S2":
                                                                case "DOC_LOC_4_S3":
                                                                    doc_loc_seq_no = 4;
                                                                    break;
                                                                case "DOC_LOC_5_S1":
                                                                case "DOC_LOC_5_S2":
                                                                case "DOC_LOC_5_S3":
                                                                    doc_loc_seq_no = 5;
                                                                    break;
                                                                case "DOC_LOC_6_S1":
                                                                case "DOC_LOC_6_S2":
                                                                case "DOC_LOC_6_S3":
                                                                    doc_loc_seq_no = 6;
                                                                    break;
                                                                case "DOC_LOC_7_S1":
                                                                case "DOC_LOC_7_S2":
                                                                case "DOC_LOC_7_S3":
                                                                    doc_loc_seq_no = 7;
                                                                    break;
                                                                case "DOC_LOC_8_S1":
                                                                case "DOC_LOC_8_S2":
                                                                case "DOC_LOC_8_S3":
                                                                    doc_loc_seq_no = 8;
                                                                    break;
                                                                case "DOC_LOC_9_S1":
                                                                case "DOC_LOC_9_S2":
                                                                case "DOC_LOC_9_S3":
                                                                    doc_loc_seq_no = 9;
                                                                    break;
                                                                case "DOC_LOC_10_S1":
                                                                case "DOC_LOC_10_S2":
                                                                case "DOC_LOC_10_S3":
                                                                    doc_loc_seq_no = 10;
                                                                    break;
                                                                case "DOC_LOC_11_S1":
                                                                case "DOC_LOC_11_S2":
                                                                case "DOC_LOC_11_S3":
                                                                    doc_loc_seq_no = 11;
                                                                    break;
                                                                case "DOC_LOC_12_S1":
                                                                case "DOC_LOC_12_S2":
                                                                case "DOC_LOC_12_S3":
                                                                    doc_loc_seq_no = 12;
                                                                    break;
                                                                case "DOC_LOC_13_S1":
                                                                case "DOC_LOC_13_S2":
                                                                case "DOC_LOC_13_S3":
                                                                    doc_loc_seq_no = 13;
                                                                    break;
                                                                case "DOC_LOC_14_S1":
                                                                case "DOC_LOC_14_S2":
                                                                case "DOC_LOC_14_S3":
                                                                    doc_loc_seq_no = 14;
                                                                    break;
                                                                case "DOC_LOC_15_S1":
                                                                case "DOC_LOC_15_S2":
                                                                case "DOC_LOC_15_S3":
                                                                    doc_loc_seq_no = 15;
                                                                    break;
                                                                case "DOC_LOC_16_S1":
                                                                case "DOC_LOC_16_S2":
                                                                case "DOC_LOC_16_S3":
                                                                    doc_loc_seq_no = 16;
                                                                    break;
                                                                case "DOC_LOC_17_S1":
                                                                case "DOC_LOC_17_S2":
                                                                case "DOC_LOC_17_S3":
                                                                    doc_loc_seq_no = 17;
                                                                    break;
                                                                case "DOC_LOC_18_S1":
                                                                case "DOC_LOC_18_S2":
                                                                case "DOC_LOC_18_S3":
                                                                    doc_loc_seq_no = 18;
                                                                    break;
                                                                case "DOC_LOC_19_S1":
                                                                case "DOC_LOC_19_S2":
                                                                case "DOC_LOC_19_S3":
                                                                    doc_loc_seq_no = 19;
                                                                    break;
                                                                case "DOC_LOC_20_S1":
                                                                case "DOC_LOC_20_S2":
                                                                case "DOC_LOC_20_S3":
                                                                    doc_loc_seq_no = 20;
                                                                    break;
                                                                case "DOC_LOC_21_S1":
                                                                case "DOC_LOC_21_S2":
                                                                case "DOC_LOC_21_S3":
                                                                    doc_loc_seq_no = 21;
                                                                    break;
                                                                case "DOC_LOC_22_S1":
                                                                case "DOC_LOC_22_S2":
                                                                case "DOC_LOC_22_S3":
                                                                    doc_loc_seq_no = 22;
                                                                    break;
                                                                case "DOC_LOC_23_S1":
                                                                case "DOC_LOC_23_S2":
                                                                case "DOC_LOC_23_S3":
                                                                    doc_loc_seq_no = 23;
                                                                    break;
                                                                case "DOC_LOC_24_S1":
                                                                case "DOC_LOC_24_S2":
                                                                case "DOC_LOC_24_S3":
                                                                    doc_loc_seq_no = 24;
                                                                    break;
                                                                case "DOC_LOC_25_S1":
                                                                case "DOC_LOC_25_S2":
                                                                case "DOC_LOC_25_S3":
                                                                    doc_loc_seq_no = 25;
                                                                    break;
                                                                case "DOC_LOC_26_S1":
                                                                case "DOC_LOC_26_S2":
                                                                case "DOC_LOC_26_S3":
                                                                    doc_loc_seq_no = 26;
                                                                    break;
                                                                case "DOC_LOC_27_S1":
                                                                case "DOC_LOC_27_S2":
                                                                case "DOC_LOC_27_S3":
                                                                    doc_loc_seq_no = 27;
                                                                    break;
                                                                case "DOC_LOC_28_S1":
                                                                case "DOC_LOC_28_S2":
                                                                case "DOC_LOC_28_S3":
                                                                    doc_loc_seq_no = 28;
                                                                    break;
                                                                case "DOC_LOC_29_S1":
                                                                case "DOC_LOC_29_S2":
                                                                case "DOC_LOC_29_S3":
                                                                    doc_loc_seq_no = 29;
                                                                    break;
                                                                case "DOC_LOC_30_S1":
                                                                case "DOC_LOC_30_S2":
                                                                case "DOC_LOC_30_S3":
                                                                    doc_loc_seq_no = 30;
                                                                    break;
                                                            }

                                                            whereClause = "DOC_NBR = '" + doc_nbr + "' AND SEQ_NO = " + doc_loc_seq_no;
                                                            if (RecordExists(dt_doc_loc, whereClause) == true)
                                                            {
                                                                if (columnName.EndsWith("S1"))
                                                                {
                                                                    columnName2 = "DOC_LOC_S1";
                                                                }
                                                                else if (columnName.EndsWith("S2"))
                                                                {
                                                                    columnName2 = "DOC_LOC_S2";
                                                                }
                                                                else
                                                                {
                                                                    columnName2 = "DOC_LOC_S3";
                                                                }

                                                                whereClause = "DOC_NBR = '" + doc_nbr + "' AND SEQ_NO = " + doc_loc_seq_no;
                                                                UpdateDocLocS(value, ref dt_doc_loc, columnName2, whereClause);
                                                            }
                                                            else
                                                            {
                                                                cm = new SqlCommand("SELECT * FROM [" + txtDatabase.Text.ToString() + "].[" + schema + "].[F020L_DOC_LOCATIONS] WHERE 0 = 1", cn);
                                                                da = new SqlDataAdapter(cm);
                                                                da.Fill(dt_doc_loc);

                                                                dt_doc_loc.Rows.Add(CreateNewRowObject(ref dt_doc_loc));
                                                                count_doc_loc = dt_doc_loc.Rows.Count - 1;

                                                                var s = 0;
                                                                var si = 3;
                                                                var cna = "DOC_NBR";
                                                                var col = columns[cna].ToString().Split('~');
                                                                var f = 0;
                                                                var sig = "";
                                                                AddColumn(ref s, ref si, ref col, ref doc_nbr, ref numberValue, ref sig, ref dateValue, ref dt_doc_loc, ref cna, ref f, ref count_doc_loc, buf);
                                                                columnName2 = "DOC_LOC";
                                                                AddColumn(ref startPosition, ref size, ref column, ref value, ref numberValue, ref signed, ref dateValue, ref dt_doc_loc, ref columnName2, ref factor, ref count_doc_loc, buf);

                                                                columnName2 = "SEQ_NO";
                                                                whereClause = "DOC_NBR = '" + doc_nbr + "' AND DOC_LOC = '" + value + "'";
                                                                UpdateSeqNo(doc_loc_seq_no, ref dt_doc_loc, columnName2, whereClause);

                                                                if (columnName.EndsWith("S1"))
                                                                {
                                                                    columnName2 = "DOC_LOC_S1";
                                                                }
                                                                else if (columnName.EndsWith("S2"))
                                                                {
                                                                    columnName2 = "DOC_LOC_S2";
                                                                }
                                                                else
                                                                {
                                                                    columnName2 = "DOC_LOC_S3";
                                                                }

                                                                whereClause = "DOC_NBR = '" + doc_nbr + "' AND SEQ_NO = " + doc_loc_seq_no;
                                                                UpdateDocLocS(value, ref dt_doc_loc, columnName2, whereClause);
                                                            }
                                                        }
                                                    }
                                                }
                                                else if (tableName == "F020_DOCTOR_EXTRA" && columnName.StartsWith("DOC_CLINIC_NBR") && columnName.EndsWith("STATUS"))
                                                {
                                                    if (value == "00" || value.Trim() == "")
                                                    {
                                                        startPosition = startPosition + size;
                                                    }
                                                    else
                                                    {
                                                        check_doc_clinic_nbr2.Add(doc_nbr + value);

                                                        //Check if doc_nbr already exists in the table. If not write to error log.
                                                        dt_doc_clinic_nbr2.Clear();
                                                        cm = new SqlCommand("SELECT * FROM [" + txtDatabase.Text.ToString() + "].[" + schema + "].[F020C_DOC_CLINIC_NEXT_BATCH_NBR] WHERE DOC_NBR = '" + doc_nbr + "'", cn);
                                                        da = new SqlDataAdapter(cm);
                                                        da.Fill(dt_doc_clinic_nbr2);

                                                        if (dt_doc_clinic_nbr2.Rows.Count == 0)
                                                        {
                                                            LogErrorLine("Record in F020_DOCTOR_EXTRA is not linked to a record in F020_DOCTOR_MSTR", tableName, columnName, size, 0, line, value);
                                                            startPosition = startPosition + size;
                                                        }
                                                        else
                                                        {
                                                            switch (columnName)
                                                            {
                                                                case "DOC_CLINIC_NBR_STATUS":
                                                                    doc_clinic_nbr = 1;
                                                                    break;
                                                                case "DOC_CLINIC_NBR_2_STATUS":
                                                                    doc_clinic_nbr = 2;
                                                                    break;
                                                                case "DOC_CLINIC_NBR_3_STATUS":
                                                                    doc_clinic_nbr = 3;
                                                                    break;
                                                                case "DOC_CLINIC_NBR_4_STATUS":
                                                                    doc_clinic_nbr = 4;
                                                                    break;
                                                                case "DOC_CLINIC_NBR_5_STATUS":
                                                                    doc_clinic_nbr = 5;
                                                                    break;
                                                                case "DOC_CLINIC_NBR_6_STATUS":
                                                                    doc_clinic_nbr = 6;
                                                                    break;
                                                            }

                                                            if (doc_clinic_nbr == null)
                                                            {
                                                                LogErrorLine("There are no records in F020_DOCTOR_MSTR with a doctor clinic number that matches the records in F020_DOCTOR_EXTRA for the for doc_nbr " + doc_nbr.ToString() + ".", tableName, columnName, size, startPosition, line, value);
                                                                startPosition = startPosition + size;
                                                            }
                                                            else
                                                            {
                                                                //Find the record in the table.
                                                                dt_doc_clinic_nbr2.Clear();
                                                                cm = new SqlCommand("SELECT * FROM [" + txtDatabase.Text.ToString() + "].[" + schema + "].[F020C_DOC_CLINIC_NEXT_BATCH_NBR] WHERE DOC_NBR = '" + doc_nbr + "' AND SEQ_NO = " + doc_clinic_nbr, cn);
                                                                //cm = new SqlCommand("SELECT x.* FROM (SELECT ROW_NUMBER() OVER (ORDER BY DOC_NBR ASC) AS ROWNUM, * FROM [" + txtDatabase.Text.ToString() + "].[" + schema + "].[F020C_DOC_CLINIC_NEXT_BATCH_NBR] WHERE DOC_NBR = '" + doc_nbr + "') AS x WHERE x.ROWNUM = " + doc_clinic_nbr, cn);
                                                                //cm = new SqlCommand("SELECT * FROM [" + txtDatabase.Text.ToString() + "].[" + schema + "].[F020C_DOC_CLINIC_NEXT_BATCH_NBR] WHERE DOC_NBR = '" + doc_nbr + "' AND DOC_CLINIC_NBR = " + doc_clinic_nbr, cn);
                                                                da = new SqlDataAdapter(cm);
                                                                da.Fill(dt_doc_clinic_nbr2);

                                                                if (dt_doc_clinic_nbr2.Rows.Count == 0)
                                                                {
                                                                    LogErrorLine("Record in F020_DOCTOR_EXTRA is not linked to a record in F020_DOCTOR_MSTR", tableName, columnName, size, startPosition, line, value);
                                                                    startPosition = startPosition + size;
                                                                }
                                                                else
                                                                {
                                                                    columnName2 = "DOC_CLINIC_NBR_STATUS";
                                                                    tName = "F020C_DOC_CLINIC_NEXT_BATCH_NBR";
                                                                    UpdateTable(ref schema, ref tName, ref startPosition, ref size, ref column, ref value, ref numberValue, ref signed, ref dateValue, ref dt_doc_clinic_nbr2, ref columnName2, ref factor);
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                                //else if (tableName == "F200_OSCAR_PROVIDER" && columnName.StartsWith("DOC_NBR"))
                                                //{
                                                //    if (value == "00" || value.Trim() == "" || check_doc_clinic_nbr3.Contains(oscar_provider_no + value))
                                                //    {
                                                //        startPosition = startPosition + size;
                                                //    }
                                                //    else
                                                //    {
                                                //        check_doc_clinic_nbr3.Add(oscar_provider_no + value);

                                                //        cm = new SqlCommand("SELECT * FROM [" + txtDatabase.Text.ToString() + "].[" + schema + "].[F200C_OSCAR_PROVIDER_NEXT_BATCH_NBR] WHERE 0 = 1", cn);
                                                //        da = new SqlDataAdapter(cm);
                                                //        da.Fill(dt_doc_clinic_nbr3);

                                                //        dt_doc_clinic_nbr3.Rows.Add(CreateNewRowObject(ref dt_doc_clinic_nbr3));
                                                //        count_doc_clinic_nbr3 = dt_doc_clinic_nbr3.Rows.Count - 1;

                                                //        var s = 0;
                                                //        var si = 10;
                                                //        var cna = "OSCAR_PROVIDER_NO";
                                                //        var col = columns[cna].ToString().Split('~');
                                                //        var f = 0;
                                                //        var sig = "";
                                                //        AddColumn(ref s, ref si, ref col, ref doc_nbr, ref numberValue, ref sig, ref dateValue, ref dt_doc_clinic_nbr3, ref cna, ref f, ref count_doc_loc, buf);
                                                //        columnName2 = "DOC_NBR";
                                                //        AddColumn(ref startPosition, ref size, ref column, ref value, ref numberValue, ref signed, ref dateValue, ref dt_doc_clinic_nbr3, ref columnName2, ref factor, ref count_doc_loc, buf);
                                                //    }
                                                //}
                                                else if (tableName == "F200_OSCAR_PROVIDER" && columnName.StartsWith("DOC_CLINIC_NBR"))
                                                {
                                                    if (value == "00" || value.Trim() == "" || check_doc_clinic_nbr3.Contains(oscar_provider_no + value))
                                                    {
                                                        startPosition = startPosition + size;
                                                    }
                                                    else
                                                    {
                                                        cm = new SqlCommand("SELECT * FROM [" + txtDatabase.Text.ToString() + "].[" + schema + "].[F200C_OSCAR_PROVIDER_NEXT_BATCH_NBR] WHERE 0 = 1", cn);
                                                        da = new SqlDataAdapter(cm);
                                                        da.Fill(dt_doc_clinic_nbr3);

                                                        dt_doc_clinic_nbr3.Rows.Add(CreateNewRowObject(ref dt_doc_clinic_nbr3));
                                                        count_doc_clinic_nbr3 = dt_doc_clinic_nbr3.Rows.Count - 1;

                                                        var s = 0;
                                                        var si = 10;
                                                        var cna = "OSCAR_PROVIDER_NO";
                                                        var col = columns[cna].ToString().Split('~');
                                                        var f = 0;
                                                        var sig = "";
                                                        AddColumn(ref s, ref si, ref col, ref oscar_provider_no, ref numberValue, ref sig, ref dateValue, ref dt_doc_clinic_nbr3, ref cna, ref f, ref count_doc_clinic_nbr3, buf);

                                                        si = 3;
                                                        cna = "DOC_NBR";
                                                        col = columns[cna].ToString().Split('~');
                                                        AddColumn(ref s, ref si, ref col, ref doc_nbr, ref numberValue, ref sig, ref dateValue, ref dt_doc_clinic_nbr3, ref cna, ref f, ref count_doc_clinic_nbr3, buf);

                                                        columnName2 = "DOC_CLINIC_NBR";
                                                        AddColumn(ref startPosition, ref size, ref column, ref value, ref numberValue, ref signed, ref dateValue, ref dt_doc_clinic_nbr3, ref columnName2, ref factor, ref count_doc_clinic_nbr3, buf);

                                                        //whereClause = "OSCAR_PROVIDER_NO = '" + oscar_provider_no + "' AND DOC_NBR = '" + doc_nbr + "'";
                                                        //UpdateColumn(ref startPosition, ref size, ref column, ref value, ref numberValue, ref signed, ref dateValue, ref dt_doc_clinic_nbr3, ref columnName2, ref factor, ref whereClause);
                                                    }
                                                }

                                                else if (tableName == "F020_DOCTOR_AUDIT" && columnName.StartsWith("DOC_CLINIC_NBR") && columnName.EndsWith("STATUS"))
                                                {
                                                    if (value == "00" || value.Trim() == "" || check_doc_clinic_nbr4.Contains(doc_nbr + value))
                                                    {
                                                        startPosition = startPosition + size;
                                                    }
                                                    else
                                                    {
                                                        check_doc_clinic_nbr4.Add(doc_nbr + value);

                                                        //Check if doc_nbr already exists in the table. If not write to error log.
                                                        whereClause = "DOC_NBR = '" + doc_nbr + "'";
                                                        DataRow[] foundRows = dt_doc_clinic_nbr4.Select(whereClause);

                                                        if (foundRows.Count() == 0)
                                                        {
                                                            LogErrorLine("The value in the column is not associated with a doctor clinic number.", tableName, columnName, size, 0, line, value);
                                                            startPosition = startPosition + size;
                                                        }
                                                        else
                                                        {
                                                            switch (columnName)
                                                            {
                                                                case "DOC_NX_AVAIL_BATCH":
                                                                    doc_clinic_nbr = doc_clinic_nbr1;
                                                                    break;
                                                                case "DOC_NX_AVAIL_BATCH_2":
                                                                    doc_clinic_nbr = doc_clinic_nbr2;
                                                                    break;
                                                                case "DOC_NX_AVAIL_BATCH_3":
                                                                    doc_clinic_nbr = doc_clinic_nbr3;
                                                                    break;
                                                                case "DOC_NX_AVAIL_BATCH_4":
                                                                    doc_clinic_nbr = doc_clinic_nbr4;
                                                                    break;
                                                                case "DOC_NX_AVAIL_BATCH_5":
                                                                    doc_clinic_nbr = doc_clinic_nbr5;
                                                                    break;
                                                                case "DOC_NX_AVAIL_BATCH_6":
                                                                    doc_clinic_nbr = doc_clinic_nbr6;
                                                                    break;
                                                            }

                                                            if (doc_clinic_nbr == null)
                                                            {
                                                                string col = string.Empty;
                                                                if (Regex.IsMatch(columnName.Substring(columnName.LastIndexOf("_") + 1), @"\d+$"))
                                                                {
                                                                    col = "DOC_CLINIC_NBR_" + columnName.Substring(columnName.LastIndexOf("_") + 1);
                                                                }
                                                                else
                                                                {
                                                                    col = "DOC_CLINIC_NBR";
                                                                }

                                                                LogErrorLine(columnName + " has a value but cannot be inserted into the table because there is no value for " + col + ".", tableName, columnName, size, startPosition, line, value);
                                                                startPosition = startPosition + size;
                                                            }
                                                            else
                                                            {
                                                                columnName2 = "DOC_CLINIC_NBR_STATUS";
                                                                tName = "F020C_DOCTOR_AUDIT_NEXT_BATCH_NBR";
                                                                UpdateTable(ref schema, ref tName, ref startPosition, ref size, ref column, ref value, ref numberValue, ref signed, ref dateValue, ref dt_doc_clinic_nbr4, ref columnName2, ref factor);
                                                            }
                                                        }
                                                    }
                                                }
                                                else if (tableName == "F020_DOCTOR_AUDIT" && columnName.StartsWith("DOC_CLINIC_NBR"))
                                                {
                                                    if (value.Trim() == "")
                                                    {
                                                        startPosition = startPosition + size;
                                                    }
                                                    else
                                                    {
                                                        check_doc_clinic_nbr4.Add(doc_nbr + value);

                                                        cm = new SqlCommand("SELECT * FROM [" + txtDatabase.Text.ToString() + "].[" + schema + "].[F020C_DOCTOR_AUDIT_NEXT_BATCH_NBR] WHERE 0 = 1", cn);
                                                        da = new SqlDataAdapter(cm);
                                                        da.Fill(dt_doc_clinic_nbr4);

                                                        dt_doc_clinic_nbr4.Rows.Add(CreateNewRowObject(ref dt_doc_clinic_nbr4));
                                                        count_doc_clinic_nbr4 = dt_doc_clinic_nbr4.Rows.Count - 1;

                                                        var s = 0;
                                                        var si = 3;
                                                        var cna = "DOC_NBR";
                                                        var col = columns[cna].ToString().Split('~');
                                                        var f = 0;
                                                        var sig = "";
                                                        AddColumn(ref s, ref si, ref col, ref doc_nbr, ref numberValue, ref sig, ref dateValue, ref dt_doc_clinic_nbr4, ref cna, ref f, ref count_doc_clinic_nbr4, buf);
                                                        columnName2 = "DOC_CLINIC_NBR";
                                                        AddColumn(ref startPosition, ref size, ref column, ref value, ref numberValue, ref signed, ref dateValue, ref dt_doc_clinic_nbr4, ref columnName2, ref factor, ref count_doc_clinic_nbr4, buf);

                                                        switch (columnName)
                                                        {
                                                            case "DOC_CLINIC_NBR":
                                                                doc_clinic_nbr1 = numberValue;
                                                                break;
                                                            case "DOC_CLINIC_NBR_2":
                                                                doc_clinic_nbr2 = numberValue;
                                                                break;
                                                            case "DOC_CLINIC_NBR_3":
                                                                doc_clinic_nbr3 = numberValue;
                                                                break;
                                                            case "DOC_CLINIC_NBR_4":
                                                                doc_clinic_nbr4 = numberValue;
                                                                break;
                                                            case "DOC_CLINIC_NBR_5":
                                                                doc_clinic_nbr5 = numberValue;
                                                                break;
                                                            case "DOC_CLINIC_NBR_6":
                                                                doc_clinic_nbr6 = numberValue;
                                                                break;
                                                        }
                                                    }
                                                }
                                                else if (tableName == "F020_DOCTOR_AUDIT" && columnName.StartsWith("DOC_NX_AVAIL_BATCH"))
                                                {
                                                    if (value.Trim() == "")
                                                    {
                                                        startPosition = startPosition + size;
                                                    }
                                                    else
                                                    {
                                                        switch (columnName)
                                                        {
                                                            case "DOC_NX_AVAIL_BATCH":
                                                                doc_clinic_nbr = doc_clinic_nbr1;
                                                                break;
                                                            case "DOC_NX_AVAIL_BATCH_2":
                                                                doc_clinic_nbr = doc_clinic_nbr2;
                                                                break;
                                                            case "DOC_NX_AVAIL_BATCH_3":
                                                                doc_clinic_nbr = doc_clinic_nbr3;
                                                                break;
                                                            case "DOC_NX_AVAIL_BATCH_4":
                                                                doc_clinic_nbr = doc_clinic_nbr4;
                                                                break;
                                                            case "DOC_NX_AVAIL_BATCH_5":
                                                                doc_clinic_nbr = doc_clinic_nbr5;
                                                                break;
                                                            case "DOC_NX_AVAIL_BATCH_6":
                                                                doc_clinic_nbr = doc_clinic_nbr6;
                                                                break;
                                                        }

                                                        columnName2 = "DOC_NX_AVAIL_BATCH";

                                                        if (doc_clinic_nbr == null)
                                                        {
                                                            whereClause = "DOC_NBR = '" + doc_nbr + "' AND DOC_CLINIC_NBR IS NULL";
                                                        }
                                                        else
                                                        {
                                                            whereClause = "DOC_NBR = '" + doc_nbr + "' AND DOC_CLINIC_NBR = " + doc_clinic_nbr;
                                                        }

                                                        UpdateColumn(ref startPosition, ref size, ref column, ref value, ref numberValue, ref signed, ref dateValue, ref dt_doc_clinic_nbr4, ref columnName2, ref factor, ref whereClause);
                                                    }
                                                }
                                                else if (tableName == "F020_DOCTOR_AUDIT" && columnName.StartsWith("DOC_LOCATIONS"))
                                                {
                                                    if (value.Trim() == "" || check_doc_loc2.Contains(doc_nbr + value))
                                                    {
                                                        startPosition = startPosition + size;
                                                    }
                                                    else
                                                    {
                                                        check_doc_loc2.Add(doc_nbr + value);

                                                        cm = new SqlCommand("SELECT * FROM [" + txtDatabase.Text.ToString() + "].[" + schema + "].[F020L_DOCTOR_AUDIT_LOCATIONS] WHERE 0 = 1", cn);
                                                        da = new SqlDataAdapter(cm);
                                                        da.Fill(dt_doc_loc2);

                                                        dt_doc_loc2.Rows.Add(CreateNewRowObject(ref dt_doc_loc2));
                                                        count_doc_loc2 = dt_doc_loc2.Rows.Count - 1;

                                                        var s = 0;
                                                        var si = 3;
                                                        var cna = "DOC_NBR";
                                                        var col = columns[cna].ToString().Split('~');
                                                        var f = 0;
                                                        var sig = "";
                                                        AddColumn(ref s, ref si, ref col, ref doc_nbr, ref numberValue, ref sig, ref dateValue, ref dt_doc_loc2, ref cna, ref f, ref count_doc_loc2, buf);

                                                        int startpos = 0;
                                                        for (int j = 0; j < value.Length / 4; j++)
                                                        {
                                                            docloc = value.Substring(startpos, 4);
                                                            columnName2 = "DOC_LOC";
                                                            si = 4;

                                                            //Check if the location was already added to the datatable
                                                            if (docloc.Trim().Length == 4 && docloc.Trim('\0').Length != 0)
                                                            {
                                                                whereClause = "DOC_NBR = '" + doc_nbr + "' AND DOC_LOC = '" + docloc + "'";
                                                                DataRow[] foundRow = dt_doc_loc2.Select(whereClause);

                                                                if (foundRow.Count() == 0)
                                                                {
                                                                    AddColumn(ref startPosition, ref si, ref column, ref docloc, ref numberValue, ref signed, ref dateValue, ref dt_doc_loc2, ref columnName2, ref factor, ref count_doc_loc2, buf);
                                                                }
                                                                else
                                                                {
                                                                    startPosition += si;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                startPosition += si;
                                                            }
                                                            startpos += si;
                                                        }

                                                        //If the length of the value is smaller than the size, because there are spaces at the end, add the difference to the startPosition
                                                        if (value.Length < size)
                                                        {
                                                            startPosition += size - value.Length;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    AddColumn(ref startPosition, ref size, ref column, ref value, ref numberValue, ref signed, ref dateValue, ref dt, ref columnName, ref factor, ref recAddedCount, buf);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            for (int q = 1; q <= occurs; q++)
                                            {
                                                if (chkPortableSubFile.Checked && column[(int)items.DataType] == "Zoned")
                                                {
                                                    size += 1;
                                                    if (chkIsDelimited.Checked)
                                                        value = recordArray[i];
                                                    else
                                                        value = line.Substring(startPosition, size);
                                                }
                                                else
                                                {
                                                    if (chkIsDelimited.Checked)
                                                        value = recordArray[i];
                                                    else
                                                        value = line.Substring(startPosition, size);
                                                }

                                                value = value.TrimEnd();
                                                columnName2 = ar[i] + q.ToString();

                                                AddColumn(ref startPosition, ref size, ref column, ref value, ref numberValue, ref signed, ref dateValue, ref dt, ref columnName2, ref factor, ref recAddedCount, buf);
                                            }
                                        }
                                    }
                                }
                                else if (parent.Length > 0)
                                {

                                    if (!string.IsNullOrEmpty(column[(int)items.Occurs].Trim()))
                                    {
                                        occurs = Convert.ToInt32(column[(int)items.Occurs].Trim());
                                        if (occurs > 0)
                                        {
                                            occurs = occurs * 1;
                                            parentsize = Convert.ToInt32(column[(int)items.Size]);
                                            parentoccurs = occurs;
                                            parentChildren = new ArrayList();
                                        }
                                    }
                                }

                                if ((tableName == "F020_DOCTOR_MSTR" && columnName == "DOC_NBR") || (tableName == "F020_DOCTOR_EXTRA" && columnName == "DOC_NBR") || (tableName == "F020_DOCTOR_AUDIT" && columnName == "DOC_NBR") || (tableName == "F200_OSCAR_PROVIDER" && columnName == "DOC_NBR"))
                                {
                                    doc_nbr = value;
                                }

                                if ((tableName == "F200_OSCAR_PROVIDER" && columnName == "OSCAR_PROVIDER_NO"))
                                {
                                    oscar_provider_no = value;
                                }
                            }
                        }

                        recAddedCount += 1;
                        totalCount += 1;
                    }

                    catch (Exception ex)
                    {
                        // Write the record to the log file.
                        errCount += 1;
                        LogErrorLine(ex.Message, tableName, columnName, size, startPosition - size, line, value);

                        dt.Rows.Remove(dt.Rows[recAddedCount]);
                        //recReadCount -= 1;
                        rejected += 1;
                        RefreshRejected(string.Format("{0:n0}", rejected) + " records rejected from " + tableName);
                    }

                    sb.Remove(0, sb.Length);
                }

                RefreshRead(string.Format("{0:n0}", recReadCount) + " records read from " + tableName);
                if (rejected > 0)
                    RefreshRejected(string.Format("{0:n0}", rejected) + " records rejected from " + tableName);

                // Perform the bulk copy.
                PerformBulkCopy(ref dt, database, schema, tableName);
                RefreshAdded(string.Format(string.Format("{0:n0}", totalCount) + " records inserted into " + tableName + " so far..."));

                if (tableName == "F002_CLAIMS_MSTR_HDR")
                {
                    claimsMstrHdrLoaded = true;
                }

                if (tableName == "F002_CLAIMS_MSTR_DTL")
                {
                    claimsMstrDtlLoaded = true;
                }

                if (tableName == "F002_CLAIMS_MSTR_DESC")
                {
                    claimsMstrDtlDescLoaded = true;
                }

                if (tableName == "ICONST_MSTR_REC")
                {
                    iconstMstrRecLoaded = true;
                }

                if (tableName == "CONSTANTS_MSTR_REC_1")
                {
                    constantsMstrRec1Loaded = true;
                }

                if (tableName == "CONSTANTS_MSTR_REC_2")
                {
                    constantsMstrRec2Loaded = true;
                }

                if (tableName == "CONSTANTS_MSTR_REC_3")
                {
                    constantsMstrRec3Loaded = true;
                }
                if (tableName == "CONSTANTS_MSTR_REC_4")
                {
                    constantsMstrRec4Loaded = true;
                }
                if (tableName == "CONSTANTS_MSTR_REC_5")
                {
                    constantsMstrRec5Loaded = true;
                }
                if (tableName == "CONSTANTS_MSTR_REC_6")
                {
                    constantsMstrRec6Loaded = true;
                }
                if (tableName == "CONSTANTS_MSTR_REC_7")
                {
                    constantsMstrRec7Loaded = true;
                }
                if (dt_doc_clinic_nbr.Rows.Count > 0)
                {
                    PerformBulkCopy(ref dt_doc_clinic_nbr, database, schema, "F020C_DOC_CLINIC_NEXT_BATCH_NBR");
                    RefreshAdded(string.Format(string.Format("{0:n0}", totalCount - rejected) + " records inserted into " + tableName + " so far..."));
                }

                if (dt_doc_loc.Rows.Count > 0)
                {
                    PerformBulkCopy(ref dt_doc_loc, database, schema, "F020L_DOC_LOCATIONS");
                    RefreshAdded(string.Format(string.Format("{0:n0}", totalCount - rejected) + " records inserted into " + tableName + " so far..."));
                }

                if (dt_doc_clinic_nbr3.Rows.Count > 0)
                {
                    PerformBulkCopy(ref dt_doc_clinic_nbr3, database, schema, "F200C_OSCAR_PROVIDER_NEXT_BATCH_NBR");
                    RefreshAdded(string.Format(string.Format("{0:n0}", totalCount - rejected) + " records inserted into " + tableName + " so far..."));
                }

                if (dt_doc_clinic_nbr4.Rows.Count > 0)
                {
                    PerformBulkCopy(ref dt_doc_clinic_nbr4, database, schema, "F020C_DOCTOR_AUDIT_NEXT_BATCH_NBR");
                    RefreshAdded(string.Format(string.Format("{0:n0}", totalCount - rejected) + " records inserted into " + tableName + " so far..."));
                }

                if (dt_doc_loc2.Rows.Count > 0)
                {
                    PerformBulkCopy(ref dt_doc_loc2, database, schema, "F020L_DOCTOR_AUDIT_LOCATIONS");
                    RefreshAdded(string.Format(string.Format("{0:n0}", totalCount - rejected) + " records inserted into " + tableName + " so far..."));
                }

                // Perform a final count.
                string noRecords = string.Empty;
                cm = new SqlCommand("SELECT Count(-1) FROM [" + txtDatabase.Text.ToString() + "].[" + schema + "].[" + tableName + "]", cn);
                noRecords = Convert.ToInt32(cm.ExecuteScalar()).ToString();
                RefreshLog(tableName + ": " + noRecords + " inserted out of " + recReadCount.ToString() + " read" + (noRecords == totalCount.ToString() || rejected > 0 ? "" : " ****"));
                RefreshAdded(string.Format(string.Format("{0:n0}", noRecords) + " records inserted into table " + tableName));
                binFile.Close();
                binFile.Dispose();
            }
        }

        public static bool IsDigit(char c)
        {
            if ((int)c >= 48)
                return (int)c <= 57;
            else
                return false;
        }

        private bool IsNumeric(string value)
        {
            double myNum = 0;
            bool isNumeric = false;

            if (Double.TryParse(value, out myNum))
            {
                isNumeric = true;
            }

            return isNumeric;
        }

        private bool IsNegativeNumber(string Value)
        {
            return Convert.ToString(Convert.ToInt64(Value, 16), 2).PadLeft((Value.Length / 2) * 4, '0').Substring(0, 1) == "1";
        }

        private void Load_ADJ_CLAIM_FILE_BK(ref DataTable dt, string schema, string table, string fileName, int recordLength, string columnString, ref int recReadCount)
        {
            DateTime? dateValue = default(System.DateTime);

            decimal? adj_claim_nbr = 0;
            decimal? numberValue = 0;
            
            int size = 0;
            int startPosition = 0;
            int factor = 0;
            int fileCounter = 1;
            int rowCounter = 0;

            string adj_batch_nbr = string.Empty;
            string columnName = string.Empty;
            string line = string.Empty;
            string newColumn = string.Empty;
            string signed = string.Empty;
            string value = string.Empty;
            string whereClause = string.Empty;

            string[] ar = columnString.Split(',');
            string[] column = null;
            string[] recordArray = { };

            try
            {
                while (true)
                {
                    //Check if backup dat file exists
                    if (File.Exists(txtFileName.Text + fileName + fileCounter.ToString() + ".dat"))
                    {
                        var binFile = new BinaryReader(new FileStream(txtFileName.Text + fileName + fileCounter.ToString() + ".dat", FileMode.Open));

                        while (true)
                        {
                            var buf = binFile.ReadBytes(recordLength);

                            if (buf.Length < recordLength)
                            {
                                fileCounter += 1;
                                break;
                            }
                            else
                            {
                                line = string.Empty;
                                for (int i = 0; i < buf.Length; i++)
                                {
                                    line += (char)buf[i];
                                }

                                recReadCount += 1;
                                startPosition = 0;

                                SqlCommand cm = new SqlCommand("SELECT * FROM [" + txtDatabase.Text.ToString() + "].[" + schema + "].[ADJ_CLAIM_FILE_BK] WHERE 0 = 1", cn);
                                SqlDataAdapter da = new SqlDataAdapter(cm);
                                da.Fill(dt);

                                dt.Rows.Add(CreateNewRowObject(ref dt));
                                rowCounter = dt.Rows.Count - 1;

                                for (int j = 0; j <= ar.Length - 1; j++)
                                {
                                    columnName = ar[j].Replace("-", "_");
                                    column = columns[columnName].ToString().Split('~');

                                    size = Convert.ToInt32(column[(int)items.Size]);

                                    if (chkIsDelimited.Checked)
                                        recordArray = SplitLineBasedOnDelimiter(table, line, ar);

                                    if (columnName != "BACKUP_VERSION" && columnName != "BACKUP_DATETIME")
                                    {
                                        if (chkIsDelimited.Checked)
                                            if (recordArray[j].StartsWith("\0"))
                                            {
                                                value = "\0";
                                            }
                                            else
                                            {
                                                value = recordArray[j];
                                            }
                                        else

                                        if (line.Substring(startPosition, size).StartsWith("\0"))
                                        {
                                            value = "\0";
                                        }
                                        else
                                        {
                                            value = line.Substring(startPosition, size);
                                        }
                                    }

                                    var si = 0;
                                    var cna = string.Empty;
                                    var f = 0;
                                    var sig = string.Empty;

                                    switch (columnName)
                                    {
                                        case "ADJ_BATCH_NBR":
                                            si = 8;
                                            f = 0;
                                            sig = string.Empty;
                                            adj_batch_nbr = value;
                                            break;

                                        case "ADJ_CLAIM_NBR":
                                            si = 2;
                                            f = 0;
                                            sig = string.Empty;
                                            adj_claim_nbr = Convert.ToInt16(value);
                                            break;

                                        case "ADJ_OMA_CD_SUFF":
                                            si = 5;
                                            f = 0;
                                            sig = string.Empty;
                                            break;

                                        case "ADJ_SERV_DATE":
                                            si = 8;
                                            f = 0;
                                            sig = string.Empty;
                                            break;

                                        case "ADJ_AGENT_CD":
                                            si = 1;
                                            f = 0;
                                            sig = string.Empty;
                                            break;

                                        case "ADJ_PAT_ACRONYM":
                                            si = 9;
                                            f = 0;
                                            sig = string.Empty;
                                            break;

                                        case "ADJ_AMT_BAL":
                                            si = 7;
                                            f = 0;
                                            sig = string.Empty;
                                            break;

                                        case "ADJ_DIAG_CD":
                                            si = 3;
                                            f = 0;
                                            sig = string.Empty;
                                            break;

                                        case "ADJ_LINE_NO":
                                            si = 2;
                                            f = 0;
                                            sig = string.Empty;
                                            break;

                                        case "BACKUP_VERSION":
                                            si = 3;
                                            f = 0;
                                            sig = string.Empty;
                                            break;

                                        case "BACKUP_DATETIME":
                                            si = 8;
                                            f = 0;
                                            sig = string.Empty;
                                            break;
                                    }

                                    if (columnName == "BACKUP_VERSION" || columnName == "BACKUP_DATETIME")
                                    {
                                        if (columnName == "BACKUP_VERSION")
                                        {
                                    //        newColumn = "ADJ_CLAIM_FILE_BK~SEQUENTIAL~ADJ_CLAIM_FILE_BK~BACKUP_VERSION~Character~3~ ~ ~ ~ ~0~0~0~ ~ ~45";
                                            value = fileCounter.ToString();
                                        }
                                        else
                                        {
                                    //        newColumn = "ADJ_CLAIM_FILE_BK~SEQUENTIAL~ADJ_CLAIM_FILE_BK~BACKUP_DATETIME~PHDate~ ~ ~ ~ ~ ~0~0~0~ ~ ~45";
                                            value = DateTime.Now.Year.ToString().PadLeft(4, '0') + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0');
                                        }

                                    //    column = newColumn.Split('~');
                                    //    AddColumn(ref startPosition, ref si, ref column, ref value, ref numberValue, ref sig, ref dateValue, ref dt, ref columnName, ref f, ref rowCounter, buf);
                                    }
                                    //else
                                    //{
                                        var col = columns[columnName].ToString().Split('~');
                                        AddColumn(ref startPosition, ref si, ref col, ref value, ref numberValue, ref sig, ref dateValue, ref dt, ref columnName, ref f, ref rowCounter, buf);
                                    //}
                                }

                                ////Add BACKUP_VERSION and BACKUP_DATETIME to the list
                                //string col_BACKUP_VERSION = "ADJ_CLAIM_FILE_BK~SEQUENTIAL~ADJ_CLAIM_FILE_BK~BACKUP_VERSION~Character~3~ ~ ~ ~ ~0~0~0~ ~ ~45";
                                //column = col_BACKUP_VERSION.Split('~');

                                //whereClause = "ADJ_BATCH_NBR = '" + adj_batch_nbr + "' AND ADJ_CLAIM_NBR = " + adj_claim_nbr; 

                                //columnName = "BACKUP_VERSION";
                                //value = fileCounter.ToString();
                                //UpdateColumn(ref startPosition, ref size, ref column, ref value, ref numberValue, ref signed, ref dateValue, ref dt, ref columnName, ref factor, ref whereClause);

                                //string col_BACKUP_DATETIME = "ADJ_CLAIM_FILE_BK~SEQUENTIAL~ADJ_CLAIM_FILE_BK~BACKUP_DATETIME~PHDate~ ~ ~ ~ ~ ~0~0~0~ ~ ~45";
                                //column = col_BACKUP_DATETIME.Split('~');

                                //columnName = "BACKUP_DATETIME";
                                //value = DateTime.Now.Year.ToString().PadLeft(4, '0') + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0');
                                //UpdateColumn(ref startPosition, ref size, ref column, ref value, ref numberValue, ref signed, ref dateValue, ref dt, ref columnName, ref factor, ref whereClause);
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            catch (Exception ex)
            {
                // Write the record to the log file.
                errCount += 1;
                LogErrorLine(ex.Message, table, columnName, size, startPosition - size, line, value);
            }
        }

        private void LoadDataTables()
        {
            if (OpenConnection(txtDatabase.Text))
            {
                try
                {
                    ReadSchemaInformation();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                CloseConnection();
            }
        }

        private void LoadSettings()
        {
            StreamReader sr;
            string line = string.Empty;

            if (File.Exists("Settings.config"))
            {
                sr = new StreamReader("Settings.config");

                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    switch (line.Substring(0, line.IndexOf("=")))
                    {
                        case "<UserName>":
                            txtUser.Text = line.Substring(line.IndexOf("=") + 1);
                            break;
                        case "<Server>":
                            txtServer.Text = line.Substring(line.IndexOf("=") + 1);
                            break;
                        case "<Database>":
                            txtDatabase.Text = line.Substring(line.IndexOf("=") + 1);
                            break;
                        case "<DBLocation>":
                            txtDatabaseLocation.Text = line.Substring(line.IndexOf("=") + 1);
                            break;
                        case "<FileName>":
                            txtFileName.Text = line.Substring(line.IndexOf("=") + 1);

                            if (!txtFileName.Text.EndsWith("\\"))
                                txtFileName.Text += "\\";
                            break;
                        case "<CheckDelimited>":
                            if (line.Substring(line.IndexOf("=") + 1) == "True")
                                chkIsDelimited.Checked = true;
                            break;
                        case "<Delimiter>":
                            txtDelimiter.Text = line.Substring(line.IndexOf("=") + 1);
                            break;
                        case "<PortableSubfile>":
                            if (line.Substring(line.IndexOf("=") + 1) == "True")
                                chkPortableSubFile.Checked = true;
                            break;
                        case "<MinimumYearCutOff>":
                            txtMinimumYearCutoff.Text = line.Substring(line.IndexOf("=") + 1);
                            break;
                        case "<ScriptsLocation>":
                            txtScriptsLocation.Text = line.Substring(line.IndexOf("=") + 1);

                            if (!txtScriptsLocation.Text.EndsWith("\\"))
                                txtScriptsLocation.Text += "\\";
                            break;
                    }
                }

                sr.Close();
                sr.Dispose();
            }
        }

        private void LoadTablesToList()
        {
            StreamReader sr = new StreamReader(txtFileName.Text + importSchemaFile + ".Core", Encoding.Default); ;
            StringBuilder sb = new StringBuilder(string.Empty);
            string line = string.Empty;
            int lineCount = 0;

            lstTables.Items.Clear();

            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                lineCount += 1;

                if (lineCount > 1)
                {
                    if (!tablelist.Contains(line.Split('~')[(int)items.Relation].Trim().PadRight(40, ' ') + "(" + line.Split('~')[(int)items.FileName].Trim() + ")"))
                    {
                        if (line.Split('~')[(int)items.Relation].Trim() != string.Empty)
                        {
                            tablelist.Add(line.Split('~')[(int)items.Relation].Trim().PadRight(40, ' ') + "(" + line.Split('~')[(int)items.FileName].Trim() + ")");
                        }
                    }
                }
            }

            lstTables.Items.AddRange(tablelist.ToArray());
        }

        private void LogErrorLine(string message, string tableName, string columnName, int size, int position, string line, string value)
        {
            if (errCount < 500)
            {
                sbError.Append(message).Append("   [Table: ").Append(tableName).Append("; Column: ").Append(columnName).Append("; Size: ").Append(size).Append("; Position: ").Append(position).Append("; Value: ").Append(value).Append("]");
                sbError.Append(Environment.NewLine);
                sbError.Append(line);
                sbError.Append(Environment.NewLine).Append(Environment.NewLine);
            }
            else
            {
                WriteOutErrorLog();
            }
        }

        private bool MatchRecordLength(string tableName, int recordLength)
        {
            //bool retvalue = false;
            //StringBuilder strSQL = new StringBuilder(string.Empty);
            //SqlCommand cm = new SqlCommand();

            //if (recordLength > 0 & tableName != "F002_CLAIMS_MSTR_HDR" & tableName != "F002_CLAIMS_MSTR_DTL" & tableName != "F002_CLAIMS_MSTR_DESC" & tableName != "F020_DOCTOR_EXTRA" & tableName != "F020C_DOC_CLINIC_NEXT_BATCH_NBR" & tableName != "F020_DOCTOR_MSTR" & tableName != "F020C_DOC_LOCATIONS" & tableName != "ICONST_MSTR_REC" & tableName != "CONSTANTS_MSTR_REC_1" & tableName != "CONSTANTS_MSTR_REC_2" & tableName != "CONSTANTS_MSTR_REC_3" & tableName != "CONSTANTS_MSTR_REC_4" & tableName != "CONSTANTS_MSTR_REC_5" & tableName != "CONSTANTS_MSTR_REC_6" & tableName != "CONSTANTS_MSTR_REC_7" & tableName != "F094_MSG_MSTR" & tableName != "F094_SUB_MSTR" & tableName != "F200_OSCAR_PROVIDER" & tableName != "F200C_OSCAR_PROVIDER_NEXT_BATCH_NBR" & tableName != "F020_DOCTOR_AUDIT" & tableName != "F020C_DOCTOR_AUDIT_NEXT_BATCH_NBR" & tableName != "F020L_DOCTOR_AUDIT_LOCATIONS" & tableName != "CLAIMS_WORK_MSTR" & tableName != "R070_WORK_MSTR" & tableName != "BATHDR_REC" & tableName != "CLMHDR_1_REC" & tableName != "CLMHDR_2_REC" & tableName != "TRAILER_REC")
            //{
            //    if (OpenConnection(txtDatabase.Text))
            //    {
            //        SqlDataReader reader;

            //        strSQL.Append("SELECT (COUNT(1) - 2) columncount, (SUM(CASE WHEN xprec <> 0 THEN xprec ELSE length END) - 25) maxrowlength ");
            //        strSQL.Append("FROM syscolumns ");
            //        strSQL.Append("WHERE OBJECT_NAME(id) = '").Append(tableName).Append("'");
            //        strSQL.Append("GROUP BY OBJECT_NAME(id)");

            //        cm = new SqlCommand(strSQL.ToString(), cn);
            //        reader = cm.ExecuteReader();
            //        reader.Read();

            //        if (reader.GetInt32(1) == recordLength)
            //        {
            //            retvalue = true;
            //        }

            //        reader.Close();
            //    }

            //    CloseConnection();
            //}
            //else
            //{
            //    retvalue = true;
            //}

            //return retvalue;
            return true;
        }

        private bool OpenConnection(string DatabaseName)
        {
            StreamReader sr = new StreamReader(txtScriptsLocation.Text + "Connection.sql");
            StreamReader sr2 = new StreamReader(txtScriptsLocation.Text + "Connection2.sql");
            bool retVal = false;

            try
            {
                if (txtUser.Text.ToUpper() == "SA")
                {
                    if (File.Exists(txtScriptsLocation.Text + "Connection.sql"))
                    {
                        StringBuilder sb = new StringBuilder(string.Empty);
                        string line = string.Empty;
                        SqlCommand cm = new SqlCommand();

                        while (!sr.EndOfStream)
                        {
                            line = sr.ReadLine();
                            sb.Append(line.Replace("%DatabaseName%", DatabaseName)).Append(Environment.NewLine);
                        }

                        cn = new SqlConnection(sb.ToString().Replace("%Server%", txtServer.Text).Replace("%UserName%", txtUser.Text).Replace("%Password%", txtPassword.Text));
                        cn.Open();

                        retVal = true;
                    }
                    else
                    {
                        MessageBox.Show("File " + txtScriptsLocation.Text +"Connection.sql does not exist.");
                        stopProcessing = true;
                        Cursor.Current = Cursors.Default;
                    }
                }
                else
                {
                    if (File.Exists(txtScriptsLocation.Text + "Connection2.sql"))
                    {
                        StringBuilder sb = new StringBuilder(string.Empty);
                        string line = string.Empty;
                        SqlCommand cm = new SqlCommand();

                        while (!sr2.EndOfStream)
                        {
                            line = sr2.ReadLine();
                            sb.Append(line.Replace("%DatabaseName%", DatabaseName)).Append(Environment.NewLine);
                        }

                        cn = new SqlConnection(sb.ToString().Replace("%Server%", txtServer.Text));
                        cn.Open();

                        retVal = true;
                    }
                    else
                    {
                        MessageBox.Show("File " + txtScriptsLocation.Text + "Connection.sql does not exist.");
                        stopProcessing = true;
                        Cursor.Current = Cursors.Default;
                    }

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("OpenConnection: " + ex.Message);
                stopProcessing = true;
                Cursor.Current = Cursors.Default;
                txtUser.SelectionStart = 0;
                txtUser.SelectionLength = txtUser.Text.Length;
                this.ActiveControl = txtUser;
            }

            sr.Close();
            sr.Dispose();
            sr2.Close();
            sr2.Dispose();

            return retVal;
        }

        private void PerformBulkCopy(ref DataTable dt, string database, string schema, string tableName)
        {
            SqlBulkCopy bulkCopy = null;

            try
            {
                bulkCopy = new SqlBulkCopy(cn);
                bulkCopy.BulkCopyTimeout = 1000;
                bulkCopy.DestinationTableName = "[" + txtDatabase.Text.ToString() + "].[" + schema + "].[" + tableName + "]";
                bulkCopy.NotifyAfter = 1000;
                bulkCopy.WriteToServer(dt);
            }
            catch (Exception ex)
            {
                HandleBcpException(ref bulkCopy, ex, tableName);
                return;
            }
            finally
            {
                bulkCopy.Close();
            }

            dt.Rows.Clear();
        }

        private void ReadSchemaInformation()
        {
            bool load_CONSTANTS_MSTR_REC_1 = false;
            bool load_CONSTANTS_MSTR_REC_2 = false;
            bool load_CONSTANTS_MSTR_REC_3 = false;
            bool load_CONSTANTS_MSTR_REC_4 = false;
            bool load_CONSTANTS_MSTR_REC_5 = false;
            bool load_CONSTANTS_MSTR_REC_6 = false;
            bool load_CONSTANTS_MSTR_REC_7 = false;
            bool load_F020_DOCTOR_MSTR = false;
            bool load_F020_DOCTOR_EXTRA = false;
            bool load_F002_CLAIMS_MSTR_HDR = false;
            bool load_F002_CLAIMS_MSTR_DTL = false;
            bool load_F002_CLAIMS_MSTR_DESC = false;
            bool load_ICONST_MSTR_REC = false;
            bool tableSelected = false;

            int length = 0;
            int lineCount = 0;
            int recordLength = 0;
            int totalLength = 0;

            StreamReader sr = new StreamReader(txtFileName.Text + importSchemaFile + ".Core", Encoding.Default);

            string columnName = string.Empty;
            string databaseName = string.Empty;
            string fileName = string.Empty;
            string line = string.Empty;
            string previousDatabase = string.Empty;
            string previousFileName = string.Empty;
            string previousTable = string.Empty;
            string tableName = string.Empty;

            StringBuilder sb = new StringBuilder(string.Empty);

            try
            {

                //Check if F020_DOCTOR_MSTR OR F020_DOCTOR_EXTRA is selected
                foreach (object element in lstTables.SelectedItems)
                {
                    if (element.ToString().Substring(0, element.ToString().IndexOf(" ")) == "F020_DOCTOR_MSTR")
                    {
                        load_F020_DOCTOR_EXTRA = true;
                    }

                    if (element.ToString().Substring(0, element.ToString().IndexOf(" ")) == "F020_DOCTOR_EXTRA")
                    {
                        load_F020_DOCTOR_MSTR = true;
                    }

                    if (element.ToString().Substring(0, element.ToString().IndexOf(" ")) == "F002_CLAIMS_MSTR_HDR")
                    {
                        load_F002_CLAIMS_MSTR_DTL = true;
                        load_F002_CLAIMS_MSTR_DESC = true;
                    }

                    if (element.ToString().Substring(0, element.ToString().IndexOf(" ")) == "F002_CLAIMS_MSTR_DTL")
                    {
                        load_F002_CLAIMS_MSTR_HDR = true;
                        load_F002_CLAIMS_MSTR_DESC = true;
                    }

                    if (element.ToString().Substring(0, element.ToString().IndexOf(" ")) == "F002_CLAIMS_MSTR_DESC")
                    {
                        load_F002_CLAIMS_MSTR_HDR = true;
                        load_F002_CLAIMS_MSTR_DTL = true;
                    }

                    if (element.ToString().Substring(0, element.ToString().IndexOf(" ")) == "ICONST_MSTR_REC")
                    {
                        load_CONSTANTS_MSTR_REC_1 = true;
                        load_CONSTANTS_MSTR_REC_2 = true;
                        load_CONSTANTS_MSTR_REC_3 = true;
                        load_CONSTANTS_MSTR_REC_4 = true;
                        load_CONSTANTS_MSTR_REC_5 = true;
                        load_CONSTANTS_MSTR_REC_6 = true;
                        load_CONSTANTS_MSTR_REC_7 = true;
                    }

                    if (element.ToString().Substring(0, element.ToString().IndexOf(" ")) == "CONSTANTS_MSTR_REC_1")
                    {
                        load_ICONST_MSTR_REC = true;
                        load_CONSTANTS_MSTR_REC_2 = true;
                        load_CONSTANTS_MSTR_REC_3 = true;
                        load_CONSTANTS_MSTR_REC_4 = true;
                        load_CONSTANTS_MSTR_REC_5 = true;
                        load_CONSTANTS_MSTR_REC_6 = true;
                        load_CONSTANTS_MSTR_REC_7 = true;
                    }

                    if (element.ToString().Substring(0, element.ToString().IndexOf(" ")) == "CONSTANTS_MSTR_REC_2")
                    {
                        load_ICONST_MSTR_REC = true;
                        load_CONSTANTS_MSTR_REC_1 = true;
                        load_CONSTANTS_MSTR_REC_3 = true;
                        load_CONSTANTS_MSTR_REC_4 = true;
                        load_CONSTANTS_MSTR_REC_5 = true;
                        load_CONSTANTS_MSTR_REC_6 = true;
                        load_CONSTANTS_MSTR_REC_7 = true;
                    }

                    if (element.ToString().Substring(0, element.ToString().IndexOf(" ")) == "CONSTANTS_MSTR_REC_3")
                    {
                        load_ICONST_MSTR_REC = true;
                        load_CONSTANTS_MSTR_REC_1 = true;
                        load_CONSTANTS_MSTR_REC_2 = true;
                        load_CONSTANTS_MSTR_REC_4 = true;
                        load_CONSTANTS_MSTR_REC_5 = true;
                        load_CONSTANTS_MSTR_REC_6 = true;
                        load_CONSTANTS_MSTR_REC_7 = true;
                    }

                    if (element.ToString().Substring(0, element.ToString().IndexOf(" ")) == "CONSTANTS_MSTR_REC_4")
                    {
                        load_ICONST_MSTR_REC = true;
                        load_CONSTANTS_MSTR_REC_1 = true;
                        load_CONSTANTS_MSTR_REC_2 = true;
                        load_CONSTANTS_MSTR_REC_3 = true;
                        load_CONSTANTS_MSTR_REC_5 = true;
                        load_CONSTANTS_MSTR_REC_6 = true;
                        load_CONSTANTS_MSTR_REC_7 = true;
                    }

                    if (element.ToString().Substring(0, element.ToString().IndexOf(" ")) == "CONSTANTS_MSTR_REC_5")
                    {
                        load_ICONST_MSTR_REC = true;
                        load_CONSTANTS_MSTR_REC_1 = true;
                        load_CONSTANTS_MSTR_REC_2 = true;
                        load_CONSTANTS_MSTR_REC_3 = true;
                        load_CONSTANTS_MSTR_REC_4 = true;
                        load_CONSTANTS_MSTR_REC_6 = true;
                        load_CONSTANTS_MSTR_REC_7 = true;
                    }

                    if (element.ToString().Substring(0, element.ToString().IndexOf(" ")) == "CONSTANTS_MSTR_REC_6")
                    {
                        load_ICONST_MSTR_REC = true;
                        load_CONSTANTS_MSTR_REC_1 = true;
                        load_CONSTANTS_MSTR_REC_2 = true;
                        load_CONSTANTS_MSTR_REC_3 = true;
                        load_CONSTANTS_MSTR_REC_4 = true;
                        load_CONSTANTS_MSTR_REC_5 = true;
                        load_CONSTANTS_MSTR_REC_7 = true;
                    }

                    if (element.ToString().Substring(0, element.ToString().IndexOf(" ")) == "CONSTANTS_MSTR_REC_7")
                    {
                        load_ICONST_MSTR_REC = true;
                        load_CONSTANTS_MSTR_REC_1 = true;
                        load_CONSTANTS_MSTR_REC_2 = true;
                        load_CONSTANTS_MSTR_REC_3 = true;
                        load_CONSTANTS_MSTR_REC_4 = true;
                        load_CONSTANTS_MSTR_REC_5 = true;
                        load_CONSTANTS_MSTR_REC_6 = true;
                    }
                }

                line = sr.ReadLine();
                while ((line != null) && line.Length > 0)
                {
                    lineCount += 1;

                    if (lineCount > 1)
                    {
                        tableSelected = false;

                        foreach (string item in lstTables.SelectedItems)
                        {
                            if (item.Substring(0, item.IndexOf(" ")) == line.Split('~')[(int)items.Relation] ||
                                (load_F020_DOCTOR_MSTR == true & "F020_DOCTOR_MSTR" == line.Split('~')[(int)items.Relation]) ||
                                (load_F020_DOCTOR_EXTRA == true & "F020_DOCTOR_EXTRA" == line.Split('~')[(int)items.Relation]) ||
                                (load_F002_CLAIMS_MSTR_HDR == true & "F002_CLAIMS_MSTR_HDR" == line.Split('~')[(int)items.Relation]) ||
                                (load_F002_CLAIMS_MSTR_DTL == true & "F002_CLAIMS_MSTR_DTL" == line.Split('~')[(int)items.Relation]) ||
                                (load_F002_CLAIMS_MSTR_DESC == true & "F002_CLAIMS_MSTR_DESC" == line.Split('~')[(int)items.Relation]) ||
                                (load_CONSTANTS_MSTR_REC_1 == true & "CONSTANTS_MSTR_REC_1" == line.Split('~')[(int)items.Relation]) ||
                                (load_CONSTANTS_MSTR_REC_2 == true & "CONSTANTS_MSTR_REC_2" == line.Split('~')[(int)items.Relation]) ||
                                (load_CONSTANTS_MSTR_REC_3 == true & "CONSTANTS_MSTR_REC_3" == line.Split('~')[(int)items.Relation]) ||
                                (load_CONSTANTS_MSTR_REC_4 == true & "CONSTANTS_MSTR_REC_4" == line.Split('~')[(int)items.Relation]) ||
                                (load_CONSTANTS_MSTR_REC_5 == true & "CONSTANTS_MSTR_REC_5" == line.Split('~')[(int)items.Relation]) ||
                                (load_CONSTANTS_MSTR_REC_6 == true & "CONSTANTS_MSTR_REC_6" == line.Split('~')[(int)items.Relation]) ||
                                (load_CONSTANTS_MSTR_REC_7 == true & "CONSTANTS_MSTR_REC_7" == line.Split('~')[(int)items.Relation]))
                            {
                                tableSelected = true;
                            }
                        }

                        if (lstTables.SelectedIndex == -1 | tableSelected == true)
                        {
                            fileName = line.Split('~')[(int)items.FileName];
                            databaseName = line.Split('~')[(int)items.Database];
                            tableName = line.Split('~')[(int)items.Relation];
                            columnName = line.Split('~')[(int)items.Column];
                            length = Convert.ToInt32(line.Split('~')[(int)items.Size]);
                            recordLength = Convert.ToInt32(line.Split('~')[(int)items.RecordLength].Trim());

                            if (tableName != previousTable && previousTable.Length > 0)
                            {
                                if (!tables.Contains(previousTable))
                                {
                                    //Set the logfile name
                                    logFile = "LogFiles\\" + txtDatabase.Text + "\\" + previousFileName + "_Error.log";

                                    //Delete the log file if it exist.

                                    if (File.Exists(logFile))
                                    {
                                        if (previousFileName == "F002_CLAIMS_MSTR_HDR")
                                        {
                                            File.Delete(logFile);
                                        }
                                        else if (previousFileName == "F002_CLAIMS_MSTR_DTL" || previousFileName == "F002_CLAIMS_MSTR_DESC")
                                        {
                                            //do not delete the log file
                                        }
                                        else
                                        {
                                            File.Delete(logFile);
                                        }
                                    }

                                    if(MatchRecordLength(tableName, recordLength) == true)
                                    {
                                        if (OpenConnection(txtDatabase.Text))
                                        {
                                            RefreshStatus("Loading table " + previousTable);

                                            InsertData(previousFileName, previousDatabase, previousTable, totalLength, sb.ToString());

                                            if (sbError.ToString().Trim() != string.Empty)
                                            {
                                                errCount = 501;
                                                WriteOutErrorLog();
                                            }
                                            sb.Remove(0, sb.Length);

                                            CloseConnection();
                                        }
                                    }
                                    else
                                    {
                                        RefreshLog("ERROR: The maximum length of a record in " + tableName + " does not match the record length in the schema file.");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("The table " + previousFileName + " already exists in the hashtable");
                                }
                                totalLength = 0;
                                columns = new Hashtable();
                            }

                            RefreshStatus("Reading table " + tableName);

                            if (sb.Length > 0)
                                sb.Append(",");
                            sb.Append(columnName);

                            columns.Add(columnName, line);
                            totalLength = recordLength;
                            previousTable = tableName;
                            previousDatabase = databaseName;
                            previousFileName = fileName;
                        }
                    }

                    line = sr.ReadLine();
                }

                // Add the last table
                if (!tables.Contains(previousTable) | lstTables.SelectedItems.Count == 1)
                {
                    if(MatchRecordLength(tableName, recordLength) == true)
                    {
                        if (OpenConnection(txtDatabase.Text))
                        {
                            //Set the logfile name
                            logFile = "LogFiles\\" + txtDatabase.Text + "\\" + previousFileName + "_Error.log";

                            //Delete the log file if it exist.
                            if (File.Exists(logFile))
                                File.Delete(logFile);

                            RefreshStatus("Loading table " + tableName);
                            InsertData(previousFileName, previousDatabase, previousTable, totalLength, sb.ToString());

                            if (sbError.ToString().Trim() != string.Empty)
                            {
                                errCount = 501;
                                WriteOutErrorLog();
                            }

                            CloseConnection();
                        }
                    }
                    else
                    {
                        RefreshLog("ERROR: The maximum length of a record in " + tableName + " does not match the record length in the schema file.");
                    }
                }
                else
                {
                    MessageBox.Show("The table " + tableName + " already exists in the hashtable");
                }

            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                sr.Close();
                sr.Dispose();
            }
        }

        private bool RecordExists(DataTable dt, string whereClause)
        {
            bool retValue = false;

            try
            {
                DataRow[] dr = dt.Select(whereClause);

                if (dr.Count() > 0)
                {
                    retValue = true;
                }
            }

            catch (Exception e)
            {
                throw e;
            }

            return retValue;
        }

        private void RefreshAdded(string Value)
        {
            lblAdded.Text = "Records Added: " + Value;
            this.Show();
            this.Refresh();
        }

        private void RefreshLog(string Value)
        {
            txtLog.Text += Value + "\r\n";
            txtLog.SelectionLength = 0;
            txtLog.SelectionStart = txtLog.Text.Length;
            txtLog.ScrollToCaret();
            this.Show();
            this.Refresh();
        }

        private void RefreshRead(string Value)
        {
            lblRead.Text = "Records Read: " + Value;
            this.Show();
            this.Refresh();
        }

        private void RefreshRejected(string Value)
        {
            this.lblRejected.Text = "Records Rejected: " + Value;
            this.Show();
            this.Refresh();
        }

        private void RefreshStatus(string Value)
        {
            lblStatus.Text = "Status: " + Value;
            this.Show();
            this.Refresh();
        }

        public string Reverse(string Value)
        {
            StringBuilder sb = new StringBuilder(string.Empty);

            for (int i = Value.Length - 1; i >= 0; i += -1)
            {
                sb.Append(Value.Substring(i, 1));
            }

            return sb.ToString();
        }

        private void SaveCurrentSettings()
        {
            StreamWriter sw;
            StringBuilder sb = new StringBuilder(string.Empty);

            try
            {
                if (File.Exists("Settings.config"))
                {
                    File.Delete("Settings.config");
                }

                sb.Append("<UserName>=" + txtUser.Text).Append(Environment.NewLine);
                sb.Append("<Server>=" + txtServer.Text).Append(Environment.NewLine);
                sb.Append("<Database>=" + txtDatabase.Text).Append(Environment.NewLine);
                sb.Append("<DBLocation>=" + txtDatabaseLocation.Text).Append(Environment.NewLine);
                sb.Append("<FileName>=" + txtFileName.Text).Append(Environment.NewLine);
                sb.Append("<CheckDelimited>=" + chkIsDelimited.Checked).Append(Environment.NewLine);
                sb.Append("<Delimiter>=" + txtDelimiter.Text).Append(Environment.NewLine);
                sb.Append("<PortableSubfile>=" + chkPortableSubFile.Checked).Append(Environment.NewLine);
                sb.Append("<MinimumYearCutOff>=" + txtMinimumYearCutoff.Text).Append(Environment.NewLine);
                sb.Append("<ScriptsLocation>=" + txtScriptsLocation.Text).Append(Environment.NewLine);

                sw = new StreamWriter("Settings.config", false, System.Text.Encoding.Default);
                sw.Write(sb.ToString());
                sw.Flush();
                sw.Close();
                sw.Dispose();
            }

            catch(Exception ex)
            {
                MessageBox.Show("SaveCurrentSettings: " + ex.Message);
            }
        }

        // This function is used to split the line based on the delimiter. This function
        // is used instead of Split so that if a string value has a delimiter, we don't 
        // split there (which the Split function would do).
        private string[] SplitLineBasedOnDelimiter(string tableName, string line, string[] ar)
        {

            string[] recordArray = new string[101];
            // Assume 100 columns as worst case scenario
            string remainingLine = line;
            int count = 0;
            int startPosition = 0;
            int position = 0;
            string[] column = null;
            string columnName = null;
            int size = 0;
            string dataType = string.Empty;
            string value = string.Empty;

            columnName = ar[0];
            column = columns[columnName].ToString().Split('~');
            columnName = columnName.Replace("-", "_");
            size = Convert.ToInt32(column[(int)items.Size]);
            dataType = column[(int)items.DataType];

            position = remainingLine.IndexOf(txtDelimiter.Text);

            while (position > -1)
            {
                if (dataType == datatypes.Character.ToString())
                {
                    position = size;
                    if (remainingLine.Substring(startPosition, 1) == "\"")
                    {
                        position = position + 2;
                        // Assume that the size to retrieve will have a start/end quote if a start quote is found.
                    }
                }

                if (position > remainingLine.Length)
                    return recordArray;

                recordArray[count] = remainingLine.Substring(startPosition, position);

                remainingLine = remainingLine.Substring(position + 1).Trim();
                if (remainingLine.StartsWith(","))
                    remainingLine = remainingLine.Substring(1).Trim();

                position = remainingLine.IndexOf(txtDelimiter.Text);
                count = count + 1;

                if (count < ar.Length)
                {
                    columnName = ar[count];
                    column = columns[columnName].ToString().Split('~');
                    columnName = columnName.Replace("-", "_");
                    size = Convert.ToInt32(column[(int)items.Size]);
                    dataType = column[(int)items.DataType];
                }
            }

            // Get the last field
            if (remainingLine.Length > 0)
            {
                recordArray[count] = remainingLine.Substring(startPosition);
            }

            return recordArray;
        }

        private void UpdateColumn(ref int startPosition, ref int size, ref string[] column, ref string value, ref decimal? numberValue, ref string signed, ref DateTime? dateValue, ref DataTable dt, ref string columnName, ref int factor, ref string whereClause)
        {
            startPosition += size;

            try
            {
                switch (column[(int)items.DataType])
                {
                    case "Integer":
                        if (column[(int)items.DataType] == datatypes.Integer.ToString())
                        {
                            if (value.Contains('\0') && value.Trim('\0').Length == 0)
                            {
                                numberValue = (decimal?)null;
                            }
                            else
                            {
                                value = Reverse(value);
                                if (chkPortableSubFile.Checked)
                                    numberValue = Convert.ToDecimal(value);
                                else
                                    numberValue = AsciiToDecimal(value, signed.ToUpper() == "UNSIGNED");
                            }
                        }
                        break;

                    case "PHDate":
                        dateValue = GetDateFromString(value);
                        break;

                    case "VMSDate":
                        value = Reverse(value);
                        numberValue = AsciiToDecimal(value, true);
                        numberValue = numberValue / 10000000;
                        System.DateTime convertedDate = new DateTime(1858, 11, 17).AddSeconds((double)numberValue);
                        numberValue = Convert.ToInt32(convertedDate.ToString("yyyyMMdd"));// Convert.ToInt32(string.Format(convertedDate, "yyyyMMdd"));
                        break;

                    case "Numeric":

                    case "Zoned":
                        if (dt.Columns[columnName].DataType.FullName == "System.DateTime")
                        {
                            if (value.Contains('\0') && value.Trim('\0').Length == 0)
                            {
                                numberValue = (decimal?)null;
                            }
                            else
                            {
                                dateValue = GetDateFromString(value);
                            }
                        }
                        else
                        {
                            if (value.Contains('\0') && value.Trim('\0').Length == 0)
                            {
                                numberValue = (decimal?)null;
                            }
                            else
                            {
                                if (value.IndexOf("\\u") >= 0)
                                {
                                    value = value.Replace("\0", "");
                                    numberValue = AsciiToDecimal(value, signed.ToUpper() == "UNSIGNED");
                                }
                                else
                                {
                                    if (chkPortableSubFile.Checked)
                                    {
                                        numberValue = Convert.ToDecimal(value);
                                    }
                                    else
                                    {
                                        numberValue = ConvertZoned(value, signed.ToUpper() == "SIGNED");
                                    }
                                }
                            }
                        }
                        break;

                    case "Character":
                        // Remove the leading/trailing quotes.
                        if (value.StartsWith("\"") && value.EndsWith("\""))
                            value = value.Substring(1, value.Length - 2);
                        value = value.Trim();
                        break;
                }

                DataRow[] dr = dt.Select(whereClause);

                switch (column[(int)items.DataType])
                {
                    case "Character":
                        if (columnName == "TYPE")
                            dr[0]["CORE_TYPE"] = value;
                        else
                            dr[0][columnName] = value;
                        break;

                    case "Integer":
                        if (numberValue.HasValue)
                        {
                            if (dt.Columns[columnName].DataType.FullName == "System.DateTime")
                                dr[0][columnName] = GetDateFromString(numberValue.ToString());
                            else
                                dr[0][columnName] = numberValue.Value;
                        }
                        else
                        {
                            dr[0][columnName] = DBNull.Value;
                        }
                        break;

                    case "PHDate":
                        if (!(dateValue == null) & !(dateValue == new System.DateTime()) & !(dateValue == System.DateTime.MinValue))
                            dr[0][columnName] = dateValue;//numberValue
                        else
                            dr[0][columnName] = DBNull.Value;
                        break;

                    case "VMSDate":
                        if (dt.Columns[columnName].DataType.FullName == "System.DateTime")
                            dr[0][columnName] = GetDateFromString(numberValue.ToString());
                        else
                            dr[0][columnName] = numberValue;
                        break;

                    case "Numeric":

                    case "Zoned":
                        if (dt.Columns[columnName].DataType.FullName == "System.DateTime")
                        {
                            if (!(dateValue == null) & !(dateValue == new System.DateTime()) & !(dateValue == System.DateTime.MinValue))
                            {
                                dr[0][columnName] = dateValue;//numberValue
                            }
                            else
                            {
                                dr[0][columnName] = DBNull.Value;
                            }
                        }
                        else
                        {
                            if (numberValue.HasValue)
                                dr[0][columnName] = numberValue;
                            else
                                dr[0][columnName] = DBNull.Value;
                        }
                        break;

                    default:
                        break;
                }
            }

            catch (Exception e)
            {
                throw e;
            }
        }

        private void UpdateDocLocS(string value, ref DataTable dt, string columnName, string whereClause)
        {
            try
            {
                DataRow[] dr = dt.Select(whereClause);
                dr[0][columnName] = value;
            }

            catch (Exception e)
            {
                throw e;
            }
        }

        private void UpdateSeqNo(decimal? numberValue, ref DataTable dt, string columnName, string whereClause)
        {
            try
            {
                DataRow[] dr = dt.Select(whereClause);
                dr[0][columnName] = numberValue;
            }

            catch (Exception e)
            {
                throw e;
            }
        }

        private void UpdateTable(ref string schema, ref string tablename, ref int startPosition, ref int size, ref string[] column, ref string value, ref decimal? numberValue, ref string signed, ref DateTime? dateValue, ref DataTable dt, ref string columnName, ref int factor)
        {
            startPosition += size;

            try
            {
                switch (column[(int)items.DataType])
                {
                    case "Integer":
                        if (column[(int)items.DataType] == datatypes.Integer.ToString())
                        {
                            if (value.Contains('\0') && value.Trim('\0').Length == 0)
                            {
                                numberValue = (decimal?)null;
                            }
                            else
                            {
                                value = Reverse(value);
                                if (chkPortableSubFile.Checked)
                                    numberValue = Convert.ToDecimal(value);
                                else
                                    numberValue = AsciiToDecimal(value, signed.ToUpper() == "UNSIGNED");
                            }
                        }
                        break;

                    case "PHDate":
                        dateValue = GetDateFromString(value);
                        break;

                    case "VMSDate":
                        value = Reverse(value);
                        numberValue = AsciiToDecimal(value, true);
                        numberValue = numberValue / 10000000;
                        System.DateTime convertedDate = new DateTime(1858, 11, 17).AddSeconds((double)numberValue);
                        numberValue = Convert.ToInt32(convertedDate.ToString("yyyyMMdd"));// Convert.ToInt32(string.Format(convertedDate, "yyyyMMdd"));
                        break;

                    case "Numeric":

                    case "Zoned":
                        if (dt.Columns[columnName].DataType.FullName == "System.DateTime")
                        {
                            if (value.Contains('\0') && value.Trim('\0').Length == 0)
                            {
                                numberValue = (decimal?)null;
                            }
                            else
                            {
                                dateValue = GetDateFromString(value);
                            }
                        }
                        else
                        {
                            if (value.Contains('\0') && value.Trim('\0').Length == 0)
                            {
                                numberValue = (decimal?)null;
                            }
                            else
                            {
                                if (value.IndexOf("\\u") >= 0)
                                {
                                    value = value.Replace("\0", "");
                                    numberValue = AsciiToDecimal(value, signed.ToUpper() == "UNSIGNED");
                                }
                                else
                                {
                                    if (chkPortableSubFile.Checked)
                                        numberValue = Convert.ToDecimal(value);
                                    else
                                        numberValue = AsciiToDecimal(value, signed.ToUpper() == "SIGNED");
                                }
                            }
                        }
                        break;

                    case "Character":
                        // Remove the leading/trailing quotes.
                        if (value.StartsWith("\"") && value.EndsWith("\""))
                            value = value.Substring(1, value.Length - 2);
                        value = value.Trim();
                        break;
                }

                if (!string.IsNullOrEmpty(column[(int)items.DecimalPosition]) || !string.IsNullOrEmpty(column[(int)items.InputScale]))
                {
                    if (numberValue.HasValue)
                    {
                        if (!string.IsNullOrEmpty(column[(int)items.InputScale]))
                            factor = Convert.ToInt32(column[(int)items.InputScale]);
                        else
                            factor = Convert.ToInt32(column[(int)items.DecimalPosition]);
                        numberValue = (decimal)numberValue / (decimal)(Math.Pow(10, factor));
                    }
                }

                switch (column[(int)items.DataType])
                {
                    case "Character":
                        if (columnName == "TYPE")
                            dt.Rows[0]["CORE_TYPE"] = value;
                        else
                            dt.Rows[0][columnName] = value;
                        break;

                    case "Integer":
                        if (numberValue.HasValue)
                        {
                            if (dt.Columns[columnName].DataType.FullName == "System.DateTime")
                                dt.Rows[0][columnName] = GetDateFromString(numberValue.ToString());
                            else
                                dt.Rows[0][columnName] = numberValue.Value;
                        }
                        else
                        {
                            dt.Rows[0][columnName] = DBNull.Value;
                        }
                        break;

                    case "PHDate":
                        if (!(dateValue == null) & !(dateValue == new System.DateTime()) & !(dateValue == System.DateTime.MinValue))
                            dt.Rows[0][columnName] = dateValue;//numberValue
                        else
                            dt.Rows[0][columnName] = DBNull.Value;
                        break;

                    case "VMSDate":
                        if (dt.Columns[columnName].DataType.FullName == "System.DateTime")
                            dt.Rows[0][columnName] = GetDateFromString(numberValue.ToString());
                        else
                            dt.Rows[0][columnName] = numberValue;
                        break;

                    case "Numeric":

                    case "Zoned":
                        if (dt.Columns[columnName].DataType.FullName == "System.DateTime")
                        {
                            if (!(dateValue == null) & !(dateValue == new System.DateTime()) & !(dateValue == System.DateTime.MinValue))
                            {
                                dt.Rows[0][columnName] = dateValue;//numberValue
                            }
                            else
                            {
                                dt.Rows[0][columnName] = DBNull.Value;
                            }
                        }
                        else
                        {
                            if (numberValue.HasValue)
                                dt.Rows[0][columnName] = numberValue;
                            else
                                dt.Rows[0][columnName] = DBNull.Value;
                        }
                        break;

                    default:
                        break;
                }

                SqlCommand cm = new SqlCommand();
                if (column[(int)items.DataType] == "Character")
                {
                    cm = new SqlCommand("UPDATE [" + schema + "].[" + tablename + "] SET [" + columnName + "] = '" + dt.Rows[0][columnName].ToString() + "' WHERE [DOC_NBR] = '" + dt.Rows[0]["DOC_NBR"].ToString() + "' AND [DOC_CLINIC_NBR] = " + dt.Rows[0]["DOC_CLINIC_NBR"].ToString(), cn);
                }
                else
                {
                    cm = new SqlCommand("UPDATE [" + schema + "].[" + tablename + "] SET [" + columnName + "] = " + dt.Rows[0][columnName].ToString() + " WHERE [DOC_NBR] = '" + dt.Rows[0]["DOC_NBR"].ToString() + "' AND [DOC_CLINIC_NBR] = " + dt.Rows[0]["DOC_CLINIC_NBR"].ToString(), cn);
                }

                cm.ExecuteNonQuery();
                cm.Dispose();
            }

            catch (Exception e)
            {
                throw e;
            }
        }

        private void WriteOutErrorLog()
        {
            try
            {
                if (!Directory.Exists("LogFiles\\" + txtDatabase.Text))
                    Directory.CreateDirectory("LogFiles\\" + txtDatabase.Text);

                StreamWriter sw = default(StreamWriter);
                if (!File.Exists(logFile))
                {
                    sw = File.CreateText(logFile);
                }
                else
                {
                    sw = File.AppendText(logFile);
                }

                sw.WriteLine(sbError.ToString());
                sw.Flush();
                sw.Close();

                errCount = 0;
                sbError.Clear();
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        private void chkStructureOnly_CheckedChanged(object sender, EventArgs e)
        {
            if (chkStructureOnly.Checked == true)
            {
                lstTables.Enabled = false;
                chkSysDebugDate.Enabled = false;
                txtSysDebugDate.Enabled = false;
            }
            else
            {
                lstTables.Enabled = true;
                chkSysDebugDate.Enabled = true;
                txtSysDebugDate.Enabled = true;
            }
        }

        private void chkSysDebugDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSysDebugDate.Checked == false)
            {
                txtSysDebugDate.Text = "";
                txtSysDebugDate.Enabled = false;
            }
            else
                txtSysDebugDate.Enabled = true;
        }
    }
}
