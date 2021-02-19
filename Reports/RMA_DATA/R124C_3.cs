#region "Screen Comments"

// 1         2         3         4         5         6         7         8         9         95        110
// 123456789 123456789 123456789 123456789 123456789 123456789 123456789 123456789 123456789 123456789 123456789 1234567

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
    public class R124C_3 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R124C_3";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrDEBUGU116CD7 = new Reader();
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

        private void Access_DEBUGU116CD7()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("FACTOR, ");
            strSQL.Append("W_TOT_1_FTE_CHARGE, ");
            strSQL.Append("W_DOC_CHARGE, ");
            strSQL.Append("W_HST_CHARGE, ");
            strSQL.Append("W_DOC_TOT_CHARGE ");
            strSQL.Append("FROM TEMPORARYDATA.DEBUGU116CD7 ");

            strSQL.Append(Choose());

            rdrDEBUGU116CD7.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);

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
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD7.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD7.FACTOR", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD7.W_TOT_1_FTE_CHARGE", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD7.W_DOC_CHARGE", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD7.W_HST_CHARGE", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.DEBUGU116CD7.W_DOC_TOT_CHARGE", DataTypes.Numeric, 10);
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
        //# Do not delete, modify or move it.  Updated: 2017-07-24 10:15:35 PM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "INDEXED.CONSTANTS_MSTR_REC_6.CURRENT_EP_NBR":
                    return rdrCONSTANTS_MSTR_REC_6.GetNumber("CURRENT_EP_NBR").ToString().PadLeft(6, ' ');

                case "TEMPORARYDATA.DEBUGU116CD7.DOC_NBR":
                    return Common.StringToField(rdrDEBUGU116CD7.GetString("DOC_NBR").PadRight(3, ' '));

                case "TEMPORARYDATA.DEBUGU116CD7.FACTOR":
                    return rdrDEBUGU116CD7.GetNumber("FACTOR").ToString().PadLeft(6,' ');

                case "TEMPORARYDATA.DEBUGU116CD7.W_TOT_1_FTE_CHARGE":
                    return rdrDEBUGU116CD7.GetNumber("W_TOT_1_FTE_CHARGE").ToString().PadLeft(10,' ');

                case "TEMPORARYDATA.DEBUGU116CD7.W_DOC_CHARGE":
                    return rdrDEBUGU116CD7.GetNumber("W_DOC_CHARGE").ToString().PadLeft(10,' ');

                case "TEMPORARYDATA.DEBUGU116CD7.W_HST_CHARGE":
                    return rdrDEBUGU116CD7.GetNumber("W_HST_CHARGE").ToString().PadLeft(10,' ');

                case "TEMPORARYDATA.DEBUGU116CD7.W_DOC_TOT_CHARGE":
                    return rdrDEBUGU116CD7.GetNumber("W_DOC_TOT_CHARGE").ToString().PadLeft(10, ' ');

                default:
                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_DEBUGU116CD7();

                while (rdrDEBUGU116CD7.Read())
                {
                    Link_CONSTANTS_MSTR_REC_6();
                    while (rdrCONSTANTS_MSTR_REC_6.Read())
                    {
                        WriteData();
                    }
                    rdrCONSTANTS_MSTR_REC_6.Close();
                }
                rdrDEBUGU116CD7.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrDEBUGU116CD7 != null))
            {
                rdrDEBUGU116CD7.Close();
                rdrDEBUGU116CD7 = null;
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
