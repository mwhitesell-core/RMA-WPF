//  PROGRAM:  CHECKF020A.QZS
//  CHECK TOT SCREEN FOR COMPUTED CEIL/EXP AND COMPUTED REQUIRED
//  AND TARGET and prdecimal if different
//  DATE      WHO       MODIFICATION
//  96/02/21  YAS       ORIGINAL
//  2009/jul/06 MC      Yasemin requested to modify to select for dept 1 to 7
//  and if doc-ytdear and doc-ytdcea and doc-yrly-ceiling-computed are not the same
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
public class CHECKF020A : BaseRDLClass {
    protected const string REPORT_NAME = "CHECKF020A";
    protected const bool REPORT_HAS_PARAMETERS = false;
    private Reader rdrF020_DOCTOR_MSTR = new Reader();
    private Reader rdrF020_DOCTOR_EXTRA = new Reader();
    public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug) {
        try
        {
            //  Set Report Properties...
            ReportName = REPORT_NAME;
            ReportHasParameters = REPORT_HAS_PARAMETERS;
            ConfigFile = strReportAssembly;
            ReportFunctions.DebugReport = blnDebug;
            Sort = "DOC_DEPT ASC, X_DOC_NAME ASC";
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
        strSQL.Append("DOC_NBR, ");
        strSQL.Append("DOC_YRLY_CEILING_COMPUTED, ");
        strSQL.Append("DOC_YRLY_EXPENSE_COMPUTED, ");
        strSQL.Append("DOC_DEPT, ");
        strSQL.Append("DOC_YTDEAR, ");
        strSQL.Append("DOC_YTDCEA, ");
        strSQL.Append("DOC_NAME, ");
        strSQL.Append("DOC_INIT1, ");
        strSQL.Append(" DOC_INIT2, ");
        strSQL.Append(" DOC_INIT3 ");
        strSQL.Append("FROM INDEXED.F020_DOCTOR_MSTR ");
        strSQL.Append(Choose());
        rdrF020_DOCTOR_MSTR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
        strSQL = null;
    }
    private void Link_F020_DOCTOR_EXTRA() {
        StringBuilder strSQL = new StringBuilder(String.Empty);
        // TODO: Check the 'WHERE' and 'AND' clauses are correct.
        strSQL.Append("SELECT ");
        strSQL.Append("DOC_NBR, ");
        strSQL.Append("DOC_YRLY_REQUIRE_REVENUE, ");
        strSQL.Append("DOC_YRLY_TARGET_REVENUE ");
        strSQL.Append("FROM INDEXED.F020_DOCTOR_EXTRA ");
        strSQL.Append("WHERE ");
        strSQL.Append("DOC_NBR = ").Append(Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_NBR")));
        rdrF020_DOCTOR_EXTRA.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
        strSQL = null;
    }
    
    private string Choose() {
        StringBuilder strChoose = new StringBuilder(String.Empty);
        // TODO: CHOOSE Statement - May require manual changes.
        return strChoose.ToString().ToString();
    }
    
    public override bool SelectIf() {
        bool blnSelected = false;
        if (((rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT") >= 1) 
                    && (rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT") <= 7))) {
            blnSelected = true;
        }
        
        return blnSelected;
    }
    
    private decimal X_CEILING() {
        decimal decReturnValue = 0;
        try
        {
            decReturnValue = QDesign.PHMod(rdrF020_DOCTOR_MSTR.GetNumber("DOC_YRLY_CEILING_COMPUTED"), 100);
        }

        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
        
        return decReturnValue;
    }
    
    private decimal X_EXPENSE() {
        decimal decReturnValue = 0;
        try
        {
            decReturnValue = QDesign.PHMod(rdrF020_DOCTOR_MSTR.GetNumber("DOC_YRLY_EXPENSE_COMPUTED"), 100);
        }

        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
        
        return decReturnValue;
    }
    
    private decimal X_REQUIRE() {
        decimal decReturnValue = 0;
        try
        {
            decReturnValue = QDesign.PHMod(rdrF020_DOCTOR_EXTRA.GetNumber("DOC_YRLY_REQUIRE_REVENUE"), 100);
        }

        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
        
        return decReturnValue;
    }
    
    private decimal X_TARGET() {
        decimal decReturnValue = 0;
        try
        {
            decReturnValue = QDesign.PHMod(rdrF020_DOCTOR_EXTRA.GetNumber("DOC_YRLY_TARGET_REVENUE"), 100);
        }

        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
        
        return decReturnValue;
    }
    
    private string X_DOC_NAME() {
        string strReturnValue = String.Empty;
        try
        {
            if (ReportDataFunctions.Exists(rdrF020_DOCTOR_MSTR)) {
                strReturnValue = ("DR. " 
                            + (rdrF020_DOCTOR_MSTR.GetString("DOC_NAME") + (" " + rdrF020_DOCTOR_MSTR.GetString("DOC_INITS"))));
            }
            else
            {
                strReturnValue = "UNKNOWN!";
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
            AddControl(ReportSection.REPORT, "INDEXED.F020_DOCTOR_MSTR.DOC_NBR", DataTypes.Character, 3);
            AddControl(ReportSection.REPORT, "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT", DataTypes.Numeric, 2);
            AddControl(ReportSection.REPORT, "X_DOC_NAME", DataTypes.Character, 20);
            AddControl(ReportSection.REPORT, "INDEXED.F020_DOCTOR_MSTR.DOC_YRLY_CEILING_COMPUTED", DataTypes.Numeric, 9);
            AddControl(ReportSection.REPORT, "INDEXED.F020_DOCTOR_MSTR.DOC_YRLY_EXPENSE_COMPUTED", DataTypes.Numeric, 9);
            AddControl(ReportSection.REPORT, "INDEXED.F020_DOCTOR_EXTRA.DOC_YRLY_REQUIRE_REVENUE", DataTypes.Numeric, 9);
            AddControl(ReportSection.REPORT, "INDEXED.F020_DOCTOR_EXTRA.DOC_YRLY_TARGET_REVENUE", DataTypes.Numeric, 9);
            AddControl(ReportSection.REPORT, "INDEXED.F020_DOCTOR_MSTR.DOC_YTDEAR", DataTypes.Numeric, 9);
            AddControl(ReportSection.REPORT, "INDEXED.F020_DOCTOR_MSTR.DOC_YTDCEA", DataTypes.Numeric, 9);
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
            case "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT":
                return rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT").ToString();
            case "X_DOC_NAME":
                return Common.StringToField(X_DOC_NAME(), intSize);
            case "INDEXED.F020_DOCTOR_MSTR.DOC_YRLY_CEILING_COMPUTED":
                return rdrF020_DOCTOR_MSTR.GetNumber("DOC_YRLY_CEILING_COMPUTED").ToString();
            case "INDEXED.F020_DOCTOR_MSTR.DOC_YRLY_EXPENSE_COMPUTED":
                return rdrF020_DOCTOR_MSTR.GetNumber("DOC_YRLY_EXPENSE_COMPUTED").ToString();
            case "INDEXED.F020_DOCTOR_EXTRA.DOC_YRLY_REQUIRE_REVENUE":
                return rdrF020_DOCTOR_EXTRA.GetNumber("DOC_YRLY_REQUIRE_REVENUE").ToString();
            case "INDEXED.F020_DOCTOR_EXTRA.DOC_YRLY_TARGET_REVENUE":
                return rdrF020_DOCTOR_EXTRA.GetNumber("DOC_YRLY_TARGET_REVENUE").ToString();
            case "INDEXED.F020_DOCTOR_MSTR.DOC_YTDEAR":
                return rdrF020_DOCTOR_MSTR.GetNumber("DOC_YTDEAR").ToString();
            case "INDEXED.F020_DOCTOR_MSTR.DOC_YTDCEA":
                return rdrF020_DOCTOR_MSTR.GetNumber("DOC_YTDCEA").ToString();
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
                Link_F020_DOCTOR_EXTRA();
                while (rdrF020_DOCTOR_EXTRA.Read()) {
                    WriteData();
                }
                
                rdrF020_DOCTOR_EXTRA.Close();
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
        
        if (!(rdrF020_DOCTOR_EXTRA == null)) {
            rdrF020_DOCTOR_EXTRA.Close();
            rdrF020_DOCTOR_EXTRA = null;
        }
    }
}
}
