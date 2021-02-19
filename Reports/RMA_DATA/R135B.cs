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
    public class R135B : BaseRDLClass
    {
        protected const string REPORT_NAME = "R135B";
        protected const bool REPORT_HAS_PARAMETERS = true;
        private Reader rdrR135 = new Reader();
        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                //  Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;
                Sort = "CLMHDR_DOC_NBR ASC, RAT_REJECTED_CLAIM ASC, X_CODE DESC";
                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return ReportData;
        }
        private void Access_R135()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: If * is not used to select all columns, ensure the necessary columns (i.e. columns that are used to access records of other tables) are included in the SELECT statement
            strSQL.Append("SELECT ");
            strSQL.Append("CLMHDR_DOC_NBR, ");
            strSQL.Append("DOC_DEPT, ");
            strSQL.Append("RAT_REJECTED_CLAIM, ");
            strSQL.Append("DOC_NAME, ");
            strSQL.Append("X_CODE, ");
            strSQL.Append("CLMDTL_SV_DATE, ");
            strSQL.Append("PAT_HEALTH_NBR, ");
            strSQL.Append("PAT_VERSION_CD, ");
            strSQL.Append("OHIP_ERR_CODE, ");
            strSQL.Append("X_DESC ");
            strSQL.Append("FROM TEMPORARYDATA.R135 ");
            strSQL.Append(Choose());
            rdrR135.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
            strSQL = null;
        }

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(String.Empty);
            // TODO: CHOOSE Statement - May require manual changes.
            return strChoose.ToString().ToString();
        }

        private string X_RUN_TYPE()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = QDesign.NULL(ReportFunctions.astrScreenParameters[0].ToString());
                //  Prompt String: "Enter either `REGULAR` or `PORTAL` : " _
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_DOC_DEPT_NBR()
        {
            string strReturnValue = String.Empty;
            try
            {
                if (QDesign.NULL(X_RUN_TYPE()) == "PORTAL")
                {
                    strReturnValue = "~" + rdrR135.GetString("CLMHDR_DOC_NBR") + QDesign.ASCII(rdrR135.GetNumber("DOC_DEPT"), 2) + "~";
                }
                else
                {
                    strReturnValue = " ";
                }
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
                AddControl(ReportSection.PAGE_HEADING, "X_DOC_DEPT_NBR", DataTypes.Character, 7);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.R135.DOC_DEPT", DataTypes.Numeric, 2);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.R135.CLMHDR_DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.R135.DOC_NAME", DataTypes.Character, 24);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R135.RAT_REJECTED_CLAIM", DataTypes.Character, 10);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R135.X_CODE", DataTypes.Character, 5);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R135.CLMDTL_SV_DATE", DataTypes.Character, 8);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R135.PAT_HEALTH_NBR", DataTypes.Numeric, 10);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R135.PAT_VERSION_CD", DataTypes.Character, 2);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R135.OHIP_ERR_CODE", DataTypes.Character, 3);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R135.X_DESC", DataTypes.Character, 70);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2019-01-29 10:23:44 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            // TODO: Remove duplicate controls, if there are any.
            switch (strControl)
            {
                case "X_DOC_DEPT_NBR":
                    return Common.StringToField(X_DOC_DEPT_NBR(), intSize);
                case "TEMPORARYDATA.R135.DOC_DEPT":
                    return rdrR135.GetNumber("DOC_DEPT").ToString();
                case "TEMPORARYDATA.R135.CLMHDR_DOC_NBR":
                    return Common.StringToField(rdrR135.GetString("CLMHDR_DOC_NBR"));
                case "TEMPORARYDATA.R135.DOC_NAME":
                    return Common.StringToField(rdrR135.GetString("DOC_NAME"));
                case "TEMPORARYDATA.R135.RAT_REJECTED_CLAIM":
                    return Common.StringToField(rdrR135.GetString("RAT_REJECTED_CLAIM"));
                case "TEMPORARYDATA.R135.X_CODE":
                    return Common.StringToField(rdrR135.GetString("X_CODE"));
                case "TEMPORARYDATA.R135.CLMDTL_SV_DATE":
                    return Common.StringToField(rdrR135.GetString("CLMDTL_SV_DATE"));
                case "TEMPORARYDATA.R135.PAT_HEALTH_NBR":
                    return rdrR135.GetNumber("PAT_HEALTH_NBR").ToString();
                case "TEMPORARYDATA.R135.PAT_VERSION_CD":
                    return Common.StringToField(rdrR135.GetString("PAT_VERSION_CD"));
                case "TEMPORARYDATA.R135.OHIP_ERR_CODE":
                    return Common.StringToField(rdrR135.GetString("OHIP_ERR_CODE"));
                case "TEMPORARYDATA.R135.X_DESC":
                    return Common.StringToField(rdrR135.GetString("X_DESC"));
                default:
                    return String.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                // TODO: Some manual steps maybe required.
                Access_R135();
                while (rdrR135.Read())
                {
                    WriteData();
                }

                rdrR135.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrR135 == null))
            {
                rdrR135.Close();
                rdrR135 = null;
            }
        }
    }
}
