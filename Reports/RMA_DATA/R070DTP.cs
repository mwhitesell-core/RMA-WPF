//  DOC: R070DTP.QZS
//  DOC: ACCOUNTS RECEIVABLE
//  DOC: SORT BY/SORT-RECORD-STATUS/AGENT/AGE DESCENDING/CLAIM NUMBER
//  DOC: RUN FOR: MUMC DIAGNOSTICS
//  PROGRAM PURPOSE : ACCOUNTS RECEIVABLE (DETAIL REPORT)
//  THIS IS THE 4TH OF A SERIES OF PROGRAMS TO CREATE
//  THE R070DTP.TXT REPORT
//  DATE       BY WHOM   DESCRIPTION
//  92/07/27   YASEMIN   ORIGINAL
using Core.DataAccess.SqlServer;
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
public class R070DTP : BaseRDLClass {
    protected const string REPORT_NAME = "R070DTP";
    protected const bool REPORT_HAS_PARAMETERS = false;
    private Reader rdrR070BTP = new Reader();
    public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug) {
        try
        {
            //  Set Report Properties...
            ReportName = REPORT_NAME;
            ReportHasParameters = REPORT_HAS_PARAMETERS;
            ConfigFile = strReportAssembly;
            ReportFunctions.DebugReport = blnDebug;
            Sort = "X_HEADING_SORT_RECORD ASC";
            ProcessData(strConnection, arrParameters);
        }

        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
        
        return ReportData;
    }
    private void Access_R070BTP() {
        StringBuilder strSQL = new StringBuilder(String.Empty);
        // TODO: If * is not used to select all columns, ensure the necessary columns (i.e. columns that are used to access records of other tables) are included in the SELECT statement
        strSQL.Append("SELECT ");
        strSQL.Append("X_SORT_RECORD_STATUS, ");
        strSQL.Append("X_DAY_OLD, ");
        strSQL.Append("X_TECH_DUE, ");
        strSQL.Append("X_PROF_DUE, ");
        strSQL.Append("X_BALANCE_DUE, ");
        strSQL.Append("ICONST_DATE_PERIOD_END ");
        strSQL.Append("FROM TEMPORARYDATA.R070BTP ");
        strSQL.Append(Choose());
        rdrR070BTP.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
            strSQL = null;
    }
    
    private string Choose() {
        StringBuilder strChoose = new StringBuilder(String.Empty);
        // TODO: CHOOSE Statement - May require manual changes.
        return strChoose.ToString().ToString();
    }
    
    private string X_HEADING_SORT_RECORD() {
        string strReturnValue = String.Empty;
        try
        {
            if ((QDesign.NULL(rdrR070BTP.GetNumber("X_SORT_RECORD_STATUS")) == 0)) {
                strReturnValue = "CLINIC EXE. WRITEOFFS ---->";
            }
            else
            {
                strReturnValue = "CLINIC WRITEOFFS --------->";
            }
        }

        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
        
        return strReturnValue;
    }
    
    private decimal X_AGENT_TECH_00() {
        decimal decReturnValue = 0;
        try
        {
            if ((QDesign.NULL(rdrR070BTP.GetString("X_DAY_OLD")) == "CUR")) {
                decReturnValue = rdrR070BTP.GetNumber("X_TECH_DUE");
            }
        }

        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
        
        return decReturnValue;
    }
    
    private decimal X_AGENT_TECH_30() {
        decimal decReturnValue = 0;
        try
        {
            if ((QDesign.NULL(rdrR070BTP.GetString("X_DAY_OLD")) == "30")) {
                decReturnValue = rdrR070BTP.GetNumber("X_TECH_DUE");
            }
        }

        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
        
        return decReturnValue;
    }
    
    private decimal X_AGENT_TECH_60() {
        decimal decReturnValue = 0;
        try
        {
            if ((QDesign.NULL(rdrR070BTP.GetString("X_DAY_OLD")) == "60")) {
                decReturnValue = rdrR070BTP.GetNumber("X_TECH_DUE");
            }
        }

        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
        
        return decReturnValue;
    }
    
    private decimal X_AGENT_TECH_90() {
        decimal decReturnValue = 0;
        try
        {
            if ((QDesign.NULL(rdrR070BTP.GetString("X_DAY_OLD")) == "90")) {
                decReturnValue = rdrR070BTP.GetNumber("X_TECH_DUE");
            }
        }

        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
        
        return decReturnValue;
    }
    
    private decimal X_AGENT_TECH_120() {
        decimal decReturnValue = 0;
        try
        {
            if ((QDesign.NULL(rdrR070BTP.GetString("X_DAY_OLD")) == "120")) {
                decReturnValue = rdrR070BTP.GetNumber("X_TECH_DUE");
            }
        }

        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
        
        return decReturnValue;
    }
    
    private decimal X_AGENT_PROF_00() {
        decimal decReturnValue = 0;
        try
        {
            if ((QDesign.NULL(rdrR070BTP.GetString("X_DAY_OLD")) == "CUR")) {
                decReturnValue = rdrR070BTP.GetNumber("X_PROF_DUE");
            }
        }

        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
        
        return decReturnValue;
    }
    
    private decimal X_AGENT_PROF_30() {
        decimal decReturnValue = 0;
        try
        {
            if ((QDesign.NULL(rdrR070BTP.GetString("X_DAY_OLD")) == "30")) {
                decReturnValue = rdrR070BTP.GetNumber("X_PROF_DUE");
            }
        }

        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
        
        return decReturnValue;
    }
    
    private decimal X_AGENT_PROF_60() {
        decimal decReturnValue = 0;
        try
        {
            if ((QDesign.NULL(rdrR070BTP.GetString("X_DAY_OLD")) == "60")) {
                decReturnValue = rdrR070BTP.GetNumber("X_PROF_DUE");
            }
        }

        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
        
        return decReturnValue;
    }
    
    private decimal X_AGENT_PROF_90() {
        decimal decReturnValue = 0;
        try
        {
            if ((QDesign.NULL(rdrR070BTP.GetString("X_DAY_OLD")) == "90")) {
                decReturnValue = rdrR070BTP.GetNumber("X_PROF_DUE");
            }
        }

        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
        
        return decReturnValue;
    }
    
    private decimal X_AGENT_PROF_120() {
        decimal decReturnValue = 0;
        try
        {
            if ((QDesign.NULL(rdrR070BTP.GetString("X_DAY_OLD")) == "120")) {
                decReturnValue = rdrR070BTP.GetNumber("X_PROF_DUE");
            }
        }

        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
        
        return decReturnValue;
    }
    
    private decimal X_AGENT_BALANCE_00() {
        decimal decReturnValue = 0;
        try
        {
            if ((QDesign.NULL(rdrR070BTP.GetString("X_DAY_OLD")) == "CUR")) {
                decReturnValue = rdrR070BTP.GetNumber("X_BALANCE_DUE");
            }
        }

        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
        
        return decReturnValue;
    }
    
    private decimal X_AGENT_BALANCE_30() {
        decimal decReturnValue = 0;
        try
        {
            if ((QDesign.NULL(rdrR070BTP.GetString("X_DAY_OLD")) == "30")) {
                decReturnValue = rdrR070BTP.GetNumber("X_BALANCE_DUE");
            }
        }

        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
        
        return decReturnValue;
    }
    
    private decimal X_AGENT_BALANCE_60() {
        decimal decReturnValue = 0;
        try
        {
            if ((QDesign.NULL(rdrR070BTP.GetString("X_DAY_OLD")) == "60")) {
                decReturnValue = rdrR070BTP.GetNumber("X_BALANCE_DUE");
            }
        }

        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
        
        return decReturnValue;
    }
    
    private decimal X_AGENT_BALANCE_90() {
        decimal decReturnValue = 0;
        try
        {
            if ((QDesign.NULL(rdrR070BTP.GetString("X_DAY_OLD")) == "90")) {
                decReturnValue = rdrR070BTP.GetNumber("X_BALANCE_DUE");
            }
        }

        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
        
        return decReturnValue;
    }
    
    private decimal X_AGENT_BALANCE_120() {
        decimal decReturnValue = 0;
        try
        {
            if ((QDesign.NULL(rdrR070BTP.GetString("X_DAY_OLD")) == "120")) {
                decReturnValue = rdrR070BTP.GetNumber("X_BALANCE_DUE");
            }
        }

        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
        
        return decReturnValue;
    }
    
    private decimal X_AGENT_NBR_00() {
        decimal decReturnValue = 0;
        try
        {
            if ((QDesign.NULL(rdrR070BTP.GetString("X_DAY_OLD")) == "CUR")) {
                decReturnValue = 1;
            }
        }

        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
        
        return decReturnValue;
    }
    
    private decimal X_AGENT_NBR_30() {
        decimal decReturnValue = 0;
        try
        {
            if ((QDesign.NULL(rdrR070BTP.GetString("X_DAY_OLD")) == "30")) {
                decReturnValue = 1;
            }
        }

        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
        
        return decReturnValue;
    }
    
    private decimal X_AGENT_NBR_60() {
        decimal decReturnValue = 0;
        try
        {
            if ((QDesign.NULL(rdrR070BTP.GetString("X_DAY_OLD")) == "60")) {
                decReturnValue = 1;
            }
        }

        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
        
        return decReturnValue;
    }
    
    private decimal X_AGENT_NBR_90() {
        decimal decReturnValue = 0;
        try
        {
            if ((QDesign.NULL(rdrR070BTP.GetString("X_DAY_OLD")) == "90")) {
                decReturnValue = 1;
            }
        }

        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
        
        return decReturnValue;
    }
    
    private decimal X_AGENT_NBR_120() {
        decimal decReturnValue = 0;
        try
        {
            if ((QDesign.NULL(rdrR070BTP.GetString("X_DAY_OLD")) == "120")) {
                decReturnValue = 1;
            }
        }

        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
        
        return decReturnValue;
    }
    
    private decimal X_AGENT_NBR_TOT() {
        decimal decReturnValue = 0;
        try
        {
            decReturnValue = (X_AGENT_NBR_00()
                        + (X_AGENT_NBR_30()
                        + (X_AGENT_NBR_60()
                        + (X_AGENT_NBR_90() + X_AGENT_NBR_120()))));
        }

        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
        
        return decReturnValue;
    }
    
    private decimal X_AGENT_TECH_TOT() {
        decimal decReturnValue = 0;
        try
        {
            decReturnValue = rdrR070BTP.GetNumber("X_TECH_DUE");
        }

        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
        
        return decReturnValue;
    }
    
    private decimal X_AGENT_PROF_TOT() {
        decimal decReturnValue = 0;
        try
        {
            decReturnValue = rdrR070BTP.GetNumber("X_PROF_DUE");
        }

        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
        
        return decReturnValue;
    }
    
    private decimal X_AGENT_BALANCE_TOT() {
        decimal decReturnValue = 0;
        try
        {
            decReturnValue = rdrR070BTP.GetNumber("X_BALANCE_DUE");
        }

        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
        
        return decReturnValue;
    }
    public override void DeclareReportControls() {
        try
        {
 AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.R070BTP.ICONST_DATE_PERIOD_END", DataTypes.Numeric, 8);
 AddControl(ReportSection.FOOTING_AT, "X_HEADING_SORT_RECORD", DataTypes.Character, 27);
 AddControl(ReportSection.FOOTING_AT, "X_AGENT_TECH_00", DataTypes.Numeric, 7);
 AddControl(ReportSection.FOOTING_AT, "X_AGENT_PROF_00", DataTypes.Numeric, 7);
 AddControl(ReportSection.FOOTING_AT, "X_AGENT_BALANCE_00", DataTypes.Numeric, 7);
 AddControl(ReportSection.FOOTING_AT, "X_AGENT_NBR_00", DataTypes.Numeric, 6);
 AddControl(ReportSection.FOOTING_AT, "X_AGENT_TECH_30", DataTypes.Numeric, 7);
 AddControl(ReportSection.FOOTING_AT, "X_AGENT_PROF_30", DataTypes.Numeric, 7);
 AddControl(ReportSection.FOOTING_AT, "X_AGENT_BALANCE_30", DataTypes.Numeric, 7);
 AddControl(ReportSection.FOOTING_AT, "X_AGENT_NBR_30", DataTypes.Numeric, 6);
 AddControl(ReportSection.FOOTING_AT, "X_AGENT_TECH_60", DataTypes.Numeric, 7);
 AddControl(ReportSection.FOOTING_AT, "X_AGENT_PROF_60", DataTypes.Numeric, 7);
 AddControl(ReportSection.FOOTING_AT, "X_AGENT_BALANCE_60", DataTypes.Numeric, 7);
 AddControl(ReportSection.FOOTING_AT, "X_AGENT_NBR_60", DataTypes.Numeric, 6);
 AddControl(ReportSection.FOOTING_AT, "X_AGENT_TECH_90", DataTypes.Numeric, 7);
 AddControl(ReportSection.FOOTING_AT, "X_AGENT_PROF_90", DataTypes.Numeric, 7);
 AddControl(ReportSection.FOOTING_AT, "X_AGENT_BALANCE_90", DataTypes.Numeric, 7);
 AddControl(ReportSection.FOOTING_AT, "X_AGENT_NBR_90", DataTypes.Numeric, 6);
 AddControl(ReportSection.FOOTING_AT, "X_AGENT_TECH_120", DataTypes.Numeric, 7);
 AddControl(ReportSection.FOOTING_AT, "X_AGENT_PROF_120", DataTypes.Numeric, 7);
 AddControl(ReportSection.FOOTING_AT, "X_AGENT_BALANCE_120", DataTypes.Numeric, 7);
 AddControl(ReportSection.FOOTING_AT, "X_AGENT_NBR_120", DataTypes.Numeric, 6);
 AddControl(ReportSection.FOOTING_AT, "X_AGENT_TECH_TOT", DataTypes.Numeric, 7);
 AddControl(ReportSection.FOOTING_AT, "X_AGENT_PROF_TOT", DataTypes.Numeric, 7);
 AddControl(ReportSection.FOOTING_AT, "X_AGENT_BALANCE_TOT", DataTypes.Numeric, 7);
 AddControl(ReportSection.FOOTING_AT, "X_AGENT_NBR_TOT", DataTypes.Numeric, 6);
            }

        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
    }
    
    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 2018-05-14 10:20:59 AM
    public override string ReturnControlValue(string strControl, int intSize) {
        // TODO: Remove duplicate controls, if there are any.
        switch (strControl) {
            case "TEMPORARYDATA.R070BTP.ICONST_DATE_PERIOD_END":
                return rdrR070BTP.GetNumber("ICONST_DATE_PERIOD_END").ToString();
            case "X_HEADING_SORT_RECORD":
                return Common.StringToField(X_HEADING_SORT_RECORD());
            case "X_AGENT_TECH_00":
                return X_AGENT_TECH_00().ToString();
            case "X_AGENT_PROF_00":
                return X_AGENT_PROF_00().ToString();
            case "X_AGENT_BALANCE_00":
                return X_AGENT_BALANCE_00().ToString();
            case "X_AGENT_NBR_00":
                return X_AGENT_NBR_00().ToString();
            case "X_AGENT_TECH_30":
                return X_AGENT_TECH_30().ToString();
            case "X_AGENT_PROF_30":
                return X_AGENT_PROF_30().ToString();
            case "X_AGENT_BALANCE_30":
                return X_AGENT_BALANCE_30().ToString();
            case "X_AGENT_NBR_30":
                return X_AGENT_NBR_30().ToString();
            case "X_AGENT_TECH_60":
                return X_AGENT_TECH_60().ToString();
            case "X_AGENT_PROF_60":
                return X_AGENT_PROF_60().ToString();
            case "X_AGENT_BALANCE_60":
                return X_AGENT_BALANCE_60().ToString();
            case "X_AGENT_NBR_60":
                return X_AGENT_NBR_60().ToString();
            case "X_AGENT_TECH_90":
                return X_AGENT_TECH_90().ToString();
            case "X_AGENT_PROF_90":
                return X_AGENT_PROF_90().ToString();
            case "X_AGENT_BALANCE_90":
                return X_AGENT_BALANCE_90().ToString();
            case "X_AGENT_NBR_90":
                return X_AGENT_NBR_90().ToString();
            case "X_AGENT_TECH_120":
                return X_AGENT_TECH_120().ToString();
            case "X_AGENT_PROF_120":
                return X_AGENT_PROF_120().ToString();
            case "X_AGENT_BALANCE_120":
                return X_AGENT_BALANCE_120().ToString();
            case "X_AGENT_NBR_120":
                return X_AGENT_NBR_120().ToString();
            case "X_AGENT_TECH_TOT":
                return X_AGENT_TECH_TOT().ToString();
            case "X_AGENT_PROF_TOT":
                return X_AGENT_PROF_TOT().ToString();
            case "X_AGENT_BALANCE_TOT":
                return X_AGENT_BALANCE_TOT().ToString();
            case "X_AGENT_NBR_TOT":
                return X_AGENT_NBR_TOT().ToString();
            default:
                return String.Empty;
        }
    }
    public override void AccessData() {
        try
        {
            // TODO: Some manual steps maybe required.
            Access_R070BTP();
            while (rdrR070BTP.Read()) {
                WriteData();
            }
            
            rdrR070BTP.Close();
        }

        catch (Exception ex)
        {
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
    }
    public override void CloseReaders() {
        if (!(rdrR070BTP == null)) {
            rdrR070BTP.Close();
            rdrR070BTP = null;
        }
    }
}
}
