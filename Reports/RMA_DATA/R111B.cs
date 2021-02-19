#region "Screen Comments"

// #> PROGRAM-ID.     R111B.QZS
// ((C)) Dyad Technologies
// PURPOSE: SUB-PROCESS WITHIN  EARNINGS GENERATION  PROCESS.
// Create EARNINGS transactions in F110-COMPENSATION for
// the current EP-NBR using MTD values taken from F050-REVENUE-MSTR
// PHASE 2B- PRINT AUDIT REPORT
// MODIFICATION HISTORY
// DATE    SAF #  WHO      DESCRIPTION
// 93/JUL/25  ____   B.E.     - original
// 95/OCT/24  ----   M.C.  - PDR 631 - INCLUDE MICV, MICM, MISJ,
// MISP, MOHR TOTALS
// - RE-WRITE THE PROGRAM
// 1999/JAN/15  ----   S.B.     - Checked for Y2K.

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
    public class R111B : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R111B";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrU110 = new Reader();

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

                Sort = "COMP_CODE ASC";

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

        private void Access_U110()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("COMP_CODE, ");
            strSQL.Append("MTD_BILLING ");
            strSQL.Append("FROM TEMPORARYDATA.U110");

            strSQL.Append(Choose());

            rdrU110.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);

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
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.U110.COMP_CODE", DataTypes.Character, 6);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.U110.MTD_BILLING", DataTypes.Numeric, 8);
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
        //# Do not delete, modify or move it.  Updated: 6/29/2017 2:19:23 PM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "TEMPORARYDATA.U110.COMP_CODE":
                    return Common.StringToField(rdrU110.GetString("COMP_CODE").PadRight(6, ' '));

                case "TEMPORARYDATA.U110.MTD_BILLING":
                    return rdrU110.GetNumber("MTD_BILLING").ToString().PadLeft(15, ' ');

                default:
                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_U110();

                while (rdrU110.Read())
                {
                    WriteData();
                }
                rdrU110.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrU110 != null))
            {
                rdrU110.Close();
                rdrU110 = null;
            }
        }

        #endregion

        #endregion
    }
}
