//  #> PROGRAM-ID.   r018.qzs     
//  ((C)) Dyad Infosys LTD
//  PROGRAM PURPOSE :
//  - generate the report for `M`iscellaneous payment by doctor by clinic.  This report can be run nightly
//  or user`s request for Helena
using Core.DataAccess.SqlServer;
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
    public class R018 : BaseRDLClass
    {
        protected const string REPORT_NAME = "R018";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrF001_BATCH_CONTROL_FILE = new Reader();
        private Reader rdrF002_CLAIMS_MSTR = new Reader();
        private Reader rdrF020_DOCTOR_MSTR = new Reader();
        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                //  Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;
                Sort = "DOC_NBR ASC, CLMHDR_CLAIM_ID ASC";
                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return ReportData;
        }
        private void Access_F001_BATCH_CONTROL_FILE()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("BATCTRL_BATCH_NBR, ");
            strSQL.Append("BATCTRL_BATCH_TYPE, ");
            strSQL.Append("BATCTRL_ADJ_CD, ");
            strSQL.Append("BATCTRL_BATCH_STATUS ");
            strSQL.Append("FROM INDEXED.F001_BATCH_CONTROL_FILE ");

            strSQL.Append(SelectIf_F001_BATCH_CONTROL_FILE(true));

            strSQL.Append(Choose());

            rdrF001_BATCH_CONTROL_FILE.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_F002_CLAIMS_MSTR() {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("KEY_CLM_TYPE, ");
            strSQL.Append("KEY_CLM_BATCH_NBR, ");
            strSQL.Append("CLMHDR_BATCH_NBR, ");
            strSQL.Append("CLMHDR_CLAIM_NBR, ");
            strSQL.Append("CLMHDR_ADJ_OMA_CD, ");
            strSQL.Append("CLMHDR_ADJ_OMA_SUFF, ");
            strSQL.Append("CLMHDR_ADJ_ADJ_NBR, ");
            strSQL.Append("KEY_CLM_SERV_CODE, ");
            strSQL.Append("CLMHDR_DATE_SYS, ");
            strSQL.Append("CLMHDR_MANUAL_AND_TAPE_PAYMENTS, ");
            strSQL.Append("CLMHDR_ORIG_BATCH_NBR, ");
            strSQL.Append("CLMHDR_ORIG_CLAIM_NBR ");
            strSQL.Append("FROM INDEXED.F002_CLAIMS_MSTR_HDR ");
            strSQL.Append("WHERE ");
            strSQL.Append("KEY_CLM_TYPE = ").Append("'B'");
            strSQL.Append(" AND KEY_CLM_BATCH_NBR = ").Append(Common.StringToField(rdrF001_BATCH_CONTROL_FILE.GetString("BATCTRL_BATCH_NBR")));

            strSQL.Append(SelectIf_F002_CLAIMS_MSTR(false));

            rdrF002_CLAIMS_MSTR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_F020_DOCTOR_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("DOC_DEPT ");
            strSQL.Append("FROM INDEXED.F020_DOCTOR_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_NBR = ").Append(Common.StringToField(QDesign.Substring(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_BATCH_NBR"), 3, 3)));

            rdrF020_DOCTOR_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
    
        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(string.Empty);

            return strChoose.ToString();
        }
    
        private string SelectIf_F001_BATCH_CONTROL_FILE(bool blnAddWhere)
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);
            if (blnAddWhere) {
                strSQL.Append(" WHERE ");
            }
            else
            {
                strSQL.Append(" AND ");
            }
        
            // TODO: SelectIf Statement - May require manual changes.
            strSQL.Append(" (    BATCTRL_BATCH_TYPE =  \'P\' AND ");
            strSQL.Append("    BATCTRL_ADJ_CD =  \'M\' AND ");
            strSQL.Append("    BATCTRL_BATCH_STATUS =  \'1\')");
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
        
            // TODO: SelectIf Statement - May require manual changes.
            strSQL.Append(" (    KEY_CLM_SERV_CODE =  \'00000\')");
            return strSQL.ToString();
        }

        private string F002_CLAIMS_MSTR_HDR_CLMHDR_CLAIM_ID()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = (rdrF002_CLAIMS_MSTR.GetString("CLMHDR_BATCH_NBR") + rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_CLAIM_NBR").ToString().PadLeft(2, '0') 
                    + rdrF002_CLAIMS_MSTR.GetString("CLMHDR_ADJ_OMA_CD") + rdrF002_CLAIMS_MSTR.GetString("CLMHDR_ADJ_OMA_SUFF")
                    + rdrF002_CLAIMS_MSTR.GetString("CLMHDR_ADJ_ADJ_NBR"));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string F002_CLAIMS_MSTR_HDR_CLMHDR_ORIG_BATCH_ID()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = (rdrF002_CLAIMS_MSTR.GetString("CLMHDR_ORIG_BATCH_NBR") + rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_ORIG_CLAIM_NBR").ToString().PadLeft(2, '0'));
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
                 AddControl(ReportSection.REPORT, "INDEXED.F020_DOCTOR_MSTR.DOC_NBR", DataTypes.Character, 3);
                 AddControl(ReportSection.REPORT, "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT", DataTypes.Numeric, 2);
                 AddControl(ReportSection.REPORT, "INDEXED.F002_CLAIMS_MSTR_HDR.CLMHDR_DATE_SYS", DataTypes.Character, 8);
                 AddControl(ReportSection.REPORT, "INDEXED.F002_CLAIMS_MSTR_HDR.CLMHDR_MANUAL_AND_TAPE_PAYMENTS", DataTypes.Numeric, 7);
                 AddControl(ReportSection.REPORT, "CLMHDR_ORIG_BATCH_ID", DataTypes.Character, 10);
                 AddControl(ReportSection.REPORT, "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_BATCH_STATUS", DataTypes.Character, 1);
                 AddControl(ReportSection.REPORT, "CLMHDR_CLAIM_ID", DataTypes.Character, 16);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
    
        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-07-20 11:56:54 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "INDEXED.F020_DOCTOR_MSTR.DOC_NBR":
                    return Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_NBR"));

                case "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT":
                    return rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT").ToString();

                case "INDEXED.F002_CLAIMS_MSTR_HDR.CLMHDR_DATE_SYS":
                    return Common.StringToField(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_DATE_SYS"));

                case "INDEXED.F002_CLAIMS_MSTR_HDR.CLMHDR_MANUAL_AND_TAPE_PAYMENTS":
                    return rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_MANUAL_AND_TAPE_PAYMENTS").ToString();

                case "CLMHDR_ORIG_BATCH_ID":
                    return Common.StringToField(F002_CLAIMS_MSTR_HDR_CLMHDR_ORIG_BATCH_ID().ToString());

                case "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_BATCH_STATUS":
                    return Common.StringToField(rdrF001_BATCH_CONTROL_FILE.GetString("BATCTRL_BATCH_STATUS"));

                case "CLMHDR_CLAIM_ID":
                    return Common.StringToField(F002_CLAIMS_MSTR_HDR_CLMHDR_CLAIM_ID().ToString());

                default:
                    return string.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                Access_F001_BATCH_CONTROL_FILE();
                while (rdrF001_BATCH_CONTROL_FILE.Read())
                {
                    Link_F002_CLAIMS_MSTR();
                    while (rdrF002_CLAIMS_MSTR.Read())
                    {
                        Link_F020_DOCTOR_MSTR();
                        while (rdrF020_DOCTOR_MSTR.Read())
                        {
                            WriteData();
                        }
                    
                        rdrF020_DOCTOR_MSTR.Close();
                    }
                
                    rdrF002_CLAIMS_MSTR.Close();
                }
            
                rdrF001_BATCH_CONTROL_FILE.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrF001_BATCH_CONTROL_FILE == null))
            {
                rdrF001_BATCH_CONTROL_FILE.Close();
                rdrF001_BATCH_CONTROL_FILE = null;
            }
        
            if (!(rdrF002_CLAIMS_MSTR == null))
            {
                rdrF002_CLAIMS_MSTR.Close();
                rdrF002_CLAIMS_MSTR = null;
            }
        
            if (!(rdrF020_DOCTOR_MSTR == null))
            {
                rdrF020_DOCTOR_MSTR.Close();
                rdrF020_DOCTOR_MSTR = null;
            }
        }
    }
}
