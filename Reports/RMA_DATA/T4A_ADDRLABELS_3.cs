//  t4a_addrlabels_3.qzs
//  CREATE MAILING DOCTOR ADDRESS LABELS
//  RUN FOR: MANAGEMENT/STAFF
//  PROGRAM PURPOSE : MAILING DOCTOR ADDRESS LABELS
//  This phase - output report
//  DATE        WHO       DESCRIPTION
//  2005/feb/09 b.e - split logic into 2 pgms to eliminate duplicate docs
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
    public class T4A_ADDRLABELS_3 : BaseRDLClass
    {
        protected const string REPORT_NAME = "T4A_ADDRLABELS_3";
        protected const bool REPORT_HAS_PARAMETERS = false;

        private Reader rdrT4A_ADDRLABELS_2 = new Reader();
        private Reader rdrF020_DOCTOR_MSTR = new Reader();

        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                //  Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;

                switch (arrParameters[5].ToString())
                {
                    case "1":
                        Sort = "DOC_NBR ASC";
                        break;
                    case "2":
                        Sort = "DOC_NAME ASC, DOC_INITS ASC";
                        break;
                    case "3":
                        Sort = "DOC_DEPT ASC, DOC_NBR ASC";
                        break;
                    case "4":
                        Sort = "DOC_DEPT ASC, DOC_NAME ASC, DOC_INITS ASC";
                        break;
                    case "6":
                        Sort = "DOC_FULL_PART_IND ASC, DOC_NAME ASC, DOC_INITS ASC";
                        break;
                    case "7":
                        Sort = "DOC_DEPT ASC, DOC_FULL_PART_IND ASC, DOC_NBR ASC";
                        break;
                    case "8":
                        Sort = "DOC_DEPT ASC, DOC_FULL_PART_IND ASC, DOC_NAME ASC, DOC_INITS ASC";
                        break;
                    default:
                        Sort = "";
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

        private void Access_T4A_ADDRLABELS_2()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("X_DOCDEPT, ");
            strSQL.Append("X_NAME, ");
            strSQL.Append("X_ADDR_1, ");
            strSQL.Append("X_ADDR_2, ");
            strSQL.Append("X_ADDR_3, ");
            strSQL.Append("X_ADDR_PC_1, ");
            strSQL.Append("X_ADDR_PC_2 ");
            strSQL.Append("FROM TEMPORARYDATA.T4A_ADDRLABELS_2 ");

            strSQL.Append(Choose());

            rdrT4A_ADDRLABELS_2.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
            strSQL = null;
        }

        private void Link_F020_DOCTOR_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NAME, ");
            strSQL.Append("DOC_DEPT, ");
            strSQL.Append("DOC_FULL_PART_IND, ");
            strSQL.Append("DOC_INIT1, ");
            strSQL.Append("DOC_INIT2, ");
            strSQL.Append("DOC_INIT3 ");
            strSQL.Append("FROM INDEXED.F020_DOCTOR_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_NBR = ").Append(Common.StringToField(rdrT4A_ADDRLABELS_2.GetString("DOC_NBR")));

            rdrF020_DOCTOR_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
    
        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(string.Empty);

            return strChoose.ToString();
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
        
        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.T4A_ADDRLABELS_2.X_DOCDEPT", DataTypes.Character, 6);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.T4A_ADDRLABELS_2.X_NAME", DataTypes.Character, 30);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.T4A_ADDRLABELS_2.X_ADDR_1", DataTypes.Character, 30);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.T4A_ADDRLABELS_2.X_ADDR_2", DataTypes.Character, 30);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.T4A_ADDRLABELS_2.X_ADDR_3", DataTypes.Character, 30);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.T4A_ADDRLABELS_2.X_ADDR_PC_1", DataTypes.Character, 6);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.T4A_ADDRLABELS_2.X_ADDR_PC_2", DataTypes.Character, 6);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.T4A_ADDRLABELS_2.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "INDEXED.F020_DOCTOR_MSTR.DOC_NAME", DataTypes.Character, 24);
                AddControl(ReportSection.REPORT, "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "INDEXED.F020_DOCTOR_MSTR.DOC_FULL_PART_IND", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "DOC_INITS", DataTypes.Character, 3);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
    
        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-07-20 11:56:24 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "TEMPORARYDATA.T4A_ADDRLABELS_2.X_DOCDEPT":
                    return Common.StringToField(rdrT4A_ADDRLABELS_2.GetString("X_DOCDEPT"));

                case "TEMPORARYDATA.T4A_ADDRLABELS_2.X_NAME":
                    return Common.StringToField(rdrT4A_ADDRLABELS_2.GetString("X_NAME"));

                case "TEMPORARYDATA.T4A_ADDRLABELS_2.X_ADDR_1":
                    return Common.StringToField(rdrT4A_ADDRLABELS_2.GetString("X_ADDR_1"));

                case "TEMPORARYDATA.T4A_ADDRLABELS_2.X_ADDR_2":
                    return Common.StringToField(rdrT4A_ADDRLABELS_2.GetString("X_ADDR_2"));

                case "TEMPORARYDATA.T4A_ADDRLABELS_2.X_ADDR_3":
                    return Common.StringToField(rdrT4A_ADDRLABELS_2.GetString("X_ADDR_3"));

                case "TEMPORARYDATA.T4A_ADDRLABELS_2.X_ADDR_PC_1":
                    return Common.StringToField(rdrT4A_ADDRLABELS_2.GetString("X_ADDR_PC_1"));

                case "TEMPORARYDATA.T4A_ADDRLABELS_2.X_ADDR_PC_2":
                    return Common.StringToField(rdrT4A_ADDRLABELS_2.GetString("X_ADDR_PC_2"));

                case "TEMPORARYDATA.T4A_ADDRLABELS_2.DOC_NBR":
                    return Common.StringToField(rdrT4A_ADDRLABELS_2.GetString("DOC_NBR"));

                case "INDEXED.F020_DOCTOR_MSTR.DOC_NAME":
                    return Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_NAME"));

                case "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT":
                    return rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT").ToString();

                case "INDEXED.F020_DOCTOR_MSTR.DOC_FULL_PART_IND":
                    return Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_FULL_PART_IND"));

                case "DOC_INITS":
                    return Common.StringToField(DOC_INITS());

                default:
                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_T4A_ADDRLABELS_2();
                while (rdrT4A_ADDRLABELS_2.Read())
                {
                    Link_F020_DOCTOR_MSTR();
                    while (rdrF020_DOCTOR_MSTR.Read())
                    {
                        WriteData();
                    }
                    rdrF020_DOCTOR_MSTR.Close();
                }
                rdrT4A_ADDRLABELS_2.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if (!(rdrT4A_ADDRLABELS_2 == null))
            {
                rdrT4A_ADDRLABELS_2.Close();
                rdrT4A_ADDRLABELS_2 = null;
            }
        
            if (!(rdrF020_DOCTOR_MSTR == null))
            {
                rdrF020_DOCTOR_MSTR.Close();
                rdrF020_DOCTOR_MSTR = null;
            }
        }
    }
}
