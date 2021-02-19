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
    public class DOCREV : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "DOCREV";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrF050_DOC_REVENUE_MSTR = new Reader();

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
                Sort = "X_DOC ASC";
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

        private void Access_F050_DOC_REVENUE_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOCREV_CLINIC_1_2, ");
            strSQL.Append("DOCREV_DOC_NBR, ");
            strSQL.Append("DOCREV_LOCATION, ");
            strSQL.Append("DOCREV_MTD_IN_SVC, ");
            strSQL.Append("DOCREV_YTD_IN_SVC, ");
            strSQL.Append("DOCREV_MTD_IN_REC, ");
            strSQL.Append("DOCREV_YTD_IN_REC, ");
            strSQL.Append("DOCREV_MTD_OUT_SVC, ");
            strSQL.Append("DOCREV_YTD_OUT_SVC, ");
            strSQL.Append("DOCREV_MTD_OUT_REC, ");
            strSQL.Append("DOCREV_YTD_OUT_REC ");
            strSQL.Append("FROM INDEXED.F050_DOC_REVENUE_MSTR ");

            strSQL.Append(Choose());

            rdrF050_DOC_REVENUE_MSTR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        #endregion

        #region " CHOOSE "

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(string.Empty);

            return strChoose.ToString();
        }

        #endregion

        #region " SELECT IF "

        #endregion

        #region " DEFINES "

        private string X_DOC()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = (rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_CLINIC_1_2") + rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_DOC_NBR"));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private decimal IN_SVC_MTD()
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

        private decimal IN_SVC_YTD()
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

        private decimal IN_AMT_MTD()
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

        private decimal IN_AMT_YTD()
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

        private decimal OUT_SVC_MTD()
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

        private decimal OUT_SVC_YTD()
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

        private decimal OUT_AMT_MTD()
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

        private decimal OUT_AMT_YTD()
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

        private decimal MISC_SVC_MTD()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")) == "MISC"))
                {
                    decReturnValue = (rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_MTD_OUT_SVC") + rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_MTD_IN_SVC"));
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal MISC_SVC_YTD()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")) == "MISC"))
                {
                    decReturnValue = (rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_YTD_OUT_SVC") + rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_YTD_IN_SVC"));
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal MISC_AMT_MTD()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")) == "MISC"))
                {
                    decReturnValue = (rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_MTD_OUT_REC") + rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_MTD_IN_REC"));
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal MISC_AMT_YTD()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_LOCATION")) == "MISC"))
                {
                    decReturnValue = (rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_YTD_OUT_REC") + rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_YTD_IN_REC"));
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal TOT_SVC_MTD()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = (IN_SVC_MTD()
                            + (OUT_SVC_MTD() + MISC_SVC_MTD()));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal TOT_SVC_YTD()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = (IN_SVC_YTD()
                            + (OUT_SVC_YTD() + MISC_SVC_YTD()));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal TOT_AMT_MTD()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = (IN_AMT_MTD()
                            + (OUT_AMT_MTD() + MISC_AMT_MTD()));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal TOT_AMT_YTD()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = (IN_AMT_YTD()
                            + (OUT_AMT_YTD() + MISC_AMT_YTD()));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_DATE()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = QDesign.SysDate(ref m_cnnQUERY);
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
                AddControl(ReportSection.FOOTING_AT, "X_DOC", DataTypes.Character, 5);
                AddControl(ReportSection.FOOTING_AT, "IN_SVC_MTD", DataTypes.Numeric, 4);
                AddControl(ReportSection.FOOTING_AT, "IN_SVC_YTD", DataTypes.Numeric, 5);
                AddControl(ReportSection.FOOTING_AT, "IN_AMT_MTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "IN_AMT_YTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "OUT_SVC_MTD", DataTypes.Numeric, 4);
                AddControl(ReportSection.FOOTING_AT, "OUT_SVC_YTD", DataTypes.Numeric, 5);
                AddControl(ReportSection.FOOTING_AT, "OUT_AMT_MTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "OUT_AMT_YTD", DataTypes.Numeric, 9);
                AddControl(ReportSection.FOOTING_AT, "MISC_SVC_MTD", DataTypes.Numeric, 4);
                AddControl(ReportSection.FOOTING_AT, "MISC_SVC_YTD", DataTypes.Numeric, 5);
                AddControl(ReportSection.FOOTING_AT, "MISC_AMT_MTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "MISC_AMT_YTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "TOT_SVC_MTD", DataTypes.Numeric, 4);
                AddControl(ReportSection.FOOTING_AT, "TOT_SVC_YTD", DataTypes.Numeric, 5);
                AddControl(ReportSection.FOOTING_AT, "TOT_AMT_MTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "TOT_AMT_YTD", DataTypes.Numeric, 9);
                AddControl(ReportSection.FOOTING_AT, "X_DATE", DataTypes.Numeric, 8);
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
        // # Do not delete, modify or move it.  Updated: 2018-05-09 9:52:34 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "X_DOC":
                    return Common.StringToField(X_DOC(), intSize);

                case "IN_SVC_MTD":
                    return IN_SVC_MTD().ToString();

                case "IN_SVC_YTD":
                    return IN_SVC_YTD().ToString();

                case "IN_AMT_MTD":
                    return IN_AMT_MTD().ToString();

                case "IN_AMT_YTD":
                    return IN_AMT_YTD().ToString();

                case "OUT_SVC_MTD":
                    return OUT_SVC_MTD().ToString();

                case "OUT_SVC_YTD":
                    return OUT_SVC_YTD().ToString();

                case "OUT_AMT_MTD":
                    return OUT_AMT_MTD().ToString();

                case "OUT_AMT_YTD":
                    return OUT_AMT_YTD().ToString();

                case "MISC_SVC_MTD":
                    return MISC_SVC_MTD().ToString();

                case "MISC_SVC_YTD":
                    return MISC_SVC_YTD().ToString();

                case "MISC_AMT_MTD":
                    return MISC_AMT_MTD().ToString();

                case "MISC_AMT_YTD":
                    return MISC_AMT_YTD().ToString();

                case "TOT_SVC_MTD":
                    return TOT_SVC_MTD().ToString();

                case "TOT_SVC_YTD":
                    return TOT_SVC_YTD().ToString();

                case "TOT_AMT_MTD":
                    return TOT_AMT_MTD().ToString();

                case "TOT_AMT_YTD":
                    return TOT_AMT_YTD().ToString();

                case "X_DATE":
                    return X_DATE().ToString();

                default:
                    return string.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                Access_F050_DOC_REVENUE_MSTR();
                while (rdrF050_DOC_REVENUE_MSTR.Read())
                {
                    WriteData();
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
        }

        #endregion

        #endregion
    }
}
