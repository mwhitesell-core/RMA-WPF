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
    public class EMERGENCY_PAYROLL_CLMHDRID_3 : BaseRDLClass
    {
        protected const string REPORT_NAME = "EMERGENCY_PAYROLL_CLMHDRID_3";
        protected const bool REPORT_HAS_PARAMETERS = false;

        private Reader rdrPAYROLL2_CLMID = new Reader();

        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                //  Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;
                Sort = "DOC_NAME ASC, CLMHDR_PAYROLL ASC";
                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return ReportData;
        }
        private void Access_PAYROLL2_CLMID()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            strSQL.Append("SELECT ");
            strSQL.Append("X_CLINIC, ");
            strSQL.Append("COMMA, ");
            strSQL.Append("CLMHDR_DOC_DEPT, ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("DOC_NAME, ");
            strSQL.Append("CLMHDR_SERV_DATE, ");
            strSQL.Append("CLMHDR_LOC, ");
            strSQL.Append("CLMHDR_PAYROLL ");
            strSQL.Append("FROM TEMPORARYDATA.PAYROLL2_CLMID ");

            rdrPAYROLL2_CLMID.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
            strSQL = null;
        }

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(String.Empty);

            return strChoose.ToString().ToString();
        }

        public override bool SelectIf()
        {
            bool blnSelected = false;
            if (X_LOC() == "H")
            {
                blnSelected = true;
            }

            return blnSelected;
        }

        private string X_LOC()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = QDesign.Substring(rdrPAYROLL2_CLMID.GetString("CLMHDR_LOC"), 1, 1);
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
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.PAYROLL2_CLMID.X_CLINIC", DataTypes.Character, 2);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.PAYROLL2_CLMID.COMMA", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.PAYROLL2_CLMID.CLMHDR_DOC_DEPT", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.PAYROLL2_CLMID.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.PAYROLL2_CLMID.DOC_NAME", DataTypes.Character, 24);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.PAYROLL2_CLMID.CLMHDR_SERV_DATE", DataTypes.Numeric, 8);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.PAYROLL2_CLMID.CLMHDR_LOC", DataTypes.Character, 4);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.PAYROLL2_CLMID.CLMHDR_PAYROLL", DataTypes.Character, 1);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-07-30 10:52:26 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            // TODO: Remove duplicate controls, if there are any.
            switch (strControl)
            {
                case "TEMPORARYDATA.PAYROLL2_CLMID.X_CLINIC":
                    return Common.StringToField(rdrPAYROLL2_CLMID.GetString("X_CLINIC"));
                case "TEMPORARYDATA.PAYROLL2_CLMID.COMMA":
                    return Common.StringToField(rdrPAYROLL2_CLMID.GetString("COMMA"));
                case "TEMPORARYDATA.PAYROLL2_CLMID.CLMHDR_DOC_DEPT":
                    return rdrPAYROLL2_CLMID.GetNumber("CLMHDR_DOC_DEPT").ToString();
                case "TEMPORARYDATA.PAYROLL2_CLMID.DOC_NBR":
                    return Common.StringToField(rdrPAYROLL2_CLMID.GetString("DOC_NBR"));
                case "TEMPORARYDATA.PAYROLL2_CLMID.DOC_NAME":
                    return Common.StringToField(rdrPAYROLL2_CLMID.GetString("DOC_NAME"));
                case "TEMPORARYDATA.PAYROLL2_CLMID.CLMHDR_SERV_DATE":
                    return rdrPAYROLL2_CLMID.GetNumber("CLMHDR_SERV_DATE").ToString();
                case "TEMPORARYDATA.PAYROLL2_CLMID.CLMHDR_LOC":
                    return Common.StringToField(rdrPAYROLL2_CLMID.GetString("CLMHDR_LOC"));
                case "TEMPORARYDATA.PAYROLL2_CLMID.CLMHDR_PAYROLL":
                    return Common.StringToField(rdrPAYROLL2_CLMID.GetString("CLMHDR_PAYROLL"));
                default:
                    return String.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_PAYROLL2_CLMID();
                while (rdrPAYROLL2_CLMID.Read())
                {
                    WriteData();
                }
                rdrPAYROLL2_CLMID.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if (!(rdrPAYROLL2_CLMID == null))
            {
                rdrPAYROLL2_CLMID.Close();
                rdrPAYROLL2_CLMID = null;
            }
        }
    }
}
