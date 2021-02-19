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
    public class R011B_CSV : BaseRDLClass
    {
        protected const string REPORT_NAME = "R011B_CSV";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrR011_PED = new Reader();
        private Reader rdrF050_DOC_REVENUE_MSTR_HISTORY = new Reader();
        private Reader rdrF070_DEPT_MSTR = new Reader();
        private Reader rdrR011A_CSV = new Reader();

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
                SubFileName = "R011A_CSV";
                SubFileType = SubFileType.Keep;
                SubFileAT = "DOCREV_DEPT";

                Sort = "DOCREV_CLINIC_1_2 ASC, DOCREV_DEPT ASC";

                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return ReportData;
        }
        private void Access_R011_PED()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: If * is not used to select all columns, ensure the necessary columns (i.e. columns that are used to access records of other tables) are included in the SELECT statement
            strSQL.Append("SELECT ");
            strSQL.Append("X_EP_YR ");
            strSQL.Append("FROM TEMPORARYDATA.R011_PED ");
            strSQL.Append(Choose());
            rdrR011_PED.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
            strSQL = null;
        }
        private void Link_F050_DOC_REVENUE_MSTR_HISTORY()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("EP_YR, ");
            strSQL.Append("ICONST_DATE_PERIOD_END, ");
            strSQL.Append("DOCREV_DEPT, ");
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
            strSQL.Append("EP_YR = ").Append(rdrR011_PED.GetNumber("X_EP_YR"));
            strSQL.Append(" AND ICONST_DATE_PERIOD_END = ").Append(rdrR011_PED.GetNumber("X_PREV_PED"));
            rdrF050_DOC_REVENUE_MSTR_HISTORY.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
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
            strSQL.Append("DEPT_NBR = ").Append(rdrF050_DOC_REVENUE_MSTR_HISTORY.GetNumber("DOCREV_DEPT"));
            rdrF070_DEPT_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(String.Empty);
            // TODO: CHOOSE Statement - May require manual changes.
            return strChoose.ToString().ToString();
        }

        private decimal X_SVC_MTD_IN()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR_HISTORY.GetString("DOCREV_LOCATION")) != "MISC"))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR_HISTORY.GetNumber("DOCREV_MTD_IN_SVC");
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
                if ((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR_HISTORY.GetString("DOCREV_LOCATION")) != "MISC"))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR_HISTORY.GetNumber("DOCREV_MTD_OUT_SVC");
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
                if ((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR_HISTORY.GetString("DOCREV_LOCATION")) != "MISC"))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR_HISTORY.GetNumber("DOCREV_MTD_IN_REC");
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
                if ((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR_HISTORY.GetString("DOCREV_LOCATION")) != "MISC"))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR_HISTORY.GetNumber("DOCREV_MTD_OUT_REC");
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
                if ((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR_HISTORY.GetString("DOCREV_LOCATION")) == "MISC"))
                {
                    decReturnValue = (rdrF050_DOC_REVENUE_MSTR_HISTORY.GetNumber("DOCREV_MTD_IN_SVC") + rdrF050_DOC_REVENUE_MSTR_HISTORY.GetNumber("DOCREV_MTD_OUT_SVC"));
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
                if ((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR_HISTORY.GetString("DOCREV_LOCATION")) == "MISC"))
                {
                    decReturnValue = (rdrF050_DOC_REVENUE_MSTR_HISTORY.GetNumber("DOCREV_MTD_IN_REC") + rdrF050_DOC_REVENUE_MSTR_HISTORY.GetNumber("DOCREV_MTD_OUT_REC"));
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
                if ((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR_HISTORY.GetString("DOCREV_LOCATION")) != "MISC"))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR_HISTORY.GetNumber("DOCREV_YTD_IN_SVC");
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
                if ((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR_HISTORY.GetString("DOCREV_LOCATION")) != "MISC"))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR_HISTORY.GetNumber("DOCREV_YTD_OUT_SVC");
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
                if ((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR_HISTORY.GetString("DOCREV_LOCATION")) != "MISC"))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR_HISTORY.GetNumber("DOCREV_YTD_IN_REC");
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
                if ((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR_HISTORY.GetString("DOCREV_LOCATION")) != "MISC"))
                {
                    decReturnValue = rdrF050_DOC_REVENUE_MSTR_HISTORY.GetNumber("DOCREV_YTD_OUT_REC");
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
                if ((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR_HISTORY.GetString("DOCREV_LOCATION")) == "MISC"))
                {
                    decReturnValue = (rdrF050_DOC_REVENUE_MSTR_HISTORY.GetNumber("DOCREV_YTD_IN_SVC") + rdrF050_DOC_REVENUE_MSTR_HISTORY.GetNumber("DOCREV_YTD_OUT_SVC"));
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
                if ((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR_HISTORY.GetString("DOCREV_LOCATION")) == "MISC"))
                {
                    decReturnValue = (rdrF050_DOC_REVENUE_MSTR_HISTORY.GetNumber("DOCREV_YTD_IN_REC") + rdrF050_DOC_REVENUE_MSTR_HISTORY.GetNumber("DOCREV_YTD_OUT_REC"));
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
                decReturnValue = X_SVC_MTD_IN() + X_SVC_MTD_OUT() + X_MISC_SVC_MTD();
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
                decReturnValue = (X_SVC_YTD_IN() + (X_SVC_YTD_OUT() + X_MISC_SVC_YTD()));
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
                decReturnValue = (X_AMT_MTD_IN() + (X_AMT_MTD_OUT() + X_MISC_AMT_MTD()));
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
                decReturnValue = (X_AMT_YTD_IN() + (X_AMT_YTD_OUT() + X_MISC_AMT_YTD()));
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
                AddControl(ReportSection.SUMMARY, "INDEXED.F050_DOC_REVENUE_MSTR_HISTORY.DOCREV_CLINIC_1_2", DataTypes.Character, 2);
                AddControl(ReportSection.SUMMARY, "INDEXED.F050_DOC_REVENUE_MSTR_HISTORY.DOCREV_DEPT", DataTypes.Numeric, 2);
                AddControl(ReportSection.SUMMARY, "INDEXED.F070_DEPT_MSTR.DEPT_COMPANY", DataTypes.Numeric, 2);
                AddControl(ReportSection.SUMMARY, "X_SVC_MTD_IN", DataTypes.Numeric, 6, SummaryType.SUBTOTAL);
                AddControl(ReportSection.SUMMARY, "X_AMT_MTD_IN", DataTypes.Numeric, 9, SummaryType.SUBTOTAL);
                AddControl(ReportSection.SUMMARY, "X_SVC_MTD_OUT", DataTypes.Numeric, 6, SummaryType.SUBTOTAL);
                AddControl(ReportSection.SUMMARY, "X_AMT_MTD_OUT", DataTypes.Numeric, 9, SummaryType.SUBTOTAL);
                AddControl(ReportSection.SUMMARY, "X_MISC_SVC_MTD", DataTypes.Numeric, 6, SummaryType.SUBTOTAL);
                AddControl(ReportSection.SUMMARY, "X_MISC_AMT_MTD", DataTypes.Numeric, 9, SummaryType.SUBTOTAL);
                AddControl(ReportSection.SUMMARY, "X_SVC_TOTAL_MTD", DataTypes.Numeric, 6, SummaryType.SUBTOTAL);
                AddControl(ReportSection.SUMMARY, "X_AMT_TOTAL_MTD", DataTypes.Numeric, 9, SummaryType.SUBTOTAL);
                AddControl(ReportSection.SUMMARY, "X_SVC_YTD_IN", DataTypes.Numeric, 6, SummaryType.SUBTOTAL);
                AddControl(ReportSection.SUMMARY, "X_AMT_YTD_IN", DataTypes.Numeric, 10, SummaryType.SUBTOTAL);
                AddControl(ReportSection.SUMMARY, "X_SVC_YTD_OUT", DataTypes.Numeric, 6, SummaryType.SUBTOTAL);
                AddControl(ReportSection.SUMMARY, "X_AMT_YTD_OUT", DataTypes.Numeric, 10, SummaryType.SUBTOTAL);
                AddControl(ReportSection.SUMMARY, "X_MISC_SVC_YTD", DataTypes.Numeric, 6, SummaryType.SUBTOTAL);
                AddControl(ReportSection.SUMMARY, "X_MISC_AMT_YTD", DataTypes.Numeric, 10, SummaryType.SUBTOTAL);
                AddControl(ReportSection.SUMMARY, "X_SVC_TOTAL_YTD", DataTypes.Numeric, 6, SummaryType.SUBTOTAL);
                AddControl(ReportSection.SUMMARY, "X_AMT_TOTAL_YTD", DataTypes.Numeric, 10, SummaryType.SUBTOTAL);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-11-20 2:09:51 PM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            // TODO: Remove duplicate controls, if there are any.
            switch (strControl)
            {
                case "INDEXED.F050_DOC_REVENUE_MSTR_HISTORY.DOCREV_CLINIC_1_2":
                    return Common.StringToField(rdrF050_DOC_REVENUE_MSTR_HISTORY.GetString("DOCREV_CLINIC_1_2"));
                case "INDEXED.F050_DOC_REVENUE_MSTR_HISTORY.DOCREV_DEPT":
                    return rdrF050_DOC_REVENUE_MSTR_HISTORY.GetNumber("DOCREV_DEPT").ToString();
                case "INDEXED.F070_DEPT_MSTR.DEPT_COMPANY":
                    return rdrF070_DEPT_MSTR.GetNumber("DEPT_COMPANY").ToString();
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
                default:
                    return String.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                // TODO: Some manual steps maybe required.
                Access_R011_PED();
                while (rdrR011_PED.Read())
                {
                    Link_F050_DOC_REVENUE_MSTR_HISTORY();
                    while (rdrF050_DOC_REVENUE_MSTR_HISTORY.Read())
                    {
                        Link_F070_DEPT_MSTR();
                        while (rdrF070_DEPT_MSTR.Read())
                        {
                            WriteData();
                        }

                        rdrF070_DEPT_MSTR.Close();
                    }

                    rdrF050_DOC_REVENUE_MSTR_HISTORY.Close();
                }

                rdrR011_PED.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrR011_PED == null))
            {
                rdrR011_PED.Close();
                rdrR011_PED = null;
            }

            if (!(rdrF050_DOC_REVENUE_MSTR_HISTORY == null))
            {
                rdrF050_DOC_REVENUE_MSTR_HISTORY.Close();
                rdrF050_DOC_REVENUE_MSTR_HISTORY = null;
            }

            if (!(rdrF070_DEPT_MSTR == null))
            {
                rdrF070_DEPT_MSTR.Close();
                rdrF070_DEPT_MSTR = null;
            }
        }
    }
}
