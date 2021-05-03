
#region "Screen Comments"

// #> PROGRAM-ID.     U030B.QTS
// ((C)) Dyad Technologies
// PROGRAM PURPOSE : SECOND PASS OF U030
// THIS IS THE MAIN PROGRAM OF THE ORIGINAL
// U030.CB
// MODIFICATION HISTORY
// DATE   WHO          DESCRIPTION
// 91/FEB/20 M.C.         - ORIGINAL (SMS 138)
// 91/JUL/27 M.C.         - PDR 511
// - ADD TWO NEW REQUESTS IN THE BEGINNING
// EDIT AND SORT RECORDS
// 91/OCT/01 M.C.         - PDR 520
// - ADD TWO NEW REQUESTS BETWEEN REQUESTS
// `CREATE_ISAM_DTL` AND `MATCH_DTL`
// - TRY TO MATCH RAT DTL WITH EQUIVALENCE
// TABLE FOR THE DTL THAT DO NOT MATCH TO
// CLAIM MSTR
// - ADD NEW FIELD `PART-DTL-EQUIV-FLAG` IN
// PART-PAID-DTL RECORD
// - SAVE `X-BAL-FLAG` IN U030_NO_ADJ SUBFILE.
// 91/DEC/16 M.C.         - ADD SEL IF CONDITION IN MATCH_DTL REQUEST
// - ADD SELECTION AND STORE TWO MORE FIELDS
// IN THE SUBFILE IN SORT_BEFORE_ADJ REQUEST
// - COMMENT THE LINKAGE TO F002-CLMHDR AND
// SOME DEFINE STATEMENTS AND SELECTION
// CONDITION IN  SORT_BEFORE_ADJ REQUEST
// - COMMENT THE LINKAGE TO F002-CLMDTL AND
// SOME DEFINE STATEMENTS AND SELECTION
// CONDITION IN CREATE_B_ADJUSTMENT REQUEST
// - IN CREATE_B_ADJUSTMENT REQUEST, CREATE
// A NEW SUBFILE TO STORE ALL ADJUSTED
// BATCHES
// - ADD A NEW REQUEST TO UPDATE THE ADJUSTED
// BATCHES INTO THE INTERMEDIATE FILE
// PART_ADJ_BATCH
// 92/MAR/20 M.C.         - PDR 550
// - AGENT 4 CLAIMS GOT PROCESSED IN TAPE,
// MODIFY REQUEST `EXTRACT-CLAIMS`, TO
// UPDATE CLAIMS MSTR AND/OR CREATE
// PART-PAID-HDR FOR AGENT 4 AS WELL
// 92/AUG/17 M.C.         - TAKE OUT THE SELECTION CRITERIA  IN
// MATCH_DTL REQUEST
// 93/FEB/19 M.C.         - PDR 560 - WHEN CREATING THE ADJUSTMENT
// USE THE DOC-DEPT INSTEAD OF THE DEPT OF
// THE ORIGINAL CLAIM DEPT
// 93/AUG/10 M.C.         - PDR 565 - SET THE CLMDTL-LINE-NO
// 93/SEP/02 M.C.         - SMS 143 - EXTEND THE FILE DEFINITION
// IN PART-PAID-HDR AND
// PART-PAID-DTL FILE TO STORE
// THE NECESSARY INFO FOR RU030B
// REPORT
// 94/JAN/06 M.C.         - SMS 144 - INCLUDE THE LOGIC FOR SOCIAL
// CONTRACT ADJUSTMENT (IE. HOLD
// BACK OR OVERPAY)
// 94/FEB/01 M.C.         - COMMENT OUT THE REQUEST `CREATE_DUMMY_
// SERV_CODE`, DO NOT CREATE AUTO ADJUSTMENT
// FOR DUMMY CODE Y999A, REPORT ON THE NEW
// REPORT FOR MANUALLY ADJUSTMENT BY USER
// 94/FEB/21 M.C.         - SUBTOTAL THE OUTSTANDING BALANCE BY CLAIM
// AND UPDATE TO THE CLAIM HEADER IN A NEW
// SEPARATE REQUEST
// 94/AUG/03 M.C.         - SMS 146 - CHECK THE APPROPRIATE SOCIAL
// CONTRACT REDUCTION FACTOR BASED
// ON THE SERVICE DATE
// 95/APR/25 M.C.         - PDR 615 - PRESET THE AGENT  OF AUTOMATIC
// ADJUSTMENT CLAIM TO BE THE SAME
// AS THE ORIGINAL CLAIM
// - PRESET THE BATCTRL AGENT OF THE
// AUTOMATIC ADJUSTMENT TO BE THE
// SAME AS THE LAST CLAIM IN THE
// BATCH
// 96/MAR/11 M.C.         - PDR 637 - UPDATE OHIP CLAIM NBR INTO
// F002-CLAIMS-EXTRA IN PROCEDURE
// HOLD_CLAIM_STATUS
// 96/OCT/08 M.C.         - MODIFY REQUEST `EXTRACT_CLAIMS` TO ADD
// CLMHDR-AGENT-CD IN U030_PAID_AMT SUBFILE
// - MODIFY REQUEST `UPDATE_CASH_MSTR` TO USE
// CLMHDR-AGENT-CD TO LINK F051-DOC-CASH-MSTR
// 97/APR/14 YAS.         - PDR 656 - NEW CLINIC 82 - NO AUTO ADJUST
// 97/AUG/06 YAS.         - PDR 664 - NEW CLINIC 83 - NO AUTO ADJUST
// 97/DEC/03 M.C.         - PDR 663 - ADD TO LINK TO F099 FILE
// SUBSTITUTE RAT-145-GROUP-NBR WITH X-GROUP-NBR
// FROM REQUEST EXTRACT_CLAIMS AND ONWARD
// 98/MAR/25 YAS.         - PDR 668 - ADD CLINIC 80
// 98/Sep/10 B.E.      - for clinic 60-65, if ohip no-payment reason code
// is 80 and auto adjustment created should affect
// only techical portion of claim.
// 1999/May/21 S.B.        - Added the use file
// def_batctrl_batch_status.def to 
// prevent hardcoding of batctrl-batch-status.
// 1999/May/31 S.B.        - Added the use file
// def_clmhdr_status_ohip.def to 
// prevent hard coding of clmhdr-status-ohip.
// 1999/oct/20 B.E.      - y2k format of date assignments changed from 6 to 8
// 1999/dec/20 M.C.      - create P key when creating f002 hdr/dtl adjustment
// 2000/feb/14 M.C.      - correct the formula when creating p key dtl record 
// 2001/feb/06 M.C.      - Yas requests to update MOH`s claim number with all
// claims.  Modify request extract_claims and 
// hold_claim_status
// 2001/nov/16 B.E.   - transfer last `request` from u030b to u030bb to 
// reduce complexity/size of u030b
// 2002/sep/05 yas.   - add new linic 95 (AA2K)
// 2002/sep/09 M.C.   - undo the transfer done on 2001/nov/16 by Brad
// - transfer back the first `request`from u030bb to u030b for
// updating amount in clmhdr
// - u030b_special2.qts has already included this logic 
// of updating clmhdr amount.  
// If u030b_special1/2.qts are run to replace u030b.qts,
// currently update clmhdr amount will be double.
// jun/02/04    yas   - add new clinics AA5V AA5W AA5X AA5Y 6317
// 2003/oct/22 M.C.   - Mary Ann/Yasemin requested not to automatically adjust
// if department = 26 and reason code = D7 or 35
// 2003/nov/04 M.C.   - Mary Ann/Yasemin requested not to automatically adjust
// if department = 26 only           
// 2003/nov/12 M.C.   - comment out the clinics when creating u030_auto_adj or
// u030_no_adj subfiles, they are redundant codes, they 
// can determine based on the values defined for each limit
// for each clinic in the constants mstr
// 2003/dec/12 A.A.   - alpha doctor nbr
// 2006/mar/21 M.C.   - create a new temp x-explan-cd to evaluate the non blank
// explan cd for each claim, update to part-paid-hdr and
// f002-claims-mstr (hdr) 
// 2006/jul/27 M.C.   - Lori and Linda O`Hara requested not to auto adjust if the
// claim is underpaid with greater than one dollar and with blank
// reason code  
// 2007/feb/06 M.C.   - Lori has requested more conditions for clinic 61 to have auto
// adjustment created
// 2007/may/01 M.C.   - create and calculate amt tech based on clmdtl-amt-tech-billed instead of
// clmhdr-amt-tech-billed
// 2007/may/01 M.C.   - change the x-part-bal to be clmhdr-tot-claim-ar-ohip + clmhdr-manual-tape-payments
// and x-bal-diff to have condition check
// 2007/sep/12 M.C.   - apply clinic 71 to 75 to the same as clinic 60`s with reason code 80
// 2008/apr/09 M.C.   - reason 35 with zero amt paid did not auto adjusted even though it met
// the criteria, records shown in ru030e for user to do manual adjustment
// - modify definition to include zero amt paid to determine balance due (x-bal-diff)
// 2008/aug/05 M.C.   - As per Thekla`s request - If reason code is = 30 - Not a Benefit of OHIP and service code is
// E014C, E009C, E019C, E007C and E018C, please automatically adjust.
// - but after investigation, we cannot check with service code as the determination of B adjustment
// is based on the claim header not detail; hence Thekla agreed to only check with reason cd = `30`
// - Based on the result of RA run on July 10, 2008, the claims that have reason code =`30` is the
// only reason cd for the whole claim.
// 2010/feb/10 MC1    - include clinic 66
// 2010/Apr/07 MC1    - use set lock record update
// 2012/Jan/25 MC2    - modify the criteria for automatic adjustment in determine_adjustment request 
// 2012/Feb/09 MC3    - reinstate the update to the original claim hdr for claim balance in create_b_adjustment request
// and comment out the update_claim_bal request
// 2012/Apr/02 MC4    - for some reason, receive `record has changed since you found it` when update f002-clmhdr
// - think the sequence of the field update is important
// 2012/Apr/04 MC5    - receive `record has changed since you found it` when update f002-clmhdr
// - based on investigation, if the claim has more one adjustment detail to be made and the batch count
// has changed, then error receive. Always happen when the last adjustment claim is 99 and subsequent
// adjustment claim is 01 or more
// 2012/May/08 MC6    - more records receive `record has changed since you found it` when update f002-clmhdr for this month run
// - modify to reinstate the update of f002-clmhdr to the last request; so that the error should be eliminated
// - also, in request create_isam_dtl, for the last two month run, receive error
// `record has changed since you found it`, it is very annoying even though there were no change.
// Looking at the log, it did not seem to sort the file correctly; suspect that at the execution time,
// there were not enough sort space in /charly/tmp directory; hence will modify to extract the necessary 
// items in new request before sorting the records  
// 2012/Jun/19 MC7    - modify the last request to use u030bradadj instead of u030_update_clmhdr and comment out redundant codes
// 2014/Apr/08 MC8    - create 2 new requests to delete records from f002-outstanding based on fully paid claims 
// and auto adjust claims
// 2015/Mar/10 MC9    - correct to delete f002-outstanding at part-hdr-claim-id in the last request
// 2015/Oct/21 MC10   - do not auto adjust if explan-cd = 55 if clinic = 69 as requested by Lori
// 2016/Jan/28 MC11   - modify/add selection criteria for auto adjustment
// 2010/04/07 - MC1
// set lock file update
// 2010/04/07 - end
// ;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;


public class U030B_PART2 : BaseClassControl
{

    private U030B_PART2 m_U030B_PART2;

