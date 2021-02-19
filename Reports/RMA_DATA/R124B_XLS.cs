#region "Screen Comments"

//
//       ((C)) Dyad Infosys LTD  
//
//    PURPOSE: Print the STATEMENT OF EARNINGS for the physician
// PHASE II - READ SUBFILE AND CREATE ACTUAL STATEMENT
//
//    MODIFICATION HISTORY
// DATE SAF #  WHO      DESCRIPTION
// 
// 15/jun/01 be1   - cloned from r124b_rma.qzs

// LEGEND for FORMAT OF OUTPUT
// H 00,~mmmdd~where mmm = Dept manager ID(Z + 2 digit dept nbr)  and dd = dept nbr
// H 01,REGIONAL MEDICAL ASSOCIATES	 	 
// H 02,YTD Statement of Earnings by Month(2015/05) - Regular?? Payments	 	 
// H 10,Dr.L WRIGHT    01-06A		
// H 11,Family Medicine
// SK01			
// H 21,July,August,September, .........
// TI01,ACTUAL REVENUE
// D 01	     Miscellaneous Revenue                              0	0
// SK01 FF 1		
// TO01 Total                                              0	0
// SK01			
//.
//.
// H 00, ...

#endregion

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
    public class R124B_XLS : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R124B_CSV";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrR124A_XLS = new Reader();
        private Reader rdrF070_DEPT_MSTR = new Reader();
        private Reader rdrF123_COMPANY_MSTR = new Reader();

        private string X_NEW_PARM()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = "DEP";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_COMP_CODE_GROUP_DESC()
        {
            string strReturnValue = string.Empty;

            try
            {
                if (rdrR124A_XLS.GetString("COMP_CODE") == "PAYEFT")
                {
                    strReturnValue = "KEEP this LINE";
                }
                else if (rdrR124A_XLS.GetString("COMP_CODE_GROUP") == "A")
                {
                    strReturnValue = "ACTUAL REVENUE";
                }
                else if (rdrR124A_XLS.GetString("COMP_CODE_GROUP") == "C")
                {
                    strReturnValue = "EXPENSES";
                }
                else if (rdrR124A_XLS.GetString("COMP_CODE_GROUP") == "F")
                {
                    strReturnValue = "CLINIC CEILING PAYMENT";
                }
                else if (rdrR124A_XLS.GetString("COMP_CODE_GROUP") == "G")
                {
                    strReturnValue = "DEDUCTIONS";
                }
                else if (rdrR124A_XLS.GetString("COMP_CODE_GROUP") == "J")
                {
                    strReturnValue = "CURRENT STATUS";
                }
                else if (QDesign.Substring(rdrR124A_XLS.GetString("X_LINE_TEXT_XLS"), 1, 5) == "Total")
                {
                    strReturnValue = "DELETEthisLINE";
                }
                else if (rdrR124A_XLS.GetString("COMP_CODE_GROUP") == "B" | rdrR124A_XLS.GetString("COMP_CODE_GROUP") == "D" | rdrR124A_XLS.GetString("COMP_CODE_GROUP") == "E" | rdrR124A_XLS.GetString("COMP_CODE_GROUP") == "H" | rdrR124A_XLS.GetString("COMP_CODE_GROUP") == "I" | rdrR124A_XLS.GetString("COMP_CODE_GROUP") == "K" | rdrR124A_XLS.GetString("COMP_CODE_GROUP") == "L" | rdrR124A_XLS.GetString("COMP_CODE_GROUP") == "M" | rdrR124A_XLS.GetString("COMP_CODE_GROUP") == "N")
                {
                    strReturnValue = "              ";
                }
                else
                {
                    strReturnValue = "?";
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_DOC_DEPT()
        {
            string strReturnValue = string.Empty;

            try
            {
                if (X_NEW_PARM() == "DOC")
                {
                    strReturnValue = rdrR124A_XLS.GetString("DOC_NBR") + QDesign.Substring(QDesign.ASCII(rdrR124A_XLS.GetNumber("DOC_DEPT"), 2), 1, 2);
                }
                else if (X_NEW_PARM() == "DEP")
                {
                    strReturnValue = "Z" + QDesign.ASCII(rdrR124A_XLS.GetNumber("DOC_DEPT"), 2) + QDesign.Substring(QDesign.ASCII(rdrR124A_XLS.GetNumber("DOC_DEPT"), 2), 1, 2);
                }

            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_FLAG()
        {
            string strReturnValue = string.Empty;

            try
            {
                if (X_COMP_CODE_GROUP_DESC() != "")
                {
                    strReturnValue = "TI01,";
                }
                else
                {
                    strReturnValue = "";
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_LINE_FLAG()
        {
            string strReturnValue = string.Empty;

            try
            {
                if (X_FLAG() != "")
                {
                    strReturnValue = X_FLAG();
                }
                else if (rdrR124A_XLS.GetString("COMP_CODE_GROUP") == "B" | rdrR124A_XLS.GetString("COMP_CODE_GROUP") == "D" | rdrR124A_XLS.GetString("COMP_CODE_GROUP") == "H")
                {
                    strReturnValue = "    ,";
                }
                else if (rdrR124A_XLS.GetString("COMP_CODE_GROUP") == "E" | rdrR124A_XLS.GetString("COMP_CODE_GROUP") == "I" | rdrR124A_XLS.GetString("COMP_CODE_GROUP") == "K")
                {
                    strReturnValue = "D 01,";
                }
                else if (rdrR124A_XLS.GetString("COMP_CODE_GROUP") == "E" | rdrR124A_XLS.GetString("COMP_CODE_GROUP") == "I" | rdrR124A_XLS.GetString("COMP_CODE_GROUP") == "K" | rdrR124A_XLS.GetString("COMP_CODE_GROUP") == "L")
                {
                    strReturnValue = "D 01,";
                }
                else if (rdrR124A_XLS.GetString("COMP_CODE_GROUP") == "M" | rdrR124A_XLS.GetString("COMP_CODE_GROUP") == "N")
                {
                    strReturnValue = "SK02,";
                }
                else
                {
                    strReturnValue = "D 01,";
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_TITLE_1()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = "YTD Statement of Earnings by Month (" + QDesign.Substring(QDesign.ASCII(rdrR124A_XLS.GetNumber("CURRENT_EP_NBR")), 1, 4) + "/" + QDesign.Substring(QDesign.ASCII(rdrR124A_XLS.GetNumber("CURRENT_EP_NBR")), 5, 2) + ") - Payments";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string YR_CURRENT()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.Substring(QDesign.ASCII(rdrR124A_XLS.GetNumber("FIRST_EP_NBR_OF_CAL_YR")), 1, 4);
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string YR_NEXT()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.Substring(QDesign.ASCII(rdrR124A_XLS.GetNumber("LAST_EP_NBR_OF_CAL_YR")), 1, 4);
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        #endregion

        #region " Renaissance Data "

        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                // Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;

                Sort = "DOC_DEPT ASC, DOC_NBR ASC, COMP_CODE_GROUP ASC, PROCESS_SEQ ASC";

                // Start report data processing.
                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return ReportData;
        }

        #endregion

        #region " Renaissance Statements "

        #region " ACCESS "

        private void Access_R124A_XLS()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("DOC_DEPT, ");
            strSQL.Append("X_DOC_ID_INFO, ");
            strSQL.Append("X_DEPT_NAME, ");
            strSQL.Append("COMP_CODE_GROUP, ");
            strSQL.Append("X_LINE_TEXT_XLS ");
            strSQL.Append("FROM TEMPORARYDATA.R124A_XLS ");

            strSQL.Append(Choose());

            rdrR124A_XLS.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);

            strSQL = null;
        }

        private void Link_F070_DEPT_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DEPT_COMPANY ");
            strSQL.Append("FROM [101C].INDEXED.F070_DEPT_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DEPT_NBR = ").Append(rdrR124A_XLS.GetNumber("DOC_DEPT"));

            rdrF070_DEPT_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

            strSQL = null;
        }

        private void Link_F123_COMPANY_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("COMPANY_NAME ");
            strSQL.Append("FROM [101C].INDEXED.F123_COMPANY_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("COMPANY_NBR = ").Append(rdrF070_DEPT_MSTR.GetNumber("DEPT_COMPANY"));

            rdrF123_COMPANY_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

            strSQL = null;
        }

        #endregion

        #region " CHOOSE "

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(string.Empty);


            return strChoose.ToString();
        }

        #endregion

        #region " SELECT IF "

        #endregion

        #region " DEFINES "

        #endregion

        #region " CONTROLS "

        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.R124A_XLS.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.HEADING_AT, "X_DOC_DEPT", DataTypes.Character, 5);
                AddControl(ReportSection.HEADING_AT, "INDEXED.F123_COMPANY_MSTR.COMPANY_NAME", DataTypes.Character, 40);
                AddControl(ReportSection.HEADING_AT, "X_TITLE_1", DataTypes.Character, 90);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.R124A_XLS.X_DOC_ID_INFO", DataTypes.Character, 50);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.R124A.X_DEPT_NAME", DataTypes.Character, 30);
                AddControl(ReportSection.HEADING_AT, "YR_CURRENT", DataTypes.Character, 4);
                AddControl(ReportSection.HEADING_AT, "YR_NEXT", DataTypes.Character, 4);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.R124A.COMP_CODE_GROUP", DataTypes.Character, 1);
                AddControl(ReportSection.HEADING_AT, "X_LINE_FLAG", DataTypes.Character, 5);
                AddControl(ReportSection.HEADING_AT, "X_COMP_CODE_GROUP_DESC", DataTypes.Character, 100);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R124A_XLS.X_LINE_TEXT_XLS", DataTypes.Character, 230);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.R124A_XLS.PROCESS_SEQ", DataTypes.Numeric, 3);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.R124A_XLS.DOC_DEPT", DataTypes.Numeric, 3);
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        #endregion

        #region " Renaissance Precompiler Generated Code "

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 2017-07-24 6:39:01 PM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "TEMPORARYDATA.R124A_XLS.DOC_NBR":
                    return Common.StringToField(rdrR124A_XLS.GetString("DOC_NBR")).PadRight(3, ' ');

                case "TEMPORARYDATA.R124A_XLS.PROCESS_SEQ":
                    return rdrR124A_XLS.GetNumber("PROCESS_SEQ").ToString().PadLeft(3,' ');

                case "TEMPORARYDATA.R124A_XLS.DOC_DEPT":
                    return rdrR124A_XLS.GetNumber("DOC_DEPT").ToString().PadLeft(3, ' ');

                case "X_DOC_DEPT":
                    return Common.StringToField(X_DOC_DEPT()).PadRight(5, ' ');

                case "INDEXED.F123_COMPANY_MSTR.COMPANY_NAME":
                    return Common.StringToField(rdrF123_COMPANY_MSTR.GetString("COMPANY_NAME")).PadRight(40, ' ');

                case "X_TITLE_1":
                    return Common.StringToField(X_TITLE_1()).PadRight(90, ' ');

                case "TEMPORARYDATA.R124A_XLS.X_DOC_ID_INFO":
                    return Common.StringToField(rdrR124A_XLS.GetString("X_DOC_ID_INFO")).PadRight(50, ' ');

                case "TEMPORARYDATA.R124A.X_DEPT_NAME":
                    return Common.StringToField(rdrR124A_XLS.GetString("X_DEPT_NAME")).PadRight(30, ' ');

                case "YR_CURRENT":
                    return Common.StringToField(YR_CURRENT()).PadRight(4, ' ');

                case "YR_NEXT":
                    return Common.StringToField(YR_NEXT()).PadRight(4, ' ');

                case "TEMPORARYDATA.R124A.COMP_CODE_GROUP":
                    return Common.StringToField(rdrR124A_XLS.GetString("COMP_CODE_GROUP")).PadRight(1, ' ');

                case "X_LINE_FLAG":
                    return Common.StringToField(X_LINE_FLAG()).PadRight(5, ' ');

                case "X_COMP_CODE_GROUP_DESC":
                    return Common.StringToField(X_COMP_CODE_GROUP_DESC()).PadRight(100, ' ');

                case "TEMPORARYDATA.R124A_XLS.X_LINE_TEXT_XLS":
                    return Common.StringToField(rdrR124A_XLS.GetString("X_LINE_TEXT_XLS")).PadRight(230, ' ');

                default:
                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_R124A_XLS();

                while (rdrR124A_XLS.Read())
                {
                    Link_F070_DEPT_MSTR();

                      while (rdrF070_DEPT_MSTR.Read())
                    {
                        Link_F123_COMPANY_MSTR();

                        while (rdrF123_COMPANY_MSTR.Read())
                        {
                            WriteData();
                        }
                        rdrF123_COMPANY_MSTR.Close();
                    }
                    rdrF070_DEPT_MSTR.Close();
                }
                rdrR124A_XLS.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrR124A_XLS != null))
            {
                rdrR124A_XLS.Close();
                rdrR124A_XLS = null;
            }

            if ((rdrF070_DEPT_MSTR != null))
            {
                rdrF070_DEPT_MSTR.Close();
                rdrF070_DEPT_MSTR = null;
            }

            if ((rdrF123_COMPANY_MSTR != null))
            {
                rdrF123_COMPANY_MSTR.Close();
                rdrF123_COMPANY_MSTR = null;
            }
        }

        #endregion

        #endregion
    }
}
