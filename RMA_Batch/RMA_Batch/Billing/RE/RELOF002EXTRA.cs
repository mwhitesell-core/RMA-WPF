#region "Screen Comments"

#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;

public class RELOF002EXTRA : BaseClassControl
{
    private RELOF002EXTRA m_RELOF002EXTRA;

    public RELOF002EXTRA(string Name, int Level) :
        base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
    }

    public RELOF002EXTRA(string Name, int Level, bool Request) :
        base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
    }

    public override void Dispose()
    {
        if (!(m_RELOF002EXTRA == null))
        {
            m_RELOF002EXTRA.CloseTransactionObjects();
            m_RELOF002EXTRA = null;
        }
    }

    public RELOF002EXTRA GetRELOF002EXTRA(int Level)
    {
        if ((m_RELOF002EXTRA == null))
        {
            m_RELOF002EXTRA = new RELOF002EXTRA("RELOF002EXTRA", Level);
        }
        else
        {
            m_RELOF002EXTRA.ResetValues();
        }

        return m_RELOF002EXTRA;
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
            RELOF002EXTRA_ONE_1 ONE_1 = new RELOF002EXTRA_ONE_1(Name, Level);
            ONE_1.Run();
            ONE_1.Dispose();
            ONE_1 = null;

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

public class RELOF002EXTRA_ONE_1 : RELOF002EXTRA
{
    public RELOF002EXTRA_ONE_1(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;

        fleUNLOF002EXTRA = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "UNLOF002EXTRA", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF002_CLAIMS_EXTRA = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_EXTRA", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF002_CLAIMS_EXTRA.SetItemFinals += fleF002_CLAIMS_EXTRA_SetItemFinals;
    }

    #region "Declarations (Variables, Files and Transactions)(RELOF002EXTRA)"
    
    private SqlFileObject fleUNLOF002EXTRA;
    private SqlFileObject fleF002_CLAIMS_EXTRA;

    private void fleF002_CLAIMS_EXTRA_SetItemFinals()
    {
        try
        {
            fleF002_CLAIMS_EXTRA.set_SetValue("CLMHDR_RMA_CLM_NBR", fleUNLOF002EXTRA.GetStringValue("CLMHDR_RMA_CLM_NBR"));
            fleF002_CLAIMS_EXTRA.set_SetValue("CLMHDR_OHIP_CLM_NBR", fleUNLOF002EXTRA.GetStringValue("CLMHDR_OHIP_CLM_NBR"));
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

    #region "Standard Generated Procedures(RELOF002EXTRA)"

    #region "Automatic Item Initialization(RELOF002EXTRA)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion

    #region "Transaction Management Procedures(RELOF002EXTRA)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:01:00 PM

    //#-----------------------------------------
    //# InitializeTransactionObjects Procedure.
    //#-----------------------------------------

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

    //#-----------------------------------------
    //# CloseTransactionObjects Procedure.
    //#-----------------------------------------
    protected override void CloseTransactionObjects()
    {
        try
        {
            CloseFiles();

            if ((m_trnTRANS_UPDATE != null))
                m_trnTRANS_UPDATE.Dispose();

            if ((m_cnnTRANS_UPDATE != null))
                m_cnnTRANS_UPDATE.Close();

            if ((m_cnnTRANS_UPDATE != null))
                m_cnnTRANS_UPDATE.Dispose();

            if ((m_cnnQUERY != null))
                m_cnnQUERY.Close();

            if ((m_cnnQUERY != null))
                m_cnnQUERY.Dispose();
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
        if (Method == TransactionMethods.Rollback)
        {
            m_trnTRANS_UPDATE.Rollback();
        }
        else
        {
            m_trnTRANS_UPDATE.Commit();
        }

        m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
        Initialize_TRANS_UPDATE();
    }

    private void Initialize_TRANS_UPDATE()
    {
        fleUNLOF002EXTRA.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_EXTRA.Transaction = m_trnTRANS_UPDATE;
    }

    #endregion

    #region "FILE Management Procedures(RELOF002EXTRA)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:01:00 PM

    //#-----------------------------------------
    //# InitializeFiles Procedure.
    //#-----------------------------------------
    protected override void InitializeFiles()
    {
        try
        {
            Initialize_TRANS_UPDATE();
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

    //#-----------------------------------------
    //# CloseFiles Procedure.
    //#-----------------------------------------
    protected override void CloseFiles()
    {
        try
        {
            fleUNLOF002EXTRA.Dispose();
            fleF002_CLAIMS_EXTRA.Dispose();
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

    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(RELOF002EXTRA)"

    public void Run()
    {
        try
        {
            Request("ONE_1");

            while (fleUNLOF002EXTRA.QTPForMissing())
            {
                //  --> GET UNLOF002EXTRA <--
                fleUNLOF002EXTRA.GetData();
                //  --> End GET UNLOF002EXTRA <--

                if (Transaction())
                {
                    fleF002_CLAIMS_EXTRA.OutPut(OutPutType.Add);
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
            EndRequest("RELOF002EXTRA");
        }
    }

    #endregion
}
//ONE_1

