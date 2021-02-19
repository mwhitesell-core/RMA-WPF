#region "Screen Comments"


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
    public class MARYGSTTAX : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "MARYGSTTAX";
        protected const bool REPORT_HAS_PARAMETERS = true;

        // Data Helpers.
        private Reader rdrF113_DEFAULT_COMP = new Reader();
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

                Sort = "DOC_NAME ASC";

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

        private void Access_F113_DEFAULT_COMP()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("COMP_CODE, ");
            strSQL.Append("EP_NBR_FROM, ");
            strSQL.Append("EP_NBR_TO, ");
            strSQL.Append("AMT_NET, ");
            strSQL.Append("AMT_GROSS ");
            strSQL.Append("FROM INDEXED.F113_DEFAULT_COMP ");

            strSQL.Append(Choose());

            rdrF113_DEFAULT_COMP.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

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
            strSQL.Append("DOC_NBR = ").Append(Common.StringToField(rdrF113_DEFAULT_COMP.GetString("DOC_NBR")));

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

            if (QDesign.NULL(rdrF113_DEFAULT_COMP.GetString("COMP_CODE")) == QDesign.NULL("GSTTAX") & QDesign.NULL(rdrF113_DEFAULT_COMP.GetNumber("EP_NBR_FROM")) == QDesign.NULL(X_DATE_FROM()) & QDesign.NULL(rdrF113_DEFAULT_COMP.GetNumber("EP_NBR_TO")) == QDesign.NULL(X_DATE_TO()))
            {
                blnSelected = true;
            }

            return blnSelected;
        }

        #endregion

        #region " DEFINES "

        private decimal X_DATE_FROM()
        {
            decimal decReturnValue = 0;

            try
            {
                if (ReportFunctions.astrScreenParameters[0].ToString().Trim() != string.Empty)
                {
                    decReturnValue = Convert.ToDecimal(ReportFunctions.astrScreenParameters[0].ToString());
                }
                else
                {
                    decReturnValue = 0;
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private decimal X_DATE_TO()
        {
            decimal decReturnValue = 0;

            try
            {
                if (ReportFunctions.astrScreenParameters[1].ToString().Trim() != string.Empty)
                {
                    decReturnValue = Convert.ToDecimal(ReportFunctions.astrScreenParameters[1].ToString());
                }
                else
                {
                    decReturnValue = 0;
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        #endregion

        #region " CONTROLS "

        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.REPORT, "INDEXED.F113_DEFAULT_COMP.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "INDEXED.F020_DOCTOR_MSTR.DOC_NAME", DataTypes.Character, 24);
                AddControl(ReportSection.REPORT, "INDEXED.F113_DEFAULT_COMP.COMP_CODE", DataTypes.Character, 6);
                AddControl(ReportSection.REPORT, "INDEXED.F113_DEFAULT_COMP.AMT_NET", DataTypes.Numeric, 9);
                AddControl(ReportSection.REPORT, "INDEXED.F113_DEFAULT_COMP.AMT_GROSS", DataTypes.Numeric, 9);
                AddControl(ReportSection.FINAL_FOOTING, "INDEXED.F113_DEFAULT_COMP.AMT_NET", DataTypes.Numeric, 9);
                AddControl(ReportSection.FINAL_FOOTING, "INDEXED.F113_DEFAULT_COMP.AMT_GROSS", DataTypes.Numeric, 9);
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
        //# Do not delete, modify or move it.  Updated: 8/22/2017 10:52:07 AM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "INDEXED.F113_DEFAULT_COMP.DOC_NBR":
                    return Common.StringToField(rdrF113_DEFAULT_COMP.GetString("DOC_NBR"));

                case "INDEXED.F020_DOCTOR_MSTR.DOC_NAME":
                    return Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_NAME"));

                case "INDEXED.F113_DEFAULT_COMP.COMP_CODE":
                    return Common.StringToField(rdrF113_DEFAULT_COMP.GetString("COMP_CODE"));

                case "INDEXED.F113_DEFAULT_COMP.AMT_NET":
                    return rdrF113_DEFAULT_COMP.GetNumber("AMT_NET").ToString();

                case "INDEXED.F113_DEFAULT_COMP.AMT_GROSS":
                    return rdrF113_DEFAULT_COMP.GetNumber("AMT_GROSS").ToString();

                default:
                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_F113_DEFAULT_COMP();

                while (rdrF113_DEFAULT_COMP.Read())
                {
                    Link_F020_DOCTOR_MSTR();
                    while (rdrF020_DOCTOR_MSTR.Read())
                    {
                            WriteData();
                    }
                    rdrF020_DOCTOR_MSTR.Close();
                }
                rdrF113_DEFAULT_COMP.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrF113_DEFAULT_COMP != null))
            {
                rdrF113_DEFAULT_COMP.Close();
                rdrF113_DEFAULT_COMP = null;
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
