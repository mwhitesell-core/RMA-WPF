#region "Screen Comments"

// R139_CSV.QZS
// DOC: INCEXP minus TOTDED <> PAYEFT for pay code 2 only
// DOC: SORT BY COMPANY/DEPT
// DOC: RUN FOR: Ross  
// PROGRAM PURPOSE : The difference between ( (Total Revenue - Total Expense ) - Total Deduction)
// and PAYEFT Amount  for pay code 2 doctors
// DATE           WHO       DESCRIPTION
// 2015/Aug/12 MC   ORIGINAL - this program will be run in $cmd/teb3; thus ep nbr has changed (+1)  
// - this is the second pass
// 2015/Nov/05  MC1   change column heading as requested by Brad
// 2016/Mar/15    MC2       include pay code 0 as Brad suggested, display terminated date
// MC2
// set page length 0  width 132

#endregion

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
    public class R139_CSV : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R139_CSV";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrR139_CSV = new Reader();

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

                Sort = "DEPT_COMPANY ASC, DOC_DEPT ASC, DOC_NBR ASC";

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

        private void Access_R139_CSV()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DEPT_COMPANY, ");
            strSQL.Append("DOC_DEPT, ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("AMT_INCEXP, ");
            strSQL.Append("AMT_TOTDED, ");
            strSQL.Append("AMT_PAYEFT, ");
            strSQL.Append("EP_NBR, ");
            strSQL.Append("DOC_DATE_FAC_TERM, ");
            strSQL.Append("AMT_PAYPOT, ");
            strSQL.Append("AMT_ADVOUT, ");
            strSQL.Append("DOC_NAME, ");
            strSQL.Append("DOC_EP_PAY_CODE ");
            strSQL.Append("FROM TEMPORARYDATA.R139_CSV ");

            strSQL.Append(Choose());

            rdrR139_CSV.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);

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

            if (QDesign.NULL(INCEXP_TOTDED()) != QDesign.NULL(rdrR139_CSV.GetNumber("AMT_PAYEFT")))
                blnSelected = true;

            return blnSelected;
        }

        #endregion

        #region " DEFINES "
        private decimal INCEXP_TOTDED()
        {
            decimal decReturnValue = 0;

            try
            {
                decReturnValue = rdrR139_CSV.GetNumber("AMT_INCEXP") - rdrR139_CSV.GetNumber("AMT_TOTDED");
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private string X_DELIMITER()
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
        private string X_COMPANY()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.ASCII(rdrR139_CSV.GetNumber("DEPT_COMPANY"));
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_DEPT()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = "\"" + QDesign.ASCII(rdrR139_CSV.GetNumber("DOC_DEPT"), 2) + "\"";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_DOC_NBR()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = "\"" + rdrR139_CSV.GetString("DOC_NBR") + "\"";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_EP_NBR()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.ASCII(rdrR139_CSV.GetNumber("EP_NBR"));
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_TERM_DATE()
        {
            string strReturnValue = string.Empty;

            try
            {
                if (QDesign.NULL(rdrR139_CSV.GetNumber("DOC_DATE_FAC_TERM")) != 0)
                {
                    strReturnValue = QDesign.ASCII(rdrR139_CSV.GetNumber("DOC_DATE_FAC_TERM"));
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_INCEXP_SIGN()
        {
            string strReturnValue = string.Empty;

            try
            {
                if (QDesign.NULL(rdrR139_CSV.GetNumber("AMT_INCEXP")) < 0)
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

        private decimal X_INCEXP_DOLLARS()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrR139_CSV.GetNumber("AMT_INCEXP")) != 0)
                {
                    decReturnValue = Math.Abs(rdrR139_CSV.GetNumber("AMT_INCEXP")) / 100;
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

        private decimal X_INCEXP_CENTS()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrR139_CSV.GetNumber("AMT_INCEXP")) != 0)
                {
                    decReturnValue = QDesign.PHMod(Math.Abs(rdrR139_CSV.GetNumber("AMT_INCEXP")), 100);
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

        private string X_TOTDED_SIGN()
        {
            string strReturnValue = string.Empty;

            try
            {
                if (QDesign.NULL(rdrR139_CSV.GetNumber("AMT_TOTDED")) < 0)
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

        private decimal X_TOTDED_DOLLARS()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrR139_CSV.GetNumber("AMT_TOTDED")) != 0)
                {
                    decReturnValue = Math.Abs(rdrR139_CSV.GetNumber("AMT_TOTDED")) / 100;
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

        private decimal X_TOTDED_CENTS()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrR139_CSV.GetNumber("AMT_TOTDED")) != 0)
                {
                    decReturnValue = QDesign.PHMod(Math.Abs(rdrR139_CSV.GetNumber("AMT_TOTDED")), 100);
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

        private string X_INCEXP_TOTDED_SIGN()
        {
            string strReturnValue = string.Empty;

            try
            {
                if (QDesign.NULL(INCEXP_TOTDED()) < 0)
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

        private decimal X_INCEXP_TOTDED_DOLLARS()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(INCEXP_TOTDED()) != 0)
                {
                    decReturnValue = Math.Abs(INCEXP_TOTDED()) / 100;
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

        private decimal X_INCEXP_TOTDED_CENTS()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(INCEXP_TOTDED()) != 0)
                {
                    decReturnValue = QDesign.PHMod(Math.Abs(INCEXP_TOTDED()), 100);
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

        private string X_PAYPOT_SIGN()
        {
            string strReturnValue = string.Empty;

            try
            {
                if (QDesign.NULL(rdrR139_CSV.GetNumber("AMT_PAYPOT")) < 0)
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

        private decimal X_PAYPOT_DOLLARS()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrR139_CSV.GetNumber("AMT_PAYPOT")) != 0)
                {
                    decReturnValue = Math.Abs(rdrR139_CSV.GetNumber("AMT_PAYPOT")) / 100;
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

        private decimal X_PAYPOT_CENTS()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrR139_CSV.GetNumber("AMT_PAYPOT")) != 0)
                {
                    decReturnValue = QDesign.PHMod(Math.Abs(rdrR139_CSV.GetNumber("AMT_PAYPOT")), 100);
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

        private string X_PAYEFT_SIGN()
        {
            string strReturnValue = string.Empty;

            try
            {
                if (QDesign.NULL(rdrR139_CSV.GetNumber("AMT_PAYEFT")) < 0)
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

        private decimal X_PAYEFT_DOLLARS()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrR139_CSV.GetNumber("AMT_PAYEFT")) != 0)
                {
                    decReturnValue = Math.Abs(rdrR139_CSV.GetNumber("AMT_PAYEFT")) / 100;
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

        private decimal X_PAYEFT_CENTS()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrR139_CSV.GetNumber("AMT_PAYEFT")) != 0)
                {
                    decReturnValue = QDesign.PHMod(Math.Abs(rdrR139_CSV.GetNumber("AMT_PAYEFT")), 100);
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

        private string X_ADVOUT_SIGN()
        {
            string strReturnValue = string.Empty;

            try
            {
                if (QDesign.NULL(rdrR139_CSV.GetNumber("AMT_ADVOUT")) < 0)
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

        private decimal X_ADVOUT_DOLLARS()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrR139_CSV.GetNumber("AMT_ADVOUT")) != 0)
                {
                    decReturnValue = Math.Abs(rdrR139_CSV.GetNumber("AMT_ADVOUT")) / 100;
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
        private decimal X_ADVOUT_CENTS()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrR139_CSV.GetNumber("AMT_ADVOUT")) != 0)
                {
                    decReturnValue = QDesign.PHMod(Math.Abs(rdrR139_CSV.GetNumber("AMT_ADVOUT")), 100);
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

        private string X_INCEXP_ALPHA()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.Pack(QDesign.LeftJustify(X_INCEXP_SIGN().TrimEnd() + QDesign.ASCII(X_INCEXP_DOLLARS()) + X_PERIOD() + QDesign.ASCII(X_INCEXP_CENTS(), 2)));
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_TOTDED_ALPHA()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.Pack(QDesign.LeftJustify(X_TOTDED_SIGN().TrimEnd() + QDesign.ASCII(X_TOTDED_DOLLARS()) + X_PERIOD() + QDesign.ASCII(X_TOTDED_CENTS(), 2)));
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_INCEXP_TOTDED_ALPHA()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.Pack(QDesign.LeftJustify(X_INCEXP_TOTDED_SIGN().TrimEnd() + QDesign.ASCII(X_INCEXP_TOTDED_DOLLARS()) + X_PERIOD() + QDesign.ASCII(X_INCEXP_TOTDED_CENTS(), 2)));
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_PAYPOT_ALPHA()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.Pack(QDesign.LeftJustify(X_PAYPOT_SIGN().TrimEnd() + QDesign.ASCII(X_PAYPOT_DOLLARS()) + X_PERIOD() + QDesign.ASCII(X_PAYPOT_CENTS(), 2)));
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_PAYEFT_ALPHA()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.Pack(QDesign.LeftJustify(X_PAYEFT_SIGN().TrimEnd() + QDesign.ASCII(X_PAYEFT_DOLLARS()) + X_PERIOD() + QDesign.ASCII(X_PAYEFT_CENTS(), 2)));
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_ADVOUT_ALPHA()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.Pack(QDesign.LeftJustify(X_ADVOUT_SIGN().TrimEnd() + QDesign.ASCII(X_ADVOUT_DOLLARS()) + X_PERIOD() + QDesign.ASCII(X_ADVOUT_CENTS(), 2)));
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
                strReturnValue = QDesign.LeftJustify(QDesign.Pack(X_COMPANY() + X_DELIMITER() + X_DEPT() + X_DELIMITER() + X_DOC_NBR() + X_DELIMITER() + rdrR139_CSV.GetString("DOC_NAME") + X_DELIMITER() + X_INCEXP_ALPHA() + X_DELIMITER() + X_TOTDED_ALPHA() + X_DELIMITER() + X_INCEXP_TOTDED_ALPHA() + X_DELIMITER() + X_PAYEFT_ALPHA() + X_DELIMITER() + X_PAYPOT_ALPHA() + X_DELIMITER() + X_ADVOUT_ALPHA() + X_DELIMITER() + X_EP_NBR() + X_DELIMITER() + rdrR139_CSV.GetString("DOC_EP_PAY_CODE") + X_DELIMITER() + X_TERM_DATE()));
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_HEAD()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = "Company" + X_DELIMITER() + "Dept" + X_DELIMITER() + "Doc Nbr" + X_DELIMITER() + "Name" + X_DELIMITER() + "Income-Expense (A)" + X_DELIMITER() + "Total Deductions (B)" + X_DELIMITER() + "(A) - (B)" + X_DELIMITER() + "PayEft" + X_DELIMITER() + "Potential Pay" + X_DELIMITER() + "Advance Outstanding" + X_DELIMITER() + "EP Nbr" + X_DELIMITER() + "Pay Cd" + X_DELIMITER() + "Term Date";
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
                AddControl(ReportSection.INITIAL_HEADING, "X_HEAD", DataTypes.Character, 145);
                AddControl(ReportSection.REPORT, "X_LINE", DataTypes.Character, 145);
                AddControl(ReportSection.REPORT, "DEPT_COMPANY", DataTypes.Numeric, 4);
                AddControl(ReportSection.REPORT, "DOC_DEPT", DataTypes.Numeric, 4);
                AddControl(ReportSection.REPORT, "DOC_NBR", DataTypes.Character, 3);
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
        //# Do not delete, modify or move it.  Updated: 6/29/2017 2:26:31 PM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "X_HEAD":
                    return Common.StringToField(X_HEAD(), intSize);

                case "X_LINE":
                    return Common.StringToField(X_LINE(), intSize);

                case "DEPT_COMPANY":
                    return rdrR139_CSV.GetNumber("DEPT_COMPANY").ToString();

                case "DOC_DEPT":
                    return rdrR139_CSV.GetNumber("DOC_DEPT").ToString();

                case "DOC_NBR":
                    return Common.StringToField(rdrR139_CSV.GetString("DOC_NBR"));

                default:
                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_R139_CSV();

                while (rdrR139_CSV.Read())
                {
                    WriteData();
                }
                rdrR139_CSV.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrR139_CSV != null))
            {
                rdrR139_CSV.Close();
                rdrR139_CSV = null;
            }
        }

        #endregion

        #endregion
    }
}
