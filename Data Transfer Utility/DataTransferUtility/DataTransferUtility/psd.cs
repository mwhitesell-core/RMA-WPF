//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Data.SqlClient;
//using System.Drawing;
//using System.IO;
//using System.Linq;
//using System.Reflection;
//using System.Text;
//using System.Text.RegularExpressions;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using Microsoft.VisualBasic;
//using System.Data.SqlTypes;

//namespace DateTransferUtility
//{
//    public partial class Form1 : Form
//    {
//        private Hashtable pkcheck = new Hashtable();

//        private Hashtable tables = new Hashtable();
//        private Hashtable tableInformation = new Hashtable();
//        private Hashtable columns = new Hashtable();
//        private SqlConnection cn = null;

//        private ArrayList punch = new ArrayList();
//        private string ptable = "";
//        private string pcolumn = "";

//        private Hashtable columnCounts = new Hashtable();
//        private enum datatypes
//        {
//            Character,
//            Integer,
//            PHDate,
//            VMSDate,
//            Zoned,
//            Numeric
//        }

//        private enum items
//        {
//            FileName = 0,
//            Database = 1,
//            Relation = 2,
//            Column = 3,
//            DataType = 4,
//            Signed = 5,
//            Size = 6,
//            DecimalPosition = 7,
//            Picture = 8,
//            DateFormat = 9,
//            InputScale = 10,
//            OutputScale = 11,
//            Occurs = 12,
//            ParentFlag = 13,
//            RedefinedElement = 14,
//            RecordLength = 15

//            FileName = 0,
//            Database = 1,
//            Relation = 2,
//            Column = 3,
//            DataType = 4,
//            Size = 5,
//            DecimalPosition = 6,
//            Picture = 7,
//            Signed = 8,
//            DateFormat = 9,
//            InputScale = 10,
//            OutputScale = 11,
//            Occurs = 12,
//            ParentFlag = 13,
//            RedefinedElement = 14,
//            RecordLength = 15
//        }

//        public Form1()
//        {
//            InitializeComponent();
//        }

//        private void Button1_Click(System.Object sender, System.EventArgs e)
//        {
//            System.Text.StringBuilder strLog = new System.Text.StringBuilder();

//            RefreshStatus("Opening connection...");

//            cn = new SqlConnection("Initial Catalog=" + txtDatabase.Text + ";Data Source=" + txtServer.Text + ";User ID=" + txtUser.Text + ";Password=" + txtPassword.Text + ";Integrated Security='false';");
//            cn.Open();


//            ReadSchemaInformation();

//            cn.Close();
//            cn.Dispose();

//            var p = new StringBuilder("");
//            foreach (var s in punch)
//            {
//                p.Append(s).Append(Environment.NewLine);
//            }
//            var sw = new StreamWriter("punched");
//            sw.Write(p.ToString());
//            sw.Flush();
//            sw.Dispose();
//        }


//        private void ReadSchemaInformation()
//        {
//            string line = string.Empty;
//            string databaseName = string.Empty;
//            string previousDatabase = string.Empty;
//            string tableName = string.Empty;
//            string columnName = string.Empty;
//            string previousTable = string.Empty;
//            string fileName = string.Empty;
//            string previousFileName = string.Empty;
//            int recordLength = 0;
//            int length = 0;
//            int totalLength = 0;
//            int lineCount = 0;
//            StreamReader sr = new StreamReader(txtFileName.Text, Encoding.Default);
//            StringBuilder sb = new StringBuilder(string.Empty);



//            line = sr.ReadLine();
//            while ((line != null) && line.Length > 0)
//            {
//                lineCount += 1;

//                if (lineCount > 1)
//                {
//                    fileName = line.Split('~')[(int)items.FileName];
//                    databaseName = line.Split('~')[(int)items.Database];
//                    tableName = line.Split('~')[(int)items.Relation];
//                    columnName = line.Split('~')[(int)items.Column];
//                    length = Convert.ToInt32(line.Split('~')[(int)items.Size]);
//                    recordLength = Convert.ToInt32(line.Split('~')[(int)items.RecordLength].Trim());



//                    if (tableName != previousTable && previousTable.Length > 0)
//                    {
//                        if (!tables.Contains(previousTable))
//                        {
//                            RefreshStatus("Loading table " + previousTable);

//                            InsertData(previousFileName, previousDatabase, previousTable, totalLength, sb.ToString());

//                            sb.Remove(0, sb.Length);
//                        }
//                        else
//                        {
//                            MessageBox.Show("The table " + tableName + " already exists in the hashtable");
//                        }
//                        totalLength = 0;
//                        columns = new Hashtable();
//                    }

//                    RefreshStatus("Reading table " + tableName);

//                    if (sb.Length > 0)
//                        sb.Append(",");
//                    sb.Append(columnName);

//                    columns.Add(columnName, line);
//                    totalLength = recordLength;
//                    previousTable = tableName;
//                    previousDatabase = databaseName;
//                    previousFileName = fileName;
//                }

//                line = sr.ReadLine();
//            }

//             Add the last table
//            if (!tables.Contains(previousTable))
//            {
//                RefreshStatus("Loading table " + tableName);
//                InsertData(previousFileName, previousDatabase, previousTable, totalLength, sb.ToString());
//            }
//            else
//            {
//                MessageBox.Show("The table " + tableName + " already exists in the hashtable");
//            }

//            sr.Close();
//            sr.Dispose();

//        }

//        private void InsertData(string fileName, string schema, string table, int recordLength, string columnString)
//        {
//            string fullFileName = txtFileName.Text;
//            fullFileName = fullFileName.Substring(0, fullFileName.LastIndexOf("\\") + 1);

//            fullFileName += fileName;

//            if (!File.Exists(fullFileName))
//            {

