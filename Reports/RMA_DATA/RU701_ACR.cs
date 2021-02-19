//  2010/may/20 MC - original - ru701_acr 
//  - to be executed after newu701.cbl to generate a new report
//  by acronym order
//  2011/apr/21 MC  - decimal spacing
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
    public class RU701_ACR : BaseRDLClass
    {
        protected const string REPORT_NAME = "RU701_ACR";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrRU701_WORK_FILE = new Reader();
        private Reader rdrF020_DOCTOR_MSTR = new Reader();
        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                //  Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;
                Sort = "DOC_NBR ASC, ICONST_CLINIC_NBR_1_2 ASC, DOC_SPEC_CD ASC, PAGE_AREA ASC, CLMHDR_PAT_ACRONYM ASC, CLMHDR_ACCOUNTING_NBR ASC, ORIG_REC_NO ASC, CLMDTL_LINE_NO ASC";
                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return ReportData;
        }
        private void Access_RU701_WORK_FILE()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("ICONST_CLINIC_NBR_1_2, ");
            strSQL.Append("DOC_SPEC_CD, ");
            strSQL.Append("PAGE_AREA, ");
            strSQL.Append("CLMHDR_PAT_ACRONYM, ");
            strSQL.Append("CLMHDR_ACCOUNTING_NBR, ");
            strSQL.Append("ORIG_REC_NO, ");
            strSQL.Append("CLMDTL_LINE_NO, ");
            strSQL.Append("PRINT_LINE ");
            strSQL.Append("FROM SEQUENTIAL.RU701_WORK_FILE ");
            strSQL.Append(Choose());
            rdrRU701_WORK_FILE.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.m_strFlatFileDictionary, ReportFunctions.TextFiles);
            strSQL = null;
        }
        private void Link_F020_DOCTOR_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("DOC_INIT1, ");
            strSQL.Append(" DOC_INIT2, ");
            strSQL.Append(" DOC_INIT3, ");
            strSQL.Append("DOC_NAME ");
            strSQL.Append("FROM INDEXED.F020_DOCTOR_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_NBR = ").Append(Common.StringToField(rdrRU701_WORK_FILE.GetString("DOC_NBR")));
            rdrF020_DOCTOR_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(String.Empty);
            // TODO: CHOOSE Statement - May require manual changes.
            return strChoose.ToString().ToString();
        }

        private string X_DOC_NAME()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = rdrF020_DOCTOR_MSTR.GetString("DOC_INIT1") + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT2") + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT3") + " " + rdrF020_DOCTOR_MSTR.GetString("DOC_NAME");
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
                AddControl(ReportSection.HEADING_AT, "SEQUENTIAL.RU701_WORK_FILE.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.HEADING_AT, "X_DOC_NAME", DataTypes.Character, 30);
                AddControl(ReportSection.HEADING_AT, "SEQUENTIAL.RU701_WORK_FILE.ICONST_CLINIC_NBR_1_2", DataTypes.Numeric, 2);
                AddControl(ReportSection.HEADING_AT, "SEQUENTIAL.RU701_WORK_FILE.DOC_SPEC_CD", DataTypes.Numeric, 2);
                AddControl(ReportSection.HEADING_AT, "SEQUENTIAL.RU701_WORK_FILE.CLMHDR_PAT_ACRONYM", DataTypes.Character, 9);
                AddControl(ReportSection.REPORT, "SEQUENTIAL.RU701_WORK_FILE.PRINT_LINE", DataTypes.Character, 132);
                AddControl(ReportSection.REPORT, "SEQUENTIAL.RU701_WORK_FILE.PAGE_AREA", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "SEQUENTIAL.RU701_WORK_FILE.CLMHDR_ACCOUNTING_NBR", DataTypes.Character, 8);
                AddControl(ReportSection.REPORT, "SEQUENTIAL.RU701_WORK_FILE.ORIG_REC_NO", DataTypes.Numeric, 5);
                AddControl(ReportSection.REPORT, "SEQUENTIAL.RU701_WORK_FILE.CLMDTL_LINE_NO", DataTypes.Numeric, 2);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-05-16 9:44:53 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            // TODO: Remove duplicate controls, if there are any.
            switch (strControl)
            {
                case "SEQUENTIAL.RU701_WORK_FILE.DOC_NBR":
                    return Common.StringToField(rdrRU701_WORK_FILE.GetString("DOC_NBR"));
                case "X_DOC_NAME":
                    return Common.StringToField(X_DOC_NAME(), intSize);
                case "SEQUENTIAL.RU701_WORK_FILE.ICONST_CLINIC_NBR_1_2":
                    return rdrRU701_WORK_FILE.GetNumber("ICONST_CLINIC_NBR_1_2").ToString();
                case "SEQUENTIAL.RU701_WORK_FILE.DOC_SPEC_CD":
                    return rdrRU701_WORK_FILE.GetNumber("DOC_SPEC_CD").ToString();
                case "SEQUENTIAL.RU701_WORK_FILE.CLMHDR_PAT_ACRONYM":
                    return Common.StringToField(rdrRU701_WORK_FILE.GetString("CLMHDR_PAT_ACRONYM"));
                case "SEQUENTIAL.RU701_WORK_FILE.PRINT_LINE":
                    return Common.StringToField(rdrRU701_WORK_FILE.GetString("PRINT_LINE"));
                case "SEQUENTIAL.RU701_WORK_FILE.PAGE_AREA":
                    return Common.StringToField(rdrRU701_WORK_FILE.GetString("PAGE_AREA"));
                case "SEQUENTIAL.RU701_WORK_FILE.CLMHDR_ACCOUNTING_NBR":
                    return Common.StringToField(rdrRU701_WORK_FILE.GetString("CLMHDR_ACCOUNTING_NBR"));
                case "SEQUENTIAL.RU701_WORK_FILE.ORIG_REC_NO":
                    return rdrRU701_WORK_FILE.GetNumber("ORIG_REC_NO").ToString();
                case "SEQUENTIAL.RU701_WORK_FILE.CLMDTL_LINE_NO":
                    return rdrRU701_WORK_FILE.GetNumber("CLMDTL_LINE_NO").ToString();
                default:
                    return String.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                // TODO: Some manual steps maybe required.
                Access_RU701_WORK_FILE();
                while (rdrRU701_WORK_FILE.Read())
                {
                    Link_F020_DOCTOR_MSTR();
                    while (rdrF020_DOCTOR_MSTR.Read())
                    {
                        WriteData();
                    }

                    rdrF020_DOCTOR_MSTR.Close();
                }

                rdrRU701_WORK_FILE.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrRU701_WORK_FILE == null))
            {
                rdrRU701_WORK_FILE.Close();
                rdrRU701_WORK_FILE = null;
            }

            if (!(rdrF020_DOCTOR_MSTR == null))
            {
                rdrF020_DOCTOR_MSTR.Close();
                rdrF020_DOCTOR_MSTR = null;
            }
        }
    }
}
