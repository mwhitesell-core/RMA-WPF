//  Program: suspend_suffix.qzs
//  Purpose: dump out if suffix C, B or A if over certain amount
//  2011/10/28  Change fees to reflect the new fee schedule
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
    public class SUSPEND_SUFFIX : BaseRDLClass
    {
        protected const string REPORT_NAME = "SUSPEND_SUFFIX";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrF002_SUSPEND_DTL = new Reader();
        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                //  Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;
                Sort = "CLMDTL_DOC_OHIP_NBR ASC, CLMDTL_ACCOUNTING_NBR ASC";
                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return ReportData;
        }
        private void Access_F002_SUSPEND_DTL()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            strSQL.Append("SELECT ");
            strSQL.Append("CLMDTL_DOC_OHIP_NBR, ");
            strSQL.Append("CLMDTL_ACCOUNTING_NBR, ");
            strSQL.Append("CLMDTL_OMA_SUFF, ");
            strSQL.Append("CLMDTL_FEE_OHIP, ");
            strSQL.Append("CLMDTL_OMA_CD, ");
            strSQL.Append("CLMDTL_NBR_SERV, ");
            strSQL.Append("CLMDTL_CONSEC_DATES_R, ");
            strSQL.Append("CLMDTL_AMT_TECH_BILLED, ");
            strSQL.Append("CLMDTL_FEE_OMA ");
            strSQL.Append("FROM INDEXED.F002_SUSPEND_DTL ");
            strSQL.Append(Choose());
            rdrF002_SUSPEND_DTL.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.m_strFlatFileDictionary, ReportFunctions.TextFiles);
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
            if ((QDesign.NULL(rdrF002_SUSPEND_DTL.GetString("CLMDTL_OMA_SUFF")) == "C" && rdrF002_SUSPEND_DTL.GetNumber("CLMDTL_FEE_OHIP") >= 148602) || 
                (QDesign.NULL(rdrF002_SUSPEND_DTL.GetString("CLMDTL_OMA_SUFF")) == "B" && rdrF002_SUSPEND_DTL.GetNumber("CLMDTL_FEE_OHIP") >= 119198) ||
                (QDesign.NULL(rdrF002_SUSPEND_DTL.GetString("CLMDTL_OMA_SUFF")) == "A" && rdrF002_SUSPEND_DTL.GetNumber("CLMDTL_FEE_OHIP") >= 540000))
            {
                blnSelected = true;
            }

            return blnSelected;
        }

        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.REPORT, "INDEXED.F002_SUSPEND_DTL.CLMDTL_DOC_OHIP_NBR", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "INDEXED.F002_SUSPEND_DTL.CLMDTL_ACCOUNTING_NBR", DataTypes.Character, 8);
                AddControl(ReportSection.REPORT, "INDEXED.F002_SUSPEND_DTL.CLMDTL_OMA_CD", DataTypes.Character, 4);
                AddControl(ReportSection.REPORT, "INDEXED.F002_SUSPEND_DTL.CLMDTL_OMA_SUFF", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "INDEXED.F002_SUSPEND_DTL.CLMDTL_NBR_SERV", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "INDEXED.F002_SUSPEND_DTL.CLMDTL_CONSEC_DATES_R", DataTypes.Character, 9);
                AddControl(ReportSection.REPORT, "INDEXED.F002_SUSPEND_DTL.CLMDTL_AMT_TECH_BILLED", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "INDEXED.F002_SUSPEND_DTL.CLMDTL_FEE_OMA", DataTypes.Numeric, 7);
                AddControl(ReportSection.REPORT, "INDEXED.F002_SUSPEND_DTL.CLMDTL_FEE_OHIP", DataTypes.Numeric, 7);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-05-16 12:45:40 PM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            // TODO: Remove duplicate controls, if there are any.
            switch (strControl)
            {
                case "INDEXED.F002_SUSPEND_DTL.CLMDTL_DOC_OHIP_NBR":
                    return rdrF002_SUSPEND_DTL.GetNumber("CLMDTL_DOC_OHIP_NBR").ToString();
                case "INDEXED.F002_SUSPEND_DTL.CLMDTL_ACCOUNTING_NBR":
                    return Common.StringToField(rdrF002_SUSPEND_DTL.GetString("CLMDTL_ACCOUNTING_NBR"));
                case "INDEXED.F002_SUSPEND_DTL.CLMDTL_OMA_CD":
                    return Common.StringToField(rdrF002_SUSPEND_DTL.GetString("CLMDTL_OMA_CD"));
                case "INDEXED.F002_SUSPEND_DTL.CLMDTL_OMA_SUFF":
                    return Common.StringToField(rdrF002_SUSPEND_DTL.GetString("CLMDTL_OMA_SUFF"));
                case "INDEXED.F002_SUSPEND_DTL.CLMDTL_NBR_SERV":
                    return rdrF002_SUSPEND_DTL.GetNumber("CLMDTL_NBR_SERV").ToString();
                case "INDEXED.F002_SUSPEND_DTL.CLMDTL_CONSEC_DATES_R":
                    return Common.StringToField(rdrF002_SUSPEND_DTL.GetString("CLMDTL_CONSEC_DATES_R"));
                case "INDEXED.F002_SUSPEND_DTL.CLMDTL_AMT_TECH_BILLED":
                    return rdrF002_SUSPEND_DTL.GetNumber("CLMDTL_AMT_TECH_BILLED").ToString();
                case "INDEXED.F002_SUSPEND_DTL.CLMDTL_FEE_OMA":
                    return rdrF002_SUSPEND_DTL.GetNumber("CLMDTL_FEE_OMA").ToString();
                case "INDEXED.F002_SUSPEND_DTL.CLMDTL_FEE_OHIP":
                    return rdrF002_SUSPEND_DTL.GetNumber("CLMDTL_FEE_OHIP").ToString();
                default:
                    return String.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                // TODO: Some manual steps maybe required.
                Access_F002_SUSPEND_DTL();
                while (rdrF002_SUSPEND_DTL.Read())
                {
                    WriteData();
                }

                rdrF002_SUSPEND_DTL.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrF002_SUSPEND_DTL == null))
            {
                rdrF002_SUSPEND_DTL.Close();
                rdrF002_SUSPEND_DTL = null;
            }
        }
    }
}
