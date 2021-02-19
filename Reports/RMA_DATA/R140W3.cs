#region "Screen Comments"

// Program : r140w3.qzs
// purpose:  Report any doctors who: - weren`t exists in f020-doctor-mstr     
// or    weren`t exists from governance file  with the group number
// 2008/nov/05 M.C. - Yasemin requests to extract the records if either of the conditions is true 
// A)  If doctor in the governance file even with zero amount and it`s missing from 
// f020-doctor-mstr (doc-ohip-nbr/afp-paym-group)
// B)  If doctor have a group number in f020-doctor-mstr but it is not in the governance file
// so that she can notify the hospital
// - change select statement and add final footing for legend

#endregion

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
    public class R140W3 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R140W3";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrTMP_GOVERNANCE_PAYMENTS_FILE = new Reader();

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

                Sort = "DOC_AFP_PAYM_GROUP ASC, AFP_SOLO_NAME ASC, DOC_OHIP_NBR ASC";

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

        private void Access_TMP_GOVERNANCE_PAYMENTS_FILE()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("REPORTED_IN_R140B_REPORT, ");
            strSQL.Append("DOC_AFP_PAYM_GROUP, ");
            strSQL.Append("AFP_SOLO_NAME, ");
            strSQL.Append("DOC_OHIP_NBR ");
            strSQL.Append("FROM [101C].INDEXED.TMP_GOVERNANCE_PAYMENTS_FILE ");

            strSQL.Append(Choose());

            rdrTMP_GOVERNANCE_PAYMENTS_FILE.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

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

            if (QDesign.NULL(rdrTMP_GOVERNANCE_PAYMENTS_FILE.GetString("REPORTED_IN_R140B_REPORT")) == QDesign.NULL(" ") | QDesign.NULL(rdrTMP_GOVERNANCE_PAYMENTS_FILE.GetString("REPORTED_IN_R140B_REPORT")) == QDesign.NULL("M"))
            {
                blnSelected = true;
            }

            return blnSelected;
        }

        #endregion

        #region " DEFINES "

        #endregion

        #region " CONTROLS "

        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.HEADING_AT, "INDEXED.TMP_GOVERNANCE_PAYMENTS_FILE.DOC_AFP_PAYM_GROUP", DataTypes.Character, 4);
                AddControl(ReportSection.REPORT, "INDEXED.TMP_GOVERNANCE_PAYMENTS_FILE.DOC_OHIP_NBR", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "INDEXED.TMP_GOVERNANCE_PAYMENTS_FILE.AFP_SOLO_NAME", DataTypes.Character, 75);
                AddControl(ReportSection.REPORT, "INDEXED.TMP_GOVERNANCE_PAYMENTS_FILE.REPORTED_IN_R140B_REPORT", DataTypes.Character, 1);
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
        //# Do not delete, modify or move it.  Updated: 9/28/2017 11:17:55 AM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "INDEXED.TMP_GOVERNANCE_PAYMENTS_FILE.DOC_AFP_PAYM_GROUP":
                    return Common.StringToField(rdrTMP_GOVERNANCE_PAYMENTS_FILE.GetString("DOC_AFP_PAYM_GROUP").PadRight(4, ' '));

                case "INDEXED.TMP_GOVERNANCE_PAYMENTS_FILE.DOC_OHIP_NBR":
                    return rdrTMP_GOVERNANCE_PAYMENTS_FILE.GetNumber("DOC_OHIP_NBR").ToString().PadLeft(6, ' ');

                case "INDEXED.TMP_GOVERNANCE_PAYMENTS_FILE.AFP_SOLO_NAME":
                    return Common.StringToField(rdrTMP_GOVERNANCE_PAYMENTS_FILE.GetString("AFP_SOLO_NAME").PadRight(75, ' '));

                case "INDEXED.TMP_GOVERNANCE_PAYMENTS_FILE.REPORTED_IN_R140B_REPORT":
                    return Common.StringToField(rdrTMP_GOVERNANCE_PAYMENTS_FILE.GetString("REPORTED_IN_R140B_REPORT").PadRight(1, ' '));

                default:

                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_TMP_GOVERNANCE_PAYMENTS_FILE();

                while (rdrTMP_GOVERNANCE_PAYMENTS_FILE.Read())
                {
                    WriteData();
                }
                rdrTMP_GOVERNANCE_PAYMENTS_FILE.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrTMP_GOVERNANCE_PAYMENTS_FILE != null))
            {
                rdrTMP_GOVERNANCE_PAYMENTS_FILE.Close();
                rdrTMP_GOVERNANCE_PAYMENTS_FILE = null;
            }
        }


        #endregion

        #endregion
    }
}
