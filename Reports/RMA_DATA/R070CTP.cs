//  DOC: R070CTP.QZS
//  DOC: ACCOUNTS RECEIVABLE
//  DOC: SORT BY/SORT-RECORD-STATUS/AGENT/AGE DESCENDING/CLAIM NUMBER
//  DOC: RUN FOR: MUMC DIAGNOSTICS
//  PROGRAM PURPOSE : ACCOUNTS RECEIVABLE (DETAIL REPORT)
//  THIS IS THE THIRD OF A SERIES OF PROGRAMS TO CREATE
//  THE R070CTP.TXT REPORT
//  DATE       BY WHOM   DESCRIPTION
//  92/06/22   YASEMIN   ORIGINAL
//  03/dec/17  A.A.      alpha doctor nbr
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
public class R070CTP : BaseRDLClass {
    protected const string REPORT_NAME = "R070CTP";
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
            Sort = "X_CLINIC ASC, X_SORT_RECORD_STATUS ASC, CLMHDR_AGENT_CD ASC, X_AGE_CATEGORY DESC, X_CLM_ID ASC";
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
        strSQL.Append("X_CLINIC, ");
        strSQL.Append("X_SORT_RECORD_STATUS, ");
        strSQL.Append("CLMHDR_AGENT_CD, ");
        strSQL.Append("X_AGE_CATEGORY, ");
        strSQL.Append("X_CLM_ID, ");
        strSQL.Append("X_DAY_OLD, ");
        strSQL.Append("X_TECH_DUE, ");
        strSQL.Append("X_PROF_DUE, ");
        strSQL.Append("X_BALANCE_DUE, ");
        strSQL.Append("CLMHDR_DOC_DEPT, ");
        strSQL.Append("X_SUB_NBR, ");
        strSQL.Append("CLMHDR_REFERENCE, ");
        strSQL.Append("ICONST_DATE_PERIOD_END, ");
        strSQL.Append("ICONST_CLINIC_NAME, ");
        strSQL.Append("ICONST_CLINIC_NBR, ");
        strSQL.Append("CLMHDR_PAT_ACRONYM, ");
        strSQL.Append("X_PAT_ID_INFO, ");
        strSQL.Append("CLMHDR_AMT_TECH_BILLED, ");
        strSQL.Append("CLMHDR_AMT_TECH_PAID, ");
        strSQL.Append("X_PROF_BILL, ");
        strSQL.Append("X_PROF_PAID, ");
        strSQL.Append("CLMHDR_DATE_PERIOD_END, ");
        strSQL.Append("CLMDTL_SV_DATE, ");
        strSQL.Append("CLMHDR_ORIG_BATCH_NBR ");
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
    
