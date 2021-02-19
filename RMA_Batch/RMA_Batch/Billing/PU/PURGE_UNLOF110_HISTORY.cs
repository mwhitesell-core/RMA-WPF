//  2006/jun/15 - MC - delete f110 history file
using Core.DataAccess.SqlServer;
using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
public class PURGE_UNLOF110_HISTORY : BaseClassControl
{

    private PURGE_UNLOF110_HISTORY m_PURGE_UNLOF110_HISTORY;

    public PURGE_UNLOF110_HISTORY(string Name, int Level) :
            base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
    }

    public PURGE_UNLOF110_HISTORY(string Name, int Level, bool Request) :
            base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
    }

    public override void Dispose()
    {
        if (!(m_PURGE_UNLOF110_HISTORY == null))
        {
            m_PURGE_UNLOF110_HISTORY.CloseTransactionObjects();
            m_PURGE_UNLOF110_HISTORY = null;
        }

    }

    public PURGE_UNLOF110_HISTORY GetPURGE_UNLOF110_HISTORY(int Level)
    {
        if ((m_PURGE_UNLOF110_HISTORY == null))
        {
            m_PURGE_UNLOF110_HISTORY = new PURGE_UNLOF110_HISTORY("PURGE_UNLOF110_HISTORY", Level);
        }
        else
        {
            m_PURGE_UNLOF110_HISTORY.ResetValues();
        }

        return m_PURGE_UNLOF110_HISTORY;
    }

    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.
    protected SqlConnection m_cnnQUERY = new SqlConnection();

    protected SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();

    protected SqlTransaction m_trnTRANS_UPDATE;

    protected string CONNSTRING;

    public override bool RunQTP()
    {
        try
        {
            PURGE_UNLOF110_HISTORY_DELETE_F110_HIST_1 DELETE_F110_HIST_1 = new PURGE_UNLOF110_HISTORY_DELETE_F110_HIST_1(Name, Level);
            DELETE_F110_HIST_1.Run();
            DELETE_F110_HIST_1.Dispose();
            DELETE_F110_HIST_1 = null;
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
public class PURGE_UNLOF110_HISTORY_DELETE_F110_HIST_1 : PURGE_UNLOF110_HISTORY
{

    public PURGE_UNLOF110_HISTORY_DELETE_F110_HIST_1(string Name, int Level) :
            base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;

        fleF110_COMPENSATION_HISTORY = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION_HISTORY", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleSAVEF110HIST_DELETE = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "SAVEF110HIST_DELETE", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        //fleSAVEF110HIST_RETAIN = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "SAVEF110HIST_RETAIN", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF110_COMPENSATION_HISTORY.Choose += fleF110_COMPENSATION_HISTORY_Choose;
        FROM_EP_NBR.GetValue += FROM_EP_NBR_GetValue;
        TO_EP_NBR.GetValue += TO_EP_NBR_GetValue;
    }

    private SqlFileObject fleF110_COMPENSATION_HISTORY;

    private void fleF110_COMPENSATION_HISTORY_Choose(ref string ChooseClause)
    {
        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF110_COMPENSATION_HISTORY.ElementOwner("EP_NBR")).Append(" >= ");
            strSQL.Append(QDesign.NULL(FROM_EP_NBR.Value));

            strSQL.Append(" AND ");
            strSQL.Append(fleF110_COMPENSATION_HISTORY.ElementOwner("EP_NBR")).Append(" <= ");
            strSQL.Append(QDesign.NULL(TO_EP_NBR.Value));

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

    private DDecimal FROM_EP_NBR = new DDecimal("FROM_EP_NBR", 6);

    private void FROM_EP_NBR_GetValue(ref Decimal Value)
    {
        try
        {
            Value = Convert.ToDecimal(Prompt(1));
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

    private DDecimal TO_EP_NBR = new DDecimal("TO_EP_NBR", 6);

    private void TO_EP_NBR_GetValue(ref Decimal Value)
    {
        try
        {
            Value = Convert.ToDecimal(Prompt(2));
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

    private SqlFileObject fleSAVEF110HIST_DELETE;

    // Parent:COMPENSATION_KEY
    //private SqlFileObject fleSAVEF110HIST_RETAIN;

    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 2019-08-13 8:04:48 AM
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
        fleF110_COMPENSATION_HISTORY.Transaction = m_trnTRANS_UPDATE;
        fleSAVEF110HIST_DELETE.Transaction = m_trnTRANS_UPDATE;
        //fleSAVEF110HIST_RETAIN.Transaction = m_trnTRANS_UPDATE;
    }

    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 2019-08-13 8:04:48 AM
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
            fleF110_COMPENSATION_HISTORY.Dispose();
            fleSAVEF110HIST_DELETE.Dispose();
            //fleSAVEF110HIST_RETAIN.Dispose();
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
            Request("DELETE_F110_HIST_1");
            //while (fleF110_COMPENSATION_HISTORY.QTPForMissing())
            //{
            //    //  --> GET F110_COMPENSATION_HISTORY <--
            //    fleF110_COMPENSATION_HISTORY.GetData();
            //    //  --> End GET F110_COMPENSATION_HISTORY <--
            //    if (Transaction())
            //    {
            //        //SubFile(ref m_trnTRANS_UPDATE, "SAVEF110HIST_DELETE", ((fleF110_COMPENSATION_HISTORY.GetDecimalValue("EP_NBR") >= FROM_EP_NBR.Value)
            //        //                & (fleF110_COMPENSATION_HISTORY.GetDecimalValue("EP_NBR") <= TO_EP_NBR.Value)), SubFileType.Keep, fleF110_COMPENSATION_HISTORY);
            //        // Parent:COMPENSATION_KEY
            //        //SubFile(ref m_trnTRANS_UPDATE, "SAVEF110HIST_RETAIN", ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetDecimalValue("EP_NBR")) < QDesign.NULL(FROM_EP_NBR.Value))
            //        //                | (QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetDecimalValue("EP_NBR")) > QDesign.NULL(TO_EP_NBR.Value))), SubFileType.Keep, fleF110_COMPENSATION_HISTORY);
            //        // Parent:COMPENSATION_KEY

            //        SubFile(ref m_trnTRANS_UPDATE, "SAVEF110HIST_DELETE", SubFileType.Keep, fleF110_COMPENSATION_HISTORY);
            //        fleF110_COMPENSATION_HISTORY.OutPut(OutPutType.Delete);
            //    }

            //}

            if (Environment.GetEnvironmentVariable("RMABILL_VERS", EnvironmentVariableTarget.Process).ToUpper() == "101C")
            {
                CONNSTRING = ConfigurationManager.AppSettings["ConnectionString1"];
            }
            else if (Environment.GetEnvironmentVariable("RMABILL_VERS", EnvironmentVariableTarget.Process).ToUpper() == "MP")
            {
                CONNSTRING = ConfigurationManager.AppSettings["ConnectionString6"];
            }
            else if (Environment.GetEnvironmentVariable("RMABILL_VERS", EnvironmentVariableTarget.Process).ToUpper() == "SOLO")
            {
                CONNSTRING = ConfigurationManager.AppSettings["ConnectionString7"];
            }

            CONNSTRING = Common.ConnectionStringDecrypt(CONNSTRING.Trim());
            var sql = new StringBuilder("");

            sql = new StringBuilder("DELETE FROM INDEXED.F110_COMPENSATION_HISTORY ");
            sql.Append("WHERE EP_NBR BETWEEN " + FROM_EP_NBR.Value + " AND " + TO_EP_NBR.Value);

            try
            {
                var updated = SqlHelper.ExecuteNonQuery(CONNSTRING.Trim(), CommandType.Text, sql.ToString());
            }

            catch (Exception ex)
            {
                WriteError(ex);
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
            EndRequest("DELETE_F110_HIST_1");
        }

    }
}
// DELETE_F110_HIST_1