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
    public class R717 : BaseRDLClass
    {
        protected const string REPORT_NAME = "R717__PASS2";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrSUSP_DTL = new Reader();
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
        private void Access_SUSP_DTL()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: If * is not used to select all columns, ensure the necessary columns (i.e. columns that are used to access records of other tables) are included in the SELECT statement
            strSQL.Append("SELECT ");
            strSQL.Append("CLMDTL_DOC_OHIP_NBR, ");
            strSQL.Append("CLMDTL_ACCOUNTING_NBR, ");
            strSQL.Append("CLMDTL_FEE_OHIP ");
            strSQL.Append("FROM TEMPORARYDATA.SUSP_DTL ");
            strSQL.Append(Choose());
            rdrSUSP_DTL.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.m_strFlatFileDictionary, ReportFunctions.TextFiles); ;
            strSQL = null;
        }
        private void Link_F002_SUSPEND_HDR()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("CLMHDR_DOC_OHIP_NBR, ");
            strSQL.Append("CLMHDR_ACCOUNTING_NBR, ");
            strSQL.Append("CLMHDR_TOT_CLAIM_AR_OHIP ");
            strSQL.Append("FROM INDEXED.F002_SUSPEND_HDR ");
            strSQL.Append("WHERE ");
            strSQL.Append("CLMHDR_DOC_OHIP_NBR = ").Append(rdrSUSP_DTL.GetNumber("CLMDTL_DOC_OHIP_NBR"));
            strSQL.Append(" AND CLMHDR_ACCOUNTING_NBR = ").Append(Common.StringToField(rdrSUSP_DTL.GetString("CLMDTL_ACCOUNTING_NBR")));
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
            if ((QDesign.NULL(rdrSUSP_DTL.GetNumber("CLMDTL_FEE_OHIP")) != QDesign.NULL(rdrF002_SUSPEND_HDR.GetNumber("CLMHDR_TOT_CLAIM_AR_OHIP"))))
            {
                blnSelected = true;
            }

            return blnSelected;
        }
        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.SUSP_DTL.CLMDTL_DOC_OHIP_NBR", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.SUSP_DTL.CLMDTL_ACCOUNTING_NBR", DataTypes.Character, 8);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.SUSP_DTL.CLMDTL_FEE_OHIP", DataTypes.Numeric, 7);
                AddControl(ReportSection.REPORT, "INDEXED.F002_SUSPEND_HDR.CLMHDR_TOT_CLAIM_AR_OHIP", DataTypes.Numeric, 7);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-05-16 9:44:54 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            // TODO: Remove duplicate controls, if there are any.
            switch (strControl)
            {
                case "TEMPORARYDATA.SUSP_DTL.CLMDTL_DOC_OHIP_NBR":
                    return rdrSUSP_DTL.GetNumber("CLMDTL_DOC_OHIP_NBR").ToString();
                case "TEMPORARYDATA.SUSP_DTL.CLMDTL_ACCOUNTING_NBR":
                    return Common.StringToField(rdrSUSP_DTL.GetString("CLMDTL_ACCOUNTING_NBR"));
                case "TEMPORARYDATA.SUSP_DTL.CLMDTL_FEE_OHIP":
                    return rdrSUSP_DTL.GetNumber("CLMDTL_FEE_OHIP").ToString();
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
                // TODO: Some manual steps maybe required.
                Access_SUSP_DTL();
                while (rdrSUSP_DTL.Read())
                {
                    Link_F002_SUSPEND_HDR();
                    while (rdrF002_SUSPEND_HDR.Read())
                    {
                        WriteData();
                    }

                    rdrF002_SUSPEND_HDR.Close();
                }

                rdrSUSP_DTL.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrSUSP_DTL == null))
            {
                rdrSUSP_DTL.Close();
                rdrSUSP_DTL = null;
            }

            if (!(rdrF002_SUSPEND_HDR == null))
            {
                rdrF002_SUSPEND_HDR.Close();
                rdrF002_SUSPEND_HDR = null;
            }
        }
    }
}
