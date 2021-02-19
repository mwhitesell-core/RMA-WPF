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
    public class SUSPEND_FEE : BaseRDLClass
    {
        protected const string REPORT_NAME = "SUSPEND_FEE";
        protected const bool REPORT_HAS_PARAMETERS = false;

        private Reader rdrF002_SUSPEND_HDR = new Reader();

        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                //  Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;
                Sort = "CLMHDR_DOC_NBR ASC, CLMHDR_AGENT_CD";
                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return ReportData;
        }

        private void Access_F002_SUSPEND_HDR()
         {
            StringBuilder strSQL = new StringBuilder(String.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("CLMHDR_BATCH_NBR, ");
            strSQL.Append("CLMHDR_AGENT_CODE, ");
            strSQL.Append("CLMHDR_ACCOUNTING_NBR, ");
            strSQL.Append("CLMHDR_TOT_CLAIM_AR_OMA, ");
            strSQL.Append("CLMHDR_TOT_CLAIM_AR_OHIP ");
            strSQL.Append("FROM INDEXED.F002_SUSPEND_HDR ");

            strSQL.Append(Choose());

            rdrF002_SUSPEND_HDR.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.m_strFlatFileDictionary, ReportFunctions.TextFiles);

            strSQL = null;
        }

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(String.Empty);

            return strChoose.ToString().ToString();
        }

        private string CLMHDR_DOC_NBR()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = QDesign.Substring(rdrF002_SUSPEND_HDR.GetString("CLMHDR_BATCH_NBR"), 3, 3);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.HEADING_AT, "INDEXED.F002_SUSPEND_HDR.CLMHDR_AGENT_CD", DataTypes.Numeric, 1);
                AddControl(ReportSection.HEADING_AT, "CLMHDR_DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.HEADING_AT, "INDEXED.F002_SUSPEND_HDR.CLMHDR_ACCOUNTING_NBR", DataTypes.Character, 8);
                AddControl(ReportSection.HEADING_AT, "INDEXED.F002_SUSPEND_HDR.CLMHDR_TOT_CLAIM_AR_OMA", DataTypes.Numeric, 7);
                AddControl(ReportSection.HEADING_AT, "INDEXED.F002_SUSPEND_HDR.CLMHDR_TOT_CLAIM_AR_OHIP", DataTypes.Numeric, 7);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2019-04-15 3:48:25 PM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "INDEXED.F002_SUSPEND_HDR.CLMHDR_AGENT_CD":
                    return rdrF002_SUSPEND_HDR.GetNumber("CLMHDR_AGENT_CD").ToString();

                case "CLMHDR_DOC_NBR":
                    return Common.StringToField(CLMHDR_DOC_NBR(), intSize);

                case "INDEXED.F002_SUSPEND_HDR.CLMHDR_ACCOUNTING_NBR":
                    return Common.StringToField(rdrF002_SUSPEND_HDR.GetString("CLMHDR_ACCOUNTING_NBR"));

                case "INDEXED.F002_SUSPEND_HDR.CLMHDR_TOT_CLAIM_AR_OMA":
                    return rdrF002_SUSPEND_HDR.GetNumber("CLMHDR_TOT_CLAIM_AR_OMA").ToString();

                case "INDEXED.F002_SUSPEND_HDR.CLMHDR_TOT_CLAIM_AR_OHIP":
                    return rdrF002_SUSPEND_HDR.GetNumber("CLMHDR_TOT_CLAIM_AR_OHIP").ToString();

                default:
                    return String.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_F002_SUSPEND_HDR();
                while (rdrF002_SUSPEND_HDR.Read())
                {
                    WriteData();
                }
                rdrF002_SUSPEND_HDR.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if (!(rdrF002_SUSPEND_HDR == null))
            {
                rdrF002_SUSPEND_HDR.Close();
                rdrF002_SUSPEND_HDR = null;
            }
        }
    }
}
