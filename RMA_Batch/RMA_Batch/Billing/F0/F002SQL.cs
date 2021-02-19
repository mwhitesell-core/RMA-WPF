
#region "Screen Comments"
#endregion

using Core.DataAccess.SqlServer;
using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;

public class F002SQL : BaseClassControl
{
    private F002SQL m_F002SQL;

    public F002SQL(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
        CONNSTRING = new CoreCharacter("CONNSTRING", 200, this, ResetTypes.ResetAtStartup, ConfigurationManager.AppSettings["ConnectionString10"]);
        PROCESS = new CoreCharacter("PROCESS", 8, this, ResetTypes.ResetAtStartup, Prompt(1).ToString());
    }

    public F002SQL(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
        CONNSTRING = new CoreCharacter("CONNSTRING", 200, this, ResetTypes.ResetAtStartup, ConfigurationManager.AppSettings["ConnectionString10"]);
        PROCESS = new CoreCharacter("PROCESS", 8, this, ResetTypes.ResetAtStartup, Prompt(1).ToString());
    }

    public override void Dispose()
    {
        if ((m_F002SQL != null))
        {
            m_F002SQL.CloseTransactionObjects();
            m_F002SQL = null;
        }
    }

    public F002SQL GetLOAD_F002_SUSPEND_FILES(int Level)
    {
        if (m_F002SQL == null)
        {
            m_F002SQL = new F002SQL("F002SQL", Level);
        }
        else
        {
            m_F002SQL.ResetValues();
        }
        return m_F002SQL;
    }

    #region "Renaissance Architect Migration Services Default Regions"

    protected CoreCharacter CONNSTRING;
    protected CoreCharacter PROCESS;

    private string SCHEMA;

    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"

    private StringBuilder sb = new StringBuilder("");
    private int count;
    private string input_file_location = "";

    private string extractData(string data, string datatype, int start, int size)
    {
        string buf = "";
        string buf2 = "";
        string buf3 = "";
        string return_value = "";

        buf = data.Substring(start, size);

        switch (datatype)
        {
            case "numeric":
                buf2 = buf.Replace(' ', '0');

                if (buf2.IndexOf("?") != -1)
                {
                    for (int i = 0; i < buf.Length; i++)
                    {
                        if (buf2[i] == '?')
                        {
                            buf3 += '0';
                        }
                        else
                            buf3 += buf[i];
                    }
                    return_value = buf3;
                }
                else
                    return_value = Convert.ToInt64(buf2).ToString();
                break;

            case "string":
                if (buf.IndexOf("'") != -1)
                {
                    for (int i = 0; i < buf.Length; i++)
                    {
                        if (buf[i] == '\'')
                        {
                            buf2 += '\'';
                            buf2 += '\'';
                        }
                        else
                            buf2 += buf[i];
                    }
                    return_value = buf2;
                }
                else
                    return_value = buf;
                break;

            default:
                break;
        }

        return return_value;
    }

