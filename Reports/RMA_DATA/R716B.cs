//  Program: r716a.qzs
//  Purpose: To create a flat file used with the web
//  Modification History
//  YY/MMM/DD  By whom    Why
//  00/jan/01  B.A. - original
//  00/sep/21  B.E.       - picked up actual BI/OP flags from dtl rec
//  - added page length 0, no formfeed
//  00/oct/10  B.E. - deleted records now get transferred back to web
//  - removed access to header (even if header is updated
//  don`t send back any details unless are altered too)
//  note: if the header is `d`eleted then then details
//  don`t need to be sent back 
//  00/oct/18 B.E. - changed select. Since all details are dropped when
//  the header is udpated, we must sent ALL details
//  for UPDATED headers must go back to the web
//  UNLESS they have been  D eleted
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
    public class R716B : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R716B";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrF002_SUSPEND_DTL = new Reader();
        private Reader rdrF002_SUSPEND_HDR = new Reader();

        // #CORE_BEGIN_INCLUDE: DEF_CLMHDR_STATUS"
        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-05-16 9:44:55 AM
        private string CLMHDR_STATUS_COMPLETE()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = "C";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string CLMHDR_STATUS_DELETE()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = "D";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string CLMHDR_STATUS_CANCEL()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = "Y";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string CLMHDR_STATUS_RESUBMIT()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = "R";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string CLMHDR_STATUS_ERROR()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = "X";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string CLMHDR_STATUS_NOT_COMPLETE()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = "N";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string CLMHDR_STATUS_DEFAULT()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = " ";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string UPDATED()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = "U";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string CLMHDR_STATUS_IGNOR()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = "I";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        // #CORE_END_INCLUDE: DEF_CLMHDR_STATUS"
        // #CORE_BEGIN_INCLUDE: DEF_CLMDTL_STATUS"
        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-05-16 9:44:55 AM
        private string CLMDTL_STATUS_DELETE()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = "D";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string CLMDTL_STATUS_NEW()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = "N";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string CLMDTL_STATUS_ACTIVE()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = " ";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string CLMDTL_STATUS_UPDATED()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = "U";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

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

        private void Access_F002_SUSPEND_DTL()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("CLMDTL_DOC_OHIP_NBR, ");
            strSQL.Append("CLMDTL_ACCOUNTING_NBR, ");
            strSQL.Append("CLMDTL_STATUS, ");
            strSQL.Append("CLMDTL_CONSEC_DATES_R, ");
            strSQL.Append("CLMDTL_DIAG_CD, ");
            strSQL.Append("CLMDTL_NBR_SERV, ");
            strSQL.Append("CLMDTL_FEE_OHIP, ");
            strSQL.Append("CLMDTL_AMT_TECH_BILLED, ");
            strSQL.Append("CLMDTL_OMA_CD, ");
            strSQL.Append("CLMDTL_OMA_SUFF ");
            strSQL.Append("FROM INDEXED.F002_SUSPEND_DTL ");

            strSQL.Append(Choose());

            rdrF002_SUSPEND_DTL.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_F002_SUSPEND_HDR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("CLMHDR_DOC_OHIP_NBR, ");
            strSQL.Append("CLMHDR_ACCOUNTING_NBR, ");
            strSQL.Append("CLMHDR_STATUS ");
            strSQL.Append("FROM INDEXED.F002_SUSPEND_HDR ");
            strSQL.Append("WHERE ");
            strSQL.Append("CLMHDR_DOC_OHIP_NBR = ").Append(rdrF002_SUSPEND_DTL.GetNumber("CLMDTL_DOC_OHIP_NBR"));
            strSQL.Append(" AND CLMHDR_ACCOUNTING_NBR = ").Append(Common.StringToField(rdrF002_SUSPEND_DTL.GetString("CLMDTL_ACCOUNTING_NBR")));

            rdrF002_SUSPEND_HDR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
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
            if (QDesign.NULL(rdrF002_SUSPEND_HDR.GetString("CLMHDR_STATUS")) == UPDATED() && QDesign.NULL(rdrF002_SUSPEND_DTL.GetString("CLMDTL_STATUS")) != CLMDTL_STATUS_DELETE())
            {
                blnSelected = true;
            }

            return blnSelected;
        }

        #endregion

        #region " DEFINES "

        private string X_CLMDTL_FLAG_BI()
        {
            string strReturnValue = string.Empty;
            try
            {
                if ((QDesign.NULL(QDesign.Substring(rdrF002_SUSPEND_DTL.GetString("CLMDTL_CONSEC_DATES"), 1, 2)) == "BI"))
                {
                    strReturnValue = "Y";
                }
                else
                {
                    strReturnValue = " ";
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_CLMDTL_FLAG_OP()
        {
            string strReturnValue = string.Empty;
            try
            {
                if ((QDesign.NULL(QDesign.Substring(rdrF002_SUSPEND_DTL.GetString("CLMDTL_CONSEC_DATES"), 1, 2)) == "OP"))
                {
                    strReturnValue = "Y";
                }
                else
                {
                    strReturnValue = " ";
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private decimal Z_CLMDTL_DOC_OHIP_NBR()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = rdrF002_SUSPEND_DTL.GetNumber("CLMDTL_DOC_OHIP_NBR");
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal Z_CLMDTL_DIAG_CD()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = rdrF002_SUSPEND_DTL.GetNumber("CLMDTL_DIAG_CD");
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal Z_CLMDTL_NBR_SERV()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = rdrF002_SUSPEND_DTL.GetNumber("CLMDTL_NBR_SERV");
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal Z_CLMDTL_FEE_OHIP()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = rdrF002_SUSPEND_DTL.GetNumber("CLMDTL_FEE_OHIP");
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal Z_CLMDTL_AMT_TECH_BILLED()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = rdrF002_SUSPEND_DTL.GetNumber("CLMDTL_AMT_TECH_BILLED");
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        #endregion

        #region " CONTROLS "

        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.REPORT, "Z_CLMDTL_DOC_OHIP_NBR", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "INDEXED.F002_SUSPEND_DTL.CLMDTL_ACCOUNTING_NBR", DataTypes.Character, 8);
                AddControl(ReportSection.REPORT, "INDEXED.F002_SUSPEND_DTL.CLMDTL_OMA_CD", DataTypes.Character, 4);
                AddControl(ReportSection.REPORT, "INDEXED.F002_SUSPEND_DTL.CLMDTL_OMA_SUFF", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "Z_CLMDTL_DIAG_CD", DataTypes.Numeric, 3);
                AddControl(ReportSection.REPORT, "Z_CLMDTL_NBR_SERV", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "Z_CLMDTL_FEE_OHIP", DataTypes.Numeric, 7);
                AddControl(ReportSection.REPORT, "Z_CLMDTL_AMT_TECH_BILLED", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "X_CLMDTL_FLAG_OP", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "X_CLMDTL_FLAG_BI", DataTypes.Character, 1);
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
                case "Z_CLMDTL_DOC_OHIP_NBR":
                    return Z_CLMDTL_DOC_OHIP_NBR().ToString();

                case "INDEXED.F002_SUSPEND_DTL.CLMDTL_ACCOUNTING_NBR":
                    return Common.StringToField(rdrF002_SUSPEND_DTL.GetString("CLMDTL_ACCOUNTING_NBR"));

                case "INDEXED.F002_SUSPEND_DTL.CLMDTL_OMA_CD":
                    return Common.StringToField(rdrF002_SUSPEND_DTL.GetString("CLMDTL_OMA_CD"));

                case "INDEXED.F002_SUSPEND_DTL.CLMDTL_OMA_SUFF":
                    return Common.StringToField(rdrF002_SUSPEND_DTL.GetString("CLMDTL_OMA_SUFF"));

                case "Z_CLMDTL_DIAG_CD":
                    return Z_CLMDTL_DIAG_CD().ToString();

                case "Z_CLMDTL_NBR_SERV":
                    return Z_CLMDTL_NBR_SERV().ToString();

                case "Z_CLMDTL_FEE_OHIP":
                    return Z_CLMDTL_FEE_OHIP().ToString();

                case "Z_CLMDTL_AMT_TECH_BILLED":
                    return Z_CLMDTL_AMT_TECH_BILLED().ToString();

                case "X_CLMDTL_FLAG_OP":
                    return Common.StringToField(X_CLMDTL_FLAG_OP(), intSize);

                case "X_CLMDTL_FLAG_BI":
                    return Common.StringToField(X_CLMDTL_FLAG_BI(), intSize);

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
                    Link_F002_SUSPEND_HDR();
                    while (rdrF002_SUSPEND_HDR.Read())
                    {
                        WriteData();
                    }

                    rdrF002_SUSPEND_HDR.Close();
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

            if (!(rdrF002_SUSPEND_HDR == null))
            {
                rdrF002_SUSPEND_HDR.Close();
                rdrF002_SUSPEND_HDR = null;
            }
        }

        #endregion

        #endregion
    }
}
