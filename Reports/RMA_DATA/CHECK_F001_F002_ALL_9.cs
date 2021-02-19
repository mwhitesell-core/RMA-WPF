//  2013/03/21 - MC2
//  ----------------------------------
//  access claim dtl to get amount for each claim    
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
    public class CHECK_F001_F002_ALL_9 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "CHECK_F001_F002_ALL_9";
        protected const bool REPORT_HAS_PARAMETERS = false;

        private Reader rdrF002_CLAIMS_MSTR_HDR = new Reader();
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
                //  Create Subfile.
                SubFile = true;
                SubFileName = "F002_CURR_PED";
                SubFileType = SubFileType.Keep;
                SubFileAT = "KEY_CLM_BATCH_NBR";
                Sort = "KEY_CLM_BATCH_NBR";
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

        private void Access_F002_CLAIMS_MSTR_HDR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("KEY_CLM_BATCH_NBR, ");
            strSQL.Append("KEY_CLM_CLAIM_NBR, ");
            strSQL.Append("CLMHDR_DATE_PERIOD_END, ");
            strSQL.Append("CLMHDR_TOT_CLAIM_AR_OHIP, ");
            strSQL.Append("CLMHDR_DATE_SYS, ");
            strSQL.Append("CLMHDR_BATCH_TYPE, ");
            strSQL.Append("CLMHDR_ADJ_CD_SUB_TYPE ");
            strSQL.Append("FROM INDEXED.F002_CLAIMS_MSTR_HDR ");

            strSQL.Append(Choose());

            rdrF002_CLAIMS_MSTR_HDR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_ICONST_MSTR_REC()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("ICONST_DATE_PERIOD_END_YY, ");
            strSQL.Append("ICONST_DATE_PERIOD_END_MM, ");
            strSQL.Append("ICONST_DATE_PERIOD_END_DD ");
            strSQL.Append("FROM INDEXED.ICONST_MSTR_REC ");
            strSQL.Append("WHERE ").Append("ICONST_CLINIC_NBR_1_2 = ").Append(QDesign.NConvert(QDesign.Substring(rdrF002_CLAIMS_MSTR_HDR.GetString("KEY_CLM_BATCH_NBR"), 1,2)));

            rdrICONST_MSTR_REC.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        #endregion

        #region " CHOOSE "

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(string.Empty);

            strChoose.Append(" WHERE KEY_CLM_TYPE = 'B' ");
            strChoose.Append("AND KEY_CLM_SERV_CODE = '00000'");

            return strChoose.ToString();
        }

        #endregion

        #region " SELECT IF "

        public override bool SelectIf()
        {
            bool blnSelected = false;

            if (QDesign.NULL(rdrF002_CLAIMS_MSTR_HDR.GetNumber("CLMHDR_DATE_PERIOD_END")) == QDesign.NULL(QDesign.NConvert(QDesign.ASCII(rdrICONST_MSTR_REC.GetNumber("ICONST_DATE_PERIOD_END_YY"), 4) + QDesign.ASCII(rdrICONST_MSTR_REC.GetNumber("ICONST_DATE_PERIOD_END_MM"), 2) + QDesign.ASCII(rdrICONST_MSTR_REC.GetNumber("ICONST_DATE_PERIOD_END_DD"), 2))))
            {
                blnSelected = true;
            }

            return blnSelected;
        }

        #region " DEFINES "

        private decimal X_CLAIM()
        {
            decimal decReturnValue = 0;

            try
            {
                decReturnValue = 1;
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        #endregion

        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR_HDR.KEY_CLM_BATCH_NBR", DataTypes.Character, 8);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR_HDR.KEY_CLM_CLAIM_NBR", DataTypes.Numeric, 2);
                AddControl(ReportSection.SUMMARY, "X_CLAIM", DataTypes.Numeric, 2, SummaryType.SUBTOTAL, "KEY_CLM_BATCH_NBR");
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR_HDR.CLMHDR_TOT_CLAIM_AR_OHIP", DataTypes.Numeric, 7, SummaryType.SUBTOTAL, "KEY_CLM_BATCH_NBR");
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR_HDR.CLMHDR_DATE_SYS", DataTypes.Character, 8);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR_HDR.CLMHDR_BATCH_TYPE", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR_HDR.CLMHDR_ADJ_CD_SUB_TYPE", DataTypes.Character, 1);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-05-09 7:36:49 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {

            switch (strControl)
            {
                case "INDEXED.F002_CLAIMS_MSTR_HDR.KEY_CLM_BATCH_NBR":
                    return Common.StringToField(rdrF002_CLAIMS_MSTR_HDR.GetString("KEY_CLM_BATCH_NBR"));
                case "INDEXED.F002_CLAIMS_MSTR_HDR.KEY_CLM_CLAIM_NBR":
                    return rdrF002_CLAIMS_MSTR_HDR.GetNumber("KEY_CLM_CLAIM_NBR").ToString();
                case "X_CLAIM":
                    return X_CLAIM().ToString();
                case "INDEXED.F002_CLAIMS_MSTR_HDR.CLMHDR_TOT_CLAIM_AR_OHIP":
                    return rdrF002_CLAIMS_MSTR_HDR.GetNumber("CLMHDR_TOT_CLAIM_AR_OHIP").ToString();
                case "INDEXED.F002_CLAIMS_MSTR_HDR.CLMHDR_DATE_SYS":
                    return Common.StringToField(rdrF002_CLAIMS_MSTR_HDR.GetString("CLMHDR_DATE_SYS"));
                case "INDEXED.F002_CLAIMS_MSTR_HDR.CLMHDR_BATCH_TYPE":
                    return Common.StringToField(rdrF002_CLAIMS_MSTR_HDR.GetString("CLMHDR_BATCH_TYPE"));
                case "INDEXED.F002_CLAIMS_MSTR_HDR.CLMHDR_ADJ_CD_SUB_TYPE":
                    return Common.StringToField(rdrF002_CLAIMS_MSTR_HDR.GetString("CLMHDR_ADJ_CD_SUB_TYPE"));
                default:
                    return String.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_F002_CLAIMS_MSTR_HDR();
                while (rdrF002_CLAIMS_MSTR_HDR.Read())
                {
                    Link_ICONST_MSTR_REC();
                    while (rdrICONST_MSTR_REC.Read())
                    {
                        WriteData();
                    }
                    rdrICONST_MSTR_REC.Close();
                }
                rdrF002_CLAIMS_MSTR_HDR.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if (!(rdrF002_CLAIMS_MSTR_HDR == null))
            {
                rdrF002_CLAIMS_MSTR_HDR.Close();
                rdrF002_CLAIMS_MSTR_HDR = null;
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
