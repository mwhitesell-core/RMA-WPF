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
    public class R030R3 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R030R3";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrR030R_UNDEFINED_DOC = new Reader();

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

        private void Access_R030R_UNDEFINED_DOC()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("BATCTRL_BATCH_NBR, ");
            strSQL.Append("KEY_CLM_CLAIM_NBR, ");
            strSQL.Append("CLMHDR_CLAIM_ID, ");
            strSQL.Append("CLMHDR_MANUAL_AND_TAPE_PAYMENTS ");
            strSQL.Append("FROM TEMPORARYDATA.R030R_UNDEFINED_DOC ");

            strSQL.Append(Choose());

            rdrR030R_UNDEFINED_DOC.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);

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
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R030R_UNDEFINED_DOC.BATCTRL_BATCH_NBR", DataTypes.Character, 8);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R030R_UNDEFINED_DOC.KEY_CLM_CLAIM_NBR", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R030R_UNDEFINED_DOC.CLMHDR_CLAIM_ID", DataTypes.Character, 16);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R030R_UNDEFINED_DOC.CLMHDR_MANUAL_AND_TAPE_PAYMENTS", DataTypes.Numeric, 7);
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
        //# Do not delete, modify or move it.  Updated: 9/27/2017 7:25:02 PM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "TEMPORARYDATA.R030R_UNDEFINED_DOC.BATCTRL_BATCH_NBR":
                    return Common.StringToField(rdrR030R_UNDEFINED_DOC.GetString("BATCTRL_BATCH_NBR").PadRight(8, ' '));

                case "TEMPORARYDATA.R030R_UNDEFINED_DOC.KEY_CLM_CLAIM_NBR":
                    return rdrR030R_UNDEFINED_DOC.GetNumber("KEY_CLM_CLAIM_NBR").ToString().PadLeft(2, ' ');

                case "TEMPORARYDATA.R030R_UNDEFINED_DOC.CLMHDR_CLAIM_ID":
                    return Common.StringToField(rdrR030R_UNDEFINED_DOC.GetString("CLMHDR_CLAIM_ID").PadRight(16, ' '));

                case "TEMPORARYDATA.R030R_UNDEFINED_DOC.CLMHDR_MANUAL_AND_TAPE_PAYMENTS":
                    return rdrR030R_UNDEFINED_DOC.GetNumber("CLMHDR_MANUAL_AND_TAPE_PAYMENTS").ToString().PadLeft(7, ' ');

                default:
                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_R030R_UNDEFINED_DOC();

                while (rdrR030R_UNDEFINED_DOC.Read())
                {
                    WriteData();
                }
                rdrR030R_UNDEFINED_DOC.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrR030R_UNDEFINED_DOC != null))
            {
                rdrR030R_UNDEFINED_DOC.Close();
                rdrR030R_UNDEFINED_DOC = null;
            }
        }


        #endregion

        #endregion
    }
}
