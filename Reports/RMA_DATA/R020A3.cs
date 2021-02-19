//  !  link ( B  ,(nconvert(clmhdr-claim-id[1:9])),  &
//  (nconvert(clmhdr-claim-id[10:2])),  ZZZZ0 ) &
//  to key-clm-type, key-clm-batch-nbr, key-clm-claim-nbr, &
//  key-clm-serv-code     &
//  !             (nconvert(clmhdr-claim-id[10:2])))  &
//  2008/04/21 - MC - use doc-nbr to link to f020 file
//  link batctrl-doc-nbr-ohip                                     &
//  to doc-ohip-nbr of f020-doctor-mstr opt
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
    public class R020A3 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R020A3";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrU020A2 = new Reader();
        private Reader rdrF002_CLAIMS_MSTR_DESC = new Reader();
        private Reader rdrF020_DOCTOR_MSTR = new Reader();

        #endregion

        #region " Renaissance Data "

        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug) {
            try
            {
                //  Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;
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

        private void Access_U020A2()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("CLMHDR_CLAIM_ID, ");
            strSQL.Append("CLMHDR_BATCH_NBR, ");
            strSQL.Append("CLMHDR_CLAIM_NBR, ");
            strSQL.Append("PAT_HEALTH_NBR, ");
            strSQL.Append("W_PAT_OHIP_MMYY, ");
            strSQL.Append("BATCTRL_AGENT_CD, ");
            strSQL.Append("PAT_SURNAME, ");
            strSQL.Append("PAT_GIVEN_NAME, ");
            strSQL.Append("TRANSLATED_GROUP_NBR, ");
            strSQL.Append("BATCTRL_DOC_NBR_OHIP, ");
            strSQL.Append("CLMHDR_DOC_SPEC_CD, ");
            strSQL.Append("PAT_PROV_CD, ");
            strSQL.Append("CLMDTL_SV_DATE ");
            strSQL.Append("FROM TEMPORARYDATA.U020A2 ");

            strSQL.Append(Choose());

            rdrU020A2.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
            strSQL = null;
        }
        private void Link_F002_CLAIMS_MSTR_DESC()
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
            strSQL.Append("KEY_CLM_TYPE = ").Append("'B'");
            strSQL.Append(" AND KEY_CLM_BATCH_NBR = ").Append(Common.StringToField(rdrU020A2.GetString("CLMHDR_BATCH_NBR")));
            strSQL.Append(" AND KEY_CLM_CLAIM_NBR = ").Append(rdrU020A2.GetNumber("CLMHDR_CLAIM_NBR"));

            rdrF002_CLAIMS_MSTR_DESC.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        private void Link_F020_DOCTOR_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("DOC_NAME ");
            strSQL.Append("FROM INDEXED.F020_DOCTOR_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_NBR = ").Append(Common.StringToField(QDesign.Substring(rdrU020A2.GetString("CLMHDR_CLAIM_ID"), 3, 3)));

            rdrF020_DOCTOR_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
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
                if ((QDesign.NULL(rdrU020A2.GetNumber("PAT_HEALTH_NBR")) != QDesign.NULL(0d)))
                {
                    strReturnValue = QDesign.ASCII(rdrU020A2.GetNumber("PAT_HEALTH_NBR"), 10);
                }
                else
                {
                    strReturnValue = rdrU020A2.GetString("W_PAT_OHIP_MMYY");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return strReturnValue;
        }
    
        private string W_CLMHDR_CLAIM_ID()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = QDesign.Substring(rdrU020A2.GetString("CLMHDR_CLAIM_ID"), 3, 8);
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
                if ((QDesign.NULL(rdrU020A2.GetNumber("BATCTRL_AGENT_CD")) == QDesign.NULL(2d)))
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
    
        private string PATIENT_NAME()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = (rdrU020A2.GetString("PAT_SURNAME").TrimEnd() + (", " + rdrU020A2.GetString("PAT_GIVEN_NAME").TrimEnd()));
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
                 AddControl(ReportSection.HEADING_AT, "INDEXED.F020_DOCTOR_MSTR.DOC_NAME", DataTypes.Character, 24);
                 AddControl(ReportSection.HEADING_AT, "W_HEALTH_NBR", DataTypes.Character, 12);
                 AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U020A2.TRANSLATED_GROUP_NBR", DataTypes.Character, 4);
                 AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U020A2.BATCTRL_DOC_NBR_OHIP", DataTypes.Numeric, 6);
                 AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U020A2.CLMHDR_DOC_SPEC_CD", DataTypes.Numeric, 2);
                 AddControl(ReportSection.HEADING_AT, "W_CLMHDR_CLAIM_ID", DataTypes.Character, 8);
                 AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U020A2.PAT_PROV_CD", DataTypes.Character, 2);
                 AddControl(ReportSection.HEADING_AT, "W_WCB", DataTypes.Character, 1);
                 AddControl(ReportSection.HEADING_AT, "PATIENT_NAME", DataTypes.Character, 30);
                 AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U020A2.CLMDTL_SV_DATE", DataTypes.Character, 8);
                 AddControl(ReportSection.REPORT, "W_CLMDTL_DESC", DataTypes.Character, 22);
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.U020A2.CLMHDR_CLAIM_ID", DataTypes.Character, 16);
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
                case "INDEXED.F020_DOCTOR_MSTR.DOC_NAME":
                    return Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_NAME"));

                case "W_HEALTH_NBR":
                    return Common.StringToField(W_HEALTH_NBR(), intSize);

                case "TEMPORARYDATA.U020A2.TRANSLATED_GROUP_NBR":
                    return Common.StringToField(rdrU020A2.GetString("TRANSLATED_GROUP_NBR"));

                case "TEMPORARYDATA.U020A2.BATCTRL_DOC_NBR_OHIP":
                    return rdrU020A2.GetNumber("BATCTRL_DOC_NBR_OHIP").ToString();

                case "TEMPORARYDATA.U020A2.CLMHDR_DOC_SPEC_CD":
                    return rdrU020A2.GetNumber("CLMHDR_DOC_SPEC_CD").ToString();

                case "W_CLMHDR_CLAIM_ID":
                    return Common.StringToField(W_CLMHDR_CLAIM_ID(), intSize);

                case "TEMPORARYDATA.U020A2.PAT_PROV_CD":
                    return Common.StringToField(rdrU020A2.GetString("PAT_PROV_CD"));

                case "W_WCB":
                    return Common.StringToField(W_WCB(), intSize);

                case "PATIENT_NAME":
                    return Common.StringToField(PATIENT_NAME(), intSize);

                case "TEMPORARYDATA.U020A2.CLMDTL_SV_DATE":
                    return Common.StringToField(rdrU020A2.GetString("CLMDTL_SV_DATE"));

                case "W_CLMDTL_DESC":
                    return Common.StringToField(W_CLMDTL_DESC(), intSize);

                case "TEMPORARYDATA.U020A2.CLMHDR_CLAIM_ID":
                    return Common.StringToField(rdrU020A2.GetString("CLMHDR_CLAIM_ID"));

                default:
                    return string.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                Access_U020A2();
                while (rdrU020A2.Read())
                {
                    Link_F002_CLAIMS_MSTR_DESC();
                    while (rdrF002_CLAIMS_MSTR_DESC.Read())
                    {
                        Link_F020_DOCTOR_MSTR();
                        while (rdrF020_DOCTOR_MSTR.Read())
                        {
                            WriteData();
                        }

                            rdrF020_DOCTOR_MSTR.Close();
                    }
                
                    rdrF002_CLAIMS_MSTR_DESC.Close();
                }
            
                rdrU020A2.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrU020A2 == null))
            {
                rdrU020A2.Close();
                rdrU020A2 = null;
            }
        
            if (!(rdrF002_CLAIMS_MSTR_DESC == null))
            {
                rdrF002_CLAIMS_MSTR_DESC.Close();
                rdrF002_CLAIMS_MSTR_DESC = null;
            }

            if (!(rdrF020_DOCTOR_MSTR == null))
            {
                rdrF020_DOCTOR_MSTR.Close();
                rdrF020_DOCTOR_MSTR = null;
            }
        }

        #endregion

        #endregion
    }
}
