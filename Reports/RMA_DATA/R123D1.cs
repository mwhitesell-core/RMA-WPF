#region "Screen Comments"

// Program: r123d
// Purpose: audit report for CIBC EFT transfer 
// - r123d1 - sorted by BANK/BRANCH
// - r123d2 - sorted by AMOUNT 
// - r123d3 - sorted by DOCTOR NAME 
// REPLACE BY POWERPLAY ANALYSIS
// 2003/11/27 M.C. - suppress printing for doctors do not have pay
// 2003/dec/16   A.A. - alpha doctor nbr
// 2006/jan/24   M.C. - modify w-doctor-name to prdecimal properly even there is no inits defined
// 2010/10/26    Yas - expend the pic w-payeft-amt-n subtotal pic  ^^,^^^,^^^.^^ 

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
    public class R123D1 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R123D1";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrU119_PAYEFT = new Reader();
        private Reader rdrF020_DOCTOR_MSTR = new Reader();
        private Reader rdrF070_DEPT_MSTR = new Reader();
        private Reader rdrF080_BANK_MSTR = new Reader();

        #endregion

        #region " Renaissance Data "

        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                // Set Report Properties...
                ReportName = "r123d1";
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;

                Sort = "BANK_NAME COLLATE SQL_Latin1_General_CP850_BIN ASC, BANK_ADDRESS1 COLLATE SQL_Latin1_General_CP850_BIN ASC,  DOC_NAME COLLATE SQL_Latin1_General_CP850_BIN ASC";

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

        private void Access_U119_PAYEFT()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("W_PAYEFT_AMT_N ");
            strSQL.Append("FROM TEMPORARYDATA.U119_PAYEFT ");
            strSQL.Append(SelectIf_U119_PAYEFT(true));
            strSQL.Append(Choose());

            rdrU119_PAYEFT.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);

            strSQL = null;
        }


        private void Link_F020_DOCTOR_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("DOC_DEPT, ");
            strSQL.Append("DOC_BANK_NBR, ");
            strSQL.Append("DOC_BANK_BRANCH, ");
            strSQL.Append("DOC_NAME, ");
            strSQL.Append("DOC_INIT1, ");
            strSQL.Append("DOC_INIT2, ");
            strSQL.Append("DOC_INIT3, ");
            strSQL.Append("DOC_BANK_ACCT ");
            strSQL.Append("FROM INDEXED.F020_DOCTOR_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_NBR = ").Append(Common.StringToField(rdrU119_PAYEFT.GetString("DOC_NBR")));

            rdrF020_DOCTOR_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

            strSQL = null;
        }

        private void Link_F070_DEPT_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DEPT_NBR ");
            strSQL.Append("FROM [101C].INDEXED.F070_DEPT_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DEPT_NBR = ").Append(rdrU119_PAYEFT.GetNumber("DOC_DEPT"));

            rdrF070_DEPT_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

            strSQL = null;
        }

        private void Link_F080_BANK_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("BANK_CD, ");
            strSQL.Append("BANK_NAME, ");
            strSQL.Append("BANK_ADDRESS1 ");
            strSQL.Append("FROM [101C].INDEXED.F080_BANK_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("BANK_CD = ").Append(Common.StringToField((QDesign.ASCII(rdrF020_DOCTOR_MSTR.GetNumber("DOC_BANK_NBR"), 4) + QDesign.ASCII(rdrF020_DOCTOR_MSTR.GetNumber("DOC_BANK_BRANCH"), 5))));

            rdrF080_BANK_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

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

        private string SelectIf_U119_PAYEFT(bool blnAddWhere)
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

            strSQL.Append(" (W_PAYEFT_AMT_N <>  0)");

            return strSQL.ToString();
        }

        #endregion

        #region " DEFINES "

        private string W_DOCTOR_NAME()
        {

            string strReturnValue = string.Empty;

            try
            {
                if (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_INIT1")) != " " & QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_INIT2")) != " " & QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_INIT3")) != " ")
                {
                    strReturnValue = rdrF020_DOCTOR_MSTR.GetString("DOC_NAME").TrimEnd() + ", " + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT1") + "." + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT2") + "." + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT3") + ".";
                }
                else if (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_INIT1")) != " " & QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_INIT2")) != " ")
                {
                    strReturnValue = rdrF020_DOCTOR_MSTR.GetString("DOC_NAME").TrimEnd() + ", " + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT1") + "." + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT2") + ".";
                }
                else if (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_INIT1")) != " ")
                {
                    strReturnValue = rdrF020_DOCTOR_MSTR.GetString("DOC_NAME").TrimEnd() + ", " + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT1") + ".";
                }
                else
                {
                    strReturnValue = rdrF020_DOCTOR_MSTR.GetString("DOC_NAME").TrimEnd();
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
                AddControl(ReportSection.REPORT, "INDEXED.F080_BANK_MSTR.BANK_NAME", DataTypes.Character, 30);
                AddControl(ReportSection.REPORT, "INDEXED.F080_BANK_MSTR.BANK_ADDRESS1", DataTypes.Character, 30);
                AddControl(ReportSection.REPORT, "INDEXED.F020_DOCTOR_MSTR.DOC_BANK_ACCT", DataTypes.Character, 12);
                AddControl(ReportSection.REPORT, "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "INDEXED.F020_DOCTOR_MSTR.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "W_DOCTOR_NAME", DataTypes.Character, 25);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U119_PAYEFT.W_PAYEFT_AMT_N", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "INDEXED.F020_DOCTOR_MSTR.DOC_NAME", DataTypes.Character, 24);
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
        //# Do not delete, modify or move it.  Updated: 6/29/2017 2:22:06 PM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "INDEXED.F080_BANK_MSTR.BANK_NAME":
                    return Common.StringToField(rdrF080_BANK_MSTR.GetString("BANK_NAME").PadRight(30, ' '));

                case "INDEXED.F080_BANK_MSTR.BANK_ADDRESS1":
                    return Common.StringToField(rdrF080_BANK_MSTR.GetString("BANK_ADDRESS1").PadRight(30, ' '));

                case "INDEXED.F020_DOCTOR_MSTR.DOC_BANK_ACCT":
                    return Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_BANK_ACCT").PadRight(12, ' '));

                case "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT":
                    return rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT").ToString().PadLeft(2, ' ');

                case "INDEXED.F020_DOCTOR_MSTR.DOC_NBR":
                    return Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_NBR").PadRight(3, ' '));

                case "W_DOCTOR_NAME":
                    return Common.StringToField(W_DOCTOR_NAME(), intSize);

                case "TEMPORARYDATA.U119_PAYEFT.W_PAYEFT_AMT_N":
                    return rdrU119_PAYEFT.GetNumber("W_PAYEFT_AMT_N").ToString().PadLeft(16, ' ');

                case "INDEXED.F020_DOCTOR_MSTR.DOC_NAME":
                    return Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_NAME").PadRight(24, ' '));

                default:
                    return string.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                Access_U119_PAYEFT();

                while (rdrU119_PAYEFT.Read())
                {
                    Link_F020_DOCTOR_MSTR();
                    while (rdrF020_DOCTOR_MSTR.Read())
                    {
                        Link_F070_DEPT_MSTR();
                        while (rdrF070_DEPT_MSTR.Read())
                        {
                            Link_F080_BANK_MSTR();
                            while ((rdrF080_BANK_MSTR.Read()))
                            {
                                WriteData();
                            }
                            rdrF080_BANK_MSTR.Close();
                        }
                        rdrF070_DEPT_MSTR.Close();
                    }
                    rdrF020_DOCTOR_MSTR.Close();
                }
                rdrU119_PAYEFT.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrU119_PAYEFT != null))
            {
                rdrU119_PAYEFT.Close();
                rdrU119_PAYEFT = null;
            }

            if ((rdrF020_DOCTOR_MSTR != null))
            {
                rdrF020_DOCTOR_MSTR.Close();
                rdrF020_DOCTOR_MSTR = null;
            }

            if ((rdrF070_DEPT_MSTR != null))
            {
                rdrF070_DEPT_MSTR.Close();
                rdrF070_DEPT_MSTR = null;
            }

            if ((rdrF080_BANK_MSTR != null))
            {
                rdrF080_BANK_MSTR.Close();
                rdrF080_BANK_MSTR = null;
            }
        }

        #endregion

        #endregion
    }
}
