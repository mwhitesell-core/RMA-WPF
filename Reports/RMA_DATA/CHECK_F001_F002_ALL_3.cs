//  ----------------------------------
//  access claim dtl to get amount & nbr of services
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
    public class CHECK_F001_F002_ALL_3 : BaseRDLClass
    {
        protected const string REPORT_NAME = "CHECK_F001_F002_ALL_3";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrEXTF002HDR = new Reader();
        private Reader rdrF002_CLAIMS_MSTR = new Reader();
        private Reader rdrEXTF002DTL = new Reader();
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
                SubFileName = "EXTF002DTL";
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
        private void Access_EXTF002HDR()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: If * is not used to select all columns, ensure the necessary columns (i.e. columns that are used to access records of other tables) are included in the SELECT statement
            strSQL.Append("SELECT ");
            strSQL.Append("BATCTRL_BATCH_NBR, ");
            strSQL.Append("BATCTRL_BATCH_TYPE, ");
            strSQL.Append("BATCTRL_ADJ_CD, ");
            strSQL.Append("BATCTRL_BATCH_STATUS, ");
            strSQL.Append("BATCTRL_NBR_CLAIMS_IN_BATCH, ");
            strSQL.Append("BATCTRL_LAST_CLAIM_NBR, ");
            strSQL.Append("XCOUNT, ");
            strSQL.Append("KEY_CLM_CLAIM_NBR, ");
            strSQL.Append("BATCTRL_CALC_TOT_REV, ");
            strSQL.Append("BATCTRL_CALC_AR_DUE, ");
            strSQL.Append("BATCTRL_MANUAL_PAY_TOT, ");
            strSQL.Append("CLMHDR_TOT_CLAIM_AR_OHIP, ");
            strSQL.Append("CLMHDR_MANUAL_AND_TAPE_PAYMENTS, ");
            strSQL.Append("BATCTRL_AMT_ACT, ");
            strSQL.Append("BATCTRL_AMT_EST, ");
            strSQL.Append("BATCTRL_SVC_ACT, ");
            strSQL.Append("BATCTRL_SVC_EST, ");
            strSQL.Append("CLMHDR_DATE_PERIOD_END, ");
            strSQL.Append("CLMHDR_ORIG_BATCH_ID, ");
            strSQL.Append("BATCTRL_DATE_PERIOD_END, ");
            strSQL.Append("BATCTRL_DATE_BATCH_ENTERED ");
            strSQL.Append("FROM TEMPORARYDATA.EXTF002HDR ");
            strSQL.Append(Choose());
            rdrEXTF002HDR.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
            strSQL = null;
        }
        private void Link_F002_CLAIMS_MSTR_DTL()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("CLMDTL_OMA_CD, ");
            strSQL.Append("CLMDTL_CONSEC_DATES_R, ");
            strSQL.Append("CLMDTL_NBR_SERV, ");
            strSQL.Append("CLMDTL_FEE_OHIP ");
            strSQL.Append("FROM INDEXED.F002_CLAIMS_MSTR_DTL ");
            strSQL.Append("WHERE ");
            strSQL.Append("KEY_CLM_TYPE = '").Append("B");
            strSQL.Append("' AND KEY_CLM_BATCH_NBR = ").Append(Common.StringToField(rdrEXTF002HDR.GetString("BATCTRL_BATCH_NBR")));
            rdrF002_CLAIMS_MSTR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(String.Empty);
            // TODO: CHOOSE Statement - May require manual changes.
            return strChoose.ToString();
        }

        public override bool SelectIf()
        {
            bool blnSelected = false;
            if (((QDesign.NULL(rdrF002_CLAIMS_MSTR.GetString("CLMDTL_OMA_CD")) != "0000")
                        && (QDesign.NULL(rdrF002_CLAIMS_MSTR.GetString("CLMDTL_OMA_CD")) != "ZZZZ")))
            {
                blnSelected = true;
            }

            return blnSelected;
        }

        private string CONSEC_FLAG()
        {
            string strReturnValue = String.Empty;
            try
            {
                if (((QDesign.NULL(QDesign.Substring(rdrF002_CLAIMS_MSTR.GetString("CLMDTL_CONSEC_DATES_R"), 1, 3)) != "0OP")
                            && ((QDesign.NULL(QDesign.Substring(rdrF002_CLAIMS_MSTR.GetString("CLMDTL_CONSEC_DATES_R"), 1, 3)) != "0MR")
                            && ((QDesign.NULL(QDesign.Substring(rdrF002_CLAIMS_MSTR.GetString("CLMDTL_CONSEC_DATES_R"), 1, 3)) != "0BI")
                            && ((QDesign.NULL(QDesign.Substring(rdrF002_CLAIMS_MSTR.GetString("CLMDTL_CONSEC_DATES_R"), 1, 3)) != "0")
                            && ((QDesign.NULL(QDesign.Substring(rdrF002_CLAIMS_MSTR.GetString("CLMDTL_CONSEC_DATES_R"), 1, 3)) != " 00")
                            && ((QDesign.NULL(QDesign.Substring(rdrF002_CLAIMS_MSTR.GetString("CLMDTL_CONSEC_DATES_R"), 1, 3)) != "000")
                            && ((QDesign.NULL(QDesign.Substring(rdrF002_CLAIMS_MSTR.GetString("CLMDTL_CONSEC_DATES_R"), 1, 3)) != "00")
                            && (QDesign.NULL(QDesign.Substring(rdrF002_CLAIMS_MSTR.GetString("CLMDTL_CONSEC_DATES_R"), 1, 3)) != QDesign.NULL("   "))))))))))
                {
                    strReturnValue = "Y";
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private decimal X_SV_NBR1()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = rdrF002_CLAIMS_MSTR.GetNumber("CLMDTL_NBR_SERV");
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_SV_NBR2()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(CONSEC_FLAG()) == "Y"))
                {
                    decReturnValue = QDesign.NConvert(QDesign.Substring(rdrF002_CLAIMS_MSTR.GetString("CLMDTL_CONSEC_DATES_R"), 1, 1));
                }
                else
                {
                    decReturnValue = 0;
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_SV_NBR3()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(CONSEC_FLAG()) == "Y"))
                {
                    decReturnValue = QDesign.NConvert(QDesign.Substring(rdrF002_CLAIMS_MSTR.GetString("CLMDTL_CONSEC_DATES_R"), 4, 1));
                }
                else
                {
                    decReturnValue = 0;
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_SV_NBR4()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(CONSEC_FLAG()) == "Y"))
                {
                    decReturnValue = QDesign.NConvert(QDesign.Substring(rdrF002_CLAIMS_MSTR.GetString("CLMDTL_CONSEC_DATES_R"), 7, 1));
                }
                else
                {
                    decReturnValue = 0;
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal TOT_SVC()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = (X_SV_NBR1()
                            + (X_SV_NBR2()
                            + (X_SV_NBR3() + X_SV_NBR4())));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.EXTF002HDR.BATCTRL_BATCH_NBR", DataTypes.Character, 8);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.EXTF002HDR.BATCTRL_BATCH_TYPE", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.EXTF002HDR.BATCTRL_ADJ_CD", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.EXTF002HDR.BATCTRL_BATCH_STATUS", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.EXTF002HDR.BATCTRL_NBR_CLAIMS_IN_BATCH", DataTypes.Numeric, 2);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.EXTF002HDR.BATCTRL_LAST_CLAIM_NBR", DataTypes.Numeric, 2);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.EXTF002HDR.XCOUNT", DataTypes.Numeric, 6);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.EXTF002HDR.KEY_CLM_CLAIM_NBR", DataTypes.Numeric, 2);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.EXTF002HDR.BATCTRL_CALC_TOT_REV", DataTypes.Numeric, 9);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.EXTF002HDR.BATCTRL_CALC_AR_DUE", DataTypes.Numeric, 9);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.EXTF002HDR.BATCTRL_MANUAL_PAY_TOT", DataTypes.Numeric, 9);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.EXTF002HDR.CLMHDR_TOT_CLAIM_AR_OHIP", DataTypes.Numeric, 7);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.EXTF002HDR.CLMHDR_MANUAL_AND_TAPE_PAYMENTS", DataTypes.Numeric, 7);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.EXTF002HDR.BATCTRL_AMT_ACT", DataTypes.Numeric, 9);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.EXTF002HDR.BATCTRL_AMT_EST", DataTypes.Numeric, 9);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.EXTF002HDR.BATCTRL_SVC_ACT", DataTypes.Numeric, 4);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.EXTF002HDR.BATCTRL_SVC_EST", DataTypes.Numeric, 4);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.EXTF002HDR.CLMHDR_DATE_PERIOD_END", DataTypes.Numeric, 8);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.EXTF002HDR.CLMHDR_ORIG_BATCH_ID", DataTypes.Character, 10);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.EXTF002HDR.BATCTRL_DATE_PERIOD_END", DataTypes.Character, 8);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.EXTF002HDR.BATCTRL_DATE_BATCH_ENTERED", DataTypes.Character, 8);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR.CLMDTL_FEE_OHIP", DataTypes.Numeric, 9, SummaryType.SUBTOTAL, "BATCTRL_BATCH_NBR");
                AddControl(ReportSection.SUMMARY, "TOT_SVC", DataTypes.Numeric, 4, SummaryType.SUBTOTAL, "BATCTRL_BATCH_NBR");
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-05-09 7:36:49 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            // TODO: Remove duplicate controls, if there are any.
            switch (strControl)
            {
                case "TEMPORARYDATA.EXTF002HDR.BATCTRL_BATCH_NBR":
                    return Common.StringToField(rdrEXTF002HDR.GetString("BATCTRL_BATCH_NBR"));
                case "TEMPORARYDATA.EXTF002HDR.BATCTRL_BATCH_TYPE":
                    return Common.StringToField(rdrEXTF002HDR.GetString("BATCTRL_BATCH_TYPE"));
                case "TEMPORARYDATA.EXTF002HDR.BATCTRL_ADJ_CD":
                    return Common.StringToField(rdrEXTF002HDR.GetString("BATCTRL_ADJ_CD"));
                case "TEMPORARYDATA.EXTF002HDR.BATCTRL_BATCH_STATUS":
                    return Common.StringToField(rdrEXTF002HDR.GetString("BATCTRL_BATCH_STATUS"));
                case "TEMPORARYDATA.EXTF002HDR.BATCTRL_NBR_CLAIMS_IN_BATCH":
                    return rdrEXTF002HDR.GetNumber("BATCTRL_NBR_CLAIMS_IN_BATCH").ToString();
                case "TEMPORARYDATA.EXTF002HDR.BATCTRL_LAST_CLAIM_NBR":
                    return rdrEXTF002HDR.GetNumber("BATCTRL_LAST_CLAIM_NBR").ToString();
                case "TEMPORARYDATA.EXTF002HDR.XCOUNT":
                    return rdrEXTF002HDR.GetNumber("XCOUNT").ToString();
                case "TEMPORARYDATA.EXTF002HDR.KEY_CLM_CLAIM_NBR":
                    return rdrEXTF002HDR.GetNumber("KEY_CLM_CLAIM_NBR").ToString();
                case "TEMPORARYDATA.EXTF002HDR.BATCTRL_CALC_TOT_REV":
                    return rdrEXTF002HDR.GetNumber("BATCTRL_CALC_TOT_REV").ToString();
                case "TEMPORARYDATA.EXTF002HDR.BATCTRL_CALC_AR_DUE":
                    return rdrEXTF002HDR.GetNumber("BATCTRL_CALC_AR_DUE").ToString();
                case "TEMPORARYDATA.EXTF002HDR.BATCTRL_MANUAL_PAY_TOT":
                    return rdrEXTF002HDR.GetNumber("BATCTRL_MANUAL_PAY_TOT").ToString();
                case "TEMPORARYDATA.EXTF002HDR.CLMHDR_TOT_CLAIM_AR_OHIP":
                    return rdrEXTF002HDR.GetNumber("CLMHDR_TOT_CLAIM_AR_OHIP").ToString();
                case "TEMPORARYDATA.EXTF002HDR.CLMHDR_MANUAL_AND_TAPE_PAYMENTS":
                    return rdrEXTF002HDR.GetNumber("CLMHDR_MANUAL_AND_TAPE_PAYMENTS").ToString();
                case "TEMPORARYDATA.EXTF002HDR.BATCTRL_AMT_ACT":
                    return rdrEXTF002HDR.GetNumber("BATCTRL_AMT_ACT").ToString();
                case "TEMPORARYDATA.EXTF002HDR.BATCTRL_AMT_EST":
                    return rdrEXTF002HDR.GetNumber("BATCTRL_AMT_EST").ToString();
                case "TEMPORARYDATA.EXTF002HDR.BATCTRL_SVC_ACT":
                    return rdrEXTF002HDR.GetNumber("BATCTRL_SVC_ACT").ToString();
                case "TEMPORARYDATA.EXTF002HDR.BATCTRL_SVC_EST":
                    return rdrEXTF002HDR.GetNumber("BATCTRL_SVC_EST").ToString();
                case "TEMPORARYDATA.EXTF002HDR.CLMHDR_DATE_PERIOD_END":
                    return rdrEXTF002HDR.GetNumber("CLMHDR_DATE_PERIOD_END").ToString();
                case "TEMPORARYDATA.EXTF002HDR.CLMHDR_ORIG_BATCH_ID":
                    return Common.StringToField(rdrEXTF002HDR.GetString("CLMHDR_ORIG_BATCH_ID"));
                case "TEMPORARYDATA.EXTF002HDR.BATCTRL_DATE_PERIOD_END":
                    return Common.StringToField(rdrEXTF002HDR.GetString("BATCTRL_DATE_PERIOD_END"));
                case "TEMPORARYDATA.EXTF002HDR.BATCTRL_DATE_BATCH_ENTERED":
                    return Common.StringToField(rdrEXTF002HDR.GetString("BATCTRL_DATE_BATCH_ENTERED"));
                case "INDEXED.F002_CLAIMS_MSTR.CLMDTL_FEE_OHIP":
                    return rdrF002_CLAIMS_MSTR.GetNumber("CLMDTL_FEE_OHIP").ToString();
                case "TOT_SVC":
                    return TOT_SVC().ToString();
                default:
                    return String.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                // TODO: Some manual steps maybe required.
                Access_EXTF002HDR();
                while (rdrEXTF002HDR.Read())
                {
                    Link_F002_CLAIMS_MSTR_DTL();
                    while (rdrF002_CLAIMS_MSTR.Read())
                    {
                        WriteData();
                    }

                    rdrF002_CLAIMS_MSTR.Close();
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

            if (!(rdrF002_CLAIMS_MSTR == null))
            {
                rdrF002_CLAIMS_MSTR.Close();
                rdrF002_CLAIMS_MSTR = null;
            }
        }
    }
}