    private decimal X_DEPT1() {
        decimal decReturnValue = 0;
        try
        {
            if ((QDesign.NULL(rdrR070BTP.GetNumber("CLMHDR_DOC_DEPT")) == QDesign.NULL(1d))) {
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
    
    private decimal X_DEPT2() {
        decimal decReturnValue = 0;
        try
        {
            if ((QDesign.NULL(rdrR070BTP.GetNumber("CLMHDR_DOC_DEPT")) == QDesign.NULL(2d))) {
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
    
    private decimal X_DEPT3() {
        decimal decReturnValue = 0;
        try
        {
            if ((QDesign.NULL(rdrR070BTP.GetNumber("CLMHDR_DOC_DEPT")) == QDesign.NULL(3d))) {
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
    
    private decimal X_DEPT4() {
        decimal decReturnValue = 0;
        try
        {
            if ((QDesign.NULL(rdrR070BTP.GetNumber("CLMHDR_DOC_DEPT")) == QDesign.NULL(4d))) {
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
    
    private decimal X_DEPT5() {
        decimal decReturnValue = 0;
        try
        {
            if ((QDesign.NULL(rdrR070BTP.GetNumber("CLMHDR_DOC_DEPT")) == QDesign.NULL(5d))) {
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
    
    private decimal X_DEPT6() {
        decimal decReturnValue = 0;
        try
        {
            if ((QDesign.NULL(rdrR070BTP.GetNumber("CLMHDR_DOC_DEPT")) == QDesign.NULL(6d))) {
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
    
    private decimal X_DEPT7() {
        decimal decReturnValue = 0;
        try
        {
            if ((QDesign.NULL(rdrR070BTP.GetNumber("CLMHDR_DOC_DEPT")) == QDesign.NULL(7d))) {
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
    
    private decimal X_DEPT8() {
        decimal decReturnValue = 0;
        try
        {
            if ((QDesign.NULL(rdrR070BTP.GetNumber("CLMHDR_DOC_DEPT")) == QDesign.NULL(8d))) {
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
    
    private decimal X_DEPT9() {
        decimal decReturnValue = 0;
        try
        {
            if ((QDesign.NULL(rdrR070BTP.GetNumber("CLMHDR_DOC_DEPT")) == QDesign.NULL(9d))) {
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
    
    private decimal X_DEPT10() {
        decimal decReturnValue = 0;
        try
        {
            if ((QDesign.NULL(rdrR070BTP.GetNumber("CLMHDR_DOC_DEPT")) == QDesign.NULL(10d))) {
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
    
    private decimal X_DEPT11() {
        decimal decReturnValue = 0;
        try
        {
            if ((QDesign.NULL(rdrR070BTP.GetNumber("CLMHDR_DOC_DEPT")) == QDesign.NULL(11d))) {
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
    
    private decimal X_DEPT12() {
        decimal decReturnValue = 0;
        try
        {
            if ((QDesign.NULL(rdrR070BTP.GetNumber("CLMHDR_DOC_DEPT")) == QDesign.NULL(12d))) {
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
    
    private decimal X_DEPT13() {
        decimal decReturnValue = 0;
        try
        {
            if ((QDesign.NULL(rdrR070BTP.GetNumber("CLMHDR_DOC_DEPT")) == QDesign.NULL(13d))) {
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
    
    private decimal X_AGENT_SUB_0() {
        decimal decReturnValue = 0;
        try
        {
            if (((QDesign.NULL(rdrR070BTP.GetNumber("X_SUB_NBR")) == QDesign.NULL(0d)) 
                        && (QDesign.NULL(rdrR070BTP.GetNumber("CLMHDR_AGENT_CD")) == QDesign.NULL(6d)))) {
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
    
    private decimal X_AGENT_SUB_1() {
        decimal decReturnValue = 0;
        try
        {
            if (((QDesign.NULL(rdrR070BTP.GetNumber("X_SUB_NBR")) == QDesign.NULL(1d)) 
                        && (QDesign.NULL(rdrR070BTP.GetNumber("CLMHDR_AGENT_CD")) == QDesign.NULL(6d)))) {
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
    
    private decimal X_AGENT_SUB_2() {
        decimal decReturnValue = 0;
        try
        {
            if (((QDesign.NULL(rdrR070BTP.GetNumber("X_SUB_NBR")) == QDesign.NULL(2d)) 
                        && (QDesign.NULL(rdrR070BTP.GetNumber("CLMHDR_AGENT_CD")) == QDesign.NULL(6d)))) {
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
    
    private decimal X_AGENT_SUB_3() {
        decimal decReturnValue = 0;
        try
        {
            if (((QDesign.NULL(rdrR070BTP.GetNumber("X_SUB_NBR")) == QDesign.NULL(3d)) 
                        && (QDesign.NULL(rdrR070BTP.GetNumber("CLMHDR_AGENT_CD")) == QDesign.NULL(6d)))) {
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
    
    private string X_HEADING_SORT_RECORD() {
        string strReturnValue = String.Empty;
        try
        {
            if ((QDesign.NULL(rdrR070BTP.GetString("X_SORT_RECORD_STATUS")) == QDesign.NULL("0"))) {
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
    
    private decimal X_INCL_TECH_00() {
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
    
    private decimal X_INCL_TECH_30() {
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
    
    private decimal X_INCL_TECH_60() {
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
    
    private decimal X_INCL_TECH_90() {
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
    
    private decimal X_INCL_TECH_120() {
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
    
    private decimal X_INCL_PROF_00() {
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
    
    private decimal X_INCL_PROF_30() {
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
    
    private decimal X_INCL_PROF_60() {
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
    
    private decimal X_INCL_PROF_90() {
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
    
    private decimal X_INCL_PROF_120() {
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
    
    private decimal X_INCL_BALANCE_00() {
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
    
    private decimal X_INCL_BALANCE_30() {
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
    
    private decimal X_INCL_BALANCE_60() {
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
    
    private decimal X_INCL_BALANCE_90() {
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
    
    private decimal X_INCL_BALANCE_120() {
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
    
    private decimal X_INCL_NBR_00() {
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
    
    private decimal X_INCL_NBR_30() {
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
    
    private decimal X_INCL_NBR_60() {
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
    
    private decimal X_INCL_NBR_90() {
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
    
    private decimal X_INCL_NBR_120() {
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
    
    private decimal X_INCL_NBR_TOT() {
        decimal decReturnValue = 0;
        try
        {
            decReturnValue = (X_INCL_NBR_00()
                        + (X_INCL_NBR_30()
                        + (X_INCL_NBR_60()
                        + (X_INCL_NBR_90() + X_INCL_NBR_120()))));
        }

        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
        
        return decReturnValue;
    }
    
    private decimal X_INCL_TECH_TOT() {
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
    
    private decimal X_INCL_PROF_TOT() {
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
    
    private decimal X_INCL_BALANCE_TOT() {
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
    
    private string X_REF() {
        string strReturnValue = String.Empty;
        try
        {
            strReturnValue = QDesign.Substring(rdrR070BTP.GetString("CLMHDR_REFERENCE"), 1, 9);
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
 AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.R070BTP.X_CLINIC", DataTypes.Numeric, 2);
 AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.R070BTP.ICONST_DATE_PERIOD_END", DataTypes.Numeric, 8);
 AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.R070BTP.ICONST_CLINIC_NAME", DataTypes.Character, 20);
 AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.R070BTP.ICONST_CLINIC_NBR", DataTypes.Character, 4);
 AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.R070BTP.CLMHDR_AGENT_CD", DataTypes.Numeric, 1);
 AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R070BTP.CLMHDR_PAT_ACRONYM", DataTypes.Character, 9);
 AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R070BTP.X_PAT_ID_INFO", DataTypes.Character, 12);
 AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R070BTP.X_CLM_ID", DataTypes.Character, 10);
 AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R070BTP.CLMHDR_AMT_TECH_BILLED", DataTypes.Numeric, 6);
 AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R070BTP.CLMHDR_AMT_TECH_PAID", DataTypes.Numeric, 6);
 AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R070BTP.X_TECH_DUE", DataTypes.Numeric, 6);
 AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R070BTP.X_PROF_BILL", DataTypes.Numeric, 7);
 AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R070BTP.X_PROF_PAID", DataTypes.Numeric, 7);
 AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R070BTP.X_PROF_DUE", DataTypes.Numeric, 7);
 AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R070BTP.X_BALANCE_DUE", DataTypes.Numeric, 7);
 AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R070BTP.CLMHDR_DATE_PERIOD_END", DataTypes.Numeric, 8);
 AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R070BTP.CLMDTL_SV_DATE", DataTypes.Numeric, 8);
 AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R070BTP.X_DAY_OLD", DataTypes.Character, 3);
 AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R070BTP.CLMHDR_ORIG_BATCH_NBR", DataTypes.Character, 8);
 AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R070BTP.CLMHDR_REFERENCE", DataTypes.Character, 11);
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
 AddControl(ReportSection.FOOTING_AT, "X_DEPT1", DataTypes.Numeric, 7);
 AddControl(ReportSection.FOOTING_AT, "X_DEPT2", DataTypes.Numeric, 7);
 AddControl(ReportSection.FOOTING_AT, "X_DEPT3", DataTypes.Numeric, 7);
 AddControl(ReportSection.FOOTING_AT, "X_DEPT4", DataTypes.Numeric, 7);
 AddControl(ReportSection.FOOTING_AT, "X_DEPT5", DataTypes.Numeric, 7);
 AddControl(ReportSection.FOOTING_AT, "X_DEPT6", DataTypes.Numeric, 7);
 AddControl(ReportSection.FOOTING_AT, "X_DEPT7", DataTypes.Numeric, 7);
 AddControl(ReportSection.FOOTING_AT, "X_DEPT8", DataTypes.Numeric, 7);
 AddControl(ReportSection.FOOTING_AT, "X_DEPT9", DataTypes.Numeric, 7);
 AddControl(ReportSection.FOOTING_AT, "X_DEPT10", DataTypes.Numeric, 7);
 AddControl(ReportSection.FOOTING_AT, "X_DEPT11", DataTypes.Numeric, 7);
 AddControl(ReportSection.FOOTING_AT, "X_DEPT12", DataTypes.Numeric, 7);
 AddControl(ReportSection.FOOTING_AT, "X_DEPT13", DataTypes.Numeric, 7);
 AddControl(ReportSection.FOOTING_AT, "X_AGENT_SUB_0", DataTypes.Numeric, 7);
 AddControl(ReportSection.FOOTING_AT, "X_AGENT_SUB_1", DataTypes.Numeric, 7);
 AddControl(ReportSection.FOOTING_AT, "X_AGENT_SUB_2", DataTypes.Numeric, 7);
 AddControl(ReportSection.FOOTING_AT, "X_AGENT_SUB_3", DataTypes.Numeric, 7);
 AddControl(ReportSection.FOOTING_AT, "X_HEADING_SORT_RECORD", DataTypes.Character, 27);
 AddControl(ReportSection.FOOTING_AT, "X_INCL_TECH_00", DataTypes.Numeric, 7);
 AddControl(ReportSection.FOOTING_AT, "X_INCL_PROF_00", DataTypes.Numeric, 7);
 AddControl(ReportSection.FOOTING_AT, "X_INCL_BALANCE_00", DataTypes.Numeric, 7);
 AddControl(ReportSection.FOOTING_AT, "X_INCL_NBR_00", DataTypes.Numeric, 6);
 AddControl(ReportSection.FOOTING_AT, "X_INCL_TECH_30", DataTypes.Numeric, 7);
 AddControl(ReportSection.FOOTING_AT, "X_INCL_PROF_30", DataTypes.Numeric, 7);
 AddControl(ReportSection.FOOTING_AT, "X_INCL_BALANCE_30", DataTypes.Numeric, 7);
 AddControl(ReportSection.FOOTING_AT, "X_INCL_NBR_30", DataTypes.Numeric, 6);
 AddControl(ReportSection.FOOTING_AT, "X_INCL_TECH_60", DataTypes.Numeric, 7);
 AddControl(ReportSection.FOOTING_AT, "X_INCL_PROF_60", DataTypes.Numeric, 7);
 AddControl(ReportSection.FOOTING_AT, "X_INCL_BALANCE_60", DataTypes.Numeric, 7);
 AddControl(ReportSection.FOOTING_AT, "X_INCL_NBR_60", DataTypes.Numeric, 6);
 AddControl(ReportSection.FOOTING_AT, "X_INCL_TECH_90", DataTypes.Numeric, 7);
 AddControl(ReportSection.FOOTING_AT, "X_INCL_PROF_90", DataTypes.Numeric, 7);
 AddControl(ReportSection.FOOTING_AT, "X_INCL_BALANCE_90", DataTypes.Numeric, 7);
 AddControl(ReportSection.FOOTING_AT, "X_INCL_NBR_90", DataTypes.Numeric, 6);
 AddControl(ReportSection.FOOTING_AT, "X_INCL_TECH_120", DataTypes.Numeric, 7);
 AddControl(ReportSection.FOOTING_AT, "X_INCL_PROF_120", DataTypes.Numeric, 7);
 AddControl(ReportSection.FOOTING_AT, "X_INCL_BALANCE_120", DataTypes.Numeric, 7);
 AddControl(ReportSection.FOOTING_AT, "X_INCL_NBR_120", DataTypes.Numeric, 6);
 AddControl(ReportSection.FOOTING_AT, "X_INCL_TECH_TOT", DataTypes.Numeric, 7);
 AddControl(ReportSection.FOOTING_AT, "X_INCL_PROF_TOT", DataTypes.Numeric, 7);
 AddControl(ReportSection.FOOTING_AT, "X_INCL_BALANCE_TOT", DataTypes.Numeric, 7);
 AddControl(ReportSection.FOOTING_AT, "X_INCL_NBR_TOT", DataTypes.Numeric, 6);
 AddControl(ReportSection.REPORT, "TEMPORARYDATA.R070BTP.X_SORT_RECORD_STATUS", DataTypes.Character, 1);
 AddControl(ReportSection.REPORT, "TEMPORARYDATA.R070BTP.X_AGE_CATEGORY", DataTypes.Character, 1);
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
            case "TEMPORARYDATA.R070BTP.X_CLINIC":
                return rdrR070BTP.GetNumber("X_CLINIC").ToString();
            case "TEMPORARYDATA.R070BTP.ICONST_DATE_PERIOD_END":
                return rdrR070BTP.GetNumber("ICONST_DATE_PERIOD_END").ToString();
            case "TEMPORARYDATA.R070BTP.ICONST_CLINIC_NAME":
                return Common.StringToField(rdrR070BTP.GetString("ICONST_CLINIC_NAME"));
            case "TEMPORARYDATA.R070BTP.ICONST_CLINIC_NBR":
                return Common.StringToField(rdrR070BTP.GetString("ICONST_CLINIC_NBR"));
            case "TEMPORARYDATA.R070BTP.CLMHDR_AGENT_CD":
                return rdrR070BTP.GetNumber("CLMHDR_AGENT_CD").ToString();
            case "TEMPORARYDATA.R070BTP.CLMHDR_PAT_ACRONYM":
                return Common.StringToField(rdrR070BTP.GetString("CLMHDR_PAT_ACRONYM"));
            case "TEMPORARYDATA.R070BTP.X_PAT_ID_INFO":
                return Common.StringToField(rdrR070BTP.GetString("X_PAT_ID_INFO"));
            case "TEMPORARYDATA.R070BTP.X_CLM_ID":
                return Common.StringToField(rdrR070BTP.GetString("X_CLM_ID"));
            case "TEMPORARYDATA.R070BTP.CLMHDR_AMT_TECH_BILLED":
                return rdrR070BTP.GetNumber("CLMHDR_AMT_TECH_BILLED").ToString();
            case "TEMPORARYDATA.R070BTP.CLMHDR_AMT_TECH_PAID":
                return rdrR070BTP.GetNumber("CLMHDR_AMT_TECH_PAID").ToString();
            case "TEMPORARYDATA.R070BTP.X_TECH_DUE":
                return rdrR070BTP.GetNumber("X_TECH_DUE").ToString();
            case "TEMPORARYDATA.R070BTP.X_PROF_BILL":
                return rdrR070BTP.GetNumber("X_PROF_BILL").ToString();
            case "TEMPORARYDATA.R070BTP.X_PROF_PAID":
                return rdrR070BTP.GetNumber("X_PROF_PAID").ToString();
            case "TEMPORARYDATA.R070BTP.X_PROF_DUE":
                return rdrR070BTP.GetNumber("X_PROF_DUE").ToString();
            case "TEMPORARYDATA.R070BTP.X_BALANCE_DUE":
                return rdrR070BTP.GetNumber("X_BALANCE_DUE").ToString();
            case "TEMPORARYDATA.R070BTP.CLMHDR_DATE_PERIOD_END":
                return rdrR070BTP.GetNumber("CLMHDR_DATE_PERIOD_END").ToString();
            case "TEMPORARYDATA.R070BTP.CLMDTL_SV_DATE":
                return rdrR070BTP.GetNumber("CLMDTL_SV_DATE").ToString();
            case "TEMPORARYDATA.R070BTP.X_DAY_OLD":
                return Common.StringToField(rdrR070BTP.GetString("X_DAY_OLD"));
            case "TEMPORARYDATA.R070BTP.CLMHDR_ORIG_BATCH_NBR":
                return Common.StringToField(rdrR070BTP.GetString("CLMHDR_ORIG_BATCH_NBR"));
            case "TEMPORARYDATA.R070BTP.CLMHDR_REFERENCE":
                return Common.StringToField(rdrR070BTP.GetString("CLMHDR_REFERENCE"));
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
            case "X_DEPT1":
                return X_DEPT1().ToString();
            case "X_DEPT2":
                return X_DEPT2().ToString();
            case "X_DEPT3":
                return X_DEPT3().ToString();
            case "X_DEPT4":
                return X_DEPT4().ToString();
            case "X_DEPT5":
                return X_DEPT5().ToString();
            case "X_DEPT6":
                return X_DEPT6().ToString();
            case "X_DEPT7":
                return X_DEPT7().ToString();
            case "X_DEPT8":
                return X_DEPT8().ToString();
            case "X_DEPT9":
                return X_DEPT9().ToString();
            case "X_DEPT10":
                return X_DEPT10().ToString();
            case "X_DEPT11":
                return X_DEPT11().ToString();
            case "X_DEPT12":
                return X_DEPT12().ToString();
            case "X_DEPT13":
                return X_DEPT13().ToString();
            case "X_AGENT_SUB_0":
                return X_AGENT_SUB_0().ToString();
            case "X_AGENT_SUB_1":
                return X_AGENT_SUB_1().ToString();
            case "X_AGENT_SUB_2":
                return X_AGENT_SUB_2().ToString();
            case "X_AGENT_SUB_3":
                return X_AGENT_SUB_3().ToString();
            case "X_HEADING_SORT_RECORD":
                return Common.StringToField(X_HEADING_SORT_RECORD());
            case "X_INCL_TECH_00":
                return X_INCL_TECH_00().ToString();
            case "X_INCL_PROF_00":
                return X_INCL_PROF_00().ToString();
            case "X_INCL_BALANCE_00":
                return X_INCL_BALANCE_00().ToString();
            case "X_INCL_NBR_00":
                return X_INCL_NBR_00().ToString();
            case "X_INCL_TECH_30":
                return X_INCL_TECH_30().ToString();
            case "X_INCL_PROF_30":
                return X_INCL_PROF_30().ToString();
            case "X_INCL_BALANCE_30":
                return X_INCL_BALANCE_30().ToString();
            case "X_INCL_NBR_30":
                return X_INCL_NBR_30().ToString();
            case "X_INCL_TECH_60":
                return X_INCL_TECH_60().ToString();
            case "X_INCL_PROF_60":
                return X_INCL_PROF_60().ToString();
            case "X_INCL_BALANCE_60":
                return X_INCL_BALANCE_60().ToString();
            case "X_INCL_NBR_60":
                return X_INCL_NBR_60().ToString();
            case "X_INCL_TECH_90":
                return X_INCL_TECH_90().ToString();
            case "X_INCL_PROF_90":
                return X_INCL_PROF_90().ToString();
            case "X_INCL_BALANCE_90":
                return X_INCL_BALANCE_90().ToString();
            case "X_INCL_NBR_90":
                return X_INCL_NBR_90().ToString();
            case "X_INCL_TECH_120":
                return X_INCL_TECH_120().ToString();
            case "X_INCL_PROF_120":
                return X_INCL_PROF_120().ToString();
            case "X_INCL_BALANCE_120":
                return X_INCL_BALANCE_120().ToString();
            case "X_INCL_NBR_120":
                return X_INCL_NBR_120().ToString();
            case "X_INCL_TECH_TOT":
                return X_INCL_TECH_TOT().ToString();
            case "X_INCL_PROF_TOT":
                return X_INCL_PROF_TOT().ToString();
            case "X_INCL_BALANCE_TOT":
                return X_INCL_BALANCE_TOT().ToString();
            case "X_INCL_NBR_TOT":
                return X_INCL_NBR_TOT().ToString();
            case "TEMPORARYDATA.R070BTP.X_SORT_RECORD_STATUS":
                return Common.StringToField(rdrR070BTP.GetString("X_SORT_RECORD_STATUS"));
            case "TEMPORARYDATA.R070BTP.X_AGE_CATEGORY":
                return Common.StringToField(rdrR070BTP.GetString("X_AGE_CATEGORY"));
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
