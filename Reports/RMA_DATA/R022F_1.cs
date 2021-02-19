//  #> PROGRAM-ID.     r022f.qzs 
//  Program Purpose Generate a report for the almost staled date claims with
//  `H`old  or `C`ard status
//  ((C)) Dyad Technologies
//  2007/mar/06 M.C     - original
//  2007/mar/08 yas.    - report balance-due, add total at clinic and final total
//  2008/Feb/20 yas.    - add column  MESS  pat-mess-code of f010                                     
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
    public class R022F_1 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R022F_1";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrF002_CLAIMS_MSTR = new Reader();
        private Reader rdrF010_PAT_MSTR = new Reader();
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
                //  Create Subfile.
                SubFile = true;
                SubFileName = "R022F";
                SubFileType = SubFileType.Keep;
                SubFileAT = "";
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

        private void Access_F002_CLAIMS_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("CLMHDR_PAT_KEY_TYPE, ");
            strSQL.Append("CLMHDR_PAT_KEY_DATA, ");
            strSQL.Append("KEY_CLM_TYPE, ");
            strSQL.Append("KEY_CLM_SERV_CODE, ");
            strSQL.Append("KEY_CLM_ADJ_NBR, ");
            strSQL.Append("CLMHDR_BATCH_NBR, ");
            strSQL.Append("CLMHDR_CLAIM_NBR, ");
            strSQL.Append("CLMHDR_ADJ_OMA_CD, ");
            strSQL.Append("CLMHDR_ADJ_OMA_SUFF, ");
            strSQL.Append("CLMHDR_ADJ_ADJ_NBR, ");
            strSQL.Append("CLMHDR_TOT_CLAIM_AR_OHIP, ");
            strSQL.Append("CLMHDR_MANUAL_AND_TAPE_PAYMENTS, ");
            strSQL.Append("CLMHDR_SERV_DATE, ");
            strSQL.Append("CLMHDR_BATCH_TYPE, ");
            strSQL.Append("CLMHDR_STATUS_OHIP, ");
            strSQL.Append("CLMHDR_MSG_NBR, ");
            strSQL.Append("CLMHDR_REPRINT_FLAG, ");
            strSQL.Append("CLMHDR_SUB_NBR, ");
            strSQL.Append("CLMHDR_AUTO_LOGOUT, ");
            strSQL.Append("CLMHDR_FEE_COMPLEX, ");
            strSQL.Append("FILLER, ");
            strSQL.Append("CLMHDR_AGENT_CD, ");
            strSQL.Append("CLMHDR_TAPE_SUBMIT_IND, ");
            strSQL.Append("KEY_CLM_BATCH_NBR, ");
            strSQL.Append("KEY_CLM_CLAIM_NBR ");
            strSQL.Append("FROM INDEXED.F002_CLAIMS_MSTR_HDR ");

            strSQL.Append(Choose());

            rdrF002_CLAIMS_MSTR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_F010_PAT_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("PAT_MESS_CODE, ");
            strSQL.Append("PAT_SURNAME_FIRST3, ");
            strSQL.Append("PAT_SURNAME_LAST22 ");
            strSQL.Append("FROM INDEXED.F010_PAT_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("PAT_I_KEY = ").Append(Common.StringToField(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_PAT_KEY_TYPE")));
            strSQL.Append(" AND PAT_CON_NBR = ").Append(QDesign.NConvert(QDesign.Substring(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_PAT_KEY_DATA"), 1, 2)));
            strSQL.Append(" AND PAT_I_NBR = ").Append(QDesign.NConvert(QDesign.Substring(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_PAT_KEY_DATA"), 3, 12)));
            strSQL.Append(" AND FILLER4 = ").Append(Common.StringToField(QDesign.Substring(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_PAT_KEY_DATA"), 15, 1)));

            rdrF010_PAT_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        #endregion

        #region " CHOOSE "

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(string.Empty);
            strChoose.Append(ReportDataFunctions.GetWhereCondition("KEY_CLM_TYPE", "B", true));
            strChoose.Append(ReportDataFunctions.GetWhereCondition("KEY_CLM_SERV_CODE", "00000"));
            strChoose.Append(ReportDataFunctions.GetWhereCondition("KEY_CLM_ADJ_NBR", "0"));
            return strChoose.ToString();
        }

        #endregion

        #region " SELECT IF "

        public override bool SelectIf()
        {
            bool blnSelected = false;
            if (QDesign.NULL(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_BATCH_TYPE")) == "C"
                && QDesign.NULL(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_STATUS_OHIP")) != "I2"
                && QDesign.NULL(BALANCE_DUE()) > QDesign.NULL(0d)
                && X_DAYS_SINCE_SERVICE() >= 150
                && (
                QDesign.NULL(F002_CLAIMS_MSTR_CLMHDR_DATE_CASH_TAPE_PAYMENT()) == QDesign.NULL(" ")
                || QDesign.NULL(F002_CLAIMS_MSTR_CLMHDR_DATE_CASH_TAPE_PAYMENT()) == "00000000")
                &&
                (
                QDesign.NULL(rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_AGENT_CD")) == QDesign.NULL(0d)
                || QDesign.NULL(rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_AGENT_CD")) == QDesign.NULL(2d)
                || QDesign.NULL(rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_AGENT_CD")) == QDesign.NULL(4d))
                &&
                (
                QDesign.NULL(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_TAPE_SUBMIT_IND")) == "H"
                || QDesign.NULL(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_TAPE_SUBMIT_IND")) == "C"
                || QDesign.NULL(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_TAPE_SUBMIT_IND")) == QDesign.NULL(" "))
                )
            {
                blnSelected = true;
            }
        
            return blnSelected;
        }

        #endregion

        #region " DEFINES "

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
    
        private decimal BALANCE_DUE()
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
    
        private decimal X_DAYS_SINCE_SERVICE()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_SERV_DATE")) != QDesign.NULL(0d)))
                {
                    decReturnValue = (QDesign.Days(QDesign.SysDate(ref m_cnnQUERY)) - QDesign.Days(QDesign.GetDateFromYYYYMMDDDecimal(rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_SERV_DATE"))));
                }
                else
                {
                    decReturnValue = 99999;
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return decReturnValue;
        }
    
        private string F002_CLAIMS_MSTR_CLMHDR_CLAIM_ID()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = rdrF002_CLAIMS_MSTR.GetString("CLMHDR_BATCH_NBR") + QDesign.ASCII(rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_CLAIM_NBR"), 2) + rdrF002_CLAIMS_MSTR.GetString("CLMHDR_ADJ_OMA_CD") + rdrF002_CLAIMS_MSTR.GetString("CLMHDR_ADJ_OMA_SUFF") + rdrF002_CLAIMS_MSTR.GetString("CLMHDR_ADJ_ADJ_NBR");
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

        private string F002_CLAIMS_MSTR_CLMHDR_DATE_CASH_TAPE_PAYMENT()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = QDesign.NULL(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_MSG_NBR")).PadRight(2, '0')
                    + QDesign.NULL(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_REPRINT_FLAG")).PadRight(1, '0')
                    + QDesign.NULL(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_SUB_NBR")).PadRight(1, '0')
                    + QDesign.NULL(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_AUTO_LOGOUT")).PadRight(1, '0')
                    + QDesign.NULL(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_FEE_COMPLEX")).PadRight(1, '0')
                    + QDesign.NULL(rdrF002_CLAIMS_MSTR.GetString("FILLER")).PadRight(2, '0');
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string F010_PAT_MSTR_PAT_SURNAME()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = rdrF010_PAT_MSTR.GetString("PAT_SURNAME_FIRST3").PadRight(3, ' ') + rdrF010_PAT_MSTR.GetString("PAT_SURNAME_LAST22");
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
                 AddControl(ReportSection.SUMMARY, "X_CLINIC", DataTypes.Character, 2);
                 AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR.KEY_CLM_BATCH_NBR", DataTypes.Character, 8);
                 AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR.KEY_CLM_CLAIM_NBR", DataTypes.Numeric, 2);
                 AddControl(ReportSection.SUMMARY, "CLMHDR_CLAIM_ID", DataTypes.Character, 16);
                 AddControl(ReportSection.SUMMARY, "CLMHDR_PAT_OHIP_ID_OR_CHART", DataTypes.Character, 16);
                 AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR.CLMHDR_AGENT_CD", DataTypes.Numeric, 1);
                 AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR.CLMHDR_TAPE_SUBMIT_IND", DataTypes.Character, 1);
                 AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR.CLMHDR_STATUS_OHIP", DataTypes.Character, 2);
                 AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR.CLMHDR_SERV_DATE", DataTypes.Numeric, 8);
                 AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR.CLMHDR_TOT_CLAIM_AR_OHIP", DataTypes.Numeric, 7);
                 AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR.CLMHDR_MANUAL_AND_TAPE_PAYMENTS", DataTypes.Numeric, 7);
                 AddControl(ReportSection.SUMMARY, "BALANCE_DUE", DataTypes.Numeric, 7);
                 AddControl(ReportSection.SUMMARY, "X_DAYS_SINCE_SERVICE", DataTypes.Numeric, 6);
                 AddControl(ReportSection.SUMMARY, "INDEXED.F010_PAT_MSTR.PAT_MESS_CODE", DataTypes.Character, 3);
                 AddControl(ReportSection.SUMMARY, "PAT_SURNAME", DataTypes.Character, 18);
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
                case "X_CLINIC":
                    return Common.StringToField(X_CLINIC(), intSize);

                case "INDEXED.F002_CLAIMS_MSTR.KEY_CLM_BATCH_NBR":
                    return Common.StringToField(rdrF002_CLAIMS_MSTR.GetString("KEY_CLM_BATCH_NBR"));

                case "INDEXED.F002_CLAIMS_MSTR.KEY_CLM_CLAIM_NBR":
                    return rdrF002_CLAIMS_MSTR.GetNumber("KEY_CLM_CLAIM_NBR").ToString();

                case "CLMHDR_CLAIM_ID":
                    return Common.StringToField(F002_CLAIMS_MSTR_CLMHDR_CLAIM_ID(), intSize);

                case "CLMHDR_PAT_OHIP_ID_OR_CHART":
                    return Common.StringToField(F002_CLAIMS_MSTR_CLMHDR_PAT_OHIP_ID_OR_CHART(), intSize);

                case "INDEXED.F002_CLAIMS_MSTR.CLMHDR_AGENT_CD":
                    return rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_AGENT_CD").ToString();

                case "INDEXED.F002_CLAIMS_MSTR.CLMHDR_TAPE_SUBMIT_IND":
                    return Common.StringToField(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_TAPE_SUBMIT_IND"));

                case "INDEXED.F002_CLAIMS_MSTR.CLMHDR_STATUS_OHIP":
                    return Common.StringToField(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_STATUS_OHIP"));

                case "INDEXED.F002_CLAIMS_MSTR.CLMHDR_SERV_DATE":
                    return rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_SERV_DATE").ToString();

                case "INDEXED.F002_CLAIMS_MSTR.CLMHDR_TOT_CLAIM_AR_OHIP":
                    return rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_TOT_CLAIM_AR_OHIP").ToString();

                case "INDEXED.F002_CLAIMS_MSTR.CLMHDR_MANUAL_AND_TAPE_PAYMENTS":
                    return rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_MANUAL_AND_TAPE_PAYMENTS").ToString();

                case "BALANCE_DUE":
                    return BALANCE_DUE().ToString();

                case "X_DAYS_SINCE_SERVICE":
                    return X_DAYS_SINCE_SERVICE().ToString();

                case "INDEXED.F010_PAT_MSTR.PAT_MESS_CODE":
                    return Common.StringToField(rdrF010_PAT_MSTR.GetString("PAT_MESS_CODE"));

                case "PAT_SURNAME":
                    return Common.StringToField(F010_PAT_MSTR_PAT_SURNAME(), intSize);

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
                    Link_F010_PAT_MSTR();
                    while (rdrF010_PAT_MSTR.Read())
                    {
                        WriteData();
                    }
                
                    rdrF010_PAT_MSTR.Close();
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
        
            if (!(rdrF010_PAT_MSTR == null))
            {
                rdrF010_PAT_MSTR.Close();
                rdrF010_PAT_MSTR = null;
            }
        }

        #endregion

        #endregion
    }
}
