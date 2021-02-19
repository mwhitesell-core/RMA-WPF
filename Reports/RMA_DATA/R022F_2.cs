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
    public class R022F_2 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R022F_2";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrR022F = new Reader();

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
                Sort = "X_CLINIC ASC, CLMHDR_AGENT_CD ASC, KEY_CLM_BATCH_NBR ASC, KEY_CLM_CLAIM_NBR ASC";
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

        private void Access_R022F()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("X_CLINIC, ");
            strSQL.Append("CLMHDR_AGENT_CD, ");
            strSQL.Append("KEY_CLM_BATCH_NBR, ");
            strSQL.Append("KEY_CLM_CLAIM_NBR, ");
            strSQL.Append("CLMHDR_SERV_DATE, ");
            strSQL.Append("CLMHDR_TAPE_SUBMIT_IND, ");
            strSQL.Append("PAT_SURNAME, ");
            strSQL.Append("BALANCE_DUE, ");
            strSQL.Append("PAT_MESS_CODE ");
            strSQL.Append("FROM TEMPORARYDATA.R022F ");

            strSQL.Append(Choose());

            rdrR022F.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
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
                 AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.R022F.X_CLINIC", DataTypes.Character, 2);
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.R022F.CLMHDR_AGENT_CD", DataTypes.Numeric, 1);
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.R022F.KEY_CLM_BATCH_NBR", DataTypes.Character, 8);
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.R022F.KEY_CLM_CLAIM_NBR", DataTypes.Numeric, 2);
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.R022F.CLMHDR_SERV_DATE", DataTypes.Numeric, 8);
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.R022F.CLMHDR_TAPE_SUBMIT_IND", DataTypes.Character, 1);
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.R022F.PAT_SURNAME", DataTypes.Character, 18);
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.R022F.BALANCE_DUE", DataTypes.Numeric, 7);
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.R022F.PAT_MESS_CODE", DataTypes.Character, 3);
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
                case "TEMPORARYDATA.R022F.X_CLINIC":
                    return Common.StringToField(rdrR022F.GetString("X_CLINIC"));

                case "TEMPORARYDATA.R022F.CLMHDR_AGENT_CD":
                    return rdrR022F.GetNumber("CLMHDR_AGENT_CD").ToString();

                case "TEMPORARYDATA.R022F.KEY_CLM_BATCH_NBR":
                    return Common.StringToField(rdrR022F.GetString("KEY_CLM_BATCH_NBR"));

                case "TEMPORARYDATA.R022F.KEY_CLM_CLAIM_NBR":
                    return rdrR022F.GetNumber("KEY_CLM_CLAIM_NBR").ToString();

                case "TEMPORARYDATA.R022F.CLMHDR_SERV_DATE":
                    return rdrR022F.GetNumber("CLMHDR_SERV_DATE").ToString();

                case "TEMPORARYDATA.R022F.CLMHDR_TAPE_SUBMIT_IND":
                    return Common.StringToField(rdrR022F.GetString("CLMHDR_TAPE_SUBMIT_IND"));

                case "TEMPORARYDATA.R022F.PAT_SURNAME":
                    return Common.StringToField(rdrR022F.GetString("PAT_SURNAME"));

                case "TEMPORARYDATA.R022F.BALANCE_DUE":
                    return rdrR022F.GetNumber("BALANCE_DUE").ToString();

                case "TEMPORARYDATA.R022F.PAT_MESS_CODE":
                    return Common.StringToField(rdrR022F.GetString("PAT_MESS_CODE"));

                default:
                    return string.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                Access_R022F();
                while (rdrR022F.Read())
                {
                    WriteData();
                }
            
                rdrR022F.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrR022F == null))
            {
                rdrR022F.Close();
                rdrR022F = null;
            }
        }

        #endregion

        #endregion
    }
}
