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
public class UNLOF002EXTRA : BaseRDLClass {
    protected const string REPORT_NAME = "UNLOF002EXTRA";
    protected const bool REPORT_HAS_PARAMETERS = false;
    private Reader rdrF002_CLAIMS_EXTRA = new Reader();
    private Reader rdrUNLOF002EXTRA = new Reader();
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
            SubFileName = "UNLOF002EXTRA";
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
    private void Access_F002_CLAIMS_EXTRA() {
        StringBuilder strSQL = new StringBuilder(String.Empty);
        strSQL.Append("SELECT ");
        strSQL.Append("CLMHDR_RMA_CLM_NBR, ");
        strSQL.Append("CLMHDR_OHIP_CLM_NBR ");
        strSQL.Append("FROM INDEXED.F002_CLAIMS_EXTRA ");
        strSQL.Append(Choose());
        rdrF002_CLAIMS_EXTRA.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
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
            AddControl(ReportSection.REPORT, "INDEXED.F002_CLAIMS_EXTRA.CLMHDR_OHIP_CLM_NBR", DataTypes.Character, 11);
            AddControl(ReportSection.REPORT, "INDEXED.F002_CLAIMS_EXTRA.CLMHDR_RMA_CLM_NBR", DataTypes.Character, 10);
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
            case "INDEXED.F002_CLAIMS_EXTRA.CLMHDR_OHIP_CLM_NBR":
                return Common.StringToField(rdrF002_CLAIMS_EXTRA.GetString("CLMHDR_OHIP_CLM_NBR"));
            case "INDEXED.F002_CLAIMS_EXTRA.CLMHDR_RMA_CLM_NBR":
                return Common.StringToField(rdrF002_CLAIMS_EXTRA.GetString("CLMHDR_RMA_CLM_NBR"));
            default:
                return String.Empty;
        }
    }
    
    public override void AccessData() {
        try
        {
            // TODO: Some manual steps maybe required.
            Access_F002_CLAIMS_EXTRA();
            while (rdrF002_CLAIMS_EXTRA.Read()) {
                WriteData();
            }
            
            rdrF002_CLAIMS_EXTRA.Close();
        }

        catch (Exception ex)
        {
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
    }
    
    public override void CloseReaders() {
        if (!(rdrF002_CLAIMS_EXTRA == null)) {
            rdrF002_CLAIMS_EXTRA.Close();
            rdrF002_CLAIMS_EXTRA = null;
        }
    }
}
}
