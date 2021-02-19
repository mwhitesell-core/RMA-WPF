#region "Screen Comments"

// #> PROGRAM-ID.     r128b.qzs   
// ((C)) Dyad Infosys LTD 
// PURPOSE: Second pass to prdecimal Inactive Doctors report who have no earnings for 3 most recent months
// MODIFICATION HISTORY
// DATE    SAF #  WHO      DESCRIPTION
// 2014/Jul/16  M.C.     - original
// 2015/Oct/21  MC1   - select for dept 14 or 15 with pay code 2 for Helena`s request as the original selection from r128a.qts
// - use different subfile on the access statement
// MC1
// access *r128a_inactive   

#endregion

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
    public class R128B : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R128B";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrR128A_INACTIVE_DOC_WITH_CLM = new Reader();
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

        private void Access_R128A_INACTIVE_DOC_WITH_CLM()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_DEPT, ");
            strSQL.Append("DOC_EP_PAY_CODE, ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("DOC_NAME, ");
            strSQL.Append("DOC_DATE_FAC_START_YY, ");
            strSQL.Append("DOC_DATE_FAC_START_MM, ");
            strSQL.Append("DOC_DATE_FAC_START_DD, ");
            strSQL.Append("DOC_DATE_FAC_TERM_YY, ");
            strSQL.Append("DOC_DATE_FAC_TERM_MM, ");
            strSQL.Append("DOC_DATE_FAC_TERM_DD, ");
            strSQL.Append("X_CLAIM_BAL ");
            strSQL.Append("FROM TEMPORARYDATA.R128A_INACTIVE_DOC_WITH_CLM ");

            strSQL.Append(Choose());

            rdrR128A_INACTIVE_DOC_WITH_CLM.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);

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

            if ((QDesign.NULL(rdrR128A_INACTIVE_DOC_WITH_CLM.GetNumber("DOC_DEPT")) == QDesign.NULL(14d) | QDesign.NULL(rdrR128A_INACTIVE_DOC_WITH_CLM.GetNumber("DOC_DEPT")) == QDesign.NULL(15d)) & QDesign.NULL(rdrR128A_INACTIVE_DOC_WITH_CLM.GetString("DOC_EP_PAY_CODE")) == QDesign.NULL("2"))
                blnSelected = true;

            return blnSelected;
        }

        #endregion

        #region " DEFINES "

        private System.Decimal DOC_DATE_FAC_START()
        {
            decimal decReturnValue = 0;

            try
            {
                decReturnValue = QDesign.NConvert(Convert.ToString(rdrR128A_INACTIVE_DOC_WITH_CLM.GetNumber("DOC_DATE_FAC_START_YY")) + Convert.ToString(rdrR128A_INACTIVE_DOC_WITH_CLM.GetNumber("DOC_DATE_FAC_START_MM").ToString().PadLeft(2, '0')) + Convert.ToString(rdrR128A_INACTIVE_DOC_WITH_CLM.GetNumber("DOC_DATE_FAC_START_DD").ToString().PadLeft(2, '0')));
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private System.Decimal DOC_DATE_FAC_TERM()
        {
            decimal decReturnValue = 0;

            try
            {
                decReturnValue = QDesign.NConvert(Convert.ToString(rdrR128A_INACTIVE_DOC_WITH_CLM.GetNumber("DOC_DATE_FAC_TERM_YY")) + Convert.ToString(rdrR128A_INACTIVE_DOC_WITH_CLM.GetNumber("DOC_DATE_FAC_TERM_MM").ToString().PadLeft(2, '0')) + Convert.ToString(rdrR128A_INACTIVE_DOC_WITH_CLM.GetNumber("DOC_DATE_FAC_TERM_DD").ToString().PadLeft(2, '0')));
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
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R128A_INACTIVE_DOC_WITH_CLM.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R128A_INACTIVE_DOC_WITH_CLM.DOC_DEPT", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R128A_INACTIVE_DOC_WITH_CLM.DOC_NAME", DataTypes.Character, 24);
                AddControl(ReportSection.REPORT, "DOC_DATE_FAC_START", DataTypes.Numeric, 8);
                AddControl(ReportSection.REPORT, "DOC_DATE_FAC_TERM", DataTypes.Numeric, 8);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R128A_INACTIVE_DOC_WITH_CLM.X_CLAIM_BAL", DataTypes.Numeric, 10);
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
        //# Do not delete, modify or move it.  Updated: 2017-07-24 5:05:05 PM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "TEMPORARYDATA.R128A_INACTIVE_DOC_WITH_CLM.DOC_NBR":
                    return Common.StringToField(rdrR128A_INACTIVE_DOC_WITH_CLM.GetString("DOC_NBR"));

                case "TEMPORARYDATA.R128A_INACTIVE_DOC_WITH_CLM.DOC_DEPT":
                    return rdrR128A_INACTIVE_DOC_WITH_CLM.GetNumber("DOC_DEPT").ToString();

                case "TEMPORARYDATA.R128A_INACTIVE_DOC_WITH_CLM.DOC_NAME":
                    return Common.StringToField(rdrR128A_INACTIVE_DOC_WITH_CLM.GetString("DOC_NAME"));

                case "DOC_DATE_FAC_START":
                    return DOC_DATE_FAC_START().ToString().PadLeft(8, ' ');

                case "DOC_DATE_FAC_TERM":
                    return DOC_DATE_FAC_TERM().ToString().PadLeft(8, ' ');

                case "TEMPORARYDATA.R128A_INACTIVE_DOC_WITH_CLM.X_CLAIM_BAL":
                    return rdrR128A_INACTIVE_DOC_WITH_CLM.GetNumber("X_CLAIM_BAL").ToString();

                default:
                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_R128A_INACTIVE_DOC_WITH_CLM();

                while (rdrR128A_INACTIVE_DOC_WITH_CLM.Read())
                {
                    WriteData();
                }
                rdrR128A_INACTIVE_DOC_WITH_CLM.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrR128A_INACTIVE_DOC_WITH_CLM != null))
            {
                rdrR128A_INACTIVE_DOC_WITH_CLM.Close();
                rdrR128A_INACTIVE_DOC_WITH_CLM = null;
            }
        }


        #endregion

        #endregion
    }
}
