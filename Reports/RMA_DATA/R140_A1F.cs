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
    public class R140_A1F : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R140_A1F";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrAFP_A1F_FILE = new Reader();

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

        private void Access_AFP_A1F_FILE()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("AFP_GOVERNANCE_GROUP, ");
            strSQL.Append("AFP_GROUP_NAME, ");
            strSQL.Append("AFP_REPORTING_MTH, ");
            strSQL.Append("AFP_PAYMENT_SIGN, ");
            strSQL.Append("AFP_PAYMENT_AMT ");
            strSQL.Append("FROM SEQUENTIAL.AFP_A1F_FILE ");

            strSQL.Append(Choose());

            rdrAFP_A1F_FILE.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.m_strFlatFileDictionary, ReportFunctions.TextFiles);

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
                AddControl(ReportSection.REPORT, "SEQUENTIAL.AFP_A1F_FILE.AFP_GOVERNANCE_GROUP", DataTypes.Character, 4);
                AddControl(ReportSection.REPORT, "SEQUENTIAL.AFP_A1F_FILE.AFP_GROUP_NAME", DataTypes.Character, 75);
                AddControl(ReportSection.REPORT, "SEQUENTIAL.AFP_A1F_FILE.AFP_REPORTING_MTH", DataTypes.Character, 6);
                AddControl(ReportSection.REPORT, "SEQUENTIAL.AFP_A1F_FILE.AFP_PAYMENT_SIGN", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "SEQUENTIAL.AFP_A1F_FILE.AFP_PAYMENT_AMT", DataTypes.Numeric, 11);
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
        //# Do not delete, modify or move it.  Updated: 9/28/2017 10:29:16 AM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "SEQUENTIAL.AFP_A1F_FILE.AFP_GOVERNANCE_GROUP":
                    return Common.StringToField(rdrAFP_A1F_FILE.GetString("AFP_GOVERNANCE_GROUP").PadRight(4, ' '));

                case "SEQUENTIAL.AFP_A1F_FILE.AFP_GROUP_NAME":
                    return Common.StringToField(rdrAFP_A1F_FILE.GetString("AFP_GROUP_NAME").PadRight(75, ' '));

                case "SEQUENTIAL.AFP_A1F_FILE.AFP_REPORTING_MTH":
                    return Common.StringToField(rdrAFP_A1F_FILE.GetString("AFP_REPORTING_MTH").PadRight(6, ' '));

                case "SEQUENTIAL.AFP_A1F_FILE.AFP_PAYMENT_SIGN":
                    return Common.StringToField(rdrAFP_A1F_FILE.GetString("AFP_PAYMENT_SIGN").PadRight(1, ' '));

                case "SEQUENTIAL.AFP_A1F_FILE.AFP_PAYMENT_AMT":
                    return rdrAFP_A1F_FILE.GetNumber("AFP_PAYMENT_AMT").ToString().PadLeft(11, ' ');

                default:

                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_AFP_A1F_FILE();

                while (rdrAFP_A1F_FILE.Read())
                {
                    WriteData();
                }
                rdrAFP_A1F_FILE.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrAFP_A1F_FILE != null))
            {
                rdrAFP_A1F_FILE.Close();
                rdrAFP_A1F_FILE = null;
            }
        }


        #endregion

        #endregion
    }
}