//                if (!fileName.EndsWith(".DAT", StringComparison.CurrentCultureIgnoreCase))
//                    fullFileName += ".DAT";
//                if (!File.Exists(fullFileName))
//                {
//                    RefreshLog("Missing dat file for " + table);
//                    return;
//                }
//            }

//            recordLength += 2; // 2;

//            RefreshAdded("");

//            string logFile = fullFileName.Substring(0, fullFileName.Length - 4) + "_Error.log";
//            string database = txtDatabase.Text;
//            string line = string.Empty;
//            StreamReader sr = new StreamReader(fullFileName, Encoding.Default);
//            char[] buffer = new char[recordLength];
//            StringBuilder sb = new StringBuilder(recordLength, recordLength);
//            string value = string.Empty;
//            int count = 0;
//            int chunkCount = 0;
//            int totalCount = 0;
//            int rejected = 0;
//            string columnName = string.Empty;
//            string[] ar = columnString.Split(',');
//            string[] column = null;
//            int returnValue;
//            int size = 0;
//            int startPosition = 0;
//            decimal? numberValue = 0;
//            DateTime? dateValue = default(System.DateTime);
//            int factor = 0;
//            int occurs = 0;
//            string signed = string.Empty;
//            string tableName = table.Replace("-", "_");
//            DataTable dt = new DataTable();
//            SqlCommand cm = new SqlCommand("SELECT * FROM " + schema + "." + "dbo" + "." + tableName + " WHERE 0 = 1", cn);
//            SqlDataAdapter da = new SqlDataAdapter(cm);
//            string[] recordArray = { };
//            string redefineElement = "";
//            string parent = "";
//            int parentsize = 0;
//            int parentoccurs = 0;
//            ArrayList parentChildren = new ArrayList();
//            var doc_nbr = "";
//            DataTable dt_doc_clinic_nbr = new DataTable();
//            DataTable dt_doc_loc = new DataTable();
//            int count_doc_clinic_nbr = 0;
//            int count_doc_loc = 0;
//            ArrayList check_doc_clinic_nbr = new ArrayList();
//            ArrayList check_doc_loc = new ArrayList();

//             Delete the old log file if one exists.
//            if (File.Exists(logFile))
//                File.Delete(logFile);

//            try
//            {
//                da.Fill(dt);
//            }
//            catch (SqlException)
//            {
//                RefreshLog(tableName + ": Missing table ****");
//                return;
//            }

//             Exit if we already loaded the table...
//            if (chkEmptyTablesOnly.Checked)
//            {
//                cm = new SqlCommand("SELECT Count(-1) FROM " + schema + "." + "dbo" + "." + tableName, cn);
//                if (System.Convert.ToInt32(cm.ExecuteScalar()) > 0)
//                {
//                    RefreshLog("Insert Successful for " + table);
//                    return;
//                }

//            }

//             Make sure the table is empty.
//            cm.Dispose();
//            da.Dispose();
//            cm = new SqlCommand("Truncate table " + schema + "." + "dbo" + "." + tableName, cn);
//            cm.ExecuteNonQuery();


//            if (tableName == "F020_DOCTOR_MSTR")
//            {
//                 Exit if we already loaded the table...
//                if (chkEmptyTablesOnly.Checked)
//                {
//                    cm = new SqlCommand("SELECT Count(-1) FROM " + schema + "." + "dbo" + "." + "F020C_DOC_CLINIC_NEXT_BATCH_NBR", cn);
//                    if (System.Convert.ToInt32(cm.ExecuteScalar()) > 0)
//                        return;
//                }

//                 Make sure the table is empty.
//                cm.Dispose();
//                da.Dispose();
//                cm = new SqlCommand("Truncate table " + schema + "." + "dbo" + "." + "F020C_DOC_CLINIC_NEXT_BATCH_NBR", cn);
//                cm.ExecuteNonQuery();

//                 Exit if we already loaded the table...
//                if (chkEmptyTablesOnly.Checked)
//                {
//                    cm = new SqlCommand("SELECT Count(-1) FROM " + schema + "." + "dbo" + "." + "F020L_DOC_LOCATIONS", cn);
//                    if (System.Convert.ToInt32(cm.ExecuteScalar()) > 0)
//                        return;
//                }

//                 Make sure the table is empty.
//                cm.Dispose();
//                da.Dispose();
//                cm = new SqlCommand("Truncate table " + schema + "." + "dbo" + "." + "F020L_DOC_LOCATIONS", cn);
//                cm.ExecuteNonQuery();
//            }


//            var srcont = true;

//            while (srcont)
//            {
//                 Ensure that the large files load without Out of Memory errors...
//                if (count == 1000)
//                {
//                    chunkCount += count;
//                    count = 0;

//                    RefreshStatus(string.Format("{0:n0}", totalCount) + " records read for " + tableName);
//                    if (rejected > 0)
//                        RefreshRejected(string.Format("{0:n0}", rejected) + " records rejected for " + tableName);

//                     Perform the bulk copy.
//                    PerformBulkCopy(ref dt, database, schema, tableName);

//                    if (dt_doc_clinic_nbr.Rows.Count > 0)
//                    {
//                        PerformBulkCopy(ref dt_doc_clinic_nbr, database, schema, "F020C_DOC_CLINIC_NEXT_BATCH_NBR");
//                    }
//                    if (dt_doc_loc.Rows.Count > 0)
//                    {
//                        PerformBulkCopy(ref dt_doc_loc, database, schema, "F020L_DOC_LOCATIONS");
//                    }
//                    GC.Collect();

//                } // if (count == 250000)

//                count += 1;
//                totalCount += 1;
//                if (!chkPortableSubFile.Checked)
//                    startPosition = 0;


