//  #> program-id.     r022a9.qzs
//  ((C)) Dyad Technologies
//  PROGRAM PURPOSE : prdecimal program for manual review report
//  MODIFICATION HISTORY
//  DATE   WHO          DESCRIPTION
//  03/nov/13 M.C.        - clone from the original r022a7.qzs
//  03/nov/13 M.C. - generate the new manual review reports with additional
//  fields and rejected detail     
//  04/jan/08 M.C. - alpha doc nbr
//  04/aug/17 M.C. - add edt-process-date to the sort so that the earlier 
//  process date is printed on the report
//  05/dec/05 M.C. - include patient name on the report     
//  08/Apr/10 yas         - add physician name to the report
//  and sort by clinic by physician name
//  08/Apr/21 M.C.        - link doc-nbr to f020-doctor-mstr instead of doc-ohip-nbr
//  08/May/07 yas.        - go back to original srt group/claim nbr - requested by                          MOH                 
//  2008/04/21 - MC - use doc-nbr to link to f020 file
//  link batctrl-doc-nbr-ohip                     &
//  to doc-ohip-nbr of f020-doctor-mstr opt
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
    public class R022A9 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R022A9";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrR022A7_DESC_REJECT = new Reader();
        private Reader rdrF020_DOCTOR_MSTR = new Reader();

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
                Sort = "CLMHDR_CLAIM_ID ASC, W_TYPE ASC, EDT_PROCESS_DATE ASC";
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

        private void Access_R022A7_DESC_REJECT()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("CLMHDR_CLAIM_ID, ");
            strSQL.Append("W_TYPE, ");
            strSQL.Append("PAT_SURNAME, ");
            strSQL.Append("PAT_GIVEN_NAME, ");
            strSQL.Append("EDT_PROCESS_DATE, ");
            strSQL.Append("W_HEALTH_NBR, ");
            strSQL.Append("PAT_VERSION_CD, ");
            strSQL.Append("PAT_BIRTH_DATE, ");
            strSQL.Append("TRANSLATED_GROUP_NBR, ");
            strSQL.Append("BATCTRL_DOC_NBR_OHIP, ");
            strSQL.Append("CLMHDR_DOC_SPEC_CD, ");
            strSQL.Append("CLMHDR_LOC, ");
            strSQL.Append("PAT_PROV_CD, ");
            strSQL.Append("W_WCB, ");
            strSQL.Append("CLMDTL_SV_DATE, ");
            strSQL.Append("W_CLMDTL_DESC, ");
            strSQL.Append("EDT_OMA_SERVICE_CD_AND_SUFFIX, ");
            strSQL.Append("EDT_SERVICE_DATE, ");
            strSQL.Append("EDT_NBR_SERV, ");
            strSQL.Append("EDT_AMOUNT_SUBMITTED, ");
            strSQL.Append("EDT_DTL_DIAG_CD, ");
            strSQL.Append("EDT_DTL_ERR_CD_1, ");
            strSQL.Append("EDT_DTL_ERR_CD_2, ");
            strSQL.Append("EDT_DTL_ERR_CD_3, ");
            strSQL.Append("EDT_DTL_ERR_CD_4, ");
            strSQL.Append("EDT_DTL_ERR_CD_5 ");
            strSQL.Append("FROM TEMPORARYDATA.R022A7_DESC_REJECT ");

            strSQL.Append(Choose());

            rdrR022A7_DESC_REJECT.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
            strSQL = null;
        }
        private void Link_F020_DOCTOR_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("DOC_NAME ");
            strSQL.Append("FROM INDEXED.F020_DOCTOR_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_NBR = '").Append(QDesign.Substring(rdrR022A7_DESC_REJECT.GetString("CLMHDR_CLAIM_ID"), 3, 3));
            strSQL.Append("'");

            rdrF020_DOCTOR_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        #endregion

        #region " CHOOSE "

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(string.Empty);

            return strChoose.ToString().ToString();
        }

        #endregion

        #region " SELECT IF "

        #endregion

        #region " DEFINES "

        private string W_CLMHDR_CLAIM_ID()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = QDesign.Substring(rdrR022A7_DESC_REJECT.GetString("CLMHDR_CLAIM_ID"), 3, 8);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string W_DESC()
        {
            string strReturnValue = string.Empty;
            try
            {
                if ((QDesign.NULL(rdrR022A7_DESC_REJECT.GetString("W_TYPE")) == "D"))
                {
                    strReturnValue = "DESCRIPTION:";
                }
                else if ((QDesign.NULL(rdrR022A7_DESC_REJECT.GetString("W_TYPE")) == "R"))
                {
                    strReturnValue = "Electronic data transfer claims error report run date: ";
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string PATIENT_NAME()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = (rdrR022A7_DESC_REJECT.GetString("PAT_SURNAME").TrimEnd() + (", " + rdrR022A7_DESC_REJECT.GetString("PAT_GIVEN_NAME").TrimEnd()));
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
                AddControl(ReportSection.PAGE_HEADING, "INDEXED.F020_DOCTOR_MSTR.DOC_NAME", DataTypes.Character, 24);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.R022A7_DESC_REJECT.W_HEALTH_NBR", DataTypes.Character, 12);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.R022A7_DESC_REJECT.PAT_VERSION_CD", DataTypes.Character, 2);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.R022A7_DESC_REJECT.PAT_BIRTH_DATE", DataTypes.Numeric, 8);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.R022A7_DESC_REJECT.TRANSLATED_GROUP_NBR", DataTypes.Character, 4);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.R022A7_DESC_REJECT.BATCTRL_DOC_NBR_OHIP", DataTypes.Numeric, 6);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.R022A7_DESC_REJECT.CLMHDR_DOC_SPEC_CD", DataTypes.Numeric, 2);
                AddControl(ReportSection.PAGE_HEADING, "W_CLMHDR_CLAIM_ID", DataTypes.Character, 8);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.R022A7_DESC_REJECT.CLMHDR_LOC", DataTypes.Character, 4);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.R022A7_DESC_REJECT.PAT_PROV_CD", DataTypes.Character, 2);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.R022A7_DESC_REJECT.W_WCB", DataTypes.Character, 1);
                AddControl(ReportSection.PAGE_HEADING, "PATIENT_NAME", DataTypes.Character, 30);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.R022A7_DESC_REJECT.CLMDTL_SV_DATE", DataTypes.Character, 8);
                AddControl(ReportSection.HEADING_AT, "W_DESC", DataTypes.Character, 60);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.R022A7_DESC_REJECT.EDT_PROCESS_DATE", DataTypes.Numeric, 8);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R022A7_DESC_REJECT.W_CLMDTL_DESC", DataTypes.Character, 22);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R022A7_DESC_REJECT.EDT_OMA_SERVICE_CD_AND_SUFFIX", DataTypes.Character, 5);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R022A7_DESC_REJECT.EDT_SERVICE_DATE", DataTypes.Numeric, 8);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R022A7_DESC_REJECT.EDT_NBR_SERV", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R022A7_DESC_REJECT.EDT_AMOUNT_SUBMITTED", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R022A7_DESC_REJECT.EDT_DTL_DIAG_CD", DataTypes.Character, 4);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R022A7_DESC_REJECT.EDT_DTL_ERR_CD_1", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R022A7_DESC_REJECT.EDT_DTL_ERR_CD_2", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R022A7_DESC_REJECT.EDT_DTL_ERR_CD_3", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R022A7_DESC_REJECT.EDT_DTL_ERR_CD_4", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R022A7_DESC_REJECT.EDT_DTL_ERR_CD_5", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R022A7_DESC_REJECT.CLMHDR_CLAIM_ID", DataTypes.Character, 16);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R022A7_DESC_REJECT.W_TYPE", DataTypes.Character, 1);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-05-11 6:02:20 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            // TODO: Remove duplicate controls, if there are any.
            switch (strControl)
            {
                case "INDEXED.F020_DOCTOR_MSTR.DOC_NAME":
                    return Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_NAME"));
                case "TEMPORARYDATA.R022A7_DESC_REJECT.W_HEALTH_NBR":
                    return Common.StringToField(rdrR022A7_DESC_REJECT.GetString("W_HEALTH_NBR"));
                case "TEMPORARYDATA.R022A7_DESC_REJECT.PAT_VERSION_CD":
                    return Common.StringToField(rdrR022A7_DESC_REJECT.GetString("PAT_VERSION_CD"));
                case "TEMPORARYDATA.R022A7_DESC_REJECT.PAT_BIRTH_DATE":
                    return rdrR022A7_DESC_REJECT.GetNumber("PAT_BIRTH_DATE").ToString();
                case "TEMPORARYDATA.R022A7_DESC_REJECT.TRANSLATED_GROUP_NBR":
                    return Common.StringToField(rdrR022A7_DESC_REJECT.GetString("TRANSLATED_GROUP_NBR"));
                case "TEMPORARYDATA.R022A7_DESC_REJECT.BATCTRL_DOC_NBR_OHIP":
                    return rdrR022A7_DESC_REJECT.GetNumber("BATCTRL_DOC_NBR_OHIP").ToString();
                case "TEMPORARYDATA.R022A7_DESC_REJECT.CLMHDR_DOC_SPEC_CD":
                    return rdrR022A7_DESC_REJECT.GetNumber("CLMHDR_DOC_SPEC_CD").ToString();
                case "W_CLMHDR_CLAIM_ID":
                    return Common.StringToField(W_CLMHDR_CLAIM_ID(), intSize);
                case "TEMPORARYDATA.R022A7_DESC_REJECT.CLMHDR_LOC":
                    return Common.StringToField(rdrR022A7_DESC_REJECT.GetString("CLMHDR_LOC"));
                case "TEMPORARYDATA.R022A7_DESC_REJECT.PAT_PROV_CD":
                    return Common.StringToField(rdrR022A7_DESC_REJECT.GetString("PAT_PROV_CD"));
                case "TEMPORARYDATA.R022A7_DESC_REJECT.W_WCB":
                    return Common.StringToField(rdrR022A7_DESC_REJECT.GetString("W_WCB"));
                case "PATIENT_NAME":
                    return Common.StringToField(PATIENT_NAME(), intSize);
                case "TEMPORARYDATA.R022A7_DESC_REJECT.CLMDTL_SV_DATE":
                    return Common.StringToField(rdrR022A7_DESC_REJECT.GetString("CLMDTL_SV_DATE"));
                case "W_DESC":
                    return Common.StringToField(W_DESC(), intSize);
                case "TEMPORARYDATA.R022A7_DESC_REJECT.EDT_PROCESS_DATE":
                    return rdrR022A7_DESC_REJECT.GetNumber("EDT_PROCESS_DATE").ToString();
                case "TEMPORARYDATA.R022A7_DESC_REJECT.W_CLMDTL_DESC":
                    return Common.StringToField(rdrR022A7_DESC_REJECT.GetString("W_CLMDTL_DESC"));
                case "TEMPORARYDATA.R022A7_DESC_REJECT.EDT_OMA_SERVICE_CD_AND_SUFFIX":
                    return Common.StringToField(rdrR022A7_DESC_REJECT.GetString("EDT_OMA_SERVICE_CD_AND_SUFFIX"));
                case "TEMPORARYDATA.R022A7_DESC_REJECT.EDT_SERVICE_DATE":
                    return rdrR022A7_DESC_REJECT.GetNumber("EDT_SERVICE_DATE").ToString();
                case "TEMPORARYDATA.R022A7_DESC_REJECT.EDT_NBR_SERV":
                    return rdrR022A7_DESC_REJECT.GetNumber("EDT_NBR_SERV").ToString();
                case "TEMPORARYDATA.R022A7_DESC_REJECT.EDT_AMOUNT_SUBMITTED":
                    return rdrR022A7_DESC_REJECT.GetNumber("EDT_AMOUNT_SUBMITTED").ToString();
                case "TEMPORARYDATA.R022A7_DESC_REJECT.EDT_DTL_DIAG_CD":
                    return Common.StringToField(rdrR022A7_DESC_REJECT.GetString("EDT_DTL_DIAG_CD"));
                case "TEMPORARYDATA.R022A7_DESC_REJECT.EDT_DTL_ERR_CD_1":
                    return Common.StringToField(rdrR022A7_DESC_REJECT.GetString("EDT_DTL_ERR_CD_1"));
                case "TEMPORARYDATA.R022A7_DESC_REJECT.EDT_DTL_ERR_CD_2":
                    return Common.StringToField(rdrR022A7_DESC_REJECT.GetString("EDT_DTL_ERR_CD_2"));
                case "TEMPORARYDATA.R022A7_DESC_REJECT.EDT_DTL_ERR_CD_3":
                    return Common.StringToField(rdrR022A7_DESC_REJECT.GetString("EDT_DTL_ERR_CD_3"));
                case "TEMPORARYDATA.R022A7_DESC_REJECT.EDT_DTL_ERR_CD_4":
                    return Common.StringToField(rdrR022A7_DESC_REJECT.GetString("EDT_DTL_ERR_CD_4"));
                case "TEMPORARYDATA.R022A7_DESC_REJECT.EDT_DTL_ERR_CD_5":
                    return Common.StringToField(rdrR022A7_DESC_REJECT.GetString("EDT_DTL_ERR_CD_5"));
                case "TEMPORARYDATA.R022A7_DESC_REJECT.CLMHDR_CLAIM_ID":
                    return Common.StringToField(rdrR022A7_DESC_REJECT.GetString("CLMHDR_CLAIM_ID"));
                case "TEMPORARYDATA.R022A7_DESC_REJECT.W_TYPE":
                    return Common.StringToField(rdrR022A7_DESC_REJECT.GetString("W_TYPE"));
                default:
                    return String.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                // TODO: Some manual steps maybe required.
                Access_R022A7_DESC_REJECT();
                while (rdrR022A7_DESC_REJECT.Read())
                {
                    Link_F020_DOCTOR_MSTR();
                    while (rdrF020_DOCTOR_MSTR.Read())
                    {
                        WriteData();
                    }

                    rdrF020_DOCTOR_MSTR.Close();
                }

                rdrR022A7_DESC_REJECT.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrR022A7_DESC_REJECT == null))
            {
                rdrR022A7_DESC_REJECT.Close();
                rdrR022A7_DESC_REJECT = null;
            }

            if (!(rdrF020_DOCTOR_MSTR == null))
            {
                rdrF020_DOCTOR_MSTR.Close();
                rdrF020_DOCTOR_MSTR = null;
            }
        }

        #endregion

        #endregion
    }
}
