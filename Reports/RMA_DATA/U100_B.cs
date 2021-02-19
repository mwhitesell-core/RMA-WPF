#region "Screen Comments"

// 2009/may/20  MC1 - link f020-doctor-extra in access
// - include dept, primary flag start & term date paym group
// - change selection criteria
// 2009/06/24    yas     - add heading
// 2009/10/05    MC2 - a new request to report blank doc-paym-group
// 2011/11/29    MC3 - a new request to report doctors have revenue but blank record in f112-pycdceilings
// 2012/11/01    MC4 - a new request to report doctors with special payment but blank record in f112-pycdceilings
// - correct page heading for third request
// 2012/Dec/20   MC5     - pass the payroll flag as part of the selection, payroll A = 101c, payroll C = solo
// 2013/Dec/11   MC6     - change the selection criteria to check up to 1 year before rundate to consider active doctor
// - include if f112 record exists and pay-code = 0 in the selection in the 4th request
// 2014/Feb/11   MC7     - include dept, term date for each section of the report
// - exclude dept 10, 13 & 21 for f114 file which is the last request 
// - separate f114 check into 2 separate passes - one is if no f112 record exists for the doctor,
// two is if f112 records exists for previous ep-nbr but with pay code 0
// 2014/Oct/14   MC8 - comment out the first pass as it has transferred to u100_b.qzs
// 2015/Apr/22   MC9     - add a new request to report missing doctor from f112 file
// 2016/Sep/08   MC10    - when checking f114 file, choose rec-type `A` for solo and `C` for 101c  only 
// for what are displaying on 94 screen
// MC8
// ;access *u100_prim_doc link DOC-OHIP-NBR                    &
// ;                   to DOC-OHIP-NBR of f020-doctor-mstr opt &
// 2009/05/20 - MC1
// ; link doc-nbr to doc-nbr of f020-doctor-extra opt
// 2009/05/20 - end
// 2013/12/11 - MC6
// ;def one-year-before date = sysdate - 10000
// 2013/12/11 - end
// 2009/05/20 - MC1
// sel if doc-count <> 1 and doc-date-fac-term = 0
// ;sel if doc-count <> 1     &
// 2013/12/11 - MC6 - not sure why hard code the date, assuming to select active doctor, let allow 1 year before current rundate
// and    (    doc-date-fac-term > 20080630     &
// ;   and    (    doc-date-fac-term > one-year-before   &
// 2013/12/11 - end
// ;            or doc-date-fac-term = 0  &
// ;          )      &
// ;   and                           &
// 2012/12/20 - MC5 - add the payroll-flag check with selection condition
// ;      (   (    (   (doc-dept = 4)                   &
// ;                or (    (    doc-dept = 14          &
// ;                          or doc-dept = 15          &
// ;                        )                           &
// ;                    and doc-afp-paym-group = `H111` &
// ;                   )                                &
// ;               )                                    &
// ;           and payroll-flag = `A`                   &
// ;          )                                         &
// ;       or (    (    doc-dept = 31                   &
// ;                and doc-afp-paym-group = `H132`     &
// ;               )                                    &
// ;           and payroll-flag = `C`                   &
// ;          )         &
// ;      )
// 2012/12/20 - end
// 2009/05/20 - end
// ;page heading                                    &
// ;tab  1 `U100`     &
// ;tab 10 `Run Date: `    &
// ;tab 20 sysdate     &
// ;tab 70 `Page: `                                 &
// ;tab 79 syspage pic `^^`                         &
// ;skip 2      &
// ;tab 10 `Check if the Primary flag assigned to the correct doctor number`       & 
// ;skip 3 keep column heading
// ;rep               &
// ;doc-nbr           &
// ;doc-name          &
// ;doc-inits         &
// ;DOC-OHIP-NBR    &
// 2009/05/20 - MC1
// ;doc-dept   &
// ;doc-afp-paym-group &
// ;doc-date-fac-start &
// ;doc-date-fac-term  &
// ;doc-flag-primary
// 2009/05/20 - end
// ;build $obj/u100 
// 2009/10/05 - MC2 - add new request

