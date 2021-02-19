
#region "Screen Comments"

// #> program-id.     u115a_1.qts
// ((C)) Dyad Technologies
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
// 2008/may/10 brad2     -  AFPADJ  transactions no longer shown on r124a stmnts
// nor the `94` screen - moved to  +  type transactions
// in f119 to `hide` them (shown on new 96 screen)
// 2008/jun/05 M.C.      - change access to link to f116-dtl file
// - change criteria when calculating amounts for TOTINC
// - modify criteria in $src/u115_common.qts
// - create records in new subfile f119_tithe
// 2008/aug/19 M.C.      - prompt for global parameter for payroll-flag
// 2008/sep/29 M.C.      - access to use f119 instead of f110 since titheable records have rec-type = `D` in f119
// which were generated from u130.qts
// 2008/oct/21 M.C. - clone from u115a_0.qts but this time to use f110 instead of f119 and take out the select statement
// 2008/oct/22 brad1 - try various locking statements to see if performance altered
// 2008/nov/17 M.C. - delete all commented codes to avoid confusion
// - we must either add/update f119 for all the titheable comp code extract from f110 in order to see
// properly on the 97 screen
// 2008/nov/19 MC1 - change the definition for x-amt-net to consider `MICG`
// 2008/nov/20 MC2 - undo MC1, use gross amt instead
// - change the definition for x-amt-gross to consider `MICG`
// - since tithe calculation is calculated based on the amt-gross, we must also change to show
// the titheable comp code with amt-gross as the mtd instead of amt-net
// 2015/Jun/25 MC3       - add second linkage to f116-dtl for the actual doc-nbr for determine tithe
// brad1
// set lock file update


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;
 
public class U115A_1 : BaseClassControl
{
    private U115A_1 m_U115A_1;

