
#region "Screen Comments"

// PROGRAM:  R121A.QZS
// REPORT MTD AND YTD FIGURES REPORT  AT CLASS
// DATE      WHO       MODIFICATION
// 94/08/17  B.M.L.    ORIGINAL
// 94/11/14  YASEMIN   ADD CLASS PLASTIC SURGERY
// 95/01/09  YASEMIN   CHANGE SORT ORDER TO MATCH R119A.QZS
// 98/01/29  J. CHAU   COMMENT OUT SET NOCLOSE
// 03/dec/16 A.A.      alpha doctor nbr
// 08/may/27 M.C.      add the select of rec-type = `A` or `C`
// 08/oct/27 brad1     only rec-type  A  is `visible` to the system -  C  for mary online review only - change select to  A  only
// jc set noclose

#endregion

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
    public class R121A : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R121A";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        //private Reader rdrF020_DOCTOR_MSTR = new Reader();
        //private Reader rdrF119_DOCTOR_YTD = new Reader();
        //private Reader rdrF190_COMP_CODES = new Reader();
        //private Reader rdrF070_DEPT_MSTR = new Reader();
        //private Reader rdrCONSTANTS_MSTR_REC_6 = new Reader();
        private Reader rdrDATA = new Reader();

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

                Sort = "X_KEY2 ASC, DOC_DEPT ASC, X_KEY1 ASC";

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

        private void Access_Data()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT * FROM [INDEXED].[F020_DOCTOR_MSTR] mstr ");
            strSQL.Append("INNER JOIN [INDEXED].[F119_DOCTOR_YTD] ytd ON ytd.DOC_NBR = mstr.DOC_NBR ");
            strSQL.Append("LEFT OUTER JOIN [101C].[INDEXED].[F190_COMP_CODES] comp ON comp.COMP_CODE = ytd.COMP_CODE ");
            strSQL.Append("LEFT OUTER JOIN [101C].[INDEXED].[F070_DEPT_MSTR] dept ON dept.DEPT_NBR = mstr.DOC_DEPT ");
            strSQL.Append("LEFT OUTER JOIN [INDEXED].[CONSTANTS_MSTR_REC_6] constmstr ON constmstr.CONST_REC_NBR = 6 ");
            strSQL.Append("WHERE ytd.REC_TYPE = 'A' ");

            rdrDATA.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

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

        private string X_KEY1()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = rdrDATA.GetString("COMP_CODE_GROUP") + QDesign.ASCII(rdrDATA.GetNumber("REPORTING_SEQ"), 2) + rdrDATA.GetString("COMP_CODE");
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_KEY2()
        {
            string strReturnValue = string.Empty;

            try
            {
                if (QDesign.NULL(rdrDATA.GetNumber("DOC_DEPT")) == 14)
                {
                    strReturnValue = "D";
                }
                else if (QDesign.NULL(rdrDATA.GetString("DOC_FULL_PART_IND")) == "F")
                {
                    strReturnValue = "A";
                }
                else if (QDesign.NULL(rdrDATA.GetString("DOC_FULL_PART_IND")) == "P")
                {
                    strReturnValue = "B";
                }
                else if (QDesign.NULL(rdrDATA.GetString("DOC_FULL_PART_IND")) == "C")
                {
                    strReturnValue = "C";
                }
                else if (QDesign.NULL(rdrDATA.GetString("DOC_FULL_PART_IND")) == "S")
                {
                    strReturnValue = "S";
                }
                else
                {
                    strReturnValue = "E";
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_CLASS()
        {
            string strReturnValue = string.Empty;

            try
            {
                if (QDesign.NULL(X_KEY2()) == "A")
                {
                    strReturnValue = "FULL TIME";
                }
                else if (QDesign.NULL(X_KEY2()) == "B")
                {
                    strReturnValue = "PART TIME";
                }
                else if (QDesign.NULL(X_KEY2()) == "C")
                {
                    strReturnValue = "CLINICAL SCHOLARS";
                }
                else if (QDesign.NULL(X_KEY2()) == "S")
                {
                    strReturnValue = "PLASTIC SURGERY";
                }
                else if (QDesign.NULL(X_KEY2()) == "D")
                {
                    strReturnValue = "DEPT-14        ";
                }
                else if (QDesign.NULL(X_KEY2()) == "E")
                {
                    strReturnValue = "UNKNOWN";
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
                AddControl(ReportSection.PAGE_HEADING, "INDEXED.CONSTANTS_MSTR_REC_6.CURRENT_EP_NBR", DataTypes.Numeric, 6);
                AddControl(ReportSection.HEADING_AT, "X_CLASS", DataTypes.Character, 18);
                AddControl(ReportSection.HEADING_AT, "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT", DataTypes.Numeric, 2);
                AddControl(ReportSection.HEADING_AT, "INDEXED.F070_DEPT_MSTR.DEPT_NAME", DataTypes.Character, 30);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F190_COMP_CODES.COMP_TYPE", DataTypes.Character, 1);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F119_DOCTOR_YTD.COMP_CODE", DataTypes.Character, 6);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F190_COMP_CODES.DESC_SHORT", DataTypes.Character, 15);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F119_DOCTOR_YTD.AMT_MTD", DataTypes.Numeric, 9);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F119_DOCTOR_YTD.AMT_YTD", DataTypes.Numeric, 9);
                AddControl(ReportSection.REPORT, "X_KEY2", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "X_KEY1", DataTypes.Character, 9);
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
        //# Do not delete, modify or move it.  Updated: 6/29/2017 2:21:09 PM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "INDEXED.CONSTANTS_MSTR_REC_6.CURRENT_EP_NBR":
                    return rdrDATA.GetNumber("CURRENT_EP_NBR").ToString().PadLeft(6, ' ');

                case "X_CLASS":
                    return Common.StringToField(X_CLASS(), intSize);

                case "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT":
                    return rdrDATA.GetNumber("DOC_DEPT").ToString().PadLeft(2, ' ');

                case "INDEXED.F070_DEPT_MSTR.DEPT_NAME":
                    return Common.StringToField(rdrDATA.GetString("DEPT_NAME").PadRight(30, ' '));

                case "INDEXED.F190_COMP_CODES.COMP_TYPE":
                    return Common.StringToField(rdrDATA.GetString("COMP_TYPE").PadRight(1, ' '));

                case "INDEXED.F119_DOCTOR_YTD.COMP_CODE":
                    return Common.StringToField(rdrDATA.GetString("COMP_CODE").PadRight(6, ' '));

                case "INDEXED.F190_COMP_CODES.DESC_SHORT":
                    return Common.StringToField(rdrDATA.GetString("DESC_SHORT").PadRight(15, ' '));

                case "INDEXED.F119_DOCTOR_YTD.AMT_MTD":
                    return rdrDATA.GetNumber("AMT_MTD").ToString().PadLeft(10, ' ');

                case "INDEXED.F119_DOCTOR_YTD.AMT_YTD":
                    return rdrDATA.GetNumber("AMT_YTD").ToString().PadLeft(10, ' ');

                case "X_KEY2":
                    return Common.StringToField(X_KEY2(), intSize);

                case "X_KEY1":
                    return Common.StringToField(X_KEY1(), intSize);

                default:
                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_Data();

                while (rdrDATA.Read())
                {
                    WriteData();
                }
                rdrDATA.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrDATA != null))
            {
                rdrDATA.Close();
                rdrDATA = null;
            }
        }
        
        #endregion

        #endregion
    }
}
