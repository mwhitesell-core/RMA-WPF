#region "Screen Comments"

// program: R126.QZS
// #> PROGRAM-ID.     R126.QZS
// ((C)) Dyad Technologies
// PURPOSE: VERIFY special payment in f114 has pay code `0` or ` ` IN SCREEN 91
// if record in f114 and record exist in f112 with current ep-nbr and pay code in f112 = `0` or `blank`, then report
// MODIFICATION HISTORY
// DATE    WHO      DESCRIPTION
// 2013/Sep/26  MC       - original
// 2013/Oct/03  MC   - add second criteria - if no record found in f112, report
// 2014/Apr/23  MC1      - separate f114 check into 2 separate passes - one is if no f112 record exists for the doctor,
// two is if f112 records exists for previous ep-nbr but with pay code 0
// 2015/Jan/15  MC2      - include columns comp-code and amt-net in the report  in first pass
// 2016/Jul/19  MC3   - add a new request to access f110 file to see if record found if f112 
// MC1
// MC1 - end

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
    public class R126_1 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R126_1";
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
            strSQL.Append("COMP_CODE, ");
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
            strSQL.Append("DOC_NAME ");
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
            strSQL.Append("DOC_NBR ");
            strSQL.Append("FROM INDEXED.F112_PYCDCEILINGS ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_NBR = ").Append(Common.StringToField(rdrF114_SPECIAL_PAYMENTS.GetString("DOC_NBR")));

            rdrF112_PYCDCEILINGS.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

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

            if (!ReportDataFunctions.Exists(rdrF112_PYCDCEILINGS))
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
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F114_SPECIAL_PAYMENTS.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F020_DOCTOR_MSTR.DOC_NAME", DataTypes.Character, 24);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F114_SPECIAL_PAYMENTS.COMP_CODE", DataTypes.Character, 6);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F114_SPECIAL_PAYMENTS.AMT_NET", DataTypes.Numeric, 9);
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
        //# Do not delete, modify or move it.  Updated: 10/27/2017 10:29:24 AM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "INDEXED.F114_SPECIAL_PAYMENTS.DOC_NBR":
                    return Common.StringToField(rdrF114_SPECIAL_PAYMENTS.GetString("DOC_NBR").PadRight(3, ' '));

                case "INDEXED.F020_DOCTOR_MSTR.DOC_NAME":
                    return Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_NAME").PadRight(24, ' '));

                case "INDEXED.F114_SPECIAL_PAYMENTS.COMP_CODE":
                    return Common.StringToField(rdrF114_SPECIAL_PAYMENTS.GetString("COMP_CODE").PadRight(6, ' '));

                case "INDEXED.F114_SPECIAL_PAYMENTS.AMT_NET":
                    return rdrF114_SPECIAL_PAYMENTS.GetNumber("AMT_NET").ToString().PadLeft(9, ' ');

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
