#region "Screen Comments"

// #> PROGRAM-ID.     R030N.QZS
// ((C)) Dyad Technologies
// PROGRAM PURPOSE : PRINT THE DOCTORS that have not created payment records 
// this report will be appended to the end of ru030k and ru030 if records exist
// MODIFICATION HISTORY
// DATE   WHO          DESCRIPTION
// 07/Jun/13 M.C.         - original  
// 09/Apr/01 M.C.      - include x-adj-cd in the linkage
// 13/Mar/18 MC1      - exclude records with zero amount
// 2009/04/14 - MC
// 2009/04/01 - MC
// link (ascii(iconst-clinic-nbr-1-2,2) + ascii(doc-ohip-nbr,6)) &
// 2009/04/01 - end

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
    public class R030N : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R030N";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrR031A_SORT_DOCTOR = new Reader();
        private Reader rdrTMP_COUNTERS_ALPHA = new Reader();
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

        private void Access_R031A_SORT_DOCTOR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("ICONST_CLINIC_NBR_1_2, ");
            strSQL.Append("X_ADJ_CD, ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("DOC_OHIP_NBR, ");
            strSQL.Append("X_PAYMENT ");
            strSQL.Append("FROM TEMPORARYDATA.R031A_SORT_DOCTOR ");

            strSQL.Append(Choose());

            rdrR031A_SORT_DOCTOR.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);

            strSQL = null;
        }

        private void Link_TMP_COUNTERS_ALPHA()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("TMP_COUNTER_KEY_ALPHA ");
            strSQL.Append("FROM INDEXED.TMP_COUNTERS_ALPHA ");
            strSQL.Append("WHERE ");
            strSQL.Append("TMP_COUNTER_KEY_ALPHA = ").Append(Common.StringToField(QDesign.ASCII(rdrR031A_SORT_DOCTOR.GetNumber("ICONST_CLINIC_NBR_1_2"), 2) + rdrR031A_SORT_DOCTOR.GetString("X_ADJ_CD").PadRight(5, ' ') + QDesign.ASCII(rdrR031A_SORT_DOCTOR.GetNumber("DOC_OHIP_NBR"), 6)));

            rdrTMP_COUNTERS_ALPHA.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

            strSQL = null;
        }

        private void Link_F020_DOCTOR_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("DOC_NAME, ");
            strSQL.Append("DOC_INIT1, ");
            strSQL.Append(" DOC_INIT2, ");
            strSQL.Append(" DOC_INIT3 ");
            strSQL.Append("FROM INDEXED.F020_DOCTOR_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_NBR = ").Append(Common.StringToField(rdrR031A_SORT_DOCTOR.GetString("DOC_NBR")));

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

            if (!ReportDataFunctions.Exists(rdrTMP_COUNTERS_ALPHA) && rdrR031A_SORT_DOCTOR.GetNumber("X_PAYMENT") != 0)
            {
                blnSelected = true;
            }

            return blnSelected;
        }

        #endregion

        #region " DEFINES "

        private string X_DOC_NAME()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.Pack(rdrF020_DOCTOR_MSTR.GetString("DOC_NAME") + ", " + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT1") + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT2") + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT3"));
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
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R031A_SORT_DOCTOR.ICONST_CLINIC_NBR_1_2", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R031A_SORT_DOCTOR.DOC_OHIP_NBR", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "X_DOC_NAME", DataTypes.Character, 30);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R031A_SORT_DOCTOR.X_PAYMENT", DataTypes.Numeric, 8);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R031A_SORT_DOCTOR.X_ADJ_CD", DataTypes.Character, 5);
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
        //# Do not delete, modify or move it.  Updated: 11/14/2017 12:08:35 PM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "TEMPORARYDATA.R031A_SORT_DOCTOR.ICONST_CLINIC_NBR_1_2":
                    return rdrR031A_SORT_DOCTOR.GetNumber("ICONST_CLINIC_NBR_1_2").ToString().PadLeft(2, ' ');

                case "TEMPORARYDATA.R031A_SORT_DOCTOR.DOC_OHIP_NBR":
                    return rdrR031A_SORT_DOCTOR.GetNumber("DOC_OHIP_NBR").ToString().PadLeft(6, ' ');

                case "X_DOC_NAME":
                    return Common.StringToField(X_DOC_NAME().PadRight(30, ' '));

                case "TEMPORARYDATA.R031A_SORT_DOCTOR.X_PAYMENT":
                    return rdrR031A_SORT_DOCTOR.GetNumber("X_PAYMENT").ToString().PadLeft(8, ' ');

                case "TEMPORARYDATA.R031A_SORT_DOCTOR.X_ADJ_CD":
                    return Common.StringToField(rdrR031A_SORT_DOCTOR.GetString("X_ADJ_CD").PadRight(5, ' '));

                default:
                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_R031A_SORT_DOCTOR();

                while (rdrR031A_SORT_DOCTOR.Read())
                {
                    Link_TMP_COUNTERS_ALPHA();
                    while (rdrTMP_COUNTERS_ALPHA.Read())
                    {
                        Link_F020_DOCTOR_MSTR();
                        while ((rdrF020_DOCTOR_MSTR.Read()))
                        {
                            WriteData();
                        }
                        rdrF020_DOCTOR_MSTR.Close();
                    }
                    rdrTMP_COUNTERS_ALPHA.Close();
                }
                rdrR031A_SORT_DOCTOR.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrR031A_SORT_DOCTOR != null))
            {
                rdrR031A_SORT_DOCTOR.Close();
                rdrR031A_SORT_DOCTOR = null;
            }
            if ((rdrTMP_COUNTERS_ALPHA != null))
            {
                rdrTMP_COUNTERS_ALPHA.Close();
                rdrTMP_COUNTERS_ALPHA = null;
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
