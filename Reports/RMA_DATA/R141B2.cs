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
    public class R141B2 : BaseRDLClass
    {
        protected const string REPORT_NAME = "R141B2";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrU141A_VALID = new Reader();
        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                //  Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;
                Sort = "CLINIC_NBR ASC, HDR_AGENT_CD ASC";
                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return ReportData;
        }
        private void Access_U141A_VALID()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: If * is not used to select all columns, ensure the necessary columns (i.e. columns that are used to access records of other tables) are included in the SELECT statement
            strSQL.Append("SELECT ");
            strSQL.Append("CLINIC_NBR, ");
            strSQL.Append("HDR_AGENT_CD, ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("DOC_NAME, ");
            strSQL.Append("CLMDTL_OMA_CD, ");
            strSQL.Append("SIGNED_AMT_NET, ");
            strSQL.Append("CLMHDR_REFERENCE, ");
            strSQL.Append("BYPASS_EDIT ");
            strSQL.Append("FROM TEMPORARYDATA.U141A_VALID ");
            strSQL.Append(Choose());
            rdrU141A_VALID.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
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
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U141A_VALID.CLINIC_NBR", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U141A_VALID.HDR_AGENT_CD", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U141A_VALID.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U141A_VALID.DOC_NAME", DataTypes.Character, 24);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U141A_VALID.CLMDTL_OMA_CD", DataTypes.Character, 4);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U141A_VALID.SIGNED_AMT_NET", DataTypes.Numeric, 9);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U141A_VALID.CLMHDR_REFERENCE", DataTypes.Character, 11);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U141A_VALID.BYPASS_EDIT", DataTypes.Character, 6);
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
                case "TEMPORARYDATA.U141A_VALID.CLINIC_NBR":
                    return rdrU141A_VALID.GetNumber("CLINIC_NBR").ToString();
                case "TEMPORARYDATA.U141A_VALID.HDR_AGENT_CD":
                    return Common.StringToField(rdrU141A_VALID.GetString("HDR_AGENT_CD"));
                case "TEMPORARYDATA.U141A_VALID.DOC_NBR":
                    return Common.StringToField(rdrU141A_VALID.GetString("DOC_NBR"));
                case "TEMPORARYDATA.U141A_VALID.DOC_NAME":
                    return Common.StringToField(rdrU141A_VALID.GetString("DOC_NAME"));
                case "TEMPORARYDATA.U141A_VALID.CLMDTL_OMA_CD":
                    return Common.StringToField(rdrU141A_VALID.GetString("CLMDTL_OMA_CD"));
                case "TEMPORARYDATA.U141A_VALID.SIGNED_AMT_NET":
                    return rdrU141A_VALID.GetNumber("SIGNED_AMT_NET").ToString();
                case "TEMPORARYDATA.U141A_VALID.CLMHDR_REFERENCE":
                    return Common.StringToField(rdrU141A_VALID.GetString("CLMHDR_REFERENCE"));
                case "TEMPORARYDATA.U141A_VALID.BYPASS_EDIT":
                    return Common.StringToField(rdrU141A_VALID.GetString("BYPASS_EDIT"));
                default:
                    return String.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                // TODO: Some manual steps maybe required.
                Access_U141A_VALID();
                while (rdrU141A_VALID.Read())
                {
                    WriteData();
                }

                rdrU141A_VALID.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrU141A_VALID == null))
            {
                rdrU141A_VALID.Close();
                rdrU141A_VALID = null;
            }
        }
    }
}
