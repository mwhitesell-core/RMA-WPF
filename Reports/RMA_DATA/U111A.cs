#region "Screen Comments"

// #> PROGRAM-ID.     U111A.QZS
// ((C)) Dyad Technologies
// PURPOSE: SUB-PROCESS WITHIN  EARNINGS GENERATION  PROCESS.
// Create EARNINGS transactions in F110-COMPENSATION for
// the current EP-NBR using MTD values taken from F050-REVENUE-MSTR
// PHASE 2 - sort and summarize records by doc/comp-code into
// 1 record
// MODIFICATION HISTORY
// DATE    SAF #  WHO      DESCRIPTION
// 93/JUL/25  ____   B.E.     - original
// 93/OCT/18  ____   B.E.     - fix bug in subtotalling of MTD-BILLING
// 1999/JAN/15  ____   S.B.     - Checked for Y2K.
// 2003/dec/16  A.A.  - alpha doctor nbr

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
    public class U111A : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "U111A";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrU110 = new Reader();
        private Reader rdrU111_SORTED = new Reader();

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
                // Create Subfile.
                SubFile = true;
                SubFileName = "U111_SORTED";
                SubFileType = SubFileType.Keep;
                SubFileAT = "COMP_CODE";            

                Sort = "DOCREV_DOC_NBR ASC, COMP_CODE ASC";

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
            strSQL.Append("DOCREV_DOC_NBR, ");
            strSQL.Append("COMP_CODE, ");
            strSQL.Append("COMP_TYPE, ");
            strSQL.Append("PROCESS_SEQ, ");
            strSQL.Append("FACTOR, ");
            strSQL.Append("MTD_BILLING ");
            strSQL.Append("FROM TEMPORARYDATA.U110 ");
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
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U110.DOCREV_DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U110.COMP_CODE", DataTypes.Character, 6);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U110.COMP_TYPE", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U110.PROCESS_SEQ", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U110.FACTOR", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U110.MTD_BILLING", DataTypes.Numeric, 8, SummaryType.SUBTOTAL);
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
        //# Do not delete, modify or move it.  Updated: 2017-07-25 7:16:33 PM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "TEMPORARYDATA.U110.DOCREV_DOC_NBR":
                    return Common.StringToField(rdrU110.GetString("DOCREV_DOC_NBR").PadRight(3, ' '));

                case "TEMPORARYDATA.U110.COMP_CODE":
                    return Common.StringToField(rdrU110.GetString("COMP_CODE").PadRight(6, ' '));

                case "TEMPORARYDATA.U110.COMP_TYPE":
                    return Common.StringToField(rdrU110.GetString("COMP_TYPE").PadRight(1, ' '));

                case "TEMPORARYDATA.U110.PROCESS_SEQ":
                    return rdrU110.GetNumber("PROCESS_SEQ").ToString().PadLeft(2, ' ');

                case "TEMPORARYDATA.U110.FACTOR":
                    return rdrU110.GetNumber("FACTOR").ToString().PadLeft(6, ' ');

                case "TEMPORARYDATA.U110.MTD_BILLING":
                    return rdrU110.GetNumber("MTD_BILLING").ToString().PadLeft(9, ' ');

                default:
                    break;
            }

            return string.Empty;
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
