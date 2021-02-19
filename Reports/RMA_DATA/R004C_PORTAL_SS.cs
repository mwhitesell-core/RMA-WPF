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
    public class R004C_PORTAL_SS : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R004C_PORTAL_SS";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrR004B = new Reader();
        private Reader rdrF020_RPT = new Reader();

        #endregion

        #region " Renaissance Data "

        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                //  Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;
                Sort = "ICONST_CLINIC_NBR_1_2 ASC, CLMHDR_DOC_DEPT ASC, X_DOC_NBR ASC, X_PAT_NAME ASC, CLMDTL_SV_DATE ASC, X_CLAIM_DTL_ID ASC, X_OMA_CODE ASC";
                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return ReportData;
        }

        #endregion

        #region " Renaissance Statements "

        #region " ACCESS "

        private void Access_R004B()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("X_DOC_NBR, ");
            strSQL.Append("CLMHDR_DOC_DEPT, ");
            strSQL.Append("CLMDTL_SV_DATE, ");
            strSQL.Append("CLMHDR_DATE_SYS, ");
            strSQL.Append("CLMDTL_OMA_CD, ");
            strSQL.Append("CLMDTL_OMA_SUFF, ");
            strSQL.Append("CLMDTL_ADJ_CD, ");
            strSQL.Append("CLMDTL_AGENT_CD, ");
            strSQL.Append("X_SOURCE, ");
            strSQL.Append("X_REV_OHIP_FEE, ");
            strSQL.Append("X_REV_OHIP_ADJ, ");
            strSQL.Append("CLMDTL_DIAG_CD,,,, ");
            strSQL.Append("X_NBR_SVCS, ");
            strSQL.Append("PAT_SURNAME, ");
            strSQL.Append("PAT_GIVEN_NAME, ");
            strSQL.Append("X_CLAIM_DTL_ID, ");
            strSQL.Append("X_PAT_ID_INFO, ");
            strSQL.Append("X_ORIG_BATCH, ");
            strSQL.Append("CLMHDR_REFERENCE, ");
            strSQL.Append("ICONST_CLINIC_NBR_1_2 ");
            strSQL.Append("FROM TEMPORARYDATA.R004B ");
            strSQL.Append(Choose());
            rdrR004B.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
            strSQL = null;
        }
        private void Link_F020_RPT()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("REPORT_ID ");
            strSQL.Append("FROM INDEXED.F020_RPT ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_NBR = '").Append(rdrR004B.GetString("X_DOC_NBR"));
            strSQL.Append("'");
            strSQL.Append(" AND REPORT_ID = ").Append(1);
            rdrF020_RPT.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
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

        public override bool SelectIf()
        {
            bool blnSelected = false;
            if (!ReportDataFunctions.Exists(rdrF020_RPT))
            {
                blnSelected = true;
            }

            return blnSelected;
        }

        #endregion

        #region " DEFINES "

        private string DELIMITER()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = ",";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_DOC_DEPT_NBR()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = ("\"" + (rdrR004B.GetString("X_DOC_NBR") + (QDesign.ASCII(rdrR004B.GetNumber("CLMHDR_DOC_DEPT"), 2) + "\"")));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }


            return strReturnValue;
        }

        private string X_TAB()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = "^";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_SERVICE_DATE()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = "\"" + QDesign.Substring(rdrR004B.GetString("CLMDTL_SV_DATE"), 1, 4) + "-" + QDesign.Substring(rdrR004B.GetString("CLMDTL_SV_DATE"), 5, 2) + "-" + QDesign.Substring(rdrR004B.GetString("CLMDTL_SV_DATE"), 7, 2) + "\"";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_ENTRY_DATE()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = "\"" + QDesign.Substring(rdrR004B.GetString("CLMHDR_DATE_SYS"), 1, 4) + "-" + QDesign.Substring(rdrR004B.GetString("CLMHDR_DATE_SYS"), 5, 2) + "-" + QDesign.Substring(rdrR004B.GetString("CLMHDR_DATE_SYS"), 7, 2) + "\"";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_OMA_CD_SUFF()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = "\"" + (rdrR004B.GetString("CLMDTL_OMA_CD") + rdrR004B.GetString("CLMDTL_OMA_SUFF").PadRight(1, ' ')) + "\"";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_CLMDTL_ADJ_CD()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = "\"" + rdrR004B.GetString("CLMDTL_ADJ_CD").PadRight(1, ' ') + "\"";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        //  TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:
        private string X_AGENT()
        {
            string strReturnValue = string.Empty;
            try
            {
                if (rdrR004B.GetNumber("CLMDTL_AGENT_CD") == 0)
                {
                    strReturnValue = "\"0 - OHIP BILLING\"";
                }
                else if (rdrR004B.GetNumber("CLMDTL_AGENT_CD") == 1)
                {
                    strReturnValue = "\"1 - DIAGNOSTIC BILLING\"";
                }
                else if ((rdrR004B.GetNumber("CLMDTL_AGENT_CD") == 2))
                {
                    strReturnValue = "\"2 - OHIP WCB BILLING\"";
                }
                else if ((rdrR004B.GetNumber("CLMDTL_AGENT_CD") == 3))
                {
                    strReturnValue = "\"3 - ICU (85) DIRECT BILL\"";
                }
                else if ((rdrR004B.GetNumber("CLMDTL_AGENT_CD") == 4))
                {
                    strReturnValue = "\"4 - INELIGIBLE OHIP/BILL PATIENT\"";
                }
                else if ((rdrR004B.GetNumber("CLMDTL_AGENT_CD") == 5))
                {
                    strReturnValue = "\"5 - MOH REMITTANCE REDUCTION (MOHR)\"";
                }
                else if ((rdrR004B.GetNumber("CLMDTL_AGENT_CD") == 6))
                {
                    strReturnValue = "\"6 - PATIENT/INSURANCE BILLING\"";
                }
                else if ((rdrR004B.GetNumber("CLMDTL_AGENT_CD") == 7))
                {
                    strReturnValue = "\"7 - MISCELLANEOUS PAYMENT\"";
                }
                else if ((rdrR004B.GetNumber("CLMDTL_AGENT_CD") == 8))
                {
                    strReturnValue = "\"8 - NEONATAL / GERIATRICS ALT / ICU ALT\"";
                }
                else if ((rdrR004B.GetNumber("CLMDTL_AGENT_CD") == 9))
                {
                    strReturnValue = "\"9 - W.C.B. BILLING / W.C.B. MISC.\"";
                }
                else
                {
                    strReturnValue = QDesign.Pack("\"" + QDesign.ASCII(rdrR004B.GetNumber("CLMDTL_AGENT_CD")) + "\"");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_SOURCE_CD()
        {
            string strReturnValue = string.Empty;
            try
            {
                if (QDesign.NULL(QDesign.Substring(rdrR004B.GetString("X_SOURCE"), 2, 1)) == "D")
                {
                    strReturnValue = "\"D - Diskette\"";
                }
                else if (QDesign.NULL(QDesign.Substring(rdrR004B.GetString("X_SOURCE"), 2, 1)) == "W")
                {
                    strReturnValue = "\"W - Webstar\"";
                }
                else if (QDesign.NULL(QDesign.Substring(rdrR004B.GetString("X_SOURCE"), 2, 1)) == "A")
                {
                    strReturnValue = "\"A - Cash+Revenue Adj.\"";
                }
                else if (QDesign.NULL(QDesign.Substring(rdrR004B.GetString("X_SOURCE"), 2, 1)) == "R")
                {
                    strReturnValue = "\"R - Revenue only Adj.\"";
                }
                else
                {
                    strReturnValue = "\"" + rdrR004B.GetString("X_SOURCE") + " \"";
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_OHIP_FEE_SIGN()
        {
            string strReturnValue = string.Empty;
            try
            {
                if (rdrR004B.GetNumber("X_REV_OHIP_FEE") < 0)
                {
                    strReturnValue = "-";
                }
                else
                {
                    strReturnValue = " ";
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_OHIP_ADJ_SIGN()
        {
            string strReturnValue = string.Empty;
            try
            {
                if (rdrR004B.GetNumber("X_REV_OHIP_ADJ") < 0)
                {
                    strReturnValue = "-";
                }
                else
                {
                    strReturnValue = " ";
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_PERIOD()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = ".";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private decimal X_OHIP_FEE_DOLLARS()
        {
            decimal decReturnValue = 0;

            try
            {
                if (rdrR004B.GetNumber("X_REV_OHIP_FEE") != 0)
                {
                    decReturnValue = (Math.Abs(rdrR004B.GetNumber("X_REV_OHIP_FEE")) / 100);
                }
                else
                {
                    decReturnValue = 0;
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_OHIP_FEE_CENTS()
        {
            decimal decReturnValue = 0;
            try
            {
                if (rdrR004B.GetNumber("X_REV_OHIP_FEE") != 0)
                {
                    decReturnValue = QDesign.PHMod(Math.Abs(rdrR004B.GetNumber("X_REV_OHIP_FEE")), 100);
                }
                else
                {
                    decReturnValue = 0;
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_OHIP_ADJ_DOLLARS()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((rdrR004B.GetNumber("X_REV_OHIP_ADJ") != 0))
                {
                    decReturnValue = (Math.Abs(rdrR004B.GetNumber("X_REV_OHIP_ADJ")) / 100);
                }
                else
                {
                    decReturnValue = 0;
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_OHIP_ADJ_CENTS()
        {
            decimal decReturnValue = 0;

            try
            {
                if ((rdrR004B.GetNumber("X_REV_OHIP_ADJ") != 0))
                {
                    decReturnValue = QDesign.PHMod(Math.Abs(rdrR004B.GetNumber("X_REV_OHIP_ADJ")), 100);
                }
                else
                {
                    decReturnValue = 0;
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private string X_DIAG_CD_ALPHA()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = QDesign.Pack(("\"" + (QDesign.ASCII(rdrR004B.GetNumber("CLMDTL_DIAG_CD")).PadRight(1, ' ') + "\"")));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_NBR_SVCS_ALPHA()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = QDesign.Pack(("\"" + (QDesign.ASCII(rdrR004B.GetNumber("X_NBR_SVCS")) + "\"")));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_PAT_SURNAME()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = "\"" + rdrR004B.GetString("PAT_SURNAME") + " \"";
            }
            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_PAT_GIVEN_NAME()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = "\"" + rdrR004B.GetString("PAT_GIVEN_NAME") + " \"";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_X_CLAIM_DTL_ID()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = QDesign.Pack("\"" + rdrR004B.GetString("X_CLAIM_DTL_ID") + "\"");
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_OHIP_FEE_ALPHA()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = QDesign.Pack(("\"" + (QDesign.LeftJustify((X_OHIP_FEE_SIGN() + (QDesign.ASCII(X_OHIP_FEE_DOLLARS()) + (X_PERIOD() + QDesign.ASCII(X_OHIP_FEE_CENTS(), 2))))).TrimEnd() + "\"")));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_OHIP_ADJ_ALPHA()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = QDesign.Pack(("\"" + (QDesign.LeftJustify((X_OHIP_ADJ_SIGN() + (QDesign.ASCII(X_OHIP_ADJ_DOLLARS()) + (X_PERIOD() + QDesign.ASCII(X_OHIP_ADJ_CENTS(), 2))))).TrimEnd() + "\"")));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_X_PAT_ID_INFO()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = QDesign.Pack("\"" + rdrR004B.GetString("X_PAT_ID_INFO") + " \"");
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_X_ORIG_BATCH()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = QDesign.Pack(("\"" + (rdrR004B.GetString("X_ORIG_BATCH").PadRight(1, ' ') + "\"")));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_CLMHDR_REFERENCE()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = QDesign.Pack(("\"" + (rdrR004B.GetString("CLMHDR_REFERENCE").PadRight(1, ' ') + "\"")));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_LINE()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = QDesign.LeftJustify(QDesign.Pack(X_PAT_SURNAME()
                                    + " " + X_TAB()
                                    + X_PAT_GIVEN_NAME()
                                    + " " + X_TAB()
                                    + X_X_CLAIM_DTL_ID()
                                    + " " + X_TAB()
                                    + X_X_PAT_ID_INFO()
                                    + " " + X_TAB()
                                    + X_AGENT()
                                    + " " + X_TAB()
                                    + X_CLMDTL_ADJ_CD()
                                    + X_TAB()
                                    + X_SOURCE_CD()
                                    + X_TAB()
                                    + X_OHIP_FEE_ALPHA()
                                    + " " + X_TAB()
                                    + X_OHIP_ADJ_ALPHA()
                                    + " " + X_TAB()
                                    + X_SERVICE_DATE()
                                    + X_TAB()
                                    + X_ENTRY_DATE()
                                    + X_TAB()
                                    + X_DIAG_CD_ALPHA()
                                    + X_TAB()
                                    + X_OMA_CD_SUFF()
                                    + X_TAB()
                                    + X_NBR_SVCS_ALPHA()
                                    + " " + X_TAB()
                                    + X_X_ORIG_BATCH()
                                    + X_TAB()
                                    + X_CLMHDR_REFERENCE()
                                    + " " + X_TAB() + X_DOC_DEPT_NBR()));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
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
                AddControl(ReportSection.INITIAL_HEADING, "X_TAB", DataTypes.Character, 5);
                AddControl(ReportSection.INITIAL_HEADING, "X_DOC_DEPT_NBR", DataTypes.Character, 7);
                AddControl(ReportSection.REPORT, "X_LINE", DataTypes.Character, 262);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R004B.ICONST_CLINIC_NBR_1_2", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R004B.CLMHDR_DOC_DEPT", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R004B.X_DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R004B.X_PAT_NAME", DataTypes.Character, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R004B.CLMDTL_SV_DATE", DataTypes.Character, 8);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R004B.X_CLAIM_DTL_ID", DataTypes.Character, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R004B.X_OMA_CODE", DataTypes.Character, 5);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        #endregion

        #region " Renaissance Precompiler Generated Code "

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-04-27 1:12:22 PM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "X_TAB":
                    return Common.StringToField(X_TAB(), intSize);

                case "X_DOC_DEPT_NBR":
                    return Common.StringToField(X_DOC_DEPT_NBR(), intSize);

                case "X_LINE":
                    return Common.StringToField(X_LINE(), intSize);

                case "TEMPORARYDATA.R004B.ICONST_CLINIC_NBR_1_2":
                    return rdrR004B.GetNumber("ICONST_CLINIC_NBR_1_2").ToString().PadLeft(2, ' ');

                case "TEMPORARYDATA.R004B.CLMHDR_DOC_DEPT":
                    return rdrR004B.GetNumber("CLMHDR_DOC_DEPT").ToString().PadLeft(2, ' ');

                case "TEMPORARYDATA.R004B.X_DOC_NBR":
                    return Common.StringToField(rdrR004B.GetString("X_DOC_NBR").PadRight(3, ' '));

                case "TEMPORARYDATA.R004B.X_PAT_NAME":
                    return Common.StringToField(rdrR004B.GetString("X_PAT_NAME").PadRight(10, ' '));

                case "TEMPORARYDATA.R004B.CLMDTL_SV_DATE":
                    return Common.StringToField(rdrR004B.GetString("CLMDTL_SV_DATE").PadRight(8, ' '));

                case "TEMPORARYDATA.R004B.X_CLAIM_DTL_ID":
                    return Common.StringToField(rdrR004B.GetString("X_CLAIM_DTL_ID").PadRight(10, ' '));

                case "TEMPORARYDATA.R004B.X_OMA_CODE":
                    return Common.StringToField(rdrR004B.GetString("X_OMA_CODE").PadRight(5, ' '));

                default:
                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_R004B();
                while (rdrR004B.Read())
                {
                    Link_F020_RPT();
                    while (rdrF020_RPT.Read())
                    {
                        WriteData();
                    }

                    rdrF020_RPT.Close();
                }

                rdrR004B.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrR004B != null))
            {
                rdrR004B.Close();
                rdrR004B = null;
            }

            if ((rdrF020_RPT != null))
            {
                rdrF020_RPT.Close();
                rdrF020_RPT = null;
            }
        }

        #endregion

        #endregion
    }
}
