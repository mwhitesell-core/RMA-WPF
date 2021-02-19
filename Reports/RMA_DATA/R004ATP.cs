#region "Screen Comments"

// DOC: R004ATP.QZS
// DOC: MONTHLY CLAIMS & ADJUSTMENTS TRANSACTION SUMMARY (DETAIL REPORT)
// DOC: SORT BY CLINIC/DEPT/DOC #/PATIENT/SVCS/CLAIM #/OMA CODE
// DOC: RUN FOR: MUMC DIAGNOSTICS
// PROGRAM PURPOSE : TRANSACTION SUMMARY (DETAIL REPORT)
// THIS IS THE FIRST OF A SERIES OF PROGRAMS TO CREATE
// THE R004ATP.TXT REPORT (R004BTP.TXT  AND R004CTP.TXT
// ARE CONCATENATED TO R004ATP.TXT FOR FINAL REPORT).
// DATE       BY WHOM   DESCRIPTION
// 92/06/10   YASEMIN   ORIGINAL
// 95/07/18   YASEMIN   SELECT IF F002 PED = ICONST PED
// 03/dec/17  A.A.      alpha doctor nbr
// 06/04/17   b.e.      - add logic to ignore any header record with `tape submit
// indicator` set to tilde (~). This allows correction
// adjustment transactions to be hidden from user viewing
// report(less messy)
// 2010/02/04 yas       - add new clinic 66
// !  link (floor(batctrl-batch-nbr / 10000000))   &
// !  link (nconvert(clmhdr-claim-id[4:3]))    &

