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
    public class R150_PAYEFT_CHECK__PASS3 : BaseRDLClass
    {
        protected const string REPORT_NAME = "R150_PAYEFT_CHECK__PASS3";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrSAVEF110F119 = new Reader();
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
        private void Access_SAVEF110F119()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: If * is not used to select all columns, ensure the necessary columns (i.e. columns that are used to access records of other tables) are included in the SELECT statement
            strSQL.Append("SELECT ");
            strSQL.Append("AMT_NET, ");
            strSQL.Append("AMT_MTD, ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("EP_NBR, ");
            strSQL.Append("COMP_CODE ");
            strSQL.Append("FROM TEMPORARYDATA.SAVEF110F119 ");
            strSQL.Append(Choose());
            rdrSAVEF110F119.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
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
            if ((QDesign.NULL(rdrSAVEF110F119.GetNumber("AMT_NET")) != QDesign.NULL(rdrSAVEF110F119.GetNumber("AMT_MTD"))))
            {
                blnSelected = true;
            }

            return blnSelected;
        }
        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.SAVEF110F119.AMT_MTD", DataTypes.Numeric, 9);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.SAVEF110F119.AMT_NET", DataTypes.Numeric, 18);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.SAVEF110F119.COMP_CODE", DataTypes.Character, 6);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.SAVEF110F119.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.SAVEF110F119.EP_NBR", DataTypes.Numeric, 6);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2019-07-23 1:56:07 PM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "TEMPORARYDATA.SAVEF110F119.AMT_MTD":
                    return rdrSAVEF110F119.GetNumber("AMT_MTD").ToString();
                case "TEMPORARYDATA.SAVEF110F119.AMT_NET":
                    return rdrSAVEF110F119.GetNumber("AMT_NET").ToString();
                case "TEMPORARYDATA.SAVEF110F119.COMP_CODE":
                    return Common.StringToField(rdrSAVEF110F119.GetString("COMP_CODE"));
                case "TEMPORARYDATA.SAVEF110F119.DOC_NBR":
                    return Common.StringToField(rdrSAVEF110F119.GetString("DOC_NBR"));
                case "TEMPORARYDATA.SAVEF110F119.EP_NBR":
                    return rdrSAVEF110F119.GetNumber("EP_NBR").ToString();
                default:
                    return String.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                // TODO: Some manual steps maybe required.
                Access_SAVEF110F119();
                while (rdrSAVEF110F119.Read())
                {
                    WriteData();
                }

                rdrSAVEF110F119.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if (!(rdrSAVEF110F119 == null))
            {
                rdrSAVEF110F119.Close();
                rdrSAVEF110F119 = null;
            }
        }
    }
}