    public U030B_PART2(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public U030B_PART2(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_U030B_PART2 != null))
        {
            m_U030B_PART2.CloseTransactionObjects();
            m_U030B_PART2 = null;
        }
    }

    public U030B_PART2 GetU030B_PART2(int Level)
    {
        if (m_U030B_PART2 == null)
        {
            m_U030B_PART2 = new U030B_PART2("U030B_PART2", Level);
        }
        else
        {
            m_U030B_PART2.ResetValues();
        }
        return m_U030B_PART2;
    }



    #region "Renaissance Architect Migration Services Default Regions"

    #region "Declarations (Variables, Files and Transactions)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.


    protected SqlConnection m_cnnQUERY = new SqlConnection();
    protected SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();

    protected SqlTransaction m_trnTRANS_UPDATE;


    #endregion


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"

    public override bool RunQTP()
    {


        try
        {

            U030B_PART2_EXTRACT_CLAIMS_1 EXTRACT_CLAIMS_1 = new U030B_PART2_EXTRACT_CLAIMS_1(Name, Level);
            EXTRACT_CLAIMS_1.Run();
            EXTRACT_CLAIMS_1.Dispose();
            EXTRACT_CLAIMS_1 = null;

            U030B_PART2_SPLIT_CLAIMS_2 SPLIT_CLAIMS_2 = new U030B_PART2_SPLIT_CLAIMS_2(Name, Level);
            SPLIT_CLAIMS_2.Run();
            SPLIT_CLAIMS_2.Dispose();
            SPLIT_CLAIMS_2 = null;

            U030B_PART2_UPDATE_CASH_MSTR_3 UPDATE_CASH_MSTR_3 = new U030B_PART2_UPDATE_CASH_MSTR_3(Name, Level);
            UPDATE_CASH_MSTR_3.Run();
            UPDATE_CASH_MSTR_3.Dispose();
            UPDATE_CASH_MSTR_3 = null;

            U030B_PART2_EXTRACT_ISAM_DTL_4 EXTRACT_ISAM_DTL_4 = new U030B_PART2_EXTRACT_ISAM_DTL_4(Name, Level);
            EXTRACT_ISAM_DTL_4.Run();
            EXTRACT_ISAM_DTL_4.Dispose();
            EXTRACT_ISAM_DTL_4 = null;

            U030B_PART2_CREATE_ISAM_DTL_5 CREATE_ISAM_DTL_5 = new U030B_PART2_CREATE_ISAM_DTL_5(Name, Level);
            CREATE_ISAM_DTL_5.Run();
            CREATE_ISAM_DTL_5.Dispose();
            CREATE_ISAM_DTL_5 = null;

            U030B_PART2_UPDATE_PART_HDR_6 UPDATE_PART_HDR_6 = new U030B_PART2_UPDATE_PART_HDR_6(Name, Level);
            UPDATE_PART_HDR_6.Run();
            UPDATE_PART_HDR_6.Dispose();
            UPDATE_PART_HDR_6 = null;

            U030B_PART2_MATCH_CLMDTL_7 MATCH_CLMDTL_7 = new U030B_PART2_MATCH_CLMDTL_7(Name, Level);
            MATCH_CLMDTL_7.Run();
            MATCH_CLMDTL_7.Dispose();
            MATCH_CLMDTL_7 = null;

            U030B_PART2_MATCH_EQUIV_TABLE_8 MATCH_EQUIV_TABLE_8 = new U030B_PART2_MATCH_EQUIV_TABLE_8(Name, Level);
            MATCH_EQUIV_TABLE_8.Run();
            MATCH_EQUIV_TABLE_8.Dispose();
            MATCH_EQUIV_TABLE_8 = null;

            U030B_PART2_DETERMINE_ADJUSTMENT_9 DETERMINE_ADJUSTMENT_9 = new U030B_PART2_DETERMINE_ADJUSTMENT_9(Name, Level);
            DETERMINE_ADJUSTMENT_9.Run();
            DETERMINE_ADJUSTMENT_9.Dispose();
            DETERMINE_ADJUSTMENT_9 = null;

            U030B_PART2_SUMM_CLAIM_SERV_CODE_10 SUMM_CLAIM_SERV_CODE_10 = new U030B_PART2_SUMM_CLAIM_SERV_CODE_10(Name, Level);
            SUMM_CLAIM_SERV_CODE_10.Run();
            SUMM_CLAIM_SERV_CODE_10.Dispose();
            SUMM_CLAIM_SERV_CODE_10 = null;

            U030B_PART2_MATCH_DTL_11 MATCH_DTL_11 = new U030B_PART2_MATCH_DTL_11(Name, Level);
            MATCH_DTL_11.Run();
            MATCH_DTL_11.Dispose();
            MATCH_DTL_11 = null;

            U030B_PART2_GEN_HOLDBACK_OVERPAY_DTL_12 GEN_HOLDBACK_OVERPAY_DTL_12 = new U030B_PART2_GEN_HOLDBACK_OVERPAY_DTL_12(Name, Level);
            GEN_HOLDBACK_OVERPAY_DTL_12.Run();
            GEN_HOLDBACK_OVERPAY_DTL_12.Dispose();
            GEN_HOLDBACK_OVERPAY_DTL_12 = null;

            U030B_PART2_SORT_BY_DIFF_BAL_13 SORT_BY_DIFF_BAL_13 = new U030B_PART2_SORT_BY_DIFF_BAL_13(Name, Level);
            SORT_BY_DIFF_BAL_13.Run();
            SORT_BY_DIFF_BAL_13.Dispose();
            SORT_BY_DIFF_BAL_13 = null;

            U030B_PART2_CALC_BATCH_NBR_14 CALC_BATCH_NBR_14 = new U030B_PART2_CALC_BATCH_NBR_14(Name, Level);
            CALC_BATCH_NBR_14.Run();
            CALC_BATCH_NBR_14.Dispose();
            CALC_BATCH_NBR_14 = null;

            U030B_PART2_CREATE_B_ADJUSTMENT_15 CREATE_B_ADJUSTMENT_15 = new U030B_PART2_CREATE_B_ADJUSTMENT_15(Name, Level);
            CREATE_B_ADJUSTMENT_15.Run();
            CREATE_B_ADJUSTMENT_15.Dispose();
            CREATE_B_ADJUSTMENT_15 = null;

            U030B_PART2_HOLD_CLAIM_STATUS_16 HOLD_CLAIM_STATUS_16 = new U030B_PART2_HOLD_CLAIM_STATUS_16(Name, Level);
            HOLD_CLAIM_STATUS_16.Run();
            HOLD_CLAIM_STATUS_16.Dispose();
            HOLD_CLAIM_STATUS_16 = null;

            U030B_PART2_PART_ADJ_BATCH_17 PART_ADJ_BATCH_17 = new U030B_PART2_PART_ADJ_BATCH_17(Name, Level);
            PART_ADJ_BATCH_17.Run();
            PART_ADJ_BATCH_17.Dispose();
            PART_ADJ_BATCH_17 = null;

            U030B_PART2_UPDATE_CLAIM_BAL_18 UPDATE_CLAIM_BAL_18 = new U030B_PART2_UPDATE_CLAIM_BAL_18(Name, Level);
            UPDATE_CLAIM_BAL_18.Run();
            UPDATE_CLAIM_BAL_18.Dispose();
            UPDATE_CLAIM_BAL_18 = null;

            U030B_PART2_DELETE_F002_OUTSTANDING_19 DELETE_F002_OUTSTANDING_19 = new U030B_PART2_DELETE_F002_OUTSTANDING_19(Name, Level);
            DELETE_F002_OUTSTANDING_19.Run();
            DELETE_F002_OUTSTANDING_19.Dispose();
            DELETE_F002_OUTSTANDING_19 = null;

            U030B_PART2_DELETE_F002_OUTSTANDING_ADJ_20 DELETE_F002_OUTSTANDING_ADJ_20 = new U030B_PART2_DELETE_F002_OUTSTANDING_ADJ_20(Name, Level);
            DELETE_F002_OUTSTANDING_ADJ_20.Run();
            DELETE_F002_OUTSTANDING_ADJ_20.Dispose();
            DELETE_F002_OUTSTANDING_ADJ_20 = null;

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



public class U030B_PART2_EXTRACT_CLAIMS_1 : U030B_PART2
{

    public U030B_PART2_EXTRACT_CLAIMS_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU030_SORT_145_FILE = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U030_SORT_145_FILE", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_CLAIMS_EXTRA = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_EXTRA", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_TOT_AMT_PAID = new CoreInteger("X_TOT_AMT_PAID", 7, this);
        X_TOT_AMT_BILL = new CoreInteger("X_TOT_AMT_BILL", 7, this);
        X_EXPLAN_CD = new CoreCharacter("X_EXPLAN_CD", 2, this, Common.cEmptyString);
        fleU030_DTL = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U030_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU030_UNMATCH = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U030_UNMATCH", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        flePART_PAID_HDR = new SqlFileObject(this, FileTypes.Primary, 0, "SEQUENTIAL", "PART_PAID_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.TempFile);
        fleU030_PAID_AMT = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U030_PAID_AMT", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
      
        fleF002_CLAIMS_MSTR.SetItemFinals += fleF002_CLAIMS_MSTR_SetItemFinals;
        fleF002_CLAIMS_EXTRA.InitializeItems += fleF002_CLAIMS_EXTRA_InitializeItems;
        fleF002_CLAIMS_EXTRA.SetItemFinals += fleF002_CLAIMS_EXTRA_SetItemFinals;
        X_TYPE.GetValue += X_TYPE_GetValue;
        X_OMA_FOUND.GetValue += X_OMA_FOUND_GetValue;
        X_TECH_AMT.GetValue += X_TECH_AMT_GetValue;
        X_PROF_AMT.GetValue += X_PROF_AMT_GetValue;
        X_OUT_BAL.GetValue += X_OUT_BAL_GetValue;
        X_BAL_DUE.GetValue += X_BAL_DUE_GetValue;
        X_RAT_145_AMT_PAID.GetValue += X_RAT_145_AMT_PAID_GetValue;
        flePART_PAID_HDR.InitializeItems += flePART_PAID_HDR_InitializeItems;
        flePART_PAID_HDR.SetItemFinals += flePART_PAID_HDR_SetItemFinals;
       

    }


    #region "Declarations (Variables, Files and Transactions)(U030B_PART2_EXTRACT_CLAIMS_1)"

    private SqlFileObject fleU030_SORT_145_FILE;
    private SqlFileObject fleF002_CLAIMS_MSTR;

    private void fleF002_CLAIMS_MSTR_SetItemFinals()
    {

        try
        {
            fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_MSG_NBR", (QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8)).PadRight(8).Substring(0, 2));
            //Parent:CLMHDR_DATE_CASH_TAPE_PAYMENT
            fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_REPRINT_FLAG", (QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8)).PadRight(8).Substring(2, 1));
            //Parent:CLMHDR_DATE_CASH_TAPE_PAYMENT
            fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_SUB_NBR", (QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8)).PadRight(8).Substring(3, 1));
            //Parent:CLMHDR_DATE_CASH_TAPE_PAYMENT
            fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_AUTO_LOGOUT", (QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8)).PadRight(8).Substring(4, 1));
            //Parent:CLMHDR_DATE_CASH_TAPE_PAYMENT
            fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_FEE_COMPLEX", (QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8)).PadRight(8).Substring(5, 1));
            //Parent:CLMHDR_DATE_CASH_TAPE_PAYMENT
            fleF002_CLAIMS_MSTR.set_SetValue("FILLER", (QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8)).PadRight(8).Substring(6, 1));
            //Parent:CLMHDR_DATE_CASH_TAPE_PAYMENT
            fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_STATUS_OHIP", flePART_PAID_HDR.GetStringValue("PART_HDR_EXPLAN_CD"));


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

    private SqlFileObject fleF002_CLAIMS_EXTRA;

    private void fleF002_CLAIMS_EXTRA_InitializeItems(bool Fixed)
    {

        try
        {
            if (!Fixed)
                fleF002_CLAIMS_EXTRA.set_SetValue("CLMHDR_RMA_CLM_NBR", true, fleU030_SORT_145_FILE.GetStringValue("X_GROUP_NBR") + fleU030_SORT_145_FILE.GetStringValue("RAT_145_ACCOUNT_NBR"));


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



    private void fleF002_CLAIMS_EXTRA_SetItemFinals()
    {

        try
        {
            fleF002_CLAIMS_EXTRA.set_SetValue("CLMHDR_OHIP_CLM_NBR", fleU030_SORT_145_FILE.GetStringValue("RAT_145_CLAIM_NBR"));


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

    private DCharacter X_TYPE = new DCharacter("X_TYPE", 1);
    private void X_TYPE_GetValue(ref string Value)
    {

        try
        {
            Value = "H";


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
    private DCharacter X_OMA_FOUND = new DCharacter("X_OMA_FOUND", 1);
    private void X_OMA_FOUND_GetValue(ref string Value)
    {

        try
        {
            Value = "Y";


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
    private DInteger X_TECH_AMT = new DInteger("X_TECH_AMT", 7);
    private void X_TECH_AMT_GetValue(ref decimal Value)
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
    private DInteger X_PROF_AMT = new DInteger("X_PROF_AMT", 7);
    private void X_PROF_AMT_GetValue(ref decimal Value)
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
    private DInteger X_OUT_BAL = new DInteger("X_OUT_BAL", 7);
    private void X_OUT_BAL_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_MANUAL_AND_TAPE_PAYMENTS") + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP");


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
    private DCharacter X_BAL_DUE = new DCharacter("X_BAL_DUE", 1);
    private void X_BAL_DUE_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(X_OUT_BAL.Value) != 0)
            {
                CurrentValue = "Y";
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
    private DInteger X_RAT_145_AMT_PAID = new DInteger("X_RAT_145_AMT_PAID", 7);
    private void X_RAT_145_AMT_PAID_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleU030_SORT_145_FILE.GetDecimalValue("RAT_145_AMT_PAID") * -1;


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
    private CoreInteger X_TOT_AMT_PAID;
    private CoreInteger X_TOT_AMT_BILL;
    private CoreCharacter X_EXPLAN_CD;
    private SqlFileObject fleU030_DTL;
    private SqlFileObject fleU030_UNMATCH;
    private SqlFileObject flePART_PAID_HDR;

    private void flePART_PAID_HDR_InitializeItems(bool Fixed)
    {

        try
        {
            if (!Fixed)
                flePART_PAID_HDR.set_SetValue("PART_HDR_CLINIC_NBR", true, QDesign.NConvert(fleU030_SORT_145_FILE.GetStringValue("X_GROUP_NBR")));
            if (!Fixed)
                flePART_PAID_HDR.set_SetValue("PART_HDR_CLAIM_NBR", true, fleU030_SORT_145_FILE.GetStringValue("RAT_145_ACCOUNT_NBR"));
            if (!Fixed)
                flePART_PAID_HDR.set_SetValue("PART_HDR_AMT_BILL", true, fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP"));
            if (!Fixed)
            {
                if (QDesign.NULL(fleU030_SORT_145_FILE.GetStringValue("RAT_145_LAST_NAME")) != QDesign.NULL(" "))
                {
                    flePART_PAID_HDR.set_SetValue("PART_HDR_LAST_NAME", true, fleU030_SORT_145_FILE.GetStringValue("RAT_145_LAST_NAME"));
                }
                else
                {
                    flePART_PAID_HDR.set_SetValue("PART_HDR_LAST_NAME", true, QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_ACRONYM6") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_ACRONYM3"), 1, 6));
                    //Parent:CLMHDR_PAT_ACRONYM
                }
            }
            if (!Fixed)
            {
                if (QDesign.NULL(fleU030_SORT_145_FILE.GetStringValue("RAT_145_FIRST_NAME")) != QDesign.NULL(" "))
                {
                    flePART_PAID_HDR.set_SetValue("PART_HDR_FIRST_NAME", true, fleU030_SORT_145_FILE.GetStringValue("RAT_145_FIRST_NAME"));
                }
                else
                {
                    flePART_PAID_HDR.set_SetValue("PART_HDR_FIRST_NAME", true, QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_ACRONYM6") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_ACRONYM3"), 7, 3));
                    //Parent:CLMHDR_PAT_ACRONYM
                }
            }
            if (!Fixed)
                flePART_PAID_HDR.set_SetValue("PART_HDR_OHIP_CLM_NBR", true, fleU030_SORT_145_FILE.GetStringValue("RAT_145_CLAIM_NBR"));
            if (!Fixed)
                flePART_PAID_HDR.set_SetValue("PART_HDR_VERSION_CD", true, fleU030_SORT_145_FILE.GetStringValue("RAT_145_VERSION_CD"));
            if (!Fixed)
                flePART_PAID_HDR.set_SetValue("PART_HDR_PAY_PGM", true, fleU030_SORT_145_FILE.GetStringValue("RAT_145_PAY_PROG"));
            if (!Fixed)
                flePART_PAID_HDR.set_SetValue("PART_HDR_REGISTER_NBR", true, fleU030_SORT_145_FILE.GetStringValue("RAT_145_HEALTH_OHIP_NBR"));


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



    private void flePART_PAID_HDR_SetItemFinals()
    {

        try
        {
            flePART_PAID_HDR.set_SetValue("PART_HDR_AMT_PAID", X_TOT_AMT_PAID.Value);
            flePART_PAID_HDR.set_SetValue("PART_HDR_OHIP_BILL", X_TOT_AMT_BILL.Value);
            flePART_PAID_HDR.set_SetValue("PART_HDR_EXPLAN_CD", X_EXPLAN_CD.Value);


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
    
    private SqlFileObject fleU030_PAID_AMT;
   


    #endregion


    #region "Standard Generated Procedures(U030B_PART2_EXTRACT_CLAIMS_1)"


    #region "Automatic Item Initialization(U030B_PART2_EXTRACT_CLAIMS_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

   


    #endregion


    #region "Transaction Management Procedures(U030B_PART2_EXTRACT_CLAIMS_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:47:29 PM

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
        fleU030_SORT_145_FILE.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_EXTRA.Transaction = m_trnTRANS_UPDATE;
        fleU030_DTL.Transaction = m_trnTRANS_UPDATE;
        fleU030_UNMATCH.Transaction = m_trnTRANS_UPDATE;
        flePART_PAID_HDR.Transaction = m_trnTRANS_UPDATE;
        fleU030_PAID_AMT.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U030B_PART2_EXTRACT_CLAIMS_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:47:29 PM

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
            fleU030_SORT_145_FILE.Dispose();
            fleF002_CLAIMS_MSTR.Dispose();
            fleF002_CLAIMS_EXTRA.Dispose();
            fleU030_DTL.Dispose();
            fleU030_UNMATCH.Dispose();
            flePART_PAID_HDR.Dispose();
            fleU030_PAID_AMT.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U030B_PART2_EXTRACT_CLAIMS_1)"


    public void Run()
    {

        try
        {
            Request("EXTRACT_CLAIMS_1");

            while (fleU030_SORT_145_FILE.QTPForMissing())
            {
                // --> GET U030_SORT_145_FILE <--

                fleU030_SORT_145_FILE.GetData();
                // --> End GET U030_SORT_145_FILE <--

                while (fleF002_CLAIMS_MSTR.QTPForMissing("1"))
                {
                    // --> GET F002_CLAIMS_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("B"));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleU030_SORT_145_FILE.GetStringValue("X_GROUP_NBR") + QDesign.Substring(fleU030_SORT_145_FILE.GetStringValue("RAT_145_ACCOUNT_NBR"), 1, 6)));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ");
                    m_strWhere.Append(QDesign.NConvert(QDesign.Substring(fleU030_SORT_145_FILE.GetStringValue("RAT_145_ACCOUNT_NBR"), 7, 2)));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_SERV_CODE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("00000"));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_ADJ_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("0"));

                    fleF002_CLAIMS_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F002_CLAIMS_MSTR <--

                    while (fleF002_CLAIMS_EXTRA.QTPForMissing("2"))
                    {
                        // --> GET F002_CLAIMS_EXTRA <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF002_CLAIMS_EXTRA.ElementOwner("CLMHDR_RMA_CLM_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleU030_SORT_145_FILE.GetStringValue("X_GROUP_NBR") + fleU030_SORT_145_FILE.GetStringValue("RAT_145_ACCOUNT_NBR")));

                        fleF002_CLAIMS_EXTRA.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F002_CLAIMS_EXTRA <--


                        if (Transaction())
                        {

                            Sort(fleU030_SORT_145_FILE.GetSortValue("X_GROUP_NBR"), fleU030_SORT_145_FILE.GetSortValue("RAT_145_ACCOUNT_NBR"), fleU030_SORT_145_FILE.GetSortValue("RAT_145_EXPLAN_CD", SortType.Descending));



                        }

                    }

                }

            }

            while (Sort(fleU030_SORT_145_FILE, fleF002_CLAIMS_MSTR, fleF002_CLAIMS_EXTRA))
            {
                if ((fleF002_CLAIMS_MSTR.Exists() & (QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 | QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_AGENT_CD")) == 2 | QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_AGENT_CD")) == 4)))
                {
                    SubTotal(ref X_TOT_AMT_PAID, fleU030_SORT_145_FILE.GetDecimalValue("RAT_145_AMT_PAID"));
                }
                if ((fleF002_CLAIMS_MSTR.Exists() & (QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 | QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_AGENT_CD")) == 2 | QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_AGENT_CD")) == 4)))
                {
                    SubTotal(ref X_TOT_AMT_BILL, fleU030_SORT_145_FILE.GetDecimalValue("RAT_145_AMOUNT_SUB"));
                }
                if (QDesign.NULL(fleU030_SORT_145_FILE.GetStringValue("RAT_145_EXPLAN_CD")) != QDesign.NULL(" "))
                {
                    X_EXPLAN_CD.Value = fleU030_SORT_145_FILE.GetStringValue("RAT_145_EXPLAN_CD");
                }
                else
                {
                    X_EXPLAN_CD.Value = X_EXPLAN_CD.Value;
                }
               
                SubFile(ref m_trnTRANS_UPDATE, ref fleU030_DTL, (fleF002_CLAIMS_MSTR.Exists() & (QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 | QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_AGENT_CD")) == 2 | QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_AGENT_CD")) == 4)), SubFileType.KeepSQL, fleU030_SORT_145_FILE);

                SubFile(ref m_trnTRANS_UPDATE, ref fleU030_UNMATCH, (!fleF002_CLAIMS_MSTR.Exists() | (QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_AGENT_CD")) != 0 & QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_AGENT_CD")) != 2 & QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_AGENT_CD")) != 4)), SubFileType.KeepSQL, SubFileMode.Append, fleU030_SORT_145_FILE, X_TYPE, X_OMA_FOUND, X_TECH_AMT, X_PROF_AMT);

                SubTotal(ref fleF002_CLAIMS_MSTR, "CLMHDR_MANUAL_AND_TAPE_PAYMENTS", X_RAT_145_AMT_PAID.Value);

                flePART_PAID_HDR.OutPut(OutPutType.Add, fleU030_SORT_145_FILE.At("RAT_145_ACCOUNT_NBR"), (QDesign.NULL(X_BAL_DUE.Value) == "Y" & fleF002_CLAIMS_MSTR.Exists() & (QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 | QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_AGENT_CD")) == 2 | QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_AGENT_CD")) == 4)));

                fleF002_CLAIMS_MSTR.OutPut(OutPutType.Update, fleU030_SORT_145_FILE.At("RAT_145_ACCOUNT_NBR"), (fleF002_CLAIMS_MSTR.Exists() & (QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 | QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_AGENT_CD")) == 2 | QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_AGENT_CD")) == 4)));

                fleF002_CLAIMS_EXTRA.OutPut(OutPutType.Add_Update, fleU030_SORT_145_FILE.At("RAT_145_ACCOUNT_NBR"), (fleF002_CLAIMS_MSTR.Exists() & (QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 | QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_AGENT_CD")) == 2 | QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_AGENT_CD")) == 4)));

                SubFile(ref m_trnTRANS_UPDATE, ref fleU030_PAID_AMT, fleU030_SORT_145_FILE.At("RAT_145_ACCOUNT_NBR"), (fleF002_CLAIMS_MSTR.Exists() & (QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 | QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_AGENT_CD")) == 2 | QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_AGENT_CD")) == 4)), SubFileType.KeepSQL, fleU030_SORT_145_FILE, "X_GROUP_NBR", "RAT_145_ACCOUNT_NBR", fleF002_CLAIMS_MSTR, "CLMHDR_DOC_DEPT",
                "CLMHDR_LOC", X_TOT_AMT_PAID, X_TOT_AMT_BILL, "CLMHDR_AGENT_CD");

             
                Reset(ref X_TOT_AMT_PAID, fleU030_SORT_145_FILE.At("RAT_145_ACCOUNT_NBR"));
                Reset(ref X_TOT_AMT_BILL, fleU030_SORT_145_FILE.At("RAT_145_ACCOUNT_NBR"));
                Reset(ref X_EXPLAN_CD, fleU030_SORT_145_FILE.At("RAT_145_ACCOUNT_NBR"));
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
            EndRequest("EXTRACT_CLAIMS_1");

        }

    }




    #endregion


}
//EXTRACT_CLAIMS_1



public class U030B_PART2_SPLIT_CLAIMS_2 : U030B_PART2
{

