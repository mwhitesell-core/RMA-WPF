#region "Screen Comments"

// MC3 - new request to check if f112 record exists for records found in f110 file   

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
    public class R126_3 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R126_3";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrCONSTANTS_MSTR_REC_6 = new Reader();
        private Reader rdrF110_COMPENSATION = new Reader();
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

                Sort = "DOC_NBR ASC, COMP_CODE ASC";

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
            strSQL.Append("COMP_CODE, ");
            strSQL.Append("AMT_GROSS, ");
            strSQL.Append("AMT_NET ");
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
            strSQL.Append("DOC_NBR ");
            strSQL.Append("FROM INDEXED.F112_PYCDCEILINGS ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_NBR = ").Append(Common.StringToField(rdrF110_COMPENSATION.GetString("DOC_NBR")));

            rdrF112_PYCDCEILINGS.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

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
                AddControl(ReportSection.REPORT, "INDEXED.F110_COMPENSATION.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "INDEXED.F110_COMPENSATION.COMP_CODE", DataTypes.Character, 6);
                AddControl(ReportSection.REPORT, "INDEXED.F110_COMPENSATION.AMT_GROSS", DataTypes.Numeric, 9);
                AddControl(ReportSection.REPORT, "INDEXED.F110_COMPENSATION.AMT_NET", DataTypes.Numeric, 9);
                AddControl(ReportSection.REPORT, "INDEXED.F110_COMPENSATION.EP_NBR", DataTypes.Numeric, 6);
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
        //# Do not delete, modify or move it.  Updated: 10/27/2017 11:14:33 AM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "INDEXED.F110_COMPENSATION.DOC_NBR":
                    return Common.StringToField(rdrF110_COMPENSATION.GetString("DOC_NBR").PadRight(3, ' '));

                case "INDEXED.F110_COMPENSATION.COMP_CODE":
                    return Common.StringToField(rdrF110_COMPENSATION.GetString("COMP_CODE").PadRight(6, ' '));

                case "INDEXED.F110_COMPENSATION.AMT_GROSS":
                    return rdrF110_COMPENSATION.GetNumber("AMT_GROSS").ToString().PadLeft(9, ' ');

                case "INDEXED.F110_COMPENSATION.AMT_NET":
                    return rdrF110_COMPENSATION.GetNumber("AMT_NET").ToString().PadLeft(9, ' ');

                case "INDEXED.F110_COMPENSATION.EP_NBR":
                    return rdrF110_COMPENSATION.GetNumber("EP_NBR").ToString().PadLeft(6, ' ');

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
                            WriteData();
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
        }


        #endregion

        #endregion
    }
}
