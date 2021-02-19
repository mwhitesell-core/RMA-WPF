#region "Screen Comments"

//  2013/sep/25 MC - create f073 file based on savef020adjtype subfile which is based on f002 file
//  - whatever the highest count of the adj-cd-sub-type (C,S,D,W) for the doctor,
//  create the records only for Disk  or Web

#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;

public class RELOF085 : BaseClassControl
{
    private RELOF085 m_RELOF085;
    
    public RELOF085(string Name, int Level) : 
            base(Name, Level) 
    {
        this.ScreenType = ScreenTypes.QTP;
    }
    
    public RELOF085(string Name, int Level, bool Request) : 
            base(Name, Level, Request) 
    {
        this.ScreenType = ScreenTypes.QTP;
    }
    
    public override void Dispose() 
    {
        if (!(m_RELOF085 == null)) 
        {
            m_RELOF085.CloseTransactionObjects();
            m_RELOF085 = null;
        }
    }
    
    public RELOF085 GetRELOF085(int Level) 
    {
        if ((m_RELOF085 == null)) 
        {
            m_RELOF085 = new RELOF085("RELOF085", Level);
        }
        else 
        {
            m_RELOF085.ResetValues();
        }
        
        return m_RELOF085;
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
            RELOF085_ONE_1 ONE_1 = new RELOF085_ONE_1(Name, Level);
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

public class RELOF085_ONE_1 : CREATEF073_COSTING
{
    public RELOF085_ONE_1(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;

        fleUNLOF085 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "UNLOF085", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleREJECTED_CLAIMS = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F085_REJECTED_CLAIMS", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleREJECTED_CLAIMS.SetItemFinals += fleREJECTED_CLAIMS_SetItemFinals;
    }

    #region "Declarations (Variables, Files and Transactions)(RELOF085)"

    private SqlFileObject fleUNLOF085;
    private SqlFileObject fleREJECTED_CLAIMS;

    private void fleREJECTED_CLAIMS_SetItemFinals() 
    {
        try 
        {
            fleREJECTED_CLAIMS.set_SetValue("CLAIM_NBR", fleUNLOF085.GetStringValue("CLAIM_NBR"));
            fleREJECTED_CLAIMS.set_SetValue("DOC_NBR", fleUNLOF085.GetStringValue("DOC_NBR"));
            fleREJECTED_CLAIMS.set_SetValue("CLMHDR_PAT_OHIP_ID_OR_CHART", fleUNLOF085.GetStringValue("CLMHDR_PAT_OHIP_ID_OR_CHART"));
            fleREJECTED_CLAIMS.set_SetValue("CLMHDR_LOC", fleUNLOF085.GetStringValue("CLMHDR_LOC"));
            fleREJECTED_CLAIMS.set_SetValue("MESS_CODE", fleUNLOF085.GetStringValue("MESS_CODE"));
            fleREJECTED_CLAIMS.set_SetValue("LOGICALLY_DELETED_FLAG", fleUNLOF085.GetStringValue("LOGICALLY_DELETED_FLAG"));
            fleREJECTED_CLAIMS.set_SetValue("CLMHDR_SUBMIT_DATE", fleUNLOF085.GetDecimalValue("CLMHDR_SUBMIT_DATE"));
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

    #region "Standard Generated Procedures(RELOF085)"

    #region "Automatic Item Initialization(RELOF085)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion

    #region "Transaction Management Procedures(RELOF085)"

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
        fleUNLOF085.Transaction = m_trnTRANS_UPDATE;
        fleREJECTED_CLAIMS.Transaction = m_trnTRANS_UPDATE;
    }

    #endregion

    #region "FILE Management Procedures(RELOF085)"

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
            fleUNLOF085.Dispose();
            fleREJECTED_CLAIMS.Dispose();
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
 
    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(RELOF085)"
   
    public void Run() 
    {
        try 
        {
            Request("RELOF085");

            while (fleUNLOF085.QTPForMissing()) 
            {
                //  --> GET UNLOF085 <--
                fleUNLOF085.GetData();
                //  --> End GET UNLOF085 <--

                if (Transaction()) 
                {
                    fleREJECTED_CLAIMS.OutPut(OutPutType.Add);
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
            EndRequest("RELOF085");
        }
    }
    
    #endregion
}