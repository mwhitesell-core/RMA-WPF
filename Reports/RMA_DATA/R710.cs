//  program: r510.qzs
//  purpose: printout all  P ercentage based `add on` codes in the suspend files
//  2000/???/?? B.E. - original
//  2001/apr/26 B.E. - changed selection to use `P ercent/ F lat flag rather
//  then looking at fee amounts
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
    public class R710 : BaseRDLClass
    {
        protected const string REPORT_NAME = "R710";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrF002_SUSPEND_DTL = new Reader();
        private Reader rdrF040_OMA_FEE_MSTR = new Reader();
        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                //  Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;
                Sort = "CLMDTL_DOC_OHIP_NBR ASC";
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
            strSQL.Append("CLMDTL_OMA_CD, ");
            strSQL.Append("CLMDTL_DOC_OHIP_NBR, ");
            strSQL.Append("CLMDTL_ACCOUNTING_NBR, ");
            strSQL.Append("CLMDTL_FEE_OMA, ");
            strSQL.Append("CLMDTL_FEE_OHIP, ");
            strSQL.Append("CLMDTL_AMT_TECH_BILLED ");
            strSQL.Append("FROM INDEXED.F002_SUSPEND_DTL ");
            strSQL.Append(Choose());
            rdrF002_SUSPEND_DTL.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.m_strFlatFileDictionary, ReportFunctions.TextFiles);
            strSQL = null;
        }
        private void Link_F040_OMA_FEE_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("FEE_OMA_CD_LTR1, ");
            strSQL.Append(" FILLER_NUMERIC, ");
            strSQL.Append("FEE_CURR_ADD_ON_PERC_OR_FLAT_IND ");
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
            return strChoose.ToString().ToString();
        }

        public override bool SelectIf()
        {
            bool blnSelected = false;
            if ((QDesign.NULL(rdrF040_OMA_FEE_MSTR.GetString("FEE_CURR_ADD_ON_PERC_OR_FLAT_IND")) == "P"))
            {
                blnSelected = true;
            }

            return blnSelected;
        }
        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.REPORT, "INDEXED.F002_SUSPEND_DTL.CLMDTL_DOC_OHIP_NBR", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "INDEXED.F002_SUSPEND_DTL.CLMDTL_ACCOUNTING_NBR", DataTypes.Character, 8);
                AddControl(ReportSection.REPORT, "INDEXED.F002_SUSPEND_DTL.CLMDTL_OMA_CD", DataTypes.Character, 4);
                AddControl(ReportSection.REPORT, "INDEXED.F002_SUSPEND_DTL.CLMDTL_FEE_OMA", DataTypes.Numeric, 7);
                AddControl(ReportSection.REPORT, "INDEXED.F002_SUSPEND_DTL.CLMDTL_FEE_OHIP", DataTypes.Numeric, 7);
                AddControl(ReportSection.REPORT, "INDEXED.F002_SUSPEND_DTL.CLMDTL_AMT_TECH_BILLED", DataTypes.Numeric, 6);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-05-15 3:04:05 PM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            // TODO: Remove duplicate controls, if there are any.
            switch (strControl)
            {
                case "INDEXED.F002_SUSPEND_DTL.CLMDTL_DOC_OHIP_NBR":
                    return rdrF002_SUSPEND_DTL.GetNumber("CLMDTL_DOC_OHIP_NBR").ToString();
                case "INDEXED.F002_SUSPEND_DTL.CLMDTL_ACCOUNTING_NBR":
                    return Common.StringToField(rdrF002_SUSPEND_DTL.GetString("CLMDTL_ACCOUNTING_NBR"));
                case "INDEXED.F002_SUSPEND_DTL.CLMDTL_OMA_CD":
                    return Common.StringToField(rdrF002_SUSPEND_DTL.GetString("CLMDTL_OMA_CD"));
                case "INDEXED.F002_SUSPEND_DTL.CLMDTL_FEE_OMA":
                    return rdrF002_SUSPEND_DTL.GetNumber("CLMDTL_FEE_OMA").ToString();
                case "INDEXED.F002_SUSPEND_DTL.CLMDTL_FEE_OHIP":
                    return rdrF002_SUSPEND_DTL.GetNumber("CLMDTL_FEE_OHIP").ToString();
                case "INDEXED.F002_SUSPEND_DTL.CLMDTL_AMT_TECH_BILLED":
                    return rdrF002_SUSPEND_DTL.GetNumber("CLMDTL_AMT_TECH_BILLED").ToString();
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
                    Link_F040_OMA_FEE_MSTR();
                    while (rdrF040_OMA_FEE_MSTR.Read())
                    {
                        WriteData();
                    }

                    rdrF040_OMA_FEE_MSTR.Close();
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

            if (!(rdrF040_OMA_FEE_MSTR == null))
            {
                rdrF040_OMA_FEE_MSTR.Close();
                rdrF040_OMA_FEE_MSTR = null;
            }
        }
    }
}
