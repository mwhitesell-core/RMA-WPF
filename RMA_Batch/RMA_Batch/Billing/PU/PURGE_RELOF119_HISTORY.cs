
#region "Screen Comments"

//  2006/jun/15 - MC - reload f119  history file

#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;

public class PURGE_RELOF119_HISTORY : BaseClassControl
{
    private PURGE_RELOF119_HISTORY m_PURGE_RELOF119_HISTORY;

    public PURGE_RELOF119_HISTORY(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
    }

    public PURGE_RELOF119_HISTORY(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
    }

    public override void Dispose()
    {
        if (!(m_PURGE_RELOF119_HISTORY == null))
        {
            m_PURGE_RELOF119_HISTORY.CloseTransactionObjects();
            m_PURGE_RELOF119_HISTORY = null;
        }
    }

    public PURGE_RELOF119_HISTORY GetPURGE_RELOF119_HISTORY(int Level)
    {
        if ((m_PURGE_RELOF119_HISTORY == null))
        {
            m_PURGE_RELOF119_HISTORY = new PURGE_RELOF119_HISTORY("PURGE_RELOF119_HISTORY", Level);
        }
        else
        {
            m_PURGE_RELOF119_HISTORY.ResetValues();
        }

        return m_PURGE_RELOF119_HISTORY;
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
            PURGE_RELOF119_HISTORY_RELOAD_F119_HIST_1 RELOAD_F119_HIST_1 = new PURGE_RELOF119_HISTORY_RELOAD_F119_HIST_1(Name, Level);
            RELOAD_F119_HIST_1.Run();
            RELOAD_F119_HIST_1.Dispose();
            RELOAD_F119_HIST_1 = null;

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
public class PURGE_RELOF119_HISTORY_RELOAD_F119_HIST_1 : PURGE_RELOF119_HISTORY
{
    public PURGE_RELOF119_HISTORY_RELOAD_F119_HIST_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;

        fleSAVEF119HIST_RETAIN = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "SAVEF119HIST_RETAIN", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF119_DOCTOR_YTD_HISTORY = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F119_DOCTOR_YTD_HISTORY", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF119_DOCTOR_YTD_HISTORY.SetItemFinals += fleF119_DOCTOR_YTD_HISTORY_SetItemFinals;
    }

    #region "Declarations (Variables, Files and Transactions)(RELOAD_F119_HIST_1)"

    private SqlFileObject fleSAVEF119HIST_RETAIN;
    private SqlFileObject fleF119_DOCTOR_YTD_HISTORY;

    private void fleF119_DOCTOR_YTD_HISTORY_SetItemFinals()
    {
        try
        {
            fleF119_DOCTOR_YTD_HISTORY.set_SetValue("DOC_NBR", fleSAVEF119HIST_RETAIN.GetStringValue("DOC_NBR"));
            fleF119_DOCTOR_YTD_HISTORY.set_SetValue("EP_NBR", fleSAVEF119HIST_RETAIN.GetDecimalValue("EP_NBR"));
            fleF119_DOCTOR_YTD_HISTORY.set_SetValue("COMP_CODE", fleSAVEF119HIST_RETAIN.GetStringValue("COMP_CODE"));
            fleF119_DOCTOR_YTD_HISTORY.set_SetValue("PROCESS_SEQ", fleSAVEF119HIST_RETAIN.GetDecimalValue("PROCESS_SEQ"));
            fleF119_DOCTOR_YTD_HISTORY.set_SetValue("COMP_CODE_GROUP", fleSAVEF119HIST_RETAIN.GetStringValue("COMP_CODE_GROUP"));
            fleF119_DOCTOR_YTD_HISTORY.set_SetValue("REC_TYPE", fleSAVEF119HIST_RETAIN.GetStringValue("REC_TYPE"));
            fleF119_DOCTOR_YTD_HISTORY.set_SetValue("AMT_MTD", fleSAVEF119HIST_RETAIN.GetDecimalValue("AMT_MTD"));
            fleF119_DOCTOR_YTD_HISTORY.set_SetValue("AMT_YTD", fleSAVEF119HIST_RETAIN.GetDecimalValue("AMT_YTD"));
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

    #region "Standard Generated Procedures(RELOAD_F119_HIST_1)"

    #region "Automatic Item Initialization(RELOAD_F119_HIST_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:01:47 PM

    #endregion

    #region "Transaction Management Procedures(RELOAD_F119_HIST_1)"

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
        fleSAVEF119HIST_RETAIN.Transaction = m_trnTRANS_UPDATE;
        fleF119_DOCTOR_YTD_HISTORY.Transaction = m_trnTRANS_UPDATE;
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
            fleSAVEF119HIST_RETAIN.Dispose();
            fleF119_DOCTOR_YTD_HISTORY.Dispose();
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
            Request("RELOAD_F119_HIST");
            while (fleSAVEF119HIST_RETAIN.QTPForMissing())
            {
                //  --> GET SAVEF119HIST_RETAIN <--
                fleSAVEF119HIST_RETAIN.GetData();
                //  --> End GET SAVEF119HIST_RETAIN <--

                if (Transaction())
                {
                    fleF119_DOCTOR_YTD_HISTORY.OutPut(OutPutType.Add);
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
            EndRequest("RELOAD_F119_HIST");
        }
    }

    #endregion
}
// RELOAD_F119_HIST_1