#endregion

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
    public class U100_B : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "U100_B";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrU100_BLANK_PAYM_GRP = new Reader();
        #endregion

        #region " Renaissance Data "

        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                // Set Report Properties...
                ReportName = "u100";
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;

                Sort = "";

                // Start report data processing.
                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return ReportData;
        }

        #endregion

        #region " Renaissance Statements "

        #region " ACCESS "

        private void Access_U100_BLANK_PAYM_GRP()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("DOC_OHIP_NBR, ");
            strSQL.Append("DOC_DEPT, ");
            strSQL.Append("DOC_NAME, ");
            strSQL.Append("DOC_DATE_FAC_TERM, ");
            strSQL.Append("DOCREV_KEY, ");
            strSQL.Append("DOCREV_MTD_IN_REC, ");
            strSQL.Append("DOCREV_MTD_OUT_REC, ");
            strSQL.Append("CORE_RECORD_NUMBER ");
            strSQL.Append("FROM TEMPORARYDATA.U100_BLANK_PAYM_GRP ");

            strSQL.Append(Choose());

            rdrU100_BLANK_PAYM_GRP.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);

            strSQL = null;
        }

        #endregion

        #region " CHOOSE "

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(string.Empty);

            return strChoose.ToString();
        }

        #endregion

        #region " SELECT IF "

        #endregion

        #region " DEFINES "

        private System.Decimal DOC_DATE_FAC_TERM()
        {
            decimal decReturnValue = 0;

            try
            {
                decReturnValue = QDesign.NConvert(Convert.ToString(rdrU100_BLANK_PAYM_GRP.GetNumber("DOC_DATE_FAC_TERM_YY")) + Convert.ToString(rdrU100_BLANK_PAYM_GRP.GetNumber("DOC_DATE_FAC_TERM_MM").ToString().PadLeft(2, '0')) + Convert.ToString(rdrU100_BLANK_PAYM_GRP.GetString("DOC_DATE_FAC_TERM_DD").ToString().PadLeft(2, '0')));
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        #endregion

        #region " CONTROLS "

        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U100_BLANK_PAYM_GRP.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U100_BLANK_PAYM_GRP.DOC_OHIP_NBR", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U100_BLANK_PAYM_GRP.DOC_DEPT", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U100_BLANK_PAYM_GRP.DOC_NAME", DataTypes.Character, 24);
                AddControl(ReportSection.REPORT, "DOC_DATE_FAC_TERM", DataTypes.Numeric, 8);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U100_BLANK_PAYM_GRP.DOCREV_KEY", DataTypes.Character, 16);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U100_BLANK_PAYM_GRP.DOCREV_MTD_IN_REC", DataTypes.Numeric, 8);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U100_BLANK_PAYM_GRP.DOCREV_MTD_OUT_REC", DataTypes.Numeric, 8);
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        #endregion

        #region " Renaissance Precompiler Generated Code "

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 7/2/2017 8:43:41 AM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "TEMPORARYDATA.U100_BLANK_PAYM_GRP.DOC_NBR":
                    return Common.StringToField(rdrU100_BLANK_PAYM_GRP.GetString("DOC_NBR").PadRight(3, ' '));

                case "TEMPORARYDATA.U100_BLANK_PAYM_GRP.DOC_OHIP_NBR":
                    return rdrU100_BLANK_PAYM_GRP.GetNumber("DOC_OHIP_NBR").ToString().PadLeft(6, ' ');

                case "TEMPORARYDATA.U100_BLANK_PAYM_GRP.DOC_DEPT":
                    return rdrU100_BLANK_PAYM_GRP.GetNumber("DOC_DEPT").ToString().PadLeft(2, ' ');

                case "TEMPORARYDATA.U100_BLANK_PAYM_GRP.DOC_NAME":
                    return Common.StringToField(rdrU100_BLANK_PAYM_GRP.GetString("DOC_NAME").PadRight(24, ' '));

                case "TEMPORARYDATA.U100_BLANK_PAYM_GRP.DOC_DATE_FAC_TERM":
                    return DOC_DATE_FAC_TERM().ToString().PadLeft(8, ' ');

                case "TEMPORARYDATA.U100_BLANK_PAYM_GRP.DOCREV_KEY":
                    return Common.StringToField(rdrU100_BLANK_PAYM_GRP.GetString("DOCREV_KEY").PadRight(16, ' '));

                case "TEMPORARYDATA.U100_BLANK_PAYM_GRP.DOCREV_MTD_IN_REC":
                    return rdrU100_BLANK_PAYM_GRP.GetNumber("DOCREV_MTD_IN_REC").ToString().PadLeft(8, ' ');

                case "TEMPORARYDATA.U100_BLANK_PAYM_GRP.DOCREV_MTD_OUT_REC":
                    return rdrU100_BLANK_PAYM_GRP.GetNumber("DOCREV_MTD_OUT_REC").ToString().PadLeft(8, ' ');

                default:
                    return string.Empty;
            }

        }

        public override void AccessData()
        {
            try
            {
                Access_U100_BLANK_PAYM_GRP();

                while (rdrU100_BLANK_PAYM_GRP.Read())
                {
                    WriteData();
                }
                rdrU100_BLANK_PAYM_GRP.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrU100_BLANK_PAYM_GRP != null))
            {
                rdrU100_BLANK_PAYM_GRP.Close();
                rdrU100_BLANK_PAYM_GRP = null;
            }
        }


        #endregion

        #endregion
    }
}
