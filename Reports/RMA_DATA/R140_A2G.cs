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
    public class R140_A2G : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R140_A2G";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrAFP_A2G_FILE = new Reader();
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

        private void Access_AFP_A2G_FILE()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("AFP_PAYMENT_SIGN, ");
            strSQL.Append("AFP_PAYMENT_AMT, ");
            strSQL.Append("DOC_AFP_PAYM_GROUP, ");
            strSQL.Append("AFP_PAYMENT_PERCENTAGE, ");
            strSQL.Append("AFP_GROUP_NAME ");
            strSQL.Append("FROM SEQUENTIAL.AFP_A2G_FILE ");

            strSQL.Append(Choose());

            rdrAFP_A2G_FILE.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.m_strFlatFileDictionary, ReportFunctions.TextFiles);

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

        private decimal X_PAYMENT_AMT()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrAFP_A2G_FILE.GetString("AFP_PAYMENT_SIGN")) == QDesign.NULL(" "))
                {
                    decReturnValue = rdrAFP_A2G_FILE.GetNumber("AFP_PAYMENT_AMT");
                }
                else
                {
                    decReturnValue = 0 - rdrAFP_A2G_FILE.GetNumber("AFP_PAYMENT_AMT");
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        #endregion

        #region " CONTROLS "

        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.REPORT, "SEQUENTIAL.AFP_A2G_FILE.DOC_AFP_PAYM_GROUP", DataTypes.Character, 4);
                AddControl(ReportSection.REPORT, "X_PAYMENT_AMT", DataTypes.Numeric, 11);
                AddControl(ReportSection.REPORT, "SEQUENTIAL.AFP_A2G_FILE.AFP_PAYMENT_PERCENTAGE", DataTypes.Numeric, 5);
                AddControl(ReportSection.REPORT, "SEQUENTIAL.AFP_A2G_FILE.AFP_GROUP_NAME", DataTypes.Character, 75);
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
        //# Do not delete, modify or move it.  Updated: 9/28/2017 10:34:52 AM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "SEQUENTIAL.AFP_A2G_FILE.DOC_AFP_PAYM_GROUP":
                    return Common.StringToField(rdrAFP_A2G_FILE.GetString("DOC_AFP_PAYM_GROUP").PadRight(4, ' '));

                case "X_PAYMENT_AMT":
                    return X_PAYMENT_AMT().ToString().ToString().PadLeft(11, ' ');

                case "SEQUENTIAL.AFP_A2G_FILE.AFP_PAYMENT_PERCENTAGE":
                    return rdrAFP_A2G_FILE.GetNumber("AFP_PAYMENT_PERCENTAGE").ToString().PadLeft(5, ' ');

                case "SEQUENTIAL.AFP_A2G_FILE.AFP_GROUP_NAME":
                    return Common.StringToField(rdrAFP_A2G_FILE.GetString("AFP_GROUP_NAME").PadRight(75, ' '));

                default:
                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_AFP_A2G_FILE();

                while (rdrAFP_A2G_FILE.Read())
                {
                    WriteData();
                }
                rdrAFP_A2G_FILE.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrAFP_A2G_FILE != null))
            {
                rdrAFP_A2G_FILE.Close();
                rdrAFP_A2G_FILE = null;
            }
        }


        #endregion

        #endregion
    }
}
