#region "Screen Comments"

// #> PROGRAM-ID.     r137.qzs    
// ((C)) Dyad Infosys LTD   
// PURPOSE:  When a doctor who is paying `x` % RMA Change reaches the max of 60,000 then he needs to change 
// from RMA % percentage charge to a Flat rate change. Right now Helena watches dept 14 doctors
// who YTD charges are approaching 60,000 to switch them over 
// MODIFICATION HISTORY
// DATE         WHO    DESCRIPTION
// 2015/Apr/30  MC - original
// 2016/Nov/08  MC1    - Helena requested to change from 60,000 to 65,000

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
    public class MP_R137A : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R137A";
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

        private void Access_F119_DOCTOR_YTD()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("COMP_CODE, ");
            strSQL.Append("AMT_MTD, ");
            strSQL.Append("AMT_YTD ");
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
            strSQL.Append("DOC_OHIP_NBR, ");
            strSQL.Append("DOC_DEPT, ");
            strSQL.Append("DOC_RMA_EXPENSE_PERCENT_REG, ");
            strSQL.Append("DOC_RMA_EXPENSE_PERCENT_MISC ");
            strSQL.Append("FROM INDEXED.F020_DOCTOR_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_NBR = ").Append(Common.StringToField(rdrF119_DOCTOR_YTD.GetString("DOC_NBR")));

            rdrF020_DOCTOR_MSTR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

            strSQL = null;
        }

        #endregion

        #region " CHOOSE "

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(string.Empty);

            strChoose.Append(ReportDataFunctions.GetWhereCondition("COMP_CODE", "TOTINC", true));

            return strChoose.ToString();
        }

        #endregion

        #region " SELECT IF "

        public override bool SelectIf()
        {
            bool blnSelected = false;

            if (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT")) == QDesign.NULL(14d) & (QDesign.NULL(rdrF119_DOCTOR_YTD.GetNumber("AMT_MTD")) != QDesign.NULL(0d) | QDesign.NULL(rdrF119_DOCTOR_YTD.GetNumber("AMT_YTD")) != QDesign.NULL(0d))
                && QDesign.NULL(rdrF119_DOCTOR_YTD.GetNumber("AMT_YTD")) <= 6500000 && QDesign.NULL(rdrF020_DOCTOR_MSTR.GetNumber("DOC_RMA_EXPENSE_PERCENT_REG")) != 50000)
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
        //# Do not delete, modify or move it.  Updated: 10/27/2017 11:39:57 AM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "INDEXED.F119_DOCTOR_YTD.DOC_NBR":
                    return Common.StringToField(rdrF119_DOCTOR_YTD.GetString("DOC_NBR").PadRight(3, ' '));

                case "INDEXED.F119_DOCTOR_YTD.COMP_CODE":
                    return Common.StringToField(rdrF119_DOCTOR_YTD.GetString("COMP_CODE").PadRight(6, ' '));

                case "INDEXED.F119_DOCTOR_YTD.AMT_MTD":
                    return rdrF119_DOCTOR_YTD.GetNumber("AMT_MTD").ToString().PadLeft(9, ' ');

                case "INDEXED.F119_DOCTOR_YTD.AMT_YTD":
                    return rdrF119_DOCTOR_YTD.GetNumber("AMT_YTD").ToString().PadLeft(9, ' ');

                case "INDEXED.F020_DOCTOR_MSTR.DOC_RMA_EXPENSE_PERCENT_REG":
                    return rdrF020_DOCTOR_MSTR.GetNumber("DOC_RMA_EXPENSE_PERCENT_REG").ToString().PadLeft(6, ' ');

                case "INDEXED.F020_DOCTOR_MSTR.DOC_RMA_EXPENSE_PERCENT_MISC":
                    return rdrF020_DOCTOR_MSTR.GetNumber("DOC_RMA_EXPENSE_PERCENT_MISC").ToString().PadLeft(6, ' ');

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
