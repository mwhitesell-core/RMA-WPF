//  #> program-id.     r022a5.qzs
//  ((C)) Dyad Technologies
//  PROGRAM PURPOSE : SELECT CLAIMS FOR RE-SUBMIT
//  IF CHANGES REQUIRED FOR HOSPITAL CODES, MAKE
//  SURE TO CHANGE IN HOSPITAL_CODE.DEF
//  MODIFICATION HISTORY
//  DATE   WHO          DESCRIPTION
//  00/sep/18 B.E.        - moved from r022a.qzs into separate source module
//  03/nov/13 M.C. - include pat-birth-date, pat-version-cd & clmhdr-loc
//  into the subfile u022a4
//  03/dec/12 A.A. - alpha doctor nbr
//  05/dec/05 M.C. - include patient name in u022a4 subfile
//  !  link ( B  ,(nconvert(clmhdr-claim-id[1:9])), &
//  !             (nconvert(clmhdr-claim-id[10:2]))) &
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
    public class R022A5 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R022A5";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrU020A1 = new Reader();
        private Reader rdrF002_CLAIMS_MSTR_HDR = new Reader();
        private Reader rdrF002_CLAIMS_MSTR_DTL = new Reader();
        private Reader rdrU022A4 = new Reader();

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
                SubFileName = "U022A4";
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

        private void Access_U020A1()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("CLMHDR_CLAIM_ID, ");
            strSQL.Append("CLMHDR_BATCH_NBR, ");
            strSQL.Append("BATCTRL_BATCH_TYPE, ");
            strSQL.Append("MOH_FLAG, ");
            strSQL.Append("CLMHDR_MANUAL_REVIEW, ");
            strSQL.Append("TRANSLATED_GROUP_NBR, ");
            strSQL.Append("BATCTRL_DOC_NBR_OHIP, ");
            strSQL.Append("BATCTRL_AGENT_CD, ");
            strSQL.Append("BATCTRL_CLINIC_NBR, ");
            strSQL.Append("ICONST_CLINIC_NBR_1_2, ");
            strSQL.Append("CLMHDR_DOC_SPEC_CD, ");
            strSQL.Append("PAT_HEALTH_NBR, ");
            strSQL.Append("W_PAT_OHIP_MMYY, ");
            strSQL.Append("PAT_PROV_CD, ");
            strSQL.Append("DOLLAR_FLAG, ");
            strSQL.Append("PAT_SURNAME, ");
            strSQL.Append("PAT_GIVEN_NAME, ");
            strSQL.Append("PAT_BIRTH_DATE, ");
            strSQL.Append("PAT_VERSION_CD, ");
            strSQL.Append("CLMHDR_LOC ");
            strSQL.Append("FROM TEMPORARYDATA.U020A1 ");
            strSQL.Append(SelectIf_U020A1(true));

            strSQL.Append(Choose());

            rdrU020A1.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
            strSQL = null;
        }
        private void Link_F002_CLAIMS_MSTR_HDR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("KEY_CLM_TYPE, ");
            strSQL.Append("KEY_CLM_BATCH_NBR, ");
            strSQL.Append("KEY_CLM_CLAIM_NBR, ");
            strSQL.Append("CLMHDR_ADJ_OMA_CD ");
            strSQL.Append("FROM INDEXED.F002_CLAIMS_MSTR_HDR ");
            strSQL.Append("WHERE ");
            strSQL.Append("KEY_CLM_TYPE = '").Append("B'");
            strSQL.Append(" AND KEY_CLM_BATCH_NBR = '").Append(QDesign.Substring(rdrU020A1.GetString("CLMHDR_CLAIM_ID"), 1, 8));
            strSQL.Append("' AND KEY_CLM_CLAIM_NBR = ").Append(QDesign.NConvert(QDesign.Substring(rdrU020A1.GetString("CLMHDR_CLAIM_ID"), 9, 2)));

            //strSQL.Append(SelectIf_F002_CLAIMS_MSTR(false));

            rdrF002_CLAIMS_MSTR_HDR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        private void Link_F002_CLAIMS_MSTR_DTL()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("KEY_CLM_TYPE, ");
            strSQL.Append("KEY_CLM_BATCH_NBR, ");
            strSQL.Append("KEY_CLM_CLAIM_NBR, ");
            strSQL.Append("CLMDTL_SV_YY, ");
            strSQL.Append("CLMDTL_SV_MM, ");
            strSQL.Append("CLMDTL_SV_DD ");
            strSQL.Append("FROM INDEXED.F002_CLAIMS_MSTR_DTL ");
            strSQL.Append("WHERE ");
            strSQL.Append("KEY_CLM_TYPE = '").Append("B'");
            strSQL.Append(" AND KEY_CLM_BATCH_NBR = ").Append(Common.StringToField(rdrF002_CLAIMS_MSTR_HDR.GetString("KEY_CLM_BATCH_NBR")));
            strSQL.Append(" AND KEY_CLM_CLAIM_NBR = ").Append(rdrF002_CLAIMS_MSTR_HDR.GetNumber("KEY_CLM_CLAIM_NBR"));

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

        private string SelectIf_U020A1(bool blnAddWhere)
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
        
            strSQL.Append(" (    BATCTRL_BATCH_TYPE =  \'C\' AND ");
            strSQL.Append("    MOH_FLAG =  \'Y\' AND ");
            strSQL.Append("    CLMHDR_MANUAL_REVIEW =  \'Y\')");
            return strSQL.ToString().ToString();
        }
    
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
       
            strSQL.Append("(CLMDTL_OMA_CD <> \'0000\' AND ");
            strSQL.Append(" CLMDTL_OMA_CD <>  \'ZZZZ\')");
            return strSQL.ToString().ToString();
        }

        #endregion

        #region " DEFINES "

        private string F002_CLAIMS_MSTR_CLMDTL_SV_DATE()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = (rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_SV_YY").ToString() 
                            + rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_SV_MM").ToString().PadLeft(2,'0') + rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_SV_DD").ToString().PadLeft(2,'0'));
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
                 AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U020A1.BATCTRL_DOC_NBR_OHIP", DataTypes.Numeric, 6);
                 AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U020A1.BATCTRL_AGENT_CD", DataTypes.Numeric, 1);
                 AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U020A1.BATCTRL_CLINIC_NBR", DataTypes.Character, 4);
                 AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U020A1.CLMHDR_CLAIM_ID", DataTypes.Character, 16);
                 AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U020A1.CLMHDR_BATCH_NBR", DataTypes.Character, 8);
                 AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U020A1.ICONST_CLINIC_NBR_1_2", DataTypes.Numeric, 2);
                 AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U020A1.CLMHDR_DOC_SPEC_CD", DataTypes.Numeric, 2);
                 AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U020A1.PAT_HEALTH_NBR", DataTypes.Numeric, 10);
                 AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U020A1.W_PAT_OHIP_MMYY", DataTypes.Character, 15);
                 AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U020A1.PAT_PROV_CD", DataTypes.Character, 2);
                 AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR_DTL.CLMDTL_SV_DATE", DataTypes.Character, 8);
                 AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U020A1.MOH_FLAG", DataTypes.Character, 1);
                 AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U020A1.DOLLAR_FLAG", DataTypes.Character, 1);
                 AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U020A1.TRANSLATED_GROUP_NBR", DataTypes.Character, 4);
                 AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U020A1.PAT_SURNAME", DataTypes.Character, 25);
                 AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U020A1.PAT_GIVEN_NAME", DataTypes.Character, 17);
                 AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U020A1.PAT_BIRTH_DATE", DataTypes.Numeric, 8);
                 AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U020A1.PAT_VERSION_CD", DataTypes.Character, 2);
                 AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U020A1.CLMHDR_LOC", DataTypes.Character, 4);
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
            switch (strControl)
            {
                case "TEMPORARYDATA.U020A1.BATCTRL_DOC_NBR_OHIP":
                    return rdrU020A1.GetNumber("BATCTRL_DOC_NBR_OHIP").ToString();

                case "TEMPORARYDATA.U020A1.BATCTRL_AGENT_CD":
                    return rdrU020A1.GetNumber("BATCTRL_AGENT_CD").ToString();

                case "TEMPORARYDATA.U020A1.BATCTRL_CLINIC_NBR":
                    return Common.StringToField(rdrU020A1.GetString("BATCTRL_CLINIC_NBR"));

                case "TEMPORARYDATA.U020A1.CLMHDR_CLAIM_ID":
                    return Common.StringToField(rdrU020A1.GetString("CLMHDR_CLAIM_ID"));

                case "TEMPORARYDATA.U020A1.CLMHDR_BATCH_NBR":
                    return Common.StringToField(rdrU020A1.GetString("CLMHDR_BATCH_NBR"));

                case "TEMPORARYDATA.U020A1.ICONST_CLINIC_NBR_1_2":
                    return rdrU020A1.GetNumber("ICONST_CLINIC_NBR_1_2").ToString();

                case "TEMPORARYDATA.U020A1.CLMHDR_DOC_SPEC_CD":
                    return rdrU020A1.GetNumber("CLMHDR_DOC_SPEC_CD").ToString();

                case "TEMPORARYDATA.U020A1.PAT_HEALTH_NBR":
                    return rdrU020A1.GetNumber("PAT_HEALTH_NBR").ToString();

                case "TEMPORARYDATA.U020A1.W_PAT_OHIP_MMYY":
                    return Common.StringToField(rdrU020A1.GetString("W_PAT_OHIP_MMYY"));

                case "TEMPORARYDATA.U020A1.PAT_PROV_CD":
                    return Common.StringToField(rdrU020A1.GetString("PAT_PROV_CD"));

                case "INDEXED.F002_CLAIMS_MSTR_DTL.CLMDTL_SV_DATE":
                    return Common.StringToField(F002_CLAIMS_MSTR_CLMDTL_SV_DATE(), intSize);

                case "TEMPORARYDATA.U020A1.MOH_FLAG":
                    return Common.StringToField(rdrU020A1.GetString("MOH_FLAG"));

                case "TEMPORARYDATA.U020A1.DOLLAR_FLAG":
                    return Common.StringToField(rdrU020A1.GetString("DOLLAR_FLAG"));

                case "TEMPORARYDATA.U020A1.TRANSLATED_GROUP_NBR":
                    return Common.StringToField(rdrU020A1.GetString("TRANSLATED_GROUP_NBR"));

                case "TEMPORARYDATA.U020A1.PAT_SURNAME":
                    return Common.StringToField(rdrU020A1.GetString("PAT_SURNAME"));

                case "TEMPORARYDATA.U020A1.PAT_GIVEN_NAME":
                    return Common.StringToField(rdrU020A1.GetString("PAT_GIVEN_NAME"));

                case "TEMPORARYDATA.U020A1.PAT_BIRTH_DATE":
                    return rdrU020A1.GetNumber("PAT_BIRTH_DATE").ToString();

                case "TEMPORARYDATA.U020A1.PAT_VERSION_CD":
                    return Common.StringToField(rdrU020A1.GetString("PAT_VERSION_CD"));

                case "TEMPORARYDATA.U020A1.CLMHDR_LOC":
                    return Common.StringToField(rdrU020A1.GetString("CLMHDR_LOC"));

                default:
                    return string.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                Access_U020A1();
                while (rdrU020A1.Read())
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
            
                rdrU020A1.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrU020A1 == null))
            {
                rdrU020A1.Close();
                rdrU020A1 = null;
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

        #endregion

        #endregion
    }
}
