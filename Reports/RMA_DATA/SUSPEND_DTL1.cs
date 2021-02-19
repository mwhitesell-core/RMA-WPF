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
    public class SUSPEND_DTL1 : BaseRDLClass
    {
        protected const string REPORT_NAME = "SUSPEND_DTL1";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrF002_SUSPEND_DTL = new Reader();
        private Reader rdrF020_DOCTOR_MSTR = new Reader();
        private Reader rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR = new Reader();
        private Reader rdrF002_SUSPEND_HDR = new Reader();

        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                //  Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;
                //Sort = "CLMDTL_DOC_OHIP_NBR ASC, DOC_NBR ASC, CLMHDR_CLINIC_NBR_1_2 ASC, CLMHDR_DOC_SPEC_CD ASC, CLMHDR_PAT_ACRONYM ASC, CLMDTL_ACCOUNTING_NBR ASC, CLMDTL_OMA_CD ASC";
                Sort = "DOC_NBR ASC, CLMHDR_CLINIC_NBR_1_2 ASC, CLMHDR_DOC_SPEC_CD ASC, CLMHDR_PAT_ACRONYM ASC, CLMDTL_ACCOUNTING_NBR ASC";
                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return ReportData;
        }

        private void Access_F002_SUSPEND_DTL()
         {
            StringBuilder strSQL = new StringBuilder(String.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("CLMDTL_BATCH_NBR, ");
            strSQL.Append("CLMDTL_DOC_OHIP_NBR, ");
            strSQL.Append("CLMDTL_ACCOUNTING_NBR, ");
            strSQL.Append("CLMDTL_OMA_CD, ");
            strSQL.Append("CLMDTL_OMA_SUFF, ");
            strSQL.Append("CLMDTL_NBR_SERV, ");
            strSQL.Append("CLMDTL_SV_YY, ");
            strSQL.Append("CLMDTL_SV_MM, ");
            strSQL.Append("CLMDTL_SV_DD, ");
            strSQL.Append("CLMDTL_DIAG_CD, ");
            strSQL.Append("CLMDTL_FEE_OHIP ");
            strSQL.Append("FROM INDEXED.F002_SUSPEND_DTL ");

            strSQL.Append(Choose());

            rdrF002_SUSPEND_DTL.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.m_strFlatFileDictionary, ReportFunctions.TextFiles);

            strSQL = null;
        }

        private void Link_F020_DOCTOR_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("DOC_NAME, ");
            strSQL.Append("DOC_INIT1, ");
            strSQL.Append("DOC_INIT2, ");
            strSQL.Append("DOC_INIT3, ");
            strSQL.Append("DOC_DEPT, ");
            strSQL.Append("DOC_SPEC_CD, ");
            strSQL.Append("DOC_SPEC_CD_2, ");
            strSQL.Append("DOC_SPEC_CD_3 ");
            strSQL.Append("FROM INDEXED.F020_DOCTOR_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_NBR = ").Append(Common.StringToField(QDesign.Substring(rdrF002_SUSPEND_DTL.GetString("CLMDTL_BATCH_NBR"), 3, 3)));

            rdrF020_DOCTOR_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

            strSQL = null;
        }

        private void Link_F020C_DOC_CLINIC_NEXT_BATCH_NBR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_CLINIC_NBR, ");
            strSQL.Append("SEQ_NO, ");
            strSQL.Append("DOC_CLINIC_NBR_STATUS ");
            strSQL.Append("FROM INDEXED.F020C_DOC_CLINIC_NEXT_BATCH_NBR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_NBR = ").Append(Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_NBR")));

            rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

            strSQL = null;
        }

        private void Link_F002_SUSPEND_HDR()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("CLMHDR_DOC_OHIP_NBR, ");
            strSQL.Append("CLMHDR_ACCOUNTING_NBR, ");
            strSQL.Append("CLMHDR_BATCH_NBR, ");
            strSQL.Append("CLMHDR_DOC_SPEC_CD, ");
            strSQL.Append("CLMHDR_PAT_ACRONYM6, ");
            strSQL.Append("CLMHDR_PAT_ACRONYM3, ");
            strSQL.Append("CLMHDR_HEALTH_CARE_PROV, ");
            strSQL.Append("CLMHDR_RELATIONSHIP, ");
            strSQL.Append("CLMHDR_CONFIDENTIAL_FLAG, ");
            strSQL.Append("CLMHDR_REFER_DOC_NBR, ");
            strSQL.Append("CLMHDR_LOC, ");
            strSQL.Append("CLMHDR_I_O_PAT_IND, ");
            strSQL.Append("CLMHDR_DATE_ADMIT ");
            strSQL.Append("FROM INDEXED.F002_SUSPEND_HDR ");
            strSQL.Append("WHERE ");
            strSQL.Append("CLMHDR_DOC_OHIP_NBR = ").Append(rdrF002_SUSPEND_DTL.GetNumber("CLMDTL_DOC_OHIP_NBR"));
            strSQL.Append(" AND CLMHDR_ACCOUNTING_NBR = ").Append(Common.StringToField(rdrF002_SUSPEND_DTL.GetString("CLMDTL_ACCOUNTING_NBR")));

            rdrF002_SUSPEND_HDR.GetOptionalTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.m_strFlatFileDictionary, ReportFunctions.TextFiles);

            strSQL = null;
        }

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(String.Empty);

            return strChoose.ToString().ToString();
        }

        private string X_NAME()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = QDesign.Pack(rdrF020_DOCTOR_MSTR.GetString("DOC_NAME") + " " + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT1") + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT2") + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT3"));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_PROV()
        {
            string strReturnValue = String.Empty;
            try
            {
                if (QDesign.NULL(rdrF002_SUSPEND_HDR.GetString("CLMHDR_HEALTH_CARE_PROV")) != "ON")
                {
                    strReturnValue = rdrF002_SUSPEND_HDR.GetString("CLMHDR_HEALTH_CARE_PROV");
                }
                else
                {
                    strReturnValue = " ";
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_MR()
        {
            string strReturnValue = String.Empty;
            try
            {
                if (QDesign.NULL(rdrF002_SUSPEND_HDR.GetString("CLMHDR_RELATIONSHIP")) == "Y")
                {
                    strReturnValue = rdrF002_SUSPEND_HDR.GetString("CLMHDR_RELATIONSHIP");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_CONFIDENTIAL()
        {
            string strReturnValue = String.Empty;
            try
            {
                if (QDesign.NULL(rdrF002_SUSPEND_HDR.GetString("CLMHDR_CONFIDENTIAL_FLAG")) == "Y")
                {
                    strReturnValue = rdrF002_SUSPEND_HDR.GetString("CLMHDR_CONFIDENTIAL_FLAG");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_CLINIC_STATUS()
        {
            string strReturnValue = String.Empty;
            try
            {
                if (QDesign.NULL(rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR")) != QDesign.NULL(0d) && QDesign.NULL(rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetString("DOC_CLINIC_NBR_STATUS")) != QDesign.NULL(" "))
                {
                    strReturnValue = QDesign.ASCII(rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR")) + "(" + rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetString("DOC_CLINIC_NBR_STATUS") + ")";
                }
                else if (QDesign.NULL(rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR")) != QDesign.NULL(0d) && QDesign.NULL(rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetString("DOC_CLINIC_NBR_STATUS")) == QDesign.NULL(" "))
                {
                    strReturnValue = QDesign.ASCII(rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR"));
                }
                else
                {
                    strReturnValue = QDesign.ASCII(rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR"), 2);
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_ALL_CLINIC_STATUS()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = TMP_CLINIC_STATUS_1 + " " + TMP_CLINIC_STATUS_2 + " " + TMP_CLINIC_STATUS_3 + " " + TMP_CLINIC_STATUS_4 + " " + TMP_CLINIC_STATUS_5 + " " + TMP_CLINIC_STATUS_6;
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string F002_SUSPEND_HDR_CLMHDR_PAT_ACRONYM()
        {
            string strReturnValue = String.Empty;

            try
            {
                strReturnValue = rdrF002_SUSPEND_HDR.GetString("CLMHDR_PAT_ACRONYM6").PadRight(6, ' ') + rdrF002_SUSPEND_HDR.GetString("CLMHDR_PAT_ACRONYM3");
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string F002_SUSPEND_DTL_CLMDTL_SV_DATE()
        {
            string strReturnValue = String.Empty;

            try
            {
                strReturnValue = QDesign.ASCII(rdrF002_SUSPEND_DTL.GetNumber("CLMDTL_SV_YY"), 4) + QDesign.ASCII(rdrF002_SUSPEND_DTL.GetNumber("CLMDTL_SV_MM"), 2) + QDesign.ASCII(rdrF002_SUSPEND_DTL.GetNumber("CLMDTL_SV_DD"), 2);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string F002_SUSPEND_DTL_CLMDTL_DIAG_CD_ALPHA()
        {
            string strReturnValue = String.Empty;

            try
            {
                strReturnValue = QDesign.ASCII(rdrF002_SUSPEND_DTL.GetNumber("CLMDTL_DIAG_CD"), 3);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private decimal CLMHDR_CLINIC_NBR_1_2()
        {
            decimal decimalReturnValue = 0;

            try
            {
                decimalReturnValue = QDesign.NConvert(QDesign.Substring(rdrF002_SUSPEND_HDR.GetString("CLMHDR_BATCH_NBR"), 1, 2));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decimalReturnValue;
        }

        string TMP_CLINIC_STATUS_1;
        string TMP_CLINIC_STATUS_2;
        string TMP_CLINIC_STATUS_3;
        string TMP_CLINIC_STATUS_4;
        string TMP_CLINIC_STATUS_5;
        string TMP_CLINIC_STATUS_6;

        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.HEADING_AT, "INDEXED.F002_SUSPEND_DTL.CLMDTL_DOC_OHIP_NBR", DataTypes.Numeric, 6);
                AddControl(ReportSection.HEADING_AT, "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT", DataTypes.Numeric, 2);
                AddControl(ReportSection.HEADING_AT, "INDEXED.F020_DOCTOR_MSTR.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.HEADING_AT, "X_NAME", DataTypes.Character, 25);
                AddControl(ReportSection.HEADING_AT, "INDEXED.F020_DOCTOR_MSTR.DOC_SPEC_CD", DataTypes.Numeric, 2);
                AddControl(ReportSection.HEADING_AT, "INDEXED.F020_DOCTOR_MSTR.DOC_SPEC_CD_2", DataTypes.Numeric, 2);
                AddControl(ReportSection.HEADING_AT, "INDEXED.F020_DOCTOR_MSTR.DOC_SPEC_CD_3", DataTypes.Numeric, 2);
                AddControl(ReportSection.HEADING_AT, "X_ALL_CLINIC_STATUS", DataTypes.Character, 35);
                AddControl(ReportSection.REPORT, "INDEXED.F002_SUSPEND_DTL.CLMDTL_ACCOUNTING_NBR", DataTypes.Character, 8);
                AddControl(ReportSection.REPORT, "CLMHDR_PAT_ACRONYM", DataTypes.Character, 9);
                AddControl(ReportSection.REPORT, "INDEXED.F002_SUSPEND_DTL.CLMDTL_OMA_CD", DataTypes.Character, 4);
                AddControl(ReportSection.REPORT, "INDEXED.F002_SUSPEND_DTL.CLMDTL_OMA_SUFF", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "INDEXED.F002_SUSPEND_DTL.CLMDTL_NBR_SERV", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "CLMDTL_SV_DATE", DataTypes.Character, 8);
                AddControl(ReportSection.REPORT, "CLMDTL_DIAG_CD_ALPHA", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "INDEXED.F002_SUSPEND_DTL.CLMDTL_FEE_OHIP", DataTypes.Numeric, 7);
                AddControl(ReportSection.REPORT, "INDEXED.F002_SUSPEND_HDR.CLMHDR_REFER_DOC_NBR", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "INDEXED.F002_SUSPEND_HDR.CLMHDR_LOC", DataTypes.Character, 4);
                AddControl(ReportSection.REPORT, "INDEXED.F002_SUSPEND_HDR.CLMHDR_I_O_PAT_IND", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "INDEXED.F002_SUSPEND_HDR.CLMHDR_DATE_ADMIT", DataTypes.Character, 8);
                AddControl(ReportSection.REPORT, "X_PROV", DataTypes.Character, 2);
                AddControl(ReportSection.REPORT, "X_MR", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "X_CONFIDENTIAL", DataTypes.Character, 1);
                AddControl(ReportSection.FOOTING_AT, "CLMHDR_CLINIC_NBR_1_2", DataTypes.Numeric, 2);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F002_SUSPEND_HDR.CLMHDR_DOC_SPEC_CD", DataTypes.Numeric, 2);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2019-04-15 3:48:25 PM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "INDEXED.F002_SUSPEND_DTL.CLMDTL_DOC_OHIP_NBR":
                    return rdrF002_SUSPEND_DTL.GetNumber("CLMDTL_DOC_OHIP_NBR").ToString();

                case "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT":
                    return rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT").ToString();

                case "INDEXED.F020_DOCTOR_MSTR.DOC_NBR":
                    return Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_NBR"));

                case "X_NAME":
                    return Common.StringToField(X_NAME(), intSize);

                case "INDEXED.F020_DOCTOR_MSTR.DOC_SPEC_CD":
                    return rdrF020_DOCTOR_MSTR.GetNumber("DOC_SPEC_CD").ToString();

                case "INDEXED.F020_DOCTOR_MSTR.DOC_SPEC_CD_2":
                    return rdrF020_DOCTOR_MSTR.GetNumber("DOC_SPEC_CD_2").ToString();

                case "INDEXED.F020_DOCTOR_MSTR.DOC_SPEC_CD_3":
                    return rdrF020_DOCTOR_MSTR.GetNumber("DOC_SPEC_CD_3").ToString();

                case "X_ALL_CLINIC_STATUS":
                    return Common.StringToField(X_ALL_CLINIC_STATUS(), intSize);

                case "INDEXED.F002_SUSPEND_DTL.CLMDTL_ACCOUNTING_NBR":
                    return Common.StringToField(rdrF002_SUSPEND_DTL.GetString("CLMDTL_ACCOUNTING_NBR"));

                case "CLMHDR_PAT_ACRONYM":
                    return Common.StringToField(F002_SUSPEND_HDR_CLMHDR_PAT_ACRONYM(), intSize);

                case "INDEXED.F002_SUSPEND_DTL.CLMDTL_OMA_CD":
                    return Common.StringToField(rdrF002_SUSPEND_DTL.GetString("CLMDTL_OMA_CD"));

                case "INDEXED.F002_SUSPEND_DTL.CLMDTL_OMA_SUFF":
                    return Common.StringToField(rdrF002_SUSPEND_DTL.GetString("CLMDTL_OMA_SUFF"));

                case "INDEXED.F002_SUSPEND_DTL.CLMDTL_NBR_SERV":
                    return rdrF002_SUSPEND_DTL.GetNumber("CLMDTL_NBR_SERV").ToString();

                case "CLMDTL_SV_DATE":
                    return Common.StringToField(F002_SUSPEND_DTL_CLMDTL_SV_DATE(), intSize);

                case "CLMDTL_DIAG_CD_ALPHA":
                    return Common.StringToField(F002_SUSPEND_DTL_CLMDTL_DIAG_CD_ALPHA(), intSize);

                case "INDEXED.F002_SUSPEND_DTL.CLMDTL_FEE_OHIP":
                    return rdrF002_SUSPEND_DTL.GetNumber("CLMDTL_FEE_OHIP").ToString();

                case "INDEXED.F002_SUSPEND_HDR.CLMHDR_REFER_DOC_NBR":
                    return rdrF002_SUSPEND_HDR.GetNumber("CLMHDR_REFER_DOC_NBR").ToString();

                case "INDEXED.F002_SUSPEND_HDR.CLMHDR_LOC":
                    return Common.StringToField(rdrF002_SUSPEND_HDR.GetString("CLMHDR_LOC"));

                case "INDEXED.F002_SUSPEND_HDR.CLMHDR_I_O_PAT_IND":
                    return Common.StringToField(rdrF002_SUSPEND_HDR.GetString("CLMHDR_I_O_PAT_IND"));

                case "INDEXED.F002_SUSPEND_HDR.CLMHDR_DATE_ADMIT":
                    return Common.StringToField(rdrF002_SUSPEND_HDR.GetString("CLMHDR_DATE_ADMIT"));

                case "X_PROV":
                    return Common.StringToField(X_PROV(), intSize);

                case "X_MR":
                    return Common.StringToField(X_MR(), intSize);

                case "X_CONFIDENTIAL":
                    return Common.StringToField(X_CONFIDENTIAL(), intSize);

                case "CLMHDR_CLINIC_NBR_1_2":
                    return CLMHDR_CLINIC_NBR_1_2().ToString();

                case "INDEXED.F002_SUSPEND_HDR.CLMHDR_DOC_SPEC_CD":
                    return rdrF002_SUSPEND_HDR.GetNumber("CLMHDR_DOC_SPEC_CD").ToString();

                default:
                    return String.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_F002_SUSPEND_DTL();
                while (rdrF002_SUSPEND_DTL.Read())
                {
                    Link_F020_DOCTOR_MSTR();
                    while (rdrF020_DOCTOR_MSTR.Read())
                    {
                        Link_F020C_DOC_CLINIC_NEXT_BATCH_NBR();
                        while (rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.Read())
                        {
                            if (rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("SEQ_NO") == 1)
                            {
                                TMP_CLINIC_STATUS_1 = QDesign.Pack(X_CLINIC_STATUS());
                            }
                            else if (rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("SEQ_NO") == 2)
                            {
                                TMP_CLINIC_STATUS_2 = QDesign.Pack(X_CLINIC_STATUS());
                            }
                            else if (rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("SEQ_NO") == 3)
                            {
                                TMP_CLINIC_STATUS_3 = QDesign.Pack(X_CLINIC_STATUS());
                            }
                            else if (rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("SEQ_NO") == 4)
                            {
                                TMP_CLINIC_STATUS_4 = QDesign.Pack(X_CLINIC_STATUS());
                            }
                            else if (rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("SEQ_NO") == 5)
                            {
                                TMP_CLINIC_STATUS_5 = QDesign.Pack(X_CLINIC_STATUS());
                            }
                            else if (rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("SEQ_NO") == 6)
                            {
                                TMP_CLINIC_STATUS_6 = QDesign.Pack(X_CLINIC_STATUS());
                            }
                        }
                        rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.Close();

                            Link_F002_SUSPEND_HDR();
                            while (rdrF002_SUSPEND_HDR.Read())
                            {
                                WriteData();
                            }
                            rdrF002_SUSPEND_HDR.Close();
                    }
                    rdrF020_DOCTOR_MSTR.Close();
                }
                rdrF002_SUSPEND_DTL.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if (!(rdrF002_SUSPEND_DTL == null))
            {
                rdrF002_SUSPEND_DTL.Close();
                rdrF002_SUSPEND_DTL = null;
            }

            if (!(rdrF020_DOCTOR_MSTR == null))
            {
                rdrF020_DOCTOR_MSTR.Close();
                rdrF020_DOCTOR_MSTR = null;
            }

            if (!(rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR == null))
            {
                rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.Close();
                rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR = null;
            }

            if (!(rdrF002_SUSPEND_HDR == null))
            {
                rdrF002_SUSPEND_HDR.Close();
                rdrF002_SUSPEND_HDR = null;
            }
        }
    }
}
