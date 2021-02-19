//  DOC: r005ctp_70 
//  DOC: MONTHLY CASH APPLIED RECONCILIATION
//  DOC: SORT BY AGENT CODE
//  DOC: RUN FOR: MUMC DIAGNOSTICS
//  PROGRAM PURPOSE : CASH ANALYSIS BY LOCATION (SUMMARY BY CLINIC REPORT)
//  R005TP.CB CONVERSTION TO POWERHOUSE R005CTP.QZS
//  APPEND R005CTP.TXT TO END OF R005BTP.TXT
//  DATE       WHO       DESCRIPTION
//  2007/Mar   Y.B.     r005ctp  
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
    public class R005CTP_70 : BaseRDLClass
    {
        protected const string REPORT_NAME = "R005CTP_70";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrF051TP_DOC_CASH_MSTR = new Reader();
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
                Sort = "DOCASHTP_AGENT_CD ASC";
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
            strSQL.Append("DOCASHTP_LOC_CD, ");
            strSQL.Append(" DOCASHTP_AGENT_CD, ");
            strSQL.Append("DOCASHTP_TECH_IN_MTD, ");
            strSQL.Append("DOCASHTP_TECH_OUT_MTD, ");
            strSQL.Append("DOCASHTP_PROF_IN_MTD, ");
            strSQL.Append("DOCASHTP_PROF_OUT_MTD, ");
            strSQL.Append("DOCASHTP_TECH_IN_YTD, ");
            strSQL.Append("DOCASHTP_TECH_OUT_YTD, ");
            strSQL.Append("DOCASHTP_PROF_IN_YTD, ");
            strSQL.Append("DOCASHTP_PROF_OUT_YTD ");
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
            strSQL.Append("DOC_NBR ");
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
        private void Link_F030_LOCATIONS_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("LOC_NBR ");
            strSQL.Append("FROM INDEXED.F030_LOCATIONS_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("LOC_NBR = ").Append(Common.StringToField(rdrF051TP_DOC_CASH_MSTR.GetString("DOCASHTP_LOC_CD")));
            rdrF030_LOCATIONS_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(String.Empty);
            // TODO: CHOOSE Statement - May require manual changes.
            strChoose.Append(" WHERE DOCASHTP_CLINIC_NBR BETWEEN 71 AND 75");
            return strChoose.ToString().ToString();
        }

        private decimal X_TECH_MTD()
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

        private decimal X_PROF_MTD()
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

        private decimal X_TOTAL_MTD()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = (X_TECH_MTD() + X_PROF_MTD());
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_TECH_YTD()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = (rdrF051TP_DOC_CASH_MSTR.GetNumber("DOCASHTP_TECH_IN_YTD") + rdrF051TP_DOC_CASH_MSTR.GetNumber("DOCASHTP_TECH_OUT_YTD"));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_PROF_YTD()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = (rdrF051TP_DOC_CASH_MSTR.GetNumber("DOCASHTP_PROF_IN_YTD") + rdrF051TP_DOC_CASH_MSTR.GetNumber("DOCASHTP_PROF_OUT_YTD"));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_TOTAL_YTD()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = (X_TECH_YTD() + X_PROF_YTD());
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
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

        private string X_DAY()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = QDesign.ASCII(rdrICONST_MSTR_REC.GetNumber("ICONST_DATE_PERIOD_END_YY"), 2);
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
                strReturnValue = QDesign.Pack((X_MONTH() + ("/ " + X_YEAR())));
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
                AddControl(ReportSection.PAGE_HEADING, "ICONST_DATE_PERIOD_END", DataTypes.Numeric, 8);
                AddControl(ReportSection.PAGE_HEADING, "X_DATE", DataTypes.Character, 15);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F051TP_DOC_CASH_MSTR.DOCASHTP_AGENT_CD", DataTypes.Character, 1);
                AddControl(ReportSection.FOOTING_AT, "X_TECH_MTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_PROF_MTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_TOTAL_MTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_TECH_YTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_PROF_YTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_TOTAL_YTD", DataTypes.Numeric, 8);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-05-09 11:06:46 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            // TODO: Remove duplicate controls, if there are any.
            switch (strControl)
            {
                case "ICONST_DATE_PERIOD_END":
                    return ICONST_MSTR_REC_ICONST_DATE_PERIOD_END().ToString();
                case "X_DATE":
                    return Common.StringToField(X_DATE(), intSize);
                case "INDEXED.F051TP_DOC_CASH_MSTR.DOCASHTP_AGENT_CD":
                    return Common.StringToField(rdrF051TP_DOC_CASH_MSTR.GetString("DOCASHTP_AGENT_CD"));
                case "X_TECH_MTD":
                    return X_TECH_MTD().ToString();
                case "X_PROF_MTD":
                    return X_PROF_MTD().ToString();
                case "X_TOTAL_MTD":
                    return X_TOTAL_MTD().ToString();
                case "X_TECH_YTD":
                    return X_TECH_YTD().ToString();
                case "X_PROF_YTD":
                    return X_PROF_YTD().ToString();
                case "X_TOTAL_YTD":
                    return X_TOTAL_YTD().ToString();
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

            if (!(rdrF030_LOCATIONS_MSTR == null))
            {
                rdrF030_LOCATIONS_MSTR.Close();
                rdrF030_LOCATIONS_MSTR = null;
            }
        }
    }
}
