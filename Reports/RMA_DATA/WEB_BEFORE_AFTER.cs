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
    public class WEB_BEFORE_AFTER : BaseRDLClass
    {
        protected const string REPORT_NAME = "WEB_BEFORE_AFTER";
        protected const bool REPORT_HAS_PARAMETERS = false;

        private Reader rdrSUSPDTL_ALL_SORT = new Reader();

        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                //  Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;
                Sort = "CLMHDR_DOC_NBR ASC, CLMHDR_DOC_DEPT ASC, CLMHDR_DOC_SPEC_CD ASC, X_SEQ ASC";

                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return ReportData;
        }

        private void Access_SUSPDTL_ALL_SORT()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("CLMHDR_DOC_NBR, ");
            strSQL.Append("CLMHDR_DOC_NBR, ");
            strSQL.Append("CLMHDR_DOC_SPEC_CD, ");
            strSQL.Append("X_SEQ, ");
            strSQL.Append("X_SVC, ");
            strSQL.Append("X_CLM, ");
            strSQL.Append("X_AMT, ");
            strSQL.Append("X_AMT_DIFF ");
            strSQL.Append("FROM TEMPORARYDATA.SUSPDTL_ALL_SORT ");
            strSQL.Append(Choose());

            rdrSUSPDTL_ALL_SORT.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
            strSQL = null;
        }

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(string.Empty);

            return strChoose.ToString().ToString();
        }

        private string SEQUENCE()
        {
            string strReturnValue = string.Empty;

            try
            {
                if (rdrSUSPDTL_ALL_SORT.GetNumber("X_SEQ") == 1)
                {
                    strReturnValue = "Before";
                }
                else if (rdrSUSPDTL_ALL_SORT.GetNumber("X_SEQ") == 2)
                {
                    strReturnValue = "After";
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private decimal X_SVC_B()
        {
            decimal decReturnValue = 0;

            try
            {
                if (rdrSUSPDTL_ALL_SORT.GetNumber("X_SEQ") == 1)
                {
                    decReturnValue = rdrSUSPDTL_ALL_SORT.GetNumber("X_SVC");
                }
                else
                {
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_CLM_B()
        {
            decimal decReturnValue = 0;

            try
            {
                if (rdrSUSPDTL_ALL_SORT.GetNumber("X_SEQ") == 1)
                {
                    decReturnValue = rdrSUSPDTL_ALL_SORT.GetNumber("X_CLM");
                }
                else
                {
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_AMT_B()
        {
            decimal decReturnValue = 0;

            try
            {
                if (rdrSUSPDTL_ALL_SORT.GetNumber("X_SEQ") == 1)
                {
                    decReturnValue = rdrSUSPDTL_ALL_SORT.GetNumber("X_AMT");
                }
                else
                {
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_SVC_A()
        {
            decimal decReturnValue = 0;

            try
            {
                if (rdrSUSPDTL_ALL_SORT.GetNumber("X_SEQ") == 2)
                {
                    decReturnValue = rdrSUSPDTL_ALL_SORT.GetNumber("X_SVC");
                }
                else
                {
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_CLM_A()
        {
            decimal decReturnValue = 0;

            try
            {
                if (rdrSUSPDTL_ALL_SORT.GetNumber("X_SEQ") == 2)
                {
                    decReturnValue = rdrSUSPDTL_ALL_SORT.GetNumber("X_CLM");
                }
                else
                {
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_AMT_A()
        {
            decimal decReturnValue = 0;

            try
            {
                if (rdrSUSPDTL_ALL_SORT.GetNumber("X_SEQ") == 2)
                {
                    decReturnValue = rdrSUSPDTL_ALL_SORT.GetNumber("X_AMT");
                }
                else
                {
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private string SYSDATE()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.ASCII(DateTime.Today.Year, 4) + QDesign.ASCII(DateTime.Today.Month, 2) + QDesign.ASCII(DateTime.Today.Day, 2);
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
                AddControl(ReportSection.REPORT, "SEQUENCE", DataTypes.Character, 6);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.SUSPDTL_ALL_SORT.CLMHDR_DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.SUSPDTL_ALL_SORT.CLMHDR_DOC_DEPT", DataTypes.Numeric, 4);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.SUSPDTL_ALL_SORT.CLMHDR_DOC_SPEC_CD", DataTypes.Numeric, 4);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.SUSPDTL_ALL_SORT.X_SVC", DataTypes.Numeric, 7);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.SUSPDTL_ALL_SORT.X_CLM", DataTypes.Numeric, 7);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.SUSPDTL_ALL_SORT.X_AMT", DataTypes.Numeric, 11);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.SUSPDTL_ALL_SORT.X_AMT_DIFF", DataTypes.Numeric, 11);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.SUSPDTL_ALL_SORT.X_SEQ", DataTypes.Numeric, 3);
                AddControl(ReportSection.REPORT, "X_SVC_B", DataTypes.Numeric, 7);
                AddControl(ReportSection.REPORT, "X_CLM_B", DataTypes.Numeric, 7);
                AddControl(ReportSection.REPORT, "X_AMT_B", DataTypes.Numeric, 11);
                AddControl(ReportSection.REPORT, "X_SVC_A", DataTypes.Numeric, 7);
                AddControl(ReportSection.REPORT, "X_CLM_A", DataTypes.Numeric, 7);
                AddControl(ReportSection.REPORT, "X_AMT_A", DataTypes.Numeric, 11);
                AddControl(ReportSection.REPORT, "SYSDATE", DataTypes.Character, 8);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-07-20 11:56:58 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "SEQUENCE":
                    return Common.StringToField(SEQUENCE());

                case "TEMPORARYDATA.SUSPDTL_ALL_SORT.CLMHDR_DOC_NBR":
                    return Common.StringToField(rdrSUSPDTL_ALL_SORT.GetString("CLMHDR_DOC_NBR"));

                case "TEMPORARYDATA.SUSPDTL_ALL_SORT.CLMHDR_DOC_DEPT":
                    return rdrSUSPDTL_ALL_SORT.GetNumber("CLMHDR_DOC_DEPT").ToString();

                case "TEMPORARYDATA.SUSPDTL_ALL_SORT.CLMHDR_DOC_SPEC_CD":
                    return rdrSUSPDTL_ALL_SORT.GetNumber("CLMHDR_DOC_SPEC_CD").ToString();

                case "TEMPORARYDATA.SUSPDTL_ALL_SORT.X_SVC":
                    return rdrSUSPDTL_ALL_SORT.GetNumber("X_SVC").ToString();

                case "TEMPORARYDATA.SUSPDTL_ALL_SORT.X_CLM":
                    return rdrSUSPDTL_ALL_SORT.GetNumber("X_CLM").ToString();

                case "TEMPORARYDATA.SUSPDTL_ALL_SORT.X_AMT":
                    return rdrSUSPDTL_ALL_SORT.GetNumber("X_AMT").ToString();

                case "TEMPORARYDATA.SUSPDTL_ALL_SORT.X_AMT_DIFF":
                    return rdrSUSPDTL_ALL_SORT.GetNumber("X_AMT_DIFF").ToString();

                case "TEMPORARYDATA.SUSPDTL_ALL_SORT.X_SEQ":
                    return rdrSUSPDTL_ALL_SORT.GetNumber("X_SEQ").ToString();

                case "X_SVC_B":
                    return X_SVC_B().ToString();

                case "X_CLM_B":
                    return X_CLM_B().ToString();

                case "X_AMT_B":
                    return X_AMT_B().ToString();

                case "X_SVC_A":
                    return X_SVC_A().ToString();

                case "X_CLM_A":
                    return X_CLM_A().ToString();

                case "X_AMT_A":
                    return X_AMT_A().ToString();

                case "SYSDATE":
                    return Common.StringToField(SYSDATE());

                default:
                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_SUSPDTL_ALL_SORT();
                while (rdrSUSPDTL_ALL_SORT.Read())
                {
                    WriteData();
                }
                rdrSUSPDTL_ALL_SORT.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if (!(rdrSUSPDTL_ALL_SORT == null))
            {
                rdrSUSPDTL_ALL_SORT.Close();
                rdrSUSPDTL_ALL_SORT = null;
            }
        }
    }
}
