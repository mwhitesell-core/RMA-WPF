//  DOC: PAYROLLLIST.QZS
//  DOC: CREATE PAYROLL LISTING REPORT
//  DOC: RUN FOR: MANAGEMENT/STAFF
//  PROGRAM PURPOSE : PAYROLL LISTING REPORT
//  DATE       WHO       DESCRIPTION
//  92/03/10   Y.B.      ORIGINAL
//  03/dec/17  A.A.      alpha doctor nbr
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
    public class PAYROLLLIST : BaseRDLClass
    {
        protected const string REPORT_NAME = "PAYROLLLIST";
        protected const bool REPORT_HAS_PARAMETERS = true;

        private Reader rdrF020_DOCTOR_MSTR = new Reader();
        private Reader rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR = new Reader();
        private Reader rdrF112_PYCDCEILINGS = new Reader();

        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                //  Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;

                switch (arrParameters[8].ToString())
                {
                    case "1":
                        Sort = "DOC_CLINIC_NBR ASC, DOC_NBR ASC";
                        break;
                    case "2":
                        Sort = "DOC_CLINIC_NBR ASC, DOC_NAME ASC, DOC_INITS ASC";
                        break;
                    case "3":
                        Sort = "DOC_CLINIC_NBR ASC, DOC_DEPT ASC, DOC_NBR ASC";
                        break;
                    case "4":
                        Sort = "DOC_CLINIC_NBR ASC, DOC_DEPT ASC, DOC_NAME ASC, DOC_INITS ASC";
                        break;
                    case "5":
                        Sort = "DOC_DEPT ASC, DOC_FULL_PART_IND ASC, DOC_NBR ASC";
                        break;
                    case "6":
                        Sort = "DOC_DEPT ASC, DOC_FULL_PART_IND ASC, DOC_NAME ASC, DOC_INITS ASC";
                        break;
                    case "7":
                        Sort = "DOC_CLINIC_NBR ASC, DOC_DEPT ASC, DOC_FULL_PART_IND ASC, DOC_NBR ASC";
                        break;
                    case "8":
                        Sort = "DOC_CLINIC_NBR ASC, DOC_DEPT ASC, DOC_FULL_PART_IND ASC";
                        break;
                    default:
                        Sort = "DOC_CLINIC_NBR ASC";
                        break;
                }

                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return ReportData;
        }

        private void Access_F020_DOCTOR_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("DOC_DEPT, ");
            strSQL.Append("DOC_FULL_PART_IND, ");
            strSQL.Append("DOC_NAME, ");
            strSQL.Append("DOC_INIT1, ");
            strSQL.Append("DOC_INIT2, ");
            strSQL.Append("DOC_INIT3, ");
            strSQL.Append("DOC_DATE_FAC_START_YY, ");
            strSQL.Append("DOC_DATE_FAC_START_MM, ");
            strSQL.Append("DOC_DATE_FAC_START_DD, ");
            strSQL.Append("DOC_DATE_FAC_TERM_YY, ");
            strSQL.Append("DOC_DATE_FAC_TERM_MM, ");
            strSQL.Append("DOC_DATE_FAC_TERM_DD ");
            strSQL.Append("FROM INDEXED.F020_DOCTOR_MSTR ");

            strSQL.Append(Choose());

            rdrF020_DOCTOR_MSTR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        private void Link_F020C_DOC_CLINIC_NEXT_BATCH_NBR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_CLINIC_NBR ");
            strSQL.Append("FROM INDEXED.F020C_DOC_CLINIC_NEXT_BATCH_NBR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_NBR = ").Append(Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_NBR")));
            strSQL.Append(" AND SEQ_NO = 1");

            rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        private void Link_F112_PYCDCEILINGS()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_PAY_CODE ");
            strSQL.Append("FROM INDEXED.F112_PYCDCEILINGS ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_NBR = ").Append(Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_NBR")));

            rdrF112_PYCDCEILINGS.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(string.Empty);

            return strChoose.ToString();
        }

        public override bool SelectIf()
        {
            bool blnSelected = false;
            if (((QDesign.NULL(X_CLINIC()) == QDesign.NULL(rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR"))) || QDesign.NULL(X_CLINIC()) == QDesign.NULL(0d)) && 
                (QDesign.NULL(X_DEPT()) == QDesign.NULL(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT")) || QDesign.NULL(X_DEPT()) == QDesign.NULL(0d)) && 
                ((QDesign.NULL(X_CLASS()) == QDesign.NULL(1d) && QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "F") || 
                (QDesign.NULL(X_CLASS()) == QDesign.NULL(2d) && QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "P") || 
                (QDesign.NULL(X_CLASS()) == QDesign.NULL(3d) && QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "C") || 
                (QDesign.NULL(X_CLASS()) == QDesign.NULL(4d) && QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "S") || 
                (QDesign.NULL(X_CLASS()) == QDesign.NULL(0d))))
            {
                blnSelected = true;
            }

            return blnSelected;
        }

        private decimal X_CLINIC()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((ReportFunctions.astrScreenParameters[0].ToString().Trim() != String.Empty))
                {
                    decReturnValue = Decimal.Parse(ReportFunctions.astrScreenParameters[0].ToString());
                }
                else
                {
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_DEPT()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((ReportFunctions.astrScreenParameters[1].ToString().Trim() != String.Empty))
                {
                    decReturnValue = Decimal.Parse(ReportFunctions.astrScreenParameters[1].ToString());
                }
                else
                {
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_CLASS()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((ReportFunctions.astrScreenParameters[2].ToString().Trim() != String.Empty))
                {
                    decReturnValue = Decimal.Parse(ReportFunctions.astrScreenParameters[2].ToString());
                }
                else
                {
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private string DOC_INITS()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = rdrF020_DOCTOR_MSTR.GetString("DOC_INIT1") + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT2") + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT3");
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private decimal DOC_DATE_FAC_START()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = QDesign.NConvert(QDesign.ASCII(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DATE_FAC_START_YY"), 4) + QDesign.ASCII(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DATE_FAC_START_MM"), 2) + QDesign.ASCII(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DATE_FAC_START_DD"), 2));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal DOC_DATE_FAC_TERM()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = QDesign.NConvert(QDesign.ASCII(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DATE_FAC_TERM_YY"), 4) + QDesign.ASCII(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DATE_FAC_TERM_MM"), 2) + QDesign.ASCII(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DATE_FAC_TERM_DD"), 2));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.REPORT, "INDEXED.F020C_DOC_CLINIC_NEXT_BATCH_NBR.DOC_CLINIC_NBR", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "INDEXED.F020_DOCTOR_MSTR.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "INDEXED.F020_DOCTOR_MSTR.DOC_NAME", DataTypes.Character, 20);
                AddControl(ReportSection.REPORT, "DOC_INITS", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "INDEXED.F020_DOCTOR_MSTR.DOC_FULL_PART_IND", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "INDEXED.F112_PYCDCEILINGS.DOC_PAY_CODE", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "DOC_DATE_FAC_START", DataTypes.Numeric, 8);
                AddControl(ReportSection.REPORT, "DOC_DATE_FAC_TERM", DataTypes.Numeric, 8);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-07-20 11:56:54 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "INDEXED.F020C_DOC_CLINIC_NEXT_BATCH_NBR.DOC_CLINIC_NBR":
                    return rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR").ToString();

                case "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT":
                    return rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT").ToString();

                case "INDEXED.F020_DOCTOR_MSTR.DOC_NBR":
                    return Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_NBR"));

                case "INDEXED.F020_DOCTOR_MSTR.DOC_NAME":
                    return Common.StringToField(QDesign.Substring(rdrF020_DOCTOR_MSTR.GetString("DOC_NAME"), 1, 20));

                case "DOC_INITS":
                    return Common.StringToField(DOC_INITS());

                case "INDEXED.F020_DOCTOR_MSTR.DOC_FULL_PART_IND":
                    return Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND"));

                case "INDEXED.F112_PYCDCEILINGS.DOC_PAY_CODE":
                    return Common.StringToField(rdrF112_PYCDCEILINGS.GetString("DOC_PAY_CODE"));

                case "DOC_DATE_FAC_START":
                    return DOC_DATE_FAC_START().ToString();

                case "DOC_DATE_FAC_TERM":
                    return DOC_DATE_FAC_TERM().ToString();

                default:
                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_F020_DOCTOR_MSTR();
                while (rdrF020_DOCTOR_MSTR.Read())
                {
                    Link_F020C_DOC_CLINIC_NEXT_BATCH_NBR();
                    while (rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.Read())
                    {
                        Link_F112_PYCDCEILINGS();
                        while (rdrF112_PYCDCEILINGS.Read())
                        {
                            WriteData();
                        }
                        rdrF112_PYCDCEILINGS.Close();
                    }
                    rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.Close();
                }
                rdrF020_DOCTOR_MSTR.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if (!(rdrF020_DOCTOR_MSTR == null))
            {
                rdrF020_DOCTOR_MSTR.Close();
                rdrF020_DOCTOR_MSTR = null;
            }

            if (!(rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR == null))
            {
                rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.Close();
                rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR = null;
            }

            if (!(rdrF112_PYCDCEILINGS == null))
            {
                rdrF112_PYCDCEILINGS.Close();
                rdrF112_PYCDCEILINGS = null;
            }
        }
    }
}
