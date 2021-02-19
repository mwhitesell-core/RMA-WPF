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
    public class UTL0011 : BaseRDLClass
    {
        protected const string REPORT_NAME = "UTL0011";
        protected const bool REPORT_HAS_PARAMETERS = false;

        private Reader rdrF010_PAT_MSTR = new Reader();
        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                //  Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;
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

        private void Access_F010_PAT_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            strSQL.Append("SELECT ");
            strSQL.Append("PAT_HEALTH_NBR, ");
            strSQL.Append("PAT_CHART_NBR, ");
            strSQL.Append("PAT_SURNAME_FIRST3, ");
            strSQL.Append("PAT_SURNAME_LAST22, ");
            strSQL.Append("PAT_GIVEN_NAME_FIRST1, ");
            strSQL.Append("FILLER3, ");
            strSQL.Append("PAT_BIRTH_DATE_YY, ");
            strSQL.Append("PAT_BIRTH_DATE_MM, ");
            strSQL.Append("PAT_BIRTH_DATE_DD ");
            strSQL.Append("FROM INDEXED.F010_PAT_MSTR ");

            strSQL.Append(Choose());

            rdrF010_PAT_MSTR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

            strSQL = null;
        }

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(String.Empty);

            return strChoose.ToString().ToString();
        }

        private string F010_PAT_MSTR_PAT_SURNAME()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = rdrF010_PAT_MSTR.GetString("PAT_SURNAME_FIRST3") + rdrF010_PAT_MSTR.GetString("PAT_SURNAME_LAST22");
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
            return strReturnValue;
        }

        private string F010_PAT_MSTR_PAT_GIVEN_NAME()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = rdrF010_PAT_MSTR.GetString("PAT_GIVEN_NAME_FIRST1") + rdrF010_PAT_MSTR.GetString("FILLER3");
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
            return strReturnValue;
        }

        private decimal F010_PAT_MSTR_PAT_BIRTH_DATE()
        {
            decimal decReturnValue = 0;

            try
            {
                decReturnValue = QDesign.NConvert(QDesign.ASCII(rdrF010_PAT_MSTR.GetNumber("PAT_BIRTH_DATE_YY"), 4) + QDesign.ASCII(rdrF010_PAT_MSTR.GetNumber("PAT_BIRTH_DATE_MM"), 2) + QDesign.ASCII(rdrF010_PAT_MSTR.GetNumber("PAT_BIRTH_DATE_DD"), 2));
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
            return decReturnValue;
        }

        public override bool SelectIf()
        {
            bool blnSelected = false;

            if (QDesign.NULL(F010_PAT_MSTR_PAT_BIRTH_DATE()) > QDesign.SysDate(ref m_cnnQUERY) || QDesign.NULL(F010_PAT_MSTR_PAT_BIRTH_DATE()) < 18920101)
            {
                blnSelected = true;
            }

            return blnSelected;
        }

        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.REPORT, "INDEXED.F010_PAT_MSTR.PAT_HEALTH_NBR", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "INDEXED.F010_PAT_MSTR.PAT_CHART_NBR", DataTypes.Character, 10);
                AddControl(ReportSection.REPORT, "PAT_SURNAME", DataTypes.Character, 25);
                AddControl(ReportSection.REPORT, "PAT_GIVEN_NAME", DataTypes.Character, 17);
                AddControl(ReportSection.REPORT, "PAT_BIRTH_DATE", DataTypes.Numeric, 8);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2019-07-24 7:51:35 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "INDEXED.F010_PAT_MSTR.PAT_HEALTH_NBR":
                    return rdrF010_PAT_MSTR.GetNumber("PAT_HEALTH_NBR").ToString();

                case "INDEXED.F010_PAT_MSTR.PAT_CHART_NBR":
                    return Common.StringToField(rdrF010_PAT_MSTR.GetString("PAT_CHART_NBR"));

                case "PAT_SURNAME":
                    return Common.StringToField(F010_PAT_MSTR_PAT_SURNAME());

                case "PAT_GIVEN_NAME":
                    return Common.StringToField(F010_PAT_MSTR_PAT_GIVEN_NAME());

                case "PAT_BIRTH_DATE":
                    return F010_PAT_MSTR_PAT_BIRTH_DATE().ToString();

                default:
                    return String.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_F010_PAT_MSTR();
                while (rdrF010_PAT_MSTR.Read())
                {
                    WriteData();
                }

                rdrF010_PAT_MSTR.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if (!(rdrF010_PAT_MSTR == null))
            {
                rdrF010_PAT_MSTR.Close();
                rdrF010_PAT_MSTR = null;
            }
        }
    }
}
