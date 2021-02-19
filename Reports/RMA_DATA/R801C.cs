//  NAME   : R801C.QZS
//  PURPOSE: LIST OF ALL AUTOMATIC ADJUSTED CLAIMS WITH AGENT `0`, `2`,
//  AND `4`, `6` AND `9` SORT BY CLINIC TOTALS.
//  MODIFICATION HISTORY:
//  YY/MMM/DD     BY WHOM        WHY
//  93/SEP/07     YASEMIN        ORIGINAL (SMS 143)
//  1999/May/19   S.B.  Y2K checked.
//  2004/jan/05   b.e.  - alpha doctor nbr
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
    public class R801C : BaseRDLClass
    {
        protected const string REPORT_NAME = "R801C";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrADJ_CLAIM_FILE = new Reader();
        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                //  Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;
                Sort = "CLINIC_NBR ASC, ADJ_AGENT_CD ASC, CLM_ID ASC";
                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return ReportData;
        }
        private void Access_ADJ_CLAIM_FILE()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT DISTINCT ");
            strSQL.Append("ADJ_BATCH_NBR, ");
            strSQL.Append("ADJ_CLAIM_NBR, ");
            strSQL.Append("ADJ_AGENT_CD, ");
            strSQL.Append("ADJ_AMT_BAL ");
            strSQL.Append("FROM SEQUENTIAL.ADJ_CLAIM_FILE ");

            strSQL.Append(Choose());

            rdrADJ_CLAIM_FILE.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
    
        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(string.Empty);

            return strChoose.ToString();
        }
    
        public override bool SelectIf()
        {
            bool blnSelected = false;
            if (((QDesign.NULL(rdrADJ_CLAIM_FILE.GetNumber("ADJ_AGENT_CD")) == QDesign.NULL(0d)) 
                        || ((QDesign.NULL(rdrADJ_CLAIM_FILE.GetNumber("ADJ_AGENT_CD")) == QDesign.NULL(2d)) 
                        || ((QDesign.NULL(rdrADJ_CLAIM_FILE.GetNumber("ADJ_AGENT_CD")) == QDesign.NULL(4d)) 
                        || ((QDesign.NULL(rdrADJ_CLAIM_FILE.GetNumber("ADJ_AGENT_CD")) == QDesign.NULL(6d)) 
                        || ((QDesign.NULL(rdrADJ_CLAIM_FILE.GetNumber("ADJ_AGENT_CD")) == QDesign.NULL(9d)) 
                        || (QDesign.NULL(rdrADJ_CLAIM_FILE.GetNumber("ADJ_AGENT_CD")) == QDesign.NULL(8d))))))))
            {
                blnSelected = true;
            }
        
            return blnSelected;
        }
    
        private string CLM_ID()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = (rdrADJ_CLAIM_FILE.GetString("ADJ_BATCH_NBR") + QDesign.ASCII(rdrADJ_CLAIM_FILE.GetNumber("ADJ_CLAIM_NBR"), 2));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return strReturnValue;
        }
    
        private string CLINIC_NBR()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = QDesign.Substring(rdrADJ_CLAIM_FILE.GetString("ADJ_BATCH_NBR"), 1, 2);
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
                 AddControl(ReportSection.FOOTING_AT, "CLINIC_NBR", DataTypes.Character, 2);
                 AddControl(ReportSection.FOOTING_AT, "SEQUENTIAL.ADJ_CLAIM_FILE.ADJ_AMT_BAL", DataTypes.Numeric, 7);
                 AddControl(ReportSection.REPORT, "SEQUENTIAL.ADJ_CLAIM_FILE.ADJ_AGENT_CD", DataTypes.Character, 1);
                 AddControl(ReportSection.REPORT, "CLM_ID", DataTypes.Character, 10);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
    
        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-05-16 9:44:54 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "CLINIC_NBR":
                    return Common.StringToField(CLINIC_NBR(), intSize);

                case "SEQUENTIAL.ADJ_CLAIM_FILE.ADJ_AMT_BAL":
                    return rdrADJ_CLAIM_FILE.GetNumber("ADJ_AMT_BAL").ToString();

                case "SEQUENTIAL.ADJ_CLAIM_FILE.ADJ_AGENT_CD":
                    return Common.StringToField(rdrADJ_CLAIM_FILE.GetString("ADJ_AGENT_CD"));

                case "CLM_ID":
                    return Common.StringToField(CLM_ID(), intSize);

                default:
                    return string.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                Access_ADJ_CLAIM_FILE();
                while (rdrADJ_CLAIM_FILE.Read())
                {
                    WriteData();
                }
            
                rdrADJ_CLAIM_FILE.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrADJ_CLAIM_FILE == null))
            {
                rdrADJ_CLAIM_FILE.Close();
                rdrADJ_CLAIM_FILE = null;
            }
        }
    }
}
