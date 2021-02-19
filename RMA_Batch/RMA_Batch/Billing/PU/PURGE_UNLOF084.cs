//  2015/Sep/14 - MC - delete f084-claims-inventory
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

public class PURGE_UNLOF084 : BaseClassControl
{

    private PURGE_UNLOF084 m_PURGE_UNLOF084;

    public PURGE_UNLOF084(string Name, int Level) :
            base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
        CONNSTRING = new CoreCharacter("CONNSTRING", 200, this, ResetTypes.ResetAtStartup, ConfigurationManager.AppSettings["ConnectionString1"]);
    }

    public PURGE_UNLOF084(string Name, int Level, bool Request) :
            base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
        CONNSTRING = new CoreCharacter("CONNSTRING", 200, this, ResetTypes.ResetAtStartup, ConfigurationManager.AppSettings["ConnectionString1"]);
    }

    public override void Dispose()
    {
        if (!(m_PURGE_UNLOF084 == null))
        {
            m_PURGE_UNLOF084.CloseTransactionObjects();
            m_PURGE_UNLOF084 = null;
        }

    }

    public PURGE_UNLOF084 GetPURGE_UNLOF084(int Level)
    {
        if ((m_PURGE_UNLOF084 == null))
        {
            m_PURGE_UNLOF084 = new PURGE_UNLOF084("PURGE_UNLOF084", Level);
        }
        else
        {
            m_PURGE_UNLOF084.ResetValues();
        }

        return m_PURGE_UNLOF084;
    }

    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.
    protected SqlConnection m_cnnQUERY = new SqlConnection();
    protected SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
    protected SqlTransaction m_trnTRANS_UPDATE;

    protected CoreCharacter CONNSTRING;

    public override bool RunQTP()
    {
        try
        {
            PURGE_UNLOF084_DELETE_F084_1 DELETE_F084_1 = new PURGE_UNLOF084_DELETE_F084_1(Name, Level);
            DELETE_F084_1.Run();
            DELETE_F084_1.Dispose();
            DELETE_F084_1 = null;

            //PURGE_UNLOF084_UNLO_F084_2 UNLO_F084_2 = new PURGE_UNLOF084_UNLO_F084_2(Name, Level);
            //UNLO_F084_2.Run();
            //UNLO_F084_2.Dispose();
            //UNLO_F084_2 = null;

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
}
public class PURGE_UNLOF084_DELETE_F084_1 : PURGE_UNLOF084
{

    public PURGE_UNLOF084_DELETE_F084_1(string Name, int Level) :
            base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;

        fleF084_CLAIMS_INVENTORY = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F084_CLAIMS_INVENTORY", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleSAVEF084_DELETE = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "SAVEF084_DELETE", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF084_CLAIMS_INVENTORY.Choose += fleF084_CLAIMS_INVENTORY_Choose;
    }

    private SqlFileObject fleF084_CLAIMS_INVENTORY;

    private void fleF084_CLAIMS_INVENTORY_Choose(ref string ChooseClause)
    {
        try
        {
            StringBuilder strSQL = new StringBuilder("");
            if ((!(Prompt(2) == null)
                        && (Prompt(2).ToString().Length > 0)))
            {
                strSQL.Append(fleF084_CLAIMS_INVENTORY.ElementOwner("ICONST_DATE_PERIOD_END"));
                strSQL.Append(" BETWEEN ");
                strSQL.Append(Common.StringToField(Prompt(1).ToString())).Append(" AND ").Append(Common.StringToField(Prompt(2).ToString()));
            }

            ChooseClause = strSQL.ToString();
        }
        catch (CustomApplicationException ex)
        {
            WriteError(ex);
        }
        catch (Exception ex)
        {
            WriteError(ex);
        }

    }

    private SqlFileObject fleSAVEF084_DELETE;

    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 2019-08-13 8:04:53 AM
    // #-----------------------------------------
    // # InitializeTransactionObjects Procedure.
    // #-----------------------------------------
    protected override void InitializeTransactionObjects()
    {
        try
        {
            m_cnnTRANS_UPDATE = new SqlConnection(Common.GetSqlConnectionString());
            m_cnnTRANS_UPDATE.Open();
            m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
            m_cnnQUERY = new SqlConnection(Common.GetSqlConnectionString());
        }
        catch (CustomApplicationException ex)
        {
            throw ex;
        }
        catch (Exception ex)
        {
            ExceptionManager.Publish(ex);
            throw ex;
        }

    }

    // #-----------------------------------------
    // # CloseTransactionObjects Procedure.
    // #-----------------------------------------
    protected override void CloseTransactionObjects()
    {
        try
        {
            this.CloseFiles();
            if (!(m_trnTRANS_UPDATE == null))
            {
                m_trnTRANS_UPDATE.Dispose();
            }

            if (!(m_cnnTRANS_UPDATE == null))
            {
                m_cnnTRANS_UPDATE.Close();
            }

            if (!(m_cnnTRANS_UPDATE == null))
            {
                m_cnnTRANS_UPDATE.Dispose();
            }

            if (!(m_cnnQUERY == null))
            {
                m_cnnQUERY.Close();
            }

            if (!(m_cnnQUERY == null))
            {
                m_cnnQUERY.Dispose();
            }

        }
        catch (CustomApplicationException ex)
        {
            throw ex;
        }
        catch (Exception ex)
        {
            ExceptionManager.Publish(ex);
            throw ex;
        }

    }

    protected override void TRANS_UPDATE(TransactionMethods Method)
    {
        if ((Method == TransactionMethods.Rollback))
        {
            m_trnTRANS_UPDATE.Rollback();
        }
        else
        {
            m_trnTRANS_UPDATE.Commit();
        }

        m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
        this.Initialize_TRANS_UPDATE();
    }

    private void Initialize_TRANS_UPDATE()
    {
        fleF084_CLAIMS_INVENTORY.Transaction = m_trnTRANS_UPDATE;
        fleSAVEF084_DELETE.Transaction = m_trnTRANS_UPDATE;
    }

    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 2019-08-13 8:04:53 AM
    // #-----------------------------------------
    // # InitializeFiles Procedure.
    // #-----------------------------------------
    protected override void InitializeFiles()
    {
        try
        {
            this.Initialize_TRANS_UPDATE();
        }
        catch (CustomApplicationException ex)
        {
            throw ex;
        }
        catch (Exception ex)
        {
            ExceptionManager.Publish(ex);
            throw ex;
        }

    }

    // #-----------------------------------------
    // # CloseFiles Procedure.
    // #-----------------------------------------
    protected override void CloseFiles()
    {
        try
        {
            fleF084_CLAIMS_INVENTORY.Dispose();
            fleSAVEF084_DELETE.Dispose();
        }
        catch (CustomApplicationException ex)
        {
            throw ex;
        }
        catch (Exception ex)
        {
            ExceptionManager.Publish(ex);
            throw ex;
        }

    }

    public void Run()
    {
        try
        {
            Request("DELETE_F084_1");
            //while (fleF084_CLAIMS_INVENTORY.QTPForMissing())
            //{
            //    //  --> GET F084_CLAIMS_INVENTORY <--
            //    fleF084_CLAIMS_INVENTORY.GetData();
            //    //  --> End GET F084_CLAIMS_INVENTORY <--
            //    if (Transaction())
            //    {
            //        SubFile(ref m_trnTRANS_UPDATE, "SAVEF084_DELETE", SubFileType.Keep, fleF084_CLAIMS_INVENTORY);
            //        fleF084_CLAIMS_INVENTORY.OutPut(OutPutType.Delete);
            //    }

            //}

            CONNSTRING.Value = Common.ConnectionStringDecrypt(CONNSTRING.Value.Trim());

            var sql = new StringBuilder("");

            if ((!(Prompt(2) == null) && (Prompt(2).ToString().Length > 0)))
            {
                sql = new StringBuilder("DELETE FROM INDEXED.F084_CLAIMS_INVENTORY ");
                sql.Append("WHERE ICONST_DATE_PERIOD_END BETWEEN ");
                sql.Append(Common.StringToField(Prompt(1).ToString())).Append(" AND ").Append(Common.StringToField(Prompt(2).ToString()));

                try
                {
                    var updated = SqlHelper.ExecuteNonQuery(CONNSTRING.Value.Trim(), CommandType.Text, sql.ToString());
                }

                catch (Exception ex)
                {
                    WriteError(ex);
                }
            }
        }
        catch (CustomApplicationException ex)
        {
            WriteError(ex);
        }
        catch (Exception ex)
        {
            WriteError(ex);
        }
        finally
        {
            EndRequest("DELETE_F084_1");
        }

    }
}
// DELETE_F084_1
public class PURGE_UNLOF084_UNLO_F084_2 : PURGE_UNLOF084
{

