//  DOC: UTL0006.QZS
//  DOC: REP CASH APPLIED BY DOC/DEPT/LOCATION/TECH/PROF/TOTAL  TOTALS AT
//  DOC: DOCTOR NUMBER FOR ALL AGENTS (CLINIC 60 ONLY)
//  DOC: RUN FOR: ACCOUNTING DEPT MARY BROWNRIDGE
//  PROGRAM PURPOSE : COMPUTERIZE THE REPORT WHICH WAS CREATED MANUALLY
//  DATE       WHO       DESCRIPTION
//  92/02/24   Y.B.      ORIGINAL
//  92/11/07   Y.B.      FOOTING AT CLINIC INSTEAD OF LOCATION
//  99/12/15   B.E.      - y2k review, recompile
//  03/01/15   yas       - prdecimal rma physicians only utl0006a will prdecimal rma inc. 
//  03/dec/17  A.A.      - alpha doctor nbr
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
    public class UTL0006 : BaseRDLClass
    {
        protected const string REPORT_NAME = "UTL0006";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrF051TP_DOC_CASH_MSTR = new Reader();
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
                Sort = "DOCASHTP_DOC_NBR ASC, DOCASHTP_CLINIC_NBR ASC";
                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return ReportData;
        }
        private void Access_F051TP_DOC_CASH_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            strSQL.Append("SELECT ");
            strSQL.Append("DOCASHTP_DOC_NBR, ");
            strSQL.Append("DOCASHTP_CLINIC_NBR, ");
            strSQL.Append("DOCASHTP_CLINIC_NBR, ");
            strSQL.Append(" DOCASHTP_AGENT_CD, ");
            strSQL.Append(" DOCASHTP_LOC_CD, ");
            strSQL.Append(" DOCASHTP_DOC_NBR, ");
            strSQL.Append("DOCASHTP_TECH_IN_MTD, ");
            strSQL.Append("DOCASHTP_TECH_OUT_MTD, ");
            strSQL.Append("DOCASHTP_PROF_IN_MTD, ");
            strSQL.Append("DOCASHTP_PROF_OUT_MTD ");
            strSQL.Append("FROM INDEXED.F051TP_DOC_CASH_MSTR ");
            strSQL.Append(Choose());
            rdrF051TP_DOC_CASH_MSTR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_F020_DOCTOR_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("DOC_DEPT, ");
            strSQL.Append("DOC_NAME, ");
            strSQL.Append("DOC_INIT1, ");
            strSQL.Append(" DOC_INIT2, ");
            strSQL.Append(" DOC_INIT3 ");
            strSQL.Append("FROM INDEXED.F020_DOCTOR_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_NBR = ").Append(Common.StringToField(rdrF051TP_DOC_CASH_MSTR.GetString("DOCASHTP_DOC_NBR")));
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
            strSQL.Append("ICONST_CLINIC_NBR_1_2 = ").Append(rdrF051TP_DOC_CASH_MSTR.GetNumber("DOCASHTP_CLINIC_NBR"));
            rdrICONST_MSTR_REC.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
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
            strSQL.Append("DEPT_NBR = ").Append(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT"));
            rdrF070_DEPT_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(String.Empty);
            // TODO: CHOOSE Statement - May require manual changes.
            strChoose.Append("WHERE DOCASHTP_CLINIC_NBR >= 60 AND DOCASHTP_CLINIC_NBR <= 66");
            return strChoose.ToString().ToString();
        }

        public override bool SelectIf()
        {
            bool blnSelected = false;
            if (((QDesign.NULL(rdrF070_DEPT_MSTR.GetNumber("DEPT_COMPANY")) == QDesign.NULL(1d))
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
                decReturnValue = (rdrF051TP_DOC_CASH_MSTR.GetNumber("DOCASHTP_TECH_IN_MTD") + rdrF051TP_DOC_CASH_MSTR.GetNumber("DOCASHTP_TECH_OUT_MTD"));
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
                decReturnValue = (rdrF051TP_DOC_CASH_MSTR.GetNumber("DOCASHTP_PROF_IN_MTD") + rdrF051TP_DOC_CASH_MSTR.GetNumber("DOCASHTP_PROF_OUT_MTD"));
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

        private decimal X_CLINIC()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrF051TP_DOC_CASH_MSTR.GetNumber("DOCASHTP_CLINIC_NBR")) == QDesign.NULL(60d)))
                {
                    decReturnValue = 6008;
                    decReturnValue = 6008;
                }
                else if ((QDesign.NULL(rdrF051TP_DOC_CASH_MSTR.GetNumber("DOCASHTP_CLINIC_NBR")) == QDesign.NULL(61d)))
                {
                    decReturnValue = 9595;
                }
                else if ((QDesign.NULL(rdrF051TP_DOC_CASH_MSTR.GetNumber("DOCASHTP_CLINIC_NBR")) == QDesign.NULL(62d)))
                {
                    decReturnValue = 9598;
                }
                else if ((QDesign.NULL(rdrF051TP_DOC_CASH_MSTR.GetNumber("DOCASHTP_CLINIC_NBR")) == QDesign.NULL(63d)))
                {
                    decReturnValue = 9607;
                }
                else if ((QDesign.NULL(rdrF051TP_DOC_CASH_MSTR.GetNumber("DOCASHTP_CLINIC_NBR")) == QDesign.NULL(64d)))
                {
                    decReturnValue = 9619;
                }
                else if ((QDesign.NULL(rdrF051TP_DOC_CASH_MSTR.GetNumber("DOCASHTP_CLINIC_NBR")) == QDesign.NULL(65d)))
                {
                    decReturnValue = 9632;
                }
                else if ((QDesign.NULL(rdrF051TP_DOC_CASH_MSTR.GetNumber("DOCASHTP_CLINIC_NBR")) == QDesign.NULL(66d)))
                {
                    decReturnValue = 9098;
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
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

        private string F020_DOCTOR_MSTR_DOC_INITS()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = (rdrF020_DOCTOR_MSTR.GetString("DOC_INIT1")
                            + (rdrF020_DOCTOR_MSTR.GetString("DOC_INIT2") + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT3")));
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
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F051TP_DOC_CASH_MSTR.DOCASHTP_DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT", DataTypes.Numeric, 2);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F020_DOCTOR_MSTR.DOC_NAME", DataTypes.Character, 24);
                AddControl(ReportSection.FOOTING_AT, "F020_DOCTOR_MSTR_DOC_INITS", DataTypes.Character, 3);
                AddControl(ReportSection.FOOTING_AT, "X_CLINIC", DataTypes.Numeric, 4);
                AddControl(ReportSection.FOOTING_AT, "X_TECH", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_PROF", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_TOTAL", DataTypes.Numeric, 8);
                AddControl(ReportSection.REPORT, "INDEXED.F051TP_DOC_CASH_MSTR.DOCASHTP_CLINIC_NBR", DataTypes.Character, 2);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-05-16 12:45:40 PM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            // TODO: Remove duplicate controls, if there are any.
            switch (strControl)
            {
                case "ICONST_DATE_PERIOD_END":
                    return ICONST_MSTR_REC_ICONST_DATE_PERIOD_END().ToString();
                case "INDEXED.F051TP_DOC_CASH_MSTR.DOCASHTP_DOC_NBR":
                    return Common.StringToField(rdrF051TP_DOC_CASH_MSTR.GetString("DOCASHTP_DOC_NBR"));
                case "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT":
                    return rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT").ToString();
                case "INDEXED.F020_DOCTOR_MSTR.DOC_NAME":
                    return Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_NAME"));
                case "F020_DOCTOR_MSTR_DOC_INITS":
                    return Common.StringToField(F020_DOCTOR_MSTR_DOC_INITS(), intSize);
                case "X_CLINIC":
                    return X_CLINIC().ToString();
                case "X_TECH":
                    return X_TECH().ToString();
                case "X_PROF":
                    return X_PROF().ToString();
                case "X_TOTAL":
                    return X_TOTAL().ToString();
                case "INDEXED.F051TP_DOC_CASH_MSTR.DOCASHTP_CLINIC_NBR":
                    return Common.StringToField(rdrF051TP_DOC_CASH_MSTR.GetString("DOCASHTP_CLINIC_NBR"));
                default:
                    return String.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                // TODO: Some manual steps maybe required.
                Access_F051TP_DOC_CASH_MSTR();
                while (rdrF051TP_DOC_CASH_MSTR.Read())
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

                rdrF051TP_DOC_CASH_MSTR.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrF051TP_DOC_CASH_MSTR == null))
            {
                rdrF051TP_DOC_CASH_MSTR.Close();
                rdrF051TP_DOC_CASH_MSTR = null;
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
