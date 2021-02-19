
#region "Screen Comments"

// #> PROGRAM-ID.     u021f.qts
// ((C)) Dyad Technologies
// PROGRAM PURPOSE :  the OHIP EDT error file is used to update:
// -  the f087 submission rejection file, 
// - the f002 claim record service/eligibility status
// - the f010 patient`s message code and obec status
// - and the rejected-claims file (f085)
// Logic:
// if any of the claim detail error codes are `E`ligibility type 
// errors according to error code lookup in f093 then set claim`s
// status to chargeable to doctor
// MODIFICATION HISTORY
// DATE   WHO         DESCRIPTION
// 03/jul/10 b.e.        - original 
// 03/oct/20 b.e. - add update of f002
// 03/oct/27 b.e. - added audit of f002/f010 updates
// 03/nov/17 b.e. - handle both header and detail errors on a single claim
// 03/nov/20 b.e. - added `on error report` to output statement of 
// all `add` files so that the program continues if we
// attempt to add a duplicate record
// 03/nov/21 b.e. - code added to consider error codes in all 5 codes 
// positions within header and detail error arrays 
// 03/nov/28 b.e. - if patient`s version code has changed since the 
// submission and submission error is certain eligibiligy
// errors then force claim resubmit by setting status
// to  X 
// 04/jan/14 b.e. - don`t add transaction to rejected-claim file if claim
// is being automatically resubmitted ie. status set
// to  X 
// 04/feb/26 M.C. - don`t update pat-mstr file if claim is being automatically 
// resubmitted ie. status set to  X 
// 04/mar/04 M.C. - convert the current first request into copybook
// - add the second request to access u021a-edt-rmb-file to do
// the same as the u021a-edt-1ht-file  (never process for rmb file)
// 04/may/03 M.C.        - if service reject and error code = VJ7, set charge-status = `N`


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U021F : BaseClassControl
{

    private U021F m_U021F;

    public U021F(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public U021F(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_U021F != null))
        {
            m_U021F.CloseTransactionObjects();
            m_U021F = null;
        }
    }

    public U021F GetU021F(int Level)
    {
        if (m_U021F == null)
        {
            m_U021F = new U021F("U021F", Level);
        }
        else
        {
            m_U021F.ResetValues();
        }
        return m_U021F;
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

            U021F_PROCESS_SUBMIT_ERRORS_1 PROCESS_SUBMIT_ERRORS_1 = new U021F_PROCESS_SUBMIT_ERRORS_1(Name, Level);
            PROCESS_SUBMIT_ERRORS_1.Run();
            PROCESS_SUBMIT_ERRORS_1.Dispose();
            PROCESS_SUBMIT_ERRORS_1 = null;

            U021F_PROCESS_RMB_SUBMIT_ERRORS_2 PROCESS_RMB_SUBMIT_ERRORS_2 = new U021F_PROCESS_RMB_SUBMIT_ERRORS_2(Name, Level);
            PROCESS_RMB_SUBMIT_ERRORS_2.Run();
            PROCESS_RMB_SUBMIT_ERRORS_2.Dispose();
            PROCESS_RMB_SUBMIT_ERRORS_2 = null;

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



public class U021F_PROCESS_SUBMIT_ERRORS_1 : U021F
{

    public U021F_PROCESS_SUBMIT_ERRORS_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU021A = new SqlFileObject(this, FileTypes.Primary, 0, "SEQUENTIAL", "U021A_EDT_1HT_FILE", "U021A", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF010_PAT_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F010_PAT_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleICONST_MSTR_REC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "ICONST_MSTR_REC", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF093_HDR_1 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F093_OHIP_ERROR_MSG_MSTR", "F093_HDR_1", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF093_HDR_2 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F093_OHIP_ERROR_MSG_MSTR", "F093_HDR_2", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF093_HDR_3 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F093_OHIP_ERROR_MSG_MSTR", "F093_HDR_3", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF093_HDR_4 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F093_OHIP_ERROR_MSG_MSTR", "F093_HDR_4", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF093_HDR_5 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F093_OHIP_ERROR_MSG_MSTR", "F093_HDR_5", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF093_DTL_1 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F093_OHIP_ERROR_MSG_MSTR", "F093_DTL_1", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF093_DTL_2 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F093_OHIP_ERROR_MSG_MSTR", "F093_DTL_2", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF093_DTL_3 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F093_OHIP_ERROR_MSG_MSTR", "F093_DTL_3", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF093_DTL_4 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F093_OHIP_ERROR_MSG_MSTR", "F093_DTL_4", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF093_DTL_5 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F093_OHIP_ERROR_MSG_MSTR", "F093_DTL_5", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_CHARGE_STATUS = new CoreCharacter("X_CHARGE_STATUS", 1, this, Common.cEmptyString);
        X_OHIP_ERR_HDR_ELIG_SS = new CoreDecimal("X_OHIP_ERR_HDR_ELIG_SS", 6, this);
        X_OHIP_ERR_HDR_SERV_SS = new CoreDecimal("X_OHIP_ERR_HDR_SERV_SS", 6, this);
        X_OHIP_ERR_DTL_ELIG_SS = new CoreDecimal("X_OHIP_ERR_DTL_ELIG_SS", 6, this);
        X_OHIP_ERR_DTL_SERV_SS = new CoreDecimal("X_OHIP_ERR_DTL_SERV_SS", 6, this);
        X_OHIP_ERR_CODE_HDR_THIS_REC = new CoreCharacter("X_OHIP_ERR_CODE_HDR_THIS_REC", 3, this, Common.cEmptyString);
        X_OHIP_ERR_CODE_HDR_CAT_THIS_REC = new CoreCharacter("X_OHIP_ERR_CODE_HDR_CAT_THIS_REC", 1, this, Common.cEmptyString);
        X_OHIP_ERR_CODE_DTL_THIS_REC = new CoreCharacter("X_OHIP_ERR_CODE_DTL_THIS_REC", 3, this, Common.cEmptyString);
        X_OHIP_ERR_CODE_DTL_CAT_THIS_REC = new CoreCharacter("X_OHIP_ERR_CODE_DTL_CAT_THIS_REC", 1, this, Common.cEmptyString);
        X_OHIP_ERR_CODE_HDR_CLAIM = new CoreCharacter("X_OHIP_ERR_CODE_HDR_CLAIM", 3, this, Common.cEmptyString);
        X_OHIP_ERR_CODE_DTL_CAT_CLAIM = new CoreCharacter("X_OHIP_ERR_CODE_DTL_CAT_CLAIM", 1, this, Common.cEmptyString);
        X_OHIP_ERR_CODE_HDR_CAT_CLAIM = new CoreCharacter("X_OHIP_ERR_CODE_HDR_CAT_CLAIM", 1, this, Common.cEmptyString);
        X_OHIP_ERR_CODE_DTL_CLAIM = new CoreCharacter("X_OHIP_ERR_CODE_DTL_CLAIM", 3, this, Common.cEmptyString);
        X_HDR_CODE_GOING_TO_BE_CHANGED = new CoreCharacter("X_HDR_CODE_GOING_TO_BE_CHANGED", 1, this, Common.cEmptyString);
        X_DTL_CODE_GOING_TO_BE_CHANGED = new CoreCharacter("X_DTL_CODE_GOING_TO_BE_CHANGED", 1, this, Common.cEmptyString);
        X_OHIP_ERR_CODE_DTL_SERV_THIS_REC = new CoreCharacter("X_OHIP_ERR_CODE_DTL_SERV_THIS_REC", 3, this, Common.cEmptyString);
        X_OHIP_ERR_CODE_HDR_SERV_THIS_REC = new CoreCharacter("X_OHIP_ERR_CODE_HDR_SERV_THIS_REC", 3, this, Common.cEmptyString);
        X_OHIP_ERR_CODE_HDR_SERV_CLAIM = new CoreCharacter("X_OHIP_ERR_CODE_HDR_SERV_CLAIM", 3, this, Common.cEmptyString);
        X_OHIP_ERR_CODE_DTL_SERV_CLAIM = new CoreCharacter("X_OHIP_ERR_CODE_DTL_SERV_CLAIM", 3, this, Common.cEmptyString);
        X_OHIP_ERR_CODE_FINAL = new CoreCharacter("X_OHIP_ERR_CODE_FINAL", 3, this, Common.cEmptyString);
        X_OHIP_ERR_CODE_FINAL_CAT = new CoreCharacter("X_OHIP_ERR_CODE_FINAL_CAT", 1, this, Common.cEmptyString);
        X_F002_CLAIM_STATUS = new CoreCharacter("X_F002_CLAIM_STATUS", 1, this, Common.cEmptyString);
        REC_COUNTER = new CoreDecimal("REC_COUNTER", 6, this);
        fleF087_DTL_ADD = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F087_SUBMITTED_REJECTED_CLAIMS_DTL", "F087_DTL_ADD", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF087_HDR_ADD = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F087_SUBMITTED_REJECTED_CLAIMS_HDR", "F087_HDR_ADD", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_UPDATE = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "F002_UPDATE", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleREJECTED_CLAIMS = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "REJECTED_CLAIMS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleMOH_OBEC = new SqlFileObject(this, FileTypes.Primary, 0, "SEQUENTIAL", "MOH_OBEC", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF010_UPDATE = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F010_PAT_MSTR", "F010_UPDATE", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleU021F_F002_AUDIT = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U021F_F002_AUDIT", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU021F_F010_AUDIT = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U021F_F010_AUDIT", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU021F_DEBUG = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U021F_DEBUG", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU021F_DEBUG_GW = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U021F_DEBUG_GW", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_BAL_DUE.GetValue += X_BAL_DUE_GetValue;
        X_PED.GetValue += X_PED_GetValue;
        X_NO_CHARGE_REJ_CODE.GetValue += X_NO_CHARGE_REJ_CODE_GetValue;
        RUN_DATE.GetValue += RUN_DATE_GetValue;
        RUN_TIME.GetValue += RUN_TIME_GetValue;

        // GW2019. Mar 10, Added
        fleF087_DTL_ADD.SetItemFinals += fleF087_DTL_ADD_SetItemFinals;
        fleF087_HDR_ADD.SetItemFinals += fleF087_HDR_ADD_SetItemFinals;
        fleREJECTED_CLAIMS.SetItemFinals += fleREJECTED_CLAIMS_SetItemFinals;
        fleMOH_OBEC.SetItemFinals += fleMOH_OBEC_SetItemFinals;
    }

    // GW2019. Mar 10, Added
    private void fleF087_DTL_ADD_SetItemFinals()
    {

        try
        {
            fleF087_DTL_ADD.set_SetValue("CLMHDR_BATCH_NBR", (fleU021A.GetStringValue("RAT_RMB_GROUP_NBR").Substring(0,2)) + fleU021A.GetStringValue("RAT_RMB_ACCOUNT_NBR").Substring(0, 6));
            fleF087_DTL_ADD.set_SetValue("CLMHDR_CLAIM_NBR", fleU021A.GetStringValue("RAT_RMB_ACCOUNT_NBR").Substring(6, 2));
            fleF087_DTL_ADD.set_SetValue("PED", X_PED.Value);
            fleF087_DTL_ADD.set_SetValue("EDT_PROCESS_DATE", fleU021A.GetDecimalValue("RAT_RMB_PROCESS_DATE"));
            fleF087_DTL_ADD.set_SetValue("KEY_DTL_SEQ_NBR", REC_COUNTER.Value);

            fleF087_DTL_ADD.set_SetValue("EDT_OMA_SERVICE_CD_AND_SUFFIX", fleU021A.GetStringValue("RAT_RMB_SERVICE_CD"));
            fleF087_DTL_ADD.set_SetValue("EDT_SERVICE_DATE", fleU021A.GetDecimalValue("RAT_RMB_SERVICE_DATE"));
            fleF087_DTL_ADD.set_SetValue("EDT_DTL_DIAG_CD", fleU021A.GetStringValue("RAT_RMB_DIAG_CD"));
            fleF087_DTL_ADD.set_SetValue("EDT_NBR_SERV", fleU021A.GetDecimalValue("RAT_RMB_NBR_OF_SERV"));
            fleF087_DTL_ADD.set_SetValue("EDT_AMOUNT_SUBMITTED", fleU021A.GetDecimalValue("RAT_RMB_AMOUNT_SUB"));
            fleF087_DTL_ADD.set_SetValue("EDT_DTL_ERR_EXPLAN_CD", fleU021A.GetStringValue("RAT_RMB_T_EXPLAN_CD"));
            fleF087_DTL_ADD.set_SetValue("EDT_DTL_ERR_CD_1", fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_1"));
            fleF087_DTL_ADD.set_SetValue("EDT_DTL_ERR_CD_2", fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_2"));
            fleF087_DTL_ADD.set_SetValue("EDT_DTL_ERR_CD_3", fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_3"));
            fleF087_DTL_ADD.set_SetValue("EDT_DTL_ERR_CD_4", fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_4"));
            fleF087_DTL_ADD.set_SetValue("EDT_DTL_ERR_CD_5", fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_5"));
            fleF087_DTL_ADD.set_SetValue("EDT_DTL_ERR_8_EXPLAN_CD", fleU021A.GetStringValue("RAT_RMB_8_EXPLAN_CD"));
            fleF087_DTL_ADD.set_SetValue("EDT_DTL_ERR_8_EXPLAN_DESC", fleU021A.GetStringValue("RAT_RMB_8_EXPLAN_DESC"));

            fleF087_DTL_ADD.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));
            fleF087_DTL_ADD.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);
            fleF087_DTL_ADD.set_SetValue("LAST_MOD_USER_ID", "u021f gen`d");
        }
        catch (CustomApplicationException ex)
        {
            WriteError(ex);
        }
        catch (Exception ex)
        {
            WriteError(ex);
        }
    }

    // GW2019. Mar 10, Added
    private void fleF087_HDR_ADD_SetItemFinals()
    {

        try
        {
            fleF087_HDR_ADD.set_SetValue("CLMHDR_BATCH_NBR", (fleU021A.GetStringValue("RAT_RMB_GROUP_NBR").Substring(0, 2)) + fleU021A.GetStringValue("RAT_RMB_ACCOUNT_NBR").Substring(0, 6));
            fleF087_HDR_ADD.set_SetValue("CLMHDR_CLAIM_NBR", fleU021A.GetStringValue("RAT_RMB_ACCOUNT_NBR").Substring(6, 2));
            fleF087_HDR_ADD.set_SetValue("CLMHDR_DOC_NBR", fleU021A.GetStringValue("RAT_RMB_ACCOUNT_NBR").Substring(0, 3));
            fleF087_HDR_ADD.set_SetValue("PED", X_PED.Value);
            fleF087_HDR_ADD.set_SetValue("EDT_PROCESS_DATE", fleU021A.GetDecimalValue("RAT_RMB_PROCESS_DATE"));

            fleF087_HDR_ADD.set_SetValue("EDT_HEALTH_NBR", fleU021A.GetStringValue("RAT_RMB_HEALTH_NBR"));
            fleF087_HDR_ADD.set_SetValue("EDT_HEALTH_VERSION_CD", fleU021A.GetStringValue("RAT_RMB_VERSION_CD"));
            fleF087_HDR_ADD.set_SetValue("EDT_PAT_BIRTH_DATE", fleU021A.GetDecimalValue("RAT_RMB_BIRTH_DATE"));
            fleF087_HDR_ADD.set_SetValue("EDT_ACCOUNT_NBR", fleU021A.GetStringValue("RAT_RMB_ACCOUNT_NBR"));
            fleF087_HDR_ADD.set_SetValue("EDT_PAY_PROG", fleU021A.GetStringValue("RAT_RMB_PAY_PROG"));
            fleF087_HDR_ADD.set_SetValue("EDT_PAYEE", fleU021A.GetStringValue("RAT_RMB_PAYEE"));
            fleF087_HDR_ADD.set_SetValue("EFT_REFERRING_DOC_NBR", fleU021A.GetDecimalValue("RAT_RMB_REFER_DOC_NBR"));
            fleF087_HDR_ADD.set_SetValue("EDT_FACILITY_NBR", fleU021A.GetStringValue("RAT_RMB_FACILITY_NBR"));
            fleF087_HDR_ADD.set_SetValue("EDT_ADMIT_DATE", fleU021A.GetDecimalValue("RAT_RMB_ADMIT_DATE"));
            fleF087_HDR_ADD.set_SetValue("EDT_LOCATION_CD", fleU021A.GetStringValue("RAT_RMB_LOC_CD"));
            fleF087_HDR_ADD.set_SetValue("OHIP_ERR_CODE", X_OHIP_ERR_CODE_FINAL.Value);
            fleF087_HDR_ADD.set_SetValue("EDT_ERR_H_CD_1", fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_1"));
            fleF087_HDR_ADD.set_SetValue("EDT_ERR_H_CD_2", fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_2"));
            fleF087_HDR_ADD.set_SetValue("EDT_ERR_H_CD_3", fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_3"));
            fleF087_HDR_ADD.set_SetValue("EDT_ERR_H_CD_4", fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_4"));
            fleF087_HDR_ADD.set_SetValue("EDT_ERR_H_CD_5", fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_5"));
            // fleF087_HDR_ADD.set_SetValue("CHARGE_STATUS", fleU021A.GetDecimalValue("'N' IF X_NO_CHARGE_REJ_CODE = 'Y'    &  ELSE  "Y"

            fleF087_HDR_ADD.set_SetValue("ENTRY_DATE", QDesign.SysDate(ref m_cnnQUERY));
            fleF087_HDR_ADD.set_SetValue("ENTRY_TIME_LONG", QDesign.SysTime(ref m_cnnQUERY) / 10000);
            fleF087_HDR_ADD.set_SetValue("ENTRY_USER_ID", "u021f gen`d");

            fleF087_HDR_ADD.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));
            fleF087_HDR_ADD.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);
            fleF087_HDR_ADD.set_SetValue("LAST_MOD_USER_ID", "u021f gen`d");
        }
        catch (CustomApplicationException ex)
        {
            WriteError(ex);
        }
        catch (Exception ex)
        {
            WriteError(ex);
        }

    }

    // GW2019. Mar 10, Added
    private void fleREJECTED_CLAIMS_SetItemFinals()
    {
        try
        {
            fleREJECTED_CLAIMS.set_SetValue("CLAIM_NBR", (fleU021A.GetStringValue("RAT_RMB_GROUP_NBR").Substring(0, 2)) + fleU021A.GetStringValue("RAT_RMB_ACCOUNT_NBR"));
            fleREJECTED_CLAIMS.set_SetValue("DOC_NBR", fleU021A.GetStringValue("RAT_RMB_ACCOUNT_NBR").Substring(0, 3));
            fleREJECTED_CLAIMS.set_SetValue("CLMHDR_PAT_OHIP_ID_OR_CHART", fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_TYPE") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_DATA"));
            fleREJECTED_CLAIMS.set_SetValue("CLMHDR_LOC", fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_LOC"));
            fleREJECTED_CLAIMS.set_SetValue("MESS_CODE", X_OHIP_ERR_CODE_FINAL.Value);
            fleREJECTED_CLAIMS.set_SetValue("CLMHDR_SUBMIT_DATE", 0);
        }
        catch (CustomApplicationException ex)
        {
            WriteError(ex);
        }
        catch (Exception ex)
        {
            WriteError(ex);
        }
    }

    // GW2019. Mar 10, Added
    private void fleMOH_OBEC_SetItemFinals()
    {
        try
        {
            fleMOH_OBEC.set_SetValue("PAT_HEALTH_NBR", fleF010_PAT_MSTR.GetDecimalValue("PAT_HEALTH_NBR"));
            fleMOH_OBEC.set_SetValue("PAT_VERSION_CD", fleF010_PAT_MSTR.GetStringValue("PAT_VERSION_CD"));
            fleMOH_OBEC.set_SetValue("PAT_SEX", fleF010_PAT_MSTR.GetStringValue("PAT_SEX"));
            fleMOH_OBEC.set_SetValue("OBEC_SUBMISSION_ID", " ");
        }
        catch (CustomApplicationException ex)
        {
            WriteError(ex);
        }
        catch (Exception ex)
        {
            WriteError(ex);
        }
    }

    #region "Declarations (Variables, Files and Transactions)(U021F_PROCESS_SUBMIT_ERRORS_1)"

    private SqlFileObject fleU021A;
    private SqlFileObject fleF020_DOCTOR_MSTR;
    private SqlFileObject fleF002_CLAIMS_MSTR;
    private SqlFileObject fleF010_PAT_MSTR;
    private SqlFileObject fleICONST_MSTR_REC;
    private SqlFileObject fleF093_HDR_1;
    private SqlFileObject fleF093_HDR_2;
    private SqlFileObject fleF093_HDR_3;
    private SqlFileObject fleF093_HDR_4;
    private SqlFileObject fleF093_HDR_5;
    private SqlFileObject fleF093_DTL_1;
    private SqlFileObject fleF093_DTL_2;
    private SqlFileObject fleF093_DTL_3;
    private SqlFileObject fleF093_DTL_4;
    private SqlFileObject fleF093_DTL_5;
    private DDecimal X_BAL_DUE = new DDecimal("X_BAL_DUE", 8);

    private void X_BAL_DUE_GetValue(ref decimal Value)
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

    private DDecimal X_PED = new DDecimal("X_PED");
    private void X_PED_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (fleF002_CLAIMS_MSTR.Exists())
            {
                CurrentValue = fleF002_CLAIMS_MSTR.GetNumericDateValue("CLMHDR_DATE_PERIOD_END");
            }
            else
            {
                CurrentValue = fleU021A.GetNumericDateValue("RAT_RMB_PROCESS_DATE");
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
    private CoreCharacter X_CHARGE_STATUS;
    private CoreDecimal X_OHIP_ERR_HDR_ELIG_SS;
    private CoreDecimal X_OHIP_ERR_HDR_SERV_SS;
    private CoreDecimal X_OHIP_ERR_DTL_ELIG_SS;
    private CoreDecimal X_OHIP_ERR_DTL_SERV_SS;
    private CoreCharacter X_OHIP_ERR_CODE_HDR_THIS_REC;
    private CoreCharacter X_OHIP_ERR_CODE_HDR_CAT_THIS_REC;
    private CoreCharacter X_OHIP_ERR_CODE_DTL_THIS_REC;
    private CoreCharacter X_OHIP_ERR_CODE_DTL_CAT_THIS_REC;
    private CoreCharacter X_OHIP_ERR_CODE_HDR_CLAIM;
    private CoreCharacter X_OHIP_ERR_CODE_DTL_CAT_CLAIM;
    private CoreCharacter X_OHIP_ERR_CODE_HDR_CAT_CLAIM;
    private CoreCharacter X_OHIP_ERR_CODE_DTL_CLAIM;
    private CoreCharacter X_HDR_CODE_GOING_TO_BE_CHANGED;
    private CoreCharacter X_DTL_CODE_GOING_TO_BE_CHANGED;
    private CoreCharacter X_OHIP_ERR_CODE_DTL_SERV_THIS_REC;
    private CoreCharacter X_OHIP_ERR_CODE_HDR_SERV_THIS_REC;
    private CoreCharacter X_OHIP_ERR_CODE_HDR_SERV_CLAIM;
    private CoreCharacter X_OHIP_ERR_CODE_DTL_SERV_CLAIM;
    private CoreCharacter X_OHIP_ERR_CODE_FINAL;
    private CoreCharacter X_OHIP_ERR_CODE_FINAL_CAT;
    private CoreCharacter X_F002_CLAIM_STATUS;
    private DCharacter X_NO_CHARGE_REJ_CODE = new DCharacter("X_NO_CHARGE_REJ_CODE", 1);
    private void X_NO_CHARGE_REJ_CODE_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) == QDesign.NULL("VJ7") | QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) == QDesign.NULL("EQE") | QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) == QDesign.NULL("A4D") | QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) == QDesign.NULL("EQF") | QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) == QDesign.NULL("AC4") | QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) == QDesign.NULL("ARF") | QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) == QDesign.NULL("ERF") | QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) == QDesign.NULL("ESD") | QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) == QDesign.NULL("V28") | QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) == QDesign.NULL("V66") | QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) == QDesign.NULL("VH1") | QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) == QDesign.NULL("EF4") | (string.Compare(X_OHIP_ERR_CODE_FINAL.Value, "EQ1") >= 0 & string.Compare(X_OHIP_ERR_CODE_FINAL.Value, "EQ6") <= 0) | (string.Compare(X_OHIP_ERR_CODE_FINAL.Value, "EQC") >= 0 & string.Compare(X_OHIP_ERR_CODE_FINAL.Value, "EQI") <= 0) | (string.Compare(X_OHIP_ERR_CODE_FINAL.Value, "R01") >= 0 & string.Compare(X_OHIP_ERR_CODE_FINAL.Value, "R09") <= 0) | (string.Compare(X_OHIP_ERR_CODE_FINAL.Value, "V05") >= 0 & string.Compare(X_OHIP_ERR_CODE_FINAL.Value, "V22") <= 0) | (string.Compare(X_OHIP_ERR_CODE_FINAL.Value, "V39") >= 0 & string.Compare(X_OHIP_ERR_CODE_FINAL.Value, "V42") <= 0) | (string.Compare(X_OHIP_ERR_CODE_FINAL.Value, "V51") >= 0 & string.Compare(X_OHIP_ERR_CODE_FINAL.Value, "V62") <= 0) | (QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) == QDesign.NULL("A36") & QDesign.NULL(QDesign.Substring(fleU021A.GetStringValue("RAT_RMB_GROUP_NBR"), 1, 2)) == QDesign.NULL("22") & (QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_DOC_DEPT")) == 41 | QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_DOC_DEPT")) == 42 | QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_DOC_DEPT")) == 43 | QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_DOC_DEPT")) == 75)))
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
    private CoreDecimal REC_COUNTER;
    private DDecimal RUN_DATE = new DDecimal("RUN_DATE");
    private void RUN_DATE_GetValue(ref decimal Value)
    {

        try
        {
            Value = QDesign.SysDate(ref m_cnnQUERY);


        }
        catch (CustomApplicationException ex)
        {
            WriteError(ex);


        }
        catch (Exception ex)
        {
            WriteError(ex);

        }



    }
    private DDecimal RUN_TIME = new DDecimal("RUN_TIME", 4);
    private void RUN_TIME_GetValue(ref decimal Value)
    {

        try
        {

            // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

            Value = QDesign.SysTime(ref m_cnnQUERY) / 10000;


        }
        catch (CustomApplicationException ex)
        {
            WriteError(ex);


        }
        catch (Exception ex)
        {
            WriteError(ex);

        }



    }
    private SqlFileObject fleF087_DTL_ADD;
    private SqlFileObject fleF087_HDR_ADD;
    private SqlFileObject fleF002_UPDATE;
    private SqlFileObject fleREJECTED_CLAIMS;
    private SqlFileObject fleMOH_OBEC;
    private SqlFileObject fleF010_UPDATE;





    private SqlFileObject fleU021F_F002_AUDIT;






    private SqlFileObject fleU021F_F010_AUDIT;






    private SqlFileObject fleU021F_DEBUG;
    private SqlFileObject fleU021F_DEBUG_GW;


    #endregion


    #region "Standard Generated Procedures(U021F_PROCESS_SUBMIT_ERRORS_1)"

    #region "Transaction Management Procedures(U021F_PROCESS_SUBMIT_ERRORS_1)"
    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.

    //# Do not delete, modify or move it.
    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:01:18 PM

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
         fleU021A.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF010_PAT_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleICONST_MSTR_REC.Transaction = m_trnTRANS_UPDATE;
        fleF093_HDR_1.Transaction = m_trnTRANS_UPDATE;
        fleF093_HDR_2.Transaction = m_trnTRANS_UPDATE;
        fleF093_HDR_3.Transaction = m_trnTRANS_UPDATE;
        fleF093_HDR_4.Transaction = m_trnTRANS_UPDATE;
        fleF093_HDR_5.Transaction = m_trnTRANS_UPDATE;
        fleF093_DTL_1.Transaction = m_trnTRANS_UPDATE;
        fleF093_DTL_2.Transaction = m_trnTRANS_UPDATE;
        fleF093_DTL_3.Transaction = m_trnTRANS_UPDATE;
        fleF093_DTL_4.Transaction = m_trnTRANS_UPDATE;
        fleF093_DTL_5.Transaction = m_trnTRANS_UPDATE;

        // GW2019. Added
        fleF087_DTL_ADD.Transaction = m_trnTRANS_UPDATE;
        fleF087_HDR_ADD.Transaction = m_trnTRANS_UPDATE;
        fleREJECTED_CLAIMS.Transaction = m_trnTRANS_UPDATE;
        fleMOH_OBEC.Transaction = m_trnTRANS_UPDATE;
    }

    #endregion


    #region "FILE Management Procedures(U021F_PROCESS_SUBMIT_ERRORS_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.
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
            fleU021A.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleF002_CLAIMS_MSTR.Dispose();
            fleF010_PAT_MSTR.Dispose();
            fleICONST_MSTR_REC.Dispose();
            fleF093_HDR_1.Dispose();
            fleF093_HDR_2.Dispose();
            fleF093_HDR_3.Dispose();
            fleF093_HDR_4.Dispose();
            fleF093_HDR_5.Dispose();
            fleF093_DTL_1.Dispose();
            fleF093_DTL_2.Dispose();
            fleF093_DTL_3.Dispose();
            fleF093_DTL_4.Dispose();
            fleF093_DTL_5.Dispose();

            // GW2019. Mar 10 Added
            fleF087_DTL_ADD.Dispose();
            fleF087_HDR_ADD.Dispose();
            fleREJECTED_CLAIMS.Dispose();
            fleMOH_OBEC.Dispose();
        }
        catch (CustomApplicationException ex)
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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U021F_PROCESS_SUBMIT_ERRORS_1)"


    public void Run()
    {

        try
        {
            Request("PROCESS_SUBMIT_ERRORS_1");

            while (fleU021A.QTPForMissing())
            {
                // --> GET U021A <--

                fleU021A.GetData();
                // --> End GET U021A <--

                while (fleF020_DOCTOR_MSTR.QTPForMissing("1"))
                {
                    // --> GET F020_DOCTOR_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((QDesign.Substring(fleU021A.GetStringValue("RAT_RMB_ACCOUNT_NBR"), 1, 3))));

                    fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F020_DOCTOR_MSTR <--

                    while (fleF002_CLAIMS_MSTR.QTPForMissing("2"))
                    {
                        // --> GET F002_CLAIMS_MSTR <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                        m_strWhere.Append(Common.StringToField("B"));
                        m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(QDesign.Substring(fleU021A.GetStringValue("RAT_RMB_GROUP_NBR"), 1, 2) + QDesign.Substring(fleU021A.GetStringValue("RAT_RMB_ACCOUNT_NBR"), 1, 6)));
                        m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ");
                        m_strWhere.Append((QDesign.NConvert(QDesign.Substring(fleU021A.GetStringValue("RAT_RMB_ACCOUNT_NBR"), 7, 2))));
                        m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_SERV_CODE")).Append(" = ");
                        m_strWhere.Append(Common.StringToField("00000"));
                        m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_ADJ_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField("0"));

                        fleF002_CLAIMS_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F002_CLAIMS_MSTR <--

                        while (fleF010_PAT_MSTR.QTPForMissing("3"))
                        {
                            // --> GET F010_PAT_MSTR <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_I_KEY")).Append(" = ");
                            m_strWhere.Append(Common.StringToField(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_TYPE")));
                            //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART    'Parent:KEY_PAT_MSTR
                            m_strWhere.Append(" AND ").Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_CON_NBR")).Append(" = ");
                            m_strWhere.Append(QDesign.NConvert((fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_TYPE") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_DATA")).PadRight(16).Substring(1, 2)));
                            //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART    'Parent:KEY_PAT_MSTR
                            m_strWhere.Append(" AND ").Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_I_NBR")).Append(" = ");
                            m_strWhere.Append(QDesign.NConvert((fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_TYPE") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_DATA")).PadRight(16).Substring(3, 12)));
                            //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART    'Parent:KEY_PAT_MSTR
                            m_strWhere.Append(" AND ").Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("FILLER4")).Append(" = ");
                            m_strWhere.Append(Common.StringToField((fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_TYPE") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_DATA")).PadRight(16).Substring(15, 1)));
                            //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART    'Parent:KEY_PAT_MSTR

                            fleF010_PAT_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                            // --> End GET F010_PAT_MSTR <--

                            while (fleICONST_MSTR_REC.QTPForMissing("4"))
                            {
                                // --> GET ICONST_MSTR_REC <--
                                m_strWhere = new StringBuilder(" WHERE ");
                                m_strWhere.Append(" ").Append(fleICONST_MSTR_REC.ElementOwner("ICONST_CLINIC_NBR_1_2")).Append(" = ");
                                m_strWhere.Append(((QDesign.NConvert(QDesign.Substring(fleU021A.GetStringValue("RAT_RMB_GROUP_NBR"), 1, 2)))));

                                fleICONST_MSTR_REC.GetData(m_strWhere.ToString());
                                // --> End GET ICONST_MSTR_REC <--

                                while (fleF093_HDR_1.QTPForMissing("5"))
                                {
                                    // --> GET F093_HDR_1 <--
                                    m_strWhere = new StringBuilder(" WHERE ");
                                    m_strWhere.Append(" ").Append(fleF093_HDR_1.ElementOwner("OHIP_ERR_CODE")).Append(" = ");
                                    m_strWhere.Append(Common.StringToField(fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_1")));

                                    fleF093_HDR_1.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                    // --> End GET F093_HDR_1 <--

                                    while (fleF093_HDR_2.QTPForMissing("6"))
                                    {
                                        // --> GET F093_HDR_2 <--
                                        m_strWhere = new StringBuilder(" WHERE ");
                                        m_strWhere.Append(" ").Append(fleF093_HDR_2.ElementOwner("OHIP_ERR_CODE")).Append(" = ");
                                        m_strWhere.Append(Common.StringToField(fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_2")));

                                        fleF093_HDR_2.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                        // --> End GET F093_HDR_2 <--

                                        while (fleF093_HDR_3.QTPForMissing("7"))
                                        {
                                            // --> GET F093_HDR_3 <--
                                            m_strWhere = new StringBuilder(" WHERE ");
                                            m_strWhere.Append(" ").Append(fleF093_HDR_3.ElementOwner("OHIP_ERR_CODE")).Append(" = ");
                                            m_strWhere.Append(Common.StringToField(fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_3")));

                                            fleF093_HDR_3.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                            // --> End GET F093_HDR_3 <--

                                            while (fleF093_HDR_4.QTPForMissing("8"))
                                            {
                                                // --> GET F093_HDR_4 <--
                                                m_strWhere = new StringBuilder(" WHERE ");
                                                m_strWhere.Append(" ").Append(fleF093_HDR_4.ElementOwner("OHIP_ERR_CODE")).Append(" = ");
                                                m_strWhere.Append(Common.StringToField(fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_4")));

                                                fleF093_HDR_4.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                                // --> End GET F093_HDR_4 <--

                                                while (fleF093_HDR_5.QTPForMissing("9"))
                                                {
                                                    // --> GET F093_HDR_5 <--
                                                    m_strWhere = new StringBuilder(" WHERE ");
                                                    m_strWhere.Append(" ").Append(fleF093_HDR_5.ElementOwner("OHIP_ERR_CODE")).Append(" = ");
                                                    m_strWhere.Append(Common.StringToField(fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_5")));

                                                    fleF093_HDR_5.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                                    // --> End GET F093_HDR_5 <--

                                                    while (fleF093_DTL_1.QTPForMissing("10"))
                                                    {
                                                        // --> GET F093_DTL_1 <--
                                                        m_strWhere = new StringBuilder(" WHERE ");
                                                        m_strWhere.Append(" ").Append(fleF093_DTL_1.ElementOwner("OHIP_ERR_CODE")).Append(" = ");
                                                        m_strWhere.Append(Common.StringToField(fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_1")));

                                                        fleF093_DTL_1.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                                        // --> End GET F093_DTL_1 <--

                                                        while (fleF093_DTL_2.QTPForMissing("11"))
                                                        {
                                                            // --> GET F093_DTL_2 <--
                                                            m_strWhere = new StringBuilder(" WHERE ");
                                                            m_strWhere.Append(" ").Append(fleF093_DTL_2.ElementOwner("OHIP_ERR_CODE")).Append(" = ");
                                                            m_strWhere.Append(Common.StringToField(fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_2")));

                                                            fleF093_DTL_2.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                                            // --> End GET F093_DTL_2 <--

                                                            while (fleF093_DTL_3.QTPForMissing("12"))
                                                            {
                                                                // --> GET F093_DTL_3 <--
                                                                m_strWhere = new StringBuilder(" WHERE ");
                                                                m_strWhere.Append(" ").Append(fleF093_DTL_3.ElementOwner("OHIP_ERR_CODE")).Append(" = ");
                                                                m_strWhere.Append(Common.StringToField(fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_3")));

                                                                fleF093_DTL_3.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                                                // --> End GET F093_DTL_3 <--

                                                                while (fleF093_DTL_4.QTPForMissing("13"))
                                                                {
                                                                    // --> GET F093_DTL_4 <--
                                                                    m_strWhere = new StringBuilder(" WHERE ");
                                                                    m_strWhere.Append(" ").Append(fleF093_DTL_4.ElementOwner("OHIP_ERR_CODE")).Append(" = ");
                                                                    m_strWhere.Append(Common.StringToField(fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_4")));

                                                                    fleF093_DTL_4.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                                                    // --> End GET F093_DTL_4 <--

                                                                    while (fleF093_DTL_5.QTPForMissing("14"))
                                                                    {
                                                                        // --> GET F093_DTL_5 <--
                                                                        m_strWhere = new StringBuilder(" WHERE ");
                                                                        m_strWhere.Append(" ").Append(fleF093_DTL_5.ElementOwner("OHIP_ERR_CODE")).Append(" = ");
                                                                        m_strWhere.Append(Common.StringToField(fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_5")));

                                                                        fleF093_DTL_5.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                                                        // --> End GET F093_DTL_5 <--


                                                                        if (Transaction())
                                                                        {
                                                                            // GW. 2019. Mar 9. Added
                                                                            if (X_BAL_DUE.Value != 0)
                                                                            //if (Select_If())
                                                                            {
                                                                                Sort(fleU021A.GetSortValue("RAT_RMB_ACCOUNT_NBR"), fleU021A.GetSortValue("RAT_RMB_ORIG_SEQ_NBR"), fleU021A.GetSortValue("RAT_RMB_SERVICE_CD"), fleU021A.GetSortValue("RAT_RMB_SERVICE_DATE"));
                                                                            }

                                                                        }

                                                                    }

                                                                }

                                                            }

                                                        }

                                                    }

                                                }

                                            }

                                        }

                                    }

                                }

                            }

                        }

                    }

                }

            }

            while (Sort(fleU021A, fleF020_DOCTOR_MSTR, fleF002_CLAIMS_MSTR, fleF010_PAT_MSTR, fleICONST_MSTR_REC, fleF093_HDR_1, fleF093_HDR_2, fleF093_HDR_3, fleF093_HDR_4, fleF093_HDR_5,
            fleF093_DTL_1, fleF093_DTL_2, fleF093_DTL_3, fleF093_DTL_4, fleF093_DTL_5))
            {
                X_CHARGE_STATUS.Value = "Y";
                if (QDesign.NULL(fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_1")) != QDesign.NULL(" ") & QDesign.NULL(fleF093_HDR_1.GetStringValue("OHIP_ERR_CAT_CODE")) == QDesign.NULL("E"))
                {
                    X_OHIP_ERR_HDR_ELIG_SS.Value = 1;
                }
                else if (QDesign.NULL(fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_2")) != QDesign.NULL(" ") & QDesign.NULL(fleF093_HDR_2.GetStringValue("OHIP_ERR_CAT_CODE")) == QDesign.NULL("E"))
                {
                    X_OHIP_ERR_HDR_ELIG_SS.Value = 2;
                }
                else if (QDesign.NULL(fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_3")) != QDesign.NULL(" ") & QDesign.NULL(fleF093_HDR_3.GetStringValue("OHIP_ERR_CAT_CODE")) == QDesign.NULL("E"))
                {
                    X_OHIP_ERR_HDR_ELIG_SS.Value = 3;
                }
                else if (QDesign.NULL(fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_4")) != QDesign.NULL(" ") & QDesign.NULL(fleF093_HDR_4.GetStringValue("OHIP_ERR_CAT_CODE")) == QDesign.NULL("E"))
                {
                    X_OHIP_ERR_HDR_ELIG_SS.Value = 4;
                }
                else if (QDesign.NULL(fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_5")) != QDesign.NULL(" ") & QDesign.NULL(fleF093_HDR_5.GetStringValue("OHIP_ERR_CAT_CODE")) == QDesign.NULL("E"))
                {
                    X_OHIP_ERR_HDR_ELIG_SS.Value = 5;
                }
                else
                {
                    X_OHIP_ERR_HDR_ELIG_SS.Value = 0;
                }
                if (QDesign.NULL(fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_1")) != QDesign.NULL(" ") & QDesign.NULL(fleF093_HDR_1.GetStringValue("OHIP_ERR_CAT_CODE")) == QDesign.NULL("S"))
                {
                    X_OHIP_ERR_HDR_SERV_SS.Value = 1;
                }
                else if (QDesign.NULL(fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_2")) != QDesign.NULL(" ") & QDesign.NULL(fleF093_HDR_2.GetStringValue("OHIP_ERR_CAT_CODE")) == QDesign.NULL("S"))
                {
                    X_OHIP_ERR_HDR_SERV_SS.Value = 2;
                }
                else if (QDesign.NULL(fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_3")) != QDesign.NULL(" ") & QDesign.NULL(fleF093_HDR_3.GetStringValue("OHIP_ERR_CAT_CODE")) == QDesign.NULL("S"))
                {
                    X_OHIP_ERR_HDR_SERV_SS.Value = 3;
                }
                else if (QDesign.NULL(fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_4")) != QDesign.NULL(" ") & QDesign.NULL(fleF093_HDR_4.GetStringValue("OHIP_ERR_CAT_CODE")) == QDesign.NULL("S"))
                {
                    X_OHIP_ERR_HDR_SERV_SS.Value = 4;
                }
                else if (QDesign.NULL(fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_5")) != QDesign.NULL(" ") & QDesign.NULL(fleF093_HDR_5.GetStringValue("OHIP_ERR_CAT_CODE")) == QDesign.NULL("S"))
                {
                    X_OHIP_ERR_HDR_SERV_SS.Value = 5;
                }
                else
                {
                    X_OHIP_ERR_HDR_SERV_SS.Value = 0;
                }
                if (QDesign.NULL(fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_1")) != QDesign.NULL(" ") & QDesign.NULL(fleF093_DTL_1.GetStringValue("OHIP_ERR_CAT_CODE")) == QDesign.NULL("E"))
                {
                    X_OHIP_ERR_DTL_ELIG_SS.Value = 1;
                }
                else if (QDesign.NULL(fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_2")) != QDesign.NULL(" ") & QDesign.NULL(fleF093_DTL_2.GetStringValue("OHIP_ERR_CAT_CODE")) == QDesign.NULL("E"))
                {
                    X_OHIP_ERR_DTL_ELIG_SS.Value = 2;
                }
                else if (QDesign.NULL(fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_3")) != QDesign.NULL(" ") & QDesign.NULL(fleF093_DTL_3.GetStringValue("OHIP_ERR_CAT_CODE")) == QDesign.NULL("E"))
                {
                    X_OHIP_ERR_DTL_ELIG_SS.Value = 3;
                }
                else if (QDesign.NULL(fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_4")) != QDesign.NULL(" ") & QDesign.NULL(fleF093_DTL_4.GetStringValue("OHIP_ERR_CAT_CODE")) == QDesign.NULL("E"))
                {
                    X_OHIP_ERR_DTL_ELIG_SS.Value = 4;
                }
                else if (QDesign.NULL(fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_5")) != QDesign.NULL(" ") & QDesign.NULL(fleF093_DTL_5.GetStringValue("OHIP_ERR_CAT_CODE")) == QDesign.NULL("E"))
                {
                    X_OHIP_ERR_DTL_ELIG_SS.Value = 5;
                }
                else
                {
                    X_OHIP_ERR_DTL_ELIG_SS.Value = 0;
                }
                if (QDesign.NULL(fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_1")) != QDesign.NULL(" ") & QDesign.NULL(fleF093_DTL_1.GetStringValue("OHIP_ERR_CAT_CODE")) == QDesign.NULL("S"))
                {
                    X_OHIP_ERR_DTL_SERV_SS.Value = 1;
                }
                else if (QDesign.NULL(fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_2")) != QDesign.NULL(" ") & QDesign.NULL(fleF093_DTL_2.GetStringValue("OHIP_ERR_CAT_CODE")) == QDesign.NULL("S"))
                {
                    X_OHIP_ERR_DTL_SERV_SS.Value = 2;
                }
                else if (QDesign.NULL(fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_3")) != QDesign.NULL(" ") & QDesign.NULL(fleF093_DTL_3.GetStringValue("OHIP_ERR_CAT_CODE")) == QDesign.NULL("S"))
                {
                    X_OHIP_ERR_DTL_SERV_SS.Value = 3;
                }
                else if (QDesign.NULL(fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_4")) != QDesign.NULL(" ") & QDesign.NULL(fleF093_DTL_4.GetStringValue("OHIP_ERR_CAT_CODE")) == QDesign.NULL("S"))
                {
                    X_OHIP_ERR_DTL_SERV_SS.Value = 4;
                }
                else if (QDesign.NULL(fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_5")) != QDesign.NULL(" ") & QDesign.NULL(fleF093_DTL_5.GetStringValue("OHIP_ERR_CAT_CODE")) == QDesign.NULL("S"))
                {
                    X_OHIP_ERR_DTL_SERV_SS.Value = 5;
                }
                else
                {
                    X_OHIP_ERR_DTL_SERV_SS.Value = 0;
                }
                if (QDesign.NULL(X_OHIP_ERR_HDR_ELIG_SS.Value) == 1)
                {
                    X_OHIP_ERR_CODE_HDR_THIS_REC.Value = fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_1");
                }
                else if (QDesign.NULL(X_OHIP_ERR_HDR_ELIG_SS.Value) == 2)
                {
                    X_OHIP_ERR_CODE_HDR_THIS_REC.Value = fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_2");
                }
                else if (QDesign.NULL(X_OHIP_ERR_HDR_ELIG_SS.Value) == 3)
                {
                    X_OHIP_ERR_CODE_HDR_THIS_REC.Value = fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_3");
                }
                else if (QDesign.NULL(X_OHIP_ERR_HDR_ELIG_SS.Value) == 4)
                {
                    X_OHIP_ERR_CODE_HDR_THIS_REC.Value = fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_4");
                }
                else if (QDesign.NULL(X_OHIP_ERR_HDR_ELIG_SS.Value) == 5)
                {
                    X_OHIP_ERR_CODE_HDR_THIS_REC.Value = fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_5");
                }
                else if (QDesign.NULL(X_OHIP_ERR_HDR_SERV_SS.Value) == 1)
                {
                    X_OHIP_ERR_CODE_HDR_THIS_REC.Value = fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_1");
                }
                else if (QDesign.NULL(X_OHIP_ERR_HDR_SERV_SS.Value) == 2)
                {
                    X_OHIP_ERR_CODE_HDR_THIS_REC.Value = fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_2");
                }
                else if (QDesign.NULL(X_OHIP_ERR_HDR_SERV_SS.Value) == 3)
                {
                    X_OHIP_ERR_CODE_HDR_THIS_REC.Value = fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_3");
                }
                else if (QDesign.NULL(X_OHIP_ERR_HDR_SERV_SS.Value) == 4)
                {
                    X_OHIP_ERR_CODE_HDR_THIS_REC.Value = fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_4");
                }
                else if (QDesign.NULL(X_OHIP_ERR_HDR_SERV_SS.Value) == 5)
                {
                    X_OHIP_ERR_CODE_HDR_THIS_REC.Value = fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_5");
                }
                else
                {
                    X_OHIP_ERR_CODE_HDR_THIS_REC.Value = " ";
                }
                if (QDesign.NULL(X_OHIP_ERR_HDR_ELIG_SS.Value) > 0)
                {
                    X_OHIP_ERR_CODE_HDR_CAT_THIS_REC.Value = "E";
                }
                else if (QDesign.NULL(X_OHIP_ERR_HDR_SERV_SS.Value) > 0)
                {
                    X_OHIP_ERR_CODE_HDR_CAT_THIS_REC.Value = "S";
                }
                else
                {
                    X_OHIP_ERR_CODE_HDR_CAT_THIS_REC.Value = " ";
                }
                if (QDesign.NULL(X_OHIP_ERR_DTL_ELIG_SS.Value) == 1)
                {
                    X_OHIP_ERR_CODE_DTL_THIS_REC.Value = fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_1");
                }
                else if (QDesign.NULL(X_OHIP_ERR_DTL_ELIG_SS.Value) == 2)
                {
                    X_OHIP_ERR_CODE_DTL_THIS_REC.Value = fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_2");
                }
                else if (QDesign.NULL(X_OHIP_ERR_DTL_ELIG_SS.Value) == 3)
                {
                    X_OHIP_ERR_CODE_DTL_THIS_REC.Value = fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_3");
                }
                else if (QDesign.NULL(X_OHIP_ERR_DTL_ELIG_SS.Value) == 4)
                {
                    X_OHIP_ERR_CODE_DTL_THIS_REC.Value = fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_4");
                }
                else if (QDesign.NULL(X_OHIP_ERR_DTL_ELIG_SS.Value) == 5)
                {
                    X_OHIP_ERR_CODE_DTL_THIS_REC.Value = fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_5");
                }
                else if (QDesign.NULL(X_OHIP_ERR_DTL_SERV_SS.Value) == 1)
                {
                    X_OHIP_ERR_CODE_DTL_THIS_REC.Value = fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_1");
                }
                else if (QDesign.NULL(X_OHIP_ERR_DTL_SERV_SS.Value) == 2)
                {
                    X_OHIP_ERR_CODE_DTL_THIS_REC.Value = fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_2");
                }
                else if (QDesign.NULL(X_OHIP_ERR_DTL_SERV_SS.Value) == 3)
                {
                    X_OHIP_ERR_CODE_DTL_THIS_REC.Value = fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_3");
                }
                else if (QDesign.NULL(X_OHIP_ERR_DTL_SERV_SS.Value) == 4)
                {
                    X_OHIP_ERR_CODE_DTL_THIS_REC.Value = fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_4");
                }
                else if (QDesign.NULL(X_OHIP_ERR_DTL_SERV_SS.Value) == 5)
                {
                    X_OHIP_ERR_CODE_DTL_THIS_REC.Value = fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_5");
                }
                else
                {
                    X_OHIP_ERR_CODE_DTL_THIS_REC.Value = " ";
                }
                if (QDesign.NULL(X_OHIP_ERR_DTL_ELIG_SS.Value) > 0)
                {
                    X_OHIP_ERR_CODE_DTL_CAT_THIS_REC.Value = "E";
                }
                else if (QDesign.NULL(X_OHIP_ERR_DTL_SERV_SS.Value) > 0)
                {
                    X_OHIP_ERR_CODE_DTL_CAT_THIS_REC.Value = "S";
                }
                else
                {
                    X_OHIP_ERR_CODE_DTL_CAT_THIS_REC.Value = " ";
                }
                if (QDesign.NULL(X_OHIP_ERR_CODE_HDR_CLAIM.Value) == QDesign.NULL(" ") | (QDesign.NULL(X_OHIP_ERR_CODE_HDR_CAT_CLAIM.Value) == QDesign.NULL("S") & QDesign.NULL(X_OHIP_ERR_CODE_HDR_CAT_THIS_REC.Value) == QDesign.NULL("E")))
                {
                    X_HDR_CODE_GOING_TO_BE_CHANGED.Value = "Y";
                }
                else
                {
                    X_HDR_CODE_GOING_TO_BE_CHANGED.Value = "N";
                }
                if (QDesign.NULL(X_OHIP_ERR_CODE_DTL_CLAIM.Value) == QDesign.NULL(" ") | (QDesign.NULL(X_OHIP_ERR_CODE_DTL_CAT_CLAIM.Value) == QDesign.NULL("S") & QDesign.NULL(X_OHIP_ERR_CODE_DTL_CAT_THIS_REC.Value) == QDesign.NULL("E")))
                {
                    X_DTL_CODE_GOING_TO_BE_CHANGED.Value = "Y";
                }
                else
                {
                    X_DTL_CODE_GOING_TO_BE_CHANGED.Value = "N";
                }
                if (QDesign.NULL(X_HDR_CODE_GOING_TO_BE_CHANGED.Value) == QDesign.NULL("Y"))
                {
                    X_OHIP_ERR_CODE_HDR_CAT_CLAIM.Value = X_OHIP_ERR_CODE_HDR_CAT_THIS_REC.Value;
                }
                if (QDesign.NULL(X_DTL_CODE_GOING_TO_BE_CHANGED.Value) == QDesign.NULL("Y"))
                {
                    X_OHIP_ERR_CODE_DTL_CAT_CLAIM.Value = X_OHIP_ERR_CODE_DTL_CAT_THIS_REC.Value;
                }
                if (QDesign.NULL(X_HDR_CODE_GOING_TO_BE_CHANGED.Value) == QDesign.NULL("Y"))
                {
                    X_OHIP_ERR_CODE_HDR_CLAIM.Value = X_OHIP_ERR_CODE_HDR_THIS_REC.Value;
                }
                if (QDesign.NULL(X_DTL_CODE_GOING_TO_BE_CHANGED.Value) == QDesign.NULL("Y"))
                {
                    X_OHIP_ERR_CODE_DTL_CLAIM.Value = X_OHIP_ERR_CODE_DTL_THIS_REC.Value;
                }
                if (QDesign.NULL(X_OHIP_ERR_DTL_SERV_SS.Value) == 1)
                {
                    X_OHIP_ERR_CODE_DTL_SERV_THIS_REC.Value = fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_1");
                }
                else if (QDesign.NULL(X_OHIP_ERR_DTL_SERV_SS.Value) == 2)
                {
                    X_OHIP_ERR_CODE_DTL_SERV_THIS_REC.Value = fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_2");
                }
                else if (QDesign.NULL(X_OHIP_ERR_DTL_SERV_SS.Value) == 3)
                {
                    X_OHIP_ERR_CODE_DTL_SERV_THIS_REC.Value = fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_3");
                }
                else if (QDesign.NULL(X_OHIP_ERR_DTL_SERV_SS.Value) == 4)
                {
                    X_OHIP_ERR_CODE_DTL_SERV_THIS_REC.Value = fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_4");
                }
                else if (QDesign.NULL(X_OHIP_ERR_DTL_SERV_SS.Value) == 5)
                {
                    X_OHIP_ERR_CODE_DTL_SERV_THIS_REC.Value = fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_5");
                }
                else
                {
                    X_OHIP_ERR_CODE_DTL_SERV_THIS_REC.Value = X_OHIP_ERR_CODE_DTL_SERV_THIS_REC.Value;
                }
                if (QDesign.NULL(X_OHIP_ERR_HDR_SERV_SS.Value) == 1)
                {
                    X_OHIP_ERR_CODE_HDR_SERV_THIS_REC.Value = fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_1");
                }
                else if (QDesign.NULL(X_OHIP_ERR_HDR_SERV_SS.Value) == 2)
                {
                    X_OHIP_ERR_CODE_HDR_SERV_THIS_REC.Value = fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_2");
                }
                else if (QDesign.NULL(X_OHIP_ERR_HDR_SERV_SS.Value) == 3)
                {
                    X_OHIP_ERR_CODE_HDR_SERV_THIS_REC.Value = fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_3");
                }
                else if (QDesign.NULL(X_OHIP_ERR_HDR_SERV_SS.Value) == 4)
                {
                    X_OHIP_ERR_CODE_HDR_SERV_THIS_REC.Value = fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_4");
                }
                else if (QDesign.NULL(X_OHIP_ERR_HDR_SERV_SS.Value) == 5)
                {
                    X_OHIP_ERR_CODE_HDR_SERV_THIS_REC.Value = fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_5");
                }
                else
                {
                    X_OHIP_ERR_CODE_HDR_SERV_THIS_REC.Value = " ";
                }
                if (QDesign.NULL(X_OHIP_ERR_CODE_HDR_SERV_CLAIM.Value) == QDesign.NULL(" "))
                {
                    X_OHIP_ERR_CODE_HDR_SERV_CLAIM.Value = X_OHIP_ERR_CODE_HDR_SERV_THIS_REC.Value;
                }
                if (QDesign.NULL(X_OHIP_ERR_CODE_DTL_SERV_CLAIM.Value) == QDesign.NULL(" "))
                {
                    X_OHIP_ERR_CODE_DTL_SERV_CLAIM.Value = X_OHIP_ERR_CODE_DTL_SERV_THIS_REC.Value;
                }
                if (QDesign.NULL(X_OHIP_ERR_CODE_HDR_CLAIM.Value) != QDesign.NULL(" ") & (QDesign.NULL(X_OHIP_ERR_CODE_HDR_CAT_CLAIM.Value) == QDesign.NULL("E") | QDesign.NULL(X_OHIP_ERR_CODE_DTL_CAT_CLAIM.Value) == QDesign.NULL("S")))
                {
                    X_OHIP_ERR_CODE_FINAL.Value = X_OHIP_ERR_CODE_HDR_CLAIM.Value;
                }
                else if (QDesign.NULL(X_OHIP_ERR_CODE_HDR_CLAIM.Value) != QDesign.NULL(" ") & (QDesign.NULL(X_OHIP_ERR_CODE_HDR_CAT_CLAIM.Value) == QDesign.NULL("S")))
                {
                    X_OHIP_ERR_CODE_FINAL.Value = X_OHIP_ERR_CODE_HDR_CLAIM.Value;
                }
                else if (QDesign.NULL(X_OHIP_ERR_CODE_DTL_CLAIM.Value) != QDesign.NULL(" "))
                {
                    X_OHIP_ERR_CODE_FINAL.Value = X_OHIP_ERR_CODE_DTL_CLAIM.Value;
                }
                else
                {
                    X_OHIP_ERR_CODE_FINAL.Value = " ";
                }
                if (QDesign.NULL(X_OHIP_ERR_CODE_HDR_CAT_CLAIM.Value) != QDesign.NULL(" ") & (QDesign.NULL(X_OHIP_ERR_CODE_HDR_CAT_CLAIM.Value) == QDesign.NULL("E") | QDesign.NULL(X_OHIP_ERR_CODE_DTL_CAT_CLAIM.Value) == QDesign.NULL("S")))
                {
                    X_OHIP_ERR_CODE_FINAL_CAT.Value = X_OHIP_ERR_CODE_HDR_CAT_CLAIM.Value;
                }
                else if (QDesign.NULL(X_OHIP_ERR_CODE_HDR_CAT_CLAIM.Value) != QDesign.NULL(" ") & (QDesign.NULL(X_OHIP_ERR_CODE_HDR_CAT_CLAIM.Value) == QDesign.NULL("S")))
                {
                    X_OHIP_ERR_CODE_FINAL_CAT.Value = X_OHIP_ERR_CODE_HDR_CAT_CLAIM.Value;
                }
                else if (QDesign.NULL(X_OHIP_ERR_CODE_DTL_CAT_CLAIM.Value) != QDesign.NULL(" "))
                {
                    X_OHIP_ERR_CODE_FINAL_CAT.Value = X_OHIP_ERR_CODE_DTL_CAT_CLAIM.Value;
                }
                else
                {
                    X_OHIP_ERR_CODE_FINAL_CAT.Value = " ";
                }

                // GW2019. Added for parent/child
                string pat_birth_date = QDesign.NULL(fleF010_PAT_MSTR.GetNumericDateValue("PAT_BIRTH_DATE_YY")).ToString().PadLeft(4, '0') +
                    QDesign.NULL(fleF010_PAT_MSTR.GetNumericDateValue("PAT_BIRTH_DATE_MM")).ToString().PadLeft(2, '0') +
                    QDesign.NULL(fleF010_PAT_MSTR.GetNumericDateValue("PAT_BIRTH_DATE_DD")).ToString().PadLeft(2, '0');
                string rmb_birth_date = QDesign.NULL(fleU021A.GetNumericDateValue("RAT_RMB_BIRTH_DATE")).ToString();

                //if ((QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("PAT_VERSION_CD")) != QDesign.NULL(fleU021A.GetStringValue("RAT_RMB_VERSION_CD")) & (QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) == QDesign.NULL("EH2") | QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) == QDesign.NULL("VH4"))) | (QDesign.NULL(fleF010_PAT_MSTR.GetNumericDateValue("PAT_BIRTH_DATE")) != QDesign.NULL(fleU021A.GetNumericDateValue("RAT_RMB_BIRTH_DATE")) & (QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) == QDesign.NULL("VH8"))))
                if ((QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("PAT_VERSION_CD")) != 
                       QDesign.NULL(fleU021A.GetStringValue("RAT_RMB_VERSION_CD")) 
                    & (QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) == QDesign.NULL("EH2") 
                    | QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) == QDesign.NULL("VH4"))) 
                    | (!pat_birth_date.Equals(rmb_birth_date)
                    & (QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) == QDesign.NULL("VH8"))))
                { 
                    X_F002_CLAIM_STATUS.Value = "X";
                }

                else if (QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) != QDesign.NULL(" "))
                {
                    X_F002_CLAIM_STATUS.Value = "H";
                }
                else
                {
                    X_F002_CLAIM_STATUS.Value = " ";
                }
                REC_COUNTER.Value = REC_COUNTER.Value + 1;

                fleF087_DTL_ADD.OutPut(OutPutType.Add);

                fleF087_HDR_ADD.OutPut(OutPutType.Add, fleU021A.At("RAT_RMB_ACCOUNT_NBR"), 1 == 1);

                fleF002_CLAIMS_MSTR.OutPut(OutPutType.Update, fleU021A.At("RAT_RMB_ACCOUNT_NBR"), fleF002_CLAIMS_MSTR.Exists() & 1 == 1);
                //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART)    'Parent:KEY_PAT_MSTR)    'Parent:PAT_BIRTH_DATE)    'Parent:CLMHDR_PAT_OHIP_ID_OR_CHART)    'Parent:PAT_BIRTH_DATE)    'Parent:KEY_PAT_MSTR

                fleREJECTED_CLAIMS.OutPut(OutPutType.Add, fleU021A.At("RAT_RMB_ACCOUNT_NBR"), QDesign.NULL(X_F002_CLAIM_STATUS.Value) == QDesign.NULL("H") & 1 == 1);
                //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART)    'Parent:KEY_PAT_MSTR)    'Parent:PAT_BIRTH_DATE)    'Parent:CLMHDR_PAT_OHIP_ID_OR_CHART)    'Parent:PAT_BIRTH_DATE)    'Parent:KEY_PAT_MSTR

                fleMOH_OBEC.OutPut(OutPutType.Add, fleU021A.At("RAT_RMB_ACCOUNT_NBR"), 1 == 1);
                //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART)    'Parent:KEY_PAT_MSTR)    'Parent:PAT_BIRTH_DATE)    'Parent:CLMHDR_PAT_OHIP_ID_OR_CHART)    'Parent:PAT_BIRTH_DATE)    'Parent:KEY_PAT_MSTR

                fleF010_PAT_MSTR.OutPut(OutPutType.Update, fleU021A.At("RAT_RMB_ACCOUNT_NBR"), (QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) == QDesign.NULL("EH1") | QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) == QDesign.NULL("EH2") | QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) == QDesign.NULL("EH4") | QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) == QDesign.NULL("EH5") | QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) == QDesign.NULL("VH4") | QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) == QDesign.NULL("VH8") | QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) == QDesign.NULL("VH9")) & fleF010_PAT_MSTR.Exists() & QDesign.NULL(X_F002_CLAIM_STATUS.Value) == QDesign.NULL("H") & 1 == 1);
                //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART)    'Parent:KEY_PAT_MSTR)    'Parent:PAT_BIRTH_DATE)    'Parent:CLMHDR_PAT_OHIP_ID_OR_CHART)    'Parent:PAT_BIRTH_DATE)    'Parent:KEY_PAT_MSTR

                SubFile(ref m_trnTRANS_UPDATE, ref fleU021F_F002_AUDIT, fleU021A.At("RAT_RMB_ACCOUNT_NBR"), SubFileType.Keep, RUN_DATE, RUN_TIME, fleU021A, "RAT_RMB_FILE_NAME", "RAT_RMB_ACCOUNT_NBR", X_OHIP_ERR_CODE_HDR_CAT_CLAIM,
                X_OHIP_ERR_CODE_DTL_CAT_CLAIM, X_OHIP_ERR_CODE_HDR_CLAIM, X_OHIP_ERR_CODE_DTL_CLAIM, X_OHIP_ERR_CODE_HDR_SERV_CLAIM, X_OHIP_ERR_CODE_DTL_SERV_CLAIM, X_OHIP_ERR_CODE_FINAL, X_OHIP_ERR_CODE_FINAL_CAT, fleF002_CLAIMS_MSTR, "CLMHDR_ELIG_STATUS", "CLMHDR_TAPE_SUBMIT_IND");
                //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART)    'Parent:KEY_PAT_MSTR)    'Parent:PAT_BIRTH_DATE)    'Parent:CLMHDR_PAT_OHIP_ID_OR_CHART)    'Parent:PAT_BIRTH_DATE)    'Parent:KEY_PAT_MSTR

                SubFile(ref m_trnTRANS_UPDATE, ref fleU021F_F010_AUDIT, fleU021A.At("RAT_RMB_ACCOUNT_NBR"), (QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) == QDesign.NULL("EH1") | QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) == QDesign.NULL("EH2") | QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) == QDesign.NULL("EH4") | QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) == QDesign.NULL("EH5") | QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) == QDesign.NULL("VH4") | QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) == QDesign.NULL("VH8") | QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) == QDesign.NULL("VH9")), SubFileType.Keep, RUN_DATE, RUN_TIME, fleU021A, "RAT_RMB_FILE_NAME", "RAT_RMB_ACCOUNT_NBR",
                X_OHIP_ERR_CODE_HDR_CAT_CLAIM, X_OHIP_ERR_CODE_DTL_CAT_CLAIM, X_OHIP_ERR_CODE_HDR_CLAIM, X_OHIP_ERR_CODE_DTL_CLAIM, X_OHIP_ERR_CODE_HDR_SERV_CLAIM, X_OHIP_ERR_CODE_DTL_SERV_CLAIM, X_OHIP_ERR_CODE_FINAL, X_OHIP_ERR_CODE_FINAL_CAT, fleF010_PAT_MSTR, "PAT_OHIP_VALIDATION_STATUS",
                "PAT_OBEC_STATUS");
                //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART)    'Parent:KEY_PAT_MSTR)    'Parent:PAT_BIRTH_DATE)    'Parent:CLMHDR_PAT_OHIP_ID_OR_CHART)    'Parent:PAT_BIRTH_DATE)    'Parent:KEY_PAT_MSTR

                // SubFile(ref m_trnTRANS_UPDATE, ref fleU021F_DEBUG_GW, SubFileType.Keep, fleU021A, X_F002_CLAIM_STATUS);

                SubFile(ref m_trnTRANS_UPDATE, ref fleU021F_DEBUG, SubFileType.Keep, fleU021A, "RAT_RMB_FILE_NAME", "RAT_RMB_ACCOUNT_NBR", X_OHIP_ERR_HDR_ELIG_SS, X_OHIP_ERR_HDR_SERV_SS, X_OHIP_ERR_DTL_ELIG_SS, X_OHIP_ERR_DTL_SERV_SS,
                X_OHIP_ERR_CODE_HDR_THIS_REC, X_OHIP_ERR_CODE_HDR_CAT_THIS_REC, X_OHIP_ERR_CODE_DTL_THIS_REC, X_OHIP_ERR_CODE_DTL_CAT_THIS_REC, X_OHIP_ERR_CODE_HDR_CLAIM, X_OHIP_ERR_CODE_DTL_CAT_CLAIM, X_OHIP_ERR_CODE_HDR_CAT_CLAIM, X_OHIP_ERR_CODE_DTL_CLAIM, X_HDR_CODE_GOING_TO_BE_CHANGED, X_DTL_CODE_GOING_TO_BE_CHANGED,
                X_OHIP_ERR_CODE_HDR_SERV_THIS_REC, X_OHIP_ERR_CODE_DTL_SERV_THIS_REC, X_OHIP_ERR_CODE_HDR_SERV_CLAIM, X_OHIP_ERR_CODE_DTL_SERV_CLAIM, X_OHIP_ERR_CODE_FINAL, X_OHIP_ERR_CODE_FINAL_CAT);
                //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART)    'Parent:KEY_PAT_MSTR)    'Parent:PAT_BIRTH_DATE)    'Parent:CLMHDR_PAT_OHIP_ID_OR_CHART)    'Parent:PAT_BIRTH_DATE)    'Parent:KEY_PAT_MSTR

                Reset(ref X_OHIP_ERR_CODE_HDR_CAT_CLAIM, fleU021A.At("RAT_RMB_ACCOUNT_NBR"));
                Reset(ref X_OHIP_ERR_CODE_DTL_CAT_CLAIM, fleU021A.At("RAT_RMB_ACCOUNT_NBR"));
                Reset(ref X_OHIP_ERR_CODE_HDR_CLAIM, fleU021A.At("RAT_RMB_ACCOUNT_NBR"));
                Reset(ref X_OHIP_ERR_CODE_DTL_CLAIM, fleU021A.At("RAT_RMB_ACCOUNT_NBR"));
                Reset(ref X_OHIP_ERR_CODE_DTL_SERV_THIS_REC, fleU021A.At("RAT_RMB_ACCOUNT_NBR"));
                Reset(ref X_OHIP_ERR_CODE_HDR_SERV_CLAIM, fleU021A.At("RAT_RMB_ACCOUNT_NBR"));
                Reset(ref X_OHIP_ERR_CODE_DTL_SERV_CLAIM, fleU021A.At("RAT_RMB_ACCOUNT_NBR"));
                Reset(ref REC_COUNTER, fleU021A.At("RAT_RMB_ACCOUNT_NBR"));

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
            EndRequest("PROCESS_SUBMIT_ERRORS_1");

        }

    }




    #endregion


}
//PROCESS_SUBMIT_ERRORS_1



public class U021F_PROCESS_RMB_SUBMIT_ERRORS_2 : U021F
{

    public U021F_PROCESS_RMB_SUBMIT_ERRORS_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU021A = new SqlFileObject(this, FileTypes.Primary, 0, "SEQUENTIAL", "U021A_EDT_RMB_FILE", "U021A", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF010_PAT_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F010_PAT_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleICONST_MSTR_REC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "ICONST_MSTR_REC", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF093_HDR_1 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F093_OHIP_ERROR_MSG_MSTR", "F093_HDR_1", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF093_HDR_2 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F093_OHIP_ERROR_MSG_MSTR", "F093_HDR_2", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF093_HDR_3 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F093_OHIP_ERROR_MSG_MSTR", "F093_HDR_3", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF093_HDR_4 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F093_OHIP_ERROR_MSG_MSTR", "F093_HDR_4", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF093_HDR_5 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F093_OHIP_ERROR_MSG_MSTR", "F093_HDR_5", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF093_DTL_1 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F093_OHIP_ERROR_MSG_MSTR", "F093_DTL_1", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF093_DTL_2 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F093_OHIP_ERROR_MSG_MSTR", "F093_DTL_2", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF093_DTL_3 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F093_OHIP_ERROR_MSG_MSTR", "F093_DTL_3", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF093_DTL_4 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F093_OHIP_ERROR_MSG_MSTR", "F093_DTL_4", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF093_DTL_5 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F093_OHIP_ERROR_MSG_MSTR", "F093_DTL_5", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_CHARGE_STATUS = new CoreCharacter("X_CHARGE_STATUS", 1, this, Common.cEmptyString);
        X_OHIP_ERR_HDR_ELIG_SS = new CoreDecimal("X_OHIP_ERR_HDR_ELIG_SS", 6, this);
        X_OHIP_ERR_HDR_SERV_SS = new CoreDecimal("X_OHIP_ERR_HDR_SERV_SS", 6, this);
        X_OHIP_ERR_DTL_ELIG_SS = new CoreDecimal("X_OHIP_ERR_DTL_ELIG_SS", 6, this);
        X_OHIP_ERR_DTL_SERV_SS = new CoreDecimal("X_OHIP_ERR_DTL_SERV_SS", 6, this);
        X_OHIP_ERR_CODE_HDR_THIS_REC = new CoreCharacter("X_OHIP_ERR_CODE_HDR_THIS_REC", 3, this, Common.cEmptyString);
        X_OHIP_ERR_CODE_HDR_CAT_THIS_REC = new CoreCharacter("X_OHIP_ERR_CODE_HDR_CAT_THIS_REC", 1, this, Common.cEmptyString);
        X_OHIP_ERR_CODE_DTL_THIS_REC = new CoreCharacter("X_OHIP_ERR_CODE_DTL_THIS_REC", 3, this, Common.cEmptyString);
        X_OHIP_ERR_CODE_DTL_CAT_THIS_REC = new CoreCharacter("X_OHIP_ERR_CODE_DTL_CAT_THIS_REC", 1, this, Common.cEmptyString);
        X_OHIP_ERR_CODE_HDR_CLAIM = new CoreCharacter("X_OHIP_ERR_CODE_HDR_CLAIM", 3, this, Common.cEmptyString);
        X_OHIP_ERR_CODE_DTL_CAT_CLAIM = new CoreCharacter("X_OHIP_ERR_CODE_DTL_CAT_CLAIM", 1, this, Common.cEmptyString);
        X_OHIP_ERR_CODE_HDR_CAT_CLAIM = new CoreCharacter("X_OHIP_ERR_CODE_HDR_CAT_CLAIM", 1, this, Common.cEmptyString);
        X_OHIP_ERR_CODE_DTL_CLAIM = new CoreCharacter("X_OHIP_ERR_CODE_DTL_CLAIM", 3, this, Common.cEmptyString);
        X_HDR_CODE_GOING_TO_BE_CHANGED = new CoreCharacter("X_HDR_CODE_GOING_TO_BE_CHANGED", 1, this, Common.cEmptyString);
        X_DTL_CODE_GOING_TO_BE_CHANGED = new CoreCharacter("X_DTL_CODE_GOING_TO_BE_CHANGED", 1, this, Common.cEmptyString);
        X_OHIP_ERR_CODE_DTL_SERV_THIS_REC = new CoreCharacter("X_OHIP_ERR_CODE_DTL_SERV_THIS_REC", 3, this, Common.cEmptyString);
        X_OHIP_ERR_CODE_HDR_SERV_THIS_REC = new CoreCharacter("X_OHIP_ERR_CODE_HDR_SERV_THIS_REC", 3, this, Common.cEmptyString);
        X_OHIP_ERR_CODE_HDR_SERV_CLAIM = new CoreCharacter("X_OHIP_ERR_CODE_HDR_SERV_CLAIM", 3, this, Common.cEmptyString);
        X_OHIP_ERR_CODE_DTL_SERV_CLAIM = new CoreCharacter("X_OHIP_ERR_CODE_DTL_SERV_CLAIM", 3, this, Common.cEmptyString);
        X_OHIP_ERR_CODE_FINAL = new CoreCharacter("X_OHIP_ERR_CODE_FINAL", 3, this, Common.cEmptyString);
        X_OHIP_ERR_CODE_FINAL_CAT = new CoreCharacter("X_OHIP_ERR_CODE_FINAL_CAT", 1, this, Common.cEmptyString);
        X_F002_CLAIM_STATUS = new CoreCharacter("X_F002_CLAIM_STATUS", 1, this, Common.cEmptyString);
        REC_COUNTER = new CoreDecimal("REC_COUNTER", 6, this);
        fleF087_DTL_ADD = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F087_SUBMITTED_REJECTED_CLAIMS_DTL", "F087_DTL_ADD", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF087_HDR_ADD = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F087_SUBMITTED_REJECTED_CLAIMS_HDR", "F087_HDR_ADD", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_UPDATE = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "F002_UPDATE", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleREJECTED_CLAIMS = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "REJECTED_CLAIMS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleMOH_OBEC = new SqlFileObject(this, FileTypes.Primary, 0, "SEQUENTIAL", "MOH_OBEC", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF010_UPDATE = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F010_PAT_MSTR", "F010_UPDATE", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleU021F_F002_AUDIT = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U021F_F002_AUDIT", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU021F_F010_AUDIT = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U021F_F010_AUDIT", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU021F_DEBUG = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U021F_DEBUG", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_BAL_DUE.GetValue += X_BAL_DUE_GetValue;
        X_PED.GetValue += X_PED_GetValue;
        X_NO_CHARGE_REJ_CODE.GetValue += X_NO_CHARGE_REJ_CODE_GetValue;
        RUN_DATE.GetValue += RUN_DATE_GetValue;
        RUN_TIME.GetValue += RUN_TIME_GetValue;

        // GW2019. Mar 10, Added
        fleF087_DTL_ADD.SetItemFinals += fleF087_DTL_ADD_SetItemFinals;
        fleF087_HDR_ADD.SetItemFinals += fleF087_HDR_ADD_SetItemFinals;
        fleREJECTED_CLAIMS.SetItemFinals += fleREJECTED_CLAIMS_SetItemFinals;
        fleMOH_OBEC.SetItemFinals += fleMOH_OBEC_SetItemFinals;
    }

    // GW2019. Mar 10, Added
    private void fleF087_DTL_ADD_SetItemFinals()
    {

        try
        {
            fleF087_DTL_ADD.set_SetValue("CLMHDR_BATCH_NBR", (fleU021A.GetStringValue("RAT_RMB_GROUP_NBR").Substring(0, 2)) + fleU021A.GetStringValue("RAT_RMB_ACCOUNT_NBR").Substring(0, 6));
            fleF087_DTL_ADD.set_SetValue("CLMHDR_CLAIM_NBR", fleU021A.GetStringValue("RAT_RMB_ACCOUNT_NBR").Substring(6, 2));
            fleF087_DTL_ADD.set_SetValue("PED", X_PED.Value);
            fleF087_DTL_ADD.set_SetValue("EDT_PROCESS_DATE", fleU021A.GetDecimalValue("RAT_RMB_PROCESS_DATE"));
            fleF087_DTL_ADD.set_SetValue("KEY_DTL_SEQ_NBR", REC_COUNTER.Value);

            fleF087_DTL_ADD.set_SetValue("EDT_OMA_SERVICE_CD_AND_SUFFIX", fleU021A.GetStringValue("RAT_RMB_SERVICE_CD"));
            fleF087_DTL_ADD.set_SetValue("EDT_SERVICE_DATE", fleU021A.GetDecimalValue("RAT_RMB_SERVICE_DATE"));
            fleF087_DTL_ADD.set_SetValue("EDT_DTL_DIAG_CD", fleU021A.GetStringValue("RAT_RMB_DIAG_CD"));
            fleF087_DTL_ADD.set_SetValue("EDT_NBR_SERV", fleU021A.GetDecimalValue("RAT_RMB_NBR_OF_SERV"));
            fleF087_DTL_ADD.set_SetValue("EDT_AMOUNT_SUBMITTED", fleU021A.GetDecimalValue("RAT_RMB_AMOUNT_SUB"));
            fleF087_DTL_ADD.set_SetValue("EDT_DTL_ERR_EXPLAN_CD", fleU021A.GetStringValue("RAT_RMB_T_EXPLAN_CD"));
            fleF087_DTL_ADD.set_SetValue("EDT_DTL_ERR_CD_1", fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_1"));
            fleF087_DTL_ADD.set_SetValue("EDT_DTL_ERR_CD_2", fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_2"));
            fleF087_DTL_ADD.set_SetValue("EDT_DTL_ERR_CD_3", fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_3"));
            fleF087_DTL_ADD.set_SetValue("EDT_DTL_ERR_CD_4", fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_4"));
            fleF087_DTL_ADD.set_SetValue("EDT_DTL_ERR_CD_5", fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_5"));
            fleF087_DTL_ADD.set_SetValue("EDT_DTL_ERR_8_EXPLAN_CD", fleU021A.GetStringValue("RAT_RMB_8_EXPLAN_CD"));
            fleF087_DTL_ADD.set_SetValue("EDT_DTL_ERR_8_EXPLAN_DESC", fleU021A.GetStringValue("RAT_RMB_8_EXPLAN_DESC"));

            fleF087_DTL_ADD.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));
            fleF087_DTL_ADD.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);
            fleF087_DTL_ADD.set_SetValue("LAST_MOD_USER_ID", "u021f gen`d");
        }
        catch (CustomApplicationException ex)
        {
            WriteError(ex);
        }
        catch (Exception ex)
        {
            WriteError(ex);
        }
    }

    // GW2019. Mar 10, Added
    private void fleF087_HDR_ADD_SetItemFinals()
    {

        try
        {
            fleF087_HDR_ADD.set_SetValue("CLMHDR_BATCH_NBR", (fleU021A.GetStringValue("RAT_RMB_GROUP_NBR").Substring(0, 2)) + fleU021A.GetStringValue("RAT_RMB_ACCOUNT_NBR").Substring(0, 6));
            fleF087_HDR_ADD.set_SetValue("CLMHDR_CLAIM_NBR", fleU021A.GetStringValue("RAT_RMB_ACCOUNT_NBR").Substring(6, 2));
            fleF087_HDR_ADD.set_SetValue("CLMHDR_DOC_NBR", fleU021A.GetStringValue("RAT_RMB_ACCOUNT_NBR").Substring(0, 3));
            fleF087_HDR_ADD.set_SetValue("PED", X_PED.Value);
            fleF087_HDR_ADD.set_SetValue("EDT_PROCESS_DATE", fleU021A.GetDecimalValue("RAT_RMB_PROCESS_DATE"));

            fleF087_HDR_ADD.set_SetValue("EDT_HEALTH_NBR", fleU021A.GetStringValue("RAT_RMB_HEALTH_NBR"));
            fleF087_HDR_ADD.set_SetValue("EDT_HEALTH_VERSION_CD", fleU021A.GetStringValue("RAT_RMB_VERSION_CD"));
            fleF087_HDR_ADD.set_SetValue("EDT_PAT_BIRTH_DATE", fleU021A.GetDecimalValue("RAT_RMB_BIRTH_DATE"));
            fleF087_HDR_ADD.set_SetValue("EDT_ACCOUNT_NBR", fleU021A.GetStringValue("RAT_RMB_ACCOUNT_NBR"));
            fleF087_HDR_ADD.set_SetValue("EDT_PAY_PROG", fleU021A.GetStringValue("RAT_RMB_PAY_PROG"));
            fleF087_HDR_ADD.set_SetValue("EDT_PAYEE", fleU021A.GetStringValue("RAT_RMB_PAYEE"));
            fleF087_HDR_ADD.set_SetValue("EFT_REFERRING_DOC_NBR", fleU021A.GetDecimalValue("RAT_RMB_REFER_DOC_NBR"));
            fleF087_HDR_ADD.set_SetValue("EDT_FACILITY_NBR", fleU021A.GetStringValue("RAT_RMB_FACILITY_NBR"));
            fleF087_HDR_ADD.set_SetValue("EDT_ADMIT_DATE", fleU021A.GetDecimalValue("RAT_RMB_ADMIT_DATE"));
            fleF087_HDR_ADD.set_SetValue("EDT_LOCATION_CD", fleU021A.GetStringValue("RAT_RMB_LOC_CD"));
            fleF087_HDR_ADD.set_SetValue("OHIP_ERR_CODE", X_OHIP_ERR_CODE_FINAL.Value);
            fleF087_HDR_ADD.set_SetValue("EDT_ERR_H_CD_1", fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_1"));
            fleF087_HDR_ADD.set_SetValue("EDT_ERR_H_CD_2", fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_2"));
            fleF087_HDR_ADD.set_SetValue("EDT_ERR_H_CD_3", fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_3"));
            fleF087_HDR_ADD.set_SetValue("EDT_ERR_H_CD_4", fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_4"));
            fleF087_HDR_ADD.set_SetValue("EDT_ERR_H_CD_5", fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_5"));
            // fleF087_HDR_ADD.set_SetValue("CHARGE_STATUS", fleU021A.GetDecimalValue("'N' IF X_NO_CHARGE_REJ_CODE = 'Y'    &  ELSE  "Y"

            fleF087_HDR_ADD.set_SetValue("ENTRY_DATE", QDesign.SysDate(ref m_cnnQUERY));
            fleF087_HDR_ADD.set_SetValue("ENTRY_TIME_LONG", QDesign.SysTime(ref m_cnnQUERY) / 10000);
            fleF087_HDR_ADD.set_SetValue("ENTRY_USER_ID", "u021f gen`d");

            fleF087_HDR_ADD.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));
            fleF087_HDR_ADD.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);
            fleF087_HDR_ADD.set_SetValue("LAST_MOD_USER_ID", "u021f gen`d");
        }
        catch (CustomApplicationException ex)
        {
            WriteError(ex);
        }
        catch (Exception ex)
        {
            WriteError(ex);
        }

    }

    // GW2019. Mar 10, Added
    private void fleREJECTED_CLAIMS_SetItemFinals()
    {
        try
        {
            fleREJECTED_CLAIMS.set_SetValue("CLAIM_NBR", (fleU021A.GetStringValue("RAT_RMB_GROUP_NBR").Substring(0, 2)) + fleU021A.GetStringValue("RAT_RMB_ACCOUNT_NBR"));
            fleREJECTED_CLAIMS.set_SetValue("DOC_NBR", fleU021A.GetStringValue("RAT_RMB_ACCOUNT_NBR").Substring(0, 3));
            fleREJECTED_CLAIMS.set_SetValue("CLMHDR_PAT_OHIP_ID_OR_CHART", fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_TYPE") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_DATA"));
            fleREJECTED_CLAIMS.set_SetValue("CLMHDR_LOC", fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_LOC"));
            fleREJECTED_CLAIMS.set_SetValue("MESS_CODE", X_OHIP_ERR_CODE_FINAL.Value);
            fleREJECTED_CLAIMS.set_SetValue("CLMHDR_SUBMIT_DATE", 0);
        }
        catch (CustomApplicationException ex)
        {
            WriteError(ex);
        }
        catch (Exception ex)
        {
            WriteError(ex);
        }
    }

    // GW2019. Mar 10, Added
    private void fleMOH_OBEC_SetItemFinals()
    {
        try
        {
            fleMOH_OBEC.set_SetValue("PAT_HEALTH_NBR", fleF010_PAT_MSTR.GetDecimalValue("PAT_HEALTH_NBR"));
            fleMOH_OBEC.set_SetValue("PAT_VERSION_CD", fleF010_PAT_MSTR.GetStringValue("PAT_VERSION_CD"));
            fleMOH_OBEC.set_SetValue("PAT_SEX", fleF010_PAT_MSTR.GetStringValue("PAT_SEX"));
            fleMOH_OBEC.set_SetValue("OBEC_SUBMISSION_ID", " ");
        }
        catch (CustomApplicationException ex)
        {
            WriteError(ex);
        }
        catch (Exception ex)
        {
            WriteError(ex);
        }
    }
    #region "Declarations (Variables, Files and Transactions)(U021F_PROCESS_RMB_SUBMIT_ERRORS_2)"

    private SqlFileObject fleU021A;
    private SqlFileObject fleF020_DOCTOR_MSTR;
    private SqlFileObject fleF002_CLAIMS_MSTR;
    private SqlFileObject fleF010_PAT_MSTR;
    private SqlFileObject fleICONST_MSTR_REC;
    private SqlFileObject fleF093_HDR_1;
    private SqlFileObject fleF093_HDR_2;
    private SqlFileObject fleF093_HDR_3;
    private SqlFileObject fleF093_HDR_4;
    private SqlFileObject fleF093_HDR_5;
    private SqlFileObject fleF093_DTL_1;
    private SqlFileObject fleF093_DTL_2;
    private SqlFileObject fleF093_DTL_3;
    private SqlFileObject fleF093_DTL_4;
    private SqlFileObject fleF093_DTL_5;
    private DDecimal X_BAL_DUE = new DDecimal("X_BAL_DUE", 8);
    private void X_BAL_DUE_GetValue(ref decimal Value)
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
    private DDecimal X_PED = new DDecimal("X_PED");
    private void X_PED_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (fleF002_CLAIMS_MSTR.Exists())
            {
                CurrentValue = fleF002_CLAIMS_MSTR.GetNumericDateValue("CLMHDR_DATE_PERIOD_END");
            }
            else
            {
                CurrentValue = fleU021A.GetNumericDateValue("RAT_RMB_PROCESS_DATE");
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
    private CoreCharacter X_CHARGE_STATUS;
    private CoreDecimal X_OHIP_ERR_HDR_ELIG_SS;
    private CoreDecimal X_OHIP_ERR_HDR_SERV_SS;
    private CoreDecimal X_OHIP_ERR_DTL_ELIG_SS;
    private CoreDecimal X_OHIP_ERR_DTL_SERV_SS;
    private CoreCharacter X_OHIP_ERR_CODE_HDR_THIS_REC;
    private CoreCharacter X_OHIP_ERR_CODE_HDR_CAT_THIS_REC;
    private CoreCharacter X_OHIP_ERR_CODE_DTL_THIS_REC;
    private CoreCharacter X_OHIP_ERR_CODE_DTL_CAT_THIS_REC;
    private CoreCharacter X_OHIP_ERR_CODE_HDR_CLAIM;
    private CoreCharacter X_OHIP_ERR_CODE_DTL_CAT_CLAIM;
    private CoreCharacter X_OHIP_ERR_CODE_HDR_CAT_CLAIM;
    private CoreCharacter X_OHIP_ERR_CODE_DTL_CLAIM;
    private CoreCharacter X_HDR_CODE_GOING_TO_BE_CHANGED;
    private CoreCharacter X_DTL_CODE_GOING_TO_BE_CHANGED;
    private CoreCharacter X_OHIP_ERR_CODE_DTL_SERV_THIS_REC;
    private CoreCharacter X_OHIP_ERR_CODE_HDR_SERV_THIS_REC;
    private CoreCharacter X_OHIP_ERR_CODE_HDR_SERV_CLAIM;
    private CoreCharacter X_OHIP_ERR_CODE_DTL_SERV_CLAIM;
    private CoreCharacter X_OHIP_ERR_CODE_FINAL;
    private CoreCharacter X_OHIP_ERR_CODE_FINAL_CAT;
    private CoreCharacter X_F002_CLAIM_STATUS;
    private DCharacter X_NO_CHARGE_REJ_CODE = new DCharacter("X_NO_CHARGE_REJ_CODE", 1);
    private void X_NO_CHARGE_REJ_CODE_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) == QDesign.NULL("VJ7") | QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) == QDesign.NULL("EQE") | QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) == QDesign.NULL("A4D") | QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) == QDesign.NULL("EQF") | QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) == QDesign.NULL("AC4") | QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) == QDesign.NULL("ARF") | QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) == QDesign.NULL("ERF") | QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) == QDesign.NULL("ESD") | QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) == QDesign.NULL("V28") | QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) == QDesign.NULL("V66") | QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) == QDesign.NULL("VH1") | QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) == QDesign.NULL("EF4") | (string.Compare(X_OHIP_ERR_CODE_FINAL.Value, "EQ1") >= 0 & string.Compare(X_OHIP_ERR_CODE_FINAL.Value, "EQ6") <= 0) | (string.Compare(X_OHIP_ERR_CODE_FINAL.Value, "EQC") >= 0 & string.Compare(X_OHIP_ERR_CODE_FINAL.Value, "EQI") <= 0) | (string.Compare(X_OHIP_ERR_CODE_FINAL.Value, "R01") >= 0 & string.Compare(X_OHIP_ERR_CODE_FINAL.Value, "R09") <= 0) | (string.Compare(X_OHIP_ERR_CODE_FINAL.Value, "V05") >= 0 & string.Compare(X_OHIP_ERR_CODE_FINAL.Value, "V22") <= 0) | (string.Compare(X_OHIP_ERR_CODE_FINAL.Value, "V39") >= 0 & string.Compare(X_OHIP_ERR_CODE_FINAL.Value, "V42") <= 0) | (string.Compare(X_OHIP_ERR_CODE_FINAL.Value, "V51") >= 0 & string.Compare(X_OHIP_ERR_CODE_FINAL.Value, "V62") <= 0) | (QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) == QDesign.NULL("A36") & QDesign.NULL(QDesign.Substring(fleU021A.GetStringValue("RAT_RMB_GROUP_NBR"), 1, 2)) == QDesign.NULL("22") & (QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_DOC_DEPT")) == 41 | QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_DOC_DEPT")) == 42 | QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_DOC_DEPT")) == 43 | QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_DOC_DEPT")) == 75)))
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
    private CoreDecimal REC_COUNTER;
    private DDecimal RUN_DATE = new DDecimal("RUN_DATE");
    private void RUN_DATE_GetValue(ref decimal Value)
    {

        try
        {
            Value = QDesign.SysDate(ref m_cnnQUERY);


        }
        catch (CustomApplicationException ex)
        {
            WriteError(ex);


        }
        catch (Exception ex)
        {
            WriteError(ex);

        }



    }
    private DDecimal RUN_TIME = new DDecimal("RUN_TIME", 4);
    private void RUN_TIME_GetValue(ref decimal Value)
    {

        try
        {

            // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

            Value = QDesign.SysTime(ref m_cnnQUERY) / 10000;


        }
        catch (CustomApplicationException ex)
        {
            WriteError(ex);


        }
        catch (Exception ex)
        {
            WriteError(ex);

        }



    }
    private SqlFileObject fleF087_DTL_ADD;
    private SqlFileObject fleF087_HDR_ADD;
    private SqlFileObject fleF002_UPDATE;
    private SqlFileObject fleREJECTED_CLAIMS;
    private SqlFileObject fleMOH_OBEC;
    private SqlFileObject fleF010_UPDATE;





    private SqlFileObject fleU021F_F002_AUDIT;






    private SqlFileObject fleU021F_F010_AUDIT;






    private SqlFileObject fleU021F_DEBUG;


    #endregion


    #region "Standard Generated Procedures(U021F_PROCESS_RMB_SUBMIT_ERRORS_2)"

    #region "Transaction Management Procedures(U021F_PROCESS_RMB_SUBMIT_ERRORS_2)"
    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.

    //# Do not delete, modify or move it.

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
        fleU021A.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF010_PAT_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleICONST_MSTR_REC.Transaction = m_trnTRANS_UPDATE;
        fleF093_HDR_1.Transaction = m_trnTRANS_UPDATE;
        fleF093_HDR_2.Transaction = m_trnTRANS_UPDATE;
        fleF093_HDR_3.Transaction = m_trnTRANS_UPDATE;
        fleF093_HDR_4.Transaction = m_trnTRANS_UPDATE;
        fleF093_HDR_5.Transaction = m_trnTRANS_UPDATE;
        fleF093_DTL_1.Transaction = m_trnTRANS_UPDATE;
        fleF093_DTL_2.Transaction = m_trnTRANS_UPDATE;
        fleF093_DTL_3.Transaction = m_trnTRANS_UPDATE;
        fleF093_DTL_4.Transaction = m_trnTRANS_UPDATE;
        fleF093_DTL_5.Transaction = m_trnTRANS_UPDATE;

        // GW2019. Added
        fleF087_DTL_ADD.Transaction = m_trnTRANS_UPDATE;
        fleF087_HDR_ADD.Transaction = m_trnTRANS_UPDATE;
        fleREJECTED_CLAIMS.Transaction = m_trnTRANS_UPDATE;
        fleMOH_OBEC.Transaction = m_trnTRANS_UPDATE;
    }

    #endregion


    #region "FILE Management Procedures(U021F_PROCESS_RMB_SUBMIT_ERRORS_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

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
            fleU021A.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleF002_CLAIMS_MSTR.Dispose();
            fleF010_PAT_MSTR.Dispose();
            fleICONST_MSTR_REC.Dispose();
            fleF093_HDR_1.Dispose();
            fleF093_HDR_2.Dispose();
            fleF093_HDR_3.Dispose();
            fleF093_HDR_4.Dispose();
            fleF093_HDR_5.Dispose();
            fleF093_DTL_1.Dispose();
            fleF093_DTL_2.Dispose();
            fleF093_DTL_3.Dispose();
            fleF093_DTL_4.Dispose();
            fleF093_DTL_5.Dispose();

            // GW2019. Mar 10 Added
            fleF087_DTL_ADD.Dispose();
            fleF087_HDR_ADD.Dispose();
            fleREJECTED_CLAIMS.Dispose();
            fleMOH_OBEC.Dispose();
        }
        catch (CustomApplicationException ex)
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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U021F_PROCESS_RMB_SUBMIT_ERRORS_2)"


    public void Run()
    {

        try
        {
            Request("PROCESS_RMB_SUBMIT_ERRORS_2");

            while (fleU021A.QTPForMissing())
            {
                // --> GET U021A <--

                fleU021A.GetData();
                // --> End GET U021A <--

                while (fleF020_DOCTOR_MSTR.QTPForMissing("1"))
                {
                    // --> GET F020_DOCTOR_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((QDesign.Substring(fleU021A.GetStringValue("RAT_RMB_ACCOUNT_NBR"), 1, 3))));

                    fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F020_DOCTOR_MSTR <--

                    while (fleF002_CLAIMS_MSTR.QTPForMissing("2"))
                    {
                        // --> GET F002_CLAIMS_MSTR <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                        m_strWhere.Append(Common.StringToField("B"));
                        m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(QDesign.Substring(fleU021A.GetStringValue("RAT_RMB_GROUP_NBR"), 1, 2) + QDesign.Substring(fleU021A.GetStringValue("RAT_RMB_ACCOUNT_NBR"), 1, 6)));
                        m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ");
                        m_strWhere.Append((QDesign.NConvert(QDesign.Substring(fleU021A.GetStringValue("RAT_RMB_ACCOUNT_NBR"), 7, 2))));
                        m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_SERV_CODE")).Append(" = ");
                        m_strWhere.Append(Common.StringToField("00000"));
                        m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_ADJ_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField("0"));

                        fleF002_CLAIMS_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F002_CLAIMS_MSTR <--

                        while (fleF010_PAT_MSTR.QTPForMissing("3"))
                        {
                            // --> GET F010_PAT_MSTR <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_I_KEY")).Append(" = ");
                            m_strWhere.Append(Common.StringToField(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_TYPE")));
                            //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART    'Parent:KEY_PAT_MSTR
                            m_strWhere.Append(" AND ").Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_CON_NBR")).Append(" = ");
                            m_strWhere.Append(QDesign.NConvert((fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_TYPE") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_DATA")).PadRight(16).Substring(1, 2)));
                            //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART    'Parent:KEY_PAT_MSTR
                            m_strWhere.Append(" AND ").Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_I_NBR")).Append(" = ");
                            m_strWhere.Append(QDesign.NConvert((fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_TYPE") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_DATA")).PadRight(16).Substring(3, 12)));
                            //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART    'Parent:KEY_PAT_MSTR
                            m_strWhere.Append(" AND ").Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("FILLER4")).Append(" = ");
                            m_strWhere.Append(Common.StringToField((fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_TYPE") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_DATA")).PadRight(16).Substring(15, 1)));
                            //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART    'Parent:KEY_PAT_MSTR

                            fleF010_PAT_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                            // --> End GET F010_PAT_MSTR <--

                            while (fleICONST_MSTR_REC.QTPForMissing("4"))
                            {
                                // --> GET ICONST_MSTR_REC <--
                                m_strWhere = new StringBuilder(" WHERE ");
                                m_strWhere.Append(" ").Append(fleICONST_MSTR_REC.ElementOwner("ICONST_CLINIC_NBR_1_2")).Append(" = ");
                                m_strWhere.Append(((QDesign.NConvert(QDesign.Substring(fleU021A.GetStringValue("RAT_RMB_GROUP_NBR"), 1, 2)))));

                                fleICONST_MSTR_REC.GetData(m_strWhere.ToString());
                                // --> End GET ICONST_MSTR_REC <--

                                while (fleF093_HDR_1.QTPForMissing("5"))
                                {
                                    // --> GET F093_HDR_1 <--
                                    m_strWhere = new StringBuilder(" WHERE ");
                                    m_strWhere.Append(" ").Append(fleF093_HDR_1.ElementOwner("OHIP_ERR_CODE")).Append(" = ");
                                    m_strWhere.Append(Common.StringToField(fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_1")));

                                    fleF093_HDR_1.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                    // --> End GET F093_HDR_1 <--

                                    while (fleF093_HDR_2.QTPForMissing("6"))
                                    {
                                        // --> GET F093_HDR_2 <--
                                        m_strWhere = new StringBuilder(" WHERE ");
                                        m_strWhere.Append(" ").Append(fleF093_HDR_2.ElementOwner("OHIP_ERR_CODE")).Append(" = ");
                                        m_strWhere.Append(Common.StringToField(fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_2")));

                                        fleF093_HDR_2.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                        // --> End GET F093_HDR_2 <--

                                        while (fleF093_HDR_3.QTPForMissing("7"))
                                        {
                                            // --> GET F093_HDR_3 <--
                                            m_strWhere = new StringBuilder(" WHERE ");
                                            m_strWhere.Append(" ").Append(fleF093_HDR_3.ElementOwner("OHIP_ERR_CODE")).Append(" = ");
                                            m_strWhere.Append(Common.StringToField(fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_3")));

                                            fleF093_HDR_3.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                            // --> End GET F093_HDR_3 <--

                                            while (fleF093_HDR_4.QTPForMissing("8"))
                                            {
                                                // --> GET F093_HDR_4 <--
                                                m_strWhere = new StringBuilder(" WHERE ");
                                                m_strWhere.Append(" ").Append(fleF093_HDR_4.ElementOwner("OHIP_ERR_CODE")).Append(" = ");
                                                m_strWhere.Append(Common.StringToField(fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_4")));

                                                fleF093_HDR_4.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                                // --> End GET F093_HDR_4 <--

                                                while (fleF093_HDR_5.QTPForMissing("9"))
                                                {
                                                    // --> GET F093_HDR_5 <--
                                                    m_strWhere = new StringBuilder(" WHERE ");
                                                    m_strWhere.Append(" ").Append(fleF093_HDR_5.ElementOwner("OHIP_ERR_CODE")).Append(" = ");
                                                    m_strWhere.Append(Common.StringToField(fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_5")));

                                                    fleF093_HDR_5.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                                    // --> End GET F093_HDR_5 <--

                                                    while (fleF093_DTL_1.QTPForMissing("10"))
                                                    {
                                                        // --> GET F093_DTL_1 <--
                                                        m_strWhere = new StringBuilder(" WHERE ");
                                                        m_strWhere.Append(" ").Append(fleF093_DTL_1.ElementOwner("OHIP_ERR_CODE")).Append(" = ");
                                                        m_strWhere.Append(Common.StringToField(fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_1")));

                                                        fleF093_DTL_1.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                                        // --> End GET F093_DTL_1 <--

                                                        while (fleF093_DTL_2.QTPForMissing("11"))
                                                        {
                                                            // --> GET F093_DTL_2 <--
                                                            m_strWhere = new StringBuilder(" WHERE ");
                                                            m_strWhere.Append(" ").Append(fleF093_DTL_2.ElementOwner("OHIP_ERR_CODE")).Append(" = ");
                                                            m_strWhere.Append(Common.StringToField(fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_2")));

                                                            fleF093_DTL_2.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                                            // --> End GET F093_DTL_2 <--

                                                            while (fleF093_DTL_3.QTPForMissing("12"))
                                                            {
                                                                // --> GET F093_DTL_3 <--
                                                                m_strWhere = new StringBuilder(" WHERE ");
                                                                m_strWhere.Append(" ").Append(fleF093_DTL_3.ElementOwner("OHIP_ERR_CODE")).Append(" = ");
                                                                m_strWhere.Append(Common.StringToField(fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_3")));

                                                                fleF093_DTL_3.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                                                // --> End GET F093_DTL_3 <--

                                                                while (fleF093_DTL_4.QTPForMissing("13"))
                                                                {
                                                                    // --> GET F093_DTL_4 <--
                                                                    m_strWhere = new StringBuilder(" WHERE ");
                                                                    m_strWhere.Append(" ").Append(fleF093_DTL_4.ElementOwner("OHIP_ERR_CODE")).Append(" = ");
                                                                    m_strWhere.Append(Common.StringToField(fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_4")));

                                                                    fleF093_DTL_4.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                                                    // --> End GET F093_DTL_4 <--

                                                                    while (fleF093_DTL_5.QTPForMissing("14"))
                                                                    {
                                                                        // --> GET F093_DTL_5 <--
                                                                        m_strWhere = new StringBuilder(" WHERE ");
                                                                        m_strWhere.Append(" ").Append(fleF093_DTL_5.ElementOwner("OHIP_ERR_CODE")).Append(" = ");
                                                                        m_strWhere.Append(Common.StringToField(fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_5")));

                                                                        fleF093_DTL_5.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                                                        // --> End GET F093_DTL_5 <--


                                                                        if (Transaction())
                                                                        {
                                                                            // GW2019. Mar 9. Added
                                                                            if (X_BAL_DUE.Value != 0)
                                                                            //if (Select_If())
                                                                            {
                                                                                Sort(fleU021A.GetSortValue("RAT_RMB_ACCOUNT_NBR"), fleU021A.GetSortValue("RAT_RMB_ORIG_SEQ_NBR"), fleU021A.GetSortValue("RAT_RMB_SERVICE_CD"), fleU021A.GetSortValue("RAT_RMB_SERVICE_DATE"));
                                                                            }

                                                                        }

                                                                    }

                                                                }

                                                            }

                                                        }

                                                    }

                                                }

                                            }

                                        }

                                    }

                                }

                            }

                        }

                    }

                }

            }

            while (Sort(fleU021A, fleF020_DOCTOR_MSTR, fleF002_CLAIMS_MSTR, fleF010_PAT_MSTR, fleICONST_MSTR_REC, fleF093_HDR_1, fleF093_HDR_2, fleF093_HDR_3, fleF093_HDR_4, fleF093_HDR_5,
            fleF093_DTL_1, fleF093_DTL_2, fleF093_DTL_3, fleF093_DTL_4, fleF093_DTL_5))
            {
                X_CHARGE_STATUS.Value = "Y";
                if (QDesign.NULL(fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_1")) != QDesign.NULL(" ") & QDesign.NULL(fleF093_HDR_1.GetStringValue("OHIP_ERR_CAT_CODE")) == QDesign.NULL("E"))
                {
                    X_OHIP_ERR_HDR_ELIG_SS.Value = 1;
                }
                else if (QDesign.NULL(fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_2")) != QDesign.NULL(" ") & QDesign.NULL(fleF093_HDR_2.GetStringValue("OHIP_ERR_CAT_CODE")) == QDesign.NULL("E"))
                {
                    X_OHIP_ERR_HDR_ELIG_SS.Value = 2;
                }
                else if (QDesign.NULL(fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_3")) != QDesign.NULL(" ") & QDesign.NULL(fleF093_HDR_3.GetStringValue("OHIP_ERR_CAT_CODE")) == QDesign.NULL("E"))
                {
                    X_OHIP_ERR_HDR_ELIG_SS.Value = 3;
                }
                else if (QDesign.NULL(fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_4")) != QDesign.NULL(" ") & QDesign.NULL(fleF093_HDR_4.GetStringValue("OHIP_ERR_CAT_CODE")) == QDesign.NULL("E"))
                {
                    X_OHIP_ERR_HDR_ELIG_SS.Value = 4;
                }
                else if (QDesign.NULL(fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_5")) != QDesign.NULL(" ") & QDesign.NULL(fleF093_HDR_5.GetStringValue("OHIP_ERR_CAT_CODE")) == QDesign.NULL("E"))
                {
                    X_OHIP_ERR_HDR_ELIG_SS.Value = 5;
                }
                else
                {
                    X_OHIP_ERR_HDR_ELIG_SS.Value = 0;
                }
                if (QDesign.NULL(fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_1")) != QDesign.NULL(" ") & QDesign.NULL(fleF093_HDR_1.GetStringValue("OHIP_ERR_CAT_CODE")) == QDesign.NULL("S"))
                {
                    X_OHIP_ERR_HDR_SERV_SS.Value = 1;
                }
                else if (QDesign.NULL(fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_2")) != QDesign.NULL(" ") & QDesign.NULL(fleF093_HDR_2.GetStringValue("OHIP_ERR_CAT_CODE")) == QDesign.NULL("S"))
                {
                    X_OHIP_ERR_HDR_SERV_SS.Value = 2;
                }
                else if (QDesign.NULL(fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_3")) != QDesign.NULL(" ") & QDesign.NULL(fleF093_HDR_3.GetStringValue("OHIP_ERR_CAT_CODE")) == QDesign.NULL("S"))
                {
                    X_OHIP_ERR_HDR_SERV_SS.Value = 3;
                }
                else if (QDesign.NULL(fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_4")) != QDesign.NULL(" ") & QDesign.NULL(fleF093_HDR_4.GetStringValue("OHIP_ERR_CAT_CODE")) == QDesign.NULL("S"))
                {
                    X_OHIP_ERR_HDR_SERV_SS.Value = 4;
                }
                else if (QDesign.NULL(fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_5")) != QDesign.NULL(" ") & QDesign.NULL(fleF093_HDR_5.GetStringValue("OHIP_ERR_CAT_CODE")) == QDesign.NULL("S"))
                {
                    X_OHIP_ERR_HDR_SERV_SS.Value = 5;
                }
                else
                {
                    X_OHIP_ERR_HDR_SERV_SS.Value = 0;
                }
                if (QDesign.NULL(fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_1")) != QDesign.NULL(" ") & QDesign.NULL(fleF093_DTL_1.GetStringValue("OHIP_ERR_CAT_CODE")) == QDesign.NULL("E"))
                {
                    X_OHIP_ERR_DTL_ELIG_SS.Value = 1;
                }
                else if (QDesign.NULL(fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_2")) != QDesign.NULL(" ") & QDesign.NULL(fleF093_DTL_2.GetStringValue("OHIP_ERR_CAT_CODE")) == QDesign.NULL("E"))
                {
                    X_OHIP_ERR_DTL_ELIG_SS.Value = 2;
                }
                else if (QDesign.NULL(fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_3")) != QDesign.NULL(" ") & QDesign.NULL(fleF093_DTL_3.GetStringValue("OHIP_ERR_CAT_CODE")) == QDesign.NULL("E"))
                {
                    X_OHIP_ERR_DTL_ELIG_SS.Value = 3;
                }
                else if (QDesign.NULL(fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_4")) != QDesign.NULL(" ") & QDesign.NULL(fleF093_DTL_4.GetStringValue("OHIP_ERR_CAT_CODE")) == QDesign.NULL("E"))
                {
                    X_OHIP_ERR_DTL_ELIG_SS.Value = 4;
                }
                else if (QDesign.NULL(fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_5")) != QDesign.NULL(" ") & QDesign.NULL(fleF093_DTL_5.GetStringValue("OHIP_ERR_CAT_CODE")) == QDesign.NULL("E"))
                {
                    X_OHIP_ERR_DTL_ELIG_SS.Value = 5;
                }
                else
                {
                    X_OHIP_ERR_DTL_ELIG_SS.Value = 0;
                }
                if (QDesign.NULL(fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_1")) != QDesign.NULL(" ") & QDesign.NULL(fleF093_DTL_1.GetStringValue("OHIP_ERR_CAT_CODE")) == QDesign.NULL("S"))
                {
                    X_OHIP_ERR_DTL_SERV_SS.Value = 1;
                }
                else if (QDesign.NULL(fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_2")) != QDesign.NULL(" ") & QDesign.NULL(fleF093_DTL_2.GetStringValue("OHIP_ERR_CAT_CODE")) == QDesign.NULL("S"))
                {
                    X_OHIP_ERR_DTL_SERV_SS.Value = 2;
                }
                else if (QDesign.NULL(fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_3")) != QDesign.NULL(" ") & QDesign.NULL(fleF093_DTL_3.GetStringValue("OHIP_ERR_CAT_CODE")) == QDesign.NULL("S"))
                {
                    X_OHIP_ERR_DTL_SERV_SS.Value = 3;
                }
                else if (QDesign.NULL(fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_4")) != QDesign.NULL(" ") & QDesign.NULL(fleF093_DTL_4.GetStringValue("OHIP_ERR_CAT_CODE")) == QDesign.NULL("S"))
                {
                    X_OHIP_ERR_DTL_SERV_SS.Value = 4;
                }
                else if (QDesign.NULL(fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_5")) != QDesign.NULL(" ") & QDesign.NULL(fleF093_DTL_5.GetStringValue("OHIP_ERR_CAT_CODE")) == QDesign.NULL("S"))
                {
                    X_OHIP_ERR_DTL_SERV_SS.Value = 5;
                }
                else
                {
                    X_OHIP_ERR_DTL_SERV_SS.Value = 0;
                }
                if (QDesign.NULL(X_OHIP_ERR_HDR_ELIG_SS.Value) == 1)
                {
                    X_OHIP_ERR_CODE_HDR_THIS_REC.Value = fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_1");
                }
                else if (QDesign.NULL(X_OHIP_ERR_HDR_ELIG_SS.Value) == 2)
                {
                    X_OHIP_ERR_CODE_HDR_THIS_REC.Value = fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_2");
                }
                else if (QDesign.NULL(X_OHIP_ERR_HDR_ELIG_SS.Value) == 3)
                {
                    X_OHIP_ERR_CODE_HDR_THIS_REC.Value = fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_3");
                }
                else if (QDesign.NULL(X_OHIP_ERR_HDR_ELIG_SS.Value) == 4)
                {
                    X_OHIP_ERR_CODE_HDR_THIS_REC.Value = fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_4");
                }
                else if (QDesign.NULL(X_OHIP_ERR_HDR_ELIG_SS.Value) == 5)
                {
                    X_OHIP_ERR_CODE_HDR_THIS_REC.Value = fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_5");
                }
                else if (QDesign.NULL(X_OHIP_ERR_HDR_SERV_SS.Value) == 1)
                {
                    X_OHIP_ERR_CODE_HDR_THIS_REC.Value = fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_1");
                }
                else if (QDesign.NULL(X_OHIP_ERR_HDR_SERV_SS.Value) == 2)
                {
                    X_OHIP_ERR_CODE_HDR_THIS_REC.Value = fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_2");
                }
                else if (QDesign.NULL(X_OHIP_ERR_HDR_SERV_SS.Value) == 3)
                {
                    X_OHIP_ERR_CODE_HDR_THIS_REC.Value = fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_3");
                }
                else if (QDesign.NULL(X_OHIP_ERR_HDR_SERV_SS.Value) == 4)
                {
                    X_OHIP_ERR_CODE_HDR_THIS_REC.Value = fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_4");
                }
                else if (QDesign.NULL(X_OHIP_ERR_HDR_SERV_SS.Value) == 5)
                {
                    X_OHIP_ERR_CODE_HDR_THIS_REC.Value = fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_5");
                }
                else
                {
                    X_OHIP_ERR_CODE_HDR_THIS_REC.Value = " ";
                }
                if (QDesign.NULL(X_OHIP_ERR_HDR_ELIG_SS.Value) > 0)
                {
                    X_OHIP_ERR_CODE_HDR_CAT_THIS_REC.Value = "E";
                }
                else if (QDesign.NULL(X_OHIP_ERR_HDR_SERV_SS.Value) > 0)
                {
                    X_OHIP_ERR_CODE_HDR_CAT_THIS_REC.Value = "S";
                }
                else
                {
                    X_OHIP_ERR_CODE_HDR_CAT_THIS_REC.Value = " ";
                }
                if (QDesign.NULL(X_OHIP_ERR_DTL_ELIG_SS.Value) == 1)
                {
                    X_OHIP_ERR_CODE_DTL_THIS_REC.Value = fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_1");
                }
                else if (QDesign.NULL(X_OHIP_ERR_DTL_ELIG_SS.Value) == 2)
                {
                    X_OHIP_ERR_CODE_DTL_THIS_REC.Value = fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_2");
                }
                else if (QDesign.NULL(X_OHIP_ERR_DTL_ELIG_SS.Value) == 3)
                {
                    X_OHIP_ERR_CODE_DTL_THIS_REC.Value = fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_3");
                }
                else if (QDesign.NULL(X_OHIP_ERR_DTL_ELIG_SS.Value) == 4)
                {
                    X_OHIP_ERR_CODE_DTL_THIS_REC.Value = fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_4");
                }
                else if (QDesign.NULL(X_OHIP_ERR_DTL_ELIG_SS.Value) == 5)
                {
                    X_OHIP_ERR_CODE_DTL_THIS_REC.Value = fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_5");
                }
                else if (QDesign.NULL(X_OHIP_ERR_DTL_SERV_SS.Value) == 1)
                {
                    X_OHIP_ERR_CODE_DTL_THIS_REC.Value = fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_1");
                }
                else if (QDesign.NULL(X_OHIP_ERR_DTL_SERV_SS.Value) == 2)
                {
                    X_OHIP_ERR_CODE_DTL_THIS_REC.Value = fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_2");
                }
                else if (QDesign.NULL(X_OHIP_ERR_DTL_SERV_SS.Value) == 3)
                {
                    X_OHIP_ERR_CODE_DTL_THIS_REC.Value = fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_3");
                }
                else if (QDesign.NULL(X_OHIP_ERR_DTL_SERV_SS.Value) == 4)
                {
                    X_OHIP_ERR_CODE_DTL_THIS_REC.Value = fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_4");
                }
                else if (QDesign.NULL(X_OHIP_ERR_DTL_SERV_SS.Value) == 5)
                {
                    X_OHIP_ERR_CODE_DTL_THIS_REC.Value = fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_5");
                }
                else
                {
                    X_OHIP_ERR_CODE_DTL_THIS_REC.Value = " ";
                }
                if (QDesign.NULL(X_OHIP_ERR_DTL_ELIG_SS.Value) > 0)
                {
                    X_OHIP_ERR_CODE_DTL_CAT_THIS_REC.Value = "E";
                }
                else if (QDesign.NULL(X_OHIP_ERR_DTL_SERV_SS.Value) > 0)
                {
                    X_OHIP_ERR_CODE_DTL_CAT_THIS_REC.Value = "S";
                }
                else
                {
                    X_OHIP_ERR_CODE_DTL_CAT_THIS_REC.Value = " ";
                }
                if (QDesign.NULL(X_OHIP_ERR_CODE_HDR_CLAIM.Value) == QDesign.NULL(" ") | (QDesign.NULL(X_OHIP_ERR_CODE_HDR_CAT_CLAIM.Value) == QDesign.NULL("S") & QDesign.NULL(X_OHIP_ERR_CODE_HDR_CAT_THIS_REC.Value) == QDesign.NULL("E")))
                {
                    X_HDR_CODE_GOING_TO_BE_CHANGED.Value = "Y";
                }
                else
                {
                    X_HDR_CODE_GOING_TO_BE_CHANGED.Value = "N";
                }
                if (QDesign.NULL(X_OHIP_ERR_CODE_DTL_CLAIM.Value) == QDesign.NULL(" ") | (QDesign.NULL(X_OHIP_ERR_CODE_DTL_CAT_CLAIM.Value) == QDesign.NULL("S") & QDesign.NULL(X_OHIP_ERR_CODE_DTL_CAT_THIS_REC.Value) == QDesign.NULL("E")))
                {
                    X_DTL_CODE_GOING_TO_BE_CHANGED.Value = "Y";
                }
                else
                {
                    X_DTL_CODE_GOING_TO_BE_CHANGED.Value = "N";
                }
                if (QDesign.NULL(X_HDR_CODE_GOING_TO_BE_CHANGED.Value) == QDesign.NULL("Y"))
                {
                    X_OHIP_ERR_CODE_HDR_CAT_CLAIM.Value = X_OHIP_ERR_CODE_HDR_CAT_THIS_REC.Value;
                }
                if (QDesign.NULL(X_DTL_CODE_GOING_TO_BE_CHANGED.Value) == QDesign.NULL("Y"))
                {
                    X_OHIP_ERR_CODE_DTL_CAT_CLAIM.Value = X_OHIP_ERR_CODE_DTL_CAT_THIS_REC.Value;
                }
                if (QDesign.NULL(X_HDR_CODE_GOING_TO_BE_CHANGED.Value) == QDesign.NULL("Y"))
                {
                    X_OHIP_ERR_CODE_HDR_CLAIM.Value = X_OHIP_ERR_CODE_HDR_THIS_REC.Value;
                }
                if (QDesign.NULL(X_DTL_CODE_GOING_TO_BE_CHANGED.Value) == QDesign.NULL("Y"))
                {
                    X_OHIP_ERR_CODE_DTL_CLAIM.Value = X_OHIP_ERR_CODE_DTL_THIS_REC.Value;
                }
                if (QDesign.NULL(X_OHIP_ERR_DTL_SERV_SS.Value) == 1)
                {
                    X_OHIP_ERR_CODE_DTL_SERV_THIS_REC.Value = fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_1");
                }
                else if (QDesign.NULL(X_OHIP_ERR_DTL_SERV_SS.Value) == 2)
                {
                    X_OHIP_ERR_CODE_DTL_SERV_THIS_REC.Value = fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_2");
                }
                else if (QDesign.NULL(X_OHIP_ERR_DTL_SERV_SS.Value) == 3)
                {
                    X_OHIP_ERR_CODE_DTL_SERV_THIS_REC.Value = fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_3");
                }
                else if (QDesign.NULL(X_OHIP_ERR_DTL_SERV_SS.Value) == 4)
                {
                    X_OHIP_ERR_CODE_DTL_SERV_THIS_REC.Value = fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_4");
                }
                else if (QDesign.NULL(X_OHIP_ERR_DTL_SERV_SS.Value) == 5)
                {
                    X_OHIP_ERR_CODE_DTL_SERV_THIS_REC.Value = fleU021A.GetStringValue("RAT_RMB_ERROR_T_CD_5");
                }
                else
                {
                    X_OHIP_ERR_CODE_DTL_SERV_THIS_REC.Value = X_OHIP_ERR_CODE_DTL_SERV_THIS_REC.Value;
                }
                if (QDesign.NULL(X_OHIP_ERR_HDR_SERV_SS.Value) == 1)
                {
                    X_OHIP_ERR_CODE_HDR_SERV_THIS_REC.Value = fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_1");
                }
                else if (QDesign.NULL(X_OHIP_ERR_HDR_SERV_SS.Value) == 2)
                {
                    X_OHIP_ERR_CODE_HDR_SERV_THIS_REC.Value = fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_2");
                }
                else if (QDesign.NULL(X_OHIP_ERR_HDR_SERV_SS.Value) == 3)
                {
                    X_OHIP_ERR_CODE_HDR_SERV_THIS_REC.Value = fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_3");
                }
                else if (QDesign.NULL(X_OHIP_ERR_HDR_SERV_SS.Value) == 4)
                {
                    X_OHIP_ERR_CODE_HDR_SERV_THIS_REC.Value = fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_4");
                }
                else if (QDesign.NULL(X_OHIP_ERR_HDR_SERV_SS.Value) == 5)
                {
                    X_OHIP_ERR_CODE_HDR_SERV_THIS_REC.Value = fleU021A.GetStringValue("RAT_RMB_ERROR_H_CD_5");
                }
                else
                {
                    X_OHIP_ERR_CODE_HDR_SERV_THIS_REC.Value = " ";
                }
                if (QDesign.NULL(X_OHIP_ERR_CODE_HDR_SERV_CLAIM.Value) == QDesign.NULL(" "))
                {
                    X_OHIP_ERR_CODE_HDR_SERV_CLAIM.Value = X_OHIP_ERR_CODE_HDR_SERV_THIS_REC.Value;
                }
                if (QDesign.NULL(X_OHIP_ERR_CODE_DTL_SERV_CLAIM.Value) == QDesign.NULL(" "))
                {
                    X_OHIP_ERR_CODE_DTL_SERV_CLAIM.Value = X_OHIP_ERR_CODE_DTL_SERV_THIS_REC.Value;
                }
                if (QDesign.NULL(X_OHIP_ERR_CODE_HDR_CLAIM.Value) != QDesign.NULL(" ") & (QDesign.NULL(X_OHIP_ERR_CODE_HDR_CAT_CLAIM.Value) == QDesign.NULL("E") | QDesign.NULL(X_OHIP_ERR_CODE_DTL_CAT_CLAIM.Value) == QDesign.NULL("S")))
                {
                    X_OHIP_ERR_CODE_FINAL.Value = X_OHIP_ERR_CODE_HDR_CLAIM.Value;
                }
                else if (QDesign.NULL(X_OHIP_ERR_CODE_HDR_CLAIM.Value) != QDesign.NULL(" ") & (QDesign.NULL(X_OHIP_ERR_CODE_HDR_CAT_CLAIM.Value) == QDesign.NULL("S")))
                {
                    X_OHIP_ERR_CODE_FINAL.Value = X_OHIP_ERR_CODE_HDR_CLAIM.Value;
                }
                else if (QDesign.NULL(X_OHIP_ERR_CODE_DTL_CLAIM.Value) != QDesign.NULL(" "))
                {
                    X_OHIP_ERR_CODE_FINAL.Value = X_OHIP_ERR_CODE_DTL_CLAIM.Value;
                }
                else
                {
                    X_OHIP_ERR_CODE_FINAL.Value = " ";
                }
                if (QDesign.NULL(X_OHIP_ERR_CODE_HDR_CAT_CLAIM.Value) != QDesign.NULL(" ") & (QDesign.NULL(X_OHIP_ERR_CODE_HDR_CAT_CLAIM.Value) == QDesign.NULL("E") | QDesign.NULL(X_OHIP_ERR_CODE_DTL_CAT_CLAIM.Value) == QDesign.NULL("S")))
                {
                    X_OHIP_ERR_CODE_FINAL_CAT.Value = X_OHIP_ERR_CODE_HDR_CAT_CLAIM.Value;
                }
                else if (QDesign.NULL(X_OHIP_ERR_CODE_HDR_CAT_CLAIM.Value) != QDesign.NULL(" ") & (QDesign.NULL(X_OHIP_ERR_CODE_HDR_CAT_CLAIM.Value) == QDesign.NULL("S")))
                {
                    X_OHIP_ERR_CODE_FINAL_CAT.Value = X_OHIP_ERR_CODE_HDR_CAT_CLAIM.Value;
                }
                else if (QDesign.NULL(X_OHIP_ERR_CODE_DTL_CAT_CLAIM.Value) != QDesign.NULL(" "))
                {
                    X_OHIP_ERR_CODE_FINAL_CAT.Value = X_OHIP_ERR_CODE_DTL_CAT_CLAIM.Value;
                }
                else
                {
                    X_OHIP_ERR_CODE_FINAL_CAT.Value = " ";
                }

                // GW2019. Added for parent/child
                string pat_birth_date = QDesign.NULL(fleF010_PAT_MSTR.GetNumericDateValue("PAT_BIRTH_DATE_YY")).ToString().PadLeft(4, '0') +
                    QDesign.NULL(fleF010_PAT_MSTR.GetNumericDateValue("PAT_BIRTH_DATE_MM")).ToString().PadLeft(2, '0') +
                    QDesign.NULL(fleF010_PAT_MSTR.GetNumericDateValue("PAT_BIRTH_DATE_DD")).ToString().PadLeft(2, '0');
                string rmb_birth_date = QDesign.NULL(fleU021A.GetNumericDateValue("RAT_RMB_BIRTH_DATE")).ToString();

                if ((QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("PAT_VERSION_CD")) != QDesign.NULL(fleU021A.GetStringValue("RAT_RMB_VERSION_CD")) & (QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) == QDesign.NULL("EH2") | QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) == QDesign.NULL("VH4"))) | (!pat_birth_date.Equals(rmb_birth_date) & (QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) == QDesign.NULL("VH8"))))
                {
                    X_F002_CLAIM_STATUS.Value = "X";
                }
                else if (QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) != QDesign.NULL(" "))
                {
                    X_F002_CLAIM_STATUS.Value = "H";
                }
                else
                {
                    X_F002_CLAIM_STATUS.Value = " ";
                }
                REC_COUNTER.Value = REC_COUNTER.Value + 1;






                fleF087_DTL_ADD.OutPut(OutPutType.Add);







                fleF087_HDR_ADD.OutPut(OutPutType.Add, fleU021A.At("RAT_RMB_ACCOUNT_NBR"), 1 == 1);
                //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART)    'Parent:KEY_PAT_MSTR)    'Parent:PAT_BIRTH_DATE)    'Parent:CLMHDR_PAT_OHIP_ID_OR_CHART)    'Parent:PAT_BIRTH_DATE)    'Parent:KEY_PAT_MSTR







                fleF002_CLAIMS_MSTR.OutPut(OutPutType.Update, fleU021A.At("RAT_RMB_ACCOUNT_NBR"), fleF002_CLAIMS_MSTR.Exists() & 1 == 1);
                //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART)    'Parent:KEY_PAT_MSTR)    'Parent:PAT_BIRTH_DATE)    'Parent:CLMHDR_PAT_OHIP_ID_OR_CHART)    'Parent:PAT_BIRTH_DATE)    'Parent:KEY_PAT_MSTR







                fleREJECTED_CLAIMS.OutPut(OutPutType.Add, fleU021A.At("RAT_RMB_ACCOUNT_NBR"), QDesign.NULL(X_F002_CLAIM_STATUS.Value) == QDesign.NULL("H") & 1 == 1);
                //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART)    'Parent:KEY_PAT_MSTR)    'Parent:PAT_BIRTH_DATE)    'Parent:CLMHDR_PAT_OHIP_ID_OR_CHART)    'Parent:PAT_BIRTH_DATE)    'Parent:KEY_PAT_MSTR







                fleMOH_OBEC.OutPut(OutPutType.Add, fleU021A.At("RAT_RMB_ACCOUNT_NBR"), 1 == 1);
                //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART)    'Parent:KEY_PAT_MSTR)    'Parent:PAT_BIRTH_DATE)    'Parent:CLMHDR_PAT_OHIP_ID_OR_CHART)    'Parent:PAT_BIRTH_DATE)    'Parent:KEY_PAT_MSTR







                fleF010_PAT_MSTR.OutPut(OutPutType.Update, fleU021A.At("RAT_RMB_ACCOUNT_NBR"), (QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) == QDesign.NULL("EH1") | QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) == QDesign.NULL("EH2") | QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) == QDesign.NULL("EH4") | QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) == QDesign.NULL("EH5") | QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) == QDesign.NULL("VH4") | QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) == QDesign.NULL("VH8") | QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) == QDesign.NULL("VH9")) & fleF010_PAT_MSTR.Exists() & QDesign.NULL(X_F002_CLAIM_STATUS.Value) == QDesign.NULL("H") & 1 == 1);
                //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART)    'Parent:KEY_PAT_MSTR)    'Parent:PAT_BIRTH_DATE)    'Parent:CLMHDR_PAT_OHIP_ID_OR_CHART)    'Parent:PAT_BIRTH_DATE)    'Parent:KEY_PAT_MSTR







                SubFile(ref m_trnTRANS_UPDATE, ref fleU021F_F002_AUDIT, fleU021A.At("RAT_RMB_ACCOUNT_NBR"), SubFileType.Keep, RUN_DATE, RUN_TIME, fleU021A, "RAT_RMB_FILE_NAME", "RAT_RMB_ACCOUNT_NBR", X_OHIP_ERR_CODE_HDR_CAT_CLAIM,
                X_OHIP_ERR_CODE_DTL_CAT_CLAIM, X_OHIP_ERR_CODE_HDR_CLAIM, X_OHIP_ERR_CODE_DTL_CLAIM, X_OHIP_ERR_CODE_HDR_SERV_CLAIM, X_OHIP_ERR_CODE_DTL_SERV_CLAIM, X_OHIP_ERR_CODE_FINAL, X_OHIP_ERR_CODE_FINAL_CAT, fleF002_CLAIMS_MSTR, "CLMHDR_ELIG_STATUS", "CLMHDR_TAPE_SUBMIT_IND");
                //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART)    'Parent:KEY_PAT_MSTR)    'Parent:PAT_BIRTH_DATE)    'Parent:CLMHDR_PAT_OHIP_ID_OR_CHART)    'Parent:PAT_BIRTH_DATE)    'Parent:KEY_PAT_MSTR






                SubFile(ref m_trnTRANS_UPDATE, ref fleU021F_F010_AUDIT, fleU021A.At("RAT_RMB_ACCOUNT_NBR"), (QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) == QDesign.NULL("EH1") | QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) == QDesign.NULL("EH2") | QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) == QDesign.NULL("EH4") | QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) == QDesign.NULL("EH5") | QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) == QDesign.NULL("VH4") | QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) == QDesign.NULL("VH8") | QDesign.NULL(X_OHIP_ERR_CODE_FINAL.Value) == QDesign.NULL("VH9")), SubFileType.Keep, RUN_DATE, RUN_TIME, fleU021A, "RAT_RMB_FILE_NAME", "RAT_RMB_ACCOUNT_NBR",
                X_OHIP_ERR_CODE_HDR_CAT_CLAIM, X_OHIP_ERR_CODE_DTL_CAT_CLAIM, X_OHIP_ERR_CODE_HDR_CLAIM, X_OHIP_ERR_CODE_DTL_CLAIM, X_OHIP_ERR_CODE_HDR_SERV_CLAIM, X_OHIP_ERR_CODE_DTL_SERV_CLAIM, X_OHIP_ERR_CODE_FINAL, X_OHIP_ERR_CODE_FINAL_CAT, fleF010_PAT_MSTR, "PAT_OHIP_VALIDATION_STATUS",
                "PAT_OBEC_STATUS");
                //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART)    'Parent:KEY_PAT_MSTR)    'Parent:PAT_BIRTH_DATE)    'Parent:CLMHDR_PAT_OHIP_ID_OR_CHART)    'Parent:PAT_BIRTH_DATE)    'Parent:KEY_PAT_MSTR






                SubFile(ref m_trnTRANS_UPDATE, ref fleU021F_DEBUG, SubFileType.Keep, fleU021A, "RAT_RMB_FILE_NAME", "RAT_RMB_ACCOUNT_NBR", X_OHIP_ERR_HDR_ELIG_SS, X_OHIP_ERR_HDR_SERV_SS, X_OHIP_ERR_DTL_ELIG_SS, X_OHIP_ERR_DTL_SERV_SS,
                X_OHIP_ERR_CODE_HDR_THIS_REC, X_OHIP_ERR_CODE_HDR_CAT_THIS_REC, X_OHIP_ERR_CODE_DTL_THIS_REC, X_OHIP_ERR_CODE_DTL_CAT_THIS_REC, X_OHIP_ERR_CODE_HDR_CLAIM, X_OHIP_ERR_CODE_DTL_CAT_CLAIM, X_OHIP_ERR_CODE_HDR_CAT_CLAIM, X_OHIP_ERR_CODE_DTL_CLAIM, X_HDR_CODE_GOING_TO_BE_CHANGED, X_DTL_CODE_GOING_TO_BE_CHANGED,
                X_OHIP_ERR_CODE_HDR_SERV_THIS_REC, X_OHIP_ERR_CODE_DTL_SERV_THIS_REC, X_OHIP_ERR_CODE_HDR_SERV_CLAIM, X_OHIP_ERR_CODE_DTL_SERV_CLAIM, X_OHIP_ERR_CODE_FINAL, X_OHIP_ERR_CODE_FINAL_CAT);
                //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART)    'Parent:KEY_PAT_MSTR)    'Parent:PAT_BIRTH_DATE)    'Parent:CLMHDR_PAT_OHIP_ID_OR_CHART)    'Parent:PAT_BIRTH_DATE)    'Parent:KEY_PAT_MSTR


                Reset(ref X_OHIP_ERR_CODE_HDR_CAT_CLAIM, fleU021A.At("RAT_RMB_ACCOUNT_NBR"));
                Reset(ref X_OHIP_ERR_CODE_DTL_CAT_CLAIM, fleU021A.At("RAT_RMB_ACCOUNT_NBR"));
                Reset(ref X_OHIP_ERR_CODE_HDR_CLAIM, fleU021A.At("RAT_RMB_ACCOUNT_NBR"));
                Reset(ref X_OHIP_ERR_CODE_DTL_CLAIM, fleU021A.At("RAT_RMB_ACCOUNT_NBR"));
                Reset(ref X_OHIP_ERR_CODE_DTL_SERV_THIS_REC, fleU021A.At("RAT_RMB_ACCOUNT_NBR"));
                Reset(ref X_OHIP_ERR_CODE_HDR_SERV_CLAIM, fleU021A.At("RAT_RMB_ACCOUNT_NBR"));
                Reset(ref X_OHIP_ERR_CODE_DTL_SERV_CLAIM, fleU021A.At("RAT_RMB_ACCOUNT_NBR"));
                Reset(ref REC_COUNTER, fleU021A.At("RAT_RMB_ACCOUNT_NBR"));

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
            EndRequest("PROCESS_RMB_SUBMIT_ERRORS_2");

        }

    }




    #endregion


}
//PROCESS_RMB_SUBMIT_ERRORS_2




