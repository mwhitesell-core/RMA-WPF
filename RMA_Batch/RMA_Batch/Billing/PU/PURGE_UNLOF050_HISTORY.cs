//  2006/jun/08 - MC - delete all f050 history files
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
public class PURGE_UNLOF050_HISTORY : BaseClassControl
{
    
    private PURGE_UNLOF050_HISTORY m_PURGE_UNLOF050_HISTORY;
    
    public PURGE_UNLOF050_HISTORY(string Name, int Level) : 
            base(Name, Level) {
        this.ScreenType = ScreenTypes.QTP;
    }
    
    public PURGE_UNLOF050_HISTORY(string Name, int Level, bool Request) : 
            base(Name, Level, Request) {
        this.ScreenType = ScreenTypes.QTP;
    }
    
    public override void Dispose() {
        if (!(m_PURGE_UNLOF050_HISTORY == null)) {
            m_PURGE_UNLOF050_HISTORY.CloseTransactionObjects();
            m_PURGE_UNLOF050_HISTORY = null;
        }
        
    }
    
    public PURGE_UNLOF050_HISTORY GetPURGE_UNLOF050_HISTORY(int Level) {
        if ((m_PURGE_UNLOF050_HISTORY == null)) {
            m_PURGE_UNLOF050_HISTORY = new PURGE_UNLOF050_HISTORY("PURGE_UNLOF050_HISTORY", Level);
        }
        else {
            m_PURGE_UNLOF050_HISTORY.ResetValues();
        }
        
        return m_PURGE_UNLOF050_HISTORY;
    }
    
    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.
    protected SqlConnection m_cnnQUERY = new SqlConnection();
    
    protected SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
    
    protected SqlTransaction m_trnTRANS_UPDATE;

    protected string CONNSTRING;

    public override bool RunQTP() {
        try {
            PURGE_UNLOF050_HISTORY_DELETE_F050_HIST_1 DELETE_F050_HIST_1 = new PURGE_UNLOF050_HISTORY_DELETE_F050_HIST_1(Name, Level);
            DELETE_F050_HIST_1.Run();
            DELETE_F050_HIST_1.Dispose();
            DELETE_F050_HIST_1 = null;
            PURGE_UNLOF050_HISTORY_DELETE_F050TP_HIST_2 DELETE_F050TP_HIST_2 = new PURGE_UNLOF050_HISTORY_DELETE_F050TP_HIST_2(Name, Level);
            DELETE_F050TP_HIST_2.Run();
            DELETE_F050TP_HIST_2.Dispose();
            DELETE_F050TP_HIST_2 = null;
            return true;
        }
        catch (CustomApplicationException ex) {
            WriteError(ex);
            return false;
        }
        catch (Exception ex) {
            WriteError(ex);
            return false;
        }
        
    }
}
public class PURGE_UNLOF050_HISTORY_DELETE_F050_HIST_1 : PURGE_UNLOF050_HISTORY {
    
    public PURGE_UNLOF050_HISTORY_DELETE_F050_HIST_1(string Name, int Level) : 
            base(Name, Level, true) {
        this.ScreenType = ScreenTypes.QTP;

        fleF050_DOC_REVENUE_MSTR_HISTORY = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F050_DOC_REVENUE_MSTR_HISTORY", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleSAVEF050HIST_DELETE = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "SAVEF050HIST_DELETE", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        //fleSAVEF050HIST_RETAIN = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "SAVEF050HIST_RETAIN", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        FROM_EP_YR.GetValue += FROM_EP_YR_GetValue;
        TO_EP_YR.GetValue += TO_EP_YR_GetValue;
    }

    private SqlFileObject fleF050_DOC_REVENUE_MSTR_HISTORY;

    private void fleF050_DOC_REVENUE_MSTR_HISTORY_Choose(ref string ChooseClause)
    {
        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF050_DOC_REVENUE_MSTR_HISTORY.ElementOwner("EP_YR")).Append(" >= ");
            strSQL.Append(QDesign.NULL(FROM_EP_YR.Value));

            strSQL.Append(" AND ");
            strSQL.Append(fleF050_DOC_REVENUE_MSTR_HISTORY.ElementOwner("EP_YR")).Append(" <= ");
            strSQL.Append(QDesign.NULL(TO_EP_YR.Value));

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

