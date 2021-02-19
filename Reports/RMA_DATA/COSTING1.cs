//  Program: costing1.qzs
//  Purpose : final printout of costing information gathered by programs
//  costing1.qts --> costing7.qts
//  DATE       BY WHOM   DESCRIPTION
//  99/05/28   M. Chan   ORIGINAL
//  99/06/02   M. Chan   extend the size for nbr-svc, nbr-dtl, nbr-clm from 4 to 6
//  99/06/08   M. Chan   include a new column man reject 
//  2003/dec/11 A.A. - alpha doctor nbr
using Core.DataAccess.SqlServer;
using Core.DataAccess.TextFile;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.ReportFramework;
using System;
using System.Data;
using System.Text;
namespace RMA_DATA
{
    public class COSTING1 : BaseRDLClass
    {
        protected const string REPORT_NAME = "COSTING1";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrCOSTING2 = new Reader();
        private Reader rdrF020_DOCTOR_MSTR = new Reader();
        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                //  Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;
                Sort = "DOC_NBR ASC";
                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return ReportData;
        }
        private void Access_COSTING2()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: If * is not used to select all columns, ensure the necessary columns (i.e. columns that are used to access records of other tables) are included in the SELECT statement
            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("DOC_NAME, ");
            strSQL.Append("DOC_INITS, ");
            strSQL.Append("DOC_DEPT, ");
            strSQL.Append("DOC_CLINIC_NBR, ");
            strSQL.Append("NBR_SVC, ");
            strSQL.Append("NBR_CLM, ");
            strSQL.Append("NBR_DTL, ");
            strSQL.Append("NBR_REJECT, ");
            strSQL.Append("MAN_REJECT, ");
            strSQL.Append("AMT_YTD, ");
            strSQL.Append("MISC_AMT_YTD, ");
            strSQL.Append("MOHR_AMT_YTD, ");
            strSQL.Append("TOTAL_AMT_YTD ");
            strSQL.Append("FROM TEMPORARYDATA.COSTING2 ");
            strSQL.Append(Choose());

