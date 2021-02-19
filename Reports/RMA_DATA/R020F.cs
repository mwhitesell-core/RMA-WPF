//  #> PROGRAM-ID.     R020F.QZS
//  ((C)) Dyad Technologies
//  PROGRAM PURPOSE : SUMMARY OF REJECTED CLAIMS (IE NOT SUBMITTED
//  TO OHIP DUE TO MESS CODE IN PAT MSTR)
//  MODIFICATION HISTORY
//  DATE   WHO          DESCRIPTION
//  93/MAY/06 M.C.      - SMS 141 (ORIGINAL)
//  95/SEP/21 Y.B.         - ADD CLINIC TOTALS
//  98/Aug/18 B.E.      - changed page length from 63 to 66 line
//  98/sep/16 y.b.         - changed page width from 80 to 132
//  04/may/13 M.C.      - alpha doc nbr
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
    public class R020F : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R020F";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrU020C1 = new Reader();
        private Reader rdrICONST_MSTR_REC = new Reader();

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
                Sort = "ICONST_CLINIC_NBR_1_2 ASC, BATCTRL_BATCH_NBR ASC, CLMHDR_CLAIM_ID ASC";
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

        private void Access_U020C1()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("ICONST_CLINIC_NBR_1_2, ");
            strSQL.Append("BATCTRL_BATCH_NBR, ");
            strSQL.Append("CLMHDR_CLAIM_ID, ");
            strSQL.Append("ICONST_CLINIC_CYCLE_NBR, ");
            strSQL.Append("ICONST_DATE_PERIOD_END, ");
            strSQL.Append("CLMHDR_DOC_DEPT, ");
            strSQL.Append("CLMHDR_TOT_CLAIM_AR_OHIP ");
            strSQL.Append("FROM TEMPORARYDATA.U020C1 ");

            strSQL.Append(Choose());

            rdrU020C1.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
            strSQL = null;
        }
        private void Link_ICONST_MSTR_REC()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("ICONST_CLINIC_NAME ");
            strSQL.Append("FROM INDEXED.ICONST_MSTR_REC ");
            strSQL.Append("WHERE ");
            strSQL.Append("ICONST_CLINIC_NBR_1_2 = ").Append(rdrU020C1.GetNumber("ICONST_CLINIC_NBR_1_2"));

            rdrICONST_MSTR_REC.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
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

        private string W_CLAIM_NBR()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = QDesign.Substring(rdrU020C1.GetString("CLMHDR_BATCH_NBR"), 3, 6) + QDesign.ASCII(rdrU020C1.GetNumber("CLMHDR_CLAIM_NBR"), 2);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return strReturnValue;
        }

        private string CLMHDR_CLAIM_ID()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = rdrU020C1.GetString("CLMHDR_BATCH_NBR") + QDesign.ASCII(rdrU020C1.GetNumber("CLMHDR_CLAIM_NBR"), 2) +
                    QDesign.ASCII(rdrU020C1.GetString("CLMHDR_ADJ_OMA_CD"), 4) + rdrU020C1.GetString("CLMHDR_ADJ_OMA_SUFF") + rdrU020C1.GetString("CLMHDR_ADJ_ADJ_NBR");
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
                 AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.U020C1.ICONST_CLINIC_NBR_1_2", DataTypes.Numeric, 2);
                 AddControl(ReportSection.PAGE_HEADING, "INDEXED.ICONST_MSTR_REC.ICONST_CLINIC_NAME", DataTypes.Character, 20);
                 AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.U020C1.ICONST_CLINIC_CYCLE_NBR", DataTypes.Numeric, 2);
                 AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.U020C1.ICONST_DATE_PERIOD_END", DataTypes.Numeric, 8);
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.U020C1.CLMHDR_DOC_DEPT", DataTypes.Numeric, 2);
                 AddControl(ReportSection.REPORT, "W_CLAIM_NBR", DataTypes.Character, 8);
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.U020C1.CLMHDR_TOT_CLAIM_AR_OHIP", DataTypes.Numeric, 7);
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.U020C1.BATCTRL_BATCH_NBR", DataTypes.Character, 8);
                 AddControl(ReportSection.REPORT, "CLMHDR_CLAIM_ID", DataTypes.Character, 16);
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
                case "TEMPORARYDATA.U020C1.ICONST_CLINIC_NBR_1_2":
                    return rdrU020C1.GetNumber("ICONST_CLINIC_NBR_1_2").ToString();

                case "INDEXED.ICONST_MSTR_REC.ICONST_CLINIC_NAME":
                    return Common.StringToField(rdrICONST_MSTR_REC.GetString("ICONST_CLINIC_NAME"));

                case "TEMPORARYDATA.U020C1.ICONST_CLINIC_CYCLE_NBR":
                    return rdrU020C1.GetNumber("ICONST_CLINIC_CYCLE_NBR").ToString();

                case "TEMPORARYDATA.U020C1.ICONST_DATE_PERIOD_END":
                    return rdrU020C1.GetNumber("ICONST_DATE_PERIOD_END").ToString();

                case "TEMPORARYDATA.U020C1.CLMHDR_DOC_DEPT":
                    return rdrU020C1.GetNumber("CLMHDR_DOC_DEPT").ToString();

                case "W_CLAIM_NBR":
                    return Common.StringToField(W_CLAIM_NBR(), intSize);

                case "TEMPORARYDATA.U020C1.CLMHDR_TOT_CLAIM_AR_OHIP":
                    return rdrU020C1.GetNumber("CLMHDR_TOT_CLAIM_AR_OHIP").ToString();

                case "TEMPORARYDATA.U020C1.BATCTRL_BATCH_NBR":
                    return Common.StringToField(rdrU020C1.GetString("BATCTRL_BATCH_NBR"));

                case "CLMHDR_CLAIM_ID":
                    return Common.StringToField(CLMHDR_CLAIM_ID());

                default:
                    return string.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                Access_U020C1();
                while (rdrU020C1.Read())
                {
                    Link_ICONST_MSTR_REC();
                    while (rdrICONST_MSTR_REC.Read())
                    {
                        WriteData();
                    }
                
                    rdrICONST_MSTR_REC.Close();
                }
            
                rdrU020C1.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrU020C1 == null))
            {
                rdrU020C1.Close();
                rdrU020C1 = null;
            }
        
            if (!(rdrICONST_MSTR_REC == null))
            {
                rdrICONST_MSTR_REC.Close();
                rdrICONST_MSTR_REC = null;
            }
        }

        #endregion

        #endregion
    }
}
