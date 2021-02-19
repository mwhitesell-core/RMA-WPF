//  doc     : f087_peds_rejects.qzs
//  purpose : Report pediatric eligibility rejects - report one per patient if same err code and same doc
//  who     : Department of Peds manager
//  Date           Who             Description
//  2010/08/29      Yasemin
//  2012/07/25      Yasemin add department 76
//  2015/07/21      MC1      change to check with edt-process-date instead of ped
//  change the same as costing5.qts
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
    public class F087_PEDS_REJECTS_BY_ERRCODE : BaseRDLClass
    {
        protected const string REPORT_NAME = "F087_PEDS_REJECTS_BY_ERRCODE";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrF087_SUBMITTED_REJECTED_CLAIMS_HDR = new Reader();
        private Reader rdrF020_DOCTOR_MSTR = new Reader();
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
                Sort = "CLMHDR_DOC_NBR ASC, CLMHDR_PAT_OHIP_ID_OR_CHART ASC, OHIP_ERR_CODE ASC, SUBMITTED_REJECTED_CLAIM DESC";
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
            strSQL.Append("CLMHDR_DOC_NBR, ");
            strSQL.Append("OHIP_ERR_CODE, ");
            strSQL.Append("CLMHDR_BATCH_NBR, ");
            strSQL.Append("CLMHDR_CLAIM_NBR, ");
            strSQL.Append("CHARGE_STATUS, ");
            strSQL.Append("EDT_PROCESS_DATE, ");
            strSQL.Append("CLMHDR_BATCH_NBR, ");
            strSQL.Append("CLMHDR_CLAIM_NBR ");
            strSQL.Append("FROM INDEXED.F087_SUBMITTED_REJECTED_CLAIMS_HDR ");

            strSQL.Append(Choose());

            rdrF087_SUBMITTED_REJECTED_CLAIMS_HDR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_F020_DOCTOR_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("DOC_DEPT, ");
            strSQL.Append("DOC_NAME ");
            strSQL.Append("FROM INDEXED.F020_DOCTOR_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_NBR = ").Append(Common.StringToField(rdrF087_SUBMITTED_REJECTED_CLAIMS_HDR.GetString("CLMHDR_DOC_NBR")));

            rdrF020_DOCTOR_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
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
        private void Link_F002_CLAIMS_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("KEY_CLM_TYPE, ");
            strSQL.Append("KEY_CLM_BATCH_NBR, ");
            strSQL.Append("KEY_CLM_CLAIM_NBR, ");
            strSQL.Append("KEY_CLM_SERV_CODE, ");
            strSQL.Append("KEY_CLM_ADJ_NBR, ");
            strSQL.Append("CLMHDR_PAT_KEY_TYPE, ");
            strSQL.Append("CLMHDR_PAT_KEY_DATA, ");
            strSQL.Append("CLMHDR_LOC, ");
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

            return strChoose.ToString();
        }
    
        public override bool SelectIf()
        {
            bool blnSelected = false;
            if ((QDesign.NULL(rdrF087_SUBMITTED_REJECTED_CLAIMS_HDR.GetString("CHARGE_STATUS")) == "Y") 
                        && (rdrF087_SUBMITTED_REJECTED_CLAIMS_HDR.GetNumber("EDT_PROCESS_DATE") >= 20160701) 
                        && (rdrF087_SUBMITTED_REJECTED_CLAIMS_HDR.GetNumber("EDT_PROCESS_DATE") <= 20170630) 
                        && ((QDesign.NULL(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT")) == QDesign.NULL(7d)) 
                        || (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT")) == QDesign.NULL(70d)) 
                        || (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT")) == QDesign.NULL(71d)) 
                        || (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT")) == QDesign.NULL(72d)) 
                        || (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT")) == QDesign.NULL(73d)) 
                        || (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT")) == QDesign.NULL(74d)) 
                        || (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT")) == QDesign.NULL(75d)) 
                        || (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT")) == QDesign.NULL(76d))))
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
                strReturnValue = rdrF087_SUBMITTED_REJECTED_CLAIMS_HDR.GetString("CLMHDR_BATCH_NBR") + QDesign.ASCII(rdrF087_SUBMITTED_REJECTED_CLAIMS_HDR.GetNumber("CLMHDR_CLAIM_NBR"), 2);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return strReturnValue;
        }
    
        private string F002_CLAIMS_MSTR_CLMHDR_PAT_OHIP_ID_OR_CHART()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = (rdrF002_CLAIMS_MSTR.GetString("CLMHDR_PAT_KEY_TYPE") + rdrF002_CLAIMS_MSTR.GetString("CLMHDR_PAT_KEY_DATA"));
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
                 AddControl(ReportSection.FOOTING_AT, "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT", DataTypes.Numeric, 2);
                 AddControl(ReportSection.FOOTING_AT, "INDEXED.F020_DOCTOR_MSTR.DOC_NBR", DataTypes.Character, 3);
                 AddControl(ReportSection.FOOTING_AT, "INDEXED.F020_DOCTOR_MSTR.DOC_NAME", DataTypes.Character, 24);
                 AddControl(ReportSection.FOOTING_AT, "INDEXED.F002_CLAIMS_MSTR.CLMHDR_LOC", DataTypes.Character, 4);
                 AddControl(ReportSection.FOOTING_AT, "INDEXED.F002_CLAIMS_MSTR.CLMHDR_SERV_DATE", DataTypes.Numeric, 8);
                 AddControl(ReportSection.FOOTING_AT, "INDEXED.F093_OHIP_ERROR_MSG_MSTR.OHIP_ERR_CAT_CODE", DataTypes.Character, 1);
                 AddControl(ReportSection.FOOTING_AT, "INDEXED.F087_SUBMITTED_REJECTED_CLAIMS_HDR.OHIP_ERR_CODE", DataTypes.Character, 3);
                 AddControl(ReportSection.FOOTING_AT, "INDEXED.F093_OHIP_ERROR_MSG_MSTR.OHIP_ERR_DESCRIPTION", DataTypes.Character, 60);
                 AddControl(ReportSection.REPORT, "INDEXED.F087_SUBMITTED_REJECTED_CLAIMS_HDR.CLMHDR_DOC_NBR", DataTypes.Character, 3);
                 AddControl(ReportSection.REPORT, "CLMHDR_PAT_OHIP_ID_OR_CHART", DataTypes.Character, 16);
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

                case "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT":
                    return rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT").ToString();

                case "INDEXED.F020_DOCTOR_MSTR.DOC_NBR":
                    return Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_NBR"));

                case "INDEXED.F020_DOCTOR_MSTR.DOC_NAME":
                    return Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_NAME"));

                case "INDEXED.F002_CLAIMS_MSTR.CLMHDR_LOC":
                    return Common.StringToField(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_LOC"));

                case "INDEXED.F002_CLAIMS_MSTR.CLMHDR_SERV_DATE":
                    return rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_SERV_DATE").ToString();

                case "INDEXED.F093_OHIP_ERROR_MSG_MSTR.OHIP_ERR_CAT_CODE":
                    return Common.StringToField(rdrF093_OHIP_ERROR_MSG_MSTR.GetString("OHIP_ERR_CAT_CODE"));

                case "INDEXED.F087_SUBMITTED_REJECTED_CLAIMS_HDR.OHIP_ERR_CODE":
                    return Common.StringToField(rdrF087_SUBMITTED_REJECTED_CLAIMS_HDR.GetString("OHIP_ERR_CODE"));

                case "INDEXED.F093_OHIP_ERROR_MSG_MSTR.OHIP_ERR_DESCRIPTION":
                    return Common.StringToField(rdrF093_OHIP_ERROR_MSG_MSTR.GetString("OHIP_ERR_DESCRIPTION"));

                case "INDEXED.F087_SUBMITTED_REJECTED_CLAIMS_HDR.CLMHDR_DOC_NBR":
                    return Common.StringToField(rdrF087_SUBMITTED_REJECTED_CLAIMS_HDR.GetString("CLMHDR_DOC_NBR"));

                case "CLMHDR_PAT_OHIP_ID_OR_CHART":
                    return Common.StringToField(F002_CLAIMS_MSTR_CLMHDR_PAT_OHIP_ID_OR_CHART(), intSize);

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
                    Link_F020_DOCTOR_MSTR();
                    while (rdrF020_DOCTOR_MSTR.Read())
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
                
                    rdrF020_DOCTOR_MSTR.Close();
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
        
            if (!(rdrF020_DOCTOR_MSTR == null))
            {
                rdrF020_DOCTOR_MSTR.Close();
                rdrF020_DOCTOR_MSTR = null;
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
