//  PROGRAM:  R121A_SUMM.QZS
//  REPORT YTD FIGURES REPORT  AT CLASS and dept
//  DATE       WHO    MODIFICATION
//  2015/Jan/15  MC.    ORIGINAL (clone from r121a.qzs)
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
    public class R121A_SUMM : BaseRDLClass
    {
        protected const string REPORT_NAME = "R121A_SUMM";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrR121_SUMM = new Reader();
        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                //  Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;
                Sort = "X_KEY2 ASC, DOC_DEPT ASC, X_KEY1 ASC";
                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return ReportData;
        }
        private void Access_R121_SUMM()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: If * is not used to select all columns, ensure the necessary columns (i.e. columns that are used to access records of other tables) are included in the SELECT statement
            strSQL.Append("SELECT ");
            strSQL.Append("COMP_CODE_GROUP, ");
            strSQL.Append("REPORTING_SEQ, ");
            strSQL.Append("COMP_CODE, ");
            strSQL.Append("DOC_DEPT, ");
            strSQL.Append("DOC_FULL_PART_IND, ");
            strSQL.Append("CALENDAR_YEAR, ");
            strSQL.Append("DEPT_NAME, ");
            strSQL.Append("COMP_TYPE, ");
            strSQL.Append("DESC_SHORT, ");
            strSQL.Append("YTD_AMT ");
            strSQL.Append("FROM TEMPORARYDATA.R121_SUMM ");
            strSQL.Append(Choose());
            rdrR121_SUMM.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.m_strFlatFileDictionary, ReportFunctions.TextFiles);
            strSQL = null;
        }

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(String.Empty);
            // TODO: CHOOSE Statement - May require manual changes.
            return strChoose.ToString().ToString();
        }

        private string X_KEY1()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = (rdrR121_SUMM.GetString("COMP_CODE_GROUP")
                            + (QDesign.ASCII(rdrR121_SUMM.GetNumber("REPORTING_SEQ"), 2) + rdrR121_SUMM.GetString("COMP_CODE")));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_KEY2()
        {
            string strReturnValue = String.Empty;
            try
            {
                if ((QDesign.NULL(rdrR121_SUMM.GetNumber("DOC_DEPT")) == QDesign.NULL(14d)))
                {
                    strReturnValue = "D";
                }
                else if ((QDesign.NULL(rdrR121_SUMM.GetString("DOC_FULL_PART_IND")) == "F"))
                {
                    strReturnValue = "A";
                }
                else if ((QDesign.NULL(rdrR121_SUMM.GetString("DOC_FULL_PART_IND")) == "P"))
                {
                    strReturnValue = "B";
                }
                else if ((QDesign.NULL(rdrR121_SUMM.GetString("DOC_FULL_PART_IND")) == "C"))
                {
                    strReturnValue = "C";
                }
                else if ((QDesign.NULL(rdrR121_SUMM.GetString("DOC_FULL_PART_IND")) == "S"))
                {
                    strReturnValue = "S";
                }
                else
                {
                    strReturnValue = "E";
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_CLASS()
        {
            string strReturnValue = String.Empty;
            try
            {
                if ((QDesign.NULL(X_KEY2()) == "A"))
                {
                    strReturnValue = "FULL TIME";
                }
                else if ((QDesign.NULL(X_KEY2()) == "B"))
                {
                    strReturnValue = "PART TIME";
                }
                else if ((QDesign.NULL(X_KEY2()) == "C"))
                {
                    strReturnValue = "CLINICAL SCHOLARS";
                }
                else if ((QDesign.NULL(X_KEY2()) == "S"))
                {
                    strReturnValue = "PLASTIC SURGERY";
                }
                else if ((QDesign.NULL(X_KEY2()) == "D"))
                {
                    strReturnValue = "DEPT-14        ";
                }
                else if ((QDesign.NULL(X_KEY2()) == "E"))
                {
                    strReturnValue = "UNKNOWN";
                }
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
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.R121_SUMM.CALENDAR_YEAR", DataTypes.Numeric, 5);
                AddControl(ReportSection.HEADING_AT, "X_CLASS", DataTypes.Character, 18);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.R121_SUMM.DOC_DEPT", DataTypes.Numeric, 3);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.R121_SUMM.DEPT_NAME", DataTypes.Character, 30);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R121_SUMM.COMP_TYPE", DataTypes.Character, 1);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R121_SUMM.COMP_CODE", DataTypes.Character, 6);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R121_SUMM.DESC_SHORT", DataTypes.Character, 15);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R121_SUMM.YTD_AMT", DataTypes.Numeric, 11);
                AddControl(ReportSection.REPORT, "X_KEY2", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "X_KEY1", DataTypes.Character, 9);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2019-07-24 7:51:38 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "TEMPORARYDATA.R121_SUMM.CALENDAR_YEAR":
                    return rdrR121_SUMM.GetNumber("CALENDAR_YEAR").ToString();
                case "X_CLASS":
                    return Common.StringToField(X_CLASS(), intSize);
                case "TEMPORARYDATA.R121_SUMM.DOC_DEPT":
                    return rdrR121_SUMM.GetNumber("DOC_DEPT").ToString();
                case "TEMPORARYDATA.R121_SUMM.DEPT_NAME":
                    return Common.StringToField(rdrR121_SUMM.GetString("DEPT_NAME"));
                case "TEMPORARYDATA.R121_SUMM.COMP_TYPE":
                    return Common.StringToField(rdrR121_SUMM.GetString("COMP_TYPE"));
                case "TEMPORARYDATA.R121_SUMM.COMP_CODE":
                    return Common.StringToField(rdrR121_SUMM.GetString("COMP_CODE"));
                case "TEMPORARYDATA.R121_SUMM.DESC_SHORT":
                    return Common.StringToField(rdrR121_SUMM.GetString("DESC_SHORT"));
                case "TEMPORARYDATA.R121_SUMM.YTD_AMT":
                    return rdrR121_SUMM.GetNumber("YTD_AMT").ToString();
                case "X_KEY2":
                    return Common.StringToField(X_KEY2(), intSize);
                case "X_KEY1":
                    return Common.StringToField(X_KEY1(), intSize);
                default:
                    return String.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                // TODO: Some manual steps maybe required.
                Access_R121_SUMM();
                while (rdrR121_SUMM.Read())
                {
                    WriteData();
                }

                rdrR121_SUMM.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if (!(rdrR121_SUMM == null))
            {
                rdrR121_SUMM.Close();
                rdrR121_SUMM = null;
            }
        }
    }
}
