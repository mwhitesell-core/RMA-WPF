//  DOC: R211.QZS
//  DOC: REPORT BATCH STATUS IF NOT EQUAL TO  4 
//  DOC: RUN AFTER U210 FOR CLINIC 22/60/80/81/82/83
//  PROGRAM PURPOSE : TO VERIFY U210 RUN O.K.
//  MODIFICATION HISTORY
//  DATE        WHO         DESCRIPTION
//  95/NOV/14   YAS         - ORIGINAL
//  97/MAR/24   YAS         - ADD CLINIC 82
//  97/AUG/24   YAS         - ADD CLINIC 83
//  1999/May/21 S.B.      - Added the use file
//  def_batctrl_batch_status.def to 
//  prevent hardcoding of batctrl-batch-status.
//  2004/May/19 M.C.      - alpha doc nbr
//  y2k
//  y2k
//  ! link (batctrl-batch-nbr/10000000) to iconst-clinic-nbr-1-2 &
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
    public class R211 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R211";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrF001_BATCH_CONTROL_FILE = new Reader();
        private Reader rdrICONST_MSTR_REC = new Reader();
        // #CORE_BEGIN_INCLUDE: DEF_BATCTRL_BATCH_STATUS"
        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-07-20 11:56:25 AM
        private string RANGE_FROM()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.NULL(ReportFunctions.astrScreenParameters[0].ToString());
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string RANGE_TO()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.NULL(ReportFunctions.astrScreenParameters[1].ToString());
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string BATCTRL_BATCH_STATUS_UNBALANCED()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = "0";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string BATCTRL_BATCH_STATUS_BALANCED()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = "1";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string BATCTRL_BATCH_STATUS_REV_UPDATED()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = "2";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string BATCTRL_BATCH_STATUS_OHIP_SENT()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = "3";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string BATCTRL_BATCH_STATUS_MONTHEND_DONE()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = "4";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

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

        private void Access_F001_BATCH_CONTROL_FILE()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("BATCTRL_BATCH_NBR, ");
            strSQL.Append("BATCTRL_BATCH_STATUS, ");
            strSQL.Append("BATCTRL_DATE_PERIOD_END ");
            strSQL.Append("FROM INDEXED.F001_BATCH_CONTROL_FILE ");

            strSQL.Append(SelectIf_F001_BATCH_CONTROL_FILE(true));
            strSQL.Append(Choose());

            rdrF001_BATCH_CONTROL_FILE.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_ICONST_MSTR_REC()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("ICONST_CLINIC_NBR_1_2, ");
            strSQL.Append("ICONST_DATE_PERIOD_END_YY, ");
            strSQL.Append(" ICONST_DATE_PERIOD_END_MM, ");
            strSQL.Append(" ICONST_DATE_PERIOD_END_DD ");
            strSQL.Append("FROM INDEXED.ICONST_MSTR_REC ");
            strSQL.Append("WHERE ");
            strSQL.Append("ICONST_CLINIC_NBR_1_2 = ").Append(QDesign.NConvert(QDesign.Substring(rdrF001_BATCH_CONTROL_FILE.GetString("BATCTRL_BATCH_NBR"), 1, 2)));

            rdrICONST_MSTR_REC.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        #endregion

        #region " CHOOSE "

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(string.Empty);

            strChoose.Append(" AND");
            strChoose.Append(" (BATCTRL_BATCH_NBR BETWEEN '").Append(RANGE_FROM()).Append("'");
            strChoose.Append(" AND '").Append(RANGE_TO()).Append("')");

            return strChoose.ToString();
        }

        #endregion

        #region " SELECT IF "

        private string SelectIf_F001_BATCH_CONTROL_FILE(bool blnAddWhere)
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);
            if (blnAddWhere)
            {
                strSQL.Append(" WHERE ");
            }
            else
            {
                strSQL.Append(" AND ");
            }

            strSQL.Append(" BATCTRL_BATCH_STATUS <> '");
            strSQL.Append(BATCTRL_BATCH_STATUS_MONTHEND_DONE()).Append("'");
            return strSQL.ToString();
        }

        public override bool SelectIf()
        {
            bool blnSelected = false;
            if ((QDesign.NULL(ICONST_MSTR_REC_ICONST_DATE_PERIOD_END()) == QDesign.NULL(QDesign.NConvert(rdrF001_BATCH_CONTROL_FILE.GetString("BATCTRL_DATE_PERIOD_END")))))
            {
                blnSelected = true;
            }

            return blnSelected;
        }

        #endregion

        #region " DEFINES "

        private decimal ICONST_MSTR_REC_ICONST_DATE_PERIOD_END()
        {
            decimal decReturnValue = 0;

            try
            {
                decReturnValue = QDesign.NConvert(QDesign.ASCII(rdrICONST_MSTR_REC.GetNumber("ICONST_DATE_PERIOD_END_YY"), 4) 
                    + QDesign.ASCII(rdrICONST_MSTR_REC.GetNumber("ICONST_DATE_PERIOD_END_MM"), 2) 
                    + QDesign.ASCII(rdrICONST_MSTR_REC.GetNumber("ICONST_DATE_PERIOD_END_DD"), 2));
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
                AddControl(ReportSection.PAGE_HEADING, "INDEXED.ICONST_MSTR_REC.ICONST_CLINIC_NBR_1_2", DataTypes.Numeric, 2);
                AddControl(ReportSection.PAGE_HEADING, "ICONST_DATE_PERIOD_END", DataTypes.Numeric, 8);
                AddControl(ReportSection.REPORT, "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_BATCH_NBR", DataTypes.Character, 8);
                AddControl(ReportSection.REPORT, "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_DATE_PERIOD_END", DataTypes.Character, 8);
                AddControl(ReportSection.REPORT, "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_BATCH_STATUS", DataTypes.Character, 1);
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
        // # Do not delete, modify or move it.  Updated: 2018-07-20 11:56:25 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            // TODO: Remove duplicate controls, if there are any.
            switch (strControl)
            {
                case "INDEXED.ICONST_MSTR_REC.ICONST_CLINIC_NBR_1_2":
                    return rdrICONST_MSTR_REC.GetNumber("ICONST_CLINIC_NBR_1_2").ToString();

                case "ICONST_DATE_PERIOD_END":
                    return ICONST_MSTR_REC_ICONST_DATE_PERIOD_END().ToString();

                case "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_BATCH_NBR":
                    return Common.StringToField(rdrF001_BATCH_CONTROL_FILE.GetString("BATCTRL_BATCH_NBR"));

                case "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_DATE_PERIOD_END":
                    return Common.StringToField(rdrF001_BATCH_CONTROL_FILE.GetString("BATCTRL_DATE_PERIOD_END"));

                case "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_BATCH_STATUS":
                    return Common.StringToField(rdrF001_BATCH_CONTROL_FILE.GetString("BATCTRL_BATCH_STATUS"));

                default:
                    return string.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                Access_F001_BATCH_CONTROL_FILE();
                while (rdrF001_BATCH_CONTROL_FILE.Read())
                {
                    Link_ICONST_MSTR_REC();
                    while (rdrICONST_MSTR_REC.Read())
                    {
                        WriteData();
                    }

                    rdrICONST_MSTR_REC.Close();
                }

                rdrF001_BATCH_CONTROL_FILE.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrF001_BATCH_CONTROL_FILE == null))
            {
                rdrF001_BATCH_CONTROL_FILE.Close();
                rdrF001_BATCH_CONTROL_FILE = null;
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
