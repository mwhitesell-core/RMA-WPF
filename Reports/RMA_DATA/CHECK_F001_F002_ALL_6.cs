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
    public class CHECK_F001_F002_ALL_6 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "CHECK_F001_F002_ALL_6";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrEXTF002HDRDTL = new Reader();
        private Reader rdrF002_CLAIMS_MSTR = new Reader();

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

        private void Access_EXTF002HDRDTL()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("KEY_CLM_BATCH_NBR, ");
            strSQL.Append("KEY_CLM_CLAIM_NBR, ");
            strSQL.Append("CLMDTL_FEE_OHIP, ");
            strSQL.Append("BATCTRL_BATCH_TYPE, ");
            strSQL.Append("BATCTRL_ADJ_CD ");
            strSQL.Append("FROM TEMPORARYDATA.EXTF002HDRDTL ");

            strSQL.Append(Choose());

            rdrEXTF002HDRDTL.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
            strSQL = null;
        }
        private void Link_F002_CLAIMS_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("CLMHDR_TOT_CLAIM_AR_OHIP, ");
            strSQL.Append("CLMHDR_MANUAL_AND_TAPE_PAYMENTS ");
            strSQL.Append("FROM INDEXED.F002_CLAIMS_MSTR_HDR ");
            strSQL.Append("WHERE ");
            strSQL.Append("KEY_CLM_TYPE = '").Append("B");
            strSQL.Append("'");
            strSQL.Append(" AND KEY_CLM_BATCH_NBR = ").Append(Common.StringToField(rdrEXTF002HDRDTL.GetString("KEY_CLM_BATCH_NBR")));
            strSQL.Append(" AND KEY_CLM_CLAIM_NBR = ").Append(rdrEXTF002HDRDTL.GetNumber("KEY_CLM_CLAIM_NBR"));
            strSQL.Append(" AND KEY_CLM_SERV_CODE = ").Append("00000");
            strSQL.Append(" AND KEY_CLM_ADJ_NBR = ").Append("0");

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
            if ((((QDesign.NULL(rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_TOT_CLAIM_AR_OHIP")) != QDesign.NULL(rdrEXTF002HDRDTL.GetNumber("CLMDTL_FEE_OHIP"))) 
                        && (QDesign.NULL(rdrEXTF002HDRDTL.GetString("BATCTRL_BATCH_TYPE")) == "C")) 
                        || (((QDesign.NULL(rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_TOT_CLAIM_AR_OHIP")) != QDesign.NULL(rdrEXTF002HDRDTL.GetNumber("CLMDTL_FEE_OHIP"))) 
                        && ((QDesign.NULL(rdrEXTF002HDRDTL.GetString("BATCTRL_BATCH_TYPE")) == "A") 
                        && (QDesign.NULL(rdrEXTF002HDRDTL.GetString("BATCTRL_ADJ_CD")) != "A"))) 
                        || (((QDesign.NULL(rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_TOT_CLAIM_AR_OHIP")) != QDesign.NULL(rdrEXTF002HDRDTL.GetNumber("CLMDTL_FEE_OHIP"))) 
                        && ((QDesign.NULL(rdrEXTF002HDRDTL.GetString("BATCTRL_BATCH_TYPE")) == "A") 
                        && (QDesign.NULL(rdrEXTF002HDRDTL.GetString("BATCTRL_ADJ_CD")) == "A"))) 
                        || ((QDesign.NULL(rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_MANUAL_AND_TAPE_PAYMENTS")) != QDesign.NULL(rdrEXTF002HDRDTL.GetNumber("CLMDTL_FEE_OHIP"))) 
                        && (QDesign.NULL(rdrEXTF002HDRDTL.GetString("BATCTRL_BATCH_TYPE")) == "P"))))))
            {
                blnSelected = true;
            }
        
            return blnSelected;
        }

        #endregion

        #region " DEFINES "

        //  TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:
        private string BATCTRL_BATCH_TYPE_ADJ_CD()
        {
            string strReturnValue = string.Empty;
            try
            {
                if ((QDesign.NULL(rdrEXTF002HDRDTL.GetString("BATCTRL_BATCH_TYPE")) == "C"))
                {
                    strReturnValue = rdrEXTF002HDRDTL.GetString("BATCTRL_BATCH_TYPE");
                }
                else
                {
                    strReturnValue = (rdrEXTF002HDRDTL.GetString("BATCTRL_BATCH_TYPE") + ("/" + rdrEXTF002HDRDTL.GetString("BATCTRL_ADJ_CD")));
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
        return strReturnValue;
    }
    public override void DeclareReportControls() {
        try
        {
 AddControl(ReportSection.REPORT, "TEMPORARYDATA.EXTF002HDRDTL.KEY_CLM_BATCH_NBR", DataTypes.Character, 8);
 AddControl(ReportSection.REPORT, "TEMPORARYDATA.EXTF002HDRDTL.KEY_CLM_CLAIM_NBR", DataTypes.Numeric, 2);
 AddControl(ReportSection.REPORT, "BATCTRL_BATCH_TYPE_ADJ_CD", DataTypes.Character, 3);
 AddControl(ReportSection.REPORT, "TEMPORARYDATA.EXTF002HDRDTL.CLMDTL_FEE_OHIP", DataTypes.Numeric, 9);
 AddControl(ReportSection.REPORT, "INDEXED.F002_CLAIMS_MSTR.CLMHDR_TOT_CLAIM_AR_OHIP", DataTypes.Numeric, 9);
 AddControl(ReportSection.REPORT, "INDEXED.F002_CLAIMS_MSTR.CLMHDR_MANUAL_AND_TAPE_PAYMENTS", DataTypes.Numeric, 9);
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
            case "TEMPORARYDATA.EXTF002HDRDTL.KEY_CLM_BATCH_NBR":
                return Common.StringToField(rdrEXTF002HDRDTL.GetString("KEY_CLM_BATCH_NBR"));
            case "TEMPORARYDATA.EXTF002HDRDTL.KEY_CLM_CLAIM_NBR":
                return rdrEXTF002HDRDTL.GetNumber("KEY_CLM_CLAIM_NBR").ToString();
            case "BATCTRL_BATCH_TYPE_ADJ_CD":
                return Common.StringToField(BATCTRL_BATCH_TYPE_ADJ_CD(), intSize);
            case "TEMPORARYDATA.EXTF002HDRDTL.CLMDTL_FEE_OHIP":
                return rdrEXTF002HDRDTL.GetNumber("CLMDTL_FEE_OHIP").ToString();
            case "INDEXED.F002_CLAIMS_MSTR.CLMHDR_TOT_CLAIM_AR_OHIP":
                return rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_TOT_CLAIM_AR_OHIP").ToString();
            case "INDEXED.F002_CLAIMS_MSTR.CLMHDR_MANUAL_AND_TAPE_PAYMENTS":
                return rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_MANUAL_AND_TAPE_PAYMENTS").ToString();
            default:
                return String.Empty;
        }
    }
    public override void AccessData() {
        try
        {
            // TODO: Some manual steps maybe required.
            Access_EXTF002HDRDTL();
            while (rdrEXTF002HDRDTL.Read()) {
                Link_F002_CLAIMS_MSTR();
                while (rdrF002_CLAIMS_MSTR.Read()) {
                    WriteData();
                }
                
                    rdrF002_CLAIMS_MSTR.Close();
                }
            
                rdrEXTF002HDRDTL.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrEXTF002HDRDTL == null))
            {
                rdrEXTF002HDRDTL.Close();
                rdrEXTF002HDRDTL = null;
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
