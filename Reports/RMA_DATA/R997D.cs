#region "Screen Comments"

// 2004/12/01 - MC -- use u997_rmb_good instead
// access u030-tape-rmb-file &
// 2004/12/01 - end
// ! link (nconvert(rat-rmb-account-nbr[1:3])) to doc-nbr &

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
    public class R997D : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R997D";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrU997_RMB_GOOD = new Reader();
        private Reader rdrF020_DOCTOR_MSTR = new Reader();
        private Reader rdrU997_SEL_RMB = new Reader();

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
                // Create Subfile.
                SubFile = true;
                SubFileName = "U997_SEL_RMB";
                SubFileType = SubFileType.KeepSQL;

                Sort = "";

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

        private void Access_U997_RMB_GOOD()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("RAT_RMB_ACCOUNT_NBR, ");
            strSQL.Append("RAT_RMB_GROUP_NBR, ");
            strSQL.Append("RAT_RMB_LAST_NAME, ");
            strSQL.Append("RAT_RMB_FIRST_NAME, ");
            strSQL.Append("RAT_RMB_HEALTH_OHIP_NBR, ");
            strSQL.Append("RAT_RMB_SERVICE_DATE, ");
            strSQL.Append("RAT_RMB_CLAIM_NBR, ");
            strSQL.Append("RAT_RMB_NBR_OF_SERV, ");
            strSQL.Append("RAT_RMB_SERVICE_CD, ");
            strSQL.Append("RAT_RMB_AMOUNT_SUB, ");
            strSQL.Append("RAT_RMB_AMT_PAID, ");
            strSQL.Append("RAT_RMB_EXPLAN_CD, ");
            strSQL.Append("RAT_RMB_PROV_CD, ");
            strSQL.Append("RAT_RMB_VERSION_CD, ");
            strSQL.Append("RAT_RMB_CONV_HEALTH_NBR, ");
            strSQL.Append("RAT_RMB_PAY_PROG, ");
            strSQL.Append("RAT_RMB_ELIGIBILITY_IND, ");
            strSQL.Append("RAT_RMB_PAYMENT_DATE ");
            strSQL.Append("FROM TEMPORARYDATA.U997_RMB_GOOD ");

            strSQL.Append(Choose());

            //rdrU997_RMB_GOOD.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
            rdrU997_RMB_GOOD.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

            strSQL = null;
        }

        private void Link_F020_DOCTOR_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("DOC_DEPT, ");
            strSQL.Append("DOC_NAME, ");
            strSQL.Append("DOC_INIT1, ");
            strSQL.Append("DOC_INIT2, ");
            strSQL.Append("DOC_INIT3, ");
            strSQL.Append("DOC_OHIP_NBR, ");
            strSQL.Append("DOC_SPEC_CD ");
            strSQL.Append("FROM INDEXED.F020_DOCTOR_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_NBR = ").Append(Common.StringToField(QDesign.Substring(rdrU997_RMB_GOOD.GetString("RAT_RMB_ACCOUNT_NBR"), 1, 3)));

            rdrF020_DOCTOR_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

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

        #endregion

        #region " DEFINES "

        private string W_RAT_RMB_CLINIC_NBR()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.Substring(rdrU997_RMB_GOOD.GetString("RAT_RMB_GROUP_NBR"), 1, 2);
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string W_RAT_RMB_LAST_NAME()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.Substring(rdrU997_RMB_GOOD.GetString("RAT_RMB_LAST_NAME"), 1, 9);
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string F020_DOCTOR_MSTR_DOC_INITS()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = (rdrF020_DOCTOR_MSTR.GetString("DOC_INIT1") + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT2") + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT3"));
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
                AddControl(ReportSection.SUMMARY, "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT", DataTypes.Numeric, 2);
                AddControl(ReportSection.SUMMARY, "INDEXED.F020_DOCTOR_MSTR.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.SUMMARY, "W_RAT_RMB_LAST_NAME", DataTypes.Character, 9);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U997_RMB_GOOD.RAT_RMB_FIRST_NAME", DataTypes.Character, 5);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U997_RMB_GOOD.RAT_RMB_HEALTH_OHIP_NBR", DataTypes.Character, 12);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U997_RMB_GOOD.RAT_RMB_SERVICE_DATE", DataTypes.Numeric, 8);
                AddControl(ReportSection.SUMMARY, "W_RAT_RMB_CLINIC_NBR", DataTypes.Character, 2);
                AddControl(ReportSection.SUMMARY, "INDEXED.F020_DOCTOR_MSTR.DOC_NAME", DataTypes.Character, 24);
                AddControl(ReportSection.SUMMARY, "DOC_INITS", DataTypes.Character, 3);
                AddControl(ReportSection.SUMMARY, "INDEXED.F020_DOCTOR_MSTR.DOC_OHIP_NBR", DataTypes.Numeric, 6);
                AddControl(ReportSection.SUMMARY, "INDEXED.F020_DOCTOR_MSTR.DOC_SPEC_CD", DataTypes.Numeric, 2);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U997_RMB_GOOD.RAT_RMB_CLAIM_NBR", DataTypes.Character, 11);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U997_RMB_GOOD.RAT_RMB_NBR_OF_SERV", DataTypes.Numeric, 2);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U997_RMB_GOOD.RAT_RMB_SERVICE_CD", DataTypes.Character, 5);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U997_RMB_GOOD.RAT_RMB_AMOUNT_SUB", DataTypes.Numeric, 6);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U997_RMB_GOOD.RAT_RMB_AMT_PAID", DataTypes.Numeric, 6);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U997_RMB_GOOD.RAT_RMB_EXPLAN_CD", DataTypes.Character, 2);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U997_RMB_GOOD.RAT_RMB_ACCOUNT_NBR", DataTypes.Character, 8);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U997_RMB_GOOD.RAT_RMB_PROV_CD", DataTypes.Character, 2);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U997_RMB_GOOD.RAT_RMB_VERSION_CD", DataTypes.Character, 2);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U997_RMB_GOOD.RAT_RMB_CONV_HEALTH_NBR", DataTypes.Character, 10);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U997_RMB_GOOD.RAT_RMB_PAY_PROG", DataTypes.Character, 3);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U997_RMB_GOOD.RAT_RMB_ELIGIBILITY_IND", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U997_RMB_GOOD.RAT_RMB_PAYMENT_DATE", DataTypes.Numeric, 8);
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
        //# Do not delete, modify or move it.  Updated: 9/29/2017 10:10:36 AM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT":
                    return rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT").ToString().PadLeft(2, ' ');

                case "INDEXED.F020_DOCTOR_MSTR.DOC_NBR":
                    return Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_NBR").PadRight(3, ' '));

                case "W_RAT_RMB_LAST_NAME":
                    return Common.StringToField(W_RAT_RMB_LAST_NAME().PadRight(9, ' '));

                case "TEMPORARYDATA.U997_RMB_GOOD.RAT_RMB_FIRST_NAME":
                    return Common.StringToField(rdrU997_RMB_GOOD.GetString("RAT_RMB_FIRST_NAME").PadRight(5, ' '));

                case "TEMPORARYDATA.U997_RMB_GOOD.RAT_RMB_HEALTH_OHIP_NBR":
                    return Common.StringToField(rdrU997_RMB_GOOD.GetString("RAT_RMB_HEALTH_OHIP_NBR").PadRight(12, ' '));

                case "TEMPORARYDATA.U997_RMB_GOOD.RAT_RMB_SERVICE_DATE":
                    return rdrU997_RMB_GOOD.GetNumber("RAT_RMB_SERVICE_DATE").ToString();

                case "W_RAT_RMB_CLINIC_NBR":
                    return Common.StringToField(W_RAT_RMB_CLINIC_NBR().PadRight(2, ' '));

                case "INDEXED.F020_DOCTOR_MSTR.DOC_NAME":
                    return Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_NAME").PadRight(24, ' '));

                case "DOC_INITS":
                    return Common.StringToField(F020_DOCTOR_MSTR_DOC_INITS().PadRight(3, ' '));

                case "INDEXED.F020_DOCTOR_MSTR.DOC_OHIP_NBR":
                    return rdrF020_DOCTOR_MSTR.GetNumber("DOC_OHIP_NBR").ToString().PadLeft(6, ' ');

                case "INDEXED.F020_DOCTOR_MSTR.DOC_SPEC_CD":
                    return rdrF020_DOCTOR_MSTR.GetNumber("DOC_SPEC_CD").ToString().PadLeft(2, ' ');

                case "TEMPORARYDATA.U997_RMB_GOOD.RAT_RMB_CLAIM_NBR":
                    return Common.StringToField(rdrU997_RMB_GOOD.GetString("RAT_RMB_CLAIM_NBR").PadRight(11, ' '));

                case "TEMPORARYDATA.U997_RMB_GOOD.RAT_RMB_NBR_OF_SERV":
                    return rdrU997_RMB_GOOD.GetNumber("RAT_RMB_NBR_OF_SERV").ToString().PadLeft(2, ' ');

                case "TEMPORARYDATA.U997_RMB_GOOD.RAT_RMB_SERVICE_CD":
                    return Common.StringToField(rdrU997_RMB_GOOD.GetString("RAT_RMB_SERVICE_CD").PadRight(5, ' '));

                case "TEMPORARYDATA.U997_RMB_GOOD.RAT_RMB_AMOUNT_SUB":
                    return rdrU997_RMB_GOOD.GetNumber("RAT_RMB_AMOUNT_SUB").ToString().PadLeft(6, ' ');

                case "TEMPORARYDATA.U997_RMB_GOOD.RAT_RMB_AMT_PAID":
                    return rdrU997_RMB_GOOD.GetNumber("RAT_RMB_AMT_PAID").ToString().PadLeft(6, ' ');

                case "TEMPORARYDATA.U997_RMB_GOOD.RAT_RMB_EXPLAN_CD":
                    return Common.StringToField(rdrU997_RMB_GOOD.GetString("RAT_RMB_EXPLAN_CD").PadRight(2, ' '));

                case "TEMPORARYDATA.U997_RMB_GOOD.RAT_RMB_ACCOUNT_NBR":
                    return Common.StringToField(rdrU997_RMB_GOOD.GetString("RAT_RMB_ACCOUNT_NBR").PadRight(8, ' '));

                case "TEMPORARYDATA.U997_RMB_GOOD.RAT_RMB_PROV_CD":
                    return Common.StringToField(rdrU997_RMB_GOOD.GetString("RAT_RMB_PROV_CD").PadRight(2, ' '));

                case "TEMPORARYDATA.U997_RMB_GOOD.RAT_RMB_VERSION_CD":
                    return Common.StringToField(rdrU997_RMB_GOOD.GetString("RAT_RMB_VERSION_CD").PadRight(2, ' '));

                case "TEMPORARYDATA.U997_RMB_GOOD.RAT_RMB_CONV_HEALTH_NBR":
                    return Common.StringToField(rdrU997_RMB_GOOD.GetString("RAT_RMB_CONV_HEALTH_NBR").PadRight(10, ' '));

                case "TEMPORARYDATA.U997_RMB_GOOD.RAT_RMB_PAY_PROG":
                    return Common.StringToField(rdrU997_RMB_GOOD.GetString("RAT_RMB_PAY_PROG").PadRight(3, ' '));

                case "TEMPORARYDATA.U997_RMB_GOOD.RAT_RMB_ELIGIBILITY_IND":
                    return Common.StringToField(rdrU997_RMB_GOOD.GetString("RAT_RMB_ELIGIBILITY_IND").PadRight(1, ' '));

                case "TEMPORARYDATA.U997_RMB_GOOD.RAT_RMB_PAYMENT_DATE":
                    return rdrU997_RMB_GOOD.GetNumber("RAT_RMB_PAYMENT_DATE").ToString();

                default:

                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_U997_RMB_GOOD();

                while (rdrU997_RMB_GOOD.Read())
                {
                    Link_F020_DOCTOR_MSTR();
                    while (rdrF020_DOCTOR_MSTR.Read())
                    {
                        WriteData();
                    }
                    rdrF020_DOCTOR_MSTR.Close();
                }
                rdrU997_RMB_GOOD.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrU997_RMB_GOOD != null))
            {
                rdrU997_RMB_GOOD.Close();
                rdrU997_RMB_GOOD = null;
            }
            if ((rdrF020_DOCTOR_MSTR != null))
            {
                rdrF020_DOCTOR_MSTR.Close();
                rdrF020_DOCTOR_MSTR = null;
            }
        }


        #endregion

        #endregion
    }
}
