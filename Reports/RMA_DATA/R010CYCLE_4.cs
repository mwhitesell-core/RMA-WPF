//  2007/05/10 - MC - add a  new pass for clinic 70`s subtotal
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
    public class R010CYCLE_4 : BaseRDLClass
    {
        protected const string REPORT_NAME = "R010CYCLE_4";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrR010CYCLE = new Reader();
        private Reader rdrICONST_MSTR_REC = new Reader();
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
        private void Access_R010CYCLE()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("BATCTRL_BATCH_NBR, ");
            strSQL.Append("BATCTRL_BATCH_TYPE, ");
            strSQL.Append("BATCTRL_ADJ_CD, ");
            strSQL.Append("BATCTRL_MANUAL_PAY_TOT, ");
            strSQL.Append("BATCTRL_CALC_TOT_REV, ");
            strSQL.Append("X_CASH_UPD, ");
            strSQL.Append("X_REV_UPD, ");
            strSQL.Append("BATCTRL_CALC_AR_DUE ");
            strSQL.Append("FROM TEMPORARYDATA.R010CYCLE ");

            strSQL.Append(Choose());

            rdrR010CYCLE.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
            strSQL = null;
        }
        private void Link_ICONST_MSTR_REC()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("ICONST_CLINIC_NBR_1_2 ");
            strSQL.Append("FROM INDEXED.ICONST_MSTR_REC ");
            strSQL.Append("WHERE ");
            strSQL.Append("ICONST_CLINIC_NBR_1_2 = ").Append(QDesign.NConvert(QDesign.Substring(rdrR010CYCLE.GetString("BATCTRL_BATCH_NBR"), 1, 2)));

            rdrICONST_MSTR_REC.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(string.Empty);

            return strChoose.ToString();
        }

        public override bool SelectIf()
        {
            bool blnSelected = false;
            if (((rdrICONST_MSTR_REC.GetNumber("ICONST_CLINIC_NBR_1_2") >= 71)
                        && (rdrICONST_MSTR_REC.GetNumber("ICONST_CLINIC_NBR_1_2") <= 75)))
            {
                blnSelected = true;
            }

            return blnSelected;
        }

        private decimal X_CASH_PAID()
        {
            decimal decReturnValue = 0;
            try
            {
                if (((QDesign.NULL(rdrR010CYCLE.GetString("BATCTRL_BATCH_TYPE")) == "P")
                            && (QDesign.NULL(rdrR010CYCLE.GetString("BATCTRL_ADJ_CD")) == "C")))
                {
                    decReturnValue = (0 - rdrR010CYCLE.GetNumber("BATCTRL_MANUAL_PAY_TOT"));
                }
                else
                {
                    decReturnValue = rdrR010CYCLE.GetNumber("BATCTRL_MANUAL_PAY_TOT");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_BATCH_CALC()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = (X_CASH_PAID() + rdrR010CYCLE.GetNumber("BATCTRL_CALC_TOT_REV"));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_CLM_UPDATE()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = (rdrR010CYCLE.GetNumber("X_CASH_UPD") + rdrR010CYCLE.GetNumber("X_REV_UPD"));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_DIFF()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = (X_BATCH_CALC() - X_CLM_UPDATE());
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
                AddControl(ReportSection.FINAL_FOOTING, "TEMPORARYDATA.R010CYCLE.BATCTRL_CALC_AR_DUE", DataTypes.Numeric, 9);
                AddControl(ReportSection.FINAL_FOOTING, "TEMPORARYDATA.R010CYCLE.BATCTRL_CALC_TOT_REV", DataTypes.Numeric, 9);
                AddControl(ReportSection.FINAL_FOOTING, "X_CASH_PAID", DataTypes.Numeric, 9);
                AddControl(ReportSection.FINAL_FOOTING, "TEMPORARYDATA.R010CYCLE.X_REV_UPD", DataTypes.Numeric, 9);
                AddControl(ReportSection.FINAL_FOOTING, "TEMPORARYDATA.R010CYCLE.X_CASH_UPD", DataTypes.Numeric, 9);
                AddControl(ReportSection.FINAL_FOOTING, "X_DIFF", DataTypes.Numeric, 9);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-09-04 9:47:56 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            // TODO: Remove duplicate controls, if there are any.
            switch (strControl)
            {
                case "TEMPORARYDATA.R010CYCLE.BATCTRL_CALC_AR_DUE":
                    return rdrR010CYCLE.GetNumber("BATCTRL_CALC_AR_DUE").ToString();

                case "TEMPORARYDATA.R010CYCLE.BATCTRL_CALC_TOT_REV":
                    return rdrR010CYCLE.GetNumber("BATCTRL_CALC_TOT_REV").ToString();

                case "X_CASH_PAID":
                    return X_CASH_PAID().ToString();

                case "TEMPORARYDATA.R010CYCLE.X_REV_UPD":
                    return rdrR010CYCLE.GetNumber("X_REV_UPD").ToString();

                case "TEMPORARYDATA.R010CYCLE.X_CASH_UPD":
                    return rdrR010CYCLE.GetNumber("X_CASH_UPD").ToString();

                case "X_DIFF":
                    return X_DIFF().ToString();

                default:
                    return string.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                Access_R010CYCLE();
                while (rdrR010CYCLE.Read())
                {
                    Link_ICONST_MSTR_REC();
                    while (rdrICONST_MSTR_REC.Read())
                    {
                        WriteData();
                    }

                    rdrICONST_MSTR_REC.Close();
                }

                rdrR010CYCLE.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrR010CYCLE == null))
            {
                rdrR010CYCLE.Close();
                rdrR010CYCLE = null;
            }

            if (!(rdrICONST_MSTR_REC == null))
            {
                rdrICONST_MSTR_REC.Close();
                rdrICONST_MSTR_REC = null;
            }
        }
    }
}
