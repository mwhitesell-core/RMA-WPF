//  link (nconvert(ascii(clmdtl-batch-nbr,9)[4:3]))    &
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
    public class SUSPEND_DESC : BaseRDLClass
    {
        protected const string REPORT_NAME = "SUSPEND_DESC";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrF002_SUSPEND_DTL = new Reader();
        private Reader rdrF020_DOCTOR_MSTR = new Reader();
        private Reader rdrF002_SUSPEND_HDR = new Reader();
        private Reader rdrF002_SUSPEND_DESC = new Reader();
        // #CORE_BEGIN_INCLUDE: DEF_CLMHDR_STATUS"
        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-05-16 12:45:41 PM
        private string CLMHDR_STATUS_COMPLETE()
        {
            string strReturnValue = String.Empty;
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
            string strReturnValue = String.Empty;
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
            string strReturnValue = String.Empty;
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
            string strReturnValue = String.Empty;
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
            string strReturnValue = String.Empty;
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
            string strReturnValue = String.Empty;
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
            string strReturnValue = String.Empty;
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
            string strReturnValue = String.Empty;
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
            string strReturnValue = String.Empty;
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
        // # Do not delete, modify or move it.  Updated: 2018-05-16 12:45:41 PM
        private string CLMDTL_STATUS_DELETE()
        {
            string strReturnValue = String.Empty;
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
            string strReturnValue = String.Empty;
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
            string strReturnValue = String.Empty;
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
            string strReturnValue = String.Empty;
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

        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                //  Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;
                Sort = "DOC_NBR ASC, CLMDTL_ACCOUNTING_NBR ASC";
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
            StringBuilder strSQL = new StringBuilder(String.Empty);
            strSQL.Append("SELECT ");
            strSQL.Append("CLMDTL_BATCH_NBR, ");
            strSQL.Append("CLMDTL_DOC_OHIP_NBR, ");
            strSQL.Append("CLMDTL_ACCOUNTING_NBR, ");
            strSQL.Append("CLMDTL_STATUS ");
            strSQL.Append("FROM INDEXED.F002_SUSPEND_DTL ");
            strSQL.Append(Choose());
            rdrF002_SUSPEND_DTL.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.m_strFlatFileDictionary, ReportFunctions.TextFiles);
            strSQL = null;
        }
        private void Link_F020_DOCTOR_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("DOC_NAME, ");
            strSQL.Append("DOC_INIT1, ");
            strSQL.Append("DOC_INIT2, ");
            strSQL.Append("DOC_INIT3 ");
            strSQL.Append("FROM INDEXED.F020_DOCTOR_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_NBR = ").Append(Common.StringToField(QDesign.Substring(rdrF002_SUSPEND_DTL.GetString("CLMDTL_BATCH_NBR"), 3, 3)));
            rdrF020_DOCTOR_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_F002_SUSPEND_HDR()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("CLMHDR_DOC_OHIP_NBR, ");
            strSQL.Append("CLMHDR_ACCOUNTING_NBR, ");
            strSQL.Append("CLMHDR_STATUS, ");
            strSQL.Append("CLMHDR_RELATIONSHIP ");
            strSQL.Append("FROM INDEXED.F002_SUSPEND_HDR ");
            strSQL.Append("WHERE ");
            strSQL.Append("CLMHDR_DOC_OHIP_NBR = ").Append(rdrF002_SUSPEND_DTL.GetNumber("CLMDTL_DOC_OHIP_NBR"));
            strSQL.Append(" AND CLMHDR_ACCOUNTING_NBR = ").Append(Common.StringToField(rdrF002_SUSPEND_DTL.GetString("CLMDTL_ACCOUNTING_NBR")));
            rdrF002_SUSPEND_HDR.GetOptionalTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.m_strFlatFileDictionary, ReportFunctions.TextFiles);
            strSQL = null;
        }
        private void Link_F002_SUSPEND_DESC()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("CLMDTL_DOC_OHIP_NBR, ");
            strSQL.Append("CLMDTL_ACCOUNTING_NBR, ");
            strSQL.Append("CLMDTL_SUSPEND_DESC ");
            strSQL.Append("FROM INDEXED.F002_SUSPEND_DESC ");
            strSQL.Append("WHERE ");
            strSQL.Append("CLMDTL_DOC_OHIP_NBR = ").Append(rdrF002_SUSPEND_DTL.GetNumber("CLMDTL_DOC_OHIP_NBR"));
            strSQL.Append(" AND CLMDTL_ACCOUNTING_NBR = ").Append(Common.StringToField(rdrF002_SUSPEND_DTL.GetString("CLMDTL_ACCOUNTING_NBR")));
            rdrF002_SUSPEND_DESC.GetOptionalTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.m_strFlatFileDictionary, ReportFunctions.TextFiles);
            strSQL = null;
        }

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(String.Empty);
            // TODO: CHOOSE Statement - May require manual changes.
            return strChoose.ToString().ToString();
        }

        public override bool SelectIf()
        {
            bool blnSelected = false;
            if ((((QDesign.NULL(rdrF002_SUSPEND_HDR.GetString("CLMHDR_STATUS")) != QDesign.NULL(CLMHDR_STATUS_DELETE()))
                        && (QDesign.NULL(rdrF002_SUSPEND_DTL.GetString("CLMDTL_STATUS")) != QDesign.NULL(CLMDTL_STATUS_DELETE())))
                        && ((QDesign.NULL(rdrF002_SUSPEND_HDR.GetString("CLMHDR_STATUS")) != QDesign.NULL(CLMHDR_STATUS_IGNOR()))
                        && (QDesign.NULL(rdrF002_SUSPEND_DESC.GetString("CLMDTL_SUSPEND_DESC")) != QDesign.NULL(" ")))))
            {
                blnSelected = true;
            }

            return blnSelected;
        }

        private string X_NAME()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = QDesign.Pack(rdrF020_DOCTOR_MSTR.GetString("DOC_NAME") + " " + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT1") + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT2") + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT3"));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_MR()
        {
            string strReturnValue = String.Empty;
            try
            {
                if ((QDesign.NULL(rdrF002_SUSPEND_HDR.GetString("CLMHDR_RELATIONSHIP")) == "Y"))
                {
                    strReturnValue = rdrF002_SUSPEND_HDR.GetString("CLMHDR_RELATIONSHIP");
                }
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
                AddControl(ReportSection.HEADING_AT, "INDEXED.F020_DOCTOR_MSTR.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.HEADING_AT, "X_NAME", DataTypes.Character, 25);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F002_SUSPEND_DTL.CLMDTL_DOC_OHIP_NBR", DataTypes.Numeric, 6);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F002_SUSPEND_DTL.CLMDTL_ACCOUNTING_NBR", DataTypes.Character, 8);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F002_SUSPEND_HDR.CLMHDR_RELATIONSHIP", DataTypes.Character, 1);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F002_SUSPEND_DESC.CLMDTL_SUSPEND_DESC", DataTypes.Character, 70);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-05-16 12:45:41 PM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            // TODO: Remove duplicate controls, if there are any.
            switch (strControl)
            {
                case "INDEXED.F020_DOCTOR_MSTR.DOC_NBR":
                    return Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_NBR"));
                case "X_NAME":
                    return Common.StringToField(X_NAME(), intSize);
                case "INDEXED.F002_SUSPEND_DTL.CLMDTL_DOC_OHIP_NBR":
                    return rdrF002_SUSPEND_DTL.GetNumber("CLMDTL_DOC_OHIP_NBR").ToString();
                case "INDEXED.F002_SUSPEND_DTL.CLMDTL_ACCOUNTING_NBR":
                    return Common.StringToField(rdrF002_SUSPEND_DTL.GetString("CLMDTL_ACCOUNTING_NBR"));
                case "INDEXED.F002_SUSPEND_HDR.CLMHDR_RELATIONSHIP":
                    return Common.StringToField(rdrF002_SUSPEND_HDR.GetString("CLMHDR_RELATIONSHIP"));
                case "INDEXED.F002_SUSPEND_DESC.CLMDTL_SUSPEND_DESC":
                    return Common.StringToField(rdrF002_SUSPEND_DESC.GetString("CLMDTL_SUSPEND_DESC"));
                default:
                    return String.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                // TODO: Some manual steps maybe required.
                Access_F002_SUSPEND_DTL();
                while (rdrF002_SUSPEND_DTL.Read())
                {
                    Link_F020_DOCTOR_MSTR();
                    while (rdrF020_DOCTOR_MSTR.Read())
                    {
                        Link_F002_SUSPEND_HDR();
                        while (rdrF002_SUSPEND_HDR.Read())
                        {
                            Link_F002_SUSPEND_DESC();
                            while (rdrF002_SUSPEND_DESC.Read())
                            {
                                WriteData();
                            }

                            rdrF002_SUSPEND_DESC.Close();
                        }

                        rdrF002_SUSPEND_HDR.Close();
                    }

                    rdrF020_DOCTOR_MSTR.Close();
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

            if (!(rdrF020_DOCTOR_MSTR == null))
            {
                rdrF020_DOCTOR_MSTR.Close();
                rdrF020_DOCTOR_MSTR = null;
            }

            if (!(rdrF002_SUSPEND_HDR == null))
            {
                rdrF002_SUSPEND_HDR.Close();
                rdrF002_SUSPEND_HDR = null;
            }

            if (!(rdrF002_SUSPEND_DESC == null))
            {
                rdrF002_SUSPEND_DESC.Close();
                rdrF002_SUSPEND_DESC = null;
            }
        }
    }
}
