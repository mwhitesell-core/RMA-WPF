#region "Screen Comments"

// #> PROGRAM-ID.     R120.QZS
// ((C)) Dyad Technologies
// PURPOSE: Prdecimal the Earnings Register
// MODIFICATION HISTORY
// DATE    SAF #  WHO      DESCRIPTION
// 92/MAY/01  ____   R.A.     - original
// 03/nov/20  M.C.  - alpha doc nbr
// 03/dec/16  A.A.  - alpha doctor nbr

#endregion
using Core.DataAccess.TextFile;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.ReportFramework;
using System;
using System.Data;
using System.Text;

namespace RMA_DATA
{
    public class R120 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R120";
        protected const bool REPORT_HAS_PARAMETERS = true;

        // Data Helpers.
        private Reader rdrR120AA = new Reader();

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

                Sort = "D_CHAR_DEPT ASC, D_CHAR_F_P_IND ASC, D_CHAR_DOC ASC, EP_NBR ASC, PROCESS_SEQ ASC, COMP_CODE ASC";

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

        private void Access_R120AA()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("D_CHAR_DOC, ");
            strSQL.Append("EP_NBR, ");
            strSQL.Append("FACTOR, ");
            strSQL.Append("D_CHAR_DEPT, ");
            strSQL.Append("D_CHAR_F_P_IND, ");
            strSQL.Append("PROCESS_SEQ, ");
            strSQL.Append("COMP_CODE, ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("DOC_NAME, ");
            strSQL.Append("DOC_DEPT, ");
            strSQL.Append("DOC_FULL_PART_IND, ");
            strSQL.Append("DOC_PAY_CODE, ");
            strSQL.Append("DOC_PAY_SUB_CODE, ");
            strSQL.Append("DOC_YRLY_CEILING, ");
            strSQL.Append("DOC_YRLY_CEILING_GUAR_PERC, ");
            strSQL.Append("DOC_YRLY_CEIL_GUAR, ");
            strSQL.Append("DOC_YRLY_EXPENSE, ");
            strSQL.Append("DOC_YRLY_EXPN_ALLOC_PERS, ");
            strSQL.Append("COMP_TYPE, ");
            strSQL.Append("DESC_SHORT, ");
            strSQL.Append("COMPENSATION_FACTOR, ");
            strSQL.Append("AMT_GROSS, ");
            strSQL.Append("AMT_NET, ");
            strSQL.Append("COMPENSATION_STATUS ");
            strSQL.Append("FROM TEMPORARYDATA.R120AA ");

            strSQL.Append(Choose());

            rdrR120AA.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);

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
        private decimal W_SEL_EP_NBR_FROM()
        {
            decimal decReturnValue = 0;

            try
            {
                if (ReportFunctions.astrScreenParameters[0].ToString().Trim() != string.Empty)
                {
                    decReturnValue = Convert.ToDecimal(ReportFunctions.astrScreenParameters[0].ToString());
                    // Prompt String: "Enter EP FROM: "
                }
                else
                {
                    decReturnValue = 0;
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private decimal W_SEL_EP_NBR_TO()
        {
            decimal decReturnValue = 0;

            try
            {
                if (ReportFunctions.astrScreenParameters[1].ToString().Trim() != string.Empty)
                {
                    decReturnValue = Convert.ToDecimal(ReportFunctions.astrScreenParameters[1].ToString());
                    // Prompt String: "Enter EP TO  : "
                }
                else
                {
                    decReturnValue = 0;
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private string D_EP_NBR()
        {
            string strReturnValue = string.Empty;

            try
            {
                if (QDesign.NULL(rdrR120AA.GetString("D_CHAR_DOC")) != "ZZZ")
                {
                    strReturnValue = QDesign.ASCII(rdrR120AA.GetNumber("EP_NBR"));
                }
                else
                {
                    strReturnValue = " ";
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string D_FACTOR()
        {
            string strReturnValue = string.Empty;

            try
            {
                if (QDesign.NULL(rdrR120AA.GetString("D_CHAR_DOC")) == "ZZZ")
                {
                    strReturnValue = " ";
                }
                else if (99999 < QDesign.NULL(rdrR120AA.GetNumber("FACTOR")))
                {
                    strReturnValue = QDesign.RightJustify(QDesign.Substring(QDesign.ASCII(rdrR120AA.GetNumber("FACTOR"), 6), 1, 2) + "." + QDesign.Substring(QDesign.ASCII(rdrR120AA.GetNumber("FACTOR"), 6), 3, 4));
                }
                else if (9999 < QDesign.NULL(rdrR120AA.GetNumber("FACTOR")))
                {
                    strReturnValue = QDesign.RightJustify(QDesign.Substring(QDesign.ASCII(rdrR120AA.GetNumber("FACTOR"), 6), 2, 1) + "." + QDesign.Substring(QDesign.ASCII(rdrR120AA.GetNumber("FACTOR"), 6), 3, 4));
                }
                else
                {
                    strReturnValue = QDesign.RightJustify("." + QDesign.Substring(QDesign.ASCII(rdrR120AA.GetNumber("FACTOR"), 6), 3, 4));
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        #endregion

        #region " CONTROLS "

        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.PAGE_HEADING, "W_SEL_EP_NBR_FROM", DataTypes.Numeric, 6);
                AddControl(ReportSection.PAGE_HEADING, "W_SEL_EP_NBR_TO", DataTypes.Numeric, 6);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.R120AA.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.R120AA.DOC_NAME", DataTypes.Character, 24);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.R120AA.DOC_DEPT", DataTypes.Numeric, 2);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.R120AA.DOC_FULL_PART_IND", DataTypes.Character, 1);
                AddControl(ReportSection.HEADING_AT, "D_EP_NBR", DataTypes.Character, 6);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.R120AA.DOC_PAY_CODE", DataTypes.Character, 1);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.R120AA.DOC_PAY_SUB_CODE", DataTypes.Character, 1);
                AddControl(ReportSection.HEADING_AT, "D_FACTOR", DataTypes.Character, 7);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.R120AA.DOC_YRLY_CEILING", DataTypes.Numeric, 7);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.R120AA.DOC_YRLY_CEILING_GUAR_PERC", DataTypes.Numeric, 3);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.R120AA.DOC_YRLY_CEIL_GUAR", DataTypes.Numeric, 7);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.R120AA.DOC_YRLY_EXPENSE", DataTypes.Numeric, 7);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.R120AA.DOC_YRLY_EXPN_ALLOC_PERS", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R120AA.COMP_TYPE", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R120AA.COMP_CODE", DataTypes.Character, 6);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R120AA.DESC_SHORT", DataTypes.Character, 15);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R120AA.COMPENSATION_FACTOR", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R120AA.AMT_GROSS", DataTypes.Numeric, 18);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R120AA.AMT_NET", DataTypes.Numeric, 18);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R120AA.COMPENSATION_STATUS", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R120AA.D_CHAR_DEPT", DataTypes.Character, 2);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R120AA.D_CHAR_F_P_IND", DataTypes.Character, 2);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R120AA.D_CHAR_DOC", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R120AA.EP_NBR", DataTypes.Numeric, 7);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R120AA.PROCESS_SEQ", DataTypes.Numeric, 3);
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
        //# Do not delete, modify or move it.  Updated: 6/29/2017 2:21:09 PM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "W_SEL_EP_NBR_FROM":
                    return W_SEL_EP_NBR_FROM().ToString().PadLeft(6, ' ');

                case "W_SEL_EP_NBR_TO":
                    return W_SEL_EP_NBR_TO().ToString().PadLeft(6, ' ');

                case "TEMPORARYDATA.R120AA.DOC_NBR":
                    return Common.StringToField(rdrR120AA.GetString("DOC_NBR").PadRight(3, ' '));

                case "TEMPORARYDATA.R120AA.DOC_NAME":
                    return Common.StringToField(rdrR120AA.GetString("DOC_NAME").PadRight(24, ' '));

                case "TEMPORARYDATA.R120AA.DOC_DEPT":
                    return rdrR120AA.GetNumber("DOC_DEPT").ToString().PadLeft(2, ' ');

                case "TEMPORARYDATA.R120AA.DOC_FULL_PART_IND":
                    return Common.StringToField(rdrR120AA.GetString("DOC_FULL_PART_IND").PadRight(1, ' '));

                case "D_EP_NBR":
                    return Common.StringToField(D_EP_NBR(), intSize);

                case "TEMPORARYDATA.R120AA.DOC_PAY_CODE":
                    return Common.StringToField(rdrR120AA.GetString("DOC_PAY_CODE").PadRight(1, ' '));

                case "TEMPORARYDATA.R120AA.DOC_PAY_SUB_CODE":
                    return Common.StringToField(rdrR120AA.GetString("DOC_PAY_SUB_CODE").PadRight(1, ' '));

                case "D_FACTOR":
                    return Common.StringToField(D_FACTOR(), intSize);

                case "TEMPORARYDATA.R120AA.DOC_YRLY_CEILING":
                    return rdrR120AA.GetNumber("DOC_YRLY_CEILING").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R120AA.DOC_YRLY_CEILING_GUAR_PERC":
                    return rdrR120AA.GetNumber("DOC_YRLY_CEILING_GUAR_PERC").ToString().PadLeft(3, ' ');

                case "TEMPORARYDATA.R120AA.DOC_YRLY_CEIL_GUAR":
                    return rdrR120AA.GetNumber("DOC_YRLY_CEIL_GUAR").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R120AA.DOC_YRLY_EXPENSE":
                    return rdrR120AA.GetNumber("DOC_YRLY_EXPENSE").ToString().PadLeft(7, ' ');
                    
                case "TEMPORARYDATA.R120AA.DOC_YRLY_EXPN_ALLOC_PERS":
                    return rdrR120AA.GetNumber("DOC_YRLY_EXPN_ALLOC_PERS").ToString().PadLeft(2, ' ');

                case "TEMPORARYDATA.R120AA.COMP_TYPE":
                    return Common.StringToField(rdrR120AA.GetString("COMP_TYPE").PadRight(1, ' '));

                case "TEMPORARYDATA.R120AA.COMP_CODE":
                    return Common.StringToField(rdrR120AA.GetString("COMP_CODE")).PadRight(6,' ');

                case "TEMPORARYDATA.R120AA.DESC_SHORT":
                    return Common.StringToField(rdrR120AA.GetString("DESC_SHORT").PadRight(15, ' '));

                case "TEMPORARYDATA.R120AA.COMPENSATION_FACTOR":
                    return rdrR120AA.GetNumber("COMPENSATION_FACTOR").ToString().PadLeft(6, ' ');

                case "TEMPORARYDATA.R120AA.AMT_GROSS":
                    return rdrR120AA.GetNumber("AMT_GROSS").ToString().PadLeft(14, ' ');

                case "TEMPORARYDATA.R120AA.AMT_NET":
                    return rdrR120AA.GetNumber("AMT_NET").ToString().PadLeft(14, ' ');

                case "TEMPORARYDATA.R120AA.COMPENSATION_STATUS":
                    return Common.StringToField(rdrR120AA.GetString("COMPENSATION_STATUS")).PadRight(1,' ');

                case "TEMPORARYDATA.R120AA.D_CHAR_DEPT":
                    return Common.StringToField(rdrR120AA.GetString("D_CHAR_DEPT")).PadRight(2, ' ');

                case "TEMPORARYDATA.R120AA.D_CHAR_F_P_IND":
                    return Common.StringToField(rdrR120AA.GetString("D_CHAR_F_P_IND")).PadRight(2, ' ');

                case "TEMPORARYDATA.R120AA.D_CHAR_DOC":
                    return Common.StringToField(rdrR120AA.GetString("D_CHAR_DOC")).PadRight(3, ' ');

                case "TEMPORARYDATA.R120AA.EP_NBR":
                    return rdrR120AA.GetNumber("EP_NBR").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R120AA.PROCESS_SEQ":
                    return rdrR120AA.GetNumber("PROCESS_SEQ").ToString().PadLeft(3, '0');

                default:
                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_R120AA();

                while (rdrR120AA.Read())
                {
                    WriteData();
                }
                rdrR120AA.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrR120AA != null))
            {
                rdrR120AA.Close();
                rdrR120AA = null;
            }
        }


        #endregion

        #endregion
    }
}
