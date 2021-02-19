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
    public class R150_PAYEFT_CHECK__PASS2 : BaseRDLClass
    {
        protected const string REPORT_NAME = "R150_PAYEFT_CHECK__PASS2";
        protected const bool REPORT_HAS_PARAMETERS = true;
        private Reader rdrF110_COMPENSATION = new Reader();
        private Reader rdrF119_DOCTOR_YTD_HISTORY = new Reader();
        private Reader rdrSAVEF110F119 = new Reader();
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
                SubFileName = "SAVEF110F119";
                SubFileType = SubFileType.Keep;
                SubFileAT = "TODO: Enter sortbreak name";
                Sort = "";
                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return ReportData;
        }
        private void Access_F110_COMPENSATION()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("EP_NBR, ");
            strSQL.Append("COMP_CODE, ");
            strSQL.Append("AMT_NET ");
            strSQL.Append("FROM INDEXED.F110_COMPENSATION ");
            strSQL.Append(Choose());
            strSQL.Append(SelectIf_F110_COMPENSATION(false));
            rdrF110_COMPENSATION.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_F119_DOCTOR_YTD_HISTORY()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("EP_NBR, ");
            strSQL.Append("REC_TYPE, ");
            strSQL.Append("COMP_CODE, ");
            strSQL.Append("AMT_MTD ");
            strSQL.Append("FROM INDEXED.F119_DOCTOR_YTD_HISTORY ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_NBR = ").Append(Common.StringToField(rdrF110_COMPENSATION.GetString("DOC_NBR")));
            strSQL.Append(" AND EP_NBR = ").Append(rdrF110_COMPENSATION.GetNumber("EP_NBR"));
            strSQL.Append(" AND REC_TYPE = ").Append(Common.StringToField("A"));
            strSQL.Append(SelectIf_F119_DOCTOR_YTD_HISTORY(false));
            rdrF119_DOCTOR_YTD_HISTORY.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(String.Empty);
            // TODO: CHOOSE Statement - May require manual changes.
            strChoose.Append("WHERE EP_NBR BETWEEN " + ReportFunctions.astrScreenParameters[0] + " AND " + ReportFunctions.astrScreenParameters[1]);
            return strChoose.ToString().ToString();
        }

        private string SelectIf_F110_COMPENSATION(bool blnAddWhere)
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
            strSQL.Append("     COMP_CODE =  'PAYEFT'");
            return strSQL.ToString().ToString();
        }

        private string SelectIf_F119_DOCTOR_YTD_HISTORY(bool blnAddWhere)
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
            strSQL.Append("     COMP_CODE =  'PAYEFT'");
            return strSQL.ToString().ToString();
        }
        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.SUMMARY, "INDEXED.F110_COMPENSATION.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.SUMMARY, "INDEXED.F110_COMPENSATION.EP_NBR", DataTypes.Numeric, 6);
                AddControl(ReportSection.SUMMARY, "INDEXED.F110_COMPENSATION.COMP_CODE", DataTypes.Character, 6);
                AddControl(ReportSection.SUMMARY, "INDEXED.F110_COMPENSATION.AMT_NET", DataTypes.Numeric, 9);
                AddControl(ReportSection.SUMMARY, "INDEXED.F119_DOCTOR_YTD_HISTORY.AMT_MTD", DataTypes.Numeric, 9);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2019-07-23 1:56:07 PM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "INDEXED.F110_COMPENSATION.DOC_NBR":
                    return Common.StringToField(rdrF110_COMPENSATION.GetString("DOC_NBR"));
                case "INDEXED.F110_COMPENSATION.EP_NBR":
                    return rdrF110_COMPENSATION.GetNumber("EP_NBR").ToString();
                case "INDEXED.F110_COMPENSATION.COMP_CODE":
                    return Common.StringToField(rdrF110_COMPENSATION.GetString("COMP_CODE"));
                case "INDEXED.F110_COMPENSATION.AMT_NET":
                    return rdrF110_COMPENSATION.GetNumber("AMT_NET").ToString();
                case "INDEXED.F119_DOCTOR_YTD_HISTORY.AMT_MTD":
                    return rdrF119_DOCTOR_YTD_HISTORY.GetNumber("AMT_MTD").ToString();
                default:
                    return String.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                // TODO: Some manual steps maybe required.
                Access_F110_COMPENSATION();
                while (rdrF110_COMPENSATION.Read())
                {
                    Link_F119_DOCTOR_YTD_HISTORY();
                    while (rdrF119_DOCTOR_YTD_HISTORY.Read())
                    {
                        WriteData();
                    }

                    rdrF119_DOCTOR_YTD_HISTORY.Close();
                }

                rdrF110_COMPENSATION.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if (!(rdrF110_COMPENSATION == null))
            {
                rdrF110_COMPENSATION.Close();
                rdrF110_COMPENSATION = null;
            }

            if (!(rdrF119_DOCTOR_YTD_HISTORY == null))
            {
                rdrF119_DOCTOR_YTD_HISTORY.Close();
                rdrF119_DOCTOR_YTD_HISTORY = null;
            }
        }
    }
}
