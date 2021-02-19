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
    public class R702 : BaseRDLClass
    {
        protected const string REPORT_NAME = "R702";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrF002_SUSPEND_HDR = new Reader();
        private Reader rdrF002_SUSPEND_ADDRESS = new Reader();
        // #CORE_BEGIN_INCLUDE: DEF_CLMHDR_STATUS"
        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-05-15 3:04:05 PM
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
        private Reader rdrSUBMIT_DISK_PAT_IN = new Reader();
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
                SubFileName = "SUBMIT_DISK_PAT_IN";
                SubFileType = SubFileType.Keep;
                SubFileAT = "TODO: Enter sortbreak name";
                Sort = "CLMHDR_DOC_NBR ASC";
                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return ReportData;
        }
        private void Access_F002_SUSPEND_HDR()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            strSQL.Append("SELECT ");
            strSQL.Append("CLMHDR_DOC_OHIP_NBR, ");
            strSQL.Append("CLMHDR_ACCOUNTING_NBR, ");
            strSQL.Append("CLMHDR_BATCH_NBR, ");
            strSQL.Append("CLMHDR_PAT_KEY_TYPE, ");
            strSQL.Append("CLMHDR_STATUS, ");
            strSQL.Append("CLMHDR_HEALTH_CARE_PROV, ");
            strSQL.Append("CLMHDR_HEALTH_CARE_VER, ");
            strSQL.Append("CLMHDR_PATIENT_SURNAME, ");
            strSQL.Append("CLMHDR_SUBSCR_INITIALS, ");
            strSQL.Append("CLMHDR_AGENT_CD, ");
            strSQL.Append("CLMHDR_HEALTH_CARE_NBR ");
            strSQL.Append("FROM INDEXED.F002_SUSPEND_HDR ");
            strSQL.Append(SelectIf_F002_SUSPEND_HDR(true));
            strSQL.Append(Choose());
            rdrF002_SUSPEND_HDR.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.m_strFlatFileDictionary, ReportFunctions.TextFiles);
            strSQL = null;
        }
        private void Link_F002_SUSPEND_ADDRESS()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("ADD_DOC_OHIP_NBR, ");
            strSQL.Append("ADD_ACCOUNTING_NBR, ");
            strSQL.Append("ADD_SURNAME, ");
            strSQL.Append("ADD_FIRST_NAME, ");
            strSQL.Append("ADD_BIRTH_DATE, ");
            strSQL.Append("ADD_SEX, ");
            strSQL.Append("ADD_ADDRESS_LINE_1, ");
            strSQL.Append("ADD_ADDRESS_LINE_2, ");
            strSQL.Append("ADD_ADDRESS_LINE_3, ");
            strSQL.Append("ADD_POSTAL_CODE, ");
            strSQL.Append("ADD_PHONE_NO ");
            strSQL.Append("FROM INDEXED.F002_SUSPEND_ADDRESS ");
            strSQL.Append("WHERE ");
            strSQL.Append("ADD_DOC_OHIP_NBR = ").Append(rdrF002_SUSPEND_HDR.GetNumber("CLMHDR_DOC_OHIP_NBR"));
            strSQL.Append(" AND ADD_ACCOUNTING_NBR = ").Append(Common.StringToField(rdrF002_SUSPEND_HDR.GetString("CLMHDR_ACCOUNTING_NBR")));
            rdrF002_SUSPEND_ADDRESS.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.m_strFlatFileDictionary, ReportFunctions.TextFiles);
            strSQL = null;
        }

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(String.Empty);
            // TODO: CHOOSE Statement - May require manual changes.
            return strChoose.ToString().ToString();
        }

        private string SelectIf_F002_SUSPEND_HDR(bool blnAddWhere)
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            if (blnAddWhere)
            {
                strSQL.Append(" WHERE ");
            }
            else
            {
                strSQL.Append(" AND ");
            }

            // TODO: SelectIf Statement - May require manual changes.
            strSQL.Append("CLMHDR_PAT_KEY_TYPE <>  'I' AND ");
            strSQL.Append("CLMHDR_STATUS <> ").Append(Common.StringToField(CLMHDR_STATUS_RESUBMIT()));
            return strSQL.ToString().ToString();
        }

        private string TP_PAT_FUNC_CODE()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = "AA";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string TP_PAT_SUBSCR_SURNAME()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = rdrF002_SUSPEND_ADDRESS.GetString("ADD_SURNAME");
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string TP_PAT_FIRST_NAME()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = rdrF002_SUSPEND_ADDRESS.GetString("ADD_FIRST_NAME");
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string TP_PAT_BIRTH_DATE()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = QDesign.Substring(QDesign.ASCII(rdrF002_SUSPEND_ADDRESS.GetNumber("ADD_BIRTH_DATE"), 8), 1, 4) + QDesign.Substring(QDesign.ASCII(rdrF002_SUSPEND_ADDRESS.GetNumber("ADD_BIRTH_DATE"), 8), 5, 2) + QDesign.Substring(QDesign.ASCII(rdrF002_SUSPEND_ADDRESS.GetNumber("ADD_BIRTH_DATE"), 8), 7, 2);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string TP_PAT_SEX()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = rdrF002_SUSPEND_ADDRESS.GetString("ADD_SEX");
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string TP_PAT_ID_NO()
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

        private string TP_PAT_STREET_ADDR()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = QDesign.Substring(rdrF002_SUSPEND_ADDRESS.GetString("ADD_ADDRESS_LINE_1"), 1, 26);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private decimal W_COMMA_2()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = QDesign.Index(rdrF002_SUSPEND_ADDRESS.GetString("ADD_ADDRESS_LINE_2"), ",");
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal W_COMMA_3()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = QDesign.Index(rdrF002_SUSPEND_ADDRESS.GetString("ADD_ADDRESS_LINE_3"), ",");
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private string TP_PAT_PROV()
        {
            string strReturnValue = String.Empty;
            try
            {
                if ((QDesign.NULL(rdrF002_SUSPEND_HDR.GetString("CLMHDR_HEALTH_CARE_PROV")) != QDesign.NULL(" ")))
                {
                    strReturnValue = rdrF002_SUSPEND_HDR.GetString("CLMHDR_HEALTH_CARE_PROV");
                }
                else if (((QDesign.NULL(rdrF002_SUSPEND_ADDRESS.GetString("ADD_ADDRESS_LINE_3")) != QDesign.NULL(" "))
                            && (QDesign.NULL(W_COMMA_3()) == QDesign.NULL(0d))))
                {
                    strReturnValue = QDesign.Substring(rdrF002_SUSPEND_ADDRESS.GetString("ADD_ADDRESS_LINE_3"), 1, 3);
                }
                else if (((QDesign.NULL(rdrF002_SUSPEND_ADDRESS.GetString("ADD_ADDRESS_LINE_3")) != QDesign.NULL(" "))
                            && (QDesign.NULL(W_COMMA_3()) != QDesign.NULL(0d))))
                {
                    strReturnValue = QDesign.Substring(rdrF002_SUSPEND_ADDRESS.GetString("ADD_ADDRESS_LINE_3"), (Convert.ToInt32(W_COMMA_3() + 2)), 3);
                }
                else
                {
                    strReturnValue = QDesign.Substring(rdrF002_SUSPEND_ADDRESS.GetString("ADD_ADDRESS_LINE_2"), (Convert.ToInt32(W_COMMA_2() + 2)), 3);
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string TP_PAT_CITY()
        {
            string strReturnValue = String.Empty;
            try
            {
                if (((QDesign.NULL(rdrF002_SUSPEND_ADDRESS.GetString("ADD_ADDRESS_LINE_2")) != QDesign.NULL(" "))
                            && (QDesign.NULL(W_COMMA_2()) != QDesign.NULL(0d))))
                {
                    strReturnValue = QDesign.Substring(rdrF002_SUSPEND_ADDRESS.GetString("ADD_ADDRESS_LINE_2"), 1, (Convert.ToInt32(W_COMMA_2() - 1)));
                }
                else if (((QDesign.NULL(rdrF002_SUSPEND_ADDRESS.GetString("ADD_ADDRESS_LINE_2")) != QDesign.NULL(" "))
                            && (QDesign.NULL(W_COMMA_2()) == QDesign.NULL(0d))))
                {
                    strReturnValue = rdrF002_SUSPEND_ADDRESS.GetString("ADD_ADDRESS_LINE_2");
                }
                else if (((QDesign.NULL(rdrF002_SUSPEND_ADDRESS.GetString("ADD_ADDRESS_LINE_3")) != QDesign.NULL(" "))
                            && (QDesign.NULL(W_COMMA_3()) != QDesign.NULL(0d))))
                {
                    strReturnValue = QDesign.Substring(rdrF002_SUSPEND_ADDRESS.GetString("ADD_ADDRESS_LINE_3"), 1, (Convert.ToInt32(W_COMMA_3() - 1)));
                }
                else if (((QDesign.NULL(rdrF002_SUSPEND_ADDRESS.GetString("ADD_ADDRESS_LINE_3")) != QDesign.NULL(" "))
                            && (QDesign.NULL(W_COMMA_3()) == QDesign.NULL(0d))))
                {
                    strReturnValue = rdrF002_SUSPEND_ADDRESS.GetString("ADD_ADDRESS_LINE_3");
                }
                else
                {
                    strReturnValue = rdrF002_SUSPEND_ADDRESS.GetString("ADD_ADDRESS_LINE_2");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string TP_PAT_POSTAL_CODE()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = rdrF002_SUSPEND_ADDRESS.GetString("ADD_POSTAL_CODE");
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string TP_PAT_PHONE_NO()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = rdrF002_SUSPEND_ADDRESS.GetString("ADD_PHONE_NO");
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string TP_PAT_VERSION_CD()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = rdrF002_SUSPEND_HDR.GetString("CLMHDR_HEALTH_CARE_VER");
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string TP_PAT_RELATIONSHIP()
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

        private string TP_PAT_LAST_NAME()
        {
            string strReturnValue = String.Empty;
            try
            {
                if ((QDesign.NULL(rdrF002_SUSPEND_HDR.GetString("CLMHDR_PATIENT_SURNAME")) != QDesign.NULL(" ")))
                {
                    strReturnValue = rdrF002_SUSPEND_HDR.GetString("CLMHDR_PATIENT_SURNAME");
                }
                else
                {
                    strReturnValue = rdrF002_SUSPEND_ADDRESS.GetString("ADD_SURNAME");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string TP_PAT_SUBSCR_INITIALS()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = rdrF002_SUSPEND_HDR.GetString("CLMHDR_SUBSCR_INITIALS");
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string TP_PAT_OHIP_NO()
        {
            string strReturnValue = String.Empty;
            try
            {
                if (((QDesign.NULL(rdrF002_SUSPEND_HDR.GetNumber("CLMHDR_AGENT_CD")) == QDesign.NULL(6d))
                            || (QDesign.NULL(rdrF002_SUSPEND_HDR.GetNumber("CLMHDR_AGENT_CD")) == QDesign.NULL(9d))))
                {
                    strReturnValue = (QDesign.Substring(TP_PAT_LAST_NAME(), 1, 3) + QDesign.Substring(TP_PAT_BIRTH_DATE(), 3, 6));
                }
                else
                {
                    strReturnValue = rdrF002_SUSPEND_HDR.GetString("CLMHDR_HEALTH_CARE_NBR");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string CLMHDR_DOC_NBR()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = QDesign.Substring(rdrF002_SUSPEND_HDR.GetString("CLMHDR_BATCH_NBR"), 3, 3);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }


        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.SUMMARY, "TP_PAT_FUNC_CODE", DataTypes.Character, 2);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_SUSPEND_HDR.CLMHDR_DOC_OHIP_NBR", DataTypes.Character, 6);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_SUSPEND_HDR.CLMHDR_ACCOUNTING_NBR", DataTypes.Character, 8);
                AddControl(ReportSection.SUMMARY, "TP_PAT_SUBSCR_SURNAME", DataTypes.Character, 25);
                AddControl(ReportSection.SUMMARY, "TP_PAT_FIRST_NAME", DataTypes.Character, 24);
                AddControl(ReportSection.SUMMARY, "TP_PAT_BIRTH_DATE", DataTypes.Character, 8);
                AddControl(ReportSection.SUMMARY, "TP_PAT_SEX", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "TP_PAT_ID_NO", DataTypes.Character, 9);
                AddControl(ReportSection.SUMMARY, "TP_PAT_STREET_ADDR", DataTypes.Character, 28);
                AddControl(ReportSection.SUMMARY, "TP_PAT_CITY", DataTypes.Character, 18);
                AddControl(ReportSection.SUMMARY, "TP_PAT_PROV", DataTypes.Character, 4);
                AddControl(ReportSection.SUMMARY, "TP_PAT_POSTAL_CODE", DataTypes.Character, 9);
                AddControl(ReportSection.SUMMARY, "TP_PAT_PHONE_NO", DataTypes.Character, 20);
                AddControl(ReportSection.SUMMARY, "TP_PAT_OHIP_NO", DataTypes.Character, 12);
                AddControl(ReportSection.SUMMARY, "TP_PAT_VERSION_CD", DataTypes.Character, 2);
                AddControl(ReportSection.SUMMARY, "TP_PAT_RELATIONSHIP", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "TP_PAT_LAST_NAME", DataTypes.Character, 25);
                AddControl(ReportSection.SUMMARY, "TP_PAT_SUBSCR_INITIALS", DataTypes.Character, 3);
                AddControl(ReportSection.SUMMARY, "INDEXED.F002_SUSPEND_HDR.CLMHDR_AGENT_CD", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "CLMHDR_DOC_NBR", DataTypes.Character, 3);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-05-15 3:04:05 PM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            // TODO: Remove duplicate controls, if there are any.
            switch (strControl)
            {
                case "TP_PAT_FUNC_CODE":
                    return Common.StringToField(TP_PAT_FUNC_CODE(), intSize);
                case "INDEXED.F002_SUSPEND_HDR.CLMHDR_DOC_OHIP_NBR":
                    return Common.StringToField(rdrF002_SUSPEND_HDR.GetNumber("CLMHDR_DOC_OHIP_NBR").ToString().PadLeft(6, '0'));
                case "INDEXED.F002_SUSPEND_HDR.CLMHDR_ACCOUNTING_NBR":
                    return Common.StringToField(rdrF002_SUSPEND_HDR.GetString("CLMHDR_ACCOUNTING_NBR"));
                case "TP_PAT_SUBSCR_SURNAME":
                    return Common.StringToField(TP_PAT_SUBSCR_SURNAME(), intSize);
                case "TP_PAT_FIRST_NAME":
                    return Common.StringToField(TP_PAT_FIRST_NAME(), intSize);
                case "TP_PAT_BIRTH_DATE":
                    return Common.StringToField(TP_PAT_BIRTH_DATE(), intSize);
                case "TP_PAT_SEX":
                    return Common.StringToField(TP_PAT_SEX(), intSize);
                case "TP_PAT_ID_NO":
                    return Common.StringToField(TP_PAT_ID_NO(), intSize);
                case "TP_PAT_STREET_ADDR":
                    return Common.StringToField(TP_PAT_STREET_ADDR(), intSize);
                case "TP_PAT_CITY":
                    return Common.StringToField(TP_PAT_CITY(), intSize);
                case "TP_PAT_PROV":
                    return Common.StringToField(TP_PAT_PROV(), intSize);
                case "TP_PAT_POSTAL_CODE":
                    return Common.StringToField(TP_PAT_POSTAL_CODE(), intSize);
                case "TP_PAT_PHONE_NO":
                    return Common.StringToField(TP_PAT_PHONE_NO(), intSize);
                case "TP_PAT_OHIP_NO":
                    return Common.StringToField(TP_PAT_OHIP_NO(), intSize);
                case "TP_PAT_VERSION_CD":
                    return Common.StringToField(TP_PAT_VERSION_CD(), intSize);
                case "TP_PAT_RELATIONSHIP":
                    return Common.StringToField(TP_PAT_RELATIONSHIP(), intSize);
                case "TP_PAT_LAST_NAME":
                    return Common.StringToField(TP_PAT_LAST_NAME(), intSize);
                case "TP_PAT_SUBSCR_INITIALS":
                    return Common.StringToField(TP_PAT_SUBSCR_INITIALS(), intSize);
                case "INDEXED.F002_SUSPEND_HDR.CLMHDR_AGENT_CD":
                    return Common.StringToField(rdrF002_SUSPEND_HDR.GetNumber("CLMHDR_AGENT_CD").ToString());
                case "CLMHDR_DOC_NBR":
                    return Common.StringToField(CLMHDR_DOC_NBR());
                default:
                    return String.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                // TODO: Some manual steps maybe required.
                Access_F002_SUSPEND_HDR();
                while (rdrF002_SUSPEND_HDR.Read())
                {
                    Link_F002_SUSPEND_ADDRESS();
                    while (rdrF002_SUSPEND_ADDRESS.Read())
                    {
                        WriteData();
                    }

                    rdrF002_SUSPEND_ADDRESS.Close();
                }

                rdrF002_SUSPEND_HDR.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrF002_SUSPEND_HDR == null))
            {
                rdrF002_SUSPEND_HDR.Close();
                rdrF002_SUSPEND_HDR = null;
            }

            if (!(rdrF002_SUSPEND_ADDRESS == null))
            {
                rdrF002_SUSPEND_ADDRESS.Close();
                rdrF002_SUSPEND_ADDRESS = null;
            }
        }
    }
}
