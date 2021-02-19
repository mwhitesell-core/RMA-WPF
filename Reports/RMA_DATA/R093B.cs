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
    public class R093B : BaseRDLClass
    {
        protected const string REPORT_NAME = "R093B";
        protected const bool REPORT_HAS_PARAMETERS = false;

        private Reader rdrU093_DELETE_BATCH = new Reader();
        private Reader rdrICONST_MSTR_REC = new Reader();

        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                //  Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;

                SubFile = true;
                SubFileName = "U093_PURGE_VALIDATE";
                SubFileType = SubFileType.Keep;
                SubFileAT = "BATCTRL_BATCH_NBR";
                SubFileAppend = true;

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

        private void Access_U093_DELETE_BATCH()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            strSQL.Append("SELECT ");
            strSQL.Append("BATCTRL_BATCH_NBR, ");
            strSQL.Append("BATCTRL_BATCH_TYPE, ");
            strSQL.Append("BATCTRL_ADJ_CD, ");
            strSQL.Append("BATCTRL_ADJ_CD_SUB_TYPE, ");
            strSQL.Append("BATCTRL_LAST_CLAIM_NBR, ");
            strSQL.Append("BATCTRL_CLINIC_NBR, ");
            strSQL.Append("BATCTRL_DOC_NBR_OHIP, ");
            strSQL.Append("BATCTRL_HOSP, ");
            strSQL.Append("BATCTRL_LOC, ");
            strSQL.Append("BATCTRL_AGENT_CD, ");
            strSQL.Append("BATCTRL_I_O_PAT_IND, ");
            strSQL.Append("BATCTRL_DATE_BATCH_ENTERED, ");
            strSQL.Append("BATCTRL_DATE_PERIOD_END, ");
            strSQL.Append("BATCTRL_CYCLE_NBR, ");
            strSQL.Append("BATCTRL_AMT_EST, ");
            strSQL.Append("BATCTRL_AMT_ACT, ");
            strSQL.Append("BATCTRL_SVC_EST, ");
            strSQL.Append("BATCTRL_SVC_ACT, ");
            strSQL.Append("BATCTRL_AR_YY_MM, ");
            strSQL.Append("BATCTRL_CALC_AR_DUE, ");
            strSQL.Append("BATCTRL_CALC_TOT_REV, ");
            strSQL.Append("BATCTRL_MANUAL_PAY_TOT, ");
            strSQL.Append("BATCTRL_NBR_CLAIMS_IN_BATCH, ");
            strSQL.Append("ICONST_CLINIC_NBR_1_2, ");
            strSQL.Append("CLMHDR_ADJ_CD_SUB_TYPE, ");
            strSQL.Append("CLMHDR_TOT_CLAIM_AR_OMA, ");
            strSQL.Append("CLMHDR_TOT_CLAIM_AR_OHIP, ");
            strSQL.Append("CLMHDR_MANUAL_AND_TAPE_PAYMENTS, ");
            strSQL.Append("D_CUT_OFF_DATE ");
            strSQL.Append("FROM TEMPORARYDATA.U093_DELETE_BATCH ");

            strSQL.Append(Choose());
            rdrU093_DELETE_BATCH.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
            strSQL = null;
        }

        private void Link_ICONST_MSTR_REC()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            strSQL.Append("SELECT ");
            strSQL.Append("ICONST_CLINIC_NBR_1_2, ");
            strSQL.Append("ICONST_DATE_PERIOD_END_YY, ");
            strSQL.Append("ICONST_DATE_PERIOD_END_MM, ");
            strSQL.Append("ICONST_DATE_PERIOD_END_DD, ");
            strSQL.Append("ICONST_CLINIC_CYCLE_NBR ");
            strSQL.Append("FROM INDEXED.ICONST_MSTR_REC ");
            strSQL.Append("WHERE ");
            strSQL.Append("ICONST_CLINIC_NBR_1_2 = ").Append(Common.StringToField(QDesign.Substring(rdrU093_DELETE_BATCH.GetString("BATCTRL_BATCH_NBR"), 1, 2)));

            rdrICONST_MSTR_REC.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(String.Empty);
            return strChoose.ToString().ToString();
        }

        private decimal D_CLINIC()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = QDesign.NConvert(QDesign.ASCII(rdrICONST_MSTR_REC.GetNumber("ICONST_CLINIC_1_2"), 1)); 
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal D_ICONST_CLINIC_NBR_1_2()
        {
            decimal decReturnValue = 0;
            try
            {
                if (QDesign.NULL(rdrICONST_MSTR_REC.GetNumber("ICONST_CLINIC_NBR_1_2")) >= 61 && QDesign.NULL(rdrICONST_MSTR_REC.GetNumber("ICONST_CLINIC_NBR_1_2"))<= 65)
                {
                    decReturnValue = 60;
                }
                else if (QDesign.NULL(rdrICONST_MSTR_REC.GetNumber("ICONST_CLINIC_NBR_1_2")) >= 71 && QDesign.NULL(rdrICONST_MSTR_REC.GetNumber("ICONST_CLINIC_NBR_1_2")) <= 75)
                {
                    decReturnValue = 70;
                }
                else
                {
                    decReturnValue = rdrICONST_MSTR_REC.GetNumber("ICONST_CLINIC_NBR_1_2");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal D_RETAIN_COUNT()
        {
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

        private decimal D_DELETE_COUNT()
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

        private decimal R_BATCTRL_CALC_AR_DUE()
        {
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

        private decimal R_BATCTRL_CALC_TOT_REV()
        {
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

        private decimal R_BATCTRL_MANUAL_PAY_TOT()
        {
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

        private decimal D_BATCTRL_CALC_AR_DUE()
        {
            decimal decReturnValue = 0;
            try
            {
                if (rdrU093_DELETE_BATCH.GetString("BATCTRL_BATCH_TYPE") == "P" && rdrU093_DELETE_BATCH.GetString("BATCTRL_ADJ_CD") == "C")
                {
                    decReturnValue = 0 - rdrU093_DELETE_BATCH.GetNumber("BATCTRL_CALC_AR_DUE");
                }
                else
                {
                    decReturnValue = rdrU093_DELETE_BATCH.GetNumber("BATCTRL_CALC_AR_DUE");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal D_BATCTRL_CALC_TOT_REV()
        {
            decimal decReturnValue = 0;
            try
            {
                if (rdrU093_DELETE_BATCH.GetString("BATCTRL_BATCH_TYPE") == "P" && rdrU093_DELETE_BATCH.GetString("BATCTRL_ADJ_CD") == "C")
                {
                    decReturnValue = 0 - rdrU093_DELETE_BATCH.GetNumber("BATCTRL_CALC_TOT_REV");
                }
                else
                {
                    decReturnValue = rdrU093_DELETE_BATCH.GetNumber("BATCTRL_CALC_TOT_REV");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal D_BATCTRL_MANUAL_PAY_TOT()
        {
            decimal decReturnValue = 0;
            try
            {
                if (rdrU093_DELETE_BATCH.GetString("BATCTRL_BATCH_TYPE") == "P" && rdrU093_DELETE_BATCH.GetString("BATCTRL_ADJ_CD") == "C")
                {
                    decReturnValue = 0 - rdrU093_DELETE_BATCH.GetNumber("BATCTRL_MANUAL_PAY_TOT");
                }
                else
                {
                    decReturnValue = rdrU093_DELETE_BATCH.GetNumber("BATCTRL_MANUAL_PAY_TOT");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private string D_BATCTRL_ADJ_CD()
        {
            string strReturnValue = string.Empty;
            try
            {
                if (rdrU093_DELETE_BATCH.GetString("BATCTRL_BATCH_TYPE") == "C")
                {
                    strReturnValue = QDesign.ASCII(rdrU093_DELETE_BATCH.GetNumber("BATCTRL_AGENT_CD"));
                }
                else
                {
                    strReturnValue = rdrU093_DELETE_BATCH.GetString("BATCTRL_ADJ_CD");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private decimal ICONST_DATE_PERIOD_END()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = QDesign.NConvert(QDesign.ASCII(rdrICONST_MSTR_REC.GetNumber("ICONST_DATE_PERIOD_END_YY"), 4) + QDesign.ASCII(rdrICONST_MSTR_REC.GetNumber("ICONST_DATE_PERIOD_END_MM"), 2) + QDesign.ASCII(rdrICONST_MSTR_REC.GetNumber("ICONST_DATE_PERIOD_END_DD"), 2));
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
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U093_RETAIN_BATCH.BATCTRL_BATCH_NBR", DataTypes.Character, 8);
                AddControl(ReportSection.SUMMARY, "D_ICONST_CLINIC_NBR_1_2", DataTypes.Numeric, 2);
                AddControl(ReportSection.SUMMARY, "ICONST_DATE_PERIOD_END", DataTypes.Numeric, 8);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U093_DELETE_BATCH.D_CUT_OFF_DATE", DataTypes.Numeric, 8);
                AddControl(ReportSection.SUMMARY, "INDEXED.ICONST_MSTR_REC.ICONST_CLINIC_CYCLE_NBR", DataTypes.Numeric, 2);
                AddControl(ReportSection.SUMMARY, "D_RETAIN_COUNT", DataTypes.Numeric, 1);
                AddControl(ReportSection.SUMMARY, "D_DELETE_COUNT", DataTypes.Numeric, 1);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U093_DELETE_BATCH.BATCTRL_BATCH_TYPE", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "D_BATCTRL_ADJ_CD", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U093_DELETE_BATCH.BATCTRL_CYCLE_NBR", DataTypes.Numeric, 3);
                AddControl(ReportSection.SUMMARY, "R_BATCTRL_CALC_AR_DUE", DataTypes.Numeric, 9);
                AddControl(ReportSection.SUMMARY, "R_BATCTRL_CALC_TOT_REV", DataTypes.Numeric, 9);
                AddControl(ReportSection.SUMMARY, "R_BATCTRL_MANUAL_PAY_TOT", DataTypes.Numeric, 9);
                AddControl(ReportSection.SUMMARY, "D_BATCTRL_CALC_AR_DUE", DataTypes.Numeric, 9);
                AddControl(ReportSection.SUMMARY, "D_BATCTRL_CALC_TOT_REV", DataTypes.Numeric, 9);
                AddControl(ReportSection.SUMMARY, "D_BATCTRL_MANUAL_PAY_TOT", DataTypes.Numeric, 9);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-05-15 1:46:06 PM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "TEMPORARYDATA.U093_RETAIN_BATCH.BATCTRL_BATCH_NBR":
                    return Common.StringToField(rdrU093_DELETE_BATCH.GetString("BATCTRL_BATCH_NBR"));

                case "D_ICONST_CLINIC_NBR_1_2":
                    return D_ICONST_CLINIC_NBR_1_2().ToString();

                case "ICONST_DATE_PERIOD_END":
                    return ICONST_DATE_PERIOD_END().ToString();

                case "TEMPORARYDATA.U093_DELETE_BATCH.D_CUT_OFF_DATE":
                    return rdrU093_DELETE_BATCH.GetNumber("D_CUT_OFF_DATE").ToString();

                case "INDEXED.ICONST_MSTR_REC.ICONST_CLINIC_CYCLE_NBR":
                    return rdrICONST_MSTR_REC.GetNumber("ICONST_CLINIC_CYCLE_NBR").ToString();

                case "D_RETAIN_COUNT":
                    return D_RETAIN_COUNT().ToString();

                case "D_DELETE_COUNT":
                    return D_DELETE_COUNT().ToString();

                case "TEMPORARYDATA.U093_DELETE_BATCH.BATCTRL_BATCH_TYPE":
                    return Common.StringToField(rdrU093_DELETE_BATCH.GetString("BATCTRL_BATCH_TYPE"));

                case "D_BATCTRL_ADJ_CD":
                    return Common.StringToField(D_BATCTRL_ADJ_CD(), intSize);

                case "TEMPORARYDATA.U093_DELETE_BATCH.BATCTRL_CYCLE_NBR":
                    return rdrU093_DELETE_BATCH.GetNumber("BATCTRL_CYCLE_NBR").ToString();

                case "R_BATCTRL_CALC_AR_DUE":
                    return R_BATCTRL_CALC_AR_DUE().ToString();

                case "R_BATCTRL_CALC_TOT_REV":
                    return R_BATCTRL_CALC_TOT_REV().ToString();

                case "R_BATCTRL_MANUAL_PAY_TOT":
                    return R_BATCTRL_MANUAL_PAY_TOT().ToString();

                case "D_BATCTRL_CALC_AR_DUE":
                    return D_BATCTRL_CALC_AR_DUE().ToString();

                case "D_BATCTRL_CALC_TOT_REV":
                    return D_BATCTRL_CALC_TOT_REV().ToString();

                case "D_BATCTRL_MANUAL_PAY_TOT":
                    return D_BATCTRL_MANUAL_PAY_TOT().ToString();

                default:
                    return String.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                // TODO: Some manual steps maybe required.
                Access_U093_DELETE_BATCH();
                while (rdrU093_DELETE_BATCH.Read())
                {
                    Link_ICONST_MSTR_REC();
                    while (rdrICONST_MSTR_REC.Read())
                    {
                        WriteData();
                    }
                    rdrICONST_MSTR_REC.Close();
                }

                rdrU093_DELETE_BATCH.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrU093_DELETE_BATCH == null))
            {
                rdrU093_DELETE_BATCH.Close();
                rdrU093_DELETE_BATCH = null;
            }

            if (!(rdrICONST_MSTR_REC == null))
            {
                rdrICONST_MSTR_REC.Close();
                rdrICONST_MSTR_REC = null;
            }
        }
    }
}
