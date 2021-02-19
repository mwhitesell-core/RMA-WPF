#region "Screen Comments"


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
    public class R124C_2 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R124C_2";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrU116_PAYCODE_7_B = new Reader();
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

        private void Access_U116_PAYCODE_7_B()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("W_TOT_DEPT_FTE, ");
            strSQL.Append("W_TOT_DEPT_INC_CHARGES, ");
            strSQL.Append("W_SVC_RATE, ");
            strSQL.Append("W_TOT_DEPT_DATAENTRY_CHARGES, ");
            strSQL.Append("W_TOT_DEPT_CHARGES, ");
            strSQL.Append("W_TOT_1_FTE_CHARGE ");
            strSQL.Append("FROM TEMPORARYDATA.U116_PAYCODE_7_B ");

            strSQL.Append(Choose());

            rdrU116_PAYCODE_7_B.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);

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
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U116_PAYCODE_7_B.W_TOT_DEPT_FTE", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U116_PAYCODE_7_B.W_TOT_DEPT_INC_CHARGES", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U116_PAYCODE_7_B.W_SVC_RATE", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U116_PAYCODE_7_B.W_TOT_DEPT_DATAENTRY_CHARGES", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U116_PAYCODE_7_B.W_TOT_DEPT_CHARGES", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U116_PAYCODE_7_B.W_TOT_1_FTE_CHARGE", DataTypes.Numeric, 10);
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
        //# Do not delete, modify or move it.  Updated: 2017-07-24 10:13:48 PM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "INDEXED.CONSTANTS_MSTR_REC_6.CURRENT_EP_NBR":
                    return rdrCONSTANTS_MSTR_REC_6.GetNumber("CURRENT_EP_NBR").ToString();

                case "TEMPORARYDATA.U116_PAYCODE_7_B.W_TOT_DEPT_FTE":
                    return rdrU116_PAYCODE_7_B.GetNumber("W_TOT_DEPT_FTE").ToString();

                case "TEMPORARYDATA.U116_PAYCODE_7_B.W_TOT_DEPT_INC_CHARGES":
                    return rdrU116_PAYCODE_7_B.GetNumber("W_TOT_DEPT_INC_CHARGES").ToString();

                case "TEMPORARYDATA.U116_PAYCODE_7_B.W_SVC_RATE":
                    return rdrU116_PAYCODE_7_B.GetNumber("W_SVC_RATE").ToString();

                case "TEMPORARYDATA.U116_PAYCODE_7_B.W_TOT_DEPT_DATAENTRY_CHARGES":
                    return rdrU116_PAYCODE_7_B.GetNumber("W_TOT_DEPT_DATAENTRY_CHARGES").ToString();

                case "TEMPORARYDATA.U116_PAYCODE_7_B.W_TOT_DEPT_CHARGES":
                    return rdrU116_PAYCODE_7_B.GetNumber("W_TOT_DEPT_CHARGES").ToString();

                case "TEMPORARYDATA.U116_PAYCODE_7_B.W_TOT_1_FTE_CHARGE":
                    return rdrU116_PAYCODE_7_B.GetNumber("W_TOT_1_FTE_CHARGE").ToString();

                default:
                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_U116_PAYCODE_7_B();

                while (rdrU116_PAYCODE_7_B.Read())
                {
                    Link_CONSTANTS_MSTR_REC_6();
                    while (rdrCONSTANTS_MSTR_REC_6.Read())
                    {
                        WriteData();
                    }
                    rdrCONSTANTS_MSTR_REC_6.Close();
                }
                rdrU116_PAYCODE_7_B.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrU116_PAYCODE_7_B != null))
            {
                rdrU116_PAYCODE_7_B.Close();
                rdrU116_PAYCODE_7_B = null;
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