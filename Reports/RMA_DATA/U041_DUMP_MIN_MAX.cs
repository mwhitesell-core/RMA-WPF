//  run this program before the qts to ensure updates are correct
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
    public class U041_DUMP_MIN_MAX : BaseRDLClass
    {
        protected const string REPORT_NAME = "U041_DUMP_MIN_MAX";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrF040_OMA_FEE_MSTR = new Reader();
        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                //  Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;
                Sort = "FEE_ICC_CODE ASC, FEE_OMA_CD ASC";
                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return ReportData;
        }
        private void Access_F040_OMA_FEE_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            strSQL.Append("SELECT ");
            strSQL.Append("FEE_CURR_H_MIN, ");
            strSQL.Append("FEE_CURR_A_FEE_1, ");
            strSQL.Append("FEE_OMA_CD_LTR1, ");
            strSQL.Append(" FILLER_NUMERIC, ");
            strSQL.Append("FEE_CURR_H_FEE_1, ");
            strSQL.Append("FEE_CURR_A_FEE_2, ");
            strSQL.Append("FEE_CURR_H_FEE_2, ");
            strSQL.Append("FEE_CURR_H_MAX, ");
            strSQL.Append("FEE_ICC_SEC, ");
            strSQL.Append(" FEE_ICC_CAT, ");
            strSQL.Append(" FEE_ICC_GRP, ");
            strSQL.Append(" FEE_ICC_REDUC_IND ");
            strSQL.Append("FROM INDEXED.F040_OMA_FEE_MSTR ");
            strSQL.Append(Choose());
            rdrF040_OMA_FEE_MSTR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
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
            if (((QDesign.NULL(rdrF040_OMA_FEE_MSTR.GetNumber("FEE_CURR_A_FEE_1")) == QDesign.NULL(rdrF040_OMA_FEE_MSTR.GetNumber("FEE_CURR_H_FEE_1")))
                        && ((QDesign.NULL(rdrF040_OMA_FEE_MSTR.GetNumber("FEE_CURR_H_MIN")) != QDesign.NULL(0d))
                        && ((QDesign.NULL(rdrF040_OMA_FEE_MSTR.GetNumber("FEE_CURR_H_MAX")) != QDesign.NULL(0d))
                        && ((QDesign.NULL(rdrF040_OMA_FEE_MSTR.GetNumber("FEE_CURR_H_MIN")) == QDesign.NULL(rdrF040_OMA_FEE_MSTR.GetNumber("FEE_CURR_H_MAX")))
                        && (QDesign.NULL(rdrF040_OMA_FEE_MSTR.GetNumber("FEE_CURR_A_FEE_1")) != QDesign.NULL(rdrF040_OMA_FEE_MSTR.GetNumber("FEE_CURR_H_MIN"))))))))
            {
                blnSelected = true;
            }

            return blnSelected;
        }

        private decimal X_20_PERCENT()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = (rdrF040_OMA_FEE_MSTR.GetNumber("FEE_CURR_H_MIN") * (20 / 100));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_TEST_AMT()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = (rdrF040_OMA_FEE_MSTR.GetNumber("FEE_CURR_H_MIN") + X_20_PERCENT());
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private string X_FLAG()
        {
            string strReturnValue = String.Empty;
            try
            {
                if (((QDesign.NULL(X_TEST_AMT()) < QDesign.NULL(rdrF040_OMA_FEE_MSTR.GetNumber("FEE_CURR_A_FEE_1")))
                            && (QDesign.NULL(rdrF040_OMA_FEE_MSTR.GetString("FEE_OMA_CD")) != "C183")))
                {
                    strReturnValue = "*";
                }
                else
                {
                    strReturnValue = " ";
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string F040_OMA_FEE_MSTR_FEE_OMA_CD()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = (rdrF040_OMA_FEE_MSTR.GetString("FEE_OMA_CD_LTR1") + rdrF040_OMA_FEE_MSTR.GetString("FILLER_NUMERIC"));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string F040_OMA_FEE_MSTR_FEE_ICC_CODE()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = (rdrF040_OMA_FEE_MSTR.GetString("FEE_ICC_SEC")
                            + (rdrF040_OMA_FEE_MSTR.GetString("FEE_ICC_CAT")
                            + (rdrF040_OMA_FEE_MSTR.GetString("FEE_ICC_GRP") + rdrF040_OMA_FEE_MSTR.GetString("FEE_ICC_REDUC_IND"))));
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
                AddControl(ReportSection.REPORT, "F040_OMA_FEE_MSTR_FEE_OMA_CD", DataTypes.Character, 4);
                AddControl(ReportSection.REPORT, "INDEXED.F040_OMA_FEE_MSTR.FEE_CURR_A_FEE_1", DataTypes.Numeric, 7);
                AddControl(ReportSection.REPORT, "INDEXED.F040_OMA_FEE_MSTR.FEE_CURR_H_FEE_1", DataTypes.Numeric, 7);
                AddControl(ReportSection.REPORT, "INDEXED.F040_OMA_FEE_MSTR.FEE_CURR_A_FEE_2", DataTypes.Numeric, 7);
                AddControl(ReportSection.REPORT, "INDEXED.F040_OMA_FEE_MSTR.FEE_CURR_H_FEE_2", DataTypes.Numeric, 7);
                AddControl(ReportSection.REPORT, "INDEXED.F040_OMA_FEE_MSTR.FEE_CURR_H_MIN", DataTypes.Numeric, 7);
                AddControl(ReportSection.REPORT, "INDEXED.F040_OMA_FEE_MSTR.FEE_CURR_H_MAX", DataTypes.Numeric, 7);
                AddControl(ReportSection.REPORT, "X_TEST_AMT", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "X_FLAG", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "F040_OMA_FEE_MSTR_FEE_ICC_CODE", DataTypes.Character, 6);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2019-07-23 2:20:36 PM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "F040_OMA_FEE_MSTR_FEE_OMA_CD":
                    return Common.StringToField(F040_OMA_FEE_MSTR_FEE_OMA_CD(), intSize);
                case "INDEXED.F040_OMA_FEE_MSTR.FEE_CURR_A_FEE_1":
                    return rdrF040_OMA_FEE_MSTR.GetNumber("FEE_CURR_A_FEE_1").ToString();
                case "INDEXED.F040_OMA_FEE_MSTR.FEE_CURR_H_FEE_1":
                    return rdrF040_OMA_FEE_MSTR.GetNumber("FEE_CURR_H_FEE_1").ToString();
                case "INDEXED.F040_OMA_FEE_MSTR.FEE_CURR_A_FEE_2":
                    return rdrF040_OMA_FEE_MSTR.GetNumber("FEE_CURR_A_FEE_2").ToString();
                case "INDEXED.F040_OMA_FEE_MSTR.FEE_CURR_H_FEE_2":
                    return rdrF040_OMA_FEE_MSTR.GetNumber("FEE_CURR_H_FEE_2").ToString();
                case "INDEXED.F040_OMA_FEE_MSTR.FEE_CURR_H_MIN":
                    return rdrF040_OMA_FEE_MSTR.GetNumber("FEE_CURR_H_MIN").ToString();
                case "INDEXED.F040_OMA_FEE_MSTR.FEE_CURR_H_MAX":
                    return rdrF040_OMA_FEE_MSTR.GetNumber("FEE_CURR_H_MAX").ToString();
                case "X_TEST_AMT":
                    return X_TEST_AMT().ToString();
                case "X_FLAG":
                    return Common.StringToField(X_FLAG(), intSize);
                case "F040_OMA_FEE_MSTR_FEE_ICC_CODE":
                    return Common.StringToField(F040_OMA_FEE_MSTR_FEE_ICC_CODE(), intSize);
                default:
                    return String.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                // TODO: Some manual steps maybe required.
                Access_F040_OMA_FEE_MSTR();
                while (rdrF040_OMA_FEE_MSTR.Read())
                {
                    WriteData();
                }

                rdrF040_OMA_FEE_MSTR.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if (!(rdrF040_OMA_FEE_MSTR == null))
            {
                rdrF040_OMA_FEE_MSTR.Close();
                rdrF040_OMA_FEE_MSTR = null;
            }
        }
    }
}
