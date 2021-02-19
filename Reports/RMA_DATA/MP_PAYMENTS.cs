
#region "Screen Comments"

// 2009/04/17 Yas  - take out RESSUP as per Mary 2009/04 
// 2009/11/01 Yas  - take out AFPRUN as per Mary 2009/11/18

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
    public class MP_PAYMENTS : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "MP_PAYMENTS";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrDATA = new Reader();

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

        private void Access_DATA()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT a.DOC_NBR, a.COMP_CODE, a.AMT_MTD, ");
            strSQL.Append("b.DOC_DEPT, b.DOC_NAME, b.DOC_INIT1, b.DOC_INIT2, b.DOC_INIT3, ");
            strSQL.Append("c.DOC_CLINIC_NBR ");
            strSQL.Append("FROM INDEXED.F119_DOCTOR_YTD a ");
            strSQL.Append("LEFT OUTER JOIN INDEXED.F020_DOCTOR_MSTR b ON b.DOC_NBR = a.DOC_NBR ");
            strSQL.Append("LEFT OUTER JOIN (");
            strSQL.Append("SELECT DOC_NBR, DOC_CLINIC_NBR ");
            strSQL.Append("FROM (");
            strSQL.Append("SELECT DOC_NBR, DOC_CLINIC_NBR, ROW_NUMBER() OVER(PARTITION BY DOC_NBR ORDER BY DOC_NBR) AS ROWNUM ");
            strSQL.Append("FROM INDEXED.F020C_DOC_CLINIC_NEXT_BATCH_NBR) AS data ");
            strSQL.Append("WHERE ROWNUM = 1) AS c ON c.DOC_NBR = b.DOC_NBR ");
            strSQL.Append("WHERE a.COMP_CODE IN ('HAHSO', 'FAMAFP', 'SURGBO', 'LABMED', 'PGPCP', 'AFP', 'PSYCAP', 'PSYPAY', 'SURONC', 'TRANSP', 'AFPRET', 'ACAINC', 'LEACON', 'SAMMP', 'CLIREP', 'RECRUI', 'AFPBON', 'NEUSRF', 'RETCLI', 'EDUCON', 'AHSC') ");
            strSQL.Append("AND a.AMT_MTD > 0 ");
            strSQL.Append("ORDER BY c.DOC_CLINIC_NBR ASC, b.DOC_DEPT ASC, b.DOC_NAME ASC ");

            rdrDATA.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

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

        private string F020_DOCTOR_MSTR_DOC_INITS()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = (rdrDATA.GetString("DOC_INIT1") + rdrDATA.GetString("DOC_INIT2") + rdrDATA.GetString("DOC_INIT3"));
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
                AddControl(ReportSection.REPORT, "INDEXED.F020C_DOC_CLINIC_NEXT_BATCH_NBR.DOC_CLINIC_NBR", DataTypes.Numeric, 2);
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
        //# Do not delete, modify or move it.  Updated: 10/26/2017 11:46:39 AM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "INDEXED.F020C_DOC_CLINIC_NEXT_BATCH_NBR.DOC_CLINIC_NBR":
                    return rdrDATA.GetNumber("DOC_CLINIC_NBR").ToString().PadLeft(2, ' ');

                case "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT":
                    return rdrDATA.GetNumber("DOC_DEPT").ToString().PadLeft(2, ' ');

                case "INDEXED.F119_DOCTOR_YTD.DOC_NBR":
                    return Common.StringToField(rdrDATA.GetString("DOC_NBR").PadRight(3, ' '));

                case "INDEXED.F020_DOCTOR_MSTR.DOC_NAME":
                    return Common.StringToField(rdrDATA.GetString("DOC_NAME").PadRight(24, ' '));

                case "F020_DOCTOR_MSTR_DOC_INITS":
                    return Common.StringToField(F020_DOCTOR_MSTR_DOC_INITS().PadRight(3, ' '));

                case "INDEXED.F119_DOCTOR_YTD.COMP_CODE":
                    return Common.StringToField(rdrDATA.GetString("COMP_CODE").PadRight(6, ' '));

                case "INDEXED.F119_DOCTOR_YTD.AMT_MTD":
                    return rdrDATA.GetNumber("AMT_MTD").ToString().PadLeft(9, ' ');

                default:
                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_DATA();

                while (rdrDATA.Read())
                {
                    WriteData();
                }
                rdrDATA.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if (rdrDATA != null)
            {
                rdrDATA.Close();
                rdrDATA = null;
            }
        }

        #endregion

        #endregion
    }
}
