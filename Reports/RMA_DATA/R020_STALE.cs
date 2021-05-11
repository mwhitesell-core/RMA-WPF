//  set page length 63 width 132
//  set noclose
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
    public class R020_STALE : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R020_STALE";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrU020B = new Reader();
        private Reader rdrF020_DOCTOR_MSTR = new Reader();

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
                Sort = "CLMHDR_BATCH_NBR ASC, CLMHDR_CLAIM_NBR ASC";
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

        private void Access_U020B()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("BATCTRL_DOC_NBR_OHIP, ");
            strSQL.Append("BATCTRL_LOC, ");
            strSQL.Append("BATCTRL_DATE_BATCH_ENTERED, ");
            strSQL.Append("CLMHDR_BATCH_NBR, ");
            strSQL.Append("CLMHDR_CLAIM_NBR, ");
            strSQL.Append("CLMDTL_OMA_CD, ");
            strSQL.Append("W_CLMDTL_FEE_OHIP, ");
            strSQL.Append("CLMDTL_SV_DATE ");
            strSQL.Append("FROM TEMPORARYDATA.U020B ");

            strSQL.Append(Choose());

            rdrU020B.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
            strSQL = null;
        }
        private void Link_F020_DOCTOR_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("DOC_NAME, ");
            strSQL.Append("DOC_INIT1, ");
            strSQL.Append("DOC_INIT2, ");
            strSQL.Append("DOC_INIT3 ");
            strSQL.Append("FROM INDEXED.F020_DOCTOR_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_OHIP_NBR = ").Append(rdrU020B.GetNumber("BATCTRL_DOC_NBR_OHIP"));

            rdrF020_DOCTOR_MSTR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
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

        private string DOC_FULLNAME()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = rdrF020_DOCTOR_MSTR.GetString("DOC_NAME") + " " + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT1") + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT2") + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT3");
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
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
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.U020B.CLMHDR_BATCH_NBR", DataTypes.Character, 8);
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.U020B.CLMHDR_CLAIM_NBR", DataTypes.Numeric, 2);
                 AddControl(ReportSection.REPORT, "INDEXED.F002_DOCTOR_MSTR.DOC_NBR", DataTypes.Character, 3);
                 AddControl(ReportSection.REPORT, "DOC_FULLNAME", DataTypes.Character, 28);
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.U020B.BATCTRL_LOC", DataTypes.Character, 4);
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.U020B.CLMDTL_OMA_CD", DataTypes.Character, 4);
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.U020B.W_CLMDTL_FEE_OHIP", DataTypes.Numeric, 12);
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.U020B.BATCTRL_DATE_BATCH_ENTERED", DataTypes.Numeric, 8);
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.U020B.CLMDTL_SV_DATE", DataTypes.Numeric, 8);
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
        // # Do not delete, modify or move it.  Updated: 2018-05-11 6:02:25 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "TEMPORARYDATA.U020B.CLMHDR_BATCH_NBR":
                    return Common.StringToField(rdrU020B.GetString("CLMHDR_BATCH_NBR"));

                case "TEMPORARYDATA.U020B.CLMHDR_CLAIM_NBR":
                    return rdrU020B.GetNumber("CLMHDR_CLAIM_NBR").ToString();

                case "INDEXED.F002_DOCTOR_MSTR.DOC_NBR":
                    return Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_NBR"));

                case "DOC_FULLNAME":
                    return Common.StringToField(DOC_FULLNAME(), intSize);

                case "TEMPORARYDATA.U020B.BATCTRL_LOC":
                    return Common.StringToField(rdrU020B.GetString("BATCTRL_LOC"));

                case "TEMPORARYDATA.U020B.CLMDTL_OMA_CD":
                    return Common.StringToField(rdrU020B.GetString("CLMDTL_OMA_CD"));

                case "TEMPORARYDATA.U020B.W_CLMDTL_FEE_OHIP":
                    return rdrU020B.GetNumber("W_CLMDTL_FEE_OHIP").ToString();

                case "TEMPORARYDATA.U020B.BATCTRL_DATE_BATCH_ENTERED":
                    return rdrU020B.GetNumber("BATCTRL_DATE_BATCH_ENTERED").ToString();

                case "TEMPORARYDATA.U020B.CLMDTL_SV_DATE":
                    return rdrU020B.GetNumber("CLMDTL_SV_DATE").ToString();

                default:
                    return string.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                Access_U020B();
                while (rdrU020B.Read())
                {
                    Link_F020_DOCTOR_MSTR();
                    while (rdrF020_DOCTOR_MSTR.Read())
                    {
                        WriteData();
                    }
                
                    rdrF020_DOCTOR_MSTR.Close();
                }
            
                rdrU020B.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrU020B == null))
            {
                rdrU020B.Close();
                rdrU020B = null;
            }
        
            if (!(rdrF020_DOCTOR_MSTR == null))
            {
                rdrF020_DOCTOR_MSTR.Close();
                rdrF020_DOCTOR_MSTR = null;
            }
        }

        #endregion

        #endregion
    }
}
