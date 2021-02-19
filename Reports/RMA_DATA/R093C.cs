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
    public class R093C : BaseRDLClass
    {
        protected const string REPORT_NAME = "R093C";
        protected const bool REPORT_HAS_PARAMETERS = true;
        private Reader rdrU093_PURGE_VALIDATE = new Reader();
        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                //  Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;
                Sort = "D_ICONST_CLINIC_NBR_1_2 ASC, D_BATCH_TYPE ASC, D_BATCTRL_ADJ_CD ASC";
                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return ReportData;
        }
        private void Access_U093_PURGE_VALIDATE()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: If * is not used to select all columns, ensure the necessary columns (i.e. columns that are used to access records of other tables) are included in the SELECT statement
            strSQL.Append("SELECT ");
            strSQL.Append("D_ICONST_CLINIC_NBR_1_2, ");
            strSQL.Append("BATCTRL_BATCH_TYPE, ");
            strSQL.Append("D_BATCTRL_ADJ_CD, ");
            strSQL.Append("ICONST_DATE_PERIOD_END, ");
            strSQL.Append("ICONST_CLINIC_CYCLE_NBR, ");
            strSQL.Append("D_CUT_OFF_DATE, ");
            strSQL.Append("R_BATCTRL_CALC_AR_DUE, ");
            strSQL.Append("R_BATCTRL_CALC_TOT_REV, ");
            strSQL.Append("R_BATCTRL_MANUAL_PAY_TOT, ");
            strSQL.Append("D_RETAIN_COUNT, ");
            strSQL.Append("D_BATCTRL_CALC_AR_DUE, ");
            strSQL.Append("D_BATCTRL_CALC_TOT_REV, ");
            strSQL.Append("D_BATCTRL_MANUAL_PAY_TOT, ");
            strSQL.Append("D_DELETE_COUNT ");
            strSQL.Append("FROM TEMPORARYDATA.U093_PURGE_VALIDATE ");
            strSQL.Append(Choose());
            rdrU093_PURGE_VALIDATE.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles); ;
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
            if ((QDesign.NULL(rdrU093_PURGE_VALIDATE.GetNumber("D_ICONST_CLINIC_NBR_1_2")) == QDesign.NULL(D_CLINIC_PARM())))
            {
                blnSelected = true;
            }

            return blnSelected;
        }

        private decimal D_CLINIC_PARM()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((ReportFunctions.astrScreenParameters[0].ToString().Trim() != String.Empty))
                {
                    decReturnValue = Decimal.Parse(ReportFunctions.astrScreenParameters[0].ToString());
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal D_BATCH_TYPE()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrU093_PURGE_VALIDATE.GetString("BATCTRL_BATCH_TYPE")) == "C"))
                {
                    decReturnValue = 1;
                }
                else if ((QDesign.NULL(rdrU093_PURGE_VALIDATE.GetString("BATCTRL_BATCH_TYPE")) == "A"))
                {
                    decReturnValue = 2;
                }
                else
                {
                    decReturnValue = 3;
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private string D_TYPE()
        {
            string strReturnValue = String.Empty;
            try
            {
                if ((QDesign.NULL(rdrU093_PURGE_VALIDATE.GetString("BATCTRL_BATCH_TYPE")) == "C"))
                {
                    strReturnValue = "CLAIMS";
                }
                else if ((QDesign.NULL(rdrU093_PURGE_VALIDATE.GetString("BATCTRL_BATCH_TYPE")) == "A"))
                {
                    strReturnValue = "ADJUSTMENTS";
                }
                else if ((QDesign.NULL(rdrU093_PURGE_VALIDATE.GetString("BATCTRL_BATCH_TYPE")) == "P"))
                {
                    strReturnValue = "PAYMENTS";
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
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U093_PURGE_VALIDATE.D_ICONST_CLINIC_NBR_1_2", DataTypes.Numeric, 2);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U093_PURGE_VALIDATE.ICONST_DATE_PERIOD_END", DataTypes.Numeric, 8);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U093_PURGE_VALIDATE.ICONST_CLINIC_CYCLE_NBR", DataTypes.Numeric, 2);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U093_PURGE_VALIDATE.D_CUT_OFF_DATE", DataTypes.Numeric, 8);
                AddControl(ReportSection.HEADING_AT, "D_TYPE", DataTypes.Character, 11);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.U093_PURGE_VALIDATE.D_BATCTRL_ADJ_CD", DataTypes.Character, 1);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.U093_PURGE_VALIDATE.R_BATCTRL_CALC_AR_DUE", DataTypes.Numeric, 9);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.U093_PURGE_VALIDATE.R_BATCTRL_CALC_TOT_REV", DataTypes.Numeric, 9);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.U093_PURGE_VALIDATE.R_BATCTRL_MANUAL_PAY_TOT", DataTypes.Numeric, 9);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.U093_PURGE_VALIDATE.D_RETAIN_COUNT", DataTypes.Numeric, 1);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.U093_PURGE_VALIDATE.D_BATCTRL_CALC_AR_DUE", DataTypes.Numeric, 9);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.U093_PURGE_VALIDATE.D_BATCTRL_CALC_TOT_REV", DataTypes.Numeric, 9);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.U093_PURGE_VALIDATE.D_BATCTRL_MANUAL_PAY_TOT", DataTypes.Numeric, 9);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.U093_PURGE_VALIDATE.D_DELETE_COUNT", DataTypes.Numeric, 1);
                AddControl(ReportSection.REPORT, "D_BATCH_TYPE", DataTypes.Numeric, 1);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-05-15 1:46:06 PM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            // TODO: Remove duplicate controls, if there are any.
            switch (strControl)
            {
                case "TEMPORARYDATA.U093_PURGE_VALIDATE.D_ICONST_CLINIC_NBR_1_2":
                    return rdrU093_PURGE_VALIDATE.GetNumber("D_ICONST_CLINIC_NBR_1_2").ToString();
                case "TEMPORARYDATA.U093_PURGE_VALIDATE.ICONST_DATE_PERIOD_END":
                    return rdrU093_PURGE_VALIDATE.GetNumber("ICONST_DATE_PERIOD_END").ToString();
                case "TEMPORARYDATA.U093_PURGE_VALIDATE.ICONST_CLINIC_CYCLE_NBR":
                    return rdrU093_PURGE_VALIDATE.GetNumber("ICONST_CLINIC_CYCLE_NBR").ToString();
                case "TEMPORARYDATA.U093_PURGE_VALIDATE.D_CUT_OFF_DATE":
                    return rdrU093_PURGE_VALIDATE.GetNumber("D_CUT_OFF_DATE").ToString();
                case "D_TYPE":
                    return Common.StringToField(D_TYPE(), intSize);
                case "TEMPORARYDATA.U093_PURGE_VALIDATE.D_BATCTRL_ADJ_CD":
                    return Common.StringToField(rdrU093_PURGE_VALIDATE.GetString("D_BATCTRL_ADJ_CD"));
                case "TEMPORARYDATA.U093_PURGE_VALIDATE.R_BATCTRL_CALC_AR_DUE":
                    return rdrU093_PURGE_VALIDATE.GetNumber("R_BATCTRL_CALC_AR_DUE").ToString();
                case "TEMPORARYDATA.U093_PURGE_VALIDATE.R_BATCTRL_CALC_TOT_REV":
                    return rdrU093_PURGE_VALIDATE.GetNumber("R_BATCTRL_CALC_TOT_REV").ToString();
                case "TEMPORARYDATA.U093_PURGE_VALIDATE.R_BATCTRL_MANUAL_PAY_TOT":
                    return rdrU093_PURGE_VALIDATE.GetNumber("R_BATCTRL_MANUAL_PAY_TOT").ToString();
                case "TEMPORARYDATA.U093_PURGE_VALIDATE.D_RETAIN_COUNT":
                    return rdrU093_PURGE_VALIDATE.GetNumber("D_RETAIN_COUNT").ToString();
                case "TEMPORARYDATA.U093_PURGE_VALIDATE.D_BATCTRL_CALC_AR_DUE":
                    return rdrU093_PURGE_VALIDATE.GetNumber("D_BATCTRL_CALC_AR_DUE").ToString();
                case "TEMPORARYDATA.U093_PURGE_VALIDATE.D_BATCTRL_CALC_TOT_REV":
                    return rdrU093_PURGE_VALIDATE.GetNumber("D_BATCTRL_CALC_TOT_REV").ToString();
                case "TEMPORARYDATA.U093_PURGE_VALIDATE.D_BATCTRL_MANUAL_PAY_TOT":
                    return rdrU093_PURGE_VALIDATE.GetNumber("D_BATCTRL_MANUAL_PAY_TOT").ToString();
                case "TEMPORARYDATA.U093_PURGE_VALIDATE.D_DELETE_COUNT":
                    return rdrU093_PURGE_VALIDATE.GetNumber("D_DELETE_COUNT").ToString();
                case "D_BATCH_TYPE":
                    return D_BATCH_TYPE().ToString();
                default:
                    return String.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                // TODO: Some manual steps maybe required.
                Access_U093_PURGE_VALIDATE();
                while (rdrU093_PURGE_VALIDATE.Read())
                {
                    WriteData();
                }

                rdrU093_PURGE_VALIDATE.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrU093_PURGE_VALIDATE == null))
            {
                rdrU093_PURGE_VALIDATE.Close();
                rdrU093_PURGE_VALIDATE = null;
            }
        }
    }
}
