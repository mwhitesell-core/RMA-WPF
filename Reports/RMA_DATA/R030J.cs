#region "Screen Comments"

// #> PROGRAM-ID.     R030J.QZS
// ((C)) Dyad Technologies
// PROGRAM PURPOSE : PRINT THE CLAIMS WITH REMAINING BALANCE SO
// USER CAN MANUALLY ADJUST
// MODIFICATION HISTORY
// DATE   WHO          DESCRIPTION
// 94/FEB/01 M.C.         - ORIGINAL (SMS 144)
// 04/Jun/03 M.C.      - alpha doc nbr
// 07/jun/27 M.C.         - do not include x-sel-dtl = 0
// which either means no record exists part-paid-dtl 
// or record with explan cd = 35 with zero amt paid
// 07/jul/30 M.C.         - undo on 07/jun/27

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
    public class R030J : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R030J";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrU030_NO_ADJCLM_CREATED = new Reader();

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

        private void Access_U030_NO_ADJCLM_CREATED()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("X_TOT_BAL, ");
            strSQL.Append("X_PART_BAL, ");
            strSQL.Append("PART_HDR_CLAIM_ID, ");
            strSQL.Append("X_SEL_DTL ");
            strSQL.Append("FROM TEMPORARYDATA.U030_NO_ADJCLM_CREATED ");

            strSQL.Append(Choose());

            rdrU030_NO_ADJCLM_CREATED.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);

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

            if ((QDesign.NULL(X_BAL_DIFF()) != QDesign.NULL(0d) & QDesign.NULL(rdrU030_NO_ADJCLM_CREATED.GetNumber("X_SEL_DTL")) > QDesign.NULL(0d)) | QDesign.NULL(rdrU030_NO_ADJCLM_CREATED.GetNumber("X_SEL_DTL")) == QDesign.NULL(0d))
            {
                blnSelected = true;
            }

            return blnSelected;
        }

        #endregion

        #region " DEFINES "

        private decimal X_BAL_DIFF()
        {
            decimal decReturnValue = 0;

            try
            {
                decReturnValue = rdrU030_NO_ADJCLM_CREATED.GetNumber("X_PART_BAL") - rdrU030_NO_ADJCLM_CREATED.GetNumber("X_TOT_BAL");
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private string X_CLINIC_NBR()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.Substring(rdrU030_NO_ADJCLM_CREATED.GetString("PART_HDR_CLAIM_ID"), 1, 2);
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_CLAIM_NBR()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.Substring(rdrU030_NO_ADJCLM_CREATED.GetString("PART_HDR_CLAIM_ID"), 1, 2) + QDesign.Substring(rdrU030_NO_ADJCLM_CREATED.GetString("PART_HDR_CLAIM_ID"), 3, 8);
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
                AddControl(ReportSection.PAGE_HEADING, "X_CLINIC_NBR", DataTypes.Character, 2);
                AddControl(ReportSection.REPORT, "X_CLAIM_NBR", DataTypes.Character, 10);
                AddControl(ReportSection.REPORT, "X_BAL_DIFF", DataTypes.Numeric, 7);
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
        //# Do not delete, modify or move it.  Updated: 9/27/2017 12:59:37 PM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "X_CLINIC_NBR":
                    return Common.StringToField(X_CLINIC_NBR().PadRight(2, ' '));

                case "X_CLAIM_NBR":
                    return Common.StringToField(X_CLAIM_NBR().PadRight(10, ' '));

                case "X_BAL_DIFF":
                    return X_BAL_DIFF().ToString().PadLeft(7, ' ');

                default:
                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_U030_NO_ADJCLM_CREATED();

                while (rdrU030_NO_ADJCLM_CREATED.Read())
                {
                    WriteData();
                }
                rdrU030_NO_ADJCLM_CREATED.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrU030_NO_ADJCLM_CREATED != null))
            {
                rdrU030_NO_ADJCLM_CREATED.Close();
                rdrU030_NO_ADJCLM_CREATED = null;
            }
        }


        #endregion

        #endregion
    }
}