//                if (chkPortableSubFile.Checked)
//                {
//                    if (line == "")
//                        line = sr.ReadLine();
//                }
//                else
//                {
//                    line = sr.ReadLine();
//                }



//                if (tableName.StartsWith("CONSTANTS_MSTR_REC_"))
//                {
//                    if (line.Substring(1, 1) != tableName.Replace("CONSTANTS_MSTR_REC_", ""))
//                    {
//                        count -= 1;
//                        totalCount -= 1;
//                        continue;
//                    }
//                }

//                if (tableName == "F002_OUTSTANDING"
//                    || tableName == "F051_DOC_CASH_MSTR"
//                    || tableName == "F051TP_DOC_CASH_MSTR"
//                     || tableName == "F096_OHIP_PAY_CODE"
//                     || tableName == "F110_COMPENSATION"
//                     || tableName == "F110_COMP_HISTORY"
//                     || tableName == "F113_DEFAULT_COMP"
//                     || tableName == "F119_DOCTOR_YTD")
//                {
//                while (line.StartsWith("\0"))
//                {
//                    line = line.Substring(1);
//                }



//                }


//                line = line.Replace("\0", "");

//                if (line.Replace("\0", "").Trim() == "")
//                {
//                    count -= 1;
//                    totalCount = 1;
//                    continue;
//                }



//                while (line.Length < recordLength)
//                    line = line + " " + sr.ReadLine();

//                if (tableName == "F002_CLAIMS_MSTR_HDR")
//                {
//                    if (!(line.Substring(194, 1) == "B" && line.Substring(205, 5) == "00000" && line.Substring(210, 1) == "0"))
//                    {
//                        count -= 1;
//                        totalCount -= 1;
//                        continue;
//                    }
//                }
//                if (tableName == "F002_CLAIMS_MSTR_DTL")
//                {
//                    if (!(line.Substring(194, 1) == "B" && line.Substring(205, 5) != "00000" && line.Substring(205, 4) != "ZZZZ" && line.Substring(11, 4) != "ZZZZ"))
//                    {
//                        count -= 1;
//                        totalCount -= 1;
//                        continue;
//                    }
//                }
//                if (tableName == "F002_CLAIMS_MSTR_DTL_DESC")
//                {
//                    if (!(line.Substring(194, 1) == "B" && line.Substring(205, 5) != "00000" && line.Substring(205, 4) != "ZZZZ" && line.Substring(11, 4) == "ZZZZ"))
//                    {
//                        count -= 1;
//                        totalCount -= 1;
//                        continue;
//                    }
//                }

//                dt.Rows.Add(CreateNewRowObject(ref dt));

//                if (chkIsDelimited.Checked)
//                    recordArray = SplitLineBasedOnDelimiter(table, line, ar);

//                if (count % 1000 == 0)
//                    RefreshStatus(string.Format("{0:n0}", totalCount) + " records read for " + tableName);

//                try
//                {
//                     Loop through the columns.
//                    for (int i = 0; i <= ar.Length - 1; i++)
//                    {
//                        columnName = ar[i];
//                        column = columns[columnName].ToString().Split('~');
//                        columnName = columnName.Replace("-", "_");
//                        parent = column[(int)items.ParentFlag].Trim();
//                        redefineElement = column[(int)items.RedefinedElement].Trim();
//                        signed = column[(int)items.Signed].Trim();
//                        occurs = 0;

//                         Exceptions (ie. structures, redefines)
//                        if (redefineElement.Length == 0 && parent.Length == 0)
//                        {
//                            size = Convert.ToInt32(column[(int)items.Size]);


//                            if (parentsize > 0)
//                            {
//                                parentChildren.Add(columnName + "~" + signed + "~" + size);
//                                parentsize = parentsize - size;

//                                if (parentsize == 0)
//                                {
//                                    for (int q = 1; q <= parentoccurs; q++)
//                                    {
//                                        foreach (string c in parentChildren)
//                                        {
//                                            columnName = c.Split('~')[0];
//                                            column = columns[columnName].ToString().Split('~');
//                                            columnName = columnName + q.ToString();
//                                            signed = c.Split('~')[1];
//                                            size = Convert.ToInt32(c.Split('~')[2]);

//                                            if (chkIsDelimited.Checked)
//                                                value = recordArray[i];
//                                            else
//                                                value = line.Substring(startPosition, size);

//                                            value = value.TrimEnd();

//                                            AddColumn(ref startPosition, ref size, ref column, ref value, ref numberValue, ref signed, ref dateValue, ref dt, ref columnName, ref factor, ref count);
//                                        }
//                                    }

//                                    parentChildren = new ArrayList();
//                                }


//                            }
//                            else
//                            {
//                                ptable = tableName;
//                                pcolumn = columnName;

//                                if (!string.IsNullOrEmpty(column[(int)items.Occurs].Trim()))
//                                {
//                                    occurs = Convert.ToInt32(column[(int)items.Occurs].Trim());
//                                    if (occurs > 0)
//                                        occurs = occurs * 1;
//                                }

//                                if (occurs == 0)
//                                {
//                                    if (chkPortableSubFile.Checked && (column[(int)items.DataType] == "Zoned" ||
//                                        column[(int)items.DataType] == "Integer"))
//                                    {

//                                        if (column[(int)items.DataType] == "Zoned")
//                                        {
//                                            size += 1;
//                                        }

//                                        if (column[(int)items.DataType] == "Integer")
//                                        {
//                                            size += 1;
//                                            size = size * 2;
//                                        }


//                                        if (chkIsDelimited.Checked)
//                                            value = recordArray[i];
//                                        else
//                                            value = line.Substring(startPosition, size);
//                                    }
//                                    else
//                                    {
//                                        if (chkIsDelimited.Checked)
//                                            value = recordArray[i];
//                                        else
//                                            value = line.Substring(startPosition, size);
//                                    }

