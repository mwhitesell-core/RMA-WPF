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
    public class R011C_CSV : BaseRDLClass
    {
        protected const string REPORT_NAME = "R011C_CSV";
        protected const bool REPORT_HAS_PARAMETERS = false;
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
                Sort = "";
                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return ReportData;
        }
        private void Access_R011A_CSV()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: If * is not used to select all columns, ensure the necessary columns (i.e. columns that are used to access records of other tables) are included in the SELECT statement
            strSQL.Append("SELECT ");
            strSQL.Append("X_AMT_MTD_IN, ");
            strSQL.Append("X_AMT_MTD_OUT, ");
            strSQL.Append("X_MISC_AMT_MTD, ");
            strSQL.Append("X_AMT_TOTAL_MTD, ");
            strSQL.Append("X_AMT_YTD_IN, ");
            strSQL.Append("X_AMT_YTD_OUT, ");
            strSQL.Append("X_MISC_AMT_YTD, ");
            strSQL.Append("X_AMT_TOTAL_YTD, ");
            strSQL.Append("DOCREV_CLINIC_1_2, ");
            strSQL.Append("DOCREV_DEPT, ");
            strSQL.Append("DEPT_COMPANY, ");
            strSQL.Append("X_SVC_MTD_IN, ");
            strSQL.Append("X_SVC_MTD_OUT, ");
            strSQL.Append("X_MISC_SVC_MTD, ");
            strSQL.Append("X_SVC_TOTAL_MTD, ");
            strSQL.Append("X_SVC_YTD_IN, ");
            strSQL.Append("X_SVC_YTD_OUT, ");
            strSQL.Append("X_MISC_SVC_YTD, ");
            strSQL.Append("X_SVC_TOTAL_YTD ");
            strSQL.Append("FROM TEMPORARYDATA.R011A_CSV ");
            strSQL.Append(Choose());
            rdrR011A_CSV.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
            strSQL = null;
        }

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(String.Empty);
            // TODO: CHOOSE Statement - May require manual changes.
            return strChoose.ToString().ToString();
        }

        private string X_DELIMITER()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = "~";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
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

        private string X_AMT_MTD_IN_SIGN()
        {
            string strReturnValue = String.Empty;
            try
            {
                if ((QDesign.NULL(rdrR011A_CSV.GetNumber("X_AMT_MTD_IN")) < QDesign.NULL(0d)))
                {
                    strReturnValue = "-";
                }
                else
                {
                    strReturnValue = " ";
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        //  TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:
        private decimal X_AMT_MTD_IN_DOLLARS()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrR011A_CSV.GetNumber("X_AMT_MTD_IN")) != QDesign.NULL(0d)))
                {
                    decReturnValue = (Math.Abs(rdrR011A_CSV.GetNumber("X_AMT_MTD_IN")) / 100);
                }
                else
                {
                    decReturnValue = 0;
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_AMT_MTD_IN_CENTS()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrR011A_CSV.GetNumber("X_AMT_MTD_IN")) != QDesign.NULL(0d)))
                {
                    decReturnValue = QDesign.PHMod(Math.Abs(rdrR011A_CSV.GetNumber("X_AMT_MTD_IN")), 100);
                }
                else
                {
                    decReturnValue = 0;
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private string X_AMT_MTD_OUT_SIGN()
        {
            string strReturnValue = String.Empty;
            try
            {
                if ((QDesign.NULL(rdrR011A_CSV.GetNumber("X_AMT_MTD_OUT")) < QDesign.NULL(0d)))
                {
                    strReturnValue = "-";
                }
                else
                {
                    strReturnValue = " ";
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        //  TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:
        private decimal X_AMT_MTD_OUT_DOLLARS()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrR011A_CSV.GetNumber("X_AMT_MTD_OUT")) != QDesign.NULL(0d)))
                {
                    decReturnValue = (Math.Abs(rdrR011A_CSV.GetNumber("X_AMT_MTD_OUT")) / 100);
                }
                else
                {
                    decReturnValue = 0;
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_AMT_MTD_OUT_CENTS()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrR011A_CSV.GetNumber("X_AMT_MTD_OUT")) != QDesign.NULL(0d)))
                {
                    decReturnValue = QDesign.PHMod(Math.Abs(rdrR011A_CSV.GetNumber("X_AMT_MTD_OUT")), 100);
                }
                else
                {
                    decReturnValue = 0;
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private string X_MISC_AMT_MTD_SIGN()
        {
            string strReturnValue = String.Empty;
            try
            {
                if ((QDesign.NULL(rdrR011A_CSV.GetNumber("X_MISC_AMT_MTD")) < QDesign.NULL(0d)))
                {
                    strReturnValue = "-";
                }
                else
                {
                    strReturnValue = " ";
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        //  TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:
        private decimal X_MISC_AMT_MTD_DOLLARS()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrR011A_CSV.GetNumber("X_MISC_AMT_MTD")) != QDesign.NULL(0d)))
                {
                    decReturnValue = (Math.Abs(rdrR011A_CSV.GetNumber("X_MISC_AMT_MTD")) / 100);
                }
                else
                {
                    decReturnValue = 0;
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_MISC_AMT_MTD_CENTS()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrR011A_CSV.GetNumber("X_MISC_AMT_MTD")) != QDesign.NULL(0d)))
                {
                    decReturnValue = QDesign.PHMod(Math.Abs(rdrR011A_CSV.GetNumber("X_MISC_AMT_MTD")), 100);
                }
                else
                {
                    decReturnValue = 0;
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private string X_AMT_TOTAL_MTD_SIGN()
        {
            string strReturnValue = String.Empty;
            try
            {
                if ((QDesign.NULL(rdrR011A_CSV.GetNumber("X_AMT_TOTAL_MTD")) < QDesign.NULL(0d)))
                {
                    strReturnValue = "-";
                }
                else
                {
                    strReturnValue = " ";
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        //  TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:
        private decimal X_AMT_TOTAL_MTD_DOLLARS()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrR011A_CSV.GetNumber("X_AMT_TOTAL_MTD")) != QDesign.NULL(0d)))
                {
                    decReturnValue = (Math.Abs(rdrR011A_CSV.GetNumber("X_AMT_TOTAL_MTD")) / 100);
                }
                else
                {
                    decReturnValue = 0;
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_AMT_TOTAL_MTD_CENTS()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrR011A_CSV.GetNumber("X_AMT_TOTAL_MTD")) != QDesign.NULL(0d)))
                {
                    decReturnValue = QDesign.PHMod(Math.Abs(rdrR011A_CSV.GetNumber("X_AMT_TOTAL_MTD")), 100);
                }
                else
                {
                    decReturnValue = 0;
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private string X_AMT_YTD_IN_SIGN()
        {
            string strReturnValue = String.Empty;
            try
            {
                if ((QDesign.NULL(rdrR011A_CSV.GetNumber("X_AMT_YTD_IN")) < QDesign.NULL(0d)))
                {
                    strReturnValue = "-";
                }
                else
                {
                    strReturnValue = " ";
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        //  TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:
        private decimal X_AMT_YTD_IN_DOLLARS()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrR011A_CSV.GetNumber("X_AMT_YTD_IN")) != QDesign.NULL(0d)))
                {
                    decReturnValue = (Math.Abs(rdrR011A_CSV.GetNumber("X_AMT_YTD_IN")) / 100);
                }
                else
                {
                    decReturnValue = 0;
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_AMT_YTD_IN_CENTS()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrR011A_CSV.GetNumber("X_AMT_YTD_IN")) != QDesign.NULL(0d)))
                {
                    decReturnValue = QDesign.PHMod(Math.Abs(rdrR011A_CSV.GetNumber("X_AMT_YTD_IN")), 100);
                }
                else
                {
                    decReturnValue = 0;
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private string X_AMT_YTD_OUT_SIGN()
        {
            string strReturnValue = String.Empty;
            try
            {
                if ((QDesign.NULL(rdrR011A_CSV.GetNumber("X_AMT_YTD_OUT")) < QDesign.NULL(0d)))
                {
                    strReturnValue = "-";
                }
                else
                {
                    strReturnValue = " ";
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        //  TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:
        private decimal X_AMT_YTD_OUT_DOLLARS()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrR011A_CSV.GetNumber("X_AMT_YTD_OUT")) != QDesign.NULL(0d)))
                {
                    decReturnValue = (Math.Abs(rdrR011A_CSV.GetNumber("X_AMT_YTD_OUT")) / 100);
                }
                else
                {
                    decReturnValue = 0;
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_AMT_YTD_OUT_CENTS()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrR011A_CSV.GetNumber("X_AMT_YTD_OUT")) != QDesign.NULL(0d)))
                {
                    decReturnValue = QDesign.PHMod(Math.Abs(rdrR011A_CSV.GetNumber("X_AMT_YTD_OUT")), 100);
                }
                else
                {
                    decReturnValue = 0;
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private string X_MISC_AMT_YTD_SIGN()
        {
            string strReturnValue = String.Empty;
            try
            {
                if ((QDesign.NULL(rdrR011A_CSV.GetNumber("X_MISC_AMT_YTD")) < QDesign.NULL(0d)))
                {
                    strReturnValue = "-";
                }
                else
                {
                    strReturnValue = " ";
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        //  TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:
        private decimal X_MISC_AMT_YTD_DOLLARS()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrR011A_CSV.GetNumber("X_MISC_AMT_YTD")) != QDesign.NULL(0d)))
                {
                    decReturnValue = (Math.Abs(rdrR011A_CSV.GetNumber("X_MISC_AMT_YTD")) / 100);
                }
                else
                {
                    decReturnValue = 0;
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_MISC_AMT_YTD_CENTS()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrR011A_CSV.GetNumber("X_MISC_AMT_YTD")) != QDesign.NULL(0d)))
                {
                    decReturnValue = QDesign.PHMod(Math.Abs(rdrR011A_CSV.GetNumber("X_MISC_AMT_YTD")), 100);
                }
                else
                {
                    decReturnValue = 0;
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private string X_AMT_TOTAL_YTD_SIGN()
        {
            string strReturnValue = String.Empty;
            try
            {
                if ((QDesign.NULL(rdrR011A_CSV.GetNumber("X_AMT_TOTAL_YTD")) < QDesign.NULL(0d)))
                {
                    strReturnValue = "-";
                }
                else
                {
                    strReturnValue = " ";
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        //  TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:
        private decimal X_AMT_TOTAL_YTD_DOLLARS()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrR011A_CSV.GetNumber("X_AMT_TOTAL_YTD")) != QDesign.NULL(0d)))
                {
                    decReturnValue = (Math.Abs(rdrR011A_CSV.GetNumber("X_AMT_TOTAL_YTD")) / 100);
                }
                else
                {
                    decReturnValue = 0;
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_AMT_TOTAL_YTD_CENTS()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrR011A_CSV.GetNumber("X_AMT_TOTAL_YTD")) != QDesign.NULL(0d)))
                {
                    decReturnValue = QDesign.PHMod(Math.Abs(rdrR011A_CSV.GetNumber("X_AMT_TOTAL_YTD")), 100);
                }
                else
                {
                    decReturnValue = 0;
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private string X_CLINIC()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = ("\"" + (rdrR011A_CSV.GetString("DOCREV_CLINIC_1_2") + "\""));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_DEPT()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = ("\"" + (QDesign.ASCII(rdrR011A_CSV.GetNumber("DOCREV_DEPT"), 2) + "\""));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_COMPANY()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = QDesign.ASCII(rdrR011A_CSV.GetNumber("DEPT_COMPANY"));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_SVC_MTD_IN_ALPHA()
        {
            string strReturnValue = String.Empty;
            try
            {
                if (QDesign.ASCII(rdrR011A_CSV.GetNumber("X_SVC_MTD_IN")).Length < 5)
                {
                    strReturnValue = QDesign.ASCII(rdrR011A_CSV.GetNumber("X_SVC_MTD_IN")) + " ";
                }
                else
                {
                    strReturnValue = QDesign.ASCII(rdrR011A_CSV.GetNumber("X_SVC_MTD_IN"));
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_AMT_MTD_IN_ALPHA()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = QDesign.Pack(QDesign.LeftJustify((X_AMT_MTD_IN_SIGN()
                                    + (QDesign.ASCII(X_AMT_MTD_IN_DOLLARS())
                                    + (X_PERIOD() + QDesign.ASCII(X_AMT_MTD_IN_CENTS(), 2))))).TrimEnd());
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_SVC_MTD_OUT_ALPHA()
        {
            string strReturnValue = String.Empty;
            try
            {
                if (QDesign.ASCII(rdrR011A_CSV.GetNumber("X_SVC_MTD_OUT")).Length < 5)
                {
                    strReturnValue = QDesign.ASCII(rdrR011A_CSV.GetNumber("X_SVC_MTD_OUT")) + " ";
                }
                else
                {
                    strReturnValue = QDesign.ASCII(rdrR011A_CSV.GetNumber("X_SVC_MTD_OUT"));
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_AMT_MTD_OUT_ALPHA()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = QDesign.Pack(QDesign.LeftJustify((X_AMT_MTD_OUT_SIGN()
                                    + (QDesign.ASCII(X_AMT_MTD_OUT_DOLLARS())
                                    + (X_PERIOD() + QDesign.ASCII(X_AMT_MTD_OUT_CENTS(), 2))))).TrimEnd());
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_MISC_SVC_MTD_ALPHA()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = QDesign.Pack(QDesign.ASCII(rdrR011A_CSV.GetNumber("X_MISC_SVC_MTD")));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_MISC_AMT_MTD_ALPHA()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = QDesign.Pack(QDesign.LeftJustify((X_MISC_AMT_MTD_SIGN()
                                    + (QDesign.ASCII(X_MISC_AMT_MTD_DOLLARS())
                                    + (X_PERIOD() + QDesign.ASCII(X_MISC_AMT_MTD_CENTS(), 2))))).TrimEnd());
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_SVC_TOTAL_MTD_ALPHA()
        {
            string strReturnValue = String.Empty;
            try
            {
                if (QDesign.Substring(QDesign.ASCII(rdrR011A_CSV.GetNumber("X_SVC_TOTAL_MTD")), 1, 5).Length < 5)
                {
                    strReturnValue = QDesign.ASCII(rdrR011A_CSV.GetNumber("X_SVC_TOTAL_MTD")) + " ";
                }
                else
                {
                    strReturnValue = QDesign.Substring(QDesign.ASCII(rdrR011A_CSV.GetNumber("X_SVC_TOTAL_MTD")), 1, 5);
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_AMT_TOTAL_MTD_ALPHA()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = QDesign.Pack(QDesign.LeftJustify(X_AMT_TOTAL_MTD_SIGN() + QDesign.ASCII(X_AMT_TOTAL_MTD_DOLLARS()) + X_PERIOD() + QDesign.ASCII(X_AMT_TOTAL_MTD_CENTS(), 2)).TrimEnd());
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_SVC_YTD_IN_ALPHA()
        {
            string strReturnValue = String.Empty;
            try
            {
                if (QDesign.ASCII(rdrR011A_CSV.GetNumber("X_SVC_YTD_IN")).Length < 6)
                {
                    strReturnValue = QDesign.ASCII(rdrR011A_CSV.GetNumber("X_SVC_YTD_IN")) + " ";
                }
                else
                {
                    strReturnValue = QDesign.ASCII(rdrR011A_CSV.GetNumber("X_SVC_YTD_IN"));
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_AMT_YTD_IN_ALPHA()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = QDesign.Pack(QDesign.LeftJustify((X_AMT_YTD_IN_SIGN()
                                    + (QDesign.ASCII(X_AMT_YTD_IN_DOLLARS())
                                    + (X_PERIOD() + QDesign.ASCII(X_AMT_YTD_IN_CENTS(), 2))))).TrimEnd());
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_SVC_YTD_OUT_ALPHA()
        {
            string strReturnValue = String.Empty;
            try
            {
                if (QDesign.ASCII(rdrR011A_CSV.GetNumber("X_SVC_YTD_OUT")).Length < 6)
                {
                    strReturnValue = QDesign.ASCII(rdrR011A_CSV.GetNumber("X_SVC_YTD_OUT")) + " ";
                }
                else
                {
                    strReturnValue = QDesign.ASCII(rdrR011A_CSV.GetNumber("X_SVC_YTD_OUT"));
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_AMT_YTD_OUT_ALPHA()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = QDesign.Pack(QDesign.LeftJustify((X_AMT_YTD_OUT_SIGN()
                                    + (QDesign.ASCII(X_AMT_YTD_OUT_DOLLARS())
                                    + (X_PERIOD() + QDesign.ASCII(X_AMT_YTD_OUT_CENTS(), 2))))).TrimEnd());
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_MISC_SVC_YTD_ALPHA()
        {
            string strReturnValue = String.Empty;
            try
            {
                if (QDesign.ASCII(rdrR011A_CSV.GetNumber("X_MISC_SVC_YTD")).Length < 6)
                {
                    strReturnValue = QDesign.ASCII(rdrR011A_CSV.GetNumber("X_MISC_SVC_YTD")) + " ";
                }
                else
                {
                    strReturnValue = QDesign.ASCII(rdrR011A_CSV.GetNumber("X_MISC_SVC_YTD"));
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_MISC_AMT_YTD_ALPHA()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = QDesign.Pack(QDesign.LeftJustify((X_MISC_AMT_YTD_SIGN()
                                    + (QDesign.ASCII(X_MISC_AMT_YTD_DOLLARS())
                                    + (X_PERIOD() + QDesign.ASCII(X_MISC_AMT_YTD_CENTS(), 2))))).TrimEnd());
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_SVC_TOTAL_YTD_ALPHA()
        {
            string strReturnValue = String.Empty;
            try
            {
                if (QDesign.ASCII(rdrR011A_CSV.GetNumber("X_SVC_TOTAL_YTD")).Length < 6)
                {
                    strReturnValue = QDesign.ASCII(rdrR011A_CSV.GetNumber("X_SVC_TOTAL_YTD")) + " ";
                }
                else
                {
                    strReturnValue = QDesign.ASCII(rdrR011A_CSV.GetNumber("X_SVC_TOTAL_YTD"));
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_AMT_TOTAL_YTD_ALPHA()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = QDesign.Pack(QDesign.LeftJustify((X_AMT_TOTAL_YTD_SIGN()
                                    + (QDesign.ASCII(X_AMT_TOTAL_YTD_DOLLARS())
                                    + (X_PERIOD() + QDesign.ASCII(X_AMT_TOTAL_YTD_CENTS(), 2))))).TrimEnd());
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_LINE()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = QDesign.LeftJustify(QDesign.Pack(X_CLINIC() + X_DELIMITER() + X_DEPT() + X_DELIMITER() + X_COMPANY() + X_DELIMITER() + X_SVC_MTD_IN_ALPHA() + X_DELIMITER() + X_AMT_MTD_IN_ALPHA() + " " + X_DELIMITER() + X_SVC_MTD_OUT_ALPHA() + X_DELIMITER() + X_AMT_MTD_OUT_ALPHA() + " " + X_DELIMITER() + X_MISC_SVC_MTD_ALPHA() + " " + X_DELIMITER() + X_MISC_AMT_MTD_ALPHA() + " " + X_DELIMITER() + X_SVC_TOTAL_MTD_ALPHA() + X_DELIMITER() + X_AMT_TOTAL_MTD_ALPHA() + " " + X_DELIMITER() + X_SVC_YTD_IN_ALPHA() + X_DELIMITER() + X_AMT_YTD_IN_ALPHA() + " " + X_DELIMITER() + X_SVC_YTD_OUT_ALPHA() + X_DELIMITER() + X_AMT_YTD_OUT_ALPHA() + " " + X_DELIMITER() + X_MISC_SVC_YTD_ALPHA() + X_DELIMITER() + X_MISC_AMT_YTD_ALPHA() + " " + X_DELIMITER() + X_SVC_TOTAL_YTD_ALPHA() + X_DELIMITER() + X_AMT_TOTAL_YTD_ALPHA()));
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
                AddControl(ReportSection.INITIAL_HEADING, "X_DELIMITER", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "X_LINE", DataTypes.Character, 220);
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
                case "X_DELIMITER":
                    return Common.StringToField(X_DELIMITER(), intSize);
                case "X_LINE":
                    return Common.StringToField(X_LINE(), intSize);
                default:
                    return String.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                // TODO: Some manual steps maybe required.
                Access_R011A_CSV();
                while (rdrR011A_CSV.Read())
                {
                    WriteData();
                }

                rdrR011A_CSV.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrR011A_CSV == null))
            {
                rdrR011A_CSV.Close();
                rdrR011A_CSV = null;
            }
        }
    }
}
