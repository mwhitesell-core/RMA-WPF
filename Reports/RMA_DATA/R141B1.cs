//  #> PROGRAM-ID.     r141b.qzs 
//  ((C)) Dyad Infosys LTD 
//  PURPOSE:   Create miscellaneous payment  batches/claims from a `text` file.
//  Second pass to report errors from u141a_error subfile,
//  report valid from u141a_valid subfile
//  MODIFICATION HISTORY
//  DATE     WHO     DESCRIPTION
//  2015/Nov/10 MC      - original
//  2016/Jan/20 MC1     - include grand total in error report, and remove bypass column in error report
//  2016/May/31 MC2     - include error 7 - amt < -99,999.99 or > 99,999.99
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
    public class R141B1 : BaseRDLClass
    {
        protected const string REPORT_NAME = "R141B1";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrU141A_ERROR = new Reader();
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
        private void Access_U141A_ERROR()
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
            strSQL.Append("CLMHDR_REFERENCE ");
            strSQL.Append("FROM TEMPORARYDATA.U141A_ERROR ");
            strSQL.Append(Choose());
            rdrU141A_ERROR.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
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
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U141A_ERROR.CLINIC_NBR", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U141A_ERROR.HDR_AGENT_CD", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U141A_ERROR.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U141A_ERROR.DOC_NAME", DataTypes.Character, 24);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U141A_ERROR.CLMDTL_OMA_CD", DataTypes.Character, 4);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U141A_ERROR.SIGNED_AMT_NET", DataTypes.Numeric, 9);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U141A_ERROR.CLMHDR_REFERENCE", DataTypes.Character, 11);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U141A_ERROR.ERROR_CD", DataTypes.Character, 1);
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
                case "TEMPORARYDATA.U141A_ERROR.CLINIC_NBR":
                    return rdrU141A_ERROR.GetNumber("CLINIC_NBR").ToString();
                case "TEMPORARYDATA.U141A_ERROR.HDR_AGENT_CD":
                    return Common.StringToField(rdrU141A_ERROR.GetString("HDR_AGENT_CD"));
                case "TEMPORARYDATA.U141A_ERROR.DOC_NBR":
                    return Common.StringToField(rdrU141A_ERROR.GetString("DOC_NBR"));
                case "TEMPORARYDATA.U141A_ERROR.DOC_NAME":
                    return Common.StringToField(rdrU141A_ERROR.GetString("DOC_NAME"));
                case "TEMPORARYDATA.U141A_ERROR.CLMDTL_OMA_CD":
                    return Common.StringToField(rdrU141A_ERROR.GetString("CLMDTL_OMA_CD"));
                case "TEMPORARYDATA.U141A_ERROR.SIGNED_AMT_NET":
                    return rdrU141A_ERROR.GetNumber("SIGNED_AMT_NET").ToString();
                case "TEMPORARYDATA.U141A_ERROR.CLMHDR_REFERENCE":
                    return Common.StringToField(rdrU141A_ERROR.GetString("CLMHDR_REFERENCE"));
                case "TEMPORARYDATA.U141A_ERROR.ERROR_CD":
                    return Common.StringToField(rdrU141A_ERROR.GetString("ERROR_CD"));
                default:
                    return String.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                // TODO: Some manual steps maybe required.
                Access_U141A_ERROR();
                while (rdrU141A_ERROR.Read())
                {
                    WriteData();
                }

                rdrU141A_ERROR.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrU141A_ERROR == null))
            {
                rdrU141A_ERROR.Close();
                rdrU141A_ERROR = null;
            }
        }
    }
}
