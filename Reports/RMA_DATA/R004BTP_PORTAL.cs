#region "Screen Comments"

// DOC: R004BTP_PORTAL.QZS
// PROGRAM PURPOSE : TRANSACTION SUMMARY (DETAIL REPORT)
// SORT .SF FILE CREATED IN R004ATP AND CREATE
// R004ATP.TXT REPORT.
// MODIFICATION HISTORY
// DATE       BY WHOM   DESCRIPTION
// 05/jul/07  M.C.      clone from r004btp.qzs
// 06/jan/19  M.C. - add `~` before and after doc nbr & doc dept at the end of each report line
// set page length 62 width 137

#endregion

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
    public class R004BTP_PORTAL : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R004BTP_PORTAL";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrR004ATP = new Reader();
        private Reader rdrF002_CLAIMS_MSTR_HDR = new Reader();
        private Reader rdrF002_CLAIMS_MSTR_DTL = new Reader();
        private Reader rdrF070_DEPT_MSTR = new Reader();

        #endregion

        #region " Renaissance Data "

        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                // Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;

                Sort = "X_DOC_NBR ASC, ICONST_CLINIC_NBR_1_2 ASC, X_PAT_NAME ASC, CLMDTL_SV_DATE ASC, CLMDTL_ID ASC";

                // Start report data processing.
                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return ReportData;
        }

        #endregion

        #region " Renaissance Statements "

        #region " ACCESS "

        private void Access_R004ATP()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("CLMHDR_DOC_DEPT, ");
            strSQL.Append("X_DOC_NBR, ");
            strSQL.Append("ICONST_CLINIC_NBR_1_2, ");
            strSQL.Append("X_PAT_NAME, ");
            strSQL.Append("ICONST_DATE_PERIOD_END, ");
            strSQL.Append("ICONST_CLINIC_NAME, ");
            strSQL.Append("ICONST_CLINIC_NBR, ");
            strSQL.Append("X_DOC_NAME, ");
            strSQL.Append("X_PAT_ID_INFO, ");
            strSQL.Append("KEY_CLM_BATCH_NBR, ");
            strSQL.Append("KEY_CLM_CLAIM_NBR ");
            strSQL.Append("FROM TEMPORARYDATA.R004ATP ");

            strSQL.Append(Choose());

            rdrR004ATP.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);

            strSQL = null;
        }

        private void Link_F002_CLAIMS_MSTR_HDR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("CLMHDR_ADJ_OMA_CD, ");
            strSQL.Append("CLMHDR_REFERENCE, ");
            strSQL.Append("CLMHDR_DATE_SYS ");
            strSQL.Append("FROM INDEXED.F002_CLAIMS_MSTR_HDR ");
            strSQL.Append("WHERE ");
            strSQL.Append("KEY_CLM_TYPE = ").Append(Common.StringToField("B"));
            strSQL.Append(" AND KEY_CLM_BATCH_NBR = ").Append(Common.StringToField(rdrR004ATP.GetString("KEY_CLM_BATCH_NBR")));
            strSQL.Append(" AND KEY_CLM_CLAIM_NBR = ").Append(rdrR004ATP.GetNumber("KEY_CLM_CLAIM_NBR"));

            rdrF002_CLAIMS_MSTR_HDR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

            strSQL = null;
        }

        private void Link_F002_CLAIMS_MSTR_DTL()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("CLMDTL_ORIG_BATCH_NBR, ");
            strSQL.Append("CLMDTL_SV_YY, ");
            strSQL.Append("CLMDTL_SV_MM, ");
            strSQL.Append("CLMDTL_SV_DD, ");
            strSQL.Append("CLMDTL_BATCH_NBR, ");
            strSQL.Append("CLMDTL_CLAIM_NBR, ");
            strSQL.Append("CLMDTL_OMA_CD, ");
            strSQL.Append("CLMDTL_OMA_SUFF, ");
            strSQL.Append("CLMDTL_ADJ_NBR, ");
            strSQL.Append("CLMDTL_ADJ_CD, ");
            strSQL.Append("CLMDTL_FEE_OHIP, ");
            strSQL.Append("CLMDTL_AMT_TECH_BILLED, ");
            strSQL.Append("CLMDTL_NBR_SERV, ");
            strSQL.Append("CLMDTL_CONSEC_DATES_R, ");
            strSQL.Append("CLMDTL_AGENT_CD, ");
            strSQL.Append("CLMDTL_DIAG_CD, ");
            strSQL.Append("KEY_CLM_BATCH_NBR, ");
            strSQL.Append("KEY_CLM_CLAIM_NBR ");
            strSQL.Append("FROM INDEXED.F002_CLAIMS_MSTR_DTL ");
            strSQL.Append("WHERE ");
            strSQL.Append("KEY_CLM_TYPE = ").Append(Common.StringToField("B"));
            strSQL.Append(" AND KEY_CLM_BATCH_NBR = ").Append(Common.StringToField(rdrR004ATP.GetString("KEY_CLM_BATCH_NBR")));
            strSQL.Append(" AND KEY_CLM_CLAIM_NBR = ").Append(rdrR004ATP.GetNumber("KEY_CLM_CLAIM_NBR"));

            strSQL.Append(SelectIf_F002_CLAIMS_MSTR_DTL(false));

            rdrF002_CLAIMS_MSTR_DTL.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

            strSQL = null;
        }

        private void Link_F070_DEPT_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DEPT_NBR, ");
            strSQL.Append("DEPT_NAME ");
            strSQL.Append("FROM [101C].INDEXED.F070_DEPT_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DEPT_NBR = ").Append(rdrR004ATP.GetNumber("CLMHDR_DOC_DEPT"));

            rdrF070_DEPT_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

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

        private string SelectIf_F002_CLAIMS_MSTR_DTL(bool blnAddWhere)
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

            strSQL.Append(" (CLMDTL_OMA_CD <> '0000' AND ");
            strSQL.Append("CLMDTL_OMA_CD <> 'ZZZZ' AND ");
            strSQL.Append("CLMDTL_OMA_CD <> 'PAID' AND ");
            strSQL.Append("(CLMDTL_ORIG_BATCH_NBR =  ").Append(Common.StringToField(QDesign.NULL(rdrR004ATP.GetString("KEY_CLM_BATCH_NBR")))).Append("))");
            return strSQL.ToString();
        }

        #endregion

        #region " DEFINES "

        private string X_DOC_DEPT_NBR()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = "~" + rdrR004ATP.GetString("X_DOC_NBR") + QDesign.ASCII(rdrR004ATP.GetNumber("CLMHDR_DOC_DEPT"), 2) + "~";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_CLMHDR_REFERENCE()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.Substring(rdrF002_CLAIMS_MSTR_HDR.GetString("CLMHDR_REFERENCE"), 1, 9);
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_CLAIM_DTL_ID()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_BATCH_NBR") + QDesign.ASCII(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_CLAIM_NBR"), 2);
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private decimal X_OHIP_FEE()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_ADJ_CD")) == QDesign.NULL("M") | QDesign.NULL(rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_ADJ_CD")) == QDesign.NULL(" "))
                {
                    decReturnValue = rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_FEE_OHIP");
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private decimal X_TECH_FEE()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_ADJ_CD")) == QDesign.NULL("M") | QDesign.NULL(rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_ADJ_CD")) == QDesign.NULL(" "))
                {
                    decReturnValue = rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_AMT_TECH_BILLED");
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private decimal X_PROF_FEE()
        {
            decimal decReturnValue = 0;

            try
            {
                decReturnValue = X_OHIP_FEE() - X_TECH_FEE();
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private decimal X_OHIP_ADJ()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_ADJ_CD")) == QDesign.NULL("B") | QDesign.NULL(rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_ADJ_CD")) == QDesign.NULL("R"))
                {
                    decReturnValue = rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_FEE_OHIP");
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private decimal X_TECH_ADJ()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_ADJ_CD")) == QDesign.NULL("B") | QDesign.NULL(rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_ADJ_CD")) == QDesign.NULL("R"))
                {
                    decReturnValue = rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_AMT_TECH_BILLED");
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private decimal X_PROF_ADJ()
        {
            decimal decReturnValue = 0;

            try
            {
                decReturnValue = X_OHIP_ADJ() - X_TECH_ADJ();
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private decimal X_AR_OHIP_FEE()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_ADJ_CD")) == QDesign.NULL(" "))
                {
                    decReturnValue = rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_FEE_OHIP");
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private decimal X_AR_TECH_FEE()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_ADJ_CD")) == QDesign.NULL(" "))
                {
                    decReturnValue = rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_AMT_TECH_BILLED");
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private decimal X_AR_PROF_FEE()
        {
            decimal decReturnValue = 0;

            try
            {
                decReturnValue = X_AR_OHIP_FEE() - X_AR_TECH_FEE();
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private decimal X_AR_OHIP_ADJ()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_ADJ_CD")) == QDesign.NULL("B"))
                {
                    decReturnValue = rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_FEE_OHIP");
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private decimal X_AR_TECH_ADJ()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_ADJ_CD")) == QDesign.NULL("B"))
                {
                    decReturnValue = rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_AMT_TECH_BILLED");
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private decimal X_AR_PROF_ADJ()
        {
            decimal decReturnValue = 0;

            try
            {
                decReturnValue = X_AR_OHIP_ADJ() - X_AR_TECH_ADJ();
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private decimal X_AR_OHIP_TOTAL()
        {
            decimal decReturnValue = 0;

            try
            {
                decReturnValue = X_AR_OHIP_FEE() + X_AR_OHIP_ADJ();
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private decimal X_AR_TECH_TOTAL()
        {
            decimal decReturnValue = 0;

            try
            {
                decReturnValue = X_AR_TECH_FEE() + X_AR_TECH_ADJ();
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private decimal X_AR_PROF_TOTAL()
        {
            decimal decReturnValue = 0;

            try
            {
                decReturnValue = X_AR_PROF_FEE() + X_AR_PROF_ADJ();
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private decimal X_REV_OHIP_TOTAL()
        {
            decimal decReturnValue = 0;

            try
            {
                decReturnValue = X_OHIP_FEE() + X_OHIP_ADJ();
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private decimal X_REV_TECH_TOTAL()
        {
            decimal decReturnValue = 0;

            try
            {
                decReturnValue = X_TECH_FEE() + X_TECH_ADJ();
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private decimal X_REV_PROF_TOTAL()
        {
            decimal decReturnValue = 0;

            try
            {
                decReturnValue = X_PROF_FEE() + X_PROF_ADJ();
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private decimal X_NBR_SVCS()
        {
            decimal decReturnValue = 0;

            try
            {
                decReturnValue = rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_NBR_SERV") + QDesign.NConvert(QDesign.Substring(rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_CONSEC_DATES_R"), 1, 1)) + QDesign.NConvert(QDesign.Substring(rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_CONSEC_DATES_R"), 4, 1)) + QDesign.NConvert(QDesign.Substring(rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_CONSEC_DATES_R"), 7, 1));
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private string F002_CLAIMS_MSTR_CLMDTL_SV_DATE()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.ASCII(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_SV_YY"), 4) + QDesign.ASCII(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_SV_MM"), 2) + QDesign.ASCII(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_SV_DD"), 2);
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
            return strReturnValue;
        }

        private string F002_CLAIMS_MSTR_CLMDTL_ID()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = (rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_BATCH_NBR") + QDesign.ASCII(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_CLAIM_NBR"), 2) + rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_OMA_CD") + rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_OMA_SUFF") + QDesign.ASCII(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_ADJ_NBR"), 1));
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
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
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.R004ATP.ICONST_CLINIC_NBR_1_2", DataTypes.Numeric, 2);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.R004ATP.ICONST_DATE_PERIOD_END", DataTypes.Numeric, 8);
                AddControl(ReportSection.PAGE_HEADING, "X_DOC_DEPT_NBR", DataTypes.Character, 7);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.R004ATP.ICONST_CLINIC_NAME", DataTypes.Character, 20);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.R004ATP.ICONST_CLINIC_NBR", DataTypes.Character, 4);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.R004ATP.X_DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.R004ATP.X_DOC_NAME", DataTypes.Character, 35);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.R004ATP.CLMHDR_DOC_DEPT", DataTypes.Numeric, 2);
                AddControl(ReportSection.PAGE_HEADING, "INDEXED.F070_DEPT_MSTR.DEPT_NAME", DataTypes.Character, 30);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R004ATP.X_PAT_NAME", DataTypes.Character, 10);
                AddControl(ReportSection.REPORT, "X_CLAIM_DTL_ID", DataTypes.Character, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R004ATP.X_PAT_ID_INFO", DataTypes.Character, 12);
                AddControl(ReportSection.REPORT, "INDEXED.F002_CLAIMS_MSTR_DTL.CLMDTL_AGENT_CD", DataTypes.Numeric, 1);
                AddControl(ReportSection.REPORT, "INDEXED.F002_CLAIMS_MSTR_DTL.CLMDTL_ADJ_CD", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "X_OHIP_FEE", DataTypes.Numeric, 7);
                AddControl(ReportSection.REPORT, "X_TECH_FEE", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "X_PROF_FEE", DataTypes.Numeric, 7);
                AddControl(ReportSection.REPORT, "X_OHIP_ADJ", DataTypes.Numeric, 7);
                AddControl(ReportSection.REPORT, "X_TECH_ADJ", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "X_PROF_ADJ", DataTypes.Numeric, 7);
                AddControl(ReportSection.REPORT, "CLMDTL_SV_DATE", DataTypes.Character, 8);
                AddControl(ReportSection.REPORT, "INDEXED.F002_CLAIMS_MSTR_HDR.CLMHDR_DATE_SYS", DataTypes.Character, 8);
                AddControl(ReportSection.REPORT, "INDEXED.F002_CLAIMS_MSTR_DTL.CLMDTL_DIAG_CD", DataTypes.Numeric, 3);
                AddControl(ReportSection.REPORT, "INDEXED.F002_CLAIMS_MSTR_DTL.CLMDTL_OMA_CD", DataTypes.Character, 4);
                AddControl(ReportSection.REPORT, "INDEXED.F002_CLAIMS_MSTR_DTL.CLMDTL_OMA_SUFF", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "X_NBR_SVCS", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "X_CLMHDR_REFERENCE", DataTypes.Character, 9);
                AddControl(ReportSection.FOOTING_AT, "X_AR_OHIP_FEE", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "X_AR_TECH_FEE", DataTypes.Numeric, 6);
                AddControl(ReportSection.FOOTING_AT, "X_AR_PROF_FEE", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "X_AR_OHIP_ADJ", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "X_AR_TECH_ADJ", DataTypes.Numeric, 6);
                AddControl(ReportSection.FOOTING_AT, "X_AR_PROF_ADJ", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "X_AR_OHIP_TOTAL", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "X_AR_TECH_TOTAL", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "X_AR_PROF_TOTAL", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "X_REV_OHIP_TOTAL", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "X_REV_TECH_TOTAL", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "X_REV_PROF_TOTAL", DataTypes.Numeric, 7);
                AddControl(ReportSection.REPORT, "CLMDTL_ID", DataTypes.Character, 16);
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        #endregion

        #region " Renaissance Precompiler Generated Code "

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 10/19/2017 11:23:50 AM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "TEMPORARYDATA.R004ATP.ICONST_CLINIC_NBR_1_2":
                    return rdrR004ATP.GetNumber("ICONST_CLINIC_NBR_1_2").ToString();

                case "TEMPORARYDATA.R004ATP.ICONST_DATE_PERIOD_END":
                    return rdrR004ATP.GetNumber("ICONST_DATE_PERIOD_END").ToString();

                case "X_DOC_DEPT_NBR":
                    return Common.StringToField(X_DOC_DEPT_NBR());

                case "TEMPORARYDATA.R004ATP.ICONST_CLINIC_NAME":
                    return Common.StringToField(rdrR004ATP.GetString("ICONST_CLINIC_NAME"));

                case "TEMPORARYDATA.R004ATP.ICONST_CLINIC_NBR":
                    return Common.StringToField(rdrR004ATP.GetString("ICONST_CLINIC_NBR"));

                case "TEMPORARYDATA.R004ATP.X_DOC_NBR":
                    return Common.StringToField(rdrR004ATP.GetString("X_DOC_NBR"));

                case "TEMPORARYDATA.R004ATP.X_DOC_NAME":
                    return Common.StringToField(rdrR004ATP.GetString("X_DOC_NAME"));

                case "TEMPORARYDATA.R004ATP.CLMHDR_DOC_DEPT":
                    return rdrR004ATP.GetNumber("CLMHDR_DOC_DEPT").ToString();

                case "INDEXED.F070_DEPT_MSTR.DEPT_NAME":
                    return Common.StringToField(rdrF070_DEPT_MSTR.GetString("DEPT_NAME"));

                case "TEMPORARYDATA.R004ATP.X_PAT_NAME":
                    return Common.StringToField(rdrR004ATP.GetString("X_PAT_NAME"));

                case "X_CLAIM_DTL_ID":
                    return Common.StringToField(X_CLAIM_DTL_ID());

                case "TEMPORARYDATA.R004ATP.X_PAT_ID_INFO":
                    return Common.StringToField(rdrR004ATP.GetString("X_PAT_ID_INFO"));

                case "INDEXED.F002_CLAIMS_MSTR_DTL.CLMDTL_AGENT_CD":
                    return rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_AGENT_CD").ToString();

                case "INDEXED.F002_CLAIMS_MSTR_DTL.CLMDTL_ADJ_CD":
                    return Common.StringToField(rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_ADJ_CD"));

                case "X_OHIP_FEE":
                    return X_OHIP_FEE().ToString();

                case "X_TECH_FEE":
                    return X_TECH_FEE().ToString();

                case "X_PROF_FEE":
                    return X_PROF_FEE().ToString();

                case "X_OHIP_ADJ":
                    return X_OHIP_ADJ().ToString();

                case "X_TECH_ADJ":
                    return X_TECH_ADJ().ToString();

                case "X_PROF_ADJ":
                    return X_PROF_ADJ().ToString();

                case "CLMDTL_SV_DATE":
                    return Common.StringToField(F002_CLAIMS_MSTR_CLMDTL_SV_DATE());

                case "INDEXED.F002_CLAIMS_MSTR_HDR.CLMHDR_DATE_SYS":
                    return Common.StringToField(rdrF002_CLAIMS_MSTR_HDR.GetString("CLMHDR_DATE_SYS"));

                case "INDEXED.F002_CLAIMS_MSTR_DTL.CLMDTL_DIAG_CD":
                    return rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_DIAG_CD").ToString();

                case "INDEXED.F002_CLAIMS_MSTR_DTL.CLMDTL_OMA_CD":
                    return Common.StringToField(rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_OMA_CD"));

                case "INDEXED.F002_CLAIMS_MSTR_DTL.CLMDTL_OMA_SUFF":
                    return Common.StringToField(rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_OMA_SUFF"));

                case "X_NBR_SVCS":
                    return X_NBR_SVCS().ToString();

                case "X_CLMHDR_REFERENCE":
                    return Common.StringToField(X_CLMHDR_REFERENCE());

                case "X_AR_OHIP_FEE":
                    return X_AR_OHIP_FEE().ToString();

                case "X_AR_TECH_FEE":
                    return X_AR_TECH_FEE().ToString();

                case "X_AR_PROF_FEE":
                    return X_AR_PROF_FEE().ToString();

                case "X_AR_OHIP_ADJ":
                    return X_AR_OHIP_ADJ().ToString();

                case "X_AR_TECH_ADJ":
                    return X_AR_TECH_ADJ().ToString();

                case "X_AR_PROF_ADJ":
                    return X_AR_PROF_ADJ().ToString();

                case "X_AR_OHIP_TOTAL":
                    return X_AR_OHIP_TOTAL().ToString();

                case "X_AR_TECH_TOTAL":
                    return X_AR_TECH_TOTAL().ToString();

                case "X_AR_PROF_TOTAL":
                    return X_AR_PROF_TOTAL().ToString();

                case "X_REV_OHIP_TOTAL":
                    return X_REV_OHIP_TOTAL().ToString();

                case "X_REV_TECH_TOTAL":
                    return X_REV_TECH_TOTAL().ToString();

                case "X_REV_PROF_TOTAL":
                    return X_REV_PROF_TOTAL().ToString();

                case "CLMDTL_ID":
                    return Common.StringToField(F002_CLAIMS_MSTR_CLMDTL_ID());

                default:

                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_R004ATP();

                while (rdrR004ATP.Read())
                {
                    Link_F002_CLAIMS_MSTR_HDR();
                    while (rdrF002_CLAIMS_MSTR_HDR.Read())
                    {
                        Link_F002_CLAIMS_MSTR_DTL();
                        while (rdrF002_CLAIMS_MSTR_DTL.Read())
                        {
                            Link_F070_DEPT_MSTR();
                            while ((rdrF070_DEPT_MSTR.Read()))
                            {
                                WriteData();
                            }
                            rdrF070_DEPT_MSTR.Close();
                        }
                        rdrF002_CLAIMS_MSTR_DTL.Close();
                    }
                    rdrF002_CLAIMS_MSTR_HDR.Close();
                }
                rdrR004ATP.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrR004ATP != null))
            {
                rdrR004ATP.Close();
                rdrR004ATP = null;
            }
            if ((rdrF002_CLAIMS_MSTR_HDR != null))
            {
                rdrF002_CLAIMS_MSTR_HDR.Close();
                rdrF002_CLAIMS_MSTR_HDR = null;
            }
            if ((rdrF002_CLAIMS_MSTR_DTL != null))
            {
                rdrF002_CLAIMS_MSTR_DTL.Close();
                rdrF002_CLAIMS_MSTR_DTL = null;
            }
            if ((rdrF070_DEPT_MSTR != null))
            {
                rdrF070_DEPT_MSTR.Close();
                rdrF070_DEPT_MSTR = null;
            }
        }


        #endregion

        #endregion
    }
}
