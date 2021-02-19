#region "Screen Comments"

#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;

public class RELOF099 : BaseClassControl
{
    private RELOF099 m_RELOF099;
    
    public RELOF099(string Name, int Level) : 
            base(Name, Level) 
    {
        this.ScreenType = ScreenTypes.QTP;
    }
    
    public RELOF099(string Name, int Level, bool Request) : 
            base(Name, Level, Request) 
    {
        this.ScreenType = ScreenTypes.QTP;
    }
    
    public override void Dispose() 
    {
        if (!(m_RELOF099 == null)) 
        {
            m_RELOF099.CloseTransactionObjects();
            m_RELOF099 = null;
        }
    }
    
    public RELOF099 GetRELOF099(int Level) 
    {
        if ((m_RELOF099 == null)) 
        {
            m_RELOF099 = new RELOF099("RELOF099", Level);
        }
        else 
        {
            m_RELOF099.ResetValues();
        }
        
        return m_RELOF099;
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
            RELOF099_ONE_1 ONE_1 = new RELOF099_ONE_1(Name, Level);
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

public class RELOF099_ONE_1 : RELOF099
{
    public RELOF099_ONE_1(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;

        fleUNLOF099 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "UNLOF099", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF099_GROUP_CLAIM_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F099_GROUP_CLAIM_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF099_GROUP_CLAIM_MSTR.SetItemFinals += fleF099_GROUP_CLAIM_MSTR_SetItemFinals;
    }

    #region "Declarations (Variables, Files and Transactions)(RELOF099)"
    
    private SqlFileObject fleUNLOF099;
    private SqlFileObject fleF099_GROUP_CLAIM_MSTR;

    private void fleF099_GROUP_CLAIM_MSTR_SetItemFinals()
    {
        try
        {
            fleF099_GROUP_CLAIM_MSTR.set_SetValue("GROUP_NBR", fleUNLOF099.GetStringValue("GROUP_NBR"));
            fleF099_GROUP_CLAIM_MSTR.set_SetValue("CLMHDR_BATCH_NBR", fleUNLOF099.GetStringValue("CLMHDR_BATCH_NBR"));
            fleF099_GROUP_CLAIM_MSTR.set_SetValue("CLMHDR_CLAIM_NBR", fleUNLOF099.GetDecimalValue("CLMHDR_CLAIM_NBR"));
            fleF099_GROUP_CLAIM_MSTR.set_SetValue("ACCOUNTING_NBR", fleUNLOF099.GetStringValue("ACCOUNTING_NBR"));
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
  
    #region "Standard Generated Procedures(RELOF099)"

    #region "Automatic Item Initialization(RELOF099)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion

    #region "Transaction Management Procedures(RELOF099)"

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
        fleUNLOF099.Transaction = m_trnTRANS_UPDATE;
        fleF099_GROUP_CLAIM_MSTR.Transaction = m_trnTRANS_UPDATE;
    }

    #endregion

    #region "FILE Management Procedures(RELOF099)"

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
            fleUNLOF099.Dispose();
            fleF099_GROUP_CLAIM_MSTR.Dispose();
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

    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(RELOF099)"

    public void Run() 
    {
        try 
        {
            Request("RELOF099");
            while (fleUNLOF099.QTPForMissing()) 
            {
                //  --> GET UNLOF099 <--
                fleUNLOF099.GetData();
                //  --> End GET UNLOF099 <--

                if (Transaction()) 
                {
                    fleF099_GROUP_CLAIM_MSTR.OutPut(OutPutType.Add);
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
            EndRequest("RELOF099");
        }
    }

    #endregion
}    


