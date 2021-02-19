#region "Screen Comments"


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
    public class R997_CLINIC22_84J_B : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R997_CLINIC22_84J_B";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrU997_RMB_SRT = new Reader();
        private Reader rdrF002_CLAIMS_MSTR = new Reader();

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

                Sort = "DOC_NBR ASC, RAT_RMB_SERVICE_DATE ASC";

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

        private void Access_U997_RMB_SRT()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("W_RAT_RMB_CLINIC_NBR, ");
            strSQL.Append("RAT_RMB_ACCOUNT_NBR, ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("RAT_RMB_SERVICE_DATE, ");
            strSQL.Append("DOC_DEPT, ");
            strSQL.Append("DOC_NAME, ");
            strSQL.Append("DOC_INITS, ");
            strSQL.Append("DOC_OHIP_NBR, ");
            strSQL.Append("DOC_SPEC_CD, ");
            strSQL.Append("RAT_RMB_PAYMENT_DATE, ");
            strSQL.Append("W_RAT_RMB_LAST_NAME, ");
            strSQL.Append("RAT_RMB_FIRST_NAME, ");
            strSQL.Append("RAT_RMB_PROV_CD, ");
            strSQL.Append("RAT_RMB_PAY_PROG, ");
            strSQL.Append("RAT_RMB_NBR_OF_SERV, ");
            strSQL.Append("RAT_RMB_SERVICE_CD, ");
            strSQL.Append("RAT_RMB_ELIGIBILITY_IND, ");
            strSQL.Append("RAT_RMB_AMOUNT_SUB, ");
            strSQL.Append("RAT_RMB_AMT_PAID, ");
            strSQL.Append("RAT_RMB_EXPLAN_CD ");
            strSQL.Append("FROM TEMPORARYDATA.U997_RMB_SRT ");

            strSQL.Append(Choose());

            rdrU997_RMB_SRT.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);

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
            strSQL.Append("CLMHDR_LOC, ");
            strSQL.Append("CLMHDR_DOC_DEPT ");
            strSQL.Append("FROM INDEXED.F002_CLAIMS_MSTR_HDR ");
            strSQL.Append("WHERE ");
            strSQL.Append("KEY_CLM_TYPE = ").Append(Common.StringToField("B"));
            strSQL.Append(" AND KEY_CLM_BATCH_NBR = ").Append(Common.StringToField(rdrU997_RMB_SRT.GetString("W_RAT_RMB_CLINIC_NBR") + QDesign.Substring(rdrU997_RMB_SRT.GetString("RAT_RMB_ACCOUNT_NBR"), 1, 6)));
            strSQL.Append(" AND KEY_CLM_CLAIM_NBR = ").Append(QDesign.NConvert(QDesign.Substring(rdrU997_RMB_SRT.GetString("RAT_RMB_ACCOUNT_NBR"), 7, 2)));
            strSQL.Append(" AND KEY_CLM_SERV_CODE = ").Append(Common.StringToField("00000"));
            strSQL.Append(" AND KEY_CLM_ADJ_NBR = ").Append(Common.StringToField("0"));

            rdrF002_CLAIMS_MSTR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

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

            if ((QDesign.NULL(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_LOC")) == QDesign.NULL("B343") | QDesign.NULL(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_LOC")) == QDesign.NULL("B353") | QDesign.NULL(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_LOC")) == QDesign.NULL("B330")) & QDesign.NULL(QDesign.Substring(rdrU997_RMB_SRT.GetString("RAT_RMB_ACCOUNT_NBR"), 1, 3)) == QDesign.NULL("84J") & QDesign.NULL(rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_DOC_DEPT")) == QDesign.NULL(73d) & QDesign.NULL(rdrU997_RMB_SRT.GetString("W_RAT_RMB_CLINIC_NBR")) == QDesign.NULL("22"))
            {
                blnSelected = true;
            }

            return blnSelected;
        }

        #endregion

        #region " DEFINES "

        #endregion

        #region " CONTROLS "

        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.U997_RMB_SRT.DOC_DEPT", DataTypes.Numeric, 2);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.U997_RMB_SRT.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.U997_RMB_SRT.DOC_NAME", DataTypes.Character, 24);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.U997_RMB_SRT.DOC_INITS", DataTypes.Character, 3);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.U997_RMB_SRT.W_RAT_RMB_CLINIC_NBR", DataTypes.Character, 2);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.U997_RMB_SRT.DOC_OHIP_NBR", DataTypes.Numeric, 6);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.U997_RMB_SRT.DOC_SPEC_CD", DataTypes.Numeric, 2);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.U997_RMB_SRT.RAT_RMB_PAYMENT_DATE", DataTypes.Date);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U997_RMB_SRT.RAT_RMB_ACCOUNT_NBR", DataTypes.Character, 8);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U997_RMB_SRT.W_RAT_RMB_LAST_NAME", DataTypes.Character, 9);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U997_RMB_SRT.RAT_RMB_FIRST_NAME", DataTypes.Character, 5);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U997_RMB_SRT.RAT_RMB_PROV_CD", DataTypes.Character, 2);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U997_RMB_SRT.RAT_RMB_PAY_PROG", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U997_RMB_SRT.RAT_RMB_SERVICE_DATE", DataTypes.Date);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U997_RMB_SRT.RAT_RMB_NBR_OF_SERV", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U997_RMB_SRT.RAT_RMB_SERVICE_CD", DataTypes.Character, 5);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U997_RMB_SRT.RAT_RMB_ELIGIBILITY_IND", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U997_RMB_SRT.RAT_RMB_AMOUNT_SUB", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U997_RMB_SRT.RAT_RMB_AMT_PAID", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U997_RMB_SRT.RAT_RMB_EXPLAN_CD", DataTypes.Character, 2);
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
        //# Do not delete, modify or move it.  Updated: 9/28/2017 12:37:40 PM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "TEMPORARYDATA.U997_RMB_SRT.DOC_DEPT":
                    return rdrU997_RMB_SRT.GetNumber("DOC_DEPT").ToString().PadLeft(2, ' ');

                case "TEMPORARYDATA.U997_RMB_SRT.DOC_NBR":
                    return Common.StringToField(rdrU997_RMB_SRT.GetString("DOC_NBR").PadRight(3, ' '));

                case "TEMPORARYDATA.U997_RMB_SRT.DOC_NAME":
                    return Common.StringToField(rdrU997_RMB_SRT.GetString("DOC_NAME").PadRight(24, ' '));

                case "TEMPORARYDATA.U997_RMB_SRT.DOC_INITS":
                    return Common.StringToField(rdrU997_RMB_SRT.GetString("DOC_INITS").PadRight(3, ' '));

                case "TEMPORARYDATA.U997_RMB_SRT.W_RAT_RMB_CLINIC_NBR":
                    return Common.StringToField(rdrU997_RMB_SRT.GetString("W_RAT_RMB_CLINIC_NBR").PadRight(2, ' '));

                case "TEMPORARYDATA.U997_RMB_SRT.DOC_OHIP_NBR":
                    return rdrU997_RMB_SRT.GetNumber("DOC_OHIP_NBR").ToString().PadLeft(6, ' ');

                case "TEMPORARYDATA.U997_RMB_SRT.DOC_SPEC_CD":
                    return rdrU997_RMB_SRT.GetNumber("DOC_SPEC_CD").ToString().PadLeft(2, ' ');

                case "TEMPORARYDATA.U997_RMB_SRT.RAT_RMB_PAYMENT_DATE":
                    return rdrU997_RMB_SRT.GetDate("RAT_RMB_PAYMENT_DATE").ToString() == "1/1/0001 12:00:00 AM" ? "0" : Common.StringToField(rdrU997_RMB_SRT.GetDate("RAT_RMB_PAYMENT_DATE").Year.ToString() + "/" + rdrU997_RMB_SRT.GetDate("RAT_RMB_PAYMENT_DATE").Month.ToString().PadLeft(2, '0') + "/" + rdrU997_RMB_SRT.GetDate("RAT_RMB_PAYMENT_DATE").Day.ToString().PadLeft(2, '0') + " 12:00:00 AM");

                case "TEMPORARYDATA.U997_RMB_SRT.RAT_RMB_ACCOUNT_NBR":
                    return Common.StringToField(rdrU997_RMB_SRT.GetString("RAT_RMB_ACCOUNT_NBR").PadRight(8, ' '));

                case "TEMPORARYDATA.U997_RMB_SRT.W_RAT_RMB_LAST_NAME":
                    return Common.StringToField(rdrU997_RMB_SRT.GetString("W_RAT_RMB_LAST_NAME").PadRight(9, ' '));

                case "TEMPORARYDATA.U997_RMB_SRT.RAT_RMB_FIRST_NAME":
                    return Common.StringToField(rdrU997_RMB_SRT.GetString("RAT_RMB_FIRST_NAME").PadRight(5, ' '));

                case "TEMPORARYDATA.U997_RMB_SRT.RAT_RMB_PROV_CD":
                    return Common.StringToField(rdrU997_RMB_SRT.GetString("RAT_RMB_PROV_CD").PadRight(2, ' '));

                case "TEMPORARYDATA.U997_RMB_SRT.RAT_RMB_PAY_PROG":
                    return Common.StringToField(rdrU997_RMB_SRT.GetString("RAT_RMB_PAY_PROG").PadRight(3, ' '));

                case "TEMPORARYDATA.U997_RMB_SRT.RAT_RMB_SERVICE_DATE":
                    return rdrU997_RMB_SRT.GetDate("RAT_RMB_SERVICE_DATE").ToString() == "1/1/0001 12:00:00 AM" ? "0" : Common.StringToField(rdrU997_RMB_SRT.GetDate("RAT_RMB_SERVICE_DATE").Year.ToString() + "/" + rdrU997_RMB_SRT.GetDate("RAT_RMB_SERVICE_DATE").Month.ToString().PadLeft(2, '0') + "/" + rdrU997_RMB_SRT.GetDate("RAT_RMB_SERVICE_DATE").Day.ToString().PadLeft(2, '0') + " 12:00:00 AM");

                case "TEMPORARYDATA.U997_RMB_SRT.RAT_RMB_NBR_OF_SERV":
                    return rdrU997_RMB_SRT.GetNumber("RAT_RMB_NBR_OF_SERV").ToString().PadLeft(2, ' ');

                case "TEMPORARYDATA.U997_RMB_SRT.RAT_RMB_SERVICE_CD":
                    return Common.StringToField(rdrU997_RMB_SRT.GetString("RAT_RMB_SERVICE_CD").PadRight(5, ' '));

                case "TEMPORARYDATA.U997_RMB_SRT.RAT_RMB_ELIGIBILITY_IND":
                    return Common.StringToField(rdrU997_RMB_SRT.GetString("RAT_RMB_ELIGIBILITY_IND").PadRight(1, ' '));

                case "TEMPORARYDATA.U997_RMB_SRT.RAT_RMB_AMOUNT_SUB":
                    return rdrU997_RMB_SRT.GetNumber("RAT_RMB_AMOUNT_SUB").ToString().PadLeft(6, ' ');

                case "TEMPORARYDATA.U997_RMB_SRT.RAT_RMB_AMT_PAID":
                    return rdrU997_RMB_SRT.GetNumber("RAT_RMB_AMT_PAID").ToString().PadLeft(6, ' ');

                case "TEMPORARYDATA.U997_RMB_SRT.RAT_RMB_EXPLAN_CD":
                    return Common.StringToField(rdrU997_RMB_SRT.GetString("RAT_RMB_EXPLAN_CD").PadRight(2, ' '));

                default:
                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_U997_RMB_SRT();

                while (rdrU997_RMB_SRT.Read())
                {
                    Link_F002_CLAIMS_MSTR();
                    while (rdrF002_CLAIMS_MSTR.Read())
                    {
                        WriteData();
                    }
                    rdrF002_CLAIMS_MSTR.Close();
                }
                rdrU997_RMB_SRT.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrU997_RMB_SRT != null))
            {
                rdrU997_RMB_SRT.Close();
                rdrU997_RMB_SRT = null;
            }
            if ((rdrF002_CLAIMS_MSTR != null))
            {
                rdrF002_CLAIMS_MSTR.Close();
                rdrF002_CLAIMS_MSTR = null;
            }
        }


        #endregion

        #endregion
    }
}
