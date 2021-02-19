//  2015/Jan/28 MC original
//  Portal RA rejects
//  2015/Apr/15   MC1     add the parameter for selection to run `REGULAR` or `PORTAL`
//  change define item x-doc-dept-nbr
//  2015/Apr/22   MC2     before it took an hours to run due to large record complex for sort,
//  change program into A/B so that extract the require items in A and sort in B
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
    public class R135A : BaseRDLClass
    {
        protected const string REPORT_NAME = "R135A";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrF088_RAT_REJECTED_CLAIMS_HIST_DTL = new Reader();
        private Reader rdrF088_RAT_REJECTED_CLAIMS_HIST_HDR = new Reader();
        private Reader rdrF020_DOCTOR_MSTR = new Reader();
        private Reader rdrF002_CLAIMS_MSTR = new Reader();
        private Reader rdrF010_PAT_MSTR = new Reader();
        private Reader rdrF096_RA_REJECT_CODE = new Reader();
        private Reader rdrR135 = new Reader();
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
                SubFileName = "R135";
                SubFileType = SubFileType.Keep;
                SubFileAT = "TODO: Enter sortbreak name";
                Sort = "RAT_REJECTED_CLAIM ASC, X_CODE DESC";
                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return ReportData;
        }
        private void Access_F088_RAT_REJECTED_CLAIMS_HIST_DTL()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            strSQL.Append("SELECT ");
            strSQL.Append("CLMHDR_BATCH_NBR, ");
            strSQL.Append("CLMHDR_CLAIM_NBR, ");
            strSQL.Append("PED, ");
            strSQL.Append("CLMHDR_DOC_NBR, ");
            strSQL.Append("OHIP_ERR_CODE, ");
            strSQL.Append("CLMHDR_ADJ_OMA_CD, ");
            strSQL.Append("CLMHDR_ADJ_OMA_SUFF, ");
            strSQL.Append("CLMDTL_SV_DATE ");
            strSQL.Append("FROM INDEXED.F088_RAT_REJECTED_CLAIMS_HIST_DTL ");

            strSQL.Append(Choose());

            strSQL.Append(" ORDER BY CLMHDR_ADJ_OMA_CD");

            rdrF088_RAT_REJECTED_CLAIMS_HIST_DTL.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_F088_RAT_REJECTED_CLAIMS_HIST_HDR()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("CLMHDR_BATCH_NBR, ");
            strSQL.Append(" CLMHDR_CLAIM_NBR, ");
            strSQL.Append("PED, ");
            strSQL.Append("CHARGE_STATUS, ");
            strSQL.Append("OHIP_ERR_CODE ");
            strSQL.Append("FROM INDEXED.F088_RAT_REJECTED_CLAIMS_HIST_HDR ");
            strSQL.Append("WHERE ");
            strSQL.Append("CLMHDR_BATCH_NBR = ").Append(Common.StringToField(rdrF088_RAT_REJECTED_CLAIMS_HIST_DTL.GetString("CLMHDR_BATCH_NBR")));
            strSQL.Append(" AND CLMHDR_CLAIM_NBR = ").Append(rdrF088_RAT_REJECTED_CLAIMS_HIST_DTL.GetNumber("CLMHDR_CLAIM_NBR"));
            strSQL.Append(" AND PED = ").Append(rdrF088_RAT_REJECTED_CLAIMS_HIST_DTL.GetNumber("PED"));

            strSQL.Append(SelectIf_F088_RAT_REJECTED_CLAIMS_HIST_HDR(false));

            rdrF088_RAT_REJECTED_CLAIMS_HIST_HDR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_F020_DOCTOR_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("DOC_DEPT, ");
            strSQL.Append("DOC_NAME ");
            strSQL.Append("FROM INDEXED.F020_DOCTOR_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_NBR = ").Append(Common.StringToField(rdrF088_RAT_REJECTED_CLAIMS_HIST_DTL.GetString("CLMHDR_DOC_NBR")));

            rdrF020_DOCTOR_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_F002_CLAIMS_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("KEY_CLM_TYPE, ");
            strSQL.Append("KEY_CLM_BATCH_NBR, ");
            strSQL.Append("KEY_CLM_CLAIM_NBR, ");
            strSQL.Append("KEY_CLM_SERV_CODE, ");
            strSQL.Append("KEY_CLM_ADJ_NBR, ");
            strSQL.Append("CLMHDR_PAT_KEY_TYPE, ");
            strSQL.Append(" CLMHDR_PAT_KEY_DATA ");
            strSQL.Append("FROM INDEXED.F002_CLAIMS_MSTR_HDR ");
            strSQL.Append("WHERE ");
            strSQL.Append("KEY_CLM_TYPE = ").Append(Common.StringToField("B"));
            strSQL.Append(" AND KEY_CLM_BATCH_NBR = ").Append(Common.StringToField(rdrF088_RAT_REJECTED_CLAIMS_HIST_DTL.GetString("CLMHDR_BATCH_NBR")));
            strSQL.Append(" AND KEY_CLM_CLAIM_NBR = ").Append(rdrF088_RAT_REJECTED_CLAIMS_HIST_DTL.GetNumber("CLMHDR_CLAIM_NBR"));
            strSQL.Append(" AND KEY_CLM_SERV_CODE = ").Append(Common.StringToField("00000"));
            strSQL.Append(" AND KEY_CLM_ADJ_NBR = ").Append(Common.StringToField("0"));

            rdrF002_CLAIMS_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_F010_PAT_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("PAT_HEALTH_NBR, ");
            strSQL.Append("PAT_VERSION_CD ");
            strSQL.Append("FROM INDEXED.F010_PAT_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("PAT_I_KEY = ").Append(Common.StringToField(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_PAT_KEY_TYPE")));
            strSQL.Append(" AND PAT_CON_NBR = ").Append(QDesign.NConvert(QDesign.Substring(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_PAT_KEY_DATA"), 1, 2)));
            strSQL.Append(" AND PAT_I_NBR = ").Append(QDesign.NConvert(QDesign.Substring(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_PAT_KEY_DATA"), 3, 12)));
            strSQL.Append(" AND FILLER4 = ").Append(Common.StringToField(QDesign.Substring(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_PAT_KEY_DATA"), 15, 1)));

            rdrF010_PAT_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_F096_RA_REJECT_CODE()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("RAT_CODE, ");
            strSQL.Append("RAT_EXPLANATION ");
            strSQL.Append("FROM INDEXED.F096_RA_REJECT_CODE ");
            strSQL.Append("WHERE ");
            strSQL.Append("RAT_CODE = ").Append(Common.StringToField(rdrF088_RAT_REJECTED_CLAIMS_HIST_DTL.GetString("OHIP_ERR_CODE")));

            rdrF096_RA_REJECT_CODE.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(String.Empty);

            strChoose.Append("WHERE ");
            strChoose.Append("PED BETWEEN ").Append(QDesign.NConvert(ReportFunctions.astrScreenParameters[0].ToString())).Append(" AND ").Append(QDesign.NConvert(ReportFunctions.astrScreenParameters[1].ToString()));

            return strChoose.ToString().ToString();
        }

        private string SelectIf_F088_RAT_REJECTED_CLAIMS_HIST_HDR(bool blnAddWhere)
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

            // TODO: SelectIf Statement - May require manual changes.
            strSQL.Append(" (    CHARGE_STATUS =  'Y')");
            return strSQL.ToString().ToString();
        }

        public override bool SelectIf()
        {
            bool blnSelected = false;
            if ((QDesign.NULL(rdrF088_RAT_REJECTED_CLAIMS_HIST_HDR.GetString("OHIP_ERR_CODE")) == QDesign.NULL(rdrF088_RAT_REJECTED_CLAIMS_HIST_DTL.GetString("OHIP_ERR_CODE"))))
            {
                blnSelected = true;
            }

            return blnSelected;
        }

        private string X_CODE()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = (rdrF088_RAT_REJECTED_CLAIMS_HIST_DTL.GetString("CLMHDR_ADJ_OMA_CD") + rdrF088_RAT_REJECTED_CLAIMS_HIST_DTL.GetString("CLMHDR_ADJ_OMA_SUFF"));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_DESC()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = rdrF096_RA_REJECT_CODE.GetString("RAT_EXPLANATION");
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string RAT_REJECTED_CLAIM()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = (rdrF088_RAT_REJECTED_CLAIMS_HIST_HDR.GetString("CLMHDR_BATCH_NBR") + QDesign.ASCII(rdrF088_RAT_REJECTED_CLAIMS_HIST_HDR.GetNumber("CLMHDR_CLAIM_NBR"), 2));
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
                AddControl(ReportSection.SUMMARY, "INDEXED.F088_RAT_REJECTED_CLAIMS_HIST_DTL.CLMHDR_DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.SUMMARY, "RAT_REJECTED_CLAIM", DataTypes.Character, 10);
                AddControl(ReportSection.SUMMARY, "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT", DataTypes.Numeric, 2);
                AddControl(ReportSection.SUMMARY, "INDEXED.F020_DOCTOR_MSTR.DOC_NAME", DataTypes.Character, 24);
                AddControl(ReportSection.SUMMARY, "X_CODE", DataTypes.Character, 5);
                AddControl(ReportSection.SUMMARY, "INDEXED.F088_RAT_REJECTED_CLAIMS_HIST_DTL.CLMDTL_SV_DATE", DataTypes.Character, 8);
                AddControl(ReportSection.SUMMARY, "INDEXED.F010_PAT_MSTR.PAT_HEALTH_NBR", DataTypes.Numeric, 10);
                AddControl(ReportSection.SUMMARY, "INDEXED.F010_PAT_MSTR.PAT_VERSION_CD", DataTypes.Character, 2);
                AddControl(ReportSection.SUMMARY, "INDEXED.F088_RAT_REJECTED_CLAIMS_HIST_DTL.OHIP_ERR_CODE", DataTypes.Character, 3);
                AddControl(ReportSection.SUMMARY, "X_DESC", DataTypes.Character, 70);
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
                case "INDEXED.F088_RAT_REJECTED_CLAIMS_HIST_DTL.CLMHDR_DOC_NBR":
                    return Common.StringToField(rdrF088_RAT_REJECTED_CLAIMS_HIST_DTL.GetString("CLMHDR_DOC_NBR"));
                case "RAT_REJECTED_CLAIM":
                    return Common.StringToField(RAT_REJECTED_CLAIM(), intSize);
                case "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT":
                    return rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT").ToString();
                case "INDEXED.F020_DOCTOR_MSTR.DOC_NAME":
                    return Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_NAME"));
                case "X_CODE":
                    return Common.StringToField(X_CODE(), intSize);
                case "INDEXED.F088_RAT_REJECTED_CLAIMS_HIST_DTL.CLMDTL_SV_DATE":
                    return Common.StringToField(rdrF088_RAT_REJECTED_CLAIMS_HIST_DTL.GetString("CLMDTL_SV_DATE"));
                case "INDEXED.F010_PAT_MSTR.PAT_HEALTH_NBR":
                    return rdrF010_PAT_MSTR.GetNumber("PAT_HEALTH_NBR").ToString();
                case "INDEXED.F010_PAT_MSTR.PAT_VERSION_CD":
                    return Common.StringToField(rdrF010_PAT_MSTR.GetString("PAT_VERSION_CD"));
                case "INDEXED.F088_RAT_REJECTED_CLAIMS_HIST_DTL.OHIP_ERR_CODE":
                    return Common.StringToField(rdrF088_RAT_REJECTED_CLAIMS_HIST_DTL.GetString("OHIP_ERR_CODE"));
                case "X_DESC":
                    return Common.StringToField(X_DESC(), intSize);
                default:
                    return String.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                // TODO: Some manual steps maybe required.
                Access_F088_RAT_REJECTED_CLAIMS_HIST_DTL();
                while (rdrF088_RAT_REJECTED_CLAIMS_HIST_DTL.Read())
                {
                    Link_F088_RAT_REJECTED_CLAIMS_HIST_HDR();
                    while (rdrF088_RAT_REJECTED_CLAIMS_HIST_HDR.Read())
                    {
                        Link_F020_DOCTOR_MSTR();
                        while (rdrF020_DOCTOR_MSTR.Read())
                        {
                            Link_F002_CLAIMS_MSTR();
                            while (rdrF002_CLAIMS_MSTR.Read())
                            {
                                Link_F010_PAT_MSTR();
                                while (rdrF010_PAT_MSTR.Read())
                                {
                                    Link_F096_RA_REJECT_CODE();
                                    while (rdrF096_RA_REJECT_CODE.Read())
                                    {
                                        WriteData();
                                    }

                                    rdrF096_RA_REJECT_CODE.Close();
                                }

                                rdrF010_PAT_MSTR.Close();
                            }

                            rdrF002_CLAIMS_MSTR.Close();
                        }

                        rdrF020_DOCTOR_MSTR.Close();
                    }

                    rdrF088_RAT_REJECTED_CLAIMS_HIST_HDR.Close();
                }

                rdrF088_RAT_REJECTED_CLAIMS_HIST_DTL.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrF088_RAT_REJECTED_CLAIMS_HIST_DTL == null))
            {
                rdrF088_RAT_REJECTED_CLAIMS_HIST_DTL.Close();
                rdrF088_RAT_REJECTED_CLAIMS_HIST_DTL = null;
            }

            if (!(rdrF088_RAT_REJECTED_CLAIMS_HIST_HDR == null))
            {
                rdrF088_RAT_REJECTED_CLAIMS_HIST_HDR.Close();
                rdrF088_RAT_REJECTED_CLAIMS_HIST_HDR = null;
            }

            if (!(rdrF020_DOCTOR_MSTR == null))
            {
                rdrF020_DOCTOR_MSTR.Close();
                rdrF020_DOCTOR_MSTR = null;
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

            if (!(rdrF096_RA_REJECT_CODE == null))
            {
                rdrF096_RA_REJECT_CODE.Close();
                rdrF096_RA_REJECT_CODE = null;
            }
        }
    }
}
