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
    public class R004C : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R004C";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrR004B = new Reader();

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
                Sort = "ICONST_CLINIC_NBR_1_2 ASC, CLMHDR_DOC_DEPT ASC, X_DOC_NBR ASC, X_PAT_NAME ASC, CLMDTL_SV_DATE ASC, X_CLAIM_DTL_ID ASC, X_OMA_CODE ASC";
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

        private void Access_R004B()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("* ");
            strSQL.Append("FROM TEMPORARYDATA.R004B ");

            strSQL.Append(Choose());

            rdrR004B.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
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

        #endregion

        #region " DEFINES "

        #endregion

        #region " CONTROLS "

        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.R004B.ICONST_CLINIC_NBR_1_2", DataTypes.Numeric, 2);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.R004B.ICONST_DATE_PERIOD_END", DataTypes.Numeric, 9);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.R004B.CLMHDR_DOC_DEPT", DataTypes.Numeric, 2);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.R004B.DEPT_NAME", DataTypes.Character, 30);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.R004B.X_DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.PAGE_HEADING, "TEMPORARYDATA.R004B.X_DOC_NAME", DataTypes.Character, 35);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R004B.X_PAT_NAME", DataTypes.Character, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R004B.X_CLAIM_DTL_ID", DataTypes.Character, 10);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R004B.X_PAT_ID_INFO", DataTypes.Character, 12);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R004B.CLMDTL_AGENT_CD", DataTypes.Numeric, 1);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R004B.CLMDTL_ADJ_CD", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R004B.X_SOURCE", DataTypes.Character, 2);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R004B.X_REV_OHIP_FEE", DataTypes.Numeric, 7);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R004B.X_REV_OHIP_ADJ", DataTypes.Numeric, 7);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R004B.CLMDTL_SV_DATE", DataTypes.Character, 8);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R004B.CLMHDR_DATE_SYS", DataTypes.Character, 8);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R004B.CLMDTL_DIAG_CD", DataTypes.Numeric, 3);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R004B.CLMDTL_OMA_CD", DataTypes.Character, 4);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R004B.CLMDTL_OMA_SUFF", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R004B.X_NBR_SVCS", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R004B.X_ORIG_BATCH", DataTypes.Character, 8);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R004B.CLMHDR_REFERENCE", DataTypes.Character, 11);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_AGENT_0_AR", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_AGENT_1_AR", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_AGENT_2_AR", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_AGENT_3_AR", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_AGENT_4_AR", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_AGENT_5_AR", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_AGENT_6_AR", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_AGENT_7_AR", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_AGENT_8_AR", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_AGENT_9_AR", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_AR_OHIP_FEE", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_AGENT_0_ADJ_AR", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_AGENT_1_ADJ_AR", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_AGENT_2_ADJ_AR", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_AGENT_3_ADJ_AR", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_AGENT_4_ADJ_AR", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_AGENT_5_ADJ_AR", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_AGENT_6_ADJ_AR", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_AGENT_7_ADJ_AR", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_AGENT_8_ADJ_AR", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_AGENT_9_ADJ_AR", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_AR_OHIP_ADJ", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_AGENT_0_TOT_AR", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_AGENT_1_TOT_AR", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_AGENT_2_TOT_AR", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_AGENT_3_TOT_AR", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_AGENT_4_TOT_AR", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_AGENT_5_TOT_AR", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_AGENT_6_TOT_AR", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_AGENT_7_TOT_AR", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_AGENT_8_TOT_AR", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_AGENT_9_TOT_AR", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_AR_OHIP_TOTAL", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_AGENT_0_REV", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_AGENT_1_REV", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_AGENT_2_REV", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_AGENT_3_REV", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_AGENT_4_REV", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_AGENT_5_REV", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_AGENT_6_REV", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_AGENT_7_REV", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_AGENT_8_REV", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_AGENT_9_REV", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_REV_OHIP_FEE", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_AG_0_ADJ_REV", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_AG_1_ADJ_REV", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_AG_2_ADJ_REV", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_AG_3_ADJ_REV", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_AG_4_ADJ_REV", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_AG_5_ADJ_REV", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_AG_6_ADJ_REV", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_AG_7_ADJ_REV", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_AG_8_ADJ_REV", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_AG_9_ADJ_REV", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_REV_OHIP_ADJ", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_AG_0_TOT_REV", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_AG_1_TOT_REV", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_AG_2_TOT_REV", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_AG_3_TOT_REV", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_AG_4_TOT_REV", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_AG_5_TOT_REV", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_AG_6_TOT_REV", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_AG_7_TOT_REV", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_AG_8_TOT_REV", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_AG_9_TOT_REV", DataTypes.Numeric, 7);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.X_REV_OHIP_TOTAL", DataTypes.Numeric, 7);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R004B.X_OMA_CODE", DataTypes.Character, 5);
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
        // # Do not delete, modify or move it.  Updated: 2018-04-27 12:13:28 PM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "TEMPORARYDATA.R004B.ICONST_CLINIC_NBR_1_2":
                    return rdrR004B.GetNumber("ICONST_CLINIC_NBR_1_2").ToString();
					
				case "TEMPORARYDATA.R004B.ICONST_DATE_PERIOD_END":
                    return rdrR004B.GetNumber("ICONST_DATE_PERIOD_END").ToString();

                case "TEMPORARYDATA.R004B.CLMHDR_DOC_DEPT":
                    return rdrR004B.GetNumber("CLMHDR_DOC_DEPT").ToString();
					
				case "TEMPORARYDATA.R004B.DEPT_NAME":
                    return Common.StringToField(rdrR004B.GetString("DEPT_NAME"));

                case "TEMPORARYDATA.R004B.X_DOC_NBR":
                    return Common.StringToField(rdrR004B.GetString("X_DOC_NBR"));
					
				case "TEMPORARYDATA.R004B.X_DOC_NAME":
                    return Common.StringToField(rdrR004B.GetString("X_DOC_NAME"));

                case "TEMPORARYDATA.R004B.X_PAT_NAME":
                    return Common.StringToField(rdrR004B.GetString("X_PAT_NAME"));

                case "TEMPORARYDATA.R004B.X_PAT_ID_INFO":
                    return Common.StringToField(rdrR004B.GetString("X_PAT_ID_INFO"));

                case "TEMPORARYDATA.R004B.CLMDTL_SV_DATE":
                    return Common.StringToField(rdrR004B.GetString("CLMDTL_SV_DATE"));

                case "TEMPORARYDATA.R004B.X_CLAIM_DTL_ID":
                    return Common.StringToField(rdrR004B.GetString("X_CLAIM_DTL_ID"));

                case "TEMPORARYDATA.R004B.X_OMA_CODE":
                    return Common.StringToField(rdrR004B.GetString("X_OMA_CODE"));
					
				case "TEMPORARYDATA.R004B.CLMDTL_AGENT_CD":
                    return rdrR004B.GetNumber("CLMDTL_AGENT_CD").ToString();
					
				case "TEMPORARYDATA.R004B.CLMDTL_ADJ_CD":
                    return Common.StringToField(rdrR004B.GetString("CLMDTL_ADJ_CD"));
					
				case "TEMPORARYDATA.R004B.X_SOURCE":
                    return Common.StringToField(rdrR004B.GetString("X_SOURCE"));
					
				case "TEMPORARYDATA.R004B.X_REV_OHIP_FEE":
                    return rdrR004B.GetNumber("X_REV_OHIP_FEE").ToString();
					
				case "TEMPORARYDATA.R004B.X_REV_OHIP_ADJ":
                    return rdrR004B.GetNumber("X_REV_OHIP_ADJ").ToString();
					
				case "TEMPORARYDATA.R004B.CLMHDR_DATE_SYS":
                    return Common.StringToField(rdrR004B.GetString("CLMHDR_DATE_SYS"));
					
				case "TEMPORARYDATA.R004B.CLMDTL_DIAG_CD":
                    return rdrR004B.GetNumber("CLMDTL_DIAG_CD").ToString();
					
				case "TEMPORARYDATA.R004B.CLMDTL_OMA_CD":
                    return Common.StringToField(rdrR004B.GetString("CLMDTL_OMA_CD"));
					
				case "TEMPORARYDATA.R004B.CLMDTL_OMA_SUFF":
                    return Common.StringToField(rdrR004B.GetString("CLMDTL_OMA_SUFF"));
					
				case "TEMPORARYDATA.R004B.X_NBR_SVCS":
                    return rdrR004B.GetNumber("X_NBR_SVCS").ToString();
					
				case "TEMPORARYDATA.R004B.X_ORIG_BATCH":
                    return Common.StringToField(rdrR004B.GetString("X_ORIG_BATCH"));
					
				case "TEMPORARYDATA.R004B.CLMHDR_REFERENCE":
                    return Common.StringToField(rdrR004B.GetString("CLMHDR_REFERENCE"));

                case "TEMPORARYDATA.R004B.X_AGENT_0_AR":
                    return rdrR004B.GetNumber("X_AGENT_0_AR").ToString();

                case "TEMPORARYDATA.R004B.X_AGENT_1_AR":
                    return rdrR004B.GetNumber("X_AGENT_1_AR").ToString();

                case "TEMPORARYDATA.R004B.X_AGENT_2_AR":
                    return rdrR004B.GetNumber("X_AGENT_2_AR").ToString();

                case "TEMPORARYDATA.R004B.X_AGENT_3_AR":
                    return rdrR004B.GetNumber("X_AGENT_3_AR").ToString();

                case "TEMPORARYDATA.R004B.X_AGENT_4_AR":
                    return rdrR004B.GetNumber("X_AGENT_4_AR").ToString();

                case "TEMPORARYDATA.R004B.X_AGENT_5_AR":
                    return rdrR004B.GetNumber("X_AGENT_5_AR").ToString();

                case "TEMPORARYDATA.R004B.X_AGENT_6_AR":
                    return rdrR004B.GetNumber("X_AGENT_6_AR").ToString();

                case "TEMPORARYDATA.R004B.X_AGENT_7_AR":
                    return rdrR004B.GetNumber("X_AGENT_7_AR").ToString();

                case "TEMPORARYDATA.R004B.X_AGENT_8_AR":
                    return rdrR004B.GetNumber("X_AGENT_8_AR").ToString();

                case "TEMPORARYDATA.R004B.X_AGENT_9_AR":
                    return rdrR004B.GetNumber("X_AGENT_9_AR").ToString();

                case "TEMPORARYDATA.R004B.X_AR_OHIP_FEE":
                    return rdrR004B.GetNumber("X_AR_OHIP_FEE").ToString();

                case "TEMPORARYDATA.R004B.X_AGENT_0_ADJ_AR":
                    return rdrR004B.GetNumber("X_AGENT_0_ADJ_AR").ToString();

                case "TEMPORARYDATA.R004B.X_AGENT_1_ADJ_AR":
                    return rdrR004B.GetNumber("X_AGENT_1_ADJ_AR").ToString();

                case "TEMPORARYDATA.R004B.X_AGENT_2_ADJ_AR":
                    return rdrR004B.GetNumber("X_AGENT_2_ADJ_AR").ToString();

                case "TEMPORARYDATA.R004B.X_AGENT_3_ADJ_AR":
                    return rdrR004B.GetNumber("X_AGENT_3_ADJ_AR").ToString();

                case "TEMPORARYDATA.R004B.X_AGENT_4_ADJ_AR":
                    return rdrR004B.GetNumber("X_AGENT_4_ADJ_AR").ToString();

                case "TEMPORARYDATA.R004B.X_AGENT_5_ADJ_AR":
                    return rdrR004B.GetNumber("X_AGENT_5_ADJ_AR").ToString();

                case "TEMPORARYDATA.R004B.X_AGENT_6_ADJ_AR":
                    return rdrR004B.GetNumber("X_AGENT_6_ADJ_AR").ToString();

                case "TEMPORARYDATA.R004B.X_AGENT_7_ADJ_AR":
                    return rdrR004B.GetNumber("X_AGENT_7_ADJ_AR").ToString();

                case "TEMPORARYDATA.R004B.X_AGENT_8_ADJ_AR":
                    return rdrR004B.GetNumber("X_AGENT_8_ADJ_AR").ToString();

                case "TEMPORARYDATA.R004B.X_AGENT_9_ADJ_AR":
                    return rdrR004B.GetNumber("X_AGENT_9_ADJ_AR").ToString();

                case "TEMPORARYDATA.R004B.X_AR_OHIP_ADJ":
                    return rdrR004B.GetNumber("X_AR_OHIP_ADJ").ToString();

                case "TEMPORARYDATA.R004B.X_AGENT_0_TOT_AR":
                    return rdrR004B.GetNumber("X_AGENT_0_TOT_AR").ToString();

                case "TEMPORARYDATA.R004B.X_AGENT_1_TOT_AR":
                    return rdrR004B.GetNumber("X_AGENT_1_TOT_AR").ToString();

                case "TEMPORARYDATA.R004B.X_AGENT_2_TOT_AR":
                    return rdrR004B.GetNumber("X_AGENT_2_TOT_AR").ToString();

                case "TEMPORARYDATA.R004B.X_AGENT_3_TOT_AR":
                    return rdrR004B.GetNumber("X_AGENT_3_TOT_AR").ToString();

                case "TEMPORARYDATA.R004B.X_AGENT_4_TOT_AR":
                    return rdrR004B.GetNumber("X_AGENT_4_TOT_AR").ToString();

                case "TEMPORARYDATA.R004B.X_AGENT_5_TOT_AR":
                    return rdrR004B.GetNumber("X_AGENT_5_TOT_AR").ToString();

                case "TEMPORARYDATA.R004B.X_AGENT_6_TOT_AR":
                    return rdrR004B.GetNumber("X_AGENT_6_TOT_AR").ToString();

                case "TEMPORARYDATA.R004B.X_AGENT_7_TOT_AR":
                    return rdrR004B.GetNumber("X_AGENT_7_TOT_AR").ToString();

                case "TEMPORARYDATA.R004B.X_AGENT_8_TOT_AR":
                    return rdrR004B.GetNumber("X_AGENT_8_TOT_AR").ToString();

                case "TEMPORARYDATA.R004B.X_AGENT_9_TOT_AR":
                    return rdrR004B.GetNumber("X_AGENT_9_TOT_AR").ToString();

                case "TEMPORARYDATA.R004B.X_AR_OHIP_TOTAL":
                    return rdrR004B.GetNumber("X_AR_OHIP_TOTAL").ToString();

                case "TEMPORARYDATA.R004B.X_AGENT_0_REV":
                    return rdrR004B.GetNumber("X_AGENT_0_REV").ToString();

                case "TEMPORARYDATA.R004B.X_AGENT_1_REV":
                    return rdrR004B.GetNumber("X_AGENT_1_REV").ToString();

                case "TEMPORARYDATA.R004B.X_AGENT_2_REV":
                    return rdrR004B.GetNumber("X_AGENT_2_REV").ToString();

                case "TEMPORARYDATA.R004B.X_AGENT_3_REV":
                    return rdrR004B.GetNumber("X_AGENT_3_REV").ToString();

                case "TEMPORARYDATA.R004B.X_AGENT_4_REV":
                    return rdrR004B.GetNumber("X_AGENT_4_REV").ToString();

                case "TEMPORARYDATA.R004B.X_AGENT_5_REV":
                    return rdrR004B.GetNumber("X_AGENT_5_REV").ToString();

                case "TEMPORARYDATA.R004B.X_AGENT_6_REV":
                    return rdrR004B.GetNumber("X_AGENT_6_REV").ToString();

                case "TEMPORARYDATA.R004B.X_AGENT_7_REV":
                    return rdrR004B.GetNumber("X_AGENT_7_REV").ToString();

                case "TEMPORARYDATA.R004B.X_AGENT_8_REV":
                    return rdrR004B.GetNumber("X_AGENT_8_REV").ToString();

                case "TEMPORARYDATA.R004B.X_AGENT_9_REV":
                    return rdrR004B.GetNumber("X_AGENT_9_REV").ToString();

                case "TEMPORARYDATA.R004B.X_AG_0_ADJ_REV":
                    return rdrR004B.GetNumber("X_AG_0_ADJ_REV").ToString();

                case "TEMPORARYDATA.R004B.X_AG_1_ADJ_REV":
                    return rdrR004B.GetNumber("X_AG_1_ADJ_REV").ToString();

                case "TEMPORARYDATA.R004B.X_AG_2_ADJ_REV":
                    return rdrR004B.GetNumber("X_AG_2_ADJ_REV").ToString();

                case "TEMPORARYDATA.R004B.X_AG_3_ADJ_REV":
                    return rdrR004B.GetNumber("X_AG_3_ADJ_REV").ToString();

                case "TEMPORARYDATA.R004B.X_AG_4_ADJ_REV":
                    return rdrR004B.GetNumber("X_AG_4_ADJ_REV").ToString();

                case "TEMPORARYDATA.R004B.X_AG_5_ADJ_REV":
                    return rdrR004B.GetNumber("X_AG_5_ADJ_REV").ToString();

                case "TEMPORARYDATA.R004B.X_AG_6_ADJ_REV":
                    return rdrR004B.GetNumber("X_AG_6_ADJ_REV").ToString();

                case "TEMPORARYDATA.R004B.X_AG_7_ADJ_REV":
                    return rdrR004B.GetNumber("X_AG_7_ADJ_REV").ToString();

                case "TEMPORARYDATA.R004B.X_AG_8_ADJ_REV":
                    return rdrR004B.GetNumber("X_AG_8_ADJ_REV").ToString();

                case "TEMPORARYDATA.R004B.X_AG_9_ADJ_REV":
                    return rdrR004B.GetNumber("X_AG_9_ADJ_REV").ToString();

                case "TEMPORARYDATA.R004B.X_AG_0_TOT_REV":
                    return rdrR004B.GetNumber("X_AG_0_TOT_REV").ToString();

                case "TEMPORARYDATA.R004B.X_AG_1_TOT_REV":
                    return rdrR004B.GetNumber("X_AG_1_TOT_REV").ToString();

                case "TEMPORARYDATA.R004B.X_AG_2_TOT_REV":
                    return rdrR004B.GetNumber("X_AG_2_TOT_REV").ToString();

                case "TEMPORARYDATA.R004B.X_AG_3_TOT_REV":
                    return rdrR004B.GetNumber("X_AG_3_TOT_REV").ToString();

                case "TEMPORARYDATA.R004B.X_AG_4_TOT_REV":
                    return rdrR004B.GetNumber("X_AG_4_TOT_REV").ToString();

                case "TEMPORARYDATA.R004B.X_AG_5_TOT_REV":
                    return rdrR004B.GetNumber("X_AG_5_TOT_REV").ToString();

                case "TEMPORARYDATA.R004B.X_AG_6_TOT_REV":
                    return rdrR004B.GetNumber("X_AG_6_TOT_REV").ToString();

                case "TEMPORARYDATA.R004B.X_AG_7_TOT_REV":
                    return rdrR004B.GetNumber("X_AG_7_TOT_REV").ToString();

                case "TEMPORARYDATA.R004B.X_AG_8_TOT_REV":
                    return rdrR004B.GetNumber("X_AG_8_TOT_REV").ToString();

                case "TEMPORARYDATA.R004B.X_AG_9_TOT_REV":
                    return rdrR004B.GetNumber("X_AG_9_TOT_REV").ToString();

                case "TEMPORARYDATA.R004B.X_REV_OHIP_TOTAL":
                    return rdrR004B.GetNumber("X_REV_OHIP_TOTAL").ToString();

                default:
                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_R004B();
                while (rdrR004B.Read())
                {
                    WriteData();
                }

                rdrR004B.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrR004B != null))
            {
                rdrR004B.Close();
                rdrR004B = null;
            }
        }

        #endregion

        #endregion
    }
}
