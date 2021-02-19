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
    public class R716A : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R716A";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrU716A = new Reader();
        private Reader rdrF002_SUSPEND_HDR = new Reader();
        private Reader rdrF030_LOCATIONS_MSTR = new Reader();

        // #CORE_BEGIN_INCLUDE: DEF_CLMHDR_STATUS"
        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-05-16 9:44:55 AM
        private string CLMHDR_STATUS_COMPLETE()
        {
            string strReturnValue = string.Empty;
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
            string strReturnValue = string.Empty;
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
            string strReturnValue = string.Empty;
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
            string strReturnValue = string.Empty;
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
            string strReturnValue = string.Empty;
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
            string strReturnValue = string.Empty;
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
            string strReturnValue = string.Empty;
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
            string strReturnValue = string.Empty;
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
            string strReturnValue = string.Empty;
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

        #endregion

        #region " Renaissance Statements "

        #region " ACCESS "

        private void Access_U716A()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("CLMDTL_DOC_OHIP_NBR, ");
            strSQL.Append("CLMDTL_ACCOUNTING_NBR, ");
            strSQL.Append("CLMDTL_SV_DATE ");
            strSQL.Append("FROM TEMPORARYDATA.U716A ");

            strSQL.Append(Choose());

            rdrU716A.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
            strSQL = null;
        }
        private void Link_F002_SUSPEND_HDR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("CLMHDR_DOC_OHIP_NBR, ");
            strSQL.Append("CLMHDR_ACCOUNTING_NBR, ");
            strSQL.Append("CLMHDR_LOC, ");
            strSQL.Append("CLMHDR_STATUS, ");
            strSQL.Append("CLMHDR_AGENT_CD, ");
            strSQL.Append("CLMHDR_REFER_DOC_NBR, ");
            strSQL.Append("CLMHDR_DIAG_CD, ");
            strSQL.Append("CLMHDR_TOT_CLAIM_AR_OHIP, ");
            strSQL.Append("CLMHDR_AMT_TECH_BILLED, ");
            strSQL.Append("CLMHDR_BATCH_NBR, ");
            strSQL.Append("CLMHDR_CLINIC_NBR_1_2, ");
            strSQL.Append("CLMHDR_DOC_NBR, ");
            strSQL.Append("CLMHDR_WEEK, ");
            strSQL.Append("CLMHDR_DAY, ");
            strSQL.Append("CLMHDR_CLAIM_NBR, ");
            strSQL.Append("CLMHDR_ADJ_OMA_CD, ");
            strSQL.Append("CLMHDR_ADJ_OMA_SUFF, ");
            strSQL.Append("CLMHDR_ADJ_ADJ_NBRF, ");
            strSQL.Append("CLMHDR_CONFIDENTIAL_FLAG, ");
            strSQL.Append("CLMHDR_RELATIONSHIP, ");
            strSQL.Append("CLMHDR_HEALTH_CARE_NBR, ");
            strSQL.Append("CLMHDR_HEALTH_CARE_PROV, ");
            strSQL.Append("CLMHDR_DATE_ADMIT, ");
            strSQL.Append("CLMHDR_I_O_PAT_IND, ");
            strSQL.Append("CLMHDR_DOC_SPEC_CD ");
            strSQL.Append("FROM INDEXED.F002_SUSPEND_HDR ");
            strSQL.Append("WHERE ");
            strSQL.Append("CLMHDR_DOC_OHIP_NBR = ").Append(rdrU716A.GetNumber("CLMDTL_DOC_OHIP_NBR"));
            strSQL.Append(" AND CLMHDR_ACCOUNTING_NBR = ").Append(Common.StringToField(rdrU716A.GetString("CLMDTL_ACCOUNTING_NBR")));

            rdrF002_SUSPEND_HDR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_F030_LOCATIONS_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("LOC_NBR, ");
            strSQL.Append("LOC_HOSPITAL_NBR ");
            strSQL.Append("FROM INDEXED.F030_LOCATIONS_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("LOC_NBR = ").Append(Common.StringToField(rdrF002_SUSPEND_HDR.GetString("CLMHDR_LOC")));

            rdrF030_LOCATIONS_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        #endregion

        #region " CHOOSE "

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(string.Empty);

            return strChoose.ToString().ToString();
        }

        #endregion

        #region " SELECT IF "

        public override bool SelectIf()
        {
            bool blnSelected = false;
            if (((QDesign.NULL(rdrF002_SUSPEND_HDR.GetString("CLMHDR_STATUS")) == QDesign.NULL(UPDATED())) 
                        || (QDesign.NULL(rdrF002_SUSPEND_HDR.GetString("CLMHDR_STATUS")) == QDesign.NULL(CLMHDR_STATUS_DELETE()))))
            {
                blnSelected = true;
            }
        
            return blnSelected;
        }

        #endregion

        #region " DEFINES "

        private decimal X_CLMHDR_DOC_OHIP_NBR()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = rdrF002_SUSPEND_HDR.GetNumber("CLMHDR_DOC_OHIP_NBR");
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return decReturnValue;
        }
    
        private decimal X_CLMHDR_AGENT_CD()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = rdrF002_SUSPEND_HDR.GetNumber("CLMHDR_AGENT_CD");
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return decReturnValue;
        }
    
        private decimal X_CLMHDR_REFER_DOC_NBR()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = rdrF002_SUSPEND_HDR.GetNumber("CLMHDR_REFER_DOC_NBR");
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return decReturnValue;
        }
    
        private decimal X_CLMHDR_DIAG_CD()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = rdrF002_SUSPEND_HDR.GetNumber("CLMHDR_DIAG_CD");
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return decReturnValue;
        }
    
        private decimal X_CLMHDR_TOT_CLAIM_AR_OHIP()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = rdrF002_SUSPEND_HDR.GetNumber("CLMHDR_TOT_CLAIM_AR_OHIP");
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return decReturnValue;
        }
    
        private decimal X_CLMHDR_AMT_TECH_BILLED()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = rdrF002_SUSPEND_HDR.GetNumber("CLMHDR_AMT_TECH_BILLED");
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return decReturnValue;
        }
    
        private decimal X_CLINIC()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = QDesign.NConvert(QDesign.Substring(F002_SUSPEND_HDR_CLMHDR_CLAIM_ID(), 1, 2));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return decReturnValue;
        }
    
        private string X_CLMHDR_CONFIDENTIAL_FLAG()
        {
            string strReturnValue = string.Empty;
            try
            {
                if ((QDesign.NULL(rdrF002_SUSPEND_HDR.GetString("CLMHDR_CONFIDENTIAL_FLAG")) == "Y")) {
                    strReturnValue = "Y";
                }
                else
                {
                    strReturnValue = "N";
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return strReturnValue;
        }
    
        private string X_CLMHDR_MANUAL_REVIEW()
        {
            string strReturnValue = string.Empty;
            try
            {
                if ((QDesign.NULL(rdrF002_SUSPEND_HDR.GetString("CLMHDR_RELATIONSHIP")) == "Y")) {
                    strReturnValue = "Y";
                }
                else
                {
                    strReturnValue = "N";
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return strReturnValue;
        }
    
        private string X_BLANKS()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = "  ";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
        return strReturnValue;
    }
        private string F002_SUSPEND_HDR_CLMHDR_CLAIM_ID()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = rdrF002_SUSPEND_HDR.GetString("CLMHDR_BATCH_NBR") + rdrF002_SUSPEND_HDR.GetNumber("CLMHDR_CLAIM_NBR").ToString().PadLeft(2, '0')
                + rdrF002_SUSPEND_HDR.GetString("CLMHDR_ADJ_OMA_CD") + rdrF002_SUSPEND_HDR.GetString("CLMHDR_ADJ_OMA_SUFF") + rdrF002_SUSPEND_HDR.GetString("CLMHDR_ADJ_ADJ_NBRF");

            }
            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;

        }
        public override void DeclareReportControls() {
        try
        {
 AddControl(ReportSection.REPORT, "X_CLMHDR_DOC_OHIP_NBR", DataTypes.Numeric, 6);
 AddControl(ReportSection.REPORT, "INDEXED.F002_SUSPEND_HDR.CLMHDR_ACCOUNTING_NBR", DataTypes.Character, 8);
 AddControl(ReportSection.REPORT, "INDEXED.F002_SUSPEND_HDR.CLMHDR_HEALTH_CARE_NBR", DataTypes.Character, 12);
 AddControl(ReportSection.REPORT, "X_BLANKS", DataTypes.Character, 2);
 AddControl(ReportSection.REPORT, "INDEXED.F002_SUSPEND_HDR.CLMHDR_HEALTH_CARE_PROV", DataTypes.Character, 2);
 AddControl(ReportSection.REPORT, "INDEXED.F002_SUSPEND_HDR.CLMHDR_LOC", DataTypes.Character, 4);
 AddControl(ReportSection.REPORT, "X_CLMHDR_AGENT_CD", DataTypes.Numeric, 1);
 AddControl(ReportSection.REPORT, "X_CLMHDR_REFER_DOC_NBR", DataTypes.Numeric, 6);
 AddControl(ReportSection.REPORT, "X_CLMHDR_DIAG_CD", DataTypes.Numeric, 3);
 AddControl(ReportSection.REPORT, "INDEXED.F002_SUSPEND_HDR.CLMHDR_DATE_ADMIT", DataTypes.Character, 8);
 AddControl(ReportSection.REPORT, "INDEXED.F030_LOCATIONS_MSTR.LOC_HOSPITAL_NBR", DataTypes.Numeric, 4);
 AddControl(ReportSection.REPORT, "X_CLMHDR_TOT_CLAIM_AR_OHIP", DataTypes.Numeric, 7);
 AddControl(ReportSection.REPORT, "X_CLMHDR_AMT_TECH_BILLED", DataTypes.Numeric, 6);
 AddControl(ReportSection.REPORT, "INDEXED.F002_SUSPEND_HDR.CLMHDR_I_O_PAT_IND", DataTypes.Character, 1);
 AddControl(ReportSection.REPORT, "X_CLMHDR_MANUAL_REVIEW", DataTypes.Character, 1);
 AddControl(ReportSection.REPORT, "X_CLINIC", DataTypes.Numeric, 2);
 AddControl(ReportSection.REPORT, "X_CLMHDR_CONFIDENTIAL_FLAG", DataTypes.Character, 1);
 AddControl(ReportSection.REPORT, "INDEXED.F002_SUSPEND_HDR.CLMHDR_STATUS", DataTypes.Character, 1);
 AddControl(ReportSection.REPORT, "INDEXED.F002_SUSPEND_HDR.CLMHDR_DOC_SPEC_CD", DataTypes.Numeric, 2);
 AddControl(ReportSection.REPORT, "TEMPORARYDATA.U716A.CLMDTL_SV_DATE", DataTypes.Character, 8);
        }

        catch (Exception ex)
        {
            //  Write the exception to the log file.
            ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
        }
    }
    
    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 2018-05-16 9:44:55 AM
    public override string ReturnControlValue(string strControl, int intSize) {
        // TODO: Remove duplicate controls, if there are any.
        switch (strControl) {
            case "X_CLMHDR_DOC_OHIP_NBR":
                return X_CLMHDR_DOC_OHIP_NBR().ToString();
            case "INDEXED.F002_SUSPEND_HDR.CLMHDR_ACCOUNTING_NBR":
                return Common.StringToField(rdrF002_SUSPEND_HDR.GetString("CLMHDR_ACCOUNTING_NBR"));
            case "INDEXED.F002_SUSPEND_HDR.CLMHDR_HEALTH_CARE_NBR":
                return Common.StringToField(rdrF002_SUSPEND_HDR.GetString("CLMHDR_HEALTH_CARE_NBR"));
            case "X_BLANKS":
                return Common.StringToField(X_BLANKS(), intSize);
            case "INDEXED.F002_SUSPEND_HDR.CLMHDR_HEALTH_CARE_PROV":
                return Common.StringToField(rdrF002_SUSPEND_HDR.GetString("CLMHDR_HEALTH_CARE_PROV"));
            case "INDEXED.F002_SUSPEND_HDR.CLMHDR_LOC":
                return Common.StringToField(rdrF002_SUSPEND_HDR.GetString("CLMHDR_LOC"));
            case "X_CLMHDR_AGENT_CD":
                return X_CLMHDR_AGENT_CD().ToString();
            case "X_CLMHDR_REFER_DOC_NBR":
                return X_CLMHDR_REFER_DOC_NBR().ToString();
            case "X_CLMHDR_DIAG_CD":
                return X_CLMHDR_DIAG_CD().ToString();
            case "INDEXED.F002_SUSPEND_HDR.CLMHDR_DATE_ADMIT":
                return Common.StringToField(rdrF002_SUSPEND_HDR.GetString("CLMHDR_DATE_ADMIT"));
            case "INDEXED.F030_LOCATIONS_MSTR.LOC_HOSPITAL_NBR":
                return rdrF030_LOCATIONS_MSTR.GetNumber("LOC_HOSPITAL_NBR").ToString();
            case "X_CLMHDR_TOT_CLAIM_AR_OHIP":
                return X_CLMHDR_TOT_CLAIM_AR_OHIP().ToString();
            case "X_CLMHDR_AMT_TECH_BILLED":
                return X_CLMHDR_AMT_TECH_BILLED().ToString();
            case "INDEXED.F002_SUSPEND_HDR.CLMHDR_I_O_PAT_IND":
                return Common.StringToField(rdrF002_SUSPEND_HDR.GetString("CLMHDR_I_O_PAT_IND"));
            case "X_CLMHDR_MANUAL_REVIEW":
                return Common.StringToField(X_CLMHDR_MANUAL_REVIEW(), intSize);
            case "X_CLINIC":
                return X_CLINIC().ToString();
            case "X_CLMHDR_CONFIDENTIAL_FLAG":
                return Common.StringToField(X_CLMHDR_CONFIDENTIAL_FLAG(), intSize);
            case "INDEXED.F002_SUSPEND_HDR.CLMHDR_STATUS":
                return Common.StringToField(rdrF002_SUSPEND_HDR.GetString("CLMHDR_STATUS"));
            case "INDEXED.F002_SUSPEND_HDR.CLMHDR_DOC_SPEC_CD":
                return rdrF002_SUSPEND_HDR.GetNumber("CLMHDR_DOC_SPEC_CD").ToString();
            case "TEMPORARYDATA.U716A.CLMDTL_SV_DATE":
                return Common.StringToField(rdrU716A.GetString("CLMDTL_SV_DATE"));
            default:
                return String.Empty;
        }
    }
    public override void AccessData() {
        try
        {
            // TODO: Some manual steps maybe required.
            Access_U716A();
            while (rdrU716A.Read()) {
                Link_F002_SUSPEND_HDR();
                while (rdrF002_SUSPEND_HDR.Read()) {
                    Link_F030_LOCATIONS_MSTR();
                    while (rdrF030_LOCATIONS_MSTR.Read()) {
                        WriteData();
                    }
                    
                        rdrF030_LOCATIONS_MSTR.Close();
                    }
                
                    rdrF002_SUSPEND_HDR.Close();
                }
            
                rdrU716A.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrU716A == null))
            {
                rdrU716A.Close();
                rdrU716A = null;
            }
        
            if (!(rdrF002_SUSPEND_HDR == null))
            {
                rdrF002_SUSPEND_HDR.Close();
                rdrF002_SUSPEND_HDR = null;
            }
        
            if (!(rdrF030_LOCATIONS_MSTR == null))
            {
                rdrF030_LOCATIONS_MSTR.Close();
                rdrF030_LOCATIONS_MSTR = null;
            }
        }

        #endregion

        #endregion
    }
}
