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
    public class ADDRLABELS : BaseRDLClass
    {
        protected const string REPORT_NAME = "ADDRLABELS";
        protected const bool REPORT_HAS_PARAMETERS = true;

        private Reader rdrF020_DOCTOR_MSTR = new Reader();
        private Reader rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR = new Reader();
        private Reader rdrF020_DOCTOR_EXTRA = new Reader();
        private Reader rdrF027_DOC = new Reader();
        private Reader rdrF028_DOC_HOME = new Reader();
        private Reader rdrF028_DOC_OFFICE = new Reader();

        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                //  Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;

                switch (arrParameters[9].ToString())
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
                        Sort = "DOC_CLINIC_NBR ASC, DOC_DEPT ASC, DOC_FULL_PART_IND ASC, DOC_NAME ASC, DOC_INITS ASC";
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
            StringBuilder strSQL = new StringBuilder(String.Empty);
            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("DOC_INIT1, ");
            strSQL.Append("DOC_INIT2, ");
            strSQL.Append("DOC_INIT3, ");
            strSQL.Append("DOC_NAME, ");
            strSQL.Append("DOC_DEPT, ");
            strSQL.Append("DOC_DATE_FAC_TERM_YY, ");
            strSQL.Append("DOC_DATE_FAC_TERM_MM, ");
            strSQL.Append("DOC_DATE_FAC_TERM_DD, ");
            strSQL.Append("DOC_FULL_PART_IND ");
            strSQL.Append("FROM INDEXED.F020_DOCTOR_MSTR ");
            strSQL.Append(Choose());
            rdrF020_DOCTOR_MSTR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        private void Link_F020C_DOC_CLINIC_NEXT_BATCH_NBR()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            strSQL.Append("SELECT TOP 1");
            strSQL.Append("DOC_CLINIC_NBR, ");
            strSQL.Append("SEQ_NO ");
            strSQL.Append("FROM INDEXED.F020C_DOC_CLINIC_NEXT_BATCH_NBR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_NBR = ").Append(Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_NBR")));
            strSQL.Append("AND DOC_CLINIC_NBR <> 0");
            strSQL.Append(" AND (CASE WHEN SEQ_NO = 1 AND DOC_CLINIC_NBR = 22 THEN DOC_CLINIC_NBR END = ").Append(QDesign.NULL(X_CLINIC())).Append(" OR");
            strSQL.Append(" CASE WHEN SEQ_NO = 1 AND (DOC_CLINIC_NBR >= 60 AND DOC_CLINIC_NBR <= 66) THEN DOC_CLINIC_NBR ELSE");
            strSQL.Append(" CASE WHEN SEQ_NO = 2 AND (DOC_CLINIC_NBR >= 60 AND DOC_CLINIC_NBR <= 66) THEN DOC_CLINIC_NBR ELSE");
            strSQL.Append(" CASE WHEN SEQ_NO = 3 AND (DOC_CLINIC_NBR >= 60 AND DOC_CLINIC_NBR <= 66) THEN DOC_CLINIC_NBR ELSE");
            strSQL.Append(" CASE WHEN SEQ_NO = 4 AND (DOC_CLINIC_NBR >= 60 AND DOC_CLINIC_NBR <= 66) THEN DOC_CLINIC_NBR ELSE");
            strSQL.Append(" CASE WHEN SEQ_NO = 5 AND (DOC_CLINIC_NBR >= 60 AND DOC_CLINIC_NBR <= 66) THEN DOC_CLINIC_NBR ELSE");
            strSQL.Append(" CASE WHEN SEQ_NO = 6 AND (DOC_CLINIC_NBR >= 60 AND DOC_CLINIC_NBR <= 66) THEN DOC_CLINIC_NBR END END END END END END = ").Append(QDesign.NULL(X_CLINIC())).Append(" OR");
            strSQL.Append(" CASE WHEN SEQ_NO = 1 AND DOC_CLINIC_NBR = 80 THEN DOC_CLINIC_NBR ELSE");
            strSQL.Append(" CASE WHEN SEQ_NO = 2 AND DOC_CLINIC_NBR = 80 THEN DOC_CLINIC_NBR ELSE");
            strSQL.Append(" CASE WHEN SEQ_NO = 3 AND DOC_CLINIC_NBR = 80 THEN DOC_CLINIC_NBR ELSE");
            strSQL.Append(" CASE WHEN SEQ_NO = 4 AND DOC_CLINIC_NBR = 80 THEN DOC_CLINIC_NBR ELSE");
            strSQL.Append(" CASE WHEN SEQ_NO = 5 AND DOC_CLINIC_NBR = 80 THEN DOC_CLINIC_NBR ELSE");
            strSQL.Append(" CASE WHEN SEQ_NO = 6 AND DOC_CLINIC_NBR = 80 THEN DOC_CLINIC_NBR END END END END END END = ").Append(QDesign.NULL(X_CLINIC())).Append(" OR");
            strSQL.Append(" CASE WHEN SEQ_NO = 1 AND DOC_CLINIC_NBR = 81 THEN DOC_CLINIC_NBR ELSE");
            strSQL.Append(" CASE WHEN SEQ_NO = 2 AND DOC_CLINIC_NBR = 81 THEN DOC_CLINIC_NBR ELSE");
            strSQL.Append(" CASE WHEN SEQ_NO = 3 AND DOC_CLINIC_NBR = 81 THEN DOC_CLINIC_NBR ELSE");
            strSQL.Append(" CASE WHEN SEQ_NO = 4 AND DOC_CLINIC_NBR = 81 THEN DOC_CLINIC_NBR ELSE");
            strSQL.Append(" CASE WHEN SEQ_NO = 5 AND DOC_CLINIC_NBR = 81 THEN DOC_CLINIC_NBR ELSE");
            strSQL.Append(" CASE WHEN SEQ_NO = 6 AND DOC_CLINIC_NBR = 81 THEN DOC_CLINIC_NBR END END END END END END = ").Append(QDesign.NULL(X_CLINIC())).Append(" OR");
            strSQL.Append(" CASE WHEN SEQ_NO = 1 AND DOC_CLINIC_NBR = 82 THEN DOC_CLINIC_NBR ELSE");
            strSQL.Append(" CASE WHEN SEQ_NO = 2 AND DOC_CLINIC_NBR = 82 THEN DOC_CLINIC_NBR ELSE");
            strSQL.Append(" CASE WHEN SEQ_NO = 3 AND DOC_CLINIC_NBR = 82 THEN DOC_CLINIC_NBR ELSE");
            strSQL.Append(" CASE WHEN SEQ_NO = 4 AND DOC_CLINIC_NBR = 82 THEN DOC_CLINIC_NBR ELSE");
            strSQL.Append(" CASE WHEN SEQ_NO = 5 AND DOC_CLINIC_NBR = 82 THEN DOC_CLINIC_NBR ELSE");
            strSQL.Append(" CASE WHEN SEQ_NO = 6 AND DOC_CLINIC_NBR = 82 THEN DOC_CLINIC_NBR END END END END END END = ").Append(QDesign.NULL(X_CLINIC())).Append(" OR ");
            strSQL.Append(QDesign.NULL(X_CLINIC())).Append(" = 0 OR (");
            strSQL.Append(QDesign.NULL(X_CLINIC())).Append(" = 60 AND (");
            strSQL.Append(" CASE WHEN SEQ_NO = 1 AND (DOC_CLINIC_NBR >= 60 AND DOC_CLINIC_NBR <= 66) THEN DOC_CLINIC_NBR ELSE");
            strSQL.Append(" CASE WHEN SEQ_NO = 2 AND (DOC_CLINIC_NBR >= 60 AND DOC_CLINIC_NBR <= 66) THEN DOC_CLINIC_NBR ELSE");
            strSQL.Append(" CASE WHEN SEQ_NO = 3 AND (DOC_CLINIC_NBR >= 60 AND DOC_CLINIC_NBR <= 66) THEN DOC_CLINIC_NBR ELSE");
            strSQL.Append(" CASE WHEN SEQ_NO = 4 AND (DOC_CLINIC_NBR >= 60 AND DOC_CLINIC_NBR <= 66) THEN DOC_CLINIC_NBR ELSE");
            strSQL.Append(" CASE WHEN SEQ_NO = 5 AND (DOC_CLINIC_NBR >= 60 AND DOC_CLINIC_NBR <= 66) THEN DOC_CLINIC_NBR ELSE");
            strSQL.Append(" CASE WHEN SEQ_NO = 6 AND (DOC_CLINIC_NBR >= 60 AND DOC_CLINIC_NBR <= 66) THEN DOC_CLINIC_NBR END END END END END END >= 60)))");

            rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        private void Link_F020_DOCTOR_EXTRA()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR ");
            strSQL.Append("FROM INDEXED.F020_DOCTOR_EXTRA ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_NBR = ").Append(Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_NBR")));
            rdrF020_DOCTOR_EXTRA.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        private void Link_F027_DOC()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("FILLER, ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("CONTACTS_TYPE ");
            strSQL.Append("FROM INDEXED.F027_CONTACTS_MSTR F027_DOC ");
            strSQL.Append("WHERE ");
            strSQL.Append("FILLER = ").Append(Common.StringToField(" "));
            strSQL.Append(" AND DOC_NBR = ").Append(Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_NBR")));
            strSQL.Append(" AND CONTACTS_TYPE = ").Append(Common.StringToField("D"));
            rdrF027_DOC.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        private void Link_F028_DOC_HOME()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("FILLER, ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("CONTACTS_TYPE, ");
            strSQL.Append("CONTACTS_LOCATION, ");
            strSQL.Append("CONTACTS_ADDR_1, ");
            strSQL.Append("CONTACTS_ADDR_2, ");
            strSQL.Append("CONTACTS_ADDR_3, ");
            strSQL.Append("POSTAL_CODE ");
            strSQL.Append("FROM INDEXED.F028_CONTACTS_INFO_MSTR F028_DOC_HOME ");
            strSQL.Append("WHERE ");
            strSQL.Append("FILLER = ").Append(Common.StringToField(" "));
            strSQL.Append(" AND DOC_NBR = ").Append(Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_NBR")));
            strSQL.Append(" AND CONTACTS_TYPE = ").Append(Common.StringToField("D"));
            strSQL.Append(" AND CONTACTS_LOCATION = ").Append(Common.StringToField("H"));
            rdrF028_DOC_HOME.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        private void Link_F028_DOC_OFFICE()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("FILLER, ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("CONTACTS_TYPE, ");
            strSQL.Append("CONTACTS_LOCATION, ");
            strSQL.Append("CONTACTS_ADDR_1, ");
            strSQL.Append("CONTACTS_ADDR_2, ");
            strSQL.Append("CONTACTS_ADDR_3, ");
            strSQL.Append("POSTAL_CODE ");
            strSQL.Append("FROM INDEXED.F028_CONTACTS_INFO_MSTR F028_DOC_OFFICE ");
            strSQL.Append("WHERE ");
            strSQL.Append("FILLER = ").Append(Common.StringToField(" "));
            strSQL.Append(" AND DOC_NBR = ").Append(Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_NBR")));
            strSQL.Append(" AND CONTACTS_TYPE = ").Append(Common.StringToField("D"));
            strSQL.Append(" AND CONTACTS_LOCATION = ").Append(Common.StringToField("O"));
            rdrF028_DOC_OFFICE.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(String.Empty);
            // TODO: CHOOSE Statement - May require manual changes.
            return strChoose.ToString().ToString();
        }

        public override bool SelectIf()
        {
            bool blnSelected = false;

            //if (((QDesign.NULL(X_CLINIC()) == QDesign.NULL(X_CLINIC_22()) || 
            //    QDesign.NULL(X_CLINIC()) == QDesign.NULL(X_CLINIC_60()) || 
            //    QDesign.NULL(X_CLINIC()) == QDesign.NULL(X_CLINIC_80()) || 
            //    QDesign.NULL(X_CLINIC()) == QDesign.NULL(X_CLINIC_81()) || 
            //    QDesign.NULL(X_CLINIC()) == QDesign.NULL(X_CLINIC_82()) || 
            //    QDesign.NULL(X_CLINIC()) == QDesign.NULL(0d)) || 
            //    (QDesign.NULL(X_CLINIC()) == QDesign.NULL(60d) && (X_CLINIC_60() >= 60)) && 
            //    (QDesign.NULL(X_DEPT()) == QDesign.NULL(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT")) || QDesign.NULL(X_DEPT()) == QDesign.NULL(0d)) && 
            //    (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT")) != QDesign.NULL(10d) && 
            //    QDesign.NULL(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT")) != QDesign.NULL(13d) && 
            //    QDesign.NULL(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT")) != QDesign.NULL(21d) && 
            //    QDesign.NULL(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT")) != QDesign.NULL(22d) && 
            //    QDesign.NULL(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT")) != QDesign.NULL(23d) && 
            //    QDesign.NULL(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT")) != QDesign.NULL(25d) && 
            //    QDesign.NULL(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT")) != QDesign.NULL(26d) && 
            //    QDesign.NULL(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT")) != QDesign.NULL(27d) && 
            //    QDesign.NULL(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT")) != QDesign.NULL(28d) && 
            //    QDesign.NULL(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT")) != QDesign.NULL(30d))) && 
            //    (QDesign.NULL(F020_DOCTOR_MSTR_DOC_DATE_FAC_TERM()) == QDesign.NULL(0d) || F020_DOCTOR_MSTR_DOC_DATE_FAC_TERM() >= QDesign.SysDate(ref m_cnnQUERY)) && 
            //    ((QDesign.NULL(X_CLASS()) == QDesign.NULL(1d) && QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "F") || 
            //    (QDesign.NULL(X_CLASS()) == QDesign.NULL(2d) && QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "P") || 
            //    (QDesign.NULL(X_CLASS()) == QDesign.NULL(3d) && QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "C") || 
            //    (QDesign.NULL(X_CLASS()) == QDesign.NULL(4d) && QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "S") || 
            //    (QDesign.NULL(X_CLASS()) == QDesign.NULL(0d))))
            //{
            //    blnSelected = true;
            //}

            if ((QDesign.NULL(X_DEPT()) == QDesign.NULL(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT")) || QDesign.NULL(X_DEPT()) == QDesign.NULL(0d)) &&
                (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT")) != QDesign.NULL(10d) &&
                QDesign.NULL(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT")) != QDesign.NULL(13d) &&
                QDesign.NULL(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT")) != QDesign.NULL(21d) &&
                QDesign.NULL(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT")) != QDesign.NULL(22d) &&
                QDesign.NULL(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT")) != QDesign.NULL(23d) &&
                QDesign.NULL(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT")) != QDesign.NULL(25d) &&
                QDesign.NULL(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT")) != QDesign.NULL(26d) &&
                QDesign.NULL(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT")) != QDesign.NULL(27d) &&
                QDesign.NULL(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT")) != QDesign.NULL(28d) &&
                QDesign.NULL(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT")) != QDesign.NULL(30d)) &&
                (QDesign.NULL(F020_DOCTOR_MSTR_DOC_DATE_FAC_TERM()) == QDesign.NULL(0d) || F020_DOCTOR_MSTR_DOC_DATE_FAC_TERM() >= QDesign.SysDate(ref m_cnnQUERY)) &&
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

        private decimal X_ADDR()
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

        private decimal X_CLINIC()
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

        private decimal X_DEPT()
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

        private decimal X_CLASS()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((ReportFunctions.astrScreenParameters[3].ToString().Trim() != String.Empty))
                {
                    decReturnValue = Decimal.Parse(ReportFunctions.astrScreenParameters[3].ToString());
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

        private string X_NAME()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = QDesign.Pack("DR. " + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT1") + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT2") + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT3") + " " + rdrF020_DOCTOR_MSTR.GetString("DOC_NAME"));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_DOCDEPT()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = QDesign.Pack(rdrF020_DOCTOR_MSTR.GetString("DOC_NBR") + "/" + QDesign.ASCII(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT"), 2));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_ADDR_1()
        {
            string strReturnValue = String.Empty;
            try
            {
                if ((QDesign.NULL(X_ADDR()) == QDesign.NULL(1d)))
                {
                    strReturnValue = rdrF028_DOC_OFFICE.GetString("CONTACTS_ADDR_1");
                }
                else
                {
                    strReturnValue = rdrF028_DOC_HOME.GetString("CONTACTS_ADDR_1");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_ADDR_2()
        {
            string strReturnValue = String.Empty;
            try
            {
                if ((QDesign.NULL(X_ADDR()) == QDesign.NULL(1d)))
                {
                    strReturnValue = rdrF028_DOC_OFFICE.GetString("CONTACTS_ADDR_2");
                }
                else
                {
                    strReturnValue = rdrF028_DOC_HOME.GetString("CONTACTS_ADDR_2");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_ADDR_3()
        {
            string strReturnValue = String.Empty;
            try
            {
                if ((QDesign.NULL(X_ADDR()) == QDesign.NULL(1d)))
                {
                    strReturnValue = rdrF028_DOC_OFFICE.GetString("CONTACTS_ADDR_3");
                }
                else
                {
                    strReturnValue = rdrF028_DOC_HOME.GetString("CONTACTS_ADDR_3");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_ADDR_PC_1()
        {
            string strReturnValue = String.Empty;
            try
            {
                if ((QDesign.NULL(X_ADDR()) == QDesign.NULL(1d)))
                {
                    strReturnValue = QDesign.Substring(rdrF028_DOC_OFFICE.GetString("POSTAL_CODE"), 1, 3);
                }
                else
                {
                    strReturnValue = QDesign.Substring(rdrF028_DOC_HOME.GetString("POSTAL_CODE"), 1, 3);
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_ADDR_PC_2()
        {
            string strReturnValue = String.Empty;
            try
            {
                if ((QDesign.NULL(X_ADDR()) == QDesign.NULL(1d)))
                {
                    strReturnValue = QDesign.Substring(rdrF028_DOC_OFFICE.GetString("POSTAL_CODE"), 4, 3);
                }
                else
                {
                    strReturnValue = QDesign.Substring(rdrF028_DOC_HOME.GetString("POSTAL_CODE"), 4, 3);
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private decimal X_CLINIC_22()
        {
            decimal decReturnValue = 0;
            try
            {
                if (QDesign.NULL(rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR")) == QDesign.NULL(22d) && QDesign.NULL(rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("SEQ_NO")) == 1)
                {
                    decReturnValue = rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_CLINIC_60()
        {
            decimal decReturnValue = 0;
            try
            {
                if (QDesign.NULL(rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("SEQ_NO")) == 1 && (rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR") >= 60 && rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR") <= 66))
                {
                    decReturnValue = rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR");
                }
                else if (QDesign.NULL(rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("SEQ_NO")) == 2 && (rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR") >= 60 && rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR") <= 66))
                {
                    decReturnValue = rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR");
                }
                else if (QDesign.NULL(rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("SEQ_NO")) == 3 && (rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR") >= 60 && rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR") <= 66))
                {
                    decReturnValue = rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR");
                }
                else if (QDesign.NULL(rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("SEQ_NO")) == 4 && (rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR") >= 60 && rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR") <= 66))
                {
                    decReturnValue = rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR");
                }
                else if (QDesign.NULL(rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("SEQ_NO")) == 5 && (rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR") >= 60 && rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR") <= 66))
                {
                    decReturnValue = rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR");
                }
                else if (QDesign.NULL(rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("SEQ_NO")) == 6 && (rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR") >= 60 && rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR") <= 66))
                {
                    decReturnValue = rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_CLINIC_80()
        {
            decimal decReturnValue = 0;
            try
            {
                if (QDesign.NULL(rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("SEQ_NO")) == 1 && QDesign.NULL(rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR")) == QDesign.NULL(80d))
                {
                    decReturnValue = rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR");
                }
                else if (QDesign.NULL(rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("SEQ_NO")) == 2 && QDesign.NULL(rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR")) == QDesign.NULL(80d))
                {
                    decReturnValue = rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR");
                }
                else if (QDesign.NULL(rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("SEQ_NO")) == 3 && QDesign.NULL(rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR")) == QDesign.NULL(80d))
                {
                    decReturnValue = rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR");
                }
                else if (QDesign.NULL(rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("SEQ_NO")) == 4 && QDesign.NULL(rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR")) == QDesign.NULL(80d))
                {
                    decReturnValue = rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR");
                }
                else if (QDesign.NULL(rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("SEQ_NO")) == 5 && QDesign.NULL(rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR")) == QDesign.NULL(80d))
                {
                    decReturnValue = rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR");
                }
                else if (QDesign.NULL(rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("SEQ_NO")) == 6 && QDesign.NULL(rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR")) == QDesign.NULL(80d))
                {
                    decReturnValue = rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_CLINIC_81()
        {
            decimal decReturnValue = 0;
            try
            {
                if (QDesign.NULL(rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("SEQ_NO")) == 1 && QDesign.NULL(rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR")) == QDesign.NULL(81d))
                {
                    decReturnValue = rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR");
                }
                else if (QDesign.NULL(rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("SEQ_NO")) == 2 && QDesign.NULL(rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR")) == QDesign.NULL(81d))
                {
                    decReturnValue = rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR");
                }
                else if (QDesign.NULL(rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("SEQ_NO")) == 3 && QDesign.NULL(rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR")) == QDesign.NULL(81d))
                {
                    decReturnValue = rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR");
                }
                else if (QDesign.NULL(rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("SEQ_NO")) == 4 && QDesign.NULL(rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR")) == QDesign.NULL(81d))
                {
                    decReturnValue = rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR");
                }
                else if (QDesign.NULL(rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("SEQ_NO")) == 5 && QDesign.NULL(rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR")) == QDesign.NULL(81d))
                {
                    decReturnValue = rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR");
                }
                else if (QDesign.NULL(rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("SEQ_NO")) == 6 && QDesign.NULL(rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR")) == QDesign.NULL(81d))
                {
                    decReturnValue = rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_CLINIC_82()
        {
            decimal decReturnValue = 0;
            try
            {
                if (QDesign.NULL(rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("SEQ_NO")) == 1 && QDesign.NULL(rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR")) == QDesign.NULL(82d))
                {
                    decReturnValue = rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR");
                }
                else if (QDesign.NULL(rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("SEQ_NO")) == 2 && QDesign.NULL(rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR")) == QDesign.NULL(82d))
                {
                    decReturnValue = rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR");
                }
                else if (QDesign.NULL(rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("SEQ_NO")) == 3 && QDesign.NULL(rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR")) == QDesign.NULL(82d))
                {
                    decReturnValue = rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR");
                }
                else if (QDesign.NULL(rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("SEQ_NO")) == 4 && QDesign.NULL(rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR")) == QDesign.NULL(82d))
                {
                    decReturnValue = rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR");
                }
                else if (QDesign.NULL(rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("SEQ_NO")) == 5 && QDesign.NULL(rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR")) == QDesign.NULL(82d))
                {
                    decReturnValue = rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR");
                }
                else if (QDesign.NULL(rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("SEQ_NO")) == 6 && QDesign.NULL(rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR")) == QDesign.NULL(82d))
                {
                    decReturnValue = rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR");
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal F020_DOCTOR_MSTR_DOC_DATE_FAC_TERM()
        {
            decimal decReturnValue = 0;

            try
            {
                decReturnValue = QDesign.NConvert(QDesign.ASCII(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DATE_FAC_TERM_YY"), 4) + QDesign.ASCII(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DATE_FAC_TERM_MM"), 2) + QDesign.ASCII(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DATE_FAC_TERM_DD"), 2));
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
            return decReturnValue;
        }

        private string F020_DOCTOR_MSTR_DOC_INITS()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = rdrF020_DOCTOR_MSTR.GetString("DOC_INIT1") + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT2") + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT3");
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
            return strReturnValue;
        }

        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.REPORT, "X_DOCDEPT", DataTypes.Character, 6);
                AddControl(ReportSection.REPORT, "X_NAME", DataTypes.Character, 30);
                AddControl(ReportSection.REPORT, "X_ADDR_1", DataTypes.Character, 30);
                AddControl(ReportSection.REPORT, "X_ADDR_2", DataTypes.Character, 30);
                AddControl(ReportSection.REPORT, "X_ADDR_3", DataTypes.Character, 30);
                AddControl(ReportSection.REPORT, "X_ADDR_PC_1", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "X_ADDR_PC_2", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "INDEXED.F020C_DOC_CLINIC_NEXT_BATCH_NBR.DOC_CLINIC_NBR", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "INDEXED.F020_DOCTOR_MSTR.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "DOC_INITS", DataTypes.Character, 3);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-07-30 10:52:26 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            // TODO: Remove duplicate controls, if there are any.
            switch (strControl)
            {
                case "X_DOCDEPT":
                    return Common.StringToField(X_DOCDEPT(), intSize);

                case "X_NAME":
                    return Common.StringToField(X_NAME(), intSize);

                case "X_ADDR_1":
                    return Common.StringToField(X_ADDR_1(), intSize);

                case "X_ADDR_2":
                    return Common.StringToField(X_ADDR_2(), intSize);

                case "X_ADDR_3":
                    return Common.StringToField(X_ADDR_3(), intSize);

                case "X_ADDR_PC_1":
                    return Common.StringToField(X_ADDR_PC_1(), intSize);

                case "X_ADDR_PC_2":
                    return Common.StringToField(X_ADDR_PC_2(), intSize);

                case "INDEXED.F020C_DOC_CLINIC_NEXT_BATCH_NBR.DOC_CLINIC_NBR":
                    return rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR").ToString();

                case "INDEXED.F020_DOCTOR_MSTR.DOC_NBR":
                    return Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_NBR"));

                case "DOC_INITS":
                    return Common.StringToField(F020_DOCTOR_MSTR_DOC_INITS(), intSize);

                default:
                    return String.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                // TODO: Some manual steps maybe required.
                Access_F020_DOCTOR_MSTR();
                while (rdrF020_DOCTOR_MSTR.Read())
                {
                    Link_F020C_DOC_CLINIC_NEXT_BATCH_NBR();
                    while (rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.Read())
                    {
                        Link_F020_DOCTOR_EXTRA();
                        while (rdrF020_DOCTOR_EXTRA.Read())
                        {
                            Link_F027_DOC();
                            while (rdrF027_DOC.Read())
                            {
                                Link_F028_DOC_HOME();
                                while (rdrF028_DOC_HOME.Read())
                                {
                                    Link_F028_DOC_OFFICE();
                                    while (rdrF028_DOC_OFFICE.Read())
                                    {
                                        WriteData();
                                    }
                                    rdrF028_DOC_OFFICE.Close();
                                }
                                rdrF028_DOC_HOME.Close();
                            }
                            rdrF027_DOC.Close();
                        }
                        rdrF020_DOCTOR_EXTRA.Close();
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

            if (!(rdrF020_DOCTOR_EXTRA == null))
            {
                rdrF020_DOCTOR_EXTRA.Close();
                rdrF020_DOCTOR_EXTRA = null;
            }

            if (!(rdrF027_DOC == null))
            {
                rdrF027_DOC.Close();
                rdrF027_DOC = null;
            }

            if (!(rdrF028_DOC_HOME == null))
            {
                rdrF028_DOC_HOME.Close();
                rdrF028_DOC_HOME = null;
            }

            if (!(rdrF028_DOC_OFFICE == null))
            {
                rdrF028_DOC_OFFICE.Close();
                rdrF028_DOC_OFFICE = null;
            }
        }
    }
}
