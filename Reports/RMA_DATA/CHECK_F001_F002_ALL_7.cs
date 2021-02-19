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
    public class CHECK_F001_F002_ALL_7 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "CHECK_F001_F002_ALL_7";
        protected const bool REPORT_HAS_PARAMETERS = false;

        private Reader rdrF001_BATCH_CONTROL_FILE = new Reader();
        private Reader rdrF002_CLAIMS_MSTR_HDR = new Reader();

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
                SubFileName = "ORPHANED_BATCHES";
                SubFileType = SubFileType.Keep;
                SubFileAT = "";
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

        #endregion

        #region " Renaissance Statements "

        #region " ACCESS "

        private void Access_F001_BATCH_CONTROL_FILE()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("BATCTRL_BATCH_TYPE, ");
            strSQL.Append("BATCTRL_ADJ_CD, ");
            strSQL.Append("BATCTRL_BATCH_NBR, ");
            strSQL.Append("BATCTRL_BATCH_STATUS, ");
            strSQL.Append("BATCTRL_DATE_BATCH_ENTERED, ");
            strSQL.Append("BATCTRL_NBR_CLAIMS_IN_BATCH, ");
            strSQL.Append("BATCTRL_AMT_ACT, ");
            strSQL.Append("BATCTRL_AMT_EST, ");
            strSQL.Append("BATCTRL_CALC_TOT_REV, ");
            strSQL.Append("BATCTRL_MANUAL_PAY_TOT ");
            strSQL.Append("FROM INDEXED.F001_BATCH_CONTROL_FILE ");

            strSQL.Append(Choose());
            strSQL.Append(F001_BATCH_CONTROL_FILE_SelectIf(true));

            rdrF001_BATCH_CONTROL_FILE.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_F002_CLAIMS_MSTR_HDR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("CLMHDR_BATCH_NBR ");
            strSQL.Append("FROM INDEXED.F002_CLAIMS_MSTR_HDR ");
            strSQL.Append("WHERE ");
            strSQL.Append("KEY_CLM_TYPE = '").Append("B").Append("' ");
            strSQL.Append("AND KEY_CLM_BATCH_NBR = ").Append(Common.StringToField(rdrF001_BATCH_CONTROL_FILE.GetString("BATCTRL_BATCH_NBR")));

            rdrF002_CLAIMS_MSTR_HDR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
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

        private string F001_BATCH_CONTROL_FILE_SelectIf(bool addWhere) 
        {
            string value = string.Empty;

            if (addWhere)
            {
                value = " WHERE ";
            }
            else
            {
                value = " AND ";
            }

            value += "BATCTRL_BATCH_STATUS < '2' ";

            return value;
        }

        public override bool SelectIf()
        {
            bool blnSelected = false;

            if (!ReportDataFunctions.Exists(rdrF002_CLAIMS_MSTR_HDR))
            {
                blnSelected = true;
            }

            return blnSelected;
        }

        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.SUMMARY, "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_BATCH_TYPE", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_ADJ_CD", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_BATCH_NBR", DataTypes.Character, 8);
                AddControl(ReportSection.SUMMARY, "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_BATCH_STATUS", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_DATE_BATCH_ENTERED", DataTypes.Character, 8);
                AddControl(ReportSection.SUMMARY, "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_NBR_CLAIMS_IN_BATCH", DataTypes.Numeric, 2);
                AddControl(ReportSection.SUMMARY, "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_AMT_ACT", DataTypes.Numeric, 9);
                AddControl(ReportSection.SUMMARY, "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_AMT_EST", DataTypes.Numeric, 9);
                AddControl(ReportSection.SUMMARY, "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_CALC_TOT_REV", DataTypes.Numeric, 9);
                AddControl(ReportSection.SUMMARY, "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_MANUAL_PAY_TOT", DataTypes.Numeric, 9);
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
                case "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_BATCH_TYPE":
                    return Common.StringToField(rdrF001_BATCH_CONTROL_FILE.GetString("BATCTRL_BATCH_TYPE"));
                case "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_ADJ_CD":
                    return Common.StringToField(rdrF001_BATCH_CONTROL_FILE.GetString("BATCTRL_ADJ_CD"));
                case "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_BATCH_NBR":
                    return Common.StringToField(rdrF001_BATCH_CONTROL_FILE.GetString("BATCTRL_BATCH_NBR"));
                case "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_BATCH_STATUS":
                    return Common.StringToField(rdrF001_BATCH_CONTROL_FILE.GetString("BATCTRL_BATCH_STATUS"));
                case "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_DATE_BATCH_ENTERED":
                    return Common.StringToField(rdrF001_BATCH_CONTROL_FILE.GetString("BATCTRL_DATE_BATCH_ENTERED"));
                case "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_NBR_CLAIMS_IN_BATCH":
                    return rdrF001_BATCH_CONTROL_FILE.GetNumber("BATCTRL_NBR_CLAIMS_IN_BATCH").ToString();
                case "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_AMT_ACT":
                    return rdrF001_BATCH_CONTROL_FILE.GetNumber("BATCTRL_AMT_ACT").ToString();
                case "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_AMT_EST":
                    return rdrF001_BATCH_CONTROL_FILE.GetNumber("BATCTRL_AMT_EST").ToString();
                case "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_CALC_TOT_REV":
                    return rdrF001_BATCH_CONTROL_FILE.GetNumber("BATCTRL_CALC_TOT_REV").ToString();
                case "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_MANUAL_PAY_TOT":
                    return rdrF001_BATCH_CONTROL_FILE.GetNumber("BATCTRL_MANUAL_PAY_TOT").ToString();
                default:
                    return String.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_F001_BATCH_CONTROL_FILE();
                while (rdrF001_BATCH_CONTROL_FILE.Read())
                {
                    Link_F002_CLAIMS_MSTR_HDR();
                    while (rdrF002_CLAIMS_MSTR_HDR.Read())
                    {
                        WriteData();
                    }
                    rdrF002_CLAIMS_MSTR_HDR.Close();
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

            if (!(rdrF002_CLAIMS_MSTR_HDR == null))
            {
                rdrF002_CLAIMS_MSTR_HDR.Close();
                rdrF002_CLAIMS_MSTR_HDR = null;
            }
        }

        #endregion

        #endregion
    }
}
