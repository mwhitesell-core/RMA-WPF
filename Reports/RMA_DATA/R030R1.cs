#region "Screen Comments"

// #> PROGRAM-ID.     R030R.QZS
// ((C)) Dyad Technologies
// PROGRAM PURPOSE : PRINT THE UNDEFINED DOCTOR`S TOTAL AMOUNT PREMIUM PAID FROM THE RAT
// MODIFICATION HISTORY
// DATE   WHO          DESCRIPTION
// 2013/Sep/11 M.C.         - ORIGINAL (cloned from r030.qzs)

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
    public class R030R1 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R030R1";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrR031A_ACTIVE_DOCTOR = new Reader();
        private Reader rdrF020_DOCTOR_MSTR = new Reader();

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

                Sort = "X_CLINIC ASC, DOC_OHIP_NBR ASC, DOC_NBR ASC";

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

        private void Access_R031A_ACTIVE_DOCTOR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("X_CLINIC, ");
            strSQL.Append("DOC_OHIP_NBR, ");
            strSQL.Append("X_TOTAL_PAID_AMT ");
            strSQL.Append("FROM TEMPORARYDATA.R031A_ACTIVE_DOCTOR ");

            strSQL.Append(Choose());

            rdrR031A_ACTIVE_DOCTOR.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);

            strSQL = null;
        }

        private void Link_F020_DOCTOR_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("DOC_NAME, ");
            strSQL.Append("DOC_INIT1, ");
            strSQL.Append(" DOC_INIT2, ");
            strSQL.Append(" DOC_INIT3, ");
            strSQL.Append("DOC_OHIP_NBR, ");
            strSQL.Append("DOC_DEPT, ");
            strSQL.Append("DOC_DATE_FAC_TERM_YY, ");
            strSQL.Append(" DOC_DATE_FAC_TERM_MM, ");
            strSQL.Append(" DOC_DATE_FAC_TERM_DD ");
            strSQL.Append("FROM INDEXED.F020_DOCTOR_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_NBR = ").Append(Common.StringToField(rdrR031A_ACTIVE_DOCTOR.GetString("DOC_NBR")));

            rdrF020_DOCTOR_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

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

            if (!ReportDataFunctions.Exists(rdrF020_DOCTOR_MSTR))
            {
                blnSelected = true;
            }

            return blnSelected;
        }

        #endregion

        #region " DEFINES "

        private string X_DOC_NAME()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.Pack(rdrF020_DOCTOR_MSTR.GetString("DOC_NAME") + ", " + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT1") + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT2") + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT3"));
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private System.DateTime DOC_DATE_FAC_TERM()
        {
            System.DateTime dteReturnValue = Common.cZeroDate;

            try
            {
                dteReturnValue = QDesign.GetDateFromYYYYMMDDDecimal(Convert.ToString(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DATE_FAC_TERM_YY")) + Convert.ToString(rdrF020_DOCTOR_MSTR.GetString("DOC_DATE_FAC_TERM_MM")) + Convert.ToString(rdrF020_DOCTOR_MSTR.GetString("DOC_DATE_FAC_TERM_DD")));
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
            return dteReturnValue;
        }

        #endregion

        #region " CONTROLS "

        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R031A_ACTIVE_DOCTOR.X_CLINIC", DataTypes.Character, 2);
                AddControl(ReportSection.REPORT, "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R031A_ACTIVE_DOCTOR.DOC_OHIP_NBR", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "INDEXED.F020_DOCTOR_MSTR.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "X_DOC_NAME", DataTypes.Character, 30);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R031A_ACTIVE_DOCTOR.X_TOTAL_PAID_AMT", DataTypes.Numeric, 8);
                AddControl(ReportSection.REPORT, "DOC_DATE_FAC_TERM", DataTypes.Numeric, 8);
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
        //# Do not delete, modify or move it.  Updated: 9/27/2017 6:49:59 PM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "TEMPORARYDATA.R031A_ACTIVE_DOCTOR.X_CLINIC":
                    return Common.StringToField(rdrR031A_ACTIVE_DOCTOR.GetString("X_CLINIC").PadRight(2, ' '));

                case "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT":
                    return rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT").ToString().PadLeft(2, ' ');

                case "TEMPORARYDATA.R031A_ACTIVE_DOCTOR.DOC_OHIP_NBR":
                    return rdrR031A_ACTIVE_DOCTOR.GetNumber("DOC_OHIP_NBR").ToString().PadLeft(6, ' ');

                case "INDEXED.F020_DOCTOR_MSTR.DOC_NBR":
                    return Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_NBR").PadRight(3, ' '));

                case "X_DOC_NAME":
                    return Common.StringToField(X_DOC_NAME().PadRight(30, ' '));

                case "TEMPORARYDATA.R031A_ACTIVE_DOCTOR.X_TOTAL_PAID_AMT":
                    return rdrR031A_ACTIVE_DOCTOR.GetNumber("X_TOTAL_PAID_AMT").ToString().PadLeft(8, ' ');

                case "DOC_DATE_FAC_TERM":
                    return DOC_DATE_FAC_TERM().ToString().PadLeft(8, ' ');

                default:
                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_R031A_ACTIVE_DOCTOR();

                while (rdrR031A_ACTIVE_DOCTOR.Read())
                {
                    Link_F020_DOCTOR_MSTR();
                    while (rdrF020_DOCTOR_MSTR.Read())
                    {
                        WriteData();
                    }
                    rdrF020_DOCTOR_MSTR.Close();
                }
                rdrR031A_ACTIVE_DOCTOR.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrR031A_ACTIVE_DOCTOR != null))
            {
                rdrR031A_ACTIVE_DOCTOR.Close();
                rdrR031A_ACTIVE_DOCTOR = null;
            }
            if ((rdrF020_DOCTOR_MSTR != null))
            {
                rdrF020_DOCTOR_MSTR.Close();
                rdrF020_DOCTOR_MSTR = null;
            }
        }


        #endregion

        #endregion
    }
}
