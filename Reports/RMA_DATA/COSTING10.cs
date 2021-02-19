//  Program: costing10.qzs
//  Purpose : final printout of costing information gathered by programs
//  costing1.qts --> costing7.qts
//  DATE       BY WHOM   DESCRIPTION
//  99/05/28   M. Chan   cloned from  costing1.qzs - added additional counters
//  that can be use to calculate number of months active
//  during the current year. This can be used to factor
//  up the doctor results for a full year when determining
//  a budget for next year.
//  02/07/23 B.E. - added x-billing-source column and derivation
//  - added column headings into output file for documentation 
//  purposes
//  2003/dec/11 A.A. - alpha doctor nbr
//  2015/Jul/16 MC1 - change the definition for x-billing-source & comment out linkage to f072
//  MC1
//  link client-id                                   &
//  to client-id of f072-client-mstr       opt   &
//  !    to tmp-counter-key  of tmp-counters 
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
    public class COSTING10 : BaseRDLClass
    {
        protected const string REPORT_NAME = "COSTING10";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrCOSTING2 = new Reader();
        private Reader rdrF020_DOCTOR_MSTR = new Reader();
        private Reader rdrF073_CLIENT_DOC_MSTR = new Reader();
        private Reader rdrTMP_COUNTERS_ALPHA = new Reader();
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
        private void Link_F073_CLIENT_DOC_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("CLIENT_ID ");
            strSQL.Append("FROM INDEXED.F073_CLIENT_DOC_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_NBR = ").Append(Common.StringToField(rdrCOSTING2.GetString("DOC_NBR")));
            rdrF073_CLIENT_DOC_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_TMP_COUNTERS_ALPHA()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("TMP_COUNTER_KEY_ALPHA, ");
            strSQL.Append("TMP_COUNTER_3, ");
            strSQL.Append("TMP_COUNTER_4, ");
            strSQL.Append("TMP_COUNTER_5 ");
            strSQL.Append("FROM INDEXED.TMP_COUNTERS_ALPHA ");
            strSQL.Append("WHERE ");
            strSQL.Append("TMP_COUNTER_KEY_ALPHA = ").Append(Common.StringToField(rdrCOSTING2.GetString("DOC_NBR")));
            rdrTMP_COUNTERS_ALPHA.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
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

        private string X_BILLING_SOURCE()
        {
            string strReturnValue = String.Empty;
            try
            {
                if ((QDesign.NULL(rdrF073_CLIENT_DOC_MSTR.GetString("CLIENT_ID")) == "WEB"))
                {
                    strReturnValue = "W";
                }
                else if ((QDesign.NULL(rdrF073_CLIENT_DOC_MSTR.GetString("CLIENT_ID")) == "DISK"))
                {
                    strReturnValue = "D";
                }
                else
                {
                    strReturnValue = " ";
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_COMMA()
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
                AddControl(ReportSection.INITIAL_HEADING, "X_COMA", DataTypes.Character, 1);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.COSTING2.DOC_NBR", DataTypes.Character, 3);
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
                AddControl(ReportSection.FOOTING_AT, "INDEXED.TMP_COUNTERS_ALPHA.TMP_COUNTER_3", DataTypes.Numeric, 10);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.TMP_COUNTERS_ALPHA.TMP_COUNTER_4", DataTypes.Numeric, 10);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.TMP_COUNTERS_ALPHA.TMP_COUNTER_5", DataTypes.Numeric, 10);
                AddControl(ReportSection.FOOTING_AT, "X_BILLING_SOURCE", DataTypes.Character, 1);
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
                case "X_COMA":
                    return Common.StringToField(X_COMMA(), intSize);
                case "TEMPORARYDATA.COSTING2.DOC_NBR":
                    return Common.StringToField(rdrCOSTING2.GetString("DOC_NBR"));
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
                case "INDEXED.TMP_COUNTERS_ALPHA.TMP_COUNTER_3":
                    return (rdrTMP_COUNTERS_ALPHA.GetNumber("TMP_COUNTER_3")*100).ToString();
                case "INDEXED.TMP_COUNTERS_ALPHA.TMP_COUNTER_4":
                    return (rdrTMP_COUNTERS_ALPHA.GetNumber("TMP_COUNTER_4")*100).ToString();
                case "INDEXED.TMP_COUNTERS_ALPHA.TMP_COUNTER_5":
                    return (rdrTMP_COUNTERS_ALPHA.GetNumber("TMP_COUNTER_5")*100).ToString();
                case "X_BILLING_SOURCE":
                    return Common.StringToField(X_BILLING_SOURCE(), intSize);
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
                        Link_F073_CLIENT_DOC_MSTR();
                        while (rdrF073_CLIENT_DOC_MSTR.Read())
                        {
                            Link_TMP_COUNTERS_ALPHA();
                            while (rdrTMP_COUNTERS_ALPHA.Read())
                            {
                                WriteData();
                            }

                            rdrTMP_COUNTERS_ALPHA.Close();
                        }

                        rdrF073_CLIENT_DOC_MSTR.Close();
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

            if (!(rdrF073_CLIENT_DOC_MSTR == null))
            {
                rdrF073_CLIENT_DOC_MSTR.Close();
                rdrF073_CLIENT_DOC_MSTR = null;
            }

            if (!(rdrTMP_COUNTERS_ALPHA == null))
            {
                rdrTMP_COUNTERS_ALPHA.Close();
                rdrTMP_COUNTERS_ALPHA = null;
            }
        }
    }
}
