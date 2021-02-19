//  MC1 
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
    public class R011D_CSV : BaseRDLClass
    {
        protected const string REPORT_NAME = "R011D_CSV";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrR011A_CSV = new Reader();
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
        private void Access_R011A_CSV()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: If * is not used to select all columns, ensure the necessary columns (i.e. columns that are used to access records of other tables) are included in the SELECT statement
            strSQL.Append("SELECT ");
            strSQL.Append("X_SVC_MTD_IN, ");
            strSQL.Append("X_AMT_MTD_IN, ");
            strSQL.Append("X_SVC_MTD_OUT, ");
            strSQL.Append("X_AMT_MTD_OUT, ");
            strSQL.Append("X_MISC_SVC_MTD, ");
            strSQL.Append("X_MISC_AMT_MTD, ");
            strSQL.Append("X_SVC_TOTAL_MTD, ");
            strSQL.Append("X_AMT_TOTAL_MTD, ");
            strSQL.Append("X_SVC_YTD_IN, ");
            strSQL.Append("X_AMT_YTD_IN, ");
            strSQL.Append("X_SVC_YTD_OUT, ");
            strSQL.Append("X_AMT_YTD_OUT, ");
            strSQL.Append("X_MISC_SVC_YTD, ");
            strSQL.Append("X_MISC_AMT_YTD, ");
            strSQL.Append("X_SVC_TOTAL_YTD, ");
            strSQL.Append("X_AMT_TOTAL_YTD ");
            strSQL.Append("FROM TEMPORARYDATA.R011A_CSV ");
            strSQL.Append(Choose());
            rdrR011A_CSV.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
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
                AddControl(ReportSection.FINAL_FOOTING, "TEMPORARYDATA.R011A_CSV.X_SVC_MTD_IN", DataTypes.Numeric, 6);
                AddControl(ReportSection.FINAL_FOOTING, "TEMPORARYDATA.R011A_CSV.X_AMT_MTD_IN", DataTypes.Numeric, 10);
                AddControl(ReportSection.FINAL_FOOTING, "TEMPORARYDATA.R011A_CSV.X_SVC_MTD_OUT", DataTypes.Numeric, 6);
                AddControl(ReportSection.FINAL_FOOTING, "TEMPORARYDATA.R011A_CSV.X_AMT_MTD_OUT", DataTypes.Numeric, 10);
                AddControl(ReportSection.FINAL_FOOTING, "TEMPORARYDATA.R011A_CSV.X_MISC_SVC_MTD", DataTypes.Numeric, 6);
                AddControl(ReportSection.FINAL_FOOTING, "TEMPORARYDATA.R011A_CSV.X_MISC_AMT_MTD", DataTypes.Numeric, 10);
                AddControl(ReportSection.FINAL_FOOTING, "TEMPORARYDATA.R011A_CSV.X_SVC_TOTAL_MTD", DataTypes.Numeric, 7);
                AddControl(ReportSection.FINAL_FOOTING, "TEMPORARYDATA.R011A_CSV.X_AMT_TOTAL_MTD", DataTypes.Numeric, 10);
                AddControl(ReportSection.FINAL_FOOTING, "TEMPORARYDATA.R011A_CSV.X_SVC_YTD_IN", DataTypes.Numeric, 7);
                AddControl(ReportSection.FINAL_FOOTING, "TEMPORARYDATA.R011A_CSV.X_AMT_YTD_IN", DataTypes.Numeric, 11);
                AddControl(ReportSection.FINAL_FOOTING, "TEMPORARYDATA.R011A_CSV.X_SVC_YTD_OUT", DataTypes.Numeric, 7);
                AddControl(ReportSection.FINAL_FOOTING, "TEMPORARYDATA.R011A_CSV.X_AMT_YTD_OUT", DataTypes.Numeric, 11);
                AddControl(ReportSection.FINAL_FOOTING, "TEMPORARYDATA.R011A_CSV.X_MISC_SVC_YTD", DataTypes.Numeric, 7);
                AddControl(ReportSection.FINAL_FOOTING, "TEMPORARYDATA.R011A_CSV.X_MISC_AMT_YTD", DataTypes.Numeric, 11);
                AddControl(ReportSection.FINAL_FOOTING, "TEMPORARYDATA.R011A_CSV.X_SVC_TOTAL_YTD", DataTypes.Numeric, 7);
                AddControl(ReportSection.FINAL_FOOTING, "TEMPORARYDATA.R011A_CSV.X_AMT_TOTAL_YTD", DataTypes.Numeric, 11);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-11-20 2:09:51 PM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            // TODO: Remove duplicate controls, if there are any.
            switch (strControl)
            {
                case "TEMPORARYDATA.R011A_CSV.X_SVC_MTD_IN":
                    return rdrR011A_CSV.GetNumber("X_SVC_MTD_IN").ToString();
                case "TEMPORARYDATA.R011A_CSV.X_AMT_MTD_IN":
                    return rdrR011A_CSV.GetNumber("X_AMT_MTD_IN").ToString();
                case "TEMPORARYDATA.R011A_CSV.X_SVC_MTD_OUT":
                    return rdrR011A_CSV.GetNumber("X_SVC_MTD_OUT").ToString();
                case "TEMPORARYDATA.R011A_CSV.X_AMT_MTD_OUT":
                    return rdrR011A_CSV.GetNumber("X_AMT_MTD_OUT").ToString();
                case "TEMPORARYDATA.R011A_CSV.X_MISC_SVC_MTD":
                    return rdrR011A_CSV.GetNumber("X_MISC_SVC_MTD").ToString();
                case "TEMPORARYDATA.R011A_CSV.X_MISC_AMT_MTD":
                    return rdrR011A_CSV.GetNumber("X_MISC_AMT_MTD").ToString();
                case "TEMPORARYDATA.R011A_CSV.X_SVC_TOTAL_MTD":
                    return rdrR011A_CSV.GetNumber("X_SVC_TOTAL_MTD").ToString();
                case "TEMPORARYDATA.R011A_CSV.X_AMT_TOTAL_MTD":
                    return rdrR011A_CSV.GetNumber("X_AMT_TOTAL_MTD").ToString();
                case "TEMPORARYDATA.R011A_CSV.X_SVC_YTD_IN":
                    return rdrR011A_CSV.GetNumber("X_SVC_YTD_IN").ToString();
                case "TEMPORARYDATA.R011A_CSV.X_AMT_YTD_IN":
                    return rdrR011A_CSV.GetNumber("X_AMT_YTD_IN").ToString();
                case "TEMPORARYDATA.R011A_CSV.X_SVC_YTD_OUT":
                    return rdrR011A_CSV.GetNumber("X_SVC_YTD_OUT").ToString();
                case "TEMPORARYDATA.R011A_CSV.X_AMT_YTD_OUT":
                    return rdrR011A_CSV.GetNumber("X_AMT_YTD_OUT").ToString();
                case "TEMPORARYDATA.R011A_CSV.X_MISC_SVC_YTD":
                    return rdrR011A_CSV.GetNumber("X_MISC_SVC_YTD").ToString();
                case "TEMPORARYDATA.R011A_CSV.X_MISC_AMT_YTD":
                    return rdrR011A_CSV.GetNumber("X_MISC_AMT_YTD").ToString();
                case "TEMPORARYDATA.R011A_CSV.X_SVC_TOTAL_YTD":
                    return rdrR011A_CSV.GetNumber("X_SVC_TOTAL_YTD").ToString();
                case "TEMPORARYDATA.R011A_CSV.X_AMT_TOTAL_YTD":
                    return rdrR011A_CSV.GetNumber("X_AMT_TOTAL_YTD").ToString();
                default:
                    return String.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                // TODO: Some manual steps maybe required.
                Access_R011A_CSV();
                while (rdrR011A_CSV.Read())
                {
                    WriteData();
                }

                rdrR011A_CSV.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrR011A_CSV == null))
            {
                rdrR011A_CSV.Close();
                rdrR011A_CSV = null;
            }
        }
    }
}
