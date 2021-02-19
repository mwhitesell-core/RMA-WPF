#region "Screen Comments"

// Program: r140_e.qzs
// Purpose: Generate i audit report of AFP conversion payments placed into
// payroll`s f114 special payments file
// 2004/sep/14 b.e. - original
// 2004/dec/06 M.C. - add optional to f020 in the access
// 2005/feb/05 b.e. - optional access to f020 doesn`t get doc name - remove
// access to f020 and replace with subfile data
// 2007/aug/15 M.C. - access to f074 and f070 to be removed since no reference to the file
// 2008/oct/14 M.C. - correct on spelling for Compensation Code
// &

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
    public class R140_E : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R140_E";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrU140_E_AUDIT = new Reader();

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

                Sort = "X_SELECTED_PAYROLL ASC, COMP_CODE ASC, DOC_NAME ASC";

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

        private void Access_U140_E_AUDIT()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("X_SELECTED_PAYROLL, ");
            strSQL.Append("COMP_CODE, ");
            strSQL.Append("DOC_NAME, ");
            strSQL.Append("DOC_INITS, ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("X_TMP_AMT_NET ");
            strSQL.Append("FROM TEMPORARYDATA.U140_E_AUDIT ");

            strSQL.Append(Choose());

            rdrU140_E_AUDIT.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);

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

        private string X_DOC_NAME()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.Pack(rdrU140_E_AUDIT.GetString("DOC_NAME") + ", " + rdrU140_E_AUDIT.GetString("DOC_INITS") + " [" + rdrU140_E_AUDIT.GetString("DOC_NBR") + "]");
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
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U140_E_AUDIT.X_SELECTED_PAYROLL", DataTypes.Character, 1);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U140_E_AUDIT.COMP_CODE", DataTypes.Character, 6);
                AddControl(ReportSection.REPORT, "X_DOC_NAME", DataTypes.Character, 35);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U140_E_AUDIT.X_TMP_AMT_NET", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U140_E_AUDIT.DOC_NAME", DataTypes.Character, 24);
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
        //# Do not delete, modify or move it.  Updated: 9/28/2017 11:10:18 AM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "TEMPORARYDATA.U140_E_AUDIT.X_SELECTED_PAYROLL":
                    return Common.StringToField(rdrU140_E_AUDIT.GetString("X_SELECTED_PAYROLL").PadRight(1, ' '));

                case "TEMPORARYDATA.U140_E_AUDIT.COMP_CODE":
                    return Common.StringToField(rdrU140_E_AUDIT.GetString("COMP_CODE").PadRight(6, ' '));

                case "X_DOC_NAME":
                    return Common.StringToField(X_DOC_NAME().PadRight(35, ' '));

                case "TEMPORARYDATA.U140_E_AUDIT.X_TMP_AMT_NET":
                    return rdrU140_E_AUDIT.GetNumber("X_TMP_AMT_NET").ToString().PadLeft(10, ' ');

                case "TEMPORARYDATA.U140_E_AUDIT.DOC_NAME":
                    return Common.StringToField(rdrU140_E_AUDIT.GetString("DOC_NAME").PadRight(24, ' '));

                default:
                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_U140_E_AUDIT();

                while (rdrU140_E_AUDIT.Read())
                {
                    WriteData();
                }
                rdrU140_E_AUDIT.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrU140_E_AUDIT != null))
            {
                rdrU140_E_AUDIT.Close();
                rdrU140_E_AUDIT = null;
            }
        }


        #endregion

        #endregion
    }
}
