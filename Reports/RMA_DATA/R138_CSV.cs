#region "Screen Comments"

// DOC: R138_CSV.QZS
// DOC: DEFICIT REPORT
// DOC: SORT BY COMPANY/DEPT
// DOC: RUN FOR: Ross  
// PROGRAM PURPOSE : DEFICIT REPORT FOR PAYROLL
// DATE           WHO       DESCRIPTION
// 2015/Aug/11 MC   ORIGINAL - this program will be run in $cmd/teb3; thus ep nbr has changed (+1)  
// 2016/Mar/16    MC1       this has cloned into new program r138_csv.qts as the first pass, and now this will be
// the second pass, change program accordingly to show defict and advout amount from the subfile
// r138_csv_doc.sf which is created from r138_csv.qts and as well include error flag `***`
// if deficit amount <> advout amount
// 2016/Sep/13    MC2       change the column headings for DEFICIT and ADVOUT as Yasemin suggested 
// MC1
// access constants-mstr-rec-6   &
// link  current-ep-nbr             &
// to   ep-nbr  of f110-compensation &
// link  doc-nbr    &
// to   doc-nbr of f020-doctor-mstr opt   &
// link  doc-dept    &
// to   dept-nbr of f070-dept-mstr opt

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
    public class R138_CSV : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R138_CSV";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrR138_CSV_DOC = new Reader();

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

        private void Access_R138_CSV_DOC()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DEPT_COMPANY, ");
            strSQL.Append("DOC_DEPT, ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("DEFICIT_AMT, ");
            strSQL.Append("ADVOUT_AMT, ");
            strSQL.Append("EP_NBR, ");
            strSQL.Append("DOC_EP_PAY_CODE, ");
            strSQL.Append("DOC_EP_PAY_SUB_CODE, ");
            strSQL.Append("DOC_NAME ");
            strSQL.Append("FROM TEMPORARYDATA.R138_CSV_DOC ");

            strSQL.Append(Choose());

            rdrR138_CSV_DOC.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);

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

        private string X_AMT_DEFICIT_SIGN()
        {
            string strReturnValue = string.Empty;

            try
            {
                if (QDesign.NULL(rdrR138_CSV_DOC.GetNumber("DEFICIT_AMT")) < 0)
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

        private decimal X_AMT_DEFICIT_DOLLARS()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrR138_CSV_DOC.GetNumber("DEFICIT_AMT")) != 0)
                {
                    decReturnValue = Math.Abs(rdrR138_CSV_DOC.GetNumber("DEFICIT_AMT")) / 100;
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

        private decimal X_AMT_DEFICIT_CENTS()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrR138_CSV_DOC.GetNumber("DEFICIT_AMT")) != 0)
                {
                    decReturnValue = QDesign.PHMod(Math.Abs(rdrR138_CSV_DOC.GetNumber("DEFICIT_AMT")), 100);
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

        private string X_AMT_ADVOUT_SIGN()
        {
            string strReturnValue = string.Empty;

            try
            {
                if (QDesign.NULL(rdrR138_CSV_DOC.GetNumber("ADVOUT_AMT")) < 0)
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

        private decimal X_AMT_ADVOUT_DOLLARS()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrR138_CSV_DOC.GetNumber("ADVOUT_AMT")) != 0)
                {
                    decReturnValue = Math.Abs(rdrR138_CSV_DOC.GetNumber("ADVOUT_AMT")) / 100;
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

        private decimal X_AMT_ADVOUT_CENTS()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrR138_CSV_DOC.GetNumber("ADVOUT_AMT")) != 0)
                {
                    decReturnValue = QDesign.PHMod(Math.Abs(rdrR138_CSV_DOC.GetNumber("ADVOUT_AMT")), 100);
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

        private string X_COMPANY()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.ASCII(rdrR138_CSV_DOC.GetNumber("DEPT_COMPANY"));
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
                strReturnValue = "\"" + QDesign.ASCII(rdrR138_CSV_DOC.GetNumber("DOC_DEPT"), 2) + "\"";
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
                strReturnValue = "\"" + rdrR138_CSV_DOC.GetString("DOC_NBR") + "\"";
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
                strReturnValue = QDesign.ASCII(rdrR138_CSV_DOC.GetNumber("EP_NBR"));
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_PAY_CODE()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = (rdrR138_CSV_DOC.GetString("DOC_EP_PAY_CODE") + rdrR138_CSV_DOC.GetString("DOC_EP_PAY_SUB_CODE")).PadRight(2, ' ');
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_DEFICIT_AMT_ALPHA()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.Pack(QDesign.LeftJustify(X_AMT_DEFICIT_SIGN().TrimEnd() + QDesign.ASCII(X_AMT_DEFICIT_DOLLARS()) + X_PERIOD() + QDesign.ASCII(X_AMT_DEFICIT_CENTS(), 2)));
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_ADVOUT_AMT_ALPHA()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.Pack(QDesign.LeftJustify(X_AMT_ADVOUT_SIGN().TrimEnd() + QDesign.ASCII(X_AMT_ADVOUT_DOLLARS()) + X_PERIOD() + QDesign.ASCII(X_AMT_ADVOUT_CENTS(), 2)));
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_ERROR_FLAG()
        {
            string strReturnValue = string.Empty;

            try
            {
                if (QDesign.NULL(rdrR138_CSV_DOC.GetNumber("DEFICIT_AMT")) != QDesign.NULL(rdrR138_CSV_DOC.GetNumber("ADVOUT_AMT")))
                {
                    strReturnValue = "***";
                }
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
                strReturnValue = "COMPANY" + X_DELIMITER() + "DEPT" + X_DELIMITER() + "DOC#" + X_DELIMITER() + "DOC NAME" + X_DELIMITER() + "F110-DEFICIT" + X_DELIMITER() + "F119-ADVOUT" + X_DELIMITER() + "EP NBR" + X_DELIMITER() + "PAY CODE" + X_DELIMITER() + "ERROR FLAG";
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
                strReturnValue = QDesign.LeftJustify(QDesign.Pack(X_COMPANY() + X_DELIMITER() + X_DEPT() + X_DELIMITER() + X_DOC_NBR() + X_DELIMITER() + rdrR138_CSV_DOC.GetString("DOC_NAME") + X_DELIMITER() + X_DEFICIT_AMT_ALPHA() + X_DELIMITER() + X_ADVOUT_AMT_ALPHA() + X_DELIMITER() + X_EP_NBR() + X_DELIMITER() + X_PAY_CODE() + X_DELIMITER() + X_ERROR_FLAG()));
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
                AddControl(ReportSection.INITIAL_HEADING, "X_HEAD", DataTypes.Character, 132);
                AddControl(ReportSection.REPORT, "X_LINE", DataTypes.Character, 132);
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
                    return rdrR138_CSV_DOC.GetNumber("DEPT_COMPANY").ToString();

                case "DOC_DEPT":
                    return rdrR138_CSV_DOC.GetNumber("DOC_DEPT").ToString();

                case "DOC_NBR":
                    return Common.StringToField(rdrR138_CSV_DOC.GetString("DOC_NBR"));

                default:
                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_R138_CSV_DOC();

                while (rdrR138_CSV_DOC.Read())
                {
                    WriteData();
                }
                rdrR138_CSV_DOC.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrR138_CSV_DOC != null))
            {
                rdrR138_CSV_DOC.Close();
                rdrR138_CSV_DOC = null;
            }
        }

        #endregion

        #endregion
    }
}