//                                    value = value.TrimEnd();


//                                    if (tableName == "F020_DOCTOR_MSTR" && columnName.StartsWith("DOC_CLINIC_NBR"))
//                                    {
//                                        if (value == "00" || value == "" || check_doc_clinic_nbr.Contains(doc_nbr + value))
//                                        {
//                                            startPosition = startPosition + size;
//                                        }
//                                        else
//                                        {
//                                            check_doc_clinic_nbr.Add(doc_nbr + value);

//                                            cm = new SqlCommand("SELECT * FROM " + schema + "." + "dbo" + "." + "F020C_DOC_CLINIC_NEXT_BATCH_NBR" + " WHERE 0 = 1", cn);
//                                            da = new SqlDataAdapter(cm);
//                                            da.Fill(dt_doc_clinic_nbr);

//                                            dt_doc_clinic_nbr.Rows.Add(CreateNewRowObject(ref dt_doc_clinic_nbr));
//                                            count_doc_clinic_nbr = count_doc_clinic_nbr + 1;

//                                            var s = 0;
//                                            var si = 3;
//                                            var cna = "DOC_NBR";
//                                            var col = columns[cna].ToString().Split('~');
//                                            var f = 0;
//                                            var sig = "";
//                                            AddColumn(ref s, ref si, ref col, ref doc_nbr, ref numberValue, ref sig, ref dateValue, ref dt_doc_clinic_nbr, ref cna, ref f, ref count_doc_clinic_nbr);
//                                            columnName = "DOC_CLINIC_NBR";
//                                            AddColumn(ref startPosition, ref size, ref column, ref value, ref numberValue, ref signed, ref dateValue, ref dt_doc_clinic_nbr, ref columnName, ref factor, ref count_doc_clinic_nbr);
//                                        }
//                                    }
//                                    else if (tableName == "F020_DOCTOR_MSTR" && columnName.StartsWith("DOC_LOC"))
//                                    {
//                                        if (value == "" || check_doc_loc.Contains(doc_nbr + value))
//                                        {
//                                            startPosition = startPosition + size;
//                                        }
//                                        else
//                                        {
//                                            check_doc_loc.Add(doc_nbr + value);

//                                            cm = new SqlCommand("SELECT * FROM " + schema + "." + "dbo" + "." + "F020L_DOC_LOCATIONS" + " WHERE 0 = 1", cn);
//                                            da = new SqlDataAdapter(cm);
//                                            da.Fill(dt_doc_loc);

//                                            dt_doc_loc.Rows.Add(CreateNewRowObject(ref dt_doc_loc));
//                                            count_doc_loc = count_doc_loc + 1;


//                                            var s = 0;
//                                            var si = 3;
//                                            var cna = "DOC_NBR";
//                                            var col = columns[cna].ToString().Split('~');
//                                            var f = 0;
//                                            var sig = "";
//                                            AddColumn(ref s, ref si, ref col, ref doc_nbr, ref numberValue, ref sig, ref dateValue, ref dt_doc_loc, ref cna, ref f, ref count_doc_loc);
//                                            columnName = "DOC_LOC";
//                                            AddColumn(ref startPosition, ref size, ref column, ref value, ref numberValue, ref signed, ref dateValue, ref dt_doc_loc, ref columnName, ref factor, ref count_doc_loc);
//                                        }
//                                    }
//                                    else
//                                    {
//                                        AddColumn(ref startPosition, ref size, ref column, ref value, ref numberValue, ref signed, ref dateValue, ref dt, ref columnName, ref factor, ref count);
//                                    }
//                                }
//                                else
//                                {
//                                    for (int q = 1; q <= occurs; q++)
//                                    {
//                                        if (chkPortableSubFile.Checked && column[(int)items.DataType] == "Zoned")
//                                        {
//                                            size += 1;
//                                            if (chkIsDelimited.Checked)
//                                                value = recordArray[i];
//                                            else
//                                                value = line.Substring(startPosition, size);
//                                        }
//                                        else
//                                        {
//                                            if (chkIsDelimited.Checked)
//                                                value = recordArray[i];
//                                            else
//                                                value = line.Substring(startPosition, size);
//                                        }



//                                        value = value.TrimEnd();

//                                        columnName = ar[i] + q.ToString();

//                                        AddColumn(ref startPosition, ref size, ref column, ref value, ref numberValue, ref signed, ref dateValue, ref dt, ref columnName, ref factor, ref count);
//                                    }
//                                }
//                            }

//                        }
//                        else if (parent.Length > 0)
//                        {

//                            if (!string.IsNullOrEmpty(column[(int)items.Occurs].Trim()))
//                            {
//                                occurs = Convert.ToInt32(column[(int)items.Occurs].Trim());
//                                if (occurs > 0)
//                                {
//                                    occurs = occurs * 1;
//                                    parentsize = Convert.ToInt32(column[(int)items.Size]);
//                                    parentoccurs = occurs;

//                                    parentChildren = new ArrayList();
//                                }
//                            }
//                        }

//                        if (tableName == "F020_DOCTOR_MSTR" && columnName == "DOC_NBR")
//                        {

//                            doc_nbr = value;


//                        }

//                    }

//                }
//                catch (Exception ex)
//                {
//                     Write the record to the log file.
//                    LogErrorLine(ex, startPosition - size, logFile, line);

//                    dt.Rows.Remove(dt.Rows[count - 1]);
//                    count -= 1;
//                    rejected += 1;
//                    RefreshRejected(string.Format("{0:n0}", rejected) + " records rejected for " + tableName + Environment.NewLine + line + Environment.NewLine);
//                }

//                sb.Remove(0, sb.Length);

//                srcont = sr.Peek() >= 0;

