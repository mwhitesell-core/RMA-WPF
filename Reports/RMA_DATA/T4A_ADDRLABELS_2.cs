//  t4a_addrlabels_2.qzs
//  CREATE MAILING DOCTOR ADDRESS LABELS
//  RUN FOR: MANAGEMENT/STAFF
//  PROGRAM PURPOSE : MAILING DOCTOR ADDRESS LABELS
//  This Phase - remove duplicate doctors
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
    public class T4A_ADDRLABELS_2 : BaseRDLClass
    {
        protected const string REPORT_NAME = "T4A_ADDRLABELS_2";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrT4A_ADDRLABELS_1 = new Reader();
        private Reader rdrT4A_ADDRLABELS_2 = new Reader();
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
                SubFileName = "T4A_ADDRLABELS_2";
                SubFileType = SubFileType.Keep;
                SubFileAT = "GERIATRIC2.DOC_OHIP_NBR";
                Sort = "DOC_OHIP_NBR ASC";
                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return ReportData;
        }
        private void Access_T4A_ADDRLABELS_1()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_OHIP_NBR, ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("X_DOCDEPT, ");
            strSQL.Append("X_NAME, ");
            strSQL.Append("X_ADDR_1, ");
            strSQL.Append("X_ADDR_2, ");
            strSQL.Append("X_ADDR_3, ");
            strSQL.Append("X_ADDR_PC_1, ");
            strSQL.Append("X_ADDR_PC_2 ");
            strSQL.Append("FROM TEMPORARYDATA.T4A_ADDRLABELS_1 ");

            strSQL.Append(Choose());

            rdrT4A_ADDRLABELS_1.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
            strSQL = null;
        }
    
        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(string.Empty);

            return strChoose.ToString().ToString();
        }
        public override void DeclareReportControls()
        {
            try
            {
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.T4A_ADDRLABELS_1.DOC_NBR", DataTypes.Character, 3);
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.T4A_ADDRLABELS_1.X_DOCDEPT", DataTypes.Character, 6);
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.T4A_ADDRLABELS_1.X_NAME", DataTypes.Character, 30);
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.T4A_ADDRLABELS_1.X_ADDR_1", DataTypes.Character, 30);
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.T4A_ADDRLABELS_1.X_ADDR_2", DataTypes.Character, 30);
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.T4A_ADDRLABELS_1.X_ADDR_3", DataTypes.Character, 30);
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.T4A_ADDRLABELS_1.X_ADDR_PC_1", DataTypes.Character, 6);
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.T4A_ADDRLABELS_1.X_ADDR_PC_2", DataTypes.Character, 6);
                 AddControl(ReportSection.REPORT, "TEMPORARYDATA.T4A_ADDRLABELS_1.DOC_OHIP_NBR", DataTypes.Character, 6);
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
                case "TEMPORARYDATA.T4A_ADDRLABELS_1.DOC_NBR":
                    return Common.StringToField(rdrT4A_ADDRLABELS_1.GetString("DOC_NBR"));

                case "TEMPORARYDATA.T4A_ADDRLABELS_1.X_DOCDEPT":
                    return Common.StringToField(rdrT4A_ADDRLABELS_1.GetString("X_DOCDEPT"));

                case "TEMPORARYDATA.T4A_ADDRLABELS_1.X_NAME":
                    return Common.StringToField(rdrT4A_ADDRLABELS_1.GetString("X_NAME"));

                case "TEMPORARYDATA.T4A_ADDRLABELS_1.X_ADDR_1":
                    return Common.StringToField(rdrT4A_ADDRLABELS_1.GetString("X_ADDR_1"));

                case "TEMPORARYDATA.T4A_ADDRLABELS_1.X_ADDR_2":
                    return Common.StringToField(rdrT4A_ADDRLABELS_1.GetString("X_ADDR_2"));
                case "TEMPORARYDATA.T4A_ADDRLABELS_1.X_ADDR_3":
                    return Common.StringToField(rdrT4A_ADDRLABELS_1.GetString("X_ADDR_3"));

                case "TEMPORARYDATA.T4A_ADDRLABELS_1.X_ADDR_PC_1":
                    return Common.StringToField(rdrT4A_ADDRLABELS_1.GetString("X_ADDR_PC_1"));

                case "TEMPORARYDATA.T4A_ADDRLABELS_1.X_ADDR_PC_2":
                    return Common.StringToField(rdrT4A_ADDRLABELS_1.GetString("X_ADDR_PC_2"));

                case "TEMPORARYDATA.T4A_ADDRLABELS_1.DOC_OHIP_NBR":
                    return Common.StringToField(rdrT4A_ADDRLABELS_1.GetString("DOC_OHIP_NBR"));

                default:
                    return string.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                Access_T4A_ADDRLABELS_1();
                while (rdrT4A_ADDRLABELS_1.Read())
                {
                    WriteData();
                }
            
                rdrT4A_ADDRLABELS_1.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrT4A_ADDRLABELS_1 == null))
            {
                rdrT4A_ADDRLABELS_1.Close();
                rdrT4A_ADDRLABELS_1 = null;
            }
        }
    }
}
