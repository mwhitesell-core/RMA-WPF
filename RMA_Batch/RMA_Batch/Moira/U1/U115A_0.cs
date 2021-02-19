
#region "Screen Comments"

// #> program-id.     u115a_0.qts
// ((C)) Dyad Infosys  LTD
// purpose: sub-process within  earnings generation  process.
// calculate required `tot`al / `ytd` transactions as of current EP
// MODIFICATION HISTORY
// DATE    SAF #  WHO      DESCRIPTION
// 92/jan/01  ____   B.E.     - original
// 92/may/01  ____   B.E.     - Added YTDGUC logic
// 92/may/11  ____   B.E.     - YTDGUC logic changed from 1C to 1B (YTDGUC)
// 92/aug/11  ____   b.e.     - moved ytd logic into 2nd request
// 92/sep/14  ----   b.e.     - comment out output of YTDGUx transaction
// since GTYPEx is now calculated as ytd not
// current ep.  If GTYPEx changed re-activatE
// the TYDGUx code.
// 92/oct/26  ----   B.E.     - Updated F020 with YTDINC value
// 92/nov/10         B.E.     - updated F020 within this run with OUTPUT stmt
// rather than using U115 SUBFILE.
// 93/apr/10         B.E.     - YTDCEA/CEX use values in DOCTOR-MSTR rather
// than calculated ones.
// 93/may/06         B.E.     - Added SUBFILE F119
// 93/may/11         B.E.     - Added ACCESS of F119-DOCTOR-YTD to preset
// 93/may/18         B.E.     - INTEGER*4 for zoned*8, F119/F119 SUBFILE changes
// YTD values
// 93/may/27         B.E.     - *F119 exclude records added to F119
// - add/subtract F110  M anual type recs to 
// F020`s YTDEAR (ytd earnings)
// - changed YTDxxx to use = not < current-ep-nbr
// ?????? WITH ABOVE = VS < CHANGE IS THIS CODE NOW NOT REQUIRED ????????????????
// 93/JUN/01         B.E.     - removed ADD of recs to F119-DOCTOR-YTD, all records
// now added to *F119 and then U122 adds them to F119-YTD
// 93/JUN/22         B.E.     - added Part timer Expense logic
// 93/AUG/09         B.E.     - GST/AMT EXPENSE now calculated by
// separating these two amounts from the
// the amount of the difference between
// GROSS and NET amounts.
// 93/SEP/14         B.E.     - added RMA+GST and DEPT MISC/REG Expense Logic
// and rounding of result
// 93/SEP/20         B.E.     - added separate expenses for RMA MISC/REG.
// now using RMAEXR(RMA  Regular expense),
// RMAEXM(RMA  Misc.   expense),
// DEPEXR(DEPT Regular expense),
// DEPEXM(DEPT Misc.   expense)
// OUTPUT RMA and DEPT expense only if > 0
// 93/SEP/24         B.E.     - added DOCTOR`S CEIEXP to TOTEXP amount
// 93/SEP/28         B.E.     - changed update of *F119 from GROSS to NET values
// 93/OCT/02         B.E.     - OUTPUT TOTxxx records to *F119 only if > 0
// 93/OCT/05         B.E.     - RMA-EXPENSE calc. as diff between GROSS and NET
// minus DEPT-EXPENSE even if doctor`s RMA
// EXPENSE PERCENTAGES are zero.
// 93/OCT/26         B.E.     - changed IF > 0  to IF <> 0 on all OUTPUT stmnts
// 93/OCT/30         B.E.     - AMT-INCOME-MINUS-EXPENSES-G now allowed  to go
// negative (otherwise negative income
// wasn`t reported correctly)
// 93/NOV/26         B.E.     - Reversed GROSS/NET fields on CEIEXP output to *F119
// 93/DEC/03         B.E.     - for CEIEXP used AMT-NET not 0 in calc.
// 93/DEC/24         B.E.     - put YTDEAR into *F119 for update into F119-DOCTOR-YTD
// 94/MAR/07         M.C.     - ADD THE CONDITIONAL COMPILE FOR `INCEXP`
// LOGIC
// 94/MAR/16         M.C.     - INCLUDE COMP-TYPE `P` IN THE SUBFILE,
// - CHANGE THE FORMULA FOR CALCULATING
// DEPT AND RMA EXPENSE
// 95/MAY/02  M.C.  - ADD THE BACKHOLD AS PART OF THE
// EXPENSE
// 95/MAY/08         M.C.     - COMMENT OUT THE SUBFILE DEBUGU115A,
// MESSAGE `VIRTUAL MEMORY HAS EXCEEDED`
// OCCURRED WHEN EXECUTING PROGRAM EVEN
// THE STACKSIZE HAS INCREASED FROM 1500
// TO 10000. NOTE:  KEEP IN MIND THAT
// SIMILIAR PROBLEM MAY OCCUR IF THERE
// ARE MORE ITEMS, SUBFILES OR RECORDS
// TO BE ADDED IN THE REQUESTS
// 95/MAY/09  M.C.  - CALCULATE THE RMA EXPENSE BY THE
// DOCTOR RMA EXPENSE PERCENTAGE RATHER
// THAN THE REMAINING VALUE BETWEEN
// GROSS - NET - DEPT
// 95/JUL/05         M.C.     - IF HOLDBACK < 10 CENTS, ADD TO RMA
// EXPENSE IF RMA-EXPENSE IS NON-ZERO;
// OTHERWISE, ADD TO DEPT EXPENSE
// 95/JUL/14  M.C.  - DUE TO VIRTUAL MEMORY HAS EXCEEDED
// SPLIT THE LAST REQUEST INTO A NEW
// PROGRAM(U115B.QTS).  IF CHANGES ARE
// REQUIRED IN THE LAST REQUEST, ALSO
// MAKE THE SAME CHANGE IN U115B.QTS
// 95/SEP/15  M.C.  - INCLUDE `E`XPENSE RECORDS AS PART OF
// FINAL-ALL-EXPENSES
// 95/NOV/07  M.C.  - PDR 634 - INCLUDE NEW CONDITION FOR
// TOT-REVHBK DEFINITION
// 95/NOV/22   M.C.  - OPTIMIZE THE PROGRAM BY DELETING ALL
// THE UNUSED TEMP & DEFINE ITEMS
// 96/APR/19  M.C.  - INCLUDE `REVCLA` IN TOT-REVHBK
// 1999/Feb/18         S.B.     - Checked for Y2K.
// 1999/Jun/07  S.B.  - Altered the call to gst.use to call 
// from $use instead of src.
// 00/nov/23.B.E. - HOLDBK calculation has some rounding problems whereby
// hold backs in the amount of a few cents occur. The
// original logic ignored values less than 10 cents.
// Changed to ignore anything less than $1.00
// 00/mar/01 B.E. - added debug subfiles and cosmetic alignment
// of calculations
// 03/jan/21 B.E. - added doc-nbr to debug file debugu115a_at_doc_nbr
// 03/dec/16 A.A. - alpha doctor nbr
// 04/jan/28 b.e. - calculation of RMAEXR/RMAEXM which are based upon
// tot-rma-expense-only-reg/misc created only if calc is
// positive (doesn`t fix all of problem but at least if
// total amount for month is negative we don`t create
// negative charge)
// 04/mar/01 b.e. - added `O`ther `I`ncome processing in addition to
// current logic that handles `R`egular and `M`isc
// types of Income.
// 04/mac/25 b .e. - changed sequence of factor divide by 100000 to try
// to avoid rounding errors (approx 5cents on 10,500)
// 04/apr/01 b.e.  - undid the jan 28 change as the GST and TOTEXP calcs
// were still output and negative so unbalanced with
// 06/mar/20 b.e. - generate of HOLDBK transaction eliminated in 
// u115_common.qts used by this program
// 2006/may/10 b.e.      - $1M payroll changes to size of calculated fields
// 2008/may/10 brad1     -  AFPADJ  transactions no longer shown on r124a stmnts
// nor the `94` screen - moved to  +  type transactions
// in f119 to `hide` them (shown on new 96 screen)
// 2008/jun/05 M.C.      - change access to link to f116-dtl file
// - change criteria when calculating amounts for TOTINC
// - modify criteria in $src/u115_common.qts
// - create records in new subfile f119_tithe
// 2008/aug/19 M.C.      - prompt for global parameter for payroll-flag
// 2008/sep/29 M.C.      - access to use f119 instead of f110 since titheable records have rec-type = `D` in f119
// which were generated from u130.qts
// 2008/oct/21 brad2 - take all records for rec-type D  from f119 even if mtd-amt = 0 since ytd is what is used in calcs
// 2008/oct/21 brad3 - amt-gross values set to amt-ytd (amt-net left set to amt-mtd) as the ytd values are used in calcs
// 2008/oct/21 brad4 - UNDID ABOVE CHANGE - CHANGED ONE TIME CONVERSION FROM  A  to  D  records to put amt-mtd = amt-ytd
// 2015/Jun/25 MC1 - add second linkage to f116-dtl for the actual doc-nbr for determine tithe 
// needs TOTITE created from u122 -- this comment may be wrong!


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;

public class U115A_0 : BaseClassControl
{
    private U115A_0 m_U115A_0;

