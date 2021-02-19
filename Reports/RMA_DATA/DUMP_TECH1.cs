//  2004/04/14 M.C. - alpha doc nbr
//  2005/04/19 yas. - link to f040 if code = T and codes start with G or J
//  don`t print
//  201/02/23     MC1 - change this program into 2 passes, first one to create subfile
//  and second to create report as original
//  access f002-suspend-dtl       &
//  link clmdtl-doc-ohip-nbr    &
//  to doc-ohip-nbr of f020-doctor-mstr opt
//  2004/04/14 - MC
//  !  link (nconvert(clmdtl-id[4:3]))     &
//  2004/04/14 - end
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
    public class DUMP_TECH1 : BaseRDLClass
    {
        protected const string REPORT_NAME = "DUMP_TECH1";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrF002_SUSPEND_DTL = new Reader();
        private Reader rdrF020_DOCTOR_MSTR = new Reader();
        private Reader rdrF040_OMA_FEE_MSTR = new Reader();
        private Reader rdrDUMP_TECH = new Reader();
        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                //  Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;
                //  Create Subfile.
                SubFile = true;
                SubFileName = "DUMP_TECH";
                SubFileType = SubFileType.Keep;
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
        private void Access_F002_SUSPEND_DTL()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            strSQL.Append("SELECT ");
            strSQL.Append("CLMDTL_BATCH_NBR, ");
            strSQL.Append(" CLMDTL_CLAIM_NBR, ");
            strSQL.Append(" CLMDTL_OMA_CD, ");
            strSQL.Append(" CLMDTL_OMA_SUFF, ");
            strSQL.Append(" CLMDTL_ADJ_NBR, ");
            strSQL.Append("CLMDTL_AMT_TECH_BILLED, ");
            strSQL.Append("CLMDTL_DOC_OHIP_NBR, ");
            strSQL.Append("CLMDTL_ACCOUNTING_NBR, ");
            strSQL.Append("CLMDTL_NBR_SERV, ");
            strSQL.Append("CLMDTL_FEE_OMA, ");
            strSQL.Append("CLMDTL_FEE_OHIP ");
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
            strSQL.Append("DOC_NBR ");
            strSQL.Append("FROM INDEXED.F020_DOCTOR_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_NBR = ").Append(Common.StringToField(QDesign.Substring(rdrF002_SUSPEND_DTL.GetString("CLMDTL_BATCH_NBR"), 3, 3)));
            rdrF020_DOCTOR_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_F040_OMA_FEE_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("FEE_OMA_CD_LTR1, ");
            strSQL.Append("FILLER_NUMERIC, ");
            strSQL.Append("FEE_TECH_IND ");
            strSQL.Append("FROM INDEXED.F040_OMA_FEE_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("FEE_OMA_CD_LTR1 = ").Append(Common.StringToField(QDesign.Substring(rdrF002_SUSPEND_DTL.GetString("CLMDTL_OMA_CD"), 1, 1)));
            strSQL.Append(" AND FILLER_NUMERIC = ").Append(Common.StringToField(QDesign.Substring(rdrF002_SUSPEND_DTL.GetString("CLMDTL_OMA_CD"), 2, 3)));
            rdrF040_OMA_FEE_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(String.Empty);
            // TODO: CHOOSE Statement - May require manual changes.
            return strChoose.ToString();
        }

        public override bool SelectIf()
        {
            bool blnSelected = false;
            if (QDesign.NULL(rdrF002_SUSPEND_DTL.GetNumber("CLMDTL_AMT_TECH_BILLED")) != QDesign.NULL(0d) && QDesign.NULL(QDesign.Substring(rdrF002_SUSPEND_DTL.GetString("CLMDTL_OMA_CD"), 1, 1)) != "G" && QDesign.NULL(QDesign.Substring(rdrF002_SUSPEND_DTL.GetString("CLMDTL_OMA_CD"), 1, 1)) != "J" && QDesign.NULL(rdrF040_OMA_FEE_MSTR.GetString("FEE_TECH_IND")) != "T")
            {
                blnSelected = true;
            }

            return blnSelected;
        }
        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.SUMMARY, "INDEXED.F020_DOCTOR_MSTR.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_SUSPEND_DTL.CLMDTL_DOC_OHIP_NBR", DataTypes.Numeric, 6);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_SUSPEND_DTL.CLMDTL_ACCOUNTING_NBR", DataTypes.Character, 8);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_SUSPEND_DTL.CLMDTL_OMA_CD", DataTypes.Character, 4);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_SUSPEND_DTL.CLMDTL_OMA_SUFF", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_SUSPEND_DTL.CLMDTL_NBR_SERV", DataTypes.Numeric, 2);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_SUSPEND_DTL.CLMDTL_AMT_TECH_BILLED", DataTypes.Numeric, 6);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_SUSPEND_DTL.CLMDTL_FEE_OMA", DataTypes.Numeric, 7);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_SUSPEND_DTL.CLMDTL_FEE_OHIP", DataTypes.Numeric, 7);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-05-09 9:52:33 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            // TODO: Remove duplicate controls, if there are any.
            switch (strControl)
            {
                case "INDEXED.F020_DOCTOR_MSTR.DOC_NBR":
                    return Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_NBR"));
                case "INDEXED.F002_SUSPEND_DTL.CLMDTL_DOC_OHIP_NBR":
                    return rdrF002_SUSPEND_DTL.GetNumber("CLMDTL_DOC_OHIP_NBR").ToString();
                case "INDEXED.F002_SUSPEND_DTL.CLMDTL_ACCOUNTING_NBR":
                    return Common.StringToField(rdrF002_SUSPEND_DTL.GetString("CLMDTL_ACCOUNTING_NBR"));
                case "INDEXED.F002_SUSPEND_DTL.CLMDTL_OMA_CD":
                    return Common.StringToField(rdrF002_SUSPEND_DTL.GetString("CLMDTL_OMA_CD"));
                case "INDEXED.F002_SUSPEND_DTL.CLMDTL_OMA_SUFF":
                    return Common.StringToField(rdrF002_SUSPEND_DTL.GetString("CLMDTL_OMA_SUFF"));
                case "INDEXED.F002_SUSPEND_DTL.CLMDTL_NBR_SERV":
                    return rdrF002_SUSPEND_DTL.GetNumber("CLMDTL_NBR_SERV").ToString();
                case "INDEXED.F002_SUSPEND_DTL.CLMDTL_AMT_TECH_BILLED":
                    return rdrF002_SUSPEND_DTL.GetNumber("CLMDTL_AMT_TECH_BILLED").ToString();
                case "INDEXED.F002_SUSPEND_DTL.CLMDTL_FEE_OMA":
                    return rdrF002_SUSPEND_DTL.GetNumber("CLMDTL_FEE_OMA").ToString();
                case "INDEXED.F002_SUSPEND_DTL.CLMDTL_FEE_OHIP":
                    return rdrF002_SUSPEND_DTL.GetNumber("CLMDTL_FEE_OHIP").ToString();
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
                        Link_F040_OMA_FEE_MSTR();
                        while (rdrF040_OMA_FEE_MSTR.Read())
                        {
                            WriteData();
                        }

                        rdrF040_OMA_FEE_MSTR.Close();
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

            if (!(rdrF040_OMA_FEE_MSTR == null))
            {
                rdrF040_OMA_FEE_MSTR.Close();
                rdrF040_OMA_FEE_MSTR = null;
            }
        }
    }
}
