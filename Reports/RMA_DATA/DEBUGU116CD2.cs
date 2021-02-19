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
    public class DEBUGU116CD2 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "DEBUGU116CD2";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrDEBUGU116CD2 = new Reader();

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

        private void Access_DEBUGU116CD2()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("EP_NBR, ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("DOC_PAY_CODE, ");
            strSQL.Append("DOC_PAY_SUB_CODE, ");
            strSQL.Append("FACTOR, ");
            strSQL.Append("AMT_NET, ");
            strSQL.Append("W_PAYPOT_AMT_NET, ");
            strSQL.Append("CORE_RECORD_NUMBER, ");
            strSQL.Append("W_PAYPOT_AMT_NET_2, ");
            strSQL.Append("W_AMT_NET_F110_YTDINC, ");
            strSQL.Append("W_AMT_NET_F110_YTDEAR, ");
            strSQL.Append("W_PAYPOT_AMT_NET_3, ");
            strSQL.Append("W_PAYPOT_AMT_NET_4, ");
            strSQL.Append("W_AMT_ADVOUT, ");
            strSQL.Append("ADVOUT_SEQ, ");
            strSQL.Append("W_AMT_NET_F110_TOTADV, ");
            strSQL.Append("TOTADV_FLAG ");
            strSQL.Append("FROM TEMPORARYDATA.DEBUGU116CD2 ");

            strSQL.Append(Choose());

            rdrDEBUGU116CD2.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);

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
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD2.EP_NBR", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD2.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD2.DOC_PAY_CODE", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD2.DOC_PAY_SUB_CODE", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD2.W_PAYPOT_AMT_NET_2", DataTypes.SignedInteger, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD2.W_AMT_NET_F110_YTDINC", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD2.W_AMT_NET_F110_YTDEAR", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD2.FACTOR", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD2.W_PAYPOT_AMT_NET_3", DataTypes.SignedInteger, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD2.W_PAYPOT_AMT_NET_4", DataTypes.SignedInteger, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD2.AMT_NET", DataTypes.Numeric, 9);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD2.W_AMT_ADVOUT", DataTypes.SignedInteger, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD2.W_PAYPOT_AMT_NET", DataTypes.SignedInteger, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD2.ADVOUT_SEQ", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD2.W_AMT_NET_F110_TOTADV", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD2.TOTADV_FLAG", DataTypes.Character, 1);
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
                case "TEMPORARYDATA.DEBUGU116CD2.EP_NBR":
                    return rdrDEBUGU116CD2.GetNumber("EP_NBR").ToString().PadLeft(6, ' ');

                case "TEMPORARYDATA.DEBUGU116CD2.DOC_NBR":
                    return Common.StringToField(rdrDEBUGU116CD2.GetString("DOC_NBR").PadRight(3, ' '));

                case "TEMPORARYDATA.DEBUGU116CD2.DOC_PAY_CODE":
                    return Common.StringToField(rdrDEBUGU116CD2.GetString("DOC_PAY_CODE").PadRight(1, ' '));

                case "TEMPORARYDATA.DEBUGU116CD2.DOC_PAY_SUB_CODE":
                    return Common.StringToField(rdrDEBUGU116CD2.GetString("DOC_PAY_SUB_CODE").PadRight(1, ' '));

                case "TEMPORARYDATA.DEBUGU116CD2.W_PAYPOT_AMT_NET_2":
                    return rdrDEBUGU116CD2.GetNumber("W_PAYPOT_AMT_NET_2").ToString().PadLeft(10, ' ');

                case "TEMPORARYDATA.DEBUGU116CD2.W_AMT_NET_F110_YTDINC":
                    return rdrDEBUGU116CD2.GetNumber("W_AMT_NET_F110_YTDINC").ToString().PadLeft(10, ' ');

                case "TEMPORARYDATA.DEBUGU116CD2.W_AMT_NET_F110_YTDEAR":
                    return rdrDEBUGU116CD2.GetNumber("W_AMT_NET_F110_YTDEAR").ToString().PadLeft(10, ' ');

                case "TEMPORARYDATA.DEBUGU116CD2.FACTOR":
                    return rdrDEBUGU116CD2.GetNumber("FACTOR").ToString().PadLeft(6, ' ');

                case "TEMPORARYDATA.DEBUGU116CD2.W_PAYPOT_AMT_NET_3":
                    return rdrDEBUGU116CD2.GetNumber("W_PAYPOT_AMT_NET_3").ToString().PadLeft(10, ' ');

                case "TEMPORARYDATA.DEBUGU116CD2.W_PAYPOT_AMT_NET_4":
                    return rdrDEBUGU116CD2.GetNumber("W_PAYPOT_AMT_NET_4").ToString().PadLeft(10, ' ');

                case "TEMPORARYDATA.DEBUGU116CD2.AMT_NET":
                    return rdrDEBUGU116CD2.GetNumber("AMT_NET").ToString().PadLeft(10, ' ');

                case "TEMPORARYDATA.DEBUGU116CD2.W_AMT_ADVOUT":
                    return rdrDEBUGU116CD2.GetNumber("W_AMT_ADVOUT").ToString().PadLeft(10, ' ');

                case "TEMPORARYDATA.DEBUGU116CD2.W_PAYPOT_AMT_NET":
                    return rdrDEBUGU116CD2.GetNumber("W_PAYPOT_AMT_NET").ToString().PadLeft(10, ' ');

                case "TEMPORARYDATA.DEBUGU116CD2.ADVOUT_SEQ":
                    return rdrDEBUGU116CD2.GetNumber("ADVOUT_SEQ").ToString().PadLeft(2, ' ');

                case "TEMPORARYDATA.DEBUGU116CD2.W_AMT_NET_F110_TOTADV":
                    return rdrDEBUGU116CD2.GetNumber("W_AMT_NET_F110_TOTADV").ToString().PadLeft(10, ' ');

                case "TEMPORARYDATA.DEBUGU116CD2.TOTADV_FLAG":
                    return Common.StringToField(rdrDEBUGU116CD2.GetString("TOTADV_FLAG").PadRight(1, ' '));

                default:
                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_DEBUGU116CD2();

                while (rdrDEBUGU116CD2.Read())
                {
                    WriteData();
                }
                rdrDEBUGU116CD2.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrDEBUGU116CD2 != null))
            {
                rdrDEBUGU116CD2.Close();
                rdrDEBUGU116CD2 = null;
            }
        }

        #endregion

        #endregion
    }
}
