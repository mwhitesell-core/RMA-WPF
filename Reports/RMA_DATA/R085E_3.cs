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
    public class R085E_3 : BaseRDLClass
    {
        protected const string REPORT_NAME = "R085E_3";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrU085D = new Reader();
        private Reader rdrF002_CLAIMS_MSTR = new Reader();
        private Reader rdrF010_PAT_MSTR = new Reader();
        private Reader rdrF020_DOCTOR_MSTR = new Reader();
        private Reader rdrREJECTED_CLAIMS = new Reader();
        private Reader rdrF030_LOCATIONS_MSTR = new Reader();
        private Reader rdrTMP_COUNTERS = new Reader();
        private Reader rdrR085E_RUN_DATE = new Reader();
        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
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
        private void Access_U085D()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: If * is not used to select all columns, ensure the necessary columns (i.e. columns that are used to access records of other tables) are included in the SELECT statement
            strSQL.Append("SELECT ");
            strSQL.Append("CLAIM_NBR, ");
            strSQL.Append("CLMHDR_PAT_OHIP_ID_OR_CHART, ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("CLMHDR_LOC, ");
            strSQL.Append("MESS_CODE ");
            strSQL.Append("FROM TEMPORARYDATA.U085D ");
            strSQL.Append(Choose());
            rdrU085D.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
            strSQL = null;
        }
        private void Link_F002_CLAIMS_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("KEY_CLM_TYPE, ");
            strSQL.Append("KEY_CLM_BATCH_NBR, ");
            strSQL.Append("KEY_CLM_CLAIM_NBR, ");
            strSQL.Append("KEY_CLM_SERV_CODE, ");
            strSQL.Append("KEY_CLM_ADJ_NBR, ");
            strSQL.Append("CLMHDR_CONFIDENTIAL_FLAG ");
            strSQL.Append("FROM INDEXED.F002_CLAIMS_MSTR_HDR ");
            strSQL.Append("WHERE ");
            strSQL.Append("KEY_CLM_TYPE = ").Append(Common.StringToField("B"));
            strSQL.Append(" AND KEY_CLM_BATCH_NBR = ").Append(Common.StringToField(QDesign.Substring(rdrU085D.GetString("CLAIM_NBR"), 1, 8)));
            strSQL.Append(" AND KEY_CLM_CLAIM_NBR = ").Append(QDesign.NConvert(QDesign.Substring(rdrU085D.GetString("CLAIM_NBR"), 9, 2)));
            strSQL.Append(" AND KEY_CLM_SERV_CODE = ").Append(Common.StringToField("00000"));
            strSQL.Append(" AND KEY_CLM_ADJ_NBR = ").Append(Common.StringToField("0"));
            rdrF002_CLAIMS_MSTR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_F010_PAT_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("PAT_GIVEN_NAME_FIRST1, ");
            strSQL.Append("FILLER3, ");
            strSQL.Append("PAT_SURNAME_FIRST3, ");
            strSQL.Append("PAT_SURNAME_LAST22, ");
            strSQL.Append("SUBSCR_ADDR1, ");
            strSQL.Append("SUBSCR_ADDR2, ");
            strSQL.Append("SUBSCR_ADDR3, ");
            strSQL.Append("SUBSCR_PROV_CD, ");
            strSQL.Append("SUBSCR_POST_CD1, ");
            strSQL.Append("SUBSCR_POST_CD2, ");
            strSQL.Append("SUBSCR_POST_CD3, ");
            strSQL.Append("SUBSCR_POST_CD4, ");
            strSQL.Append("SUBSCR_POST_CD5, ");
            strSQL.Append("SUBSCR_POST_CD6, ");
            strSQL.Append("PAT_HEALTH_NBR, ");
            strSQL.Append("PAT_VERSION_CD, ");
            strSQL.Append("PAT_BIRTH_DATE_YY, ");
            strSQL.Append("PAT_BIRTH_DATE_MM, ");
            strSQL.Append("PAT_BIRTH_DATE_DD, ");
            strSQL.Append("PAT_DATE_LAST_ELIG_MAILING, ");
            strSQL.Append("PAT_NO_OF_LETTER_SENT ");
            strSQL.Append("FROM INDEXED.F010_PAT_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("PAT_I_KEY = ").Append(Common.StringToField(QDesign.Substring(rdrU085D.GetString("CLMHDR_PAT_OHIP_ID_OR_CHART"), 1, 1)));
            strSQL.Append(" AND PAT_CON_NBR = ").Append(QDesign.NConvert(QDesign.Substring(rdrU085D.GetString("CLMHDR_PAT_OHIP_ID_OR_CHART"), 2, 2)));
            strSQL.Append(" AND PAT_I_NBR = ").Append(QDesign.NConvert(QDesign.Substring(rdrU085D.GetString("CLMHDR_PAT_OHIP_ID_OR_CHART"), 4, 12)));
            strSQL.Append(" AND FILLER4 = ").Append(Common.StringToField(QDesign.Substring(rdrU085D.GetString("CLMHDR_PAT_OHIP_ID_OR_CHART"), 16, 1)));
            rdrF010_PAT_MSTR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_F020_DOCTOR_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("DOC_NAME, ");
            strSQL.Append("DOC_INIT1, ");
            strSQL.Append("DOC_INIT2, ");
            strSQL.Append("DOC_INIT3 ");
            strSQL.Append("FROM INDEXED.F020_DOCTOR_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_NBR = ").Append(Common.StringToField(rdrU085D.GetString("DOC_NBR")));
            rdrF020_DOCTOR_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_REJECTED_CLAIMS()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("CLAIM_NBR, ");
            strSQL.Append("LOGICALLY_DELETED_FLAG, ");
            strSQL.Append("CLMHDR_SUBMIT_DATE ");
            strSQL.Append("FROM INDEXED.REJECTED_CLAIMS ");
            strSQL.Append("WHERE ");
            strSQL.Append("CLAIM_NBR = ").Append(Common.StringToField(rdrU085D.GetString("CLAIM_NBR")));
            rdrREJECTED_CLAIMS.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_F030_LOCATIONS_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("LOC_NBR, ");
            strSQL.Append("LOC_NAME ");
            strSQL.Append("FROM INDEXED.F030_LOCATIONS_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("LOC_NBR = ").Append(Common.StringToField(rdrU085D.GetString("CLMHDR_LOC")));
            rdrF030_LOCATIONS_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_TMP_COUNTERS()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("TMP_COUNTER_KEY, ");
            strSQL.Append("TMP_COUNTER_1 ");
            strSQL.Append("FROM INDEXED.TMP_COUNTERS ");
            strSQL.Append("WHERE ");
            strSQL.Append("TMP_COUNTER_KEY = ").Append(1);
            rdrTMP_COUNTERS.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Access_R085E_RUN_DATE()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: If * is not used to select all columns, ensure the necessary columns (i.e. columns that are used to access records of other tables) are included in the SELECT statement
            strSQL.Append("SELECT TOP 1 ");
            strSQL.Append("OHIP_RUN_DATE ");
            strSQL.Append("FROM TEMPORARYDATA.R085E_RUN_DATE ");
            strSQL.Append(Choose());
            rdrR085E_RUN_DATE.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
            strSQL = null;
        }

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(String.Empty);
            // TODO: CHOOSE Statement - May require manual changes.
            return strChoose.ToString().ToString();
        }

        public override bool SelectIf()
        {
            bool blnSelected = false;
            
            if (QDesign.NULL(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_CONFIDENTIAL_FLAG")) != "R"
                        && QDesign.NULL(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_CONFIDENTIAL_FLAG")) != "Y"
                        && QDesign.NULL(rdrREJECTED_CLAIMS.GetString("LOGICALLY_DELETED_FLAG")) != "Y"
                        && QDesign.NULL(QDesign.Substring(rdrU085D.GetString("CLAIM_NBR"), 1, 2)) != "87"
                        && (QDesign.NULL(rdrREJECTED_CLAIMS.GetNumber("CLMHDR_SUBMIT_DATE")) == QDesign.NULL(rdrR085E_RUN_DATE.GetNumber("OHIP_RUN_DATE"))
                        || ((QDesign.NULL(rdrF010_PAT_MSTR.GetNumber("PAT_DATE_LAST_ELIG_MAILING")) == QDesign.NULL(0d)
                        || QDesign.NULL(rdrF010_PAT_MSTR.GetNumber("PAT_DATE_LAST_ELIG_MAILING")) == QDesign.NULL(160100d)
                        || QDesign.NULL(rdrF010_PAT_MSTR.GetNumber("PAT_DATE_LAST_ELIG_MAILING")) == QDesign.NULL(19160100d)
                        || (QDesign.NULL(D_TEST_DATE()) > QDesign.NULL(35d)
                        && QDesign.NULL(rdrF010_PAT_MSTR.GetNumber("PAT_NO_OF_LETTER_SENT")) < QDesign.NULL(2d)))
                        && ((QDesign.NULL(rdrREJECTED_CLAIMS.GetNumber("CLMHDR_SUBMIT_DATE")) < QDesign.NULL(rdrR085E_RUN_DATE.GetNumber("OHIP_RUN_DATE"))
                        && QDesign.NULL(rdrTMP_COUNTERS.GetNumber("TMP_COUNTER_1")) > QDesign.NULL(1d))
                        || (rdrREJECTED_CLAIMS.GetNumber("CLMHDR_SUBMIT_DATE") <= rdrR085E_RUN_DATE.GetNumber("OHIP_RUN_DATE")
                        && QDesign.NULL(rdrTMP_COUNTERS.GetNumber("TMP_COUNTER_1")) == QDesign.NULL(1d))))))
            {
                blnSelected = true;
            }

            return blnSelected;
        }

        private decimal D_TEST_DATE()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrF010_PAT_MSTR.GetNumber("PAT_DATE_LAST_ELIG_MAILING")) > QDesign.NULL(0d)))
                {
                    decReturnValue = (QDesign.Days(QDesign.GetDateFromYYYYMMDDDecimal(rdrR085E_RUN_DATE.GetNumber("OHIP_RUN_DATE"))) - QDesign.Days(QDesign.GetDateFromYYYYMMDDDecimal(rdrF010_PAT_MSTR.GetNumber("PAT_DATE_LAST_ELIG_MAILING"))));
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private string X_PAT_NAME()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = QDesign.Pack(rdrF010_PAT_MSTR.GetString("PAT_GIVEN_NAME_FIRST1") + rdrF010_PAT_MSTR.GetString("FILLER3") + " " + rdrF010_PAT_MSTR.GetString("PAT_SURNAME_FIRST3") + rdrF010_PAT_MSTR.GetString("PAT_SURNAME_LAST22"));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private decimal X_INDEX()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = QDesign.Index(rdrF020_DOCTOR_MSTR.GetString("DOC_NAME"), "MED PR");
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private string X_DOC_NAME()
        {
            string strReturnValue = String.Empty;
            try
            {
                if (QDesign.NULL(X_INDEX()) == QDesign.NULL(0d))
                {
                    strReturnValue = QDesign.Pack("Dr. " + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT1") + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT2") + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT3") + " " + rdrF020_DOCTOR_MSTR.GetString("DOC_NAME"));
                }
                else
                {
                    strReturnValue = QDesign.Pack("Dr. " + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT1") + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT2") + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT3") + " " + QDesign.Substring(rdrF020_DOCTOR_MSTR.GetString("DOC_NAME"), 1, (Convert.ToInt16(X_INDEX()) - 1)));
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_ADDR_1()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = X_PAT_NAME();
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_ADDR_3()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = rdrF010_PAT_MSTR.GetString("SUBSCR_ADDR1") + " " + rdrF010_PAT_MSTR.GetString("SUBSCR_ADDR2");
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_ADDR_4()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = rdrF010_PAT_MSTR.GetString("SUBSCR_ADDR3").TrimEnd() + "  " + rdrF010_PAT_MSTR.GetString("SUBSCR_PROV_CD") + " " + rdrF010_PAT_MSTR.GetString("SUBSCR_POST_CD1") + " " + rdrF010_PAT_MSTR.GetString("SUBSCR_POST_CD2");
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_LETTER_NBR()
        {
            string strReturnValue = String.Empty;
            try
            {
                if (QDesign.NULL(rdrU085D.GetString("MESS_CODE")) == QDesign.NULL("EH2") || QDesign.NULL(rdrU085D.GetString("MESS_CODE")) == QDesign.NULL("VH4") || QDesign.NULL(rdrU085D.GetString("MESS_CODE")) == QDesign.NULL("EH4") || QDesign.NULL(rdrU085D.GetString("MESS_CODE")) == QDesign.NULL("VH9") || QDesign.NULL(rdrU085D.GetString("MESS_CODE")) == QDesign.NULL("E4") || QDesign.NULL(rdrU085D.GetString("MESS_CODE")) == QDesign.NULL("VH8"))
                {
                    strReturnValue = "1";
                }
                else if (QDesign.NULL(rdrU085D.GetString("MESS_CODE")) == QDesign.NULL("EH1") || QDesign.NULL(rdrU085D.GetString("MESS_CODE")) == QDesign.NULL("EH5"))
                {
                    strReturnValue = "2";
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_MESS1()
        {
            string strReturnValue = String.Empty;
            try
            {
                if (QDesign.NULL(X_LETTER_NBR()) == QDesign.NULL("1"))
                {
                    strReturnValue = "physician`s claims(s), our office did not have your correct health card";
                }
                else if ((QDesign.NULL(X_LETTER_NBR()) == QDesign.NULL("2")))
                {
                    strReturnValue = "physician`s claims(s), your Health Insurance Number was not in effect for";
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_MESS2()
        {
            string strReturnValue = String.Empty;
            try
            {
                if (QDesign.NULL(X_LETTER_NBR()) == QDesign.NULL("1"))
                {
                    strReturnValue = "information.  Please review the information below and contact us to correct";
                }
                else if (QDesign.NULL(X_LETTER_NBR()) == QDesign.NULL("2"))
                {
                    strReturnValue = "service date of ______ / ____________ / ____.";
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_MESS3()
        {
            string strReturnValue = String.Empty;
            try
            {
                if (QDesign.NULL(X_LETTER_NBR()) == QDesign.NULL("1"))
                {
                    strReturnValue = "your health number, version code or date of birth.  The version code is";
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_MESS4()
        {
            string strReturnValue = String.Empty;
            try
            {
                if (QDesign.NULL(X_LETTER_NBR()) == QDesign.NULL("1"))
                {
                    strReturnValue = "one or two letters following the 10 digit health number on your photo ID card";
                }
                else
                {
                    strReturnValue = "If you were eligible for Ontario Health Insurance for the date above,";
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_MESS5()
        {
            string strReturnValue = String.Empty;
            try
            {
                if (QDesign.NULL(X_LETTER_NBR()) == QDesign.NULL("1"))
                {
                    strReturnValue = "or red and white card.  If you need to update your Health Card, please visit";
                }
                else if ((QDesign.NULL(X_LETTER_NBR()) == QDesign.NULL("2")))
                {
                    strReturnValue = "please contact Service Ontario at 1-800-267-8097 to update your coverage for";
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_MESS6()
        {
            string strReturnValue = String.Empty;
            try
            {
                if (QDesign.NULL(X_LETTER_NBR()) == QDesign.NULL("1"))
                {
                    strReturnValue = "your local Service Ontario office or call 1-800-267-8097.";
                }
                else if ((QDesign.NULL(X_LETTER_NBR()) == QDesign.NULL("2")))
                {
                    strReturnValue = "this date.  If you have coverage under another Province or insurance plan,";
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_MESS7()
        {
            string strReturnValue = String.Empty;
            try
            {
                if (QDesign.NULL(X_LETTER_NBR()) == QDesign.NULL("1"))
                {
                    strReturnValue = "  ";
                }
                else if (QDesign.NULL(X_LETTER_NBR()) == QDesign.NULL("2"))
                {
                    strReturnValue = "please provide us with this information.";
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_MESS8()
        {
            string strReturnValue = String.Empty;
            try
            {
                if (QDesign.NULL(X_LETTER_NBR()) == QDesign.NULL("1"))
                {
                    strReturnValue = "or the 1-2 letters at the bottom right corner of the red and white card.";
                }
                else if (QDesign.NULL(X_LETTER_NBR()) == QDesign.NULL("2"))
                {
                    strReturnValue = "faxed, telephoned or returned by mail to our office. ";
                }
                else if (QDesign.NULL(X_LETTER_NBR()) == QDesign.NULL("3"))
                {
                    strReturnValue = "or the 1-2 letters at the bottom right corner of the red and white card.";
                }
                else if (QDesign.NULL(X_LETTER_NBR()) == QDesign.NULL("4"))
                {
                    strReturnValue = " ";
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_MESS9()
        {
            string strReturnValue = String.Empty;
            try
            {
                if (QDesign.NULL(X_LETTER_NBR()) == QDesign.NULL("1"))
                {
                    strReturnValue = "Thank you for your co-operation in this matter.";
                }
                else if (QDesign.NULL(X_LETTER_NBR()) == QDesign.NULL("2"))
                {
                    strReturnValue = "Thank you for your co-operation in this matter.";
                }
                else if (QDesign.NULL(X_LETTER_NBR()) == QDesign.NULL("3"))
                {
                    strReturnValue = "Thank you for your co-operation in this matter.";
                }
                else if (QDesign.NULL(X_LETTER_NBR()) == QDesign.NULL("4"))
                {
                    strReturnValue = " ";
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_SIGN_LIT()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = "SIGNATURE:";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_SIGN_UNDERSCORE()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = "____________________";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_DATE_LIT()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = "DATE:";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_DATE_UNDERSCORE()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = "_______________";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private decimal F010_PAT_MSTR_PAT_BIRTH_DATE()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = QDesign.NConvert(QDesign.ASCII(rdrF010_PAT_MSTR.GetString("PAT_BIRTH_DATE_YY")) + QDesign.ASCII(rdrF010_PAT_MSTR.GetString("PAT_BIRTH_DATE_MM")) + QDesign.ASCII(rdrF010_PAT_MSTR.GetString("PAT_BIRTH_DATE_DD")));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal COUNT()
        {
            decimal decReturnValue = 0;
            try
            {
                if (rdrU085D.GetString("CLMHDR_PAT_OHIP_ID_OR_CHART") != PREV_CLMHDR_PAT_OHIP_ID_OR_CHART || PREV_CLMHDR_PAT_OHIP_ID_OR_CHART == string.Empty)
                {
                    decReturnValue = 1;
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

        private string F010_PAT_MSTR_PAT_SURNAME()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = (rdrF010_PAT_MSTR.GetString("PAT_SURNAME_FIRST3") + rdrF010_PAT_MSTR.GetString("PAT_SURNAME_LAST22"));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string PREV_CLMHDR_PAT_OHIP_ID_OR_CHART;

        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.HEADING_AT, "X_ADDR_1", DataTypes.Character, 30);
                AddControl(ReportSection.HEADING_AT, "X_ADDR_3", DataTypes.Character, 43);
                AddControl(ReportSection.HEADING_AT, "X_ADDR_4", DataTypes.Character, 32);
                AddControl(ReportSection.HEADING_AT, "X_MESS1", DataTypes.Character, 80);
                AddControl(ReportSection.HEADING_AT, "X_MESS2", DataTypes.Character, 80);
                AddControl(ReportSection.HEADING_AT, "X_MESS3", DataTypes.Character, 80);
                AddControl(ReportSection.HEADING_AT, "X_MESS4", DataTypes.Character, 80);
                AddControl(ReportSection.HEADING_AT, "X_MESS5", DataTypes.Character, 80);
                AddControl(ReportSection.HEADING_AT, "X_MESS6", DataTypes.Character, 80);
                AddControl(ReportSection.HEADING_AT, "X_MESS7", DataTypes.Character, 80);
                AddControl(ReportSection.HEADING_AT, "INDEXED.F010_PAT_MSTR.PAT_HEALTH_NBR", DataTypes.Numeric, 10);
                AddControl(ReportSection.HEADING_AT, "INDEXED.F010_PAT_MSTR.PAT_VERSION_CD", DataTypes.Character, 2);
                AddControl(ReportSection.HEADING_AT, "F010_PAT_MSTR_PAT_BIRTH_DATE", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.U085D.CLMHDR_PAT_OHIP_ID_OR_CHART", DataTypes.Character, 16);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.U085D.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.FOOTING_AT, "X_DOC_NAME", DataTypes.Character, 35);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.U085D.MESS_CODE", DataTypes.Character, 3);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F030_LOCATIONS_MSTR.LOC_NAME", DataTypes.Character, 24);
                AddControl(ReportSection.FOOTING_AT, "COUNT", DataTypes.Numeric, 1);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-07-31 10:14:50 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            // TODO: Remove duplicate controls, if there are any.
            switch (strControl)
            {
                case "X_ADDR_1":
                    return Common.StringToField(X_ADDR_1(), intSize);
                case "X_ADDR_3":
                    return Common.StringToField(X_ADDR_3(), intSize);
                case "X_ADDR_4":
                    return Common.StringToField(X_ADDR_4(), intSize);
                case "X_MESS1":
                    return Common.StringToField(X_MESS1(), intSize);
                case "X_MESS2":
                    return Common.StringToField(X_MESS2(), intSize);
                case "X_MESS3":
                    return Common.StringToField(X_MESS3(), intSize);
                case "X_MESS4":
                    return Common.StringToField(X_MESS4(), intSize);
                case "X_MESS5":
                    return Common.StringToField(X_MESS5(), intSize);
                case "X_MESS6":
                    return Common.StringToField(X_MESS6(), intSize);
                case "X_MESS7":
                    return Common.StringToField(X_MESS7(), intSize);
                case "TEMPORARYDATA.U085D.CLMHDR_PAT_OHIP_ID_OR_CHART":
                    return Common.StringToField(rdrU085D.GetString("CLMHDR_PAT_OHIP_ID_OR_CHART"));
                case "TEMPORARYDATA.U085D.DOC_NBR":
                    return Common.StringToField(rdrU085D.GetString("DOC_NBR"));
                case "INDEXED.F010_PAT_MSTR.PAT_HEALTH_NBR":
                    return rdrF010_PAT_MSTR.GetNumber("PAT_HEALTH_NBR").ToString();
                case "INDEXED.F010_PAT_MSTR.PAT_VERSION_CD":
                    return Common.StringToField(rdrF010_PAT_MSTR.GetString("PAT_VERSION_CD"));
                case "F010_PAT_MSTR_PAT_BIRTH_DATE":
                    return F010_PAT_MSTR_PAT_BIRTH_DATE().ToString();
                case "X_DOC_NAME":
                    return Common.StringToField(X_DOC_NAME(), intSize);
                case "TEMPORARYDATA.U085D.MESS_CODE":
                    return Common.StringToField(rdrU085D.GetString("MESS_CODE"));
                case "INDEXED.F030_LOCATIONS_MSTR.LOC_NAME":
                    return Common.StringToField(rdrF030_LOCATIONS_MSTR.GetString("LOC_NAME"));
                case "COUNT":
                    return COUNT().ToString();
                default:
                    return String.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                Access_R085E_RUN_DATE();
                rdrR085E_RUN_DATE.Read();

                // TODO: Some manual steps maybe required.
                Access_U085D();
                
                while (rdrU085D.Read())
                {
                    Link_F002_CLAIMS_MSTR();
                    while (rdrF002_CLAIMS_MSTR.Read())
                    {
                        Link_F010_PAT_MSTR();
                        while (rdrF010_PAT_MSTR.Read())
                        {
                            Link_F020_DOCTOR_MSTR();
                            while (rdrF020_DOCTOR_MSTR.Read())
                            {
                                Link_REJECTED_CLAIMS();
                                while (rdrREJECTED_CLAIMS.Read())
                                {
                                    Link_F030_LOCATIONS_MSTR();
                                    while (rdrF030_LOCATIONS_MSTR.Read())
                                    {
                                        Link_TMP_COUNTERS();
                                        while (rdrTMP_COUNTERS.Read())
                                        {
                                            WriteData();

                                            if (PREV_CLMHDR_PAT_OHIP_ID_OR_CHART == string.Empty || PREV_CLMHDR_PAT_OHIP_ID_OR_CHART != rdrU085D.GetString("CLMHDR_PAT_OHIP_ID_OR_CHART"))
                                            {
                                                PREV_CLMHDR_PAT_OHIP_ID_OR_CHART = rdrU085D.GetString("CLMHDR_PAT_OHIP_ID_OR_CHART");
                                            }
                                        }

                                        rdrTMP_COUNTERS.Close();
                                    }

                                    rdrF030_LOCATIONS_MSTR.Close();
                                }

                                rdrREJECTED_CLAIMS.Close();
                            }

                            rdrF020_DOCTOR_MSTR.Close();
                        }

                        rdrF010_PAT_MSTR.Close();
                    }

                    rdrF002_CLAIMS_MSTR.Close();
                }

                rdrU085D.Close();
                rdrR085E_RUN_DATE.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrU085D == null))
            {
                rdrU085D.Close();
                rdrU085D = null;
            }

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

            if (!(rdrF020_DOCTOR_MSTR == null))
            {
                rdrF020_DOCTOR_MSTR.Close();
                rdrF020_DOCTOR_MSTR = null;
            }

            if (!(rdrREJECTED_CLAIMS == null))
            {
                rdrREJECTED_CLAIMS.Close();
                rdrREJECTED_CLAIMS = null;
            }

            if (!(rdrF030_LOCATIONS_MSTR == null))
            {
                rdrF030_LOCATIONS_MSTR.Close();
                rdrF030_LOCATIONS_MSTR = null;
            }

            if (!(rdrTMP_COUNTERS == null))
            {
                rdrTMP_COUNTERS.Close();
                rdrTMP_COUNTERS = null;
            }

            if (!(rdrR085E_RUN_DATE == null))
            {
                rdrR085E_RUN_DATE.Close();
                rdrR085E_RUN_DATE = null;
            }
        }
    }
}
