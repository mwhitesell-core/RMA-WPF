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
    public class MP_UTL0201_2 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "UTL0201_2";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrUTL0201 = new Reader();
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

                Sort = "DOC_DEPT ASC, AMT_MTD DESC, DOC_NBR ASC";

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

        private void Access_UTL0201()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_DEPT, ");
            strSQL.Append("AMT_MTD, ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("X_PED, ");
            strSQL.Append("DOC_NAME, ");
            strSQL.Append("COMP_CODE, ");
            strSQL.Append("AMT_YTD ");
            strSQL.Append("FROM TEMPORARYDATA.UTL0201 ");

            strSQL.Append(Choose());

            rdrUTL0201.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);

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
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.UTL0201.X_PED", DataTypes.Character, 6);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.UTL0201.DOC_DEPT", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.UTL0201.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.UTL0201.DOC_NAME", DataTypes.Character, 24);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.UTL0201.COMP_CODE", DataTypes.Character, 6);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.UTL0201.AMT_MTD", DataTypes.Numeric, 9);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.UTL0201.AMT_YTD", DataTypes.Numeric, 8);
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
        //# Do not delete, modify or move it.  Updated: 10/27/2017 1:13:57 PM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "TEMPORARYDATA.UTL0201.X_PED":
                    return Common.StringToField(rdrUTL0201.GetString("X_PED").PadRight(6, ' '));

                case "TEMPORARYDATA.UTL0201.DOC_DEPT":
                    return rdrUTL0201.GetNumber("DOC_DEPT").ToString().PadLeft(2, ' ');

                case "TEMPORARYDATA.UTL0201.DOC_NBR":
                    return Common.StringToField(rdrUTL0201.GetString("DOC_NBR").PadRight(3, ' '));

                case "TEMPORARYDATA.UTL0201.DOC_NAME":
                    return Common.StringToField(rdrUTL0201.GetString("DOC_NAME").PadRight(24, ' '));

                case "TEMPORARYDATA.UTL0201.COMP_CODE":
                    return Common.StringToField(rdrUTL0201.GetString("COMP_CODE").PadRight(6, ' '));

                case "TEMPORARYDATA.UTL0201.AMT_MTD":
                    return rdrUTL0201.GetNumber("AMT_MTD").ToString().PadLeft(9, ' ');

                case "TEMPORARYDATA.UTL0201.AMT_YTD":
                    return rdrUTL0201.GetNumber("AMT_YTD").ToString().PadLeft(8, ' ');

                default:

                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_UTL0201();

                while (rdrUTL0201.Read())
                {
                    WriteData();
                }
                rdrUTL0201.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrUTL0201 != null))
            {
                rdrUTL0201.Close();
                rdrUTL0201 = null;
            }
        }


        #endregion

        #endregion
    }
}
