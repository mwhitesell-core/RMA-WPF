//  #> PROGRAM-ID.     r021c.qzs
//  ((C)) Dyad Technologies
//  PROGRAM PURPOSE : PRINT THE OHIP RMB ERROR REPORT   
//  MODIFICATION HISTORY
//  DATE   WHO          DESCRIPTION
//  03/MAR/31 M.C.         - ORIGINAL 
//  03/APR/24 M.C.      - include referring doctor, hospital nbr and admit date 
//  in the report as Thelka needs them
//  03/JUN/02 M.C.      - change to prdecimal clinic and group number properly
//  03/JUN/05 M.C.      - Thekla requested to include doc ohip nbr, specialty code
//  doc full name and pay program, make it letter size  
//  2004/mar/02 M.C.       - sort on group nbr on process date before account nbr
//  - skip page at process date
//  2004/mar/02 M.C.       - provide final total number of rejected claims  
//  2004/sep/28 b.e.       - replace truncate file with with rat-rmb-file-name ;
//  to show all 12 chars of the name
//  2011/May/17 MC1        - prdecimal rat-rmb-file-name at header
//  !    link (nconvert(rat-rmb-account-nbr[1:3]))               &
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
    public class R021C : BaseRDLClass
    {
        protected const string REPORT_NAME = "R021C";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrU021A_EDT_RMB_FILE = new Reader();
        private Reader rdrF020_DOCTOR_MSTR = new Reader();
        private Reader rdrICONST_MSTR_REC = new Reader();
        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                //  Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;
                Sort = "ICONST_CLINIC_NBR ASC, RAT_RMB_PROCESS_DATE ASC, RAT_RMB_DOC_NBR ASC, RAT_RMB_ACCOUNT_NBR ASC, RAT_RMB_SERVICE_CD ASC, RAT" +
                "_RMB_SERVICE_DATE ASC";
                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return ReportData;
        }
        private void Access_U021A_EDT_RMB_FILE()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("RAT_RMB_ACCOUNT_NBR, ");
            strSQL.Append("RAT_RMB_GROUP_NBR, ");
            strSQL.Append("RAT_RMB_PROCESS_DATE, ");
            strSQL.Append("RAT_RMB_SERVICE_CD, ");
            strSQL.Append("RAT_RMB_SERVICE_DATE, ");
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
            strSQL.Append("RAT_RMB_REGISTRATION_NBR, ");
            strSQL.Append("RAT_RMB_LAST_NAME, ");
            strSQL.Append("RAT_RMB_FIRST_NAME, ");
            strSQL.Append("RAT_RMB_SEX, ");
            strSQL.Append("RAT_RMB_PROV_CD, ");
            strSQL.Append("RAT_RMB_T_EXPLAN_CD, ");
            strSQL.Append("RAT_RMB_ERROR_T_CD_1, ");
            strSQL.Append("RAT_RMB_ERROR_T_CD_2, ");
            strSQL.Append("RAT_RMB_ERROR_T_CD_3, ");
            strSQL.Append("RAT_RMB_ERROR_T_CD_4, ");
            strSQL.Append("RAT_RMB_ERROR_T_CD_5, ");
            strSQL.Append("RAT_RMB_NBR_OF_SERV, ");
            strSQL.Append("RAT_RMB_AMOUNT_SUB, ");
            strSQL.Append("RAT_RMB_DIAG_CD, ");
            strSQL.Append("RAT_RMB_8_EXPLAN_CD, ");
            strSQL.Append("RAT_RMB_8_EXPLAN_DESC ");
            strSQL.Append("FROM TEMPORARYDATA.U021A_EDT_RMB_FILE ");

            strSQL.Append(Choose());

            rdrU021A_EDT_RMB_FILE.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.m_strFlatFileDictionary, ReportFunctions.TextFiles);
            strSQL = null;
        }
        private void Link_F020_DOCTOR_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("DOC_INIT1, ");
            strSQL.Append("DOC_INIT2, ");
            strSQL.Append("DOC_INIT3, ");
            strSQL.Append("DOC_NAME ");
            strSQL.Append("FROM INDEXED.F020_DOCTOR_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_NBR = ").Append(Common.StringToField(QDesign.Substring(rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_ACCOUNT_NBR"), 1, 3)));

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
            strSQL.Append("ICONST_CLINIC_NBR_1_2 = ").Append(QDesign.NConvert(QDesign.Substring(rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_GROUP_NBR"), 1, 2)));

            rdrICONST_MSTR_REC.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(string.Empty);

            return strChoose.ToString();
        }

        private string DOC_FULL_NAME()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = QDesign.Pack(rdrF020_DOCTOR_MSTR.GetString("DOC_INIT1") 
                    + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT2") 
                    + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT3") 
                    + " " 
                    + rdrF020_DOCTOR_MSTR.GetString("DOC_NAME"));
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
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_PROCESS_DATE", DataTypes.Numeric, 8);
                AddControl(ReportSection.PAGE_HEADING, "INDEXED.ICONST_MSTR_REC.ICONST_CLINIC_NBR", DataTypes.Character, 4);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_DOC_NBR", DataTypes.Numeric, 6);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_SPECIALTY_CD", DataTypes.Numeric, 2);
                AddControl(ReportSection.HEADING_AT, "DOC_FULL_NAME", DataTypes.Character, 30);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_PAY_PROG", DataTypes.Character, 3);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_REFER_DOC_NBR", DataTypes.Numeric, 6);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_FACILITY_NBR", DataTypes.Character, 4);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_ADMIT_DATE", DataTypes.Numeric, 8);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_ACCOUNT_NBR", DataTypes.Character, 8);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_HEALTH_NBR", DataTypes.Character, 10);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_VERSION_CD", DataTypes.Character, 2);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_BIRTH_DATE", DataTypes.Numeric, 8);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_LOC_CD", DataTypes.Character, 4);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_ERROR_H_CD_1", DataTypes.Character, 3);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_ERROR_H_CD_2", DataTypes.Character, 3);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_ERROR_H_CD_3", DataTypes.Character, 3);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_ERROR_H_CD_4", DataTypes.Character, 3);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_ERROR_H_CD_5", DataTypes.Character, 3);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_FILE_NAME", DataTypes.Character, 12);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_REGISTRATION_NBR", DataTypes.Character, 12);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_LAST_NAME", DataTypes.Character, 14);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_FIRST_NAME", DataTypes.Character, 5);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_SEX", DataTypes.Character, 1);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_PROV_CD", DataTypes.Character, 2);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_T_EXPLAN_CD", DataTypes.Character, 2);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_ERROR_T_CD_1", DataTypes.Character, 3);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_ERROR_T_CD_2", DataTypes.Character, 3);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_ERROR_T_CD_3", DataTypes.Character, 3);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_ERROR_T_CD_4", DataTypes.Character, 3);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_ERROR_T_CD_5", DataTypes.Character, 3);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_SERVICE_CD", DataTypes.Character, 5);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_SERVICE_DATE", DataTypes.Numeric, 8);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_NBR_OF_SERV", DataTypes.Numeric, 2);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_AMOUNT_SUB", DataTypes.Numeric, 6);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_DIAG_CD", DataTypes.Character, 4);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_8_EXPLAN_CD", DataTypes.Character, 2);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_8_EXPLAN_DESC", DataTypes.Character, 55);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_GROUP_NBR", DataTypes.Character, 4);
                AddControl(ReportSection.REPORT, "COUNT", DataTypes.Numeric, 5);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2019-01-29 10:23:44 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            // TODO: Remove duplicate controls, if there are any.
            switch (strControl)
            {
                case "INDEXED.ICONST_MSTR_REC.ICONST_CLINIC_NBR_1_2":
                    return rdrICONST_MSTR_REC.GetNumber("ICONST_CLINIC_NBR_1_2").ToString();
                case "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_PROCESS_DATE":
                    return rdrU021A_EDT_RMB_FILE.GetNumber("RAT_RMB_PROCESS_DATE").ToString();
                case "INDEXED.ICONST_MSTR_REC.ICONST_CLINIC_NBR":
                    return Common.StringToField(rdrICONST_MSTR_REC.GetString("ICONST_CLINIC_NBR"));
                case "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_DOC_NBR":
                    return rdrU021A_EDT_RMB_FILE.GetNumber("RAT_RMB_DOC_NBR").ToString();
                case "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_SPECIALTY_CD":
                    return rdrU021A_EDT_RMB_FILE.GetNumber("RAT_RMB_SPECIALTY_CD").ToString();
                case "DOC_FULL_NAME":
                    return Common.StringToField(DOC_FULL_NAME(), intSize);
                case "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_PAY_PROG":
                    return Common.StringToField(rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_PAY_PROG"));
                case "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_REFER_DOC_NBR":
                    return rdrU021A_EDT_RMB_FILE.GetNumber("RAT_RMB_REFER_DOC_NBR").ToString();
                case "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_FACILITY_NBR":
                    return Common.StringToField(rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_FACILITY_NBR"));
                case "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_ADMIT_DATE":
                    return rdrU021A_EDT_RMB_FILE.GetNumber("RAT_RMB_ADMIT_DATE").ToString();
                case "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_ACCOUNT_NBR":
                    return Common.StringToField(rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_ACCOUNT_NBR"));
                case "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_HEALTH_NBR":
                    return Common.StringToField(rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_HEALTH_NBR"));
                case "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_VERSION_CD":
                    return Common.StringToField(rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_VERSION_CD"));
                case "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_BIRTH_DATE":
                    return rdrU021A_EDT_RMB_FILE.GetNumber("RAT_RMB_BIRTH_DATE").ToString();
                case "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_LOC_CD":
                    return Common.StringToField(rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_LOC_CD"));
                case "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_ERROR_H_CD_1":
                    return Common.StringToField(rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_ERROR_H_CD_1"));
                case "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_ERROR_H_CD_2":
                    return Common.StringToField(rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_ERROR_H_CD_2"));
                case "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_ERROR_H_CD_3":
                    return Common.StringToField(rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_ERROR_H_CD_3"));
                case "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_ERROR_H_CD_4":
                    return Common.StringToField(rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_ERROR_H_CD_4"));
                case "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_ERROR_H_CD_5":
                    return Common.StringToField(rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_ERROR_H_CD_5"));
                case "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_FILE_NAME":
                    return Common.StringToField(rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_FILE_NAME"));
                case "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_REGISTRATION_NBR":
                    return Common.StringToField(rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_REGISTRATION_NBR"));
                case "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_LAST_NAME":
                    return Common.StringToField(rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_LAST_NAME"));
                case "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_FIRST_NAME":
                    return Common.StringToField(rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_FIRST_NAME"));
                case "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_SEX":
                    return Common.StringToField(rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_SEX"));
                case "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_PROV_CD":
                    return Common.StringToField(rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_PROV_CD"));
                case "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_T_EXPLAN_CD":
                    return Common.StringToField(rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_T_EXPLAN_CD"));
                case "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_ERROR_T_CD_1":
                    return Common.StringToField(rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_ERROR_T_CD_1"));
                case "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_ERROR_T_CD_2":
                    return Common.StringToField(rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_ERROR_T_CD_2"));
                case "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_ERROR_T_CD_3":
                    return Common.StringToField(rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_ERROR_T_CD_3"));
                case "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_ERROR_T_CD_4":
                    return Common.StringToField(rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_ERROR_T_CD_4"));
                case "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_ERROR_T_CD_5":
                    return Common.StringToField(rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_ERROR_T_CD_5"));
                case "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_SERVICE_CD":
                    return Common.StringToField(rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_SERVICE_CD"));
                case "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_SERVICE_DATE":
                    return rdrU021A_EDT_RMB_FILE.GetNumber("RAT_RMB_SERVICE_DATE").ToString();
                case "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_NBR_OF_SERV":
                    return rdrU021A_EDT_RMB_FILE.GetNumber("RAT_RMB_NBR_OF_SERV").ToString();
                case "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_AMOUNT_SUB":
                    return rdrU021A_EDT_RMB_FILE.GetNumber("RAT_RMB_AMOUNT_SUB").ToString();
                case "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_DIAG_CD":
                    return Common.StringToField(rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_DIAG_CD"));
                case "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_8_EXPLAN_CD":
                    return Common.StringToField(rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_8_EXPLAN_CD"));
                case "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_8_EXPLAN_DESC":
                    return Common.StringToField(rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_8_EXPLAN_DESC"));
                case "TEMPORARYDATA.U021A_EDT_RMB_FILE.RAT_RMB_GROUP_NBR":
                    return Common.StringToField(rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_GROUP_NBR"));
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
                // TODO: Some manual steps maybe required.
                Access_U021A_EDT_RMB_FILE();
                while (rdrU021A_EDT_RMB_FILE.Read())
                {
                    Link_F020_DOCTOR_MSTR();
                    while (rdrF020_DOCTOR_MSTR.Read())
                    {
                        Link_ICONST_MSTR_REC();
                        while (rdrICONST_MSTR_REC.Read())
                        {
                            if (prev_rmb_account_nbr == string.Empty)
                            {
                                COUNT = 1;
                                setPreviousValues();
                            }
                            else if (prev_rmb_account_nbr == rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_ACCOUNT_NBR"))
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

                        rdrICONST_MSTR_REC.Close();
                    }

                    rdrF020_DOCTOR_MSTR.Close();
                }

                rdrU021A_EDT_RMB_FILE.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        private void setPreviousValues()
        {
            prev_rmb_account_nbr = rdrU021A_EDT_RMB_FILE.GetString("RAT_RMB_ACCOUNT_NBR");
        }

        public override void CloseReaders()
        {
            if (!(rdrU021A_EDT_RMB_FILE == null))
            {
                rdrU021A_EDT_RMB_FILE.Close();
                rdrU021A_EDT_RMB_FILE = null;
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
        }
    }
}
