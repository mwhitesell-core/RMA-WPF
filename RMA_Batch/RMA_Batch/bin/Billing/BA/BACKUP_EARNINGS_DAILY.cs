
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
        try
        {
            string backup_table_list = "";

            if (Prompt(2).ToString().ToLower().Equals("backup_earnings_daily"))
            {
                backup_table_list =
                    "CONSTANTS_MSTR_REC_1," +
                    "CONSTANTS_MSTR_REC_2," +
                    "CONSTANTS_MSTR_REC_3," +
                    "CONSTANTS_MSTR_REC_4," +
                    "CONSTANTS_MSTR_REC_5," +
                    "CONSTANTS_MSTR_REC_6," +
                    "CONSTANTS_MSTR_REC_7," +
                    "F020_DOCTOR_EXTRA," +
                    "F020_DOCTOR_MSTR," +
                    "F020_DOC_MSTR_HISTORY," +
                    "F050_DOC_REVENUE_MSTR," +
                    "F074_AFP_GROUP_MSTR," +
                    "F074_AFP_GROUP_SEQUENCE_MSTR," +
                    "F075_AFP_DOC_MSTR," +
                    "F095_TEXT_LINES," +
                    "F110_COMPENSATION," +
                    "F110_COMPENSATION_HISTORY," +
                    "F112_PYCDCEILINGS," +
                    "F112_PYCDCEILINGS_HISTORY," +
                    "F113_DEFAULT_COMP," +
                    "F113_DEFAULT_COMP_HISTORY," +
                    "F113_DEFAULT_COMP_UPLOAD_DRIVER," +
                    "F114_SPECIAL_PAYMENTS," +
                    "F115_DEPT_EXPENSE_CALC_CODES," +
                    "F116_DEPT_EXPENSE_RULES_DTL," +
                    "F116_DEPT_EXPENSE_RULES_HDR," +
                    "F119_DOCTOR_YTD," +
                    "F119_DOCTOR_YTD_HISTORY," +
                    "F190_COMP_CODES," +
                    "F191_EARNINGS_PERIOD," +
                    "F198_USER_DEFINED_TOTALS," +
                    "F199_USER_DEFINED_FIELDS," +
                    "ICONST_MSTR_REC";
            }

            if (Prompt(2).ToString().ToLower().Equals("backup_earnings_daily_disk"))
            {
                backup_table_list =
                    "CONSTANTS_MSTR_REC_1," +
                    "CONSTANTS_MSTR_REC_2," +
                    "CONSTANTS_MSTR_REC_3," +
                    "CONSTANTS_MSTR_REC_4," +
                    "CONSTANTS_MSTR_REC_5," +
                    "CONSTANTS_MSTR_REC_6," +
                    "CONSTANTS_MSTR_REC_7," +
                    "F020_DOCTOR_EXTRA," +
                    "F020_DOCTOR_MSTR," +
                    "F020_DOC_MSTR_HISTORY," +
                    "F050_DOC_REVENUE_MSTR," +
                    "F074_AFP_GROUP_MSTR," +
                    "F074_AFP_GROUP_SEQUENCE_MSTR," +
                    "F075_AFP_DOC_MSTR," +
                    "F095_TEXT_LINES," +
                    "F110_COMPENSATION," +
                    "F110_COMPENSATION_HISTORY," +
                    "F112_PYCDCEILINGS," +
                    "F112_PYCDCEILINGS_HISTORY," +
                    "F113_DEFAULT_COMP," +
                    "F113_DEFAULT_COMP_HISTORY," +
                    "F113_DEFAULT_COMP_UPLOAD_DRIVER," +
                    "F114_SPECIAL_PAYMENTS," +
                    "F115_DEPT_EXPENSE_CALC_CODES," +
                    "F116_DEPT_EXPENSE_RULES_DTL," +
                    "F116_DEPT_EXPENSE_RULES_HDR," +
                    "F119_DOCTOR_YTD," +
                    "F119_DOCTOR_YTD_HISTORY," +
                    "F190_COMP_CODES," +
                    "F191_EARNINGS_PERIOD," +
                    "F198_USER_DEFINED_TOTALS," +
                    "F199_USER_DEFINED_FIELDS," +
                    "ICONST_MSTR_REC";
            }

            if (Prompt(2).ToString().ToLower().Equals("backup_earnings_monthend") 
                 || Prompt(2).ToString().ToLower().Equals("backup_earnings_monthend_disk"))
            {
                backup_table_list =
                    "CONSTANTS_MSTR_REC_1," +
                    "CONSTANTS_MSTR_REC_2," +
                    "CONSTANTS_MSTR_REC_3," +
                    "CONSTANTS_MSTR_REC_4," +
                    "CONSTANTS_MSTR_REC_5," +
                    "CONSTANTS_MSTR_REC_6," +
                    "CONSTANTS_MSTR_REC_7," +
                    "F020_DOCTOR_MSTR," +
                    "F020_DOC_MSTR_HISTORY," +
                    "F020_DOCTOR_EXTRA," +
                    "F050_DOC_REVENUE_MSTR," +
                    "F070_DEPT_MSTE," +
                    "F074_AFP_GROUP_MSTR," +
                    "F074_AFP_GROUP_SEQUENCE_MSTR," +
                    "F075_AFP_DOC_MSTR," +
                    "F080_BANK_MSTR," +
                    // "F090_CONSTANTS_MSTR," +                 // Missing F090_CONSTANTS_MSTR. Where is it in DB? 
                    "F095_TEXT_LINES," +
                    "F110_COMPENSATION," +
                    "F110_COMPENSATION_HISTORY," +
                    "F112_PYCDCEILINGS," +
                    "F112_PYCDCEILINGS_HISTORY," +
                    "F113_DEFAULT_COMP," +
                    "F113_DEFAULT_COMP_HISTORY," +
                    "F113_DEFAULT_COMP_UPLOAD_DRIVER," +
                    "F114_SPECIAL_PAYMENTS," +
                    "F115_DEPT_EXPENSE_CALC_CODES," +
                    "F116_DEPT_EXPENSE_RULES_DTL," +
                    "F116_DEPT_EXPENSE_RULES_HDR," +
                    "F119_DOCTOR_YTD," +
                    "F119_DOCTOR_YTD_HISTORY," +
                    "F190_COMP_CODES," +
                    "F191_EARNINGS_PERIOD," +
                    "F198_USER_DEFINED_TOTALS," +
                    "F199_USER_DEFINED_FIELDS," +
                    "ICONST_MSTR_REC";                      // Is this needed?

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
            sql.Append("    SELECT  @item = SUBSTRING(@table_list,  @i,CHARINDEX(',',@table_list,@i)-@i) ");
            sql.Append(" ");
            sql.Append("      BEGIN TRY ");
            //sql.Append("      -- Check if Schema exists. If Not, Create It. ");
            sql.Append("      SET @query = N' IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = '''  ");
            sql.Append("             +  cast(@earningsperiod as varchar)  + ''')' ");
            sql.Append("             + N' EXEC(''' + 'CREATE SCHEMA ['  + cast(@earningsperiod as varchar)  ");
            sql.Append("             + ']'')'; ");
            //sql.Append("--      Print('Use '+ @backupschema + ';' + @query) ");
            sql.Append("      EXEC ('Use ['+ @backupschema + '];' + @query) ");
            sql.Append(" ");
            //sql.Append("    -- Check if backup table exists and drop it. ");
            //sql.Append("    -- Using sql server 2016 syntax ");
            sql.Append(" ");
            sql.Append("      SET @query = N' DROP TABLE IF EXISTS ' + QUOTENAME(cast(@backupschema as varchar))  + '.' + QUOTENAME(cast(@earningsperiod as varchar)) + '.' + QUOTENAME(@item); ");
            //sql.Append("--      Print('Use '+ @backupschema + ';' + @query) ");
            sql.Append("      EXEC ('Use ['+ @backupschema + '];' + @query) ");
            sql.Append(" ");
            sql.Append(" ");
            //sql.Append("    -- create the table here with @item  ");
            sql.Append("      SET @query = 'select * into ' +  QUOTENAME(cast(@backupschema as varchar))  + '.' + QUOTENAME(cast(@earningsperiod as varchar)) + '.' + QUOTENAME(@item) + ' from '  + QUOTENAME(@dbname) + '.' + QUOTENAME('INDEXED') + '.' + QUOTENAME(@item) + ''; ");
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

            int i = 0;
            foreach (string table_name in tables)
            {
                ++i;

                sql = new StringBuilder("SELECT COUNT(1) FROM " + "[" + backup_schema + "]" + "." + "[" + earnings_period + "]" + "." + "[" + table_name + "]");

                try
                {
                    SqlConnection conn = new SqlConnection(Common.GetSqlConnectionString());
                    conn.Open();
                    SqlCommand comm = new SqlCommand(sql.ToString(), conn);
                    Int32 count = Convert.ToInt32(comm.ExecuteScalar());

                    string record_word = "";
                    if (count == 1) record_word = "record was"; else record_word = "records were";
                    Console.WriteLine("Table " + table_name + " backed up to " + backup_schema + "." + earnings_period + ". " + count.ToString() + " " + record_word + " backed up.");
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

