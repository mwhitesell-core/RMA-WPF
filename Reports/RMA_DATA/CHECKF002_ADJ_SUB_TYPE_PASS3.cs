//  write record for each doctor at the highest claim count for the adj type
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
    public class CHECKF002_ADJ_SUB_TYPE__PASS3 : BaseRDLClass
    {
        protected const string REPORT_NAME = "CHECKF002_ADJ_SUB_TYPE__PASS3";
        protected const bool REPORT_HAS_PARAMETERS = false;

        private Reader rdrCHECKF020_ADJTYPE = new Reader();
        private Reader rdrSAVEF020ADJTYPE = new Reader();

        private string docNbr = string.Empty;
        private string xType = string.Empty;
        private Int32 xCount = 0;

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
                SubFileName = "SAVEF020ADJTYPE";
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
        private void Access_CHECKF020_ADJTYPE()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: If * is not used to select all columns, ensure the necessary columns (i.e. columns that are used to access records of other tables) are included in the SELECT statement
            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("X_COUNT, ");
            strSQL.Append("CLMHDR_ADJ_CD_SUB_TYPE ");
            strSQL.Append("FROM TEMPORARYDATA.CHECKF020_ADJTYPE ");
            strSQL.Append(Choose());
            rdrCHECKF020_ADJTYPE.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
            strSQL = null;
        }

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(String.Empty);
            // TODO: CHOOSE Statement - May require manual changes.
            return strChoose.ToString().ToString();
        }
        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.CHECKF020_ADJTYPE.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.CHECKF020_ADJTYPE.CLMHDR_ADJ_CD_SUB_TYPE", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.CHECKF020_ADJTYPE.X_COUNT", DataTypes.Numeric, 6);
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
                case "TEMPORARYDATA.CHECKF020_ADJTYPE.DOC_NBR":
                    return docNbr;
                case "TEMPORARYDATA.CHECKF020_ADJTYPE.CLMHDR_ADJ_CD_SUB_TYPE":
                    return xType;
                case "TEMPORARYDATA.CHECKF020_ADJTYPE.X_COUNT":
                    return xCount.ToString();
                default:
                    return String.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                // TODO: Some manual steps maybe required.
                Access_CHECKF020_ADJTYPE();
                while (rdrCHECKF020_ADJTYPE.Read())
                {
                    if (docNbr == "")
                    {
                        docNbr = rdrCHECKF020_ADJTYPE.GetString("DOC_NBR").ToString();
                        xType = rdrCHECKF020_ADJTYPE.GetString("CLMHDR_ADJ_CD_SUB_TYPE").ToString();
                        xCount = (int)QDesign.NConvert(rdrCHECKF020_ADJTYPE.GetNumber("X_COUNT").ToString());
                    }
                    else if (docNbr == rdrCHECKF020_ADJTYPE.GetString("DOC_NBR").ToString() && xCount < (int)QDesign.NConvert(rdrCHECKF020_ADJTYPE.GetNumber("X_COUNT").ToString()))
                    {
                        xCount = (int)QDesign.NConvert(rdrCHECKF020_ADJTYPE.GetNumber("X_COUNT").ToString());
                        xType = rdrCHECKF020_ADJTYPE.GetString("CLMHDR_ADJ_CD_SUB_TYPE").ToString();
                    }
                    else if (docNbr != rdrCHECKF020_ADJTYPE.GetString("DOC_NBR").ToString())
                    {
                        WriteData();

                        docNbr = rdrCHECKF020_ADJTYPE.GetString("DOC_NBR").ToString();
                        xType = rdrCHECKF020_ADJTYPE.GetString("CLMHDR_ADJ_CD_SUB_TYPE").ToString();
                        xCount = (int)QDesign.NConvert(rdrCHECKF020_ADJTYPE.GetNumber("X_COUNT").ToString());
                    }
                }

                //Write the last record
                WriteData();

                rdrCHECKF020_ADJTYPE.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if (!(rdrCHECKF020_ADJTYPE == null))
            {
                rdrCHECKF020_ADJTYPE.Close();
                rdrCHECKF020_ADJTYPE = null;
            }
        }
    }
}
