#region "Screen Comments"


#endregion

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
    public class R997H : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R997H";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrU997_TOTAL = new Reader();

        #endregion

        #region " Renaissance Data "

        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                // Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;

                Sort = "";

                // Start report data processing.
                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return ReportData;
        }

        #endregion

        #region " Renaissance Statements "

        #region " ACCESS "

        private void Access_U997_TOTAL()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("W_COUNT, ");
            strSQL.Append("W_RAT_145_AMOUNT_SUB, ");
            strSQL.Append("W_RAT_145_AMT_PAID ");
            strSQL.Append("FROM TEMPORARYDATA.U997_TOTAL ");

            strSQL.Append(Choose());

            rdrU997_TOTAL.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);

            strSQL = null;
        }

        #endregion

        #region " CHOOSE "

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(string.Empty);


            return strChoose.ToString();
        }

        #endregion

        #region " SELECT IF "

        #endregion

        #region " DEFINES "

        #endregion

        #region " CONTROLS "

        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.FINAL_FOOTING, "TEMPORARYDATA.U997_TOTAL.W_COUNT", DataTypes.Numeric, 6);
                AddControl(ReportSection.FINAL_FOOTING, "TEMPORARYDATA.U997_TOTAL.W_RAT_145_AMOUNT_SUB", DataTypes.Numeric, 11);
                AddControl(ReportSection.FINAL_FOOTING, "TEMPORARYDATA.U997_TOTAL.W_RAT_145_AMT_PAID", DataTypes.Numeric, 11);
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        #endregion

        #region " Renaissance Precompiler Generated Code "

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 9/29/2017 11:07:49 AM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "TEMPORARYDATA.U997_TOTAL.W_COUNT":
                    return rdrU997_TOTAL.GetNumber("W_COUNT").ToString().PadLeft(6, ' ');

                case "TEMPORARYDATA.U997_TOTAL.W_RAT_145_AMOUNT_SUB":
                    return rdrU997_TOTAL.GetNumber("W_RAT_145_AMOUNT_SUB").ToString().PadLeft(11, ' ');

                case "TEMPORARYDATA.U997_TOTAL.W_RAT_145_AMT_PAID":
                    return rdrU997_TOTAL.GetNumber("W_RAT_145_AMT_PAID").ToString().PadLeft(11, ' ');

                default:

                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_U997_TOTAL();

                while (rdrU997_TOTAL.Read())
                {
                    WriteData();
                }
                rdrU997_TOTAL.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrU997_TOTAL != null))
            {
                rdrU997_TOTAL.Close();
                rdrU997_TOTAL = null;
            }
        }


        #endregion

        #endregion
    }
}
