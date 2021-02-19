#region "Screen Comments"

// filename: create_claims_sub.qzs
// purpose:  select data for claims_subfile history file for each clinic
// Modification History
// 91/02/14   D.B. MOD - ADD NEW FIELDS (HEALTH NBR, VERSION CD)
// 91/03/05   D.B. MOD - ACCORDING TO NEW CLAIMS AND PATIENT FILES
// 91/04/22   M.C. SMS 138 - MODIFY THE ACCESS STATEMENT
// 91/08/30   M.C. MOD - TAKE OUT THE SORTED STMT AND CONTROL BREAK
// FROM SUBFILE STMT OF PART C
// 92/02/03   Y.B. MOD - REPLACE SEL_F002_DTL_CLAIMS.DEF WITH
// SEL_PED_F002_DTL_CLAIMS.DEF
// 1999/06/04   S.B. MOD - ALTERED THE CALL TO `SEL_PED_F002_DTL_CLAIMS.DEF`
// TO USE `$USE` INSTEAD OF `SRC`.
// 03/09/17   M.C. MOD - in the third pass (C), add the additional fields
// in the subfile
// 2003/dec/11    A.A.     - alpha doctor nbr 

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
    public class CREATE_CLAIMS_SUBA : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "CREATE_CLAIMS_SUBA";
        protected const bool REPORT_HAS_PARAMETERS = true;

        // Data Helpers.
        private Reader rdrF002_CLAIMS_MSTR_DTL = new Reader();

        //#CORE_BEGIN_INCLUDE: SEL_PED_F002_DTL_CLAIMS"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 10/19/2017 10:42:22 AM

        private string CLINIC_NBR()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.NULL(ReportFunctions.astrScreenParameters[0].ToString());
                // Prompt String: "Enter Clinic: "
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_PED()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.NULL(ReportFunctions.astrScreenParameters[1].ToString());
                // Prompt String: "ENTER PERIOD END DATE (YYYYMMDD): "
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        //#CORE_END_INCLUDE: SEL_PED_F002_DTL_CLAIMS"

        private Reader rdrDETAIL_CLAIMSA = new Reader();

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
                SubFileName = "DETAIL_CLAIMSA";
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

        private void Access_F002_CLAIMS_MSTR_DTL()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("KEY_CLM_TYPE, ");
            strSQL.Append("KEY_CLM_BATCH_NBR, ");
            strSQL.Append("CLMDTL_ADJ_NBR, ");
            strSQL.Append("CLMDTL_DATE_PERIOD_END, ");
            strSQL.Append("KEY_CLM_CLAIM_NBR, ");
            strSQL.Append("CLMDTL_BATCH_NBR, ");
            strSQL.Append("CLMDTL_CLAIM_NBR, ");
            strSQL.Append("CLMDTL_OMA_CD, ");
            strSQL.Append("CLMDTL_OMA_SUFF, ");
            strSQL.Append("CLMDTL_ADJ_NBR, ");
            strSQL.Append("CLMDTL_NBR_SERV, ");
            strSQL.Append("CLMDTL_SV_YY, ");
            strSQL.Append("CLMDTL_SV_MM, ");
            strSQL.Append("CLMDTL_SV_DD, ");
            strSQL.Append("CLMDTL_CONSEC_DATES_R, ");
            strSQL.Append("CLMDTL_AMT_TECH_BILLED, ");
            strSQL.Append("CLMDTL_FEE_OMA, ");
            strSQL.Append("CLMDTL_FEE_OHIP, ");
            strSQL.Append("CLMDTL_DIAG_CD ");
            strSQL.Append("FROM INDEXED.F002_CLAIMS_MSTR_DTL ");

            strSQL.Append(Choose());

            rdrF002_CLAIMS_MSTR_DTL.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

            strSQL = null;
        }

        #endregion

        #region " CHOOSE "

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(string.Empty);

            strChoose.Append(ReportDataFunctions.GetWhereCondition("KEY_CLM_TYPE", "B", true));
            strChoose.Append(ReportDataFunctions.GetWhereCondition("KEY_CLM_BATCH_NBR", QDesign.NULL(CLINIC_NBR())+"@", false));

            return strChoose.ToString();
        }

        #endregion

        #region " SELECT IF "

        public override bool SelectIf()
        {
            bool blnSelected = false;

            if (QDesign.NULL(rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_OMA_CD")) != QDesign.NULL("0000") & 
                QDesign.NULL(rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_OMA_CD")) != QDesign.NULL("ZZZZ") & 
                QDesign.NULL(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_ADJ_NBR")) == QDesign.NULL(0d) 
                & QDesign.NULL(rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_DATE_PERIOD_END")) == QDesign.NULL(X_PED()))
            {
                blnSelected = true;
            }

            return blnSelected;
        }

        #endregion

        #region " DEFINES "

        private string F002_CLAIMS_MSTR_CLMDTL_ID()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = (rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_BATCH_NBR") + QDesign.ASCII(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_CLAIM_NBR"), 2) + 
                    rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_OMA_CD") + rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_OMA_SUFF") + 
                    QDesign.ASCII(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_ADJ_NBR"), 1));
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
            return strReturnValue;
        }

        private string F002_CLAIMS_MSTR_CLMDTL_SV_DATE()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = (rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_SV_YY").ToString() + rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_SV_MM").ToString().PadLeft(2, '0') + 
                    rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_SV_DD").ToString().PadLeft(2, '0'));
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
            return strReturnValue;
        }

        private string F002_CLAIMS_MSTR_CLMDTL_CONSEC_DATES()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = (rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_CONSEC_DATES_R"));
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
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR_DTL.KEY_CLM_BATCH_NBR", DataTypes.Character, 8);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR_DTL.KEY_CLM_CLAIM_NBR", DataTypes.Numeric, 2);
                AddControl(ReportSection.SUMMARY, "CLMDTL_ID", DataTypes.Character, 16);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR_DTL.CLMDTL_NBR_SERV", DataTypes.Numeric, 2);
                AddControl(ReportSection.SUMMARY, "CLMDTL_SV_DATE", DataTypes.Character, 8);
                AddControl(ReportSection.SUMMARY, "CLMDTL_CONSEC_DATES", DataTypes.Character, 9);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR_DTL.CLMDTL_AMT_TECH_BILLED", DataTypes.Numeric, 6);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR_DTL.CLMDTL_FEE_OMA", DataTypes.Numeric, 7);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR_DTL.CLMDTL_FEE_OHIP", DataTypes.Numeric, 7);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR_DTL.CLMDTL_DATE_PERIOD_END", DataTypes.Character, 8);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR_DTL.CLMDTL_DIAG_CD", DataTypes.Numeric, 3);
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
        //# Do not delete, modify or move it.  Updated: 10/19/2017 10:42:22 AM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "INDEXED.F002_CLAIMS_MSTR_DTL.KEY_CLM_BATCH_NBR":
                    return Common.StringToField(rdrF002_CLAIMS_MSTR_DTL.GetString("KEY_CLM_BATCH_NBR").PadRight(8, ' '));

                case "INDEXED.F002_CLAIMS_MSTR_DTL.KEY_CLM_CLAIM_NBR":
                    return rdrF002_CLAIMS_MSTR_DTL.GetNumber("KEY_CLM_CLAIM_NBR").ToString().PadLeft(2, ' ');

                case "CLMDTL_ID":
                    return Common.StringToField(F002_CLAIMS_MSTR_CLMDTL_ID().PadRight(16, ' '));

                case "INDEXED.F002_CLAIMS_MSTR_DTL.CLMDTL_NBR_SERV":
                    return rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_NBR_SERV").ToString().PadLeft(2, ' ');

                case "CLMDTL_SV_DATE":
                    return Common.StringToField(F002_CLAIMS_MSTR_CLMDTL_SV_DATE().PadRight(8, ' '));

                case "CLMDTL_CONSEC_DATES":
                    return Common.StringToField(F002_CLAIMS_MSTR_CLMDTL_CONSEC_DATES().PadLeft(9, ' '));

                case "INDEXED.F002_CLAIMS_MSTR_DTL.CLMDTL_AMT_TECH_BILLED":
                    return rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_AMT_TECH_BILLED").ToString().PadLeft(6, ' ');

                case "INDEXED.F002_CLAIMS_MSTR_DTL.CLMDTL_FEE_OMA":
                    return rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_FEE_OMA").ToString().PadLeft(7, ' ');

                case "INDEXED.F002_CLAIMS_MSTR_DTL.CLMDTL_FEE_OHIP":
                    return rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_FEE_OHIP").ToString().PadLeft(7, ' ');

                case "INDEXED.F002_CLAIMS_MSTR_DTL.CLMDTL_DATE_PERIOD_END":
                    return Common.StringToField(rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_DATE_PERIOD_END").PadRight(8, ' '));

                case "INDEXED.F002_CLAIMS_MSTR_DTL.CLMDTL_DIAG_CD":
                    return rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_DIAG_CD").ToString().PadLeft(3, ' ');

                default:
                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_F002_CLAIMS_MSTR_DTL();

                while (rdrF002_CLAIMS_MSTR_DTL.Read())
                {
                    WriteData();
                }

                rdrF002_CLAIMS_MSTR_DTL.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrF002_CLAIMS_MSTR_DTL != null))
            {
                rdrF002_CLAIMS_MSTR_DTL.Close();
                rdrF002_CLAIMS_MSTR_DTL = null;
            }
        }


        #endregion

        #endregion
    }
}
