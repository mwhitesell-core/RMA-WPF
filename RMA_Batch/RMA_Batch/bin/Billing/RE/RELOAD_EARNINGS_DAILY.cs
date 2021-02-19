
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



public class RELOAD_EARNINGS_DAILY : BaseClassControl
{

    private RELOAD_EARNINGS_DAILY m_RELOAD_EARNINGS_DAILY;

    public RELOAD_EARNINGS_DAILY(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;



    }

    public RELOAD_EARNINGS_DAILY(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;



    }

    public override void Dispose()
    {
        if ((m_RELOAD_EARNINGS_DAILY != null))
        {
            m_RELOAD_EARNINGS_DAILY.CloseTransactionObjects();
            m_RELOAD_EARNINGS_DAILY = null;
        }
    }

    public RELOAD_EARNINGS_DAILY GetRELOAD_EARNINGS_DAILY(int Level)
    {
        if (m_RELOAD_EARNINGS_DAILY == null)
        {
            m_RELOAD_EARNINGS_DAILY = new RELOAD_EARNINGS_DAILY("RELOAD_EARNINGS_DAILY", Level);
        }
        else
        {
            m_RELOAD_EARNINGS_DAILY.ResetValues();
        }
        return m_RELOAD_EARNINGS_DAILY;
    }



    #region "Renaissance Architect Migration Services Default Regions"




    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"


    private StringBuilder sb = new StringBuilder("");
    void conn_InfoMessage(object sender, SqlInfoMessageEventArgs e)
    {
        sb.AppendLine(e.Message);
    }


