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
    public class R021A_3 : BaseRDLClass
    {
        protected const string REPORT_NAME = "R021A_3";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrR021A = new Reader();
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
        private void Access_R021A()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: If * is not used to select all columns, ensure the necessary columns (i.e. columns that are used to access records of other tables) are included in the SELECT statement
            strSQL.Append("SELECT ");
            strSQL.Append("RAT_RMB_GROUP_NBR, ");
            strSQL.Append("RAT_RMB_ACCOUNT_NBR, ");
            strSQL.Append("RAT_RMB_ERROR_H_CD_1, ");
            strSQL.Append("RAT_RMB_ERROR_H_CD_2, ");
            strSQL.Append("RAT_RMB_ERROR_H_CD_3, ");
            strSQL.Append("RAT_RMB_ERROR_H_CD_4, ");
            strSQL.Append("RAT_RMB_ERROR_H_CD_5, ");
            strSQL.Append("RAT_RMB_ERROR_T_CD_1, ");
            strSQL.Append("RAT_RMB_ERROR_T_CD_2, ");
            strSQL.Append("RAT_RMB_ERROR_T_CD_3, ");
            strSQL.Append("RAT_RMB_ERROR_T_CD_4, ");
            strSQL.Append("RAT_RMB_ERROR_T_CD_5, ");
            strSQL.Append("RAT_RMB_PROCESS_DATE, ");
            strSQL.Append("RAT_RMB_FILE_NAME ");
            strSQL.Append("FROM TEMPORARYDATA.R021A ");
            strSQL.Append(Choose());
            rdrR021A.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
            strSQL = null;
        }

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(String.Empty);
            // TODO: CHOOSE Statement - May require manual changes.
            return strChoose.ToString().ToString();
        }
        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R021A.RAT_RMB_ACCOUNT_NBR", DataTypes.Character, 8);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R021A.RAT_RMB_ERROR_H_CD_1", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R021A.RAT_RMB_ERROR_H_CD_2", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R021A.RAT_RMB_ERROR_H_CD_3", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R021A.RAT_RMB_ERROR_H_CD_4", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R021A.RAT_RMB_ERROR_H_CD_5", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R021A.RAT_RMB_ERROR_T_CD_1", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R021A.RAT_RMB_ERROR_T_CD_2", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R021A.RAT_RMB_ERROR_T_CD_3", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R021A.RAT_RMB_ERROR_T_CD_4", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R021A.RAT_RMB_ERROR_T_CD_5", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R021A.RAT_RMB_FILE_NAME", DataTypes.Character, 12);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R021A.RAT_RMB_GROUP_NBR", DataTypes.Character, 4);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R021A.RAT_RMB_PROCESS_DATE", DataTypes.Numeric, 8);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2019-01-29 10:23:44 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            // TODO: Remove duplicate controls, if there are any.
            switch (strControl)
            {
                case "TEMPORARYDATA.R021A.RAT_RMB_ACCOUNT_NBR":
                    return Common.StringToField(rdrR021A.GetString("RAT_RMB_ACCOUNT_NBR"));
                case "TEMPORARYDATA.R021A.RAT_RMB_ERROR_H_CD_1":
                    return Common.StringToField(rdrR021A.GetString("RAT_RMB_ERROR_H_CD_1"));
                case "TEMPORARYDATA.R021A.RAT_RMB_ERROR_H_CD_2":
                    return Common.StringToField(rdrR021A.GetString("RAT_RMB_ERROR_H_CD_2"));
                case "TEMPORARYDATA.R021A.RAT_RMB_ERROR_H_CD_3":
                    return Common.StringToField(rdrR021A.GetString("RAT_RMB_ERROR_H_CD_3"));
                case "TEMPORARYDATA.R021A.RAT_RMB_ERROR_H_CD_4":
                    return Common.StringToField(rdrR021A.GetString("RAT_RMB_ERROR_H_CD_4"));
                case "TEMPORARYDATA.R021A.RAT_RMB_ERROR_H_CD_5":
                    return Common.StringToField(rdrR021A.GetString("RAT_RMB_ERROR_H_CD_5"));
                case "TEMPORARYDATA.R021A.RAT_RMB_ERROR_T_CD_1":
                    return Common.StringToField(rdrR021A.GetString("RAT_RMB_ERROR_T_CD_1"));
                case "TEMPORARYDATA.R021A.RAT_RMB_ERROR_T_CD_2":
                    return Common.StringToField(rdrR021A.GetString("RAT_RMB_ERROR_T_CD_2"));
                case "TEMPORARYDATA.R021A.RAT_RMB_ERROR_T_CD_3":
                    return Common.StringToField(rdrR021A.GetString("RAT_RMB_ERROR_T_CD_3"));
                case "TEMPORARYDATA.R021A.RAT_RMB_ERROR_T_CD_4":
                    return Common.StringToField(rdrR021A.GetString("RAT_RMB_ERROR_T_CD_4"));
                case "TEMPORARYDATA.R021A.RAT_RMB_ERROR_T_CD_5":
                    return Common.StringToField(rdrR021A.GetString("RAT_RMB_ERROR_T_CD_5"));
                case "TEMPORARYDATA.R021A.RAT_RMB_FILE_NAME":
                    return Common.StringToField(rdrR021A.GetString("RAT_RMB_FILE_NAME"));
                case "TEMPORARYDATA.R021A.RAT_RMB_GROUP_NBR":
                    return Common.StringToField(rdrR021A.GetString("RAT_RMB_GROUP_NBR"));
                case "TEMPORARYDATA.R021A.RAT_RMB_PROCESS_DATE":
                    return rdrR021A.GetNumber("RAT_RMB_PROCESS_DATE").ToString();
                default:
                    return String.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                // TODO: Some manual steps maybe required.
                Access_R021A();
                while (rdrR021A.Read())
                {
                    WriteData();
                }
                rdrR021A.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrR021A == null))
            {
                rdrR021A.Close();
                rdrR021A = null;
            }
        }
    }
}
