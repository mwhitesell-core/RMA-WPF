#region "Screen Comments"

// PURPOSE: QUARTERLY TAX DEDUCTION REPORT
// 94/08/29 M. CHAN  - ORIGINAL
// 99/12/21 B.E.  - y2k
// 00/03/02      Yas  - create a subfile r151 for excell
// 02/08/28      M.C.            - modify to select if doc-tax-rpt-flag = `Y`
// instead of amt-taxable <> 0
// 03/dec/15 A.A.  - alpha doctor nbr

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
    public class R151_SUMMARY : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R151";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
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
                // Create Subfile.
                SubFile = true;
                SubFileName = "R151";
                SubFileType = SubFileType.Keep;
                SubFileAT = "doc_nbr";

                Sort = "DOC_CLINIC_NBR ASC, DOC_NBR ASC";

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

            strSQL.Append("SELECT alldata.* FROM (SELECT compens.COMP_CODE, compens.DOC_NBR, compens.EP_NBR, compens.AMT_NET, comp.DOC_TAX_RPT_FLAG, ");
            strSQL.Append("clinic.DOC_CLINIC_NBR, ");
            strSQL.Append("mstr.DOC_INIT1, mstr.DOC_INIT2, mstr.DOC_INIT3, mstr.DOC_NAME, mstr.DOC_DEPT, mstr.DOC_SIN_123, mstr.DOC_SIN_456, mstr.DOC_SIN_789, ");
            strSQL.Append("iconstmstr.ICONST_CLINIC_NBR_1_2, iconstmstr.ICONST_DATE_PERIOD_END_YY, iconstmstr.ICONST_DATE_PERIOD_END_MM, iconstmstr.ICONST_DATE_PERIOD_END_DD ");
            strSQL.Append("FROM [INDEXED].[F110_COMPENSATION] compens ");
            strSQL.Append("INNER JOIN [101C].[INDEXED].[F190_COMP_CODES] comp ON compens.COMP_CODE = comp.COMP_CODE ");
            strSQL.Append("LEFT OUTER JOIN [INDEXED].[F020_DOCTOR_MSTR] mstr ON compens.DOC_NBR = mstr.DOC_NBR ");
            strSQL.Append("LEFT OUTER JOIN [INDEXED].[F020C_DOC_CLINIC_NEXT_BATCH_NBR] clinic ON clinic.DOC_NBR = mstr.DOC_NBR AND SEQ_NO = 1 ");
            strSQL.Append("LEFT OUTER JOIN [INDEXED].[ICONST_MSTR_REC] iconstmstr ON iconstmstr.ICONST_CLINIC_NBR_1_2 = 22 ");
            strSQL.Append("WHERE (compens.AMT_NET <> 0 AND comp.DOC_TAX_RPT_FLAG = 'Y' ) ");
            strSQL.Append("AND compens.EP_NBR BETWEEN ").Append(QDesign.NConvert(ReportFunctions.astrScreenParameters[0].ToString()));
            strSQL.Append(" AND ").Append(QDesign.NConvert(ReportFunctions.astrScreenParameters[1].ToString())).Append(") AS alldata ");

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

        private string W_DOCTOR_NAME()
        {
            string strReturnValue = string.Empty;

            try
            {
                if (QDesign.NULL(rdrDATA.GetString("DOC_INIT1")) != " " & QDesign.NULL(rdrDATA.GetString("DOC_INIT2")) != " " & QDesign.NULL(rdrDATA.GetString("DOC_INIT3")) != " ")
                {
                    strReturnValue = rdrDATA.GetString("DOC_NAME").TrimEnd() + ", " + rdrDATA.GetString("DOC_INIT1") + "." + rdrDATA.GetString("DOC_INIT2") + "." + rdrDATA.GetString("DOC_INIT3") + ".";
                }
                else if (QDesign.NULL(rdrDATA.GetString("DOC_INIT1")) != " " & QDesign.NULL(rdrDATA.GetString("DOC_INIT2")) != " ")
                {
                    strReturnValue = rdrDATA.GetString("DOC_NAME").TrimEnd() + ", " + rdrDATA.GetString("DOC_INIT1") + "." + rdrDATA.GetString("DOC_INIT2") + ".";
                }
                else if (QDesign.NULL(rdrDATA.GetString("DOC_INIT1")) != " ")
                {
                    strReturnValue = rdrDATA.GetString("DOC_NAME").TrimEnd() + ", " + rdrDATA.GetString("DOC_INIT1") + ".";
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_COMMA()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = ",";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private decimal DOC_SIN_NBR()
        {
            decimal decReturnValue = 0;

            try
            {
                decReturnValue = QDesign.NConvert(QDesign.ASCII(rdrDATA.GetNumber("DOC_SIN_123")).PadLeft(3, '0') + QDesign.ASCII(rdrDATA.GetNumber("DOC_SIN_456")).PadLeft(3, '0') + QDesign.ASCII(rdrDATA.GetNumber("DOC_SIN_789")).PadLeft(3, '0'));
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
            return decReturnValue;
        }

        private string DOC_INITS()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = (rdrDATA.GetString("DOC_INIT1") + rdrDATA.GetString("DOC_INIT2") + rdrDATA.GetString("DOC_INIT3"));
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
            return strReturnValue;
        }

        private decimal SUB_AMT_NET;
        private string LAST_DOC_NBR= "";
        private string LAST_CLINIC_NBR;
        private string LAST_DOC_DEPT;
        private string LAST_DOC_NAME;
        private string LAST_DOC_INITS;
        private string LAST_DOC_SIN;
        #endregion

        #region " CONTROLS "

        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F020C_DOC_CLINIC_NEXT_BATCH_NBR.DOC_CLINIC_NBR", DataTypes.Numeric, 2);
                AddControl(ReportSection.SUMMARY, "X_COMMA", DataTypes.Character, 1);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT", DataTypes.Numeric, 2);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F110_COMPENSATION.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.SUMMARY, "INDEXED.F020_DOCTOR_MSTR.DOC_NAME", DataTypes.Character, 24);
                AddControl(ReportSection.SUMMARY, "DOC_INITS", DataTypes.Character, 3);
                AddControl(ReportSection.FOOTING_AT, "DOC_SIN_NBR", DataTypes.Numeric, 9);
                AddControl(ReportSection.FOOTING_AT, "INDEXED.F110_COMPENSATION.AMT_NET", DataTypes.Numeric, 9);
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
        //# Do not delete, modify or move it.  Updated: 6/29/2017 2:26:31 PM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "INDEXED.F020C_DOC_CLINIC_NEXT_BATCH_NBR.DOC_CLINIC_NBR":
                    return LAST_CLINIC_NBR.ToString();

                case "X_COMMA":
                    return Common.StringToField(X_COMMA(), intSize);

                case "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT":
                    return LAST_DOC_DEPT;

                case "INDEXED.F110_COMPENSATION.DOC_NBR":
                    return Common.StringToField(LAST_DOC_NBR);

                case "INDEXED.F020_DOCTOR_MSTR.DOC_NAME":
                    return Common.StringToField(LAST_DOC_NAME);

                case "DOC_INITS":
                    return Common.StringToField(LAST_DOC_INITS, intSize);

                case "DOC_SIN_NBR":
                    return LAST_DOC_SIN;

                case "INDEXED.F110_COMPENSATION.AMT_NET":
                    return SUB_AMT_NET.ToString();

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
                    if(LAST_DOC_NBR == "")
                    {
                        LAST_DOC_NBR = rdrDATA.GetString("DOC_NBR");
                        SUB_AMT_NET = rdrDATA.GetNumber("AMT_NET");
                        LAST_CLINIC_NBR = rdrDATA.GetNumber("DOC_CLINIC_NBR").ToString();
                        LAST_DOC_DEPT = rdrDATA.GetNumber("DOC_DEPT").ToString();
                        LAST_DOC_NAME = rdrDATA.GetString("DOC_NAME");
                        LAST_DOC_INITS = DOC_INITS();
                        LAST_DOC_SIN = DOC_SIN_NBR().ToString();

                    }
                    else if (LAST_DOC_NBR != rdrDATA.GetString("DOC_NBR"))
                    {
                        WriteData();
                        LAST_DOC_NBR = rdrDATA.GetString("DOC_NBR");
                        SUB_AMT_NET = rdrDATA.GetNumber("AMT_NET");
                        LAST_CLINIC_NBR = rdrDATA.GetNumber("DOC_CLINIC_NBR").ToString();
                        LAST_DOC_DEPT = rdrDATA.GetNumber("DOC_DEPT").ToString();
                        LAST_DOC_NAME = rdrDATA.GetString("DOC_NAME");
                        LAST_DOC_INITS = DOC_INITS();
                        LAST_DOC_SIN = DOC_SIN_NBR().ToString();
                    }
                    else
                    {
                        SUB_AMT_NET += rdrDATA.GetNumber("AMT_NET");
                    }
                }
                WriteData();
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
