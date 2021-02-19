#region "Screen Comments"

//#> PROGRAM-ID.     R030D.QZS
//
//	((C)) Dyad Technologies
//
//    PROGRAM PURPOSE : PRINT THE UNMATCH CLAIMS ON RU030A REPORT
//
//    MODIFICATION HISTORY
//        DATE   WHO          DESCRIPTION
//     91/MAR/04 M.C.         - ORIGINAL (SMS 138)
//     91/SEP/10 D.B.         - CHANGE PIC FOR FINAL FOOTING
//     92/MAR/13 Y.B.	     - SAF 26
//			     - PRINT PATIENT NAME AND HEALTH NBR
//			       AND AGE CAT FOR EACH DETAIL
//			     - MODIFY ACCESS STMT TO LINK PATIENT
//			       MSTR TO EXTRACT PATIENT NAME
//     92/MAR/17 Y.B.         - MODIFY **TOTAL** WITH TRAIL "-"
//
//     92/AUG/13 M.C.         - RESET THE GROUP NBR BACK TO THE
//			       REAL ONE FOR CLINIC 61 TO 65
//     97/SEP/17 M.C.	     - PDR 663
//			     - USE X-GROUP-NBR INSTEAD OF RAT-145-GROUP-NBR
//			     - USE SORT INSTEAD OF SORTED
//			     - ADD FOOTING AT X-RAT-GROUP-NBR AND
//			       ALSO SORT ON X-RAT-GROUP-NBR
// 2002/09/05      yas        - add new clinic 95 (AA2K)  
// 2003/may/03   yas   - add new clinics AA5V AA5W AA5X AA5Y 6317
// 2004/mar/03   yas   - add new clinics 84 and 43               
// 2004/mar/16   M.C.  - add constant mstr in the access statement
//		      - modify x-rat-group-nbr definition 

#endregion

