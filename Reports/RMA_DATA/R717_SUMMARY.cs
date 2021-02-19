//  #PROGRAM-ID.     R717.QZS
//  PROGRAM PURPOSE : TO REPORT WHEN SUSPEND HDR AND SUSPEND DTL DO NOT MATCH ON AMOUNTS
//  STATUS  
//  MODIFICATION HISTORY
//  DATE            WHO     DESCRIPTION
//  2016/Apr/21         MC      original
//  2016/Apr/25  MC1 exclude clmdtl-status = `D`elete
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
    public class R717_SUMMARY : BaseRDLClass
    {
        protected const string REPORT_NAME = "R717__PASS1";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrF002_SUSPEND_DTL = new Reader();
        private Reader rdrSUSP_DTL = new Reader();
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
                SubFileName = "SUSP_DTL";
                SubFileType = SubFileType.Keep;
                SubFileAT = "CLMDTL_ACCOUNTING_NBR";
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
            strSQL.Append("CLMDTL_STATUS, ");
            strSQL.Append("CLMDTL_DOC_OHIP_NBR, ");
            strSQL.Append("CLMDTL_ACCOUNTING_NBR, ");
            strSQL.Append("CLMDTL_FEE_OHIP ");
            strSQL.Append("FROM INDEXED.F002_SUSPEND_DTL ");
            strSQL.Append(Choose());
            rdrF002_SUSPEND_DTL.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
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
            if ((QDesign.NULL(rdrF002_SUSPEND_DTL.GetString("CLMDTL_STATUS")) != "D"))
            {
                blnSelected = true;
            }

            return blnSelected;
        }
        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_SUSPEND_DTL.CLMDTL_DOC_OHIP_NBR", DataTypes.Numeric, 6);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_SUSPEND_DTL.CLMDTL_ACCOUNTING_NBR", DataTypes.Character, 8);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_SUSPEND_DTL.CLMDTL_FEE_OHIP", DataTypes.Numeric, 7);
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
                case "INDEXED.F002_SUSPEND_DTL.CLMDTL_DOC_OHIP_NBR":
                    return rdrF002_SUSPEND_DTL.GetNumber("CLMDTL_DOC_OHIP_NBR").ToString();
                case "INDEXED.F002_SUSPEND_DTL.CLMDTL_ACCOUNTING_NBR":
                    return Common.StringToField(rdrF002_SUSPEND_DTL.GetString("CLMDTL_ACCOUNTING_NBR"));
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
