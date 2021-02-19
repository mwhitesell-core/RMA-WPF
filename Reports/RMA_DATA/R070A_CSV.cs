//  DOC: R070_CSV.QZS
//  DOC: ACCOUNTS RECEIVABLE
//  PROGRAM PURPOSE : ACCOUNTS RECEIVABLE (DETAIL REPORT IN EXCEL)
//  DATE        BY WHOM  DESCRIPTION
//  2015/Nov/17  MC       original  (clone from r070atp.qzs)
//  2016/Jan/04    MC1  change writeoff to be `Y` or blank instead of 9 or 0 as Brad/Yas agrees
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
    public class R070A_CSV : BaseRDLClass
    {
        protected const string REPORT_NAME = "R070A_CSV";
        protected const bool REPORT_HAS_PARAMETERS = true;
        private Reader rdrF002_CLAIMS_MSTR = new Reader();
        private Reader rdrICONST_MSTR_REC = new Reader();
        private Reader rdrF020_DOCTOR_MSTR = new Reader();
        private Reader rdrF010_PAT_MSTR = new Reader();
        private Reader rdrF070_DEPT_MSTR = new Reader();
        private Reader rdrR070A_CSV = new Reader();
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
                SubFileName = "R070A_CSV";
                SubFileType = SubFileType.Keep;
                SubFileAT = "";
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
            strSQL.Append("KEY_CLM_BATCH_NBR, ");
            strSQL.Append("KEY_CLM_CLAIM_NBR, ");
            strSQL.Append("CLMHDR_PAT_KEY_TYPE, ");
            strSQL.Append(" CLMHDR_PAT_KEY_DATA, ");
            strSQL.Append("CLMHDR_DOC_DEPT, ");
            strSQL.Append("KEY_CLM_TYPE, ");
            strSQL.Append("KEY_CLM_SERV_CODE, ");
            strSQL.Append("KEY_CLM_ADJ_NBR, ");
            strSQL.Append("CLMHDR_TOT_CLAIM_AR_OHIP, ");
            strSQL.Append("CLMHDR_MANUAL_AND_TAPE_PAYMENTS, ");
            strSQL.Append("CLMHDR_BATCH_TYPE, ");
            strSQL.Append("CLMHDR_DATE_PERIOD_END, ");
            strSQL.Append("CLMHDR_AGENT_CD, ");
            strSQL.Append("CLMHDR_SUB_NBR, ");
            strSQL.Append("CLMHDR_BATCH_NBR, ");
            strSQL.Append(" CLMHDR_CLAIM_NBR, ");
            strSQL.Append(" CLMHDR_ADJ_OMA_CD, ");
            strSQL.Append(" CLMHDR_ADJ_OMA_SUFF, ");
            strSQL.Append(" CLMHDR_ADJ_ADJ_NBR, ");
            strSQL.Append("CLMHDR_AMT_TECH_BILLED, ");
            strSQL.Append("CLMHDR_AMT_TECH_PAID, ");
            strSQL.Append("CLMHDR_PAT_ACRONYM6, ");
            strSQL.Append(" CLMHDR_PAT_ACRONYM3, ");
            strSQL.Append("CLMHDR_STATUS_OHIP, ");
            strSQL.Append("CLMHDR_SERV_DATE, ");
            strSQL.Append("CLMHDR_TAPE_SUBMIT_IND, ");
            strSQL.Append("CLMHDR_REFERENCE ");
            strSQL.Append("FROM INDEXED.F002_CLAIMS_MSTR_HDR ");
            strSQL.Append(Choose());
            strSQL.Append(SelectIf_F002_CLAIMS_MSTR(false));
            rdrF002_CLAIMS_MSTR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_ICONST_MSTR_REC()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("ICONST_CLINIC_NBR_1_2, ");
            strSQL.Append("ICONST_MONTHEND, ");
            strSQL.Append("ICONST_DATE_PERIOD_END_YY, ");
            strSQL.Append("ICONST_DATE_PERIOD_END_MM, ");
            strSQL.Append("ICONST_CLINIC_CARD_COLOUR ");
            strSQL.Append("FROM INDEXED.ICONST_MSTR_REC ");
            strSQL.Append("WHERE ");
            strSQL.Append("ICONST_CLINIC_NBR_1_2 = ").Append(QDesign.NConvert(QDesign.Substring(rdrF002_CLAIMS_MSTR.GetString("KEY_CLM_BATCH_NBR"), 1, 2)));
            rdrICONST_MSTR_REC.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_F020_DOCTOR_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("DOC_AFP_PAYM_GROUP ");
            strSQL.Append("FROM INDEXED.F020_DOCTOR_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_NBR = ").Append(Common.StringToField(QDesign.Substring(rdrF002_CLAIMS_MSTR.GetString("KEY_CLM_BATCH_NBR"), 3, 3)));
            rdrF020_DOCTOR_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
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
            strSQL.Append("PAT_DIRECT_YY, ");
            strSQL.Append("PAT_DIRECT_MM, ");
            strSQL.Append("PAT_DIRECT_DD, ");
            strSQL.Append("PAT_DIRECT_LAST_6, ");
            strSQL.Append("PAT_CHART_NBR ");
            strSQL.Append("FROM INDEXED.F010_PAT_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("PAT_I_KEY = ").Append(Common.StringToField(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_PAT_KEY_TYPE")));
            strSQL.Append(" AND PAT_CON_NBR = ").Append(QDesign.NConvert(QDesign.Substring(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_PAT_KEY_DATA"), 1, 2)));
            strSQL.Append(" AND PAT_I_NBR = ").Append(QDesign.NConvert(QDesign.Substring(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_PAT_KEY_DATA"), 3, 12)));
            strSQL.Append(" AND FILLER4 = ").Append(Common.StringToField(QDesign.Substring(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_PAT_KEY_DATA"), 15, 1)));
            rdrF010_PAT_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_F070_DEPT_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("DEPT_NBR, ");
            strSQL.Append("DEPT_COMPANY ");
            strSQL.Append("FROM INDEXED.F070_DEPT_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DEPT_NBR = ").Append(rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_DOC_DEPT"));
            rdrF070_DEPT_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(String.Empty);
            strChoose.Append(ReportDataFunctions.GetWhereCondition("KEY_CLM_TYPE", "B", true));
            strChoose.Append(ReportDataFunctions.GetWhereCondition("KEY_CLM_SERV_CODE", "00000"));
            strChoose.Append(ReportDataFunctions.GetWhereCondition("KEY_CLM_ADJ_NBR", "0"));
            return strChoose.ToString().ToString();
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

            // TODO: SelectIf Statement - May require manual changes.
            strSQL.Append("(CLMHDR_BATCH_TYPE = 'C' AND ");
            strSQL.Append("(CLMHDR_TOT_CLAIM_AR_OHIP + CLMHDR_MANUAL_AND_TAPE_PAYMENTS) <>  0)");
            return strSQL.ToString().ToString();
        }

        public override bool SelectIf()
        {
            bool blnSelected = false;
            if ((QDesign.NULL(rdrICONST_MSTR_REC.GetString("ICONST_MONTHEND")) == QDesign.NULL(X_MONTHEND())))
            {
                blnSelected = true;
            }

            return blnSelected;
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

        private string X_MONTHEND()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = QDesign.NULL(ReportFunctions.astrScreenParameters[0].ToString());
                //  Prompt String: "Enter Monthend (1,2,3): "
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_PAT_ID_INFO()
        {
            string strReturnValue = String.Empty;
            try
            {
                if (ReportDataFunctions.Exists(rdrF010_PAT_MSTR) && QDesign.NULL(rdrF010_PAT_MSTR.GetNumber("PAT_HEALTH_NBR")) == QDesign.NULL(0d))
                {
                    strReturnValue = rdrF010_PAT_MSTR.GetString("PAT_DIRECT_ALPHA").PadRight(3, ' ') + QDesign.ASCII(rdrF010_PAT_MSTR.GetNumber("PAT_DIRECT_YY"), 2) + QDesign.ASCII(rdrF010_PAT_MSTR.GetNumber("PAT_DIRECT_MM"), 2) + QDesign.ASCII(rdrF010_PAT_MSTR.GetNumber("PAT_DIRECT_DD"), 2) + rdrF010_PAT_MSTR.GetString("PAT_DIRECT_LAST_6");
                }
                else if (ReportDataFunctions.Exists(rdrF010_PAT_MSTR) && QDesign.NULL(rdrF010_PAT_MSTR.GetNumber("PAT_HEALTH_NBR")) != QDesign.NULL(0d))
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

        private string X_SORT_RECORD_STATUS()
        {
            string strReturnValue = String.Empty;
            try
            {
                if (((QDesign.NULL(X_BALANCE_DUE()) > QDesign.NULL(-86d))
                            && (QDesign.NULL(X_BALANCE_DUE()) < QDesign.NULL(86d))))
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
                decReturnValue = ((X_AGE_YY() * 12) + X_AGE_MM());
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
                else if ((QDesign.NULL(X_MTH_OLD()) < QDesign.NULL(5d)))
                {
                    strReturnValue = "120";
                }
                else if ((QDesign.NULL(X_MTH_OLD()) < QDesign.NULL(6d)))
                {
                    strReturnValue = "150";
                }
                else
                {
                    strReturnValue = "180";
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

        private string X_INCL_PAYROLL()
        {
            string strReturnValue = String.Empty;
            try
            {
                if ((((QDesign.NULL(rdrICONST_MSTR_REC.GetNumber("ICONST_CLINIC_NBR_1_2")) == QDesign.NULL(22d))
                            || ((QDesign.NULL(rdrICONST_MSTR_REC.GetNumber("ICONST_CLINIC_NBR_1_2")) == QDesign.NULL(23d))
                            || ((QDesign.NULL(rdrICONST_MSTR_REC.GetNumber("ICONST_CLINIC_NBR_1_2")) == QDesign.NULL(24d))
                            || ((QDesign.NULL(rdrICONST_MSTR_REC.GetNumber("ICONST_CLINIC_NBR_1_2")) == QDesign.NULL(25d))
                            || (QDesign.NULL(rdrICONST_MSTR_REC.GetNumber("ICONST_CLINIC_NBR_1_2")) == QDesign.NULL(26d))))))
                            || ((QDesign.NULL(rdrICONST_MSTR_REC.GetString("ICONST_CLINIC_CARD_COLOUR")) == "Y")
                            && ((QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_AFP_PAYM_GROUP")) != QDesign.NULL(" "))
                            && ((QDesign.NULL(rdrICONST_MSTR_REC.GetNumber("ICONST_CLINIC_NBR_1_2")) < QDesign.NULL(71d))
                            || (QDesign.NULL(rdrICONST_MSTR_REC.GetNumber("ICONST_CLINIC_NBR_1_2")) > QDesign.NULL(75d)))))))
                {
                    strReturnValue = "Y";
                }
                else
                {
                    strReturnValue = "N";
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string F002_CLAIMS_MSTR_HDR_CLMHDR_PAT_ACRONYM()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = rdrF002_CLAIMS_MSTR.GetString("CLMHDR_PAT_ACRONYM6").PadRight(6, ' ') + rdrF002_CLAIMS_MSTR.GetString("CLMHDR_PAT_ACRONYM3").PadRight(3, ' ');
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
                AddControl(ReportSection.SUMMARY, "X_SORT_RECORD_STATUS", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR.CLMHDR_AGENT_CD", DataTypes.Numeric, 1);
                AddControl(ReportSection.SUMMARY, "INDEXED.F070_DEPT_MSTR.DEPT_COMPANY", DataTypes.Numeric, 2);
                AddControl(ReportSection.SUMMARY, "INDEXED.ICONST_MSTR_REC.ICONST_CLINIC_NBR_1_2", DataTypes.Numeric, 2);
                AddControl(ReportSection.SUMMARY, "CLMHDR_PAT_ACRONYM", DataTypes.Character, 9);
                AddControl(ReportSection.SUMMARY, "X_PAT_ID_INFO", DataTypes.Character, 12);
                AddControl(ReportSection.SUMMARY, "X_CLM_ID", DataTypes.Character, 10);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR.CLMHDR_DOC_DEPT", DataTypes.Numeric, 2);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR.CLMHDR_STATUS_OHIP", DataTypes.Character, 2);
                AddControl(ReportSection.SUMMARY, "X_SUB_NBR", DataTypes.Numeric, 1);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR.CLMHDR_TOT_CLAIM_AR_OHIP", DataTypes.Numeric, 7);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR.CLMHDR_MANUAL_AND_TAPE_PAYMENTS", DataTypes.Numeric, 7);
                AddControl(ReportSection.SUMMARY, "X_BALANCE_DUE", DataTypes.Numeric, 7);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR.CLMHDR_DATE_PERIOD_END", DataTypes.Numeric, 8);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR.CLMHDR_SERV_DATE", DataTypes.Numeric, 8);
                AddControl(ReportSection.SUMMARY, "X_DAY_OLD", DataTypes.Character, 3);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR.CLMHDR_TAPE_SUBMIT_IND", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR.CLMHDR_REFERENCE", DataTypes.Character, 11);
                AddControl(ReportSection.SUMMARY, "X_INCL_PAYROLL", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR.CLMHDR_BATCH_NBR", DataTypes.Character, 8);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR.CLMHDR_CLAIM_NBR", DataTypes.Numeric, 2);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-07-20 11:56:25 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            // TODO: Remove duplicate controls, if there are any.
            switch (strControl)
            {
                case "X_SORT_RECORD_STATUS":
                    return Common.StringToField(X_SORT_RECORD_STATUS(), intSize);
                case "INDEXED.F002_CLAIMS_MSTR.CLMHDR_AGENT_CD":
                    return rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_AGENT_CD").ToString();
                case "INDEXED.F070_DEPT_MSTR.DEPT_COMPANY":
                    return rdrF070_DEPT_MSTR.GetNumber("DEPT_COMPANY").ToString();
                case "INDEXED.ICONST_MSTR_REC.ICONST_CLINIC_NBR_1_2":
                    return rdrICONST_MSTR_REC.GetNumber("ICONST_CLINIC_NBR_1_2").ToString();
                case "CLMHDR_PAT_ACRONYM":
                    return Common.StringToField(F002_CLAIMS_MSTR_HDR_CLMHDR_PAT_ACRONYM());
                case "X_PAT_ID_INFO":
                    return Common.StringToField(X_PAT_ID_INFO(), intSize);
                case "X_CLM_ID":
                    return Common.StringToField(X_CLM_ID(), intSize);
                case "INDEXED.F002_CLAIMS_MSTR.CLMHDR_DOC_DEPT":
                    return rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_DOC_DEPT").ToString();
                case "INDEXED.F002_CLAIMS_MSTR.CLMHDR_STATUS_OHIP":
                    return Common.StringToField(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_STATUS_OHIP"));
                case "X_SUB_NBR":
                    return X_SUB_NBR().ToString();
                case "INDEXED.F002_CLAIMS_MSTR.CLMHDR_TOT_CLAIM_AR_OHIP":
                    return rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_TOT_CLAIM_AR_OHIP").ToString();
                case "INDEXED.F002_CLAIMS_MSTR.CLMHDR_MANUAL_AND_TAPE_PAYMENTS":
                    return rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_MANUAL_AND_TAPE_PAYMENTS").ToString();
                case "X_BALANCE_DUE":
                    return X_BALANCE_DUE().ToString();
                case "INDEXED.F002_CLAIMS_MSTR.CLMHDR_DATE_PERIOD_END":
                    return rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_DATE_PERIOD_END").ToString();
                case "INDEXED.F002_CLAIMS_MSTR.CLMHDR_SERV_DATE":
                    return rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_SERV_DATE").ToString();
                case "X_DAY_OLD":
                    return Common.StringToField(X_DAY_OLD(), intSize);
                case "INDEXED.F002_CLAIMS_MSTR.CLMHDR_TAPE_SUBMIT_IND":
                    return Common.StringToField(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_TAPE_SUBMIT_IND"));
                case "INDEXED.F002_CLAIMS_MSTR.CLMHDR_REFERENCE":
                    return Common.StringToField(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_REFERENCE"));
                case "X_INCL_PAYROLL":
                    return Common.StringToField(X_INCL_PAYROLL(), intSize);
                case "INDEXED.F002_CLAIMS_MSTR.CLMHDR_BATCH_NBR":
                    return Common.StringToField(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_BATCH_NBR"));
                case "INDEXED.F002_CLAIMS_MSTR.CLMHDR_CLAIM_NBR":
                    return rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_CLAIM_NBR").ToString();
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
                    Link_ICONST_MSTR_REC();
                    while (rdrICONST_MSTR_REC.Read())
                    {
                        Link_F020_DOCTOR_MSTR();
                        while (rdrF020_DOCTOR_MSTR.Read())
                        {
                            Link_F010_PAT_MSTR();
                            while (rdrF010_PAT_MSTR.Read())
                            {
                                Link_F070_DEPT_MSTR();
                                while (rdrF070_DEPT_MSTR.Read())
                                {
                                    WriteData();
                                }

                                rdrF070_DEPT_MSTR.Close();
                            }

                            rdrF010_PAT_MSTR.Close();
                        }

                        rdrF020_DOCTOR_MSTR.Close();
                    }

                    rdrICONST_MSTR_REC.Close();
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

            if (!(rdrICONST_MSTR_REC == null))
            {
                rdrICONST_MSTR_REC.Close();
                rdrICONST_MSTR_REC = null;
            }

            if (!(rdrF020_DOCTOR_MSTR == null))
            {
                rdrF020_DOCTOR_MSTR.Close();
                rdrF020_DOCTOR_MSTR = null;
            }

            if (!(rdrF010_PAT_MSTR == null))
            {
                rdrF010_PAT_MSTR.Close();
                rdrF010_PAT_MSTR = null;
            }

            if (!(rdrF070_DEPT_MSTR == null))
            {
                rdrF070_DEPT_MSTR.Close();
                rdrF070_DEPT_MSTR = null;
            }
        }
    }
}
