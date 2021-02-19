//  DOC: PROXY.qzs
//  DOC: CREATE MAILING RMA ADDRESS LABELS
//  DOC: RUN FOR: TAMMY
//  PROGRAM PURPOSE : MAILING RETURN ADDRESS LABELS
//  DATE       WHO       DESCRIPTION
//  95/11/08   YASEMIN   ORIGINAL
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
    public class PROXY : BaseRDLClass
    {
        protected const string REPORT_NAME = "PROXY";
        protected const bool REPORT_HAS_PARAMETERS = false;
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
        private void Access_F020_DOCTOR_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);
            strSQL.Append("SELECT TOP 300 * ");
            strSQL.Append("FROM INDEXED.F020_DOCTOR_MSTR ");

            strSQL.Append(Choose());

            rdrF020_DOCTOR_MSTR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
    
        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(string.Empty);

            return strChoose.ToString().ToString();
        }
        public override void DeclareReportControls()
        {
                try
                {
                }

                catch (Exception ex)
                {
                    //  Write the exception to the log file.
                    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
                }
         }

            // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
            // # Do not delete, modify or move it.  Updated: 2018-07-30 10:52:24 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
                return "";
        }
        public override void AccessData()
        {
            try
            {
                Access_F020_DOCTOR_MSTR();
                while (rdrF020_DOCTOR_MSTR.Read())
                {
                    WriteData();
                }
            
                rdrF020_DOCTOR_MSTR.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrF020_DOCTOR_MSTR == null))
            {
                rdrF020_DOCTOR_MSTR.Close();
                rdrF020_DOCTOR_MSTR = null;
            }
        }
    }
}
