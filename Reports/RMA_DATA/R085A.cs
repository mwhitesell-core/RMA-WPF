//  Program: r085a 
//  Purpose: create subfile of selected patients for
//  all programs related to sending letters to
//  patients for wrong health card info
//  98/dec/10 B.E. - created from access/selection logic in r085/86/87/u085
//  1999/May/16 S.B. - Y2K checked. Already done.
//  2000/may/29 B.E. - removed checking of confidential field and moved to 
//  r085b program.  This was required since the write
//  to the rejected-claims file may be from a confidential
//  claim, however the patient may have other non-confid.
//  claims for which they may be contacted.  By moving the
//  checking of this field to the r085b program the
//  individual claims can be tested to see if they can
//  appear in the letter. Note that if ALL claims are
//  confidential, this program will write a driver
//  record to the subfile however r085b will not build
//  a record complex with ANY claims and therefore
//  no letter will be generated.
//  2000/jun/28 B.E. - changed name of subfile from r085 to r085a to meet
//  programming standards
//  2003/dec/15  - alpha doctor nbr
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
    public class R085A : BaseRDLClass
    {
        protected const string REPORT_NAME = "R085A";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrR085A = new Reader();
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
                //  Create Subfile.
                SubFile = true;
                SubFileName = "R085A";
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
        private void Access_REJECTED_CLAIMS()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("CLAIM_NBR, ");
            strSQL.Append("CLMHDR_PAT_OHIP_ID_OR_CHART, ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("CLMHDR_LOC, ");
            strSQL.Append("MESS_CODE ");
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
            strSQL.Append("KEY_CLM_ADJ_NBR ");
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
            strSQL.Append("PAT_MESS_CODE ");
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
            strSQL.Append("DOC_NBR ");
            strSQL.Append("FROM INDEXED.F020_DOCTOR_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_NBR = ").Append(Common.StringToField(rdrREJECTED_CLAIMS.GetString("DOC_NBR")));

            rdrF020_DOCTOR_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
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
            if ((QDesign.NULL(rdrF010_PAT_MSTR.GetNumber("PAT_DATE_LAST_ELIG_MAILING")) == QDesign.NULL(0d)
                        || QDesign.NULL(rdrF010_PAT_MSTR.GetNumber("PAT_DATE_LAST_ELIG_MAILING")) == QDesign.NULL(19160100d)
                        || (QDesign.NULL(D_TEST_DATE()) > QDesign.NULL(35d)
                        && QDesign.NULL(rdrF010_PAT_MSTR.GetNumber("PAT_NO_OF_LETTER_SENT")) < QDesign.NULL(2d)))
                        && QDesign.NULL(rdrF010_PAT_MSTR.GetString("PAT_MESS_CODE")) != QDesign.NULL(" "))
            {
                blnSelected = true;
            }

            return blnSelected;
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
        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.SUMMARY, "INDEXED.REJECTED_CLAIMS.CLAIM_NBR", DataTypes.Character, 10);
                AddControl(ReportSection.SUMMARY, "INDEXED.REJECTED_CLAIMS.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.SUMMARY, "INDEXED.REJECTED_CLAIMS.CLMHDR_PAT_OHIP_ID_OR_CHART", DataTypes.Character, 16);
                AddControl(ReportSection.SUMMARY, "INDEXED.REJECTED_CLAIMS.CLMHDR_LOC", DataTypes.Character, 4);
                AddControl(ReportSection.SUMMARY, "INDEXED.REJECTED_CLAIMS.MESS_CODE", DataTypes.Character, 3);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-05-14 10:20:58 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "INDEXED.REJECTED_CLAIMS.CLAIM_NBR":
                    return Common.StringToField(rdrREJECTED_CLAIMS.GetString("CLAIM_NBR"));

                case "INDEXED.REJECTED_CLAIMS.DOC_NBR":
                    return Common.StringToField(rdrREJECTED_CLAIMS.GetString("DOC_NBR"));

                case "INDEXED.REJECTED_CLAIMS.CLMHDR_PAT_OHIP_ID_OR_CHART":
                    return Common.StringToField(rdrREJECTED_CLAIMS.GetString("CLMHDR_PAT_OHIP_ID_OR_CHART"));

                case "INDEXED.REJECTED_CLAIMS.CLMHDR_LOC":
                    return Common.StringToField(rdrREJECTED_CLAIMS.GetString("CLMHDR_LOC"));

                case "INDEXED.REJECTED_CLAIMS.MESS_CODE":
                    return Common.StringToField(rdrREJECTED_CLAIMS.GetString("MESS_CODE"));

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
