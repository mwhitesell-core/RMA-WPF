#region "Screen Comments"

// 2016/Mar/22  MC1  - correct program by adding choose statement

#endregion

using Core.DataAccess.TextFile;
using Core.DataAccess.SqlServer;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.ReportFramework;
using System;
using System.Data;
using System.Text;

namespace RMA_DATA
{
    public class PAYCODE1A_CEILINGS : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "PAYCODE1A_CEILINGS";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrCONSTANTS_MSTR_REC_6 = new Reader();
        private Reader rdrF112_PYCDCEILINGS = new Reader();
        private Reader rdrF020_DOCTOR_MSTR = new Reader();
        private Reader rdrF070_DEPT_MSTR = new Reader();

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

        private void Link_F112_PYCDCEILINGS()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("EP_NBR, ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("DOC_PAY_CODE, ");
            strSQL.Append("DOC_PAY_SUB_CODE, ");
            strSQL.Append("DOC_YRLY_CEILING ");
            strSQL.Append("FROM INDEXED.F112_PYCDCEILINGS ");
            strSQL.Append("WHERE ");
            strSQL.Append("EP_NBR = ").Append(rdrCONSTANTS_MSTR_REC_6.GetNumber("CURRENT_EP_NBR"));

            rdrF112_PYCDCEILINGS.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

            strSQL = null;
        }

        private void Link_F020_DOCTOR_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("DOC_DEPT, ");
            strSQL.Append("DOC_NAME, ");
            strSQL.Append("DOC_INIT1, ");
            strSQL.Append(" DOC_INIT2, ");
            strSQL.Append(" DOC_INIT3 ");
            strSQL.Append("FROM INDEXED.F020_DOCTOR_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_NBR = ").Append(Common.StringToField(rdrF112_PYCDCEILINGS.GetString("DOC_NBR")));

            rdrF020_DOCTOR_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

            strSQL = null;
        }

        private void Link_F070_DEPT_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DEPT_NBR, ");
            strSQL.Append("DEPT_COMPANY ");
            strSQL.Append("FROM [101C].INDEXED.F070_DEPT_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DEPT_NBR = ").Append(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT"));

            rdrF070_DEPT_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

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

            if (QDesign.NULL(rdrF112_PYCDCEILINGS.GetString("DOC_PAY_CODE")) == "1" & QDesign.NULL(rdrF112_PYCDCEILINGS.GetString("DOC_PAY_SUB_CODE")) == "A")
                blnSelected = true;

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
                AddControl(ReportSection.REPORT, "INDEXED.F112_PYCDCEILINGS.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "INDEXED.F070_DEPT_MSTR.DEPT_COMPANY", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "INDEXED.F020_DOCTOR_MSTR.DOC_NAME", DataTypes.Character, 24);
                AddControl(ReportSection.REPORT, "DOC_INITS", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "INDEXED.F112_PYCDCEILINGS.EP_NBR", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "INDEXED.F112_PYCDCEILINGS.DOC_YRLY_CEILING", DataTypes.Numeric, 7);
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
        //# Do not delete, modify or move it.  Updated: 6/29/2017 2:16:51 PM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "INDEXED.F112_PYCDCEILINGS.DOC_NBR":
                    return Common.StringToField(rdrF112_PYCDCEILINGS.GetString("DOC_NBR").PadRight(3, ' '));

                case "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT":
                    return rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT").ToString().PadLeft(2, ' ');

                case "INDEXED.F070_DEPT_MSTR.DEPT_COMPANY":
                    return rdrF070_DEPT_MSTR.GetNumber("DEPT_COMPANY").ToString().PadLeft(2, ' ');

                case "INDEXED.F020_DOCTOR_MSTR.DOC_NAME":
                    return Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_NAME").PadRight(24, ' '));

                case "DOC_INITS":
                    return Common.StringToField(F020_DOCTOR_MSTR_DOC_INITS(), intSize);

                case "INDEXED.F112_PYCDCEILINGS.EP_NBR":
                    return rdrF112_PYCDCEILINGS.GetNumber("EP_NBR").ToString().PadLeft(6, ' ');

                case "INDEXED.F112_PYCDCEILINGS.DOC_YRLY_CEILING":
                    return rdrF112_PYCDCEILINGS.GetNumber("DOC_YRLY_CEILING").ToString().PadLeft(7, ' ');

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
                    Link_F112_PYCDCEILINGS();
                    while (rdrF112_PYCDCEILINGS.Read())
                    {
                        Link_F020_DOCTOR_MSTR();
                        rdrF020_DOCTOR_MSTR.Read();
                        Link_F070_DEPT_MSTR();
                        rdrF070_DEPT_MSTR.Read();


                        WriteData();

                        rdrF070_DEPT_MSTR.Close();
                        rdrF020_DOCTOR_MSTR.Close();
                    }
                    rdrF112_PYCDCEILINGS.Close();
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

            if ((rdrF070_DEPT_MSTR != null))
            {
                rdrF070_DEPT_MSTR.Close();
                rdrF070_DEPT_MSTR = null;
            }
        }

        #endregion

        #endregion
    }
}
