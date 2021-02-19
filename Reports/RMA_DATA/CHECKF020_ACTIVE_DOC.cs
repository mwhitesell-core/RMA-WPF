//  PROGRAM:  CHECKF020_ACTIVE_DOC.QZS
//  select the doctors who started from 20130701 onwards
//  created for the auditors  
//  DATE       WHO       MODIFICATION
//  2014/Jul/28  MC      ORIGINAL
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
public class CHECKF020_ACTIVE_DOC : BaseRDLClass {
    protected const string REPORT_NAME = "CHECKF020_ACTIVE_DOC";
    protected const bool REPORT_HAS_PARAMETERS = false;
    private Reader rdrF020_DOCTOR_MSTR = new Reader();
    private Reader rdrF070_DEPT_MSTR = new Reader();
    private Reader rdrCHECKF020_ACTIVE_DOC = new Reader();
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
            SubFileName = "CHECKF020_ACTIVE_DOC";
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
    private void Access_F020_DOCTOR_MSTR() {
        StringBuilder strSQL = new StringBuilder(String.Empty);
        strSQL.Append("SELECT ");
        strSQL.Append("DOC_DEPT, ");
        strSQL.Append("DOC_DATE_FAC_START_YY, ");
        strSQL.Append(" DOC_DATE_FAC_START_MM, ");
        strSQL.Append(" DOC_DATE_FAC_START_DD, ");
        strSQL.Append("DOC_NBR, ");
        strSQL.Append("DOC_NAME, ");
        strSQL.Append("DOC_INIT1, ");
        strSQL.Append(" DOC_INIT2, ");
        strSQL.Append(" DOC_INIT3, ");
        strSQL.Append("DOC_DATE_FAC_TERM_YY, ");
        strSQL.Append(" DOC_DATE_FAC_TERM_MM, ");
        strSQL.Append(" DOC_DATE_FAC_TERM_DD, ");
        strSQL.Append("DOC_SUB_SPECIALTY ");
        strSQL.Append("FROM INDEXED.F020_DOCTOR_MSTR ");
        strSQL.Append(Choose());
        rdrF020_DOCTOR_MSTR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
        strSQL = null;
    }
    private void Link_F070_DEPT_MSTR() {
        StringBuilder strSQL = new StringBuilder(String.Empty);
        // TODO: Check the 'WHERE' and 'AND' clauses are correct.
        strSQL.Append("SELECT ");
        strSQL.Append("DEPT_NBR, ");
        strSQL.Append("DEPT_COMPANY ");
        strSQL.Append("FROM INDEXED.F070_DEPT_MSTR ");
        strSQL.Append("WHERE ");
        strSQL.Append("DEPT_NBR = ").Append(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT"));
        rdrF070_DEPT_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
        strSQL = null;
    }
    
    private string Choose() {
        StringBuilder strChoose = new StringBuilder(String.Empty);
        // TODO: CHOOSE Statement - May require manual changes.
        return strChoose.ToString().ToString();
    }
    
    public override bool SelectIf() {
        bool blnSelected = false;
        if (rdrF020_DOCTOR_MSTR.GetNumber("DOC_DATE_FAC_START") >= 20160701) {
            blnSelected = true;
        }
        
        return blnSelected;
    }
    
    private string COMMA() {
        string strReturnValue = String.Empty;
        try
        {
            strReturnValue = "~";
        }

        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
        
        return strReturnValue;
    }
    
    private decimal X_NUM_CR() {
        decimal decReturnValue = 0;
        try
        {
            decReturnValue = 13m;
        }

        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
        
        return decReturnValue;
    }
    
    private string X_CR() {
        string strReturnValue = String.Empty;
        try
        {
            strReturnValue = QDesign.Characters(X_NUM_CR());
        }

        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
        
        return strReturnValue;
    }
    
    private string F020_DOCTOR_MSTR_DOC_INITS() {
        string strReturnValue = String.Empty;
        try
        {
            strReturnValue = (rdrF020_DOCTOR_MSTR.GetString("DOC_INIT1") 
                        + (rdrF020_DOCTOR_MSTR.GetString("DOC_INIT2") + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT3")));
        }

        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
        
        return strReturnValue;
    }
    
    private string F020_DOCTOR_MSTR_DOC_DATE_FAC_START() {
        string strReturnValue = String.Empty;
        try
        {
            strReturnValue = (rdrF020_DOCTOR_MSTR.GetString("DOC_DATE_FAC_START_YY") 
                        + (rdrF020_DOCTOR_MSTR.GetString("DOC_DATE_FAC_START_MM") + rdrF020_DOCTOR_MSTR.GetString("DOC_DATE_FAC_START_DD")));
        }

        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
        
        return strReturnValue;
    }
    
    private string F020_DOCTOR_MSTR_DOC_DATE_FAC_TERM() {
        string strReturnValue = String.Empty;
        try
        {
            strReturnValue = (rdrF020_DOCTOR_MSTR.GetString("DOC_DATE_FAC_TERM_YY") 
                        + (rdrF020_DOCTOR_MSTR.GetString("DOC_DATE_FAC_TERM_MM") + rdrF020_DOCTOR_MSTR.GetString("DOC_DATE_FAC_TERM_DD")));
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
            AddControl(ReportSection.SUMMARY, "INDEXED.F020_DOCTOR_MSTR.DOC_NBR", DataTypes.Character, 3);
            AddControl(ReportSection.SUMMARY, "COMMA", DataTypes.Character, 1);
            AddControl(ReportSection.SUMMARY, "INDEXED.F020_DOCTOR_MSTR.DOC_NAME", DataTypes.Character, 24);
            AddControl(ReportSection.SUMMARY, "F020_DOCTOR_MSTR_DOC_INITS", DataTypes.Character, 3);
            AddControl(ReportSection.SUMMARY, "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT", DataTypes.Numeric, 2);
            AddControl(ReportSection.SUMMARY, "INDEXED.F070_DEPT_MSTR.DEPT_COMPANY", DataTypes.Numeric, 2);
            AddControl(ReportSection.SUMMARY, "F020_DOCTOR_MSTR_DOC_DATE_FAC_START", DataTypes.Numeric, 8);
            AddControl(ReportSection.SUMMARY, "F020_DOCTOR_MSTR_DOC_DATE_FAC_TERM", DataTypes.Numeric, 8);
            AddControl(ReportSection.SUMMARY, "INDEXED.F020_DOCTOR_MSTR.DOC_SUB_SPECIALTY", DataTypes.Character, 15);
            AddControl(ReportSection.SUMMARY, "X_CR", DataTypes.Character, 2);
        }

        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
    }
    
    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 2019-07-24 7:52:03 AM
    public override string ReturnControlValue(string strControl, int intSize) {
        switch (strControl) {
            case "INDEXED.F020_DOCTOR_MSTR.DOC_NBR":
                return Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_NBR"));
            case "COMMA":
                return Common.StringToField(COMMA(), intSize);
            case "INDEXED.F020_DOCTOR_MSTR.DOC_NAME":
                return Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_NAME"));
            case "F020_DOCTOR_MSTR_DOC_INITS":
                return Common.StringToField(F020_DOCTOR_MSTR_DOC_INITS(), intSize);
            case "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT":
                return rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT").ToString();
            case "INDEXED.F070_DEPT_MSTR.DEPT_COMPANY":
                return rdrF070_DEPT_MSTR.GetNumber("DEPT_COMPANY").ToString();
            case "F020_DOCTOR_MSTR_DOC_DATE_FAC_START":
                return F020_DOCTOR_MSTR_DOC_DATE_FAC_START().ToString();
            case "F020_DOCTOR_MSTR_DOC_DATE_FAC_TERM":
                return F020_DOCTOR_MSTR_DOC_DATE_FAC_TERM().ToString();
            case "INDEXED.F020_DOCTOR_MSTR.DOC_SUB_SPECIALTY":
                return Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_SUB_SPECIALTY"));
            case "X_CR":
                return Common.StringToField(X_CR(), intSize);
            default:
                return String.Empty;
        }
    }
    
    public override void AccessData() {
        try
        {
            // TODO: Some manual steps maybe required.
            Access_F020_DOCTOR_MSTR();
            while (rdrF020_DOCTOR_MSTR.Read()) {
                Link_F070_DEPT_MSTR();
                while (rdrF070_DEPT_MSTR.Read()) {
                    WriteData();
                }
                
                rdrF070_DEPT_MSTR.Close();
            }
            
            rdrF020_DOCTOR_MSTR.Close();
        }

        catch (Exception ex)
        {
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
    }
    
    public override void CloseReaders() {
        if (!(rdrF020_DOCTOR_MSTR == null)) {
            rdrF020_DOCTOR_MSTR.Close();
            rdrF020_DOCTOR_MSTR = null;
        }
        
        if (!(rdrF070_DEPT_MSTR == null)) {
            rdrF070_DEPT_MSTR.Close();
            rdrF070_DEPT_MSTR = null;
        }
    }
}
}
