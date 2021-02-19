#region "Screen Comments"

// program: R125.QZS
// purpose: VERIFY SCREEN 93 HAS REVENUE BUT NOT PAY CODE IN SCREEN 91
// DATE       BY WHOM      DESCRIPTION
// 95/01/16   yasemin      - original
// 99/Feb/18  S.B.         - Checked for Y2K.
// 00/jul/12  B.E.  - added  missing  flags to determine which selection
// criteria selected the record for printing
// 03/nov/20 M.C.   - alpha doc nbr

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
    public class R125 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R125";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrCONSTANTS_MSTR_REC_6 = new Reader();
        private Reader rdrF110_COMPENSATION = new Reader();
        private Reader rdrF112_PYCDCEILINGS = new Reader();
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

                Sort = "DOC_DEPT ASC, DOC_NBR ASC";

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

        private void Access_CONSTANTS_MSTR_REC_6()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("CURRENT_EP_NBR, ");
            strSQL.Append("CONST_REC_NBR ");
            strSQL.Append("FROM INDEXED.CONSTANTS_MSTR_REC_6 ");

            strSQL.Append(Choose());

            rdrCONSTANTS_MSTR_REC_6.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

            strSQL = null;
        }

        private void Link_F110_COMPENSATION()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("EP_NBR, ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("COMP_CODE ");
            strSQL.Append("FROM INDEXED.F110_COMPENSATION ");
            strSQL.Append("WHERE ");
            strSQL.Append("EP_NBR = ").Append(rdrCONSTANTS_MSTR_REC_6.GetNumber("CURRENT_EP_NBR"));

            rdrF110_COMPENSATION.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

            strSQL = null;
        }

        private void Link_F112_PYCDCEILINGS()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("EP_NBR, ");
            strSQL.Append("DOC_PAY_CODE ");
            strSQL.Append("FROM INDEXED.F112_PYCDCEILINGS ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_NBR = ").Append(Common.StringToField(rdrF110_COMPENSATION.GetString("DOC_NBR")));
            strSQL.Append(" AND EP_NBR = ").Append(rdrCONSTANTS_MSTR_REC_6.GetNumber("CURRENT_EP_NBR"));

            rdrF112_PYCDCEILINGS.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

            strSQL = null;
        }

        private void Link_F020_DOCTOR_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("DOC_DEPT ");
            strSQL.Append("FROM INDEXED.F020_DOCTOR_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_NBR = ").Append(Common.StringToField(rdrF110_COMPENSATION.GetString("DOC_NBR")));

            rdrF020_DOCTOR_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

            strSQL = null;
        }

        #endregion

        #region " CHOOSE "

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(string.Empty);

            strChoose.Append(ReportDataFunctions.GetWhereCondition("CONST_REC_NBR", "6", true));

            return strChoose.ToString();
        }

        #endregion

        #region " SELECT IF "

        public override bool SelectIf()
        {
            bool blnSelected = false;

            if (QDesign.NULL(rdrF112_PYCDCEILINGS.GetString("DOC_PAY_CODE")) == " " | !ReportDataFunctions.Exists(rdrF112_PYCDCEILINGS) | !ReportDataFunctions.Exists(rdrF020_DOCTOR_MSTR))
                blnSelected = true;

            return blnSelected;
        }

        #endregion

        #region " DEFINES "

        private string FLAG_MISSING_PAY_CODE()
        {
            string strReturnValue = string.Empty;

            try
            {
                if (QDesign.NULL(rdrF112_PYCDCEILINGS.GetString("DOC_PAY_CODE")) == " ")
                {
                    strReturnValue = "Y";
                }
                else
                {
                    strReturnValue = rdrF112_PYCDCEILINGS.GetString("DOC_PAY_CODE");
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string FLAG_MISSING_F112()
        {
            string strReturnValue = string.Empty;

            try
            {
                if (!ReportDataFunctions.Exists(rdrF112_PYCDCEILINGS))
                {
                    strReturnValue = "Y";
                }
                else
                {
                    strReturnValue = " ";
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string FLAG_MISSING_F020()
        {
            string strReturnValue = string.Empty;

            try
            {
                if (!ReportDataFunctions.Exists(rdrF020_DOCTOR_MSTR))
                {
                    strReturnValue = "Y";
                }
                else
                {
                    strReturnValue = " ";
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
                AddControl(ReportSection.PAGE_HEADING, "INDEXED.F110_COMPENSATION.EP_NBR", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "INDEXED.F110_COMPENSATION.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "INDEXED.F112_PYCDCEILINGS.DOC_PAY_CODE", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "INDEXED.F110_COMPENSATION.COMP_CODE", DataTypes.Character, 6);
                AddControl(ReportSection.REPORT, "FLAG_MISSING_PAY_CODE", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "FLAG_MISSING_F112", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "FLAG_MISSING_F020", DataTypes.Character, 1);
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
        //# Do not delete, modify or move it.  Updated: 6/29/2017 2:23:24 PM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "INDEXED.F110_COMPENSATION.EP_NBR":
                    return rdrF110_COMPENSATION.GetNumber("EP_NBR").ToString().PadLeft(6, ' ');

                case "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT":
                    return rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT").ToString().PadLeft(2, ' ');

                case "INDEXED.F110_COMPENSATION.DOC_NBR":
                    return Common.StringToField(rdrF110_COMPENSATION.GetString("DOC_NBR").PadRight(3, ' '));

                case "INDEXED.F112_PYCDCEILINGS.DOC_PAY_CODE":
                    return Common.StringToField(rdrF112_PYCDCEILINGS.GetString("DOC_PAY_CODE").PadRight(1, ' '));

                case "INDEXED.F110_COMPENSATION.COMP_CODE":
                    return Common.StringToField(rdrF110_COMPENSATION.GetString("COMP_CODE").PadRight(6, ' '));

                case "FLAG_MISSING_PAY_CODE":
                    return Common.StringToField(FLAG_MISSING_PAY_CODE(), intSize);

                case "FLAG_MISSING_F112":
                    return Common.StringToField(FLAG_MISSING_F112(), intSize);

                case "FLAG_MISSING_F020":
                    return Common.StringToField(FLAG_MISSING_F020(), intSize);

                default:
                    return string.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                Access_CONSTANTS_MSTR_REC_6();

                while (rdrCONSTANTS_MSTR_REC_6.Read())
                {
                    Link_F110_COMPENSATION();
                    while (rdrF110_COMPENSATION.Read())
                    {
                        Link_F112_PYCDCEILINGS();
                        while ((rdrF112_PYCDCEILINGS.Read()))
                        {

                            Link_F020_DOCTOR_MSTR();
                            while ((rdrF020_DOCTOR_MSTR.Read()))
                            {
                                WriteData();
                            }
                            rdrF020_DOCTOR_MSTR.Close();
                        }                     
                        rdrF112_PYCDCEILINGS.Close();
                    }
                    rdrF110_COMPENSATION.Close();
                }
                rdrCONSTANTS_MSTR_REC_6.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrCONSTANTS_MSTR_REC_6 != null))
            {
                rdrCONSTANTS_MSTR_REC_6.Close();
                rdrCONSTANTS_MSTR_REC_6 = null;
            }

            if ((rdrF110_COMPENSATION != null))
            {
                rdrF110_COMPENSATION.Close();
                rdrF110_COMPENSATION = null;
            }

            if ((rdrF112_PYCDCEILINGS != null))
            {
                rdrF112_PYCDCEILINGS.Close();
                rdrF112_PYCDCEILINGS = null;
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
