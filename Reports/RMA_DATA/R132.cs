#region "Screen Comments"

// Program: r132.qzc
// Purpose: create u132_awk.com and pass parameters to awk script based upon
// contents of f113 driver record called

#endregion

using Core.DataAccess.SqlServer;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.ReportFramework;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using System.IO;

namespace RMA_DATA
{
    public class R132 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R132_awk";

        protected const bool REPORT_HAS_PARAMETERS = true;

        // Data Helpers.
        private Reader rdrF113_DEFAULT_COMP_UPLOAD_DRIVER = new Reader();

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

        private void Access_F113_DEFAULT_COMP_UPLOAD_DRIVER()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("SEQ_NBR, ");
            strSQL.Append("COLUMN_NBR_DOC_NBR, ");
            strSQL.Append("COLUMN_NBR_DOC_SURNAME, ");
            strSQL.Append("COLUMN_NBR_DOC_INITS, ");
            strSQL.Append("COLUMN_NBR_DOC_GIVEN_NAMES, ");
            strSQL.Append("COLUMN_NBR_AMT, ");
            strSQL.Append("COLUMN_NBR_COMP_CODE ");
            strSQL.Append("FROM [101C].INDEXED.F113_DEFAULT_COMP_UPLOAD_DRIVER ");

            strSQL.Append(Choose());

            rdrF113_DEFAULT_COMP_UPLOAD_DRIVER.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

            strSQL = null;
        }

        #endregion

        #region " CHOOSE "

        private string Choose()
        {

            StringBuilder strChoose = new StringBuilder(string.Empty);

            strChoose.Append(" WHERE ").Append("SEQ_NBR = ").Append(QDesign.NConvert(ReportFunctions.astrScreenParameters[0].ToString()));

            return strChoose.ToString();

        }

        #endregion

        #region " SELECT IF "

        #endregion

        #region " DEFINES "
        private string X_FILENAME_TO_PROCESS()
        {

            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.NULL(ReportFunctions.astrScreenParameters[1].ToString());
                // Prompt String: "Filename to process: "

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
                AddControl(ReportSection.REPORT, "INDEXED.F113_DEFAULT_COMP_UPLOAD_DRIVER.COLUMN_NBR_DOC_NBR", DataTypes.Numeric, 3);
                AddControl(ReportSection.REPORT, "INDEXED.F113_DEFAULT_COMP_UPLOAD_DRIVER.COLUMN_NBR_DOC_SURNAME", DataTypes.Numeric, 3);
                AddControl(ReportSection.REPORT, "INDEXED.F113_DEFAULT_COMP_UPLOAD_DRIVER.COLUMN_NBR_DOC_INITS", DataTypes.Numeric, 3);
                AddControl(ReportSection.REPORT, "INDEXED.F113_DEFAULT_COMP_UPLOAD_DRIVER.COLUMN_NBR_DOC_GIVEN_NAMES", DataTypes.Numeric, 3);
                AddControl(ReportSection.REPORT, "INDEXED.F113_DEFAULT_COMP_UPLOAD_DRIVER.COLUMN_NBR_AMT", DataTypes.Numeric, 3);
                AddControl(ReportSection.REPORT, "INDEXED.F113_DEFAULT_COMP_UPLOAD_DRIVER.COLUMN_NBR_COMP_CODE", DataTypes.Numeric, 3);
                AddControl(ReportSection.REPORT, "X_FILENAME_TO_PROCESS", DataTypes.Character, 30);

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
        //# Do not delete, modify or move it.  Updated: 6/29/2017 2:22:05 PM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "INDEXED.F113_DEFAULT_COMP_UPLOAD_DRIVER.COLUMN_NBR_DOC_NBR":
                    return rdrF113_DEFAULT_COMP_UPLOAD_DRIVER.GetNumber("COLUMN_NBR_DOC_NBR").ToString();

                case "INDEXED.F113_DEFAULT_COMP_UPLOAD_DRIVER.COLUMN_NBR_DOC_SURNAME":
                    return rdrF113_DEFAULT_COMP_UPLOAD_DRIVER.GetNumber("COLUMN_NBR_DOC_SURNAME").ToString();

                case "INDEXED.F113_DEFAULT_COMP_UPLOAD_DRIVER.COLUMN_NBR_DOC_INITS":
                    return rdrF113_DEFAULT_COMP_UPLOAD_DRIVER.GetNumber("COLUMN_NBR_DOC_INITS").ToString();

                case "INDEXED.F113_DEFAULT_COMP_UPLOAD_DRIVER.COLUMN_NBR_DOC_GIVEN_NAMES":
                    return rdrF113_DEFAULT_COMP_UPLOAD_DRIVER.GetNumber("COLUMN_NBR_DOC_GIVEN_NAMES").ToString();

                case "INDEXED.F113_DEFAULT_COMP_UPLOAD_DRIVER.COLUMN_NBR_AMT":
                    return rdrF113_DEFAULT_COMP_UPLOAD_DRIVER.GetNumber("COLUMN_NBR_AMT").ToString();

                case "INDEXED.F113_DEFAULT_COMP_UPLOAD_DRIVER.COLUMN_NBR_COMP_CODE":
                    return rdrF113_DEFAULT_COMP_UPLOAD_DRIVER.GetNumber("COLUMN_NBR_COMP_CODE").ToString();

                case "X_FILENAME_TO_PROCESS":
                    return Common.StringToField(X_FILENAME_TO_PROCESS());

                default:
                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_F113_DEFAULT_COMP_UPLOAD_DRIVER();

                while (rdrF113_DEFAULT_COMP_UPLOAD_DRIVER.Read())
                {
                    WriteData();
                }
                rdrF113_DEFAULT_COMP_UPLOAD_DRIVER.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrF113_DEFAULT_COMP_UPLOAD_DRIVER != null))
            {
                rdrF113_DEFAULT_COMP_UPLOAD_DRIVER.Close();
                rdrF113_DEFAULT_COMP_UPLOAD_DRIVER = null;
            }
        }

        #endregion

        #endregion
    }
}