            rdrCOSTING2.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_F020_DOCTOR_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("DOC_DATE_FAC_START_YY, ");
            strSQL.Append(" DOC_DATE_FAC_START_MM, ");
            strSQL.Append(" DOC_DATE_FAC_START_DD, ");
            strSQL.Append("DOC_DATE_FAC_TERM_YY, ");
            strSQL.Append(" DOC_DATE_FAC_TERM_MM, ");
            strSQL.Append(" DOC_DATE_FAC_TERM_DD, ");
            strSQL.Append("DOC_FULL_PART_IND ");
            strSQL.Append("FROM INDEXED.F020_DOCTOR_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_NBR = ").Append(Common.StringToField(rdrCOSTING2.GetString("DOC_NBR")));
            rdrF020_DOCTOR_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(String.Empty);
            // TODO: CHOOSE Statement - May require manual changes.
            return strChoose.ToString().ToString();
        }

        private string X_START()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = QDesign.ASCII(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DATE_FAC_START_YY"), 4) + QDesign.ASCII(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DATE_FAC_START_MM"), 2) + QDesign.ASCII(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DATE_FAC_START_DD"), 2);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_TERM()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = QDesign.ASCII(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DATE_FAC_TERM_YY"), 4) + QDesign.ASCII(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DATE_FAC_TERM_MM"), 2) + QDesign.ASCII(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DATE_FAC_TERM_DD"), 2);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_COMA()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = ",";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.COSTING2.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.FOOTING_AT, "X_COMA", DataTypes.Character, 1);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.COSTING2.DOC_NAME", DataTypes.Character, 24);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.COSTING2.DOC_INITS", DataTypes.Character, 3);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.COSTING2.DOC_DEPT", DataTypes.Numeric, 2);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.COSTING2.DOC_CLINIC_NBR", DataTypes.Numeric, 2);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F020_DOCTOR_MSTR.DOC_FULL_PART_IND", DataTypes.Character, 1);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.COSTING2.NBR_SVC", DataTypes.Numeric, 6);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.COSTING2.NBR_CLM", DataTypes.Numeric, 6);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.COSTING2.NBR_DTL", DataTypes.Numeric, 6);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.COSTING2.NBR_REJECT", DataTypes.Numeric, 4);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.COSTING2.MAN_REJECT", DataTypes.Numeric, 6);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.COSTING2.AMT_YTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.COSTING2.MISC_AMT_YTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.COSTING2.MOHR_AMT_YTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.COSTING2.TOTAL_AMT_YTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_START", DataTypes.Character, 8);
                AddControl(ReportSection.FOOTING_AT, "X_TERM", DataTypes.Character, 8);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2019-07-24 7:52:03 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "TEMPORARYDATA.COSTING2.DOC_NBR":
                    return Common.StringToField(rdrCOSTING2.GetString("DOC_NBR"));
                case "X_COMA":
                    return Common.StringToField(X_COMA(), intSize);
                case "TEMPORARYDATA.COSTING2.DOC_NAME":
                    return Common.StringToField(rdrCOSTING2.GetString("DOC_NAME"));
                case "TEMPORARYDATA.COSTING2.DOC_INITS":
                    return Common.StringToField(rdrCOSTING2.GetString("DOC_INITS"));
                case "TEMPORARYDATA.COSTING2.DOC_DEPT":
                    return rdrCOSTING2.GetNumber("DOC_DEPT").ToString();
                case "TEMPORARYDATA.COSTING2.DOC_CLINIC_NBR":
                    return rdrCOSTING2.GetNumber("DOC_CLINIC_NBR").ToString();
                case "INDEXED.F020_DOCTOR_MSTR.DOC_FULL_PART_IND":
                    return Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND"));
                case "TEMPORARYDATA.COSTING2.NBR_SVC":
                    return rdrCOSTING2.GetNumber("NBR_SVC").ToString();
                case "TEMPORARYDATA.COSTING2.NBR_CLM":
                    return rdrCOSTING2.GetNumber("NBR_CLM").ToString();
                case "TEMPORARYDATA.COSTING2.NBR_DTL":
                    return rdrCOSTING2.GetNumber("NBR_DTL").ToString();
                case "TEMPORARYDATA.COSTING2.NBR_REJECT":
                    return rdrCOSTING2.GetNumber("NBR_REJECT").ToString();
                case "TEMPORARYDATA.COSTING2.MAN_REJECT":
                    return rdrCOSTING2.GetNumber("MAN_REJECT").ToString();
                case "TEMPORARYDATA.COSTING2.AMT_YTD":
                    return rdrCOSTING2.GetNumber("AMT_YTD").ToString();
                case "TEMPORARYDATA.COSTING2.MISC_AMT_YTD":
                    return rdrCOSTING2.GetNumber("MISC_AMT_YTD").ToString();
                case "TEMPORARYDATA.COSTING2.MOHR_AMT_YTD":
                    return rdrCOSTING2.GetNumber("MOHR_AMT_YTD").ToString();
                case "TEMPORARYDATA.COSTING2.TOTAL_AMT_YTD":
                    return rdrCOSTING2.GetNumber("TOTAL_AMT_YTD").ToString();
                case "X_START":
                    return Common.StringToField(X_START(), intSize);
                case "X_TERM":
                    return Common.StringToField(X_TERM(), intSize);
                default:
                    return String.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                // TODO: Some manual steps maybe required.
                Access_COSTING2();
                while (rdrCOSTING2.Read())
                {
                    Link_F020_DOCTOR_MSTR();
                    while (rdrF020_DOCTOR_MSTR.Read())
                    {
                        WriteData();
                    }

                    rdrF020_DOCTOR_MSTR.Close();
                }

                rdrCOSTING2.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if (!(rdrCOSTING2 == null))
            {
                rdrCOSTING2.Close();
                rdrCOSTING2 = null;
            }

            if (!(rdrF020_DOCTOR_MSTR == null))
            {
                rdrF020_DOCTOR_MSTR.Close();
                rdrF020_DOCTOR_MSTR = null;
            }
        }
    }
}