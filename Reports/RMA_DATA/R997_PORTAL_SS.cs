#region "Screen Comments"


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
    public class R997_PORTAL_SS : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R997_PORTAL_SS";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrU997_GOOD_SRT = new Reader();
        private Reader rdrF020_RPT = new Reader();

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

                Sort = "DOC_NBR ASC, W_RAT_145_CLINIC_NBR ASC, DOC_DEPT ASC, X_PAY_PGM ASC, W_RAT_145_LAST_NAME ASC, W_RAT_145_FIRST_NAME ASC, RAT_145_HEALTH_OHIP_NBR ASC, RAT_145_ACCOUNT_NBR ASC";

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

        private void Access_U997_GOOD_SRT()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_DEPT, ");
            strSQL.Append("RAT_145_PAY_PROG, ");
            strSQL.Append("W_RAT_145_CLINIC_NBR, ");
            strSQL.Append("W_RAT_145_LAST_NAME, ");
            strSQL.Append("W_RAT_145_FIRST_NAME, ");
            strSQL.Append("RAT_145_HEALTH_OHIP_NBR, ");
            strSQL.Append("RAT_145_ACCOUNT_NBR, ");
            strSQL.Append("RAT_145_AMT_PAID, ");
            strSQL.Append("RAT_145_AMOUNT_SUB, ");
            strSQL.Append("DOC_NAME, ");
            strSQL.Append("DOC_INITS, ");
            strSQL.Append("RAT_145_SERVICE_DATE, ");
            strSQL.Append("RAT_145_NBR_OF_SERV, ");
            strSQL.Append("RAT_145_SERVICE_CD, ");
            strSQL.Append("RAT_145_EXPLAN_CD ");
            strSQL.Append("FROM TEMPORARYDATA.U997_GOOD_SRT ");

            strSQL.Append(Choose());

            rdrU997_GOOD_SRT.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);

            strSQL = null;
        }

        private void Link_F020_RPT()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("REPORT_ID ");
            strSQL.Append("FROM INDEXED.F020_RPT ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_NBR = ").Append(Common.StringToField("Z" + QDesign.ASCII(rdrU997_GOOD_SRT.GetNumber("DOC_DEPT"), 2)));
            strSQL.Append(" AND REPORT_ID = ").Append(2);

            rdrF020_RPT.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

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

        public override bool SelectIf()
        {
            bool blnSelected = false;

            if ((QDesign.NULL(rdrU997_GOOD_SRT.GetNumber("DOC_DEPT")) == QDesign.NULL(7d) | (rdrU997_GOOD_SRT.GetNumber("DOC_DEPT") >= 70 & rdrU997_GOOD_SRT.GetNumber("DOC_DEPT") <= 76)))
            {
                blnSelected = true;
            }

            return blnSelected;
        }

        #endregion

        #region " DEFINES "

        private decimal X_PAY_PGM()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrU997_GOOD_SRT.GetString("RAT_145_PAY_PROG")) == QDesign.NULL("RMB"))
                {
                    decReturnValue = 2;
                }
                else
                {
                    decReturnValue = 1;
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private string X_DOC_DEPT_NBR()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = "`" + "Z" + QDesign.ASCII(rdrU997_GOOD_SRT.GetNumber("DOC_DEPT"), 2) + QDesign.ASCII(rdrU997_GOOD_SRT.GetNumber("DOC_DEPT"), 2) + "`";
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
                strReturnValue = ",";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_TAB()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = "\t";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_AMT_PAID_SIGN()
        {
            string strReturnValue = string.Empty;

            try
            {
                if (QDesign.NULL(rdrU997_GOOD_SRT.GetNumber("RAT_145_AMT_PAID")) < QDesign.NULL(0d))
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
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_PERIOD()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = ".";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

        private decimal X_SUBMIT_FEE_DOLLARS()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrU997_GOOD_SRT.GetNumber("RAT_145_AMOUNT_SUB")) != QDesign.NULL(0d))
                {
                    decReturnValue = Math.Abs(rdrU997_GOOD_SRT.GetNumber("RAT_145_AMOUNT_SUB")) / 100;
                }
                else
                {
                    decReturnValue = 0;
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private decimal X_SUBMIT_FEE_CENTS()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrU997_GOOD_SRT.GetNumber("RAT_145_AMOUNT_SUB")) != QDesign.NULL(0d))
                {
                    decReturnValue = QDesign.PHMod(Math.Abs(rdrU997_GOOD_SRT.GetNumber("RAT_145_AMOUNT_SUB")), 100);
                }
                else
                {
                    decReturnValue = 0;
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

        private decimal X_AMT_PAID_DOLLARS()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrU997_GOOD_SRT.GetNumber("RAT_145_AMT_PAID")) != QDesign.NULL(0d))
                {
                    decReturnValue = Math.Abs(rdrU997_GOOD_SRT.GetNumber("RAT_145_AMT_PAID")) / 100;
                }
                else
                {
                    decReturnValue = 0;
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private decimal X_AMT_PAID_CENTS()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrU997_GOOD_SRT.GetNumber("RAT_145_AMT_PAID")) != QDesign.NULL(0d))
                {
                    decReturnValue = QDesign.PHMod(Math.Abs(rdrU997_GOOD_SRT.GetNumber("RAT_145_AMT_PAID")), 100);
                }
                else
                {
                    decReturnValue = 0;
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private string X_DOC_NBR()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = "`" + rdrF020_RPT.GetString("DOC_NBR") + "`";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_CLINIC()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = "`" + rdrU997_GOOD_SRT.GetString("W_RAT_145_CLINIC_NBR") + "`";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_DOC_DEPT()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.Pack("`" + QDesign.ASCII(rdrU997_GOOD_SRT.GetNumber("DOC_DEPT")) + "`");
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_DOC_NAME()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.Pack("`" + rdrU997_GOOD_SRT.GetString("DOC_NAME") + "`");
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_DOC_INITS()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.Pack("`" + rdrU997_GOOD_SRT.GetString("DOC_INITS") + "`");
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_CLAIM_NBR()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.Pack("`" + rdrU997_GOOD_SRT.GetString("RAT_145_ACCOUNT_NBR") + "`");
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_PAT_SURNAME()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.Pack("`" + rdrU997_GOOD_SRT.GetString("W_RAT_145_LAST_NAME") + "`");
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_PAT_FIRST_NAME()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.Pack("`" + rdrU997_GOOD_SRT.GetString("W_RAT_145_FIRST_NAME") + "`");
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_HEALTH_OHIP_NBR()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.Pack("`" + rdrU997_GOOD_SRT.GetString("RAT_145_HEALTH_OHIP_NBR") + "`");
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_PAY_PROG()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.Pack("`" + rdrU997_GOOD_SRT.GetString("RAT_145_PAY_PROG") + "`");
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_SERVICE_DATE()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = "`" + QDesign.Substring(QDesign.ASCII(rdrU997_GOOD_SRT.GetDate("RAT_145_SERVICE_DATE")), 1, 4) + "-" + QDesign.Substring(QDesign.ASCII(rdrU997_GOOD_SRT.GetDate("RAT_145_SERVICE_DATE")), 5, 2) + "-" + QDesign.Substring(QDesign.ASCII(rdrU997_GOOD_SRT.GetDate("RAT_145_SERVICE_DATE")), 7, 2) + "`";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_NBR_SVCS_ALPHA()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.Pack("`" + QDesign.ASCII(rdrU997_GOOD_SRT.GetNumber("RAT_145_NBR_OF_SERV")) + "`");
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_OMA_CD()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.Pack("`" + rdrU997_GOOD_SRT.GetString("RAT_145_SERVICE_CD") + "`");
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_SUBMIT_FEE_ALPHA()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.Pack("`" + (QDesign.ASCII(X_SUBMIT_FEE_DOLLARS()) + X_PERIOD() + QDesign.ASCII(X_SUBMIT_FEE_CENTS(), 2)).TrimEnd() + "`");
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_AMT_PAID_ALPHA()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.Pack("`" + (QDesign.LeftJustify(X_AMT_PAID_SIGN() + QDesign.ASCII(X_AMT_PAID_DOLLARS()) + X_PERIOD() + QDesign.ASCII(X_AMT_PAID_CENTS(), 2))).TrimEnd() + "`");
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_EXPLAN_CD()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.Pack("`" + rdrU997_GOOD_SRT.GetString("RAT_145_EXPLAN_CD") + "`");
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_LINE()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.LeftJustify(QDesign.Pack(X_DOC_NBR() + X_TAB() + X_CLINIC() + X_TAB() + X_DOC_DEPT() + X_TAB() + X_DOC_NAME() + X_TAB() + X_DOC_INITS() + X_TAB() + X_CLAIM_NBR() + X_TAB() + X_PAT_SURNAME() + X_TAB() + X_PAT_FIRST_NAME() + X_TAB() + X_HEALTH_OHIP_NBR() + X_TAB() + X_PAY_PROG() + X_TAB() + X_SERVICE_DATE() + X_TAB() + X_NBR_SVCS_ALPHA() + X_TAB() + X_OMA_CD() + X_TAB() + X_SUBMIT_FEE_ALPHA() + X_TAB() + X_AMT_PAID_ALPHA() + X_TAB() + X_EXPLAN_CD() + X_TAB() + X_DOC_DEPT_NBR()));
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
                AddControl(ReportSection.INITIAL_HEADING, "X_TAB", DataTypes.Character, 1);
                AddControl(ReportSection.INITIAL_HEADING, "X_DOC_DEPT_NBR", DataTypes.Character, 7);
                AddControl(ReportSection.REPORT, "X_LINE", DataTypes.Character, 160);
                AddControl(ReportSection.REPORT, "INDEXED.F020_RPT.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U997_GOOD_SRT.W_RAT_145_CLINIC_NBR", DataTypes.Character, 2);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U997_GOOD_SRT.DOC_DEPT", DataTypes.Character, 2);
                AddControl(ReportSection.REPORT, "X_PAY_PGM", DataTypes.Numeric, 0);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U997_GOOD_SRT.W_RAT_145_LAST_NAME", DataTypes.Character, 9);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U997_GOOD_SRT.W_RAT_145_FIRST_NAME", DataTypes.Character, 5);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U997_GOOD_SRT.RAT_145_HEALTH_OHIP_NBR", DataTypes.Character, 12);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U997_GOOD_SRT.RAT_145_ACCOUNT_NBR", DataTypes.Character, 8);
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
        //# Do not delete, modify or move it.  Updated: 10/10/2017 2:56:35 PM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "X_TAB":
                    return Common.StringToField(X_TAB().PadRight(1, ' '));


                case "X_DOC_DEPT_NBR":
                    return Common.StringToField(X_DOC_DEPT_NBR().PadRight(7, ' '));

                case "X_LINE":
                    return Common.StringToField(X_LINE().PadRight(160, ' '));

                case "INDEXED.F020_RPT.DOC_NBR":
                    return Common.StringToField(rdrF020_RPT.GetString("DOC_NBR").PadRight(3, ' '));

                case "TEMPORARYDATA.U997_GOOD_SRT.W_RAT_145_CLINIC_NBR":
                    return Common.StringToField(rdrU997_GOOD_SRT.GetString("W_RAT_145_CLINIC_NBR").PadRight(2, ' '));

                case "TEMPORARYDATA.U997_GOOD_SRT.DOC_DEPT":
                    return Common.StringToField(rdrU997_GOOD_SRT.GetString("DOC_DEPT").PadRight(2, ' '));

                case "X_PAY_PGM":
                    return X_PAY_PGM().ToString().ToString().PadLeft(0, ' ');

                case "TEMPORARYDATA.U997_GOOD_SRT.W_RAT_145_LAST_NAME":
                    return Common.StringToField(rdrU997_GOOD_SRT.GetString("W_RAT_145_LAST_NAME").PadRight(9, ' '));

                case "TEMPORARYDATA.U997_GOOD_SRT.W_RAT_145_FIRST_NAME":
                    return Common.StringToField(rdrU997_GOOD_SRT.GetString("W_RAT_145_FIRST_NAME").PadRight(5, ' '));

                case "TEMPORARYDATA.U997_GOOD_SRT.RAT_145_HEALTH_OHIP_NBR":
                    return Common.StringToField(rdrU997_GOOD_SRT.GetString("RAT_145_HEALTH_OHIP_NBR").PadRight(12, ' '));

                case "TEMPORARYDATA.U997_GOOD_SRT.RAT_145_ACCOUNT_NBR":
                    return Common.StringToField(rdrU997_GOOD_SRT.GetString("RAT_145_ACCOUNT_NBR").PadRight(8, ' '));

                default:

                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_U997_GOOD_SRT();

                while (rdrU997_GOOD_SRT.Read())
                {
                    Link_F020_RPT();
                    while (rdrF020_RPT.Read())
                    {
                        WriteData();
                    }
                    rdrF020_RPT.Close();
                }
                rdrU997_GOOD_SRT.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrU997_GOOD_SRT != null))
            {
                rdrU997_GOOD_SRT.Close();
                rdrU997_GOOD_SRT = null;
            }
            if ((rdrF020_RPT != null))
            {
                rdrF020_RPT.Close();
                rdrF020_RPT = null;
            }
        }


        #endregion

        #endregion
    }
}
