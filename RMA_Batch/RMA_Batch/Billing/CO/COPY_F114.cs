
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

public class COPY_F114 : BaseClassControl
{

    private COPY_F114 m_COPY_F114;

    public COPY_F114(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;

    }

    public COPY_F114(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;



    }

    public override void Dispose()
    {
        if ((m_COPY_F114 != null))
        {
            m_COPY_F114.CloseTransactionObjects();
            m_COPY_F114 = null;
        }
    }

    public COPY_F114 GetCOPY_F114(int Level)
    {
        if (m_COPY_F114 == null)
        {
            m_COPY_F114 = new COPY_F114("COPY_F114", Level);
        }
        else
        {
            m_COPY_F114.ResetValues();
        }
        return m_COPY_F114;
    }



    #region "Renaissance Architect Migration Services Default Regions"




    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"


    private StringBuilder sb = new StringBuilder("");
    private int count;

    public override bool RunQTP()
    {

        bool silent = Prompt(1).ToString().ToUpper() == "SILENT" || Prompt(2).ToString().ToUpper() == "SILENT";



        if (Prompt(1).ToString().ToUpper() == "CASCADE")
        {
            Cascade(silent);
        }
        else
        {

            var connectstring = Common.GetSqlConnectionString();

            var replace = connectstring.Substring(connectstring.IndexOf("Initial Catalog"));
            replace = replace.Substring(replace.IndexOf("=") + 1);
            replace = replace.Substring(0, replace.IndexOf(";"));

            var connectstringback = connectstring.Replace(replace, "101C_BACKUP");
            NoCascade(connectstring.Replace(replace, "101C"), connectstringback, "101C", silent);

            connectstringback = connectstring.Replace(replace, "MP_BACKUP");
            NoCascade(connectstring.Replace(replace, "MP"), connectstringback, "MP", silent);

            connectstringback = connectstring.Replace(replace, "SOLO_BACKUP");
            NoCascade(connectstring.Replace(replace, "SOLO"), connectstringback, "SOLO", silent);
        }


        return true;

    }


