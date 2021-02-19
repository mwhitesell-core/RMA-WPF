//  2011/05/10 yas add two new items 
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
    public class WEBOMAFEE : BaseRDLClass
    {
        protected const string REPORT_NAME = "WEBOMAFEE";
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
                Sort = "FEE_OMA_CD ASC";
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
            strSQL.Append("FEE_OMA_CD_LTR1, ");
            strSQL.Append(" FILLER_NUMERIC, ");
            strSQL.Append("FEE_DESC, ");
            strSQL.Append("FEE_DATE_YY, ");
            strSQL.Append(" FEE_DATE_MM, ");
            strSQL.Append(" FEE_DATE_DD, ");
            strSQL.Append("FEE_CURR_H_FEE_1, ");
            strSQL.Append("FEE_CURR_H_FEE_2, ");
            strSQL.Append("FEE_CURR_H_ANAE, ");
            strSQL.Append("FEE_CURR_H_ASST, ");
            strSQL.Append("FEE_ACTIVE_FOR_ENTRY, ");
            strSQL.Append("FEE_DIAG_IND, ");
            strSQL.Append("FEE_ADMIT_IND ");
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

        private string COMMA()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = "~";
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

        private decimal F040_OMA_FEE_MSTR_FEE_EFFECTIVE_DATE()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = QDesign.NConvert(QDesign.ASCII(rdrF040_OMA_FEE_MSTR.GetNumber("FEE_DATE_YY")) + QDesign.ASCII(rdrF040_OMA_FEE_MSTR.GetNumber("FEE_DATE_MM")).PadLeft(2, '0') + QDesign.ASCII(rdrF040_OMA_FEE_MSTR.GetNumber("FEE_DATE_DD")).PadLeft(2, '0'));
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
                AddControl(ReportSection.REPORT, "FEE_OMA_CD", DataTypes.Character, 4);
                AddControl(ReportSection.REPORT, "COMMA", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "INDEXED.F040_OMA_FEE_MSTR.FEE_DESC", DataTypes.Character, 48);
                AddControl(ReportSection.REPORT, "FEE_EFFECTIVE_DATE", DataTypes.Numeric, 8);
                AddControl(ReportSection.REPORT, "INDEXED.F040_OMA_FEE_MSTR.FEE_CURR_H_FEE_1", DataTypes.Numeric, 7);
                AddControl(ReportSection.REPORT, "INDEXED.F040_OMA_FEE_MSTR.FEE_CURR_H_FEE_2", DataTypes.Numeric, 7);
                AddControl(ReportSection.REPORT, "INDEXED.F040_OMA_FEE_MSTR.FEE_CURR_H_ANAE", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "INDEXED.F040_OMA_FEE_MSTR.FEE_CURR_H_ASST", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "INDEXED.F040_OMA_FEE_MSTR.FEE_ACTIVE_FOR_ENTRY", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "INDEXED.F040_OMA_FEE_MSTR.FEE_DIAG_IND", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "INDEXED.F040_OMA_FEE_MSTR.FEE_ADMIT_IND", DataTypes.Character, 1);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-05-16 12:43:34 PM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            // TODO: Remove duplicate controls, if there are any.
            switch (strControl)
            {
                case "FEE_OMA_CD":
                    return Common.StringToField(F040_OMA_FEE_MSTR_FEE_OMA_CD(), intSize);
                case "COMMA":
                    return Common.StringToField(COMMA(), intSize);
                case "INDEXED.F040_OMA_FEE_MSTR.FEE_DESC":
                    return Common.StringToField(rdrF040_OMA_FEE_MSTR.GetString("FEE_DESC"));
                case "FEE_EFFECTIVE_DATE":
                    return F040_OMA_FEE_MSTR_FEE_EFFECTIVE_DATE().ToString();
                case "INDEXED.F040_OMA_FEE_MSTR.FEE_CURR_H_FEE_1":
                    return rdrF040_OMA_FEE_MSTR.GetNumber("FEE_CURR_H_FEE_1").ToString();
                case "INDEXED.F040_OMA_FEE_MSTR.FEE_CURR_H_FEE_2":
                    return rdrF040_OMA_FEE_MSTR.GetNumber("FEE_CURR_H_FEE_2").ToString();
                case "INDEXED.F040_OMA_FEE_MSTR.FEE_CURR_H_ANAE":
                    return rdrF040_OMA_FEE_MSTR.GetNumber("FEE_CURR_H_ANAE").ToString();
                case "INDEXED.F040_OMA_FEE_MSTR.FEE_CURR_H_ASST":
                    return rdrF040_OMA_FEE_MSTR.GetNumber("FEE_CURR_H_ASST").ToString();
                case "INDEXED.F040_OMA_FEE_MSTR.FEE_ACTIVE_FOR_ENTRY":
                    return Common.StringToField(rdrF040_OMA_FEE_MSTR.GetString("FEE_ACTIVE_FOR_ENTRY"));
                case "INDEXED.F040_OMA_FEE_MSTR.FEE_DIAG_IND":
                    return Common.StringToField(rdrF040_OMA_FEE_MSTR.GetString("FEE_DIAG_IND"));
                case "INDEXED.F040_OMA_FEE_MSTR.FEE_ADMIT_IND":
                    return Common.StringToField(rdrF040_OMA_FEE_MSTR.GetString("FEE_ADMIT_IND"));
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
