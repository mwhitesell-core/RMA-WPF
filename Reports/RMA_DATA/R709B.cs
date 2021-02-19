//  PROGRAM-ID. R709B.QZS
//  PROGRAM PURPOSE: TO PRINT A REPORT TO SHOW THE MISSING INFORMATION OF
//  THE SUSPENDED CLAIMS HEADER.
//  MODIFICATION HISTORY
//  DATE     SMS #  WHO   DESCRIPTION
//  90.09.19  000    Y.B.  - ORIGINAL
//  1999/jan/28        B.E.  - y2k 
//  1999/May/27       S.B.  - Added the use file
//  def_clmhdr_status.def to 
//  prevent hardcoding of clmhdr-status.
//  2014/Apr/01 MC1 - include the check of clinic nbr 00
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
    public class R709B : BaseRDLClass
    {
        protected const string REPORT_NAME = "R709B";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrF002_SUSPEND_HDR = new Reader();
        // #CORE_BEGIN_INCLUDE: DEF_CLMHDR_STATUS"
        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-05-15 3:04:05 PM
        private string CLMHDR_STATUS_COMPLETE()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = "C";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return strReturnValue;
        }
    
        private string CLMHDR_STATUS_DELETE()
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
    
        private string CLMHDR_STATUS_CANCEL()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = "Y";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return strReturnValue;
        }
    
        private string CLMHDR_STATUS_RESUBMIT()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = "R";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return strReturnValue;
        }
    
        private string CLMHDR_STATUS_ERROR()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = "X";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return strReturnValue;
        }
    
        private string CLMHDR_STATUS_NOT_COMPLETE()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = "N";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return strReturnValue;
        }
    
        private string CLMHDR_STATUS_DEFAULT()
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
    
        private string UPDATED()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = "U";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return strReturnValue;
        }
    
        private string CLMHDR_STATUS_IGNOR()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = "I";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return strReturnValue;
        }
    
        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                //  Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;
                Sort = "CLMHDR_DOC_NBR_OHIP ASC, CLMHDR_ACCOUNTING_NBR ASC";
                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return ReportData;
        }
        private void Access_F002_SUSPEND_HDR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);
            strSQL.Append("SELECT ");
            strSQL.Append("ERROR_FLAG, ");
            strSQL.Append("CLMHDR_DOC_NBR_OHIP, ");
            strSQL.Append("CLMHDR_ACCOUNTING_NBR ");
            strSQL.Append("FROM INDEXED.F002_SUSPEND_HDR ");

            strSQL.Append(Choose());

            rdrF002_SUSPEND_HDR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
    
        private string Choose() {
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
                decReturnValue = rdrF002_SUSPEND_HDR.GetNumber("ERROR_FLAG");
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        public override void DeclareReportControls()
        {
            try
            {
                 AddControl(ReportSection.REPORT, "INDEXED.F002_SUSPEND_HDR.CLMHDR_DOC_NBR_OHIP", DataTypes.Numeric, 6);
                 AddControl(ReportSection.REPORT, "INDEXED.F002_SUSPEND_HDR.CLMHDR_ACCOUNTING_NBR", DataTypes.Character, 8);
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
                case "INDEXED.F002_SUSPEND_HDR.CLMHDR_DOC_NBR_OHIP":
                    return rdrF002_SUSPEND_HDR.GetNumber("CLMHDR_DOC_NBR_OHIP").ToString();

                case "INDEXED.F002_SUSPEND_HDR.CLMHDR_ACCOUNTING_NBR":
                    return Common.StringToField(rdrF002_SUSPEND_HDR.GetString("CLMHDR_ACCOUNTING_NBR"));

                default:
                    return string.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                Access_F002_SUSPEND_HDR();
                while (rdrF002_SUSPEND_HDR.Read())
                {
                    WriteData();
                }
            
                rdrF002_SUSPEND_HDR.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrF002_SUSPEND_HDR == null))
            {
                rdrF002_SUSPEND_HDR.Close();
                rdrF002_SUSPEND_HDR = null;
            }
        }
    }
}
