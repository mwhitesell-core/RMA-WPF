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
    public class GERIATRIC : BaseRDLClass
    {
        protected const string REPORT_NAME = "GERIATRIC";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrGERIATRIC2 = new Reader();
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
                Sort = "X_CLINIC, DOC_NAME";
                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return ReportData;
        }
        private void Access_GERIATRIC2()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("LINE ");
            strSQL.Append("FROM TEMPORARYDATA.GERIATRIC2 ");

            strSQL.Append(Choose());

            rdrGERIATRIC2.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
            strSQL = null;
        }
        private void Link_F020_DOCTOR_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NAME, ");
            strSQL.Append("DOC_INIT1, ");
            strSQL.Append("DOC_INIT2, ");
            strSQL.Append("DOC_INIT3 ");
            strSQL.Append("FROM INDEXED.F020_DOCTOR_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_NBR = ").Append(Common.StringToField(QDesign.Substring(rdrGERIATRIC2.GetString("LINE"), 21, 3)));

            rdrF020_DOCTOR_MSTR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
    
        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(string.Empty);

            return strChoose.ToString();
        }

        private string DOC_INITS()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = rdrF020_DOCTOR_MSTR.GetString("DOC_INIT1") + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT2") + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT3");
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_CLINIC()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = QDesign.Substring(rdrGERIATRIC2.GetString("LINE"), 18, 2);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_DOC()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = QDesign.Substring(rdrGERIATRIC2.GetString("LINE"), 21, 3);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private decimal X_CLMDTL_FEE_OHIP_1()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = QDesign.NConvert(QDesign.Substring(rdrGERIATRIC2.GetString("LINE"), 80, 7));
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
                 AddControl(ReportSection.FOOTING_AT, "X_CLINIC", DataTypes.Character, 2);
                 AddControl(ReportSection.FOOTING_AT, "X_DOC", DataTypes.Character, 3);
                 AddControl(ReportSection.FOOTING_AT, "INDEXED.F020_DOCTOR_MSTR.DOC_NAME", DataTypes.Character, 24);
                 AddControl(ReportSection.FOOTING_AT, "DOC_INITS", DataTypes.Character, 3);
                 AddControl(ReportSection.FOOTING_AT, "X_CLMDTL_FEE_OHIP_1", DataTypes.Numeric, 7);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "X_CLINIC":
                    return Common.StringToField(X_CLINIC(), intSize);

                case "X_DOC":
                    return Common.StringToField(X_DOC(), intSize);

                case "INDEXED.F020_DOCTOR_MSTR.DOC_NAME":
                    return Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_NAME"));

                case "DOC_INITS":
                    return Common.StringToField(DOC_INITS(), intSize);

                case "X_CLMDTL_FEE_OHIP_1":
                    return X_CLMDTL_FEE_OHIP_1().ToString();

                default:
                    return string.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                Access_GERIATRIC2();
                while (rdrGERIATRIC2.Read())
                {
                    Link_F020_DOCTOR_MSTR();
                    while (rdrF020_DOCTOR_MSTR.Read())
                    {
                        WriteData();
                    }
                
                    rdrF020_DOCTOR_MSTR.Close();
                }
            
                rdrGERIATRIC2.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrGERIATRIC2 == null))
            {
                rdrGERIATRIC2.Close();
                rdrGERIATRIC2 = null;
            }
        
            if (!(rdrF020_DOCTOR_MSTR == null))
            {
                rdrF020_DOCTOR_MSTR.Close();
                rdrF020_DOCTOR_MSTR = null;
            }
        }
    }
}
