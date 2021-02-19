//  DOC: r011a_70 
//  DOC: PHYSICIAN REVENUE ANALYSIS BY DOCTOR (DETAIL REPORT)
//  DOC: SORT BY CLINIC BY DEPARTMENT BY CLASS BY DOCTOR
//  DOC: RUN FOR: MUMC DIAGNOSTICS
//  PROGRAM PURPOSE : REVENUE ANALYSIS BY DOCTOR (DETAIL REPORT)
//  R011.CB CONVERSTION TO POWERHOUSE R011A.QZS
//  THIS IS THE FIRST OF 3 PROGRAMS. APPEND REPORTS
//  R011B.TXT R011C.TXT TO END OF R011A.TXT REPORT
//  DATE       BY WHOM   DESCRIPTION
//  2007/Mar   YASEMIN   r011a_70   
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
    public class R011A_70 : BaseRDLClass
    {
        protected const string REPORT_NAME = "R011A_70";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrF050_DOC_REVENUE_MSTR = new Reader();
        private Reader rdrF020_DOCTOR_MSTR = new Reader();
        private Reader rdrICONST_MSTR_REC = new Reader();
        private Reader rdrF070_DEPT_MSTR = new Reader();
        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                //  Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;
                Sort = "DOCREV_CLINIC_1_2 ASC, DOCREV_DEPT ASC, DOC_FULL_PART_IND DESC, DOCREV_DOC_NBR ASC";
                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return ReportData;
        }
        private void Access_F050_DOC_REVENUE_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            strSQL.Append("SELECT ");
            strSQL.Append("DOCREV_DOC_NBR, ");
            strSQL.Append("DOCREV_CLINIC_1_2, ");
            strSQL.Append("DOCREV_DEPT, ");
            strSQL.Append(" DOCREV_LOCATION, ");
            strSQL.Append(" DOCREV_OMA_CODE, ");
            strSQL.Append(" DOCREV_OMA_SUFF, ");
            strSQL.Append("DOCREV_MTD_IN_SVC, ");
            strSQL.Append("DOCREV_MTD_OUT_SVC, ");
            strSQL.Append("DOCREV_MTD_IN_REC, ");
            strSQL.Append("DOCREV_MTD_OUT_REC, ");
            strSQL.Append("DOCREV_YTD_IN_SVC, ");
            strSQL.Append("DOCREV_YTD_OUT_SVC, ");
            strSQL.Append("DOCREV_YTD_IN_REC, ");
            strSQL.Append("DOCREV_YTD_OUT_REC ");
            strSQL.Append("FROM INDEXED.F050_DOC_REVENUE_MSTR ");
            strSQL.Append(Choose());
            rdrF050_DOC_REVENUE_MSTR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_F020_DOCTOR_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("DOC_FULL_PART_IND, ");
            strSQL.Append("DOC_NAME, ");
            strSQL.Append("DOC_INIT1, ");
            strSQL.Append(" DOC_INIT2, ");
            strSQL.Append(" DOC_INIT3 ");
            strSQL.Append("FROM INDEXED.F020_DOCTOR_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_NBR = ").Append(Common.StringToField(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_DOC_NBR")));
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
            strSQL.Append("ICONST_CLINIC_NBR_1_2 = ").Append(QDesign.NConvert(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_CLINIC_1_2")));
            rdrICONST_MSTR_REC.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_F070_DEPT_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("DEPT_NBR, ");
            strSQL.Append("DEPT_NAME ");
            strSQL.Append("FROM INDEXED.F070_DEPT_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DEPT_NBR = ").Append(rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_DEPT"));
            rdrF070_DEPT_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(String.Empty);
            // TODO: CHOOSE Statement - May require manual changes.
            strChoose.Append(" WHERE DOCREV_CLINIC_1_2 BETWEEN 71 AND 75");
            return strChoose.ToString().ToString();
        }

        private string X_CLASS()
        {
            string strReturnValue = String.Empty;
            try
            {
                if ((QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "F"))
                {
                    strReturnValue = "FULL TIME";
                }
                else if ((QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "P"))
                {
                    strReturnValue = "PART TIME";
                }
                else if ((QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "C"))
                {
                    strReturnValue = "CLINICAL SCHOLARS";
                }
                else if ((QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "S"))
                {
                    strReturnValue = "OTHER";
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private decimal X_SVC_MTD_IN()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")) != "MISC"))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_MTD_IN_SVC");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_SVC_MTD_OUT()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")) != "MISC"))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_MTD_OUT_SVC");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_AMT_MTD_IN()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")) != "MISC"))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_MTD_IN_REC");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_AMT_MTD_OUT()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")) != "MISC"))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_MTD_OUT_REC");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_MISC_SVC_MTD()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")) == "MISC"))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_MTD_OUT_SVC");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_MISC_AMT_MTD()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")) == "MISC"))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_MTD_OUT_REC");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_SVC_YTD_IN()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")) != "MISC"))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_YTD_IN_SVC");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_SVC_YTD_OUT()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")) != "MISC"))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_YTD_OUT_SVC");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_AMT_YTD_IN()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")) != "MISC"))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_YTD_IN_REC");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_AMT_YTD_OUT()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")) != "MISC"))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_YTD_OUT_REC");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_MISC_SVC_YTD()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")) == "MISC"))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_YTD_OUT_SVC");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_MISC_AMT_YTD()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")) == "MISC"))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_YTD_OUT_REC");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_SVC_TOTAL_MTD()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = (X_SVC_MTD_IN()
                            + (X_SVC_MTD_OUT() + X_MISC_SVC_MTD()));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_SVC_TOTAL_YTD()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = (X_SVC_YTD_IN()
                            + (X_SVC_YTD_OUT() + X_MISC_SVC_YTD()));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_AMT_TOTAL_MTD()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = (X_AMT_MTD_IN()
                            + (X_AMT_MTD_OUT() + X_MISC_AMT_MTD()));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_AMT_TOTAL_YTD()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = (X_AMT_YTD_IN()
                            + (X_AMT_YTD_OUT() + X_MISC_AMT_YTD()));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_FULL_SVC_MTD_IN()
        {
            decimal decReturnValue = 0;
            try
            {
                if (((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")) != "MISC")
                            && (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "F")))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_MTD_IN_SVC");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_FULL_SVC_MTD_OUT()
        {
            decimal decReturnValue = 0;
            try
            {
                if (((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")) != "MISC")
                            && (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "F")))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_MTD_OUT_SVC");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_FULL_AMT_MTD_IN()
        {
            decimal decReturnValue = 0;
            try
            {
                if (((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")) != "MISC")
                            && (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "F")))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_MTD_IN_REC");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_FULL_AMT_MTD_OUT()
        {
            decimal decReturnValue = 0;
            try
            {
                if (((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")) != "MISC")
                            && (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "F")))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_MTD_OUT_REC");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_FULL_MISC_SVC_MTD()
        {
            decimal decReturnValue = 0;
            try
            {
                if (((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")) == "MISC")
                            && (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "F")))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_MTD_OUT_SVC");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_FULL_MISC_AMT_MTD()
        {
            decimal decReturnValue = 0;
            try
            {
                if (((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")) == "MISC")
                            && (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "F")))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_MTD_OUT_REC");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_FULL_SVC_YTD_IN()
        {
            decimal decReturnValue = 0;
            try
            {
                if (((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")) != "MISC")
                            && (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "F")))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_YTD_IN_SVC");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_FULL_SVC_YTD_OUT()
        {
            decimal decReturnValue = 0;
            try
            {
                if (((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")) != "MISC")
                            && (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "F")))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_YTD_OUT_SVC");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_FULL_AMT_YTD_IN()
        {
            decimal decReturnValue = 0;
            try
            {
                if (((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")) != "MISC")
                            && (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "F")))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_YTD_IN_REC");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_FULL_AMT_YTD_OUT()
        {
            decimal decReturnValue = 0;
            try
            {
                if (((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")) != "MISC")
                            && (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "F")))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_YTD_OUT_REC");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_FULL_MISC_SVC_YTD()
        {
            decimal decReturnValue = 0;
            try
            {
                if (((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")) == "MISC")
                            && (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "F")))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_YTD_OUT_SVC");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_FULL_MISC_AMT_YTD()
        {
            decimal decReturnValue = 0;
            try
            {
                if (((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")) == "MISC")
                            && (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "F")))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_YTD_OUT_REC");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_FULL_SVC_TOTAL_MTD()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "F"))
                {
                    decReturnValue = (X_SVC_MTD_IN()
                                + (X_SVC_MTD_OUT() + X_MISC_SVC_MTD()));
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_FULL_SVC_TOTAL_YTD()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "F"))
                {
                    decReturnValue = (X_SVC_YTD_IN()
                                + (X_SVC_YTD_OUT() + X_MISC_SVC_YTD()));
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_FULL_AMT_TOTAL_MTD()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "F"))
                {
                    decReturnValue = (X_AMT_MTD_IN()
                                + (X_AMT_MTD_OUT() + X_MISC_AMT_MTD()));
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_FULL_AMT_TOTAL_YTD()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "F"))
                {
                    decReturnValue = (X_AMT_YTD_IN()
                                + (X_AMT_YTD_OUT() + X_MISC_AMT_YTD()));
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_PART_SVC_MTD_IN()
        {
            decimal decReturnValue = 0;
            try
            {
                if (((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")) != "MISC")
                            && (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "P")))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_MTD_IN_SVC");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_PART_SVC_MTD_OUT()
        {
            decimal decReturnValue = 0;
            try
            {
                if (((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")) != "MISC")
                            && (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "P")))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_MTD_OUT_SVC");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_PART_AMT_MTD_IN()
        {
            decimal decReturnValue = 0;
            try
            {
                if (((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")) != "MISC")
                            && (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "P")))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_MTD_IN_REC");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_PART_AMT_MTD_OUT()
        {
            decimal decReturnValue = 0;
            try
            {
                if (((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")) != "MISC")
                            && (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "P")))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_MTD_OUT_REC");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_PART_MISC_SVC_MTD()
        {
            decimal decReturnValue = 0;
            try
            {
                if (((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")) == "MISC")
                            && (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "P")))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_MTD_OUT_SVC");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_PART_MISC_AMT_MTD()
        {
            decimal decReturnValue = 0;
            try
            {
                if (((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")) == "MISC")
                            && (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "P")))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_MTD_OUT_REC");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_PART_SVC_YTD_IN()
        {
            decimal decReturnValue = 0;
            try
            {
                if (((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")) != "MISC")
                            && (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "P")))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_YTD_IN_SVC");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_PART_SVC_YTD_OUT()
        {
            decimal decReturnValue = 0;
            try
            {
                if (((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")) != "MISC")
                            && (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "P")))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_YTD_OUT_SVC");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_PART_AMT_YTD_IN()
        {
            decimal decReturnValue = 0;
            try
            {
                if (((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")) != "MISC")
                            && (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "P")))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_YTD_IN_REC");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_PART_AMT_YTD_OUT()
        {
            decimal decReturnValue = 0;
            try
            {
                if (((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")) != "MISC")
                            && (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "P")))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_YTD_OUT_REC");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_PART_MISC_SVC_YTD()
        {
            decimal decReturnValue = 0;
            try
            {
                if (((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")) == "MISC")
                            && (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "P")))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_YTD_OUT_SVC");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_PART_MISC_AMT_YTD()
        {
            decimal decReturnValue = 0;
            try
            {
                if (((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")) == "MISC")
                            && (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "P")))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_YTD_OUT_REC");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_PART_SVC_TOTAL_MTD()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "P"))
                {
                    decReturnValue = (X_SVC_MTD_IN()
                                + (X_SVC_MTD_OUT() + X_MISC_SVC_MTD()));
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_PART_SVC_TOTAL_YTD()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "P"))
                {
                    decReturnValue = (X_SVC_YTD_IN()
                                + (X_SVC_YTD_OUT() + X_MISC_SVC_YTD()));
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_PART_AMT_TOTAL_MTD()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "P"))
                {
                    decReturnValue = (X_AMT_MTD_IN()
                                + (X_AMT_MTD_OUT() + X_MISC_AMT_MTD()));
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_PART_AMT_TOTAL_YTD()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "P"))
                {
                    decReturnValue = (X_AMT_YTD_IN()
                                + (X_AMT_YTD_OUT() + X_MISC_AMT_YTD()));
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_CS_SVC_MTD_IN()
        {
            decimal decReturnValue = 0;
            try
            {
                if (((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")) != "MISC")
                            && (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "C")))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_MTD_IN_SVC");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_CS_SVC_MTD_OUT()
        {
            decimal decReturnValue = 0;
            try
            {
                if (((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")) != "MISC")
                            && (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "C")))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_MTD_OUT_SVC");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_CS_AMT_MTD_IN()
        {
            decimal decReturnValue = 0;
            try
            {
                if (((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")) != "MISC")
                            && (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "C")))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_MTD_IN_REC");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_CS_AMT_MTD_OUT()
        {
            decimal decReturnValue = 0;
            try
            {
                if (((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")) != "MISC")
                            && (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "C")))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_MTD_OUT_REC");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_CS_MISC_SVC_MTD()
        {
            decimal decReturnValue = 0;
            try
            {
                if (((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")) == "MISC")
                            && (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "C")))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_MTD_OUT_SVC");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_CS_MISC_AMT_MTD()
        {
            decimal decReturnValue = 0;
            try
            {
                if (((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")) == "MISC")
                            && (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "C")))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_MTD_OUT_REC");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_CS_SVC_YTD_IN()
        {
            decimal decReturnValue = 0;
            try
            {
                if (((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")) != "MISC")
                            && (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "C")))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_YTD_IN_SVC");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_CS_SVC_YTD_OUT()
        {
            decimal decReturnValue = 0;
            try
            {
                if (((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")) != "MISC")
                            && (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "C")))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_YTD_OUT_SVC");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_CS_AMT_YTD_IN()
        {
            decimal decReturnValue = 0;
            try
            {
                if (((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")) != "MISC")
                            && (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "C")))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_YTD_IN_REC");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_CS_AMT_YTD_OUT()
        {
            decimal decReturnValue = 0;
            try
            {
                if (((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")) != "MISC")
                            && (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "C")))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_YTD_OUT_REC");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_CS_MISC_SVC_YTD()
        {
            decimal decReturnValue = 0;
            try
            {
                if (((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")) == "MISC")
                            && (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "C")))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_YTD_OUT_SVC");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_CS_MISC_AMT_YTD()
        {
            decimal decReturnValue = 0;
            try
            {
                if (((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")) == "MISC")
                            && (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "C")))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_YTD_OUT_REC");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_CS_SVC_TOTAL_MTD()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "C"))
                {
                    decReturnValue = (X_SVC_MTD_IN()
                                + (X_SVC_MTD_OUT() + X_MISC_SVC_MTD()));
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_CS_SVC_TOTAL_YTD()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "C"))
                {
                    decReturnValue = (X_SVC_YTD_IN()
                                + (X_SVC_YTD_OUT() + X_MISC_SVC_YTD()));
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_CS_AMT_TOTAL_MTD()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "C"))
                {
                    decReturnValue = (X_AMT_MTD_IN()
                                + (X_AMT_MTD_OUT() + X_MISC_AMT_MTD()));
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_CS_AMT_TOTAL_YTD()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "C"))
                {
                    decReturnValue = (X_AMT_YTD_IN()
                                + (X_AMT_YTD_OUT() + X_MISC_AMT_YTD()));
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_PS_SVC_MTD_IN()
        {
            decimal decReturnValue = 0;
            try
            {
                if (((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")) != "MISC")
                            && (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "S")))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_MTD_IN_SVC");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_PS_SVC_MTD_OUT()
        {
            decimal decReturnValue = 0;
            try
            {
                if (((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")) != "MISC")
                            && (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "S")))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_MTD_OUT_SVC");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_PS_AMT_MTD_IN()
        {
            decimal decReturnValue = 0;
            try
            {
                if (((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")) != "MISC")
                            && (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "S")))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_MTD_IN_REC");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_PS_AMT_MTD_OUT()
        {
            decimal decReturnValue = 0;
            try
            {
                if (((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")) != "MISC")
                            && (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "S")))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_MTD_OUT_REC");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_PS_MISC_SVC_MTD()
        {
            decimal decReturnValue = 0;
            try
            {
                if (((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")) == "MISC")
                            && (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "S")))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_MTD_OUT_SVC");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_PS_MISC_AMT_MTD()
        {
            decimal decReturnValue = 0;
            try
            {
                if (((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")) == "MISC")
                            && (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "S")))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_MTD_OUT_REC");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_PS_SVC_YTD_IN()
        {
            decimal decReturnValue = 0;
            try
            {
                if (((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")) != "MISC")
                            && (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "S")))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_YTD_IN_SVC");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_PS_SVC_YTD_OUT()
        {
            decimal decReturnValue = 0;
            try
            {
                if (((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")) != "MISC")
                            && (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "S")))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_YTD_OUT_SVC");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_PS_AMT_YTD_IN()
        {
            decimal decReturnValue = 0;
            try
            {
                if (((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")) != "MISC")
                            && (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "S")))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_YTD_IN_REC");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_PS_AMT_YTD_OUT()
        {
            decimal decReturnValue = 0;
            try
            {
                if (((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")) != "MISC")
                            && (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "S")))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_YTD_OUT_REC");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_PS_MISC_SVC_YTD()
        {
            decimal decReturnValue = 0;
            try
            {
                if (((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")) == "MISC")
                            && (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "S")))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_YTD_OUT_SVC");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_PS_MISC_AMT_YTD()
        {
            decimal decReturnValue = 0;
            try
            {
                if (((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")) == "MISC")
                            && (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "S")))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_YTD_OUT_REC");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_PS_SVC_TOTAL_MTD()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "S"))
                {
                    decReturnValue = (X_SVC_MTD_IN()
                                + (X_SVC_MTD_OUT() + X_MISC_SVC_MTD()));
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_PS_SVC_TOTAL_YTD()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "S"))
                {
                    decReturnValue = (X_SVC_YTD_IN()
                                + (X_SVC_YTD_OUT() + X_MISC_SVC_YTD()));
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_PS_AMT_TOTAL_MTD()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "S"))
                {
                    decReturnValue = (X_AMT_MTD_IN()
                                + (X_AMT_MTD_OUT() + X_MISC_AMT_MTD()));
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_PS_AMT_TOTAL_YTD()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "S"))
                {
                    decReturnValue = (X_AMT_YTD_IN()
                                + (X_AMT_YTD_OUT() + X_MISC_AMT_YTD()));
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private string X_PERIOD()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = ".";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_NAME()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = QDesign.Pack(rdrF020_DOCTOR_MSTR.GetString("DOC_NAME") + " " + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT1") + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT2") + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT3"));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_FULL_CLASS()
        {
            string strReturnValue = String.Empty;
            try
            {
                if ((QDesign.NULL(X_FULL_AMT_TOTAL_YTD()) != QDesign.NULL(0d)))
                {
                    strReturnValue = "F: FULL TIME";
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

        private string X_PART_CLASS()
        {
            string strReturnValue = String.Empty;
            try
            {
                if ((QDesign.NULL(X_PART_AMT_TOTAL_YTD()) != QDesign.NULL(0d)))
                {
                    strReturnValue = "P: PART TIME";
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

        private string X_CS_CLASS()
        {
            string strReturnValue = String.Empty;
            try
            {
                if ((QDesign.NULL(X_CS_AMT_TOTAL_YTD()) != QDesign.NULL(0d)))
                {
                    strReturnValue = "C: CLINICAL SCHOLARS";
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

        private string X_PS_CLASS()
        {
            string strReturnValue = String.Empty;
            try
            {
                if ((QDesign.NULL(X_PS_AMT_TOTAL_YTD()) != QDesign.NULL(0d)))
                {
                    strReturnValue = "S: PLASTIC SURGERY";
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

        private string X_FULL_MONTH()
        {
            string strReturnValue = String.Empty;
            try
            {
                if ((QDesign.NULL(X_FULL_AMT_TOTAL_MTD()) != QDesign.NULL(0d)))
                {
                    strReturnValue = "MONTH";
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

        private string X_PART_MONTH()
        {
            string strReturnValue = String.Empty;
            try
            {
                if ((QDesign.NULL(X_PART_AMT_TOTAL_MTD()) != QDesign.NULL(0d)))
                {
                    strReturnValue = "MONTH";
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

        private string X_CS_MONTH()
        {
            string strReturnValue = String.Empty;
            try
            {
                if ((QDesign.NULL(X_CS_AMT_TOTAL_MTD()) != QDesign.NULL(0d)))
                {
                    strReturnValue = "MONTH";
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

        private string X_PS_MONTH()
        {
            string strReturnValue = String.Empty;
            try
            {
                if ((QDesign.NULL(X_PS_AMT_TOTAL_MTD()) != QDesign.NULL(0d)))
                {
                    strReturnValue = "MONTH";
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

        private string X_FULL_YEAR()
        {
            string strReturnValue = String.Empty;
            try
            {
                if ((QDesign.NULL(X_FULL_AMT_TOTAL_YTD()) != QDesign.NULL(0d)))
                {
                    strReturnValue = "YEAR";
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

        private string X_PART_YEAR()
        {
            string strReturnValue = String.Empty;
            try
            {
                if ((QDesign.NULL(X_PART_AMT_TOTAL_YTD()) != QDesign.NULL(0d)))
                {
                    strReturnValue = "YEAR";
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

        private string X_CS_YEAR()
        {
            string strReturnValue = String.Empty;
            try
            {
                if ((QDesign.NULL(X_CS_AMT_TOTAL_YTD()) != QDesign.NULL(0d)))
                {
                    strReturnValue = "YEAR";
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

        private string X_PS_YEAR()
        {
            string strReturnValue = String.Empty;
            try
            {
                if ((QDesign.NULL(X_PS_AMT_TOTAL_YTD()) != QDesign.NULL(0d)))
                {
                    strReturnValue = "YEAR";
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
                AddControl(ReportSection.PAGE_HEADING, "INDEXED.F050_DOC_REVENUE_MSTR.DOCREV_CLINIC_1_2", DataTypes.Character, 2);
                AddControl(ReportSection.PAGE_HEADING, "ICONST_DATE_PERIOD_END", DataTypes.Numeric, 8);
                AddControl(ReportSection.PAGE_HEADING, "INDEXED.ICONST_MSTR_REC.ICONST_CLINIC_NAME", DataTypes.Character, 20);
                AddControl(ReportSection.PAGE_HEADING, "INDEXED.ICONST_MSTR_REC.ICONST_CLINIC_NBR", DataTypes.Character, 4);
                AddControl(ReportSection.PAGE_HEADING, "INDEXED.F050_DOC_REVENUE_MSTR.DOCREV_DEPT", DataTypes.Numeric, 2);
                AddControl(ReportSection.PAGE_HEADING, "INDEXED.F070_DEPT_MSTR.DEPT_NAME", DataTypes.Character, 30);
                AddControl(ReportSection.HEADING_AT, "INDEXED.F020_DOCTOR_MSTR.DOC_FULL_PART_IND", DataTypes.Character, 1);
                AddControl(ReportSection.HEADING_AT, "X_CLASS", DataTypes.Character, 18);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F050_DOC_REVENUE_MSTR.DOCREV_DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.FOOTING_AT, "X_SVC_MTD_IN", DataTypes.Numeric, 4);
                AddControl(ReportSection.FOOTING_AT, "X_AMT_MTD_IN", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_SVC_MTD_OUT", DataTypes.Numeric, 4);
                AddControl(ReportSection.FOOTING_AT, "X_AMT_MTD_OUT", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_MISC_SVC_MTD", DataTypes.Numeric, 4);
                AddControl(ReportSection.FOOTING_AT, "X_MISC_AMT_MTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_SVC_TOTAL_MTD", DataTypes.Numeric, 4);
                AddControl(ReportSection.FOOTING_AT, "X_AMT_TOTAL_MTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_NAME", DataTypes.Character, 30);
                AddControl(ReportSection.FOOTING_AT, "X_SVC_YTD_IN", DataTypes.Numeric, 5);
                AddControl(ReportSection.FOOTING_AT, "X_AMT_YTD_IN", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_SVC_YTD_OUT", DataTypes.Numeric, 5);
                AddControl(ReportSection.FOOTING_AT, "X_AMT_YTD_OUT", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_MISC_SVC_YTD", DataTypes.Numeric, 5);
                AddControl(ReportSection.FOOTING_AT, "X_MISC_AMT_YTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_SVC_TOTAL_YTD", DataTypes.Numeric, 5);
                AddControl(ReportSection.FOOTING_AT, "X_AMT_TOTAL_YTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_FULL_SVC_MTD_IN", DataTypes.Numeric, 4);
                AddControl(ReportSection.FOOTING_AT, "X_FULL_AMT_MTD_IN", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_FULL_SVC_MTD_OUT", DataTypes.Numeric, 4);
                AddControl(ReportSection.FOOTING_AT, "X_FULL_AMT_MTD_OUT", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_FULL_MISC_SVC_MTD", DataTypes.Numeric, 4);
                AddControl(ReportSection.FOOTING_AT, "X_FULL_MISC_AMT_MTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_FULL_SVC_TOTAL_MTD", DataTypes.Numeric, 4);
                AddControl(ReportSection.FOOTING_AT, "X_FULL_AMT_TOTAL_MTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_FULL_SVC_YTD_IN", DataTypes.Numeric, 5);
                AddControl(ReportSection.FOOTING_AT, "X_FULL_AMT_YTD_IN", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_FULL_SVC_YTD_OUT", DataTypes.Numeric, 5);
                AddControl(ReportSection.FOOTING_AT, "X_FULL_AMT_YTD_OUT", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_FULL_MISC_SVC_YTD", DataTypes.Numeric, 5);
                AddControl(ReportSection.FOOTING_AT, "X_FULL_MISC_AMT_YTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_FULL_SVC_TOTAL_YTD", DataTypes.Numeric, 5);
                AddControl(ReportSection.FOOTING_AT, "X_FULL_AMT_TOTAL_YTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_PART_SVC_MTD_IN", DataTypes.Numeric, 4);
                AddControl(ReportSection.FOOTING_AT, "X_PART_AMT_MTD_IN", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_PART_SVC_MTD_OUT", DataTypes.Numeric, 4);
                AddControl(ReportSection.FOOTING_AT, "X_PART_AMT_MTD_OUT", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_PART_MISC_SVC_MTD", DataTypes.Numeric, 4);
                AddControl(ReportSection.FOOTING_AT, "X_PART_MISC_AMT_MTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_PART_SVC_TOTAL_MTD", DataTypes.Numeric, 4);
                AddControl(ReportSection.FOOTING_AT, "X_PART_AMT_TOTAL_MTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_PART_SVC_YTD_IN", DataTypes.Numeric, 5);
                AddControl(ReportSection.FOOTING_AT, "X_PART_AMT_YTD_IN", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_PART_SVC_YTD_OUT", DataTypes.Numeric, 5);
                AddControl(ReportSection.FOOTING_AT, "X_PART_AMT_YTD_OUT", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_PART_MISC_SVC_YTD", DataTypes.Numeric, 5);
                AddControl(ReportSection.FOOTING_AT, "X_PART_MISC_AMT_YTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_PART_SVC_TOTAL_YTD", DataTypes.Numeric, 5);
                AddControl(ReportSection.FOOTING_AT, "X_PART_AMT_TOTAL_YTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_CS_SVC_MTD_IN", DataTypes.Numeric, 4);
                AddControl(ReportSection.FOOTING_AT, "X_CS_AMT_MTD_IN", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_CS_SVC_MTD_OUT", DataTypes.Numeric, 4);
                AddControl(ReportSection.FOOTING_AT, "X_CS_AMT_MTD_OUT", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_CS_MISC_SVC_MTD", DataTypes.Numeric, 4);
                AddControl(ReportSection.FOOTING_AT, "X_CS_MISC_AMT_MTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_CS_SVC_TOTAL_MTD", DataTypes.Numeric, 4);
                AddControl(ReportSection.FOOTING_AT, "X_CS_AMT_TOTAL_MTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_CS_SVC_YTD_IN", DataTypes.Numeric, 5);
                AddControl(ReportSection.FOOTING_AT, "X_CS_AMT_YTD_IN", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_CS_SVC_YTD_OUT", DataTypes.Numeric, 5);
                AddControl(ReportSection.FOOTING_AT, "X_CS_AMT_YTD_OUT", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_CS_MISC_SVC_YTD", DataTypes.Numeric, 5);
                AddControl(ReportSection.FOOTING_AT, "X_CS_MISC_AMT_YTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_CS_SVC_TOTAL_YTD", DataTypes.Numeric, 5);
                AddControl(ReportSection.FOOTING_AT, "X_CS_AMT_TOTAL_YTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_PS_SVC_MTD_IN", DataTypes.Numeric, 4);
                AddControl(ReportSection.FOOTING_AT, "X_PS_AMT_MTD_IN", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_PS_SVC_MTD_OUT", DataTypes.Numeric, 4);
                AddControl(ReportSection.FOOTING_AT, "X_PS_AMT_MTD_OUT", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_PS_MISC_SVC_MTD", DataTypes.Numeric, 4);
                AddControl(ReportSection.FOOTING_AT, "X_PS_MISC_AMT_MTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_PS_SVC_TOTAL_MTD", DataTypes.Numeric, 4);
                AddControl(ReportSection.FOOTING_AT, "X_PS_AMT_TOTAL_MTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_PS_SVC_YTD_IN", DataTypes.Numeric, 5);
                AddControl(ReportSection.FOOTING_AT, "X_PS_AMT_YTD_IN", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_PS_SVC_YTD_OUT", DataTypes.Numeric, 5);
                AddControl(ReportSection.FOOTING_AT, "X_PS_AMT_YTD_OUT", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_PS_MISC_SVC_YTD", DataTypes.Numeric, 5);
                AddControl(ReportSection.FOOTING_AT, "X_PS_MISC_AMT_YTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_PS_SVC_TOTAL_YTD", DataTypes.Numeric, 5);
                AddControl(ReportSection.FOOTING_AT, "X_PS_AMT_TOTAL_YTD", DataTypes.Numeric, 8);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-05-10 7:53:44 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            // TODO: Remove duplicate controls, if there are any.
            switch (strControl)
            {
                case "INDEXED.F050_DOC_REVENUE_MSTR.DOCREV_CLINIC_1_2":
                    return Common.StringToField(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_CLINIC_1_2"));
                case "ICONST_DATE_PERIOD_END":
                    return ICONST_MSTR_REC_ICONST_DATE_PERIOD_END().ToString();
                case "INDEXED.ICONST_MSTR_REC.ICONST_CLINIC_NAME":
                    return Common.StringToField(rdrICONST_MSTR_REC.GetString("ICONST_CLINIC_NAME"));
                case "INDEXED.ICONST_MSTR_REC.ICONST_CLINIC_NBR":
                    return Common.StringToField(rdrICONST_MSTR_REC.GetString("ICONST_CLINIC_NBR"));
                case "INDEXED.F050_DOC_REVENUE_MSTR.DOCREV_DEPT":
                    return rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_DEPT").ToString();
                case "INDEXED.F070_DEPT_MSTR.DEPT_NAME":
                    return Common.StringToField(rdrF070_DEPT_MSTR.GetString("DEPT_NAME"));
                case "INDEXED.F020_DOCTOR_MSTR.DOC_FULL_PART_IND":
                    return Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND"));
                case "X_CLASS":
                    return Common.StringToField(X_CLASS(), intSize);
                case "INDEXED.F050_DOC_REVENUE_MSTR.DOCREV_DOC_NBR":
                    return Common.StringToField(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_DOC_NBR"));
                case "X_SVC_MTD_IN":
                    return X_SVC_MTD_IN().ToString();
                case "X_AMT_MTD_IN":
                    return X_AMT_MTD_IN().ToString();
                case "X_SVC_MTD_OUT":
                    return X_SVC_MTD_OUT().ToString();
                case "X_AMT_MTD_OUT":
                    return X_AMT_MTD_OUT().ToString();
                case "X_MISC_SVC_MTD":
                    return X_MISC_SVC_MTD().ToString();
                case "X_MISC_AMT_MTD":
                    return X_MISC_AMT_MTD().ToString();
                case "X_SVC_TOTAL_MTD":
                    return X_SVC_TOTAL_MTD().ToString();
                case "X_AMT_TOTAL_MTD":
                    return X_AMT_TOTAL_MTD().ToString();
                case "X_NAME":
                    return Common.StringToField(X_NAME(), intSize);
                case "X_SVC_YTD_IN":
                    return X_SVC_YTD_IN().ToString();
                case "X_AMT_YTD_IN":
                    return X_AMT_YTD_IN().ToString();
                case "X_SVC_YTD_OUT":
                    return X_SVC_YTD_OUT().ToString();
                case "X_AMT_YTD_OUT":
                    return X_AMT_YTD_OUT().ToString();
                case "X_MISC_SVC_YTD":
                    return X_MISC_SVC_YTD().ToString();
                case "X_MISC_AMT_YTD":
                    return X_MISC_AMT_YTD().ToString();
                case "X_SVC_TOTAL_YTD":
                    return X_SVC_TOTAL_YTD().ToString();
                case "X_AMT_TOTAL_YTD":
                    return X_AMT_TOTAL_YTD().ToString();
                case "X_FULL_SVC_MTD_IN":
                    return X_FULL_SVC_MTD_IN().ToString();
                case "X_FULL_AMT_MTD_IN":
                    return X_FULL_AMT_MTD_IN().ToString();
                case "X_FULL_SVC_MTD_OUT":
                    return X_FULL_SVC_MTD_OUT().ToString();
                case "X_FULL_AMT_MTD_OUT":
                    return X_FULL_AMT_MTD_OUT().ToString();
                case "X_FULL_MISC_SVC_MTD":
                    return X_FULL_MISC_SVC_MTD().ToString();
                case "X_FULL_MISC_AMT_MTD":
                    return X_FULL_MISC_AMT_MTD().ToString();
                case "X_FULL_SVC_TOTAL_MTD":
                    return X_FULL_SVC_TOTAL_MTD().ToString();
                case "X_FULL_AMT_TOTAL_MTD":
                    return X_FULL_AMT_TOTAL_MTD().ToString();
                case "X_FULL_SVC_YTD_IN":
                    return X_FULL_SVC_YTD_IN().ToString();
                case "X_FULL_AMT_YTD_IN":
                    return X_FULL_AMT_YTD_IN().ToString();
                case "X_FULL_SVC_YTD_OUT":
                    return X_FULL_SVC_YTD_OUT().ToString();
                case "X_FULL_AMT_YTD_OUT":
                    return X_FULL_AMT_YTD_OUT().ToString();
                case "X_FULL_MISC_SVC_YTD":
                    return X_FULL_MISC_SVC_YTD().ToString();
                case "X_FULL_MISC_AMT_YTD":
                    return X_FULL_MISC_AMT_YTD().ToString();
                case "X_FULL_SVC_TOTAL_YTD":
                    return X_FULL_SVC_TOTAL_YTD().ToString();
                case "X_FULL_AMT_TOTAL_YTD":
                    return X_FULL_AMT_TOTAL_YTD().ToString();
                case "X_PART_SVC_MTD_IN":
                    return X_PART_SVC_MTD_IN().ToString();
                case "X_PART_AMT_MTD_IN":
                    return X_PART_AMT_MTD_IN().ToString();
                case "X_PART_SVC_MTD_OUT":
                    return X_PART_SVC_MTD_OUT().ToString();
                case "X_PART_AMT_MTD_OUT":
                    return X_PART_AMT_MTD_OUT().ToString();
                case "X_PART_MISC_SVC_MTD":
                    return X_PART_MISC_SVC_MTD().ToString();
                case "X_PART_MISC_AMT_MTD":
                    return X_PART_MISC_AMT_MTD().ToString();
                case "X_PART_SVC_TOTAL_MTD":
                    return X_PART_SVC_TOTAL_MTD().ToString();
                case "X_PART_AMT_TOTAL_MTD":
                    return X_PART_AMT_TOTAL_MTD().ToString();
                case "X_PART_SVC_YTD_IN":
                    return X_PART_SVC_YTD_IN().ToString();
                case "X_PART_AMT_YTD_IN":
                    return X_PART_AMT_YTD_IN().ToString();
                case "X_PART_SVC_YTD_OUT":
                    return X_PART_SVC_YTD_OUT().ToString();
                case "X_PART_AMT_YTD_OUT":
                    return X_PART_AMT_YTD_OUT().ToString();
                case "X_PART_MISC_SVC_YTD":
                    return X_PART_MISC_SVC_YTD().ToString();
                case "X_PART_MISC_AMT_YTD":
                    return X_PART_MISC_AMT_YTD().ToString();
                case "X_PART_SVC_TOTAL_YTD":
                    return X_PART_SVC_TOTAL_YTD().ToString();
                case "X_PART_AMT_TOTAL_YTD":
                    return X_PART_AMT_TOTAL_YTD().ToString();
                case "X_CS_SVC_MTD_IN":
                    return X_CS_SVC_MTD_IN().ToString();
                case "X_CS_AMT_MTD_IN":
                    return X_CS_AMT_MTD_IN().ToString();
                case "X_CS_SVC_MTD_OUT":
                    return X_CS_SVC_MTD_OUT().ToString();
                case "X_CS_AMT_MTD_OUT":
                    return X_CS_AMT_MTD_OUT().ToString();
                case "X_CS_MISC_SVC_MTD":
                    return X_CS_MISC_SVC_MTD().ToString();
                case "X_CS_MISC_AMT_MTD":
                    return X_CS_MISC_AMT_MTD().ToString();
                case "X_CS_SVC_TOTAL_MTD":
                    return X_CS_SVC_TOTAL_MTD().ToString();
                case "X_CS_AMT_TOTAL_MTD":
                    return X_CS_AMT_TOTAL_MTD().ToString();
                case "X_CS_SVC_YTD_IN":
                    return X_CS_SVC_YTD_IN().ToString();
                case "X_CS_AMT_YTD_IN":
                    return X_CS_AMT_YTD_IN().ToString();
                case "X_CS_SVC_YTD_OUT":
                    return X_CS_SVC_YTD_OUT().ToString();
                case "X_CS_AMT_YTD_OUT":
                    return X_CS_AMT_YTD_OUT().ToString();
                case "X_CS_MISC_SVC_YTD":
                    return X_CS_MISC_SVC_YTD().ToString();
                case "X_CS_MISC_AMT_YTD":
                    return X_CS_MISC_AMT_YTD().ToString();
                case "X_CS_SVC_TOTAL_YTD":
                    return X_CS_SVC_TOTAL_YTD().ToString();
                case "X_CS_AMT_TOTAL_YTD":
                    return X_CS_AMT_TOTAL_YTD().ToString();
                case "X_PS_SVC_MTD_IN":
                    return X_PS_SVC_MTD_IN().ToString();
                case "X_PS_AMT_MTD_IN":
                    return X_PS_AMT_MTD_IN().ToString();
                case "X_PS_SVC_MTD_OUT":
                    return X_PS_SVC_MTD_OUT().ToString();
                case "X_PS_AMT_MTD_OUT":
                    return X_PS_AMT_MTD_OUT().ToString();
                case "X_PS_MISC_SVC_MTD":
                    return X_PS_MISC_SVC_MTD().ToString();
                case "X_PS_MISC_AMT_MTD":
                    return X_PS_MISC_AMT_MTD().ToString();
                case "X_PS_SVC_TOTAL_MTD":
                    return X_PS_SVC_TOTAL_MTD().ToString();
                case "X_PS_AMT_TOTAL_MTD":
                    return X_PS_AMT_TOTAL_MTD().ToString();
                case "X_PS_SVC_YTD_IN":
                    return X_PS_SVC_YTD_IN().ToString();
                case "X_PS_AMT_YTD_IN":
                    return X_PS_AMT_YTD_IN().ToString();
                case "X_PS_SVC_YTD_OUT":
                    return X_PS_SVC_YTD_OUT().ToString();
                case "X_PS_AMT_YTD_OUT":
                    return X_PS_AMT_YTD_OUT().ToString();
                case "X_PS_MISC_SVC_YTD":
                    return X_PS_MISC_SVC_YTD().ToString();
                case "X_PS_MISC_AMT_YTD":
                    return X_PS_MISC_AMT_YTD().ToString();
                case "X_PS_SVC_TOTAL_YTD":
                    return X_PS_SVC_TOTAL_YTD().ToString();
                case "X_PS_AMT_TOTAL_YTD":
                    return X_PS_AMT_TOTAL_YTD().ToString();
                default:
                    return String.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                // TODO: Some manual steps maybe required.
                Access_F050_DOC_REVENUE_MSTR();
                while (rdrF050_DOC_REVENUE_MSTR.Read())
                {
                    Link_F020_DOCTOR_MSTR();
                    while (rdrF020_DOCTOR_MSTR.Read())
                    {
                        Link_ICONST_MSTR_REC();
                        while (rdrICONST_MSTR_REC.Read())
                        {
                            Link_F070_DEPT_MSTR();
                            while (rdrF070_DEPT_MSTR.Read())
                            {
                                WriteData();
                            }

                            rdrF070_DEPT_MSTR.Close();
                        }

                        rdrICONST_MSTR_REC.Close();
                    }

                    rdrF020_DOCTOR_MSTR.Close();
                }

                rdrF050_DOC_REVENUE_MSTR.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrF050_DOC_REVENUE_MSTR == null))
            {
                rdrF050_DOC_REVENUE_MSTR.Close();
                rdrF050_DOC_REVENUE_MSTR = null;
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

            if (!(rdrF070_DEPT_MSTR == null))
            {
                rdrF070_DEPT_MSTR.Close();
                rdrF070_DEPT_MSTR = null;
            }
        }
    }
}
