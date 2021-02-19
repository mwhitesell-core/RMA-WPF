#region "Screen Comments"

//  #> PROGRAM-ID.     R030F.QZS
//  ((C)) Dyad Technologies
//  PROGRAM PURPOSE : PRINT THE AUTOMATIC ADJUSTED CLAIMS ON RU030C
//  REPORT
//  MODIFICATION HISTORY
//  DATE   WHO          DESCRIPTION
//  91/MAR/05 M.C.         - ORIGINAL (SMS 138)
//  91/OCT/01 M.C.      - PDR 520
//  - SHOW THE EQUIVALENCE FLAG  ?  ON THE RPT
//  94/JAN/12 M.C.         - SMS 144
//  - USE U030_TOT_CLAIMS SUBFILE INSTEAD OF
//  U030_AUTO_ADJ AND ADD THE SELECTION
//  CRITERIA
//  97/SEP/17 M.C.         - PDR 663
//  - ADD SORT ON X-CLINIC-NBR AND FOOTING
//  AT X-CLINIC-NBR
//  98/AUG/14 M.C.         - S149     
//  - ADD  ICONST-CLINIC-NBR-1-2 OF  ON ACCESS
//  STATEMENT
//  03/dec/12 A.A.      - alpha doctor nbr
//  07/jul/31 M.C.      - At final footing, prdecimal x-true-auto-adj-amt instead of x-auto-adj-amt in the 
//  last pass r030f2
//  ! link ( B , nconvert(part-hdr-claim-id[1:9]),  &
//  !       nconvert(part-hdr-claim-id[10:2]),  00000 ,  0 )   &

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
    public class R030F1 : BaseRDLClass
    { 
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R030F1";
        protected const bool REPORT_HAS_PARAMETERS = false;

        //Data Helpers.
        private Reader rdrU030_TOT_CLAIMS = new Reader();
        private Reader rdrF002_CLAIMS_MSTR = new Reader();
        private Reader rdrF010_PAT_MSTR = new Reader();
        private Reader rdrPART_PAID_DTL = new Reader();
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

                Sort = "X_CLINIC_NBR ASC, PART_HDR_CLAIM_ID ASC";

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

        private void Access_U030_TOT_CLAIMS()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            strSQL.Append("SELECT ");
            strSQL.Append("PART_HDR_CLAIM_ID, ");
            strSQL.Append("PART_HDR_CLINIC_NBR, ");
            strSQL.Append("PART_HDR_CLAIM_NBR, ");
            strSQL.Append("X_AUTO_ADJ, ");
            strSQL.Append("X_HOLD_BACK, ");
            strSQL.Append("X_OVER_PAY, ");
            strSQL.Append("PART_HDR_AMT_BILL, ");
            strSQL.Append("PART_HDR_AMT_PAID ");
            strSQL.Append("FROM TEMPORARYDATA.U030_TOT_CLAIMS ");
            strSQL.Append(this.Choose());
            rdrU030_TOT_CLAIMS.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
            strSQL = null;
        }
        private void Link_F002_CLAIMS_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            strSQL.Append("SELECT ");
            strSQL.Append("KEY_CLM_TYPE, ");
            strSQL.Append("KEY_CLM_BATCH_NBR, ");
            strSQL.Append("KEY_CLM_CLAIM_NBR, ");
            strSQL.Append("KEY_CLM_SERV_CODE, ");
            strSQL.Append("KEY_CLM_ADJ_NBR, ");
            strSQL.Append("CLMHDR_PAT_KEY_TYPE, ");
            strSQL.Append("CLMHDR_PAT_KEY_DATA, ");
            strSQL.Append("CLMHDR_DOC_DEPT, ");
            strSQL.Append("CLMHDR_PAT_ACRONYM6, ");
            strSQL.Append("CLMHDR_PAT_ACRONYM3, ");
            strSQL.Append("CLMHDR_LOC, ");
            strSQL.Append("CLMHDR_ADJ_CD_SUB_TYPE ");
            strSQL.Append("FROM INDEXED.F002_CLAIMS_MSTR_HDR ");
            strSQL.Append("WHERE ");
            strSQL.Append("KEY_CLM_TYPE = ").Append(Common.StringToField("B"));
            strSQL.Append(" AND KEY_CLM_BATCH_NBR = ").Append(Common.StringToField(QDesign.Substring(rdrU030_TOT_CLAIMS.GetString("PART_HDR_CLAIM_ID"), 1, 8)));
            strSQL.Append(" AND KEY_CLM_CLAIM_NBR = ").Append(QDesign.NConvert(QDesign.Substring(rdrU030_TOT_CLAIMS.GetString("PART_HDR_CLAIM_ID"), 9, 2)));
            strSQL.Append(" AND KEY_CLM_SERV_CODE = ").Append(Common.StringToField("00000"));
            strSQL.Append(" AND KEY_CLM_ADJ_NBR = ").Append(Common.StringToField("0"));
            rdrF002_CLAIMS_MSTR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_F010_PAT_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            strSQL.Append("SELECT ");
            strSQL.Append("PAT_HEALTH_NBR, ");
            strSQL.Append("PAT_DIRECT_ALPHA, ");
            strSQL.Append("PAT_DIRECT_YY, ");
            strSQL.Append("PAT_DIRECT_MM, ");
            strSQL.Append("PAT_DIRECT_DD, ");
            strSQL.Append("PAT_DIRECT_LAST_6, ");
            strSQL.Append("PAT_CHART_NBR ");
            strSQL.Append("FROM INDEXED.F010_PAT_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("PAT_I_KEY = ").Append(Common.StringToField(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_PAT_KEY_TYPE")));
            strSQL.Append(" AND PAT_CON_NBR = ").Append(Common.StringToField(QDesign.Substring(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_PAT_KEY_DATA"), 1, 2)));
            strSQL.Append(" AND PAT_I_NBR = ").Append(Common.StringToField(QDesign.Substring(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_PAT_KEY_DATA"), 3, 12)));
            strSQL.Append(" AND FILLER4 = ").Append(Common.StringToField(QDesign.Substring(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_PAT_KEY_DATA"), 15, 1)));

            rdrF010_PAT_MSTR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_Parallel_PART_PAID_DTL()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            strSQL.Append("SELECT ");
            strSQL.Append("PART_DTL_CLINIC_NBR, ");
            strSQL.Append("PART_DTL_CLAIM_NBR, ");
            strSQL.Append("PART_DTL_AMT_BILL, ");
            strSQL.Append("PART_DTL_AMT_PAID, ");
            strSQL.Append("PART_DTL_OMA_CD, ");
            strSQL.Append("PART_DTL_EXPLAN_CD, ");
            strSQL.Append("PART_DTL_EQUIV_FLAG ");
            strSQL.Append("FROM SEQUENTIAL.PART_PAID_DTL ");
            strSQL.Append("WHERE ");
            strSQL.Append("PART_DTL_CLINIC_NBR = ").Append(rdrU030_TOT_CLAIMS.GetNumber("PART_HDR_CLINIC_NBR"));
            strSQL.Append(" AND PART_DTL_CLAIM_NBR = ").Append(Common.StringToField(rdrU030_TOT_CLAIMS.GetString("PART_HDR_CLAIM_NBR")));
            rdrPART_PAID_DTL.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.m_strFlatFileDictionary, ReportFunctions.TextFiles);
            strSQL = null;
        }
        private void Link_Parallel_ICONST_MSTR_REC()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            strSQL.Append("SELECT ");
            strSQL.Append("ICONST_CLINIC_NBR_1_2, ");
            strSQL.Append("ICONST_CLINIC_NBR ");
            strSQL.Append("FROM INDEXED.ICONST_MSTR_REC ");
            strSQL.Append("WHERE ");
            strSQL.Append("ICONST_CLINIC_NBR_1_2 = ").Append(rdrPART_PAID_DTL.GetNumber("PART_DTL_CLINIC_NBR"));
            rdrICONST_MSTR_REC.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        #endregion

        #region " CHOOSE "

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(String.Empty);
            // TODO: CHOOSE Statement - May require manual changes.
            return strChoose.ToString();
        }

        #endregion

        #region " SELECT IF "

        public override bool SelectIf()
        { 
            bool blnSelected = false;
            if (((QDesign.NULL(rdrU030_TOT_CLAIMS.GetString("X_AUTO_ADJ")) == QDesign.NULL("Y"))
                        || ((QDesign.NULL(rdrU030_TOT_CLAIMS.GetString("X_HOLD_BACK")) == QDesign.NULL("Y"))
                        || (QDesign.NULL(rdrU030_TOT_CLAIMS.GetString("X_OVER_PAY")) == QDesign.NULL("Y")))))
            { 
                blnSelected = true;
            }

            return blnSelected;
        }

        #endregion

        #region " DEFINES "

        private string X_CLAIM_NBR()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = QDesign.Substring(rdrU030_TOT_CLAIMS.GetString("PART_HDR_CLAIM_ID"), 1, 10);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_CLINIC_NBR()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = QDesign.Substring(rdrU030_TOT_CLAIMS.GetString("PART_HDR_CLAIM_ID"), 1, 2);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private Decimal X_OUT_BAL()
        { 
            decimal decReturnValue = 0;

            try
            {
                decReturnValue = (rdrU030_TOT_CLAIMS.GetNumber("PART_HDR_AMT_BILL") - rdrU030_TOT_CLAIMS.GetNumber("PART_HDR_AMT_PAID"));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private string X_DOC_NBR()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = QDesign.Substring(rdrU030_TOT_CLAIMS.GetString("PART_HDR_CLAIM_ID"), 3, 3);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_PAT_ID()
        {
            string strReturnValue = String.Empty;
            try
            {
                if ((QDesign.NULL(rdrF010_PAT_MSTR.GetNumber("PAT_HEALTH_NBR")) != QDesign.NULL(0d)))
                {
                    strReturnValue = QDesign.ASCII(rdrF010_PAT_MSTR.GetNumber("PAT_HEALTH_NBR"));
                }
                else if ((QDesign.NULL(rdrF010_PAT_MSTR.GetString("PAT_DIRECT_ALPHA") + QDesign.ASCII(rdrF010_PAT_MSTR.GetNumber("PAT_DIRECT_YY")) + QDesign.ASCII(rdrF010_PAT_MSTR.GetNumber("PAT_DIRECT_MM")) + QDesign.ASCII(rdrF010_PAT_MSTR.GetNumber("PAT_DIRECT_DD")) + rdrF010_PAT_MSTR.GetString("PAT_DIRECT_LAST_6")) != QDesign.NULL(" ")))
                {
                    strReturnValue = rdrF010_PAT_MSTR.GetString("PAT_DIRECT_ALPHA") + QDesign.ASCII(rdrF010_PAT_MSTR.GetNumber("PAT_DIRECT_YY")) + QDesign.ASCII(rdrF010_PAT_MSTR.GetNumber("PAT_DIRECT_MM")) + QDesign.ASCII(rdrF010_PAT_MSTR.GetNumber("PAT_DIRECT_DD")) + rdrF010_PAT_MSTR.GetString("PAT_DIRECT_LAST_6");
                }
                else
                {
                    strReturnValue = rdrF010_PAT_MSTR.GetString("PAT_CHART_NBR");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string F002_CLAIMS_MSTR_CLMHDR_PAT_ACRONYM()
        {
            string strReturnValue = String.Empty;

            try
            {
                strReturnValue = (rdrF002_CLAIMS_MSTR.GetString("CLMHDR_PAT_ACRONYM6") + rdrF002_CLAIMS_MSTR.GetString("CLMHDR_PAT_ACRONYM3"));
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
                AddControl(ReportSection.PAGE_HEADING, "INDEXED.ICONST_MSTR_REC.ICONST_CLINIC_NBR", DataTypes.Character, 4);
                AddControl(ReportSection.HEADING_AT, "X_CLAIM_NBR", DataTypes.Character, 10);
                AddControl(ReportSection.HEADING_AT, "INDEXED.F002_CLAIMS_MSTR.CLMHDR_DOC_DEPT", DataTypes.Numeric, 2);
                AddControl(ReportSection.HEADING_AT, "X_PAT_ID", DataTypes.Character, 12);
                AddControl(ReportSection.HEADING_AT, "F002_CLAIMS_MSTR_CLMHDR_PAT_ACRONYM", DataTypes.Character, 9);
                AddControl(ReportSection.HEADING_AT, "X_DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.HEADING_AT, "INDEXED.F002_CLAIMS_MSTR.CLMHDR_LOC", DataTypes.Character, 4);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U030_TOT_CLAIMS.PART_HDR_AMT_BILL", DataTypes.Numeric, 6);
                AddControl(ReportSection.HEADING_AT, "INDEXED.F002_CLAIMS_MSTR.CLMHDR_ADJ_CD_SUB_TYPE", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "INDEXED.PART_PAID_DTL.PART_DTL_AMT_BILL", DataTypes.Numeric, 9);
                AddControl(ReportSection.REPORT, "INDEXED.PART_PAID_DTL.PART_DTL_AMT_PAID", DataTypes.Numeric, 9);
                AddControl(ReportSection.REPORT, "INDEXED.PART_PAID_DTL.PART_DTL_OMA_CD", DataTypes.Character, 5);
                AddControl(ReportSection.REPORT, "INDEXED.PART_PAID_DTL.PART_DTL_EXPLAN_CD", DataTypes.Character, 2);
                AddControl(ReportSection.REPORT, "INDEXED.PART_PAID_DTL.PART_DTL_EQUIV_FLAG", DataTypes.Character, 1);
                AddControl(ReportSection.FOOTING_AT, "X_OUT_BAL", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "X_CLINIC_NBR", DataTypes.Character, 2);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U030_TOT_CLAIMS.PART_HDR_CLAIM_ID", DataTypes.Character, 10);
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
        // # Do not delete, modify or move it.  Updated: 1/8/2018 9:31:23 AM

        public override string ReturnControlValue(string strControl, int intSize)
        { 
            switch (strControl)
            {
                case "INDEXED.ICONST_MSTR_REC.ICONST_CLINIC_NBR":
                    return Common.StringToField(rdrICONST_MSTR_REC.GetString("ICONST_CLINIC_NBR").PadRight(4, ' '));

                case "X_CLAIM_NBR":
                    return Common.StringToField(X_CLAIM_NBR(), intSize);

                case "INDEXED.F002_CLAIMS_MSTR.CLMHDR_DOC_DEPT":
                    return rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_DOC_DEPT").ToString().PadLeft(2, ' ');

                case "X_PAT_ID":
                    return Common.StringToField(X_PAT_ID(), intSize);

                case "F002_CLAIMS_MSTR_CLMHDR_PAT_ACRONYM":
                    return Common.StringToField(F002_CLAIMS_MSTR_CLMHDR_PAT_ACRONYM().PadRight(9, ' '));

                case "X_DOC_NBR":
                    return Common.StringToField(X_DOC_NBR(), intSize);

                case "INDEXED.F002_CLAIMS_MSTR.CLMHDR_LOC":
                    return Common.StringToField(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_LOC").PadRight(4, ' '));

                case "TEMPORARYDATA.U030_TOT_CLAIMS.PART_HDR_AMT_BILL":
                    return rdrU030_TOT_CLAIMS.GetNumber("PART_HDR_AMT_BILL").ToString().PadLeft(6, ' ');

                case "INDEXED.F002_CLAIMS_MSTR.CLMHDR_ADJ_CD_SUB_TYPE":
                    return Common.StringToField(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_ADJ_CD_SUB_TYPE").PadRight(1, ' '));

                case "INDEXED.PART_PAID_DTL.PART_DTL_AMT_BILL":
                    return rdrPART_PAID_DTL.GetNumber("PART_DTL_AMT_BILL").ToString().PadLeft(9, ' ');

                case "INDEXED.PART_PAID_DTL.PART_DTL_AMT_PAID":
                    return rdrPART_PAID_DTL.GetNumber("PART_DTL_AMT_PAID").ToString().PadLeft(9, ' ');

                case "INDEXED.PART_PAID_DTL.PART_DTL_OMA_CD":
                    return Common.StringToField(rdrPART_PAID_DTL.GetString("PART_DTL_OMA_CD").PadRight(5, ' '));

                case "INDEXED.PART_PAID_DTL.PART_DTL_EXPLAN_CD":
                    return Common.StringToField(rdrPART_PAID_DTL.GetString("PART_DTL_EXPLAN_CD").PadRight(2, ' '));

                case "INDEXED.PART_PAID_DTL.PART_DTL_EQUIV_FLAG":
                    return Common.StringToField(rdrPART_PAID_DTL.GetString("PART_DTL_EQUIV_FLAG").PadRight(1, ' '));

                case "X_OUT_BAL":
                    return X_OUT_BAL().ToString();

                case "X_CLINIC_NBR":
                    return Common.StringToField(X_CLINIC_NBR(), intSize);

                case "TEMPORARYDATA.U030_TOT_CLAIMS.PART_HDR_CLAIM_ID":
                    return Common.StringToField(rdrU030_TOT_CLAIMS.GetString("PART_HDR_CLAIM_ID"));

                default:
                    return String.Empty;
            }
        }

        public override void AccessData()
        {
            try
            { 
                Access_U030_TOT_CLAIMS();

                while (rdrU030_TOT_CLAIMS.Read())
                { 
                    Link_F002_CLAIMS_MSTR();

                while (rdrF002_CLAIMS_MSTR.Read())
                    { 
                        Link_F010_PAT_MSTR();
                        Link_Parallel_PART_PAID_DTL();
                        Link_Parallel_ICONST_MSTR_REC();
                        while (rdrICONST_MSTR_REC.Read() | rdrF010_PAT_MSTR.Read() | rdrPART_PAID_DTL.Read())
                        {
                            WriteData();
                        }
                        rdrICONST_MSTR_REC.Close();
                        rdrPART_PAID_DTL.Close();
                        rdrF010_PAT_MSTR.Close();
                    }
                    rdrF002_CLAIMS_MSTR.Close();
                }
                rdrU030_TOT_CLAIMS.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrU030_TOT_CLAIMS != null))
            {
                rdrU030_TOT_CLAIMS.Close();
                rdrU030_TOT_CLAIMS = null;
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

            if ((rdrPART_PAID_DTL != null))
            {
                rdrPART_PAID_DTL.Close();
                rdrPART_PAID_DTL = null;
            }

            if ((rdrICONST_MSTR_REC != null))
            {
                rdrICONST_MSTR_REC.Close();
                rdrICONST_MSTR_REC = null;
            }
        }

        #endregion
        #endregion
    }
}
 