    public U115A_0(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
        YTDEAR_GROUP = new CoreCharacter("YTDEAR_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        YTDEAR_SEQ_RPT = new CoreDecimal("YTDEAR_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        RMAEXR_GROUP = new CoreCharacter("RMAEXR_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        RMAEXR_SEQ_RPT = new CoreDecimal("RMAEXR_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        RMAEXM_GROUP = new CoreCharacter("RMAEXM_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        RMAEXM_SEQ_RPT = new CoreDecimal("RMAEXM_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        INCEXP_GROUP = new CoreCharacter("INCEXP_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        INCEXP_SEQ_RPT = new CoreDecimal("INCEXP_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        TOTINC_GROUP = new CoreCharacter("TOTINC_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        TOTINC_SEQ_RPT = new CoreDecimal("TOTINC_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        TOTEXP_GROUP = new CoreCharacter("TOTEXP_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        TOTEXP_SEQ_RPT = new CoreDecimal("TOTEXP_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        DEPEXR_GROUP = new CoreCharacter("DEPEXR_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DEPEXR_SEQ_RPT = new CoreDecimal("DEPEXR_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        DEPEXM_GROUP = new CoreCharacter("DEPEXM_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DEPEXM_SEQ_RPT = new CoreDecimal("DEPEXM_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        GST_GROUP = new CoreCharacter("GST_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        GST_SEQ_RPT = new CoreDecimal("GST_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        HOLDBACK_GROUP = new CoreCharacter("HOLDBACK_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        HOLDBACK_SEQ_RPT = new CoreDecimal("HOLDBACK_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        PAYROLL_FLAG = new CoreCharacter("PAYROLL_FLAG", 1, this, ResetTypes.ResetAtStartup, Prompt(1).ToString());
        TOTITE_GROUP = new CoreCharacter("TOTITE_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        TOTITE_SEQ_RPT = new CoreDecimal("TOTITE_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        TOTITD_GROUP = new CoreCharacter("TOTITD_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        TOTITD_SEQ_RPT = new CoreDecimal("TOTITD_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
    }

    public U115A_0(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
        YTDEAR_GROUP = new CoreCharacter("YTDEAR_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        YTDEAR_SEQ_RPT = new CoreDecimal("YTDEAR_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        RMAEXR_GROUP = new CoreCharacter("RMAEXR_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        RMAEXR_SEQ_RPT = new CoreDecimal("RMAEXR_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        RMAEXM_GROUP = new CoreCharacter("RMAEXM_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        RMAEXM_SEQ_RPT = new CoreDecimal("RMAEXM_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        INCEXP_GROUP = new CoreCharacter("INCEXP_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        INCEXP_SEQ_RPT = new CoreDecimal("INCEXP_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        TOTINC_GROUP = new CoreCharacter("TOTINC_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        TOTINC_SEQ_RPT = new CoreDecimal("TOTINC_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        TOTEXP_GROUP = new CoreCharacter("TOTEXP_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        TOTEXP_SEQ_RPT = new CoreDecimal("TOTEXP_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        DEPEXR_GROUP = new CoreCharacter("DEPEXR_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DEPEXR_SEQ_RPT = new CoreDecimal("DEPEXR_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        DEPEXM_GROUP = new CoreCharacter("DEPEXM_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DEPEXM_SEQ_RPT = new CoreDecimal("DEPEXM_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        GST_GROUP = new CoreCharacter("GST_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        GST_SEQ_RPT = new CoreDecimal("GST_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        HOLDBACK_GROUP = new CoreCharacter("HOLDBACK_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        HOLDBACK_SEQ_RPT = new CoreDecimal("HOLDBACK_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        PAYROLL_FLAG = new CoreCharacter("PAYROLL_FLAG", 1, this, ResetTypes.ResetAtStartup, Prompt(1).ToString());
        TOTITE_GROUP = new CoreCharacter("TOTITE_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        TOTITE_SEQ_RPT = new CoreDecimal("TOTITE_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        TOTITD_GROUP = new CoreCharacter("TOTITD_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        TOTITD_SEQ_RPT = new CoreDecimal("TOTITD_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
    }

    public override void Dispose()
    {
        if ((m_U115A_0 != null))
        {
            m_U115A_0.CloseTransactionObjects();
            m_U115A_0 = null;
        }
    }

    public U115A_0 GetU115A_0(int Level)
    {
        if (m_U115A_0 == null)
        {
            m_U115A_0 = new U115A_0("U115A_0", Level);
        }
        else
        {
            m_U115A_0.ResetValues();
        }
        return m_U115A_0;
    }

    #region "Renaissance Architect Migration Services Default Regions"

    #region "Declarations (Variables, Files and Transactions)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.
    protected CoreCharacter YTDEAR_GROUP;
    protected CoreDecimal YTDEAR_SEQ_RPT;
    protected CoreCharacter RMAEXR_GROUP;
    protected CoreDecimal RMAEXR_SEQ_RPT;
    protected CoreCharacter RMAEXM_GROUP;
    protected CoreDecimal RMAEXM_SEQ_RPT;
    protected CoreCharacter INCEXP_GROUP;
    protected CoreDecimal INCEXP_SEQ_RPT;
    protected CoreCharacter TOTINC_GROUP;
    protected CoreDecimal TOTINC_SEQ_RPT;
    protected CoreCharacter TOTEXP_GROUP;
    protected CoreDecimal TOTEXP_SEQ_RPT;
    protected CoreCharacter DEPEXR_GROUP;
    protected CoreDecimal DEPEXR_SEQ_RPT;
    protected CoreCharacter DEPEXM_GROUP;
    protected CoreDecimal DEPEXM_SEQ_RPT;
    protected CoreCharacter GST_GROUP;
    protected CoreDecimal GST_SEQ_RPT;
    protected CoreCharacter HOLDBACK_GROUP;
    protected CoreDecimal HOLDBACK_SEQ_RPT;
    protected CoreCharacter PAYROLL_FLAG;
    protected CoreCharacter TOTITE_GROUP;
    protected CoreDecimal TOTITE_SEQ_RPT;
    protected CoreCharacter TOTITD_GROUP;
    protected CoreDecimal TOTITD_SEQ_RPT;

    protected SqlConnection m_cnnQUERY = new SqlConnection();
    protected SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();

    protected SqlTransaction m_trnTRANS_UPDATE;

    #endregion

    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"

    public override bool RunQTP()
    {
        try
        {
            //; DETERMINE THE 'REPORTING-SEQ' AND 'COMP CODE GROUP'
            //; FOR THE TRANSACTIONS BEING CREATED IN THIS RUN

            U115A_0_U115_A_GET_YTDEAR_1 U115_A_GET_YTDEAR_1 = new U115A_0_U115_A_GET_YTDEAR_1(Name, Level);
            U115_A_GET_YTDEAR_1.Run();
            U115_A_GET_YTDEAR_1.Dispose();
            U115_A_GET_YTDEAR_1 = null;

            U115A_0_U115_A_GET_RMAEXR_2 U115_A_GET_RMAEXR_2 = new U115A_0_U115_A_GET_RMAEXR_2(Name, Level);
            U115_A_GET_RMAEXR_2.Run();
            U115_A_GET_RMAEXR_2.Dispose();
            U115_A_GET_RMAEXR_2 = null;

            U115A_0_U115_A_GET_RMAEXM_3 U115_A_GET_RMAEXM_3 = new U115A_0_U115_A_GET_RMAEXM_3(Name, Level);
            U115_A_GET_RMAEXM_3.Run();
            U115_A_GET_RMAEXM_3.Dispose();
            U115_A_GET_RMAEXM_3 = null;

            U115A_0_U115_A_GET_INCEXP_4 U115_A_GET_INCEXP_4 = new U115A_0_U115_A_GET_INCEXP_4(Name, Level);
            U115_A_GET_INCEXP_4.Run();
            U115_A_GET_INCEXP_4.Dispose();
            U115_A_GET_INCEXP_4 = null;

            U115A_0_U115_A_GET_TOTINC_5 U115_A_GET_TOTINC_5 = new U115A_0_U115_A_GET_TOTINC_5(Name, Level);
            U115_A_GET_TOTINC_5.Run();
            U115_A_GET_TOTINC_5.Dispose();
            U115_A_GET_TOTINC_5 = null;

            U115A_0_U115_A_GET_TOTEXP_6 U115_A_GET_TOTEXP_6 = new U115A_0_U115_A_GET_TOTEXP_6(Name, Level);
            U115_A_GET_TOTEXP_6.Run();
            U115_A_GET_TOTEXP_6.Dispose();
            U115_A_GET_TOTEXP_6 = null;

            U115A_0_U115_A_GET_DEPEXR_7 U115_A_GET_DEPEXR_7 = new U115A_0_U115_A_GET_DEPEXR_7(Name, Level);
            U115_A_GET_DEPEXR_7.Run();
            U115_A_GET_DEPEXR_7.Dispose();
            U115_A_GET_DEPEXR_7 = null;

            U115A_0_U115_A_GET_DEPEXM_8 U115_A_GET_DEPEXM_8 = new U115A_0_U115_A_GET_DEPEXM_8(Name, Level);
            U115_A_GET_DEPEXM_8.Run();
            U115_A_GET_DEPEXM_8.Dispose();
            U115_A_GET_DEPEXM_8 = null;

            U115A_0_U115_A_GET_GST_9 U115_A_GET_GST_9 = new U115A_0_U115_A_GET_GST_9(Name, Level);
            U115_A_GET_GST_9.Run();
            U115_A_GET_GST_9.Dispose();
            U115_A_GET_GST_9 = null;

            U115A_0_U115_A_GET_HOLDBACK_10 U115_A_GET_HOLDBACK_10 = new U115A_0_U115_A_GET_HOLDBACK_10(Name, Level);
            U115_A_GET_HOLDBACK_10.Run();
            U115_A_GET_HOLDBACK_10.Dispose();
            U115_A_GET_HOLDBACK_10 = null;

            U115A_0_U115_RUN_0_11 U115_RUN_0_11 = new U115A_0_U115_RUN_0_11(Name, Level);
            U115_RUN_0_11.Run();
            U115_RUN_0_11.Dispose();
            U115_RUN_0_11 = null;

            return true;
        }

        catch (CustomApplicationException ex)
        {
            WriteError(ex);
            return false;
        }

        catch (Exception ex)
        {
            WriteError(ex);
            return false;
        }
    }

    #endregion

    #endregion

    public class U115A_0_U115_A_GET_YTDEAR_1 : U115A_0
    {
        public U115A_0_U115_A_GET_YTDEAR_1(string Name, int Level)
            : base(Name, Level, true)
        {
            this.ScreenType = ScreenTypes.QTP;
            fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

            fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;
        }

        #region "Declarations (Variables, Files and Transactions)(U115A_0_U115_A_GET_YTDEAR_1)"

        private SqlFileObject fleF190_COMP_CODES;

        private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
        {
            try
            {
                StringBuilder strSQL = new StringBuilder("");

                strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE"));
                strSQL.Append(" = 'YTDEAR'");

                ChooseClause = strSQL.ToString();
            }

            catch (CustomApplicationException ex)
            {
                WriteError(ex);
            }

            catch (Exception ex)
            {
                WriteError(ex);
            }
        }

        #endregion

        #region "Standard Generated Procedures(U115A_0_U115_A_GET_YTDEAR_1)"

        #region "Transaction Management Procedures(U115A_0_U115_A_GET_YTDEAR_1)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 6/27/2017 2:46:31 PM

        //#-----------------------------------------
        //# InitializeTransactionObjects Procedure.
        //#-----------------------------------------

        protected override void InitializeTransactionObjects()
        {
            try
            {
                m_cnnTRANS_UPDATE = new SqlConnection(Common.GetConnectionString());
                m_cnnTRANS_UPDATE.Open();
                m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
                m_cnnQUERY = new SqlConnection(Common.GetConnectionString());
            }

            catch (CustomApplicationException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;
            }
        }

        //#-----------------------------------------
        //# CloseTransactionObjects Procedure.
        //#-----------------------------------------

        protected override void CloseTransactionObjects()
        {
            try
            {
                CloseFiles();

                if ((m_trnTRANS_UPDATE != null))
                    m_trnTRANS_UPDATE.Dispose();

                if ((m_cnnTRANS_UPDATE != null))
                    m_cnnTRANS_UPDATE.Close();

                if ((m_cnnTRANS_UPDATE != null))
                    m_cnnTRANS_UPDATE.Dispose();

                if ((m_cnnQUERY != null))
                    m_cnnQUERY.Close();

                if ((m_cnnQUERY != null))
                    m_cnnQUERY.Dispose();
            }

            catch (CustomApplicationException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;
            }
        }

        protected override void TRANS_UPDATE(TransactionMethods Method)
        {
            if (Method == TransactionMethods.Rollback)
            {
                m_trnTRANS_UPDATE.Rollback();
            }
            else
            {
                m_trnTRANS_UPDATE.Commit();
            }

            m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
            Initialize_TRANS_UPDATE();
        }

        private void Initialize_TRANS_UPDATE()
        {
            fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;
        }

        #endregion

        #region "FILE Management Procedures(U115A_0_U115_A_GET_YTDEAR_1)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 6/27/2017 2:46:31 PM

        //#-----------------------------------------
        //# InitializeFiles Procedure.
        //#-----------------------------------------

        protected override void InitializeFiles()
        {
            try
            {
                Initialize_TRANS_UPDATE();
            }

            catch (CustomApplicationException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;
            }
        }

        //#-----------------------------------------
        //# CloseFiles Procedure.
        //#-----------------------------------------

        protected override void CloseFiles()
        {
            try
            {
                fleF190_COMP_CODES.Dispose();
            }

            catch (CustomApplicationException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;
            }
        }

        #endregion

        #endregion

        #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U115A_0_U115_A_GET_YTDEAR_1)"

        public void Run()
        {
            try
            {
                Request("U115A_0_U115_A_GET_YTDEAR_1");

                while (fleF190_COMP_CODES.QTPForMissing())
                {
                    // --> GET fleF190_COMP_CODES <--
                    fleF190_COMP_CODES.GetData();
                    // --> End GET fleF190_COMP_CODES <--

                    if (Transaction())
                    {
                        YTDEAR_GROUP.Value = fleF190_COMP_CODES.GetStringValue("COMP_CODE_GROUP");
                        YTDEAR_SEQ_RPT.Value = fleF190_COMP_CODES.GetDecimalValue("REPORTING_SEQ");
                    }
                }
            }

            catch (CustomApplicationException ex)
            {
                WriteError(ex);
            }

            catch (Exception ex)
            {
                WriteError(ex);
            }

            finally
            {
                EndRequest("U115A_0_U115_A_GET_YTDEAR_1");
            }
        }

        #endregion
    }

    public class U115A_0_U115_A_GET_RMAEXR_2 : U115A_0
    {
        public U115A_0_U115_A_GET_RMAEXR_2(string Name, int Level)
            : base(Name, Level, true)
        {
            this.ScreenType = ScreenTypes.QTP;
            fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

            fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;
        }

        #region "Declarations (Variables, Files and Transactions)(U115A_0_U115_A_GET_RMAEXR_2)"

        private SqlFileObject fleF190_COMP_CODES;

        private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
        {
            try
            {
                StringBuilder strSQL = new StringBuilder("");

                strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE"));
                strSQL.Append(" = 'RMAEXR'");

                ChooseClause = strSQL.ToString();
            }

            catch (CustomApplicationException ex)
            {
                WriteError(ex);
            }

            catch (Exception ex)
            {
                WriteError(ex);
            }
        }

        #endregion

        #region "Standard Generated Procedures(U115A_0_U115_A_GET_RMAEXR_2)"

        #region "Transaction Management Procedures(U115A_0_U115_A_GET_RMAEXR_2)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 6/27/2017 2:46:31 PM

        //#-----------------------------------------
        //# InitializeTransactionObjects Procedure.
        //#-----------------------------------------

        protected override void InitializeTransactionObjects()
        {
            try
            {
                m_cnnTRANS_UPDATE = new SqlConnection(Common.GetConnectionString());
                m_cnnTRANS_UPDATE.Open();
                m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
                m_cnnQUERY = new SqlConnection(Common.GetConnectionString());
            }

            catch (CustomApplicationException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;
            }
        }

        //#-----------------------------------------
        //# CloseTransactionObjects Procedure.
        //#-----------------------------------------

        protected override void CloseTransactionObjects()
        {
            try
            {
                CloseFiles();

                if ((m_trnTRANS_UPDATE != null))
                    m_trnTRANS_UPDATE.Dispose();

                if ((m_cnnTRANS_UPDATE != null))
                    m_cnnTRANS_UPDATE.Close();

                if ((m_cnnTRANS_UPDATE != null))
                    m_cnnTRANS_UPDATE.Dispose();

                if ((m_cnnQUERY != null))
                    m_cnnQUERY.Close();

                if ((m_cnnQUERY != null))
                    m_cnnQUERY.Dispose();
            }

            catch (CustomApplicationException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;
            }
        }

        protected override void TRANS_UPDATE(TransactionMethods Method)
        {
            if (Method == TransactionMethods.Rollback)
            {
                m_trnTRANS_UPDATE.Rollback();
            }
            else
            {
                m_trnTRANS_UPDATE.Commit();
            }

            m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
            Initialize_TRANS_UPDATE();
        }

        private void Initialize_TRANS_UPDATE()
        {
            fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;
        }

        #endregion

        #region "FILE Management Procedures(U115A_0_U115_A_GET_RMAEXR_2)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 6/27/2017 2:46:31 PM

        //#-----------------------------------------
        //# InitializeFiles Procedure.
        //#-----------------------------------------

        protected override void InitializeFiles()
        {
            try
            {
                Initialize_TRANS_UPDATE();
            }

            catch (CustomApplicationException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;
            }
        }

        //#-----------------------------------------
        //# CloseFiles Procedure.
        //#-----------------------------------------

        protected override void CloseFiles()
        {
            try
            {
                fleF190_COMP_CODES.Dispose();
            }

            catch (CustomApplicationException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;
            }
        }

        #endregion

        #endregion

        #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U115A_0_U115_A_GET_RMAEXR_2)"

        public void Run()
        {
            try
            {
                Request("U115A_0_U115_A_GET_RMAEXR_2");

                while (fleF190_COMP_CODES.QTPForMissing())
                {
                    // --> GET fleF190_COMP_CODES <--
                    fleF190_COMP_CODES.GetData();
                    // --> End GET fleF190_COMP_CODES <--

                    if (Transaction())
                    {
                        RMAEXR_GROUP.Value = fleF190_COMP_CODES.GetStringValue("COMP_CODE_GROUP");
                        RMAEXR_SEQ_RPT.Value = fleF190_COMP_CODES.GetDecimalValue("REPORTING_SEQ");
                    }
                }
            }

            catch (CustomApplicationException ex)
            {
                WriteError(ex);
            }

            catch (Exception ex)
            {
                WriteError(ex);
            }

            finally
            {
                EndRequest("U115A_0_U115_A_GET_RMAEXR_2");
            }
        }

        #endregion
    }

    public class U115A_0_U115_A_GET_RMAEXM_3 : U115A_0
    {
        public U115A_0_U115_A_GET_RMAEXM_3(string Name, int Level)
            : base(Name, Level, true)
        {
            this.ScreenType = ScreenTypes.QTP;
            fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

            fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;
        }

        #region "Declarations (Variables, Files and Transactions)(U115A_0_U115_U115_A_GET_RMAEXM_3)"

        private SqlFileObject fleF190_COMP_CODES;

        private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
        {
            try
            {
                StringBuilder strSQL = new StringBuilder("");

                strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE"));
                strSQL.Append(" = 'RMAEXM'");

                ChooseClause = strSQL.ToString();
            }

            catch (CustomApplicationException ex)
            {
                WriteError(ex);
            }

            catch (Exception ex)
            {
                WriteError(ex);
            }
        }

        #endregion

        #region "Standard Generated Procedures(U115A_0_U115_U115_A_GET_RMAEXM_3)"

        #region "Transaction Management Procedures(U115A_0_U115_U115_A_GET_RMAEXM_3)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 6/27/2017 2:46:31 PM

        //#-----------------------------------------
        //# InitializeTransactionObjects Procedure.
        //#-----------------------------------------

        protected override void InitializeTransactionObjects()
        {
            try
            {
                m_cnnTRANS_UPDATE = new SqlConnection(Common.GetConnectionString());
                m_cnnTRANS_UPDATE.Open();
                m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
                m_cnnQUERY = new SqlConnection(Common.GetConnectionString());
            }

            catch (CustomApplicationException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;
            }
        }

        //#-----------------------------------------
        //# CloseTransactionObjects Procedure.
        //#-----------------------------------------

        protected override void CloseTransactionObjects()
        {
            try
            {
                CloseFiles();

                if ((m_trnTRANS_UPDATE != null))
                    m_trnTRANS_UPDATE.Dispose();

                if ((m_cnnTRANS_UPDATE != null))
                    m_cnnTRANS_UPDATE.Close();

                if ((m_cnnTRANS_UPDATE != null))
                    m_cnnTRANS_UPDATE.Dispose();

                if ((m_cnnQUERY != null))
                    m_cnnQUERY.Close();

                if ((m_cnnQUERY != null))
                    m_cnnQUERY.Dispose();
            }

            catch (CustomApplicationException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;
            }
        }

        protected override void TRANS_UPDATE(TransactionMethods Method)
        {
            if (Method == TransactionMethods.Rollback)
            {
                m_trnTRANS_UPDATE.Rollback();
            }
            else
            {
                m_trnTRANS_UPDATE.Commit();
            }

            m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
            Initialize_TRANS_UPDATE();
        }

        private void Initialize_TRANS_UPDATE()
        {
            fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;
        }

        #endregion

        #region "FILE Management Procedures(U115A_0_U115_U115_A_GET_RMAEXM_3)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 6/27/2017 2:46:31 PM

        //#-----------------------------------------
        //# InitializeFiles Procedure.
        //#-----------------------------------------

        protected override void InitializeFiles()
        {
            try
            {
                Initialize_TRANS_UPDATE();
            }

            catch (CustomApplicationException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;
            }
        }

        //#-----------------------------------------
        //# CloseFiles Procedure.
        //#-----------------------------------------

        protected override void CloseFiles()
        {
            try
            {
                fleF190_COMP_CODES.Dispose();
            }

            catch (CustomApplicationException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;
            }
        }

        #endregion

        #endregion

        #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U115A_0_U115_U115_A_GET_RMAEXM_3)"

        public void Run()
        {
            try
            {
                Request("U115A_0_U115_A_GET_RMAEXM_3");

                while (fleF190_COMP_CODES.QTPForMissing())
                {
                    // --> GET fleF190_COMP_CODES <--
                    fleF190_COMP_CODES.GetData();
                    // --> End GET fleF190_COMP_CODES <--

                    if (Transaction())
                    {
                        RMAEXM_GROUP.Value = fleF190_COMP_CODES.GetStringValue("COMP_CODE_GROUP");
                        RMAEXM_SEQ_RPT.Value = fleF190_COMP_CODES.GetDecimalValue("REPORTING_SEQ");
                    }
                }
            }

            catch (CustomApplicationException ex)
            {
                WriteError(ex);
            }

            catch (Exception ex)
            {
                WriteError(ex);
            }

            finally
            {
                EndRequest("U115A_0_U115_A_GET_RMAEXM_3");
            }
        }

        #endregion
    }

    public class U115A_0_U115_A_GET_INCEXP_4 : U115A_0
    {
        public U115A_0_U115_A_GET_INCEXP_4(string Name, int Level)
            : base(Name, Level, true)
        {
            this.ScreenType = ScreenTypes.QTP;
            fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

            fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;
        }

        #region "Declarations (Variables, Files and Transactions)(U115A_0_U115_A_GET_INCEXP_4)"

        private SqlFileObject fleF190_COMP_CODES;

        private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
        {
            try
            {
                StringBuilder strSQL = new StringBuilder("");

                strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE"));
                strSQL.Append(" = 'INCEXP'");

                ChooseClause = strSQL.ToString();
            }

            catch (CustomApplicationException ex)
            {
                WriteError(ex);
            }

            catch (Exception ex)
            {
                WriteError(ex);
            }
        }

        #endregion

        #region "Standard Generated Procedures(U115A_0_U115_A_GET_INCEXP_4)"

        #region "Transaction Management Procedures(U115A_0_U115_A_GET_INCEXP_4)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 6/27/2017 2:46:31 PM

        //#-----------------------------------------
        //# InitializeTransactionObjects Procedure.
        //#-----------------------------------------

        protected override void InitializeTransactionObjects()
        {
            try
            {
                m_cnnTRANS_UPDATE = new SqlConnection(Common.GetConnectionString());
                m_cnnTRANS_UPDATE.Open();
                m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
                m_cnnQUERY = new SqlConnection(Common.GetConnectionString());
            }

            catch (CustomApplicationException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;
            }
        }

        //#-----------------------------------------
        //# CloseTransactionObjects Procedure.
        //#-----------------------------------------

        protected override void CloseTransactionObjects()
        {
            try
            {
                CloseFiles();

                if ((m_trnTRANS_UPDATE != null))
                    m_trnTRANS_UPDATE.Dispose();

                if ((m_cnnTRANS_UPDATE != null))
                    m_cnnTRANS_UPDATE.Close();

                if ((m_cnnTRANS_UPDATE != null))
                    m_cnnTRANS_UPDATE.Dispose();

                if ((m_cnnQUERY != null))
                    m_cnnQUERY.Close();

                if ((m_cnnQUERY != null))
                    m_cnnQUERY.Dispose();
            }

            catch (CustomApplicationException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;
            }
        }

        protected override void TRANS_UPDATE(TransactionMethods Method)
        {
            if (Method == TransactionMethods.Rollback)
            {
                m_trnTRANS_UPDATE.Rollback();
            }
            else
            {
                m_trnTRANS_UPDATE.Commit();
            }

            m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
            Initialize_TRANS_UPDATE();
        }

        private void Initialize_TRANS_UPDATE()
        {
            fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;
        }

        #endregion

        #region "FILE Management Procedures(U115A_0_U115_A_GET_INCEXP_4)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 6/27/2017 2:46:31 PM

        //#-----------------------------------------
        //# InitializeFiles Procedure.
        //#-----------------------------------------

        protected override void InitializeFiles()
        {
            try
            {
                Initialize_TRANS_UPDATE();
            }

            catch (CustomApplicationException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;
            }
        }

        //#-----------------------------------------
        //# CloseFiles Procedure.
        //#-----------------------------------------

        protected override void CloseFiles()
        {
            try
            {
                fleF190_COMP_CODES.Dispose();
            }

            catch (CustomApplicationException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;
            }
        }

        #endregion

        #endregion

        #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U115A_0_U115_A_GET_INCEXP_4)"

        public void Run()
        {
            try
            {
                Request("U115A_0_U115_A_GET_INCEXP_4");

                while (fleF190_COMP_CODES.QTPForMissing())
                {
                    // --> GET fleF190_COMP_CODES <--
                    fleF190_COMP_CODES.GetData();
                    // --> End GET fleF190_COMP_CODES <--

                    if (Transaction())
                    {
                        INCEXP_SEQ_RPT.Value = fleF190_COMP_CODES.GetDecimalValue("REPORTING_SEQ");
                        INCEXP_GROUP.Value = fleF190_COMP_CODES.GetStringValue("COMP_CODE_GROUP");
                    }
                }
            }

            catch (CustomApplicationException ex)
            {
                WriteError(ex);
            }

            catch (Exception ex)
            {
                WriteError(ex);
            }

            finally
            {
                EndRequest("U115A_0_U115_A_GET_INCEXP_4");
            }
        }

        #endregion
    }

    public class U115A_0_U115_A_GET_TOTINC_5 : U115A_0
    {
        public U115A_0_U115_A_GET_TOTINC_5(string Name, int Level)
            : base(Name, Level, true)
        {
            this.ScreenType = ScreenTypes.QTP;
            fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

            fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;
        }

        #region "Declarations (Variables, Files and Transactions)(U115A_0_U115_A_GET_TOTINC_5)"

        private SqlFileObject fleF190_COMP_CODES;

        private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
        {
            try
            {
                StringBuilder strSQL = new StringBuilder("");

                strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE"));
                strSQL.Append(" = 'TOTINC'");

                ChooseClause = strSQL.ToString();
            }

            catch (CustomApplicationException ex)
            {
                WriteError(ex);
            }

            catch (Exception ex)
            {
                WriteError(ex);
            }
        }

        #endregion

        #region "Standard Generated Procedures(U115A_0_U115_A_GET_TOTINC_5)"

        #region "Transaction Management Procedures(U115A_0_U115_A_GET_TOTINC_5)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 6/27/2017 2:46:31 PM

        //#-----------------------------------------
        //# InitializeTransactionObjects Procedure.
        //#-----------------------------------------

        protected override void InitializeTransactionObjects()
        {
            try
            {
                m_cnnTRANS_UPDATE = new SqlConnection(Common.GetConnectionString());
                m_cnnTRANS_UPDATE.Open();
                m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
                m_cnnQUERY = new SqlConnection(Common.GetConnectionString());
            }

            catch (CustomApplicationException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;
            }
        }

        //#-----------------------------------------
        //# CloseTransactionObjects Procedure.
        //#-----------------------------------------

        protected override void CloseTransactionObjects()
        {
            try
            {
                CloseFiles();

                if ((m_trnTRANS_UPDATE != null))
                    m_trnTRANS_UPDATE.Dispose();

                if ((m_cnnTRANS_UPDATE != null))
                    m_cnnTRANS_UPDATE.Close();

                if ((m_cnnTRANS_UPDATE != null))
                    m_cnnTRANS_UPDATE.Dispose();

                if ((m_cnnQUERY != null))
                    m_cnnQUERY.Close();

                if ((m_cnnQUERY != null))
                    m_cnnQUERY.Dispose();
            }

            catch (CustomApplicationException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;
            }
        }

        protected override void TRANS_UPDATE(TransactionMethods Method)
        {
            if (Method == TransactionMethods.Rollback)
            {
                m_trnTRANS_UPDATE.Rollback();
            }
            else
            {
                m_trnTRANS_UPDATE.Commit();
            }

            m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
            Initialize_TRANS_UPDATE();
        }

        private void Initialize_TRANS_UPDATE()
        {
            fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;
        }

        #endregion

        #region "FILE Management Procedures(U115A_0_U115_A_GET_TOTINC_5)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 6/27/2017 2:46:31 PM

        //#-----------------------------------------
        //# InitializeFiles Procedure.
        //#-----------------------------------------

        protected override void InitializeFiles()
        {
            try
            {
                Initialize_TRANS_UPDATE();
            }

            catch (CustomApplicationException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;
            }
        }

        //#-----------------------------------------
        //# CloseFiles Procedure.
        //#-----------------------------------------

        protected override void CloseFiles()
        {
            try
            {
                fleF190_COMP_CODES.Dispose();
            }

            catch (CustomApplicationException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;
            }
        }

        #endregion

        #endregion

        #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U115A_0_U115_A_GET_TOTINC_5)"

        public void Run()
        {
            try
            {
                Request("U115A_0_U115_A_GET_TOTINC_5");

                while (fleF190_COMP_CODES.QTPForMissing())
                {
                    // --> GET fleF190_COMP_CODES <--
                    fleF190_COMP_CODES.GetData();
                    // --> End GET fleF190_COMP_CODES <--

                    if (Transaction())
                    {
                        TOTINC_SEQ_RPT.Value = fleF190_COMP_CODES.GetDecimalValue("REPORTING_SEQ");
                        TOTINC_GROUP.Value = fleF190_COMP_CODES.GetStringValue("COMP_CODE_GROUP");
                    }
                }
            }

            catch (CustomApplicationException ex)
            {
                WriteError(ex);
            }

            catch (Exception ex)
            {
                WriteError(ex);
            }

            finally
            {
                EndRequest("U115A_0_U115_A_GET_TOTINC_5");
            }
        }

        #endregion
    }

    public class U115A_0_U115_A_GET_TOTEXP_6 : U115A_0
    {
        public U115A_0_U115_A_GET_TOTEXP_6(string Name, int Level)
            : base(Name, Level, true)
        {
            this.ScreenType = ScreenTypes.QTP;
            fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

            fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;
        }

        #region "Declarations (Variables, Files and Transactions)(U115A_0_U115_A_GET_TOTEXP_6)"

        private SqlFileObject fleF190_COMP_CODES;

        private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
        {
            try
            {
                StringBuilder strSQL = new StringBuilder("");

                strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE"));
                strSQL.Append(" = 'TOTEXP'");

                ChooseClause = strSQL.ToString();
            }

            catch (CustomApplicationException ex)
            {
                WriteError(ex);
            }

            catch (Exception ex)
            {
                WriteError(ex);
            }
        }

        #endregion

        #region "Standard Generated Procedures(U115A_0_U115_A_GET_TOTEXP_6)"

        #region "Transaction Management Procedures(U115A_0_U115_A_GET_TOTEXP_6)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 6/27/2017 2:46:31 PM

        //#-----------------------------------------
        //# InitializeTransactionObjects Procedure.
        //#-----------------------------------------

        protected override void InitializeTransactionObjects()
        {
            try
            {
                m_cnnTRANS_UPDATE = new SqlConnection(Common.GetConnectionString());
                m_cnnTRANS_UPDATE.Open();
                m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
                m_cnnQUERY = new SqlConnection(Common.GetConnectionString());
            }

            catch (CustomApplicationException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;
            }
        }

        //#-----------------------------------------
        //# CloseTransactionObjects Procedure.
        //#-----------------------------------------

        protected override void CloseTransactionObjects()
        {
            try
            {
                CloseFiles();

                if ((m_trnTRANS_UPDATE != null))
                    m_trnTRANS_UPDATE.Dispose();

                if ((m_cnnTRANS_UPDATE != null))
                    m_cnnTRANS_UPDATE.Close();

                if ((m_cnnTRANS_UPDATE != null))
                    m_cnnTRANS_UPDATE.Dispose();

                if ((m_cnnQUERY != null))
                    m_cnnQUERY.Close();

                if ((m_cnnQUERY != null))
                    m_cnnQUERY.Dispose();
            }

            catch (CustomApplicationException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;
            }
        }

        protected override void TRANS_UPDATE(TransactionMethods Method)
        {
            if (Method == TransactionMethods.Rollback)
            {
                m_trnTRANS_UPDATE.Rollback();
            }
            else
            {
                m_trnTRANS_UPDATE.Commit();
            }

            m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
            Initialize_TRANS_UPDATE();
        }

        private void Initialize_TRANS_UPDATE()
        {
            fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;
        }

        #endregion

        #region "FILE Management Procedures(U115A_0_U115_A_GET_TOTEXP_6)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 6/27/2017 2:46:31 PM

        //#-----------------------------------------
        //# InitializeFiles Procedure.
        //#-----------------------------------------

        protected override void InitializeFiles()
        {
            try
            {
                Initialize_TRANS_UPDATE();
            }

            catch (CustomApplicationException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;
            }
        }

        //#-----------------------------------------
        //# CloseFiles Procedure.
        //#-----------------------------------------

        protected override void CloseFiles()
        {
            try
            {
                fleF190_COMP_CODES.Dispose();
            }

            catch (CustomApplicationException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;
            }
        }

        #endregion

        #endregion

        #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U115A_0_U115_A_GET_TOTEXP_6)"

        public void Run()
        {
            try
            {
                Request("U115A_0_U115_A_GET_TOTEXP_6");

                while (fleF190_COMP_CODES.QTPForMissing())
                {
                    // --> GET fleF190_COMP_CODES <--
                    fleF190_COMP_CODES.GetData();
                    // --> End GET fleF190_COMP_CODES <--

                    if (Transaction())
                    {
                        TOTEXP_SEQ_RPT.Value = fleF190_COMP_CODES.GetDecimalValue("REPORTING_SEQ");
                        TOTEXP_GROUP.Value = fleF190_COMP_CODES.GetStringValue("COMP_CODE_GROUP");
                    }
                }
            }

            catch (CustomApplicationException ex)
            {
                WriteError(ex);
            }

            catch (Exception ex)
            {
                WriteError(ex);
            }

            finally
            {
                EndRequest("U115A_0_U115_A_GET_TOTEXP_6");
            }
        }

        #endregion
    }

    public class U115A_0_U115_A_GET_DEPEXR_7 : U115A_0
    {
        public U115A_0_U115_A_GET_DEPEXR_7(string Name, int Level)
            : base(Name, Level, true)
        {
            this.ScreenType = ScreenTypes.QTP;
            fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

            fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;
        }

        #region "Declarations (Variables, Files and Transactions)(U115A_0_U115_A_GET_DEPEXR_7)"

        private SqlFileObject fleF190_COMP_CODES;

        private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
        {
            try
            {
                StringBuilder strSQL = new StringBuilder("");

                strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE"));
                strSQL.Append(" = 'DEPEXR'");

                ChooseClause = strSQL.ToString();
            }

            catch (CustomApplicationException ex)
            {
                WriteError(ex);
            }

            catch (Exception ex)
            {
                WriteError(ex);
            }
        }

        #endregion

        #region "Standard Generated Procedures(U115A_0_U115_A_GET_DEPEXR_7)"

        #region "Transaction Management Procedures(U115A_0_U115_A_GET_DEPEXR_7)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 6/27/2017 2:46:31 PM

        //#-----------------------------------------
        //# InitializeTransactionObjects Procedure.
        //#-----------------------------------------

        protected override void InitializeTransactionObjects()
        {
            try
            {
                m_cnnTRANS_UPDATE = new SqlConnection(Common.GetConnectionString());
                m_cnnTRANS_UPDATE.Open();
                m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
                m_cnnQUERY = new SqlConnection(Common.GetConnectionString());
            }

            catch (CustomApplicationException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;
            }
        }

        //#-----------------------------------------
        //# CloseTransactionObjects Procedure.
        //#-----------------------------------------

        protected override void CloseTransactionObjects()
        {
            try
            {
                CloseFiles();

                if ((m_trnTRANS_UPDATE != null))
                    m_trnTRANS_UPDATE.Dispose();

                if ((m_cnnTRANS_UPDATE != null))
                    m_cnnTRANS_UPDATE.Close();

                if ((m_cnnTRANS_UPDATE != null))
                    m_cnnTRANS_UPDATE.Dispose();

                if ((m_cnnQUERY != null))
                    m_cnnQUERY.Close();

                if ((m_cnnQUERY != null))
                    m_cnnQUERY.Dispose();
            }

            catch (CustomApplicationException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;
            }
        }

        protected override void TRANS_UPDATE(TransactionMethods Method)
        {
            if (Method == TransactionMethods.Rollback)
            {
                m_trnTRANS_UPDATE.Rollback();
            }
            else
            {
                m_trnTRANS_UPDATE.Commit();
            }

            m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
            Initialize_TRANS_UPDATE();
        }

        private void Initialize_TRANS_UPDATE()
        {
            fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;
        }

        #endregion

        #region "FILE Management Procedures(U115A_0_U115_A_GET_DEPEXR_7)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 6/27/2017 2:46:31 PM

        //#-----------------------------------------
        //# InitializeFiles Procedure.
        //#-----------------------------------------

        protected override void InitializeFiles()
        {
            try
            {
                Initialize_TRANS_UPDATE();
            }

            catch (CustomApplicationException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;
            }
        }

        //#-----------------------------------------
        //# CloseFiles Procedure.
        //#-----------------------------------------

        protected override void CloseFiles()
        {
            try
            {
                fleF190_COMP_CODES.Dispose();
            }

            catch (CustomApplicationException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;
            }
        }

        #endregion

        #endregion

        #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U115A_0_U115_A_GET_DEPEXR_7)"

        public void Run()
        {
            try
            {
                Request("U115A_0_U115_A_GET_DEPEXR_7");

                while (fleF190_COMP_CODES.QTPForMissing())
                {
                    // --> GET fleF190_COMP_CODES <--
                    fleF190_COMP_CODES.GetData();
                    // --> End GET fleF190_COMP_CODES <--

                    if (Transaction())
                    {
                        DEPEXR_SEQ_RPT.Value = fleF190_COMP_CODES.GetDecimalValue("REPORTING_SEQ");
                        DEPEXR_GROUP.Value = fleF190_COMP_CODES.GetStringValue("COMP_CODE_GROUP");
                    }
                }
            }

            catch (CustomApplicationException ex)
            {
                WriteError(ex);
            }

            catch (Exception ex)
            {
                WriteError(ex);
            }

            finally
            {
                EndRequest("U115A_0_U115_A_GET_DEPEXR_7");
            }
        }

        #endregion
    }

    public class U115A_0_U115_A_GET_DEPEXM_8 : U115A_0
    {
        public U115A_0_U115_A_GET_DEPEXM_8(string Name, int Level)
            : base(Name, Level, true)
        {
            this.ScreenType = ScreenTypes.QTP;
            fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

            fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;
        }

        #region "Declarations (Variables, Files and Transactions)(U115A_0_U115_A_GET_DEPEXM_8)"

        private SqlFileObject fleF190_COMP_CODES;

        private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
        {
            try
            {
                StringBuilder strSQL = new StringBuilder("");

                strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE"));
                strSQL.Append(" = 'DEPEXM'");

                ChooseClause = strSQL.ToString();
            }

            catch (CustomApplicationException ex)
            {
                WriteError(ex);
            }

            catch (Exception ex)
            {
                WriteError(ex);
            }
        }

        #endregion

        #region "Standard Generated Procedures(U115A_0_U115_A_GET_DEPEXM_8)"

        #region "Transaction Management Procedures(U115A_0_U115_A_GET_DEPEXM_8)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 6/27/2017 2:46:31 PM

        //#-----------------------------------------
        //# InitializeTransactionObjects Procedure.
        //#-----------------------------------------

        protected override void InitializeTransactionObjects()
        {
            try
            {
                m_cnnTRANS_UPDATE = new SqlConnection(Common.GetConnectionString());
                m_cnnTRANS_UPDATE.Open();
                m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
                m_cnnQUERY = new SqlConnection(Common.GetConnectionString());
            }

            catch (CustomApplicationException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;
            }
        }

        //#-----------------------------------------
        //# CloseTransactionObjects Procedure.
        //#-----------------------------------------

        protected override void CloseTransactionObjects()
        {
            try
            {
                CloseFiles();

                if ((m_trnTRANS_UPDATE != null))
                    m_trnTRANS_UPDATE.Dispose();

                if ((m_cnnTRANS_UPDATE != null))
                    m_cnnTRANS_UPDATE.Close();

                if ((m_cnnTRANS_UPDATE != null))
                    m_cnnTRANS_UPDATE.Dispose();

                if ((m_cnnQUERY != null))
                    m_cnnQUERY.Close();

                if ((m_cnnQUERY != null))
                    m_cnnQUERY.Dispose();
            }

            catch (CustomApplicationException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;
            }
        }

        protected override void TRANS_UPDATE(TransactionMethods Method)
        {
            if (Method == TransactionMethods.Rollback)
            {
                m_trnTRANS_UPDATE.Rollback();
            }
            else
            {
                m_trnTRANS_UPDATE.Commit();
            }

            m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
            Initialize_TRANS_UPDATE();
        }

        private void Initialize_TRANS_UPDATE()
        {
            fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;
        }

        #endregion

        #region "FILE Management Procedures(U115A_0_U115_A_GET_DEPEXM_8)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 6/27/2017 2:46:31 PM

        //#-----------------------------------------
        //# InitializeFiles Procedure.
        //#-----------------------------------------

        protected override void InitializeFiles()
        {
            try
            {
                Initialize_TRANS_UPDATE();
            }

            catch (CustomApplicationException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;
            }
        }

        //#-----------------------------------------
        //# CloseFiles Procedure.
        //#-----------------------------------------

        protected override void CloseFiles()
        {
            try
            {
                fleF190_COMP_CODES.Dispose();
            }

            catch (CustomApplicationException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;
            }
        }

        #endregion

        #endregion

        #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U115A_0_U115_A_GET_DEPEXM_8)"

        public void Run()
        {
            try
            {
                Request("U115A_0_U115_A_GET_DEPEXM_8");

                while (fleF190_COMP_CODES.QTPForMissing())
                {
                    // --> GET fleF190_COMP_CODES <--
                    fleF190_COMP_CODES.GetData();
                    // --> End GET fleF190_COMP_CODES <--

                    if (Transaction())
                    {
                        DEPEXM_GROUP.Value = fleF190_COMP_CODES.GetStringValue("COMP_CODE_GROUP");
                        DEPEXM_SEQ_RPT.Value = fleF190_COMP_CODES.GetDecimalValue("REPORTING_SEQ");
                    }
                }
            }

            catch (CustomApplicationException ex)
            {
                WriteError(ex);
            }

            catch (Exception ex)
            {
                WriteError(ex);
            }

            finally
            {
                EndRequest("U115A_0_U115_A_GET_DEPEXM_8");
            }
        }

        #endregion
    }

    public class U115A_0_U115_A_GET_GST_9 : U115A_0
    {
        public U115A_0_U115_A_GET_GST_9(string Name, int Level)
            : base(Name, Level, true)
        {
            this.ScreenType = ScreenTypes.QTP;
            fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

            fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;
        }

        #region "Declarations (Variables, Files and Transactions)(U115A_0_U115_A_GET_GST_9)"

        private SqlFileObject fleF190_COMP_CODES;

        private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
        {
            try
            {
                StringBuilder strSQL = new StringBuilder("");

                strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE"));
                strSQL.Append(" = 'GST'");

                ChooseClause = strSQL.ToString();
            }

            catch (CustomApplicationException ex)
            {
                WriteError(ex);
            }

            catch (Exception ex)
            {
                WriteError(ex);
            }
        }

        #endregion

        #region "Standard Generated Procedures(U115A_0_U115_A_GET_GST_9)"

        #region "Transaction Management Procedures(U115A_0_U115_A_GET_GST_9)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 6/27/2017 2:46:31 PM

        //#-----------------------------------------
        //# InitializeTransactionObjects Procedure.
        //#-----------------------------------------

        protected override void InitializeTransactionObjects()
        {
            try
            {
                m_cnnTRANS_UPDATE = new SqlConnection(Common.GetConnectionString());
                m_cnnTRANS_UPDATE.Open();
                m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
                m_cnnQUERY = new SqlConnection(Common.GetConnectionString());
            }

            catch (CustomApplicationException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;
            }
        }

        //#-----------------------------------------
        //# CloseTransactionObjects Procedure.
        //#-----------------------------------------

        protected override void CloseTransactionObjects()
        {
            try
            {
                CloseFiles();

                if ((m_trnTRANS_UPDATE != null))
                    m_trnTRANS_UPDATE.Dispose();

                if ((m_cnnTRANS_UPDATE != null))
                    m_cnnTRANS_UPDATE.Close();

                if ((m_cnnTRANS_UPDATE != null))
                    m_cnnTRANS_UPDATE.Dispose();

                if ((m_cnnQUERY != null))
                    m_cnnQUERY.Close();

                if ((m_cnnQUERY != null))
                    m_cnnQUERY.Dispose();
            }

            catch (CustomApplicationException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;
            }
        }

        protected override void TRANS_UPDATE(TransactionMethods Method)
        {
            if (Method == TransactionMethods.Rollback)
            {
                m_trnTRANS_UPDATE.Rollback();
            }
            else
            {
                m_trnTRANS_UPDATE.Commit();
            }

            m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
            Initialize_TRANS_UPDATE();
        }

        private void Initialize_TRANS_UPDATE()
        {
            fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;
        }

        #endregion

        #region "FILE Management Procedures(U115A_0_U115_A_GET_GST_9)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 6/27/2017 2:46:31 PM

        //#-----------------------------------------
        //# InitializeFiles Procedure.
        //#-----------------------------------------

        protected override void InitializeFiles()
        {
            try
            {
                Initialize_TRANS_UPDATE();
            }

            catch (CustomApplicationException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;
            }
        }

        //#-----------------------------------------
        //# CloseFiles Procedure.
        //#-----------------------------------------

        protected override void CloseFiles()
        {
            try
            {
                fleF190_COMP_CODES.Dispose();
            }

            catch (CustomApplicationException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;
            }
        }

        #endregion

        #endregion

        #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U115A_0_U115_A_GET_GST_9)"

        public void Run()
        {
            try
            {
                Request("U115A_0_U115_A_GET_GST_9");

                while (fleF190_COMP_CODES.QTPForMissing())
                {
                    // --> GET fleF190_COMP_CODES <--
                    fleF190_COMP_CODES.GetData();
                    // --> End GET fleF190_COMP_CODES <--

                    if (Transaction())
                    {
                        GST_GROUP.Value = fleF190_COMP_CODES.GetStringValue("COMP_CODE_GROUP");
                        GST_SEQ_RPT.Value = fleF190_COMP_CODES.GetDecimalValue("REPORTING_SEQ");
                    }
                }
            }

            catch (CustomApplicationException ex)
            {
                WriteError(ex);
            }

            catch (Exception ex)
            {
                WriteError(ex);
            }

            finally
            {
                EndRequest("U115A_0_U115_A_GET_GST_9");
            }
        }

        #endregion
    }

    public class U115A_0_U115_A_GET_HOLDBACK_10 : U115A_0
    {
        public U115A_0_U115_A_GET_HOLDBACK_10(string Name, int Level)
            : base(Name, Level, true)
        {
            this.ScreenType = ScreenTypes.QTP;
            fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

            fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;
        }

        #region "Declarations (Variables, Files and Transactions)(U115A_0_U115_A_GET_HOLDBACK_10)"

        private SqlFileObject fleF190_COMP_CODES;

        private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
        {
            try
            {
                StringBuilder strSQL = new StringBuilder("");

                strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE"));
                strSQL.Append(" = 'HOLDBK'");

                ChooseClause = strSQL.ToString();
            }

            catch (CustomApplicationException ex)
            {
                WriteError(ex);
            }

            catch (Exception ex)
            {
                WriteError(ex);
            }
        }

        #endregion

        #region "Standard Generated Procedures(U115A_0_U115_A_GET_HOLDBACK_10)"

        #region "Transaction Management Procedures(U115A_0_U115_A_GET_HOLDBACK_10)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 6/27/2017 2:46:31 PM

        //#-----------------------------------------
        //# InitializeTransactionObjects Procedure.
        //#-----------------------------------------

        protected override void InitializeTransactionObjects()
        {
            try
            {
                m_cnnTRANS_UPDATE = new SqlConnection(Common.GetConnectionString());
                m_cnnTRANS_UPDATE.Open();
                m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
                m_cnnQUERY = new SqlConnection(Common.GetConnectionString());
            }

            catch (CustomApplicationException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;
            }
        }

        //#-----------------------------------------
        //# CloseTransactionObjects Procedure.
        //#-----------------------------------------

        protected override void CloseTransactionObjects()
        {
            try
            {
                CloseFiles();

                if ((m_trnTRANS_UPDATE != null))
                    m_trnTRANS_UPDATE.Dispose();

                if ((m_cnnTRANS_UPDATE != null))
                    m_cnnTRANS_UPDATE.Close();

                if ((m_cnnTRANS_UPDATE != null))
                    m_cnnTRANS_UPDATE.Dispose();

                if ((m_cnnQUERY != null))
                    m_cnnQUERY.Close();

                if ((m_cnnQUERY != null))
                    m_cnnQUERY.Dispose();
            }

            catch (CustomApplicationException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;
            }
        }

        protected override void TRANS_UPDATE(TransactionMethods Method)
        {
            if (Method == TransactionMethods.Rollback)
            {
                m_trnTRANS_UPDATE.Rollback();
            }
            else
            {
                m_trnTRANS_UPDATE.Commit();
            }

            m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
            Initialize_TRANS_UPDATE();
        }

        private void Initialize_TRANS_UPDATE()
        {
            fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;
        }

        #endregion

        #region "FILE Management Procedures(U115A_0_U115_A_GET_HOLDBACK_10)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 6/27/2017 2:46:31 PM

        //#-----------------------------------------
        //# InitializeFiles Procedure.
        //#-----------------------------------------

        protected override void InitializeFiles()
        {
            try
            {
                Initialize_TRANS_UPDATE();
            }

            catch (CustomApplicationException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;
            }
        }

        //#-----------------------------------------
        //# CloseFiles Procedure.
        //#-----------------------------------------

        protected override void CloseFiles()
        {
            try
            {
                fleF190_COMP_CODES.Dispose();
            }

            catch (CustomApplicationException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;
            }
        }

        #endregion

        #endregion

        #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U115A_0_U115_A_GET_HOLDBACK_10)"

        public void Run()
        {
            try
            {
                Request("U115A_0_U115_A_GET_HOLDBACK_10");

                while (fleF190_COMP_CODES.QTPForMissing())
                {
                    // --> GET fleF190_COMP_CODES <--
                    fleF190_COMP_CODES.GetData();
                    // --> End GET fleF190_COMP_CODES <--

                    if (Transaction())
                    {
                        HOLDBACK_GROUP.Value = fleF190_COMP_CODES.GetStringValue("COMP_CODE_GROUP");
                        HOLDBACK_SEQ_RPT.Value = fleF190_COMP_CODES.GetDecimalValue("REPORTING_SEQ");
                    }
                }
            }

            catch (CustomApplicationException ex)
            {
                WriteError(ex);
            }

            catch (Exception ex)
            {
                WriteError(ex);
            }

            finally
            {
                EndRequest("U115A_0_U115_A_GET_HOLDBACK_10");
            }
        }

        #endregion
    }

    public class U115A_0_U115_RUN_0_11 : U115A_0
    {
        public U115A_0_U115_RUN_0_11(string Name, int Level)
            : base(Name, Level, true)
        {
            this.ScreenType = ScreenTypes.QTP;
            fleF119_DOCTOR_YTD = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F119_DOCTOR_YTD", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
           fleF116_GROUP = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F116_DEPT_EXPENSE_RULES_DTL", "F116_GROUP", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleDEBUGU115A0_AT_COMP_CODE = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "DEBUGU115A0_AT_COMP_CODE", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleDEBUGU115A0_AT_DOC_NBR = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "DEBUGU115A0_AT_DOC_NBR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF119_TITHE_DTL = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F119_TITHE_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF119_DOC_SUMM = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F119_TITHE_DTL", "F119_DOC_SUMM", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF119_TOTIT_DOC = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F119_TITHE_DTL", "F119_TOTIT_DOC", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF119_TOTIT_SUMM = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F119_TITHE_DTL", "F119_TOTIT_SUMM ", false, false, false, 0, "m_trnTRANS_UPDATE");

            //fleU115A0_MC = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U115A0_MC", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            TOT_INCOME_GROSS_REG = new CoreInteger("TOT_INCOME_GROSS_REG", 10, this);
            TOT_INCOME_GROSS_MISC = new CoreInteger("TOT_INCOME_GROSS_MISC", 10, this);
            TOT_INCOME_GROSS_OTHER = new CoreInteger("TOT_INCOME_GROSS_OTHER", 10, this);
            TOT_INCOME_NET_REG = new CoreInteger("TOT_INCOME_NET_REG", 10, this);
            TOT_INCOME_NET_MISC = new CoreInteger("TOT_INCOME_NET_MISC", 10, this);
            TOT_INCOME_NET_OTHER = new CoreInteger("TOT_INCOME_NET_OTHER", 10, this);
            TOT_TITHE_GROSS_REG = new CoreInteger("TOT_TITHE_GROSS_REG", 10, this);
            TOT_TITHE_GROSS_MISC = new CoreInteger("TOT_TITHE_GROSS_MISC", 10, this);
            TOT_TITHE_GROSS_OTHER = new CoreInteger("TOT_TITHE_GROSS_OTHER", 10, this);
            TOT_TITHE_NET_REG = new CoreInteger("TOT_TITHE_NET_REG", 10, this);
            TOT_TITHE_NET_MISC = new CoreInteger("TOT_TITHE_NET_MISC", 10, this);
            TOT_TITHE_NET_OTHER = new CoreInteger("TOT_TITHE_NET_OTHER", 10, this);
            TOT_DEPT_EXPENSE_REG = new CoreInteger("TOT_DEPT_EXPENSE_REG", 10, this);
            TOT_DEPT_EXPENSE_MISC = new CoreInteger("TOT_DEPT_EXPENSE_MISC", 10, this);
            TOT_RMA_EXPENSE_PLUS_GST_REG = new CoreInteger("TOT_RMA_EXPENSE_PLUS_GST_REG", 10, this);
            TOT_RMA_EXPENSE_PLUS_GST_MISC = new CoreInteger("TOT_RMA_EXPENSE_PLUS_GST_MISC", 10, this);
            TOT_RMA_EXPENSE_ONLY_REG = new CoreInteger("TOT_RMA_EXPENSE_ONLY_REG", 10, this);
            TOT_RMA_EXPENSE_ONLY_MISC = new CoreInteger("TOT_RMA_EXPENSE_ONLY_MISC", 10, this);
            TOT_GST_ONLY_REG = new CoreInteger("TOT_GST_ONLY_REG", 10, this);
            TOT_GST_ONLY_MISC = new CoreInteger("TOT_GST_ONLY_MISC", 10, this);
            TOT_HOLDBACK_ONLY_REG = new CoreInteger("TOT_HOLDBACK_ONLY_REG", 10, this);
            TOT_HOLDBACK_ONLY_MISC = new CoreInteger("TOT_HOLDBACK_ONLY_MISC", 10, this);
            TOT_REVHBK = new CoreInteger("TOT_REVHBK", 10, this);
            AMT_MANPAY = new CoreInteger("AMT_MANPAY", 10, this);
            FINAL_ALL_EXPENSES = new CoreInteger("FINAL_ALL_EXPENSES", 10, this);
            AMT_INCOME_MINUS_EXPENSES_G = new CoreInteger("AMT_INCOME_MINUS_EXPENSES_G", 10, this);
            DOC_YTDEAR_PLUS_AMT_MANPAY = new CoreInteger("DOC_YTDEAR_PLUS_AMT_MANPAY", 10, this);

            GST_PERCENT.GetValue += GST_PERCENT_GetValue;
            X_INCOME_GROSS_MINUS_NET.GetValue += X_INCOME_GROSS_MINUS_NET_GetValue;
            TOT_DEPT_EXPENSE_OTHER.GetValue += TOT_DEPT_EXPENSE_OTHER_GetValue;
            X_AMT_DEPT_EXPENSE_POT_G.GetValue += X_AMT_DEPT_EXPENSE_POT_G_GetValue;
            X_AMT_DEPT_EXPENSE_G.GetValue += X_AMT_DEPT_EXPENSE_G_GetValue;
            X_AMT_RMA_EXPENSE_POT_G.GetValue += X_AMT_RMA_EXPENSE_POT_G_GetValue;
            X_AMT_RMA_EXPENSE_ONLY.GetValue += X_AMT_RMA_EXPENSE_ONLY_GetValue;
            X_AMT_ROUND_OFF.GetValue += X_AMT_ROUND_OFF_GetValue;
            X_AMT_GST_ONLY.GetValue += X_AMT_GST_ONLY_GetValue;
            X_AMT_RMA_EXPENSE_PLUS_GST_G.GetValue += X_AMT_RMA_EXPENSE_PLUS_GST_G_GetValue;
            X_AMT_HOLDBACK_G.GetValue += X_AMT_HOLDBACK_G_GetValue;
            X_AMT_HOLDBACK_FINAL.GetValue += X_AMT_HOLDBACK_FINAL_GetValue;
            X_AMT_RMA_EXPENSE_FINAL.GetValue += X_AMT_RMA_EXPENSE_FINAL_GetValue;
            X_AMT_DEPT_EXPENSE_FINAL.GetValue += X_AMT_DEPT_EXPENSE_FINAL_GetValue;
            X_AMT_RMA_EXPENSE_PLUSGST_FINAL.GetValue += X_AMT_RMA_EXPENSE_PLUSGST_FINAL_GetValue;
            X_REC_TYPE.GetValue += X_REC_TYPE_GetValue;
            REC_TYPE.GetValue += REC_TYPE_GetValue;
            X_NOT_NEEDED.GetValue += X_NOT_NEEDED_GetValue;
            X_AMT_NET.GetValue += X_AMT_NET_GetValue;
            X_AMT_GROSS.GetValue += X_AMT_GROSS_GetValue;
            TOT_GST_ONLY.GetValue += TOT_GST_ONLY_GetValue;
            TOT_HOLDBACK_ONLY.GetValue += TOT_HOLDBACK_ONLY_GetValue;
            TOT_INCOME_GROSS.GetValue += TOT_INCOME_GROSS_GetValue;
            TOT_INCOME_NET.GetValue += TOT_INCOME_NET_GetValue;
            REC_TYPE_D.GetValue += REC_TYPE_D_GetValue;
            DOC_NBR_SUMM.GetValue += DOC_NBR_SUMM_GetValue;
            X_COMP_CODE_TOTIT.GetValue += X_COMP_CODE_TOTIT_GetValue;
            TOTIT_SEQ_RPT.GetValue += TOTIT_SEQ_RPT_GetValue;
            TOTIT_GROUP.GetValue += TOTIT_GROUP_GetValue;
            TOT_TITHE_GROSS.GetValue += TOT_TITHE_GROSS_GetValue;
            TOT_TITHE_NET.GetValue += TOT_TITHE_NET_GetValue;
        fleF119_DOCTOR_YTD.SelectIf += fleF119_DOCTOR_YTD_SelectIf;

            X_AMT_NET_DTL.GetValue += X_AMT_NET_DTL_GetValue;
            X_AMT_GROSS_DTL.GetValue += X_AMT_GROSS_DTL_GetValue;

        }

        #region "Declarations (Variables, Files and Transactions)(U115A_0_U115_RUN_0_11)"

        private SqlFileObject fleF119_DOCTOR_YTD;

        private void fleF119_DOCTOR_YTD_SelectIf(ref string SelectIfClause)
        {
            try
            {
                StringBuilder strSQL = new StringBuilder("");

                strSQL.Append("(").Append(fleF119_DOCTOR_YTD.ElementOwner("REC_TYPE")).Append(" = 'D')");

                SelectIfClause = strSQL.ToString();
            }

            catch (CustomApplicationException ex)
            {
                WriteError(ex);
            }

            catch (Exception ex)
            {
                WriteError(ex);
            }
        }

        private SqlFileObject fleF020_DOCTOR_MSTR;
        private SqlFileObject fleF116_GROUP;
       
        private SqlFileObject fleF190_COMP_CODES;

        private DDecimal GST_PERCENT = new DDecimal("GST_PERCENT", 8);
        private void GST_PERCENT_GetValue(ref decimal Value)
        {
            try
            {
                Value = 13;
            }

            catch (CustomApplicationException ex)
            {
                WriteError(ex);
            }

            catch (Exception ex)
            {
                WriteError(ex);
            }
        }

        //Use file U115_COMMON_F119.QTS
        //; DATE WHO  WHY
        //; 2004/mar/25 b.e.made common to u115a/b.qts   
        //; 2006/mar/20 b.e. while testing a comp code with a factor of 0 (shows amount
        //;		   in gross but pays nothing by turning net to zero) it was
        //; discovered that the old 'hold back' feature used in mid-90's
        //;		   was kicking in and generating a HOLDBK comp code for the 
        //;		   gross amount.The calculation of this hold back amount
        //; changed to always be zero so that it won't intefere with
        //;		   using a factor of 0.00
        //;		   - set to zero by adding a condition 1 = 2 to logic
        //; 2006/jun/09 b.e. - UNDID THE ABOVE CHANGE SO THAT HOLDBK AGAIN CALCULATED
        //; 2006/jun/22 b.e.after change in size of field there occcured rounding
        //; problem giving .01 difference..changed from > to = in calc of x-amt-gst-only
        //; 2008/jun/05 M.C. - modify criteria for tot-income-gross-reg, tot-income-gross-misc &
        //;			tot-income-gross-other, create tot-tithe-gross-reg,
        //;			tot-tithe-gross-misc & tot-tithe-gross-other
        //;		   - apply the same to tot-income-net-reg/misc/other, and
        //;		     tot-tithe-net-reg/misc/other
        //; 2008/jul/02 brad1 - add code to catch TITHE expenese - above not working
        //; 2008/jul/02 brad2 - added check that comp-type is I'ncome type when incuding
        //;		      in calculation of:
        //; tot-income-gross-reg/misc/other
        //;		      and tot-income-net-reg/misc/other
        //;		      and tot-tithe-gross-reg/misc/other
        //;		      and tot-tithe-net-reg/misc/other
        //; 2008/sep/29 MC    - clone from u115_coomon.qts
        //;		    - change to reference to f119 instead of 110

        //; ----------- CALCULATIONS PERFORMED AT COMP-CODE LEVEL ------------

        //; (Determine Expenses charged(difference between GROSS and NET) using
        //;  FACTOR or non-zero Expense Percentages as indicators as to type of charges
        //; applied)

        private DDecimal X_INCOME_GROSS_MINUS_NET = new DDecimal("X_INCOME_GROSS_MINUS_NET", 8);
        private void X_INCOME_GROSS_MINUS_NET_GetValue(ref decimal Value)
        {
            try
            {
                Value = fleF119_DOCTOR_YTD.GetDecimalValue("AMT_MTD") - fleF119_DOCTOR_YTD.GetDecimalValue("AMT_MTD");
            }

            catch (CustomApplicationException ex)
            {
                WriteError(ex);
            }

            catch (Exception ex)
            {
                WriteError(ex);
            }
        }

        private DDecimal TOT_DEPT_EXPENSE_OTHER = new DDecimal("TOT_DEPT_EXPENSE_OTHER", 8);
        private void TOT_DEPT_EXPENSE_OTHER_GetValue(ref decimal Value)
        {
            try
            {
                if (fleF190_COMP_CODES.GetStringValue("COMP_TYPE") == "E" && fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE") == "O")
                {
                    Value = QDesign.Round((fleF119_DOCTOR_YTD.GetDecimalValue("AMT_MTD")));
                }
            }

            catch (CustomApplicationException ex)
            {
                WriteError(ex);
            }

            catch (Exception ex)
            {
                WriteError(ex);
            }
        }

        private DDecimal X_AMT_DEPT_EXPENSE_POT_G = new DDecimal("X_AMT_DEPT_EXPENSE_POT_G", 8);
        private void X_AMT_DEPT_EXPENSE_POT_G_GetValue(ref decimal Value)
        {
            try
            {
                decimal CurrentValue = 0m;

                if (fleF190_COMP_CODES.GetStringValue("COMP_TYPE") == "I" && fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE") == "R" && (!fleF116_GROUP.Exists() || (fleF116_GROUP.Exists() && fleF116_GROUP.GetStringValue("TITHE_IN_EX_CLUDE_FLAG") == "E") || (fleF116_GROUP.Exists() && fleF116_GROUP.GetStringValue("TITHE_IN_EX_CLUDE_FLAG") == "I" && fleF116_GROUP.GetStringValue("FLAG_DISPLAY_HIDE") == "N")))
                {
                    CurrentValue = QDesign.Round((fleF119_DOCTOR_YTD.GetDecimalValue("AMT_MTD") / 1000000) * QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_REG")), 0, RoundOptionTypes.Near);
                }
                else if (fleF190_COMP_CODES.GetStringValue("COMP_TYPE") == "I" && fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE") == "M" && (!fleF116_GROUP.Exists() || (fleF116_GROUP.Exists() && fleF116_GROUP.GetStringValue("TITHE_IN_EX_CLUDE_FLAG") == "E") || (fleF116_GROUP.Exists() && fleF116_GROUP.GetStringValue("TITHE_IN_EX_CLUDE_FLAG") == "I" && fleF116_GROUP.GetStringValue("FLAG_DISPLAY_HIDE") == "N")))
                {
                    CurrentValue = QDesign.Round((fleF119_DOCTOR_YTD.GetDecimalValue("AMT_MTD") / 1000000) * QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_MISC")), 0, RoundOptionTypes.Near);
                }
                else
                {
                    CurrentValue = 0;
                }

                Value = CurrentValue;
            }

            catch (CustomApplicationException ex)
            {
                WriteError(ex);
            }

            catch (Exception ex)
            {
                WriteError(ex);
            }
        }

        private DDecimal X_AMT_DEPT_EXPENSE_G = new DDecimal("X_AMT_DEPT_EXPENSE_G", 8);
        private void X_AMT_DEPT_EXPENSE_G_GetValue(ref decimal Value)
        {
            try
            {
                decimal CurrentValue = 0m;

                if ((X_AMT_DEPT_EXPENSE_POT_G.Value < X_INCOME_GROSS_MINUS_NET.Value && QDesign.NULL(fleF119_DOCTOR_YTD.GetDecimalValue("AMT_MTD")) > 0) || (X_AMT_DEPT_EXPENSE_POT_G.Value > X_INCOME_GROSS_MINUS_NET.Value && QDesign.NULL(fleF119_DOCTOR_YTD.GetDecimalValue("AMT_MTD")) < 0))
                {
                    CurrentValue = X_AMT_DEPT_EXPENSE_POT_G.Value;
                }
                else
                {
                    CurrentValue = X_INCOME_GROSS_MINUS_NET.Value;
                }

                Value = CurrentValue;
            }

            catch (CustomApplicationException ex)
            {
                WriteError(ex);
            }

            catch (Exception ex)
            {
                WriteError(ex);
            }
        }

        private DDecimal X_AMT_RMA_EXPENSE_POT_G = new DDecimal("X_AMT_RMA_EXPENSE_POT_G", 8);
        private void X_AMT_RMA_EXPENSE_POT_G_GetValue(ref decimal Value)
        {
            try
            {
                decimal CurrentValue = 0m;

                if (fleF190_COMP_CODES.GetStringValue("COMP_TYPE") == "I" && fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE") == "R" && (!fleF116_GROUP.Exists() || (fleF116_GROUP.Exists() && fleF116_GROUP.GetStringValue("TITHE_IN_EX_CLUDE_FLAG") == "E") || (fleF116_GROUP.Exists() && fleF116_GROUP.GetStringValue("TITHE_IN_EX_CLUDE_FLAG") == "I" && fleF116_GROUP.GetStringValue("FLAG_DISPLAY_HIDE") == "N")))
                {
                    CurrentValue = QDesign.Round((fleF119_DOCTOR_YTD.GetDecimalValue("AMT_MTD") / 1000000) * QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_REG")), 0, RoundOptionTypes.Near);
                }
                else if (fleF190_COMP_CODES.GetStringValue("COMP_TYPE") == "I" && fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE") == "M" && (!fleF116_GROUP.Exists() || (fleF116_GROUP.Exists() && fleF116_GROUP.GetStringValue("TITHE_IN_EX_CLUDE_FLAG") == "E") || (fleF116_GROUP.Exists() && fleF116_GROUP.GetStringValue("TITHE_IN_EX_CLUDE_FLAG") == "I" && fleF116_GROUP.GetStringValue("FLAG_DISPLAY_HIDE") == "N")))
                {
                    CurrentValue = QDesign.Round((fleF119_DOCTOR_YTD.GetDecimalValue("AMT_MTD") / 1000000) * QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_MISC")), 0, RoundOptionTypes.Near);
                }
                else
                {
                    CurrentValue = 0;
                }

                Value = CurrentValue;
            }

            catch (CustomApplicationException ex)
            {
                WriteError(ex);
            }

            catch (Exception ex)
            {
                WriteError(ex);
            }
        }

        private DDecimal X_AMT_RMA_EXPENSE_ONLY = new DDecimal("X_AMT_RMA_EXPENSE_ONLY", 8);
        private void X_AMT_RMA_EXPENSE_ONLY_GetValue(ref decimal Value)
        {
            try
            {
                decimal CurrentValue = 0m;

                if ((X_INCOME_GROSS_MINUS_NET.Value > (X_AMT_DEPT_EXPENSE_G.Value + X_AMT_RMA_EXPENSE_POT_G.Value) && QDesign.NULL(fleF119_DOCTOR_YTD.GetDecimalValue("AMT_MTD")) > 0) || (X_INCOME_GROSS_MINUS_NET.Value < (X_AMT_DEPT_EXPENSE_G.Value + X_AMT_RMA_EXPENSE_POT_G.Value) && QDesign.NULL(fleF119_DOCTOR_YTD.GetDecimalValue("AMT_MTD")) < 0))
                {
                    CurrentValue = X_AMT_RMA_EXPENSE_POT_G.Value;
                }
                else
                {
                    CurrentValue = X_INCOME_GROSS_MINUS_NET.Value - X_AMT_DEPT_EXPENSE_G.Value;
                }

                Value = CurrentValue;
            }

            catch (CustomApplicationException ex)
            {
                WriteError(ex);
            }

            catch (Exception ex)
            {
                WriteError(ex);
            }
        }

        private DDecimal X_AMT_GST_POT_G = new DDecimal("X_AMT_GST_POT_G", 8);
        private void X_AMT_GST_POT_G_GetValue(ref decimal Value)
        {
            try
            {
                decimal CurrentValue = 0m;

                if (fleF020_DOCTOR_MSTR.GetStringValue("DOC_IND_PAYS_GST") == "Y")
                {
                    CurrentValue = QDesign.Round((X_AMT_RMA_EXPENSE_ONLY.Value * GST_PERCENT.Value) / 100, 0, RoundOptionTypes.Near);
                }
                else
                {
                    CurrentValue = 0;
                }

                Value = CurrentValue;
            }

            catch (CustomApplicationException ex)
            {
                WriteError(ex);
            }

            catch (Exception ex)
            {
                WriteError(ex);
            }
        }

        private DDecimal X_AMT_ROUND_OFF = new DDecimal("X_AMT_ROUND_OFF", 8);
        private void X_AMT_ROUND_OFF_GetValue(ref decimal Value)
        {
            try
            {
                Value = Math.Abs(X_INCOME_GROSS_MINUS_NET.Value) - Math.Abs(X_AMT_DEPT_EXPENSE_G.Value) - Math.Abs(X_AMT_RMA_EXPENSE_ONLY.Value) - Math.Abs(X_AMT_GST_POT_G.Value);
            }

            catch (CustomApplicationException ex)
            {
                WriteError(ex);
            }

            catch (Exception ex)
            {
                WriteError(ex);
            }
        }

        private DDecimal X_AMT_GST_ONLY = new DDecimal("X_AMT_GST_ONLY", 8);
        private void X_AMT_GST_ONLY_GetValue(ref decimal Value)
        {
            try
            {
                decimal CurrentValue = 0m;

                if ((((X_INCOME_GROSS_MINUS_NET.Value > (X_AMT_DEPT_EXPENSE_G.Value + X_AMT_RMA_EXPENSE_ONLY.Value + X_AMT_GST_POT_G.Value)) && QDesign.NULL(fleF119_DOCTOR_YTD.GetDecimalValue("AMT_MTD")) > 0) || ((X_INCOME_GROSS_MINUS_NET.Value < (X_AMT_DEPT_EXPENSE_G.Value + X_AMT_RMA_EXPENSE_ONLY.Value + X_AMT_GST_POT_G.Value)) && QDesign.NULL(fleF119_DOCTOR_YTD.GetDecimalValue("AMT_MTD")) < 0)) && (X_AMT_ROUND_OFF.Value > 5))
                {
                    CurrentValue = X_AMT_GST_POT_G.Value;
                }
                else
                {
                    CurrentValue = (X_INCOME_GROSS_MINUS_NET.Value - X_AMT_DEPT_EXPENSE_G.Value - X_AMT_RMA_EXPENSE_ONLY.Value);
                }

                Value = CurrentValue;
            }

            catch (CustomApplicationException ex)
            {
                WriteError(ex);
            }

            catch (Exception ex)
            {
                WriteError(ex);
            }
        }

        private DDecimal X_AMT_RMA_EXPENSE_PLUS_GST_G = new DDecimal("X_AMT_RMA_EXPENSE_PLUS_GST_G", 8);
        private void X_AMT_RMA_EXPENSE_PLUS_GST_G_GetValue(ref decimal Value)
        {
            try
            {
                Value = X_AMT_RMA_EXPENSE_ONLY.Value + X_AMT_GST_ONLY.Value;
            }

            catch (CustomApplicationException ex)
            {
                WriteError(ex);
            }

            catch (Exception ex)
            {
                WriteError(ex);
            }
        }

        private DDecimal X_AMT_HOLDBACK_G = new DDecimal("X_AMT_HOLDBACK_G", 10);
        private void X_AMT_HOLDBACK_G_GetValue(ref decimal Value)
        {
            try
            {
                decimal CurrentValue = 0m;

                if (((X_INCOME_GROSS_MINUS_NET.Value > (X_AMT_DEPT_EXPENSE_G.Value + X_AMT_RMA_EXPENSE_PLUS_GST_G.Value) && QDesign.NULL(fleF119_DOCTOR_YTD.GetDecimalValue("AMT_MTD")) > 0) || (X_INCOME_GROSS_MINUS_NET.Value < (X_AMT_DEPT_EXPENSE_G.Value + X_AMT_RMA_EXPENSE_PLUS_GST_G.Value) && QDesign.NULL(fleF119_DOCTOR_YTD.GetDecimalValue("AMT_MTD")) < 0)))
                {
                    CurrentValue = QDesign.Round(X_INCOME_GROSS_MINUS_NET.Value - X_AMT_DEPT_EXPENSE_G.Value - X_AMT_RMA_EXPENSE_PLUS_GST_G.Value);
                }
                else
                {
                    CurrentValue = 0;
                }

                Value = CurrentValue;
            }

            catch (CustomApplicationException ex)
            {
                WriteError(ex);
            }

            catch (Exception ex)
            {
                WriteError(ex);
            }
        }

        //;(IF HOLDBACK IS LESS THAN OR = 10 CENTS AND THERE WAS PREVIOUS
        //; NON-ZERO EXPENSE CALCULATIONS, THEN IGNORE THE CALCULATED HOLDBACK
        //; AND ADD THE AMOUNT OF THE LEFT OVER "HOLDBACK" BACK INTO THE
        //; LAST NON-ZERO EXPENSE CALCUATION)
        //; 2000/nov/23 B.E.changed limit from 10 cents to a dollar

        private DDecimal X_AMT_HOLDBACK_FINAL = new DDecimal("X_AMT_HOLDBACK_FINAL", 10);
        private void X_AMT_HOLDBACK_FINAL_GetValue(ref decimal Value)
        {
            try
            {
                decimal CurrentValue = 0m;

                if (X_AMT_HOLDBACK_G.Value > 100 || (X_AMT_RMA_EXPENSE_ONLY.Value == 0 && X_AMT_DEPT_EXPENSE_G.Value == 0))
                {
                    CurrentValue = X_AMT_HOLDBACK_G.Value;
                }
                else
                {
                    CurrentValue = 0;
                }

                Value = CurrentValue;
            }

            catch (CustomApplicationException ex)
            {
                WriteError(ex);
            }

            catch (Exception ex)
            {
                WriteError(ex);
            }
        }

        private DDecimal X_AMT_RMA_EXPENSE_FINAL = new DDecimal("X_AMT_RMA_EXPENSE_FINAL", 10);
        private void X_AMT_RMA_EXPENSE_FINAL_GetValue(ref decimal Value)
        {
            try
            {
                decimal CurrentValue = 0m;

                if (X_AMT_HOLDBACK_G.Value < 10 && X_AMT_RMA_EXPENSE_ONLY.Value != 0)
                {
                    CurrentValue = X_AMT_RMA_EXPENSE_ONLY.Value + X_AMT_HOLDBACK_G.Value;
                }
                else
                {
                    CurrentValue = X_AMT_RMA_EXPENSE_ONLY.Value;
                }

                Value = CurrentValue;
            }

            catch (CustomApplicationException ex)
            {
                WriteError(ex);
            }

            catch (Exception ex)
            {
                WriteError(ex);
            }
        }

        private DDecimal X_AMT_DEPT_EXPENSE_FINAL = new DDecimal("X_AMT_DEPT_EXPENSE_FINAL", 10);
        private void X_AMT_DEPT_EXPENSE_FINAL_GetValue(ref decimal Value)
        {
            try
            {
                decimal CurrentValue = 0m;

                if (X_AMT_HOLDBACK_G.Value < 10 && X_AMT_DEPT_EXPENSE_G.Value != 0)
                {
                    CurrentValue = X_AMT_DEPT_EXPENSE_G.Value + X_AMT_HOLDBACK_G.Value;
                }
                else
                {
                    CurrentValue = X_AMT_DEPT_EXPENSE_G.Value;
                }

                Value = CurrentValue;
            }

            catch (CustomApplicationException ex)
            {
                WriteError(ex);
            }

            catch (Exception ex)
            {
                WriteError(ex);
            }
        }

        private DDecimal X_AMT_RMA_EXPENSE_PLUSGST_FINAL = new DDecimal("X_AMT_RMA_EXPENSE_PLUSGST_FINAL", 10);
        private void X_AMT_RMA_EXPENSE_PLUSGST_FINAL_GetValue(ref decimal Value)
        {
            try
            {
                Value = X_AMT_RMA_EXPENSE_FINAL.Value + X_AMT_GST_ONLY.Value;
            }

            catch (CustomApplicationException ex)
            {
                WriteError(ex);
            }

            catch (Exception ex)
            {
                WriteError(ex);
            }
        }

        private CoreInteger TOT_INCOME_GROSS_REG;
        private CoreInteger TOT_INCOME_GROSS_MISC;
        private CoreInteger TOT_INCOME_GROSS_OTHER;
        private CoreInteger TOT_INCOME_NET_REG;
        private CoreInteger TOT_INCOME_NET_MISC;
        private CoreInteger TOT_INCOME_NET_OTHER;
        private CoreInteger TOT_TITHE_GROSS_REG;
        private CoreInteger TOT_TITHE_GROSS_MISC;
        private CoreInteger TOT_TITHE_GROSS_OTHER;
        private CoreInteger TOT_TITHE_NET_REG;
        private CoreInteger TOT_TITHE_NET_MISC;
        private CoreInteger TOT_TITHE_NET_OTHER;
        private CoreInteger TOT_DEPT_EXPENSE_REG;
        private CoreInteger TOT_DEPT_EXPENSE_MISC;
        private CoreInteger TOT_RMA_EXPENSE_PLUS_GST_REG;
        private CoreInteger TOT_RMA_EXPENSE_PLUS_GST_MISC;
        private CoreInteger TOT_RMA_EXPENSE_ONLY_REG;
        private CoreInteger TOT_RMA_EXPENSE_ONLY_MISC;
        private CoreInteger TOT_GST_ONLY_REG;
        private CoreInteger TOT_GST_ONLY_MISC;
        private CoreInteger TOT_HOLDBACK_ONLY_REG;
        private CoreInteger TOT_HOLDBACK_ONLY_MISC;
        private CoreInteger TOT_REVHBK;
        private CoreInteger AMT_MANPAY;

        //; if new record, initial YTD record in F119.  (required only for
        //; "I"ncome, AND "E"xpense records - .ie calc rec types like CEICEA are
        //;  needed AND the "D"eduction records are handled in the tax/eft processing)

        private DCharacter X_REC_TYPE = new DCharacter("X_REC_TYPE", 1);
        private void X_REC_TYPE_GetValue(ref string Value)
        {
            try
            {
                Value = "A";
            }

            catch (CustomApplicationException ex)
            {
                WriteError(ex);
            }

            catch (Exception ex)
            {
                WriteError(ex);
            }
        }

        private DCharacter REC_TYPE = new DCharacter("REC_TYPE", 1);
        private void REC_TYPE_GetValue(ref string Value)
        {
            try
            {
                if (fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE") == "AFPADJ")
                {
                    Value = "C";
                }
                else
                {
                    Value = "A";
                }
            }

            catch (CustomApplicationException ex)
            {
                WriteError(ex);
            }

            catch (Exception ex)
            {
                WriteError(ex);
            }
        }

        private DDecimal X_NOT_NEEDED = new DDecimal("X_NOT_NEEDED", 10);
        private void X_NOT_NEEDED_GetValue(ref decimal Value)
        {
            try
            {
                Value = 0;
            }

            catch (CustomApplicationException ex)
            {
                WriteError(ex);
            }

            catch (Exception ex)
            {
                WriteError(ex);
            }
        }

        //; (GROSS VALUES ARE USUALLY PUT INTO F119 HOWEVER FOR CEIEXP THE NET VALUE IS REQUIRED)

        private DDecimal X_AMT_NET = new DDecimal("X_AMT_NET", 10);
        private void X_AMT_NET_GetValue(ref decimal Value)
        {
            try
            {
                if (fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE") == "CEIEXP")
                {
                    Value = fleF119_DOCTOR_YTD.GetDecimalValue("AMT_MTD");
                }
                else
                {
                    Value = fleF119_DOCTOR_YTD.GetDecimalValue("AMT_MTD");
                }
            }

            catch (CustomApplicationException ex)
            {
                WriteError(ex);
            }

            catch (Exception ex)
            {
                WriteError(ex);
            }
        }

        private DDecimal X_AMT_GROSS = new DDecimal("X_AMT_GROSS", 10);
        private void X_AMT_GROSS_GetValue(ref decimal Value)
        {
            try
            {
                if (fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE") == "CEIEXP")
                {
                    Value = fleF119_DOCTOR_YTD.GetDecimalValue("AMT_MTD");
                }
                else
                {
                    Value = fleF119_DOCTOR_YTD.GetDecimalValue("AMT_MTD");
                }
            }

            catch (CustomApplicationException ex)
            {
                WriteError(ex);
            }

            catch (Exception ex)
            {
                WriteError(ex);
            }
        }

        private DDecimal TOT_GST_ONLY = new DDecimal("TOT_GST_ONLY", 10);
        private void TOT_GST_ONLY_GetValue(ref decimal Value)
        {
            try
            {
                Value = TOT_GST_ONLY_REG.Value + TOT_GST_ONLY_MISC.Value;
            }

            catch (CustomApplicationException ex)
            {
                WriteError(ex);
            }

            catch (Exception ex)
            {
                WriteError(ex);
            }
        }

        private DDecimal TOT_HOLDBACK_ONLY = new DDecimal("TOT_HOLDBACK_ONLY", 10);
        private void TOT_HOLDBACK_ONLY_GetValue(ref decimal Value)
        {
            try
            {
                Value = TOT_HOLDBACK_ONLY_REG.Value + TOT_HOLDBACK_ONLY_MISC.Value;
            }

            catch (CustomApplicationException ex)
            {
                WriteError(ex);
            }

            catch (Exception ex)
            {
                WriteError(ex);
            }
        }

        private DDecimal TOT_INCOME_GROSS = new DDecimal("TOT_INCOME_GROSS", 10);
        private void TOT_INCOME_GROSS_GetValue(ref decimal Value)
        {
            try
            {
                Value = TOT_INCOME_GROSS_REG.Value + TOT_INCOME_GROSS_MISC.Value + TOT_INCOME_GROSS_OTHER.Value;
            }

            catch (CustomApplicationException ex)
            {
                WriteError(ex);
            }

            catch (Exception ex)
            {
                WriteError(ex);
            }
        }

        private DDecimal TOT_INCOME_NET = new DDecimal("TOT_INCOME_NET", 10);
        private void TOT_INCOME_NET_GetValue(ref decimal Value)
        {
            try
            {
                Value = TOT_INCOME_NET_REG.Value + TOT_INCOME_NET_MISC.Value + TOT_INCOME_NET_OTHER.Value;
            }

            catch (CustomApplicationException ex)
            {
                WriteError(ex);
            }

            catch (Exception ex)
            {
                WriteError(ex);
            }
        }

        private CoreInteger FINAL_ALL_EXPENSES;
        private CoreInteger AMT_INCOME_MINUS_EXPENSES_G;
        private CoreInteger DOC_YTDEAR_PLUS_AMT_MANPAY;

        SqlFileObject fleDEBUGU115A0_AT_COMP_CODE;
        SqlFileObject fleDEBUGU115A0_AT_DOC_NBR;
        SqlFileObject fleF119_TITHE_DTL;
        SqlFileObject fleF119_DOC_SUMM;
        SqlFileObject fleF119_TOTIT_DOC;
        SqlFileObject fleF119_TOTIT_SUMM;

        //SqlFileObject fleU115A0_MC;

        private DCharacter REC_TYPE_D = new DCharacter("REC_TYPE_D", 1);
        private void REC_TYPE_D_GetValue(ref string Value)
        {
            try
            {
                Value = "D";
            }

            catch (CustomApplicationException ex)
            {
                WriteError(ex);
            }

            catch (Exception ex)
            {
                WriteError(ex);
            }
        }

        private DCharacter DOC_NBR_SUMM = new DCharacter("DOC_NBR_SUMM", 3);
        private void DOC_NBR_SUMM_GetValue(ref string Value)
        {
            try
            {
                Value = "000";
            }

            catch (CustomApplicationException ex)
            {
                WriteError(ex);
            }

            catch (Exception ex)
            {
                WriteError(ex);
            }
        }

        private DCharacter X_COMP_CODE_TOTIT = new DCharacter("X_COMP_CODE_TOTIT", 6);
        private void X_COMP_CODE_TOTIT_GetValue(ref string Value)
        {
            try
            {
                if (PAYROLL_FLAG.Value == "A")
                {
                    Value = "TOTITE";
                }
                else if (PAYROLL_FLAG.Value == "C")
                {
                    Value = "TOTITD";
                }
            }

            catch (CustomApplicationException ex)
            {
                WriteError(ex);
            }

            catch (Exception ex)
            {
                WriteError(ex);
            }
        }

        private DDecimal TOTIT_SEQ_RPT = new DDecimal("TOTIT_SEQ_RPT", 2);
        private void TOTIT_SEQ_RPT_GetValue(ref decimal Value)
        {
            try
            {
                decimal CurrentValue = 0m;

                if (PAYROLL_FLAG.Value == "A")
                {
                    CurrentValue = TOTITE_SEQ_RPT.Value;
                }
                else
                {
                    CurrentValue = TOTITD_SEQ_RPT.Value;
                }

                Value = CurrentValue;
            }

            catch (CustomApplicationException ex)
            {
                WriteError(ex);
            }

            catch (Exception ex)
            {
                WriteError(ex);
            }
        }

        private DCharacter TOTIT_GROUP = new DCharacter("TOTIT_GROUP", 1);
        private void TOTIT_GROUP_GetValue(ref string Value)
        {
            try
            {
                if (PAYROLL_FLAG.Value == "A")
                {
                    Value = TOTITE_GROUP.Value;
                }
                else if (PAYROLL_FLAG.Value == "C")
                {
                    Value = TOTITD_GROUP.Value;
                }
            }

            catch (CustomApplicationException ex)
            {
                WriteError(ex);
            }

            catch (Exception ex)
            {
                WriteError(ex);
            }
        }

        private DDecimal TOT_TITHE_GROSS = new DDecimal("TOT_TITHE_GROSS", 10);
        private void TOT_TITHE_GROSS_GetValue(ref decimal Value)
        {
            try
            {
                Value = TOT_TITHE_GROSS_REG.Value + TOT_TITHE_GROSS_MISC.Value + TOT_TITHE_GROSS_OTHER.Value;
            }

            catch (CustomApplicationException ex)
            {
                WriteError(ex);
            }

            catch (Exception ex)
            {
                WriteError(ex);
            }
        }

        private DDecimal TOT_TITHE_NET = new DDecimal("TOT_TITHE_NET", 10);
        private void TOT_TITHE_NET_GetValue(ref decimal Value)
        {
            try
            {
                Value = TOT_TITHE_NET_REG.Value + TOT_TITHE_NET_MISC.Value + TOT_TITHE_NET_OTHER.Value;
            }

            catch (CustomApplicationException ex)
            {
                WriteError(ex);
            }

            catch (Exception ex)
            {
                WriteError(ex);
            }
        }

        private DDecimal X_AMT_NET_DTL = new DDecimal("X_AMT_NET_DTL", 10);
        private void X_AMT_NET_DTL_GetValue(ref decimal Value)
        {
            try
            {
                Value = X_AMT_NET.Value;
            }

            catch (CustomApplicationException ex)
            {
                WriteError(ex);
            }

            catch (Exception ex)
            {
                WriteError(ex);
            }
        }

        private DDecimal X_AMT_GROSS_DTL = new DDecimal("X_AMT_GROSS_DTL", 10);
        private void X_AMT_GROSS_DTL_GetValue(ref decimal Value)
        {
            try
            {
                Value = X_AMT_GROSS.Value;
            }

            catch (CustomApplicationException ex)
            {
                WriteError(ex);
            }

            catch (Exception ex)
            {
                WriteError(ex);
            }
        }

        #endregion

        #region "Standard Generated Procedures(U115A_0_U115_RUN_0_11)"

        #region "Transaction Management Procedures(U115A_0_U115_RUN_0_11)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 6/27/2017 2:46:31 PM

        //#-----------------------------------------
        //# InitializeTransactionObjects Procedure.
        //#-----------------------------------------

        protected override void InitializeTransactionObjects()
        {
            try
            {
                m_cnnTRANS_UPDATE = new SqlConnection(Common.GetConnectionString());
                m_cnnTRANS_UPDATE.Open();
                m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
                m_cnnQUERY = new SqlConnection(Common.GetConnectionString());
            }

            catch (CustomApplicationException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;
            }
        }

        //#-----------------------------------------
        //# CloseTransactionObjects Procedure.
        //#-----------------------------------------

        protected override void CloseTransactionObjects()
        {
            try
            {
                CloseFiles();

                if ((m_trnTRANS_UPDATE != null))
                    m_trnTRANS_UPDATE.Dispose();

                if ((m_cnnTRANS_UPDATE != null))
                    m_cnnTRANS_UPDATE.Close();

                if ((m_cnnTRANS_UPDATE != null))
                    m_cnnTRANS_UPDATE.Dispose();

                if ((m_cnnQUERY != null))
                    m_cnnQUERY.Close();

                if ((m_cnnQUERY != null))
                    m_cnnQUERY.Dispose();
            }

            catch (CustomApplicationException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;
            }
        }

        protected override void TRANS_UPDATE(TransactionMethods Method)
        {
            if (Method == TransactionMethods.Rollback)
            {
                m_trnTRANS_UPDATE.Rollback();
            }
            else
            {
                m_trnTRANS_UPDATE.Commit();
            }

            m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
            Initialize_TRANS_UPDATE();
        }

        private void Initialize_TRANS_UPDATE()
        {
            fleF119_DOCTOR_YTD.Transaction = m_trnTRANS_UPDATE;
            fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
            fleF116_GROUP.Transaction = m_trnTRANS_UPDATE;
             fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;
            fleDEBUGU115A0_AT_COMP_CODE.Transaction = m_trnTRANS_UPDATE;
            fleDEBUGU115A0_AT_DOC_NBR.Transaction = m_trnTRANS_UPDATE;
            fleF119_TITHE_DTL.Transaction = m_trnTRANS_UPDATE;
            //fleU115A0_MC.Transaction = m_trnTRANS_UPDATE;
        }

        #endregion

        #region "FILE Management Procedures(U115A_0_U115_RUN_0_11)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 6/27/2017 2:46:31 PM

        //#-----------------------------------------
        //# InitializeFiles Procedure.
        //#-----------------------------------------

        protected override void InitializeFiles()
        {
            try
            {
                Initialize_TRANS_UPDATE();
            }

            catch (CustomApplicationException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;
            }
        }

        //#-----------------------------------------
        //# CloseFiles Procedure.
        //#-----------------------------------------

        protected override void CloseFiles()
        {
            try
            {
                fleF119_DOCTOR_YTD.Dispose();
                fleF020_DOCTOR_MSTR.Dispose();
                fleF116_GROUP.Dispose();
                fleF190_COMP_CODES.Dispose();
                fleDEBUGU115A0_AT_COMP_CODE.Dispose();
                fleDEBUGU115A0_AT_DOC_NBR.Dispose();
                fleF119_TITHE_DTL.Dispose();
                //fleU115A0_MC.Dispose();
            }

            catch (CustomApplicationException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;
            }
        }

        #endregion

        #endregion

        #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U115A_0_U115_RUN_0_11)"

        public void Run()
        {
            try
            {
                Request("U115A_0_U115_RUN_0_11");

                while (fleF119_DOCTOR_YTD.QTPForMissing())
                {
                    // --> GET fleF119_DOCTOR_YTD <--
                    fleF119_DOCTOR_YTD.GetData();
                    // --> End GET fleF119_DOCTOR_YTD <--

                    while (fleF020_DOCTOR_MSTR.QTPForMissing("1"))
                    {
                        // --> GET fleF020_DOCTOR_MSTR <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleF119_DOCTOR_YTD.GetStringValue("DOC_NBR")));

                        fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString());
                        // --> End GET fleF020_DOCTOR_MSTR <--

                        while (fleF116_GROUP.QTPForMissing("2"))
                        {
                            // --> GET fleF116_GROUP <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(fleF116_GROUP.ElementOwner("DEPT_EXPENSE_CALC_CODE")).Append(" = ");
                            m_strWhere.Append(Common.StringToField("FLAT+3_TITHE_LEVELS"));
                            m_strWhere.Append(" AND ").Append(fleF116_GROUP.ElementOwner("DEPT_NBR")).Append(" = ");
                            m_strWhere.Append(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT"));
                            m_strWhere.Append(" AND ").Append(fleF116_GROUP.ElementOwner("DOC_AFP_PAYM_GROUP")).Append(" = ");                           
                            m_strWhere.Append(Common.StringToField(fleF020_DOCTOR_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP")));
                            m_strWhere.Append(" AND ").Append(fleF116_GROUP.ElementOwner("DOC_NBR")).Append(" = ");
                            m_strWhere.Append(Common.StringToField("000"));
                            m_strWhere.Append(" AND ").Append(fleF116_GROUP.ElementOwner("COMP_CODE")).Append(" = ");
                            m_strWhere.Append(Common.StringToField(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")));

                            fleF116_GROUP.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                            // --> End GET fleF116_GROUP <--

                           

                                while (fleF190_COMP_CODES.QTPForMissing("3"))
                                {
                                    // --> GET fleF190_COMP_CODES <--
                                    m_strWhere = new StringBuilder(" WHERE ");
                                    m_strWhere.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
                                    m_strWhere.Append(Common.StringToField(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")));

                                    fleF190_COMP_CODES.GetData(m_strWhere.ToString());
                                    // --> End GET fleF190_COMP_CODES <--

                                    if (Transaction())
                                    {
                                        Sort(fleF119_DOCTOR_YTD.GetSortValue("DOC_NBR"), fleF119_DOCTOR_YTD.GetSortValue("COMP_CODE"));
                                    }
                                }
                            }
                        }
                    }
                

                while (Sort(fleF119_DOCTOR_YTD, fleF020_DOCTOR_MSTR, fleF116_GROUP, fleF190_COMP_CODES))
                {
                    if (fleF190_COMP_CODES.GetStringValue("COMP_TYPE") == "I" && fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE") == "R" && (!fleF116_GROUP.Exists() || (fleF116_GROUP.Exists() && fleF116_GROUP.GetStringValue("TITHE_IN_EX_CLUDE_FLAG") == "E") || (fleF116_GROUP.Exists() && fleF116_GROUP.GetStringValue("TITHE_IN_EX_CLUDE_FLAG") == "I" && fleF116_GROUP.GetStringValue("FLAG_DISPLAY_HIDE") == "N")))
                    {
                        TOT_INCOME_GROSS_REG.Value = TOT_INCOME_GROSS_REG.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_MTD");
                    }


                    if (fleF190_COMP_CODES.GetStringValue("COMP_TYPE") == "I" && fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE") == "M" && (!fleF116_GROUP.Exists() || (fleF116_GROUP.Exists() && fleF116_GROUP.GetStringValue("TITHE_IN_EX_CLUDE_FLAG") == "E") || (fleF116_GROUP.Exists() && fleF116_GROUP.GetStringValue("TITHE_IN_EX_CLUDE_FLAG") == "I" && fleF116_GROUP.GetStringValue("FLAG_DISPLAY_HIDE") == "N")))
                    {
                        TOT_INCOME_GROSS_MISC.Value = TOT_INCOME_GROSS_MISC.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_MTD");
                    }

                    if (fleF190_COMP_CODES.GetStringValue("COMP_TYPE") == "I" && fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE") == "O" && (!fleF116_GROUP.Exists() || (fleF116_GROUP.Exists() && fleF116_GROUP.GetStringValue("TITHE_IN_EX_CLUDE_FLAG") == "E") || (fleF116_GROUP.Exists() && fleF116_GROUP.GetStringValue("TITHE_IN_EX_CLUDE_FLAG") == "I" && fleF116_GROUP.GetStringValue("FLAG_DISPLAY_HIDE") == "N")))
                    {
                        TOT_INCOME_GROSS_OTHER.Value = TOT_INCOME_GROSS_OTHER.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_MTD");
                    }

                    if (fleF190_COMP_CODES.GetStringValue("COMP_TYPE") == "I" && fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE") == "R" && (!fleF116_GROUP.Exists() || (fleF116_GROUP.Exists() && fleF116_GROUP.GetStringValue("TITHE_IN_EX_CLUDE_FLAG") == "E") || (fleF116_GROUP.Exists() && fleF116_GROUP.GetStringValue("TITHE_IN_EX_CLUDE_FLAG") == "I" && fleF116_GROUP.GetStringValue("FLAG_DISPLAY_HIDE") == "N")))
                    {
                        TOT_INCOME_NET_REG.Value = TOT_INCOME_NET_REG.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_MTD");
                    }

                    if (fleF190_COMP_CODES.GetStringValue("COMP_TYPE") == "I" && fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE") == "M" && (!fleF116_GROUP.Exists() || (fleF116_GROUP.Exists() && fleF116_GROUP.GetStringValue("TITHE_IN_EX_CLUDE_FLAG") == "E") || (fleF116_GROUP.Exists() && fleF116_GROUP.GetStringValue("TITHE_IN_EX_CLUDE_FLAG") == "I" && fleF116_GROUP.GetStringValue("FLAG_DISPLAY_HIDE") == "N")))
                    {
                        TOT_INCOME_NET_MISC.Value = TOT_INCOME_NET_MISC.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_MTD");
                    }

                    if (fleF190_COMP_CODES.GetStringValue("COMP_TYPE") == "I" && fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE") == "O" && (!fleF116_GROUP.Exists() || (fleF116_GROUP.Exists() && fleF116_GROUP.GetStringValue("TITHE_IN_EX_CLUDE_FLAG") == "E") || (fleF116_GROUP.Exists() && fleF116_GROUP.GetStringValue("TITHE_IN_EX_CLUDE_FLAG") == "I" && fleF116_GROUP.GetStringValue("FLAG_DISPLAY_HIDE") == "N")))
                    {
                        TOT_INCOME_NET_OTHER.Value = TOT_INCOME_NET_OTHER.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_MTD");
                    }

                    if (fleF190_COMP_CODES.GetStringValue("COMP_TYPE") == "I" && fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE") == "R" && fleF116_GROUP.Exists() && fleF116_GROUP.GetStringValue("TITHE_IN_EX_CLUDE_FLAG") == "I")
                    {
                        TOT_TITHE_GROSS_REG.Value = TOT_TITHE_GROSS_REG.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_MTD");
                    }

                    if (fleF190_COMP_CODES.GetStringValue("COMP_TYPE") == "I" && fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE") == "M" && fleF116_GROUP.Exists() && fleF116_GROUP.GetStringValue("TITHE_IN_EX_CLUDE_FLAG") == "I")
                    {
                        TOT_TITHE_GROSS_MISC.Value = TOT_TITHE_GROSS_MISC.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_MTD");
                    }

                    if (fleF190_COMP_CODES.GetStringValue("COMP_TYPE") == "I" && fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE") == "O" && fleF116_GROUP.Exists() && fleF116_GROUP.GetStringValue("TITHE_IN_EX_CLUDE_FLAG") == "I")
                    {
                        TOT_TITHE_GROSS_OTHER.Value = TOT_TITHE_GROSS_OTHER.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_MTD");
                    }
                                     

                    if (fleF190_COMP_CODES.GetStringValue("COMP_TYPE") == "I" && fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE") == "R" && fleF116_GROUP.Exists() && fleF116_GROUP.GetStringValue("TITHE_IN_EX_CLUDE_FLAG") == "I")
                    {
                        TOT_TITHE_NET_REG.Value = TOT_TITHE_NET_REG.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_MTD");
                    }

                    if (fleF190_COMP_CODES.GetStringValue("COMP_TYPE") == "I" && fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE") == "M" && fleF116_GROUP.Exists() && fleF116_GROUP.GetStringValue("TITHE_IN_EX_CLUDE_FLAG") == "I")
                    {
                        TOT_TITHE_NET_MISC.Value = TOT_TITHE_NET_MISC.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_MTD");
                    }

                    if (fleF190_COMP_CODES.GetStringValue("COMP_TYPE") == "I" && fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE") == "O" && fleF116_GROUP.Exists() && fleF116_GROUP.GetStringValue("TITHE_IN_EX_CLUDE_FLAG") == "I")
                    {
                        TOT_TITHE_NET_OTHER.Value = TOT_TITHE_NET_OTHER.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_MTD");
                    }

                    if (fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE") == "R")
                    {
                        TOT_DEPT_EXPENSE_REG.Value = TOT_DEPT_EXPENSE_REG.Value + X_AMT_DEPT_EXPENSE_FINAL.Value;
                    }

                    if (fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE") == "M")
                    {
                        TOT_DEPT_EXPENSE_MISC.Value = TOT_DEPT_EXPENSE_MISC.Value + X_AMT_DEPT_EXPENSE_FINAL.Value;
                    }

                    if (fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE") == "R")
                    {
                        TOT_RMA_EXPENSE_PLUS_GST_REG.Value = TOT_RMA_EXPENSE_PLUS_GST_REG.Value + X_AMT_RMA_EXPENSE_PLUSGST_FINAL.Value;
                    }

                    if (fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE") == "M")
                    {
                        TOT_RMA_EXPENSE_PLUS_GST_MISC.Value = TOT_RMA_EXPENSE_PLUS_GST_MISC.Value + X_AMT_RMA_EXPENSE_PLUSGST_FINAL.Value;
                    }

                    if (fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE") == "R")
                    {
                        TOT_RMA_EXPENSE_ONLY_REG.Value = TOT_RMA_EXPENSE_ONLY_REG.Value + X_AMT_RMA_EXPENSE_FINAL.Value;
                    }

                    if (fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE") == "M")
                    {
                        TOT_RMA_EXPENSE_ONLY_MISC.Value = TOT_RMA_EXPENSE_ONLY_MISC.Value + X_AMT_RMA_EXPENSE_FINAL.Value;
                    }

                    if (fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE") == "R")
                    {
                        TOT_GST_ONLY_REG.Value = TOT_GST_ONLY_REG.Value + X_AMT_GST_ONLY.Value;
                    }

                    if (fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE") == "M")
                    {
                        TOT_GST_ONLY_MISC.Value = TOT_GST_ONLY_MISC.Value + X_AMT_GST_ONLY.Value;
                    }

                    if (fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE") == "R")
                    {
                        TOT_HOLDBACK_ONLY_REG.Value = TOT_HOLDBACK_ONLY_REG.Value + X_AMT_HOLDBACK_FINAL.Value;
                    }

                    if (fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE") == "M")
                    {
                        TOT_HOLDBACK_ONLY_MISC.Value = TOT_HOLDBACK_ONLY_MISC.Value + X_AMT_HOLDBACK_FINAL.Value;
                    }

                    if (fleF190_COMP_CODES.GetStringValue("COMP_TYPE") == "E" && (fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE") == "REVHBK" || fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE") == "REVCLA"))
                    {
                        TOT_REVHBK.Value = TOT_REVHBK.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_MTD");
                    }

                    if (fleF190_COMP_CODES.GetStringValue("COMP_TYPE") == "M")
                    {
                        AMT_MANPAY.Value = AMT_MANPAY.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_MTD");
                    }

                    FINAL_ALL_EXPENSES.Value = TOT_DEPT_EXPENSE_REG.Value + TOT_DEPT_EXPENSE_MISC.Value + TOT_RMA_EXPENSE_ONLY_REG.Value + TOT_RMA_EXPENSE_ONLY_MISC.Value + TOT_GST_ONLY.Value + TOT_HOLDBACK_ONLY.Value + TOT_REVHBK.Value + fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CEICEX");
                    AMT_INCOME_MINUS_EXPENSES_G.Value = TOT_INCOME_GROSS.Value - FINAL_ALL_EXPENSES.Value;
                    DOC_YTDEAR_PLUS_AMT_MANPAY.Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDEAR") + AMT_MANPAY.Value;

                    SubFile(ref m_trnTRANS_UPDATE, ref fleDEBUGU115A0_AT_COMP_CODE, SubFileType.Keep, fleF119_DOCTOR_YTD, "DOC_NBR", "COMP_CODE", "AMT_MTD", fleF190_COMP_CODES, "COMP_TYPE", "COMP_SUB_TYPE", fleF020_DOCTOR_MSTR, "DOC_DEPT_EXPENSE_PERCENT_REG", "DOC_DEPT_EXPENSE_PERCENT_MISC",
                            "DOC_IND_PAYS_GST", "DOC_RMA_EXPENSE_PERCENT_MISC", "DOC_RMA_EXPENSE_PERCENT_REG", X_INCOME_GROSS_MINUS_NET, X_AMT_DEPT_EXPENSE_POT_G, X_AMT_DEPT_EXPENSE_G, GST_PERCENT, X_AMT_GST_ONLY, X_AMT_RMA_EXPENSE_ONLY, X_AMT_RMA_EXPENSE_POT_G, X_AMT_RMA_EXPENSE_PLUS_GST_G,
                            X_AMT_HOLDBACK_G, X_AMT_HOLDBACK_FINAL, X_AMT_RMA_EXPENSE_FINAL, X_AMT_RMA_EXPENSE_PLUSGST_FINAL, TOT_INCOME_GROSS_REG, TOT_INCOME_GROSS_MISC, TOT_INCOME_GROSS_OTHER, TOT_INCOME_NET_REG, TOT_INCOME_NET_MISC, TOT_INCOME_NET_OTHER, TOT_DEPT_EXPENSE_REG, TOT_DEPT_EXPENSE_MISC,
                            TOT_RMA_EXPENSE_PLUS_GST_REG, TOT_RMA_EXPENSE_PLUS_GST_MISC, TOT_RMA_EXPENSE_ONLY_REG, TOT_RMA_EXPENSE_ONLY_MISC, TOT_GST_ONLY_REG, TOT_GST_ONLY_MISC, TOT_HOLDBACK_ONLY_REG, TOT_HOLDBACK_ONLY_MISC, TOT_REVHBK, AMT_MANPAY, FINAL_ALL_EXPENSES, AMT_INCOME_MINUS_EXPENSES_G,
                            DOC_YTDEAR_PLUS_AMT_MANPAY, "DOC_YTDEAR");

                    SubFile(ref m_trnTRANS_UPDATE, ref fleDEBUGU115A0_AT_DOC_NBR, fleF119_DOCTOR_YTD.At("DOC_NBR"), SubFileType.Keep, fleF119_DOCTOR_YTD, "DOC_NBR", TOT_INCOME_GROSS_REG, TOT_INCOME_GROSS_MISC, TOT_INCOME_GROSS_OTHER, TOT_INCOME_NET_REG, TOT_INCOME_NET_MISC,
                            TOT_INCOME_NET_OTHER, TOT_DEPT_EXPENSE_REG, TOT_DEPT_EXPENSE_MISC, TOT_RMA_EXPENSE_PLUS_GST_REG, TOT_RMA_EXPENSE_PLUS_GST_MISC, TOT_RMA_EXPENSE_ONLY_REG, TOT_RMA_EXPENSE_ONLY_MISC, TOT_GST_ONLY_REG, TOT_GST_ONLY_MISC, TOT_HOLDBACK_ONLY_REG, TOT_HOLDBACK_ONLY_MISC, TOT_REVHBK,
                            AMT_MANPAY, FINAL_ALL_EXPENSES, AMT_INCOME_MINUS_EXPENSES_G, DOC_YTDEAR_PLUS_AMT_MANPAY, fleF020_DOCTOR_MSTR, "DOC_YTDEAR");


                   
                    SubFile(ref m_trnTRANS_UPDATE, ref fleF119_TITHE_DTL, fleF190_COMP_CODES.GetStringValue("COMP_TYPE") == "I" && fleF116_GROUP.GetStringValue("TITHE_IN_EX_CLUDE_FLAG") == "I", SubFileType.Keep, fleF020_DOCTOR_MSTR, "DOC_OHIP_NBR",
                            fleF119_DOCTOR_YTD, "DOC_NBR", "COMP_CODE", fleF190_COMP_CODES, "REPORTING_SEQ", "COMP_CODE_GROUP", REC_TYPE_D, X_AMT_NET_DTL, X_AMT_GROSS_DTL);

                    SubFile(ref m_trnTRANS_UPDATE, ref fleF119_DOC_SUMM, fleF190_COMP_CODES.GetStringValue("COMP_TYPE") == "I" && fleF116_GROUP.GetStringValue("TITHE_IN_EX_CLUDE_FLAG") == "I", SubFileType.Keep, 
                        fleF020_DOCTOR_MSTR, "DOC_OHIP_NBR", DOC_NBR_SUMM, fleF119_DOCTOR_YTD, "COMP_CODE", fleF190_COMP_CODES, "REPORTING_SEQ", "COMP_CODE_GROUP", REC_TYPE_D, X_AMT_NET, X_AMT_GROSS);

                    //SubFile(ref m_trnTRANS_UPDATE, ref fleU115A0_MC, fleF119_DOCTOR_YTD.At("DOC_NBR"), SubFileType.Keep, fleF020_DOCTOR_MSTR, "DOC_OHIP_NBR", fleF119_DOCTOR_YTD, "DOC_NBR", X_COMP_CODE_TOTIT, TOTIT_SEQ_RPT, TOTIT_GROUP, REC_TYPE_D, TOT_TITHE_NET, TOT_TITHE_GROSS,
                    //        TOT_TITHE_NET_REG, TOT_TITHE_NET_MISC, TOT_TITHE_NET_OTHER);

                    SubFile(ref m_trnTRANS_UPDATE, ref fleF119_TOTIT_DOC, fleF119_DOCTOR_YTD.At("DOC_NBR"), TOT_TITHE_NET.Value != 0, SubFileType.Keep, fleF020_DOCTOR_MSTR, "DOC_OHIP_NBR", fleF119_DOCTOR_YTD, "DOC_NBR", X_COMP_CODE_TOTIT, TOTIT_SEQ_RPT, TOTIT_GROUP,
                            REC_TYPE_D, TOT_TITHE_NET, TOT_TITHE_GROSS);

                    SubFile(ref m_trnTRANS_UPDATE, ref fleF119_TOTIT_SUMM, fleF119_DOCTOR_YTD.At("DOC_NBR"), TOT_TITHE_NET.Value != 0, SubFileType.Keep, fleF020_DOCTOR_MSTR, "DOC_OHIP_NBR", DOC_NBR_SUMM, X_COMP_CODE_TOTIT, TOTIT_SEQ_RPT, TOTIT_GROUP,
                            REC_TYPE_D, TOT_TITHE_NET, TOT_TITHE_GROSS);





                    Reset(ref TOT_INCOME_GROSS_REG, fleF119_DOCTOR_YTD.At("DOC_NBR"));
                    Reset(ref TOT_INCOME_GROSS_MISC, fleF119_DOCTOR_YTD.At("DOC_NBR"));
                    Reset(ref TOT_INCOME_GROSS_OTHER, fleF119_DOCTOR_YTD.At("DOC_NBR"));
                    Reset(ref TOT_INCOME_NET_REG, fleF119_DOCTOR_YTD.At("DOC_NBR"));
                    Reset(ref TOT_INCOME_NET_MISC, fleF119_DOCTOR_YTD.At("DOC_NBR"));
                    Reset(ref TOT_INCOME_NET_OTHER, fleF119_DOCTOR_YTD.At("DOC_NBR"));
                    Reset(ref TOT_TITHE_GROSS_REG, fleF119_DOCTOR_YTD.At("DOC_NBR"));
                    Reset(ref TOT_TITHE_GROSS_MISC, fleF119_DOCTOR_YTD.At("DOC_NBR"));
                    Reset(ref TOT_TITHE_GROSS_OTHER, fleF119_DOCTOR_YTD.At("DOC_NBR"));
                    Reset(ref TOT_TITHE_NET_REG, fleF119_DOCTOR_YTD.At("DOC_NBR"));
                    Reset(ref TOT_TITHE_NET_MISC, fleF119_DOCTOR_YTD.At("DOC_NBR"));
                    Reset(ref TOT_TITHE_NET_OTHER, fleF119_DOCTOR_YTD.At("DOC_NBR"));
                    Reset(ref TOT_DEPT_EXPENSE_REG, fleF119_DOCTOR_YTD.At("DOC_NBR"));
                    Reset(ref TOT_DEPT_EXPENSE_MISC, fleF119_DOCTOR_YTD.At("DOC_NBR"));
                    Reset(ref TOT_RMA_EXPENSE_PLUS_GST_REG, fleF119_DOCTOR_YTD.At("DOC_NBR"));
                    Reset(ref TOT_RMA_EXPENSE_PLUS_GST_MISC, fleF119_DOCTOR_YTD.At("DOC_NBR"));
                    Reset(ref TOT_RMA_EXPENSE_ONLY_REG, fleF119_DOCTOR_YTD.At("DOC_NBR"));
                    Reset(ref TOT_RMA_EXPENSE_ONLY_MISC, fleF119_DOCTOR_YTD.At("DOC_NBR"));
                    Reset(ref TOT_GST_ONLY_REG, fleF119_DOCTOR_YTD.At("DOC_NBR"));
                    Reset(ref TOT_GST_ONLY_MISC, fleF119_DOCTOR_YTD.At("DOC_NBR"));
                    Reset(ref TOT_HOLDBACK_ONLY_REG, fleF119_DOCTOR_YTD.At("DOC_NBR"));
                    Reset(ref TOT_HOLDBACK_ONLY_MISC, fleF119_DOCTOR_YTD.At("DOC_NBR"));
                    Reset(ref TOT_REVHBK, fleF119_DOCTOR_YTD.At("DOC_NBR"));
                    Reset(ref AMT_MANPAY, fleF119_DOCTOR_YTD.At("DOC_NBR"));
                }
            }

            catch (CustomApplicationException ex)
            {
                WriteError(ex);
            }

            catch (Exception ex)
            {
                WriteError(ex);
            }

            finally
            {
                EndRequest("U115A_0_U115_RUN_0_11");
            }
        }

        #endregion
    }
}

