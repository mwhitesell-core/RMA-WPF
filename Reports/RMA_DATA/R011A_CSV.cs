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
    public class R011A_CSV : BaseRDLClass
    {
        protected const string REPORT_NAME = "R011A_CSV";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrICONST_MSTR_REC = new Reader();
        private Reader rdrR011_PED = new Reader();

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
                SubFileName = "R011_PED";
                SubFileType = SubFileType.Keep;
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
        private void Access_ICONST_MSTR_REC()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            strSQL.Append("SELECT ");
            strSQL.Append("ICONST_CLINIC_NBR_1_2, ");
            strSQL.Append("ICONST_DATE_PERIOD_END_YY, ");
            strSQL.Append("ICONST_DATE_PERIOD_END_MM, ");
            strSQL.Append("ICONST_DATE_PERIOD_END_DD ");
            strSQL.Append("FROM INDEXED.ICONST_MSTR_REC ");
            strSQL.Append(Choose());
            rdrICONST_MSTR_REC.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(String.Empty);
            // TODO: CHOOSE Statement - May require manual changes.
            strChoose.Append(ReportDataFunctions.GetWhereCondition("ICONST_CLINIC_NBR_1_2", "22", true));
            return strChoose.ToString().ToString();
        }

        private decimal X_PED_YYYYMM()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = QDesign.NConvert((QDesign.ASCII(rdrICONST_MSTR_REC.GetNumber("ICONST_DATE_PERIOD_END_YY"), 4) + QDesign.ASCII(rdrICONST_MSTR_REC.GetNumber("ICONST_DATE_PERIOD_END_MM"), 2)));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_PED_YYYY()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = rdrICONST_MSTR_REC.GetNumber("ICONST_DATE_PERIOD_END_YY");
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_PED_MM()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = QDesign.PHMod(X_PED_YYYYMM(), 100);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_PED_DD()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = QDesign.PHMod(QDesign.NConvert(QDesign.ASCII(rdrICONST_MSTR_REC.GetNumber("ICONST_DATE_PERIOD_END_YY"), 4) + QDesign.ASCII(rdrICONST_MSTR_REC.GetNumber("ICONST_DATE_PERIOD_END_MM"), 2) + QDesign.ASCII(rdrICONST_MSTR_REC.GetNumber("ICONST_DATE_PERIOD_END_DD"), 2)), 100);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_EP_YR()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((X_PED_MM() >= 8) && (X_PED_MM() <= 12))
                {
                    decReturnValue = X_PED_YYYY();
                }
                else if ((X_PED_MM() <= 7))
                {
                    decReturnValue = (X_PED_YYYY() - 1);
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_PREV_PED()
        {
            decimal decReturnValue = 0;
            try
            {
                if (QDesign.NULL(X_PED_MM()) == QDesign.NULL(1d))
                {
                    decReturnValue = (((X_PED_YYYY() - 1) * 10000) + 1201);
                }
                else if ((QDesign.NULL(X_PED_DD()) != QDesign.NULL(30d)) && (QDesign.NULL(X_PED_MM()) != QDesign.NULL(7d)))
                {
                    decReturnValue = (((X_PED_YYYYMM() - 1) * 100) + 1);
                }
                else if ((QDesign.NULL(X_PED_DD()) == QDesign.NULL(30d)) && (QDesign.NULL(X_PED_MM()) == QDesign.NULL(6d)))
                {
                    decReturnValue = ((X_PED_YYYYMM() * 100) + 1);
                }
                else if ((QDesign.NULL(X_PED_MM()) == QDesign.NULL(7d)))
                {
                    decReturnValue = (((X_PED_YYYYMM() - 1) * 100) + 30);
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal ICONST_MSTR_REC_ICONST_DATE_PERIOD_END()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = QDesign.NConvert(QDesign.ASCII(rdrICONST_MSTR_REC.GetNumber("ICONST_DATE_PERIOD_END_YY"), 4) + (QDesign.ASCII(rdrICONST_MSTR_REC.GetNumber("ICONST_DATE_PERIOD_END_MM"), 2) + QDesign.ASCII(rdrICONST_MSTR_REC.GetNumber("ICONST_DATE_PERIOD_END_DD"), 2)));
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
                AddControl(ReportSection.SUMMARY, "X_EP_YR", DataTypes.Numeric, 4);
                AddControl(ReportSection.SUMMARY, "X_PREV_PED", DataTypes.Numeric, 8);
                AddControl(ReportSection.SUMMARY, "ICONST_DATE_PERIOD_END", DataTypes.Numeric, 8);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-11-20 2:09:52 PM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            // TODO: Remove duplicate controls, if there are any.
            switch (strControl)
            {
                case "X_EP_YR":
                    return X_EP_YR().ToString();
                case "X_PREV_PED":
                    return X_PREV_PED().ToString();
                case "ICONST_DATE_PERIOD_END":
                    return ICONST_MSTR_REC_ICONST_DATE_PERIOD_END().ToString();
                default:
                    return String.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                // TODO: Some manual steps maybe required.
                Access_ICONST_MSTR_REC();
                while (rdrICONST_MSTR_REC.Read())
                {
                    WriteData();
                }

                rdrICONST_MSTR_REC.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrICONST_MSTR_REC == null))
            {
                rdrICONST_MSTR_REC.Close();
                rdrICONST_MSTR_REC = null;
            }
        }
    }
}
