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
public class MARYPAYEFT : BaseRDLClass {
    protected const string REPORT_NAME = "MARYPAYEFT";
    protected const bool REPORT_HAS_PARAMETERS = false;
    private Reader rdrF119_DOCTOR_YTD = new Reader();
    private Reader rdrF020_DOCTOR_MSTR = new Reader();
    private Reader rdrF070_DEPT_MSTR = new Reader();
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
    private void Access_F119_DOCTOR_YTD() {
        StringBuilder strSQL = new StringBuilder(String.Empty);
        strSQL.Append("SELECT ");
        strSQL.Append("DOC_NBR, ");
        strSQL.Append("COMP_CODE, ");
        strSQL.Append("AMT_MTD ");
        strSQL.Append("FROM INDEXED.F119_DOCTOR_YTD ");
        strSQL.Append(Choose());
        rdrF119_DOCTOR_YTD.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
        strSQL = null;
    }
    private void Link_F020_DOCTOR_MSTR() {
        StringBuilder strSQL = new StringBuilder(String.Empty);
        // TODO: Check the 'WHERE' and 'AND' clauses are correct.
        strSQL.Append("SELECT ");
        strSQL.Append("DOC_NBR, ");
        strSQL.Append("DOC_DEPT, ");
        strSQL.Append("DOC_NAME, ");
        strSQL.Append("DOC_INIT1, ");
        strSQL.Append(" DOC_INIT2, ");
        strSQL.Append(" DOC_INIT3 ");
        strSQL.Append("FROM INDEXED.F020_DOCTOR_MSTR ");
        strSQL.Append("WHERE ");
        strSQL.Append("DOC_NBR = ").Append(Common.StringToField(rdrF119_DOCTOR_YTD.GetString("DOC_NBR")));
        rdrF020_DOCTOR_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
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
        if (((QDesign.NULL(rdrF119_DOCTOR_YTD.GetString("COMP_CODE")) == "PAYEFT") 
                    && (QDesign.NULL(rdrF119_DOCTOR_YTD.GetNumber("AMT_MTD")) != QDesign.NULL(0d)))) {
            blnSelected = true;
        }
        
        return blnSelected;
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
    public override void DeclareReportControls() {
        try
        {
            AddControl(ReportSection.REPORT, "INDEXED.F119_DOCTOR_YTD.DOC_NBR", DataTypes.Character, 3);
            AddControl(ReportSection.REPORT, "INDEXED.F070_DEPT_MSTR.DEPT_COMPANY", DataTypes.Numeric, 2);
            AddControl(ReportSection.REPORT, "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT", DataTypes.Numeric, 2);
            AddControl(ReportSection.REPORT, "INDEXED.F020_DOCTOR_MSTR.DOC_NAME", DataTypes.Character, 24);
            AddControl(ReportSection.REPORT, "F020_DOCTOR_MSTR_DOC_INITS", DataTypes.Character, 3);
            AddControl(ReportSection.REPORT, "INDEXED.F119_DOCTOR_YTD.COMP_CODE", DataTypes.Character, 6);
            AddControl(ReportSection.REPORT, "INDEXED.F119_DOCTOR_YTD.AMT_MTD", DataTypes.Numeric, 9);
        }

        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
    }
    
    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 2019-07-24 7:51:44 AM
    public override string ReturnControlValue(string strControl, int intSize) {
        switch (strControl) {
            case "INDEXED.F119_DOCTOR_YTD.DOC_NBR":
                return Common.StringToField(rdrF119_DOCTOR_YTD.GetString("DOC_NBR"));
            case "INDEXED.F070_DEPT_MSTR.DEPT_COMPANY":
                return rdrF070_DEPT_MSTR.GetNumber("DEPT_COMPANY").ToString();
            case "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT":
                return rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT").ToString();
            case "INDEXED.F020_DOCTOR_MSTR.DOC_NAME":
                return Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_NAME"));
            case "F020_DOCTOR_MSTR_DOC_INITS":
                return Common.StringToField(F020_DOCTOR_MSTR_DOC_INITS(), intSize);
            case "INDEXED.F119_DOCTOR_YTD.COMP_CODE":
                return Common.StringToField(rdrF119_DOCTOR_YTD.GetString("COMP_CODE"));
            case "INDEXED.F119_DOCTOR_YTD.AMT_MTD":
                return rdrF119_DOCTOR_YTD.GetNumber("AMT_MTD").ToString();
            default:
                return String.Empty;
        }
    }
    
    public override void AccessData() {
        try
        {
            // TODO: Some manual steps maybe required.
            Access_F119_DOCTOR_YTD();
            while (rdrF119_DOCTOR_YTD.Read()) {
                Link_F020_DOCTOR_MSTR();
                while (rdrF020_DOCTOR_MSTR.Read()) {
                    Link_F070_DEPT_MSTR();
                    while (rdrF070_DEPT_MSTR.Read()) {
                        WriteData();
                    }
                    
                    rdrF070_DEPT_MSTR.Close();
                }
                
                rdrF020_DOCTOR_MSTR.Close();
            }
            
            rdrF119_DOCTOR_YTD.Close();
        }

        catch (Exception ex)
        {
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
    }
    
    public override void CloseReaders() {
        if (!(rdrF119_DOCTOR_YTD == null)) {
            rdrF119_DOCTOR_YTD.Close();
            rdrF119_DOCTOR_YTD = null;
        }
        
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
