#region "Screen Comments"

// 2009/10/05 - end 
// 2011/11/29 - MC3 - add new request

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
    public class U100_C : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "U100_C";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrU100_BLANK_F112_REC = new Reader();

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

        private void Access_U100_BLANK_F112_REC()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOCREV_DOC_NBR, ");
            strSQL.Append("DOC_OHIP_NBR, ");
            strSQL.Append("DOC_DEPT, ");
            strSQL.Append("DOC_NAME, ");
            strSQL.Append("DOC_DATE_FAC_TERM, ");
            strSQL.Append("CORE_RECORD_NUMBER ");
            strSQL.Append("FROM TEMPORARYDATA.U100_BLANK_F112_REC ");

            strSQL.Append(Choose());

            rdrU100_BLANK_F112_REC.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);

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
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U100_BLANK_F112_REC.DOCREV_DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U100_BLANK_F112_REC.DOC_OHIP_NBR", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U100_BLANK_F112_REC.DOC_DEPT", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U100_BLANK_F112_REC.DOC_NAME", DataTypes.Character, 24);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U100_BLANK_F112_REC.DOC_DATE_FAC_TERM", DataTypes.Numeric, 8);
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
        //# Do not delete, modify or move it.  Updated: 7/2/2017 9:13:43 AM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "TEMPORARYDATA.U100_BLANK_F112_REC.DOCREV_DOC_NBR":
                    return Common.StringToField(rdrU100_BLANK_F112_REC.GetString("DOCREV_DOC_NBR").PadRight(3, ' '));

                case "TEMPORARYDATA.U100_BLANK_F112_REC.DOC_OHIP_NBR":
                    return rdrU100_BLANK_F112_REC.GetNumber("DOC_OHIP_NBR").ToString().PadLeft(6, ' ');

                case "TEMPORARYDATA.U100_BLANK_F112_REC.DOC_DEPT":
                    return rdrU100_BLANK_F112_REC.GetNumber("DOC_DEPT").ToString().PadLeft(2, ' ');

                case "TEMPORARYDATA.U100_BLANK_F112_REC.DOC_NAME":
                    return Common.StringToField(rdrU100_BLANK_F112_REC.GetString("DOC_NAME").PadRight(24, ' '));

                case "TEMPORARYDATA.U100_BLANK_F112_REC.DOC_DATE_FAC_TERM":
                    return rdrU100_BLANK_F112_REC.GetNumber("DOC_DATE_FAC_TERM").ToString().PadLeft(8, ' ');

                default:
                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_U100_BLANK_F112_REC();

                while (rdrU100_BLANK_F112_REC.Read())
                {
                    WriteData();
                }
                rdrU100_BLANK_F112_REC.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrU100_BLANK_F112_REC != null))
            {
                rdrU100_BLANK_F112_REC.Close();
                rdrU100_BLANK_F112_REC = null;
            }
        }

        #endregion

        #endregion
    }
}
