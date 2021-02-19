#region "Screen Comments"

// doc     : kathyf001status.qzs
// purpose : check if  status < 4
// who     : operations
// Date           Who             Description
// 2000/07/07     Yasemin         Original
// 2003/dec/17    A.A.  alpha doctor nbr

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
    public class KATHYF001STATUS : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "KATHYF001STATUS";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrF001_BATCH_CONTROL_FILE = new Reader();

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

        private void Access_F001_BATCH_CONTROL_FILE()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("BATCTRL_BATCH_STATUS, ");
            strSQL.Append("BATCTRL_BATCH_NBR, ");
            strSQL.Append("BATCTRL_DATE_PERIOD_END, ");
            strSQL.Append("BATCTRL_DATE_BATCH_ENTERED ");
            strSQL.Append("FROM INDEXED.F001_BATCH_CONTROL_FILE ");

            strSQL.Append(Choose());

            rdrF001_BATCH_CONTROL_FILE.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

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

            if (QDesign.NULL(rdrF001_BATCH_CONTROL_FILE.GetString("BATCTRL_BATCH_STATUS")).CompareTo(QDesign.NULL("4")) < 0)
            {
                blnSelected = true;
                ROW_NUMBER++;
            }

            return blnSelected;
        }

        #endregion

        #region " DEFINES "

        private int ROW_NUMBER = 0;

        #endregion

        #region " CONTROLS "

        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.REPORT, "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_BATCH_NBR", DataTypes.Character, 8);
                AddControl(ReportSection.REPORT, "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_DATE_PERIOD_END", DataTypes.Character, 8);
                AddControl(ReportSection.REPORT, "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_DATE_BATCH_ENTERED", DataTypes.Character, 8);
                AddControl(ReportSection.REPORT, "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_BATCH_STATUS", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "ROW_NUMBER", DataTypes.Numeric, 5);
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
        //# Do not delete, modify or move it.  Updated: 10/19/2017 11:14:51 AM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_BATCH_NBR":
                    return Common.StringToField(rdrF001_BATCH_CONTROL_FILE.GetString("BATCTRL_BATCH_NBR"));

                case "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_DATE_PERIOD_END":
                    return Common.StringToField(rdrF001_BATCH_CONTROL_FILE.GetString("BATCTRL_DATE_PERIOD_END"));

                case "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_DATE_BATCH_ENTERED":
                    return Common.StringToField(rdrF001_BATCH_CONTROL_FILE.GetString("BATCTRL_DATE_BATCH_ENTERED"));

                case "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_BATCH_STATUS":
                    return Common.StringToField(rdrF001_BATCH_CONTROL_FILE.GetString("BATCTRL_BATCH_STATUS"));

                case "ROW_NUMBER":
                    return ROW_NUMBER.ToString();

                default:

                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_F001_BATCH_CONTROL_FILE();
                ROW_NUMBER = 0;
                while (rdrF001_BATCH_CONTROL_FILE.Read())
                {
                    WriteData();
                }
                rdrF001_BATCH_CONTROL_FILE.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrF001_BATCH_CONTROL_FILE != null))
            {
                rdrF001_BATCH_CONTROL_FILE.Close();
                rdrF001_BATCH_CONTROL_FILE = null;
            }
        }


        #endregion

        #endregion
    }
}
