#region "Screen Comments"

//  2006/jun/08 - MC - delete f011 files
//  2013/jan/08 - MC - add more criteria for deletion
//  2012/feb/26 - MC1  -  only retain last 3 changes as agreed by Maria
//  2013/apr/08 - MC2  -  swap the condition for savef011_retain & savef011_delete
//  2013/02/26 - MC1

#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;

public class PURGE_UNLOF011 : BaseClassControl
{
    
    private PURGE_UNLOF011 m_PURGE_UNLOF011;
    
    public PURGE_UNLOF011(string Name, int Level) : 
            base(Name, Level) 
    {
        this.ScreenType = ScreenTypes.QTP;
    }
    
    public PURGE_UNLOF011(string Name, int Level, bool Request) : 
            base(Name, Level, Request) 
    {
        this.ScreenType = ScreenTypes.QTP;
    }
    
    public override void Dispose() 
    {
        if (!(m_PURGE_UNLOF011 == null)) 
        {
            m_PURGE_UNLOF011.CloseTransactionObjects();
            m_PURGE_UNLOF011 = null;
        }
    }
    
    public PURGE_UNLOF011 GetPURGE_UNLOF011(int Level) 
    {
        if ((m_PURGE_UNLOF011 == null)) 
        {
            m_PURGE_UNLOF011 = new PURGE_UNLOF011("PURGE_UNLOF011", Level);
        }
        else 
        {
            m_PURGE_UNLOF011.ResetValues();
        }
        
        return m_PURGE_UNLOF011;
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
            PURGE_UNLOF011_COUNT_F011_1 COUNT_F011_1 = new PURGE_UNLOF011_COUNT_F011_1(Name, Level);
            COUNT_F011_1.Run();
            COUNT_F011_1.Dispose();
            COUNT_F011_1 = null;

            PURGE_UNLOF011_DELETE_F011_2 DELETE_F011_2 = new PURGE_UNLOF011_DELETE_F011_2(Name, Level);
            DELETE_F011_2.Run();
            DELETE_F011_2.Dispose();
            DELETE_F011_2 = null;

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

public class PURGE_UNLOF011_COUNT_F011_1 : PURGE_UNLOF011 {
    
    public PURGE_UNLOF011_COUNT_F011_1(string Name, int Level) : 
            base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;

        fleF011_PAT_MSTR_ELIG_HISTORY = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F011_PAT_MSTR_ELIG_HISTORY", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleSAVEF011 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "SAVEF011", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
    }
    
    #region "Declarations (Variables, Files and Transactions)(PURGE_UNLOF011)"

    private SqlFileObject fleF011_PAT_MSTR_ELIG_HISTORY;
    private SqlFileObject fleSAVEF011;

    private CoreDecimal XCOUNT;

    #endregion

    #region "Standard Generated Procedures(COUNT_F011_1)"

    #region "Automatic Item Initialization(COUNT_F011_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion

    #region "Transaction Management Procedures(COUNT_F011_1)"

    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 2019-08-13 8:04:57 AM
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
        fleF011_PAT_MSTR_ELIG_HISTORY.Transaction = m_trnTRANS_UPDATE;
        fleSAVEF011.Transaction = m_trnTRANS_UPDATE;
    }
    
    #endregion

    #region "FILE Management Procedures(COUNT_F011_1)"

    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 2019-08-13 8:04:57 AM
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
            fleF011_PAT_MSTR_ELIG_HISTORY.Dispose();
            fleSAVEF011.Dispose();
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
 
    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(COUNT_F011_1)"
        
    public void Run() 
    {
        try 
        {
            Request("COUNT_F011_1");

            while (fleF011_PAT_MSTR_ELIG_HISTORY.QTPForMissing()) 
            {
                //  --> GET F011_PAT_MSTR_ELIG_HISTORY <--
                fleF011_PAT_MSTR_ELIG_HISTORY.GetData();
                //  --> End GET F011_PAT_MSTR_ELIG_HISTORY <--

                if (Transaction()) 
                {
                    Sort(fleF011_PAT_MSTR_ELIG_HISTORY.GetSortValue("PAT_I_KEY"), fleF011_PAT_MSTR_ELIG_HISTORY.GetSortValue("PAT_CON_NBR"), fleF011_PAT_MSTR_ELIG_HISTORY.GetSortValue("PAT_I_NBR"), fleF011_PAT_MSTR_ELIG_HISTORY.GetSortValue("FILLER4"), fleF011_PAT_MSTR_ELIG_HISTORY.GetSortValue("PAT_DATE_LAST_MAINT", SortType.Descending), fleF011_PAT_MSTR_ELIG_HISTORY.GetSortValue("ENTRY_TIME_LONG", SortType.Descending));
                    // Parent:KEY_PAT_MSTR
                }
            }
            
            while (Sort(fleF011_PAT_MSTR_ELIG_HISTORY)) 
            {
                XCOUNT.Value = (XCOUNT.Value + 1);

                SubFile(ref m_trnTRANS_UPDATE, "SAVEF011", SubFileType.Keep, XCOUNT, fleF011_PAT_MSTR_ELIG_HISTORY);
                // Parent:PAT_EXPIRY_DATE)    'Parent:KEY_PAT_MSTR)    'Parent:KEY_PAT_MSTR

                Reset(ref XCOUNT, fleF011_PAT_MSTR_ELIG_HISTORY.At("KEY_PAT_MSTR"));
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
            EndRequest("COUNT_F011_1");
        }
    }

    #endregion
}
// COUNT_F011_1

public class PURGE_UNLOF011_DELETE_F011_2 : PURGE_UNLOF011 
{
    
