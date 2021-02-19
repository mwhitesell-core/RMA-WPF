#region "Screen Comments"

// 2009/mar/03 CHAN  - ORIGINAL
// - GENERATE A REPORT THAT WILL SHOW ALL ADJUSTED BATCHES
// with reason cd I4 & oma code  `G313A` and clinic 88 only  
// 2009/mar/05 MC  - Yasemin requests to include reason cd 36 as well since MOH has
// chanaged their mind for this month run
// 2012/Feb/06 MC1               - since this program is no longer reserved for clinic 88, modify the program
// to display the correct clinic nbr
// 2016/Jul/11 MC2  - use u030c_debug_adj instead of u030c_88_adj
// MC2
// access *u030c_88_adj    

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
    public class R030I_3 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R030I_3";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrU030MC_DEBUG_ADJ = new Reader();

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

                Sort = "X_CLINIC_BATCH_NBR ASC";

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

        private void Access_U030MC_DEBUG_ADJ()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("X_CLINIC_BATCH_NBR, ");
            strSQL.Append("PART_DTL_CLINIC_NBR, ");
            strSQL.Append("X_OHIP_BAL ");
            strSQL.Append("FROM TEMPORARYDATA.U030MC_DEBUG_ADJ ");

            strSQL.Append(Choose());

            rdrU030MC_DEBUG_ADJ.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.m_strFlatFileDictionary, ReportFunctions.TextFiles);

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
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.U030MC_DEBUG_ADJ.PART_DTL_CLINIC_NBR", DataTypes.Numeric, 2);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.U030MC_DEBUG_ADJ.X_CLINIC_BATCH_NBR", DataTypes.Character, 8);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.U030MC_DEBUG_ADJ.X_OHIP_BAL", DataTypes.Numeric, 7);
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
        //# Do not delete, modify or move it.  Updated: 9/27/2017 11:58:37 AM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "TEMPORARYDATA.U030MC_DEBUG_ADJ.PART_DTL_CLINIC_NBR":
                    return rdrU030MC_DEBUG_ADJ.GetNumber("PART_DTL_CLINIC_NBR").ToString();

                case "TEMPORARYDATA.U030MC_DEBUG_ADJ.X_CLINIC_BATCH_NBR":
                    return Common.StringToField(rdrU030MC_DEBUG_ADJ.GetString("X_CLINIC_BATCH_NBR"));

                case "TEMPORARYDATA.U030MC_DEBUG_ADJ.X_OHIP_BAL":
                    return rdrU030MC_DEBUG_ADJ.GetNumber("X_OHIP_BAL").ToString();

                default:
                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_U030MC_DEBUG_ADJ();

                while (rdrU030MC_DEBUG_ADJ.Read())
                {
                    WriteData();
                }
                rdrU030MC_DEBUG_ADJ.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrU030MC_DEBUG_ADJ != null))
            {
                rdrU030MC_DEBUG_ADJ.Close();
                rdrU030MC_DEBUG_ADJ = null;
            }
        }


        #endregion

        #endregion
    }
}
