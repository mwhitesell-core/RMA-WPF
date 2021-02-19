//  suspend_status.qzs
//  purpose: count status  I ignore and  D delete for Linda and Renee
//  DATE:          WHO:            MODIFICATION
//  2003/07/03     yasemin         original
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
    public class SUSPEND_STATUS : BaseRDLClass
    {
        protected const string REPORT_NAME = "SUSPEND_STATUS";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrF002_SUSPEND_HDR = new Reader();
        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                //  Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;
                Sort = "X_STATUS ASC";
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
            StringBuilder strSQL = new StringBuilder(String.Empty);
            strSQL.Append("SELECT ");
            strSQL.Append("CLMHDR_STATUS ");
            strSQL.Append("FROM INDEXED.F002_SUSPEND_HDR ");
            strSQL.Append(Choose());
            rdrF002_SUSPEND_HDR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(String.Empty);
            // TODO: CHOOSE Statement - May require manual changes.
            return strChoose.ToString().ToString();
        }

        public override bool SelectIf()
        {
            bool blnSelected = false;
            if (((QDesign.NULL(rdrF002_SUSPEND_HDR.GetString("CLMHDR_STATUS")) == "D")
                        || ((QDesign.NULL(rdrF002_SUSPEND_HDR.GetString("CLMHDR_STATUS")) == "I")
                        || (QDesign.NULL(rdrF002_SUSPEND_HDR.GetString("CLMHDR_STATUS")) == "R"))))
            {
                blnSelected = true;
            }

            return blnSelected;
        }

        private string X_STATUS()
        {
            string strReturnValue = String.Empty;
            try
            {
                if ((QDesign.NULL(rdrF002_SUSPEND_HDR.GetString("CLMHDR_STATUS")) == "D"))
                {
                    strReturnValue = "D";
                }
                else if ((QDesign.NULL(rdrF002_SUSPEND_HDR.GetString("CLMHDR_STATUS")) == "I"))
                {
                    strReturnValue = "I";
                }
                else if ((QDesign.NULL(rdrF002_SUSPEND_HDR.GetString("CLMHDR_STATUS")) == "R"))
                {
                    strReturnValue = "R";
                }
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
                AddControl(ReportSection.FOOTING_AT, "X_STATUS", DataTypes.Character, 1);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-05-16 12:45:41 PM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            // TODO: Remove duplicate controls, if there are any.
            switch (strControl)
            {
                case "X_STATUS":
                    return Common.StringToField(X_STATUS(), intSize);
                default:
                    return String.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                // TODO: Some manual steps maybe required.
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
