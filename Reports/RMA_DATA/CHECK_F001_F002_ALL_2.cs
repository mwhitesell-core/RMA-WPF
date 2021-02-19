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
    public class CHECK_F001_F002_ALL_2 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "CHECK_F001_F002_ALL_2";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrEXTF002HDR = new Reader();

        #endregion

        #region " Renaissance Data "

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

        #endregion

        #region " Renaissance Statements "

        #region " ACCESS "

        private void Access_EXTF002HDR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("BATCTRL_NBR_CLAIMS_IN_BATCH, ");
            strSQL.Append("XCOUNT, ");
            strSQL.Append("BATCTRL_LAST_CLAIM_NBR, ");
            strSQL.Append("KEY_CLM_CLAIM_NBR, ");
            strSQL.Append("BATCTRL_CALC_TOT_REV, ");
            strSQL.Append("CLMHDR_TOT_CLAIM_AR_OHIP, ");
            strSQL.Append("BATCTRL_BATCH_TYPE, ");
            strSQL.Append("BATCTRL_ADJ_CD, ");
            strSQL.Append("BATCTRL_CALC_AR_DUE, ");
            strSQL.Append("BATCTRL_MANUAL_PAY_TOT, ");
            strSQL.Append("CLMHDR_MANUAL_AND_TAPE_PAYMENTS, ");
            strSQL.Append("BATCTRL_AMT_ACT, ");
            strSQL.Append("BATCTRL_AMT_EST, ");
            strSQL.Append("BATCTRL_BATCH_NBR, ");
            strSQL.Append("BATCTRL_BATCH_STATUS ");
            strSQL.Append("FROM TEMPORARYDATA.EXTF002HDR ");

            strSQL.Append(Choose());

            rdrEXTF002HDR.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);

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

        public override bool SelectIf()
        {
            bool blnSelected = false;
            if (((QDesign.NULL(rdrEXTF002HDR.GetNumber("BATCTRL_NBR_CLAIMS_IN_BATCH")) != QDesign.NULL(rdrEXTF002HDR.GetNumber("XCOUNT"))) 
                        || ((QDesign.NULL(rdrEXTF002HDR.GetNumber("BATCTRL_LAST_CLAIM_NBR")) != QDesign.NULL(rdrEXTF002HDR.GetNumber("KEY_CLM_CLAIM_NBR"))) 
                        || (((QDesign.NULL(rdrEXTF002HDR.GetNumber("BATCTRL_CALC_TOT_REV")) != QDesign.NULL(rdrEXTF002HDR.GetNumber("CLMHDR_TOT_CLAIM_AR_OHIP"))) 
                        && (QDesign.NULL(rdrEXTF002HDR.GetString("BATCTRL_BATCH_TYPE")) == "C")) 
                        || (((QDesign.NULL(rdrEXTF002HDR.GetNumber("BATCTRL_CALC_TOT_REV")) != QDesign.NULL(rdrEXTF002HDR.GetNumber("CLMHDR_TOT_CLAIM_AR_OHIP"))) 
                        && ((QDesign.NULL(rdrEXTF002HDR.GetString("BATCTRL_BATCH_TYPE")) == "A") 
                        && (QDesign.NULL(rdrEXTF002HDR.GetString("BATCTRL_ADJ_CD")) != "A"))) 
                        || (((QDesign.NULL(rdrEXTF002HDR.GetNumber("BATCTRL_CALC_AR_DUE")) != QDesign.NULL(rdrEXTF002HDR.GetNumber("CLMHDR_TOT_CLAIM_AR_OHIP"))) 
                        && ((QDesign.NULL(rdrEXTF002HDR.GetString("BATCTRL_BATCH_TYPE")) == "A") 
                        && (QDesign.NULL(rdrEXTF002HDR.GetString("BATCTRL_ADJ_CD")) == "A"))) 
                        || (((QDesign.NULL(rdrEXTF002HDR.GetNumber("BATCTRL_MANUAL_PAY_TOT")) != QDesign.NULL(rdrEXTF002HDR.GetNumber("CLMHDR_MANUAL_AND_TAPE_PAYMENTS"))) 
                        && (QDesign.NULL(rdrEXTF002HDR.GetString("BATCTRL_BATCH_TYPE")) == "P")) 
                        || (QDesign.NULL(rdrEXTF002HDR.GetNumber("BATCTRL_AMT_ACT")) != QDesign.NULL(rdrEXTF002HDR.GetNumber("BATCTRL_AMT_EST"))))))))))
            {
                blnSelected = true;
            }
        
            return blnSelected;
        }

        #endregion

        #region " DEFINES "

        //  TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:
        private string BATCTRL_BATCH_TYPE_ADJ_CD()
        {
            string strReturnValue = String.Empty;
            try
            {
                if ((QDesign.NULL(rdrEXTF002HDR.GetString("BATCTRL_BATCH_TYPE")) == "C"))
                {
                    strReturnValue = rdrEXTF002HDR.GetString("BATCTRL_BATCH_TYPE");
                }
                else
                {
                    strReturnValue = (rdrEXTF002HDR.GetString("BATCTRL_BATCH_TYPE") + ("/" + rdrEXTF002HDR.GetString("BATCTRL_ADJ_CD")));
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
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.EXTF002HDR.BATCTRL_BATCH_NBR", DataTypes.Character, 8);
                 AddControl(ReportSection.REPORT, "BATCTRL_BATCH_TYPE_ADJ_CD", DataTypes.Character, 3);
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.EXTF002HDR.BATCTRL_BATCH_STATUS", DataTypes.Character, 1);
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.EXTF002HDR.BATCTRL_LAST_CLAIM_NBR", DataTypes.Numeric, 2);
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.EXTF002HDR.KEY_CLM_CLAIM_NBR", DataTypes.Numeric, 2);
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.EXTF002HDR.BATCTRL_NBR_CLAIMS_IN_BATCH", DataTypes.Numeric, 2);
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.EXTF002HDR.XCOUNT", DataTypes.Numeric, 2);
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.EXTF002HDR.BATCTRL_AMT_ACT", DataTypes.Numeric, 9);
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.EXTF002HDR.BATCTRL_AMT_EST", DataTypes.Numeric, 9);
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.EXTF002HDR.BATCTRL_CALC_TOT_REV", DataTypes.Numeric, 9);
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.EXTF002HDR.CLMHDR_TOT_CLAIM_AR_OHIP", DataTypes.Numeric, 9);
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.EXTF002HDR.BATCTRL_MANUAL_PAY_TOT", DataTypes.Numeric, 9);
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.EXTF002HDR.CLMHDR_MANUAL_AND_TAPE_PAYMENTS", DataTypes.Numeric, 9);
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
        // # Do not delete, modify or move it.  Updated: 2018-05-09 7:36:49 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "TEMPORARYDATA.EXTF002HDR.BATCTRL_BATCH_NBR":
                    return Common.StringToField(rdrEXTF002HDR.GetString("BATCTRL_BATCH_NBR"));

                case "BATCTRL_BATCH_TYPE_ADJ_CD":
                    return Common.StringToField(BATCTRL_BATCH_TYPE_ADJ_CD(), intSize);

                case "TEMPORARYDATA.EXTF002HDR.BATCTRL_BATCH_STATUS":
                    return Common.StringToField(rdrEXTF002HDR.GetString("BATCTRL_BATCH_STATUS"));

                case "TEMPORARYDATA.EXTF002HDR.BATCTRL_LAST_CLAIM_NBR":
                    return rdrEXTF002HDR.GetNumber("BATCTRL_LAST_CLAIM_NBR").ToString();

                case "TEMPORARYDATA.EXTF002HDR.KEY_CLM_CLAIM_NBR":
                    return rdrEXTF002HDR.GetNumber("KEY_CLM_CLAIM_NBR").ToString();

                case "TEMPORARYDATA.EXTF002HDR.BATCTRL_NBR_CLAIMS_IN_BATCH":
                    return rdrEXTF002HDR.GetNumber("BATCTRL_NBR_CLAIMS_IN_BATCH").ToString();

                case "TEMPORARYDATA.EXTF002HDR.XCOUNT":
                    return rdrEXTF002HDR.GetNumber("XCOUNT").ToString();

                case "TEMPORARYDATA.EXTF002HDR.BATCTRL_AMT_ACT":
                    return rdrEXTF002HDR.GetNumber("BATCTRL_AMT_ACT").ToString();

                case "TEMPORARYDATA.EXTF002HDR.BATCTRL_AMT_EST":
                    return rdrEXTF002HDR.GetNumber("BATCTRL_AMT_EST").ToString();

                case "TEMPORARYDATA.EXTF002HDR.BATCTRL_CALC_TOT_REV":
                    return rdrEXTF002HDR.GetNumber("BATCTRL_CALC_TOT_REV").ToString();

                case "TEMPORARYDATA.EXTF002HDR.CLMHDR_TOT_CLAIM_AR_OHIP":
                    return rdrEXTF002HDR.GetNumber("CLMHDR_TOT_CLAIM_AR_OHIP").ToString();

                case "TEMPORARYDATA.EXTF002HDR.BATCTRL_MANUAL_PAY_TOT":
                    return rdrEXTF002HDR.GetNumber("BATCTRL_MANUAL_PAY_TOT").ToString();

                case "TEMPORARYDATA.EXTF002HDR.CLMHDR_MANUAL_AND_TAPE_PAYMENTS":
                    return rdrEXTF002HDR.GetNumber("CLMHDR_MANUAL_AND_TAPE_PAYMENTS").ToString();

                default:
                    return string.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                Access_EXTF002HDR();
                while (rdrEXTF002HDR.Read())
                {
                    WriteData();
                }
            
                rdrEXTF002HDR.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrEXTF002HDR == null))
            {
                rdrEXTF002HDR.Close();
                rdrEXTF002HDR = null;
            }
        }

        #endregion

        #endregion
    }
}
