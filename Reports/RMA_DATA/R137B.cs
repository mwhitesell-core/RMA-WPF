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
    public class R137B : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R137B";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        //private Reader rdrF119_DOCTOR_YTD = new Reader();
        //private Reader rdrF020_DOCTOR_MSTR = new Reader();
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

        private void Access_Data()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT alldata.* FROM (SELECT mstr.DOC_NBR, ytd.COMP_CODE, ytd.AMT_MTD, ytd.AMT_YTD, mstr.DOC_RMA_EXPENSE_PERCENT_REG, mstr.DOC_RMA_EXPENSE_PERCENT_MISC ");
            strSQL.Append("FROM [INDEXED].[F119_DOCTOR_YTD] ytd ");
            strSQL.Append("INNER JOIN [INDEXED].[F020_DOCTOR_MSTR] mstr ON ytd.DOC_NBR = mstr.DOC_NBR ");
            strSQL.Append("WHERE (ytd.COMP_CODE = 'TOTINC' AND ytd.REC_TYPE = 'A' AND mstr.DOC_DEPT = '14' AND (ytd.AMT_MTD <> 0 or ytd.AMT_YTD <> 0) AND ytd.AMT_YTD > 6500000 AND mstr.DOC_RMA_EXPENSE_PERCENT_REG <> 0)) AS alldata");

            rdrDATA.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

            strSQL = null;
        }

        //private void Access_F119_DOCTOR_YTD()
        //{
        //    StringBuilder strSQL = new StringBuilder(string.Empty);

        //    strSQL.Append("SELECT ");
        //    strSQL.Append("DOC_NBR, ");
        //    strSQL.Append("COMP_CODE, ");
        //    strSQL.Append("REC_TYPE, ");
        //    strSQL.Append("AMT_MTD, ");
        //    strSQL.Append("AMT_YTD ");
        //    strSQL.Append("FROM INDEXED.F119_DOCTOR_YTD ");

        //    strSQL.Append(Choose());

        //    rdrF119_DOCTOR_YTD.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

        //    strSQL = null;
        //}

        //private void Link_F020_DOCTOR_MSTR()
        //{
        //    StringBuilder strSQL = new StringBuilder(string.Empty);

        //    strSQL.Append("SELECT ");
        //    strSQL.Append("DOC_NBR, ");
        //    strSQL.Append("DOC_OHIP_NBR, ");
        //    strSQL.Append("DOC_DEPT, ");
        //    strSQL.Append("DOC_RMA_EXPENSE_PERCENT_REG, ");
        //    strSQL.Append("DOC_RMA_EXPENSE_PERCENT_MISC ");
        //    strSQL.Append("FROM INDEXED.F020_DOCTOR_MSTR ");
        //    strSQL.Append("WHERE ");
        //    strSQL.Append("DOC_NBR = ");
        //    strSQL.Append(" AND DOC_OHIP_NBR = ");

        //    rdrF020_DOCTOR_MSTR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

        //    strSQL = null;
        //}

        #endregion

        #region " CHOOSE "

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(string.Empty);

            //strChoose.Append(ReportDataFunctions.GetWhereCondition("COMP_CODE", "TOTINC", true));
            //strChoose.Append(ReportDataFunctions.GetWhereCondition("REC_TYPE", "A"));

            return strChoose.ToString();
        }

        #endregion

        #region " SELECT IF "

        //public override bool SelectIf()
        //{
        //    bool blnSelected = false;

        //    if (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT")) == 14 & (QDesign.NULL(rdrF119_DOCTOR_YTD.GetNumber("AMT_MTD")) != 0 | QDesign.NULL(rdrF119_DOCTOR_YTD.GetNumber("AMT_YTD")) != 0))
        //        blnSelected = true;

        //    return blnSelected;
        //}

        #endregion

        #region " DEFINES "

        #endregion

        #region " CONTROLS "

        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.REPORT, "INDEXED.F119_DOCTOR_YTD.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "INDEXED.F119_DOCTOR_YTD.COMP_CODE", DataTypes.Character, 6);
                AddControl(ReportSection.REPORT, "INDEXED.F119_DOCTOR_YTD.AMT_MTD", DataTypes.Numeric, 9);
                AddControl(ReportSection.REPORT, "INDEXED.F119_DOCTOR_YTD.AMT_YTD", DataTypes.Numeric, 9);
                AddControl(ReportSection.REPORT, "INDEXED.F020_DOCTOR_MSTR.DOC_RMA_EXPENSE_PERCENT_REG", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "INDEXED.F020_DOCTOR_MSTR.DOC_RMA_EXPENSE_PERCENT_MISC", DataTypes.Numeric, 6);
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
        //# Do not delete, modify or move it.  Updated: 6/29/2017 2:23:25 PM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "INDEXED.F119_DOCTOR_YTD.DOC_NBR":
                    return Common.StringToField(rdrDATA.GetString("DOC_NBR").PadRight(3, ' '));

                case "INDEXED.F119_DOCTOR_YTD.COMP_CODE":
                    return Common.StringToField(rdrDATA.GetString("COMP_CODE").PadRight(6, ' '));

                case "INDEXED.F119_DOCTOR_YTD.AMT_MTD":
                    return rdrDATA.GetNumber("AMT_MTD").ToString().PadLeft(9, ' ');

                case "INDEXED.F119_DOCTOR_YTD.AMT_YTD":
                    return rdrDATA.GetNumber("AMT_YTD").ToString().PadLeft(9, ' ');

                case "INDEXED.F020_DOCTOR_MSTR.DOC_RMA_EXPENSE_PERCENT_REG":
                    return rdrDATA.GetNumber("DOC_RMA_EXPENSE_PERCENT_REG").ToString().PadLeft(6, ' ');

                case "INDEXED.F020_DOCTOR_MSTR.DOC_RMA_EXPENSE_PERCENT_MISC":
                    return rdrDATA.GetNumber("DOC_RMA_EXPENSE_PERCENT_MISC").ToString().PadLeft(6, ' ');

                default:
                    return string.Empty;
            }
        }

        //public override string ReturnControlValue(string strControl, int intSize)
        //{
        //    switch (strControl)
        //    {
        //        case "INDEXED.F119_DOCTOR_YTD.DOC_NBR":
        //            return Common.StringToField(rdrF119_DOCTOR_YTD.GetString("DOC_NBR").PadRight(3, ' '));

        //        case "INDEXED.F119_DOCTOR_YTD.COMP_CODE":
        //            return Common.StringToField(rdrF119_DOCTOR_YTD.GetString("COMP_CODE").PadRight(6, ' '));

        //        case "INDEXED.F119_DOCTOR_YTD.AMT_MTD":
        //            return rdrF119_DOCTOR_YTD.GetNumber("AMT_MTD").ToString().PadLeft(9, ' ');

        //        case "INDEXED.F119_DOCTOR_YTD.AMT_YTD":
        //            return rdrF119_DOCTOR_YTD.GetNumber("AMT_YTD").ToString().PadLeft(9, ' ');

        //        case "INDEXED.F020_DOCTOR_MSTR.DOC_RMA_EXPENSE_PERCENT_REG":
        //            return rdrF020_DOCTOR_MSTR.GetNumber("DOC_RMA_EXPENSE_PERCENT_REG").ToString().PadLeft(6, ' ');

        //        case "INDEXED.F020_DOCTOR_MSTR.DOC_RMA_EXPENSE_PERCENT_MISC":
        //            return rdrF020_DOCTOR_MSTR.GetNumber("DOC_RMA_EXPENSE_PERCENT_MISC").ToString().PadLeft(6, ' ');

        //        default:
        //            return string.Empty;
        //    }
        //}

        public override void AccessData()
        {
            try
            {
                Access_Data();

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

        //public override void AccessData()
        //{
        //    try
        //    {
        //        Access_F119_DOCTOR_YTD();

        //        while (rdrF119_DOCTOR_YTD.Read())
        //        {
        //            Link_F020_DOCTOR_MSTR();
        //            while (rdrF020_DOCTOR_MSTR.Read())
        //            {
        //                WriteData();
        //            }
        //            rdrF020_DOCTOR_MSTR.Close();
        //        }
        //        rdrF119_DOCTOR_YTD.Close();

        //    }

        //    catch (Exception ex)
        //    {
        //        ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        //    }
        //}

        public override void CloseReaders()
        {
            if ((rdrDATA != null))
            {
                rdrDATA.Close();
                rdrDATA = null;
            }

            //if ((rdrF119_DOCTOR_YTD != null))
            //{
            //    rdrF119_DOCTOR_YTD.Close();
            //    rdrF119_DOCTOR_YTD = null;
            //}

            //if ((rdrF020_DOCTOR_MSTR != null))
            //{
            //    rdrF020_DOCTOR_MSTR.Close();
            //    rdrF020_DOCTOR_MSTR = null;
            //}
        }

        #endregion

        #endregion
    }
}
