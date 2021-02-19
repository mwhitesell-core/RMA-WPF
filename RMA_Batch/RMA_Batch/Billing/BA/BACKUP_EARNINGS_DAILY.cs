
#region "Screen Comments"

// MODIFICATION HISTORY:
// 1999/JAN/15  S.B.     - Checked for Y2K.


#endregion

using Core.DataAccess.SqlServer;
using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

public class BACKUP_EARNINGS_DAILY : BaseClassControl
{

    private BACKUP_EARNINGS_DAILY m_BACKUP_EARNINGS_DAILY;

    public BACKUP_EARNINGS_DAILY(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;

    }

    public BACKUP_EARNINGS_DAILY(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;



    }

    public override void Dispose()
    {
        if ((m_BACKUP_EARNINGS_DAILY != null))
        {
            m_BACKUP_EARNINGS_DAILY.CloseTransactionObjects();
            m_BACKUP_EARNINGS_DAILY = null;
        }
    }

    public BACKUP_EARNINGS_DAILY GetBACKUP_EARNINGS_DAILY(int Level)
    {
        if (m_BACKUP_EARNINGS_DAILY == null)
        {
            m_BACKUP_EARNINGS_DAILY = new BACKUP_EARNINGS_DAILY("BACKUP_EARNINGS_DAILY", Level);
        }
        else
        {
            m_BACKUP_EARNINGS_DAILY.ResetValues();
        }
        return m_BACKUP_EARNINGS_DAILY;
    }



    #region "Renaissance Architect Migration Services Default Regions"




    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"


    private StringBuilder sb = new StringBuilder("");
    