using Core.DataAccess.SqlServer;
using Core.DataAccess.TextFile;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.ReportFramework;
using System;
using System.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace RMA_DATA
{
    public class R030D1 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R030D1";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrU030_UNMATCH = new Reader();
        private Reader rdrF010_PAT_MSTR = new Reader();
        private Reader rdrICONST_MSTR_REC = new Reader();

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

                Sort = "X_RAT_GROUP_NBR ASC, RAT_145_ACCOUNT_NBR ASC";

                // Start report data processing.
                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return ReportData;
        }

        #endregion

        #region " Renaissance Statements "

        #region " ACCESS "

        private void Access_U030_UNMATCH()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);
            strSQL.Append("SELECT ");
            strSQL.Append("RAT_145_HEALTH_OHIP_NBR, ");
            strSQL.Append("X_GROUP_NBR, ");
            strSQL.Append("RAT_145_SERVICE_DATE, ");
            strSQL.Append("RAT_145_ACCOUNT_NBR, ");
            strSQL.Append("X_OMA_FOUND, ");
            strSQL.Append("RAT_145_LAST_NAME, ");
            strSQL.Append("RAT_145_FIRST_NAME, ");
            strSQL.Append("RAT_145_SERVICE_CD, ");
            strSQL.Append("RAT_145_AMT_PAID, ");
            strSQL.Append("X_TECH_AMT, ");
            strSQL.Append("X_PROF_AMT, ");
            strSQL.Append("X_TYPE ");
            strSQL.Append("FROM TEMPORARYDATA.U030_UNMATCH ");

            strSQL.Append(Choose());

            rdrU030_UNMATCH.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);

            strSQL = null;
        }
        private void Link_F010_PAT_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);
            strSQL.Append("SELECT ");
            strSQL.Append("PAT_HEALTH_NBR, ");
            strSQL.Append("PAT_SURNAME_FIRST3, ");
            strSQL.Append("PAT_SURNAME_LAST22, ");
            strSQL.Append("PAT_GIVEN_NAME_FIRST1, ");
            strSQL.Append("FILLER3 ");
            strSQL.Append("FROM INDEXED.F010_PAT_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("PAT_HEALTH_NBR = ").Append(QDesign.NConvert(rdrU030_UNMATCH.GetString("RAT_145_HEALTH_OHIP_NBR")));

            rdrF010_PAT_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

            strSQL = null;
        }
        private void Link_ICONST_MSTR_REC()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);
            strSQL.Append("SELECT ");
            strSQL.Append("ICONST_CLINIC_NBR_1_2, ");
            strSQL.Append("ICONST_CLINIC_NBR ");
            strSQL.Append("FROM INDEXED.ICONST_MSTR_REC ");
            strSQL.Append("WHERE ");
            strSQL.Append("ICONST_CLINIC_NBR_1_2 = ").Append(QDesign.NConvert(rdrU030_UNMATCH.GetString("X_GROUP_NBR")));

            rdrICONST_MSTR_REC.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

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

        public override bool SelectIf()
        {
            bool blnSelected = false;

            if (QDesign.NULL(rdrU030_UNMATCH.GetNumber("RAT_145_AMT_PAID")) != 0)
            {
                blnSelected = true;
            }

            return blnSelected;
        }

        #endregion

        #region " DEFINES "

        private decimal X_AGE_CAT()
        {
            decimal decReturnValue = 0M;
            try
            {
                decReturnValue = QDesign.Days(QDesign.SysDate(ref m_cnnQUERY)) - QDesign.Days(rdrU030_UNMATCH.GetDate("RAT_145_SERVICE_DATE"));
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private string X_CLAIM_NBR()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = rdrU030_UNMATCH.GetString("X_GROUP_NBR") + rdrU030_UNMATCH.GetString("RAT_145_ACCOUNT_NBR");
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_CLAIM_REJECT()
        {
            string strReturnValue = string.Empty;
            try
            {
                if (QDesign.NULL(rdrU030_UNMATCH.GetString("X_OMA_FOUND")) == QDesign.NULL("N"))
                {
                    strReturnValue = "*****";
                }
                else
                {
                    strReturnValue = " ";
                }
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_SURNAME()
        {
            string strReturnValue = string.Empty;
            try
            {
                if (QDesign.NULL(rdrU030_UNMATCH.GetString("RAT_145_LAST_NAME")) != QDesign.NULL(" "))
                {
                    strReturnValue = QDesign.Substring(rdrU030_UNMATCH.GetString("RAT_145_LAST_NAME"), 1, 9);
                }
                else
                {
                    strReturnValue = QDesign.Substring(rdrF010_PAT_MSTR.GetString("PAT_SURNAME_FIRST3") + rdrF010_PAT_MSTR.GetString("PAT_SURNAME_LAST22"), 1, 9);
                }
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_FIRST_NAME()
        {
            string strReturnValue = string.Empty;
            try
            {
                if (QDesign.NULL(rdrU030_UNMATCH.GetString("RAT_145_FIRST_NAME")) != QDesign.NULL(" "))
                {
                    strReturnValue = QDesign.Substring(rdrU030_UNMATCH.GetString("RAT_145_FIRST_NAME"), 1, 5);
                }
                else
                {
                    strReturnValue = QDesign.Substring(rdrF010_PAT_MSTR.GetString("PAT_GIVEN_NAME_FIRST1") + rdrF010_PAT_MSTR.GetString("FILLER3"), 1, 5);
                }
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_RAT_145_NAME()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = QDesign.Pack(X_SURNAME() + ", " + X_FIRST_NAME());
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_RAT_GROUP_NBR()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = rdrICONST_MSTR_REC.GetString("ICONST_CLINIC_NBR");
            }

            catch (Exception ex)
            {
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
                AddControl(ReportSection.PAGE_HEADING, "X_RAT_GROUP_NBR", DataTypes.Character, 4);
                AddControl(ReportSection.REPORT, "X_CLAIM_NBR", DataTypes.Character, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U030_UNMATCH.RAT_145_SERVICE_CD", DataTypes.Character, 5);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U030_UNMATCH.RAT_145_SERVICE_DATE", DataTypes.Numeric, 8);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U030_UNMATCH.RAT_145_AMT_PAID", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U030_UNMATCH.X_TECH_AMT", DataTypes.Numeric, 11);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U030_UNMATCH.X_PROF_AMT", DataTypes.Numeric, 11);
                AddControl(ReportSection.REPORT, "X_RAT_145_NAME", DataTypes.Character, 14);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U030_UNMATCH.RAT_145_HEALTH_OHIP_NBR", DataTypes.Character, 12);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U030_UNMATCH.X_TYPE", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "X_AGE_CAT", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "X_CLAIM_REJECT", DataTypes.Character, 5);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U030_UNMATCH.RAT_145_ACCOUNT_NBR", DataTypes.Character, 8);
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        #endregion

        #region " Renaissance Precompiler Generated Code "

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "X_RAT_GROUP_NBR":
                    return Common.StringToField(X_RAT_GROUP_NBR(), intSize).PadRight(4, ' ');

                case "X_CLAIM_NBR":
                    return Common.StringToField(X_CLAIM_NBR(), intSize).PadRight(10, ' ');

                case "TEMPORARYDATA.U030_UNMATCH.RAT_145_SERVICE_CD":
                    return Common.StringToField(rdrU030_UNMATCH.GetString("RAT_145_SERVICE_CD")).PadRight(5, ' ');

                case "TEMPORARYDATA.U030_UNMATCH.RAT_145_SERVICE_DATE":
                    return rdrU030_UNMATCH.GetNumber("RAT_145_SERVICE_DATE").ToString().PadLeft(8, ' ');

                case "TEMPORARYDATA.U030_UNMATCH.RAT_145_AMT_PAID":
                    return rdrU030_UNMATCH.GetNumber("RAT_145_AMT_PAID").ToString().PadLeft(10, ' ');

                case "TEMPORARYDATA.U030_UNMATCH.X_TECH_AMT":
                    return rdrU030_UNMATCH.GetNumber("X_TECH_AMT").ToString().PadLeft(11, ' ');

                case "TEMPORARYDATA.U030_UNMATCH.X_PROF_AMT":
                    return rdrU030_UNMATCH.GetNumber("X_PROF_AMT").ToString().PadLeft(11, ' ');

                case "X_RAT_145_NAME":
                    return Common.StringToField(X_RAT_145_NAME(), intSize).PadRight(14, ' ');

                case "TEMPORARYDATA.U030_UNMATCH.RAT_145_HEALTH_OHIP_NBR":
                    return Common.StringToField(rdrU030_UNMATCH.GetString("RAT_145_HEALTH_OHIP_NBR")).PadRight(12, ' ');

                case "TEMPORARYDATA.U030_UNMATCH.X_TYPE":
                    return Common.StringToField(rdrU030_UNMATCH.GetString("X_TYPE").PadRight(1, ' '));

                case "X_AGE_CAT":
                    return X_AGE_CAT().ToString().PadLeft(6, ' ');

                case "X_CLAIM_REJECT":
                    return Common.StringToField(X_CLAIM_REJECT(), intSize);

                case "TEMPORARYDATA.U030_UNMATCH.RAT_145_ACCOUNT_NBR":
                    return Common.StringToField(rdrU030_UNMATCH.GetString("RAT_145_ACCOUNT_NBR")).PadRight(8, ' ');

                default:
                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_U030_UNMATCH();
                while (rdrU030_UNMATCH.Read())
                {
                    Link_F010_PAT_MSTR();
                    while (rdrF010_PAT_MSTR.Read())
                    {
                        Link_ICONST_MSTR_REC();
                        while ((rdrICONST_MSTR_REC.Read()))
                        {
                            WriteData();
                        }

                        rdrICONST_MSTR_REC.Close();
                    }

                    rdrF010_PAT_MSTR.Close();
                }

                rdrU030_UNMATCH.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if (rdrU030_UNMATCH != null)
            {
                rdrU030_UNMATCH.Close();
                rdrU030_UNMATCH = null;
            }

            if (rdrF010_PAT_MSTR != null)
            {
                rdrF010_PAT_MSTR.Close();
                rdrF010_PAT_MSTR = null;
            }

            if (rdrICONST_MSTR_REC != null)
            {
                rdrICONST_MSTR_REC.Close();
                rdrICONST_MSTR_REC = null;
            }
        }

        #endregion
        #endregion
    }
}

