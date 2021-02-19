#region "Screen Comments"

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
    public class DEBUGU116CD34 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "DEBUGU116CD34";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrDEBUGU116CD346 = new Reader();

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

        private void Access_DEBUGU116CD346()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("EP_NBR, ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("DOC_PAY_CODE, ");
            strSQL.Append("DOC_PAY_SUB_CODE, ");
            strSQL.Append("FACTOR, ");
            strSQL.Append("DOC_YTDINC, ");
            strSQL.Append("DOC_YTDEAR, ");
            strSQL.Append("DOC_YTDCEA, ");
            strSQL.Append("DOC_YTDCEX, ");
            strSQL.Append("DOC_YRLY_EXPENSE_COMPUTED, ");
            strSQL.Append("DOC_YTDINC_G, ");
            strSQL.Append("W_PAY_POT_G_1, ");
            strSQL.Append("W_PAY_POT_G, ");
            strSQL.Append("W_PAY_ACTUAL_N, ");
            strSQL.Append("W_PAYPOT_AMT_NET, ");
            strSQL.Append("W_UNDERAGE_ACT ");
            strSQL.Append("FROM TEMPORARYDATA.DEBUGU116CD346 ");

            strSQL.Append(Choose());

            rdrDEBUGU116CD346.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);

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

        #endregion

        #region " CONTROLS "

        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD346.EP_NBR", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD346.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD346.DOC_PAY_CODE", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD346.DOC_PAY_SUB_CODE", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD346.FACTOR", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD346.DOC_YTDINC", DataTypes.Numeric, 4);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD346.DOC_YTDEAR", DataTypes.Numeric, 4);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD346.DOC_YTDCEA", DataTypes.Numeric, 4);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD346.DOC_YTDCEX", DataTypes.Numeric, 4);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD346.DOC_YRLY_EXPENSE_COMPUTED", DataTypes.Numeric, 9);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD346.DOC_YTDINC_G", DataTypes.Numeric, 4);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD346.W_PAY_POT_G_1", DataTypes.SignedInteger, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD346.W_PAY_POT_G", DataTypes.SignedInteger, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD346.W_PAY_ACTUAL_G", DataTypes.SignedInteger, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD346.W_PAY_ACTUAL_N", DataTypes.SignedInteger, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD346.W_PAYPOT_AMT_NET", DataTypes.SignedInteger, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD346.W_UNDERAGE_ACT", DataTypes.SignedInteger, 10);
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
        //# Do not delete, modify or move it.  Updated: 7/1/2017 2:28:04 PM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "TEMPORARYDATA.DEBUGU116CD346.EP_NBR":
                    return rdrDEBUGU116CD346.GetNumber("EP_NBR").ToString().PadLeft(6, ' ');

                case "TEMPORARYDATA.DEBUGU116CD346.DOC_NBR":
                    return Common.StringToField(rdrDEBUGU116CD346.GetString("DOC_NBR").PadRight(3, ' '));

                case "TEMPORARYDATA.DEBUGU116CD346.DOC_PAY_CODE":
                    return Common.StringToField(rdrDEBUGU116CD346.GetString("DOC_PAY_CODE").PadRight(1, ' '));

                case "TEMPORARYDATA.DEBUGU116CD346.DOC_PAY_SUB_CODE":
                    return Common.StringToField(rdrDEBUGU116CD346.GetString("DOC_PAY_SUB_CODE").PadRight(1, ' '));

                case "TEMPORARYDATA.DEBUGU116CD346.FACTOR":
                    return rdrDEBUGU116CD346.GetNumber("FACTOR").ToString().PadLeft(6, ' ');

                case "TEMPORARYDATA.DEBUGU116CD346.DOC_YTDINC":
                    return rdrDEBUGU116CD346.GetNumber("DOC_YTDINC").ToString().PadLeft(4, ' ');

                case "TEMPORARYDATA.DEBUGU116CD346.DOC_YTDEAR":
                    return rdrDEBUGU116CD346.GetNumber("DOC_YTDEAR").ToString().PadLeft(4, ' ');

                case "TEMPORARYDATA.DEBUGU116CD346.DOC_YTDCEA":
                    return rdrDEBUGU116CD346.GetNumber("DOC_YTDCEA").ToString().PadLeft(4, ' ');

                case "TEMPORARYDATA.DEBUGU116CD346.DOC_YTDCEX":
                    return rdrDEBUGU116CD346.GetNumber("DOC_YTDCEX").ToString().PadLeft(4, ' ');

                case "TEMPORARYDATA.DEBUGU116CD346.DOC_YRLY_EXPENSE_COMPUTED":
                    return rdrDEBUGU116CD346.GetNumber("DOC_YRLY_EXPENSE_COMPUTED").ToString().PadLeft(9, ' ');

                case "TEMPORARYDATA.DEBUGU116CD346.DOC_YTDINC_G":
                    return rdrDEBUGU116CD346.GetNumber("DOC_YTDINC_G").ToString().PadLeft(4, ' ');

                case "TEMPORARYDATA.DEBUGU116CD346.W_PAY_POT_G_1":
                    return rdrDEBUGU116CD346.GetNumber("W_PAY_POT_G_1").ToString().PadLeft(10, ' ');

                case "TEMPORARYDATA.DEBUGU116CD346.W_PAY_POT_G":
                    return rdrDEBUGU116CD346.GetNumber("W_PAY_POT_G").ToString().PadLeft(10, ' ');

                case "TEMPORARYDATA.DEBUGU116CD346.W_PAY_ACTUAL_G":
                    return rdrDEBUGU116CD346.GetNumber("W_PAY_ACTUAL_G").ToString().PadLeft(10, ' ');

                case "TEMPORARYDATA.DEBUGU116CD346.W_PAY_ACTUAL_N":
                    return rdrDEBUGU116CD346.GetNumber("W_PAY_ACTUAL_N").ToString().PadLeft(10, ' ');

                case "TEMPORARYDATA.DEBUGU116CD346.W_PAYPOT_AMT_NET":
                    return rdrDEBUGU116CD346.GetNumber("W_PAYPOT_AMT_NET").ToString().PadLeft(10, ' ');

                case "TEMPORARYDATA.DEBUGU116CD346.W_UNDERAGE_ACT":
                    return rdrDEBUGU116CD346.GetNumber("W_UNDERAGE_ACT").ToString().PadLeft(10, ' ');

                default:
                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_DEBUGU116CD346();

                while (rdrDEBUGU116CD346.Read())
                {
                    WriteData();
                }
                rdrDEBUGU116CD346.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrDEBUGU116CD346 != null))
            {
                rdrDEBUGU116CD346.Close();
                rdrDEBUGU116CD346 = null;
            }
        }

        #endregion

        #endregion
    }
}
