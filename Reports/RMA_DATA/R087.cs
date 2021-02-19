#region "Screen Comments"

// program: r087
// purpose: rma history report for letters send to patients
// 93/04/19 AGK       SMS 141 (ORIGINAL)
// 93/04/22        Y.B.      MODIFY REPORT FORMAT
// 93/05/21 M. CHAN   - ADD THE MESS CODE CHECK IN THE
// SELECTION CRITERIA (SAME AS R085.QZS)
// 94/02/22 M. CHAN   - PDR 594
// - CHECK LAST MAILING > 21 DAYS OLD
// INSTEAD OF 10 DAYS
// 98/12/10        B.E.   - changed to access *r085 subfile rather than
// selecting records directly from the 
// rejected-claims file.
// 99/jan/31 B.E. - y2k
// 00/jan/21 yas  - prdecimal patient once 
// 00/jun/29 B.E. - changed to access *u085b rather than 
// 00/jun/29 B.E. - changed to access *u085b rather than *r085. This ensures
// the claims printed are the same ones printed in the
// letters and have been filtered so that no `confidential`
// claims are printed
// 03/dec/15 A.A. - alpha doctor nbr
// 05/jun/16 M.C. - include days old column, add days old in sort
// 09/Apr/02 yas. - Add service date column and report service date
// 10/jun/22 MC1  - include rejected-claims in access statement and add sel if clmhdr-submit-date = blank         
// and logically-deleted-flag <>  Y      
// 11/Jan/17 MC2  - include u020c_ohip_run_date in the access 
// 11/Jan/17 MC3  - sel if clmhdr-submit-date of rejected-claims = ohip_run_date of u020c_ohip_run_date  
// 11/Feb/03 MC4  - add the resubmit criteria in the selection
// 11/Mar/02 brad - add more criteria in the selection (hard code the date)
// 11/Apr/04 MC5  - modify the criteria and change the second-last-rundate to 20110324
// - add second_last_ohip_rundate subfile in the access
// 17/Feb/27 MC6  - Yasemin requested to change resubmit criteria from 35 days to 25 days
// ! nconvert(ascii(claim-nbr,10)[1:2] +  0  + ascii(claim-nbr,10)[3:6]), &
// ! nconvert(ascii(claim-nbr,10)[9:2]),     &
// 2010/06/22 - MC1
// 2010/06/22 - end
// 2011/01/17 - MC2
// 2011/01/17 - end
// 2011/04/04 - MC5

