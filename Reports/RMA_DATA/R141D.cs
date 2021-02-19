//  #> PROGRAM-ID.     R141D.QZS
//  ((C)) Dyad Infosys LTD  
//  PROGRAM PURPOSE : PRINT automatic Miscelleanous payment batches                              
//  MODIFICATION HISTORY
//  DATE   WHO          DESCRIPTION
//  2015/Nov/16 M.C.         - ORIGINAL
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
    public class R141D : BaseRDLClass
    {
        protected const string REPORT_NAME = "R141D";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrU141C_PAY_BATCHES = new Reader();
        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                //  Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;
                Sort = "";
                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return ReportData;
        }
        private void Access_U141C_PAY_BATCHES()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: If * is not used to select all columns, ensure the necessary columns (i.e. columns that are used to access records of other tables) are included in the SELECT statement
            strSQL.Append("SELECT ");
            strSQL.Append("BATCTRL_MANUAL_PAY_TOT, ");
            strSQL.Append("BATCTRL_BATCH_NBR ");
            strSQL.Append("FROM TEMPORARYDATA.U141C_PAY_BATCHES ");
            strSQL.Append(Choose());
            rdrU141C_PAY_BATCHES.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
            strSQL = null;
        }

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(String.Empty);
            // TODO: CHOOSE Statement - May require manual changes.
            return strChoose.ToString().ToString();
        }
        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U141C_PAY_BATCHES.BATCTRL_BATCH_NBR", DataTypes.Character, 8);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U141C_PAY_BATCHES.BATCTRL_MANUAL_PAY_TOT", DataTypes.Numeric, 10);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-05-15 1:46:05 PM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            // TODO: Remove duplicate controls, if there are any.
            switch (strControl)
            {
                case "TEMPORARYDATA.U141C_PAY_BATCHES.BATCTRL_BATCH_NBR":
                    return Common.StringToField(rdrU141C_PAY_BATCHES.GetString("BATCTRL_BATCH_NBR"));
                case "TEMPORARYDATA.U141C_PAY_BATCHES.BATCTRL_MANUAL_PAY_TOT":
                    return rdrU141C_PAY_BATCHES.GetNumber("BATCTRL_MANUAL_PAY_TOT").ToString();
                default:
                    return String.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                // TODO: Some manual steps maybe required.
                Access_U141C_PAY_BATCHES();
                while (rdrU141C_PAY_BATCHES.Read())
                {
                    WriteData();
                }

                rdrU141C_PAY_BATCHES.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrU141C_PAY_BATCHES == null))
            {
                rdrU141C_PAY_BATCHES.Close();
                rdrU141C_PAY_BATCHES = null;
            }
        }
    }
}
