#region "Screen Comments"

// set rep dev disc name diffdate_20160203

#endregion

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
    public class DIFFDATE : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "DIFFDATE";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrDIFF_SV_DATE_SEL = new Reader();

        #endregion

        #region " Renaissance Data "

        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                // Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;

                Sort = "";

                // Start report data processing.
                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return ReportData;
        }

        #endregion

        #region " Renaissance Statements "

        #region " ACCESS "

        private void Access_DIFF_SV_DATE_SEL()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("X_AMT_TECH_BILLED, ");
            strSQL.Append("X_SV_DATE, ");
            strSQL.Append("X_AMT_OHIP, ");
            strSQL.Append("X_AMT_OMA, ");
            strSQL.Append("KEY_CLM_TYPE, ");
            strSQL.Append("KEY_CLM_BATCH_NBR, ");
            strSQL.Append("KEY_CLM_CLAIM_NBR, ");
            strSQL.Append("CLMHDR_SERV_DATE, ");
            strSQL.Append("CLMHDR_AMT_TECH_BILLED, ");
            strSQL.Append("CLMHDR_TOT_CLAIM_AR_OHIP, ");
            strSQL.Append("CLMHDR_TOT_CLAIM_AR_OMA, ");
            strSQL.Append("CLMHDR_AGENT_CD ");
            strSQL.Append("FROM INDEXED.DIFF_SV_DATE_SEL ");

            strSQL.Append(Choose());

            rdrDIFF_SV_DATE_SEL.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

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

        #endregion

        #region " DEFINES "

        #endregion

        #region " CONTROLS "

        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.REPORT, "INDEXED.DIFF_SV_DATE_SEL.X_AMT_TECH_BILLED", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "INDEXED.DIFF_SV_DATE_SEL.X_SV_DATE", DataTypes.Numeric, 8);
                AddControl(ReportSection.REPORT, "INDEXED.DIFF_SV_DATE_SEL.X_AMT_OHIP", DataTypes.Numeric, 7);
                AddControl(ReportSection.REPORT, "INDEXED.DIFF_SV_DATE_SEL.X_AMT_OMA", DataTypes.Numeric, 7);
                AddControl(ReportSection.REPORT, "INDEXED.DIFF_SV_DATE_SEL.KEY_CLM_TYPE", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "INDEXED.DIFF_SV_DATE_SEL.KEY_CLM_BATCH_NBR", DataTypes.Character, 8);
                AddControl(ReportSection.REPORT, "INDEXED.DIFF_SV_DATE_SEL.KEY_CLM_CLAIM_NBR", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "INDEXED.DIFF_SV_DATE_SEL.CLMHDR_SERV_DATE", DataTypes.Numeric);
                AddControl(ReportSection.REPORT, "INDEXED.DIFF_SV_DATE_SEL.CLMHDR_AMT_TECH_BILLED", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "INDEXED.DIFF_SV_DATE_SEL.CLMHDR_TOT_CLAIM_AR_OHIP", DataTypes.Numeric, 7);
                AddControl(ReportSection.REPORT, "INDEXED.DIFF_SV_DATE_SEL.CLMHDR_TOT_CLAIM_AR_OMA", DataTypes.Numeric, 7);
                AddControl(ReportSection.REPORT, "INDEXED.DIFF_SV_DATE_SEL.CLMHDR_AGENT_CD", DataTypes.Numeric, 1);
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        #endregion

        #region " Renaissance Precompiler Generated Code "

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 10/10/2017 9:24:11 AM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "INDEXED.DIFF_SV_DATE_SEL.X_AMT_TECH_BILLED":
                    return rdrDIFF_SV_DATE_SEL.GetNumber("X_AMT_TECH_BILLED").ToString().PadLeft(6, ' ');

                case "INDEXED.DIFF_SV_DATE_SEL.X_SV_DATE":
                    return rdrDIFF_SV_DATE_SEL.GetNumber("X_SV_DATE").ToString().PadLeft(8, ' ');

                case "INDEXED.DIFF_SV_DATE_SEL.X_AMT_OHIP":
                    return rdrDIFF_SV_DATE_SEL.GetNumber("X_AMT_OHIP").ToString().PadLeft(7, ' ');

                case "INDEXED.DIFF_SV_DATE_SEL.X_AMT_OMA":
                    return rdrDIFF_SV_DATE_SEL.GetNumber("X_AMT_OMA").ToString().PadLeft(7, ' ');

                case "INDEXED.DIFF_SV_DATE_SEL.KEY_CLM_TYPE":
                    return Common.StringToField(rdrDIFF_SV_DATE_SEL.GetString("KEY_CLM_TYPE").PadRight(1, ' '));

                case "INDEXED.DIFF_SV_DATE_SEL.KEY_CLM_BATCH_NBR":
                    return Common.StringToField(rdrDIFF_SV_DATE_SEL.GetString("KEY_CLM_BATCH_NBR").PadRight(8, ' '));

                case "INDEXED.DIFF_SV_DATE_SEL.KEY_CLM_CLAIM_NBR":
                    return rdrDIFF_SV_DATE_SEL.GetNumber("KEY_CLM_CLAIM_NBR").ToString().PadLeft(2, ' ');

                case "INDEXED.DIFF_SV_DATE_SEL.CLMHDR_SERV_DATE":
                    return rdrDIFF_SV_DATE_SEL.GetNumber("CLMHDR_SERV_DATE").ToString();

                case "INDEXED.DIFF_SV_DATE_SEL.CLMHDR_AMT_TECH_BILLED":
                    return rdrDIFF_SV_DATE_SEL.GetNumber("CLMHDR_AMT_TECH_BILLED").ToString().PadLeft(6, ' ');

                case "INDEXED.DIFF_SV_DATE_SEL.CLMHDR_TOT_CLAIM_AR_OHIP":
                    return rdrDIFF_SV_DATE_SEL.GetNumber("CLMHDR_TOT_CLAIM_AR_OHIP").ToString().PadLeft(7, ' ');

                case "INDEXED.DIFF_SV_DATE_SEL.CLMHDR_TOT_CLAIM_AR_OMA":
                    return rdrDIFF_SV_DATE_SEL.GetNumber("CLMHDR_TOT_CLAIM_AR_OMA").ToString().PadLeft(7, ' ');

                case "INDEXED.DIFF_SV_DATE_SEL.CLMHDR_AGENT_CD":
                    return rdrDIFF_SV_DATE_SEL.GetNumber("CLMHDR_AGENT_CD").ToString().PadLeft(1, ' ');

                default:
                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_DIFF_SV_DATE_SEL();

                while (rdrDIFF_SV_DATE_SEL.Read())
                {
                    WriteData();
                }
                rdrDIFF_SV_DATE_SEL.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrDIFF_SV_DATE_SEL != null))
            {
                rdrDIFF_SV_DATE_SEL.Close();
                rdrDIFF_SV_DATE_SEL = null;
            }
        }


        #endregion

        #endregion
    }
}
