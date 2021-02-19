// #> PROGRAM-ID.     r021b.qzs
//
// 	((C)) Dyad Technologies
//
//     PROGRAM PURPOSE : PRINT THE OHIP EDT ERROR REPORT   
//
//     MODIFICATION HISTORY
//         DATE   WHO          DESCRIPTION
//      03/MAR/26 M.C.         - ORIGINAL 
//      03/APR/22 M.C.         - include referring doctor, hospital nbr and admit date 
//                               in the report as Thelka needs them
//      03/JUN/02 M.C.         - change to print clinic and group number properly
//      03/JUN/05 M.C.         - Thekla requested to include doc ohip nbr, specialty code
//                               doc full name and pay program, make it letter size  
//      03/JUL/29 M.C.         - Yasemin requests to suppress printing for claims have
//                               been fully paid, add f002 to access statement
//      03/nov/17 b.e. 	- rename from r031b to r021b
//                      - add original edt error file to report statement
//                        add sort on error
//  2003/nov/21 b.e.	- select now based upon all 5 hdr/dtl error codes not
//                        just the 1st one
//                      - access to f093 to pickup error code's category - used
//                        by subsequent 'nogo's of this progam with different
//                        'and select's.
//  2003/12/03 M.C.     - include the temporary tmp-serv-err-claim in the access
//                        statement
//  2003/12/10 b.e.     - doctor alpha number conversion
//  2004/03/02 M.C.     - sort on group nbr on process date before account nbr
//                      - skip page at process date
//  2004/03/02 M.C.     - provide final total number of rejected claims  
//  2004/sep/28 b.e.    - replace truncate file with with rat-rmb-file-name 
//                        to show all 12 chars of the name
//  2006/nov/21 M.C.	- determine the stale date of the claims
//  2010/Apr/21 MC1     - change rep length to 60 instead of 63
//  2011/May/17 MC2     - print rat-rmb-file-name once at the header
//  2013/Jan/08 MC3     - modify selection criteria to include CME codes
//                      - add f010 to access statement

using Core.DataAccess.SqlServer;
using Core.DataAccess.TextFile;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.ReportFramework;
using System;
using System.Data;
using System.Text;
namespace RMA_DATA
{
    public class R021B : BaseRDLClass
    {
        protected const string REPORT_NAME = "R021B";
        protected const bool REPORT_HAS_PARAMETERS = true;

        private Reader rdrU021A_EDT_1HT_FILE = new Reader();
        private Reader rdrTMP_SERV_ERR_CLAIM = new Reader();
        private Reader rdrF020_DOCTOR_MSTR = new Reader();
        private Reader rdrICONST_MSTR_REC = new Reader();
        private Reader rdrF002_CLAIMS_MSTR_HDR = new Reader();
        private Reader rdrF010_PAT_MSTR = new Reader();

        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                //  Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;
                Sort = "ICONST_CLINIC_NBR ASC, RAT_RMB_PROCESS_DATE ASC, RAT_RMB_DOC_NBR ASC, RAT_RMB_ACCOUNT_NBR ASC, RAT_RMB_SERVICE_CD ASC, RAT_RMB_SERVICE_DATE ASC";

                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return ReportData;
        }
        private void Access_U021A_EDT_1HT_FILE()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("RAT_RMB_PROCESS_DATE, ");
            strSQL.Append("RAT_RMB_ACCOUNT_NBR, ");
            strSQL.Append("RAT_RMB_DOC_NBR, ");
            strSQL.Append("RAT_RMB_SPECIALTY_CD, ");
            strSQL.Append("RAT_RMB_PAY_PROG, ");
            strSQL.Append("RAT_RMB_REFER_DOC_NBR, ");
            strSQL.Append("RAT_RMB_FACILITY_NBR, ");
            strSQL.Append("RAT_RMB_ADMIT_DATE, ");
            strSQL.Append("RAT_RMB_HEALTH_NBR, ");
            strSQL.Append("RAT_RMB_VERSION_CD, ");
            strSQL.Append("RAT_RMB_BIRTH_DATE, ");
            strSQL.Append("RAT_RMB_LOC_CD, ");
            strSQL.Append("RAT_RMB_ERROR_H_CD_1, ");
            strSQL.Append("RAT_RMB_ERROR_H_CD_2, ");
            strSQL.Append("RAT_RMB_ERROR_H_CD_3, ");
            strSQL.Append("RAT_RMB_ERROR_H_CD_4, ");
            strSQL.Append("RAT_RMB_ERROR_H_CD_5, ");
            strSQL.Append("RAT_RMB_FILE_NAME, ");
            strSQL.Append("RAT_RMB_SERVICE_DATE, ");
            strSQL.Append("RAT_RMB_SERVICE_CD, ");
            strSQL.Append("RAT_RMB_NBR_OF_SERV, ");
            strSQL.Append("RAT_RMB_AMOUNT_SUB, ");
            strSQL.Append("RAT_RMB_DIAG_CD, ");
            strSQL.Append("RAT_RMB_T_EXPLAN_CD, ");
            strSQL.Append("RAT_RMB_ERROR_T_CD_1, ");
            strSQL.Append("RAT_RMB_ERROR_T_CD_2, ");
            strSQL.Append("RAT_RMB_ERROR_T_CD_3, ");
            strSQL.Append("RAT_RMB_ERROR_T_CD_4, ");
            strSQL.Append("RAT_RMB_ERROR_T_CD_5, ");
            strSQL.Append("RAT_RMB_8_EXPLAN_CD, ");
            strSQL.Append("RAT_RMB_8_EXPLAN_DESC, ");
            strSQL.Append("RAT_RMB_GROUP_NBR ");
            strSQL.Append("FROM TEMPORARYDATA.U021A_EDT_1HT_FILE ");

