//  #> program-id.     r022a6.qzs
//  ((C)) Dyad Technologies
//  PROGRAM PURPOSE : SELECT CLAIMS FOR RE-SUBMIT
//  IF CHANGES REQUIRED FOR HOSPITAL CODES, MAKE
//  SURE TO CHANGE IN HOSPITAL_CODE.DEF
//  MODIFICATION HISTORY
//  DATE   WHO          DESCRIPTION
//  00/sep/18 B.E.        - moved from r022a.qzs into separate source module
//  set page length 66 width 132
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
    public class R022A6 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R022A6";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrU020A1 = new Reader();

        #endregion

        #region " Renaissance Data "

        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                //  Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;
                Sort = "TRANSLATED_GROUP_NBR ASC";
                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return ReportData;
        }

        #endregion

        #region " Renaissance Statements "

        #region " ACCESS "

        private void Access_U020A1()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("TRANSLATED_GROUP_NBR, ");
            strSQL.Append("ICONST_DATE_PERIOD_END, ");
            strSQL.Append("CLMHDR_TOT_CLAIM_AR_OMA, ");
            strSQL.Append("CLMHDR_TOT_CLAIM_AR_OHIP ");
            strSQL.Append("FROM TEMPORARYDATA.U020A1 ");

            strSQL.Append(Choose());

            rdrU020A1.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
            strSQL = null;
        }

        #endregion

        #region " CHOOSE "

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(string.Empty);

            return strChoose.ToString().ToString();
        }

        #endregion

        #region " SELECT IF "

        #endregion

        #region " DEFINES "

        #endregion

        #region " CONTROLS "

        public override void DeclareReportControls()
        {
            try
            {
                 AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.U020A1.ICONST_DATE_PERIOD_END", DataTypes.Numeric, 8);
                 AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.U020A1.TRANSLATED_GROUP_NBR", DataTypes.Character, 4);
                 AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.U020A1.CLMHDR_TOT_CLAIM_AR_OMA", DataTypes.Numeric, 7);
                 AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.U020A1.CLMHDR_TOT_CLAIM_AR_OHIP", DataTypes.Numeric, 7);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        #endregion

        #region " Renaissance Precompiler Generated Code "

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-05-11 6:02:21 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "TEMPORARYDATA.U020A1.ICONST_DATE_PERIOD_END":
                    return rdrU020A1.GetNumber("ICONST_DATE_PERIOD_END").ToString();

                case "TEMPORARYDATA.U020A1.TRANSLATED_GROUP_NBR":
                    return Common.StringToField(rdrU020A1.GetString("TRANSLATED_GROUP_NBR"));

                case "TEMPORARYDATA.U020A1.CLMHDR_TOT_CLAIM_AR_OMA":
                    return rdrU020A1.GetNumber("CLMHDR_TOT_CLAIM_AR_OMA").ToString();

                case "TEMPORARYDATA.U020A1.CLMHDR_TOT_CLAIM_AR_OHIP":
                    return rdrU020A1.GetNumber("CLMHDR_TOT_CLAIM_AR_OHIP").ToString();

                default:
                    return string.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                Access_U020A1();
                while (rdrU020A1.Read())
                {
                    WriteData();
                }
            
                rdrU020A1.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrU020A1 == null))
            {
                rdrU020A1.Close();
                rdrU020A1 = null;
            }
        }

        #endregion

        #endregion
    }
}
