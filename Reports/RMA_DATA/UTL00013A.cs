//  DOC: UTL00013.QZS
//  DOC: LIST OF CLAIMS WITH  S  STATUS AND NO PAYMENT DATE
//  DOC: PROMPT FOR CLAIM SUBMIT DATE
//  DOC: RUN FOR: Melissa
//  PURPOSE: BE ABLE TO ZERO IN ON CLAIMS WITH NO ACTION, RATHER THAN
//  HAVING TO REVIEW THE ENTIRE ACCOUNTS RECEIVABLE. AVOID
//  STALE DATES AND MAXIMIZE ON THE COLLECTION OF PAYMENTS.
//  MODIFICATION HISTORY:
//  YY/MMM/DD     BY WHOM        WHY
//  92/MAY/26     YASEMIN        ORIGINAL
//  99/dec/6      YASEMIN        add select if x-clinic = 22
//  and x-balance <> 0
//  03/dec/17     A.A.  alpha doctor nbr
//  11/Apr/07     yas   add clinic 32, 33. 42 and 43
//  13/aug/19     yas   add clinic 23                 
//  14/May/23   yas  mod clinics  22-25, 31-37 41-46 84 and 96
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
    public class UTL00013A : BaseRDLClass
    {
        protected const string REPORT_NAME = "UTL00013A";
        protected const bool REPORT_HAS_PARAMETERS = true;
        private Reader rdrF002_CLAIMS_MSTR = new Reader();
        private Reader rdrUTL00013A = new Reader();
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
                SubFileName = "UTL00013A";
                SubFileType = SubFileType.Keep;
                SubFileAT = "";
                Sort = "CLM_ID ASC";
                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return ReportData;
        }
        private void Access_F002_CLAIMS_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("KEY_CLM_TYPE, ");
            strSQL.Append("CLMHDR_REFERENCE, ");
            strSQL.Append("CLMHDR_BATCH_NBR, ");
            strSQL.Append("CLMHDR_CLAIM_NBR, ");
            strSQL.Append("CLMHDR_ADJ_OMA_CD, ");
            strSQL.Append("CLMHDR_ADJ_OMA_SUFF, ");
            strSQL.Append("CLMHDR_ADJ_ADJ_NBR, ");
            strSQL.Append("CLMHDR_TOT_CLAIM_AR_OHIP, ");
            strSQL.Append("CLMHDR_MANUAL_AND_TAPE_PAYMENTS, ");
            strSQL.Append("CLMHDR_BATCH_TYPE, ");
            strSQL.Append("CLMHDR_AGENT_CD, ");
            strSQL.Append("CLMHDR_ADJ_OMA_CD, ");
            strSQL.Append("CLMHDR_SUBMIT_DATE, ");
            strSQL.Append("CLMHDR_MSG_NBR, ");
            strSQL.Append("CLMHDR_REPRINT_FLAG, ");
            strSQL.Append("CLMHDR_SUB_NBR, ");
            strSQL.Append("CLMHDR_AUTO_LOGOUT, ");
            strSQL.Append("CLMHDR_FEE_COMPLEX, ");
            strSQL.Append("FILLER, ");
            strSQL.Append("CLMHDR_TAPE_SUBMIT_IND, ");
            strSQL.Append("KEY_CLM_BATCH_NBR, ");
            strSQL.Append("KEY_CLM_CLAIM_NBR ");
            strSQL.Append("FROM INDEXED.F002_CLAIMS_MSTR_HDR ");

            strSQL.Append(Choose());

            rdrF002_CLAIMS_MSTR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
    
        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(string.Empty);
            strChoose.Append(ReportDataFunctions.GetWhereCondition("KEY_CLM_TYPE", "B", true));
            return strChoose.ToString();
        }
    
        public override bool SelectIf()
        {
            bool blnSelected = false;
            if ((((QDesign.NULL(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_BATCH_TYPE")) == "C") 
                        && (((QDesign.NULL(rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_AGENT_CD")) == QDesign.NULL(0d)) 
                        || (QDesign.NULL(rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_AGENT_CD")) == QDesign.NULL(2d))) 
                        && ((QDesign.NULL(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_ADJ_OMA_CD")) == "0000") 
                        && (((QDesign.NULL(X_CLINIC()) == "22") 
                        || ((QDesign.NULL(X_CLINIC()) == "23") 
                        || ((QDesign.NULL(X_CLINIC()) == "24") 
                        || ((QDesign.NULL(X_CLINIC()) == "25") 
                        || ((QDesign.NULL(X_CLINIC()) == "26") 
                        || ((QDesign.NULL(X_CLINIC()) == "30") 
                        || ((QDesign.NULL(X_CLINIC()) == "31") 
                        || ((QDesign.NULL(X_CLINIC()) == "32") 
                        || ((QDesign.NULL(X_CLINIC()) == "33") 
                        || ((QDesign.NULL(X_CLINIC()) == "34") 
                        || ((QDesign.NULL(X_CLINIC()) == "35") 
                        || ((QDesign.NULL(X_CLINIC()) == "36") 
                        || ((QDesign.NULL(X_CLINIC()) == "37") 
                        || ((QDesign.NULL(X_CLINIC()) == "41") 
                        || ((QDesign.NULL(X_CLINIC()) == "42") 
                        || ((QDesign.NULL(X_CLINIC()) == "43") 
                        || ((QDesign.NULL(X_CLINIC()) == "44") 
                        || ((QDesign.NULL(X_CLINIC()) == "45") 
                        || ((QDesign.NULL(X_CLINIC()) == "46") 
                        || ((QDesign.NULL(X_CLINIC()) == "84") 
                        || (QDesign.NULL(X_CLINIC()) == "96"))))))))))))))))))))) 
                        && ((rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_SUBMIT_DATE") >= X_DATE_FROM()) 
                        && (rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_SUBMIT_DATE") <= X_DATE_TO())))))) 
                        && (((QDesign.NULL(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_MSG_NBR")) + QDesign.NULL(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_REPRINT_FLAG")) + QDesign.NULL(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_SUB_NBR")) + QDesign.NULL(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_AUTO_LOGOUT")) + QDesign.NULL(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_FEE_COMPLEX")) + QDesign.NULL(rdrF002_CLAIMS_MSTR.GetString("FILLER")) == QDesign.NULL(" ")) 
                        || ((QDesign.NULL(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_MSG_NBR")) + QDesign.NULL(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_REPRINT_FLAG")) + QDesign.NULL(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_SUB_NBR")) + QDesign.NULL(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_AUTO_LOGOUT")) + QDesign.NULL(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_FEE_COMPLEX")) + QDesign.NULL(rdrF002_CLAIMS_MSTR.GetString("FILLER")) != QDesign.NULL(" ")) 
                        && (QDesign.NULL(rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_MANUAL_AND_TAPE_PAYMENTS")) == QDesign.NULL(0d)))) 
                        && ((QDesign.NULL(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_TAPE_SUBMIT_IND")) == "S") 
                        || (QDesign.NULL(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_TAPE_SUBMIT_IND")) == "Y")))))
            {
                blnSelected = true;
            }
        
            return blnSelected;
        }
    
        private decimal X_DATE_FROM()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = QDesign.NConvert(ReportFunctions.astrScreenParameters[0].ToString());
                //  Prompt String: "ENTER DATE FROM (YYYYMMDD) "
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return decReturnValue;
        }
    
        private decimal X_DATE_TO()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = QDesign.NConvert(ReportFunctions.astrScreenParameters[1].ToString());
                //  Prompt String: "ENTER DATE TO   (YYYYMMDD) "
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return decReturnValue;
        }
    
        private string CLM_REF()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = QDesign.Substring(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_REFERENCE"), 1, 3);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return strReturnValue;
        }
    
        private string CLM_ID()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = rdrF002_CLAIMS_MSTR.GetString("CLMHDR_BATCH_NBR") + QDesign.ASCII(rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_CLAIM_NBR"), 2);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return strReturnValue;
        }
    
        private string X_CLINIC()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = QDesign.Substring(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_BATCH_NBR"), 1, 2);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return strReturnValue;
        }
    
        private decimal X_BALANCE()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = (rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_TOT_CLAIM_AR_OHIP") + rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_MANUAL_AND_TAPE_PAYMENTS"));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return decReturnValue;
        }
        public override void DeclareReportControls()
        {
            try
            {
                 AddControl(ReportSection.SUMMARY, "CLM_REF", DataTypes.Character, 3);
                 AddControl(ReportSection.SUMMARY, "CLM_ID", DataTypes.Character, 10);
                 AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR.KEY_CLM_BATCH_NBR", DataTypes.Character, 8);
                 AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR.KEY_CLM_CLAIM_NBR", DataTypes.Numeric, 2);
                 AddControl(ReportSection.SUMMARY, "X_BALANCE", DataTypes.Numeric, 7);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
    
        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-05-16 12:45:40 PM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "CLM_REF":
                    return Common.StringToField(CLM_REF(), intSize);

                case "CLM_ID":
                    return Common.StringToField(CLM_ID(), intSize);

                case "INDEXED.F002_CLAIMS_MSTR.KEY_CLM_BATCH_NBR":
                    return Common.StringToField(rdrF002_CLAIMS_MSTR.GetString("KEY_CLM_BATCH_NBR"));

                case "INDEXED.F002_CLAIMS_MSTR.KEY_CLM_CLAIM_NBR":
                    return rdrF002_CLAIMS_MSTR.GetNumber("KEY_CLM_CLAIM_NBR").ToString();

                case "X_BALANCE":
                    return X_BALANCE().ToString();

                default:
                    return string.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                Access_F002_CLAIMS_MSTR();
                while (rdrF002_CLAIMS_MSTR.Read())
                {
                    WriteData();
                }
            
                rdrF002_CLAIMS_MSTR.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrF002_CLAIMS_MSTR == null))
            {
                rdrF002_CLAIMS_MSTR.Close();
                rdrF002_CLAIMS_MSTR = null;
            }
        }
    }
}
