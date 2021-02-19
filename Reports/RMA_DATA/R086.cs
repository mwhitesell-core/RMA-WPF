//  program: r086 -  
//  purpose: create listing for confidential/stale dates and 2 letters sent
//  (patient requires direct contact)
//  93/04/21 AGK       SMS 141 (ORIGINAL)
//  93/04/22        YASEMIN   MODIFY
//  CHECK LAST MAILING > 10 DAYS OLD
//  93/05/21 M.CHAN   - ADD THE MESS CODE CHECK IN THE
//  SELECTION CRITERIA
//  93/06/04        YASEMIN   - ADD REFERENCE FILED COLUMN
//  94/02/22 M. CHAN   - PDR 594
//  - USE LAST MAILING > 21 DAYS OLD
//  INSTEAD OF 10 DAYS
//  1999/jan/31 B.E.  - y2k
//  2003/apr/30 M.C.  - include clmhdr-confidential-flage = `R` in 
//  the selection criteria to be the same as `Y`
//  as Yasemin requested
//  2003/dec/15 A.A.  - alpha doctor nbr
//  2009/Apr/14 Yas   - As per Maria - take out doc name and reference column
//  Add Health#, version,birthdate,location code, number of days old and service date
//  prdecimal at patient             
//  2015/Jun/17 MC1  - user wants decimal spacing
//  2016/Jan/23 MC2  - Helena requested to change the stale date from 150 to 120 days
//  2017/Feb/27 MC3              - Yasemin to change the sort statement as
//  sort on d-status on d-patient-name on d-days-old on claim-nbr
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
    public class R086 : BaseRDLClass
    {
        protected const string REPORT_NAME = "R086";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrREJECTED_CLAIMS = new Reader();
        private Reader rdrF002_CLAIMS_MSTR = new Reader();
        private Reader rdrF010_PAT_MSTR = new Reader();
        private Reader rdrF020_DOCTOR_MSTR = new Reader();
        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                //  Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;
                Sort = "D_STATUS ASC, D_PATIENT_NAME ASC, D_DAYS_OLD DESC, CLAIM_NBR DESC";
                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return ReportData;
        }
        private void Access_REJECTED_CLAIMS()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("CLAIM_NBR, ");
            strSQL.Append("CLMHDR_PAT_OHIP_ID_OR_CHART, ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("CLMHDR_LOC ");
            strSQL.Append("FROM INDEXED.REJECTED_CLAIMS ");

            strSQL.Append(Choose());

            rdrREJECTED_CLAIMS.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
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
            strSQL.Append("CLMHDR_CONFIDENTIAL_FLAG, ");
            strSQL.Append("CLMHDR_REFERENCE ");
            strSQL.Append("FROM INDEXED.F002_CLAIMS_MSTR_HDR ");
            strSQL.Append("WHERE ");
            strSQL.Append("KEY_CLM_TYPE = ").Append(Common.StringToField("B"));
            strSQL.Append(" AND KEY_CLM_BATCH_NBR = ").Append(Common.StringToField(QDesign.Substring(rdrREJECTED_CLAIMS.GetString("CLAIM_NBR"), 1, 8)));
            strSQL.Append(" AND KEY_CLM_CLAIM_NBR = ").Append(QDesign.NConvert(QDesign.Substring(rdrREJECTED_CLAIMS.GetString("CLAIM_NBR"), 9, 2)));
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
            strSQL.Append("PAT_NO_OF_LETTER_SENT, ");
            strSQL.Append("PAT_MESS_CODE, ");
            strSQL.Append("PAT_SURNAME_FIRST3, ");
            strSQL.Append("PAT_SURNAME_LAST22, ");
            strSQL.Append("PAT_GIVEN_NAME_FIRST1, ");
            strSQL.Append("FILLER3, ");
            strSQL.Append("PAT_HEALTH_NBR, ");
            strSQL.Append("PAT_VERSION_CD, ");
            strSQL.Append("PAT_BIRTH_DATE_YY, ");
            strSQL.Append("PAT_BIRTH_DATE_MM, ");
            strSQL.Append("PAT_BIRTH_DATE_DD ");
            strSQL.Append("FROM INDEXED.F010_PAT_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("PAT_I_KEY = ").Append(Common.StringToField(QDesign.Substring(rdrREJECTED_CLAIMS.GetString("CLMHDR_PAT_OHIP_ID_OR_CHART"), 1, 1)));
            strSQL.Append(" AND PAT_CON_NBR = ").Append(QDesign.NConvert(QDesign.Substring(rdrREJECTED_CLAIMS.GetString("CLMHDR_PAT_OHIP_ID_OR_CHART"), 2, 2)));
            strSQL.Append(" AND PAT_I_NBR = ").Append(QDesign.NConvert(QDesign.Substring(rdrREJECTED_CLAIMS.GetString("CLMHDR_PAT_OHIP_ID_OR_CHART"), 4, 12)));
            strSQL.Append(" AND FILLER4 = ").Append(Common.StringToField(QDesign.Substring(rdrREJECTED_CLAIMS.GetString("CLMHDR_PAT_OHIP_ID_OR_CHART"), 16, 1)));

            rdrF010_PAT_MSTR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
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
            strSQL.Append("DOC_NBR = ").Append(Common.StringToField(rdrREJECTED_CLAIMS.GetString("DOC_NBR")));

            rdrF020_DOCTOR_MSTR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
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
            if (((QDesign.NULL(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_CONFIDENTIAL_FLAG")) == "Y")
                || (QDesign.NULL(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_CONFIDENTIAL_FLAG")) == "R")
                || ((QDesign.NULL(D_TEST_DATE()) > QDesign.NULL(21d)) && (rdrF010_PAT_MSTR.GetNumber("PAT_NO_OF_LETTER_SENT") >= 2))
                || (QDesign.NULL(D_TEST_SERV()) > QDesign.NULL(120d)))
                && (QDesign.NULL(rdrF010_PAT_MSTR.GetString("PAT_MESS_CODE")) != QDesign.NULL(" ")))
            {
                blnSelected = true;
            }

            return blnSelected;
        }

        private decimal D_TEST_SERV()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_SERV_DATE")) > QDesign.NULL(0d)))
                {
                    decReturnValue = (QDesign.Days(QDesign.SysDate(ref m_cnnQUERY)) - QDesign.Days(rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_SERV_DATE")));
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal D_TEST_DATE()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrF010_PAT_MSTR.GetNumber("PAT_DATE_LAST_ELIG_MAILING")) > QDesign.NULL(0d)))
                {
                    decReturnValue = (QDesign.Days(QDesign.SysDate(ref m_cnnQUERY)) - QDesign.Days(rdrF010_PAT_MSTR.GetNumber("PAT_DATE_LAST_ELIG_MAILING")));
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private string D_STATUS()
        {
            string strReturnValue = string.Empty;
            try
            {
                if (((QDesign.NULL(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_CONFIDENTIAL_FLAG")) == "Y")
                            || (QDesign.NULL(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_CONFIDENTIAL_FLAG")) == "R")))
                {
                    strReturnValue = "C";
                }
                else if ((QDesign.NULL(D_TEST_SERV()) > QDesign.NULL(120d)))
                {
                    strReturnValue = "S";
                }
                else if ((rdrF010_PAT_MSTR.GetNumber("PAT_NO_OF_LETTER_SENT") >= 2))
                {
                    strReturnValue = "I";
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private decimal D_DAYS_OLD()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = (QDesign.Days(QDesign.SysDate(ref m_cnnQUERY)) - QDesign.Days(rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_SERV_DATE")));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private string D_DOCTOR_NAME()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = (F020_DOCTOR_MSTR_DOC_INITS() + (", " + rdrF020_DOCTOR_MSTR.GetString("DOC_NAME")));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string D_PATIENT_NAME()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = QDesign.Pack((D_NEW_SURNAME() + (", " + D_NEW_GIVEN_NAME())));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
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
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private string D_NEW_GIVEN_NAME()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = rdrF010_PAT_MSTR.GetString("PAT_GIVEN_NAME_FIRST1") + rdrF010_PAT_MSTR.GetString("FILLER3");
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string D_NEW_SURNAME()
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

        private string F020_DOCTOR_MSTR_DOC_INITS()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = (rdrF020_DOCTOR_MSTR.GetString("DOC_INIT1")
                            + (rdrF020_DOCTOR_MSTR.GetString("DOC_INIT2") + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT3")));
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
                AddControl(ReportSection.FOOTING_AT, "INDEXED.REJECTED_CLAIMS.CLAIM_NBR", DataTypes.Character, 10);
                AddControl(ReportSection.FOOTING_AT, "D_PATIENT_NAME", DataTypes.Character, 30);
                AddControl(ReportSection.FOOTING_AT, "D_STATUS", DataTypes.Character, 1);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F010_PAT_MSTR.PAT_MESS_CODE", DataTypes.Character, 3);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F010_PAT_MSTR.PAT_HEALTH_NBR", DataTypes.Numeric, 10);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F010_PAT_MSTR.PAT_VERSION_CD", DataTypes.Character, 2);
                AddControl(ReportSection.FOOTING_AT, "PAT_BIRTH_DATE", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.REJECTED_CLAIMS.CLMHDR_LOC", DataTypes.Character, 4);
                AddControl(ReportSection.FOOTING_AT, "D_DAYS_OLD", DataTypes.Numeric, 6);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F002_CLAIMS_MSTR.CLMHDR_REFERENCE", DataTypes.Character, 11);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F002_CLAIMS_MSTR.CLMHDR_SERV_DATE", DataTypes.Numeric, 8);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-05-14 10:20:16 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "INDEXED.REJECTED_CLAIMS.CLAIM_NBR":
                    return Common.StringToField(rdrREJECTED_CLAIMS.GetString("CLAIM_NBR"));

                case "D_PATIENT_NAME":
                    return Common.StringToField(D_PATIENT_NAME(), intSize);

                case "D_STATUS":
                    return Common.StringToField(D_STATUS(), intSize);

                case "INDEXED.F010_PAT_MSTR.PAT_MESS_CODE":
                    return Common.StringToField(rdrF010_PAT_MSTR.GetString("PAT_MESS_CODE"));

                case "INDEXED.F010_PAT_MSTR.PAT_HEALTH_NBR":
                    return rdrF010_PAT_MSTR.GetNumber("PAT_HEALTH_NBR").ToString();

                case "INDEXED.F010_PAT_MSTR.PAT_VERSION_CD":
                    return Common.StringToField(rdrF010_PAT_MSTR.GetString("PAT_VERSION_CD"));

                case "PAT_BIRTH_DATE":
                    return Common.StringToField(F010_PAT_MSTR_PAT_BIRTH_DATE().ToString());

                case "INDEXED.REJECTED_CLAIMS.CLMHDR_LOC":
                    return Common.StringToField(rdrREJECTED_CLAIMS.GetString("CLMHDR_LOC"));

                case "D_DAYS_OLD":
                    return D_DAYS_OLD().ToString();

                case "INDEXED.F002_CLAIMS_MSTR.CLMHDR_REFERENCE":
                    return Common.StringToField(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_REFERENCE"));

                case "INDEXED.F002_CLAIMS_MSTR.CLMHDR_SERV_DATE":
                    return rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_SERV_DATE").ToString();

                default:
                    return string.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                Access_REJECTED_CLAIMS();
                while (rdrREJECTED_CLAIMS.Read())
                {
                    Link_F002_CLAIMS_MSTR();
                    while (rdrF002_CLAIMS_MSTR.Read())
                    {
                        Link_F010_PAT_MSTR();
                        while (rdrF010_PAT_MSTR.Read())
                        {
                            Link_F020_DOCTOR_MSTR();
                            while (rdrF020_DOCTOR_MSTR.Read())
                            {
                                WriteData();
                            }

                            rdrF020_DOCTOR_MSTR.Close();
                        }
                        rdrF010_PAT_MSTR.Close();
                    }
                    rdrF002_CLAIMS_MSTR.Close();
                }
                rdrREJECTED_CLAIMS.Close();
            }
            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrREJECTED_CLAIMS == null))
            {
                rdrREJECTED_CLAIMS.Close();
                rdrREJECTED_CLAIMS = null;
            }

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

            if (!(rdrF020_DOCTOR_MSTR == null))
            {
                rdrF020_DOCTOR_MSTR.Close();
                rdrF020_DOCTOR_MSTR = null;
            }
        }
    }
}
