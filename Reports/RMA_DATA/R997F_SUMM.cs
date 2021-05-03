#region "Screen Comments"

// 2008/dec/04   M.C.    - original
// - report summary by doctor(doc-ohip-nbr/doc-nbr) with amount billed and paid
// for r997f_summ (bad), r997g_summ (hcp) & r997k_summ (rmb)
// 2009/jan/20   yas     - change reports r997g_summ and r997k_summ to be sorted by doc 6 digit ohip number

#endregion

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
    public class R997F_SUMM : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R997F_SUMM";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrU997_BAD = new Reader();

        #endregion

        #region " Renaissance Data "

        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                // Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;

                Sort = "RAT_145_DOC_NBR ASC, RAT_145_ACCOUNT_NBR ASC";

                // Start report data processing.
                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return ReportData;
        }

        #endregion

        #region " Renaissance Statements "

        #region " ACCESS "

        private void Access_U997_BAD()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("RAT_145_DOC_NBR, ");
            strSQL.Append("RAT_145_ACCOUNT_NBR, ");
            strSQL.Append("RAT_145_AMOUNT_SUB, ");
            strSQL.Append("RAT_145_AMT_PAID ");
            strSQL.Append("FROM TEMPORARYDATA.U997_BAD ");

            strSQL.Append(Choose());

            //rdrU997_BAD.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
            rdrU997_BAD.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

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

        #endregion

        #region " DEFINES "

        #endregion

        #region " CONTROLS "

        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.U997_BAD.RAT_145_DOC_NBR", DataTypes.Numeric, 6);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.U997_BAD.RAT_145_AMOUNT_SUB", DataTypes.Numeric, 6);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.U997_BAD.RAT_145_AMT_PAID", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U997_BAD.RAT_145_ACCOUNT_NBR", DataTypes.Character, 8);
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        #endregion

        #region " Renaissance Precompiler Generated Code "

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 9/28/2017 1:28:52 PM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "TEMPORARYDATA.U997_BAD.RAT_145_DOC_NBR":
                    return rdrU997_BAD.GetNumber("RAT_145_DOC_NBR").ToString().PadLeft(6, ' ');

                case "TEMPORARYDATA.U997_BAD.RAT_145_AMOUNT_SUB":
                    return rdrU997_BAD.GetNumber("RAT_145_AMOUNT_SUB").ToString().PadLeft(6, ' ');

                case "TEMPORARYDATA.U997_BAD.RAT_145_AMT_PAID":
                    return rdrU997_BAD.GetNumber("RAT_145_AMT_PAID").ToString().PadLeft(6, ' ');

                case "TEMPORARYDATA.U997_BAD.RAT_145_ACCOUNT_NBR":
                    return Common.StringToField(rdrU997_BAD.GetString("RAT_145_ACCOUNT_NBR").PadRight(8, ' '));

                default:
                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_U997_BAD();

                while (rdrU997_BAD.Read())
                {
                    WriteData();
                }
                rdrU997_BAD.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrU997_BAD != null))
            {
                rdrU997_BAD.Close();
                rdrU997_BAD = null;
            }
        }


        #endregion

        #endregion
    }
}
