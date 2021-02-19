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
    public class R150D_DETAIL__PASS2 : BaseRDLClass
    {
        protected const string REPORT_NAME = "R150D_DETAIL__PASS2";
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
            strSQL.Append("T_NET_FAMSUP, ");
            strSQL.Append("T_NET_RMACHR, ");
            strSQL.Append("T_NET_GSTTAX, ");
            strSQL.Append("T_NET_WEB, ");
            strSQL.Append("T_NET_RMAEXR, ");
            strSQL.Append("T_NET_RMAEXM, ");
            strSQL.Append("T_NET_GST, ");
            strSQL.Append("T_NET_DEPEXR, ");
            strSQL.Append("T_NET_DEPEXM, ");
            strSQL.Append("T_NET_SURPLU, ");
            strSQL.Append("T_NET_REBATE, ");
            strSQL.Append("T_NET_GSTREB, ");
            strSQL.Append("T_NET_LIPID, ");
            strSQL.Append("T_NET_ICUCHR, ");
            strSQL.Append("T_NET_ICUGST ");
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
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R150A.T_NET_FAMSUP", DataTypes.Numeric, 21);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R150A.T_NET_RMACHR", DataTypes.Numeric, 21);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R150A.T_NET_GSTTAX", DataTypes.Numeric, 21);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R150A.T_NET_WEB", DataTypes.Numeric, 21);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R150A.T_NET_RMAEXR", DataTypes.Numeric, 21);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R150A.T_NET_RMAEXM", DataTypes.Numeric, 21);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R150A.T_NET_GST", DataTypes.Numeric, 21);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R150A.T_NET_DEPEXR", DataTypes.Numeric, 21);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R150A.T_NET_DEPEXM", DataTypes.Numeric, 21);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R150A.T_NET_SURPLU", DataTypes.Numeric, 21);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R150A.T_NET_REBATE", DataTypes.Numeric, 21);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R150A.T_NET_GSTREB", DataTypes.Numeric, 21);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R150A.T_NET_LIPID", DataTypes.Numeric, 21);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R150A.T_NET_ICUCHR", DataTypes.Numeric, 21);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R150A.T_NET_ICUGST", DataTypes.Numeric, 21);
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
                case "TEMPORARYDATA.R150A.T_NET_FAMSUP":
                    return rdrR150A.GetNumber("T_NET_FAMSUP").ToString();
                case "TEMPORARYDATA.R150A.T_NET_RMACHR":
                    return rdrR150A.GetNumber("T_NET_RMACHR").ToString();
                case "TEMPORARYDATA.R150A.T_NET_GSTTAX":
                    return rdrR150A.GetNumber("T_NET_GSTTAX").ToString();
                case "TEMPORARYDATA.R150A.T_NET_WEB":
                    return rdrR150A.GetNumber("T_NET_WEB").ToString();
                case "TEMPORARYDATA.R150A.T_NET_RMAEXR":
                    return rdrR150A.GetNumber("T_NET_RMAEXR").ToString();
                case "TEMPORARYDATA.R150A.T_NET_RMAEXM":
                    return rdrR150A.GetNumber("T_NET_RMAEXM").ToString();
                case "TEMPORARYDATA.R150A.T_NET_GST":
                    return rdrR150A.GetNumber("T_NET_GST").ToString();
                case "TEMPORARYDATA.R150A.T_NET_DEPEXR":
                    return rdrR150A.GetNumber("T_NET_DEPEXR").ToString();
                case "TEMPORARYDATA.R150A.T_NET_DEPEXM":
                    return rdrR150A.GetNumber("T_NET_DEPEXM").ToString();
                case "TEMPORARYDATA.R150A.T_NET_SURPLU":
                    return rdrR150A.GetNumber("T_NET_SURPLU").ToString();
                case "TEMPORARYDATA.R150A.T_NET_REBATE":
                    return rdrR150A.GetNumber("T_NET_REBATE").ToString();
                case "TEMPORARYDATA.R150A.T_NET_GSTREB":
                    return rdrR150A.GetNumber("T_NET_GSTREB").ToString();
                case "TEMPORARYDATA.R150A.T_NET_LIPID":
                    return rdrR150A.GetNumber("T_NET_LIPID").ToString();
                case "TEMPORARYDATA.R150A.T_NET_ICUCHR":
                    return rdrR150A.GetNumber("T_NET_ICUCHR").ToString();
                case "TEMPORARYDATA.R150A.T_NET_ICUGST":
                    return rdrR150A.GetNumber("T_NET_ICUGST").ToString();
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
