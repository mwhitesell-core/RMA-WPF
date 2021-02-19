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
    public class R140_A4T : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R140_A4T";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrAFP_A4T_FILE = new Reader();

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

        private void Access_AFP_A4T_FILE()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("AFP_PAYMENT_SIGN, ");
            strSQL.Append("AFP_PAYMENT_AMT ");
            strSQL.Append("FROM SEQUENTIAL.AFP_A4T_FILE ");

            strSQL.Append(Choose());

            rdrAFP_A4T_FILE.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.m_strFlatFileDictionary, ReportFunctions.TextFiles);

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
                AddControl(ReportSection.REPORT, "SEQUENTIAL.AFP_A4T_FILE.AFP_PAYMENT_SIGN", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "SEQUENTIAL.AFP_A4T_FILE.AFP_PAYMENT_AMT", DataTypes.Numeric, 11);
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
        //# Do not delete, modify or move it.  Updated: 9/28/2017 11:02:30 AM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "SEQUENTIAL.AFP_A4T_FILE.AFP_PAYMENT_SIGN":
                    return Common.StringToField(rdrAFP_A4T_FILE.GetString("AFP_PAYMENT_SIGN").PadRight(1, ' '));

                case "SEQUENTIAL.AFP_A4T_FILE.AFP_PAYMENT_AMT":
                    return rdrAFP_A4T_FILE.GetNumber("AFP_PAYMENT_AMT").ToString().PadLeft(11, ' ');

                default:

                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_AFP_A4T_FILE();

                while (rdrAFP_A4T_FILE.Read())
                {
                    WriteData();
                }
                rdrAFP_A4T_FILE.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrAFP_A4T_FILE != null))
            {
                rdrAFP_A4T_FILE.Close();
                rdrAFP_A4T_FILE = null;
            }
        }


        #endregion

        #endregion
    }
}
