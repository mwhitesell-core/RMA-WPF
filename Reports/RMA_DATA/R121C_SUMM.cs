//  PROGRAM: R121C_SUMM.QZS
//  REPORT YTD FIGURES GRAND TOTALS
//  DATE  WHO     MODIFICATION
//  2015/Jan/15 MC ORIGINAL (clone from r121c.qzs)
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
    public class R121C_SUMM : BaseRDLClass
    {
        protected const string REPORT_NAME = "R121C_SUMM";
        protected const bool REPORT_HAS_PARAMETERS = true;
        private Reader rdrR121_SUMM = new Reader();
        private Reader rdrF123_COMPANY_MSTR = new Reader();
        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                //  Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;
                Sort = "X_KEY1 ASC";
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
            strSQL.Append("DEPT_COMPANY, ");
            strSQL.Append("COMP_CODE_GROUP, ");
            strSQL.Append("REPORTING_SEQ, ");
            strSQL.Append("COMP_CODE, ");
            strSQL.Append("CALENDAR_YEAR, ");
            strSQL.Append("COMP_TYPE, ");
            strSQL.Append("DESC_SHORT, ");
            strSQL.Append("YTD_AMT ");
            strSQL.Append("FROM TEMPORARYDATA.R121_SUMM ");
            strSQL.Append(Choose());
            rdrR121_SUMM.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.m_strFlatFileDictionary, ReportFunctions.TextFiles);
            strSQL = null;
        }
        private void Link_F123_COMPANY_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("COMPANY_NBR, ");
            strSQL.Append("COMPANY_NAME ");
            strSQL.Append("FROM [101C].INDEXED.F123_COMPANY_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("COMPANY_NBR = ").Append(rdrR121_SUMM.GetNumber("DEPT_COMPANY"));
            rdrF123_COMPANY_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(String.Empty);
            // TODO: CHOOSE Statement - May require manual changes.
            return strChoose.ToString().ToString();
        }

        public override bool SelectIf()
        {
            bool blnSelected = false;            

            switch(ReportFunctions.astrScreenParameters[0].ToString())
            {
                case "2":
                    if ((QDesign.NULL(rdrR121_SUMM.GetNumber("DEPT_COMPANY")) == QDesign.NULL(2d)))
                    {
                        blnSelected = true;
                    };
                    break;
                case "3":
                    if ((QDesign.NULL(rdrR121_SUMM.GetNumber("DEPT_COMPANY")) == QDesign.NULL(3d)))
                    {
                        blnSelected = true;
                    };
                    break;
                case "4":
                    if ((QDesign.NULL(rdrR121_SUMM.GetNumber("DEPT_COMPANY")) == QDesign.NULL(4d)))
                    {
                        blnSelected = true;
                    };
                    break;
                default:
                    if ((QDesign.NULL(rdrR121_SUMM.GetNumber("DEPT_COMPANY")) == QDesign.NULL(1d)))
                    {
                        blnSelected = true;
                    }                
                    break;
            }
           
            
            return blnSelected;
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
        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.PAGE_HEADING, "INDEXED.F123_COMPANY_MSTR.COMPANY_NAME", DataTypes.Character, 40);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.R121_SUMM.CALENDAR_YEAR", DataTypes.Numeric, 5);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R121_SUMM.COMP_TYPE", DataTypes.Character, 1);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R121_SUMM.COMP_CODE", DataTypes.Character, 6);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R121_SUMM.DESC_SHORT", DataTypes.Character, 15);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R121_SUMM.YTD_AMT", DataTypes.Numeric, 11);
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
                case "INDEXED.F123_COMPANY_MSTR.COMPANY_NAME":
                    return Common.StringToField(rdrF123_COMPANY_MSTR.GetString("COMPANY_NAME"));
                case "TEMPORARYDATA.R121_SUMM.CALENDAR_YEAR":
                    return rdrR121_SUMM.GetNumber("CALENDAR_YEAR").ToString();
                case "TEMPORARYDATA.R121_SUMM.COMP_TYPE":
                    return Common.StringToField(rdrR121_SUMM.GetString("COMP_TYPE"));
                case "TEMPORARYDATA.R121_SUMM.COMP_CODE":
                    return Common.StringToField(rdrR121_SUMM.GetString("COMP_CODE"));
                case "TEMPORARYDATA.R121_SUMM.DESC_SHORT":
                    return Common.StringToField(rdrR121_SUMM.GetString("DESC_SHORT"));
                case "TEMPORARYDATA.R121_SUMM.YTD_AMT":
                    return rdrR121_SUMM.GetNumber("YTD_AMT").ToString();
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
                    Link_F123_COMPANY_MSTR();
                    while (rdrF123_COMPANY_MSTR.Read())
                    {
                        WriteData();
                    }

                    rdrF123_COMPANY_MSTR.Close();
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

            if (!(rdrF123_COMPANY_MSTR == null))
            {
                rdrF123_COMPANY_MSTR.Close();
                rdrF123_COMPANY_MSTR = null;
            }
        }
    }
}
