//  PURPOSE: REPORT SUSPEND CLAIM DETAIL AND DESCRIPTION    
//  SECOND PASS OF TWO PROGRAMS
//  DATE:  WHO:  MODIFICATION
//  2011/May/04   M.C.      ORIGINAL
//  2011/Jul/20   MC1   include dr name, CPSO #, chart-key
//  2017/Apr/25   MC2  Yasemin requested to sort on doc-nbr
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
    public class SUSPEND_AGENT_DETAIL : BaseRDLClass
    {
        protected const string REPORT_NAME = "SUSPEND_AGENT_DETAIL";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrSUSP_AGENT_DTL = new Reader();
        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                //  Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;
                Sort = "CLMHDR_DOC_NBR ASC, CLMHDR_DOC_OHIP_NBR ASC, CLMHDR_ACCOUNTING_NBR ASC, X_TYPE ASC, X_SEQ ASC";
                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return ReportData;
        }
        private void Access_SUSP_AGENT_DTL()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: If * is not used to select all columns, ensure the necessary columns (i.e. columns that are used to access records of other tables) are included in the SELECT statement
            strSQL.Append("SELECT ");
            strSQL.Append("CLMHDR_DOC_NBR, ");
            strSQL.Append("CLMHDR_DOC_OHIP_NBR, ");
            strSQL.Append("CLMHDR_ACCOUNTING_NBR, ");
            strSQL.Append("X_TYPE, ");
            strSQL.Append("X_SEQ, ");
            strSQL.Append("DOC_NAME, ");
            strSQL.Append("CPSO_NBR, ");
            strSQL.Append("PAT_SURNAME_FIRST3, ");
            strSQL.Append("PAT_SURNAME_LAST22, ");
            strSQL.Append("PAT_GIVEN_NAME_FIRST1, ");
            strSQL.Append("FILLER3, ");
            strSQL.Append("PAT_BIRTH_DATE_YY, ");
            strSQL.Append("PAT_BIRTH_DATE_MM, ");
            strSQL.Append("PAT_BIRTH_DATE_DD, ");
            strSQL.Append("PAT_SEX, ");
            strSQL.Append("PAT_OHIP_MMYY, ");
            strSQL.Append("X_CHART_KEY, ");
            strSQL.Append("PAT_HEALTH_NBR, ");
            strSQL.Append("PAT_VERSION_CD, ");
            strSQL.Append("SUBSCR_ADDR1, ");
            strSQL.Append("SUBSCR_ADDR2, ");
            strSQL.Append("SUBSCR_ADDR3, ");
            strSQL.Append("SUBSCR_POSTAL_CD1, ");
            strSQL.Append("SUBSCR_POSTAL_CD2, ");
            strSQL.Append("SUBSCR_POSTAL_CD3, ");
            strSQL.Append("SUBSCR_POSTAL_CD4, ");
            strSQL.Append("SUBSCR_POSTAL_CD5, ");
            strSQL.Append("SUBSCR_POSTAL_CD6, ");
            strSQL.Append("FILLER, ");
            strSQL.Append("SUBSCR_PROV_CD, ");
            strSQL.Append("PAT_PHONE_NBR, ");
            strSQL.Append("CLMHDR_CLINIC_NBR_1_2, ");
            strSQL.Append("CLMHDR_DOC_DEPT, ");
            strSQL.Append("CLMHDR_DOC_SPEC_CD, ");
            strSQL.Append("CLMHDR_I_O_PAT_IND, ");
            strSQL.Append("CLMHDR_LOC, ");
            strSQL.Append("CLMHDR_AGENT_CD, ");
            strSQL.Append("CLMHDR_DATE_ADMIT, ");
            strSQL.Append("CLMHDR_REFER_DOC_NBR, ");
            strSQL.Append("CLMHDR_CONFIDENTIAL_FLAG, ");
            strSQL.Append("X_LINE ");
            strSQL.Append("FROM TEMPORARYDATA.SUSP_AGENT_DTL ");
            strSQL.Append(Choose());
            rdrSUSP_AGENT_DTL.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.m_strFlatFileDictionary, ReportFunctions.TextFiles);
            strSQL = null;
        }

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(String.Empty);
            // TODO: CHOOSE Statement - May require manual changes.
            return strChoose.ToString().ToString();
        }

        private string X_TITLE()
        {
            string strReturnValue = String.Empty;
            try
            {
                if ((QDesign.NULL(rdrSUSP_AGENT_DTL.GetNumber("X_TYPE")) == QDesign.NULL(1d)))
                {
                    strReturnValue = "Detail Info:";
                }
                else if ((QDesign.NULL(rdrSUSP_AGENT_DTL.GetNumber("X_TYPE")) == QDesign.NULL(2d)))
                {
                    strReturnValue = "Description:";
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string PAT_SURNAME()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = rdrSUSP_AGENT_DTL.GetString("PAT_SURNAME_FIRST3") + rdrSUSP_AGENT_DTL.GetString("PAT_SURNAME_LAST22");
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string PAT_GIVEN_NAME()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = rdrSUSP_AGENT_DTL.GetString("PAT_GIVEN_NAME_FIRST1") + rdrSUSP_AGENT_DTL.GetString("FILLER3");
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private decimal PAT_BIRTH_DATE()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = QDesign.NConvert(QDesign.ASCII(rdrSUSP_AGENT_DTL.GetNumber("PAT_BIRTH_DATE_YY")) + QDesign.ASCII(rdrSUSP_AGENT_DTL.GetNumber("PAT_BIRTH_DATE_MM"), 2) + QDesign.ASCII(rdrSUSP_AGENT_DTL.GetNumber("PAT_BIRTH_DATE_DD"), 2));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private string SUBSCR_POSTAL_CD()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = rdrSUSP_AGENT_DTL.GetString("SUBSCR_POST_CD1") + rdrSUSP_AGENT_DTL.GetString("SUBSCR_POST_CD2") + rdrSUSP_AGENT_DTL.GetString("SUBSCR_POST_CD3") + rdrSUSP_AGENT_DTL.GetString("SUBSCR_POST_CD4") + rdrSUSP_AGENT_DTL.GetString("SUBSCR_POST_CD5") + rdrSUSP_AGENT_DTL.GetString("SUBSCR_POST_CD6") + rdrSUSP_AGENT_DTL.GetString("FILLER");
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
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.SUSP_AGENT_DTL.CLMHDR_DOC_OHIP_NBR", DataTypes.Numeric, 7);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.SUSP_AGENT_DTL.CLMHDR_ACCOUNTING_NBR", DataTypes.Character, 8);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.SUSP_AGENT_DTL.DOC_NAME", DataTypes.Character, 24);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.SUSP_AGENT_DTL.CPSO_NBR", DataTypes.Character, 6);
                AddControl(ReportSection.PAGE_HEADING, "PAT_SURNAME", DataTypes.Character, 25);
                AddControl(ReportSection.PAGE_HEADING, "PAT_GIVEN_NAME", DataTypes.Character, 17);
                AddControl(ReportSection.PAGE_HEADING, "PAT_BIRTH_DATE", DataTypes.Numeric, 8);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.SUSP_AGENT_DTL.PAT_SEX", DataTypes.Character, 1);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.SUSP_AGENT_DTL.PAT_OHIP_MMYY", DataTypes.Character, 15);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.SUSP_AGENT_DTL.X_CHART_KEY", DataTypes.Character, 11);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.SUSP_AGENT_DTL.PAT_HEALTH_NBR", DataTypes.Numeric, 11);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.SUSP_AGENT_DTL.PAT_VERSION_CD", DataTypes.Character, 2);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.SUSP_AGENT_DTL.SUBSCR_ADDR1", DataTypes.Character, 30);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.SUSP_AGENT_DTL.SUBSCR_ADDR2", DataTypes.Character, 30);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.SUSP_AGENT_DTL.SUBSCR_ADDR3", DataTypes.Character, 30);
                AddControl(ReportSection.PAGE_HEADING, "SUBSCR_POSTAL_CD", DataTypes.Character, 10);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.SUSP_AGENT_DTL.SUBSCR_PROV_CD", DataTypes.Character, 2);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.SUSP_AGENT_DTL.PAT_PHONE_NBR", DataTypes.Character, 20);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.SUSP_AGENT_DTL.CLMHDR_CLINIC_NBR_1_2", DataTypes.Numeric, 3);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.SUSP_AGENT_DTL.CLMHDR_DOC_DEPT", DataTypes.Numeric, 3);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.SUSP_AGENT_DTL.CLMHDR_DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.SUSP_AGENT_DTL.CLMHDR_DOC_SPEC_CD", DataTypes.Numeric, 3);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.SUSP_AGENT_DTL.CLMHDR_I_O_PAT_IND", DataTypes.Character, 1);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.SUSP_AGENT_DTL.CLMHDR_LOC", DataTypes.Character, 4);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.SUSP_AGENT_DTL.CLMHDR_AGENT_CD", DataTypes.Numeric, 2);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.SUSP_AGENT_DTL.CLMHDR_DATE_ADMIT", DataTypes.Character, 8);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.SUSP_AGENT_DTL.CLMHDR_REFER_DOC_NBR", DataTypes.Numeric, 7);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.SUSP_AGENT_DTL.CLMHDR_CONFIDENTIAL_FLAG", DataTypes.Character, 1);
                AddControl(ReportSection.HEADING_AT, "X_TITLE", DataTypes.Character, 15);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.SUSP_AGENT_DTL.X_LINE", DataTypes.Character, 70);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.SUSP_AGENT_DTL.X_TYPE", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.SUSP_AGENT_DTL.X_SEQ", DataTypes.Numeric, 3);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-05-16 12:45:41 PM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            // TODO: Remove duplicate controls, if there are any.
            switch (strControl)
            {
                case "TEMPORARYDATA.SUSP_AGENT_DTL.CLMHDR_DOC_OHIP_NBR":
                    return rdrSUSP_AGENT_DTL.GetNumber("CLMHDR_DOC_OHIP_NBR").ToString();
                case "TEMPORARYDATA.SUSP_AGENT_DTL.CLMHDR_ACCOUNTING_NBR":
                    return Common.StringToField(rdrSUSP_AGENT_DTL.GetString("CLMHDR_ACCOUNTING_NBR"));
                case "TEMPORARYDATA.SUSP_AGENT_DTL.DOC_NAME":
                    return Common.StringToField(rdrSUSP_AGENT_DTL.GetString("DOC_NAME"));
                case "TEMPORARYDATA.SUSP_AGENT_DTL.CPSO_NBR":
                    return Common.StringToField(rdrSUSP_AGENT_DTL.GetString("CPSO_NBR"));
                case "PAT_SURNAME":
                    return Common.StringToField(PAT_SURNAME(), intSize);
                case "PAT_GIVEN_NAME":
                    return Common.StringToField(PAT_GIVEN_NAME(), intSize);
                case "PAT_BIRTH_DATE":
                    return PAT_BIRTH_DATE().ToString();
                case "TEMPORARYDATA.SUSP_AGENT_DTL.PAT_SEX":
                    return Common.StringToField(rdrSUSP_AGENT_DTL.GetString("PAT_SEX"));
                case "TEMPORARYDATA.SUSP_AGENT_DTL.PAT_OHIP_MMYY":
                    return Common.StringToField(rdrSUSP_AGENT_DTL.GetString("PAT_OHIP_MMYY"));
                case "TEMPORARYDATA.SUSP_AGENT_DTL.X_CHART_KEY":
                    return Common.StringToField(rdrSUSP_AGENT_DTL.GetString("X_CHART_KEY"));
                case "TEMPORARYDATA.SUSP_AGENT_DTL.PAT_HEALTH_NBR":
                    return rdrSUSP_AGENT_DTL.GetNumber("PAT_HEALTH_NBR").ToString();
                case "TEMPORARYDATA.SUSP_AGENT_DTL.PAT_VERSION_CD":
                    return Common.StringToField(rdrSUSP_AGENT_DTL.GetString("PAT_VERSION_CD"));
                case "TEMPORARYDATA.SUSP_AGENT_DTL.SUBSCR_ADDR1":
                    return Common.StringToField(rdrSUSP_AGENT_DTL.GetString("SUBSCR_ADDR1"));
                case "TEMPORARYDATA.SUSP_AGENT_DTL.SUBSCR_ADDR2":
                    return Common.StringToField(rdrSUSP_AGENT_DTL.GetString("SUBSCR_ADDR2"));
                case "TEMPORARYDATA.SUSP_AGENT_DTL.SUBSCR_ADDR3":
                    return Common.StringToField(rdrSUSP_AGENT_DTL.GetString("SUBSCR_ADDR3"));
                case "SUBSCR_POSTAL_CD":
                    return Common.StringToField(SUBSCR_POSTAL_CD(), intSize);
                case "TEMPORARYDATA.SUSP_AGENT_DTL.SUBSCR_PROV_CD":
                    return Common.StringToField(rdrSUSP_AGENT_DTL.GetString("SUBSCR_PROV_CD"));
                case "TEMPORARYDATA.SUSP_AGENT_DTL.PAT_PHONE_NBR":
                    return Common.StringToField(rdrSUSP_AGENT_DTL.GetString("PAT_PHONE_NBR"));
                case "TEMPORARYDATA.SUSP_AGENT_DTL.CLMHDR_CLINIC_NBR_1_2":
                    return rdrSUSP_AGENT_DTL.GetNumber("CLMHDR_CLINIC_NBR_1_2").ToString();
                case "TEMPORARYDATA.SUSP_AGENT_DTL.CLMHDR_DOC_DEPT":
                    return rdrSUSP_AGENT_DTL.GetNumber("CLMHDR_DOC_DEPT").ToString();
                case "TEMPORARYDATA.SUSP_AGENT_DTL.CLMHDR_DOC_NBR":
                    return Common.StringToField(rdrSUSP_AGENT_DTL.GetString("CLMHDR_DOC_NBR"));
                case "TEMPORARYDATA.SUSP_AGENT_DTL.CLMHDR_DOC_SPEC_CD":
                    return rdrSUSP_AGENT_DTL.GetNumber("CLMHDR_DOC_SPEC_CD").ToString();
                case "TEMPORARYDATA.SUSP_AGENT_DTL.CLMHDR_I_O_PAT_IND":
                    return Common.StringToField(rdrSUSP_AGENT_DTL.GetString("CLMHDR_I_O_PAT_IND"));
                case "TEMPORARYDATA.SUSP_AGENT_DTL.CLMHDR_LOC":
                    return Common.StringToField(rdrSUSP_AGENT_DTL.GetString("CLMHDR_LOC"));
                case "TEMPORARYDATA.SUSP_AGENT_DTL.CLMHDR_AGENT_CD":
                    return rdrSUSP_AGENT_DTL.GetNumber("CLMHDR_AGENT_CD").ToString();
                case "TEMPORARYDATA.SUSP_AGENT_DTL.CLMHDR_DATE_ADMIT":
                    return Common.StringToField(rdrSUSP_AGENT_DTL.GetString("CLMHDR_DATE_ADMIT"));
                case "TEMPORARYDATA.SUSP_AGENT_DTL.CLMHDR_REFER_DOC_NBR":
                    return rdrSUSP_AGENT_DTL.GetNumber("CLMHDR_REFER_DOC_NBR").ToString();
                case "TEMPORARYDATA.SUSP_AGENT_DTL.CLMHDR_CONFIDENTIAL_FLAG":
                    return Common.StringToField(rdrSUSP_AGENT_DTL.GetString("CLMHDR_CONFIDENTIAL_FLAG"));
                case "X_TITLE":
                    return Common.StringToField(X_TITLE(), intSize);
                case "TEMPORARYDATA.SUSP_AGENT_DTL.X_LINE":
                    return Common.StringToField(rdrSUSP_AGENT_DTL.GetString("X_LINE"));
                case "TEMPORARYDATA.SUSP_AGENT_DTL.X_TYPE":
                    return rdrSUSP_AGENT_DTL.GetNumber("X_TYPE").ToString();
                case "TEMPORARYDATA.SUSP_AGENT_DTL.X_SEQ":
                    return rdrSUSP_AGENT_DTL.GetNumber("X_SEQ").ToString();
                default:
                    return String.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                // TODO: Some manual steps maybe required.
                Access_SUSP_AGENT_DTL();
                while (rdrSUSP_AGENT_DTL.Read())
                {
                    WriteData();
                }

                rdrSUSP_AGENT_DTL.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrSUSP_AGENT_DTL == null))
            {
                rdrSUSP_AGENT_DTL.Close();
                rdrSUSP_AGENT_DTL = null;
            }
        }
    }
}
