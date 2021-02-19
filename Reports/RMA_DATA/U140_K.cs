#region "Screen Comments"

// Program: u140_k.qzs
// Purpose: Generate grand total report (for Kevin S.) and individual
// department reports for the payments to doctors from the 
// MOH EFT file for Conversion payments
// This is the 1st phase that gathers the `R`eporting only group doctors
// and adds them to the `E`arnings group doctors already in u140_d1
// 2004/jul/01 b.e. - original
// 2004/aug/12 b.e. - access f075 and use calcualted amounts rather than the base amounts in the a2s file
// 2004/sep/14 b.e. - changed length of report from 60 to 50 so that when
// report is imported into Word to be emailed that pages
// fit within Word`s default page length
// 2004/oct/16 b.e. - added afp-submit-amt to printout
// 2004/dec/02 b.e. - changed from report program to just gather data
// in subfile
// 2004/dec/20 b.e. - prdecimal doctor even if zero payment amount
// 2005/jan/14 b.e. - don`t select unless found on this months MOH file a
// which is signified by the date field being setup
// to the current process month
// 2005/mar/08 M.C. - substitute afp-payment-percentage with afp-multi-doc-ra-percentage
// 2007/jul/11 b.e. - field afp-payment-amt was mistakenly put into
// subfile (taken from f074) rather 
// than afp-conversion-amt(from a2s file). Fix made.
// set report dev disc name r140_b
// use $use/r140_b.use 

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
    public class U140_K : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "U140_K";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrAFP_A2S_FILE = new Reader();
        private Reader rdrF074_AFP_GROUP_MSTR = new Reader();
        private Reader rdrU140_D1 = new Reader();

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
                SubFileName = "U140_D1";
                SubFileType = SubFileType.Keep;
                SubFileAppend = true;
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

        private void Access_AFP_A2S_FILE()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_AFP_PAYM_GROUP, ");
            strSQL.Append("AFP_SOLO_NAME, ");
            strSQL.Append("AFP_CONVERSION_SIGN, ");
            strSQL.Append("AFP_CONVERSION_AMT, ");
            strSQL.Append("AFP_SUBMISSION_SIGN, ");
            strSQL.Append("AFP_SUBMISSION_AMT, ");
            strSQL.Append("AFP_TRANSACTION_ID, ");
            strSQL.Append("AFP_RECORD_ID, ");
            strSQL.Append("DOC_AFP_PAYM_SOLO, ");
            strSQL.Append("AFP_PAYMENT_PERCENTAGE ");
            strSQL.Append("FROM SEQUENTIAL.AFP_A2S_FILE ");

            strSQL.Append(Choose());

            rdrAFP_A2S_FILE.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.m_strFlatFileDictionary, ReportFunctions.TextFiles);

            strSQL = null;
        }

        private void Link_F074_AFP_GROUP_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_AFP_PAYM_GROUP, ");
            strSQL.Append("AFP_GROUP_PROCESS_FLAG, ");
            strSQL.Append("AFP_GROUP_NAME, ");
            strSQL.Append("AFP_MULTI_DOC_RA_PERCENTAGE, ");
            strSQL.Append("AFP_REPORTING_MTH ");
            strSQL.Append("FROM [101C].INDEXED.F074_AFP_GROUP_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_AFP_PAYM_GROUP = ").Append(Common.StringToField(rdrAFP_A2S_FILE.GetString("DOC_AFP_PAYM_GROUP")));

            rdrF074_AFP_GROUP_MSTR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

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

            if (QDesign.NULL(rdrF074_AFP_GROUP_MSTR.GetString("AFP_GROUP_PROCESS_FLAG")) == QDesign.NULL("R"))
            {
                blnSelected = true;
            }

            return blnSelected;
        }

        #endregion

        #region " DEFINES "

        private string DOC_NBR()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = "000";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_DOC_NAME()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.Pack(rdrAFP_A2S_FILE.GetString("AFP_SOLO_NAME"));
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private decimal DEPT_NBR()
        {
            decimal decReturnValue = 0;

            try
            {
                decReturnValue = 0;
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private string DEPT_NAME()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = "Non-RMA doctor - No Department";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private decimal DOC_DATE_FAC_TERM()
        {
            decimal decReturnValue = 0;

            try
            {
                decReturnValue = 0;
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private decimal X_CONVERSION_AMT()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrAFP_A2S_FILE.GetString("AFP_CONVERSION_SIGN")) == QDesign.NULL(" "))
                {
                    decReturnValue = rdrAFP_A2S_FILE.GetNumber("AFP_CONVERSION_AMT");
                }
                else
                {
                    decReturnValue = 0 - rdrAFP_A2S_FILE.GetNumber("AFP_CONVERSION_AMT");
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private decimal X_SUBMISSION_AMT()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrAFP_A2S_FILE.GetString("AFP_SUBMISSION_SIGN")) == QDesign.NULL(" "))
                {
                    decReturnValue = rdrAFP_A2S_FILE.GetNumber("AFP_SUBMISSION_AMT");
                }
                else
                {
                    decReturnValue = 0 - rdrAFP_A2S_FILE.GetNumber("AFP_SUBMISSION_AMT");
                }
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
                AddControl(ReportSection.SUMMARY, "SEQUENTIAL.AFP_A2S_FILE.AFP_TRANSACTION_ID", DataTypes.Character, 2);
                AddControl(ReportSection.SUMMARY, "SEQUENTIAL.AFP_A2S_FILE.AFP_RECORD_ID", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "SEQUENTIAL.AFP_A2S_FILE.DOC_AFP_PAYM_GROUP", DataTypes.Character, 4);
                AddControl(ReportSection.SUMMARY, "INDEXED.F074_AFP_GROUP_MSTR.AFP_GROUP_NAME", DataTypes.Character, 75);
                AddControl(ReportSection.SUMMARY, "INDEXED.F074_AFP_GROUP_MSTR.AFP_MULTI_DOC_RA_PERCENTAGE", DataTypes.Numeric, 6);
                AddControl(ReportSection.SUMMARY, "SEQUENTIAL.AFP_A2S_FILE.DOC_AFP_PAYM_SOLO", DataTypes.Character, 6);
                AddControl(ReportSection.SUMMARY, "DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.SUMMARY, "SEQUENTIAL.AFP_A2S_FILE.AFP_SOLO_NAME", DataTypes.Character, 75);
                AddControl(ReportSection.SUMMARY, "X_DOC_NAME", DataTypes.Character, 35);
                AddControl(ReportSection.SUMMARY, "DEPT_NBR", DataTypes.Numeric, 2);
                AddControl(ReportSection.SUMMARY, "DEPT_NAME", DataTypes.Character, 30);                
                AddControl(ReportSection.SUMMARY, "SEQUENTIAL.AFP_A2S_FILE.AFP_PAYMENT_PERCENTAGE", DataTypes.Numeric, 5);
                AddControl(ReportSection.SUMMARY, "SEQUENTIAL.AFP_A2S_FILE.AFP_CONVERSION_AMT", DataTypes.Numeric, 11);
                AddControl(ReportSection.SUMMARY, "SEQUENTIAL.AFP_A2S_FILE.AFP_SUBMISSION_AMT", DataTypes.Numeric, 11);
                AddControl(ReportSection.SUMMARY, "X_CONVERSION_AMT", DataTypes.Numeric, 11);
                AddControl(ReportSection.SUMMARY, "X_SUBMISSION_AMT", DataTypes.Numeric, 11);
                AddControl(ReportSection.SUMMARY, "INDEXED.F074_AFP_GROUP_MSTR.AFP_GROUP_PROCESS_FLAG", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "DOC_DATE_FAC_TERM", DataTypes.Numeric, 8);
                AddControl(ReportSection.SUMMARY, "INDEXED.F074_AFP_GROUP_MSTR.AFP_REPORTING_MTH", DataTypes.Character, 6);
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
        //# Do not delete, modify or move it.  Updated: 10/10/2017 1:53:38 PM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "SEQUENTIAL.AFP_A2S_FILE.AFP_TRANSACTION_ID":
                    return Common.StringToField(rdrAFP_A2S_FILE.GetString("AFP_TRANSACTION_ID").PadRight(2, ' '));

                case "SEQUENTIAL.AFP_A2S_FILE.AFP_RECORD_ID":
                    return Common.StringToField(rdrAFP_A2S_FILE.GetString("AFP_RECORD_ID").PadRight(1, ' '));

                case "SEQUENTIAL.AFP_A2S_FILE.DOC_AFP_PAYM_GROUP":
                    return Common.StringToField(rdrAFP_A2S_FILE.GetString("DOC_AFP_PAYM_GROUP").PadRight(4, ' '));

                case "INDEXED.F074_AFP_GROUP_MSTR.AFP_GROUP_NAME":
                    return Common.StringToField(rdrF074_AFP_GROUP_MSTR.GetString("AFP_GROUP_NAME").PadRight(75, ' '));

                case "INDEXED.F074_AFP_GROUP_MSTR.AFP_MULTI_DOC_RA_PERCENTAGE":
                    return rdrF074_AFP_GROUP_MSTR.GetNumber("AFP_MULTI_DOC_RA_PERCENTAGE").ToString().PadLeft(6, ' ');

                case "SEQUENTIAL.AFP_A2S_FILE.DOC_AFP_PAYM_SOLO":
                    return Common.StringToField(rdrAFP_A2S_FILE.GetString("DOC_AFP_PAYM_SOLO").PadRight(6, ' '));

                case "DOC_NBR":
                    return Common.StringToField(DOC_NBR().PadRight(3, ' '));

                case "SEQUENTIAL.AFP_A2S_FILE.AFP_SOLO_NAME":
                    return Common.StringToField(rdrAFP_A2S_FILE.GetString("AFP_SOLO_NAME").PadRight(75, ' '));

                case "X_DOC_NAME":
                    return Common.StringToField(X_DOC_NAME().PadRight(35, ' '));

                case "DEPT_NBR":
                    return DEPT_NBR().ToString().ToString().PadLeft(2, ' ');

                case "DEPT_NAME":
                    return Common.StringToField(DEPT_NAME().PadRight(30, ' '));

                case "SEQUENTIAL.AFP_A2S_FILE.AFP_PAYMENT_PERCENTAGE":
                    return rdrAFP_A2S_FILE.GetNumber("AFP_PAYMENT_PERCENTAGE").ToString().PadLeft(5, ' ');

                case "SEQUENTIAL.AFP_A2S_FILE.AFP_CONVERSION_AMT":
                    return rdrAFP_A2S_FILE.GetNumber("AFP_CONVERSION_AMT").ToString().PadLeft(11, ' ');

                case "SEQUENTIAL.AFP_A2S_FILE.AFP_SUBMISSION_AMT":
                    return rdrAFP_A2S_FILE.GetNumber("AFP_SUBMISSION_AMT").ToString().PadLeft(11, ' ');

                case "X_CONVERSION_AMT":
                    return X_CONVERSION_AMT().ToString().PadLeft(11, ' ');

                case "X_SUBMISSION_AMT":
                    return X_SUBMISSION_AMT().ToString().PadLeft(11, ' ');

                case "INDEXED.F074_AFP_GROUP_MSTR.AFP_GROUP_PROCESS_FLAG":
                    return Common.StringToField(rdrF074_AFP_GROUP_MSTR.GetString("AFP_GROUP_PROCESS_FLAG").PadRight(1, ' '));

                case "DOC_DATE_FAC_TERM":
                    return DOC_DATE_FAC_TERM().ToString().PadLeft(8, ' ');

                case "INDEXED.F074_AFP_GROUP_MSTR.AFP_REPORTING_MTH":
                    return Common.StringToField(rdrF074_AFP_GROUP_MSTR.GetString("AFP_REPORTING_MTH").PadRight(6, ' '));

                default:

                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_AFP_A2S_FILE();

                while (rdrAFP_A2S_FILE.Read())
                {
                    Link_F074_AFP_GROUP_MSTR();
                    while (rdrF074_AFP_GROUP_MSTR.Read())
                    {
                        WriteData();
                    }
                    rdrF074_AFP_GROUP_MSTR.Close();
                }
                rdrAFP_A2S_FILE.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrAFP_A2S_FILE != null))
            {
                rdrAFP_A2S_FILE.Close();
                rdrAFP_A2S_FILE = null;
            }
            if ((rdrF074_AFP_GROUP_MSTR != null))
            {
                rdrF074_AFP_GROUP_MSTR.Close();
                rdrF074_AFP_GROUP_MSTR = null;
            }
        }


        #endregion

        #endregion
    }
}
