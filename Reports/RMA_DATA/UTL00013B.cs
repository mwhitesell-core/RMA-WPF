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
    public class UTL00013B : BaseRDLClass
    {
        protected const string REPORT_NAME = "UTL00013B";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrUTL00013A = new Reader();
        private Reader rdrF002_CLAIMS_MSTR_DTL = new Reader();
        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                //  Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;
                Sort = "CLM_ID ASC, CLMDTL_SV_DATE ASC";
                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return ReportData;
        }
        private void Access_UTL00013A()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("KEY_CLM_BATCH_NBR, ");
            strSQL.Append("KEY_CLM_CLAIM_NBR, ");
            strSQL.Append("X_BALANCE, ");
            strSQL.Append("CLM_ID ");
            strSQL.Append("FROM TEMPORARYDATA.UTL00013A ");

            strSQL.Append(Choose());

            rdrUTL00013A.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
            strSQL = null;
        }

        private void Link_F002_CLAIMS_MSTR_DTL()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
			strSQL.Append("CLMDTL_OMA_CD, ");
            strSQL.Append("CLMDTL_SV_YY, ");
            strSQL.Append("CLMDTL_SV_MM, ");
            strSQL.Append("CLMDTL_SV_DD ");
            strSQL.Append("FROM INDEXED.F002_CLAIMS_MSTR_DTL ");
            strSQL.Append("WHERE ");
            strSQL.Append("KEY_CLM_TYPE = ").Append(Common.StringToField("B"));
            strSQL.Append(" AND KEY_CLM_BATCH_NBR = ").Append(Common.StringToField(rdrUTL00013A.GetString("KEY_CLM_BATCH_NBR")));
            strSQL.Append(" AND KEY_CLM_CLAIM_NBR = ").Append(rdrUTL00013A.GetNumber("KEY_CLM_CLAIM_NBR"));

            rdrF002_CLAIMS_MSTR_DTL.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
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
            if (((QDesign.NULL(rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_OMA_CD")) != "0000")
                        && ((QDesign.NULL(rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_OMA_CD")) != "ZZZZ") 
                        && (QDesign.NULL(rdrUTL00013A.GetNumber("X_BALANCE")) != QDesign.NULL(0d)))))
            {
                blnSelected = true;
            }
        
            return blnSelected;
        }
    
        private decimal F002_CLAIMS_MSTR_CLMDTL_SV_DATE()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = QDesign.NConvert(QDesign.ASCII(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_SV_YY"), 4) + QDesign.ASCII(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_SV_MM"), 2) + QDesign.ASCII(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_SV_DD"), 2));
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
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.UTL00013A.CLM_ID", DataTypes.Character, 10);
                 AddControl(ReportSection.REPORT, "CLMDTL_SV_DATE", DataTypes.Numeric, 8);
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.UTL00013A.X_BALANCE", DataTypes.Numeric, 7);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
    
        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-05-16 12:45:40 PM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "TEMPORARYDATA.UTL00013A.CLM_ID":
                    return Common.StringToField(rdrUTL00013A.GetString("CLM_ID"));

                case "CLMDTL_SV_DATE":
                    return F002_CLAIMS_MSTR_CLMDTL_SV_DATE().ToString();

                case "TEMPORARYDATA.UTL00013A.X_BALANCE":
                    return rdrUTL00013A.GetNumber("X_BALANCE").ToString();

                default:
                    return string.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                Access_UTL00013A();
                while (rdrUTL00013A.Read())
                {
                    Link_F002_CLAIMS_MSTR_DTL();
                    while (rdrF002_CLAIMS_MSTR_DTL.Read())
                    {
                        WriteData();
                    }
                    rdrF002_CLAIMS_MSTR_DTL.Close();
                }
                rdrUTL00013A.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrUTL00013A == null))
            {
                rdrUTL00013A.Close();
                rdrUTL00013A = null;
            }
        
            if (!(rdrF002_CLAIMS_MSTR_DTL == null))
            {
                rdrF002_CLAIMS_MSTR_DTL.Close();
                rdrF002_CLAIMS_MSTR_DTL = null;
            }
        }
    }
}