    public PURGE_UNLOF084_UNLO_F084_2(string Name, int Level) :
            base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;

        fleF084_CLAIMS_INVENTORY = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F084_CLAIMS_INVENTORY", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleSAVEF084_RETAIN = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "SAVEF084_RETAIN", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
    }

    private SqlFileObject fleF084_CLAIMS_INVENTORY;

    private SqlFileObject fleSAVEF084_RETAIN;

    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 2019-08-13 8:04:53 AM
    // #-----------------------------------------
    // # InitializeTransactionObjects Procedure.
    // #-----------------------------------------
    protected override void InitializeTransactionObjects()
    {
        try
        {
            m_cnnTRANS_UPDATE = new SqlConnection(Common.GetSqlConnectionString());
            m_cnnTRANS_UPDATE.Open();
            m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
            m_cnnQUERY = new SqlConnection(Common.GetSqlConnectionString());
        }
        catch (CustomApplicationException ex)
        {
            throw ex;
        }
        catch (Exception ex)
        {
            ExceptionManager.Publish(ex);
            throw ex;
        }

    }

    // #-----------------------------------------
    // # CloseTransactionObjects Procedure.
    // #-----------------------------------------
    protected override void CloseTransactionObjects()
    {
        try
        {
            this.CloseFiles();
            if (!(m_trnTRANS_UPDATE == null))
            {
                m_trnTRANS_UPDATE.Dispose();
            }

            if (!(m_cnnTRANS_UPDATE == null))
            {
                m_cnnTRANS_UPDATE.Close();
            }

            if (!(m_cnnTRANS_UPDATE == null))
            {
                m_cnnTRANS_UPDATE.Dispose();
            }

            if (!(m_cnnQUERY == null))
            {
                m_cnnQUERY.Close();
            }

            if (!(m_cnnQUERY == null))
            {
                m_cnnQUERY.Dispose();
            }

        }
        catch (CustomApplicationException ex)
        {
            throw ex;
        }
        catch (Exception ex)
        {
            ExceptionManager.Publish(ex);
            throw ex;
        }

    }

    protected override void TRANS_UPDATE(TransactionMethods Method)
    {
        if ((Method == TransactionMethods.Rollback))
        {
            m_trnTRANS_UPDATE.Rollback();
        }
        else
        {
            m_trnTRANS_UPDATE.Commit();
        }

        m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
        this.Initialize_TRANS_UPDATE();
    }

    private void Initialize_TRANS_UPDATE()
    {
        fleF084_CLAIMS_INVENTORY.Transaction = m_trnTRANS_UPDATE;
        fleSAVEF084_RETAIN.Transaction = m_trnTRANS_UPDATE;
    }

    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 2019-08-13 8:04:53 AM
    // #-----------------------------------------
    // # InitializeFiles Procedure.
    // #-----------------------------------------
    protected override void InitializeFiles()
    {
        try
        {
            this.Initialize_TRANS_UPDATE();
        }
        catch (CustomApplicationException ex)
        {
            throw ex;
        }
        catch (Exception ex)
        {
            ExceptionManager.Publish(ex);
            throw ex;
        }

    }

    // #-----------------------------------------
    // # CloseFiles Procedure.
    // #-----------------------------------------
    protected override void CloseFiles()
    {
        try
        {
            fleF084_CLAIMS_INVENTORY.Dispose();
            fleSAVEF084_RETAIN.Dispose();
        }
        catch (CustomApplicationException ex)
        {
            throw ex;
        }
        catch (Exception ex)
        {
            ExceptionManager.Publish(ex);
            throw ex;
        }

    }

    public void Run()
    {
        try
        {
            Request("UNLO_F084_2");
            while (fleF084_CLAIMS_INVENTORY.QTPForMissing())
            {
                //  --> GET F084_CLAIMS_INVENTORY <--
                fleF084_CLAIMS_INVENTORY.GetData();
                //  --> End GET F084_CLAIMS_INVENTORY <--
                if (Transaction())
                {
                    SubFile(ref m_trnTRANS_UPDATE, "SAVEF084_RETAIN", SubFileType.Keep, fleF084_CLAIMS_INVENTORY);
                }

            }

        }
        catch (CustomApplicationException ex)
        {
            WriteError(ex);
        }
        catch (Exception ex)
        {
            WriteError(ex);
        }
        finally
        {
            EndRequest("UNLO_F084_2");
        }

    }
}
// UNLO_F084_2