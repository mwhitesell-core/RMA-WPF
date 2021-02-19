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
    public class K037_CODE : BaseRDLClass
    {
        protected const string REPORT_NAME = "K037_CODE";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrK037A = new Reader();
        private Reader rdrF020_DOCTOR_MSTR = new Reader();
        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                //  Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;
                Sort = "X_CLINIC ASC, DOC_NAME ASC";
                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return ReportData;
        }
        private void Access_K037A()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("LINE ");
            strSQL.Append("FROM TEMPORARYDATA.K037A ");

            strSQL.Append(Choose());

            rdrK037A.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
            strSQL = null;
        }
        private void Link_F020_DOCTOR_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR ");
            strSQL.Append("FROM INDEXED.F020_DOCTOR_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_NBR = ").Append(Common.StringToField(QDesign.Substring(rdrK037A.GetString("LINE"), 7, 3)));

            rdrF020_DOCTOR_MSTR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
    
        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(string.Empty);

            return strChoose.ToString();
        }

        private string X_CLINIC()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = QDesign.Substring(rdrK037A.GetString("LINE"), 1, 2);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private decimal DOC_DEPT()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = QDesign.NConvert(QDesign.Substring(rdrK037A.GetString("LINE"), 4, 2));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private string X_DOC()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = QDesign.Substring(rdrK037A.GetString("LINE"), 7, 3);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string DOC_NAME()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = QDesign.Substring(rdrK037A.GetString("LINE"), 11, 24);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string DOC_INITS()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = QDesign.Substring(rdrK037A.GetString("LINE"), 36, 3);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private decimal X_K037()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = QDesign.NConvert(QDesign.Substring(rdrK037A.GetString("LINE"), 40, 7));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private string CLMHDR_LOC()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = QDesign.Substring(rdrK037A.GetString("LINE"), 56, 4);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }


        public override void DeclareReportControls() {
            try
            {
                 AddControl(ReportSection.FOOTING_AT, "X_CLINIC", DataTypes.Character, 2);
                 AddControl(ReportSection.FOOTING_AT, "DOC_DEPT", DataTypes.Numeric, 2);
                 AddControl(ReportSection.FOOTING_AT, "X_DOC", DataTypes.Character, 3);
                 AddControl(ReportSection.FOOTING_AT, "DOC_NAME", DataTypes.Character, 24);
                 AddControl(ReportSection.FOOTING_AT, "DOC_INITS", DataTypes.Character, 3);
                 AddControl(ReportSection.FOOTING_AT, "X_K037", DataTypes.Numeric, 8);
                 AddControl(ReportSection.FOOTING_AT, "CLMHDR_LOC", DataTypes.Character, 4);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
    
        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-07-30 10:52:25 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {

                case "X_CLINIC":
                    return Common.StringToField(X_CLINIC(), intSize);

                case "DOC_DEPT":
                    return DOC_DEPT().ToString();

                case "X_DOC":
                    return Common.StringToField(X_DOC(), intSize);

                case "DOC_NAME":
                    return Common.StringToField(DOC_NAME(), intSize);

                case "DOC_INITS":
                    return Common.StringToField(DOC_INITS(), intSize);

                case "X_K037":
                    return X_K037().ToString();

                case "CLMHDR_LOC":
                    return Common.StringToField(CLMHDR_LOC());

                default:
                    return string.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                Access_K037A();
                while (rdrK037A.Read())
                {
                    Link_F020_DOCTOR_MSTR();
                    while (rdrF020_DOCTOR_MSTR.Read())
                    {
                        WriteData();
                    }
                
                    rdrF020_DOCTOR_MSTR.Close();
                }
            
                rdrK037A.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrK037A == null))
            {
                rdrK037A.Close();
                rdrK037A = null;
            }
        
            if (!(rdrF020_DOCTOR_MSTR == null))
            {
                rdrF020_DOCTOR_MSTR.Close();
                rdrF020_DOCTOR_MSTR = null;
            }
        }
    }
}
