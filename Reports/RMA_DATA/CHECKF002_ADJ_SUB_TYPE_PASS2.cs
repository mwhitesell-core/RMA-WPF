//  write record for each doctor at the highest claim count for the adj type
using Core.DataAccess.TextFile;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.ReportFramework;
using System;
using System.Data;
using System.Text;
namespace RMA_DATA
{
    public class CHECKF002_ADJ_SUB_TYPE__PASS2 : BaseRDLClass
    {
        protected const string REPORT_NAME = "CHECKF002_ADJ_SUB_TYPE__PASS2";
        protected const bool REPORT_HAS_PARAMETERS = false;

        private Reader rdrCHECKF002ADJSUBTYPE = new Reader();
        private Reader rdrCHECKF020_ADJTYPE = new Reader();

        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                //  Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;
                //  Create Subfile.
                SubFile = true;
                SubFileName = "CHECKF020_ADJTYPE";
                SubFileType = SubFileType.Keep;
                Sort = "DOC_NBR ASC, X_COUNT ASC";
                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return ReportData;
        }
        private void Access_CHECKF002ADJSUBTYPE()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: If * is not used to select all columns, ensure the necessary columns (i.e. columns that are used to access records of other tables) are included in the SELECT statement
            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("CLMHDR_ADJ_CD_SUB_TYPE ");
            strSQL.Append("FROM TEMPORARYDATA.CHECKF002ADJSUBTYPE ");
            strSQL.Append("ORDER BY DOC_NBR, CLMHDR_ADJ_CD_SUB_TYPE ");
            strSQL.Append(Choose());
            rdrCHECKF002ADJSUBTYPE.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
            strSQL = null;
        }

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(String.Empty);
            // TODO: CHOOSE Statement - May require manual changes.
            return strChoose.ToString().ToString();
        }

        private decimal X_COUNT = 1;

        private string PREV_CLMHDR_ADJ_CD_SUB_TYPE = string.Empty;
        private string PREV_DOC_NBR = string.Empty;

        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.CHECKF002ADJSUBTYPE.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.CHECKF002ADJSUBTYPE.CLMHDR_ADJ_CD_SUB_TYPE", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "X_COUNT", DataTypes.Numeric, 6);
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
                case "TEMPORARYDATA.CHECKF002ADJSUBTYPE.DOC_NBR":
                    return Common.StringToField(PREV_DOC_NBR);
                case "TEMPORARYDATA.CHECKF002ADJSUBTYPE.CLMHDR_ADJ_CD_SUB_TYPE":
                    return Common.StringToField(PREV_CLMHDR_ADJ_CD_SUB_TYPE);
                case "X_COUNT":
                    return X_COUNT.ToString();
                default:
                    return String.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                // TODO: Some manual steps maybe required.
                Access_CHECKF002ADJSUBTYPE();
                while (rdrCHECKF002ADJSUBTYPE.Read())
                {
                    if (PREV_CLMHDR_ADJ_CD_SUB_TYPE == string.Empty && PREV_DOC_NBR == string.Empty)
                    {
                        PREV_CLMHDR_ADJ_CD_SUB_TYPE = rdrCHECKF002ADJSUBTYPE.GetString("CLMHDR_ADJ_CD_SUB_TYPE");
                        PREV_DOC_NBR = rdrCHECKF002ADJSUBTYPE.GetString("DOC_NBR");
                    }
                    else if (PREV_CLMHDR_ADJ_CD_SUB_TYPE == rdrCHECKF002ADJSUBTYPE.GetString("CLMHDR_ADJ_CD_SUB_TYPE") && PREV_DOC_NBR == rdrCHECKF002ADJSUBTYPE.GetString("DOC_NBR"))
                    {
                        X_COUNT += 1;
                    }
                    else if ((PREV_CLMHDR_ADJ_CD_SUB_TYPE != rdrCHECKF002ADJSUBTYPE.GetString("CLMHDR_ADJ_CD_SUB_TYPE") && PREV_DOC_NBR == rdrCHECKF002ADJSUBTYPE.GetString("DOC_NBR")) || (PREV_DOC_NBR != rdrCHECKF002ADJSUBTYPE.GetString("DOC_NBR")))
                    {
                        WriteData();
                        PREV_CLMHDR_ADJ_CD_SUB_TYPE = rdrCHECKF002ADJSUBTYPE.GetString("CLMHDR_ADJ_CD_SUB_TYPE");
                        PREV_DOC_NBR = rdrCHECKF002ADJSUBTYPE.GetString("DOC_NBR");
                        X_COUNT = 1;
                    }
                }

                //Core Added: Write the last record
                WriteData();

                rdrCHECKF002ADJSUBTYPE.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if (!(rdrCHECKF002ADJSUBTYPE == null))
            {
                rdrCHECKF002ADJSUBTYPE.Close();
                rdrCHECKF002ADJSUBTYPE = null;
            }
        }
    }
}
