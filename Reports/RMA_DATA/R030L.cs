#region "Screen Comments"

// #> PROGRAM-ID.     R030L.QZS
// ((C)) Dyad Technologies
// PROGRAM PURPOSE : PRINT automatic payment batches                              
// MODIFICATION HISTORY
// DATE   WHO          DESCRIPTION
// 06/Nov/09 M.C.         - ORIGINAL
// 2016/Jul/14 MC1      - fix picture

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
    public class R030L : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R030L";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrR031A_PAY_BATCHES = new Reader();

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

        private void Access_R031A_PAY_BATCHES()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("BATCTRL_BATCH_NBR, ");
            strSQL.Append("BATCTRL_MANUAL_PAY_TOT, ");
            strSQL.Append("FROM TEMPORARYDATA.R031A_PAY_BATCHES ");

            strSQL.Append(Choose());

            rdrR031A_PAY_BATCHES.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);

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
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R031A_PAY_BATCHES.BATCTRL_BATCH_NBR", DataTypes.Character, 8);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R031A_PAY_BATCHES.BATCTRL_MANUAL_PAY_TOT", DataTypes.Numeric, 9);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R031A_PAY_BATCHES.CORE_RECORD_NUMBER", DataTypes.Numeric, 32);
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
        //# Do not delete, modify or move it.  Updated: 10/10/2017 9:56:28 AM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "TEMPORARYDATA.R031A_PAY_BATCHES.BATCTRL_BATCH_NBR":
                    return Common.StringToField(rdrR031A_PAY_BATCHES.GetString("BATCTRL_BATCH_NBR").PadRight(8, ' '));

                case "TEMPORARYDATA.R031A_PAY_BATCHES.BATCTRL_MANUAL_PAY_TOT":
                    return rdrR031A_PAY_BATCHES.GetNumber("BATCTRL_MANUAL_PAY_TOT").ToString().PadLeft(9, ' ');

                case "TEMPORARYDATA.R031A_PAY_BATCHES.CORE_RECORD_NUMBER":
                    return rdrR031A_PAY_BATCHES.GetNumber("CORE_RECORD_NUMBER").ToString().PadLeft(32, ' ');

                default:
                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_R031A_PAY_BATCHES();

                while (rdrR031A_PAY_BATCHES.Read())
                {
                    WriteData();
                }
                rdrR031A_PAY_BATCHES.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrR031A_PAY_BATCHES != null))
            {
                rdrR031A_PAY_BATCHES.Close();
                rdrR031A_PAY_BATCHES = null;
            }
        }


        #endregion

        #endregion
    }
}
