#region "Screen Comments"

// #> PROGRAM-ID.   utl0201.qzs
// ((C)) Dyad Infosys LTD 
// PROGRAM PURPOSE :
// - generate 2 reports     requested by Brad
// the purpose of the 1st report is to list the PAYMENTS for doctors by dept, sorted by highest payment.
// the purpose of the 2nd report is to list the PAYMENTS for doctors by dept, sorted by highest different in payment from LAST MONTH.
// -----------------------------------------------------------------------------------
// report1 will access the utl0201_f119_all.ps
// and link to comp code table and only select transactions if comp-code-type field is `P`ayment
// it will only select those from the .ps with EP_nbr matching current EP_NBR
// sort on dept, docnbr, amt DESC
// rep dept page heading, and on line doc nbr, doc name, mtd  ytd
// -------------------------------------------------------------------------------------

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
    public class MP_UTL0201_1 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "UTL0201_1";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrUTL0201_F119 = new Reader();
        private Reader rdrF020_DOCTOR_MSTR = new Reader();
        private Reader rdrF190_COMP_CODES = new Reader();
        private Reader rdrUTL0201 = new Reader();

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
                SubFileName = "UTL0201";
                SubFileType = SubFileType.Keep;
                SubFileAT = "TODO: Enter sortbreak name";

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

        private void Access_UTL0201_F119()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("X_PED, ");
            strSQL.Append("ENVIRONMENT, ");
            strSQL.Append("AMT_MTD, ");
            strSQL.Append("AMT_YTD, COMP_CODE ");
            strSQL.Append("FROM TEMPORARYDATA.UTL0201_F119 ");

            strSQL.Append(Choose());

            rdrUTL0201_F119.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);

            strSQL = null;
        }

        private void Link_F020_DOCTOR_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("DOC_DEPT, ");
            strSQL.Append("DOC_NAME ");
            strSQL.Append("FROM INDEXED.F020_DOCTOR_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_NBR = ").Append(Common.StringToField(rdrUTL0201_F119.GetString("DOC_NBR")));

            rdrF020_DOCTOR_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

            strSQL = null;
        }

        private void Link_F190_COMP_CODES()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("COMP_CODE, ");
            strSQL.Append("COMP_TYPE ");
            strSQL.Append("FROM [101C].INDEXED.F190_COMP_CODES ");
            strSQL.Append("WHERE ");
            strSQL.Append("COMP_CODE = ").Append(Common.StringToField(rdrUTL0201_F119.GetString("COMP_CODE")));

            rdrF190_COMP_CODES.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

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

            if (QDesign.NULL(rdrF190_COMP_CODES.GetString("COMP_TYPE")) == QDesign.NULL("P") & QDesign.NULL(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT")) == QDesign.NULL(42d))
            {
                blnSelected = true;
            }

          
            return blnSelected;
        }

        #endregion

        #region " DEFINES "

        private string PREV_EP_NBR()
        {
            string strReturnValue = string.Empty;

            try
            {
                if (QDesign.NULL(QDesign.Substring(rdrUTL0201_F119.GetString("X_PED"), 5, 2)).CompareTo(QDesign.NULL("02")) > 0)
                {
                    strReturnValue = QDesign.ASCII(QDesign.NConvert(rdrUTL0201_F119.GetString("X_PED")) - 2);
                }
                else if (QDesign.NULL(QDesign.Substring(rdrUTL0201_F119.GetString("X_PED"), 5, 2)) == QDesign.NULL("02") & QDesign.NULL(rdrUTL0201_F119.GetString("ENVIRONMENT")) == QDesign.NULL("101C"))
                {
                    strReturnValue = QDesign.ASCII(QDesign.NConvert(QDesign.Substring(rdrUTL0201_F119.GetString("X_PED"), 1, 4)) - 1) + "13";
                }
                else if (QDesign.NULL(QDesign.Substring(rdrUTL0201_F119.GetString("X_PED"), 5, 2)) == QDesign.NULL("02") & QDesign.NULL(rdrUTL0201_F119.GetString("ENVIRONMENT")) != QDesign.NULL("101C"))
                {
                    strReturnValue = QDesign.ASCII(QDesign.NConvert(QDesign.Substring(rdrUTL0201_F119.GetString("X_PED"), 1, 4)) - 1) + "12";
                }
                else if (QDesign.NULL(QDesign.Substring(rdrUTL0201_F119.GetString("X_PED"), 5, 2)) == QDesign.NULL("01") & QDesign.NULL(rdrUTL0201_F119.GetString("ENVIRONMENT")) == QDesign.NULL("101C"))
                {
                    strReturnValue = QDesign.ASCII(QDesign.NConvert(QDesign.Substring(rdrUTL0201_F119.GetString("X_PED"), 1, 4)) - 1) + "13";
                }
                else if (QDesign.NULL(QDesign.Substring(rdrUTL0201_F119.GetString("X_PED"), 5, 2)) == QDesign.NULL("01") & QDesign.NULL(rdrUTL0201_F119.GetString("ENVIRONMENT")) != QDesign.NULL("101C"))
                {
                    strReturnValue = QDesign.ASCII(QDesign.NConvert(QDesign.Substring(rdrUTL0201_F119.GetString("X_PED"), 1, 4)) - 1) + "12";
                }
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
                AddControl(ReportSection.SUMMARY, "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT", DataTypes.Numeric, 2);
                AddControl(ReportSection.SUMMARY, "INDEXED.F020_DOCTOR_MSTR.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.SUMMARY, "INDEXED.F020_DOCTOR_MSTR.DOC_NAME", DataTypes.Character, 24);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.UTL0201_F119.X_PED", DataTypes.Character, 6);
                AddControl(ReportSection.SUMMARY, "PREV_EP_NBR", DataTypes.Character, 6);
                AddControl(ReportSection.SUMMARY, "INDEXED.F190_COMP_CODES.COMP_CODE", DataTypes.Character, 6);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.UTL0201_F119.AMT_MTD", DataTypes.Numeric, 9);
                AddControl(ReportSection.SUMMARY, "TEMPORARYDATA.UTL0201_F119.AMT_YTD", DataTypes.Numeric, 8);
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
        //# Do not delete, modify or move it.  Updated: 10/27/2017 12:59:18 PM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT":
                    return rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT").ToString().PadLeft(2, ' ');

                case "INDEXED.F020_DOCTOR_MSTR.DOC_NBR":
                    return Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_NBR").PadRight(3, ' '));

                case "INDEXED.F020_DOCTOR_MSTR.DOC_NAME":
                    return Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_NAME").PadRight(24, ' '));

                case "TEMPORARYDATA.UTL0201_F119.X_PED":
                    return Common.StringToField(rdrUTL0201_F119.GetString("X_PED").PadRight(6, ' '));

                case "PREV_EP_NBR":
                    return Common.StringToField(PREV_EP_NBR().PadRight(6, ' '));

                case "INDEXED.F190_COMP_CODES.COMP_CODE":
                    return Common.StringToField(rdrF190_COMP_CODES.GetString("COMP_CODE").PadRight(6, ' '));

                case "TEMPORARYDATA.UTL0201_F119.AMT_MTD":
                    return rdrUTL0201_F119.GetNumber("AMT_MTD").ToString().PadLeft(9, ' ');

                case "TEMPORARYDATA.UTL0201_F119.AMT_YTD":
                    return rdrUTL0201_F119.GetNumber("AMT_YTD").ToString().PadLeft(8, ' ');

                default:

                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_UTL0201_F119();

                while (rdrUTL0201_F119.Read())
                {
                    Link_F020_DOCTOR_MSTR();
                    while (rdrF020_DOCTOR_MSTR.Read())
                    {
                        Link_F190_COMP_CODES();
                        while ((rdrF190_COMP_CODES.Read()))
                        {
                            WriteData();
                        }
                        rdrF190_COMP_CODES.Close();
                    }
                    rdrF020_DOCTOR_MSTR.Close();
                }
                rdrUTL0201_F119.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrUTL0201_F119 != null))
            {
                rdrUTL0201_F119.Close();
                rdrUTL0201_F119 = null;
            }
            if ((rdrF020_DOCTOR_MSTR != null))
            {
                rdrF020_DOCTOR_MSTR.Close();
                rdrF020_DOCTOR_MSTR = null;
            }
            if ((rdrF190_COMP_CODES != null))
            {
                rdrF190_COMP_CODES.Close();
                rdrF190_COMP_CODES = null;
            }
        }


        #endregion

        #endregion
    }
}
