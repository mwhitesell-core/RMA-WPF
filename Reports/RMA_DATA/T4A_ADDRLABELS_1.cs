//  t4a_addrlabels_1.qzs
//  CREATE MAILING DOCTOR ADDRESS LABELS
//  RUN FOR: MANAGEMENT/STAFF
//  PROGRAM PURPOSE : MAILING DOCTOR ADDRESS LABELS
//  This phase - select doctors that match user`s criteria
//  DATE        WHO        DESCRIPTION
//  92/mar/18   YASEMIN    - original
//  05/feb/07              - prdecimal for t4a`s mail out prdecimal one set company = 1 and
//  set company = 2
//  05/feb/08   b.e. -add postpass of basic program to eliminate duplicate 
//  doctors by selecting 1 doctor per doc-ohip-nbr
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
    public class T4A_ADDRLABELS_1 : BaseRDLClass
    {
        protected const string REPORT_NAME = "T4A_ADDRLABELS_1";
        protected const bool REPORT_HAS_PARAMETERS = true;
        private Reader rdrF020_DOCTOR_MSTR = new Reader();
        private Reader rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR = new Reader();
        private Reader rdrF070_DEPT_MSTR = new Reader();

        private Reader rdrT4A_ADDRLABELS_1 = new Reader();
        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                //  Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;
                //  Create Subfile.
                SubFile = true;
                SubFileName = "T4A_ADDRLABELS_1";
                SubFileType = SubFileType.Keep;
                SubFileAT = "TODO: Enter sortbreak name";
                Sort = "";
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
            strSQL.Append("DOC_DEPT, ");
            strSQL.Append("DOC_INIT1, ");
            strSQL.Append("DOC_INIT2, ");
            strSQL.Append("DOC_INIT3, ");
            strSQL.Append("DOC_NAME, ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("DOC_ADDR_OFFICE_1, ");
            strSQL.Append("DOC_ADDR_HOME_1, ");
            strSQL.Append("DOC_ADDR_OFFICE_2, ");
            strSQL.Append("DOC_ADDR_HOME_2, ");
            strSQL.Append("DOC_ADDR_OFFICE_3, ");
            strSQL.Append("DOC_ADDR_HOME_3, ");
            strSQL.Append("DOC_ADDR_OFFICE_PC1, ");
            strSQL.Append("DOC_ADDR_OFFICE_PC2, ");
            strSQL.Append("DOC_ADDR_OFFICE_PC3, ");
            strSQL.Append("DOC_ADDR_HOME_PC1, ");
            strSQL.Append("DOC_ADDR_HOME_PC2, ");
            strSQL.Append("DOC_ADDR_HOME_PC3, ");
            strSQL.Append("DOC_ADDR_OFFICE_PC4, ");
            strSQL.Append("DOC_ADDR_OFFICE_PC5, ");
            strSQL.Append("DOC_ADDR_OFFICE_PC6, ");
            strSQL.Append("DOC_ADDR_HOME_PC4, ");
            strSQL.Append("DOC_ADDR_HOME_PC5, ");
            strSQL.Append("DOC_ADDR_HOME_PC6, ");
            strSQL.Append("DOC_DATE_FAC_TERM_YY, ");
            strSQL.Append("DOC_DATE_FAC_TERM_MM, ");
            strSQL.Append("DOC_DATE_FAC_TERM_DD, ");
            strSQL.Append("DOC_DATE_FAC_START_YY, ");
            strSQL.Append("DOC_DATE_FAC_START_MM, ");
            strSQL.Append("DOC_DATE_FAC_START_DD, ");
            strSQL.Append("DOC_FULL_PART_IND, ");
            strSQL.Append("DOC_OHIP_NBR ");
            strSQL.Append("FROM INDEXED.F020_DOCTOR_MSTR ");

            strSQL.Append(Choose());

            rdrF020_DOCTOR_MSTR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        private void Link_F020C_DOC_CLINIC_NEXT_BATCH_NBR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_CLINIC_NBR, ");
            strSQL.Append("SEQ_NO ");
            strSQL.Append("FROM INDEXED.F020C_DOC_CLINIC_NEXT_BATCH_NBR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_NBR = ").Append(Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_NBR")));
            strSQL.Append("ORDER BY DOC_NBR, SEQ_NO");

            rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        private void Link_F070_DEPT_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DEPT_NBR, ");
            strSQL.Append("DEPT_COMPANY ");
            strSQL.Append("FROM INDEXED.F070_DEPT_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DEPT_NBR = ").Append(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT"));

            rdrF070_DEPT_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
    
        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(string.Empty);

            return strChoose.ToString().ToString();
        }
    
        public override bool SelectIf()
        {
            bool blnSelected = false;
            if (((QDesign.NULL(X_CLINIC()) == QDesign.NULL(X_CLINIC_22()) ||
                QDesign.NULL(X_CLINIC()) == QDesign.NULL(X_CLINIC_60()) ||
                QDesign.NULL(X_CLINIC()) == QDesign.NULL(X_CLINIC_80()) ||
                QDesign.NULL(X_CLINIC()) == QDesign.NULL(X_CLINIC_81()) ||
                QDesign.NULL(X_CLINIC()) == QDesign.NULL(X_CLINIC_82()) ||
                QDesign.NULL(X_CLINIC()) == QDesign.NULL(0d) ||
                (QDesign.NULL(X_CLINIC()) == 60) && (X_CLINIC_60() >= 60))) &&
                ((QDesign.NULL(X_DEPT()) == QDesign.NULL(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT")) || QDesign.NULL(X_DEPT()) == 0) &&
                (QDesign.NULL(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT")) != 31)) &&
                (QDesign.NULL(X_COMPANY()) == QDesign.NULL(rdrF070_DEPT_MSTR.GetNumber("DEPT_COMPANY")) || QDesign.NULL(X_COMPANY()) == 0) &&
                (QDesign.NULL(F020_DOCTOR_MSTR_DOC_DATE_FAC_TERM()) == 0 || QDesign.NULL(F020_DOCTOR_MSTR_DOC_DATE_FAC_TERM()) >= 20031201) &&
                ((QDesign.NULL(X_CLASS()) == 1 && QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "F") ||
                (QDesign.NULL(X_CLASS()) == 2 && QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "P") ||
                (QDesign.NULL(X_CLASS()) == 3 && QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "C") ||
                (QDesign.NULL(X_CLASS()) == 4 && QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "S") ||
                (QDesign.NULL(X_CLASS()) == 0)))
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
                if ((ReportFunctions.astrScreenParameters[0].ToString().Trim() != string.Empty))
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
                if ((ReportFunctions.astrScreenParameters[1].ToString().Trim() != string.Empty))
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
                if ((ReportFunctions.astrScreenParameters[2].ToString().Trim() != string.Empty))
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
                if ((ReportFunctions.astrScreenParameters[3].ToString().Trim() != string.Empty))
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
    
        private decimal X_COMPANY()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((ReportFunctions.astrScreenParameters[4].ToString().Trim() != string.Empty))
                {
                    decReturnValue = Decimal.Parse(ReportFunctions.astrScreenParameters[4].ToString());
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
            string strReturnValue = string.Empty;
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
    
        private string X_DOCDEPT() {
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
            string strReturnValue = string.Empty;
            try
            {
                if ((QDesign.NULL(X_ADDR()) == QDesign.NULL(1d)))
                {
                    strReturnValue = rdrF020_DOCTOR_MSTR.GetString("DOC_ADDR_OFFICE_1");
                }
                else if ((QDesign.NULL(X_ADDR()) == QDesign.NULL(2d))) 
                {
                    strReturnValue = rdrF020_DOCTOR_MSTR.GetString("DOC_ADDR_HOME_1");
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
            string strReturnValue = string.Empty;
            try
            {
                if ((QDesign.NULL(X_ADDR()) == QDesign.NULL(1d)))
                {
                    strReturnValue = rdrF020_DOCTOR_MSTR.GetString("DOC_ADDR_OFFICE_2");
                }
                else if ((QDesign.NULL(X_ADDR()) == QDesign.NULL(2d))) 
                {
                    strReturnValue = rdrF020_DOCTOR_MSTR.GetString("DOC_ADDR_HOME_2");
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
            string strReturnValue = string.Empty;
            try
            {
                if ((QDesign.NULL(X_ADDR()) == QDesign.NULL(1d)))
                {
                    strReturnValue = rdrF020_DOCTOR_MSTR.GetString("DOC_ADDR_OFFICE_3");
                }
                else if ((QDesign.NULL(X_ADDR()) == QDesign.NULL(2d))) 
                {
                    strReturnValue = rdrF020_DOCTOR_MSTR.GetString("DOC_ADDR_HOME_3");
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
            string strReturnValue = string.Empty;
            try
            {
                if ((QDesign.NULL(X_ADDR()) == QDesign.NULL(1d)))
                {
                    strReturnValue = rdrF020_DOCTOR_MSTR.GetString("DOC_ADDR_OFFICE_PC1").PadRight(1, ' ') + QDesign.ASCII(rdrF020_DOCTOR_MSTR.GetNumber("DOC_ADDR_OFFICE_PC2"), 1) + rdrF020_DOCTOR_MSTR.GetString("DOC_ADDR_OFFICE_PC3").PadRight(1, ' ');
                }
                else if ((QDesign.NULL(X_ADDR()) == QDesign.NULL(2d))) 
                {
                    strReturnValue = rdrF020_DOCTOR_MSTR.GetString("DOC_ADDR_HOME_PC1").PadRight(1, ' ') + QDesign.ASCII(rdrF020_DOCTOR_MSTR.GetNumber("DOC_ADDR_HOME_PC2"), 1) + rdrF020_DOCTOR_MSTR.GetString("DOC_ADDR_HOME_PC3").PadRight(1, ' ');
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
            string strReturnValue = string.Empty;
            try
            {
                if ((QDesign.NULL(X_ADDR()) == QDesign.NULL(1d)))
                {
                    strReturnValue = QDesign.ASCII(rdrF020_DOCTOR_MSTR.GetNumber("DOC_ADDR_OFFICE_PC4"), 1) + rdrF020_DOCTOR_MSTR.GetString("DOC_ADDR_OFFICE_PC5").PadRight(1, ' ') + QDesign.ASCII(rdrF020_DOCTOR_MSTR.GetNumber("DOC_ADDR_OFFICE_PC6"), 1);
                }
                else if ((QDesign.NULL(X_ADDR()) == QDesign.NULL(2d))) 
                {
                    strReturnValue = QDesign.ASCII(rdrF020_DOCTOR_MSTR.GetNumber("DOC_ADDR_HOME_PC4"), 1) + rdrF020_DOCTOR_MSTR.GetString("DOC_ADDR_HOME_PC5").PadRight(1, ' ') + QDesign.ASCII(rdrF020_DOCTOR_MSTR.GetNumber("DOC_ADDR_HOME_PC6"), 1);
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
                if (QDesign.NULL((PREV_DOC_CLINIC_NBR)) == QDesign.NULL(22d))
                {
                    decReturnValue = PREV_DOC_CLINIC_NBR;
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
                if ((PREV_DOC_CLINIC_NBR >= 60 && PREV_DOC_CLINIC_NBR <= 65))
                {
                    decReturnValue = PREV_DOC_CLINIC_NBR;
                }
                else if ((PREV_DOC_CLINIC_NBR_2 >= 60 && PREV_DOC_CLINIC_NBR_2 <= 65))
                {
                    decReturnValue = PREV_DOC_CLINIC_NBR_2;
                }
                else if ((PREV_DOC_CLINIC_NBR_3 >= 60 && PREV_DOC_CLINIC_NBR_3 <= 65))
                {
                    decReturnValue = PREV_DOC_CLINIC_NBR_3;
                }
                else if ((PREV_DOC_CLINIC_NBR_4 >= 60 && PREV_DOC_CLINIC_NBR_4 <= 65))
                {
                    decReturnValue = PREV_DOC_CLINIC_NBR_4;
                }
                else if ((PREV_DOC_CLINIC_NBR_5 >= 60 && PREV_DOC_CLINIC_NBR_5 <= 65))
                {
                    decReturnValue = PREV_DOC_CLINIC_NBR_5;
                }
                else if ((PREV_DOC_CLINIC_NBR_6 >= 60 && PREV_DOC_CLINIC_NBR_6 <= 65))
                {
                    decReturnValue = PREV_DOC_CLINIC_NBR_6;
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
                if (QDesign.NULL(PREV_DOC_CLINIC_NBR) == QDesign.NULL(80d))
                {
                    decReturnValue = PREV_DOC_CLINIC_NBR;
                }
                else if (QDesign.NULL(PREV_DOC_CLINIC_NBR_2) == QDesign.NULL(80d)) 
                {
                    decReturnValue = PREV_DOC_CLINIC_NBR_2;
                }
                else if (QDesign.NULL(PREV_DOC_CLINIC_NBR_3) == QDesign.NULL(80d)) 
                {
                    decReturnValue = PREV_DOC_CLINIC_NBR_3;
                }
                else if (QDesign.NULL(PREV_DOC_CLINIC_NBR_4) == QDesign.NULL(80d)) 
                {
                    decReturnValue = PREV_DOC_CLINIC_NBR_4;
                }
                else if (QDesign.NULL(PREV_DOC_CLINIC_NBR_5) == QDesign.NULL(80d)) 
                {
                    decReturnValue = PREV_DOC_CLINIC_NBR_5;
                }
                else if (QDesign.NULL(PREV_DOC_CLINIC_NBR_6) == QDesign.NULL(80d)) 
                {
                    decReturnValue = PREV_DOC_CLINIC_NBR_6;
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
                if (QDesign.NULL(PREV_DOC_CLINIC_NBR) == QDesign.NULL(81d))
                {
                    decReturnValue = PREV_DOC_CLINIC_NBR;
                }
                else if (QDesign.NULL(PREV_DOC_CLINIC_NBR_2) == QDesign.NULL(81d)) 
                {
                    decReturnValue = PREV_DOC_CLINIC_NBR_2;
                }
                else if (QDesign.NULL(PREV_DOC_CLINIC_NBR_3) == QDesign.NULL(81d)) 
                {
                    decReturnValue = PREV_DOC_CLINIC_NBR_3;
                }
                else if (QDesign.NULL(PREV_DOC_CLINIC_NBR_4) == QDesign.NULL(81d)) 
                {
                    decReturnValue = PREV_DOC_CLINIC_NBR_4;
                }
                else if (QDesign.NULL(PREV_DOC_CLINIC_NBR_5) == QDesign.NULL(81d)) 
                {
                    decReturnValue = PREV_DOC_CLINIC_NBR_5;
                }
                else if (QDesign.NULL(PREV_DOC_CLINIC_NBR_6) == QDesign.NULL(81d)) 
                {
                    decReturnValue = PREV_DOC_CLINIC_NBR_6;
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
                if (QDesign.NULL(PREV_DOC_CLINIC_NBR) == QDesign.NULL(82d))
                {
                    decReturnValue = PREV_DOC_CLINIC_NBR;
                }
                else if (QDesign.NULL(PREV_DOC_CLINIC_NBR_2) == QDesign.NULL(82d)) 
                {
                    decReturnValue = PREV_DOC_CLINIC_NBR_2;
                }
                else if (QDesign.NULL(PREV_DOC_CLINIC_NBR_3) == QDesign.NULL(82d)) 
                {
                    decReturnValue = PREV_DOC_CLINIC_NBR_3;
                }
                else if (QDesign.NULL(PREV_DOC_CLINIC_NBR_4) == QDesign.NULL(82d)) 
                {
                    decReturnValue = PREV_DOC_CLINIC_NBR_4;
                }
                else if (QDesign.NULL(PREV_DOC_CLINIC_NBR_5) == QDesign.NULL(82d)) 
                {
                    decReturnValue = PREV_DOC_CLINIC_NBR_5;
                }
                else if (QDesign.NULL(PREV_DOC_CLINIC_NBR_6) == QDesign.NULL(82d)) 
                {
                    decReturnValue = PREV_DOC_CLINIC_NBR_6;
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return decReturnValue;
        }

        private decimal F020_DOCTOR_MSTR_DOC_DATE_FAC_START()
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

        private decimal F020_DOCTOR_MSTR_DOC_DATE_FAC_TERM()
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

        private decimal CNTER = 0;
        private decimal SEQ_NUM = 0;
        private decimal PREV_DOC_CLINIC_NBR = 0;
        private decimal PREV_DOC_CLINIC_NBR_2 = 0;
        private decimal PREV_DOC_CLINIC_NBR_3 = 0;
        private decimal PREV_DOC_CLINIC_NBR_4 = 0;
        private decimal PREV_DOC_CLINIC_NBR_5 = 0;
        private decimal PREV_DOC_CLINIC_NBR_6 = 0;
        private decimal PREV_DOC_OHIP_NBR = 0;

        private string PREV_DOC_NBR = string.Empty;
        private string PREV_X_DOCDEPT = string.Empty;
        private string PREV_X_NAME = string.Empty;
        private string PREV_X_ADDR_1 = string.Empty;
        private string PREV_X_ADDR_2 = string.Empty;
        private string PREV_X_ADDR_3 = string.Empty;
        private string PREV_X_ADDR_PC_1 = string.Empty;
        private string PREV_X_ADDR_PC_2 = string.Empty;

        public override void DeclareReportControls()
        {
            try
            {
                 AddControl(ReportSection.SUMMARY, "INDEXED.F020_DOCTOR_MSTR.DOC_OHIP_NBR", DataTypes.Numeric, 6);
                 AddControl(ReportSection.SUMMARY, "INDEXED.F020_DOCTOR_MSTR.DOC_NBR", DataTypes.Character, 3);
                 AddControl(ReportSection.SUMMARY, "X_DOCDEPT", DataTypes.Character, 6);
                 AddControl(ReportSection.SUMMARY, "X_NAME", DataTypes.Character, 30);
                 AddControl(ReportSection.SUMMARY, "X_ADDR_1", DataTypes.Character, 30);
                 AddControl(ReportSection.SUMMARY, "X_ADDR_2", DataTypes.Character, 30);
                 AddControl(ReportSection.SUMMARY, "X_ADDR_3", DataTypes.Character, 30);
                 AddControl(ReportSection.SUMMARY, "X_ADDR_PC_1", DataTypes.Character, 6);
                 AddControl(ReportSection.SUMMARY, "X_ADDR_PC_2", DataTypes.Character, 6);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
    
        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-07-20 11:56:25 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "INDEXED.F020_DOCTOR_MSTR.DOC_OHIP_NBR":
                    return PREV_DOC_OHIP_NBR.ToString();

                case "INDEXED.F020_DOCTOR_MSTR.DOC_NBR":
                    return Common.StringToField(PREV_DOC_NBR);

                case "X_DOCDEPT":
                    return Common.StringToField(PREV_X_DOCDEPT, intSize);

                case "X_NAME":
                    return Common.StringToField(PREV_X_NAME, intSize);

                case "X_ADDR_1":
                    return Common.StringToField(PREV_X_ADDR_1, intSize);

                case "X_ADDR_2":
                    return Common.StringToField(PREV_X_ADDR_2, intSize);

                case "X_ADDR_3":
                    return Common.StringToField(PREV_X_ADDR_3, intSize);

                case "X_ADDR_PC_1":
                    return Common.StringToField(PREV_X_ADDR_PC_1, intSize);

                case "X_ADDR_PC_2":
                    return Common.StringToField(PREV_X_ADDR_PC_2, intSize);

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
                    if (CNTER > 0)
                    {
                        WriteData();
                        CNTER = 0;

                        PREV_DOC_NBR = rdrF020_DOCTOR_MSTR.GetString("DOC_NBR");
                        PREV_X_NAME = X_NAME();
                        PREV_X_DOCDEPT = X_DOCDEPT();
                        PREV_X_ADDR_1 = X_ADDR_1();
                        PREV_X_ADDR_2 = X_ADDR_2();
                        PREV_X_ADDR_3 = X_ADDR_3();
                        PREV_X_ADDR_PC_1 = X_ADDR_PC_1();
                        PREV_X_ADDR_PC_2 = X_ADDR_PC_2();
                        PREV_DOC_OHIP_NBR = rdrF020_DOCTOR_MSTR.GetNumber("DOC_OHIP_NBR");
                    }
                    else
                    {
                        PREV_DOC_NBR = rdrF020_DOCTOR_MSTR.GetString("DOC_NBR");
                        PREV_X_NAME = X_NAME();
                        PREV_X_DOCDEPT = X_DOCDEPT();
                        PREV_X_ADDR_1 = X_ADDR_1();
                        PREV_X_ADDR_2 = X_ADDR_2();
                        PREV_X_ADDR_3 = X_ADDR_3();
                        PREV_X_ADDR_PC_1 = X_ADDR_PC_1();
                        PREV_X_ADDR_PC_2 = X_ADDR_PC_2();
                        PREV_DOC_OHIP_NBR = rdrF020_DOCTOR_MSTR.GetNumber("DOC_OHIP_NBR");
                    }

                    Link_F020C_DOC_CLINIC_NEXT_BATCH_NBR();
                    while (rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.Read())
                    {
                        Link_F070_DEPT_MSTR();
                        while (rdrF070_DEPT_MSTR.Read())
                        {
                            switch (rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("SEQ_NO").ToString())
                            {
                                case "1":
                                    PREV_DOC_CLINIC_NBR = rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR");
                                    CNTER = rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("SEQ_NO");
                                    break;

                                case "2":
                                    PREV_DOC_CLINIC_NBR_2 = rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR");
                                    CNTER = rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("SEQ_NO");
                                    break;

                                case "3":
                                    PREV_DOC_CLINIC_NBR_3 = rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR");
                                    CNTER = rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("SEQ_NO");
                                    break;

                                case "4":
                                    PREV_DOC_CLINIC_NBR_4 = rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR");
                                    CNTER = rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("SEQ_NO");
                                    break;

                                case "5":
                                    PREV_DOC_CLINIC_NBR_5 = rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR");
                                    CNTER = rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("SEQ_NO");
                                    break;

                                case "6":
                                    PREV_DOC_CLINIC_NBR_6 = rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR");
                                    CNTER = rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("SEQ_NO");
                                    break;
                            }
                        }
                        rdrF070_DEPT_MSTR.Close();
                    }
                    rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.Close();
                }
                rdrF020_DOCTOR_MSTR.Close();

                //Core Added: Write out last record
                WriteData();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders() {
            if (!(rdrF020_DOCTOR_MSTR == null)) {
                rdrF020_DOCTOR_MSTR.Close();
                rdrF020_DOCTOR_MSTR = null;
            }

            if (!(rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR == null))
            {
                rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.Close();
                rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR = null;
            }

            if (!(rdrF070_DEPT_MSTR == null)) {
                rdrF070_DEPT_MSTR.Close();
                rdrF070_DEPT_MSTR = null;
            }
        }
    }
}
