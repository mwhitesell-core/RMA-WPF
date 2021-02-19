//  Program: r716c1.qzs
//  Purpose: To create a flat file of modified description records to upload
//  back to the web
//  - this pgm reads the subfile of concatenated desriptions
//  and creates a text file readable by the web pgms
//  - note a 2nd pass creates an error file if any of the comments
//  were lost (due to limit of writing out 264 max characters
//  if the full 255 bytes of text were used the last 5 characters
//  would be lost - it`s assumed that this won`t happend often, if ever)
//  Modification History
//  YY/MMM/DD  who  Why
//  00/oct/05  B.E. - original
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
    public class R716C1 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R716C1";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrU716C2 = new Reader();

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
                Sort = "CLMHDR_DOC_OHIP_NBR ASC, CLMHDR_ACCOUNTING_NBR ASC";
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

        private void Access_U716C2()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("CLMDTL_DOC_OHIP_NBR, ");
            strSQL.Append("CLMDTL_ACCOUNTING_NBR, ");
            strSQL.Append("X_TEXT ");
            strSQL.Append("FROM TEMPORARYDATA.U716C2 ");

            strSQL.Append(Choose());

            rdrU716C2.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
            strSQL = null;
        }

        #endregion

        #region " CHOOSE "

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(string.Empty);

            return strChoose.ToString().ToString();
        }

        #endregion

        #region " SELECT IF "

        #endregion

        #region " DEFINES "

        private decimal X_CLMHDR_DOC_OHIP_NBR()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = rdrU716C2.GetNumber("CLMDTL_DOC_OHIP_NBR");
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return decReturnValue;
        }
    
        private string X_DESC()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = QDesign.Substring(rdrU716C2.GetString("X_TEXT"), 1, 250);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return strReturnValue;
        }

        #endregion

        #region " CONTROLS "

        public override void DeclareReportControls()
        {
            try
            {
                 AddControl(ReportSection.REPORT, "X_CLMHDR_DOC_OHIP_NBR", DataTypes.Numeric, 6);
                 AddControl(ReportSection.REPORT, "CLMHDR_ACCOUNTING_NBR", DataTypes.Character, 8);
                 AddControl(ReportSection.REPORT, "X_DESC", DataTypes.Character, 250);
                 AddControl(ReportSection.REPORT, "CLMHDR_DOC_OHIP_NBR", DataTypes.Character, 6);
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
        // # Do not delete, modify or move it.  Updated: 2018-05-16 9:44:55 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "X_CLMHDR_DOC_OHIP_NBR":
                    return X_CLMHDR_DOC_OHIP_NBR().ToString();

                case "CLMHDR_ACCOUNTING_NBR":
                    return Common.StringToField(rdrU716C2.GetString("CLMDTL_ACCOUNTING_NBR"));

                case "X_DESC":
                    return Common.StringToField(X_DESC(), intSize);

                case "CLMHDR_DOC_OHIP_NBR":
                    return Common.StringToField(rdrU716C2.GetString("CLMDTL_DOC_OHIP_NBR"));

                default:
                    return string.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                Access_U716C2();
                while (rdrU716C2.Read())
                {
                    WriteData();
                }
            
                rdrU716C2.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrU716C2 == null))
            {
                rdrU716C2.Close();
                rdrU716C2 = null;
            }
        }

        #endregion

        #endregion
    }
}
