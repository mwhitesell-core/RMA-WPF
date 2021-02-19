#region "Screen Comments"

// 2007/04/16  M.C. change the definition for x-paid-amt with negative amount as well
// 2009/03/31   M.C.    include clmhdr-adj-cd in the sort, footing at clmhdr-adj-cd since
// now we have 3 different files(2 AGEP & MOHR)
// 2009/04/08   M.C. cosmetic change on report including page heading, similiar to r031b_agep.txt
// 2013/05/15   MC1  cosmetic change on report including page heading, similiar to r031b_agep.txt to include MOHD
// add a new request to have subtotal for clmhdr-adj-cd
// 2013/09/11   MC1     include the third pass for undefined doctor transactions if applied
// 2016/07/14   MC2     expand the amount fields

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
    public class R031_PART3_BEFORE_UPDATE : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R031_PART3_BEFORE_UPDATE";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrR031A_BATCH_NBR = new Reader();
        private Reader rdrTMP_DOCTOR_ALPHA = new Reader();

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

                Sort = "ICONST_CLINIC_NBR_1_2 ASC, DOC_OHIP_NBR ASC, X_ADJ_CD ASC";

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

        private void Access_R031A_BATCH_NBR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT * ");
            strSQL.Append("FROM TEMPORARYDATA.R031A_BATCH_NBR ");

            strSQL.Append(Choose());

            rdrR031A_BATCH_NBR.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);

            strSQL = null;
        }

        private void Link_TMP_DOCTOR_ALPHA()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_OHIP_NBR ");
            strSQL.Append("FROM INDEXED.TMP_DOCTOR_ALPHA ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_OHIP_NBR = ").Append(rdrR031A_BATCH_NBR.GetNumber("DOC_OHIP_NBR"));
            strSQL.Append(" AND DOC_NBR = ").Append(Common.StringToField(QDesign.NULL(" ")));
            strSQL.Append(" AND TMP_ALPHA_FIELD_1 = ").Append(Common.StringToField(QDesign.ASCII(rdrR031A_BATCH_NBR.GetNumber("ICONST_CLINIC_NBR_1_2"), 2)));

            rdrTMP_DOCTOR_ALPHA.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

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

        private decimal X_TECH_AMT()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrR031A_BATCH_NBR.GetNumber("ICONST_CLINIC_NBR_1_2")) >= 61 && QDesign.NULL(rdrR031A_BATCH_NBR.GetNumber("ICONST_CLINIC_NBR_1_2")) <= 75)
                {
                    decReturnValue = QDesign.Divide(rdrR031A_BATCH_NBR.GetNumber("X_TOTAL_PAID_AMT") * rdrTMP_DOCTOR_ALPHA.GetNumber("TMP_COUNTER_1"), rdrTMP_DOCTOR_ALPHA.GetNumber("TMP_COUNTER_2"));
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_PROF_AMT()
        {
            decimal decReturnValue = 0;

            try
            {
                decReturnValue = rdrR031A_BATCH_NBR.GetNumber("X_TOTAL_PAID_AMT") - X_TECH_AMT();
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
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R031A_BATCH_NBR.X_ADJ_CD", DataTypes.Character, 5);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R031A_BATCH_NBR.DOC_OHIP_NBR", DataTypes.Numeric, 6);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R031A_BATCH_NBR.X_TOTAL_PAID_AMT", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_TECH_AMT", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_PROF_AMT", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R031A_BATCH_NBR.ICONST_CLINIC_NBR_1_2", DataTypes.Numeric, 2);
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
        //# Do not delete, modify or move it.  Updated: 9/28/2017 7:37:58 AM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "TEMPORARYDATA.R031A_BATCH_NBR.X_ADJ_CD":
                    return Common.StringToField(rdrR031A_BATCH_NBR.GetString("X_ADJ_CD"));

                case "TEMPORARYDATA.R031A_BATCH_NBR.DOC_OHIP_NBR":
                    return rdrR031A_BATCH_NBR.GetNumber("DOC_OHIP_NBR").ToString();

                case "TEMPORARYDATA.R031A_BATCH_NBR.X_TOTAL_PAID_AMT":
                    return rdrR031A_BATCH_NBR.GetNumber("X_TOTAL_PAID_AMT").ToString();

                case "X_TECH_AMT":
                    return X_TECH_AMT().ToString();

                case "X_PROF_AMT":
                    return X_PROF_AMT().ToString();

                case "TEMPORARYDATA.R031A_BATCH_NBR.ICONST_CLINIC_NBR_1_2":
                    return rdrR031A_BATCH_NBR.GetNumber("ICONST_CLINIC_NBR_1_2").ToString();

                default:
                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_R031A_BATCH_NBR();

                while (rdrR031A_BATCH_NBR.Read())
                {
                    Link_TMP_DOCTOR_ALPHA();
                    while ((rdrTMP_DOCTOR_ALPHA.Read()))
                    {
                        WriteData();
                    }
                    rdrTMP_DOCTOR_ALPHA.Close();
                }
                rdrR031A_BATCH_NBR.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrR031A_BATCH_NBR != null))
            {
                rdrR031A_BATCH_NBR.Close();
                rdrR031A_BATCH_NBR = null;
            }

            if ((rdrTMP_DOCTOR_ALPHA != null))
            {
                rdrTMP_DOCTOR_ALPHA.Close();
                rdrTMP_DOCTOR_ALPHA = null;
            }
        }

        #endregion

        #endregion
    }
}
