#region "Screen Comments"

//  2006/jun/15 - MC - delete f119  history file

#endregion
using Core.DataAccess.SqlServer;
using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

public class PURGE_UNLOF119_HISTORY : BaseClassControl
{
    private PURGE_UNLOF119_HISTORY m_PURGE_UNLOF119_HISTORY;
    
    public PURGE_UNLOF119_HISTORY(string Name, int Level) : 
            base(Name, Level) 
    {
        this.ScreenType = ScreenTypes.QTP;
    }
    
    public PURGE_UNLOF119_HISTORY(string Name, int Level, bool Request) : 
            base(Name, Level, Request) 
    {
        this.ScreenType = ScreenTypes.QTP;
    }
    
    public override void Dispose() 
    {
        if (!(m_PURGE_UNLOF119_HISTORY == null)) 
        {
            m_PURGE_UNLOF119_HISTORY.CloseTransactionObjects();
            m_PURGE_UNLOF119_HISTORY = null;
        }
    }
    
    public PURGE_UNLOF119_HISTORY GetPURGE_UNLOF119_HISTORY(int Level) 
    {
        if ((m_PURGE_UNLOF119_HISTORY == null)) 
        {
            m_PURGE_UNLOF119_HISTORY = new PURGE_UNLOF119_HISTORY("PURGE_UNLOF119_HISTORY", Level);
        }
        else 
        {
            m_PURGE_UNLOF119_HISTORY.ResetValues();
        }
        
        return m_PURGE_UNLOF119_HISTORY;
    }

    #region "Renaissance Architect Migration Services Default Regions"

    #region "Declarations (Variables, Files and Transactions)"

    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.

    protected SqlConnection m_cnnQUERY = new SqlConnection();
    protected SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
    protected SqlTransaction m_trnTRANS_UPDATE;

    protected string CONNSTRING;

    #endregion

    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"

