#region "Screen Comments"

// #> PROGRAM-ID.     U030AA3.QZS
// ((C)) Dyad Technologies
// PROGRAM PURPOSE : PRINT THE UNMATCH CLAIMS ON RU030A REPORT
// MODIFICATION HISTORY
// DATE   WHO          DESCRIPTION
// 98/JAN/04 Y.B.         - ORIGINAL (PDR 667)
// 2001/MAY/29 M.C.      - Yas requested to add f002-claims-mstr in the
// access statement and sel if clmhdr-adj-cd-sub-type <> `D`
// 2003/JUN/10 M.C.      - include clinic-nbr to link to f071
// 2003/dec/16 A.A.      - alpha doctor nbr
// 2004/mar/08 yas          - select if adj sub type = W only
// 2004/Apr/27 yas          - select if adj sub type = W and C
// 2004/Jul/13 M.C.      - Yas reqested not to show on the report if claims in f002
// has reason code I2 and incoming record has reason code 35
// 2005/jun/22 M.C.      - user may forget to add doc record in f073 file, hence no
// report generated for the doctors.  Add optional to f073 each file
// in the access will generate the report.
// 2005/aug/30 M.C.      - Do not show on the report if incoming record has reason code 35
// and (clmhdr payment not equal to 0 or clmhdr status = `I2`)
// set stacksize 1500
// !       link (ncon(rat-145-account-nbr[1:3]))   &
// 2005/06/22 - MC
// to doc-nbr of f073-client-doc-mstr        &
// 2005/06/22- end
// 2003/06/10 - MC
// link (nconvert(rat-145-account-nbr))    &
// to claim-nbr-rma  of  f071-client-rma-claim-nbr  &
// !      nconvert(rat-145-account-nbr))    &
// 2003/06/10 - end
// !      nconvert(ascii(clinic-nbr,2)    &
// !      + `0`       &
// !      + ascii(claim-nbr-rma,8)[1:6]),   &
// !              nconvert(ascii(claim-nbr-rma,8)[7:2]), &

