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
public class UNLOF099 : BaseRDLClass {
    protected const string REPORT_NAME = "UNLOF099";
    protected const bool REPORT_HAS_PARAMETERS = false;
    private Reader rdrF099_GROUP_CLAIM_MSTR = new Reader();
    private Reader rdrUNLOF099 = new Reader();
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
            SubFileName = "UNLOF099";
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
    private void Access_F099_GROUP_CLAIM_MSTR() {
        StringBuilder strSQL = new StringBuilder(String.Empty);
        strSQL.Append("SELECT ");
        strSQL.Append("GROUP_NBR, ");
        strSQL.Append("CLMHDR_BATCH_NBR, ");
        strSQL.Append(" CLMHDR_CLAIM_NBR, ");
        strSQL.Append("ACCOUNTING_NBR ");
        strSQL.Append("FROM INDEXED.F099_GROUP_CLAIM_MSTR ");
        strSQL.Append(Choose());
        rdrF099_GROUP_CLAIM_MSTR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
        strSQL = null;
    }
    
    private string Choose() {
        StringBuilder strChoose = new StringBuilder(String.Empty);
        // TODO: CHOOSE Statement - May require manual changes.
        return strChoose.ToString().ToString();
    }
    
    private string F099_GROUP_CLAIM_MSTR_CLAIM_ID() {
        string strReturnValue = String.Empty;
        try
        {
            strReturnValue = (rdrF099_GROUP_CLAIM_MSTR.GetString("CLMHDR_BATCH_NBR") + rdrF099_GROUP_CLAIM_MSTR.GetString("CLMHDR_CLAIM_NBR"));
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
            AddControl(ReportSection.REPORT, "INDEXED.F099_GROUP_CLAIM_MSTR.ACCOUNTING_NBR", DataTypes.Character, 8);
            AddControl(ReportSection.REPORT, "F099_GROUP_CLAIM_MSTR_CLAIM_ID", DataTypes.Character, 10);
            AddControl(ReportSection.REPORT, "INDEXED.F099_GROUP_CLAIM_MSTR.CLMHDR_BATCH_NBR", DataTypes.Character, 8);
            AddControl(ReportSection.REPORT, "INDEXED.F099_GROUP_CLAIM_MSTR.CLMHDR_CLAIM_NBR", DataTypes.Numeric, 2);
            AddControl(ReportSection.REPORT, "INDEXED.F099_GROUP_CLAIM_MSTR.GROUP_NBR", DataTypes.Character, 4);
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
            case "INDEXED.F099_GROUP_CLAIM_MSTR.ACCOUNTING_NBR":
                return Common.StringToField(rdrF099_GROUP_CLAIM_MSTR.GetString("ACCOUNTING_NBR"));
            case "F099_GROUP_CLAIM_MSTR_CLAIM_ID":
                return Common.StringToField(F099_GROUP_CLAIM_MSTR_CLAIM_ID(), intSize);
            case "INDEXED.F099_GROUP_CLAIM_MSTR.CLMHDR_BATCH_NBR":
                return Common.StringToField(rdrF099_GROUP_CLAIM_MSTR.GetString("CLMHDR_BATCH_NBR"));
            case "INDEXED.F099_GROUP_CLAIM_MSTR.CLMHDR_CLAIM_NBR":
                return rdrF099_GROUP_CLAIM_MSTR.GetNumber("CLMHDR_CLAIM_NBR").ToString();
            case "INDEXED.F099_GROUP_CLAIM_MSTR.GROUP_NBR":
                return Common.StringToField(rdrF099_GROUP_CLAIM_MSTR.GetString("GROUP_NBR"));
            default:
                return String.Empty;
        }
    }
    
    public override void AccessData() {
        try
        {
            // TODO: Some manual steps maybe required.
            Access_F099_GROUP_CLAIM_MSTR();
            while (rdrF099_GROUP_CLAIM_MSTR.Read()) {
                WriteData();
            }
            
            rdrF099_GROUP_CLAIM_MSTR.Close();
        }

        catch (Exception ex)
        {
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
    }
    
    public override void CloseReaders() {
        if (!(rdrF099_GROUP_CLAIM_MSTR == null)) {
            rdrF099_GROUP_CLAIM_MSTR.Close();
            rdrF099_GROUP_CLAIM_MSTR = null;
        }
    }
}
}
