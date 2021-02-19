#region "Screen Comments"

// PROGRAM: R121B.QZS
//      REPORT MTD AND YTD FIGURES PRINT AT DOC-DEPT
//
// DATE WHO       MODIFICATION
// 94/08/17  B.M.L.ORIGINAL
// 94/11/03  YASEMIN ADD CLASS PLASTIC SURGERY
// 95/01/09  YASEMIN CHANGE SORT ORDER TO MATCH R119A.QZS
// 98/01/29  J.CHAU COMMENT OUT SET NOCLOSE
// 14/may/14 MC1 link to f112 to not select pay code 7
//

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
    public class MP_R121B : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R121B";
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

                Sort = "X_KEY2 ASC, X_KEY1 ASC";

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
            strSQL.Append("dept.DEPT_NBR, dept.DEPT_COMPANY, dept.DEPT_NAME, ");
            strSQL.Append("constmstr.CURRENT_EP_NBR, ");
            strSQL.Append("concat(ytd.comp_code_group, CASE WHEN len(right(reporting_seq,2)) < 2 THEN REPLICATE('0', len(right(reporting_seq,2))) + right(reporting_seq,2) ELSE right(reporting_seq,2) END, ytd.COMP_CODE) x_key1, ");
            strSQL.Append("x_key2 = (CASE WHEN mstr.DOC_DEPT = 14 THEN 'D' ");
            strSQL.Append("WHEN mstr.DOC_FULL_PART_IND = 'F' THEN 'A' ");
            strSQL.Append("WHEN mstr.DOC_FULL_PART_IND = 'P' THEN 'B' ");
            strSQL.Append("WHEN DOC_FULL_PART_IND = 'C' THEN 'C' ");
            strSQL.Append("WHEN DOC_FULL_PART_IND = 'S' THEN 'S' ");
            strSQL.Append("ELSE 'E' END) ");
            strSQL.Append("FROM [INDEXED].[F020_DOCTOR_MSTR] mstr ");
            strSQL.Append("INNER JOIN [INDEXED].[F119_DOCTOR_YTD] ytd ON ytd.DOC_NBR = mstr.DOC_NBR ");
            strSQL.Append("LEFT OUTER JOIN [101C].[INDEXED].[F190_COMP_CODES] comp ON ytd.COMP_CODE = comp.COMP_CODE ");
            strSQL.Append("LEFT OUTER JOIN [101C].[INDEXED].[F070_DEPT_MSTR] Dept ON dept.DEPT_NBR = mstr.DOC_dept ");
            strSQL.Append("LEFT OUTER JOIN [INDEXED].[CONSTANTS_MSTR_REC_6] constmstr ON constmstr.CONST_REC_NBR = 6 ");
            strSQL.Append("INNER JOIN [INDEXED].[F112_PYCDCEILINGS] pyd ON pyd.DOC_NBR = mstr.DOC_NBR and pyd.EP_NBR = constmstr.CURRENT_EP_NBR ");
            strSQL.Append("WHERE pyd.DOC_PAY_CODE != '7' ) AS alldata ");
            strSQL.Append("ORDER BY x_key2, x_key1 ");

            rdrDATA.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

            strSQL = null;
        }

        //private void Access_F020_DOCTOR_MSTR()
        //{
        //    StringBuilder strSQL = new StringBuilder(string.Empty);

        //    strSQL.Append("SELECT ");
        //    strSQL.Append("DOC_NBR, ");
        //    strSQL.Append("DOC_DEPT ");
        //    strSQL.Append("FROM INDEXED.F020_DOCTOR_MSTR ");

        //    strSQL.Append(Choose());

        //    rdrF020_DOCTOR_MSTR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

        //    strSQL = null;
        //}

        //private void Link_F119_DOCTOR_YTD()
        //{
        //    StringBuilder strSQL = new StringBuilder(string.Empty);

        //    strSQL.Append("SELECT ");
        //    strSQL.Append("COMP_CODE, ");
        //    strSQL.Append("AMT_MTD, ");
        //    strSQL.Append("AMT_YTD ");
        //    strSQL.Append("FROM INDEXED.F119_DOCTOR_YTD ");
        //    strSQL.Append("WHERE ");
        //    strSQL.Append("DOC_NBR = ").Append(Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_NBR")));

        //    strSQL.Append(SelectIf_F119_DOCTOR_YTD(true));

        //    rdrF119_DOCTOR_YTD.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

        //    strSQL = null;
        //}

        //private void Link_F190_COMP_CODES()
        //{
        //    StringBuilder strSQL = new StringBuilder(string.Empty);

        //    strSQL.Append("SELECT ");
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
        //    strSQL.Append("DEPT_NBR, ");
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

        //    strSQL.Append("(REC_TYPE = 'A')");

        //    return strSQL.ToString();
        //}

        #endregion

        #region " DEFINES "
        private string X_CLASS()
        {
            string strReturnValue = string.Empty;

            try
            {
                if (QDesign.NULL(rdrDATA.GetString("X_KEY2")) == "A")
                {
                    strReturnValue = "FULL TIME";
                }
                else if (QDesign.NULL(rdrDATA.GetString("X_KEY2")) == "B")
                {
                    strReturnValue = "PART TIME";
                }
                else if (QDesign.NULL(rdrDATA.GetString("X_KEY2")) == "C")
                {
                    strReturnValue = "CLINICAL SCHOLARS";
                }
                else if (QDesign.NULL(rdrDATA.GetString("X_KEY2")) == "S")
                {
                    strReturnValue = "PLASTIC SURGERY";
                }
                else if (QDesign.NULL(rdrDATA.GetString("X_KEY2")) == "D")
                {
                    strReturnValue = "DEPT-14        ";
                }
                else if (QDesign.NULL(rdrDATA.GetString("X_KEY2")) == "E")
                {
                    strReturnValue = "UNKNOWN";
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        //private string X_KEY1()
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

        //private string X_KEY2()
        //{
        //    string strReturnValue = string.Empty;

        //    try
        //    {
        //        if (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT")) == 14)
        //        {
        //            strReturnValue = "D";
        //        }
        //        else if (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "F")
        //        {
        //            strReturnValue = "A";
        //        }
        //        else if (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "P")
        //        {
        //            strReturnValue = "B";
        //        }
        //        else if (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "C")
        //        {
        //            strReturnValue = "C";
        //        }
        //        else if (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "S")
        //        {
        //            strReturnValue = "S";
        //        }
        //        else
        //        {
        //            strReturnValue = "E";
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
        //        if (QDesign.NULL(X_KEY2()) == "A")
        //        {
        //            strReturnValue = "FULL TIME";
        //        }
        //        else if (QDesign.NULL(X_KEY2()) == "B")
        //        {
        //            strReturnValue = "PART TIME";
        //        }
        //        else if (QDesign.NULL(X_KEY2()) == "C")
        //        {
        //            strReturnValue = "CLINICAL SCHOLARS";
        //        }
        //        else if (QDesign.NULL(X_KEY2()) == "S")
        //        {
        //            strReturnValue = "PLASTIC SURGERY";
        //        }
        //        else if (QDesign.NULL(X_KEY2()) == "D")
        //        {
        //            strReturnValue = "DEPT-14        ";
        //        }
        //        else if (QDesign.NULL(X_KEY2()) == "E")
        //        {
        //            strReturnValue = "UNKNOWN";
        //        }
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
                AddControl(ReportSection.PAGE_HEADING, "INDEXED.CONSTANTS_MSTR_REC_6.CURRENT_EP_NBR", DataTypes.Numeric, 6);
                AddControl(ReportSection.HEADING_AT, "X_CLASS", DataTypes.Character, 18);
                AddControl(ReportSection.HEADING_AT, "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT", DataTypes.Numeric, 2);
                AddControl(ReportSection.HEADING_AT, "INDEXED.F070_DEPT_MSTR.DEPT_NAME", DataTypes.Character, 30);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F190_COMP_CODES.COMP_TYPE", DataTypes.Character, 1);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F119_DOCTOR_YTD.COMP_CODE", DataTypes.Character, 6);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F190_COMP_CODES.DESC_SHORT", DataTypes.Character, 15);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F119_DOCTOR_YTD.AMT_MTD", DataTypes.Numeric, 9);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F119_DOCTOR_YTD.AMT_YTD", DataTypes.Numeric, 9);
                AddControl(ReportSection.REPORT, "X_KEY2", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "X_KEY1", DataTypes.Character, 9);
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
        //# Do not delete, modify or move it.  Updated: 6/29/2017 2:21:09 PM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "INDEXED.CONSTANTS_MSTR_REC_6.CURRENT_EP_NBR":
                    return rdrDATA.GetNumber("CURRENT_EP_NBR").ToString().PadLeft(6, ' ');

                case "X_CLASS":
                    return Common.StringToField(X_CLASS(), intSize);

                case "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT":
                    return rdrDATA.GetNumber("DOC_DEPT").ToString().PadLeft(2, ' ');

                case "INDEXED.F070_DEPT_MSTR.DEPT_NAME":
                    return Common.StringToField(rdrDATA.GetString("DEPT_NAME").PadRight(30, ' '));

                case "INDEXED.F190_COMP_CODES.COMP_TYPE":
                    return Common.StringToField(rdrDATA.GetString("COMP_TYPE").PadRight(1, ' '));

                case "INDEXED.F119_DOCTOR_YTD.COMP_CODE":
                    return Common.StringToField(rdrDATA.GetString("COMP_CODE").PadRight(6, ' '));

                case "INDEXED.F190_COMP_CODES.DESC_SHORT":
                    return Common.StringToField(rdrDATA.GetString("DESC_SHORT").PadRight(15, ' '));

                case "INDEXED.F119_DOCTOR_YTD.AMT_MTD":
                    return rdrDATA.GetNumber("AMT_MTD").ToString().PadLeft(10, ' ');

                case "INDEXED.F119_DOCTOR_YTD.AMT_YTD":
                    return rdrDATA.GetNumber("AMT_YTD").ToString().PadLeft(10, ' ');

                case "X_KEY2":
                    return Common.StringToField(rdrDATA.GetString("X_KEY2").PadRight(9, ' '));

                case "X_KEY1":
                    return Common.StringToField(rdrDATA.GetString("X_KEY1").PadRight(1, ' '));

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

        //        case "X_CLASS":
        //            return Common.StringToField(X_CLASS(), intSize);

        //        case "INDEXED.F190_COMP_CODES.COMP_TYPE":
        //            return Common.StringToField(rdrF190_COMP_CODES.GetString("COMP_TYPE").PadRight(1, ' '));

        //        case "INDEXED.F119_DOCTOR_YTD.COMP_CODE":
        //            return Common.StringToField(rdrF119_DOCTOR_YTD.GetString("COMP_CODE").PadRight(6, ' '));

        //        case "INDEXED.F190_COMP_CODES.DESC_SHORT":
        //            return Common.StringToField(rdrF190_COMP_CODES.GetString("DESC_SHORT").PadRight(15, ' '));

        //        case "INDEXED.F119_DOCTOR_YTD.AMT_MTD":
        //            return rdrF119_DOCTOR_YTD.GetNumber("AMT_MTD").ToString().PadLeft(10, ' ');

        //        case "INDEXED.F119_DOCTOR_YTD.AMT_YTD":
        //            return rdrF119_DOCTOR_YTD.GetNumber("AMT_YTD").ToString().PadLeft(10, ' ');

        //        case "X_KEY2":
        //            return Common.StringToField(X_KEY2(), intSize);

        //        case "X_KEY1":
        //            return Common.StringToField(X_KEY1(), intSize);

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