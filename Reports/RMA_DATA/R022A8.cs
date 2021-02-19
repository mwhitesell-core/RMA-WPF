//
//	((C)) Dyad Technologies
//
//    PROGRAM PURPOSE : SELECT RECORDS FROM F087-DTL FOR MANUAL REVIEW REPORT
//
//    MODIFICATION HISTORY
// DATE WHO          DESCRIPTION
// 03/nov/13 M.C.        - clone from original r022a7.qzs
// 03/nov/13 M.C.    - extract rejected details from f087-dtl into
// the subfile r022a7_desc_reject
//
// 04/Jan/08 M.C.    - alpha doc nbr
// 04/Jan/20 M.C.    - pick up the initial reject details, a claim
//			  could have duplicate rejects from each submission
//			- add the sort statement and write the subfile at control break
// 04/May/06 M.C.    - since we have consolidated records from manual-rejected-claims-hist
//			  into f087-submitted-rejected-claims-hdr/dtl, Yas/users requested to
//			  exclude the old records from manual-rejected-claims-hist with
// edt-process-date 19000101
// 05/dec/05 M.C.    - include patient name in r022a7_desc_reject subfile
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
    public class R022A8 : BaseRDLClass
    {
        protected const string REPORT_NAME = "R022A8";
        protected const bool REPORT_HAS_PARAMETERS = false;

        private Reader rdrU022A4 = new Reader();
        private Reader rdrF002_CLAIMS_MSTR_HDR = new Reader();
        private Reader rdrF087_SUBMITTED_REJECTED_CLAIMS_DTL = new Reader();

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
                SubFileName = "R022A7_DESC_REJECT";
                SubFileType = SubFileType.Keep;
                SubFileAppend = true;
                SubFileAT = "EDT_OMA_SERVICE_CD_AND_SUFFIX";

                Sort = "CLMHDR_CLAIM_ID ASC, EDT_SERVICE_DATE ASC, EDT_OMA_SERVICE_CD_AND_SUFFIX ASC, EDT_PROCESS_DATE DESC";

                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return ReportData;
        }
        private void Access_U022A4()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("CLMHDR_CLAIM_ID, ");
            strSQL.Append("PAT_HEALTH_NBR, ");
            strSQL.Append("W_PAT_OHIP_MMYY, ");
            strSQL.Append("BATCTRL_AGENT_CD, ");
            strSQL.Append("BATCTRL_DOC_NBR_OHIP, ");
            strSQL.Append("CLMHDR_DOC_SPEC_CD, ");
            strSQL.Append("CLMDTL_SV_DATE, ");
            strSQL.Append("PAT_PROV_CD, ");
            strSQL.Append("PAT_SURNAME, ");
            strSQL.Append("PAT_GIVEN_NAME, ");
            strSQL.Append("PAT_BIRTH_DATE, ");
            strSQL.Append("PAT_VERSION_CD, ");
            strSQL.Append("TRANSLATED_GROUP_NBR, ");
            strSQL.Append("CLMHDR_LOC ");
            strSQL.Append("FROM TEMPORARYDATA.U022A4 ");

            strSQL.Append(Choose());

            rdrU022A4.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
            strSQL = null;
        }

        private void Link_F002_CLAIMS_MSTR_HDR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("CLMHDR_BATCH_NBR, ");
            strSQL.Append("CLMHDR_CLAIM_NBR, ");
            strSQL.Append("CLMHDR_DATE_PERIOD_END, ");
            strSQL.Append("CLMHDR_ADJ_OMA_CD, ");
            strSQL.Append("CLMHDR_ADJ_OMA_SUFF, ");
            strSQL.Append("CLMHDR_ADJ_ADJ_NBR ");
            strSQL.Append("FROM INDEXED.F002_CLAIMS_MSTR_HDR ");
            strSQL.Append("WHERE ");
            strSQL.Append("KEY_CLM_TYPE = 'B' ");
            strSQL.Append("AND KEY_CLM_BATCH_NBR = ").Append(Common.StringToField(QDesign.Substring(rdrU022A4.GetString("CLMHDR_CLAIM_ID"), 1, 8)));
            strSQL.Append(" AND KEY_CLM_CLAIM_NBR = ").Append(QDesign.NConvert(QDesign.Substring(rdrU022A4.GetString("CLMHDR_CLAIM_ID"), 9, 2)));
            strSQL.Append(" AND KEY_CLM_SERV_CODE = '00000' ");
            strSQL.Append(" AND KEY_CLM_ADJ_NBR = '0' ");

            rdrF002_CLAIMS_MSTR_HDR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        private void Link_F087_SUBMITTED_REJECTED_CLAIMS_DTL()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("EDT_PROCESS_DATE, ");
            strSQL.Append("EDT_SERVICE_DATE, ");
            strSQL.Append("EDT_OMA_SERVICE_CD_AND_SUFFIX, ");
            strSQL.Append("EDT_NBR_SERV, ");
            strSQL.Append("EDT_AMOUNT_SUBMITTED, ");
            strSQL.Append("EDT_DTL_DIAG_CD, ");
            strSQL.Append("EDT_DTL_ERR_CD_1, ");
            strSQL.Append("EDT_DTL_ERR_CD_2, ");
            strSQL.Append("EDT_DTL_ERR_CD_3, ");
            strSQL.Append("EDT_DTL_ERR_CD_4, ");
            strSQL.Append("EDT_DTL_ERR_CD_5 ");
            strSQL.Append("FROM INDEXED.F087_SUBMITTED_REJECTED_CLAIMS_DTL ");
            strSQL.Append("WHERE ");
            strSQL.Append("CLMHDR_BATCH_NBR = ").Append(Common.StringToField(rdrF002_CLAIMS_MSTR_HDR.GetString("CLMHDR_BATCH_NBR")));
            strSQL.Append(" AND CLMHDR_CLAIM_NBR = ").Append(rdrF002_CLAIMS_MSTR_HDR.GetNumber("CLMHDR_CLAIM_NBR"));
            strSQL.Append(" AND PED = ").Append(rdrF002_CLAIMS_MSTR_HDR.GetNumber("CLMHDR_DATE_PERIOD_END"));

            rdrF087_SUBMITTED_REJECTED_CLAIMS_DTL.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
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

            if (rdrF087_SUBMITTED_REJECTED_CLAIMS_DTL.GetNumber("EDT_PROCESS_DATE") != 0)
            {
                blnSelected = true;
            }

            return blnSelected;
        }

        private string W_HEALTH_NBR()
        {
            string strReturnValue = string.Empty;

            try
            {
                if (rdrU022A4.GetNumber("PAT_HEALTH_NBR") != 0)
                {
                    strReturnValue = QDesign.ASCII(rdrU022A4.GetNumber("PAT_HEALTH_NBR"), 10);
                }
                else
                {
                    strReturnValue = rdrU022A4.GetString("W_PAT_OHIP_MMYY");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string W_WCB()
        {
            string strReturnValue = string.Empty;

            try
            {
                if (rdrU022A4.GetNumber("BATCTRL_AGENT_CD") == 2)
                {
                    strReturnValue = "Y";
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
    
        private string X_TYPE()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = "R";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return strReturnValue;
        }
    
        private string X_CLMDTL_DESC()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = " ";
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
                AddControl(ReportSection.REPORT, "W_HEALTH_NBR", DataTypes.Character, 12);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U22A4.TRANSLATED_GROUP_NBR", DataTypes.Character, 4);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U22A4.BATCTRL_DOC_NBR_OHIP", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U22A4.CLMHDR_DOC_SPEC_CD", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U22A4.CLMHDR_CLAIM_ID", DataTypes.Character, 16);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U22A4.PAT_PROV_CD", DataTypes.Character, 2);
                AddControl(ReportSection.REPORT, "W_WCB", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "TEMPORARY.U22A4.CLMDTL_SV_DATE", DataTypes.Character, 8);
                AddControl(ReportSection.REPORT, "X_CLMDTL_DESC", DataTypes.Character, 22);
                AddControl(ReportSection.REPORT, "X_TYPE", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "INDEXED.F087_SUBMITTED_REJECTED_CLAIMS_DTL.EDT_OMA_SERVICE_CD_AND_SUFFIX", DataTypes.Character, 5);
                AddControl(ReportSection.REPORT, "INDEXED.F087_SUBMITTED_REJECTED_CLAIMS_DTL.EDT_SERVICE_DATE", DataTypes.Numeric, 8);
                AddControl(ReportSection.REPORT, "INDEXED.F087_SUBMITTED_REJECTED_CLAIMS_DTL.EDT_NBR_SERV", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "INDEXED.F087_SUBMITTED_REJECTED_CLAIMS_DTL.EDT_AMOUNT_SUBMITTED", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "INDEXED.F087_SUBMITTED_REJECTED_CLAIMS_DTL.EDT_DTL_DIAG_CD", DataTypes.Character, 4);
                AddControl(ReportSection.REPORT, "INDEXED.F087_SUBMITTED_REJECTED_CLAIMS_DTL.EDT_DTL_ERR_CD_1", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "INDEXED.F087_SUBMITTED_REJECTED_CLAIMS_DTL.EDT_DTL_ERR_CD_2", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "INDEXED.F087_SUBMITTED_REJECTED_CLAIMS_DTL.EDT_DTL_ERR_CD_3", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "INDEXED.F087_SUBMITTED_REJECTED_CLAIMS_DTL.EDT_DTL_ERR_CD_4", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "INDEXED.F087_SUBMITTED_REJECTED_CLAIMS_DTL.EDT_DTL_ERR_CD_5", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "INDEXED.F087_SUBMITTED_REJECTED_CLAIMS_DTL.EDT_PROCESS_DATE", DataTypes.Numeric, 8);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U22A4.PAT_SURNAME", DataTypes.Character, 25);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U22A4.PAT_GIVEN_NAME", DataTypes.Character, 17);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U22A4.PAT_BIRTH_DATE", DataTypes.Numeric, 8);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U22A4.PAT_VERSION_CD", DataTypes.Character, 2);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U22A4.CLMHDR_LOC", DataTypes.Character, 4);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
    
        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-05-11 6:02:21 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "W_HEALTH_NBR":
                    return Common.StringToField(W_HEALTH_NBR(), intSize);

                case "TEMPORARYDATA.U22A4.TRANSLATED_GROUP_NBR":
                    return Common.StringToField(rdrU022A4.GetString("TRANSLATED_GROUP_NBR"));

                case "TEMPORARYDATA.U22A4.BATCTRL_DOC_NBR_OHIP":
                    return rdrU022A4.GetNumber("BATCTRL_DOC_NBR_OHIP").ToString();

                case "TEMPORARYDATA.U22A4.CLMHDR_DOC_SPEC_CD":
                    return rdrU022A4.GetNumber("CLMHDR_DOC_SPEC_CD").ToString();

                case "TEMPORARYDATA.U22A4.CLMHDR_CLAIM_ID":
                    return Common.StringToField(rdrU022A4.GetString("CLMHDR_CLAIM_ID"));

                case "TEMPORARYDATA.U22A4.PAT_PROV_CD":
                    return Common.StringToField(rdrU022A4.GetString("PAT_PROV_CD"));

                case "W_WCB":
                    return Common.StringToField(W_WCB(), intSize);

                case "TEMPORARY.U22A4.CLMDTL_SV_DATE":
                    return rdrU022A4.GetNumber("CLMDTL_SV_DATE").ToString();

                case "X_CLMDTL_DESC":
                    return Common.StringToField(X_CLMDTL_DESC(), intSize);

                case "X_TYPE":
                    return Common.StringToField(X_TYPE(), intSize);

                case "INDEXED.F087_SUBMITTED_REJECTED_CLAIMS_DTL.EDT_OMA_SERVICE_CD_AND_SUFFIX":
                    return Common.StringToField(rdrF087_SUBMITTED_REJECTED_CLAIMS_DTL.GetString("EDT_OMA_SERVICE_CD_AND_SUFFIX"));

                case "INDEXED.F087_SUBMITTED_REJECTED_CLAIMS_DTL.EDT_SERVICE_DATE":
                    return rdrF087_SUBMITTED_REJECTED_CLAIMS_DTL.GetNumber("EDT_SERVICE_DATE").ToString();

                case "INDEXED.F087_SUBMITTED_REJECTED_CLAIMS_DTL.EDT_NBR_SERV":
                    return rdrF087_SUBMITTED_REJECTED_CLAIMS_DTL.GetNumber("EDT_NBR_SERV").ToString();

                case "INDEXED.F087_SUBMITTED_REJECTED_CLAIMS_DTL.EDT_AMOUNT_SUBMITTED":
                    return rdrF087_SUBMITTED_REJECTED_CLAIMS_DTL.GetNumber("EDT_AMOUNT_SUBMITTED").ToString();

                case "INDEXED.F087_SUBMITTED_REJECTED_CLAIMS_DTL.EDT_DTL_DIAG_CD":
                    return Common.StringToField(rdrF087_SUBMITTED_REJECTED_CLAIMS_DTL.GetString("EDT_DTL_DIAG_CD"));

                case "INDEXED.F087_SUBMITTED_REJECTED_CLAIMS_DTL.EDT_DTL_ERR_CD_1":
                    return Common.StringToField(rdrF087_SUBMITTED_REJECTED_CLAIMS_DTL.GetString("EDT_DTL_ERR_CD_1"));

                case "INDEXED.F087_SUBMITTED_REJECTED_CLAIMS_DTL.EDT_DTL_ERR_CD_2":
                    return Common.StringToField(rdrF087_SUBMITTED_REJECTED_CLAIMS_DTL.GetString("EDT_DTL_ERR_CD_2"));

                case "INDEXED.F087_SUBMITTED_REJECTED_CLAIMS_DTL.EDT_DTL_ERR_CD_3":
                    return Common.StringToField(rdrF087_SUBMITTED_REJECTED_CLAIMS_DTL.GetString("EDT_DTL_ERR_CD_3"));

                case "INDEXED.F087_SUBMITTED_REJECTED_CLAIMS_DTL.EDT_DTL_ERR_CD_4":
                    return Common.StringToField(rdrF087_SUBMITTED_REJECTED_CLAIMS_DTL.GetString("EDT_DTL_ERR_CD_4"));

                case "INDEXED.F087_SUBMITTED_REJECTED_CLAIMS_DTL.EDT_DTL_ERR_CD_5":
                    return Common.StringToField(rdrF087_SUBMITTED_REJECTED_CLAIMS_DTL.GetString("EDT_DTL_ERR_CD_5"));

                case "INDEXED.F087_SUBMITTED_REJECTED_CLAIMS_DTL.EDT_PROCESS_DATE":
                    return rdrF087_SUBMITTED_REJECTED_CLAIMS_DTL.GetNumber("EDT_PROCESS_DATE").ToString();

                case "TEMPORARYDATA.U22A4.PAT_SURNAME":
                    return Common.StringToField(rdrU022A4.GetString("PAT_SURNAME"));

                case "TEMPORARYDATA.U22A4.PAT_GIVEN_NAME":
                    return Common.StringToField(rdrU022A4.GetString("PAT_GIVEN_NAME"));

                case "TEMPORARYDATA.U22A4.PAT_BIRTH_DATE":
                    return rdrU022A4.GetNumber("PAT_BIRTH_DATE").ToString();

                case "TEMPORARYDATA.U22A4.PAT_VERSION_CD":
                    return Common.StringToField(rdrU022A4.GetString("PAT_VERSION_CD"));

                case "TEMPORARYDATA.U22A4.CLMHDR_LOC":
                    return Common.StringToField(rdrU022A4.GetString("CLMHDR_LOC"));

                default:
                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_U022A4();
                while (rdrU022A4.Read())
                {
                    Link_F002_CLAIMS_MSTR_HDR();
                    while (rdrF002_CLAIMS_MSTR_HDR.Read())
                    {
                        Link_F087_SUBMITTED_REJECTED_CLAIMS_DTL();
                        while (rdrF087_SUBMITTED_REJECTED_CLAIMS_DTL.Read())
                        {
                            WriteData();
                        }
                        rdrF087_SUBMITTED_REJECTED_CLAIMS_DTL.Close();
                    }
                    rdrF002_CLAIMS_MSTR_HDR.Close();
                }
                rdrU022A4.Close();
            }
            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrU022A4 == null))
            {
                rdrU022A4.Close();
                rdrU022A4 = null;
            }
        
            if (!(rdrF002_CLAIMS_MSTR_HDR == null))
            {
                rdrF002_CLAIMS_MSTR_HDR.Close();
                rdrF002_CLAIMS_MSTR_HDR = null;
            }
        
            if (!(rdrF087_SUBMITTED_REJECTED_CLAIMS_DTL == null))
            {
                rdrF087_SUBMITTED_REJECTED_CLAIMS_DTL.Close();
                rdrF087_SUBMITTED_REJECTED_CLAIMS_DTL = null;
            }
        }
    }
}
