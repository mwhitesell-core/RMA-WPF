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
    public class CHECK_F001_F002_ALL_10 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "ORPHANED_CLAIMS";
        protected const bool REPORT_HAS_PARAMETERS = false;

        private Reader rdrF002_CURR_PED = new Reader();
        private Reader rdrF001_BATCH_CONTROL_FILE = new Reader();

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
                Sort = "";
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

        private void Access_F002_CURR_PED()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT * ");
            strSQL.Append("FROM TEMPORARYDATA.F002_CURR_PED ");

            strSQL.Append(Choose());

            rdrF002_CURR_PED.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
            strSQL = null;
        }

        private void Link_F001_BATCH_CONTROL_FILE()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("BATCTRL_BATCH_NBR ");
            strSQL.Append("FROM INDEXED.F001_BATCH_CONTROL_FILE ");
            strSQL.Append("WHERE ").Append("BATCTRL_BATCH_NBR = ").Append(Common.StringToField(rdrF002_CURR_PED.GetString("KEY_CLM_BATCH_NBR")));

            rdrF001_BATCH_CONTROL_FILE.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
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

        public override bool SelectIf()
        {
            bool blnSelected = false;

            if (!ReportDataFunctions.Exists(rdrF001_BATCH_CONTROL_FILE))
            {
                blnSelected = true;
            }

            return blnSelected;
        }

        #endregion

        #region " DEFINES "

        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.F002_CURR_PED.KEY_CLM_BATCH_NBR", DataTypes.Character, 8);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.F002_CURR_PED.X_CLAIM", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.F002_CURR_PED.CLMHDR_BATCH_TYPE", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.F002_CURR_PED.CLMHDR_ADJ_CD_SUB_TYPE", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.F002_CURR_PED.CLMHDR_DATE_SYS", DataTypes.Character, 8);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.F002_CURR_PED.CLMHDR_TOT_CLAIM_AR_OHIP", DataTypes.Numeric, 7);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-05-09 7:36:49 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            // TODO: Remove duplicate controls, if there are any.
            switch (strControl)
            {
                case "TEMPORARYDATA.F002_CURR_PED.KEY_CLM_BATCH_NBR":
                    return Common.StringToField(rdrF002_CURR_PED.GetString("KEY_CLM_BATCH_NBR"));
                case "TEMPORARYDATA.F002_CURR_PED.X_CLAIM":
                    return rdrF002_CURR_PED.GetNumber("X_CLAIM").ToString();
                case "TEMPORARYDATA.F002_CURR_PED.CLMHDR_BATCH_TYPE":
                    return Common.StringToField(rdrF002_CURR_PED.GetString("CLMHDR_BATCH_TYPE"));
                case "TEMPORARYDATA.F002_CURR_PED.CLMHDR_ADJ_CD_SUB_TYPE":
                    return Common.StringToField(rdrF002_CURR_PED.GetString("CLMHDR_ADJ_CD_SUB_TYPE"));
                case "TEMPORARYDATA.F002_CURR_PED.CLMHDR_DATE_SYS":
                    return Common.StringToField(rdrF002_CURR_PED.GetString("CLMHDR_DATE_SYS"));
                case "TEMPORARYDATA.F002_CURR_PED.CLMHDR_TOT_CLAIM_AR_OHIP":
                    return rdrF002_CURR_PED.GetNumber("CLMHDR_TOT_CLAIM_AR_OHIP").ToString();
                default:
                    return String.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                Access_F002_CURR_PED();
                while (rdrF002_CURR_PED.Read())
                {
                    Link_F001_BATCH_CONTROL_FILE();
                    while (rdrF001_BATCH_CONTROL_FILE.Read())
                    {
                        WriteData();
                    }
                    rdrF001_BATCH_CONTROL_FILE.Close();
                }
                rdrF002_CURR_PED.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrF002_CURR_PED == null))
            {
                rdrF002_CURR_PED.Close();
                rdrF002_CURR_PED = null;
            }

            if (!(rdrF001_BATCH_CONTROL_FILE == null))
            {
                rdrF001_BATCH_CONTROL_FILE.Close();
                rdrF001_BATCH_CONTROL_FILE = null;
            }
        }

        #endregion

        #endregion
    }
}
