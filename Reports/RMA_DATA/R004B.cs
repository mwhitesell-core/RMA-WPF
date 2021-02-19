#region "Screen Comments"

// doc: r004b.qzs
// program purpose : transaction summary (detail report)
// sort .sf file created in r004a and create
// r004b.sf work file (detail and header info)
// modification history
// date       by whom   description
// 95/10/17   yasemin   original
// 04/12/07   MC        make the neccessary changes
// 13/01/23   MC1       include patient surname and given name in the subfile r004b

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
    public class R004B : BaseRDLClass
    {
	    #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

	    protected const string REPORT_NAME = "R004B";
	    protected const bool REPORT_HAS_PARAMETERS = false;

	    // Data Helpers.
	    private Reader rdrR004A = new Reader();
	    private Reader rdrF002_CLAIMS_MSTR_HDR = new Reader();
        private Reader rdrF002_CLAIMS_MSTR_DTL = new Reader();
        private Reader rdrF070_DEPT_MSTR = new Reader();
	    private Reader rdrR004B = new Reader();

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
			    // Create Subfile.
			    SubFile = true;
			    SubFileName = "R004B";
			    SubFileType = SubFileType.Keep;
			    SubFileAT = "";

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

	    private void Access_R004A()
	    {
		    StringBuilder strSQL = new StringBuilder(string.Empty);

		    strSQL.Append("SELECT ");
		    strSQL.Append("CLMHDR_DOC_DEPT, ");
            strSQL.Append("KEY_CLM_BATCH_NBR, ");
            strSQL.Append("KEY_CLM_CLAIM_NBR, ");
            strSQL.Append("ICONST_CLINIC_NBR, ");
		    strSQL.Append("ICONST_CLINIC_NBR_1_2, ");
		    strSQL.Append("ICONST_CLINIC_NAME, ");
		    strSQL.Append("ICONST_DATE_PERIOD_END, ");
		    strSQL.Append("X_DOC_NBR, ");
		    strSQL.Append("X_DOC_NAME, ");
		    strSQL.Append("X_PAT_NAME, ");
		    strSQL.Append("X_PAT_ID_INFO, ");
		    strSQL.Append("PAT_SURNAME, ");
		    strSQL.Append("PAT_GIVEN_NAME ");
		    strSQL.Append("FROM TEMPORARYDATA.R004A ");

		    strSQL.Append(Choose());

		    rdrR004A.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);

		    strSQL = null;
	    }

	    private void Link_F002_CLAIMS_MSTR_HDR()
	    {
		    StringBuilder strSQL = new StringBuilder(string.Empty);

		    strSQL.Append("SELECT ");
            strSQL.Append("KEY_CLM_BATCH_NBR, ");
            strSQL.Append("KEY_CLM_CLAIM_NBR, ");
            strSQL.Append("CLMHDR_ADJ_CD_SUB_TYPE, ");
            strSQL.Append("CLMHDR_DOC_DEPT, ");
		    strSQL.Append("CLMHDR_DATE_SYS, ");
		    strSQL.Append("CLMHDR_REFERENCE ");
		    strSQL.Append("FROM INDEXED.F002_CLAIMS_MSTR_HDR ");
            strSQL.Append("WHERE ");
		    strSQL.Append("KEY_CLM_TYPE = 'B'");
            strSQL.Append(" AND KEY_CLM_BATCH_NBR = ").Append(Common.StringToField(rdrR004A.GetString("KEY_CLM_BATCH_NBR")));
		    strSQL.Append(" AND KEY_CLM_CLAIM_NBR = ").Append(rdrR004A.GetNumber("KEY_CLM_CLAIM_NBR"));

            rdrF002_CLAIMS_MSTR_HDR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
	    }

        private void Link_F002_CLAIMS_MSTR_DTL()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("CLMDTL_ORIG_BATCH_NBR, ");
            strSQL.Append("CLMDTL_BATCH_NBR, ");
            strSQL.Append("CLMDTL_CLAIM_NBR, ");
            strSQL.Append("CLMDTL_OMA_CD, ");
            strSQL.Append("CLMDTL_OMA_SUFF, ");
            strSQL.Append("CLMDTL_ADJ_NBR, ");
            strSQL.Append("CLMDTL_ADJ_CD, ");
            strSQL.Append("CLMDTL_FEE_OHIP, ");
            strSQL.Append("CLMDTL_AGENT_CD, ");
            strSQL.Append("CLMDTL_NBR_SERV, ");
            strSQL.Append("CLMDTL_CONSEC_DATES_R, ");
            strSQL.Append("CLMDTL_SV_YY, ");
            strSQL.Append("CLMDTL_SV_MM, ");
            strSQL.Append("CLMDTL_SV_DD, ");
            strSQL.Append("CLMDTL_DIAG_CD, ");
            strSQL.Append("CLMDTL_OMA_CD, ");
            strSQL.Append("CLMDTL_OMA_SUFF ");
            strSQL.Append("FROM INDEXED.F002_CLAIMS_MSTR_DTL ");
            strSQL.Append("WHERE ");
            strSQL.Append("KEY_CLM_TYPE = 'B'");
            strSQL.Append(" AND KEY_CLM_BATCH_NBR = ").Append(Common.StringToField(rdrR004A.GetString("KEY_CLM_BATCH_NBR")));
            strSQL.Append(" AND KEY_CLM_CLAIM_NBR = ").Append(rdrR004A.GetNumber("KEY_CLM_CLAIM_NBR"));

            strSQL.Append(SelectIf_F002_CLAIMS_MSTR_DTL(false));

            rdrF002_CLAIMS_MSTR_DTL.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        private void Link_F070_DEPT_MSTR()
	    {
		    StringBuilder strSQL = new StringBuilder(string.Empty);

		    strSQL.Append("SELECT ");
		    strSQL.Append("DEPT_NBR, ");
		    strSQL.Append("DEPT_NAME ");
		    strSQL.Append("FROM [101C].INDEXED.F070_DEPT_MSTR ");
		    strSQL.Append("WHERE ");
		    strSQL.Append("DEPT_NBR = ").Append(rdrR004A.GetNumber("CLMHDR_DOC_DEPT"));

		    rdrF070_DEPT_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

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

        private string SelectIf_F002_CLAIMS_MSTR_DTL(bool blnAddWhere)
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            if (blnAddWhere)
            {
                strSQL.Append(" WHERE ");
            }
            else
            {
                strSQL.Append(" AND ");
            }

            strSQL.Append(" (CLMDTL_OMA_CD <> '0000' AND ");
            strSQL.Append("CLMDTL_OMA_CD <> 'ZZZZ' AND ");
            strSQL.Append("CLMDTL_OMA_CD <> 'PAID') AND ");
            strSQL.Append("(CLMDTL_ORIG_BATCH_NBR = ").Append(Common.StringToField(QDesign.NULL(rdrR004A.GetString("KEY_CLM_BATCH_NBR")))).Append(")");
            return strSQL.ToString();
        }

        #endregion

        #region " DEFINES "

        private string X_OMA_CODE()
	    {
		    string strReturnValue = string.Empty;

		    try
		    {
                //strReturnValue = QDesign.Substring(rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_ID"), 11, 5);
                strReturnValue = rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_OMA_CD");
            }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return strReturnValue;
	    }
	    private string X_CLAIM_DTL_ID()
	    {
		    string strReturnValue = string.Empty;

		    try
		    {
			    strReturnValue = (rdrF002_CLAIMS_MSTR_HDR.GetString("KEY_CLM_BATCH_NBR") + QDesign.ASCII(rdrF002_CLAIMS_MSTR_HDR.GetNumber("KEY_CLM_CLAIM_NBR")).PadLeft(2, '0'));
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return strReturnValue;
	    }
	    private string X_ORIG_BATCH()
	    {
		    string strReturnValue = string.Empty;

		    try
		    {
                strReturnValue = rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_BATCH_NBR");
            }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return strReturnValue;
	    }
	    private decimal X_REV_OHIP_FEE()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    if (QDesign.NULL(rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_ADJ_CD")) == QDesign.NULL("M") | QDesign.NULL(rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_ADJ_CD")) == QDesign.NULL(" "))
                {
				    decReturnValue = rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_FEE_OHIP");
			    }
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_REV_OHIP_ADJ()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    if (QDesign.NULL(rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_ADJ_CD")) == QDesign.NULL("B") | QDesign.NULL(rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_ADJ_CD")) == QDesign.NULL("R"))
                {
				    decReturnValue = rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_FEE_OHIP");
			    }
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_REV_OHIP_TOTAL()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    decReturnValue = X_REV_OHIP_FEE() + X_REV_OHIP_ADJ();
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_AGENT_0_REV()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    if (QDesign.NULL(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_AGENT_CD")) == QDesign.NULL(0d))
                {
				    decReturnValue = X_REV_OHIP_FEE();
			    }
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_AGENT_1_REV()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    if (QDesign.NULL(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_AGENT_CD")) == QDesign.NULL(1d))
                {
				    decReturnValue = X_REV_OHIP_FEE();
			    }
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_AGENT_2_REV()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    if (QDesign.NULL(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_AGENT_CD")) == QDesign.NULL(2d))
                {
				    decReturnValue = X_REV_OHIP_FEE();
			    }
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_AGENT_3_REV()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    if (QDesign.NULL(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_AGENT_CD")) == QDesign.NULL(3d))
                {
				    decReturnValue = X_REV_OHIP_FEE();
			    }
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_AGENT_4_REV()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    if (QDesign.NULL(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_AGENT_CD")) == QDesign.NULL(4d))
                {
				    decReturnValue = X_REV_OHIP_FEE();
			    }
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_AGENT_5_REV()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    if (QDesign.NULL(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_AGENT_CD")) == QDesign.NULL(5d))
                {
				    decReturnValue = X_REV_OHIP_FEE();
			    }
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_AGENT_6_REV()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    if (QDesign.NULL(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_AGENT_CD")) == QDesign.NULL(6d))
                {
				    decReturnValue = X_REV_OHIP_FEE();
			    }
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_AGENT_7_REV()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    if (QDesign.NULL(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_AGENT_CD")) == QDesign.NULL(7d))
                {
				    decReturnValue = X_REV_OHIP_FEE();
			    }
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_AGENT_8_REV()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    if (QDesign.NULL(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_AGENT_CD")) == QDesign.NULL(8d))
                {
				    decReturnValue = X_REV_OHIP_FEE();
			    }
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_AGENT_9_REV()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    if (QDesign.NULL(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_AGENT_CD")) == QDesign.NULL(9d))
                {
				    decReturnValue = X_REV_OHIP_FEE();
			    }
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_AG_0_ADJ_REV()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    if (QDesign.NULL(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_AGENT_CD")) == QDesign.NULL(0d))
                {
				    decReturnValue = X_REV_OHIP_ADJ();
			    }
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_AG_1_ADJ_REV()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    if (QDesign.NULL(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_AGENT_CD")) == QDesign.NULL(1d))
                {
				    decReturnValue = X_REV_OHIP_ADJ();
			    }
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_AG_2_ADJ_REV()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    if (QDesign.NULL(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_AGENT_CD")) == QDesign.NULL(2d))
                {
				    decReturnValue = X_REV_OHIP_ADJ();
			    }
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_AG_3_ADJ_REV()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    if (QDesign.NULL(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_AGENT_CD")) == QDesign.NULL(3d))
                {
				    decReturnValue = X_REV_OHIP_ADJ();
			    }
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_AG_4_ADJ_REV()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    if (QDesign.NULL(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_AGENT_CD")) == QDesign.NULL(4d))
                {
				    decReturnValue = X_REV_OHIP_ADJ();
			    }
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_AG_5_ADJ_REV()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    if (QDesign.NULL(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_AGENT_CD")) == QDesign.NULL(5d))
                {
				    decReturnValue = X_REV_OHIP_ADJ();
			    }
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_AG_6_ADJ_REV()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    if (QDesign.NULL(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_AGENT_CD")) == QDesign.NULL(6d))
                {
				    decReturnValue = X_REV_OHIP_ADJ();
			    }
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_AG_7_ADJ_REV()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    if (QDesign.NULL(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_AGENT_CD")) == QDesign.NULL(7d))
                {
				    decReturnValue = X_REV_OHIP_ADJ();
			    }
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_AG_8_ADJ_REV()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    if (QDesign.NULL(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_AGENT_CD")) == QDesign.NULL(8d))
                {
				    decReturnValue = X_REV_OHIP_ADJ();
			    }
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_AG_9_ADJ_REV()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    if (QDesign.NULL(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_AGENT_CD")) == QDesign.NULL(9d))
                {
				    decReturnValue = X_REV_OHIP_ADJ();
			    }
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_AG_0_TOT_REV()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    decReturnValue = X_AGENT_0_REV() + X_AG_0_ADJ_REV();
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_AG_1_TOT_REV()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    decReturnValue = X_AGENT_1_REV() + X_AG_1_ADJ_REV();
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_AG_2_TOT_REV()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    decReturnValue = X_AGENT_2_REV() + X_AG_2_ADJ_REV();
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_AG_3_TOT_REV()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    decReturnValue = X_AGENT_3_REV() + X_AG_3_ADJ_REV();
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_AG_4_TOT_REV()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    decReturnValue = X_AGENT_4_REV() + X_AG_4_ADJ_REV();
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_AG_5_TOT_REV()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    decReturnValue = X_AGENT_5_REV() + X_AG_5_ADJ_REV();
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_AG_6_TOT_REV()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    decReturnValue = X_AGENT_6_REV() + X_AG_6_ADJ_REV();
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_AG_7_TOT_REV()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    decReturnValue = X_AGENT_7_REV() + X_AG_7_ADJ_REV();
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_AG_8_TOT_REV()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    decReturnValue = X_AGENT_8_REV() + X_AG_8_ADJ_REV();
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_AG_9_TOT_REV()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    decReturnValue = X_AGENT_9_REV() + X_AG_9_ADJ_REV();
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_AR_OHIP_FEE()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    if (QDesign.NULL(rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_ADJ_CD")) == QDesign.NULL(" "))
                {
				    decReturnValue = rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_FEE_OHIP");
			    }
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_AR_OHIP_ADJ()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    if (QDesign.NULL(rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_ADJ_CD")) == QDesign.NULL("B"))
                {
				    decReturnValue = rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_FEE_OHIP");
			    }
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_AR_OHIP_TOTAL()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    decReturnValue = X_AR_OHIP_FEE() + X_AR_OHIP_ADJ();
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_AGENT_0_AR()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    if (QDesign.NULL(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_AGENT_CD")) == QDesign.NULL(0d))
                {
				    decReturnValue = X_AR_OHIP_FEE();
			    }
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_AGENT_1_AR()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    if (QDesign.NULL(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_AGENT_CD")) == QDesign.NULL(1d))
                {
				    decReturnValue = X_AR_OHIP_FEE();
			    }
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_AGENT_2_AR()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    if (QDesign.NULL(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_AGENT_CD")) == QDesign.NULL(2d))
                {
				    decReturnValue = X_AR_OHIP_FEE();
			    }
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_AGENT_3_AR()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    if (QDesign.NULL(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_AGENT_CD")) == QDesign.NULL(3d))
                {
				    decReturnValue = X_AR_OHIP_FEE();
			    }
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_AGENT_4_AR()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    if (QDesign.NULL(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_AGENT_CD")) == QDesign.NULL(4d))
                {
				    decReturnValue = X_AR_OHIP_FEE();
			    }
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_AGENT_5_AR()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    if (QDesign.NULL(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_AGENT_CD")) == QDesign.NULL(5d))
                {
				    decReturnValue = X_AR_OHIP_FEE();
			    }
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_AGENT_6_AR()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    if (QDesign.NULL(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_AGENT_CD")) == QDesign.NULL(6d))
                {
				    decReturnValue = X_AR_OHIP_FEE();
			    }
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_AGENT_7_AR()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    if (QDesign.NULL(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_AGENT_CD")) == QDesign.NULL(7d))
                {
				    decReturnValue = X_AR_OHIP_FEE();
			    }
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_AGENT_8_AR()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    if (QDesign.NULL(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_AGENT_CD")) == QDesign.NULL(8d))
                {
				    decReturnValue = X_AR_OHIP_FEE();
			    }
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_AGENT_9_AR()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    if (QDesign.NULL(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_AGENT_CD")) == QDesign.NULL(9d))
                {
				    decReturnValue = X_AR_OHIP_FEE();
			    }
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_AGENT_0_ADJ_AR()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    if (QDesign.NULL(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_AGENT_CD")) == QDesign.NULL(0d))
                {
				    decReturnValue = X_AR_OHIP_ADJ();
			    }
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_AGENT_1_ADJ_AR()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    if (QDesign.NULL(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_AGENT_CD")) == QDesign.NULL(1d))
                {
				    decReturnValue = X_AR_OHIP_ADJ();
			    }
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_AGENT_2_ADJ_AR()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    if (QDesign.NULL(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_AGENT_CD")) == QDesign.NULL(2d))
                {
				    decReturnValue = X_AR_OHIP_ADJ();
			    }
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_AGENT_3_ADJ_AR()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    if (QDesign.NULL(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_AGENT_CD")) == QDesign.NULL(3d))
                {
				    decReturnValue = X_AR_OHIP_ADJ();
			    }
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_AGENT_4_ADJ_AR()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    if (QDesign.NULL(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_AGENT_CD")) == QDesign.NULL(4d))
                {
				    decReturnValue = X_AR_OHIP_ADJ();
			    }
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_AGENT_5_ADJ_AR()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    if (QDesign.NULL(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_AGENT_CD")) == QDesign.NULL(5d))
                {
				    decReturnValue = X_AR_OHIP_ADJ();
			    }
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_AGENT_6_ADJ_AR()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    if (QDesign.NULL(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_AGENT_CD")) == QDesign.NULL(6d))
                {
				    decReturnValue = X_AR_OHIP_ADJ();
			    }
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_AGENT_7_ADJ_AR()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    if (QDesign.NULL(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_AGENT_CD")) == QDesign.NULL(7d))
                {
				    decReturnValue = X_AR_OHIP_ADJ();
			    }
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_AGENT_8_ADJ_AR()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    if (QDesign.NULL(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_AGENT_CD")) == QDesign.NULL(8d))
                {
				    decReturnValue = X_AR_OHIP_ADJ();
			    }
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_AGENT_9_ADJ_AR()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    if (QDesign.NULL(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_AGENT_CD")) == QDesign.NULL(9d))
                {
				    decReturnValue = X_AR_OHIP_ADJ();
			    }
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_AGENT_0_TOT_AR()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    decReturnValue = X_AGENT_0_AR() + X_AGENT_0_ADJ_AR();
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_AGENT_1_TOT_AR()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    decReturnValue = X_AGENT_1_AR() + X_AGENT_1_ADJ_AR();
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_AGENT_2_TOT_AR()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    decReturnValue = X_AGENT_2_AR() + X_AGENT_2_ADJ_AR();
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_AGENT_3_TOT_AR()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    decReturnValue = X_AGENT_3_AR() + X_AGENT_3_ADJ_AR();
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_AGENT_4_TOT_AR()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    decReturnValue = X_AGENT_4_AR() + X_AGENT_4_ADJ_AR();
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_AGENT_5_TOT_AR()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    decReturnValue = X_AGENT_5_AR() + X_AGENT_5_ADJ_AR();
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_AGENT_6_TOT_AR()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    decReturnValue = X_AGENT_6_AR() + X_AGENT_6_ADJ_AR();
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_AGENT_7_TOT_AR()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    decReturnValue = X_AGENT_7_AR() + X_AGENT_7_ADJ_AR();
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_AGENT_8_TOT_AR()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    decReturnValue = X_AGENT_8_AR() + X_AGENT_8_ADJ_AR();
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_AGENT_9_TOT_AR()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
			    decReturnValue = X_AGENT_9_AR() + X_AGENT_9_ADJ_AR();
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }
	    private decimal X_NBR_SVCS()
	    {
		    decimal decReturnValue = 0;

		    try
		    {
                decReturnValue = rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_NBR_SERV") + QDesign.NConvert(QDesign.Substring(rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_CONSEC_DATES_R"), 1, 1)) + QDesign.NConvert(QDesign.Substring(rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_CONSEC_DATES_R"), 4, 1)) + QDesign.NConvert(QDesign.Substring(rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_CONSEC_DATES_R"), 7, 1));
                }

                catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return decReturnValue;
	    }

	    // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

	    private string X_SOURCE()
	    {
		    string strReturnValue = string.Empty;

		    try
		    {
			    if ((QDesign.NULL(rdrF002_CLAIMS_MSTR_HDR.GetString("CLMHDR_ADJ_CD_SUB_TYPE")) != QDesign.NULL("0") & 
                    QDesign.NULL(rdrF002_CLAIMS_MSTR_HDR.GetString("CLMHDR_ADJ_CD_SUB_TYPE")) != QDesign.NULL("S") & 
                    QDesign.NULL(rdrF002_CLAIMS_MSTR_HDR.GetString("CLMHDR_ADJ_CD_SUB_TYPE")) != QDesign.NULL(" ")))
                {
				    strReturnValue = ("/" + rdrF002_CLAIMS_MSTR_HDR.GetString("CLMHDR_ADJ_CD_SUB_TYPE"));
			    }
			    else
			    {
				    strReturnValue = " ";
			    }
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }

		    return strReturnValue;
	    }

	    private string F002_CLAIMS_MSTR_CLMDTL_SV_DATE()
	    {
		    string strReturnValue = string.Empty;

		    try
		    {
			    strReturnValue = QDesign.ASCII(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_SV_YY"), 4) + QDesign.ASCII(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_SV_MM"), 2) + QDesign.ASCII(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_SV_DD"), 2);
		    }

		    catch (Exception ex)
		    {
			    // Write the exception to the log file.
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }
		    return strReturnValue;
	    }

	    private string F002_CLAIMS_MSTR_CLMDTL_ID()
	    {
		    string strReturnValue = string.Empty;

		    try
		    {
			    strReturnValue = (rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_BATCH_NBR") + QDesign.ASCII(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_CLAIM_NBR"), 2) + rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_OMA_CD") + rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_OMA_SUFF") + QDesign.ASCII(rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_ADJ_NBR"), 1));
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
			    AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.R004A.ICONST_CLINIC_NBR", DataTypes.Character, 4);
			    AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.R004A.ICONST_CLINIC_NBR_1_2", DataTypes.Numeric, 2);
			    AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.R004A.ICONST_CLINIC_NAME", DataTypes.Character, 20);
			    AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.R004A.ICONST_DATE_PERIOD_END", DataTypes.Numeric, 9);
			    AddControl(ReportSection.SUMMARY, "X_OMA_CODE", DataTypes.Character, 5);
			    AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.R004A.X_DOC_NBR", DataTypes.Character, 3);
			    AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.R004A.X_DOC_NAME", DataTypes.Character, 35);
			    AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.R004A.X_PAT_NAME", DataTypes.Character, 10);
			    AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.R004A.X_PAT_ID_INFO", DataTypes.Character, 12);
			    AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR_HDR.CLMHDR_DOC_DEPT", DataTypes.Numeric, 2);
			    AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR_HDR.CLMHDR_DATE_SYS", DataTypes.Character, 8);
			    AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR_DTL.CLMDTL_SV_DATE", DataTypes.Character, 8);
			    AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR_DTL.CLMDTL_ID", DataTypes.Character, 16);
			    AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR_HDR.CLMHDR_REFERENCE", DataTypes.Character, 11);
			    AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR_DTL.CLMDTL_AGENT_CD", DataTypes.Numeric, 1);
			    AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR_DTL.CLMDTL_ADJ_CD", DataTypes.Character, 1);
			    AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR_DTL.CLMDTL_DIAG_CD", DataTypes.Numeric, 3);
			    AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR_DTL.CLMDTL_OMA_CD", DataTypes.Character, 4);
			    AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR_DTL.CLMDTL_OMA_SUFF", DataTypes.Character, 1);
			    AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR_HDR.CLMHDR_ADJ_CD_SUB_TYPE", DataTypes.Character, 1);
			    AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR_HDR.KEY_CLM_BATCH_NBR", DataTypes.Character, 8);
			    AddControl(ReportSection.SUMMARY, "INDEXED.F002_CLAIMS_MSTR_HDR.KEY_CLM_CLAIM_NBR", DataTypes.Numeric, 2);
			    AddControl(ReportSection.SUMMARY, "X_CLAIM_DTL_ID", DataTypes.Character, 10);
			    AddControl(ReportSection.SUMMARY, "X_ORIG_BATCH", DataTypes.Character, 8);
			    AddControl(ReportSection.SUMMARY, "X_REV_OHIP_FEE", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_REV_OHIP_ADJ", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_REV_OHIP_TOTAL", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_AGENT_0_REV", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_AGENT_1_REV", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_AGENT_2_REV", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_AGENT_3_REV", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_AGENT_4_REV", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_AGENT_5_REV", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_AGENT_6_REV", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_AGENT_7_REV", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_AGENT_8_REV", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_AGENT_9_REV", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_AG_0_ADJ_REV", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_AG_1_ADJ_REV", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_AG_2_ADJ_REV", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_AG_3_ADJ_REV", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_AG_4_ADJ_REV", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_AG_5_ADJ_REV", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_AG_6_ADJ_REV", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_AG_7_ADJ_REV", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_AG_8_ADJ_REV", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_AG_9_ADJ_REV", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_AG_0_TOT_REV", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_AG_1_TOT_REV", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_AG_2_TOT_REV", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_AG_3_TOT_REV", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_AG_4_TOT_REV", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_AG_5_TOT_REV", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_AG_6_TOT_REV", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_AG_7_TOT_REV", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_AG_8_TOT_REV", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_AG_9_TOT_REV", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_AR_OHIP_FEE", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_AR_OHIP_ADJ", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_AR_OHIP_TOTAL", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_AGENT_0_AR", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_AGENT_1_AR", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_AGENT_2_AR", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_AGENT_3_AR", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_AGENT_4_AR", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_AGENT_5_AR", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_AGENT_6_AR", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_AGENT_7_AR", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_AGENT_8_AR", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_AGENT_9_AR", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_AGENT_0_ADJ_AR", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_AGENT_1_ADJ_AR", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_AGENT_2_ADJ_AR", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_AGENT_3_ADJ_AR", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_AGENT_4_ADJ_AR", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_AGENT_5_ADJ_AR", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_AGENT_6_ADJ_AR", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_AGENT_7_ADJ_AR", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_AGENT_8_ADJ_AR", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_AGENT_9_ADJ_AR", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_AGENT_0_TOT_AR", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_AGENT_1_TOT_AR", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_AGENT_2_TOT_AR", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_AGENT_3_TOT_AR", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_AGENT_4_TOT_AR", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_AGENT_5_TOT_AR", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_AGENT_6_TOT_AR", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_AGENT_7_TOT_AR", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_AGENT_8_TOT_AR", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_AGENT_9_TOT_AR", DataTypes.Numeric, 7);
			    AddControl(ReportSection.SUMMARY, "X_NBR_SVCS", DataTypes.Numeric, 2);
			    AddControl(ReportSection.SUMMARY, "X_SOURCE", DataTypes.Character, 2);
			    AddControl(ReportSection.SUMMARY, "INDEXED.F070_DEPT_MSTR.DEPT_NAME", DataTypes.Character, 30);
			    AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.R004A.PAT_SURNAME", DataTypes.Character, 25);
			    AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.R004A.PAT_GIVEN_NAME", DataTypes.Character, 17);
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
	    //# Do not delete, modify or move it.  Updated: 10/19/2017 11:23:50 AM

	    public override string ReturnControlValue(string strControl, int intSize)
	    {
		    switch (strControl)
            {
			    case "TEMPORARYDATA.R004A.ICONST_CLINIC_NBR":
				    return Common.StringToField(rdrR004A.GetString("ICONST_CLINIC_NBR").PadRight( 4, ' '));

			    case "TEMPORARYDATA.R004A.ICONST_CLINIC_NBR_1_2":
				    return rdrR004A.GetNumber("ICONST_CLINIC_NBR_1_2").ToString().PadLeft( 2, ' ');

			    case "TEMPORARYDATA.R004A.ICONST_CLINIC_NAME":
				    return Common.StringToField(rdrR004A.GetString("ICONST_CLINIC_NAME").PadRight( 20, ' '));

			    case "TEMPORARYDATA.R004A.ICONST_DATE_PERIOD_END":
                    return rdrR004A.GetNumber("ICONST_DATE_PERIOD_END").ToString().PadLeft(9, ' ');

			    case "X_OMA_CODE":
				    return Common.StringToField(X_OMA_CODE().PadRight( 5, ' '));

			    case "TEMPORARYDATA.R004A.X_DOC_NBR":
				    return Common.StringToField(rdrR004A.GetString("X_DOC_NBR").PadRight( 3, ' '));

			    case "TEMPORARYDATA.R004A.X_DOC_NAME":
				    return Common.StringToField(rdrR004A.GetString("X_DOC_NAME").PadRight( 35, ' '));

			    case "TEMPORARYDATA.R004A.X_PAT_NAME":
				    return Common.StringToField(rdrR004A.GetString("X_PAT_NAME").PadRight( 10, ' '));

			    case "TEMPORARYDATA.R004A.X_PAT_ID_INFO":
				    return Common.StringToField(rdrR004A.GetString("X_PAT_ID_INFO").PadRight( 12, ' '));

			    case "INDEXED.F002_CLAIMS_MSTR_HDR.CLMHDR_DOC_DEPT":
				    return rdrF002_CLAIMS_MSTR_HDR.GetNumber("CLMHDR_DOC_DEPT").ToString().PadLeft( 2, ' ');

			    case "INDEXED.F002_CLAIMS_MSTR_HDR.CLMHDR_DATE_SYS":
				    return Common.StringToField(rdrF002_CLAIMS_MSTR_HDR.GetString("CLMHDR_DATE_SYS").PadRight( 8, ' '));

			    case "INDEXED.F002_CLAIMS_MSTR_DTL.CLMDTL_SV_DATE":
				    return Common.StringToField(F002_CLAIMS_MSTR_CLMDTL_SV_DATE().PadRight( 8, ' '));

			    case "INDEXED.F002_CLAIMS_MSTR_DTL.CLMDTL_ID":
				    return Common.StringToField(F002_CLAIMS_MSTR_CLMDTL_ID().PadRight( 16, ' '));

			    case "INDEXED.F002_CLAIMS_MSTR_HDR.CLMHDR_REFERENCE":
				    return Common.StringToField(rdrF002_CLAIMS_MSTR_HDR.GetString("CLMHDR_REFERENCE").PadRight( 11, ' '));

			    case "INDEXED.F002_CLAIMS_MSTR_DTL.CLMDTL_AGENT_CD":
				    return rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_AGENT_CD").ToString().PadLeft( 1, ' ');

			    case "INDEXED.F002_CLAIMS_MSTR_DTL.CLMDTL_ADJ_CD":
				    return Common.StringToField(rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_ADJ_CD").PadRight( 1, ' '));

			    case "INDEXED.F002_CLAIMS_MSTR_DTL.CLMDTL_DIAG_CD":
				    return rdrF002_CLAIMS_MSTR_DTL.GetNumber("CLMDTL_DIAG_CD").ToString().PadLeft( 3, ' ');

			    case "INDEXED.F002_CLAIMS_MSTR_DTL.CLMDTL_OMA_CD":
				    return Common.StringToField(rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_OMA_CD").PadRight( 4, ' '));

			    case "INDEXED.F002_CLAIMS_MSTR_DTL.CLMDTL_OMA_SUFF":
				    return Common.StringToField(rdrF002_CLAIMS_MSTR_DTL.GetString("CLMDTL_OMA_SUFF").PadRight( 1, ' '));

			    case "INDEXED.F002_CLAIMS_MSTR_HDR.CLMHDR_ADJ_CD_SUB_TYPE":
				    return Common.StringToField(rdrF002_CLAIMS_MSTR_HDR.GetString("CLMHDR_ADJ_CD_SUB_TYPE").PadRight( 1, ' '));

			    case "INDEXED.F002_CLAIMS_MSTR_HDR.KEY_CLM_BATCH_NBR":
				    return Common.StringToField(rdrF002_CLAIMS_MSTR_HDR.GetString("KEY_CLM_BATCH_NBR").PadRight( 8, ' '));

			    case "INDEXED.F002_CLAIMS_MSTR_HDR.KEY_CLM_CLAIM_NBR":
				    return rdrF002_CLAIMS_MSTR_HDR.GetNumber("KEY_CLM_CLAIM_NBR").ToString().PadLeft( 2, ' ');

			    case "X_CLAIM_DTL_ID":
				    return Common.StringToField(X_CLAIM_DTL_ID().PadRight( 10, ' '));

			    case "X_ORIG_BATCH":
				    return Common.StringToField(X_ORIG_BATCH().PadRight( 8, ' '));

			    case "X_REV_OHIP_FEE":
				    return X_REV_OHIP_FEE().ToString().PadLeft( 7, ' ');

			    case "X_REV_OHIP_ADJ":
				    return X_REV_OHIP_ADJ().ToString().PadLeft( 7, ' ');

			    case "X_REV_OHIP_TOTAL":
				    return X_REV_OHIP_TOTAL().ToString().PadLeft( 7, ' ');

			    case "X_AGENT_0_REV":
				    return X_AGENT_0_REV().ToString().PadLeft( 7, ' ');

			    case "X_AGENT_1_REV":
				    return X_AGENT_1_REV().ToString().PadLeft( 7, ' ');

			    case "X_AGENT_2_REV":
				    return X_AGENT_2_REV().ToString().PadLeft( 7, ' ');

			    case "X_AGENT_3_REV":
				    return X_AGENT_3_REV().ToString().PadLeft( 7, ' ');

			    case "X_AGENT_4_REV":
				    return X_AGENT_4_REV().ToString().PadLeft( 7, ' ');

			    case "X_AGENT_5_REV":
				    return X_AGENT_5_REV().ToString().PadLeft( 7, ' ');

			    case "X_AGENT_6_REV":
				    return X_AGENT_6_REV().ToString().PadLeft( 7, ' ');

			    case "X_AGENT_7_REV":
				    return X_AGENT_7_REV().ToString().PadLeft( 7, ' ');

			    case "X_AGENT_8_REV":
				    return X_AGENT_8_REV().ToString().PadLeft( 7, ' ');

			    case "X_AGENT_9_REV":
				    return X_AGENT_9_REV().ToString().PadLeft( 7, ' ');

			    case "X_AG_0_ADJ_REV":
				    return X_AG_0_ADJ_REV().ToString().PadLeft( 7, ' ');

			    case "X_AG_1_ADJ_REV":
				    return X_AG_1_ADJ_REV().ToString().PadLeft( 7, ' ');

			    case "X_AG_2_ADJ_REV":
				    return X_AG_2_ADJ_REV().ToString().PadLeft( 7, ' ');

			    case "X_AG_3_ADJ_REV":
				    return X_AG_3_ADJ_REV().ToString().PadLeft( 7, ' ');

			    case "X_AG_4_ADJ_REV":
				    return X_AG_4_ADJ_REV().ToString().PadLeft( 7, ' ');

			    case "X_AG_5_ADJ_REV":
				    return X_AG_5_ADJ_REV().ToString().PadLeft( 7, ' ');

			    case "X_AG_6_ADJ_REV":
				    return X_AG_6_ADJ_REV().ToString().PadLeft( 7, ' ');

			    case "X_AG_7_ADJ_REV":
				    return X_AG_7_ADJ_REV().ToString().PadLeft( 7, ' ');

			    case "X_AG_8_ADJ_REV":
				    return X_AG_8_ADJ_REV().ToString().PadLeft( 7, ' ');

			    case "X_AG_9_ADJ_REV":
				    return X_AG_9_ADJ_REV().ToString().PadLeft( 7, ' ');

			    case "X_AG_0_TOT_REV":
				    return X_AG_0_TOT_REV().ToString().PadLeft( 7, ' ');

			    case "X_AG_1_TOT_REV":
				    return X_AG_1_TOT_REV().ToString().PadLeft( 7, ' ');

			    case "X_AG_2_TOT_REV":
				    return X_AG_2_TOT_REV().ToString().PadLeft( 7, ' ');

			    case "X_AG_3_TOT_REV":
				    return X_AG_3_TOT_REV().ToString().PadLeft( 7, ' ');

			    case "X_AG_4_TOT_REV":
				    return X_AG_4_TOT_REV().ToString().PadLeft( 7, ' ');

			    case "X_AG_5_TOT_REV":
				    return X_AG_5_TOT_REV().ToString().PadLeft( 7, ' ');

			    case "X_AG_6_TOT_REV":
				    return X_AG_6_TOT_REV().ToString().PadLeft( 7, ' ');

			    case "X_AG_7_TOT_REV":
				    return X_AG_7_TOT_REV().ToString().PadLeft( 7, ' ');

			    case "X_AG_8_TOT_REV":
				    return X_AG_8_TOT_REV().ToString().PadLeft( 7, ' ');

			    case "X_AG_9_TOT_REV":
				    return X_AG_9_TOT_REV().ToString().PadLeft( 7, ' ');

			    case "X_AR_OHIP_FEE":
				    return X_AR_OHIP_FEE().ToString().PadLeft( 7, ' ');

			    case "X_AR_OHIP_ADJ":
				    return X_AR_OHIP_ADJ().ToString().PadLeft( 7, ' ');

			    case "X_AR_OHIP_TOTAL":
				    return X_AR_OHIP_TOTAL().ToString().PadLeft( 7, ' ');

			    case "X_AGENT_0_AR":
				    return X_AGENT_0_AR().ToString().PadLeft( 7, ' ');

			    case "X_AGENT_1_AR":
				    return X_AGENT_1_AR().ToString().PadLeft( 7, ' ');

			    case "X_AGENT_2_AR":
				    return X_AGENT_2_AR().ToString().PadLeft( 7, ' ');

			    case "X_AGENT_3_AR":
				    return X_AGENT_3_AR().ToString().PadLeft( 7, ' ');

			    case "X_AGENT_4_AR":
				    return X_AGENT_4_AR().ToString().PadLeft( 7, ' ');

			    case "X_AGENT_5_AR":
				    return X_AGENT_5_AR().ToString().PadLeft( 7, ' ');

			    case "X_AGENT_6_AR":
				    return X_AGENT_6_AR().ToString().PadLeft( 7, ' ');

			    case "X_AGENT_7_AR":
				    return X_AGENT_7_AR().ToString().PadLeft( 7, ' ');

			    case "X_AGENT_8_AR":
				    return X_AGENT_8_AR().ToString().PadLeft( 7, ' ');

			    case "X_AGENT_9_AR":
				    return X_AGENT_9_AR().ToString().PadLeft( 7, ' ');

			    case "X_AGENT_0_ADJ_AR":
				    return X_AGENT_0_ADJ_AR().ToString().PadLeft( 7, ' ');

			    case "X_AGENT_1_ADJ_AR":
				    return X_AGENT_1_ADJ_AR().ToString().PadLeft( 7, ' ');

			    case "X_AGENT_2_ADJ_AR":
				    return X_AGENT_2_ADJ_AR().ToString().PadLeft( 7, ' ');

			    case "X_AGENT_3_ADJ_AR":
				    return X_AGENT_3_ADJ_AR().ToString().PadLeft( 7, ' ');

			    case "X_AGENT_4_ADJ_AR":
				    return X_AGENT_4_ADJ_AR().ToString().PadLeft( 7, ' ');

			    case "X_AGENT_5_ADJ_AR":
				    return X_AGENT_5_ADJ_AR().ToString().PadLeft( 7, ' ');

			    case "X_AGENT_6_ADJ_AR":
				    return X_AGENT_6_ADJ_AR().ToString().PadLeft( 7, ' ');

			    case "X_AGENT_7_ADJ_AR":
				    return X_AGENT_7_ADJ_AR().ToString().PadLeft( 7, ' ');

			    case "X_AGENT_8_ADJ_AR":
				    return X_AGENT_8_ADJ_AR().ToString().PadLeft( 7, ' ');

			    case "X_AGENT_9_ADJ_AR":
				    return X_AGENT_9_ADJ_AR().ToString().PadLeft( 7, ' ');

			    case "X_AGENT_0_TOT_AR":
				    return X_AGENT_0_TOT_AR().ToString().PadLeft( 7, ' ');

			    case "X_AGENT_1_TOT_AR":
				    return X_AGENT_1_TOT_AR().ToString().PadLeft( 7, ' ');

			    case "X_AGENT_2_TOT_AR":
				    return X_AGENT_2_TOT_AR().ToString().PadLeft( 7, ' ');

			    case "X_AGENT_3_TOT_AR":
				    return X_AGENT_3_TOT_AR().ToString().PadLeft( 7, ' ');

			    case "X_AGENT_4_TOT_AR":
				    return X_AGENT_4_TOT_AR().ToString().PadLeft( 7, ' ');

			    case "X_AGENT_5_TOT_AR":
				    return X_AGENT_5_TOT_AR().ToString().PadLeft( 7, ' ');

			    case "X_AGENT_6_TOT_AR":
				    return X_AGENT_6_TOT_AR().ToString().PadLeft( 7, ' ');

			    case "X_AGENT_7_TOT_AR":
				    return X_AGENT_7_TOT_AR().ToString().PadLeft( 7, ' ');

			    case "X_AGENT_8_TOT_AR":
				    return X_AGENT_8_TOT_AR().ToString().PadLeft( 7, ' ');

			    case "X_AGENT_9_TOT_AR":
				    return X_AGENT_9_TOT_AR().ToString().PadLeft( 7, ' ');

			    case "X_NBR_SVCS":
				    return X_NBR_SVCS().ToString().PadLeft( 2, ' ');

			    case "X_SOURCE":
				    return Common.StringToField(X_SOURCE().PadRight( 2, ' '));

			    case "INDEXED.F070_DEPT_MSTR.DEPT_NAME":
				    return Common.StringToField(rdrF070_DEPT_MSTR.GetString("DEPT_NAME").PadRight( 30, ' '));

			    case "TEMPORARYDATA.R004A.PAT_SURNAME":
				    return Common.StringToField(rdrR004A.GetString("PAT_SURNAME").PadRight( 25, ' '));

			    case "TEMPORARYDATA.R004A.PAT_GIVEN_NAME":
				    return Common.StringToField(rdrR004A.GetString("PAT_GIVEN_NAME").PadRight( 17, ' '));

			    default:

				    return string.Empty;
		    }
	    }

        public override void AccessData()
	    {
		    try
		    {
			    Access_R004A();

			    while (rdrR004A.Read())
                {
				    Link_F002_CLAIMS_MSTR_HDR();
				    while (rdrF002_CLAIMS_MSTR_HDR.Read())
                    {
                        Link_F002_CLAIMS_MSTR_DTL();
                        while (rdrF002_CLAIMS_MSTR_DTL.Read())
                        {
                            Link_F070_DEPT_MSTR();
                            while ((rdrF070_DEPT_MSTR.Read()))
                            {
                                WriteData();
                            }
                            rdrF070_DEPT_MSTR.Close();
                        }
                        rdrF002_CLAIMS_MSTR_DTL.Close();
                    }
				    rdrF002_CLAIMS_MSTR_HDR.Close();
			    }
			    rdrR004A.Close();

		    }

		    catch (Exception ex)
		    {
			    ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
		    }
	    }

	    public override void CloseReaders()
	    {
		    if ((rdrR004A != null))
            {
			    rdrR004A.Close();
			    rdrR004A = null;
		    }
		    if ((rdrF002_CLAIMS_MSTR_HDR != null))
            {
			    rdrF002_CLAIMS_MSTR_HDR.Close();
			    rdrF002_CLAIMS_MSTR_HDR = null;
		    }
            if ((rdrF002_CLAIMS_MSTR_DTL != null))
            {
                rdrF002_CLAIMS_MSTR_DTL.Close();
                rdrF002_CLAIMS_MSTR_DTL = null;
            }
            if ((rdrF070_DEPT_MSTR != null))
            {
			    rdrF070_DEPT_MSTR.Close();
			    rdrF070_DEPT_MSTR = null;
		    }
	    }


	    #endregion

	    #endregion
    }
}
