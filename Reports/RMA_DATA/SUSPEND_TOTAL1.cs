//  02/04/02       yas             add clinic 85(represents payroll B)
//  02/08/23       yas             add clinic 95(represents oncology clinic)
//  03/08/23       yasmin          add clinic 91,92,93,94,96
//  04/04/07       MC              alpha doc nbr
//  2004/jun/07    yasemin         add new afp clinic 31-59
//  2004/oct/22    yasemin         add new afp clinic  46 
//  2005/feb/08    yasemin         add new clinic 86
//  2006/jun/01    MC              change the file sequence in access statement
//  use clmhdr-doc-nbr to link to f020
//  2007/apr/15    yasemin         add new clinics 71-75
//  2007/Nov/20    yasemin         add new clinic 87        
//  2008/April     yasemin         add new clinic 37
//  2008/Oct       yasemin         add new clinic 88
//  2009/Apr       yasemin         add new clinic 89
//  2009/Jun       yasemin         add new clinic 79
//  2009/Jun       yasemin         add new clinic 78
//  2010/Feb       yasemin         add new clinic 66
//  2011/Jan/12    yasemin         add new clinic 23
//  2012/Jan/23    yasemin         add new clinic 24
//  2012/Jun/08    yasemin         add new clinic 25
//  2014/Apr/03    yasemin         add new clinic 69
//  2014/May/06    yasemin         add new clinic 68
//  2014/Oct/17    yasemin         add new clinic 30
//  2015/Mar/10    yasemin         add new clinic 26
//  2016/Apr/11    MC1             correct programming so that do not need to hardcode each new clinic
//  2016/May/31    MC2  correct programming to ignore the duplicate sort break, include page number

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
    public class SUSPEND_TOTAL1 : BaseRDLClass
    {
        protected const string REPORT_NAME = "SUSPEND_TOTAL1";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrF002_SUSPEND_DTL = new Reader();
        private Reader rdrF002_SUSPEND_HDR = new Reader();
        private Reader rdrF020_DOCTOR_MSTR = new Reader();
        private Reader rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR = new Reader();

        // #CORE_BEGIN_INCLUDE: DEF_CLMHDR_STATUS"
        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2019-04-15 3:47:29 PM
        private string CLMHDR_STATUS_COMPLETE()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = "C";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string CLMHDR_STATUS_DELETE()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = "D";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string CLMHDR_STATUS_CANCEL()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = "Y";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string CLMHDR_STATUS_RESUBMIT()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = "R";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string CLMHDR_STATUS_ERROR()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = "X";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string CLMHDR_STATUS_NOT_COMPLETE()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = "N";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string CLMHDR_STATUS_DEFAULT()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = " ";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string UPDATED()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = "U";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string CLMHDR_STATUS_IGNOR()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = "I";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        // #CORE_END_INCLUDE: DEF_CLMHDR_STATUS"

        // #CORE_BEGIN_INCLUDE: DEF_CLMDTL_STATUS"
        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2019-04-15 3:47:29 PM
        private string CLMDTL_STATUS_DELETE()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = "D";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string CLMDTL_STATUS_NEW()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = "N";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string CLMDTL_STATUS_ACTIVE()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = " ";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string CLMDTL_STATUS_UPDATED()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = "U";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                //  Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;
                Sort = "DOC_NBR ASC, CLMHDR_CLINIC_NBR_1_2 ASC, CLMHDR_DOC_SPEC_CD ASC, CLMDTL_ACCOUNTING_NBR ASC";
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
            strSQL.Append("CLMDTL_DOC_OHIP_NBR, ");
            strSQL.Append("CLMDTL_ACCOUNTING_NBR, ");
            strSQL.Append("CLMDTL_STATUS, ");
            strSQL.Append("CLMDTL_NBR_SERV, ");
            strSQL.Append("CLMDTL_FEE_OHIP ");
            strSQL.Append("FROM INDEXED.F002_SUSPEND_DTL ");

            strSQL.Append(Choose());

            rdrF002_SUSPEND_DTL.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.m_strFlatFileDictionary, ReportFunctions.TextFiles);

            strSQL = null;
        }

        private void Link_F002_SUSPEND_HDR()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("CLMHDR_DOC_OHIP_NBR, ");
            strSQL.Append("CLMHDR_ACCOUNTING_NBR, ");
            strSQL.Append("CLMHDR_STATUS, ");
            strSQL.Append("CLMHDR_BATCH_NBR, ");
            strSQL.Append("CLMHDR_DOC_SPEC_CD, ");
            strSQL.Append("CLMHDR_HEALTH_CARE_PROV, ");
            strSQL.Append("CLMHDR_RELATIONSHIP, ");
            strSQL.Append("CLMHDR_PAT_KEY_DATA");
            strSQL.Append("FROM INDEXED.F002_SUSPEND_HDR ");
            strSQL.Append("WHERE ");
            strSQL.Append("CLMHDR_DOC_OHIP_NBR = ").Append(rdrF002_SUSPEND_DTL.GetNumber("CLMDTL_DOC_OHIP_NBR"));
            strSQL.Append(" AND CLMHDR_ACCOUNTING_NBR = ").Append(Common.StringToField(rdrF002_SUSPEND_DTL.GetString("CLMDTL_ACCOUNTING_NBR")));

            rdrF002_SUSPEND_HDR.GetOptionalTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.m_strFlatFileDictionary, ReportFunctions.TextFiles);

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
            strSQL.Append("DOC_NBR = ").Append(Common.StringToField(QDesign.Substring(rdrF002_SUSPEND_HDR.GetString("CLMHDR_BATCH_NBR"), 3, 3)));

            rdrF020_DOCTOR_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

            strSQL = null;
        }

        private void Link_F020C_DOC_CLINIC_NEXT_BATCH_NBR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_CLINIC_NBR, ");
            strSQL.Append("SEQ_NO ");
            strSQL.Append("FROM INDEXED.F020C_DOC_CLINIC_NEXT_BATCH_NBR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_NBR = ").Append(Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_NBR")));

            rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

            strSQL = null;
        }

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(String.Empty);

            return strChoose.ToString().ToString();
        }

        public override bool SelectIf()
        {
            bool blnSelected = false;
            if (QDesign.NULL(rdrF002_SUSPEND_HDR.GetString("CLMHDR_STATUS")) != QDesign.NULL(CLMHDR_STATUS_DELETE()) && QDesign.NULL(rdrF002_SUSPEND_DTL.GetString("CLMDTL_STATUS")) != QDesign.NULL(CLMDTL_STATUS_DELETE()) && QDesign.NULL(rdrF002_SUSPEND_HDR.GetString("CLMHDR_STATUS")) != QDesign.NULL(CLMHDR_STATUS_IGNOR()))
            {
                blnSelected = true;
            }

            return blnSelected;
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

        decimal TMP_DOC_CLINIC_NBR_1;
        decimal TMP_DOC_CLINIC_NBR_2;
        decimal TMP_DOC_CLINIC_NBR_3;
        decimal TMP_DOC_CLINIC_NBR_4;
        decimal TMP_DOC_CLINIC_NBR_5;
        decimal TMP_DOC_CLINIC_NBR_6;

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
                AddControl(ReportSection.HEADING_AT, "DOC_CLINIC_NBR", DataTypes.Numeric, 2);
                AddControl(ReportSection.HEADING_AT, "DOC_CLINIC_NBR_2", DataTypes.Numeric, 2);
                AddControl(ReportSection.HEADING_AT, "DOC_CLINIC_NBR_3", DataTypes.Numeric, 2);
                AddControl(ReportSection.HEADING_AT, "DOC_CLINIC_NBR_4", DataTypes.Numeric, 2);
                AddControl(ReportSection.HEADING_AT, "DOC_CLINIC_NBR_5", DataTypes.Numeric, 2);
                AddControl(ReportSection.HEADING_AT, "DOC_CLINIC_NBR_6", DataTypes.Numeric, 2);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F002_SUSPEND_DTL.CLMDTL_NBR_SERV", DataTypes.Numeric, 2);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F002_SUSPEND_DTL.CLMDTL_FEE_OHIP", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "CLMHDR_CLINIC_NBR_1_2", DataTypes.Numeric, 2);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F002_SUSPEND_HDR.CLMHDR_DOC_SPEC_CD", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "INDEXED.F002_SUSPEND_DTL.CLMDTL_ACCOUNTING_NBR", DataTypes.Character, 8);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F002_SUSPEND_HDR.CLMHDR_PAT_KEY_DATA", DataTypes.Character, 15);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2019-04-15 3:47:44 PM
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

                case "DOC_CLINIC_NBR":
                    return TMP_DOC_CLINIC_NBR_1.ToString();

                case "DOC_CLINIC_NBR_2":
                    return TMP_DOC_CLINIC_NBR_2.ToString();

                case "DOC_CLINIC_NBR_3":
                    return TMP_DOC_CLINIC_NBR_3.ToString();

                case "DOC_CLINIC_NBR_4":
                    return TMP_DOC_CLINIC_NBR_4.ToString();
                        
                case "DOC_CLINIC_NBR_5":
                    return TMP_DOC_CLINIC_NBR_5.ToString();

                case "DOC_CLINIC_NBR_6":
                    return TMP_DOC_CLINIC_NBR_6.ToString();

                case "INDEXED.F002_SUSPEND_DTL.CLMDTL_NBR_SERV":
                    return rdrF002_SUSPEND_DTL.GetNumber("CLMDTL_NBR_SERV").ToString();

                case "INDEXED.F002_SUSPEND_DTL.CLMDTL_FEE_OHIP":
                    return rdrF002_SUSPEND_DTL.GetNumber("CLMDTL_FEE_OHIP").ToString();

                case "CLMHDR_CLINIC_NBR_1_2":
                    return CLMHDR_CLINIC_NBR_1_2().ToString();

                case "INDEXED.F002_SUSPEND_HDR.CLMHDR_DOC_SPEC_CD":
                    return rdrF002_SUSPEND_HDR.GetNumber("CLMHDR_DOC_SPEC_CD").ToString();

                case "INDEXED.F002_SUSPEND_DTL.CLMDTL_ACCOUNTING_NBR":
                    return Common.StringToField(rdrF002_SUSPEND_DTL.GetString("CLMDTL_ACCOUNTING_NBR"));

                case "INDEXED.F002_SUSPEND_HDR.CLMHDR_PAT_KEY_DATA":
                    return Common.StringToField(rdrF002_SUSPEND_HDR.GetString("CLMHDR_PAT_KEY_DATA"));

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
                    Link_F002_SUSPEND_HDR();
                    while (rdrF002_SUSPEND_HDR.Read())
                    {
                        Link_F020_DOCTOR_MSTR();
                        while (rdrF020_DOCTOR_MSTR.Read())
                        {
                            Link_F020C_DOC_CLINIC_NEXT_BATCH_NBR();
                            while (rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.Read())
                            {
                                if (rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("SEQ_NO") == 1)
                                {
                                    TMP_DOC_CLINIC_NBR_1 = rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR");
                                }
                                else if (rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("SEQ_NO") == 2)
                                {
                                    TMP_DOC_CLINIC_NBR_2 = rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR");
                                }
                                else if (rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("SEQ_NO") == 3)
                                {
                                    TMP_DOC_CLINIC_NBR_3 = rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR");
                                }
                                else if (rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("SEQ_NO") == 4)
                                {
                                    TMP_DOC_CLINIC_NBR_4 = rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR");
                                }
                                else if (rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("SEQ_NO") == 5)
                                {
                                    TMP_DOC_CLINIC_NBR_5 = rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR");
                                }
                                else if (rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("SEQ_NO") == 6)
                                {
                                    TMP_DOC_CLINIC_NBR_6 = rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR");
                                }
                            }
                            rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.Close();

                            WriteData();
                        }
                        rdrF020_DOCTOR_MSTR.Close();
                    }
                    rdrF002_SUSPEND_HDR.Close();
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

            if (!(rdrF002_SUSPEND_HDR == null))
            {
                rdrF002_SUSPEND_HDR.Close();
                rdrF002_SUSPEND_HDR = null;
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
        }
    }
}
