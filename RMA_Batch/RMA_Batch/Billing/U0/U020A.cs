
#region "Screen Comments"

// #> PROGRAM-ID.     U020A.QTS
// ((C)) Dyad Technologies
// PROGRAM PURPOSE : READ F001-BATCH-CONTROL-FILE AND SELECT
// BALANCED BATCHES WITHING PED AND CYCLE #,
// LINK TO CLAIMS, PATIENTS, AND DOCTOR FILES
// AND EXTRACT DATA NEEDED FOR OHIP TAPE OR
// CLAIM SHADOW
// IF CHANGES REQUIRED FOR HOSPITAL CODES, MAKE
// SURE TO CHANGE IN HOSPITAL_CODE.DEF
// MODIFICATION HISTORY
// DATE   WHO          DESCRIPTION
// 91/FEB/12 D.B.         - ORIGINAL (SMS 138)
// 93/MAR/17 M.C.         - SMS 140
// - CONVERT THE FIRST PASS R020A1 INTO
// HERE U020A.QTS
// 93/MAY/06 M.C.            - SMS 141
// - ADD PAT-MESS-CODE IN EACH SUBFILE
// 96/JAN/16 M.C.         - PDR 636
// - SELECT BATCTRL-STATUS = `2` INSTEAD OF
// `1` (BATCHES HAVE GONE THROUGH U010DAILY)
// 97/JUN/04 K.M.         - LINKED RECORD STRUCTURE TO
// F020-DOCTOR-MSTR TO DETERMINE WHICH
// GROUP NUMBER TO USE FOR EACH RECORD AND
// SORTED THE DATASET ON THAT NUMBER
// 97/AUG/08 B.E.         - MADE LINK TO DOCTOR MSTR OPTIONAL
// SO THAT ADJUSTMENT/PAYMENT BATCHES
// COULD BE PROCESSED IN THIS PROGRAM.
// SEE COMMENTS BEFORE ACCESS STATEMENT
// FOR MORE DETAILS.
// 98/JAN/18 M.C.        - ADD REQUEST STATEMENT WITH EXCEPTIONAL
// ERRORS REPORT
// 99/feb/09 B.E         - no y2k changes needed 
// 99/may/05 B.E. - clmhdr-hosp field no longer contains actual hospital
// code.
// if this field contains  Y  then use clmhdr-loc to
// access location master to obtain correct hospital code
// - also pickup new moh location code from the f030 file
// - u020a1 now contains new moh location code
// 1999/May/21 S.B.      - Added the use file
// def_batctrl_batch_status.def to 
// prevent hardcoding of batctrl-batch-status.
// 1999/Jun/03 S.B. - Altered the call for def_group_nbr.use to call
// 1999/jul/21 B.E.      - fixed bug that caused `zero` hospital to go on tape 
// - now blank if not a valid hospital.
// 99/aug/25 B.E.        - calculation of hospital nbr now based solely on
// existance of location code and not patient i/o ind.
// 03/aug/07 M.C.  - include contract-code in the subfile, so that in u020b.qts, sort
// on contract-code before any other sort fields; contract D contains
// all 60`s clinics
// 03/dec/19 A.A.  - alpha doctor nbr
// 04/feb/26 M.C.  - change/extend the definition of w-clmhdr-hosp
// 04/may/19 M.C.  - modify the value check on afp-flag(iconst-clinic-card-colour)
// - value `O` represents old afp  
// 06/apr/10 M.C. - effective Apr 1, 2006, do not require to submit loc-ministry-loc-code
// - use service location indicator instead
// 07/apr/09 yas. - add u020a1_e for the new contract code  E  
// for AFP Diagnostic clinic 


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U020A : BaseClassControl
{

    private U020A m_U020A;

    public U020A(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public U020A(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_U020A != null))
        {
            m_U020A.CloseTransactionObjects();
            m_U020A = null;
        }
    }

    public U020A GetU020A(int Level)
    {
        if (m_U020A == null)
        {
            m_U020A = new U020A("U020A", Level);
        }
        else
        {
            m_U020A.ResetValues();
        }
        return m_U020A;
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

            U020A_EXTRACT_1 EXTRACT_1 = new U020A_EXTRACT_1(Name, Level);
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



public class U020A_EXTRACT_1 : U020A
{

    public U020A_EXTRACT_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF001_BATCH_CONTROL_FILE = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F001_BATCH_CONTROL_FILE", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleCONTRACT_DTL = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "CONTRACT_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF010_PAT_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F010_PAT_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleICONST_MSTR_REC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "ICONST_MSTR_REC", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF030_LOCATIONS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F030_LOCATIONS_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleU020A1_A = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U020A1_A", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU020A1_B = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U020A1_B", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU020A1_C = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U020A1_C", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU020A1_D = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U020A1_D", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU020A1_E = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U020A1_E", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        BATCTRL_BATCH_STATUS_UNBALANCED.GetValue += BATCTRL_BATCH_STATUS_UNBALANCED_GetValue;
        BATCTRL_BATCH_STATUS_BALANCED.GetValue += BATCTRL_BATCH_STATUS_BALANCED_GetValue;
        BATCTRL_BATCH_STATUS_REV_UPDATED.GetValue += BATCTRL_BATCH_STATUS_REV_UPDATED_GetValue;
        BATCTRL_BATCH_STATUS_OHIP_SENT.GetValue += BATCTRL_BATCH_STATUS_OHIP_SENT_GetValue;
        BATCTRL_BATCH_STATUS_MONTHEND_DONE.GetValue += BATCTRL_BATCH_STATUS_MONTHEND_DONE_GetValue;
        W_MOH_LOCATION_CODE.GetValue += W_MOH_LOCATION_CODE_GetValue;
        W_CLMHDR_HOSP.GetValue += W_CLMHDR_HOSP_GetValue;
        W_PAT_OHIP_MMYY.GetValue += W_PAT_OHIP_MMYY_GetValue;
        W_PAT_SEX.GetValue += W_PAT_SEX_GetValue;
        DOC_NBR.GetValue += DOC_NBR_GetValue;
        W_REGULAR.GetValue += W_REGULAR_GetValue;
        W_OVER.GetValue += W_OVER_GetValue;
        IN_LOC.GetValue += IN_LOC_GetValue;
        IN_SPEC.GetValue += IN_SPEC_GetValue;
        W_DOC_CLINIC_NBR.GetValue += W_DOC_CLINIC_NBR_GetValue;
        TRANSLATED_GROUP_NBR.GetValue += TRANSLATED_GROUP_NBR_GetValue;
        CLMHDR_CLAIM_ID.GetValue += CLMHDR_CLAIM_ID_GetValue;
                
        fleF001_BATCH_CONTROL_FILE.SelectIf += fleF001_BATCH_CONTROL_FILE_SelectIf;
        fleF002_CLAIMS_MSTR.SelectIf += fleF002_CLAIMS_MSTR_SelectIf;
        ICONST_DATE_PERIOD_END.GetValue += ICONST_DATE_PERIOD_END_GetValue;
    }

    #region "Declarations (Variables, Files and Transactions)(U020A_EXTRACT_1)"

    private SqlFileObject fleF001_BATCH_CONTROL_FILE;

    private void fleF001_BATCH_CONTROL_FILE_SelectIf(ref string SelectIfClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(" (    ").Append(fleF001_BATCH_CONTROL_FILE.ElementOwner("BATCTRL_BATCH_STATUS")).Append(" =  ").Append(Common.StringToField(BATCTRL_BATCH_STATUS_REV_UPDATED.Value)).Append(" )");


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

    private SqlFileObject fleCONTRACT_DTL;
    private SqlFileObject fleF002_CLAIMS_MSTR;

    private void fleF002_CLAIMS_MSTR_SelectIf(ref string SelectIfClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(" (    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMHDR_ADJ_OMA_CD")).Append(" =  '0000')");


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

    private SqlFileObject fleF010_PAT_MSTR;
    private SqlFileObject fleICONST_MSTR_REC;
    private SqlFileObject fleF020_DOCTOR_MSTR;
    private SqlFileObject fleF030_LOCATIONS_MSTR;
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
    private DCharacter W_PAT_OHIP_MMYY = new DCharacter("W_PAT_OHIP_MMYY", 15);
    private void W_PAT_OHIP_MMYY_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(fleF010_PAT_MSTR.GetDecimalValue("PAT_HEALTH_NBR")) == 0 
                & QDesign.NULL(QDesign.ASCII(fleF010_PAT_MSTR.GetStringValue("PAT_DIRECT_ALPHA"), 3) + 
                QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_DIRECT_YY"), 2) +
                QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_DIRECT_MM"), 2) +
                QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_DIRECT_DD"), 2) +
                QDesign.ASCII(fleF010_PAT_MSTR.GetStringValue("PAT_DIRECT_LAST_6"), 6)) != QDesign.NULL(" "))
            {
                CurrentValue = QDesign.ASCII(fleF010_PAT_MSTR.GetStringValue("PAT_DIRECT_ALPHA"), 3) + 
                    QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_DIRECT_YY"), 2) +
                    QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_DIRECT_MM"), 2) +
                    QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_DIRECT_DD"), 2) +
                    QDesign.ASCII(fleF010_PAT_MSTR.GetStringValue("PAT_DIRECT_LAST_6"), 6);
                //Parent:PAT_OHIP_MMYY
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
    private DCharacter W_PAT_SEX = new DCharacter("W_PAT_SEX", 1);
    private void W_PAT_SEX_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("PAT_SEX")) == "M")
            {
                CurrentValue = "1";
            }
            else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("PAT_SEX")) == "F")
            {
                CurrentValue = "2";
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
    private DCharacter DOC_NBR = new DCharacter("DOC_NBR", 3);
    private void DOC_NBR_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_BATCH_NBR") + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_CLAIM_NBR"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_OMA_CD") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_OMA_SUFF") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_ADJ_NBR"), 3, 3);
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



    private DDecimal ICONST_DATE_PERIOD_END = new DDecimal("ICONST_DATE_PERIOD_END", 8);
    private void ICONST_DATE_PERIOD_END_GetValue(ref decimal Value)
    {

        try
        {
            Value = QDesign.NConvert(QDesign.ASCII(fleICONST_MSTR_REC.GetDecimalValue("ICONST_DATE_PERIOD_END_YY"), 4) + QDesign.ASCII(fleICONST_MSTR_REC.GetDecimalValue("ICONST_DATE_PERIOD_END_MM"), 2) + QDesign.ASCII(fleICONST_MSTR_REC.GetDecimalValue("ICONST_DATE_PERIOD_END_DD"), 2));



        }
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
            if (((QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("GROUP_OVER_SERVICED")) != QDesign.NULL("    ")) && (((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_1"))) && (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_1_S1")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_1_S2")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_1_S3")) == QDesign.NULL(W_OVER.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_2"))) && (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_2_S1")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_2_S2")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_2_S3")) == QDesign.NULL(W_OVER.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_3"))) && (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_3_S1")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_3_S2")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_3_S3")) == QDesign.NULL(W_OVER.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_4"))) && (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_4_S1")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_4_S2")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_4_S3")) == QDesign.NULL(W_OVER.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_5"))) && (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_5_S1")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_5_S2")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_5_S3")) == QDesign.NULL(W_OVER.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_6"))) && (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_6_S1")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_6_S2")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_6_S3")) == QDesign.NULL(W_OVER.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_7"))) && (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_7_S1")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_7_S2")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_7_S3")) == QDesign.NULL(W_OVER.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_8"))) && (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_8_S1")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_8_S2")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_8_S3")) == QDesign.NULL(W_OVER.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_9"))) && (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_9_S1")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_9_S2")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_9_S3")) == QDesign.NULL(W_OVER.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_10"))) && (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_10_S1")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_10_S2")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_10_S3")) == QDesign.NULL(W_OVER.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_11"))) && (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_11_S1")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_11_S2")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_11_S3")) == QDesign.NULL(W_OVER.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_12"))) && (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_12_S1")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_12_S2")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_12_S3")) == QDesign.NULL(W_OVER.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_13"))) && (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_13_S1")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_13_S2")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_13_S3")) == QDesign.NULL(W_OVER.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_14"))) && (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_14_S1")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_14_S2")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_14_S3")) == QDesign.NULL(W_OVER.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_15"))) && (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_15_S1")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_15_S2")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_15_S3")) == QDesign.NULL(W_OVER.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_16"))) && (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_16_S1")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_16_S2")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_16_S3")) == QDesign.NULL(W_OVER.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_17"))) && (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_17_S1")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_17_S2")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_17_S3")) == QDesign.NULL(W_OVER.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_18"))) && (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_18_S1")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_18_S2")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_18_S3")) == QDesign.NULL(W_OVER.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_19"))) && (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_19_S1")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_19_S2")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_19_S3")) == QDesign.NULL(W_OVER.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_20"))) && (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_20_S1")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_20_S2")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_20_S3")) == QDesign.NULL(W_OVER.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_21"))) && (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_21_S1")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_21_S2")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_21_S3")) == QDesign.NULL(W_OVER.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_22"))) && (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_22_S1")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_22_S2")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_22_S3")) == QDesign.NULL(W_OVER.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_23"))) && (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_23_S1")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_23_S2")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_23_S3")) == QDesign.NULL(W_OVER.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_24"))) && (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_24_S1")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_24_S2")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_24_S3")) == QDesign.NULL(W_OVER.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_25"))) && (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_25_S1")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_25_S2")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_25_S3")) == QDesign.NULL(W_OVER.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_26"))) && (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_26_S1")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_26_S2")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_26_S3")) == QDesign.NULL(W_OVER.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_27"))) && (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_27_S1")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_27_S2")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_27_S3")) == QDesign.NULL(W_OVER.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_28"))) && (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_28_S1")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_28_S2")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_28_S3")) == QDesign.NULL(W_OVER.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_29"))) && (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_29_S1")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_29_S2")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_29_S3")) == QDesign.NULL(W_OVER.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_30"))) && (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_30_S1")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_30_S2")) == QDesign.NULL(W_OVER.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_30_S3")) == QDesign.NULL(W_OVER.Value))))))))
            {
                CurrentValue = fleF020_DOCTOR_MSTR.GetStringValue("GROUP_OVER_SERVICED");
            }
            else if (((QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("GROUP_REGULAR_SERVICE")) != QDesign.NULL("    ")) && (((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_1"))) && (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_1_S1")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_1_S2")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_1_S3")) == QDesign.NULL(W_REGULAR.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_2"))) && (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_2_S1")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_2_S2")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_2_S3")) == QDesign.NULL(W_REGULAR.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_3"))) && (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_3_S1")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_3_S2")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_3_S3")) == QDesign.NULL(W_REGULAR.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_4"))) && (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_4_S1")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_4_S2")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_4_S3")) == QDesign.NULL(W_REGULAR.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_5"))) && (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_5_S1")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_5_S2")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_5_S3")) == QDesign.NULL(W_REGULAR.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_6"))) && (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_6_S1")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_6_S2")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_6_S3")) == QDesign.NULL(W_REGULAR.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_7"))) && (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_7_S1")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_7_S2")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_7_S3")) == QDesign.NULL(W_REGULAR.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_8"))) && (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_8_S1")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_8_S2")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_8_S3")) == QDesign.NULL(W_REGULAR.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_9"))) && (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_9_S1")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_9_S2")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_9_S3")) == QDesign.NULL(W_REGULAR.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_10"))) && (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_10_S1")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_10_S2")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_10_S3")) == QDesign.NULL(W_REGULAR.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_11"))) && (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_11_S1")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_11_S2")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_11_S3")) == QDesign.NULL(W_REGULAR.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_12"))) && (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_12_S1")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_12_S2")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_12_S3")) == QDesign.NULL(W_REGULAR.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_13"))) && (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_13_S1")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_13_S2")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_13_S3")) == QDesign.NULL(W_REGULAR.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_14"))) && (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_14_S1")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_14_S2")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_14_S3")) == QDesign.NULL(W_REGULAR.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_15"))) && (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_15_S1")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_15_S2")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_15_S3")) == QDesign.NULL(W_REGULAR.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_16"))) && (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_16_S1")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_16_S2")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_16_S3")) == QDesign.NULL(W_REGULAR.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_17"))) && (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_17_S1")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_17_S2")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_17_S3")) == QDesign.NULL(W_REGULAR.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_18"))) && (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_18_S1")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_18_S2")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_18_S3")) == QDesign.NULL(W_REGULAR.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_19"))) && (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_19_S1")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_19_S2")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_19_S3")) == QDesign.NULL(W_REGULAR.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_20"))) && (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_20_S1")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_20_S2")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_20_S3")) == QDesign.NULL(W_REGULAR.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_21"))) && (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_21_S1")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_21_S2")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_21_S3")) == QDesign.NULL(W_REGULAR.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_22"))) && (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_22_S1")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_22_S2")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_22_S3")) == QDesign.NULL(W_REGULAR.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_23"))) && (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_23_S1")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_23_S2")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_23_S3")) == QDesign.NULL(W_REGULAR.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_24"))) && (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_24_S1")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_24_S2")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_24_S3")) == QDesign.NULL(W_REGULAR.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_25"))) && (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_25_S1")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_25_S2")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_25_S3")) == QDesign.NULL(W_REGULAR.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_26"))) && (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_26_S1")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_26_S2")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_26_S3")) == QDesign.NULL(W_REGULAR.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_27"))) && (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_27_S1")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_27_S2")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_27_S3")) == QDesign.NULL(W_REGULAR.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_28"))) && (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_28_S1")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_28_S2")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_28_S3")) == QDesign.NULL(W_REGULAR.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_29"))) && (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_29_S1")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_29_S2")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_29_S3")) == QDesign.NULL(W_REGULAR.Value))))) | ((QDesign.NULL(IN_LOC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_30"))) && (((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_30_S1")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_30_S2")) == QDesign.NULL(W_REGULAR.Value))) | ((QDesign.NULL(IN_SPEC.Value) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"))) && (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_30_S3")) == QDesign.NULL(W_REGULAR.Value))))))))
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

    private DCharacter CLMHDR_CLAIM_ID = new DCharacter("CLMHDR_CLAIM_ID", 16);
    private void CLMHDR_CLAIM_ID_GetValue(ref string Value)
    {

        try
        {
            Value = fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_BATCH_NBR") + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_CLAIM_NBR"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_OMA_CD") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_OMA_SUFF") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_ADJ_NBR");
        }

        catch (CustomApplicationException ex)
        {
            WriteError(ex);
        }

        catch (Exception ex)
        {
            WriteError(ex);
        }
    }

    private SqlFileObject fleU020A1_A;
    private SqlFileObject fleU020A1_B;
    private SqlFileObject fleU020A1_C;
    private SqlFileObject fleU020A1_D;
    private SqlFileObject fleU020A1_E;


    #endregion


    #region "Standard Generated Procedures(U020A_EXTRACT_1)"


    #region "Automatic Item Initialization(U020A_EXTRACT_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U020A_EXTRACT_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 12:28:04 PM

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
        fleF001_BATCH_CONTROL_FILE.Transaction = m_trnTRANS_UPDATE;
        fleCONTRACT_DTL.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF010_PAT_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleICONST_MSTR_REC.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF030_LOCATIONS_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleU020A1_A.Transaction = m_trnTRANS_UPDATE;
        fleU020A1_B.Transaction = m_trnTRANS_UPDATE;
        fleU020A1_C.Transaction = m_trnTRANS_UPDATE;
        fleU020A1_D.Transaction = m_trnTRANS_UPDATE;
        fleU020A1_E.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U020A_EXTRACT_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 12:28:04 PM

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
            fleF001_BATCH_CONTROL_FILE.Dispose();
            fleCONTRACT_DTL.Dispose();
            fleF002_CLAIMS_MSTR.Dispose();
            fleF010_PAT_MSTR.Dispose();
            fleICONST_MSTR_REC.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleF030_LOCATIONS_MSTR.Dispose();
            fleU020A1_A.Dispose();
            fleU020A1_B.Dispose();
            fleU020A1_C.Dispose();
            fleU020A1_D.Dispose();
            fleU020A1_E.Dispose();


        }
        catch (CustomApplicationException ex)
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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U020A_EXTRACT_1)"


    public void Run()
    {

        try
        {
            Request("EXTRACT_1");

            while (fleF001_BATCH_CONTROL_FILE.QTPForMissing())
            {
                // --> GET F001_BATCH_CONTROL_FILE <--

                fleF001_BATCH_CONTROL_FILE.GetData();
                // --> End GET F001_BATCH_CONTROL_FILE <--

                while (fleCONTRACT_DTL.QTPForMissing("1"))
                {
                    // --> GET CONTRACT_DTL <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleCONTRACT_DTL.ElementOwner("CLINIC_NBR")).Append(" = ");
                    m_strWhere.Append((QDesign.NConvert(QDesign.Substring(fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_BATCH_NBR"), 1, 2))));
                    m_strWhere.Append(" And ").Append(fleCONTRACT_DTL.ElementOwner("AGENT_CD")).Append(" = ");
                    m_strWhere.Append((fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_AGENT_CD")));

                    fleCONTRACT_DTL.GetData(m_strWhere.ToString());
                    // --> End GET CONTRACT_DTL <--

                    while (fleF002_CLAIMS_MSTR.QTPForMissing("2"))
                    {
                        // --> GET F002_CLAIMS_MSTR <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                        m_strWhere.Append(Common.StringToField("B"));
                        m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_BATCH_NBR")));

                        fleF002_CLAIMS_MSTR.GetData(m_strWhere.ToString());
                        // --> End GET F002_CLAIMS_MSTR <--

                        while (fleF010_PAT_MSTR.QTPForMissing("3"))
                        {
                            // --> GET F010_PAT_MSTR <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_I_KEY")).Append(" = ");
                            m_strWhere.Append(Common.StringToField(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_TYPE")));
                            //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART    'Parent:KEY_PAT_MSTR
                            m_strWhere.Append(" AND ").Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_CON_NBR")).Append(" = ");
                            m_strWhere.Append(QDesign.VAL2(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_DATA").PadRight(15).Substring(0, 2)));
                            //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART    'Parent:KEY_PAT_MSTR
                            m_strWhere.Append(" AND ").Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_I_NBR")).Append(" = ");
                            m_strWhere.Append(QDesign.VAL2(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_DATA").PadRight(15).Substring(2, 12)));
                            //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART    'Parent:KEY_PAT_MSTR
                            m_strWhere.Append(" AND ").Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("FILLER4")).Append(" = ");
                            m_strWhere.Append(Common.StringToField(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_DATA").PadRight(15).Substring(14, 1)));
                            //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART    'Parent:KEY_PAT_MSTR

                            fleF010_PAT_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                            // --> End GET F010_PAT_MSTR <--

                            while (fleICONST_MSTR_REC.QTPForMissing("4"))
                            {
                                // --> GET ICONST_MSTR_REC <--
                                m_strWhere = new StringBuilder(" WHERE ");
                                m_strWhere.Append(" ").Append(fleICONST_MSTR_REC.ElementOwner("ICONST_CLINIC_NBR_1_2")).Append(" = ");
                                m_strWhere.Append((QDesign.NConvert(QDesign.Substring(fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_BATCH_NBR"), 1, 2))));

                                fleICONST_MSTR_REC.GetData(m_strWhere.ToString());
                                // --> End GET ICONST_MSTR_REC <--

                                while (fleF020_DOCTOR_MSTR.QTPForMissing("5"))
                                {
                                    // --> GET F020_DOCTOR_MSTR <--
                                    m_strWhere = new StringBuilder(" WHERE ");
                                    m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                                    m_strWhere.Append(Common.StringToField((QDesign.Substring(fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_BATCH_NBR"), 3, 3))));

                                    fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                    // --> End GET F020_DOCTOR_MSTR <--

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

                                            Sort(TRANSLATED_GROUP_NBR.Value, CLMHDR_CLAIM_ID.Value);



                                        }

                                    }

                                }

                            }

                        }

                    }

                }

            }


            while (Sort(fleF001_BATCH_CONTROL_FILE, fleCONTRACT_DTL, fleF002_CLAIMS_MSTR, fleF010_PAT_MSTR, fleICONST_MSTR_REC, fleF020_DOCTOR_MSTR, fleF030_LOCATIONS_MSTR))
            {


                SubFile(ref m_trnTRANS_UPDATE, ref fleU020A1_A, QDesign.NULL(fleCONTRACT_DTL.GetStringValue("CONTRACT_CODE")) == "A", SubFileType.Keep, fleF001_BATCH_CONTROL_FILE, "BATCTRL_BATCH_NBR", "BATCTRL_BATCH_TYPE", "BATCTRL_CLINIC_NBR", "BATCTRL_DOC_NBR_OHIP", "BATCTRL_LOC",
                "BATCTRL_AGENT_CD", "BATCTRL_DATE_BATCH_ENTERED", fleICONST_MSTR_REC, "ICONST_CLINIC_NBR_1_2", "ICONST_CLINIC_CYCLE_NBR", ICONST_DATE_PERIOD_END, "ICONST_DATE_PERIOD_END_YY", "ICONST_DATE_PERIOD_END_MM", "ICONST_DATE_PERIOD_END_DD", fleF002_CLAIMS_MSTR,
                 "CLMHDR_BATCH_NBR", "CLMHDR_CLAIM_NBR", "CLMHDR_ADJ_OMA_CD", "CLMHDR_ADJ_OMA_SUFF", "CLMHDR_ADJ_ADJ_NBR", W_CLMHDR_HOSP,
                W_MOH_LOCATION_CODE, "CLMHDR_DATE_ADMIT", "CLMHDR_PAT_KEY_TYPE", "CLMHDR_PAT_KEY_DATA", "CLMHDR_REFER_DOC_NBR", "CLMHDR_LOC", "CLMHDR_I_O_PAT_IND", "CLMHDR_AGENT_CD", "CLMHDR_TOT_CLAIM_AR_OMA", "CLMHDR_TOT_CLAIM_AR_OHIP", "CLMHDR_STATUS_OHIP",
                "CLMHDR_SUB_NBR", "CLMHDR_MANUAL_REVIEW", DOC_NBR, "CLMHDR_DOC_DEPT", "CLMHDR_DOC_SPEC_CD", fleF010_PAT_MSTR, "PAT_HEALTH_NBR", "PAT_VERSION_CD", W_PAT_OHIP_MMYY, "PAT_CHART_NBR",
                "PAT_SURNAME_FIRST3", "PAT_SURNAME_LAST22", "PAT_GIVEN_NAME_FIRST1", "FILLER3", "PAT_ACRONYM_FIRST6", "PAT_ACRONYM_LAST3", "PAT_BIRTH_DATE_YY", "PAT_BIRTH_DATE_MM", "PAT_BIRTH_DATE_DD", W_PAT_SEX, "PAT_PROV_CD", "SUBSCR_ADDR1", "SUBSCR_ADDR2", "SUBSCR_ADDR3", "SUBSCR_POST_CD1", "SUBSCR_POST_CD2", "SUBSCR_POST_CD3", "SUBSCR_POST_CD4", "SUBSCR_POST_CD5", "SUBSCR_POST_CD6",
                fleCONTRACT_DTL, "MOH_FLAG", "DOLLAR_FLAG", fleF010_PAT_MSTR, "PAT_MESS_CODE", TRANSLATED_GROUP_NBR, fleCONTRACT_DTL, "CONTRACT_CODE");





                SubFile(ref m_trnTRANS_UPDATE, ref fleU020A1_B, QDesign.NULL(fleCONTRACT_DTL.GetStringValue("CONTRACT_CODE")) == "B", SubFileType.Keep, fleF001_BATCH_CONTROL_FILE, "BATCTRL_BATCH_NBR", "BATCTRL_BATCH_TYPE", "BATCTRL_CLINIC_NBR", "BATCTRL_DOC_NBR_OHIP", "BATCTRL_LOC",
                "BATCTRL_AGENT_CD", "BATCTRL_DATE_BATCH_ENTERED", fleICONST_MSTR_REC, "ICONST_CLINIC_NBR_1_2", "ICONST_CLINIC_CYCLE_NBR", ICONST_DATE_PERIOD_END, "ICONST_DATE_PERIOD_END_YY", "ICONST_DATE_PERIOD_END_MM", "ICONST_DATE_PERIOD_END_DD", fleF002_CLAIMS_MSTR,
                 "CLMHDR_BATCH_NBR", "CLMHDR_CLAIM_NBR", "CLMHDR_ADJ_OMA_CD", "CLMHDR_ADJ_OMA_SUFF", "CLMHDR_ADJ_ADJ_NBR", W_CLMHDR_HOSP,
                W_MOH_LOCATION_CODE, "CLMHDR_DATE_ADMIT", "CLMHDR_PAT_KEY_TYPE", "CLMHDR_PAT_KEY_DATA", "CLMHDR_REFER_DOC_NBR", "CLMHDR_LOC", "CLMHDR_I_O_PAT_IND", "CLMHDR_AGENT_CD", "CLMHDR_TOT_CLAIM_AR_OMA", "CLMHDR_TOT_CLAIM_AR_OHIP", "CLMHDR_STATUS_OHIP",
                "CLMHDR_SUB_NBR", "CLMHDR_MANUAL_REVIEW", DOC_NBR, "CLMHDR_DOC_DEPT", "CLMHDR_DOC_SPEC_CD", fleF010_PAT_MSTR, "PAT_HEALTH_NBR", "PAT_VERSION_CD", W_PAT_OHIP_MMYY, "PAT_CHART_NBR",
                "PAT_SURNAME_FIRST3", "PAT_SURNAME_LAST22", "PAT_GIVEN_NAME_FIRST1", "FILLER3", "PAT_ACRONYM_FIRST6", "PAT_ACRONYM_LAST3", "PAT_BIRTH_DATE_YY", "PAT_BIRTH_DATE_MM", "PAT_BIRTH_DATE_DD", W_PAT_SEX, "PAT_PROV_CD", "SUBSCR_ADDR1", "SUBSCR_ADDR2", "SUBSCR_ADDR3", "SUBSCR_POST_CD1", "SUBSCR_POST_CD2", "SUBSCR_POST_CD3", "SUBSCR_POST_CD4", "SUBSCR_POST_CD5", "SUBSCR_POST_CD6",
                fleCONTRACT_DTL, "MOH_FLAG", "DOLLAR_FLAG", fleF010_PAT_MSTR, "PAT_MESS_CODE", TRANSLATED_GROUP_NBR, fleCONTRACT_DTL, "CONTRACT_CODE");





                SubFile(ref m_trnTRANS_UPDATE, ref fleU020A1_C, QDesign.NULL(fleCONTRACT_DTL.GetStringValue("CONTRACT_CODE")) == "C", SubFileType.Keep, fleF001_BATCH_CONTROL_FILE, "BATCTRL_BATCH_NBR", "BATCTRL_BATCH_TYPE", "BATCTRL_CLINIC_NBR", "BATCTRL_DOC_NBR_OHIP", "BATCTRL_LOC",
                "BATCTRL_AGENT_CD", "BATCTRL_DATE_BATCH_ENTERED", fleICONST_MSTR_REC, "ICONST_CLINIC_NBR_1_2", "ICONST_CLINIC_CYCLE_NBR", ICONST_DATE_PERIOD_END,"ICONST_DATE_PERIOD_END_YY", "ICONST_DATE_PERIOD_END_MM", "ICONST_DATE_PERIOD_END_DD", fleF002_CLAIMS_MSTR,
                 "CLMHDR_BATCH_NBR", "CLMHDR_CLAIM_NBR", "CLMHDR_ADJ_OMA_CD", "CLMHDR_ADJ_OMA_SUFF", "CLMHDR_ADJ_ADJ_NBR", W_CLMHDR_HOSP,
                W_MOH_LOCATION_CODE, "CLMHDR_DATE_ADMIT", "CLMHDR_PAT_KEY_TYPE", "CLMHDR_PAT_KEY_DATA", "CLMHDR_REFER_DOC_NBR", "CLMHDR_LOC", "CLMHDR_I_O_PAT_IND", "CLMHDR_AGENT_CD", "CLMHDR_TOT_CLAIM_AR_OMA", "CLMHDR_TOT_CLAIM_AR_OHIP", "CLMHDR_STATUS_OHIP",
                "CLMHDR_SUB_NBR", "CLMHDR_MANUAL_REVIEW", DOC_NBR, "CLMHDR_DOC_DEPT", "CLMHDR_DOC_SPEC_CD", fleF010_PAT_MSTR, "PAT_HEALTH_NBR", "PAT_VERSION_CD", W_PAT_OHIP_MMYY, "PAT_CHART_NBR",
                "PAT_SURNAME_FIRST3", "PAT_SURNAME_LAST22", "PAT_GIVEN_NAME_FIRST1", "FILLER3", "PAT_ACRONYM_FIRST6", "PAT_ACRONYM_LAST3", "PAT_BIRTH_DATE_YY", "PAT_BIRTH_DATE_MM", "PAT_BIRTH_DATE_DD", W_PAT_SEX, "PAT_PROV_CD", "SUBSCR_ADDR1", "SUBSCR_ADDR2", "SUBSCR_ADDR3", "SUBSCR_POST_CD1", "SUBSCR_POST_CD2", "SUBSCR_POST_CD3", "SUBSCR_POST_CD4", "SUBSCR_POST_CD5", "SUBSCR_POST_CD6",
                fleCONTRACT_DTL, "MOH_FLAG", "DOLLAR_FLAG", fleF010_PAT_MSTR, "PAT_MESS_CODE", TRANSLATED_GROUP_NBR, fleCONTRACT_DTL, "CONTRACT_CODE");





                SubFile(ref m_trnTRANS_UPDATE, ref fleU020A1_D, QDesign.NULL(fleCONTRACT_DTL.GetStringValue("CONTRACT_CODE")) == "D", SubFileType.Keep, fleF001_BATCH_CONTROL_FILE, "BATCTRL_BATCH_NBR", "BATCTRL_BATCH_TYPE", "BATCTRL_CLINIC_NBR", "BATCTRL_DOC_NBR_OHIP", "BATCTRL_LOC",
                "BATCTRL_AGENT_CD", "BATCTRL_DATE_BATCH_ENTERED", fleICONST_MSTR_REC, "ICONST_CLINIC_NBR_1_2", "ICONST_CLINIC_CYCLE_NBR", ICONST_DATE_PERIOD_END, "ICONST_DATE_PERIOD_END_YY", "ICONST_DATE_PERIOD_END_MM", "ICONST_DATE_PERIOD_END_DD", fleF002_CLAIMS_MSTR,
                 "CLMHDR_BATCH_NBR", "CLMHDR_CLAIM_NBR", "CLMHDR_ADJ_OMA_CD", "CLMHDR_ADJ_OMA_SUFF", "CLMHDR_ADJ_ADJ_NBR", W_CLMHDR_HOSP,
                W_MOH_LOCATION_CODE, "CLMHDR_DATE_ADMIT", "CLMHDR_PAT_KEY_TYPE", "CLMHDR_PAT_KEY_DATA", "CLMHDR_REFER_DOC_NBR", "CLMHDR_LOC", "CLMHDR_I_O_PAT_IND", "CLMHDR_AGENT_CD", "CLMHDR_TOT_CLAIM_AR_OMA", "CLMHDR_TOT_CLAIM_AR_OHIP", "CLMHDR_STATUS_OHIP",
                "CLMHDR_SUB_NBR", "CLMHDR_MANUAL_REVIEW", DOC_NBR, "CLMHDR_DOC_DEPT", "CLMHDR_DOC_SPEC_CD", fleF010_PAT_MSTR, "PAT_HEALTH_NBR", "PAT_VERSION_CD", W_PAT_OHIP_MMYY, "PAT_CHART_NBR",
                "PAT_SURNAME_FIRST3", "PAT_SURNAME_LAST22", "PAT_GIVEN_NAME_FIRST1", "FILLER3", "PAT_ACRONYM_FIRST6", "PAT_ACRONYM_LAST3", "PAT_BIRTH_DATE_YY", "PAT_BIRTH_DATE_MM", "PAT_BIRTH_DATE_DD", W_PAT_SEX, "PAT_PROV_CD", "SUBSCR_ADDR1", "SUBSCR_ADDR2", "SUBSCR_ADDR3", "SUBSCR_POST_CD1", "SUBSCR_POST_CD2", "SUBSCR_POST_CD3", "SUBSCR_POST_CD4", "SUBSCR_POST_CD5", "SUBSCR_POST_CD6",
                fleCONTRACT_DTL, "MOH_FLAG", "DOLLAR_FLAG", fleF010_PAT_MSTR, "PAT_MESS_CODE", TRANSLATED_GROUP_NBR, fleCONTRACT_DTL, "CONTRACT_CODE");





                SubFile(ref m_trnTRANS_UPDATE, ref fleU020A1_E, QDesign.NULL(fleCONTRACT_DTL.GetStringValue("CONTRACT_CODE")) == "E", SubFileType.Keep, fleF001_BATCH_CONTROL_FILE, "BATCTRL_BATCH_NBR", "BATCTRL_BATCH_TYPE", "BATCTRL_CLINIC_NBR", "BATCTRL_DOC_NBR_OHIP", "BATCTRL_LOC",
                "BATCTRL_AGENT_CD", "BATCTRL_DATE_BATCH_ENTERED", fleICONST_MSTR_REC, "ICONST_CLINIC_NBR_1_2", "ICONST_CLINIC_CYCLE_NBR", ICONST_DATE_PERIOD_END, "ICONST_DATE_PERIOD_END_YY", "ICONST_DATE_PERIOD_END_MM", "ICONST_DATE_PERIOD_END_DD", fleF002_CLAIMS_MSTR,
                 "CLMHDR_BATCH_NBR", "CLMHDR_CLAIM_NBR", "CLMHDR_ADJ_OMA_CD", "CLMHDR_ADJ_OMA_SUFF", "CLMHDR_ADJ_ADJ_NBR", W_CLMHDR_HOSP,
                W_MOH_LOCATION_CODE, "CLMHDR_DATE_ADMIT", "CLMHDR_PAT_KEY_TYPE", "CLMHDR_PAT_KEY_DATA", "CLMHDR_REFER_DOC_NBR", "CLMHDR_LOC", "CLMHDR_I_O_PAT_IND", "CLMHDR_AGENT_CD", "CLMHDR_TOT_CLAIM_AR_OMA", "CLMHDR_TOT_CLAIM_AR_OHIP", "CLMHDR_STATUS_OHIP",
                "CLMHDR_SUB_NBR", "CLMHDR_MANUAL_REVIEW", DOC_NBR, "CLMHDR_DOC_DEPT", "CLMHDR_DOC_SPEC_CD", fleF010_PAT_MSTR, "PAT_HEALTH_NBR", "PAT_VERSION_CD", W_PAT_OHIP_MMYY, "PAT_CHART_NBR",
                "PAT_SURNAME_FIRST3", "PAT_SURNAME_LAST22", "PAT_GIVEN_NAME_FIRST1", "FILLER3", "PAT_ACRONYM_FIRST6", "PAT_ACRONYM_LAST3", "PAT_BIRTH_DATE_YY", "PAT_BIRTH_DATE_MM", "PAT_BIRTH_DATE_DD", W_PAT_SEX, "PAT_PROV_CD", "SUBSCR_ADDR1", "SUBSCR_ADDR2", "SUBSCR_ADDR3", "SUBSCR_POST_CD1", "SUBSCR_POST_CD2", "SUBSCR_POST_CD3", "SUBSCR_POST_CD4", "SUBSCR_POST_CD5", "SUBSCR_POST_CD6",
                fleCONTRACT_DTL, "MOH_FLAG", "DOLLAR_FLAG", fleF010_PAT_MSTR, "PAT_MESS_CODE", TRANSLATED_GROUP_NBR, fleCONTRACT_DTL, "CONTRACT_CODE");



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