//                if (chkPortableSubFile.Checked)
//                {
//                    if (startPosition + 1 > line.Length)
//                        srcont = false;
//                    else
//                        srcont = true;
//                }

//            }

//            RefreshStatus(string.Format("{0:n0}", totalCount) + " records read for " + tableName);
//            if (rejected > 0)
//                RefreshRejected(string.Format("{0:n0}", rejected) + " records rejected for " + tableName);

//             Perform the bulk copy.
//            PerformBulkCopy(ref dt, database, schema, tableName);
//            if (dt_doc_clinic_nbr.Rows.Count > 0)
//            {
//                PerformBulkCopy(ref dt_doc_clinic_nbr, database, schema, "F020C_DOC_CLINIC_NEXT_BATCH_NBR");
//            }
//            if (dt_doc_loc.Rows.Count > 0)
//            {
//                PerformBulkCopy(ref dt_doc_loc, database, schema, "F020L_DOC_LOCATIONS");
//            }

//             Perform a final count.
//            string noRecords = string.Empty;
//            cm = new SqlCommand("SELECT Count(-1) FROM " + schema + "." + "dbo" + "." + tableName, cn);
//            noRecords = System.Convert.ToInt32(cm.ExecuteScalar()).ToString();
//            RefreshLog(tableName + ": " + noRecords + " inserted out of " + totalCount.ToString() + " read" + (noRecords == totalCount.ToString() || rejected > 0 ? "" : " ****"));
//            RefreshAdded(string.Format("Copied {0}", string.Format("{0:n0}", noRecords)));
//        }

//        private void AddColumn(ref int startPosition
//            , ref int size
//            , ref string[] column
//            , ref string value
//            , ref decimal? numberValue
//            , ref string signed
//            , ref DateTime? dateValue
//            , ref DataTable dt
//            , ref string columnName
//            , ref int factor
//            , ref int count)
//        {




//            startPosition += size;

//            try
//            {
//                switch (column[(int)items.DataType])
//                {
//                    case "Integer":
//                        if (column[(int)items.DataType] == datatypes.Integer.ToString())
//                        {
//                            if (value.Contains('\0') && value.Trim('\0').Length == 0)
//                            {
//                                numberValue = (decimal?)null;
//                            }
//                            else
//                            {
//                                value = Reverse(value);
//                                if (chkPortableSubFile.Checked)
//                                    numberValue = Convert.ToDecimal(value);
//                                else
//                                    numberValue = AsciiToDecimal(value, signed.ToUpper() == "UNSIGNED");
//                            }
//                        }
//                        break;

//                    case "PHDate":
//                        numberValue = value
//                        dateValue = GetDateFromString(value);
//                        break;
//                    case "VMSDate":
//                        value = Reverse(value);
//                        numberValue = AsciiToDecimal(value, true);
//                        numberValue = numberValue / 10000000;
//                        System.DateTime convertedDate = new DateTime(1858, 11, 17).AddSeconds((double)numberValue);
//                        numberValue = Convert.ToInt32(convertedDate.ToString("yyyyMMdd"));// Convert.ToInt32(string.Format(convertedDate, "yyyyMMdd"));
//                        break;
//                    case "Numeric":
//                    case "Zoned":
//                        if (dt.Columns[columnName].DataType.FullName == "System.DateTime")
//                        {
//                            if (value.Contains('\0') && value.Trim('\0').Length == 0)
//                            {
//                                numberValue = (decimal?)null;
//                            }
//                            else
//                            {
//                                dateValue = GetDateFromString(value);
//                            }
//                        }
//                        else
//                        {
//                            if (value.Contains('\0') && value.Trim('\0').Length == 0)
//                            {
//                                numberValue = (decimal?)null;
//                            }
//                            else
//                            {

//                                if (value.IndexOf("\\u") >= 0)
//                                {
//                                    value = value.Replace("\0", "");
//                                    numberValue = AsciiToDecimal(value, signed.ToUpper() == "UNSIGNED");
//                                }
//                                else
//                                {
//                                    if (chkPortableSubFile.Checked)
//                                        numberValue = Convert.ToDecimal(value);
//                                    else
//                                        numberValue = ConvertZoned(value, signed.ToUpper() == "SIGNED");
//                                }
//                            }
//                        }
//                        break;
//                    case "Character":
//                         Remove the leading/trailing quotes.
//                        if (value.StartsWith("\"") && value.EndsWith("\""))
//                            value = value.Substring(1, value.Length - 2);
//                        value = value.Trim();
//                        break;
//                }

//                if (!string.IsNullOrEmpty(column[(int)items.DecimalPosition]) || !string.IsNullOrEmpty(column[(int)items.InputScale]))
//                {
//                    if (numberValue.HasValue)
//                    {
//                        if (!string.IsNullOrEmpty(column[(int)items.InputScale]))
//                            factor = Convert.ToInt32(column[(int)items.InputScale]);
//                        else
//                            factor = Convert.ToInt32(column[(int)items.DecimalPosition]);
//                        numberValue = (decimal)numberValue / (decimal)(Math.Pow(10, factor));
//                    }
//                }

