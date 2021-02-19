//  #> program-id.     r022a7.qzs
//  ((C)) Dyad Technologies
//  PROGRAM PURPOSE : SELECT CLAIMS FOR RE-SUBMIT
//  IF CHANGES REQUIRED FOR HOSPITAL CODES, MAKE
//  SURE TO CHANGE IN HOSPITAL_CODE.DEF
//  MODIFICATION HISTORY
//  DATE   WHO          DESCRIPTION
//  00/sep/18 B.E.        - moved from r022a.qzs into separate source module
//  03/nov/13 M.C. - modify to extract claim description records into
//  the subfile r022a7_desc_reject
//  03/dec/12 A.A. - alpha doctor nbr
//  05/dec/05 M.C. - include patient name in r022a7_desc_reject subfile
//  !  link ( B  ,(nconvert(clmhdr-claim-id[1:9])),  &
//  !             (nconvert(clmhdr-claim-id[10:2])))  &
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
    public class R022A7 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R022A7";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrU022A4 = new Reader();
        private Reader rdrF002_CLAIMS_MSTR_DESC = new Reader();
        private Reader rdrR022A7_DESC_REJECT = new Reader();

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
                SubFileName = "R022A7_DESC_REJECT";
                SubFileType = SubFileType.Keep;
                SubFileAT = "";
                Sort = "";
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

        private void Access_U022A4()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("CLMHDR_CLAIM_ID, ");
            strSQL.Append("PAT_HEALTH_NBR, ");
            strSQL.Append("W_PAT_OHIP_MMYY, ");
            strSQL.Append("BATCTRL_AGENT_CD, ");
            strSQL.Append("TRANSLATED_GROUP_NBR, ");
            strSQL.Append("BATCTRL_DOC_NBR_OHIP, ");
            strSQL.Append("CLMHDR_DOC_SPEC_CD, ");
            strSQL.Append("PAT_PROV_CD, ");
            strSQL.Append("CLMDTL_SV_DATE, ");
            strSQL.Append("PAT_SURNAME, ");
            strSQL.Append("PAT_GIVEN_NAME, ");
            strSQL.Append("PAT_BIRTH_DATE, ");
            strSQL.Append("PAT_VERSION_CD, ");
            strSQL.Append("CLMHDR_LOC ");
            strSQL.Append("FROM TEMPORARYDATA.U022A4 ");

            strSQL.Append(Choose());

            rdrU022A4.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
            strSQL = null;
        }
        private void Link_F002_CLAIMS_MSTR_HDR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("KEY_CLM_TYPE, ");
            strSQL.Append("KEY_CLM_BATCH_NBR, ");
            strSQL.Append("KEY_CLM_CLAIM_NBR, ");
            strSQL.Append("KEY_CLM_SERV_CODE, ");
            strSQL.Append("CLMDTL_OMA_CD, ");
            strSQL.Append("CLMDTL_DESC ");
            strSQL.Append("FROM INDEXED.F002_CLAIMS_MSTR_DESC ");
            strSQL.Append("WHERE ");
            strSQL.Append("KEY_CLM_TYPE = '").Append("B'");
            strSQL.Append(" AND KEY_CLM_BATCH_NBR = '").Append(QDesign.Substring(rdrU022A4.GetString("CLMHDR_CLAIM_ID"), 1, 8)).Append("'");
            strSQL.Append(" AND KEY_CLM_CLAIM_NBR = ").Append(QDesign.NConvert(QDesign.Substring(rdrU022A4.GetString("CLMHDR_CLAIM_ID"), 9, 2)));

            rdrF002_CLAIMS_MSTR_DESC.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
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
            if ((QDesign.NULL(QDesign.Substring(rdrF002_CLAIMS_MSTR_DESC.GetString("KEY_CLM_SERV_CODE"), 1, 4)) == "ZZZZ"))
            {
                blnSelected = true;
            }
        
            return blnSelected;
        }

        #endregion

        #region " DEFINES "

        private string W_HEALTH_NBR()
        {
            string strReturnValue = string.Empty;
            try
            {
                if ((QDesign.NULL(rdrU022A4.GetNumber("PAT_HEALTH_NBR")) != QDesign.NULL(0d)))
                {
                    strReturnValue = QDesign.ASCII(rdrU022A4.GetNumber("PAT_HEALTH_NBR"), 10);
                }
                else
                {
                    strReturnValue = rdrU022A4.GetString("W_PAT_OHIP_MMYY");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return strReturnValue;
        }
    
        private string W_WCB()
        {
            string strReturnValue = string.Empty;
            try
            {
                if ((QDesign.NULL(rdrU022A4.GetNumber("BATCTRL_AGENT_CD")) == QDesign.NULL(2d)))
                {
                    strReturnValue = "Y";
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return strReturnValue;
        }
    
        private string W_CLMDTL_DESC()
        {
            string strReturnValue = string.Empty;
            try
            {
                if ((QDesign.NULL(rdrF002_CLAIMS_MSTR_DESC.GetString("CLMDTL_OMA_CD")) == "ZZZZ"))
                {
                    strReturnValue = rdrF002_CLAIMS_MSTR_DESC.GetString("CLMDTL_DESC");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return strReturnValue;
        }
    
        private string W_TYPE()
        {
            string strReturnValue = string.Empty;
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
    
        private string EDT_OMA_SERVICE_CD_AND_SUFFIX()
        {
            string strReturnValue = string.Empty;
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
    
        private decimal EDT_SERVICE_DATE()
        {
            decimal decReturnValue = 0;
                try { }
            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return decReturnValue;
        }
    
        private decimal EDT_NBR_SERV()
        {
            decimal decReturnValue = 0;
                try { }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return decReturnValue;
        }
    
        private decimal EDT_AMOUNT_SUBMITTED()
        {
            decimal decReturnValue = 0;
                try { }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return decReturnValue;
        }
    
        private string EDT_DTL_DIAG_CD()
        {
            string strReturnValue = string.Empty;
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
    
        private string EDT_DTL_ERR_CD_1()
        {
            string strReturnValue = string.Empty;
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
    
        private string EDT_DTL_ERR_CD_2()
        {
            string strReturnValue = string.Empty;
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
    
        private string EDT_DTL_ERR_CD_3()
        {
            string strReturnValue = string.Empty;
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
    
        private string EDT_DTL_ERR_CD_4()
        {
            string strReturnValue = string.Empty;
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
    
        private string EDT_DTL_ERR_CD_5()
        {
            string strReturnValue = string.Empty;
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
    
        private decimal EDT_PROCESS_DATE()
        {
            decimal decReturnValue = 0;
            try { }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return decReturnValue;
        }

        #endregion

        #region " CONTROLS "

        public override void DeclareReportControls()
        {
            try
            {
                 AddControl(ReportSection.SUMMARY, "W_HEALTH_NBR", DataTypes.Character, 12);
                 AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A4.TRANSLATED_GROUP_NBR", DataTypes.Character, 4);
                 AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A4.BATCTRL_DOC_NBR_OHIP", DataTypes.Numeric, 6);
                 AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A4.CLMHDR_DOC_SPEC_CD", DataTypes.Numeric, 2);
                 AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A4.CLMHDR_CLAIM_ID", DataTypes.Character, 16);
                 AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A4.PAT_PROV_CD", DataTypes.Character, 2);
                 AddControl(ReportSection.SUMMARY, "W_WCB", DataTypes.Character, 1);
                 AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A4.CLMDTL_SV_DATE", DataTypes.Character, 8);
                 AddControl(ReportSection.SUMMARY, "W_CLMDTL_DESC", DataTypes.Character, 22);
                 AddControl(ReportSection.SUMMARY, "W_TYPE", DataTypes.Character, 1);
                 AddControl(ReportSection.SUMMARY, "EDT_OMA_SERVICE_CD_AND_SUFFIX", DataTypes.Character, 5);
                 AddControl(ReportSection.SUMMARY, "EDT_SERVICE_DATE", DataTypes.Numeric, 8);
                 AddControl(ReportSection.SUMMARY, "EDT_NBR_SERV", DataTypes.Numeric, 2);
                 AddControl(ReportSection.SUMMARY, "EDT_AMOUNT_SUBMITTED", DataTypes.Numeric, 6);
                 AddControl(ReportSection.SUMMARY, "EDT_DTL_DIAG_CD", DataTypes.Character, 4);
                 AddControl(ReportSection.SUMMARY, "EDT_DTL_ERR_CD_1", DataTypes.Character, 3);
                 AddControl(ReportSection.SUMMARY, "EDT_DTL_ERR_CD_2", DataTypes.Character, 3);
                 AddControl(ReportSection.SUMMARY, "EDT_DTL_ERR_CD_3", DataTypes.Character, 3);
                 AddControl(ReportSection.SUMMARY, "EDT_DTL_ERR_CD_4", DataTypes.Character, 3);
                 AddControl(ReportSection.SUMMARY, "EDT_DTL_ERR_CD_5", DataTypes.Character, 3);
                 AddControl(ReportSection.SUMMARY, "EDT_PROCESS_DATE", DataTypes.Numeric, 8);
                 AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A4.PAT_SURNAME", DataTypes.Character, 25);
                 AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A4.PAT_GIVEN_NAME", DataTypes.Character, 17);
                 AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A4.PAT_BIRTH_DATE", DataTypes.Numeric, 8);
                 AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A4.PAT_VERSION_CD", DataTypes.Character, 2);
                 AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U022A4.CLMHDR_LOC", DataTypes.Character, 4);
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
        // # Do not delete, modify or move it.  Updated: 2018-05-11 6:02:20 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "W_HEALTH_NBR":
                    return Common.StringToField(W_HEALTH_NBR(), intSize);

                case "TEMPORARYDATA.U022A4.TRANSLATED_GROUP_NBR":
                    return Common.StringToField(rdrU022A4.GetString("TRANSLATED_GROUP_NBR"));

                case "TEMPORARYDATA.U022A4.BATCTRL_DOC_NBR_OHIP":
                    return rdrU022A4.GetNumber("BATCTRL_DOC_NBR_OHIP").ToString();

                case "TEMPORARYDATA.U022A4.CLMHDR_DOC_SPEC_CD":
                    return rdrU022A4.GetNumber("CLMHDR_DOC_SPEC_CD").ToString();

                case "TEMPORARYDATA.U022A4.CLMHDR_CLAIM_ID":
                    return Common.StringToField(rdrU022A4.GetString("CLMHDR_CLAIM_ID"));

                case "TEMPORARYDATA.U022A4.PAT_PROV_CD":
                    return Common.StringToField(rdrU022A4.GetString("PAT_PROV_CD"));

                case "W_WCB":
                    return Common.StringToField(W_WCB(), intSize);

                case "TEMPORARYDATA.U022A4.CLMDTL_SV_DATE":
                    return Common.StringToField(rdrU022A4.GetString("CLMDTL_SV_DATE"));

                case "W_CLMDTL_DESC":
                    return Common.StringToField(W_CLMDTL_DESC(), intSize);

                case "W_TYPE":
                    return Common.StringToField(W_TYPE(), intSize);

                case "EDT_OMA_SERVICE_CD_AND_SUFFIX":
                    return Common.StringToField(EDT_OMA_SERVICE_CD_AND_SUFFIX(), intSize);

                case "EDT_SERVICE_DATE":
                    return EDT_SERVICE_DATE().ToString();

                case "EDT_NBR_SERV":
                    return EDT_NBR_SERV().ToString();

                case "EDT_AMOUNT_SUBMITTED":
                    return EDT_AMOUNT_SUBMITTED().ToString();

                case "EDT_DTL_DIAG_CD":
                    return Common.StringToField(EDT_DTL_DIAG_CD(), intSize);

                case "EDT_DTL_ERR_CD_1":
                    return Common.StringToField(EDT_DTL_ERR_CD_1(), intSize);

                case "EDT_DTL_ERR_CD_2":
                    return Common.StringToField(EDT_DTL_ERR_CD_2(), intSize);

                case "EDT_DTL_ERR_CD_3":
                    return Common.StringToField(EDT_DTL_ERR_CD_3(), intSize);

                case "EDT_DTL_ERR_CD_4":
                    return Common.StringToField(EDT_DTL_ERR_CD_4(), intSize);

                case "EDT_DTL_ERR_CD_5":
                    return Common.StringToField(EDT_DTL_ERR_CD_5(), intSize);

                case "EDT_PROCESS_DATE":
                    return EDT_PROCESS_DATE().ToString();

                case "TEMPORARYDATA.U022A4.PAT_SURNAME":
                    return Common.StringToField(rdrU022A4.GetString("PAT_SURNAME"));

                case "TEMPORARYDATA.U022A4.PAT_GIVEN_NAME":
                    return Common.StringToField(rdrU022A4.GetString("PAT_GIVEN_NAME"));

                case "TEMPORARYDATA.U022A4.PAT_BIRTH_DATE":
                    return rdrU022A4.GetNumber("PAT_BIRTH_DATE").ToString();

                case "TEMPORARYDATA.U022A4.PAT_VERSION_CD":
                    return Common.StringToField(rdrU022A4.GetString("PAT_VERSION_CD"));

                case "TEMPORARYDATA.U022A4.CLMHDR_LOC":
                    return Common.StringToField(rdrU022A4.GetString("CLMHDR_LOC"));

                default:
                    return string.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                Access_U022A4();
                while (rdrU022A4.Read())
                {
                    Link_F002_CLAIMS_MSTR_HDR();
                    while (rdrF002_CLAIMS_MSTR_DESC.Read())
                    {
                        WriteData();
                    }
                
                    rdrF002_CLAIMS_MSTR_DESC.Close();
                }
            
                rdrU022A4.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrU022A4 == null))
            {
                rdrU022A4.Close();
                rdrU022A4 = null;
            }
        
            if (!(rdrF002_CLAIMS_MSTR_DESC == null))
            {
                rdrF002_CLAIMS_MSTR_DESC.Close();
                rdrF002_CLAIMS_MSTR_DESC = null;
            }

        }

        #endregion

        #endregion
    }
}
