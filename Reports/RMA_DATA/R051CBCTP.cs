//  DOC: R051CBCTP.QZS
//  DOC: DEPARTMENT PRACTICE ANALYSIS
//  DOC: SORT BY CLINIC SUMMARY REPORT
//  DOC: RUN FOR: MUMC DIAGNOSTICS
//  PROGRAM PURPOSE : DEPARTMENT PRACTICE ANALYSIS
//  R051A/B/C.CB CONVERSTION TO POWERHOUSE R051CBCTP.QZS
//  THIS IS THE SECOND OF 3 PROGRAMS APPEND
//  R051CBBTP.TXT R051CBCTP.TXT END OF R051CBATP.TXT
//  DATE       BY WHOM   DESCRIPTION
//  92/06/05   YASEMIN   ORIGINAL
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
    public class R051CBCTP : BaseRDLClass
    {
        protected const string REPORT_NAME = "R051CBCTP";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrF050TP_DOC_REVENUE_MSTR = new Reader();
        private Reader rdrF020_DOCTOR_MSTR = new Reader();
        private Reader rdrICONST_MSTR_REC = new Reader();
        private Reader rdrF070_DEPT_MSTR = new Reader();
        private Reader rdrF040_OMA_FEE_MSTR = new Reader();
        private Reader rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR = new Reader();
        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                //  Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;
                Sort = "DOCREVTP_CLINIC_NBR ASC";
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
            strSQL.Append("DOCREVTP_OMA_CODE, ");
            strSQL.Append("DOCREVTP_OMA_SUFFIX, ");
            strSQL.Append("DOCREVTP_AGENT_CD, ");
            strSQL.Append("DOCREVTP_LOC_CD, ");
            strSQL.Append("DOCREVTP_IN_TECH_AMT_BILLED1, ");
            strSQL.Append("DOCREVTP_OUT_TECH_AMT_BILLED1, ");
            strSQL.Append("DOCREVTP_IN_TECH_AMT_ADJUSTS1, ");
            strSQL.Append("DOCREVTP_OUT_TECH_AMT_ADJUSTS1, ");
            strSQL.Append("DOCREVTP_IN_PROF_AMT_BILLED1, ");
            strSQL.Append("DOCREVTP_OUT_PROF_AMT_BILLED1, ");
            strSQL.Append("DOCREVTP_IN_PROF_AMT_ADJUSTS1, ");
            strSQL.Append("DOCREVTP_OUT_PROF_AMT_ADJUSTS1, ");
            strSQL.Append("DOCREVTP_OUT_TECH_NBR_SVC1, ");
            strSQL.Append("DOCREVTP_IN_TECH_NBR_SVC1, ");
            strSQL.Append("DOCREVTP_IN_PROF_NBR_SVC1, ");
            strSQL.Append("DOCREVTP_OUT_PROF_NBR_SVC1, ");
            strSQL.Append("DOCREVTP_IN_TECH_AMT_BILLED2, ");
            strSQL.Append("DOCREVTP_OUT_TECH_AMT_BILLED2, ");
            strSQL.Append("DOCREVTP_IN_TECH_AMT_ADJUSTS2, ");
            strSQL.Append("DOCREVTP_OUT_TECH_AMT_ADJUSTS2, ");
            strSQL.Append("DOCREVTP_IN_PROF_AMT_BILLED2, ");
            strSQL.Append("DOCREVTP_OUT_PROF_AMT_BILLED2, ");
            strSQL.Append("DOCREVTP_IN_PROF_AMT_ADJUSTS2, ");
            strSQL.Append("DOCREVTP_OUT_PROF_AMT_ADJUSTS2, ");
            strSQL.Append("DOCREVTP_OUT_TECH_NBR_SVC2, ");
            strSQL.Append("DOCREVTP_IN_TECH_NBR_SVC2, ");
            strSQL.Append("DOCREVTP_IN_PROF_NBR_SVC2, ");
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
            strSQL.Append("DOC_DEPT ");
            strSQL.Append("FROM INDEXED.F020_DOCTOR_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_NBR = ").Append(Common.StringToField(rdrF050TP_DOC_REVENUE_MSTR.GetString("DOCREVTP_DOC_NBR")));
            rdrF020_DOCTOR_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_F020C_DOC_CLINIC_NEXT_BATCH_NBR()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("DOC_CLINIC_NBR ");
            strSQL.Append("FROM INDEXED.F020C_DOC_CLINIC_NEXT_BATCH_NBR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_NBR = ").Append(Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_NBR")));
            strSQL.Append(" AND SEQ_NO = 1");
            rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_ICONST_MSTR_REC()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("ICONST_CLINIC_NBR_1_2 ");
            strSQL.Append("FROM INDEXED.ICONST_MSTR_REC ");
            strSQL.Append("WHERE ");
            strSQL.Append("ICONST_CLINIC_NBR_1_2 = ").Append(rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR"));
            rdrICONST_MSTR_REC.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_F070_DEPT_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("DEPT_NBR ");
            strSQL.Append("FROM INDEXED.F070_DEPT_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DEPT_NBR = ").Append(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT"));
            rdrF070_DEPT_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_F040_OMA_FEE_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("FEE_OMA_CD_LTR1, ");
            strSQL.Append(" FILLER_NUMERIC ");
            strSQL.Append("FROM INDEXED.F040_OMA_FEE_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("(FEE_OMA_CD_LTR1 + FILLER_NUMERIC) = ").Append(Common.StringToField(F050TP_DOC_REVENUE_MSTR_DOCREVTP_OMA_CD()));
            rdrF040_OMA_FEE_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(String.Empty);
            // TODO: CHOOSE Statement - May require manual changes.
            strChoose.Append("WHERE DOCREVTP_CLINIC_NBR >= 60 AND DOCREVTP_CLINIC_NBR <= 66");
            return strChoose.ToString().ToString();
        }

        private string F050TP_DOC_REVENUE_MSTR_DOCREVTP_OMA_CD()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = (rdrF050TP_DOC_REVENUE_MSTR.GetString("DOCREVTP_OMA_CODE") + rdrF050TP_DOC_REVENUE_MSTR.GetString("DOCREVTP_OMA_SUFFIX"));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private decimal T_AMT_MTD()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = (rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_IN_TECH_AMT_BILLED1")
                            + (rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_OUT_TECH_AMT_BILLED1")
                            + (rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_IN_TECH_AMT_ADJUSTS1") + rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_OUT_TECH_AMT_ADJUSTS1"))));
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
                decReturnValue = (rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_IN_PROF_AMT_BILLED1")
                            + (rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_OUT_PROF_AMT_BILLED1")
                            + (rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_IN_PROF_AMT_ADJUSTS1") + rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_OUT_PROF_AMT_ADJUSTS1"))));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal T_P_SVC_MTD()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_OUT_TECH_NBR_SVC1")) != QDesign.NULL(0d)))
                {
                    decReturnValue = (rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_IN_TECH_NBR_SVC1") + rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_OUT_TECH_NBR_SVC1"));
                }
                else
                {
                    decReturnValue = (rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_IN_PROF_NBR_SVC1") + rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_OUT_PROF_NBR_SVC1"));
                }
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
                decReturnValue = (T_AMT_MTD() + P_AMT_MTD());
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
                decReturnValue = (rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_IN_TECH_AMT_BILLED2")
                            + (rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_OUT_TECH_AMT_BILLED2")
                            + (rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_IN_TECH_AMT_ADJUSTS2") + rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_OUT_TECH_AMT_ADJUSTS2"))));
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
                decReturnValue = (rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_IN_PROF_AMT_BILLED2")
                            + (rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_OUT_PROF_AMT_BILLED2")
                            + (rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_IN_PROF_AMT_ADJUSTS2") + rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_OUT_PROF_AMT_ADJUSTS2"))));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal T_P_SVC_YTD()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_OUT_TECH_NBR_SVC2")) != QDesign.NULL(0d)))
                {
                    decReturnValue = (rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_IN_TECH_NBR_SVC2") + rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_OUT_TECH_NBR_SVC2"));
                }
                else
                {
                    decReturnValue = (rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_IN_PROF_NBR_SVC2") + rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_OUT_PROF_NBR_SVC2"));
                }
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
                decReturnValue = (T_AMT_YTD() + P_AMT_YTD());
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
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F050TP_DOC_REVENUE_MSTR.DOCREVTP_CLINIC_NBR", DataTypes.Numeric, 2);
                AddControl(ReportSection.FOOTING_AT, "T_P_SVC_MTD", DataTypes.Numeric, 5);
                AddControl(ReportSection.FOOTING_AT, "T_AMT_MTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "P_AMT_MTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "TOTAL_AMT_MTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "T_P_SVC_YTD", DataTypes.Numeric, 5);
                AddControl(ReportSection.FOOTING_AT, "T_AMT_YTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "P_AMT_YTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "TOTAL_AMT_YTD", DataTypes.Numeric, 8);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-05-11 1:07:29 PM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            // TODO: Remove duplicate controls, if there are any.
            switch (strControl)
            {
                case "INDEXED.F050TP_DOC_REVENUE_MSTR.DOCREVTP_CLINIC_NBR":
                    return rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_CLINIC_NBR").ToString();
                case "T_P_SVC_MTD":
                    return T_P_SVC_MTD().ToString();
                case "T_AMT_MTD":
                    return T_AMT_MTD().ToString();
                case "P_AMT_MTD":
                    return P_AMT_MTD().ToString();
                case "TOTAL_AMT_MTD":
                    return TOTAL_AMT_MTD().ToString();
                case "T_P_SVC_YTD":
                    return T_P_SVC_YTD().ToString();
                case "T_AMT_YTD":
                    return T_AMT_YTD().ToString();
                case "P_AMT_YTD":
                    return P_AMT_YTD().ToString();
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
                        Link_F020C_DOC_CLINIC_NEXT_BATCH_NBR();
                        while (rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.Read())
                        {
                            Link_ICONST_MSTR_REC();
                            while (rdrICONST_MSTR_REC.Read())
                            {
                                Link_F070_DEPT_MSTR();
                                while (rdrF070_DEPT_MSTR.Read())
                                {
                                    Link_F040_OMA_FEE_MSTR();
                                    while (rdrF040_OMA_FEE_MSTR.Read())
                                    {
                                        WriteData();
                                    }

                                    rdrF040_OMA_FEE_MSTR.Close();
                                }

                                rdrF070_DEPT_MSTR.Close();
                            }

                            rdrICONST_MSTR_REC.Close();
                        }

                        rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.Close();
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

            if (!(rdrF070_DEPT_MSTR == null))
            {
                rdrF070_DEPT_MSTR.Close();
                rdrF070_DEPT_MSTR = null;
            }

            if (!(rdrF040_OMA_FEE_MSTR == null))
            {
                rdrF040_OMA_FEE_MSTR.Close();
                rdrF040_OMA_FEE_MSTR = null;
            }
            if (!(rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR == null))
            {
                rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.Close();
                rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR = null;
            }
        }
    }
}