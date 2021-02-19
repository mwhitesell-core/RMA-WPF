#region "Screen Comments"

//  2006/jun/15 - MC - upload f011 files

#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;

public class PURGE_RELOF011 : BaseClassControl 
{
    private PURGE_RELOF011 m_PURGE_RELOF011;
    
    public PURGE_RELOF011(string Name, int Level) : 
            base(Name, Level) 
    {
        this.ScreenType = ScreenTypes.QTP;
    }
    
    public PURGE_RELOF011(string Name, int Level, bool Request) : 
            base(Name, Level, Request) 
    {
        this.ScreenType = ScreenTypes.QTP;
    }
    
    public override void Dispose() 
    {
        if (!(m_PURGE_RELOF011 == null)) 
        {
            m_PURGE_RELOF011.CloseTransactionObjects();
            m_PURGE_RELOF011 = null;
        }
    }
    
    public PURGE_RELOF011 GetPURGE_RELOF011(int Level) 
    {
        if ((m_PURGE_RELOF011 == null)) 
        {
            m_PURGE_RELOF011 = new PURGE_RELOF011("PURGE_RELOF011", Level);
        }
        else 
        {
            m_PURGE_RELOF011.ResetValues();
        }
        
        return m_PURGE_RELOF011;
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
            PURGE_RELOF011_RELOAD_F011_1 RELOAD_F011_1 = new PURGE_RELOF011_RELOAD_F011_1(Name, Level);
            RELOAD_F011_1.Run();
            RELOAD_F011_1.Dispose();
            RELOAD_F011_1 = null;
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

public class PURGE_RELOF011_RELOAD_F011_1 : PURGE_RELOF011 
{
    
    public PURGE_RELOF011_RELOAD_F011_1(string Name, int Level) : 
            base(Name, Level, true) 
    {
        this.ScreenType = ScreenTypes.QTP;
    
        fleSAVEF011_RETAIN = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "SAVEF011_RETAIN", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF011_PAT_MSTR_ELIG_HISTORY = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F011_PAT_MSTR_ELIG_HISTORY", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF011_PAT_MSTR_ELIG_HISTORY.SetItemFinals += fleF011_PAT_MSTR_ELIG_HISTORY_SetItemFinals;
    }

    #region "Declarations (Variables, Files and Transactions)(CREATEF073_COSTING)"

    private SqlFileObject fleSAVEF011_RETAIN;
    private SqlFileObject fleF011_PAT_MSTR_ELIG_HISTORY;

    private void fleF011_PAT_MSTR_ELIG_HISTORY_SetItemFinals()
    {
        try
        {
            fleF011_PAT_MSTR_ELIG_HISTORY.set_SetValue("PAT_I_KEY", fleSAVEF011_RETAIN.GetStringValue("PAT_I_KEY"));
            fleF011_PAT_MSTR_ELIG_HISTORY.set_SetValue("PAT_CON_NBR", fleSAVEF011_RETAIN.GetDecimalValue("PAT_CON_NBR"));
            fleF011_PAT_MSTR_ELIG_HISTORY.set_SetValue("PAT_I_NBR", fleSAVEF011_RETAIN.GetDecimalValue("FILLER4"));
            fleF011_PAT_MSTR_ELIG_HISTORY.set_SetValue("FILLER4", fleSAVEF011_RETAIN.GetStringValue("DOC_NBR"));
            fleF011_PAT_MSTR_ELIG_HISTORY.set_SetValue("PAT_DATE_LAST_MAINT", fleSAVEF011_RETAIN.GetDecimalValue("PAT_DATE_LAST_MAINT"));
            fleF011_PAT_MSTR_ELIG_HISTORY.set_SetValue("ENTRY_TIME_LONG", fleSAVEF011_RETAIN.GetDecimalValue("ENTRY_TIME_LONG"));
            fleF011_PAT_MSTR_ELIG_HISTORY.set_SetValue("PAT_EXPIRY_YY", fleSAVEF011_RETAIN.GetDecimalValue("PAT_EXPIRY_YY"));
            fleF011_PAT_MSTR_ELIG_HISTORY.set_SetValue("PAT_EXPIRY_MM", fleSAVEF011_RETAIN.GetDecimalValue("PAT_EXPIRY_MM"));
            fleF011_PAT_MSTR_ELIG_HISTORY.set_SetValue("PAT_HEALTH_NBR", fleSAVEF011_RETAIN.GetDecimalValue("PAT_HEALTH_NBR"));
            fleF011_PAT_MSTR_ELIG_HISTORY.set_SetValue("PAT_LAST_HEALTH_NBR", fleSAVEF011_RETAIN.GetDecimalValue("PAT_LAST_HEALTH_NBR"));
            fleF011_PAT_MSTR_ELIG_HISTORY.set_SetValue("PAT_VERSION_CD", fleSAVEF011_RETAIN.GetStringValue("PAT_VERSION_CD"));
            fleF011_PAT_MSTR_ELIG_HISTORY.set_SetValue("PAT_LAST_VERSION_CD", fleSAVEF011_RETAIN.GetStringValue("PAT_LAST_VERSION_CD"));
            fleF011_PAT_MSTR_ELIG_HISTORY.set_SetValue("PAT_BIRTH_DATE", fleSAVEF011_RETAIN.GetDecimalValue("PAT_BIRTH_DATE"));
            fleF011_PAT_MSTR_ELIG_HISTORY.set_SetValue("PAT_BIRTH_DAT_LAST", fleSAVEF011_RETAIN.GetDecimalValue("PAT_BIRTH_DAT_LAST"));
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

    #region "Standard Generated Procedures(PURGE_RELOF011)"

    #region "Automatic Item Initialization(PURGE_RELOF011)"

    #region "Transaction Management Procedures(PURGE_RELOF011)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion

    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 2019-08-13 8:05:00 AM

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
        fleSAVEF011_RETAIN.Transaction = m_trnTRANS_UPDATE;
        fleF011_PAT_MSTR_ELIG_HISTORY.Transaction = m_trnTRANS_UPDATE;
    }
    
    #endregion

    #region "FILE Management Procedures(PURGE_RELOF011)"

    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 2019-08-13 8:05:00 AM

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
            fleSAVEF011_RETAIN.Dispose();
            fleF011_PAT_MSTR_ELIG_HISTORY.Dispose();
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
 
    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(PURGE_RELOF011)"
        
    public void Run() 
    {
        try 
        {
            Request("RELOAD_F011_1");

            while (fleSAVEF011_RETAIN.QTPForMissing()) 
            {
                //  --> GET SAVEF011_RETAIN <--
                fleSAVEF011_RETAIN.GetData();
                //  --> End GET SAVEF011_RETAIN <--

                if (Transaction()) 
                {
                    fleF011_PAT_MSTR_ELIG_HISTORY.OutPut(OutPutType.Add);
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
            EndRequest("RELOAD_F011_1");
        }
    }

    #endregion
}
// RELOAD_F011_1
 
