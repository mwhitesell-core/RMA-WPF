#region "Screen Comments"

// DOC: R119C.QZS
// DOC; REPORT MTD AND YTD FIGURES GRAND TOTALS
// DATE      WHO       MODIFICATION
// 93/06/23  YASEMIN   ORIGINAL
// 94/10/03  YASEMIN   CHANGE SORT SEQUENCE OF COMP DESCRIPTION
// 95/01/09  YASEMIN   CHANGE SORT SEQUENCE OF COMP DESCRIPTION
// 98/01/29  J. CHAU   COMMENT OUT SET NOCLOSE
// 03/dec/16 A.A.      alpha doctor nbr
// 08/may/27 M.C.      add the select of rec-type = `A` or `C`
// 08/oct/27 brad1     only rec-type  A  is `visible` to the system -  C  for mary online review only - change select to  A  only
// 14/Feb/24 MC1       define miscellaneous grand totals based on the selected comp codes as requested by Yasemin
// 15/Dec/07 MC2       include MACC, MIBD, MPAP, MSLP, MMDU, MBRT into miscellaneous grand totals
// jc set noclose
// LINK DOC-NBR TO DOC-NBR OF F110-COMPENSATION         OPT      &

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
    public class R119C : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R119C";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        //private Reader rdrF020_DOCTOR_MSTR = new Reader();
        //private Reader rdrF119_DOCTOR_YTD = new Reader();
        //private Reader rdrF190_COMP_CODES = new Reader();
        //private Reader rdrF070_DEPT_MSTR = new Reader();
        //private Reader rdrCONSTANTS_MSTR_REC_6 = new Reader();
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

                Sort = "X_KEY2 ASC";

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

            strSQL.Append("SELECT alldata.* FROM ");
            strSQL.Append("(SELECT mstr.DOC_NBR, mstr.DOC_DEPT, mstr.DOC_FULL_PART_IND, ");
            strSQL.Append("ytd.COMP_CODE, ytd.AMT_MTD, ytd.AMT_YTD, ");
            strSQL.Append("comp.COMP_TYPE, comp.DESC_SHORT, ");
            strSQL.Append("dept.DEPT_NBR, dept.DEPT_COMPANY, ");
            strSQL.Append("constmstr.CURRENT_EP_NBR, ");
            // GW2018. April 30. Changed. strSQL.Append("CONCAT(ytd.COMP_CODE_GROUP, RIGHT(REPORTING_SEQ, 2), ytd.COMP_CODE) X_KEY2 ");
            strSQL.Append("CONCAT(ytd.COMP_CODE_GROUP, RIGHT('00'+CAST(reporting_seq AS VARCHAR(2)),2), ytd.COMP_CODE) X_KEY2 ");
            strSQL.Append("FROM [INDEXED].[F020_DOCTOR_MSTR] mstr ");
            strSQL.Append("LEFT OUTER JOIN [INDEXED].[F119_DOCTOR_YTD] ytd ON ytd.DOC_NBR = mstr.DOC_NBR and ytd.REC_TYPE = 'A'");
            strSQL.Append("LEFT OUTER JOIN [101C].[INDEXED].[F190_COMP_CODES] comp ON comp.COMP_CODE = ytd.COMP_CODE ");
            strSQL.Append("LEFT OUTER JOIN [101C].[INDEXED].[F070_DEPT_MSTR] dept ON dept.DEPT_NBR = mstr.DOC_DEPT ");
            strSQL.Append("LEFT OUTER JOIN [INDEXED].[CONSTANTS_MSTR_REC_6] constmstr ON constmstr.CONST_REC_NBR = 6 ");
            strSQL.Append(") AS alldata ");
            strSQL.Append("ORDER BY X_KEY2");

            rdrDATA.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

            strSQL = null;
        }

        //private void Access_F020_DOCTOR_MSTR()
        //{
        //    StringBuilder strSQL = new StringBuilder(string.Empty);

        //    strSQL.Append("SELECT ");
        //    strSQL.Append("DOC_NBR, ");
        //    strSQL.Append("DOC_DEPT, ");
        //    strSQL.Append("DOC_INIT1, ");
        //    strSQL.Append(" DOC_INIT2, ");
        //    strSQL.Append(" DOC_INIT3, ");
        //    strSQL.Append("DOC_NAME, ");
        //    strSQL.Append("DOC_FULL_PART_IND ");
        //    strSQL.Append("FROM INDEXED.F020_DOCTOR_MSTR ");

        //    strSQL.Append(Choose());

        //    rdrF020_DOCTOR_MSTR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

        //    strSQL = null;
        //}

        //private void Link_F119_DOCTOR_YTD()
        //{
        //    StringBuilder strSQL = new StringBuilder(string.Empty);

        //    strSQL.Append("SELECT ");
        //    strSQL.Append("DOC_NBR, ");
        //    strSQL.Append("COMP_CODE, ");
        //    strSQL.Append("REC_TYPE, ");
        //    strSQL.Append("COMP_CODE_GROUP, ");
        //    strSQL.Append("AMT_MTD, ");
        //    strSQL.Append("AMT_YTD ");
        //    strSQL.Append("FROM INDEXED.F119_DOCTOR_YTD ");
        //    strSQL.Append("WHERE ");
        //    strSQL.Append("DOC_NBR = ").Append(Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_NBR")));

        //    strSQL.Append(SelectIf_F119_DOCTOR_YTD(true));

        //    rdrF119_DOCTOR_YTD.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

        //    strSQL = null;
        //}

        //private void Link_F190_COMP_CODES()
        //{
        //    StringBuilder strSQL = new StringBuilder(string.Empty);

        //    strSQL.Append("SELECT ");
        //    strSQL.Append("REPORTING_SEQ, ");
        //    strSQL.Append("COMP_TYPE, ");
        //    strSQL.Append("DESC_SHORT ");
        //    strSQL.Append("FROM INDEXED.F190_COMP_CODES ");
        //    strSQL.Append("WHERE ");
        //    strSQL.Append("COMP_CODE = ").Append(Common.StringToField(rdrF119_DOCTOR_YTD.GetString("COMP_CODE")));

        //    rdrF190_COMP_CODES.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

        //    strSQL = null;
        //}

        //private void Link_F070_DEPT_MSTR()
        //{
        //    StringBuilder strSQL = new StringBuilder(string.Empty);

        //    strSQL.Append("SELECT ");
        //    strSQL.Append("DEPT_NBR ");
        //    strSQL.Append("FROM INDEXED.F070_DEPT_MSTR ");
        //    strSQL.Append("WHERE ");
        //    strSQL.Append("DEPT_NBR = ").Append(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT"));

        //    rdrF070_DEPT_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

        //    strSQL = null;
        //}

        //private void Link_CONSTANTS_MSTR_REC_6()
        //{
        //    StringBuilder strSQL = new StringBuilder(string.Empty);

        //    strSQL.Append("SELECT ");
        //    strSQL.Append("CONST_REC_NBR, ");
        //    strSQL.Append("CURRENT_EP_NBR ");
        //    strSQL.Append("FROM INDEXED.CONSTANTS_MSTR_REC_6 ");
        //    strSQL.Append("WHERE ");
        //    strSQL.Append("CONST_REC_NBR = ").Append(6);

        //    rdrCONSTANTS_MSTR_REC_6.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

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

        //private string SelectIf_F119_DOCTOR_YTD(bool blnAddWhere)
        //{
        //    StringBuilder strSQL = new StringBuilder(string.Empty);

        //    if (blnAddWhere)
        //    {
        //        strSQL.Append(" WHERE ");
        //    }
        //    else
        //    {
        //        strSQL.Append(" AND ");
        //    }

        //    strSQL.Append(" (    REC_TYPE =  'A')");

        //    return strSQL.ToString();
        //}

        #endregion

        #region " DEFINES "

        private string W_DOC_NAME()
        {
            string strReturnValue = string.Empty;

            try
            {
                if (QDesign.NULL(rdrDATA.GetString("DOC_NAME")) != QDesign.NULL(""))
                {
                    strReturnValue = "DR. " + rdrDATA.GetString("DOC_INIT1") + rdrDATA.GetString("DOC_INIT2") + rdrDATA.GetString("DOC_INIT3") + " " + rdrDATA.GetString("DOC_NAME");
                }
                else
                {
                    strReturnValue = "UNKNOWN!";
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_CLASS()
        {
            string strReturnValue = string.Empty;

            try
            {
                if (QDesign.NULL(rdrDATA.GetString("DOC_FULL_PART_IND")) == "F")
                {
                    strReturnValue = "FULL TIME";
                }
                else if (QDesign.NULL(rdrDATA.GetString("DOC_FULL_PART_IND")) == "P")
                {
                    strReturnValue = "PART TIME";
                }
                else if (QDesign.NULL(rdrDATA.GetString("DOC_FULL_PART_IND")) == "C")
                {
                    strReturnValue = "CLINICAL SCHOLARS";
                }
                else if (QDesign.NULL(rdrDATA.GetString("DOC_FULL_PART_IND")) == "S")
                {
                    strReturnValue = "PLASTIC SURGERY";
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private decimal MISC_MTD()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(QDesign.Substring(rdrDATA.GetString("COMP_CODE"), 1, 4)) == "MISC" | QDesign.NULL(QDesign.Substring(rdrDATA.GetString("COMP_CODE"), 1, 3)) == "MIC" | QDesign.NULL(rdrDATA.GetString("COMP_CODE")) == "RESSUP" | QDesign.NULL(rdrDATA.GetString("COMP_CODE")) == "MISJ" | QDesign.NULL(rdrDATA.GetString("COMP_CODE")) == "MISP" | QDesign.NULL(rdrDATA.GetString("COMP_CODE")) == "MOHR" | QDesign.NULL(rdrDATA.GetString("COMP_CODE")) == "HOCC" | QDesign.NULL(rdrDATA.GetString("COMP_CODE")) == "MHSC" | QDesign.NULL(rdrDATA.GetString("COMP_CODE")) == "AGEP" | QDesign.NULL(rdrDATA.GetString("COMP_CODE")) == "DHSC" | QDesign.NULL(rdrDATA.GetString("COMP_CODE")) == "MOHD" | QDesign.NULL(rdrDATA.GetString("COMP_CODE")) == "MACC" | QDesign.NULL(rdrDATA.GetString("COMP_CODE")) == "MIBD" | QDesign.NULL(rdrDATA.GetString("COMP_CODE")) == "MPAP" | QDesign.NULL(rdrDATA.GetString("COMP_CODE")) == "MSLP" | QDesign.NULL(rdrDATA.GetString("COMP_CODE")) == "MMDU" | QDesign.NULL(rdrDATA.GetString("COMP_CODE")) == "MBRT")
                {
                    decReturnValue = rdrDATA.GetNumber("AMT_MTD");
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal MISC_YTD()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(QDesign.Substring(rdrDATA.GetString("COMP_CODE"), 1, 4)) == "MISC" | QDesign.NULL(QDesign.Substring(rdrDATA.GetString("COMP_CODE"), 1, 3)) == "MIC" | QDesign.NULL(rdrDATA.GetString("COMP_CODE")) == "RESSUP" | QDesign.NULL(rdrDATA.GetString("COMP_CODE")) == "MISJ" | QDesign.NULL(rdrDATA.GetString("COMP_CODE")) == "MISP" | QDesign.NULL(rdrDATA.GetString("COMP_CODE")) == "MOHR" | QDesign.NULL(rdrDATA.GetString("COMP_CODE")) == "HOCC" | QDesign.NULL(rdrDATA.GetString("COMP_CODE")) == "MHSC" | QDesign.NULL(rdrDATA.GetString("COMP_CODE")) == "AGEP" | QDesign.NULL(rdrDATA.GetString("COMP_CODE")) == "DHSC" | QDesign.NULL(rdrDATA.GetString("COMP_CODE")) == "MOHD" | QDesign.NULL(rdrDATA.GetString("COMP_CODE")) == "MACC" | QDesign.NULL(rdrDATA.GetString("COMP_CODE")) == "MIBD" | QDesign.NULL(rdrDATA.GetString("COMP_CODE")) == "MPAP" | QDesign.NULL(rdrDATA.GetString("COMP_CODE")) == "MSLP" | QDesign.NULL(rdrDATA.GetString("COMP_CODE")) == "MMDU" | QDesign.NULL(rdrDATA.GetString("COMP_CODE")) == "MBRT")
                {
                    decReturnValue = rdrDATA.GetNumber("AMT_YTD");
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        //private string X_KEY2()
        //{
        //    string strReturnValue = string.Empty;

        //    try
        //    {
        //        strReturnValue = rdrF119_DOCTOR_YTD.GetString("COMP_CODE_GROUP") + QDesign.ASCII(rdrF190_COMP_CODES.GetNumber("REPORTING_SEQ"), 2) + rdrF119_DOCTOR_YTD.GetString("COMP_CODE");
        //    }

        //    catch (Exception ex)
        //    {
        //        // Write the exception to the log file.
        //        ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        //    }

        //    return strReturnValue;
        //}

        //private string W_DOC_NAME()
        //{
        //    string strReturnValue = string.Empty;

        //    try
        //    {
        //        if (ReportDataFunctions.Exists(rdrF020_DOCTOR_MSTR))
        //        {
        //            strReturnValue = "DR. " + rdrF020_DOCTOR_MSTR.GetString("DOC_INITS") + " " + rdrF020_DOCTOR_MSTR.GetString("DOC_NAME");
        //        }
        //        else
        //        {
        //            strReturnValue = "UNKNOWN!";
        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        // Write the exception to the log file.
        //        ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        //    }

        //    return strReturnValue;
        //}

        //private string X_CLASS()
        //{
        //    string strReturnValue = string.Empty;

        //    try
        //    {
        //        if (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "F")
        //        {
        //            strReturnValue = "FULL TIME";
        //        }
        //        else if (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "P")
        //        {
        //            strReturnValue = "PART TIME";
        //        }
        //        else if (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "C")
        //        {
        //            strReturnValue = "CLINICAL SCHOLARS";
        //        }
        //        else if (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "S")
        //        {
        //            strReturnValue = "PLASTIC SURGERY";
        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        // Write the exception to the log file.
        //        ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        //    }

        //    return strReturnValue;
        //}

        //private decimal MISC_MTD()
        //{
        //    decimal decReturnValue = 0;

        //    try
        //    {
        //        if (QDesign.NULL(QDesign.Substring(rdrF119_DOCTOR_YTD.GetString("COMP_CODE"), 1, 4)) == "MISC" | QDesign.NULL(QDesign.Substring(rdrF119_DOCTOR_YTD.GetString("COMP_CODE"), 1, 3)) == "MIC" | QDesign.NULL(rdrF119_DOCTOR_YTD.GetString("COMP_CODE")) == "RESSUP" | QDesign.NULL(rdrF119_DOCTOR_YTD.GetString("COMP_CODE")) == "MISJ" | QDesign.NULL(rdrF119_DOCTOR_YTD.GetString("COMP_CODE")) == "MISP" | QDesign.NULL(rdrF119_DOCTOR_YTD.GetString("COMP_CODE")) == "MOHR" | QDesign.NULL(rdrF119_DOCTOR_YTD.GetString("COMP_CODE")) == "HOCC" | QDesign.NULL(rdrF119_DOCTOR_YTD.GetString("COMP_CODE")) == "MHSC" | QDesign.NULL(rdrF119_DOCTOR_YTD.GetString("COMP_CODE")) == "AGEP" | QDesign.NULL(rdrF119_DOCTOR_YTD.GetString("COMP_CODE")) == "DHSC" | QDesign.NULL(rdrF119_DOCTOR_YTD.GetString("COMP_CODE")) == "MOHD" | QDesign.NULL(rdrF119_DOCTOR_YTD.GetString("COMP_CODE")) == "MACC" | QDesign.NULL(rdrF119_DOCTOR_YTD.GetString("COMP_CODE")) == "MIBD" | QDesign.NULL(rdrF119_DOCTOR_YTD.GetString("COMP_CODE")) == "MPAP" | QDesign.NULL(rdrF119_DOCTOR_YTD.GetString("COMP_CODE")) == "MSLP" | QDesign.NULL(rdrF119_DOCTOR_YTD.GetString("COMP_CODE")) == "MMDU" | QDesign.NULL(rdrF119_DOCTOR_YTD.GetString("COMP_CODE")) == "MBRT")
        //        {
        //            decReturnValue = rdrF119_DOCTOR_YTD.GetNumber("AMT_MTD");
        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        // Write the exception to the log file.
        //        ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        //    }

        //    return decReturnValue;
        //}

        //private decimal MISC_YTD()
        //{
        //    decimal decReturnValue = 0;

        //    try
        //    {
        //        if (QDesign.NULL(QDesign.Substring(rdrF119_DOCTOR_YTD.GetString("COMP_CODE"), 1, 4)) == "MISC" | QDesign.NULL(QDesign.Substring(rdrF119_DOCTOR_YTD.GetString("COMP_CODE"), 1, 3)) == "MIC" | QDesign.NULL(rdrF119_DOCTOR_YTD.GetString("COMP_CODE")) == "RESSUP" | QDesign.NULL(rdrF119_DOCTOR_YTD.GetString("COMP_CODE")) == "MISJ" | QDesign.NULL(rdrF119_DOCTOR_YTD.GetString("COMP_CODE")) == "MISP" | QDesign.NULL(rdrF119_DOCTOR_YTD.GetString("COMP_CODE")) == "MOHR" | QDesign.NULL(rdrF119_DOCTOR_YTD.GetString("COMP_CODE")) == "HOCC" | QDesign.NULL(rdrF119_DOCTOR_YTD.GetString("COMP_CODE")) == "MHSC" | QDesign.NULL(rdrF119_DOCTOR_YTD.GetString("COMP_CODE")) == "AGEP" | QDesign.NULL(rdrF119_DOCTOR_YTD.GetString("COMP_CODE")) == "DHSC" | QDesign.NULL(rdrF119_DOCTOR_YTD.GetString("COMP_CODE")) == "MOHD" | QDesign.NULL(rdrF119_DOCTOR_YTD.GetString("COMP_CODE")) == "MACC" | QDesign.NULL(rdrF119_DOCTOR_YTD.GetString("COMP_CODE")) == "MIBD" | QDesign.NULL(rdrF119_DOCTOR_YTD.GetString("COMP_CODE")) == "MPAP" | QDesign.NULL(rdrF119_DOCTOR_YTD.GetString("COMP_CODE")) == "MSLP" | QDesign.NULL(rdrF119_DOCTOR_YTD.GetString("COMP_CODE")) == "MMDU" | QDesign.NULL(rdrF119_DOCTOR_YTD.GetString("COMP_CODE")) == "MBRT")
        //        {
        //            decReturnValue = rdrF119_DOCTOR_YTD.GetNumber("AMT_YTD");
        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        // Write the exception to the log file.
        //        ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        //    }

        //    return decReturnValue;
        //}

        #endregion

        #region " CONTROLS "

        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.PAGE_HEADING, "INDEXED.CONSTANTS_MSTR_REC_6.CURRENT_EP_NBR", DataTypes.Numeric, 6);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F190_COMP_CODES.COMP_TYPE", DataTypes.Character, 1);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F119_DOCTOR_YTD.COMP_CODE", DataTypes.Character, 6);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F190_COMP_CODES.DESC_SHORT", DataTypes.Character, 15);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F119_DOCTOR_YTD.AMT_MTD", DataTypes.Numeric, 9);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F119_DOCTOR_YTD.AMT_YTD", DataTypes.Numeric, 9);
                AddControl(ReportSection.FINAL_FOOTING, "MISC_MTD", DataTypes.Numeric, 10);
                AddControl(ReportSection.FINAL_FOOTING, "MISC_YTD", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "X_KEY2", DataTypes.Character, 9);
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
        //# Do not delete, modify or move it.  Updated: 6/29/2017 2:19:22 PM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "INDEXED.CONSTANTS_MSTR_REC_6.CURRENT_EP_NBR":
                    return rdrDATA.GetNumber("CURRENT_EP_NBR").ToString().PadLeft(6, ' ');

                case "INDEXED.F190_COMP_CODES.COMP_TYPE":
                    return Common.StringToField(rdrDATA.GetString("COMP_TYPE").PadRight(1, ' '));

                case "INDEXED.F119_DOCTOR_YTD.COMP_CODE":
                    return Common.StringToField(rdrDATA.GetString("COMP_CODE").PadRight(6, ' '));

                case "INDEXED.F190_COMP_CODES.DESC_SHORT":
                    return Common.StringToField(rdrDATA.GetString("DESC_SHORT").PadRight(15, ' '));

                case "INDEXED.F119_DOCTOR_YTD.AMT_MTD":
                    return rdrDATA.GetNumber("AMT_MTD").ToString().PadLeft(12, ' ');

                case "INDEXED.F119_DOCTOR_YTD.AMT_YTD":
                    return rdrDATA.GetNumber("AMT_YTD").ToString().PadLeft(12, ' ');

                case "MISC_MTD":
                    return MISC_MTD().ToString().PadLeft(10, ' ');

                case "MISC_YTD":
                    return MISC_YTD().ToString().PadLeft(10, ' ');

                case "X_KEY2":
                    return Common.StringToField(rdrDATA.GetString("X_KEY2")).PadRight(9, ' ');

                default:
                    return string.Empty;
            }
        }

        //public override string ReturnControlValue(string strControl, int intSize)
        //{
        //    switch (strControl)
        //    {
        //        case "INDEXED.CONSTANTS_MSTR_REC_6.CURRENT_EP_NBR":
        //            return rdrCONSTANTS_MSTR_REC_6.GetNumber("CURRENT_EP_NBR").ToString().PadLeft(6, ' ');

        //        case "INDEXED.F190_COMP_CODES.COMP_TYPE":
        //            return Common.StringToField(rdrF190_COMP_CODES.GetString("COMP_TYPE").PadRight(1, ' '));

        //        case "INDEXED.F119_DOCTOR_YTD.COMP_CODE":
        //            return Common.StringToField(rdrF119_DOCTOR_YTD.GetString("COMP_CODE").PadRight(6, ' '));

        //        case "INDEXED.F190_COMP_CODES.DESC_SHORT":
        //            return Common.StringToField(rdrF190_COMP_CODES.GetString("DESC_SHORT").PadRight(15, ' '));

        //        case "INDEXED.F119_DOCTOR_YTD.AMT_MTD":
        //            return rdrF119_DOCTOR_YTD.GetNumber("AMT_MTD").ToString().PadLeft(12, ' ');

        //        case "INDEXED.F119_DOCTOR_YTD.AMT_YTD":
        //            return rdrF119_DOCTOR_YTD.GetNumber("AMT_YTD").ToString().PadLeft(12, ' ');

        //        case "MISC_MTD":
        //            return MISC_MTD().ToString().PadLeft(10,' ');

        //        case "MISC_YTD":
        //            return MISC_YTD().ToString().PadLeft(10,' ');

        //        case "X_KEY2":
        //            return Common.StringToField(X_KEY2(), intSize);

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
        //        Access_F020_DOCTOR_MSTR();

        //        while (rdrF020_DOCTOR_MSTR.Read())
        //        {
        //            Link_F119_DOCTOR_YTD();
        //            while (rdrF119_DOCTOR_YTD.Read())
        //            {
        //                Link_F190_COMP_CODES();
        //                Link_F070_DEPT_MSTR();
        //                Link_CONSTANTS_MSTR_REC_6();
        //                while ((rdrCONSTANTS_MSTR_REC_6.Read()))
        //                {
        //                    WriteData();
        //                }
        //                rdrCONSTANTS_MSTR_REC_6.Close();
        //                rdrF070_DEPT_MSTR.Close();
        //                rdrF190_COMP_CODES.Close();
        //            }
        //            rdrF119_DOCTOR_YTD.Close();
        //        }
        //        rdrF020_DOCTOR_MSTR.Close();

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

            //if ((rdrF020_DOCTOR_MSTR != null))
            //{
            //    rdrF020_DOCTOR_MSTR.Close();
            //    rdrF020_DOCTOR_MSTR = null;
            //}

            //if ((rdrF119_DOCTOR_YTD != null))
            //{
            //    rdrF119_DOCTOR_YTD.Close();
            //    rdrF119_DOCTOR_YTD = null;
            //}

            //if ((rdrF190_COMP_CODES != null))
            //{
            //    rdrF190_COMP_CODES.Close();
            //    rdrF190_COMP_CODES = null;
            //}

            //if ((rdrF070_DEPT_MSTR != null))
            //{
            //    rdrF070_DEPT_MSTR.Close();
            //    rdrF070_DEPT_MSTR = null;
            //}

            //if ((rdrCONSTANTS_MSTR_REC_6 != null))
            //{
            //    rdrCONSTANTS_MSTR_REC_6.Close();
            //    rdrCONSTANTS_MSTR_REC_6 = null;
            //}
        }

        #endregion

        #endregion
    }
}
