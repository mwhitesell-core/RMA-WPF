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
    public class R715 : BaseRDLClass
    {
        protected const string REPORT_NAME = "R715";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrF002_SUSPEND_HDR = new Reader();
        private Reader rdrF002_SUSPEND_DTL = new Reader();
        private Reader rdrF002_SUSPEND_ADDRESS = new Reader();
        // #CORE_BEGIN_INCLUDE: DEF_CLMHDR_STATUS"
        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-09-13 11:57:55 AM
        private string CLMHDR_STATUS_COMPLETE()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = "C";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string CLMHDR_STATUS_DELETE()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = "D";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string CLMHDR_STATUS_CANCEL()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = "Y";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string CLMHDR_STATUS_RESUBMIT()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = "R";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string CLMHDR_STATUS_ERROR()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = "X";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string CLMHDR_STATUS_NOT_COMPLETE()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = "N";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string CLMHDR_STATUS_DEFAULT()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = " ";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string UPDATED()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = "U";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string CLMHDR_STATUS_IGNOR()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = "I";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        // #CORE_END_INCLUDE: DEF_CLMHDR_STATUS"
        // #CORE_BEGIN_INCLUDE: F002_CONSECUTIVE_DATES"
        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-09-13 11:57:55 AM
        private string W_CLMDTL_SV_DAY_1()
        {
            string strReturnValue = String.Empty;
            try
            {
                if (QDesign.NULL(QDesign.Substring(rdrF002_SUSPEND_DTL.GetString("CLMDTL_CONSEC_DATES_R"), 7, 2)) == "00")
                {
                    strReturnValue = " ";
                }
                else
                {
                    strReturnValue = QDesign.Substring(rdrF002_SUSPEND_DTL.GetString("CLMDTL_CONSEC_DATES_R"), 7, 2);
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                //  Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;
                Sort = "CLMHDR_DOC_OHIP_NBR ASC, CLMHDR_ACCOUNTING_NBR ASC";
                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return ReportData;
        }
        private void Access_F002_SUSPEND_HDR()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            strSQL.Append("SELECT ");
            strSQL.Append("CLMHDR_DOC_OHIP_NBR, ");
            strSQL.Append("CLMHDR_ACCOUNTING_NBR, ");
            strSQL.Append("CLMHDR_STATUS, ");
            strSQL.Append("CLMHDR_AGENT_CD, ");
            strSQL.Append("CLMHDR_PAT_KEY_DATA, ");
            strSQL.Append("CLMHDR_PAT_ACRONYM6, ");
            strSQL.Append("CLMHDR_PAT_ACRONYM3, ");
            strSQL.Append("CLMHDR_LOC, ");
            strSQL.Append("CLMHDR_HOSP, ");
            strSQL.Append("CLMHDR_DATE_ADMIT, ");
            strSQL.Append("CLMHDR_I_O_PAT_IND, ");
            strSQL.Append("CLMHDR_DIAG_CD, ");
            strSQL.Append("CLMHDR_TAPE_SUBMIT_IND, ");
            strSQL.Append("CLMHDR_DOC_SPEC_CD, ");
            strSQL.Append("CLMHDR_REFER_DOC_NBR ");
            strSQL.Append("FROM INDEXED.F002_SUSPEND_HDR ");
            strSQL.Append(Choose());
            strSQL.Append(SelectIf_F002_SUSPEND_HDR(true));
            rdrF002_SUSPEND_HDR.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.m_strFlatFileDictionary, ReportFunctions.TextFiles);
            strSQL = null;
        }
        private void Link_F002_SUSPEND_DTL()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("CLMDTL_DOC_OHIP_NBR, ");
            strSQL.Append("CLMDTL_ACCOUNTING_NBR, ");
            strSQL.Append("CLMDTL_CONSEC_DATES_R, ");
            strSQL.Append("CLMDTL_OMA_CD, ");
            strSQL.Append("CLMDTL_OMA_SUFF, ");
            strSQL.Append("CLMDTL_SV_YY, ");
            strSQL.Append("CLMDTL_SV_MM, ");
            strSQL.Append("CLMDTL_SV_DD, ");
            strSQL.Append("CLMDTL_FEE_OMA, ");
            strSQL.Append("CLMDTL_NBR_SERV ");
            strSQL.Append("FROM INDEXED.F002_SUSPEND_DTL ");
            strSQL.Append("WHERE ");
            strSQL.Append("CLMDTL_DOC_OHIP_NBR = ").Append(rdrF002_SUSPEND_HDR.GetNumber("CLMHDR_DOC_OHIP_NBR"));
            strSQL.Append(" AND CLMDTL_ACCOUNTING_NBR = ").Append(Common.StringToField(rdrF002_SUSPEND_HDR.GetString("CLMHDR_ACCOUNTING_NBR")));
            rdrF002_SUSPEND_DTL.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.m_strFlatFileDictionary, ReportFunctions.TextFiles);
            strSQL = null;
        }
        private void Link_F002_SUSPEND_ADDRESS()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("ADD_DOC_OHIP_NBR, ");
            strSQL.Append("ADD_ACCOUNTING_NBR, ");
            strSQL.Append("ADD_SURNAME, ");
            strSQL.Append("ADD_FIRST_NAME ");
            strSQL.Append("FROM INDEXED.F002_SUSPEND_ADDRESS ");
            strSQL.Append("WHERE ");
            strSQL.Append("ADD_DOC_OHIP_NBR = ").Append(rdrF002_SUSPEND_HDR.GetNumber("CLMHDR_DOC_OHIP_NBR"));
            strSQL.Append(" AND ADD_ACCOUNTING_NBR = ").Append(Common.StringToField(rdrF002_SUSPEND_HDR.GetString("CLMHDR_ACCOUNTING_NBR")));
            rdrF002_SUSPEND_ADDRESS.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.m_strFlatFileDictionary, ReportFunctions.TextFiles);
            strSQL = null;
        }

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(String.Empty);
            // TODO: CHOOSE Statement - May require manual changes.
            return strChoose.ToString().ToString();
        }

        private string SelectIf_F002_SUSPEND_HDR(bool blnAddWhere)
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            if (blnAddWhere)
            {
                strSQL.Append(" WHERE ");
            }
            else
            {
                strSQL.Append(" AND ");
            }

            strSQL.Append("CLMHDR_STATUS = ").Append(Common.StringToField(CLMHDR_STATUS_RESUBMIT()));
            return strSQL.ToString().ToString();
        }

        private string F002_SUSPEND_HDR_CLMHDR_PAT_ACRONYM()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = (rdrF002_SUSPEND_HDR.GetString("CLMHDR_PAT_ACRONYM6").PadRight(6) + rdrF002_SUSPEND_HDR.GetString("CLMHDR_PAT_ACRONYM3"));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string F002_SUSPEND_DTL_CLMDTL_SV_DATE()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = QDesign.ASCII(rdrF002_SUSPEND_DTL.GetNumber("CLMDTL_SV_YY"), 4) + QDesign.ASCII(rdrF002_SUSPEND_DTL.GetNumber("CLMDTL_SV_MM"), 2) + QDesign.ASCII(rdrF002_SUSPEND_DTL.GetNumber("CLMDTL_SV_DD"), 2);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private decimal F002_SUSPEND_DTL_CLMDTL_SV_NBR1()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = QDesign.NConvert(QDesign.Substring(rdrF002_SUSPEND_DTL.GetString("CLMDTL_CONSEC_DATES_R"), 1, 1));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal F002_SUSPEND_DTL_CLMDTL_SV_NBR2()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = QDesign.NConvert(QDesign.Substring(rdrF002_SUSPEND_DTL.GetString("CLMDTL_CONSEC_DATES_R"), 4, 1));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal F002_SUSPEND_DTL_CLMDTL_SV_NBR3()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = QDesign.NConvert(QDesign.Substring(rdrF002_SUSPEND_DTL.GetString("CLMDTL_CONSEC_DATES_R"), 7, 1));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal F002_SUSPEND_DTL_CLMDTL_SV_DAY2()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = QDesign.NConvert(QDesign.Substring(rdrF002_SUSPEND_DTL.GetString("CLMDTL_CONSEC_DATES_R"), 5, 2));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal F002_SUSPEND_DTL_CLMDTL_SV_DAY3()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = QDesign.NConvert(QDesign.Substring(rdrF002_SUSPEND_DTL.GetString("CLMDTL_CONSEC_DATES_R"), 8, 2));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.HEADING_AT, "INDEXED.F002_SUSPEND_HDR.CLMHDR_DOC_OHIP_NBR", DataTypes.Numeric, 6);
                AddControl(ReportSection.HEADING_AT, "INDEXED.F002_SUSPEND_HDR.CLMHDR_ACCOUNTING_NBR", DataTypes.Character, 8);
                AddControl(ReportSection.HEADING_AT, "INDEXED.F002_SUSPEND_HDR.CLMHDR_AGENT_CD", DataTypes.Numeric, 1);
                AddControl(ReportSection.HEADING_AT, "INDEXED.F002_SUSPEND_ADDRESS.ADD_SURNAME", DataTypes.Character, 25);
                AddControl(ReportSection.HEADING_AT, "INDEXED.F002_SUSPEND_HDR.CLMHDR_PAT_KEY_DATA", DataTypes.Character, 15);
                AddControl(ReportSection.HEADING_AT, "INDEXED.F002_SUSPEND_ADDRESS.ADD_FIRST_NAME", DataTypes.Character, 25);
                AddControl(ReportSection.HEADING_AT, "CLMHDR_PAT_ACRONYM", DataTypes.Character, 9);
                AddControl(ReportSection.HEADING_AT, "INDEXED.F002_SUSPEND_HDR.CLMHDR_LOC", DataTypes.Character, 4);
                AddControl(ReportSection.HEADING_AT, "INDEXED.F002_SUSPEND_HDR.CLMHDR_HOSP", DataTypes.Character, 1);
                AddControl(ReportSection.HEADING_AT, "INDEXED.F002_SUSPEND_HDR.CLMHDR_DATE_ADMIT", DataTypes.Character, 8);
                AddControl(ReportSection.HEADING_AT, "INDEXED.F002_SUSPEND_HDR.CLMHDR_I_O_PAT_IND", DataTypes.Character, 1);
                AddControl(ReportSection.HEADING_AT, "INDEXED.F002_SUSPEND_HDR.CLMHDR_DIAG_CD", DataTypes.Numeric, 3);
                AddControl(ReportSection.HEADING_AT, "INDEXED.F002_SUSPEND_HDR.CLMHDR_TAPE_SUBMIT_IND", DataTypes.Character, 1);
                AddControl(ReportSection.HEADING_AT, "INDEXED.F002_SUSPEND_HDR.CLMHDR_DOC_SPEC_CD", DataTypes.Numeric, 2);
                AddControl(ReportSection.HEADING_AT, "INDEXED.F002_SUSPEND_HDR.CLMHDR_REFER_DOC_NBR", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "INDEXED.F002_SUSPEND_DTL.CLMDTL_OMA_CD", DataTypes.Character, 4);
                AddControl(ReportSection.REPORT, "INDEXED.F002_SUSPEND_DTL.CLMDTL_OMA_SUFF", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "CLMDTL_SV_DATE", DataTypes.Character, 8);
                AddControl(ReportSection.REPORT, "INDEXED.F002_SUSPEND_DTL.CLMDTL_FEE_OMA", DataTypes.Numeric, 7);
                AddControl(ReportSection.REPORT, "INDEXED.F002_SUSPEND_DTL.CLMDTL_NBR_SERV", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "W_CLMDTL_SV_DAY_1", DataTypes.Character, 2);
                AddControl(ReportSection.REPORT, "CLMDTL_SV_NBR1", DataTypes.Numeric, 1);
                AddControl(ReportSection.REPORT, "CLMDTL_SV_NBR2", DataTypes.Numeric, 1);
                AddControl(ReportSection.REPORT, "CLMDTL_SV_DAY2", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "CLMDTL_SV_NBR3", DataTypes.Numeric, 1);
                AddControl(ReportSection.REPORT, "CLMDTL_SV_DAY3", DataTypes.Numeric, 2);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-09-13 11:57:56 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            // TODO: Remove duplicate controls, if there are any.
            switch (strControl)
            {
                case "INDEXED.F002_SUSPEND_HDR.CLMHDR_DOC_OHIP_NBR":
                    return rdrF002_SUSPEND_HDR.GetNumber("CLMHDR_DOC_OHIP_NBR").ToString();
                case "INDEXED.F002_SUSPEND_HDR.CLMHDR_ACCOUNTING_NBR":
                    return Common.StringToField(rdrF002_SUSPEND_HDR.GetString("CLMHDR_ACCOUNTING_NBR"));
                case "INDEXED.F002_SUSPEND_HDR.CLMHDR_AGENT_CD":
                    return rdrF002_SUSPEND_HDR.GetNumber("CLMHDR_AGENT_CD").ToString();
                case "INDEXED.F002_SUSPEND_ADDRESS.ADD_SURNAME":
                    return Common.StringToField(rdrF002_SUSPEND_ADDRESS.GetString("ADD_SURNAME"));
                case "INDEXED.F002_SUSPEND_HDR.CLMHDR_PAT_KEY_DATA":
                    return Common.StringToField(rdrF002_SUSPEND_HDR.GetString("CLMHDR_PAT_KEY_DATA"));
                case "INDEXED.F002_SUSPEND_ADDRESS.ADD_FIRST_NAME":
                    return Common.StringToField(rdrF002_SUSPEND_ADDRESS.GetString("ADD_FIRST_NAME"));
                case "CLMHDR_PAT_ACRONYM":
                    return Common.StringToField(F002_SUSPEND_HDR_CLMHDR_PAT_ACRONYM(), intSize);
                case "INDEXED.F002_SUSPEND_HDR.CLMHDR_LOC":
                    return Common.StringToField(rdrF002_SUSPEND_HDR.GetString("CLMHDR_LOC"));
                case "INDEXED.F002_SUSPEND_HDR.CLMHDR_HOSP":
                    return Common.StringToField(rdrF002_SUSPEND_HDR.GetString("CLMHDR_HOSP"));
                case "INDEXED.F002_SUSPEND_HDR.CLMHDR_DATE_ADMIT":
                    return Common.StringToField(rdrF002_SUSPEND_HDR.GetString("CLMHDR_DATE_ADMIT"));
                case "INDEXED.F002_SUSPEND_HDR.CLMHDR_I_O_PAT_IND":
                    return Common.StringToField(rdrF002_SUSPEND_HDR.GetString("CLMHDR_I_O_PAT_IND"));
                case "INDEXED.F002_SUSPEND_HDR.CLMHDR_DIAG_CD":
                    return rdrF002_SUSPEND_HDR.GetNumber("CLMHDR_DIAG_CD").ToString();
                case "INDEXED.F002_SUSPEND_HDR.CLMHDR_TAPE_SUBMIT_IND":
                    return Common.StringToField(rdrF002_SUSPEND_HDR.GetString("CLMHDR_TAPE_SUBMIT_IND"));
                case "INDEXED.F002_SUSPEND_HDR.CLMHDR_DOC_SPEC_CD":
                    return rdrF002_SUSPEND_HDR.GetNumber("CLMHDR_DOC_SPEC_CD").ToString();
                case "INDEXED.F002_SUSPEND_HDR.CLMHDR_REFER_DOC_NBR":
                    return rdrF002_SUSPEND_HDR.GetNumber("CLMHDR_REFER_DOC_NBR").ToString();
                case "INDEXED.F002_SUSPEND_DTL.CLMDTL_OMA_CD":
                    return Common.StringToField(rdrF002_SUSPEND_DTL.GetString("CLMDTL_OMA_CD"));
                case "INDEXED.F002_SUSPEND_DTL.CLMDTL_OMA_SUFF":
                    return Common.StringToField(rdrF002_SUSPEND_DTL.GetString("CLMDTL_OMA_SUFF"));
                case "CLMDTL_SV_DATE":
                    return Common.StringToField(F002_SUSPEND_DTL_CLMDTL_SV_DATE(), intSize);
                case "INDEXED.F002_SUSPEND_DTL.CLMDTL_FEE_OMA":
                    return rdrF002_SUSPEND_DTL.GetNumber("CLMDTL_FEE_OMA").ToString();
                case "INDEXED.F002_SUSPEND_DTL.CLMDTL_NBR_SERV":
                    return rdrF002_SUSPEND_DTL.GetNumber("CLMDTL_NBR_SERV").ToString();
                case "W_CLMDTL_SV_DAY_1":
                    return Common.StringToField(W_CLMDTL_SV_DAY_1(), intSize);
                case "CLMDTL_SV_NBR1":
                    return F002_SUSPEND_DTL_CLMDTL_SV_NBR1().ToString();
                case "CLMDTL_SV_DAY2":
                    return F002_SUSPEND_DTL_CLMDTL_SV_DAY2().ToString();
                case "CLMDTL_SV_NBR2":
                    return F002_SUSPEND_DTL_CLMDTL_SV_NBR2().ToString();
                case "CLMDTL_SV_DAY3":
                    return F002_SUSPEND_DTL_CLMDTL_SV_DAY3().ToString();
                case "CLMDTL_SV_NBR3":
                    return F002_SUSPEND_DTL_CLMDTL_SV_NBR3().ToString();
                default:
                    return String.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                // TODO: Some manual steps maybe required.
                Access_F002_SUSPEND_HDR();
                while (rdrF002_SUSPEND_HDR.Read())
                {
                    Link_F002_SUSPEND_DTL();
                    while (rdrF002_SUSPEND_DTL.Read())
                    {
                        Link_F002_SUSPEND_ADDRESS();
                        while (rdrF002_SUSPEND_ADDRESS.Read())
                        {
                            WriteData();
                        }

                        rdrF002_SUSPEND_ADDRESS.Close();
                    }

                    rdrF002_SUSPEND_DTL.Close();
                }

                rdrF002_SUSPEND_HDR.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrF002_SUSPEND_HDR == null))
            {
                rdrF002_SUSPEND_HDR.Close();
                rdrF002_SUSPEND_HDR = null;
            }

            if (!(rdrF002_SUSPEND_DTL == null))
            {
                rdrF002_SUSPEND_DTL.Close();
                rdrF002_SUSPEND_DTL = null;
            }

            if (!(rdrF002_SUSPEND_ADDRESS == null))
            {
                rdrF002_SUSPEND_ADDRESS.Close();
                rdrF002_SUSPEND_ADDRESS = null;
            }
        }
    }
}
