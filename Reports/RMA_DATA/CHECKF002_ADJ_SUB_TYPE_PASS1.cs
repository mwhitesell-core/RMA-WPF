using Core.DataAccess.SqlServer;
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
    public class CHECKF002_ADJ_SUB_TYPE__PASS1 : BaseRDLClass
    {
        protected const string REPORT_NAME = "CHECKF002_ADJ_SUB_TYPE__PASS1";
        protected const bool REPORT_HAS_PARAMETERS = false;

        private Reader rdrF002_CLAIMS_MSTR = new Reader();
        private Reader rdrCHECKF002ADJSUBTYPE = new Reader();

        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                //  Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;
                //  Create Subfile.
                SubFile = true;
                SubFileName = "CHECKF002ADJSUBTYPE";
                SubFileType = SubFileType.Keep;
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
        private void Access_F002_CLAIMS_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            strSQL.Append("SELECT ");
            strSQL.Append("KEY_CLM_BATCH_NBR, ");
            strSQL.Append("CLMHDR_BATCH_TYPE, ");
            strSQL.Append("CLMHDR_BATCH_NBR, ");
            strSQL.Append("CLMHDR_CLAIM_NBR, ");
            strSQL.Append("CLMHDR_ADJ_CD_SUB_TYPE, ");
            strSQL.Append("CLMHDR_DATE_PERIOD_END, ");
            strSQL.Append("CLMHDR_DATE_SYS ");
            strSQL.Append("FROM INDEXED.F002_CLAIMS_MSTR_HDR");

            strSQL.Append(Choose());

            rdrF002_CLAIMS_MSTR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(String.Empty);

            strChoose.Append(" WHERE KEY_CLM_TYPE = 'B'");
            strChoose.Append(" AND KEY_CLM_SERV_CODE = '00000'");
            strChoose.Append(" AND KEY_CLM_ADJ_NBR = '0'");

            return strChoose.ToString().ToString();
        }

        private string DOC_NBR()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = QDesign.Substring(rdrF002_CLAIMS_MSTR.GetString("KEY_CLM_BATCH_NBR"), 3, 3);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string CLMHDR_CLAIM_ID()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = rdrF002_CLAIMS_MSTR.GetString("CLMHDR_BATCH_NBR") + QDesign.ASCII(rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_CLAIM_NBR"), 2);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        public override bool SelectIf()
        {
            bool blnSelected = false;

            if (QDesign.NULL(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_BATCH_TYPE")) == "C")
            {
                blnSelected = true;
            }

            return blnSelected;
        }

        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.SUMMARY, "CLMHDR_CLAIM_ID", DataTypes.Character, 10);
                AddControl(ReportSection.SUMMARY, "DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR_HDR.CLMHDR_ADJ_CD_SUB_TYPE", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR_HDR.CLMHDR_DATE_PERIOD_END", DataTypes.Numeric, 10);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR_HDR.CLMHDR_DATE_SYS", DataTypes.Character, 8);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2019-07-24 7:52:04 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "CLMHDR_CLAIM_ID":
                    return Common.StringToField(CLMHDR_CLAIM_ID());
                case "DOC_NBR":
                    return Common.StringToField(DOC_NBR());
                case "INDEXED.F002_CLAIMS_MSTR_HDR.CLMHDR_ADJ_CD_SUB_TYPE":
                    return Common.StringToField(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_ADJ_CD_SUB_TYPE"));
                case "INDEXED.F002_CLAIMS_MSTR_HDR.CLMHDR_DATE_PERIOD_END":
                    return rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_DATE_PERIOD_END").ToString();
                case "INDEXED.F002_CLAIMS_MSTR_HDR.CLMHDR_DATE_SYS":
                    return Common.StringToField(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_DATE_SYS"));
                default:
                    return String.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                // TODO: Some manual steps maybe required.
                Access_F002_CLAIMS_MSTR();
                while (rdrF002_CLAIMS_MSTR.Read())
                {
                    WriteData();
                }

                rdrF002_CLAIMS_MSTR.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if (!(rdrF002_CLAIMS_MSTR == null))
            {
                rdrF002_CLAIMS_MSTR.Close();
                rdrF002_CLAIMS_MSTR = null;
            }
        }
    }
}