    public override bool RunQTP()
    {
        try
        {
            string reload_table_list = "";
            var sql = new StringBuilder("");
            bool all_tables_found = false;

            string source_schema = Environment.GetEnvironmentVariable("RMABILL_VERS", EnvironmentVariableTarget.Process).ToString().ToUpper();
            string backup_schema = Environment.GetEnvironmentVariable("RMABILL_VERS", EnvironmentVariableTarget.Process).ToString().ToUpper() + "_BACKUP";
            string earnings_period = Prompt(1).ToString();

            reload_table_list =
                "CONSTANTS_MSTR_REC_1," +
                "CONSTANTS_MSTR_REC_2," +
                "CONSTANTS_MSTR_REC_3," +
                "CONSTANTS_MSTR_REC_4," +
                "CONSTANTS_MSTR_REC_5," +
                "CONSTANTS_MSTR_REC_6," +
                "CONSTANTS_MSTR_REC_7," +
                //"F020C_DOC_CLINIC_NEXT_BATCH_NBR," +      // Where did this come from?
                //"F020L_DOC_LOCATIONS," +                  // Where did this come from?
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

            int table_count = 0;
            string[] tables = reload_table_list.Split(',');
            table_count = tables.Length;

            // First, make sure all the tables exist in the backup schema before proceding

            all_tables_found = true;

            int i = 0;
            foreach (string table_name in tables)
            {
                ++i;
                sql = new StringBuilder("SELECT COUNT(1) FROM " + "[" + backup_schema + "]" + "." + "[" + earnings_period + "]" + "." + "[" + table_name + "]");

                try
                {
                    // If an error is thrown on a count(1), then table does not exists. Write to the console.
                    SqlConnection conn = new SqlConnection(Common.GetSqlConnectionString());
                    conn.Open();
                    SqlCommand comm = new SqlCommand(sql.ToString(), conn);
                    Int32 count = Convert.ToInt32(comm.ExecuteScalar());
                    conn.Close(); 
                }
                catch (Exception ex)
                {
                    if (all_tables_found == true)
                        Console.WriteLine("");          // Print a blank line before first error

                    all_tables_found = false;
                    Console.WriteLine("Error: Table " + table_name + " was not found in " + "[" + backup_schema + "]" + "." + "[" + earnings_period + "]");
                }
            }

            if (all_tables_found == true)
            {
                sql.Append("BEGIN ");
                sql.Append("  SET NOCOUNT ON ");
                sql.Append("  DECLARE @query  varchar(Max) ");
                sql.Append("  declare @table_list varchar(Max) ");
                sql.Append("  declare @schema varchar(Max) ");
                sql.Append("  declare @i int ");
                sql.Append("  declare @missing int ");
                sql.Append("  declare @earningsperiod as int = ").Append(Prompt(1).ToString()).Append(" ");
                sql.Append("  declare @dbname as varchar(max) = '").Append(Environment.GetEnvironmentVariable("RMABILL_VERS", EnvironmentVariableTarget.Process).ToString().ToUpper()).Append("' ");
                sql.Append("  declare @backupschema as varchar(max) = '").Append(Environment.GetEnvironmentVariable("RMABILL_VERS", EnvironmentVariableTarget.Process).ToString().ToUpper()).Append("_BACKUP' ");
                sql.Append(" ");

                sql.Append("  select @i=0,   @table_list = '" + reload_table_list + ",' ");
                //sql.Append("  select @i=0,   @table_list = 'F020_DOCTOR_MSTR,F020C_DOC_CLINIC_NEXT_BATCH_NBR,F020L_DOC_LOCATIONS,F020_DOC_MSTR_HISTORY,F020_DOCTOR_EXTRA,F074_AFP_GROUP_MSTR,F074_AFP_GROUP_SEQUENCE_MSTR,F075_AFP_DOC_MSTR,ICONST_MSTR_REC,CONSTANTS_MSTR_REC_1,CONSTANTS_MSTR_REC_2,CONSTANTS_MSTR_REC_3,CONSTANTS_MSTR_REC_4,CONSTANTS_MSTR_REC_5,CONSTANTS_MSTR_REC_6,CONSTANTS_MSTR_REC_7,F050_DOC_REVENUE_MSTR,F095_TEXT_LINES,F110_COMPENSATION,F110_COMPENSATION_HISTORY,F112_PYCDCEILINGS,F112_PYCDCEILINGS_HISTORY,F113_DEFAULT_COMP,F113_DEFAULT_COMP_HISTORY,F113_DEFAULT_COMP_UPLOAD_DRIVER,F114_SPECIAL_PAYMENTS,F115_DEPT_EXPENSE_CALC_CODES,F116_DEPT_EXPENSE_RULES_DTL,F116_DEPT_EXPENSE_RULES_HDR,F119_DOCTOR_YTD,F119_DOCTOR_YTD_HISTORY,F198_USER_DEFINED_TOTALS,F199_USER_DEFINED_FIELDS,F190_COMP_CODES,F191_EARNINGS_PERIOD,' ");

                sql.Append("  select @schema='INDEXED' ");
                sql.Append(" ");
                sql.Append("  IF @missing <> 0 ");
                sql.Append("    PRINT 'Severe Error: Missing backup tables from backup datatabase for this earnings period. Unable to perform Complete restore....'; ");
                sql.Append("  ELSE ");
                sql.Append(" ");
                sql.Append("  BEGIN ");
                sql.Append("    while( @i < LEN(@table_list)) ");
                sql.Append("    begin ");
                sql.Append("      declare @item varchar(MAX) ");
                sql.Append("      SELECT  @item = SUBSTRING(@table_list,  @i,CHARINDEX(',',@table_list,@i)-@i) ");
                sql.Append(" ");
                sql.Append("      BEGIN TRY ");
                sql.Append(" ");
                sql.Append("        SET @query = N' IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = '''  ");
                sql.Append("               +  cast(@schema as varchar)  + ''')' ");
                sql.Append("               + N' EXEC(''' + 'CREATE SCHEMA '  + cast(@schema as varchar)  ");
                sql.Append("               + ''')'; ");
                sql.Append(" ");
                sql.Append("        EXEC ('Use '+ @backupschema + ';' + @query) ");
                sql.Append(" ");
                sql.Append("        SET @query = N' DROP TABLE IF EXISTS ' + QUOTENAME(cast(@dbname as varchar))  + '.' + QUOTENAME(cast(@schema as varchar)) + '.' + QUOTENAME(@item); ");
                sql.Append("        EXEC ('Use '+ @backupschema + ';' + @query) ");
                sql.Append(" ");
                sql.Append("        SET @query = 'select * into ' +  QUOTENAME(cast(@dbname as varchar))  + '.' + QUOTENAME(cast(@schema as varchar)) + '.' + QUOTENAME(@item) + ' from '  + QUOTENAME(@backupschema) + '.' + QUOTENAME(@earningsperiod) + '.' + QUOTENAME(@item) + ''; ");
                sql.Append(" ");
                sql.Append("        EXEC ( 'Use '+ @backupschema + ';' + @query) ");
                sql.Append("      END TRY ");
                sql.Append(" ");
                sql.Append("      BEGIN CATCH ");
                sql.Append("        PRINT Error_message(); ");
                sql.Append("      END CATCH ");
                sql.Append(" ");
                sql.Append("      set @i = CHARINDEX(',',@table_list,@i)+1 ");
                sql.Append("      if(@i = 0) set @i = LEN(@table_list)  ");
                sql.Append("    end ");
                sql.Append("  END ");
                sql.Append("end ");

                try
                {
                    var updated = SqlHelper.ExecuteNonQuery(Common.GetSqlConnectionString(), CommandType.Text, sql.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine("");

                i = 0;
                foreach (string table_name in tables)
                {
                    ++i;
                    sql = new StringBuilder("SELECT COUNT(1) FROM " + "[" + source_schema + "]" + "." + "INDEXED" + "." + "[" + table_name + "]");

                    try
                    {
                        SqlConnection conn = new SqlConnection(Common.GetSqlConnectionString());
                        conn.Open();
                        SqlCommand comm = new SqlCommand(sql.ToString(), conn);
                        Int32 count = Convert.ToInt32(comm.ExecuteScalar());

                        string record_word = "";
                        if (count == 1) record_word = "record was"; else record_word = "records were";
                        Console.WriteLine("Table " + table_name + " reloaded from " + backup_schema + "." + earnings_period + ". " + count.ToString() + " " + record_word + " reloaded.");
                        conn.Close(); //Remember close the connection
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            Console.WriteLine("");

            if (all_tables_found == true)
                Console.WriteLine("Reload Completed.");
            else
                Console.WriteLine("Reload Not completed. Missing tables.");

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
