
#region "Screen Comments"

//  2006/jun/15 - MC - reload f113 history file

#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;

public class PURGE_RELOF113_HISTORY : BaseClassControl
{
    private PURGE_RELOF113_HISTORY m_PURGE_RELOF113_HISTORY;

    public PURGE_RELOF113_HISTORY(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
    }

    public PURGE_RELOF113_HISTORY(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
    }

    public override void Dispose()
    {
        if (!(m_PURGE_RELOF113_HISTORY == null))
        {
            m_PURGE_RELOF113_HISTORY.CloseTransactionObjects();
            m_PURGE_RELOF113_HISTORY = null;
        }
    }

    public PURGE_RELOF113_HISTORY GetPURGE_RELOF113_HISTORY(int Level)
    {
        if ((m_PURGE_RELOF113_HISTORY == null))
        {
            m_PURGE_RELOF113_HISTORY = new PURGE_RELOF113_HISTORY("PURGE_RELOF113_HISTORY", Level);
        }
        else
        {
            m_PURGE_RELOF113_HISTORY.ResetValues();
        }

        return m_PURGE_RELOF113_HISTORY;
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
            PURGE_RELOF113_HISTORY_RELOAD_F113_HIST_1 RELOAD_F113_HIST_1 = new PURGE_RELOF113_HISTORY_RELOAD_F113_HIST_1(Name, Level);
            RELOAD_F113_HIST_1.Run();
            RELOAD_F113_HIST_1.Dispose();
            RELOAD_F113_HIST_1 = null;

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
public class PURGE_RELOF113_HISTORY_RELOAD_F113_HIST_1 : PURGE_RELOF113_HISTORY
{
    public PURGE_RELOF113_HISTORY_RELOAD_F113_HIST_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;

        fleSAVEF113HIST_RETAIN = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "SAVEF113HIST_RETAIN", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF113_DEFAULT_COMP_HISTORY = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F113_DEFAULT_COMP_HISTORY", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF113_DEFAULT_COMP_HISTORY.SetItemFinals += fleF113_DEFAULT_COMP_HISTORY_SetItemFinals;
    }

    #region "Declarations (Variables, Files and Transactions)(RELOAD_F113_HIST_1)"

    private SqlFileObject fleSAVEF113HIST_RETAIN;
    private SqlFileObject fleF113_DEFAULT_COMP_HISTORY;

    private void fleF113_DEFAULT_COMP_HISTORY_SetItemFinals()
    {
        try
        {
            fleF113_DEFAULT_COMP_HISTORY.set_SetValue("DOC_NBR", fleSAVEF113HIST_RETAIN.GetStringValue("DOC_NBR"));
            fleF113_DEFAULT_COMP_HISTORY.set_SetValue("EP_YR", fleSAVEF113HIST_RETAIN.GetDecimalValue("EP_YR"));
            fleF113_DEFAULT_COMP_HISTORY.set_SetValue("EP_MM", fleSAVEF113HIST_RETAIN.GetDecimalValue("EP_MM"));
            fleF113_DEFAULT_COMP_HISTORY.set_SetValue("COMP_CODE", fleSAVEF113HIST_RETAIN.GetStringValue("COMP_CODE"));
            fleF113_DEFAULT_COMP_HISTORY.set_SetValue("EP_NBR_TO", fleSAVEF113HIST_RETAIN.GetDecimalValue("EP_NBR_TO"));
            fleF113_DEFAULT_COMP_HISTORY.set_SetValue("FACTOR", fleSAVEF113HIST_RETAIN.GetDecimalValue("FACTOR"));
            fleF113_DEFAULT_COMP_HISTORY.set_SetValue("FACTOR_OVERRIDE", fleSAVEF113HIST_RETAIN.GetStringValue("FACTOR_OVERRIDE"));
            fleF113_DEFAULT_COMP_HISTORY.set_SetValue("COMP_UNITS", fleSAVEF113HIST_RETAIN.GetDecimalValue("COMP_UNITS"));
            fleF113_DEFAULT_COMP_HISTORY.set_SetValue("AMT_GROSS", fleSAVEF113HIST_RETAIN.GetDecimalValue("AMT_GROSS"));
            fleF113_DEFAULT_COMP_HISTORY.set_SetValue("AMT_NET", fleSAVEF113HIST_RETAIN.GetDecimalValue("AMT_NET"));
            fleF113_DEFAULT_COMP_HISTORY.set_SetValue("EP_NBR_ENTRY", fleSAVEF113HIST_RETAIN.GetDecimalValue("EP_NBR_ENTRY"));
            fleF113_DEFAULT_COMP_HISTORY.set_SetValue("LAST_MOD_DATE", fleSAVEF113HIST_RETAIN.GetDecimalValue("LAST_MOD_DATE"));
            fleF113_DEFAULT_COMP_HISTORY.set_SetValue("LAST_MOD_TIME", fleSAVEF113HIST_RETAIN.GetDecimalValue("LAST_MOD_TIME"));
            fleF113_DEFAULT_COMP_HISTORY.set_SetValue("LAST_MOD_USER_ID", fleSAVEF113HIST_RETAIN.GetStringValue("LAST_MOD_USER_ID"));
            fleF113_DEFAULT_COMP_HISTORY.set_SetValue("CORE_COMMENT", fleSAVEF113HIST_RETAIN.GetStringValue("CORE_COMMENT"));
            fleF113_DEFAULT_COMP_HISTORY.set_SetValue("FILLER", fleSAVEF113HIST_RETAIN.GetStringValue("FILLER"));
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

    #region "Standard Generated Procedures(RELOAD_F113_HIST_1)"

    #region "Automatic Item Initialization(RELOAD_F113_HIST_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:01:47 PM

    //#-----------------------------------------
    //# fleF001_ADD_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 3:01:47 PM
    //#-----------------------------------------

    #endregion

    #region "Transaction Management Procedures(RELOAD_F113_HIST_1)"

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
        fleSAVEF113HIST_RETAIN.Transaction = m_trnTRANS_UPDATE;
        fleF113_DEFAULT_COMP_HISTORY.Transaction = m_trnTRANS_UPDATE;
    }

    #endregion

    #region "FILE Management Procedures(RELOAD_F113_HIST_1)"

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
            fleSAVEF113HIST_RETAIN.Dispose();
            fleF113_DEFAULT_COMP_HISTORY.Dispose();
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

    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(RELOAD_F113_HIST_1)"

    public void Run()
    {
        try
        {
            Request("RELOAD_F113_HIST");
            while (fleSAVEF113HIST_RETAIN.QTPForMissing())
            {
                //  --> GET SAVEF113HIST_RETAIN <--
                fleSAVEF113HIST_RETAIN.GetData();
                //  --> End GET SAVEF113HIST_RETAIN <--

                if (Transaction())
                {
                    fleF113_DEFAULT_COMP_HISTORY.OutPut(OutPutType.Add);
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
            EndRequest("RELOAD_F113_HIST");
        }
    }

    #endregion
}
// RELOAD_F113_HIST_1
