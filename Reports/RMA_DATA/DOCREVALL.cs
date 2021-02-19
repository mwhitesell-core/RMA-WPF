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
    public class DOCREVALL : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "DOCREVALL";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrDOCREVALL = new Reader();

        #endregion

        #region " Renaissance Data "

        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                //  Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;
                Sort = "DOCREV_CLINIC_1_2 ASC";
                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return ReportData;
        }

        #endregion

        #region " Renaissance Statements "

        #region " ACCESS "

        private void Access_DOCREVALL()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOCREV_CLINIC_1_2, ");
            strSQL.Append("TOT_AMT_YTD, ");
            strSQL.Append("TOT_MISC, ");
            strSQL.Append("TOTALS ");
            strSQL.Append("FROM TEMPORARYDATA.DOCREVALL ");

            strSQL.Append(Choose());

            rdrDOCREVALL.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, true, ReportFunctions.TextFiles);
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
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.DOCREVALL.DOCREV_CLINIC_1_2", DataTypes.Character, 2);
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.DOCREVALL.TOT_AMT_YTD", DataTypes.Numeric, 10);
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.DOCREVALL.TOT_MISC", DataTypes.Numeric, 10);
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.DOCREVALL.TOTALS", DataTypes.Numeric, 10);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        #endregion

        #region " Renaissance Precompiler Generated Code "

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-05-09 9:52:34 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "TEMPORARYDATA.DOCREVALL.DOCREV_CLINIC_1_2":
                    return Common.StringToField(rdrDOCREVALL.GetString("DOCREV_CLINIC_1_2"));

                case "TEMPORARYDATA.DOCREVALL.TOT_AMT_YTD":
                    return rdrDOCREVALL.GetNumber("TOT_AMT_YTD").ToString();

                case "TEMPORARYDATA.DOCREVALL.TOT_MISC":
                    return rdrDOCREVALL.GetNumber("TOT_MISC").ToString();

                case "TEMPORARYDATA.DOCREVALL.TOTALS":
                    return rdrDOCREVALL.GetNumber("TOTALS").ToString();

                default:
                    return string.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                Access_DOCREVALL();
                while (rdrDOCREVALL.Read())
                {
                    WriteData();
                }
            
                rdrDOCREVALL.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrDOCREVALL == null)) {
                rdrDOCREVALL.Close();
                rdrDOCREVALL = null;
            }
        }

        #endregion

        #endregion
    }
}
