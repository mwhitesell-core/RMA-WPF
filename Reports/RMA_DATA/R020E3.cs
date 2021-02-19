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
    public class R020E3 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R020E3";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrU020E2 = new Reader();
        private Reader rdrU020E3 = new Reader();

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
                SubFileName = "U020E3";
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

        private void Access_U020E2()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("W_BATCH_TYPE, ");
            strSQL.Append("BATCTRL_ADJ_CD, ");
            strSQL.Append("BATCTRL_MANUAL_PAY_TOT, ");
            strSQL.Append("ICONST_CLINIC_NBR_1_2, ");
            strSQL.Append("ICONST_CLINIC_CYCLE_NBR, ");
            strSQL.Append("ICONST_DATE_PERIOD_END, ");
            strSQL.Append("W_AGENT, ");
            strSQL.Append("BATCTRL_CALC_AR_DUE, ");
            strSQL.Append("BATCTRL_CALC_TOT_REV, ");
            strSQL.Append("BATCTRL_NBR_CLAIMS_IN_BATCH ");
            strSQL.Append("FROM TEMPORARYDATA.U020E2 ");

            strSQL.Append(Choose());

            rdrU020E2.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
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

        private decimal W_BATCTRL_MANUAL_PAY_TOT()
        {
            decimal decReturnValue = 0;
            try
            {
                if (((QDesign.NULL(rdrU020E2.GetString("W_BATCH_TYPE")) == "P") 
                            && (QDesign.NULL(rdrU020E2.GetString("BATCTRL_ADJ_CD")) == "C")))
                {
                    decReturnValue = (rdrU020E2.GetNumber("BATCTRL_MANUAL_PAY_TOT") * -1);
                }
                else
                {
                    decReturnValue = rdrU020E2.GetNumber("BATCTRL_MANUAL_PAY_TOT");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return decReturnValue;
        }

        #endregion

        #region " CONTROLS "

        public override void DeclareReportControls()
        {
            try
            {
                 AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U020E2.ICONST_CLINIC_NBR_1_2", DataTypes.Numeric, 2);
                 AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U020E2.ICONST_CLINIC_CYCLE_NBR", DataTypes.Numeric, 2);
                 AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U020E2.ICONST_DATE_PERIOD_END", DataTypes.Numeric, 8);
                 AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U020E2.W_BATCH_TYPE", DataTypes.Character, 1);
                 AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U020E2.BATCTRL_ADJ_CD", DataTypes.Character, 1);
                 AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U020E2.W_AGENT", DataTypes.Character, 1);
                 AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U020E2.BATCTRL_CALC_AR_DUE", DataTypes.Numeric, 9);
                 AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U020E2.BATCTRL_CALC_TOT_REV", DataTypes.Numeric, 9);
                 AddControl(ReportSection.SUMMARY, "W_BATCTRL_MANUAL_PAY_TOT", DataTypes.Numeric, 9);
                 AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U020E2.BATCTRL_NBR_CLAIMS_IN_BATCH", DataTypes.Numeric, 5);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        #endregion

        #region " Renaissance Precompiler Generated Code "

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-05-11 6:02:29 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "TEMPORARYDATA.U020E2.ICONST_CLINIC_NBR_1_2":
                    return rdrU020E2.GetNumber("ICONST_CLINIC_NBR_1_2").ToString();

                case "TEMPORARYDATA.U020E2.ICONST_CLINIC_CYCLE_NBR":
                    return rdrU020E2.GetNumber("ICONST_CLINIC_CYCLE_NBR").ToString();

                case "TEMPORARYDATA.U020E2.ICONST_DATE_PERIOD_END":
                    return rdrU020E2.GetNumber("ICONST_DATE_PERIOD_END").ToString();

                case "TEMPORARYDATA.U020E2.W_BATCH_TYPE":
                    return Common.StringToField(rdrU020E2.GetString("W_BATCH_TYPE"));

                case "TEMPORARYDATA.U020E2.BATCTRL_ADJ_CD":
                    return Common.StringToField(rdrU020E2.GetString("BATCTRL_ADJ_CD"));

                case "TEMPORARYDATA.U020E2.W_AGENT":
                    return Common.StringToField(rdrU020E2.GetString("W_AGENT"));

                case "TEMPORARYDATA.U020E2.BATCTRL_CALC_AR_DUE":
                    return rdrU020E2.GetNumber("BATCTRL_CALC_AR_DUE").ToString();

                case "TEMPORARYDATA.U020E2.BATCTRL_CALC_TOT_REV":
                    return rdrU020E2.GetNumber("BATCTRL_CALC_TOT_REV").ToString();

                case "W_BATCTRL_MANUAL_PAY_TOT":
                    return W_BATCTRL_MANUAL_PAY_TOT().ToString();

                case "TEMPORARYDATA.U020E2.BATCTRL_NBR_CLAIMS_IN_BATCH":
                    return rdrU020E2.GetNumber("BATCTRL_NBR_CLAIMS_IN_BATCH").ToString();

                default:
                    return string.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                Access_U020E2();
                while (rdrU020E2.Read())
                {
                    WriteData();
                }
            
                rdrU020E2.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrU020E2 == null))
            {
                rdrU020E2.Close();
                rdrU020E2 = null;
            }
        }

        #endregion

        #endregion
    }
}
