
#region "Screen Comments"

//  2006/jun/15 - MC - reload f112 history file

#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;

public class PURGE_RELOF112_HISTORY : BaseClassControl
{
    private PURGE_RELOF112_HISTORY m_PURGE_RELOF112_HISTORY;

    public PURGE_RELOF112_HISTORY(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
    }

    public PURGE_RELOF112_HISTORY(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
    }

    public override void Dispose()
    {
        if (!(m_PURGE_RELOF112_HISTORY == null))
        {
            m_PURGE_RELOF112_HISTORY.CloseTransactionObjects();
            m_PURGE_RELOF112_HISTORY = null;
        }
    }

    public PURGE_RELOF112_HISTORY GetPURGE_RELOF112_HISTORY(int Level)
    {
        if ((m_PURGE_RELOF112_HISTORY == null))
        {
            m_PURGE_RELOF112_HISTORY = new PURGE_RELOF112_HISTORY("PURGE_RELOF112_HISTORY", Level);
        }
        else
        {
            m_PURGE_RELOF112_HISTORY.ResetValues();
        }

        return m_PURGE_RELOF112_HISTORY;
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
            PURGE_RELOF112_HISTORY_RELOAD_F112_HIST_1 RELOAD_F112_HIST_1 = new PURGE_RELOF112_HISTORY_RELOAD_F112_HIST_1(Name, Level);
            RELOAD_F112_HIST_1.Run();
            RELOAD_F112_HIST_1.Dispose();
            RELOAD_F112_HIST_1 = null;

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
public class PURGE_RELOF112_HISTORY_RELOAD_F112_HIST_1 : PURGE_RELOF112_HISTORY
{
    public PURGE_RELOF112_HISTORY_RELOAD_F112_HIST_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;

        fleSAVEF112HIST_RETAIN = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "SAVEF112HIST_RETAIN", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF112_PYCDCEILINGS_HISTORY = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F112_PYCDCEILINGS_HISTORY", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF112_PYCDCEILINGS_HISTORY.SetItemFinals += flefleF112_PYCDCEILINGS_HISTORY_SetItemFinals;
    }

    #region "Declarations (Variables, Files and Transactions)(RELOAD_F112_HIST_1)"

    private SqlFileObject fleSAVEF112HIST_RETAIN;
    private SqlFileObject fleF112_PYCDCEILINGS_HISTORY;

    private void flefleF112_PYCDCEILINGS_HISTORY_SetItemFinals()
    {
        try
        {
            fleF112_PYCDCEILINGS_HISTORY.set_SetValue("DOC_NBR", fleSAVEF112HIST_RETAIN.GetStringValue("DOC_NBR"));
            fleF112_PYCDCEILINGS_HISTORY.set_SetValue("EP_NBR", fleSAVEF112HIST_RETAIN.GetDecimalValue("EP_NBR"));
            fleF112_PYCDCEILINGS_HISTORY.set_SetValue("FACTOR", fleSAVEF112HIST_RETAIN.GetDecimalValue("FACTOR"));
            fleF112_PYCDCEILINGS_HISTORY.set_SetValue("DOC_PAY_CODE", fleSAVEF112HIST_RETAIN.GetStringValue("DOC_PAY_CODE"));
            fleF112_PYCDCEILINGS_HISTORY.set_SetValue("DOC_PAY_SUB_CODE", fleSAVEF112HIST_RETAIN.GetStringValue("DOC_PAY_SUB_CODE"));
            fleF112_PYCDCEILINGS_HISTORY.set_SetValue("RETRO_TO_EP_NBR", fleSAVEF112HIST_RETAIN.GetDecimalValue("RETRO_TO_EP_NBR"));
            fleF112_PYCDCEILINGS_HISTORY.set_SetValue("DOC_YRLY_CEILING", fleSAVEF112HIST_RETAIN.GetDecimalValue("DOC_YRLY_CEILING"));
            fleF112_PYCDCEILINGS_HISTORY.set_SetValue("DOC_YRLY_CEILING_ADJUSTED", fleSAVEF112HIST_RETAIN.GetDecimalValue("DOC_YRLY_CEILING_ADJUSTED"));
            fleF112_PYCDCEILINGS_HISTORY.set_SetValue("DOC_YRLY_CEILING_COMPUTED", fleSAVEF112HIST_RETAIN.GetDecimalValue("DOC_YRLY_CEILING_COMPUTED"));
            fleF112_PYCDCEILINGS_HISTORY.set_SetValue("DOC_YRLY_EXPENSE", fleSAVEF112HIST_RETAIN.GetDecimalValue("DOC_YRLY_EXPENSE"));
            fleF112_PYCDCEILINGS_HISTORY.set_SetValue("DOC_YRLY_EXPENSE_ADJUSTED", fleSAVEF112HIST_RETAIN.GetDecimalValue("DOC_YRLY_EXPENSE_ADJUSTED"));
            fleF112_PYCDCEILINGS_HISTORY.set_SetValue("DOC_YRLY_EXPENSE_COMPUTED", fleSAVEF112HIST_RETAIN.GetDecimalValue("DOC_YRLY_EXPENSE_COMPUTED"));
            fleF112_PYCDCEILINGS_HISTORY.set_SetValue("DOC_YRLY_EXPN_ALLOC_PERS", fleSAVEF112HIST_RETAIN.GetDecimalValue("DOC_YRLY_EXPN_ALLOC_PERS"));
            fleF112_PYCDCEILINGS_HISTORY.set_SetValue("DOC_YRLY_CEIL_GUAR", fleSAVEF112HIST_RETAIN.GetDecimalValue("DOC_YRLY_CEIL_GUAR"));
            fleF112_PYCDCEILINGS_HISTORY.set_SetValue("DOC_YRLY_CEILING_GUAR_PERC", fleSAVEF112HIST_RETAIN.GetDecimalValue("DOC_YRLY_CEILING_GUAR_PERC"));
            fleF112_PYCDCEILINGS_HISTORY.set_SetValue("LAST_MOD_DATE", fleSAVEF112HIST_RETAIN.GetDecimalValue("LAST_MOD_DATE"));
            fleF112_PYCDCEILINGS_HISTORY.set_SetValue("LAST_MOD_TIME", fleSAVEF112HIST_RETAIN.GetDecimalValue("LAST_MOD_TIME"));
            fleF112_PYCDCEILINGS_HISTORY.set_SetValue("LAST_MOD_USER_ID", fleSAVEF112HIST_RETAIN.GetStringValue("LAST_MOD_USER_ID"));
            fleF112_PYCDCEILINGS_HISTORY.set_SetValue("DOC_RMA_EXPENSE_PERCENT_REG", fleSAVEF112HIST_RETAIN.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_REG"));
            fleF112_PYCDCEILINGS_HISTORY.set_SetValue("DOC_RMA_EXPENSE_PERCENT_MISC", fleSAVEF112HIST_RETAIN.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_MISC"));
            fleF112_PYCDCEILINGS_HISTORY.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_REG", fleSAVEF112HIST_RETAIN.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_REG"));
            fleF112_PYCDCEILINGS_HISTORY.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_MISC", fleSAVEF112HIST_RETAIN.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_MISC"));
            fleF112_PYCDCEILINGS_HISTORY.set_SetValue("DOC_YRLY_REQREV", fleSAVEF112HIST_RETAIN.GetDecimalValue("DOC_YRLY_REQREV"));
            fleF112_PYCDCEILINGS_HISTORY.set_SetValue("DOC_YRLY_REQREV_ADJUSTED", fleSAVEF112HIST_RETAIN.GetDecimalValue("DOC_YRLY_REQREV_ADJUSTED"));
            fleF112_PYCDCEILINGS_HISTORY.set_SetValue("DOC_YRLY_REQREV_COMPUTED", fleSAVEF112HIST_RETAIN.GetDecimalValue("DOC_YRLY_REQREV_COMPUTED"));
            fleF112_PYCDCEILINGS_HISTORY.set_SetValue("DOC_YRLY_TARREV", fleSAVEF112HIST_RETAIN.GetDecimalValue("DOC_YRLY_TARREV"));
            fleF112_PYCDCEILINGS_HISTORY.set_SetValue("DOC_YRLY_TARREV_ADJUSTED", fleSAVEF112HIST_RETAIN.GetDecimalValue("DOC_YRLY_TARREV_ADJUSTED"));
            fleF112_PYCDCEILINGS_HISTORY.set_SetValue("DOC_YRLY_TARREV_COMPUTED", fleSAVEF112HIST_RETAIN.GetDecimalValue("DOC_YRLY_TARREV_COMPUTED"));
            fleF112_PYCDCEILINGS_HISTORY.set_SetValue("RETRO_TO_EP_NBR_REQ", fleSAVEF112HIST_RETAIN.GetDecimalValue("RETRO_TO_EP_NBR_REQ"));
            fleF112_PYCDCEILINGS_HISTORY.set_SetValue("RETRO_TO_EP_NBR_TAR", fleSAVEF112HIST_RETAIN.GetDecimalValue("RETRO_TO_EP_NBR_TAR"));
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

    #region "Standard Generated Procedures(RELOAD_F112_HIST_1)"

    #region "Automatic Item Initialization(RELOAD_F112_HIST_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:01:47 PM

    //#-----------------------------------------
    //# fleF001_ADD_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 3:01:47 PM
    //#-----------------------------------------

    #endregion

    #region "Transaction Management Procedures(RELOAD_F112_HIST_1)"

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
        fleSAVEF112HIST_RETAIN.Transaction = m_trnTRANS_UPDATE;
        fleF112_PYCDCEILINGS_HISTORY.Transaction = m_trnTRANS_UPDATE;
    }

    #endregion

    #region "FILE Management Procedures(RELOAD_F110_HIST_1)"

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
            fleSAVEF112HIST_RETAIN.Dispose();
            fleF112_PYCDCEILINGS_HISTORY.Dispose();
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

    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(RELOAD_F110_HIST_1)"

    public void Run()
    {
        try
        {
            Request("RELOAD_F112_HIST");
            while (fleSAVEF112HIST_RETAIN.QTPForMissing())
            {
                //  --> GET SAVEF112HIST_RETAIN <--
                fleSAVEF112HIST_RETAIN.GetData();
                //  --> End GET SAVEF112HIST_RETAIN <--

                if (Transaction())
                {
                    fleF112_PYCDCEILINGS_HISTORY.OutPut(OutPutType.Add);
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
            EndRequest("RELOAD_F110_HIST");
        }
    }

    #endregion
}
// RELOAD_F112_HIST_1
