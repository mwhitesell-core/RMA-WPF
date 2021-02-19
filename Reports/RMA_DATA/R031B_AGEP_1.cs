#region "Screen Comments"

// #> PROGRAM-ID.     r031b_agep.qzs
// ((C)) Dyad Infosys LTD  
// Purpose: extract AGEP payments from r031a_agep subfile for each clinic from production 
// MODIFICATION HISTORY
// DATE   WHO         DESCRIPTION
// 07/Feb/26 M.C.        - original
// 09/apr/01 M.C. - include MOHR & AGE3 payments
// - add sort and payment-type
// 09/apr/6 yas  - add footing at x-clinic  skip 2
// 10/feb/08 MC1  - allow negative amount by including trailing sign
// 13/may/15 MC2  - include MOHD payments in the page heading
// - add new pass for subtotal for each payment type
// 16/Jul/14 MC3  - change picture field size

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
    public class R031B_AGEP_1 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R031B_AGEP_1";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrR031A_AGEP = new Reader();

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

                Sort = "X_CLINIC ASC, PAYMENT_TYPE ASC";

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

        private void Access_R031A_AGEP()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("X_CLINIC, ");
            strSQL.Append("PAYMENT_TYPE, ");
            strSQL.Append("RAT_67_TRANS_AMT ");
            strSQL.Append("FROM TEMPORARYDATA.R031A_AGEP ");

            strSQL.Append(Choose());

            rdrR031A_AGEP.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);

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
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R031A_AGEP.X_CLINIC", DataTypes.Character, 2);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R031A_AGEP.PAYMENT_TYPE", DataTypes.Character, 4);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R031A_AGEP.RAT_67_TRANS_AMT", DataTypes.Numeric, 8);

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
        //# Do not delete, modify or move it.  Updated: 9/28/2017 8:02:27 AM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "TEMPORARYDATA.R031A_AGEP.X_CLINIC":
                    return rdrR031A_AGEP.GetNumber("X_CLINIC").ToString().PadLeft(2, ' ');

                case "TEMPORARYDATA.R031A_AGEP.PAYMENT_TYPE":
                    return Common.StringToField(rdrR031A_AGEP.GetString("PAYMENT_TYPE").PadRight(4, ' '));

                case "TEMPORARYDATA.R031A_AGEP.RAT_67_TRANS_AMT":
                    return rdrR031A_AGEP.GetNumber("RAT_67_TRANS_AMT").ToString().PadLeft(8, ' ');

                default:

                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_R031A_AGEP();

                while (rdrR031A_AGEP.Read())
                {
                    WriteData();
                }
                rdrR031A_AGEP.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrR031A_AGEP != null))
            {
                rdrR031A_AGEP.Close();
                rdrR031A_AGEP = null;
            }
        }


        #endregion

        #endregion
    }
}