    private DDecimal FROM_EP_YR = new DDecimal("FROM_EP_YR", 4);
    
    private void FROM_EP_YR_GetValue(ref Decimal Value) {
        try {
            Value = Convert.ToDecimal(Prompt(1));
        }
        catch (CustomApplicationException ex) {
            WriteError(ex);
        }
        catch (Exception ex) {
            WriteError(ex);
        }
        
    }
    
    private DDecimal TO_EP_YR = new DDecimal("TO_EP_YR", 4);
    
    private void TO_EP_YR_GetValue(ref Decimal Value) {
        try {
            Value = Convert.ToDecimal(Prompt(2));
        }
        catch (CustomApplicationException ex) {
            WriteError(ex);
        }
        catch (Exception ex) {
            WriteError(ex);
        }
        
    }

    private SqlFileObject fleSAVEF050HIST_DELETE;

    // Parent:DOCREV_KEY)    'Parent:DOCREV_OMA_CD)    'Parent:DOCREV_MONTH_TO_DATE)    'Parent:DOCREV_YEAR_TO_DATE)    'Parent:DOCREVTP_KEY)    'Parent:DOCREVTP_OMA_CD)    'Parent:DOCREVTP_MTD_YTD
    //private SqlFileObject fleSAVEF050HIST_RETAIN;
    
    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 2019-08-13 8:04:54 AM
    // #-----------------------------------------
    // # InitializeTransactionObjects Procedure.
    // #-----------------------------------------
    protected override void InitializeTransactionObjects() {
        try {
            m_cnnTRANS_UPDATE = new SqlConnection(Common.GetSqlConnectionString());
            m_cnnTRANS_UPDATE.Open();
            m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
            m_cnnQUERY = new SqlConnection(Common.GetSqlConnectionString());
        }
        catch (CustomApplicationException ex) {
            throw ex;
        }
        catch (Exception ex) {
            ExceptionManager.Publish(ex);
            throw ex;
        }
        
    }
    
    // #-----------------------------------------
    // # CloseTransactionObjects Procedure.
    // #-----------------------------------------
    protected override void CloseTransactionObjects() {
        try {
            this.CloseFiles();
            if (!(m_trnTRANS_UPDATE == null)) {
                m_trnTRANS_UPDATE.Dispose();
            }
            
            if (!(m_cnnTRANS_UPDATE == null)) {
                m_cnnTRANS_UPDATE.Close();
            }
            
            if (!(m_cnnTRANS_UPDATE == null)) {
                m_cnnTRANS_UPDATE.Dispose();
            }
            
            if (!(m_cnnQUERY == null)) {
                m_cnnQUERY.Close();
            }
            
            if (!(m_cnnQUERY == null)) {
                m_cnnQUERY.Dispose();
            }
            
        }
        catch (CustomApplicationException ex) {
            throw ex;
        }
        catch (Exception ex) {
            ExceptionManager.Publish(ex);
            throw ex;
        }
        
    }
    
    protected override void TRANS_UPDATE(TransactionMethods Method) {
        if ((Method == TransactionMethods.Rollback)) {
            m_trnTRANS_UPDATE.Rollback();
        }
        else {
            m_trnTRANS_UPDATE.Commit();
        }
        
        m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
        this.Initialize_TRANS_UPDATE();
    }
    
    private void Initialize_TRANS_UPDATE() {
        fleF050_DOC_REVENUE_MSTR_HISTORY.Transaction = m_trnTRANS_UPDATE;
        fleSAVEF050HIST_DELETE.Transaction = m_trnTRANS_UPDATE;
        //fleSAVEF050HIST_RETAIN.Transaction = m_trnTRANS_UPDATE;
    }
    
    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 2019-08-13 8:04:54 AM
    // #-----------------------------------------
    // # InitializeFiles Procedure.
    // #-----------------------------------------
    protected override void InitializeFiles() {
        try {
            this.Initialize_TRANS_UPDATE();
        }
        catch (CustomApplicationException ex) {
            throw ex;
        }
        catch (Exception ex) {
            ExceptionManager.Publish(ex);
            throw ex;
        }
        
    }
    
