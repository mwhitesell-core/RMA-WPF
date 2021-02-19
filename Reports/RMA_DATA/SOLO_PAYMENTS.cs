#region "Screen Comments"


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
    public class SOLO_PAYMENTS : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "SOLO_PAYMENTS";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrF119_DOCTOR_YTD = new Reader();
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

                Sort = "DOC_CLINIC_NBR ASC, DOC_DEPT ASC, DOC_NAME ASC";

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

        private void Access_F119_DOCTOR_YTD()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("COMP_CODE, ");
            strSQL.Append("AMT_MTD ");
            strSQL.Append("FROM INDEXED.F119_DOCTOR_YTD ");

            strSQL.Append(Choose());

            rdrF119_DOCTOR_YTD.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

            strSQL = null;
        }

        private void Link_F020_DOCTOR_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("DOC_CLINIC_NBR, ");
            strSQL.Append("DOC_DEPT, ");
            strSQL.Append("DOC_NAME, ");
            strSQL.Append("DOC_INIT1, ");
            strSQL.Append(" DOC_INIT2, ");
            strSQL.Append(" DOC_INIT3 ");
            strSQL.Append("FROM INDEXED.F020_DOCTOR_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_NBR = ").Append(Common.StringToField(rdrF119_DOCTOR_YTD.GetString("DOC_NBR")));

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

            if ((QDesign.NULL(rdrF119_DOCTOR_YTD.GetString("COMP_CODE")) == QDesign.NULL("HAHSO") | QDesign.NULL(rdrF119_DOCTOR_YTD.GetString("COMP_CODE")) == QDesign.NULL("FAMAFP") | QDesign.NULL(rdrF119_DOCTOR_YTD.GetString("COMP_CODE")) == QDesign.NULL("SURGBO") | QDesign.NULL(rdrF119_DOCTOR_YTD.GetString("COMP_CODE")) == QDesign.NULL("LABMED") | QDesign.NULL(rdrF119_DOCTOR_YTD.GetString("COMP_CODE")) == QDesign.NULL("PGPCP") | QDesign.NULL(rdrF119_DOCTOR_YTD.GetString("COMP_CODE")) == QDesign.NULL("AFP") | QDesign.NULL(rdrF119_DOCTOR_YTD.GetString("COMP_CODE")) == QDesign.NULL("PSYCAP") | QDesign.NULL(rdrF119_DOCTOR_YTD.GetString("COMP_CODE")) == QDesign.NULL("PSYPAY") | QDesign.NULL(rdrF119_DOCTOR_YTD.GetString("COMP_CODE")) == QDesign.NULL("SURONC") | QDesign.NULL(rdrF119_DOCTOR_YTD.GetString("COMP_CODE")) == QDesign.NULL("TRANSP") | QDesign.NULL(rdrF119_DOCTOR_YTD.GetString("COMP_CODE")) == QDesign.NULL("AFPRET") | QDesign.NULL(rdrF119_DOCTOR_YTD.GetString("COMP_CODE")) == QDesign.NULL("ACAINC") | QDesign.NULL(rdrF119_DOCTOR_YTD.GetString("COMP_CODE")) == QDesign.NULL("AFPFUN") | QDesign.NULL(rdrF119_DOCTOR_YTD.GetString("COMP_CODE")) == QDesign.NULL("LEACON") | QDesign.NULL(rdrF119_DOCTOR_YTD.GetString("COMP_CODE")) == QDesign.NULL("SAMMP") | QDesign.NULL(rdrF119_DOCTOR_YTD.GetString("COMP_CODE")) == QDesign.NULL("CLIREP") | QDesign.NULL(rdrF119_DOCTOR_YTD.GetString("COMP_CODE")) == QDesign.NULL("AHSC")) & QDesign.NULL(rdrF119_DOCTOR_YTD.GetNumber("AMT_MTD")) > QDesign.NULL(0d))
            {
                blnSelected = true;
            }

            return blnSelected;
        }

        #endregion

        #region " DEFINES "

        private string F020_DOCTOR_MSTR_DOC_INITS()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = (rdrF020_DOCTOR_MSTR.GetString("DOC_INIT1") + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT2") + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT3"));
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
                AddControl(ReportSection.REPORT, "INDEXED.F020_DOCTOR_MSTR.DOC_CLINIC_NBR", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "INDEXED.F119_DOCTOR_YTD.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "INDEXED.F020_DOCTOR_MSTR.DOC_NAME", DataTypes.Character, 24);
                AddControl(ReportSection.REPORT, "F020_DOCTOR_MSTR_DOC_INITS", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "INDEXED.F119_DOCTOR_YTD.COMP_CODE", DataTypes.Character, 6);
                AddControl(ReportSection.REPORT, "INDEXED.F119_DOCTOR_YTD.AMT_MTD", DataTypes.Numeric, 9);
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
        //# Do not delete, modify or move it.  Updated: 9/28/2017 1:58:40 PM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "INDEXED.F020_DOCTOR_MSTR.DOC_CLINIC_NBR":
                    return rdrF020_DOCTOR_MSTR.GetNumber("DOC_CLINIC_NBR").ToString().PadLeft(2, ' ');

                case "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT":
                    return rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT").ToString().PadLeft(2, ' ');

                case "INDEXED.F119_DOCTOR_YTD.DOC_NBR":
                    return Common.StringToField(rdrF119_DOCTOR_YTD.GetString("DOC_NBR").PadRight(3, ' '));

                case "INDEXED.F020_DOCTOR_MSTR.DOC_NAME":
                    return Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_NAME").PadRight(24, ' '));

                case "F020_DOCTOR_MSTR_DOC_INITS":
                    return Common.StringToField(F020_DOCTOR_MSTR_DOC_INITS().PadRight(3, ' '));

                case "INDEXED.F119_DOCTOR_YTD.COMP_CODE":
                    return Common.StringToField(rdrF119_DOCTOR_YTD.GetString("COMP_CODE").PadRight(6, ' '));

                case "INDEXED.F119_DOCTOR_YTD.AMT_MTD":
                    return rdrF119_DOCTOR_YTD.GetNumber("AMT_MTD").ToString().PadLeft(9, ' ');

                default:
                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_F119_DOCTOR_YTD();

                while (rdrF119_DOCTOR_YTD.Read())
                {
                    Link_F020_DOCTOR_MSTR();
                    while (rdrF020_DOCTOR_MSTR.Read())
                    {
                        WriteData();
                    }
                    rdrF020_DOCTOR_MSTR.Close();
                }
                rdrF119_DOCTOR_YTD.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrF119_DOCTOR_YTD != null))
            {
                rdrF119_DOCTOR_YTD.Close();
                rdrF119_DOCTOR_YTD = null;
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
