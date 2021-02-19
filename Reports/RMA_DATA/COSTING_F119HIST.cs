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
    public class COSTING_F119HIST : BaseRDLClass
    {
        protected const string REPORT_NAME = "COSTINGF119";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrCOSTINGF119 = new Reader();
        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                //  Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;

                ReportFunctions.DebugReport = blnDebug;

                Sort = "DOC_DEPT ASC, DOC_NAME ASC, DOC_NBR ASC";

                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return ReportData;
        }
        private void Access_COSTINGF119()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: If * is not used to select all columns, ensure the necessary columns (i.e. columns that are used to access records of other tables) are included in the SELECT statement
            strSQL.Append("SELECT * ");
            strSQL.Append("FROM TEMPORARYDATA.COSTINGF119 ");
            strSQL.Append(this.Choose());
            rdrCOSTINGF119.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
            strSQL = null;
        }

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(String.Empty);
            // TODO: CHOOSE Statement - May require manual changes.
            return strChoose.ToString();
        }
        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.COSTINGF119.COMMA", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.COSTINGF119.DOC_CLINIC_NBR", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.COSTINGF119.DOC_DEPT", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.COSTINGF119.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.COSTINGF119.DOC_NAME", DataTypes.Character, 24);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.COSTINGF119.DOC_INITS", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.COSTINGF119.X_TOTINC", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.COSTINGF119.X_RMACHR", DataTypes.Numeric, 9);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.COSTINGF119.X_RMAEXR", DataTypes.Numeric, 9);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.COSTINGF119.X_RMAEXM", DataTypes.Numeric, 9);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.COSTINGF119.DOC_DATE_FAC_START", DataTypes.Numeric, 8);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.COSTINGF119.DOC_DATE_FAC_TERM", DataTypes.Numeric, 8);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-05-01 11:37:26 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "TEMPORARYDATA.COSTINGF119.COMMA":
                    return Common.StringToField(rdrCOSTINGF119.GetString("COMMA"));

                case "TEMPORARYDATA.COSTINGF119.DOC_CLINIC_NBR":
                    return rdrCOSTINGF119.GetNumber("DOC_CLINIC_NBR").ToString();

                case "TEMPORARYDATA.COSTINGF119.DOC_DEPT":
                    return rdrCOSTINGF119.GetNumber("DOC_DEPT").ToString();

                case "TEMPORARYDATA.COSTINGF119.DOC_NBR":
                    return Common.StringToField(rdrCOSTINGF119.GetString("DOC_NBR"));

                case "TEMPORARYDATA.COSTINGF119.DOC_NAME":
                    return Common.StringToField(rdrCOSTINGF119.GetString("DOC_NAME"));

                case "TEMPORARYDATA.COSTINGF119.DOC_INITS":
                    return Common.StringToField(rdrCOSTINGF119.GetString("DOC_INITS"));

                case "TEMPORARYDATA.COSTINGF119.X_TOTINC":
                    return rdrCOSTINGF119.GetNumber("X_TOTINC").ToString();

                case "TEMPORARYDATA.COSTINGF119.X_RMACHR":
                    return rdrCOSTINGF119.GetNumber("X_RMACHR").ToString();

                case "TEMPORARYDATA.COSTINGF119.X_RMAEXR":
                    return rdrCOSTINGF119.GetNumber("X_RMAEXR").ToString();

                case "TEMPORARYDATA.COSTINGF119.X_RMAEXM":
                    return rdrCOSTINGF119.GetNumber("X_RMAEXM").ToString();

                case "TEMPORARYDATA.COSTINGF119.DOC_DATE_FAC_START":
                    return rdrCOSTINGF119.GetNumber("DOC_DATE_FAC_START").ToString();

                case "TEMPORARYDATA.COSTINGF119.DOC_DATE_FAC_TERM":
                    return rdrCOSTINGF119.GetNumber("DOC_DATE_FAC_TERM").ToString();

                default:
                    return String.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                // TODO: Some manual steps maybe required.
                this.Access_COSTINGF119();
                while (rdrCOSTINGF119.Read())
                {
                    WriteData();
                }

                rdrCOSTINGF119.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if (!(rdrCOSTINGF119 == null))
            {
                rdrCOSTINGF119.Close();
                rdrCOSTINGF119 = null;
            }
        }
    }
}