    // #-----------------------------------------
    // # CloseFiles Procedure.
    // #-----------------------------------------
    protected override void CloseFiles() {
        try {
            fleF050_DOC_REVENUE_MSTR_HISTORY.Dispose();
            fleSAVEF050HIST_DELETE.Dispose();
            //fleSAVEF050HIST_RETAIN.Dispose();
        }
        catch (CustomApplicationException ex) {
            throw ex;
        }
        catch (Exception ex) {
            ExceptionManager.Publish(ex);
            throw ex;
        }
        
    }
    
    public void Run() {
        try {
            Request("DELETE_F050_HIST_1");
            //while (fleF050_DOC_REVENUE_MSTR_HISTORY.QTPForMissing()) {
                //  --> GET F050_DOC_REVENUE_MSTR_HISTORY <--
                //fleF050_DOC_REVENUE_MSTR_HISTORY.GetData();
                //  --> End GET F050_DOC_REVENUE_MSTR_HISTORY <--
                //if (Transaction()) {
                    //SubFile(ref m_trnTRANS_UPDATE, "SAVEF050HIST_DELETE", ((fleF050_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("EP_YR") >= FROM_EP_YR.Value) 
                    //                & (fleF050_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("EP_YR") <= TO_EP_YR.Value)), SubFileType.Keep, fleF050_DOC_REVENUE_MSTR_HISTORY);
                    // Parent:DOCREV_KEY)    'Parent:DOCREV_OMA_CD)    'Parent:DOCREV_MONTH_TO_DATE)    'Parent:DOCREV_YEAR_TO_DATE)    'Parent:DOCREVTP_KEY)    'Parent:DOCREVTP_OMA_CD)    'Parent:DOCREVTP_MTD_YTD
                    //SubFile(ref m_trnTRANS_UPDATE, "SAVEF050HIST_RETAIN", ((QDesign.NULL(fleF050_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("EP_YR")) < QDesign.NULL(FROM_EP_YR.Value)) 
                    //                | (QDesign.NULL(fleF050_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("EP_YR")) > QDesign.NULL(TO_EP_YR.Value))), SubFileType.Keep, fleF050_DOC_REVENUE_MSTR_HISTORY);
                    // Parent:DOCREV_KEY)    'Parent:DOCREV_OMA_CD)    'Parent:DOCREV_MONTH_TO_DATE)    'Parent:DOCREV_YEAR_TO_DATE)    'Parent:DOCREVTP_KEY)    'Parent:DOCREVTP_OMA_CD)    'Parent:DOCREVTP_MTD_YTD


                    //SubFile(ref m_trnTRANS_UPDATE, "SAVEF050HIST_DELETE", SubFileType.Keep, fleF050_DOC_REVENUE_MSTR_HISTORY);
                    //fleF050_DOC_REVENUE_MSTR_HISTORY.OutPut(OutPutType.Delete);
                //}

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

            sql = new StringBuilder("DELETE FROM INDEXED.F050_DOC_REVENUE_MSTR_HISTORY ");
            sql.Append("WHERE EP_YR BETWEEN " + FROM_EP_YR.Value + " AND " + TO_EP_YR.Value);

            try
            {
                var updated = SqlHelper.ExecuteNonQuery(CONNSTRING.Trim(), CommandType.Text, sql.ToString());
            }

            catch (Exception ex)
            {
                WriteError(ex);
            }
        }
        catch (CustomApplicationException ex) {
            WriteError(ex);
        }
        catch (Exception ex) {
            WriteError(ex);
        }
        finally {
            EndRequest("DELETE_F050_HIST_1");
        }
        
    }
}
// DELETE_F050_HIST_1
public class PURGE_UNLOF050_HISTORY_DELETE_F050TP_HIST_2 : PURGE_UNLOF050_HISTORY {
    
    public PURGE_UNLOF050_HISTORY_DELETE_F050TP_HIST_2(string Name, int Level) : 
            base(Name, Level, true) {
        this.ScreenType = ScreenTypes.QTP;

        fleF050TP_DOC_REVENUE_MSTR_HISTORY = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F050TP_DOC_REVENUE_MSTR_HISTORY", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleSAVEF050TPHIST_DELETE = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "SAVEF050TPHIST_DELETE", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        //fleSAVEF050TPHIST_RETAIN = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "SAVEF050TPHIST_RETAIN", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
    }

