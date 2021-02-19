#region "Screen Comments"

// #> PROGRAM-ID.     R030Q.QZS
// ((C)) Dyad Technologies
// PROGRAM PURPOSE : PRINT THE MULTIPLE DOCTORS THAT  MAY HAVE PREMIUM PAID FROM THE RAT
// MODIFICATION HISTORY
// DATE   WHO          DESCRIPTION
// 11/Jul/27 M.C.         - ORIGINAL - cloned from r030k.qzs

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
    public class R030Q : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R030Q";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrR031A_MULTIPLE_DOCTOR = new Reader();
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

                Sort = "ICONST_CLINIC_NBR_1_2 ASC, X_ADJ_CD ASC, DOC_OHIP_NBR ASC, DOC_DEPT DESC, DOC_DATE_FAC_START ASC";

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

        private void Access_R031A_MULTIPLE_DOCTOR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("ICONST_CLINIC_NBR_1_2, ");
            strSQL.Append("X_ADJ_CD, ");
            strSQL.Append("X_PAYMENT ");
            strSQL.Append("FROM TEMPORARYDATA.R031A_MULTIPLE_DOCTOR ");

            strSQL.Append(Choose());

            rdrR031A_MULTIPLE_DOCTOR.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);

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
            strSQL.Append("DOC_DATE_FAC_START_YY, ");
            strSQL.Append(" DOC_DATE_FAC_START_MM, ");
            strSQL.Append(" DOC_DATE_FAC_START_DD, ");
            strSQL.Append("DOC_DATE_FAC_TERM_YY, ");
            strSQL.Append(" DOC_DATE_FAC_TERM_MM, ");
            strSQL.Append(" DOC_DATE_FAC_TERM_DD, ");
            strSQL.Append("DOC_BANK_NBR, ");
            strSQL.Append(" DOC_BANK_BRANCH, ");
            strSQL.Append(" DOC_BANK_ACCT ");
            strSQL.Append("FROM INDEXED.F020_DOCTOR_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_NBR = ").Append(Common.StringToField(rdrR031A_MULTIPLE_DOCTOR.GetString("DOC_NBR")));

            rdrF020_DOCTOR_MSTR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

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

        private string DOC_DATE_FAC_TERM()
        {
            string strReturnValue = "";

            try
            {
                strReturnValue = Convert.ToString(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DATE_FAC_TERM_YY")) + Convert.ToString(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DATE_FAC_TERM_MM")).PadLeft(2, '0') + Convert.ToString(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DATE_FAC_TERM_DD")).PadLeft(2, '0');
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
            return strReturnValue;
        }

        private string DOC_DATE_FAC_START()
        {
            //System.DateTime dteReturnValue = Common.cZeroDate;
            string strReturnValue = "";
            try
            {
                strReturnValue = Convert.ToString(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DATE_FAC_START_YY")) + Convert.ToString(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DATE_FAC_START_MM")) + Convert.ToString(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DATE_FAC_START_DD")).PadLeft(2, '0');
                //dteReturnValue = QDesign.GetDateFromYYYYMMDDDecimal(Convert.ToString(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DATE_FAC_START_YY")) + Convert.ToString(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DATE_FAC_START_MM")) + Convert.ToString(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DATE_FAC_START_DD")));
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
            return strReturnValue;
        }

        private string F020_DOCTOR_MSTR_DOC_BANK_INFO()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = Convert.ToString(rdrF020_DOCTOR_MSTR.GetNumber("DOC_BANK_NBR")) + Convert.ToString(rdrF020_DOCTOR_MSTR.GetNumber("DOC_BANK_BRANCH")) + rdrF020_DOCTOR_MSTR.GetString("DOC_BANK_ACCT");
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
            return strReturnValue;
        }

        #endregion

        #region " CONTROLS "

        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R031A_MULTIPLE_DOCTOR.ICONST_CLINIC_NBR_1_2", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "INDEXED.F020_DOCTOR_MSTR.DOC_OHIP_NBR", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "INDEXED.F020_DOCTOR_MSTR.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "X_DOC_NAME", DataTypes.Character, 30);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R031A_MULTIPLE_DOCTOR.X_PAYMENT", DataTypes.Numeric, 8);
                AddControl(ReportSection.REPORT, "DOC_DATE_FAC_TERM", DataTypes.Numeric, 8);
                AddControl(ReportSection.REPORT, "DOC_DATE_FAC_START", DataTypes.Numeric, 8);
                AddControl(ReportSection.REPORT, "F020_DOCTOR_MSTR_DOC_BANK_INFO", DataTypes.Character, 21);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R031A_MULTIPLE_DOCTOR.X_ADJ_CD", DataTypes.Character, 5);
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
        //# Do not delete, modify or move it.  Updated: 9/27/2017 3:39:43 PM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "TEMPORARYDATA.R031A_MULTIPLE_DOCTOR.ICONST_CLINIC_NBR_1_2":
                    return rdrR031A_MULTIPLE_DOCTOR.GetNumber("ICONST_CLINIC_NBR_1_2").ToString().PadLeft(2, ' ');

                case "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT":
                    return rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT").ToString().PadLeft(2, ' ');

                case "INDEXED.F020_DOCTOR_MSTR.DOC_OHIP_NBR":
                    return rdrF020_DOCTOR_MSTR.GetNumber("DOC_OHIP_NBR").ToString().PadLeft(6, ' ');

                case "INDEXED.F020_DOCTOR_MSTR.DOC_NBR":
                    return Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_NBR").PadRight(3, ' '));

                case "X_DOC_NAME":
                    return Common.StringToField(X_DOC_NAME().PadRight(30, ' '));

                case "TEMPORARYDATA.R031A_MULTIPLE_DOCTOR.X_PAYMENT":
                    return rdrR031A_MULTIPLE_DOCTOR.GetNumber("X_PAYMENT").ToString().PadLeft(8, ' ');

                case "DOC_DATE_FAC_TERM":
                    return DOC_DATE_FAC_TERM().ToString().PadLeft(8, ' ');

                case "DOC_DATE_FAC_START":
                    return DOC_DATE_FAC_START().ToString().PadLeft(8, ' ');

                case "F020_DOCTOR_MSTR_DOC_BANK_INFO":
                    return Common.StringToField(F020_DOCTOR_MSTR_DOC_BANK_INFO().PadRight(21, ' '));

                case "TEMPORARYDATA.R031A_MULTIPLE_DOCTOR.X_ADJ_CD":
                    return Common.StringToField(rdrR031A_MULTIPLE_DOCTOR.GetString("X_ADJ_CD").PadRight(5, ' '));

                default:

                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_R031A_MULTIPLE_DOCTOR();

                while (rdrR031A_MULTIPLE_DOCTOR.Read())
                {
                    Link_F020_DOCTOR_MSTR();
                    while (rdrF020_DOCTOR_MSTR.Read())
                    {
                        WriteData();
                    }
                    rdrF020_DOCTOR_MSTR.Close();
                }
                rdrR031A_MULTIPLE_DOCTOR.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrR031A_MULTIPLE_DOCTOR != null))
            {
                rdrR031A_MULTIPLE_DOCTOR.Close();
                rdrR031A_MULTIPLE_DOCTOR = null;
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
