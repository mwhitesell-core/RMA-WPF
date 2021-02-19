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
public class PURGE_UNLOF087 : BaseClassControl
{

    private PURGE_UNLOF087 m_PURGE_UNLOF087;

    public PURGE_UNLOF087(string Name, int Level) :
            base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
        CONNSTRING = new CoreCharacter("CONNSTRING", 200, this, ResetTypes.ResetAtStartup, ConfigurationManager.AppSettings["ConnectionString1"]);
    }

    public PURGE_UNLOF087(string Name, int Level, bool Request) :
            base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
        CONNSTRING = new CoreCharacter("CONNSTRING", 200, this, ResetTypes.ResetAtStartup, ConfigurationManager.AppSettings["ConnectionString1"]);
    }

    public override void Dispose()
    {
        if (!(m_PURGE_UNLOF087 == null))
        {
            m_PURGE_UNLOF087.CloseTransactionObjects();
            m_PURGE_UNLOF087 = null;
        }

    }

    public PURGE_UNLOF087 GetPURGE_UNLOF087(int Level)
    {
        if ((m_PURGE_UNLOF087 == null))
        {
            m_PURGE_UNLOF087 = new PURGE_UNLOF087("PURGE_UNLOF087", Level);
        }
        else
        {
            m_PURGE_UNLOF087.ResetValues();
        }

        return m_PURGE_UNLOF087;
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
            PURGE_UNLOF087_DELETE_F087_HDR_1 DELETE_F087_HDR_1 = new PURGE_UNLOF087_DELETE_F087_HDR_1(Name, Level);
            DELETE_F087_HDR_1.Run();
            DELETE_F087_HDR_1.Dispose();
            DELETE_F087_HDR_1 = null;

            PURGE_UNLOF087_DELETE_F087_DTL_2 DELETE_F087_DTL_2 = new PURGE_UNLOF087_DELETE_F087_DTL_2(Name, Level);
            DELETE_F087_DTL_2.Run();
            DELETE_F087_DTL_2.Dispose();
            DELETE_F087_DTL_2 = null;
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
public class PURGE_UNLOF087_DELETE_F087_HDR_1 : PURGE_UNLOF087
{

    public PURGE_UNLOF087_DELETE_F087_HDR_1(string Name, int Level) :
            base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;

        fleF087SUBMITTEDREJECTEDCLAIMSHDR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F087_SUBMITTED_REJECTED_CLAIMS_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleSAVEF087HDR_DELETE = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "SAVEF087HDR_DELETE", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        //fleSAVEF087HDR_RETAIN = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "SAVEF087HDR_RETAIN", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

    }

    private SqlFileObject fleF087SUBMITTEDREJECTEDCLAIMSHDR;
    private SqlFileObject fleF002_CLAIMS_MSTR;
    private SqlFileObject fleSAVEF087HDR_DELETE;

    // Parent:SUBMITTED_REJECTED_CLAIM)    'Parent:SUBMITTED_REJECTED_CLAIM
    //private SqlFileObject fleSAVEF087HDR_RETAIN;

    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 2019-08-13 8:04:51 AM
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
        fleF087SUBMITTEDREJECTEDCLAIMSHDR.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleSAVEF087HDR_DELETE.Transaction = m_trnTRANS_UPDATE;
        //fleSAVEF087HDR_RETAIN.Transaction = m_trnTRANS_UPDATE;
    }

    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 2019-08-13 8:04:51 AM
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
            fleF087SUBMITTEDREJECTEDCLAIMSHDR.Dispose();
            fleF002_CLAIMS_MSTR.Dispose();
            fleSAVEF087HDR_DELETE.Dispose();
            //fleSAVEF087HDR_RETAIN.Dispose();
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
            Request("DELETE_F087_HDR_1");
            //while (fleF087SUBMITTEDREJECTEDCLAIMSHDR.QTPForMissing())
            //{
            //    //  --> GET F087SUBMITTEDREJECTEDCLAIMSHDR <--
            //    fleF087SUBMITTEDREJECTEDCLAIMSHDR.GetData();
            //    //  --> End GET F087SUBMITTEDREJECTEDCLAIMSHDR <--
            //    while (fleF002_CLAIMS_MSTR.QTPForMissing("1"))
            //    {
            //        //  --> GET F002_CLAIMS_MSTR <--
            //        m_strWhere = new StringBuilder(" WHERE ");
            //        m_strWhere.Append(" ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
            //        m_strWhere.Append(Common.StringToField("B"));
            //        m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
            //        m_strWhere.Append(Common.StringToField(fleF087SUBMITTEDREJECTEDCLAIMSHDR.GetStringValue("CLMHDR_BATCH_NBR")));
            //        m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ");
            //        m_strWhere.Append(Convert.ToDecimal(fleF087SUBMITTEDREJECTEDCLAIMSHDR.GetDecimalValue("CLMHDR_CLAIM_NBR")));
            //        m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_SERV_CODE")).Append(" = ");
            //        m_strWhere.Append(Common.StringToField("00000"));
            //        fleF002_CLAIMS_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
            //        //  --> End GET F002_CLAIMS_MSTR <--
            //        if (Transaction())
            //        {
            //            SubFile(ref m_trnTRANS_UPDATE, "SAVEF087HDR_DELETE", !fleF002_CLAIMS_MSTR.Exists(), SubFileType.Keep, fleF087SUBMITTEDREJECTEDCLAIMSHDR);
            //            // Parent:SUBMITTED_REJECTED_CLAIM)    'Parent:SUBMITTED_REJECTED_CLAIM

            //            if (!fleF002_CLAIMS_MSTR.Exists())
            //            {
            //                fleF087SUBMITTEDREJECTEDCLAIMSHDR.OutPut(OutPutType.Delete);
            //            }

            //            //SubFile(ref m_trnTRANS_UPDATE, "SAVEF087HDR_RETAIN", fleF002_CLAIMS_MSTR.Exists(), SubFileType.Keep, fleF087SUBMITTEDREJECTEDCLAIMSHDR);
            //            // Parent:SUBMITTED_REJECTED_CLAIM)    'Parent:SUBMITTED_REJECTED_CLAIM
            //        }
            //    }
            //}

            CONNSTRING.Value = Common.ConnectionStringDecrypt(CONNSTRING.Value.Trim());

            var sql = new StringBuilder("");

            sql = new StringBuilder("DECLARE @batch_nbr varchar(10)," + Environment.NewLine);
            sql.Append("@claim_nbr int" + Environment.NewLine);
            sql.Append("DECLARE tmptable CURSOR FOR " + Environment.NewLine);
            sql.Append("SELECT a.CLMHDR_BATCH_NBR, a.CLMHDR_CLAIM_NBR FROM INDEXED.F087_SUBMITTED_REJECTED_CLAIMS_HDR a" + Environment.NewLine);
            sql.Append("LEFT OUTER JOIN INDEXED.F002_CLAIMS_MSTR_HDR b ON b.KEY_CLM_TYPE = 'B' AND" + Environment.NewLine);
            sql.Append("b.KEY_CLM_BATCH_NBR = a.CLMHDR_BATCH_NBR AND" + Environment.NewLine);
            sql.Append("b.KEY_CLM_CLAIM_NBR = a.CLMHDR_CLAIM_NBR AND" + Environment.NewLine);
            sql.Append("b.KEY_CLM_SERV_CODE = '00000'" + Environment.NewLine);
            sql.Append("WHERE b.KEY_CLM_BATCH_NBR IS NULL;" + Environment.NewLine);
            sql.Append("OPEN tmptable " + Environment.NewLine);
            sql.Append("FETCH NEXT FROM tmptable" + Environment.NewLine);
            sql.Append("INTO @batch_nbr, @claim_nbr" + Environment.NewLine);
            sql.Append("WHILE @@FETCH_STATUS = 0" + Environment.NewLine);
            sql.Append("BEGIN" + Environment.NewLine);
            sql.Append("DELETE FROM INDEXED.F087_SUBMITTED_REJECTED_CLAIMS_HDR" + Environment.NewLine);
            sql.Append("WHERE CLMHDR_BATCH_NBR = @batch_nbr " + Environment.NewLine);
            sql.Append("AND CLMHDR_CLAIM_NBR = @claim_nbr" + Environment.NewLine);
            sql.Append("FETCH NEXT FROM tmptable" + Environment.NewLine);
            sql.Append("INTO @batch_nbr, @claim_nbr" + Environment.NewLine);
            sql.Append("END" + Environment.NewLine);
            sql.Append("CLOSE tmptable;" + Environment.NewLine);
            sql.Append("DEALLOCATE tmptable;");

                try
                {
                    var updated = SqlHelper.ExecuteNonQuery(CONNSTRING.Value.Trim(), CommandType.Text, sql.ToString());
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
            EndRequest("DELETE_F087_HDR_1");
        }

    }
}
// DELETE_F087_HDR_1
public class PURGE_UNLOF087_DELETE_F087_DTL_2 : PURGE_UNLOF087
{