    public U030B_PART2_SPLIT_CLAIMS_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU030_PAID_AMT = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U030_PAID_AMT", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        flePART_PAID_HDR = new SqlFileObject(this, FileTypes.Primary, 0, "SEQUENTIAL", "PART_PAID_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.TempFile);
        fleU030_FULLY_PAID = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U030_FULLY_PAID", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU030_PARTIALLY_PAID = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U030_PARTIALLY_PAID", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);


    }


    #region "Declarations (Variables, Files and Transactions)(U030B_PART2_SPLIT_CLAIMS_2)"

    private SqlFileObject fleU030_PAID_AMT;
    private SqlFileObject flePART_PAID_HDR;
    private SqlFileObject fleU030_FULLY_PAID;
    private SqlFileObject fleU030_PARTIALLY_PAID;


    #endregion


    #region "Standard Generated Procedures(U030B_PART2_SPLIT_CLAIMS_2)"


    #region "Automatic Item Initialization(U030B_PART2_SPLIT_CLAIMS_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U030B_PART2_SPLIT_CLAIMS_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:47:30 PM

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
        fleU030_PAID_AMT.Transaction = m_trnTRANS_UPDATE;
        flePART_PAID_HDR.Transaction = m_trnTRANS_UPDATE;
        fleU030_FULLY_PAID.Transaction = m_trnTRANS_UPDATE;
        fleU030_PARTIALLY_PAID.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U030B_PART2_SPLIT_CLAIMS_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:47:30 PM

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
            fleU030_PAID_AMT.Dispose();
            flePART_PAID_HDR.Dispose();
            fleU030_FULLY_PAID.Dispose();
            fleU030_PARTIALLY_PAID.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U030B_PART2_SPLIT_CLAIMS_2)"


    public void Run()
    {

        try
        {
            Request("SPLIT_CLAIMS_2");

            while (fleU030_PAID_AMT.QTPForMissing())
            {
                // --> GET U030_PAID_AMT <--

                fleU030_PAID_AMT.GetData();
                // --> End GET U030_PAID_AMT <--

                while (flePART_PAID_HDR.QTPForMissing("1"))
                {
                    // --> GET PART_PAID_HDR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(flePART_PAID_HDR.ElementOwner("PART_HDR_CLINIC_NBR")).Append(" = ");
                    m_strWhere.Append(fleU030_PAID_AMT.GetDecimalValue("X_GROUP_NBR"));
                    //Parent:PART_HDR_CLAIM_ID
                    m_strWhere.Append(" AND ").Append(flePART_PAID_HDR.ElementOwner("PART_HDR_CLAIM_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleU030_PAID_AMT.GetStringValue("RAT_145_ACCOUNT_NBR")));
                    //Parent:PART_HDR_CLAIM_ID

                    flePART_PAID_HDR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET PART_PAID_HDR <--

                    if (Transaction())
                    {
                        SubFile(ref m_trnTRANS_UPDATE, ref fleU030_FULLY_PAID, !flePART_PAID_HDR.Exists(), SubFileType.KeepSQL, fleU030_PAID_AMT);

                        SubFile(ref m_trnTRANS_UPDATE, ref fleU030_PARTIALLY_PAID, flePART_PAID_HDR.Exists(), SubFileType.KeepSQL, fleU030_PAID_AMT);
                    }
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
            EndRequest("SPLIT_CLAIMS_2");

        }

    }




    #endregion


}
//SPLIT_CLAIMS_2



public class U030B_PART2_UPDATE_CASH_MSTR_3 : U030B_PART2
{

    public U030B_PART2_UPDATE_CASH_MSTR_3(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU030_PAID_AMT = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U030_PAID_AMT", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF051_DOC_CASH_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F051_DOC_CASH_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF051_DOC_CASH_MSTR.InitializeItems += fleF051_DOC_CASH_MSTR_InitializeItems;

    }


    #region "Declarations (Variables, Files and Transactions)(U030B_PART2_UPDATE_CASH_MSTR_3)"

    private SqlFileObject fleU030_PAID_AMT;
    private SqlFileObject fleF051_DOC_CASH_MSTR;

    private void fleF051_DOC_CASH_MSTR_InitializeItems(bool Fixed)
    {

        try
        {
            if (!Fixed)
                fleF051_DOC_CASH_MSTR.set_SetValue("DOCASH_MTD_IN_SVC", true, 0);
            if (!Fixed)
                fleF051_DOC_CASH_MSTR.set_SetValue("DOCASH_YTD_IN_SVC", true, 0);


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


    #region "Standard Generated Procedures(U030B_PART2_UPDATE_CASH_MSTR_3)"


    #region "Automatic Item Initialization(U030B_PART2_UPDATE_CASH_MSTR_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U030B_PART2_UPDATE_CASH_MSTR_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:47:30 PM

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
        fleU030_PAID_AMT.Transaction = m_trnTRANS_UPDATE;
        fleF051_DOC_CASH_MSTR.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U030B_PART2_UPDATE_CASH_MSTR_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:47:30 PM

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
            fleU030_PAID_AMT.Dispose();
            fleF051_DOC_CASH_MSTR.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U030B_PART2_UPDATE_CASH_MSTR_3)"


    public void Run()
    {

        try
        {
            Request("UPDATE_CASH_MSTR_3");

            while (fleU030_PAID_AMT.QTPForMissing())
            {
                // --> GET U030_PAID_AMT <--

                fleU030_PAID_AMT.GetData();
                // --> End GET U030_PAID_AMT <--

                while (fleF051_DOC_CASH_MSTR.QTPForMissing("1"))
                {
                    // --> GET F051_DOC_CASH_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF051_DOC_CASH_MSTR.ElementOwner("DOCASH_CLINIC_1_2")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleU030_PAID_AMT.GetStringValue("X_GROUP_NBR")));
                    m_strWhere.Append(" AND ").Append(fleF051_DOC_CASH_MSTR.ElementOwner("DOCASH_DEPT")).Append(" = ");
                    m_strWhere.Append(fleU030_PAID_AMT.GetDecimalValue("CLMHDR_DOC_DEPT"));
                    m_strWhere.Append(" AND ").Append(fleF051_DOC_CASH_MSTR.ElementOwner("DOCASH_DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(QDesign.Substring(fleU030_PAID_AMT.GetStringValue("RAT_145_ACCOUNT_NBR"), 1, 3)));
                    m_strWhere.Append(" AND ").Append(fleF051_DOC_CASH_MSTR.ElementOwner("DOCASH_LOCATION")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleU030_PAID_AMT.GetStringValue("CLMHDR_LOC")));
                    m_strWhere.Append(" AND ").Append(fleF051_DOC_CASH_MSTR.ElementOwner("DOCASH_AGENCY_TYPE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleU030_PAID_AMT.GetStringValue("CLMHDR_AGENT_CD")));

                    m_strOrderBy = new StringBuilder(" ORDER BY ");
                    m_strOrderBy.Append(fleF051_DOC_CASH_MSTR.ElementOwner("DOCASH_CLINIC_1_2")).Append(", ")
                        .Append(fleF051_DOC_CASH_MSTR.ElementOwner("DOCASH_DEPT")).Append(", ")
                        .Append(fleF051_DOC_CASH_MSTR.ElementOwner("DOCASH_DOC_NBR")).Append(", ")
                        .Append(fleF051_DOC_CASH_MSTR.ElementOwner("DOCASH_LOCATION")).Append(", ")
                        .Append(fleF051_DOC_CASH_MSTR.ElementOwner("DOCASH_AGENCY_TYPE"));

                    fleF051_DOC_CASH_MSTR.GetData(m_strWhere.ToString(), m_strOrderBy.ToString());
                    // --> End GET F051_DOC_CASH_MSTR <--



                    SubTotal(ref fleF051_DOC_CASH_MSTR, "DOCASH_MTD_IN_REC", fleU030_PAID_AMT.GetDecimalValue("X_TOT_AMT_PAID"));


                    SubTotal(ref fleF051_DOC_CASH_MSTR, "DOCASH_YTD_IN_REC", fleU030_PAID_AMT.GetDecimalValue("X_TOT_AMT_PAID"));

                    fleF051_DOC_CASH_MSTR.OutPut(OutPutType.Add_Update);

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
            EndRequest("UPDATE_CASH_MSTR_3");

        }

    }




    #endregion


}
//UPDATE_CASH_MSTR_3



public class U030B_PART2_EXTRACT_ISAM_DTL_4 : U030B_PART2
{

    public U030B_PART2_EXTRACT_ISAM_DTL_4(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU030_DTL = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U030_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        flePART_PAID_HDR = new SqlFileObject(this, FileTypes.Primary, 0, "SEQUENTIAL", "PART_PAID_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.TempFile);
        fleU030_EXTRACT_DTL = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U030_EXTRACT_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        PART_HDR_CLAIM_ID = new CoreCharacter("PART_HDR_CLAIM_ID", 11, this, Common.cEmptyString);
    }


    #region "Declarations (Variables, Files and Transactions)(U030B_PART2_EXTRACT_ISAM_DTL_4)"

    private SqlFileObject fleU030_DTL;
    private SqlFileObject flePART_PAID_HDR;

    private CoreCharacter PART_HDR_CLAIM_ID;







    private SqlFileObject fleU030_EXTRACT_DTL;


    #endregion


    #region "Standard Generated Procedures(U030B_PART2_EXTRACT_ISAM_DTL_4)"


    #region "Automatic Item Initialization(U030B_PART2_EXTRACT_ISAM_DTL_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U030B_PART2_EXTRACT_ISAM_DTL_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:47:30 PM

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
        fleU030_DTL.Transaction = m_trnTRANS_UPDATE;
        flePART_PAID_HDR.Transaction = m_trnTRANS_UPDATE;
        fleU030_EXTRACT_DTL.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U030B_PART2_EXTRACT_ISAM_DTL_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:47:30 PM

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
            fleU030_DTL.Dispose();
            flePART_PAID_HDR.Dispose();
            fleU030_EXTRACT_DTL.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U030B_PART2_EXTRACT_ISAM_DTL_4)"


    public void Run()
    {

        try
        {
            Request("EXTRACT_ISAM_DTL_4");

            while (fleU030_DTL.QTPForMissing())
            {
                // --> GET U030_DTL <--

                fleU030_DTL.GetData();
                // --> End GET U030_DTL <--

                while (flePART_PAID_HDR.QTPForMissing("1"))
                {
                    // --> GET PART_PAID_HDR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(flePART_PAID_HDR.ElementOwner("PART_HDR_CLINIC_NBR")).Append(" = ");
                    m_strWhere.Append(QDesign.VAL(((fleU030_DTL.GetStringValue("X_GROUP_NBR") + fleU030_DTL.GetStringValue("RAT_145_ACCOUNT_NBR"))).PadRight(10).Substring(0, 2)));
                    //Parent:PART_HDR_CLAIM_ID
                    m_strWhere.Append(" AND ").Append(" ").Append(flePART_PAID_HDR.ElementOwner("PART_HDR_CLAIM_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(((fleU030_DTL.GetStringValue("X_GROUP_NBR") + fleU030_DTL.GetStringValue("RAT_145_ACCOUNT_NBR"))).PadRight(10).Substring(2, 8)));
                    //Parent:PART_HDR_CLAIM_ID

                    m_strOrderBy = new StringBuilder(" ORDER BY ");
                    m_strOrderBy.Append(flePART_PAID_HDR.ElementOwner("PART_HDR_CLINIC_NBR"));
                    //Parent:PART_HDR_CLAIM_ID
                    m_strOrderBy.Append(", ").Append(flePART_PAID_HDR.ElementOwner("PART_HDR_CLAIM_NBR"));
                    //Parent:PART_HDR_CLAIM_ID

                    flePART_PAID_HDR.GetData(m_strWhere.ToString(), m_strOrderBy.ToString());
                    // --> End GET PART_PAID_HDR <--


                    if (Transaction())
                    {
                        PART_HDR_CLAIM_ID.Value = QDesign.ASCII(flePART_PAID_HDR.GetDecimalValue("PART_HDR_CLINIC_NBR")) + flePART_PAID_HDR.GetStringValue("PART_HDR_CLAIM_NBR");
                        SubFile(ref m_trnTRANS_UPDATE, ref fleU030_EXTRACT_DTL, SubFileType.KeepSQL, PART_HDR_CLAIM_ID, fleU030_DTL, "RAT_145_SERVICE_CD", "RAT_145_EXPLAN_CD", "X_GROUP_NBR", "RAT_145_ACCOUNT_NBR",
                            "RAT_145_AMOUNT_SUB", "RAT_145_AMT_PAID", "RAT_145_SERVICE_DATE", "RAT_145_NBR_OF_SERV");


                    }

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
            EndRequest("EXTRACT_ISAM_DTL_4");

        }

    }




    #endregion


}
//EXTRACT_ISAM_DTL_4



public class U030B_PART2_CREATE_ISAM_DTL_5 : U030B_PART2
{

    public U030B_PART2_CREATE_ISAM_DTL_5(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU030_EXTRACT_DTL = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U030_EXTRACT_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        flePART_PAID_DTL = new SqlFileObject(this, FileTypes.Primary, 0, "SEQUENTIAL", "PART_PAID_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.TempFile);
        fleU030_SORT_HDR = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U030_SORT_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        flePART_PAID_DTL.InitializeItems += flePART_PAID_DTL_InitializeItems;
        flePART_PAID_DTL.SetItemFinals += flePART_PAID_DTL_SetItemFinals;

    }


    #region "Declarations (Variables, Files and Transactions)(U030B_PART2_CREATE_ISAM_DTL_5)"

    private SqlFileObject fleU030_EXTRACT_DTL;
    private SqlFileObject flePART_PAID_DTL;

    private void flePART_PAID_DTL_InitializeItems(bool Fixed)
    {

        try
        {
            if (!Fixed)
                flePART_PAID_DTL.set_SetValue("PART_DTL_CLINIC_NBR", true, QDesign.NConvert(fleU030_EXTRACT_DTL.GetStringValue("X_GROUP_NBR")));
            if (!Fixed)
                flePART_PAID_DTL.set_SetValue("PART_DTL_CLAIM_NBR", true, fleU030_EXTRACT_DTL.GetStringValue("RAT_145_ACCOUNT_NBR"));
            if (!Fixed)
                flePART_PAID_DTL.set_SetValue("PART_DTL_OMA_CD", true, fleU030_EXTRACT_DTL.GetStringValue("RAT_145_SERVICE_CD"));
            if (!Fixed)
                flePART_PAID_DTL.set_SetValue("PART_DTL_SERV_DATE", true, fleU030_EXTRACT_DTL.GetDecimalValue("RAT_145_SERVICE_DATE"));
            if (!Fixed)
                flePART_PAID_DTL.set_SetValue("PART_DTL_EQUIV_FLAG", true, " ");


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



    private void flePART_PAID_DTL_SetItemFinals()
    {

        try
        {
            flePART_PAID_DTL.set_SetValue("PART_DTL_EXPLAN_CD", fleU030_EXTRACT_DTL.GetStringValue("RAT_145_EXPLAN_CD"));


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
























    private SqlFileObject fleU030_SORT_HDR;


    #endregion


    #region "Standard Generated Procedures(U030B_PART2_CREATE_ISAM_DTL_5)"


    #region "Automatic Item Initialization(U030B_PART2_CREATE_ISAM_DTL_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U030B_PART2_CREATE_ISAM_DTL_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:47:31 PM

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
        fleU030_EXTRACT_DTL.Transaction = m_trnTRANS_UPDATE;
        flePART_PAID_DTL.Transaction = m_trnTRANS_UPDATE;
        fleU030_SORT_HDR.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U030B_PART2_CREATE_ISAM_DTL_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:47:31 PM

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
            fleU030_EXTRACT_DTL.Dispose();
            flePART_PAID_DTL.Dispose();
            fleU030_SORT_HDR.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U030B_PART2_CREATE_ISAM_DTL_5)"


    public void Run()
    {

        try
        {
            Request("CREATE_ISAM_DTL_5");

            while (fleU030_EXTRACT_DTL.QTPForMissing())
            {
                // --> GET U030_EXTRACT_DTL <--

                fleU030_EXTRACT_DTL.GetData();
                // --> End GET U030_EXTRACT_DTL <--


                if (Transaction())
                {

                    Sort(fleU030_EXTRACT_DTL.GetSortValue("PART_HDR_CLAIM_ID"), fleU030_EXTRACT_DTL.GetSortValue("RAT_145_SERVICE_CD"), fleU030_EXTRACT_DTL.GetSortValue("RAT_145_EXPLAN_CD"));


                }

            }


            while (Sort(fleU030_EXTRACT_DTL))
            {
                SubTotal(ref flePART_PAID_DTL, "PART_DTL_AMT_BILL", fleU030_EXTRACT_DTL.GetDecimalValue("RAT_145_AMOUNT_SUB"));
                SubTotal(ref flePART_PAID_DTL, "PART_DTL_AMT_PAID", fleU030_EXTRACT_DTL.GetDecimalValue("RAT_145_AMT_PAID"));
                SubTotal(ref flePART_PAID_DTL, "PART_DTL_NBR_SERV", fleU030_EXTRACT_DTL.GetDecimalValue("RAT_145_NBR_OF_SERV"));

                flePART_PAID_DTL.OutPut(OutPutType.Add, fleU030_EXTRACT_DTL.At("PART_HDR_CLAIM_ID") || fleU030_EXTRACT_DTL.At("RAT_145_SERVICE_CD"), null);

                SubFile(ref m_trnTRANS_UPDATE, ref fleU030_SORT_HDR, fleU030_EXTRACT_DTL.At("PART_HDR_CLAIM_ID"), SubFileType.KeepSQL, fleU030_EXTRACT_DTL, "PART_HDR_CLAIM_ID", "RAT_145_SERVICE_DATE");
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
            EndRequest("CREATE_ISAM_DTL_5");

        }

    }




    #endregion


}
//CREATE_ISAM_DTL_5



public class U030B_PART2_UPDATE_PART_HDR_6 : U030B_PART2
{

    public U030B_PART2_UPDATE_PART_HDR_6(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU030_SORT_HDR = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U030_SORT_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        flePART_PAID_HDR = new SqlFileObject(this, FileTypes.Primary, 0, "SEQUENTIAL", "PART_PAID_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.TempFile);

        flePART_PAID_HDR.SetItemFinals += flePART_PAID_HDR_SetItemFinals;

    }


    #region "Declarations (Variables, Files and Transactions)(U030B_PART2_UPDATE_PART_HDR_6)"

    private SqlFileObject fleU030_SORT_HDR;
    private SqlFileObject flePART_PAID_HDR;

    private void flePART_PAID_HDR_SetItemFinals()
    {

        try
        {
            flePART_PAID_HDR.set_SetValue("PART_HDR_SERV_DATE", fleU030_SORT_HDR.GetDecimalValue("RAT_145_SERVICE_DATE"));


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


    #region "Standard Generated Procedures(U030B_PART2_UPDATE_PART_HDR_6)"


    #region "Automatic Item Initialization(U030B_PART2_UPDATE_PART_HDR_6)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U030B_PART2_UPDATE_PART_HDR_6)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:47:31 PM

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
        fleU030_SORT_HDR.Transaction = m_trnTRANS_UPDATE;
        flePART_PAID_HDR.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U030B_PART2_UPDATE_PART_HDR_6)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:47:31 PM

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
            fleU030_SORT_HDR.Dispose();
            flePART_PAID_HDR.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U030B_PART2_UPDATE_PART_HDR_6)"


    public void Run()
    {

        try
        {
            Request("UPDATE_PART_HDR_6");

            while (fleU030_SORT_HDR.QTPForMissing())
            {
                // --> GET U030_SORT_HDR <--

                fleU030_SORT_HDR.GetData();
                // --> End GET U030_SORT_HDR <--

                while (flePART_PAID_HDR.QTPForMissing("1"))
                {
                    // --> GET PART_PAID_HDR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(flePART_PAID_HDR.ElementOwner("PART_HDR_CLINIC_NBR")).Append(" = ");
                    m_strWhere.Append(QDesign.VAL((fleU030_SORT_HDR.GetStringValue("PART_HDR_CLAIM_ID")).PadRight(10).Substring(0, 2)));
                    //Parent:PART_HDR_CLAIM_ID
                    m_strWhere.Append(" AND ").Append(" ").Append(flePART_PAID_HDR.ElementOwner("PART_HDR_CLAIM_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((fleU030_SORT_HDR.GetStringValue("PART_HDR_CLAIM_ID")).PadRight(10).Substring(2, 8)));
                    //Parent:PART_HDR_CLAIM_ID

                    flePART_PAID_HDR.GetData(m_strWhere.ToString());
                    // --> End GET PART_PAID_HDR <--


                    if (Transaction())
                    {
                       
                        flePART_PAID_HDR.OutPut(OutPutType.Update);
                    
                    }

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
            EndRequest("UPDATE_PART_HDR_6");

        }

    }




    #endregion


}
//UPDATE_PART_HDR_6



public class U030B_PART2_MATCH_CLMDTL_7 : U030B_PART2
{

    public U030B_PART2_MATCH_CLMDTL_7(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        flePART_PAID_DTL = new SqlFileObject(this, FileTypes.Primary, 0, "SEQUENTIAL", "PART_PAID_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.TempFile);
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleU030_NOMATCH_DTL = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U030_NOMATCH_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);


    }


    #region "Declarations (Variables, Files and Transactions)(U030B_PART2_MATCH_CLMDTL_7)"

    private SqlFileObject flePART_PAID_DTL;
    private SqlFileObject fleF002_CLAIMS_MSTR;
    public override bool SelectIf()
    {


        try
        {
            if (!fleF002_CLAIMS_MSTR.Exists())
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
























    private SqlFileObject fleU030_NOMATCH_DTL;


    #endregion


    #region "Standard Generated Procedures(U030B_PART2_MATCH_CLMDTL_7)"


    #region "Automatic Item Initialization(U030B_PART2_MATCH_CLMDTL_7)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U030B_PART2_MATCH_CLMDTL_7)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:47:31 PM

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
        flePART_PAID_DTL.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleU030_NOMATCH_DTL.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U030B_PART2_MATCH_CLMDTL_7)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:47:31 PM

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
            flePART_PAID_DTL.Dispose();
            fleF002_CLAIMS_MSTR.Dispose();
            fleU030_NOMATCH_DTL.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U030B_PART2_MATCH_CLMDTL_7)"


    public void Run()
    {

        try
        {
            Request("MATCH_CLMDTL_7");

            while (flePART_PAID_DTL.QTPForMissing())
            {
                // --> GET PART_PAID_DTL <--

                flePART_PAID_DTL.GetData();
                // --> End GET PART_PAID_DTL <--

                while (fleF002_CLAIMS_MSTR.QTPForMissing("1"))
                {
                    // --> GET F002_CLAIMS_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("B"));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(QDesign.Substring(QDesign.ASCII(flePART_PAID_DTL.GetDecimalValue("PART_DTL_CLINIC_NBR"), 2) + flePART_PAID_DTL.GetStringValue("PART_DTL_CLAIM_NBR") + flePART_PAID_DTL.GetStringValue("PART_DTL_OMA_CD"), 1, 8)));
                    //Parent:PART_DTL_CLAIM_ID
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ");
                    m_strWhere.Append((QDesign.NConvert(QDesign.Substring(QDesign.ASCII(flePART_PAID_DTL.GetDecimalValue("PART_DTL_CLINIC_NBR"), 2) + flePART_PAID_DTL.GetStringValue("PART_DTL_CLAIM_NBR") + flePART_PAID_DTL.GetStringValue("PART_DTL_OMA_CD"), 9, 2))));
                    //Parent:PART_DTL_CLAIM_ID
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_SERV_CODE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(flePART_PAID_DTL.GetStringValue("PART_DTL_OMA_CD")));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_ADJ_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("0"));

                    fleF002_CLAIMS_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F002_CLAIMS_MSTR <--

                    if (Transaction())
                    {

                        if (Select_If())
                        {

                            SubFile(ref m_trnTRANS_UPDATE, ref fleU030_NOMATCH_DTL, SubFileType.KeepSQL, flePART_PAID_DTL);
                        

                        }

                    }

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
            EndRequest("MATCH_CLMDTL_7");

        }

    }




    #endregion


}
//MATCH_CLMDTL_7



public class U030B_PART2_MATCH_EQUIV_TABLE_8 : U030B_PART2
{

    public U030B_PART2_MATCH_EQUIV_TABLE_8(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU030_NOMATCH_DTL = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U030_NOMATCH_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF098_EQUIV_OMA_CODE_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F098_EQUIV_OMA_CODE_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        flePART_PAID_DTL = new SqlFileObject(this, FileTypes.Primary, 0, "SEQUENTIAL", "PART_PAID_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.TempFile);
        fleU030_NO_EQUIV = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U030_NO_EQUIV", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        flePART_PAID_DTL.SetItemFinals += flePART_PAID_DTL_SetItemFinals;

    }


    #region "Declarations (Variables, Files and Transactions)(U030B_PART2_MATCH_EQUIV_TABLE_8)"

    private SqlFileObject fleU030_NOMATCH_DTL;
    private SqlFileObject fleF098_EQUIV_OMA_CODE_MSTR;
    private SqlFileObject flePART_PAID_DTL;

    private void flePART_PAID_DTL_SetItemFinals()
    {

        try
        {
            flePART_PAID_DTL.set_SetValue("PART_DTL_OMA_CD", fleF098_EQUIV_OMA_CODE_MSTR.GetStringValue("EQUIV_OMA_CODE"));
            flePART_PAID_DTL.set_SetValue("PART_DTL_EQUIV_FLAG", "?");


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
























    private SqlFileObject fleU030_NO_EQUIV;


    #endregion


    #region "Standard Generated Procedures(U030B_PART2_MATCH_EQUIV_TABLE_8)"


    #region "Automatic Item Initialization(U030B_PART2_MATCH_EQUIV_TABLE_8)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U030B_PART2_MATCH_EQUIV_TABLE_8)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:47:32 PM

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
        fleU030_NOMATCH_DTL.Transaction = m_trnTRANS_UPDATE;
        fleF098_EQUIV_OMA_CODE_MSTR.Transaction = m_trnTRANS_UPDATE;
        flePART_PAID_DTL.Transaction = m_trnTRANS_UPDATE;
        fleU030_NO_EQUIV.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U030B_PART2_MATCH_EQUIV_TABLE_8)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:47:32 PM

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
            fleU030_NOMATCH_DTL.Dispose();
            fleF098_EQUIV_OMA_CODE_MSTR.Dispose();
            flePART_PAID_DTL.Dispose();
            fleU030_NO_EQUIV.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U030B_PART2_MATCH_EQUIV_TABLE_8)"


    public void Run()
    {

        try
        {
            Request("MATCH_EQUIV_TABLE_8");

            while (fleU030_NOMATCH_DTL.QTPForMissing())
            {
                // --> GET U030_NOMATCH_DTL <--

                fleU030_NOMATCH_DTL.GetData();
                // --> End GET U030_NOMATCH_DTL <--

                while (fleF098_EQUIV_OMA_CODE_MSTR.QTPForMissing("1"))
                {
                    // --> GET F098_EQUIV_OMA_CODE_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF098_EQUIV_OMA_CODE_MSTR.ElementOwner("ORIG_OMA_CODE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleU030_NOMATCH_DTL.GetStringValue("PART_DTL_OMA_CD")));

                    fleF098_EQUIV_OMA_CODE_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F098_EQUIV_OMA_CODE_MSTR <--

                    while (flePART_PAID_DTL.QTPForMissing("2"))
                    {
                        // --> GET PART_PAID_DTL <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(flePART_PAID_DTL.ElementOwner("PART_DTL_OMA_CD")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleU030_NOMATCH_DTL.GetStringValue("PART_DTL_OMA_CD")));
                        m_strWhere.Append(" And ").Append(flePART_PAID_DTL.ElementOwner("PART_DTL_CLINIC_NBR")).Append(" = ");
                        m_strWhere.Append((fleU030_NOMATCH_DTL.GetDecimalValue("PART_DTL_CLINIC_NBR")));
                        m_strWhere.Append(" And ").Append(flePART_PAID_DTL.ElementOwner("PART_DTL_CLAIM_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleU030_NOMATCH_DTL.GetStringValue("PART_DTL_CLAIM_NBR")));

                        flePART_PAID_DTL.GetData(m_strWhere.ToString());
                        // --> End GET PART_PAID_DTL <--


                        flePART_PAID_DTL.OutPut(OutPutType.Update, null, fleF098_EQUIV_OMA_CODE_MSTR.Exists());
                     

                    }  

                    SubFile(ref m_trnTRANS_UPDATE, ref fleU030_NO_EQUIV, !fleF098_EQUIV_OMA_CODE_MSTR.Exists(), SubFileType.KeepSQL, fleU030_NOMATCH_DTL);
                   

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
            EndRequest("MATCH_EQUIV_TABLE_8");

        }

    }




    #endregion


}
//MATCH_EQUIV_TABLE_8



public class U030B_PART2_DETERMINE_ADJUSTMENT_9 : U030B_PART2
{

    public U030B_PART2_DETERMINE_ADJUSTMENT_9(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        flePART_PAID_HDR = new SqlFileObject(this, FileTypes.Primary, 0, "SEQUENTIAL", "PART_PAID_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.TempFile);
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleICONST_MSTR_REC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "ICONST_MSTR_REC", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF096_OHIP_PAY_CODE = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F096_OHIP_PAY_CODE", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleSOCIAL_CONTRACT_FACTOR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "SOCIAL_CONTRACT_FACTOR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleU030_AUTO_ADJ = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U030_AUTO_ADJ", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU030_NO_ADJ = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U030_NO_ADJ", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU030_HOLDBACK = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U030_HOLDBACK", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU030_OVERPAY = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U030_OVERPAY", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU030_TOT_CLAIMS = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U030_TOT_CLAIMS", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        PART_HDR_CLAIM_ID = new CoreCharacter("PART_HDR_CLAIM_ID", 11, this, Common.cEmptyString);

        X_PART_BAL.GetValue += X_PART_BAL_GetValue;
        X_OVER.GetValue += X_OVER_GetValue;
        X_UNDER.GetValue += X_UNDER_GetValue;
        X_PART_BAL_DIFF.GetValue += X_PART_BAL_DIFF_GetValue;
        X_BAL_FLAG.GetValue += X_BAL_FLAG_GetValue;
        X_AUTO_ADJ.GetValue += X_AUTO_ADJ_GetValue;
        X_RED_AMOUNT.GetValue += X_RED_AMOUNT_GetValue;
        X_FROM_RED_RANGE.GetValue += X_FROM_RED_RANGE_GetValue;
        X_TO_RED_RANGE.GetValue += X_TO_RED_RANGE_GetValue;
        X_OVER_AMOUNT.GetValue += X_OVER_AMOUNT_GetValue;
        X_FROM_OVER_RANGE.GetValue += X_FROM_OVER_RANGE_GetValue;
        X_TO_OVER_RANGE.GetValue += X_TO_OVER_RANGE_GetValue;
        X_HOLD_BACK.GetValue += X_HOLD_BACK_GetValue;
        X_OVER_PAY.GetValue += X_OVER_PAY_GetValue;
        X_ADJ_SERV_CODE.GetValue += X_ADJ_SERV_CODE_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(U030B_PART2_DETERMINE_ADJUSTMENT_9)"

    private CoreCharacter PART_HDR_CLAIM_ID;
    private SqlFileObject flePART_PAID_HDR;
    private SqlFileObject fleF002_CLAIMS_MSTR;
    private SqlFileObject fleICONST_MSTR_REC;
    private SqlFileObject fleF096_OHIP_PAY_CODE;
    private SqlFileObject fleSOCIAL_CONTRACT_FACTOR;
    public override bool SelectIf()
    {


        try
        {
            if (flePART_PAID_HDR.GetNumericDateValue("PART_HDR_SERV_DATE") >= fleSOCIAL_CONTRACT_FACTOR.GetNumericDateValue("CONST_SERV_DATE_FROM") & flePART_PAID_HDR.GetNumericDateValue("PART_HDR_SERV_DATE") <= fleSOCIAL_CONTRACT_FACTOR.GetNumericDateValue("CONST_SERV_DATE_TO"))
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

    private DInteger X_PART_BAL = new DInteger("X_PART_BAL", 7);
    private void X_PART_BAL_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP") + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_MANUAL_AND_TAPE_PAYMENTS");


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
    private DCharacter X_OVER = new DCharacter("X_OVER", 1);
    private void X_OVER_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(X_PART_BAL.Value) < 0)
            {
                CurrentValue = "Y";
            }
            else
            {
                CurrentValue = " ";
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
    private DCharacter X_UNDER = new DCharacter("X_UNDER", 1);
    private void X_UNDER_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(X_PART_BAL.Value) > 0)
            {
                CurrentValue = "Y";
            }
            else
            {
                CurrentValue = " ";
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
    private DInteger X_PART_BAL_DIFF = new DInteger("X_PART_BAL_DIFF", 7);
    private void X_PART_BAL_DIFF_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0;
            if (QDesign.NULL(X_OVER.Value) == "Y")
            {
                CurrentValue = X_PART_BAL.Value * -1;
            }
            else
            {
                CurrentValue = X_PART_BAL.Value;
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
    private DCharacter X_BAL_FLAG = new DCharacter("X_BAL_FLAG", 1);
    private void X_BAL_FLAG_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(flePART_PAID_HDR.GetDecimalValue("PART_HDR_OHIP_BILL")) == QDesign.NULL(flePART_PAID_HDR.GetDecimalValue("PART_HDR_AMT_BILL")))
            {
                CurrentValue = "Y";
            }
            else
            {
                CurrentValue = "N";
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
    private DCharacter X_AUTO_ADJ = new DCharacter("X_AUTO_ADJ", 1);
    private void X_AUTO_ADJ_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if ((QDesign.NULL(X_UNDER.Value) == "Y" & QDesign.NULL(flePART_PAID_HDR.GetStringValue("PART_HDR_EXPLAN_CD")) == QDesign.NULL(" ") & QDesign.NULL(X_PART_BAL_DIFF.Value) > 100))
            {
                CurrentValue = "N";
            }
            else if ((((X_PART_BAL_DIFF.Value <= 900) | (((QDesign.NULL(X_OVER.Value) == "Y" & QDesign.NULL(flePART_PAID_HDR.GetStringValue("PART_HDR_EXPLAN_CD")) == QDesign.NULL(" ") & X_PART_BAL_DIFF.Value <= fleICONST_MSTR_REC.GetDecimalValue("ICONST_CLINIC_OVER_LIM1")) | (QDesign.NULL(X_OVER.Value) == "Y" & QDesign.NULL(flePART_PAID_HDR.GetStringValue("PART_HDR_EXPLAN_CD")) != QDesign.NULL(" ") & X_PART_BAL_DIFF.Value <= fleICONST_MSTR_REC.GetDecimalValue("ICONST_CLINIC_OVER_LIM4")) | (QDesign.NULL(X_UNDER.Value) == "Y" & QDesign.NULL(flePART_PAID_HDR.GetDecimalValue("PART_HDR_AMT_PAID")) != 0 & X_PART_BAL_DIFF.Value <= fleICONST_MSTR_REC.GetDecimalValue("ICONST_CLINIC_UNDER_LIM2")) | (QDesign.NULL(X_UNDER.Value) == "Y" & fleF096_OHIP_PAY_CODE.Exists() & X_PART_BAL_DIFF.Value <= fleICONST_MSTR_REC.GetDecimalValue("ICONST_CLINIC_UNDER_LIM3"))) & (QDesign.NULL(X_BAL_FLAG.Value) == "Y")))) | (QDesign.NULL(X_OVER.Value) == "Y" & QDesign.NULL(flePART_PAID_HDR.GetStringValue("PART_HDR_EXPLAN_CD")) == "D2" & X_PART_BAL_DIFF.Value <= 2000) | (QDesign.NULL(X_UNDER.Value) == "Y" & QDesign.NULL(flePART_PAID_HDR.GetStringValue("PART_HDR_EXPLAN_CD")) == "MD" & X_PART_BAL_DIFF.Value <= 7500) | (((flePART_PAID_HDR.GetDecimalValue("PART_HDR_CLINIC_NBR") >= 61 & flePART_PAID_HDR.GetDecimalValue("PART_HDR_CLINIC_NBR") <= 66) | (flePART_PAID_HDR.GetDecimalValue("PART_HDR_CLINIC_NBR") >= 71 & flePART_PAID_HDR.GetDecimalValue("PART_HDR_CLINIC_NBR") <= 75)) & ((QDesign.NULL(flePART_PAID_HDR.GetStringValue("PART_HDR_EXPLAN_CD")) == "DT" | QDesign.NULL(flePART_PAID_HDR.GetStringValue("PART_HDR_EXPLAN_CD")) == "55") | (QDesign.NULL(flePART_PAID_HDR.GetStringValue("PART_HDR_EXPLAN_CD")) == "35" & X_PART_BAL_DIFF.Value <= 2000))))
            {
                CurrentValue = "Y";
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
    private DInteger X_RED_AMOUNT = new DInteger("X_RED_AMOUNT", 4);
    private void X_RED_AMOUNT_GetValue(ref decimal Value)
    {

        try
        {

            // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

            Value = flePART_PAID_HDR.GetDecimalValue("PART_HDR_AMT_BILL") * fleSOCIAL_CONTRACT_FACTOR.GetDecimalValue("CONST_REDUCTION_FACTOR") / 10000;


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
    private DInteger X_FROM_RED_RANGE = new DInteger("X_FROM_RED_RANGE", 6);
    private void X_FROM_RED_RANGE_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0;
            if (QDesign.NULL(X_RED_AMOUNT.Value) != 0)
            {
                CurrentValue = X_RED_AMOUNT.Value - 5;
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
    private DInteger X_TO_RED_RANGE = new DInteger("X_TO_RED_RANGE", 6);
    private void X_TO_RED_RANGE_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0;
            if (QDesign.NULL(X_RED_AMOUNT.Value) != 0)
            {
                CurrentValue = X_RED_AMOUNT.Value + 5;
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
    private DInteger X_OVER_AMOUNT = new DInteger("X_OVER_AMOUNT", 6);
    private void X_OVER_AMOUNT_GetValue(ref decimal Value)
    {

        try
        {

            // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

            Value = flePART_PAID_HDR.GetDecimalValue("PART_HDR_AMT_BILL") * fleSOCIAL_CONTRACT_FACTOR.GetDecimalValue("CONST_OVERPAY_FACTOR") / 10000;


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
    private DInteger X_FROM_OVER_RANGE = new DInteger("X_FROM_OVER_RANGE", 6);
    private void X_FROM_OVER_RANGE_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0;
            if (QDesign.NULL(X_OVER_AMOUNT.Value) != 0)
            {
                CurrentValue = X_OVER_AMOUNT.Value - 5;
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
    private DInteger X_TO_OVER_RANGE = new DInteger("X_TO_OVER_RANGE", 6);
    private void X_TO_OVER_RANGE_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0;
            if (QDesign.NULL(X_OVER_AMOUNT.Value) != 0)
            {
                CurrentValue = X_OVER_AMOUNT.Value + 5;
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
    private DCharacter X_HOLD_BACK = new DCharacter("X_HOLD_BACK", 1);
    private void X_HOLD_BACK_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (X_PART_BAL.Value >= X_FROM_RED_RANGE.Value & X_PART_BAL.Value <= X_TO_RED_RANGE.Value & QDesign.NULL(flePART_PAID_HDR.GetStringValue("PART_HDR_PAY_PGM")) == "HCP" & QDesign.NULL(X_UNDER.Value) == "Y")
            {
                CurrentValue = "Y";
            }
            else
            {
                CurrentValue = "N";
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
    private DCharacter X_OVER_PAY = new DCharacter("X_OVER_PAY", 1);
    private void X_OVER_PAY_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (X_PART_BAL_DIFF.Value >= X_FROM_OVER_RANGE.Value & X_PART_BAL_DIFF.Value <= X_TO_OVER_RANGE.Value & QDesign.NULL(flePART_PAID_HDR.GetStringValue("PART_HDR_PAY_PGM")) == "HCP" & QDesign.NULL(X_OVER.Value) == "Y")
            {
                CurrentValue = "Y";
            }
            else
            {
                CurrentValue = "N";
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
    private DCharacter X_ADJ_SERV_CODE = new DCharacter("X_ADJ_SERV_CODE", 5);
    private void X_ADJ_SERV_CODE_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(X_HOLD_BACK.Value) == "Y")
            {
                CurrentValue = "Y900A";
            }
            else if (QDesign.NULL(X_OVER_PAY.Value) == "Y")
            {
                CurrentValue = "Y901A";
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

    
    private SqlFileObject fleU030_AUTO_ADJ;
    private SqlFileObject fleU030_NO_ADJ;
    private SqlFileObject fleU030_HOLDBACK;
    private SqlFileObject fleU030_OVERPAY;
    private SqlFileObject fleU030_TOT_CLAIMS;


    #endregion


    #region "Standard Generated Procedures(U030B_PART2_DETERMINE_ADJUSTMENT_9)"


    #region "Automatic Item Initialization(U030B_PART2_DETERMINE_ADJUSTMENT_9)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U030B_PART2_DETERMINE_ADJUSTMENT_9)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:47:32 PM

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
        flePART_PAID_HDR.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleICONST_MSTR_REC.Transaction = m_trnTRANS_UPDATE;
        fleF096_OHIP_PAY_CODE.Transaction = m_trnTRANS_UPDATE;
        fleSOCIAL_CONTRACT_FACTOR.Transaction = m_trnTRANS_UPDATE;
        fleU030_AUTO_ADJ.Transaction = m_trnTRANS_UPDATE;
        fleU030_NO_ADJ.Transaction = m_trnTRANS_UPDATE;
        fleU030_HOLDBACK.Transaction = m_trnTRANS_UPDATE;
        fleU030_OVERPAY.Transaction = m_trnTRANS_UPDATE;
        fleU030_TOT_CLAIMS.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U030B_PART2_DETERMINE_ADJUSTMENT_9)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:47:32 PM

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
            flePART_PAID_HDR.Dispose();
            fleF002_CLAIMS_MSTR.Dispose();
            fleICONST_MSTR_REC.Dispose();
            fleF096_OHIP_PAY_CODE.Dispose();
            fleSOCIAL_CONTRACT_FACTOR.Dispose();
            fleU030_AUTO_ADJ.Dispose();
            fleU030_NO_ADJ.Dispose();
            fleU030_HOLDBACK.Dispose();
            fleU030_OVERPAY.Dispose();
            fleU030_TOT_CLAIMS.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U030B_PART2_DETERMINE_ADJUSTMENT_9)"


    public void Run()
    {

        try
        {
            Request("DETERMINE_ADJUSTMENT_9");

            while (flePART_PAID_HDR.QTPForMissing())
            {
                // --> GET PART_PAID_HDR <--

                flePART_PAID_HDR.GetData();
                // --> End GET PART_PAID_HDR <--

                while (fleF002_CLAIMS_MSTR.QTPForMissing("1"))
                {
                    // --> GET F002_CLAIMS_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("B"));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(QDesign.Substring(QDesign.ASCII(flePART_PAID_HDR.GetDecimalValue("PART_HDR_CLINIC_NBR"), 2) + flePART_PAID_HDR.GetStringValue("PART_HDR_CLAIM_NBR"), 1, 8)));
                    //Parent:PART_HDR_CLAIM_ID
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ");
                    m_strWhere.Append((QDesign.NConvert(QDesign.Substring(QDesign.ASCII(flePART_PAID_HDR.GetDecimalValue("PART_HDR_CLINIC_NBR"), 2) + flePART_PAID_HDR.GetStringValue("PART_HDR_CLAIM_NBR"), 9, 2))));
                    //Parent:PART_HDR_CLAIM_ID
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_SERV_CODE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("00000"));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_ADJ_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("0"));

                    fleF002_CLAIMS_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F002_CLAIMS_MSTR <--

                    while (fleICONST_MSTR_REC.QTPForMissing("2"))
                    {
                        // --> GET ICONST_MSTR_REC <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleICONST_MSTR_REC.ElementOwner("ICONST_CLINIC_NBR_1_2")).Append(" = ");
                        m_strWhere.Append((QDesign.NConvert(QDesign.Substring(QDesign.ASCII(flePART_PAID_HDR.GetDecimalValue("PART_HDR_CLINIC_NBR"), 2) + flePART_PAID_HDR.GetStringValue("PART_HDR_CLAIM_NBR"), 1, 2))));
                        //Parent:PART_HDR_CLAIM_ID

                        fleICONST_MSTR_REC.GetData(m_strWhere.ToString());
                        // --> End GET ICONST_MSTR_REC <--

                        while (fleF096_OHIP_PAY_CODE.QTPForMissing("3"))
                        {
                            // --> GET F096_OHIP_PAY_CODE <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleF096_OHIP_PAY_CODE.ElementOwner("RAT_CODE")).Append(" = ");
                            m_strWhere.Append(Common.StringToField(flePART_PAID_HDR.GetStringValue("PART_HDR_EXPLAN_CD")));

                            fleF096_OHIP_PAY_CODE.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                            // --> End GET F096_OHIP_PAY_CODE <--

                            while (fleSOCIAL_CONTRACT_FACTOR.QTPForMissing("4"))
                            {
                                // --> GET SOCIAL_CONTRACT_FACTOR <--
                                m_strWhere = new StringBuilder(" WHERE ");
                                m_strWhere.Append(" ").Append(fleSOCIAL_CONTRACT_FACTOR.ElementOwner("CONST_REC_NBR")).Append(" = ");
                                m_strWhere.Append((QDesign.NConvert(QDesign.Substring(QDesign.ASCII(flePART_PAID_HDR.GetDecimalValue("PART_HDR_CLINIC_NBR"), 2) + flePART_PAID_HDR.GetStringValue("PART_HDR_CLAIM_NBR"), 1, 2))));
                                //Parent:PART_HDR_CLAIM_ID

                                fleSOCIAL_CONTRACT_FACTOR.GetData(m_strWhere.ToString());
                                // --> End GET SOCIAL_CONTRACT_FACTOR <--

                                if (Transaction())
                                {

                                    if (Select_If())
                                    {
                                        PART_HDR_CLAIM_ID.Value = QDesign.ASCII(flePART_PAID_HDR.GetDecimalValue("PART_HDR_CLINIC_NBR")) + flePART_PAID_HDR.GetStringValue("PART_HDR_CLAIM_NBR");
                                        SubFile(ref m_trnTRANS_UPDATE, ref fleU030_AUTO_ADJ, QDesign.NULL(X_AUTO_ADJ.Value) == "Y" & QDesign.NULL(X_HOLD_BACK.Value) == "N" & QDesign.NULL(X_OVER_PAY.Value) == "N", SubFileType.KeepSQL, X_BAL_FLAG, X_PART_BAL, PART_HDR_CLAIM_ID, flePART_PAID_HDR);
                                        
                                        SubFile(ref m_trnTRANS_UPDATE, ref fleU030_NO_ADJ, (QDesign.NULL(X_AUTO_ADJ.Value) != "Y" & QDesign.NULL(X_HOLD_BACK.Value) == "N" & QDesign.NULL(X_OVER_PAY.Value) == "N"), SubFileType.KeepSQL, X_BAL_FLAG, PART_HDR_CLAIM_ID,  flePART_PAID_HDR);

                                        SubFile(ref m_trnTRANS_UPDATE, ref fleU030_HOLDBACK, QDesign.NULL(X_HOLD_BACK.Value) == "Y", SubFileType.KeepSQL, X_BAL_FLAG, PART_HDR_CLAIM_ID,  flePART_PAID_HDR);

                                        SubFile(ref m_trnTRANS_UPDATE, ref fleU030_OVERPAY, QDesign.NULL(X_OVER_PAY.Value) == "Y", SubFileType.KeepSQL, X_BAL_FLAG, PART_HDR_CLAIM_ID,  flePART_PAID_HDR);

                                        SubFile(ref m_trnTRANS_UPDATE, ref fleU030_TOT_CLAIMS, SubFileType.KeepSQL, X_AUTO_ADJ, X_BAL_FLAG, X_HOLD_BACK, X_OVER_PAY, X_ADJ_SERV_CODE, X_PART_BAL, PART_HDR_CLAIM_ID, flePART_PAID_HDR);


                                    }

                                }

                            }

                        }

                    }

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
            EndRequest("DETERMINE_ADJUSTMENT_9");

        }

    }




    #endregion


}
//DETERMINE_ADJUSTMENT_9



public class U030B_PART2_SUMM_CLAIM_SERV_CODE_10 : U030B_PART2
{

    public U030B_PART2_SUMM_CLAIM_SERV_CODE_10(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU030_AUTO_ADJ = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U030_AUTO_ADJ", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_AMT_BILLED = new CoreInteger("X_AMT_BILLED", 7, this);
        X_AMT_DTL_TECH_BILLED = new CoreInteger("X_AMT_DTL_TECH_BILLED", 7, this);
        fleU030_SUMM_SERV_CODE = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U030_SUMM_SERV_CODE", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        CLMDTL_SV_DATE = new CoreDecimal("CLMDTL_SV_DATE", 8, this);

    }


    #region "Declarations (Variables, Files and Transactions)(U030B_PART2_SUMM_CLAIM_SERV_CODE_10)"
    private CoreDecimal CLMDTL_SV_DATE;
    private SqlFileObject fleU030_AUTO_ADJ;
    private SqlFileObject fleF002_CLAIMS_MSTR;
    public override bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) != "0000" & QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) != "ZZZZ" & QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_ADJ_NBR")) == 0)
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

    private CoreInteger X_AMT_BILLED;

    private CoreInteger X_AMT_DTL_TECH_BILLED; 

    private SqlFileObject fleU030_SUMM_SERV_CODE;


    #endregion


    #region "Standard Generated Procedures(U030B_PART2_SUMM_CLAIM_SERV_CODE_10)"


    #region "Automatic Item Initialization(U030B_PART2_SUMM_CLAIM_SERV_CODE_10)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U030B_PART2_SUMM_CLAIM_SERV_CODE_10)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:47:32 PM

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
        fleU030_AUTO_ADJ.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleU030_SUMM_SERV_CODE.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U030B_PART2_SUMM_CLAIM_SERV_CODE_10)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:47:33 PM

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
            fleU030_AUTO_ADJ.Dispose();
            fleF002_CLAIMS_MSTR.Dispose();
            fleU030_SUMM_SERV_CODE.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U030B_PART2_SUMM_CLAIM_SERV_CODE_10)"


    public void Run()
    {

        try
        {
            Request("SUMM_CLAIM_SERV_CODE_10");

            while (fleU030_AUTO_ADJ.QTPForMissing())
            {
                // --> GET U030_AUTO_ADJ <--

                fleU030_AUTO_ADJ.GetData();
                // --> End GET U030_AUTO_ADJ <--

                while (fleF002_CLAIMS_MSTR.QTPForMissing("1"))
                {
                    // --> GET F002_CLAIMS_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("B"));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(QDesign.Substring(fleU030_AUTO_ADJ.GetStringValue("PART_HDR_CLAIM_ID"), 1, 8)));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ");
                    m_strWhere.Append((QDesign.NConvert(QDesign.Substring(fleU030_AUTO_ADJ.GetStringValue("PART_HDR_CLAIM_ID"), 9, 2))));

                    fleF002_CLAIMS_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F002_CLAIMS_MSTR <--

                    if (Transaction())
                    {

                        if (Select_If())
                        {

                            Sort(fleU030_AUTO_ADJ.GetSortValue("PART_HDR_CLAIM_ID"), fleF002_CLAIMS_MSTR.GetSortValue("KEY_CLM_SERV_CODE"));



                        }

                    }

                }

            }

            while (Sort(fleU030_AUTO_ADJ, fleF002_CLAIMS_MSTR))
            {
                X_AMT_BILLED.Value = X_AMT_BILLED.Value + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_FEE_OHIP");
                X_AMT_DTL_TECH_BILLED.Value = X_AMT_DTL_TECH_BILLED.Value + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_AMT_TECH_BILLED");
                CLMDTL_SV_DATE.Value = Convert.ToDecimal(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_YY").ToString().PadLeft(4, '0') + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_MM").ToString().PadLeft(2, '0') + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DD").ToString().PadLeft(2, '0'));


                SubFile(ref m_trnTRANS_UPDATE, ref fleU030_SUMM_SERV_CODE, fleU030_AUTO_ADJ.At("PART_HDR_CLAIM_ID") || fleF002_CLAIMS_MSTR.At("KEY_CLM_SERV_CODE"), SubFileType.KeepSQL, 
                    X_AMT_BILLED, fleF002_CLAIMS_MSTR, "KEY_CLM_SERV_CODE", fleU030_AUTO_ADJ, fleF002_CLAIMS_MSTR, "CLMDTL_DIAG_CD",
                CLMDTL_SV_DATE, fleF002_CLAIMS_MSTR, "CLMDTL_LINE_NO", X_AMT_DTL_TECH_BILLED);
              

                Reset(ref X_AMT_BILLED, fleU030_AUTO_ADJ.At("PART_HDR_CLAIM_ID") || fleF002_CLAIMS_MSTR.At("KEY_CLM_SERV_CODE"));
                Reset(ref X_AMT_DTL_TECH_BILLED, fleU030_AUTO_ADJ.At("PART_HDR_CLAIM_ID") || fleF002_CLAIMS_MSTR.At("KEY_CLM_SERV_CODE"));

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
            EndRequest("SUMM_CLAIM_SERV_CODE_10");

        }

    }




    #endregion


}
//SUMM_CLAIM_SERV_CODE_10



public class U030B_PART2_MATCH_DTL_11 : U030B_PART2
{

    public U030B_PART2_MATCH_DTL_11(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU030_SUMM_SERV_CODE = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U030_SUMM_SERV_CODE", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        flePART_PAID_DTL = new SqlFileObject(this, FileTypes.Primary, 0, "SEQUENTIAL", "PART_PAID_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.TempFile);
        X_SEL_DTL = new CoreDecimal("X_SEL_DTL", 6, this);
        X_TOT_BAL = new CoreDecimal("X_TOT_BAL", 6, this);
        fleU030_AUTO_ADJDTL = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U030_AUTO_ADJDTL", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU030_NO_ADJCLM_CREATED = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U030_NO_ADJCLM_CREATED", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_BAL_DIFF.GetValue += X_BAL_DIFF_GetValue;
        X_ADJ_SERV_CODE.GetValue += X_ADJ_SERV_CODE_GetValue;
       
    }


    #region "Declarations (Variables, Files and Transactions)(U030B_PART2_MATCH_DTL_11)"
   
    private SqlFileObject fleU030_SUMM_SERV_CODE;
    private SqlFileObject flePART_PAID_DTL;
    private DInteger X_BAL_DIFF = new DInteger("X_BAL_DIFF", 7);
    private void X_BAL_DIFF_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0;
            if (flePART_PAID_DTL.GetDecimalValue("PART_DTL_AMT_PAID") >= 0)
            {
                CurrentValue = fleU030_SUMM_SERV_CODE.GetDecimalValue("X_AMT_BILLED") - flePART_PAID_DTL.GetDecimalValue("PART_DTL_AMT_PAID");
            }
            else
            {
                CurrentValue = flePART_PAID_DTL.GetDecimalValue("PART_DTL_AMT_PAID") * -1;
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
    private CoreDecimal X_SEL_DTL;
    private CoreDecimal X_TOT_BAL;
    private DCharacter X_ADJ_SERV_CODE = new DCharacter("X_ADJ_SERV_CODE", 5);
    private void X_ADJ_SERV_CODE_GetValue(ref string Value)
    {

        try
        {
            Value = fleU030_SUMM_SERV_CODE.GetStringValue("KEY_CLM_SERV_CODE");


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

    

    private SqlFileObject fleU030_AUTO_ADJDTL;
    private SqlFileObject fleU030_NO_ADJCLM_CREATED;


    #endregion


    #region "Standard Generated Procedures(U030B_PART2_MATCH_DTL_11)"


    #region "Automatic Item Initialization(U030B_PART2_MATCH_DTL_11)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U030B_PART2_MATCH_DTL_11)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:47:33 PM

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
        fleU030_SUMM_SERV_CODE.Transaction = m_trnTRANS_UPDATE;
        flePART_PAID_DTL.Transaction = m_trnTRANS_UPDATE;
        fleU030_AUTO_ADJDTL.Transaction = m_trnTRANS_UPDATE;
        fleU030_NO_ADJCLM_CREATED.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U030B_PART2_MATCH_DTL_11)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:47:33 PM

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
            fleU030_SUMM_SERV_CODE.Dispose();
            flePART_PAID_DTL.Dispose();
            fleU030_AUTO_ADJDTL.Dispose();
            fleU030_NO_ADJCLM_CREATED.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U030B_PART2_MATCH_DTL_11)"


    public void Run()
    {

        try
        {
            Request("MATCH_DTL_11");

            while (fleU030_SUMM_SERV_CODE.QTPForMissing())
            {
                // --> GET U030_SUMM_SERV_CODE <--

                fleU030_SUMM_SERV_CODE.GetData();
                // --> End GET U030_SUMM_SERV_CODE <--

                while (flePART_PAID_DTL.QTPForMissing("1"))
                {
                    // --> GET PART_PAID_DTL <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(flePART_PAID_DTL.ElementOwner("PART_DTL_CLINIC_NBR")).Append(" = ");
                    m_strWhere.Append((fleU030_SUMM_SERV_CODE.GetDecimalValue("PART_HDR_CLINIC_NBR")));
                    m_strWhere.Append(" And ").Append(flePART_PAID_DTL.ElementOwner("PART_DTL_CLAIM_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleU030_SUMM_SERV_CODE.GetStringValue("PART_HDR_CLAIM_NBR")));
                    m_strWhere.Append(" And ").Append(flePART_PAID_DTL.ElementOwner("PART_DTL_OMA_CD")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleU030_SUMM_SERV_CODE.GetStringValue("KEY_CLM_SERV_CODE")));

                    flePART_PAID_DTL.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET PART_PAID_DTL <--


                    if (Transaction())
                    {

                        Sort(fleU030_SUMM_SERV_CODE.GetSortValue("PART_HDR_CLAIM_ID"));



                    }

                }

            }

            while (Sort(fleU030_SUMM_SERV_CODE, flePART_PAID_DTL))
            {
                if (QDesign.NULL(X_BAL_DIFF.Value) != 0 & flePART_PAID_DTL.Exists())
                {
                    X_SEL_DTL.Value = X_SEL_DTL.Value + 1;
                }
                if (QDesign.NULL(X_BAL_DIFF.Value) != 0 & flePART_PAID_DTL.Exists())
                {
                    X_TOT_BAL.Value = X_TOT_BAL.Value + X_BAL_DIFF.Value;
                }
                
                SubFile(ref m_trnTRANS_UPDATE, ref fleU030_AUTO_ADJDTL, QDesign.NULL(X_BAL_DIFF.Value) != 0 & flePART_PAID_DTL.Exists(), SubFileType.KeepSQL, X_ADJ_SERV_CODE, fleU030_SUMM_SERV_CODE, "PART_HDR_CLAIM_ID", "CLMDTL_DIAG_CD", "CLMDTL_SV_DATE", "CLMDTL_LINE_NO",
                 X_BAL_DIFF, flePART_PAID_DTL, "PART_DTL_EXPLAN_CD", fleU030_SUMM_SERV_CODE, "X_AMT_BILLED", "X_AMT_DTL_TECH_BILLED");
              
                SubFile(ref m_trnTRANS_UPDATE, ref fleU030_NO_ADJCLM_CREATED, fleU030_SUMM_SERV_CODE.At("PART_HDR_CLAIM_ID"), SubFileType.KeepSQL, X_ADJ_SERV_CODE, fleU030_SUMM_SERV_CODE, "PART_HDR_CLAIM_ID", "CLMDTL_DIAG_CD", "CLMDTL_SV_DATE", "CLMDTL_LINE_NO", 
                flePART_PAID_DTL, "PART_DTL_EXPLAN_CD", fleU030_SUMM_SERV_CODE, "X_PART_BAL", X_TOT_BAL, X_SEL_DTL);
               
                Reset(ref X_SEL_DTL, fleU030_SUMM_SERV_CODE.At("PART_HDR_CLAIM_ID"));
                Reset(ref X_TOT_BAL, fleU030_SUMM_SERV_CODE.At("PART_HDR_CLAIM_ID"));

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
            EndRequest("MATCH_DTL_11");

        }

    }




    #endregion


}
//MATCH_DTL_11



public class U030B_PART2_GEN_HOLDBACK_OVERPAY_DTL_12 : U030B_PART2
{

    public U030B_PART2_GEN_HOLDBACK_OVERPAY_DTL_12(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU030_TOT_CLAIMS = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U030_TOT_CLAIMS", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        flePART_PAID_DTL = new SqlFileObject(this, FileTypes.Primary, 0, "SEQUENTIAL", "PART_PAID_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.TempFile);
        fleU030_PAID_DIFF = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U030_PAID_DIFF", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_AMT_DTL_TECH_BILLED.GetValue += X_AMT_DTL_TECH_BILLED_GetValue;
        X_AMT_BILLED.GetValue += X_AMT_BILLED_GetValue;
        X_DTL_BAL_DIFF.GetValue += X_DTL_BAL_DIFF_GetValue;
        X_BAL_DIFF.GetValue += X_BAL_DIFF_GetValue;

        fleF002_CLAIMS_MSTR.SelectIf += fleF002_CLAIMS_MSTR_SelectIf;
        CLMDTL_SV_DATE = new CoreDecimal("CLMDTL_SV_DATE", 8, this);
    }


    #region "Declarations (Variables, Files and Transactions)(U030B_PART2_GEN_HOLDBACK_OVERPAY_DTL_12)"

    private CoreDecimal CLMDTL_SV_DATE;

    private SqlFileObject fleU030_TOT_CLAIMS;
    private SqlFileObject fleF002_CLAIMS_MSTR;

    private void fleF002_CLAIMS_MSTR_SelectIf(ref string SelectIfClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(" (    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  '0000' AND ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'ZZZZ' AND ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_ADJ_NBR")).Append(" =  0 AND ");
            strSQL.Append(" (  ").Append(Common.StringToField(fleU030_TOT_CLAIMS.GetStringValue("X_HOLD_BACK"))).Append(" =  'Y' OR ");
            strSQL.Append("  ").Append(Common.StringToField(fleU030_TOT_CLAIMS.GetStringValue("X_OVER_PAY"))).Append(" =  'Y' ))");


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

    private SqlFileObject flePART_PAID_DTL;
    private DInteger X_AMT_DTL_TECH_BILLED = new DInteger("X_AMT_DTL_TECH_BILLED", 7);
    private void X_AMT_DTL_TECH_BILLED_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_AMT_TECH_BILLED");


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
    private DInteger X_AMT_BILLED = new DInteger("X_AMT_BILLED", 7);
    private void X_AMT_BILLED_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_FEE_OHIP");


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
    private DInteger X_DTL_BAL_DIFF = new DInteger("X_DTL_BAL_DIFF", 7);
    private void X_DTL_BAL_DIFF_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_FEE_OHIP") - flePART_PAID_DTL.GetDecimalValue("PART_DTL_AMT_PAID");


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
    private DInteger X_BAL_DIFF = new DInteger("X_BAL_DIFF", 7);
    private void X_BAL_DIFF_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleU030_TOT_CLAIMS.GetDecimalValue("X_PART_BAL");


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
       


    private SqlFileObject fleU030_PAID_DIFF;


    #endregion


    #region "Standard Generated Procedures(U030B_PART2_GEN_HOLDBACK_OVERPAY_DTL_12)"


    #region "Automatic Item Initialization(U030B_PART2_GEN_HOLDBACK_OVERPAY_DTL_12)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U030B_PART2_GEN_HOLDBACK_OVERPAY_DTL_12)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:47:33 PM

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
        fleU030_TOT_CLAIMS.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_MSTR.Transaction = m_trnTRANS_UPDATE;
        flePART_PAID_DTL.Transaction = m_trnTRANS_UPDATE;
        fleU030_PAID_DIFF.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U030B_PART2_GEN_HOLDBACK_OVERPAY_DTL_12)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:47:33 PM

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
            fleU030_TOT_CLAIMS.Dispose();
            fleF002_CLAIMS_MSTR.Dispose();
            flePART_PAID_DTL.Dispose();
            fleU030_PAID_DIFF.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U030B_PART2_GEN_HOLDBACK_OVERPAY_DTL_12)"


    public void Run()
    {

        try
        {
            Request("GEN_HOLDBACK_OVERPAY_DTL_12");

            while (fleU030_TOT_CLAIMS.QTPForMissing())
            {
                // --> GET U030_TOT_CLAIMS <--

                fleU030_TOT_CLAIMS.GetData();
                // --> End GET U030_TOT_CLAIMS <--

                while (fleF002_CLAIMS_MSTR.QTPForMissing("1"))
                {
                    // --> GET F002_CLAIMS_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("B"));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(QDesign.Substring(fleU030_TOT_CLAIMS.GetStringValue("PART_HDR_CLAIM_ID"), 1, 8)));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ");
                    m_strWhere.Append((QDesign.NConvert(QDesign.Substring(fleU030_TOT_CLAIMS.GetStringValue("PART_HDR_CLAIM_ID"), 9, 2))));

                    fleF002_CLAIMS_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F002_CLAIMS_MSTR <--

                    while (flePART_PAID_DTL.QTPForMissing("2"))
                    {
                        // --> GET PART_PAID_DTL <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(flePART_PAID_DTL.ElementOwner("PART_DTL_CLINIC_NBR")).Append(" = ");
                        m_strWhere.Append((fleU030_TOT_CLAIMS.GetDecimalValue("PART_HDR_CLINIC_NBR")));
                        m_strWhere.Append(" And ").Append(flePART_PAID_DTL.ElementOwner("PART_DTL_CLAIM_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleU030_TOT_CLAIMS.GetStringValue("PART_HDR_CLAIM_NBR")));
                        m_strWhere.Append(" And ").Append(flePART_PAID_DTL.ElementOwner("PART_DTL_OMA_CD")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleF002_CLAIMS_MSTR.GetStringValue("KEY_CLM_SERV_CODE")));

                        flePART_PAID_DTL.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET PART_PAID_DTL <--


                        if (Transaction())
                        {

                          
                            CLMDTL_SV_DATE.Value = Convert.ToDecimal(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_YY").ToString().PadLeft(4, '0') + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_MM").ToString().PadLeft(2, '0') + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DD").ToString().PadLeft(2, '0'));

                            SubFile(ref m_trnTRANS_UPDATE, ref fleU030_PAID_DIFF, SubFileType.KeepSQL, fleU030_TOT_CLAIMS, "X_ADJ_SERV_CODE", "PART_HDR_CLAIM_ID", "PART_HDR_CLINIC_NBR", "PART_HDR_CLAIM_NBR", fleF002_CLAIMS_MSTR, "CLMDTL_DIAG_CD", CLMDTL_SV_DATE, fleF002_CLAIMS_MSTR, "CLMDTL_LINE_NO", X_BAL_DIFF,
                            X_DTL_BAL_DIFF, flePART_PAID_DTL, "PART_DTL_EXPLAN_CD", X_AMT_BILLED, X_AMT_DTL_TECH_BILLED);
                          

                        }

                    }

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
            EndRequest("GEN_HOLDBACK_OVERPAY_DTL_12");

        }

    }




    #endregion


}
//GEN_HOLDBACK_OVERPAY_DTL_12



public class U030B_PART2_SORT_BY_DIFF_BAL_13 : U030B_PART2
{

    public U030B_PART2_SORT_BY_DIFF_BAL_13(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU030_PAID_DIFF = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U030_PAID_DIFF", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU030_AUTO_ADJDTL = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U030_AUTO_ADJDTL", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);


    }


    #region "Declarations (Variables, Files and Transactions)(U030B_PART2_SORT_BY_DIFF_BAL_13)"

    private SqlFileObject fleU030_PAID_DIFF;   
    private SqlFileObject fleU030_AUTO_ADJDTL;


    #endregion


    #region "Standard Generated Procedures(U030B_PART2_SORT_BY_DIFF_BAL_13)"


    #region "Automatic Item Initialization(U030B_PART2_SORT_BY_DIFF_BAL_13)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U030B_PART2_SORT_BY_DIFF_BAL_13)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:47:33 PM

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
        fleU030_PAID_DIFF.Transaction = m_trnTRANS_UPDATE;
        fleU030_AUTO_ADJDTL.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U030B_PART2_SORT_BY_DIFF_BAL_13)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:47:34 PM

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
            fleU030_PAID_DIFF.Dispose();
            fleU030_AUTO_ADJDTL.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U030B_PART2_SORT_BY_DIFF_BAL_13)"


    public void Run()
    {

        try
        {
            Request("SORT_BY_DIFF_BAL_13");

            while (fleU030_PAID_DIFF.QTPForMissing())
            {
                // --> GET U030_PAID_DIFF <--

                fleU030_PAID_DIFF.GetData();
                // --> End GET U030_PAID_DIFF <--


                if (Transaction())
                {

                    Sort(fleU030_PAID_DIFF.GetSortValue("PART_HDR_CLAIM_ID"), fleU030_PAID_DIFF.GetSortValue("X_DTL_BAL_DIFF"));



                }

            }


            while (Sort(fleU030_PAID_DIFF))
            {
                
                SubFile(ref m_trnTRANS_UPDATE, ref fleU030_AUTO_ADJDTL, fleU030_PAID_DIFF.At("PART_HDR_CLAIM_ID"), SubFileType.KeepSQL, fleU030_PAID_DIFF, "X_ADJ_SERV_CODE", "PART_HDR_CLAIM_ID", "CLMDTL_DIAG_CD", "CLMDTL_SV_DATE", "CLMDTL_LINE_NO", "X_BAL_DIFF",
                "PART_DTL_EXPLAN_CD", "X_AMT_BILLED", "X_AMT_DTL_TECH_BILLED");
             

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
            EndRequest("SORT_BY_DIFF_BAL_13");

        }

    }




    #endregion


}
//SORT_BY_DIFF_BAL_13



public class U030B_PART2_CALC_BATCH_NBR_14 : U030B_PART2
{

    public U030B_PART2_CALC_BATCH_NBR_14(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU030_AUTO_ADJDTL = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U030_AUTO_ADJDTL", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        X_COUNT = new CoreDecimal("X_COUNT", 6, this);
        X_BATCH_COUNT = new CoreDecimal("X_BATCH_COUNT", 6, this);
        X_CLAIM_BAL = new CoreInteger("X_CLAIM_BAL", 7, this);
        X_HDR_AMT_TECH_BILLED = new CoreInteger("X_HDR_AMT_TECH_BILLED", 7, this);
        X_HDR_AMT_BILLED = new CoreInteger("X_HDR_AMT_BILLED", 7, this);
        fleU030_SRT_ADJ = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U030_SRT_ADJ", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU030_UPDATE_CLMHDR = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U030_UPDATE_CLMHDR", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);


    }


    #region "Declarations (Variables, Files and Transactions)(U030B_PART2_CALC_BATCH_NBR_14)"

    private SqlFileObject fleU030_AUTO_ADJDTL;
    private CoreDecimal X_COUNT;
    private CoreDecimal X_BATCH_COUNT;
    private CoreInteger X_CLAIM_BAL;
    private CoreInteger X_HDR_AMT_TECH_BILLED;

    private CoreInteger X_HDR_AMT_BILLED;
    private SqlFileObject fleU030_SRT_ADJ;
    private SqlFileObject fleU030_UPDATE_CLMHDR;


    #endregion


    #region "Standard Generated Procedures(U030B_PART2_CALC_BATCH_NBR_14)"


    #region "Automatic Item Initialization(U030B_PART2_CALC_BATCH_NBR_14)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U030B_PART2_CALC_BATCH_NBR_14)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:47:34 PM

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
        fleU030_AUTO_ADJDTL.Transaction = m_trnTRANS_UPDATE;
        fleU030_SRT_ADJ.Transaction = m_trnTRANS_UPDATE;
        fleU030_UPDATE_CLMHDR.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U030B_PART2_CALC_BATCH_NBR_14)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:47:34 PM

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
            fleU030_AUTO_ADJDTL.Dispose();
            fleU030_SRT_ADJ.Dispose();
            fleU030_UPDATE_CLMHDR.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U030B_PART2_CALC_BATCH_NBR_14)"


    public void Run()
    {

        try
        {
            Request("CALC_BATCH_NBR_14");

            while (fleU030_AUTO_ADJDTL.QTPForMissing())
            {
                // --> GET U030_AUTO_ADJDTL <--

                fleU030_AUTO_ADJDTL.GetData();
                // --> End GET U030_AUTO_ADJDTL <--


                if (Transaction())
                {

                    Sort(fleU030_AUTO_ADJDTL.GetSortValue("PART_HDR_CLAIM_ID"), fleU030_AUTO_ADJDTL.GetSortValue("X_ADJ_SERV_CODE"));



                }

            }

            while (Sort(fleU030_AUTO_ADJDTL))
            {
                Count(ref X_COUNT);
                X_BATCH_COUNT.Value = QDesign.Ceiling(X_COUNT.Value / 99);
                X_CLAIM_BAL.Value = X_CLAIM_BAL.Value + fleU030_AUTO_ADJDTL.GetDecimalValue("X_BAL_DIFF");
                X_HDR_AMT_TECH_BILLED.Value = X_HDR_AMT_TECH_BILLED.Value + fleU030_AUTO_ADJDTL.GetDecimalValue("X_AMT_DTL_TECH_BILLED");
                X_HDR_AMT_BILLED.Value = X_HDR_AMT_BILLED.Value + fleU030_AUTO_ADJDTL.GetDecimalValue("X_AMT_BILLED");


                SubFile(ref m_trnTRANS_UPDATE, ref fleU030_SRT_ADJ, SubFileType.Keep, X_COUNT, X_BATCH_COUNT, fleU030_AUTO_ADJDTL);
               
                SubFile(ref m_trnTRANS_UPDATE, ref fleU030_UPDATE_CLMHDR, fleU030_AUTO_ADJDTL.At("PART_HDR_CLAIM_ID"), SubFileType.KeepSQL, fleU030_AUTO_ADJDTL, "PART_HDR_CLAIM_ID", X_CLAIM_BAL, "PART_DTL_EXPLAN_CD", X_HDR_AMT_BILLED, X_HDR_AMT_TECH_BILLED);
              

                Reset(ref X_CLAIM_BAL, fleU030_AUTO_ADJDTL.At("PART_HDR_CLAIM_ID"));
                Reset(ref X_HDR_AMT_TECH_BILLED, fleU030_AUTO_ADJDTL.At("PART_HDR_CLAIM_ID"));
                Reset(ref X_HDR_AMT_BILLED, fleU030_AUTO_ADJDTL.At("PART_HDR_CLAIM_ID"));

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
            EndRequest("CALC_BATCH_NBR_14");

        }

    }




    #endregion


}
//CALC_BATCH_NBR_14



public class U030B_PART2_CREATE_B_ADJUSTMENT_15 : U030B_PART2
{

    public U030B_PART2_CREATE_B_ADJUSTMENT_15(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU030_SRT_ADJ = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U030_SRT_ADJ", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF002_CLMHDR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "F002_CLMHDR", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleICONST_MSTR_REC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "ICONST_MSTR_REC", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_BATCH_NBR = new CoreInteger("X_BATCH_NBR", 6, this);
        fleU030BRADADJ = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U030BRADADJ", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF001_BATCH_CONTROL_FILE = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F001_BATCH_CONTROL_FILE", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_ADJ_HDR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "F002_ADJ_HDR", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_ADJ_DTL = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_DTL", "F002_ADJ_DTL", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleU030_DTL_KEY = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U030_DTL_KEY", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU030_ADJ_BATCHES = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U030_ADJ_BATCHES", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleICONST_MSTR_REC.SetItemFinals += fleICONST_MSTR_REC_SetItemFinals;
        X_CLINIC_BATCH_NBR.GetValue += X_CLINIC_BATCH_NBR_GetValue;
        X_MOD.GetValue += X_MOD_GetValue;
        X_CLAIM_NBR.GetValue += X_CLAIM_NBR_GetValue;
        X_OHIP_BAL.GetValue += X_OHIP_BAL_GetValue;
        X_TOT_CLAIM_AR_OMA.GetValue += X_TOT_CLAIM_AR_OMA_GetValue;
        X_AMT_TECH_BILLED.GetValue += X_AMT_TECH_BILLED_GetValue;
        BATCTRL_BATCH_STATUS_UNBALANCED.GetValue += BATCTRL_BATCH_STATUS_UNBALANCED_GetValue;
        BATCTRL_BATCH_STATUS_BALANCED.GetValue += BATCTRL_BATCH_STATUS_BALANCED_GetValue;
        BATCTRL_BATCH_STATUS_REV_UPDATED.GetValue += BATCTRL_BATCH_STATUS_REV_UPDATED_GetValue;
        BATCTRL_BATCH_STATUS_OHIP_SENT.GetValue += BATCTRL_BATCH_STATUS_OHIP_SENT_GetValue;
        BATCTRL_BATCH_STATUS_MONTHEND_DONE.GetValue += BATCTRL_BATCH_STATUS_MONTHEND_DONE_GetValue;
        CLMHDR_STATUS_OHIP_ACCEPTED.GetValue += CLMHDR_STATUS_OHIP_ACCEPTED_GetValue;
        fleF001_BATCH_CONTROL_FILE.InitializeItems += fleF001_BATCH_CONTROL_FILE_InitializeItems;
        fleF001_BATCH_CONTROL_FILE.SetItemFinals += fleF001_BATCH_CONTROL_FILE_SetItemFinals;
        fleF002_ADJ_HDR.InitializeItems += fleF002_ADJ_HDR_InitializeItems;
        fleF002_ADJ_DTL.InitializeItems += fleF002_ADJ_DTL_InitializeItems;

    }


    #region "Declarations (Variables, Files and Transactions)(U030B_PART2_CREATE_B_ADJUSTMENT_15)"

    private SqlFileObject fleU030_SRT_ADJ;
    private SqlFileObject fleF002_CLMHDR;
    private SqlFileObject fleF020_DOCTOR_MSTR;
    private SqlFileObject fleICONST_MSTR_REC;

    private void fleICONST_MSTR_REC_SetItemFinals()
    {

        try
        {
            fleICONST_MSTR_REC.set_SetValue("ICONST_CLINIC_BATCH_NBR", X_BATCH_NBR.Value);


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

    private CoreInteger X_BATCH_NBR;
    private DCharacter X_CLINIC_BATCH_NBR = new DCharacter("X_CLINIC_BATCH_NBR", 8);
    private void X_CLINIC_BATCH_NBR_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.Substring(fleU030_SRT_ADJ.GetStringValue("PART_HDR_CLAIM_ID"), 1, 2) + QDesign.ASCII(X_BATCH_NBR.Value, 6);


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
    private DDecimal X_MOD = new DDecimal("X_MOD", 6);
    private void X_MOD_GetValue(ref decimal Value)
    {

        try
        {
            Value = QDesign.PHMod(fleU030_SRT_ADJ.GetDecimalValue("X_COUNT"), 99);


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
    private DDecimal X_CLAIM_NBR = new DDecimal("X_CLAIM_NBR", 6);
    private void X_CLAIM_NBR_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(X_MOD.Value) != 0)
            {
                CurrentValue = X_MOD.Value;
            }
            else
            {
                CurrentValue = 99;
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
    private DInteger X_OHIP_BAL = new DInteger("X_OHIP_BAL", 7);
    private void X_OHIP_BAL_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleU030_SRT_ADJ.GetDecimalValue("X_BAL_DIFF") * -1;


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
    private DInteger X_TOT_CLAIM_AR_OMA = new DInteger("X_TOT_CLAIM_AR_OMA", 7);
    private void X_TOT_CLAIM_AR_OMA_GetValue(ref decimal Value)
    {

        try
        {

            // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

            Value = QDesign.Round((QDesign.Divide(fleF002_CLMHDR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OMA"), fleF002_CLMHDR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP"))) * X_OHIP_BAL.Value, 0, RoundOptionTypes.Near);


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
    private DInteger X_AMT_TECH_BILLED = new DInteger("X_AMT_TECH_BILLED", 7);
    private void X_AMT_TECH_BILLED_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0;

            // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

            if (QDesign.NULL(fleU030_SRT_ADJ.GetStringValue("PART_DTL_EXPLAN_CD")) == "80" & ((string.Compare(QDesign.Substring(fleU030_SRT_ADJ.GetStringValue("PART_HDR_CLAIM_ID"), 1, 2), "61") >= 0 & string.Compare(QDesign.Substring(fleU030_SRT_ADJ.GetStringValue("PART_HDR_CLAIM_ID"), 1, 2), "66") <= 0) | (string.Compare(QDesign.Substring(fleU030_SRT_ADJ.GetStringValue("PART_HDR_CLAIM_ID"), 1, 2), "71") >= 0 & string.Compare(QDesign.Substring(fleU030_SRT_ADJ.GetStringValue("PART_HDR_CLAIM_ID"), 1, 2), "75") <= 0)))
            {
                CurrentValue = X_OHIP_BAL.Value;
            }
            else
            {
               CurrentValue = QDesign.Round((QDesign.Divide(fleU030_SRT_ADJ.GetDecimalValue("X_AMT_DTL_TECH_BILLED"), fleU030_SRT_ADJ.GetDecimalValue("X_AMT_BILLED"))) * X_OHIP_BAL.Value, 0, RoundOptionTypes.Near);
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
    private DCharacter BATCTRL_BATCH_STATUS_UNBALANCED = new DCharacter("BATCTRL_BATCH_STATUS_UNBALANCED", 1);
    private void BATCTRL_BATCH_STATUS_UNBALANCED_GetValue(ref string Value)
    {

        try
        {
            Value = "0";


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
    private DCharacter BATCTRL_BATCH_STATUS_BALANCED = new DCharacter("BATCTRL_BATCH_STATUS_BALANCED", 1);
    private void BATCTRL_BATCH_STATUS_BALANCED_GetValue(ref string Value)
    {

        try
        {
            Value = "1";


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
    private DCharacter BATCTRL_BATCH_STATUS_REV_UPDATED = new DCharacter("BATCTRL_BATCH_STATUS_REV_UPDATED", 1);
    private void BATCTRL_BATCH_STATUS_REV_UPDATED_GetValue(ref string Value)
    {

        try
        {
            Value = "2";


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
    private DCharacter BATCTRL_BATCH_STATUS_OHIP_SENT = new DCharacter("BATCTRL_BATCH_STATUS_OHIP_SENT", 1);
    private void BATCTRL_BATCH_STATUS_OHIP_SENT_GetValue(ref string Value)
    {

        try
        {
            Value = "3";


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
    private DCharacter BATCTRL_BATCH_STATUS_MONTHEND_DONE = new DCharacter("BATCTRL_BATCH_STATUS_MONTHEND_DONE", 1);
    private void BATCTRL_BATCH_STATUS_MONTHEND_DONE_GetValue(ref string Value)
    {

        try
        {
            Value = "4";


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
    private DCharacter CLMHDR_STATUS_OHIP_ACCEPTED = new DCharacter("CLMHDR_STATUS_OHIP_ACCEPTED", 2);
    private void CLMHDR_STATUS_OHIP_ACCEPTED_GetValue(ref string Value)
    {

        try
        {
            Value = "00";


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







    private SqlFileObject fleU030BRADADJ;
    private SqlFileObject fleF001_BATCH_CONTROL_FILE;

    private void fleF001_BATCH_CONTROL_FILE_InitializeItems(bool Fixed)
    {

        try
        {
            if (!Fixed)
                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_BATCH_NBR", true, X_CLINIC_BATCH_NBR.Value);
            if (!Fixed)
                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_BATCH_TYPE", true, "A");
            if (!Fixed)
                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_CLINIC_NBR", true, fleICONST_MSTR_REC.GetStringValue("ICONST_CLINIC_NBR"));
            if (!Fixed)
                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_ADJ_CD", true, "B");
            if (!Fixed)
                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_DATE_BATCH_ENTERED", true, QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8));

            if (!Fixed)
                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_DATE_PERIOD_END", true, Convert.ToDecimal(fleICONST_MSTR_REC.GetDecimalValue("ICONST_DATE_PERIOD_END_YY").ToString().PadLeft(4, '0') + fleICONST_MSTR_REC.GetDecimalValue("ICONST_DATE_PERIOD_END_MM").ToString().PadLeft(2, '0') + fleICONST_MSTR_REC.GetDecimalValue("ICONST_DATE_PERIOD_END_DD").ToString().PadLeft(2, '0')));

            if (!Fixed)
                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_CYCLE_NBR", true, fleICONST_MSTR_REC.GetDecimalValue("ICONST_CLINIC_CYCLE_NBR"));
            if (!Fixed)
                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_AR_YY_MM", true, "000000");
            if (!Fixed)
                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_ADJ_CD_SUB_TYPE", true, "A");


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



    private void fleF001_BATCH_CONTROL_FILE_SetItemFinals()
    {

        try
        {
            fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_NBR_CLAIMS_IN_BATCH", X_CLAIM_NBR.Value);
            fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_LAST_CLAIM_NBR", X_CLAIM_NBR.Value);
            fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_BATCH_STATUS", BATCTRL_BATCH_STATUS_BALANCED.Value);
            fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_AGENT_CD", fleF002_CLMHDR.GetDecimalValue("CLMHDR_AGENT_CD"));


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

    private SqlFileObject fleF002_ADJ_HDR;

    private void fleF002_ADJ_HDR_InitializeItems(bool Fixed)
    {

        try
        {
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("KEY_CLM_TYPE", true, "B");
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("KEY_CLM_BATCH_NBR", true, X_CLINIC_BATCH_NBR.Value);
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("KEY_CLM_CLAIM_NBR", true, X_CLAIM_NBR.Value);
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("KEY_CLM_SERV_CODE", true, "00000");
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("KEY_CLM_ADJ_NBR", true, "0");
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_ORIG_BATCH_NBR", true, fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_BATCH_NBR"));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_ORIG_CLAIM_NBR", true, X_CLAIM_NBR.Value);
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_BATCH_TYPE", true, fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_BATCH_TYPE"));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_ADJ_CD_SUB_TYPE", true, fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_ADJ_CD_SUB_TYPE"));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_ADJ_CD", true, fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_ADJ_CD"));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_DATE_PERIOD_END", true, QDesign.NConvert(fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_DATE_PERIOD_END")));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_CYCLE_NBR", true, fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_CYCLE_NBR"));
            
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_BATCH_NBR", true, fleF002_CLMHDR.GetStringValue("CLMHDR_BATCH_NBR"));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_CLAIM_NBR", true, fleF002_CLMHDR.GetDecimalValue("CLMHDR_CLAIM_NBR"));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_ADJ_OMA_CD", true, fleF002_CLMHDR.GetStringValue("CLMHDR_ADJ_OMA_CD"));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_ADJ_OMA_SUFF", true,  fleF002_CLMHDR.GetStringValue("CLMHDR_ADJ_OMA_SUFF"));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_ADJ_ADJ_NBR", true, fleF002_CLMHDR.GetStringValue("CLMHDR_ADJ_ADJ_NBR"));

            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_DIAG_CD", true, fleF002_CLMHDR.GetDecimalValue("CLMHDR_DIAG_CD"));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_HOSP", true, fleF002_CLMHDR.GetStringValue("CLMHDR_HOSP"));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_I_O_PAT_IND", true, fleF002_CLMHDR.GetStringValue("CLMHDR_I_O_PAT_IND"));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_AGENT_CD", true, fleF002_CLMHDR.GetDecimalValue("CLMHDR_AGENT_CD"));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_LOC", true, fleF002_CLMHDR.GetStringValue("CLMHDR_LOC"));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_PAT_KEY_TYPE", true, fleF002_CLMHDR.GetStringValue("CLMHDR_PAT_KEY_TYPE") );
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_PAT_KEY_DATA", true,  fleF002_CLMHDR.GetStringValue("CLMHDR_PAT_KEY_DATA"));

           
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_PAT_ACRONYM6", true, fleF002_CLMHDR.GetStringValue("CLMHDR_PAT_ACRONYM6"));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_PAT_ACRONYM3", true, fleF002_CLMHDR.GetStringValue("CLMHDR_PAT_ACRONYM3"));

            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_DOC_DEPT", true, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT"));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_REFERENCE", true, fleU030_SRT_ADJ.GetStringValue("PART_DTL_EXPLAN_CD"));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_DATE_ADMIT", true, "00000000");

            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_MSG_NBR", true, QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8).Substring(0,2));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_REPRINT_FLAG", true, QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8).Substring(2, 1));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_SUB_NBR", true, QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8).Substring(3, 1));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_AUTO_LOGOUT", true, QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8).Substring(4, 1));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_FEE_COMPLEX", true, QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8).Substring(5, 1));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("FILLER", true, QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8).Substring(6, 2));
           

            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_DATE_SYS", true, QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_STATUS_OHIP", true, CLMHDR_STATUS_OHIP_ACCEPTED.Value);
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_TAPE_SUBMIT_IND", true, "N");
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_DOC_NBR_OHIP", true, 0);
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_DOC_SPEC_CD", true, 0);
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_REFER_DOC_NBR", true, 0);
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_CURR_PAYMENT", true, 0);
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_AMT_TECH_PAID", true, 0);
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_MANUAL_AND_TAPE_PAYMENTS", true, 0);
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_AMT_TECH_BILLED", true, X_AMT_TECH_BILLED.Value);
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_TOT_CLAIM_AR_OMA", true, X_TOT_CLAIM_AR_OMA.Value);
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_TOT_CLAIM_AR_OHIP", true, X_OHIP_BAL.Value);
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("KEY_P_CLM_TYPE", true, "Z");
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("KEY_P_CLM_DATA", true, QDesign.Substring(fleF002_CLMHDR.GetStringValue("CLMHDR_PAT_KEY_TYPE") + fleF002_CLMHDR.GetStringValue("CLMHDR_PAT_KEY_DATA"), 2, 14));
            //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART


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

    private SqlFileObject fleF002_ADJ_DTL;

    private void fleF002_ADJ_DTL_InitializeItems(bool Fixed)
    {

        try
        {
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("KEY_CLM_TYPE", true, "B");
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("KEY_CLM_BATCH_NBR", true, X_CLINIC_BATCH_NBR.Value);
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("KEY_CLM_CLAIM_NBR", true, X_CLAIM_NBR.Value);
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("KEY_CLM_SERV_CODE", true, fleU030_SRT_ADJ.GetStringValue("X_ADJ_SERV_CODE"));
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("KEY_CLM_ADJ_NBR", true, "0");
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_BATCH_NBR", true, fleF002_ADJ_HDR.GetStringValue("CLMHDR_BATCH_NBR"));
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_CLAIM_NBR", true, fleF002_ADJ_HDR.GetDecimalValue("CLMHDR_CLAIM_NBR"));
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_OMA_CD", true, QDesign.Substring(fleU030_SRT_ADJ.GetStringValue("X_ADJ_SERV_CODE"), 1, 4));
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_OMA_SUFF", true, QDesign.Substring(fleU030_SRT_ADJ.GetStringValue("X_ADJ_SERV_CODE"), 5, 1));
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_ADJ_NBR", true, 1);
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_AGENT_CD", true, fleF002_ADJ_HDR.GetDecimalValue("CLMHDR_AGENT_CD"));
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_ADJ_CD", true, fleF002_ADJ_HDR.GetStringValue("CLMHDR_ADJ_CD"));

            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_SV_YY", true, fleU030_SRT_ADJ.GetStringValue("CLMDTL_SV_DATE").Substring(0,4));
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_SV_MM", true, fleU030_SRT_ADJ.GetStringValue("CLMDTL_SV_DATE").Substring(4,2));
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_SV_DD", true, fleU030_SRT_ADJ.GetStringValue("CLMDTL_SV_DATE").Substring(6,2));

           
          
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_DATE_PERIOD_END", true, QDesign.ASCII(fleF002_ADJ_HDR.GetDecimalValue("CLMHDR_DATE_PERIOD_END"), 8));
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_CYCLE_NBR", true, fleF002_ADJ_HDR.GetDecimalValue("CLMHDR_CYCLE_NBR"));
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_ORIG_BATCH_NBR", true, fleF002_ADJ_HDR.GetStringValue("CLMHDR_ORIG_BATCH_NBR"));
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_ORIG_CLAIM_NBR_IN_BATCH", true, fleF002_ADJ_HDR.GetDecimalValue("CLMHDR_ORIG_CLAIM_NBR"));
          
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_FEE_OMA", true, fleF002_ADJ_HDR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OMA"));
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_FEE_OHIP", true, fleF002_ADJ_HDR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP"));
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_AMT_TECH_BILLED", true, fleF002_ADJ_HDR.GetDecimalValue("CLMHDR_AMT_TECH_BILLED"));
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_DIAG_CD", true, fleU030_SRT_ADJ.GetDecimalValue("CLMDTL_DIAG_CD"));
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_REV_GROUP_CD", true, " ");
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_LINE_NO", true, fleU030_SRT_ADJ.GetDecimalValue("CLMDTL_LINE_NO"));
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("KEY_P_CLM_TYPE", true, "Z");
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("KEY_P_CLM_DATA", true, X_CLINIC_BATCH_NBR.Value + QDesign.ASCII(X_CLAIM_NBR.Value, 2) + fleU030_SRT_ADJ.GetStringValue("X_ADJ_SERV_CODE") + "0");


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








    private SqlFileObject fleU030_DTL_KEY;







    private SqlFileObject fleU030_ADJ_BATCHES;


    #endregion


    #region "Standard Generated Procedures(U030B_PART2_CREATE_B_ADJUSTMENT_15)"


    #region "Automatic Item Initialization(U030B_PART2_CREATE_B_ADJUSTMENT_15)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U030B_PART2_CREATE_B_ADJUSTMENT_15)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:47:34 PM

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
        fleU030_SRT_ADJ.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLMHDR.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleICONST_MSTR_REC.Transaction = m_trnTRANS_UPDATE;
        fleU030BRADADJ.Transaction = m_trnTRANS_UPDATE;
        fleF001_BATCH_CONTROL_FILE.Transaction = m_trnTRANS_UPDATE;
        fleF002_ADJ_HDR.Transaction = m_trnTRANS_UPDATE;
        fleF002_ADJ_DTL.Transaction = m_trnTRANS_UPDATE;
        fleU030_DTL_KEY.Transaction = m_trnTRANS_UPDATE;
        fleU030_ADJ_BATCHES.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U030B_PART2_CREATE_B_ADJUSTMENT_15)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:47:35 PM

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
            fleU030_SRT_ADJ.Dispose();
            fleF002_CLMHDR.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleICONST_MSTR_REC.Dispose();
            fleU030BRADADJ.Dispose();
            fleF001_BATCH_CONTROL_FILE.Dispose();
            fleF002_ADJ_HDR.Dispose();
            fleF002_ADJ_DTL.Dispose();
            fleU030_DTL_KEY.Dispose();
            fleU030_ADJ_BATCHES.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U030B_PART2_CREATE_B_ADJUSTMENT_15)"


    public void Run()
    {

        try
        {
            Request("CREATE_B_ADJUSTMENT_15");

            while (fleU030_SRT_ADJ.QTPForMissing())
            {
                // --> GET U030_SRT_ADJ <--

                fleU030_SRT_ADJ.GetData();
                // --> End GET U030_SRT_ADJ <--

                while (fleF002_CLMHDR.QTPForMissing("1"))
                {
                    // --> GET F002_CLMHDR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_CLMHDR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("B"));
                    m_strWhere.Append(" And ").Append(fleF002_CLMHDR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(QDesign.Substring(fleU030_SRT_ADJ.GetStringValue("PART_HDR_CLAIM_ID"), 1, 8)));
                    m_strWhere.Append(" And ").Append(fleF002_CLMHDR.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ");
                    m_strWhere.Append((QDesign.NConvert(QDesign.Substring(fleU030_SRT_ADJ.GetStringValue("PART_HDR_CLAIM_ID"), 9, 2))));
                    m_strWhere.Append(" And ").Append(fleF002_CLMHDR.ElementOwner("KEY_CLM_SERV_CODE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("00000"));
                    m_strWhere.Append(" And ").Append(fleF002_CLMHDR.ElementOwner("KEY_CLM_ADJ_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("0"));

                    fleF002_CLMHDR.GetData(m_strWhere.ToString());
                    // --> End GET F002_CLMHDR <--

                    while (fleF020_DOCTOR_MSTR.QTPForMissing("2"))
                    {
                        // --> GET F020_DOCTOR_MSTR <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(QDesign.Substring(fleU030_SRT_ADJ.GetStringValue("PART_HDR_CLAIM_ID"), 3, 3)));

                        fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString());
                        // --> End GET F020_DOCTOR_MSTR <--

                        while (fleICONST_MSTR_REC.QTPForMissing("3"))
                        {
                            // --> GET ICONST_MSTR_REC <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleICONST_MSTR_REC.ElementOwner("ICONST_CLINIC_NBR_1_2")).Append(" = ");
                            m_strWhere.Append((QDesign.NConvert(QDesign.Substring(fleU030_SRT_ADJ.GetStringValue("PART_HDR_CLAIM_ID"), 1, 2))));

                            fleICONST_MSTR_REC.GetData(m_strWhere.ToString());
                            // --> End GET ICONST_MSTR_REC <--


                            if (Transaction())
                            {

                                Sort(fleU030_SRT_ADJ.GetSortValue("X_BATCH_COUNT"), fleU030_SRT_ADJ.GetSortValue("PART_HDR_CLAIM_ID"));



                            }

                        }

                    }

                }

            }

            while (Sort(fleU030_SRT_ADJ, fleF002_CLMHDR, fleF020_DOCTOR_MSTR, fleICONST_MSTR_REC))
            {
                if (AtInitial())
                {
                    X_BATCH_NBR.Value = fleICONST_MSTR_REC.GetDecimalValue("ICONST_CLINIC_BATCH_NBR");
                }

                SubFile(ref m_trnTRANS_UPDATE, ref fleU030BRADADJ, SubFileType.KeepSQL, X_CLINIC_BATCH_NBR, X_CLAIM_NBR, fleF002_CLMHDR, "CLMHDR_TOT_CLAIM_AR_OMA", X_TOT_CLAIM_AR_OMA, "CLMHDR_TOT_CLAIM_AR_OHIP", X_OHIP_BAL,
                "CLMHDR_AMT_TECH_BILLED", X_AMT_TECH_BILLED, fleU030_SRT_ADJ);
             
                SubTotal(ref fleF001_BATCH_CONTROL_FILE, "BATCTRL_AMT_ACT", X_OHIP_BAL.Value);
                SubTotal(ref fleF001_BATCH_CONTROL_FILE, "BATCTRL_AMT_EST", X_OHIP_BAL.Value);
                SubTotal(ref fleF001_BATCH_CONTROL_FILE, "BATCTRL_CALC_AR_DUE", X_OHIP_BAL.Value);
                SubTotal(ref fleF001_BATCH_CONTROL_FILE, "BATCTRL_CALC_TOT_REV", X_OHIP_BAL.Value);

                fleF002_ADJ_HDR.OutPut(OutPutType.Add);
                fleF002_ADJ_DTL.OutPut(OutPutType.Add);
               
                m_strWhere = new StringBuilder(" WHERE ");
                m_strWhere.Append(" ").Append(fleF002_ADJ_HDR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                m_strWhere.Append(Common.StringToField("B"));
                m_strWhere.Append(" And ").Append(fleF002_ADJ_HDR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                m_strWhere.Append(Common.StringToField(X_CLINIC_BATCH_NBR.Value));
                m_strWhere.Append(" And ").Append(fleF002_ADJ_HDR.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ");
                m_strWhere.Append(X_CLAIM_NBR.Value);
                m_strWhere.Append(" And ").Append(fleF002_ADJ_HDR.ElementOwner("KEY_CLM_SERV_CODE")).Append(" = ");
                m_strWhere.Append(Common.StringToField("00000"));
                m_strWhere.Append(" And ").Append(fleF002_ADJ_HDR.ElementOwner("KEY_CLM_ADJ_NBR")).Append(" = ");
                m_strWhere.Append(Common.StringToField("0"));
                fleF002_ADJ_HDR.GetData(m_strWhere.ToString());


                SubFile(ref m_trnTRANS_UPDATE, ref fleU030_DTL_KEY, SubFileType.KeepSQL, fleF002_ADJ_HDR, "KEY_CLM_TYPE", "KEY_CLM_BATCH_NBR", "KEY_CLM_CLAIM_NBR", "KEY_CLM_SERV_CODE", "KEY_CLM_ADJ_NBR");

                if (fleU030_SRT_ADJ.At("X_BATCH_COUNT"))
                {
                    fleF001_BATCH_CONTROL_FILE.OutPut(OutPutType.Add, fleU030_SRT_ADJ.At("X_BATCH_COUNT"), null);

                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF001_BATCH_CONTROL_FILE.ElementOwner("BATCTRL_BATCH_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(X_CLINIC_BATCH_NBR.Value));
                    fleF001_BATCH_CONTROL_FILE.GetData(m_strWhere.ToString());

                    SubFile(ref m_trnTRANS_UPDATE, ref fleU030_ADJ_BATCHES, fleU030_SRT_ADJ.At("X_BATCH_COUNT"), SubFileType.KeepSQL, fleF001_BATCH_CONTROL_FILE, "BATCTRL_BATCH_NBR");

                    X_BATCH_NBR.Value = fleICONST_MSTR_REC.GetDecimalValue("ICONST_CLINIC_BATCH_NBR") + fleU030_SRT_ADJ.GetDecimalValue("X_BATCH_COUNT");
                }
                fleICONST_MSTR_REC.OutPut(OutPutType.Update, AtFinal(), null);
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
            EndRequest("CREATE_B_ADJUSTMENT_15");

        }

    }




    #endregion


}
//CREATE_B_ADJUSTMENT_15



public class U030B_PART2_HOLD_CLAIM_STATUS_16 : U030B_PART2
{

    public U030B_PART2_HOLD_CLAIM_STATUS_16(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU030_NO_ADJ = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U030_NO_ADJ", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF002_CLAIMS_MSTR.SetItemFinals += fleF002_CLAIMS_MSTR_SetItemFinals;

    }


    #region "Declarations (Variables, Files and Transactions)(U030B_PART2_HOLD_CLAIM_STATUS_16)"

    private SqlFileObject fleU030_NO_ADJ;
    private SqlFileObject fleF002_CLAIMS_MSTR;

    private void fleF002_CLAIMS_MSTR_SetItemFinals()
    {

        try
        {
            fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_TAPE_SUBMIT_IND", "H");
            fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_STATUS_OHIP", fleU030_NO_ADJ.GetStringValue("PART_HDR_EXPLAN_CD"));


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


    #region "Standard Generated Procedures(U030B_PART2_HOLD_CLAIM_STATUS_16)"


    #region "Automatic Item Initialization(U030B_PART2_HOLD_CLAIM_STATUS_16)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U030B_PART2_HOLD_CLAIM_STATUS_16)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:47:35 PM

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
        fleU030_NO_ADJ.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_MSTR.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U030B_PART2_HOLD_CLAIM_STATUS_16)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:47:35 PM

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
            fleU030_NO_ADJ.Dispose();
            fleF002_CLAIMS_MSTR.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U030B_PART2_HOLD_CLAIM_STATUS_16)"


    public void Run()
    {

        try
        {
            Request("HOLD_CLAIM_STATUS_16");

            while (fleU030_NO_ADJ.QTPForMissing())
            {
                // --> GET U030_NO_ADJ <--

                fleU030_NO_ADJ.GetData();
                // --> End GET U030_NO_ADJ <--

                while (fleF002_CLAIMS_MSTR.QTPForMissing("1"))
                {
                    // --> GET F002_CLAIMS_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("B"));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(QDesign.Substring(fleU030_NO_ADJ.GetStringValue("PART_HDR_CLAIM_ID"), 1, 8)));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ");
                    m_strWhere.Append((QDesign.NConvert(QDesign.Substring(fleU030_NO_ADJ.GetStringValue("PART_HDR_CLAIM_ID"), 9, 2))));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_SERV_CODE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("00000"));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_ADJ_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("0"));

                    fleF002_CLAIMS_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F002_CLAIMS_MSTR <--


                    if (Transaction())
                    {

                        fleF002_CLAIMS_MSTR.OutPut(OutPutType.Update);
                     
                    }

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
            EndRequest("HOLD_CLAIM_STATUS_16");

        }

    }




    #endregion


}
//HOLD_CLAIM_STATUS_16



public class U030B_PART2_PART_ADJ_BATCH_17 : U030B_PART2
{

    public U030B_PART2_PART_ADJ_BATCH_17(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU030_ADJ_BATCHES = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U030_ADJ_BATCHES", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        flePART_ADJ_BATCH = new SqlFileObject(this, FileTypes.Primary, 0, "SEQUENTIAL", "PART_ADJ_BATCH", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        flePART_ADJ_BATCH.SetItemFinals += flePART_ADJ_BATCH_SetItemFinals;

    }


    #region "Declarations (Variables, Files and Transactions)(U030B_PART2_PART_ADJ_BATCH_17)"

    private SqlFileObject fleU030_ADJ_BATCHES;
    private SqlFileObject fleF002_CLAIMS_MSTR;
    public override bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_OMA_CD") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_OMA_SUFF") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_ADJ_NBR")) == "000000")
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

    private SqlFileObject flePART_ADJ_BATCH;

    private void flePART_ADJ_BATCH_SetItemFinals()
    {

        try
        {
            flePART_ADJ_BATCH.set_SetValue("PART_ADJ_CLAIM_ID", QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_BATCH_NBR") + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_CLAIM_NBR"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_OMA_CD") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_OMA_SUFF") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_ADJ_NBR"), 1, 11));
            //Parent:CLMHDR_CLAIM_ID
            flePART_ADJ_BATCH.set_SetValue("PART_ADJ_BAL", fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP"));


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


    #region "Standard Generated Procedures(U030B_PART2_PART_ADJ_BATCH_17)"


    #region "Automatic Item Initialization(U030B_PART2_PART_ADJ_BATCH_17)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U030B_PART2_PART_ADJ_BATCH_17)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:47:35 PM

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
        fleU030_ADJ_BATCHES.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_MSTR.Transaction = m_trnTRANS_UPDATE;
        flePART_ADJ_BATCH.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U030B_PART2_PART_ADJ_BATCH_17)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:47:35 PM

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
            fleU030_ADJ_BATCHES.Dispose();
            fleF002_CLAIMS_MSTR.Dispose();
            flePART_ADJ_BATCH.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U030B_PART2_PART_ADJ_BATCH_17)"


    public void Run()
    {

        try
        {
            Request("PART_ADJ_BATCH_17");

            while (fleU030_ADJ_BATCHES.QTPForMissing())
            {
                // --> GET U030_ADJ_BATCHES <--

                fleU030_ADJ_BATCHES.GetData();
                // --> End GET U030_ADJ_BATCHES <--

                while (fleF002_CLAIMS_MSTR.QTPForMissing("1"))
                {
                    // --> GET F002_CLAIMS_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("B"));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleU030_ADJ_BATCHES.GetStringValue("BATCTRL_BATCH_NBR")));

                    fleF002_CLAIMS_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F002_CLAIMS_MSTR <--

                    if (Transaction())
                    {

                        if (Select_If())
                        {

                            flePART_ADJ_BATCH.OutPut(OutPutType.Add);
                          
                        }

                    }

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
            EndRequest("PART_ADJ_BATCH_17");

        }

    }




    #endregion


}
//PART_ADJ_BATCH_17



public class U030B_PART2_UPDATE_CLAIM_BAL_18 : U030B_PART2
{

    public U030B_PART2_UPDATE_CLAIM_BAL_18(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU030BRADADJ = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U030BRADADJ", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");


    }


    #region "Declarations (Variables, Files and Transactions)(U030B_PART2_UPDATE_CLAIM_BAL_18)"

    private SqlFileObject fleU030BRADADJ;
    private SqlFileObject fleF002_CLAIMS_MSTR;

    #endregion


    #region "Standard Generated Procedures(U030B_PART2_UPDATE_CLAIM_BAL_18)"


    #region "Automatic Item Initialization(U030B_PART2_UPDATE_CLAIM_BAL_18)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U030B_PART2_UPDATE_CLAIM_BAL_18)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:47:36 PM

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
        fleU030BRADADJ.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_MSTR.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U030B_PART2_UPDATE_CLAIM_BAL_18)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:47:36 PM

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
            fleU030BRADADJ.Dispose();
            fleF002_CLAIMS_MSTR.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U030B_PART2_UPDATE_CLAIM_BAL_18)"


    public void Run()
    {

        try
        {
            Request("UPDATE_CLAIM_BAL_18");

            while (fleU030BRADADJ.QTPForMissing())
            {
                // --> GET U030BRADADJ <--

                fleU030BRADADJ.GetData();
                // --> End GET U030BRADADJ <--

                while (fleF002_CLAIMS_MSTR.QTPForMissing("1"))
                {
                    // --> GET F002_CLAIMS_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("B"));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(QDesign.Substring(fleU030BRADADJ.GetStringValue("PART_HDR_CLAIM_ID"), 1, 8)));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ");
                    m_strWhere.Append((QDesign.NConvert(QDesign.Substring(fleU030BRADADJ.GetStringValue("PART_HDR_CLAIM_ID"), 9, 2))));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_SERV_CODE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("00000"));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_ADJ_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("0"));

                    fleF002_CLAIMS_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F002_CLAIMS_MSTR <--


                    if (Transaction())
                    {

                        Sort(fleU030BRADADJ.GetSortValue("PART_HDR_CLAIM_ID"));



                    }

                }

            }


            while (Sort(fleU030BRADADJ, fleF002_CLAIMS_MSTR))
            {
                SubTotal(ref fleF002_CLAIMS_MSTR, "CLMHDR_TOT_CLAIM_AR_OMA", fleU030BRADADJ.GetDecimalValue("X_TOT_CLAIM_AR_OMA"));


                SubTotal(ref fleF002_CLAIMS_MSTR, "CLMHDR_TOT_CLAIM_AR_OHIP", fleU030BRADADJ.GetDecimalValue("X_OHIP_BAL"));


                SubTotal(ref fleF002_CLAIMS_MSTR, "CLMHDR_AMT_TECH_BILLED", fleU030BRADADJ.GetDecimalValue("X_AMT_TECH_BILLED"));

      fleF002_CLAIMS_MSTR.OutPut(OutPutType.Update, fleU030BRADADJ.At("PART_HDR_CLAIM_ID"), null);
               
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
            EndRequest("UPDATE_CLAIM_BAL_18");

        }

    }




    #endregion


}
//UPDATE_CLAIM_BAL_18



public class U030B_PART2_DELETE_F002_OUTSTANDING_19 : U030B_PART2
{

    public U030B_PART2_DELETE_F002_OUTSTANDING_19(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU030_FULLY_PAID = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U030_FULLY_PAID", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF002_OUTSTANDING = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_OUTSTANDING", "", false, false, false, 0, "m_trnTRANS_UPDATE");


    }


    #region "Declarations (Variables, Files and Transactions)(U030B_PART2_DELETE_F002_OUTSTANDING_19)"

    private SqlFileObject fleU030_FULLY_PAID;
    private SqlFileObject fleF002_OUTSTANDING;

    #endregion


    #region "Standard Generated Procedures(U030B_PART2_DELETE_F002_OUTSTANDING_19)"


    #region "Automatic Item Initialization(U030B_PART2_DELETE_F002_OUTSTANDING_19)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U030B_PART2_DELETE_F002_OUTSTANDING_19)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:47:36 PM

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
        fleU030_FULLY_PAID.Transaction = m_trnTRANS_UPDATE;
        fleF002_OUTSTANDING.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U030B_PART2_DELETE_F002_OUTSTANDING_19)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:47:36 PM

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
            fleU030_FULLY_PAID.Dispose();
            fleF002_OUTSTANDING.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U030B_PART2_DELETE_F002_OUTSTANDING_19)"


    public void Run()
    {

        try
        {
            Request("DELETE_F002_OUTSTANDING_19");

            while (fleU030_FULLY_PAID.QTPForMissing())
            {
                // --> GET U030_FULLY_PAID <--

                fleU030_FULLY_PAID.GetData();
                // --> End GET U030_FULLY_PAID <--

                while (fleF002_OUTSTANDING.QTPForMissing("1"))
                {
                    // --> GET F002_OUTSTANDING <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_OUTSTANDING.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("B"));
                    m_strWhere.Append(" And ").Append(fleF002_OUTSTANDING.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((fleU030_FULLY_PAID.GetStringValue("X_GROUP_NBR") + QDesign.Substring(fleU030_FULLY_PAID.GetStringValue("RAT_145_ACCOUNT_NBR"), 1, 6))));
                    m_strWhere.Append(" And ").Append(fleF002_OUTSTANDING.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ");
                    m_strWhere.Append((QDesign.NConvert(QDesign.Substring(fleU030_FULLY_PAID.GetStringValue("RAT_145_ACCOUNT_NBR"), 7, 2))));

                    fleF002_OUTSTANDING.GetData(m_strWhere.ToString());
                    // --> End GET F002_OUTSTANDING <--


                    if (Transaction())
                    {


                        fleF002_OUTSTANDING.OutPut(OutPutType.Delete);
                     
                    }

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
            EndRequest("DELETE_F002_OUTSTANDING_19");

        }

    }




    #endregion


}
//DELETE_F002_OUTSTANDING_19



public class U030B_PART2_DELETE_F002_OUTSTANDING_ADJ_20 : U030B_PART2
{

    public U030B_PART2_DELETE_F002_OUTSTANDING_ADJ_20(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU030_SRT_ADJ = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U030_SRT_ADJ", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF002_OUTSTANDING = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_OUTSTANDING", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        X_BAL.GetValue += X_BAL_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(U030B_PART2_DELETE_F002_OUTSTANDING_ADJ_20)"

    private SqlFileObject fleU030_SRT_ADJ;
    private SqlFileObject fleF002_OUTSTANDING;
    private SqlFileObject fleF002_CLAIMS_MSTR;
    private DDecimal X_BAL = new DDecimal("X_BAL", 7);
    private void X_BAL_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP") + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_MANUAL_AND_TAPE_PAYMENTS");


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
            if (QDesign.NULL(X_BAL.Value) == 0)
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


    #endregion


    #region "Standard Generated Procedures(U030B_PART2_DELETE_F002_OUTSTANDING_ADJ_20)"


    #region "Automatic Item Initialization(U030B_PART2_DELETE_F002_OUTSTANDING_ADJ_20)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U030B_PART2_DELETE_F002_OUTSTANDING_ADJ_20)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:47:36 PM

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
        fleU030_SRT_ADJ.Transaction = m_trnTRANS_UPDATE;
        fleF002_OUTSTANDING.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_MSTR.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U030B_PART2_DELETE_F002_OUTSTANDING_ADJ_20)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:47:37 PM

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
            fleU030_SRT_ADJ.Dispose();
            fleF002_OUTSTANDING.Dispose();
            fleF002_CLAIMS_MSTR.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U030B_PART2_DELETE_F002_OUTSTANDING_ADJ_20)"


    public void Run()
    {

        try
        {
            Request("DELETE_F002_OUTSTANDING_ADJ_20");

            while (fleU030_SRT_ADJ.QTPForMissing())
            {
                // --> GET U030_SRT_ADJ <--

                fleU030_SRT_ADJ.GetData();
                // --> End GET U030_SRT_ADJ <--

                while (fleF002_OUTSTANDING.QTPForMissing("1"))
                {
                    // --> GET F002_OUTSTANDING <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_OUTSTANDING.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("B"));
                    m_strWhere.Append(" And ").Append(fleF002_OUTSTANDING.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(QDesign.Substring(fleU030_SRT_ADJ.GetStringValue("PART_HDR_CLAIM_ID"), 1, 8)));
                    m_strWhere.Append(" And ").Append(fleF002_OUTSTANDING.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ");
                    m_strWhere.Append((QDesign.NConvert(QDesign.Substring(fleU030_SRT_ADJ.GetStringValue("PART_HDR_CLAIM_ID"), 9, 2))));

                    fleF002_OUTSTANDING.GetData(m_strWhere.ToString());
                    // --> End GET F002_OUTSTANDING <--

                    while (fleF002_CLAIMS_MSTR.QTPForMissing("2"))
                    {
                        // --> GET F002_CLAIMS_MSTR <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                        m_strWhere.Append(Common.StringToField("B"));
                        m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(QDesign.Substring(fleU030_SRT_ADJ.GetStringValue("PART_HDR_CLAIM_ID"), 1, 8)));
                        m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ");
                        m_strWhere.Append((QDesign.NConvert(QDesign.Substring(fleU030_SRT_ADJ.GetStringValue("PART_HDR_CLAIM_ID"), 9, 2))));
                        m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_SERV_CODE")).Append(" = ");
                        m_strWhere.Append(Common.StringToField("00000"));
                        m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_ADJ_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField("0"));

                        fleF002_CLAIMS_MSTR.GetData(m_strWhere.ToString());
                        // --> End GET F002_CLAIMS_MSTR <--


                        if (Transaction())
                        {

                            if (Select_If())
                            {

                                Sort(fleU030_SRT_ADJ.GetSortValue("PART_HDR_CLAIM_ID"));



                            }

                        }

                    }

                }

            }


            while (Sort(fleU030_SRT_ADJ, fleF002_OUTSTANDING, fleF002_CLAIMS_MSTR))
            {


                fleF002_OUTSTANDING.OutPut(OutPutType.Delete, fleU030_SRT_ADJ.At("PART_HDR_CLAIM_ID"), null);
             
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
            EndRequest("DELETE_F002_OUTSTANDING_ADJ_20");

        }

    }




    #endregion


}
//DELETE_F002_OUTSTANDING_ADJ_20




