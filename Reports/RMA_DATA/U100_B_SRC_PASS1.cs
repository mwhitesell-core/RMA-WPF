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
    public class U100_B_SRC_PASS1 : BaseRDLClass
    {
        #region "Screen Comments"

        // 2014/Sep/23  MC - check  primary doctor (u100_b.qzs)
        // - to be run as last part of $cmd/verify_payroll_ok_to_run
        // - user is asked to pass 2 parameters, user should change the terminated date cutoff once after yearend
        // 2014/Oct/9   yas      - If doc has only one number and have primary flag set then do not print on this report
        // We need the primary number so that system will calculate the TITHE for the doctor 
        // 2014/Oct/14 MC1 - include doctor name in subfile/report
        // - include constants-mstr-rec-7 in the access to extract previous fiscal yearend date
        // 2014/Oct/23 MC2 - include doctor sub specialty cd     
        // 2016/Feb/23   MC3     - change select statment for unique doctor check
        // MC1 

        #endregion

        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "U100_B__PASS1";

        protected const bool REPORT_HAS_PARAMETERS = true;

        // Data Helpers.
        private Reader rdrDATA = new Reader();

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
                SubFileName = "U100_B";
                SubFileType = SubFileType.Keep;
                SubFileAT = "";

                Sort = "DOC_OHIP_NBR ASC";

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

        private void Access_Data()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT DOC_OHIP_NBR, F020.DOC_NBR, DOC_DEPT, DOC_AFP_PAYM_GROUP, DOC_FLAG_PRIMARY, DOC_DATE_FAC_START_YY, DOC_DATE_FAC_START_MM, DOC_DATE_FAC_START_DD, DOC_DATE_FAC_TERM_YY, ");
            strSQL.Append("DOC_DATE_FAC_TERM_MM, DOC_DATE_FAC_TERM_DD, DOC_NAME, PREVIOUS_FISCAL_END_YYMMDD, DOC_SUB_SPECIALTY ");
            strSQL.Append("FROM INDEXED.F020_DOCTOR_MSTR F020 ");
            strSQL.Append("LEFT OUTER JOIN INDEXED.F020_DOCTOR_EXTRA F020_DE ON F020.DOC_NBR = F020_DE.DOC_NBR ");
            strSQL.Append("INNER JOIN INDEXED.CONSTANTS_MSTR_REC_7 ON CONST_REC_NBR = 7 ");
            strSQL.Append("WHERE ");
            strSQL.Append("(((DOC_DATE_FAC_TERM_YY * 10000) + (DOC_DATE_FAC_TERM_MM * 100) + DOC_DATE_FAC_TERM_MM) = 0 ");
            strSQL.Append("OR ((DOC_DATE_FAC_TERM_YY * 10000) + (DOC_DATE_FAC_TERM_MM * 100) + DOC_DATE_FAC_TERM_MM) > PREVIOUS_FISCAL_END_YYMMDD) ");
            strSQL.Append("AND ");
            strSQL.Append("((((DOC_DEPT = 4) ");
            strSQL.Append("OR (DOC_DEPT = 42) ");
            strSQL.Append("OR ((DOC_DEPT = 14 ");
            strSQL.Append("OR DOC_DEPT = 15) ");
            strSQL.Append("AND DOC_AFP_PAYM_GROUP = 'H111')) ");
            strSQL.Append("AND ").Append(Common.StringToField(PAYROLL_FLAG())).Append(" = 'A') ");
            strSQL.Append("OR ((DOC_DEPT = 31 ");
            strSQL.Append("AND DOC_AFP_PAYM_GROUP = 'H132') ");
            strSQL.Append("AND ").Append(Common.StringToField(PAYROLL_FLAG())).Append(" = 'C')) ");
            strSQL.Append("ORDER BY DOC_OHIP_NBR");

            rdrDATA.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

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
        private string PAYROLL_FLAG()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.NULL(ReportFunctions.astrScreenParameters[0].ToString()); // Prompt String: "Enter Payroll (A = 101c, & = solo): "
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private decimal DOC_DATE_FAC_START()
        {
            decimal decReturnValue = 0;

            try
            {
                decReturnValue = QDesign.NConvert(rdrDATA.GetNumber("DOC_DATE_FAC_START_YY").ToString() + rdrDATA.GetNumber("DOC_DATE_FAC_START_MM").ToString().PadLeft(2, '0') + rdrDATA.GetNumber("DOC_DATE_FAC_START_DD").ToString().PadLeft(2, '0'));
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
            return decReturnValue;
        }

        private decimal DOC_DATE_FAC_TERM()
        {

            decimal decReturnValue = 0;

            try
            {
                decReturnValue = QDesign.NConvert(rdrDATA.GetNumber("DOC_DATE_FAC_TERM_YY").ToString() + rdrDATA.GetNumber("DOC_DATE_FAC_TERM_MM").ToString().PadLeft(2, '0') + rdrDATA.GetNumber("DOC_DATE_FAC_TERM_DD").ToString().PadLeft(2, '0'));
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
                AddControl(ReportSection.SUMMARY, "INDEXED.F020_DOCTOR_MSTR.DOC_OHIP_NBR", DataTypes.Numeric, 6);
                AddControl(ReportSection.SUMMARY, "INDEXED.F020_DOCTOR_MSTR.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.SUMMARY, "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT", DataTypes.Numeric, 2);
                AddControl(ReportSection.SUMMARY, "INDEXED.F020_DOCTOR_MSTR.DOC_AFP_PAYM_GROUP", DataTypes.Character, 4);
                AddControl(ReportSection.SUMMARY, "INDEXED.F020_DOCTOR_EXTRA.DOC_FLAG_PRIMARY", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "DOC_DATE_FAC_START", DataTypes.Numeric, 8);
                AddControl(ReportSection.SUMMARY, "DOC_DATE_FAC_TERM", DataTypes.Numeric, 8);
                AddControl(ReportSection.SUMMARY, "PAYROLL_FLAG", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "INDEXED.F020_DOCTOR_MSTR.DOC_NAME", DataTypes.Character, 24);
                AddControl(ReportSection.SUMMARY, "INDEXED.CONSTANTS_MSTR_REC_7.PREVIOUS_FISCAL_END_YYMMDD", DataTypes.Numeric, 8);
                AddControl(ReportSection.SUMMARY, "INDEXED.F020_DOCTOR_MSTR.DOC_SUB_SPECIALTY", DataTypes.Character, 15);
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
        //# Do not delete, modify or move it.  Updated: 6/7/2017 11:45:00 AM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "INDEXED.F020_DOCTOR_MSTR.DOC_OHIP_NBR":
                    return rdrDATA.GetNumber("DOC_OHIP_NBR").ToString().PadRight(6, ' ');

                case "INDEXED.F020_DOCTOR_MSTR.DOC_NBR":
                    return Common.StringToField(rdrDATA.GetString("DOC_NBR")).PadRight(3, ' ');

                case "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT":
                    return rdrDATA.GetNumber("DOC_DEPT").ToString().PadRight(2, ' ');

                case "INDEXED.F020_DOCTOR_MSTR.DOC_AFP_PAYM_GROUP":
                    return Common.StringToField(rdrDATA.GetString("DOC_AFP_PAYM_GROUP")).PadRight(4, ' ');

                case "INDEXED.F020_DOCTOR_EXTRA.DOC_FLAG_PRIMARY":
                    return Common.StringToField(rdrDATA.GetString("DOC_FLAG_PRIMARY")).PadRight(1, ' ');

                case "DOC_DATE_FAC_START":
                    return DOC_DATE_FAC_START().ToString().PadRight(8, ' ');

                case "DOC_DATE_FAC_TERM":
                    return DOC_DATE_FAC_TERM().ToString().PadRight(8, ' ');

                case "PAYROLL_FLAG":
                    return Common.StringToField(PAYROLL_FLAG()).PadRight(1, ' ');

                case "INDEXED.F020_DOCTOR_MSTR.DOC_NAME":
                    return Common.StringToField(rdrDATA.GetString("DOC_NAME")).PadRight(24, ' ');

                case "INDEXED.CONSTANTS_MSTR_REC_7.PREVIOUS_FISCAL_END_YYMMDD":
                    return rdrDATA.GetNumber("PREVIOUS_FISCAL_END_YYMMDD").ToString().PadRight(8, ' ');

                case "INDEXED.F020_DOCTOR_MSTR.DOC_SUB_SPECIALTY":
                    return Common.StringToField(rdrDATA.GetString("DOC_SUB_SPECIALTY")).PadRight(15, ' ');

                default:
                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_Data();

                while (rdrDATA.Read())
                {
                    WriteData();
                }
                rdrDATA.Close();

            }
            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrDATA != null))
            {
                rdrDATA.Close();
                rdrDATA = null;
            }
        }

        #endregion
    }
}
