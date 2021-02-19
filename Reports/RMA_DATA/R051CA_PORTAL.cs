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
    public class R051CA_PORTAL : BaseRDLClass
    {
        protected const string REPORT_NAME = "R051CA_PORTAL";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrF050_DOC_REVENUE_MSTR = new Reader();
        private Reader rdrF020_DOCTOR_MSTR = new Reader();
        private Reader rdrICONST_MSTR_REC = new Reader();
        private Reader rdrF070_DEPT_MSTR = new Reader();
        private Reader rdrF040_OMA_FEE_MSTR = new Reader();
        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                //  Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;
                Sort = "DOCREV_CLINIC_1_2 ASC, DOCREV_DEPT ASC, DOC_FULL_PART_IND ASC, DOCREV_DOC_NBR ASC, DOCREV_OMA_CODE ASC, DOCREV_OMA_SUFF ASC";
                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return ReportData;
        }
        private void Access_F050_DOC_REVENUE_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOCREV_DOC_NBR, ");
            strSQL.Append("DOCREV_CLINIC_1_2, ");
            strSQL.Append("DOCREV_DEPT, ");
            strSQL.Append("DOCREV_OMA_CODE, ");
            strSQL.Append("DOCREV_OMA_SUFF, ");
            strSQL.Append("DOCREV_LOCATION, ");
            strSQL.Append("DOCREV_MTD_IN_REC, ");
            strSQL.Append("DOCREV_MTD_OUT_REC, ");
            strSQL.Append("DOCREV_MTD_IN_SVC, ");
            strSQL.Append("DOCREV_MTD_OUT_SVC, ");
            strSQL.Append("DOCREV_YTD_IN_REC, ");
            strSQL.Append("DOCREV_YTD_OUT_REC, ");
            strSQL.Append("DOCREV_YTD_IN_SVC, ");
            strSQL.Append("DOCREV_YTD_OUT_SVC ");
            strSQL.Append("FROM INDEXED.F050_DOC_REVENUE_MSTR ");

            strSQL.Append(Choose());

            rdrF050_DOC_REVENUE_MSTR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_F020_DOCTOR_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("DOC_FULL_PART_IND, ");
            strSQL.Append("DOC_NAME, ");
            strSQL.Append("DOC_INIT1, ");
            strSQL.Append("DOC_INIT2, ");
            strSQL.Append("DOC_INIT3 ");
            strSQL.Append("FROM INDEXED.F020_DOCTOR_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_NBR = ").Append(Common.StringToField(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_DOC_NBR")));

            rdrF020_DOCTOR_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_ICONST_MSTR_REC()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("ICONST_CLINIC_NBR_1_2, ");
            strSQL.Append("ICONST_DATE_PERIOD_END_YY, ");
            strSQL.Append("ICONST_DATE_PERIOD_END_MM, ");
            strSQL.Append("ICONST_DATE_PERIOD_END_DD, ");
            strSQL.Append("ICONST_CLINIC_NAME ");
            strSQL.Append("FROM INDEXED.ICONST_MSTR_REC ");
            strSQL.Append("WHERE ");
            strSQL.Append("ICONST_CLINIC_NBR_1_2 = ").Append(QDesign.NConvert(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_CLINIC_1_2")));

            rdrICONST_MSTR_REC.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_F070_DEPT_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DEPT_NBR, ");
            strSQL.Append("DEPT_NAME ");
            strSQL.Append("FROM INDEXED.F070_DEPT_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DEPT_NBR = ").Append(rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_DEPT"));

            rdrF070_DEPT_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_F040_OMA_FEE_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("FEE_OMA_CD_LTR1, ");
            strSQL.Append("FILLER_NUMERIC, ");
            strSQL.Append("FEE_DESC ");
            strSQL.Append("FROM INDEXED.F040_OMA_FEE_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("FEE_OMA_CD_LTR1 = '").Append(Common.StringToField(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_OMA_CODE")).Substring(1,1));
            strSQL.Append("' AND FILLER_NUMERIC = '").Append(Common.StringToField(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_OMA_CODE")).Substring(2,3));
            strSQL.Append("'");

            rdrF040_OMA_FEE_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
    
        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(string.Empty);

            strChoose.Append(ReportDataFunctions.GetWhereCondition("DOCREV_CLINIC_1_2", QDesign.NULL(ReportFunctions.astrScreenParameters[0].ToString()), true));

            return strChoose.ToString();
        }
    
        private string X_CLASS()
        {
            string strReturnValue = string.Empty;
            try
            {
                if ((QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "F"))
                {
                    strReturnValue = "FULL TIME";
                }
                else if ((QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "P")) 
                {
                    strReturnValue = "PART TIME";
                }
                else if ((QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "C")) 
                {
                    strReturnValue = "CLINICAL SCHOLAR";
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
    
        private decimal X_AMT_MTD()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = (rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_MTD_IN_REC") + rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_MTD_OUT_REC"));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return decReturnValue;
        }
    
        private decimal X_SVC_MTD()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = (rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_MTD_IN_SVC") + rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_MTD_OUT_SVC"));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return decReturnValue;
        }
    
        private decimal X_AMT_YTD()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = (rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_YTD_IN_REC") + rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_YTD_OUT_REC"));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return decReturnValue;
        }
    
        private decimal X_SVC_YTD()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = (rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_YTD_IN_SVC") + rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_YTD_OUT_SVC"));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return decReturnValue;
        }
    
        private decimal X_FULL_AMT_MTD()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "F")) {
                    decReturnValue = X_AMT_MTD();
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return decReturnValue;
        }
    
        private decimal X_FULL_SVC_MTD()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "F")) {
                    decReturnValue = X_SVC_MTD();
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return decReturnValue;
        }
    
        private decimal X_FULL_AMT_YTD()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "F")) {
                    decReturnValue = X_AMT_YTD();
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return decReturnValue;
        }
    
        private decimal X_FULL_SVC_YTD()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "F")) {
                    decReturnValue = X_SVC_YTD();
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return decReturnValue;
        }
    
        private decimal X_PART_AMT_MTD()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "P")) {
                    decReturnValue = X_AMT_MTD();
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return decReturnValue;
        }
    
        private decimal X_PART_SVC_MTD()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "P")) {
                    decReturnValue = X_SVC_MTD();
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return decReturnValue;
        }
    
        private decimal X_PART_AMT_YTD()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "P")) {
                    decReturnValue = X_AMT_YTD();
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return decReturnValue;
        }
    
        private decimal X_PART_SVC_YTD()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "P")) {
                    decReturnValue = X_SVC_YTD();
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return decReturnValue;
        }
    
        private string X_PERIOD()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = ".";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return strReturnValue;
        }
    
        private string X_NAME()
        {
            string strReturnValue = string.Empty;
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
    
        private string X_DOC_DEPT_NBR()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = ("~" 
                            + (rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_DOC_NBR") 
                            + (QDesign.ASCII(rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_DEPT"), 2) + "~")));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return strReturnValue;
        }
    
        private decimal ICONST_MSTR_REC_ICONST_DATE_PERIOD_END()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = QDesign.NConvert(QDesign.ASCII(rdrICONST_MSTR_REC.GetNumber("ICONST_DATE_PERIOD_END_YY"), 4) + QDesign.ASCII(rdrICONST_MSTR_REC.GetNumber("ICONST_DATE_PERIOD_END_MM"), 2) + QDesign.ASCII(rdrICONST_MSTR_REC.GetNumber("ICONST_DATE_PERIOD_END_DD"), 2));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return decReturnValue;
        }
    
        private string F050_DOC_REVENUE_MSTR_DOCREV_OMA_CD()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = (rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_OMA_CODE") 
                            + (rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_OMA_SUFF")));
                //+ (rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_OMA_SUFF") + rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_ADJ_CD_SUB_TYPE")));
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
                AddControl(ReportSection.PAGE_HEADING, "INDEXED.F050_DOC_REVENUE_MSTR.DOCREV_CLINIC_1_2", DataTypes.Character, 2);
                AddControl(ReportSection.PAGE_HEADING, "ICONST_DATE_PERIOD_END", DataTypes.Numeric, 8);
                AddControl(ReportSection.PAGE_HEADING, "X_DOC_DEPT_NBR", DataTypes.Character, 7);
                AddControl(ReportSection.PAGE_HEADING, "INDEXED.ICONST_MSTR_REC.ICONST_CLINIC_NAME", DataTypes.Character, 20);
                AddControl(ReportSection.HEADING_AT, "INDEXED.F050_DOC_REVENUE_MSTR.DOCREV_DEPT", DataTypes.Numeric, 2);
                AddControl(ReportSection.HEADING_AT, "INDEXED.F070_DEPT_MSTR.DEPT_NAME", DataTypes.Character, 30);
                AddControl(ReportSection.HEADING_AT, "INDEXED.F020_DOCTOR_MSTR.DOC_FULL_PART_IND", DataTypes.Character, 1);
                AddControl(ReportSection.HEADING_AT, "X_CLASS", DataTypes.Character, 18);
                AddControl(ReportSection.HEADING_AT, "INDEXED.F020_DOCTOR_MSTR.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.HEADING_AT, "X_NAME", DataTypes.Character, 30);
                AddControl(ReportSection.FOOTING_AT, "DOCREV_OMA_CD", DataTypes.Character, 5);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F040_OMA_FEE_MSTR.FEE_DESC", DataTypes.Character, 48);
                AddControl(ReportSection.FOOTING_AT, "X_SVC_MTD", DataTypes.Numeric, 3);
                AddControl(ReportSection.FOOTING_AT, "X_AMT_MTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "X_SVC_YTD", DataTypes.Numeric, 5);
                AddControl(ReportSection.FOOTING_AT, "X_AMT_YTD", DataTypes.Numeric, 8);
                AddControl(ReportSection.REPORT, "INDEXED.F050_DOC_REVENUE_MSTR.DOCREV_DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "INDEXED.F050_DOC_REVENUE_MSTR.DOCREV_OMA_CODE", DataTypes.Character, 4);
                AddControl(ReportSection.REPORT, "INDEXED.F050_DOC_REVENUE_MSTR.DOCREV_OMA_SUFF", DataTypes.Character, 1);
            }
            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
    
        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-05-01 11:14:17 PM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "INDEXED.F050_DOC_REVENUE_MSTR.DOCREV_CLINIC_1_2":
                    return Common.StringToField(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_CLINIC_1_2"));

                case "ICONST_DATE_PERIOD_END":
                    return ICONST_MSTR_REC_ICONST_DATE_PERIOD_END().ToString();

                case "X_DOC_DEPT_NBR":
                    return Common.StringToField(X_DOC_DEPT_NBR(), intSize);

                case "INDEXED.ICONST_MSTR_REC.ICONST_CLINIC_NAME":
                    return Common.StringToField(rdrICONST_MSTR_REC.GetString("ICONST_CLINIC_NAME"));

                case "INDEXED.F050_DOC_REVENUE_MSTR.DOCREV_DEPT":
                    return rdrF050_DOC_REVENUE_MSTR.GetNumber("DOCREV_DEPT").ToString();

                case "INDEXED.F070_DEPT_MSTR.DEPT_NAME":
                    return Common.StringToField(rdrF070_DEPT_MSTR.GetString("DEPT_NAME"));

                case "INDEXED.F020_DOCTOR_MSTR.DOC_FULL_PART_IND":
                    return Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND"));

                case "X_CLASS":
                    return Common.StringToField(X_CLASS(), intSize);

                case "INDEXED.F020_DOCTOR_MSTR.DOC_NBR":
                    return Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_NBR"));

                case "X_NAME":
                    return Common.StringToField(X_NAME(), intSize);

                case "DOCREV_OMA_CD":
                    return Common.StringToField(F050_DOC_REVENUE_MSTR_DOCREV_OMA_CD(), intSize);

                case "INDEXED.F040_OMA_FEE_MSTR.FEE_DESC":
                    return Common.StringToField(rdrF040_OMA_FEE_MSTR.GetString("FEE_DESC"));

                case "X_SVC_MTD":
                    return X_SVC_MTD().ToString();

                case "X_AMT_MTD":
                    return X_AMT_MTD().ToString();

                case "X_SVC_YTD":
                    return X_SVC_YTD().ToString();

                case "X_AMT_YTD":
                    return X_AMT_YTD().ToString();

                case "INDEXED.F050_DOC_REVENUE_MSTR.DOCREV_DOC_NBR":
                    return Common.StringToField(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_DOC_NBR"));

                case "INDEXED.F050_DOC_REVENUE_MSTR.DOCREV_OMA_CODE":
                    return Common.StringToField(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_OMA_CODE"));

                case "INDEXED.F050_DOC_REVENUE_MSTR.DOCREV_OMA_SUFF":
                    return Common.StringToField(rdrF050_DOC_REVENUE_MSTR.GetString("DOCREV_OMA_SUFF"));

                default:
                    return string.Empty;
            }
        }
    
        public override void AccessData()
        {
            try
            {
                Access_F050_DOC_REVENUE_MSTR();
                while (rdrF050_DOC_REVENUE_MSTR.Read())
                {
                    Link_F020_DOCTOR_MSTR();
                    while (rdrF020_DOCTOR_MSTR.Read())
                    {
                        Link_ICONST_MSTR_REC();
                        while (rdrICONST_MSTR_REC.Read())
                        {
                            Link_F070_DEPT_MSTR();
                            while (rdrF070_DEPT_MSTR.Read())
                            {
                                Link_F040_OMA_FEE_MSTR();
                                while (rdrF040_OMA_FEE_MSTR.Read())
                                {
                                    WriteData();
                                }
                                rdrF040_OMA_FEE_MSTR.Close();
                            }
                            rdrF070_DEPT_MSTR.Close();
                        }
                        rdrICONST_MSTR_REC.Close();
                    }
                    rdrF020_DOCTOR_MSTR.Close();
                }
                rdrF050_DOC_REVENUE_MSTR.Close();
            }
            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
    
        public override void CloseReaders()
        {
            if (!(rdrF050_DOC_REVENUE_MSTR == null))
            {
                rdrF050_DOC_REVENUE_MSTR.Close();
                rdrF050_DOC_REVENUE_MSTR = null;
            }
        
            if (!(rdrF020_DOCTOR_MSTR == null))
            {
                rdrF020_DOCTOR_MSTR.Close();
                rdrF020_DOCTOR_MSTR = null;
            }
        
            if (!(rdrICONST_MSTR_REC == null))
            {
                rdrICONST_MSTR_REC.Close();
                rdrICONST_MSTR_REC = null;
            }
        
            if (!(rdrF070_DEPT_MSTR == null))
            {
                rdrF070_DEPT_MSTR.Close();
                rdrF070_DEPT_MSTR = null;
            }
        
            if (!(rdrF040_OMA_FEE_MSTR == null))
            {
                rdrF040_OMA_FEE_MSTR.Close();
                rdrF040_OMA_FEE_MSTR = null;
            }
        }
    }
}
