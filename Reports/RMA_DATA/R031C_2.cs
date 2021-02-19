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
    public class R031C_2 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R031C_2";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrR031A_BATCH_NBR = new Reader();
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

                Sort = "X_CLINIC ASC, X_BATCH_COUNT ASC";

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

        private void Access_R031A_BATCH_NBR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("X_CLINIC, ");
            strSQL.Append("X_BATCH_COUNT, ");
            strSQL.Append("X_TOTAL_PAID_AMT ");
            strSQL.Append("FROM TEMPORARYDATA.R031A_BATCH_NBR ");

            strSQL.Append(Choose());

            rdrR031A_BATCH_NBR.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);

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
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R031A_BATCH_NBR.X_CLINIC", DataTypes.Numeric, 6);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R031A_BATCH_NBR.X_BATCH_COUNT", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R031A_BATCH_NBR.X_TOTAL_PAID_AMT", DataTypes.Numeric, 12);
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
        //# Do not delete, modify or move it.  Updated: 9/28/2017 9:17:57 AM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "TEMPORARYDATA.R031A_BATCH_NBR.X_CLINIC":
                    return rdrR031A_BATCH_NBR.GetNumber("X_CLINIC").ToString().PadLeft(6, ' ');

                case "TEMPORARYDATA.R031A_BATCH_NBR.X_BATCH_COUNT":
                    return rdrR031A_BATCH_NBR.GetNumber("X_BATCH_COUNT").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R031A_BATCH_NBR.X_TOTAL_PAID_AMT":
                    return rdrR031A_BATCH_NBR.GetNumber("X_TOTAL_PAID_AMT").ToString().PadLeft(12, ' ');

                default:

                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_R031A_BATCH_NBR();

                while (rdrR031A_BATCH_NBR.Read())
                {
                    WriteData();
                }
                rdrR031A_BATCH_NBR.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrR031A_BATCH_NBR != null))
            {
                rdrR031A_BATCH_NBR.Close();
                rdrR031A_BATCH_NBR = null;
            }
        }


        #endregion

        #endregion
    }
}
