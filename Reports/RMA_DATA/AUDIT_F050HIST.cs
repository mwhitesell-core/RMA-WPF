#region "Screen Comments"

// 2015/Apr/01 MC As per Yasemin, only pick up the current year records
// Program: audit_f050hist
// Purpose: prdecimal an audit of f050 history rev values for each clinic
// MC - include  constants-mstr-rec-7 to pick up current year
// access f050-doc-revenue-mstr-history  &

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
    public class AUDIT_F050HIST : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "AUDIT_F050HIST";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrCONSTANTS_MSTR_REC_7 = new Reader();
        private Reader rdrF050_DOC_REVENUE_MSTR_HISTORY = new Reader();

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

                Sort = "ICONST_DATE_PERIOD_END ASC, EP_YR ASC, DOCREV_CLINIC_1_2 ASC";

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
        private void Link_F050_DOC_REVENUE_MSTR_HISTORY()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("EP_YR, ");
            strSQL.Append("ICONST_DATE_PERIOD_END, ");
            strSQL.Append("DOCREV_CLINIC_1_2, ");
            strSQL.Append("DOCREV_LOCATION, ");
            strSQL.Append("DOCREV_MTD_IN_SVC, ");
            strSQL.Append("DOCREV_MTD_OUT_SVC, ");
            strSQL.Append("DOCREV_MTD_IN_REC, ");
            strSQL.Append("DOCREV_MTD_OUT_REC, ");
            strSQL.Append("DOCREV_YTD_IN_SVC, ");
            strSQL.Append("DOCREV_YTD_OUT_SVC, ");
            strSQL.Append("DOCREV_YTD_IN_REC, ");
            strSQL.Append("DOCREV_YTD_OUT_REC ");
            strSQL.Append("FROM INDEXED.F050_DOC_REVENUE_MSTR_HISTORY ");
            strSQL.Append("WHERE ");
            strSQL.Append("EP_YR = ").Append(rdrCONSTANTS_MSTR_REC_7.GetNumber("EP_YR"));

            rdrF050_DOC_REVENUE_MSTR_HISTORY.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

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

        private decimal X_SVC_MTD_IN()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrF050_DOC_REVENUE_MSTR_HISTORY.GetString("DOCREV_LOCATION")) != QDesign.NULL("MISC"))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR_HISTORY.GetNumber("DOCREV_MTD_IN_SVC");
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private decimal X_SVC_MTD_OUT()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrF050_DOC_REVENUE_MSTR_HISTORY.GetString("DOCREV_LOCATION")) != QDesign.NULL("MISC"))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR_HISTORY.GetNumber("DOCREV_MTD_OUT_SVC");
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private decimal X_AMT_MTD_IN()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrF050_DOC_REVENUE_MSTR_HISTORY.GetString("DOCREV_LOCATION")) != QDesign.NULL("MISC"))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR_HISTORY.GetNumber("DOCREV_MTD_IN_REC");
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private decimal X_AMT_MTD_OUT()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrF050_DOC_REVENUE_MSTR_HISTORY.GetString("DOCREV_LOCATION")) != QDesign.NULL("MISC"))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR_HISTORY.GetNumber("DOCREV_MTD_OUT_REC");
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private decimal X_MISC_SVC_MTD()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrF050_DOC_REVENUE_MSTR_HISTORY.GetString("DOCREV_LOCATION")) == QDesign.NULL("MISC"))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR_HISTORY.GetNumber("DOCREV_MTD_OUT_SVC");
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private decimal X_MISC_AMT_MTD()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrF050_DOC_REVENUE_MSTR_HISTORY.GetString("DOCREV_LOCATION")) == QDesign.NULL("MISC"))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR_HISTORY.GetNumber("DOCREV_MTD_OUT_REC");
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private decimal X_SVC_YTD_IN()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrF050_DOC_REVENUE_MSTR_HISTORY.GetString("DOCREV_LOCATION")) != QDesign.NULL("MISC"))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR_HISTORY.GetNumber("DOCREV_YTD_IN_SVC");
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private decimal X_SVC_YTD_OUT()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrF050_DOC_REVENUE_MSTR_HISTORY.GetString("DOCREV_LOCATION")) != QDesign.NULL("MISC"))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR_HISTORY.GetNumber("DOCREV_YTD_OUT_SVC");
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private decimal X_AMT_YTD_IN()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrF050_DOC_REVENUE_MSTR_HISTORY.GetString("DOCREV_LOCATION")) != QDesign.NULL("MISC"))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR_HISTORY.GetNumber("DOCREV_YTD_IN_REC");
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private decimal X_AMT_YTD_OUT()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrF050_DOC_REVENUE_MSTR_HISTORY.GetString("DOCREV_LOCATION")) != QDesign.NULL("MISC"))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR_HISTORY.GetNumber("DOCREV_YTD_OUT_REC");
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private decimal X_MISC_SVC_YTD()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrF050_DOC_REVENUE_MSTR_HISTORY.GetString("DOCREV_LOCATION")) == QDesign.NULL("MISC"))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR_HISTORY.GetNumber("DOCREV_YTD_OUT_SVC");
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private decimal X_MISC_AMT_YTD()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrF050_DOC_REVENUE_MSTR_HISTORY.GetString("DOCREV_LOCATION")) == QDesign.NULL("MISC"))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR_HISTORY.GetNumber("DOCREV_YTD_OUT_REC");
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private decimal X_SVC_TOTAL_MTD()
        {
            decimal decReturnValue = 0;

            try
            {
                decReturnValue = (X_SVC_MTD_IN() + X_SVC_MTD_OUT() + X_MISC_SVC_MTD());
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private decimal X_SVC_TOTAL_YTD()
        {
            decimal decReturnValue = 0;

            try
            {
                decReturnValue = (X_SVC_YTD_IN() + X_SVC_YTD_OUT() + X_MISC_SVC_YTD());
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private decimal X_AMT_TOTAL_MTD()
        {
            decimal decReturnValue = 0;

            try
            {
                decReturnValue = (X_AMT_MTD_IN() + X_AMT_MTD_OUT() + X_MISC_AMT_MTD());
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private decimal X_AMT_TOTAL_YTD()
        {
            decimal decReturnValue = 0;

            try
            {
                decReturnValue = (X_AMT_YTD_IN() + X_AMT_YTD_OUT() + X_MISC_AMT_YTD());
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
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F050_DOC_REVENUE_MSTR_HISTORY.DOCREV_CLINIC_1_2", DataTypes.Character, 2);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.CONSTANTS_MSTR_REC_7.EP_YR", DataTypes.Numeric, 4);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F050_DOC_REVENUE_MSTR_HISTORY.ICONST_DATE_PERIOD_END", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_SVC_MTD_IN", DataTypes.Numeric, 4);
                AddControl(ReportSection.FOOTING_AT, "X_AMT_MTD_IN", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_SVC_MTD_OUT", DataTypes.Numeric, 4);
                AddControl(ReportSection.FOOTING_AT, "X_AMT_MTD_OUT", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_MISC_AMT_MTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_SVC_TOTAL_MTD", DataTypes.Numeric, 4);
                AddControl(ReportSection.FOOTING_AT, "X_AMT_TOTAL_MTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_SVC_YTD_IN", DataTypes.Numeric, 5);
                AddControl(ReportSection.FOOTING_AT, "X_AMT_YTD_IN", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_SVC_YTD_OUT", DataTypes.Numeric, 5);
                AddControl(ReportSection.FOOTING_AT, "X_AMT_YTD_OUT", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_MISC_AMT_YTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_SVC_TOTAL_YTD", DataTypes.Numeric, 5);
                AddControl(ReportSection.FOOTING_AT, "X_AMT_TOTAL_YTD", DataTypes.Numeric, 8);
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
        //# Do not delete, modify or move it.  Updated: 9/25/2017 11:24:25 AM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "INDEXED.F050_DOC_REVENUE_MSTR_HISTORY.DOCREV_CLINIC_1_2":
                    return Common.StringToField(rdrF050_DOC_REVENUE_MSTR_HISTORY.GetString("DOCREV_CLINIC_1_2"));

                case "INDEXED.CONSTANTS_MSTR_REC_7.EP_YR":
                    return rdrCONSTANTS_MSTR_REC_7.GetNumber("EP_YR").ToString();

                case "INDEXED.F050_DOC_REVENUE_MSTR_HISTORY.ICONST_DATE_PERIOD_END":
                    return rdrF050_DOC_REVENUE_MSTR_HISTORY.GetNumber("ICONST_DATE_PERIOD_END").ToString();

                case "X_SVC_MTD_IN":
                    return X_SVC_MTD_IN().ToString();

                case "X_AMT_MTD_IN":
                    return X_AMT_MTD_IN().ToString();

                case "X_SVC_MTD_OUT":
                    return X_SVC_MTD_OUT().ToString();

                case "X_AMT_MTD_OUT":
                    return X_AMT_MTD_OUT().ToString();

                case "X_MISC_AMT_MTD":
                    return X_MISC_AMT_MTD().ToString();

                case "X_SVC_TOTAL_MTD":
                    return X_SVC_TOTAL_MTD().ToString();

                case "X_AMT_TOTAL_MTD":
                    return X_AMT_TOTAL_MTD().ToString();

                case "X_SVC_YTD_IN":
                    return X_SVC_YTD_IN().ToString();

                case "X_AMT_YTD_IN":
                    return X_AMT_YTD_IN().ToString();

                case "X_SVC_YTD_OUT":
                    return X_SVC_YTD_OUT().ToString();

                case "X_AMT_YTD_OUT":
                    return X_AMT_YTD_OUT().ToString();

                case "X_MISC_AMT_YTD":
                    return X_MISC_AMT_YTD().ToString();

                case "X_SVC_TOTAL_YTD":
                    return X_SVC_TOTAL_YTD().ToString();

                case "X_AMT_TOTAL_YTD":
                    return X_AMT_TOTAL_YTD().ToString();

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
                    Link_F050_DOC_REVENUE_MSTR_HISTORY();
                    while (rdrF050_DOC_REVENUE_MSTR_HISTORY.Read())
                    {
                        WriteData();
                    }
                    rdrF050_DOC_REVENUE_MSTR_HISTORY.Close();
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
            if ((rdrF050_DOC_REVENUE_MSTR_HISTORY != null))
            {
                rdrF050_DOC_REVENUE_MSTR_HISTORY.Close();
                rdrF050_DOC_REVENUE_MSTR_HISTORY = null;
            }
        }

        #endregion

        #endregion
    }
}
