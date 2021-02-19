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
    public class R020A2 : BaseRDLClass
	{
		#region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "
		
        protected const string REPORT_NAME = "R020A2";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrU020A1 = new Reader();
        private Reader rdrF002_CLAIMS_MSTR_HDR = new Reader();
        private Reader rdrF002_CLAIMS_MSTR_DTL = new Reader();
        private Reader rdrR020A2 = new Reader();
		
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
                SubFileName = "U020A2";
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
            strSQL.Append("CLMHDR_CLAIM_NBR, ");
            strSQL.Append("CLMHDR_BATCH_NBR, ");
            strSQL.Append("BATCTRL_BATCH_TYPE, ");
            strSQL.Append("MOH_FLAG, ");
            strSQL.Append("CLMHDR_MANUAL_REVIEW, ");
            strSQL.Append("PAT_MESS_CODE, ");
            strSQL.Append("TRANSLATED_GROUP_NBR, ");
            strSQL.Append("BATCTRL_DOC_NBR_OHIP, ");
            strSQL.Append("BATCTRL_AGENT_CD, ");
            strSQL.Append("BATCTRL_CLINIC_NBR, ");
            strSQL.Append("CLMHDR_DOC_SPEC_CD, ");
            strSQL.Append("PAT_HEALTH_NBR, ");
            strSQL.Append("PAT_SURNAME_FIRST3, ");
            strSQL.Append("PAT_SURNAME_LAST22, ");
            strSQL.Append("PAT_GIVEN_NAME_FIRST1, ");
            strSQL.Append("FILLER3, ");
            strSQL.Append("W_PAT_OHIP_MMYY, ");
            strSQL.Append("PAT_PROV_CD, ");
            strSQL.Append("ICONST_CLINIC_NBR_1_2 ");
            strSQL.Append("FROM TEMPORARYDATA.U020A1 ");
			
            strSQL.Append(SelectIf_U020A1(true));
			
            strSQL.Append(Choose());
			
            rdrU020A1.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
            strSQL = null;
        }

        private void Link_F002_CLAIMS_MSTR_DTL()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("CLMDTL_SV_YY, ");
            strSQL.Append("CLMDTL_SV_MM, ");
            strSQL.Append("CLMDTL_SV_DD ");
            strSQL.Append("FROM INDEXED.F002_CLAIMS_MSTR_DTL ");
            strSQL.Append("WHERE ");
            strSQL.Append("KEY_CLM_TYPE = ").Append("'B'");
            strSQL.Append(" AND KEY_CLM_BATCH_NBR = ").Append(Common.StringToField(rdrU020A1.GetString("CLMHDR_BATCH_NBR")));
            strSQL.Append(" AND KEY_CLM_CLAIM_NBR = ").Append(rdrU020A1.GetNumber("CLMHDR_CLAIM_NBR"));

            strSQL.Append(SelectIf_F002_CLAIMS_MSTR(false));

            rdrF002_CLAIMS_MSTR_DTL.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
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

            strSQL.Append(" (    BATCTRL_BATCH_TYPE =  'C' AND ");
            strSQL.Append("    MOH_FLAG =  'Y' AND ");
            strSQL.Append("    CLMHDR_MANUAL_REVIEW =  'Y' AND ");
            strSQL.Append("    PAT_MESS_CODE =  ' ')");
            return strSQL.ToString();
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

            strSQL.Append("CLMDTL_OMA_CD <> '0000' AND ");
            strSQL.Append("CLMDTL_OMA_CD <> 'ZZZZ'");
            return strSQL.ToString();
        }
		
		#endregion

        #region " DEFINES "
    
        private string F002_CLAIMS_MSTR_CLMDTL_SV_DATE()
		{
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = QDesign.ASCII(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_SV_YY"), 4) + QDesign.ASCII(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_SV_MM"), 2) + QDesign.ASCII(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_SV_DD"), 2);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return strReturnValue;
        }

        private string CLMHDR_CLAIM_ID()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = rdrU020A1.GetString("CLMHDR_BATCH_NBR") + rdrU020A1.GetNumber("CLMHDR_CLAIM_NBR").ToString().PadLeft(2, '0') + rdrU020A1.GetString("CLMHDR_ADJ_OMA_CD")
                    + rdrU020A1.GetString("CLMHDR_ADJ_OMA_SUFF") + rdrU020A1.GetString("CLMHDR_ADJ_ADJ_NBR");
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
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = rdrU020A1.GetString("PAT_SURNAME_FIRST3") + rdrU020A1.GetString("PAT_SURNAME_LAST22");
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
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = rdrU020A1.GetString("PAT_GIVEN_NAME_FIRST1") + rdrU020A1.GetString("FILLER3");
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
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U020A1.CLMHDR_CLAIM_NBR", DataTypes.Numeric, 2);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U020A1.CLMHDR_ADJ_OMA_CD", DataTypes.Character, 4);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U020A1.CLMHDR_ADJ_OMA_SUFF", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U020A1.CLMHDR_ADJ_ADJ_NBR", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U020A1.TRANSLATED_GROUP_NBR", DataTypes.Character, 4);
				AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U020A1.CLMHDR_DOC_SPEC_CD", DataTypes.Numeric, 2);
				AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U020A1.PAT_HEALTH_NBR", DataTypes.Numeric, 10);
				AddControl(ReportSection.SUMMARY, "PAT_SURNAME", DataTypes.Character, 25);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U020A1.PAT_SURNAME_FIRST3", DataTypes.Character, 3);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U020A1.PAT_SURNAME_LAST22", DataTypes.Character, 22);
                AddControl(ReportSection.SUMMARY, "PAT_GIVEN_NAME", DataTypes.Character, 17);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U020A1.PAT_GIVEN_NAME_FIRST1", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U020A1.FILLER3", DataTypes.Character, 16);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U020A1.W_PAT_OHIP_MMYY", DataTypes.Character, 15);
			    AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U020A1.PAT_PROV_CD", DataTypes.Character, 2);
				AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U020A1.ICONST_CLINIC_NBR_1_2", DataTypes.Numeric, 2);
				AddControl(ReportSection.SUMMARY, "CLMDTL_SV_DATE", DataTypes.Character, 8);
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
        // # Do not delete, modify or move it.  Updated: 2018-05-11 6:02:42 AM
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
                    return Common.StringToField(CLMHDR_CLAIM_ID());

                case "TEMPORARYDATA.U020A1.CLMHDR_BATCH_NBR":
                    return Common.StringToField(rdrU020A1.GetString("CLMHDR_BATCH_NBR"));

                case "TEMPORARYDATA.U020A1.CLMHDR_CLAIM_NBR":
                    return rdrU020A1.GetNumber("CLMHDR_CLAIM_NBR").ToString();

                case "TEMPORARYDATA.U020A1.CLMHDR_ADJ_OMA_CD":
                    return Common.StringToField(rdrU020A1.GetString("CLMHDR_ADJ_OMA_CD"));

                case "TEMPORARYDATA.U020A1.CLMHDR_ADJ_OMA_SUFF":
                    return Common.StringToField(rdrU020A1.GetString("CLMHDR_ADJ_OMA_SUFF"));

                case "TEMPORARYDATA.U020A1.CLMHDR_ADJ_ADJ_NBR":
                    return Common.StringToField(rdrU020A1.GetString("CLMHDR_ADJ_ADJ_NBR"));

                case "TEMPORARYDATA.U020A1.TRANSLATED_GROUP_NBR":
                    return Common.StringToField(rdrU020A1.GetString("TRANSLATED_GROUP_NBR"));

                case "TEMPORARYDATA.U020A1.CLMHDR_DOC_SPEC_CD":
                    return rdrU020A1.GetNumber("CLMHDR_DOC_SPEC_CD").ToString();

                case "TEMPORARYDATA.U020A1.PAT_HEALTH_NBR":
                    return rdrU020A1.GetNumber("PAT_HEALTH_NBR").ToString();

                case "PAT_SURNAME":
                    return Common.StringToField(PAT_SURNAME());

                case "TEMPORARYDATA.U020A1.PAT_SURNAME_FIRST3":
                    return Common.StringToField(rdrU020A1.GetString("PAT_SURNAME_FIRST3"));

                case "TEMPORARYDATA.U020A1.PAT_SURNAME_LAST22":
                    return Common.StringToField(rdrU020A1.GetString("PAT_SURNAME_LAST22"));

                case "PAT_GIVEN_NAME":
                    return Common.StringToField(PAT_GIVEN_NAME());

                case "TEMPORARYDATA.U020A1.PAT_GIVEN_NAME_FIRST1":
                    return Common.StringToField(rdrU020A1.GetString("PAT_GIVEN_NAME_FIRST1"));

                case "TEMPORARYDATA.U020A1.FILLER3":
                    return Common.StringToField(rdrU020A1.GetString("FILLER3"));

                case "TEMPORARYDATA.U020A1.W_PAT_OHIP_MMYY":
                    return Common.StringToField(rdrU020A1.GetString("W_PAT_OHIP_MMYY"));

                case "TEMPORARYDATA.U020A1.PAT_PROV_CD":
                    return Common.StringToField(rdrU020A1.GetString("PAT_PROV_CD"));

                case "TEMPORARYDATA.U020A1.ICONST_CLINIC_NBR_1_2":
                    return rdrU020A1.GetNumber("ICONST_CLINIC_NBR_1_2").ToString();

                case "CLMDTL_SV_DATE":
                    return Common.StringToField(F002_CLAIMS_MSTR_CLMDTL_SV_DATE(), intSize);

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
                    Link_F002_CLAIMS_MSTR_DTL();
                    while (rdrF002_CLAIMS_MSTR_DTL.Read())
                    {
                        WriteData();
                    }

                    rdrF002_CLAIMS_MSTR_DTL.Close();
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
