//  #> program-id.     r022a2.qzs
//  ((C)) Dyad Technologies
//  PROGRAM PURPOSE : SELECT CLAIMS FOR RE-SUBMIT
//  IF CHANGES REQUIRED FOR HOSPITAL CODES, MAKE
//  SURE TO CHANGE IN HOSPITAL_CODE.DEF
//  MODIFICATION HISTORY
//  DATE   WHO          DESCRIPTION
//  00/sep/18 B.E. - moved from r022a.qzs into separate source module
//  03/aug/07 M.C.   - include contract-code in the subfile, so that in u022b.qts, sort
//  on contract-code before any other sort fields; contract D contains
//  all 60`s clinics
//  2003/dec/11 A.A. - alpha doctor nbr
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
    public class R022A2 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R022A2";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrU022A1 = new Reader();
        private Reader rdrF002_CLAIMS_MSTR_DTL = new Reader();
        private Reader rdrU022A2 = new Reader();

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
                //  Create Subfile.
                SubFile = true;
                SubFileName = "U022A2";
                SubFileType = SubFileType.Keep;
                SubFileAT = "CLMHDR_CLAIM_ID";
                Sort = "TRANSLATED_GROUP_NBR ASC, CLMHDR_CLAIM_ID ASC";
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

        private void Access_U022A1()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("KEY_CLM_TYPE, ");
            strSQL.Append("KEY_CLM_BATCH_NBR, ");
            strSQL.Append("KEY_CLM_CLAIM_NBR, ");
            strSQL.Append("CLMHDR_BATCH_TYPE, ");
            strSQL.Append("CLMHDR_DOC_NBR_OHIP, ");
            strSQL.Append("CLMHDR_DATE_SYS, ");
            strSQL.Append("CLMHDR_CLAIM_ID, ");
            strSQL.Append("CLMHDR_CLAIM_NBR, ");
            strSQL.Append("W_CLMHDR_HOSP, ");
            strSQL.Append("CLMHDR_DATE_ADMIT, ");
            //strSQL.Append("CLMHDR_PAT_OHIP_ID_OR_CHART, ");
            strSQL.Append("CLMHDR_PAT_KEY_TYPE, ");
            strSQL.Append("CLMHDR_PAT_KEY_DATA, ");
            strSQL.Append("CLMHDR_REFER_DOC_NBR, ");
            strSQL.Append("CLMHDR_LOC, ");
            strSQL.Append("CLMHDR_I_O_PAT_IND, ");
            strSQL.Append("CLMHDR_AGENT_CD, ");
            strSQL.Append("CLMHDR_TOT_CLAIM_AR_OMA, ");
            strSQL.Append("CLMHDR_TOT_CLAIM_AR_OHIP, ");
            strSQL.Append("CLMHDR_STATUS_OHIP, ");
            strSQL.Append("CLMHDR_DOC_DEPT, ");
            strSQL.Append("CLMHDR_DOC_SPEC_CD, ");
            strSQL.Append("CLMHDR_SUB_NBR, ");
            strSQL.Append("CLMHDR_MANUAL_REVIEW, ");
            strSQL.Append("DOLLAR_FLAG, ");
            strSQL.Append("MOH_FLAG, ");
            strSQL.Append("TRANSLATED_GROUP_NBR, ");
            strSQL.Append("W_MOH_LOCATION_CODE, ");
            strSQL.Append("CONTRACT_CODE ");
            strSQL.Append("FROM TEMPORARYDATA.U022A1 ");

            strSQL.Append(Choose());

            rdrU022A1.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
            strSQL = null;
        }
        private void Link_F002_CLAIMS_MSTR_DTL()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("KEY_CLM_TYPE, ");
            strSQL.Append("KEY_CLM_BATCH_NBR, ");
            strSQL.Append("KEY_CLM_CLAIM_NBR, ");
            strSQL.Append("CLMDTL_ADJ_NBR, ");
            strSQL.Append("CLMDTL_OMA_CD, ");
            strSQL.Append("CLMDTL_SV_YY, ");
            strSQL.Append("CLMDTL_SV_MM, ");
            strSQL.Append("CLMDTL_SV_DD ");
            strSQL.Append("FROM INDEXED.F002_CLAIMS_MSTR_DTL ");
            strSQL.Append("WHERE ");
            strSQL.Append("KEY_CLM_TYPE = 'B'");
            strSQL.Append(" AND KEY_CLM_BATCH_NBR = ").Append(Common.StringToField(rdrU022A1.GetString("KEY_CLM_BATCH_NBR")));
            strSQL.Append(" AND KEY_CLM_CLAIM_NBR = ").Append(rdrU022A1.GetNumber("KEY_CLM_CLAIM_NBR"));

            strSQL.Append(SelectIf_F002_CLAIMS_MSTR(false));

            rdrF002_CLAIMS_MSTR_DTL.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
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

        private string SelectIf_F002_CLAIMS_MSTR(bool blnAddWhere)
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

            strSQL.Append("(CLMDTL_OMA_CD <> '0000' AND ");
            strSQL.Append("CLMDTL_OMA_CD <> 'ZZZZ')");
            return strSQL.ToString();
        }

        #endregion

        #region " DEFINES "

        private string F002_CLAIMS_MSTR_DTL_CLMDTL_SV_DATE()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = (rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_SV_YY").ToString() 
                    + rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_SV_MM").ToString().PadLeft(2, '0') 
                    + rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_SV_DD").ToString().PadLeft(2, '0'));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string U022A1_CLMHDR_BATCH_NBR()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = QDesign.Substring(rdrU022A1.GetString("CLMHDR_CLAIM_ID"), 1, 8);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string U022A1_CLMHDR_ADJ_OMA_CD()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = QDesign.Substring(rdrU022A1.GetString("CLMHDR_CLAIM_ID"), 11, 4);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string U022A1_CLMHDR_ADJ_OMA_SUFF()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = QDesign.Substring(rdrU022A1.GetString("CLMHDR_CLAIM_ID"), 15, 1);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string U022A1_CLMHDR_ADJ_ADJ_NBR()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = QDesign.Substring(rdrU022A1.GetString("CLMHDR_CLAIM_ID"), 16, 1);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string U022A1_CLMHDR_PAT_OHIP_ID_OR_CHART()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = (rdrU022A1.GetString("CLMHDR_PAT_KEY_TYPE") + rdrU022A1.GetString("CLMHDR_PAT_KEY_DATA"));
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
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A1.KEY_CLM_TYPE", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A1.KEY_CLM_BATCH_NBR", DataTypes.Character, 8);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A1.KEY_CLM_CLAIM_NBR", DataTypes.Numeric, 2);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A1.CLMHDR_BATCH_TYPE", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A1.CLMHDR_DOC_NBR_OHIP", DataTypes.Numeric, 6);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A1.CLMHDR_DATE_SYS", DataTypes.Character, 8);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A1.CLMHDR_CLAIM_ID", DataTypes.Character, 16);
                AddControl(ReportSection.SUMMARY, "CLMHDR_BATCH_NBR", DataTypes.Character, 8);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A1.CLMHDR_CLAIM_NBR", DataTypes.Numeric, 2);
                AddControl(ReportSection.SUMMARY, "CLMHDR_ADJ_OMA_CD", DataTypes.Character, 4);
                AddControl(ReportSection.SUMMARY, "CLMHDR_ADJ_OMA_SUFF", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "CLMHDR_ADJ_ADJ_NBR", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A1.W_CLMHDR_HOSP", DataTypes.Character, 4);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A1.CLMHDR_DATE_ADMIT", DataTypes.Character, 8);
                AddControl(ReportSection.SUMMARY, "CLMHDR_PAT_OHIP_ID_OR_CHART", DataTypes.Character, 16);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A1.CLMHDR_PAT_KEY_TYPE", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A1.CLMHDR_PAT_KEY_DATA", DataTypes.Character, 15);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A1.CLMHDR_REFER_DOC_NBR", DataTypes.Numeric, 6);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A1.CLMHDR_LOC", DataTypes.Character, 4);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A1.CLMHDR_I_O_PAT_IND", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A1.CLMHDR_AGENT_CD", DataTypes.Numeric, 1);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A1.CLMHDR_TOT_CLAIM_AR_OMA", DataTypes.Numeric, 7);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A1.CLMHDR_TOT_CLAIM_AR_OHIP", DataTypes.Numeric, 7);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A1.CLMHDR_STATUS_OHIP", DataTypes.Character, 2);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A1.CLMHDR_SUB_NBR", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A1.CLMHDR_DOC_DEPT", DataTypes.Numeric, 2);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A1.CLMHDR_DOC_SPEC_CD", DataTypes.Numeric, 2);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A1.CLMHDR_MANUAL_REVIEW", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR_DTL.CLMDTL_ADJ_NBR", DataTypes.Numeric, 1);
                AddControl(ReportSection.SUMMARY, "CLMDTL_SV_DATE", DataTypes.Character, 8);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A1.MOH_FLAG", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A1.DOLLAR_FLAG", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A1.TRANSLATED_GROUP_NBR", DataTypes.Character, 4);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A1.W_MOH_LOCATION_CODE", DataTypes.Character, 4);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A1.CONTRACT_CODE", DataTypes.Character, 2);
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
        // # Do not delete, modify or move it.  Updated: 2018-05-11 6:02:21 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            // TODO: Remove duplicate controls, if there are any.
            switch (strControl)
            {
                case "TEMPORARYDATA.U022A1.KEY_CLM_TYPE":
                    return Common.StringToField(rdrU022A1.GetString("KEY_CLM_TYPE"));

                case "TEMPORARYDATA.U022A1.KEY_CLM_BATCH_NBR":
                    return Common.StringToField(rdrU022A1.GetString("KEY_CLM_BATCH_NBR"));

                case "TEMPORARYDATA.U022A1.KEY_CLM_CLAIM_NBR":
                    return rdrU022A1.GetNumber("KEY_CLM_CLAIM_NBR").ToString();

                case "TEMPORARYDATA.U022A1.CLMHDR_BATCH_TYPE":
                    return Common.StringToField(rdrU022A1.GetString("CLMHDR_BATCH_TYPE"));

                case "TEMPORARYDATA.U022A1.CLMHDR_DOC_NBR_OHIP":
                    return rdrU022A1.GetNumber("CLMHDR_DOC_NBR_OHIP").ToString();

                case "TEMPORARYDATA.U022A1.CLMHDR_DATE_SYS":
                    return Common.StringToField(rdrU022A1.GetString("CLMHDR_DATE_SYS"));

                case "TEMPORARYDATA.U022A1.CLMHDR_CLAIM_ID":
                    return Common.StringToField(rdrU022A1.GetString("CLMHDR_CLAIM_ID"));

                case "CLMHDR_BATCH_NBR":
                    return Common.StringToField(U022A1_CLMHDR_BATCH_NBR());

                case "TEMPORARYDATA.U022A1.CLMHDR_CLAIM_NBR":
                    return rdrU022A1.GetNumber("CLMHDR_CLAIM_NBR").ToString();

                case "CLMHDR_ADJ_OMA_CD":
                    return Common.StringToField(U022A1_CLMHDR_ADJ_OMA_CD());

                case "CLMHDR_ADJ_OMA_SUFF":
                    return Common.StringToField(U022A1_CLMHDR_ADJ_OMA_SUFF());

                case "CLMHDR_ADJ_ADJ_NBR":
                    return Common.StringToField(U022A1_CLMHDR_ADJ_ADJ_NBR());

                case "TEMPORARYDATA.U022A1.W_CLMHDR_HOSP":
                    return Common.StringToField(rdrU022A1.GetString("W_CLMHDR_HOSP"));

                case "TEMPORARYDATA.U022A1.CLMHDR_DATE_ADMIT":
                    return Common.StringToField(rdrU022A1.GetString("CLMHDR_DATE_ADMIT"));

                case "CLMHDR_PAT_OHIP_ID_OR_CHART":
                    return Common.StringToField(U022A1_CLMHDR_PAT_OHIP_ID_OR_CHART());

                case "TEMPORARYDATA.U022A1.CLMHDR_PAT_KEY_TYPE":
                    return Common.StringToField(rdrU022A1.GetString("CLMHDR_PAT_KEY_TYPE"));

                case "TEMPORARYDATA.U022A1.CLMHDR_PAT_KEY_DATA":
                    return Common.StringToField(rdrU022A1.GetString("CLMHDR_PAT_KEY_DATA"));

                case "TEMPORARYDATA.U022A1.CLMHDR_REFER_DOC_NBR":
                    return rdrU022A1.GetNumber("CLMHDR_REFER_DOC_NBR").ToString();

                case "TEMPORARYDATA.U022A1.CLMHDR_LOC":
                    return Common.StringToField(rdrU022A1.GetString("CLMHDR_LOC"));

                case "TEMPORARYDATA.U022A1.CLMHDR_I_O_PAT_IND":
                    return Common.StringToField(rdrU022A1.GetString("CLMHDR_I_O_PAT_IND"));

                case "TEMPORARYDATA.U022A1.CLMHDR_AGENT_CD":
                    return rdrU022A1.GetNumber("CLMHDR_AGENT_CD").ToString();

                case "TEMPORARYDATA.U022A1.CLMHDR_TOT_CLAIM_AR_OMA":
                    return rdrU022A1.GetNumber("CLMHDR_TOT_CLAIM_AR_OMA").ToString();

                case "TEMPORARYDATA.U022A1.CLMHDR_TOT_CLAIM_AR_OHIP":
                    return rdrU022A1.GetNumber("CLMHDR_TOT_CLAIM_AR_OHIP").ToString();

                case "TEMPORARYDATA.U022A1.CLMHDR_STATUS_OHIP":
                    return Common.StringToField(rdrU022A1.GetString("CLMHDR_STATUS_OHIP"));

                case "TEMPORARYDATA.U022A1.CLMHDR_SUB_NBR":
                    return Common.StringToField(rdrU022A1.GetString("CLMHDR_SUB_NBR"));

                case "TEMPORARYDATA.U022A1.CLMHDR_DOC_DEPT":
                    return rdrU022A1.GetNumber("CLMHDR_DOC_DEPT").ToString();

                case "TEMPORARYDATA.U022A1.CLMHDR_DOC_SPEC_CD":
                    return rdrU022A1.GetNumber("CLMHDR_DOC_SPEC_CD").ToString();

                case "TEMPORARYDATA.U022A1.CLMHDR_MANUAL_REVIEW":
                    return Common.StringToField(rdrU022A1.GetString("CLMHDR_MANUAL_REVIEW"));

                case "INDEXED.F002_CLAIMS_MSTR_DTL.CLMDTL_ADJ_NBR":
                    return rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_ADJ_NBR").ToString();

                case "CLMDTL_SV_DATE":
                    return Common.StringToField(F002_CLAIMS_MSTR_DTL_CLMDTL_SV_DATE());

                case "TEMPORARYDATA.U022A1.MOH_FLAG":
                    return Common.StringToField(rdrU022A1.GetString("MOH_FLAG"));

                case "TEMPORARYDATA.U022A1.DOLLAR_FLAG":
                    return Common.StringToField(rdrU022A1.GetString("DOLLAR_FLAG"));

                case "TEMPORARYDATA.U022A1.TRANSLATED_GROUP_NBR":
                    return Common.StringToField(rdrU022A1.GetString("TRANSLATED_GROUP_NBR"));

                case "TEMPORARYDATA.U022A1.W_MOH_LOCATION_CODE":
                    return Common.StringToField(rdrU022A1.GetString("W_MOH_LOCATION_CODE"));

                case "TEMPORARYDATA.U022A1.CONTRACT_CODE":
                    return Common.StringToField(rdrU022A1.GetString("CONTRACT_CODE"));

                default:
                    return string.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                Access_U022A1();
                while (rdrU022A1.Read())
                {
                    Link_F002_CLAIMS_MSTR_DTL();
                    while (rdrF002_CLAIMS_MSTR_DTL.Read())
                    {
                        WriteData();
                    }
                    rdrF002_CLAIMS_MSTR_DTL.Close();
                }

                rdrU022A1.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrU022A1 == null))
            {
                rdrU022A1.Close();
                rdrU022A1 = null;
            }

            if (!(rdrF002_CLAIMS_MSTR_DTL == null))
            {
                rdrF002_CLAIMS_MSTR_DTL.Close();
                rdrF002_CLAIMS_MSTR_DTL = null;
            }
        }

        #endregion

        #endregion
    }
}