    public bool Cascade(bool silent)
    {
        try
        {

            var connectstring = Common.GetSqlConnectionString();

            var replace = connectstring.Substring(connectstring.IndexOf("Initial Catalog"));
            replace = replace.Substring(replace.IndexOf("=") + 1);
            replace = replace.Substring(0, replace.IndexOf(";"));

            var connectstringback = connectstring.Replace(replace, replace + "_BACKUP");

            var dtF114_SPECIAL_PAYMENTS = new DataTable();
            var dtF114_SPECIAL_PAYMENTS_1 = new DataTable();
            var dtF114_SPECIAL_PAYMENTS_2 = new DataTable();
            var dtF114_SPECIAL_PAYMENTS_3 = new DataTable();
            var dtF114_SPECIAL_PAYMENTS_4 = new DataTable();



            var sql = new StringBuilder("");
            sql.Append(" SELECT * FROM F114.F114_SPECIAL_PAYMENTS  ");

            try
            {
                dtF114_SPECIAL_PAYMENTS = SqlHelper.ExecuteDataTable(connectstringback, CommandType.Text, sql.ToString());
            }
            catch (Exception)
            {
                if (!silent)
                    Console.WriteLine("Table F114_SPECIAL_PAYMENTS_BK1 does not exist!");
            }
            sql = new StringBuilder("");
            sql.Append(" SELECT * FROM F114.F114_SPECIAL_PAYMENTS_BK1  ");

            try
            {
                dtF114_SPECIAL_PAYMENTS_1 = SqlHelper.ExecuteDataTable(connectstringback, CommandType.Text, sql.ToString());
            }
            catch (Exception)
            {
                if (!silent)
                    Console.WriteLine("Table F114_SPECIAL_PAYMENTS_BK1 does not exist!");
            }
            sql = new StringBuilder("");
            sql.Append(" SELECT * FROM F114.F114_SPECIAL_PAYMENTS_BK2  ");

            try
            {
                dtF114_SPECIAL_PAYMENTS_2 = SqlHelper.ExecuteDataTable(connectstringback, CommandType.Text, sql.ToString());
            }
            catch (Exception)
            {
                if (!silent)
                    Console.WriteLine("Table F114_SPECIAL_PAYMENTS_BK2 does not exist!");
            }
            sql = new StringBuilder("");
            sql.Append(" SELECT * FROM F114.F114_SPECIAL_PAYMENTS_BK3  ");

            try
            {
                dtF114_SPECIAL_PAYMENTS_3 = SqlHelper.ExecuteDataTable(connectstringback, CommandType.Text, sql.ToString());
            }
            catch (Exception)
            {
                if (!silent)
                    Console.WriteLine("Table F114_SPECIAL_PAYMENTS_BK3 does not exist!");
            }
            sql = new StringBuilder("");
            sql.Append(" SELECT * FROM F114.F114_SPECIAL_PAYMENTS_BK4  ");

            try
            {
                dtF114_SPECIAL_PAYMENTS_4 = SqlHelper.ExecuteDataTable(connectstringback, CommandType.Text, sql.ToString());
            }
            catch (Exception)
            {
                if (!silent)
                    Console.WriteLine("Table F114_SPECIAL_PAYMENTS_BK4 does not exist!");
            }




            sql = new StringBuilder("");
            sql.Append(" IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'F114') BEGIN EXEC('CREATE SCHEMA F114') END  ");

            try
            {
                var update = SqlHelper.ExecuteDataTable(connectstringback, CommandType.Text, sql.ToString());
            }
            catch (Exception)
            {
                if (!silent)
                    Console.WriteLine("Could not create Schema F114!");
            }




            AddTable(dtF114_SPECIAL_PAYMENTS, connectstringback, 1, replace, silent);
            AddTable(dtF114_SPECIAL_PAYMENTS_1, connectstringback, 2, replace, silent);
            AddTable(dtF114_SPECIAL_PAYMENTS_2, connectstringback, 3, replace, silent);
            AddTable(dtF114_SPECIAL_PAYMENTS_3, connectstringback, 4, replace, silent);
            AddTable(dtF114_SPECIAL_PAYMENTS_4, connectstringback, 5, replace, silent);









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


    private void AddTable(DataTable dtF114_SPECIAL_PAYMENTS, string connectstringback, int number, string replace, bool silent)
    {

        var sql = new StringBuilder("");
        sql.Append(" SELECT count(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE' AND TABLE_SCHEMA = 'F114' AND TABLE_NAME='F114_SPECIAL_PAYMENTS_BK" + number + "'  ");

        try
        {
            var updated = SqlHelper.ExecuteScalar(connectstringback, CommandType.Text, sql.ToString());

            if (Convert.ToInt32(updated) > 0)
            {
                try
                {
                    sql = new StringBuilder("");
                    sql.Append(" TRUNCATE TABLE F114.F114_SPECIAL_PAYMENTS_BK" + number + " ");

                    var updated2 = SqlHelper.ExecuteNonQuery(connectstringback, CommandType.Text, sql.ToString());
                }
                catch (Exception)
                {
                    if (!silent)
                        Console.WriteLine("Could not Truncate F114.F114_SPECIAL_PAYMENTS ");
                }
            }
            else
            {
                sql = new StringBuilder("");

                sql.Append(" CREATE TABLE [F114].[F114_SPECIAL_PAYMENTS_BK" + number + "]( ").Append(Environment.NewLine);
                sql.Append(" 	[ROWID] [uniqueidentifier] NULL DEFAULT (newid()), ").Append(Environment.NewLine);
                sql.Append(" 	[DOC_NBR] [varchar](3) NOT NULL, ").Append(Environment.NewLine);
                sql.Append(" 	[COMP_CODE] [varchar](6) NOT NULL, ").Append(Environment.NewLine);
                sql.Append(" 	[REC_TYPE] [varchar](1) NOT NULL, ").Append(Environment.NewLine);
                sql.Append(" 	[EP_NBR_FROM] [numeric](6, 0) NOT NULL, ").Append(Environment.NewLine);
                sql.Append(" 	[EP_NBR_TO] [numeric](6, 0) NULL, ").Append(Environment.NewLine);
                sql.Append(" 	[COMP_UNITS] [numeric](6, 0) NULL, ").Append(Environment.NewLine);
                sql.Append(" 	[AMT_GROSS] [numeric](9, 0) NULL, ").Append(Environment.NewLine);
                sql.Append(" 	[AMT_NET] [numeric](9, 0) NULL, ").Append(Environment.NewLine);
                sql.Append(" 	[EP_NBR_ENTRY] [numeric](6, 0) NULL, ").Append(Environment.NewLine);
                sql.Append(" 	[LAST_MOD_DATE] [numeric](8, 0) NULL, ").Append(Environment.NewLine);
                sql.Append(" 	[LAST_MOD_TIME] [numeric](4, 0) NULL, ").Append(Environment.NewLine);
                sql.Append(" 	[LAST_MOD_USER_ID] [varchar](15) NULL, ").Append(Environment.NewLine);
                sql.Append(" 	[CHECKSUM_VALUE] [int] NULL DEFAULT ((0)), ").Append(Environment.NewLine);
                sql.Append(" PRIMARY KEY CLUSTERED  ").Append(Environment.NewLine);
                sql.Append(" ( ").Append(Environment.NewLine);
                sql.Append(" 	[DOC_NBR] ASC, ").Append(Environment.NewLine);
                sql.Append(" 	[COMP_CODE] ASC, ").Append(Environment.NewLine);
                sql.Append(" 	[EP_NBR_FROM] ASC, ").Append(Environment.NewLine);
                sql.Append(" 	[REC_TYPE] ASC ").Append(Environment.NewLine);
                sql.Append(" )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] ").Append(Environment.NewLine);
                sql.Append(" ) ON [PRIMARY] ").Append(Environment.NewLine);


                var updated2 = SqlHelper.ExecuteNonQuery(connectstringback, CommandType.Text, sql.ToString());

            }

        }
        catch (Exception)
        {
            if (!silent)
                Console.WriteLine("Could not create F114 schema in BACKUP");
        }


        try
        {
            using (SqlConnection connection = new SqlConnection(connectstringback))
            {
                connection.Open();

                //Open bulkcopy connection.
                using (SqlBulkCopy bulkcopy = new SqlBulkCopy(connection))
                {
                    //Set destination table name
                    //to table previously created.
                    bulkcopy.DestinationTableName = "F114.F114_SPECIAL_PAYMENTS_BK" + number;

                    try
                    {
                        bulkcopy.WriteToServer(dtF114_SPECIAL_PAYMENTS);
                    }
                    catch (Exception ex)
                    {
                        if (!silent)
                            Console.WriteLine(ex.Message);
                    }

                    connection.Close();
                }
            }


            if (number == 1)
            {
                if (dtF114_SPECIAL_PAYMENTS.Rows.Count == 1)
                {
                    if (!silent)
                        Console.WriteLine("Table F114_SPECIAL_PAYMENTS backed up to " + replace + "_BACKUP.F114.F114_SPECIAL_PAYMENTS_BK1 1 record was backed up");
                }
                else
                {
                    if (!silent)
                        Console.WriteLine("Table F114_SPECIAL_PAYMENTS backed up to " + replace + "_BACKUP.F114.F114_SPECIAL_PAYMENTS_BK1 " + dtF114_SPECIAL_PAYMENTS.Rows.Count + " records were backed up");
                }
            }
            else
            {
                if (dtF114_SPECIAL_PAYMENTS.Rows.Count == 1)
                {
                    if (!silent)
                        Console.WriteLine("Table F114_SPECIAL_PAYMENTS_BK" + (number - 1) + " backed up to " + replace + "_BACKUP.F114.F114_SPECIAL_PAYMENTS_BK" + number + " 1 record was backed up");
                }
                else
                {
                    if (!silent)
                        Console.WriteLine("Table F114_SPECIAL_PAYMENTS_BK" + (number - 1) + " backed up to " + replace + "_BACKUP.F114.F114_SPECIAL_PAYMENTS_BK" + number + " " + dtF114_SPECIAL_PAYMENTS.Rows.Count + " records were backed up");
                }
            }

        }

        catch (Exception)
        {
            if (!silent)
                Console.WriteLine("Could copy table F114_SPECIAL_PAYMENTS");
        }


    }


    public bool NoCascade(string connectstring, string connectstringback, string replace, bool silent)
    {
        try
        {



            var dtF114_SPECIAL_PAYMENTS = new DataTable();




            var sql = new StringBuilder("");
            sql.Append(" SELECT * FROM INDEXED.F114_SPECIAL_PAYMENTS  ");

            try
            {
                dtF114_SPECIAL_PAYMENTS = SqlHelper.ExecuteDataTable(connectstring, CommandType.Text, sql.ToString());
            }
            catch (Exception)
            {
                if (!silent)
                    Console.WriteLine("Table F114_SPECIAL_PAYMENTS does not exist!");
            }


            sql = new StringBuilder("");
            sql.Append(" IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'F114') BEGIN EXEC('CREATE SCHEMA F114') END  ");

            try
            {
                var update = SqlHelper.ExecuteDataTable(connectstringback, CommandType.Text, sql.ToString());
            }
            catch (Exception)
            {
                if (!silent)
                    Console.WriteLine("Could not create Schema F114!");
            }



            sql = new StringBuilder("");
            sql.Append(" SELECT count(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE' AND TABLE_SCHEMA = 'F114' AND TABLE_NAME='F114_SPECIAL_PAYMENTS'  ");

            try
            {
                var updated = SqlHelper.ExecuteScalar(connectstringback, CommandType.Text, sql.ToString());

                if (Convert.ToInt32(updated) > 0)
                {
                    try
                    {
                        sql = new StringBuilder("");
                        sql.Append(" TRUNCATE TABLE F114.F114_SPECIAL_PAYMENTS ");

                        var updated2 = SqlHelper.ExecuteNonQuery(connectstringback, CommandType.Text, sql.ToString());
                    }
                    catch (Exception)
                    {
                        if (!silent)
                            Console.WriteLine("Could not Truncate F114.F114_SPECIAL_PAYMENTS ");
                    }
                }
                else
                {
                    sql = new StringBuilder("");

                    sql.Append(" CREATE TABLE [F114].[F114_SPECIAL_PAYMENTS]( ").Append(Environment.NewLine);
                    sql.Append(" 	[ROWID] [uniqueidentifier] NULL DEFAULT (newid()), ").Append(Environment.NewLine);
                    sql.Append(" 	[DOC_NBR] [varchar](3) NOT NULL, ").Append(Environment.NewLine);
                    sql.Append(" 	[COMP_CODE] [varchar](6) NOT NULL, ").Append(Environment.NewLine);
                    sql.Append(" 	[REC_TYPE] [varchar](1) NOT NULL, ").Append(Environment.NewLine);
                    sql.Append(" 	[EP_NBR_FROM] [numeric](6, 0) NOT NULL, ").Append(Environment.NewLine);
                    sql.Append(" 	[EP_NBR_TO] [numeric](6, 0) NULL, ").Append(Environment.NewLine);
                    sql.Append(" 	[COMP_UNITS] [numeric](6, 0) NULL, ").Append(Environment.NewLine);
                    sql.Append(" 	[AMT_GROSS] [numeric](9, 0) NULL, ").Append(Environment.NewLine);
                    sql.Append(" 	[AMT_NET] [numeric](9, 0) NULL, ").Append(Environment.NewLine);
                    sql.Append(" 	[EP_NBR_ENTRY] [numeric](6, 0) NULL, ").Append(Environment.NewLine);
                    sql.Append(" 	[LAST_MOD_DATE] [numeric](8, 0) NULL, ").Append(Environment.NewLine);
                    sql.Append(" 	[LAST_MOD_TIME] [numeric](4, 0) NULL, ").Append(Environment.NewLine);
                    sql.Append(" 	[LAST_MOD_USER_ID] [varchar](15) NULL, ").Append(Environment.NewLine);
                    sql.Append(" 	[CHECKSUM_VALUE] [int] NULL DEFAULT ((0)), ").Append(Environment.NewLine);
                    sql.Append(" PRIMARY KEY CLUSTERED  ").Append(Environment.NewLine);
                    sql.Append(" ( ").Append(Environment.NewLine);
                    sql.Append(" 	[DOC_NBR] ASC, ").Append(Environment.NewLine);
                    sql.Append(" 	[COMP_CODE] ASC, ").Append(Environment.NewLine);
                    sql.Append(" 	[EP_NBR_FROM] ASC, ").Append(Environment.NewLine);
                    sql.Append(" 	[REC_TYPE] ASC ").Append(Environment.NewLine);
                    sql.Append(" )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] ").Append(Environment.NewLine);
                    sql.Append(" ) ON [PRIMARY] ").Append(Environment.NewLine);


                    var updated2 = SqlHelper.ExecuteNonQuery(connectstringback, CommandType.Text, sql.ToString());

                }

            }
            catch (Exception)
            {
                if (!silent)
                    Console.WriteLine("Could not create F114 schema in BACKUP");
            }


            try
            {
                using (SqlConnection connection = new SqlConnection(connectstringback))
                {
                    connection.Open();

                    //Open bulkcopy connection.
                    using (SqlBulkCopy bulkcopy = new SqlBulkCopy(connection))
                    {
                        //Set destination table name
                        //to table previously created.
                        bulkcopy.DestinationTableName = "F114.F114_SPECIAL_PAYMENTS";

                        try
                        {
                            bulkcopy.WriteToServer(dtF114_SPECIAL_PAYMENTS);
                        }
                        catch (Exception ex)
                        {
                            if (!silent)
                                Console.WriteLine(ex.Message);
                        }

                        connection.Close();
                    }
                }


                if (dtF114_SPECIAL_PAYMENTS.Rows.Count == 1)
                {
                    if (!silent)
                        Console.WriteLine("Table F114_SPECIAL_PAYMENTS backed up to " + replace + "_BACKUP.F114.F114_SPECIAL_PAYMENTS 1 record was backed up");
                }
                else
                {
                    if (!silent)
                        Console.WriteLine("Table F114_SPECIAL_PAYMENTS backed up to " + replace + "_BACKUP.F114.F114_SPECIAL_PAYMENTS " + dtF114_SPECIAL_PAYMENTS.Rows.Count + " records were backed up");
                }


            }

            catch (Exception)
            {
                if (!silent)
                    Console.WriteLine("Could copy table F114_SPECIAL_PAYMENTS");
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


    }



    #endregion

    #endregion

}

