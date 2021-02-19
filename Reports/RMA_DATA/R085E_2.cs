//  2011/01/20 - end
//  brad1       &
//  2010/08/10 - MC2
//  link clmhdr-pat-ohip-id-or-chart of u085d   &
//  to   clmhdr-pat-ohip-id-or-chart of rejected-claims
//  2010/08/10 - end
//  MC11
//  MC11 - end
//  2011/03/08 - MC8
//  2011/03/08 -  end
//  2011/01/20 - MC4
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
    public class R085E_2 : BaseRDLClass
    {
        protected const string REPORT_NAME = "R085E_2";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrU085D = new Reader();
        private Reader rdrF002_CLAIMS_MSTR = new Reader();
        private Reader rdrF010_PAT_MSTR = new Reader();
        private Reader rdrF020_DOCTOR_MSTR = new Reader();
        private Reader rdrREJECTED_CLAIMS = new Reader();
        private Reader rdrF030_LOCATIONS_MSTR = new Reader();
        private Reader rdrTMP_COUNTERS = new Reader();
        private Reader rdrR085E_RUN_DATE = new Reader();
        private Reader rdrR085E = new Reader();
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
                SubFileName = "R085E";
                SubFileType = SubFileType.Keep;
                SubFileAT = "CLMHDR_PAT_OHIP_ID_OR_CHART";
                Sort = "PAT_SURNAME ASC, CLMHDR_PAT_OHIP_ID_OR_CHART ASC, DOC_NBR ASC, CLAIM_NBR ASC";
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
            strSQL.Append("CLMHDR_CONFIDENTIAL_FLAG, ");
            strSQL.Append("CLMHDR_TOT_CLAIM_AR_OHIP, ");
            strSQL.Append("CLMHDR_MANUAL_AND_TAPE_PAYMENTS ");
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
            strSQL.Append("PAT_DATE_LAST_ELIG_MAILING, ");
            strSQL.Append("PAT_NO_OF_LETTER_SENT, ");
            strSQL.Append("PAT_SURNAME_FIRST3, ");
            strSQL.Append("PAT_SURNAME_LAST22, ");
            strSQL.Append("PAT_GIVEN_NAME_FIRST1, ");
            strSQL.Append("FILLER3, ");
            strSQL.Append("PAT_HEALTH_NBR, ");
            strSQL.Append("PAT_BIRTH_DATE_YY, ");
            strSQL.Append("PAT_BIRTH_DATE_MM, ");
            strSQL.Append("PAT_BIRTH_DATE_DD, ");
            strSQL.Append("PAT_VERSION_CD ");
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
            strSQL.Append("DOC_NBR ");
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
            strSQL.Append("LOC_NBR ");
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

        private decimal X_BAL_DUE()
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

        private decimal F010_PAT_MSTR_PAT_BIRTH_DATE()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = QDesign.NConvert(QDesign.ASCII(rdrF010_PAT_MSTR.GetNumber("PAT_BIRTH_DATE_YY")) + QDesign.ASCII(rdrF010_PAT_MSTR.GetNumber("PAT_BIRTH_DATE_MM")).PadLeft(2, '0') + QDesign.ASCII(rdrF010_PAT_MSTR.GetNumber("PAT_BIRTH_DATE_DD")).PadLeft(2, '0'));
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
        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U085D.CLMHDR_PAT_OHIP_ID_OR_CHART", DataTypes.Character, 16);
                AddControl(ReportSection.SUMMARY, "INDEXED.F010_PAT_MSTR.PAT_HEALTH_NBR", DataTypes.Numeric, 10);
                AddControl(ReportSection.SUMMARY, "F010_PAT_MSTR_PAT_BIRTH_DATE", DataTypes.Numeric, 8);
                AddControl(ReportSection.SUMMARY, "INDEXED.F010_PAT_MSTR.PAT_VERSION_CD", DataTypes.Character, 2);
                AddControl(ReportSection.SUMMARY, "X_PAT_NAME", DataTypes.Character, 30);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U085D.MESS_CODE", DataTypes.Character, 3);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U085D.CLAIM_NBR", DataTypes.Character, 10);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U085D.CLMHDR_LOC", DataTypes.Character, 4);
                AddControl(ReportSection.SUMMARY, "INDEXED.F010_PAT_MSTR.PAT_DATE_LAST_ELIG_MAILING", DataTypes.Numeric, 8);
                AddControl(ReportSection.SUMMARY, "INDEXED.F010_PAT_MSTR.PAT_NO_OF_LETTER_SENT", DataTypes.Numeric, 2);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.R085E_RUN_DATE.OHIP_RUN_DATE", DataTypes.Numeric, 8);
                AddControl(ReportSection.REPORT, "PAT_SURNAME", DataTypes.Character, 22);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U085D.DOC_NBR", DataTypes.Character, 3);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-05-14 10:20:58 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            // TODO: Remove duplicate controls, if there are any.
            switch (strControl)
            {
                case "TEMPORARYDATA.U085D.CLMHDR_PAT_OHIP_ID_OR_CHART":
                    return Common.StringToField(rdrU085D.GetString("CLMHDR_PAT_OHIP_ID_OR_CHART"));
                case "INDEXED.F010_PAT_MSTR.PAT_HEALTH_NBR":
                    return rdrF010_PAT_MSTR.GetNumber("PAT_HEALTH_NBR").ToString();
                case "F010_PAT_MSTR_PAT_BIRTH_DATE":
                    return F010_PAT_MSTR_PAT_BIRTH_DATE().ToString();
                case "INDEXED.F010_PAT_MSTR.PAT_VERSION_CD":
                    return Common.StringToField(rdrF010_PAT_MSTR.GetString("PAT_VERSION_CD"));
                case "X_PAT_NAME":
                    return Common.StringToField(X_PAT_NAME(), intSize);
                case "TEMPORARYDATA.U085D.MESS_CODE":
                    return Common.StringToField(rdrU085D.GetString("MESS_CODE"));
                case "TEMPORARYDATA.U085D.CLAIM_NBR":
                    return Common.StringToField(rdrU085D.GetString("CLAIM_NBR"));
                case "TEMPORARYDATA.U085D.CLMHDR_LOC":
                    return Common.StringToField(rdrU085D.GetString("CLMHDR_LOC"));
                case "INDEXED.F010_PAT_MSTR.PAT_DATE_LAST_ELIG_MAILING":
                    return rdrF010_PAT_MSTR.GetNumber("PAT_DATE_LAST_ELIG_MAILING").ToString();
                case "INDEXED.F010_PAT_MSTR.PAT_NO_OF_LETTER_SENT":
                    return rdrF010_PAT_MSTR.GetNumber("PAT_NO_OF_LETTER_SENT").ToString();
                case "TEMPORARYDATA.R085E_RUN_DATE.OHIP_RUN_DATE":
                    return rdrR085E_RUN_DATE.GetNumber("OHIP_RUN_DATE").ToString();
                case "PAT_SURNAME":
                    return Common.StringToField(F010_PAT_MSTR_PAT_SURNAME(), intSize);
                case "TEMPORARYDATA.U085D.DOC_NBR":
                    return Common.StringToField(rdrU085D.GetString("DOC_NBR"));
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
