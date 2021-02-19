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
    public class R070ATP : BaseRDLClass
    {
        protected const string REPORT_NAME = "R070ATP";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrF002_CLAIMS_MSTR = new Reader();
        private Reader rdrF010_PAT_MSTR = new Reader();
        private Reader rdrICONST_MSTR_REC = new Reader();
        private Reader rdrR070ATP = new Reader();
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
                SubFileName = "R070ATP";
                SubFileType = SubFileType.Keep;
                SubFileAT = "X_CLM_ID";
                Sort = "X_CLM_ID ASC";
                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return ReportData;
        }
        private void Access_F002_CLAIMS_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            strSQL.Append("SELECT ");
            strSQL.Append("CLMHDR_PAT_KEY_TYPE, ");
            strSQL.Append(" CLMHDR_PAT_KEY_DATA, ");
            strSQL.Append("KEY_CLM_BATCH_NBR, ");
            strSQL.Append("KEY_CLM_TYPE, ");
            strSQL.Append("CLMHDR_TOT_CLAIM_AR_OHIP, ");
            strSQL.Append("CLMHDR_MANUAL_AND_TAPE_PAYMENTS, ");
            strSQL.Append("CLMHDR_ADJ_OMA_CD, ");
            strSQL.Append(" CLMHDR_ADJ_OMA_SUFF, ");
            strSQL.Append(" CLMHDR_ADJ_ADJ_NBR, ");
            strSQL.Append("CLMHDR_BATCH_TYPE, ");
            strSQL.Append("CLMHDR_DATE_PERIOD_END, ");
            strSQL.Append("CLMHDR_AGENT_CD, ");
            strSQL.Append("CLMHDR_SUB_NBR, ");
            strSQL.Append("CLMHDR_BATCH_NBR, ");
            strSQL.Append(" CLMHDR_CLAIM_NBR, ");
            strSQL.Append("CLMHDR_AMT_TECH_BILLED, ");
            strSQL.Append("CLMHDR_AMT_TECH_PAID, ");
            strSQL.Append("CLMHDR_DOC_DEPT, ");
            strSQL.Append("CLMHDR_PAT_ACRONYM6, ");
            strSQL.Append(" CLMHDR_PAT_ACRONYM3, ");
            strSQL.Append("CLMHDR_ORIG_BATCH_NBR, ");
            strSQL.Append("CLMHDR_REFERENCE, ");
            strSQL.Append("KEY_CLM_CLAIM_NBR ");
            strSQL.Append("FROM INDEXED.F002_CLAIMS_MSTR_HDR ");

            strSQL.Append(Choose());
            strSQL.Append(SelectIf_F002_CLAIMS_MSTR(false));

            rdrF002_CLAIMS_MSTR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_F010_PAT_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("PAT_I_KEY, ");
            strSQL.Append(" PAT_CON_NBR, ");
            strSQL.Append(" PAT_I_NBR, ");
            strSQL.Append(" FILLER4, ");
            strSQL.Append("PAT_HEALTH_NBR, ");
            strSQL.Append("PAT_DIRECT_ALPHA, ");
            strSQL.Append(" PAT_DIRECT_YY, ");
            strSQL.Append(" PAT_DIRECT_MM, ");
            strSQL.Append(" PAT_DIRECT_DD, ");
            strSQL.Append(" PAT_DIRECT_LAST_6, ");
            strSQL.Append("PAT_CHART_NBR ");
            strSQL.Append("FROM INDEXED.F010_PAT_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("(PAT_I_KEY + RIGHT('00' + CAST(PAT_CON_NBR AS varchar(2)), 2) + RIGHT('000000000000' + CAST(PAT_I_NBR AS varchar(12)), 12) + FILLER4) = ").Append(Common.StringToField(F002_CLAIMS_MSTR_HDR_CLMHDR_PAT_OHIP_ID_OR_CHART()));

            rdrF010_PAT_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
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
            strSQL.Append("ICONST_CLINIC_NBR, ");
            strSQL.Append("ICONST_CLINIC_NAME, ");
            strSQL.Append("ICONST_DATE_PERIOD_END_YY, ");
            strSQL.Append(" ICONST_DATE_PERIOD_END_MM, ");
            strSQL.Append(" ICONST_DATE_PERIOD_END_DD ");
            strSQL.Append("FROM INDEXED.ICONST_MSTR_REC ");
            strSQL.Append("WHERE ");
            strSQL.Append("ICONST_CLINIC_NBR_1_2 = ").Append(QDesign.NConvert(QDesign.Substring(rdrF002_CLAIMS_MSTR.GetString("KEY_CLM_BATCH_NBR"), 1, 2)));

            rdrICONST_MSTR_REC.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(String.Empty);
            // TODO: CHOOSE Statement - May require manual changes.
            strChoose.Append(ReportDataFunctions.GetWhereCondition("KEY_CLM_TYPE", "B", true));
            strChoose.Append(" AND KEY_CLM_BATCH_NBR BETWEEN '60000000' AND '66ZZZ999'");

            return strChoose.ToString();
        }

        private string SelectIf_F002_CLAIMS_MSTR(bool blnAddWhere)
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            if (blnAddWhere)
            {
                strSQL.Append(" WHERE ");
            }
            else
            {
                strSQL.Append(" AND ");
            }

            strSQL.Append(" ((CLMHDR_ADJ_OMA_CD + CLMHDR_ADJ_OMA_SUFF + CLMHDR_ADJ_ADJ_NBR) = '000000' AND ");
            strSQL.Append("CLMHDR_BATCH_TYPE = 'C' AND ");
            strSQL.Append("(CLMHDR_TOT_CLAIM_AR_OHIP + CLMHDR_MANUAL_AND_TAPE_PAYMENTS) <> 0) ");

            return strSQL.ToString();
        }

        private string F002_CLAIMS_MSTR_HDR_CLMHDR_PAT_OHIP_ID_OR_CHART()
        {
            string strReturnValue = null;
            try
            {
                strReturnValue = rdrF002_CLAIMS_MSTR.GetString("CLMHDR_PAT_KEY_TYPE") + rdrF002_CLAIMS_MSTR.GetString("CLMHDR_PAT_KEY_DATA");
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string F010_PAT_MSTR_PAT_OHIP_MMYY()
        {
            string strReturnValue = null;
            try
            {
                strReturnValue = rdrF010_PAT_MSTR.GetString("PAT_DIRECT_ALPHA") + QDesign.ASCII(rdrF010_PAT_MSTR.GetNumber("PAT_DIRECT_YY"), 2) +
                                 QDesign.ASCII(rdrF010_PAT_MSTR.GetNumber("PAT_DIRECT_MM"), 2) + QDesign.ASCII(rdrF010_PAT_MSTR.GetNumber("PAT_DIRECT_DD"), 2) +
                                 rdrF010_PAT_MSTR.GetString("PAT_DIRECT_LAST_6");
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
            return strReturnValue;

        }

        private decimal X_BALANCE_DUE()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = (rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_TOT_CLAIM_AR_OHIP") + rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_MANUAL_AND_TAPE_PAYMENTS"));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private string X_PAT_ID_INFO()
        {
            string strReturnValue = String.Empty;
            try
            {
                if ((ReportDataFunctions.Exists(rdrF010_PAT_MSTR)
                            && (QDesign.NULL(rdrF010_PAT_MSTR.GetNumber("PAT_HEALTH_NBR")) == QDesign.NULL(0d))))
                {
                    strReturnValue = F010_PAT_MSTR_PAT_OHIP_MMYY();
                }
                else if ((ReportDataFunctions.Exists(rdrF010_PAT_MSTR)
                            && (QDesign.NULL(rdrF010_PAT_MSTR.GetNumber("PAT_HEALTH_NBR")) != QDesign.NULL(0d))))
                {
                    strReturnValue = QDesign.ASCII(rdrF010_PAT_MSTR.GetNumber("PAT_HEALTH_NBR"), 10);
                }
                else
                {
                    strReturnValue = rdrF010_PAT_MSTR.GetString("PAT_CHART_NBR");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private decimal X_SORT_RECORD_STATUS()
        {
            decimal decReturnValue = 0;
            try
            {
                if (((QDesign.NULL(X_BALANCE_DUE()) > QDesign.NULL(-86d))
                            && (QDesign.NULL(X_BALANCE_DUE()) < QDesign.NULL(86d))))
                {
                    decReturnValue = 9;
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

        private decimal X_AGE_YY()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = (rdrICONST_MSTR_REC.GetNumber("ICONST_DATE_PERIOD_END_YY") - QDesign.Floor((rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_DATE_PERIOD_END") / 10000)));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_AGE_MM()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = (rdrICONST_MSTR_REC.GetNumber("ICONST_DATE_PERIOD_END_MM") - QDesign.PHMod(QDesign.Floor((rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_DATE_PERIOD_END") / 100)), 100));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_MTH_OLD()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = ((X_AGE_YY() * 12)
                            + X_AGE_MM());
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_AGE_CATEGORY()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(X_MTH_OLD()) < QDesign.NULL(1d)))
                {
                    decReturnValue = 0;
                }
                else if ((QDesign.NULL(X_MTH_OLD()) < QDesign.NULL(2d)))
                {
                    decReturnValue = 1;
                }
                else if ((QDesign.NULL(X_MTH_OLD()) < QDesign.NULL(3d)))
                {
                    decReturnValue = 2;
                }
                else if ((QDesign.NULL(X_MTH_OLD()) < QDesign.NULL(4d)))
                {
                    decReturnValue = 3;
                }
                else
                {
                    decReturnValue = 4;
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private string X_DAY_OLD()
        {
            string strReturnValue = String.Empty;
            try
            {
                if ((QDesign.NULL(X_MTH_OLD()) < QDesign.NULL(1d)))
                {
                    strReturnValue = "CUR";
                }
                else if ((QDesign.NULL(X_MTH_OLD()) < QDesign.NULL(2d)))
                {
                    strReturnValue = "30";
                }
                else if ((QDesign.NULL(X_MTH_OLD()) < QDesign.NULL(3d)))
                {
                    strReturnValue = "60";
                }
                else if ((QDesign.NULL(X_MTH_OLD()) < QDesign.NULL(4d)))
                {
                    strReturnValue = "90";
                }
                else
                {
                    strReturnValue = "120";
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private decimal X_SUB_NBR()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_AGENT_CD")) == QDesign.NULL(6d)))
                {
                    decReturnValue = QDesign.NConvert(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_SUB_NBR"));
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

        private string X_CLM_ID()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = rdrF002_CLAIMS_MSTR.GetString("CLMHDR_BATCH_NBR") + QDesign.ASCII(rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_CLAIM_NBR"), 2);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private decimal X_PROF_BILL()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = (rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_TOT_CLAIM_AR_OHIP") - rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_AMT_TECH_BILLED"));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_PROF_PAID()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = ((rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_MANUAL_AND_TAPE_PAYMENTS") + rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_AMT_TECH_PAID"))
                            * -1);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_PROF_DUE()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = (X_PROF_BILL() - X_PROF_PAID());
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_TECH_DUE()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = (rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_AMT_TECH_BILLED") - rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_AMT_TECH_PAID"));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
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

        private string F002_CLAIMS_MSTR_CLMHDR_PAT_ACRONYM()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = (rdrF002_CLAIMS_MSTR.GetString("CLMHDR_PAT_ACRONYM6") + rdrF002_CLAIMS_MSTR.GetString("CLMHDR_PAT_ACRONYM3"));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.SUMMARY, "X_SORT_RECORD_STATUS", DataTypes.Numeric, 1);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR.CLMHDR_AGENT_CD", DataTypes.Numeric, 1);
                AddControl(ReportSection.SUMMARY, "X_AGE_CATEGORY", DataTypes.Numeric, 1);
                AddControl(ReportSection.SUMMARY, "X_CLM_ID", DataTypes.Character, 10);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR.CLMHDR_DOC_DEPT", DataTypes.Numeric, 2);
                AddControl(ReportSection.SUMMARY, "INDEXED.ICONST_MSTR_REC.ICONST_CLINIC_NBR_1_2", DataTypes.Numeric, 2);
                AddControl(ReportSection.SUMMARY, "INDEXED.ICONST_MSTR_REC.ICONST_CLINIC_NBR", DataTypes.Character, 4);
                AddControl(ReportSection.SUMMARY, "INDEXED.ICONST_MSTR_REC.ICONST_CLINIC_NAME", DataTypes.Character, 20);
                AddControl(ReportSection.SUMMARY, "ICONST_DATE_PERIOD_END", DataTypes.Numeric, 8);
                AddControl(ReportSection.SUMMARY, "CLMHDR_PAT_ACRONYM", DataTypes.Character, 9);
                AddControl(ReportSection.SUMMARY, "X_PAT_ID_INFO", DataTypes.Character, 12);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR.CLMHDR_AMT_TECH_BILLED", DataTypes.Numeric, 6);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR.CLMHDR_AMT_TECH_PAID", DataTypes.Numeric, 6);
                AddControl(ReportSection.SUMMARY, "X_BALANCE_DUE", DataTypes.Numeric, 7);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR.CLMHDR_DATE_PERIOD_END", DataTypes.Numeric, 8);
                AddControl(ReportSection.SUMMARY, "X_DAY_OLD", DataTypes.Character, 3);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR.CLMHDR_ORIG_BATCH_NBR", DataTypes.Character, 8);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR.CLMHDR_REFERENCE", DataTypes.Character, 11);
                AddControl(ReportSection.SUMMARY, "X_SUB_NBR", DataTypes.Numeric, 1);
                AddControl(ReportSection.SUMMARY, "X_TECH_DUE", DataTypes.Numeric, 6);
                AddControl(ReportSection.SUMMARY, "X_PROF_BILL", DataTypes.Numeric, 7);
                AddControl(ReportSection.SUMMARY, "X_PROF_PAID", DataTypes.Numeric, 7);
                AddControl(ReportSection.SUMMARY, "X_PROF_DUE", DataTypes.Numeric, 7);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR.KEY_CLM_BATCH_NBR", DataTypes.Character, 8);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR.KEY_CLM_CLAIM_NBR", DataTypes.Numeric, 2);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-05-14 10:21:00 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            // TODO: Remove duplicate controls, if there are any.
            switch (strControl)
            {
                case "X_SORT_RECORD_STATUS":
                    return X_SORT_RECORD_STATUS().ToString();
                case "INDEXED.F002_CLAIMS_MSTR.CLMHDR_AGENT_CD":
                    return rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_AGENT_CD").ToString();
                case "X_AGE_CATEGORY":
                    return X_AGE_CATEGORY().ToString();
                case "X_CLM_ID":
                    return Common.StringToField(X_CLM_ID(), intSize);
                case "INDEXED.F002_CLAIMS_MSTR.CLMHDR_DOC_DEPT":
                    return rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_DOC_DEPT").ToString();
                case "INDEXED.ICONST_MSTR_REC.ICONST_CLINIC_NBR_1_2":
                    return rdrICONST_MSTR_REC.GetNumber("ICONST_CLINIC_NBR_1_2").ToString();
                case "INDEXED.ICONST_MSTR_REC.ICONST_CLINIC_NBR":
                    return Common.StringToField(rdrICONST_MSTR_REC.GetString("ICONST_CLINIC_NBR"));
                case "INDEXED.ICONST_MSTR_REC.ICONST_CLINIC_NAME":
                    return Common.StringToField(rdrICONST_MSTR_REC.GetString("ICONST_CLINIC_NAME"));
                case "ICONST_DATE_PERIOD_END":
                    return ICONST_MSTR_REC_ICONST_DATE_PERIOD_END().ToString();
                case "CLMHDR_PAT_ACRONYM":
                    return Common.StringToField(F002_CLAIMS_MSTR_CLMHDR_PAT_ACRONYM(), intSize);
                case "X_PAT_ID_INFO":
                    return Common.StringToField(X_PAT_ID_INFO(), intSize);
                case "INDEXED.F002_CLAIMS_MSTR.CLMHDR_AMT_TECH_BILLED":
                    return rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_AMT_TECH_BILLED").ToString();
                case "INDEXED.F002_CLAIMS_MSTR.CLMHDR_AMT_TECH_PAID":
                    return rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_AMT_TECH_PAID").ToString();
                case "X_BALANCE_DUE":
                    return X_BALANCE_DUE().ToString();
                case "INDEXED.F002_CLAIMS_MSTR.CLMHDR_DATE_PERIOD_END":
                    return rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_DATE_PERIOD_END").ToString();
                case "X_DAY_OLD":
                    return Common.StringToField(X_DAY_OLD(), intSize);
                case "INDEXED.F002_CLAIMS_MSTR.CLMHDR_ORIG_BATCH_NBR":
                    return Common.StringToField(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_ORIG_BATCH_NBR"));
                case "INDEXED.F002_CLAIMS_MSTR.CLMHDR_REFERENCE":
                    return Common.StringToField(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_REFERENCE"));
                case "X_SUB_NBR":
                    return X_SUB_NBR().ToString();
                case "X_TECH_DUE":
                    return X_TECH_DUE().ToString();
                case "X_PROF_BILL":
                    return X_PROF_BILL().ToString();
                case "X_PROF_PAID":
                    return X_PROF_PAID().ToString();
                case "X_PROF_DUE":
                    return X_PROF_DUE().ToString();
                case "INDEXED.F002_CLAIMS_MSTR.KEY_CLM_BATCH_NBR":
                    return Common.StringToField(rdrF002_CLAIMS_MSTR.GetString("KEY_CLM_BATCH_NBR"));
                case "INDEXED.F002_CLAIMS_MSTR.KEY_CLM_CLAIM_NBR":
                    return rdrF002_CLAIMS_MSTR.GetNumber("KEY_CLM_CLAIM_NBR").ToString();
                default:
                    return String.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                // TODO: Some manual steps maybe required.
                Access_F002_CLAIMS_MSTR();
                while (rdrF002_CLAIMS_MSTR.Read())
                {
                    Link_F010_PAT_MSTR();
                    while (rdrF010_PAT_MSTR.Read())
                    {
                        Link_ICONST_MSTR_REC();
                        while (rdrICONST_MSTR_REC.Read())
                        {
                            WriteData();
                        }

                        rdrICONST_MSTR_REC.Close();
                    }

                    rdrF010_PAT_MSTR.Close();
                }

                rdrF002_CLAIMS_MSTR.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrF002_CLAIMS_MSTR == null))
            {
                rdrF002_CLAIMS_MSTR.Close();
                rdrF002_CLAIMS_MSTR = null;
            }

            if (!(rdrF010_PAT_MSTR == null))
            {
                rdrF010_PAT_MSTR.Close();
                rdrF010_PAT_MSTR = null;
            }

            if (!(rdrICONST_MSTR_REC == null))
            {
                rdrICONST_MSTR_REC.Close();
                rdrICONST_MSTR_REC = null;
            }
        }
    }
}
