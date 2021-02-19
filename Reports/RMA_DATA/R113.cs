//  MODIFICATION HISTORY
//  2006/may/24          M.C.     - As per Brad`s request, dump out new f113 for
//  user to verify after yearend purge
//  2009/jul/07          M.C.     - Yas only wants to select active doctors
//  2013/Jul/08          MC1  - Mary changed her mind that she wants to see everyone in MP only
//  - Moira suggested to include the termination date since we are showing all doctors
//  2009/07/07 - MC
//  access f113-default-comp 
using Core.DataAccess.SqlServer;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.ReportFramework;
using System;
using System.Data;
using System.Text;

namespace RMA_DATA
{
    public class R113 : BaseRDLClass
    {
        protected const string REPORT_NAME = "R113";
        protected const bool REPORT_HAS_PARAMETERS = false;

        private Reader rdrF113_DEFAULT_COMP = new Reader();
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
        private void Access_F113_DEFAULT_COMP()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("EP_NBR_FROM, ");
            strSQL.Append("COMP_CODE, ");
            strSQL.Append("EP_NBR_TO, ");
            strSQL.Append("AMT_GROSS, ");
            strSQL.Append("AMT_NET, ");
            strSQL.Append("EP_NBR_ENTRY ");
            strSQL.Append("FROM INDEXED.F113_DEFAULT_COMP ");
            strSQL.Append(Choose());
            rdrF113_DEFAULT_COMP.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_F020_DOCTOR_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: Check the 'WHERE' and 'AND' clauses are correct.
            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("DOC_DATE_FAC_TERM_YY, ");
            strSQL.Append(" DOC_DATE_FAC_TERM_MM, ");
            strSQL.Append(" DOC_DATE_FAC_TERM_DD ");
            strSQL.Append("FROM [101C].INDEXED.F020_DOCTOR_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_NBR = ").Append(Common.StringToField(rdrF113_DEFAULT_COMP.GetString("DOC_NBR")));
            rdrF020_DOCTOR_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(String.Empty);
            // TODO: CHOOSE Statement - May require manual changes.
            return strChoose.ToString().ToString();
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
        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.REPORT, "INDEXED.dbo.F113_DEFAULT_COMP.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "INDEXED.dbo.F113_DEFAULT_COMP.EP_NBR_FROM", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "INDEXED.dbo.F113_DEFAULT_COMP.COMP_CODE", DataTypes.Character, 6);
                AddControl(ReportSection.REPORT, "INDEXED.dbo.F113_DEFAULT_COMP.EP_NBR_TO", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "INDEXED.dbo.F113_DEFAULT_COMP.AMT_GROSS", DataTypes.Numeric, 9);
                AddControl(ReportSection.REPORT, "INDEXED.dbo.F113_DEFAULT_COMP.AMT_NET", DataTypes.Numeric, 9);
                AddControl(ReportSection.REPORT, "INDEXED.dbo.F113_DEFAULT_COMP.EP_NBR_ENTRY", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "DOC_DATE_FAC_TERM", DataTypes.Numeric, 8);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2020-02-27 2:29:26 PM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "INDEXED.dbo.F113_DEFAULT_COMP.DOC_NBR":
                    return Common.StringToField(rdrF113_DEFAULT_COMP.GetString("DOC_NBR"));
                case "INDEXED.dbo.F113_DEFAULT_COMP.EP_NBR_FROM":
                    return rdrF113_DEFAULT_COMP.GetNumber("EP_NBR_FROM").ToString();
                case "INDEXED.dbo.F113_DEFAULT_COMP.COMP_CODE":
                    return Common.StringToField(rdrF113_DEFAULT_COMP.GetString("COMP_CODE"));
                case "INDEXED.dbo.F113_DEFAULT_COMP.EP_NBR_TO":
                    return rdrF113_DEFAULT_COMP.GetNumber("EP_NBR_TO").ToString();
                case "INDEXED.dbo.F113_DEFAULT_COMP.AMT_GROSS":
                    return rdrF113_DEFAULT_COMP.GetNumber("AMT_GROSS").ToString();
                case "INDEXED.dbo.F113_DEFAULT_COMP.AMT_NET":
                    return rdrF113_DEFAULT_COMP.GetNumber("AMT_NET").ToString();
                case "INDEXED.dbo.F113_DEFAULT_COMP.EP_NBR_ENTRY":
                    return rdrF113_DEFAULT_COMP.GetNumber("EP_NBR_ENTRY").ToString();
                case "DOC_DATE_FAC_TERM":
                    return F020_DOCTOR_MSTR_DOC_DATE_FAC_TERM().ToString();
                default:
                    return String.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_F113_DEFAULT_COMP();
                while (rdrF113_DEFAULT_COMP.Read())
                {
                    Link_F020_DOCTOR_MSTR();
                    while (rdrF020_DOCTOR_MSTR.Read())
                    {
                        WriteData();
                    }
                    rdrF020_DOCTOR_MSTR.Close();
                }
                rdrF113_DEFAULT_COMP.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if (!(rdrF113_DEFAULT_COMP == null))
            {
                rdrF113_DEFAULT_COMP.Close();
                rdrF113_DEFAULT_COMP = null;
            }

            if (!(rdrF020_DOCTOR_MSTR == null))
            {
                rdrF020_DOCTOR_MSTR.Close();
                rdrF020_DOCTOR_MSTR = null;
            }
        }
    }
}