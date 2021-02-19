#region "Screen Comments"

// MODIFICATION HISTORY
// 1999/Feb/18          S.B.     - Checked for Y2K.
// 2003/dec/16  A.A.  - alpha doctor nbr

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
    public class DEBUGU114 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "DEBUGU114";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        #endregion
        private Reader rdrDEBUGU114 = new Reader();
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

                Sort = "DOC_NBR";

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

        private void Access_DEBUGU114()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("EP_NBR, ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("DOC_PAY_CODE, ");
            strSQL.Append("DOC_PAY_SUB_CODE, ");
            strSQL.Append("DOC_YRLY_CEILING_COMPUTED, ");
            strSQL.Append("COMA_F112, ");
            strSQL.Append("W_DOC_YRLY_CEILING, ");
            strSQL.Append("W_DOC_YRLY_CEILING_COMPUTED, ");
            strSQL.Append("DOC_YRLY_EXPENSE_COMPUTED, ");
            strSQL.Append("COMX_F112, ");
            strSQL.Append("W_EP_CEIL_EARN, ");
            strSQL.Append("W_EP_CEIL_EARN_ADJ, ");
            strSQL.Append("DOC_ADJCEA, ");
            strSQL.Append("W_NEW_ADJCEA, ");
            strSQL.Append("W_CEIL_EARN_YTD, ");
            strSQL.Append("W_POT_ANNUAL_CALCEARN, ");
            strSQL.Append("W_EP_CEIL_EARN_1, ");
            strSQL.Append("W_DOC_ADJCEA_ABS, ");
            strSQL.Append("W_EP_CEIL_EARN_ACT, ");
            strSQL.Append("W_EP_FISCAL_NBR, ");
            strSQL.Append("W_DOC_YRLY_EXPENSE, ");
            strSQL.Append("W_DOC_YRLY_EXPENSE_COMPUTED, ");
            strSQL.Append("W_EP_CEIL_EXPN, ");
            strSQL.Append("W_CEIL_EXPN_YTD, ");
            strSQL.Append("W_EP_CEIL_EXPN_ACT, ");
            strSQL.Append("DOC_YRLY_EXPN_ALLOC_PERS, ");
            strSQL.Append("DOC_YTDCEA, ");
            strSQL.Append("DOC_YTDCEX, ");
            strSQL.Append("W_EP_TARREV_ACT, ");
            strSQL.Append("W_EP_REQREV_ACT, ");
            strSQL.Append("CORE_RECORD_NUMBER ");
            strSQL.Append("FROM TEMPORARYDATA.DEBUGU114 ");

            strSQL.Append(Choose());

            rdrDEBUGU114.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);

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
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU114.EP_NBR", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU114.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU114.DOC_PAY_CODE", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU114.DOC_PAY_SUB_CODE", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU114.DOC_YRLY_CEILING_COMPUTED", DataTypes.Numeric, 9);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU114.COMA_F112", DataTypes.Numeric, 9);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU114.W_DOC_YRLY_CEILING", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU114.W_DOC_YRLY_CEILING_COMPUTED", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU114.DOC_YRLY_EXPENSE_COMPUTED", DataTypes.Numeric, 9);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU114.COMX_F112", DataTypes.Numeric, 9);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU114.W_EP_CEIL_EARN", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU114.W_EP_CEIL_EARN_ADJ", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU114.DOC_ADJCEA", DataTypes.Numeric, 9);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU114.W_NEW_ADJCEA", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU114.W_CEIL_EARN_YTD", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU114.W_POT_ANNUAL_CALCEARN", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU114.W_EP_CEIL_EARN_1", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU114.W_DOC_ADJCEA_ABS", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU114.W_EP_CEIL_EARN_ACT", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU114.W_EP_FISCAL_NBR", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU114.W_DOC_YRLY_EXPENSE", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU114.W_DOC_YRLY_EXPENSE_COMPUTED", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU114.W_EP_CEIL_EXPN", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU114.W_CEIL_EXPN_YTD", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU114.W_EP_CEIL_EXPN_ACT", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU114.DOC_YRLY_EXPN_ALLOC_PERS", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU114.DOC_YTDCEA", DataTypes.Numeric, 9);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU114.DOC_YTDCEX", DataTypes.Numeric, 9);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU114.W_EP_TARREV_ACT", DataTypes.Numeric, 8);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU114.W_EP_REQREV_ACT", DataTypes.Numeric, 10);
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
                case "TEMPORARYDATA.DEBUGU114.EP_NBR":
                    return rdrDEBUGU114.GetNumber("EP_NBR").ToString().PadLeft(6, ' ');

                case "TEMPORARYDATA.DEBUGU114.DOC_NBR":
                    return Common.StringToField(rdrDEBUGU114.GetString("DOC_NBR").PadRight(3, ' '));

                case "TEMPORARYDATA.DEBUGU114.DOC_PAY_CODE":
                    return Common.StringToField(rdrDEBUGU114.GetString("DOC_PAY_CODE").PadRight(1, ' '));

                case "TEMPORARYDATA.DEBUGU114.DOC_PAY_SUB_CODE":
                    return Common.StringToField(rdrDEBUGU114.GetString("DOC_PAY_SUB_CODE").PadRight(1, ' '));

                case "TEMPORARYDATA.DEBUGU114.DOC_YRLY_CEILING_COMPUTED":
                    return rdrDEBUGU114.GetNumber("DOC_YRLY_CEILING_COMPUTED").ToString().PadLeft(9, ' ');

                case "TEMPORARYDATA.DEBUGU114.COMA_F112":
                    return rdrDEBUGU114.GetNumber("COMA_F112").ToString().PadLeft(9, ' ');

                case "TEMPORARYDATA.DEBUGU114.W_DOC_YRLY_CEILING":
                    return rdrDEBUGU114.GetNumber("W_DOC_YRLY_CEILING").ToString().PadLeft(10, ' ');

                case "TEMPORARYDATA.DEBUGU114.W_DOC_YRLY_CEILING_COMPUTED":
                    return rdrDEBUGU114.GetNumber("W_DOC_YRLY_CEILING_COMPUTED").ToString().PadLeft(10, ' ');

                case "TEMPORARYDATA.DEBUGU114.DOC_YRLY_EXPENSE_COMPUTED":
                    return rdrDEBUGU114.GetNumber("DOC_YRLY_EXPENSE_COMPUTED").ToString().PadLeft(9, ' ');

                case "TEMPORARYDATA.DEBUGU114.COMX_F112":
                    return rdrDEBUGU114.GetNumber("COMX_F112").ToString().PadLeft(9, ' ');

                case "TEMPORARYDATA.DEBUGU114.W_EP_CEIL_EARN":
                    return rdrDEBUGU114.GetNumber("W_EP_CEIL_EARN").ToString().PadLeft(10, ' ');

                case "TEMPORARYDATA.DEBUGU114.W_EP_CEIL_EARN_ADJ":
                    return rdrDEBUGU114.GetNumber("W_EP_CEIL_EARN_ADJ").ToString().PadLeft(10, ' ');

                case "TEMPORARYDATA.DEBUGU114.DOC_ADJCEA":
                    return rdrDEBUGU114.GetNumber("DOC_ADJCEA").ToString().PadLeft(9, ' ');

                case "TEMPORARYDATA.DEBUGU114.W_NEW_ADJCEA":
                    return rdrDEBUGU114.GetNumber("W_NEW_ADJCEA").ToString().PadLeft(10, ' ');

                case "TEMPORARYDATA.DEBUGU114.W_CEIL_EARN_YTD":
                    return rdrDEBUGU114.GetNumber("W_CEIL_EARN_YTD").ToString().PadLeft(10, ' ');

                case "TEMPORARYDATA.DEBUGU114.W_POT_ANNUAL_CALCEARN":
                    return rdrDEBUGU114.GetNumber("W_POT_ANNUAL_CALCEARN").ToString().PadLeft(10, ' ');

                case "TEMPORARYDATA.DEBUGU114.W_EP_CEIL_EARN_1":
                    return rdrDEBUGU114.GetNumber("W_EP_CEIL_EARN_1").ToString().PadLeft(10, ' ');

                case "TEMPORARYDATA.DEBUGU114.W_DOC_ADJCEA_ABS":
                    return rdrDEBUGU114.GetNumber("W_DOC_ADJCEA_ABS").ToString().PadLeft(10, ' ');

                case "TEMPORARYDATA.DEBUGU114.W_EP_CEIL_EARN_ACT":
                    return rdrDEBUGU114.GetNumber("W_EP_CEIL_EARN_ACT").ToString().PadLeft(10, ' ');

                case "TEMPORARYDATA.DEBUGU114.W_EP_FISCAL_NBR":
                    return rdrDEBUGU114.GetNumber("W_EP_FISCAL_NBR").ToString().PadLeft(10, ' ');

                case "TEMPORARYDATA.DEBUGU114.W_DOC_YRLY_EXPENSE":
                    return rdrDEBUGU114.GetNumber("W_DOC_YRLY_EXPENSE").ToString().PadLeft(10, ' ');

                case "TEMPORARYDATA.DEBUGU114.W_DOC_YRLY_EXPENSE_COMPUTED":
                    return rdrDEBUGU114.GetNumber("W_DOC_YRLY_EXPENSE_COMPUTED").ToString().PadLeft(10, ' ');

                case "TEMPORARYDATA.DEBUGU114.W_EP_CEIL_EXPN":
                    return rdrDEBUGU114.GetNumber("W_EP_CEIL_EXPN").ToString().PadLeft(10, ' ');

                case "TEMPORARYDATA.DEBUGU114.W_CEIL_EXPN_YTD":
                    return rdrDEBUGU114.GetNumber("W_CEIL_EXPN_YTD").ToString().PadLeft(10, ' ');

                case "TEMPORARYDATA.DEBUGU114.W_EP_CEIL_EXPN_ACT":
                    return rdrDEBUGU114.GetNumber("W_EP_CEIL_EXPN_ACT").ToString().PadLeft(10, ' ');

                case "TEMPORARYDATA.DEBUGU114.DOC_YRLY_EXPN_ALLOC_PERS":
                    return rdrDEBUGU114.GetNumber("DOC_YRLY_EXPN_ALLOC_PERS").ToString().PadLeft(2, ' ');

                case "TEMPORARYDATA.DEBUGU114.DOC_YTDCEA":
                    return rdrDEBUGU114.GetNumber("DOC_YTDCEA").ToString().PadLeft(9, ' ');

                case "TEMPORARYDATA.DEBUGU114.DOC_YTDCEX":
                    return rdrDEBUGU114.GetNumber("DOC_YTDCEX").ToString().PadLeft(9, ' ');

                case "TEMPORARYDATA.DEBUGU114.W_EP_TARREV_ACT":
                    return rdrDEBUGU114.GetNumber("W_EP_TARREV_ACT").ToString().PadLeft(8, ' ');

                case "TEMPORARYDATA.DEBUGU114.W_EP_REQREV_ACT":
                    return rdrDEBUGU114.GetNumber("W_EP_REQREV_ACT").ToString().PadLeft(10, ' ');

                default:
                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_DEBUGU114();

                while (rdrDEBUGU114.Read())
                {
                    WriteData();
                }
                rdrDEBUGU114.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrDEBUGU114 != null))
            {
                rdrDEBUGU114.Close();
                rdrDEBUGU114 = null;
            }
        }

        #endregion

        #endregion
    }
}
