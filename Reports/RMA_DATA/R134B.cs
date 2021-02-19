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
    public class R134B : BaseRDLClass
    {
        protected const string REPORT_NAME = "R134B";
        protected const bool REPORT_HAS_PARAMETERS = true;

        private Reader rdrR134 = new Reader();
        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                //  Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;
                Sort = "CLMHDR_DOC_NBR ASC, SUBMITTED_REJECTED_CLAIM ASC, EDT_OMA_SERVICE_CD_AND_SUFFIX DESC";
                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return ReportData;
        }
        private void Access_R134()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            strSQL.Append("SELECT ");
            strSQL.Append("DOC_DEPT, ");
            strSQL.Append("CLMHDR_DOC_NBR, ");
            strSQL.Append("DOC_NAME, ");
            strSQL.Append("SUBMITTED_REJECTED_CLAIM, ");
            strSQL.Append("EDT_OMA_SERVICE_CD_AND_SUFFIX, ");
            strSQL.Append("EDT_SERVICE_DATE, ");
            strSQL.Append("EDT_HEALTH_NBR, ");
            strSQL.Append("EDT_HEALTH_VERSION_NBR, ");
            strSQL.Append("OHIP_ERR_CODE, ");
            strSQL.Append("OHIP_ERR_DESCRIPTION ");
            strSQL.Append("FROM TEMPORARYDATA.R134 ");

            strSQL.Append(Choose());

            rdrR134.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
            strSQL = null;
        }

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(String.Empty);

            return strChoose.ToString().ToString();
        }

        private string X_RUN_TYPE()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = QDesign.NULL(ReportFunctions.astrScreenParameters[0].ToString());
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
                    strReturnValue = "~" + rdrR134.GetString("CLMHDR_DOC_NBR") + QDesign.ASCII(rdrR134.GetNumber("DOC_DEPT"), 2) + "~";
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
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.R134.DOC_DEPT", DataTypes.Numeric, 2);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.R134.CLMHDR_DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.R134.DOC_NAME", DataTypes.Character, 24);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R134.SUBMITTED_REJECTED_CLAIM", DataTypes.Character, 10);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R134.EDT_OMA_SERVICE_CD_AND_SUFFIX", DataTypes.Character, 5);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R134.EDT_SERVICE_DATE", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R134.EDT_HEALTH_NBR", DataTypes.Character, 10);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R134.EDT_HEALTH_VERSION_CD", DataTypes.Character, 2);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R134.OHIP_ERR_CODE", DataTypes.Character, 3);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R134.OHIP_ERR_DESCRIPTION", DataTypes.Character, 60);
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

                case "TEMPORARYDATA.R134.DOC_DEPT":
                    return rdrR134.GetNumber("DOC_DEPT").ToString();

                case "TEMPORARYDATA.R134.CLMHDR_DOC_NBR":
                    return Common.StringToField(rdrR134.GetString("CLMHDR_DOC_NBR"));

                case "TEMPORARYDATA.R134.DOC_NAME":
                    return Common.StringToField(rdrR134.GetString("DOC_NAME"));

                case "TEMPORARYDATA.R134.SUBMITTED_REJECTED_CLAIM":
                    return Common.StringToField(rdrR134.GetString("SUBMITTED_REJECTED_CLAIM"));

                case "TEMPORARYDATA.R134.EDT_OMA_SERVICE_CD_AND_SUFFIX":
                    return Common.StringToField(rdrR134.GetString("EDT_OMA_SERVICE_CD_AND_SUFFIX"));

                case "TEMPORARYDATA.R134.EDT_SERVICE_DATE":
                    return rdrR134.GetNumber("EDT_SERVICE_DATE").ToString();

                case "TEMPORARYDATA.R134.EDT_HEALTH_NBR":
                    return Common.StringToField(rdrR134.GetString("EDT_HEALTH_NBR"));

                case "TEMPORARYDATA.R134.EDT_HEALTH_VERSION_CD":
                    return Common.StringToField(rdrR134.GetString("EDT_HEALTH_VERSION_CD"));

                case "TEMPORARYDATA.R134.OHIP_ERR_CODE":
                    return Common.StringToField(rdrR134.GetString("OHIP_ERR_CODE"));

                case "TEMPORARYDATA.R134.OHIP_ERR_DESCRIPTION":
                    return Common.StringToField(rdrR134.GetString("OHIP_ERR_DESCRIPTION"));

                default:
                    return String.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_R134();
                while (rdrR134.Read())
                {
                    WriteData();
                }
                rdrR134.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrR134 == null))
            {
                rdrR134.Close();
                rdrR134 = null;
            }
        }
    }
}
