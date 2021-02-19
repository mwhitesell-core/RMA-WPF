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
    public class PAYEFT : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "PAYEFT";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        //private Reader rdrF119_DOCTOR_YTD = new Reader();
        //private Reader rdrF020_DOCTOR_MSTR = new Reader();
        //private Reader rdrF070_DEPT_MSTR = new Reader();
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

            strSQL.Append("SELECT ");
            strSQL.Append("ytd.DOC_NBR, ");
            strSQL.Append("ytd.COMP_CODE, ");
            strSQL.Append("ytd.AMT_YTD, ");
            strSQL.Append("ytd.AMT_MTD, ");
            strSQL.Append("mstr.DOC_DEPT, ");
            strSQL.Append("mstr.DOC_NAME, ");
            strSQL.Append("mstr.DOC_INIT1, ");
            strSQL.Append("mstr.DOC_INIT2, ");
            strSQL.Append("mstr.DOC_INIT3, ");
            strSQL.Append("dept.DEPT_COMPANY ");
            strSQL.Append("FROM INDEXED.F119_DOCTOR_YTD  ytd ");
            strSQL.Append("LEFT OUTER JOIN INDEXED.F020_DOCTOR_MSTR  mstr ");
            strSQL.Append("ON mstr.DOC_NBR = ytd.DOC_NBR ");
            strSQL.Append("LEFT OUTER JOIN [101C].INDEXED.F070_DEPT_MSTR  dept ");
            strSQL.Append("ON dept.DEPT_NBR = mstr.DOC_DEPT ");
            strSQL.Append("WHERE ytd.COMP_CODE = 'PAYEFT' AND ytd.AMT_YTD <> 0");

            rdrDATA.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

            strSQL = null;
        }

        //private void Access_F119_DOCTOR_YTD()
        //{
        //    StringBuilder strSQL = new StringBuilder(string.Empty);

        //    strSQL.Append("SELECT ");
        //    strSQL.Append("DOC_NBR, ");
        //    strSQL.Append("COMP_CODE, ");
        //    strSQL.Append("AMT_YTD, ");
        //    strSQL.Append("AMT_MTD ");
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
        //    strSQL.Append("DOC_DEPT, ");
        //    strSQL.Append("DOC_NAME, ");
        //    strSQL.Append("DOC_INIT1, ");
        //    strSQL.Append(" DOC_INIT2, ");
        //    strSQL.Append(" DOC_INIT3 ");
        //    strSQL.Append("FROM INDEXED.F020_DOCTOR_MSTR ");
        //    strSQL.Append("WHERE ");
        //    strSQL.Append("DOC_NBR = ").Append(Common.StringToField(rdrF119_DOCTOR_YTD.GetString("DOC_NBR")));

        //    rdrF020_DOCTOR_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

        //    strSQL = null;
        //}

        //private void Link_F070_DEPT_MSTR()
        //{
        //    StringBuilder strSQL = new StringBuilder(string.Empty);

        //    strSQL.Append("SELECT ");
        //    strSQL.Append("DEPT_NBR, ");
        //    strSQL.Append("DEPT_COMPANY ");
        //    strSQL.Append("FROM INDEXED.F070_DEPT_MSTR ");
        //    strSQL.Append("WHERE ");
        //    strSQL.Append("DEPT_NBR = ").Append(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT"));

        //    rdrF070_DEPT_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

        //    strSQL = null;
        //}

        #endregion

        #region " CHOOSE "

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(string.Empty);
            
            return strChoose.ToString();
        }

        #endregion

        #region " SELECT IF "

        //public override bool SelectIf()
        //{
        //    bool blnSelected = false;

        //    if (QDesign.NULL(rdrF119_DOCTOR_YTD.GetString("COMP_CODE")) == "PAYEFT" & QDesign.NULL(rdrF119_DOCTOR_YTD.GetNumber("AMT_YTD")) != 0)
        //        blnSelected = true;
            
        //    return blnSelected;
        //}

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

        private string F119_DOCTOR_YTD_COMP_CODE()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = rdrDATA.GetString("COMP_CODE").Substring(0, 5);
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        //private string F020_DOCTOR_MSTR_DOC_INITS()
        //{
        //    string strReturnValue = string.Empty;

        //    try
        //    {
        //        strReturnValue = (rdrF020_DOCTOR_MSTR.GetString("DOC_INIT1") + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT2") + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT3"));
        //    }

        //    catch (Exception ex)
        //    {
        //        // Write the exception to the log file.
        //        ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        //    }

        //    return strReturnValue;
        //}

        #endregion

        #region " CONTROLS "

        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.REPORT, "INDEXED.F119_DOCTOR_YTD.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT", DataTypes.Numeric, 3);
                AddControl(ReportSection.REPORT, "INDEXED.F070_DEPT_MSTR.DEPT_COMPANY", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "INDEXED.F020_DOCTOR_MSTR.DOC_NAME", DataTypes.Character, 24);
                AddControl(ReportSection.REPORT, "DOC_INITS", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "COMP_CODE", DataTypes.Character, 6);
                AddControl(ReportSection.REPORT, "INDEXED.F119_DOCTOR_YTD.AMT_MTD", DataTypes.Float, 12);
                AddControl(ReportSection.REPORT, "INDEXED.F119_DOCTOR_YTD.AMT_YTD", DataTypes.Float, 12);
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
        //# Do not delete, modify or move it.  Updated: 6/29/2017 2:18:06 PM

        public override string ReturnControlValue(string strControl, int intSize)
        {

            switch (strControl)
            {
                case "INDEXED.F119_DOCTOR_YTD.DOC_NBR":
                    return Common.StringToField(rdrDATA.GetString("DOC_NBR").PadRight(3, ' '));

                case "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT":
                    return rdrDATA.GetNumber("DOC_DEPT").ToString().PadLeft(2, ' ');

                case "INDEXED.F070_DEPT_MSTR.DEPT_COMPANY":
                    return rdrDATA.GetNumber("DEPT_COMPANY").ToString().PadLeft(2, ' ');

                case "INDEXED.F020_DOCTOR_MSTR.DOC_NAME":
                    return Common.StringToField(rdrDATA.GetString("DOC_NAME").PadRight(24, ' '));

                case "DOC_INITS":
                    return Common.StringToField(F020_DOCTOR_MSTR_DOC_INITS(), intSize);

                case "COMP_CODE":
                    return Common.StringToField(F119_DOCTOR_YTD_COMP_CODE(), intSize);

                case "INDEXED.F119_DOCTOR_YTD.AMT_MTD":
                    return rdrDATA.GetNumber("AMT_MTD").ToString().PadLeft(9, ' ');

                case "INDEXED.F119_DOCTOR_YTD.AMT_YTD":
                    return rdrDATA.GetNumber("AMT_YTD").ToString().PadLeft(9, ' ');

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

        //        case "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT":
        //            return rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT").ToString().PadLeft(2, ' ');

        //        case "INDEXED.F070_DEPT_MSTR.DEPT_COMPANY":
        //            return rdrF070_DEPT_MSTR.GetNumber("DEPT_COMPANY").ToString().PadLeft(2, ' ');

        //        case "INDEXED.F020_DOCTOR_MSTR.DOC_NAME":
        //            return Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_NAME").PadRight(24, ' '));

        //        case "DOC_INITS":
        //            return Common.StringToField(F020_DOCTOR_MSTR_DOC_INITS(), intSize);

        //        case "INDEXED.F119_DOCTOR_YTD.COMP_CODE":
        //            return Common.StringToField(rdrF119_DOCTOR_YTD.GetString("COMP_CODE").PadRight(6, ' '));

        //        case "INDEXED.F119_DOCTOR_YTD.AMT_MTD":
        //            return rdrF119_DOCTOR_YTD.GetNumber("AMT_MTD").ToString().PadLeft(9, ' ');

        //        case "INDEXED.F119_DOCTOR_YTD.AMT_YTD":
        //            return rdrF119_DOCTOR_YTD.GetNumber("AMT_YTD").ToString().PadLeft(9, ' ');

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

                //Access_F119_DOCTOR_YTD();

                //while (rdrF119_DOCTOR_YTD.Read())
                //{
                //    Link_F020_DOCTOR_MSTR();
                //    while (rdrF020_DOCTOR_MSTR.Read())
                //    {
                //        Link_F070_DEPT_MSTR();
                //        while ((rdrF070_DEPT_MSTR.Read()))
                //        {
                //            WriteData();
                //        }
                //        rdrF070_DEPT_MSTR.Close();
                //    }
                //    rdrF020_DOCTOR_MSTR.Close();
                //}
                //rdrF119_DOCTOR_YTD.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

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

            //if ((rdrF070_DEPT_MSTR != null))
            //{
            //    rdrF070_DEPT_MSTR.Close();
            //    rdrF070_DEPT_MSTR = null;
            //}
        }
        
        #endregion

        #endregion
    }
}
