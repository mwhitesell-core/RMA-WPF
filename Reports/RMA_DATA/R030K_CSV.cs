#region "Screen Comments"

// #> PROGRAM-ID.     R030K_CSV.QZS
// ((C)) Dyad Infosys Ltd 
// PROGRAM PURPOSE : PRINT THE DOCTOR`S TOTAL AMOUNT PREMIUM PAID FROM THE RAT
// MODIFICATION HISTORY
// DATE   WHO          DESCRIPTION
// 2016/Aug/24 M.C.         - ORIGINAL (clone from r030k.qzs)
// - Helena requested to have CSV version

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
    public class R030K_CSV : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R030K_CSV";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrR031A_ACTIVE_DOCTOR = new Reader();
        private Reader rdrF020_DOCTOR_MSTR = new Reader();
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

                Sort = "DOC_DEPT ASC, DOC_NAME ASC";

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

        private void Access_R031A_ACTIVE_DOCTOR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("X_CLINIC, ");
            strSQL.Append("DOC_OHIP_NBR, ");
            strSQL.Append("X_TOTAL_PAID_AMT ");
            strSQL.Append("FROM TEMPORARYDATA.R031A_ACTIVE_DOCTOR ");

            strSQL.Append(Choose());

            rdrR031A_ACTIVE_DOCTOR.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);

            strSQL = null;
        }

        private void Link_F020_DOCTOR_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("DOC_NAME, ");
            strSQL.Append("DOC_INIT1, ");
            strSQL.Append("DOC_INIT2, ");
            strSQL.Append("DOC_INIT3, ");
            strSQL.Append("DOC_DEPT, ");
            strSQL.Append("DOC_DATE_FAC_TERM_YY, ");
            strSQL.Append("DOC_DATE_FAC_TERM_MM, ");
            strSQL.Append("DOC_DATE_FAC_TERM_DD ");
            strSQL.Append("FROM INDEXED.F020_DOCTOR_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_NBR = ").Append(Common.StringToField(rdrR031A_ACTIVE_DOCTOR.GetString("DOC_NBR")));

            rdrF020_DOCTOR_MSTR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

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
        private string X_CLINIC_ALPHA()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.ASCII(rdrR031A_ACTIVE_DOCTOR.GetString("X_CLINIC"), 2);
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
                strReturnValue = QDesign.Pack(rdrF020_DOCTOR_MSTR.GetString("DOC_NAME") + ", " + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT1") + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT2") + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT3"));
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
                strReturnValue = "`" + QDesign.ASCII(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT"), 2) + "`";
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
                strReturnValue = "`" + rdrF020_DOCTOR_MSTR.GetString("DOC_NBR") + "`";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_DOC_OHIP_NBR()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = "`" + QDesign.ASCII(rdrR031A_ACTIVE_DOCTOR.GetNumber("DOC_OHIP_NBR"), 6) + "`";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_TOTAL_PAID_AMT_SIGN()
        {
            string strReturnValue = string.Empty;

            try
            {
                if (QDesign.NULL(rdrR031A_ACTIVE_DOCTOR.GetNumber("X_TOTAL_PAID_AMT")) < QDesign.NULL(0d))
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

        private decimal X_TOTAL_PAID_AMT_DOLLARS()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrR031A_ACTIVE_DOCTOR.GetNumber("X_TOTAL_PAID_AMT")) != QDesign.NULL(0d))
                {
                    decReturnValue = Math.Abs(rdrR031A_ACTIVE_DOCTOR.GetNumber("X_TOTAL_PAID_AMT")) / 100;
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
        private decimal X_TOTAL_PAID_AMT_CENTS()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrR031A_ACTIVE_DOCTOR.GetNumber("X_TOTAL_PAID_AMT")) != QDesign.NULL(0d))
                {
                    decReturnValue = QDesign.PHMod(Math.Abs(rdrR031A_ACTIVE_DOCTOR.GetNumber("X_TOTAL_PAID_AMT")), 100);
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
        private string X_PAID_AMT_ALPHA()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.Pack(QDesign.LeftJustify(X_TOTAL_PAID_AMT_SIGN() + QDesign.ASCII(X_TOTAL_PAID_AMT_DOLLARS()) + X_PERIOD() + QDesign.ASCII(X_TOTAL_PAID_AMT_CENTS(), 2)).TrimEnd());
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
                if (QDesign.NULL(QDesign.GetDecimalFromDate(rdrF020_DOCTOR_MSTR.GetDate("DOC_DATE_FAC_TERM"))) != QDesign.NULL(0d))
                {
                    strReturnValue = QDesign.ASCII(rdrF020_DOCTOR_MSTR.GetDate("DOC_DATE_FAC_TERM"));
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
                strReturnValue = "CLINIC" + X_DELIMITER() + "DEPT" + X_DELIMITER() + "DOC OHIP NBR" + X_DELIMITER() + "DOC#" + X_DELIMITER() + "DOC NAME" + X_DELIMITER() + "PAID AMOUNT" + X_DELIMITER() + "TERM DATE";
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
                strReturnValue = QDesign.LeftJustify(QDesign.Pack(X_CLINIC_ALPHA() + X_DELIMITER() + X_DEPT() + X_DELIMITER() + X_DOC_OHIP_NBR() + X_DELIMITER() + X_DOC_NBR() + X_DELIMITER() + X_DOC_NAME() + X_DELIMITER() + X_PAID_AMT_ALPHA() + X_DELIMITER() + X_TERM_DATE()));
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
                AddControl(ReportSection.REPORT, "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT", DataTypes.Character, 2);
                AddControl(ReportSection.REPORT, "INDEXED.F020_DOCTOR_MSTR.DOC_NAME", DataTypes.Character, 24);
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
        //# Do not delete, modify or move it.  Updated: 9/27/2017 1:24:53 PM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "X_HEAD":
                    return Common.StringToField(X_HEAD().PadRight(132, ' '));

                case "X_LINE":
                    return Common.StringToField(X_LINE().PadRight(132, ' '));

                case "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT":
                    return Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_DEPT").PadRight(2, ' '));

                case "INDEXED.F020_DOCTOR_MSTR.DOC_NAME":
                    return Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_NAME").PadRight(24, ' '));

                default:

                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_R031A_ACTIVE_DOCTOR();

                while (rdrR031A_ACTIVE_DOCTOR.Read())
                {
                    Link_F020_DOCTOR_MSTR();
                    while (rdrF020_DOCTOR_MSTR.Read())
                    {
                        WriteData();
                    }
                    rdrF020_DOCTOR_MSTR.Close();
                }
                rdrR031A_ACTIVE_DOCTOR.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrR031A_ACTIVE_DOCTOR != null))
            {
                rdrR031A_ACTIVE_DOCTOR.Close();
                rdrR031A_ACTIVE_DOCTOR = null;
            }
            if ((rdrF020_DOCTOR_MSTR != null))
            {
                rdrF020_DOCTOR_MSTR.Close();
                rdrF020_DOCTOR_MSTR = null;
            }
        }


        #endregion

        #endregion
    }
}
