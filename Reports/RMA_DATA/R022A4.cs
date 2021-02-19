//  #> program-id.     r022a4.qzs
//  ((C)) Dyad Technologies
//  PROGRAM PURPOSE : SELECT CLAIMS FOR RE-SUBMIT
//  IF CHANGES REQUIRED FOR HOSPITAL CODES, MAKE
//  SURE TO CHANGE IN HOSPITAL_CODE.DEF
//  MODIFICATION HISTORY
//  DATE   WHO          DESCRIPTION
//  00/sep/18 B.E.        - moved from r022a.qzs into separate source module
//  03/aug/07 M.C.        - include contract-code in subfile
//  03/dec/11 A.A. - alpha doctor nbr
//  !  link (floor(key-clm-batch-nbr / 10000000)) to iconst-clinic-nbr-1-2 &
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
    public class R022A4 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R022A4";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrU022A3 = new Reader();
        private Reader rdrF010_PAT_MSTR = new Reader();
        private Reader rdrICONST_MSTR_REC = new Reader();
        private Reader rdrU020A1 = new Reader();

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
                SubFileName = "U020A1";
                SubFileType = SubFileType.Keep;
                SubFileAT = "";
                Sort = "CLMHDR_CLAIM_ID ASC";
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

        private void Access_U022A3()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("CLMHDR_PAT_OHIP_ID_OR_CHART, ");
            strSQL.Append("CLMHDR_PAT_KEY_TYPE, ");
            strSQL.Append("CLMHDR_PAT_KEY_DATA, ");
            strSQL.Append("KEY_CLM_BATCH_NBR, ");
            strSQL.Append("CLMHDR_BATCH_TYPE, ");
            strSQL.Append("CLMHDR_DOC_NBR_OHIP, ");
            strSQL.Append("CLMHDR_LOC, ");
            strSQL.Append("CLMHDR_AGENT_CD, ");
            strSQL.Append("CLMHDR_DATE_SYS, ");
            strSQL.Append("CLMHDR_CLAIM_ID, ");
            strSQL.Append("CLMHDR_BATCH_NBR, ");
            strSQL.Append("CLMHDR_CLAIM_NBR, ");
            strSQL.Append("CLMHDR_ADJ_OMA_CD, ");
            strSQL.Append("CLMHDR_ADJ_OMA_SUFF, ");
            strSQL.Append("CLMHDR_ADJ_ADJ_NBR, ");
            strSQL.Append("W_CLMHDR_HOSP, ");
            strSQL.Append("W_MOH_LOCATION_CODE, ");
            strSQL.Append("CLMHDR_DATE_ADMIT, ");
            strSQL.Append("CLMHDR_REFER_DOC_NBR, ");
            strSQL.Append("CLMHDR_I_O_PAT_IND, ");
            strSQL.Append("CLMHDR_TOT_CLAIM_AR_OMA, ");
            strSQL.Append("CLMHDR_TOT_CLAIM_AR_OHIP, ");
            strSQL.Append("CLMHDR_STATUS_OHIP, ");
            strSQL.Append("CLMHDR_SUB_NBR, ");
            strSQL.Append("CLMHDR_MANUAL_REVIEW, ");
            strSQL.Append("CLMHDR_DOC_DEPT, ");
            strSQL.Append("CLMHDR_DOC_SPEC_CD, ");
            strSQL.Append("MOH_FLAG, ");
            strSQL.Append("DOLLAR_FLAG, ");
            strSQL.Append("TRANSLATED_GROUP_NBR, ");
            strSQL.Append("CONTRACT_CODE ");
            strSQL.Append("FROM TEMPORARYDATA.U022A3 ");

            strSQL.Append(Choose());

            rdrU022A3.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
            strSQL = null;
        }
        private void Link_F010_PAT_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("PAT_I_KEY, ");
            strSQL.Append("PAT_CON_NBR, ");
            strSQL.Append("PAT_I_NBR, ");
            strSQL.Append("FILLER4, ");
            strSQL.Append("PAT_HEALTH_NBR, ");
            /*strSQL.Append("PAT_OHIP_NBR, ");
            strSQL.Append("PAT_MM, ");
            strSQL.Append("PAT_YY, ");
            strSQL.Append("FILLER1, ");*/
            strSQL.Append("PAT_DIRECT_ALPHA, ");
            strSQL.Append("PAT_DIRECT_YY, ");
            strSQL.Append("PAT_DIRECT_MM, ");
            strSQL.Append("PAT_DIRECT_DD, ");
            strSQL.Append("PAT_DIRECT_LAST_6, ");
            strSQL.Append("PAT_SEX, ");
            strSQL.Append("PAT_VERSION_CD, ");
            strSQL.Append("PAT_CHART_NBR, ");
            strSQL.Append("PAT_SURNAME_FIRST3, ");
            strSQL.Append("PAT_SURNAME_LAST22, ");
            strSQL.Append("PAT_GIVEN_NAME_FIRST1, ");
            strSQL.Append("FILLER3, ");
            strSQL.Append("PAT_ACRONYM_FIRST6, ");
            strSQL.Append("PAT_ACRONYM_LAST3, ");
            strSQL.Append("PAT_BIRTH_DATE_YY, ");
            strSQL.Append("PAT_BIRTH_DATE_MM, ");
            strSQL.Append("PAT_BIRTH_DATE_DD, ");
            strSQL.Append("PAT_PROV_CD, ");
            strSQL.Append("SUBSCR_ADDR1, ");
            strSQL.Append("SUBSCR_ADDR2, ");
            strSQL.Append("SUBSCR_ADDR3, ");
            strSQL.Append("SUBSCR_POST_CD1, ");
            strSQL.Append("SUBSCR_POST_CD2, ");
            strSQL.Append("SUBSCR_POST_CD3, ");
            strSQL.Append("SUBSCR_POST_CD4, ");
            strSQL.Append("SUBSCR_POST_CD5, ");
            strSQL.Append("SUBSCR_POST_CD6, ");
            strSQL.Append("FILLER, ");
            strSQL.Append("PAT_MESS_CODE ");
            strSQL.Append("FROM INDEXED.F010_PAT_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("PAT_I_KEY = ").Append(Common.StringToField(QDesign.Substring(rdrU022A3.GetString("CLMHDR_PAT_OHIP_ID_OR_CHART"), 1, 1)));
            strSQL.Append(" AND PAT_CON_NBR = ").Append(QDesign.NConvert(QDesign.Substring(rdrU022A3.GetString("CLMHDR_PAT_OHIP_ID_OR_CHART"), 2, 2)));
            strSQL.Append(" AND PAT_I_NBR = ").Append(QDesign.NConvert(QDesign.Substring(rdrU022A3.GetString("CLMHDR_PAT_OHIP_ID_OR_CHART"), 4, 12)));
            strSQL.Append(" AND FILLER4 = ").Append(Common.StringToField(QDesign.Substring(rdrU022A3.GetString("CLMHDR_PAT_OHIP_ID_OR_CHART"), 16, 1)));

            rdrF010_PAT_MSTR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_ICONST_MSTR_REC()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("ICONST_CLINIC_NBR_1_2, ");
            strSQL.Append("ICONST_CLINIC_NBR, ");
            strSQL.Append("ICONST_CLINIC_CYCLE_NBR, ");
            strSQL.Append("ICONST_DATE_PERIOD_END_YY, ");
            strSQL.Append("ICONST_DATE_PERIOD_END_MM, ");
            strSQL.Append("ICONST_DATE_PERIOD_END_DD ");
            strSQL.Append("FROM INDEXED.ICONST_MSTR_REC ");
            strSQL.Append("WHERE ");
            strSQL.Append("ICONST_CLINIC_NBR_1_2 = ").Append(QDesign.NConvert(QDesign.Substring(rdrU022A3.GetString("KEY_CLM_BATCH_NBR"), 1, 2)));

            rdrICONST_MSTR_REC.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        #endregion

        #region " CHOOSE "

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(string.Empty);

            return strChoose.ToString().ToString();
        }

        #endregion

        #region " SELECT IF "

        #endregion

        #region " DEFINES "

        private string PAT_DIRECT_ID()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = rdrF010_PAT_MSTR.GetString("PAT_DIRECT_ALPHA") + rdrF010_PAT_MSTR.GetNumber("PAT_DIRECT_YY").ToString() +
                                 rdrF010_PAT_MSTR.GetNumber("PAT_DIRECT_MM").ToString() + rdrF010_PAT_MSTR.GetNumber("PAT_DIRECT_DD").ToString() +
                                 rdrF010_PAT_MSTR.GetString("PAT_DIRECT_LAST_6");
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string BATCTRL_BATCH_NBR()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = rdrU022A3.GetString("KEY_CLM_BATCH_NBR");
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string BATCTRL_BATCH_TYPE()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = rdrU022A3.GetString("CLMHDR_BATCH_TYPE");
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string BATCTRL_CLINIC_NBR()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = rdrICONST_MSTR_REC.GetString("ICONST_CLINIC_NBR");
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private decimal BATCTRL_DOC_NBR_OHIP()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = rdrU022A3.GetNumber("CLMHDR_DOC_NBR_OHIP");
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private string BATCTRL_LOC()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = rdrU022A3.GetString("CLMHDR_LOC");
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private decimal BATCTRL_AGENT_CD()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = rdrU022A3.GetNumber("CLMHDR_AGENT_CD");
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private string BATCTRL_DATE_BATCH_ENTERED()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = rdrU022A3.GetString("CLMHDR_DATE_SYS");
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string W_PAT_OHIP_MMYY()
        {
            string strReturnValue = string.Empty;
            try
            {
                if (((QDesign.NULL(rdrF010_PAT_MSTR.GetNumber("PAT_HEALTH_NBR")) == QDesign.NULL(0d))
                            && (QDesign.NULL(PAT_DIRECT_ID()) != QDesign.NULL(" "))))
                {
                    strReturnValue = PAT_DIRECT_ID();
                }
                else
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

        private string W_PAT_SEX()
        {
            string strReturnValue = string.Empty;
            try
            {
                if ((QDesign.NULL(rdrF010_PAT_MSTR.GetString("PAT_SEX")) == "M"))
                {
                    strReturnValue = "1";
                }
                else if ((QDesign.NULL(rdrF010_PAT_MSTR.GetString("PAT_SEX")) == "F"))
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

        private string DOC_NBR()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = QDesign.Substring(rdrU022A3.GetString("CLMHDR_CLAIM_ID"), 3, 3);
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

        private string F010_PAT_MSTR_PAT_SURNAME()
        {
            string strReturnValue = string.Empty;
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

        private string F010_PAT_MSTR_PAT_GIVEN_NAME()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = (rdrF010_PAT_MSTR.GetString("PAT_GIVEN_NAME_FIRST1") + rdrF010_PAT_MSTR.GetString("FILLER3"));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string F010_PAT_MSTR_PAT_ACRONYM()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = (rdrF010_PAT_MSTR.GetString("PAT_ACRONYM_FIRST6") + rdrF010_PAT_MSTR.GetString("PAT_ACRONYM_LAST3"));
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

        private string F010_PAT_MSTR_SUBSCR_POSTAL_CD()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = rdrF010_PAT_MSTR.GetString("SUBSCR_POST_CD1") + rdrF010_PAT_MSTR.GetString("SUBSCR_POST_CD2") + rdrF010_PAT_MSTR.GetString("SUBSCR_POST_CD3")
                               + rdrF010_PAT_MSTR.GetString("SUBSCR_POST_CD4") + rdrF010_PAT_MSTR.GetString("SUBSCR_POST_CD5") + rdrF010_PAT_MSTR.GetString("SUBSCR_POST_CD6") + rdrF010_PAT_MSTR.GetString("FILLER");
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
                AddControl(ReportSection.SUMMARY, "BATCTRL_BATCH_NBR", DataTypes.Character, 8);
                AddControl(ReportSection.SUMMARY, "BATCTRL_BATCH_TYPE", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "BATCTRL_CLINIC_NBR", DataTypes.Character, 4);
                AddControl(ReportSection.SUMMARY, "BATCTRL_DOC_NBR_OHIP", DataTypes.Numeric, 6);
                AddControl(ReportSection.SUMMARY, "BATCTRL_LOC", DataTypes.Character, 4);
                AddControl(ReportSection.SUMMARY, "BATCTRL_AGENT_CD", DataTypes.Numeric, 1);
                AddControl(ReportSection.SUMMARY, "BATCTRL_DATE_BATCH_ENTERED", DataTypes.Character, 8);
                AddControl(ReportSection.SUMMARY, "INDEXED.ICONST_MSTR_REC.ICONST_CLINIC_NBR_1_2", DataTypes.Numeric, 2);
                AddControl(ReportSection.SUMMARY, "INDEXED.ICONST_MSTR_REC.ICONST_CLINIC_CYCLE_NBR", DataTypes.Numeric, 2);
                AddControl(ReportSection.SUMMARY, "ICONST_DATE_PERIOD_END", DataTypes.Numeric, 8);
                AddControl(ReportSection.SUMMARY, "INDEXED.ICONST_MSTR_REC.ICONST_DATE_PERIOD_END_YY", DataTypes.Numeric, 4);
                AddControl(ReportSection.SUMMARY, "INDEXED.ICONST_MSTR_REC.ICONST_DATE_PERIOD_END_MM", DataTypes.Numeric, 2);
                AddControl(ReportSection.SUMMARY, "INDEXED.ICONST_MSTR_REC.ICONST_DATE_PERIOD_END_DD", DataTypes.Numeric, 2);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A3.CLMHDR_CLAIM_ID", DataTypes.Character, 16);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A3.CLMHDR_BATCH_NBR", DataTypes.Character, 8);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A3.CLMHDR_CLAIM_NBR", DataTypes.Numeric, 2);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A2.CLMHDR_ADJ_OMA_CD", DataTypes.Character, 4);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A2.CLMHDR_ADJ_OMA_SUFF", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A2.CLMHDR_ADJ_ADJ_NBR", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A3.W_CLMHDR_HOSP", DataTypes.Character, 4);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A3.W_MOH_LOCATION_CODE", DataTypes.Character, 4);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A3.CLMHDR_DATE_ADMIT", DataTypes.Character, 8);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A3.CLMHDR_PAT_OHIP_ID_OR_CHART", DataTypes.Character, 16);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A3.CLMHDR_PAT_KEY_TYPE", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A3.CLMHDR_PAT_KEY_DATA", DataTypes.Character, 15);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A3.CLMHDR_REFER_DOC_NBR", DataTypes.Numeric, 6);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A3.CLMHDR_LOC", DataTypes.Character, 4);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A3.CLMHDR_I_O_PAT_IND", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A3.CLMHDR_AGENT_CD", DataTypes.Numeric, 1);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A3.CLMHDR_TOT_CLAIM_AR_OMA", DataTypes.Numeric, 7);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A3.CLMHDR_TOT_CLAIM_AR_OHIP", DataTypes.Numeric, 7);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A3.CLMHDR_STATUS_OHIP", DataTypes.Character, 2);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A3.CLMHDR_SUB_NBR", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A3.CLMHDR_MANUAL_REVIEW", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A3.CLMHDR_DOC_DEPT", DataTypes.Numeric, 2);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A3.CLMHDR_DOC_SPEC_CD", DataTypes.Numeric, 2);
                AddControl(ReportSection.SUMMARY, "INDEXED.F010_PAT_MSTR.PAT_HEALTH_NBR", DataTypes.Numeric, 10);
                AddControl(ReportSection.SUMMARY, "INDEXED.F010_PAT_MSTR.PAT_VERSION_CD", DataTypes.Character, 2);
                AddControl(ReportSection.SUMMARY, "W_PAT_OHIP_MMYY", DataTypes.Character, 15);
                AddControl(ReportSection.SUMMARY, "INDEXED.F010_PAT_MSTR.PAT_CHART_NBR", DataTypes.Character, 10);
                AddControl(ReportSection.SUMMARY, "INDEXED.F010_PAT_MSTR.PAT_SURNAME", DataTypes.Character, 25);
                AddControl(ReportSection.SUMMARY, "INDEXED.F010_PAT_MSTR.PAT_SURNAME_FIRST3", DataTypes.Character, 3);
                AddControl(ReportSection.SUMMARY, "INDEXED.F010_PAT_MSTR.PAT_SURNAME_LAST22", DataTypes.Character, 22);
                AddControl(ReportSection.SUMMARY, "INDEXED.F010_PAT_MSTR.PAT_GIVEN_NAME", DataTypes.Character, 17);
                AddControl(ReportSection.SUMMARY, "INDEXED.F010_PAT_MSTR.PAT_GIVEN_NAME_FIRST1", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "INDEXED.F010_PAT_MSTR.FILLER3", DataTypes.Character, 16);
                AddControl(ReportSection.SUMMARY, "INDEXED.F010_PAT_MSTR.PAT_ACRONYM", DataTypes.Character, 9);
                AddControl(ReportSection.SUMMARY, "INDEXED.F010_PAT_MSTR.PAT_ACRONYM_FIRST6", DataTypes.Character, 6);
                AddControl(ReportSection.SUMMARY, "INDEXED.F010_PAT_MSTR.PAT_ACRONYM_LAST3", DataTypes.Character, 3);
                AddControl(ReportSection.SUMMARY, "INDEXED.F010_PAT_MSTR.PAT_BIRTH_DATE", DataTypes.Numeric, 8);
                AddControl(ReportSection.SUMMARY, "INDEXED.F010_PAT_MSTR.PAT_BIRTH_DATE_YY", DataTypes.Numeric, 4);
                AddControl(ReportSection.SUMMARY, "INDEXED.F010_PAT_MSTR.PAT_BIRTH_DATE_MM", DataTypes.Numeric, 2);
                AddControl(ReportSection.SUMMARY, "INDEXED.F010_PAT_MSTR.PAT_BIRTH_DATE_DD", DataTypes.Numeric, 2);
                AddControl(ReportSection.SUMMARY, "W_PAT_SEX", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "INDEXED.F010_PAT_MSTR.PAT_PROV_CD", DataTypes.Character, 2);
                AddControl(ReportSection.SUMMARY, "INDEXED.F010_PAT_MSTR.SUBSCR_ADDR1", DataTypes.Character, 30);
                AddControl(ReportSection.SUMMARY, "INDEXED.F010_PAT_MSTR.SUBSCR_ADDR2", DataTypes.Character, 30);
                AddControl(ReportSection.SUMMARY, "INDEXED.F010_PAT_MSTR.SUBSCR_ADDR3", DataTypes.Character, 30);
                AddControl(ReportSection.SUMMARY, "INDEXED.F010_PAT_MSTR.SUBSCR_POSTAL_CD", DataTypes.Character, 10);
                AddControl(ReportSection.SUMMARY, "INDEXED.F010_PAT_MSTR.SUBSCR_POST_CD1", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "INDEXED.F010_PAT_MSTR.SUBSCR_POST_CD2", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "INDEXED.F010_PAT_MSTR.SUBSCR_POST_CD3", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "INDEXED.F010_PAT_MSTR.SUBSCR_POST_CD4", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "INDEXED.F010_PAT_MSTR.SUBSCR_POST_CD5", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "INDEXED.F010_PAT_MSTR.SUBSCR_POST_CD6", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "INDEXED.F010_PAT_MSTR.FILLER", DataTypes.Character, 4);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A3.MOH_FLAG", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A3.DOLLAR_FLAG", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "INDEXED.F010_PAT_MSTR.PAT_MESS_CODE", DataTypes.Character, 3);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A3.TRANSLATED_GROUP_NBR", DataTypes.Character, 4);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A3.CONTRACT_CODE", DataTypes.Character, 2);
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
        // # Do not delete, modify or move it.  Updated: 2018-05-11 6:02:21 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "BATCTRL_BATCH_NBR":
                    return Common.StringToField(BATCTRL_BATCH_NBR(), intSize);

                case "BATCTRL_BATCH_TYPE":
                    return Common.StringToField(BATCTRL_BATCH_TYPE(), intSize);

                case "BATCTRL_CLINIC_NBR":
                    return Common.StringToField(BATCTRL_CLINIC_NBR(), intSize);

                case "BATCTRL_DOC_NBR_OHIP":
                    return BATCTRL_DOC_NBR_OHIP().ToString();

                case "BATCTRL_LOC":
                    return Common.StringToField(BATCTRL_LOC(), intSize);

                case "BATCTRL_AGENT_CD":
                    return BATCTRL_AGENT_CD().ToString();

                case "BATCTRL_DATE_BATCH_ENTERED":
                    return Common.StringToField(BATCTRL_DATE_BATCH_ENTERED(), intSize);

                case "INDEXED.ICONST_MSTR_REC.ICONST_CLINIC_NBR_1_2":
                    return rdrICONST_MSTR_REC.GetNumber("ICONST_CLINIC_NBR_1_2").ToString();

                case "INDEXED.ICONST_MSTR_REC.ICONST_CLINIC_CYCLE_NBR":
                    return rdrICONST_MSTR_REC.GetNumber("ICONST_CLINIC_CYCLE_NBR").ToString();

                case "ICONST_DATE_PERIOD_END":
                    return ICONST_MSTR_REC_ICONST_DATE_PERIOD_END().ToString();

                case "INDEXED.ICONST_MSTR_REC.ICONST_DATE_PERIOD_END_YY":
                    return rdrICONST_MSTR_REC.GetNumber("ICONST_DATE_PERIOD_END_YY").ToString();

                case "INDEXED.ICONST_MSTR_REC.ICONST_DATE_PERIOD_END_MM":
                    return rdrICONST_MSTR_REC.GetNumber("ICONST_DATE_PERIOD_END_MM").ToString();

                case "INDEXED.ICONST_MSTR_REC.ICONST_DATE_PERIOD_END_DD":
                    return rdrICONST_MSTR_REC.GetNumber("ICONST_DATE_PERIOD_END_DD").ToString();

                case "TEMPORARYDATA.U022A3.CLMHDR_CLAIM_ID":
                    return Common.StringToField(rdrU022A3.GetString("CLMHDR_CLAIM_ID"));

                case "TEMPORARYDATA.U022A3.CLMHDR_BATCH_NBR":
                    return Common.StringToField(rdrU022A3.GetString("CLMHDR_BATCH_NBR"));

                case "TEMPORARYDATA.U022A3.CLMHDR_CLAIM_NBR":
                    return rdrU022A3.GetNumber("CLMHDR_CLAIM_NBR").ToString();

                case "TEMPORARYDATA.U022A2.CLMHDR_ADJ_OMA_CD":
                    return Common.StringToField(rdrU022A3.GetString("CLMHDR_ADJ_OMA_CD"));

                case "TEMPORARYDATA.U022A2.CLMHDR_ADJ_OMA_SUFF":
                    return Common.StringToField(rdrU022A3.GetString("CLMHDR_ADJ_OMA_SUFF"));

                case "TEMPORARYDATA.U022A2.CLMHDR_ADJ_ADJ_NBR":
                    return Common.StringToField(rdrU022A3.GetString("CLMHDR_ADJ_ADJ_NBR"));

                case "TEMPORARYDATA.U022A3.W_CLMHDR_HOSP":
                    return Common.StringToField(rdrU022A3.GetString("W_CLMHDR_HOSP"));

                case "TEMPORARYDATA.U022A3.W_MOH_LOCATION_CODE":
                    return Common.StringToField(rdrU022A3.GetString("W_MOH_LOCATION_CODE"));

                case "TEMPORARYDATA.U022A3.CLMHDR_DATE_ADMIT":
                    return Common.StringToField(rdrU022A3.GetString("CLMHDR_DATE_ADMIT"));

                case "TEMPORARYDATA.U022A3.CLMHDR_PAT_OHIP_ID_OR_CHART":
                    return Common.StringToField(rdrU022A3.GetString("CLMHDR_PAT_OHIP_ID_OR_CHART"));

                case "TEMPORARYDATA.U022A2.CLMHDR_PAT_KEY_TYPE":
                    return Common.StringToField(rdrU022A3.GetString("CLMHDR_PAT_KEY_TYPE"));

                case "TEMPORARYDATA.U022A2.CLMHDR_PAT_KEY_DATA":
                    return Common.StringToField(rdrU022A3.GetString("CLMHDR_PAT_KEY_DATA"));

                case "TEMPORARYDATA.U022A3.CLMHDR_REFER_DOC_NBR":
                    return rdrU022A3.GetNumber("CLMHDR_REFER_DOC_NBR").ToString();

                case "TEMPORARYDATA.U022A3.CLMHDR_LOC":
                    return Common.StringToField(rdrU022A3.GetString("CLMHDR_LOC"));

                case "TEMPORARYDATA.U022A3.CLMHDR_I_O_PAT_IND":
                    return Common.StringToField(rdrU022A3.GetString("CLMHDR_I_O_PAT_IND"));

                case "TEMPORARYDATA.U022A3.CLMHDR_AGENT_CD":
                    return rdrU022A3.GetNumber("CLMHDR_AGENT_CD").ToString();

                case "TEMPORARYDATA.U022A3.CLMHDR_TOT_CLAIM_AR_OMA":
                    return rdrU022A3.GetNumber("CLMHDR_TOT_CLAIM_AR_OMA").ToString();

                case "TEMPORARYDATA.U022A3.CLMHDR_TOT_CLAIM_AR_OHIP":
                    return rdrU022A3.GetNumber("CLMHDR_TOT_CLAIM_AR_OHIP").ToString();

                case "TEMPORARYDATA.U022A3.CLMHDR_STATUS_OHIP":
                    return Common.StringToField(rdrU022A3.GetString("CLMHDR_STATUS_OHIP"));

                case "TEMPORARYDATA.U022A3.CLMHDR_SUB_NBR":
                    return Common.StringToField(rdrU022A3.GetString("CLMHDR_SUB_NBR"));

                case "TEMPORARYDATA.U022A3.CLMHDR_MANUAL_REVIEW":
                    return Common.StringToField(rdrU022A3.GetString("CLMHDR_MANUAL_REVIEW"));

                case "DOC_NBR":
                    return Common.StringToField(DOC_NBR(), intSize);

                case "TEMPORARYDATA.U022A3.CLMHDR_DOC_DEPT":
                    return rdrU022A3.GetNumber("CLMHDR_DOC_DEPT").ToString();

                case "TEMPORARYDATA.U022A3.CLMHDR_DOC_SPEC_CD":
                    return rdrU022A3.GetNumber("CLMHDR_DOC_SPEC_CD").ToString();

                case "INDEXED.F010_PAT_MSTR.PAT_HEALTH_NBR":
                    return rdrF010_PAT_MSTR.GetNumber("PAT_HEALTH_NBR").ToString();

                case "INDEXED.F010_PAT_MSTR.PAT_VERSION_CD":
                    return Common.StringToField(rdrF010_PAT_MSTR.GetString("PAT_VERSION_CD"));

                case "W_PAT_OHIP_MMYY":
                    return Common.StringToField(W_PAT_OHIP_MMYY(), intSize);

                case "INDEXED.F010_PAT_MSTR.PAT_CHART_NBR":
                    return Common.StringToField(rdrF010_PAT_MSTR.GetString("PAT_CHART_NBR"));

                case "INDEXED.F010_PAT_MSTR.PAT_SURNAME":
                    return Common.StringToField(F010_PAT_MSTR_PAT_SURNAME(), intSize);

                case "INDEXED.F010_PAT_MSTR.PAT_SURNAME_FIRST3":
                    return Common.StringToField(rdrF010_PAT_MSTR.GetString("PAT_SURNAME_FIRST3"));

                case "INDEXED.F010_PAT_MSTR.PAT_SURNAME_LAST22":
                    return Common.StringToField(rdrF010_PAT_MSTR.GetString("PAT_SURNAME_LAST22"));

                case "INDEXED.F010_PAT_MSTR.PAT_GIVEN_NAME":
                    return Common.StringToField(F010_PAT_MSTR_PAT_GIVEN_NAME(), intSize);

                case "INDEXED.F010_PAT_MSTR.PAT_GIVEN_NAME_FIRST1":
                    return Common.StringToField(rdrF010_PAT_MSTR.GetString("PAT_GIVEN_NAME_FIRST1"));

                case "INDEXED.F010_PAT_MSTR.FILLER3":
                    return Common.StringToField(rdrF010_PAT_MSTR.GetString("FILLER3"));

                case "INDEXED.F010_PAT_MSTR.PAT_ACRONYM":
                    return Common.StringToField(F010_PAT_MSTR_PAT_ACRONYM(), intSize);

                case "INDEXED.F010_PAT_MSTR.PAT_BIRTH_DATE":
                    return F010_PAT_MSTR_PAT_BIRTH_DATE().ToString();

                case "INDEXED.F010_PAT_MSTR.PAT_BIRTH_DATE_YY":
                    return rdrF010_PAT_MSTR.GetNumber("PAT_BIRTH_DATE_YY").ToString();

                case "INDEXED.F010_PAT_MSTR.PAT_BIRTH_DATE_MM":
                    return rdrF010_PAT_MSTR.GetNumber("PAT_BIRTH_DATE_MM").ToString();

                case "INDEXED.F010_PAT_MSTR.PAT_BIRTH_DATE_DD":
                    return rdrF010_PAT_MSTR.GetNumber("PAT_BIRTH_DATE_DD").ToString();

                case "W_PAT_SEX":
                    return Common.StringToField(W_PAT_SEX(), intSize);

                case "INDEXED.F010_PAT_MSTR.PAT_PROV_CD":
                    return Common.StringToField(rdrF010_PAT_MSTR.GetString("PAT_PROV_CD"));

                case "INDEXED.F010_PAT_MSTR.SUBSCR_ADDR1":
                    return Common.StringToField(rdrF010_PAT_MSTR.GetString("SUBSCR_ADDR1"));

                case "INDEXED.F010_PAT_MSTR.SUBSCR_ADDR2":
                    return Common.StringToField(rdrF010_PAT_MSTR.GetString("SUBSCR_ADDR2"));

                case "INDEXED.F010_PAT_MSTR.SUBSCR_ADDR3":
                    return Common.StringToField(rdrF010_PAT_MSTR.GetString("SUBSCR_ADDR3"));

                case "INDEXED.F010_PAT_MSTR.SUBSCR_POSTAL_CD":
                    return Common.StringToField(F010_PAT_MSTR_SUBSCR_POSTAL_CD(), intSize);

                case "INDEXED.F010_PAT_MSTR.SUBSCR_POST_CD1":
                    return Common.StringToField(rdrF010_PAT_MSTR.GetString("SUBSCR_POST_CD1"));

                case "INDEXED.F010_PAT_MSTR.SUBSCR_POST_CD2":
                    return Common.StringToField(rdrF010_PAT_MSTR.GetString("SUBSCR_POST_CD2"));

                case "INDEXED.F010_PAT_MSTR.SUBSCR_POST_CD3":
                    return Common.StringToField(rdrF010_PAT_MSTR.GetString("SUBSCR_POST_CD3"));

                case "INDEXED.F010_PAT_MSTR.SUBSCR_POST_CD4":
                    return Common.StringToField(rdrF010_PAT_MSTR.GetString("SUBSCR_POST_CD4"));

                case "INDEXED.F010_PAT_MSTR.SUBSCR_POST_CD5":
                    return Common.StringToField(rdrF010_PAT_MSTR.GetString("SUBSCR_POST_CD5"));

                case "INDEXED.F010_PAT_MSTR.SUBSCR_POST_CD6":
                    return Common.StringToField(rdrF010_PAT_MSTR.GetString("SUBSCR_POST_CD6"));

                case "INDEXED.F010_PAT_MSTR.FILLER":
                    return Common.StringToField(rdrF010_PAT_MSTR.GetString("FILLER"));

                case "TEMPORARYDATA.U022A3.MOH_FLAG":
                    return Common.StringToField(rdrU022A3.GetString("MOH_FLAG"));

                case "TEMPORARYDATA.U022A3.DOLLAR_FLAG":
                    return Common.StringToField(rdrU022A3.GetString("DOLLAR_FLAG"));

                case "INDEXED.F010_PAT_MSTR.PAT_MESS_CODE":
                    return Common.StringToField(rdrF010_PAT_MSTR.GetString("PAT_MESS_CODE"));

                case "TEMPORARYDATA.U022A3.TRANSLATED_GROUP_NBR":
                    return Common.StringToField(rdrU022A3.GetString("TRANSLATED_GROUP_NBR"));

                case "TEMPORARYDATA.U022A3.CONTRACT_CODE":
                    return Common.StringToField(rdrU022A3.GetString("CONTRACT_CODE"));

                default:
                    return string.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                Access_U022A3();
                while (rdrU022A3.Read())
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
                rdrU022A3.Close();
            }
            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrU022A3 == null))
            {
                rdrU022A3.Close();
                rdrU022A3 = null;
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

        #endregion

        #endregion
    }
}
