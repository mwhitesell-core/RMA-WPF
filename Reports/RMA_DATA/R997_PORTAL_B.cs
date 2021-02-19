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
    public class R997_PORTAL_B : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R997_PORTAL_B";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrU997_GOOD_SRT = new Reader();

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

                Sort = "DOC_NBR ASC, W_RAT_145_CLINIC_NBR ASC, W_RAT_145_LAST_NAME ASC, W_RAT_145_FIRST_NAME ASC, RAT_145_HEALTH_OHIP_NBR ASC, RAT_145_ACCOUNT_NBR ASC";

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

        private void Access_U997_GOOD_SRT()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("W_RAT_145_CLINIC_NBR, ");
            strSQL.Append("W_RAT_145_LAST_NAME, ");
            strSQL.Append("W_RAT_145_FIRST_NAME, ");
            strSQL.Append("RAT_145_HEALTH_OHIP_NBR, ");
            strSQL.Append("RAT_145_ACCOUNT_NBR, ");
            strSQL.Append("RAT_145_AMOUNT_SUB, ");
            strSQL.Append("RAT_145_AMT_PAID ");
            strSQL.Append("FROM TEMPORARYDATA.U997_GOOD_SRT ");

            strSQL.Append(Choose());

            rdrU997_GOOD_SRT.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);

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
                AddControl(ReportSection.FINAL_FOOTING, "TEMPORARYDATA.U997_GOOD_SRT.RAT_145_AMOUNT_SUB", DataTypes.Numeric, 6);
                AddControl(ReportSection.FINAL_FOOTING, "TEMPORARYDATA.U997_GOOD_SRT.RAT_145_AMT_PAID", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U997_GOOD_SRT.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U997_GOOD_SRT.W_RAT_145_CLINIC_NBR", DataTypes.Character, 2);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U997_GOOD_SRT.W_RAT_145_LAST_NAME", DataTypes.Character, 9);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U997_GOOD_SRT.W_RAT_145_FIRST_NAME", DataTypes.Character, 5);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U997_GOOD_SRT.RAT_145_HEALTH_OHIP_NBR", DataTypes.Character, 12);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U997_GOOD_SRT.RAT_145_ACCOUNT_NBR", DataTypes.Character, 8);
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
        //# Do not delete, modify or move it.  Updated: 9/28/2017 1:18:32 PM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "TEMPORARYDATA.U997_GOOD_SRT.RAT_145_AMOUNT_SUB":
                    return rdrU997_GOOD_SRT.GetNumber("RAT_145_AMOUNT_SUB").ToString().PadLeft(6, ' ');

                case "TEMPORARYDATA.U997_GOOD_SRT.RAT_145_AMT_PAID":
                    return rdrU997_GOOD_SRT.GetNumber("RAT_145_AMT_PAID").ToString().PadLeft(6, ' ');

                case "TEMPORARYDATA.U997_GOOD_SRT.DOC_NBR":
                    return Common.StringToField(rdrU997_GOOD_SRT.GetString("DOC_NBR").PadRight(3, ' '));

                case "TEMPORARYDATA.U997_GOOD_SRT.W_RAT_145_CLINIC_NBR":
                    return Common.StringToField(rdrU997_GOOD_SRT.GetString("W_RAT_145_CLINIC_NBR").PadRight(2, ' '));

                case "TEMPORARYDATA.U997_GOOD_SRT.W_RAT_145_LAST_NAME":
                    return Common.StringToField(rdrU997_GOOD_SRT.GetString("W_RAT_145_LAST_NAME").PadRight(9, ' '));

                case "TEMPORARYDATA.U997_GOOD_SRT.W_RAT_145_FIRST_NAME":
                    return Common.StringToField(rdrU997_GOOD_SRT.GetString("W_RAT_145_FIRST_NAME").PadRight(5, ' '));

                case "TEMPORARYDATA.U997_GOOD_SRT.RAT_145_HEALTH_OHIP_NBR":
                    return Common.StringToField(rdrU997_GOOD_SRT.GetString("RAT_145_HEALTH_OHIP_NBR").PadRight(12, ' '));

                case "TEMPORARYDATA.U997_GOOD_SRT.RAT_145_ACCOUNT_NBR":
                    return Common.StringToField(rdrU997_GOOD_SRT.GetString("RAT_145_ACCOUNT_NBR").PadRight(8, ' '));

                default:

                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_U997_GOOD_SRT();

                while (rdrU997_GOOD_SRT.Read())
                {
                    WriteData();
                }
                rdrU997_GOOD_SRT.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrU997_GOOD_SRT != null))
            {
                rdrU997_GOOD_SRT.Close();
                rdrU997_GOOD_SRT = null;
            }
        }


        #endregion

        #endregion
    }
}
