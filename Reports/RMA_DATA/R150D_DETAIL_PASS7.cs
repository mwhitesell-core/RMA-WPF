//  r150d.qzs
//  2001/jan/19     yas - create text file to upload to excel
//  2004/jan/20    Yasemin - add hahso, moh, rmapen, afpsti, inter, penpay,feecor
//  2006/feb/01    Yasemin - add new 12 
//  2007/jan/18    Yasemin - add new 8
//  2007/jun/20    yasemin - added spepay leacon uninsu covchu pace 
//  2008/jan/16    yasemin - added advanc ahsc weekend shn equpay
//  2009/jan/15    yasemin - added 21 new codes retcli to depmed 
//  2010/jan/15    yasemin - added titdef cppded prebon spepre shadow abcsta mansur
//  2011/jan/10    yasemin - added  exetax afthou diabet hghcon gstrej pathol guaran
//  2011/jan/11    yasemin - move payeft to last column as per Mary                 
//  2011/nov/11    yasemin - added pda mrp ucaf wsib admin nucchr                   
//  2012/jan/04    yasemin - added newpat                                           
//  2012/jan/05    yasemin - Report department company                              
//  2013/Jan/14    yasemin - added  BLEFEE take out PERC as per Mary
//  2014/Jan/21    yasemin - added  AGEP BASE MICA MISC0 MOHD OUTPRO               
//  2014/May/16    yasemin - added  pyrfee pyrhst webhst bridge topoff blepre travel     
//  2014/Jan/08    yasemin - added  perc  AND made the size 1 bigger  for t-net-afp                          
//  2015/Feb/13    yasemin - added  malpra                                                                   
//  2016/Jan/08    yasemin - added  MICC GARNIS MANPAY

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
    public class R150D_DETAIL__PASS7 : BaseRDLClass
    {
        protected const string REPORT_NAME = "R150D_DETAIL__PASS7";
        protected const bool REPORT_HAS_PARAMETERS = false;

        private Reader rdrR150A = new Reader();
        private Reader rdrF020_DOCTOR_MSTR = new Reader();
        private Reader rdrF070_DEPT_MSTR = new Reader();

        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                //  Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;
                Sort = "DOC_NAME ASC, DOC_INITS ASC, DOC_NBR ASC";
                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return ReportData;
        }

        private void Access_R150A()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            // TODO: If * is not used to select all columns, ensure the necessary columns (i.e. columns that are used to access records of other tables) are included in the SELECT statement
            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("T_NET_ADVANC, ");
            strSQL.Append("T_NET_AHSC, ");
            strSQL.Append("T_NET_WEEKEN, ");
            strSQL.Append("T_NET_SHN, ");
            strSQL.Append("T_NET_EQUPAY, ");
            strSQL.Append("T_NET_RETCLI, ");
            strSQL.Append("T_NET_SERREC, ");
            strSQL.Append("T_NET_EDUCON, ");
            strSQL.Append("T_NET_NEUSRF, ");
            strSQL.Append("T_NET_LABPAY, ");
            strSQL.Append("T_NET_REJECT, ");
            strSQL.Append("T_NET_AFPBON, ");
            strSQL.Append("T_NET_RESSUP, ");
            strSQL.Append("T_NET_RECRUI, ");
            strSQL.Append("T_NET_CLIREP, ");
            strSQL.Append("T_NET_HOCC, ");
            strSQL.Append("T_NET_FLOTHR, ");
            strSQL.Append("T_NET_MOROVE ");
            strSQL.Append("FROM TEMPORARYDATA.R150A ");

            strSQL.Append(Choose());

            rdrR150A.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
            strSQL = null;
        }
        private void Link_F020_DOCTOR_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NAME, ");
            strSQL.Append("DOC_INIT1, ");
            strSQL.Append("DOC_INIT2, ");
            strSQL.Append("DOC_INIT3, ");
            strSQL.Append("DOC_DEPT ");
            strSQL.Append("FROM INDEXED.F020_DOCTOR_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_NBR = ").Append(Common.StringToField(rdrR150A.GetString("DOC_NBR")));

            rdrF020_DOCTOR_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        private void Link_F070_DEPT_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            strSQL.Append("SELECT ");
            strSQL.Append("DEPT_NBR ");
            strSQL.Append("FROM [101C].INDEXED.F070_DEPT_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DEPT_NBR = ").Append(rdrF020_DOCTOR_MSTR.GetNumber("DOC_DEPT"));

            rdrF070_DEPT_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(String.Empty);
            return strChoose.ToString().ToString();
        }

        private string X_COMMA()
        {
            string strReturnValue = String.Empty;
            try
            {
                strReturnValue = "~";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string F020_DOCTOR_MSTR_DOC_INITS()
        {
            string strReturnValue = String.Empty;
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
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R150A.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "X_COMMA", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "INDEXED.F020_DOCTOR_MSTR.DOC_NAME", DataTypes.Character, 24);
                AddControl(ReportSection.REPORT, "DOC_INITS", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R150A.T_NET_ADVANC", DataTypes.Numeric, 21);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R150A.T_NET_AHSC", DataTypes.Numeric, 21);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R150A.T_NET_WEEKEN", DataTypes.Numeric, 21);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R150A.T_NET_SHN", DataTypes.Numeric, 21);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R150A.T_NET_EQUPAY", DataTypes.Numeric, 21);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R150A.T_NET_RETCLI", DataTypes.Numeric, 21);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R150A.T_NET_SERREC", DataTypes.Numeric, 21);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R150A.T_NET_EDUCON", DataTypes.Numeric, 21);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R150A.T_NET_NEUSRF", DataTypes.Numeric, 21);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R150A.T_NET_LABPAY", DataTypes.Numeric, 21);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R150A.T_NET_REJECT", DataTypes.Numeric, 21);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R150A.T_NET_AFPBON", DataTypes.Numeric, 21);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R150A.T_NET_RESSUP", DataTypes.Numeric, 21);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R150A.T_NET_RECRUI", DataTypes.Numeric, 21);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R150A.T_NET_CLIREP", DataTypes.Numeric, 21);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R150A.T_NET_HOCC", DataTypes.Numeric, 21);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R150A.T_NET_FLOTHR", DataTypes.Numeric, 21);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R150A.T_NET_MOROVE", DataTypes.Numeric, 21);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2019-07-23 2:20:45 PM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "TEMPORARYDATA.R150A.DOC_NBR":
                    return Common.StringToField(rdrR150A.GetString("DOC_NBR"));
                case "X_COMMA":
                    return Common.StringToField(X_COMMA(), intSize);
                case "INDEXED.F020_DOCTOR_MSTR.DOC_NAME":
                    return Common.StringToField(rdrF020_DOCTOR_MSTR.GetString("DOC_NAME"));
                case "DOC_INITS":
                    return Common.StringToField(F020_DOCTOR_MSTR_DOC_INITS(), intSize);
                case "TEMPORARYDATA.R150A.T_NET_ADVANC":
                    return rdrR150A.GetNumber("T_NET_ADVANC").ToString();
                case "TEMPORARYDATA.R150A.T_NET_AHSC":
                    return rdrR150A.GetNumber("T_NET_AHSC").ToString();
                case "TEMPORARYDATA.R150A.T_NET_WEEKEN":
                    return rdrR150A.GetNumber("T_NET_WEEKEN").ToString();
                case "TEMPORARYDATA.R150A.T_NET_SHN":
                    return rdrR150A.GetNumber("T_NET_SHN").ToString();
                case "TEMPORARYDATA.R150A.T_NET_EQUPAY":
                    return rdrR150A.GetNumber("T_NET_EQUPAY").ToString();
                case "TEMPORARYDATA.R150A.T_NET_RETCLI":
                    return rdrR150A.GetNumber("T_NET_RETCLI").ToString();
                case "TEMPORARYDATA.R150A.T_NET_SERREC":
                    return rdrR150A.GetNumber("T_NET_SERREC").ToString();
                case "TEMPORARYDATA.R150A.T_NET_EDUCON":
                    return rdrR150A.GetNumber("T_NET_EDUCON").ToString();
                case "TEMPORARYDATA.R150A.T_NET_NEUSRF":
                    return rdrR150A.GetNumber("T_NET_NEUSRF").ToString();
                case "TEMPORARYDATA.R150A.T_NET_LABPAY":
                    return rdrR150A.GetNumber("T_NET_LABPAY").ToString();
                case "TEMPORARYDATA.R150A.T_NET_REJECT":
                    return rdrR150A.GetNumber("T_NET_REJECT").ToString();
                case "TEMPORARYDATA.R150A.T_NET_AFPBON":
                    return rdrR150A.GetNumber("T_NET_AFPBON").ToString();
                case "TEMPORARYDATA.R150A.T_NET_RESSUP":
                    return rdrR150A.GetNumber("T_NET_RESSUP").ToString();
                case "TEMPORARYDATA.R150A.T_NET_RECRUI":
                    return rdrR150A.GetNumber("T_NET_RECRUI").ToString();
                case "TEMPORARYDATA.R150A.T_NET_CLIREP":
                    return rdrR150A.GetNumber("T_NET_CLIREP").ToString();
                case "TEMPORARYDATA.R150A.T_NET_HOCC":
                    return rdrR150A.GetNumber("T_NET_HOCC").ToString();
                case "TEMPORARYDATA.R150A.T_NET_FLOTHR":
                    return rdrR150A.GetNumber("T_NET_FLOTHR").ToString();
                case "TEMPORARYDATA.R150A.T_NET_MOROVE":
                    return rdrR150A.GetNumber("T_NET_MOROVE").ToString();
                default:
                    return String.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_R150A();
                while (rdrR150A.Read())
                {
                    Link_F020_DOCTOR_MSTR();
                    while (rdrF020_DOCTOR_MSTR.Read())
                    {
                        Link_F070_DEPT_MSTR();
                        while (rdrF070_DEPT_MSTR.Read())
                        {
                            WriteData();
                        }
                        rdrF070_DEPT_MSTR.Close();
                    }
                    rdrF020_DOCTOR_MSTR.Close();
                }
                rdrR150A.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if (!(rdrR150A == null))
            {
                rdrR150A.Close();
                rdrR150A = null;
            }

            if (!(rdrF020_DOCTOR_MSTR == null))
            {
                rdrF020_DOCTOR_MSTR.Close();
                rdrF020_DOCTOR_MSTR = null;
            }

            if (!(rdrF070_DEPT_MSTR == null))
            {
                rdrF070_DEPT_MSTR.Close();
                rdrF070_DEPT_MSTR = null;
            }
        }
    }
}