    public override bool RunQTP()
    {
        try 
        {
            PURGE_UNLOF119_HISTORY_DELETE_F119_HIST_1 DELETE_F119_HIST_1 = new PURGE_UNLOF119_HISTORY_DELETE_F119_HIST_1(Name, Level);
            DELETE_F119_HIST_1.Run();
            DELETE_F119_HIST_1.Dispose();
            DELETE_F119_HIST_1 = null;
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

public class PURGE_UNLOF119_HISTORY_DELETE_F119_HIST_1 : PURGE_UNLOF119_HISTORY 
{
    public PURGE_UNLOF119_HISTORY_DELETE_F119_HIST_1(string Name, int Level) : 
            base(Name, Level, true) 
    {
        this.ScreenType = ScreenTypes.QTP;

        fleF119_DOCTOR_YTD_HISTORY = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F119_DOCTOR_YTD_HISTORY", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleSAVEF119HIST_DELETE = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "SAVEF119HIST_DELETE", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        //fleSAVEF119HIST_RETAIN = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "SAVEF119HIST_RETAIN", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF119_DOCTOR_YTD_HISTORY.Choose += fleF119_DOCTOR_YTD_HISTORY_Choose;

        FROM_EP_NBR.GetValue += FROM_EP_NBR_GetValue;
        TO_EP_NBR.GetValue += TO_EP_NBR_GetValue;
    }

    #region "Declarations (Variables, Files and Transactions)(DELETE_F119_HIST_1)"

    private SqlFileObject fleF119_DOCTOR_YTD_HISTORY;
    private void fleF119_DOCTOR_YTD_HISTORY_Choose(ref string ChooseClause)
    {
        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF119_DOCTOR_YTD_HISTORY.ElementOwner("EP_NBR")).Append(" >= ");
            strSQL.Append(QDesign.NULL(FROM_EP_NBR.Value));

            strSQL.Append(" AND ");
            strSQL.Append(fleF119_DOCTOR_YTD_HISTORY.ElementOwner("EP_NBR")).Append(" <= ");
            strSQL.Append(QDesign.NULL(TO_EP_NBR.Value));

            ChooseClause = strSQL.ToString();
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


    private SqlFileObject fleSAVEF119HIST_DELETE;
    //private SqlFileObject fleSAVEF119HIST_RETAIN;
    
    private DDecimal FROM_EP_NBR = new DDecimal("FROM_EP_NBR", 6);
    
    private void FROM_EP_NBR_GetValue(ref Decimal Value) 
    {
        try 
        {
            Value = QDesign.NConvert(Prompt(1).ToString());
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
    
    private DDecimal TO_EP_NBR = new DDecimal("TO_EP_NBR", 6);
    
    private void TO_EP_NBR_GetValue(ref Decimal Value) 
    {
        try 
        {
            Value = QDesign.NConvert((Prompt(2).ToString()));
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

    #region "Standard Generated Procedures(DELETE_F119_HIST_1)"

    #region "Automatic Item Initialization(DELETE_F119_HIST_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion

    #region "Transaction Management Procedures(DELETE_F119_HIST_1)"
    
    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 2019-08-13 8:04:42 AM
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
        fleF119_DOCTOR_YTD_HISTORY.Transaction = m_trnTRANS_UPDATE;
        fleSAVEF119HIST_DELETE.Transaction = m_trnTRANS_UPDATE;
        //fleSAVEF119HIST_RETAIN.Transaction = m_trnTRANS_UPDATE;
    }
    
    #endregion

    #region "FILE Management Procedures(DELETE_F119_HIST_1)"

    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 2019-08-13 8:04:42 AM
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
            fleF119_DOCTOR_YTD_HISTORY.Dispose();
            fleSAVEF119HIST_DELETE.Dispose();
            //fleSAVEF119HIST_RETAIN.Dispose();
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
 
    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(DELETE_F119_HIST_1)"
        
    public void Run() 
    {
        try 
        {
            Request("DELETE_F119_HIST_1");

            //while (fleF119_DOCTOR_YTD_HISTORY.QTPForMissing()) 
            //{
            //    //  --> GET F119_DOCTOR_YTD_HISTORY <--
            //    fleF119_DOCTOR_YTD_HISTORY.GetData();
            //    //  --> End GET F119_DOCTOR_YTD_HISTORY <--

            //    if (Transaction()) 
            //    {
            //        //SubFile(ref m_trnTRANS_UPDATE, "SAVEF119HIST_DELETE", ((fleF119_DOCTOR_YTD_HISTORY.GetDecimalValue("EP_NBR") >= FROM_EP_NBR.Value) & (fleF119_DOCTOR_YTD_HISTORY.GetDecimalValue("EP_NBR") <= TO_EP_NBR.Value)), SubFileType.Keep, fleF119_DOCTOR_YTD_HISTORY);
            //        SubFile(ref m_trnTRANS_UPDATE, "SAVEF119HIST_RETAIN", ((QDesign.NULL(fleF119_DOCTOR_YTD_HISTORY.GetDecimalValue("EP_NBR")) < QDesign.NULL(FROM_EP_NBR.Value)) | (QDesign.NULL(fleF119_DOCTOR_YTD_HISTORY.GetDecimalValue("EP_NBR")) > QDesign.NULL(TO_EP_NBR.Value))), SubFileType.Keep, fleF119_DOCTOR_YTD_HISTORY);

            //        SubFile(ref m_trnTRANS_UPDATE, "SAVEF119HIST_DELETE", SubFileType.Keep, fleF119_DOCTOR_YTD_HISTORY);
            //        fleF119_DOCTOR_YTD_HISTORY.OutPut(OutPutType.Delete);
            //    }
            //}

            if (Environment.GetEnvironmentVariable("RMABILL_VERS", EnvironmentVariableTarget.Process).ToUpper() == "101C")
            {
                CONNSTRING = ConfigurationManager.AppSettings["ConnectionString1"];
            }
            else if (Environment.GetEnvironmentVariable("RMABILL_VERS", EnvironmentVariableTarget.Process).ToUpper() == "MP")
            {
                CONNSTRING = ConfigurationManager.AppSettings["ConnectionString6"];
            }
            else if (Environment.GetEnvironmentVariable("RMABILL_VERS", EnvironmentVariableTarget.Process).ToUpper() == "SOLO")
            {
                CONNSTRING = ConfigurationManager.AppSettings["ConnectionString7"];
            }

            CONNSTRING = Common.ConnectionStringDecrypt(CONNSTRING.Trim());
            var sql = new StringBuilder("");

            sql = new StringBuilder("DELETE FROM INDEXED.F119_DOCTOR_YTD_HISTORY ");
            sql.Append("WHERE EP_NBR BETWEEN " + FROM_EP_NBR.Value + " AND " + TO_EP_NBR.Value);

            try
            {
                var updated = SqlHelper.ExecuteNonQuery(CONNSTRING.Trim(), CommandType.Text, sql.ToString());
            }

            catch (Exception ex)
            {
                WriteError(ex);
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
            EndRequest("DELETE_F119_HIST_1");
        }
    }

    #endregion
}
// DELETE_F119_HIST_1