    public PURGE_UNLOF087_DELETE_F087_DTL_2(string Name, int Level) :
            base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;

        fleF087SUBMITTEDREJECTEDCLAIMSDTL = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F087_SUBMITTED_REJECTED_CLAIMS_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleSAVEF087DTL_DELETE = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "SAVEF087DTL_DELETE", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        //fleSAVEF087DTL_RETAIN = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "SAVEF087DTL_RETAIN", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

    }

    private SqlFileObject fleF087SUBMITTEDREJECTEDCLAIMSDTL;

    private SqlFileObject fleF002_CLAIMS_MSTR;

    private SqlFileObject fleSAVEF087DTL_DELETE;

    // Parent:SUBMITTED_REJECTED_CLAIM)    'Parent:SUBMITTED_REJECTED_CLAIM
    //private SqlFileObject fleSAVEF087DTL_RETAIN;

    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 2019-08-13 8:04:51 AM
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
        fleF087SUBMITTEDREJECTEDCLAIMSDTL.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleSAVEF087DTL_DELETE.Transaction = m_trnTRANS_UPDATE;
        //fleSAVEF087DTL_RETAIN.Transaction = m_trnTRANS_UPDATE;
    }

    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 2019-08-13 8:04:51 AM
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
            fleF087SUBMITTEDREJECTEDCLAIMSDTL.Dispose();
            fleF002_CLAIMS_MSTR.Dispose();
            fleSAVEF087DTL_DELETE.Dispose();
            //fleSAVEF087DTL_RETAIN.Dispose();
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
            Request("DELETE_F087_DTL_2");
            //while (fleF087SUBMITTEDREJECTEDCLAIMSDTL.QTPForMissing())
            //{
            //    //  --> GET F087SUBMITTEDREJECTEDCLAIMSDTL <--
            //    fleF087SUBMITTEDREJECTEDCLAIMSDTL.GetData();
            //    //  --> End GET F087SUBMITTEDREJECTEDCLAIMSDTL <--
            //    while (fleF002_CLAIMS_MSTR.QTPForMissing("1"))
            //    {
            //        //  --> GET F002_CLAIMS_MSTR <--
            //        m_strWhere = new StringBuilder(" WHERE ");
            //        m_strWhere.Append(" ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
            //        m_strWhere.Append(Common.StringToField("B"));
            //        m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
            //        m_strWhere.Append(Common.StringToField(fleF087SUBMITTEDREJECTEDCLAIMSDTL.GetStringValue("CLMHDR_BATCH_NBR")));
            //        m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ");
            //        m_strWhere.Append(Convert.ToDecimal(fleF087SUBMITTEDREJECTEDCLAIMSDTL.GetDecimalValue("CLMHDR_CLAIM_NBR")));
            //        m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_SERV_CODE")).Append(" = ");
            //        m_strWhere.Append(Common.StringToField("00000"));
            //        fleF002_CLAIMS_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
            //        //  --> End GET F002_CLAIMS_MSTR <--
            //        if (Transaction())
            //        {
            //            SubFile(ref m_trnTRANS_UPDATE, "SAVEF087DTL_DELETE", !fleF002_CLAIMS_MSTR.Exists(), SubFileType.Keep, fleF087SUBMITTEDREJECTEDCLAIMSDTL);
            //            // Parent:SUBMITTED_REJECTED_CLAIM)    'Parent:SUBMITTED_REJECTED_CLAIM

            //            if (!fleF002_CLAIMS_MSTR.Exists())
            //            {
            //                fleF087SUBMITTEDREJECTEDCLAIMSDTL.OutPut(OutPutType.Delete);
            //            }

            //            //SubFile(ref m_trnTRANS_UPDATE, "SAVEF087DTL_RETAIN", fleF002_CLAIMS_MSTR.Exists(), SubFileType.Keep, fleF087SUBMITTEDREJECTEDCLAIMSDTL);
            //            // Parent:SUBMITTED_REJECTED_CLAIM)    'Parent:SUBMITTED_REJECTED_CLAIM
            //        }
            //    }
            //}

            var sql = new StringBuilder("");

            sql = new StringBuilder("DECLARE @batch_nbr varchar(10)," + Environment.NewLine);
            sql.Append("@claim_nbr int" + Environment.NewLine);
            sql.Append("DECLARE tmptable CURSOR FOR " + Environment.NewLine);
            sql.Append("SELECT a.CLMHDR_BATCH_NBR, a.CLMHDR_CLAIM_NBR FROM INDEXED.F087_SUBMITTED_REJECTED_CLAIMS_DTL a" + Environment.NewLine);
            sql.Append("LEFT OUTER JOIN INDEXED.F002_CLAIMS_MSTR_HDR b ON b.KEY_CLM_TYPE = 'B' AND" + Environment.NewLine);
            sql.Append("b.KEY_CLM_BATCH_NBR = a.CLMHDR_BATCH_NBR AND" + Environment.NewLine);
            sql.Append("b.KEY_CLM_CLAIM_NBR = a.CLMHDR_CLAIM_NBR AND" + Environment.NewLine);
            sql.Append("b.KEY_CLM_SERV_CODE = '00000'" + Environment.NewLine);
            sql.Append("WHERE b.KEY_CLM_BATCH_NBR IS NULL;" + Environment.NewLine);
            sql.Append("OPEN tmptable " + Environment.NewLine);
            sql.Append("FETCH NEXT FROM tmptable" + Environment.NewLine);
            sql.Append("INTO @batch_nbr, @claim_nbr" + Environment.NewLine);
            sql.Append("WHILE @@FETCH_STATUS = 0" + Environment.NewLine);
            sql.Append("BEGIN" + Environment.NewLine);
            sql.Append("DELETE FROM INDEXED.F087_SUBMITTED_REJECTED_CLAIMS_DTL" + Environment.NewLine);
            sql.Append("WHERE CLMHDR_BATCH_NBR = @batch_nbr " + Environment.NewLine);
            sql.Append("AND CLMHDR_CLAIM_NBR = @claim_nbr" + Environment.NewLine);
            sql.Append("FETCH NEXT FROM tmptable" + Environment.NewLine);
            sql.Append("INTO @batch_nbr, @claim_nbr" + Environment.NewLine);
            sql.Append("END" + Environment.NewLine);
            sql.Append("CLOSE tmptable;" + Environment.NewLine);
            sql.Append("DEALLOCATE tmptable;");

            try
            {
                var updated = SqlHelper.ExecuteNonQuery(CONNSTRING.Value.Trim(), CommandType.Text, sql.ToString());
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
            EndRequest("DELETE_F087_DTL_2");
        }

    }
}
// DELETE_F087_DTL_2