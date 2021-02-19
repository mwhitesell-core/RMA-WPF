//  DOC: RMAPRICE.QZS
//  DOC: FILE TO BE UPLOADED TO WEB SITE FOR RMA PRICING
//  DOC: RUN FOR: WEBSITE BILLING
//  PROGRAM PURPOSE :
//  DATE       BY WHOM   DESCRIPTION
//  97/09/10   YASEMIN   ORIGINAL
using Core.DataAccess.SqlServer;
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
    public class RMAPRICE : BaseRDLClass
    {
        protected const string REPORT_NAME = "RMAPRICE";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrF002_SUSPEND_DTL = new Reader();
        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                //  Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;
                Sort = "CLMDTL_DOC_OHIP_NBR ASC, CLMDTL_ACCOUNTING_NBR ASC";
                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return ReportData;
        }
        private void Access_F002_SUSPEND_DTL()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);
            strSQL.Append("SELECT ");
            strSQL.Append("CLMDTL_FEE_OHIP, ");
            strSQL.Append("CLMDTL_AMT_TECH_BILLED, ");
            strSQL.Append("CLMDTL_ACCOUNTING_NBR, ");
            strSQL.Append("CLMDTL_OMA_CD, ");
            strSQL.Append("CLMDTL_OMA_SUFF, ");
            strSQL.Append("CLMDTL_SV_YY, ");
            strSQL.Append("CLMDTL_SV_MM, ");
            strSQL.Append("CLMDTL_SV_DD, ");
            strSQL.Append("CLMDTL_NBR_SERV, ");
            strSQL.Append("CLMDTL_FEE_OMA, ");
            strSQL.Append("CLMDTL_DOC_OHIP_NBR ");
            strSQL.Append("FROM INDEXED.F002_SUSPEND_DTL ");

            strSQL.Append(Choose());

            rdrF002_SUSPEND_DTL.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
    
        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(string.Empty);

            return strChoose.ToString();
        }
    
        private string X_ZEROES()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = "000000000000000000";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return strReturnValue;
        }
    
        private decimal X_CR()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = 13;
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return decReturnValue;
        }
    
        private string X_CARRIAGE_RETURN()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = QDesign.Substring(QDesign.Characters(X_CR()), 2, 1);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return strReturnValue;
        }
    
        private string X_PROF_AMT_BILLED()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = QDesign.ASCII(rdrF002_SUSPEND_DTL.GetNumber("CLMDTL_FEE_OHIP") - rdrF002_SUSPEND_DTL.GetNumber("CLMDTL_AMT_TECH_BILLED"), 6);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return strReturnValue;
        }
    
        private string F002_SUSPEND_DTL_CLMDTL_SV_DATE()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = QDesign.ASCII(rdrF002_SUSPEND_DTL.GetNumber("CLMDTL_SV_YY")) + QDesign.ASCII(rdrF002_SUSPEND_DTL.GetNumber("CLMDTL_SV_MM"), 2) + QDesign.ASCII(rdrF002_SUSPEND_DTL.GetNumber("CLMDTL_SV_DD"), 2);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return strReturnValue;
        }

        private string CLMDTL_NBR_SERV_ALPHA()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = QDesign.ASCII(rdrF002_SUSPEND_DTL.GetNumber("CLMDTL_NBR_SERV"), 2);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.REPORT, "INDEXED.F002_SUSPEND_DTL.CLMDTL_ACCOUNTING_NBR", DataTypes.Character, 8);
                AddControl(ReportSection.REPORT, "INDEXED.F002_SUSPEND_DTL.CLMDTL_OMA_CD", DataTypes.Character, 4);
                AddControl(ReportSection.REPORT, "INDEXED.F002_SUSPEND_DTL.CLMDTL_OMA_SUFF", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "INDEXED.F002_SUSPEND_DTL.CLMDTL_FEE_OHIP", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "CLMDTL_SV_DATE", DataTypes.Character, 8);
                AddControl(ReportSection.REPORT, "CLMDTL_NBR_SERV_ALPHA", DataTypes.Character, 2);
                AddControl(ReportSection.REPORT, "INDEXED.F002_SUSPEND_DTL.CLMDTL_FEE_OMA", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "INDEXED.F002_SUSPEND_DTL.CLMDTL_AMT_TECH_BILLED", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "X_PROF_AMT_BILLED", DataTypes.Character, 6);
                AddControl(ReportSection.REPORT, "INDEXED.F002_SUSPEND_DTL.CLMDTL_DOC_OHIP_NBR", DataTypes.Numeric, 6);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
    
        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-05-16 9:44:53 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "INDEXED.F002_SUSPEND_DTL.CLMDTL_ACCOUNTING_NBR":
                    return Common.StringToField(rdrF002_SUSPEND_DTL.GetString("CLMDTL_ACCOUNTING_NBR"));

                case "INDEXED.F002_SUSPEND_DTL.CLMDTL_OMA_CD":
                    return Common.StringToField(rdrF002_SUSPEND_DTL.GetString("CLMDTL_OMA_CD"));

                case "INDEXED.F002_SUSPEND_DTL.CLMDTL_OMA_SUFF":
                    return Common.StringToField(rdrF002_SUSPEND_DTL.GetString("CLMDTL_OMA_SUFF"));

                case "INDEXED.F002_SUSPEND_DTL.CLMDTL_FEE_OHIP":
                    return rdrF002_SUSPEND_DTL.GetNumber("CLMDTL_FEE_OHIP").ToString();

                case "CLMDTL_SV_DATE":
                    return Common.StringToField(F002_SUSPEND_DTL_CLMDTL_SV_DATE(), intSize);

                case "CLMDTL_NBR_SERV_ALPHA":
                    return Common.StringToField(CLMDTL_NBR_SERV_ALPHA(), intSize);

                case "INDEXED.F002_SUSPEND_DTL.CLMDTL_FEE_OMA":
                    return rdrF002_SUSPEND_DTL.GetNumber("CLMDTL_FEE_OMA").ToString();

                case "INDEXED.F002_SUSPEND_DTL.CLMDTL_AMT_TECH_BILLED":
                    return rdrF002_SUSPEND_DTL.GetNumber("CLMDTL_AMT_TECH_BILLED").ToString();

                case "INDEXED.F002_SUSPEND_DTL.CLMDTL_DOC_OHIP_NBR":
                    return rdrF002_SUSPEND_DTL.GetNumber("CLMDTL_DOC_OHIP_NBR").ToString();

                case "X_PROF_AMT_BILLED":
                    return Common.StringToField(X_PROF_AMT_BILLED(), intSize);

                default:
                    return string.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                Access_F002_SUSPEND_DTL();
                while (rdrF002_SUSPEND_DTL.Read())
                {
                    WriteData();
                }
            
                rdrF002_SUSPEND_DTL.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrF002_SUSPEND_DTL == null))
            {
                rdrF002_SUSPEND_DTL.Close();
                rdrF002_SUSPEND_DTL = null;
            }
        }
    }
}