    public override bool RunQTP()
    {
        string backup_table_list = "";
        string backup_database_prefix = "";

        try
        {
            backup_database_prefix = Prompt(2).ToString().ToLower();

            if (Prompt(2).ToString().ToLower().Equals("backup_earnings_daily"))
            {
                backup_table_list =
                    "INDEXED.CONSTANTS_MSTR_REC_1," +
                    "INDEXED.CONSTANTS_MSTR_REC_2," +
                    "INDEXED.CONSTANTS_MSTR_REC_3," +
                    "INDEXED.CONSTANTS_MSTR_REC_4," +
                    "INDEXED.CONSTANTS_MSTR_REC_5," +
                    "INDEXED.CONSTANTS_MSTR_REC_6," +
                    "INDEXED.CONSTANTS_MSTR_REC_7," +
                    "INDEXED.F020_DOCTOR_EXTRA," +
                    "INDEXED.F020_DOCTOR_MSTR," +
                    "INDEXED.F020_DOC_MSTR_HISTORY," +
                    "INDEXED.F050_DOC_REVENUE_MSTR," +
                    "INDEXED.F050TP_DOC_REVENUE_MSTR_HISTORY," +
                    "INDEXED.F074_AFP_GROUP_MSTR," +
                    "INDEXED.F074_AFP_GROUP_SEQUENCE_MSTR," +
                    "INDEXED.F075_AFP_DOC_MSTR," +
                    "INDEXED.F095_TEXT_LINES," +
                    "INDEXED.F110_COMPENSATION," +
                    "INDEXED.F110_COMPENSATION_HISTORY," +
                    "INDEXED.F112_PYCDCEILINGS," +
                    "INDEXED.F112_PYCDCEILINGS_HISTORY," +
                    "INDEXED.F113_DEFAULT_COMP," +
                    "INDEXED.F113_DEFAULT_COMP_HISTORY," +
                    "INDEXED.F113_DEFAULT_COMP_UPLOAD_DRIVER," +
                    "INDEXED.F114_SPECIAL_PAYMENTS," +
                    "INDEXED.F115_DEPT_EXPENSE_CALC_CODES," +
                    "INDEXED.F116_DEPT_EXPENSE_RULES_DTL," +
                    "INDEXED.F116_DEPT_EXPENSE_RULES_HDR," +
                    "INDEXED.F119_DOCTOR_YTD," +
                    "INDEXED.F119_DOCTOR_YTD_HISTORY," +
                    "INDEXED.F190_COMP_CODES," +
                    "INDEXED.F191_EARNINGS_PERIOD," +
                    "INDEXED.F198_USER_DEFINED_TOTALS," +
                    "INDEXED.F199_USER_DEFINED_FIELDS," +
                    "INDEXED.ICONST_MSTR_REC," +

                    "INDEXED.F050_DOC_REVENUE_MSTR_HISTORY," +          // Added see Mantis issue 33
                    "SEQUENTIAL.F110_COMPENSATION_AUDIT," +
                    "SEQUENTIAL.F112_PYCDCEILINGS_AUDIT," +
                    "SEQUENTIAL.F119_DOCTOR_YTD_AUDIT";
            }

            if (Prompt(2).ToString().ToLower().Equals("backup_earnings_daily_disk"))
            {
                backup_table_list =
               backup_table_list =
                    "INDEXED.CONSTANTS_MSTR_REC_1," +
                    "INDEXED.CONSTANTS_MSTR_REC_2," +
                    "INDEXED.CONSTANTS_MSTR_REC_3," +
                    "INDEXED.CONSTANTS_MSTR_REC_4," +
                    "INDEXED.CONSTANTS_MSTR_REC_5," +
                    "INDEXED.CONSTANTS_MSTR_REC_6," +
                    "INDEXED.CONSTANTS_MSTR_REC_7," +
                    "INDEXED.F020_DOCTOR_EXTRA," +
                    "INDEXED.F020_DOCTOR_MSTR," +
                    "INDEXED.F020_DOC_MSTR_HISTORY," +
                    "INDEXED.F050_DOC_REVENUE_MSTR," +
                    "INDEXED.F050TP_DOC_REVENUE_MSTR_HISTORY," +
                    "INDEXED.F074_AFP_GROUP_MSTR," +
                    "INDEXED.F074_AFP_GROUP_SEQUENCE_MSTR," +
                    "INDEXED.F075_AFP_DOC_MSTR," +
                    "INDEXED.F095_TEXT_LINES," +
                    "INDEXED.F110_COMPENSATION," +
                    "INDEXED.F110_COMPENSATION_HISTORY," +
                    "INDEXED.F112_PYCDCEILINGS," +
                    "INDEXED.F112_PYCDCEILINGS_HISTORY," +
                    "INDEXED.F113_DEFAULT_COMP," +
                    "INDEXED.F113_DEFAULT_COMP_HISTORY," +
                    "INDEXED.F113_DEFAULT_COMP_UPLOAD_DRIVER," +
                    "INDEXED.F114_SPECIAL_PAYMENTS," +
                    "INDEXED.F115_DEPT_EXPENSE_CALC_CODES," +
                    "INDEXED.F116_DEPT_EXPENSE_RULES_DTL," +
                    "INDEXED.F116_DEPT_EXPENSE_RULES_HDR," +
                    "INDEXED.F119_DOCTOR_YTD," +
                    "INDEXED.F119_DOCTOR_YTD_HISTORY," +
                    "INDEXED.F190_COMP_CODES," +
                    "INDEXED.F191_EARNINGS_PERIOD," +
                    "INDEXED.F198_USER_DEFINED_TOTALS," +
                    "INDEXED.F199_USER_DEFINED_FIELDS," +
                    "INDEXED.ICONST_MSTR_REC," +

                    "INDEXED.F050_DOC_REVENUE_MSTR_HISTORY," +          // Added see Mantis issue 33
                    "SEQUENTIAL.F110_COMPENSATION_AUDIT," +
                    "SEQUENTIAL.F112_PYCDCEILINGS_AUDIT," +
                    "SEQUENTIAL.F119_DOCTOR_YTD_AUDIT";
            }

            if (Prompt(2).ToString().ToLower().Equals("backup_earnings_monthend") 
                 || Prompt(2).ToString().ToLower().Equals("backup_earnings_monthend_disk"))
            {
                backup_table_list =
                    "INDEXED.CONSTANTS_MSTR_REC_1," +
                    "INDEXED.CONSTANTS_MSTR_REC_2," +
                    "INDEXED.CONSTANTS_MSTR_REC_3," +
                    "INDEXED.CONSTANTS_MSTR_REC_4," +
                    "INDEXED.CONSTANTS_MSTR_REC_5," +
                    "INDEXED.CONSTANTS_MSTR_REC_6," +
                    "INDEXED.CONSTANTS_MSTR_REC_7," +
                    "INDEXED.F020_DOCTOR_MSTR," +
                    "INDEXED.F020_DOC_MSTR_HISTORY," +
                    "INDEXED.F020_DOCTOR_EXTRA," +
                    "INDEXED.F050_DOC_REVENUE_MSTR," +
                    "INDEXED.F050TP_DOC_REVENUE_MSTR_HISTORY," +
                    "INDEXED.F070_DEPT_MSTR," +
                    "INDEXED.F074_AFP_GROUP_MSTR," +
                    "INDEXED.F074_AFP_GROUP_SEQUENCE_MSTR," +
                    "INDEXED.F075_AFP_DOC_MSTR," +
                    "INDEXED.F080_BANK_MSTR," +
                    "INDEXED.F095_TEXT_LINES," +
                    "INDEXED.F110_COMPENSATION," +
                    "INDEXED.F110_COMPENSATION_HISTORY," +
                    "INDEXED.F112_PYCDCEILINGS," +
                    "INDEXED.F112_PYCDCEILINGS_HISTORY," +
                    "INDEXED.F113_DEFAULT_COMP," +
                    "INDEXED.F113_DEFAULT_COMP_HISTORY," +
                    "INDEXED.F113_DEFAULT_COMP_UPLOAD_DRIVER," +
                    "INDEXED.F114_SPECIAL_PAYMENTS," +
                    "INDEXED.F115_DEPT_EXPENSE_CALC_CODES," +
                    "INDEXED.F116_DEPT_EXPENSE_RULES_DTL," +
                    "INDEXED.F116_DEPT_EXPENSE_RULES_HDR," +
                    "INDEXED.F119_DOCTOR_YTD," +
                    "INDEXED.F119_DOCTOR_YTD_HISTORY," +
                    "INDEXED.F190_COMP_CODES," +
                    "INDEXED.F191_EARNINGS_PERIOD," +
                    "INDEXED.F198_USER_DEFINED_TOTALS," +
                    "INDEXED.F199_USER_DEFINED_FIELDS," +
                    "INDEXED.ICONST_MSTR_REC," +

                    "INDEXED.F050_DOC_REVENUE_MSTR_HISTORY," +          // Added see Mantis issue 33
                    "SEQUENTIAL.F110_COMPENSATION_AUDIT," +
                    "SEQUENTIAL.F112_PYCDCEILINGS_AUDIT," +
                    "SEQUENTIAL.F119_DOCTOR_YTD_AUDIT";

            }
            if (Prompt(2).ToString().ToLower().Equals("backup_daily_1"))
            {
                backup_table_list =
                    "[101C].INDEXED.F010_PAT_MSTR," +
                    "INDEXED.F001_BATCH_CONTROL_FILE," +
                    "INDEXED.F002_CLAIM_SHADOW," +
                    "INDEXED.F002_CLAIMS_EXTRA," +
                    "INDEXED.F002_CLAIMS_MSTR," +
                    "INDEXED.F011_PAT_MSTR_ELIG_HISTORY," +
                    "INDEXED.F020_DOCTOR_EXTRA," +
                    "INDEXED.F020_DOCTOR_MSTR," +
                    "INDEXED.F021_AVAIL_DOCTOR_MSTR*," +
                    "SEQUENTIAL.F022_DELETED_DOC_AUDIT_FILE," +
                    "INDEXED.F023_ALTERNATIVE_DOC_NBR*," +
                    "INDEXED.F027_CONTACTS_MSTR," +
                    "INDEXED.F028_AUDIT_FILE," +
                    "INDEXED.F028_CONTACTS_INFO_MSTR," +
                    "INDEXED.F029_FOLLOWUP_EVENTS," +
                    "INDEXED.F030_LOCATIONS_MSTR," +
                    "INDEXED.F040_OMA_FEE_MSTR," +
                    "INDEXED.F050_DOC_REVENUE_MSTR," +
                    "[101C].INDEXED.F050_DOC_REVENUE_MSTR_HISTORY," +
                    "INDEXED.F050TP_DOC_REVENUE_MSTR," +
                    "[101C].INDEXED.F050TP_DOC_REVENUE_MSTR_HISTORY," +
                    "INDEXED.F051_DOC_CASH_MSTR," +
                    "INDEXED.F051TP_DOC_CASH_MSTR," +
                    "INDEXED.F060_CHEQUE_REG_MSTR," +
                    "INDEXED.F070_DEPT_MSTR," +
                    "INDEXED.F071_CLIENT_RMA_CLAIM_NBR," +
                    "INDEXED.F072_CLIENT_MSTR," +
                    "INDEXED.F073_CLIENT_DOC_MSTR," +
                    "INDEXED.F074_AFP_GROUP_MSTR," +
                    "INDEXED.F074_AFP_GROUP_SEQUENCE_MSTR," +
                    "INDEXED.F075_AFP_DOC_MSTR," +
                    "INDEXED.F080_BANK_MSTR," +
                    "INDEXED.F083_USER_MSTR," +
                    "INDEXED.F084_CLAIMS_INVENTORY," +
                    "INDEXED.F085_REJECTED_CLAIMS," +
                    "SEQUENTIAL.F086_PAT_ID," +
                    "INDEXED.F087_SUBMITTED_REJECTED," +
                    "INDEXED.F088_RAT_REJECTED_CLAIMS," +
                    "INDEXED.F090_CONSTANTS_MSTR," +
                    "INDEXED.F091_DIAG_CODES_MSTR," +
                    "INDEXED.F092_OHIP_ERROR_CAT_MSTR," +
                    "INDEXED.F093_OHIP_ERROR_MSG_MSTR," +
                    "INDEXED.F094_MSG_SUB_MSTR," +
                    "INDEXED.F095_TEXT_LINES," +
                    "INDEXED.F096_OHIP_PAY_CODE," +
                    "INDEXED.F097_SPEC_CD_MSTR," +
                    "INDEXED.F098_EQUIV_OMA_CODE_MSTR," +
                    "INDEXED.F099_GROUP_CLAIM_MSTR," +
                    "INDEXED.F112_PYCDCEILINGS," +
                    "INDEXED.F113_DEFAULT_COMP," +
                    "INDEXED.F114_SPECIAL_PAYMENTS," +
                    "INDEXED.F123_COMPANY_MSTR," +
                    "INDEXED.F190_COMP_CODES," +
                    "INDEXED.F191_EARNINGS_PERIOD," +
                    "INDEXED.F923_DOC_REVENUE_TRANSLATION," +
                    "INDEXED.F924_NON_FEE_FOR_SERVICE_LOCATIONS," +
                    "SEQUENTIAL.ADJ_CLAIM_FILE," +
                    "INDEXED.CONTRACT_DTL," +
                    "INDEXED.CONTRACT_MSTR," +
                    //"INDEXED.COPY," +
                    //"INDEXED.CREATE," +
                    "INDEXED.DOC_TOTALS_TMP," +
                    //"INDEXED.RESUBMIT.REQUIRED," +
                    "INDEXED.SOCIAL_CONTRACT_FACTOR";
            }
            if (Prompt(2).ToString().ToLower().Equals("backup_daily_2"))
            {
                backup_table_list =
                    "[MP].INDEXED.F110_COMPENSATION," +
                    "[MP].INDEXED.F112_PYDCEILINGS," +
                    "[MP].INDEXED.F113_DEFAULT_COMP," +
                    "[MP].INDEXED.F191_EARNINGS_PERIOD";
            }
            if(Prompt(2).ToString().ToLower().Equals("backup_f001_f050"))
            {
                backup_table_list =
                    "INDEXED.F001_BATCH_CONTROL_FILE," +
                    "INDEXED.F051_DOC_CASH_MSTR," +
                    "INDEXED.F050_DOC_REVENUE_MSTR," +
                    //"INDEXED.F050_DOC_REVENUE_MSTR_HISTORY," +            backs up 101c specifically
                    "INDEXED.F050TP_DOC_REVENUE_MSTR," +
                    //"INDEXED.F050TP_DOC_REVENUE_MSTR_HISTORY," +          backs up 101c specifically
                    "INDEXED.F051TP_DOC_CASH_MSTR,";
            }
            if(Prompt(2).ToString().ToLower().Equals("copy_error_files"))
            {
                backup_table_list = 
                    "INDEXED.F087_SUBMITTED_REJECTED_CLAIMS_HDR," +
                    "INDEXED.F087_SUBMITTED_REJECTED_CLAIMS_DTL," +
                    "INDEXED.REJECTED_CLAIMS";
            }
            if (Prompt(2).ToString().ToLower().Equals("yearend_payroll_backups"))
            {
                backup_table_list =
                    "INDEXED.F110_COMPENSATION," +
                    "INDEXED.F112_PYCDCEILINGS," +
                    "INDEXED.F113_DEFAULT_COMP," +
                    "INDEXED.F113_DEFAULT_COMP_UPLOAD_DRIVER," +
                    "INDEXED.F114_SPECIAL_PAYMENTS," +
                    "INDEXED.F115_DEPT_EXPENSE_CALC_CODES," +
                    "INDEXED.F116_DEPT_EXPENSE_RULES_DTL," +
                    "INDEXED.F116_DEPT_EXPENSE_RULES_HDR," +
                    "INDEXED.F119_DOCTOR_YTD," +
                    "INDEXED.F190_COMP_CODES," +
                    "INDEXED.F191_EARNINGS_PERIOD," +
                    "INDEXED.F198_USER_DEFINED_TOTALS," +
                    "INDEXED.F199_USER_DEFINED_FIELDS," +
                    "INDEXED.F095_TEXT_LINES," +
                    "INDEXED.F020_DOCTOR_MSTR," +
                    "INDEXED.ICONST_MSTR_REC," +
                    "INDEXED.CONSTANTS_MSTR_REC_1," +
                    "INDEXED.CONSTANTS_MSTR_REC_2," +
                    "INDEXED.CONSTANTS_MSTR_REC_3," +
                    "INDEXED.CONSTANTS_MSTR_REC_4," +
                    "INDEXED.CONSTANTS_MSTR_REC_5," +
                    "INDEXED.CONSTANTS_MSTR_REC_6," +
                    "INDEXED.CONSTANTS_MSTR_REC_7," +
                    "INDEXED.F050_DOC_REVENUE_MSTR," +
                    "INDEXED.F050_DOC_REVENUE_MSTR_HISTORY," +
                    "INDEXED.F050TP_DOC_REVENUE_MSTR," +
                    "INDEXED.F050TP_DOC_REVENUE_MSTR_HISTORY," +
                    "INDEXED.F074_AFP_GROUP_MSTR," +
                    "INDEXED.F074_AFP_GROUP_SEQUENCE_MSTR," +
                    "INDEXED.F075_AFP_DOC_MSTR," +
                    "INDEXED.F110_COMPENSATION_HISTORY," +
                    "INDEXED.F112_PYCDCEILINGS_HISTORY," +
                    "INDEXED.F113_DEFAULT_COMP_HISTORY," +
                    "INDEXED.F119_DOCTOR_YTD_HISTORY," +
                    "INDEXED.F020_DOC_MSTR_HISTORY," +
                    "INDEXED.F020_DOCTOR_EXTRA";
            }
            if (Prompt(2).ToString().ToLower().Equals("backup_f050_f051_f001_f002"))
            {
                backup_table_list =
                    "INDEXED.F050_DOC_REVENUE_MSTR," +
                    "INDEXED.F050TP_DOC_REVENUE_MSTR," +
                    "INDEXED.F050_DOC_REVENUE_MSTR_HISTORY," +
                    "INDEXED.F050TP_DOC_REVENUE_MSTR_HISTORY," +
                    "INDEXED.F051_DOC_CASH_MSTR," +
                    "INDEXED.F051TP_DOC_CASH_MSTR," +
                    "INDEXED.F001_BATCH_CONTROL_FILE," +
                    "INDEXED.F002_CLAIM_SHADOW";
            }
            if (Prompt(2).ToString().ToLower().Equals("delete_f001_claims_batches"))
            {
                backup_table_list =
                    "INDEXED.F001_BATCH_CONTROL_FILE";
            }
            if (Prompt(2).ToString().ToLower().Equals("delete_f001_adj_pay_batches"))
            {
                backup_table_list =
                    "INDEXED.F002_CLAIMS_MSTR_HDR," +
                    "INDEXED.F002_CLAIMS_MSTR_DTL," +
                    "INDEXED.F002_CLAIMS_MSTR_DESC";
            }
            if (Prompt(2).ToString().ToLower().Equals("purge_f084"))
            {
                backup_table_list =
                    "INDEXED.F084_CLAIMS_INVENTORY";
            }
            if (Prompt(2).ToString().ToLower().Equals("purge_f087"))
            {
                backup_table_list =
                    "INDEXED.F087_SUBMITTED_REJECTED_CLAIMS_HDR," +
                    "INDEXED.F087_SUBMITTED_REJECTED_CLAIMS_DTL";
            }
            if (Prompt(2).ToString().ToLower().Equals("purge_f088"))
            {
                backup_table_list =
                    "INDEXED.F088_RAT_REJECTED_CLAIMS_HIST_HDR," +
                    "INDEXED.F088_RAT_REJECTED_CLAIMS_HIST_DTL";
            }
            if (Prompt(2).ToString().ToLower().Equals("backup_f073_client_doc_mstr"))
            {
                backup_table_list =
                    "INDEXED.F073_CLIENT_DOC_MSTR";
            }
            if (Prompt(2).ToString().ToLower().Equals("f020_doc_mstr_history"))
            {
                backup_table_list =
                    "INDEXED.F020_DOC_MSTR_HISTORY";
            }
            if (Prompt(2).ToString().ToLower().Equals("f110_compensation_history"))
            {
                backup_table_list =
                    "INDEXED.F110_COMPENSATION_HISTORY";
            }
            if (Prompt(2).ToString().ToLower().Equals("f112_pycdceilings_history"))
            {
                backup_table_list =
                    "INDEXED.F112_PYCDCEILINGS_HISTORY";
            }
            if (Prompt(2).ToString().ToLower().Equals("f113_default_comp_history"))
            {
                backup_table_list =
                    "INDEXED.F113_DEFAULT_COMP_HISTORY";
            }
            if (Prompt(2).ToString().ToLower().Equals("f119_doctor_ytd_history"))
            {
                backup_table_list =
                    "INDEXED.F119_DOCTOR_YTD_HISTORY";
            }

            int table_count = 0;
            string[] tables = backup_table_list.Split(',');
            table_count = tables.Length;

            var sql = new StringBuilder("");

            sql.Append(" ");
            sql.Append("BEGIN ");
            sql.Append("  SET NOCOUNT ON ");
            sql.Append("  DECLARE @query  varchar(Max) ");
            sql.Append("  declare @table_list varchar(Max) ");
            sql.Append("  declare @i int ");
            sql.Append("  declare @earningsperiod as int = ").Append(Prompt(1).ToString()).Append(" ");
            sql.Append("  declare @backup_name as varchar(max) = '").Append(backup_database_prefix.ToString()).Append("' ");

            sql.Append("  declare @dbname as varchar(max) = '").Append(Environment.GetEnvironmentVariable("RMABILL_VERS", EnvironmentVariableTarget.Process).ToString().ToUpper()).Append("' ");
            sql.Append("  declare @backupschema as varchar(max) = '").Append(Environment.GetEnvironmentVariable("RMABILL_VERS", EnvironmentVariableTarget.Process).ToString().ToUpper()).Append("_BACKUP' ");
            sql.Append(" ");
            //sql.Append("--  subset below used for testing ");
            //sql.Append("--  select @i=0,  @table_list = 'f020_doctor_mstr,f020_doc_mstr_history,' ");
            sql.Append(" ");
            sql.Append("  select @i=0,   @table_list = '" + backup_table_list + ",' ");
            sql.Append(" ");
            sql.Append("  while( @i < LEN(@table_list)) ");
            sql.Append("  begin ");
            sql.Append("    declare @item varchar(MAX) ");
            sql.Append("    declare @schema_name varchar(MAX) ");
            sql.Append("    declare @table_name varchar(MAX) ");
            sql.Append("    SELECT  @item = SUBSTRING(@table_list,  @i,CHARINDEX(',',@table_list,@i)-@i) ");
            sql.Append("    SET @schema_name = SUBSTRING(@item, 1, charindex('.', @item) - 1)");
            sql.Append("    SET @table_name = SUBSTRING(@item, charindex('.', @item) + 1, LEN(@item))");

            sql.Append(" ");
            sql.Append("      BEGIN TRY ");
            //sql.Append("      -- Check if Schema exists. If Not, Create It. ");
            sql.Append("      SET @query = N' IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = '''  ");
            sql.Append("             +  @backup_name + cast(@earningsperiod as varchar)  + ''')' ");
            sql.Append("             + N' EXEC(''' + 'CREATE SCHEMA ['  + @backup_name + cast(@earningsperiod as varchar)  ");
            sql.Append("             + ']'')'; ");
            //sql.Append("--      Print('Use '+ @backupschema + ';' + @query) ");
            sql.Append("      EXEC ('Use ['+ @backupschema + '];' + @query) ");
            sql.Append(" ");
            //sql.Append("    -- Check if backup table exists and drop it. ");
            //sql.Append("    -- Using sql server 2016 syntax ");
            sql.Append(" ");
            sql.Append("      SET @query = N' DROP TABLE IF EXISTS ' + QUOTENAME(cast(@backupschema as varchar))  + '.' + QUOTENAME(@backup_name + cast(@earningsperiod as varchar)) + '.' + QUOTENAME(@table_name); ");
            //sql.Append("--      Print('Use '+ @backupschema + ';' + @query) ");
            sql.Append("      EXEC ('Use ['+ @backupschema + '];' + @query) ");
            sql.Append(" ");
            sql.Append(" ");
            //sql.Append("    -- create the table here with @table_name  ");
            sql.Append("      SET @query = 'select * into ' +  QUOTENAME(cast(@backupschema as varchar))  + '.' + QUOTENAME(@backup_name + cast(@earningsperiod as varchar)) + '.' + QUOTENAME(@table_name) + ' from '  + QUOTENAME(@dbname) + '.' + QUOTENAME(@schema_name) + '.' + QUOTENAME(@table_name) + ''; ");
            //sql.Append("--           Print( 'Use '+ @backupschema + ';' + @query) ");
            sql.Append("      EXEC ( 'Use ['+ @backupschema + '];' + @query) ");
            sql.Append("    END TRY ");
            sql.Append(" ");
            sql.Append("    BEGIN CATCH ");
            sql.Append("      PRINT Error_message(); ");
            sql.Append("    END CATCH ");
            sql.Append(" ");
            sql.Append("    set @i = CHARINDEX(',',@table_list,@i)+1 ");
            sql.Append("    if(@i = 0) set @i = LEN(@table_list)  ");
            sql.Append("  end ");
            sql.Append("end ");

            try
            {
                var updated = SqlHelper.ExecuteNonQuery(Common.GetSqlConnectionString(), CommandType.Text, sql.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            string source_schema = Environment.GetEnvironmentVariable("RMABILL_VERS", EnvironmentVariableTarget.Process).ToString().ToUpper();
            string backup_schema = Environment.GetEnvironmentVariable("RMABILL_VERS", EnvironmentVariableTarget.Process).ToString().ToUpper() + "_BACKUP";
            string earnings_period = Prompt(1).ToString();

            Console.WriteLine("");

            string temp_schema_name = "";
            string temp_table_name = "";

            int i = 0;
            foreach (string table_name in tables)
            {
                ++i;
                string[] words = table_name.Split('.');
                temp_schema_name = words[0];
                temp_table_name = words[1];

                sql = new StringBuilder("SELECT COUNT(1) FROM " + "[" + backup_schema + "]" + "." + "[" + backup_database_prefix + earnings_period + "]" + "." + "[" + temp_table_name + "]");

                try
                {
                    SqlConnection conn = new SqlConnection(Common.GetSqlConnectionString());
                    conn.Open();
                    SqlCommand comm = new SqlCommand(sql.ToString(), conn);
                    Int32 count = Convert.ToInt32(comm.ExecuteScalar());

                    string record_word = "";
                    if (count == 1) record_word = "record was"; else record_word = "records were";
                    Console.WriteLine("Table " + temp_table_name + " backed up to " + backup_schema + "." + backup_database_prefix + earnings_period + ". " + count.ToString() + " " + record_word + " backed up.");
                    conn.Close(); //Remember close the connection

                    //var count = SqlHelper.ExecuteNonQuery(Common.GetSqlConnectionString(), CommandType.Text, sql.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine("");
            Console.WriteLine("Backup Complete.");
            Console.WriteLine("");

            Console.Write(sb.ToString());

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

    }







    #endregion

    #endregion

}

