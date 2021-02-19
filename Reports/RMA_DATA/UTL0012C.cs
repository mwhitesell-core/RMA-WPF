//  program utl0012c.qzs
//  purpose: before adding patients to f010, ensure the ikeys are not already there
using Core.DataAccess.SqlServer;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.ReportFramework;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
namespace RMA_DATA
{
public class UTL0012C : BaseRDLClass {
    protected const string REPORT_NAME = "UTL0012C";
    protected const bool REPORT_HAS_PARAMETERS = false;
    private Reader rdrU099_DELETE_PATIENTS = new Reader();
    private Reader rdrTMP_PAT_MSTR = new Reader();
    private Reader rdrF010_PAT_MSTR = new Reader();
    public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug) {
        try
        {
            //  Set Report Properties...
            ReportName = REPORT_NAME;
            ReportHasParameters = REPORT_HAS_PARAMETERS;
            ConfigFile = strReportAssembly;
            ReportFunctions.DebugReport = blnDebug;
            Sort = "";
            ProcessData(strConnection, arrParameters);
        }

        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
        
        return ReportData;
    }
    private void Access_U099_DELETE_PATIENTS() {
        StringBuilder strSQL = new StringBuilder(String.Empty);
        // TODO: If * is not used to select all columns, ensure the necessary columns (i.e. columns that are used to access records of other tables) are included in the SELECT statement
        strSQL.Append("SELECT * ");
        strSQL.Append("FROM TEMPORARYDATA.U099_DELETE_PATIENTS ");
        strSQL.Append(Choose());
        rdrU099_DELETE_PATIENTS.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
        strSQL = null;
    }
    private void Link_TMP_PAT_MSTR() {
        StringBuilder strSQL = new StringBuilder(String.Empty);
        // TODO: Check the 'WHERE' and 'AND' clauses are correct.
        strSQL.Append("SELECT ");
        strSQL.Append("PAT_I_KEY, ");
        strSQL.Append(" PAT_CON_NBR, ");
        strSQL.Append(" PAT_I_NBR, ");
        strSQL.Append(" FILLER4 ");
        strSQL.Append("FROM INDEXED.TMP_PAT_MSTR ");
        strSQL.Append("WHERE ");
        strSQL.Append("KEY_PAT_MSTR = ").Append(QDesign.Substring(rdrU099_DELETE_PATIENTS.GetString("KEY_PAT_MSTR"), 2, 15));
        rdrTMP_PAT_MSTR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
        strSQL = null;
    }
    private void Link_F010_PAT_MSTR() {
        StringBuilder strSQL = new StringBuilder(String.Empty);
        // TODO: Check the 'WHERE' and 'AND' clauses are correct.
        strSQL.Append("SELECT ");
        strSQL.Append("PAT_I_KEY, ");
        strSQL.Append(" PAT_CON_NBR, ");
        strSQL.Append(" PAT_I_NBR, ");
        strSQL.Append(" FILLER4 ");
        strSQL.Append("FROM INDEXED.F010_PAT_MSTR ");
        strSQL.Append("WHERE ");
        strSQL.Append("KEY_PAT_MSTR = ").Append(rdrTMP_PAT_MSTR.GetString("KEY_PAT_MSTR"));
        rdrF010_PAT_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
        strSQL = null;
    }
    
    private string Choose() {
        StringBuilder strChoose = new StringBuilder(String.Empty);
        // TODO: CHOOSE Statement - May require manual changes.
        return strChoose.ToString().ToString();
    }
    
    public override bool SelectIf() {
        bool blnSelected = false;
        if ((QDesign.NULL(X_PROBLEM_FLAG()) == "Y")) {
            blnSelected = true;
        }
        
        return blnSelected;
    }
    
    private string X_PROBLEM_FLAG() {
        string strReturnValue = String.Empty;
        try
        {
            if (ReportDataFunctions.Exists(rdrF010_PAT_MSTR)) {
                strReturnValue = "Y";
            }
        }

        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
        
        return strReturnValue;
    }
    public override void DeclareReportControls() {
        try
        {
            AddControl(ReportSection.REPORT, "X_PROBLEM_FLAG", DataTypes.Character, 1);
        }

        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
    }
    
    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 2019-07-24 7:51:37 AM
    public override string ReturnControlValue(string strControl, int intSize) {
        switch (strControl) {
            case "X_PROBLEM_FLAG":
                return Common.StringToField(X_PROBLEM_FLAG(), intSize);
            default:
                return String.Empty;
        }
    }
    
    public override void AccessData() {
        try
        {
            // TODO: Some manual steps maybe required.
            Access_U099_DELETE_PATIENTS();
            while (rdrU099_DELETE_PATIENTS.Read()) {
                Link_TMP_PAT_MSTR();
                while (rdrTMP_PAT_MSTR.Read()) {
                    Link_F010_PAT_MSTR();
                    while (rdrF010_PAT_MSTR.Read()) {
                        WriteData();
                    }
                    
                    rdrF010_PAT_MSTR.Close();
                }
                
                rdrTMP_PAT_MSTR.Close();
            }
            
            rdrU099_DELETE_PATIENTS.Close();
        }

        catch (Exception ex)
        {
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
    }
    
    public override void CloseReaders() {
        if (!(rdrU099_DELETE_PATIENTS == null)) {
            rdrU099_DELETE_PATIENTS.Close();
            rdrU099_DELETE_PATIENTS = null;
        }
        
        if (!(rdrTMP_PAT_MSTR == null)) {
            rdrTMP_PAT_MSTR.Close();
            rdrTMP_PAT_MSTR = null;
        }
        
        if (!(rdrF010_PAT_MSTR == null)) {
            rdrF010_PAT_MSTR.Close();
            rdrF010_PAT_MSTR = null;
        }
    }
}
}
