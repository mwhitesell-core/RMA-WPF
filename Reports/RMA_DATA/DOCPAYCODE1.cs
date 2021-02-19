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
    public class DOCPAYCODE1 : BaseRDLClass
    {
        protected const string REPORT_NAME = "DOCPAYCODE1";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrDOCPAYCODE = new Reader();
        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                //  Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;

                switch (arrParameters[5].ToString())
                {
                    case "1":
                        Sort = "DOC_DEPT ASC, DOC_NBR ASC";
                        break;
                    case "2":
                        Sort = "DOC_NAME ASC, DOC_INITS ASC, DOC_NBR ASC";
                        break;
                    default:
                        Sort = "DOC_NAME ASC, DOC_INITS ASC, DOC_NBR ASC";
                        break;
                }

                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return ReportData;
        }
        private void Access_DOCPAYCODE()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NAME, ");
            strSQL.Append("DOC_INITS, ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("DOC_CLINIC_NBR, ");
            strSQL.Append("DOC_DEPT, ");
            strSQL.Append("DOC_PAY_CODE, ");
            strSQL.Append("DOC_PAY_SUB_CODE, ");
            strSQL.Append("DOC_DATE_FAC_TERM ");
            strSQL.Append("FROM TEMPORARYDATA.DOCPAYCODE ");

            strSQL.Append(Choose());

            rdrDOCPAYCODE.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
            strSQL = null;
        }
    
        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(string.Empty);

            return strChoose.ToString().ToString();
        }
        public override void DeclareReportControls()
        {
            try
            {
                 AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.DOCPAYCODE.DOC_CLINIC_NBR", DataTypes.Numeric, 2);
                 AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.DOCPAYCODE.DOC_DEPT", DataTypes.Numeric, 2);
                 AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.DOCPAYCODE.DOC_NBR", DataTypes.Character, 3);
                 AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.DOCPAYCODE.DOC_NAME", DataTypes.Character, 24);
                 AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.DOCPAYCODE.DOC_INITS", DataTypes.Character, 3);
                 AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.DOCPAYCODE.DOC_PAY_CODE", DataTypes.Character, 1);
                 AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.DOCPAYCODE.DOC_PAY_SUB_CODE", DataTypes.Character, 1);
                 AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.DOCPAYCODE.DOC_DATE_FAC_TERM", DataTypes.Numeric, 8);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
    
        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-07-30 10:52:25 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "TEMPORARYDATA.DOCPAYCODE.DOC_CLINIC_NBR":
                    return rdrDOCPAYCODE.GetNumber("DOC_CLINIC_NBR").ToString();

                case "TEMPORARYDATA.DOCPAYCODE.DOC_DEPT":
                    return rdrDOCPAYCODE.GetNumber("DOC_DEPT").ToString();

                case "TEMPORARYDATA.DOCPAYCODE.DOC_NBR":
                    return Common.StringToField(rdrDOCPAYCODE.GetString("DOC_NBR"));

                case "TEMPORARYDATA.DOCPAYCODE.DOC_NAME":
                    return Common.StringToField(rdrDOCPAYCODE.GetString("DOC_NAME"));

                case "TEMPORARYDATA.DOCPAYCODE.DOC_INITS":
                    return Common.StringToField(rdrDOCPAYCODE.GetString("DOC_INITS"));

                case "TEMPORARYDATA.DOCPAYCODE.DOC_PAY_CODE":
                    return Common.StringToField(rdrDOCPAYCODE.GetString("DOC_PAY_CODE"));

                case "TEMPORARYDATA.DOCPAYCODE.DOC_PAY_SUB_CODE":
                    return Common.StringToField(rdrDOCPAYCODE.GetString("DOC_PAY_SUB_CODE"));

                case "TEMPORARYDATA.DOCPAYCODE.DOC_DATE_FAC_TERM":
                    return rdrDOCPAYCODE.GetNumber("DOC_DATE_FAC_TERM").ToString();

                default:
                    return string.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                Access_DOCPAYCODE();
                while (rdrDOCPAYCODE.Read())
                {
                    WriteData();
                }
            
                rdrDOCPAYCODE.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrDOCPAYCODE == null))
            {
                rdrDOCPAYCODE.Close();
                rdrDOCPAYCODE = null;
            }
        }
    }
}
