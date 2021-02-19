#region "Screen Comments"

// -----------------------------------------------------------------------
// /T/ R030E.QZS PRINT NO ADJUST CLAIMS
// /A/ 
//P/ Dyad Systems Inc.
// /Q/ QZC
// /D/ PROGRAM PURPOSE : PRINT THE NO ADJUST CLAIMS ON RU030B REPORT
// /M/ Modification History
// /M/ --------------------
// /M/ Date Programmer      Description
// /M/
// /M/ 950317      BML             CREATION FROM U023.CB
// /M/ 91/MAR/04  M.C.         - ORIGINAL (SMS 138)
// /M/ 91/MAY/02  M.C.           - PDR 492
// /M/                           - SORT THE REPORT TO THE SAME AS R997.TXT
// /M/                             (IE. DEPT, DOC-NBR, CLAIM-NBR...ETC)
// /M/ 91/OCT/01  M.C.      - PDR 520
// /M/                           - SHOW THE EQUIVALENCE FLAG  ?  ON THE RPT
// /M/                          - DISPLAY  ****  FOR TWO AMOUNT BILLED DO
// /M/                             NOT MATCH.
// /M/ 93/SEP/03  M.C.        - SMS 143
// /M/                           - REDO THE REPORT FORMAT SIMILIAR TO RA
// /M/                               REPORT
// /M/ 94/JAN/12  M.C.            - SMS 144
// /M/                           - FOR THE LAST PASS, ADD THE CRITERIA FOR
// /M/                             CHECKING NO ADJUSTMENT OR AUTO ADJUSTMENT
// /M/ 95/03/16   BML          - DO NOT PRINT IF AGENT 81 AND MESSAGE CODE
// /M/                           IS EV, EA, EF, OR 48
// /M/ 96/04/14   YAS       - DO NOT PRINT IF AGENT 82 AND MESSAGE CODE
// /M/                           IS EV, EA, EF, OR 48 ADD MESS CODE I2
// /M/ 96/08/06   YAS              - DO NOT PRINT IF AGENT 83 AND MESSAGE CODE
// /M/                           IS EV, EA, EF, OR 48 ADD MESS CODE I2
// /M/ 97/09/17   M.C.             - PDR 663 - ADD SORT ON X-CLINIC-NBR AND
// /M/                              FOOTING AT X-CLINIC-NBR
// /M/ 98/03/25   YAS.           - PDR 668 - ADD CLINIC 80
// /M/      
// 2002/09/05      yas        - add new clinic 95 (AA2K)
// 2003/01/09   mc      - add a new column `charge` between registration
// number and version code
// - add f088 file to access statement 
// 2003/may/03   yas   - add new clinics AA5V AA5W AA5X AA5Y 6317 
// 2003/dec/12   A.A.  - alpha doctor nbr
// 2004/mar/03   yas   - take out clinic 96
// 2004/mar/16   M.C.  - modify select statement to ftp-flag instead of clinic nbr
// 2004/may/19   M.C.  - modify the value check on afp-flag(iconst-clinic-card-colour)
// - value `O` represents old afp  
// 2006/nov/29   M.C.  - Yasemin requested to have page break at doc nbr    
// 2008/Feb/10   yas.  - make accepted amount pic 1 digit bigger        
// 2009/Mar/04   M.C.  - DO NOT PRINT IF clinic 88 and message code is I4 and oma code is `G313`
// because they will be auto adjused in part2   
// 2009/Mar/05   M.C.  - Yasemin requests to include reason cd 36 as well since MOH has changed
// their mind for this month run
// 2013/Sep/05   MC1   - Kathy reported data overflow for claim subtotal amount 
// -----------------------------------------------------------------------
// /D/                       TRADE SECRET NOTICE
// /D/
// /D/  The techniques, algorithms, and processes contained herein, or
// /D/  any modification, extraction, or extrapolation thereof, are the
// /D/  proprietary property and trade secrets of Dyad Systems Inc.
// /D/  and except as provided for by a License Agreement, shall not be
// /D/  duplicated, used, or disclosed for any purpose, in whole or part
// /D/  without the express written permission of Dyad Systems Inc.
// -----------------------------------------------------------------------
// 2003/01/10 - MC
// ! link ((ascii(part-hdr-clinic-nbr,2) + ascii(part-hdr-claim-nbr,9)), &

#endregion

using Core.DataAccess.SqlServer;
using Core.DataAccess.TextFile;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.ReportFramework;
using System;
using System.Data;
using System.Text;

