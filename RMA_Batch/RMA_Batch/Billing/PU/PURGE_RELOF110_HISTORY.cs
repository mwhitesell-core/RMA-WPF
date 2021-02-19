
#region "Screen Comments"

//  2006/jun/15 - MC - reload f110 history file

#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;

public class PURGE_RELOF110_HISTORY : BaseClassControl
{
    private PURGE_RELOF110_HISTORY m_PURGE_RELOF110_HISTORY;

    public PURGE_RELOF110_HISTORY(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
    }

    public PURGE_RELOF110_HISTORY(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
    }

    public override void Dispose()
    {
        if (!(m_PURGE_RELOF110_HISTORY == null))
        {
            m_PURGE_RELOF110_HISTORY.CloseTransactionObjects();
            m_PURGE_RELOF110_HISTORY = null;
        }
    }

    public PURGE_RELOF110_HISTORY GetPURGE_RELOF110_HISTORY(int Level)
    {
        if ((m_PURGE_RELOF110_HISTORY == null))
        {
            m_PURGE_RELOF110_HISTORY = new PURGE_RELOF110_HISTORY("PURGE_RELOF110_HISTORY", Level);
        }
        else
        {
            m_PURGE_RELOF110_HISTORY.ResetValues();
        }

        return m_PURGE_RELOF110_HISTORY;
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
            PURGE_RELOF110_HISTORY_RELOAD_F110_HIST_1 RELOAD_F110_HIST_1 = new PURGE_RELOF110_HISTORY_RELOAD_F110_HIST_1(Name, Level);
            RELOAD_F110_HIST_1.Run();
            RELOAD_F110_HIST_1.Dispose();
            RELOAD_F110_HIST_1 = null;

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
public class PURGE_RELOF110_HISTORY_RELOAD_F110_HIST_1 : PURGE_RELOF110_HISTORY
{
    public PURGE_RELOF110_HISTORY_RELOAD_F110_HIST_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;

        fleSAVEF110HIST_RETAIN = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "SAVEF110HIST_RETAIN", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF110_COMPENSATION_HISTORY = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION_HISTORY", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF110_COMPENSATION_HISTORY.SetItemFinals += fleF110_COMPENSATION_HISTORY_SetItemFinals;
    }

    #region "Declarations (Variables, Files and Transactions)(RELOAD_F110_HIST_1)"

    private SqlFileObject fleSAVEF110HIST_RETAIN;
    private SqlFileObject fleF110_COMPENSATION_HISTORY;

    private void fleF110_COMPENSATION_HISTORY_SetItemFinals()
    {
        try
        {
            fleF110_COMPENSATION_HISTORY.set_SetValue("DOC_NBR", fleSAVEF110HIST_RETAIN.GetStringValue("DOC_NBR"));
            fleF110_COMPENSATION_HISTORY.set_SetValue("EP_NBR", fleSAVEF110HIST_RETAIN.GetDecimalValue("EP_NBR"));
            fleF110_COMPENSATION_HISTORY.set_SetValue("PROCESS_SEQ", fleSAVEF110HIST_RETAIN.GetDecimalValue("PROCESS_SEQ"));
            fleF110_COMPENSATION_HISTORY.set_SetValue("COMP_CODE", fleSAVEF110HIST_RETAIN.GetStringValue("COMP_CODE"));
            fleF110_COMPENSATION_HISTORY.set_SetValue("COMP_TYPE", fleSAVEF110HIST_RETAIN.GetStringValue("COMP_TYPE"));
            fleF110_COMPENSATION_HISTORY.set_SetValue("FACTOR", fleSAVEF110HIST_RETAIN.GetDecimalValue("FACTOR"));
            fleF110_COMPENSATION_HISTORY.set_SetValue("FACTOR_OVERRIDE", fleSAVEF110HIST_RETAIN.GetStringValue("FACTOR_OVERRIDE"));
            fleF110_COMPENSATION_HISTORY.set_SetValue("COMP_UNITS", fleSAVEF110HIST_RETAIN.GetDecimalValue("COMP_UNITS"));
            fleF110_COMPENSATION_HISTORY.set_SetValue("AMT_GROSS", fleSAVEF110HIST_RETAIN.GetDecimalValue("AMT_GROSS"));
            fleF110_COMPENSATION_HISTORY.set_SetValue("AMT_NET", fleSAVEF110HIST_RETAIN.GetDecimalValue("AMT_NET"));
            fleF110_COMPENSATION_HISTORY.set_SetValue("EP_NBR_ENTRY", fleSAVEF110HIST_RETAIN.GetDecimalValue("EP_NBR_ENTRY"));
            fleF110_COMPENSATION_HISTORY.set_SetValue("COMPENSATION_STATUS", fleSAVEF110HIST_RETAIN.GetStringValue("COMPENSATION_STATUS"));
            fleF110_COMPENSATION_HISTORY.set_SetValue("LAST_MOD_DATE", fleSAVEF110HIST_RETAIN.GetDecimalValue("LAST_MOD_DATE"));
            fleF110_COMPENSATION_HISTORY.set_SetValue("LAST_MOD_TIME", fleSAVEF110HIST_RETAIN.GetDecimalValue("LAST_MOD_TIME"));
            fleF110_COMPENSATION_HISTORY.set_SetValue("LAST_MOD_USER_ID", fleSAVEF110HIST_RETAIN.GetStringValue("LAST_MOD_USER_ID"));
            fleF110_COMPENSATION_HISTORY.set_SetValue("FILLER", fleSAVEF110HIST_RETAIN.GetStringValue("FILLER"));
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

    #region "Standard Generated Procedures(RELOAD_F110_HIST_1)"

    #region "Automatic Item Initialization(RELOAD_F110_HIST_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:01:47 PM

    //#-----------------------------------------
    //# fleF001_ADD_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 3:01:47 PM
    //#-----------------------------------------

    #endregion

    #region "Transaction Management Procedures(RELOAD_F110_HIST_1)"

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
        fleSAVEF110HIST_RETAIN.Transaction = m_trnTRANS_UPDATE;
        fleF110_COMPENSATION_HISTORY.Transaction = m_trnTRANS_UPDATE;
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
            fleSAVEF110HIST_RETAIN.Dispose();
            fleF110_COMPENSATION_HISTORY.Dispose();
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
            Request("RELOAD_F110_HIST");
            while (fleSAVEF110HIST_RETAIN.QTPForMissing())
            {
                //  --> GET SAVEF110HIST_RETAIN <--
                fleSAVEF110HIST_RETAIN.GetData();
                //  --> End GET SAVEF110HIST_RETAIN <--

                if (Transaction())
                {
                    fleF110_COMPENSATION_HISTORY.OutPut(OutPutType.Add);
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
// RELOAD_F110_HIST_1
