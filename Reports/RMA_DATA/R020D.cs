//  #> PROGRAM-ID.     R020D.QZS
//  ((C)) Dyad Technologies
//  PROGRAM PURPOSE : PRINT DETAIL CLAIMS SUBMITTED TO OHIP TAPE
//  MODIFICATION HISTORY
//  DATE   WHO          DESCRIPTION
//  91/FEB/19 D.B.         - ORIGINAL (SMS 138)
//  *** NOTE *** DIFFERENCE BETWEEN HEADER TOT AND DETAIL
//  TOTAL IS NOT CALCULATED AND PRINTED
//  91/APR/03 D.B.          - USE USE-FILES BECAUSE OF R022D.QZS
//  98/Aug/19 B.E.       - changed page length from 63 to 66 lines
//  03/dec/12 A.A.       - alpah doctor nbr
//  set page length 63 width 132
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
    public class R020D : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R020D";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrU020A1 = new Reader();
        private Reader rdrF002_CLAIMS_MSTR_DTL = new Reader();
        private Reader rdrICONST_MSTR_REC = new Reader();

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
                Sort = "BATCTRL_BATCH_NBR ASC, CLMHDR_CLAIM_ID ASC";
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

        private void Access_U020A1()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            try
            {
                strSQL.Append("SELECT ");
                strSQL.Append("CLMHDR_BATCH_NBR, ");
                strSQL.Append("CLMHDR_CLAIM_NBR, ");
                strSQL.Append("PAT_SURNAME_FIRST3, ");
                strSQL.Append("PAT_SURNAME_LAST22, ");
                strSQL.Append("PAT_GIVEN_NAME_FIRST1, ");
                strSQL.Append("FILLER3, ");
                strSQL.Append("PAT_HEALTH_NBR, ");
                strSQL.Append("BATCTRL_BATCH_TYPE, ");
                strSQL.Append("ICONST_CLINIC_NBR_1_2, ");
                strSQL.Append("ICONST_CLINIC_CYCLE_NBR, ");
                strSQL.Append("BATCTRL_BATCH_NBR, ");
                strSQL.Append("ICONST_DATE_PERIOD_END, ");
                strSQL.Append("CLMHDR_DOC_DEPT, ");
                strSQL.Append("DOC_NBR, ");
                strSQL.Append("CLMHDR_REFER_DOC_NBR, ");
                strSQL.Append("W_CLMHDR_HOSP, ");
                strSQL.Append("CLMHDR_LOC, ");
                strSQL.Append("CLMHDR_AGENT_CD, ");
                strSQL.Append("CLMHDR_I_O_PAT_IND, ");
                strSQL.Append("CLMHDR_DATE_ADMIT, ");
                strSQL.Append("CLMHDR_TOT_CLAIM_AR_OMA, ");
                strSQL.Append("CLMHDR_TOT_CLAIM_AR_OHIP, ");
                strSQL.Append("CLMHDR_STATUS_OHIP, ");
                strSQL.Append("CLMHDR_TOT_CLAIM_AR_OHIP ");
                strSQL.Append("FROM TEMPORARYDATA.U020A1 ");

                strSQL.Append(Choose());
                strSQL.Append(SelectIf_U020A1(true));

                rdrU020A1.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
                strSQL = null;
            }

            catch (Exception ex)
            {
                ReportFunctions.WriteToLogFile("Error: " + ex.Message);
            }
        }
        private void Link_F002_CLAIMS_MSTR_DTL()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);
            strSQL.Append("SELECT ");
            strSQL.Append("CLMDTL_CONSEC_DATES_R, ");
            strSQL.Append("CLMDTL_DIAG_CD, ");
            strSQL.Append("CLMDTL_OMA_CD, ");
            strSQL.Append("CLMDTL_OMA_SUFF, ");
            strSQL.Append("CLMDTL_ADJ_NBR, ");
            strSQL.Append("CLMDTL_NBR_SERV, ");
            strSQL.Append("CLMDTL_FEE_OMA, ");
            strSQL.Append("CLMDTL_SV_YY, ");
            strSQL.Append("CLMDTL_SV_MM, ");
            strSQL.Append("CLMDTL_SV_DD, ");
            strSQL.Append("CLMDTL_NBR_SERV, ");
            strSQL.Append("CLMDTL_FEE_OHIP ");
            strSQL.Append("FROM INDEXED.F002_CLAIMS_MSTR_DTL ");
            strSQL.Append("WHERE ");
            strSQL.Append("KEY_CLM_TYPE = ").Append(Common.StringToField("B"));
            strSQL.Append(" AND KEY_CLM_BATCH_NBR = ").Append(Common.StringToField(rdrU020A1.GetString("BATCTRL_BATCH_NBR")));
            strSQL.Append(" AND KEY_CLM_CLAIM_NBR = ").Append(rdrU020A1.GetNumber("CLMHDR_CLAIM_NBR"));

            strSQL.Append(SelectIf_F002_CLAIMS_MSTR_DTL(false));

            rdrF002_CLAIMS_MSTR_DTL.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_ICONST_MSTR_REC()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("ICONST_CLINIC_NAME ");
            strSQL.Append("FROM INDEXED.ICONST_MSTR_REC ");
            strSQL.Append("WHERE ");
            strSQL.Append("ICONST_CLINIC_NBR_1_2 = ").Append(rdrU020A1.GetNumber("ICONST_CLINIC_NBR_1_2"));

            rdrICONST_MSTR_REC.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        #endregion

        #region " CHOOSE "

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(string.Empty);

            return strChoose.ToString();
        }
    
        private string SelectIf_U020A1(bool blnAddWhere)
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);
            if (blnAddWhere)
            {
                strSQL.Append(" WHERE ");
            }
            else
            {
                strSQL.Append(" AND ");
            }
        
            strSQL.Append(" (BATCTRL_BATCH_TYPE = 'C' ");
            strSQL.Append("AND MOH_FLAG = 'Y' ");
            strSQL.Append("AND PAT_MESS_CODE = ' ')");
            return strSQL.ToString();
        }

        #endregion

        #region " SELECT IF "

        private string SelectIf_F002_CLAIMS_MSTR_DTL(bool blnAddWhere)
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);
            if (blnAddWhere)
            {
                strSQL.Append(" WHERE ");
            }
            else
            {
                strSQL.Append(" AND ");
            }
        
            strSQL.Append(" (CLMDTL_OMA_CD <> '0000' ");
            strSQL.Append("AND CLMDTL_OMA_CD <> 'ZZZZ')");
            return strSQL.ToString();
        }

        #endregion

        #region " DEFINES "

        private string W_PAT_SURNAME()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = QDesign.ASCII(rdrU020A1.GetString("PAT_SURNAME_FIRST3"), 3) + QDesign.Substring(rdrU020A1.GetString("PAT_SURNAME_LAST22"), 1, 3);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return strReturnValue;
        }
    
        private string W_PAT_GIVEN_NAME()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = rdrU020A1.GetString("PAT_GIVEN_NAME_FIRST1") + QDesign.Substring(rdrU020A1.GetString("FILLER3"), 1, 2);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return strReturnValue;
        }
    
        private string W_CLAIM_NBR()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_CLAIM_NBR");
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return strReturnValue;
        }
    
        private string W_PAT_CHART_NBR()
        {
            string strReturnValue = string.Empty;
            try
            {
                if ((rdrU020A1.GetNumber("PAT_HEALTH_NBR") != 0))
                {
                    strReturnValue = QDesign.ASCII(rdrU020A1.GetNumber("PAT_HEALTH_NBR"), 10);
                }
                else
                {
                    strReturnValue = rdrU020A1.GetString("W_PAT_OHIP_MMYY");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return strReturnValue;
        }
    
        private string W_BATCH_TYPE()
        {
            string strReturnValue = string.Empty;
            try
            {
                if ((rdrU020A1.GetString("BATCTRL_BATCH_TYPE") == "C"))
                {
                    strReturnValue = "CLAIMS";
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return strReturnValue;
        }
    
        private decimal W_COUNT_HEADER()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = 1;
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return decReturnValue;
        }
    
        private string W_CLMDTL_NBR_1()
        {
            string strReturnValue = string.Empty;
            try
            {
                if (((QDesign.Substring(rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_CONSEC_DATES_R"), 1, 1) != " ") 
                            && (QDesign.Substring(rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_CONSEC_DATES_R"), 1, 1) != "0")))
                {
                    strReturnValue = QDesign.Substring(rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_CONSEC_DATES_R"), 1, 1);
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return strReturnValue;
        }
    
        private string W_CLMDTL_NBR_2()
        {
            string strReturnValue = string.Empty;
            try
            {
                if (((QDesign.Substring(rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_CONSEC_DATES_R"), 4, 1) != " ") 
                            && (QDesign.Substring(rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_CONSEC_DATES_R"), 4, 1) != "0")))
                {
                    strReturnValue = QDesign.Substring(rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_CONSEC_DATES_R"), 4, 1);
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return strReturnValue;
        }
    
        private string W_CLMDTL_NBR_3()
        {
            string strReturnValue = string.Empty;
            try
            {
                if (((QDesign.Substring(rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_CONSEC_DATES_R"), 7, 1) != " ") 
                            && (QDesign.Substring(rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_CONSEC_DATES_R"), 7, 1) != "0")))
                {
                    strReturnValue = QDesign.Substring(rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_CONSEC_DATES_R"), 7, 1);
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return strReturnValue;
        }
    
        private string W_CLMDTL_DATE_1()
        {
            string strReturnValue = string.Empty;
            try
            {
                if (((QDesign.Substring(rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_CONSEC_DATES_R"), 2, 2) != "  ") 
                            && ((QDesign.Substring(rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_CONSEC_DATES_R"), 2, 1) != "0") 
                            || (QDesign.Substring(rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_CONSEC_DATES_R"), 3, 1).CompareTo("0") > 0))))
                {
                    strReturnValue = QDesign.Substring(rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_CONSEC_DATES_R"), 2, 2);
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return strReturnValue;
        }
    
        private string W_CLMDTL_DATE_2()
        {
            string strReturnValue = string.Empty;
            try
            {
                if (((QDesign.Substring(rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_CONSEC_DATES_R"), 5, 2) != "  ") 
                            && ((QDesign.Substring(rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_CONSEC_DATES_R"), 5, 1) != "0") 
                            || (QDesign.Substring(rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_CONSEC_DATES_R"), 6, 1).CompareTo("0") > 0))))
                {
                    strReturnValue = QDesign.Substring(rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_CONSEC_DATES_R"), 5, 2);
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return strReturnValue;
        }
    
        private string W_CLMDTL_DATE_3()
        {
            string strReturnValue = string.Empty;
            try
            {
                if (((QDesign.Substring(rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_CONSEC_DATES_R"), 8, 2) != "  ") 
                            && ((QDesign.Substring(rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_CONSEC_DATES_R"), 8, 1) != "0") 
                            || (QDesign.Substring(rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_CONSEC_DATES_R"), 9, 1).CompareTo("0") > 0))))
                {
                    strReturnValue = QDesign.Substring(rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_CONSEC_DATES_R"), 8, 2);
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return strReturnValue;
        }

        private string F002_CLAIMS_MSTR_DTL_CLMDTL_SV_DATE()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = QDesign.ASCII(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_SV_YY"), 4) + QDesign.ASCII(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_SV_MM"), 2) + QDesign.ASCII(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_SV_DD"), 2);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string CLMHDR_CLAIM_ID()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = rdrU020A1.GetString("CLMHDR_BATCH_NBR") + QDesign.ASCII(rdrU020A1.GetNumber("CLMHDR_CLAIM_NBR"), 2);
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
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.U020A1.ICONST_CLINIC_NBR_1_2", DataTypes.Numeric, 2);
                AddControl(ReportSection.PAGE_HEADING, "W_BATCH_TYPE", DataTypes.Character, 9);
                AddControl(ReportSection.PAGE_HEADING, "INDEXED.ICONST_MSTR_REC.ICONST_CLINIC_NAME", DataTypes.Character, 20);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.U020A1.ICONST_CLINIC_CYCLE_NBR", DataTypes.Numeric, 2);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.U020A1.BATCTRL_BATCH_NBR", DataTypes.Character, 8);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.U020A1.ICONST_DATE_PERIOD_END", DataTypes.Numeric, 8);
                AddControl(ReportSection.HEADING_AT, "CLMHDR_CLAIM_ID", DataTypes.Character, 10);
                AddControl(ReportSection.HEADING_AT, "W_PAT_SURNAME", DataTypes.Character, 6);
                AddControl(ReportSection.HEADING_AT, "W_PAT_GIVEN_NAME", DataTypes.Character, 3);
                AddControl(ReportSection.HEADING_AT, "W_PAT_CHART_NBR", DataTypes.Character, 15);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U020A1.CLMHDR_DOC_DEPT", DataTypes.Numeric, 2);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U020A1.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.HEADING_AT, "INDEXED.F002_CLAIMS_MSTR_DTL.CLMDTL_DIAG_CD", DataTypes.Numeric, 3);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U020A1.CLMHDR_REFER_DOC_NBR", DataTypes.Numeric, 6);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U020A1.W_CLMHDR_HOSP", DataTypes.Character, 4);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U020A1.CLMHDR_LOC", DataTypes.Character, 4);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U020A1.CLMHDR_AGENT_CD", DataTypes.Numeric, 1);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U020A1.CLMHDR_I_O_PAT_IND", DataTypes.Character, 1);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U020A1.CLMHDR_DATE_ADMIT", DataTypes.Character, 8);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U020A1.CLMHDR_TOT_CLAIM_AR_OMA", DataTypes.Numeric, 7);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U020A1.CLMHDR_TOT_CLAIM_AR_OHIP", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F002_CLAIMS_MSTR_DTL.CLMDTL_NBR_SERV", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "W_CLMDTL_NBR_1", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "W_CLMDTL_DATE_1", DataTypes.Character, 2);
                AddControl(ReportSection.REPORT, "W_CLMDTL_NBR_2", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "W_CLMDTL_DATE_2", DataTypes.Character, 2);
                AddControl(ReportSection.REPORT, "W_CLMDTL_NBR_3", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "W_CLMDTL_DATE_3", DataTypes.Character, 2);
                AddControl(ReportSection.REPORT, "INDEXED.F002_CLAIMS_MSTR_DTL.CLMDTL_OMA_CD", DataTypes.Character, 4);
                AddControl(ReportSection.REPORT, "INDEXED.F002_CLAIMS_MSTR_DTL.CLMDTL_OMA_SUFF", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U020A1.CLMHDR_STATUS_OHIP", DataTypes.Character, 2);
                AddControl(ReportSection.REPORT, "INDEXED.F002_CLAIMS_MSTR_DTL.CLMDTL_NBR_SERV", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "INDEXED.F002_CLAIMS_MSTR_DTL.CLMDTL_FEE_OMA", DataTypes.Numeric, 7);
                AddControl(ReportSection.REPORT, "INDEXED.F002_CLAIMS_MSTR_DTL.CLMDTL_FEE_OHIP", DataTypes.Numeric, 7);
                AddControl(ReportSection.REPORT, "F002_CLAIMS_MSTR_DTL_CLMDTL_SV_DATE", DataTypes.Character, 8);
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
        // # Do not delete, modify or move it.  Updated: 2018-07-20 11:56:54 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "TEMPORARYDATA.U020A1.ICONST_CLINIC_NBR_1_2":
                    return rdrU020A1.GetNumber("ICONST_CLINIC_NBR_1_2").ToString();
                case "W_BATCH_TYPE":
                    return Common.StringToField(W_BATCH_TYPE(), intSize);
                case "INDEXED.ICONST_MSTR_REC.ICONST_CLINIC_NAME":
                    return Common.StringToField(rdrICONST_MSTR_REC.GetString("ICONST_CLINIC_NAME"));
                case "TEMPORARYDATA.U020A1.ICONST_CLINIC_CYCLE_NBR":
                    return rdrU020A1.GetNumber("ICONST_CLINIC_CYCLE_NBR").ToString();
                case "TEMPORARYDATA.U020A1.BATCTRL_BATCH_NBR":
                    return Common.StringToField(rdrU020A1.GetString("BATCTRL_BATCH_NBR"));
                case "TEMPORARYDATA.U020A1.ICONST_DATE_PERIOD_END":
                    return rdrU020A1.GetNumber("ICONST_DATE_PERIOD_END").ToString();
                case "CLMHDR_CLAIM_ID":
                    return Common.StringToField(CLMHDR_CLAIM_ID());
                case "W_PAT_SURNAME":
                    return Common.StringToField(W_PAT_SURNAME(), intSize);
                case "W_PAT_GIVEN_NAME":
                    return Common.StringToField(W_PAT_GIVEN_NAME(), intSize);
                case "W_PAT_CHART_NBR":
                    return Common.StringToField(W_PAT_CHART_NBR(), intSize);
                case "TEMPORARYDATA.U020A1.CLMHDR_DOC_DEPT":
                    return rdrU020A1.GetNumber("CLMHDR_DOC_DEPT").ToString();
                case "TEMPORARYDATA.U020A1.DOC_NBR":
                    return Common.StringToField(rdrU020A1.GetString("DOC_NBR"));
                case "INDEXED.F002_CLAIMS_MSTR_DTL.CLMDTL_DIAG_CD":
                    return rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_DIAG_CD").ToString();
                case "TEMPORARYDATA.U020A1.CLMHDR_REFER_DOC_NBR":
                    return rdrU020A1.GetNumber("CLMHDR_REFER_DOC_NBR").ToString();
                case "TEMPORARYDATA.U020A1.W_CLMHDR_HOSP":
                    return Common.StringToField(rdrU020A1.GetString("W_CLMHDR_HOSP"));
                case "TEMPORARYDATA.U020A1.CLMHDR_LOC":
                    return Common.StringToField(rdrU020A1.GetString("CLMHDR_LOC"));
                case "TEMPORARYDATA.U020A1.CLMHDR_AGENT_CD":
                    return rdrU020A1.GetNumber("CLMHDR_AGENT_CD").ToString();
                case "TEMPORARYDATA.U020A1.CLMHDR_I_O_PAT_IND":
                    return Common.StringToField(rdrU020A1.GetString("CLMHDR_I_O_PAT_IND"));
                case "TEMPORARYDATA.U020A1.CLMHDR_DATE_ADMIT":
                    return Common.StringToField(rdrU020A1.GetString("CLMHDR_DATE_ADMIT"));
                case "TEMPORARYDATA.U020A1.CLMHDR_TOT_CLAIM_AR_OMA":
                    return rdrU020A1.GetNumber("CLMHDR_TOT_CLAIM_AR_OMA").ToString();
                case "TEMPORARYDATA.U020A1.CLMHDR_TOT_CLAIM_AR_OHIP":
                    return rdrU020A1.GetNumber("CLMHDR_TOT_CLAIM_AR_OHIP").ToString();
                case "W_CLMDTL_NBR_1":
                    return Common.StringToField(W_CLMDTL_NBR_1(), intSize);
                case "W_CLMDTL_DATE_1":
                    return Common.StringToField(W_CLMDTL_DATE_1(), intSize);
                case "W_CLMDTL_NBR_2":
                    return Common.StringToField(W_CLMDTL_NBR_2(), intSize);
                case "W_CLMDTL_DATE_2":
                    return Common.StringToField(W_CLMDTL_DATE_2(), intSize);
                case "W_CLMDTL_NBR_3":
                    return Common.StringToField(W_CLMDTL_NBR_3(), intSize);
                case "W_CLMDTL_DATE_3":
                    return Common.StringToField(W_CLMDTL_DATE_3(), intSize);
                case "INDEXED.F002_CLAIMS_MSTR_DTL.CLMDTL_OMA_CD":
                    return Common.StringToField(rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_OMA_CD"));
                case "INDEXED.F002_CLAIMS_MSTR_DTL.CLMDTL_OMA_SUFF":
                    return Common.StringToField(rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_OMA_SUFF"));
                case "TEMPORARYDATA.U020A1.CLMHDR_STATUS_OHIP":
                    return Common.StringToField(rdrU020A1.GetString("CLMHDR_STATUS_OHIP"));
                case "INDEXED.F002_CLAIMS_MSTR_DTL.CLMDTL_NBR_SERV":
                    return rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_NBR_SERV").ToString();
                case "INDEXED.F002_CLAIMS_MSTR_DTL.CLMDTL_FEE_OMA":
                    return rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_FEE_OMA").ToString();
                case "INDEXED.F002_CLAIMS_MSTR_DTL.CLMDTL_FEE_OHIP":
                    return rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_FEE_OHIP").ToString();
                case "F002_CLAIMS_MSTR_DTL_CLMDTL_SV_DATE":
                    return Common.StringToField(F002_CLAIMS_MSTR_DTL_CLMDTL_SV_DATE());
                default:
                    return string.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                Access_U020A1();
                while (rdrU020A1.Read())
                {
                    Link_F002_CLAIMS_MSTR_DTL();
                    while (rdrF002_CLAIMS_MSTR_DTL.Read())
                    {
                        Link_ICONST_MSTR_REC();
                        while (rdrICONST_MSTR_REC.Read())
                        {
                            WriteData();
                        }
                        rdrICONST_MSTR_REC.Close();
                    }
                    rdrF002_CLAIMS_MSTR_DTL.Close();
                }
                rdrU020A1.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrU020A1 == null))
            {
                rdrU020A1.Close();
                rdrU020A1 = null;
            }
        
            if (!(rdrF002_CLAIMS_MSTR_DTL == null))
            {
                rdrF002_CLAIMS_MSTR_DTL.Close();
                rdrF002_CLAIMS_MSTR_DTL = null;
            }
        
            if (!(rdrICONST_MSTR_REC == null))
            {
                rdrICONST_MSTR_REC.Close();
                rdrICONST_MSTR_REC = null;
            }
        }

        #endregion

        #endregion
    }
}
