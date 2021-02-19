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
public class R072C : BaseRDLClass {
    protected const string REPORT_NAME = "R072C";
    protected const bool REPORT_HAS_PARAMETERS = false;
    private Reader rdrU072_PURGE_VALIDATE = new Reader();
    public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug) {
        try
        {
            //  Set Report Properties...
            ReportName = REPORT_NAME;
            ReportHasParameters = REPORT_HAS_PARAMETERS;
            ConfigFile = strReportAssembly;
            ReportFunctions.DebugReport = blnDebug;
            Sort = "D_ICONST_CLINIC_NBR_1_2 ASC, D_BATCH_TYPE ASC, CLMHDR_AGENT_CD ASC";
            ProcessData(strConnection, arrParameters);
        }

        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
        
        return ReportData;
    }
    private void Access_U072_PURGE_VALIDATE() {
        StringBuilder strSQL = new StringBuilder(String.Empty);
        // TODO: If * is not used to select all columns, ensure the necessary columns (i.e. columns that are used to access records of other tables) are included in the SELECT statement
        strSQL.Append("SELECT ");
        strSQL.Append("D_TYPE, ");
        strSQL.Append("D_ICONST_CLINIC_NBR_1_2, ");
        strSQL.Append("D_BATCH_TYPE, ");
        strSQL.Append("CLMHDR_AGENT_CD, ");
        strSQL.Append("ICONST_DATE_PERIOD_END, ");
        strSQL.Append("ICONST_CLINIC_CYCLE_NBR, ");
        strSQL.Append("D_CLMHDR_TOT_CLAIM_AR_OMA, ");
        strSQL.Append("D_CLMHDR_TOT_CLAIM_AR_OHIP, ");
        strSQL.Append("D_CLMHDR_MANUAL_AND_TAPE_PAYMENTS, ");
        strSQL.Append("D_DELETE_COUNT, ");
        strSQL.Append("D_RETAIN_COUNT ");
        strSQL.Append("FROM TEMPORARYDATA.U072_PURGE_VALIDATE ");
        strSQL.Append(Choose());
        rdrU072_PURGE_VALIDATE.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
        strSQL = null;
    }
    
    private string Choose() {
        StringBuilder strChoose = new StringBuilder(String.Empty);
        // TODO: CHOOSE Statement - May require manual changes.
        return strChoose.ToString().ToString();
    }
    
    public override bool SelectIf() {
        bool blnSelected = false;
        if ((QDesign.NULL(rdrU072_PURGE_VALIDATE.GetString("D_TYPE")) == "CLAIMS")) {
            blnSelected = true;
        }
        
        return blnSelected;
    }
    public override void DeclareReportControls() {
        try
        {
            AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U072_PURGE_VALIDATE.D_ICONST_CLINIC_NBR_1_2", DataTypes.Numeric, 4);
            AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U072_PURGE_VALIDATE.ICONST_DATE_PERIOD_END", DataTypes.Numeric, 8);
            AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U072_PURGE_VALIDATE.ICONST_CLINIC_CYCLE_NBR", DataTypes.Numeric, 2);
            AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U072_PURGE_VALIDATE.X_PED_PURGE_PRIOR_TO_DATE", DataTypes.Character, 1);
            AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U072_PURGE_VALIDATE.D_TYPE", DataTypes.Character, 11);
            AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.U072_PURGE_VALIDATE.CLMHDR_AGENT_CD", DataTypes.Numeric, 1);
            AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.U072_PURGE_VALIDATE.D_CLMHDR_TOT_CLAIM_AR_OMA", DataTypes.Numeric, 7);
            AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.U072_PURGE_VALIDATE.D_CLMHDR_TOT_CLAIM_AR_OHIP", DataTypes.Numeric, 7);
            AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.U072_PURGE_VALIDATE.D_CLMHDR_MANUAL_AND_TAPE_PAYMENTS", DataTypes.Numeric, 7);
            AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.U072_PURGE_VALIDATE.D_DELETE_COUNT", DataTypes.Numeric, 1);
            AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.U072_PURGE_VALIDATE.D_RETAIN_COUNT", DataTypes.Numeric, 1);
            AddControl(ReportSection.REPORT, "TEMPORARYDATA.U072_PURGE_VALIDATE.D_BATCH_TYPE", DataTypes.Character, 1);
        }

        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
    }
    
    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 2019-07-24 7:51:43 AM
    public override string ReturnControlValue(string strControl, int intSize) {
        switch (strControl) {
            case "TEMPORARYDATA.U072_PURGE_VALIDATE.D_ICONST_CLINIC_NBR_1_2":
                return rdrU072_PURGE_VALIDATE.GetNumber("D_ICONST_CLINIC_NBR_1_2").ToString();
            case "TEMPORARYDATA.U072_PURGE_VALIDATE.ICONST_DATE_PERIOD_END":
                return rdrU072_PURGE_VALIDATE.GetNumber("ICONST_DATE_PERIOD_END").ToString();
            case "TEMPORARYDATA.U072_PURGE_VALIDATE.ICONST_CLINIC_CYCLE_NBR":
                return rdrU072_PURGE_VALIDATE.GetNumber("ICONST_CLINIC_CYCLE_NBR").ToString();
            case "TEMPORARYDATA.U072_PURGE_VALIDATE.X_PED_PURGE_PRIOR_TO_DATE":
                return Common.StringToField(rdrU072_PURGE_VALIDATE.GetString("X_PED_PURGE_PRIOR_TO_DATE"));
            case "TEMPORARYDATA.U072_PURGE_VALIDATE.D_TYPE":
                return Common.StringToField(rdrU072_PURGE_VALIDATE.GetString("D_TYPE"));
            case "TEMPORARYDATA.U072_PURGE_VALIDATE.CLMHDR_AGENT_CD":
                return rdrU072_PURGE_VALIDATE.GetNumber("CLMHDR_AGENT_CD").ToString();
            case "TEMPORARYDATA.U072_PURGE_VALIDATE.D_CLMHDR_TOT_CLAIM_AR_OMA":
                return rdrU072_PURGE_VALIDATE.GetNumber("D_CLMHDR_TOT_CLAIM_AR_OMA").ToString();
            case "TEMPORARYDATA.U072_PURGE_VALIDATE.D_CLMHDR_TOT_CLAIM_AR_OHIP":
                return rdrU072_PURGE_VALIDATE.GetNumber("D_CLMHDR_TOT_CLAIM_AR_OHIP").ToString();
            case "TEMPORARYDATA.U072_PURGE_VALIDATE.D_CLMHDR_MANUAL_AND_TAPE_PAYMENTS":
                return rdrU072_PURGE_VALIDATE.GetNumber("D_CLMHDR_MANUAL_AND_TAPE_PAYMENTS").ToString();
            case "TEMPORARYDATA.U072_PURGE_VALIDATE.D_DELETE_COUNT":
                return rdrU072_PURGE_VALIDATE.GetNumber("D_DELETE_COUNT").ToString();
            case "TEMPORARYDATA.U072_PURGE_VALIDATE.D_RETAIN_COUNT":
                return rdrU072_PURGE_VALIDATE.GetNumber("D_RETAIN_COUNT").ToString();
            case "TEMPORARYDATA.U072_PURGE_VALIDATE.D_BATCH_TYPE":
                return Common.StringToField(rdrU072_PURGE_VALIDATE.GetString("D_BATCH_TYPE"));
            default:
                return String.Empty;
        }
    }
    
    public override void AccessData() {
        try
        {
            // TODO: Some manual steps maybe required.
            Access_U072_PURGE_VALIDATE();
            while (rdrU072_PURGE_VALIDATE.Read()) {
                WriteData();
            }
            
            rdrU072_PURGE_VALIDATE.Close();
        }

        catch (Exception ex)
        {
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
    }
    
    public override void CloseReaders() {
        if (!(rdrU072_PURGE_VALIDATE == null)) {
            rdrU072_PURGE_VALIDATE.Close();
            rdrU072_PURGE_VALIDATE = null;
        }
    }
}
}
