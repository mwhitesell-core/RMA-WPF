#region "Screen Comments"

// program: r124c.qzs
// purpose: Audit of invoice amounts for paycode 7
// DATE       BY WHOM      DESCRIPTION
// 2014/apr/15 be           - original
// 2014/apr/15 be1          - add printing of doctor`s bank info
// 2014/May/05 MC1   - no choose on rec-type for the last/fourth pass because MP did not include rec-type
// as part of the key 
// 2014/May/14 MC2   - include HST & total column in third pass, change 4th pass to choose on FINCHG instead

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
    public class R124C_1 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R124C_1";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrU116_PAYCODE_7_A = new Reader();
        private Reader rdrCONSTANTS_MSTR_REC_6 = new Reader();

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

                Sort = "";

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

        private void Access_U116_PAYCODE_7_A()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("W_TOT_DEPT_INC, ");
            strSQL.Append("W_TOT_DEPT_KEYHRS, ");
            strSQL.Append("W_TOT_DEPT_FTE ");
            strSQL.Append("FROM TEMPORARYDATA.U116_PAYCODE_7_A ");

            strSQL.Append(Choose());

            rdrU116_PAYCODE_7_A.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);

            strSQL = null;
        }

        private void Link_CONSTANTS_MSTR_REC_6()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("CONST_REC_NBR, ");
            strSQL.Append("CURRENT_EP_NBR ");
            strSQL.Append("FROM INDEXED.CONSTANTS_MSTR_REC_6 ");
            strSQL.Append("WHERE ");
            strSQL.Append("CONST_REC_NBR = ").Append(6);

            rdrCONSTANTS_MSTR_REC_6.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

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
                AddControl(ReportSection.PAGE_HEADING, "INDEXED.CONSTANTS_MSTR_REC_6.CURRENT_EP_NBR", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U116_PAYCODE_7_A.W_TOT_DEPT_INC", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U116_PAYCODE_7_A.W_TOT_DEPT_KEYHRS", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U116_PAYCODE_7_A.W_TOT_DEPT_FTE", DataTypes.Numeric, 10);
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
        //# Do not delete, modify or move it.  Updated: 2017-07-24 10:13:03 PM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "INDEXED.CONSTANTS_MSTR_REC_6.CURRENT_EP_NBR":
                    return rdrCONSTANTS_MSTR_REC_6.GetNumber("CURRENT_EP_NBR").ToString();

                case "TEMPORARYDATA.U116_PAYCODE_7_A.W_TOT_DEPT_INC":
                    return rdrU116_PAYCODE_7_A.GetNumber("W_TOT_DEPT_INC").ToString();

                case "TEMPORARYDATA.U116_PAYCODE_7_A.W_TOT_DEPT_KEYHRS":
                    return rdrU116_PAYCODE_7_A.GetNumber("W_TOT_DEPT_KEYHRS").ToString();

                case "TEMPORARYDATA.U116_PAYCODE_7_A.W_TOT_DEPT_FTE":
                    return rdrU116_PAYCODE_7_A.GetNumber("W_TOT_DEPT_FTE").ToString();

                default:
                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_U116_PAYCODE_7_A();

                while (rdrU116_PAYCODE_7_A.Read())
                {
                    Link_CONSTANTS_MSTR_REC_6();
                    while (rdrCONSTANTS_MSTR_REC_6.Read())
                    {
                        WriteData();
                    }
                    rdrCONSTANTS_MSTR_REC_6.Close();
                }
                rdrU116_PAYCODE_7_A.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrU116_PAYCODE_7_A != null))
            {
                rdrU116_PAYCODE_7_A.Close();
                rdrU116_PAYCODE_7_A = null;
            }
            if ((rdrCONSTANTS_MSTR_REC_6 != null))
            {
                rdrCONSTANTS_MSTR_REC_6.Close();
                rdrCONSTANTS_MSTR_REC_6 = null;
            }
        }


        #endregion

        #endregion
    }
}
