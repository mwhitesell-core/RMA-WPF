#region "Screen Comments"

// 2009/mar/03 CHAN  - ORIGINAL
// - GENERATE A REPORT THAT WILL SHOW ALL
// CLAIMS THAT GET AUTOMATICALLY
// ADJUSTED FROM U030_NO_ADJ SUBFILE
// with reason cd I4 & oma code  `G313A` and clinic 88 only  
// 2009/mar/05 MC  - Yasemin requests to include reason cd 36 as well since MOH has changed
// their mind for this month run   
// 2012/Feb/06 MC1  - since this program is no longer reserved for clinic 88, modify the program
// to display the correct clinic nbr

#endregion

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
    public class R030I_2 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R030I_2";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        #endregion
        private Reader rdrPART_ADJ_BATCH = new Reader();

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

        private void Access_PART_ADJ_BATCH()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("PART_ADJ_CLAIM_ID, ");
            strSQL.Append("PART_ADJ_BAL ");
            strSQL.Append("FROM INDEXED.PART_ADJ_BATCH ");

            strSQL.Append(Choose());

            rdrPART_ADJ_BATCH.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.m_strFlatFileDictionary, ReportFunctions.TextFiles);

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

        private string X_CLINIC()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.Substring(rdrPART_ADJ_BATCH.GetString("PART_ADJ_CLAIM_ID"), 1, 2);
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        #endregion

        #region " CONTROLS "

        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.PAGE_HEADING, "X_CLINIC", DataTypes.Character, 2);
                AddControl(ReportSection.REPORT, "INDEXED.PART_ADJ_BATCH.PART_ADJ_CLAIM_ID", DataTypes.Character, 10);
                AddControl(ReportSection.REPORT, "INDEXED.PART_ADJ_BATCH.PART_ADJ_BAL", DataTypes.Numeric, 7);
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
        //# Do not delete, modify or move it.  Updated: 9/26/2017 11:04:15 AM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "X_CLINIC":
                    return Common.StringToField(X_CLINIC().PadRight(2, ' '));

                case "INDEXED.PART_ADJ_BATCH.PART_ADJ_CLAIM_ID":
                    return Common.StringToField(rdrPART_ADJ_BATCH.GetString("PART_ADJ_CLAIM_ID"));

                case "INDEXED.PART_ADJ_BATCH.PART_ADJ_BAL":
                    return rdrPART_ADJ_BATCH.GetNumber("PART_ADJ_BAL").ToString();

                default:
                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_PART_ADJ_BATCH();

                while (rdrPART_ADJ_BATCH.Read())
                {
                    WriteData();
                }
                rdrPART_ADJ_BATCH.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrPART_ADJ_BATCH != null))
            {
                rdrPART_ADJ_BATCH.Close();
                rdrPART_ADJ_BATCH = null;
            }
        }


        #endregion

        #endregion
    }
}
