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
    public class CHECK_F001_F002_ALL_8 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "ORPHANED_BATCHES";
        protected const bool REPORT_HAS_PARAMETERS = false;

        private Reader rdrORPHANED_BATCHES = new Reader();

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

        private void Access_ORPHANED_BATCHES()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT * ");
            strSQL.Append("FROM TEMPORARYDATA.ORPHANED_BATCHES ");

            strSQL.Append(Choose());

            rdrORPHANED_BATCHES.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
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

        private string BATCTRL_BATCH_TYPE_ADJ_CD()
        {
            string strReturnValue = string.Empty;
            try
            {
                if (QDesign.NULL(rdrORPHANED_BATCHES.GetString("BATCTRL_BATCH_TYPE")) == "C")
                {
                    strReturnValue = rdrORPHANED_BATCHES.GetString("BATCTRL_BATCH_TYPE");
                }
                else
                {
                    strReturnValue = rdrORPHANED_BATCHES.GetString("BATCTRL_BATCH_TYPE") + "/" + rdrORPHANED_BATCHES.GetString("BATCTRL_ADJ_CD");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.ORPHANED_BATCHES.BATCTRL_BATCH_NBR", DataTypes.Character, 8);
                AddControl(ReportSection.REPORT, "BATCTRL_BATCH_TYPE_ADJ_CD", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.ORPHANED_BATCHES.BATCTRL_BATCH_STATUS", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.ORPHANED_BATCHES.BATCTRL_DATE_BATCH_ENTERED", DataTypes.Character, 8);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.ORPHANED_BATCHES.BATCTRL_NBR_CLAIMS_IN_BATCH", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.ORPHANED_BATCHES.BATCTRL_AMT_ACT", DataTypes.Numeric, 9);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.ORPHANED_BATCHES.BATCTRL_AMT_EST", DataTypes.Numeric, 9);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.ORPHANED_BATCHES.BATCTRL_CALC_TOT_REV", DataTypes.Numeric, 9);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.ORPHANED_BATCHES.BATCTRL_MANUAL_PAY_TOT", DataTypes.Numeric, 9);
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
                case "TEMPORARYDATA.ORPHANED_BATCHES.BATCTRL_BATCH_NBR":
                    return Common.StringToField(rdrORPHANED_BATCHES.GetString("BATCTRL_BATCH_NBR"));
                case "BATCTRL_BATCH_TYPE_ADJ_CD":
                    return Common.StringToField(BATCTRL_BATCH_TYPE_ADJ_CD(), intSize);
                case "TEMPORARYDATA.ORPHANED_BATCHES.BATCTRL_BATCH_STATUS":
                    return Common.StringToField(rdrORPHANED_BATCHES.GetString("BATCTRL_BATCH_STATUS"));
                case "TEMPORARYDATA.ORPHANED_BATCHES.BATCTRL_DATE_BATCH_ENTERED":
                    return Common.StringToField(rdrORPHANED_BATCHES.GetString("BATCTRL_DATE_BATCH_ENTERED"));
                case "TEMPORARYDATA.ORPHANED_BATCHES.BATCTRL_NBR_CLAIMS_IN_BATCH":
                    return rdrORPHANED_BATCHES.GetNumber("BATCTRL_NBR_CLAIMS_IN_BATCH").ToString();
                case "TEMPORARYDATA.ORPHANED_BATCHES.BATCTRL_AMT_ACT":
                    return rdrORPHANED_BATCHES.GetNumber("BATCTRL_AMT_ACT").ToString();
                case "TEMPORARYDATA.ORPHANED_BATCHES.BATCTRL_AMT_EST":
                    return rdrORPHANED_BATCHES.GetNumber("BATCTRL_AMT_EST").ToString();
                case "TEMPORARYDATA.ORPHANED_BATCHES.BATCTRL_CALC_TOT_REV":
                    return rdrORPHANED_BATCHES.GetNumber("BATCTRL_CALC_TOT_REV").ToString();
                case "TEMPORARYDATA.ORPHANED_BATCHES.BATCTRL_MANUAL_PAY_TOT":
                    return rdrORPHANED_BATCHES.GetNumber("BATCTRL_MANUAL_PAY_TOT").ToString();
                default:
                    return String.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                Access_ORPHANED_BATCHES();
                while (rdrORPHANED_BATCHES.Read())
                {
                    WriteData();
                }

                rdrORPHANED_BATCHES.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrORPHANED_BATCHES == null))
            {
                rdrORPHANED_BATCHES.Close();
                rdrORPHANED_BATCHES = null;
            }

        }

        #endregion

        #endregion
    }
}
