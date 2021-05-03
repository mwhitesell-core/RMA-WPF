#region "Screen Comments"

// #> PROGRAM-ID.     R997_PORTAL.QZS
// ((C)) Dyad Technologies
// PROGRAM PURPOSE : PRODUCE R.A. REPORT
// MODIFICATION HISTORY
// DATE SMS # WHO DESCRIPTION
// 90.09.11 131 D.B. ORIGINAL
// 90.12.12  PDR467  M.C. MODIFY THE R997B SECTION TO SPLIT INTO
// TWO PARTS, THERE IS A SORT ERROR DUE
// TO NOT ENOUGH CONTIGUOUS DISK BLOCK;
// HENCE EXTRACT THE REQUIRED FIELDS FROM
// DOCTOR MASTER BEFORE SORTING.
// 90.12.13  PDR469  M.C. CHANGE THE TOTAL LINE OF UNMATCHED OHIP
// PAYMENTS TO BE THE SAME AS THE REGULAR
// DOC TOTAL
// 91.03.09  SMS138  D.B. MODIFY ACCORDING TO NEW MRO
// 92.10.14  SRA152  Y.B. ADD TOTAL FEE PAID (R997H) TO FINAL TOTALS
// 97.10.27  PDR 663 M.C. IN R997I, CHANGE TO PRINT TOTAL CLAIMS
// PAYABLE AT FOOTING INSTEAD OF HEADING
// 98.10.16          B.E. added set report statement 
// 99.12.09          M.C. set noclose is no longer valid, define each
// report with a separate name and merge them 
// together before printing
// y2k - extend date fields
// 03/dec/16  A.A. alpha doctor nbr
// 04/dec/01   M.C. in r997d, use u997_rmb_good instead of
// u030-tape-rmb-file
// 05/may/30  M.C.    clone from r997.qzs
// 05/jul/05  M.C. create r997_portal_a.qzc for detail
// and r997_portal_b.qzc for total
// 06/jan/19   M.C. - add `~` before and after doc nbr & doc dept at the end of each report line

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
    public class R997_PORTAL_A : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R997_PORTAL_A";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrU997_GOOD_SRT = new Reader();

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

                Sort = "DOC_NBR ASC, W_RAT_145_CLINIC_NBR ASC, X_PAY_PGM ASC, W_RAT_145_LAST_NAME ASC, W_RAT_145_FIRST_NAME ASC, RAT_145_HEALTH_OHIP_NBR ASC, RAT_145_ACCOUNT_NBR ASC";

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

        private void Access_U997_GOOD_SRT()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("RAT_145_PAY_PROG, ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("DOC_DEPT, ");
            strSQL.Append("W_RAT_145_CLINIC_NBR, ");
            strSQL.Append("W_RAT_145_LAST_NAME, ");
            strSQL.Append("W_RAT_145_FIRST_NAME, ");
            strSQL.Append("RAT_145_HEALTH_OHIP_NBR, ");
            strSQL.Append("RAT_145_ACCOUNT_NBR, ");
            strSQL.Append("DOC_NAME, ");
            strSQL.Append("DOC_INITS, ");
            strSQL.Append("DOC_OHIP_NBR, ");
            strSQL.Append("DOC_SPEC_CD, ");
            strSQL.Append("RAT_145_PAYMENT_DATE, ");
            strSQL.Append("RAT_145_PROV_CD, ");
            strSQL.Append("RAT_145_VERSION_CD, ");
            strSQL.Append("RAT_145_CONV_HEALTH_NBR, ");
            strSQL.Append("RAT_145_CLAIM_NBR, ");
            strSQL.Append("RAT_145_SERVICE_DATE, ");
            strSQL.Append("RAT_145_NBR_OF_SERV, ");
            strSQL.Append("RAT_145_SERVICE_CD, ");
            strSQL.Append("RAT_145_ELIGIBILITY_IND, ");
            strSQL.Append("RAT_145_AMOUNT_SUB, ");
            strSQL.Append("RAT_145_AMT_PAID, ");
            strSQL.Append("RAT_145_EXPLAN_CD ");
            strSQL.Append("FROM TEMPORARYDATA.U997_GOOD_SRT ");

            strSQL.Append(Choose());

            //rdrU997_GOOD_SRT.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
            rdrU997_GOOD_SRT.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

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

        private decimal X_PAY_PGM()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrU997_GOOD_SRT.GetString("RAT_145_PAY_PROG")) == QDesign.NULL("RMB"))
                {
                    decReturnValue = 2;
                }
                else
                {
                    decReturnValue = 1;
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private string X_DOC_DEPT_NBR()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = "~" + rdrU997_GOOD_SRT.GetString("DOC_NBR") + QDesign.ASCII(rdrU997_GOOD_SRT.GetNumber("DOC_DEPT"), 2) + "~";
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
                AddControl(ReportSection.PAGE_HEADING, "X_DOC_DEPT_NBR", DataTypes.Character, 7);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.U997_GOOD_SRT.DOC_DEPT", DataTypes.Character, 2);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.U997_GOOD_SRT.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.U997_GOOD_SRT.DOC_NAME", DataTypes.Character, 24);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.U997_GOOD_SRT.DOC_INITS", DataTypes.Character, 3);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.U997_GOOD_SRT.W_RAT_145_CLINIC_NBR", DataTypes.Character, 2);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.U997_GOOD_SRT.DOC_OHIP_NBR", DataTypes.Numeric, 6);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.U997_GOOD_SRT.DOC_SPEC_CD", DataTypes.Numeric, 2);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.U997_GOOD_SRT.RAT_145_PAYMENT_DATE", DataTypes.Numeric, 8);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U997_GOOD_SRT.RAT_145_ACCOUNT_NBR", DataTypes.Character, 8);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U997_GOOD_SRT.W_RAT_145_LAST_NAME", DataTypes.Character, 9);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U997_GOOD_SRT.W_RAT_145_FIRST_NAME", DataTypes.Character, 5);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U997_GOOD_SRT.RAT_145_PROV_CD", DataTypes.Character, 2);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U997_GOOD_SRT.RAT_145_HEALTH_OHIP_NBR", DataTypes.Character, 12);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U997_GOOD_SRT.RAT_145_VERSION_CD", DataTypes.Character, 2);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U997_GOOD_SRT.RAT_145_CONV_HEALTH_NBR", DataTypes.Character, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U997_GOOD_SRT.RAT_145_PAY_PROG", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U997_GOOD_SRT.RAT_145_CLAIM_NBR", DataTypes.Character, 11);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U997_GOOD_SRT.RAT_145_SERVICE_DATE", DataTypes.Numeric, 8);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U997_GOOD_SRT.RAT_145_NBR_OF_SERV", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U997_GOOD_SRT.RAT_145_SERVICE_CD", DataTypes.Character, 5);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U997_GOOD_SRT.RAT_145_ELIGIBILITY_IND", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U997_GOOD_SRT.RAT_145_AMOUNT_SUB", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U997_GOOD_SRT.RAT_145_AMT_PAID", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U997_GOOD_SRT.RAT_145_EXPLAN_CD", DataTypes.Character, 2);
                AddControl(ReportSection.REPORT, "X_PAY_PGM", DataTypes.Numeric, 0);
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
        //# Do not delete, modify or move it.  Updated: 9/28/2017 1:09:34 PM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "X_DOC_DEPT_NBR":
                    return Common.StringToField(X_DOC_DEPT_NBR().PadRight(7, ' '));

                case "TEMPORARYDATA.U997_GOOD_SRT.DOC_DEPT":
                    return Common.StringToField(rdrU997_GOOD_SRT.GetString("DOC_DEPT").PadRight(2, ' '));

                case "TEMPORARYDATA.U997_GOOD_SRT.DOC_NBR":
                    return Common.StringToField(rdrU997_GOOD_SRT.GetString("DOC_NBR").PadRight(3, ' '));

                case "TEMPORARYDATA.U997_GOOD_SRT.DOC_NAME":
                    return Common.StringToField(rdrU997_GOOD_SRT.GetString("DOC_NAME").PadRight(24, ' '));

                case "TEMPORARYDATA.U997_GOOD_SRT.DOC_INITS":
                    return Common.StringToField(rdrU997_GOOD_SRT.GetString("DOC_INITS").PadRight(3, ' '));

                case "TEMPORARYDATA.U997_GOOD_SRT.W_RAT_145_CLINIC_NBR":
                    return Common.StringToField(rdrU997_GOOD_SRT.GetString("W_RAT_145_CLINIC_NBR").PadRight(2, ' '));

                case "TEMPORARYDATA.U997_GOOD_SRT.DOC_OHIP_NBR":
                    return rdrU997_GOOD_SRT.GetNumber("DOC_OHIP_NBR").ToString().PadLeft(6, ' ');

                case "TEMPORARYDATA.U997_GOOD_SRT.DOC_SPEC_CD":
                    return rdrU997_GOOD_SRT.GetNumber("DOC_SPEC_CD").ToString().PadLeft(2, ' ');

                case "TEMPORARYDATA.U997_GOOD_SRT.RAT_145_PAYMENT_DATE":
                    return rdrU997_GOOD_SRT.GetNumber("RAT_145_PAYMENT_DATE").ToString().PadLeft(10, ' ');

                case "TEMPORARYDATA.U997_GOOD_SRT.RAT_145_ACCOUNT_NBR":
                    return Common.StringToField(rdrU997_GOOD_SRT.GetString("RAT_145_ACCOUNT_NBR").PadRight(8, ' '));

                case "TEMPORARYDATA.U997_GOOD_SRT.W_RAT_145_LAST_NAME":
                    return Common.StringToField(rdrU997_GOOD_SRT.GetString("W_RAT_145_LAST_NAME").PadRight(9, ' '));

                case "TEMPORARYDATA.U997_GOOD_SRT.W_RAT_145_FIRST_NAME":
                    return Common.StringToField(rdrU997_GOOD_SRT.GetString("W_RAT_145_FIRST_NAME").PadRight(5, ' '));

                case "TEMPORARYDATA.U997_GOOD_SRT.RAT_145_PROV_CD":
                    return Common.StringToField(rdrU997_GOOD_SRT.GetString("RAT_145_PROV_CD").PadRight(2, ' '));

                case "TEMPORARYDATA.U997_GOOD_SRT.RAT_145_HEALTH_OHIP_NBR":
                    return Common.StringToField(rdrU997_GOOD_SRT.GetString("RAT_145_HEALTH_OHIP_NBR").PadRight(12, ' '));

                case "TEMPORARYDATA.U997_GOOD_SRT.RAT_145_VERSION_CD":
                    return Common.StringToField(rdrU997_GOOD_SRT.GetString("RAT_145_VERSION_CD").PadRight(2, ' '));

                case "TEMPORARYDATA.U997_GOOD_SRT.RAT_145_CONV_HEALTH_NBR":
                    return Common.StringToField(rdrU997_GOOD_SRT.GetString("RAT_145_CONV_HEALTH_NBR").PadRight(10, ' '));

                case "TEMPORARYDATA.U997_GOOD_SRT.RAT_145_PAY_PROG":
                    return Common.StringToField(rdrU997_GOOD_SRT.GetString("RAT_145_PAY_PROG").PadRight(3, ' '));

                case "TEMPORARYDATA.U997_GOOD_SRT.RAT_145_CLAIM_NBR":
                    return Common.StringToField(rdrU997_GOOD_SRT.GetString("RAT_145_CLAIM_NBR").PadRight(11, ' '));

                case "TEMPORARYDATA.U997_GOOD_SRT.RAT_145_SERVICE_DATE":
                    return rdrU997_GOOD_SRT.GetNumber("RAT_145_SERVICE_DATE").ToString().PadLeft(10, ' ');

                case "TEMPORARYDATA.U997_GOOD_SRT.RAT_145_NBR_OF_SERV":
                    return rdrU997_GOOD_SRT.GetNumber("RAT_145_NBR_OF_SERV").ToString().PadLeft(2, ' ');

                case "TEMPORARYDATA.U997_GOOD_SRT.RAT_145_SERVICE_CD":
                    return Common.StringToField(rdrU997_GOOD_SRT.GetString("RAT_145_SERVICE_CD").PadRight(5, ' '));

                case "TEMPORARYDATA.U997_GOOD_SRT.RAT_145_ELIGIBILITY_IND":
                    return Common.StringToField(rdrU997_GOOD_SRT.GetString("RAT_145_ELIGIBILITY_IND").PadRight(1, ' '));

                case "TEMPORARYDATA.U997_GOOD_SRT.RAT_145_AMOUNT_SUB":
                    return rdrU997_GOOD_SRT.GetNumber("RAT_145_AMOUNT_SUB").ToString().PadLeft(6, ' ');

                case "TEMPORARYDATA.U997_GOOD_SRT.RAT_145_AMT_PAID":
                    return rdrU997_GOOD_SRT.GetNumber("RAT_145_AMT_PAID").ToString().PadLeft(6, ' ');

                case "TEMPORARYDATA.U997_GOOD_SRT.RAT_145_EXPLAN_CD":
                    return Common.StringToField(rdrU997_GOOD_SRT.GetString("RAT_145_EXPLAN_CD").PadRight(2, ' '));

                case "X_PAY_PGM":
                    return X_PAY_PGM().ToString().ToString().PadLeft(0, ' ');

                default:
                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_U997_GOOD_SRT();

                while (rdrU997_GOOD_SRT.Read())
                {
                    WriteData();
                }
                rdrU997_GOOD_SRT.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrU997_GOOD_SRT != null))
            {
                rdrU997_GOOD_SRT.Close();
                rdrU997_GOOD_SRT = null;
            }
        }


        #endregion

        #endregion
    }
}