#endregion

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
    public class R004ATP : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R004ATP";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrF001_BATCH_CONTROL_FILE = new Reader();
        private Reader rdrF002_CLAIMS_MSTR = new Reader();
        private Reader rdrF010_PAT_MSTR = new Reader();
        private Reader rdrICONST_MSTR_REC = new Reader();
        private Reader rdrF020_DOCTOR_MSTR = new Reader();
        private Reader rdrR004ATP = new Reader();
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
                SubFileName = "R004ATP";
                SubFileType = SubFileType.Keep;
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

        private void Access_F001_BATCH_CONTROL_FILE()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("BATCTRL_BATCH_NBR, ");
            strSQL.Append("BATCTRL_BATCH_TYPE, ");
            strSQL.Append("BATCTRL_ADJ_CD, ");
            strSQL.Append("BATCTRL_DATE_PERIOD_END ");
            strSQL.Append("FROM INDEXED.F001_BATCH_CONTROL_FILE ");
            strSQL.Append(Choose());
            strSQL.Append(SelectIf_F001_BATCH_CONTROL_FILE(false));

            rdrF001_BATCH_CONTROL_FILE.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

            strSQL = null;
        }

        private void Link_F002_CLAIMS_MSTR_HDR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("KEY_CLM_TYPE, ");
            strSQL.Append("KEY_CLM_BATCH_NBR, ");
            strSQL.Append("CLMHDR_PAT_KEY_TYPE, ");
            strSQL.Append("CLMHDR_PAT_KEY_DATA, ");
            strSQL.Append("CLMHDR_BATCH_NBR, ");
            strSQL.Append("CLMHDR_CLAIM_NBR, ");
            strSQL.Append("CLMHDR_ADJ_OMA_CD, ");
            strSQL.Append("CLMHDR_ADJ_OMA_SUFF, ");
            strSQL.Append("CLMHDR_ADJ_ADJ_NBR, ");
            strSQL.Append("CLMHDR_TAPE_SUBMIT_IND, ");
            strSQL.Append("CLMHDR_DATE_PERIOD_END, ");
            strSQL.Append("CLMHDR_DOC_DEPT, ");
            strSQL.Append("CLMHDR_DATE_SYS, ");
            strSQL.Append("CLMHDR_REFERENCE, ");
            strSQL.Append("KEY_CLM_CLAIM_NBR ");
            strSQL.Append("FROM INDEXED.F002_CLAIMS_MSTR_HDR ");
            strSQL.Append("WHERE ");
            strSQL.Append("KEY_CLM_TYPE = ").Append(Common.StringToField("B"));
            strSQL.Append(" AND KEY_CLM_BATCH_NBR = ").Append(Common.StringToField(rdrF001_BATCH_CONTROL_FILE.GetString("BATCTRL_BATCH_NBR")));

            strSQL.Append(SelectIf_F002_CLAIMS_MSTR(false));
            rdrF002_CLAIMS_MSTR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

            strSQL = null;
        }

        private void Link_F010_PAT_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("PAT_I_KEY, ");
            strSQL.Append("PAT_CON_NBR, ");
            strSQL.Append("PAT_I_NBR, ");
            strSQL.Append("FILLER4, ");
            strSQL.Append("PAT_HEALTH_NBR, ");
            strSQL.Append("PAT_DIRECT_ALPHA, ");
            strSQL.Append("PAT_DIRECT_YY, ");
            strSQL.Append("PAT_DIRECT_MM, ");
            strSQL.Append("PAT_DIRECT_DD, ");
            strSQL.Append("PAT_DIRECT_LAST_6, ");
            strSQL.Append("PAT_ACRONYM_FIRST6, ");
            strSQL.Append("PAT_ACRONYM_LAST3, ");
            strSQL.Append("PAT_SURNAME_FIRST3, ");
            strSQL.Append("PAT_SURNAME_LAST22, ");
            strSQL.Append("PAT_GIVEN_NAME_FIRST1, ");
            strSQL.Append("FILLER3 ");
            strSQL.Append("FROM INDEXED.F010_PAT_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("PAT_I_KEY = ").Append(Common.StringToField(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_PAT_KEY_TYPE")));
            strSQL.Append(" AND PAT_CON_NBR = ").Append(QDesign.NConvert(QDesign.Substring(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_PAT_KEY_DATA"), 1, 2)));
            strSQL.Append(" AND PAT_I_NBR = ").Append(QDesign.NConvert(QDesign.Substring(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_PAT_KEY_DATA"), 3, 12)));
            strSQL.Append(" AND FILLER4 = ").Append(Common.StringToField(QDesign.Substring(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_PAT_KEY_DATA"), 15, 1)));

            rdrF010_PAT_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

            strSQL = null;
        }

        private void Link_ICONST_MSTR_REC()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("ICONST_CLINIC_NBR_1_2, ");
            strSQL.Append("ICONST_DATE_PERIOD_END_YY, ");
            strSQL.Append("ICONST_DATE_PERIOD_END_MM, ");
            strSQL.Append("ICONST_DATE_PERIOD_END_DD, ");
            strSQL.Append("ICONST_CLINIC_NBR, ");
            strSQL.Append("ICONST_CLINIC_NAME ");
            strSQL.Append("FROM INDEXED.ICONST_MSTR_REC ");
            strSQL.Append("WHERE ");
            strSQL.Append("ICONST_CLINIC_NBR_1_2 = ").Append(QDesign.NConvert(QDesign.Substring(rdrF001_BATCH_CONTROL_FILE.GetString("BATCTRL_BATCH_NBR"), 1, 2)));

            rdrICONST_MSTR_REC.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

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
            strSQL.Append("DOC_NBR = ").Append(Common.StringToField(QDesign.Substring(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_BATCH_NBR"), 3, 3)));

            rdrF020_DOCTOR_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

            strSQL = null;
        }

        #endregion

        #region " CHOOSE "

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(string.Empty);

            strChoose.Append(" WHERE ");
            if(QDesign.NULL(ReportFunctions.astrScreenParameters[0].ToString()) != QDesign.NULL("") && QDesign.NULL(ReportFunctions.astrScreenParameters[1].ToString()) != QDesign.NULL(""))
            {
                strChoose.Append(" BATCTRL_BATCH_NBR >= ").Append(Common.StringToField(ReportFunctions.astrScreenParameters[0].ToString()));
                strChoose.Append(" AND BATCTRL_BATCH_NBR <= ").Append(Common.StringToField(ReportFunctions.astrScreenParameters[1].ToString()));
            }
            else
            {
                strChoose.Append(" BATCTRL_BATCH_NBR >= '60000000'");
                strChoose.Append(" AND BATCTRL_BATCH_NBR <= '66ZZZ999'");
            }


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

            strSQL.Append("((BATCTRL_BATCH_TYPE = 'C') OR ");
            strSQL.Append("(BATCTRL_BATCH_TYPE = 'A' AND ");
            strSQL.Append("(BATCTRL_ADJ_CD = 'B' OR ");
            strSQL.Append("BATCTRL_ADJ_CD = 'R')) OR ");
            strSQL.Append("(BATCTRL_BATCH_TYPE = 'P' AND ");
            strSQL.Append("BATCTRL_ADJ_CD = 'M'))");
            return strSQL.ToString();
        }

        private string SelectIf_F002_CLAIMS_MSTR(bool blnAddWhere)
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

            strSQL.Append(" (    CLMHDR_ADJ_OMA_CD =  '0000' AND ");
            strSQL.Append("    CLMHDR_ADJ_OMA_SUFF =  '0' AND ");
            strSQL.Append("    CLMHDR_ADJ_ADJ_NBR =  '0' AND ");
            strSQL.Append("    CLMHDR_TAPE_SUBMIT_IND <>  '~')");
            return strSQL.ToString();
        }

        public override bool SelectIf()
        {
            bool blnSelected = false;

            if ((QDesign.NULL(rdrF001_BATCH_CONTROL_FILE.GetString("BATCTRL_DATE_PERIOD_END")) == QDesign.NULL(QDesign.ASCII(rdrICONST_MSTR_REC.GetNumber("ICONST_DATE_PERIOD_END_YY"), 4) + QDesign.ASCII(rdrICONST_MSTR_REC.GetNumber("ICONST_DATE_PERIOD_END_MM"), 2) + QDesign.ASCII(rdrICONST_MSTR_REC.GetNumber("ICONST_DATE_PERIOD_END_DD"), 2))) & (QDesign.NULL(QDesign.ASCII(rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_DATE_PERIOD_END"))) == QDesign.NULL(QDesign.ASCII(rdrICONST_MSTR_REC.GetNumber("ICONST_DATE_PERIOD_END_YY"), 4) + QDesign.ASCII(rdrICONST_MSTR_REC.GetNumber("ICONST_DATE_PERIOD_END_MM"), 2) + QDesign.ASCII(rdrICONST_MSTR_REC.GetNumber("ICONST_DATE_PERIOD_END_DD"), 2))))
            {
                blnSelected = true;
            }

            return blnSelected;
        }

        #endregion

        #region " DEFINES "

        private string X_PAT_ID_INFO()
        {
            string strReturnValue = string.Empty;

            try
            {
                if (ReportDataFunctions.Exists(rdrF010_PAT_MSTR) & QDesign.NULL(rdrF010_PAT_MSTR.GetNumber("PAT_HEALTH_NBR")) == QDesign.NULL(0d))
                {
                    strReturnValue = rdrF010_PAT_MSTR.GetString("PAT_DIRECT_ALPHA")
                        + QDesign.ASCII(rdrF010_PAT_MSTR.GetNumber("PAT_DIRECT_YY"), 2)
                        + QDesign.ASCII(rdrF010_PAT_MSTR.GetNumber("PAT_DIRECT_MM"), 2)
                        + QDesign.ASCII(rdrF010_PAT_MSTR.GetNumber("PAT_DIRECT_DD"), 2)
                        + QDesign.Substring(rdrF010_PAT_MSTR.GetString("PAT_DIRECT_LAST_6"), 1, 3);
                }
                else if (ReportDataFunctions.Exists(rdrF010_PAT_MSTR) & QDesign.NULL(rdrF010_PAT_MSTR.GetNumber("PAT_HEALTH_NBR")) != QDesign.NULL(0d))
                {
                    strReturnValue = QDesign.ASCII(rdrF010_PAT_MSTR.GetNumber("PAT_HEALTH_NBR"), 10);
                }
                else
                {
                    strReturnValue = " ";
                }
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
                strReturnValue = QDesign.Pack(rdrF020_DOCTOR_MSTR.GetString("DOC_NAME") + " " + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT1") + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT2") + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT3"));
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_PAT_NAME()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = rdrF010_PAT_MSTR.GetString("PAT_SURNAME_FIRST3").PadRight(3, ' ') + QDesign.Substring(rdrF010_PAT_MSTR.GetString("PAT_SURNAME_LAST22"), 1, 3)
                    + " " + rdrF010_PAT_MSTR.GetString("PAT_GIVEN_NAME_FIRST1") + QDesign.Substring(rdrF010_PAT_MSTR.GetString("FILLER3"), 1, 2);
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_DOC_NBR()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.Substring(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_BATCH_NBR"), 3, 3);
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private decimal ICONST_MSTR_REC_ICONST_DATE_PERIOD_END()
        {
            decimal decReturnValue = 0;

            try
            {
                decReturnValue = QDesign.NConvert(QDesign.ASCII(rdrICONST_MSTR_REC.GetNumber("ICONST_DATE_PERIOD_END_YY"), 4) + QDesign.ASCII(rdrICONST_MSTR_REC.GetNumber("ICONST_DATE_PERIOD_END_MM"), 2) + QDesign.ASCII(rdrICONST_MSTR_REC.GetNumber("ICONST_DATE_PERIOD_END_DD"), 2));
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
                AddControl(ReportSection.SUMMARY, "ICONST_DATE_PERIOD_END", DataTypes.Numeric, 8);
                AddControl(ReportSection.SUMMARY, "INDEXED.ICONST_MSTR_REC.ICONST_CLINIC_NBR_1_2", DataTypes.Numeric, 2);
                AddControl(ReportSection.SUMMARY, "INDEXED.ICONST_MSTR_REC.ICONST_CLINIC_NBR", DataTypes.Character, 4);
                AddControl(ReportSection.SUMMARY, "INDEXED.ICONST_MSTR_REC.ICONST_CLINIC_NAME", DataTypes.Character, 20);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR.CLMHDR_DOC_DEPT", DataTypes.Numeric, 2);
                AddControl(ReportSection.SUMMARY, "X_DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.SUMMARY, "X_DOC_NAME", DataTypes.Character, 27);
                AddControl(ReportSection.SUMMARY, "X_PAT_NAME", DataTypes.Character, 10);
                AddControl(ReportSection.SUMMARY, "X_PAT_ID_INFO", DataTypes.Character, 12);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR.CLMHDR_DATE_SYS", DataTypes.Character, 8);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR.CLMHDR_REFERENCE", DataTypes.Character, 11);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR.KEY_CLM_BATCH_NBR", DataTypes.Character, 8);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR.KEY_CLM_CLAIM_NBR", DataTypes.Numeric, 2);
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
        //# Do not delete, modify or move it.  Updated: 10/19/2017 11:23:51 AM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "ICONST_DATE_PERIOD_END":
                    return ICONST_MSTR_REC_ICONST_DATE_PERIOD_END().ToString().PadLeft(8,' ');

                case "INDEXED.ICONST_MSTR_REC.ICONST_CLINIC_NBR_1_2":
                    return rdrICONST_MSTR_REC.GetNumber("ICONST_CLINIC_NBR_1_2").ToString().PadLeft(2, ' ');

                case "INDEXED.ICONST_MSTR_REC.ICONST_CLINIC_NBR":
                    return Common.StringToField(rdrICONST_MSTR_REC.GetString("ICONST_CLINIC_NBR").PadRight(4, ' '));

                case "INDEXED.ICONST_MSTR_REC.ICONST_CLINIC_NAME":
                    return Common.StringToField(rdrICONST_MSTR_REC.GetString("ICONST_CLINIC_NAME").PadRight(20, ' '));

                case "INDEXED.F002_CLAIMS_MSTR.CLMHDR_DOC_DEPT":
                    return rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_DOC_DEPT").ToString().PadLeft(2, ' ');

                case "X_DOC_NBR":
                    return Common.StringToField(X_DOC_NBR().PadRight(3, ' '));

                case "X_DOC_NAME":
                    return Common.StringToField(X_DOC_NAME().PadRight(27, ' '));

                case "X_PAT_NAME":
                    return Common.StringToField(X_PAT_NAME().PadRight(10, ' '));

                case "X_PAT_ID_INFO":
                    return Common.StringToField(X_PAT_ID_INFO().PadRight(12, ' '));

                case "INDEXED.F002_CLAIMS_MSTR.CLMHDR_DATE_SYS":
                    return Common.StringToField(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_DATE_SYS").PadRight(8, ' '));

                case "INDEXED.F002_CLAIMS_MSTR.CLMHDR_REFERENCE":
                    return Common.StringToField(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_REFERENCE").PadRight(11, ' '));

                case "INDEXED.F002_CLAIMS_MSTR.KEY_CLM_BATCH_NBR":
                    return Common.StringToField(rdrF002_CLAIMS_MSTR.GetString("KEY_CLM_BATCH_NBR").PadRight(8, ' '));

                case "INDEXED.F002_CLAIMS_MSTR.KEY_CLM_CLAIM_NBR":
                    return rdrF002_CLAIMS_MSTR.GetNumber("KEY_CLM_CLAIM_NBR").ToString().PadLeft(2, ' ');

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
                    Link_F002_CLAIMS_MSTR_HDR();
                    while (rdrF002_CLAIMS_MSTR.Read())
                    {
                        Link_F010_PAT_MSTR();
                        while (rdrF010_PAT_MSTR.Read())
                        {
                            Link_ICONST_MSTR_REC();
                            while (rdrICONST_MSTR_REC.Read())
                            {
                                Link_F020_DOCTOR_MSTR();
                                while (rdrF020_DOCTOR_MSTR.Read())
                                {
                                    WriteData();
                                }
                                rdrF020_DOCTOR_MSTR.Close();
                            }
                            rdrICONST_MSTR_REC.Close();
                        }
                        rdrF010_PAT_MSTR.Close();
                    }
                    rdrF002_CLAIMS_MSTR.Close();
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
            if ((rdrF001_BATCH_CONTROL_FILE != null))
            {
                rdrF001_BATCH_CONTROL_FILE.Close();
                rdrF001_BATCH_CONTROL_FILE = null;
            }
            if ((rdrF002_CLAIMS_MSTR != null))
            {
                rdrF002_CLAIMS_MSTR.Close();
                rdrF002_CLAIMS_MSTR = null;
            }
            if ((rdrF010_PAT_MSTR != null))
            {
                rdrF010_PAT_MSTR.Close();
                rdrF010_PAT_MSTR = null;
            }
            if ((rdrICONST_MSTR_REC != null))
            {
                rdrICONST_MSTR_REC.Close();
                rdrICONST_MSTR_REC = null;
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
