#region "Screen Comments"

// #> PROGRAM-ID.     R030H.QZS
// ((C)) Dyad Technologies
// PROGRAM PURPOSE : PRINT RAT DETAILS THAT DO NOT HAVE EQUIVALENCE
// OMA CODE
// MODIFICATION HISTORY
// DATE   WHO          DESCRIPTION
// 91/OCT/02 M.C.      - ORIGINAL PDR 520
// 97/SEP/17 M.C.      - PDR 663 - ADD SORT STMT
// 03/dec/15 A.A.      - alpha doctor nbr

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
    public class R030H : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R030H";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrU030_NO_EQUIV = new Reader();
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

                Sort = "PART_DTL_CLINIC_NBR ASC, PART_DTL_CLAIM_NBR ASC";

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

        private void Access_U030_NO_EQUIV()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("PART_DTL_CLINIC_NBR, ");
            strSQL.Append("PART_DTL_CLAIM_NBR, ");
            strSQL.Append("PART_DTL_OMA_CD, ");
            strSQL.Append("PART_DTL_SERV_DATE, ");
            strSQL.Append("PART_DTL_AMT_BILL, ");
            strSQL.Append("PART_DTL_AMT_PAID, ");
            strSQL.Append("PART_DTL_EXPLAN_CD ");
            strSQL.Append("FROM TEMPORARYDATA.U030_NO_EQUIV ");

            strSQL.Append(Choose());

            //rdrU030_NO_EQUIV.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
            rdrU030_NO_EQUIV.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

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
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U030_NO_EQUIV.PART_DTL_CLINIC_NBR", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U030_NO_EQUIV.PART_DTL_CLAIM_NBR", DataTypes.Character, 8);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U030_NO_EQUIV.PART_DTL_OMA_CD", DataTypes.Character, 5);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U030_NO_EQUIV.PART_DTL_SERV_DATE", DataTypes.Numeric, 8);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U030_NO_EQUIV.PART_DTL_AMT_BILL", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U030_NO_EQUIV.PART_DTL_AMT_PAID", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U030_NO_EQUIV.PART_DTL_EXPLAN_CD", DataTypes.Character, 2);

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
        //# Do not delete, modify or move it.  Updated: 9/26/2017 10:11:30 AM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "TEMPORARYDATA.U030_NO_EQUIV.PART_DTL_CLINIC_NBR":
                    return rdrU030_NO_EQUIV.GetNumber("PART_DTL_CLINIC_NBR").ToString().PadLeft(2, ' ');

                case "TEMPORARYDATA.U030_NO_EQUIV.PART_DTL_CLAIM_NBR":
                    return Common.StringToField(rdrU030_NO_EQUIV.GetString("PART_DTL_CLAIM_NBR").PadRight(8, ' '));

                case "TEMPORARYDATA.U030_NO_EQUIV.PART_DTL_OMA_CD":
                    return Common.StringToField(rdrU030_NO_EQUIV.GetString("PART_DTL_OMA_CD").PadRight(5, ' '));

                case "TEMPORARYDATA.U030_NO_EQUIV.PART_DTL_SERV_DATE":
                    return rdrU030_NO_EQUIV.GetNumber("PART_DTL_SERV_DATE").ToString().PadLeft(8, ' ');

                case "TEMPORARYDATA.U030_NO_EQUIV.PART_DTL_AMT_BILL":
                    return rdrU030_NO_EQUIV.GetNumber("PART_DTL_AMT_BILL").ToString().PadLeft(6, ' ');

                case "TEMPORARYDATA.U030_NO_EQUIV.PART_DTL_AMT_PAID":
                    return rdrU030_NO_EQUIV.GetNumber("PART_DTL_AMT_PAID").ToString().PadLeft(6, ' ');

                case "TEMPORARYDATA.U030_NO_EQUIV.PART_DTL_EXPLAN_CD":
                    return Common.StringToField(rdrU030_NO_EQUIV.GetString("PART_DTL_EXPLAN_CD").PadRight(2, ' '));

                default:

                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_U030_NO_EQUIV();

                while (rdrU030_NO_EQUIV.Read())
                {
                    WriteData();
                }
                rdrU030_NO_EQUIV.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrU030_NO_EQUIV != null))
            {
                rdrU030_NO_EQUIV.Close();
                rdrU030_NO_EQUIV = null;
            }
        }


        #endregion

        #endregion
    }
}
