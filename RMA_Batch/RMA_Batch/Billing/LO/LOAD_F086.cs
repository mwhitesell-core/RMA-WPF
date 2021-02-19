
#region "Screen Comments"




#endregion

using Core.DataAccess.SqlServer;
using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;

public class LOAD_F086 : BaseClassControl
{

    private LOAD_F086 m_LOAD_F086;

    public LOAD_F086(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;

    }

    public LOAD_F086(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;



    }

    public override void Dispose()
    {
        if ((m_LOAD_F086 != null))
        {
            m_LOAD_F086.CloseTransactionObjects();
            m_LOAD_F086 = null;
        }
    }

    public LOAD_F086 GetLOAD_F086(int Level)
    {
        if (m_LOAD_F086 == null)
        {
            m_LOAD_F086 = new LOAD_F086("LOAD_F086", Level);
        }
        else
        {
            m_LOAD_F086.ResetValues();
        }
        return m_LOAD_F086;
    }



    #region "Renaissance Architect Migration Services Default Regions"




    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"


    private StringBuilder sb = new StringBuilder("");
    private int count;

    public override bool RunQTP()
    {
        string Filename = Prompt(1).ToString();
        var sql = new StringBuilder("");
        var f086_switch = 0;

        try
        {


            if (!File.Exists(Directory.GetCurrentDirectory() + "/" + Filename))
            {
                var ex = new Exception("File: " + Filename + " does not exist!");
                throw ex;
            }

            if (Filename.ToLower().Equals("f086_pat_id.dat"))
                f086_switch = 1;

            if (Filename.ToLower().Equals("f086a_orig_new_pat_ids.dat"))
                f086_switch = 2;


            if (f086_switch == 1)   // F086_PAT_ID
            {
                sql = new StringBuilder("");
                sql.Append(" TRUNCATE TABLE [INDEXED].[F086_PAT_ID] ");

                try
                {
                    var updated = SqlHelper.ExecuteNonQuery(Common.GetSqlConnectionString(), CommandType.Text, sql.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }





                var sr = new StreamReader(Directory.GetCurrentDirectory() + "/" + Filename);
                var line = sr.ReadLine();
                var text = "";

                while (line != null && line != "")
                {
                    //191

                    while (line != null && line != "")
                    {
                        text = line.Substring(0, 192);
                        line = line.Substring(192);

                        sql = new StringBuilder("INSERT INTO [INDEXED].[F086_PAT_ID]           ([CLMHDR_PAT_OHIP_ID_OR_CHART],[PAT_LAST_BIRTH_DATE],[PAT_LAST_VERSION_CD],[PAT_OLD_SURNAME],[PAT_OLD_GIVEN_NAME],[PAT_OLD_HEALTH_NBR],[PAT_OLD_CHART_NBR] ,[PAT_OLD_CHART_NBR_2],[PAT_OLD_CHART_NBR_3],[PAT_OLD_CHART_NBR_4],[PAT_OLD_CHART_NBR_5],[PAT_OLD_ADDR1],[PAT_OLD_ADDR2] ,[PAT_OLD_ADDR3], [ADUSER])     VALUES           (");

                        sql.Append("'").Append(text.Substring(0, 16).Trim().Replace("'", "''")).Append("',");

                        if (text.Substring(16, 8).Trim() == "")
                        {
                            sql.Append("'").Append("00000000").Append("',");
                        }
                        else
                        {
                            sql.Append("'").Append(text.Substring(16, 8).Trim().Replace("'", "''")).Append("',");
                        }

                        sql.Append("'").Append(text.Substring(24, 2).Trim().Replace("'", "''")).Append("',");
                        sql.Append("'").Append(text.Substring(26, 25).Trim().Replace("'", "''")).Append("',");
                        sql.Append("'").Append(text.Substring(51, 17).Trim().Replace("'", "''")).Append("',");
                        sql.Append("'").Append(text.Substring(68, 10).Trim().Replace("'", "''")).Append("',");
                        sql.Append("'").Append(text.Substring(78, 10).Trim().Replace("'", "''")).Append("',");
                        sql.Append("'").Append(text.Substring(88, 10).Trim().Replace("'", "''")).Append("',");
                        sql.Append("'").Append(text.Substring(98, 10).Trim().Replace("'", "''")).Append("',");
                        sql.Append("'").Append(text.Substring(108, 10).Trim().Replace("'", "''")).Append("',");
                        sql.Append("'").Append(text.Substring(118, 11).Trim().Replace("'", "''")).Append("',");
                        sql.Append("'").Append(text.Substring(129, 21).Trim().Replace("'", "''")).Append("',");
                        sql.Append("'").Append(text.Substring(150, 21).Trim().Replace("'", "''")).Append("',");
                        sql.Append("'").Append(text.Substring(171, 21).Trim().Replace("'", "''")).Append("',");

                        sql.Append("'").Append(System.Security.Principal.WindowsIdentity.GetCurrent().Name).Append("'");

                        sql.Append(")");

                        try
                        {
                            var updated = SqlHelper.ExecuteNonQuery(Common.GetSqlConnectionString(), CommandType.Text, sql.ToString());
                            count += 1;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }

                    line = sr.ReadLine();
                }
            }


            if (f086_switch == 2)   // F086A_ORIG_NEW_PAT_IDS
            {

                sql = new StringBuilder("");
                sql.Append(" TRUNCATE TABLE [INDEXED].[F086A_ORIG_NEW_PAT_IDS] ");

                try
                {
                    var updated = SqlHelper.ExecuteNonQuery(Common.GetSqlConnectionString(), CommandType.Text, sql.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


                var sr = new StreamReader(Directory.GetCurrentDirectory() + "/" + Filename);
                var line = sr.ReadLine();
                var text = "";

                while (line != null && line != "")
                {
                    //86


                    while (line != null && line != "")
                    {
                        text = line.Substring(0, 86);
                        line = line.Substring(86);

                        sql = new StringBuilder("INSERT INTO [INDEXED].[F086A_ORIG_NEW_PAT_IDS]([ORIG_CLMHDR_PAT_OHIP_ID_OR_CHART],[ORIG_PAT_OLD_SURNAME],[ORIG_PAT_OLD_GIVEN_NAME] ,[CLMHDR_PAT_OHIP_ID_OR_CHART],[PAT_OLD_SURNAME],[PAT_OLD_GIVEN_NAME],[ADUSER])     VALUES           (");

                        sql.Append("'").Append(text.Substring(0, 16).Trim().Replace("'", "''")).Append("',");
                        sql.Append("'").Append(text.Substring(16, 15).Trim().Replace("'", "''")).Append("',");
                        sql.Append("'").Append(text.Substring(31, 12).Trim().Replace("'", "''")).Append("',");
                        sql.Append("'").Append(text.Substring(43, 16).Trim().Replace("'", "''")).Append("',");
                        sql.Append("'").Append(text.Substring(59, 15).Trim().Replace("'", "''")).Append("',");
                        sql.Append("'").Append(text.Substring(74, 12).Trim().Replace("'", "''")).Append("',");
                        sql.Append("'").Append(System.Security.Principal.WindowsIdentity.GetCurrent().Name).Append("'");

                        sql.Append(")");

                        try
                        {
                            var updated = SqlHelper.ExecuteNonQuery(Common.GetSqlConnectionString(), CommandType.Text, sql.ToString());
                            count += 1;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }

                    line = sr.ReadLine();
                }

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
            var ex = new Exception("Inserted " + count + " records into " + Filename);
            Console.WriteLine(ex.Message);
        }

    }







    #endregion

    #endregion

}

