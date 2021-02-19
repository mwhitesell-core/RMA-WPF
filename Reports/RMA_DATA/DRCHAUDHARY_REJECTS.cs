//  link clmhdr-doc-nbr to doc-nbr      &
//  of f020-doctor-mstr opt           &
using Core.DataAccess.SqlServer;
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
    public class DRCHAUDHARY_REJECTS : BaseRDLClass
    {
        protected const string REPORT_NAME = "DRCHAUDHARY_REJECTS";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrF087_SUBMITTED_REJECTED_CLAIMS_HDR = new Reader();
        private Reader rdrF093_OHIP_ERROR_MSG_MSTR = new Reader();
        private Reader rdrF002_CLAIMS_MSTR = new Reader();
        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                //  Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;
                Sort = "CLMHDR_DOC_NBR ASC, OHIP_ERR_CAT_CODE ASC, SUBMITTED_REJECTED_CLAIM ASC, OHIP_ERR_CODE ASC, EDT_PROCESS_DATE DESC";
                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return ReportData;
        }
        private void Access_F087_SUBMITTED_REJECTED_CLAIMS_HDR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("OHIP_ERR_CODE, ");
            strSQL.Append("CLMHDR_BATCH_NBR, ");
            strSQL.Append("CLMHDR_CLAIM_NBR, ");
            strSQL.Append("CLMHDR_BATCH_NBR, ");
            strSQL.Append("CLMHDR_CLAIM_NBR, ");
            strSQL.Append("EDT_PROCESS_DATE, ");
            strSQL.Append("CHARGE_STATUS, ");
            strSQL.Append("CLMHDR_DOC_NBR, ");
            strSQL.Append("EDT_HEALTH_NBR, ");
            strSQL.Append("EDT_HEALTH_VERSION_CD ");
            strSQL.Append("FROM INDEXED.F087_SUBMITTED_REJECTED_CLAIMS_HDR ");

            strSQL.Append(Choose());

            rdrF087_SUBMITTED_REJECTED_CLAIMS_HDR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_F093_OHIP_ERROR_MSG_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("OHIP_ERR_CODE, ");
            strSQL.Append("OHIP_ERR_CAT_CODE, ");
            strSQL.Append("OHIP_ERR_DESCRIPTION ");
            strSQL.Append("FROM INDEXED.F093_OHIP_ERROR_MSG_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("OHIP_ERR_CODE = ").Append(Common.StringToField(rdrF087_SUBMITTED_REJECTED_CLAIMS_HDR.GetString("OHIP_ERR_CODE")));

            rdrF093_OHIP_ERROR_MSG_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_F002_CLAIMS_MSTR() {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("KEY_CLM_TYPE, ");
            strSQL.Append("KEY_CLM_BATCH_NBR, ");
            strSQL.Append("KEY_CLM_CLAIM_NBR, ");
            strSQL.Append("KEY_CLM_SERV_CODE, ");
            strSQL.Append("KEY_CLM_ADJ_NBR, ");
            strSQL.Append("CLMHDR_SERV_DATE ");
            strSQL.Append("FROM INDEXED.F002_CLAIMS_MSTR_HDR ");
            strSQL.Append("WHERE ");
            strSQL.Append("KEY_CLM_TYPE = ").Append("'B'");
            strSQL.Append(" AND KEY_CLM_BATCH_NBR = ").Append(Common.StringToField(rdrF087_SUBMITTED_REJECTED_CLAIMS_HDR.GetString("CLMHDR_BATCH_NBR")));
            strSQL.Append(" AND KEY_CLM_CLAIM_NBR = ").Append(rdrF087_SUBMITTED_REJECTED_CLAIMS_HDR.GetNumber("CLMHDR_CLAIM_NBR"));
            strSQL.Append(" AND KEY_CLM_SERV_CODE = ").Append("00000");
            strSQL.Append(" AND KEY_CLM_ADJ_NBR = ").Append("0");

            rdrF002_CLAIMS_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
    
        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(string.Empty);
            //strChoose.Append(ReportDataFunctions.GetWhereCondition("SUBMITTED_REJECTED_CLAIM", "22V59@", true)); parent to batch nbr and claim nbr
            strChoose.Append("WHERE (CLMHDR_BATCH_NBR LIKE '22V59%' ");
            strChoose.Append("OR CLMHDR_BATCH_NBR LIKE '33V59%') ");
            strChoose.Append("AND EDT_PROCESS_DATE BETWEEN 20160701 AND 20170630");
            return strChoose.ToString();
        }
    
        public override bool SelectIf()
        {
            bool blnSelected = false;
            if (((QDesign.NULL(rdrF087_SUBMITTED_REJECTED_CLAIMS_HDR.GetString("CHARGE_STATUS")) == "Y") 
                        && (QDesign.NULL(rdrF093_OHIP_ERROR_MSG_MSTR.GetString("OHIP_ERR_CAT_CODE")) != "R")))
            {
                blnSelected = true;
            }
        
            return blnSelected;
        }
    
        private string COMMA()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = "~";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return strReturnValue;
        }
    
        private string F087_SUBMITTED_REJECTED_CLAIMS_HDR_SUBMITTED_REJECTED_CLAIM()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = (rdrF087_SUBMITTED_REJECTED_CLAIMS_HDR.GetString("CLMHDR_BATCH_NBR") + rdrF087_SUBMITTED_REJECTED_CLAIMS_HDR.GetNumber("CLMHDR_CLAIM_NBR").ToString().PadLeft(2, '0'));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return strReturnValue;
        }
        public override void DeclareReportControls()
        {
            try
            {
                 AddControl(ReportSection.FOOTING_AT, "SUBMITTED_REJECTED_CLAIM", DataTypes.Character, 10);
                 AddControl(ReportSection.FOOTING_AT, "COMMA", DataTypes.Character, 1);
                 AddControl(ReportSection.FOOTING_AT, "INDEXED.F002_CLAIMS_MSTR.CLMHDR_SERV_DATE", DataTypes.Numeric, 8);
                 AddControl(ReportSection.FOOTING_AT, "INDEXED.F087_SUBMITTED_REJECTED_CLAIMS_HDR.OHIP_ERR_CODE", DataTypes.Character, 3);
                 AddControl(ReportSection.FOOTING_AT, "INDEXED.F093_OHIP_ERROR_MSG_MSTR.OHIP_ERR_DESCRIPTION", DataTypes.Character, 60);
                 AddControl(ReportSection.FOOTING_AT, "INDEXED.F087_SUBMITTED_REJECTED_CLAIMS_HDR.EDT_HEALTH_NBR", DataTypes.Character, 10);
                 AddControl(ReportSection.FOOTING_AT, "INDEXED.F087_SUBMITTED_REJECTED_CLAIMS_HDR.EDT_HEALTH_VERSION_CD", DataTypes.Character, 2);
                 AddControl(ReportSection.REPORT, "INDEXED.F087_SUBMITTED_REJECTED_CLAIMS_HDR.CLMHDR_DOC_NBR", DataTypes.Character, 3);
                 AddControl(ReportSection.REPORT, "INDEXED.F093_OHIP_ERROR_MSG_MSTR.OHIP_ERR_CAT_CODE", DataTypes.Character, 1);
                 AddControl(ReportSection.REPORT, "INDEXED.F087_SUBMITTED_REJECTED_CLAIMS_HDR.EDT_PROCESS_DATE", DataTypes.Numeric, 8);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
    
        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-07-30 10:52:25 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "SUBMITTED_REJECTED_CLAIM":
                    return Common.StringToField(F087_SUBMITTED_REJECTED_CLAIMS_HDR_SUBMITTED_REJECTED_CLAIM(), intSize);

                case "COMMA":
                    return Common.StringToField(COMMA(), intSize);

                case "INDEXED.F002_CLAIMS_MSTR.CLMHDR_SERV_DATE":
                    return rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_SERV_DATE").ToString();

                case "INDEXED.F087_SUBMITTED_REJECTED_CLAIMS_HDR.OHIP_ERR_CODE":
                    return Common.StringToField(rdrF087_SUBMITTED_REJECTED_CLAIMS_HDR.GetString("OHIP_ERR_CODE"));

                case "INDEXED.F093_OHIP_ERROR_MSG_MSTR.OHIP_ERR_DESCRIPTION":
                    return Common.StringToField(rdrF093_OHIP_ERROR_MSG_MSTR.GetString("OHIP_ERR_DESCRIPTION"));

                case "INDEXED.F087_SUBMITTED_REJECTED_CLAIMS_HDR.EDT_HEALTH_NBR":
                    return Common.StringToField(rdrF087_SUBMITTED_REJECTED_CLAIMS_HDR.GetString("EDT_HEALTH_NBR"));

                case "INDEXED.F087_SUBMITTED_REJECTED_CLAIMS_HDR.EDT_HEALTH_VERSION_CD":
                    return Common.StringToField(rdrF087_SUBMITTED_REJECTED_CLAIMS_HDR.GetString("EDT_HEALTH_VERSION_CD"));

                case "INDEXED.F087_SUBMITTED_REJECTED_CLAIMS_HDR.CLMHDR_DOC_NBR":
                    return Common.StringToField(rdrF087_SUBMITTED_REJECTED_CLAIMS_HDR.GetString("CLMHDR_DOC_NBR"));

                case "INDEXED.F093_OHIP_ERROR_MSG_MSTR.OHIP_ERR_CAT_CODE":
                    return Common.StringToField(rdrF093_OHIP_ERROR_MSG_MSTR.GetString("OHIP_ERR_CAT_CODE"));

                case "INDEXED.F087_SUBMITTED_REJECTED_CLAIMS_HDR.EDT_PROCESS_DATE":
                    return rdrF087_SUBMITTED_REJECTED_CLAIMS_HDR.GetNumber("EDT_PROCESS_DATE").ToString();

                default:
                    return string.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                Access_F087_SUBMITTED_REJECTED_CLAIMS_HDR();
                while (rdrF087_SUBMITTED_REJECTED_CLAIMS_HDR.Read())
                {
                    Link_F093_OHIP_ERROR_MSG_MSTR();
                    while (rdrF093_OHIP_ERROR_MSG_MSTR.Read())
                    {
                        Link_F002_CLAIMS_MSTR();
                        while (rdrF002_CLAIMS_MSTR.Read())
                        {
                            WriteData();
                        }
                    
                        rdrF002_CLAIMS_MSTR.Close();
                    }
                
                    rdrF093_OHIP_ERROR_MSG_MSTR.Close();
                }
            
                rdrF087_SUBMITTED_REJECTED_CLAIMS_HDR.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrF087_SUBMITTED_REJECTED_CLAIMS_HDR == null))
            {
                rdrF087_SUBMITTED_REJECTED_CLAIMS_HDR.Close();
                rdrF087_SUBMITTED_REJECTED_CLAIMS_HDR = null;
            }
        
            if (!(rdrF093_OHIP_ERROR_MSG_MSTR == null))
            {
                rdrF093_OHIP_ERROR_MSG_MSTR.Close();
                rdrF093_OHIP_ERROR_MSG_MSTR = null;
            }
        
            if (!(rdrF002_CLAIMS_MSTR == null))
            {
                rdrF002_CLAIMS_MSTR.Close();
                rdrF002_CLAIMS_MSTR = null;
            }
        }
    }
}
