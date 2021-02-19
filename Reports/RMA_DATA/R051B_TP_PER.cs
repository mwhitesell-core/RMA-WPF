//  DOC: R051B_TP_PER.QZS
//  DOC: PHYSICIAN REVENUE ANALYSIS BY PERCENT
//  DOC: RUN FOR: MUMC DIAGNOSTICS
//  PROGRAM PURPOSE : PHYSICIAN REVENUE ANALYSIS
//  DATE       BY WHOM   DESCRIPTION
//  95/09/14   YASEMIN   ORIGINAL
//  03/dec/15  A.A.      alpha doctor nbr
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
    public class R051B_TP_PER : BaseRDLClass
    {
        protected const string REPORT_NAME = "R051B_TP_PER";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrR051A_TP = new Reader();
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
                Sort = "DOCREVTP_CLINIC_NBR ASC, DOCREVTP_DOC_NBR ASC";
                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return ReportData;
        }
        private void Access_R051A_TP()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: If * is not used to select all columns, ensure the necessary columns (i.e. columns that are used to access records of other tables) are included in the SELECT statement
            strSQL.Append("SELECT ");
            strSQL.Append("DOCREVTP_DOC_NBR, ");
            strSQL.Append("DOCREVTP_CLINIC_NBR, ");
            strSQL.Append("X_TECH_MTD, ");
            strSQL.Append("TOTAL_AMT_MTD, ");
            strSQL.Append("X_PROF_MTD, ");
            strSQL.Append("X_TECH_YTD, ");
            strSQL.Append("TOTAL_AMT_YTD, ");
            strSQL.Append("X_PROF_YTD ");
            strSQL.Append("FROM TEMPORARYDATA.R051A_TP ");
            strSQL.Append(Choose());
            rdrR051A_TP.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
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
            strSQL.Append(" DOC_INIT3 ");
            strSQL.Append("FROM INDEXED.F020_DOCTOR_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_NBR = ").Append(Common.StringToField(rdrR051A_TP.GetString("DOCREVTP_DOC_NBR")));
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
            strSQL.Append("ICONST_CLINIC_NBR_1_2 = ").Append(rdrR051A_TP.GetNumber("DOCREVTP_CLINIC_NBR"));
            rdrICONST_MSTR_REC.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(String.Empty);
            // TODO: CHOOSE Statement - May require manual changes.
            return strChoose.ToString().ToString();
        }

        private decimal X_TECH_PER_MTD()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = QDesign.Round((QDesign.Divide(rdrR051A_TP.GetNumber("X_TECH_MTD"), rdrR051A_TP.GetNumber("TOTAL_AMT_MTD"))
                                * 10000), 0, RoundOptionTypes.Near);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_PROF_PER_MTD()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = QDesign.Round((QDesign.Divide(rdrR051A_TP.GetNumber("X_PROF_MTD"), rdrR051A_TP.GetNumber("TOTAL_AMT_MTD"))
                                * 10000), 0, RoundOptionTypes.Near);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_TECH_PER_YTD()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = QDesign.Round((QDesign.Divide(rdrR051A_TP.GetNumber("X_TECH_YTD"), rdrR051A_TP.GetNumber("TOTAL_AMT_YTD"))
                                * 10000), 0, RoundOptionTypes.Near);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_PROF_PER_YTD()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = QDesign.Round((QDesign.Divide(rdrR051A_TP.GetNumber("X_PROF_YTD"), rdrR051A_TP.GetNumber("TOTAL_AMT_YTD"))
                                * 10000), 0, RoundOptionTypes.Near);
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
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.R051A_TP.DOCREVTP_CLINIC_NBR", DataTypes.Numeric, 2);
                AddControl(ReportSection.PAGE_HEADING, "ICONST_DATE_PERIOD_END", DataTypes.Numeric, 8);
                AddControl(ReportSection.PAGE_HEADING, "INDEXED.ICONST_MSTR_REC.ICONST_CLINIC_NAME", DataTypes.Character, 20);
                AddControl(ReportSection.PAGE_HEADING, "INDEXED.ICONST_MSTR_REC.ICONST_CLINIC_NBR", DataTypes.Character, 4);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R051A_TP.DOCREVTP_DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.FOOTING_AT, "X_NAME", DataTypes.Character, 21);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R051A_TP.X_TECH_MTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_TECH_PER_MTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R051A_TP.X_PROF_MTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_PROF_PER_MTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R051A_TP.TOTAL_AMT_MTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R051A_TP.X_TECH_YTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_TECH_PER_YTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R051A_TP.X_PROF_YTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_PROF_PER_YTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R051A_TP.TOTAL_AMT_YTD", DataTypes.Numeric, 8);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-05-11 7:47:37 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            // TODO: Remove duplicate controls, if there are any.
            switch (strControl)
            {
                case "TEMPORARYDATA.R051A_TP.DOCREVTP_CLINIC_NBR":
                    return rdrR051A_TP.GetNumber("DOCREVTP_CLINIC_NBR").ToString();
                case "ICONST_DATE_PERIOD_END":
                    return ICONST_MSTR_REC_ICONST_DATE_PERIOD_END().ToString();
                case "INDEXED.ICONST_MSTR_REC.ICONST_CLINIC_NAME":
                    return Common.StringToField(rdrICONST_MSTR_REC.GetString("ICONST_CLINIC_NAME"));
                case "INDEXED.ICONST_MSTR_REC.ICONST_CLINIC_NBR":
                    return Common.StringToField(rdrICONST_MSTR_REC.GetString("ICONST_CLINIC_NBR"));
                case "TEMPORARYDATA.R051A_TP.DOCREVTP_DOC_NBR":
                    return Common.StringToField(rdrR051A_TP.GetString("DOCREVTP_DOC_NBR"));
                case "X_NAME":
                    return Common.StringToField(X_NAME(), intSize);
                case "TEMPORARYDATA.R051A_TP.X_TECH_MTD":
                    return rdrR051A_TP.GetNumber("X_TECH_MTD").ToString();
                case "X_TECH_PER_MTD":
                    return X_TECH_PER_MTD().ToString();
                case "TEMPORARYDATA.R051A_TP.X_PROF_MTD":
                    return rdrR051A_TP.GetNumber("X_PROF_MTD").ToString();
                case "X_PROF_PER_MTD":
                    return X_PROF_PER_MTD().ToString();
                case "TEMPORARYDATA.R051A_TP.TOTAL_AMT_MTD":
                    return rdrR051A_TP.GetNumber("TOTAL_AMT_MTD").ToString();
                case "TEMPORARYDATA.R051A_TP.X_TECH_YTD":
                    return rdrR051A_TP.GetNumber("X_TECH_YTD").ToString();
                case "X_TECH_PER_YTD":
                    return X_TECH_PER_YTD().ToString();
                case "TEMPORARYDATA.R051A_TP.X_PROF_YTD":
                    return rdrR051A_TP.GetNumber("X_PROF_YTD").ToString();
                case "X_PROF_PER_YTD":
                    return X_PROF_PER_YTD().ToString();
                case "TEMPORARYDATA.R051A_TP.TOTAL_AMT_YTD":
                    return rdrR051A_TP.GetNumber("TOTAL_AMT_YTD").ToString();
                default:
                    return String.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                // TODO: Some manual steps maybe required.
                Access_R051A_TP();
                while (rdrR051A_TP.Read())
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

                rdrR051A_TP.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrR051A_TP == null))
            {
                rdrR051A_TP.Close();
                rdrR051A_TP = null;
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
