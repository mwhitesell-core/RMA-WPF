#region "Screen Comments"

// program: utl0101.qzsqzs
// purpose: prdecimal duplicate entries found in f119-doctor-ytd
// This pass follows utl0100.qts
// modification history
// DATE    WHO       DESCRIPTION
// 2002/sep/24 B.E. - original

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
    public class UTL0101 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "UTL0101";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrF119_DUPLICATES = new Reader();

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

        private void Access_F119_DUPLICATES()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("COMP_CODE, ");
            strSQL.Append("AMT_MTD, ");
            strSQL.Append("AMT_YTD ");
            strSQL.Append("FROM TEMPORARYDATA.F119_DUPLICATES ");

            strSQL.Append(Choose());

            rdrF119_DUPLICATES.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);

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
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.F119_DUPLICATES.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.F119_DUPLICATES.COMP_CODE", DataTypes.Character, 6);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.F119_DUPLICATES.AMT_MTD", DataTypes.Numeric, 9);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.F119_DUPLICATES.AMT_YTD", DataTypes.Numeric, 8);
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
        //# Do not delete, modify or move it.  Updated: 6/29/2017 2:55:39 PM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "TEMPORARYDATA.F119_DUPLICATES.DOC_NBR":
                    return Common.StringToField(rdrF119_DUPLICATES.GetString("DOC_NBR").PadRight(6, ' '));

                case "TEMPORARYDATA.F119_DUPLICATES.COMP_CODE":
                    return Common.StringToField(rdrF119_DUPLICATES.GetString("COMP_CODE").PadRight(6, ' '));

                case "TEMPORARYDATA.F119_DUPLICATES.AMT_MTD":
                    return rdrF119_DUPLICATES.GetNumber("AMT_MTD").ToString().PadLeft(9, ' ');

                case "TEMPORARYDATA.F119_DUPLICATES.AMT_YTD":
                    return rdrF119_DUPLICATES.GetNumber("AMT_YTD").ToString().PadLeft(9, ' ');

                default:
                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_F119_DUPLICATES();

                while (rdrF119_DUPLICATES.Read())
                {
                    WriteData();
                }
                rdrF119_DUPLICATES.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrF119_DUPLICATES != null))
            {
                rdrF119_DUPLICATES.Close();
                rdrF119_DUPLICATES = null;
            }
        }

        #endregion

        #endregion
    }
}
