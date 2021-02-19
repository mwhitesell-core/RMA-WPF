#region "Screen Comments"

// #> PROGRAM-ID.     r031a.qzs
// ((C)) Dyad Infosys LTD  
// Purpose: extract AGEP payments from u030-tape-8-file 
// This program: 
// will extract data from the variable length file  u030-tape-8-file 
// and put data into a fixed length format so that in a subsequent pass
// awk can extract the data required.
// MODIFICATION HISTORY
// DATE   WHO         DESCRIPTION
// 06/oct/10 b.e.        - original
// 09/Apr/06 M.C. - Brad requested to add`**********************` as the
// first line of the report

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
    public class R031A : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R031A";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrU030_TAPE_8_FILE = new Reader();

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

        private void Access_U030_TAPE_8_FILE()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("RAT_8_MESSAGE_TEXT ");
            strSQL.Append("FROM SEQUENTIAL.U030_TAPE_8_FILE ");

            strSQL.Append(Choose());

            rdrU030_TAPE_8_FILE.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.m_strFlatFileDictionary, ReportFunctions.TextFiles);

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

        #endregion

        #region " DEFINES "

        #endregion

        #region " CONTROLS "

        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.REPORT, "SEQUENTIAL.U030_TAPE_8_FILE.RAT_8_MESSAGE_TEXT", DataTypes.Character, 70);
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
        //# Do not delete, modify or move it.  Updated: 10/10/2017 10:08:41 AM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "SEQUENTIAL.U030_TAPE_8_FILE.RAT_8_MESSAGE_TEXT":
                    return Common.StringToField(rdrU030_TAPE_8_FILE.GetString("RAT_8_MESSAGE_TEXT").PadRight(70, ' '));

                default:

                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_U030_TAPE_8_FILE();

                while (rdrU030_TAPE_8_FILE.Read())
                {
                    WriteData();
                }
                rdrU030_TAPE_8_FILE.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrU030_TAPE_8_FILE != null))
            {
                rdrU030_TAPE_8_FILE.Close();
                rdrU030_TAPE_8_FILE = null;
            }
        }


        #endregion

        #endregion
    }
}
