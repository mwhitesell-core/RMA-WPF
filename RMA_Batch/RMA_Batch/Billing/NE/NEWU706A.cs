
#region "Screen Comments"

// #> PROGRAM-ID.     NEWU706A.QTS
// ((C)) Dyad Technologies
// PROGRAM PURPOSE: SELECT  CORRECT  CLAIMS FROM THE SUSPENDED FILES
// AND TRANSFER THEM INTO THE LIVE F002 CLAIMS MASTER.
// MODIFICATION HISTORY
// DATE    SMS #  WHO     DESCRIPTION
// 93/07/21     M.C.    - SMS 142
// - CLONE FROM U706A.QTS
// - USE DOC-NBR TO LINK TO F020
// - DO NOT REQUIRE TO PROMPT FOR DOC NBR
// - WHEN CREATING RMA CLAIMS, ALSO CREATE
// RECORDS IN F071-CLIENT-RMA-CLAIM-NBR
// 93/08/31     M.C.    - SMS 142
// - ALSO DELETE  R ESUBMIT CLAIMS IN REQUEST
// U706A_DELETE_CLAIMS
// 93/08/31          M.C.    - SMS 142
// - SET CLMHDR-MANUAL-REVIEW FROM CLMHDR-
// RELATIONSHIP OF F002-SUSPEND-HDR
// 94/10/15     B.E.    - ADDED CODE TO INITIALIZE FIELD CLMDTL-LINE-NO
// WHEN CREATING CLAIM DETAIL RECORDS.
// 96/07/22     M.C.    - PDR 649
// - DIFFERENT SERVICE MONTH CAN BE IN A
// DETAIL CLAIM
// - CHANGE X-ACCOUNTING-NBR NOT TO INCLUDE
// CLMDTL-SV-YY & CLMDTL-SV-MM
// 96/08/19     M.C.    - PDR 649 - REQUEST DELETE_CLAIMS DOES NOT
// WORK ANYMORE, RECEIVE ERROR  RECORD HAS
// BEEN CHANGED SINCE YOU FOUND IT , CONVERT
// THE REQUEST INTO 3 INDIVIDUAL REQUESTS
// DELETE_DETAIL, DELETE_ADDRESS, DELETE_HEADER
// 98/02/19    B.E.    - A NEW BATCH NUMBER MUST BE CREATED WHEN
// A DOCTOR S CLINIC OR SPECIALTY CODE CHANGES.
// IN REQUEST U706A_SELECT_COMPLETE_CLAIMS THE
// SORT AND KEEP AT CHANGED SO THAT  W-COUNT 
// IS RESET TO 1 IF CHANGE IN CLINIC/SPEC.
// REQUEST U706A_GEN_CLAIM_NBRS CHANGED
// TO BUILD BATCH NUMBER TAKING INTO CONSIDERATION
// IF CLINIC/DOC NUMBER HAS CHANGED.
// 98/04/17    M.C.    - CHANGE THE FORMULA FOR COUNTER-CLINIC-NBRS &
// COUNTER-SPEC-CODES, HOLD-CLINIC-NBR-1-2 &
// HOLD-SPEC-CD
// 98/06/02    M.C.    - CHANGE THE FORMULA FOR COUNTER-CLINIC-NBRS &
// W-BATCH-NBR AND COMMENT OUT COUNTER-SPEC-CD
// IN U706A_PROCESS_CLAIM_DETAILS REQUEST,
// CHANGE THE SORTED AND OUTPUT F001-BATCH-
// CONTROL-FILE STATEMENTS
// 98/09/14    B.E     - w-count was being reset a change in clinic/specialty
// which started batch number back at 1 again. If a 
// doctor had a large series of claims that increased
// batch number at each group of 99, then the reset
// caused the duplication of batch numbers. Code changed
// so that w-count reset only at change in doctor number
// so that it now counts all claims. This now calculates
// the next batch number correctly, however it doesn t
// reset the claim-nbr within the batch back to 1.
// Therefore each time the clinic/spec/agent changes 
// the 1st claim within the batch will start at the
// next higher number than the last claim nbr in 
// in the last batch. This could eventually be
// be fixed but isn t within this version of code.
// also needs check if agent changed
// 98/10/14    M.C.     - create  P  keys in header & detail records of
// f002-claims-mstr   
// 1999/jan/28 B.E./M.C.- y2k
// - use key-p-clm-data instead of the 4 items when creating
// p keys for claim header and detail records
// 1999/May/21 S.B.     - Added the use file def_batctrl_batch_status.def
// to remove any hardcoding of the 
// batctrl-batch-status.
// 1999/May/27 S.B.     - Added the use file
// def_clmhdr_status.def to 
// prevent hardcoding of clmhdr-status.
// 1999/May/28 S.B.     - Removed the nconvert from the iconst-clinic-nbr.
// 1999/Nov/08 M.C.     - output f071 record first before creating f002/f001
// record in u706a_process_claim_headers request
// 1999/Nov/12 M.C.     - reset batch nbr to 1 if ws-batch-nbr = 1000 in
// u706a_gen_claim_nbrs request
// 2000/Jan/18 M.C.     - include clinic nbr when creating f071 record in   
// u706a_process_claim_headers request
// 2000/Feb/08 B.A.     - Added code to put confidential-flag to 
// f002-claims-mstr and put a corresponding description
// 2000/Feb/16 M.C.     - do not process f002-suspend-dtl where clmdtl-status
// equal to `D` 
// 2000/may/03 B.E.     - clmhdr-date-sys represents the date the claim
// was  keyed . For diskette/web claims this date
// was set at the time the file was uploaded into
// suspense files. The newu706a pgm was changed to 
// use the actual system date the day the suspend
// record was loaded into the claims mstr instead
// of the date it was loaded into suspense.
// 2000/may/04 M.C.     - add clmhdr-doc-nbr in the sort/sorted statements of
// request u706a_select_complete_claims, and       
// u706a_gen_claim_nbrs 
// 2000/jun/08 B.E.     - write out only 1 description rec for confidential
// claims with message  NO VERIFICATION PLEASE 
// 2000/jun/12 B.E.     - no defaulting of f002`s  manual-revie ` based upon 
//  confidentiality  field. Manual review is always
// set to value of manual-review field in susp hdr.
// 2000/sep/04 B.E.      - calculation of total nbr services now based
// upon new redefined fields added to dictionary
// 2000/sep/21 B.E.      - requests that delete hdr/dtl/address records
// check clmhdr status. Added `i`gnore status to select
// deletion of transactions
// - added request to delete description records
// 2000/sep/23 B.E. - added request to upload description records into
// claim description records
// 2000/oct/02 B.E. - updates claim header total oma/ohip amts with 
// appropriate oma/ohip amt rather than putting ohip
// amount into both fields
// - in request that deletes header record included
// select of headers with `delete` or `ignore` status
// 2000/oct/11 B.E. - don`t pickup description records unless header`s
// manual-review field =  Y  (some comments are passed
// in from the web and are only for RMA staff to 
// read - they don`t need to be brought into f002
// 2000/nov/07 M.C. - change the definition when defining ws-batch-nbr
// - add the new request u706a_gen_batch_nbrs,
// u706a_sort_batch_rec, modify request
// u706a_gen_claim_nbrs
// 2002/may/06 M.C.      - if clinic is 85 with payroll-flag = `B`, set clmhdr-clinic to 22
// 2002/jun/14 M.C. -  add  `on errors report` at the end of each output statement
// 2002/sep/30 M.C. -  assign the correct next batch nbr based on the clinic nbr
// 2003/jun/12 M.C. -  change to sort on t-batch-nbr instead of w-batch-nbr
// 2003/oct/23 M.C. -  reset the next batch nbr to 1 if greater than 999 for
// each clinic
// 2003/nov/19 M.C.      - store the clmhdr-serv-date from the minimum of clmdtl-serv-date
// 2003/dec/23 A.A. -  alpha doctor nbr
// 2004/jul/07 M.C. -   reinstate the change on 2003/jun/12
// -   change back the sort on w-batch-nbr instead of t-batch-nbr
// -   change output on f001 at w-batch-nbr instead of t-batch-nbr
// 2005/may/10 M.C. -   reinstate the change on 2003/jun/12 in request u706a_process_claim_details
// -   change back the sort on w-batch-nbr instead of t-batch-nbr
// -   change output on f001 at w-batch-nbr instead of t-batch-nbr
// 2005/may/16 M.C. -   include t-batch-nbr in the sort/ed statement before w-batch-nbr            
// 2007/apr/24 M.C. -   include clmhdr-doc-nbr in the sorted statement if not already done
// 2009/jan/16 brad1 - increase the number of batches/claims that can be processed in a single file
// from 27/2673 to 40/3960
// 2009/mar/23 MC1  - update pat-date-last-visit and pat-date-last-admit in the last request update_pat_clm_nbr
// to be the same as d001, and also u099.qts is checking these two dates for purge criteria
// 2010/Jun/03 MC2  - modify to make sure each request has on calculation and edit errors report, in update_pat_clm_nbr
// request, add xcount temp field and subfile savef010_mc for debug purpose in case there is data
// conversion on date fields.
// 2010/Jan/23 MC3 - include agent 4 when creating f002-claim-shadow
// 2013/Apr/25 MC4 - set clmhdr values properly for agent 6           
// *******************************************************************************


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class NEWU706A : BaseClassControl
{

    private NEWU706A m_NEWU706A;

    public NEWU706A(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public NEWU706A(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_NEWU706A != null))
        {
            m_NEWU706A.CloseTransactionObjects();
            m_NEWU706A = null;
        }
    }

    public NEWU706A GetNEWU706A(int Level)
    {
        if (m_NEWU706A == null)
        {
            m_NEWU706A = new NEWU706A("NEWU706A", Level);
        }
        else
        {
            m_NEWU706A.ResetValues();
        }
        return m_NEWU706A;
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

            NEWU706A_U706A_SELECT_COMPLETE_CLAIMS_1 U706A_SELECT_COMPLETE_CLAIMS_1 = new NEWU706A_U706A_SELECT_COMPLETE_CLAIMS_1(Name, Level);
            U706A_SELECT_COMPLETE_CLAIMS_1.Run();
            U706A_SELECT_COMPLETE_CLAIMS_1.Dispose();
            U706A_SELECT_COMPLETE_CLAIMS_1 = null;

            NEWU706A_U706A_GEN_CLAIM_NBRS_2 U706A_GEN_CLAIM_NBRS_2 = new NEWU706A_U706A_GEN_CLAIM_NBRS_2(Name, Level);
            U706A_GEN_CLAIM_NBRS_2.Run();
            U706A_GEN_CLAIM_NBRS_2.Dispose();
            U706A_GEN_CLAIM_NBRS_2 = null;

            NEWU706A_U706A_SORT_BATCH_REC_3 U706A_SORT_BATCH_REC_3 = new NEWU706A_U706A_SORT_BATCH_REC_3(Name, Level);
            U706A_SORT_BATCH_REC_3.Run();
            U706A_SORT_BATCH_REC_3.Dispose();
            U706A_SORT_BATCH_REC_3 = null;

            NEWU706A_U706A_GEN_BATCH_NBRS_4 U706A_GEN_BATCH_NBRS_4 = new NEWU706A_U706A_GEN_BATCH_NBRS_4(Name, Level);
            U706A_GEN_BATCH_NBRS_4.Run();
            U706A_GEN_BATCH_NBRS_4.Dispose();
            U706A_GEN_BATCH_NBRS_4 = null;

            NEWU706A_U706A_PROCESS_CLAIM_HEADERS_5 U706A_PROCESS_CLAIM_HEADERS_5 = new NEWU706A_U706A_PROCESS_CLAIM_HEADERS_5(Name, Level);
            U706A_PROCESS_CLAIM_HEADERS_5.Run();
            U706A_PROCESS_CLAIM_HEADERS_5.Dispose();
            U706A_PROCESS_CLAIM_HEADERS_5 = null;

            NEWU706A_U706A_PROCESS_CLAIM_DETAILS_6 U706A_PROCESS_CLAIM_DETAILS_6 = new NEWU706A_U706A_PROCESS_CLAIM_DETAILS_6(Name, Level);
            U706A_PROCESS_CLAIM_DETAILS_6.Run();
            U706A_PROCESS_CLAIM_DETAILS_6.Dispose();
            U706A_PROCESS_CLAIM_DETAILS_6 = null;

            NEWU706A_U706A_PACK_ALL_SUSP_DESC_REC_INTO_1_SUBFILE_REC_7 U706A_PACK_ALL_SUSP_DESC_REC_INTO_1_SUBFILE_REC_7 = new NEWU706A_U706A_PACK_ALL_SUSP_DESC_REC_INTO_1_SUBFILE_REC_7(Name, Level);
            U706A_PACK_ALL_SUSP_DESC_REC_INTO_1_SUBFILE_REC_7.Run();
            U706A_PACK_ALL_SUSP_DESC_REC_INTO_1_SUBFILE_REC_7.Dispose();
            U706A_PACK_ALL_SUSP_DESC_REC_INTO_1_SUBFILE_REC_7 = null;

            NEWU706A_U706A_SPLIT_INTO_5_TIMES_22_8 U706A_SPLIT_INTO_5_TIMES_22_8 = new NEWU706A_U706A_SPLIT_INTO_5_TIMES_22_8(Name, Level);
            U706A_SPLIT_INTO_5_TIMES_22_8.Run();
            U706A_SPLIT_INTO_5_TIMES_22_8.Dispose();
            U706A_SPLIT_INTO_5_TIMES_22_8 = null;

            NEWU706A_U706A_CREATE_F002_CLAIM_DESC_RECS_9 U706A_CREATE_F002_CLAIM_DESC_RECS_9 = new NEWU706A_U706A_CREATE_F002_CLAIM_DESC_RECS_9(Name, Level);
            U706A_CREATE_F002_CLAIM_DESC_RECS_9.Run();
            U706A_CREATE_F002_CLAIM_DESC_RECS_9.Dispose();
            U706A_CREATE_F002_CLAIM_DESC_RECS_9 = null;

            NEWU706A_U706A_DELETE_DETAIL_10 U706A_DELETE_DETAIL_10 = new NEWU706A_U706A_DELETE_DETAIL_10(Name, Level);
            U706A_DELETE_DETAIL_10.Run();
            U706A_DELETE_DETAIL_10.Dispose();
            U706A_DELETE_DETAIL_10 = null;

            NEWU706A_U706A_DELETE_ADDRESS_11 U706A_DELETE_ADDRESS_11 = new NEWU706A_U706A_DELETE_ADDRESS_11(Name, Level);
            U706A_DELETE_ADDRESS_11.Run();
            U706A_DELETE_ADDRESS_11.Dispose();
            U706A_DELETE_ADDRESS_11 = null;

            NEWU706A_U706A_DELETE_DESC_12 U706A_DELETE_DESC_12 = new NEWU706A_U706A_DELETE_DESC_12(Name, Level);
            U706A_DELETE_DESC_12.Run();
            U706A_DELETE_DESC_12.Dispose();
            U706A_DELETE_DESC_12 = null;

            NEWU706A_U706A_DELETE_HEADER_13 U706A_DELETE_HEADER_13 = new NEWU706A_U706A_DELETE_HEADER_13(Name, Level);
            U706A_DELETE_HEADER_13.Run();
            U706A_DELETE_HEADER_13.Dispose();
            U706A_DELETE_HEADER_13 = null;

            NEWU706A_UPDATE_PAT_CLM_NBR_14 UPDATE_PAT_CLM_NBR_14 = new NEWU706A_UPDATE_PAT_CLM_NBR_14(Name, Level);
            UPDATE_PAT_CLM_NBR_14.Run();
            UPDATE_PAT_CLM_NBR_14.Dispose();
            UPDATE_PAT_CLM_NBR_14 = null;

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



public class NEWU706A_U706A_SELECT_COMPLETE_CLAIMS_1 : NEWU706A
{

    public NEWU706A_U706A_SELECT_COMPLETE_CLAIMS_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF002_SUSPEND_HDR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_SUSPEND_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_SUSPEND_DTL = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_SUSPEND_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        W_COUNT = new CoreDecimal("W_COUNT", 6, this);
        CLMHDR_TOT_CLAIM_AR_OMA = new CoreDecimal("CLMHDR_TOT_CLAIM_AR_OMA", 8, this);
        CLMHDR_TOT_CLAIM_AR_OHIP = new CoreDecimal("CLMHDR_TOT_CLAIM_AR_OHIP", 8, this);
        fleU706A_SEL_SUSP_HDR = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U706A_SEL_SUSP_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        CLMHDR_STATUS_COMPLETE.GetValue += CLMHDR_STATUS_COMPLETE_GetValue;
        CLMHDR_STATUS_DELETE.GetValue += CLMHDR_STATUS_DELETE_GetValue;
        CLMHDR_STATUS_CANCEL.GetValue += CLMHDR_STATUS_CANCEL_GetValue;
        CLMHDR_STATUS_RESUBMIT.GetValue += CLMHDR_STATUS_RESUBMIT_GetValue;
        CLMHDR_STATUS_ERROR.GetValue += CLMHDR_STATUS_ERROR_GetValue;
        CLMHDR_STATUS_NOT_COMPLETE.GetValue += CLMHDR_STATUS_NOT_COMPLETE_GetValue;
        CLMHDR_STATUS_DEFAULT.GetValue += CLMHDR_STATUS_DEFAULT_GetValue;
        UPDATED.GetValue += UPDATED_GetValue;
        CLMHDR_STATUS_IGNOR.GetValue += CLMHDR_STATUS_IGNOR_GetValue;
        CLMDTL_STATUS_DELETE.GetValue += CLMDTL_STATUS_DELETE_GetValue;
        CLMDTL_STATUS_NEW.GetValue += CLMDTL_STATUS_NEW_GetValue;
        CLMDTL_STATUS_ACTIVE.GetValue += CLMDTL_STATUS_ACTIVE_GetValue;
        CLMDTL_STATUS_UPDATED.GetValue += CLMDTL_STATUS_UPDATED_GetValue;
        W_CONVERT_CLINIC.GetValue += W_CONVERT_CLINIC_GetValue;
        CLMHDR_DOC_NBR.GetValue += CLMHDR_DOC_NBR_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(NEWU706A_U706A_SELECT_COMPLETE_CLAIMS_1)"

    private SqlFileObject fleF002_SUSPEND_HDR;
    private SqlFileObject fleF002_SUSPEND_DTL;
    private DCharacter CLMHDR_STATUS_COMPLETE = new DCharacter("CLMHDR_STATUS_COMPLETE", 1);
    private void CLMHDR_STATUS_COMPLETE_GetValue(ref string Value)
    {

        try
        {
            Value = "C";


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
    private DCharacter CLMHDR_STATUS_DELETE = new DCharacter("CLMHDR_STATUS_DELETE", 1);
    private void CLMHDR_STATUS_DELETE_GetValue(ref string Value)
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
    private DCharacter CLMHDR_STATUS_CANCEL = new DCharacter("CLMHDR_STATUS_CANCEL", 1);
    private void CLMHDR_STATUS_CANCEL_GetValue(ref string Value)
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
    private DCharacter CLMHDR_STATUS_RESUBMIT = new DCharacter("CLMHDR_STATUS_RESUBMIT", 1);
    private void CLMHDR_STATUS_RESUBMIT_GetValue(ref string Value)
    {

        try
        {
            Value = "R";


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
    private DCharacter CLMHDR_STATUS_ERROR = new DCharacter("CLMHDR_STATUS_ERROR", 1);
    private void CLMHDR_STATUS_ERROR_GetValue(ref string Value)
    {

        try
        {
            Value = "X";


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
    private DCharacter CLMHDR_STATUS_NOT_COMPLETE = new DCharacter("CLMHDR_STATUS_NOT_COMPLETE", 1);
    private void CLMHDR_STATUS_NOT_COMPLETE_GetValue(ref string Value)
    {

        try
        {
            Value = "N";


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
    private DCharacter CLMHDR_STATUS_DEFAULT = new DCharacter("CLMHDR_STATUS_DEFAULT", 1);
    private void CLMHDR_STATUS_DEFAULT_GetValue(ref string Value)
    {

        try
        {
            Value = " ";


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
    private DCharacter UPDATED = new DCharacter("UPDATED", 1);
    private void UPDATED_GetValue(ref string Value)
    {

        try
        {
            Value = "U";


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
    private DCharacter CLMHDR_STATUS_IGNOR = new DCharacter("CLMHDR_STATUS_IGNOR", 1);
    private void CLMHDR_STATUS_IGNOR_GetValue(ref string Value)
    {

        try
        {
            Value = "I";


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
    private DCharacter CLMDTL_STATUS_DELETE = new DCharacter("CLMDTL_STATUS_DELETE", 1);
    private void CLMDTL_STATUS_DELETE_GetValue(ref string Value)
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
    private DCharacter CLMDTL_STATUS_NEW = new DCharacter("CLMDTL_STATUS_NEW", 1);
    private void CLMDTL_STATUS_NEW_GetValue(ref string Value)
    {

        try
        {
            Value = "N";


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
    private DCharacter CLMDTL_STATUS_ACTIVE = new DCharacter("CLMDTL_STATUS_ACTIVE", 1);
    private void CLMDTL_STATUS_ACTIVE_GetValue(ref string Value)
    {

        try
        {
            Value = " ";


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
    private DCharacter CLMDTL_STATUS_UPDATED = new DCharacter("CLMDTL_STATUS_UPDATED", 1);
    private void CLMDTL_STATUS_UPDATED_GetValue(ref string Value)
    {

        try
        {
            Value = "U";


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
            if (QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_STATUS")) == QDesign.NULL(CLMHDR_STATUS_COMPLETE.Value) & QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_STATUS")) != QDesign.NULL(CLMDTL_STATUS_DELETE.Value))
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

    private DDecimal W_CONVERT_CLINIC = new DDecimal("W_CONVERT_CLINIC", 2);
    private void W_CONVERT_CLINIC_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_CLINIC_NBR_1_2")) == 85)
            {
                CurrentValue = 22;
            }
            else
            {
                CurrentValue = fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_CLINIC_NBR_1_2");
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
    private CoreDecimal W_COUNT;
    private CoreDecimal CLMHDR_TOT_CLAIM_AR_OMA;
    private CoreDecimal CLMHDR_TOT_CLAIM_AR_OHIP;
    private DCharacter CLMHDR_DOC_NBR = new DCharacter("CLMHDR_DOC_NBR", 3);
    private void CLMHDR_DOC_NBR_GetValue(ref string Value)
    {

        try
        {
            Value = (QDesign.Substring(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_BATCH_NBR"), 3, 3));


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


























    private SqlFileObject fleU706A_SEL_SUSP_HDR;


    #endregion


    #region "Standard Generated Procedures(NEWU706A_U706A_SELECT_COMPLETE_CLAIMS_1)"


    #region "Automatic Item Initialization(NEWU706A_U706A_SELECT_COMPLETE_CLAIMS_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(NEWU706A_U706A_SELECT_COMPLETE_CLAIMS_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:46:33 PM

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
        fleF002_SUSPEND_HDR.Transaction = m_trnTRANS_UPDATE;
        fleF002_SUSPEND_DTL.Transaction = m_trnTRANS_UPDATE;
        fleU706A_SEL_SUSP_HDR.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(NEWU706A_U706A_SELECT_COMPLETE_CLAIMS_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:46:33 PM

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
            fleF002_SUSPEND_HDR.Dispose();
            fleF002_SUSPEND_DTL.Dispose();
            fleU706A_SEL_SUSP_HDR.Dispose();


        }
        catch (CustomApplicationException ex)
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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(NEWU706A_U706A_SELECT_COMPLETE_CLAIMS_1)"


    public void Run()
    {

        try
        {
            Request("U706A_SELECT_COMPLETE_CLAIMS_1");

            while (fleF002_SUSPEND_HDR.QTPForMissing())
            {
                // --> GET F002_SUSPEND_HDR <--

                fleF002_SUSPEND_HDR.GetData();
                // --> End GET F002_SUSPEND_HDR <--

                while (fleF002_SUSPEND_DTL.QTPForMissing("1"))
                {
                    // --> GET F002_SUSPEND_DTL <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_SUSPEND_DTL.ElementOwner("CLMDTL_DOC_OHIP_NBR")).Append(" = ");
                    m_strWhere.Append((fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_DOC_OHIP_NBR")));
                    m_strWhere.Append(" And ").Append(fleF002_SUSPEND_DTL.ElementOwner("CLMDTL_ACCOUNTING_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_ACCOUNTING_NBR")));

                    fleF002_SUSPEND_DTL.GetData(m_strWhere.ToString());
                    // --> End GET F002_SUSPEND_DTL <--


                    if (Transaction())
                    {

                        if (Select_If())
                        {

                            Sort(fleF002_SUSPEND_HDR.GetSortValue("CLMHDR_DOC_NBR"), fleF002_SUSPEND_HDR.GetSortValue("CLMHDR_DOC_OHIP_NBR"), W_CONVERT_CLINIC.Value, fleF002_SUSPEND_HDR.GetSortValue("CLMHDR_DOC_SPEC_CD"), fleF002_SUSPEND_HDR.GetSortValue("CLMHDR_AGENT_CD"), fleF002_SUSPEND_HDR.GetSortValue("CLMHDR_ACCOUNTING_NBR"));


                        }

                    }

                }

            }

            while (Sort(fleF002_SUSPEND_HDR, fleF002_SUSPEND_DTL))
            {
                Count(ref W_COUNT, fleF002_SUSPEND_HDR.At("CLMHDR_DOC_NBR") || fleF002_SUSPEND_HDR.At("CLMHDR_DOC_OHIP_NBR") || At(W_CONVERT_CLINIC) || fleF002_SUSPEND_HDR.At("CLMHDR_DOC_SPEC_CD") || fleF002_SUSPEND_HDR.At("CLMHDR_AGENT_CD") || fleF002_SUSPEND_HDR.At("CLMHDR_ACCOUNTING_NBR"));

                SubTotal(ref CLMHDR_TOT_CLAIM_AR_OMA, fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_FEE_OMA"));
                SubTotal(ref CLMHDR_TOT_CLAIM_AR_OHIP, fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_FEE_OHIP"));


                SubFile(ref m_trnTRANS_UPDATE, ref fleU706A_SEL_SUSP_HDR, fleF002_SUSPEND_HDR.At("CLMHDR_DOC_NBR") || fleF002_SUSPEND_HDR.At("CLMHDR_DOC_OHIP_NBR") || At(W_CONVERT_CLINIC) || fleF002_SUSPEND_HDR.At("CLMHDR_DOC_SPEC_CD") || fleF002_SUSPEND_HDR.At("CLMHDR_AGENT_CD") || fleF002_SUSPEND_HDR.At("CLMHDR_ACCOUNTING_NBR"), SubFileType.Keep, fleF002_SUSPEND_HDR, "CLMHDR_DOC_OHIP_NBR", "CLMHDR_ACCOUNTING_NBR", W_COUNT, "CLMHDR_PAT_KEY_DATA", "CLMHDR_AGENT_CD",
                CLMHDR_TOT_CLAIM_AR_OMA, CLMHDR_TOT_CLAIM_AR_OHIP, W_CONVERT_CLINIC, "CLMHDR_DOC_SPEC_CD", CLMHDR_DOC_NBR);


                Reset(ref W_COUNT, fleF002_SUSPEND_HDR.At("CLMHDR_DOC_NBR") || fleF002_SUSPEND_HDR.At("CLMHDR_DOC_OHIP_NBR") || At(W_CONVERT_CLINIC) || fleF002_SUSPEND_HDR.At("CLMHDR_DOC_SPEC_CD") || fleF002_SUSPEND_HDR.At("CLMHDR_AGENT_CD"));
                Reset(ref CLMHDR_TOT_CLAIM_AR_OMA, fleF002_SUSPEND_HDR.At("CLMHDR_DOC_NBR") || fleF002_SUSPEND_HDR.At("CLMHDR_DOC_OHIP_NBR") || At(W_CONVERT_CLINIC) || fleF002_SUSPEND_HDR.At("CLMHDR_DOC_SPEC_CD") || fleF002_SUSPEND_HDR.At("CLMHDR_AGENT_CD") || fleF002_SUSPEND_HDR.At("CLMHDR_ACCOUNTING_NBR"));
                Reset(ref CLMHDR_TOT_CLAIM_AR_OHIP, fleF002_SUSPEND_HDR.At("CLMHDR_DOC_NBR") || fleF002_SUSPEND_HDR.At("CLMHDR_DOC_OHIP_NBR") || At(W_CONVERT_CLINIC) || fleF002_SUSPEND_HDR.At("CLMHDR_DOC_SPEC_CD") || fleF002_SUSPEND_HDR.At("CLMHDR_AGENT_CD") || fleF002_SUSPEND_HDR.At("CLMHDR_ACCOUNTING_NBR"));

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
            EndRequest("U706A_SELECT_COMPLETE_CLAIMS_1");

        }

    }




    #endregion


}
//U706A_SELECT_COMPLETE_CLAIMS_1



public class NEWU706A_U706A_GEN_CLAIM_NBRS_2 : NEWU706A
{

    public NEWU706A_U706A_GEN_CLAIM_NBRS_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU706A_SEL_SUSP_HDR = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U706A_SEL_SUSP_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleU706A_TEMP = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U706A_TEMP", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        W_CLAIM_NBR.GetValue += W_CLAIM_NBR_GetValue;
        W_BATCH_NBR_COUNT.GetValue += W_BATCH_NBR_COUNT_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(NEWU706A_U706A_GEN_CLAIM_NBRS_2)"

    private SqlFileObject fleU706A_SEL_SUSP_HDR;
    private SqlFileObject fleF020_DOCTOR_MSTR;
    private DDecimal W_CLAIM_NBR = new DDecimal("W_CLAIM_NBR", 6);
    private void W_CLAIM_NBR_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 99)
            {
                CurrentValue = fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT");
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 99 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 198))
            {
                CurrentValue = fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") - 99;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 198 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 297))
            {
                CurrentValue = fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") - 198;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 297 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 396))
            {
                CurrentValue = fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") - 297;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 396 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 495))
            {
                CurrentValue = fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") - 396;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 495 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 594))
            {
                CurrentValue = fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") - 495;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 594 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 693))
            {
                CurrentValue = fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") - 594;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 693 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 792))
            {
                CurrentValue = fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") - 693;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 792 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 891))
            {
                CurrentValue = fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") - 792;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 891 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 990))
            {
                CurrentValue = fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") - 891;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 990 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 1089))
            {
                CurrentValue = fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") - 990;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 1089 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 1188))
            {
                CurrentValue = fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") - 1089;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 1188 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 1287))
            {
                CurrentValue = fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") - 1188;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 1287 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 1386))
            {
                CurrentValue = fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") - 1287;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 1386 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 1485))
            {
                CurrentValue = fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") - 1386;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 1485 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 1584))
            {
                CurrentValue = fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") - 1485;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 1584 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 1683))
            {
                CurrentValue = fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") - 1584;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 1683 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 1782))
            {
                CurrentValue = fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") - 1683;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 1782 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 1881))
            {
                CurrentValue = fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") - 1782;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 1881 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 1980))
            {
                CurrentValue = fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") - 1881;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 1980 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 2079))
            {
                CurrentValue = fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") - 1980;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 2079 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 2178))
            {
                CurrentValue = fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") - 2079;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 2178 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 2277))
            {
                CurrentValue = fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") - 2178;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 2277 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 2376))
            {
                CurrentValue = fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") - 2277;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 2376 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 2475))
            {
                CurrentValue = fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") - 2376;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 2475 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 2574))
            {
                CurrentValue = fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") - 2475;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 2574 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 2673))
            {
                CurrentValue = fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") - 2574;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 2673 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 2772))
            {
                CurrentValue = fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") - 2673;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 2772 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 2871))
            {
                CurrentValue = fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") - 2772;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 2871 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 2970))
            {
                CurrentValue = fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") - 2871;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 2970 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 3069))
            {
                CurrentValue = fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") - 2970;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 3069 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 3168))
            {
                CurrentValue = fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") - 3069;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 3168 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 3267))
            {
                CurrentValue = fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") - 3168;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 3267 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 3366))
            {
                CurrentValue = fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") - 3267;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 3366 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 3465))
            {
                CurrentValue = fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") - 3366;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 3465 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 3564))
            {
                CurrentValue = fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") - 3465;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 3564 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 3663))
            {
                CurrentValue = fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") - 3564;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 3663 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 3762))
            {
                CurrentValue = fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") - 3663;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 3762 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 3861))
            {
                CurrentValue = fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") - 3762;
            }
            else
            {
                CurrentValue = fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") - 3861;
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
    private DDecimal W_BATCH_NBR_COUNT = new DDecimal("W_BATCH_NBR_COUNT", 6);
    private void W_BATCH_NBR_COUNT_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 99)
            {
                CurrentValue = 1;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 99 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 198))
            {
                CurrentValue = 2;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 198 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 297))
            {
                CurrentValue = 3;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 297 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 396))
            {
                CurrentValue = 4;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 396 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 495))
            {
                CurrentValue = 5;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 495 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 594))
            {
                CurrentValue = 6;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 594 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 693))
            {
                CurrentValue = 7;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 693 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 792))
            {
                CurrentValue = 8;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 792 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 891))
            {
                CurrentValue = 9;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 891 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 990))
            {
                CurrentValue = 10;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 990 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 1089))
            {
                CurrentValue = 11;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 1089 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 1188))
            {
                CurrentValue = 12;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 1188 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 1287))
            {
                CurrentValue = 13;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 1287 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 1386))
            {
                CurrentValue = 14;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 1386 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 1485))
            {
                CurrentValue = 15;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 1485 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 1584))
            {
                CurrentValue = 16;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 1584 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 1683))
            {
                CurrentValue = 17;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 1683 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 1782))
            {
                CurrentValue = 18;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 1782 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 1881))
            {
                CurrentValue = 19;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 1881 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 1980))
            {
                CurrentValue = 20;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 1980 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 2079))
            {
                CurrentValue = 21;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 2079 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 2178))
            {
                CurrentValue = 22;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 2178 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 2277))
            {
                CurrentValue = 23;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 2277 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 2376))
            {
                CurrentValue = 24;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 2376 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 2475))
            {
                CurrentValue = 25;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 2475 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 2574))
            {
                CurrentValue = 26;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 2277 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 2376))
            {
                CurrentValue = 27;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 2376 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 2475))
            {
                CurrentValue = 28;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 2475 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 2574))
            {
                CurrentValue = 29;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 2574 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 2673))
            {
                CurrentValue = 30;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 2673 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 2772))
            {
                CurrentValue = 31;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 2772 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 2871))
            {
                CurrentValue = 32;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 2871 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 2970))
            {
                CurrentValue = 33;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 2970 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 3069))
            {
                CurrentValue = 34;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 3069 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 3168))
            {
                CurrentValue = 35;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 3168 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 3267))
            {
                CurrentValue = 36;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 3267 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 3366))
            {
                CurrentValue = 37;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 3366 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 3465))
            {
                CurrentValue = 38;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 3465 & fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT") <= 3564))
            {
                CurrentValue = 39;
            }
            else if ((QDesign.NULL(fleU706A_SEL_SUSP_HDR.GetDecimalValue("W_COUNT")) > 3564))
            {
                CurrentValue = 40;
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


























    private SqlFileObject fleU706A_TEMP;


    #endregion


    #region "Standard Generated Procedures(NEWU706A_U706A_GEN_CLAIM_NBRS_2)"


    #region "Automatic Item Initialization(NEWU706A_U706A_GEN_CLAIM_NBRS_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(NEWU706A_U706A_GEN_CLAIM_NBRS_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:46:33 PM

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
        fleU706A_SEL_SUSP_HDR.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleU706A_TEMP.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(NEWU706A_U706A_GEN_CLAIM_NBRS_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:46:33 PM

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
            fleU706A_SEL_SUSP_HDR.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleU706A_TEMP.Dispose();


        }
        catch (CustomApplicationException ex)
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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(NEWU706A_U706A_GEN_CLAIM_NBRS_2)"


    public void Run()
    {

        try
        {
            Request("U706A_GEN_CLAIM_NBRS_2");

            while (fleU706A_SEL_SUSP_HDR.QTPForMissing())
            {
                // --> GET U706A_SEL_SUSP_HDR <--

                fleU706A_SEL_SUSP_HDR.GetData();
                // --> End GET U706A_SEL_SUSP_HDR <--

                while (fleF020_DOCTOR_MSTR.QTPForMissing("1"))
                {
                    // --> GET F020_DOCTOR_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleU706A_SEL_SUSP_HDR.GetStringValue("CLMHDR_DOC_NBR")));

                    fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F020_DOCTOR_MSTR <--


                    if (Transaction())
                    {

                        Sort(fleU706A_SEL_SUSP_HDR.GetSortValue("CLMHDR_DOC_NBR"), fleU706A_SEL_SUSP_HDR.GetSortValue("CLMHDR_DOC_OHIP_NBR"), fleU706A_SEL_SUSP_HDR.GetSortValue("W_CONVERT_CLINIC"), fleU706A_SEL_SUSP_HDR.GetSortValue("CLMHDR_DOC_SPEC_CD"), fleU706A_SEL_SUSP_HDR.GetSortValue("CLMHDR_AGENT_CD"), fleU706A_SEL_SUSP_HDR.GetSortValue("CLMHDR_ACCOUNTING_NBR"));



                    }

                }

            }


            while (Sort(fleU706A_SEL_SUSP_HDR, fleF020_DOCTOR_MSTR))
            {

                SubFile(ref m_trnTRANS_UPDATE, ref fleU706A_TEMP, SubFileType.Keep, fleU706A_SEL_SUSP_HDR, "CLMHDR_DOC_OHIP_NBR", "CLMHDR_ACCOUNTING_NBR", "CLMHDR_DOC_NBR", "W_CONVERT_CLINIC", "CLMHDR_DOC_SPEC_CD", W_BATCH_NBR_COUNT,
                W_CLAIM_NBR, "CLMHDR_AGENT_CD", "CLMHDR_PAT_KEY_DATA", "CLMHDR_TOT_CLAIM_AR_OMA", "CLMHDR_TOT_CLAIM_AR_OHIP");



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
            EndRequest("U706A_GEN_CLAIM_NBRS_2");

        }

    }




    #endregion


}
//U706A_GEN_CLAIM_NBRS_2



public class NEWU706A_U706A_SORT_BATCH_REC_3 : NEWU706A
{

    public NEWU706A_U706A_SORT_BATCH_REC_3(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU706A_TEMP = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U706A_TEMP", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        T_BATCH_NBR = new CoreDecimal("T_BATCH_NBR", 6, this, 1);
        fleTEMPU706A = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "TEMPU706A", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        SORT_KEY.GetValue += SORT_KEY_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(NEWU706A_U706A_SORT_BATCH_REC_3)"

    private SqlFileObject fleU706A_TEMP;
    private DCharacter SORT_KEY = new DCharacter("SORT_KEY", 13);
    private void SORT_KEY_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.ASCII(fleU706A_TEMP.GetDecimalValue("CLMHDR_DOC_OHIP_NBR"), 6) + QDesign.ASCII(fleU706A_TEMP.GetDecimalValue("W_CONVERT_CLINIC"), 2) + QDesign.ASCII(fleU706A_TEMP.GetDecimalValue("CLMHDR_DOC_SPEC_CD"), 2) + QDesign.ASCII(fleU706A_TEMP.GetDecimalValue("CLMHDR_AGENT_CD"), 1) + QDesign.ASCII(fleU706A_TEMP.GetDecimalValue("W_BATCH_NBR_COUNT"), 2);


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

    private CoreDecimal T_BATCH_NBR;

























    private SqlFileObject fleTEMPU706A;


    #endregion


    #region "Standard Generated Procedures(NEWU706A_U706A_SORT_BATCH_REC_3)"


    #region "Automatic Item Initialization(NEWU706A_U706A_SORT_BATCH_REC_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(NEWU706A_U706A_SORT_BATCH_REC_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:46:33 PM

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
        fleU706A_TEMP.Transaction = m_trnTRANS_UPDATE;
        fleTEMPU706A.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(NEWU706A_U706A_SORT_BATCH_REC_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:46:34 PM

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
            fleU706A_TEMP.Dispose();
            fleTEMPU706A.Dispose();


        }
        catch (CustomApplicationException ex)
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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(NEWU706A_U706A_SORT_BATCH_REC_3)"


    public void Run()
    {

        try
        {
            Request("U706A_SORT_BATCH_REC_3");

            while (fleU706A_TEMP.QTPForMissing())
            {
                // --> GET U706A_TEMP <--

                fleU706A_TEMP.GetData();
                // --> End GET U706A_TEMP <--


                if (Transaction())
                {

                    Sort(fleU706A_TEMP.GetSortValue("CLMHDR_DOC_NBR"), fleU706A_TEMP.GetSortValue("W_CONVERT_CLINIC"), SORT_KEY.Value);

                }

            }

            while (Sort(fleU706A_TEMP))
            {

                SubFile(ref m_trnTRANS_UPDATE, ref fleTEMPU706A, SubFileType.Keep, T_BATCH_NBR, fleU706A_TEMP);

                if (fleU706A_TEMP.At("CLMHDR_DOC_NBR") || fleU706A_TEMP.At("W_CONVERT_CLINIC") || At(SORT_KEY))
                {
                    T_BATCH_NBR.Value = T_BATCH_NBR.Value + 1;
                }

                Reset(ref T_BATCH_NBR, 1, fleU706A_TEMP.At("CLMHDR_DOC_NBR"));

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
            EndRequest("U706A_SORT_BATCH_REC_3");

        }

    }




    #endregion


}
//U706A_SORT_BATCH_REC_3



public class NEWU706A_U706A_GEN_BATCH_NBRS_4 : NEWU706A
{

    public NEWU706A_U706A_GEN_BATCH_NBRS_4(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleTEMPU706A = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "TEMPU706A", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF020C_DOC_CLINIC_NEXT_BATCH_NBR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020C_DOC_CLINIC_NEXT_BATCH_NBR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020L_DOC_LOCATIONS = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020L_DOC_LOCATIONS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        W_NEXT_BATCH = new CoreDecimal("W_NEXT_BATCH", 6, this);
        W_NEXT_BATCH_2 = new CoreDecimal("W_NEXT_BATCH_2", 6, this);
        W_NEXT_BATCH_3 = new CoreDecimal("W_NEXT_BATCH_3", 6, this);
        W_NEXT_BATCH_4 = new CoreDecimal("W_NEXT_BATCH_4", 6, this);
        W_NEXT_BATCH_5 = new CoreDecimal("W_NEXT_BATCH_5", 6, this);
        W_NEXT_BATCH_6 = new CoreDecimal("W_NEXT_BATCH_6", 6, this);
        SEQ_NO = new CoreDecimal("SEQ_NO", 6, this);
        PREV_CLINIC_NBR = new CoreDecimal("PREV_CLINIC_NBR", 6, this);
        fleU706A_SUSP_HDR_COUNT_SRTED = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U706A_SUSP_HDR_COUNT_SRTED", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleSAVEF020 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "SAVEF020", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleSAVEF020_DOC_CLINIC_NEXT_BATCH_NBR = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "SAVEF020_DOC_CLINIC_NEXT_BATCH_NBR", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleSAVEF020_DOC_LOCATIONS = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "SAVEF020_DOC_LOCATIONS", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);



        fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.SetItemFinals += fleF020C_DOC_CLINIC_NEXT_BATCH_NBR_SetItemFinals;
        WS_BATCH_NBR.GetValue += WS_BATCH_NBR_GetValue;
        W_BATCH_NBR.GetValue += W_BATCH_NBR_GetValue;
        D_NEXT_BATCH_1.GetValue += D_NEXT_BATCH_1_GetValue;
        D_NEXT_BATCH_2.GetValue += D_NEXT_BATCH_2_GetValue;
        D_NEXT_BATCH_3.GetValue += D_NEXT_BATCH_3_GetValue;
        D_NEXT_BATCH_4.GetValue += D_NEXT_BATCH_4_GetValue;
        D_NEXT_BATCH_5.GetValue += D_NEXT_BATCH_5_GetValue;
        D_NEXT_BATCH_6.GetValue += D_NEXT_BATCH_6_GetValue;

        W_KEY_CLAIMS_MSTR.GetValue += W_KEY_CLAIMS_MSTR_GetValue;
        W_P_KEY_CLAIMS_MSTR.GetValue += W_P_KEY_CLAIMS_MSTR_GetValue;



    }


    #region "Declarations (Variables, Files and Transactions)(NEWU706A_U706A_GEN_BATCH_NBRS_4)"

    private SqlFileObject fleTEMPU706A;
    private SqlFileObject fleF020_DOCTOR_MSTR;
    private SqlFileObject fleF020C_DOC_CLINIC_NEXT_BATCH_NBR;
    private SqlFileObject fleF020L_DOC_LOCATIONS;

    private void fleF020C_DOC_CLINIC_NEXT_BATCH_NBR_SetItemFinals()
    {

        try
        {


            if (fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetDecimalValue("SEQ_NO") == 1)
            {
                fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.set_SetValue("DOC_NX_AVAIL_BATCH", D_NEXT_BATCH_1.Value);
            }
            else if (fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetDecimalValue("SEQ_NO") == 2)
            {
                fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.set_SetValue("DOC_NX_AVAIL_BATCH", D_NEXT_BATCH_2.Value);
            }
            else if (fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetDecimalValue("SEQ_NO") == 3)
            {
                fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.set_SetValue("DOC_NX_AVAIL_BATCH", D_NEXT_BATCH_3.Value);
            }
            else if (fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetDecimalValue("SEQ_NO") == 4)
            {
                fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.set_SetValue("DOC_NX_AVAIL_BATCH", D_NEXT_BATCH_4.Value);
            }
            else if (fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetDecimalValue("SEQ_NO") == 5)
            {
                fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.set_SetValue("DOC_NX_AVAIL_BATCH", D_NEXT_BATCH_5.Value);
            }
            else if (fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetDecimalValue("SEQ_NO") == 6)
            {
                fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.set_SetValue("DOC_NX_AVAIL_BATCH", D_NEXT_BATCH_6.Value);
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

    private CoreDecimal PREV_CLINIC_NBR;
    private CoreDecimal SEQ_NO;
    private CoreDecimal W_NEXT_BATCH;
    private CoreDecimal W_NEXT_BATCH_2;
    private CoreDecimal W_NEXT_BATCH_3;
    private CoreDecimal W_NEXT_BATCH_4;
    private CoreDecimal W_NEXT_BATCH_5;
    private CoreDecimal W_NEXT_BATCH_6;
    private DDecimal WS_BATCH_NBR = new DDecimal("WS_BATCH_NBR", 6);
    private void WS_BATCH_NBR_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (SEQ_NO.Value == 1)
            {
                CurrentValue = W_NEXT_BATCH.Value;
            }
            else if (SEQ_NO.Value == 2)
            {
                CurrentValue = W_NEXT_BATCH_2.Value;
            }
            else if (SEQ_NO.Value == 3)
            {
                CurrentValue = W_NEXT_BATCH_3.Value;
            }
            else if (SEQ_NO.Value == 4)
            {
                CurrentValue = W_NEXT_BATCH_4.Value;
            }
            else if (SEQ_NO.Value == 5)
            {
                CurrentValue = W_NEXT_BATCH_5.Value;
            }
            else if (SEQ_NO.Value == 6)
            {
                CurrentValue = W_NEXT_BATCH_6.Value;
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
    private DDecimal W_BATCH_NBR = new DDecimal("W_BATCH_NBR", 6);
    private void W_BATCH_NBR_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(WS_BATCH_NBR.Value) == 1000)
            {
                CurrentValue = 1;
            }
            else if (QDesign.NULL(WS_BATCH_NBR.Value) > 1000)
            {
                CurrentValue = (WS_BATCH_NBR.Value - 999);
            }
            else
            {
                CurrentValue = WS_BATCH_NBR.Value;
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
    private DDecimal D_NEXT_BATCH_1 = new DDecimal("D_NEXT_BATCH_1", 6);
    private void D_NEXT_BATCH_1_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(W_NEXT_BATCH.Value) == 1000)
            {
                CurrentValue = 1;
            }
            else if (QDesign.NULL(W_NEXT_BATCH.Value) > 1000)
            {
                CurrentValue = (W_NEXT_BATCH.Value - 999);
            }
            else
            {
                CurrentValue = W_NEXT_BATCH.Value;
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

    private DDecimal D_NEXT_BATCH_2 = new DDecimal("D_NEXT_BATCH_2", 6);
    private void D_NEXT_BATCH_2_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(W_NEXT_BATCH_2.Value) == 1000)
            {
                CurrentValue = 1;
            }
            else if (QDesign.NULL(W_NEXT_BATCH_2.Value) > 1000)
            {
                CurrentValue = (W_NEXT_BATCH_2.Value - 999);
            }
            else
            {
                CurrentValue = W_NEXT_BATCH_2.Value;
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
    private DDecimal D_NEXT_BATCH_3 = new DDecimal("D_NEXT_BATCH_3", 6);
    private void D_NEXT_BATCH_3_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(W_NEXT_BATCH_3.Value) == 1000)
            {
                CurrentValue = 1;
            }
            else if (QDesign.NULL(W_NEXT_BATCH_3.Value) > 1000)
            {
                CurrentValue = (W_NEXT_BATCH_3.Value - 999);
            }
            else
            {
                CurrentValue = W_NEXT_BATCH_3.Value;
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
    private DDecimal D_NEXT_BATCH_4 = new DDecimal("D_NEXT_BATCH_4", 6);
    private void D_NEXT_BATCH_4_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(W_NEXT_BATCH_4.Value) == 1000)
            {
                CurrentValue = 1;
            }
            else if (QDesign.NULL(W_NEXT_BATCH_4.Value) > 1000)
            {
                CurrentValue = (W_NEXT_BATCH_4.Value - 999);
            }
            else
            {
                CurrentValue = W_NEXT_BATCH_4.Value;
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
    private DDecimal D_NEXT_BATCH_5 = new DDecimal("D_NEXT_BATCH_5", 6);
    private void D_NEXT_BATCH_5_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(W_NEXT_BATCH_5.Value) == 1000)
            {
                CurrentValue = 1;
            }
            else if (QDesign.NULL(W_NEXT_BATCH_5.Value) > 1000)
            {
                CurrentValue = (W_NEXT_BATCH_5.Value - 999);
            }
            else
            {
                CurrentValue = W_NEXT_BATCH_5.Value;
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
    private DDecimal D_NEXT_BATCH_6 = new DDecimal("D_NEXT_BATCH_6", 6);
    private void D_NEXT_BATCH_6_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(W_NEXT_BATCH_6.Value) == 1000)
            {
                CurrentValue = 1;
            }
            else if (QDesign.NULL(W_NEXT_BATCH_6.Value) > 1000)
            {
                CurrentValue = (W_NEXT_BATCH_6.Value - 999);
            }
            else
            {
                CurrentValue = W_NEXT_BATCH_6.Value;
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

    private DCharacter W_KEY_CLAIMS_MSTR = new DCharacter("W_KEY_CLAIMS_MSTR", 17);
    private void W_KEY_CLAIMS_MSTR_GetValue(ref string Value)
    {

        try
        {
            Value = "B" + QDesign.ASCII(fleTEMPU706A.GetDecimalValue("W_CONVERT_CLINIC"), 2) + fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR") + QDesign.ASCII(W_BATCH_NBR.Value, 3) + QDesign.ASCII(fleTEMPU706A.GetDecimalValue("W_CLAIM_NBR"), 2) + "000000";

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
    private DCharacter W_P_KEY_CLAIMS_MSTR = new DCharacter("W_P_KEY_CLAIMS_MSTR", 17);
    private void W_P_KEY_CLAIMS_MSTR_GetValue(ref string Value)
    {

        try
        {
            Value = "P" + fleTEMPU706A.GetStringValue("CLMHDR_PAT_KEY_DATA");


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


    private SqlFileObject fleU706A_SUSP_HDR_COUNT_SRTED;



    private SqlFileObject fleSAVEF020;
    private SqlFileObject fleSAVEF020_DOC_CLINIC_NEXT_BATCH_NBR;
    private SqlFileObject fleSAVEF020_DOC_LOCATIONS;


    #endregion


    #region "Standard Generated Procedures(NEWU706A_U706A_GEN_BATCH_NBRS_4)"


    #region "Automatic Item Initialization(NEWU706A_U706A_GEN_BATCH_NBRS_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(NEWU706A_U706A_GEN_BATCH_NBRS_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:46:34 PM

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
        fleTEMPU706A.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.Transaction = m_trnTRANS_UPDATE;
        fleF020L_DOC_LOCATIONS.Transaction = m_trnTRANS_UPDATE;
        fleU706A_SUSP_HDR_COUNT_SRTED.Transaction = m_trnTRANS_UPDATE;
        fleSAVEF020.Transaction = m_trnTRANS_UPDATE;
        fleSAVEF020_DOC_CLINIC_NEXT_BATCH_NBR.Transaction = m_trnTRANS_UPDATE;
        fleSAVEF020_DOC_LOCATIONS.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(NEWU706A_U706A_GEN_BATCH_NBRS_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:46:34 PM

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
            fleTEMPU706A.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.Dispose();
            fleF020L_DOC_LOCATIONS.Dispose();
            fleU706A_SUSP_HDR_COUNT_SRTED.Dispose();
            fleSAVEF020.Dispose();
            fleSAVEF020_DOC_CLINIC_NEXT_BATCH_NBR.Dispose();
            fleSAVEF020_DOC_LOCATIONS.Dispose();


        }
        catch (CustomApplicationException ex)
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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(NEWU706A_U706A_GEN_BATCH_NBRS_4)"


    public void Run()
    {
        try
        {
            Request("U706A_GEN_BATCH_NBRS_4");

            while (fleTEMPU706A.QTPForMissing())
            {
                // --> GET TEMPU706A <--
                fleTEMPU706A.GetData();
                // --> End GET TEMPU706A <--

                while (fleF020_DOCTOR_MSTR.QTPForMissing("1"))
                {
                    // --> GET F020_DOCTOR_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleTEMPU706A.GetStringValue("CLMHDR_DOC_NBR")));

                    fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F020_DOCTOR_MSTR <--

                    if (Transaction())
                    {
                        Sort(fleTEMPU706A.GetSortValue("CLMHDR_DOC_NBR"), fleTEMPU706A.GetSortValue("T_BATCH_NBR"));
                    }
                }
            }

            while (Sort(fleTEMPU706A, fleF020_DOCTOR_MSTR))
            {
                while (fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.QTPForMissing())
                {
                    // --> GET F020C_DOCT_CLINIC_NEXT_BATCH_NBR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.ElementOwner("DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")));

                    fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F020C_DOCT_CLINIC_NEXT_BATCH_NBR <--

                    if (QDesign.NULL(fleTEMPU706A.GetDecimalValue("W_CONVERT_CLINIC")) == QDesign.NULL(fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetDecimalValue("DOC_CLINIC_NBR")) && fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetDecimalValue("SEQ_NO") == 1)
                    {
                        if (QDesign.NULL(PREV_CLINIC_NBR.Value) != QDesign.NULL(fleTEMPU706A.GetDecimalValue("W_CONVERT_CLINIC")) || W_NEXT_BATCH.Value == 0)
                        {
                            W_NEXT_BATCH.Value = fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetDecimalValue("DOC_NX_AVAIL_BATCH") + 1;
                            SEQ_NO.Value = 1;
                            fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.OutPut(OutPutType.Update);
                            PREV_CLINIC_NBR.Value = fleTEMPU706A.GetDecimalValue("W_CONVERT_CLINIC");
                        }
                        else
                        {
                            W_NEXT_BATCH.Value = fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetDecimalValue("DOC_NX_AVAIL_BATCH");
                        }
                    }

                    if (QDesign.NULL(fleTEMPU706A.GetDecimalValue("W_CONVERT_CLINIC")) == QDesign.NULL(fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetDecimalValue("DOC_CLINIC_NBR")) && fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetDecimalValue("SEQ_NO") == 2)
                    {
                        if (QDesign.NULL(PREV_CLINIC_NBR.Value) != QDesign.NULL(fleTEMPU706A.GetDecimalValue("W_CONVERT_CLINIC")) || W_NEXT_BATCH_2.Value == 0)
                        {
                            W_NEXT_BATCH_2.Value = fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetDecimalValue("DOC_NX_AVAIL_BATCH") + 1;
                            SEQ_NO.Value = 2;
                            fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.OutPut(OutPutType.Update);
                            PREV_CLINIC_NBR.Value = fleTEMPU706A.GetDecimalValue("W_CONVERT_CLINIC");
                        }
                        else
                        {
                            W_NEXT_BATCH_2.Value = fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetDecimalValue("DOC_NX_AVAIL_BATCH");
                        }
                    }

                    if (QDesign.NULL(fleTEMPU706A.GetDecimalValue("W_CONVERT_CLINIC")) == QDesign.NULL(fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetDecimalValue("DOC_CLINIC_NBR")) && fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetDecimalValue("SEQ_NO") == 3)
                    {
                        if (QDesign.NULL(PREV_CLINIC_NBR.Value) != QDesign.NULL(fleTEMPU706A.GetDecimalValue("W_CONVERT_CLINIC")) || W_NEXT_BATCH_3.Value == 0)
                        {
                            W_NEXT_BATCH_3.Value = fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetDecimalValue("DOC_NX_AVAIL_BATCH") + 1;
                            SEQ_NO.Value = 3;
                            fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.OutPut(OutPutType.Update);
                            PREV_CLINIC_NBR.Value = fleTEMPU706A.GetDecimalValue("W_CONVERT_CLINIC");
                        }
                        else
                        {
                            W_NEXT_BATCH_3.Value = fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetDecimalValue("DOC_NX_AVAIL_BATCH");
                        }
                    }

                    if (QDesign.NULL(fleTEMPU706A.GetDecimalValue("W_CONVERT_CLINIC")) == QDesign.NULL(fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetDecimalValue("DOC_CLINIC_NBR")) && fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetDecimalValue("SEQ_NO") == 4)
                    {
                        if (QDesign.NULL(PREV_CLINIC_NBR.Value) != QDesign.NULL(fleTEMPU706A.GetDecimalValue("W_CONVERT_CLINIC")) || W_NEXT_BATCH_4.Value == 0)
                        {
                            W_NEXT_BATCH_4.Value = fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetDecimalValue("DOC_NX_AVAIL_BATCH") + 1;
                            SEQ_NO.Value = 4;
                            fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.OutPut(OutPutType.Update);
                            PREV_CLINIC_NBR.Value = fleTEMPU706A.GetDecimalValue("W_CONVERT_CLINIC");
                        }
                        else
                        {
                            W_NEXT_BATCH_4.Value = fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetDecimalValue("DOC_NX_AVAIL_BATCH");
                        }
                    }

                    if (QDesign.NULL(fleTEMPU706A.GetDecimalValue("W_CONVERT_CLINIC")) == QDesign.NULL(fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetDecimalValue("DOC_CLINIC_NBR")) && fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetDecimalValue("SEQ_NO") == 5)
                    {
                        if (QDesign.NULL(PREV_CLINIC_NBR.Value) != QDesign.NULL(fleTEMPU706A.GetDecimalValue("W_CONVERT_CLINIC")) || W_NEXT_BATCH_5.Value == 0)
                        {
                            W_NEXT_BATCH_5.Value = fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetDecimalValue("DOC_NX_AVAIL_BATCH") + 1;
                            SEQ_NO.Value = 5;
                            fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.OutPut(OutPutType.Update);
                            PREV_CLINIC_NBR.Value = fleTEMPU706A.GetDecimalValue("W_CONVERT_CLINIC");
                        }
                        else
                        {
                            W_NEXT_BATCH_5.Value = fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetDecimalValue("DOC_NX_AVAIL_BATCH");
                        }
                    }

                    if (QDesign.NULL(fleTEMPU706A.GetDecimalValue("W_CONVERT_CLINIC")) == QDesign.NULL(fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetDecimalValue("DOC_CLINIC_NBR")) && fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetDecimalValue("SEQ_NO") == 6)
                    {
                        if (QDesign.NULL(PREV_CLINIC_NBR.Value) != QDesign.NULL(fleTEMPU706A.GetDecimalValue("W_CONVERT_CLINIC")) || W_NEXT_BATCH.Value == 0)
                        {
                            W_NEXT_BATCH_6.Value = fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetDecimalValue("DOC_NX_AVAIL_BATCH") + 1;
                            SEQ_NO.Value = 6;
                            fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.OutPut(OutPutType.Update);
                            PREV_CLINIC_NBR.Value = fleTEMPU706A.GetDecimalValue("W_CONVERT_CLINIC");
                        }
                        else
                        {
                            W_NEXT_BATCH_6.Value = fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetDecimalValue("DOC_NX_AVAIL_BATCH");
                        }
                    }

                    SubFile(ref m_trnTRANS_UPDATE, ref fleSAVEF020_DOC_CLINIC_NEXT_BATCH_NBR, fleTEMPU706A.At("CLMHDR_DOC_NBR"), SubFileType.Keep, fleF020C_DOC_CLINIC_NEXT_BATCH_NBR);
                }

                while (fleF020L_DOC_LOCATIONS.QTPForMissing())
                {
                    // --> GET F020C_DOCT_CLINIC_NEXT_BATCH_NBR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(fleF020L_DOC_LOCATIONS.ElementOwner("DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")));

                    fleF020L_DOC_LOCATIONS.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);

                    SubFile(ref m_trnTRANS_UPDATE, ref fleSAVEF020_DOC_LOCATIONS, fleTEMPU706A.At("CLMHDR_DOC_NBR"), SubFileType.Keep, fleF020L_DOC_LOCATIONS);
                }

                SubFile(ref m_trnTRANS_UPDATE, ref fleU706A_SUSP_HDR_COUNT_SRTED, SubFileType.Keep, fleTEMPU706A, "CLMHDR_DOC_OHIP_NBR", "CLMHDR_ACCOUNTING_NBR", W_BATCH_NBR, W_KEY_CLAIMS_MSTR, W_P_KEY_CLAIMS_MSTR, "W_BATCH_NBR_COUNT",
                "W_CLAIM_NBR", "CLMHDR_AGENT_CD", "T_BATCH_NBR", "CLMHDR_TOT_CLAIM_AR_OMA", "CLMHDR_TOT_CLAIM_AR_OHIP", "CLMHDR_DOC_NBR");

                SubFile(ref m_trnTRANS_UPDATE, ref fleSAVEF020, fleTEMPU706A.At("CLMHDR_DOC_NBR"), SubFileType.Keep, fleF020_DOCTOR_MSTR);

                //fleF020_DOCTOR_MSTR.OutPut(OutPutType.Update, fleTEMPU706A.At("CLMHDR_DOC_NBR"), null);

                if (fleTEMPU706A.GetDecimalValue("W_CLAIM_NBR") == 99 || fleTEMPU706A.At("CLMHDR_DOC_NBR") || fleTEMPU706A.At("T_BATCH_NBR"))
                {
                    W_NEXT_BATCH.Value = 0;
                    W_NEXT_BATCH_2.Value = 0;
                    W_NEXT_BATCH_3.Value = 0;
                    W_NEXT_BATCH_4.Value = 0;
                    W_NEXT_BATCH_5.Value = 0;
                    W_NEXT_BATCH_6.Value = 0;
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
            EndRequest("U706A_GEN_BATCH_NBRS_4");

        }

    }




    #endregion


}
//U706A_GEN_BATCH_NBRS_4



public class NEWU706A_U706A_PROCESS_CLAIM_HEADERS_5 : NEWU706A
{

    public NEWU706A_U706A_PROCESS_CLAIM_HEADERS_5(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU706A_SUSP_HDR_COUNT_SRTED = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U706A_SUSP_HDR_COUNT_SRTED", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF002_SUSPEND_HDR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_SUSPEND_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleICONST_MSTR_REC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "ICONST_MSTR_REC", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF071_CLIENT_RMA_CLAIM_NBR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F071_CLIENT_RMA_CLAIM_NBR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_CLAIM_SHADOW = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIM_SHADOW", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF001_BATCH_CONTROL_FILE = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F001_BATCH_CONTROL_FILE", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleU706A_CLAIMS_KEYS = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U706A_CLAIMS_KEYS", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        BATCTRL_BATCH_STATUS_UNBALANCED.GetValue += BATCTRL_BATCH_STATUS_UNBALANCED_GetValue;
        BATCTRL_BATCH_STATUS_BALANCED.GetValue += BATCTRL_BATCH_STATUS_BALANCED_GetValue;
        BATCTRL_BATCH_STATUS_REV_UPDATED.GetValue += BATCTRL_BATCH_STATUS_REV_UPDATED_GetValue;
        BATCTRL_BATCH_STATUS_OHIP_SENT.GetValue += BATCTRL_BATCH_STATUS_OHIP_SENT_GetValue;
        BATCTRL_BATCH_STATUS_MONTHEND_DONE.GetValue += BATCTRL_BATCH_STATUS_MONTHEND_DONE_GetValue;
        W_CLMHDR_CLAIM_ID.GetValue += W_CLMHDR_CLAIM_ID_GetValue;
        W_CLMHDR_BATCH_NBR.GetValue += W_CLMHDR_BATCH_NBR_GetValue;
        W_CLM_SHADOW_CLINIC.GetValue += W_CLM_SHADOW_CLINIC_GetValue;
        W_DATE.GetValue += W_DATE_GetValue;
        W_ICONST_DATE_PERIOD_END.GetValue += W_ICONST_DATE_PERIOD_END_GetValue;
        fleF071_CLIENT_RMA_CLAIM_NBR.SetItemFinals += fleF071_CLIENT_RMA_CLAIM_NBR_SetItemFinals;
        fleF002_CLAIMS_MSTR.SetItemFinals += fleF002_CLAIMS_MSTR_SetItemFinals;
        fleF002_CLAIM_SHADOW.SetItemFinals += fleF002_CLAIM_SHADOW_SetItemFinals;
        fleF001_BATCH_CONTROL_FILE.SetItemFinals += fleF001_BATCH_CONTROL_FILE_SetItemFinals;

    }


    #region "Declarations (Variables, Files and Transactions)(NEWU706A_U706A_PROCESS_CLAIM_HEADERS_5)"

    private SqlFileObject fleU706A_SUSP_HDR_COUNT_SRTED;
    private SqlFileObject fleF002_SUSPEND_HDR;
    private SqlFileObject fleICONST_MSTR_REC;
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

    public override bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(fleU706A_SUSP_HDR_COUNT_SRTED.GetStringValue("CLMHDR_DOC_NBR")) == QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_DOC_NBR")))
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

    private DCharacter W_CLMHDR_CLAIM_ID = new DCharacter("W_CLMHDR_CLAIM_ID", 16);
    private void W_CLMHDR_CLAIM_ID_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.Substring(fleU706A_SUSP_HDR_COUNT_SRTED.GetStringValue("W_KEY_CLAIMS_MSTR"), 2, 16);


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
    private DCharacter W_CLMHDR_BATCH_NBR = new DCharacter("W_CLMHDR_BATCH_NBR", 8);
    private void W_CLMHDR_BATCH_NBR_GetValue(ref string Value)
    {

        try
        {
            Value = (QDesign.Substring(fleU706A_SUSP_HDR_COUNT_SRTED.GetStringValue("W_KEY_CLAIMS_MSTR"), 2, 8));


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
    private DDecimal W_CLM_SHADOW_CLINIC = new DDecimal("W_CLM_SHADOW_CLINIC", 6);
    private void W_CLM_SHADOW_CLINIC_GetValue(ref decimal Value)
    {

        try
        {
            Value = QDesign.NConvert(QDesign.Substring(fleU706A_SUSP_HDR_COUNT_SRTED.GetStringValue("W_KEY_CLAIMS_MSTR"), 2, 2));


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
    private DCharacter W_DATE = new DCharacter("W_DATE", 8);
    private void W_DATE_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8);


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
    private DCharacter W_ICONST_DATE_PERIOD_END = new DCharacter("W_ICONST_DATE_PERIOD_END", 8);
    private void W_ICONST_DATE_PERIOD_END_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.ASCII(Convert.ToInt64(fleICONST_MSTR_REC.GetDecimalValue("ICONST_DATE_PERIOD_END_YY").ToString().PadLeft(4, '0')
                            + fleICONST_MSTR_REC.GetDecimalValue("ICONST_DATE_PERIOD_END_MM").ToString().PadLeft(2, '0')
                            + fleICONST_MSTR_REC.GetDecimalValue("ICONST_DATE_PERIOD_END_DD").ToString().PadLeft(2, '0')), 8);


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
    private SqlFileObject fleF071_CLIENT_RMA_CLAIM_NBR;

    private void fleF071_CLIENT_RMA_CLAIM_NBR_SetItemFinals()
    {

        try
        {
            fleF071_CLIENT_RMA_CLAIM_NBR.set_SetValue("CLAIM_NBR_CLIENT", (QDesign.ASCII(fleU706A_SUSP_HDR_COUNT_SRTED.GetDecimalValue("CLMHDR_DOC_OHIP_NBR"), 6) + fleU706A_SUSP_HDR_COUNT_SRTED.GetStringValue("CLMHDR_ACCOUNTING_NBR")));
            fleF071_CLIENT_RMA_CLAIM_NBR.set_SetValue("CLAIM_NBR_RMA", (QDesign.Substring(fleU706A_SUSP_HDR_COUNT_SRTED.GetStringValue("W_KEY_CLAIMS_MSTR"), 4, 8)));
            fleF071_CLIENT_RMA_CLAIM_NBR.set_SetValue("CLINIC_NBR", QDesign.NConvert(QDesign.Substring(fleU706A_SUSP_HDR_COUNT_SRTED.GetStringValue("W_KEY_CLAIMS_MSTR"), 2, 2)));


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

    private SqlFileObject fleF002_CLAIMS_MSTR;

    private void fleF002_CLAIMS_MSTR_SetItemFinals()
    {

        try
        {
            fleF002_CLAIMS_MSTR.set_SetValue("KEY_CLM_TYPE", QDesign.Substring(fleU706A_SUSP_HDR_COUNT_SRTED.GetStringValue("W_KEY_CLAIMS_MSTR"), 1, 1));
            fleF002_CLAIMS_MSTR.set_SetValue("KEY_CLM_BATCH_NBR", (QDesign.Substring(fleU706A_SUSP_HDR_COUNT_SRTED.GetStringValue("W_KEY_CLAIMS_MSTR"), 2, 8)));
            fleF002_CLAIMS_MSTR.set_SetValue("KEY_CLM_CLAIM_NBR", QDesign.NConvert(QDesign.Substring(fleU706A_SUSP_HDR_COUNT_SRTED.GetStringValue("W_KEY_CLAIMS_MSTR"), 10, 2)));
            fleF002_CLAIMS_MSTR.set_SetValue("KEY_CLM_SERV_CODE", QDesign.Substring(fleU706A_SUSP_HDR_COUNT_SRTED.GetStringValue("W_KEY_CLAIMS_MSTR"), 12, 5));
            fleF002_CLAIMS_MSTR.set_SetValue("KEY_CLM_ADJ_NBR", QDesign.Substring(fleU706A_SUSP_HDR_COUNT_SRTED.GetStringValue("W_KEY_CLAIMS_MSTR"), 17, 1));
            fleF002_CLAIMS_MSTR.set_SetValue("KEY_P_CLM_TYPE", QDesign.Substring(fleU706A_SUSP_HDR_COUNT_SRTED.GetStringValue("W_P_KEY_CLAIMS_MSTR"), 1, 1));
            fleF002_CLAIMS_MSTR.set_SetValue("KEY_P_CLM_DATA", QDesign.Substring(fleU706A_SUSP_HDR_COUNT_SRTED.GetStringValue("W_P_KEY_CLAIMS_MSTR"), 2, 16));
            fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_BATCH_NBR", (W_CLMHDR_CLAIM_ID.Value).PadRight(16).Substring(0, 8));
            //Parent:CLMHDR_CLAIM_ID
            fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_CLAIM_NBR", (W_CLMHDR_CLAIM_ID.Value).PadRight(16).Substring(8, 2));
            //Parent:CLMHDR_CLAIM_ID
            fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_ADJ_OMA_CD", (W_CLMHDR_CLAIM_ID.Value).PadRight(16).Substring(10, 4));
            //Parent:CLMHDR_CLAIM_ID
            fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_ADJ_OMA_SUFF", (W_CLMHDR_CLAIM_ID.Value).PadRight(16).Substring(14, 1));
            //Parent:CLMHDR_CLAIM_ID
            fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_ADJ_ADJ_NBR", (W_CLMHDR_CLAIM_ID.Value).PadRight(16).Substring(15, 1));
            //Parent:CLMHDR_CLAIM_ID
            fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_ORIG_BATCH_NBR", W_CLMHDR_BATCH_NBR.Value);
            fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_ORIG_CLAIM_NBR", fleU706A_SUSP_HDR_COUNT_SRTED.GetDecimalValue("W_CLAIM_NBR"));
            fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_DATE_PERIOD_END", Convert.ToInt64(fleICONST_MSTR_REC.GetDecimalValue("ICONST_DATE_PERIOD_END_YY").ToString().PadLeft(4, '0')
                            + fleICONST_MSTR_REC.GetDecimalValue("ICONST_DATE_PERIOD_END_MM").ToString().PadLeft(2, '0')
                            + fleICONST_MSTR_REC.GetDecimalValue("ICONST_DATE_PERIOD_END_DD").ToString().PadLeft(2, '0')));
            fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_CYCLE_NBR", fleICONST_MSTR_REC.GetDecimalValue("ICONST_CLINIC_CYCLE_NBR"));
            fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_BATCH_TYPE", fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_BATCH_TYPE"));
            fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_ADJ_CD_SUB_TYPE", fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_ADJ_CD_SUB_TYPE"));
            fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_DOC_NBR_OHIP", fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_DOC_NBR_OHIP"));
            fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_DOC_SPEC_CD", fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_DOC_SPEC_CD"));
            fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_REFER_DOC_NBR", fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_REFER_DOC_NBR"));
            fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_DIAG_CD", fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_DIAG_CD"));
            fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_LOC", fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_LOC"));
            fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_HOSP", fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_HOSP"));
            fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_AGENT_CD", fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_AGENT_CD"));
            fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_ADJ_CD", fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_ADJ_CD"));
            fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_TAPE_SUBMIT_IND", fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_TAPE_SUBMIT_IND"));
            fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_I_O_PAT_IND", fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_I_O_PAT_IND"));
            fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_PAT_KEY_TYPE", fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_PAT_KEY_TYPE"));
            fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_PAT_KEY_DATA", fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_PAT_KEY_DATA"));
            fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_PAT_ACRONYM6", fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_PAT_ACRONYM6"));
            fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_PAT_ACRONYM3", fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_PAT_ACRONYM3"));
            fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_REFERENCE", fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_REFERENCE"));
            fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_DATE_ADMIT", fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_DATE_ADMIT"));
            fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_DOC_DEPT", fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_DOC_DEPT"));
            if (QDesign.NULL(fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) != 6)
            {
                fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_MSG_NBR", ("00000000").PadRight(8).Substring(0, 2));
                //Parent:CLMHDR_DATE_CASH_TAPE_PAYMENT
                fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_REPRINT_FLAG", ("00000000").PadRight(8).Substring(2, 1));
                //Parent:CLMHDR_DATE_CASH_TAPE_PAYMENT
                fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_SUB_NBR", ("00000000").PadRight(8).Substring(3, 1));
                //Parent:CLMHDR_DATE_CASH_TAPE_PAYMENT
                fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_AUTO_LOGOUT", ("00000000").PadRight(8).Substring(4, 1));
                //Parent:CLMHDR_DATE_CASH_TAPE_PAYMENT
                fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_FEE_COMPLEX", ("00000000").PadRight(8).Substring(5, 1));
                //Parent:CLMHDR_DATE_CASH_TAPE_PAYMENT
                fleF002_CLAIMS_MSTR.set_SetValue("FILLER", ("00000000").PadRight(8).Substring(6, 1));
                //Parent:CLMHDR_DATE_CASH_TAPE_PAYMENT
            }
            if (QDesign.NULL(fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 6)
            {
                fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_MSG_NBR", fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_MSG_NBR"));
            }
            if (QDesign.NULL(fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 6)
            {
                fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_REPRINT_FLAG", fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_REPRINT_FLAG"));
            }
            if (QDesign.NULL(fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 6)
            {
                fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_SUB_NBR", fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_SUB_NBR"));
            }
            if (QDesign.NULL(fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 6)
            {
                fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_AUTO_LOGOUT", fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_AUTO_LOGOUT"));
            }
            if (QDesign.NULL(fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 6)
            {
                fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_FEE_COMPLEX", fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_FEE_COMPLEX"));
            }
            fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_CURR_PAYMENT", 0);
            fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_DATE_SYS", W_DATE.Value);
            fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_AMT_TECH_BILLED", fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_AMT_TECH_BILLED"));
            fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_AMT_TECH_PAID", 0);
            fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_TOT_CLAIM_AR_OMA", fleU706A_SUSP_HDR_COUNT_SRTED.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OMA"));
            fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_TOT_CLAIM_AR_OHIP", fleU706A_SUSP_HDR_COUNT_SRTED.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP"));
            fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_MANUAL_AND_TAPE_PAYMENTS", 0);
            fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_STATUS_OHIP", fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_STATUS_OHIP"));
            fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_TOT_CLAIM_AR_OMA", fleU706A_SUSP_HDR_COUNT_SRTED.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OMA"));
            fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_CONFIDENTIAL_FLAG", fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_CONFIDENTIAL_FLAG"));


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

    private SqlFileObject fleF002_CLAIM_SHADOW;

    private void fleF002_CLAIM_SHADOW_SetItemFinals()
    {

        try
        {
            fleF002_CLAIM_SHADOW.set_SetValue("CLM_SHADOW_CLINIC", W_CLM_SHADOW_CLINIC.Value);
            fleF002_CLAIM_SHADOW.set_SetValue("CLM_SHADOW_SUBDIVISION", fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_SUB_NBR"));
            fleF002_CLAIM_SHADOW.set_SetValue("CLM_SHADOW_PAT_KEY_TYPE", fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_PAT_KEY_TYPE"));
            //Parent:CLM_SHADOW_PATIENT
            fleF002_CLAIM_SHADOW.set_SetValue("CLM_SHADOW_PAT_KEY_OHIP", (fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_PAT_KEY_TYPE") + fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_PAT_KEY_DATA")).PadRight(16).Substring(1, 8));
            //Parent:CLM_SHADOW_PATIENT
            fleF002_CLAIM_SHADOW.set_SetValue("CLM_SHADOW_FILLER5", (fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_PAT_KEY_TYPE") + fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_PAT_KEY_DATA")).PadRight(16).Substring(9, 7));
            //Parent:CLM_SHADOW_PATIENT
            fleF002_CLAIM_SHADOW.set_SetValue("CLM_SHADOW_BATCH_NBR", W_CLMHDR_BATCH_NBR.Value);
            fleF002_CLAIM_SHADOW.set_SetValue("CLM_SHADOW_CLAIM_NBR", fleU706A_SUSP_HDR_COUNT_SRTED.GetDecimalValue("W_CLAIM_NBR"));


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

    private SqlFileObject fleF001_BATCH_CONTROL_FILE;

    private void fleF001_BATCH_CONTROL_FILE_SetItemFinals()
    {

        try
        {
            fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_BATCH_NBR", W_CLMHDR_BATCH_NBR.Value);
            fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_BATCH_TYPE", "C");
            fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_LAST_CLAIM_NBR", fleU706A_SUSP_HDR_COUNT_SRTED.GetDecimalValue("W_CLAIM_NBR"));
            fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_CLINIC_NBR", fleICONST_MSTR_REC.GetStringValue("ICONST_CLINIC_NBR"));
            fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_DOC_NBR_OHIP", fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_DOC_OHIP_NBR"));
            fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_LOC", fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_LOC"));
            fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_HOSP", QDesign.Substring(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_LOC"), 1, 1));
            fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_AGENT_CD", fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_AGENT_CD"));
            fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_ADJ_CD", fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_ADJ_CD"));
            fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_I_O_PAT_IND", fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_I_O_PAT_IND"));
            fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_DATE_BATCH_ENTERED", W_DATE.Value);
            fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_DATE_PERIOD_END", W_ICONST_DATE_PERIOD_END.Value);
            fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_CYCLE_NBR", fleICONST_MSTR_REC.GetDecimalValue("ICONST_CLINIC_CYCLE_NBR"));
            fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_MANUAL_PAY_TOT", 0);
            fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_BATCH_STATUS", BATCTRL_BATCH_STATUS_BALANCED.Value);
            fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_NBR_CLAIMS_IN_BATCH", fleU706A_SUSP_HDR_COUNT_SRTED.GetDecimalValue("W_CLAIM_NBR"));
            fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_ADJ_CD_SUB_TYPE", fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_ADJ_CD_SUB_TYPE"));


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






    private SqlFileObject fleU706A_CLAIMS_KEYS;


    #endregion


    #region "Standard Generated Procedures(NEWU706A_U706A_PROCESS_CLAIM_HEADERS_5)"


    #region "Automatic Item Initialization(NEWU706A_U706A_PROCESS_CLAIM_HEADERS_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(NEWU706A_U706A_PROCESS_CLAIM_HEADERS_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:46:35 PM

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
        fleU706A_SUSP_HDR_COUNT_SRTED.Transaction = m_trnTRANS_UPDATE;
        fleF002_SUSPEND_HDR.Transaction = m_trnTRANS_UPDATE;
        fleICONST_MSTR_REC.Transaction = m_trnTRANS_UPDATE;
        fleF071_CLIENT_RMA_CLAIM_NBR.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIM_SHADOW.Transaction = m_trnTRANS_UPDATE;
        fleF001_BATCH_CONTROL_FILE.Transaction = m_trnTRANS_UPDATE;
        fleU706A_CLAIMS_KEYS.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(NEWU706A_U706A_PROCESS_CLAIM_HEADERS_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:46:35 PM

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
            fleU706A_SUSP_HDR_COUNT_SRTED.Dispose();
            fleF002_SUSPEND_HDR.Dispose();
            fleICONST_MSTR_REC.Dispose();
            fleF071_CLIENT_RMA_CLAIM_NBR.Dispose();
            fleF002_CLAIMS_MSTR.Dispose();
            fleF002_CLAIM_SHADOW.Dispose();
            fleF001_BATCH_CONTROL_FILE.Dispose();
            fleU706A_CLAIMS_KEYS.Dispose();


        }
        catch (CustomApplicationException ex)
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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(NEWU706A_U706A_PROCESS_CLAIM_HEADERS_5)"


    public void Run()
    {

        try
        {
            Request("U706A_PROCESS_CLAIM_HEADERS_5");

            while (fleU706A_SUSP_HDR_COUNT_SRTED.QTPForMissing())
            {
                // --> GET U706A_SUSP_HDR_COUNT_SRTED <--

                fleU706A_SUSP_HDR_COUNT_SRTED.GetData();
                // --> End GET U706A_SUSP_HDR_COUNT_SRTED <--

                while (fleF002_SUSPEND_HDR.QTPForMissing("1"))
                {
                    // --> GET F002_SUSPEND_HDR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_SUSPEND_HDR.ElementOwner("CLMHDR_DOC_OHIP_NBR")).Append(" = ");
                    m_strWhere.Append((fleU706A_SUSP_HDR_COUNT_SRTED.GetDecimalValue("CLMHDR_DOC_OHIP_NBR")));
                    m_strWhere.Append(" And ").Append(fleF002_SUSPEND_HDR.ElementOwner("CLMHDR_ACCOUNTING_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleU706A_SUSP_HDR_COUNT_SRTED.GetStringValue("CLMHDR_ACCOUNTING_NBR")));

                    fleF002_SUSPEND_HDR.GetData(m_strWhere.ToString());
                    // --> End GET F002_SUSPEND_HDR <--

                    while (fleICONST_MSTR_REC.QTPForMissing("2"))
                    {
                        // --> GET ICONST_MSTR_REC <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleICONST_MSTR_REC.ElementOwner("ICONST_CLINIC_NBR_1_2")).Append(" = ");
                        m_strWhere.Append(((QDesign.NConvert(QDesign.Substring(fleU706A_SUSP_HDR_COUNT_SRTED.GetStringValue("W_KEY_CLAIMS_MSTR"), 2, 2)))));

                        fleICONST_MSTR_REC.GetData(m_strWhere.ToString());
                        // --> End GET ICONST_MSTR_REC <--


                        if (Transaction())
                        {

                            if (Select_If())
                            {

                                Sort(fleU706A_SUSP_HDR_COUNT_SRTED.GetSortValue("CLMHDR_DOC_NBR"), fleU706A_SUSP_HDR_COUNT_SRTED.GetSortValue("CLMHDR_DOC_OHIP_NBR"), fleU706A_SUSP_HDR_COUNT_SRTED.GetSortValue("T_BATCH_NBR"), fleU706A_SUSP_HDR_COUNT_SRTED.GetSortValue("W_BATCH_NBR"), fleU706A_SUSP_HDR_COUNT_SRTED.GetSortValue("W_CLAIM_NBR"));


                            }

                        }

                    }

                }

            }


            while (Sort(fleU706A_SUSP_HDR_COUNT_SRTED, fleF002_SUSPEND_HDR, fleICONST_MSTR_REC))
            {

                fleF071_CLIENT_RMA_CLAIM_NBR.OutPut(OutPutType.Add);

                fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_MANUAL_REVIEW", fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_RELATIONSHIP"));

                fleF002_CLAIMS_MSTR.OutPut(OutPutType.Add);

                fleF002_CLAIM_SHADOW.OutPut(OutPutType.Add, null, QDesign.NULL(fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 4 | QDesign.NULL(fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 6);

                SubTotal(ref fleF001_BATCH_CONTROL_FILE, "BATCTRL_AMT_EST", fleU706A_SUSP_HDR_COUNT_SRTED.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OMA"));


                SubTotal(ref fleF001_BATCH_CONTROL_FILE, "BATCTRL_AMT_ACT", fleU706A_SUSP_HDR_COUNT_SRTED.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OMA"));


                SubTotal(ref fleF001_BATCH_CONTROL_FILE, "BATCTRL_CALC_AR_DUE", fleU706A_SUSP_HDR_COUNT_SRTED.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP"));


                SubTotal(ref fleF001_BATCH_CONTROL_FILE, "BATCTRL_CALC_TOT_REV", fleU706A_SUSP_HDR_COUNT_SRTED.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP"));


                fleF001_BATCH_CONTROL_FILE.OutPut(OutPutType.Add, fleU706A_SUSP_HDR_COUNT_SRTED.At("CLMHDR_DOC_NBR") || fleU706A_SUSP_HDR_COUNT_SRTED.At("CLMHDR_DOC_OHIP_NBR") || fleU706A_SUSP_HDR_COUNT_SRTED.At("T_BATCH_NBR") || fleU706A_SUSP_HDR_COUNT_SRTED.At("W_BATCH_NBR"), null);

                SubFile(ref m_trnTRANS_UPDATE, ref fleU706A_CLAIMS_KEYS, SubFileType.Keep, fleU706A_SUSP_HDR_COUNT_SRTED, "W_KEY_CLAIMS_MSTR", "W_P_KEY_CLAIMS_MSTR");


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
            EndRequest("U706A_PROCESS_CLAIM_HEADERS_5");

        }

    }




    #endregion


}
//U706A_PROCESS_CLAIM_HEADERS_5



public class NEWU706A_U706A_PROCESS_CLAIM_DETAILS_6 : NEWU706A
{

    public NEWU706A_U706A_PROCESS_CLAIM_DETAILS_6(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU706A_SUSP_HDR_COUNT_SRTED = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U706A_SUSP_HDR_COUNT_SRTED", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF002_SUSPEND_DTL = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_SUSPEND_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleICONST_MSTR_REC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "ICONST_MSTR_REC", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        W_CLMDTL_REC_COUNT = new CoreDecimal("W_CLMDTL_REC_COUNT", 6, this);
        X_CLMDTL_SERV_DATE = new CoreDecimal("X_CLMDTL_SERV_DATE", 8, this);
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleUPD_HDR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "UPD_HDR", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF001_BATCH_CONTROL_FILE = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F001_BATCH_CONTROL_FILE", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        CLMDTL_STATUS_DELETE.GetValue += CLMDTL_STATUS_DELETE_GetValue;
        CLMDTL_STATUS_NEW.GetValue += CLMDTL_STATUS_NEW_GetValue;
        CLMDTL_STATUS_ACTIVE.GetValue += CLMDTL_STATUS_ACTIVE_GetValue;
        CLMDTL_STATUS_UPDATED.GetValue += CLMDTL_STATUS_UPDATED_GetValue;
        W_ICONST_DATE_PERIOD_END.GetValue += W_ICONST_DATE_PERIOD_END_GetValue;
        W_KEY_CLAIMS_MSTR_DTL.GetValue += W_KEY_CLAIMS_MSTR_DTL_GetValue;
        W_CLAIM_ID.GetValue += W_CLAIM_ID_GetValue;
        W_CLMHDR_BATCH_NBR.GetValue += W_CLMHDR_BATCH_NBR_GetValue;
        W_NBR_OF_SERVICES.GetValue += W_NBR_OF_SERVICES_GetValue;
        W_CLMDTL_SV_DATE.GetValue += W_CLMDTL_SV_DATE_GetValue;
        fleF002_CLAIMS_MSTR.SetItemFinals += fleF002_CLAIMS_MSTR_SetItemFinals;
        fleUPD_HDR.SetItemFinals += fleUPD_HDR_SetItemFinals;
        fleF002_CLAIMS_MSTR.InitializeItems += fleF002_CLAIMS_MSTR_AutomaticItemInitialization;

    }


    #region "Declarations (Variables, Files and Transactions)(NEWU706A_U706A_PROCESS_CLAIM_DETAILS_6)"

    private SqlFileObject fleU706A_SUSP_HDR_COUNT_SRTED;
    private SqlFileObject fleF002_SUSPEND_DTL;
    private SqlFileObject fleICONST_MSTR_REC;
    private DCharacter CLMDTL_STATUS_DELETE = new DCharacter("CLMDTL_STATUS_DELETE", 1);
    private void CLMDTL_STATUS_DELETE_GetValue(ref string Value)
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
    private DCharacter CLMDTL_STATUS_NEW = new DCharacter("CLMDTL_STATUS_NEW", 1);
    private void CLMDTL_STATUS_NEW_GetValue(ref string Value)
    {

        try
        {
            Value = "N";


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
    private DCharacter CLMDTL_STATUS_ACTIVE = new DCharacter("CLMDTL_STATUS_ACTIVE", 1);
    private void CLMDTL_STATUS_ACTIVE_GetValue(ref string Value)
    {

        try
        {
            Value = " ";


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
    private DCharacter CLMDTL_STATUS_UPDATED = new DCharacter("CLMDTL_STATUS_UPDATED", 1);
    private void CLMDTL_STATUS_UPDATED_GetValue(ref string Value)
    {

        try
        {
            Value = "U";


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
            if (QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_STATUS")) != QDesign.NULL(CLMDTL_STATUS_DELETE.Value))
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

    private DCharacter W_ICONST_DATE_PERIOD_END = new DCharacter("W_ICONST_DATE_PERIOD_END", 8);
    private void W_ICONST_DATE_PERIOD_END_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.ASCII(Convert.ToInt64(fleICONST_MSTR_REC.GetDecimalValue("ICONST_DATE_PERIOD_END_YY").ToString().PadLeft(4, '0')
                            + fleICONST_MSTR_REC.GetDecimalValue("ICONST_DATE_PERIOD_END_MM").ToString().PadLeft(2, '0')
                            + fleICONST_MSTR_REC.GetDecimalValue("ICONST_DATE_PERIOD_END_DD").ToString().PadLeft(2, '0')), 8);


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
    private DCharacter W_KEY_CLAIMS_MSTR_DTL = new DCharacter("W_KEY_CLAIMS_MSTR_DTL", 17);
    private void W_KEY_CLAIMS_MSTR_DTL_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.Substring(fleU706A_SUSP_HDR_COUNT_SRTED.GetStringValue("W_KEY_CLAIMS_MSTR"), 1, 11) + fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_OMA_CD") + fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_OMA_SUFF") + QDesign.ASCII(fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_ADJ_NBR"), 1);


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
    private DCharacter W_CLAIM_ID = new DCharacter("W_CLAIM_ID", 16);
    private void W_CLAIM_ID_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.Substring(W_KEY_CLAIMS_MSTR_DTL.Value, 2, 16);


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
    private CoreDecimal W_CLMDTL_REC_COUNT;
    private DCharacter W_CLMHDR_BATCH_NBR = new DCharacter("W_CLMHDR_BATCH_NBR", 8);
    private void W_CLMHDR_BATCH_NBR_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.Substring(fleU706A_SUSP_HDR_COUNT_SRTED.GetStringValue("W_KEY_CLAIMS_MSTR"), 2, 8);


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
    private DDecimal W_NBR_OF_SERVICES = new DDecimal("W_NBR_OF_SERVICES", 6);
    private void W_NBR_OF_SERVICES_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_NBR_SERV") + fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_CONSEC_DATES_R", 0, 1) + fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_CONSEC_DATES_R", 3, 1) + fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_CONSEC_DATES_R", 5, 1);


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
    private DDecimal W_CLMDTL_SV_DATE = new DDecimal("W_CLMDTL_SV_DATE", 8);
    private void W_CLMDTL_SV_DATE_GetValue(ref decimal Value)
    {

        try
        {
            Value = QDesign.NConvert(QDesign.ASCII(fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_SV_YY"), 4) + QDesign.ASCII(fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_SV_MM"), 2) + QDesign.ASCII(fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_SV_DD"), 2));
            //Parent:CLMDTL_SV_DATE


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
    private CoreDecimal X_CLMDTL_SERV_DATE;
    private SqlFileObject fleF002_CLAIMS_MSTR;

    private void fleF002_CLAIMS_MSTR_SetItemFinals()
    {

        try
        {
            fleF002_CLAIMS_MSTR.set_SetValue("KEY_CLM_TYPE", QDesign.Substring(W_KEY_CLAIMS_MSTR_DTL.Value, 1, 1));
            fleF002_CLAIMS_MSTR.set_SetValue("KEY_CLM_BATCH_NBR", QDesign.Substring(W_KEY_CLAIMS_MSTR_DTL.Value, 2, 8));
            fleF002_CLAIMS_MSTR.set_SetValue("KEY_CLM_CLAIM_NBR", QDesign.NConvert(QDesign.Substring(W_KEY_CLAIMS_MSTR_DTL.Value, 10, 2)));
            fleF002_CLAIMS_MSTR.set_SetValue("KEY_CLM_SERV_CODE", QDesign.Substring(W_KEY_CLAIMS_MSTR_DTL.Value, 12, 5));
            fleF002_CLAIMS_MSTR.set_SetValue("KEY_CLM_ADJ_NBR", QDesign.Substring(W_KEY_CLAIMS_MSTR_DTL.Value, 17, 1));
            fleF002_CLAIMS_MSTR.set_SetValue("KEY_P_CLM_TYPE", "Z");
            fleF002_CLAIMS_MSTR.set_SetValue("KEY_P_CLM_DATA", QDesign.Substring(fleU706A_SUSP_HDR_COUNT_SRTED.GetStringValue("W_P_KEY_CLAIMS_MSTR"), 2, 16));
            fleF002_CLAIMS_MSTR.set_SetValue("CLMDTL_CYCLE_NBR", fleICONST_MSTR_REC.GetDecimalValue("ICONST_CLINIC_CYCLE_NBR"));
            fleF002_CLAIMS_MSTR.set_SetValue("CLMDTL_DATE_PERIOD_END", W_ICONST_DATE_PERIOD_END.Value);
            fleF002_CLAIMS_MSTR.set_SetValue("CLMDTL_FEE_OMA", fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_FEE_OMA"));
            fleF002_CLAIMS_MSTR.set_SetValue("CLMDTL_FEE_OHIP", fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_FEE_OHIP"));
            fleF002_CLAIMS_MSTR.set_SetValue("CLMDTL_BATCH_NBR", (W_CLAIM_ID.Value).PadRight(16).Substring(0, 8));
            //Parent:CLMDTL_ID
            fleF002_CLAIMS_MSTR.set_SetValue("CLMDTL_CLAIM_NBR", (W_CLAIM_ID.Value).PadRight(16).Substring(8, 2));
            //Parent:CLMDTL_ID
            fleF002_CLAIMS_MSTR.set_SetValue("CLMDTL_OMA_CD", (W_CLAIM_ID.Value).PadRight(16).Substring(10, 4));
            //Parent:CLMDTL_ID
            fleF002_CLAIMS_MSTR.set_SetValue("CLMDTL_OMA_SUFF", (W_CLAIM_ID.Value).PadRight(16).Substring(14, 1));
            //Parent:CLMDTL_ID
            fleF002_CLAIMS_MSTR.set_SetValue("CLMDTL_ADJ_NBR", (W_CLAIM_ID.Value).PadRight(16).Substring(15, 1));
            //Parent:CLMDTL_ID

            fleF002_CLAIMS_MSTR.set_SetValue("CLMDTL_LINE_NO", W_CLMDTL_REC_COUNT.Value);


            fleF002_CLAIMS_MSTR.set_SetValue("CLMDTL_ORIG_BATCH_NBR", W_CLMHDR_BATCH_NBR.Value);
            fleF002_CLAIMS_MSTR.set_SetValue("CLMDTL_ORIG_CLAIM_NBR_IN_BATCH", fleU706A_SUSP_HDR_COUNT_SRTED.GetDecimalValue("W_CLAIM_NBR"));
            fleF002_CLAIMS_MSTR.set_SetValue("CLMDTL_AGENT_CD", fleU706A_SUSP_HDR_COUNT_SRTED.GetDecimalValue("CLMHDR_AGENT_CD"));


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

    private SqlFileObject fleUPD_HDR;

    private void fleUPD_HDR_SetItemFinals()
    {

        try
        {
            fleUPD_HDR.set_SetValue("CLMHDR_SERV_DATE", X_CLMDTL_SERV_DATE.Value);


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

    private SqlFileObject fleF001_BATCH_CONTROL_FILE;

    #endregion


    #region "Standard Generated Procedures(NEWU706A_U706A_PROCESS_CLAIM_DETAILS_6)"


    #region "Automatic Item Initialization(NEWU706A_U706A_PROCESS_CLAIM_DETAILS_6)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    private void fleF002_CLAIMS_MSTR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {

            fleF002_CLAIMS_MSTR.set_SetValue("CLMDTL_BATCH_NBR", !Fixed, fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_BATCH_NBR"));
            fleF002_CLAIMS_MSTR.set_SetValue("CLMDTL_CLAIM_NBR", !Fixed, fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_CLAIM_NBR"));
            fleF002_CLAIMS_MSTR.set_SetValue("CLMDTL_OMA_CD", !Fixed, fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_OMA_CD"));
            fleF002_CLAIMS_MSTR.set_SetValue("CLMDTL_OMA_SUFF", !Fixed, fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_OMA_SUFF"));
            fleF002_CLAIMS_MSTR.set_SetValue("CLMDTL_ADJ_NBR", !Fixed, fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_ADJ_NBR"));
            fleF002_CLAIMS_MSTR.set_SetValue("CLMDTL_REV_GROUP_CD", !Fixed, fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_REV_GROUP_CD"));
            fleF002_CLAIMS_MSTR.set_SetValue("CLMDTL_AGENT_CD", !Fixed, fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_AGENT_CD"));
            fleF002_CLAIMS_MSTR.set_SetValue("CLMDTL_ADJ_CD", !Fixed, fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_ADJ_CD"));
            fleF002_CLAIMS_MSTR.set_SetValue("CLMDTL_NBR_SERV", !Fixed, fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_NBR_SERV"));
            fleF002_CLAIMS_MSTR.set_SetValue("CLMDTL_SV_YY", !Fixed, fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_SV_YY"));
            fleF002_CLAIMS_MSTR.set_SetValue("CLMDTL_SV_MM", !Fixed, fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_SV_MM"));
            fleF002_CLAIMS_MSTR.set_SetValue("CLMDTL_SV_DD", !Fixed, fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_SV_DD"));
            fleF002_CLAIMS_MSTR.set_SetValue("CLMDTL_CONSEC_DATES_R", !Fixed, fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_CONSEC_DATES_R"));
            fleF002_CLAIMS_MSTR.set_SetValue("CLMDTL_AMT_TECH_BILLED", !Fixed, fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_AMT_TECH_BILLED"));
            fleF002_CLAIMS_MSTR.set_SetValue("CLMDTL_FEE_OMA", !Fixed, fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_FEE_OMA"));
            fleF002_CLAIMS_MSTR.set_SetValue("CLMDTL_FEE_OHIP", !Fixed, fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_FEE_OHIP"));
            fleF002_CLAIMS_MSTR.set_SetValue("CLMDTL_DATE_PERIOD_END", !Fixed, fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_DATE_PERIOD_END"));
            fleF002_CLAIMS_MSTR.set_SetValue("CLMDTL_CYCLE_NBR", !Fixed, fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_CYCLE_NBR"));
            fleF002_CLAIMS_MSTR.set_SetValue("CLMDTL_DIAG_CD", !Fixed, fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_DIAG_CD"));

        }
        catch (CustomApplicationException ex)
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


    #region "Transaction Management Procedures(NEWU706A_U706A_PROCESS_CLAIM_DETAILS_6)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:46:35 PM

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
        fleU706A_SUSP_HDR_COUNT_SRTED.Transaction = m_trnTRANS_UPDATE;
        fleF002_SUSPEND_DTL.Transaction = m_trnTRANS_UPDATE;
        fleICONST_MSTR_REC.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleUPD_HDR.Transaction = m_trnTRANS_UPDATE;
        fleF001_BATCH_CONTROL_FILE.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(NEWU706A_U706A_PROCESS_CLAIM_DETAILS_6)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:46:35 PM

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
            fleU706A_SUSP_HDR_COUNT_SRTED.Dispose();
            fleF002_SUSPEND_DTL.Dispose();
            fleICONST_MSTR_REC.Dispose();
            fleF002_CLAIMS_MSTR.Dispose();
            fleUPD_HDR.Dispose();
            fleF001_BATCH_CONTROL_FILE.Dispose();


        }
        catch (CustomApplicationException ex)
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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(NEWU706A_U706A_PROCESS_CLAIM_DETAILS_6)"


    public void Run()
    {

        try
        {
            Request("U706A_PROCESS_CLAIM_DETAILS_6");

            while (fleU706A_SUSP_HDR_COUNT_SRTED.QTPForMissing())
            {
                // --> GET U706A_SUSP_HDR_COUNT_SRTED <--

                fleU706A_SUSP_HDR_COUNT_SRTED.GetData();
                // --> End GET U706A_SUSP_HDR_COUNT_SRTED <--


                while (fleF002_SUSPEND_DTL.QTPForMissing("1"))
                {
                    // --> GET F002_SUSPEND_DTL <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_SUSPEND_DTL.ElementOwner("CLMDTL_DOC_OHIP_NBR")).Append(" = ");
                    m_strWhere.Append((fleU706A_SUSP_HDR_COUNT_SRTED.GetDecimalValue("CLMHDR_DOC_OHIP_NBR")));
                    m_strWhere.Append(" And ").Append(fleF002_SUSPEND_DTL.ElementOwner("CLMDTL_ACCOUNTING_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleU706A_SUSP_HDR_COUNT_SRTED.GetStringValue("CLMHDR_ACCOUNTING_NBR")));

                    fleF002_SUSPEND_DTL.GetData(m_strWhere.ToString());
                    // --> End GET F002_SUSPEND_DTL <--

                    while (fleICONST_MSTR_REC.QTPForMissing("2"))
                    {
                        // --> GET ICONST_MSTR_REC <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleICONST_MSTR_REC.ElementOwner("ICONST_CLINIC_NBR_1_2")).Append(" = ");
                        m_strWhere.Append(((QDesign.NConvert(QDesign.Substring(fleU706A_SUSP_HDR_COUNT_SRTED.GetStringValue("W_KEY_CLAIMS_MSTR"), 2, 2)))));

                        fleICONST_MSTR_REC.GetData(m_strWhere.ToString());
                        // --> End GET ICONST_MSTR_REC <--


                        if (Transaction())
                        {

                            if (Select_If())
                            {

                                Sort(fleU706A_SUSP_HDR_COUNT_SRTED.GetSortValue("CLMHDR_DOC_NBR"), fleU706A_SUSP_HDR_COUNT_SRTED.GetSortValue("CLMHDR_DOC_OHIP_NBR"), fleU706A_SUSP_HDR_COUNT_SRTED.GetSortValue("T_BATCH_NBR"), fleU706A_SUSP_HDR_COUNT_SRTED.GetSortValue("W_BATCH_NBR"), fleU706A_SUSP_HDR_COUNT_SRTED.GetSortValue("W_KEY_CLAIMS_MSTR"));

                            }

                        }

                    }

                }

            }

            while (Sort(fleU706A_SUSP_HDR_COUNT_SRTED, fleF002_SUSPEND_DTL, fleICONST_MSTR_REC))
            {
                Count(ref W_CLMDTL_REC_COUNT);
                Minimum(ref X_CLMDTL_SERV_DATE, W_CLMDTL_SV_DATE);


                fleF002_CLAIMS_MSTR.OutPut(OutPutType.Add);



                while (fleUPD_HDR.QTPForMissing())
                {
                    // --> GET UPD_HDR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleUPD_HDR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("B"));
                    m_strWhere.Append(" And ").Append(fleUPD_HDR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((QDesign.Substring(fleU706A_SUSP_HDR_COUNT_SRTED.GetStringValue("W_KEY_CLAIMS_MSTR"), 2, 8))));
                    m_strWhere.Append(" And ").Append(fleUPD_HDR.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ");
                    m_strWhere.Append((QDesign.NConvert(QDesign.Substring(fleU706A_SUSP_HDR_COUNT_SRTED.GetStringValue("W_KEY_CLAIMS_MSTR"), 10, 2))));
                    m_strWhere.Append(" And ").Append(fleUPD_HDR.ElementOwner("KEY_CLM_SERV_CODE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("00000"));
                    m_strWhere.Append(" And ").Append(fleUPD_HDR.ElementOwner("KEY_CLM_ADJ_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("0"));

                    fleUPD_HDR.GetData(m_strWhere.ToString());
                    // --> End GET UPD_HDR <--


                    fleUPD_HDR.OutPut(OutPutType.Update, fleU706A_SUSP_HDR_COUNT_SRTED.At("CLMHDR_DOC_NBR") || fleU706A_SUSP_HDR_COUNT_SRTED.At("CLMHDR_DOC_OHIP_NBR") || fleU706A_SUSP_HDR_COUNT_SRTED.At("T_BATCH_NBR") || fleU706A_SUSP_HDR_COUNT_SRTED.At("W_BATCH_NBR") || fleU706A_SUSP_HDR_COUNT_SRTED.At("W_KEY_CLAIMS_MSTR"), null);



                }


                while (fleF001_BATCH_CONTROL_FILE.QTPForMissing())
                {
                    // --> GET F001_BATCH_CONTROL_FILE <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF001_BATCH_CONTROL_FILE.ElementOwner("BATCTRL_BATCH_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(W_CLMHDR_BATCH_NBR.Value));

                    m_strOrderBy = new StringBuilder(" ORDER BY ");
                    m_strOrderBy.Append(fleF001_BATCH_CONTROL_FILE.ElementOwner("BATCTRL_BATCH_NBR"));

                    fleF001_BATCH_CONTROL_FILE.GetData(m_strWhere.ToString(), m_strOrderBy.ToString());
                    // --> End GET F001_BATCH_CONTROL_FILE <--


                    SubTotal(ref fleF001_BATCH_CONTROL_FILE, "BATCTRL_SVC_EST", W_NBR_OF_SERVICES.Value);

                    SubTotal(ref fleF001_BATCH_CONTROL_FILE, "BATCTRL_SVC_ACT", W_NBR_OF_SERVICES.Value);


                    fleF001_BATCH_CONTROL_FILE.OutPut(OutPutType.Update, fleU706A_SUSP_HDR_COUNT_SRTED.At("CLMHDR_DOC_NBR") || fleU706A_SUSP_HDR_COUNT_SRTED.At("CLMHDR_DOC_OHIP_NBR") || fleU706A_SUSP_HDR_COUNT_SRTED.At("T_BATCH_NBR") || fleU706A_SUSP_HDR_COUNT_SRTED.At("W_BATCH_NBR"), null);


                }


                Reset(ref W_CLMDTL_REC_COUNT, fleU706A_SUSP_HDR_COUNT_SRTED.At("CLMHDR_DOC_NBR") || fleU706A_SUSP_HDR_COUNT_SRTED.At("CLMHDR_DOC_OHIP_NBR") || fleU706A_SUSP_HDR_COUNT_SRTED.At("T_BATCH_NBR") || fleU706A_SUSP_HDR_COUNT_SRTED.At("W_BATCH_NBR") || fleU706A_SUSP_HDR_COUNT_SRTED.At("W_KEY_CLAIMS_MSTR"));
                Reset(ref X_CLMDTL_SERV_DATE, fleU706A_SUSP_HDR_COUNT_SRTED.At("CLMHDR_DOC_NBR") || fleU706A_SUSP_HDR_COUNT_SRTED.At("CLMHDR_DOC_OHIP_NBR") || fleU706A_SUSP_HDR_COUNT_SRTED.At("T_BATCH_NBR") || fleU706A_SUSP_HDR_COUNT_SRTED.At("W_BATCH_NBR") || fleU706A_SUSP_HDR_COUNT_SRTED.At("W_KEY_CLAIMS_MSTR"));

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
            EndRequest("U706A_PROCESS_CLAIM_DETAILS_6");

        }

    }




    #endregion


}
//U706A_PROCESS_CLAIM_DETAILS_6



public class NEWU706A_U706A_PACK_ALL_SUSP_DESC_REC_INTO_1_SUBFILE_REC_7 : NEWU706A
{

    public NEWU706A_U706A_PACK_ALL_SUSP_DESC_REC_INTO_1_SUBFILE_REC_7(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU706A_SUSP_HDR_COUNT_SRTED = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U706A_SUSP_HDR_COUNT_SRTED", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF002_SUSPEND_HDR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_SUSPEND_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_SUSPEND_DESC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_SUSPEND_DESC", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleICONST_MSTR_REC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "ICONST_MSTR_REC", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_TEXT = new CoreCharacter("X_TEXT", 110, this, Common.cEmptyString);
        fleU706A_COMBINED_DESCS = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U706A_COMBINED_DESCS", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        CLMHDR_STATUS_COMPLETE.GetValue += CLMHDR_STATUS_COMPLETE_GetValue;
        CLMHDR_STATUS_DELETE.GetValue += CLMHDR_STATUS_DELETE_GetValue;
        CLMHDR_STATUS_CANCEL.GetValue += CLMHDR_STATUS_CANCEL_GetValue;
        CLMHDR_STATUS_RESUBMIT.GetValue += CLMHDR_STATUS_RESUBMIT_GetValue;
        CLMHDR_STATUS_ERROR.GetValue += CLMHDR_STATUS_ERROR_GetValue;
        CLMHDR_STATUS_NOT_COMPLETE.GetValue += CLMHDR_STATUS_NOT_COMPLETE_GetValue;
        CLMHDR_STATUS_DEFAULT.GetValue += CLMHDR_STATUS_DEFAULT_GetValue;
        UPDATED.GetValue += UPDATED_GetValue;
        CLMHDR_STATUS_IGNOR.GetValue += CLMHDR_STATUS_IGNOR_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(NEWU706A_U706A_PACK_ALL_SUSP_DESC_REC_INTO_1_SUBFILE_REC_7)"

    private SqlFileObject fleU706A_SUSP_HDR_COUNT_SRTED;
    private SqlFileObject fleF002_SUSPEND_HDR;
    private SqlFileObject fleF002_SUSPEND_DESC;
    private SqlFileObject fleICONST_MSTR_REC;
    private DCharacter CLMHDR_STATUS_COMPLETE = new DCharacter("CLMHDR_STATUS_COMPLETE", 1);
    private void CLMHDR_STATUS_COMPLETE_GetValue(ref string Value)
    {

        try
        {
            Value = "C";


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
    private DCharacter CLMHDR_STATUS_DELETE = new DCharacter("CLMHDR_STATUS_DELETE", 1);
    private void CLMHDR_STATUS_DELETE_GetValue(ref string Value)
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
    private DCharacter CLMHDR_STATUS_CANCEL = new DCharacter("CLMHDR_STATUS_CANCEL", 1);
    private void CLMHDR_STATUS_CANCEL_GetValue(ref string Value)
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
    private DCharacter CLMHDR_STATUS_RESUBMIT = new DCharacter("CLMHDR_STATUS_RESUBMIT", 1);
    private void CLMHDR_STATUS_RESUBMIT_GetValue(ref string Value)
    {

        try
        {
            Value = "R";


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
    private DCharacter CLMHDR_STATUS_ERROR = new DCharacter("CLMHDR_STATUS_ERROR", 1);
    private void CLMHDR_STATUS_ERROR_GetValue(ref string Value)
    {

        try
        {
            Value = "X";


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
    private DCharacter CLMHDR_STATUS_NOT_COMPLETE = new DCharacter("CLMHDR_STATUS_NOT_COMPLETE", 1);
    private void CLMHDR_STATUS_NOT_COMPLETE_GetValue(ref string Value)
    {

        try
        {
            Value = "N";


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
    private DCharacter CLMHDR_STATUS_DEFAULT = new DCharacter("CLMHDR_STATUS_DEFAULT", 1);
    private void CLMHDR_STATUS_DEFAULT_GetValue(ref string Value)
    {

        try
        {
            Value = " ";


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
    private DCharacter UPDATED = new DCharacter("UPDATED", 1);
    private void UPDATED_GetValue(ref string Value)
    {

        try
        {
            Value = "U";


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
    private DCharacter CLMHDR_STATUS_IGNOR = new DCharacter("CLMHDR_STATUS_IGNOR", 1);
    private void CLMHDR_STATUS_IGNOR_GetValue(ref string Value)
    {

        try
        {
            Value = "I";


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
            if (QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_STATUS")) != QDesign.NULL(CLMHDR_STATUS_DELETE.Value) & QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_STATUS")) != QDesign.NULL(CLMHDR_STATUS_CANCEL.Value) & QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_STATUS")) != QDesign.NULL(CLMHDR_STATUS_RESUBMIT.Value) & QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_STATUS")) != QDesign.NULL(CLMHDR_STATUS_IGNOR.Value) & QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_RELATIONSHIP")) == "Y")
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


    private CoreCharacter X_TEXT;

























    private SqlFileObject fleU706A_COMBINED_DESCS;


    #endregion


    #region "Standard Generated Procedures(NEWU706A_U706A_PACK_ALL_SUSP_DESC_REC_INTO_1_SUBFILE_REC_7)"


    #region "Automatic Item Initialization(NEWU706A_U706A_PACK_ALL_SUSP_DESC_REC_INTO_1_SUBFILE_REC_7)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(NEWU706A_U706A_PACK_ALL_SUSP_DESC_REC_INTO_1_SUBFILE_REC_7)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:46:35 PM

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
        fleU706A_SUSP_HDR_COUNT_SRTED.Transaction = m_trnTRANS_UPDATE;
        fleF002_SUSPEND_HDR.Transaction = m_trnTRANS_UPDATE;
        fleF002_SUSPEND_DESC.Transaction = m_trnTRANS_UPDATE;
        fleICONST_MSTR_REC.Transaction = m_trnTRANS_UPDATE;
        fleU706A_COMBINED_DESCS.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(NEWU706A_U706A_PACK_ALL_SUSP_DESC_REC_INTO_1_SUBFILE_REC_7)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:46:36 PM

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
            fleU706A_SUSP_HDR_COUNT_SRTED.Dispose();
            fleF002_SUSPEND_HDR.Dispose();
            fleF002_SUSPEND_DESC.Dispose();
            fleICONST_MSTR_REC.Dispose();
            fleU706A_COMBINED_DESCS.Dispose();


        }
        catch (CustomApplicationException ex)
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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(NEWU706A_U706A_PACK_ALL_SUSP_DESC_REC_INTO_1_SUBFILE_REC_7)"


    public void Run()
    {

        try
        {
            Request("U706A_PACK_ALL_SUSP_DESC_REC_INTO_1_SUBFILE_REC_7");

            while (fleU706A_SUSP_HDR_COUNT_SRTED.QTPForMissing())
            {
                // --> GET U706A_SUSP_HDR_COUNT_SRTED <--

                fleU706A_SUSP_HDR_COUNT_SRTED.GetData();
                // --> End GET U706A_SUSP_HDR_COUNT_SRTED <--

                while (fleF002_SUSPEND_HDR.QTPForMissing("1"))
                {
                    // --> GET F002_SUSPEND_HDR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_SUSPEND_HDR.ElementOwner("CLMHDR_DOC_OHIP_NBR")).Append(" = ");
                    m_strWhere.Append((fleU706A_SUSP_HDR_COUNT_SRTED.GetDecimalValue("CLMHDR_DOC_OHIP_NBR")));
                    m_strWhere.Append(" And ").Append(fleF002_SUSPEND_HDR.ElementOwner("CLMHDR_ACCOUNTING_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleU706A_SUSP_HDR_COUNT_SRTED.GetStringValue("CLMHDR_ACCOUNTING_NBR")));

                    fleF002_SUSPEND_HDR.GetData(m_strWhere.ToString());
                    // --> End GET F002_SUSPEND_HDR <--

                    while (fleF002_SUSPEND_DESC.QTPForMissing("2"))
                    {
                        // --> GET F002_SUSPEND_DESC <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF002_SUSPEND_DESC.ElementOwner("CLMDTL_DOC_OHIP_NBR")).Append(" = ");
                        m_strWhere.Append((fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_DOC_OHIP_NBR")));
                        m_strWhere.Append(" And ").Append(fleF002_SUSPEND_DESC.ElementOwner("CLMDTL_ACCOUNTING_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_ACCOUNTING_NBR")));

                        fleF002_SUSPEND_DESC.GetData(m_strWhere.ToString());
                        // --> End GET F002_SUSPEND_DESC <--

                        while (fleICONST_MSTR_REC.QTPForMissing("3"))
                        {
                            // --> GET ICONST_MSTR_REC <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleICONST_MSTR_REC.ElementOwner("ICONST_CLINIC_NBR_1_2")).Append(" = ");
                            m_strWhere.Append(((QDesign.NConvert(QDesign.Substring(fleU706A_SUSP_HDR_COUNT_SRTED.GetStringValue("W_KEY_CLAIMS_MSTR"), 2, 2)))));

                            fleICONST_MSTR_REC.GetData(m_strWhere.ToString());
                            // --> End GET ICONST_MSTR_REC <--


                            if (Transaction())
                            {

                                if (Select_If())
                                {

                                    Sort(fleU706A_SUSP_HDR_COUNT_SRTED.GetSortValue("W_KEY_CLAIMS_MSTR"));


                                }

                            }

                        }

                    }

                }

            }

            while (Sort(fleU706A_SUSP_HDR_COUNT_SRTED, fleF002_SUSPEND_HDR, fleF002_SUSPEND_DESC, fleICONST_MSTR_REC))
            {
                X_TEXT.Value = (QDesign.Pack(X_TEXT.Value)).TrimEnd() + QDesign.RTrim(QDesign.Pack(fleF002_SUSPEND_DESC.GetStringValue("CLMDTL_SUSPEND_DESC")));

                SubFile(ref m_trnTRANS_UPDATE, ref fleU706A_COMBINED_DESCS, fleU706A_SUSP_HDR_COUNT_SRTED.At("W_KEY_CLAIMS_MSTR"), SubFileType.Keep, fleF002_SUSPEND_DESC, "CLMDTL_DOC_OHIP_NBR", "CLMDTL_ACCOUNTING_NBR", fleU706A_SUSP_HDR_COUNT_SRTED, X_TEXT);

                Reset(ref X_TEXT, fleU706A_SUSP_HDR_COUNT_SRTED.At("W_KEY_CLAIMS_MSTR"));

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
            EndRequest("U706A_PACK_ALL_SUSP_DESC_REC_INTO_1_SUBFILE_REC_7");

        }

    }




    #endregion


}
//U706A_PACK_ALL_SUSP_DESC_REC_INTO_1_SUBFILE_REC_7



public class NEWU706A_U706A_SPLIT_INTO_5_TIMES_22_8 : NEWU706A
{

    public NEWU706A_U706A_SPLIT_INTO_5_TIMES_22_8(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU706A_COMBINED_DESCS = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U706A_COMBINED_DESCS", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU706A_SINGLE_DESC1 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U706A_SINGLE_DESCS", "U706A_SINGLE_DESC1", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU706A_SINGLE_DESC2 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U706A_SINGLE_DESCS", "U706A_SINGLE_DESC2", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU706A_SINGLE_DESC3 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U706A_SINGLE_DESCS", "U706A_SINGLE_DESC3", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU706A_SINGLE_DESC4 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U706A_SINGLE_DESCS", "U706A_SINGLE_DESC4", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU706A_SINGLE_DESC5 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U706A_SINGLE_DESCS", "U706A_SINGLE_DESC5", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_DESC_1.GetValue += X_DESC_1_GetValue;
        X_DESC_2.GetValue += X_DESC_2_GetValue;
        X_DESC_3.GetValue += X_DESC_3_GetValue;
        X_DESC_4.GetValue += X_DESC_4_GetValue;
        X_DESC_5.GetValue += X_DESC_5_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(NEWU706A_U706A_SPLIT_INTO_5_TIMES_22_8)"

    private SqlFileObject fleU706A_COMBINED_DESCS;
    private DCharacter X_DESC_1 = new DCharacter("X_DESC_1", 22);
    private void X_DESC_1_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.Substring(fleU706A_COMBINED_DESCS.GetStringValue("X_TEXT"), 1, 22);


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
    private DCharacter X_DESC_2 = new DCharacter("X_DESC_2", 22);
    private void X_DESC_2_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.Substring(fleU706A_COMBINED_DESCS.GetStringValue("X_TEXT"), 23, 44);


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
    private DCharacter X_DESC_3 = new DCharacter("X_DESC_3", 22);
    private void X_DESC_3_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.Substring(fleU706A_COMBINED_DESCS.GetStringValue("X_TEXT"), 45, 66);


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
    private DCharacter X_DESC_4 = new DCharacter("X_DESC_4", 22);
    private void X_DESC_4_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.Substring(fleU706A_COMBINED_DESCS.GetStringValue("X_TEXT"), 67, 88);


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
    private DCharacter X_DESC_5 = new DCharacter("X_DESC_5", 22);
    private void X_DESC_5_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.Substring(fleU706A_COMBINED_DESCS.GetStringValue("X_TEXT"), 89, 110);


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


























    private SqlFileObject fleU706A_SINGLE_DESC1;


























    private SqlFileObject fleU706A_SINGLE_DESC2;


























    private SqlFileObject fleU706A_SINGLE_DESC3;


























    private SqlFileObject fleU706A_SINGLE_DESC4;


























    private SqlFileObject fleU706A_SINGLE_DESC5;


    #endregion


    #region "Standard Generated Procedures(NEWU706A_U706A_SPLIT_INTO_5_TIMES_22_8)"


    #region "Automatic Item Initialization(NEWU706A_U706A_SPLIT_INTO_5_TIMES_22_8)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(NEWU706A_U706A_SPLIT_INTO_5_TIMES_22_8)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:46:36 PM

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
        fleU706A_COMBINED_DESCS.Transaction = m_trnTRANS_UPDATE;
        fleU706A_SINGLE_DESC1.Transaction = m_trnTRANS_UPDATE;
        fleU706A_SINGLE_DESC2.Transaction = m_trnTRANS_UPDATE;
        fleU706A_SINGLE_DESC3.Transaction = m_trnTRANS_UPDATE;
        fleU706A_SINGLE_DESC4.Transaction = m_trnTRANS_UPDATE;
        fleU706A_SINGLE_DESC5.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(NEWU706A_U706A_SPLIT_INTO_5_TIMES_22_8)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:46:36 PM

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
            fleU706A_COMBINED_DESCS.Dispose();
            fleU706A_SINGLE_DESC1.Dispose();
            fleU706A_SINGLE_DESC2.Dispose();
            fleU706A_SINGLE_DESC3.Dispose();
            fleU706A_SINGLE_DESC4.Dispose();
            fleU706A_SINGLE_DESC5.Dispose();


        }
        catch (CustomApplicationException ex)
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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(NEWU706A_U706A_SPLIT_INTO_5_TIMES_22_8)"


    public void Run()
    {

        try
        {
            Request("U706A_SPLIT_INTO_5_TIMES_22_8");

            while (fleU706A_COMBINED_DESCS.QTPForMissing())
            {
                // --> GET U706A_COMBINED_DESCS <--

                fleU706A_COMBINED_DESCS.GetData();
                // --> End GET U706A_COMBINED_DESCS <--


                if (Transaction())
                {

                    SubFile(ref m_trnTRANS_UPDATE, ref fleU706A_SINGLE_DESC1, QDesign.NULL(X_DESC_1.Value) != QDesign.NULL(" "), SubFileType.Keep, X_DESC_1, fleU706A_COMBINED_DESCS);


                    SubFile(ref m_trnTRANS_UPDATE, ref fleU706A_SINGLE_DESC2, QDesign.NULL(X_DESC_2.Value) != QDesign.NULL(" "), SubFileType.Keep, X_DESC_2, fleU706A_COMBINED_DESCS);


                    SubFile(ref m_trnTRANS_UPDATE, ref fleU706A_SINGLE_DESC3, QDesign.NULL(X_DESC_3.Value) != QDesign.NULL(" "), SubFileType.Keep, X_DESC_3, fleU706A_COMBINED_DESCS);


                    SubFile(ref m_trnTRANS_UPDATE, ref fleU706A_SINGLE_DESC4, QDesign.NULL(X_DESC_4.Value) != QDesign.NULL(" "), SubFileType.Keep, X_DESC_4, fleU706A_COMBINED_DESCS);

                    SubFile(ref m_trnTRANS_UPDATE, ref fleU706A_SINGLE_DESC5, QDesign.NULL(X_DESC_5.Value) != QDesign.NULL(" "), SubFileType.Keep, X_DESC_5, fleU706A_COMBINED_DESCS);



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
            EndRequest("U706A_SPLIT_INTO_5_TIMES_22_8");

        }

    }




    #endregion


}
//U706A_SPLIT_INTO_5_TIMES_22_8



public class NEWU706A_U706A_CREATE_F002_CLAIM_DESC_RECS_9 : NEWU706A
{

    public NEWU706A_U706A_CREATE_F002_CLAIM_DESC_RECS_9(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU706A_SINGLE_DESCS = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U706A_SINGLE_DESCS", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleICONST_MSTR_REC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "ICONST_MSTR_REC", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_DESC_REC_NBR = new CoreDecimal("X_DESC_REC_NBR", 1, this);
        X_DESC_REC_NBR_ALPHA = new CoreCharacter("X_DESC_REC_NBR_ALPHA", 1, this, Common.cEmptyString);
        fleF002_DESC_1 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_DESC", "F002_DESC_1", false, false, false, 0, "m_trnTRANS_UPDATE");

        W_CLMHDR_CLAIM_ID.GetValue += W_CLMHDR_CLAIM_ID_GetValue;
        W_CLMHDR_BATCH_NBR.GetValue += W_CLMHDR_BATCH_NBR_GetValue;
        W_CLM_SHADOW_CLINIC.GetValue += W_CLM_SHADOW_CLINIC_GetValue;
        fleF002_DESC_1.SetItemFinals += fleF002_DESC_1_SetItemFinals;
    }


    #region "Declarations (Variables, Files and Transactions)(NEWU706A_U706A_CREATE_F002_CLAIM_DESC_RECS_9)"

    private SqlFileObject fleU706A_SINGLE_DESCS;
    private SqlFileObject fleICONST_MSTR_REC;
    private DCharacter W_CLMHDR_CLAIM_ID = new DCharacter("W_CLMHDR_CLAIM_ID", 16);
    private void W_CLMHDR_CLAIM_ID_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.Substring(fleU706A_SINGLE_DESCS.GetStringValue("W_KEY_CLAIMS_MSTR"), 2, 16);


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
    private DCharacter W_CLMHDR_BATCH_NBR = new DCharacter("W_CLMHDR_BATCH_NBR", 8);
    private void W_CLMHDR_BATCH_NBR_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.Substring(fleU706A_SINGLE_DESCS.GetStringValue("W_KEY_CLAIMS_MSTR"), 2, 8);


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
    private DDecimal W_CLM_SHADOW_CLINIC = new DDecimal("W_CLM_SHADOW_CLINIC", 6);
    private void W_CLM_SHADOW_CLINIC_GetValue(ref decimal Value)
    {

        try
        {
            Value = QDesign.NConvert(QDesign.Substring(fleU706A_SINGLE_DESCS.GetStringValue("W_KEY_CLAIMS_MSTR"), 2, 2));


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
    private CoreDecimal X_DESC_REC_NBR;
    private CoreCharacter X_DESC_REC_NBR_ALPHA;
    private SqlFileObject fleF002_DESC_1;

    private void fleF002_DESC_1_SetItemFinals()
    {

        try
        {
            fleF002_DESC_1.set_SetValue("KEY_CLM_TYPE", QDesign.Substring(fleU706A_SINGLE_DESCS.GetStringValue("W_KEY_CLAIMS_MSTR"), 1, 1));
            fleF002_DESC_1.set_SetValue("KEY_CLM_BATCH_NBR", QDesign.Substring(fleU706A_SINGLE_DESCS.GetStringValue("W_KEY_CLAIMS_MSTR"), 2, 8));
            fleF002_DESC_1.set_SetValue("KEY_CLM_CLAIM_NBR", QDesign.NConvert(QDesign.Substring(fleU706A_SINGLE_DESCS.GetStringValue("W_KEY_CLAIMS_MSTR"), 10, 2)));
            fleF002_DESC_1.set_SetValue("KEY_CLM_SERV_CODE", "ZZZZ" + X_DESC_REC_NBR_ALPHA.Value);
            fleF002_DESC_1.set_SetValue("KEY_CLM_ADJ_NBR", QDesign.Substring(fleU706A_SINGLE_DESCS.GetStringValue("W_KEY_CLAIMS_MSTR"), 17, 1));
            fleF002_DESC_1.set_SetValue("KEY_P_CLM_TYPE", "Z");
            fleF002_DESC_1.set_SetValue("KEY_P_CLM_DATA", QDesign.Substring(fleU706A_SINGLE_DESCS.GetStringValue("W_P_KEY_CLAIMS_MSTR"), 2, 16));
            fleF002_DESC_1.set_SetValue("CLMDTL_DESC", fleU706A_SINGLE_DESCS.GetStringValue("X_DESC_1"));
            fleF002_DESC_1.set_SetValue("CLMDTL_BATCH_NBR", QDesign.Substring(fleU706A_SINGLE_DESCS.GetStringValue("W_KEY_CLAIMS_MSTR"), 2, 8));
            fleF002_DESC_1.set_SetValue("CLMDTL_CLAIM_NBR", QDesign.NConvert(QDesign.Substring(fleU706A_SINGLE_DESCS.GetStringValue("W_KEY_CLAIMS_MSTR"), 10, 2)));
            fleF002_DESC_1.set_SetValue("CLMDTL_OMA_CD", "ZZZZ");
            fleF002_DESC_1.set_SetValue("CLMDTL_OMA_SUFF", X_DESC_REC_NBR_ALPHA.Value);
            fleF002_DESC_1.set_SetValue("CLMDTL_ADJ_NBR", QDesign.Substring(fleU706A_SINGLE_DESCS.GetStringValue("W_KEY_CLAIMS_MSTR"), 17, 1));
            fleF002_DESC_1.set_SetValue("CLMDTL_ORIG_BATCH_NBR", W_CLMHDR_BATCH_NBR.Value);
            fleF002_DESC_1.set_SetValue("CLMDTL_ORIG_CLAIM_NBR_IN_BATCH", fleU706A_SINGLE_DESCS.GetDecimalValue("W_CLAIM_NBR"));


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


    #region "Standard Generated Procedures(NEWU706A_U706A_CREATE_F002_CLAIM_DESC_RECS_9)"


    #region "Automatic Item Initialization(NEWU706A_U706A_CREATE_F002_CLAIM_DESC_RECS_9)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.



    #endregion


    #region "Transaction Management Procedures(NEWU706A_U706A_CREATE_F002_CLAIM_DESC_RECS_9)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:46:37 PM

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
        fleU706A_SINGLE_DESCS.Transaction = m_trnTRANS_UPDATE;
        fleICONST_MSTR_REC.Transaction = m_trnTRANS_UPDATE;
        fleF002_DESC_1.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(NEWU706A_U706A_CREATE_F002_CLAIM_DESC_RECS_9)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:46:37 PM

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
            fleU706A_SINGLE_DESCS.Dispose();
            fleICONST_MSTR_REC.Dispose();
            fleF002_DESC_1.Dispose();


        }
        catch (CustomApplicationException ex)
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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(NEWU706A_U706A_CREATE_F002_CLAIM_DESC_RECS_9)"


    public void Run()
    {

        try
        {
            Request("U706A_CREATE_F002_CLAIM_DESC_RECS_9");

            while (fleU706A_SINGLE_DESCS.QTPForMissing())
            {
                // --> GET U706A_SINGLE_DESCS <--

                fleU706A_SINGLE_DESCS.GetData();
                // --> End GET U706A_SINGLE_DESCS <--

                while (fleICONST_MSTR_REC.QTPForMissing("1"))
                {
                    // --> GET ICONST_MSTR_REC <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleICONST_MSTR_REC.ElementOwner("ICONST_CLINIC_NBR_1_2")).Append(" = ");
                    m_strWhere.Append(((QDesign.NConvert(QDesign.Substring(fleU706A_SINGLE_DESCS.GetStringValue("W_KEY_CLAIMS_MSTR"), 2, 2)))));

                    fleICONST_MSTR_REC.GetData(m_strWhere.ToString());
                    // --> End GET ICONST_MSTR_REC <--


                    if (Transaction())
                    {

                        Sort(fleU706A_SINGLE_DESCS.GetSortValue("W_KEY_CLAIMS_MSTR"));

                    }

                }

            }

            while (Sort(fleU706A_SINGLE_DESCS, fleICONST_MSTR_REC))
            {
                X_DESC_REC_NBR.Value = X_DESC_REC_NBR.Value + 1;
                X_DESC_REC_NBR_ALPHA.Value = QDesign.ASCII(X_DESC_REC_NBR.Value);

                fleF002_DESC_1.OutPut(OutPutType.Add);


                Reset(ref X_DESC_REC_NBR, fleU706A_SINGLE_DESCS.At("W_KEY_CLAIMS_MSTR"));

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
            EndRequest("U706A_CREATE_F002_CLAIM_DESC_RECS_9");

        }

    }




    #endregion


}
//U706A_CREATE_F002_CLAIM_DESC_RECS_9



public class NEWU706A_U706A_DELETE_DETAIL_10 : NEWU706A
{

    public NEWU706A_U706A_DELETE_DETAIL_10(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF002_SUSPEND_HDR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_SUSPEND_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_SUSPEND_DTL = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_SUSPEND_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        CLMHDR_STATUS_COMPLETE.GetValue += CLMHDR_STATUS_COMPLETE_GetValue;
        CLMHDR_STATUS_DELETE.GetValue += CLMHDR_STATUS_DELETE_GetValue;
        CLMHDR_STATUS_CANCEL.GetValue += CLMHDR_STATUS_CANCEL_GetValue;
        CLMHDR_STATUS_RESUBMIT.GetValue += CLMHDR_STATUS_RESUBMIT_GetValue;
        CLMHDR_STATUS_ERROR.GetValue += CLMHDR_STATUS_ERROR_GetValue;
        CLMHDR_STATUS_NOT_COMPLETE.GetValue += CLMHDR_STATUS_NOT_COMPLETE_GetValue;
        CLMHDR_STATUS_DEFAULT.GetValue += CLMHDR_STATUS_DEFAULT_GetValue;
        UPDATED.GetValue += UPDATED_GetValue;
        CLMHDR_STATUS_IGNOR.GetValue += CLMHDR_STATUS_IGNOR_GetValue;
        CLMDTL_STATUS_DELETE.GetValue += CLMDTL_STATUS_DELETE_GetValue;
        CLMDTL_STATUS_NEW.GetValue += CLMDTL_STATUS_NEW_GetValue;
        CLMDTL_STATUS_ACTIVE.GetValue += CLMDTL_STATUS_ACTIVE_GetValue;
        CLMDTL_STATUS_UPDATED.GetValue += CLMDTL_STATUS_UPDATED_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(NEWU706A_U706A_DELETE_DETAIL_10)"

    private SqlFileObject fleF002_SUSPEND_HDR;
    private SqlFileObject fleF002_SUSPEND_DTL;
    private DCharacter CLMHDR_STATUS_COMPLETE = new DCharacter("CLMHDR_STATUS_COMPLETE", 1);
    private void CLMHDR_STATUS_COMPLETE_GetValue(ref string Value)
    {

        try
        {
            Value = "C";


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
    private DCharacter CLMHDR_STATUS_DELETE = new DCharacter("CLMHDR_STATUS_DELETE", 1);
    private void CLMHDR_STATUS_DELETE_GetValue(ref string Value)
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
    private DCharacter CLMHDR_STATUS_CANCEL = new DCharacter("CLMHDR_STATUS_CANCEL", 1);
    private void CLMHDR_STATUS_CANCEL_GetValue(ref string Value)
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
    private DCharacter CLMHDR_STATUS_RESUBMIT = new DCharacter("CLMHDR_STATUS_RESUBMIT", 1);
    private void CLMHDR_STATUS_RESUBMIT_GetValue(ref string Value)
    {

        try
        {
            Value = "R";


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
    private DCharacter CLMHDR_STATUS_ERROR = new DCharacter("CLMHDR_STATUS_ERROR", 1);
    private void CLMHDR_STATUS_ERROR_GetValue(ref string Value)
    {

        try
        {
            Value = "X";


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
    private DCharacter CLMHDR_STATUS_NOT_COMPLETE = new DCharacter("CLMHDR_STATUS_NOT_COMPLETE", 1);
    private void CLMHDR_STATUS_NOT_COMPLETE_GetValue(ref string Value)
    {

        try
        {
            Value = "N";


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
    private DCharacter CLMHDR_STATUS_DEFAULT = new DCharacter("CLMHDR_STATUS_DEFAULT", 1);
    private void CLMHDR_STATUS_DEFAULT_GetValue(ref string Value)
    {

        try
        {
            Value = " ";


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
    private DCharacter UPDATED = new DCharacter("UPDATED", 1);
    private void UPDATED_GetValue(ref string Value)
    {

        try
        {
            Value = "U";


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
    private DCharacter CLMHDR_STATUS_IGNOR = new DCharacter("CLMHDR_STATUS_IGNOR", 1);
    private void CLMHDR_STATUS_IGNOR_GetValue(ref string Value)
    {

        try
        {
            Value = "I";


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
    private DCharacter CLMDTL_STATUS_DELETE = new DCharacter("CLMDTL_STATUS_DELETE", 1);
    private void CLMDTL_STATUS_DELETE_GetValue(ref string Value)
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
    private DCharacter CLMDTL_STATUS_NEW = new DCharacter("CLMDTL_STATUS_NEW", 1);
    private void CLMDTL_STATUS_NEW_GetValue(ref string Value)
    {

        try
        {
            Value = "N";


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
    private DCharacter CLMDTL_STATUS_ACTIVE = new DCharacter("CLMDTL_STATUS_ACTIVE", 1);
    private void CLMDTL_STATUS_ACTIVE_GetValue(ref string Value)
    {

        try
        {
            Value = " ";


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
    private DCharacter CLMDTL_STATUS_UPDATED = new DCharacter("CLMDTL_STATUS_UPDATED", 1);
    private void CLMDTL_STATUS_UPDATED_GetValue(ref string Value)
    {

        try
        {
            Value = "U";


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
            if (QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_STATUS")) == QDesign.NULL(CLMHDR_STATUS_DELETE.Value) | QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_STATUS")) == QDesign.NULL(CLMHDR_STATUS_COMPLETE.Value) | QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_STATUS")) == QDesign.NULL(CLMHDR_STATUS_CANCEL.Value) | QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_STATUS")) == QDesign.NULL(CLMHDR_STATUS_RESUBMIT.Value) | QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_STATUS")) == QDesign.NULL(CLMHDR_STATUS_IGNOR.Value))
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


    #region "Standard Generated Procedures(NEWU706A_U706A_DELETE_DETAIL_10)"


    #region "Automatic Item Initialization(NEWU706A_U706A_DELETE_DETAIL_10)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(NEWU706A_U706A_DELETE_DETAIL_10)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:46:37 PM

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
        fleF002_SUSPEND_HDR.Transaction = m_trnTRANS_UPDATE;
        fleF002_SUSPEND_DTL.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(NEWU706A_U706A_DELETE_DETAIL_10)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:46:37 PM

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
            fleF002_SUSPEND_HDR.Dispose();
            fleF002_SUSPEND_DTL.Dispose();


        }
        catch (CustomApplicationException ex)
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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(NEWU706A_U706A_DELETE_DETAIL_10)"


    public void Run()
    {

        try
        {
            Request("U706A_DELETE_DETAIL_10");

            while (fleF002_SUSPEND_HDR.QTPForMissing())
            {
                // --> GET F002_SUSPEND_HDR <--

                fleF002_SUSPEND_HDR.GetData();
                // --> End GET F002_SUSPEND_HDR <--

                while (fleF002_SUSPEND_DTL.QTPForMissing("1"))
                {
                    // --> GET F002_SUSPEND_DTL <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_SUSPEND_DTL.ElementOwner("CLMDTL_DOC_OHIP_NBR")).Append(" = ");
                    m_strWhere.Append((fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_DOC_OHIP_NBR")));
                    m_strWhere.Append(" And ").Append(fleF002_SUSPEND_DTL.ElementOwner("CLMDTL_ACCOUNTING_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_ACCOUNTING_NBR")));

                    fleF002_SUSPEND_DTL.GetData(m_strWhere.ToString());
                    // --> End GET F002_SUSPEND_DTL <--


                    if (Transaction())
                    {

                        if (Select_If())
                        {

                            fleF002_SUSPEND_DTL.OutPut(OutPutType.Delete);


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
            EndRequest("U706A_DELETE_DETAIL_10");

        }

    }




    #endregion


}
//U706A_DELETE_DETAIL_10



public class NEWU706A_U706A_DELETE_ADDRESS_11 : NEWU706A
{

    public NEWU706A_U706A_DELETE_ADDRESS_11(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF002_SUSPEND_HDR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_SUSPEND_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_SUSPEND_ADDRESS = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_SUSPEND_ADDRESS", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        CLMHDR_STATUS_COMPLETE.GetValue += CLMHDR_STATUS_COMPLETE_GetValue;
        CLMHDR_STATUS_DELETE.GetValue += CLMHDR_STATUS_DELETE_GetValue;
        CLMHDR_STATUS_CANCEL.GetValue += CLMHDR_STATUS_CANCEL_GetValue;
        CLMHDR_STATUS_RESUBMIT.GetValue += CLMHDR_STATUS_RESUBMIT_GetValue;
        CLMHDR_STATUS_ERROR.GetValue += CLMHDR_STATUS_ERROR_GetValue;
        CLMHDR_STATUS_NOT_COMPLETE.GetValue += CLMHDR_STATUS_NOT_COMPLETE_GetValue;
        CLMHDR_STATUS_DEFAULT.GetValue += CLMHDR_STATUS_DEFAULT_GetValue;
        UPDATED.GetValue += UPDATED_GetValue;
        CLMHDR_STATUS_IGNOR.GetValue += CLMHDR_STATUS_IGNOR_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(NEWU706A_U706A_DELETE_ADDRESS_11)"

    private SqlFileObject fleF002_SUSPEND_HDR;
    private SqlFileObject fleF002_SUSPEND_ADDRESS;
    private DCharacter CLMHDR_STATUS_COMPLETE = new DCharacter("CLMHDR_STATUS_COMPLETE", 1);
    private void CLMHDR_STATUS_COMPLETE_GetValue(ref string Value)
    {

        try
        {
            Value = "C";


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
    private DCharacter CLMHDR_STATUS_DELETE = new DCharacter("CLMHDR_STATUS_DELETE", 1);
    private void CLMHDR_STATUS_DELETE_GetValue(ref string Value)
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
    private DCharacter CLMHDR_STATUS_CANCEL = new DCharacter("CLMHDR_STATUS_CANCEL", 1);
    private void CLMHDR_STATUS_CANCEL_GetValue(ref string Value)
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
    private DCharacter CLMHDR_STATUS_RESUBMIT = new DCharacter("CLMHDR_STATUS_RESUBMIT", 1);
    private void CLMHDR_STATUS_RESUBMIT_GetValue(ref string Value)
    {

        try
        {
            Value = "R";


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
    private DCharacter CLMHDR_STATUS_ERROR = new DCharacter("CLMHDR_STATUS_ERROR", 1);
    private void CLMHDR_STATUS_ERROR_GetValue(ref string Value)
    {

        try
        {
            Value = "X";


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
    private DCharacter CLMHDR_STATUS_NOT_COMPLETE = new DCharacter("CLMHDR_STATUS_NOT_COMPLETE", 1);
    private void CLMHDR_STATUS_NOT_COMPLETE_GetValue(ref string Value)
    {

        try
        {
            Value = "N";


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
    private DCharacter CLMHDR_STATUS_DEFAULT = new DCharacter("CLMHDR_STATUS_DEFAULT", 1);
    private void CLMHDR_STATUS_DEFAULT_GetValue(ref string Value)
    {

        try
        {
            Value = " ";


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
    private DCharacter UPDATED = new DCharacter("UPDATED", 1);
    private void UPDATED_GetValue(ref string Value)
    {

        try
        {
            Value = "U";


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
    private DCharacter CLMHDR_STATUS_IGNOR = new DCharacter("CLMHDR_STATUS_IGNOR", 1);
    private void CLMHDR_STATUS_IGNOR_GetValue(ref string Value)
    {

        try
        {
            Value = "I";


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
            if (QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_STATUS")) == QDesign.NULL(CLMHDR_STATUS_DELETE.Value) | QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_STATUS")) == QDesign.NULL(CLMHDR_STATUS_COMPLETE.Value) | QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_STATUS")) == QDesign.NULL(CLMHDR_STATUS_CANCEL.Value) | QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_STATUS")) == QDesign.NULL(CLMHDR_STATUS_RESUBMIT.Value) | QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_STATUS")) == QDesign.NULL(CLMHDR_STATUS_IGNOR.Value) | QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_STATUS")) == QDesign.NULL(CLMHDR_STATUS_NOT_COMPLETE.Value))
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


    #region "Standard Generated Procedures(NEWU706A_U706A_DELETE_ADDRESS_11)"


    #region "Automatic Item Initialization(NEWU706A_U706A_DELETE_ADDRESS_11)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(NEWU706A_U706A_DELETE_ADDRESS_11)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:46:38 PM

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
        fleF002_SUSPEND_HDR.Transaction = m_trnTRANS_UPDATE;
        fleF002_SUSPEND_ADDRESS.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(NEWU706A_U706A_DELETE_ADDRESS_11)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:46:38 PM

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
            fleF002_SUSPEND_HDR.Dispose();
            fleF002_SUSPEND_ADDRESS.Dispose();


        }
        catch (CustomApplicationException ex)
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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(NEWU706A_U706A_DELETE_ADDRESS_11)"


    public void Run()
    {

        try
        {
            Request("U706A_DELETE_ADDRESS_11");

            while (fleF002_SUSPEND_HDR.QTPForMissing())
            {
                // --> GET F002_SUSPEND_HDR <--

                fleF002_SUSPEND_HDR.GetData();
                // --> End GET F002_SUSPEND_HDR <--

                while (fleF002_SUSPEND_ADDRESS.QTPForMissing("1"))
                {
                    // --> GET F002_SUSPEND_ADDRESS <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_SUSPEND_ADDRESS.ElementOwner("ADD_DOC_OHIP_NBR")).Append(" = ");
                    m_strWhere.Append((fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_DOC_OHIP_NBR")));
                    m_strWhere.Append(" And ").Append(fleF002_SUSPEND_ADDRESS.ElementOwner("ADD_ACCOUNTING_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_ACCOUNTING_NBR")));

                    fleF002_SUSPEND_ADDRESS.GetData(m_strWhere.ToString());
                    // --> End GET F002_SUSPEND_ADDRESS <--


                    if (Transaction())
                    {

                        if (Select_If())
                        {

                            fleF002_SUSPEND_ADDRESS.OutPut(OutPutType.Delete);


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
            EndRequest("U706A_DELETE_ADDRESS_11");

        }

    }




    #endregion


}
//U706A_DELETE_ADDRESS_11



public class NEWU706A_U706A_DELETE_DESC_12 : NEWU706A
{

    public NEWU706A_U706A_DELETE_DESC_12(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF002_SUSPEND_HDR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_SUSPEND_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_SUSPEND_DESC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_SUSPEND_DESC", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        CLMHDR_STATUS_COMPLETE.GetValue += CLMHDR_STATUS_COMPLETE_GetValue;
        CLMHDR_STATUS_DELETE.GetValue += CLMHDR_STATUS_DELETE_GetValue;
        CLMHDR_STATUS_CANCEL.GetValue += CLMHDR_STATUS_CANCEL_GetValue;
        CLMHDR_STATUS_RESUBMIT.GetValue += CLMHDR_STATUS_RESUBMIT_GetValue;
        CLMHDR_STATUS_ERROR.GetValue += CLMHDR_STATUS_ERROR_GetValue;
        CLMHDR_STATUS_NOT_COMPLETE.GetValue += CLMHDR_STATUS_NOT_COMPLETE_GetValue;
        CLMHDR_STATUS_DEFAULT.GetValue += CLMHDR_STATUS_DEFAULT_GetValue;
        UPDATED.GetValue += UPDATED_GetValue;
        CLMHDR_STATUS_IGNOR.GetValue += CLMHDR_STATUS_IGNOR_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(NEWU706A_U706A_DELETE_DESC_12)"

    private SqlFileObject fleF002_SUSPEND_HDR;
    private SqlFileObject fleF002_SUSPEND_DESC;
    private DCharacter CLMHDR_STATUS_COMPLETE = new DCharacter("CLMHDR_STATUS_COMPLETE", 1);
    private void CLMHDR_STATUS_COMPLETE_GetValue(ref string Value)
    {

        try
        {
            Value = "C";


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
    private DCharacter CLMHDR_STATUS_DELETE = new DCharacter("CLMHDR_STATUS_DELETE", 1);
    private void CLMHDR_STATUS_DELETE_GetValue(ref string Value)
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
    private DCharacter CLMHDR_STATUS_CANCEL = new DCharacter("CLMHDR_STATUS_CANCEL", 1);
    private void CLMHDR_STATUS_CANCEL_GetValue(ref string Value)
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
    private DCharacter CLMHDR_STATUS_RESUBMIT = new DCharacter("CLMHDR_STATUS_RESUBMIT", 1);
    private void CLMHDR_STATUS_RESUBMIT_GetValue(ref string Value)
    {

        try
        {
            Value = "R";


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
    private DCharacter CLMHDR_STATUS_ERROR = new DCharacter("CLMHDR_STATUS_ERROR", 1);
    private void CLMHDR_STATUS_ERROR_GetValue(ref string Value)
    {

        try
        {
            Value = "X";


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
    private DCharacter CLMHDR_STATUS_NOT_COMPLETE = new DCharacter("CLMHDR_STATUS_NOT_COMPLETE", 1);
    private void CLMHDR_STATUS_NOT_COMPLETE_GetValue(ref string Value)
    {

        try
        {
            Value = "N";


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
    private DCharacter CLMHDR_STATUS_DEFAULT = new DCharacter("CLMHDR_STATUS_DEFAULT", 1);
    private void CLMHDR_STATUS_DEFAULT_GetValue(ref string Value)
    {

        try
        {
            Value = " ";


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
    private DCharacter UPDATED = new DCharacter("UPDATED", 1);
    private void UPDATED_GetValue(ref string Value)
    {

        try
        {
            Value = "U";


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
    private DCharacter CLMHDR_STATUS_IGNOR = new DCharacter("CLMHDR_STATUS_IGNOR", 1);
    private void CLMHDR_STATUS_IGNOR_GetValue(ref string Value)
    {

        try
        {
            Value = "I";


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
            if (QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_STATUS")) == QDesign.NULL(CLMHDR_STATUS_DELETE.Value) | QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_STATUS")) == QDesign.NULL(CLMHDR_STATUS_COMPLETE.Value) | QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_STATUS")) == QDesign.NULL(CLMHDR_STATUS_CANCEL.Value) | QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_STATUS")) == QDesign.NULL(CLMHDR_STATUS_RESUBMIT.Value) | QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_STATUS")) == QDesign.NULL(CLMHDR_STATUS_IGNOR.Value))
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


    #region "Standard Generated Procedures(NEWU706A_U706A_DELETE_DESC_12)"


    #region "Automatic Item Initialization(NEWU706A_U706A_DELETE_DESC_12)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(NEWU706A_U706A_DELETE_DESC_12)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:46:38 PM

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
        fleF002_SUSPEND_HDR.Transaction = m_trnTRANS_UPDATE;
        fleF002_SUSPEND_DESC.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(NEWU706A_U706A_DELETE_DESC_12)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:46:38 PM

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
            fleF002_SUSPEND_HDR.Dispose();
            fleF002_SUSPEND_DESC.Dispose();


        }
        catch (CustomApplicationException ex)
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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(NEWU706A_U706A_DELETE_DESC_12)"


    public void Run()
    {

        try
        {
            Request("U706A_DELETE_DESC_12");

            while (fleF002_SUSPEND_HDR.QTPForMissing())
            {
                // --> GET F002_SUSPEND_HDR <--

                fleF002_SUSPEND_HDR.GetData();
                // --> End GET F002_SUSPEND_HDR <--

                while (fleF002_SUSPEND_DESC.QTPForMissing("1"))
                {
                    // --> GET F002_SUSPEND_DESC <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_SUSPEND_DESC.ElementOwner("CLMDTL_DOC_OHIP_NBR")).Append(" = ");
                    m_strWhere.Append((fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_DOC_OHIP_NBR")));
                    m_strWhere.Append(" And ").Append(fleF002_SUSPEND_DESC.ElementOwner("CLMDTL_ACCOUNTING_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_ACCOUNTING_NBR")));

                    fleF002_SUSPEND_DESC.GetData(m_strWhere.ToString());
                    // --> End GET F002_SUSPEND_DESC <--


                    if (Transaction())
                    {

                        if (Select_If())
                        {


                            fleF002_SUSPEND_DESC.OutPut(OutPutType.Delete);


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
            EndRequest("U706A_DELETE_DESC_12");

        }

    }




    #endregion


}
//U706A_DELETE_DESC_12



public class NEWU706A_U706A_DELETE_HEADER_13 : NEWU706A
{

    public NEWU706A_U706A_DELETE_HEADER_13(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF002_SUSPEND_HDR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_SUSPEND_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        CLMHDR_STATUS_COMPLETE.GetValue += CLMHDR_STATUS_COMPLETE_GetValue;
        CLMHDR_STATUS_DELETE.GetValue += CLMHDR_STATUS_DELETE_GetValue;
        CLMHDR_STATUS_CANCEL.GetValue += CLMHDR_STATUS_CANCEL_GetValue;
        CLMHDR_STATUS_RESUBMIT.GetValue += CLMHDR_STATUS_RESUBMIT_GetValue;
        CLMHDR_STATUS_ERROR.GetValue += CLMHDR_STATUS_ERROR_GetValue;
        CLMHDR_STATUS_NOT_COMPLETE.GetValue += CLMHDR_STATUS_NOT_COMPLETE_GetValue;
        CLMHDR_STATUS_DEFAULT.GetValue += CLMHDR_STATUS_DEFAULT_GetValue;
        UPDATED.GetValue += UPDATED_GetValue;
        CLMHDR_STATUS_IGNOR.GetValue += CLMHDR_STATUS_IGNOR_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(NEWU706A_U706A_DELETE_HEADER_13)"

    private SqlFileObject fleF002_SUSPEND_HDR;
    private DCharacter CLMHDR_STATUS_COMPLETE = new DCharacter("CLMHDR_STATUS_COMPLETE", 1);
    private void CLMHDR_STATUS_COMPLETE_GetValue(ref string Value)
    {

        try
        {
            Value = "C";


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
    private DCharacter CLMHDR_STATUS_DELETE = new DCharacter("CLMHDR_STATUS_DELETE", 1);
    private void CLMHDR_STATUS_DELETE_GetValue(ref string Value)
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
    private DCharacter CLMHDR_STATUS_CANCEL = new DCharacter("CLMHDR_STATUS_CANCEL", 1);
    private void CLMHDR_STATUS_CANCEL_GetValue(ref string Value)
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
    private DCharacter CLMHDR_STATUS_RESUBMIT = new DCharacter("CLMHDR_STATUS_RESUBMIT", 1);
    private void CLMHDR_STATUS_RESUBMIT_GetValue(ref string Value)
    {

        try
        {
            Value = "R";


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
    private DCharacter CLMHDR_STATUS_ERROR = new DCharacter("CLMHDR_STATUS_ERROR", 1);
    private void CLMHDR_STATUS_ERROR_GetValue(ref string Value)
    {

        try
        {
            Value = "X";


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
    private DCharacter CLMHDR_STATUS_NOT_COMPLETE = new DCharacter("CLMHDR_STATUS_NOT_COMPLETE", 1);
    private void CLMHDR_STATUS_NOT_COMPLETE_GetValue(ref string Value)
    {

        try
        {
            Value = "N";


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
    private DCharacter CLMHDR_STATUS_DEFAULT = new DCharacter("CLMHDR_STATUS_DEFAULT", 1);
    private void CLMHDR_STATUS_DEFAULT_GetValue(ref string Value)
    {

        try
        {
            Value = " ";


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
    private DCharacter UPDATED = new DCharacter("UPDATED", 1);
    private void UPDATED_GetValue(ref string Value)
    {

        try
        {
            Value = "U";


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
    private DCharacter CLMHDR_STATUS_IGNOR = new DCharacter("CLMHDR_STATUS_IGNOR", 1);
    private void CLMHDR_STATUS_IGNOR_GetValue(ref string Value)
    {

        try
        {
            Value = "I";


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
            if (QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_STATUS")) == QDesign.NULL(CLMHDR_STATUS_DELETE.Value) | QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_STATUS")) == QDesign.NULL(CLMHDR_STATUS_COMPLETE.Value) | QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_STATUS")) == QDesign.NULL(CLMHDR_STATUS_CANCEL.Value) | QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_STATUS")) == QDesign.NULL(CLMHDR_STATUS_RESUBMIT.Value) | QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_STATUS")) == QDesign.NULL(CLMHDR_STATUS_IGNOR.Value))
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


    #region "Standard Generated Procedures(NEWU706A_U706A_DELETE_HEADER_13)"


    #region "Automatic Item Initialization(NEWU706A_U706A_DELETE_HEADER_13)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(NEWU706A_U706A_DELETE_HEADER_13)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:46:39 PM

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
        fleF002_SUSPEND_HDR.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(NEWU706A_U706A_DELETE_HEADER_13)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:46:39 PM

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
            fleF002_SUSPEND_HDR.Dispose();


        }
        catch (CustomApplicationException ex)
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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(NEWU706A_U706A_DELETE_HEADER_13)"


    public void Run()
    {

        try
        {
            Request("U706A_DELETE_HEADER_13");

            while (fleF002_SUSPEND_HDR.QTPForMissing())
            {
                // --> GET F002_SUSPEND_HDR <--

                fleF002_SUSPEND_HDR.GetData();
                // --> End GET F002_SUSPEND_HDR <--


                if (Transaction())
                {

                    if (Select_If())
                    {

                        fleF002_SUSPEND_HDR.OutPut(OutPutType.Delete);

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
            EndRequest("U706A_DELETE_HEADER_13");

        }

    }




    #endregion


}
//U706A_DELETE_HEADER_13



public class NEWU706A_UPDATE_PAT_CLM_NBR_14 : NEWU706A
{

    public NEWU706A_UPDATE_PAT_CLM_NBR_14(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU706A_CLAIMS_KEYS = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U706A_CLAIMS_KEYS", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF010_PAT_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F010_PAT_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        XCOUNT = new CoreDecimal("XCOUNT", 6, this);
        X_CLAIM_COUNT = new CoreDecimal("X_CLAIM_COUNT", 6, this);
        X_MAX_ADMIT_DATE = new CoreDate("X_MAX_ADMIT_DATE", this);
        X_MAX_SERV_DATE = new CoreDate("X_MAX_SERV_DATE", this);
        fleSAVEF010_MC = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "SAVEF010_MC", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleSAVEF010 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "SAVEF010", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF010_PAT_MSTR.SetItemFinals += fleF010_PAT_MSTR_SetItemFinals;
        X_ADMIT_DATE.GetValue += X_ADMIT_DATE_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(NEWU706A_UPDATE_PAT_CLM_NBR_14)"

    public override bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(fleU706A_CLAIMS_KEYS.GetStringValue("W_P_KEY_CLAIMS_MSTR")) != "P")
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

    private SqlFileObject fleU706A_CLAIMS_KEYS;
    private SqlFileObject fleF010_PAT_MSTR;

    private void fleF010_PAT_MSTR_SetItemFinals()
    {

        try
        {
            fleF010_PAT_MSTR.set_SetValue("PAT_NBR_OUTSTANDING_CLAIMS", fleF010_PAT_MSTR.GetDecimalValue("PAT_NBR_OUTSTANDING_CLAIMS") + X_CLAIM_COUNT.Value);
            fleF010_PAT_MSTR.set_SetValue("PAT_TOTAL_NBR_CLAIMS", fleF010_PAT_MSTR.GetDecimalValue("PAT_TOTAL_NBR_CLAIMS") + X_CLAIM_COUNT.Value);
            if (QDesign.NULL(X_MAX_SERV_DATE.Value) > QDesign.NULL(fleF010_PAT_MSTR.GetNumericDateValue("PAT_DATE_LAST_VISIT")))
            {
                fleF010_PAT_MSTR.set_SetValue("PAT_DATE_LAST_VISIT", X_MAX_SERV_DATE.Value);
            }
            if (QDesign.NULL(X_MAX_SERV_DATE.Value) > QDesign.NULL(fleF010_PAT_MSTR.GetNumericDateValue("PAT_DATE_LAST_VISIT")))
            {
                fleF010_PAT_MSTR.set_SetValue("PAT_DATE_LAST_VISIT", X_MAX_SERV_DATE.Value);
            }
            if (QDesign.NULL(X_MAX_ADMIT_DATE.Value) > QDesign.NULL(fleF010_PAT_MSTR.GetNumericDateValue("PAT_DATE_LAST_ADMIT")))
            {
                fleF010_PAT_MSTR.set_SetValue("PAT_DATE_LAST_ADMIT", X_MAX_ADMIT_DATE.Value);
            }
            if (QDesign.NULL(X_MAX_ADMIT_DATE.Value) > QDesign.NULL(fleF010_PAT_MSTR.GetNumericDateValue("PAT_DATE_LAST_ADMIT")))
            {
                fleF010_PAT_MSTR.set_SetValue("PAT_DATE_LAST_ADMIT", X_MAX_ADMIT_DATE.Value);
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

    private SqlFileObject fleF002_CLAIMS_MSTR;
    private CoreDecimal XCOUNT;
    private CoreDecimal X_CLAIM_COUNT;
    private DDecimal X_ADMIT_DATE = new DDecimal("X_ADMIT_DATE");
    private void X_ADMIT_DATE_GetValue(ref decimal Value)
    {

        try
        {
            Value = QDesign.NConvert(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_DATE_ADMIT"));


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
    private CoreDate X_MAX_ADMIT_DATE;

    private CoreDate X_MAX_SERV_DATE;

























    private SqlFileObject fleSAVEF010_MC;


























    private SqlFileObject fleSAVEF010;


    #endregion


    #region "Standard Generated Procedures(NEWU706A_UPDATE_PAT_CLM_NBR_14)"


    #region "Automatic Item Initialization(NEWU706A_UPDATE_PAT_CLM_NBR_14)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(NEWU706A_UPDATE_PAT_CLM_NBR_14)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:46:39 PM

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
        fleU706A_CLAIMS_KEYS.Transaction = m_trnTRANS_UPDATE;
        fleF010_PAT_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleSAVEF010_MC.Transaction = m_trnTRANS_UPDATE;
        fleSAVEF010.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(NEWU706A_UPDATE_PAT_CLM_NBR_14)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:46:39 PM

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
            fleU706A_CLAIMS_KEYS.Dispose();
            fleF010_PAT_MSTR.Dispose();
            fleF002_CLAIMS_MSTR.Dispose();
            fleSAVEF010_MC.Dispose();
            fleSAVEF010.Dispose();


        }
        catch (CustomApplicationException ex)
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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(NEWU706A_UPDATE_PAT_CLM_NBR_14)"


    public void Run()
    {

        try
        {
            Request("UPDATE_PAT_CLM_NBR_14");

            while (fleU706A_CLAIMS_KEYS.QTPForMissing())
            {
                // --> GET U706A_CLAIMS_KEYS <--

                fleU706A_CLAIMS_KEYS.GetData();
                // --> End GET U706A_CLAIMS_KEYS <--

                while (fleF010_PAT_MSTR.QTPForMissing("1"))
                {
                    // --> GET F010_PAT_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_I_KEY")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((("I" + QDesign.Substring(fleU706A_CLAIMS_KEYS.GetStringValue("W_P_KEY_CLAIMS_MSTR"), 2, 15))).PadRight(16).Substring(0, 1)));
                    //Parent:KEY_PAT_MSTR
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_CON_NBR")).Append(" = ");
                    m_strWhere.Append(QDesign.NConvert((("I" + QDesign.Substring(fleU706A_CLAIMS_KEYS.GetStringValue("W_P_KEY_CLAIMS_MSTR"), 2, 15))).PadRight(16).Substring(1, 2)));
                    //Parent:KEY_PAT_MSTR
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_I_NBR")).Append(" = ");
                    m_strWhere.Append(QDesign.NConvert((("I" + QDesign.Substring(fleU706A_CLAIMS_KEYS.GetStringValue("W_P_KEY_CLAIMS_MSTR"), 2, 15))).PadRight(16).Substring(3, 12)));
                    //Parent:KEY_PAT_MSTR
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("FILLER4")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((("I" + QDesign.Substring(fleU706A_CLAIMS_KEYS.GetStringValue("W_P_KEY_CLAIMS_MSTR"), 2, 15))).PadRight(16).Substring(15, 1)));
                    //Parent:KEY_PAT_MSTR

                    fleF010_PAT_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F010_PAT_MSTR <--

                    while (fleF002_CLAIMS_MSTR.QTPForMissing("2"))
                    {
                        // --> GET F002_CLAIMS_MSTR <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                        m_strWhere.Append(Common.StringToField("B"));
                        m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(QDesign.Substring(fleU706A_CLAIMS_KEYS.GetStringValue("W_KEY_CLAIMS_MSTR"), 2, 8)));
                        m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ");
                        m_strWhere.Append((QDesign.NConvert(QDesign.Substring(fleU706A_CLAIMS_KEYS.GetStringValue("W_KEY_CLAIMS_MSTR"), 10, 2))));
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
                                Sort(fleU706A_CLAIMS_KEYS.GetSortValue("W_P_KEY_CLAIMS_MSTR"));
                            }

                        }

                    }

                }

            }

            while (Sort(fleU706A_CLAIMS_KEYS, fleF010_PAT_MSTR, fleF002_CLAIMS_MSTR))
            {
                XCOUNT.Value = XCOUNT.Value + 1;
                X_CLAIM_COUNT.Value = X_CLAIM_COUNT.Value + 1;
                Maximum(ref X_MAX_ADMIT_DATE);
                Maximum(ref X_MAX_SERV_DATE);


                SubFile(ref m_trnTRANS_UPDATE, ref fleSAVEF010_MC, SubFileType.Keep, XCOUNT, fleU706A_CLAIMS_KEYS, fleF002_CLAIMS_MSTR, "CLMHDR_SERV_DATE", X_MAX_SERV_DATE, "CLMHDR_DATE_ADMIT", X_MAX_ADMIT_DATE,
                X_CLAIM_COUNT);



                SubFile(ref m_trnTRANS_UPDATE, ref fleSAVEF010, fleU706A_CLAIMS_KEYS.At("W_P_KEY_CLAIMS_MSTR"), SubFileType.Keep, fleU706A_CLAIMS_KEYS, "W_P_KEY_CLAIMS_MSTR", fleF010_PAT_MSTR, "PAT_DATE_LAST_VISIT", X_MAX_SERV_DATE,
                "PAT_DATE_LAST_ADMIT", X_MAX_ADMIT_DATE);



                fleF010_PAT_MSTR.OutPut(OutPutType.Update, fleU706A_CLAIMS_KEYS.At("W_P_KEY_CLAIMS_MSTR"), null);


                Reset(ref X_CLAIM_COUNT, fleU706A_CLAIMS_KEYS.At("W_P_KEY_CLAIMS_MSTR"));
                Reset(ref X_MAX_ADMIT_DATE, fleU706A_CLAIMS_KEYS.At("W_P_KEY_CLAIMS_MSTR"));
                Reset(ref X_MAX_SERV_DATE, fleU706A_CLAIMS_KEYS.At("W_P_KEY_CLAIMS_MSTR"));

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
            EndRequest("UPDATE_PAT_CLM_NBR_14");

        }

    }




    #endregion


}
//UPDATE_PAT_CLM_NBR_14




