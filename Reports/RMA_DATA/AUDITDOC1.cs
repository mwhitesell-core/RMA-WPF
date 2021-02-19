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
    public class AUDITDOC1 : BaseRDLClass
    {
        protected const string REPORT_NAME = "AUDITDOC1";
        protected const bool REPORT_HAS_PARAMETERS = true;
        private Reader rdrF020_DOCTOR_MSTR = new Reader();
        private Reader rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR = new Reader();
        private Reader rdrAUDITDOC = new Reader();

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
                SubFileName = "AUDITDOC";
                SubFileType = SubFileType.Keep;
                //SubFileAT = "DOC_OHIP_NBR";
                //Sort = "DOC_OHIP_NBR ASC, X_CLASS ASC";
                Sort = "";
                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return ReportData;
        }
        private void Access_F020_DOCTOR_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            strSQL.Append("SELECT * FROM (");
            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("DOC_FULL_PART_IND, ");
            strSQL.Append("DOC_DEPT, ");
            strSQL.Append("DOC_DATE_FAC_TERM_YY, ");
            strSQL.Append("DOC_DATE_FAC_TERM_MM, ");
            strSQL.Append("DOC_DATE_FAC_TERM_DD, ");
            strSQL.Append("DOC_DATE_FAC_START_YY, ");
            strSQL.Append("DOC_DATE_FAC_START_MM, ");
            strSQL.Append("DOC_DATE_FAC_START_DD, ");
            strSQL.Append("DOC_OHIP_NBR, ");
            strSQL.Append("(CASE WHEN DOC_FULL_PART_IND = 'S' THEN 1 ELSE CASE WHEN DOC_FULL_PART_IND = 'C' THEN 2 ELSE CASE WHEN DOC_FULL_PART_IND = 'P' THEN 3 ELSE 4 END END END) AS X_CLASS ");
            strSQL.Append("FROM INDEXED.F020_DOCTOR_MSTR ");
            strSQL.Append(") x ");
            strSQL.Append("ORDER BY ");
            strSQL.Append("DOC_OHIP_NBR ASC, X_CLASS ASC ");
            strSQL.Append(Choose());
            rdrF020_DOCTOR_MSTR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        private void Link_F020C_DOC_CLINIC_NEXT_BATCH_NBR()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            strSQL.Append("SELECT ");
            strSQL.Append("DOC_CLINIC_NBR ");
            strSQL.Append("FROM INDEXED.F020C_DOC_CLINIC_NEXT_BATCH_NBR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_NBR = ").Append(Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_NBR")));
            strSQL.Append(" AND SEQ_NO = 1");

            rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(String.Empty);
            // TODO: CHOOSE Statement - May require manual changes.
            return strChoose.ToString();
        }

        public override bool SelectIf()
        {
            bool blnSelected = false;
            if (QDesign.NULL(rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR")) == QDesign.NULL(22d)  
                        && (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "F"
                        || QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "P"
                        || QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "C"
                        || QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "S")
                        && (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT")) != QDesign.NULL(31d))
                        && ((QDesign.NConvert(QDesign.ASCII(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DATE_FAC_TERM_YY"), 4) + QDesign.ASCII(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DATE_FAC_TERM_MM"), 2) + QDesign.ASCII(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DATE_FAC_TERM_DD"), 2)) == QDesign.NULL(0d)
                        || QDesign.NConvert(QDesign.ASCII(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DATE_FAC_TERM_YY"), 4) + QDesign.ASCII(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DATE_FAC_TERM_MM"), 2) + QDesign.ASCII(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DATE_FAC_TERM_DD"), 2)) >= QDesign.NConvert(ReportFunctions.astrScreenParameters[0].ToString()))
                        && (QDesign.NConvert(QDesign.ASCII(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DATE_FAC_START_YY"), 4) + QDesign.ASCII(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DATE_FAC_START_MM"), 2) + QDesign.ASCII(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DATE_FAC_START_DD"), 2)) < QDesign.NConvert(ReportFunctions.astrScreenParameters[1].ToString()))))
            {
                blnSelected = true;
            }

            return blnSelected;
        }

        private string PREV_DOC_FULL_PART_IND = string.Empty;
        private decimal PREV_DOC_OHIP_NBR = 0;

        private string PREV_X_IND = string.Empty;


        private string X_IND()
        {
            string strReturnValue = String.Empty;
            try
            {
                if ((QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "F"))
                {
                    strReturnValue = "GFT      ";
                }
                else if ((QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "P"))
                {
                    strReturnValue = "PART TIME";
                }
                else if ((QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "C"))
                {
                    strReturnValue = "CLINICAL SCHOLARS";
                }
                else if ((QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "S"))
                {
                    strReturnValue = "PLASTIC SURGERY";
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private decimal X_CLASS()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "F"))
                {
                    decReturnValue = 4;
                }
                else if ((QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "P"))
                {
                    decReturnValue = 3;
                }
                else if ((QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "C"))
                {
                    decReturnValue = 2;
                }
                else if ((QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "S"))
                {
                    decReturnValue = 1;
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        public override void AccessData()
        {
            try
            {
                //Initialize PREV_DOC_OHIP_NBR
                PREV_DOC_OHIP_NBR = 9999999;

                // TODO: Some manual steps maybe required.
                Access_F020_DOCTOR_MSTR();
                while (rdrF020_DOCTOR_MSTR.Read())
                {
                    Link_F020C_DOC_CLINIC_NEXT_BATCH_NBR();
                    while (rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.Read())
                    {
                        if (PREV_DOC_OHIP_NBR == 9999999)
                        {
                            PREV_DOC_OHIP_NBR = rdrF020_DOCTOR_MSTR.GetNumber("DOC_OHIP_NBR");
                            PREV_X_IND = X_IND();
                            PREV_DOC_FULL_PART_IND = rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND");
                        }
                        else if (PREV_DOC_OHIP_NBR == rdrF020_DOCTOR_MSTR.GetNumber("DOC_OHIP_NBR"))
                        {
                            if (PREV_DOC_OHIP_NBR == rdrF020_DOCTOR_MSTR.GetNumber("DOC_OHIP_NBR") && PREV_DOC_FULL_PART_IND == rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND"))
                            {
                                PREV_DOC_OHIP_NBR = rdrF020_DOCTOR_MSTR.GetNumber("DOC_OHIP_NBR");
                                PREV_X_IND = X_IND();
                                PREV_DOC_FULL_PART_IND = rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND");
                            }
                            else if (PREV_DOC_OHIP_NBR == rdrF020_DOCTOR_MSTR.GetNumber("DOC_OHIP_NBR") && PREV_DOC_FULL_PART_IND != rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND"))
                            {
                                WriteData();
                                PREV_DOC_OHIP_NBR = rdrF020_DOCTOR_MSTR.GetNumber("DOC_OHIP_NBR");
                                PREV_X_IND = X_IND();
                                PREV_DOC_FULL_PART_IND = rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND");
                            }
                        }
                        else if (PREV_DOC_OHIP_NBR != rdrF020_DOCTOR_MSTR.GetNumber("DOC_OHIP_NBR"))
                        {
                            WriteData();
                            PREV_DOC_OHIP_NBR = rdrF020_DOCTOR_MSTR.GetNumber("DOC_OHIP_NBR");
                            PREV_X_IND = X_IND();
                            PREV_DOC_FULL_PART_IND = rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND");
                        }
                    }

                    rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.Close();
                }
                WriteData();
                rdrF020_DOCTOR_MSTR.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }


        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.SUMMARY, "X_IND", DataTypes.Character, 18);
                AddControl(ReportSection.SUMMARY, "INDEXED.F020_DOCTOR_MSTR.DOC_FULL_PART_IND", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "INDEXED.F020_DOCTOR_MSTR.DOC_OHIP_NBR", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "X_CLASS", DataTypes.Numeric, 1);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-05-09 7:36:50 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            // TODO: Remove duplicate controls, if there are any.
            switch (strControl)
            {
                case "X_IND":
                    return Common.StringToField(X_IND());
                case "INDEXED.F020_DOCTOR_MSTR.DOC_FULL_PART_IND":
                    return Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND"));
                case "INDEXED.F020_DOCTOR_MSTR.DOC_OHIP_NBR":
                    return rdrF020_DOCTOR_MSTR.GetNumber("DOC_OHIP_NBR").ToString();
                case "X_CLASS":
                    return X_CLASS().ToString();
                default:
                    return String.Empty;
            }
        }

        public override void CloseReaders()
        {
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
