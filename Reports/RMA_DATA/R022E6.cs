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
    public class R022E6 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R022E6";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrU022E3 = new Reader();
        private Reader rdrICONST_MSTR_REC = new Reader();

        #endregion

        #region " Renaissance Data "

        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                //  Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;
                Sort = "ICONST_CLINIC_NBR_1_2 ASC, W_BATCH_TYPE ASC, W_ADJ_CODE ASC, W_AGENT ASC";
                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return ReportData;
        }

        #endregion

        #region " Renaissance Statements "

        #region " ACCESS "

        private void Access_U022E3()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("ICONST_CLINIC_NBR_1_2, ");
            strSQL.Append("W_BATCH_TYPE, ");
            strSQL.Append("BATCTRL_ADJ_CD, ");
            strSQL.Append("W_AGENT, ");
            strSQL.Append("BATCTRL_CALC_AR_DUE, ");
            strSQL.Append("BATCTRL_CALC_TOT_REV, ");
            strSQL.Append("W_BATCTRL_MANUAL_PAY_TOT, ");
            strSQL.Append("BATCTRL_NBR_CLAIMS_IN_BATCH, ");
            strSQL.Append("ICONST_CLINIC_CYCLE_NBR, ");
            strSQL.Append("ICONST_DATE_PERIOD_END ");
            strSQL.Append("FROM TEMPORARYDATA.U022E3 ");

            strSQL.Append(Choose());

            rdrU022E3.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
            strSQL = null;
        }
        private void Link_ICONST_MSTR_REC() {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("ICONST_CLINIC_NBR_1_2, ");
            strSQL.Append("ICONST_CLINIC_NAME ");
            strSQL.Append("FROM INDEXED.ICONST_MSTR_REC ");
            strSQL.Append("WHERE ");
            strSQL.Append("ICONST_CLINIC_NBR_1_2 = ").Append(rdrU022E3.GetNumber("ICONST_CLINIC_NBR_1_2"));

            rdrICONST_MSTR_REC.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        #endregion

        #region " CHOOSE "

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(string.Empty);

            return strChoose.ToString();
        }

        #endregion

        #region " SELECT IF "

        #endregion

        #region " DEFINES "

        private string W_ADJ_CODE()
        {
            string strReturnValue = string.Empty;
            try
            {
                if ((QDesign.NULL(rdrU022E3.GetString("W_BATCH_TYPE")) == "A"))
                {
                    strReturnValue = " ";
                }
                else
                {
                    strReturnValue = rdrU022E3.GetString("BATCTRL_ADJ_CD");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return strReturnValue;
        }
    
        private string W_ADJ_AGENT()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = (W_ADJ_CODE() + rdrU022E3.GetString("W_AGENT"));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return strReturnValue;
        }
    
        private string W_CLAIM_TYPE()
        {
            string strReturnValue = string.Empty;
            try
            {
                if ((QDesign.NULL(rdrU022E3.GetString("W_BATCH_TYPE")) == "A"))
                {
                    strReturnValue = "CLAIMS";
                }
                else if ((QDesign.NULL(rdrU022E3.GetString("W_BATCH_TYPE")) == "B")) 
                {
                    strReturnValue = "ADJUSTMENTS";
                }
                else if ((QDesign.NULL(rdrU022E3.GetString("W_BATCH_TYPE")) == "P")) 
                {
                    strReturnValue = "PAYMENTS";
                }
                else if ((QDesign.NULL(rdrU022E3.GetString("W_BATCH_TYPE")) == "Z")) 
                {
                    strReturnValue = "GRAND TOTALS";
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return strReturnValue;
        }
    
        private decimal W_BATCTRL_CALC_AR_DUE()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrU022E3.GetString("W_BATCH_TYPE")) != "Z"))
                {
                    decReturnValue = rdrU022E3.GetNumber("BATCTRL_CALC_AR_DUE");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return decReturnValue;
        }
    
        private decimal W_BATCTRL_CALC_TOT_REV()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrU022E3.GetString("W_BATCH_TYPE")) != "Z"))
                {
                    decReturnValue = rdrU022E3.GetNumber("BATCTRL_CALC_TOT_REV");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return decReturnValue;
        }
    
        private decimal W_W_BATCTRL_MANUAL_PAY_TOT()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrU022E3.GetString("W_BATCH_TYPE")) != "Z")) {
                    decReturnValue = rdrU022E3.GetNumber("W_BATCTRL_MANUAL_PAY_TOT");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return decReturnValue;
        }
    
        private decimal W_BATCTRL_NBR_CLAIMS_IN_BATCH()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrU022E3.GetString("W_BATCH_TYPE")) != "Z"))
                {
                    decReturnValue = rdrU022E3.GetNumber("BATCTRL_NBR_CLAIMS_IN_BATCH");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return decReturnValue;
        }
    
        private string W_TYPE_NAME()
        {
            string strReturnValue = string.Empty;
            try
            {
                if (((QDesign.NULL(rdrU022E3.GetString("W_BATCH_TYPE")) == "B") 
                            || (QDesign.NULL(rdrU022E3.GetString("W_BATCH_TYPE")) == "P")))
                {
                    strReturnValue = rdrU022E3.GetString("BATCTRL_ADJ_CD");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
        return strReturnValue;
    }

        #endregion

        #region " CONTROLS "

        public override void DeclareReportControls()
        {
            try
            {
                 AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.U022E3.ICONST_CLINIC_NBR_1_2", DataTypes.Numeric, 2);
                 AddControl(ReportSection.PAGE_HEADING, "INDEXED.ICONST_MSTR_REC.ICONST_CLINIC_NAME", DataTypes.Character, 20);
                 AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.U022E3.ICONST_CLINIC_CYCLE_NBR", DataTypes.Numeric, 2);
                 AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.U022E3.ICONST_DATE_PERIOD_END", DataTypes.Numeric, 8);
                 AddControl(ReportSection.FOOTING_AT, "W_CLAIM_TYPE", DataTypes.Character, 14);
                 AddControl(ReportSection.FOOTING_AT, "W_TYPE_NAME", DataTypes.Character, 1);
                 AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.U022E3.W_AGENT", DataTypes.Character, 1);
                 AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.U022E3.BATCTRL_CALC_AR_DUE", DataTypes.Numeric, 9);
                 AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.U022E3.BATCTRL_CALC_TOT_REV", DataTypes.Numeric, 9);
                 AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.U022E3.W_BATCTRL_MANUAL_PAY_TOT", DataTypes.Numeric, 9);
                 AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.U022E3.BATCTRL_NBR_CLAIMS_IN_BATCH", DataTypes.Numeric, 5);
                 AddControl(ReportSection.FINAL_FOOTING, "W_BATCTRL_CALC_AR_DUE", DataTypes.Numeric, 9);
                 AddControl(ReportSection.FINAL_FOOTING, "W_BATCTRL_CALC_TOT_REV", DataTypes.Numeric, 9);
                 AddControl(ReportSection.FINAL_FOOTING, "W_W_BATCTRL_MANUAL_PAY_TOT", DataTypes.Numeric, 9);
                 AddControl(ReportSection.FINAL_FOOTING, "W_BATCTRL_NBR_CLAIMS_IN_BATCH", DataTypes.Numeric, 6);
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.U022E3.W_BATCH_TYPE", DataTypes.Character, 1);
                 AddControl(ReportSection.REPORT, "W_ADJ_CODE", DataTypes.Character, 1);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        #endregion

        #region " Renaissance Precompiler Generated Code "

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-05-11 7:47:42 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "TEMPORARYDATA.U022E3.ICONST_CLINIC_NBR_1_2":
                    return rdrU022E3.GetNumber("ICONST_CLINIC_NBR_1_2").ToString();
                case "INDEXED.ICONST_MSTR_REC.ICONST_CLINIC_NAME":
                    return Common.StringToField(rdrICONST_MSTR_REC.GetString("ICONST_CLINIC_NAME"));
                case "TEMPORARYDATA.U022E3.ICONST_CLINIC_CYCLE_NBR":
                    return rdrU022E3.GetNumber("ICONST_CLINIC_CYCLE_NBR").ToString();
                case "TEMPORARYDATA.U022E3.ICONST_DATE_PERIOD_END":
                    return rdrU022E3.GetNumber("ICONST_DATE_PERIOD_END").ToString();
                case "W_CLAIM_TYPE":
                    return Common.StringToField(W_CLAIM_TYPE(), intSize);
                case "W_TYPE_NAME":
                    return Common.StringToField(W_TYPE_NAME(), intSize);
                case "TEMPORARYDATA.U022E3.W_AGENT":
                    return Common.StringToField(rdrU022E3.GetString("W_AGENT"));
                case "TEMPORARYDATA.U022E3.BATCTRL_CALC_AR_DUE":
                    return rdrU022E3.GetNumber("BATCTRL_CALC_AR_DUE").ToString();
                case "TEMPORARYDATA.U022E3.BATCTRL_CALC_TOT_REV":
                    return rdrU022E3.GetNumber("BATCTRL_CALC_TOT_REV").ToString();
                case "TEMPORARYDATA.U022E3.W_BATCTRL_MANUAL_PAY_TOT":
                    return rdrU022E3.GetNumber("W_BATCTRL_MANUAL_PAY_TOT").ToString();
                case "TEMPORARYDATA.U022E3.BATCTRL_NBR_CLAIMS_IN_BATCH":
                    return rdrU022E3.GetNumber("BATCTRL_NBR_CLAIMS_IN_BATCH").ToString();
                case "W_BATCTRL_CALC_AR_DUE":
                    return W_BATCTRL_CALC_AR_DUE().ToString();
                case "W_BATCTRL_CALC_TOT_REV":
                    return W_BATCTRL_CALC_TOT_REV().ToString();
                case "W_W_BATCTRL_MANUAL_PAY_TOT":
                    return W_W_BATCTRL_MANUAL_PAY_TOT().ToString();
                case "W_BATCTRL_NBR_CLAIMS_IN_BATCH":
                    return W_BATCTRL_NBR_CLAIMS_IN_BATCH().ToString();
                case "TEMPORARYDATA.U022E3.W_BATCH_TYPE":
                    return Common.StringToField(rdrU022E3.GetString("W_BATCH_TYPE"));
                case "W_ADJ_CODE":
                    return Common.StringToField(W_ADJ_CODE(), intSize);
                default:
                    return string.Empty;
            }
        }
    public override void AccessData() {
        try
        {
            // TODO: Some manual steps maybe required.
            Access_U022E3();
            while (rdrU022E3.Read()) {
                Link_ICONST_MSTR_REC();
                while (rdrICONST_MSTR_REC.Read()) {
                    WriteData();
                }
                
                    rdrICONST_MSTR_REC.Close();
                }
            
                rdrU022E3.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrU022E3 == null))
            {
                rdrU022E3.Close();
                rdrU022E3 = null;
            }
        
            if (!(rdrICONST_MSTR_REC == null))
            {
                rdrICONST_MSTR_REC.Close();
                rdrICONST_MSTR_REC = null;
            }
        }

        #endregion

        #endregion
    }
}
