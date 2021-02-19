//  DOC:   REPORT CHANGE OF PATIENT INFORMATION TO MCMASTER AND CHEDOKE
//  HOSPITALS
//  93/04/25 AGK       SMS 141 (ORIGINAL)
//  93/04/20 YB   MODIFY
//  93/10/05 YB   MODIFY EXT.
//  93/11/29 YB   MODIFY HEADING
//  95/01/12 YB   MODIFY HEADING
//  03/10/03 MC   concatenate the address lines
//  05/07/21 YB   modify address lines           
//  05/11/03 YB   modify address lines           
//  06/11/17 YB   modify address lines           
//  07/05/03 YB   modify heading addres and name of new mail to
//  12/03/08        YB        modify heading addres and name of new mail to
//  15/06/02        YB        modify heading name change to Janielle MacDonald
//  15/09/03        YB        modify heading name change to Carly Rotstein
//  17/04/07        YB        change name to  RMA Eligibility Clerk  and ext 22240`
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
    public class R088 : BaseRDLClass
    {
        protected const string REPORT_NAME = "R088";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrF086_PAT_ID = new Reader();
        private Reader rdrREJECTED_CLAIMS = new Reader();
        private Reader rdrF010_PAT_MSTR = new Reader();
        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                //  Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;
                Sort = "PAT_OLD_SURNAME ASC, CLMHDR_PAT_OHIP_ID_OR_CHART ASC";
                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return ReportData;
        }
        private void Access_F086_PAT_ID()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("CLMHDR_PAT_OHIP_ID_OR_CHART, ");
            strSQL.Append("PAT_OLD_SURNAME, ");
            strSQL.Append("PAT_OLD_GIVEN_NAME, ");
            strSQL.Append("PAT_OLD_ADDR1, ");
            strSQL.Append("PAT_OLD_ADDR2, ");
            strSQL.Append("PAT_OLD_ADDR3, ");
            strSQL.Append("PAT_OLD_CHART_NBR, ");
            strSQL.Append("PAT_OLD_HEALTH_NBR, ");
            strSQL.Append("PAT_LAST_VERSION_CD, ");
            strSQL.Append("PAT_LAST_BIRTH_DATE ");
            strSQL.Append("FROM INDEXED.F086_PAT_ID ");

            strSQL.Append(Choose());

            rdrF086_PAT_ID.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_REJECTED_CLAIMS()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("CLMHDR_PAT_OHIP_ID_OR_CHART, ");
            strSQL.Append("CLMHDR_LOC ");
            strSQL.Append("FROM INDEXED.REJECTED_CLAIMS ");
            strSQL.Append("WHERE ");
            strSQL.Append("CLMHDR_PAT_OHIP_ID_OR_CHART = ").Append(Common.StringToField(rdrF086_PAT_ID.GetString("CLMHDR_PAT_OHIP_ID_OR_CHART")));

            rdrREJECTED_CLAIMS.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_F010_PAT_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("PAT_I_KEY, ");
            strSQL.Append("PAT_CON_NBR, ");
            strSQL.Append("PAT_I_NBR, ");
            strSQL.Append("FILLER4, ");
            strSQL.Append("PAT_GIVEN_NAME_FIRST1, ");
            strSQL.Append("FILLER3, ");
            strSQL.Append("PAT_SURNAME_FIRST3, ");
            strSQL.Append("PAT_SURNAME_LAST22, ");
            strSQL.Append("SUBSCR_ADDR1, ");
            strSQL.Append("SUBSCR_ADDR2, ");
            strSQL.Append("SUBSCR_ADDR3, ");
            strSQL.Append("PAT_CHART_NBR, ");
            strSQL.Append("PAT_HEALTH_NBR, ");
            strSQL.Append("PAT_VERSION_CD, ");
            strSQL.Append("PAT_BIRTH_DATE_YY, ");
            strSQL.Append("PAT_BIRTH_DATE_MM, ");
            strSQL.Append("PAT_BIRTH_DATE_DD ");
            strSQL.Append("FROM INDEXED.F010_PAT_MSTR ");
            strSQL.Append("WHERE ");
            //strSQL.Append("KEY_PAT_MSTR = ").Append(Common.StringToField(rdrF086_PAT_ID.GetString("CLMHDR_PAT_OHIP_ID_OR_CHART")));
            strSQL.Append("PAT_I_KEY = ").Append(Common.StringToField(QDesign.Substring(rdrREJECTED_CLAIMS.GetString("CLMHDR_PAT_OHIP_ID_OR_CHART"), 1, 1)));
            strSQL.Append(" AND PAT_CON_NBR = ").Append(QDesign.NConvert(QDesign.Substring(rdrREJECTED_CLAIMS.GetString("CLMHDR_PAT_OHIP_ID_OR_CHART"), 2, 2)));
            strSQL.Append(" AND PAT_I_NBR = ").Append(QDesign.NConvert(QDesign.Substring(rdrREJECTED_CLAIMS.GetString("CLMHDR_PAT_OHIP_ID_OR_CHART"), 4, 12)));
            strSQL.Append(" AND FILLER4 = ").Append(Common.StringToField(QDesign.Substring(rdrREJECTED_CLAIMS.GetString("CLMHDR_PAT_OHIP_ID_OR_CHART"), 16, 1)));

            rdrF010_PAT_MSTR.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
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
            if (((QDesign.NULL(QDesign.Substring(rdrREJECTED_CLAIMS.GetString("CLMHDR_LOC"), 1, 1)) == "M") 
                        || (QDesign.NULL(QDesign.Substring(rdrREJECTED_CLAIMS.GetString("CLMHDR_LOC"), 1, 1)) == "C")))
            {
                blnSelected = true;
            }
        
            return blnSelected;
        }
    
        private string D_OLD_NAME()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = QDesign.Pack((rdrF086_PAT_ID.GetString("PAT_OLD_GIVEN_NAME") + (" " + rdrF086_PAT_ID.GetString("PAT_OLD_SURNAME"))));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return strReturnValue;
        }
    
        private string D_NEW_NAME()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = QDesign.Pack((D_NEW_GIVEN_NAME() + (" " + D_NEW_SURNAME())));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return strReturnValue;
        }
    
        private string D_OLD_ADDR()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = QDesign.Pack((rdrF086_PAT_ID.GetString("PAT_OLD_ADDR1") + (", " 
                                + (rdrF086_PAT_ID.GetString("PAT_OLD_ADDR2") + (", " + rdrF086_PAT_ID.GetString("PAT_OLD_ADDR3"))))));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return strReturnValue;
        }
    
        private string D_NEW_ADDR()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = QDesign.Pack((rdrF010_PAT_MSTR.GetString("SUBSCR_ADDR1") + (", " 
                                + (rdrF010_PAT_MSTR.GetString("SUBSCR_ADDR2") + (", " + rdrF010_PAT_MSTR.GetString("SUBSCR_ADDR3"))))));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return strReturnValue;
        }
    
        private decimal F010_PAT_MSTR_PAT_BIRTH_DATE()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = QDesign.NConvert(QDesign.ASCII(rdrF010_PAT_MSTR.GetNumber("PAT_BIRTH_DATE_YY")) + QDesign.ASCII(rdrF010_PAT_MSTR.GetNumber("PAT_BIRTH_DATE_MM")).PadLeft(2, '0') + QDesign.ASCII(rdrF010_PAT_MSTR.GetNumber("PAT_BIRTH_DATE_DD")).PadLeft(2, '0'));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        
            return decReturnValue;
        }

        private string D_NEW_GIVEN_NAME()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = rdrF010_PAT_MSTR.GetString("PAT_GIVEN_NAME_FIRST1") + rdrF010_PAT_MSTR.GetString("FILLER3");
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string D_NEW_SURNAME()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = rdrF010_PAT_MSTR.GetString("PAT_SURNAME_FIRST3") + rdrF010_PAT_MSTR.GetString("PAT_SURNAME_LAST22");
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
                 AddControl(ReportSection.FOOTING_AT, "D_OLD_NAME", DataTypes.Character, 23);
                 AddControl(ReportSection.FOOTING_AT, "INDEXED.F086_PAT_ID.PAT_OLD_CHART_NBR", DataTypes.Character, 10);
                 AddControl(ReportSection.FOOTING_AT, "INDEXED.F086_PAT_ID.PAT_OLD_HEALTH_NBR", DataTypes.Numeric, 10);
                 AddControl(ReportSection.FOOTING_AT, "INDEXED.F086_PAT_ID.PAT_LAST_VERSION_CD", DataTypes.Character, 2);
                 AddControl(ReportSection.FOOTING_AT, "INDEXED.F086_PAT_ID.PAT_LAST_BIRTH_DATE", DataTypes.Numeric, 8);
                 AddControl(ReportSection.FOOTING_AT, "D_OLD_ADDR", DataTypes.Character, 65);
                 AddControl(ReportSection.FOOTING_AT, "D_NEW_NAME", DataTypes.Character, 23);
                 AddControl(ReportSection.FOOTING_AT, "INDEXED.F010_PAT_MSTR.PAT_CHART_NBR", DataTypes.Character, 10);
                 AddControl(ReportSection.FOOTING_AT, "INDEXED.F010_PAT_MSTR.PAT_HEALTH_NBR", DataTypes.Numeric, 10);
                 AddControl(ReportSection.FOOTING_AT, "INDEXED.F010_PAT_MSTR.PAT_VERSION_CD", DataTypes.Character, 2);
                 AddControl(ReportSection.FOOTING_AT, "PAT_BIRTH_DATE", DataTypes.Numeric, 8);
                 AddControl(ReportSection.FOOTING_AT, "D_NEW_ADDR", DataTypes.Character, 65);
                 AddControl(ReportSection.REPORT, "INDEXED.F086_PAT_ID.PAT_OLD_SURNAME", DataTypes.Character, 15);
                 AddControl(ReportSection.REPORT, "INDEXED.F086_PAT_ID.CLMHDR_PAT_OHIP_ID_OR_CHART", DataTypes.Character, 16);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
    
        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-05-14 10:20:16 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "D_OLD_NAME":
                    return Common.StringToField(D_OLD_NAME(), intSize);

                case "INDEXED.F086_PAT_ID.PAT_OLD_CHART_NBR":
                    return Common.StringToField(rdrF086_PAT_ID.GetString("PAT_OLD_CHART_NBR"));

                case "INDEXED.F086_PAT_ID.PAT_OLD_HEALTH_NBR":
                    return rdrF086_PAT_ID.GetNumber("PAT_OLD_HEALTH_NBR").ToString();

                case "INDEXED.F086_PAT_ID.PAT_LAST_VERSION_CD":
                    return Common.StringToField(rdrF086_PAT_ID.GetString("PAT_LAST_VERSION_CD"));

                case "INDEXED.F086_PAT_ID.PAT_LAST_BIRTH_DATE":
                    return rdrF086_PAT_ID.GetNumber("PAT_LAST_BIRTH_DATE").ToString();

                case "D_OLD_ADDR":
                    return Common.StringToField(D_OLD_ADDR(), intSize);

                case "D_NEW_NAME":
                    return Common.StringToField(D_NEW_NAME(), intSize);

                case "INDEXED.F010_PAT_MSTR.PAT_CHART_NBR":
                    return Common.StringToField(rdrF010_PAT_MSTR.GetString("PAT_CHART_NBR"));

                case "INDEXED.F010_PAT_MSTR.PAT_HEALTH_NBR":
                    return rdrF010_PAT_MSTR.GetNumber("PAT_HEALTH_NBR").ToString();

                case "INDEXED.F010_PAT_MSTR.PAT_VERSION_CD":
                    return Common.StringToField(rdrF010_PAT_MSTR.GetString("PAT_VERSION_CD"));

                case "PAT_BIRTH_DATE":
                    return Common.StringToField(F010_PAT_MSTR_PAT_BIRTH_DATE().ToString());

                case "D_NEW_ADDR":
                    return Common.StringToField(D_NEW_ADDR(), intSize);

                case "INDEXED.F086_PAT_ID.PAT_OLD_SURNAME":
                    return Common.StringToField(rdrF086_PAT_ID.GetString("PAT_OLD_SURNAME"));

                case "INDEXED.F086_PAT_ID.CLMHDR_PAT_OHIP_ID_OR_CHART":
                    return Common.StringToField(rdrF086_PAT_ID.GetString("CLMHDR_PAT_OHIP_ID_OR_CHART"));

                default:
                    return string.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                Access_F086_PAT_ID();
                while (rdrF086_PAT_ID.Read())
                {
                    Link_REJECTED_CLAIMS();
                    while (rdrREJECTED_CLAIMS.Read())
                    {
                        Link_F010_PAT_MSTR();
                        while (rdrF010_PAT_MSTR.Read())
                        {
                            WriteData();
                        }
                        rdrF010_PAT_MSTR.Close();
                    }
                    rdrREJECTED_CLAIMS.Close();
                }
                rdrF086_PAT_ID.Close();
            }
            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrF086_PAT_ID == null))
            {
                rdrF086_PAT_ID.Close();
                rdrF086_PAT_ID = null;
            }
        
            if (!(rdrREJECTED_CLAIMS == null))
            {
                rdrREJECTED_CLAIMS.Close();
                rdrREJECTED_CLAIMS = null;
            }
        
            if (!(rdrF010_PAT_MSTR == null))
            {
                rdrF010_PAT_MSTR.Close();
                rdrF010_PAT_MSTR = null;
            }
        }
    }
}
