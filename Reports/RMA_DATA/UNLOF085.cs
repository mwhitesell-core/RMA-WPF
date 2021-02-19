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
public class UNLOF085 : BaseRDLClass {
    protected const string REPORT_NAME = "UNLOF085";
    protected const bool REPORT_HAS_PARAMETERS = false;
    private Reader rdrREJECTED_CLAIMS = new Reader();
    private Reader rdrUNLOF085 = new Reader();
    public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug) {
        try
        {
            //  Set Report Properties...
            ReportName = REPORT_NAME;
            ReportHasParameters = REPORT_HAS_PARAMETERS;
            ConfigFile = strReportAssembly;
            ReportFunctions.DebugReport = blnDebug;
            //  Create Subfile.
            SubFile = true;
            SubFileName = "UNLOF085";
            SubFileType = SubFileType.Keep;
            SubFileAT = "TODO: Enter sortbreak name";
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
    private void Access_REJECTED_CLAIMS() {
        StringBuilder strSQL = new StringBuilder(String.Empty);
        strSQL.Append("SELECT ");
        strSQL.Append("CLAIM_NBR, ");
        strSQL.Append("DOC_NBR, ");
        strSQL.Append("CLMHDR_PAT_OHIP_ID_OR_CHART, ");
        strSQL.Append("CLMHDR_LOC, ");
        strSQL.Append("MESS_CODE, ");
        strSQL.Append("LOGICALLY_DELETED_FLAG, ");
        strSQL.Append("CLMHDR_SUBMIT_DATE ");
        strSQL.Append("FROM INDEXED.REJECTED_CLAIMS ");
        strSQL.Append(Choose());
        rdrREJECTED_CLAIMS.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
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
            AddControl(ReportSection.REPORT, "INDEXED.REJECTED_CLAIMS.CLAIM_NBR", DataTypes.Character, 10);
            AddControl(ReportSection.REPORT, "INDEXED.REJECTED_CLAIMS.CLMHDR_LOC", DataTypes.Character, 4);
            AddControl(ReportSection.REPORT, "INDEXED.REJECTED_CLAIMS.CLMHDR_PAT_OHIP_ID_OR_CHART", DataTypes.Character, 16);
            AddControl(ReportSection.REPORT, "INDEXED.REJECTED_CLAIMS.CLMHDR_SUBMIT_DATE", DataTypes.Numeric, 8);
            AddControl(ReportSection.REPORT, "INDEXED.REJECTED_CLAIMS.DOC_NBR", DataTypes.Character, 3);
            AddControl(ReportSection.REPORT, "INDEXED.REJECTED_CLAIMS.LOGICALLY_DELETED_FLAG", DataTypes.Character, 1);
            AddControl(ReportSection.REPORT, "INDEXED.REJECTED_CLAIMS.MESS_CODE", DataTypes.Character, 3);
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
            case "INDEXED.REJECTED_CLAIMS.CLAIM_NBR":
                return Common.StringToField(rdrREJECTED_CLAIMS.GetString("CLAIM_NBR"));
            case "INDEXED.REJECTED_CLAIMS.CLMHDR_LOC":
                return Common.StringToField(rdrREJECTED_CLAIMS.GetString("CLMHDR_LOC"));
            case "INDEXED.REJECTED_CLAIMS.CLMHDR_PAT_OHIP_ID_OR_CHART":
                return Common.StringToField(rdrREJECTED_CLAIMS.GetString("CLMHDR_PAT_OHIP_ID_OR_CHART"));
            case "INDEXED.REJECTED_CLAIMS.CLMHDR_SUBMIT_DATE":
                return rdrREJECTED_CLAIMS.GetNumber("CLMHDR_SUBMIT_DATE").ToString();
            case "INDEXED.REJECTED_CLAIMS.DOC_NBR":
                return Common.StringToField(rdrREJECTED_CLAIMS.GetString("DOC_NBR"));
            case "INDEXED.REJECTED_CLAIMS.LOGICALLY_DELETED_FLAG":
                return Common.StringToField(rdrREJECTED_CLAIMS.GetString("LOGICALLY_DELETED_FLAG"));
            case "INDEXED.REJECTED_CLAIMS.MESS_CODE":
                return Common.StringToField(rdrREJECTED_CLAIMS.GetString("MESS_CODE"));
            default:
                return String.Empty;
        }
    }
    
    public override void AccessData() {
        try
        {
            // TODO: Some manual steps maybe required.
            Access_REJECTED_CLAIMS();
            while (rdrREJECTED_CLAIMS.Read()) {
                WriteData();
            }
            
            rdrREJECTED_CLAIMS.Close();
        }

        catch (Exception ex)
        {
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
    }
    
    public override void CloseReaders() {
        if (!(rdrREJECTED_CLAIMS == null)) {
            rdrREJECTED_CLAIMS.Close();
            rdrREJECTED_CLAIMS = null;
        }
    }
}
}
