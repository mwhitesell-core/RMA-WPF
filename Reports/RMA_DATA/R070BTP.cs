//  DOC: R070BTP.QZS
//  DOC: ACCOUNTS RECEIVABLE
//  DOC: SORT BY/SORT-RECORD-STATUS/AGENT/AGE DESCENDING/CLAIM NBR
//  DOC: RUN FOR: MUMC DIAGNOSTICS
//  PROGRAM PURPOSE : ACCOUNTS RECEIVABLE (SORT FILE)
//  DATE       BY WHOM   DESCRIPTION
//  92/06/23   YASEMIN   ORIGINAL
//  03/dec/17  A.A.      alpha doctor nbr
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
    public class R070BTP : BaseRDLClass
    {
        protected const string REPORT_NAME = "R070BTP";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrR070ATP = new Reader();
        private Reader rdrF002_CLAIMS_MSTR_HDR = new Reader();
        private Reader rdrF002_CLAIMS_MSTR_DTL = new Reader();
        private Reader rdrR070BTP = new Reader();
        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                //  Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;
                //  Create Subfile.
                SubFile = true;
                SubFileName = "R070BTP";
                SubFileType = SubFileType.Keep;
                SubFileAT = "X_CLM_ID";
                Sort = "X_CLM_ID ASC";
                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return ReportData;
        }
        private void Access_R070ATP()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: If * is not used to select all columns, ensure the necessary columns (i.e. columns that are used to access records of other tables) are included in the SELECT statement
            strSQL.Append("SELECT ");
            strSQL.Append("KEY_CLM_BATCH_NBR, ");
            strSQL.Append("KEY_CLM_CLAIM_NBR, ");
            strSQL.Append("X_CLM_ID, ");
            strSQL.Append("X_SORT_RECORD_STATUS, ");
            strSQL.Append("CLMHDR_AGENT_CD, ");
            strSQL.Append("X_AGE_CATEGORY, ");
            strSQL.Append("CLMHDR_DOC_DEPT, ");
            strSQL.Append("ICONST_CLINIC_NBR, ");
            strSQL.Append("ICONST_CLINIC_NAME, ");
            strSQL.Append("ICONST_DATE_PERIOD_END, ");
            strSQL.Append("CLMHDR_PAT_ACRONYM, ");
            strSQL.Append("X_PAT_ID_INFO, ");
            strSQL.Append("CLMHDR_AMT_TECH_BILLED, ");
            strSQL.Append("CLMHDR_AMT_TECH_PAID, ");
            strSQL.Append("X_BALANCE_DUE, ");
            strSQL.Append("CLMHDR_DATE_PERIOD_END, ");
            strSQL.Append("X_DAY_OLD, ");
            strSQL.Append("CLMHDR_ORIG_BATCH_NBR, ");
            strSQL.Append("CLMHDR_REFERENCE, ");
            strSQL.Append("X_SUB_NBR, ");
            strSQL.Append("X_TECH_DUE, ");
            strSQL.Append("X_PROF_BILL, ");
            strSQL.Append("X_PROF_PAID, ");
            strSQL.Append("X_PROF_DUE ");
            strSQL.Append("FROM TEMPORARYDATA.R070ATP ");
            strSQL.Append(Choose());
            rdrR070ATP.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
            strSQL = null;
        }
        private void Link_F002_CLAIMS_MSTR_DTL()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("CLMDTL_SV_YY, ");
            strSQL.Append(" CLMDTL_SV_MM, ");
            strSQL.Append(" CLMDTL_SV_DD ");
            strSQL.Append("FROM INDEXED.F002_CLAIMS_MSTR_DTL ");
            strSQL.Append("WHERE ");
            strSQL.Append("KEY_CLM_TYPE = ").Append("'B'");
            strSQL.Append(" AND KEY_CLM_BATCH_NBR = ").Append(Common.StringToField(rdrR070ATP.GetString("KEY_CLM_BATCH_NBR")));
            strSQL.Append(" AND KEY_CLM_CLAIM_NBR = ").Append(rdrR070ATP.GetNumber("KEY_CLM_CLAIM_NBR"));

            strSQL.Append(SelectIf_F002_CLAIMS_MSTR_DTL(false));

            rdrF002_CLAIMS_MSTR_DTL.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_F002_CLAIMS_MSTR_HDR()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("KEY_CLM_TYPE, ");
            strSQL.Append("KEY_CLM_BATCH_NBR, ");
            strSQL.Append("KEY_CLM_CLAIM_NBR, ");
            strSQL.Append("CLMHDR_ADJ_OMA_CD, ");
            strSQL.Append("CLMHDR_BATCH_NBR, ");
            strSQL.Append(" CLMHDR_CLAIM_NBR, ");
            strSQL.Append(" CLMHDR_ADJ_OMA_CD, ");
            strSQL.Append(" CLMHDR_ADJ_OMA_SUFF, ");
            strSQL.Append(" CLMHDR_ADJ_ADJ_NBR ");
            strSQL.Append("FROM INDEXED.F002_CLAIMS_MSTR_HDR ");
            strSQL.Append("WHERE ");
            strSQL.Append("KEY_CLM_TYPE = ").Append("'B'");
            strSQL.Append(" AND KEY_CLM_BATCH_NBR = ").Append(Common.StringToField(rdrR070ATP.GetString("KEY_CLM_BATCH_NBR")));
            strSQL.Append(" AND KEY_CLM_CLAIM_NBR = ").Append(rdrR070ATP.GetNumber("KEY_CLM_CLAIM_NBR"));

            rdrF002_CLAIMS_MSTR_HDR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(String.Empty);
            // TODO: CHOOSE Statement - May require manual changes.
            return strChoose.ToString().ToString();
        }

        private string SelectIf_F002_CLAIMS_MSTR_DTL(bool blnAddWhere)
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

            strSQL.Append(" (CLMDTL_OMA_CD <>  '0000' AND ");
            strSQL.Append("CLMDTL_OMA_CD <>  'ZZZZ' AND ");
            strSQL.Append("CLMDTL_OMA_CD <>  'PAID')");

            return strSQL.ToString().ToString();
        }

        private string X_CLINIC()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = QDesign.Substring(QDesign.ASCII(rdrF002_CLAIMS_MSTR_HDR.GetString("CLMHDR_BATCH_NBR")), 1, 2);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private decimal F002_CLAIMS_MSTR_CLMDTL_SV_DATE()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = QDesign.NConvert(QDesign.ASCII(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_SV_YY"), 4) + QDesign.ASCII(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_SV_MM"), 2) + QDesign.ASCII(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_SV_DD"), 2));

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
                AddControl(ReportSection.SUMMARY, "X_CLINIC", DataTypes.Character, 2);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.R070ATP.X_SORT_RECORD_STATUS", DataTypes.Numeric, 1);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.R070ATP.CLMHDR_AGENT_CD", DataTypes.Numeric, 1);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.R070ATP.X_AGE_CATEGORY", DataTypes.Numeric, 1);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.R070ATP.X_CLM_ID", DataTypes.Character, 10);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.R070ATP.CLMHDR_DOC_DEPT", DataTypes.Numeric, 2);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.R070ATP.ICONST_CLINIC_NBR", DataTypes.Character, 4);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.R070ATP.ICONST_CLINIC_NAME", DataTypes.Character, 20);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.R070ATP.ICONST_DATE_PERIOD_END", DataTypes.Numeric, 8);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.R070ATP.CLMHDR_PAT_ACRONYM", DataTypes.Character, 9);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.R070ATP.X_PAT_ID_INFO", DataTypes.Character, 12);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.R070ATP.CLMHDR_AMT_TECH_BILLED", DataTypes.Numeric, 6);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.R070ATP.CLMHDR_AMT_TECH_PAID", DataTypes.Numeric, 6);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.R070ATP.X_BALANCE_DUE", DataTypes.Numeric, 7);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.R070ATP.CLMHDR_DATE_PERIOD_END", DataTypes.Numeric, 8);
                AddControl(ReportSection.SUMMARY, "CLMDTL_SV_DATE", DataTypes.Numeric, 8);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.R070ATP.X_DAY_OLD", DataTypes.Character, 3);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.R070ATP.CLMHDR_ORIG_BATCH_NBR", DataTypes.Character, 8);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.R070ATP.CLMHDR_REFERENCE", DataTypes.Character, 11);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.R070ATP.X_SUB_NBR", DataTypes.Numeric, 1);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.R070ATP.X_TECH_DUE", DataTypes.Numeric, 6);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.R070ATP.X_PROF_BILL", DataTypes.Numeric, 7);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.R070ATP.X_PROF_PAID", DataTypes.Numeric, 7);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.R070ATP.X_PROF_DUE", DataTypes.Numeric, 7);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-05-14 10:21:00 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            // TODO: Remove duplicate controls, if there are any.
            switch (strControl)
            {
                case "X_CLINIC":
                    return Common.StringToField(X_CLINIC(), intSize);
                case "TEMPORARYDATA.R070ATP.X_SORT_RECORD_STATUS":
                    return rdrR070ATP.GetNumber("X_SORT_RECORD_STATUS").ToString();
                case "TEMPORARYDATA.R070ATP.CLMHDR_AGENT_CD":
                    return rdrR070ATP.GetNumber("CLMHDR_AGENT_CD").ToString();
                case "TEMPORARYDATA.R070ATP.X_AGE_CATEGORY":
                    return rdrR070ATP.GetNumber("X_AGE_CATEGORY").ToString();
                case "TEMPORARYDATA.R070ATP.X_CLM_ID":
                    return Common.StringToField(rdrR070ATP.GetString("X_CLM_ID"));
                case "TEMPORARYDATA.R070ATP.CLMHDR_DOC_DEPT":
                    return rdrR070ATP.GetNumber("CLMHDR_DOC_DEPT").ToString();
                case "TEMPORARYDATA.R070ATP.ICONST_CLINIC_NBR":
                    return Common.StringToField(rdrR070ATP.GetString("ICONST_CLINIC_NBR"));
                case "TEMPORARYDATA.R070ATP.ICONST_CLINIC_NAME":
                    return Common.StringToField(rdrR070ATP.GetString("ICONST_CLINIC_NAME"));
                case "TEMPORARYDATA.R070ATP.ICONST_DATE_PERIOD_END":
                    return rdrR070ATP.GetNumber("ICONST_DATE_PERIOD_END").ToString();
                case "TEMPORARYDATA.R070ATP.CLMHDR_PAT_ACRONYM":
                    return Common.StringToField(rdrR070ATP.GetString("CLMHDR_PAT_ACRONYM"));
                case "TEMPORARYDATA.R070ATP.X_PAT_ID_INFO":
                    return Common.StringToField(rdrR070ATP.GetString("X_PAT_ID_INFO"));
                case "TEMPORARYDATA.R070ATP.CLMHDR_AMT_TECH_BILLED":
                    return rdrR070ATP.GetNumber("CLMHDR_AMT_TECH_BILLED").ToString();
                case "TEMPORARYDATA.R070ATP.CLMHDR_AMT_TECH_PAID":
                    return rdrR070ATP.GetNumber("CLMHDR_AMT_TECH_PAID").ToString();
                case "TEMPORARYDATA.R070ATP.X_BALANCE_DUE":
                    return rdrR070ATP.GetNumber("X_BALANCE_DUE").ToString();
                case "TEMPORARYDATA.R070ATP.CLMHDR_DATE_PERIOD_END":
                    return rdrR070ATP.GetNumber("CLMHDR_DATE_PERIOD_END").ToString();
                case "CLMDTL_SV_DATE":
                    return F002_CLAIMS_MSTR_CLMDTL_SV_DATE().ToString();
                case "TEMPORARYDATA.R070ATP.X_DAY_OLD":
                    return Common.StringToField(rdrR070ATP.GetString("X_DAY_OLD"));
                case "TEMPORARYDATA.R070ATP.CLMHDR_ORIG_BATCH_NBR":
                    return Common.StringToField(rdrR070ATP.GetString("CLMHDR_ORIG_BATCH_NBR"));
                case "TEMPORARYDATA.R070ATP.CLMHDR_REFERENCE":
                    return Common.StringToField(rdrR070ATP.GetString("CLMHDR_REFERENCE"));
                case "TEMPORARYDATA.R070ATP.X_SUB_NBR":
                    return rdrR070ATP.GetNumber("X_SUB_NBR").ToString();
                case "TEMPORARYDATA.R070ATP.X_TECH_DUE":
                    return rdrR070ATP.GetNumber("X_TECH_DUE").ToString();
                case "TEMPORARYDATA.R070ATP.X_PROF_BILL":
                    return rdrR070ATP.GetNumber("X_PROF_BILL").ToString();
                case "TEMPORARYDATA.R070ATP.X_PROF_PAID":
                    return rdrR070ATP.GetNumber("X_PROF_PAID").ToString();
                case "TEMPORARYDATA.R070ATP.X_PROF_DUE":
                    return rdrR070ATP.GetNumber("X_PROF_DUE").ToString();
                default:
                    return String.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                // TODO: Some manual steps maybe required.
                Access_R070ATP();
                while (rdrR070ATP.Read())
                {
                    Link_F002_CLAIMS_MSTR_HDR();
                    while (rdrF002_CLAIMS_MSTR_HDR.Read())
                    {
                        Link_F002_CLAIMS_MSTR_DTL();
                        while (rdrF002_CLAIMS_MSTR_DTL.Read())
                        {
                            WriteData();
                        }
                        rdrF002_CLAIMS_MSTR_DTL.Close();
                    }

                    rdrF002_CLAIMS_MSTR_HDR.Close();
                }

                rdrR070ATP.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrR070ATP == null))
            {
                rdrR070ATP.Close();
                rdrR070ATP = null;
            }

            if (!(rdrF002_CLAIMS_MSTR_HDR == null))
            {
                rdrF002_CLAIMS_MSTR_HDR.Close();
                rdrF002_CLAIMS_MSTR_HDR = null;
            }

            if (!(rdrF002_CLAIMS_MSTR_DTL == null))
            {
                rdrF002_CLAIMS_MSTR_DTL.Close();
                rdrF002_CLAIMS_MSTR_DTL = null;
            }
        }
    }
}
