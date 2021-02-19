#region "Screen Comments"

// DOC: R119C.QZS
// DOC; REPORT MTD AND YTD FIGURES GRAND TOTALS
// DATE      WHO       MODIFICATION
// 93/06/23  YASEMIN   ORIGINAL
// 94/10/03  YASEMIN   CHANGE SORT SEQUENCE OF COMP DESCRIPTION
// 95/01/09  YASEMIN   CHANGE SORT SEQUENCE OF COMP DESCRIPTION
// 98/01/29  J. CHAU   COMMENT OUT SET NOCLOSE
// 14/may/14 MC1       link to f112 to not select pay code 7
// jc set noclose
// LINK DOC-NBR TO DOC-NBR OF F110-COMPENSATION         OPT      &
// MC1

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
    public class MP_R119C : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R119C";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrF020_DOCTOR_MSTR = new Reader();
        private Reader rdrF119_DOCTOR_YTD = new Reader();
        private Reader rdrF190_COMP_CODES = new Reader();
        private Reader rdrF070_DEPT_MSTR = new Reader();
        private Reader rdrCONSTANTS_MSTR_REC_6 = new Reader();
        private Reader rdrF112_PYCDCEILINGS = new Reader();

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

        private void Access_F020_DOCTOR_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("DOC_DEPT, ");
            strSQL.Append("DOC_INIT1, ");
            strSQL.Append(" DOC_INIT2, ");
            strSQL.Append(" DOC_INIT3, ");
            strSQL.Append("DOC_NAME, ");
            strSQL.Append("DOC_FULL_PART_IND ");
            strSQL.Append("FROM INDEXED.F020_DOCTOR_MSTR ");

            strSQL.Append(Choose());

            rdrF020_DOCTOR_MSTR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

            strSQL = null;
        }

        private void Link_F119_DOCTOR_YTD()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("COMP_CODE, ");
            strSQL.Append("COMP_CODE_GROUP, ");
            strSQL.Append("AMT_MTD, ");
            strSQL.Append("AMT_YTD ");
            strSQL.Append("FROM INDEXED.F119_DOCTOR_YTD ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_NBR = ").Append(Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_NBR")));

            rdrF119_DOCTOR_YTD.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

            strSQL = null;
        }

        private void Link_F190_COMP_CODES()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("REPORTING_SEQ, ");
            strSQL.Append("COMP_TYPE, ");
            strSQL.Append("DESC_SHORT ");
            strSQL.Append("FROM [101C].INDEXED.F190_COMP_CODES ");
            strSQL.Append("WHERE ");
            strSQL.Append("COMP_CODE = ").Append(Common.StringToField(rdrF119_DOCTOR_YTD.GetString("COMP_CODE")));

            rdrF190_COMP_CODES.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

            strSQL = null;
        }

        private void Link_F070_DEPT_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DEPT_NBR ");
            strSQL.Append("FROM [101C].INDEXED.F070_DEPT_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DEPT_NBR = ").Append(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT"));

            rdrF070_DEPT_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

            strSQL = null;
        }

        private void Link_CONSTANTS_MSTR_REC_6()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("CONST_REC_NBR, ");
            strSQL.Append("CURRENT_EP_NBR ");
            strSQL.Append("FROM INDEXED.CONSTANTS_MSTR_REC_6 ");
            strSQL.Append("WHERE ");
            strSQL.Append("CONST_REC_NBR = ").Append(6);

            rdrCONSTANTS_MSTR_REC_6.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

            strSQL = null;
        }

        private void Link_F112_PYCDCEILINGS()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("EP_NBR, ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("DOC_PAY_CODE ");
            strSQL.Append("FROM INDEXED.F112_PYCDCEILINGS ");
            strSQL.Append("WHERE ");
            strSQL.Append("EP_NBR = ").Append(rdrCONSTANTS_MSTR_REC_6.GetNumber("CURRENT_EP_NBR"));
            strSQL.Append(" AND DOC_NBR = ").Append(Common.StringToField(rdrF119_DOCTOR_YTD.GetString("DOC_NBR")));

            rdrF112_PYCDCEILINGS.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

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

            if (QDesign.NULL(rdrF112_PYCDCEILINGS.GetString("DOC_PAY_CODE")) != QDesign.NULL("7"))
            {
                blnSelected = true;
            }

            return blnSelected;
        }

        #endregion

        #region " DEFINES "

        private string X_KEY2()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = rdrF119_DOCTOR_YTD.GetString("COMP_CODE_GROUP") + QDesign.ASCII(rdrF190_COMP_CODES.GetNumber("REPORTING_SEQ"), 2) + rdrF119_DOCTOR_YTD.GetString("COMP_CODE");
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string W_DOC_NAME()
        {
            string strReturnValue = string.Empty;

            try
            {
                if (ReportDataFunctions.Exists(rdrF020_DOCTOR_MSTR))
                {
                    strReturnValue = "DR. " + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT1") + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT2") + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT3") + " " + rdrF020_DOCTOR_MSTR.GetString("DOC_NAME");
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
                if (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == QDesign.NULL("F"))
                {
                    strReturnValue = "FULL TIME";
                }
                else if (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == QDesign.NULL("P"))
                {
                    strReturnValue = "PART TIME";
                }
                else if (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == QDesign.NULL("C"))
                {
                    strReturnValue = "CLINICAL SCHOLARS";
                }
                else if (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == QDesign.NULL("S"))
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
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F119_DOCTOR_YTD.AMT_YTD", DataTypes.Numeric, 15);
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
        //# Do not delete, modify or move it.  Updated: 10/26/2017 2:22:35 PM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "INDEXED.CONSTANTS_MSTR_REC_6.CURRENT_EP_NBR":
                    return rdrCONSTANTS_MSTR_REC_6.GetNumber("CURRENT_EP_NBR").ToString().PadLeft(6, ' ');

                case "INDEXED.F190_COMP_CODES.COMP_TYPE":
                    return Common.StringToField(rdrF190_COMP_CODES.GetString("COMP_TYPE").PadRight(1, ' '));

                case "INDEXED.F119_DOCTOR_YTD.COMP_CODE":
                    return Common.StringToField(rdrF119_DOCTOR_YTD.GetString("COMP_CODE").PadRight(6, ' '));

                case "INDEXED.F190_COMP_CODES.DESC_SHORT":
                    return Common.StringToField(rdrF190_COMP_CODES.GetString("DESC_SHORT").PadRight(15, ' '));

                case "INDEXED.F119_DOCTOR_YTD.AMT_MTD":
                    return rdrF119_DOCTOR_YTD.GetNumber("AMT_MTD").ToString().PadLeft(9, ' ');

                case "INDEXED.F119_DOCTOR_YTD.AMT_YTD":
                    return rdrF119_DOCTOR_YTD.GetNumber("AMT_YTD").ToString().PadLeft(15, ' ');

                case "X_KEY2":
                    return Common.StringToField(X_KEY2().PadRight(0, ' '));

                default:

                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_F020_DOCTOR_MSTR();

                while (rdrF020_DOCTOR_MSTR.Read())
                {
                    Link_F119_DOCTOR_YTD();
                    while (rdrF119_DOCTOR_YTD.Read())
                    {
                        Link_F190_COMP_CODES();
                        while (rdrF190_COMP_CODES.Read())
                        {
                            Link_F070_DEPT_MSTR();
                            while (rdrF070_DEPT_MSTR.Read())
                            {
                                Link_CONSTANTS_MSTR_REC_6();
                                while (rdrCONSTANTS_MSTR_REC_6.Read())
                                {
                                    Link_F112_PYCDCEILINGS();
                                    while (rdrF112_PYCDCEILINGS.Read())
                                    {
                                        WriteData();
                                    }
                                    rdrF112_PYCDCEILINGS.Close();
                                }
                                rdrCONSTANTS_MSTR_REC_6.Close();
                            }
                            rdrF070_DEPT_MSTR.Close();
                        }
                        rdrF190_COMP_CODES.Close();
                    }
                    rdrF119_DOCTOR_YTD.Close();
                }
                rdrF020_DOCTOR_MSTR.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrF020_DOCTOR_MSTR != null))
            {
                rdrF020_DOCTOR_MSTR.Close();
                rdrF020_DOCTOR_MSTR = null;
            }
            if ((rdrF119_DOCTOR_YTD != null))
            {
                rdrF119_DOCTOR_YTD.Close();
                rdrF119_DOCTOR_YTD = null;
            }
            if ((rdrF190_COMP_CODES != null))
            {
                rdrF190_COMP_CODES.Close();
                rdrF190_COMP_CODES = null;
            }
            if ((rdrF070_DEPT_MSTR != null))
            {
                rdrF070_DEPT_MSTR.Close();
                rdrF070_DEPT_MSTR = null;
            }
            if ((rdrCONSTANTS_MSTR_REC_6 != null))
            {
                rdrCONSTANTS_MSTR_REC_6.Close();
                rdrCONSTANTS_MSTR_REC_6 = null;
            }
            if ((rdrF112_PYCDCEILINGS != null))
            {
                rdrF112_PYCDCEILINGS.Close();
                rdrF112_PYCDCEILINGS = null;
            }
        }


        #endregion

        #endregion
    }
}
