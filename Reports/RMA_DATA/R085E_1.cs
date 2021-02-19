//  Program: r085e 
//  Purpose: create letters to patients requesting update of health card 
//  eligibility information. All claims  of the patient are
//  listed in the body of the letter along with doctor`s
//  name
//  - NOTE: only claims that have NOT be flagged as confidential
//  ( Y  for ministry,  R  for rma flagged) will be 
//  printed.
//  - If ALL claims are confidential NO letter is generated
//  93/03/25 M. CHAN  - SMS 141 (ORIGINAL)
//  93/03/26        Y. BOCCIA         MODIFY
//  93/04/27        Y. BOCCIA         REPLACE VH8 WITH EH3
//  93/05/21 M. CHAN  - ADD MESS CODE CHECK IN THE
//  SELECTION CRITERIA (IE. IF
//  USER ENTERS THE REJECTED CLAIM
//  AND CORRECTS THE INFO WITHIN
//  THE SAME CYCLE, LETTER IS NOT
//  REQUIRED)
//  93/06/04        YASEMIN         - SORT ON PAT NAME
//  93/11/29        YASEMIN         - TAKE OUT ROSE MARINO
//  94/02/22 M. CHAN  - PDR 594
//  - CHECK LAST MAILING > 21 DAYS
//  OLD INSTEAD OF 10 DAYS
//  94/08/30 YASEMIN  - MODIFY FIST PARAGRAPH
//  96/03/28 YASEMIN  - ADD RMA HEADING
//  96/09/05 YASEMIN  - change body of letter
//  98/12/10        B.E.  - renamed from r085 to r085c. changed 
//  to access subfile created in r085a.
//  99/jan/31  B.E. - y2k
//  99/june/29   Yasemin - add e-mail address
//  00/Mar/07    Yasemin - change the body of the letters
//  00/may/29 B.E. - added testing of confidentiality flag to ensure
//  that no letter shows a confidential claim (either
//  flag  Y  (doctor request to ministry) or  R 
//  for RMA rule-based suppression
//  - changed code to prdecimal all doctors with rejected 
//  claims associated with patient (this option lost
//  when location of printing of doc-name was made)
//  00/jun/28    B.E. - this code was originally part of r085b.qzs before
//  that program was split into u085b.qts and this
//  program
//  00/sep/14    B.E.    - renamed r085c to r085e so that new program
//  u085c/d could be run first on u085b subfile to 
//  reduce to a max of 5 the number of doctors reported 
//  on any individual letter to a patient
//  02/Jan/22    Yasemin - Change the address and phone ext.
//  02/Sep/23    Yasemin - Change the address 
//  2003/nov/05   b.e.   - addition 4th letter, new selection error codes
//  2003/dec/01   yas.  - change order in heading e-mail, phone number 
//  changed the wording at footing at clmhdr-pat-ohip-id-or-chart
//  added another line  This service could have been rendered 
//  in any hospital or Clinic in Ontario 
//  2003/dec/15   A.A.    - alpha doctor nbr
//  2004/jan/07   yas.    - change VN8 to VH8 and add E4 to letter 2
//  2004/jan/14   M.C. - do not prdecimal letter if the claims are fully paid
//  2005/oct/24   yas     - changed HE2 message and heading
//  2007/Aug/24   yas     - not fitting on one page changed all skip 4 to 3 recompiled
//  2008/May/27   yas     - take out e-mail address for Privacy Act 
//  2008/Jun/13   yas     - take out response by e-mail at footing
//  2010/May/26   brad1   - access rejected-claims to filter selection statement so that letters are only printer for patients
//  who are NOT `logically` deleted 
//  2010/Jun/21   MC1     - and the clmhdr-submit-date in the selection criteria  
//  2010/Aug/10   MC2 - change the linkage when access to rejected-claims
//  2010/Oct/06   MC3     - do not prdecimal if clinic 87  
//  2011/Jan/20   MC4     - add a new prepass to get the earliest ohip-run-date and save as r085e_1
//  - include the link to the subfile in the second pass to select records to be printed
//  and save as r085e_2
//  2011/Feb/03   MC5     - Brad suggested to use ohip-run-date of r085e_run_date instead of sysdate
//  when determine the d-test-date
//  2011/Feb/24   MC6     - Yasemin/Leena requested to change the company name without `of Hamilton`
//  effective as of Feb 11, 2011    
//  2011/Mar/02   MC7     - change the selection criteria to suppress letters prdecimal for new rejected claims
//  use < if there are more than one records in ohip-run-dates file;
//  otherwise, use <= if there is only one record in ohip-run-date file
//  2011/Mar/08   MC8     - change the same as u085e.qts                 
//  - include tmp-counters in the access statement
//  - change the selection criteria to use either `<` or `<=` based on the tmp-counter-1 of tmp-counters files
//  2011/Mar/21   brad2   - remove test in select stmnt made redundant by change MC8
//  2011/Apr/04   MC9     - undo what Brad has done during my absence by change brad2
//  - also define $obj/r085e_2 to create subfile r085e which will be used in u085e.qts and actual letter 
//  to be r085e_3
//  2012/Jun/19   yas     - change MOH number from 905-521-7100 to 905-521-7825
//  2014/Oct/30   MC10    - change the address
//  2015/May/14   Yas     - change name to Jenielle MacDonald
//  2015/Jun/08   Yas     - change name to Carly Rotstein
//  2016/Mar/22   MC11    - change from 4 different letters to 2, change the body content, it will prdecimal on letterhead
//  include access to f030 file to prdecimal the location name instead of location code
//  - Yasemin requests to prdecimal Dr. Smith instead of Smith MED PROF CORP
//  2016/Mar/29   MC12    - reduce some blank lines to maximize doctor printing per patient instead of decimal up per line
//  - also Yasemin requests to suppress printing of mees code = `V09` or `A4E`
//  2016/Apr/26   Yas     - change name to Cady Mahoney  
//  2011/01/20 - MC4
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
    public class R085E_1 : BaseRDLClass
    {
        protected const string REPORT_NAME = "R085E_1";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrOHIP_RUN_DATES = new Reader();
        private Reader rdrR085E_RUN_DATE = new Reader();
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
                SubFileName = "R085E_RUN_DATE";
                SubFileType = SubFileType.Keep;
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
        private void Access_OHIP_RUN_DATES()
        {
            StringBuilder strSQL = new StringBuilder(String.Empty);
            strSQL.Append("SELECT TOP 1 ");
            strSQL.Append("SEQ_NBR, ");
            strSQL.Append("OHIP_RUN_DATE ");
            strSQL.Append("FROM INDEXED.OHIP_RUN_DATES ");
            strSQL.Append(Choose());
            rdrOHIP_RUN_DATES.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(String.Empty);
            // TODO: CHOOSE Statement - May require manual changes.
            return strChoose.ToString().ToString();
        }
        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.SUMMARY, "INDEXED.OHIP_RUN_DATES.SEQ_NBR", DataTypes.Numeric, 5);
                AddControl(ReportSection.SUMMARY, "INDEXED.OHIP_RUN_DATES.OHIP_RUN_DATE", DataTypes.Numeric, 8);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-05-14 10:20:58 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            // TODO: Remove duplicate controls, if there are any.
            switch (strControl)
            {
                case "INDEXED.OHIP_RUN_DATES.SEQ_NBR":
                    return rdrOHIP_RUN_DATES.GetNumber("SEQ_NBR").ToString();
                case "INDEXED.OHIP_RUN_DATES.OHIP_RUN_DATE":
                    return rdrOHIP_RUN_DATES.GetNumber("OHIP_RUN_DATE").ToString();
                default:
                    return String.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                // TODO: Some manual steps maybe required.
                Access_OHIP_RUN_DATES();
                while (rdrOHIP_RUN_DATES.Read())
                {
                    WriteData();
                }

                rdrOHIP_RUN_DATES.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrOHIP_RUN_DATES == null))
            {
                rdrOHIP_RUN_DATES.Close();
                rdrOHIP_RUN_DATES = null;
            }
        }
    }
}
