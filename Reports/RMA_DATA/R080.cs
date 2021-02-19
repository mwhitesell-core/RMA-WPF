//  #> PROGRAM-ID. R080.qzs
//  ((C)) Dyad Technologies
//  PROGRAM PURPOSE :  PRODUCE AN AUDIT REPORT SUBTOTALING
//  ALL PATIENTS DELETED AND RETAIN AFTER
//  PATIENT PURGE
//  MODIFICATION HISTORY
//  DATE   WHO       DESCRIPTION
//  2000/07/27  BANNIS    ORIGIONAL
//  2013/04/09  MC1   include 4 more chart nbrs (E6 to E9)
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
public class R080 : BaseRDLClass {
    protected const string REPORT_NAME = "R080";
    protected const bool REPORT_HAS_PARAMETERS = false;
    private Reader rdrU080_INVALID_RECORDS = new Reader();
    public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug) {
        try
        {
            //  Set Report Properties...
            ReportName = REPORT_NAME;
            ReportHasParameters = REPORT_HAS_PARAMETERS;
            ConfigFile = strReportAssembly;
            ReportFunctions.DebugReport = blnDebug;
            Sort = "PAT_ACRONYM ASC, D_INVALID_REC ASC";
            ProcessData(strConnection, arrParameters);
        }

        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
        
        return ReportData;
    }
    private void Access_U080_INVALID_RECORDS() {
        StringBuilder strSQL = new StringBuilder(String.Empty);
        // TODO: If * is not used to select all columns, ensure the necessary columns (i.e. columns that are used to access records of other tables) are included in the SELECT statement
        strSQL.Append("SELECT ");
        strSQL.Append("PAT_ACRONYM, ");
        strSQL.Append("PAT_OHIP_MMYY, ");
        strSQL.Append("PAT_SURNAME, ");
        strSQL.Append("PAT_GIVEN_NAME, ");
        strSQL.Append("PAT_INIT, ");
        strSQL.Append("PAT_LOCATION_FIELD, ");
        strSQL.Append("PAT_LAST_DOC_NBR_SEEN, ");
        strSQL.Append("PAT_BIRTH_DATE, ");
        strSQL.Append("PAT_DATE_LAST_MAINT, ");
        strSQL.Append("PAT_DATE_LAST_VISIT, ");
        strSQL.Append("PAT_DATE_LAST_ADMIT, ");
        strSQL.Append("PAT_PHONE_NBR, ");
        strSQL.Append("PAT_CHART_NBR, ");
        strSQL.Append("PAT_CHART_NBR_2, ");
        strSQL.Append("PAT_CHART_NBR_3, ");
        strSQL.Append("PAT_CHART_NBR_4, ");
        strSQL.Append("PAT_CHART_NBR_5 ");
        strSQL.Append("FROM TEMPORARYDATA.U080_INVALID_RECORDS ");
        strSQL.Append(Choose());
        rdrU080_INVALID_RECORDS.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
        strSQL = null;
    }
    
    private string Choose() {
        StringBuilder strChoose = new StringBuilder(String.Empty);
        // TODO: CHOOSE Statement - May require manual changes.
        return strChoose.ToString().ToString();
    }
    
    private string D_ERROR_MSG() {
        string strReturnValue = String.Empty;
        try
        {
            if ((QDesign.NULL(rdrU080_INVALID_RECORDS.GetString("D_INVALID_REC")) == "E1")) {
                strReturnValue = "INVALID OHIP NUMBER FOR RELATED PROVINCE";
            }
            else if ((QDesign.NULL(rdrU080_INVALID_RECORDS.GetString("D_INVALID_REC")) == "E2")) 
            {
                strReturnValue = "DIRECT-ID DOES NOT BEGIN 3 LETTERS";
            }
            else if ((QDesign.NULL(rdrU080_INVALID_RECORDS.GetString("D_INVALID_REC")) == "E3")) 
            {
                strReturnValue = "HEALTH, OHIP AND CHART NUMBERS = SPACES";
            }
            else if ((QDesign.NULL(rdrU080_INVALID_RECORDS.GetString("D_INVALID_REC")) == "E4")) 
            {
                strReturnValue = "INVALID PAT ACRONYM KEY";
            }
            else if ((QDesign.NULL(rdrU080_INVALID_RECORDS.GetString("D_INVALID_REC")) == "E5")) 
            {
                strReturnValue = "INVALID CHART NUMBER FORMAT";
            }
            else if ((QDesign.NULL(rdrU080_INVALID_RECORDS.GetString("D_INVALID_REC")) == "E6")) 
            {
                strReturnValue = "INVALID CHART NUMBER 2 FORMAT";
            }
            else if ((QDesign.NULL(rdrU080_INVALID_RECORDS.GetString("D_INVALID_REC")) == "E7")) 
            {
                strReturnValue = "INVALID CHART NUMBER 3 FORMAT";
            }
            else if ((QDesign.NULL(rdrU080_INVALID_RECORDS.GetString("D_INVALID_REC")) == "E8")) 
            {
                strReturnValue = "INVALID CHART NUMBER 4 FORMAT";
            }
            else if ((QDesign.NULL(rdrU080_INVALID_RECORDS.GetString("D_INVALID_REC")) == "E9")) 
            {
                strReturnValue = "INVALID CHART NUMBER 5 FORMAT";
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
            AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U080_INVALID_RECORDS.T_COUNT", DataTypes.Character, 1);
            AddControl(ReportSection.REPORT, "D_ERROR_MSG", DataTypes.Character, 60);
            AddControl(ReportSection.REPORT, "TEMPORARYDATA.U080_INVALID_RECORDS.PAT_ACRONYM", DataTypes.Character, 9);
            AddControl(ReportSection.REPORT, "TEMPORARYDATA.U080_INVALID_RECORDS.PAT_OHIP_MMYY", DataTypes.Character, 15);
            AddControl(ReportSection.REPORT, "TEMPORARYDATA.U080_INVALID_RECORDS.PAT_SURNAME", DataTypes.Character, 25);
            AddControl(ReportSection.REPORT, "TEMPORARYDATA.U080_INVALID_RECORDS.PAT_GIVEN_NAME", DataTypes.Character, 17);
            AddControl(ReportSection.REPORT, "TEMPORARYDATA.U080_INVALID_RECORDS.PAT_INIT", DataTypes.Character, 3);
            AddControl(ReportSection.REPORT, "TEMPORARYDATA.U080_INVALID_RECORDS.PAT_LOCATION_FIELD", DataTypes.Character, 4);
            AddControl(ReportSection.REPORT, "TEMPORARYDATA.U080_INVALID_RECORDS.D_FILLER", DataTypes.Character, 1);
            AddControl(ReportSection.REPORT, "TEMPORARYDATA.U080_INVALID_RECORDS.PAT_LAST_DOC_NBR_SEEN", DataTypes.Character, 3);
            AddControl(ReportSection.REPORT, "TEMPORARYDATA.U080_INVALID_RECORDS.PAT_BIRTH_DATE", DataTypes.Numeric, 8);
            AddControl(ReportSection.REPORT, "TEMPORARYDATA.U080_INVALID_RECORDS.PAT_DATE_LAST_MAINT", DataTypes.Numeric, 8);
            AddControl(ReportSection.REPORT, "TEMPORARYDATA.U080_INVALID_RECORDS.PAT_DATE_LAST_VISIT", DataTypes.Numeric, 8);
            AddControl(ReportSection.REPORT, "TEMPORARYDATA.U080_INVALID_RECORDS.PAT_DATE_LAST_ADMIT", DataTypes.Numeric, 8);
            AddControl(ReportSection.REPORT, "TEMPORARYDATA.U080_INVALID_RECORDS.PAT_PHONE_NBR", DataTypes.Character, 20);
            AddControl(ReportSection.REPORT, "TEMPORARYDATA.U080_INVALID_RECORDS.PAT_CHART_NBR", DataTypes.Character, 10);
            AddControl(ReportSection.REPORT, "TEMPORARYDATA.U080_INVALID_RECORDS.PAT_CHART_NBR_2", DataTypes.Character, 10);
            AddControl(ReportSection.REPORT, "TEMPORARYDATA.U080_INVALID_RECORDS.PAT_CHART_NBR_3", DataTypes.Character, 10);
            AddControl(ReportSection.REPORT, "TEMPORARYDATA.U080_INVALID_RECORDS.PAT_CHART_NBR_4", DataTypes.Character, 10);
            AddControl(ReportSection.REPORT, "TEMPORARYDATA.U080_INVALID_RECORDS.PAT_CHART_NBR_5", DataTypes.Character, 11);
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
            case "TEMPORARYDATA.U080_INVALID_RECORDS.T_COUNT":
                return Common.StringToField(rdrU080_INVALID_RECORDS.GetString("T_COUNT"));
            case "D_ERROR_MSG":
                return Common.StringToField(D_ERROR_MSG(), intSize);
            case "TEMPORARYDATA.U080_INVALID_RECORDS.PAT_ACRONYM":
                return Common.StringToField(rdrU080_INVALID_RECORDS.GetString("PAT_ACRONYM"));
            case "TEMPORARYDATA.U080_INVALID_RECORDS.PAT_OHIP_MMYY":
                return Common.StringToField(rdrU080_INVALID_RECORDS.GetString("PAT_OHIP_MMYY"));
            case "TEMPORARYDATA.U080_INVALID_RECORDS.PAT_SURNAME":
                return Common.StringToField(rdrU080_INVALID_RECORDS.GetString("PAT_SURNAME"));
            case "TEMPORARYDATA.U080_INVALID_RECORDS.PAT_GIVEN_NAME":
                return Common.StringToField(rdrU080_INVALID_RECORDS.GetString("PAT_GIVEN_NAME"));
            case "TEMPORARYDATA.U080_INVALID_RECORDS.PAT_INIT":
                return Common.StringToField(rdrU080_INVALID_RECORDS.GetString("PAT_INIT"));
            case "TEMPORARYDATA.U080_INVALID_RECORDS.PAT_LOCATION_FIELD":
                return Common.StringToField(rdrU080_INVALID_RECORDS.GetString("PAT_LOCATION_FIELD"));
            case "TEMPORARYDATA.U080_INVALID_RECORDS.D_FILLER":
                return Common.StringToField(rdrU080_INVALID_RECORDS.GetString("D_FILLER"));
            case "TEMPORARYDATA.U080_INVALID_RECORDS.PAT_LAST_DOC_NBR_SEEN":
                return Common.StringToField(rdrU080_INVALID_RECORDS.GetString("PAT_LAST_DOC_NBR_SEEN"));
            case "TEMPORARYDATA.U080_INVALID_RECORDS.PAT_BIRTH_DATE":
                return rdrU080_INVALID_RECORDS.GetNumber("PAT_BIRTH_DATE").ToString();
            case "TEMPORARYDATA.U080_INVALID_RECORDS.PAT_DATE_LAST_MAINT":
                return rdrU080_INVALID_RECORDS.GetNumber("PAT_DATE_LAST_MAINT").ToString();
            case "TEMPORARYDATA.U080_INVALID_RECORDS.PAT_DATE_LAST_VISIT":
                return rdrU080_INVALID_RECORDS.GetNumber("PAT_DATE_LAST_VISIT").ToString();
            case "TEMPORARYDATA.U080_INVALID_RECORDS.PAT_DATE_LAST_ADMIT":
                return rdrU080_INVALID_RECORDS.GetNumber("PAT_DATE_LAST_ADMIT").ToString();
            case "TEMPORARYDATA.U080_INVALID_RECORDS.PAT_PHONE_NBR":
                return Common.StringToField(rdrU080_INVALID_RECORDS.GetString("PAT_PHONE_NBR"));
            case "TEMPORARYDATA.U080_INVALID_RECORDS.PAT_CHART_NBR":
                return Common.StringToField(rdrU080_INVALID_RECORDS.GetString("PAT_CHART_NBR"));
            case "TEMPORARYDATA.U080_INVALID_RECORDS.PAT_CHART_NBR_2":
                return Common.StringToField(rdrU080_INVALID_RECORDS.GetString("PAT_CHART_NBR_2"));
            case "TEMPORARYDATA.U080_INVALID_RECORDS.PAT_CHART_NBR_3":
                return Common.StringToField(rdrU080_INVALID_RECORDS.GetString("PAT_CHART_NBR_3"));
            case "TEMPORARYDATA.U080_INVALID_RECORDS.PAT_CHART_NBR_4":
                return Common.StringToField(rdrU080_INVALID_RECORDS.GetString("PAT_CHART_NBR_4"));
            case "TEMPORARYDATA.U080_INVALID_RECORDS.PAT_CHART_NBR_5":
                return Common.StringToField(rdrU080_INVALID_RECORDS.GetString("PAT_CHART_NBR_5"));
            default:
                return String.Empty;
        }
    }
    
    public override void AccessData() {
        try
        {
            // TODO: Some manual steps maybe required.
            Access_U080_INVALID_RECORDS();
            while (rdrU080_INVALID_RECORDS.Read()) {
                WriteData();
            }
            
            rdrU080_INVALID_RECORDS.Close();
        }

        catch (Exception ex)
        {
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
    }
    
    public override void CloseReaders() {
        if (!(rdrU080_INVALID_RECORDS == null)) {
            rdrU080_INVALID_RECORDS.Close();
            rdrU080_INVALID_RECORDS = null;
        }
    }
}
}
