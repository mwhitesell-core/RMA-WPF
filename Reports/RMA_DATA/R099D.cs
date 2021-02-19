using Core.DataAccess.SqlServer;
using Core.DataAccess.TextFile;
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
public class R099D : BaseRDLClass {
    protected const string REPORT_NAME = "R099D";
    protected const bool REPORT_HAS_PARAMETERS = false;
    private Reader rdrU099_PURGE_VALIDATE = new Reader();
    public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug) {
        try
        {
            //  Set Report Properties...
            ReportName = REPORT_NAME;
            ReportHasParameters = REPORT_HAS_PARAMETERS;
            ConfigFile = strReportAssembly;
            ReportFunctions.DebugReport = blnDebug;
            Sort = "D_SORT_ITEM ASC";
            ProcessData(strConnection, arrParameters);
        }

        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
        
        return ReportData;
    }
    private void Access_U099_PURGE_VALIDATE() {
        StringBuilder strSQL = new StringBuilder(String.Empty);
        // TODO: If * is not used to select all columns, ensure the necessary columns (i.e. columns that are used to access records of other tables) are included in the SELECT statement
        strSQL.Append("SELECT ");
        strSQL.Append("D_TOTAL, ");
        strSQL.Append("D_DELETE_COUNT, ");
        strSQL.Append("D_RETAIN_COUNT ");
        strSQL.Append("FROM TEMPORARYDATA.U099_PURGE_VALIDATE ");
        strSQL.Append(Choose());
        rdrU099_PURGE_VALIDATE.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
            strSQL = null;
    }
    
    private string Choose() {
        StringBuilder strChoose = new StringBuilder(String.Empty);
        // TODO: CHOOSE Statement - May require manual changes.
        return strChoose.ToString().ToString();
    }
    
    private decimal D_SORT_ITEM() {
        decimal decReturnValue = 0;
            try
            {
                decReturnValue = 1;
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
        return decReturnValue;
    }
    public override void DeclareReportControls() {
        try
        {
            AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.U099_PURGE_VALIDATE.D_TOTAL", DataTypes.Numeric, 6);
            AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.U099_PURGE_VALIDATE.D_DELETE_COUNT", DataTypes.Numeric, 1);
            AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.U099_PURGE_VALIDATE.D_RETAIN_COUNT", DataTypes.Numeric, 1);
            AddControl(ReportSection.REPORT, "D_SORT_ITEM", DataTypes.Numeric, 6);
        }

        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
    }
    
    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 2019-07-24 7:51:38 AM
    public override string ReturnControlValue(string strControl, int intSize) {
        switch (strControl) {
            case "TEMPORARYDATA.U099_PURGE_VALIDATE.D_TOTAL":
                return rdrU099_PURGE_VALIDATE.GetNumber("D_TOTAL").ToString();
            case "TEMPORARYDATA.U099_PURGE_VALIDATE.D_DELETE_COUNT":
                return rdrU099_PURGE_VALIDATE.GetNumber("D_DELETE_COUNT").ToString();
            case "TEMPORARYDATA.U099_PURGE_VALIDATE.D_RETAIN_COUNT":
                return rdrU099_PURGE_VALIDATE.GetNumber("D_RETAIN_COUNT").ToString();
            case "D_SORT_ITEM":
                return D_SORT_ITEM().ToString();
            default:
                return String.Empty;
        }
    }
    
    public override void AccessData() {
        try
        {
            // TODO: Some manual steps maybe required.
            Access_U099_PURGE_VALIDATE();
            while (rdrU099_PURGE_VALIDATE.Read()) {
                WriteData();
            }
            
            rdrU099_PURGE_VALIDATE.Close();
        }

        catch (Exception ex)
        {
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
    }
    
    public override void CloseReaders() {
        if (!(rdrU099_PURGE_VALIDATE == null)) {
            rdrU099_PURGE_VALIDATE.Close();
            rdrU099_PURGE_VALIDATE = null;
        }
    }
}
}