    public U115A_1(string Name, int Level)
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
        //PAYROLL_FLAG = new CoreCharacter("PAYROLL_FLAG", 1, this, ResetTypes.ResetAtStartup, Prompt(1).ToString());
        PAYROLL_FLAG = new CoreCharacter("PAYROLL_FLAG", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        TOTITE_GROUP = new CoreCharacter("TOTITE_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        TOTITE_SEQ_RPT = new CoreDecimal("TOTITE_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        TOTITD_GROUP = new CoreCharacter("TOTITD_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        TOTITD_SEQ_RPT = new CoreDecimal("TOTITD_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
    }

    public U115A_1(string Name, int Level, bool Request)
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
        if ((m_U115A_1 != null))
        {
            m_U115A_1.CloseTransactionObjects();
            m_U115A_1 = null;
        }
    }

    public U115A_1 GetU115A_1(int Level)
    {
        if (m_U115A_1 == null)
        {
            m_U115A_1 = new U115A_1("U115A_1", Level);
        }
        else
        {
            m_U115A_1.ResetValues();
        }
        return m_U115A_1;
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

            U115A_1_U115_A_GET_YTDEAR_1 U115_A_GET_YTDEAR_1 = new U115A_1_U115_A_GET_YTDEAR_1(Name, Level);
            U115_A_GET_YTDEAR_1.Run();
            U115_A_GET_YTDEAR_1.Dispose();
            U115_A_GET_YTDEAR_1 = null;

            U115A_1_U115_A_GET_RMAEXR_2 U115_A_GET_RMAEXR_2 = new U115A_1_U115_A_GET_RMAEXR_2(Name, Level);
            U115_A_GET_RMAEXR_2.Run();
            U115_A_GET_RMAEXR_2.Dispose();
            U115_A_GET_RMAEXR_2 = null;

            U115A_1_U115_A_GET_RMAEXM_3 U115_A_GET_RMAEXM_3 = new U115A_1_U115_A_GET_RMAEXM_3(Name, Level);
            U115_A_GET_RMAEXM_3.Run();
            U115_A_GET_RMAEXM_3.Dispose();
            U115_A_GET_RMAEXM_3 = null;

            U115A_1_U115_A_GET_INCEXP_4 U115_A_GET_INCEXP_4 = new U115A_1_U115_A_GET_INCEXP_4(Name, Level);
            U115_A_GET_INCEXP_4.Run();
            U115_A_GET_INCEXP_4.Dispose();
            U115_A_GET_INCEXP_4 = null;

            U115A_1_U115_A_GET_TOTINC_5 U115_A_GET_TOTINC_5 = new U115A_1_U115_A_GET_TOTINC_5(Name, Level);
            U115_A_GET_TOTINC_5.Run();
            U115_A_GET_TOTINC_5.Dispose();
            U115_A_GET_TOTINC_5 = null;

            U115A_1_U115_A_GET_TOTEXP_6 U115_A_GET_TOTEXP_6 = new U115A_1_U115_A_GET_TOTEXP_6(Name, Level);
            U115_A_GET_TOTEXP_6.Run();
            U115_A_GET_TOTEXP_6.Dispose();
            U115_A_GET_TOTEXP_6 = null;

            U115A_1_U115_A_GET_DEPEXR_7 U115_A_GET_DEPEXR_7 = new U115A_1_U115_A_GET_DEPEXR_7(Name, Level);
            U115_A_GET_DEPEXR_7.Run();
            U115_A_GET_DEPEXR_7.Dispose();
            U115_A_GET_DEPEXR_7 = null;

            U115A_1_U115_A_GET_DEPEXM_8 U115_A_GET_DEPEXM_8 = new U115A_1_U115_A_GET_DEPEXM_8(Name, Level);
            U115_A_GET_DEPEXM_8.Run();
            U115_A_GET_DEPEXM_8.Dispose();
            U115_A_GET_DEPEXM_8 = null;

            U115A_1_U115_A_GET_GST_9 U115_A_GET_GST_9 = new U115A_1_U115_A_GET_GST_9(Name, Level);
            U115_A_GET_GST_9.Run();
            U115_A_GET_GST_9.Dispose();
            U115_A_GET_GST_9 = null;

            U115A_1_U115_A_GET_HOLDBACK_10 U115_A_GET_HOLDBACK_10 = new U115A_1_U115_A_GET_HOLDBACK_10(Name, Level);
            U115_A_GET_HOLDBACK_10.Run();
            U115_A_GET_HOLDBACK_10.Dispose();
            U115_A_GET_HOLDBACK_10 = null;

            U115A_1_U115_RUN_0_11 U115_RUN_0_11 = new U115A_1_U115_RUN_0_11(Name, Level);
            U115_RUN_0_11.Run();
            U115_RUN_0_11.Dispose();
            U115_RUN_0_11 = null;

            U115A_1_U115_SUMMARIZE_F119_TITHE_12 U115_SUMMARIZE_F119_TITHE_12 = new U115A_1_U115_SUMMARIZE_F119_TITHE_12(Name, Level);
            U115_SUMMARIZE_F119_TITHE_12.Run();
            U115_SUMMARIZE_F119_TITHE_12.Dispose();
            U115_SUMMARIZE_F119_TITHE_12 = null;

            U115A_1_U115_ADD_UPDATE_F119_TITHE_COMP_CODE_13 U115_ADD_UPDATE_F119_TITHE_COMP_CODE_13 = new U115A_1_U115_ADD_UPDATE_F119_TITHE_COMP_CODE_13(Name, Level);
            U115_ADD_UPDATE_F119_TITHE_COMP_CODE_13.Run();
            U115_ADD_UPDATE_F119_TITHE_COMP_CODE_13.Dispose();
            U115_ADD_UPDATE_F119_TITHE_COMP_CODE_13 = null;

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

    public class U115A_1_U115_A_GET_YTDEAR_1 : U115A_1
    {
        public U115A_1_U115_A_GET_YTDEAR_1(string Name, int Level)
            : base(Name, Level, true)
        {
            this.ScreenType = ScreenTypes.QTP;
            fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

            fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;
        }

        #region "Declarations (Variables, Files and Transactions)(U115A_1_U115_A_GET_YTDEAR_1)"

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

        #region "Standard Generated Procedures(U115A_1_U115_A_GET_YTDEAR_1)"

        #region "Transaction Management Procedures(U115A_1_U115_A_GET_YTDEAR_1)"

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

        #region "FILE Management Procedures(U115A_1_U115_A_GET_YTDEAR_1)"

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

        #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U115A_1_U115_A_GET_YTDEAR_1)"

        public void Run()
        {
            try
            {
                Request("U115A_1_U115_A_GET_YTDEAR_1");

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
                EndRequest("U115A_1_U115_A_GET_YTDEAR_1");
            }
        }

        #endregion

    }

    public class U115A_1_U115_A_GET_RMAEXR_2 : U115A_1
    {
        public U115A_1_U115_A_GET_RMAEXR_2(string Name, int Level)
            : base(Name, Level, true)
        {
            this.ScreenType = ScreenTypes.QTP;
            fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

            fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;
        }

        #region "Declarations (Variables, Files and Transactions)(U115A_1_U115_A_GET_RMAEXR_2)"

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

        #region "Standard Generated Procedures(U115A_1_U115_A_GET_RMAEXR_2)"

        #region "Transaction Management Procedures(U115A_1_U115_A_GET_RMAEXR_2)"

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

        #region "FILE Management Procedures(U115A_1_U115_A_GET_RMAEXR_2)"

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

        #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U115A_1_U115_A_GET_RMAEXR_2)"

        public void Run()
        {
            try
            {
                Request("U115A_1_U115_A_GET_RMAEXR_2");

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
                EndRequest("U115A_1_U115_A_GET_RMAEXR_2");
            }
        }

        #endregion
    }

    public class U115A_1_U115_A_GET_RMAEXM_3 : U115A_0
    {
        public U115A_1_U115_A_GET_RMAEXM_3(string Name, int Level)
            : base(Name, Level, true)
        {
            this.ScreenType = ScreenTypes.QTP;
            fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

            fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;
        }

        #region "Declarations (Variables, Files and Transactions)(U115A_1_U115_U115_A_GET_RMAEXM_3)"

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

        #region "Standard Generated Procedures(U115A_1_U115_U115_A_GET_RMAEXM_3)"

        #region "Transaction Management Procedures(U115A_1_U115_U115_A_GET_RMAEXM_3)"

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

        #region "FILE Management Procedures(U115A_1_U115_U115_A_GET_RMAEXM_3)"

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

        #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U115A_1_U115_U115_A_GET_RMAEXM_3)"

        public void Run()
        {
            try
            {
                Request("U115A_1_U115_A_GET_RMAEXM_3");

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
                EndRequest("U115A_1_U115_A_GET_RMAEXM_3");
            }
        }

        #endregion
    }

    public class U115A_1_U115_A_GET_INCEXP_4 : U115A_0
    {
        public U115A_1_U115_A_GET_INCEXP_4(string Name, int Level)
            : base(Name, Level, true)
        {
            this.ScreenType = ScreenTypes.QTP;
            fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

            fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;
        }

        #region "Declarations (Variables, Files and Transactions)(U115A_1_U115_A_GET_INCEXP_4)"

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

        #region "Standard Generated Procedures(U115A_1_U115_A_GET_INCEXP_4)"

        #region "Transaction Management Procedures(U115A_1_U115_A_GET_INCEXP_4)"

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

        #region "FILE Management Procedures(U115A_1_U115_A_GET_INCEXP_4)"

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

        #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U115A_1_U115_A_GET_INCEXP_4)"

        public void Run()
        {
            try
            {
                Request("U115A_1_U115_A_GET_INCEXP_4");

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
                EndRequest("U115A_1_U115_A_GET_INCEXP_4");
            }
        }

        #endregion
    }

    public class U115A_1_U115_A_GET_TOTINC_5 : U115A_0
    {
        public U115A_1_U115_A_GET_TOTINC_5(string Name, int Level)
            : base(Name, Level, true)
        {
            this.ScreenType = ScreenTypes.QTP;
            fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

            fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;
        }

        #region "Declarations (Variables, Files and Transactions)(U115A_1_U115_A_GET_TOTINC_5)"

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

        #region "Standard Generated Procedures(U115A_1_U115_A_GET_TOTINC_5)"

        #region "Transaction Management Procedures(U115A_1_U115_A_GET_TOTINC_5)"

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

        #region "FILE Management Procedures(U115A_1_U115_A_GET_TOTINC_5)"

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

        #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U115A_1_U115_A_GET_TOTINC_5)"

        public void Run()
        {
            try
            {
                Request("U115A_1_U115_A_GET_TOTINC_5");

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
                EndRequest("U115A_1_U115_A_GET_TOTINC_5");
            }
        }

        #endregion
    }

    public class U115A_1_U115_A_GET_TOTEXP_6 : U115A_0
    {
        public U115A_1_U115_A_GET_TOTEXP_6(string Name, int Level)
            : base(Name, Level, true)
        {
            this.ScreenType = ScreenTypes.QTP;
            fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

            fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;
        }

        #region "Declarations (Variables, Files and Transactions)(U115A_1_U115_A_GET_TOTEXP_6)"

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

        #region "Standard Generated Procedures(U115A_1_U115_A_GET_TOTEXP_6)"

        #region "Transaction Management Procedures(U115A_1_U115_A_GET_TOTEXP_6)"

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

        #region "FILE Management Procedures(U115A_1_U115_A_GET_TOTEXP_6)"

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

        #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U115A_1_U115_A_GET_TOTEXP_6)"

        public void Run()
        {
            try
            {
                Request("U115A_1_U115_A_GET_TOTEXP_6");

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
                EndRequest("U115A_1_U115_A_GET_TOTEXP_6");
            }
        }

        #endregion
    }

    public class U115A_1_U115_A_GET_DEPEXR_7 : U115A_0
    {
        public U115A_1_U115_A_GET_DEPEXR_7(string Name, int Level)
            : base(Name, Level, true)
        {
            this.ScreenType = ScreenTypes.QTP;
            fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

            fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;
        }

        #region "Declarations (Variables, Files and Transactions)(U115A_1_U115_A_GET_DEPEXR_7)"

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

        #region "Standard Generated Procedures(U115A_1_U115_A_GET_DEPEXR_7)"

        #region "Transaction Management Procedures(U115A_1_U115_A_GET_DEPEXR_7)"

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

        #region "FILE Management Procedures(U115A_1_U115_A_GET_DEPEXR_7)"

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

        #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U115A_1_U115_A_GET_DEPEXR_7)"

        public void Run()
        {
            try
            {
                Request("U115A_1_U115_A_GET_DEPEXR_7");

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
                EndRequest("U115A_1_U115_A_GET_DEPEXR_7");
            }
        }

        #endregion
    }

    public class U115A_1_U115_A_GET_DEPEXM_8 : U115A_0
    {
        public U115A_1_U115_A_GET_DEPEXM_8(string Name, int Level)
            : base(Name, Level, true)
        {
            this.ScreenType = ScreenTypes.QTP;
            fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

            fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;
        }

        #region "Declarations (Variables, Files and Transactions)(U115A_1_U115_A_GET_DEPEXM_8)"

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

        #region "Standard Generated Procedures(U115A_1_U115_A_GET_DEPEXM_8)"

        #region "Transaction Management Procedures(U115A_1_U115_A_GET_DEPEXM_8)"

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

        #region "FILE Management Procedures(U115A_1_U115_A_GET_DEPEXM_8)"

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

        #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U115A_1_U115_A_GET_DEPEXM_8)"

        public void Run()
        {
            try
            {
                Request("U115A_1_U115_A_GET_DEPEXM_8");

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
                EndRequest("U115A_1_U115_A_GET_DEPEXM_8");
            }
        }

        #endregion
    }

    public class U115A_1_U115_A_GET_GST_9 : U115A_0
    {
        public U115A_1_U115_A_GET_GST_9(string Name, int Level)
            : base(Name, Level, true)
        {
            this.ScreenType = ScreenTypes.QTP;
            fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

            fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;
        }

        #region "Declarations (Variables, Files and Transactions)(U115A_1_U115_A_GET_GST_9)"

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

        #region "Standard Generated Procedures(U115A_1_U115_A_GET_GST_9)"

        #region "Transaction Management Procedures(U115A_1_U115_A_GET_GST_9)"

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

        #region "FILE Management Procedures(U115A_1_U115_A_GET_GST_9)"

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

        #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U115A_1_U115_A_GET_GST_9)"

        public void Run()
        {
            try
            {
                Request("U115A_1_U115_A_GET_GST_9");

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
                EndRequest("U115A_1_U115_A_GET_GST_9");
            }
        }

        #endregion
    }

    public class U115A_1_U115_A_GET_HOLDBACK_10 : U115A_0
    {
        public U115A_1_U115_A_GET_HOLDBACK_10(string Name, int Level)
            : base(Name, Level, true)
        {
            this.ScreenType = ScreenTypes.QTP;
            fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

            fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;
        }

        #region "Declarations (Variables, Files and Transactions)(U115A_1_U115_A_GET_HOLDBACK_10)"

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

        #region "Standard Generated Procedures(U115A_1_U115_A_GET_HOLDBACK_10)"

        #region "Transaction Management Procedures(U115A_1_U115_A_GET_HOLDBACK_10)"

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

        #region "FILE Management Procedures(U115A_1_U115_A_GET_HOLDBACK_10)"

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

        #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U115A_1_U115_A_GET_HOLDBACK_10)"

        public void Run()
        {
            try
            {
                Request("U115A_1_U115_A_GET_HOLDBACK_10");

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
                EndRequest("U115A_1_U115_A_GET_HOLDBACK_10");
            }
        }

        #endregion
    }

    public class U115A_1_U115_RUN_0_11 : U115A_0
    {
        public U115A_1_U115_RUN_0_11(string Name, int Level)
            : base(Name, Level, true)
        {
            this.ScreenType = ScreenTypes.QTP;
            fleCONSTANTS_MSTR_REC_6 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "CONSTANTS_MSTR_REC_6", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF110_COMPENSATION = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
           fleF116_GROUP = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F116_DEPT_EXPENSE_RULES_DTL", "F116_GROUP", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF116_DOC = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F116_DEPT_EXPENSE_RULES_DTL", "F116_DOC", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleDEBUGU115A_1_AT_COMP_CODE = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "DEBUGU115A_1_AT_COMP_CODE", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
            fleDEBUGU115A_1_AT_DOC_NBR = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "DEBUGU115A_1_AT_DOC_NBR", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
            fleF119_TITHE_DTL = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F119_TITHE_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
            fleF119_DOC_SUMM = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F119_TITHE_DTL", "F119_DOC_SUMM", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF119_TOTIT_DOC = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F119_TITHE_DTL", "F119_TOTIT_DOC", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF119_TOTIT_SUMM = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F119_TITHE_DTL", "F119_TOTIT_SUMM ", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF110_TITHE_DTL = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F110_TITHE_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
            //fleU115A1_MC = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U115A1_MC", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

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
            X_AMT_NET_DTL.GetValue += X_AMT_NET_DTL_GetValue;
            X_AMT_GROSS_DTL.GetValue += X_AMT_GROSS_DTL_GetValue;
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
            X_AMT_GROSS_ADJUST.GetValue += X_AMT_GROSS_ADJUST_GetValue;
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
        }

        #region "Declarations (Variables, Files and Transactions)(U115A_1_U115_RUN_0_11)"

        private SqlFileObject fleCONSTANTS_MSTR_REC_6;

        private void fleCONSTANTS_MSTR_REC_6_Choose(ref string ChooseClause)
        {
            try
            {
                StringBuilder strSQL = new StringBuilder("");

                strSQL.Append(fleCONSTANTS_MSTR_REC_6.ElementOwner("CONST_REC_NBR")).Append(" = ");
                strSQL.Append(6);

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

        private SqlFileObject fleF110_COMPENSATION;
        private SqlFileObject fleF020_DOCTOR_MSTR;
        private SqlFileObject fleF116_GROUP;
        private SqlFileObject fleF116_DOC;
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

        //Use file U115_COMMON_F110.QTS
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
        //; 2008/nov/19 MC1   - add new defined item  x-amt-net-adjust
        //;	              change the definition for  tot-tithe-net-misc include 'MICG' 
        //; 2008/nov/20 MC2   - undo MC1 above
        //;		    -  add new defined item  x-amt-gross-adjust
        //;	              change the definition for  tot-tithe-gross-misc include 'MICG' 
        //;
        //; ----------- CALCULATIONS PERFORMED AT COMP-CODE LEVEL ------------

        //; (Determine Expenses charged(difference between GROSS and NET) using
        //;  FACTOR or non-zero Expense Percentages as indicators as to type of charges
        //; applied)

        private DDecimal X_INCOME_GROSS_MINUS_NET = new DDecimal("X_INCOME_GROSS_MINUS_NET", 8);
        private void X_INCOME_GROSS_MINUS_NET_GetValue(ref decimal Value)
        {
            try
            {
                Value = fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS") - fleF110_COMPENSATION.GetDecimalValue("AMT_NET");
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
                    Value = QDesign.Round((fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS")));
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
                    CurrentValue = QDesign.Round((fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS") / 1000000) * QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_REG")), 0, RoundOptionTypes.Near);
                }
                else if (fleF190_COMP_CODES.GetStringValue("COMP_TYPE") == "I" && fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE") == "M" && (!fleF116_GROUP.Exists() || (fleF116_GROUP.Exists() && fleF116_GROUP.GetStringValue("TITHE_IN_EX_CLUDE_FLAG") == "E") || (fleF116_GROUP.Exists() && fleF116_GROUP.GetStringValue("TITHE_IN_EX_CLUDE_FLAG") == "I" && fleF116_GROUP.GetStringValue("FLAG_DISPLAY_HIDE") == "N")))
                {
                    CurrentValue = QDesign.Round((fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS") / 1000000) * QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_MISC")), 0, RoundOptionTypes.Near);
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

                if ((X_AMT_DEPT_EXPENSE_POT_G.Value < X_INCOME_GROSS_MINUS_NET.Value && QDesign.NULL(fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS")) > 0) || (X_AMT_DEPT_EXPENSE_POT_G.Value > X_INCOME_GROSS_MINUS_NET.Value && QDesign.NULL(fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS")) < 0))
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
                    CurrentValue = QDesign.Round((fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS") / 1000000) * QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_REG")), 0, RoundOptionTypes.Near);
                }
                else if (fleF190_COMP_CODES.GetStringValue("COMP_TYPE") == "I" && fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE") == "M" && (!fleF116_GROUP.Exists() || (fleF116_GROUP.Exists() && fleF116_GROUP.GetStringValue("TITHE_IN_EX_CLUDE_FLAG") == "E") || (fleF116_GROUP.Exists() && fleF116_GROUP.GetStringValue("TITHE_IN_EX_CLUDE_FLAG") == "I" && fleF116_GROUP.GetStringValue("FLAG_DISPLAY_HIDE") == "N")))
                {
                    CurrentValue = QDesign.Round((fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS") / 1000000) * QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_MISC")), 0, RoundOptionTypes.Near);
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

                if ((X_INCOME_GROSS_MINUS_NET.Value > (X_AMT_DEPT_EXPENSE_G.Value + X_AMT_RMA_EXPENSE_POT_G.Value) && QDesign.NULL(fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS")) > 0) || (X_INCOME_GROSS_MINUS_NET.Value < (X_AMT_DEPT_EXPENSE_G.Value + X_AMT_RMA_EXPENSE_POT_G.Value) && QDesign.NULL(fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS")) < 0))
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

                if ((((X_INCOME_GROSS_MINUS_NET.Value > (X_AMT_DEPT_EXPENSE_G.Value + X_AMT_RMA_EXPENSE_ONLY.Value + X_AMT_GST_POT_G.Value)) && QDesign.NULL(fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS")) > 0) || ((X_INCOME_GROSS_MINUS_NET.Value < (X_AMT_DEPT_EXPENSE_G.Value + X_AMT_RMA_EXPENSE_ONLY.Value + X_AMT_GST_POT_G.Value)) && QDesign.NULL(fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS")) < 0)) && (X_AMT_ROUND_OFF.Value > 5))
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

                if (((X_INCOME_GROSS_MINUS_NET.Value > (X_AMT_DEPT_EXPENSE_G.Value + X_AMT_RMA_EXPENSE_PLUS_GST_G.Value) && QDesign.NULL(fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS")) > 0) || (X_INCOME_GROSS_MINUS_NET.Value < (X_AMT_DEPT_EXPENSE_G.Value + X_AMT_RMA_EXPENSE_PLUS_GST_G.Value) && QDesign.NULL(fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS")) < 0)))
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

        private DDecimal X_AMT_GROSS_ADJUST = new DDecimal("X_AMT_GROSS_ADJUST", 10);
        private void X_AMT_GROSS_ADJUST_GetValue(ref decimal Value)
        {
            try
            {
                if (fleF110_COMPENSATION.GetStringValue("COMP_CODE") == "MICG")
                {
                    Value = fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS") * 4;
                }
                else
                {
                    Value = fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS");
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

        //; if new record, initial YTD record in F119.  (required only for
        //; "I"ncome, AND "E"xpense records - .ie calc rec types like CEICEA are
        //;  needed AND the "D"eduction records are handled in the tax/eft processing)

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
                if (fleF110_COMPENSATION.GetStringValue("COMP_CODE") == "CEIEXP")
                {
                    Value = fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS");
                }
                else
                {
                    Value = fleF110_COMPENSATION.GetDecimalValue("AMT_NET");
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
                if (fleF110_COMPENSATION.GetStringValue("COMP_CODE") == "CEIEXP")
                {
                    Value = fleF110_COMPENSATION.GetDecimalValue("AMT_NET");
                }
                else if (fleF110_COMPENSATION.GetStringValue("COMP_CODE") == "MICG")
                {
                    Value = fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS") * 4;
                }
                else
                {
                    Value = fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS");
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

        private SqlFileObject fleDEBUGU115A_1_AT_COMP_CODE;
        private SqlFileObject fleDEBUGU115A_1_AT_DOC_NBR;

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

        private SqlFileObject fleF119_TITHE_DTL;
        private SqlFileObject fleF119_DOC_SUMM;
        private SqlFileObject fleF119_TOTIT_DOC;
        private SqlFileObject fleF119_TOTIT_SUMM;


        private SqlFileObject fleF110_TITHE_DTL;

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
                else if (PAYROLL_FLAG.Value == "C")
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

        //private SqlFileObject fleU115A1_MC;

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

        #region "Standard Generated Procedures(U115A_1_U115_RUN_0_11)"

        #region "Transaction Management Procedures(U115A_1_U115_RUN_0_11)"

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
            fleCONSTANTS_MSTR_REC_6.Transaction = m_trnTRANS_UPDATE;
            fleF110_COMPENSATION.Transaction = m_trnTRANS_UPDATE;
            fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
            fleF116_GROUP.Transaction = m_trnTRANS_UPDATE;
            fleF116_DOC.Transaction = m_trnTRANS_UPDATE;
            fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;
            fleDEBUGU115A_1_AT_COMP_CODE.Transaction = m_trnTRANS_UPDATE;
            fleDEBUGU115A_1_AT_DOC_NBR.Transaction = m_trnTRANS_UPDATE;
            fleF119_TITHE_DTL.Transaction = m_trnTRANS_UPDATE;
            fleF110_TITHE_DTL.Transaction = m_trnTRANS_UPDATE;
            //fleU115A1_MC.Transaction = m_trnTRANS_UPDATE;
        }

        #endregion

        #region "FILE Management Procedures(U115A_1_U115_RUN_0_11)"

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
                fleCONSTANTS_MSTR_REC_6.Dispose();
                fleF110_COMPENSATION.Dispose();
                fleF020_DOCTOR_MSTR.Dispose();
                fleF116_GROUP.Dispose();
                fleF116_DOC.Dispose();
                fleF190_COMP_CODES.Dispose();
                fleDEBUGU115A_1_AT_COMP_CODE.Dispose();
                fleDEBUGU115A_1_AT_DOC_NBR.Dispose();
                fleF119_TITHE_DTL.Dispose();
                fleF110_TITHE_DTL.Dispose();
                //fleU115A1_MC.Dispose();
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

        #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U115A_1_U115_RUN_0_11)"

        public void Run()
        {
            try
            {
                Request("U115A_1_U115_RUN_0_11");

                while (fleCONSTANTS_MSTR_REC_6.QTPForMissing())
                {
                    // --> GET fleCONSTANTS_MSTR_REC_6 <--
                    fleCONSTANTS_MSTR_REC_6.GetData();
                    // --> End GET fleCONSTANTS_MSTR_REC_6 <--

                    while (fleF110_COMPENSATION.QTPForMissing("1"))
                    {
                        // --> GET fleF110_COMPENSATION <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(fleF110_COMPENSATION.ElementOwner("EP_NBR")).Append(" = ");
                        m_strWhere.Append(fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR"));

                        fleF110_COMPENSATION.GetData(m_strWhere.ToString());
                        // --> End GET fleF110_COMPENSATION <--

                        while (fleF020_DOCTOR_MSTR.QTPForMissing("2"))
                        {
                            // --> GET fleF020_DOCTOR_MSTR <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                            m_strWhere.Append(Common.StringToField(fleF110_COMPENSATION.GetStringValue("DOC_NBR")));

                            fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString());
                            // --> End GET fleF020_DOCTOR_MSTR <--

                            while (fleF116_GROUP.QTPForMissing("3"))
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
                                m_strWhere.Append(Common.StringToField(fleF110_COMPENSATION.GetStringValue("COMP_CODE")));

                                fleF116_GROUP.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                // --> End GET fleF116_GROUP <--



                                while (fleF116_DOC.QTPForMissing("4"))
                                {
                                    // --> GET fleF116_DOC <--
                                    m_strWhere = new StringBuilder(" WHERE ");
                                    m_strWhere.Append(fleF116_DOC.ElementOwner("DEPT_EXPENSE_CALC_CODE")).Append(" = ");
                                    m_strWhere.Append(Common.StringToField("FLAT+3_TITHE_LEVELS"));
                                    m_strWhere.Append(" AND ").Append(fleF116_DOC.ElementOwner("DEPT_NBR")).Append(" = ");
                                    m_strWhere.Append(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT"));
                                    m_strWhere.Append(" AND ").Append(fleF116_DOC.ElementOwner("DOC_AFP_PAYM_GROUP")).Append(" = ");
                                    m_strWhere.Append(Common.StringToField(fleF020_DOCTOR_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP")));
                                    m_strWhere.Append(" AND ").Append(fleF116_DOC.ElementOwner("DOC_NBR")).Append(" = ");
                                    m_strWhere.Append(Common.StringToField(fleF110_COMPENSATION.GetStringValue("DOC_NBR")));
                                    m_strWhere.Append(" AND ").Append(fleF116_DOC.ElementOwner("COMP_CODE")).Append(" = ");
                                    m_strWhere.Append(Common.StringToField(fleF110_COMPENSATION.GetStringValue("COMP_CODE")));

                                    fleF116_DOC.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                    // --> End GET fleF116_DOC <--

                                    while (fleF190_COMP_CODES.QTPForMissing("5"))
                                    {
                                        // --> GET fleF190_COMP_CODES <--
                                        m_strWhere = new StringBuilder(" WHERE ");
                                        m_strWhere.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
                                        m_strWhere.Append(Common.StringToField(fleF110_COMPENSATION.GetStringValue("COMP_CODE")));

                                        fleF190_COMP_CODES.GetData(m_strWhere.ToString());
                                        // --> End GET fleF190_COMP_CODES <--

                                        if (Transaction())
                                        {
                                            Sort(fleF110_COMPENSATION.GetSortValue("DOC_NBR"), fleF110_COMPENSATION.GetSortValue("EP_NBR"), fleF110_COMPENSATION.GetSortValue("COMP_CODE"));
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                while (Sort(fleCONSTANTS_MSTR_REC_6, fleF110_COMPENSATION, fleF020_DOCTOR_MSTR, fleF116_GROUP, fleF116_DOC, fleF190_COMP_CODES))
                {
                    if (fleF190_COMP_CODES.GetStringValue("COMP_TYPE") == "I" && fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE") == "R" && (!fleF116_GROUP.Exists() || (fleF116_GROUP.Exists() && fleF116_GROUP.GetStringValue("TITHE_IN_EX_CLUDE_FLAG") == "E") || (fleF116_GROUP.Exists() && fleF116_GROUP.GetStringValue("TITHE_IN_EX_CLUDE_FLAG") == "I" && fleF116_GROUP.GetStringValue("FLAG_DISPLAY_HIDE") == "N")))
                    {
                        TOT_INCOME_GROSS_REG.Value = TOT_INCOME_GROSS_REG.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS");
                    }

                    if (fleF190_COMP_CODES.GetStringValue("COMP_TYPE") == "I" && fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE") == "M" && (!fleF116_GROUP.Exists() || (fleF116_GROUP.Exists() && fleF116_GROUP.GetStringValue("TITHE_IN_EX_CLUDE_FLAG") == "E") || (fleF116_GROUP.Exists() && fleF116_GROUP.GetStringValue("TITHE_IN_EX_CLUDE_FLAG") == "I" && fleF116_GROUP.GetStringValue("FLAG_DISPLAY_HIDE") == "N")))
                    {
                        TOT_INCOME_GROSS_MISC.Value = TOT_INCOME_GROSS_MISC.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS");
                    }

                    if (fleF190_COMP_CODES.GetStringValue("COMP_TYPE") == "I" && fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE") == "O" && (!fleF116_GROUP.Exists() || (fleF116_GROUP.Exists() && fleF116_GROUP.GetStringValue("TITHE_IN_EX_CLUDE_FLAG") == "E") || (fleF116_GROUP.Exists() && fleF116_GROUP.GetStringValue("TITHE_IN_EX_CLUDE_FLAG") == "I" && fleF116_GROUP.GetStringValue("FLAG_DISPLAY_HIDE") == "N")))
                    {
                        TOT_INCOME_GROSS_OTHER.Value = TOT_INCOME_GROSS_OTHER.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS");
                    }

                    if (fleF190_COMP_CODES.GetStringValue("COMP_TYPE") == "I" && fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE") == "R" && (!fleF116_GROUP.Exists() || (fleF116_GROUP.Exists() && fleF116_GROUP.GetStringValue("TITHE_IN_EX_CLUDE_FLAG") == "E") || (fleF116_GROUP.Exists() && fleF116_GROUP.GetStringValue("TITHE_IN_EX_CLUDE_FLAG") == "I" && fleF116_GROUP.GetStringValue("FLAG_DISPLAY_HIDE") == "N")))
                    {
                        TOT_INCOME_NET_REG.Value = TOT_INCOME_NET_REG.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET");
                    }

                    if (fleF190_COMP_CODES.GetStringValue("COMP_TYPE") == "I" && fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE") == "M" && (!fleF116_GROUP.Exists() || (fleF116_GROUP.Exists() && fleF116_GROUP.GetStringValue("TITHE_IN_EX_CLUDE_FLAG") == "E") || (fleF116_GROUP.Exists() && fleF116_GROUP.GetStringValue("TITHE_IN_EX_CLUDE_FLAG") == "I" && fleF116_GROUP.GetStringValue("FLAG_DISPLAY_HIDE") == "N")))
                    {
                        TOT_INCOME_NET_MISC.Value = TOT_INCOME_NET_MISC.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET");
                    }

                    if (fleF190_COMP_CODES.GetStringValue("COMP_TYPE") == "I" && fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE") == "O" && (!fleF116_GROUP.Exists() || (fleF116_GROUP.Exists() && fleF116_GROUP.GetStringValue("TITHE_IN_EX_CLUDE_FLAG") == "E") || (fleF116_GROUP.Exists() && fleF116_GROUP.GetStringValue("TITHE_IN_EX_CLUDE_FLAG") == "I" && fleF116_GROUP.GetStringValue("FLAG_DISPLAY_HIDE") == "N")))
                    {
                        TOT_INCOME_NET_OTHER.Value = TOT_INCOME_NET_OTHER.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET");
                    }

                    if (fleF190_COMP_CODES.GetStringValue("COMP_TYPE") == "I" && fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE") == "R" && fleF116_GROUP.Exists() && fleF116_GROUP.GetStringValue("TITHE_IN_EX_CLUDE_FLAG") == "I")
                    {
                        TOT_TITHE_GROSS_REG.Value = TOT_TITHE_GROSS_REG.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS");
                    }

                    if (fleF190_COMP_CODES.GetStringValue("COMP_TYPE") == "I" && fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE") == "M" && fleF116_GROUP.Exists() && fleF116_GROUP.GetStringValue("TITHE_IN_EX_CLUDE_FLAG") == "I")
                    {
                        TOT_TITHE_GROSS_MISC.Value = TOT_TITHE_GROSS_MISC.Value + X_AMT_GROSS_ADJUST.Value;
                    }

                    if (fleF190_COMP_CODES.GetStringValue("COMP_TYPE") == "I" && fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE") == "O" && fleF116_GROUP.Exists() && fleF116_GROUP.GetStringValue("TITHE_IN_EX_CLUDE_FLAG") == "I")
                    {
                        TOT_TITHE_GROSS_OTHER.Value = TOT_TITHE_GROSS_OTHER.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS");
                    }




                    if (fleF190_COMP_CODES.GetStringValue("COMP_TYPE") == "I" && fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE") == "R" && fleF116_GROUP.Exists() && fleF116_GROUP.GetStringValue("TITHE_IN_EX_CLUDE_FLAG") == "I")
                    {
                        TOT_TITHE_NET_REG.Value = TOT_TITHE_NET_REG.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET");
                    }

                    if (fleF190_COMP_CODES.GetStringValue("COMP_TYPE") == "I" && fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE") == "M" && fleF116_GROUP.Exists() && fleF116_GROUP.GetStringValue("TITHE_IN_EX_CLUDE_FLAG") == "I")
                    {
                        TOT_TITHE_NET_MISC.Value = TOT_TITHE_NET_MISC.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET");
                    }

                    if (fleF190_COMP_CODES.GetStringValue("COMP_TYPE") == "I" && fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE") == "O" && fleF116_GROUP.Exists() && fleF116_GROUP.GetStringValue("TITHE_IN_EX_CLUDE_FLAG") == "I")
                    {
                        TOT_TITHE_NET_OTHER.Value = TOT_TITHE_NET_OTHER.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET");
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

                    if (fleF110_COMPENSATION.GetStringValue("COMP_TYPE") == "E" && (fleF110_COMPENSATION.GetStringValue("COMP_CODE") == "REVHBK" || fleF110_COMPENSATION.GetStringValue("COMP_CODE") == "REVCLA"))
                    {
                        TOT_REVHBK.Value = TOT_REVHBK.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET");
                    }

                    if (fleF110_COMPENSATION.GetStringValue("COMP_TYPE") == "M")
                    {
                        AMT_MANPAY.Value = AMT_MANPAY.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET");
                    }

                    FINAL_ALL_EXPENSES.Value = TOT_DEPT_EXPENSE_REG.Value + TOT_DEPT_EXPENSE_MISC.Value + TOT_RMA_EXPENSE_ONLY_REG.Value + TOT_RMA_EXPENSE_ONLY_MISC.Value + TOT_GST_ONLY.Value + TOT_HOLDBACK_ONLY.Value + TOT_REVHBK.Value + fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CEICEX");
                    AMT_INCOME_MINUS_EXPENSES_G.Value = TOT_INCOME_GROSS.Value - FINAL_ALL_EXPENSES.Value;
                    DOC_YTDEAR_PLUS_AMT_MANPAY.Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDEAR") + AMT_MANPAY.Value;

                    SubFile(ref m_trnTRANS_UPDATE, ref fleDEBUGU115A_1_AT_COMP_CODE, SubFileType.Keep, fleF110_COMPENSATION, "DOC_NBR", "COMP_CODE", "AMT_GROSS", "AMT_NET", fleF190_COMP_CODES, "COMP_TYPE", "COMP_SUB_TYPE", fleCONSTANTS_MSTR_REC_6, "CURRENT_EP_NBR", fleF020_DOCTOR_MSTR, "DOC_DEPT_EXPENSE_PERCENT_REG",
                            "DOC_DEPT_EXPENSE_PERCENT_MISC", "DOC_IND_PAYS_GST", "DOC_RMA_EXPENSE_PERCENT_MISC", "DOC_RMA_EXPENSE_PERCENT_REG", fleF110_COMPENSATION, "EP_NBR", X_INCOME_GROSS_MINUS_NET, X_AMT_DEPT_EXPENSE_POT_G, X_AMT_DEPT_EXPENSE_G, GST_PERCENT, X_AMT_GST_POT_G, X_AMT_GST_ONLY,
                            X_AMT_RMA_EXPENSE_ONLY, X_AMT_RMA_EXPENSE_POT_G, X_AMT_RMA_EXPENSE_PLUS_GST_G, X_AMT_HOLDBACK_G, X_AMT_HOLDBACK_FINAL, X_AMT_RMA_EXPENSE_FINAL, X_AMT_RMA_EXPENSE_PLUSGST_FINAL, TOT_INCOME_GROSS_REG, TOT_INCOME_GROSS_MISC, TOT_INCOME_GROSS_OTHER, TOT_INCOME_NET_REG, TOT_INCOME_NET_MISC,
                            TOT_INCOME_NET_OTHER, TOT_DEPT_EXPENSE_REG, TOT_DEPT_EXPENSE_MISC, TOT_RMA_EXPENSE_PLUS_GST_REG, TOT_RMA_EXPENSE_PLUS_GST_MISC, TOT_RMA_EXPENSE_ONLY_REG, TOT_RMA_EXPENSE_ONLY_MISC, TOT_GST_ONLY_REG, TOT_GST_ONLY_MISC, TOT_HOLDBACK_ONLY_REG, TOT_HOLDBACK_ONLY_MISC, TOT_REVHBK, AMT_MANPAY,
                            FINAL_ALL_EXPENSES, AMT_INCOME_MINUS_EXPENSES_G, DOC_YTDEAR_PLUS_AMT_MANPAY, fleF020_DOCTOR_MSTR, "DOC_YTDEAR");

                    SubFile(ref m_trnTRANS_UPDATE, ref fleDEBUGU115A_1_AT_DOC_NBR, fleF110_COMPENSATION.At("DOC_NBR"), SubFileType.Keep, fleF110_COMPENSATION, "DOC_NBR", TOT_INCOME_GROSS_REG, TOT_INCOME_GROSS_MISC, TOT_INCOME_GROSS_OTHER, TOT_INCOME_NET_REG, TOT_INCOME_NET_MISC,
                            TOT_INCOME_NET_OTHER, TOT_DEPT_EXPENSE_REG, TOT_DEPT_EXPENSE_MISC, TOT_RMA_EXPENSE_PLUS_GST_REG, TOT_RMA_EXPENSE_PLUS_GST_MISC, TOT_RMA_EXPENSE_ONLY_REG, TOT_RMA_EXPENSE_ONLY_MISC, TOT_GST_ONLY_REG, TOT_GST_ONLY_MISC, TOT_HOLDBACK_ONLY_REG, TOT_HOLDBACK_ONLY_MISC, TOT_REVHBK,
                            AMT_MANPAY, FINAL_ALL_EXPENSES, AMT_INCOME_MINUS_EXPENSES_G, DOC_YTDEAR_PLUS_AMT_MANPAY, fleF020_DOCTOR_MSTR, "DOC_YTDEAR");

                    SubFile(ref m_trnTRANS_UPDATE, ref fleF119_TITHE_DTL, fleF190_COMP_CODES.GetStringValue("COMP_TYPE") == "I" && fleF116_GROUP.GetStringValue("TITHE_IN_EX_CLUDE_FLAG") == "I", SubFileType.Keep, SubFileMode.Append, fleF020_DOCTOR_MSTR, "DOC_OHIP_NBR",
                            fleF110_COMPENSATION, "DOC_NBR", "COMP_CODE", fleF190_COMP_CODES, "REPORTING_SEQ", "COMP_CODE_GROUP", REC_TYPE_D, X_AMT_NET_DTL, X_AMT_GROSS_DTL);



                    SubFile(ref m_trnTRANS_UPDATE, ref fleF119_DOC_SUMM, fleF190_COMP_CODES.GetStringValue("COMP_TYPE") == "I" && fleF116_GROUP.GetStringValue("TITHE_IN_EX_CLUDE_FLAG") == "I", SubFileType.Keep, SubFileMode.Append, fleF020_DOCTOR_MSTR, "DOC_OHIP_NBR",
                            DOC_NBR_SUMM, fleF110_COMPENSATION, "COMP_CODE", fleF190_COMP_CODES, "REPORTING_SEQ", "COMP_CODE_GROUP", REC_TYPE_D, X_AMT_NET, X_AMT_GROSS);

                    
                    SubFile(ref m_trnTRANS_UPDATE, ref fleF110_TITHE_DTL, fleF190_COMP_CODES.GetStringValue("COMP_TYPE") == "I" && fleF116_GROUP.GetStringValue("TITHE_IN_EX_CLUDE_FLAG") == "I", 
                        SubFileType.Keep, fleF020_DOCTOR_MSTR, "DOC_OHIP_NBR",
                            fleF110_COMPENSATION, "DOC_NBR", "COMP_CODE", fleF190_COMP_CODES, "REPORTING_SEQ", "COMP_CODE_GROUP", REC_TYPE_D, X_AMT_NET, X_AMT_GROSS);

                    //SubFile(ref m_trnTRANS_UPDATE, ref fleU115A1_MC, fleF110_COMPENSATION.At("DOC_NBR"), SubFileType.Keep, fleF020_DOCTOR_MSTR, "DOC_OHIP_NBR", fleF110_COMPENSATION, "DOC_NBR", X_COMP_CODE_TOTIT, TOTIT_SEQ_RPT, TOTIT_GROUP, REC_TYPE_D, TOT_TITHE_NET, TOT_TITHE_GROSS,
                    //        TOT_TITHE_NET_REG, TOT_TITHE_NET_MISC, TOT_TITHE_NET_OTHER);

                    SubFile(ref m_trnTRANS_UPDATE, ref fleF119_TOTIT_DOC, fleF110_COMPENSATION.At("DOC_NBR"), TOT_TITHE_NET.Value != 0, SubFileType.Keep, SubFileMode.Append, 
                        fleF020_DOCTOR_MSTR, "DOC_OHIP_NBR", fleF110_COMPENSATION, "DOC_NBR", X_COMP_CODE_TOTIT, TOTIT_SEQ_RPT, TOTIT_GROUP,
                            REC_TYPE_D, TOT_TITHE_NET, TOT_TITHE_GROSS);


                    SubFile(ref m_trnTRANS_UPDATE, ref fleF119_TOTIT_SUMM, fleF110_COMPENSATION.At("DOC_NBR"), TOT_TITHE_NET.Value != 0, SubFileType.Keep, SubFileMode.Append, 
                        fleF020_DOCTOR_MSTR, "DOC_OHIP_NBR", DOC_NBR_SUMM, X_COMP_CODE_TOTIT, TOTIT_SEQ_RPT, TOTIT_GROUP,
                            REC_TYPE_D, TOT_TITHE_NET, TOT_TITHE_GROSS);

                    Reset(ref TOT_INCOME_GROSS_REG, fleF110_COMPENSATION.At("DOC_NBR"));
                    Reset(ref TOT_INCOME_GROSS_MISC, fleF110_COMPENSATION.At("DOC_NBR"));
                    Reset(ref TOT_INCOME_GROSS_OTHER, fleF110_COMPENSATION.At("DOC_NBR"));
                    Reset(ref TOT_INCOME_NET_REG, fleF110_COMPENSATION.At("DOC_NBR"));
                    Reset(ref TOT_INCOME_NET_MISC, fleF110_COMPENSATION.At("DOC_NBR"));
                    Reset(ref TOT_INCOME_NET_OTHER, fleF110_COMPENSATION.At("DOC_NBR"));
                    Reset(ref TOT_TITHE_GROSS_REG, fleF110_COMPENSATION.At("DOC_NBR"));
                    Reset(ref TOT_TITHE_GROSS_MISC, fleF110_COMPENSATION.At("DOC_NBR"));
                    Reset(ref TOT_TITHE_GROSS_OTHER, fleF110_COMPENSATION.At("DOC_NBR"));
                    Reset(ref TOT_TITHE_NET_REG, fleF110_COMPENSATION.At("DOC_NBR"));
                    Reset(ref TOT_TITHE_NET_MISC, fleF110_COMPENSATION.At("DOC_NBR"));
                    Reset(ref TOT_TITHE_NET_OTHER, fleF110_COMPENSATION.At("DOC_NBR"));
                    Reset(ref TOT_DEPT_EXPENSE_REG, fleF110_COMPENSATION.At("DOC_NBR"));
                    Reset(ref TOT_DEPT_EXPENSE_MISC, fleF110_COMPENSATION.At("DOC_NBR"));
                    Reset(ref TOT_RMA_EXPENSE_PLUS_GST_REG, fleF110_COMPENSATION.At("DOC_NBR"));
                    Reset(ref TOT_RMA_EXPENSE_PLUS_GST_MISC, fleF110_COMPENSATION.At("DOC_NBR"));
                    Reset(ref TOT_RMA_EXPENSE_ONLY_REG, fleF110_COMPENSATION.At("DOC_NBR"));
                    Reset(ref TOT_RMA_EXPENSE_ONLY_MISC, fleF110_COMPENSATION.At("DOC_NBR"));
                    Reset(ref TOT_GST_ONLY_REG, fleF110_COMPENSATION.At("DOC_NBR"));
                    Reset(ref TOT_GST_ONLY_MISC, fleF110_COMPENSATION.At("DOC_NBR"));
                    Reset(ref TOT_HOLDBACK_ONLY_REG, fleF110_COMPENSATION.At("DOC_NBR"));
                    Reset(ref TOT_HOLDBACK_ONLY_MISC, fleF110_COMPENSATION.At("DOC_NBR"));
                    Reset(ref TOT_REVHBK, fleF110_COMPENSATION.At("DOC_NBR"));
                    Reset(ref AMT_MANPAY, fleF110_COMPENSATION.At("DOC_NBR"));
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
                EndRequest("U115A_1_U115_RUN_0_11");
            }
        }

        #endregion
    }

    public class U115A_1_U115_SUMMARIZE_F119_TITHE_12 : U115A_0
    {
        public U115A_1_U115_SUMMARIZE_F119_TITHE_12(string Name, int Level)
            : base(Name, Level, true)
        {
            this.ScreenType = ScreenTypes.QTP;
            fleF119_TITHE_DTL = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F119_TITHE_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
            fleF119_TITHE_ONE_COMP_CODE_PER_DOC_NBR = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F119_TITHE_ONE_COMP_CODE_PER_DOC_NBR", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

            X_AMT_NET = new CoreInteger("X_AMT_NET", 10, this);
            X_AMT_GROSS = new CoreInteger("X_AMT_GROSS", 10, this);
        }

        #region "Declarations (Variables, Files and Transactions)(U115A_1_U115_SUMMARIZE_F119_TITHE_12)"

        private SqlFileObject fleF119_TITHE_DTL;
        private SqlFileObject fleF119_TITHE_ONE_COMP_CODE_PER_DOC_NBR;

        private CoreInteger X_AMT_NET;
        private CoreInteger X_AMT_GROSS;

        #endregion

        #region "Standard Generated Procedures(U115A_1_U115_SUMMARIZE_F119_TITHE_12)"

        #region "Transaction Management Procedures(U115A_1_U115_SUMMARIZE_F119_TITHE_12)"

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
            fleF119_TITHE_DTL.Transaction = m_trnTRANS_UPDATE;
            fleF119_TITHE_ONE_COMP_CODE_PER_DOC_NBR.Transaction = m_trnTRANS_UPDATE;
        }

        #endregion

        #region "FILE Management Procedures(U115A_1_U115_SUMMARIZE_F119_TITHE_12)"

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
                fleF119_TITHE_DTL.Dispose();
                fleF119_TITHE_ONE_COMP_CODE_PER_DOC_NBR.Dispose();
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

        #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U115A_1_U115_SUMMARIZE_F119_TITHE_12)"

        public void Run()
        {
            try
            {
                Request("U115A_1_U115_SUMMARIZE_F119_TITHE_12");

                while (fleF119_TITHE_DTL.QTPForMissing())
                {
                    // --> GET fleF119_TITHE_DTL <--
                    fleF119_TITHE_DTL.GetData();
                    // --> End GET fleF119_TITHE_DTL <--

                    if (Transaction())
                    {
                        Sort(fleF119_TITHE_DTL.GetSortValue("DOC_OHIP_NBR"), fleF119_TITHE_DTL.GetSortValue("DOC_NBR"), fleF119_TITHE_DTL.GetSortValue("COMP_CODE"));
                    }
                }

                while (Sort(fleF119_TITHE_DTL))
                {
                    X_AMT_NET.Value = X_AMT_NET.Value + fleF119_TITHE_DTL.GetDecimalValue("X_AMT_NET_DTL");
                    X_AMT_GROSS.Value = X_AMT_GROSS.Value + fleF119_TITHE_DTL.GetDecimalValue("X_AMT_GROSS_DTL");

                    SubFile(ref m_trnTRANS_UPDATE, ref fleF119_TITHE_ONE_COMP_CODE_PER_DOC_NBR, fleF119_TITHE_DTL.At("DOC_OHIP_NBR") || fleF119_TITHE_DTL.At("DOC_NBR") || fleF119_TITHE_DTL.At("COMP_CODE"), SubFileType.Keep, fleF119_TITHE_DTL, "DOC_OHIP_NBR",
                           "DOC_NBR", "COMP_CODE", "REPORTING_SEQ", "COMP_CODE_GROUP", "REC_TYPE_D", X_AMT_NET, X_AMT_GROSS);

                    Reset(ref X_AMT_NET, fleF119_TITHE_DTL.At("DOC_OHIP_NBR") || fleF119_TITHE_DTL.At("DOC_NBR") || fleF119_TITHE_DTL.At("COMP_CODE"));
                    Reset(ref X_AMT_GROSS, fleF119_TITHE_DTL.At("DOC_NBR") | fleF119_TITHE_DTL.At("DOC_NBR") || fleF119_TITHE_DTL.At("COMP_CODE"));
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
                EndRequest("U115A_1_U115_SUMMARIZE_F119_TITHE_12");
            }
        }

        #endregion
    }

    public class U115A_1_U115_ADD_UPDATE_F119_TITHE_COMP_CODE_13 : U115A_0
    {
        public U115A_1_U115_ADD_UPDATE_F119_TITHE_COMP_CODE_13(string Name, int Level)
            : base(Name, Level, true)
        {
            this.ScreenType = ScreenTypes.QTP;
            fleF119_DOCTOR_YTD = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F119_DOCTOR_YTD", "", false, false, false, 0, "m_trnTRANS_UPDATE");

            fleF119_DOCTOR_YTD.InitializeItems += fleF119_DOCTOR_YTD_InitializeItems;
            fleF119_DOCTOR_YTD.SetItemFinals += fleF119_DOCTOR_YTD_SetItemFinals;


            fleF110_TITHE_DTL = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F110_TITHE_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        }

        #region "Declarations (Variables, Files and Transactions)(U115A_1_U115_ADD_UPDATE_F119_TITHE_COMP_CODE_13)"


        private SqlFileObject fleF119_DOCTOR_YTD;

        private SqlFileObject fleF110_TITHE_DTL;

        private void fleF119_DOCTOR_YTD_InitializeItems(bool Fixed)
        {
            try
            {
                if (!Fixed)
                    fleF119_DOCTOR_YTD.set_SetValue("DOC_NBR", true, fleF110_TITHE_DTL.GetStringValue("DOC_NBR"));
                if (!Fixed)
                    fleF119_DOCTOR_YTD.set_SetValue("COMP_CODE", true, fleF110_TITHE_DTL.GetStringValue("COMP_CODE"));
                if (!Fixed)
                    fleF119_DOCTOR_YTD.set_SetValue("REC_TYPE", true, fleF110_TITHE_DTL.GetStringValue("REC_TYPE_D"));
                if (!Fixed)
                    fleF119_DOCTOR_YTD.set_SetValue("DOC_OHIP_NBR", true, fleF110_TITHE_DTL.GetDecimalValue("DOC_OHIP_NBR"));
                if (!Fixed)
                    fleF119_DOCTOR_YTD.set_SetValue("PROCESS_SEQ", true, fleF110_TITHE_DTL.GetDecimalValue("REPORTING_SEQ"));
                if (!Fixed)
                    fleF119_DOCTOR_YTD.set_SetValue("COMP_CODE_GROUP", true, fleF110_TITHE_DTL.GetStringValue("COMP_CODE_GROUP"));
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

        private void fleF119_DOCTOR_YTD_SetItemFinals()
        {
            try
            {
                fleF119_DOCTOR_YTD.set_SetValue("AMT_MTD", fleF110_TITHE_DTL.GetDecimalValue("X_AMT_GROSS"));
                fleF119_DOCTOR_YTD.set_SetValue("AMT_YTD", fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") + fleF110_TITHE_DTL.GetDecimalValue("X_AMT_GROSS"));
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

        #region "Standard Generated Procedures(U115A_1_U115_ADD_UPDATE_F119_TITHE_COMP_CODE_13)"

        #region "Transaction Management Procedures(U115A_1_U115_ADD_UPDATE_F119_TITHE_COMP_CODE_13)"

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
            fleF110_TITHE_DTL.Transaction = m_trnTRANS_UPDATE;
            fleF119_DOCTOR_YTD.Transaction = m_trnTRANS_UPDATE;
        }

        #endregion

        #region "FILE Management Procedures(U115A_1_U115_ADD_UPDATE_F119_TITHE_COMP_CODE_13)"

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
                fleF110_TITHE_DTL.Dispose();
                fleF119_DOCTOR_YTD.Dispose();
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

        #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U115A_1_U115_ADD_UPDATE_F119_TITHE_COMP_CODE_13)"

        public void Run()
        {
            try
            {
                Request("U115A_1_U115_ADD_UPDATE_F119_TITHE_COMP_CODE_13");


                while (fleF110_TITHE_DTL.QTPForMissing())
                {
                    // --> GET fleF119_TITHE_DTL <--
                    fleF110_TITHE_DTL.GetData();
                    // --> End GET fleF119_TITHE_DTL <--

                    if (Transaction())
                    {
                        while (fleF119_DOCTOR_YTD.QTPForMissing())
                        {
                            // --> GET fleF119_DOCTOR_YTD <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleF119_DOCTOR_YTD.ElementOwner("DOC_NBR")).Append(" = ");
                            m_strWhere.Append(Common.StringToField(fleF110_TITHE_DTL.GetStringValue("DOC_NBR")));
                            m_strWhere.Append(" AND ").Append(fleF119_DOCTOR_YTD.ElementOwner("COMP_CODE")).Append(" = ");
                            m_strWhere.Append(Common.StringToField(fleF110_TITHE_DTL.GetStringValue("COMP_CODE")));
                            m_strWhere.Append(" AND ").Append(fleF119_DOCTOR_YTD.ElementOwner("REC_TYPE")).Append(" = ");
                            m_strWhere.Append(Common.StringToField(fleF110_TITHE_DTL.GetStringValue("REC_TYPE_D")));
                            m_strWhere.Append(" AND ").Append(fleF119_DOCTOR_YTD.ElementOwner("DOC_OHIP_NBR")).Append(" = ");
                            m_strWhere.Append(fleF110_TITHE_DTL.GetDecimalValue("DOC_OHIP_NBR"));

                            fleF119_DOCTOR_YTD.GetData(m_strWhere.ToString());

                        }
                        // --> End GET fleF119_DOCTOR_YTD <--

                        fleF119_DOCTOR_YTD.OutPut(OutPutType.Add_Update);


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
                EndRequest("U115A_1_U115_ADD_UPDATE_F119_TITHE_COMP_CODE_13");
            }
        }

        #endregion
    }
}

