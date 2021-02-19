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
    public class U100_B_SRC_PASS3 : BaseRDLClass
    {
        #region "Screen Comments"

        // select for multiple doctors

        #endregion

        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "U100_B__PASS3";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrU100_B2 = new Reader();
        private Reader rdrU100_B_3A = new Reader();

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
                // Create Subfile.
                SubFile = true;
                SubFileName = "U100_B_3A";
                SubFileType = SubFileType.Keep;
                SubFileAT = "";

                Sort = "";

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

        private void Access_U100_B2()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOCTOR_COUNT, ");
            strSQL.Append("DOC_OHIP_NBR, ");
            strSQL.Append("PAYROLL_FLAG, ");
            strSQL.Append("DOC_NAME, ");
            strSQL.Append("PREVIOUS_FISCAL_END_YYMMDD, ");
            strSQL.Append("DOC_SUB_SPECIALTY ");
            strSQL.Append("FROM TEMPORARYDATA.U100_B2 ");

            strSQL.Append(Choose());

            rdrU100_B2.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);

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

        public override bool SelectIf()
        {
            bool blnSelected = false;

            if (QDesign.NULL(rdrU100_B2.GetNumber("DOCTOR_COUNT")) != 1)
            {
                blnSelected = true;
            }

            return blnSelected;
        }

        #endregion

        #region " DEFINES "

        #endregion

        #region " CONTROLS "

        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U100_B2.DOC_OHIP_NBR", DataTypes.Numeric, 6);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U100_B2.DOCTOR_COUNT", DataTypes.Numeric, 6);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U100_B2.PAYROLL_FLAG", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U100_B2.DOC_NAME", DataTypes.Character, 24);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U100_B2.PREVIOUS_FISCAL_END_YYMMDD", DataTypes.Numeric, 8);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U100_B2.DOC_SUB_SPECIALTY", DataTypes.Character, 15);

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
        //# Do not delete, modify or move it.  Updated: 6/7/2017 11:45:00 AM

        public override string ReturnControlValue(string strControl, int intSize)
        {

            switch (strControl)
            {
                case "TEMPORARYDATA.U100_B2.DOC_OHIP_NBR":
                    return rdrU100_B2.GetNumber("DOC_OHIP_NBR").ToString().PadLeft(6, ' ');

                case "TEMPORARYDATA.U100_B2.DOCTOR_COUNT":
                    return rdrU100_B2.GetNumber("DOCTOR_COUNT").ToString().PadLeft(6, ' ');

                case "TEMPORARYDATA.U100_B2.PAYROLL_FLAG":
                    return Common.StringToField(rdrU100_B2.GetString("PAYROLL_FLAG").PadRight(1, ' '));

                case "TEMPORARYDATA.U100_B2.DOC_NAME":
                    return Common.StringToField(rdrU100_B2.GetString("DOC_NAME").PadRight(24, ' '));

                case "TEMPORARYDATA.U100_B2.PREVIOUS_FISCAL_END_YYMMDD":
                    return rdrU100_B2.GetNumber("PREVIOUS_FISCAL_END_YYMMDD").ToString().PadLeft(8, ' ');

                case "TEMPORARYDATA.U100_B2.DOC_SUB_SPECIALTY":
                    return Common.StringToField(rdrU100_B2.GetString("DOC_SUB_SPECIALTY").PadRight(15, ' '));

                default:
                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_U100_B2();

                while (rdrU100_B2.Read())
                {
                    WriteData();
                }
                rdrU100_B2.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrU100_B2 != null))
            {
                rdrU100_B2.Close();
                rdrU100_B2 = null;
            }

            if ((rdrU100_B_3A != null))
            {
                rdrU100_B_3A.Close();
                rdrU100_B_3A = null;
            }
        }

        #endregion

        #endregion
    }
}