//                switch (column[(int)items.DataType])
//                {
//                    case "Character":
//                        if (columnName == "TYPE")
//                            dt.Rows[count - 1]["CORE_TYPE"] = value;
//                        else
//                            dt.Rows[count - 1][columnName] = value;
//                        break;
//                    case "Integer":
//                        if (numberValue.HasValue)
//                        {
//                            if (dt.Columns[columnName].DataType.FullName == "System.DateTime")
//                                dt.Rows[count - 1][columnName] = GetDateFromString(numberValue.ToString());
//                            else
//                                dt.Rows[count - 1][columnName] = numberValue.Value;
//                        }
//                        else
//                        {
//                            dt.Rows[count - 1][columnName] = DBNull.Value;
//                        }
//                        break;
//                    case "PHDate":
//                        dt.Rows(count - 1).Item(columnName) = numberValue
//                        if (!(dateValue == null) & !(dateValue == new System.DateTime()) & !(dateValue == System.DateTime.MinValue))
//                            dt.Rows[count - 1][columnName] = dateValue;//numberValue
//                        else
//                            dt.Rows[count - 1][columnName] = DBNull.Value;
//                        break;
//                    case "VMSDate":
//                        if (dt.Columns[columnName].DataType.FullName == "System.DateTime")
//                            dt.Rows[count - 1][columnName] = GetDateFromString(numberValue.ToString());
//                        else
//                            dt.Rows[count - 1][columnName] = numberValue;
//                        break;
//                    case "Numeric":
//                    case "Zoned":
//                        if (dt.Columns[columnName].DataType.FullName == "System.DateTime")
//                        {
//                            if (!(dateValue == null) & !(dateValue == new System.DateTime()) & !(dateValue == System.DateTime.MinValue))
//                            {
//                                dt.Rows[count - 1][columnName] = dateValue;//numberValue
//                            }
//                            else
//                            {
//                                dt.Rows[count - 1][columnName] = DBNull.Value;
//                            }
//                        }
//                        else
//                        {
//                            if (numberValue.HasValue)
//                                dt.Rows[count - 1][columnName] = numberValue;
//                            else
//                                dt.Rows[count - 1][columnName] = DBNull.Value;
//                        }
//                        break;

//                    default:
//                        break;
//                }

//                if (dt.Rows[count - 1][columnName] == DBNull.Value)
//                {

//                }
//            }
//            catch (Exception e)
//            {
//                throw e;
//            }



//        }


//        private void PerformBulkCopy(ref DataTable dt, string database, string schema, string tableName)
//        {
//            SqlBulkCopy bulkCopy = null;

//            try
//            {
//                for (int i = 0; i < dt.Rows.Count; i++)
//                {
//                    if (dt.Rows[i]["LAST_UPDATE_DATE"] == DBNull.Value)
//                        dt.Rows[i]["LAST_UPDATE_DATE"] = (DateTime)SqlDateTime.MinValue;
//                }

//                bulkCopy = new SqlBulkCopy(cn);
//                bulkCopy.BulkCopyTimeout = 1000;
//                bulkCopy.DestinationTableName = schema + "." + "dbo" + "." + tableName;
//                bulkCopy.NotifyAfter = 1000;
//                bulkCopy.SqlRowsCopied += OnSqlRowsCopied;
//                bulkCopy.WriteToServer(dt);
//            }
//            catch (Exception ex)
//            {
//                HandleBcpException(ref bulkCopy, ex, tableName);
//                return;
//            }
//            finally
//            {
//                bulkCopy.Close();
//            }

//            dt.Rows.Clear();
//        }

//        private void LogErrorLine(Exception ex, int position, string logFile, string line)
//        {
//            StreamWriter sw = default(StreamWriter);
//            if (!File.Exists(logFile))
//            {
//                sw = File.CreateText(logFile);
//            }
//            else
//            {
//                sw = File.AppendText(logFile);
//            }
//            sw.WriteLine(ex.Message + " - Column: " + position);
//            sw.WriteLine(line);
//            sw.Flush();
//            sw.Close();
//        }

//        private void HandleBcpException(ref SqlBulkCopy bulkCopy, Exception ex, string tableName)
//        {
//            if (ex.Message.Contains("Received an invalid column length from the bcp client for colid"))
//            {
//                string pattern = @"\d+";
//                Match match = Regex.Match(ex.Message.ToString(), pattern);
//                var index = Convert.ToInt32(match.Value) - 1;

//                FieldInfo fi = typeof(SqlBulkCopy).GetField("_sortedColumnMappings", BindingFlags.NonPublic | BindingFlags.Instance);
//                var sortedColumns = fi.GetValue(bulkCopy);
//                var items = (Object[])sortedColumns.GetType().GetField("_items", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(sortedColumns);

//                FieldInfo itemdata = items[index].GetType().GetField("_metadata", BindingFlags.NonPublic | BindingFlags.Instance);
//                var metadata = itemdata.GetValue(items[index]);

//                var col = metadata.GetType().GetField("column", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).GetValue(metadata);
//                var length = metadata.GetType().GetField("length", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).GetValue(metadata);
//                string err = string.Format("Column: {0} contains data with a length greater than: {1}", col, length);
//            }
//            RefreshLog(tableName + ": " + ex.Message);
//        }

//         This function is used to split the line based on the delimiter.  This function
//         is used instead of Split so that if a string value has a delimiter, we don't 
//         split there (which the Split function would do).
//        private string[] SplitLineBasedOnDelimiter(string tableName, string line, string[] ar)
//        {

//            string[] recordArray = new string[101];
//             Assume 100 columns as worst case scenario
//            string remainingLine = line;
//            int count = 0;
//            int startPosition = 0;
//            int quotePosition = 0;
//            int endQuotePosition = 0;
//            int position = 0;
//            int columnCount = 0;
//            string[] column = null;
//            string columnName = null;
//            int size = 0;
//            string dataType = string.Empty;
//            string value = string.Empty;

//            columnName = ar[0];
//            column = columns[columnName].ToString().Split('~');
//            columnName = columnName.Replace("-", "_");
//            size = Convert.ToInt32(column[(int)items.Size]);
//            dataType = column[(int)items.DataType];

//            position = remainingLine.IndexOf(txtDelimiter.Text);

