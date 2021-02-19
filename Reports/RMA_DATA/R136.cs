//  2015/Apr/15   MC      - original
//  combine eligibility rejects & RA rejects by doctor #
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
    public class R136 : BaseRDLClass
    {
        protected const string REPORT_NAME = "R136";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrR136_DOC = new Reader();
        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                //  Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;
                Sort = "TOTAL_REJECT DESC, CLMHDR_DOC_NBR ASC";
                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return ReportData;
        }
        private void Access_R136_DOC()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: If * is not used to select all columns, ensure the necessary columns (i.e. columns that are used to access records of other tables) are included in the SELECT statement
            strSQL.Append("SELECT ");
            strSQL.Append("TOTAL_REJECT, ");
            strSQL.Append("CLMHDR_DOC_NBR, ");
            strSQL.Append("DOC_DEPT, ");
            strSQL.Append("DOC_NAME, ");
            strSQL.Append("ELIG_REJECT, ");
            strSQL.Append("RA_REJECT ");
            strSQL.Append("FROM TEMPORARYDATA.R136_DOC ");
            strSQL.Append(Choose());
            rdrR136_DOC.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
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
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R136_DOC.DOC_DEPT", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R136_DOC.CLMHDR_DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R136_DOC.DOC_NAME", DataTypes.Character, 24);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R136_DOC.ELIG_REJECT", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R136_DOC.RA_REJECT", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R136_DOC.TOTAL_REJECT", DataTypes.Numeric, 6);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2019-01-29 10:23:43 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            // TODO: Remove duplicate controls, if there are any.
            switch (strControl)
            {
                case "TEMPORARYDATA.R136_DOC.DOC_DEPT":
                    return rdrR136_DOC.GetNumber("DOC_DEPT").ToString();
                case "TEMPORARYDATA.R136_DOC.CLMHDR_DOC_NBR":
                    return Common.StringToField(rdrR136_DOC.GetString("CLMHDR_DOC_NBR"));
                case "TEMPORARYDATA.R136_DOC.DOC_NAME":
                    return Common.StringToField(rdrR136_DOC.GetString("DOC_NAME"));
                case "TEMPORARYDATA.R136_DOC.ELIG_REJECT":
                    return rdrR136_DOC.GetNumber("ELIG_REJECT").ToString();
                case "TEMPORARYDATA.R136_DOC.RA_REJECT":
                    return rdrR136_DOC.GetNumber("RA_REJECT").ToString();
                case "TEMPORARYDATA.R136_DOC.TOTAL_REJECT":
                    return rdrR136_DOC.GetNumber("TOTAL_REJECT").ToString();
                default:
                    return String.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                // TODO: Some manual steps maybe required.
                Access_R136_DOC();
                while (rdrR136_DOC.Read())
                {
                    WriteData();
                }

                rdrR136_DOC.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrR136_DOC == null))
            {
                rdrR136_DOC.Close();
                rdrR136_DOC = null;
            }
        }
    }
}
