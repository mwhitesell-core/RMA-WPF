
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

public class COPY_F113 : BaseClassControl
{

    private COPY_F113 m_COPY_F113;

    public COPY_F113(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;

    }

    public COPY_F113(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;



    }

    public override void Dispose()
    {
        if ((m_COPY_F113 != null))
        {
            m_COPY_F113.CloseTransactionObjects();
            m_COPY_F113 = null;
        }
    }

    public COPY_F113 GetCOPY_F113(int Level)
    {
        if (m_COPY_F113 == null)
        {
            m_COPY_F113 = new COPY_F113("COPY_F113", Level);
        }
        else
        {
            m_COPY_F113.ResetValues();
        }
        return m_COPY_F113;
    }



    #region "Renaissance Architect Migration Services Default Regions"




    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"


    private StringBuilder sb = new StringBuilder("");
    private int count;

    public override bool RunQTP()
    {
        try
        {

            var connectstring = Common.GetSqlConnectionString();

            var replace = connectstring.Substring(connectstring.IndexOf("Initial Catalog"));
            replace = replace.Substring(replace.IndexOf("=") + 1);
            replace = replace.Substring(0, replace.IndexOf(";"));

            var connectstringback = connectstring.Replace(replace, replace + "_BACKUP");

            var dtF113_DEFAULT_COMP = new DataTable();
            var dtF113_DEFAULT_COMP_UPLOAD_DRIVER = new DataTable();



            var sql = new StringBuilder("");
            sql.Append(" SELECT * FROM INDEXED.F113_DEFAULT_COMP  ");

            try
            {
                dtF113_DEFAULT_COMP = SqlHelper.ExecuteDataTable(connectstring, CommandType.Text, sql.ToString());
            }
            catch (Exception)
            {
                Console.WriteLine("Table F113_DEFAULT_COMP does not exist!");
            }

            sql = new StringBuilder("");
            sql.Append(" SELECT * FROM INDEXED.F113_DEFAULT_COMP_UPLOAD_DRIVER  ");

            try
            {
                dtF113_DEFAULT_COMP_UPLOAD_DRIVER = SqlHelper.ExecuteDataTable(connectstring, CommandType.Text, sql.ToString());
            }
            catch (Exception)
            {
                Console.WriteLine("Table F113_DEFAULT_COMP_UPLOAD_DRIVER does not exist!");
            }


            sql = new StringBuilder("");
            sql.Append(" IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'F113') BEGIN EXEC('CREATE SCHEMA F113') END  ");

            try
            {
                var update = SqlHelper.ExecuteDataTable(connectstringback, CommandType.Text, sql.ToString());
            }
            catch (Exception)
            {
                Console.WriteLine("Could not create Schema F113!");
            }


            sql = new StringBuilder("");
            sql.Append(" SELECT count(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE' AND TABLE_SCHEMA = 'F113' AND TABLE_NAME='F113_DEFAULT_COMP'  ");

            try
            {
                var updated = SqlHelper.ExecuteScalar(connectstringback, CommandType.Text, sql.ToString());

                if (Convert.ToInt32(updated) > 0)
                {
                    try
                    {
                        sql = new StringBuilder("");
                        sql.Append(" TRUNCATE TABLE F113.F113_DEFAULT_COMP ");

                        var updated2 = SqlHelper.ExecuteNonQuery(connectstringback, CommandType.Text, sql.ToString());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Could not Truncate F113.F113_DEFAULT_COMP ");
                    }
                }
                else
                {
                    sql = new StringBuilder("");

                    sql.Append(" CREATE TABLE [F113].[F113_DEFAULT_COMP]( ").Append(Environment.NewLine);
                    sql.Append(" 	[ROWID] [uniqueidentifier] NULL DEFAULT (newid()), ").Append(Environment.NewLine);
                    sql.Append(" 	[DOC_NBR] [varchar](3) NOT NULL, ").Append(Environment.NewLine);
                    sql.Append(" 	[EP_NBR_FROM] [numeric](6, 0) NOT NULL, ").Append(Environment.NewLine);
                    sql.Append(" 	[COMP_CODE] [varchar](6) NOT NULL, ").Append(Environment.NewLine);
                    sql.Append(" 	[EP_NBR_TO] [numeric](6, 0) NULL, ").Append(Environment.NewLine);
                    sql.Append(" 	[FACTOR] [numeric](6, 0) NULL, ").Append(Environment.NewLine);
                    sql.Append(" 	[FACTOR_OVERRIDE] [varchar](1) NULL, ").Append(Environment.NewLine);
                    sql.Append(" 	[COMP_UNITS] [numeric](6, 0) NULL, ").Append(Environment.NewLine);
                    sql.Append(" 	[AMT_GROSS] [numeric](9, 0) NULL, ").Append(Environment.NewLine);
                    sql.Append(" 	[AMT_NET] [numeric](9, 0) NULL, ").Append(Environment.NewLine);
                    sql.Append(" 	[EP_NBR_ENTRY] [numeric](6, 0) NULL, ").Append(Environment.NewLine);
                    sql.Append(" 	[LAST_MOD_DATE] [numeric](8, 0) NULL, ").Append(Environment.NewLine);
                    sql.Append(" 	[LAST_MOD_TIME] [numeric](4, 0) NULL, ").Append(Environment.NewLine);
                    sql.Append(" 	[LAST_MOD_USER_ID] [varchar](15) NULL, ").Append(Environment.NewLine);
                    sql.Append(" 	[CORE_COMMENT] [varchar](20) NULL, ").Append(Environment.NewLine);
                    sql.Append(" 	[FILLER] [varchar](18) NULL, ").Append(Environment.NewLine);
                    sql.Append(" 	[CHECKSUM_VALUE] [int] NULL DEFAULT ((0)), ").Append(Environment.NewLine);
                    sql.Append(" PRIMARY KEY CLUSTERED  ").Append(Environment.NewLine);
                    sql.Append(" ( ").Append(Environment.NewLine);
                    sql.Append(" 	[DOC_NBR] ASC, ").Append(Environment.NewLine);
                    sql.Append(" 	[EP_NBR_FROM] ASC, ").Append(Environment.NewLine);
                    sql.Append(" 	[COMP_CODE] ASC ").Append(Environment.NewLine);
                    sql.Append(" )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] ").Append(Environment.NewLine);
                    sql.Append(" ) ON [PRIMARY] ").Append(Environment.NewLine);


                    var updated2 = SqlHelper.ExecuteNonQuery(connectstringback, CommandType.Text, sql.ToString());

                }

            }
            catch (Exception)
            {
                Console.WriteLine("Could not create F113 schema in BACKUP");
            }


            try
            {
                using (SqlConnection connection =        new SqlConnection(connectstringback))
                {
                    connection.Open();

                    //Open bulkcopy connection.
                    using (SqlBulkCopy bulkcopy = new SqlBulkCopy(connection))
                    {
                        //Set destination table name
                        //to table previously created.
                        bulkcopy.DestinationTableName = "F113.F113_DEFAULT_COMP";

                        try
                        {
                            bulkcopy.WriteToServer(dtF113_DEFAULT_COMP);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        connection.Close();
                    }
                }


                if (dtF113_DEFAULT_COMP.Rows.Count == 1)
                {
                    Console.WriteLine("Table F113_DEFAULT_COMP backed up to " + replace + "_BACKUP.F113. 1 record was backed up");
                }
                else
                {
                    Console.WriteLine("Table F113_DEFAULT_COMP backed up to " + replace + "_BACKUP.F113. " + dtF113_DEFAULT_COMP.Rows.Count + " records were backed up");
                }
               

            }

            catch (Exception)
            {
                Console.WriteLine("Could copy table F113_DEFAULT_COMP");
            }




            //***********Driver

            sql = new StringBuilder("");
            sql.Append(" SELECT count(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE' AND TABLE_SCHEMA = 'F113' AND TABLE_NAME='F113_DEFAULT_COMP_UPLOAD_DRIVER'  ");

            try
            {
                var updated = SqlHelper.ExecuteScalar(connectstringback, CommandType.Text, sql.ToString());

                if (Convert.ToInt32(updated) > 0)
                {
                    try
                    {
                        sql = new StringBuilder("");
                        sql.Append(" TRUNCATE TABLE F113.F113_DEFAULT_COMP_UPLOAD_DRIVER ");

                        var updated2 = SqlHelper.ExecuteNonQuery(connectstringback, CommandType.Text, sql.ToString());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Could not Truncate F113.F113_DEFAULT_COMP_UPLOAD_DRIVER ");
                    }
                }
                else
                {
                    sql = new StringBuilder("");

                    sql.Append(" CREATE TABLE [F113].[F113_DEFAULT_COMP_UPLOAD_DRIVER]( ").Append(Environment.NewLine);
                    sql.Append(" 	[ROWID] [uniqueidentifier] NULL DEFAULT (newid()), ").Append(Environment.NewLine);
                    sql.Append(" 	[SEQ_NBR] [numeric](5, 0) NOT NULL, ").Append(Environment.NewLine);
                    sql.Append(" 	[COLUMN_NBR_DOC_NBR] [numeric](3, 0) NULL, ").Append(Environment.NewLine);
                    sql.Append(" 	[COLUMN_NBR_DOC_SURNAME] [numeric](3, 0) NULL, ").Append(Environment.NewLine);
                    sql.Append(" 	[COLUMN_NBR_DOC_INITS] [numeric](3, 0) NULL, ").Append(Environment.NewLine);
                    sql.Append(" 	[COLUMN_NBR_DOC_GIVEN_NAMES] [numeric](3, 0) NULL, ").Append(Environment.NewLine);
                    sql.Append(" 	[COLUMN_NBR_AMT] [numeric](3, 0) NULL, ").Append(Environment.NewLine);
                    sql.Append(" 	[COLUMN_NBR_COMP_CODE] [numeric](3, 0) NULL, ").Append(Environment.NewLine);
                    sql.Append(" 	[CHECKSUM_VALUE] [int] NULL DEFAULT ((0)), ").Append(Environment.NewLine);
                    sql.Append(" PRIMARY KEY CLUSTERED  ").Append(Environment.NewLine);
                    sql.Append(" ( ").Append(Environment.NewLine);
                    sql.Append(" 	[SEQ_NBR] ASC ").Append(Environment.NewLine);
                    sql.Append(" )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] ").Append(Environment.NewLine);
                    sql.Append(" ) ON [PRIMARY] ").Append(Environment.NewLine);


                    var updated2 = SqlHelper.ExecuteNonQuery(connectstringback, CommandType.Text, sql.ToString());

                }

            }
            catch (Exception)
            {
                Console.WriteLine("Could not create F113 schema in BACKUP");
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
                        bulkcopy.DestinationTableName = "F113.F113_DEFAULT_COMP_UPLOAD_DRIVER";

                        try
                        {
                            bulkcopy.WriteToServer(dtF113_DEFAULT_COMP_UPLOAD_DRIVER);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        connection.Close();
                    }
                }


                if (dtF113_DEFAULT_COMP_UPLOAD_DRIVER.Rows.Count == 1)
                {
                    Console.WriteLine("Table F113_DEFAULT_COMP_UPLOAD_DRIVER backed up to " + replace + "_BACKUP.F113.F113_DEFAULT_COMP_UPLOAD_DRIVER 1 record was backed up");
                }
                else
                {
                    Console.WriteLine("Table F113_DEFAULT_COMP_UPLOAD_DRIVER backed up to " + replace + "_BACKUP.F113.F113_DEFAULT_COMP_UPLOAD_DRIVER " + dtF113_DEFAULT_COMP_UPLOAD_DRIVER.Rows.Count + " records were backed up");
                }


            }

            catch (Exception)
            {
                Console.WriteLine("Could copy table F113_DEFAULT_COMP_UPLOAD_DRIVER");
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

