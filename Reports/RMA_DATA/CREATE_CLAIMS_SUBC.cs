#region "Screen Comments"


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
    public class CREATE_CLAIMS_SUBC : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "CREATE_CLAIMS_SUBC";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrDETAIL_CLAIMSB = new Reader();
        private Reader rdrF010_PAT_MSTR = new Reader();
        private Reader rdrCLAIMS_SUBFILE = new Reader();
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
                // Create Subfile.
                SubFile = true;
                SubFileName = "CLAIMS_SUBFILE";
                SubFileType = SubFileType.Keep;
                SubFileAT = "";

                Sort = "";

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

        private void Access_DETAIL_CLAIMSB()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("CLMHDR_PAT_OHIP_ID_OR_CHART, ");
            strSQL.Append("CLMDTL_ID, ");
            strSQL.Append("CLMDTL_NBR_SERV, ");
            strSQL.Append("CLMDTL_SV_DATE, ");
            strSQL.Append("CLMDTL_CONSEC_DATES, ");
            strSQL.Append("CLMDTL_AMT_TECH_BILLED, ");
            strSQL.Append("CLMDTL_FEE_OMA, ");
            strSQL.Append("CLMDTL_FEE_OHIP, ");
            strSQL.Append("CLMDTL_DATE_PERIOD_END, ");
            strSQL.Append("CLMHDR_HOSP, ");
            strSQL.Append("CLMHDR_DOC_DEPT, ");
            strSQL.Append("CLMHDR_AGENT_CD, ");
            strSQL.Append("CLMHDR_LOC, ");
            strSQL.Append("CLMHDR_REFER_DOC_NBR, ");
            strSQL.Append("CLMDTL_DIAG_CD, ");
            strSQL.Append("CLMHDR_DOC_SPEC_CD, ");
            strSQL.Append("CLMHDR_I_O_PAT_IND, ");
            strSQL.Append("CLMHDR_DATE_ADMIT, ");
            strSQL.Append("CLMHDR_DOC_NBR_OHIP ");
            strSQL.Append("FROM TEMPORARYDATA.DETAIL_CLAIMSB ");

            strSQL.Append(Choose());

            rdrDETAIL_CLAIMSB.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);

            strSQL = null;
        }

        private void Link_F010_PAT_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("PAT_DIRECT_ALPHA, ");
            strSQL.Append("PAT_DIRECT_YY, ");
            strSQL.Append("PAT_DIRECT_MM, ");
            strSQL.Append("PAT_DIRECT_DD, ");
            strSQL.Append("PAT_DIRECT_LAST_6, ");
            strSQL.Append("PAT_CHART_NBR, ");
            strSQL.Append("PAT_CHART_NBR_2, ");
            strSQL.Append("PAT_CHART_NBR_3, ");
            strSQL.Append("PAT_CHART_NBR_4, ");
            strSQL.Append("PAT_CHART_NBR_5, ");
            strSQL.Append("PAT_HEALTH_NBR, ");
            strSQL.Append("PAT_VERSION_CD, ");
            strSQL.Append("PAT_PROV_CD, ");
            strSQL.Append("PAT_BIRTH_DATE_YY, ");
            strSQL.Append("PAT_BIRTH_DATE_MM, ");
            strSQL.Append("PAT_BIRTH_DATE_DD, ");
            strSQL.Append("PAT_SEX, ");
            strSQL.Append("PAT_SURNAME_FIRST3, ");
            strSQL.Append("PAT_SURNAME_LAST22, ");
            strSQL.Append("PAT_GIVEN_NAME_FIRST1, ");
            strSQL.Append("FILLER3, ");
            strSQL.Append("PAT_INIT1, ");
            strSQL.Append("PAT_INIT2, ");
            strSQL.Append("PAT_INIT3, ");
            strSQL.Append("PAT_PHONE_NBR, ");
            strSQL.Append("SUBSCR_ADDR1, ");
            strSQL.Append("SUBSCR_ADDR2, ");
            strSQL.Append("SUBSCR_ADDR3, ");
            strSQL.Append("SUBSCR_PROV_CD, ");
            strSQL.Append("SUBSCR_POST_CD1, ");
            strSQL.Append("SUBSCR_POST_CD2, ");
            strSQL.Append("SUBSCR_POST_CD3, ");
            strSQL.Append("SUBSCR_POST_CD4, ");
            strSQL.Append("SUBSCR_POST_CD5, ");
            strSQL.Append("SUBSCR_POST_CD6, ");
            strSQL.Append("FILLER ");
            strSQL.Append("FROM INDEXED.F010_PAT_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("PAT_I_KEY = ").Append(Common.StringToField(QDesign.Substring(rdrDETAIL_CLAIMSB.GetString("CLMHDR_PAT_OHIP_ID_OR_CHART"), 1, 1)));
            strSQL.Append(" AND PAT_CON_NBR = ").Append(QDesign.NConvert(QDesign.Substring(rdrDETAIL_CLAIMSB.GetString("CLMHDR_PAT_OHIP_ID_OR_CHART"), 2, 2)));
            strSQL.Append(" AND PAT_I_NBR = ").Append(QDesign.NConvert(QDesign.Substring(rdrDETAIL_CLAIMSB.GetString("CLMHDR_PAT_OHIP_ID_OR_CHART"), 4, 12)));
            strSQL.Append(" AND FILLER4 = ").Append(Common.StringToField(QDesign.Substring(rdrDETAIL_CLAIMSB.GetString("CLMHDR_PAT_OHIP_ID_OR_CHART"), 16, 1)));

            rdrF010_PAT_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

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

        private string F010_PAT_MSTR_PAT_OHIP_MMYY()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = (rdrF010_PAT_MSTR.GetString("PAT_DIRECT_ALPHA") + QDesign.ASCII(rdrF010_PAT_MSTR.GetNumber("PAT_DIRECT_YY"), 2)
                    + QDesign.ASCII(rdrF010_PAT_MSTR.GetNumber("PAT_DIRECT_MM"), 2) + QDesign.ASCII(rdrF010_PAT_MSTR.GetNumber("PAT_DIRECT_DD"), 2)
                    + rdrF010_PAT_MSTR.GetString("PAT_DIRECT_LAST_6"));
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
            return strReturnValue;
        }

        private string F010_PAT_MSTR_PAT_BIRTH_DATE()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.ASCII(rdrF010_PAT_MSTR.GetNumber("PAT_BIRTH_DATE_YY"), 4) + QDesign.ASCII(rdrF010_PAT_MSTR.GetNumber("PAT_BIRTH_DATE_MM"), 2) + QDesign.ASCII(rdrF010_PAT_MSTR.GetNumber("PAT_BIRTH_DATE_DD"), 2);
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
            return strReturnValue;
        }

        private string F010_PAT_MSTR_PAT_SURNAME()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = (rdrF010_PAT_MSTR.GetString("PAT_SURNAME_FIRST3") + rdrF010_PAT_MSTR.GetString("PAT_SURNAME_LAST22"));
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
            return strReturnValue;
        }

        private string F010_PAT_MSTR_PAT_GIVEN_NAME()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = (rdrF010_PAT_MSTR.GetString("PAT_GIVEN_NAME_FIRST1") + rdrF010_PAT_MSTR.GetString("FILLER3"));
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
            return strReturnValue;
        }

        private string F010_PAT_MSTR_PAT_INIT()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = (rdrF010_PAT_MSTR.GetString("PAT_INIT1") + rdrF010_PAT_MSTR.GetString("PAT_INIT2") + rdrF010_PAT_MSTR.GetString("PAT_INIT3"));
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
            return strReturnValue;
        }

        private string F010_PAT_MSTR_SUBSCR_POSTAL_CD()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = (rdrF010_PAT_MSTR.GetString("SUBSCR_POST_CD1") + rdrF010_PAT_MSTR.GetString("SUBSCR_POST_CD2")
                    + rdrF010_PAT_MSTR.GetString("SUBSCR_POST_CD3") + rdrF010_PAT_MSTR.GetString("SUBSCR_POST_CD4")
                    + rdrF010_PAT_MSTR.GetString("SUBSCR_POST_CD5") + rdrF010_PAT_MSTR.GetString("SUBSCR_POST_CD6")
                    + rdrF010_PAT_MSTR.GetString("FILLER"));
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
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.DETAIL_CLAIMSB.CLMDTL_ID", DataTypes.Character, 16);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.DETAIL_CLAIMSB.CLMDTL_NBR_SERV", DataTypes.Numeric, 2);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.DETAIL_CLAIMSB.CLMDTL_SV_DATE", DataTypes.Character, 8);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.DETAIL_CLAIMSB.CLMDTL_CONSEC_DATES", DataTypes.Character, 9);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.DETAIL_CLAIMSB.CLMDTL_AMT_TECH_BILLED", DataTypes.Numeric, 6);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.DETAIL_CLAIMSB.CLMDTL_FEE_OMA", DataTypes.Numeric, 7);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.DETAIL_CLAIMSB.CLMDTL_FEE_OHIP", DataTypes.Numeric, 7);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.DETAIL_CLAIMSB.CLMDTL_DATE_PERIOD_END", DataTypes.Character, 8);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.DETAIL_CLAIMSB.CLMHDR_HOSP", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.DETAIL_CLAIMSB.CLMHDR_DOC_DEPT", DataTypes.Numeric, 2);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.DETAIL_CLAIMSB.CLMHDR_AGENT_CD", DataTypes.Numeric, 1);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.DETAIL_CLAIMSB.CLMHDR_PAT_OHIP_ID_OR_CHART", DataTypes.Character, 16);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.DETAIL_CLAIMSB.CLMHDR_LOC", DataTypes.Character, 4);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.DETAIL_CLAIMSB.CLMHDR_REFER_DOC_NBR", DataTypes.Numeric, 6);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.DETAIL_CLAIMSB.CLMDTL_DIAG_CD", DataTypes.Numeric, 3);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.DETAIL_CLAIMSB.CLMHDR_DOC_SPEC_CD", DataTypes.Numeric, 2);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.DETAIL_CLAIMSB.CLMHDR_I_O_PAT_IND", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.DETAIL_CLAIMSB.CLMHDR_DATE_ADMIT", DataTypes.Character, 8);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.DETAIL_CLAIMSB.CLMHDR_DOC_NBR_OHIP", DataTypes.Numeric, 6);
                AddControl(ReportSection.SUMMARY, "PAT_OHIP_MMYY", DataTypes.Character, 15);
                AddControl(ReportSection.SUMMARY, "INDEXED.F010_PAT_MSTR.PAT_CHART_NBR", DataTypes.Character, 10);
                AddControl(ReportSection.SUMMARY, "INDEXED.F010_PAT_MSTR.PAT_CHART_NBR_2", DataTypes.Character, 10);
                AddControl(ReportSection.SUMMARY, "INDEXED.F010_PAT_MSTR.PAT_CHART_NBR_3", DataTypes.Character, 10);
                AddControl(ReportSection.SUMMARY, "INDEXED.F010_PAT_MSTR.PAT_CHART_NBR_4", DataTypes.Character, 10);
                AddControl(ReportSection.SUMMARY, "INDEXED.F010_PAT_MSTR.PAT_CHART_NBR_5", DataTypes.Character, 11);
                AddControl(ReportSection.SUMMARY, "INDEXED.F010_PAT_MSTR.PAT_HEALTH_NBR", DataTypes.Numeric, 10);
                AddControl(ReportSection.SUMMARY, "INDEXED.F010_PAT_MSTR.PAT_VERSION_CD", DataTypes.Character, 2);
                AddControl(ReportSection.SUMMARY, "INDEXED.F010_PAT_MSTR.PAT_PROV_CD", DataTypes.Character, 2);
                AddControl(ReportSection.SUMMARY, "PAT_BIRTH_DATE", DataTypes.Character, 8);
                AddControl(ReportSection.SUMMARY, "INDEXED.F010_PAT_MSTR.PAT_SEX", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "PAT_SURNAME", DataTypes.Character, 25);
                AddControl(ReportSection.SUMMARY, "PAT_GIVEN_NAME", DataTypes.Character, 17);
                AddControl(ReportSection.SUMMARY, "PAT_INIT", DataTypes.Character, 3);
                AddControl(ReportSection.SUMMARY, "INDEXED.F010_PAT_MSTR.PAT_PHONE_NBR", DataTypes.Character, 20);
                AddControl(ReportSection.SUMMARY, "INDEXED.F010_PAT_MSTR.SUBSCR_ADDR1", DataTypes.Character, 30);
                AddControl(ReportSection.SUMMARY, "INDEXED.F010_PAT_MSTR.SUBSCR_ADDR2", DataTypes.Character, 30);
                AddControl(ReportSection.SUMMARY, "INDEXED.F010_PAT_MSTR.SUBSCR_ADDR3", DataTypes.Character, 30);
                AddControl(ReportSection.SUMMARY, "INDEXED.F010_PAT_MSTR.SUBSCR_PROV_CD", DataTypes.Character, 2);
                AddControl(ReportSection.SUMMARY, "SUBSCR_POSTAL_CD", DataTypes.Character, 10);
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
        //# Do not delete, modify or move it.  Updated: 10/19/2017 10:52:20 AM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "TEMPORARYDATA.DETAIL_CLAIMSB.CLMDTL_ID":
                    return Common.StringToField(rdrDETAIL_CLAIMSB.GetString("CLMDTL_ID").PadRight(16, ' '));

                case "TEMPORARYDATA.DETAIL_CLAIMSB.CLMDTL_NBR_SERV":
                    return rdrDETAIL_CLAIMSB.GetNumber("CLMDTL_NBR_SERV").ToString().PadLeft(2, ' ');

                case "TEMPORARYDATA.DETAIL_CLAIMSB.CLMDTL_SV_DATE":
                    return Common.StringToField(rdrDETAIL_CLAIMSB.GetString("CLMDTL_SV_DATE").PadRight(8, ' '));

                case "TEMPORARYDATA.DETAIL_CLAIMSB.CLMDTL_CONSEC_DATES":
                    return Common.StringToField(rdrDETAIL_CLAIMSB.GetString("CLMDTL_CONSEC_DATES").PadLeft(9, ' '));

                case "TEMPORARYDATA.DETAIL_CLAIMSB.CLMDTL_AMT_TECH_BILLED":
                    return rdrDETAIL_CLAIMSB.GetNumber("CLMDTL_AMT_TECH_BILLED").ToString().PadLeft(6, ' ');

                case "TEMPORARYDATA.DETAIL_CLAIMSB.CLMDTL_FEE_OMA":
                    return rdrDETAIL_CLAIMSB.GetNumber("CLMDTL_FEE_OMA").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.DETAIL_CLAIMSB.CLMDTL_FEE_OHIP":
                    return rdrDETAIL_CLAIMSB.GetNumber("CLMDTL_FEE_OHIP").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.DETAIL_CLAIMSB.CLMDTL_DATE_PERIOD_END":
                    return Common.StringToField(rdrDETAIL_CLAIMSB.GetString("CLMDTL_DATE_PERIOD_END").PadRight(8, ' '));

                case "TEMPORARYDATA.DETAIL_CLAIMSB.CLMHDR_HOSP":
                    return Common.StringToField(rdrDETAIL_CLAIMSB.GetString("CLMHDR_HOSP").PadRight(1, ' '));

                case "TEMPORARYDATA.DETAIL_CLAIMSB.CLMHDR_DOC_DEPT":
                    return rdrDETAIL_CLAIMSB.GetNumber("CLMHDR_DOC_DEPT").ToString().PadLeft(2, ' ');

                case "TEMPORARYDATA.DETAIL_CLAIMSB.CLMHDR_AGENT_CD":
                    return rdrDETAIL_CLAIMSB.GetNumber("CLMHDR_AGENT_CD").ToString().PadLeft(1, ' ');

                case "TEMPORARYDATA.DETAIL_CLAIMSB.CLMHDR_PAT_OHIP_ID_OR_CHART":
                    return Common.StringToField(rdrDETAIL_CLAIMSB.GetString("CLMHDR_PAT_OHIP_ID_OR_CHART").PadRight(16, ' '));

                case "TEMPORARYDATA.DETAIL_CLAIMSB.CLMHDR_LOC":
                    return Common.StringToField(rdrDETAIL_CLAIMSB.GetString("CLMHDR_LOC").PadRight(4, ' '));

                case "TEMPORARYDATA.DETAIL_CLAIMSB.CLMHDR_REFER_DOC_NBR":
                    return rdrDETAIL_CLAIMSB.GetNumber("CLMHDR_REFER_DOC_NBR").ToString().PadLeft(6, ' ');

                case "TEMPORARYDATA.DETAIL_CLAIMSB.CLMDTL_DIAG_CD":
                    return rdrDETAIL_CLAIMSB.GetNumber("CLMDTL_DIAG_CD").ToString().PadLeft(3, ' ');

                case "TEMPORARYDATA.DETAIL_CLAIMSB.CLMHDR_DOC_SPEC_CD":
                    return rdrDETAIL_CLAIMSB.GetNumber("CLMHDR_DOC_SPEC_CD").ToString().PadLeft(2, ' ');

                case "TEMPORARYDATA.DETAIL_CLAIMSB.CLMHDR_I_O_PAT_IND":
                    return Common.StringToField(rdrDETAIL_CLAIMSB.GetString("CLMHDR_I_O_PAT_IND").PadRight(1, ' '));

                case "TEMPORARYDATA.DETAIL_CLAIMSB.CLMHDR_DATE_ADMIT":
                    return Common.StringToField(rdrDETAIL_CLAIMSB.GetString("CLMHDR_DATE_ADMIT").PadRight(8, ' '));

                case "TEMPORARYDATA.DETAIL_CLAIMSB.CLMHDR_DOC_NBR_OHIP":
                    return rdrDETAIL_CLAIMSB.GetNumber("CLMHDR_DOC_NBR_OHIP").ToString().PadLeft(6, ' ');

                case "PAT_OHIP_MMYY":
                    return Common.StringToField(F010_PAT_MSTR_PAT_OHIP_MMYY().PadRight(15, ' '));

                case "INDEXED.F010_PAT_MSTR.PAT_CHART_NBR":
                    return Common.StringToField(rdrF010_PAT_MSTR.GetString("PAT_CHART_NBR").PadRight(10, ' '));

                case "INDEXED.F010_PAT_MSTR.PAT_CHART_NBR_2":
                    return Common.StringToField(rdrF010_PAT_MSTR.GetString("PAT_CHART_NBR_2").PadRight(10, ' '));

                case "INDEXED.F010_PAT_MSTR.PAT_CHART_NBR_3":
                    return Common.StringToField(rdrF010_PAT_MSTR.GetString("PAT_CHART_NBR_3").PadRight(10, ' '));

                case "INDEXED.F010_PAT_MSTR.PAT_CHART_NBR_4":
                    return Common.StringToField(rdrF010_PAT_MSTR.GetString("PAT_CHART_NBR_4").PadRight(10, ' '));

                case "INDEXED.F010_PAT_MSTR.PAT_CHART_NBR_5":
                    return Common.StringToField(rdrF010_PAT_MSTR.GetString("PAT_CHART_NBR_5").PadRight(11, ' '));

                case "INDEXED.F010_PAT_MSTR.PAT_HEALTH_NBR":
                    return rdrF010_PAT_MSTR.GetNumber("PAT_HEALTH_NBR").ToString().PadLeft(10, ' ');

                case "INDEXED.F010_PAT_MSTR.PAT_VERSION_CD":
                    return Common.StringToField(rdrF010_PAT_MSTR.GetString("PAT_VERSION_CD").PadRight(2, ' '));

                case "INDEXED.F010_PAT_MSTR.PAT_PROV_CD":
                    return Common.StringToField(rdrF010_PAT_MSTR.GetString("PAT_PROV_CD").PadRight(2, ' '));

                case "F010_PAT_MSTR_PAT_BIRTH_DATE":
                    return Common.StringToField(F010_PAT_MSTR_PAT_BIRTH_DATE().PadRight(8, ' '));

                case "INDEXED.F010_PAT_MSTR.PAT_SEX":
                    return Common.StringToField(rdrF010_PAT_MSTR.GetString("PAT_SEX").PadRight(1, ' '));

                case "PAT_SURNAME":
                    return Common.StringToField(F010_PAT_MSTR_PAT_SURNAME().PadRight(25, ' '));

                case "PAT_GIVEN_NAME":
                    return Common.StringToField(F010_PAT_MSTR_PAT_GIVEN_NAME().PadRight(17, ' '));

                case "PAT_INIT":
                    return Common.StringToField(F010_PAT_MSTR_PAT_INIT().PadRight(3, ' '));

                case "INDEXED.F010_PAT_MSTR.PAT_PHONE_NBR":
                    return Common.StringToField(rdrF010_PAT_MSTR.GetString("PAT_PHONE_NBR").PadRight(20, ' '));

                case "INDEXED.F010_PAT_MSTR.SUBSCR_ADDR1":
                    return Common.StringToField(rdrF010_PAT_MSTR.GetString("SUBSCR_ADDR1").PadRight(30, ' '));

                case "INDEXED.F010_PAT_MSTR.SUBSCR_ADDR2":
                    return Common.StringToField(rdrF010_PAT_MSTR.GetString("SUBSCR_ADDR2").PadRight(30, ' '));

                case "INDEXED.F010_PAT_MSTR.SUBSCR_ADDR3":
                    return Common.StringToField(rdrF010_PAT_MSTR.GetString("SUBSCR_ADDR3").PadRight(30, ' '));

                case "INDEXED.F010_PAT_MSTR.SUBSCR_PROV_CD":
                    return Common.StringToField(rdrF010_PAT_MSTR.GetString("SUBSCR_PROV_CD").PadRight(2, ' '));

                case "SUBSCR_POSTAL_CD":
                    return Common.StringToField(F010_PAT_MSTR_SUBSCR_POSTAL_CD().PadRight(10, ' '));

                default:

                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_DETAIL_CLAIMSB();

                while (rdrDETAIL_CLAIMSB.Read())
                {
                    Link_F010_PAT_MSTR();
                    while (rdrF010_PAT_MSTR.Read())
                    {
                        WriteData();
                    }
                    rdrF010_PAT_MSTR.Close();
                }
                rdrDETAIL_CLAIMSB.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrDETAIL_CLAIMSB != null))
            {
                rdrDETAIL_CLAIMSB.Close();
                rdrDETAIL_CLAIMSB = null;
            }
            if ((rdrF010_PAT_MSTR != null))
            {
                rdrF010_PAT_MSTR.Close();
                rdrF010_PAT_MSTR = null;
            }
        }


        #endregion

        #endregion
    }
}