#endregion

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
    public class R087 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R087";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrU085B = new Reader();
        private Reader rdrF002_CLAIMS_MSTR = new Reader();
        private Reader rdrF010_PAT_MSTR = new Reader();
        private Reader rdrREJECTED_CLAIMS = new Reader();
        private Reader rdrU020C_OHIP_RUN_DATE = new Reader();
        private Reader rdrSECOND_LAST_OHIP_RUNDATE = new Reader();

        #endregion

        #region " Renaissance Data "

        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                // Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;

                Sort = "PAT_SURNAME ASC, PAT_GIVEN_NAME ASC, CLMHDR_PAT_OHIP_ID_OR_CHART ASC, D_DAYS_OLD DESC";

                // Start report data processing.
                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return ReportData;
        }

        #endregion

        #region " Renaissance Statements "

        #region " ACCESS "

        private void Access_U085B()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT * ");
            strSQL.Append("FROM TEMPORARYDATA.U085B ");

            strSQL.Append(Choose());

            rdrU085B.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);

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
            strSQL.Append("CLMHDR_SERV_DATE, ");
            strSQL.Append("CLMHDR_AGENT_CD, ");
            strSQL.Append("CLMHDR_LOC ");
            strSQL.Append("FROM INDEXED.F002_CLAIMS_MSTR_HDR ");
            strSQL.Append("WHERE ");
            strSQL.Append("KEY_CLM_TYPE = ").Append(Common.StringToField("B"));
            strSQL.Append(" AND KEY_CLM_BATCH_NBR = '").Append(QDesign.Substring(rdrU085B.GetString("CLAIM_NBR"), 1, 8));
            strSQL.Append("' AND KEY_CLM_CLAIM_NBR = ").Append(QDesign.NConvert(QDesign.Substring(rdrU085B.GetString("CLAIM_NBR"), 9, 2)));
            strSQL.Append(" AND KEY_CLM_SERV_CODE = ").Append(Common.StringToField("00000"));
            strSQL.Append(" AND KEY_CLM_ADJ_NBR = ").Append(Common.StringToField("0"));

            rdrF002_CLAIMS_MSTR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

            strSQL = null;
        }

        private void Link_F010_PAT_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("PAT_DATE_LAST_ELIG_MAILING, ");
            strSQL.Append("PAT_SURNAME_FIRST3, ");
            strSQL.Append("PAT_SURNAME_LAST22, ");
            strSQL.Append("PAT_GIVEN_NAME_FIRST1, ");
            strSQL.Append("FILLER3, ");
            strSQL.Append("PAT_NO_OF_LETTER_SENT, ");
            strSQL.Append("PAT_HEALTH_NBR, ");
            strSQL.Append("PAT_VERSION_CD, ");
            strSQL.Append("PAT_BIRTH_DATE_YY, ");
            strSQL.Append("PAT_BIRTH_DATE_MM, ");
            strSQL.Append("PAT_BIRTH_DATE_DD ");
            strSQL.Append("FROM INDEXED.F010_PAT_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("PAT_I_KEY = ").Append(Common.StringToField(QDesign.Substring(rdrU085B.GetString("CLMHDR_PAT_OHIP_ID_OR_CHART"), 1, 1)));
            strSQL.Append(" AND PAT_CON_NBR = ").Append(Common.StringToField(QDesign.Substring(rdrU085B.GetString("CLMHDR_PAT_OHIP_ID_OR_CHART"), 2, 2)));
            strSQL.Append(" AND PAT_I_NBR = ").Append(Common.StringToField(QDesign.Substring(rdrU085B.GetString("CLMHDR_PAT_OHIP_ID_OR_CHART"), 4, 12)));
            strSQL.Append(" AND FILLER4 = ").Append(Common.StringToField(QDesign.Substring(rdrU085B.GetString("CLMHDR_PAT_OHIP_ID_OR_CHART"),16, 1)));

            rdrF010_PAT_MSTR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

            strSQL = null;
        }

        private void Link_REJECTED_CLAIMS()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("CLAIM_NBR, ");
            strSQL.Append("LOGICALLY_DELETED_FLAG, ");
            strSQL.Append("CLMHDR_SUBMIT_DATE, ");
            strSQL.Append("MESS_CODE ");
            strSQL.Append("FROM INDEXED.REJECTED_CLAIMS ");
            strSQL.Append("WHERE ");
            strSQL.Append("CLAIM_NBR = ").Append(Common.StringToField(rdrU085B.GetString("CLAIM_NBR")));

            rdrREJECTED_CLAIMS.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

            strSQL = null;
        }

        private void Link_U020C_OHIP_RUN_DATE()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
           // strSQL.Append("CORE_RECORD_NUMBER, ");
            strSQL.Append("OHIP_RUN_DATE ");
            strSQL.Append("FROM TEMPORARYDATA.U020C_OHIP_RUN_DATE ");

            rdrU020C_OHIP_RUN_DATE.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);

            strSQL = null;
        }

        private void Link_SECOND_LAST_OHIP_RUNDATE()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            //strSQL.Append("CORE_RECORD_NUMBER, ");
            strSQL.Append("OHIP_RUN_DATE ");
            strSQL.Append("FROM TEMPORARYDATA.SECOND_LAST_OHIP_RUNDATE ");

            rdrSECOND_LAST_OHIP_RUNDATE.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);

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

            if (QDesign.NULL(rdrREJECTED_CLAIMS.GetString("LOGICALLY_DELETED_FLAG")) != "Y" 
                && (QDesign.NULL(rdrREJECTED_CLAIMS.GetNumber("CLMHDR_SUBMIT_DATE")) == QDesign.NULL(rdrU020C_OHIP_RUN_DATE.GetNumber("OHIP_RUN_DATE")) 
                || ((QDesign.NULL(rdrF010_PAT_MSTR.GetNumber("PAT_DATE_LAST_ELIG_MAILING")) == 0 
                || QDesign.NULL(rdrF010_PAT_MSTR.GetNumber("PAT_DATE_LAST_ELIG_MAILING")) == 160100 
                || QDesign.NULL(rdrF010_PAT_MSTR.GetNumber("PAT_DATE_LAST_ELIG_MAILING")) == 19160100
                || (QDesign.NULL(D_TEST_DATE()) > 25 && QDesign.NULL(rdrF010_PAT_MSTR.GetNumber("PAT_NO_OF_LETTER_SENT")) < 2) )
                && ((QDesign.NULL(D_TEST_DATE_2NDLAST()) > 0 && D_TEST_DATE_2NDLAST() <= 25) 
                    || rdrF010_PAT_MSTR.GetNumber("PAT_NO_OF_LETTER_SENT") >= 2))))
                blnSelected = true;

            return blnSelected;
        }

        #endregion

        #region " DEFINES "

        private decimal D_TEST_DATE()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrF010_PAT_MSTR.GetNumber("PAT_DATE_LAST_ELIG_MAILING")) > 0)
                {
                    decReturnValue = QDesign.Days(QDesign.SysDate(ref m_cnnQUERY)) - QDesign.Days(rdrF010_PAT_MSTR.GetNumber("PAT_DATE_LAST_ELIG_MAILING"));
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal SECOND_LAST_RUNDATE()
        {
            decimal decReturnValue = 0;

            try
            {
                decReturnValue = rdrSECOND_LAST_OHIP_RUNDATE.GetNumber("OHIP_RUN_DATE");
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal D_TEST_DATE_2NDLAST()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrF010_PAT_MSTR.GetNumber("PAT_DATE_LAST_ELIG_MAILING")) > 0)
                {
                    decReturnValue = QDesign.Days(SECOND_LAST_RUNDATE()) - QDesign.Days(rdrF010_PAT_MSTR.GetNumber("PAT_DATE_LAST_ELIG_MAILING"));
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal D_DAYS_OLD()
        {
            decimal decReturnValue = 0;

            try
            {
                decReturnValue = QDesign.Days(QDesign.SysDate(ref m_cnnQUERY)) - QDesign.Days(rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_SERV_DATE"));
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private string X_PAT_NAME()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.Pack((F010_PAT_MSTR_PAT_SURNAME() + (", " + F010_PAT_MSTR_PAT_GIVEN_NAME())));
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private decimal F010_PAT_MSTR_PAT_BIRTH_DATE()
        {
            decimal decReturnValue = 0;

            try
            {
                decReturnValue = QDesign.NConvert(QDesign.ASCII(rdrF010_PAT_MSTR.GetNumber("PAT_BIRTH_DATE_YY")) + QDesign.ASCII(rdrF010_PAT_MSTR.GetNumber("PAT_BIRTH_DATE_MM")).PadLeft(2, '0') + QDesign.ASCII(rdrF010_PAT_MSTR.GetNumber("PAT_BIRTH_DATE_DD")).PadLeft(2, '0'));
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
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
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string F010_PAT_MSTR_PAT_GIVEN_NAME()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = rdrF010_PAT_MSTR.GetString("PAT_GIVEN_NAME_FIRST1") + rdrF010_PAT_MSTR.GetString("FILLER3");
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
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
                // Write the exception to the log file.
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
                AddControl(ReportSection.FOOTING_AT, "X_PAT_NAME", DataTypes.Character, 30);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.REJECTED_CLAIMS.MESS_CODE", DataTypes.Character, 3);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F010_PAT_MSTR.PAT_HEALTH_NBR", DataTypes.Numeric, 10);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F010_PAT_MSTR.PAT_VERSION_CD", DataTypes.Character, 2);
                AddControl(ReportSection.FOOTING_AT, "PAT_BIRTH_DATE", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.REJECTED_CLAIMS.CLAIM_NBR", DataTypes.Character, 10);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F002_CLAIMS_MSTR.CLMHDR_AGENT_CD", DataTypes.Numeric, 1);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F002_CLAIMS_MSTR.CLMHDR_LOC", DataTypes.Character, 4);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F010_PAT_MSTR.PAT_DATE_LAST_ELIG_MAILING", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "D_DAYS_OLD", DataTypes.Numeric, 6);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F002_CLAIMS_MSTR.CLMHDR_SERV_DATE", DataTypes.Numeric, 8);
                AddControl(ReportSection.REPORT, "PAT_SURNAME", DataTypes.Character, 25);
                AddControl(ReportSection.REPORT, "PAT_GIVEN_NAME", DataTypes.Character, 17);
                AddControl(ReportSection.REPORT, "CLMHDR_PAT_OHIP_ID_OR_CHART", DataTypes.Character, 16);
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        #endregion

        #region " Renaissance Precompiler Generated Code "

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 6/29/2017 2:19:24 PM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "X_PAT_NAME":
                    return Common.StringToField(X_PAT_NAME(), intSize);

                case "INDEXED.REJECTED_CLAIMS.MESS_CODE":
                    return Common.StringToField(rdrREJECTED_CLAIMS.GetString("MESS_CODE"));

                case "INDEXED.F010_PAT_MSTR.PAT_HEALTH_NBR":
                    return rdrF010_PAT_MSTR.GetNumber("PAT_HEALTH_NBR").ToString();

                case "INDEXED.F010_PAT_MSTR.PAT_VERSION_CD":
                    return Common.StringToField(rdrF010_PAT_MSTR.GetString("PAT_VERSION_CD"));

                case "PAT_BIRTH_DATE":
                    return F010_PAT_MSTR_PAT_BIRTH_DATE().ToString();

                case "INDEXED.REJECTED_CLAIMS.CLAIM_NBR":
                    return Common.StringToField(rdrREJECTED_CLAIMS.GetString("CLAIM_NBR"));

                case "INDEXED.F002_CLAIMS_MSTR.CLMHDR_AGENT_CD":
                    return rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_AGENT_CD").ToString();

                case "INDEXED.F002_CLAIMS_MSTR.CLMHDR_LOC":
                    return Common.StringToField(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_LOC"));

                case "INDEXED.F010_PAT_MSTR.PAT_DATE_LAST_ELIG_MAILING":
                    return rdrF010_PAT_MSTR.GetNumber("PAT_DATE_LAST_ELIG_MAILING").ToString();

                case "D_DAYS_OLD":
                    return D_DAYS_OLD().ToString();

                case "INDEXED.F002_CLAIMS_MSTR.CLMHDR_SERV_DATE":
                    return rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_SERV_DATE").ToString();

                case "PAT_SURNAME":
                    return Common.StringToField(F010_PAT_MSTR_PAT_SURNAME(), intSize);

                case "PAT_GIVEN_NAME":
                    return Common.StringToField(F010_PAT_MSTR_PAT_GIVEN_NAME(), intSize);

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
                Access_U085B();
                while (rdrU085B.Read())
                {
                    Link_F002_CLAIMS_MSTR();
                    while (rdrF002_CLAIMS_MSTR.Read())
                    {
                        Link_F010_PAT_MSTR();
                        while(rdrF010_PAT_MSTR.Read())
                        {
                            Link_REJECTED_CLAIMS();
                            while (rdrREJECTED_CLAIMS.Read())
                            {
                                Link_U020C_OHIP_RUN_DATE();
                                while(rdrU020C_OHIP_RUN_DATE.Read())
                                {
                                    Link_SECOND_LAST_OHIP_RUNDATE();
                                    while (rdrSECOND_LAST_OHIP_RUNDATE.Read())
                                    {
                                        WriteData();
                                    }
                                    rdrSECOND_LAST_OHIP_RUNDATE.Close();
                                }
                                rdrU020C_OHIP_RUN_DATE.Close();
                            }
                            rdrREJECTED_CLAIMS.Close();
                        }
                        rdrF010_PAT_MSTR.Close();
                    }
                    rdrF002_CLAIMS_MSTR.Close();
                }
                rdrU085B.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrU085B != null))
            {
                rdrU085B.Close();
                rdrU085B = null;
            }

            if ((rdrF002_CLAIMS_MSTR != null))
            {
                rdrF002_CLAIMS_MSTR.Close();
                rdrF002_CLAIMS_MSTR = null;
            }

            if ((rdrF010_PAT_MSTR != null))
            {
                rdrF010_PAT_MSTR.Close();
                rdrF010_PAT_MSTR = null;
            }

            if ((rdrREJECTED_CLAIMS != null))
            {
                rdrREJECTED_CLAIMS.Close();
                rdrREJECTED_CLAIMS = null;
            }

            if ((rdrU020C_OHIP_RUN_DATE != null))
            {
                rdrU020C_OHIP_RUN_DATE.Close();
                rdrU020C_OHIP_RUN_DATE = null;
            }

            if ((rdrSECOND_LAST_OHIP_RUNDATE != null))
            {
                rdrSECOND_LAST_OHIP_RUNDATE.Close();
                rdrSECOND_LAST_OHIP_RUNDATE = null;
            }
        }

        #endregion

        #endregion
    }
}
