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
    public class R093D : BaseRDLClass
    {
        protected const string REPORT_NAME = "R093D";
        protected const bool REPORT_HAS_PARAMETERS = true;

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
                Sort = "D_ICONST_CLINIC_NBR_1_2 ASC, BATCTRL_BATCH_TYPE ASC, BATCTRL_ADJ_CD ASC";
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
            strSQL.Append("ICONST_CLINIC_CYCLE_NBR ");
            strSQL.Append("FROM INDEXED.ICONST_MSTR_REC ");
            strSQL.Append("WHERE ");
            strSQL.Append("ICONST_CLINIC_NBR_1_2 = ").Append(QDesign.NConvert(QDesign.Substring(rdrU093_DELETE_BATCH.GetString("BATCTRL_BATCH_NBR"), 1, 2)));

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
                if (QDesign.NULL(rdrICONST_MSTR_REC.GetNumber("ICONST_CLINIC_NBR_1_2")) >= 61 && QDesign.NULL(rdrICONST_MSTR_REC.GetNumber("ICONST_CLINIC_NBR_1_2")) <= 65)
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

        private decimal D_CLINIC_PARM()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((ReportFunctions.astrScreenParameters[0].ToString().Trim() != String.Empty))
                {
                    decReturnValue = Decimal.Parse(ReportFunctions.astrScreenParameters[0].ToString());
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        public override bool SelectIf()
        {
            bool blnSelected = false;
            if (QDesign.NULL(D_ICONST_CLINIC_NBR_1_2()) == QDesign.NULL(D_CLINIC_PARM()) && (rdrU093_DELETE_BATCH.GetString("BATCTRL_BATCH_TYPE") == "A" || rdrU093_DELETE_BATCH.GetString("BATCTRL_BATCH_TYPE") == "P"))
            {
                blnSelected = true;
            }

            return blnSelected;
        }

        private string D_TYPE()
        {
            string strReturnValue = String.Empty;
            try
            {
                if ((QDesign.NULL(rdrU093_DELETE_BATCH.GetString("BATCTRL_BATCH_TYPE")) == "A"))
                {
                    strReturnValue = "ADJUSTMENTS";
                }
                else if ((QDesign.NULL(rdrU093_DELETE_BATCH.GetString("BATCTRL_BATCH_TYPE")) == "P"))
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

        private decimal D_CLMHDR_TOT_CLAIM_AR_OHIP()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = rdrU093_DELETE_BATCH.GetNumber("CLMHDR_TOT_CLAIM_AR_OHIP") + rdrU093_DELETE_BATCH.GetNumber("CLMHDR_MANUAL_AND_TAPE_PAYMENTS");
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal D_CLMHDR_TOT_CLAIM_AR_OMA()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = rdrU093_DELETE_BATCH.GetNumber("CLMHDR_TOT_CLAIM_AR_OMA") + rdrU093_DELETE_BATCH.GetNumber("CLMHDR_MANUAL_AND_TAPE_PAYMENTS");
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
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U093_DELETE_BATCH.BATCTRL_BATCH_TYPE", DataTypes.Character, 1);
                AddControl(ReportSection.HEADING_AT, "D_TYPE", DataTypes.Character, 11);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.U093_DELETE_BATCH.BATCTRL_ADJ_CD", DataTypes.Character, 1);
                AddControl(ReportSection.FOOTING_AT, "D_CLMHDR_TOT_CLAIM_AR_OHIP", DataTypes.Numeric, 14);
                AddControl(ReportSection.FOOTING_AT, "D_CLMHDR_TOT_CLAIM_AR_OMA", DataTypes.Numeric, 14);
                AddControl(ReportSection.FOOTING_AT, "D_DELETE_COUNT", DataTypes.Numeric, 9);
                AddControl(ReportSection.FOOTING_AT, "D_ICONST_CLINIC_NBR_1_2", DataTypes.Numeric, 9);
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
            // TODO: Remove duplicate controls, if there are any.
            switch (strControl)
            {
                case "TEMPORARYDATA.U093_DELETE_BATCH.BATCTRL_BATCH_TYPE":
                    return Common.StringToField(rdrU093_DELETE_BATCH.GetString("BATCTRL_BATCH_TYPE"));

                case "D_TYPE":
                    return Common.StringToField(D_TYPE(), intSize);

                case "TEMPORARYDATA.U093_DELETE_BATCH.BATCTRL_ADJ_CD":
                    return Common.StringToField(rdrU093_DELETE_BATCH.GetString("BATCTRL_ADJ_CD"));

                case "D_CLMHDR_TOT_CLAIM_AR_OHIP":
                    return D_CLMHDR_TOT_CLAIM_AR_OHIP().ToString();

                case "D_CLMHDR_TOT_CLAIM_AR_OMA":
                    return D_CLMHDR_TOT_CLAIM_AR_OMA().ToString();

                case "D_DELETE_COUNT":
                    return D_DELETE_COUNT().ToString();

                case "D_ICONST_CLINIC_NBR_1_2":
                    return D_ICONST_CLINIC_NBR_1_2().ToString();

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
