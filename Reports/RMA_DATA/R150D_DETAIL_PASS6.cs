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
    public class R150D_DETAIL__PASS6 : BaseRDLClass
    {
        protected const string REPORT_NAME = "R150D_DETAIL__PASS6";
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
            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("T_NET_PCN, ");
            strSQL.Append("T_NET_AFPFUN, ");
            strSQL.Append("T_NET_BOAHUN, ");
            strSQL.Append("T_NET_CANCEL, ");
            strSQL.Append("T_NET_CEIADV, ");
            strSQL.Append("T_NET_COMPCA, ");
            strSQL.Append("T_NET_EXEHON, ");
            strSQL.Append("T_NET_LTDDED, ");
            strSQL.Append("T_NET_ACAINC, ");
            strSQL.Append("T_NET_STIPEN, ");
            strSQL.Append("T_NET_RETRO, ");
            strSQL.Append("T_NET_DEPCHR, ");
            strSQL.Append("T_NET_OVPAY, ");
            strSQL.Append("T_NET_PACE, ");
            strSQL.Append("T_NET_UNINSU, ");
            strSQL.Append("T_NET_COVCHU, ");
            strSQL.Append("T_NET_LEACON, ");
            strSQL.Append("T_NET_SPEPAY ");
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
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R150A.T_NET_PCN", DataTypes.Numeric, 21);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R150A.T_NET_AFPFUN", DataTypes.Numeric, 21);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R150A.T_NET_BOAHON", DataTypes.Numeric, 21);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R150A.T_NET_CANCEL", DataTypes.Numeric, 21);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R150A.T_NET_CEIADV", DataTypes.Numeric, 21);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R150A.T_NET_COMPCA", DataTypes.Numeric, 21);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R150A.T_NET_EXEHON", DataTypes.Numeric, 21);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R150A.T_NET_LTDDED", DataTypes.Numeric, 21);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R150A.T_NET_ACAINC", DataTypes.Numeric, 21);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R150A.T_NET_STIPEN", DataTypes.Numeric, 21);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R150A.T_NET_RETRO", DataTypes.Numeric, 21);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R150A.T_NET_DEPCHR", DataTypes.Numeric, 21);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R150A.T_NET_OVPAY", DataTypes.Numeric, 21);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R150A.T_NET_PACE", DataTypes.Numeric, 21);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R150A.T_NET_UNINSU", DataTypes.Numeric, 21);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R150A.T_NET_COVCHU", DataTypes.Numeric, 21);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R150A.T_NET_LEACON", DataTypes.Numeric, 21);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R150A.T_NET_SPEPAY", DataTypes.Numeric, 21);
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
                case "TEMPORARYDATA.R150A.T_NET_PCN":
                    return rdrR150A.GetNumber("T_NET_PCN").ToString();
                case "TEMPORARYDATA.R150A.T_NET_AFPFUN":
                    return rdrR150A.GetNumber("T_NET_AFPFUN").ToString();
                case "TEMPORARYDATA.R150A.T_NET_BOAHON":
                    return rdrR150A.GetNumber("T_NET_BOAHON").ToString();
                case "TEMPORARYDATA.R150A.T_NET_CANCEL":
                    return rdrR150A.GetNumber("T_NET_CANCEL").ToString();
                case "TEMPORARYDATA.R150A.T_NET_CEIADV":
                    return rdrR150A.GetNumber("T_NET_CEIADV").ToString();
                case "TEMPORARYDATA.R150A.T_NET_COMPCA":
                    return rdrR150A.GetNumber("T_NET_COMPCA").ToString();
                case "TEMPORARYDATA.R150A.T_NET_EXEHON":
                    return rdrR150A.GetNumber("T_NET_EXEHON").ToString();
                case "TEMPORARYDATA.R150A.T_NET_LTDDED":
                    return rdrR150A.GetNumber("T_NET_LTDDED").ToString();
                case "TEMPORARYDATA.R150A.T_NET_ACAINC":
                    return rdrR150A.GetNumber("T_NET_ACAINC").ToString();
                case "TEMPORARYDATA.R150A.T_NET_STIPEN":
                    return rdrR150A.GetNumber("T_NET_STIPEN").ToString();
                case "TEMPORARYDATA.R150A.T_NET_RETRO":
                    return rdrR150A.GetNumber("T_NET_RETRO").ToString();
                case "TEMPORARYDATA.R150A.T_NET_DEPCHR":
                    return rdrR150A.GetNumber("T_NET_DEPCHR").ToString();
                case "TEMPORARYDATA.R150A.T_NET_OVPAY":
                    return rdrR150A.GetNumber("T_NET_OVPAY").ToString();
                case "TEMPORARYDATA.R150A.T_NET_PACE":
                    return rdrR150A.GetNumber("T_NET_PACE").ToString();
                case "TEMPORARYDATA.R150A.T_NET_UNINSU":
                    return rdrR150A.GetNumber("T_NET_UNINSU").ToString();
                case "TEMPORARYDATA.R150A.T_NET_COVCHU":
                    return rdrR150A.GetNumber("T_NET_COVCHU").ToString();
                case "TEMPORARYDATA.R150A.T_NET_LEACON":
                    return rdrR150A.GetNumber("T_NET_LEACON").ToString();
                case "TEMPORARYDATA.R150A.T_NET_SPEPAY":
                    return rdrR150A.GetNumber("T_NET_SPEPAY").ToString();
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