#endregion

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
    public class U030AA3 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "U030AA3";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrU030_TAPE_145_FILE = new Reader();
        private Reader rdrF073_CLIENT_DOC_MSTR = new Reader();
        private Reader rdrF071_CLIENT_RMA_CLAIM_NBR = new Reader();
        private Reader rdrF002_CLAIMS_MSTR = new Reader();
        private Reader rdrF002_CLAIMS_MSTR_DTL = new Reader();

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

        private void Access_U030_TAPE_145_FILE()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("RAT_145_ACCOUNT_NBR, ");
            strSQL.Append("RAT_145_GROUP_NBR, ");
            strSQL.Append("RAT_145_EXPLAN_CD, ");
            strSQL.Append("RAT_145_SERVICE_CD, ");
            strSQL.Append("RAT_145_AMT_PAID ");
            strSQL.Append("FROM SEQUENTIAL.U030_TAPE_145_FILE ");

            strSQL.Append(Choose());

            rdrU030_TAPE_145_FILE.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.m_strFlatFileDictionary, ReportFunctions.TextFiles);

            strSQL = null;
        }
        private void Link_F073_CLIENT_DOC_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR ");
            strSQL.Append("FROM INDEXED.F073_CLIENT_DOC_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_NBR = ").Append(Common.StringToField(QDesign.Substring(rdrU030_TAPE_145_FILE.GetString("RAT_145_ACCOUNT_NBR"), 1, 3)));

            rdrF073_CLIENT_DOC_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

            strSQL = null;
        }
        private void Link_F071_CLIENT_RMA_CLAIM_NBR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("CLINIC_NBR, ");
            strSQL.Append("CLAIM_NBR_RMA, ");
            strSQL.Append("CLAIM_NBR_CLIENT ");
            strSQL.Append("FROM INDEXED.F071_CLIENT_RMA_CLAIM_NBR ");
            strSQL.Append("WHERE ");
            strSQL.Append("CLINIC_NBR = ").Append(QDesign.NConvert(QDesign.Substring(rdrU030_TAPE_145_FILE.GetString("RAT_145_GROUP_NBR"), 1, 2)));
            strSQL.Append(" AND CLAIM_NBR_RMA = ").Append(Common.StringToField(rdrU030_TAPE_145_FILE.GetString("RAT_145_ACCOUNT_NBR")));

            rdrF071_CLIENT_RMA_CLAIM_NBR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

            strSQL = null;
        }
        private void Link_F002_CLAIMS_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("KEY_CLM_TYPE, ");
            strSQL.Append("KEY_CLM_BATCH_NBR, ");
            strSQL.Append("KEY_CLM_CLAIM_NBR, ");
            strSQL.Append("KEY_CLM_SERV_CODE, ");
            strSQL.Append("KEY_CLM_ADJ_NBR, ");
            strSQL.Append("CLMHDR_ADJ_CD_SUB_TYPE, ");
            strSQL.Append("CLMHDR_STATUS_OHIP, ");
            strSQL.Append("CLMHDR_MANUAL_AND_TAPE_PAYMENTS ");
            strSQL.Append("FROM INDEXED.F002_CLAIMS_MSTR_HDR ");
            strSQL.Append("WHERE ");
            strSQL.Append("KEY_CLM_TYPE = ").Append(Common.StringToField("B"));
            strSQL.Append(" AND KEY_CLM_BATCH_NBR = ").Append(Common.StringToField(QDesign.ASCII(rdrF071_CLIENT_RMA_CLAIM_NBR.GetNumber("CLINIC_NBR"), 2) + QDesign.Substring(rdrF071_CLIENT_RMA_CLAIM_NBR.GetString("CLAIM_NBR_RMA"), 1, 6)));
            strSQL.Append(" AND KEY_CLM_CLAIM_NBR = ").Append(QDesign.NConvert(QDesign.Substring(rdrF071_CLIENT_RMA_CLAIM_NBR.GetString("CLAIM_NBR_RMA"), 7, 2)));
            strSQL.Append(" AND KEY_CLM_SERV_CODE = ").Append(Common.StringToField("00000"));
            strSQL.Append(" AND KEY_CLM_ADJ_NBR = ").Append(Common.StringToField("0"));

            rdrF002_CLAIMS_MSTR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

            strSQL = null;
        }

        private void Link_F002_CLAIMS_MSTR_DTL()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("KEY_CLM_TYPE ");
            strSQL.Append("FROM INDEXED.F002_CLAIMS_MSTR_DTL ");
            strSQL.Append("WHERE ");
            strSQL.Append("KEY_CLM_TYPE = ").Append(Common.StringToField(rdrF002_CLAIMS_MSTR.GetString("KEY_CLM_TYPE")));
            strSQL.Append(" AND KEY_CLM_BATCH_NBR = ").Append(Common.StringToField(rdrF002_CLAIMS_MSTR.GetString("KEY_CLM_BATCH_NBR")));
            strSQL.Append(" AND KEY_CLM_CLAIM_NBR = ").Append(rdrF002_CLAIMS_MSTR.GetNumber("KEY_CLM_CLAIM_NBR"));

            rdrF002_CLAIMS_MSTR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

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

            if ((QDesign.NULL(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_ADJ_CD_SUB_TYPE")) == QDesign.NULL("W") | QDesign.NULL(rdrF002_CLAIMS_MSTR.GetString("CLMHDR_ADJ_CD_SUB_TYPE")) == QDesign.NULL("C")))
            {
                if (rdrU030_TAPE_145_FILE.GetString("RAT_145_EXPLAN_CD") != "35" | (rdrF002_CLAIMS_MSTR.GetString("CLMHDR_STATUS_OHIP") != "I2" & rdrF002_CLAIMS_MSTR.GetNumber("CLMHDR_MANUAL_AND_TAPE_PAYMENTS") == 0))
                {
                    blnSelected = true;
                }
            }

            return blnSelected;
        }

        #endregion

        #region " DEFINES "

        private string DOC_ACCOUNT_NBR()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.Substring(rdrF071_CLIENT_RMA_CLAIM_NBR.GetString("CLAIM_NBR_CLIENT"), 7, 8);
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
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
                AddControl(ReportSection.REPORT, "DOC_ACCOUNT_NBR", DataTypes.Character, 8);
                AddControl(ReportSection.REPORT, "SEQUENTIAL.U030_TAPE_145_FILE.RAT_145_SERVICE_CD", DataTypes.Character, 5);
                AddControl(ReportSection.REPORT, "SEQUENTIAL.U030_TAPE_145_FILE.RAT_145_AMT_PAID", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "SEQUENTIAL.U030_TAPE_145_FILE.RAT_145_EXPLAN_CD", DataTypes.Character, 2);
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
        //# Do not delete, modify or move it.  Updated: 9/28/2017 2:04:59 PM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "DOC_ACCOUNT_NBR":
                    return Common.StringToField(DOC_ACCOUNT_NBR().PadRight(8, ' '));

                case "SEQUENTIAL.U030_TAPE_145_FILE.RAT_145_SERVICE_CD":
                    return Common.StringToField(rdrU030_TAPE_145_FILE.GetString("RAT_145_SERVICE_CD").PadRight(5, ' '));

                case "SEQUENTIAL.U030_TAPE_145_FILE.RAT_145_AMT_PAID":
                        return rdrU030_TAPE_145_FILE.GetNumber("RAT_145_AMT_PAID").ToString().PadLeft(6, ' ');

                case "SEQUENTIAL.U030_TAPE_145_FILE.RAT_145_EXPLAN_CD":
                    return Common.StringToField(rdrU030_TAPE_145_FILE.GetString("RAT_145_EXPLAN_CD").PadRight(2, ' '));

                default:

                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_U030_TAPE_145_FILE();

                while (rdrU030_TAPE_145_FILE.Read())
                {
                    Link_F073_CLIENT_DOC_MSTR();
                    while (rdrF073_CLIENT_DOC_MSTR.Read())
                    {
                        Link_F071_CLIENT_RMA_CLAIM_NBR();
                        while (rdrF071_CLIENT_RMA_CLAIM_NBR.Read())
                        {
                            Link_F002_CLAIMS_MSTR();
                            while (rdrF002_CLAIMS_MSTR.Read())
                            {
                                WriteData();
                            }
                            rdrF002_CLAIMS_MSTR.Close();
                        }
                        rdrF071_CLIENT_RMA_CLAIM_NBR.Close();
                    }
                    rdrF073_CLIENT_DOC_MSTR.Close();
                }
                rdrU030_TAPE_145_FILE.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrU030_TAPE_145_FILE != null))
            {
                rdrU030_TAPE_145_FILE.Close();
                rdrU030_TAPE_145_FILE = null;
            }

            if ((rdrF073_CLIENT_DOC_MSTR != null))
            {
                rdrF073_CLIENT_DOC_MSTR.Close();
                rdrF073_CLIENT_DOC_MSTR = null;
            }

            if ((rdrF071_CLIENT_RMA_CLAIM_NBR != null))
            {
                rdrF071_CLIENT_RMA_CLAIM_NBR.Close();
                rdrF071_CLIENT_RMA_CLAIM_NBR = null;
            }

            if ((rdrF002_CLAIMS_MSTR != null))
            {
                rdrF002_CLAIMS_MSTR.Close();
                rdrF002_CLAIMS_MSTR = null;
            }

            if ((rdrF002_CLAIMS_MSTR_DTL != null))
            {
                rdrF002_CLAIMS_MSTR_DTL.Close();
                rdrF002_CLAIMS_MSTR_DTL = null;
            }
        }

        #endregion

        #endregion
    }
}