    private SqlFileObject fleF050TP_DOC_REVENUE_MSTR_HISTORY;

    private void fleF050TP_DOC_REVENUE_MSTR_HISTORY_Choose(ref string ChooseClause)
    {
        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF050TP_DOC_REVENUE_MSTR_HISTORY.ElementOwner("EP_YR")).Append(" >= ");
            strSQL.Append(QDesign.NULL(FROM_EP_YR.Value));

            strSQL.Append(" AND ");
            strSQL.Append(fleF050TP_DOC_REVENUE_MSTR_HISTORY.ElementOwner("EP_YR")).Append(" <= ");
            strSQL.Append(QDesign.NULL(TO_EP_YR.Value));

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


    private DDecimal FROM_EP_YR = new DDecimal("FROM_EP_YR", 4);
    
    private void FROM_EP_YR_GetValue(ref decimal Value) {
        try {
            Value = Convert.ToDecimal(Prompt(3));
        }
        catch (CustomApplicationException ex) {
            WriteError(ex);
        }
        catch (Exception ex) {
            WriteError(ex);
        }
        
    }
    
    private DDecimal TO_EP_YR = new DDecimal("TO_EP_YR", 4);
    
    private void TO_EP_YR_GetValue(ref decimal Value) {
        try {
            Value = Convert.ToDecimal(Prompt(4));
        }
        catch (CustomApplicationException ex) {
            WriteError(ex);
        }
        catch (Exception ex) {
            WriteError(ex);
        }
        
    }

    private SqlFileObject fleSAVEF050TPHIST_DELETE;

    // Parent:DOCREV_KEY)    'Parent:DOCREV_OMA_CD)    'Parent:DOCREV_MONTH_TO_DATE)    'Parent:DOCREV_YEAR_TO_DATE)    'Parent:DOCREVTP_KEY)    'Parent:DOCREVTP_OMA_CD)    'Parent:DOCREVTP_MTD_YTD
    //private SqlFileObject fleSAVEF050TPHIST_RETAIN;
    
    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 2019-08-13 8:04:54 AM
    // #-----------------------------------------
    // # InitializeTransactionObjects Procedure.
    // #-----------------------------------------
    protected override void InitializeTransactionObjects() {
        try {
            m_cnnTRANS_UPDATE = new SqlConnection(Common.GetSqlConnectionString());
            m_cnnTRANS_UPDATE.Open();
            m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
            m_cnnQUERY = new SqlConnection(Common.GetSqlConnectionString());
        }
        catch (CustomApplicationException ex) {
            throw ex;
        }
        catch (Exception ex) {
            ExceptionManager.Publish(ex);
            throw ex;
        }
        
    }
    
    // #-----------------------------------------
    // # CloseTransactionObjects Procedure.
    // #-----------------------------------------
    protected override void CloseTransactionObjects() {
        try {
            this.CloseFiles();
            if (!(m_trnTRANS_UPDATE == null)) {
                m_trnTRANS_UPDATE.Dispose();
            }
            
            if (!(m_cnnTRANS_UPDATE == null)) {
                m_cnnTRANS_UPDATE.Close();
            }
            
            if (!(m_cnnTRANS_UPDATE == null)) {
                m_cnnTRANS_UPDATE.Dispose();
            }
            
            if (!(m_cnnQUERY == null)) {
                m_cnnQUERY.Close();
            }
            
            if (!(m_cnnQUERY == null)) {
                m_cnnQUERY.Dispose();
            }
            
        }
        catch (CustomApplicationException ex) {
            throw ex;
        }
        catch (Exception ex) {
            ExceptionManager.Publish(ex);
            throw ex;
        }
        
    }
    
    protected override void TRANS_UPDATE(TransactionMethods Method) {
        if ((Method == TransactionMethods.Rollback)) {
            m_trnTRANS_UPDATE.Rollback();
        }
        else {
            m_trnTRANS_UPDATE.Commit();
        }
        
        m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
        this.Initialize_TRANS_UPDATE();
    }
    