    private bool LoadF002_SUSPEND_HDR()
    {
        try
        {
            string f002HdrFilename = "f002_suspend_hdr.dat";
            var sql = new StringBuilder("");
            var sql_all = new StringBuilder("");

            if (!File.Exists(Directory.GetCurrentDirectory() + "/" + f002HdrFilename))
            {
                var ex = new Exception("File: " + f002HdrFilename + " does not exist!");
                throw ex;
            }

            sql = new StringBuilder("");
            sql_all = new StringBuilder("");

            input_file_location = Directory.GetCurrentDirectory();

            sql.Append(" TRUNCATE TABLE [" + SCHEMA + "].[F002_SUSPEND_HDR] ");

            try
            {
                var updated = SqlHelper.ExecuteNonQuery(CONNSTRING.Value.Trim(), CommandType.Text, sql.ToString());
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            var sr = new StreamReader(Directory.GetCurrentDirectory() + "/" + f002HdrFilename);
            var line = sr.ReadLine();
            string buf = "";

            count = 0;

            int error_flag = 0;
            string debug_info = "";
            int error_position = 0;
            string error_column = "";
            int len = 0;
            int first_char = 0;

            while (line != null)
            {
                error_flag = 0;
                debug_info = "";
                error_position = 0;
                error_column = "";
                len = line.Length;

                // Break if null found. Last records usually have no data or filled with NULL \0 characters. Checj the first byte. If it is null (0), skip the record
                byte[] asciiBytes = Encoding.ASCII.GetBytes(line);
                first_char = asciiBytes[0];
                if (first_char == 0)
                    break;

                len = line.Length;

                if (len != 317 && len != 318 && len != 1086)
                {
                    var ex = new Exception("File: " + f002HdrFilename + " record length is not 317 bytes. Critical error!");
                    throw ex;
                }

                sql = new StringBuilder("INSERT INTO [" + SCHEMA +"].[F002_SUSPEND_HDR](" +
                    "[CLMHDR_BATCH_NBR]" +
                    ",[CLMHDR_CLINIC_NBR_1_2]" +
                    ",[CLMHDR_DOC_NBR]" +
                    ",[CLMHDR_WEEK]" +
                    ",[CLMHDR_DAY]" +
                    ",[CLMHDR_CLAIM_NBR]" +
                    ",[CLMHDR_ADJ_OMA_CD]" +
                    ",[CLMHDR_ADJ_OMA_SUFF]" +
                    ",[CLMHDR_ADJ_ADJ_NBRF]" +
                    ",[CLMHDR_BATCH_TYPE]" +
                    ",[CLMHDR_ADJ_CD_SUB_TYPE]" +
                    ",[CLMHDR_DOC_NBR_OHIP]" +
                    ",[CLMHDR_DOC_SPEC_CD]" +
                    ",[CLMHDR_REFER_DOC_NBR]" +
                    ",[CLMHDR_DIAG_CD]" +
                    ",[CLMHDR_LOC]" +
                    ",[CLMHDR_HOSP]" +
                    ",[CLMHDR_AGENT_CD]" +
                    ",[CLMHDR_ADJ_CD]" +
                    ",[CLMHDR_TAPE_SUBMIT_IND]" +
                    ",[CLMHDR_I_O_PAT_IND]" +
                    ",[CLMHDR_PAT_KEY_TYPE]" +
                    ",[CLMHDR_PAT_KEY_DATA]" +
                    ",[CLMHDR_PAT_ACRONYM6]" +
                    ",[CLMHDR_PAT_ACRONYM3]" +
                    ",[CLMHDR_REFERENCE]" +
                    ",[CLMHDR_DATE_ADMIT]" +
                    ",[CLMHDR_DOC_DEPT]" +
                    ",[CLMHDR_MSG_NBR]" +
                    ",[CLMHDR_REPRINT_FLAG]" +
                    ",[CLMHDR_SUB_NBR]" +
                    ",[CLMHDR_AUTO_LOGOUT]" +
                    ",[CLMHDR_FEE_COMPLEX]" +
                    ",[FILLER]" +
                    ",[CLMHDR_CURR_PAYMENT]" +
                    ",[CLMHDR_DATE_PERIOD_END]" +
                    ",[CLMHDR_CYCLE_NBR]" +
                    ",[CLMHDR_DATE_SYS]" +
                    ",[CLMHDR_AMT_TECH_BILLED]" +
                    ",[CLMHDR_AMT_TECH_PAID]" +
                    ",[CLMHDR_TOT_CLAIM_AR_OMA]" +
                    ",[CLMHDR_TOT_CLAIM_AR_OHIP]" +
                    ",[CLMHDR_MANUAL_AND_TAPE_PAYMENTS]" +
                    ",[CLMHDR_STATUS_OHIP]" +
                    ",[CLMHDR_ORIG_BATCH_NBR]" +
                    ",[CLMHDR_ORIG_CLAIM_NBR]" +
                    ",[CLMHDR_STATUS]" +
                    ",[CLMHDR_HEALTH_CARE_NBR]" +
                    ",[CLMHDR_HEALTH_CARE_VER]" +
                    ",[CLMHDR_HEALTH_CARE_PROV]" +
                    ",[CLMHDR_RELATIONSHIP]" +
                    ",[CLMHDR_PATIENT_SURNAME]" +
                    ",[CLMHDR_SUBSCR_INITIALS]" +
                    ",[CLMHDR_WCB_CLAIM_NBR]" +
                    ",[CLMHDR_WCB_ACCIDENT_DATE]" +
                    ",[CLMHDR_WCB_EMPLOYER_NAME_ADDR]" +
                    ",[CLMHDR_WCB_EMPLOYER_POSTAL_CODE]" +
                    ",[CLMHDR_CONFIDENTIAL_FLAG]" +
                    ",[CLMHDR_NBR_SUSPEND_DESC_RECS]" +
                    ",[FILLER2]" +
                    ",[CLMHDR_DOC_OHIP_NBR]" +
                    ",[CLMHDR_ACCOUNTING_NBR]" +
                    ",[SUSP_HDR_DOC_NBR]" +
                    ",[SUSP_HDR_CLINIC_NBR]" +
                    ",[SUSP_HDR_ACRONYM]" +
                    ",[SUSP_HDR_ACCOUNTING_NBR]" +
                    ",[ERROR_FLAG]" +
                    ",[DEBUG_INFO]" +
                    ",[INPUT_FILE_LOCATION])" +
                    " VALUES (");

                buf = extractData(line, "string", 0, 8);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // CLMHDR_BATCH_NBR

                buf = extractData(line, "numeric", 0, 2);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // CLMHDR_CLINIC_NBR_1_2

                buf = extractData(line, "string", 2, 3);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // CLMHDR_DOC_NBR

                buf = extractData(line, "numeric", 5, 2);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // CLMHDR_WEEK

                buf = extractData(line, "numeric", 7, 1);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // CLMHDR_DAY

                buf = extractData(line, "numeric", 8, 2);
                sql.Append("").Append(buf.ToString()).Append(",");                   // CLMHDR_CLAIM_NBR (num)

                buf = extractData(line, "string", 10, 4);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // CLMHDR_ADJ_OMA_CD

                buf = extractData(line, "string", 14, 1);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // CLMHDR_ADJ_OMA_SUFF

                buf = extractData(line, "string", 15, 1);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // CLMHDR_ADJ_ADJ_NBRF

                buf = extractData(line, "string", 16, 1);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // CLMHDR_BATCH_TYPE

                buf = extractData(line, "string", 17, 1);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // CLMHDR_ADJ_CD_SUB_TYPE

                buf = extractData(line, "numeric", 18, 6);
                sql.Append("").Append(buf.ToString()).Append(",");                   // CLMHDR_DOC_NBR_OHIP (num)

                // ******************************************************************
                // Check for ? in field. Indicates an error that needs to be flagged
                // ******************************************************************
                if (line.Substring(24, 1).Equals("?"))
                {
                    error_flag = 1;
                    error_position = 24;
                    error_column = "CLMHDR_DOC_SPEC_CD";
                }
                buf = extractData(line, "numeric", 24, 2);
                sql.Append("").Append(buf.ToString()).Append(",");                   // ?? CLMHDR_DOC_SPEC_CD (num)

                // ******************************************************************
                // Check for ? in field. Indicates an error that needs to be flagged
                // ******************************************************************
                if (line.Substring(26, 1).Equals("?"))
                {
                    error_flag = 1;
                    error_position = 26;
                    error_column = "CLMHDR_REFER_DOC_NBR";
                }
                buf = extractData(line, "numeric", 26, 6);
                sql.Append("").Append(buf.ToString()).Append(",");                   // ?? CLMHDR_REFER_DOC_NBR (num)

                // ******************************************************************
                // Check for ? in field. Indicates an error that needs to be flagged
                // ******************************************************************
                if (line.Substring(32, 1).Equals("?"))
                {
                    error_flag = 1;
                    error_position = 32;
                    error_column = "CLMHDR_DIAG_CD";
                }
                buf = extractData(line, "numeric", 32, 3);
                sql.Append("").Append(buf.ToString()).Append(",");                   // ?? CLMHDR_DIAG_CD (num)

                // ******************************************************************
                // Check for ? in field. Indicates an error that needs to be flagged
                // ******************************************************************
                if (line.Substring(35, 1).Equals("?"))
                {
                    error_flag = 1;
                    error_position = 35;
                    error_column = "CLMHDR_LOC";
                }
                buf = extractData(line, "string", 35, 4);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // ?? CLMHDR_LOC

                // ******************************************************************
                // Check for ? in field. Indicates an error that needs to be flagged
                // ******************************************************************
                if (line.Substring(39, 1).Equals("?"))
                {
                    error_flag = 1;
                    error_position = 39;
                    error_column = "CLMHDR_HOSP";
                }
                buf = extractData(line, "string", 39, 1);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // ?? CLMHDR_HOSP   (REALLY CLMHDR_PAYROLL)

                // ******************************************************************
                // Check for ? in field. Indicates an error that needs to be flagged
                // ******************************************************************
                if (line.Substring(40, 1).Equals("?"))
                {
                    error_flag = 1;
                    error_position = 40;
                    error_column = "CLMHDR_AGENT_CD";
                }
                buf = extractData(line, "numeric", 40, 1);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // ?? CLMHDR_AGENT_CD

                buf = extractData(line, "string", 41, 1);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // CLMHDR_ADJ_CD

                buf = extractData(line, "string", 42, 1);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // CLMHDR_TAPE_SUBMIT_IND

                // ******************************************************************
                // Check for ? in field. Indicates an error that needs to be flagged
                // ******************************************************************
                if (line.Substring(43, 1).Equals("?"))
                {
                    error_flag = 1;
                    error_position = 43;
                    error_column = "CLMHDR_I_O_PAT_IND";
                }
                buf = extractData(line, "string", 43, 1);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // ?? CLMHDR_I_O_PAT_IND

                // ******************************************************************
                // Check for ? in field. Indicates an error that needs to be flagged
                // ******************************************************************
                if (line.Substring(44, 1).Equals("?"))
                {
                    error_flag = 1;
                    error_position = 44;
                    error_column = "CLMHDR_PAT_KEY_TYPE";
                }
                buf = extractData(line, "string", 44, 1);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // ?? CLMHDR_PAT_KEY_TYPE

                buf = extractData(line, "string", 45, 15);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // CLMHDR_PAT_KEY_DATA

                buf = extractData(line, "string", 60, 6);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // CLMHDR_PAT_ACRONYM6

                buf = extractData(line, "string", 66, 3);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // CLMHDR_PAT_ACRONYM3

                buf = extractData(line, "string", 69, 11);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // CLMHDR_REFERENCE

                // ******************************************************************
                // Check for ? in field. Indicates an error that needs to be flagged
                // ******************************************************************
                if (line.Substring(80, 1).Equals("?"))
                {
                    error_flag = 1;
                    error_position = 80;
                    error_column = "CLMHDR_DATE_ADMIT";
                }
                buf = extractData(line, "string", 80, 8);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // ?? CLMHDR_DATE_ADMIT

                buf = extractData(line, "numeric", 88, 2);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // CLMHDR_DOC_DEPT

                // ******************************************************************
                // Check for ? in field. Indicates an error that needs to be flagged
                // ******************************************************************
                if (line.Substring(90, 1).Equals("?"))
                {
                    error_flag = 1;
                    error_position = 90;
                    error_column = "CLMHDR_MSG_NBR";
                }
                buf = extractData(line, "string", 90, 2);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // ?? CLMHDR_MSG_NBR

                // ******************************************************************
                // Check for ? in field. Indicates an error that needs to be flagged
                // ******************************************************************
                if (line.Substring(92, 1).Equals("?"))
                {
                    error_flag = 1;
                    error_position = 92;
                    error_column = "CLMHDR_REPRINT_FLAG";
                }
                buf = extractData(line, "string", 92, 1);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // ?? CLMHDR_REPRINT_FLAG

                // ******************************************************************
                // Check for ? in field. Indicates an error that needs to be flagged
                // ******************************************************************
                if (line.Substring(93, 1).Equals("?"))
                {
                    error_flag = 1;
                    error_position = 93;
                    error_column = "CLMHDR_SUB_NBR";
                }
                buf = extractData(line, "string", 93, 1);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // ?? CLMHDR_SUB_NBR

                // ******************************************************************
                // Check for ? in field. Indicates an error that needs to be flagged
                // ******************************************************************
                if (line.Substring(94, 1).Equals("?"))
                {
                    error_flag = 1;
                    error_position = 94;
                    error_column = "CLMHDR_AUTO_LOGOUT";
                }
                buf = extractData(line, "string", 94, 1);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // ?? CLMHDR_AUTO_LOGOUT

                // ******************************************************************
                // Check for ? in field. Indicates an error that needs to be flagged
                // ******************************************************************
                if (line.Substring(95, 1).Equals("?"))
                {
                    error_flag = 1;
                    error_position = 95;
                    error_column = "CLMHDR_FEE_COMPLEX";
                }
                buf = extractData(line, "string", 95, 1);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // ?? CLMHDR_FEE_COMPLEX

                buf = extractData(line, "string", 96, 2);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // FILLER

                buf = extractData(line, "numeric", 98, 7);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // CLMHDR_CURR_PAYMENT

                buf = extractData(line, "numeric", 105, 8);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // CLMHDR_DATE_PERIOD_END

                buf = extractData(line, "numeric", 113, 2);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // CLMHDR_CYCLE_NBR

                buf = extractData(line, "string", 115, 8);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // CLMHDR_DATE_SYS

                buf = extractData(line, "numeric", 123, 6);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // CLMHDR_AMT_TECH_BILLED

                buf = extractData(line, "numeric", 129, 6);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // CLMHDR_AMT_TECH_PAID

                buf = extractData(line, "numeric", 135, 7);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // CLMHDR_TOT_CLAIM_AR_OMA

                buf = extractData(line, "numeric", 142, 7);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // CLMHDR_TOT_CLAIM_AR_OHIP

                buf = extractData(line, "numeric", 149, 7);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // CLMHDR_MANUAL_AND_TAPE_PAYMENTS

                buf = extractData(line, "string", 156, 2);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // CLMHDR_STATUS_OHIP

                buf = extractData(line, "string", 158, 8);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // CLMHDR_ORIG_BATCH_NBR

                buf = extractData(line, "numeric", 166, 2);
                sql.Append("").Append(buf.ToString()).Append(",");                   // CLMHDR_ORIG_CLAIM_NBR

                buf = extractData(line, "string", 168, 1);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // CLMHDR_STATUS

                buf = extractData(line, "string", 169, 12);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // CLMHDR_HEALTH_CARE_NBR

                buf = extractData(line, "string", 181, 2);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // CLMHDR_HEALTH_CARE_VER

                buf = extractData(line, "string", 183, 2);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // CLMHDR_HEALTH_CARE_PROV

                buf = extractData(line, "string", 185, 1);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // CLMHDR_RELATIONSHIP

                buf = extractData(line, "string", 186, 25);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // CLMHDR_PATIENT_SURNAME

                buf = extractData(line, "string", 211, 3);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // CLMHDR_SUBSCR_INITIALS

                buf = extractData(line, "string", 214, 9);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // CLMHDR_WCB_CLAIM_NBR

                buf = extractData(line, "numeric", 223, 8);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // CLMHDR_WCB_ACCIDENT_DATE

                buf = extractData(line, "string", 231, 40);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // CLMHDR_WCB_EMPLOYER_NAME_ADDR

                buf = extractData(line, "string", 271, 6);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // CLMHDR_WCB_EMPLOYER_POSTAL_CODE

                buf = extractData(line, "string", 277, 1);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // CLMHDR_CONFIDENTIAL_FLAG

                buf = extractData(line, "numeric", 278, 2);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // CLMHDR_NBR_SUSPEND_DESC_RECS

                buf = extractData(line, "string", 280, 1);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // FILLER2

                buf = extractData(line, "numeric", 281, 6);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // CLMHDR_DOC_OHIP_NBR

                buf = extractData(line, "string", 287, 8).Trim();
                sql.Append("'").Append(buf.ToString()).Append("',");                 // CLMHDR_ACCOUNTING_NBR

                buf = extractData(line, "string", 295, 3);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // SUSP_HDR_DOC_NBR

                buf = extractData(line, "numeric", 298, 2);
                sql.Append("").Append(buf.ToString()).Append(",");                   // SUSP_HDR_CLINIC_NBR (num)

                buf = extractData(line, "string", 300, 9);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // SUSP_HDR_ACRONYM

                buf = extractData(line, "string", 309, 8);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // SUSP_HDR_ACCOUNTING_NBR

                if (error_flag == 0 && line.IndexOf('?') != -1)
                {
                    error_position = line.IndexOf('?');
                    debug_info = "WARNING. An ? was found on line " + count + " at position " + error_position.ToString() + ": " + line;
                }

                if (error_flag == 1)
                {
                    debug_info = "ERROR. An error was found on line " + count + " at position " + error_position.ToString() + "(" + error_column + ")" + ": " + line;
                }

                sql.Append("'").Append(error_flag.ToString()).Append("',");          // ERROR_FLAG
                sql.Append("'").Append(debug_info.ToString()).Append("',");          // DEBUG_INFO
                sql.Append("'").Append(input_file_location.ToString()).Append("'");  // INPUT_FILE_LOCATION

                sql.Append(")");

                try
                {
                    var updated = SqlHelper.ExecuteNonQuery(CONNSTRING.Value.Trim(), CommandType.Text, sql.ToString());
                    sql_all.Append(sql);
                    count += 1;
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                line = sr.ReadLine();
            }

            return true;
        }

        catch (CustomApplicationException ex)
        {
            WriteError(ex);
            return false;
        }

        catch (Exception ex)
        {
            WriteError(ex);
            return false;
        }

        finally
        {
            var ex = new Exception(" Inserted " + count + " records into F002_SUSPEND_HDR");
            Console.WriteLine(ex.Message);
        }
    }

    private bool LoadF002_SUSPEND_DTL()
    {
        try
        {
            string f002DtlFilename = "f002_suspend_dtl.dat";
            var sql = new StringBuilder("");
            var sql_all = new StringBuilder("");

            if (!File.Exists(Directory.GetCurrentDirectory() + "/" + f002DtlFilename))
            {
                var ex = new Exception("File: " + f002DtlFilename + " does not exist!");
                throw ex;
            }

            sql = new StringBuilder("");
            sql_all = new StringBuilder("");

            input_file_location = Directory.GetCurrentDirectory();

            sql.Append(" TRUNCATE TABLE [" + SCHEMA + "].[F002_SUSPEND_DTL] ");

            try
            {
                var updated = SqlHelper.ExecuteNonQuery(CONNSTRING.Value.Trim(), CommandType.Text, sql.ToString());
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            var sr = new StreamReader(Directory.GetCurrentDirectory() + "/" + f002DtlFilename);
            var line = sr.ReadLine();
            string buf = "";

            int error_flag = 0;
            string debug_info = "";
            int error_position = 0;
            string error_column = "";
            int len = 0;
            int first_char = 0;

            count = 0;

            while (line != null)
            {
                error_flag = 0;
                debug_info = "";
                error_position = 0;
                error_column = "";

                len = line.Length;

                // Break on bad records. Last records usually have no data or filled with NULL \0 characters. Checj the first byte. If it is null (0), skip the record
                byte[] asciiBytes = Encoding.ASCII.GetBytes(line);
                first_char = asciiBytes[0];
                if (first_char == 0)
                    break;

                if (line.Length != 92)
                {
                    var ex = new Exception("File: " + f002DtlFilename + " record length is not 92 bytes. Critical error!");
                    throw ex;
                }

                sql = new StringBuilder("INSERT INTO [" + SCHEMA + "].[F002_SUSPEND_DTL](" +
                    " [CLMDTL_BATCH_NBR]" +
                    ",[CLMDTL_CLAIM_NBR]" +
                    ",[CLMDTL_OMA_CD]" +
                    ",[CLMDTL_OMA_SUFF]" +
                    ",[CLMDTL_ADJ_NBR]" +
                    ",[CLMDTL_REV_GROUP_CD]" +
                    ",[CLMDTL_AGENT_CD]" +
                    ",[CLMDTL_ADJ_CD]" +
                    ",[CLMDTL_NBR_SERV]" +
                    ",[CLMDTL_SV_YY]" +
                    ",[CLMDTL_SV_MM]" +
                    ",[CLMDTL_SV_DD]" +
                    ",[CLMDTL_CONSEC_DATES_R]" +
                    ",[CLMDTL_AMT_TECH_BILLED]" +
                    ",[CLMDTL_FEE_OMA]" +
                    ",[CLMDTL_FEE_OHIP]" +
                    ",[CLMDTL_DATE_PERIOD_END]" +
                    ",[CLMDTL_CYCLE_NBR]" +
                    ",[CLMDTL_DIAG_CD]" +
                    ",[CLMDTL_DIAG_CD_LOCAL]" +
                    ",[CLMDTL_STATUS]" +
                    ",[CLMDTL_DOC_OHIP_NBR]" +
                    ",[CLMDTL_ACCOUNTING_NBR]" +
                    ",[ERROR_FLAG]" +
                    ",[DEBUG_INFO]" +
                    ",[INPUT_FILE_LOCATION])" +
                    " VALUES (");

                buf = extractData(line, "string", 0, 8);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // CLMDTL_BATCH_NBR

                buf = extractData(line, "numeric", 8, 2);
                sql.Append("").Append(buf.ToString()).Append(",");                   // CLMDTL_CLAIM_NBR

                // ******************************************************************
                // Check for ? in field. Indicates an error that needs to be flagged
                // ******************************************************************
                if (line.Substring(10, 1).Equals("?"))
                {
                    error_flag = 1;
                    error_position = 10;
                    error_column = "CLMDTL_OMA_CD";
                }
                buf = extractData(line, "string", 10, 4);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // ?? CLMDTL_OMA_CD    

                // ******************************************************************
                // Check for ? in field. Indicates an error that needs to be flagged
                // ******************************************************************
                if (line.Substring(14, 1).Equals("?"))
                {
                    error_flag = 1;
                    error_position = 14;
                    error_column = "CLMDTL_OMA_SUFF";
                }
                buf = extractData(line, "string", 14, 1);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // ?? CLMDTL_OMA_SUFF

                buf = extractData(line, "numeric", 15, 1);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // CLMDTL_ADJ_NBR

                buf = extractData(line, "string", 16, 3);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // CLMDTL_REV_GROUP_CD

                // ******************************************************************
                // Check for ? in field. Indicates an error that needs to be flagged
                // ******************************************************************
                if (line.Substring(19, 1).Equals("?"))
                {
                    error_flag = 1;
                    error_position = 19;
                    error_column = "CLMDTL_AGENT_CD";
                }
                buf = extractData(line, "numeric", 19, 1);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // ?? CLMDTL_AGENT_CD

                buf = extractData(line, "string", 20, 1);
                sql.Append("'").Append(buf.ToString()).Append("',");                 //  CLMDTL_ADJ_CD

                // ******************************************************************
                // Check for ? in field. Indicates an error that needs to be flagged
                // ******************************************************************
                if (line.Substring(19, 1).Equals("?"))
                {
                    error_flag = 1;
                    error_position = 19;
                    error_column = "CLMDTL_NBR_SERV";
                }
                buf = extractData(line, "numeric", 21, 2);
                sql.Append("").Append(buf.ToString()).Append(",");                   //  ?? CLMDTL_NBR_SERV

                // ******************************************************************
                // Check for ? in field. Indicates an error that needs to be flagged
                // ******************************************************************
                if (line.Substring(23, 1).Equals("?"))
                {
                    error_flag = 1;
                    error_position = 23;
                    error_column = "CLMDTL_SV_YY";
                }
                buf = extractData(line, "numeric", 23, 4);
                sql.Append("").Append(buf.ToString()).Append(",");                   //  ?? CLMDTL_SV_YY

                // ******************************************************************
                // Check for ? in field. Indicates an error that needs to be flagged
                // ******************************************************************
                if (line.Substring(27, 1).Equals("?"))
                {
                    error_flag = 1;
                    error_position = 27;
                    error_column = "CLMDTL_SV_MM";
                }
                buf = extractData(line, "numeric", 27, 2);
                sql.Append("").Append(buf.ToString()).Append(",");                   //  ?? CLMDTL_SV_MM

                // ******************************************************************
                // Check for ? in field. Indicates an error that needs to be flagged
                // ******************************************************************
                if (line.Substring(29, 1).Equals("?"))
                {
                    error_flag = 1;
                    error_position = 29;
                    error_column = "CLMDTL_SV_DD";
                }
                buf = extractData(line, "numeric", 29, 2);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // ?? CLMDTL_SV_DD

                // ******************************************************************
                // Check for ? in field. Indicates an error that needs to be flagged
                // ******************************************************************
                if (line.Substring(31, 1).Equals("?"))
                {
                    error_flag = 1;
                    error_position = 31;
                    error_column = "CLMDTL_CONSEC_DATES_R";
                }
                buf = extractData(line, "string", 31, 9);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // ?? CLMDTL_CONSEC_DATES_R

                buf = extractData(line, "numeric", 40, 6);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // CLMDTL_AMT_TECH_BILLED

                // ******************************************************************
                // Check for ? in field. Indicates an error that needs to be flagged
                // ******************************************************************
                if (line.Substring(46, 1).Equals("?"))
                {
                    error_flag = 1;
                    error_position = 46;
                    error_column = "CLMDTL_FEE_OMA";
                }
                buf = extractData(line, "numeric", 46, 7);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // ?? CLMDTL_FEE_OMA

                // ******************************************************************
                // Check for ? in field. Indicates an error that needs to be flagged
                // ******************************************************************
                if (line.Substring(53, 1).Equals("?"))
                {
                    error_flag = 1;
                    error_position = 53;
                    error_column = "CLMDTL_FEE_OHIP";
                }
                buf = extractData(line, "numeric", 53, 7);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // ?? CLMDTL_FEE_OHIP

                buf = extractData(line, "string", 60, 8);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // CLMDTL_DATE_PERIOD_END

                buf = extractData(line, "numeric", 68, 3);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // CLMDTL_CYCLE_NBR

                // ******************************************************************
                // Check for ? in field. Indicates an error that needs to be flagged
                // ******************************************************************
                if (line.Substring(71, 1).Equals("?"))
                {
                    error_flag = 1;
                    error_position = 71;
                    error_column = "CLMDTL_DIAG_CD";
                }
                buf = extractData(line, "numeric", 71, 3);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // ?? CLMDTL_DIAG_CD

                buf = extractData(line, "numeric", 74, 3);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // CLMDTL_DIAG_CD_LOCAL

                buf = extractData(line, "string", 77, 1);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // CLMDTL_STATUS

                buf = extractData(line, "numeric", 78, 6);
                sql.Append("'").Append(buf.ToString()).Append("',");                 // CLMDTL_DOC_OHIP_NBR

                buf = extractData(line, "string", 84, 8).Trim();
                sql.Append("'").Append(buf.ToString()).Append("',");                 // CLMDTL_ACCOUNTING_NBR


                if (error_flag == 0 && line.IndexOf('?') != -1)
                {
                    error_position = line.IndexOf('?');
                    debug_info = "WARNING. An ? was found on line " + count + " at position " + error_position.ToString() + ": " + line;
                }

                if (error_flag == 1)
                {
                    debug_info = "ERROR. An ? was found on line " + count + " at position " + error_position.ToString() + "(" + error_column + ")" + ": " + line;
                }

                sql.Append("'").Append(error_flag.ToString()).Append("',");          // ERROR_FLAG
                sql.Append("'").Append(debug_info.ToString()).Append("',");          // DEBUG_INFO
                sql.Append("'").Append(input_file_location.ToString()).Append("'");  // INPUT_FILE_LOCATION

                sql.Append(")");

                try
                {
                    var updated = SqlHelper.ExecuteNonQuery(CONNSTRING.Value.Trim(), CommandType.Text, sql.ToString());
                    sql_all.Append(sql);
                    count += 1;
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                line = sr.ReadLine();
            }

            return true;
        }

        catch (CustomApplicationException ex)
        {
            WriteError(ex);
            return false;
        }

        catch (Exception ex)
        {
            WriteError(ex);
            return false;
        }

        finally
        {
            var ex = new Exception(" Inserted " + count + " records into F002_SUSPEND_DTL");
            Console.WriteLine(ex.Message);
        }
    }

    private bool LoadF002_SUSPEND_DESC()
    {
        bool found = true;

        string tmpCLMDTL_SUSPEND_DESC = string.Empty;
        string tmpCLMDTL_STATUS = string.Empty;
        string tmpCLMDTL_DOC_OHIP_NBR = string.Empty;
        string tmpCLMDTL_ACCOUNTING_NBR = string.Empty;
        string tmpCLMDTL_LINE_NO = string.Empty;
        string tmpLine = string.Empty;

        int start = 0;
        int end = 0;
        int charcnt = 0;

        try
        {
            string f002DtlFilename = "f002_suspend_desc.dat";
            var sql = new StringBuilder("");
            var sql_all = new StringBuilder("");

            if (!File.Exists(Directory.GetCurrentDirectory() + "/" + f002DtlFilename))
            {
                found = false;
                return false;
            }

            sql = new StringBuilder("");
            sql_all = new StringBuilder("");

            input_file_location = Directory.GetCurrentDirectory();

            sql.Append(" TRUNCATE TABLE [" + SCHEMA + "].[F002_SUSPEND_DESC] ");

            try
            {
                var updated = SqlHelper.ExecuteNonQuery(CONNSTRING.Value.Trim(), CommandType.Text, sql.ToString());
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            var sr = new StreamReader(Directory.GetCurrentDirectory() + "/" + f002DtlFilename);
            var line = sr.ReadLine();
            string buf = "";

            int error_flag = 0;
            string debug_info = "";
            int len = 0;
            int first_char = 0;

            count = 0;

            while (line != null)
            {
                error_flag = 0;
                debug_info = "";

                len = line.Length;

                tmpCLMDTL_SUSPEND_DESC = string.Empty;
                tmpCLMDTL_STATUS = string.Empty;
                tmpCLMDTL_DOC_OHIP_NBR = "0";
                tmpCLMDTL_ACCOUNTING_NBR = string.Empty;
                tmpCLMDTL_LINE_NO = "0";
                tmpLine = string.Empty;

                // Break on bad records. Last records usually have no data or filled with NULL \0 characters. Check the first byte. If it is null (0), skip the record
                byte[] asciiBytes = Encoding.ASCII.GetBytes(line);
                first_char = asciiBytes[0];
                if (first_char != 0)
                {
                    if (len < 87)
                    {
                        charcnt = 0;

                        while (true)
                        {
                            if (charcnt + line.Length < 87)
                            {
                                tmpLine += line + "┬┬";
                                charcnt += line.Length + 2;
                                line = sr.ReadLine();
                            }
                            else
                            {
                                tmpLine += line;
                                break;
                            }
                        }

                        tmpCLMDTL_SUSPEND_DESC = extractData(tmpLine, "string", 0, 70);
                        tmpCLMDTL_STATUS = extractData(tmpLine, "string", 70, 1);
                        tmpCLMDTL_DOC_OHIP_NBR = extractData(tmpLine, "numeric", 71, 6);
                        tmpCLMDTL_ACCOUNTING_NBR = extractData(tmpLine, "string", 77, 8).Trim();
                        tmpCLMDTL_LINE_NO = extractData(tmpLine, "numeric", 85, 2);

                        sql = new StringBuilder("INSERT INTO [" + SCHEMA + "].[F002_SUSPEND_DESC](" +
                            " [CLMDTL_SUSPEND_DESC]" +
                            ",[CLMDTL_STATUS]" +
                            ",[CLMDTL_DOC_OHIP_NBR]" +
                            ",[CLMDTL_ACCOUNTING_NBR]" +
                            ",[CLMDTL_LINE_NO]" +
                            ",[ERROR_FLAG]" +
                            ",[DEBUG_INFO]" +
                            ",[INPUT_FILE_LOCATION])" +
                            " VALUES (");

                        if (tmpCLMDTL_SUSPEND_DESC.IndexOf("┬┬") > -1)
                        {
                            start = 0;

                            while (tmpCLMDTL_SUSPEND_DESC.IndexOf("┬┬") > -1)
                            {
                                end = tmpCLMDTL_SUSPEND_DESC.IndexOf("┬┬");
                                sql.Append("'").Append(tmpCLMDTL_SUSPEND_DESC.Substring(0, end)).Append("' + CHAR(13) + CHAR(10) + ");
                                start = end + 2;
                                tmpCLMDTL_SUSPEND_DESC = tmpCLMDTL_SUSPEND_DESC.Substring(start);
                            }

                            sql.Append("'").Append(tmpCLMDTL_SUSPEND_DESC).Append("' ,");
                        }

                        sql.Append("'").Append(tmpCLMDTL_STATUS).Append("',");
                        sql.Append("").Append(tmpCLMDTL_DOC_OHIP_NBR).Append(",");
                        sql.Append("'").Append(tmpCLMDTL_ACCOUNTING_NBR).Append("',");
                        sql.Append("").Append(tmpCLMDTL_LINE_NO).Append(",");

                        sql.Append("'").Append(error_flag.ToString()).Append("',");          // ERROR_FLAG
                        sql.Append("'").Append(debug_info.ToString()).Append("',");          // DEBUG_INFO
                        sql.Append("'").Append(input_file_location.ToString()).Append("'");  // INPUT_FILE_LOCATION

                        sql.Append(")");

                        try
                        {
                            var updated = SqlHelper.ExecuteNonQuery(CONNSTRING.Value.Trim(), CommandType.Text, sql.ToString());
                            sql_all.Append(sql);
                            count += 1;
                        }

                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    else
                    {
                        tmpCLMDTL_SUSPEND_DESC = extractData(line, "string", 0, 70);
                        tmpCLMDTL_STATUS = extractData(line, "string", 70, 1);
                        tmpCLMDTL_DOC_OHIP_NBR = extractData(line, "numeric", 71, 6);
                        tmpCLMDTL_ACCOUNTING_NBR = extractData(line, "string", 77, 8).Trim();
                        tmpCLMDTL_LINE_NO = extractData(line, "numeric", 85, 2);

                        sql = new StringBuilder("INSERT INTO [" + SCHEMA + "].[F002_SUSPEND_DESC](" +
                            " [CLMDTL_SUSPEND_DESC]" +
                            ",[CLMDTL_STATUS]" +
                            ",[CLMDTL_DOC_OHIP_NBR]" +
                            ",[CLMDTL_ACCOUNTING_NBR]" +
                            ",[CLMDTL_LINE_NO]" +
                            ",[ERROR_FLAG]" +
                            ",[DEBUG_INFO]" +
                            ",[INPUT_FILE_LOCATION])" +
                            " VALUES (");

                        sql.Append("'").Append(tmpCLMDTL_SUSPEND_DESC).Append("',");
                        sql.Append("'").Append(tmpCLMDTL_STATUS).Append("',");
                        sql.Append("").Append(tmpCLMDTL_DOC_OHIP_NBR).Append(",");
                        sql.Append("'").Append(tmpCLMDTL_ACCOUNTING_NBR).Append("',");
                        sql.Append("").Append(tmpCLMDTL_LINE_NO).Append(",");

                        sql.Append("'").Append(error_flag.ToString()).Append("',");          // ERROR_FLAG
                        sql.Append("'").Append(debug_info.ToString()).Append("',");          // DEBUG_INFO
                        sql.Append("'").Append(input_file_location.ToString()).Append("'");  // INPUT_FILE_LOCATION

                        sql.Append(")");

                        try
                        {
                            var updated = SqlHelper.ExecuteNonQuery(CONNSTRING.Value.Trim(), CommandType.Text, sql.ToString());
                            sql_all.Append(sql);
                            count += 1;
                        }

                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }

                line = sr.ReadLine();
            }

            return true;
        }

        catch (CustomApplicationException ex)
        {
            WriteError(ex);
            return false;
        }

        catch (Exception ex)
        {
            WriteError(ex);
            return false;
        }

        finally
        {
            string message = " Inserted " + count + " records into F002_SUSPEND_DESC";
            if (!found)
            {
                message = message + " (f002_suspend_desc.dat not found)";
            }

            var ex = new Exception(message);
            Console.WriteLine(ex.Message);
        }
    }

    private bool LoadF002_SUSPEND_ADDRESS()
    {
        bool found = true;

        try
        {
            string f002DtlFilename = "f002_suspend_address.dat";
            var sql = new StringBuilder("");
            var sql_all = new StringBuilder("");

            if (!File.Exists(Directory.GetCurrentDirectory() + "/" + f002DtlFilename))
            {
                found = false;
                return false;
            }

            sql = new StringBuilder("");
            sql_all = new StringBuilder("");

            input_file_location = Directory.GetCurrentDirectory();

            sql.Append(" TRUNCATE TABLE [" + SCHEMA + "].[F002_SUSPEND_ADDRESS] ");

            try
            {
                var updated = SqlHelper.ExecuteNonQuery(CONNSTRING.Value.Trim(), CommandType.Text, sql.ToString());
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            var sr = new StreamReader(Directory.GetCurrentDirectory() + "/" + f002DtlFilename);
            var line = sr.ReadLine();
            string buf = "";

            int error_flag = 0;
            string debug_info = "";
            int len = 0;
            int first_char = 0;

            count = 0;

            while (line != null)
            {
                error_flag = 0;
                debug_info = "";

                len = line.Length;

                // Break on bad records. Last records usually have no data or filled with NULL \0 characters. Checj the first byte. If it is null (0), skip the record
                byte[] asciiBytes = Encoding.ASCII.GetBytes(line);
                first_char = asciiBytes[0];
                if (first_char == 0)
                    break;

                if (line.Length != 177 && line.Length != 690)
                {
                    var ex = new Exception("File: " + f002DtlFilename + " record length is not 177 bytes. Critical error!");
                    throw ex;
                }

                sql = new StringBuilder("INSERT INTO [" + SCHEMA + "].[F002_SUSPEND_ADDRESS](" +
                     " [ADD_ADDRESS_LINE_1]" +
                     ",[ADD_ADDRESS_LINE_2]" +
                     ",[ADD_ADDRESS_LINE_3]" +
                     ",[ADD_POSTAL_CODE]" +
                     ",[ADD_SURNAME]" +
                     ",[ADD_FIRST_NAME]" +
                     ",[ADD_BIRTH_DATE]" +
                     ",[ADD_SEX]" +
                     ",[ADD_PHONE_NO]" +
                     ",[ADD_DOC_OHIP_NBR]" +
                     ",[ADD_ACCOUNTING_NBR]" +
                     ",[ERROR_FLAG]" +
                     ",[DEBUG_INFO]" +
                     ",[INPUT_FILE_LOCATION])" +
                     " VALUES (");

                buf = extractData(line, "string", 0, 25);
                sql.Append("'").Append(buf.ToString()).Append("',");

                buf = extractData(line, "string", 25, 25);
                sql.Append("'").Append(buf.ToString()).Append("',");

                buf = extractData(line, "string", 50, 25);
                sql.Append("'").Append(buf.ToString()).Append("',");

                buf = extractData(line, "string", 75, 9);
                sql.Append("'").Append(buf.ToString()).Append("',");

                buf = extractData(line, "string", 84, 25);
                sql.Append("'").Append(buf.ToString()).Append("',");

                buf = extractData(line, "string", 109, 25);
                sql.Append("'").Append(buf.ToString()).Append("',");

                buf = extractData(line, "numeric", 134, 8);
                sql.Append("").Append(buf.ToString()).Append(",");                   

                buf = extractData(line, "string", 142, 1);
                sql.Append("'").Append(buf.ToString()).Append("',");

                buf = extractData(line, "string", 143, 20);
                sql.Append("'").Append(buf.ToString()).Append("',");

                buf = extractData(line, "numeric", 163, 6);
                sql.Append("").Append(buf.ToString()).Append(",");

                buf = extractData(line, "string", 169, 8).Trim();
                sql.Append("'").Append(buf.ToString()).Append("',");

                sql.Append("'").Append(error_flag.ToString()).Append("',");         // ERROR_FLAG
                sql.Append("'").Append(debug_info.ToString()).Append("',");         // DEBUG_INFO
                sql.Append("'").Append(input_file_location.ToString()).Append("'"); // INPUT_FILE_LOCATION

                sql.Append(")");

                try
                {
                    var updated = SqlHelper.ExecuteNonQuery(CONNSTRING.Value.Trim(), CommandType.Text, sql.ToString());
                    sql_all.Append(sql);
                    count += 1;
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                line = sr.ReadLine();
            }

            return true;
        }

        catch (CustomApplicationException ex)
        {
            WriteError(ex);
            return false;
        }

        catch (Exception ex)
        {
            WriteError(ex);
            return false;

        }

        finally
        {
            string message = " Inserted " + count + " records into F002_SUSPEND_ADDRESS";
            if (!found)
            {
                message = message + " (f002_suspend_address.dat not found)";
            }
            
            var ex = new Exception(message);
            Console.WriteLine(ex.Message);
        }
    }

    private bool UnloadF002_SUSPEND_HDR()
    {
        try
        {
            string Filename = "F002_SUSPEND_HDR.dat";

            input_file_location = Directory.GetCurrentDirectory();

            if (File.Exists(input_file_location + "/" + Filename))
            {
                File.Delete(input_file_location + "/" + Filename);
            }

            try
            {
                count = 0;

                using (SqlConnection connection = new SqlConnection(CONNSTRING.Value.Trim()))
                using (SqlCommand command = new SqlCommand("SELECT * FROM [" + SCHEMA + "].[F002_SUSPEND_HDR]", connection))
                {
                    StringBuilder outputfile = new StringBuilder();
                    string line = string.Empty;
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            line = reader["CLMHDR_CLINIC_NBR_1_2"].ToString().PadLeft(2, '0') +
                                   reader["CLMHDR_DOC_NBR"].ToString().PadRight(3, ' ') +
                                   "00000000000" +
                                   reader["CLMHDR_BATCH_TYPE"].ToString().PadRight(1, ' ') +
                                   reader["CLMHDR_ADJ_CD_SUB_TYPE"].ToString().PadRight(1, ' ') +
                                   reader["CLMHDR_DOC_NBR_OHIP"].ToString().PadLeft(6, '0') +
                                   reader["CLMHDR_DOC_SPEC_CD"].ToString().PadLeft(2, '0') +
                                   reader["CLMHDR_REFER_DOC_NBR"].ToString().PadLeft(6, '0') +
                                   reader["CLMHDR_DIAG_CD"].ToString().PadLeft(3, '0') +
                                   reader["CLMHDR_LOC"].ToString().PadRight(4, ' ') +
                                   reader["CLMHDR_HOSP"].ToString().PadRight(1, ' ') +
                                   reader["CLMHDR_AGENT_CD"].ToString().PadLeft(1, '0') +
                                   reader["CLMHDR_ADJ_CD"].ToString().PadRight(1, ' ') +
                                   reader["CLMHDR_TAPE_SUBMIT_IND"].ToString().PadRight(1, ' ') +
                                   reader["CLMHDR_I_O_PAT_IND"].ToString().PadRight(1, ' ') +
                                   reader["CLMHDR_PAT_KEY_TYPE"].ToString().PadRight(1, ' ') +
                                   reader["CLMHDR_PAT_KEY_DATA"].ToString().PadRight(15, ' ') +
                                   reader["CLMHDR_PAT_ACRONYM6"].ToString().PadRight(6, ' ') +
                                   reader["CLMHDR_PAT_ACRONYM3"].ToString().PadRight(3, ' ') +
                                   reader["CLMHDR_REFERENCE"].ToString().PadRight(11, ' ') +
                                   reader["CLMHDR_DATE_ADMIT"].ToString().PadRight(8, ' ') +
                                   reader["CLMHDR_DOC_DEPT"].ToString().PadLeft(2, '0') +
                                   reader["CLMHDR_MSG_NBR"].ToString().PadRight(2, ' ') +
                                   reader["CLMHDR_REPRINT_FLAG"].ToString().PadRight(1, ' ') +
                                   reader["CLMHDR_SUB_NBR"].ToString().PadRight(1, ' ') +
                                   reader["CLMHDR_AUTO_LOGOUT"].ToString().PadRight(1, ' ') +
                                   reader["CLMHDR_FEE_COMPLEX"].ToString().PadRight(1, ' ') +
                                   reader["FILLER"].ToString().PadRight(2, ' ') +
                                   reader["CLMHDR_CURR_PAYMENT"].ToString().PadLeft(7, '0') +
                                   reader["CLMHDR_DATE_PERIOD_END"].ToString().PadLeft(8, '0') +
                                   reader["CLMHDR_CYCLE_NBR"].ToString().PadLeft(2, '0') +
                                   reader["CLMHDR_DATE_SYS"].ToString().PadRight(8, ' ') +
                                   reader["CLMHDR_AMT_TECH_BILLED"].ToString().PadLeft(6, '0') +
                                   reader["CLMHDR_AMT_TECH_PAID"].ToString().PadLeft(6, '0') +
                                   reader["CLMHDR_TOT_CLAIM_AR_OMA"].ToString().PadLeft(7, '0') +
                                   reader["CLMHDR_TOT_CLAIM_AR_OHIP"].ToString().PadLeft(7, '0') +
                                   reader["CLMHDR_MANUAL_AND_TAPE_PAYMENTS"].ToString().PadLeft(7, '0') +
                                   reader["CLMHDR_STATUS_OHIP"].ToString().PadRight(2, ' ') +
                                   reader["CLMHDR_ORIG_BATCH_NBR"].ToString().PadRight(8, ' ') +
                                   reader["CLMHDR_ORIG_CLAIM_NBR"].ToString().PadLeft(2, '0') +
                                   reader["CLMHDR_STATUS"].ToString().PadRight(1, ' ') +
                                   reader["CLMHDR_HEALTH_CARE_NBR"].ToString().PadRight(12, ' ') +
                                   reader["CLMHDR_HEALTH_CARE_VER"].ToString().PadRight(2, ' ') +
                                   reader["CLMHDR_HEALTH_CARE_PROV"].ToString().PadRight(2, ' ') +
                                   reader["CLMHDR_RELATIONSHIP"].ToString().PadRight(1, ' ') +
                                   reader["CLMHDR_PATIENT_SURNAME"].ToString().PadRight(25, ' ') +
                                   reader["CLMHDR_SUBSCR_INITIALS"].ToString().PadRight(3, ' ') +
                                   reader["CLMHDR_WCB_CLAIM_NBR"].ToString().PadRight(9, ' ') +
                                   reader["CLMHDR_WCB_ACCIDENT_DATE"].ToString().PadLeft(8, '0') +
                                   reader["CLMHDR_WCB_EMPLOYER_NAME_ADDR"].ToString().PadRight(40, ' ') +
                                   reader["CLMHDR_WCB_EMPLOYER_POSTAL_CODE"].ToString().PadRight(6, ' ') +
                                   reader["CLMHDR_CONFIDENTIAL_FLAG"].ToString().PadRight(1, ' ') +
                                   reader["CLMHDR_NBR_SUSPEND_DESC_RECS"].ToString().PadLeft(2, '0') +
                                   reader["FILLER2"].ToString().PadRight(1, ' ') +
                                   reader["CLMHDR_DOC_OHIP_NBR"].ToString().PadLeft(6, '0') +
                                   reader["CLMHDR_ACCOUNTING_NBR"].ToString().PadRight(8, ' ') +
                                   reader["SUSP_HDR_DOC_NBR"].ToString().PadRight(3, ' ') +
                                   reader["SUSP_HDR_CLINIC_NBR"].ToString().PadLeft(2, '0') +
                                   reader["SUSP_HDR_ACRONYM"].ToString().PadRight(9, ' ') +
                                   reader["SUSP_HDR_ACCOUNTING_NBR"].ToString().PadRight(8, ' ') +
                                   string.Empty.PadRight(512, ' ') +
                                   "0" +
                                   string.Empty.PadRight(256, ' ');

                            outputfile.Append(line.ToString()).Append(Environment.NewLine);
                            count++;
                        }

                        StreamWriter sw = new StreamWriter(input_file_location + "/" + Filename, false, System.Text.Encoding.Default);
                        sw.Write(outputfile.ToString());
                        sw.Flush();
                        sw.Close();
                        sw.Dispose();

                        connection.Close();
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return true;
        }

        catch (CustomApplicationException ex)
        {
            WriteError(ex);
            return false;
        }

        catch (Exception ex)
        {
            WriteError(ex);
            return false;
        }

        finally
        {
            var ex = new Exception(" Unloaded " + count + " records into F002_SUSPEND_HDR.dat");
            Console.WriteLine(ex.Message);
        }
    }

    private bool UnloadF002_SUSPEND_DTL()
    {
        try
        {
            string Filename = "F002_SUSPEND_DTL.dat";

            input_file_location = Directory.GetCurrentDirectory();

            if (File.Exists(input_file_location + "/" + Filename))
            {
                File.Delete(input_file_location + "/" + Filename);
            }

            try
            {
                count = 0;

                using (SqlConnection connection = new SqlConnection(CONNSTRING.Value.Trim()))
                using (SqlCommand command = new SqlCommand("SELECT * FROM [" + SCHEMA + "].[F002_SUSPEND_DTL]", connection))
                {
                    StringBuilder outputfile = new StringBuilder();
                    string line = string.Empty;
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            line = reader["CLMDTL_BATCH_NBR"].ToString().PadRight(8, ' ') +
                                   reader["CLMDTL_CLAIM_NBR"].ToString().PadLeft(2, '0') +
                                   reader["CLMDTL_OMA_CD"].ToString().PadRight(4, ' ') +
                                   reader["CLMDTL_OMA_SUFF"].ToString().PadRight(1, ' ') +
                                   reader["CLMDTL_ADJ_NBR"].ToString().PadLeft(1, '0') +
                                   reader["CLMDTL_REV_GROUP_CD"].ToString().PadRight(3, ' ') +
                                   reader["CLMDTL_AGENT_CD"].ToString().PadLeft(1, '0') +
                                   reader["CLMDTL_ADJ_CD"].ToString().PadRight(1, ' ') +
                                   reader["CLMDTL_NBR_SERV"].ToString().PadLeft(2, '0') +
                                   reader["CLMDTL_SV_YY"].ToString().PadLeft(4, '0') +
                                   reader["CLMDTL_SV_MM"].ToString().PadLeft(2, '0') +
                                   reader["CLMDTL_SV_DD"].ToString().PadLeft(2, '0') +
                                   reader["CLMDTL_CONSEC_DATES_R"].ToString().PadRight(9, ' ') +
                                   reader["CLMDTL_AMT_TECH_BILLED"].ToString().PadLeft(6, '0') +
                                   reader["CLMDTL_FEE_OMA"].ToString().PadLeft(7, '0') +
                                   reader["CLMDTL_FEE_OHIP"].ToString().PadLeft(7, '0') +
                                   reader["CLMDTL_DATE_PERIOD_END"].ToString().PadRight(8, ' ') +
                                   reader["CLMDTL_CYCLE_NBR"].ToString().PadLeft(3, '0') +
                                   reader["CLMDTL_DIAG_CD"].ToString().PadLeft(3, '0') +
                                   reader["CLMDTL_DIAG_CD_LOCAL"].ToString().PadLeft(3, '0') +
                                   reader["CLMDTL_STATUS"].ToString().PadRight(1, ' ') +
                                   reader["CLMDTL_DOC_OHIP_NBR"].ToString().PadLeft(6, '0') +
                                   reader["CLMDTL_ACCOUNTING_NBR"].ToString().PadRight(8, ' ');

                            outputfile.Append(line.ToString()).Append(Environment.NewLine);
                            count++;
                        }

                        StreamWriter sw = new StreamWriter(input_file_location + "/" + Filename, false, System.Text.Encoding.Default);
                        sw.Write(outputfile.ToString());
                        sw.Flush();
                        sw.Close();
                        sw.Dispose();

                        connection.Close();
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return true;
        }

        catch (CustomApplicationException ex)
        {
            WriteError(ex);
            return false;
        }

        catch (Exception ex)
        {
            WriteError(ex);
            return false;
        }

        finally
        {
            var ex = new Exception(" Unloaded " + count + " records into F002_SUSPEND_DTL.dat");
            Console.WriteLine(ex.Message);
        }
    }

    private bool UnloadF002_SUSPEND_DESC()
    {
        try
        {
            string Filename = "F002_SUSPEND_DESC.dat";
            var sql = new StringBuilder("");

            input_file_location = Directory.GetCurrentDirectory();

            if (File.Exists(input_file_location + "/" + Filename))
            {
                File.Delete(input_file_location + "/" + Filename);
            }

            try
            {
                count = 0;

                using (SqlConnection connection = new SqlConnection(CONNSTRING.Value.Trim()))
                using (SqlCommand command = new SqlCommand("SELECT * FROM [" + SCHEMA + "].[F002_SUSPEND_DESC]", connection))
                {
                    StringBuilder outputfile = new StringBuilder();
                    string line = string.Empty;
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader["CLMDTL_SUSPEND_DESC"].ToString().Trim().Length > 0)
                            {
                                line = reader["CLMDTL_SUSPEND_DESC"].ToString().PadRight(70, ' ') +
                                       reader["CLMDTL_STATUS"].ToString().PadRight(1, ' ') +
                                       reader["CLMDTL_DOC_OHIP_NBR"].ToString().PadLeft(6, '0') +
                                       reader["CLMDTL_ACCOUNTING_NBR"].ToString().PadRight(8, ' ') +
                                       reader["CLMDTL_LINE_NO"].ToString().PadLeft(2, '0');

                                outputfile.Append(line.ToString()).Append(Environment.NewLine);
                                count++;
                            }
                        }

                        StreamWriter sw = new StreamWriter(input_file_location + "/" + Filename, false, System.Text.Encoding.Default);

                        if (outputfile.ToString().Trim().Length > 0)
                        {
                            sw.Write(outputfile.ToString());
                        }
                        else
                        {
                            sw.Write("");
                        }
                        sw.Flush();
                        sw.Close();
                        sw.Dispose();

                        connection.Close();
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return true;
        }

        catch (CustomApplicationException ex)
        {
            WriteError(ex);
            return false;
        }

        catch (Exception ex)
        {
            WriteError(ex);
            return false;
        }

        finally
        {
            var ex = new Exception(" Unloaded " + count + " records into F002_SUSPEND_DESC.dat");
            Console.WriteLine(ex.Message);
        }
    }

    private bool UnloadF002_SUSPEND_ADDRESS()
    {
        try
        {
            string Filename = "F002_SUSPEND_ADDRESS.dat";
            var sql = new StringBuilder("");

            input_file_location = Directory.GetCurrentDirectory();

            if (File.Exists(input_file_location + "/" + Filename))
            {
                File.Delete(input_file_location + "/" + Filename);
            }

            try
            {
                count = 0;

                using (SqlConnection connection = new SqlConnection(CONNSTRING.Value.Trim()))
                using (SqlCommand command = new SqlCommand("SELECT * FROM [" + SCHEMA + "].[F002_SUSPEND_ADDRESS]", connection))
                {
                    StringBuilder outputfile = new StringBuilder();
                    string line = string.Empty;
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            line = reader["ADD_ADDRESS_LINE_1"].ToString().PadRight(25, ' ') +
                                   reader["ADD_ADDRESS_LINE_2"].ToString().PadRight(25, ' ') +
                                   reader["ADD_ADDRESS_LINE_3"].ToString().PadRight(25, ' ') +
                                   reader["ADD_POSTAL_CODE"].ToString().PadRight(9, ' ') +
                                   reader["ADD_SURNAME"].ToString().PadRight(25, ' ') +
                                   reader["ADD_FIRST_NAME"].ToString().PadRight(25, ' ') +
                                   reader["ADD_BIRTH_DATE"].ToString().PadLeft(8, '0') +
                                   reader["ADD_SEX"].ToString().PadRight(1, ' ') +
                                   reader["ADD_PHONE_NO"].ToString().PadRight(20, ' ') +
                                   reader["ADD_DOC_OHIP_NBR"].ToString().PadLeft(6, '0') +
                                   reader["ADD_ACCOUNTING_NBR"].ToString().PadRight(8, ' ') +
                                   string.Empty.PadRight(256, ' ') +
                                   "0" +
                                   string.Empty.PadRight(256, ' ');

                            outputfile.Append(line.ToString()).Append(Environment.NewLine);
                            count++;
                        }

                        StreamWriter sw = new StreamWriter(input_file_location + "/" + Filename, false, System.Text.Encoding.Default);

                        sw.Write(outputfile.ToString());
                        sw.Flush();
                        sw.Close();
                        sw.Dispose();

                        connection.Close();
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return true;
        }

        catch (CustomApplicationException ex)
        {
            WriteError(ex);
            return false;
        }

        catch (Exception ex)
        {
            WriteError(ex);
            return false;
        }

        finally
        {
            var ex = new Exception(" Unloaded " + count + " records into F002_SUSPEND_ADDRESS.dat");
            Console.WriteLine(ex.Message);
        }
    }

    private bool TruncateTables()
    {
        string sql = string.Empty;
        int hdr_count = 0;
        int dtl_count = 0;
        int desc_count = 0;
        int addr_count = 0;

        try
        {
            sql = "SELECT COUNT(1) FROM [" + SCHEMA + "].[F002_SUSPEND_HDR]";
            var count = SqlHelper.ExecuteScalar(CONNSTRING.Value.Trim(), CommandType.Text, sql.ToString());

            hdr_count = Convert.ToInt32(count);

            sql = "TRUNCATE TABLE [" + SCHEMA.ToString().Trim() + "].[F002_SUSPEND_HDR] ";

            try
            {
                var updated = SqlHelper.ExecuteNonQuery(CONNSTRING.Value.Trim(), CommandType.Text, sql.ToString());
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            sql = "SELECT COUNT(1) FROM [" + SCHEMA + "].[F002_SUSPEND_DTL]";
            count = SqlHelper.ExecuteScalar(CONNSTRING.Value.Trim(), CommandType.Text, sql.ToString());

            dtl_count = Convert.ToInt32(count);

            sql = "TRUNCATE TABLE [" + SCHEMA + "].[F002_SUSPEND_DTL] ";

            try
            {
                var updated = SqlHelper.ExecuteNonQuery(CONNSTRING.Value.Trim(), CommandType.Text, sql.ToString());
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            sql = "SELECT COUNT(1) FROM [" + SCHEMA + "].[F002_SUSPEND_DESC]";
            count = SqlHelper.ExecuteScalar(CONNSTRING.Value.Trim(), CommandType.Text, sql.ToString());

            desc_count = Convert.ToInt32(count);

            sql = "TRUNCATE TABLE [" + SCHEMA + "].[F002_SUSPEND_DESC] ";

            try
            {
                var updated = SqlHelper.ExecuteNonQuery(CONNSTRING.Value.Trim(), CommandType.Text, sql.ToString());
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            sql = "SELECT COUNT(1) FROM [" + SCHEMA + "].[F002_SUSPEND_ADDRESS]";
            count = SqlHelper.ExecuteScalar(CONNSTRING.Value.Trim(), CommandType.Text, sql.ToString());

            addr_count = Convert.ToInt32(count);

            sql = "TRUNCATE TABLE [" + SCHEMA + "].[F002_SUSPEND_ADDRESS] ";

            try
            {
                var updated = SqlHelper.ExecuteNonQuery(CONNSTRING.Value.Trim(), CommandType.Text, sql.ToString());
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        catch (CustomApplicationException ex)
        {
            WriteError(ex);
            return false;
        }

        catch (Exception ex)
        {
            WriteError(ex);
            return false;
        }

        finally
        {
            var ex = new Exception(Environment.NewLine + Environment.NewLine + "Tables Truncated: " + Environment.NewLine + hdr_count + " records from F002_SUSPEND_HDR" + Environment.NewLine +
                                    dtl_count + " records from F002_SUSPEND_DTL" + Environment.NewLine + desc_count + " records from F002_SUSPEND_DESC" + Environment.NewLine +
                                    addr_count + " records from F002_SUSPEND_ADDRESS");
            Console.WriteLine(ex.Message);
        }

        return true;
    }

    private bool F002RecordCount()
    {
        string sql = string.Empty;
        int hdr_count = 0;
        int dtl_count = 0;
        int desc_count = 0;
        int addr_count = 0;

        try
        {
            sql = "SELECT COUNT(1) FROM [" + SCHEMA + "].[F002_SUSPEND_HDR]";
            var count = SqlHelper.ExecuteScalar(CONNSTRING.Value.Trim(), CommandType.Text, sql.ToString());

            hdr_count = Convert.ToInt32(count);

            sql = "SELECT COUNT(1) FROM [" + SCHEMA + "].[F002_SUSPEND_DTL]";
            count = SqlHelper.ExecuteScalar(CONNSTRING.Value.Trim(), CommandType.Text, sql.ToString());

            dtl_count = Convert.ToInt32(count);

            sql = "SELECT COUNT(1) FROM [" + SCHEMA + "].[F002_SUSPEND_DESC]";
            count = SqlHelper.ExecuteScalar(CONNSTRING.Value.Trim(), CommandType.Text, sql.ToString());

            desc_count = Convert.ToInt32(count);

            sql = "SELECT COUNT(1) FROM [" + SCHEMA + "].[F002_SUSPEND_ADDRESS]";
            count = SqlHelper.ExecuteScalar(CONNSTRING.Value.Trim(), CommandType.Text, sql.ToString());

            addr_count = Convert.ToInt32(count);
        }

        catch (CustomApplicationException ex)
        {
            WriteError(ex);
            return false;
        }

        catch (Exception ex)
        {
            WriteError(ex);
            return false;
        }

        finally
        {
            var ex = new Exception(Environment.NewLine + Environment.NewLine + hdr_count + " records in F002_SUSPEND_HDR" + Environment.NewLine +
                                    dtl_count + " records in F002_SUSPEND_DTL" + Environment.NewLine +
                                    desc_count + " records in F002_SUSPEND_DESC" + Environment.NewLine +
                                    addr_count + " records in F002_SUSPEND_ADDRESS");
            Console.WriteLine(ex.Message);
        }

        return true;
    }

    public override bool RunQTP()
    {
        try
        {
            SCHEMA = Directory.GetCurrentDirectory();

            if (SCHEMA.EndsWith("\\"))
                SCHEMA = SCHEMA.Substring(0, SCHEMA.LastIndexOf("\\"));

            SCHEMA = SCHEMA.Substring(SCHEMA.LastIndexOf("\\") + 1);
            CONNSTRING.Value = Common.ConnectionStringDecrypt(CONNSTRING.Value.Trim());

            switch (PROCESS.Value.Trim().ToUpper())
            {
                case "UPLOAD":
                    Console.WriteLine(Environment.NewLine + " Are you sure you want to upload the data? (Y/N)");
                    Console.Out.Flush();
                    var answer = Console.ReadLine();

                    if (answer.ToString().ToUpper() == "Y")
                    {
                        Console.WriteLine(Environment.NewLine + " Uploading F002 SUSPEND files. One moment please..." + Environment.NewLine);

                        LoadF002_SUSPEND_HDR();
                        LoadF002_SUSPEND_DTL();
                        LoadF002_SUSPEND_DESC();
                        LoadF002_SUSPEND_ADDRESS();

                        Console.WriteLine(Environment.NewLine + " F002 SUSPEND files uploaded." + Environment.NewLine);
                    }
                    else
                    {
                        Console.WriteLine(Environment.NewLine + " Upload cancelled..." + Environment.NewLine);
                    }
                    break;

                case "DOWNLOAD":
                    Console.WriteLine(Environment.NewLine + " Are you sure you want to download the data? (Y/N)");
                    Console.Out.Flush();
                    answer = Console.ReadLine();

                    if (answer.ToString().ToUpper() == "Y")
                    {
                        Console.WriteLine(Environment.NewLine + " Downloading F002 SUSPEND files. One moment please..." + Environment.NewLine);

                        UnloadF002_SUSPEND_HDR();
                        UnloadF002_SUSPEND_DTL();
                        UnloadF002_SUSPEND_DESC();
                        UnloadF002_SUSPEND_ADDRESS();

                        Console.WriteLine(Environment.NewLine + " F002 SUSPEND files downloaded." + Environment.NewLine);
                    }
                    else
                    {
                        Console.WriteLine(Environment.NewLine + " Download cancelled..." + Environment.NewLine);
                    }
                    break;

                case "CLEAR":
                    Console.WriteLine(Environment.NewLine + " Are you sure you want to clear the tables? (Y/N)");
                    Console.Out.Flush();
                    answer = Console.ReadLine();

                    if (answer.ToString().ToUpper() == "Y")
                    {
                        TruncateTables();
                    }
                    else
                    {
                        Console.WriteLine(Environment.NewLine + " Clearing tables cancelled..." + Environment.NewLine);
                    }
                    break;

                case "LIST":
                    F002RecordCount();
                    break;
            }
        }

        catch (CustomApplicationException ex)
        {
            WriteError(ex);
            return false;
        }

        catch (Exception ex)
        {
            WriteError(ex);
            return false;
        }

        return true;
    }

    #endregion

    #endregion
}

