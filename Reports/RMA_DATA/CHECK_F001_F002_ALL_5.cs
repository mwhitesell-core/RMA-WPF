//  2013/03/21 - MC2
//  ----------------------------------
//  access claim dtl to get amount for each claim    
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
    public class CHECK_F001_F002_ALL_5 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "CHECK_F001_F002_ALL_5";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrEXTF002HDR = new Reader();
        private Reader rdrF002_CLAIMS_MSTR = new Reader();
        private Reader rdrEXTF002HDRDTL = new Reader();

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
                //  Create Subfile.
                SubFile = true;
                SubFileName = "EXTF002HDRDTL";
                SubFileType = SubFileType.Keep;
                SubFileAT = "KEY_CLM_CLAIM_NBR";
                Sort = "KEY_CLM_BATCH_NBR ASC, KEY_CLM_CLAIM_NBR ASC";
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

        private void Access_EXTF002HDR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("BATCTRL_BATCH_NBR, ");
            strSQL.Append("KEY_CLM_BATCH_NBR, ");
            strSQL.Append("KEY_CLM_TYPE, ");
            strSQL.Append("BATCTRL_BATCH_TYPE, ");
            strSQL.Append("BATCTRL_ADJ_CD ");
            strSQL.Append("FROM TEMPORARYDATA.EXTF002HDR ");

            strSQL.Append(Choose());

            rdrEXTF002HDR.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
            strSQL = null;
        }
        private void Link_F002_CLAIMS_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("KEY_CLM_TYPE, ");
            strSQL.Append("KEY_CLM_BATCH_NBR, ");
            strSQL.Append("CLMDTL_OMA_CD, ");
            strSQL.Append("KEY_CLM_CLAIM_NBR, ");
            strSQL.Append("CLMDTL_FEE_OHIP ");
            strSQL.Append("FROM INDEXED.F002_CLAIMS_MSTR_DTL ");
            strSQL.Append("WHERE ");
            strSQL.Append("KEY_CLM_TYPE = '").Append("B");
            strSQL.Append("'");
            strSQL.Append(" AND KEY_CLM_BATCH_NBR = ").Append(Common.StringToField(rdrEXTF002HDR.GetString("BATCTRL_BATCH_NBR")));

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
            if (((QDesign.NULL(rdrF002_CLAIMS_MSTR.GetString("CLMDTL_OMA_CD")) != "0000") 
                        && (QDesign.NULL(rdrF002_CLAIMS_MSTR.GetString("CLMDTL_OMA_CD")) != "ZZZZ")))
            {
                blnSelected = true;
            }
        
        return blnSelected;
    }
    public override void DeclareReportControls() {
        try
        {
 AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.EXTF002HDR.KEY_CLM_TYPE", DataTypes.Character, 1);
 AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.EXTF002HDR.KEY_CLM_BATCH_NBR", DataTypes.Character, 8);
 AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR.KEY_CLM_CLAIM_NBR", DataTypes.Numeric, 2);
 AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.EXTF002HDR.BATCTRL_BATCH_TYPE", DataTypes.Character, 1);
 AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.EXTF002HDR.BATCTRL_ADJ_CD", DataTypes.Character, 1);
 AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR.CLMDTL_FEE_OHIP", DataTypes.Numeric, 9, SummaryType.SUBTOTAL, "KEY_CLM_CLAIM_NBR");
        }

        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
    }
    
    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 2018-05-09 7:36:49 AM
    public override string ReturnControlValue(string strControl, int intSize) {
        // TODO: Remove duplicate controls, if there are any.
        switch (strControl) {
            case "TEMPORARYDATA.EXTF002HDR.KEY_CLM_TYPE":
                return Common.StringToField(rdrF002_CLAIMS_MSTR.GetString("KEY_CLM_TYPE"));
            case "TEMPORARYDATA.EXTF002HDR.KEY_CLM_BATCH_NBR":
                return Common.StringToField(rdrF002_CLAIMS_MSTR.GetString("KEY_CLM_BATCH_NBR"));
            case "INDEXED.F002_CLAIMS_MSTR.KEY_CLM_CLAIM_NBR":
                return rdrF002_CLAIMS_MSTR.GetNumber("KEY_CLM_CLAIM_NBR").ToString();
            case "TEMPORARYDATA.EXTF002HDR.BATCTRL_BATCH_TYPE":
                return Common.StringToField(rdrEXTF002HDR.GetString("BATCTRL_BATCH_TYPE"));
            case "TEMPORARYDATA.EXTF002HDR.BATCTRL_ADJ_CD":
                return Common.StringToField(rdrEXTF002HDR.GetString("BATCTRL_ADJ_CD"));
            case "INDEXED.F002_CLAIMS_MSTR.CLMDTL_FEE_OHIP":
                return rdrF002_CLAIMS_MSTR.GetNumber("CLMDTL_FEE_OHIP").ToString();
            default:
                return String.Empty;
        }
    }
    public override void AccessData() {
        try
        {
            // TODO: Some manual steps maybe required.
            Access_EXTF002HDR();
            while (rdrEXTF002HDR.Read()) {
                Link_F002_CLAIMS_MSTR();
                while (rdrF002_CLAIMS_MSTR.Read()) {
                    WriteData();
                }
                
                    rdrF002_CLAIMS_MSTR.Close();
                }
            
                rdrEXTF002HDR.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders() {
            if (!(rdrEXTF002HDR == null))
            {
                rdrEXTF002HDR.Close();
                rdrEXTF002HDR = null;
            }
        
            if (!(rdrF002_CLAIMS_MSTR == null))
            {
                rdrF002_CLAIMS_MSTR.Close();
                rdrF002_CLAIMS_MSTR = null;
            }
        }

        #endregion

        #endregion
    }
}
