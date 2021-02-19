#region "Screen Comments"

// #> PROGRAM-ID.     r031c.qzs
// ((C)) Dyad Infosys LTD  
// Purpose:  determine the highest premium amount transaction
// As of today for Feb Premium, the highest is over $6400
// IF selected amount is higher than $9999, must modify the amount check in u030b_part3_a.qts for x-batch-amount
// As of Nov 4 , 2009 run, the highest is $12,172.91, last request of u030b_part3_a.qts has changed significantly.
// From now on, user checks to make sure the batch amount is not greater than $99,999.99
// MODIFICATION HISTORY
// DATE   WHO         DESCRIPTION
// 09/Apr/20 M.C.        - original
// 09/nov/05 M.C. - add second pass to generate r031c_2 to display each batch amount so that user can verify
// the batch does not go over $99,999.99  
// 15/Apr/09 MC1         - increase the picture format for final footing in the last pass
// 15/jun/09 be1 (1453)  - increase the picture formats for amounts to ensure 100,000.00 figures can be printed

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
    public class R031C_1 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R031C_1";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrR031A_ACTIVE_DOCTOR = new Reader();

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

        private void Access_R031A_ACTIVE_DOCTOR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("X_TOTAL_PAID_AMT ");
            strSQL.Append("FROM TEMPORARYDATA.R031A_ACTIVE_DOCTOR ");

            strSQL.Append(Choose());

            rdrR031A_ACTIVE_DOCTOR.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);

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
                AddControl(ReportSection.FINAL_FOOTING, "TEMPORARYDATA.R031A_ACTIVE_DOCTOR.X_TOTAL_PAID_AMT", DataTypes.Numeric, 8);
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
        //# Do not delete, modify or move it.  Updated: 10/11/2017 7:57:28 AM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "TEMPORARYDATA.R031A_ACTIVE_DOCTOR.X_TOTAL_PAID_AMT":
                    return rdrR031A_ACTIVE_DOCTOR.GetNumber("X_TOTAL_PAID_AMT").ToString().PadLeft(8, ' ');

                default:

                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_R031A_ACTIVE_DOCTOR();

                while (rdrR031A_ACTIVE_DOCTOR.Read())
                {
                    WriteData();
                }
                rdrR031A_ACTIVE_DOCTOR.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrR031A_ACTIVE_DOCTOR != null))
            {
                rdrR031A_ACTIVE_DOCTOR.Close();
                rdrR031A_ACTIVE_DOCTOR = null;
            }
        }


        #endregion

        #endregion
    }
}
