#region "Screen Comments"

// #> PROGRAM-ID.     R997A.QZS
// ((C)) Dyad Technologies
// PROGRAM PURPOSE : THE FIRST PASS FOR R997
// MODIFICATION HISTORY
// DATE SMS # WHO DESCRIPTION
// 90.09.11 131 D.B. ORIGINAL
// 91.03.08  138     D.B. ADD RECORD 6 ITEMS
// 03/dec/16  A.A. alpha doctor nbr

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
    public class R997A : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R997A";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrU030_TAPE_67_FILE = new Reader();
        private Reader rdrR997 = new Reader();

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
                // Create Subfile.
                SubFile = true;
                SubFileName = "R997";
                SubFileType = SubFileType.Keep;
                SubFileAT = "";

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

        private void Access_U030_TAPE_67_FILE()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("RAT_67_TRANS_AMT, ");
            strSQL.Append("RAT_67_AMT_CLAIMS_ADJ, ");
            strSQL.Append("RAT_67_AMT_ADVANCES, ");
            strSQL.Append("RAT_67_AMT_REDUCTIONS, ");
            strSQL.Append("RAT_67_AMT_DEDUCTIONS, ");
            strSQL.Append("RAT_67_TRANS_CD, ");
            strSQL.Append("RAT_67_CHEQUE_IND, ");
            strSQL.Append("RAT_67_TRANS_DATE, ");
            strSQL.Append("RAT_67_TRANS_MESSAGE, ");
            strSQL.Append("RAT_67_TOTAL_CLINIC_AMT, ");
            strSQL.Append("RAT_67_AMT_BILL, ");
            strSQL.Append("RAT_67_AMT_PAID ");
            strSQL.Append("FROM SEQUENTIAL.U030_TAPE_67_FILE ");

            strSQL.Append(Choose());

            rdrU030_TAPE_67_FILE.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.m_strFlatFileDictionary, ReportFunctions.TextFiles);

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

        private decimal W_RAT_67_TRANS_AMT()
        {
            decimal decReturnValue = 0;

            try
            {
                decReturnValue = rdrU030_TAPE_67_FILE.GetNumber("RAT_67_TRANS_AMT");
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
                AddControl(ReportSection.SUMMARY, "SEQUENTIAL.U030_TAPE_67_FILE.RAT_67_AMT_CLAIMS_ADJ", DataTypes.Numeric, 9);
                AddControl(ReportSection.SUMMARY, "SEQUENTIAL.U030_TAPE_67_FILE.RAT_67_AMT_ADVANCES", DataTypes.Numeric, 9);
                AddControl(ReportSection.SUMMARY, "SEQUENTIAL.U030_TAPE_67_FILE.RAT_67_AMT_REDUCTIONS", DataTypes.Numeric, 9);
                AddControl(ReportSection.SUMMARY, "SEQUENTIAL.U030_TAPE_67_FILE.RAT_67_AMT_DEDUCTIONS", DataTypes.Numeric, 9);
                AddControl(ReportSection.SUMMARY, "SEQUENTIAL.U030_TAPE_67_FILE.RAT_67_TRANS_CD", DataTypes.Character, 2);
                AddControl(ReportSection.SUMMARY, "SEQUENTIAL.U030_TAPE_67_FILE.RAT_67_CHEQUE_IND", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "SEQUENTIAL.U030_TAPE_67_FILE.RAT_67_TRANS_DATE", DataTypes.Numeric, 8);
                AddControl(ReportSection.SUMMARY, "SEQUENTIAL.U030_TAPE_67_FILE.RAT_67_TRANS_AMT", DataTypes.Numeric, 8);
                AddControl(ReportSection.SUMMARY, "SEQUENTIAL.U030_TAPE_67_FILE.RAT_67_TRANS_MESSAGE", DataTypes.Character, 50);
                AddControl(ReportSection.SUMMARY, "SEQUENTIAL.U030_TAPE_67_FILE.RAT_67_TOTAL_CLINIC_AMT", DataTypes.Numeric, 9);
                AddControl(ReportSection.SUMMARY, "SEQUENTIAL.U030_TAPE_67_FILE.RAT_67_AMT_BILL", DataTypes.Numeric, 9);
                AddControl(ReportSection.SUMMARY, "SEQUENTIAL.U030_TAPE_67_FILE.RAT_67_AMT_PAID", DataTypes.Numeric, 9);
                AddControl(ReportSection.REPORT, "W_RAT_67_TRANS_AMT", DataTypes.Numeric, 11, SummaryType.SUBTOTAL, " ");
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
        //# Do not delete, modify or move it.  Updated: 10/10/2017 1:40:52 PM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "SEQUENTIAL.U030_TAPE_67_FILE.RAT_67_AMT_CLAIMS_ADJ":
                    return rdrU030_TAPE_67_FILE.GetNumber("RAT_67_AMT_CLAIMS_ADJ").ToString().PadLeft(9, ' ');

                case "SEQUENTIAL.U030_TAPE_67_FILE.RAT_67_AMT_ADVANCES":
                    return rdrU030_TAPE_67_FILE.GetNumber("RAT_67_AMT_ADVANCES").ToString().PadLeft(9, ' ');

                case "SEQUENTIAL.U030_TAPE_67_FILE.RAT_67_AMT_REDUCTIONS":
                    return rdrU030_TAPE_67_FILE.GetNumber("RAT_67_AMT_REDUCTIONS").ToString().PadLeft(9, ' ');

                case "SEQUENTIAL.U030_TAPE_67_FILE.RAT_67_AMT_DEDUCTIONS":
                    return rdrU030_TAPE_67_FILE.GetNumber("RAT_67_AMT_DEDUCTIONS").ToString().PadLeft(9, ' ');

                case "SEQUENTIAL.U030_TAPE_67_FILE.RAT_67_TRANS_CD":
                    return Common.StringToField(rdrU030_TAPE_67_FILE.GetString("RAT_67_TRANS_CD").PadRight(2, ' '));

                case "SEQUENTIAL.U030_TAPE_67_FILE.RAT_67_CHEQUE_IND":
                    return Common.StringToField(rdrU030_TAPE_67_FILE.GetString("RAT_67_CHEQUE_IND").PadRight(1, ' '));

                case "SEQUENTIAL.U030_TAPE_67_FILE.RAT_67_TRANS_DATE":
                    return rdrU030_TAPE_67_FILE.GetNumber("RAT_67_TRANS_DATE").ToString().PadLeft(8, ' ');

                case "SEQUENTIAL.U030_TAPE_67_FILE.RAT_67_TRANS_AMT":
                    return rdrU030_TAPE_67_FILE.GetNumber("RAT_67_TRANS_AMT").ToString().PadLeft(8, ' ');

                case "SEQUENTIAL.U030_TAPE_67_FILE.RAT_67_TRANS_MESSAGE":
                    return Common.StringToField(rdrU030_TAPE_67_FILE.GetString("RAT_67_TRANS_MESSAGE").PadRight(50, ' '));

                case "SEQUENTIAL.U030_TAPE_67_FILE.RAT_67_TOTAL_CLINIC_AMT":
                    return rdrU030_TAPE_67_FILE.GetNumber("RAT_67_TOTAL_CLINIC_AMT").ToString().PadLeft(9, ' ');

                case "SEQUENTIAL.U030_TAPE_67_FILE.RAT_67_AMT_BILL":
                    return rdrU030_TAPE_67_FILE.GetNumber("RAT_67_AMT_BILL").ToString().PadLeft(9, ' ');

                case "SEQUENTIAL.U030_TAPE_67_FILE.RAT_67_AMT_PAID":
                    return rdrU030_TAPE_67_FILE.GetNumber("RAT_67_AMT_PAID").ToString().PadLeft(9, ' ');

                case "W_RAT_67_TRANS_AMT":
                    return W_RAT_67_TRANS_AMT().ToString().PadLeft(11, ' ');

                default:

                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_U030_TAPE_67_FILE();

                while (rdrU030_TAPE_67_FILE.Read())
                {
                    WriteData();
                }
                rdrU030_TAPE_67_FILE.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrU030_TAPE_67_FILE != null))
            {
                rdrU030_TAPE_67_FILE.Close();
                rdrU030_TAPE_67_FILE = null;
            }
        }


        #endregion

        #endregion
    }
}