namespace RMA_DATA
{
    public class R030E1 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R030E1";
        protected const bool REPORT_HAS_PARAMETERS = false;

        //Data Helpers.
        private Reader rdrU030_NO_ADJ = new Reader();
        private Reader rdrPART_PAID_DTL = new Reader();
        private Reader rdrICONST_MSTR_REC = new Reader();
        private Reader rdrF088_RAT_REJECTED_CLAIMS_HIST_HDR = new Reader();

        #endregion

        #region " Renaissance Data "

        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;
                Sort = "X_CLINIC_NBR ASC, X_DOC_NBR ASC, PART_HDR_LAST_NAME ASC, PART_HDR_FIRST_NAME ASC, PART_HDR_REGISTER_NBR ASC, PART_HDR_CLAIM_NBR ASC";
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
        private void Access_U030_NO_ADJ()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);
            strSQL.Append("SELECT ");
            strSQL.Append("PART_HDR_CLINIC_NBR, ");
            strSQL.Append("PART_HDR_CLAIM_NBR, ");
            strSQL.Append("X_BAL_FLAG, ");
            strSQL.Append("PART_HDR_CLAIM_ID, ");
            strSQL.Append("PART_HDR_LAST_NAME, ");
            strSQL.Append("PART_HDR_FIRST_NAME, ");
            strSQL.Append("PART_HDR_REGISTER_NBR, ");
            strSQL.Append("PART_HDR_VERSION_CD, ");
            strSQL.Append("PART_HDR_PAY_PGM, ");
            strSQL.Append("PART_HDR_OHIP_CLM_NBR ");
            strSQL.Append("FROM TEMPORARYDATA.U030_NO_ADJ ");

            strSQL.Append(Choose());

            rdrU030_NO_ADJ.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);

            strSQL = null;
        }
        private void Link_PART_PAID_DTL()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);
            strSQL.Append("SELECT ");
            strSQL.Append("PART_DTL_CLINIC_NBR, ");
            strSQL.Append("PART_DTL_CLAIM_NBR, ");
            strSQL.Append("PART_DTL_AMT_PAID, ");
            strSQL.Append("PART_DTL_EXPLAN_CD, ");
            strSQL.Append("PART_DTL_OMA_CD, ");
            strSQL.Append("PART_DTL_SERV_DATE, ");
            strSQL.Append("PART_DTL_NBR_SERV, ");
            strSQL.Append("PART_DTL_AMT_BILL, ");
            strSQL.Append("PART_DTL_EQUIV_FLAG ");
            strSQL.Append("FROM SEQUENTIAL.PART_PAID_DTL ");
            strSQL.Append("WHERE ");
            strSQL.Append("PART_DTL_CLINIC_NBR = ").Append(rdrU030_NO_ADJ.GetNumber("PART_HDR_CLINIC_NBR"));
            strSQL.Append(" AND PART_DTL_CLAIM_NBR = ").Append(Common.StringToField(rdrU030_NO_ADJ.GetString("PART_HDR_CLAIM_NBR")));

            rdrPART_PAID_DTL.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.m_strFlatFileDictionary, ReportFunctions.TextFiles);

            strSQL = null;
        }
        private void Link_ICONST_MSTR_REC()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);
            strSQL.Append("SELECT ");
            strSQL.Append("ICONST_CLINIC_NBR_1_2, ");
            strSQL.Append("ICONST_DATE_PERIOD_END_YY, ");
            strSQL.Append(" ICONST_DATE_PERIOD_END_MM, ");
            strSQL.Append(" ICONST_DATE_PERIOD_END_DD, ");
            strSQL.Append("ICONST_CLINIC_CARD_COLOUR, ");
            strSQL.Append("ICONST_CLINIC_NBR ");
            strSQL.Append("FROM INDEXED.ICONST_MSTR_REC ");
            strSQL.Append("WHERE ");
            strSQL.Append("ICONST_CLINIC_NBR_1_2 = ").Append(rdrU030_NO_ADJ.GetNumber("PART_HDR_CLINIC_NBR"));

            rdrICONST_MSTR_REC.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

            strSQL = null;
        }
        private void Link_F088RATREJECTEDCLAIMSHISTHDR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);
            strSQL.Append("SELECT ");
            strSQL.Append("CLMHDR_BATCH_NBR, ");
            strSQL.Append("CLMHDR_CLAIM_NBR, ");
            strSQL.Append("PED, ");
            strSQL.Append("PART_HDR_AMT_BILL, ");
            strSQL.Append("PART_HDR_AMT_PAID, ");
            strSQL.Append("CHARGE_STATUS ");
            strSQL.Append("FROM INDEXED.F088_RAT_REJECTED_CLAIMS_HIST_HDR ");
            strSQL.Append("WHERE ");
            strSQL.Append("CLMHDR_BATCH_NBR = ").Append(Common.StringToField(QDesign.ASCII(rdrU030_NO_ADJ.GetNumber("PART_HDR_CLINIC_NBR"), 2) + QDesign.Substring(rdrU030_NO_ADJ.GetString("PART_HDR_CLAIM_NBR"), 1, 6)));
            strSQL.Append(" AND CLMHDR_CLAIM_NBR = ").Append(QDesign.NConvert(QDesign.Substring(rdrU030_NO_ADJ.GetString("PART_HDR_CLAIM_NBR"), 7, 2)));
            strSQL.Append(" AND PED = ").Append(QDesign.NConvert(QDesign.ASCII(rdrICONST_MSTR_REC.GetNumber("ICONST_DATE_PERIOD_END_YY"), 4) + QDesign.ASCII(rdrICONST_MSTR_REC.GetNumber("ICONST_DATE_PERIOD_END_MM"), 2) + QDesign.ASCII(rdrICONST_MSTR_REC.GetNumber("ICONST_DATE_PERIOD_END_DD"), 2)));

            rdrF088_RAT_REJECTED_CLAIMS_HIST_HDR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

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

            if ((QDesign.NULL(rdrICONST_MSTR_REC.GetString("ICONST_CLINIC_CARD_COLOUR")) != QDesign.NULL("O")) | ((QDesign.NULL(rdrICONST_MSTR_REC.GetString("ICONST_CLINIC_CARD_COLOUR")) == QDesign.NULL("O")) & (QDesign.NULL(rdrPART_PAID_DTL.GetNumber("PART_DTL_AMT_PAID")) != QDesign.NULL(0d) | (QDesign.NULL(rdrPART_PAID_DTL.GetString("PART_DTL_EXPLAN_CD")) != QDesign.NULL("EV") & QDesign.NULL(rdrPART_PAID_DTL.GetString("PART_DTL_EXPLAN_CD")) != QDesign.NULL("EA") & QDesign.NULL(rdrPART_PAID_DTL.GetString("PART_DTL_EXPLAN_CD")) != QDesign.NULL("EF") & QDesign.NULL(rdrPART_PAID_DTL.GetString("PART_DTL_EXPLAN_CD")) != QDesign.NULL("48") & QDesign.NULL(rdrPART_PAID_DTL.GetString("PART_DTL_EXPLAN_CD")) != QDesign.NULL("I2") & QDesign.NULL(rdrPART_PAID_DTL.GetString("PART_DTL_EXPLAN_CD")) != QDesign.NULL("  ") & (QDesign.NULL(X_CLINIC_NBR()) != QDesign.NULL("88") | QDesign.NULL(rdrPART_PAID_DTL.GetString("PART_DTL_OMA_CD")) != QDesign.NULL("G313A") | (QDesign.NULL(rdrPART_PAID_DTL.GetString("PART_DTL_EXPLAN_CD")) != QDesign.NULL("I4") & QDesign.NULL(rdrPART_PAID_DTL.GetString("PART_DTL_EXPLAN_CD")) != QDesign.NULL("36")))))))
                blnSelected = true;

            return blnSelected;
        }


        #endregion

        #region " DEFINES "

        private string X_ASTERISKS()
        {
            string strReturnValue = string.Empty;

            try
            {
                if (QDesign.NULL(rdrU030_NO_ADJ.GetString("X_BAL_FLAG")) == QDesign.NULL("N"))
                {
                    strReturnValue = "****";
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

        private string X_CLINIC_NBR()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = QDesign.Substring(rdrU030_NO_ADJ.GetString("PART_HDR_CLAIM_ID"), 1, 2);
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private decimal X_OUT_BAL()
        {
            decimal decReturnValue = 0M;
            try
            {
                decReturnValue = rdrF088_RAT_REJECTED_CLAIMS_HIST_HDR.GetNumber("PART_HDR_AMT_BILL") - rdrF088_RAT_REJECTED_CLAIMS_HIST_HDR.GetNumber("PART_HDR_AMT_PAID");
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private string X_DOC_NBR()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = QDesign.Substring(rdrU030_NO_ADJ.GetString("PART_HDR_CLAIM_ID"), 3, 3);
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_LAST_NAME()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = QDesign.Substring(rdrU030_NO_ADJ.GetString("PART_HDR_LAST_NAME"), 1, 6);
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
                strReturnValue = QDesign.Substring(rdrU030_NO_ADJ.GetString("PART_HDR_FIRST_NAME"), 1, 3);
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
                AddControl(ReportSection.PAGE_HEADING, "INDEXED.ICONST_MSTR_REC.ICONST_CLINIC_NBR", DataTypes.Character, 4);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U030_NO_ADJ.PART_HDR_CLAIM_NBR", DataTypes.Character, 8);
                AddControl(ReportSection.HEADING_AT, "X_LAST_NAME", DataTypes.Character, 6);
                AddControl(ReportSection.HEADING_AT, "X_FIRST_NAME", DataTypes.Character, 3);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U030_NO_ADJ.PART_HDR_REGISTER_NBR", DataTypes.Character, 12);
                AddControl(ReportSection.HEADING_AT, "INDEXED.F088_RAT_REJECTED_CLAIMS_HIST_HDR.CHARGE_STATUS", DataTypes.Character, 1);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U030_NO_ADJ.PART_HDR_VERSION_CD", DataTypes.Character, 2);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U030_NO_ADJ.PART_HDR_PAY_PGM", DataTypes.Character, 3);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U030_NO_ADJ.PART_HDR_OHIP_CLM_NBR", DataTypes.Character, 11);
                AddControl(ReportSection.HEADING_AT, "X_ASTERISKS", DataTypes.Character, 4);
                AddControl(ReportSection.REPORT, "SEQUENTIAL.PART_PAID_DTL.PART_DTL_SERV_DATE", DataTypes.Numeric, 8);
                AddControl(ReportSection.REPORT, "SEQUENTIAL.PART_PAID_DTL.PART_DTL_NBR_SERV", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "SEQUENTIAL.PART_PAID_DTL.PART_DTL_OMA_CD", DataTypes.Character, 5);
                AddControl(ReportSection.REPORT, "SEQUENTIAL.PART_PAID_DTL.PART_DTL_AMT_BILL", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "SEQUENTIAL.PART_PAID_DTL.PART_DTL_AMT_PAID", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "SEQUENTIAL.PART_PAID_DTL.PART_DTL_EXPLAN_CD", DataTypes.Character, 2);
                AddControl(ReportSection.REPORT, "SEQUENTIAL.PART_PAID_DTL.PART_DTL_EQUIV_FLAG", DataTypes.Character, 1);
                AddControl(ReportSection.FOOTING_AT, "X_CLINIC_NBR", DataTypes.Character, 2);
                AddControl(ReportSection.REPORT, "X_DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U030_NO_ADJ.PART_HDR_LAST_NAME", DataTypes.Character, 14);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U030_NO_ADJ.PART_HDR_FIRST_NAME", DataTypes.Character, 5);
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        #endregion

        #region " Renaissance Precompiler Generated Code "

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 1/7/2018 7:48:23 PM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "INDEXED.ICONST_MSTR_REC.ICONST_CLINIC_NBR":
                    return Common.StringToField(rdrICONST_MSTR_REC.GetString("ICONST_CLINIC_NBR").PadRight(4, ' '));

                case "TEMPORARYDATA.U030_NO_ADJ.PART_HDR_CLAIM_NBR":
                    return Common.StringToField(rdrU030_NO_ADJ.GetString("PART_HDR_CLAIM_NBR").PadRight(8, ' '));

                case "X_LAST_NAME":
                    return Common.StringToField(X_LAST_NAME(), intSize);

                case "X_FIRST_NAME":
                    return Common.StringToField(X_FIRST_NAME(), intSize);

                case "TEMPORARYDATA.U030_NO_ADJ.PART_HDR_REGISTER_NBR":
                    return Common.StringToField(rdrU030_NO_ADJ.GetString("PART_HDR_REGISTER_NBR").PadRight(12, ' '));

                case "INDEXED.F088_RAT_REJECTED_CLAIMS_HIST_HDR.CHARGE_STATUS":
                    return Common.StringToField(rdrF088_RAT_REJECTED_CLAIMS_HIST_HDR.GetString("CHARGE_STATUS").PadRight(1, ' '));

                case "TEMPORARYDATA.U030_NO_ADJ.PART_HDR_VERSION_CD":
                    return Common.StringToField(rdrU030_NO_ADJ.GetString("PART_HDR_VERSION_CD").PadRight(2, ' '));

                case "TEMPORARYDATA.U030_NO_ADJ.PART_HDR_PAY_PGM":
                    return Common.StringToField(rdrU030_NO_ADJ.GetString("PART_HDR_PAY_PGM").PadRight(3, ' ').PadRight(4, ' '));

                case "TEMPORARYDATA.U030_NO_ADJ.PART_HDR_OHIP_CLM_NBR":
                    return Common.StringToField(rdrU030_NO_ADJ.GetString("PART_HDR_OHIP_CLM_NBR").PadRight(11, ' '));

                case "X_ASTERISKS":
                    return Common.StringToField(X_ASTERISKS(), intSize);

                case "SEQUENTIAL.PART_PAID_DTL.PART_DTL_SERV_DATE":
                    return rdrPART_PAID_DTL.GetNumber("PART_DTL_SERV_DATE").ToString().PadLeft(8, ' ');

                case "SEQUENTIAL.PART_PAID_DTL.PART_DTL_NBR_SERV":
                    return rdrPART_PAID_DTL.GetNumber("PART_DTL_NBR_SERV").ToString().PadLeft(2, ' ');

                case "SEQUENTIAL.PART_PAID_DTL.PART_DTL_OMA_CD":
                    return Common.StringToField(rdrPART_PAID_DTL.GetString("PART_DTL_OMA_CD").PadRight(5, ' '));

                case "SEQUENTIAL.PART_PAID_DTL.PART_DTL_AMT_BILL":
                    return rdrPART_PAID_DTL.GetNumber("PART_DTL_AMT_BILL").ToString().PadLeft(6, ' ');

                case "SEQUENTIAL.PART_PAID_DTL.PART_DTL_AMT_PAID":
                    return rdrPART_PAID_DTL.GetNumber("PART_DTL_AMT_PAID").ToString().PadLeft(6, ' ');

                case "SEQUENTIAL.PART_PAID_DTL.PART_DTL_EXPLAN_CD":
                    return Common.StringToField(rdrPART_PAID_DTL.GetString("PART_DTL_EXPLAN_CD").PadRight(2, ' '));

                case "SEQUENTIAL.PART_PAID_DTL.PART_DTL_EQUIV_FLAG":
                    return Common.StringToField(rdrPART_PAID_DTL.GetString("PART_DTL_EQUIV_FLAG").PadRight(1, ' '));

                case "X_CLINIC_NBR":
                    return Common.StringToField(X_CLINIC_NBR(), intSize);

                case "X_DOC_NBR":
                    return Common.StringToField(X_DOC_NBR(), intSize);

                case "TEMPORARYDATA.U030_NO_ADJ.PART_HDR_LAST_NAME":
                    return Common.StringToField(rdrU030_NO_ADJ.GetString("PART_HDR_LAST_NAME").PadRight(14, ' '));

                case "TEMPORARYDATA.U030_NO_ADJ.PART_HDR_FIRST_NAME":
                    return Common.StringToField(rdrU030_NO_ADJ.GetString("PART_HDR_FIRST_NAME").PadRight(5, ' '));

                default:
                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_U030_NO_ADJ();
                while (rdrU030_NO_ADJ.Read())
                {
                    Link_PART_PAID_DTL();
                    while (rdrPART_PAID_DTL.Read())
                    {
                        Link_ICONST_MSTR_REC();
                        while (rdrICONST_MSTR_REC.Read())
                        {
                            Link_F088RATREJECTEDCLAIMSHISTHDR();
                            while (rdrF088_RAT_REJECTED_CLAIMS_HIST_HDR.Read())
                            {
                                WriteData();
                            }
                            rdrF088_RAT_REJECTED_CLAIMS_HIST_HDR.Close();
                        }

                        rdrICONST_MSTR_REC.Close();
                    }

                    rdrPART_PAID_DTL.Close();
                }

                rdrU030_NO_ADJ.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if (rdrU030_NO_ADJ != null)
            {
                rdrU030_NO_ADJ.Close();
                rdrU030_NO_ADJ = null;
            }

            if (rdrPART_PAID_DTL != null)
            {
                rdrPART_PAID_DTL.Close();
                rdrPART_PAID_DTL = null;
            }

            if (rdrICONST_MSTR_REC != null)
            {
                rdrICONST_MSTR_REC.Close();
                rdrICONST_MSTR_REC = null;
            }

            if (rdrF088_RAT_REJECTED_CLAIMS_HIST_HDR != null)
            {
                rdrF088_RAT_REJECTED_CLAIMS_HIST_HDR.Close();
                rdrF088_RAT_REJECTED_CLAIMS_HIST_HDR = null;
            }
        }

        #endregion
        #endregion
    }
}
