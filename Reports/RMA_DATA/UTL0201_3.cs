#region "Screen Comments"

// -------------------------------------------------------------------------------------
// report2 is the same as report 1 except it will also:
// and link to ep-NBR -1 in f119-doctor-ytd- history(?) to get the `last months value` for that transactions based upon 
// matching doc-nbr, comp-code and ep_nbr being 1 smaller (realize this won`t work on 1st EP of year but we can address later)
// calc amt-diff as mtd of transaction in .ps file - mtd of matching last months transaction found in f119-ytd-history
// sort on dept, docnbr,  DESC on amt-diff
// rep dept page heading, and on line doc nbr, doc name, amt-diff, mtd, ytd;

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
    public class UTL0201_3 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "UTL0201_3";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrUTL0201 = new Reader();
        private Reader rdrF119_DOCTOR_YTD_HISTORY = new Reader();

        #endregion

        #region " Renaissance Data "

        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                // Set Report Properties...
                ReportName = "utl0201_b";
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;

                Sort = "DOC_DEPT ASC, AMT_DIFF DESC, DOC_NBR ASC";

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

        private void Access_UTL0201()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("PREV_EP_NBR, ");
            strSQL.Append("COMP_CODE, ");
            strSQL.Append("AMT_MTD, ");
            strSQL.Append("DOC_DEPT, ");
            strSQL.Append("X_PED, ");
            strSQL.Append("DOC_NAME ");
            strSQL.Append("FROM TEMPORARYDATA.UTL0201 ");

            strSQL.Append(Choose());

            rdrUTL0201.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);

            strSQL = null;
        }

        private void Link_F119_DOCTOR_YTD_HISTORY()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("EP_NBR, ");
            strSQL.Append("REC_TYPE, ");
            strSQL.Append("COMP_CODE, ");
            strSQL.Append("AMT_MTD, ");
            strSQL.Append("AMT_YTD ");
            strSQL.Append("FROM INDEXED.F119_DOCTOR_YTD_HISTORY ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_NBR = ").Append(Common.StringToField(rdrF119_DOCTOR_YTD_HISTORY.GetString("DOC_NBR")));
            strSQL.Append(" AND EP_NBR = ").Append(QDesign.NConvert(rdrUTL0201.GetString("PREV_EP_NBR")));
            strSQL.Append(" AND REC_TYPE = ").Append(Common.StringToField("A"));

            rdrF119_DOCTOR_YTD_HISTORY.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

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

            if (QDesign.NULL(rdrUTL0201.GetString("COMP_CODE")) == QDesign.NULL(rdrF119_DOCTOR_YTD_HISTORY.GetString("COMP_CODE")))
                blnSelected = true;

            return blnSelected;
        }

        #endregion

        #region " DEFINES "

        private decimal AMT_DIFF()
        {
            decimal decReturnValue = 0;

            try
            {
                decReturnValue = rdrUTL0201.GetNumber("AMT_MTD") - rdrF119_DOCTOR_YTD_HISTORY.GetNumber("AMT_MTD");
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
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.UTL0201.X_PED", DataTypes.Character, 6);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.UTL0201.DOC_DEPT", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "INDEXED.F119_DOCTOR_YTD_HISTORY.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.UTL0201.DOC_NAME", DataTypes.Character, 24);
                AddControl(ReportSection.REPORT, "INDEXED.F119_DOCTOR_YTD_HISTORY.COMP_CODE", DataTypes.Character, 6);
                AddControl(ReportSection.REPORT, "AMT_DIFF", DataTypes.Numeric, 7);
                AddControl(ReportSection.REPORT, "INDEXED.F119_DOCTOR_YTD_HISTORY.AMT_MTD", DataTypes.Numeric, 9);
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
        //# Do not delete, modify or move it.  Updated: 6/29/2017 2:55:39 PM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "TEMPORARYDATA.UTL0201.X_PED":
                    return Common.StringToField(rdrUTL0201.GetString("X_PED").PadRight(6, ' '));

                case "TEMPORARYDATA.UTL0201.DOC_DEPT":
                    return rdrUTL0201.GetNumber("DOC_DEPT").ToString().PadLeft(6, ' ');

                case "INDEXED.F119_DOCTOR_YTD_HISTORY.DOC_NBR":
                    return Common.StringToField(rdrF119_DOCTOR_YTD_HISTORY.GetString("DOC_NBR").PadRight(3, ' '));

                case "TEMPORARYDATA.UTL0201.DOC_NAME":
                    return Common.StringToField(rdrUTL0201.GetString("DOC_NAME").PadRight(24, ' '));

                case "INDEXED.F119_DOCTOR_YTD_HISTORY.COMP_CODE":
                    return Common.StringToField(rdrF119_DOCTOR_YTD_HISTORY.GetString("COMP_CODE").PadRight(6, ' '));

                case "AMT_DIFF":
                    return AMT_DIFF().ToString().PadLeft(11, ' ');

                case "INDEXED.F119_DOCTOR_YTD_HISTORY.AMT_MTD":
                    return rdrF119_DOCTOR_YTD_HISTORY.GetNumber("AMT_MTD").ToString().PadLeft(9, ' ');

                case "INDEXED.F119_DOCTOR_YTD_HISTORY.AMT_YTD":
                    return rdrF119_DOCTOR_YTD_HISTORY.GetNumber("AMT_YTD").ToString().PadLeft(9, ' ');

                default:
                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_UTL0201();

                while (rdrUTL0201.Read())
                {
                    Link_F119_DOCTOR_YTD_HISTORY();
                    while (rdrF119_DOCTOR_YTD_HISTORY.Read())
                    {
                        WriteData();
                    }
                    rdrF119_DOCTOR_YTD_HISTORY.Close();
                }
                rdrUTL0201.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrUTL0201 != null))
            {
                rdrUTL0201.Close();
                rdrUTL0201 = null;
            }

            if ((rdrF119_DOCTOR_YTD_HISTORY != null))
            {
                rdrF119_DOCTOR_YTD_HISTORY.Close();
                rdrF119_DOCTOR_YTD_HISTORY = null;
            }
        }

        #endregion

        #endregion
    }
}
