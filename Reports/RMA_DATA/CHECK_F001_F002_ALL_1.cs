//  2012/Jul/04 - MC - clone from u991.cbl to check all clinics if there are difference in amt/svc/claim         
//  between f001 & f002
//  2012/Dec/04 - MC1 - fine tuned on selection statement
//  2013/Mar/21 - MC2 - add 2 more passes to extract which claim has different between hdr & detail 
//  2017/Jul/24 - MC3 - add 2 new passes for orphaned batch records
//  2017/Sep/20 - MC4 - cosmetic - display amounts properly
//  2018/Jan/16 - MC5 - add 2 new passes for orphaned claims records

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
    public class CHECK_F001_F002_ALL_1 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "CHECK_F001_F002_ALL_1";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrF001_BATCH_CONTROL_FILE = new Reader();
        private Reader rdrF002_CLAIMS_MSTR_HDR = new Reader();
        private Reader rdrEXTF002HDR = new Reader();

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
                //  Create Subfile.
                SubFile = true;
                SubFileName = "EXTF002HDR";
                SubFileType = SubFileType.Keep;
                SubFileAT = "BATCTRL_BATCH_NBR";
                Sort = "BATCTRL_BATCH_NBR ASC";
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

        private void Access_F001_BATCH_CONTROL_FILE()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);
            strSQL.Append("SELECT ");
            strSQL.Append("BATCTRL_BATCH_NBR, ");
            strSQL.Append("BATCTRL_BATCH_STATUS, ");
            strSQL.Append("BATCTRL_BATCH_TYPE, ");
            strSQL.Append("BATCTRL_ADJ_CD, ");
            strSQL.Append("BATCTRL_NBR_CLAIMS_IN_BATCH, ");
            strSQL.Append("BATCTRL_LAST_CLAIM_NBR, ");
            strSQL.Append("BATCTRL_CALC_TOT_REV, ");
            strSQL.Append("BATCTRL_CALC_AR_DUE, ");
            strSQL.Append("BATCTRL_MANUAL_PAY_TOT, ");
            strSQL.Append("BATCTRL_AMT_ACT, ");
            strSQL.Append("BATCTRL_AMT_EST, ");
            strSQL.Append("BATCTRL_SVC_ACT, ");
            strSQL.Append("BATCTRL_SVC_EST, ");
            strSQL.Append("BATCTRL_DATE_PERIOD_END, ");
            strSQL.Append("BATCTRL_DATE_BATCH_ENTERED ");
            strSQL.Append("FROM INDEXED.F001_BATCH_CONTROL_FILE ");
            strSQL.Append(Choose());
            strSQL.Append(SelectIf_F001_BATCH_CONTROL_FILE(true));
            rdrF001_BATCH_CONTROL_FILE.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        private void Link_F002_CLAIMS_MSTR_HDR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("KEY_CLM_TYPE, ");
            strSQL.Append("KEY_CLM_BATCH_NBR, ");
            strSQL.Append("KEY_CLM_CLAIM_NBR, ");
            strSQL.Append("CLMHDR_TOT_CLAIM_AR_OHIP, ");
            strSQL.Append("CLMHDR_MANUAL_AND_TAPE_PAYMENTS, ");
            strSQL.Append("CLMHDR_DATE_PERIOD_END, ");
            strSQL.Append("CLMHDR_ORIG_BATCH_NBR, ");
            strSQL.Append("CLMHDR_ORIG_CLAIM_NBR ");
            strSQL.Append("FROM INDEXED.F002_CLAIMS_MSTR_HDR ");
            strSQL.Append("WHERE ");
            strSQL.Append("KEY_CLM_TYPE = '").Append("B");
            strSQL.Append("'");
            strSQL.Append(" AND KEY_CLM_BATCH_NBR = '").Append(rdrF001_BATCH_CONTROL_FILE.GetString("BATCTRL_BATCH_NBR"));
            strSQL.Append("'");
            strSQL.Append(SelectIf_F002_CLAIMS_MSTR(false));
            rdrF002_CLAIMS_MSTR_HDR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
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

        private string SelectIf_F001_BATCH_CONTROL_FILE(bool blnAddWhere)
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);
            if (blnAddWhere)
            {
                strSQL.Append(" WHERE ");
            }
            else
            {
                strSQL.Append(" AND ");
            }

            strSQL.Append("BATCTRL_BATCH_STATUS < '2'");
            return strSQL.ToString();
        }

        private string SelectIf_F002_CLAIMS_MSTR(bool blnAddWhere)
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);
            if (blnAddWhere)
            {
                strSQL.Append(" WHERE ");
            }
            else
            {
                strSQL.Append(" AND ");
            }

            strSQL.Append("CLMHDR_ADJ_OMA_CD = '0000'");
            return strSQL.ToString();
        }

        #endregion

        #region " DEFINES "

        private decimal XCOUNT()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = 1;
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        //PARENT FIELD - CLMHDR_CLAIM_ID
        private string F002_CLAIMS_HDR_CLMHDR_ORIG_BATCH_ID()
        {
            string strReturnValue = "";
            try
            {
                strReturnValue = rdrF002_CLAIMS_MSTR_HDR.GetString("CLMHDR_ORIG_BATCH_NBR") + rdrF002_CLAIMS_MSTR_HDR.GetNumber("CLMHDR_ORIG_CLAIM_NBR").ToString();
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
                AddControl(ReportSection.SUMMARY, "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_BATCH_NBR", DataTypes.Character, 8);
                AddControl(ReportSection.SUMMARY, "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_BATCH_TYPE", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_ADJ_CD", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_BATCH_STATUS", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_NBR_CLAIMS_IN_BATCH", DataTypes.Numeric, 2);
                AddControl(ReportSection.SUMMARY, "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_LAST_CLAIM_NBR", DataTypes.Numeric, 2);
                AddControl(ReportSection.SUMMARY, "XCOUNT", DataTypes.Numeric, 6, SummaryType.SUBTOTAL, "BATCTRL_BATCH_NBR");
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR_HDR.KEY_CLM_CLAIM_NBR", DataTypes.Numeric, 2);
                AddControl(ReportSection.SUMMARY, "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_CALC_TOT_REV", DataTypes.Numeric, 9);
                AddControl(ReportSection.SUMMARY, "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_CALC_AR_DUE", DataTypes.Numeric, 9);
                AddControl(ReportSection.SUMMARY, "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_MANUAL_PAY_TOT", DataTypes.Numeric, 9);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR_HDR.CLMHDR_TOT_CLAIM_AR_OHIP", DataTypes.Numeric, 9, SummaryType.SUBTOTAL, "BATCTRL_BATCH_NBR");
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR_HDR.CLMHDR_MANUAL_AND_TAPE_PAYMENTS", DataTypes.Numeric, 9, SummaryType.SUBTOTAL, "BATCTRL_BATCH_NBR");
                AddControl(ReportSection.SUMMARY, "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_AMT_ACT", DataTypes.Numeric, 9);
                AddControl(ReportSection.SUMMARY, "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_AMT_EST", DataTypes.Numeric, 9);
                AddControl(ReportSection.SUMMARY, "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_SVC_ACT", DataTypes.Numeric, 4);
                AddControl(ReportSection.SUMMARY, "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_SVC_EST", DataTypes.Numeric, 4);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR_HDR.CLMHDR_DATE_PERIOD_END", DataTypes.Numeric, 8);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR_HDR.CLMHDR_ORIG_BATCH_ID", DataTypes.Character, 10);
                AddControl(ReportSection.SUMMARY, "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_DATE_PERIOD_END", DataTypes.Character, 8);
                AddControl(ReportSection.SUMMARY, "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_DATE_BATCH_ENTERED", DataTypes.Character, 8);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        #endregion

        #region " Renaissance Precompiler Generated Code "

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 10/26/2017 11:34:05 AM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            // TODO: Remove duplicate controls, if there are any.
            switch (strControl)
            {
                case "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_BATCH_NBR":
                    return Common.StringToField(rdrF001_BATCH_CONTROL_FILE.GetString("BATCTRL_BATCH_NBR"));
                case "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_BATCH_TYPE":
                    return Common.StringToField(rdrF001_BATCH_CONTROL_FILE.GetString("BATCTRL_BATCH_TYPE"));
                case "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_ADJ_CD":
                    return Common.StringToField(rdrF001_BATCH_CONTROL_FILE.GetString("BATCTRL_ADJ_CD"));
                case "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_BATCH_STATUS":
                    return Common.StringToField(rdrF001_BATCH_CONTROL_FILE.GetString("BATCTRL_BATCH_STATUS"));
                case "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_NBR_CLAIMS_IN_BATCH":
                    return rdrF001_BATCH_CONTROL_FILE.GetNumber("BATCTRL_NBR_CLAIMS_IN_BATCH").ToString();
                case "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_LAST_CLAIM_NBR":
                    return rdrF001_BATCH_CONTROL_FILE.GetNumber("BATCTRL_LAST_CLAIM_NBR").ToString();
                case "XCOUNT":
                    return XCOUNT().ToString();
                case "INDEXED.F002_CLAIMS_MSTR_HDR.KEY_CLM_CLAIM_NBR":
                    return rdrF002_CLAIMS_MSTR_HDR.GetNumber("KEY_CLM_CLAIM_NBR").ToString();
                case "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_CALC_TOT_REV":
                    return rdrF001_BATCH_CONTROL_FILE.GetNumber("BATCTRL_CALC_TOT_REV").ToString();
                case "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_CALC_AR_DUE":
                    return rdrF001_BATCH_CONTROL_FILE.GetNumber("BATCTRL_CALC_AR_DUE").ToString();
                case "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_MANUAL_PAY_TOT":
                    return rdrF001_BATCH_CONTROL_FILE.GetNumber("BATCTRL_MANUAL_PAY_TOT").ToString();
                case "INDEXED.F002_CLAIMS_MSTR_HDR.CLMHDR_TOT_CLAIM_AR_OHIP":
                    return rdrF002_CLAIMS_MSTR_HDR.GetNumber("CLMHDR_TOT_CLAIM_AR_OHIP").ToString();
                case "INDEXED.F002_CLAIMS_MSTR_HDR.CLMHDR_MANUAL_AND_TAPE_PAYMENTS":
                    return rdrF002_CLAIMS_MSTR_HDR.GetNumber("CLMHDR_MANUAL_AND_TAPE_PAYMENTS").ToString();
                case "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_AMT_ACT":
                    return rdrF001_BATCH_CONTROL_FILE.GetNumber("BATCTRL_AMT_ACT").ToString();
                case "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_AMT_EST":
                    return rdrF001_BATCH_CONTROL_FILE.GetNumber("BATCTRL_AMT_EST").ToString();
                case "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_SVC_ACT":
                    return rdrF001_BATCH_CONTROL_FILE.GetNumber("BATCTRL_SVC_ACT").ToString();
                case "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_SVC_EST":
                    return rdrF001_BATCH_CONTROL_FILE.GetNumber("BATCTRL_SVC_EST").ToString();
                case "INDEXED.F002_CLAIMS_MSTR_HDR.CLMHDR_DATE_PERIOD_END":
                    return rdrF002_CLAIMS_MSTR_HDR.GetNumber("CLMHDR_DATE_PERIOD_END").ToString();
                case "INDEXED.F002_CLAIMS_MSTR_HDR.CLMHDR_ORIG_BATCH_ID":
                    return Common.StringToField(F002_CLAIMS_HDR_CLMHDR_ORIG_BATCH_ID());
                case "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_DATE_PERIOD_END":
                    return Common.StringToField(rdrF001_BATCH_CONTROL_FILE.GetString("BATCTRL_DATE_PERIOD_END"));
                case "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_DATE_BATCH_ENTERED":
                    return Common.StringToField(rdrF001_BATCH_CONTROL_FILE.GetString("BATCTRL_DATE_BATCH_ENTERED"));
                default:
                    return String.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                // TODO: Some manual steps maybe required.
                Access_F001_BATCH_CONTROL_FILE();
                while (rdrF001_BATCH_CONTROL_FILE.Read())
                {
                    Link_F002_CLAIMS_MSTR_HDR();
                    while (rdrF002_CLAIMS_MSTR_HDR.Read())
                    {
                        WriteData();
                    }

                    rdrF002_CLAIMS_MSTR_HDR.Close();
                }

                rdrF001_BATCH_CONTROL_FILE.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrF001_BATCH_CONTROL_FILE == null))
            {
                rdrF001_BATCH_CONTROL_FILE.Close();
                rdrF001_BATCH_CONTROL_FILE = null;
            }

            if (!(rdrF002_CLAIMS_MSTR_HDR == null))
            {
                rdrF002_CLAIMS_MSTR_HDR.Close();
                rdrF002_CLAIMS_MSTR_HDR = null;
            }

        }

        #endregion

        #endregion
    }
}
