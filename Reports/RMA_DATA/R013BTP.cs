//  DOC: R013BTP.QZS
//  DOC: MONTHLY REVENUE RECONCILLIATION BY LOCATION
//  DOC: SORT BY CLINIC/BY AGENT  (SUMMARY REPORT)
//  DOC: RUN FOR: MUMC DIAGNOSTICS
//  PROGRAM PURPOSE : REVENUE ANALYSIS RECONCILIATION BY LOCATION
//  R013TPA.CB CONVERSTION TO POWERHOUSE R013BTP.QZS
//  THIS IS THE FIRST OF 3 PROGRAMS APPEND
//  R013BTP.TXT R013CTP.TXT END OF R013ATP.TXT
//  DATE       BY WHOM   DESCRIPTION
//  92/06/02   YASEMIN   ORIGINAL
//  03/dec/17  A.A.      alpha doctor nbr
//  2010/02/04 yas       - add new clinic 66
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
    public class R013BTP : BaseRDLClass
    {
        protected const string REPORT_NAME = "R013BTP";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrF050TP_DOC_REVENUE_MSTR = new Reader();
        private Reader rdrF020_DOCTOR_MSTR = new Reader();
        private Reader rdrICONST_MSTR_REC = new Reader();
        private Reader rdrF030_LOCATIONS_MSTR = new Reader();
        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                //  Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;
                Sort = "DOCREVTP_CLINIC_NBR ASC, DOCREVTP_AGENT_CD ASC";
                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return ReportData;
        }
        private void Access_F050TP_DOC_REVENUE_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            strSQL.Append("SELECT ");
            strSQL.Append("DOCREVTP_DOC_NBR, ");
            strSQL.Append("DOCREVTP_CLINIC_NBR, ");
            strSQL.Append(" DOCREVTP_AGENT_CD, ");
            strSQL.Append(" DOCREVTP_LOC_CD, ");
            strSQL.Append(" DOCREVTP_OMA_CODE, ");
            strSQL.Append(" DOCREVTP_OMA_SUFFIX, ");
            strSQL.Append(" DOCREVTP_DOC_NBR, ");
            strSQL.Append("DOCREVTP_IN_TECH_AMT_BILLED1, ");
            strSQL.Append("DOCREVTP_IN_TECH_AMT_BILLED2, ");
            strSQL.Append("DOCREVTP_OUT_TECH_AMT_BILLED1, ");
            strSQL.Append("DOCREVTP_OUT_TECH_AMT_BILLED2, ");
            strSQL.Append("DOCREVTP_IN_TECH_AMT_ADJUSTS1, ");
            strSQL.Append("DOCREVTP_IN_TECH_AMT_ADJUSTS2, ");
            strSQL.Append("DOCREVTP_OUT_TECH_AMT_ADJUSTS1, ");
            strSQL.Append("DOCREVTP_OUT_TECH_AMT_ADJUSTS2, ");
            strSQL.Append("DOCREVTP_IN_TECH_NBR_SVC1, ");
            strSQL.Append("DOCREVTP_IN_TECH_NBR_SVC2, ");
            strSQL.Append("DOCREVTP_OUT_TECH_NBR_SVC1, ");
            strSQL.Append("DOCREVTP_OUT_TECH_NBR_SVC2, ");
            strSQL.Append("DOCREVTP_IN_PROF_AMT_BILLED1, ");
            strSQL.Append("DOCREVTP_IN_PROF_AMT_BILLED2, ");
            strSQL.Append("DOCREVTP_OUT_PROF_AMT_BILLED1, ");
            strSQL.Append("DOCREVTP_OUT_PROF_AMT_BILLED2, ");
            strSQL.Append("DOCREVTP_IN_PROF_AMT_ADJUSTS1, ");
            strSQL.Append("DOCREVTP_IN_PROF_AMT_ADJUSTS2, ");
            strSQL.Append("DOCREVTP_OUT_PROF_AMT_ADJUSTS1, ");
            strSQL.Append("DOCREVTP_OUT_PROF_AMT_ADJUSTS2, ");
            strSQL.Append("DOCREVTP_IN_PROF_NBR_SVC1, ");
            strSQL.Append("DOCREVTP_IN_PROF_NBR_SVC2, ");
            strSQL.Append("DOCREVTP_OUT_PROF_NBR_SVC1, ");
            strSQL.Append("DOCREVTP_OUT_PROF_NBR_SVC2 ");
            strSQL.Append("FROM INDEXED.F050TP_DOC_REVENUE_MSTR ");
            strSQL.Append(Choose());
            rdrF050TP_DOC_REVENUE_MSTR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_F020_DOCTOR_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("DOC_INIT1, ");
            strSQL.Append(" DOC_INIT2, ");
            strSQL.Append(" DOC_INIT3, ");
            strSQL.Append("DOC_NAME ");
            strSQL.Append("FROM INDEXED.F020_DOCTOR_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_NBR = ").Append(Common.StringToField(rdrF050TP_DOC_REVENUE_MSTR.GetString("DOCREVTP_DOC_NBR")));
            rdrF020_DOCTOR_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_ICONST_MSTR_REC()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("ICONST_CLINIC_NBR_1_2, ");
            strSQL.Append("ICONST_DATE_PERIOD_END_YY, ");
            strSQL.Append(" ICONST_DATE_PERIOD_END_MM, ");
            strSQL.Append(" ICONST_DATE_PERIOD_END_DD, ");
            strSQL.Append("ICONST_CLINIC_NAME, ");
            strSQL.Append("ICONST_CLINIC_NBR ");
            strSQL.Append("FROM INDEXED.ICONST_MSTR_REC ");
            strSQL.Append("WHERE ");
            strSQL.Append("ICONST_CLINIC_NBR_1_2 = ").Append(rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_CLINIC_NBR"));
            rdrICONST_MSTR_REC.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
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
            strSQL.Append("LOC_NBR = ").Append(Common.StringToField(rdrF050TP_DOC_REVENUE_MSTR.GetString("DOCREVTP_LOC_CD")));
            rdrF030_LOCATIONS_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(String.Empty);
            // TODO: CHOOSE Statement - May require manual changes.
            strChoose.Append("WHERE DOCREVTP_CLINIC_NBR >= 60 AND DOCREVTP_CLINIC_NBR <= 66");
            return strChoose.ToString().ToString();
        }

        private decimal T_AMT_MTD()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = (rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_IN_TECH_AMT_BILLED1") + rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_OUT_TECH_AMT_BILLED1"));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal T_ADJ_MTD()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = (rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_IN_TECH_AMT_ADJUSTS1") + rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_OUT_TECH_AMT_ADJUSTS1"));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal T_SVC_MTD()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = (rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_IN_TECH_NBR_SVC1") + rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_OUT_TECH_NBR_SVC1"));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal NET_T_MTD()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = (T_AMT_MTD() + T_ADJ_MTD());
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal P_AMT_MTD()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = (rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_IN_PROF_AMT_BILLED1") + rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_OUT_PROF_AMT_BILLED1"));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal P_ADJ_MTD()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = (rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_IN_PROF_AMT_ADJUSTS1") + rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_OUT_PROF_AMT_ADJUSTS1"));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal P_SVC_MTD()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = (rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_IN_PROF_NBR_SVC1") + rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_OUT_PROF_NBR_SVC1"));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal NET_P_MTD()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = (P_AMT_MTD() + P_ADJ_MTD());
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal TOTAL_SVC_MTD()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(T_SVC_MTD()) != QDesign.NULL(0d)))
                {
                    decReturnValue = T_SVC_MTD();
                }
                else
                {
                    decReturnValue = P_SVC_MTD();
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal TOTAL_ADJ_MTD()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = (T_ADJ_MTD() + P_ADJ_MTD());
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal TOTAL_AMT_MTD()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = (NET_T_MTD() + NET_P_MTD());
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal T_AMT_YTD()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = (rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_IN_TECH_AMT_BILLED2") + rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_OUT_TECH_AMT_BILLED2"));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal T_ADJ_YTD()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = (rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_IN_TECH_AMT_ADJUSTS2") + rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_OUT_TECH_AMT_ADJUSTS2"));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal T_SVC_YTD()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = (rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_IN_TECH_NBR_SVC2") + rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_OUT_TECH_NBR_SVC2"));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal NET_T_YTD()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = (T_AMT_YTD() + T_ADJ_YTD());
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal P_AMT_YTD()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = (rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_IN_PROF_AMT_BILLED2") + rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_OUT_PROF_AMT_BILLED2"));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal P_ADJ_YTD()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = (rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_IN_PROF_AMT_ADJUSTS2") + rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_OUT_PROF_AMT_ADJUSTS2"));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal P_SVC_YTD()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = (rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_IN_PROF_NBR_SVC2") + rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_OUT_PROF_NBR_SVC2"));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal NET_P_YTD()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = (P_AMT_YTD() + P_ADJ_YTD());
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal TOTAL_SVC_YTD()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(T_SVC_YTD()) != QDesign.NULL(0d)))
                {
                    decReturnValue = T_SVC_YTD();
                }
                else
                {
                    decReturnValue = P_SVC_YTD();
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal TOTAL_ADJ_YTD()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = (T_ADJ_YTD() + P_ADJ_YTD());
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal TOTAL_AMT_YTD()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = (NET_T_YTD() + NET_P_YTD());
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private string X_NAME()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = QDesign.Pack((rdrF020_DOCTOR_MSTR.GetString("DOC_INIT1") + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT2") + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT3") + (" " + rdrF020_DOCTOR_MSTR.GetString("DOC_NAME"))));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_DAY()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = QDesign.ASCII(rdrICONST_MSTR_REC.GetNumber("ICONST_DATE_PERIOD_END_DD"), 2);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_MTH()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = QDesign.Substring(QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8), 5, 2);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_YEAR()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = QDesign.Substring(QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8), 1, 4);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_MONTH()
        {
            string strReturnValue = String.Empty;
            try
            {
                if ((QDesign.NULL(X_MTH()) == "01"))
                {
                    strReturnValue = "JANUARY";
                }
                else if ((QDesign.NULL(X_MTH()) == "02"))
                {
                    strReturnValue = "FEBRUARY";
                }
                else if ((QDesign.NULL(X_MTH()) == "03"))
                {
                    strReturnValue = "MARCH";
                }
                else if ((QDesign.NULL(X_MTH()) == "04"))
                {
                    strReturnValue = "APRIL";
                }
                else if ((QDesign.NULL(X_MTH()) == "05"))
                {
                    strReturnValue = "MAY";
                }
                else if (((QDesign.NULL(X_MTH()) == "06")
                            && (QDesign.NULL(X_DAY()).CompareTo("30") < 0)))
                {
                    strReturnValue = "JUNE";
                }
                else if (((QDesign.NULL(X_MTH()) == "06")
                            && (QDesign.NULL(X_DAY()) == "30")))
                {
                    strReturnValue = "YEAREND";
                }
                else if ((QDesign.NULL(X_MTH()) == "07"))
                {
                    strReturnValue = "JULY";
                }
                else if ((QDesign.NULL(X_MTH()) == "08"))
                {
                    strReturnValue = "AUGUST";
                }
                else if ((QDesign.NULL(X_MTH()) == "09"))
                {
                    strReturnValue = "SEPTEMBER";
                }
                else if ((QDesign.NULL(X_MTH()) == "10"))
                {
                    strReturnValue = "OCTOBER";
                }
                else if ((QDesign.NULL(X_MTH()) == "11"))
                {
                    strReturnValue = "NOVEMBER";
                }
                else if ((QDesign.NULL(X_MTH()) == "12"))
                {
                    strReturnValue = "DECEMBER";
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_DATE()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = QDesign.Pack(X_MONTH() + " / " + X_YEAR());
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
                AddControl(ReportSection.PAGE_HEADING, "INDEXED.F050TP_DOC_REVENUE_MSTR.DOCREVTP_CLINIC_NBR", DataTypes.Numeric, 2);
                AddControl(ReportSection.PAGE_HEADING, "ICONST_DATE_PERIOD_END", DataTypes.Numeric, 8);
                AddControl(ReportSection.PAGE_HEADING, "INDEXED.ICONST_MSTR_REC.ICONST_CLINIC_NAME", DataTypes.Character, 20);
                AddControl(ReportSection.PAGE_HEADING, "INDEXED.ICONST_MSTR_REC.ICONST_CLINIC_NBR", DataTypes.Character, 4);
                AddControl(ReportSection.PAGE_HEADING, "X_DATE", DataTypes.Character, 15);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F050TP_DOC_REVENUE_MSTR.DOCREVTP_AGENT_CD", DataTypes.Character, 1);
                AddControl(ReportSection.FOOTING_AT, "T_SVC_MTD", DataTypes.Numeric, 5);
                AddControl(ReportSection.FOOTING_AT, "T_AMT_MTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "T_ADJ_MTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "NET_T_MTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "P_SVC_MTD", DataTypes.Numeric, 5);
                AddControl(ReportSection.FOOTING_AT, "P_AMT_MTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "P_ADJ_MTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "NET_P_MTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "TOTAL_SVC_MTD", DataTypes.Numeric, 5);
                AddControl(ReportSection.FOOTING_AT, "TOTAL_ADJ_MTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "TOTAL_AMT_MTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "T_SVC_YTD", DataTypes.Numeric, 5);
                AddControl(ReportSection.FOOTING_AT, "T_AMT_YTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "T_ADJ_YTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "NET_T_YTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "P_SVC_YTD", DataTypes.Numeric, 5);
                AddControl(ReportSection.FOOTING_AT, "P_AMT_YTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "P_ADJ_YTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "NET_P_YTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "TOTAL_SVC_YTD", DataTypes.Numeric, 5);
                AddControl(ReportSection.FOOTING_AT, "TOTAL_ADJ_YTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "TOTAL_AMT_YTD", DataTypes.Numeric, 8);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-05-10 11:27:46 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            // TODO: Remove duplicate controls, if there are any.
            switch (strControl)
            {
                case "INDEXED.F050TP_DOC_REVENUE_MSTR.DOCREVTP_CLINIC_NBR":
                    return rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_CLINIC_NBR").ToString();
                case "ICONST_DATE_PERIOD_END":
                    return ICONST_MSTR_REC_ICONST_DATE_PERIOD_END().ToString();
                case "INDEXED.ICONST_MSTR_REC.ICONST_CLINIC_NAME":
                    return Common.StringToField(rdrICONST_MSTR_REC.GetString("ICONST_CLINIC_NAME"));
                case "INDEXED.ICONST_MSTR_REC.ICONST_CLINIC_NBR":
                    return Common.StringToField(rdrICONST_MSTR_REC.GetString("ICONST_CLINIC_NBR"));
                case "X_DATE":
                    return Common.StringToField(X_DATE(), intSize);
                case "INDEXED.F050TP_DOC_REVENUE_MSTR.DOCREVTP_AGENT_CD":
                    return Common.StringToField(rdrF050TP_DOC_REVENUE_MSTR.GetString("DOCREVTP_AGENT_CD"));
                case "T_SVC_MTD":
                    return T_SVC_MTD().ToString();
                case "T_AMT_MTD":
                    return T_AMT_MTD().ToString();
                case "T_ADJ_MTD":
                    return T_ADJ_MTD().ToString();
                case "NET_T_MTD":
                    return NET_T_MTD().ToString();
                case "P_SVC_MTD":
                    return P_SVC_MTD().ToString();
                case "P_AMT_MTD":
                    return P_AMT_MTD().ToString();
                case "P_ADJ_MTD":
                    return P_ADJ_MTD().ToString();
                case "NET_P_MTD":
                    return NET_P_MTD().ToString();
                case "TOTAL_SVC_MTD":
                    return TOTAL_SVC_MTD().ToString();
                case "TOTAL_ADJ_MTD":
                    return TOTAL_ADJ_MTD().ToString();
                case "TOTAL_AMT_MTD":
                    return TOTAL_AMT_MTD().ToString();
                case "T_SVC_YTD":
                    return T_SVC_YTD().ToString();
                case "T_AMT_YTD":
                    return T_AMT_YTD().ToString();
                case "T_ADJ_YTD":
                    return T_ADJ_YTD().ToString();
                case "NET_T_YTD":
                    return NET_T_YTD().ToString();
                case "P_SVC_YTD":
                    return P_SVC_YTD().ToString();
                case "P_AMT_YTD":
                    return P_AMT_YTD().ToString();
                case "P_ADJ_YTD":
                    return P_ADJ_YTD().ToString();
                case "NET_P_YTD":
                    return NET_P_YTD().ToString();
                case "TOTAL_SVC_YTD":
                    return TOTAL_SVC_YTD().ToString();
                case "TOTAL_ADJ_YTD":
                    return TOTAL_ADJ_YTD().ToString();
                case "TOTAL_AMT_YTD":
                    return TOTAL_AMT_YTD().ToString();
                default:
                    return String.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                // TODO: Some manual steps maybe required.
                Access_F050TP_DOC_REVENUE_MSTR();
                while (rdrF050TP_DOC_REVENUE_MSTR.Read())
                {
                    Link_F020_DOCTOR_MSTR();
                    while (rdrF020_DOCTOR_MSTR.Read())
                    {
                        Link_ICONST_MSTR_REC();
                        while (rdrICONST_MSTR_REC.Read())
                        {
                            Link_F030_LOCATIONS_MSTR();
                            while (rdrF030_LOCATIONS_MSTR.Read())
                            {
                                WriteData();
                            }

                            rdrF030_LOCATIONS_MSTR.Close();
                        }

                        rdrICONST_MSTR_REC.Close();
                    }

                    rdrF020_DOCTOR_MSTR.Close();
                }

                rdrF050TP_DOC_REVENUE_MSTR.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrF050TP_DOC_REVENUE_MSTR == null))
            {
                rdrF050TP_DOC_REVENUE_MSTR.Close();
                rdrF050TP_DOC_REVENUE_MSTR = null;
            }

            if (!(rdrF020_DOCTOR_MSTR == null))
            {
                rdrF020_DOCTOR_MSTR.Close();
                rdrF020_DOCTOR_MSTR = null;
            }

            if (!(rdrICONST_MSTR_REC == null))
            {
                rdrICONST_MSTR_REC.Close();
                rdrICONST_MSTR_REC = null;
            }

            if (!(rdrF030_LOCATIONS_MSTR == null))
            {
                rdrF030_LOCATIONS_MSTR.Close();
                rdrF030_LOCATIONS_MSTR = null;
            }
        }
    }
}
