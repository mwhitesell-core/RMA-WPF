//  DOC: DOCTORLIST.QZS
//  DOC: CREATE DOCTOR LISTING REPORT
//  DOC: RUN FOR: MANAGEMENT/STAFF
//  PROGRAM PURPOSE : DOCTOR LISTING REPORT
//  DATE       WHO       DESCRIPTION
//  92/03/16   YASEMIN   ORIGINAL
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
    public class DOCTORLIST : BaseRDLClass
    {
        protected const string REPORT_NAME = "DOCTORLIST";
        protected const bool REPORT_HAS_PARAMETERS = true;

        private Reader rdrF020_DOCTOR_MSTR = new Reader();
        private Reader rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR = new Reader();

        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                //  Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;

                switch (arrParameters[12].ToString())
                {
                    case "1":
                        Sort = "DOC_NBR ASC";
                        break;
                    case "2":
                        Sort = "DOC_CLINIC_NBR ASC, X_NAME ASC";
                        break;
                    case "3":
                        Sort = "DOC_CLINIC_NBR ASC, DOC_DEPT ASC, DOC_NBR ASC";
                        break;
                    case "4":
                        Sort = "DOC_CLINIC_NBR ASC, DOC_DEPT ASC, X_NAME ASC";
                        break;
                    case "6":
                        Sort = "DOC_DEPT ASC, DOC_FULL_PART_IND ASC, X_NAME ASC";
                        break;
                    case "7":
                        Sort = "DOC_CLINIC_NBR ASC, DOC_DEPT ASC, DOC_FULL_PART_IND ASC, DOC_NBR ASC";
                        break;
                    case "8":
                        Sort = "DOC_CLINIC_NBR ASC, DOC_DEPT ASC, DOC_FULL_PART_IND ASC, X_NAME ASC";
                        break;
                    default:
                        Sort = "DOC_CLINIC_NBR ASC, X_NAME ASC";
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
            strSQL.Append("DOC_DEPT, ");
            strSQL.Append("DOC_FULL_PART_IND, ");
            strSQL.Append("DOC_DATE_FAC_START_YY, ");
            strSQL.Append("DOC_DATE_FAC_START_MM, ");
            strSQL.Append("DOC_DATE_FAC_START_DD, ");
            strSQL.Append("DOC_DATE_FAC_TERM_YY, ");
            strSQL.Append("DOC_DATE_FAC_TERM_MM, ");
            strSQL.Append("DOC_DATE_FAC_TERM_DD, ");
            strSQL.Append("DOC_NAME, ");
            strSQL.Append("DOC_INIT1, ");
            strSQL.Append("DOC_INIT2, ");
            strSQL.Append("DOC_INIT3, ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("DOC_OHIP_NBR, ");
            strSQL.Append("DOC_SPEC_CD, ");
            strSQL.Append("DOC_SUB_SPECIALTY, ");
            strSQL.Append("DOC_SPEC_CD_2 ");
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

        private string Choose() {
            StringBuilder strChoose = new StringBuilder(string.Empty);

            return strChoose.ToString().ToString();
        }
    
        public override bool SelectIf()
        {
            bool blnSelected = false;
            if ((QDesign.NULL(X_CLINIC()) == QDesign.NULL(rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetNumber("DOC_CLINIC_NBR")) || QDesign.NULL(X_CLINIC()) == QDesign.NULL(0d)) && 
                (QDesign.NULL(X_DEPT()) == QDesign.NULL(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT")) || QDesign.NULL(X_DEPT()) == QDesign.NULL(0d)) && 
                ((QDesign.NULL(X_CLASS()) == QDesign.NULL(1D) && QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "F") || 
                (QDesign.NULL(X_CLASS()) == QDesign.NULL(2D) && QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "P") || 
                (QDesign.NULL(X_CLASS()) == QDesign.NULL(3D) && QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "C") || 
                (QDesign.NULL(X_CLASS()) == QDesign.NULL(4D) && QDesign.NULL(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND")) == "S") || 
                (QDesign.NULL(X_CLASS()) == QDesign.NULL(0d))) && 
                (((F020_DOCTOR_MSTR_DOC_DATE_FAC_START() >= START_FROM() || QDesign.NULL(START_FROM()) == QDesign.NULL(0d)) && 
                (F020_DOCTOR_MSTR_DOC_DATE_FAC_START() <= START_TO() || QDesign.NULL(START_TO()) == QDesign.NULL(0d)) && 
                (QDesign.NULL(F020_DOCTOR_MSTR_DOC_DATE_FAC_TERM()) == QDesign.NULL(0d))) || 
                ((QDesign.NULL(F020_DOCTOR_MSTR_DOC_DATE_FAC_START()) != QDesign.NULL(0d)) && 
                (F020_DOCTOR_MSTR_DOC_DATE_FAC_TERM() >= TERM_FROM() || QDesign.NULL(TERM_FROM()) == QDesign.NULL(0d)) && 
                (F020_DOCTOR_MSTR_DOC_DATE_FAC_TERM() <= TERM_TO() || QDesign.NULL(TERM_TO()) == QDesign.NULL(0d)))))
            {
                blnSelected = true;
            }
        
            return blnSelected;
        }
    
        private decimal START_FROM()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = QDesign.NConvert(ReportFunctions.astrScreenParameters[0].ToString());
                //  Prompt String: "ENTER START FROM DATE (YYYYMMDD) OR `0` FOR ALL: " _
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return decReturnValue;
        }
    
        private decimal START_TO()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = QDesign.NConvert(ReportFunctions.astrScreenParameters[1].ToString());
                //  Prompt String: "ENTER START TO   DATE (YYYYMMDD) OR `0` FOR ALL: " _
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return decReturnValue;
        }
    
        private decimal TERM_FROM()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = QDesign.NConvert(ReportFunctions.astrScreenParameters[2].ToString());
                //  Prompt String: "ENTER TERM  FROM DATE (YYYYMMDD) OR `0` FOR ALL: " _
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return decReturnValue;
        }
    
        private decimal TERM_TO()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = QDesign.NConvert(ReportFunctions.astrScreenParameters[3].ToString());
                //  Prompt String: "ENTER TERM  TO   DATE (YYYYMMDD) OR `0` FOR ALL: " _
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
                if ((ReportFunctions.astrScreenParameters[4].ToString().Trim() != string.Empty)) {
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
    
        private decimal X_DEPT()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((ReportFunctions.astrScreenParameters[5].ToString().Trim() != string.Empty)) {
                    decReturnValue = Decimal.Parse(ReportFunctions.astrScreenParameters[5].ToString());
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
                if ((ReportFunctions.astrScreenParameters[6].ToString().Trim() != string.Empty)) {
                    decReturnValue = Decimal.Parse(ReportFunctions.astrScreenParameters[6].ToString());
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
                strReturnValue = QDesign.Pack(rdrF020_DOCTOR_MSTR.GetString("DOC_NAME") + " " + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT1") + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT2") + rdrF020_DOCTOR_MSTR.GetString("DOC_INIT3"));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return strReturnValue;
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
        private decimal PREV_DOC_DEPT = 0;
        private decimal PREV_DOC_OHIP_NBR = 0;
        private decimal PREV_DOC_SPEC_CD = 0;
        private decimal PREV_DOC_DATE_FAC_START = 0;
        private decimal PREV_DOC_DATE_FAC_TERM = 0;
        private decimal PREV_DOC_SPEC_CD_2 = 0;

        private string PREV_DOC_NBR = string.Empty;
        private string PREV_X_NAME = string.Empty;
        private string PREV_DOC_FULL_PART_IND = string.Empty;
        private string PREV_DOC_SUB_SPECIALTY = string.Empty;

        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.REPORT, "INDEXED.F020C_DOC_CLINIC_NEXT_BATCH_NBR.DOC_CLINIC_NBR", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "INDEXED.F020_DOCTOR_MSTR.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "X_NAME", DataTypes.Character, 24);
                AddControl(ReportSection.REPORT, "INDEXED.F020_DOCTOR_MSTR.DOC_OHIP_NBR", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "INDEXED.F020_DOCTOR_MSTR.DOC_SPEC_CD", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "INDEXED.F020_DOCTOR_MSTR.DOC_FULL_PART_IND", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "DOC_DATE_FAC_START", DataTypes.Numeric, 8);
                AddControl(ReportSection.REPORT, "DOC_DATE_FAC_TERM", DataTypes.Numeric, 8);
                AddControl(ReportSection.REPORT, "INDEXED.F020_DOCTOR_MSTR.DOC_SUB_SPECIALTY", DataTypes.Character, 15);
                AddControl(ReportSection.REPORT, "INDEXED.F020_DOCTOR_MSTR.DOC_SPEC_CD_2", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "DOC_CLINIC_NBR_2", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "DOC_CLINIC_NBR_3", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "DOC_CLINIC_NBR_4", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "DOC_CLINIC_NBR_5", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "DOC_CLINIC_NBR_6", DataTypes.Numeric, 2);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
    
        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-07-30 10:52:25 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "INDEXED.F020C_DOC_CLINIC_NEXT_BATCH_NBR.DOC_CLINIC_NBR":
                    return PREV_DOC_CLINIC_NBR.ToString();

                case "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT":
                    return PREV_DOC_DEPT.ToString();

                case "INDEXED.F020_DOCTOR_MSTR.DOC_NBR":
                    return Common.StringToField(PREV_DOC_NBR);

                case "X_NAME":
                    return Common.StringToField(QDesign.Substring(PREV_X_NAME,1,24));

                case "INDEXED.F020_DOCTOR_MSTR.DOC_OHIP_NBR":
                    return PREV_DOC_OHIP_NBR.ToString();

                case "INDEXED.F020_DOCTOR_MSTR.DOC_SPEC_CD":
                    return PREV_DOC_SPEC_CD.ToString();

                case "INDEXED.F020_DOCTOR_MSTR.DOC_FULL_PART_IND":
                    return Common.StringToField(PREV_DOC_FULL_PART_IND);

                case "DOC_DATE_FAC_START":
                    return PREV_DOC_DATE_FAC_START.ToString();

                case "DOC_DATE_FAC_TERM":
                    return PREV_DOC_DATE_FAC_TERM.ToString();

                case "INDEXED.F020_DOCTOR_MSTR.DOC_SUB_SPECIALTY":
                    return Common.StringToField(PREV_DOC_SUB_SPECIALTY);

                case "INDEXED.F020_DOCTOR_MSTR.DOC_SPEC_CD_2":
                    return PREV_DOC_SPEC_CD_2.ToString();

                case "DOC_CLINIC_NBR_2":
                    return PREV_DOC_CLINIC_NBR_2.ToString();

                case "DOC_CLINIC_NBR_3":
                    return PREV_DOC_CLINIC_NBR_3.ToString();

                case "DOC_CLINIC_NBR_4":
                    return PREV_DOC_CLINIC_NBR_4.ToString();

                case "DOC_CLINIC_NBR_5":
                    return PREV_DOC_CLINIC_NBR_5.ToString();

                case "DOC_CLINIC_NBR_6":
                    return PREV_DOC_CLINIC_NBR_6.ToString();

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

                        PREV_DOC_DEPT = rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT");
                        PREV_DOC_NBR = rdrF020_DOCTOR_MSTR.GetString("DOC_NBR");
                        PREV_X_NAME = X_NAME();
                        PREV_DOC_OHIP_NBR = rdrF020_DOCTOR_MSTR.GetNumber("DOC_OHIP_NBR");
                        PREV_DOC_SPEC_CD = rdrF020_DOCTOR_MSTR.GetNumber("DOC_SPEC_CD");
                        PREV_DOC_FULL_PART_IND = rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND");
                        PREV_DOC_DATE_FAC_START = F020_DOCTOR_MSTR_DOC_DATE_FAC_START();
                        PREV_DOC_DATE_FAC_TERM = F020_DOCTOR_MSTR_DOC_DATE_FAC_TERM();
                        PREV_DOC_SUB_SPECIALTY = rdrF020_DOCTOR_MSTR.GetString("DOC_SUB_SPECIALTY");
                        PREV_DOC_SPEC_CD_2 = rdrF020_DOCTOR_MSTR.GetNumber("DOC_SPEC_CD_2");
                    }
                    else
                    {
                        PREV_DOC_DEPT = rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT");
                        PREV_DOC_NBR = rdrF020_DOCTOR_MSTR.GetString("DOC_NBR");
                        PREV_X_NAME = X_NAME();
                        PREV_DOC_OHIP_NBR = rdrF020_DOCTOR_MSTR.GetNumber("DOC_OHIP_NBR");
                        PREV_DOC_SPEC_CD = rdrF020_DOCTOR_MSTR.GetNumber("DOC_SPEC_CD");
                        PREV_DOC_FULL_PART_IND = rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND");
                        PREV_DOC_DATE_FAC_START = F020_DOCTOR_MSTR_DOC_DATE_FAC_START();
                        PREV_DOC_DATE_FAC_TERM = F020_DOCTOR_MSTR_DOC_DATE_FAC_TERM();
                        PREV_DOC_SUB_SPECIALTY = rdrF020_DOCTOR_MSTR.GetString("DOC_SUB_SPECIALTY");
                        PREV_DOC_SPEC_CD_2 = rdrF020_DOCTOR_MSTR.GetNumber("DOC_SPEC_CD_2");
                    }

                    Link_F020C_DOC_CLINIC_NEXT_BATCH_NBR();
                    while (rdrF020C_DOC_CLINIC_NEXT_BATCH_NBR.Read())
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
        }
    }
}
