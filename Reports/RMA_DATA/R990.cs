//  Program: r990.qzs
//  Purpose: Verify the contents of the adj_claim_file are correct before
//  processing the file.
//  Comments:If the oma code is blank then the OHIP cycle will NOT balance so
//  this program reports any blank records which have to then be
//  fixed before starting the cycle.
//  The fixup programs  are fix_adj_claim_file_*.qts
//  2004/jan/05 b.e. - alpha doctor nbr
using Core.DataAccess.SqlServer;
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
    public class R990 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R990";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrADJ_CLAIM_FILE = new Reader();

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
                Sort = "";
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

        private void Access_ADJ_CLAIM_FILE()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("ADJ_BATCH_NBR, ");
            strSQL.Append("ADJ_CLAIM_NBR, ");
            strSQL.Append("ADJ_OMA_CD_SUFF, ");
            strSQL.Append("ADJ_SERV_DATE, ");
            strSQL.Append("ADJ_AGENT_CD, ");
            strSQL.Append("ADJ_PAT_ACRONYM, ");
            strSQL.Append("ADJ_AMT_BAL, ");
            strSQL.Append("ADJ_DIAG_CD, ");
            strSQL.Append("ADJ_LINE_NO ");
            strSQL.Append("FROM SEQUENTIAL.ADJ_CLAIM_FILE ");

            strSQL.Append(Choose());

            rdrADJ_CLAIM_FILE.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
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

        public override bool SelectIf()
        {
            bool blnSelected = false;
            if (((QDesign.NULL(rdrADJ_CLAIM_FILE.GetString("ADJ_BATCH_NBR")) == "00000000") 
                        || ((QDesign.NULL(rdrADJ_CLAIM_FILE.GetNumber("ADJ_CLAIM_NBR")) == QDesign.NULL(0d)) 
                        || ((QDesign.NULL(rdrADJ_CLAIM_FILE.GetString("ADJ_OMA_CD_SUFF")) == QDesign.NULL(" ")) 
                        || (QDesign.NULL(rdrADJ_CLAIM_FILE.GetNumber("ADJ_SERV_DATE")) == QDesign.NULL(0d))))))
            {
                blnSelected = true;
            }
        
            return blnSelected;
        }

        #endregion

        #region " DEFINES "

        #endregion

        #region " CONTROLS "

        public override void DeclareReportControls()
        {
            try
            {
                 AddControl(ReportSection.REPORT, "SEQUENTIAL.ADJ_CLAIM_FILE.ADJ_AGENT_CD", DataTypes.Numeric, 1);
                 AddControl(ReportSection.REPORT, "SEQUENTIAL.ADJ_CLAIM_FILE.ADJ_AMT_BAL", DataTypes.Numeric, 7);
                 AddControl(ReportSection.REPORT, "SEQUENTIAL.ADJ_CLAIM_FILE.ADJ_BATCH_NBR", DataTypes.Character, 8);
                 AddControl(ReportSection.REPORT, "SEQUENTIAL.ADJ_CLAIM_FILE.ADJ_CLAIM_NBR", DataTypes.Numeric, 2);
                 AddControl(ReportSection.REPORT, "SEQUENTIAL.ADJ_CLAIM_FILE.ADJ_DIAG_CD", DataTypes.Numeric, 3);
                 AddControl(ReportSection.REPORT, "SEQUENTIAL.ADJ_CLAIM_FILE.ADJ_LINE_NO", DataTypes.Numeric, 2);
                 AddControl(ReportSection.REPORT, "SEQUENTIAL.ADJ_CLAIM_FILE.ADJ_OMA_CD_SUFF", DataTypes.Character, 5);
                 AddControl(ReportSection.REPORT, "SEQUENTIAL.ADJ_CLAIM_FILE.ADJ_PAT_ACRONYM", DataTypes.Character, 9);
                 AddControl(ReportSection.REPORT, "SEQUENTIAL.ADJ_CLAIM_FILE.ADJ_SERV_DATE", DataTypes.Numeric, 8);
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
        // # Do not delete, modify or move it.  Updated: 2018-05-16 9:44:54 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "SEQUENTIAL.ADJ_CLAIM_FILE.ADJ_AGENT_CD":
                    return rdrADJ_CLAIM_FILE.GetNumber("ADJ_AGENT_CD").ToString();

                case "SEQUENTIAL.ADJ_CLAIM_FILE.ADJ_AMT_BAL":
                    return rdrADJ_CLAIM_FILE.GetNumber("ADJ_AMT_BAL").ToString();

                case "SEQUENTIAL.ADJ_CLAIM_FILE.ADJ_BATCH_NBR":
                    return Common.StringToField(rdrADJ_CLAIM_FILE.GetString("ADJ_BATCH_NBR"));

                case "SEQUENTIAL.ADJ_CLAIM_FILE.ADJ_CLAIM_NBR":
                    return rdrADJ_CLAIM_FILE.GetNumber("ADJ_CLAIM_NBR").ToString();

                case "SEQUENTIAL.ADJ_CLAIM_FILE.ADJ_DIAG_CD":
                    return rdrADJ_CLAIM_FILE.GetNumber("ADJ_DIAG_CD").ToString();

                case "SEQUENTIAL.ADJ_CLAIM_FILE.ADJ_LINE_NO":
                    return rdrADJ_CLAIM_FILE.GetNumber("ADJ_LINE_NO").ToString();

                case "SEQUENTIAL.ADJ_CLAIM_FILE.ADJ_OMA_CD_SUFF":
                    return Common.StringToField(rdrADJ_CLAIM_FILE.GetString("ADJ_OMA_CD_SUFF"));

                case "SEQUENTIAL.ADJ_CLAIM_FILE.ADJ_PAT_ACRONYM":
                    return Common.StringToField(rdrADJ_CLAIM_FILE.GetString("ADJ_PAT_ACRONYM"));

                case "SEQUENTIAL.ADJ_CLAIM_FILE.ADJ_SERV_DATE":
                    return rdrADJ_CLAIM_FILE.GetNumber("ADJ_SERV_DATE").ToString();

                default:
                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_ADJ_CLAIM_FILE();
                while (rdrADJ_CLAIM_FILE.Read())
                {
                    WriteData();
                }
            
                rdrADJ_CLAIM_FILE.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if (!(rdrADJ_CLAIM_FILE == null))
            {
                rdrADJ_CLAIM_FILE.Close();
                rdrADJ_CLAIM_FILE = null;
            }
        }

        #endregion

        #endregion
    }
}
