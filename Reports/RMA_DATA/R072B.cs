//  2004/01/08 - MC
//  !        link (nconv(ascii(clmhdr-batch-nbr)[1:2]))  &
//  2004/01/08 - end
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
public class R072B : BaseRDLClass {
    protected const string REPORT_NAME = "R072B";
    protected const bool REPORT_HAS_PARAMETERS = true;
    private Reader rdrU072_DELETE_CLAIM_HDR = new Reader();
    private Reader rdrICONST_MSTR_REC = new Reader();
    private Reader rdrU072_PURGE_VALIDATE = new Reader();
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
            SubFileName = "U072_DELETE_CLAIM_HDR";
            SubFileType = SubFileType.Temp;
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
    private void Access_U072_DELETE_CLAIM_HDR() {
        StringBuilder strSQL = new StringBuilder(String.Empty);
        // TODO: If * is not used to select all columns, ensure the necessary columns (i.e. columns that are used to access records of other tables) are included in the SELECT statement
        strSQL.Append("SELECT ");
        strSQL.Append("CLMHDR_BATCH_NBR, ");
        strSQL.Append("CLMHDR_TOT_CLAIM_AR_OMA, ");
        strSQL.Append("CLMHDR_TOT_CLAIM_AR_OHIP, ");
        strSQL.Append("CLMHDR_MANUAL_AND_TAPE_PAYMENTS, ");
        strSQL.Append("CLMHDR_BATCH_TYPE, ");
        strSQL.Append("CLMHDR_ADJ_CD, ");
        strSQL.Append("CLMHDR_AGENT_CD, ");
        strSQL.Append("CLMHDR_CYCLE_NBR ");
        strSQL.Append("FROM TEMPORARYDATA.U072_DELETE_CLAIM_HDR ");
        strSQL.Append(Choose());
        rdrU072_DELETE_CLAIM_HDR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
        strSQL = null;
    }
    private void Link_ICONST_MSTR_REC() {
        StringBuilder strSQL = new StringBuilder(String.Empty);
        // TODO: Check the 'WHERE' and 'AND' clauses are correct.
        strSQL.Append("SELECT ");
        strSQL.Append("ICONST_CLINIC_NBR_1_2, ");
        strSQL.Append("ICONST_DATE_PERIOD_END_YY, ");
        strSQL.Append(" ICONST_DATE_PERIOD_END_MM, ");
        strSQL.Append(" ICONST_DATE_PERIOD_END_DD, ");
        strSQL.Append("ICONST_CLINIC_CYCLE_NBR ");
        strSQL.Append("FROM INDEXED.ICONST_MSTR_REC ");
        strSQL.Append("WHERE ");
        strSQL.Append("ICONST_CLINIC_NBR_1_2 = ").Append(QDesign.NConvert(QDesign.Substring(rdrU072_DELETE_CLAIM_HDR.GetString("CLMHDR_BATCH_NBR"), 1, 2)));
        rdrICONST_MSTR_REC.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
        strSQL = null;
    }
    
    private string Choose() {
        StringBuilder strChoose = new StringBuilder(String.Empty);
        // TODO: CHOOSE Statement - May require manual changes.
        return strChoose.ToString().ToString();
    }
    
    public override bool SelectIf() {
        bool blnSelected = false;
        if ((QDesign.NULL(D_ICONST_CLINIC_NBR_1_2()) == QDesign.NULL(D_CLINIC_SEL()))) {
            blnSelected = true;
        }
        
        return blnSelected;
    }
    
    private decimal D_CLINIC() {
        decimal decReturnValue = 0;
        try
        {
            decReturnValue = QDesign.NConvert(QDesign.Substring(QDesign.ASCII(rdrICONST_MSTR_REC.GetNumber("ICONST_CLINIC_NBR_1_2")), 1, 1));
        }

        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
        
        return decReturnValue;
    }
    
    private decimal D_ICONST_CLINIC_NBR_1_2() {
        decimal decReturnValue = 0;
        try
        {
            decReturnValue = rdrICONST_MSTR_REC.GetNumber("ICONST_CLINIC_NBR_1_2");
        }

        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
        
        return decReturnValue;
    }
    
    private decimal D_CLINIC_SEL() {
        decimal decReturnValue = 0;
        try
        {
            if ((ReportFunctions.astrScreenParameters[0].ToString().Trim() != String.Empty)) {
                decReturnValue = Decimal.Parse(ReportFunctions.astrScreenParameters[0].ToString());
            }
            else
            {
            }
        }

        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
        
        return decReturnValue;
    }
    
    private decimal D_RETAIN_COUNT() {
        decimal decReturnValue = 0m;
        try
        {
            decReturnValue = 1m;
        }

        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
        
        return decReturnValue;
    }
    
    private decimal D_DELETE_COUNT() {
        decimal decReturnValue = 0;
        try
        {
            decReturnValue = 0;
        }

        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
        
        return decReturnValue;
    }
    
