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
    public class R070C_CSV : BaseRDLClass
    {
        protected const string REPORT_NAME = "R070_ALL";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrR070A_CSV = new Reader();
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
        private void Access_R070A_CSV()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: If * is not used to select all columns, ensure the necessary columns (i.e. columns that are used to access records of other tables) are included in the SELECT statement
            strSQL.Append("SELECT ");
            strSQL.Append("CLMHDR_TOT_CLAIM_AR_OHIP, ");
            strSQL.Append("CLMHDR_MANUAL_AND_TAPE_PAYMENTS, ");
            strSQL.Append("X_BALANCE_DUE ");
            strSQL.Append("FROM TEMPORARYDATA.R070A_CSV ");
            strSQL.Append(Choose());
            rdrR070A_CSV.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
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
                AddControl(ReportSection.FINAL_FOOTING, "TEMPORARYDATA.R070A_CSV.CLMHDR_TOT_CLAIM_AR_OHIP", DataTypes.Numeric, 7);
                AddControl(ReportSection.FINAL_FOOTING, "TEMPORARYDATA.R070A_CSV.CLMHDR_MANUAL_AND_TAPE_PAYMENTS", DataTypes.Numeric, 7);
                AddControl(ReportSection.FINAL_FOOTING, "TEMPORARYDATA.R070A_CSV.X_BALANCE_DUE", DataTypes.Numeric, 7);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-07-20 11:56:25 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            // TODO: Remove duplicate controls, if there are any.
            switch (strControl)
            {
                case "TEMPORARYDATA.R070A_CSV.CLMHDR_TOT_CLAIM_AR_OHIP":
                    return rdrR070A_CSV.GetNumber("CLMHDR_TOT_CLAIM_AR_OHIP").ToString();
                case "TEMPORARYDATA.R070A_CSV.CLMHDR_MANUAL_AND_TAPE_PAYMENTS":
                    return rdrR070A_CSV.GetNumber("CLMHDR_MANUAL_AND_TAPE_PAYMENTS").ToString();
                case "TEMPORARYDATA.R070A_CSV.X_BALANCE_DUE":
                    return rdrR070A_CSV.GetNumber("X_BALANCE_DUE").ToString();
                default:
                    return String.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                // TODO: Some manual steps maybe required.
                Access_R070A_CSV();
                while (rdrR070A_CSV.Read())
                {
                    WriteData();
                }

                rdrR070A_CSV.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrR070A_CSV == null))
            {
                rdrR070A_CSV.Close();
                rdrR070A_CSV = null;
            }
        }
    }
}
