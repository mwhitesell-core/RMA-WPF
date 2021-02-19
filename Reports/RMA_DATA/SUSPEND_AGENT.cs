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
    public class SUSPEND_AGENT : BaseRDLClass
    {
        protected const string REPORT_NAME = "SUSPEND_AGENT";
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
                Sort = "CLMHDR_DOC_NBR ASC, CLMHDR_AGENT_CD ASC";
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
            strSQL.Append("CLMHDR_AGENT_CD, ");
            strSQL.Append("CLMHDR_DOC_NBR, ");
            strSQL.Append("CLMHDR_ACCOUNTING_NBR, ");
            strSQL.Append("CLMHDR_PAT_ACRONYM6, ");
            strSQL.Append(" CLMHDR_PAT_ACRONYM3 ");
            strSQL.Append("FROM INDEXED.F002_SUSPEND_HDR ");
            strSQL.Append(Choose());
            rdrF002_SUSPEND_HDR.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.m_strFlatFileDictionary, ReportFunctions.TextFiles);
            strSQL = null;
        }

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(String.Empty);
            // TODO: CHOOSE Statement - May require manual changes.
            return strChoose.ToString().ToString();
        }

        public override bool SelectIf()
        {
            bool blnSelected = false;
            if ((QDesign.NULL(rdrF002_SUSPEND_HDR.GetNumber("CLMHDR_AGENT_CD")) != QDesign.NULL(0d)))
            {
                blnSelected = true;
            }

            return blnSelected;
        }

        private string F002_SUSPEND_HDR_CLMHDR_PAT_ACRONYM()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = (rdrF002_SUSPEND_HDR.GetString("CLMHDR_PAT_ACRONYM6") + rdrF002_SUSPEND_HDR.GetString("CLMHDR_PAT_ACRONYM3"));
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
                AddControl(ReportSection.REPORT, "INDEXED.F002_SUSPEND_HDR.CLMHDR_AGENT_CD", DataTypes.Numeric, 1);
                AddControl(ReportSection.REPORT, "INDEXED.F002_SUSPEND_HDR.CLMHDR_DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "INDEXED.F002_SUSPEND_HDR.CLMHDR_ACCOUNTING_NBR", DataTypes.Character, 8);
                AddControl(ReportSection.REPORT, "CLMHDR_PAT_ACRONYM", DataTypes.Character, 9);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-05-16 12:45:41 PM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            // TODO: Remove duplicate controls, if there are any.
            switch (strControl)
            {
                case "INDEXED.F002_SUSPEND_HDR.CLMHDR_AGENT_CD":
                    return rdrF002_SUSPEND_HDR.GetNumber("CLMHDR_AGENT_CD").ToString();
                case "INDEXED.F002_SUSPEND_HDR.CLMHDR_DOC_NBR":
                    return Common.StringToField(rdrF002_SUSPEND_HDR.GetString("CLMHDR_DOC_NBR"));
                case "INDEXED.F002_SUSPEND_HDR.CLMHDR_ACCOUNTING_NBR":
                    return Common.StringToField(rdrF002_SUSPEND_HDR.GetString("CLMHDR_ACCOUNTING_NBR"));
                case "CLMHDR_PAT_ACRONYM":
                    return Common.StringToField(F002_SUSPEND_HDR_CLMHDR_PAT_ACRONYM(), intSize);
                default:
                    return String.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                // TODO: Some manual steps maybe required.
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
