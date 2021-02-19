//  2015/Mar/03 MC - utl0f020_ohip_sin.qzs  (second pass)
//  - determine for different OHIP & SIN nbr for doctors in different environments
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
    public class UTL0F020_OHIP_SIN : BaseRDLClass
    {
        protected const string REPORT_NAME = "UTL0F020_OHIP_SIN";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrUTL0F020_OHIP_SIN = new Reader();
        private Reader rdrTMP_COUNTERS_ALPHA = new Reader();
        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                //  Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;
                Sort = "TMP_COUNTER_KEY_ALPHA ASC";
                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return ReportData;
        }
        private void Access_UTL0F020_OHIP_SIN()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: If * is not used to select all columns, ensure the necessary columns (i.e. columns that are used to access records of other tables) are included in the SELECT statement
            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("DOC_DEPT, ");
            strSQL.Append("DOC_NAME, ");
            strSQL.Append("DOC_OHIP_NBR, ");
            strSQL.Append("DOC_SIN_123, ");
            strSQL.Append("DOC_SIN_456, ");
            strSQL.Append("DOC_SIN_789, ");
            strSQL.Append("DOC_DATE_FAC_START_YY, ");
            strSQL.Append("DOC_DATE_FAC_START_MM, ");
            strSQL.Append("DOC_DATE_FAC_START_DD, ");
            strSQL.Append("DOC_DATE_FAC_TERM_YY, ");
            strSQL.Append("DOC_DATE_FAC_TERM_MM, ");
            strSQL.Append("DOC_DATE_FAC_TERM_DD ");
            strSQL.Append("FROM TEMPORARYDATA.UTL0F020_OHIP_SIN ");
            strSQL.Append(Choose());
            rdrUTL0F020_OHIP_SIN.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
            strSQL = null;
        }
        private void Link_TMP_COUNTERS_ALPHA()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("TMP_COUNTER_KEY_ALPHA ");
            strSQL.Append("FROM INDEXED.TMP_COUNTERS_ALPHA ");
            strSQL.Append("WHERE ");
            strSQL.Append("TMP_COUNTER_KEY_ALPHA = ").Append(Common.StringToField((rdrUTL0F020_OHIP_SIN.GetString("DOC_NBR") + (QDesign.ASCII(rdrUTL0F020_OHIP_SIN.GetNumber("DOC_DEPT"), 2) + QDesign.Substring(rdrUTL0F020_OHIP_SIN.GetString("DOC_NAME"), 1, 15)))));

            rdrTMP_COUNTERS_ALPHA.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(String.Empty);
            // TODO: CHOOSE Statement - May require manual changes.
            return strChoose.ToString().ToString();
        }

        private decimal UTL0F020_OHIP_SIN_DOC_SIN_NBR()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = QDesign.NConvert(QDesign.ASCII(rdrUTL0F020_OHIP_SIN.GetNumber("DOC_SIN_123"), 3) + QDesign.ASCII(rdrUTL0F020_OHIP_SIN.GetNumber("DOC_SIN_456"), 3) + QDesign.ASCII(rdrUTL0F020_OHIP_SIN.GetNumber("DOC_SIN_789"), 3));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal UTL0F020_OHIP_SIN_DOC_DATE_FAC_START()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = QDesign.NConvert(QDesign.ASCII(rdrUTL0F020_OHIP_SIN.GetNumber("DOC_DATE_FAC_START_YY"), 4) + QDesign.ASCII(rdrUTL0F020_OHIP_SIN.GetNumber("DOC_DATE_FAC_START_MM"), 2) + QDesign.ASCII(rdrUTL0F020_OHIP_SIN.GetNumber("DOC_DATE_FAC_START_DD"), 2));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal UTL0F020_OHIP_SIN_DOC_DATE_FAC_TERM()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = QDesign.NConvert(QDesign.ASCII(rdrUTL0F020_OHIP_SIN.GetNumber("DOC_DATE_FAC_TERM_YY"), 4) + QDesign.ASCII(rdrUTL0F020_OHIP_SIN.GetNumber("DOC_DATE_FAC_TERM_MM"), 2) + QDesign.ASCII(rdrUTL0F020_OHIP_SIN.GetNumber("DOC_DATE_FAC_TERM_MM"), 2));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.UTL0F020_OHIP_SIN.ENVIRONMENT", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.UTL0F020_OHIP_SIN.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.UTL0F020_OHIP_SIN.DOC_DEPT", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.UTL0F020_OHIP_SIN.DOC_NAME", DataTypes.Character, 24);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.UTL0F020_OHIP_SIN.DOC_OHIP_NBR", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "DOC_SIN_NBR", DataTypes.Numeric, 9);
                AddControl(ReportSection.REPORT, "DOC_DATE_FAC_START", DataTypes.Numeric, 8);
                AddControl(ReportSection.REPORT, "DOC_DATE_FAC_TERM", DataTypes.Numeric, 8);
                AddControl(ReportSection.REPORT, "INDEXED.TMP_COUNTERS_ALPHA.TMP_COUNTER_KEY_ALPHA", DataTypes.Character, 20);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-07-20 11:56:24 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            // TODO: Remove duplicate controls, if there are any.
            switch (strControl)
            {
                case "TEMPORARYDATA.UTL0F020_OHIP_SIN.ENVIRONMENT":
                    return Common.StringToField(rdrUTL0F020_OHIP_SIN.GetString("ENVIRONMENT"));
                case "TEMPORARYDATA.UTL0F020_OHIP_SIN.DOC_NBR":
                    return Common.StringToField(rdrUTL0F020_OHIP_SIN.GetString("DOC_NBR"));
                case "TEMPORARYDATA.UTL0F020_OHIP_SIN.DOC_DEPT":
                    return rdrUTL0F020_OHIP_SIN.GetNumber("DOC_DEPT").ToString();
                case "TEMPORARYDATA.UTL0F020_OHIP_SIN.DOC_NAME":
                    return Common.StringToField(rdrUTL0F020_OHIP_SIN.GetString("DOC_NAME"));
                case "TEMPORARYDATA.UTL0F020_OHIP_SIN.DOC_OHIP_NBR":
                    return rdrUTL0F020_OHIP_SIN.GetNumber("DOC_OHIP_NBR").ToString();
                case "DOC_SIN_NBR":
                    return UTL0F020_OHIP_SIN_DOC_SIN_NBR().ToString();
                case "DOC_DATE_FAC_START":
                    return UTL0F020_OHIP_SIN_DOC_DATE_FAC_START().ToString();
                case "DOC_DATE_FAC_TERM":
                    return UTL0F020_OHIP_SIN_DOC_DATE_FAC_TERM().ToString();
                case "INDEXED.TMP_COUNTERS_ALPHA.TMP_COUNTER_KEY_ALPHA":
                    return Common.StringToField(rdrTMP_COUNTERS_ALPHA.GetString("TMP_COUNTER_KEY_ALPHA"));
                default:
                    return String.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                // TODO: Some manual steps maybe required.
                Access_UTL0F020_OHIP_SIN();
                while (rdrUTL0F020_OHIP_SIN.Read())
                {
                    Link_TMP_COUNTERS_ALPHA();
                    while (rdrTMP_COUNTERS_ALPHA.Read())
                    {
                        WriteData();
                    }

                    rdrTMP_COUNTERS_ALPHA.Close();
                }

                rdrUTL0F020_OHIP_SIN.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrUTL0F020_OHIP_SIN == null))
            {
                rdrUTL0F020_OHIP_SIN.Close();
                rdrUTL0F020_OHIP_SIN = null;
            }

            if (!(rdrTMP_COUNTERS_ALPHA == null))
            {
                rdrTMP_COUNTERS_ALPHA.Close();
                rdrTMP_COUNTERS_ALPHA = null;
            }
        }
    }
}
