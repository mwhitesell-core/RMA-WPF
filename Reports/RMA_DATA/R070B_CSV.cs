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
    public class R070B_CSV : BaseRDLClass
    {
        protected const string REPORT_NAME = "R070_CSV";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrR070A_CSV = new Reader();
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
        private void Access_R070A_CSV()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: If * is not used to select all columns, ensure the necessary columns (i.e. columns that are used to access records of other tables) are included in the SELECT statement
            strSQL.Append("SELECT ");
            strSQL.Append("CLMHDR_TOT_CLAIM_AR_OHIP, ");
            strSQL.Append("CLMHDR_MANUAL_AND_TAPE_PAYMENTS, ");
            strSQL.Append("X_BALANCE_DUE, ");
            strSQL.Append("X_SORT_RECORD_STATUS, ");
            strSQL.Append("X_CLM_ID, ");
            strSQL.Append("CLMHDR_AGENT_CD, ");
            strSQL.Append("ICONST_CLINIC_NBR_1_2, ");
            strSQL.Append("CLMHDR_DOC_DEPT, ");
            strSQL.Append("CLMHDR_STATUS_OHIP, ");
            strSQL.Append("X_SUB_NBR, ");
            strSQL.Append("DEPT_COMPANY, ");
            strSQL.Append("CLMHDR_PAT_ACRONYM, ");
            strSQL.Append("X_PAT_ID_INFO, ");
            strSQL.Append("CLMHDR_DATE_PERIOD_END, ");
            strSQL.Append("CLMHDR_SERV_DATE, ");
            strSQL.Append("X_DAY_OLD, ");
            strSQL.Append("CLMHDR_TAPE_SUBMIT_IND, ");
            strSQL.Append("CLMHDR_REFERENCE, ");
            strSQL.Append("X_INCL_PAYROLL ");
            strSQL.Append("FROM TEMPORARYDATA.R070A_CSV ");
            strSQL.Append(Choose());
            rdrR070A_CSV.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
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

        private string X_OHIP_FEE_SIGN()
        {
            string strReturnValue = String.Empty;
            try
            {
                if ((QDesign.NULL(rdrR070A_CSV.GetNumber("CLMHDR_TOT_CLAIM_AR_OHIP")) < QDesign.NULL(0d)))
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
        private decimal X_OHIP_FEE_DOLLARS()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrR070A_CSV.GetNumber("CLMHDR_TOT_CLAIM_AR_OHIP")) != QDesign.NULL(0d)))
                {
                    decReturnValue = (Math.Abs(rdrR070A_CSV.GetNumber("CLMHDR_TOT_CLAIM_AR_OHIP")) / 100);
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

        private decimal X_OHIP_FEE_CENTS()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrR070A_CSV.GetNumber("CLMHDR_TOT_CLAIM_AR_OHIP")) != QDesign.NULL(0d)))
                {
                    decReturnValue = QDesign.PHMod(Math.Abs(rdrR070A_CSV.GetNumber("CLMHDR_TOT_CLAIM_AR_OHIP")), 100);
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

        private string X_OHIP_FEE_ALPHA()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = QDesign.Pack(QDesign.LeftJustify(X_OHIP_FEE_SIGN() + QDesign.ASCII(X_OHIP_FEE_DOLLARS()) + X_PERIOD() + QDesign.ASCII(X_OHIP_FEE_CENTS(), 2)).TrimEnd()) + " ";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_PAID_AMT_SIGN()
        {
            string strReturnValue = String.Empty;
            try
            {
                if ((rdrR070A_CSV.GetNumber("CLMHDR_MANUAL_AND_TAPE_PAYMENTS") <= 0))
                {
                    strReturnValue = " ";
                }
                else
                {
                    strReturnValue = "-";
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
        private decimal X_PAID_AMT_DOLLARS()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrR070A_CSV.GetNumber("CLMHDR_MANUAL_AND_TAPE_PAYMENTS")) != QDesign.NULL(0d)))
                {
                    decReturnValue = (Math.Abs(rdrR070A_CSV.GetNumber("CLMHDR_MANUAL_AND_TAPE_PAYMENTS")) / 100);
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

        private decimal X_PAID_AMT_CENTS()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrR070A_CSV.GetNumber("CLMHDR_MANUAL_AND_TAPE_PAYMENTS")) != QDesign.NULL(0d)))
                {
                    decReturnValue = QDesign.PHMod(Math.Abs(rdrR070A_CSV.GetNumber("CLMHDR_MANUAL_AND_TAPE_PAYMENTS")), 100);
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

        private string X_PAID_AMT_ALPHA()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = QDesign.Pack(QDesign.LeftJustify(X_PAID_AMT_SIGN() + QDesign.ASCII(X_PAID_AMT_DOLLARS()) + X_PERIOD() + QDesign.ASCII(X_PAID_AMT_CENTS(), 2)).TrimEnd()) + " ";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_BALANCE_DUE_SIGN()
        {
            string strReturnValue = String.Empty;
            try
            {
                if ((QDesign.NULL(rdrR070A_CSV.GetNumber("X_BALANCE_DUE")) < QDesign.NULL(0d)))
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
        private decimal X_BALANCE_DUE_DOLLARS()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrR070A_CSV.GetNumber("X_BALANCE_DUE")) != QDesign.NULL(0d)))
                {
                    decReturnValue = (Math.Abs(rdrR070A_CSV.GetNumber("X_BALANCE_DUE")) / 100);
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

        private decimal X_BALANCE_DUE_CENTS()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrR070A_CSV.GetNumber("X_BALANCE_DUE")) != QDesign.NULL(0d)))
                {
                    decReturnValue = QDesign.PHMod(Math.Abs(rdrR070A_CSV.GetNumber("X_BALANCE_DUE")), 100);
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

        private string X_BALANCE_DUE_ALPHA()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = QDesign.Pack(QDesign.LeftJustify(X_BALANCE_DUE_SIGN() + QDesign.ASCII(X_BALANCE_DUE_DOLLARS()) + X_PERIOD() + QDesign.ASCII(X_BALANCE_DUE_CENTS(), 2)).TrimEnd()) + " ";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_RECORD_STATUS()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = "\"" + rdrR070A_CSV.GetString("X_SORT_RECORD_STATUS").PadRight(1, ' ') + "\"";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_DOC_NBR()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = "\"" + QDesign.Substring(rdrR070A_CSV.GetString("X_CLM_ID"), 3, 3) + "\"";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_AGENT_CD()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = "\"" + QDesign.ASCII(rdrR070A_CSV.GetNumber("CLMHDR_AGENT_CD"), 1) + "\"";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_CLINIC()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = QDesign.ASCII(rdrR070A_CSV.GetNumber("ICONST_CLINIC_NBR_1_2"), 2);
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
                strReturnValue = "\"" + QDesign.ASCII(rdrR070A_CSV.GetNumber("CLMHDR_DOC_DEPT"), 2) + "\"";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_EXPLAN_CD()
        {
            string strReturnValue = String.Empty;
            try
            {
                if ((QDesign.NULL(rdrR070A_CSV.GetString("CLMHDR_STATUS_OHIP")) != "00"))
                {
                    strReturnValue = rdrR070A_CSV.GetString("CLMHDR_STATUS_OHIP");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_SUBDIVISION()
        {
            string strReturnValue = String.Empty;
            try
            {
                if ((QDesign.NULL(rdrR070A_CSV.GetNumber("X_SUB_NBR")) != QDesign.NULL(0d)))
                {
                    strReturnValue = QDesign.ASCII(rdrR070A_CSV.GetNumber("X_SUB_NBR")).PadRight(1, ' ');
                }
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
                strReturnValue = X_RECORD_STATUS() + X_DELIMITER() + X_DOC_NBR() + X_DELIMITER() + X_CLINIC() + X_DELIMITER() + X_AGENT_CD() + X_DELIMITER() + QDesign.ASCII(rdrR070A_CSV.GetNumber("DEPT_COMPANY")) + X_DELIMITER() + rdrR070A_CSV.GetString("CLMHDR_PAT_ACRONYM") + X_DELIMITER() + QDesign.LeftJustify(QDesign.Pack(rdrR070A_CSV.GetString("X_PAT_ID_INFO"))) + " " + X_DELIMITER() + rdrR070A_CSV.GetString("X_CLM_ID") + X_DELIMITER() + X_DEPT() + X_DELIMITER() + X_EXPLAN_CD().PadRight(1, ' ') + X_DELIMITER() + X_SUBDIVISION().PadRight(1, ' ') + X_DELIMITER() + X_OHIP_FEE_ALPHA() + X_DELIMITER() + X_PAID_AMT_ALPHA() + X_DELIMITER() + X_BALANCE_DUE_ALPHA() + X_DELIMITER() + QDesign.ASCII(rdrR070A_CSV.GetNumber("CLMHDR_DATE_PERIOD_END")) + X_DELIMITER() + QDesign.ASCII(rdrR070A_CSV.GetNumber("CLMHDR_SERV_DATE")) + X_DELIMITER() + rdrR070A_CSV.GetString("X_DAY_OLD").PadRight(3, ' ') + X_DELIMITER() + rdrR070A_CSV.GetString("CLMHDR_TAPE_SUBMIT_IND").PadRight(1, ' ') + X_DELIMITER() + rdrR070A_CSV.GetString("CLMHDR_REFERENCE") + " " + X_DELIMITER() + rdrR070A_CSV.GetString("X_INCL_PAYROLL");
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_HEAD()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = "Writeoff" + X_DELIMITER() + "Doc#" + X_DELIMITER() + "Clinic" + X_DELIMITER() + "Agent" + X_DELIMITER() + "Company" + X_DELIMITER() + "Acronym" + X_DELIMITER() + "Pat Id" + X_DELIMITER() + "Claim Id" + X_DELIMITER() + "Dept" + X_DELIMITER() + "Explan Cd" + X_DELIMITER() + "Sub" + X_DELIMITER() + "Ohip Amt" + X_DELIMITER() + "Paid Amt" + X_DELIMITER() + "Balance" + X_DELIMITER() + "Period End Date" + X_DELIMITER() + "Service Date" + X_DELIMITER() + "Days Old" + X_DELIMITER() + "Tape Sub" + X_DELIMITER() + "Action Taken" + X_DELIMITER() + "Include Payroll";
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
                AddControl(ReportSection.INITIAL_HEADING, "X_HEAD", DataTypes.Character, 180);
                AddControl(ReportSection.REPORT, "X_LINE", DataTypes.Character, 132);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-07-20 11:56:25 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "X_HEAD":
                    return Common.StringToField(X_HEAD(), intSize);
                case "X_LINE":
                    return Common.StringToField(X_LINE(), intSize);
                default:
                    return String.Empty;
            }
        }
        public override void AccessData()
        {
            StreamWriter sw = new StreamWriter(ReportFunctions.m_strFlatFilePath + "\\r070_csv.txt");
            sw.WriteLine(X_HEAD());
            //sw.Flush();

            try
            {
                Access_R070A_CSV();
                while (rdrR070A_CSV.Read())
                {
                    sw.WriteLine(X_LINE());
                    sw.Flush();
                    //WriteData();
                }
                rdrR070A_CSV.Close();

                sw.Flush();
                sw.Close();
                sw.Dispose();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
                sw.Close();
                sw.Dispose();
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrR070A_CSV == null))
            {
                rdrR070A_CSV.Close();
                rdrR070A_CSV = null;
            }
        }
    }
}