    private decimal R_CLMHDR_TOT_CLAIM_AR_OMA() {
        decimal decReturnValue = 0;
        try
        {
            decReturnValue = 0;
        }
        
        
        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
        
        return decReturnValue;
    }
    
    private decimal R_CLMHDR_TOT_CLAIM_AR_OHIP() {
        decimal decReturnValue = 0;
        try
        {
            decReturnValue = 0;
        }
        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
        
        return decReturnValue;
    }
    
    private decimal R_CLMHDR_MANUAL_AND_TAPE_PAYMENTS() {
        decimal decReturnValue = 0;
        try
        {
            decReturnValue = 0;
        }

        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
        
        return decReturnValue;
    }
    
    private decimal D_CLMHDR_TOT_CLAIM_AR_OMA() {
        decimal decReturnValue = 0;
        try
        {
            decReturnValue = rdrU072_DELETE_CLAIM_HDR.GetNumber("CLMHDR_TOT_CLAIM_AR_OMA");
        }

        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
        
        return decReturnValue;
    }
    
    private decimal D_CLMHDR_TOT_CLAIM_AR_OHIP() {
        decimal decReturnValue = 0;
        try
        {
            decReturnValue = rdrU072_DELETE_CLAIM_HDR.GetNumber("CLMHDR_TOT_CLAIM_AR_OHIP");
        }

        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
        
        return decReturnValue;
    }
    
    private decimal D_CLMHDR_MANUAL_AND_TAPE_PAYMENTS() {
        decimal decReturnValue = 0;
        try
        {
            decReturnValue = rdrU072_DELETE_CLAIM_HDR.GetNumber("CLMHDR_MANUAL_AND_TAPE_PAYMENTS");
        }

        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
        
        return decReturnValue;
    }
    
    private decimal D_BATCH_TYPE() {
        decimal decReturnValue = 0;
        try
        {
            if ((QDesign.NULL(rdrU072_DELETE_CLAIM_HDR.GetString("CLMHDR_BATCH_TYPE")) == "C")) {
                decReturnValue = 1;
            }
            else if ((QDesign.NULL(rdrU072_DELETE_CLAIM_HDR.GetString("CLMHDR_BATCH_TYPE")) == "A")) 
            {
                decReturnValue = 2;
            }
            else
            {
                decReturnValue = 3;
            }
        }

        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
        
        return decReturnValue;
    }
    
    private string D_CLMHDR_ADJ_CD() {
        string strReturnValue = String.Empty;
        try
        {
            if ((QDesign.NULL(rdrU072_DELETE_CLAIM_HDR.GetString("CLMHDR_BATCH_TYPE")) == "C")) {
                strReturnValue = " ";
            }
            else
            {
                strReturnValue = rdrU072_DELETE_CLAIM_HDR.GetString("CLMHDR_ADJ_CD");
            }
        }

        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
        
        return strReturnValue;
    }
    
    private string D_TYPE() {
        string strReturnValue = String.Empty;
        try
        {
            if ((QDesign.NULL(rdrU072_DELETE_CLAIM_HDR.GetString("CLMHDR_BATCH_TYPE")) == "C")) {
                strReturnValue = "CLAIMS";
            }
            else if ((QDesign.NULL(rdrU072_DELETE_CLAIM_HDR.GetString("CLMHDR_BATCH_TYPE")) == "A")) 
            {
                strReturnValue = "ADJUSTMENTS";
            }
            else if ((QDesign.NULL(rdrU072_DELETE_CLAIM_HDR.GetString("CLMHDR_BATCH_TYPE")) == "P")) 
            {
                strReturnValue = "PAYMENTS";
            }
        }

        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
        
        return strReturnValue;
    }
    
