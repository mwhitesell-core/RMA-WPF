//  DOC: R051A_TP_PER_70 
//  DOC: PHYSICIAN REVENUE ANALYSIS BY PERCENT
//  DOC: RUN FOR: MUMC DIAGNOSTICS
//  PROGRAM PURPOSE : PHYSICIAN REVENUE ANALYSIS
//  DATE       BY WHOM   DESCRIPTION
//  2007/03    YASEMIN   r051a_tp_per
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
    public class R051A_TP_PER_70 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R051A_TP_PER_70";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrF050TP_DOC_REVENUE_MSTR = new Reader();
        private Reader rdrR051A_TP_70 = new Reader();

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
                SubFileName = "R051A_TP_70";
                SubFileType = SubFileType.Keep;
                SubFileAT = "X_SORT_KEY";
                Sort = "X_SORT_KEY ASC";
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

        private void Access_F050TP_DOC_REVENUE_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOCREVTP_CLINIC_NBR, ");
            strSQL.Append("DOCREVTP_AGENT_CD, ");
            strSQL.Append("DOCREVTP_LOC_CD, ");
            strSQL.Append("DOCREVTP_OMA_CODE, ");
            strSQL.Append("DOCREVTP_OMA_SUFFIX, ");
            strSQL.Append("DOCREVTP_DOC_NBR, ");
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
            strSQL.Append("DOCREVTP_OUT_PROF_AMT_ADJUSTS2 ");
            strSQL.Append("FROM INDEXED.F050TP_DOC_REVENUE_MSTR ");

            strSQL.Append(Choose());
            rdrF050TP_DOC_REVENUE_MSTR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

            strSQL = null;
        }

        #endregion

        #region " CHOOSE "

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(string.Empty);

            strChoose.Append(" WHERE DOCREVTP_CLINIC_NBR BETWEEN 71 AND 75");

            return strChoose.ToString();
        }

        #endregion

        #region " SELECT IF "

        #endregion

        #region " DEFINES "

        private string X_CLINIC()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = QDesign.ASCII(rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_CLINIC_NBR"), 2);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_DOCTOR()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = rdrF050TP_DOC_REVENUE_MSTR.GetString("DOCREVTP_DOC_NBR");
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_SORT_KEY()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = (X_CLINIC() + X_DOCTOR());
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private decimal X_TECH_MTD()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = (rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_IN_TECH_AMT_BILLED1")
                            + (rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_OUT_TECH_AMT_BILLED1")
                            + (rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_IN_TECH_AMT_ADJUSTS1") 
                            + rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_OUT_TECH_AMT_ADJUSTS1"))));
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
                decReturnValue = (rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_IN_PROF_AMT_BILLED1")
                            + (rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_OUT_PROF_AMT_BILLED1")
                            + (rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_IN_PROF_AMT_ADJUSTS1") 
                            + rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_OUT_PROF_AMT_ADJUSTS1"))));
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
                decReturnValue = (rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_IN_TECH_AMT_BILLED2")
                            + (rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_OUT_TECH_AMT_BILLED2")
                            + (rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_IN_TECH_AMT_ADJUSTS2") 
                            + rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_OUT_TECH_AMT_ADJUSTS2"))));
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
                decReturnValue = (rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_IN_PROF_AMT_BILLED2")
                            + (rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_OUT_PROF_AMT_BILLED2")
                            + (rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_IN_PROF_AMT_ADJUSTS2") 
                            + rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_OUT_PROF_AMT_ADJUSTS2"))));
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
                decReturnValue = (X_TECH_YTD() + X_PROF_YTD());
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
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
                AddControl(ReportSection.SUMMARY, "X_SORT_KEY", DataTypes.Character, 5);
                AddControl(ReportSection.SUMMARY, "INDEXED.F050TP_DOC_REVENUE_MSTR.DOCREVTP_CLINIC_NBR", DataTypes.Numeric, 2);
                AddControl(ReportSection.SUMMARY, "INDEXED.F050TP_DOC_REVENUE_MSTR.DOCREVTP_DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.SUMMARY, "X_TECH_MTD", DataTypes.Numeric, 8, SummaryType.SUBTOTAL);
                AddControl(ReportSection.SUMMARY, "X_PROF_MTD", DataTypes.Numeric, 8, SummaryType.SUBTOTAL);
                AddControl(ReportSection.SUMMARY, "TOTAL_AMT_MTD", DataTypes.Numeric, 8, SummaryType.SUBTOTAL);
                AddControl(ReportSection.SUMMARY, "X_TECH_YTD", DataTypes.Numeric, 8, SummaryType.SUBTOTAL);
                AddControl(ReportSection.SUMMARY, "X_PROF_YTD", DataTypes.Numeric, 8, SummaryType.SUBTOTAL);
                AddControl(ReportSection.SUMMARY, "TOTAL_AMT_YTD", DataTypes.Numeric, 8, SummaryType.SUBTOTAL);
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
        // # Do not delete, modify or move it.  Updated: 2018-05-11 7:47:37 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            // TODO: Remove duplicate controls, if there are any.
            switch (strControl)
            {
                case "X_SORT_KEY":
                    return Common.StringToField(X_SORT_KEY(), intSize);

                case "INDEXED.F050TP_DOC_REVENUE_MSTR.DOCREVTP_CLINIC_NBR":
                    return rdrF050TP_DOC_REVENUE_MSTR.GetNumber("DOCREVTP_CLINIC_NBR").ToString();

                case "INDEXED.F050TP_DOC_REVENUE_MSTR.DOCREVTP_DOC_NBR":
                    return Common.StringToField(rdrF050TP_DOC_REVENUE_MSTR.GetString("DOCREVTP_DOC_NBR"));

                case "X_TECH_MTD":
                    return X_TECH_MTD().ToString();

                case "X_PROF_MTD":
                    return X_PROF_MTD().ToString();

                case "TOTAL_AMT_MTD":
                    return TOTAL_AMT_MTD().ToString();

                case "X_TECH_YTD":
                    return X_TECH_YTD().ToString();

                case "X_PROF_YTD":
                    return X_PROF_YTD().ToString();

                case "TOTAL_AMT_YTD":
                    return TOTAL_AMT_YTD().ToString();

                default:
                    return string.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                Access_F050TP_DOC_REVENUE_MSTR();
                while (rdrF050TP_DOC_REVENUE_MSTR.Read())
                {
                    WriteData();
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
        }

        #endregion

        #endregion
    }
}
