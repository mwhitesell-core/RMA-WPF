//  !        link (nconv(ascii(batctrl-batch-nbr)[1:2]))  &
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
    public class R095B : BaseRDLClass
    {
        protected const string REPORT_NAME = "R095B";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrU095_DELETE_BATCH = new Reader();
        private Reader rdrICONST_MSTR_REC = new Reader();
        private Reader rdrU095_PURGE_VALIDATE = new Reader();
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
                SubFileName = "U095_PURGE_VALIDATE";
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
        private void Access_U095_DELETE_BATCH()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: If * is not used to select all columns, ensure the necessary columns (i.e. columns that are used to access records of other tables) are included in the SELECT statement
            strSQL.Append("SELECT ");
            strSQL.Append("BATCTRL_BATCH_NBR, ");
            strSQL.Append("ICONST_CLINIC_NBR_1_2, ");
            strSQL.Append("BATCTRL_BATCH_TYPE, ");
            strSQL.Append("BATCTRL_ADJ_CD, ");
            strSQL.Append("BATCTRL_CALC_AR_DUE, ");
            strSQL.Append("BATCTRL_CALC_TOT_REV, ");
            strSQL.Append("BATCTRL_MANUAL_PAY_TOT, ");
            strSQL.Append("BATCTRL_AGENT_CD, ");
            strSQL.Append("D_CUT_OFF_DATE, ");
            strSQL.Append("BATCTRL_CYCLE_NBR ");
            strSQL.Append("FROM TEMPORARYDATA.U095_DELETE_BATCH ");
            strSQL.Append(Choose());
            rdrU095_DELETE_BATCH.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
            strSQL = null;
        }
        private void Link_ICONST_MSTR_REC()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("ICONST_CLINIC_NBR_1_2, ");
            strSQL.Append("ICONST_DATE_PERIOD_END_YY, ");
            strSQL.Append("ICONST_DATE_PERIOD_END_MM, ");
            strSQL.Append("ICONST_DATE_PERIOD_END_DD, ");
            strSQL.Append("ICONST_CLINIC_CYCLE_NBR ");
            strSQL.Append("FROM INDEXED.ICONST_MSTR_REC ");
            strSQL.Append("WHERE ");
            strSQL.Append("ICONST_CLINIC_NBR_1_2 = ").Append(QDesign.NConvert(QDesign.Substring(rdrU095_DELETE_BATCH.GetString("BATCTRL_BATCH_NBR"), 1, 2)));
            rdrICONST_MSTR_REC.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(String.Empty);
            // TODO: CHOOSE Statement - May require manual changes.
            return strChoose.ToString().ToString();
        }

        private decimal D_CLINIC()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = QDesign.NConvert(QDesign.Substring(QDesign.ASCII(rdrU095_DELETE_BATCH.GetNumber("ICONST_CLINIC_NBR_1_2")), 1, 1));
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
                if (((rdrU095_DELETE_BATCH.GetNumber("ICONST_CLINIC_NBR_1_2") >= 61)
                            && (rdrU095_DELETE_BATCH.GetNumber("ICONST_CLINIC_NBR_1_2") <= 66)))
                {
                    decReturnValue = 60;
                }
                else if (((rdrU095_DELETE_BATCH.GetNumber("ICONST_CLINIC_NBR_1_2") >= 71)
                            && (rdrU095_DELETE_BATCH.GetNumber("ICONST_CLINIC_NBR_1_2") <= 75)))
                {
                    decReturnValue = 70;
                }
                else
                {
                    decReturnValue = rdrU095_DELETE_BATCH.GetNumber("ICONST_CLINIC_NBR_1_2");
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
            decimal decReturnValue = 0m;
            try
            {
                decReturnValue = 0m;
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
                if (((QDesign.NULL(rdrU095_DELETE_BATCH.GetString("BATCTRL_BATCH_TYPE")) == "P")
                            && (QDesign.NULL(rdrU095_DELETE_BATCH.GetString("BATCTRL_ADJ_CD")) == "C")))
                {
                    decReturnValue = (0 - rdrU095_DELETE_BATCH.GetNumber("BATCTRL_CALC_AR_DUE"));
                }
                else
                {
                    decReturnValue = rdrU095_DELETE_BATCH.GetNumber("BATCTRL_CALC_AR_DUE");
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
                if (((QDesign.NULL(rdrU095_DELETE_BATCH.GetString("BATCTRL_BATCH_TYPE")) == "P")
                            && (QDesign.NULL(rdrU095_DELETE_BATCH.GetString("BATCTRL_ADJ_CD")) == "C")))
                {
                    decReturnValue = (0 - rdrU095_DELETE_BATCH.GetNumber("BATCTRL_CALC_TOT_REV"));
                }
                else
                {
                    decReturnValue = rdrU095_DELETE_BATCH.GetNumber("BATCTRL_CALC_TOT_REV");
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
                if (((QDesign.NULL(rdrU095_DELETE_BATCH.GetString("BATCTRL_BATCH_TYPE")) == "P")
                            && (QDesign.NULL(rdrU095_DELETE_BATCH.GetString("BATCTRL_ADJ_CD")) == "C")))
                {
                    decReturnValue = (0 - rdrU095_DELETE_BATCH.GetNumber("BATCTRL_MANUAL_PAY_TOT"));
                }
                else
                {
                    decReturnValue = rdrU095_DELETE_BATCH.GetNumber("BATCTRL_MANUAL_PAY_TOT");
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
            string strReturnValue = String.Empty;
            try
            {
                if ((QDesign.NULL(rdrU095_DELETE_BATCH.GetString("BATCTRL_BATCH_TYPE")) == "C"))
                {
                    strReturnValue = QDesign.ASCII(rdrU095_DELETE_BATCH.GetNumber("BATCTRL_AGENT_CD"));
                }
                else
                {
                    strReturnValue = rdrU095_DELETE_BATCH.GetString("BATCTRL_ADJ_CD");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private decimal ICONST_MSTR_REC_ICONST_DATE_PERIOD_END()
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
                AddControl(ReportSection.SUMMARY, "D_ICONST_CLINIC_NBR_1_2", DataTypes.Numeric, 4);
                AddControl(ReportSection.SUMMARY, "ICONST_DATE_PERIOD_END", DataTypes.Numeric, 8);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U095_DELETE_BATCH.D_CUT_OFF_DATE", DataTypes.Numeric, 8);
                AddControl(ReportSection.SUMMARY, "INDEXED.ICONST_MSTR_REC.ICONST_CLINIC_CYCLE_NBR", DataTypes.Numeric, 2);
                AddControl(ReportSection.SUMMARY, "D_RETAIN_COUNT", DataTypes.Numeric, 1);
                AddControl(ReportSection.SUMMARY, "D_DELETE_COUNT", DataTypes.Numeric, 1);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U095_DELETE_BATCH.BATCTRL_BATCH_TYPE", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "D_BATCTRL_ADJ_CD", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U095_DELETE_BATCH.BATCTRL_CYCLE_NBR", DataTypes.Numeric, 3);
                AddControl(ReportSection.SUMMARY, "R_BATCTRL_CALC_AR_DUE", DataTypes.Numeric, 9);
                AddControl(ReportSection.SUMMARY, "R_BATCTRL_CALC_TOT_REV", DataTypes.Numeric, 9);
                AddControl(ReportSection.SUMMARY, "R_BATCTRL_MANUAL_PAY_TOT", DataTypes.Numeric, 9);
                AddControl(ReportSection.SUMMARY, "D_BATCTRL_CALC_AR_DUE", DataTypes.Numeric, 9);
                AddControl(ReportSection.SUMMARY, "D_BATCTRL_CALC_TOT_REV", DataTypes.Numeric, 9);
                AddControl(ReportSection.SUMMARY, "D_BATCTRL_MANUAL_PAY_TOT", DataTypes.Numeric, 9);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U095_DELETE_BATCH.BATCTRL_BATCH_NBR", DataTypes.Character, 8);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2019-07-24 7:51:42 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "D_ICONST_CLINIC_NBR_1_2":
                    return D_ICONST_CLINIC_NBR_1_2().ToString();
                case "ICONST_DATE_PERIOD_END":
                    return ICONST_MSTR_REC_ICONST_DATE_PERIOD_END().ToString();
                case "TEMPORARYDATA.U095_DELETE_BATCH.D_CUT_OFF_DATE":
                    return rdrU095_DELETE_BATCH.GetNumber("D_CUT_OFF_DATE").ToString();
                case "INDEXED.ICONST_MSTR_REC.ICONST_CLINIC_CYCLE_NBR":
                    return rdrICONST_MSTR_REC.GetNumber("ICONST_CLINIC_CYCLE_NBR").ToString();
                case "D_RETAIN_COUNT":
                    return D_RETAIN_COUNT().ToString();
                case "D_DELETE_COUNT":
                    return D_DELETE_COUNT().ToString();
                case "TEMPORARYDATA.U095_DELETE_BATCH.BATCTRL_BATCH_TYPE":
                    return Common.StringToField(rdrU095_DELETE_BATCH.GetString("BATCTRL_BATCH_TYPE"));
                case "D_BATCTRL_ADJ_CD":
                    return Common.StringToField(D_BATCTRL_ADJ_CD(), intSize);
                case "TEMPORARYDATA.U095_DELETE_BATCH.BATCTRL_CYCLE_NBR":
                    return rdrU095_DELETE_BATCH.GetNumber("BATCTRL_CYCLE_NBR").ToString();
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
                case "TEMPORARYDATA.U095_DELETE_BATCH.BATCTRL_BATCH_NBR":
                    return Common.StringToField(rdrU095_DELETE_BATCH.GetString("BATCTRL_BATCH_NBR"));
                default:
                    return String.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                // TODO: Some manual steps maybe required.
                Access_U095_DELETE_BATCH();
                while (rdrU095_DELETE_BATCH.Read())
                {
                    Link_ICONST_MSTR_REC();
                    while (rdrICONST_MSTR_REC.Read())
                    {
                        WriteData();
                    }

                    rdrICONST_MSTR_REC.Close();
                }

                rdrU095_DELETE_BATCH.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if (!(rdrU095_DELETE_BATCH == null))
            {
                rdrU095_DELETE_BATCH.Close();
                rdrU095_DELETE_BATCH = null;
            }

            if (!(rdrICONST_MSTR_REC == null))
            {
                rdrICONST_MSTR_REC.Close();
                rdrICONST_MSTR_REC = null;
            }
        }
    }
}
