#region "Screen Comments"

// doc     : r997_total.qzs  
// purpose : Create a total page record amount paid and submitted 
// separated by RMA and RMA INC.
// Date           Who             Description
// 2003/03/06     Yasemin         Original
// 2004/06/03 M.C.  alpha doc nbr
// !  link ( `B`, nconvert(rat-145-group-nbr[1:2] + `0`             &

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
    public class R997_TOTAL : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R997_TOTAL";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrU030_TAPE_145_FILE = new Reader();
        private Reader rdrF002_CLAIMS_MSTR = new Reader();
        private Reader rdrF070_DEPT_MSTR = new Reader();

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

        private void Access_U030_TAPE_145_FILE()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("RAT_145_GROUP_NBR, ");
            strSQL.Append("RAT_145_ACCOUNT_NBR, ");
            strSQL.Append("RAT_145_PAY_PROG, ");
            strSQL.Append("RAT_145_AMT_PAID, ");
            strSQL.Append("RAT_145_AMOUNT_SUB ");
            strSQL.Append("FROM SEQUENTIAL.U030_TAPE_145_FILE ");

            strSQL.Append(Choose());

            rdrU030_TAPE_145_FILE.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.m_strFlatFileDictionary, ReportFunctions.TextFiles);

            strSQL = null;
        }

        private void Link_F002_CLAIMS_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("KEY_CLM_TYPE, ");
            strSQL.Append("KEY_CLM_BATCH_NBR, ");
            strSQL.Append("KEY_CLM_CLAIM_NBR, ");
            strSQL.Append("KEY_CLM_SERV_CODE, ");
            strSQL.Append("KEY_CLM_ADJ_NBR, ");
            strSQL.Append("CLMHDR_DOC_DEPT ");
            strSQL.Append("FROM INDEXED.F002_CLAIMS_MSTR_HDR ");
            strSQL.Append("WHERE ");
            strSQL.Append("KEY_CLM_TYPE = ").Append(Common.StringToField("B"));
            strSQL.Append(" AND KEY_CLM_BATCH_NBR = ").Append(Common.StringToField(QDesign.Substring(rdrU030_TAPE_145_FILE.GetString("RAT_145_GROUP_NBR"), 1, 2) + QDesign.Substring(rdrU030_TAPE_145_FILE.GetString("RAT_145_ACCOUNT_NBR"), 1, 6)));
            strSQL.Append(" AND KEY_CLM_CLAIM_NBR = ").Append(QDesign.NConvert(QDesign.Substring(rdrU030_TAPE_145_FILE.GetString("RAT_145_ACCOUNT_NBR"), 7, 2)));
            strSQL.Append(" AND KEY_CLM_SERV_CODE = ").Append(Common.StringToField("00000"));
            strSQL.Append(" AND KEY_CLM_ADJ_NBR = ").Append(Common.StringToField("0"));

            rdrF002_CLAIMS_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

            strSQL = null;
        }

        private void Link_F070_DEPT_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DEPT_NBR, ");
            strSQL.Append("DEPT_COMPANY ");
            strSQL.Append("FROM [101C].INDEXED.F070_DEPT_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DEPT_NBR = ").Append(rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_DOC_DEPT"));

            rdrF070_DEPT_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

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

        private decimal X_RMA_PAID()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrF070_DEPT_MSTR.GetNumber("DEPT_COMPANY")) == QDesign.NULL(1d) & QDesign.NULL(rdrU030_TAPE_145_FILE.GetString("RAT_145_PAY_PROG")) == QDesign.NULL("HCP"))
                {
                    decReturnValue = rdrU030_TAPE_145_FILE.GetNumber("RAT_145_AMT_PAID");
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private decimal X_RMA_SUB()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrF070_DEPT_MSTR.GetNumber("DEPT_COMPANY")) == QDesign.NULL(1d) & QDesign.NULL(rdrU030_TAPE_145_FILE.GetString("RAT_145_PAY_PROG")) == QDesign.NULL("HCP"))
                {
                    decReturnValue = rdrU030_TAPE_145_FILE.GetNumber("RAT_145_AMOUNT_SUB");
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private decimal X_INC_PAID()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrF070_DEPT_MSTR.GetNumber("DEPT_COMPANY")) == QDesign.NULL(2d) & QDesign.NULL(rdrU030_TAPE_145_FILE.GetString("RAT_145_PAY_PROG")) == QDesign.NULL("HCP"))
                {
                    decReturnValue = rdrU030_TAPE_145_FILE.GetNumber("RAT_145_AMT_PAID");
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private decimal X_INC_SUB()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrF070_DEPT_MSTR.GetNumber("DEPT_COMPANY")) == QDesign.NULL(2d) & QDesign.NULL(rdrU030_TAPE_145_FILE.GetString("RAT_145_PAY_PROG")) == QDesign.NULL("HCP"))
                {
                    decReturnValue = rdrU030_TAPE_145_FILE.GetNumber("RAT_145_AMOUNT_SUB");
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private decimal X_RMB_RMA_PAID()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrF070_DEPT_MSTR.GetNumber("DEPT_COMPANY")) == QDesign.NULL(1d) & QDesign.NULL(rdrU030_TAPE_145_FILE.GetString("RAT_145_PAY_PROG")) == QDesign.NULL("RMB"))
                {
                    decReturnValue = rdrU030_TAPE_145_FILE.GetNumber("RAT_145_AMT_PAID");
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private decimal X_RMB_RMA_SUB()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrF070_DEPT_MSTR.GetNumber("DEPT_COMPANY")) == QDesign.NULL(1d) & QDesign.NULL(rdrU030_TAPE_145_FILE.GetString("RAT_145_PAY_PROG")) == QDesign.NULL("RMB"))
                {
                    decReturnValue = rdrU030_TAPE_145_FILE.GetNumber("RAT_145_AMOUNT_SUB");
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private decimal X_RMB_INC_PAID()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrF070_DEPT_MSTR.GetNumber("DEPT_COMPANY")) == QDesign.NULL(2d) & QDesign.NULL(rdrU030_TAPE_145_FILE.GetString("RAT_145_PAY_PROG")) == QDesign.NULL("RMB"))
                {
                    decReturnValue = rdrU030_TAPE_145_FILE.GetNumber("RAT_145_AMT_PAID");
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private decimal X_RMB_INC_SUB()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrF070_DEPT_MSTR.GetNumber("DEPT_COMPANY")) == QDesign.NULL(2d) & QDesign.NULL(rdrU030_TAPE_145_FILE.GetString("RAT_145_PAY_PROG")) == QDesign.NULL("RMB"))
                {
                    decReturnValue = rdrU030_TAPE_145_FILE.GetNumber("RAT_145_AMOUNT_SUB");
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
                AddControl(ReportSection.FINAL_FOOTING, "X_RMA_SUB", DataTypes.Numeric, 8);
                AddControl(ReportSection.FINAL_FOOTING, "X_RMB_RMA_SUB", DataTypes.Numeric, 8);
                AddControl(ReportSection.FINAL_FOOTING, "X_INC_SUB", DataTypes.Numeric, 8);
                AddControl(ReportSection.FINAL_FOOTING, "X_RMB_INC_SUB", DataTypes.Numeric, 8);
                AddControl(ReportSection.FINAL_FOOTING, "X_RMA_PAID", DataTypes.Numeric, 8);
                AddControl(ReportSection.FINAL_FOOTING, "X_RMB_RMA_PAID", DataTypes.Numeric, 8);
                AddControl(ReportSection.FINAL_FOOTING, "X_INC_PAID", DataTypes.Numeric, 8);
                AddControl(ReportSection.FINAL_FOOTING, "X_RMB_INC_PAID", DataTypes.Numeric, 8);
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
        //# Do not delete, modify or move it.  Updated: 9/28/2017 1:46:59 PM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "X_RMA_SUB":
                    return X_RMA_SUB().ToString().ToString().PadLeft(8, ' ');

                case "X_RMB_RMA_SUB":
                    return X_RMB_RMA_SUB().ToString().ToString().PadLeft(8, ' ');

                case "X_INC_SUB":
                    return X_INC_SUB().ToString().ToString().PadLeft(8, ' ');

                case "X_RMB_INC_SUB":
                    return X_RMB_INC_SUB().ToString().ToString().PadLeft(8, ' ');

                case "X_RMA_PAID":
                    return X_RMA_PAID().ToString().ToString().PadLeft(8, ' ');

                case "X_RMB_RMA_PAID":
                    return X_RMB_RMA_PAID().ToString().ToString().PadLeft(8, ' ');

                case "X_INC_PAID":
                    return X_INC_PAID().ToString().ToString().PadLeft(8, ' ');

                case "X_RMB_INC_PAID":
                    return X_RMB_INC_PAID().ToString().ToString().PadLeft(8, ' ');

                default:

                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_U030_TAPE_145_FILE();

                while (rdrU030_TAPE_145_FILE.Read())
                {
                    Link_F002_CLAIMS_MSTR();
                    while (rdrF002_CLAIMS_MSTR.Read())
                    {
                        Link_F070_DEPT_MSTR();
                        while ((rdrF070_DEPT_MSTR.Read()))
                        {
                            WriteData();
                        }
                        rdrF070_DEPT_MSTR.Close();
                    }
                    rdrF002_CLAIMS_MSTR.Close();
                }
                rdrU030_TAPE_145_FILE.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrU030_TAPE_145_FILE != null))
            {
                rdrU030_TAPE_145_FILE.Close();
                rdrU030_TAPE_145_FILE = null;
            }
            if ((rdrF002_CLAIMS_MSTR != null))
            {
                rdrF002_CLAIMS_MSTR.Close();
                rdrF002_CLAIMS_MSTR = null;
            }
            if ((rdrF070_DEPT_MSTR != null))
            {
                rdrF070_DEPT_MSTR.Close();
                rdrF070_DEPT_MSTR = null;
            }
        }


        #endregion

        #endregion
    }
}
