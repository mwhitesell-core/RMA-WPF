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
public class UNLOF071 : BaseRDLClass {
    protected const string REPORT_NAME = "UNLOF071";
    protected const bool REPORT_HAS_PARAMETERS = false;
    private Reader rdrF071_CLIENT_RMA_CLAIM_NBR = new Reader();
    private Reader rdrUNLOF071 = new Reader();
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
            SubFileName = "UNLOF071";
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
    private void Access_F071_CLIENT_RMA_CLAIM_NBR() {
        StringBuilder strSQL = new StringBuilder(String.Empty);
        strSQL.Append("SELECT ");
        strSQL.Append("CLAIM_NBR_CLIENT, ");
        strSQL.Append("CLINIC_NBR, ");
        strSQL.Append("CLAIM_NBR_RMA ");
        strSQL.Append("FROM INDEXED.F071_CLIENT_RMA_CLAIM_NBR ");
        strSQL.Append(Choose());
        rdrF071_CLIENT_RMA_CLAIM_NBR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
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
            AddControl(ReportSection.REPORT, "INDEXED.F071_CLIENT_RMA_CLAIM_NBR.CLAIM_NBR_CLIENT", DataTypes.Character, 14);
            AddControl(ReportSection.REPORT, "INDEXED.F071_CLIENT_RMA_CLAIM_NBR.CLAIM_NBR_RMA", DataTypes.Character, 8);
            AddControl(ReportSection.REPORT, "INDEXED.F071_CLIENT_RMA_CLAIM_NBR.CLINIC_NBR", DataTypes.Numeric, 2);
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
            case "INDEXED.F071_CLIENT_RMA_CLAIM_NBR.CLAIM_NBR_CLIENT":
                return Common.StringToField(rdrF071_CLIENT_RMA_CLAIM_NBR.GetString("CLAIM_NBR_CLIENT"));
            case "INDEXED.F071_CLIENT_RMA_CLAIM_NBR.CLAIM_NBR_RMA":
                return Common.StringToField(rdrF071_CLIENT_RMA_CLAIM_NBR.GetString("CLAIM_NBR_RMA"));
            case "INDEXED.F071_CLIENT_RMA_CLAIM_NBR.CLINIC_NBR":
                return rdrF071_CLIENT_RMA_CLAIM_NBR.GetNumber("CLINIC_NBR").ToString();
            default:
                return String.Empty;
        }
    }
    
    public override void AccessData() {
        try
        {
            // TODO: Some manual steps maybe required.
            Access_F071_CLIENT_RMA_CLAIM_NBR();
            while (rdrF071_CLIENT_RMA_CLAIM_NBR.Read()) {
                WriteData();
            }
            
            rdrF071_CLIENT_RMA_CLAIM_NBR.Close();
        }

        catch (Exception ex)
        {
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
    }
    
    public override void CloseReaders() {
        if (!(rdrF071_CLIENT_RMA_CLAIM_NBR == null)) {
            rdrF071_CLIENT_RMA_CLAIM_NBR.Close();
            rdrF071_CLIENT_RMA_CLAIM_NBR = null;
        }
    }
}
}
