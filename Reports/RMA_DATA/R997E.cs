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
    public class R997E : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R997E";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrU997_SEL_RMB = new Reader();
        private Reader rdrU997_RMB_SRT = new Reader();

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
                SubFileName = "U997_RMB_SRT";
                SubFileType = SubFileType.Keep;

                Sort = "DOC_DEPT ASC, DOC_NBR ASC, W_RAT_RMB_LAST_NAME ASC, RAT_RMB_FIRST_NAME ASC, RAT_RMB_HEALTH_OHIP_NBR ASC, RAT_RMB_ACCOUNT_NBR ASC";

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

        private void Access_U997_SEL_RMB()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_DEPT, ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("W_RAT_RMB_LAST_NAME, ");
            strSQL.Append("RAT_RMB_FIRST_NAME, ");
            strSQL.Append("RAT_RMB_HEALTH_OHIP_NBR, ");
            strSQL.Append("RAT_RMB_ACCOUNT_NBR, ");
            strSQL.Append("DOC_NAME, ");
            strSQL.Append("DOC_INITS, ");
            strSQL.Append("DOC_OHIP_NBR, ");
            strSQL.Append("DOC_SPEC_CD, ");
            strSQL.Append("RAT_RMB_SERVICE_DATE, ");
            strSQL.Append("W_RAT_RMB_CLINIC_NBR, ");
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
            strSQL.Append("FROM TEMPORARYDATA.U997_SEL_RMB ");

            strSQL.Append(Choose());

            //rdrU997_SEL_RMB.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
            rdrU997_SEL_RMB.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

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

        #endregion

        #region " CONTROLS "

        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U997_SEL_RMB.DOC_DEPT", DataTypes.Numeric, 2);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U997_SEL_RMB.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U997_SEL_RMB.W_RAT_RMB_LAST_NAME", DataTypes.Character, 9);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U997_SEL_RMB.RAT_RMB_FIRST_NAME", DataTypes.Character, 5);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U997_SEL_RMB.RAT_RMB_HEALTH_OHIP_NBR", DataTypes.Character, 12);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U997_SEL_RMB.RAT_RMB_SERVICE_DATE", DataTypes.Numeric, 8);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U997_SEL_RMB.W_RAT_RMB_CLINIC_NBR", DataTypes.Character, 2);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U997_SEL_RMB.DOC_NAME", DataTypes.Character, 24);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U997_SEL_RMB.DOC_INITS", DataTypes.Character, 3);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U997_SEL_RMB.DOC_OHIP_NBR", DataTypes.Numeric, 6);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U997_SEL_RMB.DOC_SPEC_CD", DataTypes.Numeric, 2);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U997_SEL_RMB.RAT_RMB_CLAIM_NBR", DataTypes.Character, 11);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U997_SEL_RMB.RAT_RMB_NBR_OF_SERV", DataTypes.Numeric, 2);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U997_SEL_RMB.RAT_RMB_SERVICE_CD", DataTypes.Character, 5);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U997_SEL_RMB.RAT_RMB_AMOUNT_SUB", DataTypes.Numeric, 6);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U997_SEL_RMB.RAT_RMB_AMT_PAID", DataTypes.Numeric, 6);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U997_SEL_RMB.RAT_RMB_EXPLAN_CD", DataTypes.Character, 2);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U997_SEL_RMB.RAT_RMB_ACCOUNT_NBR", DataTypes.Character, 8);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U997_SEL_RMB.RAT_RMB_PROV_CD", DataTypes.Character, 2);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U997_SEL_RMB.RAT_RMB_VERSION_CD", DataTypes.Character, 2);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U997_SEL_RMB.RAT_RMB_CONV_HEALTH_NBR", DataTypes.Character, 10);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U997_SEL_RMB.RAT_RMB_PAY_PROG", DataTypes.Character, 3);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U997_SEL_RMB.RAT_RMB_ELIGIBILITY_IND", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U997_SEL_RMB.RAT_RMB_PAYMENT_DATE", DataTypes.Numeric, 8);
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
        //# Do not delete, modify or move it.  Updated: 9/29/2017 10:27:15 AM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "TEMPORARYDATA.U997_SEL_RMB.DOC_DEPT":
                    return rdrU997_SEL_RMB.GetNumber("DOC_DEPT").ToString().PadLeft(2, ' ');

                case "TEMPORARYDATA.U997_SEL_RMB.DOC_NBR":
                    return Common.StringToField(rdrU997_SEL_RMB.GetString("DOC_NBR").PadRight(3, ' '));

                case "TEMPORARYDATA.U997_SEL_RMB.W_RAT_RMB_LAST_NAME":
                    return Common.StringToField(rdrU997_SEL_RMB.GetString("W_RAT_RMB_LAST_NAME").PadRight(9, ' '));

                case "TEMPORARYDATA.U997_SEL_RMB.RAT_RMB_FIRST_NAME":
                    return Common.StringToField(rdrU997_SEL_RMB.GetString("RAT_RMB_FIRST_NAME").PadRight(5, ' '));

                case "TEMPORARYDATA.U997_SEL_RMB.RAT_RMB_HEALTH_OHIP_NBR":
                    return Common.StringToField(rdrU997_SEL_RMB.GetString("RAT_RMB_HEALTH_OHIP_NBR").PadRight(12, ' '));

                case "TEMPORARYDATA.U997_SEL_RMB.RAT_RMB_SERVICE_DATE":
                    return rdrU997_SEL_RMB.GetNumber("RAT_RMB_SERVICE_DATE").ToString();

                case "TEMPORARYDATA.U997_SEL_RMB.W_RAT_RMB_CLINIC_NBR":
                    return Common.StringToField(rdrU997_SEL_RMB.GetString("W_RAT_RMB_CLINIC_NBR").PadRight(2, ' '));

                case "TEMPORARYDATA.U997_SEL_RMB.DOC_NAME":
                    return Common.StringToField(rdrU997_SEL_RMB.GetString("DOC_NAME").PadRight(24, ' '));

                case "TEMPORARYDATA.U997_SEL_RMB.DOC_INITS":
                    return Common.StringToField(rdrU997_SEL_RMB.GetString("DOC_INITS").PadRight(3, ' '));

                case "TEMPORARYDATA.U997_SEL_RMB.DOC_OHIP_NBR":
                    return rdrU997_SEL_RMB.GetNumber("DOC_OHIP_NBR").ToString().PadLeft(6, ' ');

                case "TEMPORARYDATA.U997_SEL_RMB.DOC_SPEC_CD":
                    return rdrU997_SEL_RMB.GetNumber("DOC_SPEC_CD").ToString().PadLeft(2, ' ');

                case "TEMPORARYDATA.U997_SEL_RMB.RAT_RMB_CLAIM_NBR":
                    return Common.StringToField(rdrU997_SEL_RMB.GetString("RAT_RMB_CLAIM_NBR").PadRight(11, ' '));

                case "TEMPORARYDATA.U997_SEL_RMB.RAT_RMB_NBR_OF_SERV":
                    return rdrU997_SEL_RMB.GetNumber("RAT_RMB_NBR_OF_SERV").ToString().PadLeft(2, ' ');

                case "TEMPORARYDATA.U997_SEL_RMB.RAT_RMB_SERVICE_CD":
                    return Common.StringToField(rdrU997_SEL_RMB.GetString("RAT_RMB_SERVICE_CD").PadRight(5, ' '));

                case "TEMPORARYDATA.U997_SEL_RMB.RAT_RMB_AMOUNT_SUB":
                    return rdrU997_SEL_RMB.GetNumber("RAT_RMB_AMOUNT_SUB").ToString().PadLeft(6, ' ');

                case "TEMPORARYDATA.U997_SEL_RMB.RAT_RMB_AMT_PAID":
                    return rdrU997_SEL_RMB.GetNumber("RAT_RMB_AMT_PAID").ToString().PadLeft(6, ' ');

                case "TEMPORARYDATA.U997_SEL_RMB.RAT_RMB_EXPLAN_CD":
                    return Common.StringToField(rdrU997_SEL_RMB.GetString("RAT_RMB_EXPLAN_CD").PadRight(2, ' '));

                case "TEMPORARYDATA.U997_SEL_RMB.RAT_RMB_ACCOUNT_NBR":
                    return Common.StringToField(rdrU997_SEL_RMB.GetString("RAT_RMB_ACCOUNT_NBR").PadRight(8, ' '));

                case "TEMPORARYDATA.U997_SEL_RMB.RAT_RMB_PROV_CD":
                    return Common.StringToField(rdrU997_SEL_RMB.GetString("RAT_RMB_PROV_CD").PadRight(2, ' '));

                case "TEMPORARYDATA.U997_SEL_RMB.RAT_RMB_VERSION_CD":
                    return Common.StringToField(rdrU997_SEL_RMB.GetString("RAT_RMB_VERSION_CD").PadRight(2, ' '));

                case "TEMPORARYDATA.U997_SEL_RMB.RAT_RMB_CONV_HEALTH_NBR":
                    return Common.StringToField(rdrU997_SEL_RMB.GetString("RAT_RMB_CONV_HEALTH_NBR").PadRight(10, ' '));

                case "TEMPORARYDATA.U997_SEL_RMB.RAT_RMB_PAY_PROG":
                    return Common.StringToField(rdrU997_SEL_RMB.GetString("RAT_RMB_PAY_PROG").PadRight(3, ' '));

                case "TEMPORARYDATA.U997_SEL_RMB.RAT_RMB_ELIGIBILITY_IND":
                    return Common.StringToField(rdrU997_SEL_RMB.GetString("RAT_RMB_ELIGIBILITY_IND").PadRight(1, ' '));

                case "TEMPORARYDATA.U997_SEL_RMB.RAT_RMB_PAYMENT_DATE":
                    return rdrU997_SEL_RMB.GetNumber("RAT_RMB_PAYMENT_DATE").ToString();

                default:

                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_U997_SEL_RMB();

                while (rdrU997_SEL_RMB.Read())
                {
                    WriteData();
                }
                rdrU997_SEL_RMB.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrU997_SEL_RMB != null))
            {
                rdrU997_SEL_RMB.Close();
                rdrU997_SEL_RMB = null;
            }
        }


        #endregion

        #endregion
    }
}