//            while (position > -1)
//            {
//                if (dataType == datatypes.Character.ToString())
//                {
//                    position = size;
//                    if (remainingLine.Substring(startPosition, 1) == "\"")
//                    {
//                        position = position + 2;
//                         Assume that the size to retrieve will have a start/end quote if a start quote is found.
//                    }
//                }

//                if (position > remainingLine.Length)
//                    return recordArray;

//                recordArray[count] = remainingLine.Substring(startPosition, position);

//                remainingLine = remainingLine.Substring(position + 1).Trim();
//                if (remainingLine.StartsWith(","))
//                    remainingLine = remainingLine.Substring(1).Trim();

//                quotePosition = remainingLine.IndexOf("""")
//                position = remainingLine.IndexOf(txtDelimiter.Text);
//                ' If the quote is before the comma, check for the end quote.
//                ' If the end quote is after the comma, then search for the next comma
//                ' after the end position.
//                Do While quotePosition < position
//                    endQuotePosition = remainingLine.IndexOf("""", quotePosition + 1) ' Get the end quote
//                    If endQuotePosition = quotePosition + 1 Then
//                        endQuotePosition = remainingLine.IndexOf("""", endQuotePosition + 1) ' Get the end quote
//                    End If
//                    quotePosition = endQuotePosition
//                    position = remainingLine.IndexOf(txtDelimiter.Text, quotePosition + 1)
//                    ' If end qoute is less then next comma, exit.
//                    If quotePosition < position Then
//                        Exit Do
//                    End If
//                Loop
//                quotePosition = 0
//                count = count + 1;

//                if (count < ar.Length)
//                {
//                    columnName = ar[count];
//                    column = columns[columnName].ToString().Split('~');
//                    columnName = columnName.Replace("-", "_");
//                    size = Convert.ToInt32(column[(int)items.Size]);
//                    dataType = column[(int)items.DataType];
//                }
//            }

//             Get the last field
//            if (remainingLine.Length > 0)
//            {
//                recordArray[count] = remainingLine.Substring(startPosition);
//            }

//            return recordArray;

//        }

//        private DateTime? GetDateFromString(string value)
//        {
//            if (value.Length == 6)
//            {
//                if (value != "000000")
//                {
//                    if (Convert.ToInt16(value.Substring(0, 2)) > Convert.ToInt16(txtMinimumYearCutoff.Text))
//                        value = "19" + value;
//                    else
//                        value = "20" + value;
//                }
//            }
//            else if (value.Length == 0)
//            {
//                value = "0";
//            }

//            int numberValue = Convert.ToInt32(value);
//            DateTime? dateValue = (DateTime?)null;

//            if (numberValue != 0)
//            {
//                if (numberValue != 0)
//                {
//                    int year = 0;
//                    int month = 0;
//                    int day = 0;

//                    year = Convert.ToInt32(value.Substring(0, 4));
//                    month = Convert.ToInt32(value.Substring(4, 2));
//                    day = Convert.ToInt32(value.Substring(6, 2));

//                    dateValue = new System.DateTime(year, month, day);
//                }
//            }

//            return dateValue;

//        }

//        private decimal ConvertZoned(string value, bool signed = false)
//        {
//            try
//            {
//                int result;
//                if (value.Trim() != "")
//                    result = int.Parse(value.Substring(value.Length - 1, 1));
//            }
//            catch
//            {

//                if (!punch.Contains(ptable + "~" + pcolumn))
//                    punch.Add(ptable + "~" + pcolumn);

//                signed = true;
//            }

//            if (signed)
//            {
//                if (value.Trim() == "")
//                    value = "0";
//                int overpunchDigit = GetOverpunchDigit(value.Substring(value.Length - 1, 1));
//                bool isPositive = GetOverpunchSign(value.Substring(value.Length - 1, 1));

//                if (isPositive)
//                    return Convert.ToDecimal(value.Substring(0, value.Length - 1) + overpunchDigit);
//                else
//                    return Convert.ToDecimal(value.Substring(0, value.Length - 1) + overpunchDigit) * -1;
//            }
//            else
//            {
//                if (!IsNumeric(value))
//                {
//                    decimal decimalValue = 0;
//                    for (int i = 0; i <= value.Length - 1; i++)
//                    {
//                        if (Convert.ToInt32(value.Substring(i, 1)) != 0 && Convert.ToInt32(value.Substring(i, 1)) != 32)
//                        {
//                            decimalValue = Convert.ToDecimal(value);
//                        }
//                    }
//                    decimalValue = AsciiToDecimal(value, true);
//                    return decimalValue;
//                }
//                else
//                {
//                    return Convert.ToDecimal(value);
//                }
//            }
//        }

//        private bool IsNumeric(string value)
//        {
//            double myNum = 0;
//            bool isNumeric = false;

//            if (Double.TryParse(value, out myNum))
//            {
//                isNumeric = true;
//            }

//            return isNumeric;
//        }

//        private void OnSqlRowsCopied(object sender, SqlRowsCopiedEventArgs args)
//        {
//            RefreshAdded(string.Format("Copied {0} so far...", string.Format("{0:n0}", args.RowsCopied)));
//        }
//        protected DataRow CreateNewRowObject(ref DataTable dt)
//        {

//            DataRow drwDataRow = null;
//            int intFieldCount = 0;

//             Create a new row object.
//            drwDataRow = dt.NewRow();

//             Initialize the fields with the appropriate PowerHouse defaults based on data type.
//            for (intFieldCount = 0; intFieldCount <= dt.Columns.Count - 1; intFieldCount++)
//            {
//                switch (dt.Columns[intFieldCount].DataType.ToString())
//                {
//                    case "System.String":
//                        if (dt.Columns[intFieldCount].ColumnName != "ROW_ID")
//                        {
//                            drwDataRow[intFieldCount] = string.Empty;
//                        }
//                        break;
//                    case "System.DateTime":
//                        drwDataRow[intFieldCount] = DBNull.Value;
//                        break;
//                    case "System.Decimal":
//                    case "System.Int16":
//                    case "System.Int32":
//                    case "System.Int64":
//                    case "System.Boolean":
//                    case "System.Double":
//                        drwDataRow[intFieldCount] = 0;
//                        break;
//                }
//                 TODO: Add code to initialize fields that are not of type String, DateTime or Decimal.
//            }
//            TODO: Remove constraints while adding new record in Entry

