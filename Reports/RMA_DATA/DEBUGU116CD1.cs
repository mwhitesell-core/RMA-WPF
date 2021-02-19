#region "Screen Comments"

// MODIFICATION HISTORY
// 1999/Feb/18          S.B.     - Checked for Y2K.
// 2002/Nov/28          M.C.     - use debugu116cd346 instead of debugu116cd34

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
    public class DEBUGU116CD1 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "DEBUGU116CD1";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrDEBUGU116CD1 = new Reader();

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

        private void Access_DEBUGU116CD1()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("EP_NBR, ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("DOC_PAY_CODE, ");
            strSQL.Append("DOC_PAY_SUB_CODE, ");
            strSQL.Append("FACTOR, ");
            strSQL.Append("DOC_YTDEAR, ");
            strSQL.Append("DOC_YTDINC, ");
            strSQL.Append("DOC_YTDCEA, ");
            strSQL.Append("DOC_YTDGUA, ");
            strSQL.Append("DOC_YTDGUB, ");
            strSQL.Append("DOC_YTDGUC, ");
            strSQL.Append("DOC_YTDGUD, ");
            strSQL.Append("NEW_DOC_YTDEAR, ");
            strSQL.Append("NEW_DOC_YTDGUA, ");
            strSQL.Append("NEW_DOC_YTDGUB, ");
            strSQL.Append("NEW_DOC_YTDGUC, ");
            strSQL.Append("NEW_DOC_YTDGUD, ");
            strSQL.Append("NEW_DOC_YTDINC, ");
            strSQL.Append("AMT_NET, ");
            strSQL.Append("W_ACTUAL_D_PAYMENT, ");
            strSQL.Append("W_DOC_YRLY_CEIL_GUAR, ");
            strSQL.Append("W_DOC_YRLY_CEILING, ");
            strSQL.Append("W_DOC_YRLY_CEILING_GUAR_FACTOR, ");
            strSQL.Append("W_EXCESS_INCOME, ");
            strSQL.Append("W_PAYPOT_AMT_GROSS, ");
            strSQL.Append("W_PAYPOT_AMT_NET_1, ");
            strSQL.Append("W_PAYPOT_AMT_NET_2, ");
            strSQL.Append("W_PAYPOT_AMT_NET_3, ");
            strSQL.Append("W_PAYPOT_AMT_NET_4, ");
            strSQL.Append("W_AMT_ADVOUT, ");
            strSQL.Append("W_PAYPOT_AMT_NET_FINAL, ");
            strSQL.Append("W_PAYPOT_B_2, ");
            strSQL.Append("W_POTGUAR_AMT_NET, ");
            strSQL.Append("W_POT_D_PAYMENT, ");
            strSQL.Append("W_POT_D_YTD_PAYMENTS, ");
            strSQL.Append("W_POT_YTDGUB, ");
            strSQL.Append("W_TRUE_YTDINC, ");
            strSQL.Append("W_TRUE_YTDINC_PLUS_CEIEAR, ");
            strSQL.Append("W_YTDCEA_MINUS_YTDEAR, ");
            strSQL.Append("W_YTDCEA_MINUS_YTDEAR_X_GUAR_PER, ");
            strSQL.Append("W_YTD_COMPUTED_CEIEAR, ");
            strSQL.Append("W_PAYPOT_YTD, ");
            strSQL.Append("W_UNDERAGE_ACT ");
            strSQL.Append("FROM TEMPORARYDATA.DEBUGU116CD1 ");

            strSQL.Append(Choose());

            rdrDEBUGU116CD1.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);

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
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD1.EP_NBR", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD1.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD1.DOC_PAY_CODE", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD1.DOC_PAY_SUB_CODE", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD1.FACTOR", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD1.DOC_YTDEAR", DataTypes.Numeric, 9);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD1.DOC_YTDINC", DataTypes.Numeric, 9);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD1.DOC_YTDCEA", DataTypes.Numeric, 9);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD1.DOC_YTDGUA", DataTypes.Numeric, 9);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD1.DOC_YTDGUB", DataTypes.Numeric, 9);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD1.DOC_YTDGUC", DataTypes.Numeric, 9);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD1.DOC_YTDGUD", DataTypes.Numeric, 9);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD1.NEW_DOC_YTDEAR", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD1.NEW_DOC_YTDGUA", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD1.NEW_DOC_YTDGUB", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD1.NEW_DOC_YTDGUC", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD1.NEW_DOC_YTDGUD", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD1.NEW_DOC_YTDINC", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD1.AMT_NET", DataTypes.Numeric, 18);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD1.W_ACTUAL_D_PAYMENT", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD1.W_DOC_YRLY_CEIL_GUAR", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD1.W_DOC_YRLY_CEILING", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD1.W_DOC_YRLY_CEILING_GUAR_FACTOR", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD1.W_EXCESS_INCOME", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD1.W_PAYPOT_AMT_GROSS", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD1.W_PAYPOT_AMT_NET_1", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD1.W_PAYPOT_AMT_NET_2", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD1.W_PAYPOT_AMT_NET_3", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD1.W_PAYPOT_AMT_NET_4", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD1.W_AMT_ADVOUT", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD1.W_PAYPOT_AMT_NET_FINAL", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD1.W_PAYPOT_B_2", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD1.W_POTGUAR_AMT_NET", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD1.W_POT_D_PAYMENT", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD1.W_POT_D_YTD_PAYMENTS", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD1.W_POT_YTDGUB", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD1.W_TRUE_YTDINC", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD1.W_TRUE_YTDINC_PLUS_CEIEAR", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD1.W_YTDCEA_MINUS_YTDEAR", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD1.W_YTDCEA_MINUS_YTDEAR_X_GUAR_PER", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD1.W_YTD_COMPUTED_CEIEAR", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD1.W_PAYPOT_YTD", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD1.W_UNDERAGE_ACT", DataTypes.Numeric, 10);
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
                case "TEMPORARYDATA.DEBUGU116CD1.EP_NBR":
                    return rdrDEBUGU116CD1.GetNumber("EP_NBR").ToString().PadLeft(6, ' ');

                case "TEMPORARYDATA.DEBUGU116CD1.DOC_NBR":
                    return Common.StringToField(rdrDEBUGU116CD1.GetString("DOC_NBR").PadRight(3, ' '));

                case "TEMPORARYDATA.DEBUGU116CD1.DOC_PAY_CODE":
                    return Common.StringToField(rdrDEBUGU116CD1.GetString("DOC_PAY_CODE").PadRight(1, ' '));

                case "TEMPORARYDATA.DEBUGU116CD1.DOC_PAY_SUB_CODE":
                    return Common.StringToField(rdrDEBUGU116CD1.GetString("DOC_PAY_SUB_CODE").PadRight(1, ' '));

                case "TEMPORARYDATA.DEBUGU116CD1.FACTOR":
                    return rdrDEBUGU116CD1.GetNumber("FACTOR").ToString().PadLeft(6, ' ');

                case "TEMPORARYDATA.DEBUGU116CD1.DOC_YTDEAR":
                    return rdrDEBUGU116CD1.GetNumber("DOC_YTDEAR").ToString().PadLeft(9, ' ');

                case "TEMPORARYDATA.DEBUGU116CD1.DOC_YTDINC":
                    return rdrDEBUGU116CD1.GetNumber("DOC_YTDINC").ToString().ToString().PadLeft(9, ' ');

                case "TEMPORARYDATA.DEBUGU116CD1.DOC_YTDCEA":
                    return rdrDEBUGU116CD1.GetNumber("DOC_YTDCEA").ToString().PadLeft(9, ' ');

                case "TEMPORARYDATA.DEBUGU116CD1.DOC_YTDGUA":
                    return rdrDEBUGU116CD1.GetNumber("DOC_YTDGUA").ToString().PadLeft(9, ' ');

                case "TEMPORARYDATA.DEBUGU116CD1.DOC_YTDGUB":
                    return rdrDEBUGU116CD1.GetNumber("DOC_YTDGUB").ToString().PadLeft(9, ' ');

                case "TEMPORARYDATA.DEBUGU116CD1.DOC_YTDGUC":
                    return rdrDEBUGU116CD1.GetNumber("DOC_YTDGUC").ToString().PadLeft(9, ' ');

                case "TEMPORARYDATA.DEBUGU116CD1.DOC_YTDGUD":
                    return rdrDEBUGU116CD1.GetNumber("DOC_YTDGUD").ToString().PadLeft(9, ' ');

                case "TEMPORARYDATA.DEBUGU116CD1.NEW_DOC_YTDEAR":
                    return rdrDEBUGU116CD1.GetNumber("NEW_DOC_YTDEAR").ToString().PadLeft(13, ' ');

                case "TEMPORARYDATA.DEBUGU116CD1.NEW_DOC_YTDGUA":
                    return rdrDEBUGU116CD1.GetNumber("NEW_DOC_YTDGUA").ToString().PadLeft(13, ' ');

                case "TEMPORARYDATA.DEBUGU116CD1.NEW_DOC_YTDGUB":
                    return rdrDEBUGU116CD1.GetNumber("NEW_DOC_YTDGUB").ToString().PadLeft(13, ' ');

                case "TEMPORARYDATA.DEBUGU116CD1.NEW_DOC_YTDGUC":
                    return rdrDEBUGU116CD1.GetNumber("NEW_DOC_YTDGUC").ToString().PadLeft(13, ' ');

                case "TEMPORARYDATA.DEBUGU116CD1.NEW_DOC_YTDGUD":
                    return rdrDEBUGU116CD1.GetNumber("NEW_DOC_YTDGUD").ToString().PadLeft(13, ' ');

                case "TEMPORARYDATA.DEBUGU116CD1.NEW_DOC_YTDINC":
                    return rdrDEBUGU116CD1.GetNumber("NEW_DOC_YTDINC").ToString().PadLeft(13, ' ');

                case "TEMPORARYDATA.DEBUGU116CD1.AMT_NET":
                    return rdrDEBUGU116CD1.GetNumber("AMT_NET").ToString().PadLeft(10, ' ');

                case "TEMPORARYDATA.DEBUGU116CD1.W_ACTUAL_D_PAYMENT":
                    return rdrDEBUGU116CD1.GetNumber("W_ACTUAL_D_PAYMENT").ToString().PadLeft(13, ' ');

                case "TEMPORARYDATA.DEBUGU116CD1.W_DOC_YRLY_CEIL_GUAR":
                    return rdrDEBUGU116CD1.GetNumber("W_DOC_YRLY_CEIL_GUAR").ToString().PadLeft(13, ' ');

                case "TEMPORARYDATA.DEBUGU116CD1.W_DOC_YRLY_CEILING":
                    return rdrDEBUGU116CD1.GetNumber("W_DOC_YRLY_CEILING").ToString().PadLeft(13, ' ');

                case "TEMPORARYDATA.DEBUGU116CD1.W_DOC_YRLY_CEILING_GUAR_FACTOR":
                    return rdrDEBUGU116CD1.GetNumber("W_DOC_YRLY_CEILING_GUAR_FACTOR").ToString().PadLeft(13, ' ');

                case "TEMPORARYDATA.DEBUGU116CD1.W_EXCESS_INCOME":
                    return rdrDEBUGU116CD1.GetNumber("W_EXCESS_INCOME").ToString().PadLeft(13, ' ');

                case "TEMPORARYDATA.DEBUGU116CD1.W_PAYPOT_AMT_GROSS":
                    return rdrDEBUGU116CD1.GetNumber("W_PAYPOT_AMT_GROSS").ToString().PadLeft(13, ' ');

                case "TEMPORARYDATA.DEBUGU116CD1.W_PAYPOT_AMT_NET_1":
                    return rdrDEBUGU116CD1.GetNumber("W_PAYPOT_AMT_NET_1").ToString().PadLeft(13, ' ');

                case "TEMPORARYDATA.DEBUGU116CD1.W_PAYPOT_AMT_NET_2":
                    return rdrDEBUGU116CD1.GetNumber("W_PAYPOT_AMT_NET_2").ToString().PadLeft(13, ' ');

                case "TEMPORARYDATA.DEBUGU116CD1.W_PAYPOT_AMT_NET_3":
                    return rdrDEBUGU116CD1.GetNumber("W_PAYPOT_AMT_NET_3").ToString().PadLeft(13, ' ');

                case "TEMPORARYDATA.DEBUGU116CD1.W_PAYPOT_AMT_NET_4":
                    return rdrDEBUGU116CD1.GetNumber("W_PAYPOT_AMT_NET_4").ToString().PadLeft(13, ' ');

                case "TEMPORARYDATA.DEBUGU116CD1.W_AMT_ADVOUT":
                    return rdrDEBUGU116CD1.GetNumber("W_AMT_ADVOUT").ToString().PadLeft(13, ' ');

                case "TEMPORARYDATA.DEBUGU116CD1.W_PAYPOT_AMT_NET_FINAL":
                    return rdrDEBUGU116CD1.GetNumber("W_PAYPOT_AMT_NET_FINAL").ToString().PadLeft(13, ' ');

                case "TEMPORARYDATA.DEBUGU116CD1.W_PAYPOT_B_2":
                    return rdrDEBUGU116CD1.GetNumber("W_PAYPOT_B_2").ToString().PadLeft(13, ' ');

                case "TEMPORARYDATA.DEBUGU116CD1.W_POTGUAR_AMT_NET":
                    return rdrDEBUGU116CD1.GetNumber("W_POTGUAR_AMT_NET").ToString().PadLeft(13, ' ');

                case "TEMPORARYDATA.DEBUGU116CD1.W_POT_D_PAYMENT":
                    return rdrDEBUGU116CD1.GetNumber("W_POT_D_PAYMENT").ToString().PadLeft(13, ' ');

                case "TEMPORARYDATA.DEBUGU116CD1.W_POT_D_YTD_PAYMENTS":
                    return rdrDEBUGU116CD1.GetNumber("W_POT_D_YTD_PAYMENTS").ToString().PadLeft(13, ' ');

                case "TEMPORARYDATA.DEBUGU116CD1.W_POT_YTDGUB":
                    return rdrDEBUGU116CD1.GetNumber("W_POT_YTDGUB").ToString().PadLeft(13, ' ');

                case "TEMPORARYDATA.DEBUGU116CD1.W_TRUE_YTDINC":
                    return rdrDEBUGU116CD1.GetNumber("W_TRUE_YTDINC").ToString().PadLeft(13, ' ');

                case "TEMPORARYDATA.DEBUGU116CD1.W_TRUE_YTDINC_PLUS_CEIEAR":
                    return rdrDEBUGU116CD1.GetNumber("W_TRUE_YTDINC_PLUS_CEIEAR").ToString().PadLeft(13, ' ');

                case "TEMPORARYDATA.DEBUGU116CD1.W_YTDCEA_MINUS_YTDEAR":
                    return rdrDEBUGU116CD1.GetNumber("W_YTDCEA_MINUS_YTDEAR").ToString().PadLeft(13, ' ');

                case "TEMPORARYDATA.DEBUGU116CD1.W_YTDCEA_MINUS_YTDEAR_X_GUAR_PER":
                    return rdrDEBUGU116CD1.GetNumber("W_YTDCEA_MINUS_YTDEAR_X_GUAR_PER").ToString().PadLeft(13, ' ');

                case "TEMPORARYDATA.DEBUGU116CD1.W_YTD_COMPUTED_CEIEAR":
                    return rdrDEBUGU116CD1.GetNumber("W_YTD_COMPUTED_CEIEAR").ToString().PadLeft(13, ' ');

                case "TEMPORARYDATA.DEBUGU116CD1.W_PAYPOT_YTD":
                    return rdrDEBUGU116CD1.GetNumber("W_PAYPOT_YTD").ToString().PadLeft(13, ' ');

                case "TEMPORARYDATA.DEBUGU116CD1.W_UNDERAGE_ACT":
                    return rdrDEBUGU116CD1.GetNumber("W_UNDERAGE_ACT").ToString().PadLeft(11, ' ');

                default:
                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_DEBUGU116CD1();

                while (rdrDEBUGU116CD1.Read())
                {
                    WriteData();
                }
                rdrDEBUGU116CD1.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrDEBUGU116CD1 != null))
            {
                rdrDEBUGU116CD1.Close();
                rdrDEBUGU116CD1 = null;
            }
        }

        #endregion

        #endregion
    }
}
