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
    public class DUMP_TECH2 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "DUMP_TECH2";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrDUMP_TECH = new Reader();

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

        private void Access_DUMP_TECH()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("CLMDTL_DOC_OHIP_NBR, ");
            strSQL.Append("CLMDTL_ACCOUNTING_NBR, ");
            strSQL.Append("CLMDTL_OMA_CD, ");
            strSQL.Append("CLMDTL_OMA_SUFF, ");
            strSQL.Append("CLMDTL_NBR_SERV, ");
            strSQL.Append("CLMDTL_AMT_TECH_BILLED, ");
            strSQL.Append("CLMDTL_FEE_OMA, ");
            strSQL.Append("CLMDTL_FEE_OHIP ");
            strSQL.Append("FROM TEMPORARYDATA.DUMP_TECH ");

            strSQL.Append(Choose());

            rdrDUMP_TECH.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
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

        public override void DeclareReportControls()
        {
            try
            {
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.DUMP_TECH.DOC_NBR", DataTypes.Character, 3);
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.DUMP_TECH.CLMDTL_DOC_OHIP_NBR", DataTypes.Numeric, 6);
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.DUMP_TECH.CLMDTL_ACCOUNTING_NBR", DataTypes.Character, 8);
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.DUMP_TECH.CLMDTL_OMA_CD", DataTypes.Character, 4);
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.DUMP_TECH.CLMDTL_OMA_SUFF", DataTypes.Character, 1);
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.DUMP_TECH.CLMDTL_NBR_SERV", DataTypes.Numeric, 2);
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.DUMP_TECH.CLMDTL_AMT_TECH_BILLED", DataTypes.Numeric, 6);
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.DUMP_TECH.CLMDTL_FEE_OMA", DataTypes.Numeric, 7);
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.DUMP_TECH.CLMDTL_FEE_OHIP", DataTypes.Numeric, 7);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        #endregion

        #region " DEFINES "

        #endregion

        #region " CONTROLS "

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-05-09 9:52:33 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "TEMPORARYDATA.DUMP_TECH.DOC_NBR":
                    return Common.StringToField(rdrDUMP_TECH.GetString("DOC_NBR"));

                case "TEMPORARYDATA.DUMP_TECH.CLMDTL_DOC_OHIP_NBR":
                    return rdrDUMP_TECH.GetNumber("CLMDTL_DOC_OHIP_NBR").ToString();

                case "TEMPORARYDATA.DUMP_TECH.CLMDTL_ACCOUNTING_NBR":
                    return Common.StringToField(rdrDUMP_TECH.GetString("CLMDTL_ACCOUNTING_NBR"));

                case "TEMPORARYDATA.DUMP_TECH.CLMDTL_OMA_CD":
                    return Common.StringToField(rdrDUMP_TECH.GetString("CLMDTL_OMA_CD"));

                case "TEMPORARYDATA.DUMP_TECH.CLMDTL_OMA_SUFF":
                    return Common.StringToField(rdrDUMP_TECH.GetString("CLMDTL_OMA_SUFF"));

                case "TEMPORARYDATA.DUMP_TECH.CLMDTL_NBR_SERV":
                    return rdrDUMP_TECH.GetNumber("CLMDTL_NBR_SERV").ToString();

                case "TEMPORARYDATA.DUMP_TECH.CLMDTL_AMT_TECH_BILLED":
                    return rdrDUMP_TECH.GetNumber("CLMDTL_AMT_TECH_BILLED").ToString();

                case "TEMPORARYDATA.DUMP_TECH.CLMDTL_FEE_OMA":
                    return rdrDUMP_TECH.GetNumber("CLMDTL_FEE_OMA").ToString();

                case "TEMPORARYDATA.DUMP_TECH.CLMDTL_FEE_OHIP":
                    return rdrDUMP_TECH.GetNumber("CLMDTL_FEE_OHIP").ToString();

                default:
                    return string.Empty;
            }
        }

        #endregion

        #region " Renaissance Precompiler Generated Code "

        public override void AccessData()
        {
            try
            {
                Access_DUMP_TECH();
                while (rdrDUMP_TECH.Read())
                {
                    WriteData();
                }
            
                rdrDUMP_TECH.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrDUMP_TECH == null))
            {
                rdrDUMP_TECH.Close();
                rdrDUMP_TECH = null;
            }
        }

        #endregion

        #endregion
    }
}
