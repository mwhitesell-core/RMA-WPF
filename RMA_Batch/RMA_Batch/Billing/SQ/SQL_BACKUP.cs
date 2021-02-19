
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

public class SQL_BACKUP : BaseClassControl
{

    private SQL_BACKUP m_SQL_BACKUP;

    public SQL_BACKUP(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;

    }

    public SQL_BACKUP(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;



    }

    public override void Dispose()
    {
        if ((m_SQL_BACKUP != null))
        {
            m_SQL_BACKUP.CloseTransactionObjects();
            m_SQL_BACKUP = null;
        }
    }

    public SQL_BACKUP GetSQL_BACKUP(int Level)
    {
        if (m_SQL_BACKUP == null)
        {
            m_SQL_BACKUP = new SQL_BACKUP("SQL_BACKUP", Level);
        }
        else
        {
            m_SQL_BACKUP.ResetValues();
        }
        return m_SQL_BACKUP;
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

