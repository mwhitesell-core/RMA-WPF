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
    public class R997I : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R997I";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrR997 = new Reader();

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

                Sort = "W_SORT ASC";

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

        private void Access_R997()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("RAT_67_TRANS_MESSAGE, ");
            strSQL.Append("RAT_67_CHEQUE_IND, ");
            strSQL.Append("RAT_67_TRANS_CD, ");
            strSQL.Append("RAT_67_AMT_PAID, ");
            strSQL.Append("W_RAT_67_TRANS_AMT, ");
            strSQL.Append("RAT_67_TRANS_DATE, ");
            strSQL.Append("RAT_67_TRANS_AMT, ");
            strSQL.Append("RAT_67_TOTAL_CLINIC_AMT ");
            strSQL.Append("FROM TEMPORARYDATA.R997 ");

            strSQL.Append(Choose());

            //rdrR997.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
            rdrR997.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

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

        private string W_TITLE()
        {
            string strReturnValue = string.Empty;

            try
            {
                if (QDesign.NULL(rdrR997.GetString("RAT_67_TRANS_MESSAGE")) != QDesign.NULL(" "))
                {
                    strReturnValue = rdrR997.GetString("RAT_67_TRANS_MESSAGE");
                }
                else if ((QDesign.NULL(rdrR997.GetString("RAT_67_CHEQUE_IND")) == QDesign.NULL("I") & QDesign.NULL(rdrR997.GetString("RAT_67_TRANS_CD")) == QDesign.NULL("10")))
                {
                    strReturnValue = "INTERIM PAYMENT";
                }
                else if (QDesign.NULL(rdrR997.GetString("RAT_67_TRANS_CD")) == QDesign.NULL("10"))
                {
                    strReturnValue = "ADVANCE";
                }
                else if (QDesign.NULL(rdrR997.GetString("RAT_67_TRANS_CD")) == QDesign.NULL("20"))
                {
                    strReturnValue = "REDUCTION";
                }
                else if (QDesign.NULL(rdrR997.GetString("RAT_67_TRANS_CD")) == QDesign.NULL("30"))
                {
                    strReturnValue = "UNUSED";
                }
                else if (QDesign.NULL(rdrR997.GetString("RAT_67_TRANS_CD")) == QDesign.NULL("40"))
                {
                    strReturnValue = "ADVANCE REPAYMENT";
                }
                else if (QDesign.NULL(rdrR997.GetString("RAT_67_TRANS_CD")) == QDesign.NULL("50"))
                {
                    strReturnValue = "ACCOUNTING ADJUSTMENT";
                }
                else if (QDesign.NULL(rdrR997.GetString("RAT_67_TRANS_CD")) == QDesign.NULL("70"))
                {
                    strReturnValue = "ATTACHMENTS";
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private decimal W_REMITT_AMT()
        {
            decimal decReturnValue = 0;

            try
            {
                decReturnValue = rdrR997.GetNumber("RAT_67_AMT_PAID") + rdrR997.GetNumber("W_RAT_67_TRANS_AMT");
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private string W_SORT()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = " ";
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
                AddControl(ReportSection.REPORT, "W_TITLE", DataTypes.Character, 40);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R997.RAT_67_TRANS_DATE", DataTypes.Numeric, 8);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R997.RAT_67_TRANS_AMT", DataTypes.Numeric, 8);
                AddControl(ReportSection.FINAL_FOOTING, "TEMPORARYDATA.R997.RAT_67_AMT_PAID", DataTypes.Numeric, 9);
                AddControl(ReportSection.FINAL_FOOTING, "W_REMITT_AMT", DataTypes.Numeric, 9);
                AddControl(ReportSection.FINAL_FOOTING, "TEMPORARYDATA.R997.RAT_67_TOTAL_CLINIC_AMT", DataTypes.Numeric, 9);
                AddControl(ReportSection.REPORT, "W_SORT", DataTypes.Character, 1);
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
        //# Do not delete, modify or move it.  Updated: 9/29/2017 11:14:54 AM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "W_TITLE":
                    return Common.StringToField(W_TITLE().PadRight(40, ' '));

                case "TEMPORARYDATA.R997.RAT_67_TRANS_DATE":
                    return rdrR997.GetNumber("RAT_67_TRANS_DATE").ToString().PadLeft(8,' ');

                case "TEMPORARYDATA.R997.RAT_67_TRANS_AMT":
                    return rdrR997.GetNumber("RAT_67_TRANS_AMT").ToString().PadLeft(8, ' ');

                case "TEMPORARYDATA.R997.RAT_67_AMT_PAID":
                    return rdrR997.GetNumber("RAT_67_AMT_PAID").ToString().PadLeft(9, ' ');

                case "W_REMITT_AMT":
                    return W_REMITT_AMT().ToString().PadLeft(9, ' ');

                case "TEMPORARYDATA.R997.RAT_67_TOTAL_CLINIC_AMT":
                    return rdrR997.GetNumber("RAT_67_TOTAL_CLINIC_AMT").ToString().PadLeft(9, ' ');

                case "W_SORT":
                    return Common.StringToField(W_SORT().PadRight(0, ' '));

                default:

                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_R997();

                while (rdrR997.Read())
                {
                    WriteData();
                }
                rdrR997.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrR997 != null))
            {
                rdrR997.Close();
                rdrR997 = null;
            }
        }


        #endregion

        #endregion
    }
}
