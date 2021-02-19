#region "Screen Comments"

// #> PROGRAM-ID.     r128b_csv.qzs   
// ((C)) Dyad Infosys LTD 
// PURPOSE: Second pass to prdecimal Inactive Doctors report who have no earnings for 3 most recent months
// for Ross/Helena - Excel file
// MODIFICATION HISTORY
// DATE    SAF #  WHO      DESCRIPTION
// 2015/Oct/21  M.C.     - original

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
    public class R128B_CSV : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R128B_CSV";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrR128A_INACTIVE_DOC_WITH_CLM = new Reader();
        private Reader rdrF070_DEPT_MSTR = new Reader();

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

        private void Access_R128A_INACTIVE_DOC_WITH_CLM()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_DEPT, ");
            strSQL.Append("X_CLAIM_BAL, ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("DOC_EP_PAY_CODE, ");
            strSQL.Append("DOC_EP_PAY_SUB_CODE, ");
            strSQL.Append("DOC_NAME, ");
            strSQL.Append("DOC_DATE_FAC_START_YY, ");
            strSQL.Append("DOC_DATE_FAC_START_MM, ");
            strSQL.Append("DOC_DATE_FAC_START_DD, ");
            strSQL.Append("DOC_DATE_FAC_TERM_YY ");
            strSQL.Append("DOC_DATE_FAC_TERM_MM ");
            strSQL.Append("DOC_DATE_FAC_TERM_DD ");
            strSQL.Append("FROM TEMPORARYDATA.R128A_INACTIVE_DOC_WITH_CLM ");

            strSQL.Append(Choose());

            rdrR128A_INACTIVE_DOC_WITH_CLM.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);

            strSQL = null;
        }

        private void Link_F070_DEPT_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DEPT_NBR, ");
            strSQL.Append("DEPT_COMPANY ");
            strSQL.Append("FROM [101C].INDEXED.F070_DEPT_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DEPT_NBR = ").Append(rdrR128A_INACTIVE_DOC_WITH_CLM.GetNumber("DOC_DEPT"));

            rdrF070_DEPT_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

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
        private string X_CLAIM_BAL_SIGN()
        {
            string strReturnValue = string.Empty;

            try
            {
                if (QDesign.NULL(rdrR128A_INACTIVE_DOC_WITH_CLM.GetNumber("X_CLAIM_BAL")) < QDesign.NULL(0d))
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

        // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

        private decimal X_CLAIM_BAL_DOLLARS()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrR128A_INACTIVE_DOC_WITH_CLM.GetNumber("X_CLAIM_BAL")) != QDesign.NULL(0d))
                {
                    decReturnValue = Math.Abs(rdrR128A_INACTIVE_DOC_WITH_CLM.GetNumber("X_CLAIM_BAL")) / 100;
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
        private decimal X_CLAIM_BAL_CENTS()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrR128A_INACTIVE_DOC_WITH_CLM.GetNumber("X_CLAIM_BAL")) != QDesign.NULL(0d))
                {
                    decReturnValue = QDesign.PHMod(Math.Abs(rdrR128A_INACTIVE_DOC_WITH_CLM.GetNumber("X_CLAIM_BAL")), 100);
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
        private string X_DEPT()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = "`" + QDesign.ASCII(rdrR128A_INACTIVE_DOC_WITH_CLM.GetNumber("DOC_DEPT"), 2) + "`";
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
                strReturnValue = QDesign.ASCII(rdrF070_DEPT_MSTR.GetNumber("DEPT_COMPANY"));
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
                strReturnValue = "`" + rdrR128A_INACTIVE_DOC_WITH_CLM.GetString("DOC_NBR") + "`";
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
                strReturnValue = "`" + QDesign.Pack(rdrR128A_INACTIVE_DOC_WITH_CLM.GetString("DOC_EP_PAY_CODE") + rdrR128A_INACTIVE_DOC_WITH_CLM.GetString("DOC_EP_PAY_SUB_CODE")) + "`";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_CLAIM_BAL_ALPHA()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.Pack(QDesign.LeftJustify(X_CLAIM_BAL_SIGN().TrimEnd() + QDesign.ASCII(X_CLAIM_BAL_DOLLARS()) + X_PERIOD() + QDesign.ASCII(X_CLAIM_BAL_CENTS(), 2)));
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
                strReturnValue = QDesign.LeftJustify(QDesign.Pack(X_COMPANY() + X_DELIMITER() + X_DEPT() + X_DELIMITER() + X_DOC_NBR() + X_DELIMITER() + rdrR128A_INACTIVE_DOC_WITH_CLM.GetString("DOC_NAME") + X_DELIMITER() + X_PAY_CODE() + X_DELIMITER()
                   + rdrR128A_INACTIVE_DOC_WITH_CLM.GetNumber("DOC_DATE_FAC_START_YY").ToString().PadLeft(4, '0') + rdrR128A_INACTIVE_DOC_WITH_CLM.GetNumber("DOC_DATE_FAC_START_MM").ToString().PadLeft(2, '0') + rdrR128A_INACTIVE_DOC_WITH_CLM.GetNumber("DOC_DATE_FAC_START_DD").ToString().PadLeft(2, '0')
                    + X_DELIMITER()
                      + rdrR128A_INACTIVE_DOC_WITH_CLM.GetNumber("DOC_DATE_FAC_TERM_YY").ToString().PadLeft(4, '0') + rdrR128A_INACTIVE_DOC_WITH_CLM.GetNumber("DOC_DATE_FAC_TERM_MM").ToString().PadLeft(2, '0') + rdrR128A_INACTIVE_DOC_WITH_CLM.GetNumber("DOC_DATE_FAC_TERM_DD").ToString().PadLeft(2, '0')
                     + X_DELIMITER() + X_CLAIM_BAL_ALPHA()));
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
                AddControl(ReportSection.INITIAL_HEADING, "X_DELIMITER", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "X_LINE", DataTypes.Character, 132);
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
        //# Do not delete, modify or move it.  Updated: 2017-07-24 5:05:05 PM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "X_DELIMITER":
                    return Common.StringToField(X_DELIMITER(), intSize);

                case "X_LINE":
                    return Common.StringToField(X_LINE(), intSize);

                default:

                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_R128A_INACTIVE_DOC_WITH_CLM();

                while (rdrR128A_INACTIVE_DOC_WITH_CLM.Read())
                {
                    Link_F070_DEPT_MSTR();
                    while (rdrF070_DEPT_MSTR.Read())
                    {
                        WriteData();
                    }
                    rdrF070_DEPT_MSTR.Close();
                }
                rdrR128A_INACTIVE_DOC_WITH_CLM.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrR128A_INACTIVE_DOC_WITH_CLM != null))
            {
                rdrR128A_INACTIVE_DOC_WITH_CLM.Close();
                rdrR128A_INACTIVE_DOC_WITH_CLM = null;
            }
            if ((rdrF070_DEPT_MSTR != null))
            {
                rdrF070_DEPT_MSTR.Close();
                rdrF070_DEPT_MSTR = null;
            }
        }


        #endregion

        #endregion
    }
}
