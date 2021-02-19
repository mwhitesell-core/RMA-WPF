//  #> PROGRAM-ID.     R020E.QZS
//  ((C)) Dyad Technologies
//  PROGRAM PURPOSE : SUMMARY OF CLAIMS SUBMITTED TO OHIP
//  MODIFICATION HISTORY
//  DATE   WHO          DESCRIPTION
//  91/FEB/26 D.B.         - ORIGINAL (SMS 138)
//  91/OCT/07 M.C.      - PDR 521 - OPTIMIZATION
//  - ADD A NEW PASS IN THE BEGINNING BEFORE
//  SORTING
//  92/JAN/09 Y.B.         - ADD EXTRA DIGIT TO TOTAL NUMBER OF CLAIMS
//  93/MAR/18 M.C.      - SMS 140 - SELECT ON MOH-FLAG INSTEAD OF
//  AGENT
//  93/MAY/06 M.C.      - SMS 141
//  - ADD PAT-MESS-CODE =     INTO THE SELECTION
//  FOR R020E5 PASS
//  97/AUG/21 Y.B.      - CHANGE R020E5 SORTED TO SORT BECAUSE OF
//  - GROUP CHANGES REPORTS SORTING INCORRECTLY
//  98/Aug/18 B.E.      - changed page length from 63 to 66 lines
//  99/apr/01 B.E.      - y2k
//  99/jul/20 B.E.         - added `set rep dev disc name ru020b_d(etails)`
//  to r020e5 and ru020b_s(ummary) for r020e6 and
//  eliminated `noclose` because report not going
//  to disk file
//  03/dec/12 A.A.      - alpha doctor nbr
//  16/Jan/04 MC1      - modify the last pass (r020e6) to extend the field size for revenue
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
    public class R020E1 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R020E1";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrU020A1 = new Reader();
        private Reader rdrF001_BATCH_CONTROL_FILE = new Reader();
        private Reader rdrU020E1 = new Reader();

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
                //  Create Subfile.
                SubFile = true;
                SubFileName = "U020E1";
                SubFileType = SubFileType.Keep;
                SubFileAT = "";
                Sort = "ICONST_CLINIC_NBR_1_2 ASC, W_BATCH_TYPE ASC, W_ADJ_CODE ASC, W_AGENT ASC, BATCTRL_BATCH_NBR ASC";
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
            strSQL.Append("BATCTRL_BATCH_NBR, ");
            strSQL.Append("BATCTRL_BATCH_TYPE, ");
            strSQL.Append("MOH_FLAG, ");
            strSQL.Append("BATCTRL_AGENT_CD, ");
            strSQL.Append("ICONST_CLINIC_NBR_1_2, ");
            strSQL.Append("ICONST_CLINIC_CYCLE_NBR, ");
            strSQL.Append("ICONST_DATE_PERIOD_END ");
            strSQL.Append("FROM TEMPORARYDATA.U020A1 ");

            strSQL.Append(Choose());

            rdrU020A1.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
            strSQL = null;
        }
        private void Link_F001_BATCH_CONTROL_FILE()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("BATCTRL_BATCH_NBR, ");
            strSQL.Append("BATCTRL_ADJ_CD, ");
            strSQL.Append("BATCTRL_CALC_AR_DUE, ");
            strSQL.Append("BATCTRL_CALC_TOT_REV, ");
            strSQL.Append("BATCTRL_MANUAL_PAY_TOT, ");
            strSQL.Append("BATCTRL_NBR_CLAIMS_IN_BATCH ");
            strSQL.Append("FROM INDEXED.F001_BATCH_CONTROL_FILE ");
            strSQL.Append("WHERE ");
            strSQL.Append("BATCTRL_BATCH_NBR = ").Append(Common.StringToField(rdrU020A1.GetString("BATCTRL_BATCH_NBR")));

            rdrF001_BATCH_CONTROL_FILE.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
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

        private string W_BATCH_TYPE()
        {
            string strReturnValue = string.Empty;
            try
            {
                if ((QDesign.NULL(rdrU020A1.GetString("BATCTRL_BATCH_TYPE")) == "C"))
                {
                    strReturnValue = "A";
                }
                else if ((QDesign.NULL(rdrU020A1.GetString("BATCTRL_BATCH_TYPE")) == "A")) 
                {
                    strReturnValue = "B";
                }
                else if ((QDesign.NULL(rdrU020A1.GetString("BATCTRL_BATCH_TYPE")) == "P")) 
                {
                    strReturnValue = "P";
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return strReturnValue;
        }
    
        private string W_AGENT()
        {
            string strReturnValue = string.Empty;
            try
            {
                if (((QDesign.NULL(rdrU020A1.GetString("MOH_FLAG")) == "Y") 
                            && (QDesign.NULL(rdrU020A1.GetString("BATCTRL_BATCH_TYPE")) == "C")))
                {
                    strReturnValue = "T";
                }
                else
                {
                    strReturnValue = QDesign.ASCII(rdrU020A1.GetNumber("BATCTRL_AGENT_CD"), 1);
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return strReturnValue;
        }
    
        private string W_ADJ_CODE()
        {
            string strReturnValue = string.Empty;
            try
            {
                if ((QDesign.NULL(W_BATCH_TYPE()) == "A"))
                {
                    strReturnValue = " ";
                }
                else
                {
                    strReturnValue = rdrF001_BATCH_CONTROL_FILE.GetString("BATCTRL_ADJ_CD");
                }
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
                 AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U020A1.ICONST_CLINIC_NBR_1_2", DataTypes.Numeric, 2);
                 AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U020A1.ICONST_CLINIC_CYCLE_NBR", DataTypes.Numeric, 2);
                 AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U020A1.ICONST_DATE_PERIOD_END", DataTypes.Numeric, 8);
                 AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U020A1.BATCTRL_BATCH_NBR", DataTypes.Character, 8);
                 AddControl(ReportSection.SUMMARY, "W_BATCH_TYPE", DataTypes.Character, 1);
                 AddControl(ReportSection.SUMMARY, "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_ADJ_CD", DataTypes.Character, 1);
                 AddControl(ReportSection.SUMMARY, "W_AGENT", DataTypes.Character, 1);
                 AddControl(ReportSection.SUMMARY, "W_ADJ_CODE", DataTypes.Character, 1);
                 AddControl(ReportSection.SUMMARY, "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_CALC_AR_DUE", DataTypes.Numeric, 9);
                 AddControl(ReportSection.SUMMARY, "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_CALC_TOT_REV", DataTypes.Numeric, 9);
                 AddControl(ReportSection.SUMMARY, "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_MANUAL_PAY_TOT", DataTypes.Numeric, 9);
                 AddControl(ReportSection.SUMMARY, "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_NBR_CLAIMS_IN_BATCH", DataTypes.Numeric, 2);
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
        // # Do not delete, modify or move it.  Updated: 2018-05-11 6:02:30 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "TEMPORARYDATA.U020A1.ICONST_CLINIC_NBR_1_2":
                    return rdrU020A1.GetNumber("ICONST_CLINIC_NBR_1_2").ToString();

                case "TEMPORARYDATA.U020A1.ICONST_CLINIC_CYCLE_NBR":
                    return rdrU020A1.GetNumber("ICONST_CLINIC_CYCLE_NBR").ToString();

                case "TEMPORARYDATA.U020A1.ICONST_DATE_PERIOD_END":
                    return rdrU020A1.GetNumber("ICONST_DATE_PERIOD_END").ToString();

                case "TEMPORARYDATA.U020A1.BATCTRL_BATCH_NBR":
                    return Common.StringToField(rdrU020A1.GetString("BATCTRL_BATCH_NBR"));

                case "W_BATCH_TYPE":
                    return Common.StringToField(W_BATCH_TYPE(), intSize);

                case "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_ADJ_CD":
                    return Common.StringToField(rdrF001_BATCH_CONTROL_FILE.GetString("BATCTRL_ADJ_CD"));

                case "W_AGENT":
                    return Common.StringToField(W_AGENT(), intSize);

                case "W_ADJ_CODE":
                    return Common.StringToField(W_ADJ_CODE(), intSize);

                case "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_CALC_AR_DUE":
                    return rdrF001_BATCH_CONTROL_FILE.GetNumber("BATCTRL_CALC_AR_DUE").ToString();

                case "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_CALC_TOT_REV":
                    return rdrF001_BATCH_CONTROL_FILE.GetNumber("BATCTRL_CALC_TOT_REV").ToString();

                case "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_MANUAL_PAY_TOT":
                    return rdrF001_BATCH_CONTROL_FILE.GetNumber("BATCTRL_MANUAL_PAY_TOT").ToString();

                case "INDEXED.F001_BATCH_CONTROL_FILE.BATCTRL_NBR_CLAIMS_IN_BATCH":
                    return rdrF001_BATCH_CONTROL_FILE.GetNumber("BATCTRL_NBR_CLAIMS_IN_BATCH").ToString();

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
                    Link_F001_BATCH_CONTROL_FILE();
                    while (rdrF001_BATCH_CONTROL_FILE.Read())
                    {
                        WriteData();
                    }
                
                    rdrF001_BATCH_CONTROL_FILE.Close();
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
        
            if (!(rdrF001_BATCH_CONTROL_FILE == null))
            {
                rdrF001_BATCH_CONTROL_FILE.Close();
                rdrF001_BATCH_CONTROL_FILE = null;
            }
        }

        #endregion

        #endregion
    }
}
