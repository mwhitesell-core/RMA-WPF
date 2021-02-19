
#region "Screen Comments"

//  2006/jun/15 - MC - reload f050 history file

#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;

public class PURGE_RELOF050_HISTORY : BaseClassControl
{
    private PURGE_RELOF050_HISTORY m_PURGE_RELOF050_HISTORY;

    public PURGE_RELOF050_HISTORY(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
    }

    public PURGE_RELOF050_HISTORY(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
    }

    public override void Dispose()
    {
        if (!(m_PURGE_RELOF050_HISTORY == null))
        {
            m_PURGE_RELOF050_HISTORY.CloseTransactionObjects();
            m_PURGE_RELOF050_HISTORY = null;
        }
    }

    public PURGE_RELOF050_HISTORY GetPURGE_RELOF050_HISTORY(int Level)
    {
        if ((m_PURGE_RELOF050_HISTORY == null))
        {
            m_PURGE_RELOF050_HISTORY = new PURGE_RELOF050_HISTORY("PURGE_RELOF050_HISTORY", Level);
        }
        else
        {
            m_PURGE_RELOF050_HISTORY.ResetValues();
        }

        return m_PURGE_RELOF050_HISTORY;
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
            PURGE_RELOF050_HISTORY_RELOAD_F050_HIST_1 RELOAD_F050_HIST_1 = new PURGE_RELOF050_HISTORY_RELOAD_F050_HIST_1(Name, Level);
            RELOAD_F050_HIST_1.Run();
            RELOAD_F050_HIST_1.Dispose();
            RELOAD_F050_HIST_1 = null;

            PURGE_RELOF050_HISTORY_RELOAD_F050TP_HIST_2 RELOAD_F050TP_HIST_2 = new PURGE_RELOF050_HISTORY_RELOAD_F050TP_HIST_2(Name, Level);
            RELOAD_F050TP_HIST_2.Run();
            RELOAD_F050TP_HIST_2.Dispose();
            RELOAD_F050TP_HIST_2 = null;

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
    #endregion

    #endregion

public class PURGE_RELOF050_HISTORY_RELOAD_F050_HIST_1 : PURGE_RELOF050_HISTORY
{
    public PURGE_RELOF050_HISTORY_RELOAD_F050_HIST_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;

        fleSAVEF050HIST_RETAIN = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "SAVEF050HIST_RETAIN", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF050_DOC_REVENUE_MSTR_HISTORY = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F050_DOC_REVENUE_MSTR_HISTORY", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF050_DOC_REVENUE_MSTR_HISTORY.SetItemFinals += fleF050_DOC__REVENUE_MSTR_HISTORY_SetItemFinals;
    }

    #region "Declarations (Variables, Files and Transactions)(PURGE_RELOF050_HISTORY)"

    private SqlFileObject fleSAVEF050HIST_RETAIN;
    private SqlFileObject fleF050_DOC_REVENUE_MSTR_HISTORY;

    private void fleF050_DOC__REVENUE_MSTR_HISTORY_SetItemFinals()
    {
        try
        {
            fleF050_DOC_REVENUE_MSTR_HISTORY.set_SetValue("DOCREV_CLINIC_1_2", fleSAVEF050HIST_RETAIN.GetStringValue("DOCREV_CLINIC_1_2"));
            fleF050_DOC_REVENUE_MSTR_HISTORY.set_SetValue("DOCREV_DEPT", fleSAVEF050HIST_RETAIN.GetDecimalValue("DOCREV_DEPT"));
            fleF050_DOC_REVENUE_MSTR_HISTORY.set_SetValue("DOCREV_DOC_NBR", fleSAVEF050HIST_RETAIN.GetStringValue("DOCREV_DOC_NBR"));
            fleF050_DOC_REVENUE_MSTR_HISTORY.set_SetValue("DOCREV_LOCATION", fleSAVEF050HIST_RETAIN.GetStringValue("DOCREV_LOCATION"));
            fleF050_DOC_REVENUE_MSTR_HISTORY.set_SetValue("DOCREV_OMA_CODE", fleSAVEF050HIST_RETAIN.GetStringValue("DOCREV_OMA_CODE"));
            fleF050_DOC_REVENUE_MSTR_HISTORY.set_SetValue("DOCREV_OMA_SUFF", fleSAVEF050HIST_RETAIN.GetStringValue("DOCREV_OMA_SUFF"));
            fleF050_DOC_REVENUE_MSTR_HISTORY.set_SetValue("EP_YR", fleSAVEF050HIST_RETAIN.GetDecimalValue("EP_YR"));
            fleF050_DOC_REVENUE_MSTR_HISTORY.set_SetValue("ICONST_DATE_PERIOD_END", fleSAVEF050HIST_RETAIN.GetDecimalValue("ICONST_DATE_PERIOD_END"));
            fleF050_DOC_REVENUE_MSTR_HISTORY.set_SetValue("DOCREV_MTD_IN_REC", fleSAVEF050HIST_RETAIN.GetDecimalValue("DOCREV_MTD_IN_REC"));
            fleF050_DOC_REVENUE_MSTR_HISTORY.set_SetValue("DOCREV_MTD_IN_SVC", fleSAVEF050HIST_RETAIN.GetDecimalValue("DOCREV_MTD_IN_SVC"));
            fleF050_DOC_REVENUE_MSTR_HISTORY.set_SetValue("DOCREV_MTD_OUT_REC", fleSAVEF050HIST_RETAIN.GetDecimalValue("DOCREV_MTD_OUT_REC"));
            fleF050_DOC_REVENUE_MSTR_HISTORY.set_SetValue("DOCREV_MTD_OUT_SVC", fleSAVEF050HIST_RETAIN.GetDecimalValue("DOCREV_MTD_OUT_SVC"));
            fleF050_DOC_REVENUE_MSTR_HISTORY.set_SetValue("DOCREV_YTD_IN_REC", fleSAVEF050HIST_RETAIN.GetDecimalValue("DOCREV_YTD_IN_REC"));
            fleF050_DOC_REVENUE_MSTR_HISTORY.set_SetValue("DOCREV_YTD_IN_SVC", fleSAVEF050HIST_RETAIN.GetDecimalValue("DOCREV_YTD_IN_SVC"));
            fleF050_DOC_REVENUE_MSTR_HISTORY.set_SetValue("DOCREV_YTD_OUT_REC", fleSAVEF050HIST_RETAIN.GetDecimalValue("DOCREV_YTD_OUT_REC"));
            fleF050_DOC_REVENUE_MSTR_HISTORY.set_SetValue("DOCREV_YTD_OUT_SVC", fleSAVEF050HIST_RETAIN.GetDecimalValue("DOCREV_YTD_OUT_SVC"));

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

        #region "Standard Generated Procedures(RELOAD_F050_HIST_1)"

        #region "Automatic Item Initialization(RELOAD_F050_HIST_1)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 6/27/2017 3:01:47 PM

        //#-----------------------------------------
        //# fleF001_ADD_AutomaticItemInitialization Procedure
        //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 3:01:47 PM
        //#-----------------------------------------

        #endregion

        #region "Transaction Management Procedures(RELOAD_F050_HIST_1)"

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
        fleSAVEF050HIST_RETAIN.Transaction = m_trnTRANS_UPDATE;
        fleF050_DOC_REVENUE_MSTR_HISTORY.Transaction = m_trnTRANS_UPDATE;
    }

    #endregion

    #region "FILE Management Procedures(RELOAD_F050_HIST_1)"

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
            fleSAVEF050HIST_RETAIN.Dispose();
            fleF050_DOC_REVENUE_MSTR_HISTORY.Dispose();
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

    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(RELOAD_F050_HIST_1)"

    public void Run()
    {
        try
        {
            Request("RELOAD_F050_HIST");
            while (fleSAVEF050HIST_RETAIN.QTPForMissing())
            {
                //  --> GET SAVEF050HIST_RETAIN <--
                fleSAVEF050HIST_RETAIN.GetData();
                //  --> End GET SAVEF050HIST_RETAIN <--

                if (Transaction())
                {
                    fleF050_DOC_REVENUE_MSTR_HISTORY.OutPut(OutPutType.Add);
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
            EndRequest("RELOAD_F050_HIST");
        }
    }

    #endregion
}
// RELOAD_F050_HIST_1

public class PURGE_RELOF050_HISTORY_RELOAD_F050TP_HIST_2 : PURGE_RELOF050_HISTORY
{
    public PURGE_RELOF050_HISTORY_RELOAD_F050TP_HIST_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;

        fleSAVEF050TPHIST_RETAIN = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "SAVEF050TPHIST_RETAIN", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF050TP_DOC_REVENUE_MSTR_HISTORY = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F050TP_DOC_REVENUE_MSTR_HISTORY", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF050TP_DOC_REVENUE_MSTR_HISTORY.SetItemFinals += fleF050TP_DOC_REVENUE_MSTR_HISTORY_SetItemFinals;
    }

    #region "Declarations (Variables, Files and Transactions)(PURGE_RELOF050_HISTORY)"

    private SqlFileObject fleSAVEF050TPHIST_RETAIN;
    private SqlFileObject fleF050TP_DOC_REVENUE_MSTR_HISTORY;

    private void fleF050TP_DOC_REVENUE_MSTR_HISTORY_SetItemFinals()
    {
        try
        {
            fleF050TP_DOC_REVENUE_MSTR_HISTORY.set_SetValue("DOCREVTP_CLINIC_NBR", fleSAVEF050TPHIST_RETAIN.GetDecimalValue("DOCREVTP_CLINIC_NBR"));
            fleF050TP_DOC_REVENUE_MSTR_HISTORY.set_SetValue("DOCREV_AGENT_CD", fleSAVEF050TPHIST_RETAIN.GetStringValue("DOCREV_AGENT_CD"));
            fleF050TP_DOC_REVENUE_MSTR_HISTORY.set_SetValue("DOCREV_LOC_CD", fleSAVEF050TPHIST_RETAIN.GetStringValue("DOCREV_LOC_CD"));
            fleF050TP_DOC_REVENUE_MSTR_HISTORY.set_SetValue("DOCREV_OMA_CODE", fleSAVEF050TPHIST_RETAIN.GetStringValue("DOCREV_OMA_CODE"));
            fleF050TP_DOC_REVENUE_MSTR_HISTORY.set_SetValue("DOCREV_OMA_SUFF", fleSAVEF050TPHIST_RETAIN.GetStringValue("DOCREV_OMA_SUFF"));
            fleF050TP_DOC_REVENUE_MSTR_HISTORY.set_SetValue("DOCREV_DOC_NBR", fleSAVEF050TPHIST_RETAIN.GetStringValue("DOCREV_DOC_NBR"));
            fleF050TP_DOC_REVENUE_MSTR_HISTORY.set_SetValue("EP_YR", fleSAVEF050TPHIST_RETAIN.GetDecimalValue("EP_YR"));
            fleF050TP_DOC_REVENUE_MSTR_HISTORY.set_SetValue("ICONST_DATE_PERIOD_END", fleSAVEF050TPHIST_RETAIN.GetDecimalValue("ICONST_DATE_PERIOD_END"));
            fleF050TP_DOC_REVENUE_MSTR_HISTORY.set_SetValue("DOCREVTP_IN_TECH_AMT_BILLED1", fleSAVEF050TPHIST_RETAIN.GetDecimalValue("DOCREVTP_IN_TECH_AMT_BILLED1"));
            fleF050TP_DOC_REVENUE_MSTR_HISTORY.set_SetValue("DOCREVTP_IN_TECH_AMT_BILLED2", fleSAVEF050TPHIST_RETAIN.GetDecimalValue("DOCREVTP_IN_TECH_AMT_BILLED2"));
            fleF050TP_DOC_REVENUE_MSTR_HISTORY.set_SetValue("DOCREVTP_IN_TECH_AMT_ADJUSTS1", fleSAVEF050TPHIST_RETAIN.GetDecimalValue("DOCREVTP_IN_TECH_AMT_ADJUSTS1"));
            fleF050TP_DOC_REVENUE_MSTR_HISTORY.set_SetValue("DOCREVTP_IN_TECH_AMT_ADJUSTS2", fleSAVEF050TPHIST_RETAIN.GetDecimalValue("DOCREVTP_IN_TECH_AMT_ADJUSTS2"));
            fleF050TP_DOC_REVENUE_MSTR_HISTORY.set_SetValue("DOCREVTP_IN_TECH_NBR_SVC1", fleSAVEF050TPHIST_RETAIN.GetDecimalValue("DOCREVTP_IN_TECH_NBR_SVC1"));
            fleF050TP_DOC_REVENUE_MSTR_HISTORY.set_SetValue("DOCREVTP_IN_TECH_NBR_SVC2", fleSAVEF050TPHIST_RETAIN.GetDecimalValue("DOCREVTP_IN_TECH_NBR_SVC2"));
            fleF050TP_DOC_REVENUE_MSTR_HISTORY.set_SetValue("DOCREVTP_IN_PROF_AMT_BILLED1", fleSAVEF050TPHIST_RETAIN.GetDecimalValue("DOCREVTP_IN_PROF_AMT_BILLED1"));
            fleF050TP_DOC_REVENUE_MSTR_HISTORY.set_SetValue("DOCREVTP_IN_PROF_AMT_BILLED2", fleSAVEF050TPHIST_RETAIN.GetDecimalValue("DOCREVTP_IN_PROF_AMT_BILLED2"));
            fleF050TP_DOC_REVENUE_MSTR_HISTORY.set_SetValue("DOCREVTP_IN_PROF_AMT_ADJUSTS1", fleSAVEF050TPHIST_RETAIN.GetDecimalValue("DOCREVTP_IN_PROF_AMT_ADJUSTS1"));
            fleF050TP_DOC_REVENUE_MSTR_HISTORY.set_SetValue("DOCREVTP_IN_PROF_AMT_ADJUSTS2", fleSAVEF050TPHIST_RETAIN.GetDecimalValue("DOCREVTP_IN_PROF_AMT_ADJUSTS2"));
            fleF050TP_DOC_REVENUE_MSTR_HISTORY.set_SetValue("DOCREVTP_IN_PROF_NBR_SVC1", fleSAVEF050TPHIST_RETAIN.GetDecimalValue("DOCREVTP_IN_PROF_NBR_SVC1"));
            fleF050TP_DOC_REVENUE_MSTR_HISTORY.set_SetValue("DOCREVTP_IN_PROF_NBR_SVC2", fleSAVEF050TPHIST_RETAIN.GetDecimalValue("DOCREVTP_IN_PROF_NBR_SVC2"));
            fleF050TP_DOC_REVENUE_MSTR_HISTORY.set_SetValue("DOCREVTP_OUT_TECH_AMT_BILLED1", fleSAVEF050TPHIST_RETAIN.GetDecimalValue("DOCREVTP_OUT_TECH_AMT_BILLED1"));
            fleF050TP_DOC_REVENUE_MSTR_HISTORY.set_SetValue("DOCREVTP_OUT_TECH_AMT_BILLED2", fleSAVEF050TPHIST_RETAIN.GetDecimalValue("DOCREVTP_OUT_TECH_AMT_BILLED2"));
            fleF050TP_DOC_REVENUE_MSTR_HISTORY.set_SetValue("DOCREVTP_OUT_TECH_AMT_ADJUSTS1", fleSAVEF050TPHIST_RETAIN.GetDecimalValue("DOCREVTP_OUT_TECH_AMT_ADJUSTS1"));
            fleF050TP_DOC_REVENUE_MSTR_HISTORY.set_SetValue("DOCREVTP_OUT_TECH_AMT_ADJUSTS2", fleSAVEF050TPHIST_RETAIN.GetDecimalValue("DOCREVTP_OUT_TECH_AMT_ADJUSTS2"));
            fleF050TP_DOC_REVENUE_MSTR_HISTORY.set_SetValue("DOCREVTP_OUT_TECH_NBR_SVC1", fleSAVEF050TPHIST_RETAIN.GetDecimalValue("DOCREVTP_OUT_TECH_NBR_SVC1"));
            fleF050TP_DOC_REVENUE_MSTR_HISTORY.set_SetValue("DOCREVTP_OUT_TECH_NBR_SVC2", fleSAVEF050TPHIST_RETAIN.GetDecimalValue("DOCREVTP_OUT_TECH_NBR_SVC2"));
            fleF050TP_DOC_REVENUE_MSTR_HISTORY.set_SetValue("DOCREVTP_OUT_PROF_AMT_BILLED1", fleSAVEF050TPHIST_RETAIN.GetDecimalValue("DOCREVTP_OUT_PROF_AMT_BILLED1"));
            fleF050TP_DOC_REVENUE_MSTR_HISTORY.set_SetValue("DOCREVTP_OUT_PROF_AMT_BILLED2", fleSAVEF050TPHIST_RETAIN.GetDecimalValue("DOCREVTP_OUT_PROF_AMT_BILLED2"));
            fleF050TP_DOC_REVENUE_MSTR_HISTORY.set_SetValue("DOCREVTP_OUT_PROF_AMT_ADJUSTS1", fleSAVEF050TPHIST_RETAIN.GetDecimalValue("DOCREVTP_OUT_PROF_AMT_ADJUSTS1"));
            fleF050TP_DOC_REVENUE_MSTR_HISTORY.set_SetValue("DOCREVTP_OUT_PROF_AMT_ADJUSTS2", fleSAVEF050TPHIST_RETAIN.GetDecimalValue("DOCREVTP_OUT_PROF_AMT_ADJUSTS2"));
            fleF050TP_DOC_REVENUE_MSTR_HISTORY.set_SetValue("DOCREVTP_OUT_PROF_NBR_SVC1", fleSAVEF050TPHIST_RETAIN.GetDecimalValue("DOCREVTP_OUT_PROF_NBR_SVC1"));
            fleF050TP_DOC_REVENUE_MSTR_HISTORY.set_SetValue("DOCREVTP_OUT_PROF_NBR_SVC2", fleSAVEF050TPHIST_RETAIN.GetDecimalValue("DOCREVTP_OUT_PROF_NBR_SVC2"));

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

    #region "Standard Generated Procedures(RELOAD_F050_HIST_2)"

    #region "Automatic Item Initialization(RELOAD_F050_HIST_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:01:47 PM

    //#-----------------------------------------
    //# fleF001_ADD_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 3:01:47 PM
    //#-----------------------------------------

    #endregion

    #region "Transaction Management Procedures(RELOAD_F050_HIST_2)"

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
        fleSAVEF050TPHIST_RETAIN.Transaction = m_trnTRANS_UPDATE;
        fleF050TP_DOC_REVENUE_MSTR_HISTORY.Transaction = m_trnTRANS_UPDATE;
    }

    #endregion

    #region "FILE Management Procedures(RELOAD_F050_HIST_2)"

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
            fleSAVEF050TPHIST_RETAIN.Dispose();
            fleF050TP_DOC_REVENUE_MSTR_HISTORY.Dispose();
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

    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(RELOAD_F050_HIST_2)"

    public void Run()
    {
        try
        {
            Request("RELOAD_F050TP_HIST");
            while (fleSAVEF050TPHIST_RETAIN.QTPForMissing())
            {
                //  --> GET SAVEF050HIST_RETAIN <--
                fleSAVEF050TPHIST_RETAIN.GetData();
                //  --> End GET SAVEF050HIST_RETAIN <--

                if (Transaction())
                {
                    fleF050TP_DOC_REVENUE_MSTR_HISTORY.OutPut(OutPutType.Add);
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
            EndRequest("RELOAD_F050TP_HIST");
        }
    }

    #endregion
}
