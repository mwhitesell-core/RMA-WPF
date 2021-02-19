#region "Screen Comments"

// doc     : r997_paid.qzs  
// purpose : create total by doctor for afp clinics 91-95 and 82 
// if amount paid ne 0
// Date           Who             Description
// 2003/08/19     Yasemin         Original
// link rat-145-doc-nbr                         &
// link (nconvert(rat-145-account-nbr[1:3]))    & 

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
    public class R997_PAID : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R997_PAID";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrU030_TAPE_145_FILE = new Reader();
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

                Sort = "DOC_NBR ASC";

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

            strSQL.Append("SELECT * ");
            //strSQL.Append("RAT_145_ACCOUNT_NBR, ");
            //strSQL.Append("RAT_145_AMT_PAID, ");
            //strSQL.Append("RAT_145_PAY_PROG, ");
            //strSQL.Append("RAT_145_GROUP_NBR ");
            strSQL.Append("FROM SEQUENTIAL.U030_TAPE_145_FILE ");

            strSQL.Append(Choose());

            rdrU030_TAPE_145_FILE.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.m_strFlatFileDictionary, ReportFunctions.TextFiles);

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
            strSQL.Append("DOC_NBR = '").Append(rdrU030_TAPE_145_FILE.GetString("RAT_145_ACCOUNT_NBR").Substring(0, 3)).Append("'");

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

        #endregion

        #region " DEFINES "

        private decimal X_HCP()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrU030_TAPE_145_FILE.GetNumber("RAT_145_AMT_PAID")) != QDesign.NULL(0d) & QDesign.NULL(rdrU030_TAPE_145_FILE.GetString("RAT_145_PAY_PROG")) == QDesign.NULL("HCP"))
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
        private decimal X_RMB()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrU030_TAPE_145_FILE.GetNumber("RAT_145_AMT_PAID")) != QDesign.NULL(0d) & QDesign.NULL(rdrU030_TAPE_145_FILE.GetString("RAT_145_PAY_PROG")) == QDesign.NULL("RMB"))
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
        private string NAME()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.Pack(QDesign.Substring(rdrF020_DOCTOR_MSTR.GetString("DOC_NAME") + ", " + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT1") + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT2") + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT3"), 1, 20));
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string CLINIC()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.Substring(rdrU030_TAPE_145_FILE.GetString("RAT_145_GROUP_NBR"), 1, 2);
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
                AddControl(ReportSection.PAGE_HEADING, "CLINIC", DataTypes.Character, 2);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F020_DOCTOR_MSTR.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.FOOTING_AT, "NAME", DataTypes.Character, 20);
                AddControl(ReportSection.FOOTING_AT, "X_HCP", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_RMB", DataTypes.Numeric, 8);
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
        //# Do not delete, modify or move it.  Updated: 9/28/2017 12:48:52 PM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "CLINIC":
                    return Common.StringToField(CLINIC().PadRight(2, ' '));

                case "INDEXED.F020_DOCTOR_MSTR.DOC_NBR":
                    return Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_NBR").PadRight(3, ' '));

                case "NAME":
                    return Common.StringToField(NAME().PadRight(20, ' '));

                case "X_HCP":
                    return X_HCP().ToString().ToString().PadLeft(8, ' ');

                case "X_RMB":
                    return X_RMB().ToString().ToString().PadLeft(8, ' ');

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
                    Link_F020_DOCTOR_MSTR();
                    while (rdrF020_DOCTOR_MSTR.Read())
                    {
                        WriteData();
                    }
                    rdrF020_DOCTOR_MSTR.Close();
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
