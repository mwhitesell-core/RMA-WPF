#region "Screen Comments"

// doc: r004d.qzs
// program purpose : transaction summary (detail report)
// use r004b.sf and create detail report
// r004d.txt control break at doc-dept
// modification history
// date       by whom   description
// 92/12/03   yasemin   original
// 04/12/07   MC        make the neccessary changes

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
    public class R004D : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R004D";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
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

                Sort = "ICONST_CLINIC_NBR_1_2 ASC, CLMHDR_DOC_DEPT ASC";

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

        private void Access_R004B()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("ICONST_CLINIC_NBR_1_2, ");
            strSQL.Append("CLMHDR_DOC_DEPT, ");
            strSQL.Append("ICONST_DATE_PERIOD_END, ");
            strSQL.Append("DEPT_NAME, ");
            strSQL.Append("X_AGENT_0_AR, ");
            strSQL.Append("X_AGENT_1_AR, ");
            strSQL.Append("X_AGENT_2_AR, ");
            strSQL.Append("X_AGENT_3_AR, ");
            strSQL.Append("X_AGENT_4_AR, ");
            strSQL.Append("X_AGENT_5_AR, ");
            strSQL.Append("X_AGENT_6_AR, ");
            strSQL.Append("X_AGENT_7_AR, ");
            strSQL.Append("X_AGENT_8_AR, ");
            strSQL.Append("X_AGENT_9_AR, ");
            strSQL.Append("X_AR_OHIP_FEE, ");
            strSQL.Append("X_AGENT_0_ADJ_AR, ");
            strSQL.Append("X_AGENT_1_ADJ_AR, ");
            strSQL.Append("X_AGENT_2_ADJ_AR, ");
            strSQL.Append("X_AGENT_3_ADJ_AR, ");
            strSQL.Append("X_AGENT_4_ADJ_AR, ");
            strSQL.Append("X_AGENT_5_ADJ_AR, ");
            strSQL.Append("X_AGENT_6_ADJ_AR, ");
            strSQL.Append("X_AGENT_7_ADJ_AR, ");
            strSQL.Append("X_AGENT_8_ADJ_AR, ");
            strSQL.Append("X_AGENT_9_ADJ_AR, ");
            strSQL.Append("X_AR_OHIP_ADJ, ");
            strSQL.Append("X_AGENT_0_TOT_AR, ");
            strSQL.Append("X_AGENT_1_TOT_AR, ");
            strSQL.Append("X_AGENT_2_TOT_AR, ");
            strSQL.Append("X_AGENT_3_TOT_AR, ");
            strSQL.Append("X_AGENT_4_TOT_AR, ");
            strSQL.Append("X_AGENT_5_TOT_AR, ");
            strSQL.Append("X_AGENT_6_TOT_AR, ");
            strSQL.Append("X_AGENT_7_TOT_AR, ");
            strSQL.Append("X_AGENT_8_TOT_AR, ");
            strSQL.Append("X_AGENT_9_TOT_AR, ");
            strSQL.Append("X_AR_OHIP_TOTAL, ");
            strSQL.Append("X_AGENT_0_REV, ");
            strSQL.Append("X_AGENT_1_REV, ");
            strSQL.Append("X_AGENT_2_REV, ");
            strSQL.Append("X_AGENT_3_REV, ");
            strSQL.Append("X_AGENT_4_REV, ");
            strSQL.Append("X_AGENT_5_REV, ");
            strSQL.Append("X_AGENT_6_REV, ");
            strSQL.Append("X_AGENT_7_REV, ");
            strSQL.Append("X_AGENT_8_REV, ");
            strSQL.Append("X_AGENT_9_REV, ");
            strSQL.Append("X_REV_OHIP_FEE, ");
            strSQL.Append("X_AG_0_ADJ_REV, ");
            strSQL.Append("X_AG_1_ADJ_REV, ");
            strSQL.Append("X_AG_2_ADJ_REV, ");
            strSQL.Append("X_AG_3_ADJ_REV, ");
            strSQL.Append("X_AG_4_ADJ_REV, ");
            strSQL.Append("X_AG_5_ADJ_REV, ");
            strSQL.Append("X_AG_6_ADJ_REV, ");
            strSQL.Append("X_AG_7_ADJ_REV, ");
            strSQL.Append("X_AG_8_ADJ_REV, ");
            strSQL.Append("X_AG_9_ADJ_REV, ");
            strSQL.Append("X_REV_OHIP_ADJ, ");
            strSQL.Append("X_AG_0_TOT_REV, ");
            strSQL.Append("X_AG_1_TOT_REV, ");
            strSQL.Append("X_AG_2_TOT_REV, ");
            strSQL.Append("X_AG_3_TOT_REV, ");
            strSQL.Append("X_AG_4_TOT_REV, ");
            strSQL.Append("X_AG_5_TOT_REV, ");
            strSQL.Append("X_AG_6_TOT_REV, ");
            strSQL.Append("X_AG_7_TOT_REV, ");
            strSQL.Append("X_AG_8_TOT_REV, ");
            strSQL.Append("X_AG_9_TOT_REV, ");
            strSQL.Append("X_REV_OHIP_TOTAL ");
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
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.CLMHDR_DOC_DEPT", DataTypes.Numeric, 2);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.R004B.DEPT_NAME", DataTypes.Character, 30);
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
        //# Do not delete, modify or move it.  Updated: 10/24/2017 8:38:23 AM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "TEMPORARYDATA.R004B.ICONST_CLINIC_NBR_1_2":
                    return rdrR004B.GetNumber("ICONST_CLINIC_NBR_1_2").ToString().PadLeft(2, ' ');

                case "TEMPORARYDATA.R004B.ICONST_DATE_PERIOD_END":
                    return rdrR004B.GetNumber("ICONST_DATE_PERIOD_END").ToString().PadLeft(9, ' ');

                case "TEMPORARYDATA.R004B.CLMHDR_DOC_DEPT":
                    return rdrR004B.GetNumber("CLMHDR_DOC_DEPT").ToString().PadLeft(2, ' ');

                case "TEMPORARYDATA.R004B.DEPT_NAME":
                    return Common.StringToField(rdrR004B.GetString("DEPT_NAME").PadRight(30, ' '));

                case "TEMPORARYDATA.R004B.X_AGENT_0_AR":
                    return rdrR004B.GetNumber("X_AGENT_0_AR").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_AGENT_1_AR":
                    return rdrR004B.GetNumber("X_AGENT_1_AR").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_AGENT_2_AR":
                    return rdrR004B.GetNumber("X_AGENT_2_AR").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_AGENT_3_AR":
                    return rdrR004B.GetNumber("X_AGENT_3_AR").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_AGENT_4_AR":
                    return rdrR004B.GetNumber("X_AGENT_4_AR").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_AGENT_5_AR":
                    return rdrR004B.GetNumber("X_AGENT_5_AR").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_AGENT_6_AR":
                    return rdrR004B.GetNumber("X_AGENT_6_AR").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_AGENT_7_AR":
                    return rdrR004B.GetNumber("X_AGENT_7_AR").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_AGENT_8_AR":
                    return rdrR004B.GetNumber("X_AGENT_8_AR").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_AGENT_9_AR":
                    return rdrR004B.GetNumber("X_AGENT_9_AR").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_AR_OHIP_FEE":
                    return rdrR004B.GetNumber("X_AR_OHIP_FEE").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_AGENT_0_ADJ_AR":
                    return rdrR004B.GetNumber("X_AGENT_0_ADJ_AR").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_AGENT_1_ADJ_AR":
                    return rdrR004B.GetNumber("X_AGENT_1_ADJ_AR").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_AGENT_2_ADJ_AR":
                    return rdrR004B.GetNumber("X_AGENT_2_ADJ_AR").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_AGENT_3_ADJ_AR":
                    return rdrR004B.GetNumber("X_AGENT_3_ADJ_AR").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_AGENT_4_ADJ_AR":
                    return rdrR004B.GetNumber("X_AGENT_4_ADJ_AR").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_AGENT_5_ADJ_AR":
                    return rdrR004B.GetNumber("X_AGENT_5_ADJ_AR").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_AGENT_6_ADJ_AR":
                    return rdrR004B.GetNumber("X_AGENT_6_ADJ_AR").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_AGENT_7_ADJ_AR":
                    return rdrR004B.GetNumber("X_AGENT_7_ADJ_AR").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_AGENT_8_ADJ_AR":
                    return rdrR004B.GetNumber("X_AGENT_8_ADJ_AR").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_AGENT_9_ADJ_AR":
                    return rdrR004B.GetNumber("X_AGENT_9_ADJ_AR").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_AR_OHIP_ADJ":
                    return rdrR004B.GetNumber("X_AR_OHIP_ADJ").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_AGENT_0_TOT_AR":
                    return rdrR004B.GetNumber("X_AGENT_0_TOT_AR").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_AGENT_1_TOT_AR":
                    return rdrR004B.GetNumber("X_AGENT_1_TOT_AR").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_AGENT_2_TOT_AR":
                    return rdrR004B.GetNumber("X_AGENT_2_TOT_AR").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_AGENT_3_TOT_AR":
                    return rdrR004B.GetNumber("X_AGENT_3_TOT_AR").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_AGENT_4_TOT_AR":
                    return rdrR004B.GetNumber("X_AGENT_4_TOT_AR").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_AGENT_5_TOT_AR":
                    return rdrR004B.GetNumber("X_AGENT_5_TOT_AR").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_AGENT_6_TOT_AR":
                    return rdrR004B.GetNumber("X_AGENT_6_TOT_AR").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_AGENT_7_TOT_AR":
                    return rdrR004B.GetNumber("X_AGENT_7_TOT_AR").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_AGENT_8_TOT_AR":
                    return rdrR004B.GetNumber("X_AGENT_8_TOT_AR").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_AGENT_9_TOT_AR":
                    return rdrR004B.GetNumber("X_AGENT_9_TOT_AR").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_AR_OHIP_TOTAL":
                    return rdrR004B.GetNumber("X_AR_OHIP_TOTAL").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_AGENT_0_REV":
                    return rdrR004B.GetNumber("X_AGENT_0_REV").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_AGENT_1_REV":
                    return rdrR004B.GetNumber("X_AGENT_1_REV").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_AGENT_2_REV":
                    return rdrR004B.GetNumber("X_AGENT_2_REV").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_AGENT_3_REV":
                    return rdrR004B.GetNumber("X_AGENT_3_REV").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_AGENT_4_REV":
                    return rdrR004B.GetNumber("X_AGENT_4_REV").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_AGENT_5_REV":
                    return rdrR004B.GetNumber("X_AGENT_5_REV").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_AGENT_6_REV":
                    return rdrR004B.GetNumber("X_AGENT_6_REV").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_AGENT_7_REV":
                    return rdrR004B.GetNumber("X_AGENT_7_REV").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_AGENT_8_REV":
                    return rdrR004B.GetNumber("X_AGENT_8_REV").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_AGENT_9_REV":
                    return rdrR004B.GetNumber("X_AGENT_9_REV").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_REV_OHIP_FEE":
                    return rdrR004B.GetNumber("X_REV_OHIP_FEE").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_AG_0_ADJ_REV":
                    return rdrR004B.GetNumber("X_AG_0_ADJ_REV").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_AG_1_ADJ_REV":
                    return rdrR004B.GetNumber("X_AG_1_ADJ_REV").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_AG_2_ADJ_REV":
                    return rdrR004B.GetNumber("X_AG_2_ADJ_REV").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_AG_3_ADJ_REV":
                    return rdrR004B.GetNumber("X_AG_3_ADJ_REV").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_AG_4_ADJ_REV":
                    return rdrR004B.GetNumber("X_AG_4_ADJ_REV").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_AG_5_ADJ_REV":
                    return rdrR004B.GetNumber("X_AG_5_ADJ_REV").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_AG_6_ADJ_REV":
                    return rdrR004B.GetNumber("X_AG_6_ADJ_REV").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_AG_7_ADJ_REV":
                    return rdrR004B.GetNumber("X_AG_7_ADJ_REV").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_AG_8_ADJ_REV":
                    return rdrR004B.GetNumber("X_AG_8_ADJ_REV").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_AG_9_ADJ_REV":
                    return rdrR004B.GetNumber("X_AG_9_ADJ_REV").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_REV_OHIP_ADJ":
                    return rdrR004B.GetNumber("X_REV_OHIP_ADJ").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_AG_0_TOT_REV":
                    return rdrR004B.GetNumber("X_AG_0_TOT_REV").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_AG_1_TOT_REV":
                    return rdrR004B.GetNumber("X_AG_1_TOT_REV").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_AG_2_TOT_REV":
                    return rdrR004B.GetNumber("X_AG_2_TOT_REV").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_AG_3_TOT_REV":
                    return rdrR004B.GetNumber("X_AG_3_TOT_REV").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_AG_4_TOT_REV":
                    return rdrR004B.GetNumber("X_AG_4_TOT_REV").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_AG_5_TOT_REV":
                    return rdrR004B.GetNumber("X_AG_5_TOT_REV").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_AG_6_TOT_REV":
                    return rdrR004B.GetNumber("X_AG_6_TOT_REV").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_AG_7_TOT_REV":
                    return rdrR004B.GetNumber("X_AG_7_TOT_REV").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_AG_8_TOT_REV":
                    return rdrR004B.GetNumber("X_AG_8_TOT_REV").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_AG_9_TOT_REV":
                    return rdrR004B.GetNumber("X_AG_9_TOT_REV").ToString().PadLeft(7, ' ');

                case "TEMPORARYDATA.R004B.X_REV_OHIP_TOTAL":
                    return rdrR004B.GetNumber("X_REV_OHIP_TOTAL").ToString().PadLeft(7, ' ');

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
