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
    public class SUSPEND_DTL2 : BaseRDLClass
    {
        protected const string REPORT_NAME = "SUSPEND_DTL2";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrSUSPDTL = new Reader();
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

        private void Access_SUSPDTL()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("CLMHDR_CLINIC_NBR_1_2, ");
            strSQL.Append("X_SVC, ");
            strSQL.Append("X_CLM, ");
            strSQL.Append("X_AMT ");
            strSQL.Append("FROM TEMPORARYDATA.SUSPDTL ");

            strSQL.Append(Choose());

            rdrSUSPDTL.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);

            strSQL = null;
        }

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(String.Empty);

            return strChoose.ToString().ToString();
        }

        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.SUSPDTL.CLMHDR_CLINIC_NBR_1_2", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.SUSPDTL.X_SVC", DataTypes.Numeric, 5);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.SUSPDTL.X_CLM", DataTypes.Numeric, 5);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.SUSPDTL.X_AMT", DataTypes.Numeric, 10);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2019-04-15 3:47:44 PM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "TEMPORARYDATA.SUSPDTL.CLMHDR_CLINIC_NBR_1_2":
                    return rdrSUSPDTL.GetNumber("CLMHDR_CLINIC_NBR_1_2").ToString();

                case "TEMPORARYDATA.SUSPDTL.X_SVC":
                    return rdrSUSPDTL.GetNumber("X_SVC").ToString();

                case "TEMPORARYDATA.SUSPDTL.X_CLM":
                    return rdrSUSPDTL.GetNumber("X_CLM").ToString();

                case "TEMPORARYDATA.SUSPDTL.X_AMT":
                    return rdrSUSPDTL.GetNumber("X_AMT").ToString();

                default:
                    return String.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_SUSPDTL();
                while (rdrSUSPDTL.Read())
                {
                    WriteData();
                }
                rdrSUSPDTL.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if (!(rdrSUSPDTL == null))
            {
                rdrSUSPDTL.Close();
                rdrSUSPDTL = null;
            }
        }
    }
}

