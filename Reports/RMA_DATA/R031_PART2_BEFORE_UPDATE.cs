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
    public class R031_PART2_BEFORE_UPDATE : BaseRDLClass
    {
        protected const string REPORT_NAME = "R031_PART2_BEFORE_UPDATE";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrR031A_OHIP_PREMIUMS = new Reader();
        private Reader rdrTMP_DOCTOR_ALPHA = new Reader();

        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                //  Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;
                Sort = "ICONST_CLINIC_NBR_1_2 ASC, DOC_OHIP_NBR ASC, CLMHDR_ADJ_CD ASC";
                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return ReportData;
        }
        private void Access_R031A_OHIP_PREMIUMS()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            strSQL.Append("SELECT ");
            strSQL.Append("DOC_OHIP_NBR, ");
            strSQL.Append("ICONST_CLINIC_NBR_1_2, ");
            strSQL.Append("DOLLARS_PAID, ");
            strSQL.Append("CLMHDR_ADJ_CD ");
            strSQL.Append("FROM SEQUENTIAL.R031A ");
            strSQL.Append(Choose());
            rdrR031A_OHIP_PREMIUMS.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.m_strFlatFileDictionary, ReportFunctions.TextFiles);
            strSQL = null;
        }
        private void Link_TMP_DOCTOR_ALPHA()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("DOC_OHIP_NBR, ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("TMP_ALPHA_FIELD_1, ");
            strSQL.Append("TMP_COUNTER_1, ");
            strSQL.Append("TMP_COUNTER_3 ");
            strSQL.Append("FROM INDEXED.TMP_DOCTOR_ALPHA ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_OHIP_NBR = ").Append(rdrR031A_OHIP_PREMIUMS.GetNumber("DOC_OHIP_NBR"));
            strSQL.Append(" AND DOC_NBR = '").Append(" '");
            strSQL.Append(" AND TMP_ALPHA_FIELD_1 = ").Append(QDesign.ASCII(rdrR031A_OHIP_PREMIUMS.GetNumber("ICONST_CLINIC_NBR_1_2"), 2));
            rdrTMP_DOCTOR_ALPHA.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(String.Empty);
            // TODO: CHOOSE Statement - May require manual changes.
            return strChoose.ToString().ToString();
        }

        private decimal X_PAID_AMT()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(QDesign.Substring(rdrR031A_OHIP_PREMIUMS.GetString("DOLLARS_PAID"), 1, 1)) == "-"))
                {
                    decReturnValue = (QDesign.NConvert((QDesign.Substring(rdrR031A_OHIP_PREMIUMS.GetString("DOLLARS_PAID"), 2, 2)
                                    + (QDesign.Substring(rdrR031A_OHIP_PREMIUMS.GetString("DOLLARS_PAID"), 5, 3) + QDesign.Substring(rdrR031A_OHIP_PREMIUMS.GetString("DOLLARS_PAID"), 9, 2)))) * -1);
                }
                else
                {
                    decReturnValue = QDesign.NConvert((QDesign.Substring(rdrR031A_OHIP_PREMIUMS.GetString("DOLLARS_PAID"), 1, 3)
                                    + (QDesign.Substring(rdrR031A_OHIP_PREMIUMS.GetString("DOLLARS_PAID"), 5, 3) + QDesign.Substring(rdrR031A_OHIP_PREMIUMS.GetString("DOLLARS_PAID"), 9, 2))));
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_TECH_AMT()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = QDesign.Divide((X_PAID_AMT() * rdrTMP_DOCTOR_ALPHA.GetNumber("TMP_COUNTER_1")), rdrTMP_DOCTOR_ALPHA.GetNumber("TMP_COUNTER_3"));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_PROF_AMT()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = (X_PAID_AMT() - X_TECH_AMT());
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.FOOTING_AT, "SEQUENTIAL.R031A_OHIP_PREMIUMS.DOC_OHIP_NBR", DataTypes.Numeric, 6);
                AddControl(ReportSection.FOOTING_AT, "SEQUENTIAL.R031A_OHIP_PREMIUMS.CLMHDR_ADJ_CD", DataTypes.Character, 5);
                AddControl(ReportSection.FOOTING_AT, "X_PAID_AMT", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_TECH_AMT", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_PROF_AMT", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "SEQUENTIAL.R031A_OHIP_PREMIUMS.ICONST_CLINIC_NBR_1_2", DataTypes.Numeric, 2);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-10-23 10:15:45 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            // TODO: Remove duplicate controls, if there are any.
            switch (strControl)
            {
                case "SEQUENTIAL.R031A_OHIP_PREMIUMS.DOC_OHIP_NBR":
                    return rdrR031A_OHIP_PREMIUMS.GetNumber("DOC_OHIP_NBR").ToString();
                case "SEQUENTIAL.R031A_OHIP_PREMIUMS.CLMHDR_ADJ_CD":
                    return Common.StringToField(rdrR031A_OHIP_PREMIUMS.GetString("CLMHDR_ADJ_CD"));
                case "X_PAID_AMT":
                    return X_PAID_AMT().ToString();
                case "X_TECH_AMT":
                    return X_TECH_AMT().ToString();
                case "X_PROF_AMT":
                    return X_PROF_AMT().ToString();
                case "SEQUENTIAL.R031A_OHIP_PREMIUMS.ICONST_CLINIC_NBR_1_2":
                    return rdrR031A_OHIP_PREMIUMS.GetNumber("ICONST_CLINIC_NBR_1_2").ToString();
                default:
                    return String.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                // TODO: Some manual steps maybe required.
                Access_R031A_OHIP_PREMIUMS();
                while (rdrR031A_OHIP_PREMIUMS.Read())
                {
                    Link_TMP_DOCTOR_ALPHA();
                    while (rdrTMP_DOCTOR_ALPHA.Read())
                    {
                        WriteData();
                    }

                    rdrTMP_DOCTOR_ALPHA.Close();
                }

                rdrR031A_OHIP_PREMIUMS.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrR031A_OHIP_PREMIUMS == null))
            {
                rdrR031A_OHIP_PREMIUMS.Close();
                rdrR031A_OHIP_PREMIUMS = null;
            }

            if (!(rdrTMP_DOCTOR_ALPHA == null))
            {
                rdrTMP_DOCTOR_ALPHA.Close();
                rdrTMP_DOCTOR_ALPHA = null;
            }
        }
    }
}
