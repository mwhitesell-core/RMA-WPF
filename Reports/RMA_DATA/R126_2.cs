#region "Screen Comments"

// MC1 - new request to check if f112 record exists for previous ep-nbr in f114 file

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
    public class R126_2 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R126_2";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrF114_SPECIAL_PAYMENTS = new Reader();
        private Reader rdrF020_DOCTOR_MSTR = new Reader();
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

                Sort = "DOC_NBR ASC";

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

        private void Access_F114_SPECIAL_PAYMENTS()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("EP_NBR_FROM, ");
            strSQL.Append("COMP_CODE, ");
            strSQL.Append("AMT_GROSS, ");
            strSQL.Append("AMT_NET ");
            strSQL.Append("FROM INDEXED.F114_SPECIAL_PAYMENTS ");

            strSQL.Append(Choose());

            rdrF114_SPECIAL_PAYMENTS.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

            strSQL = null;
        }

        private void Link_F020_DOCTOR_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("DOC_DEPT, ");
            strSQL.Append("DOC_DATE_FAC_TERM_YY, ");
            strSQL.Append(" DOC_DATE_FAC_TERM_MM, ");
            strSQL.Append(" DOC_DATE_FAC_TERM_DD ");
            strSQL.Append("FROM INDEXED.F020_DOCTOR_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_NBR = ").Append(Common.StringToField(rdrF114_SPECIAL_PAYMENTS.GetString("DOC_NBR")));

            rdrF020_DOCTOR_MSTR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

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
            strSQL.Append("DOC_NBR = ").Append(Common.StringToField(rdrF114_SPECIAL_PAYMENTS.GetString("DOC_NBR")));
            strSQL.Append(" AND EP_NBR = ").Append(rdrF114_SPECIAL_PAYMENTS.GetNumber("EP_NBR_FROM") - 1);

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

            if (QDesign.NULL(rdrF112_PYCDCEILINGS.GetString("DOC_PAY_CODE")) == QDesign.NULL("0"))
            {
                blnSelected = true;
            }

            return blnSelected;
        }

        #endregion

        #region " DEFINES "

        private System.DateTime DOC_DATE_FAC_TERM()
        {
            System.DateTime dteReturnValue = Common.cZeroDate;

            try
            {
                dteReturnValue = QDesign.GetDateFromYYYYMMDDDecimal(Convert.ToString(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DATE_FAC_TERM_YY")) + Convert.ToString(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DATE_FAC_TERM_MM")) + Convert.ToString(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DATE_FAC_TERM_DD")));
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
            return dteReturnValue;
        }

        #endregion

        #region " CONTROLS "

        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F114_SPECIAL_PAYMENTS.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F114_SPECIAL_PAYMENTS.COMP_CODE", DataTypes.Character, 6);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F114_SPECIAL_PAYMENTS.EP_NBR_FROM", DataTypes.Numeric, 6);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F114_SPECIAL_PAYMENTS.AMT_GROSS", DataTypes.Numeric, 9);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F114_SPECIAL_PAYMENTS.AMT_NET", DataTypes.Numeric, 9);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F112_PYCDCEILINGS.DOC_PAY_CODE", DataTypes.Character, 1);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT", DataTypes.Numeric, 2);
                AddControl(ReportSection.FOOTING_AT, "DOC_DATE_FAC_TERM", DataTypes.Date);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F112_PYCDCEILINGS.EP_NBR", DataTypes.Numeric, 6);
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
        //# Do not delete, modify or move it.  Updated: 10/27/2017 10:57:15 AM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "INDEXED.F114_SPECIAL_PAYMENTS.DOC_NBR":
                    return Common.StringToField(rdrF114_SPECIAL_PAYMENTS.GetString("DOC_NBR").PadRight(3, ' '));

                case "INDEXED.F114_SPECIAL_PAYMENTS.COMP_CODE":
                    return Common.StringToField(rdrF114_SPECIAL_PAYMENTS.GetString("COMP_CODE").PadRight(6, ' '));

                case "INDEXED.F114_SPECIAL_PAYMENTS.EP_NBR_FROM":
                    return rdrF114_SPECIAL_PAYMENTS.GetNumber("EP_NBR_FROM").ToString().PadLeft(6, ' ');

                case "INDEXED.F114_SPECIAL_PAYMENTS.AMT_GROSS":
                    return rdrF114_SPECIAL_PAYMENTS.GetNumber("AMT_GROSS").ToString().PadLeft(9, ' ');

                case "INDEXED.F114_SPECIAL_PAYMENTS.AMT_NET":
                    return rdrF114_SPECIAL_PAYMENTS.GetNumber("AMT_NET").ToString().PadLeft(9, ' ');

                case "INDEXED.F112_PYCDCEILINGS.DOC_PAY_CODE":
                    return Common.StringToField(rdrF112_PYCDCEILINGS.GetString("DOC_PAY_CODE").PadRight(1, ' '));

                case "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT":
                    return rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT").ToString().PadLeft(2, ' ');

                case "DOC_DATE_FAC_TERM":
                    return DOC_DATE_FAC_TERM().ToString().PadLeft(8, ' ');

                case "INDEXED.F112_PYCDCEILINGS.EP_NBR":
                    return rdrF112_PYCDCEILINGS.GetNumber("EP_NBR").ToString().PadLeft(6, ' ');

                default:

                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_F114_SPECIAL_PAYMENTS();

                while (rdrF114_SPECIAL_PAYMENTS.Read())
                {
                    Link_F020_DOCTOR_MSTR();
                    while (rdrF020_DOCTOR_MSTR.Read())
                    {
                        Link_F112_PYCDCEILINGS();
                        while ((rdrF112_PYCDCEILINGS.Read()))
                        {
                            WriteData();
                        }
                        rdrF112_PYCDCEILINGS.Close();
                    }
                    rdrF020_DOCTOR_MSTR.Close();
                }
                rdrF114_SPECIAL_PAYMENTS.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrF114_SPECIAL_PAYMENTS != null))
            {
                rdrF114_SPECIAL_PAYMENTS.Close();
                rdrF114_SPECIAL_PAYMENTS = null;
            }
            if ((rdrF020_DOCTOR_MSTR != null))
            {
                rdrF020_DOCTOR_MSTR.Close();
                rdrF020_DOCTOR_MSTR = null;
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