    private string ICONST_MSTR_REC_ICONST_DATE_PERIOD_END() {
        string strReturnValue = String.Empty;
        try
        {
            strReturnValue = (rdrICONST_MSTR_REC.GetString("ICONST_DATE_PERIOD_END_YY") 
                        + (rdrICONST_MSTR_REC.GetString("ICONST_DATE_PERIOD_END_MM") + rdrICONST_MSTR_REC.GetString("ICONST_DATE_PERIOD_END_DD")));
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
            AddControl(ReportSection.SUMMARY, "D_ICONST_CLINIC_NBR_1_2", DataTypes.Numeric, 4);
            AddControl(ReportSection.SUMMARY, "ICONST_MSTR_REC_ICONST_DATE_PERIOD_END", DataTypes.Numeric, 8);
            AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U072_DELETE_CLAIM_HDR.X_PED_PURGE_PRIOR_TO_DATE", DataTypes.Character, 1);
            AddControl(ReportSection.SUMMARY, "INDEXED.ICONST_MSTR_REC.ICONST_CLINIC_CYCLE_NBR", DataTypes.Numeric, 2);
            AddControl(ReportSection.SUMMARY, "D_TYPE", DataTypes.Character, 11);
            AddControl(ReportSection.SUMMARY, "D_BATCH_TYPE", DataTypes.Numeric, 1);
            AddControl(ReportSection.SUMMARY, "D_RETAIN_COUNT", DataTypes.Numeric, 1);
            AddControl(ReportSection.SUMMARY, "D_DELETE_COUNT", DataTypes.Numeric, 1);
            AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U072_DELETE_CLAIM_HDR.CLMHDR_BATCH_TYPE", DataTypes.Character, 1);
            AddControl(ReportSection.SUMMARY, "D_CLMHDR_ADJ_CD", DataTypes.Character, 1);
            AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U072_DELETE_CLAIM_HDR.CLMHDR_AGENT_CD", DataTypes.Numeric, 1);
            AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U072_DELETE_CLAIM_HDR.CLMHDR_CYCLE_NBR", DataTypes.Numeric, 2);
            AddControl(ReportSection.SUMMARY, "D_CLMHDR_TOT_CLAIM_AR_OMA", DataTypes.Numeric, 7);
            AddControl(ReportSection.SUMMARY, "D_CLMHDR_TOT_CLAIM_AR_OHIP", DataTypes.Numeric, 7);
            AddControl(ReportSection.SUMMARY, "D_CLMHDR_MANUAL_AND_TAPE_PAYMENTS", DataTypes.Numeric, 7);
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
            case "D_ICONST_CLINIC_NBR_1_2":
                return D_ICONST_CLINIC_NBR_1_2().ToString();
            case "ICONST_MSTR_REC_ICONST_DATE_PERIOD_END":
                return ICONST_MSTR_REC_ICONST_DATE_PERIOD_END().ToString();
            case "TEMPORARYDATA.U072_DELETE_CLAIM_HDR.X_PED_PURGE_PRIOR_TO_DATE":
                return Common.StringToField(rdrU072_DELETE_CLAIM_HDR.GetString("X_PED_PURGE_PRIOR_TO_DATE"));
            case "INDEXED.ICONST_MSTR_REC.ICONST_CLINIC_CYCLE_NBR":
                return rdrICONST_MSTR_REC.GetNumber("ICONST_CLINIC_CYCLE_NBR").ToString();
            case "D_TYPE":
                return Common.StringToField(D_TYPE(), intSize);
            case "D_BATCH_TYPE":
                return D_BATCH_TYPE().ToString();
            case "D_RETAIN_COUNT":
                return D_RETAIN_COUNT().ToString();
            case "D_DELETE_COUNT":
                return D_DELETE_COUNT().ToString();
            case "TEMPORARYDATA.U072_DELETE_CLAIM_HDR.CLMHDR_BATCH_TYPE":
                return Common.StringToField(rdrU072_DELETE_CLAIM_HDR.GetString("CLMHDR_BATCH_TYPE"));
            case "D_CLMHDR_ADJ_CD":
                return Common.StringToField(D_CLMHDR_ADJ_CD(), intSize);
            case "TEMPORARYDATA.U072_DELETE_CLAIM_HDR.CLMHDR_AGENT_CD":
                return rdrU072_DELETE_CLAIM_HDR.GetNumber("CLMHDR_AGENT_CD").ToString();
            case "TEMPORARYDATA.U072_DELETE_CLAIM_HDR.CLMHDR_CYCLE_NBR":
                return rdrU072_DELETE_CLAIM_HDR.GetNumber("CLMHDR_CYCLE_NBR").ToString();
            case "D_CLMHDR_TOT_CLAIM_AR_OMA":
                return D_CLMHDR_TOT_CLAIM_AR_OMA().ToString();
            case "D_CLMHDR_TOT_CLAIM_AR_OHIP":
                return D_CLMHDR_TOT_CLAIM_AR_OHIP().ToString();
            case "D_CLMHDR_MANUAL_AND_TAPE_PAYMENTS":
                return D_CLMHDR_MANUAL_AND_TAPE_PAYMENTS().ToString();
            default:
                return String.Empty;
        }
    }
    
    public override void AccessData() {
        try
        {
            // TODO: Some manual steps maybe required.
            Access_U072_DELETE_CLAIM_HDR();
            while (rdrU072_DELETE_CLAIM_HDR.Read()) {
                Link_ICONST_MSTR_REC();
                while (rdrICONST_MSTR_REC.Read()) {
                    WriteData();
                }
                
                rdrICONST_MSTR_REC.Close();
            }
            
            rdrU072_DELETE_CLAIM_HDR.Close();
        }

        catch (Exception ex)
        {
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
    }
    
    public override void CloseReaders() {
        if (!(rdrU072_DELETE_CLAIM_HDR == null)) {
            rdrU072_DELETE_CLAIM_HDR.Close();
            rdrU072_DELETE_CLAIM_HDR = null;
        }
        
        if (!(rdrICONST_MSTR_REC == null)) {
            rdrICONST_MSTR_REC.Close();
            rdrICONST_MSTR_REC = null;
        }
    }
}
}