    private void Initialize_TRANS_UPDATE() {
        fleF050TP_DOC_REVENUE_MSTR_HISTORY.Transaction = m_trnTRANS_UPDATE;
        fleSAVEF050TPHIST_DELETE.Transaction = m_trnTRANS_UPDATE;
        //fleSAVEF050TPHIST_RETAIN.Transaction = m_trnTRANS_UPDATE;
    }
    
    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 2019-08-13 8:04:54 AM
    // #-----------------------------------------
    // # InitializeFiles Procedure.
    // #-----------------------------------------
    protected override void InitializeFiles() {
        try {
            this.Initialize_TRANS_UPDATE();
        }
        catch (CustomApplicationException ex) {
            throw ex;
        }
        catch (Exception ex) {
            ExceptionManager.Publish(ex);
            throw ex;
        }
        
    }
    
    // #-----------------------------------------
    // # CloseFiles Procedure.
    // #-----------------------------------------
    protected override void CloseFiles() {
        try {
            fleF050TP_DOC_REVENUE_MSTR_HISTORY.Dispose();
            fleSAVEF050TPHIST_DELETE.Dispose();
            //fleSAVEF050TPHIST_RETAIN.Dispose();
        }
        catch (CustomApplicationException ex) {
            throw ex;
        }
        catch (Exception ex) {
            ExceptionManager.Publish(ex);
            throw ex;
        }
        
    }
    
    public void Run() {
        try {
            Request("DELETE_F050TP_HIST_2");
            //while (fleF050TP_DOC_REVENUE_MSTR_HISTORY.QTPForMissing()) {
            //    //  --> GET F050TP_DOC_REVENUE_MSTR_HISTORY <--
            //    fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetData();
            //    //  --> End GET F050TP_DOC_REVENUE_MSTR_HISTORY <--
            //    if (Transaction()) {
            //        //SubFile(ref m_trnTRANS_UPDATE, "SAVEF050TPHIST_DELETE", ((fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("EP_YR") >= FROM_EP_YR.Value) 
            //        //                & (fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("EP_YR") <= TO_EP_YR.Value)), SubFileType.Keep, fleF050TP_DOC_REVENUE_MSTR_HISTORY);
            //        // Parent:DOCREV_KEY)    'Parent:DOCREV_OMA_CD)    'Parent:DOCREV_MONTH_TO_DATE)    'Parent:DOCREV_YEAR_TO_DATE)    'Parent:DOCREVTP_KEY)    'Parent:DOCREVTP_OMA_CD)    'Parent:DOCREVTP_MTD_YTD
            //        //SubFile(ref m_trnTRANS_UPDATE, "SAVEF050TPHIST_RETAIN", ((QDesign.NULL(fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("EP_YR")) < QDesign.NULL(FROM_EP_YR.Value)) 
            //        //                | (QDesign.NULL(fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("EP_YR")) > QDesign.NULL(TO_EP_YR.Value))), SubFileType.Keep, fleF050TP_DOC_REVENUE_MSTR_HISTORY);
            //        // Parent:DOCREV_KEY)    'Parent:DOCREV_OMA_CD)    'Parent:DOCREV_MONTH_TO_DATE)    'Parent:DOCREV_YEAR_TO_DATE)    'Parent:DOCREVTP_KEY)    'Parent:DOCREVTP_OMA_CD)    'Parent:DOCREVTP_MTD_YTD

            //        SubFile(ref m_trnTRANS_UPDATE, "SAVEF050TPHIST_DELETE", SubFileType.Keep, fleF050TP_DOC_REVENUE_MSTR_HISTORY);
            //        fleF050TP_DOC_REVENUE_MSTR_HISTORY.OutPut(OutPutType.Delete);
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

            sql = new StringBuilder("DELETE FROM INDEXED.F050TP_DOC_REVENUE_MSTR_HISTORY ");
            sql.Append("WHERE EP_YR BETWEEN " + FROM_EP_YR.Value + " AND " + TO_EP_YR.Value);

            try
            {
                var updated = SqlHelper.ExecuteNonQuery(CONNSTRING.Trim(), CommandType.Text, sql.ToString());
            }

            catch (Exception ex)
            {
                WriteError(ex);
            }
        }
        catch (CustomApplicationException ex) {
            WriteError(ex);
        }
        catch (Exception ex) {
            WriteError(ex);
        }
        finally {
            EndRequest("DELETE_F050TP_HIST_2");
        }
        
    }
}
// DELETE_F050TP_HIST_2