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
    public class U100_B_SRC_PASS5 : BaseRDLClass
    {
        #region "Screen Comments"

        #endregion

        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "U100_B__PASS5";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrU100_B_3A = new Reader();
        private Reader rdrF020_DOCTOR_MSTR = new Reader();
        private Reader rdrF020_DOCTOR_EXTRA = new Reader();
        private Reader rdrU100_B_3B = new Reader();

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
                SubFileName = "U100_B_3B";
                SubFileAppend = true;
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

        private void Access_U100_B_3A()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("PREVIOUS_FISCAL_END_YYMMDD, ");
            strSQL.Append("PAYROLL_FLAG, ");
            strSQL.Append("DOCTOR_COUNT ");
            strSQL.Append("FROM TEMPORARYDATA.U100_B_3A ");

            strSQL.Append(Choose());

            rdrU100_B_3A.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);

            strSQL = null;
        }

        private void Link_F020_DOCTOR_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_OHIP_NBR, ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("DOC_DATE_FAC_TERM_YY, ");
            strSQL.Append("DOC_DATE_FAC_TERM_MM, ");
            strSQL.Append("DOC_DATE_FAC_TERM_DD, ");
            strSQL.Append("DOC_DEPT, ");
            strSQL.Append("DOC_AFP_PAYM_GROUP, ");
            strSQL.Append("DOC_DATE_FAC_START_YY, ");
            strSQL.Append("DOC_DATE_FAC_START_MM, ");
            strSQL.Append("DOC_DATE_FAC_START_DD, ");
            strSQL.Append("DOC_NAME, ");
            strSQL.Append("DOC_SUB_SPECIALTY ");
            strSQL.Append("FROM INDEXED.F020_DOCTOR_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_OHIP_NBR = ").Append(rdrU100_B_3A.GetNumber("DOC_OHIP_NBR"));

            rdrF020_DOCTOR_MSTR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

            strSQL = null;
        }

        private void Link_F020_DOCTOR_EXTRA()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("DOC_FLAG_PRIMARY ");
            strSQL.Append("FROM INDEXED.F020_DOCTOR_EXTRA ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_NBR = ").Append(Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_NBR")));

            rdrF020_DOCTOR_EXTRA.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

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

        public override bool SelectIf()
        {
            bool blnSelected = false;

            if (
                (
                    QDesign.NULL(DOC_DATE_FAC_TERM()) == 0
                    | QDesign.NULL(DOC_DATE_FAC_TERM()) > QDesign.NULL(rdrU100_B_3A.GetNumber("PREVIOUS_FISCAL_END_YYMMDD"))
                )

                & ((((QDesign.NULL(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT")) == 4)
                                | (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT")) == 42)
                                | ((QDesign.NULL(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT")) == 14
                                | QDesign.NULL(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT")) == 15
                    )

                     & QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_AFP_PAYM_GROUP")) == "H111"
                    )
                )

                    & QDesign.NULL(rdrU100_B_3A.GetString("PAYROLL_FLAG")) == "A"
                )

                | ((QDesign.NULL(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT")) == 31
                    & QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_AFP_PAYM_GROUP")) == "H132"
                )
                    & QDesign.NULL(rdrU100_B_3A.GetString("PAYROLL_FLAG")) == "C"
                    )
                    )
                )

            {
                blnSelected = true;
            }

            return blnSelected;
        }

        #endregion

        #region " DEFINES "

        private decimal DOC_DATE_FAC_START()
        {
            decimal decReturnValue = 0;

            try
            {
                decReturnValue = QDesign.NConvert(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DATE_FAC_START_YY").ToString() + rdrF020_DOCTOR_MSTR.GetNumber("DOC_DATE_FAC_START_MM").ToString().PadLeft(2, '0') + rdrF020_DOCTOR_MSTR.GetNumber("DOC_DATE_FAC_START_DD").ToString().PadLeft(2, '0'));
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal DOC_DATE_FAC_TERM()
        {

            decimal decReturnValue = 0;

            try
            {
                decReturnValue = QDesign.NConvert(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DATE_FAC_TERM_YY").ToString() + rdrF020_DOCTOR_MSTR.GetNumber("DOC_DATE_FAC_TERM_MM").ToString().PadLeft(2, '0') + rdrF020_DOCTOR_MSTR.GetNumber("DOC_DATE_FAC_TERM_DD").ToString().PadLeft(2, '0'));
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        #endregion

        #region " CONTROLS "

        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.SUMMARY, "INDEXED.F020_DOCTOR_MSTR.DOC_OHIP_NBR", DataTypes.Numeric, 6);
                AddControl(ReportSection.SUMMARY, "INDEXED.F020_DOCTOR_MSTR.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.SUMMARY, "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT", DataTypes.Numeric, 2);
                AddControl(ReportSection.SUMMARY, "INDEXED.F020_DOCTOR_MSTR.DOC_AFP_PAYM_GROUP", DataTypes.Character, 4);
                AddControl(ReportSection.SUMMARY, "INDEXED.F020_DOCTOR_EXTRA.DOC_FLAG_PRIMARY", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "DOC_DATE_FAC_START", DataTypes.Numeric, 8);
                AddControl(ReportSection.SUMMARY, "DOC_DATE_FAC_TERM", DataTypes.Numeric, 8);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U100_B_3A.PAYROLL_FLAG", DataTypes.Character, 1);
                AddControl(ReportSection.SUMMARY, "INDEXED.F020_DOCTOR_MSTR.DOC_NAME", DataTypes.Character, 24);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U100_B_3A.PREVIOUS_FISCAL_END_YYMMDD", DataTypes.Numeric, 8);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.U100_B_3A.DOCTOR_COUNT", DataTypes.Numeric, 6);
                AddControl(ReportSection.SUMMARY, "INDEXED.F020_DOCTOR_MSTR.DOC_SUB_SPECIALTY", DataTypes.Character, 15);
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
        //# Do not delete, modify or move it.  Updated: 6/7/2017 11:45:00 AM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "INDEXED.F020_DOCTOR_MSTR.DOC_OHIP_NBR":
                    return rdrF020_DOCTOR_MSTR.GetNumber("DOC_OHIP_NBR").ToString().PadLeft(6, ' ');

                case "INDEXED.F020_DOCTOR_MSTR.DOC_NBR":
                    return Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_NBR").PadRight(3, ' '));

                case "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT":
                    return rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT").ToString().PadLeft(2, ' ');

                case "INDEXED.F020_DOCTOR_MSTR.DOC_AFP_PAYM_GROUP":
                    return Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_AFP_PAYM_GROUP").PadRight(4, ' '));

                case "INDEXED.F020_DOCTOR_EXTRA.DOC_FLAG_PRIMARY":
                    return Common.StringToField(rdrF020_DOCTOR_EXTRA.GetString("DOC_FLAG_PRIMARY").PadRight(1, ' '));

                case "DOC_DATE_FAC_START":
                    return DOC_DATE_FAC_START().ToString().PadLeft(8, ' ');

                case "DOC_DATE_FAC_TERM":
                    return DOC_DATE_FAC_TERM().ToString().PadLeft(8, ' ');

                case "TEMPORARYDATA.U100_B_3A.PAYROLL_FLAG":
                    return Common.StringToField(rdrU100_B_3A.GetString("PAYROLL_FLAG").PadRight(1, ' '));

                case "INDEXED.F020_DOCTOR_MSTR.DOC_NAME":
                    return Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_NAME").PadRight(24, ' '));

                case "TEMPORARYDATA.U100_B_3A.PREVIOUS_FISCAL_END_YYMMDD":
                    return rdrU100_B_3A.GetNumber("PREVIOUS_FISCAL_END_YYMMDD").ToString().PadLeft(8, ' ');

                case "TEMPORARYDATA.U100_B_3A.DOCTOR_COUNT":
                    return rdrU100_B_3A.GetNumber("DOCTOR_COUNT").ToString().PadLeft(6, ' ');

                case "INDEXED.F020_DOCTOR_MSTR.DOC_SUB_SPECIALTY":
                    return Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_SUB_SPECIALTY").PadRight(15, ' '));

                default:
                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_U100_B_3A();

                while (rdrU100_B_3A.Read())
                {
                    Link_F020_DOCTOR_MSTR();
                    while (rdrF020_DOCTOR_MSTR.Read())
                    {
                        Link_F020_DOCTOR_EXTRA();
                        while (rdrF020_DOCTOR_EXTRA.Read())
                        {
                            WriteData();
                        }
                        rdrF020_DOCTOR_EXTRA.Close();
                    }
                    rdrF020_DOCTOR_MSTR.Close();
                }
                rdrU100_B_3A.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrU100_B_3A != null))
            {
                rdrU100_B_3A.Close();
                rdrU100_B_3A = null;
            }

            if ((rdrF020_DOCTOR_MSTR != null))
            {
                rdrF020_DOCTOR_MSTR.Close();
                rdrF020_DOCTOR_MSTR = null;
            }

            if ((rdrF020_DOCTOR_EXTRA != null))
            {
                rdrF020_DOCTOR_EXTRA.Close();
                rdrF020_DOCTOR_EXTRA = null;
            }


            if ((rdrU100_B_3B != null))
            {
                rdrU100_B_3B.Close();
                rdrU100_B_3B = null;
            }
        }

        #endregion

        #endregion
    }
}
