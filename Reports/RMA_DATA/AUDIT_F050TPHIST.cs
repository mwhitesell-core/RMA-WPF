#region "Screen Comments"

// 2015/Apr/01   MC      As per Yasemin, only pick up the current year records
// MC - include  constants-mstr-rec-7 to pick up current year
// access f050tp-doc-revenue-mstr-history

#endregion

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
    public class AUDIT_F050TPHIST : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "AUDIT_F050TPHIST";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrCONSTANTS_MSTR_REC_7 = new Reader();
        private Reader rdrF050TP_DOC_REVENUE_MSTR_HISTORY = new Reader();

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

                Sort = "ICONST_DATE_PERIOD_END ASC, EP_YR ASC, DOCREVTP_CLINIC_NBR ASC";

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

        private void Access_CONSTANTS_MSTR_REC_7()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("EP_YR, ");
            strSQL.Append("CONST_REC_NBR ");
            strSQL.Append("FROM INDEXED.CONSTANTS_MSTR_REC_7 ");

            strSQL.Append(Choose());

            rdrCONSTANTS_MSTR_REC_7.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

            strSQL = null;
        }

        private void Link_F050TP_DOC_REVENUE_MSTR_HISTORY()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("EP_YR, ");
            strSQL.Append("ICONST_DATE_PERIOD_END, ");
            strSQL.Append("DOCREVTP_CLINIC_NBR, ");
            strSQL.Append("DOCREVTP_IN_TECH_AMT_BILLED1, ");
            strSQL.Append("DOCREVTP_IN_TECH_AMT_BILLED2, ");
            strSQL.Append("DOCREVTP_OUT_TECH_AMT_BILLED1, ");
            strSQL.Append("DOCREVTP_OUT_TECH_AMT_BILLED2, ");
            strSQL.Append("DOCREVTP_IN_TECH_AMT_ADJUSTS1, ");
            strSQL.Append("DOCREVTP_IN_TECH_AMT_ADJUSTS2, ");
            strSQL.Append("DOCREVTP_OUT_TECH_AMT_ADJUSTS1, ");
            strSQL.Append("DOCREVTP_OUT_TECH_AMT_ADJUSTS2, ");
            strSQL.Append("DOCREVTP_IN_PROF_AMT_BILLED1, ");
            strSQL.Append("DOCREVTP_IN_PROF_AMT_BILLED2, ");
            strSQL.Append("DOCREVTP_OUT_PROF_AMT_BILLED1, ");
            strSQL.Append("DOCREVTP_OUT_PROF_AMT_BILLED2, ");
            strSQL.Append("DOCREVTP_IN_PROF_AMT_ADJUSTS1, ");
            strSQL.Append("DOCREVTP_IN_PROF_AMT_ADJUSTS2, ");
            strSQL.Append("DOCREVTP_OUT_PROF_AMT_ADJUSTS1, ");
            strSQL.Append("DOCREVTP_OUT_PROF_AMT_ADJUSTS2, ");
            strSQL.Append("DOCREVTP_IN_TECH_NBR_SVC1, ");
            strSQL.Append("DOCREVTP_IN_TECH_NBR_SVC2, ");
            strSQL.Append("DOCREVTP_OUT_TECH_NBR_SVC1, ");
            strSQL.Append("DOCREVTP_OUT_TECH_NBR_SVC2, ");
            strSQL.Append("DOCREVTP_IN_PROF_NBR_SVC1, ");
            strSQL.Append("DOCREVTP_IN_PROF_NBR_SVC2, ");
            strSQL.Append("DOCREVTP_OUT_PROF_NBR_SVC1, ");
            strSQL.Append("DOCREVTP_OUT_PROF_NBR_SVC2 ");
            strSQL.Append("FROM INDEXED.F050TP_DOC_REVENUE_MSTR_HISTORY ");
            strSQL.Append("WHERE ");
            strSQL.Append("EP_YR = ").Append(rdrCONSTANTS_MSTR_REC_7.GetNumber("EP_YR"));

            rdrF050TP_DOC_REVENUE_MSTR_HISTORY.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

            strSQL = null;
        }

        #endregion

        #region " CHOOSE "

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(string.Empty);

            strChoose.Append(ReportDataFunctions.GetWhereCondition("CONST_REC_NBR", "7", true));

            return strChoose.ToString();
        }

        #endregion

        #region " SELECT IF "

        #endregion

        #region " DEFINES "

        private decimal T_AMT_MTD()
        {
            decimal decReturnValue = 0;

            try
            {
                decReturnValue = (rdrF050TP_DOC_REVENUE_MSTR_HISTORY.GetNumber("DOCREVTP_IN_TECH_AMT_BILLED1") + rdrF050TP_DOC_REVENUE_MSTR_HISTORY.GetNumber("DOCREVTP_OUT_TECH_AMT_BILLED1") + rdrF050TP_DOC_REVENUE_MSTR_HISTORY.GetNumber("DOCREVTP_IN_TECH_AMT_ADJUSTS1") + rdrF050TP_DOC_REVENUE_MSTR_HISTORY.GetNumber("DOCREVTP_OUT_TECH_AMT_ADJUSTS1"));
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private decimal P_AMT_MTD()
        {
            decimal decReturnValue = 0;

            try
            {
                decReturnValue = (rdrF050TP_DOC_REVENUE_MSTR_HISTORY.GetNumber("DOCREVTP_IN_PROF_AMT_BILLED1") + rdrF050TP_DOC_REVENUE_MSTR_HISTORY.GetNumber("DOCREVTP_OUT_PROF_AMT_BILLED1") + rdrF050TP_DOC_REVENUE_MSTR_HISTORY.GetNumber("DOCREVTP_IN_PROF_AMT_ADJUSTS1") + rdrF050TP_DOC_REVENUE_MSTR_HISTORY.GetNumber("DOCREVTP_OUT_PROF_AMT_ADJUSTS1"));
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private decimal T_SVC_MTD()
        {
            decimal decReturnValue = 0;

            try
            {
                decReturnValue = (rdrF050TP_DOC_REVENUE_MSTR_HISTORY.GetNumber("DOCREVTP_IN_TECH_NBR_SVC1") + rdrF050TP_DOC_REVENUE_MSTR_HISTORY.GetNumber("DOCREVTP_OUT_TECH_NBR_SVC1") + rdrF050TP_DOC_REVENUE_MSTR_HISTORY.GetNumber("DOCREVTP_IN_PROF_NBR_SVC1") + rdrF050TP_DOC_REVENUE_MSTR_HISTORY.GetNumber("DOCREVTP_OUT_PROF_NBR_SVC1"));
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private decimal TOTAL_AMT_MTD()
        {
            decimal decReturnValue = 0;

            try
            {
                decReturnValue = (T_AMT_MTD() + P_AMT_MTD());
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private decimal T_AMT_YTD()
        {
            decimal decReturnValue = 0;

            try
            {
                decReturnValue = (rdrF050TP_DOC_REVENUE_MSTR_HISTORY.GetNumber("DOCREVTP_IN_TECH_AMT_BILLED2") + rdrF050TP_DOC_REVENUE_MSTR_HISTORY.GetNumber("DOCREVTP_OUT_TECH_AMT_BILLED2") + rdrF050TP_DOC_REVENUE_MSTR_HISTORY.GetNumber("DOCREVTP_IN_TECH_AMT_ADJUSTS2") + rdrF050TP_DOC_REVENUE_MSTR_HISTORY.GetNumber("DOCREVTP_OUT_TECH_AMT_ADJUSTS2"));
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private decimal P_AMT_YTD()
        {
            decimal decReturnValue = 0;

            try
            {
                decReturnValue = (rdrF050TP_DOC_REVENUE_MSTR_HISTORY.GetNumber("DOCREVTP_IN_PROF_AMT_BILLED2") + rdrF050TP_DOC_REVENUE_MSTR_HISTORY.GetNumber("DOCREVTP_OUT_PROF_AMT_BILLED2") + rdrF050TP_DOC_REVENUE_MSTR_HISTORY.GetNumber("DOCREVTP_IN_PROF_AMT_ADJUSTS2") + rdrF050TP_DOC_REVENUE_MSTR_HISTORY.GetNumber("DOCREVTP_OUT_PROF_AMT_ADJUSTS2"));
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private decimal T_SVC_YTD()
        {
            decimal decReturnValue = 0;

            try
            {
                decReturnValue = (rdrF050TP_DOC_REVENUE_MSTR_HISTORY.GetNumber("DOCREVTP_IN_TECH_NBR_SVC2") + rdrF050TP_DOC_REVENUE_MSTR_HISTORY.GetNumber("DOCREVTP_OUT_TECH_NBR_SVC2") + rdrF050TP_DOC_REVENUE_MSTR_HISTORY.GetNumber("DOCREVTP_IN_PROF_NBR_SVC2") + rdrF050TP_DOC_REVENUE_MSTR_HISTORY.GetNumber("DOCREVTP_OUT_PROF_NBR_SVC2"));
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private decimal TOTAL_AMT_YTD()
        {
            decimal decReturnValue = 0;

            try
            {
                decReturnValue = (T_AMT_YTD() + P_AMT_YTD());
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        #endregion

        #region " CONTROLS "

        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F050TP_DOC_REVENUE_MSTR_HISTORY.DOCREVTP_CLINIC_NBR", DataTypes.Numeric, 2);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.CONSTANTS_MSTR_REC_7.EP_YR", DataTypes.Numeric, 4);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F050TP_DOC_REVENUE_MSTR_HISTORY.ICONST_DATE_PERIOD_END", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "T_AMT_MTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "P_AMT_MTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "TOTAL_AMT_MTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "T_AMT_YTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "P_AMT_YTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "TOTAL_AMT_YTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "T_SVC_MTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "T_SVC_YTD", DataTypes.Numeric, 8);
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
        //# Do not delete, modify or move it.  Updated: 9/25/2017 3:09:45 PM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "INDEXED.F050TP_DOC_REVENUE_MSTR_HISTORY.DOCREVTP_CLINIC_NBR":
                    return rdrF050TP_DOC_REVENUE_MSTR_HISTORY.GetNumber("DOCREVTP_CLINIC_NBR").ToString();

                case "INDEXED.CONSTANTS_MSTR_REC_7.EP_YR":
                    return rdrCONSTANTS_MSTR_REC_7.GetNumber("EP_YR").ToString();

                case "INDEXED.F050TP_DOC_REVENUE_MSTR_HISTORY.ICONST_DATE_PERIOD_END":
                    return rdrF050TP_DOC_REVENUE_MSTR_HISTORY.GetNumber("ICONST_DATE_PERIOD_END").ToString();

                case "T_AMT_MTD":
                    return T_AMT_MTD().ToString();

                case "P_AMT_MTD":
                    return P_AMT_MTD().ToString();

                case "TOTAL_AMT_MTD":
                    return TOTAL_AMT_MTD().ToString();

                case "T_AMT_YTD":
                    return T_AMT_YTD().ToString();

                case "P_AMT_YTD":
                    return P_AMT_YTD().ToString();

                case "TOTAL_AMT_YTD":
                    return TOTAL_AMT_YTD().ToString();

                case "T_SVC_MTD":
                    return T_SVC_MTD().ToString();

                case "T_SVC_YTD":
                    return T_SVC_YTD().ToString();

                default:

                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_CONSTANTS_MSTR_REC_7();

                while (rdrCONSTANTS_MSTR_REC_7.Read())
                {
                    Link_F050TP_DOC_REVENUE_MSTR_HISTORY();
                    while (rdrF050TP_DOC_REVENUE_MSTR_HISTORY.Read())
                    {
                        while ((rdrF050TP_DOC_REVENUE_MSTR_HISTORY.Read()))
                        {
                            WriteData();
                        }
                    }
                    rdrF050TP_DOC_REVENUE_MSTR_HISTORY.Close();
                }
                rdrCONSTANTS_MSTR_REC_7.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrCONSTANTS_MSTR_REC_7 != null))
            {
                rdrCONSTANTS_MSTR_REC_7.Close();
                rdrCONSTANTS_MSTR_REC_7 = null;
            }
            if ((rdrF050TP_DOC_REVENUE_MSTR_HISTORY != null))
            {
                rdrF050TP_DOC_REVENUE_MSTR_HISTORY.Close();
                rdrF050TP_DOC_REVENUE_MSTR_HISTORY = null;
            }
        }


        #endregion

        #endregion
    }
}
