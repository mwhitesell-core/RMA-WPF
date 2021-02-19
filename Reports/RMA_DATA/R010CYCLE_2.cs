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
    public class R010CYCLE_2 : BaseRDLClass
    {
        protected const string REPORT_NAME = "R010CYCLE_2";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrEXTF001AACYCLE = new Reader();
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
        private void Access_EXTF001AACYCLE()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);
            strSQL.Append("SELECT ");
            strSQL.Append("BATCTRL_CALC_AR_DUE ");
            strSQL.Append("FROM TEMPORARYDATA.EXTF001AACYCLE ");

            strSQL.Append(Choose());

            rdrEXTF001AACYCLE.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
            strSQL = null;
        }

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(string.Empty);

            return strChoose.ToString();
        }
        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.FINAL_FOOTING, "TEMPORARYDATA.EXTF001AACYCLE.BATCTRL_CALC_AR_DUE", DataTypes.Numeric, 9);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-09-04 9:47:56 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            // TODO: Remove duplicate controls, if there are any.
            switch (strControl)
            {
                case "TEMPORARYDATA.EXTF001AACYCLE.BATCTRL_CALC_AR_DUE":
                    return rdrEXTF001AACYCLE.GetNumber("BATCTRL_CALC_AR_DUE").ToString();

                default:
                    return string.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                Access_EXTF001AACYCLE();
                while (rdrEXTF001AACYCLE.Read())
                {
                    WriteData();
                }

                rdrEXTF001AACYCLE.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrEXTF001AACYCLE == null))
            {
                rdrEXTF001AACYCLE.Close();
                rdrEXTF001AACYCLE = null;
            }
        }
    }
}
