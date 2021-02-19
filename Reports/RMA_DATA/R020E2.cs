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
    public class R020E2 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R020E2";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrU020E1 = new Reader();
        private Reader rdrU020E2 = new Reader();

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
                SubFileName = "U020E2";
                SubFileType = SubFileType.Keep;
                SubFileAT = "";// W_AGENT";
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

        private void Access_U020E1()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("ICONST_CLINIC_NBR_1_2, ");
            strSQL.Append("W_BATCH_TYPE, ");
            strSQL.Append("W_ADJ_CODE, ");
            strSQL.Append("W_AGENT, ");
            strSQL.Append("BATCTRL_BATCH_NBR, ");
            strSQL.Append("ICONST_CLINIC_CYCLE_NBR, ");
            strSQL.Append("ICONST_DATE_PERIOD_END, ");
            strSQL.Append("BATCTRL_ADJ_CD, ");
            strSQL.Append("BATCTRL_CALC_AR_DUE, ");
            strSQL.Append("BATCTRL_CALC_TOT_REV, ");
            strSQL.Append("BATCTRL_MANUAL_PAY_TOT, ");
            strSQL.Append("BATCTRL_NBR_CLAIMS_IN_BATCH ");
            strSQL.Append("FROM TEMPORARYDATA.U020E1 ");

            strSQL.Append(Choose());

            rdrU020E1.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
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

        private string FIRST_KEY()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = (QDesign.ASCII(rdrU020E1.GetNumber("ICONST_CLINIC_NBR_1_2"), 2) 
                            + (rdrU020E1.GetString("W_BATCH_TYPE") + rdrU020E1.GetString("W_ADJ_CODE")));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return strReturnValue;
        }

        private decimal BATCTRL_CALC_AR_DUE_SUBTOTAL = 0;
        private decimal BATCTRL_CALC_TOT_REV_SUBTOTAL = 0;
        private decimal BATCTRL_MANUAL_PAY_TOT_SUBTOTAL = 0;
        private decimal BATCTRL_NBR_CLAIMS_IN_BATCH_SUBTOTAL = 0;
        private decimal PREV_ICONST_CLINIC_NBR_1_2 = 0;
        private decimal PREV_ICONST_CLINIC_CYCLE_NBR = 0;
        private decimal PREV_ICONST_DATE_PERIOD_END = 0;

        private string PREV_W_BATCH_TYPE = string.Empty;
        private string PREV_W_ADJ_CODE = string.Empty;
        private string PREV_BATCTRL_ADJ_CD = string.Empty;
        private string PREV_BATCTRL_BATCH_NBR = string.Empty;
        private string PREV_W_AGENT = string.Empty;

        #endregion

        #region " CONTROLS "

        public override void DeclareReportControls()
        {
            try
            {
                 AddControl(ReportSection.SUMMARY, "ICONST_CLINIC_NBR_1_2", DataTypes.Numeric, 2);
                 AddControl(ReportSection.SUMMARY, "ICONST_CLINIC_CYCLE_NBR", DataTypes.Numeric, 2);
                 AddControl(ReportSection.SUMMARY, "ICONST_DATE_PERIOD_END", DataTypes.Numeric, 8);
                 AddControl(ReportSection.SUMMARY, "W_BATCH_TYPE", DataTypes.Character, 1);
                 AddControl(ReportSection.SUMMARY, "BATCTRL_ADJ_CD", DataTypes.Character, 1);
                 AddControl(ReportSection.SUMMARY, "W_AGENT", DataTypes.Character, 1);
                 AddControl(ReportSection.SUMMARY, "BATCTRL_CALC_AR_DUE", DataTypes.Numeric, 9);
                 AddControl(ReportSection.SUMMARY, "BATCTRL_CALC_TOT_REV", DataTypes.Numeric, 9);
                 AddControl(ReportSection.SUMMARY, "BATCTRL_MANUAL_PAY_TOT", DataTypes.Numeric, 9);
                 AddControl(ReportSection.SUMMARY, "BATCTRL_NBR_CLAIMS_IN_BATCH", DataTypes.Numeric, 5);
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
        // # Do not delete, modify or move it.  Updated: 2018-05-11 6:02:30 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "ICONST_CLINIC_NBR_1_2":
                    return PREV_ICONST_CLINIC_NBR_1_2.ToString();

                case "ICONST_CLINIC_CYCLE_NBR":
                    return PREV_ICONST_CLINIC_CYCLE_NBR.ToString();

                case "ICONST_DATE_PERIOD_END":
                    return PREV_ICONST_DATE_PERIOD_END.ToString();

                case "W_BATCH_TYPE":
                    return Common.StringToField(PREV_W_BATCH_TYPE);

                case "BATCTRL_ADJ_CD":
                    return Common.StringToField(PREV_BATCTRL_ADJ_CD);

                case "W_AGENT":
                    return Common.StringToField(PREV_W_AGENT);

                case "BATCTRL_CALC_AR_DUE":
                    return BATCTRL_CALC_AR_DUE_SUBTOTAL.ToString();

                case "BATCTRL_CALC_TOT_REV":
                    return BATCTRL_CALC_TOT_REV_SUBTOTAL.ToString();

                case "BATCTRL_MANUAL_PAY_TOT":
                    return BATCTRL_MANUAL_PAY_TOT_SUBTOTAL.ToString();

                case "BATCTRL_NBR_CLAIMS_IN_BATCH":
                    return BATCTRL_NBR_CLAIMS_IN_BATCH_SUBTOTAL.ToString();

                default:
                    return string.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                Access_U020E1();
                while (rdrU020E1.Read())
                {
                    string curr = rdrU020E1.GetString("W_AGENT");
                    string prev = PREV_W_AGENT;
                    if (PREV_BATCTRL_BATCH_NBR == string.Empty)
                    {
                        BATCTRL_CALC_AR_DUE_SUBTOTAL += rdrU020E1.GetNumber("BATCTRL_CALC_AR_DUE");
                        BATCTRL_CALC_TOT_REV_SUBTOTAL += rdrU020E1.GetNumber("BATCTRL_CALC_TOT_REV");
                        BATCTRL_MANUAL_PAY_TOT_SUBTOTAL += rdrU020E1.GetNumber("BATCTRL_MANUAL_PAY_TOT");
                        BATCTRL_NBR_CLAIMS_IN_BATCH_SUBTOTAL += rdrU020E1.GetNumber("BATCTRL_NBR_CLAIMS_IN_BATCH");

                        SetPreviousValues();
                    }
                    else if (PREV_BATCTRL_BATCH_NBR != rdrU020E1.GetString("BATCTRL_BATCH_NBR"))
                    {
                        if (PREV_ICONST_CLINIC_NBR_1_2 != rdrU020E1.GetNumber("ICONST_CLINIC_NBR_1_2"))
                        {
                            WriteData();

                            BATCTRL_CALC_AR_DUE_SUBTOTAL = rdrU020E1.GetNumber("BATCTRL_CALC_AR_DUE");
                            BATCTRL_CALC_TOT_REV_SUBTOTAL = rdrU020E1.GetNumber("BATCTRL_CALC_TOT_REV");
                            BATCTRL_MANUAL_PAY_TOT_SUBTOTAL = rdrU020E1.GetNumber("BATCTRL_MANUAL_PAY_TOT");
                            BATCTRL_NBR_CLAIMS_IN_BATCH_SUBTOTAL = rdrU020E1.GetNumber("BATCTRL_NBR_CLAIMS_IN_BATCH");

                            SetPreviousValues();
                        }
                        else if (PREV_W_BATCH_TYPE != rdrU020E1.GetString("W_BATCH_TYPE"))
                        {
                            WriteData();

                            BATCTRL_CALC_AR_DUE_SUBTOTAL = rdrU020E1.GetNumber("BATCTRL_CALC_AR_DUE");
                            BATCTRL_CALC_TOT_REV_SUBTOTAL = rdrU020E1.GetNumber("BATCTRL_CALC_TOT_REV");
                            BATCTRL_MANUAL_PAY_TOT_SUBTOTAL = rdrU020E1.GetNumber("BATCTRL_MANUAL_PAY_TOT");
                            BATCTRL_NBR_CLAIMS_IN_BATCH_SUBTOTAL = rdrU020E1.GetNumber("BATCTRL_NBR_CLAIMS_IN_BATCH");

                            SetPreviousValues();
                        }
                        else if (PREV_W_ADJ_CODE != rdrU020E1.GetString("W_ADJ_CODE"))
                        {
                            WriteData();

                            BATCTRL_CALC_AR_DUE_SUBTOTAL = rdrU020E1.GetNumber("BATCTRL_CALC_AR_DUE");
                            BATCTRL_CALC_TOT_REV_SUBTOTAL = rdrU020E1.GetNumber("BATCTRL_CALC_TOT_REV");
                            BATCTRL_MANUAL_PAY_TOT_SUBTOTAL = rdrU020E1.GetNumber("BATCTRL_MANUAL_PAY_TOT");
                            BATCTRL_NBR_CLAIMS_IN_BATCH_SUBTOTAL = rdrU020E1.GetNumber("BATCTRL_NBR_CLAIMS_IN_BATCH");

                            SetPreviousValues();
                        }
                        else if (PREV_W_AGENT != rdrU020E1.GetString("W_AGENT"))
                        {
                            WriteData();

                            BATCTRL_CALC_AR_DUE_SUBTOTAL = rdrU020E1.GetNumber("BATCTRL_CALC_AR_DUE");
                            BATCTRL_CALC_TOT_REV_SUBTOTAL = rdrU020E1.GetNumber("BATCTRL_CALC_TOT_REV");
                            BATCTRL_MANUAL_PAY_TOT_SUBTOTAL = rdrU020E1.GetNumber("BATCTRL_MANUAL_PAY_TOT");
                            BATCTRL_NBR_CLAIMS_IN_BATCH_SUBTOTAL = rdrU020E1.GetNumber("BATCTRL_NBR_CLAIMS_IN_BATCH");

                            SetPreviousValues();
                        }
                        else
                        {
                            BATCTRL_CALC_AR_DUE_SUBTOTAL += rdrU020E1.GetNumber("BATCTRL_CALC_AR_DUE");
                            BATCTRL_CALC_TOT_REV_SUBTOTAL += rdrU020E1.GetNumber("BATCTRL_CALC_TOT_REV");
                            BATCTRL_MANUAL_PAY_TOT_SUBTOTAL += rdrU020E1.GetNumber("BATCTRL_MANUAL_PAY_TOT");
                            BATCTRL_NBR_CLAIMS_IN_BATCH_SUBTOTAL += rdrU020E1.GetNumber("BATCTRL_NBR_CLAIMS_IN_BATCH");

                            SetPreviousValues();
                        }
                    }
                }

                //Write the last record
                WriteData();

                rdrU020E1.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        private void SetPreviousValues()
        {
            PREV_BATCTRL_BATCH_NBR = rdrU020E1.GetString("BATCTRL_BATCH_NBR");
            PREV_ICONST_CLINIC_NBR_1_2 = rdrU020E1.GetNumber("ICONST_CLINIC_NBR_1_2");
            PREV_ICONST_CLINIC_CYCLE_NBR = rdrU020E1.GetNumber("ICONST_CLINIC_CYCLE_NBR");
            PREV_ICONST_DATE_PERIOD_END = rdrU020E1.GetNumber("ICONST_DATE_PERIOD_END");
            PREV_W_BATCH_TYPE = rdrU020E1.GetString("W_BATCH_TYPE");
            PREV_W_ADJ_CODE = rdrU020E1.GetString("W_ADJ_CODE");
            PREV_BATCTRL_ADJ_CD = rdrU020E1.GetString("BATCTRL_ADJ_CD");
            PREV_W_AGENT = rdrU020E1.GetString("W_AGENT");
        }

        public override void CloseReaders()
        {
            if (!(rdrU020E1 == null))
            {
                rdrU020E1.Close();
                rdrU020E1 = null;
            }
        }

        #endregion

        #endregion
    }
}
