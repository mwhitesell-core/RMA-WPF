
#region "Screen Comments"

// #> PROGRAM-ID.     u115b.qts
// ((C)) Dyad Technologies
// PURPOSE: sub-process witHIN  EARNINGS GENERATION  PROCESS.
// CALCULATE REQUIRED `TOT`AL / `YTD` TRANSACTIONS AS OF CURRENT EP
// MODIFICATION HISTORY
// DATE    SAF #  WHO      DESCRIPTION
// 92/JAN/01  ____   B.E.     - original
// 92/MAY/01  ____   B.E.     - Added YTDGUC logic
// 92/MAY/11  ____   B.E.     - YTDGUC logic changed from 1C to 1B (YTDGUC)
// 92/AUG/11  ____   B.E.     - MOVED YTD LOGIC INTO 2ND REQUEST
// 92/SEP/14  ----   B.E.     - COMMENT OUT OUTPUT OF YTDGUx TRANSACTION
// SINCE GTYPEx IS NOW CALCULATED AS YTD NOT
// CURRENT EP.  IF GTYPEx CHANGED RE-ACTIVATE
// THE TYDGUx code.
// 92/OCT/26  ----   B.E.     - Updated F020 with YTDINC value
// 92/NOV/10         B.E.     - updated F020 within this run with OUTPUT stmt
// rather than using U115 SUBFILE.
// 93/APR/10         B.E.     - YTDCEA/CEX use values in DOCTOR-MSTR rather
// than calculated ones.
// 93/MAY/06         B.E.     - Added SUBFILE F119
// 93/MAY/11         B.E.     - Added ACCESS of F119-DOCTOR-YTD to preset
// 93/MAY/18         B.E.     - INTEGER*4 for zoned*8, F119/F119 SUBFILE changes
// YTD values
// 93/MAY/27         B.E.     - *F119 exclude records added to F119
// - add/subtract F110  M anual type recs to F020`s YTDEAR (ytd earnings)
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
// 95/OCT/23  M.C.  - INCLUDE TOT-REVHBK IN DOC-YTDINC
// SINCE TOT-REVHBK IS A NEGATIVE VALUE
// SUBTRACT TOT-REVHBK TO GET THE POSITIVE
// VALUE
// 95/NOV/07  M.C.  - PDR 634 - INCLUDE NEW CONDITION TO
// TOT-REVHBK DEFINITION
// 95/NOV/22  M.C.  - OPTIMIZE PROGRAM BY DELETING ALL THE
// UNUSED TEMP & DEFINE ITEMS
// 96/APR/19  M.C.  - INCLUDE `REVCLA` IN TOT-REVHBK
// 1999/Feb/18         S.B.     - Checked for Y2K.
// 1999/Jun/07  S.B.  - Altered the call to gst.use to be 
// called from $use instead of src.
// 00/nov/23.B.E.        - HOLDBK calculation has some rounding problems whereby
// hold backs in the amount of a few cents occur. The
// original logic ignored values less than 10 cents.
// Changed to ignore anything less than $1.00
// 01/feb/21 B.E. - for PAYCOD 6 ONLY - add TOTEXP into doctor`s f020 field
// doc-yrly-expense-computed to keep ytd expenses totaled
// 01/feb/22 B.E. - added rounding of ICU GST calculation
// 03/jan/21 B.E. - added file debugu115b_at_doc_nbr for debugging purposes
// 04/mar/01 b.e.        - added `O`ther `I`ncome processing in addition to
// current logic that handles `R`egular and `M`isc
// types of Income.
// 04/mar/25 b.e.       - changed sequence of factor divide by 100000 to try
// to avoid rounding errors (approx 5cents on 10,500)
// 06/mar/20 b.e.        - generate of HOLDBK transaction eliminated in 
// u115_common.qts used by this program
// 2006/may/10 b.e.      - $1M payroll changes to size of calculated fields
// 2008/oct/01 brad1     - added new tot-dept-expense-other calulation to handle TITHE /DEPMEM (as per u115a)
// 2008/oct/22 M.C.     - add set lock record update
// 2008/oct/23 M.C.     - change to use $src/u115b_debug.qts at the end for debug purpose
// - change final-all-expenses from temp to define item
// 2008/oct/24 brad4     - use net not gross in calculation for INCEXP
// 2008/oct/24 brad5     - reduce ytdear by this months incexp amount for paycode 2 doctors
// ie. reduce (ie add) doc-ytdear-plus-amt-manpay by final-all-expenses-plus-dept-expense-ather
// 2008/oct/25 brad6     - brad5 change above applied only to paycode 2 doctors - link to f112 added to access stmnt
// 2008/oct/25 brad7     - brad5 change to reduce ONLY by TITHE expenses - ie the `other` - the final-all-expenses taken
// care in by noting the difference between gross/net and using that amount as expenses
// 2008/oct/25 brad8 - undo brad4
// 2008/oct/25 brad9     - THIS COMMENT LIKELY WRONG - paypot is low by amount of non-tithe expenses and so non-tithe expenses
// not added into ytdear i.e. only add titheable expenses into ytdear
// ABOVE COMMENT LIKELY WRONG .. brad9 ignored ytdear and correctly adjusted INCEXP (income - expenses)
// calculation (variable amt-income-minus-expenses-g) by all expenses (titheable and non-titheable) and
// thus affected the eventual ytdinc - ytdear pay calculation but making
// it an (ytd-income(ytd-expenses) - ytd-earnings calcuations.
// 2008/oct/25 brad10 - correct update of doc-ytdear in f020 to use variable (doc-ytdear-plus-amt-manpay) not calculation
// 2008/oct/25 brad11 - update of f110 changed to use summary variable instead of indivudual variables
// 2008/oct/26 brad12    - don`t touch ytdear with expenses - it affects ytdinc (but may not include titheable expenses)
// 2008/oct/26 brad13    - include titheable expenses in ytdinc - adjust both net and gross amounts
// 2008/oct/27 brad14    - modify above brad13 change to just adjust the  net amount
// 2008/nov/06 moira1 - add new defined items  `x-doc-ytdinc-g/n` for updating YTDINC in f110 & f020 
// 2008/nov/18 brad15  - access f119  A  record to get previous YTD amount for TOTEXP
// 2008/nov/19 brad16  - include all expenses in ytdinc - not just titheable - slight change to brad13/brad14
// 2008/nov/19 brad17  - alternative method of calculating ytdinc using previous ytdinc from f119
// 2008/nov/19 brad18  - line that updated f020 with new ytdear got lost in editting - added back
// 2010/mar/02 moira2 - change the sequence when updating doc-YTDINC-g/n in f020


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U115B : BaseClassControl
{

    private U115B m_U115B;

    public U115B(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
        YTDCEA_SEQ = new CoreDecimal("YTDCEA_SEQ", 2, this, ResetTypes.ResetAtStartup);
        YTDCEA_TYPE = new CoreCharacter("YTDCEA_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        YTDCEX_SEQ = new CoreDecimal("YTDCEX_SEQ", 2, this, ResetTypes.ResetAtStartup);
        YTDCEX_TYPE = new CoreCharacter("YTDCEX_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        YTDEAR_SEQ = new CoreDecimal("YTDEAR_SEQ", 2, this, ResetTypes.ResetAtStartup);
        YTDEAR_TYPE = new CoreCharacter("YTDEAR_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        RMAEXR_SEQ = new CoreDecimal("RMAEXR_SEQ", 2, this, ResetTypes.ResetAtStartup);
        RMAEXR_TYPE = new CoreCharacter("RMAEXR_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        RMAEXM_SEQ = new CoreDecimal("RMAEXM_SEQ", 2, this, ResetTypes.ResetAtStartup);
        RMAEXM_TYPE = new CoreCharacter("RMAEXM_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        INCEXP_SEQ = new CoreDecimal("INCEXP_SEQ", 2, this, ResetTypes.ResetAtStartup);
        INCEXP_TYPE = new CoreCharacter("INCEXP_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        YTDINC_SEQ = new CoreDecimal("YTDINC_SEQ", 2, this, ResetTypes.ResetAtStartup);
        YTDINC_TYPE = new CoreCharacter("YTDINC_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        TOTINC_SEQ = new CoreDecimal("TOTINC_SEQ", 2, this, ResetTypes.ResetAtStartup);
        TOTINC_TYPE = new CoreCharacter("TOTINC_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        TOTEXP_SEQ = new CoreDecimal("TOTEXP_SEQ", 2, this, ResetTypes.ResetAtStartup);
        TOTEXP_TYPE = new CoreCharacter("TOTEXP_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        YTDGUA_SEQ = new CoreDecimal("YTDGUA_SEQ", 2, this, ResetTypes.ResetAtStartup);
        YTDGUA_TYPE = new CoreCharacter("YTDGUA_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        YTDGUB_SEQ = new CoreDecimal("YTDGUB_SEQ", 2, this, ResetTypes.ResetAtStartup);
        YTDGUB_TYPE = new CoreCharacter("YTDGUB_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        YTDGUC_SEQ = new CoreDecimal("YTDGUC_SEQ", 2, this, ResetTypes.ResetAtStartup);
        YTDGUC_TYPE = new CoreCharacter("YTDGUC_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DEPEXR_SEQ = new CoreDecimal("DEPEXR_SEQ", 2, this, ResetTypes.ResetAtStartup);
        DEPEXR_TYPE = new CoreCharacter("DEPEXR_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DEPEXM_SEQ = new CoreDecimal("DEPEXM_SEQ", 2, this, ResetTypes.ResetAtStartup);
        DEPEXM_TYPE = new CoreCharacter("DEPEXM_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        GST_SEQ = new CoreDecimal("GST_SEQ", 2, this, ResetTypes.ResetAtStartup);
        GST_TYPE = new CoreCharacter("GST_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        HOLDBACK_SEQ = new CoreDecimal("HOLDBACK_SEQ", 2, this, ResetTypes.ResetAtStartup);
        HOLDBACK_TYPE = new CoreCharacter("HOLDBACK_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);


    }

    public U115B(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
        YTDCEA_SEQ = new CoreDecimal("YTDCEA_SEQ", 2, this, ResetTypes.ResetAtStartup);
        YTDCEA_TYPE = new CoreCharacter("YTDCEA_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        YTDCEX_SEQ = new CoreDecimal("YTDCEX_SEQ", 2, this, ResetTypes.ResetAtStartup);
        YTDCEX_TYPE = new CoreCharacter("YTDCEX_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        YTDEAR_SEQ = new CoreDecimal("YTDEAR_SEQ", 2, this, ResetTypes.ResetAtStartup);
        YTDEAR_TYPE = new CoreCharacter("YTDEAR_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        RMAEXR_SEQ = new CoreDecimal("RMAEXR_SEQ", 2, this, ResetTypes.ResetAtStartup);
        RMAEXR_TYPE = new CoreCharacter("RMAEXR_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        RMAEXM_SEQ = new CoreDecimal("RMAEXM_SEQ", 2, this, ResetTypes.ResetAtStartup);
        RMAEXM_TYPE = new CoreCharacter("RMAEXM_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        INCEXP_SEQ = new CoreDecimal("INCEXP_SEQ", 2, this, ResetTypes.ResetAtStartup);
        INCEXP_TYPE = new CoreCharacter("INCEXP_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        YTDINC_SEQ = new CoreDecimal("YTDINC_SEQ", 2, this, ResetTypes.ResetAtStartup);
        YTDINC_TYPE = new CoreCharacter("YTDINC_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        TOTINC_SEQ = new CoreDecimal("TOTINC_SEQ", 2, this, ResetTypes.ResetAtStartup);
        TOTINC_TYPE = new CoreCharacter("TOTINC_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        TOTEXP_SEQ = new CoreDecimal("TOTEXP_SEQ", 2, this, ResetTypes.ResetAtStartup);
        TOTEXP_TYPE = new CoreCharacter("TOTEXP_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        YTDGUA_SEQ = new CoreDecimal("YTDGUA_SEQ", 2, this, ResetTypes.ResetAtStartup);
        YTDGUA_TYPE = new CoreCharacter("YTDGUA_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        YTDGUB_SEQ = new CoreDecimal("YTDGUB_SEQ", 2, this, ResetTypes.ResetAtStartup);
        YTDGUB_TYPE = new CoreCharacter("YTDGUB_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        YTDGUC_SEQ = new CoreDecimal("YTDGUC_SEQ", 2, this, ResetTypes.ResetAtStartup);
        YTDGUC_TYPE = new CoreCharacter("YTDGUC_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DEPEXR_SEQ = new CoreDecimal("DEPEXR_SEQ", 2, this, ResetTypes.ResetAtStartup);
        DEPEXR_TYPE = new CoreCharacter("DEPEXR_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DEPEXM_SEQ = new CoreDecimal("DEPEXM_SEQ", 2, this, ResetTypes.ResetAtStartup);
        DEPEXM_TYPE = new CoreCharacter("DEPEXM_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        GST_SEQ = new CoreDecimal("GST_SEQ", 2, this, ResetTypes.ResetAtStartup);
        GST_TYPE = new CoreCharacter("GST_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        HOLDBACK_SEQ = new CoreDecimal("HOLDBACK_SEQ", 2, this, ResetTypes.ResetAtStartup);
        HOLDBACK_TYPE = new CoreCharacter("HOLDBACK_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);


    }

    public override void Dispose()
    {
        if ((m_U115B != null))
        {
            m_U115B.CloseTransactionObjects();
            m_U115B = null;
        }
    }

    public U115B GetU115B(int Level)
    {
        if (m_U115B == null)
        {
            m_U115B = new U115B("U115B", Level);
        }
        else
        {
            m_U115B.ResetValues();
        }
        return m_U115B;
    }



    #region "Renaissance Architect Migration Services Default Regions"

    #region "Declarations (Variables, Files and Transactions)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.
    protected CoreDecimal YTDCEA_SEQ;
    protected CoreCharacter YTDCEA_TYPE;
    protected CoreDecimal YTDCEX_SEQ;
    protected CoreCharacter YTDCEX_TYPE;
    protected CoreDecimal YTDEAR_SEQ;
    protected CoreCharacter YTDEAR_TYPE;
    protected CoreDecimal RMAEXR_SEQ;
    protected CoreCharacter RMAEXR_TYPE;
    protected CoreDecimal RMAEXM_SEQ;
    protected CoreCharacter RMAEXM_TYPE;
    protected CoreDecimal INCEXP_SEQ;
    protected CoreCharacter INCEXP_TYPE;
    protected CoreDecimal YTDINC_SEQ;
    protected CoreCharacter YTDINC_TYPE;
    protected CoreDecimal TOTINC_SEQ;
    protected CoreCharacter TOTINC_TYPE;
    protected CoreDecimal TOTEXP_SEQ;
    protected CoreCharacter TOTEXP_TYPE;
    protected CoreDecimal YTDGUA_SEQ;
    protected CoreCharacter YTDGUA_TYPE;
    protected CoreDecimal YTDGUB_SEQ;
    protected CoreCharacter YTDGUB_TYPE;
    protected CoreDecimal YTDGUC_SEQ;
    protected CoreCharacter YTDGUC_TYPE;
    protected CoreDecimal DEPEXR_SEQ;
    protected CoreCharacter DEPEXR_TYPE;
    protected CoreDecimal DEPEXM_SEQ;
    protected CoreCharacter DEPEXM_TYPE;
    protected CoreDecimal GST_SEQ;
    protected CoreCharacter GST_TYPE;
    protected CoreDecimal HOLDBACK_SEQ;

    protected CoreCharacter HOLDBACK_TYPE;

    protected SqlConnection m_cnnQUERY = new SqlConnection();
    protected SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();

    protected SqlTransaction m_trnTRANS_UPDATE;


    #endregion


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"

    public override bool RunQTP()
    {


        try
        {

            U115B_U115_A_GET_YTDCEA_1 U115_A_GET_YTDCEA_1 = new U115B_U115_A_GET_YTDCEA_1(Name, Level);
            U115_A_GET_YTDCEA_1.Run();
            U115_A_GET_YTDCEA_1.Dispose();
            U115_A_GET_YTDCEA_1 = null;

            U115B_U115_A_GET_YTDCEX_2 U115_A_GET_YTDCEX_2 = new U115B_U115_A_GET_YTDCEX_2(Name, Level);
            U115_A_GET_YTDCEX_2.Run();
            U115_A_GET_YTDCEX_2.Dispose();
            U115_A_GET_YTDCEX_2 = null;

            U115B_U115_A_GET_YTDEAR_3 U115_A_GET_YTDEAR_3 = new U115B_U115_A_GET_YTDEAR_3(Name, Level);
            U115_A_GET_YTDEAR_3.Run();
            U115_A_GET_YTDEAR_3.Dispose();
            U115_A_GET_YTDEAR_3 = null;

            U115B_U115_A_GET_RMAEXR_4 U115_A_GET_RMAEXR_4 = new U115B_U115_A_GET_RMAEXR_4(Name, Level);
            U115_A_GET_RMAEXR_4.Run();
            U115_A_GET_RMAEXR_4.Dispose();
            U115_A_GET_RMAEXR_4 = null;

            U115B_U115_A_GET_RMAEXM_5 U115_A_GET_RMAEXM_5 = new U115B_U115_A_GET_RMAEXM_5(Name, Level);
            U115_A_GET_RMAEXM_5.Run();
            U115_A_GET_RMAEXM_5.Dispose();
            U115_A_GET_RMAEXM_5 = null;

            U115B_U115_A_GET_YTDINC_6 U115_A_GET_YTDINC_6 = new U115B_U115_A_GET_YTDINC_6(Name, Level);
            U115_A_GET_YTDINC_6.Run();
            U115_A_GET_YTDINC_6.Dispose();
            U115_A_GET_YTDINC_6 = null;

            U115B_U115_A_GET_INCEXP_7 U115_A_GET_INCEXP_7 = new U115B_U115_A_GET_INCEXP_7(Name, Level);
            U115_A_GET_INCEXP_7.Run();
            U115_A_GET_INCEXP_7.Dispose();
            U115_A_GET_INCEXP_7 = null;

            U115B_U115_A_GET_TOTINC_8 U115_A_GET_TOTINC_8 = new U115B_U115_A_GET_TOTINC_8(Name, Level);
            U115_A_GET_TOTINC_8.Run();
            U115_A_GET_TOTINC_8.Dispose();
            U115_A_GET_TOTINC_8 = null;

            U115B_U115_A_GET_TOTEXP_9 U115_A_GET_TOTEXP_9 = new U115B_U115_A_GET_TOTEXP_9(Name, Level);
            U115_A_GET_TOTEXP_9.Run();
            U115_A_GET_TOTEXP_9.Dispose();
            U115_A_GET_TOTEXP_9 = null;

            U115B_U115_A_GET_YTDGUA_10 U115_A_GET_YTDGUA_10 = new U115B_U115_A_GET_YTDGUA_10(Name, Level);
            U115_A_GET_YTDGUA_10.Run();
            U115_A_GET_YTDGUA_10.Dispose();
            U115_A_GET_YTDGUA_10 = null;

            U115B_U115_A_GET_YTDGUB_11 U115_A_GET_YTDGUB_11 = new U115B_U115_A_GET_YTDGUB_11(Name, Level);
            U115_A_GET_YTDGUB_11.Run();
            U115_A_GET_YTDGUB_11.Dispose();
            U115_A_GET_YTDGUB_11 = null;

            U115B_U115_A_GET_YTDGUC_12 U115_A_GET_YTDGUC_12 = new U115B_U115_A_GET_YTDGUC_12(Name, Level);
            U115_A_GET_YTDGUC_12.Run();
            U115_A_GET_YTDGUC_12.Dispose();
            U115_A_GET_YTDGUC_12 = null;

            U115B_U115_A_GET_DEPEXR_13 U115_A_GET_DEPEXR_13 = new U115B_U115_A_GET_DEPEXR_13(Name, Level);
            U115_A_GET_DEPEXR_13.Run();
            U115_A_GET_DEPEXR_13.Dispose();
            U115_A_GET_DEPEXR_13 = null;

            U115B_U115_A_GET_DEPEXM_14 U115_A_GET_DEPEXM_14 = new U115B_U115_A_GET_DEPEXM_14(Name, Level);
            U115_A_GET_DEPEXM_14.Run();
            U115_A_GET_DEPEXM_14.Dispose();
            U115_A_GET_DEPEXM_14 = null;

            U115B_U115_A_GET_GST_15 U115_A_GET_GST_15 = new U115B_U115_A_GET_GST_15(Name, Level);
            U115_A_GET_GST_15.Run();
            U115_A_GET_GST_15.Dispose();
            U115_A_GET_GST_15 = null;

            U115B_U115_A_GET_HOLDBACK_16 U115_A_GET_HOLDBACK_16 = new U115B_U115_A_GET_HOLDBACK_16(Name, Level);
            U115_A_GET_HOLDBACK_16.Run();
            U115_A_GET_HOLDBACK_16.Dispose();
            U115_A_GET_HOLDBACK_16 = null;

            U115B_U115_RUN_1_17 U115_RUN_1_17 = new U115B_U115_RUN_1_17(Name, Level);
            U115_RUN_1_17.Run();
            U115_RUN_1_17.Dispose();
            U115_RUN_1_17 = null;

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

}



public class U115B_U115_A_GET_YTDCEA_1 : U115B
{

    public U115B_U115_A_GET_YTDCEA_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U115B_U115_A_GET_YTDCEA_1)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("YTDCEA"));


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


    #region "Standard Generated Procedures(U115B_U115_A_GET_YTDCEA_1)"


    #region "Automatic Item Initialization(U115B_U115_A_GET_YTDCEA_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U115B_U115_A_GET_YTDCEA_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:20:03 PM

    //#-----------------------------------------
    //# InitializeTransactionObjects Procedure.
    //#-----------------------------------------

    protected override void InitializeTransactionObjects()
    {

        try
        {
            m_cnnTRANS_UPDATE = new SqlConnection(Common.GetSqlConnectionString());
            m_cnnTRANS_UPDATE.Open();
            m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
            m_cnnQUERY = new SqlConnection(Common.GetSqlConnectionString());


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


    #region "FILE Management Procedures(U115B_U115_A_GET_YTDCEA_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:20:03 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U115B_U115_A_GET_YTDCEA_1)"


    public void Run()
    {

        try
        {
            Request("U115_A_GET_YTDCEA_1");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

                if (Transaction())
                {
                    YTDCEA_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    YTDCEA_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");

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
            EndRequest("U115_A_GET_YTDCEA_1");

        }

    }







    #endregion


}
//U115_A_GET_YTDCEA_1



public class U115B_U115_A_GET_YTDCEX_2 : U115B
{

    public U115B_U115_A_GET_YTDCEX_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U115B_U115_A_GET_YTDCEX_2)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("YTDCEX"));


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


    #region "Standard Generated Procedures(U115B_U115_A_GET_YTDCEX_2)"


    #region "Automatic Item Initialization(U115B_U115_A_GET_YTDCEX_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U115B_U115_A_GET_YTDCEX_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:20:04 PM

    //#-----------------------------------------
    //# InitializeTransactionObjects Procedure.
    //#-----------------------------------------

    protected override void InitializeTransactionObjects()
    {

        try
        {
            m_cnnTRANS_UPDATE = new SqlConnection(Common.GetSqlConnectionString());
            m_cnnTRANS_UPDATE.Open();
            m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
            m_cnnQUERY = new SqlConnection(Common.GetSqlConnectionString());


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


    #region "FILE Management Procedures(U115B_U115_A_GET_YTDCEX_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:20:04 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U115B_U115_A_GET_YTDCEX_2)"


    public void Run()
    {

        try
        {
            Request("U115_A_GET_YTDCEX_2");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

                if (Transaction())
                {
                    YTDCEX_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    YTDCEX_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");

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
            EndRequest("U115_A_GET_YTDCEX_2");

        }

    }







    #endregion


}
//U115_A_GET_YTDCEX_2



public class U115B_U115_A_GET_YTDEAR_3 : U115B
{

    public U115B_U115_A_GET_YTDEAR_3(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U115B_U115_A_GET_YTDEAR_3)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("YTDEAR"));


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


    #region "Standard Generated Procedures(U115B_U115_A_GET_YTDEAR_3)"


    #region "Automatic Item Initialization(U115B_U115_A_GET_YTDEAR_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U115B_U115_A_GET_YTDEAR_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:20:04 PM

    //#-----------------------------------------
    //# InitializeTransactionObjects Procedure.
    //#-----------------------------------------

    protected override void InitializeTransactionObjects()
    {

        try
        {
            m_cnnTRANS_UPDATE = new SqlConnection(Common.GetSqlConnectionString());
            m_cnnTRANS_UPDATE.Open();
            m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
            m_cnnQUERY = new SqlConnection(Common.GetSqlConnectionString());


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


    #region "FILE Management Procedures(U115B_U115_A_GET_YTDEAR_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:20:04 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U115B_U115_A_GET_YTDEAR_3)"


    public void Run()
    {

        try
        {
            Request("U115_A_GET_YTDEAR_3");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

                if (Transaction())
                {
                    YTDEAR_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    YTDEAR_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");

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
            EndRequest("U115_A_GET_YTDEAR_3");

        }

    }







    #endregion


}
//U115_A_GET_YTDEAR_3



public class U115B_U115_A_GET_RMAEXR_4 : U115B
{

    public U115B_U115_A_GET_RMAEXR_4(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U115B_U115_A_GET_RMAEXR_4)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("RMAEXR"));


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


    #region "Standard Generated Procedures(U115B_U115_A_GET_RMAEXR_4)"


    #region "Automatic Item Initialization(U115B_U115_A_GET_RMAEXR_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U115B_U115_A_GET_RMAEXR_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:20:04 PM

    //#-----------------------------------------
    //# InitializeTransactionObjects Procedure.
    //#-----------------------------------------

    protected override void InitializeTransactionObjects()
    {

        try
        {
            m_cnnTRANS_UPDATE = new SqlConnection(Common.GetSqlConnectionString());
            m_cnnTRANS_UPDATE.Open();
            m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
            m_cnnQUERY = new SqlConnection(Common.GetSqlConnectionString());


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


    #region "FILE Management Procedures(U115B_U115_A_GET_RMAEXR_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:20:04 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U115B_U115_A_GET_RMAEXR_4)"


    public void Run()
    {

        try
        {
            Request("U115_A_GET_RMAEXR_4");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

                if (Transaction())
                {
                    RMAEXR_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    RMAEXR_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");

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
            EndRequest("U115_A_GET_RMAEXR_4");

        }

    }







    #endregion


}
//U115_A_GET_RMAEXR_4



public class U115B_U115_A_GET_RMAEXM_5 : U115B
{

    public U115B_U115_A_GET_RMAEXM_5(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U115B_U115_A_GET_RMAEXM_5)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("RMAEXM"));


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


    #region "Standard Generated Procedures(U115B_U115_A_GET_RMAEXM_5)"


    #region "Automatic Item Initialization(U115B_U115_A_GET_RMAEXM_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U115B_U115_A_GET_RMAEXM_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:20:04 PM

    //#-----------------------------------------
    //# InitializeTransactionObjects Procedure.
    //#-----------------------------------------

    protected override void InitializeTransactionObjects()
    {

        try
        {
            m_cnnTRANS_UPDATE = new SqlConnection(Common.GetSqlConnectionString());
            m_cnnTRANS_UPDATE.Open();
            m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
            m_cnnQUERY = new SqlConnection(Common.GetSqlConnectionString());


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


    #region "FILE Management Procedures(U115B_U115_A_GET_RMAEXM_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:20:04 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U115B_U115_A_GET_RMAEXM_5)"


    public void Run()
    {

        try
        {
            Request("U115_A_GET_RMAEXM_5");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

                if (Transaction())
                {
                    RMAEXM_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    RMAEXM_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");

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
            EndRequest("U115_A_GET_RMAEXM_5");

        }

    }







    #endregion


}
//U115_A_GET_RMAEXM_5



public class U115B_U115_A_GET_YTDINC_6 : U115B
{

    public U115B_U115_A_GET_YTDINC_6(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U115B_U115_A_GET_YTDINC_6)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("YTDINC"));


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


    #region "Standard Generated Procedures(U115B_U115_A_GET_YTDINC_6)"


    #region "Automatic Item Initialization(U115B_U115_A_GET_YTDINC_6)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U115B_U115_A_GET_YTDINC_6)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:20:04 PM

    //#-----------------------------------------
    //# InitializeTransactionObjects Procedure.
    //#-----------------------------------------

    protected override void InitializeTransactionObjects()
    {

        try
        {
            m_cnnTRANS_UPDATE = new SqlConnection(Common.GetSqlConnectionString());
            m_cnnTRANS_UPDATE.Open();
            m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
            m_cnnQUERY = new SqlConnection(Common.GetSqlConnectionString());


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


    #region "FILE Management Procedures(U115B_U115_A_GET_YTDINC_6)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:20:05 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U115B_U115_A_GET_YTDINC_6)"


    public void Run()
    {

        try
        {
            Request("U115_A_GET_YTDINC_6");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

                if (Transaction())
                {
                    YTDINC_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    YTDINC_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");

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
            EndRequest("U115_A_GET_YTDINC_6");

        }

    }







    #endregion


}
//U115_A_GET_YTDINC_6



public class U115B_U115_A_GET_INCEXP_7 : U115B
{

    public U115B_U115_A_GET_INCEXP_7(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U115B_U115_A_GET_INCEXP_7)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("INCEXP"));


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


    #region "Standard Generated Procedures(U115B_U115_A_GET_INCEXP_7)"


    #region "Automatic Item Initialization(U115B_U115_A_GET_INCEXP_7)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U115B_U115_A_GET_INCEXP_7)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:20:05 PM

    //#-----------------------------------------
    //# InitializeTransactionObjects Procedure.
    //#-----------------------------------------

    protected override void InitializeTransactionObjects()
    {

        try
        {
            m_cnnTRANS_UPDATE = new SqlConnection(Common.GetSqlConnectionString());
            m_cnnTRANS_UPDATE.Open();
            m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
            m_cnnQUERY = new SqlConnection(Common.GetSqlConnectionString());


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


    #region "FILE Management Procedures(U115B_U115_A_GET_INCEXP_7)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:20:05 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U115B_U115_A_GET_INCEXP_7)"


    public void Run()
    {

        try
        {
            Request("U115_A_GET_INCEXP_7");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

                if (Transaction())
                {
                    INCEXP_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    INCEXP_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");

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
            EndRequest("U115_A_GET_INCEXP_7");

        }

    }







    #endregion


}
//U115_A_GET_INCEXP_7



public class U115B_U115_A_GET_TOTINC_8 : U115B
{

    public U115B_U115_A_GET_TOTINC_8(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U115B_U115_A_GET_TOTINC_8)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("TOTINC"));


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


    #region "Standard Generated Procedures(U115B_U115_A_GET_TOTINC_8)"


    #region "Automatic Item Initialization(U115B_U115_A_GET_TOTINC_8)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U115B_U115_A_GET_TOTINC_8)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:20:05 PM

    //#-----------------------------------------
    //# InitializeTransactionObjects Procedure.
    //#-----------------------------------------

    protected override void InitializeTransactionObjects()
    {

        try
        {
            m_cnnTRANS_UPDATE = new SqlConnection(Common.GetSqlConnectionString());
            m_cnnTRANS_UPDATE.Open();
            m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
            m_cnnQUERY = new SqlConnection(Common.GetSqlConnectionString());


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


    #region "FILE Management Procedures(U115B_U115_A_GET_TOTINC_8)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:20:05 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U115B_U115_A_GET_TOTINC_8)"


    public void Run()
    {

        try
        {
            Request("U115_A_GET_TOTINC_8");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

                if (Transaction())
                {
                    TOTINC_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    TOTINC_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");

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
            EndRequest("U115_A_GET_TOTINC_8");

        }

    }







    #endregion


}
//U115_A_GET_TOTINC_8



public class U115B_U115_A_GET_TOTEXP_9 : U115B
{

    public U115B_U115_A_GET_TOTEXP_9(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U115B_U115_A_GET_TOTEXP_9)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("TOTEXP"));


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


    #region "Standard Generated Procedures(U115B_U115_A_GET_TOTEXP_9)"


    #region "Automatic Item Initialization(U115B_U115_A_GET_TOTEXP_9)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U115B_U115_A_GET_TOTEXP_9)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:20:05 PM

    //#-----------------------------------------
    //# InitializeTransactionObjects Procedure.
    //#-----------------------------------------

    protected override void InitializeTransactionObjects()
    {

        try
        {
            m_cnnTRANS_UPDATE = new SqlConnection(Common.GetSqlConnectionString());
            m_cnnTRANS_UPDATE.Open();
            m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
            m_cnnQUERY = new SqlConnection(Common.GetSqlConnectionString());


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


    #region "FILE Management Procedures(U115B_U115_A_GET_TOTEXP_9)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:20:06 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U115B_U115_A_GET_TOTEXP_9)"


    public void Run()
    {

        try
        {
            Request("U115_A_GET_TOTEXP_9");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

                if (Transaction())
                {
                    TOTEXP_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    TOTEXP_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");

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
            EndRequest("U115_A_GET_TOTEXP_9");

        }

    }







    #endregion


}
//U115_A_GET_TOTEXP_9



public class U115B_U115_A_GET_YTDGUA_10 : U115B
{

    public U115B_U115_A_GET_YTDGUA_10(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U115B_U115_A_GET_YTDGUA_10)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("YTDGUA"));


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


    #region "Standard Generated Procedures(U115B_U115_A_GET_YTDGUA_10)"


    #region "Automatic Item Initialization(U115B_U115_A_GET_YTDGUA_10)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U115B_U115_A_GET_YTDGUA_10)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:20:06 PM

    //#-----------------------------------------
    //# InitializeTransactionObjects Procedure.
    //#-----------------------------------------

    protected override void InitializeTransactionObjects()
    {

        try
        {
            m_cnnTRANS_UPDATE = new SqlConnection(Common.GetSqlConnectionString());
            m_cnnTRANS_UPDATE.Open();
            m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
            m_cnnQUERY = new SqlConnection(Common.GetSqlConnectionString());


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


    #region "FILE Management Procedures(U115B_U115_A_GET_YTDGUA_10)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:20:06 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U115B_U115_A_GET_YTDGUA_10)"


    public void Run()
    {

        try
        {
            Request("U115_A_GET_YTDGUA_10");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

                if (Transaction())
                {
                    YTDGUA_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    YTDGUA_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");

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
            EndRequest("U115_A_GET_YTDGUA_10");

        }

    }







    #endregion


}
//U115_A_GET_YTDGUA_10



public class U115B_U115_A_GET_YTDGUB_11 : U115B
{

    public U115B_U115_A_GET_YTDGUB_11(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U115B_U115_A_GET_YTDGUB_11)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("YTDGUB"));


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


    #region "Standard Generated Procedures(U115B_U115_A_GET_YTDGUB_11)"


    #region "Automatic Item Initialization(U115B_U115_A_GET_YTDGUB_11)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U115B_U115_A_GET_YTDGUB_11)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:20:06 PM

    //#-----------------------------------------
    //# InitializeTransactionObjects Procedure.
    //#-----------------------------------------

    protected override void InitializeTransactionObjects()
    {

        try
        {
            m_cnnTRANS_UPDATE = new SqlConnection(Common.GetSqlConnectionString());
            m_cnnTRANS_UPDATE.Open();
            m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
            m_cnnQUERY = new SqlConnection(Common.GetSqlConnectionString());


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


    #region "FILE Management Procedures(U115B_U115_A_GET_YTDGUB_11)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:20:06 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U115B_U115_A_GET_YTDGUB_11)"


    public void Run()
    {

        try
        {
            Request("U115_A_GET_YTDGUB_11");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

                if (Transaction())
                {
                    YTDGUB_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    YTDGUB_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");

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
            EndRequest("U115_A_GET_YTDGUB_11");

        }

    }







    #endregion


}
//U115_A_GET_YTDGUB_11



public class U115B_U115_A_GET_YTDGUC_12 : U115B
{

    public U115B_U115_A_GET_YTDGUC_12(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U115B_U115_A_GET_YTDGUC_12)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("YTDGUC"));


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


    #region "Standard Generated Procedures(U115B_U115_A_GET_YTDGUC_12)"


    #region "Automatic Item Initialization(U115B_U115_A_GET_YTDGUC_12)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U115B_U115_A_GET_YTDGUC_12)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:20:07 PM

    //#-----------------------------------------
    //# InitializeTransactionObjects Procedure.
    //#-----------------------------------------

    protected override void InitializeTransactionObjects()
    {

        try
        {
            m_cnnTRANS_UPDATE = new SqlConnection(Common.GetSqlConnectionString());
            m_cnnTRANS_UPDATE.Open();
            m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
            m_cnnQUERY = new SqlConnection(Common.GetSqlConnectionString());


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


    #region "FILE Management Procedures(U115B_U115_A_GET_YTDGUC_12)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:20:07 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U115B_U115_A_GET_YTDGUC_12)"


    public void Run()
    {

        try
        {
            Request("U115_A_GET_YTDGUC_12");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

                if (Transaction())
                {
                    YTDGUC_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    YTDGUC_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");

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
            EndRequest("U115_A_GET_YTDGUC_12");

        }

    }







    #endregion


}
//U115_A_GET_YTDGUC_12



public class U115B_U115_A_GET_DEPEXR_13 : U115B
{

    public U115B_U115_A_GET_DEPEXR_13(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U115B_U115_A_GET_DEPEXR_13)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("DEPEXR"));


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


    #region "Standard Generated Procedures(U115B_U115_A_GET_DEPEXR_13)"


    #region "Automatic Item Initialization(U115B_U115_A_GET_DEPEXR_13)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U115B_U115_A_GET_DEPEXR_13)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:20:07 PM

    //#-----------------------------------------
    //# InitializeTransactionObjects Procedure.
    //#-----------------------------------------

    protected override void InitializeTransactionObjects()
    {

        try
        {
            m_cnnTRANS_UPDATE = new SqlConnection(Common.GetSqlConnectionString());
            m_cnnTRANS_UPDATE.Open();
            m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
            m_cnnQUERY = new SqlConnection(Common.GetSqlConnectionString());


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


    #region "FILE Management Procedures(U115B_U115_A_GET_DEPEXR_13)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:20:07 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U115B_U115_A_GET_DEPEXR_13)"


    public void Run()
    {

        try
        {
            Request("U115_A_GET_DEPEXR_13");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

                if (Transaction())
                {
                    DEPEXR_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    DEPEXR_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");

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
            EndRequest("U115_A_GET_DEPEXR_13");

        }

    }







    #endregion


}
//U115_A_GET_DEPEXR_13



public class U115B_U115_A_GET_DEPEXM_14 : U115B
{

    public U115B_U115_A_GET_DEPEXM_14(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U115B_U115_A_GET_DEPEXM_14)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("DEPEXM"));


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


    #region "Standard Generated Procedures(U115B_U115_A_GET_DEPEXM_14)"


    #region "Automatic Item Initialization(U115B_U115_A_GET_DEPEXM_14)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U115B_U115_A_GET_DEPEXM_14)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:20:07 PM

    //#-----------------------------------------
    //# InitializeTransactionObjects Procedure.
    //#-----------------------------------------

    protected override void InitializeTransactionObjects()
    {

        try
        {
            m_cnnTRANS_UPDATE = new SqlConnection(Common.GetSqlConnectionString());
            m_cnnTRANS_UPDATE.Open();
            m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
            m_cnnQUERY = new SqlConnection(Common.GetSqlConnectionString());


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


    #region "FILE Management Procedures(U115B_U115_A_GET_DEPEXM_14)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:20:08 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U115B_U115_A_GET_DEPEXM_14)"


    public void Run()
    {

        try
        {
            Request("U115_A_GET_DEPEXM_14");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

                if (Transaction())
                {
                    DEPEXM_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    DEPEXM_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");

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
            EndRequest("U115_A_GET_DEPEXM_14");

        }

    }







    #endregion


}
//U115_A_GET_DEPEXM_14



public class U115B_U115_A_GET_GST_15 : U115B
{

    public U115B_U115_A_GET_GST_15(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U115B_U115_A_GET_GST_15)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("GST"));


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


    #region "Standard Generated Procedures(U115B_U115_A_GET_GST_15)"


    #region "Automatic Item Initialization(U115B_U115_A_GET_GST_15)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U115B_U115_A_GET_GST_15)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:20:08 PM

    //#-----------------------------------------
    //# InitializeTransactionObjects Procedure.
    //#-----------------------------------------

    protected override void InitializeTransactionObjects()
    {

        try
        {
            m_cnnTRANS_UPDATE = new SqlConnection(Common.GetSqlConnectionString());
            m_cnnTRANS_UPDATE.Open();
            m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
            m_cnnQUERY = new SqlConnection(Common.GetSqlConnectionString());


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


    #region "FILE Management Procedures(U115B_U115_A_GET_GST_15)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:20:08 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U115B_U115_A_GET_GST_15)"


    public void Run()
    {

        try
        {
            Request("U115_A_GET_GST_15");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

                if (Transaction())
                {
                    GST_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    GST_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");

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
            EndRequest("U115_A_GET_GST_15");

        }

    }







    #endregion


}
//U115_A_GET_GST_15



public class U115B_U115_A_GET_HOLDBACK_16 : U115B
{

    public U115B_U115_A_GET_HOLDBACK_16(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U115B_U115_A_GET_HOLDBACK_16)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("HOLDBK"));


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


    #region "Standard Generated Procedures(U115B_U115_A_GET_HOLDBACK_16)"


    #region "Automatic Item Initialization(U115B_U115_A_GET_HOLDBACK_16)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U115B_U115_A_GET_HOLDBACK_16)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:20:08 PM

    //#-----------------------------------------
    //# InitializeTransactionObjects Procedure.
    //#-----------------------------------------

    protected override void InitializeTransactionObjects()
    {

        try
        {
            m_cnnTRANS_UPDATE = new SqlConnection(Common.GetSqlConnectionString());
            m_cnnTRANS_UPDATE.Open();
            m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
            m_cnnQUERY = new SqlConnection(Common.GetSqlConnectionString());


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


    #region "FILE Management Procedures(U115B_U115_A_GET_HOLDBACK_16)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:20:09 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U115B_U115_A_GET_HOLDBACK_16)"


    public void Run()
    {

        try
        {
            Request("U115_A_GET_HOLDBACK_16");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

                if (Transaction())
                {
                    HOLDBACK_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    HOLDBACK_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");

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
            EndRequest("U115_A_GET_HOLDBACK_16");

        }

    }







    #endregion


}
//U115_A_GET_HOLDBACK_16



public class U115B_U115_RUN_1_17 : U115B
{

    public U115B_U115_RUN_1_17(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleCONSTANTS_MSTR_REC_6 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "CONSTANTS_MSTR_REC_6", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF110_COMPENSATION = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF112_PYCDCEILINGS = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F112_PYCDCEILINGS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
       fleF116_GROUP = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F116_DEPT_EXPENSE_RULES_DTL", "F116_GROUP", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF119_TOTEXP = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F119_DOCTOR_YTD", "F119_TOTEXP", false, false, false, 0, "m_trnTRANS_UPDATE");
        TOT_DEPT_EXPENSE_OTHER = new CoreInteger("TOT_DEPT_EXPENSE_OTHER", 10, this);
        TOT_INCOME_GROSS_REG = new CoreInteger("TOT_INCOME_GROSS_REG", 10, this);
        TOT_INCOME_GROSS_MISC = new CoreInteger("TOT_INCOME_GROSS_MISC", 10, this);
        TOT_INCOME_GROSS_OTHER = new CoreInteger("TOT_INCOME_GROSS_OTHER", 10, this);
        TOT_INCOME_NET_REG = new CoreInteger("TOT_INCOME_NET_REG", 10, this);
        TOT_INCOME_NET_MISC = new CoreInteger("TOT_INCOME_NET_MISC", 10, this);
        TOT_INCOME_NET_OTHER = new CoreInteger("TOT_INCOME_NET_OTHER", 10, this);
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
        AMT_YTDGUA = new CoreInteger("AMT_YTDGUA", 10, this);
        AMT_YTDGUB = new CoreInteger("AMT_YTDGUB", 10, this);
        AMT_YTDGUC = new CoreInteger("AMT_YTDGUC", 10, this);
        AMT_INCOME_MINUS_EXPENSES_G = new CoreInteger("AMT_INCOME_MINUS_EXPENSES_G", 10, this);
        DOC_YTDEAR_PLUS_AMT_MANPAY = new CoreInteger("DOC_YTDEAR_PLUS_AMT_MANPAY", 10, this);
        fleBRADU115B = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "BRADU115B", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF110_INCOME = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION", "F110_INCOME", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF110_EP_TOT_INCOME = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION", "F110_EP_TOT_INCOME", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF110_RMAEXR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION", "F110_RMAEXR", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF110_RMAEXM = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION", "F110_RMAEXM", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF110_GST = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION", "F110_GST", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF110_HOLDBACK = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION", "F110_HOLDBACK", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF110_DEPEXR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION", "F110_DEPEXR", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF110_DEPEXM = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION", "F110_DEPEXM", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF110_EP_TOT_EXPENSE = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION", "F110_EP_TOT_EXPENSE", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF110_EP_INCEXP = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION", "F110_EP_INCEXP", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF110_CEIEAR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION", "F110_CEIEAR", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF110_CEIEXP = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION", "F110_CEIEXP", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF110_YTDEAR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION", "F110_YTDEAR", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleDEBUGU115B_AT_COMP_CODE = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "DEBUGU115B_AT_COMP_CODE", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleDEBUGU115B_AT_DOC_NBR = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "DEBUGU115B_AT_DOC_NBR", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF020_DOCTOR_MSTR.SetItemFinals += fleF020_DOCTOR_MSTR_SetItemFinals;
        fleCONSTANTS_MSTR_REC_6.Choose += fleCONSTANTS_MSTR_REC_6_Choose;
        GST_PERCENT.GetValue += GST_PERCENT_GetValue;
        X_INCOME_GROSS_MINUS_NET.GetValue += X_INCOME_GROSS_MINUS_NET_GetValue;
        X_DEPT_EXPENSE_OTHER.GetValue += X_DEPT_EXPENSE_OTHER_GetValue;
        X_AMT_DEPT_EXPENSE_POT_G.GetValue += X_AMT_DEPT_EXPENSE_POT_G_GetValue;
        X_AMT_DEPT_EXPENSE_G.GetValue += X_AMT_DEPT_EXPENSE_G_GetValue;
        X_AMT_RMA_EXPENSE_POT_G.GetValue += X_AMT_RMA_EXPENSE_POT_G_GetValue;
        X_AMT_RMA_EXPENSE_ONLY.GetValue += X_AMT_RMA_EXPENSE_ONLY_GetValue;
        X_AMT_GST_POT_G.GetValue += X_AMT_GST_POT_G_GetValue;
        X_AMT_ROUND_OFF.GetValue += X_AMT_ROUND_OFF_GetValue;
        X_AMT_GST_ONLY.GetValue += X_AMT_GST_ONLY_GetValue;
        X_AMT_RMA_EXPENSE_PLUS_GST_G.GetValue += X_AMT_RMA_EXPENSE_PLUS_GST_G_GetValue;
        X_AMT_HOLDBACK_G.GetValue += X_AMT_HOLDBACK_G_GetValue;
        X_AMT_HOLDBACK_FINAL.GetValue += X_AMT_HOLDBACK_FINAL_GetValue;
        X_AMT_RMA_EXPENSE_FINAL.GetValue += X_AMT_RMA_EXPENSE_FINAL_GetValue;
        X_AMT_DEPT_EXPENSE_FINAL.GetValue += X_AMT_DEPT_EXPENSE_FINAL_GetValue;
        X_AMT_RMA_EXPENSE_PLUSGST_FINAL.GetValue += X_AMT_RMA_EXPENSE_PLUSGST_FINAL_GetValue;
        X_REC_TYPE.GetValue += X_REC_TYPE_GetValue;
        X_NOT_NEEDED.GetValue += X_NOT_NEEDED_GetValue;
        X_AMT_NET.GetValue += X_AMT_NET_GetValue;
        X_AMT_GROSS.GetValue += X_AMT_GROSS_GetValue;
        TOT_GST_ONLY.GetValue += TOT_GST_ONLY_GetValue;
        TOT_HOLDBACK_ONLY.GetValue += TOT_HOLDBACK_ONLY_GetValue;
        TOT_INCOME_GROSS.GetValue += TOT_INCOME_GROSS_GetValue;
        TOT_INCOME_NET.GetValue += TOT_INCOME_NET_GetValue;
        FINAL_ALL_EXPENSES.GetValue += FINAL_ALL_EXPENSES_GetValue;
        FINAL_ALL_EXPENSES_PLUS_DEPT_EXPENSE_OTHER.GetValue += FINAL_ALL_EXPENSES_PLUS_DEPT_EXPENSE_OTHER_GetValue;
        X_DOC_YTDINC_G.GetValue += X_DOC_YTDINC_G_GetValue;
        X_DOC_YTDINC_N.GetValue += X_DOC_YTDINC_N_GetValue;
        fleF020_DOCTOR_MSTR.InitializeItems += fleF020_DOCTOR_MSTR_AutomaticItemInitialization;
        fleF112_PYCDCEILINGS.InitializeItems += fleF112_PYCDCEILINGS_AutomaticItemInitialization;
        fleF116_GROUP.InitializeItems += fleF116_GROUP_AutomaticItemInitialization;
        fleF190_COMP_CODES.InitializeItems += fleF190_COMP_CODES_AutomaticItemInitialization;
        fleF119_TOTEXP.InitializeItems += fleF119_TOTEXP_AutomaticItemInitialization;
        fleF110_INCOME.InitializeItems += fleF110_INCOME_AutomaticItemInitialization;
        fleF110_EP_TOT_INCOME.InitializeItems += fleF110_EP_TOT_INCOME_AutomaticItemInitialization;
        fleF110_RMAEXR.InitializeItems += fleF110_RMAEXR_AutomaticItemInitialization;
        fleF110_RMAEXM.InitializeItems += fleF110_RMAEXM_AutomaticItemInitialization;
        fleF110_GST.InitializeItems += fleF110_GST_AutomaticItemInitialization;
        fleF110_HOLDBACK.InitializeItems += fleF110_HOLDBACK_AutomaticItemInitialization;
        fleF110_DEPEXR.InitializeItems += fleF110_DEPEXR_AutomaticItemInitialization;
        fleF110_DEPEXM.InitializeItems += fleF110_DEPEXM_AutomaticItemInitialization;
        fleF110_EP_TOT_EXPENSE.InitializeItems += fleF110_EP_TOT_EXPENSE_AutomaticItemInitialization;
        fleF110_EP_INCEXP.InitializeItems += fleF110_EP_INCEXP_AutomaticItemInitialization;
        fleF110_CEIEAR.InitializeItems += fleF110_CEIEAR_AutomaticItemInitialization;
        fleF110_CEIEXP.InitializeItems += fleF110_CEIEXP_AutomaticItemInitialization;
        fleF110_YTDEAR.InitializeItems += fleF110_YTDEAR_AutomaticItemInitialization;

    }


    #region "Declarations (Variables, Files and Transactions)(U115B_U115_RUN_1_17)"

    private SqlFileObject fleCONSTANTS_MSTR_REC_6;
    private SqlFileObject fleF110_COMPENSATION;
    private SqlFileObject fleF020_DOCTOR_MSTR;

    private void fleF020_DOCTOR_MSTR_SetItemFinals()
    {

        try
        {
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_TOTINC_G", TOT_INCOME_GROSS.Value);
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_TOTINC", TOT_INCOME_NET.Value);
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_YTDINC", X_DOC_YTDINC_N.Value);
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_YTDINC", X_DOC_YTDINC_N.Value);
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_YTDINC_G", X_DOC_YTDINC_G.Value);
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_YTDGUA", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUA") + AMT_YTDGUA.Value);
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_YTDGUB", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUB") + AMT_YTDGUB.Value);
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_YTDGUC", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUC") + AMT_YTDGUC.Value);
            if (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_EP_PAY_CODE")) == "6")
            {
                fleF020_DOCTOR_MSTR.set_SetValue("DOC_YRLY_EXPENSE_COMPUTED", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YRLY_EXPENSE_COMPUTED") + FINAL_ALL_EXPENSES_PLUS_DEPT_EXPENSE_OTHER.Value);
            }
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_YTDEAR", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDEAR") + AMT_MANPAY.Value);


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

    private SqlFileObject fleF112_PYCDCEILINGS;
    private SqlFileObject fleF116_GROUP;
    private SqlFileObject fleF190_COMP_CODES;
    private SqlFileObject fleF119_TOTEXP;

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

    private DInteger GST_PERCENT = new DInteger("GST_PERCENT", 8);
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
    private DInteger X_INCOME_GROSS_MINUS_NET = new DInteger("X_INCOME_GROSS_MINUS_NET", 8);
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
    private DInteger X_DEPT_EXPENSE_OTHER = new DInteger("X_DEPT_EXPENSE_OTHER", 10);
    private void X_DEPT_EXPENSE_OTHER_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0;
            if (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("COMP_TYPE")) == "E" & QDesign.NULL(fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE")) == "O")
            {
                CurrentValue = QDesign.Round((fleF110_COMPENSATION.GetDecimalValue("AMT_NET")), 0, RoundOptionTypes.Near);
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
    private CoreInteger TOT_DEPT_EXPENSE_OTHER;
    private DInteger X_AMT_DEPT_EXPENSE_POT_G = new DInteger("X_AMT_DEPT_EXPENSE_POT_G", 10);
    private void X_AMT_DEPT_EXPENSE_POT_G_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0;

            // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

            if (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("COMP_TYPE")) == "I" & QDesign.NULL(fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE")) == "R")
            {
                CurrentValue = QDesign.Round((fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS") / 1000000) * fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_REG"), 0, RoundOptionTypes.Near);
            }
            else if (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("COMP_TYPE")) == "I" & QDesign.NULL(fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE")) == "M")
            {
                CurrentValue = QDesign.Round((fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS") / 1000000) * fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_MISC"), 0, RoundOptionTypes.Near);
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
    private DInteger X_AMT_DEPT_EXPENSE_G = new DInteger("X_AMT_DEPT_EXPENSE_G", 8);
    private void X_AMT_DEPT_EXPENSE_G_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0;
            if ((QDesign.NULL(X_AMT_DEPT_EXPENSE_POT_G.Value) < QDesign.NULL(X_INCOME_GROSS_MINUS_NET.Value) & QDesign.NULL(fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS")) > 0) | (QDesign.NULL(X_AMT_DEPT_EXPENSE_POT_G.Value) > QDesign.NULL(X_INCOME_GROSS_MINUS_NET.Value) & QDesign.NULL(fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS")) < 0))
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
    private DInteger X_AMT_RMA_EXPENSE_POT_G = new DInteger("X_AMT_RMA_EXPENSE_POT_G", 10);
    private void X_AMT_RMA_EXPENSE_POT_G_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0;

            // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

            if (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("COMP_TYPE")) == "I" & QDesign.NULL(fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE")) == "R")
            {
                CurrentValue = QDesign.Round((fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS") / 1000000) * fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_REG"), 0, RoundOptionTypes.Near);
            }
            else if (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("COMP_TYPE")) == "I" & QDesign.NULL(fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE")) == "M")
            {
                CurrentValue = QDesign.Round((fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS") / 1000000) * fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_MISC"), 0, RoundOptionTypes.Near);
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
    private DInteger X_AMT_RMA_EXPENSE_ONLY = new DInteger("X_AMT_RMA_EXPENSE_ONLY", 8);
    private void X_AMT_RMA_EXPENSE_ONLY_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0;
            if ((QDesign.NULL(X_INCOME_GROSS_MINUS_NET.Value) > QDesign.NULL((X_AMT_DEPT_EXPENSE_G.Value + X_AMT_RMA_EXPENSE_POT_G.Value)) & QDesign.NULL(fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS")) > 0) | (QDesign.NULL(X_INCOME_GROSS_MINUS_NET.Value) < QDesign.NULL((X_AMT_DEPT_EXPENSE_G.Value + X_AMT_RMA_EXPENSE_POT_G.Value)) & QDesign.NULL(fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS")) < 0))
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
    private DInteger X_AMT_GST_POT_G = new DInteger("X_AMT_GST_POT_G", 8);
    private void X_AMT_GST_POT_G_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0;

            // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

            if (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_IND_PAYS_GST")) == "Y")
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
    private DInteger X_AMT_ROUND_OFF = new DInteger("X_AMT_ROUND_OFF", 8);
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
    private DInteger X_AMT_GST_ONLY = new DInteger("X_AMT_GST_ONLY", 8);
    private void X_AMT_GST_ONLY_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0;
            if ((((QDesign.NULL(X_INCOME_GROSS_MINUS_NET.Value) > QDesign.NULL((X_AMT_DEPT_EXPENSE_G.Value + X_AMT_RMA_EXPENSE_ONLY.Value + X_AMT_GST_POT_G.Value))) & QDesign.NULL(fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS")) > 0) | ((QDesign.NULL(X_INCOME_GROSS_MINUS_NET.Value) < QDesign.NULL((X_AMT_DEPT_EXPENSE_G.Value + X_AMT_RMA_EXPENSE_ONLY.Value + X_AMT_GST_POT_G.Value))) & QDesign.NULL(fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS")) < 0)) & (QDesign.NULL(X_AMT_ROUND_OFF.Value) > 5))
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
    private DInteger X_AMT_RMA_EXPENSE_PLUS_GST_G = new DInteger("X_AMT_RMA_EXPENSE_PLUS_GST_G", 10);
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
    private DInteger X_AMT_HOLDBACK_G = new DInteger("X_AMT_HOLDBACK_G", 10);
    private void X_AMT_HOLDBACK_G_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0;
            if (((QDesign.NULL(X_INCOME_GROSS_MINUS_NET.Value) > QDesign.NULL((X_AMT_DEPT_EXPENSE_G.Value + X_AMT_RMA_EXPENSE_PLUS_GST_G.Value)) & QDesign.NULL(fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS")) > 0) | (QDesign.NULL(X_INCOME_GROSS_MINUS_NET.Value) < QDesign.NULL((X_AMT_DEPT_EXPENSE_G.Value + X_AMT_RMA_EXPENSE_PLUS_GST_G.Value)) & QDesign.NULL(fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS")) < 0)))
            {
                CurrentValue = QDesign.Round(X_INCOME_GROSS_MINUS_NET.Value - X_AMT_DEPT_EXPENSE_G.Value - X_AMT_RMA_EXPENSE_PLUS_GST_G.Value, 0, RoundOptionTypes.Near);
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
    private DDecimal X_AMT_HOLDBACK_FINAL = new DDecimal("X_AMT_HOLDBACK_FINAL", 6);
    private void X_AMT_HOLDBACK_FINAL_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(X_AMT_HOLDBACK_G.Value) > 100 | (QDesign.NULL(X_AMT_RMA_EXPENSE_ONLY.Value) == 0 & QDesign.NULL(X_AMT_DEPT_EXPENSE_G.Value) == 0))
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
    private DDecimal X_AMT_RMA_EXPENSE_FINAL = new DDecimal("X_AMT_RMA_EXPENSE_FINAL", 6);
    private void X_AMT_RMA_EXPENSE_FINAL_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(X_AMT_HOLDBACK_G.Value) < 10 & QDesign.NULL(X_AMT_RMA_EXPENSE_ONLY.Value) != 0)
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
    private DDecimal X_AMT_DEPT_EXPENSE_FINAL = new DDecimal("X_AMT_DEPT_EXPENSE_FINAL", 6);
    private void X_AMT_DEPT_EXPENSE_FINAL_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(X_AMT_HOLDBACK_G.Value) < 10 & QDesign.NULL(X_AMT_DEPT_EXPENSE_G.Value) != 0)
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
    private DInteger X_AMT_RMA_EXPENSE_PLUSGST_FINAL = new DInteger("X_AMT_RMA_EXPENSE_PLUSGST_FINAL", 10);
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
    private CoreInteger AMT_YTDGUA;
    private CoreInteger AMT_YTDGUB;
    private CoreInteger AMT_YTDGUC;
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
    private DInteger X_NOT_NEEDED = new DInteger("X_NOT_NEEDED", 10);
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
    private DInteger X_AMT_NET = new DInteger("X_AMT_NET", 10);
    private void X_AMT_NET_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0;
            if (QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == "CEIEXP")
            {
                CurrentValue = fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS");
            }
            else
            {
                CurrentValue = fleF110_COMPENSATION.GetDecimalValue("AMT_NET");
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
    private DInteger X_AMT_GROSS = new DInteger("X_AMT_GROSS", 10);
    private void X_AMT_GROSS_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0;
            if (QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == "CEIEXP")
            {
                CurrentValue = fleF110_COMPENSATION.GetDecimalValue("AMT_NET");
            }
            else
            {
                CurrentValue = fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS");
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
    private DInteger TOT_GST_ONLY = new DInteger("TOT_GST_ONLY", 10);
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
    private DInteger TOT_HOLDBACK_ONLY = new DInteger("TOT_HOLDBACK_ONLY", 10);
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
    private DInteger TOT_INCOME_GROSS = new DInteger("TOT_INCOME_GROSS", 10);
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
    private DInteger TOT_INCOME_NET = new DInteger("TOT_INCOME_NET", 10);
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
    private DInteger FINAL_ALL_EXPENSES = new DInteger("FINAL_ALL_EXPENSES", 10);
    private void FINAL_ALL_EXPENSES_GetValue(ref decimal Value)
    {

        try
        {
            Value = TOT_DEPT_EXPENSE_REG.Value + TOT_DEPT_EXPENSE_MISC.Value + TOT_RMA_EXPENSE_ONLY_REG.Value + TOT_RMA_EXPENSE_ONLY_MISC.Value + TOT_GST_ONLY.Value + TOT_HOLDBACK_ONLY.Value + TOT_REVHBK.Value + fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CEICEX");


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
    private DInteger FINAL_ALL_EXPENSES_PLUS_DEPT_EXPENSE_OTHER = new DInteger("FINAL_ALL_EXPENSES_PLUS_DEPT_EXPENSE_OTHER", 10);
    private void FINAL_ALL_EXPENSES_PLUS_DEPT_EXPENSE_OTHER_GetValue(ref decimal Value)
    {

        try
        {
            Value = FINAL_ALL_EXPENSES.Value + TOT_DEPT_EXPENSE_OTHER.Value;


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
    private CoreInteger AMT_INCOME_MINUS_EXPENSES_G;
    private CoreInteger DOC_YTDEAR_PLUS_AMT_MANPAY;
    private DInteger X_DOC_YTDINC_G = new DInteger("X_DOC_YTDINC_G", 10);
    private void X_DOC_YTDINC_G_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDINC_G") + TOT_INCOME_GROSS.Value;


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
    private DInteger X_DOC_YTDINC_N = new DInteger("X_DOC_YTDINC_N", 10);
    private void X_DOC_YTDINC_N_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDINC_G") + TOT_INCOME_GROSS.Value - FINAL_ALL_EXPENSES_PLUS_DEPT_EXPENSE_OTHER.Value - fleF119_TOTEXP.GetDecimalValue("AMT_YTD");


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
    private SqlFileObject fleBRADU115B;
    private SqlFileObject fleF110_INCOME;
    private SqlFileObject fleF110_EP_TOT_INCOME;
    private SqlFileObject fleF110_RMAEXR;
    private SqlFileObject fleF110_RMAEXM;
    private SqlFileObject fleF110_GST;
    private SqlFileObject fleF110_HOLDBACK;
    private SqlFileObject fleF110_DEPEXR;
    private SqlFileObject fleF110_DEPEXM;
    private SqlFileObject fleF110_EP_TOT_EXPENSE;
    private SqlFileObject fleF110_EP_INCEXP;
    private SqlFileObject fleF110_CEIEAR;
    private SqlFileObject fleF110_CEIEXP;
    private SqlFileObject fleF110_YTDEAR;
    private SqlFileObject fleDEBUGU115B_AT_COMP_CODE;
    private SqlFileObject fleDEBUGU115B_AT_DOC_NBR;


    #endregion


    #region "Standard Generated Procedures(U115B_U115_RUN_1_17)"


    #region "Automatic Item Initialization(U115B_U115_RUN_1_17)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:20:46 PM

    //#-----------------------------------------
    //# fleF020_DOCTOR_MSTR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:20:13 PM
    //#-----------------------------------------
    private void fleF020_DOCTOR_MSTR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_NBR", !Fixed, fleF110_COMPENSATION.GetStringValue("DOC_NBR"));

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
    //# fleF112_PYCDCEILINGS_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:20:13 PM
    //#-----------------------------------------
    private void fleF112_PYCDCEILINGS_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF112_PYCDCEILINGS.set_SetValue("DOC_NBR", !Fixed, fleF110_COMPENSATION.GetStringValue("DOC_NBR"));
            fleF112_PYCDCEILINGS.set_SetValue("EP_NBR", !Fixed, fleF110_COMPENSATION.GetDecimalValue("EP_NBR"));
            fleF112_PYCDCEILINGS.set_SetValue("FACTOR", !Fixed, fleF110_COMPENSATION.GetDecimalValue("FACTOR"));
            fleF112_PYCDCEILINGS.set_SetValue("LAST_MOD_DATE", !Fixed, fleF110_COMPENSATION.GetDecimalValue("LAST_MOD_DATE"));
            fleF112_PYCDCEILINGS.set_SetValue("LAST_MOD_TIME", !Fixed, fleF110_COMPENSATION.GetDecimalValue("LAST_MOD_TIME"));
            fleF112_PYCDCEILINGS.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF110_COMPENSATION.GetStringValue("LAST_MOD_USER_ID"));
            //TODO: Manual steps may be required.
            fleF112_PYCDCEILINGS.set_SetValue("DOC_RMA_EXPENSE_PERCENT_MISC", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_MISC"));
            fleF112_PYCDCEILINGS.set_SetValue("DOC_YRLY_CEILING_COMPUTED", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YRLY_CEILING_COMPUTED"));
            fleF112_PYCDCEILINGS.set_SetValue("DOC_YRLY_EXPENSE_COMPUTED", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YRLY_EXPENSE_COMPUTED"));
            fleF112_PYCDCEILINGS.set_SetValue("DOC_RMA_EXPENSE_PERCENT_REG", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_REG"));
            fleF112_PYCDCEILINGS.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_MISC", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_MISC"));
            fleF112_PYCDCEILINGS.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_REG", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_REG"));

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
    //# fleF116_GROUP_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:20:13 PM
    //#-----------------------------------------
    private void fleF116_GROUP_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF116_GROUP.set_SetValue("DOC_NBR", !Fixed, fleF110_COMPENSATION.GetStringValue("DOC_NBR"));
            fleF116_GROUP.set_SetValue("COMP_CODE", !Fixed, fleF110_COMPENSATION.GetStringValue("COMP_CODE"));
            //TODO: Manual steps may be required.
            fleF116_GROUP.set_SetValue("DOC_AFP_PAYM_GROUP", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP"));

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
    //# fleF190_COMP_CODES_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:20:13 PM
    //#-----------------------------------------
    private void fleF190_COMP_CODES_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF190_COMP_CODES.set_SetValue("PROCESS_SEQ", !Fixed, fleF110_COMPENSATION.GetDecimalValue("PROCESS_SEQ"));
            fleF190_COMP_CODES.set_SetValue("COMP_CODE", !Fixed, fleF110_COMPENSATION.GetStringValue("COMP_CODE"));
            fleF190_COMP_CODES.set_SetValue("COMP_TYPE", !Fixed, fleF110_COMPENSATION.GetStringValue("COMP_TYPE"));
            fleF190_COMP_CODES.set_SetValue("FACTOR", !Fixed, fleF110_COMPENSATION.GetDecimalValue("FACTOR"));
            fleF190_COMP_CODES.set_SetValue("LAST_MOD_DATE", !Fixed, fleF110_COMPENSATION.GetDecimalValue("LAST_MOD_DATE"));
            fleF190_COMP_CODES.set_SetValue("LAST_MOD_TIME", !Fixed, fleF110_COMPENSATION.GetDecimalValue("LAST_MOD_TIME"));
            fleF190_COMP_CODES.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF110_COMPENSATION.GetStringValue("LAST_MOD_USER_ID"));
            //TODO: Manual steps may be required.
            fleF190_COMP_CODES.set_SetValue("DESC_LONG", !Fixed, fleF116_GROUP.GetStringValue("DESC_LONG"));
            fleF190_COMP_CODES.set_SetValue("DESC_SHORT", !Fixed, fleF116_GROUP.GetStringValue("DESC_SHORT"));

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
    //# fleF119_TOTEXP_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:20:13 PM
    //#-----------------------------------------
    private void fleF119_TOTEXP_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF119_TOTEXP.set_SetValue("DOC_NBR", !Fixed, fleF110_COMPENSATION.GetStringValue("DOC_NBR"));
            fleF119_TOTEXP.set_SetValue("PROCESS_SEQ", !Fixed, fleF110_COMPENSATION.GetDecimalValue("PROCESS_SEQ"));
            fleF119_TOTEXP.set_SetValue("COMP_CODE", !Fixed, fleF110_COMPENSATION.GetStringValue("COMP_CODE"));
            fleF119_TOTEXP.set_SetValue("LAST_MOD_DATE", !Fixed, fleF110_COMPENSATION.GetDecimalValue("LAST_MOD_DATE"));
            fleF119_TOTEXP.set_SetValue("LAST_MOD_TIME", !Fixed, fleF110_COMPENSATION.GetDecimalValue("LAST_MOD_TIME"));
            fleF119_TOTEXP.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF110_COMPENSATION.GetStringValue("LAST_MOD_USER_ID"));
            fleF119_TOTEXP.set_SetValue("FILLER", !Fixed, fleF110_COMPENSATION.GetStringValue("FILLER"));
            //TODO: Manual steps may be required.
            fleF119_TOTEXP.set_SetValue("DOC_OHIP_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR"));
            //TODO: Manual steps may be required.
            fleF119_TOTEXP.set_SetValue("COMP_CODE_GROUP", !Fixed, fleF190_COMP_CODES.GetStringValue("COMP_CODE_GROUP"));

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
    //# fleF110_INCOME_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:20:17 PM
    //#-----------------------------------------
    private void fleF110_INCOME_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF110_INCOME.set_SetValue("DOC_NBR", !Fixed, fleF110_COMPENSATION.GetStringValue("DOC_NBR"));
            fleF110_INCOME.set_SetValue("EP_NBR", !Fixed, fleF110_COMPENSATION.GetDecimalValue("EP_NBR"));
            fleF110_INCOME.set_SetValue("PROCESS_SEQ", !Fixed, fleF110_COMPENSATION.GetDecimalValue("PROCESS_SEQ"));
            fleF110_INCOME.set_SetValue("COMP_CODE", !Fixed, fleF110_COMPENSATION.GetStringValue("COMP_CODE"));
            fleF110_INCOME.set_SetValue("COMP_TYPE", !Fixed, fleF110_COMPENSATION.GetStringValue("COMP_TYPE"));
            fleF110_INCOME.set_SetValue("FACTOR", !Fixed, fleF110_COMPENSATION.GetDecimalValue("FACTOR"));
            fleF110_INCOME.set_SetValue("FACTOR_OVERRIDE", !Fixed, fleF110_COMPENSATION.GetStringValue("FACTOR_OVERRIDE"));
            fleF110_INCOME.set_SetValue("COMP_UNITS", !Fixed, fleF110_COMPENSATION.GetDecimalValue("COMP_UNITS"));
            fleF110_INCOME.set_SetValue("AMT_GROSS", !Fixed, fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS"));
            fleF110_INCOME.set_SetValue("AMT_NET", !Fixed, fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
            fleF110_INCOME.set_SetValue("EP_NBR_ENTRY", !Fixed, fleF110_COMPENSATION.GetDecimalValue("EP_NBR_ENTRY"));
            fleF110_INCOME.set_SetValue("COMPENSATION_STATUS", !Fixed, fleF110_COMPENSATION.GetStringValue("COMPENSATION_STATUS"));
            fleF110_INCOME.set_SetValue("LAST_MOD_DATE", !Fixed, fleF110_COMPENSATION.GetDecimalValue("LAST_MOD_DATE"));
            fleF110_INCOME.set_SetValue("LAST_MOD_TIME", !Fixed, fleF110_COMPENSATION.GetDecimalValue("LAST_MOD_TIME"));
            fleF110_INCOME.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF110_COMPENSATION.GetStringValue("LAST_MOD_USER_ID"));
            fleF110_INCOME.set_SetValue("FILLER", !Fixed, fleF110_COMPENSATION.GetStringValue("FILLER"));

        
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
    //# fleF110_EP_TOT_INCOME_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:20:18 PM
    //#-----------------------------------------
    private void fleF110_EP_TOT_INCOME_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF110_EP_TOT_INCOME.set_SetValue("DOC_NBR", !Fixed, fleF110_COMPENSATION.GetStringValue("DOC_NBR"));
            fleF110_EP_TOT_INCOME.set_SetValue("EP_NBR", !Fixed, fleF110_COMPENSATION.GetDecimalValue("EP_NBR"));
            fleF110_EP_TOT_INCOME.set_SetValue("PROCESS_SEQ", !Fixed, fleF110_COMPENSATION.GetDecimalValue("PROCESS_SEQ"));
            fleF110_EP_TOT_INCOME.set_SetValue("COMP_CODE", !Fixed, fleF110_COMPENSATION.GetStringValue("COMP_CODE"));
            fleF110_EP_TOT_INCOME.set_SetValue("COMP_TYPE", !Fixed, fleF110_COMPENSATION.GetStringValue("COMP_TYPE"));
            fleF110_EP_TOT_INCOME.set_SetValue("FACTOR", !Fixed, fleF110_COMPENSATION.GetDecimalValue("FACTOR"));
            fleF110_EP_TOT_INCOME.set_SetValue("FACTOR_OVERRIDE", !Fixed, fleF110_COMPENSATION.GetStringValue("FACTOR_OVERRIDE"));
            fleF110_EP_TOT_INCOME.set_SetValue("COMP_UNITS", !Fixed, fleF110_COMPENSATION.GetDecimalValue("COMP_UNITS"));
            fleF110_EP_TOT_INCOME.set_SetValue("AMT_GROSS", !Fixed, fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS"));
            fleF110_EP_TOT_INCOME.set_SetValue("AMT_NET", !Fixed, fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
            fleF110_EP_TOT_INCOME.set_SetValue("EP_NBR_ENTRY", !Fixed, fleF110_COMPENSATION.GetDecimalValue("EP_NBR_ENTRY"));
            fleF110_EP_TOT_INCOME.set_SetValue("COMPENSATION_STATUS", !Fixed, fleF110_COMPENSATION.GetStringValue("COMPENSATION_STATUS"));
            fleF110_EP_TOT_INCOME.set_SetValue("LAST_MOD_DATE", !Fixed, fleF110_COMPENSATION.GetDecimalValue("LAST_MOD_DATE"));
            fleF110_EP_TOT_INCOME.set_SetValue("LAST_MOD_TIME", !Fixed, fleF110_COMPENSATION.GetDecimalValue("LAST_MOD_TIME"));
            fleF110_EP_TOT_INCOME.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF110_COMPENSATION.GetStringValue("LAST_MOD_USER_ID"));
            fleF110_EP_TOT_INCOME.set_SetValue("FILLER", !Fixed, fleF110_COMPENSATION.GetStringValue("FILLER"));

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
    //# fleF110_RMAEXR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:20:18 PM
    //#-----------------------------------------
    private void fleF110_RMAEXR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF110_RMAEXR.set_SetValue("DOC_NBR", !Fixed, fleF110_COMPENSATION.GetStringValue("DOC_NBR"));
            fleF110_RMAEXR.set_SetValue("EP_NBR", !Fixed, fleF110_COMPENSATION.GetDecimalValue("EP_NBR"));
            fleF110_RMAEXR.set_SetValue("PROCESS_SEQ", !Fixed, fleF110_COMPENSATION.GetDecimalValue("PROCESS_SEQ"));
            fleF110_RMAEXR.set_SetValue("COMP_CODE", !Fixed, fleF110_COMPENSATION.GetStringValue("COMP_CODE"));
            fleF110_RMAEXR.set_SetValue("COMP_TYPE", !Fixed, fleF110_COMPENSATION.GetStringValue("COMP_TYPE"));
            fleF110_RMAEXR.set_SetValue("FACTOR", !Fixed, fleF110_COMPENSATION.GetDecimalValue("FACTOR"));
            fleF110_RMAEXR.set_SetValue("FACTOR_OVERRIDE", !Fixed, fleF110_COMPENSATION.GetStringValue("FACTOR_OVERRIDE"));
            fleF110_RMAEXR.set_SetValue("COMP_UNITS", !Fixed, fleF110_COMPENSATION.GetDecimalValue("COMP_UNITS"));
            fleF110_RMAEXR.set_SetValue("AMT_GROSS", !Fixed, fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS"));
            fleF110_RMAEXR.set_SetValue("AMT_NET", !Fixed, fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
            fleF110_RMAEXR.set_SetValue("EP_NBR_ENTRY", !Fixed, fleF110_COMPENSATION.GetDecimalValue("EP_NBR_ENTRY"));
            fleF110_RMAEXR.set_SetValue("COMPENSATION_STATUS", !Fixed, fleF110_COMPENSATION.GetStringValue("COMPENSATION_STATUS"));
            fleF110_RMAEXR.set_SetValue("LAST_MOD_DATE", !Fixed, fleF110_COMPENSATION.GetDecimalValue("LAST_MOD_DATE"));
            fleF110_RMAEXR.set_SetValue("LAST_MOD_TIME", !Fixed, fleF110_COMPENSATION.GetDecimalValue("LAST_MOD_TIME"));
            fleF110_RMAEXR.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF110_COMPENSATION.GetStringValue("LAST_MOD_USER_ID"));
            fleF110_RMAEXR.set_SetValue("FILLER", !Fixed, fleF110_COMPENSATION.GetStringValue("FILLER"));

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
    //# fleF110_RMAEXM_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:20:19 PM
    //#-----------------------------------------
    private void fleF110_RMAEXM_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF110_RMAEXM.set_SetValue("DOC_NBR", !Fixed, fleF110_COMPENSATION.GetStringValue("DOC_NBR"));
            fleF110_RMAEXM.set_SetValue("EP_NBR", !Fixed, fleF110_COMPENSATION.GetDecimalValue("EP_NBR"));
            fleF110_RMAEXM.set_SetValue("PROCESS_SEQ", !Fixed, fleF110_COMPENSATION.GetDecimalValue("PROCESS_SEQ"));
            fleF110_RMAEXM.set_SetValue("COMP_CODE", !Fixed, fleF110_COMPENSATION.GetStringValue("COMP_CODE"));
            fleF110_RMAEXM.set_SetValue("COMP_TYPE", !Fixed, fleF110_COMPENSATION.GetStringValue("COMP_TYPE"));
            fleF110_RMAEXM.set_SetValue("FACTOR", !Fixed, fleF110_COMPENSATION.GetDecimalValue("FACTOR"));
            fleF110_RMAEXM.set_SetValue("FACTOR_OVERRIDE", !Fixed, fleF110_COMPENSATION.GetStringValue("FACTOR_OVERRIDE"));
            fleF110_RMAEXM.set_SetValue("COMP_UNITS", !Fixed, fleF110_COMPENSATION.GetDecimalValue("COMP_UNITS"));
            fleF110_RMAEXM.set_SetValue("AMT_GROSS", !Fixed, fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS"));
            fleF110_RMAEXM.set_SetValue("AMT_NET", !Fixed, fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
            fleF110_RMAEXM.set_SetValue("EP_NBR_ENTRY", !Fixed, fleF110_COMPENSATION.GetDecimalValue("EP_NBR_ENTRY"));
            fleF110_RMAEXM.set_SetValue("COMPENSATION_STATUS", !Fixed, fleF110_COMPENSATION.GetStringValue("COMPENSATION_STATUS"));
            fleF110_RMAEXM.set_SetValue("LAST_MOD_DATE", !Fixed, fleF110_COMPENSATION.GetDecimalValue("LAST_MOD_DATE"));
            fleF110_RMAEXM.set_SetValue("LAST_MOD_TIME", !Fixed, fleF110_COMPENSATION.GetDecimalValue("LAST_MOD_TIME"));
            fleF110_RMAEXM.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF110_COMPENSATION.GetStringValue("LAST_MOD_USER_ID"));
            fleF110_RMAEXM.set_SetValue("FILLER", !Fixed, fleF110_COMPENSATION.GetStringValue("FILLER"));

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
    //# fleF110_GST_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:20:19 PM
    //#-----------------------------------------
    private void fleF110_GST_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF110_GST.set_SetValue("DOC_NBR", !Fixed, fleF110_COMPENSATION.GetStringValue("DOC_NBR"));
            fleF110_GST.set_SetValue("EP_NBR", !Fixed, fleF110_COMPENSATION.GetDecimalValue("EP_NBR"));
            fleF110_GST.set_SetValue("PROCESS_SEQ", !Fixed, fleF110_COMPENSATION.GetDecimalValue("PROCESS_SEQ"));
            fleF110_GST.set_SetValue("COMP_CODE", !Fixed, fleF110_COMPENSATION.GetStringValue("COMP_CODE"));
            fleF110_GST.set_SetValue("COMP_TYPE", !Fixed, fleF110_COMPENSATION.GetStringValue("COMP_TYPE"));
            fleF110_GST.set_SetValue("FACTOR", !Fixed, fleF110_COMPENSATION.GetDecimalValue("FACTOR"));
            fleF110_GST.set_SetValue("FACTOR_OVERRIDE", !Fixed, fleF110_COMPENSATION.GetStringValue("FACTOR_OVERRIDE"));
            fleF110_GST.set_SetValue("COMP_UNITS", !Fixed, fleF110_COMPENSATION.GetDecimalValue("COMP_UNITS"));
            fleF110_GST.set_SetValue("AMT_GROSS", !Fixed, fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS"));
            fleF110_GST.set_SetValue("AMT_NET", !Fixed, fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
            fleF110_GST.set_SetValue("EP_NBR_ENTRY", !Fixed, fleF110_COMPENSATION.GetDecimalValue("EP_NBR_ENTRY"));
            fleF110_GST.set_SetValue("COMPENSATION_STATUS", !Fixed, fleF110_COMPENSATION.GetStringValue("COMPENSATION_STATUS"));
            fleF110_GST.set_SetValue("LAST_MOD_DATE", !Fixed, fleF110_COMPENSATION.GetDecimalValue("LAST_MOD_DATE"));
            fleF110_GST.set_SetValue("LAST_MOD_TIME", !Fixed, fleF110_COMPENSATION.GetDecimalValue("LAST_MOD_TIME"));
            fleF110_GST.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF110_COMPENSATION.GetStringValue("LAST_MOD_USER_ID"));
            fleF110_GST.set_SetValue("FILLER", !Fixed, fleF110_COMPENSATION.GetStringValue("FILLER"));

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
    //# fleF110_HOLDBACK_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:20:20 PM
    //#-----------------------------------------
    private void fleF110_HOLDBACK_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF110_HOLDBACK.set_SetValue("DOC_NBR", !Fixed, fleF110_COMPENSATION.GetStringValue("DOC_NBR"));
            fleF110_HOLDBACK.set_SetValue("EP_NBR", !Fixed, fleF110_COMPENSATION.GetDecimalValue("EP_NBR"));
            fleF110_HOLDBACK.set_SetValue("PROCESS_SEQ", !Fixed, fleF110_COMPENSATION.GetDecimalValue("PROCESS_SEQ"));
            fleF110_HOLDBACK.set_SetValue("COMP_CODE", !Fixed, fleF110_COMPENSATION.GetStringValue("COMP_CODE"));
            fleF110_HOLDBACK.set_SetValue("COMP_TYPE", !Fixed, fleF110_COMPENSATION.GetStringValue("COMP_TYPE"));
            fleF110_HOLDBACK.set_SetValue("FACTOR", !Fixed, fleF110_COMPENSATION.GetDecimalValue("FACTOR"));
            fleF110_HOLDBACK.set_SetValue("FACTOR_OVERRIDE", !Fixed, fleF110_COMPENSATION.GetStringValue("FACTOR_OVERRIDE"));
            fleF110_HOLDBACK.set_SetValue("COMP_UNITS", !Fixed, fleF110_COMPENSATION.GetDecimalValue("COMP_UNITS"));
            fleF110_HOLDBACK.set_SetValue("AMT_GROSS", !Fixed, fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS"));
            fleF110_HOLDBACK.set_SetValue("AMT_NET", !Fixed, fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
            fleF110_HOLDBACK.set_SetValue("EP_NBR_ENTRY", !Fixed, fleF110_COMPENSATION.GetDecimalValue("EP_NBR_ENTRY"));
            fleF110_HOLDBACK.set_SetValue("COMPENSATION_STATUS", !Fixed, fleF110_COMPENSATION.GetStringValue("COMPENSATION_STATUS"));
            fleF110_HOLDBACK.set_SetValue("LAST_MOD_DATE", !Fixed, fleF110_COMPENSATION.GetDecimalValue("LAST_MOD_DATE"));
            fleF110_HOLDBACK.set_SetValue("LAST_MOD_TIME", !Fixed, fleF110_COMPENSATION.GetDecimalValue("LAST_MOD_TIME"));
            fleF110_HOLDBACK.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF110_COMPENSATION.GetStringValue("LAST_MOD_USER_ID"));
            fleF110_HOLDBACK.set_SetValue("FILLER", !Fixed, fleF110_COMPENSATION.GetStringValue("FILLER"));

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
    //# fleF110_DEPEXR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:20:20 PM
    //#-----------------------------------------
    private void fleF110_DEPEXR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF110_DEPEXR.set_SetValue("DOC_NBR", !Fixed, fleF110_COMPENSATION.GetStringValue("DOC_NBR"));
            fleF110_DEPEXR.set_SetValue("EP_NBR", !Fixed, fleF110_COMPENSATION.GetDecimalValue("EP_NBR"));
            fleF110_DEPEXR.set_SetValue("PROCESS_SEQ", !Fixed, fleF110_COMPENSATION.GetDecimalValue("PROCESS_SEQ"));
            fleF110_DEPEXR.set_SetValue("COMP_CODE", !Fixed, fleF110_COMPENSATION.GetStringValue("COMP_CODE"));
            fleF110_DEPEXR.set_SetValue("COMP_TYPE", !Fixed, fleF110_COMPENSATION.GetStringValue("COMP_TYPE"));
            fleF110_DEPEXR.set_SetValue("FACTOR", !Fixed, fleF110_COMPENSATION.GetDecimalValue("FACTOR"));
            fleF110_DEPEXR.set_SetValue("FACTOR_OVERRIDE", !Fixed, fleF110_COMPENSATION.GetStringValue("FACTOR_OVERRIDE"));
            fleF110_DEPEXR.set_SetValue("COMP_UNITS", !Fixed, fleF110_COMPENSATION.GetDecimalValue("COMP_UNITS"));
            fleF110_DEPEXR.set_SetValue("AMT_GROSS", !Fixed, fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS"));
            fleF110_DEPEXR.set_SetValue("AMT_NET", !Fixed, fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
            fleF110_DEPEXR.set_SetValue("EP_NBR_ENTRY", !Fixed, fleF110_COMPENSATION.GetDecimalValue("EP_NBR_ENTRY"));
            fleF110_DEPEXR.set_SetValue("COMPENSATION_STATUS", !Fixed, fleF110_COMPENSATION.GetStringValue("COMPENSATION_STATUS"));
            fleF110_DEPEXR.set_SetValue("LAST_MOD_DATE", !Fixed, fleF110_COMPENSATION.GetDecimalValue("LAST_MOD_DATE"));
            fleF110_DEPEXR.set_SetValue("LAST_MOD_TIME", !Fixed, fleF110_COMPENSATION.GetDecimalValue("LAST_MOD_TIME"));
            fleF110_DEPEXR.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF110_COMPENSATION.GetStringValue("LAST_MOD_USER_ID"));
            fleF110_DEPEXR.set_SetValue("FILLER", !Fixed, fleF110_COMPENSATION.GetStringValue("FILLER"));

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
    //# fleF110_DEPEXM_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:20:21 PM
    //#-----------------------------------------
    private void fleF110_DEPEXM_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF110_DEPEXM.set_SetValue("DOC_NBR", !Fixed, fleF110_COMPENSATION.GetStringValue("DOC_NBR"));
            fleF110_DEPEXM.set_SetValue("EP_NBR", !Fixed, fleF110_COMPENSATION.GetDecimalValue("EP_NBR"));
            fleF110_DEPEXM.set_SetValue("PROCESS_SEQ", !Fixed, fleF110_COMPENSATION.GetDecimalValue("PROCESS_SEQ"));
            fleF110_DEPEXM.set_SetValue("COMP_CODE", !Fixed, fleF110_COMPENSATION.GetStringValue("COMP_CODE"));
            fleF110_DEPEXM.set_SetValue("COMP_TYPE", !Fixed, fleF110_COMPENSATION.GetStringValue("COMP_TYPE"));
            fleF110_DEPEXM.set_SetValue("FACTOR", !Fixed, fleF110_COMPENSATION.GetDecimalValue("FACTOR"));
            fleF110_DEPEXM.set_SetValue("FACTOR_OVERRIDE", !Fixed, fleF110_COMPENSATION.GetStringValue("FACTOR_OVERRIDE"));
            fleF110_DEPEXM.set_SetValue("COMP_UNITS", !Fixed, fleF110_COMPENSATION.GetDecimalValue("COMP_UNITS"));
            fleF110_DEPEXM.set_SetValue("AMT_GROSS", !Fixed, fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS"));
            fleF110_DEPEXM.set_SetValue("AMT_NET", !Fixed, fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
            fleF110_DEPEXM.set_SetValue("EP_NBR_ENTRY", !Fixed, fleF110_COMPENSATION.GetDecimalValue("EP_NBR_ENTRY"));
            fleF110_DEPEXM.set_SetValue("COMPENSATION_STATUS", !Fixed, fleF110_COMPENSATION.GetStringValue("COMPENSATION_STATUS"));
            fleF110_DEPEXM.set_SetValue("LAST_MOD_DATE", !Fixed, fleF110_COMPENSATION.GetDecimalValue("LAST_MOD_DATE"));
            fleF110_DEPEXM.set_SetValue("LAST_MOD_TIME", !Fixed, fleF110_COMPENSATION.GetDecimalValue("LAST_MOD_TIME"));
            fleF110_DEPEXM.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF110_COMPENSATION.GetStringValue("LAST_MOD_USER_ID"));
            fleF110_DEPEXM.set_SetValue("FILLER", !Fixed, fleF110_COMPENSATION.GetStringValue("FILLER"));

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
    //# fleF110_EP_TOT_EXPENSE_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:20:22 PM
    //#-----------------------------------------
    private void fleF110_EP_TOT_EXPENSE_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF110_EP_TOT_EXPENSE.set_SetValue("DOC_NBR", !Fixed, fleF110_COMPENSATION.GetStringValue("DOC_NBR"));
            fleF110_EP_TOT_EXPENSE.set_SetValue("EP_NBR", !Fixed, fleF110_COMPENSATION.GetDecimalValue("EP_NBR"));
            fleF110_EP_TOT_EXPENSE.set_SetValue("PROCESS_SEQ", !Fixed, fleF110_COMPENSATION.GetDecimalValue("PROCESS_SEQ"));
            fleF110_EP_TOT_EXPENSE.set_SetValue("COMP_CODE", !Fixed, fleF110_COMPENSATION.GetStringValue("COMP_CODE"));
            fleF110_EP_TOT_EXPENSE.set_SetValue("COMP_TYPE", !Fixed, fleF110_COMPENSATION.GetStringValue("COMP_TYPE"));
            fleF110_EP_TOT_EXPENSE.set_SetValue("FACTOR", !Fixed, fleF110_COMPENSATION.GetDecimalValue("FACTOR"));
            fleF110_EP_TOT_EXPENSE.set_SetValue("FACTOR_OVERRIDE", !Fixed, fleF110_COMPENSATION.GetStringValue("FACTOR_OVERRIDE"));
            fleF110_EP_TOT_EXPENSE.set_SetValue("COMP_UNITS", !Fixed, fleF110_COMPENSATION.GetDecimalValue("COMP_UNITS"));
            fleF110_EP_TOT_EXPENSE.set_SetValue("AMT_GROSS", !Fixed, fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS"));
            fleF110_EP_TOT_EXPENSE.set_SetValue("AMT_NET", !Fixed, fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
            fleF110_EP_TOT_EXPENSE.set_SetValue("EP_NBR_ENTRY", !Fixed, fleF110_COMPENSATION.GetDecimalValue("EP_NBR_ENTRY"));
            fleF110_EP_TOT_EXPENSE.set_SetValue("COMPENSATION_STATUS", !Fixed, fleF110_COMPENSATION.GetStringValue("COMPENSATION_STATUS"));
            fleF110_EP_TOT_EXPENSE.set_SetValue("LAST_MOD_DATE", !Fixed, fleF110_COMPENSATION.GetDecimalValue("LAST_MOD_DATE"));
            fleF110_EP_TOT_EXPENSE.set_SetValue("LAST_MOD_TIME", !Fixed, fleF110_COMPENSATION.GetDecimalValue("LAST_MOD_TIME"));
            fleF110_EP_TOT_EXPENSE.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF110_COMPENSATION.GetStringValue("LAST_MOD_USER_ID"));
            fleF110_EP_TOT_EXPENSE.set_SetValue("FILLER", !Fixed, fleF110_COMPENSATION.GetStringValue("FILLER"));

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
    //# fleF110_EP_INCEXP_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:20:22 PM
    //#-----------------------------------------
    private void fleF110_EP_INCEXP_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF110_EP_INCEXP.set_SetValue("DOC_NBR", !Fixed, fleF110_COMPENSATION.GetStringValue("DOC_NBR"));
            fleF110_EP_INCEXP.set_SetValue("EP_NBR", !Fixed, fleF110_COMPENSATION.GetDecimalValue("EP_NBR"));
            fleF110_EP_INCEXP.set_SetValue("PROCESS_SEQ", !Fixed, fleF110_COMPENSATION.GetDecimalValue("PROCESS_SEQ"));
            fleF110_EP_INCEXP.set_SetValue("COMP_CODE", !Fixed, fleF110_COMPENSATION.GetStringValue("COMP_CODE"));
            fleF110_EP_INCEXP.set_SetValue("COMP_TYPE", !Fixed, fleF110_COMPENSATION.GetStringValue("COMP_TYPE"));
            fleF110_EP_INCEXP.set_SetValue("FACTOR", !Fixed, fleF110_COMPENSATION.GetDecimalValue("FACTOR"));
            fleF110_EP_INCEXP.set_SetValue("FACTOR_OVERRIDE", !Fixed, fleF110_COMPENSATION.GetStringValue("FACTOR_OVERRIDE"));
            fleF110_EP_INCEXP.set_SetValue("COMP_UNITS", !Fixed, fleF110_COMPENSATION.GetDecimalValue("COMP_UNITS"));
            fleF110_EP_INCEXP.set_SetValue("AMT_GROSS", !Fixed, fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS"));
            fleF110_EP_INCEXP.set_SetValue("AMT_NET", !Fixed, fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
            fleF110_EP_INCEXP.set_SetValue("EP_NBR_ENTRY", !Fixed, fleF110_COMPENSATION.GetDecimalValue("EP_NBR_ENTRY"));
            fleF110_EP_INCEXP.set_SetValue("COMPENSATION_STATUS", !Fixed, fleF110_COMPENSATION.GetStringValue("COMPENSATION_STATUS"));
            fleF110_EP_INCEXP.set_SetValue("LAST_MOD_DATE", !Fixed, fleF110_COMPENSATION.GetDecimalValue("LAST_MOD_DATE"));
            fleF110_EP_INCEXP.set_SetValue("LAST_MOD_TIME", !Fixed, fleF110_COMPENSATION.GetDecimalValue("LAST_MOD_TIME"));
            fleF110_EP_INCEXP.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF110_COMPENSATION.GetStringValue("LAST_MOD_USER_ID"));
            fleF110_EP_INCEXP.set_SetValue("FILLER", !Fixed, fleF110_COMPENSATION.GetStringValue("FILLER"));

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
    //# fleF110_CEIEAR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:20:23 PM
    //#-----------------------------------------
    private void fleF110_CEIEAR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF110_CEIEAR.set_SetValue("DOC_NBR", !Fixed, fleF110_COMPENSATION.GetStringValue("DOC_NBR"));
            fleF110_CEIEAR.set_SetValue("EP_NBR", !Fixed, fleF110_COMPENSATION.GetDecimalValue("EP_NBR"));
            fleF110_CEIEAR.set_SetValue("PROCESS_SEQ", !Fixed, fleF110_COMPENSATION.GetDecimalValue("PROCESS_SEQ"));
            fleF110_CEIEAR.set_SetValue("COMP_CODE", !Fixed, fleF110_COMPENSATION.GetStringValue("COMP_CODE"));
            fleF110_CEIEAR.set_SetValue("COMP_TYPE", !Fixed, fleF110_COMPENSATION.GetStringValue("COMP_TYPE"));
            fleF110_CEIEAR.set_SetValue("FACTOR", !Fixed, fleF110_COMPENSATION.GetDecimalValue("FACTOR"));
            fleF110_CEIEAR.set_SetValue("FACTOR_OVERRIDE", !Fixed, fleF110_COMPENSATION.GetStringValue("FACTOR_OVERRIDE"));
            fleF110_CEIEAR.set_SetValue("COMP_UNITS", !Fixed, fleF110_COMPENSATION.GetDecimalValue("COMP_UNITS"));
            fleF110_CEIEAR.set_SetValue("AMT_GROSS", !Fixed, fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS"));
            fleF110_CEIEAR.set_SetValue("AMT_NET", !Fixed, fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
            fleF110_CEIEAR.set_SetValue("EP_NBR_ENTRY", !Fixed, fleF110_COMPENSATION.GetDecimalValue("EP_NBR_ENTRY"));
            fleF110_CEIEAR.set_SetValue("COMPENSATION_STATUS", !Fixed, fleF110_COMPENSATION.GetStringValue("COMPENSATION_STATUS"));
            fleF110_CEIEAR.set_SetValue("LAST_MOD_DATE", !Fixed, fleF110_COMPENSATION.GetDecimalValue("LAST_MOD_DATE"));
            fleF110_CEIEAR.set_SetValue("LAST_MOD_TIME", !Fixed, fleF110_COMPENSATION.GetDecimalValue("LAST_MOD_TIME"));
            fleF110_CEIEAR.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF110_COMPENSATION.GetStringValue("LAST_MOD_USER_ID"));
            fleF110_CEIEAR.set_SetValue("FILLER", !Fixed, fleF110_COMPENSATION.GetStringValue("FILLER"));

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
    //# fleF110_CEIEXP_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:20:23 PM
    //#-----------------------------------------
    private void fleF110_CEIEXP_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF110_CEIEXP.set_SetValue("DOC_NBR", !Fixed, fleF110_COMPENSATION.GetStringValue("DOC_NBR"));
            fleF110_CEIEXP.set_SetValue("EP_NBR", !Fixed, fleF110_COMPENSATION.GetDecimalValue("EP_NBR"));
            fleF110_CEIEXP.set_SetValue("PROCESS_SEQ", !Fixed, fleF110_COMPENSATION.GetDecimalValue("PROCESS_SEQ"));
            fleF110_CEIEXP.set_SetValue("COMP_CODE", !Fixed, fleF110_COMPENSATION.GetStringValue("COMP_CODE"));
            fleF110_CEIEXP.set_SetValue("COMP_TYPE", !Fixed, fleF110_COMPENSATION.GetStringValue("COMP_TYPE"));
            fleF110_CEIEXP.set_SetValue("FACTOR", !Fixed, fleF110_COMPENSATION.GetDecimalValue("FACTOR"));
            fleF110_CEIEXP.set_SetValue("FACTOR_OVERRIDE", !Fixed, fleF110_COMPENSATION.GetStringValue("FACTOR_OVERRIDE"));
            fleF110_CEIEXP.set_SetValue("COMP_UNITS", !Fixed, fleF110_COMPENSATION.GetDecimalValue("COMP_UNITS"));
            fleF110_CEIEXP.set_SetValue("AMT_GROSS", !Fixed, fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS"));
            fleF110_CEIEXP.set_SetValue("AMT_NET", !Fixed, fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
            fleF110_CEIEXP.set_SetValue("EP_NBR_ENTRY", !Fixed, fleF110_COMPENSATION.GetDecimalValue("EP_NBR_ENTRY"));
            fleF110_CEIEXP.set_SetValue("COMPENSATION_STATUS", !Fixed, fleF110_COMPENSATION.GetStringValue("COMPENSATION_STATUS"));
            fleF110_CEIEXP.set_SetValue("LAST_MOD_DATE", !Fixed, fleF110_COMPENSATION.GetDecimalValue("LAST_MOD_DATE"));
            fleF110_CEIEXP.set_SetValue("LAST_MOD_TIME", !Fixed, fleF110_COMPENSATION.GetDecimalValue("LAST_MOD_TIME"));
            fleF110_CEIEXP.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF110_COMPENSATION.GetStringValue("LAST_MOD_USER_ID"));
            fleF110_CEIEXP.set_SetValue("FILLER", !Fixed, fleF110_COMPENSATION.GetStringValue("FILLER"));

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
    //# fleF110_YTDEAR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:20:24 PM
    //#-----------------------------------------
    private void fleF110_YTDEAR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF110_YTDEAR.set_SetValue("DOC_NBR", !Fixed, fleF110_COMPENSATION.GetStringValue("DOC_NBR"));
            fleF110_YTDEAR.set_SetValue("EP_NBR", !Fixed, fleF110_COMPENSATION.GetDecimalValue("EP_NBR"));
            fleF110_YTDEAR.set_SetValue("PROCESS_SEQ", !Fixed, fleF110_COMPENSATION.GetDecimalValue("PROCESS_SEQ"));
            fleF110_YTDEAR.set_SetValue("COMP_CODE", !Fixed, fleF110_COMPENSATION.GetStringValue("COMP_CODE"));
            fleF110_YTDEAR.set_SetValue("COMP_TYPE", !Fixed, fleF110_COMPENSATION.GetStringValue("COMP_TYPE"));
            fleF110_YTDEAR.set_SetValue("FACTOR", !Fixed, fleF110_COMPENSATION.GetDecimalValue("FACTOR"));
            fleF110_YTDEAR.set_SetValue("FACTOR_OVERRIDE", !Fixed, fleF110_COMPENSATION.GetStringValue("FACTOR_OVERRIDE"));
            fleF110_YTDEAR.set_SetValue("COMP_UNITS", !Fixed, fleF110_COMPENSATION.GetDecimalValue("COMP_UNITS"));
            fleF110_YTDEAR.set_SetValue("AMT_GROSS", !Fixed, fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS"));
            fleF110_YTDEAR.set_SetValue("AMT_NET", !Fixed, fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
            fleF110_YTDEAR.set_SetValue("EP_NBR_ENTRY", !Fixed, fleF110_COMPENSATION.GetDecimalValue("EP_NBR_ENTRY"));
            fleF110_YTDEAR.set_SetValue("COMPENSATION_STATUS", !Fixed, fleF110_COMPENSATION.GetStringValue("COMPENSATION_STATUS"));
            fleF110_YTDEAR.set_SetValue("LAST_MOD_DATE", !Fixed, fleF110_COMPENSATION.GetDecimalValue("LAST_MOD_DATE"));
            fleF110_YTDEAR.set_SetValue("LAST_MOD_TIME", !Fixed, fleF110_COMPENSATION.GetDecimalValue("LAST_MOD_TIME"));
            fleF110_YTDEAR.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF110_COMPENSATION.GetStringValue("LAST_MOD_USER_ID"));
            fleF110_YTDEAR.set_SetValue("FILLER", !Fixed, fleF110_COMPENSATION.GetStringValue("FILLER"));

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


    #region "Transaction Management Procedures(U115B_U115_RUN_1_17)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:20:09 PM

    //#-----------------------------------------
    //# InitializeTransactionObjects Procedure.
    //#-----------------------------------------

    protected override void InitializeTransactionObjects()
    {

        try
        {
            m_cnnTRANS_UPDATE = new SqlConnection(Common.GetSqlConnectionString());
            m_cnnTRANS_UPDATE.Open();
            m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
            m_cnnQUERY = new SqlConnection(Common.GetSqlConnectionString());


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
        fleF112_PYCDCEILINGS.Transaction = m_trnTRANS_UPDATE;
        fleF116_GROUP.Transaction = m_trnTRANS_UPDATE;
        fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;
        fleF119_TOTEXP.Transaction = m_trnTRANS_UPDATE;
        fleBRADU115B.Transaction = m_trnTRANS_UPDATE;
        fleF110_INCOME.Transaction = m_trnTRANS_UPDATE;
        fleF110_EP_TOT_INCOME.Transaction = m_trnTRANS_UPDATE;
        fleF110_RMAEXR.Transaction = m_trnTRANS_UPDATE;
        fleF110_RMAEXM.Transaction = m_trnTRANS_UPDATE;
        fleF110_GST.Transaction = m_trnTRANS_UPDATE;
        fleF110_HOLDBACK.Transaction = m_trnTRANS_UPDATE;
        fleF110_DEPEXR.Transaction = m_trnTRANS_UPDATE;
        fleF110_DEPEXM.Transaction = m_trnTRANS_UPDATE;
        fleF110_EP_TOT_EXPENSE.Transaction = m_trnTRANS_UPDATE;
        fleF110_EP_INCEXP.Transaction = m_trnTRANS_UPDATE;
        fleF110_CEIEAR.Transaction = m_trnTRANS_UPDATE;
        fleF110_CEIEXP.Transaction = m_trnTRANS_UPDATE;
        fleF110_YTDEAR.Transaction = m_trnTRANS_UPDATE;
        fleDEBUGU115B_AT_COMP_CODE.Transaction = m_trnTRANS_UPDATE;
        fleDEBUGU115B_AT_DOC_NBR.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U115B_U115_RUN_1_17)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:20:09 PM

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
            fleF112_PYCDCEILINGS.Dispose();
            fleF116_GROUP.Dispose();
            fleF190_COMP_CODES.Dispose();
            fleF119_TOTEXP.Dispose();
            fleBRADU115B.Dispose();
            fleF110_INCOME.Dispose();
            fleF110_EP_TOT_INCOME.Dispose();
            fleF110_RMAEXR.Dispose();
            fleF110_RMAEXM.Dispose();
            fleF110_GST.Dispose();
            fleF110_HOLDBACK.Dispose();
            fleF110_DEPEXR.Dispose();
            fleF110_DEPEXM.Dispose();
            fleF110_EP_TOT_EXPENSE.Dispose();
            fleF110_EP_INCEXP.Dispose();
            fleF110_CEIEAR.Dispose();
            fleF110_CEIEXP.Dispose();
            fleF110_YTDEAR.Dispose();
            fleDEBUGU115B_AT_COMP_CODE.Dispose();
            fleDEBUGU115B_AT_DOC_NBR.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U115B_U115_RUN_1_17)"


    public void Run()
    {

        try
        {
            Request("U115_RUN_1_17");

            while (fleCONSTANTS_MSTR_REC_6.QTPForMissing())
            {
                // --> GET CONSTANTS_MSTR_REC_6 <--

                fleCONSTANTS_MSTR_REC_6.GetData();
                // --> End GET CONSTANTS_MSTR_REC_6 <--

                while (fleF110_COMPENSATION.QTPForMissing("1"))
                {
                    // --> GET F110_COMPENSATION <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF110_COMPENSATION.ElementOwner("EP_NBR")).Append(" = ");
                    m_strWhere.Append((fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR")));

                    m_strOrderBy = new StringBuilder(" ORDER BY ");
                    m_strOrderBy.Append(fleF110_COMPENSATION.ElementOwner("EP_NBR"));
                    m_strOrderBy.Append(", ").Append(fleF110_COMPENSATION.ElementOwner("DOC_NBR"));

                    fleF110_COMPENSATION.GetData(m_strWhere.ToString(), m_strOrderBy.ToString());
                    // --> End GET F110_COMPENSATION <--

                    while (fleF020_DOCTOR_MSTR.QTPForMissing("2"))
                    {
                        // --> GET F020_DOCTOR_MSTR <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleF110_COMPENSATION.GetStringValue("DOC_NBR")));

                        fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString());
                        // --> End GET F020_DOCTOR_MSTR <--

                        while (fleF112_PYCDCEILINGS.QTPForMissing("3"))
                        {
                            // --> GET F112_PYCDCEILINGS <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleF112_PYCDCEILINGS.ElementOwner("EP_NBR")).Append(" = ");
                            m_strWhere.Append((fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR")));
                            m_strWhere.Append(" And ").Append(fleF112_PYCDCEILINGS.ElementOwner("DOC_NBR")).Append(" = ");
                            m_strWhere.Append(Common.StringToField(fleF110_COMPENSATION.GetStringValue("DOC_NBR")));

                            m_strOrderBy = new StringBuilder(" ORDER BY ");
                            m_strOrderBy.Append(fleF112_PYCDCEILINGS.ElementOwner("EP_NBR"));
                            m_strOrderBy.Append(", ").Append(fleF112_PYCDCEILINGS.ElementOwner("DOC_NBR"));

                            fleF112_PYCDCEILINGS.GetData(m_strWhere.ToString(), m_strOrderBy.ToString());
                            // --> End GET F112_PYCDCEILINGS <--

                            while (fleF116_GROUP.QTPForMissing("4"))
                            {
                                // --> GET F116_GROUP <--
                                m_strWhere = new StringBuilder(" WHERE ");
                                m_strWhere.Append(" ").Append(fleF116_GROUP.ElementOwner("DOC_NBR")).Append(" = ");
                                m_strWhere.Append(Common.StringToField("000"));
                                m_strWhere.Append(" And ").Append(fleF116_GROUP.ElementOwner("DEPT_EXPENSE_CALC_CODE")).Append(" = ");
                                m_strWhere.Append(Common.StringToField(("FLAT+3_TITHE_LEVELS")));
                                m_strWhere.Append(" And ").Append(fleF116_GROUP.ElementOwner("DEPT_NBR")).Append(" = ");
                                m_strWhere.Append((fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT")));
                                m_strWhere.Append(" And ").Append(fleF116_GROUP.ElementOwner("DOC_AFP_PAYM_GROUP")).Append(" = ");
                                m_strWhere.Append(Common.StringToField(fleF020_DOCTOR_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP")));
                                m_strWhere.Append(" And ").Append(fleF116_GROUP.ElementOwner("COMP_CODE")).Append(" = ");
                                m_strWhere.Append(Common.StringToField(fleF110_COMPENSATION.GetStringValue("COMP_CODE")));

                                fleF116_GROUP.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                // --> End GET F116_GROUP <--

                                while (fleF190_COMP_CODES.QTPForMissing("5"))
                                {
                                    // --> GET F190_COMP_CODES <--
                                    m_strWhere = new StringBuilder(" WHERE ");
                                    m_strWhere.Append(" ").Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
                                    m_strWhere.Append(Common.StringToField(fleF110_COMPENSATION.GetStringValue("COMP_CODE")));

                                    fleF190_COMP_CODES.GetData(m_strWhere.ToString());
                                    // --> End GET F190_COMP_CODES <--

                                    while (fleF119_TOTEXP.QTPForMissing("6"))
                                    {
                                        // --> GET F119_TOTEXP <--
                                        m_strWhere = new StringBuilder(" WHERE ");
                                        m_strWhere.Append(" ").Append(fleF119_TOTEXP.ElementOwner("DOC_NBR")).Append(" = ");
                                        m_strWhere.Append(Common.StringToField(fleF110_COMPENSATION.GetStringValue("DOC_NBR")));
                                        m_strWhere.Append(" And ").Append(fleF119_TOTEXP.ElementOwner("COMP_CODE")).Append(" = ");
                                        m_strWhere.Append(Common.StringToField("TOTEXP"));
                                        m_strWhere.Append(" And ").Append(fleF119_TOTEXP.ElementOwner("REC_TYPE")).Append(" = ");
                                        m_strWhere.Append(Common.StringToField("A"));
                                        m_strWhere.Append(" And ").Append(fleF119_TOTEXP.ElementOwner("DOC_OHIP_NBR")).Append(" = ");
                                        m_strWhere.Append((fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR")));

                                        fleF119_TOTEXP.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                        // --> End GET F119_TOTEXP <--


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

            }

            while (Sort(fleCONSTANTS_MSTR_REC_6, fleF110_COMPENSATION, fleF020_DOCTOR_MSTR, fleF112_PYCDCEILINGS, fleF116_GROUP, fleF190_COMP_CODES, fleF119_TOTEXP))
            {
                if (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("COMP_TYPE")) == "E" & QDesign.NULL(fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE")) == "O")
                {
                    TOT_DEPT_EXPENSE_OTHER.Value = TOT_DEPT_EXPENSE_OTHER.Value + X_DEPT_EXPENSE_OTHER.Value;
                }
                if (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("COMP_TYPE")) == "I" & QDesign.NULL(fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE")) == "R")
                {
                    TOT_INCOME_GROSS_REG.Value = TOT_INCOME_GROSS_REG.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS");
                }
                else
                {
                    TOT_INCOME_GROSS_REG.Value = TOT_INCOME_GROSS_REG.Value;
                }
                if (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("COMP_TYPE")) == "I" & QDesign.NULL(fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE")) == "M")
                {
                    TOT_INCOME_GROSS_MISC.Value = TOT_INCOME_GROSS_MISC.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS");
                }
                else
                {
                    TOT_INCOME_GROSS_MISC.Value = TOT_INCOME_GROSS_MISC.Value;
                }
                if (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("COMP_TYPE")) == "I" & QDesign.NULL(fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE")) == "O")
                {
                    TOT_INCOME_GROSS_OTHER.Value = TOT_INCOME_GROSS_OTHER.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS");
                }
                else
                {
                    TOT_INCOME_GROSS_OTHER.Value = TOT_INCOME_GROSS_OTHER.Value;
                }
                if (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("COMP_TYPE")) == "I" & QDesign.NULL(fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE")) == "R")
                {
                    TOT_INCOME_NET_REG.Value = TOT_INCOME_NET_REG.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET");
                }
                else
                {
                    TOT_INCOME_NET_REG.Value = TOT_INCOME_NET_REG.Value;
                }
                if (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("COMP_TYPE")) == "I" & QDesign.NULL(fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE")) == "M")
                {
                    TOT_INCOME_NET_MISC.Value = TOT_INCOME_NET_MISC.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET");
                }
                else
                {
                    TOT_INCOME_NET_MISC.Value = TOT_INCOME_NET_MISC.Value;
                }
                if (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("COMP_TYPE")) == "I" & QDesign.NULL(fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE")) == "O")
                {
                    TOT_INCOME_NET_OTHER.Value = TOT_INCOME_NET_OTHER.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET");
                }
                else
                {
                    TOT_INCOME_NET_OTHER.Value = TOT_INCOME_NET_OTHER.Value;
                }
                if (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE")) == "R")
                {
                    TOT_DEPT_EXPENSE_REG.Value = TOT_DEPT_EXPENSE_REG.Value + X_AMT_DEPT_EXPENSE_FINAL.Value;
                }
                else
                {
                    TOT_DEPT_EXPENSE_REG.Value = TOT_DEPT_EXPENSE_REG.Value;
                }
                if (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE")) == "M")
                {
                    TOT_DEPT_EXPENSE_MISC.Value = TOT_DEPT_EXPENSE_MISC.Value + X_AMT_DEPT_EXPENSE_FINAL.Value;
                }
                else
                {
                    TOT_DEPT_EXPENSE_MISC.Value = TOT_DEPT_EXPENSE_MISC.Value;
                }
                if (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE")) == "R")
                {
                    TOT_RMA_EXPENSE_PLUS_GST_REG.Value = TOT_RMA_EXPENSE_PLUS_GST_REG.Value + X_AMT_RMA_EXPENSE_PLUSGST_FINAL.Value;
                }
                else
                {
                    TOT_RMA_EXPENSE_PLUS_GST_REG.Value = TOT_RMA_EXPENSE_PLUS_GST_REG.Value;
                }
                if (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE")) == "M")
                {
                    TOT_RMA_EXPENSE_PLUS_GST_MISC.Value = TOT_RMA_EXPENSE_PLUS_GST_MISC.Value + X_AMT_RMA_EXPENSE_PLUSGST_FINAL.Value;
                }
                else
                {
                    TOT_RMA_EXPENSE_PLUS_GST_MISC.Value = TOT_RMA_EXPENSE_PLUS_GST_MISC.Value;
                }
                if (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE")) == "R")
                {
                    TOT_RMA_EXPENSE_ONLY_REG.Value = TOT_RMA_EXPENSE_ONLY_REG.Value + X_AMT_RMA_EXPENSE_FINAL.Value;
                }
                else
                {
                    TOT_RMA_EXPENSE_ONLY_REG.Value = TOT_RMA_EXPENSE_ONLY_REG.Value;
                }
                if (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE")) == "M")
                {
                    TOT_RMA_EXPENSE_ONLY_MISC.Value = TOT_RMA_EXPENSE_ONLY_MISC.Value + X_AMT_RMA_EXPENSE_FINAL.Value;
                }
                else
                {
                    TOT_RMA_EXPENSE_ONLY_MISC.Value = TOT_RMA_EXPENSE_ONLY_MISC.Value;
                }
                if (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE")) == "R")
                {
                    TOT_GST_ONLY_REG.Value = TOT_GST_ONLY_REG.Value + X_AMT_GST_ONLY.Value;
                }
                else
                {
                    TOT_GST_ONLY_REG.Value = TOT_GST_ONLY_REG.Value;
                }
                if (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE")) == "M")
                {
                    TOT_GST_ONLY_MISC.Value = TOT_GST_ONLY_MISC.Value + X_AMT_GST_ONLY.Value;
                }
                else
                {
                    TOT_GST_ONLY_MISC.Value = TOT_GST_ONLY_MISC.Value;
                }
                if (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE")) == "R")
                {
                    TOT_HOLDBACK_ONLY_REG.Value = TOT_HOLDBACK_ONLY_REG.Value + X_AMT_HOLDBACK_FINAL.Value;
                }
                else
                {
                    TOT_HOLDBACK_ONLY_REG.Value = TOT_HOLDBACK_ONLY_REG.Value;
                }
                if (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE")) == "M")
                {
                    TOT_HOLDBACK_ONLY_MISC.Value = TOT_HOLDBACK_ONLY_MISC.Value + X_AMT_HOLDBACK_FINAL.Value;
                }
                else
                {
                    TOT_HOLDBACK_ONLY_MISC.Value = TOT_HOLDBACK_ONLY_MISC.Value;
                }
                if (QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_TYPE")) == "E" & (QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == "REVHBK" | QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == "REVCLA"))
                {
                    TOT_REVHBK.Value = TOT_REVHBK.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET");
                }
                else
                {
                    TOT_REVHBK.Value = TOT_REVHBK.Value;
                }
                if (QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_TYPE")) == "M")
                {
                    AMT_MANPAY.Value = AMT_MANPAY.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET");
                }
                else
                {
                    AMT_MANPAY.Value = AMT_MANPAY.Value;
                }
                if (QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == "GTYPEA")
                {
                    AMT_YTDGUA.Value = AMT_YTDGUA.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET");
                }
                else
                {
                    AMT_YTDGUA.Value = AMT_YTDGUA.Value;
                }
                if (QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == "GTYPEB")
                {
                    AMT_YTDGUB.Value = AMT_YTDGUB.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET");
                }
                else
                {
                    AMT_YTDGUB.Value = AMT_YTDGUB.Value;
                }
                if (QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == "GTYPEC")
                {
                    AMT_YTDGUC.Value = AMT_YTDGUC.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET");
                }
                else
                {
                    AMT_YTDGUC.Value = AMT_YTDGUC.Value;
                }
                AMT_INCOME_MINUS_EXPENSES_G.Value = TOT_INCOME_GROSS.Value - FINAL_ALL_EXPENSES_PLUS_DEPT_EXPENSE_OTHER.Value;
                DOC_YTDEAR_PLUS_AMT_MANPAY.Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDEAR") + AMT_MANPAY.Value;

                SubFile(ref m_trnTRANS_UPDATE, ref fleBRADU115B, fleF110_COMPENSATION.At("DOC_NBR") || fleF110_COMPENSATION.At("EP_NBR") || fleF110_COMPENSATION.At("COMP_CODE"), SubFileType.Keep, X_DOC_YTDINC_G, fleF020_DOCTOR_MSTR, "DOC_YTDINC_G", TOT_INCOME_GROSS, X_DOC_YTDINC_N, "DOC_YTDINC",
                TOT_INCOME_NET, TOT_REVHBK, TOT_DEPT_EXPENSE_OTHER);


                fleF110_INCOME.set_SetValue("EP_NBR", fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR"));


                fleF110_INCOME.set_SetValue("EP_NBR_ENTRY", fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR"));


                fleF110_INCOME.set_SetValue("COMP_CODE", "YTDINC");


                fleF110_INCOME.set_SetValue("COMP_TYPE", QDesign.NULL(YTDINC_TYPE.Value));


                fleF110_INCOME.set_SetValue("PROCESS_SEQ", YTDINC_SEQ.Value);


                fleF110_INCOME.set_SetValue("FACTOR", 0);


                fleF110_INCOME.set_SetValue("FACTOR_OVERRIDE", " ");


                fleF110_INCOME.set_SetValue("COMP_UNITS", 0);


                fleF110_INCOME.set_SetValue("AMT_GROSS", X_DOC_YTDINC_G.Value);


                fleF110_INCOME.set_SetValue("AMT_NET", X_DOC_YTDINC_N.Value);


                fleF110_INCOME.set_SetValue("COMPENSATION_STATUS", " ");


                fleF110_INCOME.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));


                fleF110_INCOME.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);


                fleF110_INCOME.set_SetValue("LAST_MOD_USER_ID", "U115B gen`d");

                fleF110_INCOME.OutPut(OutPutType.Add, fleF110_COMPENSATION.At("DOC_NBR"), null);



                fleF110_EP_TOT_INCOME.set_SetValue("EP_NBR", fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR"));


                fleF110_EP_TOT_INCOME.set_SetValue("EP_NBR_ENTRY", fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR"));


                fleF110_EP_TOT_INCOME.set_SetValue("COMP_CODE", "TOTINC");


                fleF110_EP_TOT_INCOME.set_SetValue("COMP_TYPE", QDesign.NULL(TOTINC_TYPE.Value));


                fleF110_EP_TOT_INCOME.set_SetValue("PROCESS_SEQ", TOTINC_SEQ.Value);


                fleF110_EP_TOT_INCOME.set_SetValue("FACTOR", 0);


                fleF110_EP_TOT_INCOME.set_SetValue("FACTOR_OVERRIDE", " ");


                fleF110_EP_TOT_INCOME.set_SetValue("COMP_UNITS", 0);


                fleF110_EP_TOT_INCOME.set_SetValue("AMT_GROSS", TOT_INCOME_GROSS.Value);


                fleF110_EP_TOT_INCOME.set_SetValue("AMT_NET", TOT_INCOME_NET.Value);


                fleF110_EP_TOT_INCOME.set_SetValue("COMPENSATION_STATUS", " ");


                fleF110_EP_TOT_INCOME.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));


                fleF110_EP_TOT_INCOME.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);


                fleF110_EP_TOT_INCOME.set_SetValue("LAST_MOD_USER_ID", "U115B gen`d");

                fleF110_EP_TOT_INCOME.OutPut(OutPutType.Add, fleF110_COMPENSATION.At("DOC_NBR"), null);



                fleF110_RMAEXR.set_SetValue("EP_NBR", fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR"));


                fleF110_RMAEXR.set_SetValue("EP_NBR_ENTRY", fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR"));


                fleF110_RMAEXR.set_SetValue("COMP_CODE", "RMAEXR");


                fleF110_RMAEXR.set_SetValue("COMP_TYPE", QDesign.NULL(RMAEXR_TYPE.Value));


                fleF110_RMAEXR.set_SetValue("PROCESS_SEQ", RMAEXR_SEQ.Value);


                fleF110_RMAEXR.set_SetValue("FACTOR", 0);


                fleF110_RMAEXR.set_SetValue("FACTOR_OVERRIDE", " ");


                fleF110_RMAEXR.set_SetValue("COMP_UNITS", 0);


                fleF110_RMAEXR.set_SetValue("AMT_GROSS", 0);


                fleF110_RMAEXR.set_SetValue("AMT_NET", TOT_RMA_EXPENSE_ONLY_REG.Value);


                fleF110_RMAEXR.set_SetValue("COMPENSATION_STATUS", " ");


                fleF110_RMAEXR.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));


                fleF110_RMAEXR.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);


                fleF110_RMAEXR.set_SetValue("LAST_MOD_USER_ID", "U115B gen`d");

                fleF110_RMAEXR.OutPut(OutPutType.Add, fleF110_COMPENSATION.At("DOC_NBR"), null);



                fleF110_RMAEXM.set_SetValue("EP_NBR", fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR"));


                fleF110_RMAEXM.set_SetValue("EP_NBR_ENTRY", fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR"));


                fleF110_RMAEXM.set_SetValue("COMP_CODE", "RMAEXM");


                fleF110_RMAEXM.set_SetValue("COMP_TYPE", QDesign.NULL(RMAEXM_TYPE.Value));


                fleF110_RMAEXM.set_SetValue("PROCESS_SEQ", RMAEXM_SEQ.Value);


                fleF110_RMAEXM.set_SetValue("FACTOR", 0);


                fleF110_RMAEXM.set_SetValue("FACTOR_OVERRIDE", " ");


                fleF110_RMAEXM.set_SetValue("COMP_UNITS", 0);


                fleF110_RMAEXM.set_SetValue("AMT_GROSS", 0);


                fleF110_RMAEXM.set_SetValue("AMT_NET", TOT_RMA_EXPENSE_ONLY_MISC.Value);


                fleF110_RMAEXM.set_SetValue("COMPENSATION_STATUS", " ");


                fleF110_RMAEXM.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));


                fleF110_RMAEXM.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);


                fleF110_RMAEXM.set_SetValue("LAST_MOD_USER_ID", "U115B gen`d");

                fleF110_RMAEXM.OutPut(OutPutType.Add, fleF110_COMPENSATION.At("DOC_NBR"), QDesign.NULL(TOT_RMA_EXPENSE_ONLY_MISC.Value) != 0);



                fleF110_GST.set_SetValue("EP_NBR", fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR"));


                fleF110_GST.set_SetValue("EP_NBR_ENTRY", fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR"));


                fleF110_GST.set_SetValue("COMP_CODE", "GST");


                fleF110_GST.set_SetValue("COMP_TYPE", QDesign.NULL(GST_TYPE.Value));


                fleF110_GST.set_SetValue("PROCESS_SEQ", GST_SEQ.Value);


                fleF110_GST.set_SetValue("FACTOR", 0);


                fleF110_GST.set_SetValue("FACTOR_OVERRIDE", " ");


                fleF110_GST.set_SetValue("COMP_UNITS", 0);


                fleF110_GST.set_SetValue("AMT_GROSS", 0);


                fleF110_GST.set_SetValue("AMT_NET", TOT_GST_ONLY.Value);


                fleF110_GST.set_SetValue("COMPENSATION_STATUS", " ");


                fleF110_GST.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));


                fleF110_GST.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);


                fleF110_GST.set_SetValue("LAST_MOD_USER_ID", "U115B gen`d");

                fleF110_GST.OutPut(OutPutType.Add, fleF110_COMPENSATION.At("DOC_NBR"), null);



                fleF110_HOLDBACK.set_SetValue("EP_NBR", fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR"));


                fleF110_HOLDBACK.set_SetValue("EP_NBR_ENTRY", fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR"));


                fleF110_HOLDBACK.set_SetValue("COMP_CODE", "HOLDBK");


                fleF110_HOLDBACK.set_SetValue("COMP_TYPE", QDesign.NULL(HOLDBACK_TYPE.Value));


                fleF110_HOLDBACK.set_SetValue("PROCESS_SEQ", HOLDBACK_SEQ.Value);


                fleF110_HOLDBACK.set_SetValue("FACTOR", 0);


                fleF110_HOLDBACK.set_SetValue("FACTOR_OVERRIDE", " ");


                fleF110_HOLDBACK.set_SetValue("COMP_UNITS", 0);


                fleF110_HOLDBACK.set_SetValue("AMT_GROSS", 0);


                fleF110_HOLDBACK.set_SetValue("AMT_NET", TOT_HOLDBACK_ONLY.Value);


                fleF110_HOLDBACK.set_SetValue("COMPENSATION_STATUS", " ");


                fleF110_HOLDBACK.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));


                fleF110_HOLDBACK.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);


                fleF110_HOLDBACK.set_SetValue("LAST_MOD_USER_ID", "U115B gen`d");

                fleF110_HOLDBACK.OutPut(OutPutType.Add, fleF110_COMPENSATION.At("DOC_NBR"), QDesign.NULL(TOT_HOLDBACK_ONLY.Value) != 0);



                fleF110_DEPEXR.set_SetValue("EP_NBR", fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR"));


                fleF110_DEPEXR.set_SetValue("EP_NBR_ENTRY", fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR"));


                fleF110_DEPEXR.set_SetValue("COMP_CODE", "DEPEXR");


                fleF110_DEPEXR.set_SetValue("COMP_TYPE", QDesign.NULL(DEPEXR_TYPE.Value));


                fleF110_DEPEXR.set_SetValue("PROCESS_SEQ", DEPEXR_SEQ.Value);


                fleF110_DEPEXR.set_SetValue("FACTOR", 0);


                fleF110_DEPEXR.set_SetValue("FACTOR_OVERRIDE", " ");


                fleF110_DEPEXR.set_SetValue("COMP_UNITS", 0);


                fleF110_DEPEXR.set_SetValue("AMT_GROSS", 0);


                fleF110_DEPEXR.set_SetValue("AMT_NET", TOT_DEPT_EXPENSE_REG.Value);


                fleF110_DEPEXR.set_SetValue("COMPENSATION_STATUS", " ");


                fleF110_DEPEXR.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));


                fleF110_DEPEXR.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);


                fleF110_DEPEXR.set_SetValue("LAST_MOD_USER_ID", "U115B gen`d");

                fleF110_DEPEXR.OutPut(OutPutType.Add, fleF110_COMPENSATION.At("DOC_NBR"), QDesign.NULL(TOT_DEPT_EXPENSE_REG.Value) != 0);



                fleF110_DEPEXM.set_SetValue("EP_NBR", fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR"));


                fleF110_DEPEXM.set_SetValue("EP_NBR_ENTRY", fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR"));


                fleF110_DEPEXM.set_SetValue("COMP_CODE", "DEPEXM");


                fleF110_DEPEXM.set_SetValue("COMP_TYPE", QDesign.NULL(DEPEXM_TYPE.Value));


                fleF110_DEPEXM.set_SetValue("PROCESS_SEQ", DEPEXM_SEQ.Value);


                fleF110_DEPEXM.set_SetValue("FACTOR", 0);


                fleF110_DEPEXM.set_SetValue("FACTOR_OVERRIDE", " ");


                fleF110_DEPEXM.set_SetValue("COMP_UNITS", 0);


                fleF110_DEPEXM.set_SetValue("AMT_GROSS", 0);


                fleF110_DEPEXM.set_SetValue("AMT_NET", TOT_DEPT_EXPENSE_MISC.Value);


                fleF110_DEPEXM.set_SetValue("COMPENSATION_STATUS", " ");


                fleF110_DEPEXM.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));


                fleF110_DEPEXM.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);


                fleF110_DEPEXM.set_SetValue("LAST_MOD_USER_ID", "U115B gen`d");

                fleF110_DEPEXM.OutPut(OutPutType.Add, fleF110_COMPENSATION.At("DOC_NBR"), QDesign.NULL(TOT_DEPT_EXPENSE_MISC.Value) != 0);



                fleF110_EP_TOT_EXPENSE.set_SetValue("EP_NBR", fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR"));


                fleF110_EP_TOT_EXPENSE.set_SetValue("EP_NBR_ENTRY", fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR"));


                fleF110_EP_TOT_EXPENSE.set_SetValue("COMP_CODE", "TOTEXP");


                fleF110_EP_TOT_EXPENSE.set_SetValue("COMP_TYPE", QDesign.NULL(TOTEXP_TYPE.Value));


                fleF110_EP_TOT_EXPENSE.set_SetValue("PROCESS_SEQ", TOTEXP_SEQ.Value);


                fleF110_EP_TOT_EXPENSE.set_SetValue("FACTOR", 0);


                fleF110_EP_TOT_EXPENSE.set_SetValue("FACTOR_OVERRIDE", " ");


                fleF110_EP_TOT_EXPENSE.set_SetValue("COMP_UNITS", 0);


                fleF110_EP_TOT_EXPENSE.set_SetValue("AMT_GROSS", 0);


                fleF110_EP_TOT_EXPENSE.set_SetValue("AMT_NET", FINAL_ALL_EXPENSES_PLUS_DEPT_EXPENSE_OTHER.Value);


                fleF110_EP_TOT_EXPENSE.set_SetValue("COMPENSATION_STATUS", " ");


                fleF110_EP_TOT_EXPENSE.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));


                fleF110_EP_TOT_EXPENSE.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);


                fleF110_EP_TOT_EXPENSE.set_SetValue("LAST_MOD_USER_ID", "U115B gen`d");

                fleF110_EP_TOT_EXPENSE.OutPut(OutPutType.Add, fleF110_COMPENSATION.At("DOC_NBR"), null);



                fleF110_EP_INCEXP.set_SetValue("EP_NBR", fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR"));


                fleF110_EP_INCEXP.set_SetValue("EP_NBR_ENTRY", fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR"));


                fleF110_EP_INCEXP.set_SetValue("COMP_CODE", "INCEXP");


                fleF110_EP_INCEXP.set_SetValue("COMP_TYPE", QDesign.NULL(INCEXP_TYPE.Value));


                fleF110_EP_INCEXP.set_SetValue("PROCESS_SEQ", INCEXP_SEQ.Value);


                fleF110_EP_INCEXP.set_SetValue("FACTOR", 0);


                fleF110_EP_INCEXP.set_SetValue("FACTOR_OVERRIDE", " ");


                fleF110_EP_INCEXP.set_SetValue("COMP_UNITS", 0);


                fleF110_EP_INCEXP.set_SetValue("AMT_GROSS", 0);


                fleF110_EP_INCEXP.set_SetValue("AMT_NET", AMT_INCOME_MINUS_EXPENSES_G.Value);


                fleF110_EP_INCEXP.set_SetValue("COMPENSATION_STATUS", " ");


                fleF110_EP_INCEXP.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));


                fleF110_EP_INCEXP.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);


                fleF110_EP_INCEXP.set_SetValue("LAST_MOD_USER_ID", "U115B gen`d");

                fleF110_EP_INCEXP.OutPut(OutPutType.Add, fleF110_COMPENSATION.At("DOC_NBR"), null);



                fleF110_CEIEAR.set_SetValue("EP_NBR", fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR"));


                fleF110_CEIEAR.set_SetValue("EP_NBR_ENTRY", fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR"));


                fleF110_CEIEAR.set_SetValue("COMP_CODE", "YTDCEA");


                fleF110_CEIEAR.set_SetValue("COMP_TYPE", QDesign.NULL(YTDCEA_TYPE.Value));


                fleF110_CEIEAR.set_SetValue("PROCESS_SEQ", YTDCEA_SEQ.Value);


                fleF110_CEIEAR.set_SetValue("FACTOR", 0);


                fleF110_CEIEAR.set_SetValue("FACTOR_OVERRIDE", " ");


                fleF110_CEIEAR.set_SetValue("COMP_UNITS", 0);


                fleF110_CEIEAR.set_SetValue("AMT_GROSS", 0);


                fleF110_CEIEAR.set_SetValue("AMT_NET", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDCEA"));


                fleF110_CEIEAR.set_SetValue("COMPENSATION_STATUS", " ");


                fleF110_CEIEAR.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));


                fleF110_CEIEAR.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);


                fleF110_CEIEAR.set_SetValue("LAST_MOD_USER_ID", "U115B gen`d");

                fleF110_CEIEAR.OutPut(OutPutType.Add, fleF110_COMPENSATION.At("DOC_NBR"), null);



                fleF110_CEIEXP.set_SetValue("EP_NBR", fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR"));


                fleF110_CEIEXP.set_SetValue("EP_NBR_ENTRY", fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR"));


                fleF110_CEIEXP.set_SetValue("COMP_CODE", "YTDCEX");


                fleF110_CEIEXP.set_SetValue("COMP_TYPE", QDesign.NULL(YTDCEX_TYPE.Value));


                fleF110_CEIEXP.set_SetValue("PROCESS_SEQ", YTDCEX_SEQ.Value);


                fleF110_CEIEXP.set_SetValue("FACTOR", 0);


                fleF110_CEIEXP.set_SetValue("FACTOR_OVERRIDE", " ");


                fleF110_CEIEXP.set_SetValue("COMP_UNITS", 0);


                fleF110_CEIEXP.set_SetValue("AMT_GROSS", 0);


                fleF110_CEIEXP.set_SetValue("AMT_NET", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDCEX"));


                fleF110_CEIEXP.set_SetValue("COMPENSATION_STATUS", " ");


                fleF110_CEIEXP.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));


                fleF110_CEIEXP.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);


                fleF110_CEIEXP.set_SetValue("LAST_MOD_USER_ID", "U115B gen`d");

                fleF110_CEIEXP.OutPut(OutPutType.Add, fleF110_COMPENSATION.At("DOC_NBR"), null);



                fleF110_YTDEAR.set_SetValue("EP_NBR", fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR"));


                fleF110_YTDEAR.set_SetValue("EP_NBR_ENTRY", fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR"));


                fleF110_YTDEAR.set_SetValue("COMP_CODE", "YTDEAR");


                fleF110_YTDEAR.set_SetValue("COMP_TYPE", QDesign.NULL(YTDEAR_TYPE.Value));


                fleF110_YTDEAR.set_SetValue("PROCESS_SEQ", YTDEAR_SEQ.Value);


                fleF110_YTDEAR.set_SetValue("FACTOR", 0);


                fleF110_YTDEAR.set_SetValue("FACTOR_OVERRIDE", " ");


                fleF110_YTDEAR.set_SetValue("COMP_UNITS", 0);


                fleF110_YTDEAR.set_SetValue("AMT_GROSS", 0);


                fleF110_YTDEAR.set_SetValue("AMT_NET", DOC_YTDEAR_PLUS_AMT_MANPAY.Value);


                fleF110_YTDEAR.set_SetValue("COMPENSATION_STATUS", " ");


                fleF110_YTDEAR.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));


                fleF110_YTDEAR.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);


                fleF110_YTDEAR.set_SetValue("LAST_MOD_USER_ID", "U115B gen`d");

                fleF110_YTDEAR.OutPut(OutPutType.Add, fleF110_COMPENSATION.At("DOC_NBR"), null);

                fleF020_DOCTOR_MSTR.OutPut(OutPutType.Update, fleF110_COMPENSATION.At("DOC_NBR"), fleF020_DOCTOR_MSTR.Exists());


                SubFile(ref m_trnTRANS_UPDATE, ref fleDEBUGU115B_AT_COMP_CODE, SubFileType.Keep, fleF110_COMPENSATION, "DOC_NBR", "COMP_CODE", "AMT_GROSS", "AMT_NET", fleF190_COMP_CODES, "COMP_TYPE",
                "COMP_SUB_TYPE", fleCONSTANTS_MSTR_REC_6, "CURRENT_EP_NBR", fleF020_DOCTOR_MSTR, "DOC_DEPT_EXPENSE_PERCENT_REG", "DOC_DEPT_EXPENSE_PERCENT_MISC", "DOC_IND_PAYS_GST", "DOC_RMA_EXPENSE_PERCENT_MISC", "DOC_RMA_EXPENSE_PERCENT_REG", fleF110_COMPENSATION,
                "EP_NBR", X_INCOME_GROSS_MINUS_NET, X_AMT_DEPT_EXPENSE_POT_G, X_AMT_DEPT_EXPENSE_G, GST_PERCENT, X_AMT_GST_POT_G, X_AMT_GST_ONLY, X_AMT_RMA_EXPENSE_ONLY, X_AMT_RMA_EXPENSE_POT_G, X_AMT_RMA_EXPENSE_PLUS_GST_G,
                X_AMT_HOLDBACK_G, X_AMT_HOLDBACK_FINAL, X_AMT_RMA_EXPENSE_FINAL, X_AMT_RMA_EXPENSE_PLUSGST_FINAL, TOT_INCOME_GROSS_REG, TOT_INCOME_GROSS_MISC, TOT_INCOME_GROSS_OTHER, TOT_INCOME_NET_REG, TOT_INCOME_NET_MISC, TOT_INCOME_NET_OTHER,
                TOT_DEPT_EXPENSE_REG, TOT_DEPT_EXPENSE_MISC, TOT_RMA_EXPENSE_PLUS_GST_REG, TOT_RMA_EXPENSE_PLUS_GST_MISC, TOT_RMA_EXPENSE_ONLY_REG, TOT_RMA_EXPENSE_ONLY_MISC, TOT_GST_ONLY_REG, TOT_GST_ONLY_MISC, TOT_HOLDBACK_ONLY_REG, TOT_HOLDBACK_ONLY_MISC,
                TOT_REVHBK, AMT_MANPAY, FINAL_ALL_EXPENSES, FINAL_ALL_EXPENSES_PLUS_DEPT_EXPENSE_OTHER, TOT_DEPT_EXPENSE_OTHER, AMT_INCOME_MINUS_EXPENSES_G, DOC_YTDEAR_PLUS_AMT_MANPAY, fleF020_DOCTOR_MSTR, "DOC_YTDEAR", "DOC_YTDINC",
                "DOC_YTDINC", TOT_INCOME_GROSS, TOT_INCOME_NET, "DOC_YTDINC_G");

                SubFile(ref m_trnTRANS_UPDATE, ref fleDEBUGU115B_AT_DOC_NBR, fleF110_COMPENSATION.At("DOC_NBR"), SubFileType.Keep, fleF110_COMPENSATION, "DOC_NBR", TOT_INCOME_GROSS_REG, TOT_INCOME_GROSS_MISC, TOT_INCOME_GROSS_OTHER, TOT_INCOME_NET_REG,
                TOT_INCOME_NET_MISC, TOT_INCOME_NET_OTHER, TOT_DEPT_EXPENSE_REG, TOT_DEPT_EXPENSE_MISC, TOT_RMA_EXPENSE_PLUS_GST_REG, TOT_RMA_EXPENSE_PLUS_GST_MISC, TOT_RMA_EXPENSE_ONLY_REG, TOT_RMA_EXPENSE_ONLY_MISC, TOT_GST_ONLY_REG, TOT_GST_ONLY_MISC,
                TOT_HOLDBACK_ONLY_REG, TOT_HOLDBACK_ONLY_MISC, TOT_REVHBK, AMT_MANPAY, FINAL_ALL_EXPENSES, FINAL_ALL_EXPENSES_PLUS_DEPT_EXPENSE_OTHER, TOT_DEPT_EXPENSE_OTHER, AMT_INCOME_MINUS_EXPENSES_G, DOC_YTDEAR_PLUS_AMT_MANPAY, fleF020_DOCTOR_MSTR,
                "DOC_YTDEAR", "DOC_YTDINC", "DOC_YTDINC", TOT_INCOME_GROSS, TOT_INCOME_NET, "DOC_YTDINC_G");


                Reset(ref TOT_DEPT_EXPENSE_OTHER, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref TOT_INCOME_GROSS_REG, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref TOT_INCOME_GROSS_MISC, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref TOT_INCOME_GROSS_OTHER, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref TOT_INCOME_NET_REG, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref TOT_INCOME_NET_MISC, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref TOT_INCOME_NET_OTHER, fleF110_COMPENSATION.At("DOC_NBR"));
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
                Reset(ref AMT_YTDGUA, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref AMT_YTDGUB, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref AMT_YTDGUC, fleF110_COMPENSATION.At("DOC_NBR"));

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
            EndRequest("U115_RUN_1_17");

        }

    }







    #endregion


}
//U115_RUN_1_17