    public PURGE_UNLOF011_DELETE_F011_2(string Name, int Level) : 
            base(Name, Level, true) 
    {
        this.ScreenType = ScreenTypes.QTP;

        fleSAVEF011 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "SAVEF011", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF010_PAT_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F010_PAT_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleSAVEF011_RETAIN = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "SAVEF011_RETAIN", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleSAVEF011_DELETE = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "SAVEF011_DELETE", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
    }
    
    #region "Declarations (Variables, Files and Transactions)(DELETE_F011_2)"

    private SqlFileObject fleSAVEF011;
    private SqlFileObject fleF010_PAT_MSTR;
    private SqlFileObject fleSAVEF011_RETAIN;
    private SqlFileObject fleSAVEF011_DELETE;

    #endregion

    #region "Standard Generated Procedures(DELETE_F011_2)"

    #region "Automatic Item Initialization(DELETE_F011_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion

    #region "Transaction Management Procedures(DELETE_F011_2)"
    
    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 2019-08-13 8:04:57 AM
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
        fleSAVEF011.Transaction = m_trnTRANS_UPDATE;
        fleF010_PAT_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleSAVEF011_RETAIN.Transaction = m_trnTRANS_UPDATE;
        fleSAVEF011_DELETE.Transaction = m_trnTRANS_UPDATE;
    }
    
    #endregion

    #region "FILE Management Procedures(DELETE_F011_2)"

    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 2019-08-13 8:04:58 AM
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
            fleSAVEF011.Dispose();
            fleF010_PAT_MSTR.Dispose();
            fleSAVEF011_RETAIN.Dispose();
            fleSAVEF011_DELETE.Dispose();
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
 
    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(DELETE_F011_2)"
        
    public void Run() 
    {
        try 
        {
            Request("DELETE_F011_2");

            while (fleSAVEF011.QTPForMissing()) 
            {
                //  --> GET SAVEF011 <--
                fleSAVEF011.GetData();
                //  --> End GET SAVEF011 <--

                while (fleF010_PAT_MSTR.QTPForMissing("1")) 
                {
                    //  --> GET F010_PAT_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_I_KEY")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleSAVEF011.GetStringValue("KEY_PAT_MSTR").PadRight(16).Substring(0, 1)));
                    // Parent:KEY_PAT_MSTR
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_CON_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleSAVEF011.GetStringValue("KEY_PAT_MSTR").PadRight(16).Substring(1, 2)));
                    // Parent:KEY_PAT_MSTR
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_I_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleSAVEF011.GetStringValue("KEY_PAT_MSTR").PadRight(16).Substring(3, 12)));
                    // Parent:KEY_PAT_MSTR
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("FILLER4")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleSAVEF011.GetStringValue("KEY_PAT_MSTR").PadRight(16).Substring(15, 1)));
                    // Parent:KEY_PAT_MSTR
                    fleF010_PAT_MSTR.GetData(m_strWhere.ToString());
                    //  --> End GET F010_PAT_MSTR <--

                    if (Transaction()) 
                    {
                        SubFile(ref m_trnTRANS_UPDATE, "SAVEF011_RETAIN", (fleSAVEF011.GetDecimalValue("XCOUNT") <= 3), SubFileType.Keep, fleSAVEF011);
                        // Parent:PAT_EXPIRY_DATE)    'Parent:KEY_PAT_MSTR)    'Parent:KEY_PAT_MSTR
                        SubFile(ref m_trnTRANS_UPDATE, "SAVEF011_DELETE", (QDesign.NULL(fleSAVEF011.GetDecimalValue("XCOUNT")) > 3), SubFileType.Keep, fleSAVEF011);
                        // Parent:PAT_EXPIRY_DATE)    'Parent:KEY_PAT_MSTR)    'Parent:KEY_PAT_MSTR
                    }
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
            EndRequest("DELETE_F011_2");
        }
    }

    #endregion
}
// DELETE_F011_2