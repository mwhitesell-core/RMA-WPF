#region "Screen Comments"

// filename: create_claims_sub.qzs
// purpose:  select data for claims_subfile history file for each clinic
// Modification History
// 91/02/14   D.B. MOD - ADD NEW FIELDS (HEALTH NBR, VERSION CD)
// 91/03/05   D.B. MOD - ACCORDING TO NEW CLAIMS AND PATIENT FILES
// 91/04/22   M.C. SMS 138 - MODIFY THE ACCESS STATEMENT
// 91/08/30   M.C. MOD - TAKE OUT THE SORTED STMT AND CONTROL BREAK
// FROM SUBFILE STMT OF PART C
// 92/02/03   Y.B. MOD - REPLACE SEL_F002_DTL_CLAIMS.DEF WITH
// SEL_PED_F002_DTL_CLAIMS.DEF
// 1999/06/04   S.B. MOD - ALTERED THE CALL TO `SEL_PED_F002_DTL_CLAIMS.DEF`
// TO USE `$USE` INSTEAD OF `SRC`.
// 03/09/17   M.C. MOD - in the third pass (C), add the additional fields
// in the subfile
// 2003/dec/11    A.A.     - alpha doctor nbr 

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
    public class CREATE_CLAIMS_SUBB : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "CREATE_CLAIMS_SUBB";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrF002_CLAIMS_MSTR_HDR = new Reader();

        private Reader rdrDETAIL_CLAIMSA = new Reader();
        private Reader rdrDETAIL_CLAIMSB = new Reader();

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
                SubFileName = "DETAIL_CLAIMSB";
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

        private void Access_DETAIL_CLAIMSA()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT * ");
            strSQL.Append("FROM TEMPORARYDATA.DETAIL_CLAIMSA ");

            rdrDETAIL_CLAIMSA.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);

            strSQL = null;
        }

        private void Access_F002_CLAIMS_MSTR_HDR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("KEY_CLM_TYPE, ");
            strSQL.Append("KEY_CLM_BATCH_NBR, ");
            strSQL.Append("KEY_CLM_CLAIM_NBR, ");
            strSQL.Append("CLMHDR_ADJ_OMA_CD, ");
            strSQL.Append("CLMHDR_HOSP, ");
            strSQL.Append("CLMHDR_DOC_DEPT, ");
            strSQL.Append("CLMHDR_AGENT_CD, ");
            //strSQL.Append("CLMHDR_PAT_OHIP_ID_OR_CHART, ");
            strSQL.Append("CLMHDR_PAT_KEY_TYPE, ");
            strSQL.Append("CLMHDR_PAT_KEY_DATA, ");
            strSQL.Append("CLMHDR_LOC, ");
            strSQL.Append("CLMHDR_REFER_DOC_NBR, ");
            strSQL.Append("CLMHDR_DIAG_CD, ");
            strSQL.Append("CLMHDR_DOC_SPEC_CD, ");
            strSQL.Append("CLMHDR_I_O_PAT_IND, ");
            strSQL.Append("CLMHDR_DATE_ADMIT, ");
            strSQL.Append("CLMHDR_DOC_NBR_OHIP ");
            strSQL.Append("FROM INDEXED.F002_CLAIMS_MSTR_HDR ");
            strSQL.Append("WHERE ");
            strSQL.Append(" KEY_CLM_TYPE = 'B'");
            strSQL.Append(" AND KEY_CLM_BATCH_NBR = ").Append(Common.StringToField(rdrDETAIL_CLAIMSA.GetString("KEY_CLM_BATCH_NBR")));
            strSQL.Append(" AND KEY_CLM_CLAIM_NBR = ").Append(rdrDETAIL_CLAIMSA.GetNumber("KEY_CLM_CLAIM_NBR"));
            strSQL.Append(" AND KEY_CLM_SERV_CODE = '00000'");
            strSQL.Append(" AND KEY_CLM_ADJ_NBR = '0'");

            strSQL.Append(SelectIf_F002_CLAIMS_MSTR_HDR(false));

            rdrF002_CLAIMS_MSTR_HDR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

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

        private string SelectIf_F002_CLAIMS_MSTR_HDR(bool blnAddWhere)
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            if (blnAddWhere)
            {
                strSQL.Append(" WHERE ");
            }
            else
            {
                strSQL.Append(" AND ");
            }

            strSQL.Append("CLMHDR_BATCH_TYPE = 'C'");
            return strSQL.ToString();
        }
        #endregion

        #region " DEFINES "

        private string F002_CLAIMS_MSTR_CLMHDR_PAT_OHIP_ID_OR_CHART()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = (rdrF002_CLAIMS_MSTR_HDR.GetString("CLMHDR_PAT_KEY_TYPE") + rdrF002_CLAIMS_MSTR_HDR.GetString("CLMHDR_PAT_KEY_DATA"));
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
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.DETAIL_CLAIMSA.CLMDTL_ID", DataTypes.Character, 16);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.DETAIL_CLAIMSA.CLMDTL_NBR_SERV", DataTypes.Numeric, 2);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.DETAIL_CLAIMSA.CLMDTL_SV_DATE", DataTypes.Character, 8);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.DETAIL_CLAIMSA.CLMDTL_CONSEC_DATES", DataTypes.Character, 9);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.DETAIL_CLAIMSA.CLMDTL_AMT_TECH_BILLED", DataTypes.Numeric, 6);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.DETAIL_CLAIMSA.CLMDTL_FEE_OMA", DataTypes.Numeric, 7);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.DETAIL_CLAIMSA.CLMDTL_FEE_OHIP", DataTypes.Numeric, 7);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.DETAIL_CLAIMSA.CLMDTL_DATE_PERIOD_END", DataTypes.Character, 8);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR_HDR.CLMHDR_HOSP", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR_HDR.CLMHDR_DOC_DEPT", DataTypes.Numeric, 2);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR_HDR.CLMHDR_AGENT_CD", DataTypes.Numeric, 1);
                AddControl(ReportSection.SUMMARY, "CLMHDR_PAT_OHIP_ID_OR_CHART", DataTypes.Character, 16);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR_HDR.CLMHDR_LOC", DataTypes.Character, 4);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR_HDR.CLMHDR_REFER_DOC_NBR", DataTypes.Numeric, 6);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.DETAIL_CLAIMSA.CLMDTL_DIAG_CD", DataTypes.Numeric, 3);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR_HDR.CLMHDR_DOC_SPEC_CD", DataTypes.Numeric, 2);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR_HDR.CLMHDR_I_O_PAT_IND", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR_HDR.CLMHDR_DATE_ADMIT", DataTypes.Character, 8);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR_HDR.CLMHDR_DOC_NBR_OHIP", DataTypes.Numeric, 6);
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
        //# Do not delete, modify or move it.  Updated: 10/19/2017 10:42:22 AM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
               case "TEMPORARYDATA.DETAIL_CLAIMSA.CLMDTL_ID":
                    return Common.StringToField(rdrDETAIL_CLAIMSA.GetString("CLMDTL_ID").PadRight(16, ' '));

                case "TEMPORARYDATA.DETAIL_CLAIMSA.CLMDTL_NBR_SERV":
                    return rdrDETAIL_CLAIMSA.GetNumber("CLMDTL_NBR_SERV").ToString().PadLeft(2, ' ');

                case "TEMPORARYDATA.DETAIL_CLAIMSA.CLMDTL_SV_DATE":
                    return Common.StringToField(rdrDETAIL_CLAIMSA.GetString("CLMDTL_SV_DATE").PadRight(8, ' '));

                case "TEMPORARYDATA.DETAIL_CLAIMSA.CLMDTL_CONSEC_DATES":
                    return Common.StringToField(rdrDETAIL_CLAIMSA.GetString("CLMDTL_CONSEC_DATES").PadLeft(9, ' '));

                case "TEMPORARYDATA.DETAIL_CLAIMSA.CLMDTL_AMT_TECH_BILLED":
                    return rdrDETAIL_CLAIMSA.GetNumber("CLMDTL_AMT_TECH_BILLED").ToString().PadLeft(6, ' ');

                case "TEMPORARYDATA.DETAIL_CLAIMSA.CLMDTL_FEE_OMA":
                    return rdrDETAIL_CLAIMSA.GetNumber("CLMDTL_FEE_OMA").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.DETAIL_CLAIMSA.CLMDTL_FEE_OHIP":
                    return rdrDETAIL_CLAIMSA.GetNumber("CLMDTL_FEE_OHIP").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.DETAIL_CLAIMSA.CLMDTL_DATE_PERIOD_END":
                    return Common.StringToField(rdrDETAIL_CLAIMSA.GetString("CLMDTL_DATE_PERIOD_END").PadRight(8, ' '));
                    
                case "INDEXED.F002_CLAIMS_MSTR_HDR.CLMHDR_HOSP":
                    return Common.StringToField(rdrF002_CLAIMS_MSTR_HDR.GetString("CLMHDR_HOSP").PadLeft(1, ' '));

                case "INDEXED.F002_CLAIMS_MSTR_HDR.CLMHDR_DOC_DEPT":
                    return rdrF002_CLAIMS_MSTR_HDR.GetNumber("CLMHDR_DOC_DEPT").ToString().PadLeft(2, ' ');

                case "INDEXED.F002_CLAIMS_MSTR_HDR.CLMHDR_AGENT_CD":
                    return rdrF002_CLAIMS_MSTR_HDR.GetNumber("CLMHDR_AGENT_CD").ToString().PadLeft(1, ' ');

                case "CLMHDR_PAT_OHIP_ID_OR_CHART":
                    return Common.StringToField(F002_CLAIMS_MSTR_CLMHDR_PAT_OHIP_ID_OR_CHART().PadRight(16, ' '));
                    
                case "INDEXED.F002_CLAIMS_MSTR_HDR.CLMHDR_LOC":
                    return Common.StringToField(rdrF002_CLAIMS_MSTR_HDR.GetString("CLMHDR_LOC").PadLeft(4, ' '));

                case "INDEXED.F002_CLAIMS_MSTR_HDR.CLMHDR_REFER_DOC_NBR":
                    return rdrF002_CLAIMS_MSTR_HDR.GetNumber("CLMHDR_REFER_DOC_NBR").ToString().PadLeft(6, ' ');

                case "TEMPORARYDATA.DETAIL_CLAIMSA.CLMDTL_DIAG_CD":
                    return rdrDETAIL_CLAIMSA.GetNumber("CLMDTL_DIAG_CD").ToString().PadLeft(3, ' ');

                case "INDEXED.F002_CLAIMS_MSTR_HDR.CLMHDR_DOC_SPEC_CD":
                    return rdrF002_CLAIMS_MSTR_HDR.GetNumber("CLMHDR_DOC_SPEC_CD").ToString().PadLeft(2, ' ');

                case "INDEXED.F002_CLAIMS_MSTR_HDR.CLMHDR_I_O_PAT_IND":
                    return Common.StringToField(rdrF002_CLAIMS_MSTR_HDR.GetString("CLMHDR_I_O_PAT_IND").PadLeft(1, ' '));

                case "INDEXED.F002_CLAIMS_MSTR_HDR.CLMHDR_DATE_ADMIT":
                    return Common.StringToField(rdrF002_CLAIMS_MSTR_HDR.GetString("CLMHDR_DATE_ADMIT").PadLeft(8, ' '));

                case "INDEXED.F002_CLAIMS_MSTR_HDR.CLMHDR_DOC_NBR_OHIP":
                    return rdrF002_CLAIMS_MSTR_HDR.GetNumber("CLMHDR_DOC_NBR_OHIP").ToString().PadLeft(6, ' ');

                default:
                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_DETAIL_CLAIMSA();

                while(rdrDETAIL_CLAIMSA.Read())
                {
                    Access_F002_CLAIMS_MSTR_HDR();

                    while (rdrF002_CLAIMS_MSTR_HDR.Read())
                    {
                        WriteData();
                    }
                    rdrF002_CLAIMS_MSTR_HDR.Close();
                }
                rdrDETAIL_CLAIMSA.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrDETAIL_CLAIMSA != null))
            {
                rdrDETAIL_CLAIMSA.Close();
                rdrDETAIL_CLAIMSA = null;
            }

            if ((rdrF002_CLAIMS_MSTR_HDR != null))
            {
                rdrF002_CLAIMS_MSTR_HDR.Close();
                rdrF002_CLAIMS_MSTR_HDR = null;
            }
        }


        #endregion

        #endregion
    }
}
