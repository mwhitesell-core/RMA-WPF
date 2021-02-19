
#region "Screen Comments"


#endregion

using Core.DataAccess.SqlServer;
using Core.DataAccess.TextFile;
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
    public class R151E : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R151E";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrR151 = new Reader();
        #endregion
        private Reader rdrF070_DEPT_MSTR = new Reader();
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

                Sort = "DOC_CLINIC_NBR ASC, DOC_NBR ASC";

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

        private void Access_R151()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_DEPT, ");
            strSQL.Append("DOC_CLINIC_NBR, ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("X_COMMA, ");
            strSQL.Append("DOC_NAME, ");
            strSQL.Append("DOC_INITS, ");
            strSQL.Append("DOC_SIN_NBR, ");
            strSQL.Append("AMT_NET ");
            strSQL.Append("FROM TEMPORARYDATA.R151 ");

            strSQL.Append(Choose());

            rdrR151.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);

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
            strSQL.Append("DEPT_NBR = ").Append(rdrR151.GetNumber("DOC_DEPT"));

            rdrF070_DEPT_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

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

            if (QDesign.NULL(rdrF070_DEPT_MSTR.GetNumber("DEPT_COMPANY")) == QDesign.NULL(2d))
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
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R151.DOC_CLINIC_NBR", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R151.X_COMMA", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R151.DOC_DEPT", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R151.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R151.DOC_NAME", DataTypes.Character, 24);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R151.DOC_INITS", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R151.DOC_SIN_NBR", DataTypes.Numeric, 9);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R151.AMT_NET", DataTypes.Numeric, 18);
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
        //# Do not delete, modify or move it.  Updated: 2017-07-25 6:51:37 PM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "TEMPORARYDATA.R151.DOC_CLINIC_NBR":
                    return rdrR151.GetNumber("DOC_CLINIC_NBR").ToString();

                case "TEMPORARYDATA.R151.X_COMMA":
                    return Common.StringToField(rdrR151.GetString("X_COMMA"));

                case "TEMPORARYDATA.R151.DOC_DEPT":
                    return rdrR151.GetNumber("DOC_DEPT").ToString();

                case "TEMPORARYDATA.R151.DOC_NBR":
                    return Common.StringToField(rdrR151.GetString("DOC_NBR"));

                case "TEMPORARYDATA.R151.DOC_NAME":
                    return Common.StringToField(rdrR151.GetString("DOC_NAME"));

                case "TEMPORARYDATA.R151.DOC_INITS":
                    return Common.StringToField(rdrR151.GetString("DOC_INITS"));

                case "TEMPORARYDATA.R151.DOC_SIN_NBR":
                    return rdrR151.GetNumber("DOC_SIN_NBR").ToString().PadLeft(9, '0');

                case "TEMPORARYDATA.R151.AMT_NET":
                    return rdrR151.GetNumber("AMT_NET").ToString();

                default:
                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_R151();

                while (rdrR151.Read())
                {
                    Link_F070_DEPT_MSTR();
                    while (rdrF070_DEPT_MSTR.Read())
                    {
                        WriteData();
                    }
                    rdrF070_DEPT_MSTR.Close();
                }
                rdrR151.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrR151 != null))
            {
                rdrR151.Close();
                rdrR151 = null;
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
