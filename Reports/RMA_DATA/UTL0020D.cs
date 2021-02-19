#region "Screen Comments"

// Program utl0020d.qzs
// Purpose:
// Dump `constants master stuff` into an ascii text file for download
// to the PC 
// 2003/oct/14 B.E. -original
// 2004/jan/24 b.e. - process changed to use current-ep-nbr minus 1 since now
// run after PED is rolled over
// ----------------------------------

#endregion

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
    public class UTL0020D : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "UTL0020D";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrUTL0020A_PARMS = new Reader();
        private Reader rdrICONST_MSTR_REC = new Reader();
        private Reader rdrCONSTANTS_MSTR_REC_7 = new Reader();

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

                Sort = "";

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

        private void Access_UTL0020A_PARMS()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("X_CURRENT_EP_NBR_MINUS_1 ");
            strSQL.Append("FROM TEMPORARYDATA.UTL0020A_PARMS ");

            strSQL.Append(Choose());

            rdrUTL0020A_PARMS.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);

            strSQL = null;
        }

        private void Link_ICONST_MSTR_REC()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("ICONST_DATE_PERIOD_END_1, ");
            strSQL.Append("ICONST_DATE_PERIOD_END_2, ");
            strSQL.Append("ICONST_DATE_PERIOD_END_3, ");
            strSQL.Append("ICONST_DATE_PERIOD_END_4, ");
            strSQL.Append("ICONST_DATE_PERIOD_END_5, ");
            strSQL.Append("ICONST_DATE_PERIOD_END_6, ");
            strSQL.Append("ICONST_DATE_PERIOD_END_7, ");
            strSQL.Append("ICONST_DATE_PERIOD_END_8, ");
            strSQL.Append("ICONST_DATE_PERIOD_END_9, ");
            strSQL.Append("ICONST_DATE_PERIOD_END_10, ");
            strSQL.Append("ICONST_DATE_PERIOD_END_11, ");
            strSQL.Append("ICONST_DATE_PERIOD_END_12, ");
            strSQL.Append("ICONST_DATE_PERIOD_END_13 ");
            strSQL.Append("FROM INDEXED.ICONST_MSTR_REC ");
            strSQL.Append("WHERE ");
            strSQL.Append("ICONST_CLINIC_NBR_1_2 = ").Append(22);

            rdrICONST_MSTR_REC.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

            strSQL = null;
        }

        private void Link_CONSTANTS_MSTR_REC_7()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT * ");
            strSQL.Append("FROM INDEXED.CONSTANTS_MSTR_REC_7 ");
            strSQL.Append("WHERE ");
            strSQL.Append("CONST_REC_NBR = ").Append(7);

            rdrCONSTANTS_MSTR_REC_7.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

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

        private decimal X_KEY2()
        {
            decimal decReturnValue = 0;

            try
            {
                decReturnValue = rdrUTL0020A_PARMS.GetNumber("X_CURRENT_EP_NBR_MINUS_1") / 100;
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private decimal X_EP_YEAR()
        {
            decimal decReturnValue = 0;

            try
            {
                decReturnValue = rdrUTL0020A_PARMS.GetNumber("X_CURRENT_EP_NBR_MINUS_1") / 100;
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private decimal X_EP_MTH()
        {
            decimal decReturnValue = 0;

            try
            {
                decReturnValue = rdrUTL0020A_PARMS.GetNumber("X_CURRENT_EP_NBR_MINUS_1") - (X_EP_YEAR() * 100);
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private string X_ICONST_DATE()
        {
            string strReturnValue = string.Empty;

            try
            {
                if (QDesign.NULL(X_EP_MTH()) == QDesign.NULL(1d))
                {
                    strReturnValue = QDesign.ASCII(rdrICONST_MSTR_REC.GetDate("ICONST_DATE_PERIOD_END_1"), 8);
                }
                else if (QDesign.NULL(X_EP_MTH()) == QDesign.NULL(2d))
                {
                    strReturnValue = QDesign.ASCII(rdrICONST_MSTR_REC.GetDate("ICONST_DATE_PERIOD_END_2"), 8);
                }
                else if (QDesign.NULL(X_EP_MTH()) == QDesign.NULL(3d))
                {
                    strReturnValue = QDesign.ASCII(rdrICONST_MSTR_REC.GetDate("ICONST_DATE_PERIOD_END_3"), 8);
                }
                else if (QDesign.NULL(X_EP_MTH()) == QDesign.NULL(4d))
                {
                    strReturnValue = QDesign.ASCII(rdrICONST_MSTR_REC.GetDate("ICONST_DATE_PERIOD_END_4"), 8);
                }
                else if (QDesign.NULL(X_EP_MTH()) == QDesign.NULL(5d))
                {
                    strReturnValue = QDesign.ASCII(rdrICONST_MSTR_REC.GetDate("ICONST_DATE_PERIOD_END_5"), 8);
                }
                else if (QDesign.NULL(X_EP_MTH()) == QDesign.NULL(6d))
                {
                    strReturnValue = QDesign.ASCII(rdrICONST_MSTR_REC.GetDate("ICONST_DATE_PERIOD_END_6"), 8);
                }
                else if (QDesign.NULL(X_EP_MTH()) == QDesign.NULL(7d))
                {
                    strReturnValue = QDesign.ASCII(rdrICONST_MSTR_REC.GetDate("ICONST_DATE_PERIOD_END_7"), 8);
                }
                else if (QDesign.NULL(X_EP_MTH()) == QDesign.NULL(8d))
                {
                    strReturnValue = QDesign.ASCII(rdrICONST_MSTR_REC.GetDate("ICONST_DATE_PERIOD_END_8"), 8);
                }
                else if (QDesign.NULL(X_EP_MTH()) == QDesign.NULL(9d))
                {
                    strReturnValue = QDesign.ASCII(rdrICONST_MSTR_REC.GetDate("ICONST_DATE_PERIOD_END_9"), 8);
                }
                else if (QDesign.NULL(X_EP_MTH()) == QDesign.NULL(10d))
                {
                    strReturnValue = QDesign.ASCII(rdrICONST_MSTR_REC.GetDate("ICONST_DATE_PERIOD_END_10"), 8);
                }
                else if (QDesign.NULL(X_EP_MTH()) == QDesign.NULL(11d))
                {
                    strReturnValue = QDesign.ASCII(rdrICONST_MSTR_REC.GetDate("ICONST_DATE_PERIOD_END_11"), 8);
                }
                else if (QDesign.NULL(X_EP_MTH()) == QDesign.NULL(12d))
                {
                    strReturnValue = QDesign.ASCII(rdrICONST_MSTR_REC.GetDate("ICONST_DATE_PERIOD_END_12"), 8);
                }
                else if (QDesign.NULL(X_EP_MTH()) == QDesign.NULL(13d))
                {
                    strReturnValue = QDesign.ASCII(rdrICONST_MSTR_REC.GetDate("ICONST_DATE_PERIOD_END_13"), 8);
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_ICONST_DATE_YYYY()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.Substring(X_ICONST_DATE(), 1, 4);
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_ICONST_DATE_MM()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.Substring(X_ICONST_DATE(), 5, 2);
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_ICONST_DATE_DD()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.Substring(X_ICONST_DATE(), 7, 2);
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string DELIMITER()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = "~";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        #endregion

        #region " CONTROLS "

        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.REPORT, "X_ICONST_DATE", DataTypes.Character, 8);
                AddControl(ReportSection.REPORT, "DELIMITER", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "X_ICONST_DATE_YYYY", DataTypes.Character, 4);
                AddControl(ReportSection.REPORT, "X_ICONST_DATE_MM", DataTypes.Character, 2);
                AddControl(ReportSection.REPORT, "X_ICONST_DATE_DD", DataTypes.Character, 2);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.UTL0020A_PARMS.X_CURRENT_EP_NBR_MINUS_1", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "X_EP_YEAR", DataTypes.Numeric, 4);
                AddControl(ReportSection.REPORT, "X_EP_MTH", DataTypes.Numeric, 2);
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
        //# Do not delete, modify or move it.  Updated: 2017-07-24 10:32:28 PM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "X_ICONST_DATE":
                    return Common.StringToField(X_ICONST_DATE(), intSize);

                case "DELIMITER":
                    return Common.StringToField(DELIMITER(), intSize);

                case "X_ICONST_DATE_YYYY":
                    return Common.StringToField(X_ICONST_DATE_YYYY(), intSize);

                case "X_ICONST_DATE_MM":
                    return Common.StringToField(X_ICONST_DATE_MM(), intSize);

                case "X_ICONST_DATE_DD":
                    return Common.StringToField(X_ICONST_DATE_DD(), intSize);

                case "TEMPORARYDATA.UTL0020A_PARMS.X_CURRENT_EP_NBR_MINUS_1":
                    return rdrUTL0020A_PARMS.GetNumber("X_CURRENT_EP_NBR_MINUS_1").ToString();

                case "X_EP_YEAR":
                    return X_EP_YEAR().ToString();

                case "X_EP_MTH":
                    return X_EP_MTH().ToString();

                default:
                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_UTL0020A_PARMS();

                while (rdrUTL0020A_PARMS.Read())
                {
                    Link_ICONST_MSTR_REC();
                    while (rdrICONST_MSTR_REC.Read())
                    {
                        Link_CONSTANTS_MSTR_REC_7();
                        while ((rdrCONSTANTS_MSTR_REC_7.Read()))
                        {
                            WriteData();
                        }
                        rdrCONSTANTS_MSTR_REC_7.Close();
                    }
                    rdrICONST_MSTR_REC.Close();
                }
                rdrUTL0020A_PARMS.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrUTL0020A_PARMS != null))
            {
                rdrUTL0020A_PARMS.Close();
                rdrUTL0020A_PARMS = null;
            }
            if ((rdrICONST_MSTR_REC != null))
            {
                rdrICONST_MSTR_REC.Close();
                rdrICONST_MSTR_REC = null;
            }
            if ((rdrCONSTANTS_MSTR_REC_7 != null))
            {
                rdrCONSTANTS_MSTR_REC_7.Close();
                rdrCONSTANTS_MSTR_REC_7 = null;
            }
        }

        #endregion

        #endregion
    }
}