//            return drwDataRow;

//        }


//        public string Reverse(string Value)
//        {

//            StringBuilder sb = new StringBuilder(string.Empty);

//            for (int i = Value.Length - 1; i >= 0; i += -1)
//            {
//                sb.Append(Value.Substring(i, 1));
//            }

//            return sb.ToString();

//        }
//        private bool IsNegativeNumber(string Value)
//        {
//            return Convert.ToString(Convert.ToInt64(Value, 16), 2).PadLeft((Value.Length / 2) * 4, '0').Substring(0, 1) == "1";
//        }

//        public decimal AsciiToDecimal(string Value, bool Unsigned = false)
//        {
//            byte[] byteArray = null;
//            string hexString = string.Empty;
//            int counter = 0;

//            if (Value.Trim().Length == 0)
//            {
//                return 0m;
//            }
//            else
//            {
//                 Get the byte array using database encoding.
//                byteArray = System.Text.Encoding.Unicode.GetBytes(Value);

//                 Convert to "windows-1250"
//                byteArray = System.Text.Encoding.Convert(System.Text.Encoding.Unicode, System.Text.Encoding.Default, byteArray);

//                 Convert to hex string.
//                for (counter = 0; counter <= byteArray.Length - 1; counter++)
//                {
//                    int valueToConvert = byteArray[counter];
//                    string hexValue = valueToConvert.ToString("X");
//                    hexString += hexValue.PadLeft(2, '0');
//                }

//                if (!Unsigned && IsNegativeNumber(hexString))
//                {
//                    return Convert.ToInt64(hexString, 16); //Val("&h" & hexString)
//                }
//                else
//                {
//                    return Convert.ToInt64(hexString, 16);
//                }
//            }
//        }

//        public Double Val(string value)
//        {
//            String result = String.Empty;
//            foreach (char c in value)
//            {
//                if (Char.IsNumber(c) || (c.Equals('.') && result.Count(x => x.Equals('.')) == 0))
//                    result += c;
//                else if (!c.Equals(' '))
//                    return String.IsNullOrEmpty(result) ? 0 : Convert.ToDouble(result);
//            }
//            return String.IsNullOrEmpty(result) ? 0 : Convert.ToDouble(result);
//        }

//        private int GetOverpunchDigit(string value)
//        {
//            switch (value.ToUpper())
//            {
//                case "{":
//                    return 0;
//                case "A":
//                    return 1;
//                case "B":
//                    return 2;
//                case "C":
//                    return 3;
//                case "D":
//                    return 4;
//                case "E":
//                    return 5;
//                case "F":
//                    return 6;
//                case "G":
//                    return 7;
//                case "H":
//                    return 8;
//                case "I":
//                    return 9;
//                case "}":
//                    return 0;
//                case "J":
//                    return 1;
//                case "K":
//                    return 2;
//                case "L":
//                    return 3;
//                case "M":
//                    return 4;
//                case "N":
//                    return 5;
//                case "O":
//                    return 6;
//                case "P":
//                    return 7;
//                case "Q":
//                    return 8;
//                case "R":
//                    return 9;
//                default:
//                    return 0;
//            }
//        }

//        private bool GetOverpunchSign(string value)
//        {
//            switch (value)
//            {
//                case "{":
//                    return true;
//                case "A":
//                    return true;
//                case "B":
//                    return true;
//                case "C":
//                    return true;
//                case "D":
//                    return true;
//                case "E":
//                    return true;
//                case "F":
//                    return true;
//                case "G":
//                    return true;
//                case "H":
//                    return true;
//                case "I":
//                    return true;
//                case "}":
//                    return false;
//                case "J":
//                    return false;
//                case "K":
//                    return false;
//                case "L":
//                    return false;
//                case "M":
//                    return false;
//                case "N":
//                    return false;
//                case "O":
//                    return false;
//                case "P":
//                    return false;
//                case "Q":
//                    return false;
//                case "R":
//                    return false;
//                default:
//                    return false;
//            }
//        }

//        private byte[] GetBytes(string str)
//        {
//            byte[] bytes = new byte[str.Length * sizeof(char)];
//            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
//            return bytes;
//        }

//        private string ByteToStrArray(byte[] byt)
//        {
//            try
//            {
//                Dim encoding As New System.Text.ASCIIEncoding
//                System.Text.UnicodeEncoding encoding = new System.Text.UnicodeEncoding();

//                return encoding.GetString(byt, 0, byt.GetLength(0));
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }

//        private void RefreshStatus(string Value)
//        {
//            lblStatus.Text = "Status: " + Value;
//            this.Show();
//            this.Refresh();

//        }
//        private void RefreshAdded(string Value)
//        {
//            lblAdded.Text = "Status: " + Value;
//            this.Show();
//            this.Refresh();

//        }
//        private void RefreshRejected(string Value)
//        {
//            this.lblRejected.Text = "Status: " + Value;
//            this.Show();
//            this.Refresh();

//        }

//        private void RefreshLog(string Value)
//        {
//            txtLog.Text += Value + "\r\n";
//            txtLog.SelectionLength = 0;
//            txtLog.SelectionStart = txtLog.Text.Length;
//            txtLog.ScrollToCaret();
//            this.Show();
//            this.Refresh();

//        }
//    }
//}
