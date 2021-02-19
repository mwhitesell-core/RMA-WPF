//  set page length 63 width 132
//  set noclose
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
    public class R020E5 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R020E5";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrU020A1 = new Reader();
        private Reader rdrF002_CLAIMS_MSTR = new Reader();
        private Reader rdrICONST_MSTR_REC = new Reader();

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
                Sort = "ICONST_CLINIC_NBR_1_2 ASC, BATCTRL_BATCH_NBR ASC, CLMHDR_CLAIM_ID ASC";
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
            strSQL.Append("BATCTRL_BATCH_NBR, ");
            strSQL.Append("CLMHDR_CLAIM_NBR, ");
            strSQL.Append("ICONST_CLINIC_NBR_1_2, ");
            strSQL.Append("BATCTRL_BATCH_TYPE, ");
            strSQL.Append("MOH_FLAG, ");
            strSQL.Append("PAT_MESS_CODE, ");
            strSQL.Append("CLMHDR_CLAIM_ID, ");
            strSQL.Append("PAT_HEALTH_NBR, ");
            strSQL.Append("PAT_PROV_CD, ");
            strSQL.Append("ICONST_CLINIC_CYCLE_NBR, ");
            strSQL.Append("ICONST_DATE_PERIOD_END, ");
            strSQL.Append("CLMHDR_DOC_DEPT, ");
            strSQL.Append("CLMHDR_TOT_CLAIM_AR_OHIP ");
            strSQL.Append("FROM TEMPORARYDATA.U020A1 ");

            strSQL.Append(SelectIf_U020A1(true));
            strSQL.Append(Choose());

            rdrU020A1.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
            strSQL = null;
        }
        private void Link_F002_CLAIMS_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("KEY_CLM_TYPE, ");
            strSQL.Append("KEY_CLM_BATCH_NBR, ");
            strSQL.Append("KEY_CLM_CLAIM_NBR, ");
            strSQL.Append("CLMDTL_OMA_CD ");
            strSQL.Append("FROM INDEXED.F002_CLAIMS_MSTR_DTL ");
            strSQL.Append("WHERE ");
            strSQL.Append("KEY_CLM_TYPE = ").Append("'B'");
            strSQL.Append(" AND KEY_CLM_BATCH_NBR = ").Append(Common.StringToField(rdrU020A1.GetString("BATCTRL_BATCH_NBR")));
            strSQL.Append(" AND KEY_CLM_CLAIM_NBR = ").Append(rdrU020A1.GetNumber("CLMHDR_CLAIM_NBR"));

            strSQL.Append(SelectIf_F002_CLAIMS_MSTR(false));

            rdrF002_CLAIMS_MSTR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_ICONST_MSTR_REC()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("ICONST_CLINIC_NAME ");
            strSQL.Append("FROM INDEXED.ICONST_MSTR_REC ");
            strSQL.Append("WHERE ");
            strSQL.Append("ICONST_CLINIC_NBR_1_2 = ").Append(rdrU020A1.GetNumber("ICONST_CLINIC_NBR_1_2"));

            rdrICONST_MSTR_REC.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
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

            strSQL.Append(" (    CLMDTL_OMA_CD <>  '0000' AND ");
            strSQL.Append("    CLMDTL_OMA_CD <>  'ZZZZ')");
            return strSQL.ToString();
        }

        #endregion

        #region " DEFINES "

        private decimal W_ADDRESS_CNT()
        {
            decimal decReturnValue = 0;
            try
            {
                if (((QDesign.NULL(rdrU020A1.GetNumber("PAT_HEALTH_NBR")) == QDesign.NULL(0d)) 
                            && (QDesign.NULL(rdrU020A1.GetString("PAT_PROV_CD")) == "ON")))
                {
                    decReturnValue = 1;
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return decReturnValue;
        }
    
        private string W_BATCH_NBR()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = QDesign.Substring(rdrU020A1.GetString("CLMHDR_BATCH_NBR"), 3, 6);
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
                strReturnValue = rdrU020A1.GetString("CLMHDR_BATCH_NBR") 
                    + QDesign.ASCII(rdrU020A1.GetNumber("CLMHDR_BATCH_NBR"), 2).ToString()
                    + QDesign.ASCII(rdrU020A1.GetString("CLMHDR_ADJ_OMA_CD"), 4) 
                    + rdrU020A1.GetString("CLMHDR_ADJ_OMA_SUFF") 
                    + rdrU020A1.GetString("CLMHDR_ADJ_ADJ_NBR");
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private decimal CLMHDR_TOT_CLAIM_AR_OHIP_SUBTOTAL = 0;
        private decimal BATCTRL_BATCH_NBR_COUNT_NBR = 0;
        private decimal SEQUENCE_NBR_VALUE = 0;

        private decimal PREV_CLMHDR_CLAIM_NBR = 0;
        private string PREV_CLMHDR_BATCH_NBR = string.Empty;

        #endregion

        #region " CONTROLS "

        public override void DeclareReportControls()
        {
            try
            {
                 AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.U020A1.ICONST_CLINIC_NBR_1_2", DataTypes.Numeric, 2);
                 AddControl(ReportSection.PAGE_HEADING, "INDEXED.ICONST_MSTR_REC.ICONST_CLINIC_NAME", DataTypes.Character, 20);
                 AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.U020A1.ICONST_CLINIC_CYCLE_NBR", DataTypes.Numeric, 2);
                 AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.U020A1.ICONST_DATE_PERIOD_END", DataTypes.Numeric, 8);
                 AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.U020A1.CLMHDR_DOC_DEPT", DataTypes.Numeric, 2);
                 AddControl(ReportSection.FOOTING_AT, "W_BATCH_NBR", DataTypes.Character, 6);
                 AddControl(ReportSection.FOOTING_AT, "W_ADDRESS_CNT", DataTypes.Numeric, 6);
                 AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.U020A1.CLMHDR_TOT_CLAIM_AR_OHIP", DataTypes.Numeric, 9);
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.U020A1.BATCTRL_BATCH_NBR", DataTypes.Character, 8);
                 AddControl(ReportSection.REPORT, "CLMHDR_CLAIM_ID", DataTypes.Character, 16);
                AddControl(ReportSection.REPORT, "CLMHDR_TOT_CLAIM_AR_OHIP_SUBTOTAL", DataTypes.Numeric, 9);
                AddControl(ReportSection.REPORT, "BATCTRL_BATCH_NBR_COUNT", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "SEQUENCE_NBR", DataTypes.Numeric, 5);
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
        // # Do not delete, modify or move it.  Updated: 2018-05-11 6:02:29 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "TEMPORARYDATA.U020A1.ICONST_CLINIC_NBR_1_2":
                    return rdrU020A1.GetNumber("ICONST_CLINIC_NBR_1_2").ToString();

                case "INDEXED.ICONST_MSTR_REC.ICONST_CLINIC_NAME":
                    return Common.StringToField(rdrICONST_MSTR_REC.GetString("ICONST_CLINIC_NAME"));

                case "TEMPORARYDATA.U020A1.ICONST_CLINIC_CYCLE_NBR":
                    return rdrU020A1.GetNumber("ICONST_CLINIC_CYCLE_NBR").ToString();

                case "TEMPORARYDATA.U020A1.ICONST_DATE_PERIOD_END":
                    return rdrU020A1.GetNumber("ICONST_DATE_PERIOD_END").ToString();

                case "TEMPORARYDATA.U020A1.CLMHDR_DOC_DEPT":
                    return rdrU020A1.GetNumber("CLMHDR_DOC_DEPT").ToString();

                case "W_BATCH_NBR":
                    return Common.StringToField(W_BATCH_NBR(), intSize);

                case "W_ADDRESS_CNT":
                    return W_ADDRESS_CNT().ToString();

                case "TEMPORARYDATA.U020A1.CLMHDR_TOT_CLAIM_AR_OHIP":
                    return rdrU020A1.GetNumber("CLMHDR_TOT_CLAIM_AR_OHIP").ToString();

                case "TEMPORARYDATA.U020A1.BATCTRL_BATCH_NBR":
                    return Common.StringToField(rdrU020A1.GetString("BATCTRL_BATCH_NBR"));

                case "CLMHDR_CLAIM_ID":
                    return Common.StringToField(CLMHDR_CLAIM_ID());

                case "CLMHDR_TOT_CLAIM_AR_OHIP_SUBTOTAL":
                    return CLMHDR_TOT_CLAIM_AR_OHIP_SUBTOTAL.ToString();

                case "BATCTRL_BATCH_NBR_COUNT":
                    return BATCTRL_BATCH_NBR_COUNT_NBR.ToString();

                case "SEQUENCE_NBR":
                    return SEQUENCE_NBR_VALUE.ToString();

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
                    Link_F002_CLAIMS_MSTR();
                    while (rdrF002_CLAIMS_MSTR.Read())
                    {
                        //Set the frist occurance of the records with the same claim id to have the CLMHDR_TOT_CLAIM_AR_OHIP value and the BATCTRL_BATCH_NBR_COUNT_NBR = 1
                        // because only the hdr value os needed for the subtotals in the report and not all of the detail records
                        //Add a sequence number to all the records because rdl cannot calculate a sequential count of the records written to the report
                        if (PREV_CLMHDR_BATCH_NBR == string.Empty)
                        {
                            BATCTRL_BATCH_NBR_COUNT_NBR = 1;
                            CLMHDR_TOT_CLAIM_AR_OHIP_SUBTOTAL = rdrU020A1.GetNumber("CLMHDR_TOT_CLAIM_AR_OHIP");

                            SEQUENCE_NBR_VALUE++;
                            SetPreviousValues();
                        }
                        else if (PREV_CLMHDR_BATCH_NBR != rdrU020A1.GetString("CLMHDR_BATCH_NBR"))
                        {
                            BATCTRL_BATCH_NBR_COUNT_NBR = 1;
                            CLMHDR_TOT_CLAIM_AR_OHIP_SUBTOTAL = rdrU020A1.GetNumber("CLMHDR_TOT_CLAIM_AR_OHIP");

                            SEQUENCE_NBR_VALUE++;
                            SetPreviousValues();
                        }
                        else
                        {
                            if (PREV_CLMHDR_CLAIM_NBR != rdrU020A1.GetNumber("CLMHDR_CLAIM_NBR"))
                            {
                                BATCTRL_BATCH_NBR_COUNT_NBR = 1;
                                CLMHDR_TOT_CLAIM_AR_OHIP_SUBTOTAL = rdrU020A1.GetNumber("CLMHDR_TOT_CLAIM_AR_OHIP");
                            }
                            else
                            {
                                BATCTRL_BATCH_NBR_COUNT_NBR = 0;
                                CLMHDR_TOT_CLAIM_AR_OHIP_SUBTOTAL = 0;
                            }

                            SetPreviousValues();
                        }

                        Link_ICONST_MSTR_REC();
                        while (rdrICONST_MSTR_REC.Read())
                        {
                            WriteData();
                        }
                    
                        rdrICONST_MSTR_REC.Close();
                    }
                
                    rdrF002_CLAIMS_MSTR.Close();
                }
            
                rdrU020A1.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        private void SetPreviousValues()
        {
            PREV_CLMHDR_BATCH_NBR = rdrU020A1.GetString("CLMHDR_BATCH_NBR");
            PREV_CLMHDR_CLAIM_NBR = rdrU020A1.GetNumber("CLMHDR_CLAIM_NBR");
        }

        public override void CloseReaders()
        {
            if (!(rdrU020A1 == null))
            {
                rdrU020A1.Close();
                rdrU020A1 = null;
            }
        
            if (!(rdrF002_CLAIMS_MSTR == null))
            {
                rdrF002_CLAIMS_MSTR.Close();
                rdrF002_CLAIMS_MSTR = null;
            }
        
            if (!(rdrICONST_MSTR_REC == null))
            {
                rdrICONST_MSTR_REC.Close();
                rdrICONST_MSTR_REC = null;
            }
        }

        #endregion

        #endregion
    }
}
