//  MC2 - end
//  MC2  
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
    public class R005C_CSV : BaseRDLClass
    {
        protected const string REPORT_NAME = "R005C_CSV";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrR005_SUMM = new Reader();
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
        private void Access_R005_SUMM()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: If * is not used to select all columns, ensure the necessary columns (i.e. columns that are used to access records of other tables) are included in the SELECT statement
            strSQL.Append("SELECT ");
            strSQL.Append("DEPT_MTD_AMT, ");
            strSQL.Append("DEPT_YTD_AMT ");
            strSQL.Append("FROM TEMPORARYDATA.R005_SUMM ");
            strSQL.Append(Choose());
            rdrR005_SUMM.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
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
                AddControl(ReportSection.FINAL_FOOTING, "TEMPORARYDATA.R005_SUMM.DEPT_MTD_AMT", DataTypes.Numeric, 10);
                AddControl(ReportSection.FINAL_FOOTING, "TEMPORARYDATA.R005_SUMM.DEPT_YTD_AMT", DataTypes.Numeric, 10);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2019-01-29 10:23:46 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            // TODO: Remove duplicate controls, if there are any.
            switch (strControl)
            {
                case "TEMPORARYDATA.R005_SUMM.DEPT_MTD_AMT":
                    return rdrR005_SUMM.GetNumber("DEPT_MTD_AMT").ToString();
                case "TEMPORARYDATA.R005_SUMM.DEPT_YTD_AMT":
                    return rdrR005_SUMM.GetNumber("DEPT_YTD_AMT").ToString();
                default:
                    return String.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                // TODO: Some manual steps maybe required.
                Access_R005_SUMM();
                while (rdrR005_SUMM.Read())
                {
                    WriteData();
                }

                rdrR005_SUMM.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrR005_SUMM == null))
            {
                rdrR005_SUMM.Close();
                rdrR005_SUMM = null;
            }
        }
    }
}
