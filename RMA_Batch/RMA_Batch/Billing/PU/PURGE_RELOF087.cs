
#region "Screen Comments"

#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;

public class PURGE_RELOF087 : BaseClassControl
{
    private PURGE_RELOF087 m_PURGE_RELOF087;

    public PURGE_RELOF087(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
    }

    public PURGE_RELOF087(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
    }

    public override void Dispose()
    {
        if (!(m_PURGE_RELOF087 == null))
        {
            m_PURGE_RELOF087.CloseTransactionObjects();
            m_PURGE_RELOF087 = null;
        }
    }

    public PURGE_RELOF087 GetPURGE_RELOF087(int Level)
    {
        if ((m_PURGE_RELOF087 == null))
        {
            m_PURGE_RELOF087 = new PURGE_RELOF087("PURGE_RELOF087", Level);
        }
        else
        {
            m_PURGE_RELOF087.ResetValues();
        }

        return m_PURGE_RELOF087;
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
            PURGE_RELOF087_RELOAD_F087_HDR_1 RELOAD_F087_HDR_1 = new PURGE_RELOF087_RELOAD_F087_HDR_1(Name, Level);
            RELOAD_F087_HDR_1.Run();
            RELOAD_F087_HDR_1.Dispose();
            RELOAD_F087_HDR_1 = null;

            PURGE_RELOF087_RELOAD_F087_DTL_2 RELOAD_F087_DTL_2 = new PURGE_RELOF087_RELOAD_F087_DTL_2(Name, Level);
            RELOAD_F087_DTL_2.Run();
            RELOAD_F087_DTL_2.Dispose();
            RELOAD_F087_DTL_2 = null;

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
public class PURGE_RELOF087_RELOAD_F087_HDR_1 : PURGE_RELOF087
{
    public PURGE_RELOF087_RELOAD_F087_HDR_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;

        fleSAVEF087HDR_RETAIN = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "SAVEF087HDR_RETAIN", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF087_SUBMITTED_REJECTED_CLAIMS_HDR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F087_SUBMITTED_REJECTED_CLAIMS_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.SetItemFinals += fleF087_SUBMITTED_REJECTED_CLAIMS_HDR_SetItemFinals;
    }

    #region "Declarations (Variables, Files and Transactions)(RELOAD_F087_HDR)"

    private SqlFileObject fleSAVEF087HDR_RETAIN;
    private SqlFileObject fleF087_SUBMITTED_REJECTED_CLAIMS_HDR;

    private void fleF087_SUBMITTED_REJECTED_CLAIMS_HDR_SetItemFinals()
    {
        try
        {
            fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.set_SetValue("CLMHDR_DOC_NBR", fleSAVEF087HDR_RETAIN.GetStringValue("CLMHDR_DOC_NBR"));
            fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.set_SetValue("PED", fleSAVEF087HDR_RETAIN.GetDecimalValue("PED"));
            fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.set_SetValue("CLMHDR_BATCH_NBR", fleSAVEF087HDR_RETAIN.GetStringValue("CLMHDR_BATCH_NBR"));
            fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.set_SetValue("CLMHDR_CLAIM_NBR", fleSAVEF087HDR_RETAIN.GetDecimalValue("CLMHDR_CLAIM_NBR"));
            fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.set_SetValue("EDT_PROCESS_DATE", fleSAVEF087HDR_RETAIN.GetDecimalValue("EDT_PROCESS_DATE"));
            fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.set_SetValue("EDT_PAT_BIRTH_DATE", fleSAVEF087HDR_RETAIN.GetDecimalValue("EDT_PAT_BIRTH_DATE"));
            fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.set_SetValue("EDT_ACCOUNT_NBR", fleSAVEF087HDR_RETAIN.GetStringValue("EDT_ACCOUNT_NBR"));
            fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.set_SetValue("EDT_HEALTH_NBR", fleSAVEF087HDR_RETAIN.GetStringValue("EDT_HEALTH_NBR"));
            fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.set_SetValue("EDT_HEALTH_VERSION_CD", fleSAVEF087HDR_RETAIN.GetStringValue("EDT_HEALTH_VERSION_CD"));
            fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.set_SetValue("EDT_PAY_PROG", fleSAVEF087HDR_RETAIN.GetStringValue("EDT_PAY_PROG"));
            fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.set_SetValue("EDT_PAYEE", fleSAVEF087HDR_RETAIN.GetStringValue("EDT_PAYEE"));
            fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.set_SetValue("EFT_REFERRING_DOC_NBR", fleSAVEF087HDR_RETAIN.GetDecimalValue("EFT_REFERRING_DOC_NBR"));
            fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.set_SetValue("EDT_FACILITY_NBR", fleSAVEF087HDR_RETAIN.GetStringValue("EDT_FACILITY_NBR"));
            fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.set_SetValue("EDT_ADMIT_DATE", fleSAVEF087HDR_RETAIN.GetDecimalValue("EDT_ADMIT_DATE"));
            fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.set_SetValue("EDT_LOCATION_CD", fleSAVEF087HDR_RETAIN.GetStringValue("EDT_LOCATION_CD"));
            fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.set_SetValue("OHIP_ERR_CODE", fleSAVEF087HDR_RETAIN.GetStringValue("OHIP_ERR_CODE"));
            fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.set_SetValue("EDT_ERR_H_CD_1", fleSAVEF087HDR_RETAIN.GetStringValue("EDT_ERR_H_CD_1"));
            fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.set_SetValue("EDT_ERR_H_CD_2", fleSAVEF087HDR_RETAIN.GetStringValue("EDT_ERR_H_CD_2"));
            fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.set_SetValue("EDT_ERR_H_CD_3", fleSAVEF087HDR_RETAIN.GetStringValue("EDT_ERR_H_CD_3"));
            fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.set_SetValue("EDT_ERR_H_CD_4", fleSAVEF087HDR_RETAIN.GetStringValue("EDT_ERR_H_CD_4"));
            fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.set_SetValue("EDT_ERR_H_CD_5", fleSAVEF087HDR_RETAIN.GetStringValue("EDT_ERR_H_CD_5"));
            fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.set_SetValue("CHARGE_STATUS", fleSAVEF087HDR_RETAIN.GetStringValue("CHARGE_STATUS"));
            fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.set_SetValue("ENTRY_DATE", fleSAVEF087HDR_RETAIN.GetDecimalValue("ENTRY_DATE"));
            fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.set_SetValue("ENTRY_TIME_LONG", fleSAVEF087HDR_RETAIN.GetDecimalValue("ENTRY_TIME_LONG"));
            fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.set_SetValue("ENTRY_USER_ID", fleSAVEF087HDR_RETAIN.GetStringValue("ENTRY_USER_ID"));
            fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.set_SetValue("LAST_MOD_DATE", fleSAVEF087HDR_RETAIN.GetDecimalValue("LAST_MOD_DATE"));
            fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.set_SetValue("LAST_MOD_TIME", fleSAVEF087HDR_RETAIN.GetDecimalValue("LAST_MOD_TIME"));
            fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.set_SetValue("LAST_MOD_USER_ID", fleSAVEF087HDR_RETAIN.GetStringValue("LAST_MOD_USER_ID"));

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

    #region "Standard Generated Procedures(RELOAD_F087_HDR)"

    #region "Automatic Item Initialization(RELOAD_F087_HDR)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:01:47 PM

    //#-----------------------------------------
    //# fleF001_ADD_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 3:01:47 PM
    //#-----------------------------------------

    #endregion

    #region "Transaction Management Procedures(RELOAD_F087_HDR)"

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
        fleSAVEF087HDR_RETAIN.Transaction = m_trnTRANS_UPDATE;
        fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.Transaction = m_trnTRANS_UPDATE;
    }

    #endregion

    #region "FILE Management Procedures(RELOAD_F087_HDR)"

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
            fleSAVEF087HDR_RETAIN.Dispose();
            fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.Dispose();
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

    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(RELOAD_F087_HDR)"

    public void Run()
    {
        try
        {
            Request("RELOAD_F087_HDR");
            while (fleSAVEF087HDR_RETAIN.QTPForMissing())
            {
                //  --> GET SAVEF087_RETAIN <--
                fleSAVEF087HDR_RETAIN.GetData();
                //  --> End GET SAVEF087_RETAIN <--

                if (Transaction())
                {
                    fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.OutPut(OutPutType.Add);
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
            EndRequest("RELOAD_F087_HDR");
        }
    }

    #endregion
}
// RELOAD_F087_HDR_1

public class PURGE_RELOF087_RELOAD_F087_DTL_2 : PURGE_RELOF087
{
    public PURGE_RELOF087_RELOAD_F087_DTL_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;

        fleSAVEF087DTL_RETAIN = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "SAVEF087DTL_RETAIN", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF087_SUBMITTED_REJECTED_CLAIMS_DTL = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F087_SUBMITTED_REJECTED_CLAIMS_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF087_SUBMITTED_REJECTED_CLAIMS_DTL.SetItemFinals += fleF087_SUBMITTED_REJECTED_CLAIMS_DTL_SetItemFinals;
    }

    #region "Declarations (Variables, Files and Transactions)(RELOAD_F087_DTL)"

    private SqlFileObject fleSAVEF087DTL_RETAIN;
    private SqlFileObject fleF087_SUBMITTED_REJECTED_CLAIMS_DTL;

    private void fleF087_SUBMITTED_REJECTED_CLAIMS_DTL_SetItemFinals()
    {
        try
        {
            fleF087_SUBMITTED_REJECTED_CLAIMS_DTL.set_SetValue("CLMHDR_BATCH_NBR", fleSAVEF087DTL_RETAIN.GetStringValue("CLMHDR_BATCH_NBR"));
            fleF087_SUBMITTED_REJECTED_CLAIMS_DTL.set_SetValue("CLMHDR_CLAIM_NBR", fleSAVEF087DTL_RETAIN.GetDecimalValue("CLMHDR_CLAIM_NBR"));            
            fleF087_SUBMITTED_REJECTED_CLAIMS_DTL.set_SetValue("PED", fleSAVEF087DTL_RETAIN.GetDecimalValue("PED"));
            fleF087_SUBMITTED_REJECTED_CLAIMS_DTL.set_SetValue("EDT_PROCESS_DATE", fleSAVEF087DTL_RETAIN.GetDecimalValue("EDT_PROCESS_DATE"));
            fleF087_SUBMITTED_REJECTED_CLAIMS_DTL.set_SetValue("KEY_DTL_SEQ_NBR", fleSAVEF087DTL_RETAIN.GetDecimalValue("KEY_DTL_SEQ_NBR"));
            fleF087_SUBMITTED_REJECTED_CLAIMS_DTL.set_SetValue("EDT_OMA_SERVICE_CD_AND_SUFFIX", fleSAVEF087DTL_RETAIN.GetStringValue("EDT_OMA_SERVICE_CD_AND_SUFFIX"));
            fleF087_SUBMITTED_REJECTED_CLAIMS_DTL.set_SetValue("EDT_SERVICE_DATE", fleSAVEF087DTL_RETAIN.GetDecimalValue("EDT_SERVICE_DATE"));
            fleF087_SUBMITTED_REJECTED_CLAIMS_DTL.set_SetValue("EDT_DTL_DIAG_CD", fleSAVEF087DTL_RETAIN.GetStringValue("EDT_SERVICE_DATE"));
            fleF087_SUBMITTED_REJECTED_CLAIMS_DTL.set_SetValue("EDT_NBR_SERV", fleSAVEF087DTL_RETAIN.GetDecimalValue("EDT_NBR_SERV"));
            fleF087_SUBMITTED_REJECTED_CLAIMS_DTL.set_SetValue("EDT_AMOUNT_SUBMITTED", fleSAVEF087DTL_RETAIN.GetDecimalValue("EDT_AMOUNT_SUBMITTED"));
            fleF087_SUBMITTED_REJECTED_CLAIMS_DTL.set_SetValue("EDT_DTL_ERR_EXPLAN_CD", fleSAVEF087DTL_RETAIN.GetStringValue("EDT_DTL_ERR_EXPLAN_CD"));
            fleF087_SUBMITTED_REJECTED_CLAIMS_DTL.set_SetValue("EDT_DTL_ERR_CD_1", fleSAVEF087DTL_RETAIN.GetStringValue("EDT_DTL_ERR_CD_1"));
            fleF087_SUBMITTED_REJECTED_CLAIMS_DTL.set_SetValue("EDT_DTL_ERR_CD_2", fleSAVEF087DTL_RETAIN.GetStringValue("EDT_DTL_ERR_CD_2"));
            fleF087_SUBMITTED_REJECTED_CLAIMS_DTL.set_SetValue("EDT_DTL_ERR_CD_3", fleSAVEF087DTL_RETAIN.GetStringValue("EDT_DTL_ERR_CD_3"));
            fleF087_SUBMITTED_REJECTED_CLAIMS_DTL.set_SetValue("EDT_DTL_ERR_CD_4", fleSAVEF087DTL_RETAIN.GetStringValue("EDT_DTL_ERR_CD_4"));
            fleF087_SUBMITTED_REJECTED_CLAIMS_DTL.set_SetValue("EDT_DTL_ERR_CD_5", fleSAVEF087DTL_RETAIN.GetStringValue("EDT_DTL_ERR_CD_5"));
            fleF087_SUBMITTED_REJECTED_CLAIMS_DTL.set_SetValue("EDT_DTL_ERR_8_EXPLAN_CD", fleSAVEF087DTL_RETAIN.GetStringValue("EDT_DTL_ERR_8_EXPLAN_CD"));
            fleF087_SUBMITTED_REJECTED_CLAIMS_DTL.set_SetValue("EDT_DTL_ERR_8_EXPLAN_DESC", fleSAVEF087DTL_RETAIN.GetStringValue("EDT_DTL_ERR_8_EXPLAN_DESC"));
            fleF087_SUBMITTED_REJECTED_CLAIMS_DTL.set_SetValue("ENTRY_DATE", fleSAVEF087DTL_RETAIN.GetDecimalValue("ENTRY_DATE"));
            fleF087_SUBMITTED_REJECTED_CLAIMS_DTL.set_SetValue("ENTRY_TIME_LONG", fleSAVEF087DTL_RETAIN.GetDecimalValue("ENTRY_TIME_LONG"));
            fleF087_SUBMITTED_REJECTED_CLAIMS_DTL.set_SetValue("ENTRY_USER_ID", fleSAVEF087DTL_RETAIN.GetStringValue("ENTRY_USER_ID"));
            fleF087_SUBMITTED_REJECTED_CLAIMS_DTL.set_SetValue("LAST_MOD_DATE", fleSAVEF087DTL_RETAIN.GetDecimalValue("LAST_MOD_DATE"));
            fleF087_SUBMITTED_REJECTED_CLAIMS_DTL.set_SetValue("LAST_MOD_TIME", fleSAVEF087DTL_RETAIN.GetDecimalValue("LAST_MOD_TIME"));
            fleF087_SUBMITTED_REJECTED_CLAIMS_DTL.set_SetValue("LAST_MOD_USER_ID", fleSAVEF087DTL_RETAIN.GetStringValue("LAST_MOD_USER_ID"));

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

    #region "Standard Generated Procedures(RELOAD_F087_DTL)"

    #region "Automatic Item Initialization(RELOAD_F087_DTL)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:01:47 PM

    //#-----------------------------------------
    //# fleF001_ADD_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 3:01:47 PM
    //#-----------------------------------------

    #endregion

    #region "Transaction Management Procedures(RELOAD_F087_DTL)"

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
        fleSAVEF087DTL_RETAIN.Transaction = m_trnTRANS_UPDATE;
        fleF087_SUBMITTED_REJECTED_CLAIMS_DTL.Transaction = m_trnTRANS_UPDATE;
    }

    #endregion

    #region "FILE Management Procedures(RELOAD_F087_DTL)"

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
            fleSAVEF087DTL_RETAIN.Dispose();
            fleF087_SUBMITTED_REJECTED_CLAIMS_DTL.Dispose();
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

    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(RELOAD_F087_DTL)"

    public void Run()
    {
        try
        {
            Request("RELOAD_F087_DTL");
            while (fleSAVEF087DTL_RETAIN.QTPForMissing())
            {
                //  --> GET SAVEF087_RETAIN <--
                fleSAVEF087DTL_RETAIN.GetData();
                //  --> End GET SAVEF087_RETAIN <--

                if (Transaction())
                {
                    fleF087_SUBMITTED_REJECTED_CLAIMS_DTL.OutPut(OutPutType.Add);
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
            EndRequest("RELOAD_F087_DTL");
        }
    }

    #endregion
}
// RELOAD_F087_DTL_2