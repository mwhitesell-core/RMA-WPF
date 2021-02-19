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
    public class AUDITDOC2 : BaseRDLClass 
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "AUDITDOC2";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrAUDITDOC = new Reader();

        #endregion

        #region " Renaissance Data "

        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug) {
            try
            {
                //  Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;
                Sort = "DOC_FULL_PART_IND ASC";
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

        private void Access_AUDITDOC()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);
            
            strSQL.Append("SELECT ");
            strSQL.Append("DOC_FULL_PART_IND, ");
            strSQL.Append("X_IND ");
            strSQL.Append("FROM TEMPORARYDATA.AUDITDOC ");

            strSQL.Append(Choose());

            rdrAUDITDOC.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);

            strSQL = null;
        }

        #endregion

        #region " CHOOSE "

        private string Choose() {
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
                 AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.AUDITDOC.DOC_FULL_PART_IND", DataTypes.Character, 1);
                 AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.AUDITDOC.X_IND", DataTypes.Character, 18);
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
        // # Do not delete, modify or move it.  Updated: 2018-05-09 7:36:50 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl) {
                case "TEMPORARYDATA.AUDITDOC.DOC_FULL_PART_IND":
                    return Common.StringToField(rdrAUDITDOC.GetString("DOC_FULL_PART_IND"));

                case "TEMPORARYDATA.AUDITDOC.X_IND":
                    return Common.StringToField(rdrAUDITDOC.GetString("X_IND"));

                default:
                    return string.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                Access_AUDITDOC();
                while (rdrAUDITDOC.Read()) {
                    WriteData();
                }
            
                rdrAUDITDOC.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if ((rdrAUDITDOC != null)) {
                rdrAUDITDOC.Close();
                rdrAUDITDOC = null;
            }
        }

        #endregion

        #endregion
    }
}
