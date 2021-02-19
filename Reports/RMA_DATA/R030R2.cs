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
    public class R030R2 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R030R2";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrR031A_PAY_BATCHES = new Reader();
        private Reader rdrF002_CLAIMS_MSTR = new Reader();
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

                // Create Subfile.
                SubFile = true;
                SubFileName = "R031A_PAY_BATCHES";
                SubFileType = SubFileType.Keep;

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

        private void Access_R031A_PAY_BATCHES()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("BATCTRL_BATCH_NBR ");
            strSQL.Append("FROM TEMPORARYDATA.R031A_PAY_BATCHES ");

            strSQL.Append(Choose());

            rdrR031A_PAY_BATCHES.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);

            strSQL = null;
        }

        private void Link_F002_CLAIMS_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("KEY_CLM_TYPE, ");
            strSQL.Append("KEY_CLM_BATCH_NBR, ");
            strSQL.Append("CLMDTL_OMA_CD, ");
            strSQL.Append("CLMHDR_BATCH_NBR, ");
            strSQL.Append(" CLMHDR_CLAIM_NBR, ");
            strSQL.Append(" CLMHDR_ADJ_OMA_CD, ");
            strSQL.Append(" CLMHDR_ADJ_OMA_SUFF, ");
            strSQL.Append(" CLMHDR_ADJ_ADJ_NBR, ");
            strSQL.Append("KEY_CLM_CLAIM_NBR, ");
            strSQL.Append("CLMHDR_MANUAL_AND_TAPE_PAYMENTS ");
            strSQL.Append("FROM INDEXED.F002_CLAIMS_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("KEY_CLM_TYPE = ").Append(Common.StringToField("B"));
            strSQL.Append(" AND KEY_CLM_BATCH_NBR = ").Append(Common.StringToField(rdrR031A_PAY_BATCHES.GetString("BATCTRL_BATCH_NBR")));

            rdrF002_CLAIMS_MSTR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

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

            if (QDesign.NULL(rdrF002_CLAIMS_MSTR.GetString("CLMDTL_OMA_CD")) == QDesign.NULL("0000") & QDesign.NULL(QDesign.Substring(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_CLAIM_ID"), 3, 3)) == QDesign.NULL("   "))
            {
                blnSelected = true;
            }

            return blnSelected;
        }

        #endregion

        #region " DEFINES "

        private string F002_CLAIMS_MSTR_CLMHDR_CLAIM_ID()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = (rdrF002_CLAIMS_MSTR.GetString("CLMHDR_BATCH_NBR") + rdrF002_CLAIMS_MSTR.GetString("CLMHDR_CLAIM_NBR") + rdrF002_CLAIMS_MSTR.GetString("CLMHDR_ADJ_OMA_CD") + rdrF002_CLAIMS_MSTR.GetString("CLMHDR_ADJ_OMA_SUFF") + rdrF002_CLAIMS_MSTR.GetString("CLMHDR_ADJ_ADJ_NBR"));
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
            return strReturnValue;
        }

        #endregion

        #region " CONTROLS "

        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.R031A_PAY_BATCHES.BATCTRL_BATCH_NBR", DataTypes.Character, 8);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR.KEY_CLM_CLAIM_NBR", DataTypes.Numeric, 2);
                AddControl(ReportSection.SUMMARY, "F002_CLAIMS_MSTR_CLMHDR_CLAIM_ID", DataTypes.Character, 16);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR.CLMHDR_MANUAL_AND_TAPE_PAYMENTS", DataTypes.Numeric, 7);
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
        //# Do not delete, modify or move it.  Updated: 10/11/2017 7:11:54 AM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "TEMPORARYDATA.R031A_PAY_BATCHES.BATCTRL_BATCH_NBR":
                    return Common.StringToField(rdrR031A_PAY_BATCHES.GetString("BATCTRL_BATCH_NBR").PadRight(8, ' '));

                case "INDEXED.F002_CLAIMS_MSTR.KEY_CLM_CLAIM_NBR":
                    return rdrF002_CLAIMS_MSTR.GetNumber("KEY_CLM_CLAIM_NBR").ToString().PadLeft(2, ' ');

                case "F002_CLAIMS_MSTR_CLMHDR_CLAIM_ID":
                    return Common.StringToField(F002_CLAIMS_MSTR_CLMHDR_CLAIM_ID().PadRight(16, ' '));

                case "INDEXED.F002_CLAIMS_MSTR.CLMHDR_MANUAL_AND_TAPE_PAYMENTS":
                    return rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_MANUAL_AND_TAPE_PAYMENTS").ToString().PadLeft(7, ' ');

                default:

                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_R031A_PAY_BATCHES();

                while (rdrR031A_PAY_BATCHES.Read())
                {
                    Link_F002_CLAIMS_MSTR();
                    while (rdrF002_CLAIMS_MSTR.Read())
                    {
                        WriteData();
                    }
                    rdrF002_CLAIMS_MSTR.Close();
                }
                rdrR031A_PAY_BATCHES.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrR031A_PAY_BATCHES != null))
            {
                rdrR031A_PAY_BATCHES.Close();
                rdrR031A_PAY_BATCHES = null;
            }
            if ((rdrF002_CLAIMS_MSTR != null))
            {
                rdrF002_CLAIMS_MSTR.Close();
                rdrF002_CLAIMS_MSTR = null;
            }
        }


        #endregion

        #endregion
    }
}
