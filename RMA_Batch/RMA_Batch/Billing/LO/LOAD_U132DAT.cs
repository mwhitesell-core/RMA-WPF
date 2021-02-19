
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

public class LOAD_U132DAT : BaseClassControl
{

    private LOAD_U132DAT m_LOAD_U132DAT;

    public LOAD_U132DAT(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;

    }

    public LOAD_U132DAT(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;



    }

    public override void Dispose()
    {
        if ((m_LOAD_U132DAT != null))
        {
            m_LOAD_U132DAT.CloseTransactionObjects();
            m_LOAD_U132DAT = null;
        }
    }

    public LOAD_U132DAT GetLOAD_U132DAT(int Level)
    {
        if (m_LOAD_U132DAT == null)
        {
            m_LOAD_U132DAT = new LOAD_U132DAT("LOAD_U132DAT", Level);
        }
        else
        {
            m_LOAD_U132DAT.ResetValues();
        }
        return m_LOAD_U132DAT;
    }



    #region "Renaissance Architect Migration Services Default Regions"




    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"


    private StringBuilder sb = new StringBuilder("");
    private int count;

    public override bool RunQTP()
    {
        try
        {
            int SEQ_NBR = Convert.ToInt32(Prompt(1));
            string Filename = Prompt(2).ToString();
            string ProcessType = Prompt(3).ToString();
            var sql = new StringBuilder("");

            if (!File.Exists(Directory.GetCurrentDirectory() + "/" + Filename))
            {
                var ex = new Exception("File: " + Filename + " does not exist!");
                throw ex;
            }


            sql = new StringBuilder("");
            sql.Append(" TRUNCATE TABLE [SEQUENTIAL].[U132DAT] ");

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
           

            while (line != null)
            {

                var linecolumns = line.Split(',');
                if (linecolumns.Length != 5)
                {
                    var ex = new Exception("File: " + Filename + " is in the wrong format!");
                    throw ex;
                }

                sql = new StringBuilder("INSERT INTO [SEQUENTIAL].[U132DAT]([DOC_NBR],[DOC_NAME],[DOC_INITS] ,[SIGNED_AMT_NET],[COMP_CODE])     VALUES           (");

                sql.Append("'").Append(linecolumns[0].ToString().Trim()).Append("',");
                sql.Append("'").Append(linecolumns[1].ToString().Trim()).Append("',");
                sql.Append("'").Append(linecolumns[2].ToString().Trim()).Append("',");
                sql.Append("'").Append((Convert.ToInt32(linecolumns[3]) * 100).ToString().Trim()).Append("',");
                sql.Append("'").Append(linecolumns[4].ToString().Trim()).Append("'");


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
            var ex = new Exception("Inserted " + count + " records into U132DAT");
            Console.WriteLine(ex.Message);
        }

    }







    #endregion

    #endregion

}

