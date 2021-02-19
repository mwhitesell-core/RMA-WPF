//  program: costing11.qzs
//  formerly:costing8.qzs
//  purpose: dump chargeable items from f088 so that user has hard copy
//  of doctor charges for answering phone calls
//  00/jul/00 B.E. - original
//  00/jul/31 B.E. - added link to const rec 7 to obtain select dates
//  for f088 recs - modified select statement to list only
//  current costing period claims
//  03/dec/11 A.A. - alpha doctor nbr
//  15/Jul/22 MC1  - modify to select on ped instead of clmhdr-date-period-end
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
    public class COSTING11 : BaseRDLClass {
        protected const string REPORT_NAME = "COSTING11";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrF088_DTL = new Reader();
        private Reader rdrF088_HDR = new Reader();
        private Reader rdrF020_DOCTOR_MSTR = new Reader();
        private Reader rdrCONSTANTS_MSTR_REC_7 = new Reader();
        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug) {
            try
            {
                //  Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;
                Sort = "CLMHDR_DOC_NBR ASC, OHIP_ERR_CODE ASC, RAT_REJECTED_CLAIM ASC";
                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return ReportData;
        }
        private void Access_F088_DTL() {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            strSQL.Append("SELECT ");
            strSQL.Append("CLMHDR_BATCH_NBR, ");
            strSQL.Append("CLMHDR_CLAIM_NBR, ");
            strSQL.Append("CLMHDR_ADJ_ADJ_NBR, ");
            strSQL.Append("PED, ");
            strSQL.Append("CLMHDR_DOC_NBR, ");
            strSQL.Append("CLMHDR_ADJ_OMA_CD, ");
            strSQL.Append("CLMHDR_ADJ_OMA_SUFF, ");
            strSQL.Append("ENTRY_USER_ID, ");
            strSQL.Append("OHIP_ERR_CODE, ");
            strSQL.Append("PART_DTL_AMT_BILL, ");
            strSQL.Append("PART_DTL_AMT_PAID, ");
            strSQL.Append("AUTO_ADJ_FLAG, ");
            strSQL.Append("CLMDTL_DATE_PERIOD_END, ");
            strSQL.Append("CLMDTL_SV_DATE ");
            strSQL.Append("FROM INDEXED.F088_RAT_REJECTED_CLAIMS_HIST_DTL F088_DTL ");
            strSQL.Append(Choose());
            rdrF088_DTL.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_F088_HDR() {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("CLMHDR_BATCH_NBR, ");
            strSQL.Append("CLMHDR_CLAIM_NBR, ");
            strSQL.Append("PED, ");
            strSQL.Append("CHARGE_STATUS, ");
            strSQL.Append("OHIP_ERR_CODE, ");
            strSQL.Append("CLMHDR_DATE_PERIOD_END, ");
            strSQL.Append("CLMHDR_SERV_DATE ");
            strSQL.Append("FROM INDEXED.F088_RAT_REJECTED_CLAIMS_HIST_HDR F088_HDR ");
            strSQL.Append("WHERE ");
            strSQL.Append("CLMHDR_BATCH_NBR = ").Append(Common.StringToField(rdrF088_DTL.GetString("CLMHDR_BATCH_NBR")));
            strSQL.Append(" AND CLMHDR_CLAIM_NBR = ").Append(rdrF088_DTL.GetNumber("CLMHDR_CLAIM_NBR"));
            strSQL.Append(" AND PED = ").Append(rdrF088_DTL.GetNumber("PED"));
            rdrF088_HDR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_F020_DOCTOR_MSTR() {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("DOC_DEPT ");
            strSQL.Append("FROM INDEXED.F020_DOCTOR_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_NBR = ").Append(Common.StringToField(rdrF088_DTL.GetString("CLMHDR_DOC_NBR")));
            rdrF020_DOCTOR_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_CONSTANTS_MSTR_REC_7() {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("CONST_REC_NBR, ");
            strSQL.Append("CURRENT_FISCAL_START_YYMMDD, ");
            strSQL.Append("CURRENT_COSTING_CUTOFF_YYMMDD ");
            strSQL.Append("FROM INDEXED.CONSTANTS_MSTR_REC_7 ");
            strSQL.Append("WHERE ");
            strSQL.Append("CONST_REC_NBR = ").Append(7);
            rdrCONSTANTS_MSTR_REC_7.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        private string Choose() {
            StringBuilder strChoose = new StringBuilder(String.Empty);
            // TODO: CHOOSE Statement - May require manual changes.
            return strChoose.ToString().ToString();
        }

        public override bool SelectIf() {
            bool blnSelected = false;
            if (((QDesign.NULL(rdrF088_HDR.GetString("CHARGE_STATUS")) == "Y")
                        && ((rdrF088_DTL.GetNumber("PED") >= rdrCONSTANTS_MSTR_REC_7.GetNumber("CURRENT_FISCAL_START_YYMMDD"))
                        && (rdrF088_DTL.GetNumber("PED") <= rdrCONSTANTS_MSTR_REC_7.GetNumber("CURRENT_COSTING_CUTOFF_YYMMDD"))))) {
                blnSelected = true;
            }

            return blnSelected;
        }

        private string X_OMA_CD() {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = (rdrF088_DTL.GetString("CLMHDR_ADJ_OMA_CD") + rdrF088_DTL.GetString("CLMHDR_ADJ_OMA_SUFF"));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string OHIP_ERR_CD_2() {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = (rdrF088_DTL.GetString("OHIP_ERR_CODE"));
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }


            return strReturnValue;
        }


        private string F088_HDR_RAT_REJECTED_CLAIM() {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = (rdrF088_HDR.GetString("CLMHDR_BATCH_NBR") + QDesign.ASCII(rdrF088_HDR.GetNumber("CLMHDR_CLAIM_NBR"), 2));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        public override void DeclareReportControls() {
            try
            {
                AddControl(ReportSection.REPORT, "INDEXED.F088_DTL.CLMHDR_DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "INDEXED.F088_DTL.PED", DataTypes.Numeric, 8);
                AddControl(ReportSection.REPORT, "RAT_REJECTED_CLAIM", DataTypes.Character, 10);
                AddControl(ReportSection.REPORT, "INDEXED.F088_HDR.OHIP_ERR_CODE", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "INDEXED.F088_HDR.CLMHDR_DATE_PERIOD_END", DataTypes.Numeric, 8);
                AddControl(ReportSection.REPORT, "INDEXED.F088_HDR.CLMHDR_SERV_DATE", DataTypes.Numeric, 8);
                AddControl(ReportSection.REPORT, "INDEXED.F088_HDR.CHARGE_STATUS", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "INDEXED.F088_DTL.ENTRY_USER_ID", DataTypes.Character, 15);
                AddControl(ReportSection.REPORT, "X_OMA_CD", DataTypes.Character, 5);
                AddControl(ReportSection.REPORT, "OHIP_ERR_CD_2", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "INDEXED.F088_DTL.PART_DTL_AMT_BILL", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "INDEXED.F088_DTL.PART_DTL_AMT_PAID", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "INDEXED.F088_DTL.AUTO_ADJ_FLAG", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "INDEXED.F088_DTL.CLMDTL_DATE_PERIOD_END", DataTypes.Character, 8);
                AddControl(ReportSection.REPORT, "INDEXED.F088_DTL.CLMDTL_SV_DATE", DataTypes.Character, 8);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2019-07-24 7:52:03 AM
        public override string ReturnControlValue(string strControl, int intSize) {
            switch (strControl) {
                case "INDEXED.F088_DTL.CLMHDR_DOC_NBR":
                    return Common.StringToField(rdrF088_DTL.GetString("CLMHDR_DOC_NBR"));
                case "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT":
                    return rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT").ToString();
                case "INDEXED.F088_DTL.PED":
                    return rdrF088_DTL.GetNumber("PED").ToString();
                case "RAT_REJECTED_CLAIM":
                    return Common.StringToField(F088_HDR_RAT_REJECTED_CLAIM(), intSize);
                case "INDEXED.F088_HDR.OHIP_ERR_CODE":
                    return Common.StringToField(rdrF088_HDR.GetString("OHIP_ERR_CODE"));
                case "INDEXED.F088_HDR.CLMHDR_DATE_PERIOD_END":
                    return rdrF088_HDR.GetNumber("CLMHDR_DATE_PERIOD_END").ToString();
                case "INDEXED.F088_HDR.CLMHDR_SERV_DATE":
                    return rdrF088_HDR.GetNumber("CLMHDR_SERV_DATE").ToString();
                case "INDEXED.F088_HDR.CHARGE_STATUS":
                    return Common.StringToField(rdrF088_HDR.GetString("CHARGE_STATUS"));
                case "INDEXED.F088_DTL.ENTRY_USER_ID":
                    return Common.StringToField(rdrF088_DTL.GetString("ENTRY_USER_ID"));
                case "X_OMA_CD":
                    return Common.StringToField(X_OMA_CD(), intSize);
                case "OHIP_ERR_CD_2":
                    return Common.StringToField(OHIP_ERR_CD_2(), intSize);
                case "INDEXED.F088_DTL.PART_DTL_AMT_BILL":
                    return rdrF088_DTL.GetNumber("PART_DTL_AMT_BILL").ToString();
                case "INDEXED.F088_DTL.PART_DTL_AMT_PAID":
                    return rdrF088_DTL.GetNumber("PART_DTL_AMT_PAID").ToString();
                case "INDEXED.F088_DTL.AUTO_ADJ_FLAG":
                    return Common.StringToField(rdrF088_DTL.GetString("AUTO_ADJ_FLAG"));
                case "INDEXED.F088_DTL.CLMDTL_DATE_PERIOD_END":
                    return Common.StringToField(rdrF088_DTL.GetString("CLMDTL_DATE_PERIOD_END"));
                case "INDEXED.F088_DTL.CLMDTL_SV_DATE":
                    return Common.StringToField(rdrF088_DTL.GetString("CLMDTL_SV_DATE"));
                default:
                    return String.Empty;
            }
        }

        public override void AccessData() {
            try
            {
                // TODO: Some manual steps maybe required.
                Access_F088_DTL();
                while (rdrF088_DTL.Read()) {
                    Link_F088_HDR();
                    while (rdrF088_HDR.Read()) {
                        Link_F020_DOCTOR_MSTR();
                        while (rdrF020_DOCTOR_MSTR.Read()) {
                            Link_CONSTANTS_MSTR_REC_7();
                            while (rdrCONSTANTS_MSTR_REC_7.Read()) {
                                WriteData();
                            }

                            rdrCONSTANTS_MSTR_REC_7.Close();
                        }

                        rdrF020_DOCTOR_MSTR.Close();
                    }

                    rdrF088_HDR.Close();
                }

                rdrF088_DTL.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders() {
            if (!(rdrF088_DTL == null)) {
                rdrF088_DTL.Close();
                rdrF088_DTL = null;
            }

            if (!(rdrF088_HDR == null)) {
                rdrF088_HDR.Close();
                rdrF088_HDR = null;
            }

            if (!(rdrF020_DOCTOR_MSTR == null)) {
                rdrF020_DOCTOR_MSTR.Close();
                rdrF020_DOCTOR_MSTR = null;
            }

            if (!(rdrCONSTANTS_MSTR_REC_7 == null)) {
                rdrCONSTANTS_MSTR_REC_7.Close();
                rdrCONSTANTS_MSTR_REC_7 = null;
            }
        }
    }
}
