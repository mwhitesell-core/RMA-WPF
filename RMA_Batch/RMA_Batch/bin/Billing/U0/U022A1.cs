
#region "Screen Comments"

// #> PROGRAM-ID.     u022a1.qts
// ((C)) Dyad Technologies
// PROGRAM PURPOSE : TO WORK WITH R022A.QZS - BY CREATING A AUDIT SUBFILE
// THIS USED TO BE THE FIRST RUN OF THAT PROGRAM
// MODIFICATION HISTORY
// DATE   WHO   DESCRIPTION
// 00/MAY/08 B.A.  - ORIGINAL (transformed from r022a.qzs to 
// u022a.qts so that multiple subfiles (audit)
// could be generated in 1 pass
// 00/may/08 B.E.  - added selection of  X  status claims to force
// resubmit of claims regardless of other conditions
// 00/may/29 B.E.  - don`t select for resubmission claims that haven`t 
// been submitted to ohip yet (ie. have blank
// submission date)
// 00/may/31 B.E.  - clmhdr-date-cash-tape-payment is character field
// and selection added to select if date is    00  
// 00/jun/01 B.E.  - changed test to use submit-date rather than entry-date
// 00/jun/01 B.E.  - some agent 6 claims were incorrecltcy re-submitted to ohip
// when and  X  status was placed into claim. Select logic
// changed to first check moh-flag indicating claim should go 
// to ohip, then apply other checks.
// 02/sep/23 M.C.  - include clinic 95 to the same as other clinic 80`s        
// 02/nov/13 M.C.  - optimize the select statement by removing redundant statements
// 03/may/30 M.C.  - include contract-code in the subfile, so that in u022b.qts, sort
// on contract-code before any other sort fields; contract D contains
// all 60`s clinics
// 03/jun/11 yas   - include clinics 91,92,93,94,96 to do the same as other clinic 80`s        
// 03/dec/09 MC/BE - modify selection criteria to include stale date claims that are 
// 150 days or greater   and there is balance and no submission date
// 03/dec/11 A.A.  - alpha doctor nbr
// 04/feb/26 M.C.  - change/extend the definition of w-clmhdr-hosp and add constant mstr
// in the access statement
// 04/mar/01 M.C.  - use afp-flag instead of checking the clinic
// 04/mar/17 M.C.  - Do not resubmit claims if afp clinic with reason `I2`(fully paid)
// even the claim status has set to `X`
// 04/apr/21 M.C.  - modify the criteria for 2 rat processed and `R`esubmit
// 04/may/19 M.C.  - modify the value check on afp-flag(iconst-clinic-card-colour)
// - value `O` represents old afp  
// 05/jun/14 M.C.  - check clmhdr-status <> ` ` when selecting stale date claims
// 06/apr/10 M.C.  - effective Apr 1, 2006, do not require to submit loc-ministry-loc-code
// - use service location indicator instead
// 12/Dec/19 MC1   - allow to resubmit claims with `X` and health nbr = 1111111116 for CME claims 
// - include f010-pat-mstr in the acces statement in order to check pat-health-nbr
// 14/Apr/10 MC2   - change access to use f002-outstanding as the driver to link to claims mstr
// - transfer the selection for resubmit into the copybook $use/select_for_resubmit.use
// - comment out the choose statement as it is not needed


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U022A1 : BaseClassControl
{

    private U022A1 m_U022A1;

    public U022A1(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public U022A1(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_U022A1 != null))
        {
            m_U022A1.CloseTransactionObjects();
            m_U022A1 = null;
        }
    }

    public U022A1 GetU022A1(int Level)
    {
        if (m_U022A1 == null)
        {
            m_U022A1 = new U022A1("U022A1", Level);
        }
        else
        {
            m_U022A1.ResetValues();
        }
        return m_U022A1;
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

            U022A1_EXTRACT_1 EXTRACT_1 = new U022A1_EXTRACT_1(Name, Level);
            EXTRACT_1.Run();
            EXTRACT_1.Dispose();
            EXTRACT_1 = null;

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



public class U022A1_EXTRACT_1 : U022A1
{

    public U022A1_EXTRACT_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF002_OUTSTANDING = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_OUTSTANDING", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleCONTRACT_DTL = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "CONTRACT_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF010_PAT_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F010_PAT_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleICONST_MSTR_REC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "ICONST_MSTR_REC", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF030_LOCATIONS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F030_LOCATIONS_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_REC_COUNT = new CoreDecimal("X_REC_COUNT", 6, this);
        fleU022A1 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U022A1", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU022A1_AUDIT = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U022A1_AUDIT", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        W_REGULAR.GetValue += W_REGULAR_GetValue;
        W_OVER.GetValue += W_OVER_GetValue;
        IN_LOC.GetValue += IN_LOC_GetValue;
        IN_SPEC.GetValue += IN_SPEC_GetValue;
        W_DOC_CLINIC_NBR.GetValue += W_DOC_CLINIC_NBR_GetValue;
        TRANSLATED_GROUP_NBR.GetValue += TRANSLATED_GROUP_NBR_GetValue;
        W_DATE_FROM.GetValue += W_DATE_FROM_GetValue;
        W_DATE_TO.GetValue += W_DATE_TO_GetValue;
        X_CLINIC_NBR_1_2.GetValue += X_CLINIC_NBR_1_2_GetValue;
        BALANCE_DUE.GetValue += BALANCE_DUE_GetValue;
        X_TEST_DATE.GetValue += X_TEST_DATE_GetValue;
        X_TEST_DAY.GetValue += X_TEST_DAY_GetValue;
        W_DAYS_SINCE_ENTRY.GetValue += W_DAYS_SINCE_ENTRY_GetValue;
        TWO_RATS_PROCESSED.GetValue += TWO_RATS_PROCESSED_GetValue;
        X_DAYS_SINCE_PED.GetValue += X_DAYS_SINCE_PED_GetValue;
        X_DAYS_SINCE_SERVICE.GetValue += X_DAYS_SINCE_SERVICE_GetValue;
        W_MOH_LOCATION_CODE.GetValue += W_MOH_LOCATION_CODE_GetValue;
        W_CLMHDR_HOSP.GetValue += W_CLMHDR_HOSP_GetValue;
        D_SYSDATE.GetValue += D_SYSDATE_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(U022A1_EXTRACT_1)"

    private SqlFileObject fleF002_OUTSTANDING;
    private SqlFileObject fleF002_CLAIMS_MSTR;
    private SqlFileObject fleCONTRACT_DTL;
    private SqlFileObject fleF020_DOCTOR_MSTR;
    private SqlFileObject fleF010_PAT_MSTR;
    private SqlFileObject fleICONST_MSTR_REC;
    private SqlFileObject fleF030_LOCATIONS_MSTR;
    private DCharacter W_REGULAR = new DCharacter("W_REGULAR", 1);
    private void W_REGULAR_GetValue(ref string Value)
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
    private DCharacter W_OVER = new DCharacter("W_OVER", 1);
    private void W_OVER_GetValue(ref string Value)
    {

        try
        {
            Value = "O";


        }
        catch (CustomApplicationException ex)
        {
            WriteError(ex);


        }
        catch (Exception ex)
        {
            WriteError(ex);

        }



    }
    private DCharacter IN_LOC = new DCharacter("IN_LOC", 4);
    private void IN_LOC_GetValue(ref string Value)
    {

        try
        {
            Value = fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_LOC");


        }
        catch (CustomApplicationException ex)
        {
            WriteError(ex);


        }
        catch (Exception ex)
        {
            WriteError(ex);

        }



    }
    private DDecimal IN_SPEC = new DDecimal("IN_SPEC", 2);
    private void IN_SPEC_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_DOC_SPEC_CD");


        }
        catch (CustomApplicationException ex)
        {
            WriteError(ex);


        }
        catch (Exception ex)
        {
            WriteError(ex);

        }



    }
    private DDecimal W_DOC_CLINIC_NBR = new DDecimal("W_DOC_CLINIC_NBR", 2);
    private void W_DOC_CLINIC_NBR_GetValue(ref decimal Value)
    {

        try
        {
            Value = QDesign.NConvert(QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_BATCH_NBR") + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_CLAIM_NBR"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_OMA_CD") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_OMA_SUFF") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_ADJ_NBR"), 1, 2));
            //Parent:CLMHDR_CLAIM_ID


        }
        catch (CustomApplicationException ex)
        {
            WriteError(ex);


        }
        catch (Exception ex)
        {
            WriteError(ex);

        }

    }
    private DCharacter TRANSLATED_GROUP_NBR = new DCharacter("TRANSLATED_GROUP_NBR", 4);
    private void TRANSLATED_GROUP_NBR_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (((QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("GROUP_OVER_SERVICED")) != QDesign.NULL("    ")) & (((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_1"))) & (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_1_S1")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_1_S2")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_1_S3")) == QDesign.NULL(W_OVER.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_2"))) & (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_2_S1")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_2_S2")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_2_S3")) == QDesign.NULL(W_OVER.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_3"))) & (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_3_S1")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_3_S2")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_3_S3")) == QDesign.NULL(W_OVER.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_4"))) & (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_4_S1")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_4_S2")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_4_S3")) == QDesign.NULL(W_OVER.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_5"))) & (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_5_S1")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_5_S2")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_5_S3")) == QDesign.NULL(W_OVER.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_6"))) & (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_6_S1")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_6_S2")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_6_S3")) == QDesign.NULL(W_OVER.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_7"))) & (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_7_S1")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_7_S2")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_7_S3")) == QDesign.NULL(W_OVER.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_8"))) & (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_8_S1")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_8_S2")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_8_S3")) == QDesign.NULL(W_OVER.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_9"))) & (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_9_S1")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_9_S2")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_9_S3")) == QDesign.NULL(W_OVER.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_10"))) & (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_10_S1")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_10_S2")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_10_S3")) == QDesign.NULL(W_OVER.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_11"))) & (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_11_S1")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_11_S2")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_11_S3")) == QDesign.NULL(W_OVER.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_12"))) & (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_12_S1")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_12_S2")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_12_S3")) == QDesign.NULL(W_OVER.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_13"))) & (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_13_S1")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_13_S2")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_13_S3")) == QDesign.NULL(W_OVER.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_14"))) & (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_14_S1")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_14_S2")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_14_S3")) == QDesign.NULL(W_OVER.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_15"))) & (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_15_S1")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_15_S2")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_15_S3")) == QDesign.NULL(W_OVER.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_16"))) & (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_16_S1")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_16_S2")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_16_S3")) == QDesign.NULL(W_OVER.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_17"))) & (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_17_S1")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_17_S2")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_17_S3")) == QDesign.NULL(W_OVER.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_18"))) & (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_18_S1")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_18_S2")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_18_S3")) == QDesign.NULL(W_OVER.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_19"))) & (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_19_S1")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_19_S2")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_19_S3")) == QDesign.NULL(W_OVER.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_20"))) & (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_20_S1")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_20_S2")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_20_S3")) == QDesign.NULL(W_OVER.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_21"))) & (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_21_S1")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_21_S2")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_21_S3")) == QDesign.NULL(W_OVER.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_22"))) & (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_22_S1")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_22_S2")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_22_S3")) == QDesign.NULL(W_OVER.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_23"))) & (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_23_S1")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_23_S2")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_23_S3")) == QDesign.NULL(W_OVER.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_24"))) & (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_24_S1")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_24_S2")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_24_S3")) == QDesign.NULL(W_OVER.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_25"))) & (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_25_S1")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_25_S2")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_25_S3")) == QDesign.NULL(W_OVER.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_26"))) & (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_26_S1")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_26_S2")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_26_S3")) == QDesign.NULL(W_OVER.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_27"))) & (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_27_S1")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_27_S2")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_27_S3")) == QDesign.NULL(W_OVER.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_28"))) & (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_28_S1")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_28_S2")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_28_S3")) == QDesign.NULL(W_OVER.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_29"))) & (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_29_S1")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_29_S2")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_29_S3")) == QDesign.NULL(W_OVER.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_30"))) & (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_30_S1")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_30_S2")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_30_S3")) == QDesign.NULL(W_OVER.Value))))))))
            {
                CurrentValue = fleF020_DOCTOR_MSTR.GetStringValue("GROUP_OVER_SERVICED");
            }
            else if (((QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("GROUP_REGULAR_SERVICE")) != QDesign.NULL("    ")) & (((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_1"))) & (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_1_S1")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_1_S2")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_1_S3")) == QDesign.NULL(W_REGULAR.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_2"))) & (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_2_S1")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_2_S2")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_2_S3")) == QDesign.NULL(W_REGULAR.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_3"))) & (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_3_S1")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_3_S2")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_3_S3")) == QDesign.NULL(W_REGULAR.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_4"))) & (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_4_S1")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_4_S2")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_4_S3")) == QDesign.NULL(W_REGULAR.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_5"))) & (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_5_S1")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_5_S2")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_5_S3")) == QDesign.NULL(W_REGULAR.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_6"))) & (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_6_S1")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_6_S2")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_6_S3")) == QDesign.NULL(W_REGULAR.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_7"))) & (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_7_S1")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_7_S2")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_7_S3")) == QDesign.NULL(W_REGULAR.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_8"))) & (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_8_S1")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_8_S2")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_8_S3")) == QDesign.NULL(W_REGULAR.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_9"))) & (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_9_S1")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_9_S2")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_9_S3")) == QDesign.NULL(W_REGULAR.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_10"))) & (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_10_S1")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_10_S2")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_10_S3")) == QDesign.NULL(W_REGULAR.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_11"))) & (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_11_S1")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_11_S2")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_11_S3")) == QDesign.NULL(W_REGULAR.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_12"))) & (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_12_S1")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_12_S2")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_12_S3")) == QDesign.NULL(W_REGULAR.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_13"))) & (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_13_S1")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_13_S2")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_13_S3")) == QDesign.NULL(W_REGULAR.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_14"))) & (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_14_S1")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_14_S2")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_14_S3")) == QDesign.NULL(W_REGULAR.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_15"))) & (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_15_S1")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_15_S2")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_15_S3")) == QDesign.NULL(W_REGULAR.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_16"))) & (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_16_S1")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_16_S2")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_16_S3")) == QDesign.NULL(W_REGULAR.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_17"))) & (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_17_S1")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_17_S2")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_17_S3")) == QDesign.NULL(W_REGULAR.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_18"))) & (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_18_S1")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_18_S2")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_18_S3")) == QDesign.NULL(W_REGULAR.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_19"))) & (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_19_S1")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_19_S2")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_19_S3")) == QDesign.NULL(W_REGULAR.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_20"))) & (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_20_S1")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_20_S2")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_20_S3")) == QDesign.NULL(W_REGULAR.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_21"))) & (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_21_S1")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_21_S2")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_21_S3")) == QDesign.NULL(W_REGULAR.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_22"))) & (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_22_S1")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_22_S2")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_22_S3")) == QDesign.NULL(W_REGULAR.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_23"))) & (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_23_S1")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_23_S2")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_23_S3")) == QDesign.NULL(W_REGULAR.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_24"))) & (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_24_S1")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_24_S2")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_24_S3")) == QDesign.NULL(W_REGULAR.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_25"))) & (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_25_S1")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_25_S2")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_25_S3")) == QDesign.NULL(W_REGULAR.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_26"))) & (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_26_S1")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_26_S2")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_26_S3")) == QDesign.NULL(W_REGULAR.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_27"))) & (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_27_S1")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_27_S2")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_27_S3")) == QDesign.NULL(W_REGULAR.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_28"))) & (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_28_S1")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_28_S2")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_28_S3")) == QDesign.NULL(W_REGULAR.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_29"))) & (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_29_S1")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_29_S2")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_29_S3")) == QDesign.NULL(W_REGULAR.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_30"))) & (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_30_S1")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_30_S2")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_30_S3")) == QDesign.NULL(W_REGULAR.Value))))))))
            {
                CurrentValue = fleF020_DOCTOR_MSTR.GetStringValue("GROUP_REGULAR_SERVICE");
            }
            else if (QDesign.NULL(W_DOC_CLINIC_NBR.Value) == QDesign.NULL(fleICONST_MSTR_REC.GetDecimalValue("ICONST_CLINIC_NBR_1_2")))
            {
                CurrentValue = fleICONST_MSTR_REC.GetStringValue("ICONST_CLINIC_NBR");
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
    private DDecimal W_DATE_FROM = new DDecimal("W_DATE_FROM");
    private void W_DATE_FROM_GetValue(ref decimal Value)
    {

        try
        {
            Value = (Convert.ToDecimal(Prompt(1)));


        }
        catch (CustomApplicationException ex)
        {
            WriteError(ex);


        }
        catch (Exception ex)
        {
            WriteError(ex);

        }



    }
    private DDecimal W_DATE_TO = new DDecimal("W_DATE_TO");
    private void W_DATE_TO_GetValue(ref decimal Value)
    {

        try
        {
            Value = (Convert.ToDecimal(Prompt(2)));


        }
        catch (CustomApplicationException ex)
        {
            WriteError(ex);


        }
        catch (Exception ex)
        {
            WriteError(ex);

        }



    }
    private DCharacter X_CLINIC_NBR_1_2 = new DCharacter("X_CLINIC_NBR_1_2", 2);
    private void X_CLINIC_NBR_1_2_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_BATCH_NBR") + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_CLAIM_NBR"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_OMA_CD") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_OMA_SUFF") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_ADJ_NBR"), 1, 2);
            //Parent:CLMHDR_CLAIM_ID


        }
        catch (CustomApplicationException ex)
        {
            WriteError(ex);


        }
        catch (Exception ex)
        {
            WriteError(ex);

        }

    }
    private DDecimal BALANCE_DUE = new DDecimal("BALANCE_DUE", 6);
    private void BALANCE_DUE_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_OMA_CD")) == "0000")
            {
                CurrentValue = fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP") + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_MANUAL_AND_TAPE_PAYMENTS");
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
    private DCharacter X_TEST_DATE = new DCharacter("X_TEST_DATE", 8);
    private void X_TEST_DATE_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(fleF002_CLAIMS_MSTR.GetNumericDateValue("CLMHDR_SUBMIT_DATE")) != 0)
            {
                CurrentValue = QDesign.ASCII(fleF002_CLAIMS_MSTR.GetNumericDateValue("CLMHDR_SUBMIT_DATE"), 8);
            }
            else
            {
                CurrentValue = fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_DATE_SYS");
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
    private DCharacter X_TEST_DAY = new DCharacter("X_TEST_DAY", 2);
    private void X_TEST_DAY_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.Substring(X_TEST_DATE.Value, 7, 2);


        }
        catch (CustomApplicationException ex)
        {
            WriteError(ex);


        }
        catch (Exception ex)
        {
            WriteError(ex);

        }



    }
    private DDecimal W_DAYS_SINCE_ENTRY = new DDecimal("W_DAYS_SINCE_ENTRY", 6);
    private void W_DAYS_SINCE_ENTRY_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_OMA_CD")) == "0000")
            {
                CurrentValue = QDesign.Days(QDesign.SysDate(ref m_cnnQUERY)) - QDesign.Days(QDesign.NConvert(X_TEST_DATE.Value));
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
    private DCharacter TWO_RATS_PROCESSED = new DCharacter("TWO_RATS_PROCESSED", 1);
    private void TWO_RATS_PROCESSED_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (string.Compare(X_TEST_DAY.Value, "18") <= 0 & W_DAYS_SINCE_ENTRY.Value >= 75)
            {
                CurrentValue = "Y";
            }
            else if (string.Compare(QDesign.NULL(X_TEST_DAY.Value), "18") > 0 & W_DAYS_SINCE_ENTRY.Value >= 90)
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
    private DDecimal X_DAYS_SINCE_PED = new DDecimal("X_DAYS_SINCE_PED", 6);
    private void X_DAYS_SINCE_PED_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_OMA_CD")) == "0000")
            {
                CurrentValue = QDesign.Days(QDesign.SysDate(ref m_cnnQUERY)) - QDesign.Days(fleF002_CLAIMS_MSTR.GetNumericDateValue("CLMHDR_DATE_PERIOD_END"));
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
    private DDecimal X_DAYS_SINCE_SERVICE = new DDecimal("X_DAYS_SINCE_SERVICE", 6);
    private void X_DAYS_SINCE_SERVICE_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_OMA_CD")) == "0000" & QDesign.NULL(fleF002_CLAIMS_MSTR.GetNumericDateValue("CLMHDR_SERV_DATE")) != 0)
            {
                CurrentValue = QDesign.Days(QDesign.SysDate(ref m_cnnQUERY)) - QDesign.Days(fleF002_CLAIMS_MSTR.GetNumericDateValue("CLMHDR_SERV_DATE"));
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
    private DCharacter W_MOH_LOCATION_CODE = new DCharacter("W_MOH_LOCATION_CODE", 4);
    private void W_MOH_LOCATION_CODE_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (!fleF030_LOCATIONS_MSTR.Exists())
            {
                CurrentValue = "    ";
            }
            else
            {
                CurrentValue = fleF030_LOCATIONS_MSTR.GetStringValue("LOC_SERVICE_LOCATION_INDICATOR");
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
    private DCharacter W_CLMHDR_HOSP = new DCharacter("W_CLMHDR_HOSP", 4);
    private void W_CLMHDR_HOSP_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (!fleF030_LOCATIONS_MSTR.Exists())
            {
                CurrentValue = "    ";
            }
            else if (QDesign.NULL(fleICONST_MSTR_REC.GetStringValue("ICONST_CLINIC_CARD_COLOUR")) == "Y")
            {
                CurrentValue = fleF030_LOCATIONS_MSTR.GetStringValue("LOC_HOSPITAL_CODE");
            }
            else
            {
                CurrentValue = QDesign.ASCII(fleF030_LOCATIONS_MSTR.GetDecimalValue("LOC_HOSPITAL_NBR"), 4);
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
    private DDecimal D_SYSDATE = new DDecimal("D_SYSDATE");
    private void D_SYSDATE_GetValue(ref decimal Value)
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

    private CoreDecimal X_REC_COUNT;



    private SqlFileObject fleU022A1;




    private SqlFileObject fleU022A1_AUDIT;


    #endregion


    #region "Standard Generated Procedures(U022A1_EXTRACT_1)"


    #region "Automatic Item Initialization(U022A1_EXTRACT_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U022A1_EXTRACT_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:08:14 PM

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
        fleF002_OUTSTANDING.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleCONTRACT_DTL.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF010_PAT_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleICONST_MSTR_REC.Transaction = m_trnTRANS_UPDATE;
        fleF030_LOCATIONS_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleU022A1.Transaction = m_trnTRANS_UPDATE;
        fleU022A1_AUDIT.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U022A1_EXTRACT_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:08:14 PM

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
            fleF002_OUTSTANDING.Dispose();
            fleF002_CLAIMS_MSTR.Dispose();
            fleCONTRACT_DTL.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleF010_PAT_MSTR.Dispose();
            fleICONST_MSTR_REC.Dispose();
            fleF030_LOCATIONS_MSTR.Dispose();
            fleU022A1.Dispose();
            fleU022A1_AUDIT.Dispose();


        }
        catch (CustomApplicationException ex)
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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U022A1_EXTRACT_1)"


    public void Run()
    {

        try
        {
            Request("EXTRACT_1");

            while (fleF002_OUTSTANDING.QTPForMissing())
            {
                // --> GET F002_OUTSTANDING <--

                fleF002_OUTSTANDING.GetData();
                // --> End GET F002_OUTSTANDING <--

                while (fleF002_CLAIMS_MSTR.QTPForMissing("1"))
                {
                    // --> GET F002_CLAIMS_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF002_OUTSTANDING.GetStringValue("KEY_CLM_TYPE")));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF002_OUTSTANDING.GetStringValue("KEY_CLM_BATCH_NBR")));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ");
                    m_strWhere.Append((fleF002_OUTSTANDING.GetDecimalValue("KEY_CLM_CLAIM_NBR")));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_SERV_CODE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("00000"));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_ADJ_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("0"));

                    fleF002_CLAIMS_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F002_CLAIMS_MSTR <--

                    while (fleCONTRACT_DTL.QTPForMissing("2"))
                    {
                        // --> GET CONTRACT_DTL <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleCONTRACT_DTL.ElementOwner("CLINIC_NBR")).Append(" = ");
                        m_strWhere.Append((QDesign.NConvert(QDesign.Substring(fleF002_OUTSTANDING.GetStringValue("KEY_CLM_BATCH_NBR"), 1, 2))));
                        m_strWhere.Append(" And ").Append(fleCONTRACT_DTL.ElementOwner("AGENT_CD")).Append(" = ");
                        m_strWhere.Append((fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_AGENT_CD")));

                        fleCONTRACT_DTL.GetData(m_strWhere.ToString());
                        // --> End GET CONTRACT_DTL <--

                        while (fleF020_DOCTOR_MSTR.QTPForMissing("3"))
                        {
                            // --> GET F020_DOCTOR_MSTR <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                            m_strWhere.Append(Common.StringToField(QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("KEY_CLM_BATCH_NBR"), 3, 3)));

                            fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString());
                            // --> End GET F020_DOCTOR_MSTR <--

                            while (fleF010_PAT_MSTR.QTPForMissing("4"))
                            {
                                // --> GET F010_PAT_MSTR <--
                                m_strWhere = new StringBuilder(" WHERE ");
                                m_strWhere.Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_I_KEY")).Append(" = ");
                                m_strWhere.Append(Common.StringToField(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_TYPE")));
                                //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART    'Parent:KEY_PAT_MSTR
                                m_strWhere.Append(" AND ").Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_CON_NBR")).Append(" = ");
                                m_strWhere.Append(Common.StringToField((fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_TYPE") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_DATA")).PadRight(16).Substring(1, 2)));
                                //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART    'Parent:KEY_PAT_MSTR
                                m_strWhere.Append(" AND ").Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_I_NBR")).Append(" = ");
                                m_strWhere.Append(Common.StringToField((fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_TYPE") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_DATA")).PadRight(16).Substring(3, 12)));
                                //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART    'Parent:KEY_PAT_MSTR
                                m_strWhere.Append(" AND ").Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("FILLER4")).Append(" = ");
                                m_strWhere.Append(Common.StringToField((fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_TYPE") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_DATA")).PadRight(16).Substring(15, 1)));
                                //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART    'Parent:KEY_PAT_MSTR

                                fleF010_PAT_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                // --> End GET F010_PAT_MSTR <--

                                while (fleICONST_MSTR_REC.QTPForMissing("5"))
                                {
                                    // --> GET ICONST_MSTR_REC <--
                                    m_strWhere = new StringBuilder(" WHERE ");
                                    m_strWhere.Append(" ").Append(fleICONST_MSTR_REC.ElementOwner("ICONST_CLINIC_NBR_1_2")).Append(" = ");
                                    m_strWhere.Append((QDesign.NConvert(QDesign.Substring(fleF002_OUTSTANDING.GetStringValue("KEY_CLM_BATCH_NBR"), 1, 2))));

                                    fleICONST_MSTR_REC.GetData(m_strWhere.ToString());
                                    // --> End GET ICONST_MSTR_REC <--

                                    while (fleF030_LOCATIONS_MSTR.QTPForMissing("6"))
                                    {
                                        // --> GET F030_LOCATIONS_MSTR <--
                                        m_strWhere = new StringBuilder(" WHERE ");
                                        m_strWhere.Append(" ").Append(fleF030_LOCATIONS_MSTR.ElementOwner("LOC_NBR")).Append(" = ");
                                        m_strWhere.Append(Common.StringToField(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_LOC")));

                                        fleF030_LOCATIONS_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                        // --> End GET F030_LOCATIONS_MSTR <--


                                        if (Transaction())
                                        {

                                             if (Select_If())
                                            {
                                                X_REC_COUNT.Value = X_REC_COUNT.Value + 1;

                                                SubFile(ref m_trnTRANS_UPDATE, ref fleU022A1, SubFileType.Keep, fleF002_CLAIMS_MSTR, "KEY_CLM_TYPE", "KEY_CLM_BATCH_NBR", "KEY_CLM_CLAIM_NBR", "CLMHDR_BATCH_TYPE", "CLMHDR_DOC_NBR_OHIP", "CLMHDR_DATE_SYS",
                                                "CLMHDR_CLAIM_ID", "CLMHDR_CLAIM_NBR", W_CLMHDR_HOSP, "CLMHDR_DATE_ADMIT", "CLMHDR_PAT_OHIP_ID_OR_CHART", "CLMHDR_REFER_DOC_NBR", "CLMHDR_LOC", "CLMHDR_I_O_PAT_IND", "CLMHDR_AGENT_CD", "CLMHDR_TOT_CLAIM_AR_OMA",
                                                "CLMHDR_TOT_CLAIM_AR_OHIP", "CLMHDR_STATUS_OHIP", "CLMHDR_DOC_DEPT", "CLMHDR_DOC_SPEC_CD", "CLMHDR_SUB_NBR", "CLMHDR_MANUAL_REVIEW", fleCONTRACT_DTL, "DOLLAR_FLAG", "MOH_FLAG", TRANSLATED_GROUP_NBR,
                                                W_MOH_LOCATION_CODE, "CONTRACT_CODE");



                                                SubFile(ref m_trnTRANS_UPDATE, ref fleU022A1_AUDIT, SubFileType.Keep, fleF002_CLAIMS_MSTR, "CLMHDR_TAPE_SUBMIT_IND", "KEY_CLM_TYPE", "KEY_CLM_BATCH_NBR", "KEY_CLM_CLAIM_NBR", "CLMHDR_BATCH_TYPE", "CLMHDR_ADJ_OMA_CD",
                                                fleCONTRACT_DTL, "MOH_FLAG", BALANCE_DUE, fleF002_CLAIMS_MSTR, "CLMHDR_TOT_CLAIM_AR_OHIP", "CLMHDR_MANUAL_AND_TAPE_PAYMENTS", "CLMHDR_STATUS_OHIP", X_TEST_DATE, X_TEST_DAY, TWO_RATS_PROCESSED,
                                                "CLMHDR_DATE_CASH_TAPE_PAYMENT", "CLMHDR_DATE_SYS", X_DAYS_SINCE_SERVICE, D_SYSDATE, "CLMHDR_SUBMIT_DATE", X_REC_COUNT, "CLMHDR_SERV_DATE");



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
            EndRequest("EXTRACT_1");

        }

    }




    #endregion


}
//EXTRACT_1




