
#region "Screen Comments"

//  2006/jun/15 - MC - reload f020 history file

#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;

public class PURGE_RELOF020_HISTORY : BaseClassControl
{
    private PURGE_RELOF020_HISTORY m_PURGE_RELOF020_HISTORY;

    public PURGE_RELOF020_HISTORY(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
    }

    public PURGE_RELOF020_HISTORY(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
    }

    public override void Dispose()
    {
        if (!(m_PURGE_RELOF020_HISTORY == null))
        {
            m_PURGE_RELOF020_HISTORY.CloseTransactionObjects();
            m_PURGE_RELOF020_HISTORY = null;
        }
    }

    public PURGE_RELOF020_HISTORY GetPURGE_RELOF020_HISTORY(int Level)
    {
        if ((m_PURGE_RELOF020_HISTORY == null))
        {
            m_PURGE_RELOF020_HISTORY = new PURGE_RELOF020_HISTORY("PURGE_RELOF020_HISTORY", Level);
        }
        else
        {
            m_PURGE_RELOF020_HISTORY.ResetValues();
        }

        return m_PURGE_RELOF020_HISTORY;
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
            PURGE_RELOF020_HISTORY_RELOAD_F020_HIST_1 RELOAD_F020_HIST_1 = new PURGE_RELOF020_HISTORY_RELOAD_F020_HIST_1(Name, Level);
            RELOAD_F020_HIST_1.Run();
            RELOAD_F020_HIST_1.Dispose();
            RELOAD_F020_HIST_1 = null;

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
public class PURGE_RELOF020_HISTORY_RELOAD_F020_HIST_1 : PURGE_RELOF020_HISTORY
{
    public PURGE_RELOF020_HISTORY_RELOAD_F020_HIST_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;

        fleSAVEF020HIST_RETAIN = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "SAVEF020HIST_RETAIN", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF020_DOC_MSTR_HISTORY = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOC_MSTR_HISTORY", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF020_DOC_MSTR_HISTORY.SetItemFinals += fleF020_DOC_MSTR_HISTORY_SetItemFinals;
    }

    #region "Declarations (Variables, Files and Transactions)(PURGE_RELOF020_HISTORY)"

    private SqlFileObject fleSAVEF020HIST_RETAIN;
    private SqlFileObject fleF020_DOC_MSTR_HISTORY;

    private void fleF020_DOC_MSTR_HISTORY_SetItemFinals()
    {
        try
        {
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_NBR", fleSAVEF020HIST_RETAIN.GetStringValue("DOC_NBR"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("EP_NBR", fleSAVEF020HIST_RETAIN.GetDecimalValue("EP_NBR"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_BANK_NBR", fleSAVEF020HIST_RETAIN.GetDecimalValue("DOC_BANK_NBR"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_BANK_BRANCH", fleSAVEF020HIST_RETAIN.GetDecimalValue("DOC_BANK_BRANCH"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_BANK_ACCT", fleSAVEF020HIST_RETAIN.GetStringValue("DOC_BANK_ACCT"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_YTDGUA", fleSAVEF020HIST_RETAIN.GetDecimalValue("DOC_YTDGUA"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_YTDGUB", fleSAVEF020HIST_RETAIN.GetDecimalValue("DOC_YTDGUB"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_YTDGUC", fleSAVEF020HIST_RETAIN.GetDecimalValue("DOC_YTDGUC"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_YTDGUD", fleSAVEF020HIST_RETAIN.GetDecimalValue("DOC_YTDGUD"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_YTDCEA", fleSAVEF020HIST_RETAIN.GetDecimalValue("DOC_YTDCEA"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_YTDCEX", fleSAVEF020HIST_RETAIN.GetDecimalValue("DOC_YTDCEX"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_YTDEAR", fleSAVEF020HIST_RETAIN.GetDecimalValue("DOC_YTDEAR"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_YTDINC", fleSAVEF020HIST_RETAIN.GetDecimalValue("DOC_YTDINC"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_YTDEFT", fleSAVEF020HIST_RETAIN.GetDecimalValue("DOC_YTDEFT"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_TOTINC_G", fleSAVEF020HIST_RETAIN.GetDecimalValue("DOC_TOTINC_G"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_EP_DATE_DEPOSIT", fleSAVEF020HIST_RETAIN.GetDecimalValue("DOC_EP_DATE_DEPOSIT"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_TOTINC", fleSAVEF020HIST_RETAIN.GetDecimalValue("DOC_TOTINC"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_EP_CEIEXP", fleSAVEF020HIST_RETAIN.GetDecimalValue("DOC_EP_CEIEXP"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_ADJCEA", fleSAVEF020HIST_RETAIN.GetDecimalValue("DOC_ADJCEA"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_ADJCEX", fleSAVEF020HIST_RETAIN.GetDecimalValue("DOC_ADJCEX"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_CEICEA", fleSAVEF020HIST_RETAIN.GetDecimalValue("DOC_CEICEA"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_CEICEX", fleSAVEF020HIST_RETAIN.GetDecimalValue("DOC_CEICEX"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("CEICEX_PRT_FORMAT", fleSAVEF020HIST_RETAIN.GetStringValue("CEICEX_PRT_FORMAT"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("CEICEA_PRT_FORMAT", fleSAVEF020HIST_RETAIN.GetStringValue("CEICEA_PRT_FORMAT"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("YTDCEA_PRT_FORMAT", fleSAVEF020HIST_RETAIN.GetStringValue("YTDCEA_PRT_FORMAT"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("YTDCEX_PRT_FORMAT", fleSAVEF020HIST_RETAIN.GetStringValue("YTDCEX_PRT_FORMAT"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_YTDINC_G", fleSAVEF020HIST_RETAIN.GetDecimalValue("DOC_YTDINC_G"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_RMA_EXPENSE_PERCENT_MISC", fleSAVEF020HIST_RETAIN.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_MISC"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_RMA_EXPENSE_PERCENT_REG", fleSAVEF020HIST_RETAIN.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_REG"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_YRLY_CEILING_COMPUTED", fleSAVEF020HIST_RETAIN.GetDecimalValue("DOC_YRLY_CEILING_COMPUTED"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_YRLY_EXPENSE_COMPUTED", fleSAVEF020HIST_RETAIN.GetDecimalValue("DOC_YRLY_EXPENSE_COMPUTED"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_PAYEFT", fleSAVEF020HIST_RETAIN.GetDecimalValue("DOC_PAYEFT"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_YTDDED", fleSAVEF020HIST_RETAIN.GetDecimalValue("DOC_YTDDED"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_MISC", fleSAVEF020HIST_RETAIN.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_MISC"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_REG", fleSAVEF020HIST_RETAIN.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_REG"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_EP_PED", fleSAVEF020HIST_RETAIN.GetDecimalValue("DOC_EP_PED"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_EP_PAY_CODE", fleSAVEF020HIST_RETAIN.GetStringValue("DOC_EP_PAY_CODE"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_EP_PAY_SUB_CODE", fleSAVEF020HIST_RETAIN.GetStringValue("DOC_EP_PAY_SUB_CODE"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_YRLY_REQUIRE_REVENUE", fleSAVEF020HIST_RETAIN.GetDecimalValue("DOC_YRLY_REQUIRE_REVENUE"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_YRLY_TARGET_REVENUE", fleSAVEF020HIST_RETAIN.GetDecimalValue("DOC_YRLY_TARGET_REVENUE"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_CEIREQ", fleSAVEF020HIST_RETAIN.GetDecimalValue("DOC_CEIREQ"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_YTDREQ", fleSAVEF020HIST_RETAIN.GetDecimalValue("DOC_YTDREQ"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_CEITAR", fleSAVEF020HIST_RETAIN.GetDecimalValue("DOC_CEITAR"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_YTDTAR", fleSAVEF020HIST_RETAIN.GetDecimalValue("DOC_YTDTAR"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("CEIREQ_PRT_FORMAT", fleSAVEF020HIST_RETAIN.GetStringValue("CEIREQ_PRT_FORMAT"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("YTDREQ_PRT_FORMAT", fleSAVEF020HIST_RETAIN.GetStringValue("YTDREQ_PRT_FORMAT"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("CEITAR_PRT_FORMAT", fleSAVEF020HIST_RETAIN.GetStringValue("CEITAR_PRT_FORMAT"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("YTDTAR_PRT_FORMAT", fleSAVEF020HIST_RETAIN.GetStringValue("YTDTAR_PRT_FORMAT"));
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

    #region "Standard Generated Procedures(RELOAD_F020_HIST_1)"

    #region "Automatic Item Initialization(RELOAD_F020_HIST_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:01:47 PM

    //#-----------------------------------------
    //# fleF001_ADD_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 3:01:47 PM
    //#-----------------------------------------

    #endregion

    #region "Transaction Management Procedures(RELOAD_F020_HIST_1)"

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
        fleSAVEF020HIST_RETAIN.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOC_MSTR_HISTORY.Transaction = m_trnTRANS_UPDATE;
    }

    #endregion

    #region "FILE Management Procedures(RELOAD_F020_HIST_1)"

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
            fleSAVEF020HIST_RETAIN.Dispose();
            fleF020_DOC_MSTR_HISTORY.Dispose();
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

    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(RELOAD_F020_HIST_1)"

    public void Run()
    {
        try
        {
            Request("RELOAD_F020_HIST");
            while (fleSAVEF020HIST_RETAIN.QTPForMissing())
            {
                //  --> GET SAVEF020HIST_RETAIN <--
                fleSAVEF020HIST_RETAIN.GetData();
                //  --> End GET SAVEF020HIST_RETAIN <--

                if (Transaction())
                {
                    fleF020_DOC_MSTR_HISTORY.OutPut(OutPutType.Add);
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
            EndRequest("RELOAD_F020_HIST");
        }
    }

    #endregion
}
// RELOAD_F020_HIST_1
