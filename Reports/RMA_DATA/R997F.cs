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
    public class R997F : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R997F";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrU997_BAD = new Reader();
        private Reader rdrF010_PAT_MSTR = new Reader();

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

                Sort = "RAT_145_DOC_NBR ASC, RAT_145_ACCOUNT_NBR ASC";

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

        private void Access_U997_BAD()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("RAT_145_HEALTH_OHIP_NBR, ");
            strSQL.Append("RAT_145_DOC_NBR, ");
            strSQL.Append("RAT_145_ACCOUNT_NBR, ");
            strSQL.Append("RAT_145_LAST_NAME, ");
            strSQL.Append("RAT_145_FIRST_NAME, ");
            strSQL.Append("RAT_145_PROV_CD, ");
            strSQL.Append("RAT_145_VERSION_CD, ");
            strSQL.Append("RAT_145_CONV_HEALTH_NBR, ");
            strSQL.Append("RAT_145_PAY_PROG, ");
            strSQL.Append("RAT_145_CLAIM_NBR, ");
            strSQL.Append("RAT_145_SERVICE_DATE, ");
            strSQL.Append("RAT_145_NBR_OF_SERV, ");
            strSQL.Append("RAT_145_SERVICE_CD, ");
            strSQL.Append("RAT_145_ELIGIBILITY_IND, ");
            strSQL.Append("RAT_145_AMOUNT_SUB, ");
            strSQL.Append("RAT_145_AMT_PAID, ");
            strSQL.Append("RAT_145_EXPLAN_CD ");
            strSQL.Append("FROM TEMPORARYDATA.U997_BAD ");

            strSQL.Append(Choose());

            //rdrU997_BAD.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
            rdrU997_BAD.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

            strSQL = null;
        }

        private void Link_F010_PAT_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("PAT_HEALTH_NBR, ");
            strSQL.Append("PAT_SURNAME_FIRST3, ");
            strSQL.Append("PAT_SURNAME_LAST22, ");
            strSQL.Append("PAT_GIVEN_NAME_FIRST1, ");
            strSQL.Append("FILLER3 ");
            strSQL.Append("FROM INDEXED.F010_PAT_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("PAT_HEALTH_NBR = ").Append(QDesign.NConvert(rdrU997_BAD.GetString("RAT_145_HEALTH_OHIP_NBR")));

            rdrF010_PAT_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

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

        private string W_RAT_145_LAST_NAME()
        {
            string strReturnValue = string.Empty;

            try
            {
                if (QDesign.NULL(rdrU997_BAD.GetString("RAT_145_LAST_NAME")) != QDesign.NULL(" "))
                {
                    strReturnValue = QDesign.Substring(rdrU997_BAD.GetString("RAT_145_LAST_NAME"), 1, 9);
                }
                else
                {
                    strReturnValue = QDesign.Substring(rdrF010_PAT_MSTR.GetString("PAT_SURNAME_FIRST3") + rdrF010_PAT_MSTR.GetString("PAT_SURNAME_LAST19"), 1, 9);
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string W_RAT_145_FIRST_NAME()
        {
            string strReturnValue = string.Empty;

            try
            {
                if (QDesign.NULL(rdrU997_BAD.GetString("RAT_145_FIRST_NAME")) != QDesign.NULL(" "))
                {
                    strReturnValue = QDesign.Substring(rdrU997_BAD.GetString("RAT_145_FIRST_NAME"), 1, 5);
                }
                else
                {
                    strReturnValue = QDesign.Substring(rdrF010_PAT_MSTR.GetString("PAT_GIVEN_NAME_FIRST1") + rdrF010_PAT_MSTR.GetString("FILLER3"), 1, 5);
                }
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
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.U997_BAD.RAT_145_DOC_NBR", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U997_BAD.RAT_145_ACCOUNT_NBR", DataTypes.Character, 8);
                AddControl(ReportSection.REPORT, "W_RAT_145_LAST_NAME", DataTypes.Character, 9);
                AddControl(ReportSection.REPORT, "W_RAT_145_FIRST_NAME", DataTypes.Character, 5);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U997_BAD.RAT_145_PROV_CD", DataTypes.Character, 2);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U997_BAD.RAT_145_HEALTH_OHIP_NBR", DataTypes.Character, 12);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U997_BAD.RAT_145_VERSION_CD", DataTypes.Character, 2);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U997_BAD.RAT_145_CONV_HEALTH_NBR", DataTypes.Character, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U997_BAD.RAT_145_PAY_PROG", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U997_BAD.RAT_145_CLAIM_NBR", DataTypes.Character, 11);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U997_BAD.RAT_145_SERVICE_DATE", DataTypes.Numeric, 8);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U997_BAD.RAT_145_NBR_OF_SERV", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U997_BAD.RAT_145_SERVICE_CD", DataTypes.Character, 5);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U997_BAD.RAT_145_ELIGIBILITY_IND", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U997_BAD.RAT_145_AMOUNT_SUB", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U997_BAD.RAT_145_AMT_PAID", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U997_BAD.RAT_145_EXPLAN_CD", DataTypes.Character, 2);
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
        //# Do not delete, modify or move it.  Updated: 9/29/2017 10:35:18 AM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "TEMPORARYDATA.U997_BAD.RAT_145_DOC_NBR":
                    return rdrU997_BAD.GetNumber("RAT_145_DOC_NBR").ToString().PadLeft(6, ' ');

                case "TEMPORARYDATA.U997_BAD.RAT_145_ACCOUNT_NBR":
                    return Common.StringToField(rdrU997_BAD.GetString("RAT_145_ACCOUNT_NBR").PadRight(8, ' '));

                case "W_RAT_145_LAST_NAME":
                    return Common.StringToField(W_RAT_145_LAST_NAME().PadRight(9, ' '));

                case "W_RAT_145_FIRST_NAME":
                    return Common.StringToField(W_RAT_145_FIRST_NAME().PadRight(5, ' '));

                case "TEMPORARYDATA.U997_BAD.RAT_145_PROV_CD":
                    return Common.StringToField(rdrU997_BAD.GetString("RAT_145_PROV_CD").PadRight(2, ' '));

                case "TEMPORARYDATA.U997_BAD.RAT_145_HEALTH_OHIP_NBR":
                    return Common.StringToField(rdrU997_BAD.GetString("RAT_145_HEALTH_OHIP_NBR").PadRight(12, ' '));

                case "TEMPORARYDATA.U997_BAD.RAT_145_VERSION_CD":
                    return Common.StringToField(rdrU997_BAD.GetString("RAT_145_VERSION_CD").PadRight(2, ' '));

                case "TEMPORARYDATA.U997_BAD.RAT_145_CONV_HEALTH_NBR":
                    return Common.StringToField(rdrU997_BAD.GetString("RAT_145_CONV_HEALTH_NBR").PadRight(10, ' '));

                case "TEMPORARYDATA.U997_BAD.RAT_145_PAY_PROG":
                    return Common.StringToField(rdrU997_BAD.GetString("RAT_145_PAY_PROG").PadRight(3, ' '));

                case "TEMPORARYDATA.U997_BAD.RAT_145_CLAIM_NBR":
                    return Common.StringToField(rdrU997_BAD.GetString("RAT_145_CLAIM_NBR").PadRight(11, ' '));

                case "TEMPORARYDATA.U997_BAD.RAT_145_SERVICE_DATE":
                    return rdrU997_BAD.GetNumber("RAT_145_SERVICE_DATE").ToString();

                case "TEMPORARYDATA.U997_BAD.RAT_145_NBR_OF_SERV":
                    return rdrU997_BAD.GetNumber("RAT_145_NBR_OF_SERV").ToString().PadLeft(2, ' ');

                case "TEMPORARYDATA.U997_BAD.RAT_145_SERVICE_CD":
                    return Common.StringToField(rdrU997_BAD.GetString("RAT_145_SERVICE_CD").PadRight(5, ' '));

                case "TEMPORARYDATA.U997_BAD.RAT_145_ELIGIBILITY_IND":
                    return Common.StringToField(rdrU997_BAD.GetString("RAT_145_ELIGIBILITY_IND").PadRight(1, ' '));

                case "TEMPORARYDATA.U997_BAD.RAT_145_AMOUNT_SUB":
                    return rdrU997_BAD.GetNumber("RAT_145_AMOUNT_SUB").ToString().PadLeft(6, ' ');

                case "TEMPORARYDATA.U997_BAD.RAT_145_AMT_PAID":
                    return rdrU997_BAD.GetNumber("RAT_145_AMT_PAID").ToString().PadLeft(6, ' ');

                case "TEMPORARYDATA.U997_BAD.RAT_145_EXPLAN_CD":
                    return Common.StringToField(rdrU997_BAD.GetString("RAT_145_EXPLAN_CD").PadRight(2, ' '));

                default:
                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_U997_BAD();

                while (rdrU997_BAD.Read())
                {
                    Link_F010_PAT_MSTR();
                    while (rdrF010_PAT_MSTR.Read())
                    {
                        WriteData();
                    }
                    rdrF010_PAT_MSTR.Close();
                }
                rdrU997_BAD.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrU997_BAD != null))
            {
                rdrU997_BAD.Close();
                rdrU997_BAD = null;
            }
            if ((rdrF010_PAT_MSTR != null))
            {
                rdrF010_PAT_MSTR.Close();
                rdrF010_PAT_MSTR = null;
            }
        }


        #endregion

        #endregion
    }
}
