#region "Screen Comments"
//  MODIFICATION HISTORY
//  1999/Feb/18          S.B.     - Checked for Y2K.

#endregion

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
    public class DUMPF119 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "DUMPF119";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrF119 = new Reader();

        #endregion

        #region " Renaissance Data "

        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                // Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;

                Sort = "DOC_NBR, COMP_CODE_GROUP, REPORTING_SEQ";

                // Start report data processing.
                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return ReportData;
        }

        #endregion

        #region " Renaissance Statements "

        #region " ACCESS "

        private void Access_F119()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("COMP_CODE, ");
            strSQL.Append("REPORTING_SEQ, ");
            strSQL.Append("COMP_CODE_GROUP, ");
            strSQL.Append("REC_TYPE, ");
            strSQL.Append("X_AMT_NET, ");
            strSQL.Append("X_AMT_GROSS ");
            strSQL.Append("FROM TEMPORARYDATA.F119 ");

            strSQL.Append(Choose());

            rdrF119.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);

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

        #endregion

        #region " CONTROLS "

        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.F119.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.F119.COMP_CODE", DataTypes.Character, 6);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.F119.REPORTING_SEQ", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.F119.COMP_CODE_GROUP", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.F119.X_REC_TYPE", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.F119.X_AMT_NET", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.F119.X_AMT_GROSS", DataTypes.Numeric, 10);
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        #endregion

        #region " Renaissance Precompiler Generated Code "
        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 7/1/2017 2:28:04 PM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "TEMPORARYDATA.F119.DOC_NBR":
                    return Common.StringToField(rdrF119.GetString("DOC_NBR").PadRight(3, ' '));

                case "TEMPORARYDATA.F119.COMP_CODE":
                    return Common.StringToField(rdrF119.GetString("COMP_CODE").PadRight(6, ' '));

                case "TEMPORARYDATA.F119.REPORTING_SEQ":
                    return rdrF119.GetNumber("REPORTING_SEQ").ToString().PadLeft(2, ' ');

                case "TEMPORARYDATA.F119.COMP_CODE_GROUP":
                    return Common.StringToField(rdrF119.GetString("COMP_CODE_GROUP").PadRight(1, ' '));

                case "TEMPORARYDATA.F119.X_REC_TYPE":
                    return Common.StringToField(rdrF119.GetString("REC_TYPE").PadRight(1, ' '));

                case "TEMPORARYDATA.F119.X_AMT_NET":
                    if (Environment.GetEnvironmentVariable("RMABILL_VERS", EnvironmentVariableTarget.Process).ToUpper() == "MP")
                    {
                        return rdrF119.GetNumber("AMT_NET").ToString().PadRight(10, ' ');
                    }
                    else
                    {
                        return rdrF119.GetNumber("X_AMT_NET").ToString().PadRight(10, ' ');
                    }


                case "TEMPORARYDATA.F119.X_AMT_GROSS":
                    if (Environment.GetEnvironmentVariable("RMABILL_VERS", EnvironmentVariableTarget.Process).ToUpper() == "MP")
                    {
                        return rdrF119.GetNumber("AMT_GROSS").ToString().PadRight(10, ' ');
                    }
                    else
                    {
                        return rdrF119.GetNumber("X_AMT_GROSS").ToString().PadRight(10, ' ');
                    }

                default:
                    return string.Empty;




            }
        }

        public override void AccessData()
        {
            try
            {
                Access_F119();

                while (rdrF119.Read())
                {
                    WriteData();
                }
                rdrF119.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrF119 != null))
            {
                rdrF119.Close();
                rdrF119 = null;
            }
        }

        #endregion

        #endregion
    }
}
