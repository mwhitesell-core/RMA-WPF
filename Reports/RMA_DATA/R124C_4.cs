#region "Screen Comments"

// TODO - access f119 and get final value to ensure it matches one from subfile above
// link doc-nbr to doc-nbr of f020-doctor-extra  opt  &

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
    public class R124C_4 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R124C_4";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        //private Reader rdrF119_DOCTOR_YTD = new Reader();
        //private Reader rdrCONSTANTS_MSTR_REC_6 = new Reader();
        //private Reader rdrF112_PYCDCEILINGS = new Reader();
        //private Reader rdrF020_DOCTOR_MSTR = new Reader();
        //private Reader rdrF070_DEPT_MSTR = new Reader();
        //private Reader rdrF080_BANK_MSTR = new Reader();
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

            strSQL.Append("SELECT alldata.* FROM (SELECT mstr.DOC_NBR, mstr.DOC_DEPT, mstr.DOC_FULL_PART_IND, mstr.DOC_BANK_NBR, mstr.DOC_BANK_BRANCH, mstr.DOC_BANK_ACCT, ");
            strSQL.Append("ytd.COMP_CODE, ytd.AMT_MTD, ytd.AMT_YTD, ");
            //strSQL.Append("comp.COMP_TYPE, comp.DESC_SHORT, ");
            strSQL.Append("dept.DEPT_NBR, dept.DEPT_COMPANY, ");
            strSQL.Append("constmstr.CURRENT_EP_NBR, ");
            strSQL.Append("bank.BANK_CD, bank.BANK_NAME, ");
            strSQL.Append("CONCAT(RIGHT('0'+ RTRIM(mstr.DOC_BANK_NBR),4), RIGHT('0'+ RTRIM(mstr.DOC_BANK_BRANCH),5)) bankcode ");
            //strSQL.Append("CONCAT(ytd.COMP_CODE_GROUP, RIGHT(REPORTING_SEQ, 2), ytd.COMP_CODE) x_key1 ");
            strSQL.Append("FROM [INDEXED].[F119_DOCTOR_YTD] ytd ");
            strSQL.Append("INNER JOIN [INDEXED].[CONSTANTS_MSTR_REC_6] constmstr ON constmstr.CONST_REC_NBR = 6 ");
            strSQL.Append("INNER JOIN [INDEXED].[F112_PYCDCEILINGS] ceil ON ceil.EP_NBR = constmstr.CURRENT_EP_NBR AND ceil.DOC_NBR = ytd.DOC_NBR ");
            //strSQL.Append("LEFT OUTER JOIN [INDEXED].[F190_COMP_CODES] comp ON ytd.COMP_CODE = comp.COMP_CODE ");
            strSQL.Append("LEFT OUTER JOIN [INDEXED].[F020_DOCTOR_MSTR] mstr ON ytd.DOC_NBR = mstr.DOC_NBR ");
            strSQL.Append("LEFT OUTER JOIN [101C].[INDEXED].[F070_DEPT_MSTR] dept ON dept.DEPT_NBR = mstr.DOC_dept ");
            strSQL.Append("LEFT OUTER JOIN [101C].[INDEXED].[F080_BANK_MSTR] bank ON CONCAT(RIGHT('0000' + RTRIM(mstr.DOC_BANK_NBR), 4), RIGHT('00000' + RTRIM(mstr.DOC_BANK_BRANCH), 5)) = bank.BANK_CD ");
            strSQL.Append("WHERE (ytd.COMP_CODE = 'FINCHG' and ytd.REC_TYPE = 'A' and ceil.DOC_PAY_CODE = '7')) AS alldata ");

            rdrDATA.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

            strSQL = null;
        }

        //private void Access_F119_DOCTOR_YTD()
        //{
        //    StringBuilder strSQL = new StringBuilder(string.Empty);

        //    strSQL.Append("SELECT ");
        //    strSQL.Append("DOC_NBR, ");
        //    strSQL.Append("COMP_CODE, ");
        //    strSQL.Append("AMT_MTD ");
        //    strSQL.Append("FROM INDEXED.F119_DOCTOR_YTD ");

        //    strSQL.Append(Choose());

        //    rdrF119_DOCTOR_YTD.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

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

        //    rdrCONSTANTS_MSTR_REC_6.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

        //    strSQL = null;
        //}

        //private void Link_F112_PYCDCEILINGS()
        //{
        //    StringBuilder strSQL = new StringBuilder(string.Empty);

        //    strSQL.Append("SELECT ");
        //    strSQL.Append("EP_NBR, ");
        //    strSQL.Append("DOC_NBR, ");
        //    strSQL.Append("DOC_PAY_CODE ");
        //    strSQL.Append("FROM INDEXED.F112_PYCDCEILINGS ");
        //    strSQL.Append("WHERE ");
        //    strSQL.Append("EP_NBR = ").Append(rdrCONSTANTS_MSTR_REC_6.GetNumber("CURRENT_EP_NBR"));
        //    strSQL.Append(" AND DOC_NBR = ").Append(Common.StringToField(rdrF119_DOCTOR_YTD.GetString("DOC_NBR")));

        //    rdrF112_PYCDCEILINGS.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

        //    strSQL = null;
        //}

        //private void Link_F020_DOCTOR_MSTR()
        //{
        //    StringBuilder strSQL = new StringBuilder(string.Empty);

        //    strSQL.Append("SELECT ");
        //    strSQL.Append("DOC_NBR, ");
        //    strSQL.Append("DOC_DEPT, ");
        //    strSQL.Append("DOC_BANK_NBR, ");
        //    strSQL.Append("DOC_BANK_BRANCH, ");
        //    strSQL.Append("DOC_BANK_ACCT ");
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
        //    strSQL.Append("DEPT_NBR ");
        //    strSQL.Append("FROM INDEXED.F070_DEPT_MSTR ");
        //    strSQL.Append("WHERE ");
        //    strSQL.Append("DEPT_NBR = ").Append(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT"));

        //    rdrF070_DEPT_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

        //    strSQL = null;
        //}

        //private void Link_F080_BANK_MSTR()
        //{
        //    StringBuilder strSQL = new StringBuilder(string.Empty);

        //    strSQL.Append("SELECT ");
        //    strSQL.Append("BANK_CD ");
        //    strSQL.Append("FROM INDEXED.F080_BANK_MSTR ");
        //    strSQL.Append("WHERE ");
        //    strSQL.Append("BANK_CD = ").Append(Common.StringToField((QDesign.ASCII(rdrF020_DOCTOR_MSTR.GetNumber("DOC_BANK_NBR"), 4) + QDesign.ASCII(rdrF020_DOCTOR_MSTR.GetNumber("DOC_BANK_BRANCH"), 5))));

        //    rdrF080_BANK_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

        //    strSQL = null;
        //}

        #endregion

        #region " CHOOSE "

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(string.Empty);

            strChoose.Append(ReportDataFunctions.GetWhereCondition("COMP_CODE", "FINCHG", true));

            return strChoose.ToString();
        }

        #endregion

        #region " SELECT IF "

        //public override bool SelectIf()
        //{
        //    bool blnSelected = false;

        //    if (QDesign.NULL(rdrF112_PYCDCEILINGS.GetString("DOC_PAY_CODE")) == QDesign.NULL("7"))
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
                AddControl(ReportSection.PAGE_HEADING, "INDEXED.CONSTANTS_MSTR_REC_6.CURRENT_EP_NBR", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "INDEXED.F119_DOCTOR_YTD.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "INDEXED.F119_DOCTOR_YTD.AMT_MTD", DataTypes.Numeric, 9);
                AddControl(ReportSection.REPORT, "INDEXED.F020_DOCTOR_MSTR.DOC_BANK_NBR", DataTypes.Numeric, 4);
                AddControl(ReportSection.REPORT, "INDEXED.F020_DOCTOR_MSTR.DOC_BANK_BRANCH", DataTypes.Numeric, 5);
                AddControl(ReportSection.REPORT, "INDEXED.F020_DOCTOR_MSTR.DOC_BANK_ACCT", DataTypes.Character, 12);
                AddControl(ReportSection.FINAL_FOOTING, "INDEXED.F119_DOCTOR_YTD.AMT_MTD", DataTypes.Numeric, 9);
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
        //# Do not delete, modify or move it.  Updated: 2017-07-24 10:17:19 PM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "INDEXED.CONSTANTS_MSTR_REC_6.CURRENT_EP_NBR":
                    return rdrDATA.GetNumber("CURRENT_EP_NBR").ToString();

                case "INDEXED.F119_DOCTOR_YTD.DOC_NBR":
                    return Common.StringToField(rdrDATA.GetString("DOC_NBR"));

                case "INDEXED.F119_DOCTOR_YTD.AMT_MTD":
                    return rdrDATA.GetNumber("AMT_MTD").ToString();

                case "INDEXED.F020_DOCTOR_MSTR.DOC_BANK_NBR":
                    return rdrDATA.GetNumber("DOC_BANK_NBR").ToString();

                case "INDEXED.F020_DOCTOR_MSTR.DOC_BANK_BRANCH":
                    return rdrDATA.GetNumber("DOC_BANK_BRANCH").ToString();

                case "INDEXED.F020_DOCTOR_MSTR.DOC_BANK_ACCT":
                    return Common.StringToField(rdrDATA.GetString("DOC_BANK_ACCT"));

                default:
                    return string.Empty;
            }
        }

        //public override string ReturnControlValue(string strControl, int intSize)
        //{
        //    switch (strControl)
        //    {
        //        case "INDEXED.CONSTANTS_MSTR_REC_6.CURRENT_EP_NBR":
        //            return rdrCONSTANTS_MSTR_REC_6.GetNumber("CURRENT_EP_NBR").ToString();

        //        case "INDEXED.F119_DOCTOR_YTD.DOC_NBR":
        //            return Common.StringToField(rdrF119_DOCTOR_YTD.GetString("DOC_NBR"));

        //        case "INDEXED.F119_DOCTOR_YTD.AMT_MTD":
        //            return rdrF119_DOCTOR_YTD.GetNumber("AMT_MTD").ToString();

        //        case "INDEXED.F020_DOCTOR_MSTR.DOC_BANK_NBR":
        //            return rdrF020_DOCTOR_MSTR.GetNumber("DOC_BANK_NBR").ToString();

        //        case "INDEXED.F020_DOCTOR_MSTR.DOC_BANK_BRANCH":
        //            return rdrF020_DOCTOR_MSTR.GetNumber("DOC_BANK_BRANCH").ToString();

        //        case "INDEXED.F020_DOCTOR_MSTR.DOC_BANK_ACCT":
        //            return Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_BANK_ACCT"));

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
        //            Link_CONSTANTS_MSTR_REC_6();
        //            while (rdrCONSTANTS_MSTR_REC_6.Read())
        //            {
        //                Link_F112_PYCDCEILINGS();
        //                Link_F020_DOCTOR_MSTR();
        //                Link_F070_DEPT_MSTR();
        //                Link_F080_BANK_MSTR();
        //                while ((rdrF080_BANK_MSTR.Read()))
        //                {
        //                    WriteData();
        //                }
        //                rdrF080_BANK_MSTR.Close();
        //                rdrF070_DEPT_MSTR.Close();
        //                rdrF020_DOCTOR_MSTR.Close();
        //                rdrF112_PYCDCEILINGS.Close();
        //            }
        //            rdrCONSTANTS_MSTR_REC_6.Close();
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
            //if ((rdrCONSTANTS_MSTR_REC_6 != null))
            //{
            //    rdrCONSTANTS_MSTR_REC_6.Close();
            //    rdrCONSTANTS_MSTR_REC_6 = null;
            //}
            //if ((rdrF112_PYCDCEILINGS != null))
            //{
            //    rdrF112_PYCDCEILINGS.Close();
            //    rdrF112_PYCDCEILINGS = null;
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
            //if ((rdrF080_BANK_MSTR != null))
            //{
            //    rdrF080_BANK_MSTR.Close();
            //    rdrF080_BANK_MSTR = null;
            //}
        }


        #endregion

        #endregion
    }
}
