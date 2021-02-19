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
    public class R022G_2 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R022G_2";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrR022G = new Reader();

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
                Sort = "X_CLINIC ASC, CLMHDR_REFERENCE ASC, KEY_CLM_BATCH_NBR ASC, KEY_CLM_CLAIM_NBR ASC";
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

        private void Access_R022G()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("X_CLINIC, ");
            strSQL.Append("CLMHDR_REFERENCE, ");
            strSQL.Append("KEY_CLM_BATCH_NBR, ");
            strSQL.Append("KEY_CLM_CLAIM_NBR, ");
            strSQL.Append("CLMHDR_STATUS_OHIP, ");
            strSQL.Append("CLMHDR_AGENT_CD, ");
            strSQL.Append("CLMHDR_SERV_DATE, ");
            strSQL.Append("CLMHDR_TAPE_SUBMIT_IND, ");
            strSQL.Append("PAT_SURNAME, ");
            strSQL.Append("BALANCE_DUE, ");
            strSQL.Append("CLMHDR_DATE_CASH_TAPE_PAYMENT ");
            strSQL.Append("FROM TEMPORARYDATA.R022G ");

            strSQL.Append(Choose());

            rdrR022G.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
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
            if ((QDesign.NULL(X_PRINT_FLAG()) == "Y"))
            {
                blnSelected = true;
            }
        
            return blnSelected;
        }

        #endregion

        #region " DEFINES "

        private string X_PRINT_FLAG()
        {
            string strReturnValue = string.Empty;
            try
            {
                if (((QDesign.NULL(rdrR022G.GetString("X_CLINIC")) == "78" 
                            || QDesign.NULL(rdrR022G.GetString("X_CLINIC")) == "79" 
                            || QDesign.NULL(rdrR022G.GetString("X_CLINIC")) == "80" 
                            || QDesign.NULL(rdrR022G.GetString("X_CLINIC")) == "82" 
                            || QDesign.NULL(rdrR022G.GetString("X_CLINIC")) == "86" 
                            || QDesign.NULL(rdrR022G.GetString("X_CLINIC")) == "88" 
                            || QDesign.NULL(rdrR022G.GetString("X_CLINIC")) == "89" 
                            || (rdrR022G.GetString("X_CLINIC").CompareTo("91") >= 0 && rdrR022G.GetString("X_CLINIC").CompareTo("95") <= 0)) 
                            && QDesign.NULL(rdrR022G.GetString("CLMHDR_STATUS_OHIP")) == "55") 
                            || ((QDesign.NULL(rdrR022G.GetString("X_CLINIC")) == "78" 
                            || QDesign.NULL(rdrR022G.GetString("X_CLINIC")) == "79" 
                            || QDesign.NULL(rdrR022G.GetString("X_CLINIC")) == "88") 
                            && QDesign.NULL(rdrR022G.GetString("CLMHDR_STATUS_OHIP")) == "36"))
                {
                    strReturnValue = "N";
                }
                else
                {
                    strReturnValue = "Y";
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
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
                 AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.R022G.X_CLINIC", DataTypes.Numeric, 2);
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.R022G.CLMHDR_AGENT_CD", DataTypes.Numeric, 1);
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.R022G.KEY_CLM_BATCH_NBR", DataTypes.Character, 8);
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.R022G.KEY_CLM_CLAIM_NBR", DataTypes.Numeric, 2);
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.R022G.CLMHDR_SERV_DATE", DataTypes.Numeric, 8);
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.R022G.CLMHDR_TAPE_SUBMIT_IND", DataTypes.Character, 1);
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.R022G.PAT_SURNAME", DataTypes.Character, 18);
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.R022G.BALANCE_DUE", DataTypes.Numeric, 6);
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.R022G.CLMHDR_STATUS_OHIP", DataTypes.Character, 2);
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.R022G.CLMHDR_REFERENCE", DataTypes.Character, 11);
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.R022G.CLMHDR_DATE_CASH_TAPE_PAYMENT", DataTypes.Character, 8);
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
        // # Do not delete, modify or move it.  Updated: 2018-05-11 7:47:38 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "TEMPORARYDATA.R022G.X_CLINIC":
                    return rdrR022G.GetNumber("X_CLINIC").ToString();

                case "TEMPORARYDATA.R022G.CLMHDR_AGENT_CD":
                    return rdrR022G.GetNumber("CLMHDR_AGENT_CD").ToString();

                case "TEMPORARYDATA.R022G.KEY_CLM_BATCH_NBR":
                    return Common.StringToField(rdrR022G.GetString("KEY_CLM_BATCH_NBR"));

                case "TEMPORARYDATA.R022G.KEY_CLM_CLAIM_NBR":
                    return rdrR022G.GetNumber("KEY_CLM_CLAIM_NBR").ToString();

                case "TEMPORARYDATA.R022G.CLMHDR_SERV_DATE":
                    return rdrR022G.GetNumber("CLMHDR_SERV_DATE").ToString();

                case "TEMPORARYDATA.R022G.CLMHDR_TAPE_SUBMIT_IND":
                    return Common.StringToField(rdrR022G.GetString("CLMHDR_TAPE_SUBMIT_IND"));

                case "TEMPORARYDATA.R022G.PAT_SURNAME":
                    return Common.StringToField(rdrR022G.GetString("PAT_SURNAME"));

                case "TEMPORARYDATA.R022G.BALANCE_DUE":
                    return rdrR022G.GetNumber("BALANCE_DUE").ToString();

                case "TEMPORARYDATA.R022G.CLMHDR_STATUS_OHIP":
                    return Common.StringToField(rdrR022G.GetString("CLMHDR_STATUS_OHIP"));

                case "TEMPORARYDATA.R022G.CLMHDR_REFERENCE":
                    return Common.StringToField(rdrR022G.GetString("CLMHDR_REFERENCE"));

                case "TEMPORARYDATA.R022G.CLMHDR_DATE_CASH_TAPE_PAYMENT":
                    return Common.StringToField(rdrR022G.GetString("CLMHDR_DATE_CASH_TAPE_PAYMENT").PadLeft(8, ' '));

                default:
                    return string.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                Access_R022G();
                while (rdrR022G.Read())
                {
                    WriteData();
                }
            
                rdrR022G.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrR022G == null))
            {
                rdrR022G.Close();
                rdrR022G = null;
            }
        }

        #endregion

        #endregion
    }
}
