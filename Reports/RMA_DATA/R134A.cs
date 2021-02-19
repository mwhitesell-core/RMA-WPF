// 2015/Jan/28	MC original
// Portal eligibility rejects
// 2015/Apr/15	MC1 add the parameter for selection to run 'REGULAR' or 'PORTAL'
//			change define item x-doc-dept-nbr 
// 2015/Apr/22	MC2 before it took an hours to run due to large record complex for sort,
//			change program into A/B so that extract the require items in A and sort in B
// 2015/Jul/22   MC3 modify access statement to include edt-process-date; add edt-process-date on the choose statement  

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
    public class R134A : BaseRDLClass
    {
        protected const string REPORT_NAME = "R134A";
        protected const bool REPORT_HAS_PARAMETERS = true;

        private Reader rdrF087_SUBMITTED_REJECTED_CLAIMS_HDR = new Reader();
        private Reader rdrF087_SUBMITTED_REJECTED_CLAIMS_DTL = new Reader();
        private Reader rdrF020_DOCTOR_MSTR = new Reader();
        private Reader rdrF093_OHIP_ERROR_MSG_MSTR = new Reader();
        private Reader rdrF002_CLAIMS_MSTR = new Reader();
        private Reader rdrR134 = new Reader();

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
                SubFileName = "R134";
                SubFileType = SubFileType.Keep;
                SubFileAT = "";
                Sort = "SUBMITTED_REJECTED_CLAIM ASC, EDT_OMA_SERVICE_CD_AND_SUFFIX DESC";
                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return ReportData;
        }

        private void Access_F087_SUBMITTED_REJECTED_CLAIMS_HDR()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("CLMHDR_BATCH_NBR, ");
            strSQL.Append("CLMHDR_CLAIM_NBR, ");
            strSQL.Append("PED, ");
            strSQL.Append("EDT_PROCESS_DATE, ");
            strSQL.Append("CLMHDR_DOC_NBR, ");
            strSQL.Append("OHIP_ERR_CODE, ");
            strSQL.Append("EDT_HEALTH_NBR, ");
            strSQL.Append("EDT_HEALTH_VERSION_CD ");
            strSQL.Append("FROM INDEXED.F087_SUBMITTED_REJECTED_CLAIMS_HDR ");

            strSQL.Append(Choose());

            strSQL.Append(SelectIf_F087_SUBMITTED_REJECTED_CLAIMS_HDR(false));

            strSQL.Append(" ORDER BY CLMHDR_BATCH_NBR, CLMHDR_CLAIM_NBR, EDT_PROCESS_DATE DESC");

            rdrF087_SUBMITTED_REJECTED_CLAIMS_HDR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        private void Link_F087_SUBMITTED_REJECTED_CLAIMS_DTL()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("EDT_DTL_ERR_CD_1, ");
            strSQL.Append("EDT_OMA_SERVICE_CD_AND_SUFFIX, ");
            strSQL.Append("EDT_SERVICE_DATE ");
            strSQL.Append("FROM INDEXED.F087_SUBMITTED_REJECTED_CLAIMS_DTL ");
            strSQL.Append("WHERE ");
            strSQL.Append("CLMHDR_BATCH_NBR = ").Append(Common.StringToField(rdrF087_SUBMITTED_REJECTED_CLAIMS_HDR.GetString("CLMHDR_BATCH_NBR")));
            strSQL.Append(" AND CLMHDR_CLAIM_NBR = ").Append(rdrF087_SUBMITTED_REJECTED_CLAIMS_HDR.GetNumber("CLMHDR_CLAIM_NBR"));
            strSQL.Append(" AND PED = ").Append(rdrF087_SUBMITTED_REJECTED_CLAIMS_HDR.GetNumber("PED"));
            strSQL.Append(" AND EDT_PROCESS_DATE = ").Append(rdrF087_SUBMITTED_REJECTED_CLAIMS_HDR.GetNumber("EDT_PROCESS_DATE"));

            rdrF087_SUBMITTED_REJECTED_CLAIMS_DTL.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        private void Link_F020_DOCTOR_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_DEPT, ");
            strSQL.Append("DOC_NAME ");
            strSQL.Append("FROM INDEXED.F020_DOCTOR_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_NBR = ").Append(Common.StringToField(rdrF087_SUBMITTED_REJECTED_CLAIMS_HDR.GetString("CLMHDR_DOC_NBR")));

            rdrF020_DOCTOR_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        private void Link_F093_OHIP_ERROR_MSG_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("OHIP_ERR_CODE, ");
            strSQL.Append("OHIP_ERR_DESCRIPTION ");
            strSQL.Append("FROM INDEXED.F093_OHIP_ERROR_MSG_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("OHIP_ERR_CODE = ").Append(Common.StringToField(rdrF087_SUBMITTED_REJECTED_CLAIMS_HDR.GetString("OHIP_ERR_CODE")));

            strSQL.Append(SelectIf_F093_OHIP_ERROR_MSG_MSTR(false));

            rdrF093_OHIP_ERROR_MSG_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        private void Link_F002_CLAIMS_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("CLMHDR_BATCH_NBR ");
            strSQL.Append("FROM INDEXED.F002_CLAIMS_MSTR_HDR ");
            strSQL.Append("WHERE ");
            strSQL.Append("KEY_CLM_TYPE = ").Append(Common.StringToField("B"));
            strSQL.Append(" AND KEY_CLM_BATCH_NBR = ").Append(Common.StringToField(rdrF087_SUBMITTED_REJECTED_CLAIMS_HDR.GetString("CLMHDR_BATCH_NBR")));
            strSQL.Append(" AND KEY_CLM_CLAIM_NBR = ").Append(rdrF087_SUBMITTED_REJECTED_CLAIMS_HDR.GetNumber("CLMHDR_CLAIM_NBR"));
            strSQL.Append(" AND KEY_CLM_SERV_CODE = ").Append(Common.StringToField("00000"));
            strSQL.Append(" AND KEY_CLM_ADJ_NBR = ").Append(Common.StringToField("0"));

            rdrF002_CLAIMS_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(String.Empty);

            strChoose.Append("WHERE ");
            strChoose.Append("EDT_PROCESS_DATE BETWEEN ").Append(QDesign.NConvert(ReportFunctions.astrScreenParameters[0].ToString())).Append(" AND ").Append(QDesign.NConvert(ReportFunctions.astrScreenParameters[1].ToString()));

            return strChoose.ToString().ToString();
        }

        private string SelectIf_F087_SUBMITTED_REJECTED_CLAIMS_HDR(bool blnAddWhere)
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            if (blnAddWhere)
            {
                strSQL.Append(" WHERE ");
            }
            else
            {
                strSQL.Append(" AND ");
            }

            strSQL.Append(" CHARGE_STATUS = 'Y'");

            return strSQL.ToString().ToString();
        }

        private string SelectIf_F093_OHIP_ERROR_MSG_MSTR(bool blnAddWhere)
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            if (blnAddWhere)
            {
                strSQL.Append(" WHERE ");
            }
            else
            {
                strSQL.Append(" AND ");
            }

            strSQL.Append(" OHIP_ERR_CAT_CODE <> 'R'");

            return strSQL.ToString().ToString();
        }

        public override bool SelectIf()
        {
            bool blnSelected = false;
            if (QDesign.NULL(rdrF087_SUBMITTED_REJECTED_CLAIMS_HDR.GetString("OHIP_ERR_CODE")) == QDesign.NULL(rdrF087_SUBMITTED_REJECTED_CLAIMS_DTL.GetString("EDT_DTL_ERR_CD_1")))
            {
                blnSelected = true;
            }

            return blnSelected;
        }

        private string SUBMITTED_REJECTED_CLAIM()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = rdrF087_SUBMITTED_REJECTED_CLAIMS_HDR.GetString("CLMHDR_BATCH_NBR") + QDesign.ASCII(rdrF087_SUBMITTED_REJECTED_CLAIMS_HDR.GetNumber("CLMHDR_CLAIM_NBR"), 2);
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
                AddControl(ReportSection.SUMMARY, "INDEXED.F087_SUBMITTED_REJECTED_CLAIMS_HDR.CLMHDR_DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.SUMMARY, "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT", DataTypes.Numeric, 2);
                AddControl(ReportSection.SUMMARY, "INDEXED.F020_DOCTOR_MSTR.DOC_NAME", DataTypes.Character, 24);
                AddControl(ReportSection.SUMMARY, "SUBMITTED_REJECTED_CLAIM", DataTypes.Character, 10);
                AddControl(ReportSection.SUMMARY, "INDEXED.F087_SUBMITTED_REJECTED_CLAIMS_DTL.EDT_OMA_SERVICE_CD_AND_SUFFIX", DataTypes.Character, 5);
                AddControl(ReportSection.SUMMARY, "INDEXED.F087_SUBMITTED_REJECTED_CLAIMS_DTL.EDT_SERVICE_DATE", DataTypes.Numeric, 8);
                AddControl(ReportSection.SUMMARY, "INDEXED.F087_SUBMITTED_REJECTED_CLAIMS_HDR.EDT_HEALTH_NBR", DataTypes.Character, 10);
                AddControl(ReportSection.SUMMARY, "INDEXED.F087_SUBMITTED_REJECTED_CLAIMS_HDR.EDT_HEALTH_VERSION_CD", DataTypes.Character, 2);
                AddControl(ReportSection.SUMMARY, "INDEXED.F093_OHIP_ERROR_MSG_MSTR.OHIP_ERR_CODE", DataTypes.Character, 3);
                AddControl(ReportSection.SUMMARY, "INDEXED.F093_OHIP_ERROR_MSG_MSTR.OHIP_ERR_DESCRIPTION", DataTypes.Character, 60);
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
                case "INDEXED.F087_SUBMITTED_REJECTED_CLAIMS_HDR.CLMHDR_DOC_NBR":
                    return Common.StringToField(rdrF087_SUBMITTED_REJECTED_CLAIMS_HDR.GetString("CLMHDR_DOC_NBR"));

                case "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT":
                    return rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT").ToString();

                case "INDEXED.F020_DOCTOR_MSTR.DOC_NAME":
                    return Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_NAME"));

                case "SUBMITTED_REJECTED_CLAIM":
                    return Common.StringToField(SUBMITTED_REJECTED_CLAIM(), intSize);

                case "INDEXED.F087_SUBMITTED_REJECTED_CLAIMS_DTL.EDT_OMA_SERVICE_CD_AND_SUFFIX":
                    return Common.StringToField(rdrF087_SUBMITTED_REJECTED_CLAIMS_DTL.GetString("EDT_OMA_SERVICE_CD_AND_SUFFIX"));

                case "INDEXED.F087_SUBMITTED_REJECTED_CLAIMS_DTL.EDT_SERVICE_DATE":
                    return rdrF087_SUBMITTED_REJECTED_CLAIMS_DTL.GetNumber("EDT_SERVICE_DATE").ToString();

                case "INDEXED.F087_SUBMITTED_REJECTED_CLAIMS_HDR.EDT_HEALTH_NBR":
                    return Common.StringToField(rdrF087_SUBMITTED_REJECTED_CLAIMS_HDR.GetString("EDT_HEALTH_NBR"));

                case "INDEXED.F087_SUBMITTED_REJECTED_CLAIMS_HDR.EDT_HEALTH_VERSION_CD":
                    return Common.StringToField(rdrF087_SUBMITTED_REJECTED_CLAIMS_HDR.GetString("EDT_HEALTH_VERSION_CD"));

                case "INDEXED.F093_OHIP_ERROR_MSG_MSTR.OHIP_ERR_CODE":
                    return Common.StringToField(rdrF093_OHIP_ERROR_MSG_MSTR.GetString("OHIP_ERR_CODE"));

                case "INDEXED.F093_OHIP_ERROR_MSG_MSTR.OHIP_ERR_DESCRIPTION":
                    return Common.StringToField(rdrF093_OHIP_ERROR_MSG_MSTR.GetString("OHIP_ERR_DESCRIPTION"));

                default:
                    return String.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                // TODO: Some manual steps maybe required.
                Access_F087_SUBMITTED_REJECTED_CLAIMS_HDR();
                while (rdrF087_SUBMITTED_REJECTED_CLAIMS_HDR.Read())
                {
                    Link_F087_SUBMITTED_REJECTED_CLAIMS_DTL();
                    while (rdrF087_SUBMITTED_REJECTED_CLAIMS_DTL.Read())
                    {
                        Link_F020_DOCTOR_MSTR();
                        while (rdrF020_DOCTOR_MSTR.Read())
                        {
                            Link_F093_OHIP_ERROR_MSG_MSTR();
                            while (rdrF093_OHIP_ERROR_MSG_MSTR.Read())
                            {
                                Link_F002_CLAIMS_MSTR();
                                while (rdrF002_CLAIMS_MSTR.Read())
                                {
                                    WriteData();
                                }
                                rdrF002_CLAIMS_MSTR.Close();
                            }
                            rdrF093_OHIP_ERROR_MSG_MSTR.Close();
                        }
                        rdrF020_DOCTOR_MSTR.Close();
                    }
                    rdrF087_SUBMITTED_REJECTED_CLAIMS_DTL.Close();
                }
                rdrF087_SUBMITTED_REJECTED_CLAIMS_HDR.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrF087_SUBMITTED_REJECTED_CLAIMS_HDR == null))
            {
                rdrF087_SUBMITTED_REJECTED_CLAIMS_HDR.Close();
                rdrF087_SUBMITTED_REJECTED_CLAIMS_HDR = null;
            }

            if (!(rdrF087_SUBMITTED_REJECTED_CLAIMS_DTL == null))
            {
                rdrF087_SUBMITTED_REJECTED_CLAIMS_DTL.Close();
                rdrF087_SUBMITTED_REJECTED_CLAIMS_DTL = null;
            }

            if (!(rdrF020_DOCTOR_MSTR == null))
            {
                rdrF020_DOCTOR_MSTR.Close();
                rdrF020_DOCTOR_MSTR = null;
            }

            if (!(rdrF093_OHIP_ERROR_MSG_MSTR == null))
            {
                rdrF093_OHIP_ERROR_MSG_MSTR.Close();
                rdrF093_OHIP_ERROR_MSG_MSTR = null;
            }

            if (!(rdrF002_CLAIMS_MSTR == null))
            {
                rdrF002_CLAIMS_MSTR.Close();
                rdrF002_CLAIMS_MSTR = null;
            }
        }
    }
}
