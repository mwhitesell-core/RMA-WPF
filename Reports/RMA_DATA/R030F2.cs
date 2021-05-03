#region "Screen Comments"


#endregion

using Core.DataAccess.TextFile;
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
    public class R030F2 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R030F2";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrU030_TOT_CLAIMS = new Reader();
        private Reader rdrICONST_MSTR_REC = new Reader();

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

                Sort = "X_CLINIC_NBR ASC";

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

        private void Access_U030_TOT_CLAIMS()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("PART_HDR_CLINIC_NBR, ");
            strSQL.Append("PART_HDR_CLAIM_ID, ");
            strSQL.Append("PART_HDR_AMT_BILL, ");
            strSQL.Append("PART_HDR_AMT_PAID, ");
            strSQL.Append("X_AUTO_ADJ, ");
            strSQL.Append("X_HOLD_BACK, ");
            strSQL.Append("X_OVER_PAY, ");
            strSQL.Append("X_PART_BAL, ");
            strSQL.Append("PART_HDR_OHIP_BILL ");
            strSQL.Append("FROM TEMPORARYDATA.U030_TOT_CLAIMS ");

            strSQL.Append(Choose());

            //rdrU030_TOT_CLAIMS.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
            rdrU030_TOT_CLAIMS.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

            strSQL = null;
        }

        private void Link_ICONST_MSTR_REC()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("ICONST_CLINIC_NBR_1_2, ");
            strSQL.Append("ICONST_CLINIC_NBR ");
            strSQL.Append("FROM INDEXED.ICONST_MSTR_REC ");
            strSQL.Append("WHERE ");
            strSQL.Append("ICONST_CLINIC_NBR_1_2 = ").Append(rdrU030_TOT_CLAIMS.GetNumber("PART_HDR_CLINIC_NBR"));

            rdrICONST_MSTR_REC.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

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
        private string X_CLINIC()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.Substring(rdrU030_TOT_CLAIMS.GetString("PART_HDR_CLAIM_ID"), 1, 2);
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private decimal X_OUT_BAL()
        {
            decimal decReturnValue = 0;

            try
            {
                decReturnValue = rdrU030_TOT_CLAIMS.GetNumber("PART_HDR_AMT_BILL") - rdrU030_TOT_CLAIMS.GetNumber("PART_HDR_AMT_PAID");
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private decimal X_UNADJUST_AMT()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrU030_TOT_CLAIMS.GetString("X_AUTO_ADJ")) == QDesign.NULL(" ") & QDesign.NULL(rdrU030_TOT_CLAIMS.GetString("X_HOLD_BACK")) == QDesign.NULL("N") & QDesign.NULL(rdrU030_TOT_CLAIMS.GetString("X_OVER_PAY")) == QDesign.NULL("N"))
                {
                    decReturnValue = X_OUT_BAL();
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private decimal X_AUTO_ADJ_AMT()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrU030_TOT_CLAIMS.GetString("X_AUTO_ADJ")) == QDesign.NULL("Y") | QDesign.NULL(rdrU030_TOT_CLAIMS.GetString("X_HOLD_BACK")) == QDesign.NULL("Y") | QDesign.NULL(rdrU030_TOT_CLAIMS.GetString("X_OVER_PAY")) == QDesign.NULL("Y"))
                {
                    decReturnValue = X_OUT_BAL();
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private decimal X_TRUE_AUTO_ADJ_AMT()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrU030_TOT_CLAIMS.GetString("X_AUTO_ADJ")) == QDesign.NULL("Y") | QDesign.NULL(rdrU030_TOT_CLAIMS.GetString("X_HOLD_BACK")) == QDesign.NULL("Y") | QDesign.NULL(rdrU030_TOT_CLAIMS.GetString("X_OVER_PAY")) == QDesign.NULL("Y"))
                {
                    decReturnValue = rdrU030_TOT_CLAIMS.GetNumber("X_PART_BAL");
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
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
                AddControl(ReportSection.PAGE_HEADING, "INDEXED.ICONST_MSTR_REC.ICONST_CLINIC_NBR", DataTypes.Character, 4);
                AddControl(ReportSection.FOOTING_AT, "X_CLINIC_NBR", DataTypes.Character, 2);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.U030_TOT_CLAIMS.PART_HDR_AMT_BILL", DataTypes.Numeric, 6);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.U030_TOT_CLAIMS.PART_HDR_OHIP_BILL", DataTypes.Numeric, 6);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.U030_TOT_CLAIMS.PART_HDR_AMT_PAID", DataTypes.Numeric, 6);
                AddControl(ReportSection.FOOTING_AT, "X_OUT_BAL", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "X_UNADJUST_AMT", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_AUTO_ADJ_AMT", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_TRUE_AUTO_ADJ_AMT", DataTypes.Numeric, 8);

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
        //# Do not delete, modify or move it.  Updated: 9/27/2017 2:19:26 PM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "INDEXED.ICONST_MSTR_REC.ICONST_CLINIC_NBR":
                    return Common.StringToField(rdrICONST_MSTR_REC.GetString("ICONST_CLINIC_NBR").PadRight(4, ' '));

                case "X_CLINIC_NBR":
                    return Common.StringToField(X_CLINIC().PadRight(2, ' '));

                case "TEMPORARYDATA.U030_TOT_CLAIMS.PART_HDR_AMT_BILL":
                    return rdrU030_TOT_CLAIMS.GetNumber("PART_HDR_AMT_BILL").ToString().PadLeft(6, ' ');

                case "TEMPORARYDATA.U030_TOT_CLAIMS.PART_HDR_OHIP_BILL":
                    return rdrU030_TOT_CLAIMS.GetNumber("PART_HDR_OHIP_BILL").ToString().PadLeft(6, ' ');

                case "TEMPORARYDATA.U030_TOT_CLAIMS.PART_HDR_AMT_PAID":
                    return rdrU030_TOT_CLAIMS.GetNumber("PART_HDR_AMT_PAID").ToString().PadLeft(6, ' ');

                case "X_OUT_BAL":
                    return X_OUT_BAL().ToString().PadLeft(7, ' ');

                case "X_UNADJUST_AMT":
                    return X_UNADJUST_AMT().ToString().PadLeft(8, ' ');

                case "X_AUTO_ADJ_AMT":
                    return X_AUTO_ADJ_AMT().ToString().PadLeft(8, ' ');

                case "X_TRUE_AUTO_ADJ_AMT":
                    return X_TRUE_AUTO_ADJ_AMT().ToString().PadLeft(8, ' ');

                default:
                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_U030_TOT_CLAIMS();

                while (rdrU030_TOT_CLAIMS.Read())
                {
                    Link_ICONST_MSTR_REC();
                    while (rdrICONST_MSTR_REC.Read())
                    {
                        WriteData();
                    }
                    rdrICONST_MSTR_REC.Close();
                }
                rdrU030_TOT_CLAIMS.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrU030_TOT_CLAIMS != null))
            {
                rdrU030_TOT_CLAIMS.Close();
                rdrU030_TOT_CLAIMS = null;
            }
            if ((rdrICONST_MSTR_REC != null))
            {
                rdrICONST_MSTR_REC.Close();
                rdrICONST_MSTR_REC = null;
            }
        }


        #endregion

        #endregion
    }
}
