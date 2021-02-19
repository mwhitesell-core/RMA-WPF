//  DOC: R005_CSV.QZS
//  DOC: MONTHLY CASH APPLIED RECONCILIATION
//  DOC: SORT BY CLINIC
//  DOC: RUN FOR: Ross  
//  PROGRAM PURPOSE : CASH ANALYSIS BY CLINIC   (DETAIL & SUMMARY REPORTS)
//  DATE           WHO       DESCRIPTION
//  2015/Jun/16 MC   ORIGINAL
//  2015/jun/24 be1   added sort
//  2015/jun/25 MC1   added sort in the summary section as well
//  2015/jul/07 MC2   added a new pass to generate report with final total for all clinics
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
    public class R005A_CSV : BaseRDLClass
    {
        protected const string REPORT_NAME = "R005A_CSV";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrR005_DTL = new Reader();
        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                //  Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;
                Sort = "DOCASH_CLINIC_1_2 ASC, DOCASH_DEPT ASC, DEPT_COMPANY ASC, DOCASH_DOC_NBR ASC";
                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return ReportData;
        }
        private void Access_R005_DTL()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: If * is not used to select all columns, ensure the necessary columns (i.e. columns that are used to access records of other tables) are included in the SELECT statement
            strSQL.Append("SELECT ");
            strSQL.Append("AGENT_MTD_AMT, ");
            strSQL.Append("AGENT_YTD_AMT, ");
            strSQL.Append("DOCASH_CLINIC_1_2, ");
            strSQL.Append("DOCASH_DEPT, ");
            strSQL.Append("DEPT_COMPANY, ");
            strSQL.Append("DOCASH_DOC_NBR, ");
            strSQL.Append("DOCASH_AGENCY_TYPE ");
            strSQL.Append("FROM TEMPORARYDATA.R005_DTL ");
            strSQL.Append(Choose());
            rdrR005_DTL.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
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

        private string X_AMT_MTD_SIGN()
        {
            string strReturnValue = String.Empty;
            try
            {
                if ((QDesign.NULL(rdrR005_DTL.GetNumber("AGENT_MTD_AMT")) < QDesign.NULL(0d)))
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
        private decimal X_AMT_MTD_DOLLARS()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrR005_DTL.GetNumber("AGENT_MTD_AMT")) != QDesign.NULL(0d)))
                {
                    decReturnValue = (Math.Abs(rdrR005_DTL.GetNumber("AGENT_MTD_AMT")) / 100);
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

        private decimal X_AMT_MTD_CENTS()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrR005_DTL.GetNumber("AGENT_MTD_AMT")) != QDesign.NULL(0d)))
                {
                    decReturnValue = QDesign.PHMod(Math.Abs(rdrR005_DTL.GetNumber("AGENT_MTD_AMT")), 100);
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

        private string X_AMT_YTD_SIGN()
        {
            string strReturnValue = String.Empty;
            try
            {
                if ((QDesign.NULL(rdrR005_DTL.GetNumber("AGENT_YTD_AMT")) < QDesign.NULL(0d)))
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
        private decimal X_AMT_YTD_DOLLARS()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrR005_DTL.GetNumber("AGENT_YTD_AMT")) != QDesign.NULL(0d)))
                {
                    decReturnValue = (Math.Abs(rdrR005_DTL.GetNumber("AGENT_YTD_AMT")) / 100);
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

        private decimal X_AMT_YTD_CENTS()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrR005_DTL.GetNumber("AGENT_YTD_AMT")) != QDesign.NULL(0d)))
                {
                    decReturnValue = QDesign.PHMod(Math.Abs(rdrR005_DTL.GetNumber("AGENT_YTD_AMT")), 100);
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
                strReturnValue = ("\""
                            + (rdrR005_DTL.GetString("DOCASH_CLINIC_1_2") + "\""));
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
                strReturnValue = ("\""
                            + (QDesign.ASCII(rdrR005_DTL.GetNumber("DOCASH_DEPT"), 2) + "\""));
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
                strReturnValue = QDesign.ASCII(rdrR005_DTL.GetNumber("DEPT_COMPANY"));
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
                strReturnValue = ("\""
                            + (rdrR005_DTL.GetString("DOCASH_DOC_NBR") + "\""));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_AGENT()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = rdrR005_DTL.GetString("DOCASH_AGENCY_TYPE");
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_AMT_MTD_ALPHA()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = QDesign.Pack(QDesign.LeftJustify((X_AMT_MTD_SIGN()
                                    + (QDesign.ASCII(X_AMT_MTD_DOLLARS())
                                    + (X_PERIOD() + QDesign.ASCII(X_AMT_MTD_CENTS(), 2))))));
                if(strReturnValue.Length < 10)
                {
                    strReturnValue = strReturnValue + " ";
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_AMT_YTD_ALPHA()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = QDesign.Pack(QDesign.LeftJustify((X_AMT_YTD_SIGN()
                                    + (QDesign.ASCII(X_AMT_YTD_DOLLARS())
                                    + (X_PERIOD() + QDesign.ASCII(X_AMT_YTD_CENTS(), 2))))));
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
                strReturnValue = QDesign.LeftJustify(QDesign.Pack(X_CLINIC() + X_DELIMITER() + X_DEPT() + X_DELIMITER() + X_COMPANY() + X_DELIMITER() + X_DOC_NBR() + X_DELIMITER() + X_AGENT() + X_DELIMITER() + X_AMT_MTD_ALPHA() + X_DELIMITER() + X_AMT_YTD_ALPHA()));
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
                AddControl(ReportSection.REPORT, "X_LINE", DataTypes.Character, 50);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R005_DTL.DOCASH_CLINIC_1_2", DataTypes.Character, 2);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R005_DTL.DOCASH_DEPT", DataTypes.Numeric, 3);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R005_DTL.DEPT_COMPANY", DataTypes.Numeric, 3);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R005_DTL.DOCASH_DOC_NBR", DataTypes.Character, 3);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2019-01-29 10:23:46 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            // TODO: Remove duplicate controls, if there are any.
            switch (strControl)
            {
                case "X_DELIMITER":
                    return Common.StringToField(X_DELIMITER(), intSize);
                case "X_LINE":
                    return Common.StringToField(X_LINE(), intSize);
                case "TEMPORARYDATA.R005_DTL.DOCASH_CLINIC_1_2":
                    return Common.StringToField(rdrR005_DTL.GetString("DOCASH_CLINIC_1_2"));
                case "TEMPORARYDATA.R005_DTL.DOCASH_DEPT":
                    return rdrR005_DTL.GetNumber("DOCASH_DEPT").ToString();
                case "TEMPORARYDATA.R005_DTL.DEPT_COMPANY":
                    return rdrR005_DTL.GetNumber("DEPT_COMPANY").ToString();
                case "TEMPORARYDATA.R005_DTL.DOCASH_DOC_NBR":
                    return Common.StringToField(rdrR005_DTL.GetString("DOCASH_DOC_NBR"));
                default:
                    return String.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                // TODO: Some manual steps maybe required.
                Access_R005_DTL();
                while (rdrR005_DTL.Read())
                {
                    WriteData();
                }

                rdrR005_DTL.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrR005_DTL == null))
            {
                rdrR005_DTL.Close();
                rdrR005_DTL = null;
            }
        }
    }
}