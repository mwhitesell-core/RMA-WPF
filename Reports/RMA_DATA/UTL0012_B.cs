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
public class UTL0012_B : BaseRDLClass {
    protected const string REPORT_NAME = "UTL0012_B";
    protected const bool REPORT_HAS_PARAMETERS = false;
    private Reader rdrNOPAT = new Reader();
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
    private void Access_NOPAT() {
        StringBuilder strSQL = new StringBuilder(String.Empty);
        // TODO: If * is not used to select all columns, ensure the necessary columns (i.e. columns that are used to access records of other tables) are included in the SELECT statement
        strSQL.Append("SELECT ");
        strSQL.Append("CLMHDR_BATCH_NBR, ");
        strSQL.Append("CLMHDR_CLAIM_NBR, ");
        strSQL.Append("KEY_CLM_TYPE, ");
        strSQL.Append("KEY_CLM_BATCH_NBR, ");
        strSQL.Append("KEY_CLM_CLAIM_NBR, ");
        strSQL.Append("KEY_CLM_SERV_CODE, ");
        strSQL.Append("KEY_CLM_ADJ_NBR, ");
        strSQL.Append("CLMHDR_PAT_ACRONYM, ");
        strSQL.Append("CLMHDR_PAT_OHIP_ID_OR_CHART, ");
        strSQL.Append("KEY_P_CLM_DATA ");
        strSQL.Append("FROM TEMPORARYDATA.NOPAT ");
        strSQL.Append(Choose());
        rdrNOPAT.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
        strSQL = null;
    }
    
    private string Choose() {
        StringBuilder strChoose = new StringBuilder(String.Empty);
        // TODO: CHOOSE Statement - May require manual changes.
        return strChoose.ToString().ToString();
    }
    public override void DeclareReportControls() {
        try
        {
 AddControl(ReportSection.REPORT, "TEMPORARYDATA.NOPAT.CLMHDR_BATCH_NBR", DataTypes.Character, 8);
 AddControl(ReportSection.REPORT, "TEMPORARYDATA.NOPAT.CLMHDR_CLAIM_NBR", DataTypes.Numeric, 2);
 AddControl(ReportSection.REPORT, "TEMPORARYDATA.NOPAT.CLMHDR_PAT_ACRONYM", DataTypes.Character, 9);
 AddControl(ReportSection.REPORT, "TEMPORARYDATA.NOPAT.CLMHDR_PAT_OHIP_ID_OR_CHART", DataTypes.Character, 16);
 AddControl(ReportSection.REPORT, "TEMPORARYDATA.NOPAT.KEY_CLM_ADJ_NBR", DataTypes.Character, 1);
 AddControl(ReportSection.REPORT, "TEMPORARYDATA.NOPAT.KEY_CLM_BATCH_NBR", DataTypes.Character, 8);
 AddControl(ReportSection.REPORT, "TEMPORARYDATA.NOPAT.KEY_CLM_CLAIM_NBR", DataTypes.Numeric, 2);
 AddControl(ReportSection.REPORT, "TEMPORARYDATA.NOPAT.KEY_CLM_SERV_CODE", DataTypes.Character, 5);
 AddControl(ReportSection.REPORT, "TEMPORARYDATA.NOPAT.KEY_CLM_TYPE", DataTypes.Character, 1);
 AddControl(ReportSection.REPORT, "TEMPORARYDATA.NOPAT.KEY_P_CLM_DATA", DataTypes.Character, 16);
        }

        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
    }
    
    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 2019-07-24 7:51:35 AM
    public override string ReturnControlValue(string strControl, int intSize) {
        switch (strControl) {
            case "TEMPORARYDATA.NOPAT.CLMHDR_BATCH_NBR":
                return Common.StringToField(rdrNOPAT.GetString("CLMHDR_BATCH_NBR"));
            case "TEMPORARYDATA.NOPAT.CLMHDR_CLAIM_NBR":
                return rdrNOPAT.GetNumber("CLMHDR_CLAIM_NBR").ToString();
            case "TEMPORARYDATA.NOPAT.CLMHDR_PAT_ACRONYM":
                return Common.StringToField(rdrNOPAT.GetString("CLMHDR_PAT_ACRONYM"));
            case "TEMPORARYDATA.NOPAT.CLMHDR_PAT_OHIP_ID_OR_CHART":
                return Common.StringToField(rdrNOPAT.GetString("CLMHDR_PAT_OHIP_ID_OR_CHART"));
            case "TEMPORARYDATA.NOPAT.KEY_CLM_ADJ_NBR":
                return Common.StringToField(rdrNOPAT.GetString("KEY_CLM_ADJ_NBR"));
            case "TEMPORARYDATA.NOPAT.KEY_CLM_BATCH_NBR":
                return Common.StringToField(rdrNOPAT.GetString("KEY_CLM_BATCH_NBR"));
            case "TEMPORARYDATA.NOPAT.KEY_CLM_CLAIM_NBR":
                return rdrNOPAT.GetNumber("KEY_CLM_CLAIM_NBR").ToString();
            case "TEMPORARYDATA.NOPAT.KEY_CLM_SERV_CODE":
                return Common.StringToField(rdrNOPAT.GetString("KEY_CLM_SERV_CODE"));
            case "TEMPORARYDATA.NOPAT.KEY_CLM_TYPE":
                return Common.StringToField(rdrNOPAT.GetString("KEY_CLM_TYPE"));
            case "TEMPORARYDATA.NOPAT.KEY_P_CLM_DATA":
                return Common.StringToField(rdrNOPAT.GetString("KEY_P_CLM_DATA"));
            default:
                return String.Empty;
        }
    }
    
    public override void AccessData() {
        try
        {
            // TODO: Some manual steps maybe required.
            Access_NOPAT();
            while (rdrNOPAT.Read()) {
                WriteData();
            }
            
            rdrNOPAT.Close();
        }

        catch (Exception ex)
        {
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
    }
    
    public override void CloseReaders() {
        if (!(rdrNOPAT == null)) {
            rdrNOPAT.Close();
            rdrNOPAT = null;
        }
    }
}
}
