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
    public class YASCLARE_3 : BaseRDLClass
    {
        protected const string REPORT_NAME = "YASCLARE_3";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrCLARE2 = new Reader();
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
        private void Access_CLARE2()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT * ");
            strSQL.Append("FROM TEMPORARYDATA.CLARE2 ");

            strSQL.Append(Choose());

            rdrCLARE2.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
            strSQL = null;
        }
    
        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(string.Empty);

            return strChoose.ToString().ToString();
        }
    
        public override bool SelectIf()
        {
            bool blnSelected = false;
            if ((QDesign.NULL(rdrCLARE2.GetString("DOC_NBR")) == "Y37") 
                        || (QDesign.NULL(rdrCLARE2.GetString("DOC_NBR")) == "V13"))
            {
                blnSelected = true;
            }
        
            return blnSelected;
        }
        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.CLARE2.DOC_DEPT", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.CLARE2.COMMA", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.CLARE2.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.CLARE2.DOC_NAME", DataTypes.Character, 24);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.CLARE2.DOC_INITS", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.CLARE2.X_18", DataTypes.Numeric, 9);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.CLARE2.X_18_PLUS", DataTypes.Numeric, 9);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.CLARE2.X_ALL", DataTypes.Numeric, 9);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
    
        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-07-30 10:52:24 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "TEMPORARYDATA.CLARE2.DOC_DEPT":
                    return rdrCLARE2.GetNumber("DOC_DEPT").ToString();

                case "TEMPORARYDATA.CLARE2.COMMA":
                    return Common.StringToField(rdrCLARE2.GetString("COMMA"));

                case "TEMPORARYDATA.CLARE2.DOC_NBR":
                    return Common.StringToField(rdrCLARE2.GetString("DOC_NBR"));

                case "TEMPORARYDATA.CLARE2.DOC_NAME":
                    return Common.StringToField(rdrCLARE2.GetString("DOC_NAME"));

                case "TEMPORARYDATA.CLARE2.DOC_INITS":
                    return Common.StringToField(rdrCLARE2.GetString("DOC_INITS"));

                case "TEMPORARYDATA.CLARE2.X_18":
                    return rdrCLARE2.GetNumber("X_18").ToString();

                case "TEMPORARYDATA.CLARE2.X_18_PLUS":
                    return rdrCLARE2.GetNumber("X_18_PLUS").ToString();

                case "TEMPORARYDATA.CLARE2.X_ALL":
                    return rdrCLARE2.GetNumber("X_ALL").ToString();

                default:
                    return string.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                Access_CLARE2();
                while (rdrCLARE2.Read())
                {
                    WriteData();
                }
            
                rdrCLARE2.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrCLARE2 == null))
            {
                rdrCLARE2.Close();
                rdrCLARE2 = null;
            }
        }
    }
}
