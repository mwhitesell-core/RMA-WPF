#region "Screen Comments"

#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;

public class RELOF071 : BaseClassControl 
{
    private RELOF071 m_RELOF071;
    
    public RELOF071(string Name, int Level) : 
            base(Name, Level) 
    {
        this.ScreenType = ScreenTypes.QTP;
    }
    
    public RELOF071(string Name, int Level, bool Request) : 
            base(Name, Level, Request) 
    {
        this.ScreenType = ScreenTypes.QTP;
    }
    
    public override void Dispose() 
    {
        if (!(m_RELOF071 == null)) 
        {
            m_RELOF071.CloseTransactionObjects();
            m_RELOF071 = null;
        }
    }
    
    public RELOF071 GetRELOF071(int Level) 
    {
        if ((m_RELOF071 == null)) 
        {
            m_RELOF071 = new RELOF071("RELOF071", Level);
        }
        else 
        {
            m_RELOF071.ResetValues();
        }
        
        return m_RELOF071;
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
            RELOF071_ONE_1 ONE_1 = new RELOF071_ONE_1(Name, Level);
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

public class RELOF071_ONE_1 : RELOF071
{
    public RELOF071_ONE_1(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;

        fleUNLOF071 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "UNLOF071", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF071_CLIENT_RMA_CLAIM_NBR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F071_CLIENT_RMA_CLAIM_NBR", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF071_CLIENT_RMA_CLAIM_NBR.SetItemFinals += fleF071_CLIENT_RMA_CLAIM_NBR_SetItemFinals;
    }

    #region "Declarations (Variables, Files and Transactions)(RELOF071)"

    private SqlFileObject fleUNLOF071;
    private SqlFileObject fleF071_CLIENT_RMA_CLAIM_NBR;

    private void fleF071_CLIENT_RMA_CLAIM_NBR_SetItemFinals() 
    {
        try 
        {
            fleF071_CLIENT_RMA_CLAIM_NBR.set_SetValue("CLAIM_NBR_CLIENT", fleUNLOF071.GetStringValue("DOC_NBR"));
            fleF071_CLIENT_RMA_CLAIM_NBR.set_SetValue("CLINIC_NBR", fleUNLOF071.GetDecimalValue("DOC_NBR"));
            fleF071_CLIENT_RMA_CLAIM_NBR.set_SetValue("CLAIM_NBR_RMA", fleUNLOF071.GetStringValue("DOC_NBR"));
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

    #region "Standard Generated Procedures(RELOF071)"

    #region "Automatic Item Initialization(RELOF071)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion

    #region "Transaction Management Procedures(RELOF071)"

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
        fleUNLOF071.Transaction = m_trnTRANS_UPDATE;
        fleF071_CLIENT_RMA_CLAIM_NBR.Transaction = m_trnTRANS_UPDATE;
    }

    #endregion

    #region "FILE Management Procedures(RELOF071)"

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
            fleUNLOF071.Dispose();
            fleF071_CLIENT_RMA_CLAIM_NBR.Dispose();
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
 
    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(RELOF071)"
        
    public void Run() 
    {
        try 
        {
            Request("RELOF071");

            while (fleUNLOF071.QTPForMissing()) 
            {
                //  --> GET UNLOF071 <--
                fleUNLOF071.GetData();
                //  --> End GET UNLOF071 <--
                if (Transaction()) 
                {
                    fleF071_CLIENT_RMA_CLAIM_NBR.OutPut(OutPutType.Add);
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
            EndRequest("RELOF071");
        }
    }
    
    #endregion
}
