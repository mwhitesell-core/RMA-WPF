//  PROGRAM-ID. R709A.QZS
//  PROGRAM PURPOSE: TO PRINT A REPORT TO SHOW THE MISSING INFORMATION OF
//  THE SUSPENDED CLAIMS DETAIL.
//  MODIFICATION HISTORY
//  DATE   SMS # WHO DESCRIPTION
//  90.09.29 000   Y.B. - ORIGINAL
//  93.07.21 142   M.C. - ADD MORE SELECTION CRITERIA
//  (IE. NBR-SERV, DIAG-CD, FEE-OMA,
//  FEE-OHIP)
//  1999/jan/28      B.E. - y2k 
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
    public class R709A : BaseRDLClass
    {
        protected const string REPORT_NAME = "R709A";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrF002_SUSPEND_DTL = new Reader();
        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                //  Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;
                Sort = "CLMDTL_DOC_OHIP_NBR ASC, CLMDTL_ACCOUNTING_NBR ASC";
                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return ReportData;
        }
        private void Access_F002_SUSPEND_DTL()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);
            strSQL.Append("SELECT ");
            strSQL.Append("ERROR_FLAG, ");
            strSQL.Append("CLMDTL_DOC_OHIP_NBR, ");
            strSQL.Append("CLMDTL_ACCOUNTING_NBR ");
            strSQL.Append("FROM INDEXED.F002_SUSPEND_DTL ");

            strSQL.Append(Choose());

            rdrF002_SUSPEND_DTL.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
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
            if (QDesign.NULL(X_ERROR_FLAG()) == 1) 
            {
                blnSelected = true;
            }
        
            return blnSelected;
        }
    
        private decimal X_ERROR_FLAG()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = rdrF002_SUSPEND_DTL.GetNumber("ERROR_FLAG");
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return decReturnValue;
        }
    
        public override void DeclareReportControls() {
            try
            {
                 AddControl(ReportSection.REPORT, "INDEXED.F002_SUSPEND_DTL.CLMDTL_DOC_OHIP_NBR", DataTypes.Numeric, 6);
                 AddControl(ReportSection.REPORT, "INDEXED.F002_SUSPEND_DTL.CLMDTL_ACCOUNTING_NBR", DataTypes.Character, 8);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
    
        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-05-15 3:04:05 PM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "INDEXED.F002_SUSPEND_DTL.CLMDTL_DOC_OHIP_NBR":
                    return rdrF002_SUSPEND_DTL.GetNumber("CLMDTL_DOC_OHIP_NBR").ToString();

                case "INDEXED.F002_SUSPEND_DTL.CLMDTL_ACCOUNTING_NBR":
                    return Common.StringToField(rdrF002_SUSPEND_DTL.GetString("CLMDTL_ACCOUNTING_NBR"));

                default:
                    return string.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                Access_F002_SUSPEND_DTL();
                while (rdrF002_SUSPEND_DTL.Read())
                {
                    WriteData();
                }
            
                rdrF002_SUSPEND_DTL.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrF002_SUSPEND_DTL == null))
            {
                rdrF002_SUSPEND_DTL.Close();
                rdrF002_SUSPEND_DTL = null;
            }
        }
    }
}
