//  #> PROGRAM-ID.     R707.QZS
//  ((C)) Dyad Technologies
//  PROGRAM PURPOSE : PRINT A LIST OF NEW PATIENTS
//  MODIFICATION HISTORY
//  DATE SMS # WHO DESCRIPTION
//  90.07.11 000 D.B. ORIGINAL
//  90.10.31  000     Y.B.    ADD REPORT DEVICE DISC
//  93.07.21  142     M.C.    NEW-PAT-OHIP HAS CHANGED FROM
//  9(10) TO X(12)
//  1999/jan/28         B.E.    - y2k 
//  2008/jan/29  M.C.    - removed subscr name, change alignmnet for pat first name
//  2013/Oct/30         MC1     - allow to display postal code (10 chars)   
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
public class R707 : BaseRDLClass {
    protected const string REPORT_NAME = "R707";
    protected const bool REPORT_HAS_PARAMETERS = false;
    private Reader rdrSUBMIT_DISK_PAT_NEW = new Reader();
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
    private void Access_SUBMIT_DISK_PAT_NEW() {
        StringBuilder strSQL = new StringBuilder(String.Empty);
        strSQL.Append("SELECT ");
        strSQL.Append("NEW_PAT_OHIP, ");
        strSQL.Append("NEW_PAT_SURNAME, ");
        strSQL.Append("NEW_PAT_FIRST_NAME, ");
        strSQL.Append("NEW_PAT_ADDRESS_LINE_1, ");
        strSQL.Append("NEW_PAT_ADDRESS_LINE_2, ");
        strSQL.Append("NEW_PAT_ADDRESS_LINE_3, ");
        strSQL.Append("NEW_PAT_POSTAL_CODE, ");
        strSQL.Append("NEW_PAT_BIRTH_DATE, ");
        strSQL.Append("NEW_PAT_SEX ");
        strSQL.Append("FROM SEQUENTIAL.SUBMIT_DISK_PAT_NEW ");
        strSQL.Append(Choose());
        rdrSUBMIT_DISK_PAT_NEW.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.m_strFlatFileDictionary, ReportFunctions.TextFiles);
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
 AddControl(ReportSection.REPORT, "SEQUENTIAL.SUBMIT_DISK_PAT_NEW.NEW_PAT_OHIP", DataTypes.Character, 12);
 AddControl(ReportSection.REPORT, "SEQUENTIAL.SUBMIT_DISK_PAT_NEW.NEW_PAT_SURNAME", DataTypes.Character, 25);
 AddControl(ReportSection.REPORT, "SEQUENTIAL.SUBMIT_DISK_PAT_NEW.NEW_PAT_FIRST_NAME", DataTypes.Character, 17);
 AddControl(ReportSection.REPORT, "SEQUENTIAL.SUBMIT_DISK_PAT_NEW.NEW_PAT_ADDRESS_LINE_1", DataTypes.Character, 30);
 AddControl(ReportSection.REPORT, "SEQUENTIAL.SUBMIT_DISK_PAT_NEW.NEW_PAT_ADDRESS_LINE_2", DataTypes.Character, 30);
 AddControl(ReportSection.REPORT, "SEQUENTIAL.SUBMIT_DISK_PAT_NEW.NEW_PAT_ADDRESS_LINE_3", DataTypes.Character, 30);
 AddControl(ReportSection.REPORT, "SEQUENTIAL.SUBMIT_DISK_PAT_NEW.NEW_PAT_POSTAL_CODE", DataTypes.Character, 10);
 AddControl(ReportSection.REPORT, "SEQUENTIAL.SUBMIT_DISK_PAT_NEW.NEW_PAT_BIRTH_DATE", DataTypes.Character, 8);
 AddControl(ReportSection.REPORT, "SEQUENTIAL.SUBMIT_DISK_PAT_NEW.NEW_PAT_SEX", DataTypes.Character, 1);
        }

        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
    }
    
    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 2018-05-15 3:04:05 PM
    public override string ReturnControlValue(string strControl, int intSize) {
        // TODO: Remove duplicate controls, if there are any.
        switch (strControl) {
            case "SEQUENTIAL.SUBMIT_DISK_PAT_NEW.NEW_PAT_OHIP":
                return Common.StringToField(rdrSUBMIT_DISK_PAT_NEW.GetString("NEW_PAT_OHIP"));
            case "SEQUENTIAL.SUBMIT_DISK_PAT_NEW.NEW_PAT_SURNAME":
                return Common.StringToField(rdrSUBMIT_DISK_PAT_NEW.GetString("NEW_PAT_SURNAME"));
            case "SEQUENTIAL.SUBMIT_DISK_PAT_NEW.NEW_PAT_FIRST_NAME":
                return Common.StringToField(rdrSUBMIT_DISK_PAT_NEW.GetString("NEW_PAT_FIRST_NAME"));
            case "SEQUENTIAL.SUBMIT_DISK_PAT_NEW.NEW_PAT_ADDRESS_LINE_1":
                return Common.StringToField(rdrSUBMIT_DISK_PAT_NEW.GetString("NEW_PAT_ADDRESS_LINE_1"));
            case "SEQUENTIAL.SUBMIT_DISK_PAT_NEW.NEW_PAT_ADDRESS_LINE_2":
                return Common.StringToField(rdrSUBMIT_DISK_PAT_NEW.GetString("NEW_PAT_ADDRESS_LINE_2"));
            case "SEQUENTIAL.SUBMIT_DISK_PAT_NEW.NEW_PAT_ADDRESS_LINE_3":
                return Common.StringToField(rdrSUBMIT_DISK_PAT_NEW.GetString("NEW_PAT_ADDRESS_LINE_3"));
            case "SEQUENTIAL.SUBMIT_DISK_PAT_NEW.NEW_PAT_POSTAL_CODE":
                return Common.StringToField(rdrSUBMIT_DISK_PAT_NEW.GetString("NEW_PAT_POSTAL_CODE"));
            case "SEQUENTIAL.SUBMIT_DISK_PAT_NEW.NEW_PAT_BIRTH_DATE":
                return Common.StringToField(rdrSUBMIT_DISK_PAT_NEW.GetString("NEW_PAT_BIRTH_DATE"));
            case "SEQUENTIAL.SUBMIT_DISK_PAT_NEW.NEW_PAT_SEX":
                return Common.StringToField(rdrSUBMIT_DISK_PAT_NEW.GetString("NEW_PAT_SEX"));
            default:
                return String.Empty;
        }
    }
    public override void AccessData() {
        try
        {
            // TODO: Some manual steps maybe required.
            Access_SUBMIT_DISK_PAT_NEW();
            while (rdrSUBMIT_DISK_PAT_NEW.Read()) {
                WriteData();
            }
            
            rdrSUBMIT_DISK_PAT_NEW.Close();
        }

        catch (Exception ex)
        {
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
    }
    public override void CloseReaders() {
        if (!(rdrSUBMIT_DISK_PAT_NEW == null)) {
            rdrSUBMIT_DISK_PAT_NEW.Close();
            rdrSUBMIT_DISK_PAT_NEW = null;
        }
    }
}
}
