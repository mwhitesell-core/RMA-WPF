
#region "Screen Comments"

//  2015/Sep/14 - MC - reload f084-claims-inventory

#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;

public class PURGE_RELOF084 : BaseClassControl
{
    private PURGE_RELOF084 m_PURGE_RELOF084;

    public PURGE_RELOF084(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
    }

    public PURGE_RELOF084(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
    }

    public override void Dispose()
    {
        if (!(m_PURGE_RELOF084 == null))
        {
            m_PURGE_RELOF084.CloseTransactionObjects();
            m_PURGE_RELOF084 = null;
        }
    }

    public PURGE_RELOF084 GetPURGE_RELOF084(int Level)
    {
        if ((m_PURGE_RELOF084 == null))
        {
            m_PURGE_RELOF084 = new PURGE_RELOF084("PURGE_RELOF084", Level);
        }
        else
        {
            m_PURGE_RELOF084.ResetValues();
        }

        return m_PURGE_RELOF084;
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
            PURGE_RELOF084_RELOAD_F084_1 RELOAD_F084_1 = new PURGE_RELOF084_RELOAD_F084_1(Name, Level);
            RELOAD_F084_1.Run();
            RELOAD_F084_1.Dispose();
            RELOAD_F084_1 = null;

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
public class PURGE_RELOF084_RELOAD_F084_1 : PURGE_RELOF084
{
    public PURGE_RELOF084_RELOAD_F084_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;

        fleSAVEF084_RETAIN = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "SAVEF084_RETAIN", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF084_CLAIMS_INVENTORY = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F084_CLAIMS_INVENTORY", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF084_CLAIMS_INVENTORY.SetItemFinals += fleF084_CLAIMS_INVENTORY_SetItemFinals;
    }

    #region "Declarations (Variables, Files and Transactions)(RELOAD_F084)"

    private SqlFileObject fleSAVEF084_RETAIN;
    private SqlFileObject fleF084_CLAIMS_INVENTORY;

    private void fleF084_CLAIMS_INVENTORY_SetItemFinals()
    {
        try
        {
            fleF084_CLAIMS_INVENTORY.set_SetValue("CLMHDR_CLINIC_NBR_1_2", fleSAVEF084_RETAIN.GetDecimalValue("CLMHDR_CLINIC_NBR_1_2"));
            fleF084_CLAIMS_INVENTORY.set_SetValue("DOC_NBR", fleSAVEF084_RETAIN.GetStringValue("DOC_NBR"));
            fleF084_CLAIMS_INVENTORY.set_SetValue("ICONST_DATE_PERIOD_END", fleSAVEF084_RETAIN.GetDecimalValue("ICONST_DATE_PERIOD_END"));
            fleF084_CLAIMS_INVENTORY.set_SetValue("BATCH_RECEIVED_DATE", fleSAVEF084_RETAIN.GetDecimalValue("BATCH_RECEIVED_DATE"));
            fleF084_CLAIMS_INVENTORY.set_SetValue("ENTRY_TIME_LONG", fleSAVEF084_RETAIN.GetDecimalValue("ENTRY_TIME_LONG"));
            fleF084_CLAIMS_INVENTORY.set_SetValue("ENTRY_DATE", fleSAVEF084_RETAIN.GetDecimalValue("ENTRY_DATE"));
            fleF084_CLAIMS_INVENTORY.set_SetValue("ENTRY_USER_ID", fleSAVEF084_RETAIN.GetStringValue("ENTRY_USER_ID"));
            fleF084_CLAIMS_INVENTORY.set_SetValue("LAST_MOD_DATE", fleSAVEF084_RETAIN.GetDecimalValue("LAST_MOD_DATE"));
            fleF084_CLAIMS_INVENTORY.set_SetValue("LAST_MOD_TIME", fleSAVEF084_RETAIN.GetDecimalValue("LAST_MOD_TIME"));
            fleF084_CLAIMS_INVENTORY.set_SetValue("LAST_MOD_USER_ID", fleSAVEF084_RETAIN.GetStringValue("LAST_MOD_USER_ID"));
            fleF084_CLAIMS_INVENTORY.set_SetValue("CLAIM_SOURCE", fleSAVEF084_RETAIN.GetStringValue("CLAIM_SOURCE"));
            fleF084_CLAIMS_INVENTORY.set_SetValue("NBR_CLAIMS_BATCHES", fleSAVEF084_RETAIN.GetDecimalValue("NBR_CLAIMS_BATCHES"));
            fleF084_CLAIMS_INVENTORY.set_SetValue("NBR_CLAIMS_QUERIED", fleSAVEF084_RETAIN.GetDecimalValue("NBR_CLAIMS_QUERIED"));
            fleF084_CLAIMS_INVENTORY.set_SetValue("NBR_CLAIMS_UNPROCESSED", fleSAVEF084_RETAIN.GetDecimalValue("NBR_CLAIMS_UNPROCESSED"));
            fleF084_CLAIMS_INVENTORY.set_SetValue("BILLING_CLERK_INITIALS", fleSAVEF084_RETAIN.GetStringValue("BILLING_CLERK_INITIALS"));

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

    #region "Standard Generated Procedures(RELOAD_F084)"

    #region "Automatic Item Initialization(RELOAD_F084)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:01:47 PM

    //#-----------------------------------------
    //# fleF001_ADD_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 3:01:47 PM
    //#-----------------------------------------

    #endregion

    #region "Transaction Management Procedures(RELOAD_F084)"

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
        fleSAVEF084_RETAIN.Transaction = m_trnTRANS_UPDATE;
        fleF084_CLAIMS_INVENTORY.Transaction = m_trnTRANS_UPDATE;
    }

    #endregion

    #region "FILE Management Procedures(RELOAD_F084)"

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
            fleSAVEF084_RETAIN.Dispose();
            fleF084_CLAIMS_INVENTORY.Dispose();
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

    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(RELOAD_F084)"

    public void Run()
    {
        try
        {
            Request("RELOAD_F084");
            while (fleSAVEF084_RETAIN.QTPForMissing())
            {
                //  --> GET SAVEF084_RETAIN <--
                fleSAVEF084_RETAIN.GetData();
                //  --> End GET SAVEF084_RETAIN <--

                if (Transaction())
                {
                    fleF084_CLAIMS_INVENTORY.OutPut(OutPutType.Add);
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
            EndRequest("RELOAD_F084");
        }
    }

    #endregion
}
// RELOAD_F084_1
