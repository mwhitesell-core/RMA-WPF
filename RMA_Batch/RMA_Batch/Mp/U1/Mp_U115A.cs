
#region "Screen Comments"

// #> program-id.     Mp_U115A.qts
// ((C)) Dyad Technologies
// purpose: sub-process within  earnings generation  process.
// calculate required `tot`al / `ytd` transactions as of current eP
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
// 95/MAY/08         M.C.     - COMMENT OUT THE SUBFILE DEBUG_U115A,
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
// 03/jan/21 B.E. - added doc-nbr to debug file DEBUG_U115A_AT_DOC_NBR
// 2014/May/05 MC1     - added select so that this program doesn`t run if paycode is 7 (this paycd doesn`t need the usual
// calculated comp codes such as TOTINC, INCEXP etc.
// - add f112 to access to determine doc-pay-code
// 2014/May/12 MC2     - change fields(tot-, doc-) to allow 1M from integer*8 to integer* 10 to be the same as in 101c  
// particular the one used in f119 subfile


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class Mp_U115A : BaseClassControl
{

    private Mp_U115A m_Mp_U115A;

    public Mp_U115A(string Name, int Level)
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


    }

    public Mp_U115A(string Name, int Level, bool Request)
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


    }

    public override void Dispose()
    {
        if ((m_Mp_U115A != null))
        {
            m_Mp_U115A.CloseTransactionObjects();
            m_Mp_U115A = null;
        }
    }

    public Mp_U115A GetMp_U115A(int Level)
    {
        if (m_Mp_U115A == null)
        {
            m_Mp_U115A = new Mp_U115A("Mp_U115A", Level);
        }
        else
        {
            m_Mp_U115A.ResetValues();
        }
        return m_Mp_U115A;
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

    protected SqlConnection m_cnnQUERY = new SqlConnection();
    protected SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();

    protected SqlTransaction m_trnTRANS_UPDATE;


    #endregion


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"

    public override bool RunQTP()
    {


        try
        {

            Mp_U115A_U115_A_GET_YTDEAR_1 U115_A_GET_YTDEAR_1 = new Mp_U115A_U115_A_GET_YTDEAR_1(Name, Level);
            U115_A_GET_YTDEAR_1.Run();
            U115_A_GET_YTDEAR_1.Dispose();
            U115_A_GET_YTDEAR_1 = null;

            Mp_U115A_U115_A_GET_RMAEXR_2 U115_A_GET_RMAEXR_2 = new Mp_U115A_U115_A_GET_RMAEXR_2(Name, Level);
            U115_A_GET_RMAEXR_2.Run();
            U115_A_GET_RMAEXR_2.Dispose();
            U115_A_GET_RMAEXR_2 = null;

            Mp_U115A_U115_A_GET_RMAEXM_3 U115_A_GET_RMAEXM_3 = new Mp_U115A_U115_A_GET_RMAEXM_3(Name, Level);
            U115_A_GET_RMAEXM_3.Run();
            U115_A_GET_RMAEXM_3.Dispose();
            U115_A_GET_RMAEXM_3 = null;

            Mp_U115A_U115_A_GET_INCEXP_4 U115_A_GET_INCEXP_4 = new Mp_U115A_U115_A_GET_INCEXP_4(Name, Level);
            U115_A_GET_INCEXP_4.Run();
            U115_A_GET_INCEXP_4.Dispose();
            U115_A_GET_INCEXP_4 = null;

            Mp_U115A_U115_A_GET_TOTINC_5 U115_A_GET_TOTINC_5 = new Mp_U115A_U115_A_GET_TOTINC_5(Name, Level);
            U115_A_GET_TOTINC_5.Run();
            U115_A_GET_TOTINC_5.Dispose();
            U115_A_GET_TOTINC_5 = null;

            Mp_U115A_U115_A_GET_TOTEXP_6 U115_A_GET_TOTEXP_6 = new Mp_U115A_U115_A_GET_TOTEXP_6(Name, Level);
            U115_A_GET_TOTEXP_6.Run();
            U115_A_GET_TOTEXP_6.Dispose();
            U115_A_GET_TOTEXP_6 = null;

            Mp_U115A_U115_A_GET_DEPEXR_7 U115_A_GET_DEPEXR_7 = new Mp_U115A_U115_A_GET_DEPEXR_7(Name, Level);
            U115_A_GET_DEPEXR_7.Run();
            U115_A_GET_DEPEXR_7.Dispose();
            U115_A_GET_DEPEXR_7 = null;

            Mp_U115A_U115_A_GET_DEPEXM_8 U115_A_GET_DEPEXM_8 = new Mp_U115A_U115_A_GET_DEPEXM_8(Name, Level);
            U115_A_GET_DEPEXM_8.Run();
            U115_A_GET_DEPEXM_8.Dispose();
            U115_A_GET_DEPEXM_8 = null;

            Mp_U115A_U115_A_GET_GST_9 U115_A_GET_GST_9 = new Mp_U115A_U115_A_GET_GST_9(Name, Level);
            U115_A_GET_GST_9.Run();
            U115_A_GET_GST_9.Dispose();
            U115_A_GET_GST_9 = null;

            Mp_U115A_U115_A_GET_HOLDBACK_10 U115_A_GET_HOLDBACK_10 = new Mp_U115A_U115_A_GET_HOLDBACK_10(Name, Level);
            U115_A_GET_HOLDBACK_10.Run();
            U115_A_GET_HOLDBACK_10.Dispose();
            U115_A_GET_HOLDBACK_10 = null;

            Mp_U115A_U115_RUN_0_11 U115_RUN_0_11 = new Mp_U115A_U115_RUN_0_11(Name, Level);
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

}



public class Mp_U115A_U115_A_GET_YTDEAR_1 : Mp_U115A
{

    public Mp_U115A_U115_A_GET_YTDEAR_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(Mp_U115A_U115_A_GET_YTDEAR_1)"

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


    #region "Standard Generated Procedures(Mp_U115A_U115_A_GET_YTDEAR_1)"


    #region "Automatic Item Initialization(Mp_U115A_U115_A_GET_YTDEAR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(Mp_U115A_U115_A_GET_YTDEAR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/28/2017 8:45:59 AM

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


    #region "FILE Management Procedures(Mp_U115A_U115_A_GET_YTDEAR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/28/2017 8:45:59 AM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(Mp_U115A_U115_A_GET_YTDEAR_1)"


    public void Run()
    {

        try
        {
            Request("U115_A_GET_YTDEAR_1");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

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
            EndRequest("U115_A_GET_YTDEAR_1");

        }

    }







    #endregion


}
//U115_A_GET_YTDEAR_1



public class Mp_U115A_U115_A_GET_RMAEXR_2 : Mp_U115A
{

    public Mp_U115A_U115_A_GET_RMAEXR_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(Mp_U115A_U115_A_GET_RMAEXR_2)"

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


    #region "Standard Generated Procedures(Mp_U115A_U115_A_GET_RMAEXR_2)"


    #region "Automatic Item Initialization(Mp_U115A_U115_A_GET_RMAEXR_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(Mp_U115A_U115_A_GET_RMAEXR_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/28/2017 8:45:59 AM

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


    #region "FILE Management Procedures(Mp_U115A_U115_A_GET_RMAEXR_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/28/2017 8:45:59 AM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(Mp_U115A_U115_A_GET_RMAEXR_2)"


    public void Run()
    {

        try
        {
            Request("U115_A_GET_RMAEXR_2");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

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
            EndRequest("U115_A_GET_RMAEXR_2");

        }

    }







    #endregion


}
//U115_A_GET_RMAEXR_2



public class Mp_U115A_U115_A_GET_RMAEXM_3 : Mp_U115A
{

    public Mp_U115A_U115_A_GET_RMAEXM_3(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(Mp_U115A_U115_A_GET_RMAEXM_3)"

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


    #region "Standard Generated Procedures(Mp_U115A_U115_A_GET_RMAEXM_3)"


    #region "Automatic Item Initialization(Mp_U115A_U115_A_GET_RMAEXM_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(Mp_U115A_U115_A_GET_RMAEXM_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/28/2017 8:45:59 AM

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


    #region "FILE Management Procedures(Mp_U115A_U115_A_GET_RMAEXM_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/28/2017 8:45:59 AM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(Mp_U115A_U115_A_GET_RMAEXM_3)"


    public void Run()
    {

        try
        {
            Request("U115_A_GET_RMAEXM_3");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

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
            EndRequest("U115_A_GET_RMAEXM_3");

        }

    }







    #endregion


}
//U115_A_GET_RMAEXM_3



public class Mp_U115A_U115_A_GET_INCEXP_4 : Mp_U115A
{

    public Mp_U115A_U115_A_GET_INCEXP_4(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(Mp_U115A_U115_A_GET_INCEXP_4)"

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


    #region "Standard Generated Procedures(Mp_U115A_U115_A_GET_INCEXP_4)"


    #region "Automatic Item Initialization(Mp_U115A_U115_A_GET_INCEXP_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(Mp_U115A_U115_A_GET_INCEXP_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/28/2017 8:45:59 AM

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


    #region "FILE Management Procedures(Mp_U115A_U115_A_GET_INCEXP_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/28/2017 8:45:59 AM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(Mp_U115A_U115_A_GET_INCEXP_4)"


    public void Run()
    {

        try
        {
            Request("U115_A_GET_INCEXP_4");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

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
            EndRequest("U115_A_GET_INCEXP_4");

        }

    }







    #endregion


}
//U115_A_GET_INCEXP_4



public class Mp_U115A_U115_A_GET_TOTINC_5 : Mp_U115A
{

    public Mp_U115A_U115_A_GET_TOTINC_5(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(Mp_U115A_U115_A_GET_TOTINC_5)"

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


    #region "Standard Generated Procedures(Mp_U115A_U115_A_GET_TOTINC_5)"


    #region "Automatic Item Initialization(Mp_U115A_U115_A_GET_TOTINC_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(Mp_U115A_U115_A_GET_TOTINC_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/28/2017 8:45:59 AM

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


    #region "FILE Management Procedures(Mp_U115A_U115_A_GET_TOTINC_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/28/2017 8:46:00 AM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(Mp_U115A_U115_A_GET_TOTINC_5)"


    public void Run()
    {

        try
        {
            Request("U115_A_GET_TOTINC_5");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

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
            EndRequest("U115_A_GET_TOTINC_5");

        }

    }







    #endregion


}
//U115_A_GET_TOTINC_5



public class Mp_U115A_U115_A_GET_TOTEXP_6 : Mp_U115A
{

    public Mp_U115A_U115_A_GET_TOTEXP_6(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(Mp_U115A_U115_A_GET_TOTEXP_6)"

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


    #region "Standard Generated Procedures(Mp_U115A_U115_A_GET_TOTEXP_6)"


    #region "Automatic Item Initialization(Mp_U115A_U115_A_GET_TOTEXP_6)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(Mp_U115A_U115_A_GET_TOTEXP_6)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/28/2017 8:46:00 AM

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


    #region "FILE Management Procedures(Mp_U115A_U115_A_GET_TOTEXP_6)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/28/2017 8:46:00 AM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(Mp_U115A_U115_A_GET_TOTEXP_6)"


    public void Run()
    {

        try
        {
            Request("U115_A_GET_TOTEXP_6");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

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
            EndRequest("U115_A_GET_TOTEXP_6");

        }

    }







    #endregion


}
//U115_A_GET_TOTEXP_6



public class Mp_U115A_U115_A_GET_DEPEXR_7 : Mp_U115A
{

    public Mp_U115A_U115_A_GET_DEPEXR_7(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(Mp_U115A_U115_A_GET_DEPEXR_7)"

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


    #region "Standard Generated Procedures(Mp_U115A_U115_A_GET_DEPEXR_7)"


    #region "Automatic Item Initialization(Mp_U115A_U115_A_GET_DEPEXR_7)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(Mp_U115A_U115_A_GET_DEPEXR_7)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/28/2017 8:46:00 AM

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


    #region "FILE Management Procedures(Mp_U115A_U115_A_GET_DEPEXR_7)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/28/2017 8:46:00 AM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(Mp_U115A_U115_A_GET_DEPEXR_7)"


    public void Run()
    {

        try
        {
            Request("U115_A_GET_DEPEXR_7");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

                if (Transaction())
                {
                    DEPEXR_GROUP.Value = fleF190_COMP_CODES.GetStringValue("COMP_CODE_GROUP");
                    DEPEXR_SEQ_RPT.Value = fleF190_COMP_CODES.GetDecimalValue("REPORTING_SEQ");

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
            EndRequest("U115_A_GET_DEPEXR_7");

        }

    }







    #endregion


}
//U115_A_GET_DEPEXR_7



public class Mp_U115A_U115_A_GET_DEPEXM_8 : Mp_U115A
{

    public Mp_U115A_U115_A_GET_DEPEXM_8(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(Mp_U115A_U115_A_GET_DEPEXM_8)"

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


    #region "Standard Generated Procedures(Mp_U115A_U115_A_GET_DEPEXM_8)"


    #region "Automatic Item Initialization(Mp_U115A_U115_A_GET_DEPEXM_8)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(Mp_U115A_U115_A_GET_DEPEXM_8)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/28/2017 8:46:00 AM

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


    #region "FILE Management Procedures(Mp_U115A_U115_A_GET_DEPEXM_8)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/28/2017 8:46:00 AM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(Mp_U115A_U115_A_GET_DEPEXM_8)"


    public void Run()
    {

        try
        {
            Request("U115_A_GET_DEPEXM_8");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

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
            EndRequest("U115_A_GET_DEPEXM_8");

        }

    }







    #endregion


}
//U115_A_GET_DEPEXM_8



public class Mp_U115A_U115_A_GET_GST_9 : Mp_U115A
{

    public Mp_U115A_U115_A_GET_GST_9(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(Mp_U115A_U115_A_GET_GST_9)"

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


    #region "Standard Generated Procedures(Mp_U115A_U115_A_GET_GST_9)"


    #region "Automatic Item Initialization(Mp_U115A_U115_A_GET_GST_9)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(Mp_U115A_U115_A_GET_GST_9)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/28/2017 8:46:00 AM

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


    #region "FILE Management Procedures(Mp_U115A_U115_A_GET_GST_9)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/28/2017 8:46:00 AM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(Mp_U115A_U115_A_GET_GST_9)"


    public void Run()
    {

        try
        {
            Request("U115_A_GET_GST_9");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

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
            EndRequest("U115_A_GET_GST_9");

        }

    }







    #endregion


}
//U115_A_GET_GST_9



public class Mp_U115A_U115_A_GET_HOLDBACK_10 : Mp_U115A
{

    public Mp_U115A_U115_A_GET_HOLDBACK_10(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(Mp_U115A_U115_A_GET_HOLDBACK_10)"

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


    #region "Standard Generated Procedures(Mp_U115A_U115_A_GET_HOLDBACK_10)"


    #region "Automatic Item Initialization(Mp_U115A_U115_A_GET_HOLDBACK_10)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(Mp_U115A_U115_A_GET_HOLDBACK_10)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/28/2017 8:46:00 AM

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


    #region "FILE Management Procedures(Mp_U115A_U115_A_GET_HOLDBACK_10)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/28/2017 8:46:00 AM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(Mp_U115A_U115_A_GET_HOLDBACK_10)"


    public void Run()
    {

        try
        {
            Request("U115_A_GET_HOLDBACK_10");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

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
            EndRequest("U115_A_GET_HOLDBACK_10");

        }

    }







    #endregion


}
//U115_A_GET_HOLDBACK_10



public class Mp_U115A_U115_RUN_0_11 : Mp_U115A
{

    public Mp_U115A_U115_RUN_0_11(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleCONSTANTS_MSTR_REC_6 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "CONSTANTS_MSTR_REC_6", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF110_COMPENSATION = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF112_PYCDCEILINGS = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F112_PYCDCEILINGS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        TOT_INCOME_GROSS_REG = new CoreInteger("TOT_INCOME_GROSS_REG", 10, this);
        TOT_INCOME_GROSS_MISC = new CoreInteger("TOT_INCOME_GROSS_MISC", 10, this);
        TOT_INCOME_NET_REG = new CoreInteger("TOT_INCOME_NET_REG", 10, this);
        TOT_INCOME_NET_MISC = new CoreInteger("TOT_INCOME_NET_MISC", 10, this);
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
        AMT_MANPAY = new CoreInteger("AMT_MANPAY", 4, this);
        COMP_CODE = new CoreCharacter("COMP_CODE", 6, this);
        REPORTING_SEQ = new CoreDecimal("REPORTING_SEQ", 2, this);
        COMP_CODE_GROUP = new CoreCharacter("COMP_CODE_GROUP", 1, this);
        REC_TYPE = new CoreCharacter("REC_TYPE", 1, this);
        AMT_NET = new CoreInteger("AMT_NET", 10, this);
        AMT_GROSS = new CoreInteger("AMT_GROSS", 10, this);

        fleF119 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F119", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF119_RMAEXR = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F119", "F119_RMAEXR", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF119_RMAEXM = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F119", "F119_RMAEXM", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF119_GST = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F119", "F119_GST", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF119_HOLDBACK = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F119", "F119_HOLDBACK", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF119_TOTINC = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F119", "F119_TOTINC", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF119_DEPEXR = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F119", "F119_DEPEXR", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF119_DEPEXM = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F119", "F119_DEPEXM", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        FINAL_ALL_EXPENSES = new CoreInteger("FINAL_ALL_EXPENSES", 10, this);
        fleF119_TOTEXP = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F119", "F119_TOTEXP", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        AMT_INCOME_MINUS_EXPENSES_G = new CoreInteger("AMT_INCOME_MINUS_EXPENSES_G", 10, this);
        fleU115_INCEXP = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F119", "U115_INCEXP", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        DOC_YTDEAR_PLUS_AMT_MANPAY = new CoreInteger("DOC_YTDEAR_PLUS_AMT_MANPAY", 10, this);
        fleF119_YTDEAR = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F119", "F119_YTDEAR", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleDEBUG_U115A_AT_COMP_CODE = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "DEBUG_U115A_AT_COMP_CODE", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleDEBUG_U115A_AT_DOC_NBR = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "DEBUG_U115A_AT_DOC_NBR", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleCONSTANTS_MSTR_REC_6.Choose += fleCONSTANTS_MSTR_REC_6_Choose;
        GST_PERCENT.GetValue += GST_PERCENT_GetValue;
        X_INCOME_GROSS_MINUS_NET.GetValue += X_INCOME_GROSS_MINUS_NET_GetValue;
        X_AMT_DEPT_EXPENSE_POT_G.GetValue += X_AMT_DEPT_EXPENSE_POT_G_GetValue;
        X_AMT_DEPT_EXPENSE_G.GetValue += X_AMT_DEPT_EXPENSE_G_GetValue;
        X_AMT_RMA_EXPENSE_POT_G.GetValue += X_AMT_RMA_EXPENSE_POT_G_GetValue;
        X_AMT_RMA_EXPENSE_ONLY.GetValue += X_AMT_RMA_EXPENSE_ONLY_GetValue;
        X_AMT_GST_POT_G.GetValue += X_AMT_GST_POT_G_GetValue;
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
        X_COMP_CODE.GetValue += X_COMP_CODE_GetValue;
        X_COMP_CODE_RMAEXM.GetValue += X_COMP_CODE_RMAEXM_GetValue;
        X_COMP_CODE_GST.GetValue += X_COMP_CODE_GST_GetValue;
        TOT_GST_ONLY.GetValue += TOT_GST_ONLY_GetValue;
        X_COMP_CODE_HOLDBACK.GetValue += X_COMP_CODE_HOLDBACK_GetValue;
        TOT_HOLDBACK_ONLY.GetValue += TOT_HOLDBACK_ONLY_GetValue;
        X_COMP_CODE_TOTINC.GetValue += X_COMP_CODE_TOTINC_GetValue;
        TOT_INCOME_GROSS.GetValue += TOT_INCOME_GROSS_GetValue;
        TOT_INCOME_NET.GetValue += TOT_INCOME_NET_GetValue;
        X_COMP_CODE_DEPEXR.GetValue += X_COMP_CODE_DEPEXR_GetValue;
        X_COMP_CODE_DEPEXM.GetValue += X_COMP_CODE_DEPEXM_GetValue;
        X_COMP_CODE_TOTEXP.GetValue += X_COMP_CODE_TOTEXP_GetValue;
        X_COMP_CODE_INCEXP.GetValue += X_COMP_CODE_INCEXP_GetValue;
        X_COMP_CODE_YTDEAR.GetValue += X_COMP_CODE_YTDEAR_GetValue;
        fleF020_DOCTOR_MSTR.InitializeItems += fleF020_DOCTOR_MSTR_AutomaticItemInitialization;
        fleF190_COMP_CODES.InitializeItems += fleF190_COMP_CODES_AutomaticItemInitialization;
        fleF112_PYCDCEILINGS.InitializeItems += fleF112_PYCDCEILINGS_AutomaticItemInitialization;
        DEBUG_NOTE = new CoreCharacter("DEBUG_NOTE", 64, this, Common.cEmptyString);
    }


    #region "Declarations (Variables, Files and Transactions)(Mp_U115A_U115_RUN_0_11)"

    private SqlFileObject fleCONSTANTS_MSTR_REC_6;
    private SqlFileObject fleF110_COMPENSATION;
    private SqlFileObject fleF020_DOCTOR_MSTR;
    private SqlFileObject fleF190_COMP_CODES;
    private SqlFileObject fleF112_PYCDCEILINGS;

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


    public override bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_CODE")) != "7")
            {
                return true;
            }

            return false;


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
    private DInteger X_INCOME_GROSS_MINUS_NET = new DInteger("X_INCOME_GROSS_MINUS_NET", 4);
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
    private DInteger X_AMT_DEPT_EXPENSE_POT_G = new DInteger("X_AMT_DEPT_EXPENSE_POT_G", 4);
    private void X_AMT_DEPT_EXPENSE_POT_G_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0;

            // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

            if (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("COMP_TYPE")) == "I" & QDesign.NULL(fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE")) == "R")
            {
                CurrentValue = QDesign.Round((fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS") * fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_REG")) / 1000000, 0, RoundOptionTypes.Near);
            }
            else if (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("COMP_TYPE")) == "I" & QDesign.NULL(fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE")) == "M")
            {
                CurrentValue = QDesign.Round((fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS") * fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_MISC")) / 1000000, 0, RoundOptionTypes.Near);
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
    private DInteger X_AMT_DEPT_EXPENSE_G = new DInteger("X_AMT_DEPT_EXPENSE_G", 4);
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
    private DInteger X_AMT_RMA_EXPENSE_POT_G = new DInteger("X_AMT_RMA_EXPENSE_POT_G", 4);
    private void X_AMT_RMA_EXPENSE_POT_G_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0;

            // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

            if (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("COMP_TYPE")) == "I" & QDesign.NULL(fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE")) == "R")
            {
                CurrentValue = QDesign.Round((fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS") * fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_REG")) / 1000000, 0, RoundOptionTypes.Near);
            }
            else if (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("COMP_TYPE")) == "I" & QDesign.NULL(fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE")) == "M")
            {
                CurrentValue = QDesign.Round((fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS") * fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_MISC")) / 1000000, 0, RoundOptionTypes.Near);
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
    private DInteger X_AMT_RMA_EXPENSE_ONLY = new DInteger("X_AMT_RMA_EXPENSE_ONLY", 4);
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
                CurrentValue = (X_INCOME_GROSS_MINUS_NET.Value - X_AMT_DEPT_EXPENSE_G.Value);
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
    private DInteger X_AMT_GST_POT_G = new DInteger("X_AMT_GST_POT_G", 4);
    private void X_AMT_GST_POT_G_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0;

            // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

            if (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_IND_PAYS_GST")) == "Y")
            {
                CurrentValue = X_AMT_RMA_EXPENSE_ONLY.Value * GST_PERCENT.Value / 100;
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
    private DInteger X_AMT_GST_ONLY = new DInteger("X_AMT_GST_ONLY", 4);
    private void X_AMT_GST_ONLY_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0;
            if ((QDesign.NULL(X_INCOME_GROSS_MINUS_NET.Value) > QDesign.NULL((X_AMT_DEPT_EXPENSE_G.Value + X_AMT_RMA_EXPENSE_ONLY.Value + X_AMT_GST_POT_G.Value)) & QDesign.NULL(fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS")) > 0) | (QDesign.NULL(X_INCOME_GROSS_MINUS_NET.Value) < QDesign.NULL((X_AMT_DEPT_EXPENSE_G.Value + X_AMT_RMA_EXPENSE_ONLY.Value + X_AMT_GST_POT_G.Value)) & QDesign.NULL(fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS")) < 0))
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
    private DInteger X_AMT_RMA_EXPENSE_PLUS_GST_G = new DInteger("X_AMT_RMA_EXPENSE_PLUS_GST_G", 4);
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
    private DInteger X_AMT_HOLDBACK_G = new DInteger("X_AMT_HOLDBACK_G", 4);
    private void X_AMT_HOLDBACK_G_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0;
            if ((QDesign.NULL(X_INCOME_GROSS_MINUS_NET.Value) > QDesign.NULL((X_AMT_DEPT_EXPENSE_G.Value + X_AMT_RMA_EXPENSE_PLUS_GST_G.Value)) & QDesign.NULL(fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS")) > 0) | (QDesign.NULL(X_INCOME_GROSS_MINUS_NET.Value) < QDesign.NULL((X_AMT_DEPT_EXPENSE_G.Value + X_AMT_RMA_EXPENSE_PLUS_GST_G.Value)) & QDesign.NULL(fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS")) < 0))
            {
                CurrentValue = X_INCOME_GROSS_MINUS_NET.Value - X_AMT_DEPT_EXPENSE_G.Value - X_AMT_RMA_EXPENSE_PLUS_GST_G.Value;
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
    private DInteger X_AMT_RMA_EXPENSE_PLUSGST_FINAL = new DInteger("X_AMT_RMA_EXPENSE_PLUSGST_FINAL", 4);
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
    private CoreInteger TOT_INCOME_NET_REG;
    private CoreInteger TOT_INCOME_NET_MISC;
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
    private SqlFileObject fleF119;
    private CoreCharacter DEBUG_NOTE;
    private CoreCharacter COMP_CODE;
    private CoreDecimal REPORTING_SEQ;
    private CoreCharacter COMP_CODE_GROUP;
    private CoreCharacter REC_TYPE;
    private CoreInteger AMT_NET;
    private CoreInteger AMT_GROSS;

    private DCharacter X_COMP_CODE = new DCharacter("X_COMP_CODE", 6);
    private void X_COMP_CODE_GetValue(ref string Value)
    {

        try
        {
            Value = "RMAEXR";


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
    private SqlFileObject fleF119_RMAEXR;
    private DCharacter X_COMP_CODE_RMAEXM = new DCharacter("X_COMP_CODE_RMAEXM", 6);
    private void X_COMP_CODE_RMAEXM_GetValue(ref string Value)
    {

        try
        {
            Value = "RMAEXM";


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
    private SqlFileObject fleF119_RMAEXM;
    private DCharacter X_COMP_CODE_GST = new DCharacter("X_COMP_CODE_GST", 6);
    private void X_COMP_CODE_GST_GetValue(ref string Value)
    {

        try
        {
            Value = "GST";


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
    private SqlFileObject fleF119_GST;
    private DCharacter X_COMP_CODE_HOLDBACK = new DCharacter("X_COMP_CODE_HOLDBACK", 6);
    private void X_COMP_CODE_HOLDBACK_GetValue(ref string Value)
    {

        try
        {
            Value = "HOLDBK";


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
    private SqlFileObject fleF119_HOLDBACK;
    private DCharacter X_COMP_CODE_TOTINC = new DCharacter("X_COMP_CODE_TOTINC", 6);
    private void X_COMP_CODE_TOTINC_GetValue(ref string Value)
    {

        try
        {
            Value = "TOTINC";


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
            Value = TOT_INCOME_GROSS_REG.Value + TOT_INCOME_GROSS_MISC.Value;


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
            Value = TOT_INCOME_NET_REG.Value + TOT_INCOME_NET_MISC.Value;


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
    private SqlFileObject fleF119_TOTINC;
    private DCharacter X_COMP_CODE_DEPEXR = new DCharacter("X_COMP_CODE_DEPEXR", 6);
    private void X_COMP_CODE_DEPEXR_GetValue(ref string Value)
    {

        try
        {
            Value = "DEPEXR";


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
    private SqlFileObject fleF119_DEPEXR;
    private DCharacter X_COMP_CODE_DEPEXM = new DCharacter("X_COMP_CODE_DEPEXM", 6);
    private void X_COMP_CODE_DEPEXM_GetValue(ref string Value)
    {

        try
        {
            Value = "DEPEXM";


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
    private SqlFileObject fleF119_DEPEXM;
    private CoreInteger FINAL_ALL_EXPENSES;
    private DCharacter X_COMP_CODE_TOTEXP = new DCharacter("X_COMP_CODE_TOTEXP", 6);
    private void X_COMP_CODE_TOTEXP_GetValue(ref string Value)
    {

        try
        {
            Value = "TOTEXP";


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
    private SqlFileObject fleF119_TOTEXP;
    private CoreInteger AMT_INCOME_MINUS_EXPENSES_G;
    private DCharacter X_COMP_CODE_INCEXP = new DCharacter("X_COMP_CODE_INCEXP", 6);
    private void X_COMP_CODE_INCEXP_GetValue(ref string Value)
    {

        try
        {
            Value = "INCEXP";


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
    private SqlFileObject fleU115_INCEXP;
    private CoreInteger DOC_YTDEAR_PLUS_AMT_MANPAY;
    private DCharacter X_COMP_CODE_YTDEAR = new DCharacter("X_COMP_CODE_YTDEAR", 6);
    private void X_COMP_CODE_YTDEAR_GetValue(ref string Value)
    {

        try
        {
            Value = "YTDEAR";


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
    private SqlFileObject fleF119_YTDEAR;
    private SqlFileObject fleDEBUG_U115A_AT_COMP_CODE;
    private SqlFileObject fleDEBUG_U115A_AT_DOC_NBR;


    #endregion


    #region "Standard Generated Procedures(Mp_U115A_U115_RUN_0_11)"


    #region "Automatic Item Initialization(Mp_U115A_U115_RUN_0_11)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/28/2017 8:46:02 AM

    //#-----------------------------------------
    //# fleF020_DOCTOR_MSTR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/28/2017 8:46:01 AM
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
    //# fleF190_COMP_CODES_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/28/2017 8:46:01 AM
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
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/28/2017 8:46:02 AM
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



    #endregion


    #region "Transaction Management Procedures(Mp_U115A_U115_RUN_0_11)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/28/2017 8:46:00 AM

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
        fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;
        fleF112_PYCDCEILINGS.Transaction = m_trnTRANS_UPDATE;
        fleF119.Transaction = m_trnTRANS_UPDATE;
        fleF119_RMAEXR.Transaction = m_trnTRANS_UPDATE;
        fleF119_RMAEXM.Transaction = m_trnTRANS_UPDATE;
        fleF119_GST.Transaction = m_trnTRANS_UPDATE;
        fleF119_HOLDBACK.Transaction = m_trnTRANS_UPDATE;
        fleF119_TOTINC.Transaction = m_trnTRANS_UPDATE;
        fleF119_DEPEXR.Transaction = m_trnTRANS_UPDATE;
        fleF119_DEPEXM.Transaction = m_trnTRANS_UPDATE;
        fleF119_TOTEXP.Transaction = m_trnTRANS_UPDATE;
        fleU115_INCEXP.Transaction = m_trnTRANS_UPDATE;
        fleF119_YTDEAR.Transaction = m_trnTRANS_UPDATE;
        fleDEBUG_U115A_AT_COMP_CODE.Transaction = m_trnTRANS_UPDATE;
        fleDEBUG_U115A_AT_DOC_NBR.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(Mp_U115A_U115_RUN_0_11)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/28/2017 8:46:00 AM

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
            fleF190_COMP_CODES.Dispose();
            fleF112_PYCDCEILINGS.Dispose();
            fleF119.Dispose();
            fleF119_RMAEXR.Dispose();
            fleF119_RMAEXM.Dispose();
            fleF119_GST.Dispose();
            fleF119_HOLDBACK.Dispose();
            fleF119_TOTINC.Dispose();
            fleF119_DEPEXR.Dispose();
            fleF119_DEPEXM.Dispose();
            fleF119_TOTEXP.Dispose();
            fleU115_INCEXP.Dispose();
            fleF119_YTDEAR.Dispose();
            fleDEBUG_U115A_AT_COMP_CODE.Dispose();
            fleDEBUG_U115A_AT_DOC_NBR.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(Mp_U115A_U115_RUN_0_11)"


    public void Run()
    {

        try
        {
            Request("U115_RUN_0_11");

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

                        fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F020_DOCTOR_MSTR <--

                        while (fleF190_COMP_CODES.QTPForMissing("3"))
                        {
                            // --> GET F190_COMP_CODES <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
                            m_strWhere.Append(Common.StringToField(fleF110_COMPENSATION.GetStringValue("COMP_CODE")));

                            fleF190_COMP_CODES.GetData(m_strWhere.ToString());
                            // --> End GET F190_COMP_CODES <--

                            while (fleF112_PYCDCEILINGS.QTPForMissing("4"))
                            {
                                // --> GET F112_PYCDCEILINGS <--
                                m_strWhere = new StringBuilder(" WHERE ");
                                m_strWhere.Append(" ").Append(fleF112_PYCDCEILINGS.ElementOwner("EP_NBR")).Append(" = ");
                                m_strWhere.Append((fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR")));
                                m_strWhere.Append(" And ").Append(fleF112_PYCDCEILINGS.ElementOwner("DOC_NBR")).Append(" = ");
                                m_strWhere.Append(Common.StringToField(fleF110_COMPENSATION.GetStringValue("DOC_NBR")));

                                fleF112_PYCDCEILINGS.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                // --> End GET F112_PYCDCEILINGS <--


                                if (Transaction())
                                {

                                    if (Select_If())
                                    {

                                        Sort(fleF110_COMPENSATION.GetSortValue("DOC_NBR"), fleF110_COMPENSATION.GetSortValue("EP_NBR"), fleF110_COMPENSATION.GetSortValue("COMP_CODE"));



                                    }

                                }

                            }

                        }

                    }

                }

            }

            while (Sort(fleCONSTANTS_MSTR_REC_6, fleF110_COMPENSATION, fleF020_DOCTOR_MSTR, fleF190_COMP_CODES, fleF112_PYCDCEILINGS))
            {
                if (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE")) == "R")
                {
                    TOT_INCOME_GROSS_REG.Value = TOT_INCOME_GROSS_REG.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS");
                }
                else
                {
                    TOT_INCOME_GROSS_REG.Value = TOT_INCOME_GROSS_REG.Value;
                }
                if (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE")) == "M")
                {
                    TOT_INCOME_GROSS_MISC.Value = TOT_INCOME_GROSS_MISC.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS");
                }
                else
                {
                    TOT_INCOME_GROSS_MISC.Value = TOT_INCOME_GROSS_MISC.Value;
                }
                if (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE")) == "R")
                {
                    TOT_INCOME_NET_REG.Value = TOT_INCOME_NET_REG.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET");
                }
                else
                {
                    TOT_INCOME_NET_REG.Value = TOT_INCOME_NET_REG.Value;
                }
                if (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("COMP_SUB_TYPE")) == "M")
                {
                    TOT_INCOME_NET_MISC.Value = TOT_INCOME_NET_MISC.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET");
                }
                else
                {
                    TOT_INCOME_NET_MISC.Value = TOT_INCOME_NET_MISC.Value;
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


                // ALL
                REC_TYPE.Value = X_REC_TYPE.Value;
                AMT_GROSS.Value = X_AMT_GROSS.Value;
                AMT_NET.Value = X_AMT_NET.Value;

                DEBUG_NOTE.Value = "Generated by: MP_u115A - ALL";
                SubFile(ref m_trnTRANS_UPDATE, ref fleF119, (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("COMP_TYPE")) == "I" | QDesign.NULL(fleF190_COMP_CODES.GetStringValue("COMP_TYPE")) == "E" | QDesign.NULL(fleF190_COMP_CODES.GetStringValue("COMP_TYPE")) == "A" | QDesign.NULL(fleF190_COMP_CODES.GetStringValue("COMP_TYPE")) == "M" | QDesign.NULL(fleF190_COMP_CODES.GetStringValue("COMP_TYPE")) == "P"), SubFileType.Keep, 
                    fleF110_COMPENSATION, "DOC_NBR", "COMP_CODE", fleF190_COMP_CODES, "REPORTING_SEQ", "COMP_CODE_GROUP",
                    REC_TYPE, AMT_NET, AMT_GROSS, DEBUG_NOTE);


                // RMAEXR
                COMP_CODE.Value = X_COMP_CODE.Value;
                REPORTING_SEQ.Value = RMAEXR_SEQ_RPT.Value;
                COMP_CODE_GROUP.Value = RMAEXR_GROUP.Value;
                REC_TYPE.Value = X_REC_TYPE.Value;
                AMT_GROSS.Value = TOT_RMA_EXPENSE_ONLY_REG.Value;
                AMT_NET.Value = X_NOT_NEEDED.Value;
                DEBUG_NOTE.Value = "Generated by: MP_u115A - RMAEXR";
                SubFile(ref m_trnTRANS_UPDATE, ref fleF119_RMAEXR, fleF110_COMPENSATION.At("DOC_NBR"), QDesign.NULL(TOT_RMA_EXPENSE_ONLY_REG.Value) != 0, SubFileType.Keep, SubFileMode.Append, 
                    fleF110_COMPENSATION, "DOC_NBR",
                    COMP_CODE, REPORTING_SEQ, COMP_CODE_GROUP, REC_TYPE, AMT_NET, AMT_GROSS, DEBUG_NOTE);


                // RMAEXM
                COMP_CODE.Value = X_COMP_CODE_RMAEXM.Value;
                REPORTING_SEQ.Value = RMAEXM_SEQ_RPT.Value;
                COMP_CODE_GROUP.Value = RMAEXM_GROUP.Value;
                REC_TYPE.Value = X_REC_TYPE.Value;
                AMT_GROSS.Value = TOT_RMA_EXPENSE_ONLY_MISC.Value;
                AMT_NET.Value = X_NOT_NEEDED.Value;
                DEBUG_NOTE.Value = "Generated by: MP_u115A - RMAEXM";
                SubFile(ref m_trnTRANS_UPDATE, ref fleF119_RMAEXM, fleF110_COMPENSATION.At("DOC_NBR"), QDesign.NULL(TOT_RMA_EXPENSE_ONLY_MISC.Value) != 0, SubFileType.Keep, SubFileMode.Append, fleF110_COMPENSATION, "DOC_NBR",
                    COMP_CODE, REPORTING_SEQ, COMP_CODE_GROUP, REC_TYPE, AMT_NET, AMT_GROSS, DEBUG_NOTE);


                // GST
                COMP_CODE.Value = X_COMP_CODE_GST.Value;
                REPORTING_SEQ.Value = GST_SEQ_RPT.Value;
                COMP_CODE_GROUP.Value = GST_GROUP.Value;
                REC_TYPE.Value = X_REC_TYPE.Value;
                AMT_GROSS.Value = TOT_GST_ONLY.Value;
                AMT_NET.Value = X_NOT_NEEDED.Value;
                DEBUG_NOTE.Value = "Generated by: MP_u115A - GST";
                SubFile(ref m_trnTRANS_UPDATE, ref fleF119_GST, fleF110_COMPENSATION.At("DOC_NBR"), QDesign.NULL(TOT_GST_ONLY.Value) != 0, SubFileType.Keep, SubFileMode.Append, fleF110_COMPENSATION, "DOC_NBR",
                    COMP_CODE, REPORTING_SEQ, COMP_CODE_GROUP, REC_TYPE, AMT_NET, AMT_GROSS, DEBUG_NOTE);


                // HOLDBACK
                COMP_CODE.Value = X_COMP_CODE_HOLDBACK.Value;
                REPORTING_SEQ.Value = HOLDBACK_SEQ_RPT.Value;
                COMP_CODE_GROUP.Value = HOLDBACK_GROUP.Value;
                REC_TYPE.Value = X_REC_TYPE.Value;
                AMT_GROSS.Value = TOT_HOLDBACK_ONLY.Value;
                AMT_NET.Value = X_NOT_NEEDED.Value;
                DEBUG_NOTE.Value = "Generated by: MP_u115A - HOLDBACK";
                SubFile(ref m_trnTRANS_UPDATE, ref fleF119_HOLDBACK, fleF110_COMPENSATION.At("DOC_NBR"), QDesign.NULL(TOT_HOLDBACK_ONLY.Value) != 0, SubFileType.Keep, SubFileMode.Append, fleF110_COMPENSATION, "DOC_NBR",
                   COMP_CODE, REPORTING_SEQ, COMP_CODE_GROUP, REC_TYPE, AMT_NET, AMT_GROSS, DEBUG_NOTE);



                // TOTINC
                COMP_CODE.Value = X_COMP_CODE_TOTINC.Value;
                REPORTING_SEQ.Value = TOTINC_SEQ_RPT.Value;
                COMP_CODE_GROUP.Value = TOTINC_GROUP.Value;
                REC_TYPE.Value = X_REC_TYPE.Value;
                AMT_GROSS.Value = TOT_INCOME_GROSS.Value;
                AMT_NET.Value = TOT_INCOME_NET.Value;
                DEBUG_NOTE.Value = "Generated by: MP_u115A - TOTINC";
                SubFile(ref m_trnTRANS_UPDATE, ref fleF119_TOTINC, fleF110_COMPENSATION.At("DOC_NBR"), QDesign.NULL(TOT_INCOME_NET.Value) != 0, SubFileType.Keep, SubFileMode.Append, fleF110_COMPENSATION, "DOC_NBR",
                    COMP_CODE, REPORTING_SEQ, COMP_CODE_GROUP, REC_TYPE, AMT_NET, AMT_GROSS, DEBUG_NOTE);


                // DEPEXR
                COMP_CODE.Value = X_COMP_CODE_DEPEXR.Value;
                REPORTING_SEQ.Value = DEPEXR_SEQ_RPT.Value;
                COMP_CODE_GROUP.Value = DEPEXR_GROUP.Value;
                REC_TYPE.Value = X_REC_TYPE.Value;
                AMT_GROSS.Value = TOT_DEPT_EXPENSE_REG.Value;
                AMT_NET.Value = X_NOT_NEEDED.Value;
                DEBUG_NOTE.Value = "Generated by: MP_u115A - DEPEXR";
                SubFile(ref m_trnTRANS_UPDATE, ref fleF119_DEPEXR, fleF110_COMPENSATION.At("DOC_NBR"), QDesign.NULL(TOT_DEPT_EXPENSE_REG.Value) != 0, SubFileType.Keep, SubFileMode.Append, fleF110_COMPENSATION, "DOC_NBR",
                   COMP_CODE, REPORTING_SEQ, COMP_CODE_GROUP, REC_TYPE, AMT_NET, AMT_GROSS, DEBUG_NOTE);



                // DEPEXM
                COMP_CODE.Value = X_COMP_CODE_DEPEXM.Value;
                REPORTING_SEQ.Value = DEPEXM_SEQ_RPT.Value;
                COMP_CODE_GROUP.Value = DEPEXM_GROUP.Value;
                REC_TYPE.Value = X_REC_TYPE.Value;
                AMT_GROSS.Value = TOT_DEPT_EXPENSE_MISC.Value;
                AMT_NET.Value = X_NOT_NEEDED.Value;
                DEBUG_NOTE.Value = "Generated by: MP_u115A - DEPEXM";
                SubFile(ref m_trnTRANS_UPDATE, ref fleF119_DEPEXM, fleF110_COMPENSATION.At("DOC_NBR"), QDesign.NULL(TOT_DEPT_EXPENSE_MISC.Value) != 0, SubFileType.Keep, SubFileMode.Append, fleF110_COMPENSATION, "DOC_NBR",
                    COMP_CODE, REPORTING_SEQ, COMP_CODE_GROUP, REC_TYPE, AMT_NET, AMT_GROSS, DEBUG_NOTE);


                FINAL_ALL_EXPENSES.Value = TOT_DEPT_EXPENSE_REG.Value + TOT_DEPT_EXPENSE_MISC.Value + TOT_RMA_EXPENSE_ONLY_REG.Value + TOT_RMA_EXPENSE_ONLY_MISC.Value + TOT_GST_ONLY.Value + TOT_HOLDBACK_ONLY.Value + TOT_REVHBK.Value + fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CEICEX");


                // TOTEXP
                COMP_CODE.Value = X_COMP_CODE_TOTEXP.Value;
                REPORTING_SEQ.Value = TOTEXP_SEQ_RPT.Value;
                COMP_CODE_GROUP.Value = TOTEXP_GROUP.Value;
                REC_TYPE.Value = X_REC_TYPE.Value;
                AMT_GROSS.Value = FINAL_ALL_EXPENSES.Value;
                AMT_NET.Value = X_NOT_NEEDED.Value;
                DEBUG_NOTE.Value = "Generated by: MP_u115A - TOTEXP";
                SubFile(ref m_trnTRANS_UPDATE, ref fleF119_TOTEXP, fleF110_COMPENSATION.At("DOC_NBR"), QDesign.NULL(FINAL_ALL_EXPENSES.Value) != 0, SubFileType.Keep, SubFileMode.Append, fleF110_COMPENSATION, "DOC_NBR",
                    COMP_CODE, REPORTING_SEQ, COMP_CODE_GROUP, REC_TYPE, AMT_NET, AMT_GROSS, DEBUG_NOTE);




                // INCEXP
                AMT_INCOME_MINUS_EXPENSES_G.Value = TOT_INCOME_GROSS.Value - FINAL_ALL_EXPENSES.Value;
                COMP_CODE.Value = X_COMP_CODE_INCEXP.Value;
                REPORTING_SEQ.Value = INCEXP_SEQ_RPT.Value;
                COMP_CODE_GROUP.Value = INCEXP_GROUP.Value;
                REC_TYPE.Value = X_REC_TYPE.Value;
                AMT_GROSS.Value = AMT_INCOME_MINUS_EXPENSES_G.Value;
                AMT_NET.Value = X_NOT_NEEDED.Value;
                DEBUG_NOTE.Value = "Generated by: MP_u115A - INCEXP";
                SubFile(ref m_trnTRANS_UPDATE, ref fleU115_INCEXP, fleF110_COMPENSATION.At("DOC_NBR"), SubFileType.Keep, SubFileMode.Append, fleF110_COMPENSATION, "DOC_NBR",
                    COMP_CODE, REPORTING_SEQ, COMP_CODE_GROUP, REC_TYPE, AMT_NET, AMT_GROSS, DEBUG_NOTE);


                // YTDEAR
                DOC_YTDEAR_PLUS_AMT_MANPAY.Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDEAR") + AMT_MANPAY.Value;
                COMP_CODE.Value = X_COMP_CODE_YTDEAR.Value;
                REPORTING_SEQ.Value = YTDEAR_SEQ_RPT.Value;
                COMP_CODE_GROUP.Value = YTDEAR_GROUP.Value;
                REC_TYPE.Value = X_REC_TYPE.Value;
                AMT_GROSS.Value = DOC_YTDEAR_PLUS_AMT_MANPAY.Value;
                AMT_NET.Value = X_NOT_NEEDED.Value;
                DEBUG_NOTE.Value = "Generated by: MP_u115A - YTDEAR";
                SubFile(ref m_trnTRANS_UPDATE, ref fleF119_YTDEAR, fleF110_COMPENSATION.At("DOC_NBR"), SubFileType.Keep, SubFileMode.Append, fleF110_COMPENSATION, "DOC_NBR",
                    COMP_CODE, REPORTING_SEQ, COMP_CODE_GROUP, REC_TYPE, AMT_NET, AMT_GROSS, DEBUG_NOTE);


                SubFile(ref m_trnTRANS_UPDATE, ref fleDEBUG_U115A_AT_COMP_CODE, SubFileType.Keep, fleF110_COMPENSATION, "AMT_GROSS", "AMT_NET", "COMP_CODE", fleF190_COMP_CODES, "COMP_TYPE", "COMP_SUB_TYPE",
                fleCONSTANTS_MSTR_REC_6, "CURRENT_EP_NBR", fleF110_COMPENSATION, "DOC_NBR", fleF020_DOCTOR_MSTR, "DOC_DEPT_EXPENSE_PERCENT_REG", "DOC_DEPT_EXPENSE_PERCENT_MISC", "DOC_IND_PAYS_GST", "DOC_RMA_EXPENSE_PERCENT_MISC", "DOC_RMA_EXPENSE_PERCENT_REG",
                fleF110_COMPENSATION, "EP_NBR", GST_PERCENT, X_INCOME_GROSS_MINUS_NET, X_AMT_DEPT_EXPENSE_POT_G, X_AMT_DEPT_EXPENSE_G, X_AMT_GST_POT_G, X_AMT_GST_ONLY, X_AMT_RMA_EXPENSE_ONLY, X_AMT_RMA_EXPENSE_POT_G,
                X_AMT_RMA_EXPENSE_PLUS_GST_G, X_AMT_HOLDBACK_G, X_AMT_HOLDBACK_FINAL, X_AMT_RMA_EXPENSE_FINAL, X_AMT_RMA_EXPENSE_PLUSGST_FINAL);



                SubFile(ref m_trnTRANS_UPDATE, ref fleDEBUG_U115A_AT_DOC_NBR, fleF110_COMPENSATION.At("DOC_NBR"), SubFileType.Keep, fleF110_COMPENSATION, "DOC_NBR", TOT_INCOME_GROSS_REG, TOT_INCOME_GROSS_MISC, TOT_INCOME_NET_REG, TOT_INCOME_NET_MISC,
                TOT_DEPT_EXPENSE_REG, TOT_DEPT_EXPENSE_MISC, TOT_RMA_EXPENSE_PLUS_GST_REG, TOT_RMA_EXPENSE_PLUS_GST_MISC, TOT_RMA_EXPENSE_ONLY_REG, TOT_RMA_EXPENSE_ONLY_MISC, TOT_GST_ONLY_REG, TOT_GST_ONLY_MISC, TOT_HOLDBACK_ONLY_REG, TOT_HOLDBACK_ONLY_MISC,
                TOT_REVHBK, AMT_MANPAY, FINAL_ALL_EXPENSES, AMT_INCOME_MINUS_EXPENSES_G, DOC_YTDEAR_PLUS_AMT_MANPAY, fleF020_DOCTOR_MSTR, "DOC_YTDEAR");


                Reset(ref TOT_INCOME_GROSS_REG, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref TOT_INCOME_GROSS_MISC, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref TOT_INCOME_NET_REG, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref TOT_INCOME_NET_MISC, fleF110_COMPENSATION.At("DOC_NBR"));
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
            EndRequest("U115_RUN_0_11");

        }

    }







    #endregion


}
//U115_RUN_0_11




