
#region "Screen Comments"



#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;

public class PURGE_RELOF088 : BaseClassControl
{
    private PURGE_RELOF088 m_PURGE_RELOF088;

    public PURGE_RELOF088(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
    }

    public PURGE_RELOF088(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
    }

    public override void Dispose()
    {
        if (!(m_PURGE_RELOF088 == null))
        {
            m_PURGE_RELOF088.CloseTransactionObjects();
            m_PURGE_RELOF088 = null;
        }
    }

    public PURGE_RELOF088 GetPURGE_RELOF088(int Level)
    {
        if ((m_PURGE_RELOF088 == null))
        {
            m_PURGE_RELOF088 = new PURGE_RELOF088("PURGE_RELOF088", Level);
        }
        else
        {
            m_PURGE_RELOF088.ResetValues();
        }

        return m_PURGE_RELOF088;
    }

    #region "Renaissance Architect Migration Services Default Regions"

    #region "Declarations (Variables, Files and Transactions)"

    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.
    protected SqlConnection m_cnnQUERY = new SqlConnection();
    protected SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
    protected SqlTransaction m_trnTRANS_UPDATE;

    #endregion

    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"

    public override bool RunQTP()
    {
        try
        {
            PURGE_RELOF088_RELOAD_F088_HDR_1 RELOAD_F088_HDR_1 = new PURGE_RELOF088_RELOAD_F088_HDR_1(Name, Level);
            RELOAD_F088_HDR_1.Run();
            RELOAD_F088_HDR_1.Dispose();
            RELOAD_F088_HDR_1 = null;

            PURGE_RELOF088_RELOAD_F088_DTL_2 RELOAD_F088_DTL_2 = new PURGE_RELOF088_RELOAD_F088_DTL_2(Name, Level);
            RELOAD_F088_DTL_2.Run();
            RELOAD_F088_DTL_2.Dispose();
            RELOAD_F088_DTL_2 = null;

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
public class PURGE_RELOF088_RELOAD_F088_HDR_1 : PURGE_RELOF088
{
    public PURGE_RELOF088_RELOAD_F088_HDR_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;

        fleSAVEF088HDR_RETAIN = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "SAVEF088HDR_RETAIN", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF088_RAT_REJECTED_CLAIMS_HIST_HDR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F088_RAT_REJECTED_CLAIMS_HIST_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF088_RAT_REJECTED_CLAIMS_HIST_HDR.SetItemFinals += fleF088_RAT_REJECTED_CLAIMS_HIST_HDR_SetItemFinals;
    }

    #region "Declarations (Variables, Files and Transactions)(RELOAD_F088_HDR)"

    private SqlFileObject fleSAVEF088HDR_RETAIN;
    private SqlFileObject fleF088_RAT_REJECTED_CLAIMS_HIST_HDR;

    private void fleF088_RAT_REJECTED_CLAIMS_HIST_HDR_SetItemFinals()
    {
        try
        {            
            
            fleF088_RAT_REJECTED_CLAIMS_HIST_HDR.set_SetValue("CLMHDR_BATCH_NBR", fleSAVEF088HDR_RETAIN.GetStringValue("CLMHDR_BATCH_NBR"));
            fleF088_RAT_REJECTED_CLAIMS_HIST_HDR.set_SetValue("CLMHDR_CLAIM_NBR", fleSAVEF088HDR_RETAIN.GetDecimalValue("CLMHDR_CLAIM_NBR"));
            fleF088_RAT_REJECTED_CLAIMS_HIST_HDR.set_SetValue("PED", fleSAVEF088HDR_RETAIN.GetDecimalValue("PED"));
            fleF088_RAT_REJECTED_CLAIMS_HIST_HDR.set_SetValue("OHIP_ERR_CODE", fleSAVEF088HDR_RETAIN.GetStringValue("OHIP_ERR_CODE"));
            fleF088_RAT_REJECTED_CLAIMS_HIST_HDR.set_SetValue("PART_HDR_AMT_BILL", fleSAVEF088HDR_RETAIN.GetDecimalValue("PART_HDR_AMT_BILL"));
            fleF088_RAT_REJECTED_CLAIMS_HIST_HDR.set_SetValue("PART_HDR_AMT_PAID", fleSAVEF088HDR_RETAIN.GetDecimalValue("PART_HDR_AMT_PAID"));
            fleF088_RAT_REJECTED_CLAIMS_HIST_HDR.set_SetValue("CLMHDR_DOC_NBR", fleSAVEF088HDR_RETAIN.GetStringValue("CLMHDR_DOC_NBR"));
            fleF088_RAT_REJECTED_CLAIMS_HIST_HDR.set_SetValue("CLMHDR_DATE_PERIOD_END", fleSAVEF088HDR_RETAIN.GetDecimalValue("CLMHDR_DATE_PERIOD_END"));
            fleF088_RAT_REJECTED_CLAIMS_HIST_HDR.set_SetValue("CLMHDR_SERV_DATE", fleSAVEF088HDR_RETAIN.GetDecimalValue("CLMHDR_SERV_DATE"));            
            fleF088_RAT_REJECTED_CLAIMS_HIST_HDR.set_SetValue("CHARGE_STATUS", fleSAVEF088HDR_RETAIN.GetStringValue("CHARGE_STATUS"));
            fleF088_RAT_REJECTED_CLAIMS_HIST_HDR.set_SetValue("ENTRY_DATE", fleSAVEF088HDR_RETAIN.GetDecimalValue("ENTRY_DATE"));
            fleF088_RAT_REJECTED_CLAIMS_HIST_HDR.set_SetValue("ENTRY_TIME_LONG", fleSAVEF088HDR_RETAIN.GetDecimalValue("ENTRY_TIME_LONG"));
            fleF088_RAT_REJECTED_CLAIMS_HIST_HDR.set_SetValue("ENTRY_USER_ID", fleSAVEF088HDR_RETAIN.GetStringValue("ENTRY_USER_ID"));
            fleF088_RAT_REJECTED_CLAIMS_HIST_HDR.set_SetValue("LAST_MOD_DATE", fleSAVEF088HDR_RETAIN.GetDecimalValue("LAST_MOD_DATE"));
            fleF088_RAT_REJECTED_CLAIMS_HIST_HDR.set_SetValue("LAST_MOD_TIME", fleSAVEF088HDR_RETAIN.GetDecimalValue("LAST_MOD_TIME"));
            fleF088_RAT_REJECTED_CLAIMS_HIST_HDR.set_SetValue("LAST_MOD_USER_ID", fleSAVEF088HDR_RETAIN.GetStringValue("LAST_MOD_USER_ID"));

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

    #endregion

    #region "Standard Generated Procedures(RELOAD_F088_HDR)"

    #region "Automatic Item Initialization(RELOAD_F088_HDR)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:01:47 PM

    //#-----------------------------------------
    //# fleF001_ADD_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 3:01:47 PM
    //#-----------------------------------------

    #endregion

    #region "Transaction Management Procedures(RELOAD_F088_HDR)"

    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 2019-01-31 8:40:18 AM
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
        fleSAVEF088HDR_RETAIN.Transaction = m_trnTRANS_UPDATE;
        fleF088_RAT_REJECTED_CLAIMS_HIST_HDR.Transaction = m_trnTRANS_UPDATE;
    }

    #endregion

    #region "FILE Management Procedures(RELOAD_F088_HDR)"

    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 2019-01-31 8:40:18 AM
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
            fleSAVEF088HDR_RETAIN.Dispose();
            fleF088_RAT_REJECTED_CLAIMS_HIST_HDR.Dispose();
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

    #endregion

    #endregion

    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(RELOAD_F088_HDR)"

    public void Run()
    {
        try
        {
            Request("RELOAD_F088_HDR");
            while (fleSAVEF088HDR_RETAIN.QTPForMissing())
            {
                //  --> GET SAVEF087_RETAIN <--
                fleSAVEF088HDR_RETAIN.GetData();
                //  --> End GET SAVEF087_RETAIN <--

                if (Transaction())
                {
                    fleF088_RAT_REJECTED_CLAIMS_HIST_HDR.OutPut(OutPutType.Add);
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
            EndRequest("RELOAD_F088_HDR");
        }
    }

    #endregion
}
// RELOAD_F088_HDR_1

public class PURGE_RELOF088_RELOAD_F088_DTL_2 : PURGE_RELOF088
{
    public PURGE_RELOF088_RELOAD_F088_DTL_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;

        fleSAVEF088DTL_RETAIN = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "SAVEF088DTL_RETAIN", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF088_RAT_REJECTED_CLAIMS_DTL = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F088_RAT_REJECTED_CLAIMS_HIST_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF088_RAT_REJECTED_CLAIMS_DTL.SetItemFinals += fleF088_RAT_REJECTED_CLAIMS_DTL_SetItemFinals;
    }

    #region "Declarations (Variables, Files and Transactions)(RELOAD_F088_DTL)"

    private SqlFileObject fleSAVEF088DTL_RETAIN;
    private SqlFileObject fleF088_RAT_REJECTED_CLAIMS_DTL;

    private void fleF088_RAT_REJECTED_CLAIMS_DTL_SetItemFinals()
    {
        try
        {
            fleF088_RAT_REJECTED_CLAIMS_DTL.set_SetValue("CLMHDR_BATCH_NBR", fleSAVEF088DTL_RETAIN.GetStringValue("CLMHDR_BATCH_NBR"));
            fleF088_RAT_REJECTED_CLAIMS_DTL.set_SetValue("CLMHDR_CLAIM_NBR", fleSAVEF088DTL_RETAIN.GetDecimalValue("CLMHDR_CLAIM_NBR"));
            fleF088_RAT_REJECTED_CLAIMS_DTL.set_SetValue("CLMHDR_ADJ_OMA_CD", fleSAVEF088DTL_RETAIN.GetStringValue("CLMHDR_ADJ_OMA_CD"));
            fleF088_RAT_REJECTED_CLAIMS_DTL.set_SetValue("CLMHDR_ADJ_OMA_SUFF", fleSAVEF088DTL_RETAIN.GetStringValue("CLMHDR_ADJ_OMA_SUFF"));
            fleF088_RAT_REJECTED_CLAIMS_DTL.set_SetValue("CLMHDR_ADJ_ADJ_NBR", fleSAVEF088DTL_RETAIN.GetStringValue("CLMHDR_ADJ_ADJ_NBR"));
            fleF088_RAT_REJECTED_CLAIMS_DTL.set_SetValue("PED", fleSAVEF088DTL_RETAIN.GetDecimalValue("PED"));
            fleF088_RAT_REJECTED_CLAIMS_DTL.set_SetValue("OHIP_ERR_CODE", fleSAVEF088DTL_RETAIN.GetStringValue("OHIP_ERR_CODE"));
            fleF088_RAT_REJECTED_CLAIMS_DTL.set_SetValue("PART_DTL_AMT_BILL", fleSAVEF088DTL_RETAIN.GetDecimalValue("PART_DTL_AMT_BILL"));
            fleF088_RAT_REJECTED_CLAIMS_DTL.set_SetValue("PART_DTL_AMT_PAID", fleSAVEF088DTL_RETAIN.GetDecimalValue("PART_DTL_AMT_PAID"));
            fleF088_RAT_REJECTED_CLAIMS_DTL.set_SetValue("AUTO_ADJ_FLAG", fleSAVEF088DTL_RETAIN.GetStringValue("AUTO_ADJ_FLAG"));
            fleF088_RAT_REJECTED_CLAIMS_DTL.set_SetValue("CLMHDR_DOC_NBR", fleSAVEF088DTL_RETAIN.GetStringValue("CLMHDR_DOC_NBR"));
            fleF088_RAT_REJECTED_CLAIMS_DTL.set_SetValue("CLMDTL_DATE_PERIOD_END", fleSAVEF088DTL_RETAIN.GetStringValue("CLMDTL_DATE_PERIOD_END"));
            fleF088_RAT_REJECTED_CLAIMS_DTL.set_SetValue("CLMDTL_SV_DATE", fleSAVEF088DTL_RETAIN.GetStringValue("CLMDTL_SV_DATE"));
            fleF088_RAT_REJECTED_CLAIMS_DTL.set_SetValue("ENTRY_DATE", fleSAVEF088DTL_RETAIN.GetDecimalValue("ENTRY_DATE"));
            fleF088_RAT_REJECTED_CLAIMS_DTL.set_SetValue("ENTRY_TIME_LONG", fleSAVEF088DTL_RETAIN.GetDecimalValue("ENTRY_TIME_LONG"));
            fleF088_RAT_REJECTED_CLAIMS_DTL.set_SetValue("ENTRY_USER_ID", fleSAVEF088DTL_RETAIN.GetStringValue("ENTRY_USER_ID"));
            fleF088_RAT_REJECTED_CLAIMS_DTL.set_SetValue("LAST_MOD_DATE", fleSAVEF088DTL_RETAIN.GetDecimalValue("LAST_MOD_DATE"));
            fleF088_RAT_REJECTED_CLAIMS_DTL.set_SetValue("LAST_MOD_TIME", fleSAVEF088DTL_RETAIN.GetDecimalValue("LAST_MOD_TIME"));
            fleF088_RAT_REJECTED_CLAIMS_DTL.set_SetValue("LAST_MOD_USER_ID", fleSAVEF088DTL_RETAIN.GetStringValue("LAST_MOD_USER_ID"));

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

    #endregion

    #region "Standard Generated Procedures(RELOAD_F088_DTL)"

    #region "Automatic Item Initialization(RELOAD_F088_DTL)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:01:47 PM

    //#-----------------------------------------
    //# fleF001_ADD_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 3:01:47 PM
    //#-----------------------------------------

    #endregion

    #region "Transaction Management Procedures(RELOAD_F088_DTL)"

    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 2019-01-31 8:40:18 AM
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
        fleSAVEF088DTL_RETAIN.Transaction = m_trnTRANS_UPDATE;
        fleF088_RAT_REJECTED_CLAIMS_DTL.Transaction = m_trnTRANS_UPDATE;
    }

    #endregion

    #region "FILE Management Procedures(RELOAD_F088_DTL)"

    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 2019-01-31 8:40:18 AM
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
            fleSAVEF088DTL_RETAIN.Dispose();
            fleF088_RAT_REJECTED_CLAIMS_DTL.Dispose();
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

    #endregion

    #endregion

    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(RELOAD_F088_DTL)"

    public void Run()
    {
        try
        {
            Request("RELOAD_F088_DTL");
            while (fleSAVEF088DTL_RETAIN.QTPForMissing())
            {
                //  --> GET SAVEF088_RETAIN <--
                fleSAVEF088DTL_RETAIN.GetData();
                //  --> End GET SAVEF088_RETAIN <--

                if (Transaction())
                {
                    fleF088_RAT_REJECTED_CLAIMS_DTL.OutPut(OutPutType.Add);
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
            EndRequest("RELOAD_F088_DTL");
        }
    }

    #endregion
}
// RELOAD_F088_DTL_2