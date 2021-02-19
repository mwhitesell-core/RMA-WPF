#region "Screen Comments"

// MC9 - new request to check if f020 record exists for f112 file

#endregion

using Core.DataAccess.TextFile;
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
    public class U100_F : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "U100_F";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
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

        private void Access_F112_PYCDCEILINGS()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("EP_NBR, ");
            strSQL.Append("DOC_PAY_CODE ");
            strSQL.Append("FROM INDEXED.F112_PYCDCEILINGS ");

            strSQL.Append(Choose());

            rdrF112_PYCDCEILINGS.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

            strSQL = null;
        }

        private void Link_F020_DOCTOR_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR ");
            strSQL.Append("FROM INDEXED.F020_DOCTOR_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_NBR = ").Append(Common.StringToField(rdrF112_PYCDCEILINGS.GetString("DOC_NBR")));

            rdrF020_DOCTOR_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

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

            if (!ReportDataFunctions.Exists(rdrF020_DOCTOR_MSTR))
                blnSelected = true;


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
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F112_PYCDCEILINGS.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F112_PYCDCEILINGS.EP_NBR", DataTypes.Numeric, 6);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F112_PYCDCEILINGS.DOC_PAY_CODE", DataTypes.Character, 1);
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
        //# Do not delete, modify or move it.  Updated: 6/29/2017 8:40:32 AM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "INDEXED.F112_PYCDCEILINGS.DOC_NBR":
                    return Common.StringToField(rdrF112_PYCDCEILINGS.GetString("DOC_NBR").PadRight(3, ' '));

                case "INDEXED.F112_PYCDCEILINGS.EP_NBR":
                    return rdrF112_PYCDCEILINGS.GetNumber("EP_NBR").ToString().PadLeft(6, ' ');

                case "INDEXED.F112_PYCDCEILINGS.DOC_PAY_CODE":
                    return Common.StringToField(rdrF112_PYCDCEILINGS.GetString("DOC_PAY_CODE").PadRight(1, ' '));

                default:
                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_F112_PYCDCEILINGS();

                while (rdrF112_PYCDCEILINGS.Read())
                {
                    Link_F020_DOCTOR_MSTR();
                    while (rdrF020_DOCTOR_MSTR.Read())
                    {
                        WriteData();
                    }
                    rdrF020_DOCTOR_MSTR.Close();
                }
                rdrF112_PYCDCEILINGS.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
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
