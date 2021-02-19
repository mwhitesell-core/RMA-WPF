#region "Screen Comments"
//  MODIFICATION HISTORY
//  1999/Feb/18          S.B.     - Checked for Y2K.
//  2003/dec/16		A.A.     - alpha doctor nbr
//

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
    public class DUMPF119YTD : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "DUMPF119YTD";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrF119_DOCTOR_YTD = new Reader();

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

                Sort = "DOC_NBR, COMP_CODE_GROUP, PROCESS_SEQ";

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

        private void Access_F119_DOCTOR_YTD()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("REC_TYPE, DOC_NBR, ");
            strSQL.Append("COMP_CODE_GROUP, ");
            strSQL.Append("PROCESS_SEQ, ");
            strSQL.Append("COMP_CODE, ");
            strSQL.Append("AMT_MTD, ");
            strSQL.Append("AMT_YTD ");
            strSQL.Append("FROM INDEXED.F119_DOCTOR_YTD ");

            strSQL.Append(Choose());

            rdrF119_DOCTOR_YTD.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

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

            if (rdrF119_DOCTOR_YTD.GetString("REC_TYPE") == "A")
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
                AddControl(ReportSection.REPORT, "INDEXED.F119_DOCTOR_YTD.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "INDEXED.F119_DOCTOR_YTD.COMP_CODE_GROUP", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "INDEXED.F119_DOCTOR_YTD.PROCESS_SEQ", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "INDEXED.F119_DOCTOR_YTD.COMP_CODE", DataTypes.Character, 6);
                AddControl(ReportSection.REPORT, "INDEXED.F119_DOCTOR_YTD.AMT_MTD", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "INDEXED.F119_DOCTOR_YTD.AMT_YTD", DataTypes.Numeric, 10);
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
        //# Do not delete, modify or move it.  Updated: 7/1/2017 2:28:04 PM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "INDEXED.F119_DOCTOR_YTD.DOC_NBR":
                    return Common.StringToField(rdrF119_DOCTOR_YTD.GetString("DOC_NBR").PadRight(3, ' '));

                case "INDEXED.F119_DOCTOR_YTD.COMP_CODE_GROUP":
                    return Common.StringToField(rdrF119_DOCTOR_YTD.GetString("COMP_CODE_GROUP").PadRight(1, ' '));

                case "INDEXED.F119_DOCTOR_YTD.PROCESS_SEQ":
                    return rdrF119_DOCTOR_YTD.GetNumber("PROCESS_SEQ").ToString().PadLeft(2, ' ');

                case "INDEXED.F119_DOCTOR_YTD.COMP_CODE":
                    return Common.StringToField(rdrF119_DOCTOR_YTD.GetString("COMP_CODE").PadRight(6, ' '));

                case "INDEXED.F119_DOCTOR_YTD.AMT_MTD":
                    return rdrF119_DOCTOR_YTD.GetNumber("AMT_MTD").ToString().PadRight(10, ' ');

                case "INDEXED.F119_DOCTOR_YTD.AMT_YTD":
                    return rdrF119_DOCTOR_YTD.GetNumber("AMT_YTD").ToString().PadRight(10, ' ');

                default:
                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_F119_DOCTOR_YTD();

                while (rdrF119_DOCTOR_YTD.Read())
                {
                    WriteData();
                }
                rdrF119_DOCTOR_YTD.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrF119_DOCTOR_YTD != null))
            {
                rdrF119_DOCTOR_YTD.Close();
                rdrF119_DOCTOR_YTD = null;
            }
        }

        #endregion

        #endregion
    }
}
