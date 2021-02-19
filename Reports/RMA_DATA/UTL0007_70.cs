//  DOC: utl0007_70.qzs
//  DOC: REVENUE BY DOC/DEPT/OMACD/TECH/PROF AND TOTAL FOR MTD FIGURES
//  DOC: FOR ALL AGENTS TOTALS AT DOC NO. (CLINIC 60 ONLY)
//  DOC: RUN FOR: ACCOUNTING DEPT MARY BROWNRIDGE
//  PROGRAM PURPOSE : COMPUTERIZE REPORT WHICH WAS CREATED MANUALLY
//  DATE       WHO       DESCRIPTION
//  2007/Mar   Y.B.      utl0007 
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
    public class UTL0007_70 : BaseRDLClass
    {
        protected const string REPORT_NAME = "UTL0007_70";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrF050TP_DOC_REVENUE_MSTR = new Reader();
        private Reader rdrF020_DOCTOR_MSTR = new Reader();
        private Reader rdrICONST_MSTR_REC = new Reader();
        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                //  Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;
                Sort = "DOCREVTP_DOC_NBR ASC, DOCREVTP_OMA_CD ASC";
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
            strSQL.Append("DOCREVTP_OUT_PROF_NBR_SVC2, ");
            strSQL.Append("DOCREVTP_AGENT_CD ");
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
            strSQL.Append("DOC_NAME, ");
            strSQL.Append("DOC_INIT1, ");
            strSQL.Append(" DOC_INIT2, ");
            strSQL.Append(" DOC_INIT3, ");
            strSQL.Append("DOC_DEPT ");
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
            strSQL.Append(" ICONST_DATE_PERIOD_END_DD ");
            strSQL.Append("FROM INDEXED.ICONST_MSTR_REC ");
            strSQL.Append("WHERE ");
            strSQL.Append("ICONST_CLINIC_NBR_1_2 = ").Append(rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_CLINIC_NBR"));
            rdrICONST_MSTR_REC.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(String.Empty);
            // TODO: CHOOSE Statement - May require manual changes.
            strChoose.Append(" WHERE DOCREVTP_CLINIC_NBR BETWEEN 71 AND 75");
            return strChoose.ToString().ToString();
        }

        public override bool SelectIf()
        {
            bool blnSelected = false;
            if (((QDesign.NULL(rdrF050TP_DOC_REVENUE_MSTR.GetString("DOCREVTP_AGENT_CD")) != "6")
                        && ((QDesign.NULL(X_PROF()) != QDesign.NULL(0d))
                        || (QDesign.NULL(X_TECH()) != QDesign.NULL(0d)))))
            {
                blnSelected = true;
            }

            return blnSelected;
        }

        private decimal X_TECH()
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

        private decimal T_SVC()
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

        private decimal X_PROF()
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

        private decimal P_SVC()
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

        private decimal X_TOTAL()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = (X_TECH() + X_PROF());
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal SVC_TOT()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = (T_SVC() + P_SVC());
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
                strReturnValue = QDesign.Pack(rdrF020_DOCTOR_MSTR.GetString("DOC_NAME") + " " + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT1") + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT2") + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT3"));
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
        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.PAGE_HEADING, "ICONST_DATE_PERIOD_END", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F050TP_DOC_REVENUE_MSTR.DOCREVTP_DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT", DataTypes.Numeric, 2);
                AddControl(ReportSection.FOOTING_AT, "X_NAME", DataTypes.Character, 30);
                AddControl(ReportSection.FOOTING_AT, "DOCREVTP_OMA_CD", DataTypes.Character, 5);
                AddControl(ReportSection.FOOTING_AT, "T_SVC", DataTypes.Numeric, 5);
                AddControl(ReportSection.FOOTING_AT, "X_TECH", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "P_SVC", DataTypes.Numeric, 5);
                AddControl(ReportSection.FOOTING_AT, "X_PROF", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "SVC_TOT", DataTypes.Numeric, 5);
                AddControl(ReportSection.FOOTING_AT, "X_TOTAL", DataTypes.Numeric, 8);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-05-16 12:44:00 PM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            // TODO: Remove duplicate controls, if there are any.
            switch (strControl)
            {
                case "ICONST_DATE_PERIOD_END":
                    return ICONST_MSTR_REC_ICONST_DATE_PERIOD_END().ToString();
                case "INDEXED.F050TP_DOC_REVENUE_MSTR.DOCREVTP_DOC_NBR":
                    return Common.StringToField(rdrF050TP_DOC_REVENUE_MSTR.GetString("DOCREVTP_DOC_NBR"));
                case "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT":
                    return rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT").ToString();
                case "X_NAME":
                    return Common.StringToField(X_NAME(), intSize);
                case "DOCREVTP_OMA_CD":
                    return Common.StringToField(F050TP_DOC_REVENUE_MSTR_DOCREVTP_OMA_CD(), intSize);
                case "T_SVC":
                    return T_SVC().ToString();
                case "X_TECH":
                    return X_TECH().ToString();
                case "P_SVC":
                    return P_SVC().ToString();
                case "X_PROF":
                    return X_PROF().ToString();
                case "SVC_TOT":
                    return SVC_TOT().ToString();
                case "X_TOTAL":
                    return X_TOTAL().ToString();
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
                            WriteData();
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
        }
    }
}