            strSQL.Append(Choose());

            rdrU021A_EDT_1HT_FILE.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.m_strFlatFileDictionary, ReportFunctions.TextFiles);
            strSQL = null;
        }

        private void Link_TMP_SERV_ERR_CLAIM()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("CLMHDR_ELIG_ERROR, ");
            strSQL.Append("CLMHDR_SERV_ERROR, ");
            strSQL.Append("CLMHDR_STATUS_OHIP ");
            strSQL.Append("FROM INDEXED.TMP_SERV_ERR_CLAIM ");
            strSQL.Append("WHERE RAT_RMB_ACCOUNT_NBR = ").Append(Common.StringToField(rdrU021A_EDT_1HT_FILE.GetString("RAT_RMB_ACCOUNT_NBR")));

            rdrTMP_SERV_ERR_CLAIM.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        private void Link_F020_DOCTOR_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_INIT1, ");
            strSQL.Append("DOC_INIT2, ");
            strSQL.Append("DOC_INIT3, ");
            strSQL.Append("DOC_NAME ");
            strSQL.Append("FROM INDEXED.F020_DOCTOR_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_NBR = ").Append(Common.StringToField(QDesign.Substring(rdrU021A_EDT_1HT_FILE.GetString("RAT_RMB_ACCOUNT_NBR"), 1, 3)));

            rdrF020_DOCTOR_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        private void Link_ICONST_MSTR_REC()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("ICONST_CLINIC_NBR_1_2, ");
            strSQL.Append("ICONST_CLINIC_NBR ");
            strSQL.Append("FROM INDEXED.ICONST_MSTR_REC ");
            strSQL.Append("WHERE ");
            strSQL.Append("ICONST_CLINIC_NBR_1_2 = ").Append(QDesign.NConvert(QDesign.Substring(rdrU021A_EDT_1HT_FILE.GetString("RAT_RMB_GROUP_NBR"), 1, 2)));

            rdrICONST_MSTR_REC.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        private void Link_F002_CLAIMS_MSTR_HDR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("CLMHDR_PAT_KEY_TYPE, ");
            strSQL.Append("CLMHDR_PAT_KEY_DATA, ");
            strSQL.Append("CLMHDR_TOT_CLAIM_AR_OHIP, ");
            strSQL.Append("CLMHDR_MANUAL_AND_TAPE_PAYMENTS, ");
            strSQL.Append("CLMHDR_SERV_DATE ");
            strSQL.Append("FROM INDEXED.F002_CLAIMS_MSTR_HDR ");
            strSQL.Append("WHERE ");
            strSQL.Append("KEY_CLM_TYPE = 'B' ");
            strSQL.Append("AND KEY_CLM_BATCH_NBR = ").Append(Common.StringToField(QDesign.Substring(rdrU021A_EDT_1HT_FILE.GetString("RAT_RMB_GROUP_NBR"), 1, 2) + QDesign.Substring(rdrU021A_EDT_1HT_FILE.GetString("RAT_RMB_ACCOUNT_NBR"), 1, 6)));
            strSQL.Append(" AND KEY_CLM_CLAIM_NBR = ").Append(QDesign.NConvert(QDesign.Substring(rdrU021A_EDT_1HT_FILE.GetString("RAT_RMB_ACCOUNT_NBR"), 7, 2)));
            strSQL.Append(" AND KEY_CLM_SERV_CODE = '00000'");
            strSQL.Append(" AND KEY_CLM_ADJ_NBR = '0'");

            rdrF002_CLAIMS_MSTR_HDR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        private void Link_F010_PAT_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("PAT_HEALTH_NBR ");
            strSQL.Append("FROM INDEXED.F010_PAT_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("PAT_I_KEY = ").Append(Common.StringToField(rdrF002_CLAIMS_MSTR_HDR.GetString("CLMHDR_PAT_KEY_TYPE")));
            strSQL.Append(" AND PAT_CON_NBR = ").Append(QDesign.NConvert(QDesign.Substring(rdrF002_CLAIMS_MSTR_HDR.GetString("CLMHDR_PAT_KEY_DATA"), 1, 2)));
            strSQL.Append(" AND PAT_I_NBR = ").Append(QDesign.NConvert(QDesign.Substring(rdrF002_CLAIMS_MSTR_HDR.GetString("CLMHDR_PAT_KEY_DATA"), 3, 12)));
            strSQL.Append(" AND FILLER4 = ").Append(Common.StringToField(QDesign.Substring(rdrF002_CLAIMS_MSTR_HDR.GetString("CLMHDR_PAT_KEY_DATA"), 15, 1)));

            rdrF010_PAT_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        private string Choose() {
            StringBuilder strChoose = new StringBuilder(string.Empty);

            return strChoose.ToString().ToString();
        }
    
        public override bool SelectIf()
        {
            bool blnSelected = false;

            switch (ReportFunctions.astrScreenParameters[0].ToString())
            {
                case "A":
                    if ((QDesign.NULL(X_BAL_DUE()) != 0 || (QDesign.NULL(X_BAL_DUE()) == 0 && QDesign.NULL(rdrF010_PAT_MSTR.GetNumber("PAT_HEALTH_NBR")) == 1111111116)) && (rdrTMP_SERV_ERR_CLAIM.GetString("CLMHDR_SERV_ERROR") == "Y" && rdrTMP_SERV_ERR_CLAIM.GetString("CLMHDR_STATUS_OHIP") != "R" && QDesign.NULL(X_STALE_DAYS()) < 150))
                    {
                        blnSelected = true;
                    }
                    break;
                case "B":
                    if ((QDesign.NULL(X_BAL_DUE()) != 0 || (QDesign.NULL(X_BAL_DUE()) == 0 && QDesign.NULL(rdrF010_PAT_MSTR.GetNumber("PAT_HEALTH_NBR")) == 1111111116)) && (rdrTMP_SERV_ERR_CLAIM.GetString("CLMHDR_SERV_ERROR") == "Y" && rdrTMP_SERV_ERR_CLAIM.GetString("CLMHDR_STATUS_OHIP") == "R"))
                    {
                        blnSelected = true;
                    }
                    break;
                case "C":
                    if ((QDesign.NULL(X_BAL_DUE()) != 0 || (QDesign.NULL(X_BAL_DUE()) == 0 && QDesign.NULL(rdrF010_PAT_MSTR.GetNumber("PAT_HEALTH_NBR")) == 1111111116)) && (rdrTMP_SERV_ERR_CLAIM.GetString("CLMHDR_SERV_ERROR") == "Y" && rdrTMP_SERV_ERR_CLAIM.GetString("CLMHDR_STATUS_OHIP") != "R" && QDesign.NULL(X_STALE_DAYS()) >= 150))
                    {
                        blnSelected = true;
                    }
                    break;
                default:
                    if ((QDesign.NULL(X_BAL_DUE()) != 0 || (QDesign.NULL(X_BAL_DUE()) == 0 && QDesign.NULL(rdrF010_PAT_MSTR.GetNumber("PAT_HEALTH_NBR")) == 1111111116)) && (rdrTMP_SERV_ERR_CLAIM.GetString("CLMHDR_ELIG_ERROR") == "Y"))
                    {
                        blnSelected = true;
                    }
                    break;
            }

            return blnSelected;
        }
    
        private decimal X_BAL_DUE()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = rdrF002_CLAIMS_MSTR_HDR.GetNumber("CLMHDR_TOT_CLAIM_AR_OHIP") + rdrF002_CLAIMS_MSTR_HDR.GetNumber("CLMHDR_MANUAL_AND_TAPE_PAYMENTS");
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return decReturnValue;
        }
    
        private decimal X_STALE_DAYS()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = QDesign.Days(QDesign.GetDateFromYYYYMMDDDecimal(rdrU021A_EDT_1HT_FILE.GetNumber("RAT_RMB_PROCESS_DATE"))) - QDesign.Days(QDesign.GetDateFromYYYYMMDDDecimal(rdrF002_CLAIMS_MSTR_HDR.GetNumber("CLMHDR_SERV_DATE")));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return decReturnValue;
        }
    
        private string DOC_FULL_NAME()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = rdrF020_DOCTOR_MSTR.GetString("DOC_INIT1") + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT2") + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT3") + " " + rdrF020_DOCTOR_MSTR.GetString("DOC_NAME");
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return strReturnValue;
        }

        private int COUNT = 0;
        private string prev_rmb_account_nbr = string.Empty;
    
        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.PAGE_HEADING, "INDEXED.ICONST_MSTR_REC.ICONST_CLINIC_NBR_1_2", DataTypes.Numeric, 2);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.U021A_EDT_1HT_FILE.RAT_RMB_PROCESS_DATE", DataTypes.Numeric, 8);
                AddControl(ReportSection.PAGE_HEADING, "INDEXED.ICONST_MSTR_REC.ICONST_CLINIC_NBR", DataTypes.Character, 4);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U021A_EDT_1HT_FILE.RAT_RMB_ACCOUNT_NBR", DataTypes.Character, 8);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U021A_EDT_1HT_FILE.RAT_RMB_DOC_NBR", DataTypes.Numeric, 6);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U021A_EDT_1HT_FILE.RAT_RMB_SPECIALTY_CD", DataTypes.Numeric, 2);
                AddControl(ReportSection.HEADING_AT, "DOC_FULL_NAME", DataTypes.Character, 30);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U021A_EDT_1HT_FILE.RAT_RMB_PAY_PROG", DataTypes.Character, 3);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U021A_EDT_1HT_FILE.RAT_RMB_REFER_DOC_NBR", DataTypes.Numeric, 6);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U021A_EDT_1HT_FILE.RAT_RMB_FACILITY_NBR", DataTypes.Character, 4);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U021A_EDT_1HT_FILE.RAT_RMB_ADMIT_DATE", DataTypes.Numeric, 8);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U021A_EDT_1HT_FILE.RAT_RMB_HEALTH_NBR", DataTypes.Character, 10);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U021A_EDT_1HT_FILE.RAT_RMB_VERSION_CD", DataTypes.Character, 2);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U021A_EDT_1HT_FILE.RAT_RMB_BIRTH_DATE", DataTypes.Numeric, 8);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U021A_EDT_1HT_FILE.RAT_RMB_LOC_CD", DataTypes.Character, 4);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U021A_EDT_1HT_FILE.RAT_RMB_ERROR_H_CD_1", DataTypes.Character, 3);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U021A_EDT_1HT_FILE.RAT_RMB_ERROR_H_CD_2", DataTypes.Character, 3);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U021A_EDT_1HT_FILE.RAT_RMB_ERROR_H_CD_3", DataTypes.Character, 3);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U021A_EDT_1HT_FILE.RAT_RMB_ERROR_H_CD_4", DataTypes.Character, 3);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U021A_EDT_1HT_FILE.RAT_RMB_ERROR_H_CD_5", DataTypes.Character, 3);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U021A_EDT_1HT_FILE.RAT_RMB_FILE_NAME", DataTypes.Character, 12);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U021A_EDT_1HT_FILE.RAT_RMB_SERVICE_DATE", DataTypes.Numeric, 8);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U021A_EDT_1HT_FILE.RAT_RMB_SERVICE_CD", DataTypes.Character, 5);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U021A_EDT_1HT_FILE.RAT_RMB_NBR_OF_SERV", DataTypes.Numeric, 2);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U021A_EDT_1HT_FILE.RAT_RMB_AMOUNT_SUB", DataTypes.Numeric, 6);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U021A_EDT_1HT_FILE.RAT_RMB_DIAG_CD", DataTypes.Character, 4);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U021A_EDT_1HT_FILE.RAT_RMB_T_EXPLAN_CD", DataTypes.Character, 2);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U021A_EDT_1HT_FILE.RAT_RMB_ERROR_T_CD_1", DataTypes.Character, 3);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U021A_EDT_1HT_FILE.RAT_RMB_ERROR_T_CD_2", DataTypes.Character, 3);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U021A_EDT_1HT_FILE.RAT_RMB_ERROR_T_CD_3", DataTypes.Character, 3);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U021A_EDT_1HT_FILE.RAT_RMB_ERROR_T_CD_4", DataTypes.Character, 3);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U021A_EDT_1HT_FILE.RAT_RMB_ERROR_T_CD_5", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U021A_EDT_1HT_FILE.RAT_RMB_8_EXPLAN_CD", DataTypes.Character, 2);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U021A_EDT_1HT_FILE.RAT_RMB_8_EXPLAN_DESC", DataTypes.Character, 55);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U021A_EDT_1HT_FILE.RAT_RMB_GROUP_NBR", DataTypes.Character, 4);
                AddControl(ReportSection.REPORT, "COUNT", DataTypes.Numeric, 5);
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
                case "INDEXED.ICONST_MSTR_REC.ICONST_CLINIC_NBR_1_2":
                    return rdrICONST_MSTR_REC.GetNumber("ICONST_CLINIC_NBR_1_2").ToString();

                case "TEMPORARYDATA.U021A_EDT_1HT_FILE.RAT_RMB_PROCESS_DATE":
                    return rdrU021A_EDT_1HT_FILE.GetNumber("RAT_RMB_PROCESS_DATE").ToString();

                case "INDEXED.ICONST_MSTR_REC.ICONST_CLINIC_NBR":
                    return Common.StringToField(rdrICONST_MSTR_REC.GetString("ICONST_CLINIC_NBR"));

                case "TEMPORARYDATA.U021A_EDT_1HT_FILE.RAT_RMB_ACCOUNT_NBR":
                    return Common.StringToField(rdrU021A_EDT_1HT_FILE.GetString("RAT_RMB_ACCOUNT_NBR"));

                case "TEMPORARYDATA.U021A_EDT_1HT_FILE.RAT_RMB_DOC_NBR":
                    return rdrU021A_EDT_1HT_FILE.GetNumber("RAT_RMB_DOC_NBR").ToString();

                case "TEMPORARYDATA.U021A_EDT_1HT_FILE.RAT_RMB_SPECIALTY_CD":
                    return rdrU021A_EDT_1HT_FILE.GetNumber("RAT_RMB_SPECIALTY_CD").ToString();

                case "DOC_FULL_NAME":
                    return Common.StringToField(DOC_FULL_NAME());

                case "TEMPORARYDATA.U021A_EDT_1HT_FILE.RAT_RMB_PAY_PROG":
                    return Common.StringToField(rdrU021A_EDT_1HT_FILE.GetString("RAT_RMB_PAY_PROG"));

                case "TEMPORARYDATA.U021A_EDT_1HT_FILE.RAT_RMB_REFER_DOC_NBR":
                    return rdrU021A_EDT_1HT_FILE.GetNumber("RAT_RMB_REFER_DOC_NBR").ToString();

                case "TEMPORARYDATA.U021A_EDT_1HT_FILE.RAT_RMB_FACILITY_NBR":
                    return Common.StringToField(rdrU021A_EDT_1HT_FILE.GetString("RAT_RMB_FACILITY_NBR"));

                case "TEMPORARYDATA.U021A_EDT_1HT_FILE.RAT_RMB_ADMIT_DATE":
                    return rdrU021A_EDT_1HT_FILE.GetNumber("RAT_RMB_ADMIT_DATE").ToString();

                case "TEMPORARYDATA.U021A_EDT_1HT_FILE.RAT_RMB_HEALTH_NBR":
                    return Common.StringToField(rdrU021A_EDT_1HT_FILE.GetString("RAT_RMB_HEALTH_NBR"));

                case "TEMPORARYDATA.U021A_EDT_1HT_FILE.RAT_RMB_VERSION_CD":
                    return Common.StringToField(rdrU021A_EDT_1HT_FILE.GetString("RAT_RMB_VERSION_CD"));

                case "TEMPORARYDATA.U021A_EDT_1HT_FILE.RAT_RMB_BIRTH_DATE":
                    return rdrU021A_EDT_1HT_FILE.GetNumber("RAT_RMB_BIRTH_DATE").ToString();

                case "TEMPORARYDATA.U021A_EDT_1HT_FILE.RAT_RMB_LOC_CD":
                    return Common.StringToField(rdrU021A_EDT_1HT_FILE.GetString("RAT_RMB_LOC_CD"));

                case "TEMPORARYDATA.U021A_EDT_1HT_FILE.RAT_RMB_ERROR_H_CD_1":
                    return Common.StringToField(rdrU021A_EDT_1HT_FILE.GetString("RAT_RMB_ERROR_H_CD_1"));

                case "TEMPORARYDATA.U021A_EDT_1HT_FILE.RAT_RMB_ERROR_H_CD_2":
                    return Common.StringToField(rdrU021A_EDT_1HT_FILE.GetString("RAT_RMB_ERROR_H_CD_2"));

                case "TEMPORARYDATA.U021A_EDT_1HT_FILE.RAT_RMB_ERROR_H_CD_3":
                    return Common.StringToField(rdrU021A_EDT_1HT_FILE.GetString("RAT_RMB_ERROR_H_CD_3"));

                case "TEMPORARYDATA.U021A_EDT_1HT_FILE.RAT_RMB_ERROR_H_CD_4":
                    return Common.StringToField(rdrU021A_EDT_1HT_FILE.GetString("RAT_RMB_ERROR_H_CD_4"));

                case "TEMPORARYDATA.U021A_EDT_1HT_FILE.RAT_RMB_ERROR_H_CD_5":
                    return Common.StringToField(rdrU021A_EDT_1HT_FILE.GetString("RAT_RMB_ERROR_H_CD_5"));

                case "TEMPORARYDATA.U021A_EDT_1HT_FILE.RAT_RMB_FILE_NAME":
                    return Common.StringToField(rdrU021A_EDT_1HT_FILE.GetString("RAT_RMB_FILE_NAME"));

                case "TEMPORARYDATA.U021A_EDT_1HT_FILE.RAT_RMB_SERVICE_DATE":
                    return rdrU021A_EDT_1HT_FILE.GetNumber("RAT_RMB_SERVICE_DATE").ToString();

                case "TEMPORARYDATA.U021A_EDT_1HT_FILE.RAT_RMB_SERVICE_CD":
                    return Common.StringToField(rdrU021A_EDT_1HT_FILE.GetString("RAT_RMB_SERVICE_CD"));

                case "TEMPORARYDATA.U021A_EDT_1HT_FILE.RAT_RMB_NBR_OF_SERV":
                    return rdrU021A_EDT_1HT_FILE.GetNumber("RAT_RMB_NBR_OF_SERV").ToString();

                case "TEMPORARYDATA.U021A_EDT_1HT_FILE.RAT_RMB_AMOUNT_SUB":
                    return rdrU021A_EDT_1HT_FILE.GetNumber("RAT_RMB_AMOUNT_SUB").ToString();

                case "TEMPORARYDATA.U021A_EDT_1HT_FILE.RAT_RMB_DIAG_CD":
                    return Common.StringToField(rdrU021A_EDT_1HT_FILE.GetString("RAT_RMB_DIAG_CD"));

                case "TEMPORARYDATA.U021A_EDT_1HT_FILE.RAT_RMB_T_EXPLAN_CD":
                    return Common.StringToField(rdrU021A_EDT_1HT_FILE.GetString("RAT_RMB_T_EXPLAN_CD"));

                case "TEMPORARYDATA.U021A_EDT_1HT_FILE.RAT_RMB_ERROR_T_CD_1":
                    return Common.StringToField(rdrU021A_EDT_1HT_FILE.GetString("RAT_RMB_ERROR_T_CD_1"));

                case "TEMPORARYDATA.U021A_EDT_1HT_FILE.RAT_RMB_ERROR_T_CD_2":
                    return Common.StringToField(rdrU021A_EDT_1HT_FILE.GetString("RAT_RMB_ERROR_T_CD_2"));

                case "TEMPORARYDATA.U021A_EDT_1HT_FILE.RAT_RMB_ERROR_T_CD_3":
                    return Common.StringToField(rdrU021A_EDT_1HT_FILE.GetString("RAT_RMB_ERROR_T_CD_3"));

                case "TEMPORARYDATA.U021A_EDT_1HT_FILE.RAT_RMB_ERROR_T_CD_4":
                    return Common.StringToField(rdrU021A_EDT_1HT_FILE.GetString("RAT_RMB_ERROR_T_CD_4"));

                case "TEMPORARYDATA.U021A_EDT_1HT_FILE.RAT_RMB_ERROR_T_CD_5":
                    return Common.StringToField(rdrU021A_EDT_1HT_FILE.GetString("RAT_RMB_ERROR_T_CD_5"));

                case "TEMPORARYDATA.U021A_EDT_1HT_FILE.RAT_RMB_8_EXPLAN_CD":
                    return Common.StringToField(rdrU021A_EDT_1HT_FILE.GetString("RAT_RMB_8_EXPLAN_CD"));

                case "TEMPORARYDATA.U021A_EDT_1HT_FILE.RAT_RMB_8_EXPLAN_DESC":
                    return Common.StringToField(rdrU021A_EDT_1HT_FILE.GetString("RAT_RMB_8_EXPLAN_DESC"));

                case "TEMPORARYDATA.U021A_EDT_1HT_FILE.RAT_RMB_GROUP_NBR":
                    return Common.StringToField(rdrU021A_EDT_1HT_FILE.GetString("RAT_RMB_GROUP_NBR"));

                case "COUNT":
                    return COUNT.ToString();

                default:
                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_U021A_EDT_1HT_FILE();
                while (rdrU021A_EDT_1HT_FILE.Read())
                {
                    Link_TMP_SERV_ERR_CLAIM();
                    while (rdrTMP_SERV_ERR_CLAIM.Read())
                    {
                        Link_F020_DOCTOR_MSTR();
                        while (rdrF020_DOCTOR_MSTR.Read())
                        {
                            Link_ICONST_MSTR_REC();
                            while (rdrICONST_MSTR_REC.Read())
                            {
                                Link_F002_CLAIMS_MSTR_HDR();
                                while (rdrF002_CLAIMS_MSTR_HDR.Read())
                                {
                                    Link_F010_PAT_MSTR();
                                    while (rdrF010_PAT_MSTR.Read())
                                    {
                                        if (prev_rmb_account_nbr == string.Empty)
                                        {
                                            COUNT = 1;
                                            setPreviousValues();
                                        }
                                        else if (prev_rmb_account_nbr == rdrU021A_EDT_1HT_FILE.GetString("RAT_RMB_ACCOUNT_NBR"))
                                        {
                                            COUNT = 0;
                                        }
                                        else
                                        {
                                            COUNT = 1;
                                            setPreviousValues();
                                        }
                                        
                                        WriteData();
                                    }
                                    rdrF010_PAT_MSTR.Close();
                                }
                                rdrF002_CLAIMS_MSTR_HDR.Close();
                            }
                            rdrICONST_MSTR_REC.Close();
                        }
                        rdrF020_DOCTOR_MSTR.Close();
                    }
                    rdrTMP_SERV_ERR_CLAIM.Close();
                }
                rdrU021A_EDT_1HT_FILE.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        private void setPreviousValues()
        {
            prev_rmb_account_nbr = rdrU021A_EDT_1HT_FILE.GetString("RAT_RMB_ACCOUNT_NBR");
        }

        public override void CloseReaders()
        {
            if (!(rdrU021A_EDT_1HT_FILE == null))
            {
                rdrU021A_EDT_1HT_FILE.Close();
                rdrU021A_EDT_1HT_FILE = null;
            }

            if (!(rdrTMP_SERV_ERR_CLAIM == null))
            {
                rdrTMP_SERV_ERR_CLAIM.Close();
                rdrTMP_SERV_ERR_CLAIM = null;
            }

            if (!(rdrF020_DOCTOR_MSTR == null))
            {
                rdrF020_DOCTOR_MSTR.Close();
                rdrF020_DOCTOR_MSTR = null;
            }

            if (!(rdrICONST_MSTR_REC == null))
            {
                rdrICONST_MSTR_REC.Close();
                rdrICONST_MSTR_REC = null;
            }

            if (!(rdrF002_CLAIMS_MSTR_HDR == null))
            {
                rdrF002_CLAIMS_MSTR_HDR.Close();
                rdrF002_CLAIMS_MSTR_HDR = null;
            }

            if (!(rdrF010_PAT_MSTR == null))
            {
                rdrF010_PAT_MSTR.Close();
                rdrF010_PAT_MSTR = null;
            }
        }
    }
}
