
#region "Screen Comments"

// m010.qks
// #> PROGRAM-ID.     M010.QKS
// ((C)) DYAD TECHNOLOGIES
// PROGRAM PURPOSE : TO ENTER PATIENT DATA
// MODIFICATION HISTORY
// DATE       WHO        DESCRIPTION
// 91/02/04   D.B.  -ORIGINAL (SMS 138)
// 91/05/30   D.B.  -PDR 496 - CHANGE NUMBER FOR NT AND BC
// 91/09/23   K.S.  -ADDED LOOKUP TABLE ON ACRONYM FIELD
// -ADDED PATH PROCEDURE
// 91/11/07   Y.B.         -PDR 532 - CHANGE BC FROM 10 AND 11
// DIGITS TO 10 AND SK FROM 8 DIGITS TO 9
// 91/11/13   M.C.  -IF BIRTHDATE CHANGED, CHECK PAT-OHIP-MMYY
// AND/OR PAT-CHART-NBR DOES NOT EXIST
// 92/10/13   Y.B.         - CHANGE NT FIRST DIGIT ALPHA N/D/M OR T
// THEN 7 NUMERIC
// 93/03/29   Y.B.         - CHANGE PROV ONT. TO ON FOR MAILING
// PURPOSES.
// 93/04/16   M.C.  - SMS 141
// - IF SPECIAL USER MODIFIES BIRTH DATE
// OR VERSION CD, UPDATE PAT-DATE-LAST-
// ELIG-MAIN TO SYSDATE, RESET MESS CODE
// TO BLANK, RESET 0 TO PAT-NO-OF-LETTER-
// SENT, UPDATE F086-PAT-ID FILE
// 93/05/18   M.C.  - PDR 572
// - IF USER ADDS OR CHANGES THE PATIENT
// BIRTH DATE, AND IT DOES NOT MATCH TO
// THE YYMM OF CHART NBR, DISPLAY A
// WARNING MESSAGE
// 93/06/11   Y.B.  - ADD PORT DOVER `PD` FOR CITY
// 93/07/14   M.C.  - TAKE OUT THE RESTRICTION ON LOGONID
// REQUESTED BY Y.B.
// 93/07/30   M.C.  - PDR 583
// - CREATE A NEW DESIGNER PROCEDURE `10`
// TO ALLOW USER TO CHANGE THE ADDRESS
// INFO PROPERLY (IE. DO NOT ALLOW USERS
// TO ENTER COUNTRY IF PROV-CD <> `XX`)
// 93/09/21   M.C.  - WHEN DELETING A PATIENT, CHECK THE
// OUTSTANDING CLAIMS INSTEAD OF TOTAL
// CLAIMS
// 94/03/21   M.C.  - EFFECTIVE 94/JAN/01, NOVA SCOTIA NBR
// IS TEN DIGITS
// 94/08/23   M.C.  - EFFECTIVE 94/JUL/01, ALBERTA NBR IS
// NINE DIGITS (PDR 601)
// 94/10/12   Y.B.  - MODIFY MANITOBA HEALTH NUMBER TO 9
// 94/11/08   Y.B.  - MODIFY MANITOBA HEALTH NUMBER TO 6
// 95/07/11   M.C.  - IN THE PREUPDATE PROCEDURE, CHECK TO
// MAKE SURE ONE OF HEALTH NBR, OHIP NBR,
// DIRECT ID OR CHART NBR MUST BE ENTERED
// AND PATIENT NAME MUST BE ENTERED
// 97/03/04   Y.B.  - MODIFY PE PAT-PROV-CD  PE  9 TO 8
// 98/03/94   M.C.  - SINCE HEALTH , OHIP & CHART KEY HAVE CHANGED
// FROM UNIQUE TO REPEATING, COMMENT OUT THE
// LOOKUP NOTON FILE ON FIELD STATEMENTS BUT
// DO THE GET FILE OPTIONAL IN EDIT PROCEDURE
// TO CHECK FOR DUPLICATE
// 99/jan/15  B.E.  - y2k (birth date), upshift acronym
// 1999/mar/25  B.E.         - allow change of ohip number to the `dummy`
// number (same as i-key-nbr) so that the
// user can  blank  out the field. Note that
// they can`t enter actual blanks due to the
// limitation on duplicate keys
// - if birth date changed, do duplicate ohip/direct
// key edit check only if these numbers where
// affected by the birth date change
// 99/07/28   Y.B.         -  add PAT-PROV-CD  NU  9 digits
// 00/02/09   B.E.  - edit that birth date can`t be > sysdate
// 00/05/29   B.E.  - rules for writing transactions to f086 to
// track change in patient eligibility changed
// to include change in health nbr
// 01/jan/24 B.E. - added MESS designer routine to allow user, after
// giving correct password, to blank Message Code field
// 01/sep/18 B.E. - added pat-ohip-validation-status field 
// 02/mar/27 M.C. - edit check on chart nbr to have prefix either `K`, `M`, 
// `H`, `0` and follow by 9 digits , 
// - elininate the edit check against birth yymm  with chart nbr
// 02/apr/02 M.C. - edit check on chart nbr to have prefix either `K`, `M`, 
// `H`, `1` or `5` and follow by 9 digits , 
// if prefix is `H`, 1st 4 bytes must be either H002 or H003  
// 02/apr/09 M.C. - General Hospital chart nbr should start with either 
// 0001 or 0005 and follow by 6 digits  
// 02/apr/12 M.C. - Yas requests to include St. Joseph Chart nbr which should 
// start with J0000 + 6 more digits  (11 characters in totals)
// 02/apr/29 M.C. - Brad requests that if user enters less than 10 digits 
// chart nbr where the first digit is either 0, 1 or 5, 
// add leading zeroes to the entered chart nbr
// 02/may/10 B.E. - chart nbr expanded from 1 field to 5 different fields with 
// a different chart-nbr for each hospitals - see dictionary
// for details
// - realignment of fields to fit in the additional chart nbrs
// - defaulting of province if city recognized as ON
// - added validation of subscr-prov-cd in dictionary 
// - removed access of pat-country field
// - subscr address line 1-3 increased in length
// 02/may/28 M.C. - apply the appropriate pattern for each chart nbr
// except pat-chart-nbr-5 which allows all patterns for
// entry mode
// - create edit/process procedures for chart nbr
// 02/sep/16 B.E. - size of 3rd address line increased from 21 back to 30 and
// relabelled CITY/CTRY(country)
// 03/jan/14 M.C. - change to use temp fields for key fields
// - suppress display key fields if they are same as ikey
// 03/may/15 M.C. - switch the label for eligibility maintained and mailing
// 03/sep/22 B.E. - St Joe`s Chart nbr edit changed from J000+6 to J+10 digits
// 04/jan/29 M.C. - change to check pat-prov-cd from NF to NL for Newfoundland
// 04/feb/25 M.C. - make the neccessary changes for eligibility changes to be the
// same as other pgms like d001, d003, u011 and newu703
// 2005/05/11 yas   - modify manitoba health number to be 9 digits
// 2005/06/08 M.C.  - modify to read pat-ohip-mmyy using fieldtext instead of
// t-pat-ohip-mmyy, so that user can blank out the field
// 2010/may/25 brad1- add reference to rejected-claims so that records in that file can be deleted
// if the patient`s version code is changed. This suppresses a letter being sent to the patient.
// 2010/aug/04 MC1  - do the same as above brad1 if the patient`s birth date is changed. 
// This suppresses a letter being sent to the patient.
// 2013/may/02 MC2  - add new designer `note` to call m010_crm.qks for bill direct purposes
// - add new designer `ins` to call m010_ins.qks for insurance company
// 2014/Feb/20 MC3  - add more edit on chart nbr, now allow chart nbr starts with D, E, F, W, ZB, J+8
// chart-nbr    -  `M` , `W`
// chart-nbr-2  -  `K`, `ZB`
// chart-nbr-3  -  `H002`, `H003`
// chart-nbr-4  -  `0001`, `0005`, `D`, `E`, `F`
// chart-nbr-5  -  `J`+10, `J`+8
// D = Haldimand War Memorial Hospital, Dunnville
// E = West Haldimand Hospital, Hagersville
// F = St. Peter`s Hospital, Hamilton
// W = West Lincoln Memorial Hospital - Grimsby
// ZB = Bay Area Genetics Lab
// 2015/Oct/28 MC4  - if part-chart-nbr-4 is blank , set as `?` + ikey[7:9]   

#endregion



using System;
using System.Text;
using System.Windows;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.ExceptionManagement;
using Core.Windows.UI.Core.Windows;
using Core.Windows.UI.Core.Windows.UI;
using System.Data.SqlClient;

namespace rma.Views
{

    partial class Billing_M010 : BasePage
    {

        #region " Form Designer Generated Code "





        public Billing_M010()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "M010";

            //# Set the ACTIVITIES for the screen.
            this.ChangeActivity = true;
            this.FindActivity = true;
            this.DeleteActivity = true;
            this.EntryActivity = true;
            this.UseAcceptProcessing = true;




















        }

        #endregion

        private void Page_Load(object sender, RoutedEventArgs e)
        {
            SetVariables();
            dsrDesigner_12.Click += dsrDesigner_12_Click;
            dsrDesigner_MESS.Click += dsrDesigner_MESS_Click;
            dsrDesigner_OCLM.Click += dsrDesigner_OCLM_Click;
            dsrDesigner_NOTE.Click += dsrDesigner_NOTE_Click;
            dsrDesigner_INS.Click += dsrDesigner_INS_Click;
            dsrDesigner_09.Click += dsrDesigner_09_Click;
            dsrDesigner_22.Click += dsrDesigner_22_Click;
            dsrDesigner_13.Click += dsrDesigner_13_Click;
            dsrDesigner_10.Click += dsrDesigner_10_Click;
            dsrDesigner_24.Click += dsrDesigner_24_Click;
            dsrDesigner_20.Click += dsrDesigner_20_Click;
            dsrDesigner_17.Click += dsrDesigner_17_Click;
            dsrDesigner_18.Click += dsrDesigner_18_Click;
            dsrDesigner_21.Click += dsrDesigner_21_Click;
            dsrDesigner_05.Click += dsrDesigner_05_Click;
            fldF010_PAT_MSTR_PAT_HEALTH_NBR.Input += fldF010_PAT_MSTR_PAT_HEALTH_NBR_Input;
            fldF010_PAT_MSTR_PAT_HEALTH_NBR.Edit += fldF010_PAT_MSTR_PAT_HEALTH_NBR_Edit;
            fldT_PAT_OHIP_MMYY.Edit += fldT_PAT_OHIP_MMYY_Edit;
            fldT_PAT_CHART_NBR_5.Input += fldT_PAT_CHART_NBR_5_Input;
            fldT_PAT_CHART_NBR_5.Edit += fldT_PAT_CHART_NBR_5_Edit;
            fldT_PAT_CHART_NBR.Edit += fldT_PAT_CHART_NBR_Edit;
            fldT_PAT_CHART_NBR_2.Edit += fldT_PAT_CHART_NBR_2_Edit;
            fldT_PAT_CHART_NBR_3.Edit += fldT_PAT_CHART_NBR_3_Edit;
            fldT_PAT_CHART_NBR_4.Input += fldT_PAT_CHART_NBR_4_Input;
            fldT_PAT_CHART_NBR_4.Edit += fldT_PAT_CHART_NBR_4_Edit;
            fldF010_PAT_MSTR_PAT_SURNAME.Edit += fldF010_PAT_MSTR_PAT_SURNAME_Edit;
            fldF010_PAT_MSTR_PAT_BIRTH_DATE.Edit += fldF010_PAT_MSTR_PAT_BIRTH_DATE_Edit;
            fldF010_PAT_MSTR_SUBSCR_MSG_NBR.Input += fldF010_PAT_MSTR_SUBSCR_MSG_NBR_Input;
            fldF010_PAT_MSTR_SUBSCR_MSG_NBR.Edit += fldF010_PAT_MSTR_SUBSCR_MSG_NBR_Edit;
            fldF010_PAT_MSTR_SUBSCR_DATE_MSG_NBR_EFFECTIVE_TO.Input += fldF010_PAT_MSTR_SUBSCR_DATE_MSG_NBR_EFFECTIVE_TO_Input;
            fldF010_PAT_MSTR_SUBSCR_DATE_MSG_NBR_EFFECTIVE_TO.Edit += fldF010_PAT_MSTR_SUBSCR_DATE_MSG_NBR_EFFECTIVE_TO_Edit;
            fldT_PAT_CHART_NBR_5.Process += fldT_PAT_CHART_NBR_5_Process;
            fldF010_PAT_MSTR_PAT_SURNAME.Process += fldF010_PAT_MSTR_PAT_SURNAME_Process;
            fldF010_PAT_MSTR_PAT_GIVEN_NAME.Process += fldF010_PAT_MSTR_PAT_GIVEN_NAME_Process;
            fldF010_PAT_MSTR_SUBSCR_ADDR3.Process += fldF010_PAT_MSTR_SUBSCR_ADDR3_Process;
            fldF010_PAT_MSTR_SUBSCR_MSG_NBR.Process += fldF010_PAT_MSTR_SUBSCR_MSG_NBR_Process;
            base.Page_Load();

            // TODO: The following FIELD(S) on the form are redefine elements.  Manual steps may be required:
            //       F010_PAT_MSTR.PAT_SURNAME
            //       F010_PAT_MSTR.PAT_EXPIRY_DATE
            //       F010_PAT_MSTR.SUBSCR_DATE_MSG_NBR_EFFECTIVE_TO
            //       F010_PAT_MSTR.PAT_ACRONYM
            //       F010_PAT_MSTR.PAT_GIVEN_NAME
            //       F010_PAT_MSTR.PAT_INIT
            //       F010_PAT_MSTR.PAT_BIRTH_DATE
            //       F010_PAT_MSTR.SUBSCR_POSTAL_CD
            //       F010_PAT_MSTR.KEY_PAT_MSTR


        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            W_CH16 = new CoreCharacter("W_CH16", 16, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
            T_PAT_OHIP_MMYY = new CoreCharacter("T_PAT_OHIP_MMYY", 15, this, Common.cEmptyString);
            T_PAT_CHART_NBR = new CoreCharacter("T_PAT_CHART_NBR", 10, this, Common.cEmptyString);
            T_PAT_CHART_NBR_2 = new CoreCharacter("T_PAT_CHART_NBR_2", 10, this, Common.cEmptyString);
            T_PAT_CHART_NBR_3 = new CoreCharacter("T_PAT_CHART_NBR_3", 10, this, Common.cEmptyString);
            T_PAT_CHART_NBR_4 = new CoreCharacter("T_PAT_CHART_NBR_4", 10, this, Common.cEmptyString);
            T_PAT_CHART_NBR_5 = new CoreCharacter("T_PAT_CHART_NBR_5", 11, this, Common.cEmptyString);
            fleF010_PAT_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F010_PAT_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            HOSP_SITE = new CoreCharacter("HOSP_SITE", 1, this, Common.cEmptyString);
            W_SKIP_SUBSCR_PROV_FIELD = new CoreCharacter("W_SKIP_SUBSCR_PROV_FIELD", 1, this, Common.cEmptyString);
            W_DOC_NBR = new CoreDecimal("W_DOC_NBR", 6, this);
            PAT_OHIP_MMYY_NUMERIC = new CoreDecimal("PAT_OHIP_MMYY_NUMERIC", 15, this);
            W_PORT_ID = new CoreDecimal("W_PORT_ID", 2, this);
            X_PAT_HEALTH_NBR = new CoreDecimal("X_PAT_HEALTH_NBR", 6, this);
            W_PAT_HEALTH_NBR = new CoreDecimal("W_PAT_HEALTH_NBR", 6, this);
            W_PAT_HEALTH_NBR_1 = new CoreDecimal("W_PAT_HEALTH_NBR_1", 6, this);
            W_PAT_HEALTH_NBR_3 = new CoreDecimal("W_PAT_HEALTH_NBR_3", 6, this);
            W_PAT_HEALTH_NBR_5 = new CoreDecimal("W_PAT_HEALTH_NBR_5", 6, this);
            W_PAT_HEALTH_NBR_7 = new CoreDecimal("W_PAT_HEALTH_NBR_7", 6, this);
            W_PAT_HEALTH_NBR_9 = new CoreDecimal("W_PAT_HEALTH_NBR_9", 6, this);
            W_PROV_LENGTH = new CoreDecimal("W_PROV_LENGTH", 6, this);
            W_MSG_NBR = new CoreCharacter("W_MSG_NBR", 2, this, Common.cEmptyString);
            W_PASSWORD = new CoreCharacter("W_PASSWORD", 5, this, Common.cEmptyString);
            W_OLD_BIRTH_DATE = new CoreDate("W_OLD_BIRTH_DATE", this);
            W_OLD_VERSION_CD = new CoreCharacter("W_OLD_VERSION_CD", 2, this, Common.cEmptyString);
            W_OLD_HEALTH_NBR = new CoreDecimal("W_OLD_HEALTH_NBR", 10, this);
            W_OLD_SURNAME = new CoreCharacter("W_OLD_SURNAME", 15, this, Common.cEmptyString);
            PAT_ACRONYM = new CoreCharacter("PAT_ACRONYM", 9, this, Common.cEmptyString);
            PAT_SURNAME = new CoreCharacter("PAT_SURNAME", 25, this, Common.cEmptyString);
            PAT_GIVEN_NAME = new CoreCharacter("PAT_GIVEN_NAME", 17, this, Common.cEmptyString);
            PAT_BIRTH_DATE = new CoreDecimal("PAT_GIVEN_NAME", 8, this);
            PAT_EXPIRY_DATE = new CoreDecimal("PAT_EXPIRY_DATE", 4, this);
            PAT_INIT = new CoreCharacter("PAT_GIVEN_NAME", 3, this, Common.cEmptyString);
            SUBSCR_DATE_MSG_NBR_EFFECTIVE_TO = new CoreDecimal("SUBSCR_DATE_MSG_NBR_EFFECTIVE_TO", 8, this);            
            SUBSCR_POST_CD = new CoreCharacter("SUBSCR_POST_CD", 6, this, Common.cEmptyString);
            KEY_PAT_MSTR = new CoreCharacter("KEY_PAT_MSTR", 16, this, Common.cEmptyString);
            W_OLD_GIVEN_NAME = new CoreCharacter("W_OLD_GIVEN_NAME", 12, this, Common.cEmptyString);
            W_OLD_CHART_NBR = new CoreCharacter("W_OLD_CHART_NBR", 10, this, Common.cEmptyString);
            W_OLD_CHART_NBR_2 = new CoreCharacter("W_OLD_CHART_NBR_2", 10, this, Common.cEmptyString);
            W_OLD_CHART_NBR_3 = new CoreCharacter("W_OLD_CHART_NBR_3", 10, this, Common.cEmptyString);
            W_OLD_CHART_NBR_4 = new CoreCharacter("W_OLD_CHART_NBR_4", 10, this, Common.cEmptyString);
            W_OLD_CHART_NBR_5 = new CoreCharacter("W_OLD_CHART_NBR_5", 11, this, Common.cEmptyString);
            W_OLD_ADDR1 = new CoreCharacter("W_OLD_ADDR1", 21, this, Common.cEmptyString);
            W_OLD_ADDR2 = new CoreCharacter("W_OLD_ADDR2", 21, this, Common.cEmptyString);
            W_OLD_ADDR3 = new CoreCharacter("W_OLD_ADDR3", 21, this, Common.cEmptyString);
            W_OLD_PAT_OHIP_MMYY = new CoreCharacter("W_OLD_PAT_OHIP_MMYY", 15, this, Common.cEmptyString);
            W_OLD_PAT_DIRECT = new CoreCharacter("W_OLD_PAT_DIRECT", 15, this, Common.cEmptyString);
            PAT_IKEY = new CoreCharacter("PAT_IKEY", 15, this, Common.cEmptyString);
            BATCH_NBR = new CoreCharacter("BATCH_NBR", 8, this, Common.cEmptyString);
            CLAIM_NBR = new CoreDecimal("CLAIM_NBR", 2, this);
            CALL_PGM = new CoreCharacter("CALL_PGM", 4, this, Common.cEmptyString);
            W_CCYY = new CoreDecimal("W_CCYY", 4, this);
            W_CC00 = new CoreDecimal("W_CC00", 4, this);
            W_YY = new CoreDecimal("W_YY", 2, this);
            W_CC000000 = new CoreDecimal("W_CC000000", 8, this);
            W_YYMMDD = new CoreDecimal("W_YYMMDD", 6, this);
            fleF010_PAT_KEYS = new SqlFileObject(this, FileTypes.Reference, 0, "INDEXED", "F010_PAT_MSTR", "F010_PAT_KEYS", false, false, false, 0, "m_cnnQUERY");
            fleCONSTANTS_MSTR_REC_5 = new SqlFileObject(this, FileTypes.Designer, 0, "INDEXED", "CONSTANTS_MSTR_REC_5", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleREJECTED_CLAIMS = new SqlFileObject(this, FileTypes.Designer, 0, "INDEXED", "REJECTED_CLAIMS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF094_MSG_MSTR = new SqlFileObject(this, FileTypes.Reference, 0, "INDEXED", "F094_MSG_MSTR", "", false, false, false, 0, "m_cnnQUERY");
            fleF086_PAT_ID = new SqlFileObject(this, FileTypes.Designer, 0, "INDEXED", "F086_PAT_ID", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF011_PAT_MSTR_ELIG_HISTORY = new SqlFileObject(this, FileTypes.Designer, 0, "INDEXED", "F011_PAT_MSTR_ELIG_HISTORY", "", false, false, false, 0, "m_trnTRANS_UPDATE");

            W_SUBSCR_ADDR3.GetValue += W_SUBSCR_ADDR3_GetValue;
            fleREJECTED_CLAIMS.Access += fleREJECTED_CLAIMS_Access;
            fleF094_MSG_MSTR.Access += fleF094_MSG_MSTR_Access;
            fleF010_PAT_MSTR.InitializeItems += fleF010_PAT_MSTR_InitializeItems;
        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;
            W_SUBSCR_ADDR3.GetValue -= W_SUBSCR_ADDR3_GetValue;
            fleREJECTED_CLAIMS.Access -= fleREJECTED_CLAIMS_Access;
            fleF094_MSG_MSTR.Access -= fleF094_MSG_MSTR_Access;
            fldF010_PAT_MSTR_PAT_HEALTH_NBR.Input -= fldF010_PAT_MSTR_PAT_HEALTH_NBR_Input;
            fldF010_PAT_MSTR_PAT_HEALTH_NBR.Edit -= fldF010_PAT_MSTR_PAT_HEALTH_NBR_Edit;
            fldT_PAT_OHIP_MMYY.Edit -= fldT_PAT_OHIP_MMYY_Edit;
            fldT_PAT_CHART_NBR_5.Input -= fldT_PAT_CHART_NBR_5_Input;
            fldT_PAT_CHART_NBR_5.Edit -= fldT_PAT_CHART_NBR_5_Edit;
            fldT_PAT_CHART_NBR.Edit -= fldT_PAT_CHART_NBR_Edit;
            fldT_PAT_CHART_NBR_2.Edit -= fldT_PAT_CHART_NBR_2_Edit;
            fldT_PAT_CHART_NBR_3.Edit -= fldT_PAT_CHART_NBR_3_Edit;
            fldT_PAT_CHART_NBR_4.Input -= fldT_PAT_CHART_NBR_4_Input;
            fldT_PAT_CHART_NBR_4.Edit -= fldT_PAT_CHART_NBR_4_Edit;
            fldF010_PAT_MSTR_PAT_SURNAME.Edit -= fldF010_PAT_MSTR_PAT_SURNAME_Edit;
            fldF010_PAT_MSTR_PAT_BIRTH_DATE.Edit -= fldF010_PAT_MSTR_PAT_BIRTH_DATE_Edit;
            fldF010_PAT_MSTR_SUBSCR_MSG_NBR.Input -= fldF010_PAT_MSTR_SUBSCR_MSG_NBR_Input;
            fldF010_PAT_MSTR_SUBSCR_MSG_NBR.Edit -= fldF010_PAT_MSTR_SUBSCR_MSG_NBR_Edit;
            fldF010_PAT_MSTR_SUBSCR_DATE_MSG_NBR_EFFECTIVE_TO.Input -= fldF010_PAT_MSTR_SUBSCR_DATE_MSG_NBR_EFFECTIVE_TO_Input;
            fldF010_PAT_MSTR_SUBSCR_DATE_MSG_NBR_EFFECTIVE_TO.Edit -= fldF010_PAT_MSTR_SUBSCR_DATE_MSG_NBR_EFFECTIVE_TO_Edit;
            fleF010_PAT_MSTR.InitializeItems -= fleF010_PAT_MSTR_InitializeItems;
            fleF010_PAT_MSTR.SetItemFinals -= fleF010_PAT_MSTR_SetItemFinals;
            dsrDesigner_12.Click -= dsrDesigner_12_Click;
            dsrDesigner_MESS.Click -= dsrDesigner_MESS_Click;
            dsrDesigner_OCLM.Click -= dsrDesigner_OCLM_Click;
            dsrDesigner_NOTE.Click -= dsrDesigner_NOTE_Click;
            dsrDesigner_INS.Click -= dsrDesigner_INS_Click;
            dsrDesigner_09.Click -= dsrDesigner_09_Click;
            dsrDesigner_22.Click -= dsrDesigner_22_Click;
            dsrDesigner_13.Click -= dsrDesigner_13_Click;
            dsrDesigner_10.Click -= dsrDesigner_10_Click;
            dsrDesigner_24.Click -= dsrDesigner_24_Click;
            dsrDesigner_20.Click -= dsrDesigner_20_Click;
            dsrDesigner_17.Click -= dsrDesigner_17_Click;
            dsrDesigner_18.Click -= dsrDesigner_18_Click;
            dsrDesigner_21.Click -= dsrDesigner_21_Click;
            dsrDesigner_05.Click -= dsrDesigner_05_Click;
            fldT_PAT_CHART_NBR_5.Process -= fldT_PAT_CHART_NBR_5_Process;
            fldF010_PAT_MSTR_PAT_SURNAME.Process -= fldF010_PAT_MSTR_PAT_SURNAME_Process;
            fldF010_PAT_MSTR_PAT_GIVEN_NAME.Process -= fldF010_PAT_MSTR_PAT_GIVEN_NAME_Process;
            fldF010_PAT_MSTR_SUBSCR_ADDR3.Process -= fldF010_PAT_MSTR_SUBSCR_ADDR3_Process;
            fldF010_PAT_MSTR_SUBSCR_MSG_NBR.Process -= fldF010_PAT_MSTR_SUBSCR_MSG_NBR_Process;
        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private SqlConnection m_cnnQUERY = new SqlConnection();
        private SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
        private SqlTransaction m_trnTRANS_UPDATE;
        private CoreCharacter W_CH16;
        private CoreCharacter T_PAT_OHIP_MMYY;
        private CoreCharacter T_PAT_CHART_NBR;
        private CoreCharacter T_PAT_CHART_NBR_2;
        private CoreCharacter T_PAT_CHART_NBR_3;
        private CoreCharacter T_PAT_CHART_NBR_4;
        private CoreCharacter T_PAT_CHART_NBR_5;
        private SqlFileObject fleF010_PAT_MSTR;

        private void fleF010_PAT_MSTR_InitializeItems(bool Fixed)
        {

            try
            {
                if (!Fixed)
                    fleF010_PAT_MSTR.set_SetValue("PAT_HEALTH_NBR", true, 0);
                if (!Fixed)
                    fleF010_PAT_MSTR.set_SetValue("PAT_CHART_NBR", true, " ");
                if (!Fixed)
                    fleF010_PAT_MSTR.set_SetValue("PAT_CHART_NBR_2", true, " ");
                if (!Fixed)
                    fleF010_PAT_MSTR.set_SetValue("PAT_CHART_NBR_3", true, " ");
                if (!Fixed)
                    fleF010_PAT_MSTR.set_SetValue("PAT_CHART_NBR_4", true, " ");
                if (!Fixed)
                    fleF010_PAT_MSTR.set_SetValue("PAT_CHART_NBR_5", true, " ");
                if (!Fixed)
                    fleF010_PAT_MSTR.set_SetValue("PAT_DATE_LAST_MAINT", true, QDesign.SysDate(ref m_cnnQUERY));
                if (!Fixed)
                    fleF010_PAT_MSTR.set_SetValue("PAT_I_KEY", true, "I");


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }

        private void fleF010_PAT_MSTR_SetItemFinals()
        {

            try
            {

                fleF010_PAT_MSTR.set_SetValue("PAT_ACRONYM_FIRST6", true, PAT_ACRONYM.Value.PadRight(9, ' ').Substring(0, 6).Trim());
                fleF010_PAT_MSTR.set_SetValue("PAT_ACRONYM_LAST3", true, PAT_ACRONYM.Value.PadRight(9, ' ').Substring(6, 3).Trim());

                fleF010_PAT_MSTR.set_SetValue("PAT_SURNAME_FIRST3", true, PAT_SURNAME.Value.PadRight(25, ' ').Substring(0, 3).Trim());
                fleF010_PAT_MSTR.set_SetValue("PAT_SURNAME_LAST22", true, PAT_SURNAME.Value.PadRight(25, ' ').Substring(3).Trim());

                fleF010_PAT_MSTR.set_SetValue("PAT_GIVEN_NAME_FIRST1", true, PAT_GIVEN_NAME.Value.PadRight(9, ' ').Substring(0, 1).Trim());
                fleF010_PAT_MSTR.set_SetValue("FILLER3", true, PAT_GIVEN_NAME.Value.PadRight(9, ' ').Substring(1).Trim());

                fleF010_PAT_MSTR.set_SetValue("PAT_INIT1", true, PAT_INIT.Value.PadRight(3, ' ').Substring(0, 1).Trim());
                fleF010_PAT_MSTR.set_SetValue("PAT_INIT2", true, PAT_INIT.Value.PadRight(3, ' ').Substring(1, 1).Trim());
                fleF010_PAT_MSTR.set_SetValue("PAT_INIT3", true, PAT_INIT.Value.PadRight(3, ' ').Substring(2).Trim());


                fleF010_PAT_MSTR.set_SetValue("PAT_BIRTH_DATE_YY", true, PAT_BIRTH_DATE.Value.ToString().PadLeft(8, '0').Substring(0, 4).Trim());
                fleF010_PAT_MSTR.set_SetValue("PAT_BIRTH_DATE_MM", true, PAT_BIRTH_DATE.Value.ToString().PadLeft(8, '0').Substring(4, 2).Trim());
                fleF010_PAT_MSTR.set_SetValue("PAT_BIRTH_DATE_DD", true, PAT_BIRTH_DATE.Value.ToString().PadLeft(8, '0').Substring(6, 2).Trim());

                fleF010_PAT_MSTR.set_SetValue("PAT_EXPIRY_YY", true, PAT_EXPIRY_DATE.Value.ToString().PadRight(4, '0').Substring(0, 2).Trim());
                fleF010_PAT_MSTR.set_SetValue("PAT_EXPIRY_MM", true, PAT_EXPIRY_DATE.Value.ToString().PadRight(4, '0').Substring(2).Trim());

                fleF010_PAT_MSTR.set_SetValue("SUBSCR_POST_CD1", true, SUBSCR_POST_CD.Value.Trim().PadRight(6, ' ').Substring(0, 1).Trim());
                fleF010_PAT_MSTR.set_SetValue("SUBSCR_POST_CD2", true, SUBSCR_POST_CD.Value.Trim().PadRight(6, '0').Substring(1, 1).Trim());
                fleF010_PAT_MSTR.set_SetValue("SUBSCR_POST_CD3", true, SUBSCR_POST_CD.Value.Trim().PadRight(6, ' ').Substring(2, 1).Trim());
                fleF010_PAT_MSTR.set_SetValue("SUBSCR_POST_CD4", true, SUBSCR_POST_CD.Value.Trim().PadRight(6, '0').Substring(3, 1).Trim());
                fleF010_PAT_MSTR.set_SetValue("SUBSCR_POST_CD5", true, SUBSCR_POST_CD.Value.Trim().PadRight(6, ' ').Substring(4, 1).Trim());
                fleF010_PAT_MSTR.set_SetValue("SUBSCR_POST_CD6", true, SUBSCR_POST_CD.Value.Trim().PadRight(6, '0').Substring(5, 1).Trim());


                fleF010_PAT_MSTR.set_SetValue("SUBSCR_DATE_MSG_NBR_EFFECT_TO_YY", true, SUBSCR_DATE_MSG_NBR_EFFECTIVE_TO.Value.ToString().PadLeft(8, '0').Substring(0, 4).Trim());
                fleF010_PAT_MSTR.set_SetValue("SUBSCR_DATE_MSG_NBR_EFFECT_TO_MM", true, SUBSCR_DATE_MSG_NBR_EFFECTIVE_TO.Value.ToString().PadLeft(8, '0').Substring(4, 2).Trim());
                fleF010_PAT_MSTR.set_SetValue("SUBSCR_DATE_MSG_NBR_EFFECT_TO_DD", true, SUBSCR_DATE_MSG_NBR_EFFECTIVE_TO.Value.ToString().PadLeft(8, '0').Substring(6, 2).Trim());


                //fleF010_PAT_MSTR.set_SetValue("PAT_I_KEY", true, KEY_PAT_MSTR.Value.ToString().Trim().PadRight(16, '0').Substring(0, 1).Trim());
                //fleF010_PAT_MSTR.set_SetValue("PAT_CON_NBR", true, KEY_PAT_MSTR.Value.ToString().Trim().PadRight(16, '0').Substring(1, 2).Trim());
                //fleF010_PAT_MSTR.set_SetValue("PAT_I_NBR", true, KEY_PAT_MSTR.Value.ToString().Trim().PadRight(16, '0').Substring(3, 12).Trim());
                //fleF010_PAT_MSTR.set_SetValue("FILLER4", true, KEY_PAT_MSTR.Value.ToString().Trim().PadRight(16, '0').Substring(15).Trim());
                fleF010_PAT_MSTR.set_SetValue("FILLER4", true, "");





            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }

        private CoreCharacter HOSP_SITE;
        private CoreCharacter W_SKIP_SUBSCR_PROV_FIELD;
        private CoreDecimal W_DOC_NBR;
        private CoreDecimal PAT_OHIP_MMYY_NUMERIC;
        private CoreDecimal W_PORT_ID;
        private CoreDecimal X_PAT_HEALTH_NBR;
        private CoreDecimal W_PAT_HEALTH_NBR;
        private CoreDecimal W_PAT_HEALTH_NBR_1;
        private CoreDecimal W_PAT_HEALTH_NBR_3;
        private CoreDecimal W_PAT_HEALTH_NBR_5;
        private CoreDecimal W_PAT_HEALTH_NBR_7;
        private CoreDecimal W_PAT_HEALTH_NBR_9;
        private CoreDecimal W_PROV_LENGTH;
        private CoreCharacter W_MSG_NBR;
        private CoreCharacter W_PASSWORD;
        private CoreDate W_OLD_BIRTH_DATE;
        private CoreCharacter W_OLD_VERSION_CD;
        private CoreDecimal W_OLD_HEALTH_NBR;
        private CoreCharacter W_OLD_SURNAME;
        private CoreCharacter W_OLD_GIVEN_NAME;
        private CoreCharacter W_OLD_CHART_NBR;
        private CoreCharacter W_OLD_CHART_NBR_2;
        private CoreCharacter W_OLD_CHART_NBR_3;
        private CoreCharacter W_OLD_CHART_NBR_4;
        private CoreCharacter W_OLD_CHART_NBR_5;
        private CoreCharacter W_OLD_ADDR1;
        private CoreCharacter W_OLD_ADDR2;
        private CoreCharacter W_OLD_ADDR3;
        private CoreCharacter W_OLD_PAT_OHIP_MMYY;
        private CoreCharacter W_OLD_PAT_DIRECT;
        private CoreCharacter PAT_IKEY;
        private CoreCharacter BATCH_NBR;
        private CoreDecimal CLAIM_NBR;
        private CoreCharacter CALL_PGM;
        private CoreDecimal W_CCYY;
        private CoreDecimal W_CC00;
        private CoreDecimal W_YY;
        private CoreDecimal W_CC000000;
        private CoreDecimal W_YYMMDD;
        private DCharacter W_SUBSCR_ADDR3 = new DCharacter(21);
        private void W_SUBSCR_ADDR3_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("H"))
                {
                    CurrentValue = "Hamilton";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("STC"))
                {
                    CurrentValue = "Stoney Creek";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("D"))
                {
                    CurrentValue = "Dundas";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("DUN"))
                {
                    CurrentValue = "Dunnville";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("WAT"))
                {
                    CurrentValue = "Waterdown";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("SC"))
                {
                    CurrentValue = "St. Catharines";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("O"))
                {
                    CurrentValue = "Oakville";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("G"))
                {
                    CurrentValue = "Grimsby";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("FR"))
                {
                    CurrentValue = "Fruitland";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("HA"))
                {
                    CurrentValue = "Hannon";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("F"))
                {
                    CurrentValue = "Flamboro";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("NOL"))
                {
                    CurrentValue = "Niagara On The Lake";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("NF"))
                {
                    CurrentValue = "Niagara Falls";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("FE"))
                {
                    CurrentValue = "Fort Erie";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("W"))
                {
                    CurrentValue = "Welland";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("T"))
                {
                    CurrentValue = "Toronto";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("DM"))
                {
                    CurrentValue = "Don Mills";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("WI"))
                {
                    CurrentValue = "Willowdale";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("B"))
                {
                    CurrentValue = "Burlington";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("MKM"))
                {
                    CurrentValue = "Markham";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("RH"))
                {
                    CurrentValue = "Richmond Hill";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("TH"))
                {
                    CurrentValue = "Thorold";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("MA"))
                {
                    CurrentValue = "Malton";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("MI"))
                {
                    CurrentValue = "Mississauga";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("SCA"))
                {
                    CurrentValue = "Scarborough";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("NY"))
                {
                    CurrentValue = "North York";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("BEA"))
                {
                    CurrentValue = "Beamsville";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("BR"))
                {
                    CurrentValue = "Brampton";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("WE"))
                {
                    CurrentValue = "Weston";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("ET"))
                {
                    CurrentValue = "Etobicoke";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("BRA"))
                {
                    CurrentValue = "Brantford";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("GEO"))
                {
                    CurrentValue = "Georgetown";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("GUE"))
                {
                    CurrentValue = "Guelph";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("THO"))
                {
                    CurrentValue = "Thornhill";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("DO"))
                {
                    CurrentValue = "Downsview";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("I"))
                {
                    CurrentValue = "Islington";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("RX"))
                {
                    CurrentValue = "Rexdale";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("A"))
                {
                    CurrentValue = "Agincourt";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("AN"))
                {
                    CurrentValue = "Ancaster";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("MIL"))
                {
                    CurrentValue = "Millgrove";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("C"))
                {
                    CurrentValue = "Caledonia";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("SIM"))
                {
                    CurrentValue = "Simcoe";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("HAG"))
                {
                    CurrentValue = "Hagersville";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("J"))
                {
                    CurrentValue = "Jarvis";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("K"))
                {
                    CurrentValue = "Kitchener";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("CA"))
                {
                    CurrentValue = "Campbellville";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("COP"))
                {
                    CurrentValue = "Copetown";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("P"))
                {
                    CurrentValue = "Paris";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("WF"))
                {
                    CurrentValue = "Waterford";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("BA"))
                {
                    CurrentValue = "Barrie";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("CAM"))
                {
                    CurrentValue = "Cambridge";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("GR"))
                {
                    CurrentValue = "Greensville";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("BI"))
                {
                    CurrentValue = "Binbrook";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("CC"))
                {
                    CurrentValue = "Caistor Centre";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("CAR"))
                {
                    CurrentValue = "Carlisle";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("CY"))
                {
                    CurrentValue = "Cayuga";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("FRE"))
                {
                    CurrentValue = "Freelton";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("L"))
                {
                    CurrentValue = "Lynden";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("ML"))
                {
                    CurrentValue = "Milton";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("MH"))
                {
                    CurrentValue = "Mount Hope";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("OH"))
                {
                    CurrentValue = "Ohsweken";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("PC"))
                {
                    CurrentValue = "Port Colborne";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("PD"))
                {
                    CurrentValue = "Port Dover";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("PU"))
                {
                    CurrentValue = "Puslinch";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("SSM"))
                {
                    CurrentValue = "Sault Ste. Marie";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("SM"))
                {
                    CurrentValue = "Smithville";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("S"))
                {
                    CurrentValue = "Sudbury";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("TB"))
                {
                    CurrentValue = "Thunder Bay";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("FO"))
                {
                    CurrentValue = "Fonthill";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("WA"))
                {
                    CurrentValue = "Wainfleet";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("CB"))
                {
                    CurrentValue = "Crystal Beach";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("V"))
                {
                    CurrentValue = "Vinemount";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("VI"))
                {
                    CurrentValue = "Vineland";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("WL"))
                {
                    CurrentValue = "Waterloo";
                }
                else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("WIN"))
                {
                    CurrentValue = "Winona";
                }
                else
                {
                    CurrentValue = fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3");
                }

                Value = CurrentValue;

            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private SqlFileObject fleF010_PAT_KEYS;
        private SqlFileObject fleCONSTANTS_MSTR_REC_5;
        private SqlFileObject fleREJECTED_CLAIMS;

        private CoreCharacter PAT_ACRONYM;
        private CoreCharacter PAT_SURNAME;
        private CoreCharacter PAT_GIVEN_NAME;
        private CoreCharacter PAT_INIT;
        private CoreDecimal PAT_BIRTH_DATE;
        private CoreDecimal PAT_EXPIRY_DATE;
        private CoreCharacter SUBSCR_POST_CD;
        private CoreDecimal SUBSCR_DATE_MSG_NBR_EFFECTIVE_TO;
        private CoreCharacter KEY_PAT_MSTR;

        private void fleREJECTED_CLAIMS_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleREJECTED_CLAIMS.ElementOwner("CLAIM_NBR")).Append(" = ").Append(Common.StringToField(fleF010_PAT_MSTR.GetStringValue("PAT_I_KEY") + QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_CON_NBR"), 2) + QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_I_NBR"), 12) + fleF010_PAT_MSTR.GetStringValue("FILLER4")));
       

                strText.Append(" ORDER BY ").Append(fleREJECTED_CLAIMS.ElementOwner("CLMHDR_PAT_OHIP_ID_OR_CHART"));
                AccessClause = strText.ToString();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }

        private SqlFileObject fleF094_MSG_MSTR;

        private void fleF094_MSG_MSTR_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleF094_MSG_MSTR.ElementOwner("MSG_SUB_KEY_1")).Append(" = ").Append(Common.StringToField("M"));
                strText.Append(" AND ").Append(fleF094_MSG_MSTR.ElementOwner("MSG_SUB_KEY_23")).Append(" = ").Append(Common.StringToField(fleF010_PAT_MSTR.GetStringValue("SUBSCR_MSG_NBR")));

                AccessClause = strText.ToString();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }

        private SqlFileObject fleF086_PAT_ID;
        private SqlFileObject fleF011_PAT_MSTR_ELIG_HISTORY;
        #endregion

        #region "Standard Generated Procedures"

        #region "Grid Field Declarations"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 6/2/2017 12:49:12 PM

        //# No code was generated or needed for this region.

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 6/2/2017 12:49:12 PM

        //# No code was generated or needed for this region.

        #endregion

        #region "Transaction Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 6/2/2017 12:49:12 PM

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
            fleF010_PAT_MSTR.Transaction = m_trnTRANS_UPDATE;
            fleCONSTANTS_MSTR_REC_5.Transaction = m_trnTRANS_UPDATE;
            fleREJECTED_CLAIMS.Transaction = m_trnTRANS_UPDATE;
            fleF086_PAT_ID.Transaction = m_trnTRANS_UPDATE;
            fleF011_PAT_MSTR_ELIG_HISTORY.Transaction = m_trnTRANS_UPDATE;


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 6/2/2017 12:49:12 PM

        //#-----------------------------------------
        //# InitializeFiles Procedure.
        //#-----------------------------------------

        protected override void InitializeFiles()
        {

            try
            {
                Initialize_TRANS_UPDATE();
                fleF010_PAT_KEYS.Connection = m_cnnQUERY;
                fleF094_MSG_MSTR.Connection = m_cnnQUERY;


            }
            catch (CustomApplicationException ex)
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
                fleF010_PAT_MSTR.Dispose();
                fleF010_PAT_KEYS.Dispose();
                fleCONSTANTS_MSTR_REC_5.Dispose();
                fleREJECTED_CLAIMS.Dispose();
                fleF094_MSG_MSTR.Dispose();
                fleF086_PAT_ID.Dispose();
                fleF011_PAT_MSTR_ELIG_HISTORY.Dispose();


            }
            catch (CustomApplicationException ex)
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

        #region "Display Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.

        //#-----------------------------------------
        //# DisplayFormatting Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 6/2/2017 12:49:11 PM
        //#-----------------------------------------
        protected override void DisplayFormatting()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 6/2/2017 12:49:11 PM
                Display(ref fldF010_PAT_MSTR_PAT_PROV_CD);
                Display(ref fldF010_PAT_MSTR_PAT_ACRONYM);
                Display(ref fldF010_PAT_MSTR_PAT_HEALTH_NBR);
                Display(ref fldT_PAT_OHIP_MMYY);
                Display(ref fldT_PAT_CHART_NBR_5);
                Display(ref fldT_PAT_CHART_NBR);
                Display(ref fldT_PAT_CHART_NBR_2);
                Display(ref fldT_PAT_CHART_NBR_3);
                Display(ref fldT_PAT_CHART_NBR_4);
                Display(ref fldF010_PAT_MSTR_PAT_SURNAME);
                Display(ref fldF010_PAT_MSTR_PAT_GIVEN_NAME);
                Display(ref fldF010_PAT_MSTR_PAT_INIT);
                Display(ref fldF010_PAT_MSTR_PAT_BIRTH_DATE);
                Display(ref fldF010_PAT_MSTR_PAT_LAST_BIRTH_DATE);
                Display(ref fldF010_PAT_MSTR_PAT_SEX);
                Display(ref fldF010_PAT_MSTR_PAT_HEALTH_65_IND);
                Display(ref fldF010_PAT_MSTR_PAT_VERSION_CD);
                Display(ref fldF010_PAT_MSTR_PAT_LAST_VERSION_CD);
                Display(ref fldF010_PAT_MSTR_PAT_EXPIRY_DATE);
                Display(ref fldF010_PAT_MSTR_PAT_PHONE_NBR);
                Display(ref fldF010_PAT_MSTR_SUBSCR_ADDR1);
                Display(ref fldF010_PAT_MSTR_SUBSCR_ADDR2);
                Display(ref fldF010_PAT_MSTR_SUBSCR_ADDR3);
                Display(ref fldF010_PAT_MSTR_SUBSCR_PROV_CD);
                Display(ref fldF010_PAT_MSTR_SUBSCR_POSTAL_CD);
                Display(ref fldF010_PAT_MSTR_SUBSCR_MSG_NBR);
                Display(ref fldF010_PAT_MSTR_SUBSCR_DATE_MSG_NBR_EFFECTIVE_TO);
                Display(ref fldF010_PAT_MSTR_SUBSCR_AUTO_UPDATE);
                Display(ref fldF010_PAT_MSTR_PAT_DIALYSIS);
                Display(ref fldF010_PAT_MSTR_PAT_OHIP_VALIDATION_STATUS);
                Display(ref fldF010_PAT_MSTR_PAT_LOCATION_FIELD);
                Display(ref fldF010_PAT_MSTR_PAT_LAST_DOC_NBR_SEEN);
                Display(ref fldF010_PAT_MSTR_PAT_IN_OUT);
                Display(ref fldF010_PAT_MSTR_PAT_DATE_LAST_VISIT);
                Display(ref fldF010_PAT_MSTR_PAT_DATE_LAST_ADMIT);
                Display(ref fldF010_PAT_MSTR_PAT_DATE_LAST_MAINT);
                Display(ref fldF010_PAT_MSTR_PAT_DATE_LAST_ELIG_MAILING);
                Display(ref fldF010_PAT_MSTR_PAT_DATE_LAST_ELIG_MAINT);
                Display(ref fldF010_PAT_MSTR_PAT_MESS_CODE);
                Display(ref fldF010_PAT_MSTR_PAT_NO_OF_LETTER_SENT);
                Display(ref fldF010_PAT_MSTR_PAT_TOTAL_NBR_VISITS);
                Display(ref fldF010_PAT_MSTR_PAT_TOTAL_NBR_CLAIMS);
                Display(ref fldF010_PAT_MSTR_PAT_NBR_OUTSTANDING_CLAIMS);
                Display(ref fldF010_PAT_MSTR_KEY_PAT_MSTR);
                Display(ref fldW_PASSWORD);
                //#END STANDARD PROCEDURE CONTENT

            }
            catch (CustomApplicationException ex)
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
        //# PreDisplayFormatting Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 6/2/2017 12:49:11 PM
        //#-----------------------------------------
        protected override void PreDisplayFormatting()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 6/2/2017 12:49:11 PM
                Display(ref fldF010_PAT_MSTR_PAT_PROV_CD);
                Display(ref fldF010_PAT_MSTR_SUBSCR_AUTO_UPDATE);
                //#END STANDARD PROCEDURE CONTENT

            }
            catch (CustomApplicationException ex)
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

        #region "Update Validation"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.

        #endregion


        #region "RecordBuffer Events"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 6/2/2017 12:49:12 PM

        //#-----------------------------------------
        //# BindFields Procedure.
        //#-----------------------------------------

        public override void BindFields()
        {
            try
            {
                fldF010_PAT_MSTR_PAT_PROV_CD.Bind(fleF010_PAT_MSTR);
                fldF010_PAT_MSTR_PAT_ACRONYM.Bind(PAT_ACRONYM);
                fldF010_PAT_MSTR_PAT_HEALTH_NBR.Bind(fleF010_PAT_MSTR);
                fldT_PAT_OHIP_MMYY.Bind(T_PAT_OHIP_MMYY);
                fldT_PAT_CHART_NBR_5.Bind(T_PAT_CHART_NBR_5);
                fldT_PAT_CHART_NBR.Bind(T_PAT_CHART_NBR);
                fldT_PAT_CHART_NBR_2.Bind(T_PAT_CHART_NBR_2);
                fldT_PAT_CHART_NBR_3.Bind(T_PAT_CHART_NBR_3);
                fldT_PAT_CHART_NBR_4.Bind(T_PAT_CHART_NBR_4);
                fldF010_PAT_MSTR_PAT_SURNAME.Bind(PAT_SURNAME);
                fldF010_PAT_MSTR_PAT_GIVEN_NAME.Bind(PAT_GIVEN_NAME);
                fldF010_PAT_MSTR_PAT_INIT.Bind(PAT_INIT);
                fldF010_PAT_MSTR_PAT_BIRTH_DATE.Bind(PAT_BIRTH_DATE);
                fldF010_PAT_MSTR_PAT_LAST_BIRTH_DATE.Bind(fleF010_PAT_MSTR);
                fldF010_PAT_MSTR_PAT_SEX.Bind(fleF010_PAT_MSTR);
                fldF010_PAT_MSTR_PAT_HEALTH_65_IND.Bind(fleF010_PAT_MSTR);
                fldF010_PAT_MSTR_PAT_VERSION_CD.Bind(fleF010_PAT_MSTR);
                fldF010_PAT_MSTR_PAT_LAST_VERSION_CD.Bind(fleF010_PAT_MSTR);
                fldF010_PAT_MSTR_PAT_EXPIRY_DATE.Bind(PAT_EXPIRY_DATE);
                fldF010_PAT_MSTR_PAT_PHONE_NBR.Bind(fleF010_PAT_MSTR);
                fldF010_PAT_MSTR_SUBSCR_ADDR1.Bind(fleF010_PAT_MSTR);
                fldF010_PAT_MSTR_SUBSCR_ADDR2.Bind(fleF010_PAT_MSTR);
                fldF010_PAT_MSTR_SUBSCR_ADDR3.Bind(fleF010_PAT_MSTR);
                fldF010_PAT_MSTR_SUBSCR_PROV_CD.Bind(fleF010_PAT_MSTR);
                fldF010_PAT_MSTR_SUBSCR_POSTAL_CD.Bind(SUBSCR_POST_CD);
                fldF010_PAT_MSTR_SUBSCR_MSG_NBR.Bind(fleF010_PAT_MSTR);
                fldF010_PAT_MSTR_SUBSCR_DATE_MSG_NBR_EFFECTIVE_TO.Bind(SUBSCR_DATE_MSG_NBR_EFFECTIVE_TO);
                fldF010_PAT_MSTR_SUBSCR_AUTO_UPDATE.Bind(fleF010_PAT_MSTR);
                fldF010_PAT_MSTR_PAT_DIALYSIS.Bind(fleF010_PAT_MSTR);
                fldF010_PAT_MSTR_PAT_OHIP_VALIDATION_STATUS.Bind(fleF010_PAT_MSTR);
                fldF010_PAT_MSTR_PAT_LOCATION_FIELD.Bind(fleF010_PAT_MSTR);
                fldF010_PAT_MSTR_PAT_LAST_DOC_NBR_SEEN.Bind(fleF010_PAT_MSTR);
                fldF010_PAT_MSTR_PAT_IN_OUT.Bind(fleF010_PAT_MSTR);
                fldF010_PAT_MSTR_PAT_DATE_LAST_VISIT.Bind(fleF010_PAT_MSTR);
                fldF010_PAT_MSTR_PAT_DATE_LAST_ADMIT.Bind(fleF010_PAT_MSTR);
                fldF010_PAT_MSTR_PAT_DATE_LAST_MAINT.Bind(fleF010_PAT_MSTR);
                fldF010_PAT_MSTR_PAT_DATE_LAST_ELIG_MAILING.Bind(fleF010_PAT_MSTR);
                fldF010_PAT_MSTR_PAT_DATE_LAST_ELIG_MAINT.Bind(fleF010_PAT_MSTR);
                fldF010_PAT_MSTR_PAT_MESS_CODE.Bind(fleF010_PAT_MSTR);
                fldF010_PAT_MSTR_PAT_NO_OF_LETTER_SENT.Bind(fleF010_PAT_MSTR);
                fldF010_PAT_MSTR_PAT_TOTAL_NBR_VISITS.Bind(fleF010_PAT_MSTR);
                fldF010_PAT_MSTR_PAT_TOTAL_NBR_CLAIMS.Bind(fleF010_PAT_MSTR);
                fldF010_PAT_MSTR_PAT_NBR_OUTSTANDING_CLAIMS.Bind(fleF010_PAT_MSTR);
                fldF010_PAT_MSTR_KEY_PAT_MSTR.Bind(KEY_PAT_MSTR);
                fldW_PASSWORD.Bind(W_PASSWORD);

            }
            catch (CustomApplicationException ex)
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

        #region "Update Audit Tables"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  

        #endregion

        #region "Automatic Item Initialization"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.

        #endregion

        #endregion

        #region "Renaissance Architect Generated 4GL Procedures"


        protected override object SetFieldDefaults(string Name)
        {


            try
            {
                switch (Name)
                {
                    case "F010_PAT_MSTR_PAT_DIALYSIS":
                        return "N";
                    default:
                        return "";
                }


            }
            catch (CustomApplicationException ex)
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

        #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"

        protected override bool PostFind()
        {


            try
            {


                PAT_ACRONYM.Value = fleF010_PAT_MSTR.GetStringValue("PAT_ACRONYM_FIRST6") + fleF010_PAT_MSTR.GetStringValue("PAT_ACRONYM_LAST3");
                PAT_SURNAME.Value = fleF010_PAT_MSTR.GetStringValue("PAT_SURNAME_FIRST3") + fleF010_PAT_MSTR.GetStringValue("PAT_SURNAME_LAST22");
                PAT_GIVEN_NAME.Value = fleF010_PAT_MSTR.GetStringValue("PAT_GIVEN_NAME_FIRST1") + fleF010_PAT_MSTR.GetStringValue("FILLER3");
                PAT_INIT.Value = fleF010_PAT_MSTR.GetStringValue("PAT_INIT1") + fleF010_PAT_MSTR.GetStringValue("PAT_INIT2") + fleF010_PAT_MSTR.GetStringValue("PAT_INIT3");
                PAT_BIRTH_DATE.Value = Convert.ToDecimal(fleF010_PAT_MSTR.GetDecimalValue("PAT_BIRTH_DATE_YY").ToString().PadLeft(4, '0') + fleF010_PAT_MSTR.GetDecimalValue("PAT_BIRTH_DATE_MM").ToString().PadLeft(2, '0') + fleF010_PAT_MSTR.GetDecimalValue("PAT_BIRTH_DATE_DD").ToString().PadLeft(2, '0'));
                PAT_EXPIRY_DATE.Value = Convert.ToDecimal(fleF010_PAT_MSTR.GetDecimalValue("PAT_EXPIRY_YY").ToString().PadLeft(2, '0') + fleF010_PAT_MSTR.GetDecimalValue("PAT_EXPIRY_MM").ToString().PadLeft(2, '0'));
                SUBSCR_POST_CD.Value = fleF010_PAT_MSTR.GetStringValue("SUBSCR_POST_CD1").Trim() + fleF010_PAT_MSTR.GetStringValue("SUBSCR_POST_CD2").Trim() + fleF010_PAT_MSTR.GetStringValue("SUBSCR_POST_CD3").Trim() + fleF010_PAT_MSTR.GetStringValue("SUBSCR_POST_CD4").Trim() + fleF010_PAT_MSTR.GetStringValue("SUBSCR_POST_CD5").Trim() + fleF010_PAT_MSTR.GetStringValue("SUBSCR_POST_CD6").Trim() + fleF010_PAT_MSTR.GetStringValue("FILLER").Trim();
                SUBSCR_DATE_MSG_NBR_EFFECTIVE_TO.Value = Convert.ToDecimal(fleF010_PAT_MSTR.GetDecimalValue("SUBSCR_DATE_MSG_NBR_EFFECT_TO_YY").ToString().PadLeft(4, '0') + fleF010_PAT_MSTR.GetDecimalValue("SUBSCR_DATE_MSG_NBR_EFFECT_TO_MM").ToString().PadLeft(2, '0') + fleF010_PAT_MSTR.GetDecimalValue("SUBSCR_DATE_MSG_NBR_EFFECT_TO_DD").ToString().PadLeft(2, '0'));
                KEY_PAT_MSTR.Value = QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("PAT_I_KEY") + QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_CON_NBR"), 2) + QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_I_NBR"), 12) + fleF010_PAT_MSTR.GetStringValue("FILLER4"));


                W_OLD_BIRTH_DATE.Value = Convert.ToDecimal(fleF010_PAT_MSTR.GetDecimalValue("PAT_BIRTH_DATE_YY").ToString().PadLeft(4, '0') + fleF010_PAT_MSTR.GetDecimalValue("PAT_BIRTH_DATE_MM").ToString().PadLeft(2, '0') + fleF010_PAT_MSTR.GetDecimalValue("PAT_BIRTH_DATE_DD").ToString().PadLeft(2, '0'));
                W_OLD_VERSION_CD.Value = fleF010_PAT_MSTR.GetStringValue("PAT_VERSION_CD");
                W_OLD_HEALTH_NBR.Value = fleF010_PAT_MSTR.GetDecimalValue("PAT_HEALTH_NBR");
                W_OLD_SURNAME.Value = fleF010_PAT_MSTR.GetStringValue("PAT_SURNAME_FIRST3") + fleF010_PAT_MSTR.GetStringValue("PAT_SURNAME_LAST22");
                //Parent:PAT_SURNAME
                W_OLD_GIVEN_NAME.Value = fleF010_PAT_MSTR.GetStringValue("PAT_GIVEN_NAME_FIRST1") + fleF010_PAT_MSTR.GetStringValue("FILLER3");
                //Parent:PAT_GIVEN_NAME
                W_OLD_CHART_NBR.Value = fleF010_PAT_MSTR.GetStringValue("PAT_CHART_NBR");
                W_OLD_CHART_NBR_2.Value = fleF010_PAT_MSTR.GetStringValue("PAT_CHART_NBR_2");
                W_OLD_CHART_NBR_3.Value = fleF010_PAT_MSTR.GetStringValue("PAT_CHART_NBR_3");
                W_OLD_CHART_NBR_4.Value = fleF010_PAT_MSTR.GetStringValue("PAT_CHART_NBR_4");
                W_OLD_CHART_NBR_5.Value = fleF010_PAT_MSTR.GetStringValue("PAT_CHART_NBR_5");
                W_OLD_ADDR1.Value = fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR1");
                W_OLD_ADDR2.Value = fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR2");
                W_OLD_ADDR3.Value = fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3");
            

                if (QDesign.Substring(fleF010_PAT_MSTR.GetStringValue("PAT_DIRECT_ALPHA") +
                    fleF010_PAT_MSTR.GetStringValue("PAT_DIRECT_YY").PadLeft(2, ' ') +
                    fleF010_PAT_MSTR.GetStringValue("PAT_DIRECT_MM").PadLeft(2, ' ') +
                    fleF010_PAT_MSTR.GetStringValue("PAT_DIRECT_DD").PadLeft(2, ' ') +
                    fleF010_PAT_MSTR.GetStringValue("PAT_DIRECT_LAST_6"), 1, 8) ==
                     QDesign.NULL(QDesign.Substring(fleF010_PAT_MSTR.GetStringValue("PAT_I_KEY") + QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_CON_NBR"), 2) + QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_I_NBR"), 12) + fleF010_PAT_MSTR.GetStringValue("FILLER4"), 4, 12)))

                {
                    T_PAT_OHIP_MMYY.Value = " ";
                }
                else
                {
                    T_PAT_OHIP_MMYY.Value = fleF010_PAT_MSTR.GetStringValue("PAT_DIRECT_ALPHA").Trim() +
                    fleF010_PAT_MSTR.GetStringValue("PAT_DIRECT_YY").Trim().PadLeft(2, '0') +
                    fleF010_PAT_MSTR.GetStringValue("PAT_DIRECT_MM").Trim().PadLeft(2, '0') +
                    fleF010_PAT_MSTR.GetStringValue("PAT_DIRECT_DD").Trim().PadLeft(2, '0') +
                    fleF010_PAT_MSTR.GetStringValue("PAT_DIRECT_LAST_6").Trim();
                    //Parent:PAT_OHIP_MMYY

                    try
                    {
                        if(Convert.ToInt64(T_PAT_OHIP_MMYY.Value) == 0)
                            T_PAT_OHIP_MMYY.Value = " ";
                    }
                    catch { }


                }
              
                if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("PAT_CHART_NBR")) == QDesign.NULL(QDesign.Substring(fleF010_PAT_MSTR.GetStringValue("PAT_I_KEY") + QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_CON_NBR"), 2) + QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_I_NBR"), 12) + fleF010_PAT_MSTR.GetStringValue("FILLER4"), 6, 10)))
                {
                    T_PAT_CHART_NBR.Value = " ";
                }
                else
                {
                    T_PAT_CHART_NBR.Value = fleF010_PAT_MSTR.GetStringValue("PAT_CHART_NBR");
                }
            
                if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("PAT_CHART_NBR_2")) == QDesign.NULL(QDesign.Substring(fleF010_PAT_MSTR.GetStringValue("PAT_I_KEY") + QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_CON_NBR"), 2) + QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_I_NBR"), 12) + fleF010_PAT_MSTR.GetStringValue("FILLER4"), 6, 10)))
                {
                    T_PAT_CHART_NBR_2.Value = " ";
                }
                else
                {
                    T_PAT_CHART_NBR_2.Value = fleF010_PAT_MSTR.GetStringValue("PAT_CHART_NBR_2");
                }
            
                if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("PAT_CHART_NBR_3")) == QDesign.NULL(QDesign.Substring(fleF010_PAT_MSTR.GetStringValue("PAT_I_KEY") + QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_CON_NBR"), 2) + QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_I_NBR"), 12) + fleF010_PAT_MSTR.GetStringValue("FILLER4"), 6, 10)))
                {
                    T_PAT_CHART_NBR_3.Value = " ";
                }
                else
                {
                    T_PAT_CHART_NBR_3.Value = fleF010_PAT_MSTR.GetStringValue("PAT_CHART_NBR_3");
                }
             
                if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("PAT_CHART_NBR_4")) == QDesign.NULL("?" + QDesign.Substring(fleF010_PAT_MSTR.GetStringValue("PAT_I_KEY") + QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_CON_NBR"), 2) + QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_I_NBR"), 12) + fleF010_PAT_MSTR.GetStringValue("FILLER4"), 7, 9)))
                {
                    T_PAT_CHART_NBR_4.Value = " ";
                }
                else
                {
                    T_PAT_CHART_NBR_4.Value = fleF010_PAT_MSTR.GetStringValue("PAT_CHART_NBR_4");
                }
            
                if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("PAT_CHART_NBR_5")) == QDesign.NULL(QDesign.Substring(fleF010_PAT_MSTR.GetStringValue("PAT_I_KEY") + QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_CON_NBR"), 2) + QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_I_NBR"), 12) + fleF010_PAT_MSTR.GetStringValue("FILLER4"), 5, 11)))
                {
                    T_PAT_CHART_NBR_5.Value = " ";
                }
                else
                {
                    T_PAT_CHART_NBR_5.Value = fleF010_PAT_MSTR.GetStringValue("PAT_CHART_NBR_5");
                }

                return true;


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }


        private bool Internal_MOD_10_CHECK_DIGIT()
        {


            try
            {

                W_PAT_HEALTH_NBR_1.Value = QDesign.Floor(X_PAT_HEALTH_NBR.Value / 1000000000) * 2;
                if (QDesign.NULL(W_PAT_HEALTH_NBR_1.Value) < 10)
                {
                    W_PAT_HEALTH_NBR_1.Value = W_PAT_HEALTH_NBR_1.Value;
                }
                else
                {
                    W_PAT_HEALTH_NBR_1.Value = QDesign.Floor(W_PAT_HEALTH_NBR_1.Value / 10) + QDesign.PHMod(W_PAT_HEALTH_NBR_1.Value, 10);
                }
                W_PAT_HEALTH_NBR_3.Value = QDesign.Floor(QDesign.PHMod(X_PAT_HEALTH_NBR.Value, 100000000) / 10000000) * 2;
                if (QDesign.NULL(W_PAT_HEALTH_NBR_3.Value) < 10)
                {
                    W_PAT_HEALTH_NBR_3.Value = W_PAT_HEALTH_NBR_3.Value;
                }
                else
                {
                    W_PAT_HEALTH_NBR_3.Value = QDesign.Floor(W_PAT_HEALTH_NBR_3.Value / 10) + QDesign.PHMod(W_PAT_HEALTH_NBR_3.Value, 10);
                }
                W_PAT_HEALTH_NBR_5.Value = QDesign.Floor(QDesign.PHMod(X_PAT_HEALTH_NBR.Value, 1000000) / 100000) * 2;
                if (QDesign.NULL(W_PAT_HEALTH_NBR_5.Value) < 10)
                {
                    W_PAT_HEALTH_NBR_5.Value = W_PAT_HEALTH_NBR_5.Value;
                }
                else
                {
                    W_PAT_HEALTH_NBR_5.Value = QDesign.Floor(W_PAT_HEALTH_NBR_5.Value / 10) + QDesign.PHMod(W_PAT_HEALTH_NBR_5.Value, 10);
                }
                W_PAT_HEALTH_NBR_7.Value = QDesign.Floor(QDesign.PHMod(X_PAT_HEALTH_NBR.Value, 10000) / 1000) * 2;
                if (QDesign.NULL(W_PAT_HEALTH_NBR_7.Value) < 10)
                {
                    W_PAT_HEALTH_NBR_7.Value = W_PAT_HEALTH_NBR_7.Value;
                }
                else
                {
                    W_PAT_HEALTH_NBR_7.Value = QDesign.Floor(W_PAT_HEALTH_NBR_7.Value / 10) + QDesign.PHMod(W_PAT_HEALTH_NBR_7.Value, 10);
                }
                W_PAT_HEALTH_NBR_9.Value = QDesign.Floor(QDesign.PHMod(X_PAT_HEALTH_NBR.Value, 100) / 10) * 2;
                if (QDesign.NULL(W_PAT_HEALTH_NBR_9.Value) < 10)
                {
                    W_PAT_HEALTH_NBR_9.Value = W_PAT_HEALTH_NBR_9.Value;
                }
                else
                {
                    W_PAT_HEALTH_NBR_9.Value = QDesign.Floor(W_PAT_HEALTH_NBR_9.Value / 10) + QDesign.PHMod(W_PAT_HEALTH_NBR_9.Value, 10);
                }
                W_PAT_HEALTH_NBR.Value = QDesign.Floor(QDesign.PHMod(X_PAT_HEALTH_NBR.Value, 1000000000) / 100000000) + QDesign.Floor(QDesign.PHMod(X_PAT_HEALTH_NBR.Value, 10000000) / 1000000) + QDesign.Floor(QDesign.PHMod(X_PAT_HEALTH_NBR.Value, 100000) / 10000) + QDesign.Floor(QDesign.PHMod(X_PAT_HEALTH_NBR.Value, 1000) / 100) + W_PAT_HEALTH_NBR_1.Value + W_PAT_HEALTH_NBR_3.Value + W_PAT_HEALTH_NBR_5.Value + W_PAT_HEALTH_NBR_7.Value + W_PAT_HEALTH_NBR_9.Value;
                W_PAT_HEALTH_NBR.Value = QDesign.PHMod(W_PAT_HEALTH_NBR.Value, 10);
                if (QDesign.NULL(W_PAT_HEALTH_NBR.Value) > 0)
                {
                    W_PAT_HEALTH_NBR.Value = 10 - W_PAT_HEALTH_NBR.Value;
                }

                return true;


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldF010_PAT_MSTR_PAT_HEALTH_NBR_Input()
        {

            try
            {

                if (QDesign.NULL(FieldText) != QDesign.NULL(" ") & 10 != ((FieldText.Length)))
                {
                    ErrorMessage("Patient Health Number must be 10 digits long");
                }


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldF010_PAT_MSTR_PAT_HEALTH_NBR_Edit()
        {

            try
            {

                if (QDesign.NULL(fleF010_PAT_MSTR.GetDecimalValue("PAT_HEALTH_NBR")) != 0 & QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("PAT_PROV_CD")) != QDesign.NULL("ON"))
                {
                    ErrorMessage("Health Nbr is not allowed for Out of Province Patient");
                }
                if (QDesign.NULL(fleF010_PAT_MSTR.GetDecimalValue("PAT_HEALTH_NBR")) != 0 & QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("PAT_PROV_CD")) == QDesign.NULL("ON"))
                {
                    if (QDesign.NULL(T_PAT_OHIP_MMYY.Value) != QDesign.NULL(" ") & string.Compare(QDesign.Substring(T_PAT_OHIP_MMYY.Value, 1, 1), "A") >= 0 & string.Compare(QDesign.Substring(T_PAT_OHIP_MMYY.Value, 1, 1), "Z") <= 0)
                    {
                        ErrorMessage("Bill Direct Nbr already assigned, Health Nbr is not allowed");
                    }
                    X_PAT_HEALTH_NBR.Value = fleF010_PAT_MSTR.GetDecimalValue("PAT_HEALTH_NBR");
                    Internal_MOD_10_CHECK_DIGIT();
                    if (QDesign.NULL(W_PAT_HEALTH_NBR.Value) != QDesign.NULL((QDesign.PHMod(fleF010_PAT_MSTR.GetDecimalValue("PAT_HEALTH_NBR"), 10))))
                    {
                        ErrorMessage("Invalid Health Care Nbr");
                    }
                    // --> GET F010_PAT_KEYS <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF010_PAT_KEYS.ElementOwner("PAT_HEALTH_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF010_PAT_MSTR.GetStringValue("PAT_HEALTH_NBR")));
                  

                    fleF010_PAT_KEYS.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F010_PAT_KEYS <--
                    if (AccessOk)
                    {
                        ErrorMessage(QDesign.NULL("HEALTH NBR is already assigned to ANOTHER PATIENT"));
                        // TODO: May need to fix manually
                    }
                }


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldT_PAT_OHIP_MMYY_Edit()
        {

            try
            {

                if (QDesign.NULL(T_PAT_OHIP_MMYY.Value) != QDesign.NULL(" ") & QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("PAT_PROV_CD")) == QDesign.NULL("ON"))
                {
                    if (string.Compare(QDesign.NULL(QDesign.Substring(T_PAT_OHIP_MMYY.Value, 1, 1)), QDesign.NULL("A")) < 0)
                    {
                        ErrorMessage("Error - OHIP number is no longer valid for Ontario residents");
                    }
                    else
                    {
                        if (QDesign.NULL(fleF010_PAT_MSTR.GetDecimalValue("PAT_HEALTH_NBR")) != 0)
                        {
                            ErrorMessage("Bill Direct is not allowed with Health Nbr");
                        }
                        //Parent:PAT_SURNAME
                        if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("PAT_SURNAME_FIRST3") + fleF010_PAT_MSTR.GetStringValue("PAT_SURNAME_LAST22")) != QDesign.NULL(" "))
                        {
                            if (QDesign.NULL(QDesign.Substring(T_PAT_OHIP_MMYY.Value, 1, 3)) != QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("PAT_SURNAME_FIRST3")))
                            {
                                ErrorMessage("First 3 letters of Direct Id does not match Surname");
                            }
                        }
                        if (QDesign.NULL( PAT_BIRTH_DATE.Value) != 0)
                        {
                            W_CC000000.Value = (QDesign.Floor( PAT_BIRTH_DATE.Value / 1000000)) * 1000000;
                            W_YYMMDD.Value =  PAT_BIRTH_DATE.Value - W_CC000000.Value;
                            if (QDesign.NULL(W_YYMMDD.Value) != QDesign.NULL(QDesign.NConvert(QDesign.Substring(T_PAT_OHIP_MMYY.Value, 4, 6))))
                            {
                                ErrorMessage("Birth date doesn`t match Direct Date - change birth date first");
                            }
                        }
                    }
                }
                if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("PAT_PROV_CD")) != QDesign.NULL("ON"))
                {
                    W_PROV_LENGTH.Value = QDesign.Length(QDesign.RTrim(T_PAT_OHIP_MMYY.Value));
                    if (QDesign.NULL(W_PROV_LENGTH.Value) != 9 & (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("PAT_PROV_CD")) == QDesign.NULL("AB")))
                    {
                        ErrorMessage("ALBERTA`s    number must have 9  digits");
                    }
                    if (QDesign.NULL(W_PROV_LENGTH.Value) != 9 & (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("PAT_PROV_CD")) == QDesign.NULL("NU")))
                    {
                        ErrorMessage("Territory of NUNAVUT`s  number must have 9  digits");
                    }
                    if (QDesign.NULL(W_PROV_LENGTH.Value) != 10 & (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("PAT_PROV_CD")) == QDesign.NULL("NS")))
                    {
                        ErrorMessage("NOVA SCOTIA`s number must have 10 digits");
                    }
                    if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("PAT_PROV_CD")) == QDesign.NULL("BC") & QDesign.NULL(W_PROV_LENGTH.Value) != 10 & QDesign.NULL(QDesign.Substring(T_PAT_OHIP_MMYY.Value, 1, 1)) == QDesign.NULL("9"))
                    {
                        ErrorMessage("B.C.`s number must have 10 digits AND start with numeric 9");
                    }
                    if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("PAT_PROV_CD")) == QDesign.NULL("MB") & QDesign.NULL(W_PROV_LENGTH.Value) != 9)
                    {
                        ErrorMessage("MANITOBA`S number must have 9 digits");
                    }
                    if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("PAT_PROV_CD")) == QDesign.NULL("NL") & QDesign.NULL(W_PROV_LENGTH.Value) != 12)
                    {
                        ErrorMessage("NEWFOUNDLAND`s number must have 12 digits");
                    }
                    if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("PAT_PROV_CD")) == QDesign.NULL("PE") & QDesign.NULL(W_PROV_LENGTH.Value) != 8)
                    {
                        ErrorMessage("PRINCE EDWARD ISLAND`s number must have 8 digits");
                    }
                    if (QDesign.NULL(W_PROV_LENGTH.Value) != 9 & (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("PAT_PROV_CD")) == QDesign.NULL("NB") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("PAT_PROV_CD")) == QDesign.NULL("YT") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("PAT_PROV_CD")) == QDesign.NULL("SK")))
                    {
                        ErrorMessage("REGISTRATION Number must have 9 digits");
                    }
                    if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("PAT_PROV_CD")) == QDesign.NULL("NT") & (QDesign.NULL(QDesign.Substring(T_PAT_OHIP_MMYY.Value, 1, 1)) != QDesign.NULL("N") & QDesign.NULL(QDesign.Substring(T_PAT_OHIP_MMYY.Value, 1, 1)) != QDesign.NULL("D") & QDesign.NULL(QDesign.Substring(T_PAT_OHIP_MMYY.Value, 1, 1)) != QDesign.NULL("M") & QDesign.NULL(QDesign.Substring(T_PAT_OHIP_MMYY.Value, 1, 1)) != QDesign.NULL("T")))
                    {
                        ErrorMessage("N.T. number must start with D, N, M OR T plus 7 digits");
                    }
                    if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("PAT_PROV_CD")) == QDesign.NULL("NT") & QDesign.NULL(W_PROV_LENGTH.Value) != 8)
                    {
                        ErrorMessage("N.T. number must have  8 alpha numeric");
                    }
                }
                // --> GET F010_PAT_KEYS <--
                m_strWhere = new StringBuilder(" WHERE ");
                m_strWhere.Append(" ").Append(fleF010_PAT_KEYS.ElementOwner("PAT_DIRECT_ALPHA")).Append(" = ");
                m_strWhere.Append(Common.StringToField(FieldText));

                fleF010_PAT_KEYS.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                // --> End GET F010_PAT_KEYS <--
                if (AccessOk)
                {
                    ErrorMessage(QDesign.NULL("OHIP/DIRECT NBR IS ALREADY ASSIGNED TO ANOTHER PATIENT\a"));
                   
                }


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }


        private bool Internal_CHART_NBR_INPUT_ENTRY()
        {


            try
            {

                if (7 > FieldText.Length & (QDesign.NULL(QDesign.Substring(FieldText, 1, 1)) == QDesign.NULL("0") | QDesign.NULL(QDesign.Substring(FieldText, 1, 1)) == QDesign.NULL("1") | QDesign.NULL(QDesign.Substring(FieldText, 1, 1)) == QDesign.NULL("5")))
                {
                    ErrorMessage("Entered General Chart nbr cannot be less than 7 digits");
                }
                if (10 < FieldText.Length & (QDesign.NULL(QDesign.Substring(FieldText, 1, 1)) == QDesign.NULL("0") | QDesign.NULL(QDesign.Substring(FieldText, 1, 1)) == QDesign.NULL("1") | QDesign.NULL(QDesign.Substring(FieldText, 1, 1)) == QDesign.NULL("5")))
                {
                    ErrorMessage("Entered General Chart nbr cannot be more than 10 digits");
                }
                if (7 == FieldText.Length & (QDesign.NULL(QDesign.Substring(FieldText, 1, 1)) == QDesign.NULL("0") | QDesign.NULL(QDesign.Substring(FieldText, 1, 1)) == QDesign.NULL("1") | QDesign.NULL(QDesign.Substring(FieldText, 1, 1)) == QDesign.NULL("5")))
                {
                    FieldText = "000" + FieldText;
                }
                if (8 == FieldText.Length & (QDesign.NULL(QDesign.Substring(FieldText, 1, 1)) == QDesign.NULL("0") | QDesign.NULL(QDesign.Substring(FieldText, 1, 1)) == QDesign.NULL("1") | QDesign.NULL(QDesign.Substring(FieldText, 1, 1)) == QDesign.NULL("5")))
                {
                    FieldText = "00" + FieldText;
                }
                if (9 == FieldText.Length & (QDesign.NULL(QDesign.Substring(FieldText, 1, 1)) == QDesign.NULL("0") | QDesign.NULL(QDesign.Substring(FieldText, 1, 1)) == QDesign.NULL("1") | QDesign.NULL(QDesign.Substring(FieldText, 1, 1)) == QDesign.NULL("5")))
                {
                    FieldText = "0" + FieldText;
                }

                return true;


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }


        private bool Internal_CHART_NBR_EDIT_ENTRY()
        {


            try
            {

                if (QDesign.NULL(T_PAT_CHART_NBR_5.Value) != QDesign.NULL(" "))
                {
                    if (QDesign.NULL(QDesign.Substring(T_PAT_CHART_NBR_5.Value, 1, 1)) != QDesign.NULL("M") & QDesign.NULL(QDesign.Substring(T_PAT_CHART_NBR_5.Value, 1, 1)) != QDesign.NULL("H") & QDesign.NULL(QDesign.Substring(T_PAT_CHART_NBR_5.Value, 1, 1)) != QDesign.NULL("K") & QDesign.NULL(QDesign.Substring(T_PAT_CHART_NBR_5.Value, 1, 1)) != QDesign.NULL("J") & QDesign.NULL(QDesign.Substring(T_PAT_CHART_NBR_5.Value, 1, 1)) != QDesign.NULL("D") & QDesign.NULL(QDesign.Substring(T_PAT_CHART_NBR_5.Value, 1, 1)) != QDesign.NULL("E") & QDesign.NULL(QDesign.Substring(T_PAT_CHART_NBR_5.Value, 1, 1)) != QDesign.NULL("F") & QDesign.NULL(QDesign.Substring(T_PAT_CHART_NBR_5.Value, 1, 1)) != QDesign.NULL("W") & QDesign.NULL(QDesign.Substring(T_PAT_CHART_NBR_5.Value, 1, 2)) != QDesign.NULL("ZB") & QDesign.NULL(QDesign.Substring(T_PAT_CHART_NBR_5.Value, 1, 1)) != QDesign.NULL("0") & QDesign.NULL(QDesign.Substring(T_PAT_CHART_NBR_5.Value, 1, 1)) != QDesign.NULL("1") & QDesign.NULL(QDesign.Substring(T_PAT_CHART_NBR_5.Value, 1, 1)) != QDesign.NULL("5"))
                    {
                        ErrorMessage("Chart must start with `M` , `H` , `K` , `J` , `D` , `E` , `F` , `W` , `ZB` , `0` , `1` , `5`  ");
                    }
                    if (QDesign.NULL(QDesign.Substring(T_PAT_CHART_NBR_5.Value, 1, 1)) == QDesign.NULL("H") & QDesign.NULL(QDesign.Substring(T_PAT_CHART_NBR_5.Value, 2, 3)) != QDesign.NULL("002") & QDesign.NULL(QDesign.Substring(T_PAT_CHART_NBR_5.Value, 2, 3)) != QDesign.NULL("003"))
                    {
                        ErrorMessage("Henderson chart nbr must start with either H002 or H003");
                    }
                    if (QDesign.NULL(QDesign.Substring(T_PAT_CHART_NBR_5.Value, 1, 1)) == QDesign.NULL("0") & QDesign.NULL(QDesign.Substring(T_PAT_CHART_NBR_5.Value, 2, 3)) != QDesign.NULL("001") & QDesign.NULL(QDesign.Substring(T_PAT_CHART_NBR_5.Value, 2, 3)) != QDesign.NULL("005"))
                    {
                        ErrorMessage("General   chart nbr must start with either 0001 or 0005");
                    }
                    if (QDesign.NULL(QDesign.Substring(T_PAT_CHART_NBR_5.Value, 1, 1)) == QDesign.NULL("M"))
                    {
                        HOSP_SITE.Value = "M";
                        // --> GET F010_PAT_KEYS <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF010_PAT_KEYS.ElementOwner("PAT_CHART_NBR_5")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(T_PAT_CHART_NBR_5.Value));

                        fleF010_PAT_KEYS.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F010_PAT_KEYS <--
                        if (AccessOk)
                        {
                            ErrorMessage(QDesign.NULL("MUMC CHART NBR is already assigned to another patient\a"));
                            // TODO: May need to fix manually
                        }
                    }
                    if (QDesign.NULL(QDesign.Substring(T_PAT_CHART_NBR_5.Value, 1, 1)) == QDesign.NULL("W"))
                    {
                        HOSP_SITE.Value = "W";
                        // --> GET F010_PAT_KEYS <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF010_PAT_KEYS.ElementOwner("PAT_CHART_NBR_5")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(T_PAT_CHART_NBR_5.Value));

                        fleF010_PAT_KEYS.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F010_PAT_KEYS <--
                        if (AccessOk)
                        {
                            ErrorMessage(QDesign.NULL("West Lincoln CHART NBR is already assigned to another patient\a"));
                            // TODO: May need to fix manually
                        }
                    }
                    if (QDesign.NULL(QDesign.Substring(T_PAT_CHART_NBR_5.Value, 1, 1)) == QDesign.NULL("K"))
                    {
                        HOSP_SITE.Value = "K";
                        // --> GET F010_PAT_KEYS <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF010_PAT_KEYS.ElementOwner("PAT_CHART_NBR_5")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(T_PAT_CHART_NBR_5.Value));

                        fleF010_PAT_KEYS.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F010_PAT_KEYS <--
                        if (AccessOk)
                        {
                            ErrorMessage(QDesign.NULL("Chedoke CHART NBR is already assigned to another patient\a"));
                            // TODO: May need to fix manually
                        }
                    }
                    if (QDesign.NULL(QDesign.Substring(T_PAT_CHART_NBR_5.Value, 1, 2)) == QDesign.NULL("ZB"))
                    {
                        HOSP_SITE.Value = "Z";
                        // --> GET F010_PAT_KEYS <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF010_PAT_KEYS.ElementOwner("PAT_CHART_NBR_5")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(T_PAT_CHART_NBR_5.Value));

                        fleF010_PAT_KEYS.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F010_PAT_KEYS <--
                        if (AccessOk)
                        {
                            ErrorMessage(QDesign.NULL("Bay Area CHART NBR is already assigned to another patient\a"));
                            // TODO: May need to fix manually
                        }
                    }
                    if (QDesign.NULL(QDesign.Substring(T_PAT_CHART_NBR_5.Value, 1, 1)) == QDesign.NULL("H"))
                    {
                        HOSP_SITE.Value = "H";
                        // --> GET F010_PAT_KEYS <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF010_PAT_KEYS.ElementOwner("PAT_CHART_NBR_5")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(T_PAT_CHART_NBR_5.Value));

                        fleF010_PAT_KEYS.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F010_PAT_KEYS <--
                        if (AccessOk)
                        {
                            ErrorMessage(QDesign.NULL("Henderson CHART NBR is already assigned to another patient\a"));
                            // TODO: May need to fix manually
                        }
                    }
                    if (QDesign.NULL(QDesign.Substring(T_PAT_CHART_NBR_5.Value, 1, 1)) == QDesign.NULL("D"))
                    {
                        HOSP_SITE.Value = "D";
                        // --> GET F010_PAT_KEYS <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF010_PAT_KEYS.ElementOwner("PAT_CHART_NBR_5")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(T_PAT_CHART_NBR_5.Value));

                        fleF010_PAT_KEYS.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F010_PAT_KEYS <--
                        if (AccessOk)
                        {
                            ErrorMessage(QDesign.NULL("Haldimand War CHART NBR is already assigned to another patient\a"));
                            // TODO: May need to fix manually
                        }
                    }
                    if (QDesign.NULL(QDesign.Substring(T_PAT_CHART_NBR_5.Value, 1, 1)) == QDesign.NULL("E"))
                    {
                        HOSP_SITE.Value = "E";
                        // --> GET F010_PAT_KEYS <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF010_PAT_KEYS.ElementOwner("PAT_CHART_NBR_5")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(T_PAT_CHART_NBR_5.Value));

                        fleF010_PAT_KEYS.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F010_PAT_KEYS <--
                        if (AccessOk)
                        {
                            ErrorMessage(QDesign.NULL("West Haldimand CHART NBR is already assigned to another patient\a"));
                            // TODO: May need to fix manually
                        }
                    }
                    if (QDesign.NULL(QDesign.Substring(T_PAT_CHART_NBR_5.Value, 1, 1)) == QDesign.NULL("F"))
                    {
                        HOSP_SITE.Value = "F";
                        // --> GET F010_PAT_KEYS <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF010_PAT_KEYS.ElementOwner("PAT_CHART_NBR_5")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(T_PAT_CHART_NBR_5.Value));

                        fleF010_PAT_KEYS.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F010_PAT_KEYS <--
                        if (AccessOk)
                        {
                            ErrorMessage(QDesign.NULL("St. Peter CHART NBR is already assigned to another patient\a"));
                            // TODO: May need to fix manually
                        }
                    }
                    if (QDesign.NULL(QDesign.Substring(T_PAT_CHART_NBR_5.Value, 1, 1)) == QDesign.NULL("0") | QDesign.NULL(QDesign.Substring(T_PAT_CHART_NBR_5.Value, 1, 1)) == QDesign.NULL("1") | QDesign.NULL(QDesign.Substring(T_PAT_CHART_NBR_5.Value, 1, 1)) == QDesign.NULL("5"))
                    {
                        HOSP_SITE.Value = "G";
                        // --> GET F010_PAT_KEYS <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF010_PAT_KEYS.ElementOwner("PAT_CHART_NBR_5")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(T_PAT_CHART_NBR_5.Value));

                        fleF010_PAT_KEYS.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F010_PAT_KEYS <--
                        if (AccessOk)
                        {
                            ErrorMessage(QDesign.NULL("General CHART NBR is already assigned to another patient\a"));
                            // TODO: May need to fix manually
                        }
                    }
                    if (QDesign.NULL(QDesign.Substring(T_PAT_CHART_NBR_5.Value, 1, 1)) == QDesign.NULL("J"))
                    {
                        HOSP_SITE.Value = "J";
                        // --> GET F010_PAT_KEYS <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF010_PAT_KEYS.ElementOwner("PAT_CHART_NBR_5")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(T_PAT_CHART_NBR_5.Value));

                        fleF010_PAT_KEYS.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F010_PAT_KEYS <--
                        if (AccessOk)
                        {
                            ErrorMessage(QDesign.NULL("St. Joseph CHART NBR is already assigned to another patient\a"));
                            // TODO: May need to fix manually
                        }
                    }
                }

                return true;


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldT_PAT_CHART_NBR_5_Input()
        {

            try
            {

                if (NewRecord())
                {
                    Internal_CHART_NBR_INPUT_ENTRY();
                }


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldT_PAT_CHART_NBR_5_Edit()
        {

            try
            {

                if (NewRecord())
                {
                    Internal_CHART_NBR_EDIT_ENTRY();
                }
                else
                {
                    if (QDesign.NULL(QDesign.Substring(T_PAT_CHART_NBR_5.Value, 1, 1)) != QDesign.NULL("J"))
                    {
                        ErrorMessage("ST. Joseph Chart Nbr must start with `J`");
                    }
                    // --> GET F010_PAT_KEYS <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF010_PAT_KEYS.ElementOwner("PAT_CHART_NBR_5")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(T_PAT_CHART_NBR_5.Value));

                    fleF010_PAT_KEYS.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F010_PAT_KEYS <--
                    if (AccessOk)
                    {
                        ErrorMessage(QDesign.NULL("St. Joseph CHART NBR is already assigned to another patient\a"));
                        // TODO: May need to fix manually
                    }
                }


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldT_PAT_CHART_NBR_5_Process()
        {

            try
            {

                if (NewRecord())
                {
                    if (QDesign.NULL(HOSP_SITE.Value) == QDesign.NULL("M") | QDesign.NULL(HOSP_SITE.Value) == QDesign.NULL("W"))
                    {
                        T_PAT_CHART_NBR.Value = T_PAT_CHART_NBR_5.Value;
                        Display(ref fldT_PAT_CHART_NBR);
                        T_PAT_CHART_NBR_5.Value = " ";
                        Display(ref fldT_PAT_CHART_NBR_5);
                    }
                    if (QDesign.NULL(HOSP_SITE.Value) == QDesign.NULL("K") | QDesign.NULL(HOSP_SITE.Value) == QDesign.NULL("Z"))
                    {
                        T_PAT_CHART_NBR_2.Value = T_PAT_CHART_NBR_5.Value;
                        Display(ref fldT_PAT_CHART_NBR_2);
                        T_PAT_CHART_NBR_5.Value = " ";
                        Display(ref fldT_PAT_CHART_NBR_5);
                    }
                    if (QDesign.NULL(HOSP_SITE.Value) == QDesign.NULL("H"))
                    {
                        T_PAT_CHART_NBR_3.Value = T_PAT_CHART_NBR_5.Value;
                        Display(ref fldT_PAT_CHART_NBR_3);
                        T_PAT_CHART_NBR_5.Value = " ";
                        Display(ref fldT_PAT_CHART_NBR_5);
                    }
                    if (QDesign.NULL(HOSP_SITE.Value) == QDesign.NULL("G") | QDesign.NULL(HOSP_SITE.Value) == QDesign.NULL("D") | QDesign.NULL(HOSP_SITE.Value) == QDesign.NULL("E") | QDesign.NULL(HOSP_SITE.Value) == QDesign.NULL("F"))
                    {
                        T_PAT_CHART_NBR_4.Value = T_PAT_CHART_NBR_5.Value;
                        Display(ref fldT_PAT_CHART_NBR_4);
                        T_PAT_CHART_NBR_5.Value = " ";
                        Display(ref fldT_PAT_CHART_NBR_5);
                    }
                }


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldT_PAT_CHART_NBR_Edit()
        {

            try
            {

                // --> GET F010_PAT_KEYS <--
                m_strWhere = new StringBuilder(" WHERE ");
                m_strWhere.Append(" ").Append(fleF010_PAT_KEYS.ElementOwner("PAT_CHART_NBR")).Append(" = ");
                m_strWhere.Append(Common.StringToField(T_PAT_CHART_NBR.Value));

                fleF010_PAT_KEYS.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                // --> End GET F010_PAT_KEYS <--
                if (AccessOk & QDesign.NULL(QDesign.Substring(T_PAT_CHART_NBR.Value, 1, 1)) == QDesign.NULL("M"))
                {
                    ErrorMessage(QDesign.NULL("MUMC CHART NBR is already assigned to another patient\a"));
                    // TODO: May need to fix manually
                }
                if (AccessOk & QDesign.NULL(QDesign.Substring(T_PAT_CHART_NBR.Value, 1, 1)) == QDesign.NULL("W"))
                {
                    ErrorMessage(QDesign.NULL("West Lincoln CHART NBR is already assigned to another patient\a"));
                    // TODO: May need to fix manually
                }


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldT_PAT_CHART_NBR_2_Edit()
        {

            try
            {

                // --> GET F010_PAT_KEYS <--
                m_strWhere = new StringBuilder(" WHERE ");
                m_strWhere.Append(" ").Append(fleF010_PAT_KEYS.ElementOwner("PAT_CHART_NBR_2")).Append(" = ");
                m_strWhere.Append(Common.StringToField(T_PAT_CHART_NBR_2.Value));

                fleF010_PAT_KEYS.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                // --> End GET F010_PAT_KEYS <--
                if (AccessOk & QDesign.NULL(QDesign.Substring(T_PAT_CHART_NBR_2.Value, 1, 1)) == QDesign.NULL("K"))
                {
                    ErrorMessage(QDesign.NULL("Chedoke CHART NBR is already assigned to another patient\a"));
                    // TODO: May need to fix manually
                }
                if (AccessOk & QDesign.NULL(QDesign.Substring(T_PAT_CHART_NBR_2.Value, 1, 2)) == QDesign.NULL("ZB"))
                {
                    ErrorMessage(QDesign.NULL("Bay Area CHART NBR is already assigned to another patient\a"));
                    // TODO: May need to fix manually
                }


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldT_PAT_CHART_NBR_3_Edit()
        {

            try
            {

                if (QDesign.NULL(QDesign.Substring(T_PAT_CHART_NBR_3.Value, 1, 1)) == QDesign.NULL("H") & QDesign.NULL(QDesign.Substring(T_PAT_CHART_NBR_3.Value, 2, 3)) != QDesign.NULL("002") & QDesign.NULL(QDesign.Substring(T_PAT_CHART_NBR_3.Value, 2, 3)) != QDesign.NULL("003"))
                {
                    ErrorMessage("Henderson chart nbr must start with either H002 or H003 plus 6 digits");
                }
                // --> GET F010_PAT_KEYS <--
                m_strWhere = new StringBuilder(" WHERE ");
                m_strWhere.Append(" ").Append(fleF010_PAT_KEYS.ElementOwner("PAT_CHART_NBR_3")).Append(" = ");
                m_strWhere.Append(Common.StringToField(T_PAT_CHART_NBR_3.Value));

                fleF010_PAT_KEYS.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                // --> End GET F010_PAT_KEYS <--
                if (AccessOk)
                {
                    ErrorMessage(QDesign.NULL("Henderson CHART NBR is already assigned to another patient\a"));
                    // TODO: May need to fix manually
                }


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldT_PAT_CHART_NBR_4_Input()
        {

            try
            {

                Internal_CHART_NBR_INPUT_ENTRY();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldT_PAT_CHART_NBR_4_Edit()
        {

            try
            {

                if (QDesign.NULL(QDesign.Substring(T_PAT_CHART_NBR_4.Value, 1, 1)) != QDesign.NULL("0") & QDesign.NULL(QDesign.Substring(T_PAT_CHART_NBR_4.Value, 1, 1)) != QDesign.NULL("D") & QDesign.NULL(QDesign.Substring(T_PAT_CHART_NBR_4.Value, 1, 1)) != QDesign.NULL("E") & QDesign.NULL(QDesign.Substring(T_PAT_CHART_NBR_4.Value, 1, 1)) != QDesign.NULL("F"))
                {
                    ErrorMessage("Chart Nbr must start with `0`, `D`, `E`, `F`");
                }
                if (QDesign.NULL(QDesign.Substring(T_PAT_CHART_NBR_4.Value, 1, 1)) == QDesign.NULL("0") & QDesign.NULL(QDesign.Substring(T_PAT_CHART_NBR_4.Value, 2, 3)) != QDesign.NULL("001") & QDesign.NULL(QDesign.Substring(T_PAT_CHART_NBR_4.Value, 2, 3)) != QDesign.NULL("005"))
                {
                    ErrorMessage("General chart nbr must start with either 0001 or 0005 plus 6 digits");
                }
                // --> GET F010_PAT_KEYS <--
                m_strWhere = new StringBuilder(" WHERE ");
                m_strWhere.Append(" ").Append(fleF010_PAT_KEYS.ElementOwner("PAT_CHART_NBR_4")).Append(" = ");
                m_strWhere.Append(Common.StringToField(T_PAT_CHART_NBR_4.Value));

                fleF010_PAT_KEYS.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                // --> End GET F010_PAT_KEYS <--
                if (AccessOk & QDesign.NULL(QDesign.Substring(T_PAT_CHART_NBR_4.Value, 1, 1)) == QDesign.NULL("0"))
                {
                    ErrorMessage(QDesign.NULL("General CHART NBR is already assigned to another patient\a"));
                    // TODO: May need to fix manually
                }
                if (AccessOk & QDesign.NULL(QDesign.Substring(T_PAT_CHART_NBR_4.Value, 1, 1)) == QDesign.NULL("D"))
                {
                    ErrorMessage(QDesign.NULL("Haldimand War CHART NBR is already assigned to another patient\a"));
                    // TODO: May need to fix manually
                }
                if (AccessOk & QDesign.NULL(QDesign.Substring(T_PAT_CHART_NBR_4.Value, 1, 1)) == QDesign.NULL("E"))
                {
                    ErrorMessage(QDesign.NULL("West Haldimand CHART NBR is already assigned to another patient\a"));
                    // TODO: May need to fix manually
                }
                if (AccessOk & QDesign.NULL(QDesign.Substring(T_PAT_CHART_NBR_4.Value, 1, 1)) == QDesign.NULL("F"))
                {
                    ErrorMessage(QDesign.NULL("St. Peter CHART NBR is already assigned to another patient\a"));
                    // TODO: May need to fix manually
                }


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldF010_PAT_MSTR_PAT_SURNAME_Edit()
        {

            try
            {

                if (QDesign.NULL(T_PAT_OHIP_MMYY.Value) != QDesign.NULL(" "))
                {
                    if (string.Compare(QDesign.Substring(T_PAT_OHIP_MMYY.Value, 1, 1), "A") >= 0 & string.Compare(QDesign.Substring(T_PAT_OHIP_MMYY.Value, 1, 1), "Z") <= 0)
                    {
                        if (NewRecord() & QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("PAT_SURNAME_FIRST3")) != " " & QDesign.NULL(QDesign.Substring(T_PAT_OHIP_MMYY.Value, 1, 3)) != QDesign.NULL(QDesign.Substring(fleF010_PAT_MSTR.GetStringValue("PAT_SURNAME_FIRST3") + fleF010_PAT_MSTR.GetStringValue("PAT_SURNAME_LAST22"), 1, 3)) & QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("PAT_PROV_CD")) != QDesign.NULL("NT"))
                        {
                            ErrorMessage("Surname must start with the same first 3 letters of Direct Id");
                        }
                        if (ChangeMode | CorrectMode)
                        {
                            T_PAT_OHIP_MMYY.Value = QDesign.Substring(fleF010_PAT_MSTR.GetStringValue("PAT_SURNAME_FIRST3") + fleF010_PAT_MSTR.GetStringValue("PAT_SURNAME_LAST22"), 1, 3) + QDesign.Substring(T_PAT_OHIP_MMYY.Value, 4, 12);
                            //Parent:PAT_SURNAME
                            fleF010_PAT_MSTR.set_SetValue("PAT_ACRONYM_FIRST6", PAT_SURNAME.Value.Substring(0, 6));
                            fleF010_PAT_MSTR.set_SetValue("PAT_ACRONYM_LAST3", PAT_GIVEN_NAME.Value.Substring(0, 3));
                            PAT_ACRONYM.Value = fleF010_PAT_MSTR.GetStringValue("PAT_ACRONYM_FIRST6") + fleF010_PAT_MSTR.GetStringValue("PAT_ACRONYM_LAST3");
                            Display(ref fldT_PAT_OHIP_MMYY);
                            Display(ref fldF010_PAT_MSTR_PAT_ACRONYM);
                            // --> GET F010_PAT_KEYS <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleF010_PAT_KEYS.ElementOwner("PAT_SURNAME_FIRST3")).Append(" = ");
                            m_strWhere.Append(Common.StringToField(T_PAT_OHIP_MMYY.Value.PadLeft(25,' ').Substring(0,3)));
                            m_strWhere.Append(" ").Append(fleF010_PAT_KEYS.ElementOwner("PAT_SURNAME_LAST22")).Append(" = ");
                            m_strWhere.Append(Common.StringToField(T_PAT_OHIP_MMYY.Value.PadLeft(25, ' ').Substring(3)));

                            fleF010_PAT_KEYS.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                            // --> End GET F010_PAT_KEYS <--
                            if (AccessOk)
                            {
                                ErrorMessage("The changed DIRECT Id is already assigned to another patient");
                            }
                        }
                    }
                }


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldF010_PAT_MSTR_PAT_SURNAME_Process()
        {

            try
            {

                fleF010_PAT_MSTR.set_SetValue("PAT_ACRONYM_FIRST6", PAT_SURNAME.Value.Substring(0, 6));
                fleF010_PAT_MSTR.set_SetValue("PAT_ACRONYM_LAST3", PAT_GIVEN_NAME.Value.Substring(0,3));
                PAT_ACRONYM.Value = fleF010_PAT_MSTR.GetStringValue("PAT_ACRONYM_FIRST6") + fleF010_PAT_MSTR.GetStringValue("PAT_ACRONYM_LAST3");
                Display(ref fldF010_PAT_MSTR_PAT_ACRONYM);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldF010_PAT_MSTR_PAT_GIVEN_NAME_Process()
        {

            try
            {

                fleF010_PAT_MSTR.set_SetValue("PAT_ACRONYM_FIRST6", PAT_SURNAME.Value.Substring(0, 6));
                fleF010_PAT_MSTR.set_SetValue("PAT_ACRONYM_LAST3", PAT_GIVEN_NAME.Value.Substring(0, 3));
                PAT_ACRONYM.Value = fleF010_PAT_MSTR.GetStringValue("PAT_ACRONYM_FIRST6") + fleF010_PAT_MSTR.GetStringValue("PAT_ACRONYM_LAST3");
                Display(ref fldF010_PAT_MSTR_PAT_ACRONYM);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldF010_PAT_MSTR_PAT_BIRTH_DATE_Edit()
        {

            try
            {

                if (QDesign.NULL( PAT_BIRTH_DATE.Value) > QDesign.NULL(QDesign.SysDate(ref m_cnnQUERY)))
                {
                    ErrorMessage("Birth date can`t be in the future - ie. greater than today`s date");
                }
                if (NewRecord() & QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("PAT_PROV_CD")) != QDesign.NULL("NT") & QDesign.NULL(T_PAT_OHIP_MMYY.Value) != QDesign.NULL(" "))
                {
                    if (string.Compare(QDesign.NULL(QDesign.Substring(T_PAT_OHIP_MMYY.Value, 1, 1)), QDesign.NULL("A")) < 0)
                    {
                        W_CCYY.Value = QDesign.Floor( PAT_BIRTH_DATE.Value / 10000);
                        W_CC00.Value = (QDesign.Floor( PAT_BIRTH_DATE.Value / 1000000)) * 100;
                        W_YY.Value = W_CCYY.Value - W_CC00.Value;
                    }
                    else
                    {
                        W_CC000000.Value = (QDesign.Floor( PAT_BIRTH_DATE.Value / 1000000)) * 1000000;
                        W_YYMMDD.Value =  PAT_BIRTH_DATE.Value - W_CC000000.Value;
                        if (QDesign.NULL(W_YYMMDD.Value) != QDesign.NULL(QDesign.NConvert(QDesign.Substring(T_PAT_OHIP_MMYY.Value, 4, 6))))
                        {
                            ErrorMessage("Birth date does not match Direct Date");
                        }
                    }
                }
                if ((ChangeMode | CorrectMode) & QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("PAT_PROV_CD")) != QDesign.NULL("NT") & QDesign.NULL(T_PAT_OHIP_MMYY.Value) != QDesign.NULL(" "))
                {
                    W_OLD_PAT_OHIP_MMYY.Value = T_PAT_OHIP_MMYY.Value;
                    W_OLD_PAT_DIRECT.Value = T_PAT_OHIP_MMYY.Value;
                    PAT_OHIP_MMYY_NUMERIC.Value = QDesign.NConvert(T_PAT_OHIP_MMYY.Value);
                    if (QDesign.NULL(PAT_OHIP_MMYY_NUMERIC.Value) != QDesign.NULL(fleF010_PAT_MSTR.GetDecimalValue("PAT_I_NBR")))
                    {
                        if (string.Compare(QDesign.NULL(QDesign.Substring(T_PAT_OHIP_MMYY.Value, 1, 1)), QDesign.NULL("A")) < 0)
                        {
                            Display(ref fldT_PAT_OHIP_MMYY);
                        }
                        else
                        {
                            W_CC000000.Value = (QDesign.Floor( PAT_BIRTH_DATE.Value / 1000000)) * 1000000;
                            W_YYMMDD.Value =  PAT_BIRTH_DATE.Value - W_CC000000.Value;
                            T_PAT_OHIP_MMYY.Value = QDesign.Substring(T_PAT_OHIP_MMYY.Value, 1, 3) + QDesign.ASCII(W_YYMMDD.Value, 6);
                            Display(ref fldT_PAT_OHIP_MMYY);
                        }
                    }
                    PAT_OHIP_MMYY_NUMERIC.Value = QDesign.NConvert(T_PAT_OHIP_MMYY.Value);
                    if (QDesign.NULL(PAT_OHIP_MMYY_NUMERIC.Value) != QDesign.NULL(fleF010_PAT_MSTR.GetDecimalValue("PAT_I_NBR")) & (QDesign.NULL(W_OLD_PAT_OHIP_MMYY.Value) != QDesign.NULL(T_PAT_OHIP_MMYY.Value) | QDesign.NULL(W_OLD_PAT_DIRECT.Value) != QDesign.NULL(T_PAT_OHIP_MMYY.Value)))
                    {
                        // --> GET F010_PAT_KEYS <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF010_PAT_KEYS.ElementOwner("PAT_BIRTH_DATE_YY")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(T_PAT_OHIP_MMYY.Value.PadLeft(8, ' ').Substring(0, 4)));
                        m_strWhere.Append(" ").Append(fleF010_PAT_KEYS.ElementOwner("PAT_BIRTH_DATE_MM")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(T_PAT_OHIP_MMYY.Value.PadLeft(8, ' ').Substring(4,2)));
                        m_strWhere.Append(" ").Append(fleF010_PAT_KEYS.ElementOwner("PAT_BIRTH_DATE_DD")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(T_PAT_OHIP_MMYY.Value.PadLeft(8, ' ').Substring(6)));

                        fleF010_PAT_KEYS.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F010_PAT_KEYS <--
                        if (AccessOk)
                        {
                            ErrorMessage("The changed OHIP/DIRECT Nbr is already assigned to another patient");
                        }
                    }
                }


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldF010_PAT_MSTR_SUBSCR_ADDR3_Process()
        {

            try
            {

                if (QDesign.NULL(W_SUBSCR_ADDR3.Value) != QDesign.NULL(" "))
                {
                    fleF010_PAT_MSTR.set_SetValue("SUBSCR_ADDR3", W_SUBSCR_ADDR3.Value);
                }
                if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Hamilton") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Dundas") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Hamilton") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Stoney Creek") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Dundas") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Dunnville") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Waterdown") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("St. Catharines") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Oakville") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Grimsby") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Fruitland") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Hannon") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Flamboro") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Niagara On The Lake") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Niagara Falls") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Fort Erie") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Welland") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Toronto") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Don Mills") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Willowdale") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Burlington") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Markham") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Richmond Hill") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Thorold") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Malton") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Mississauga") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Scarborough") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("North York") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Beamsville") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Brampton") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Weston") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Etobicoke") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Brantford") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Georgetown") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Guelph") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Thornhill") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Downsview") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Islington") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Rexdale") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Agincourt") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Ancaster") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Millgrove") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Caledonia") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Simcoe") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Hagersville") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Jarvis") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Kitchener") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Campbellville") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Copetown") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Paris") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Waterford") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Barrie") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Cambridge") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Greensville") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Binbrook") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Caistor Centre") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Carlisle") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Cayuga") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Freelton") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Lynden") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Milton") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Mount Hope") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Ohsweken") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Port Colborne") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Port Dover") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Puslinch") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Sault Ste. Marie") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Smithville") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Sudbury") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Thunder Bay") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Fonthill") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Wainfleet") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Crystal Beach") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Vinemount") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Vineland") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Waterloo") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3")) == QDesign.NULL("Winona"))
                {
                    fleF010_PAT_MSTR.set_SetValue("SUBSCR_PROV_CD", "ON");
                    Display(ref fldF010_PAT_MSTR_SUBSCR_PROV_CD);
                    W_SKIP_SUBSCR_PROV_FIELD.Value = "Y";
                }
                else
                {
                    W_SKIP_SUBSCR_PROV_FIELD.Value = "N";
                }


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldF010_PAT_MSTR_SUBSCR_MSG_NBR_Input()
        {

            try
            {

                if (QDesign.NULL(FieldText) == QDesign.NULL("."))
                {
                    W_MSG_NBR.Value = " ";
                    //object[] arrRunscreen = { W_MSG_NBR };
                    //RunScreen(new Billing_SY030(),  RunScreenModes.Find, ref arrRunscreen);
                    FieldText = W_MSG_NBR.Value;
                }


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldF010_PAT_MSTR_SUBSCR_MSG_NBR_Edit()
        {

            try
            {

                if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_MSG_NBR")) != QDesign.NULL("00"))
                {
                    // --> GET F094_MSG_MSTR <--

                    fleF094_MSG_MSTR.GetData(GetDataOptions.IsOptional);
                    // --> End GET F094_MSG_MSTR <--
                    if (!AccessOk)
                    {
                        ErrorMessage("*Error* Message Number not defined. Use . to search.");
                    }
                }


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldF010_PAT_MSTR_SUBSCR_MSG_NBR_Process()
        {

            try
            {

                if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_MSG_NBR")) == QDesign.NULL("00"))
                {
                    fleF010_PAT_MSTR.set_SetValue("SUBSCR_DATE_MSG_NBR_EFFECT_TO_YY", 0);
                    fleF010_PAT_MSTR.set_SetValue("SUBSCR_DATE_MSG_NBR_EFFECT_TO_MM", 0);
                    fleF010_PAT_MSTR.set_SetValue("SUBSCR_DATE_MSG_NBR_EFFECT_TO_DD", 0);
                    Display(ref fldF010_PAT_MSTR_SUBSCR_DATE_MSG_NBR_EFFECTIVE_TO);
                }


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldF010_PAT_MSTR_SUBSCR_DATE_MSG_NBR_EFFECTIVE_TO_Input()
        {

            try
            {

                if ((ChangeMode) & QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_MSG_NBR")) != QDesign.NULL("00") & 0 == FieldText.Length  
                    & QDesign.NULL(SUBSCR_DATE_MSG_NBR_EFFECTIVE_TO.Value) == 0)
                {
                    ErrorMessage("Msg Effective Date must be entered");
                }


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldF010_PAT_MSTR_SUBSCR_DATE_MSG_NBR_EFFECTIVE_TO_Edit()
        {

            try
            {

                if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_MSG_NBR")) != QDesign.NULL("00"))
                {
                    if (QDesign.NULL(SUBSCR_DATE_MSG_NBR_EFFECTIVE_TO.Value)
                        < QDesign.NULL(QDesign.SysDate(ref m_cnnQUERY)))
                    {
                        ErrorMessage("Effective Date must be greater than System Date");
                    }
                }


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_12_Click(object sender, System.EventArgs e)
        {

            try
            {

                Accept(ref fldF010_PAT_MSTR_SUBSCR_ADDR1);
                Accept(ref fldF010_PAT_MSTR_SUBSCR_ADDR2);
                Accept(ref fldF010_PAT_MSTR_SUBSCR_ADDR3);
                if (QDesign.NULL(W_SKIP_SUBSCR_PROV_FIELD.Value) == QDesign.NULL("N"))
                {
                    Accept(ref fldF010_PAT_MSTR_SUBSCR_PROV_CD);
                }
                Accept(ref fldF010_PAT_MSTR_SUBSCR_POSTAL_CD);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_MESS_Click(object sender, System.EventArgs e)
        {

            try
            {

                Accept(ref fldW_PASSWORD);
                if (QDesign.NULL(W_PASSWORD.Value) == QDesign.NULL("MC") | QDesign.NULL(W_PASSWORD.Value) == QDesign.NULL("mc"))
                {
                    fleF010_PAT_MSTR.set_SetValue("PAT_MESS_CODE", " ");
                    Display(ref fldF010_PAT_MSTR_PAT_MESS_CODE);
                }


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_OCLM_Click(object sender, System.EventArgs e)
        {

            try
            {

                Accept(ref fldW_PASSWORD);
                if (QDesign.NULL(W_PASSWORD.Value) == QDesign.NULL("GCN"))
                {
                    Accept(ref fldF010_PAT_MSTR_PAT_NBR_OUTSTANDING_CLAIMS);
                }


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_NOTE_Click(object sender, System.EventArgs e)
        {

            try
            {

                PAT_IKEY.Value = fleF010_PAT_MSTR.GetStringValue("PAT_I_KEY") + QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_CON_NBR"), 2) + QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_I_NBR"), 12) + fleF010_PAT_MSTR.GetStringValue("FILLER4");
              
                BATCH_NBR.Value = " ";
                CLAIM_NBR.Value = 0;
                CALL_PGM.Value = "M010";
                object[] arrRunscreen = { PAT_IKEY, BATCH_NBR, CLAIM_NBR, CALL_PGM };
                RunScreen(new Moira_M010_CRM(), RunScreenModes.Find, ref arrRunscreen);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_INS_Click(object sender, System.EventArgs e)
        {

            try
            {

                PAT_IKEY.Value = fleF010_PAT_MSTR.GetStringValue("PAT_I_KEY") + QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_CON_NBR"), 2) + QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_I_NBR"), 12) + fleF010_PAT_MSTR.GetStringValue("FILLER4");
              
                BATCH_NBR.Value = " ";
                CLAIM_NBR.Value = 0;
                CALL_PGM.Value = "M010";
                //object[] arrRunscreen = { PAT_IKEY, BATCH_NBR, CLAIM_NBR, CALL_PGM };
                //RunScreen(new Billing_M010_INS(), RunScreenModes.Find, ref arrRunscreen);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }


        protected override bool Path()
        {


            try
            {

                RequestPrompt(ref fldF010_PAT_MSTR_PAT_ACRONYM);
                if (m_blnPromptOK)
                {
                    //Parent:PAT_ACRONYM
                    if (QDesign.NULL(PAT_ACRONYM.Value) == QDesign.NULL("."))
                    {
                        W_CH16.Value = " ";
                        object[] arrRunscreen = { W_CH16 };
                        RunScreen(new Billing_M010_ACR(), RunScreenModes.Find, ref arrRunscreen);
                        if (string.Compare(QDesign.NULL(W_CH16.Value), QDesign.NULL(" ")) > 0)
                        {
                            m_intPath = 2;
                        }
                    }
                    else
                    {
                        m_intPath = 1;
                    }
                }
                if (m_intPath == 0)
                {
                    RequestPrompt(ref fldF010_PAT_MSTR_PAT_HEALTH_NBR);
                    if (m_blnPromptOK)
                    {
                        m_intPath = 3;
                    }
                }
                if (m_intPath == 0)
                {
                    RequestPrompt(ref fldT_PAT_OHIP_MMYY);
                    if (m_blnPromptOK)
                    {
                        m_intPath = 4;
                    }
                }
                if (m_intPath == 0)
                {
                    RequestPrompt(ref fldT_PAT_CHART_NBR_5);
                    if (m_blnPromptOK)
                    {
                        m_intPath = 5;
                    }
                }
                if (m_intPath == 0)
                {
                    RequestPrompt(ref fldT_PAT_CHART_NBR);
                    if (m_blnPromptOK)
                    {
                        m_intPath = 6;
                    }
                }
                if (m_intPath == 0)
                {
                    RequestPrompt(ref fldT_PAT_CHART_NBR_2);
                    if (m_blnPromptOK)
                    {
                        m_intPath = 7;
                    }
                }
                if (m_intPath == 0)
                {
                    RequestPrompt(ref fldT_PAT_CHART_NBR_3);
                    if (m_blnPromptOK)
                    {
                        m_intPath = 8;
                    }
                }
                if (m_intPath == 0)
                {
                    RequestPrompt(ref fldT_PAT_CHART_NBR_4);
                    if (m_blnPromptOK)
                    {
                        m_intPath = 9;
                    }
                }
                if (m_intPath == 0)
                {
                    ErrorMessage(QDesign.NULL("Key Required."));
                    // TODO: May need to fix manually
                }

                return true;


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }


        protected override bool PreUpdate()
        {


            try
            {

                if (!DeletedRecord())
                {

                    fleF010_PAT_MSTR_SetItemFinals();

                    if (QDesign.NULL(fleF010_PAT_MSTR.GetDecimalValue("PAT_HEALTH_NBR")) == 0 & QDesign.NULL(T_PAT_OHIP_MMYY.Value) == QDesign.NULL(" ") & QDesign.NULL(T_PAT_CHART_NBR.Value) == QDesign.NULL(" ") & QDesign.NULL(T_PAT_CHART_NBR_2.Value) == QDesign.NULL(" ") & QDesign.NULL(T_PAT_CHART_NBR_3.Value) == QDesign.NULL(" ") & QDesign.NULL(T_PAT_CHART_NBR_4.Value) == QDesign.NULL(" ") & QDesign.NULL(T_PAT_CHART_NBR_5.Value) == QDesign.NULL(" "))
                    {
                        ErrorMessage("One of Health Nbr, Ohip Nbr, Direct Id or Chart Nbr must be entered");
                    }
                    //Parent:PAT_GIVEN_NAME
                    if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("PAT_SURNAME_FIRST3") + fleF010_PAT_MSTR.GetStringValue("PAT_SURNAME_LAST22")) == QDesign.NULL(" ") | QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("PAT_GIVEN_NAME_FIRST1") + fleF010_PAT_MSTR.GetStringValue("FILLER3")) == QDesign.NULL(" "))
                    {
                        ErrorMessage("Both patient`s given name and surname must be entered");
                    }
                }
                if (DeletedRecord() & QDesign.NULL(fleF010_PAT_MSTR.GetDecimalValue("PAT_NBR_OUTSTANDING_CLAIMS")) > 0)
                {
                    ErrorMessage("PATIENT HAS ACTIVE CLAIMS - CANNOT BE DELETED");
                }
                if (NewRecord())
                {
                    // --> GET CONSTANTS_MSTR_REC_5 <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleCONSTANTS_MSTR_REC_5.ElementOwner("CONST_REC_NBR")).Append(" = ");
                    m_strWhere.Append(5);

                    fleCONSTANTS_MSTR_REC_5.GetData(m_strWhere.ToString());
                    // --> End GET CONSTANTS_MSTR_REC_5 <--
                    while (fleCONSTANTS_MSTR_REC_5.For())
                    {
                        //W_PORT_ID.Value = QDesign.NConvert(QDesign.Substring(UserEnv("TERMINAL"), 10, 2)) + 1;
                        // TODO: CONST_CON_NBR occurs 25.  Manual steps may be required.
                        W_PORT_ID.Value = 1;

                        if (QDesign.NULL(fleCONSTANTS_MSTR_REC_5.GetDecimalValue("CONST_CON_NBR" + Occurrence.ToString())) == QDesign.NULL(W_PORT_ID.Value))
                        {
                            fleF010_PAT_MSTR.set_SetValue("PAT_CON_NBR", fleCONSTANTS_MSTR_REC_5.GetDecimalValue("CONST_CON_NBR" + Occurrence.ToString()));
                            // TODO: CONST_CON_NBR occurs 25.  Manual steps may be required.
                            fleF010_PAT_MSTR.set_SetValue("PAT_I_NBR", fleCONSTANTS_MSTR_REC_5.GetDecimalValue("CONST_NX_AVAIL_PAT" + Occurrence.ToString()));
                            // TODO: CONST_NX_AVAIL_PAT occurs 25.  Manual steps may be required.
                            KEY_PAT_MSTR.Value = QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("PAT_I_KEY") + QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_CON_NBR"), 2) + QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_I_NBR"), 12) + fleF010_PAT_MSTR.GetStringValue("FILLER4"));
                            Display(ref fldF010_PAT_MSTR_KEY_PAT_MSTR);
                            fleCONSTANTS_MSTR_REC_5.set_SetValue("CONST_NX_AVAIL_PAT" + Occurrence.ToString(), fleCONSTANTS_MSTR_REC_5.GetDecimalValue("CONST_NX_AVAIL_PAT" + Occurrence.ToString()) + 1);
                            // TODO: CONST_NX_AVAIL_PAT occurs 25.  Manual steps may be required.' TODO: CONST_NX_AVAIL_PAT occurs 25.  Manual steps may be required.
                        }
                    }
                    //fleCONSTANTS_MSTR_REC_5.PutData();
                }
                if (AlteredRecord() & ChangeMode)
                {
                    fleF010_PAT_MSTR.set_SetValue("PAT_DATE_LAST_MAINT", QDesign.SysDate(ref m_cnnQUERY));
                    if (QDesign.NULL(W_OLD_BIRTH_DATE.Value) != QDesign.NULL(PAT_BIRTH_DATE.Value))
                    {
                        fleF010_PAT_MSTR.set_SetValue("PAT_LAST_BIRTH_DATE", W_OLD_BIRTH_DATE.Value);
                    }
                    if (QDesign.NULL(W_OLD_VERSION_CD.Value) != QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("PAT_VERSION_CD")))
                    {
                        fleF010_PAT_MSTR.set_SetValue("PAT_LAST_VERSION_CD", W_OLD_VERSION_CD.Value);
                    }
                    if (QDesign.NULL(W_OLD_VERSION_CD.Value) != QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("PAT_VERSION_CD")) | QDesign.NULL(W_OLD_BIRTH_DATE.Value) != QDesign.NULL( PAT_BIRTH_DATE.Value))
                    {
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append("").Append(fleREJECTED_CLAIMS.ElementOwner("CLMHDR_PAT_OHIP_ID_OR_CHART")).Append(" = ").Append(Common.StringToField(fleF010_PAT_MSTR.GetStringValue("PAT_I_KEY") + QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_CON_NBR"), 2) + QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_I_NBR"), 12) + fleF010_PAT_MSTR.GetStringValue("FILLER4")));
                       

                        while (fleREJECTED_CLAIMS.WhileRetrieving(m_strWhere.ToString()))
                        {
                            fleREJECTED_CLAIMS.set_SetValue("LOGICALLY_DELETED_FLAG", "Y");
                            fleREJECTED_CLAIMS.PutData();
                        }
                    }
                    if ((QDesign.NULL(W_OLD_BIRTH_DATE.Value) != QDesign.NULL( PAT_BIRTH_DATE.Value) | QDesign.NULL(W_OLD_VERSION_CD.Value) != QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("PAT_VERSION_CD")) | QDesign.NULL(W_OLD_HEALTH_NBR.Value) != QDesign.NULL(fleF010_PAT_MSTR.GetDecimalValue("PAT_HEALTH_NBR"))))
                    {
                        fleF010_PAT_MSTR.set_SetValue("PAT_DATE_LAST_ELIG_MAINT", QDesign.SysDate(ref m_cnnQUERY));
                        fleF010_PAT_MSTR.set_SetValue("PAT_MESS_CODE", " ");
                        fleF010_PAT_MSTR.set_SetValue("PAT_NO_OF_LETTER_SENT", 0);
                        fleF086_PAT_ID.set_SetValue("CLMHDR_PAT_OHIP_ID_OR_CHART", fleF010_PAT_MSTR.GetStringValue("PAT_I_KEY") + QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_CON_NBR"), 2) + QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_I_NBR"), 12) + fleF010_PAT_MSTR.GetStringValue("FILLER4"));
                       
                        fleF086_PAT_ID.set_SetValue("PAT_LAST_BIRTH_DATE", fleF010_PAT_MSTR.GetNumericDateValue("PAT_LAST_BIRTH_DATE"));
                        fleF086_PAT_ID.set_SetValue("PAT_LAST_VERSION_CD", fleF010_PAT_MSTR.GetStringValue("PAT_LAST_VERSION_CD"));
                        fleF086_PAT_ID.set_SetValue("PAT_OLD_SURNAME", W_OLD_SURNAME.Value);
                        fleF086_PAT_ID.set_SetValue("PAT_OLD_GIVEN_NAME", W_OLD_GIVEN_NAME.Value);
                        fleF086_PAT_ID.set_SetValue("PAT_OLD_HEALTH_NBR", W_OLD_HEALTH_NBR.Value);
                        fleF086_PAT_ID.set_SetValue("PAT_OLD_CHART_NBR", W_OLD_CHART_NBR.Value);
                        fleF086_PAT_ID.set_SetValue("PAT_OLD_CHART_NBR_2", W_OLD_CHART_NBR_2.Value);
                        fleF086_PAT_ID.set_SetValue("PAT_OLD_CHART_NBR_3", W_OLD_CHART_NBR_3.Value);
                        fleF086_PAT_ID.set_SetValue("PAT_OLD_CHART_NBR_4", W_OLD_CHART_NBR_4.Value);
                        fleF086_PAT_ID.set_SetValue("PAT_OLD_CHART_NBR_5", W_OLD_CHART_NBR_5.Value);
                        fleF086_PAT_ID.set_SetValue("PAT_OLD_ADDR1", W_OLD_ADDR1.Value);
                        fleF086_PAT_ID.set_SetValue("PAT_OLD_ADDR2", W_OLD_ADDR2.Value);
                        fleF086_PAT_ID.set_SetValue("PAT_OLD_ADDR3", W_OLD_ADDR3.Value);
                        fleF086_PAT_ID.PutData();
                        fleF011_PAT_MSTR_ELIG_HISTORY.set_SetValue("PAT_I_KEY", fleF010_PAT_MSTR.GetStringValue("PAT_I_KEY"));
                      
                        fleF011_PAT_MSTR_ELIG_HISTORY.set_SetValue("PAT_CON_NBR", (fleF010_PAT_MSTR.GetStringValue("PAT_I_KEY") + QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_CON_NBR"), 2) + QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_I_NBR"), 12) + fleF010_PAT_MSTR.GetStringValue("FILLER4")).PadRight(16).Substring(1, 2));
                    
                        fleF011_PAT_MSTR_ELIG_HISTORY.set_SetValue("PAT_I_NBR", (fleF010_PAT_MSTR.GetStringValue("PAT_I_KEY") + QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_CON_NBR"), 2) + QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_I_NBR"), 12) + fleF010_PAT_MSTR.GetStringValue("FILLER4")).PadRight(16).Substring(3, 12));
             
                        fleF011_PAT_MSTR_ELIG_HISTORY.set_SetValue("FILLER4", (fleF010_PAT_MSTR.GetStringValue("PAT_I_KEY") + QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_CON_NBR"), 2) + QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_I_NBR"), 12) + fleF010_PAT_MSTR.GetStringValue("FILLER4")).PadRight(16).Substring(15, 1));
                   
                        fleF011_PAT_MSTR_ELIG_HISTORY.set_SetValue("PAT_DATE_LAST_MAINT", QDesign.SysDate(ref m_cnnQUERY));
                        fleF011_PAT_MSTR_ELIG_HISTORY.set_SetValue("ENTRY_TIME_LONG", QDesign.SysTime(ref m_cnnQUERY));
                        fleF011_PAT_MSTR_ELIG_HISTORY.set_SetValue("PAT_EXPIRY_YY", (fleF010_PAT_MSTR.GetDecimalValue("PAT_EXPIRY_YY")).ToString());
                        //Parent:PAT_EXPIRY_DATE
                        fleF011_PAT_MSTR_ELIG_HISTORY.set_SetValue("PAT_EXPIRY_MM", (fleF010_PAT_MSTR.GetDecimalValue("PAT_EXPIRY_MM")).ToString());
                        //Parent:PAT_EXPIRY_DATE
                        fleF011_PAT_MSTR_ELIG_HISTORY.set_SetValue("PAT_HEALTH_NBR", fleF010_PAT_MSTR.GetDecimalValue("PAT_HEALTH_NBR"));
                        fleF011_PAT_MSTR_ELIG_HISTORY.set_SetValue("PAT_LAST_HEALTH_NBR", fleF010_PAT_MSTR.GetDecimalValue("PAT_HEALTH_NBR"));
                        fleF011_PAT_MSTR_ELIG_HISTORY.set_SetValue("PAT_VERSION_CD", fleF010_PAT_MSTR.GetStringValue("PAT_VERSION_CD"));
                        fleF011_PAT_MSTR_ELIG_HISTORY.set_SetValue("PAT_LAST_VERSION_CD", fleF010_PAT_MSTR.GetStringValue("PAT_LAST_VERSION_CD"));
                        fleF011_PAT_MSTR_ELIG_HISTORY.set_SetValue("PAT_BIRTH_DATE",  PAT_BIRTH_DATE.Value);
                        fleF011_PAT_MSTR_ELIG_HISTORY.set_SetValue("PAT_BIRTH_DATE_LAST", fleF010_PAT_MSTR.GetNumericDateValue("PAT_LAST_BIRTH_DATE"));
                        fleF011_PAT_MSTR_ELIG_HISTORY.PutData();
                    }
                }
                if (!DeletedRecord())
                {
                    fleF010_PAT_MSTR.set_SetValue("PAT_DIRECT_ALPHA", (T_PAT_OHIP_MMYY.Value).PadRight(15).Substring(0, 3));
                    fleF010_PAT_MSTR.set_SetValue("PAT_DIRECT_YY", (T_PAT_OHIP_MMYY.Value.Trim()).PadRight(15,'0').Substring(3, 2));
                    fleF010_PAT_MSTR.set_SetValue("PAT_DIRECT_MM", (T_PAT_OHIP_MMYY.Value.Trim()).PadRight(15, '0').Substring(5, 2));
                    fleF010_PAT_MSTR.set_SetValue("PAT_DIRECT_DD", (T_PAT_OHIP_MMYY.Value.Trim()).PadRight(15, '0').Substring(7, 2));
                    fleF010_PAT_MSTR.set_SetValue("PAT_DIRECT_LAST_6", (T_PAT_OHIP_MMYY.Value).PadRight(15).Substring(9));




                    fleF010_PAT_MSTR.set_SetValue("PAT_CHART_NBR", T_PAT_CHART_NBR.Value);
                    fleF010_PAT_MSTR.set_SetValue("PAT_CHART_NBR_2", T_PAT_CHART_NBR_2.Value);
                    fleF010_PAT_MSTR.set_SetValue("PAT_CHART_NBR_3", T_PAT_CHART_NBR_3.Value);
                    fleF010_PAT_MSTR.set_SetValue("PAT_CHART_NBR_4", T_PAT_CHART_NBR_4.Value);
                    fleF010_PAT_MSTR.set_SetValue("PAT_CHART_NBR_5", T_PAT_CHART_NBR_5.Value);
                  
                    if (QDesign.NULL(T_PAT_CHART_NBR.Value) == QDesign.NULL(" "))
                    {
                        fleF010_PAT_MSTR.set_SetValue("PAT_CHART_NBR", QDesign.Substring(fleF010_PAT_MSTR.GetStringValue("PAT_I_KEY") + QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_CON_NBR"), 2) + QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_I_NBR"), 12) + fleF010_PAT_MSTR.GetStringValue("FILLER4"), 6, 10));
                        
                    }
                    if (QDesign.NULL(T_PAT_CHART_NBR_2.Value) == QDesign.NULL(" "))
                    {
                        fleF010_PAT_MSTR.set_SetValue("PAT_CHART_NBR_2", QDesign.Substring(fleF010_PAT_MSTR.GetStringValue("PAT_I_KEY") + QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_CON_NBR"), 2) + QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_I_NBR"), 12) + fleF010_PAT_MSTR.GetStringValue("FILLER4"), 6, 10));
                        
                    }
                    if (QDesign.NULL(T_PAT_CHART_NBR_3.Value) == QDesign.NULL(" "))
                    {
                        fleF010_PAT_MSTR.set_SetValue("PAT_CHART_NBR_3", QDesign.Substring(fleF010_PAT_MSTR.GetStringValue("PAT_I_KEY") + QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_CON_NBR"), 2) + QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_I_NBR"), 12) + fleF010_PAT_MSTR.GetStringValue("FILLER4"), 6, 10));
                        
                    }
                    if (QDesign.NULL(T_PAT_CHART_NBR_4.Value) == QDesign.NULL(" "))
                    {
                        fleF010_PAT_MSTR.set_SetValue("PAT_CHART_NBR_4", "?" + QDesign.Substring(fleF010_PAT_MSTR.GetStringValue("PAT_I_KEY") + QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_CON_NBR"), 2) + QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_I_NBR"), 12) + fleF010_PAT_MSTR.GetStringValue("FILLER4"), 7, 9));
                        
                    }
                    if (QDesign.NULL(T_PAT_CHART_NBR_5.Value) == QDesign.NULL(" "))
                    {
                        fleF010_PAT_MSTR.set_SetValue("PAT_CHART_NBR_5", QDesign.Substring(fleF010_PAT_MSTR.GetStringValue("PAT_I_KEY") + QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_CON_NBR"), 2) + QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_I_NBR"), 12) + fleF010_PAT_MSTR.GetStringValue("FILLER4"), 5, 11));
                        
                    }
                }

                return true;


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        protected override bool Find()
        {


            try
            {
                bool blnAddWhere = true;
                switch (m_intPath)
                {
                    case 1:
                        m_strWhere = new StringBuilder(GetWhereCondition(fleF010_PAT_MSTR.ElementOwner("PAT_ACRONYM_FIRST6"), PAT_ACRONYM.Value.PadRight(9, ' ').Substring(0, 6), ref blnAddWhere));
                        m_strWhere.Append(GetWhereCondition(fleF010_PAT_MSTR.ElementOwner("PAT_ACRONYM_LAST3"), PAT_ACRONYM.Value.PadRight(9, ' ').Substring(6, 3), ref blnAddWhere));
                        fleF010_PAT_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
                        break;
                    case 2:
                        m_strWhere = new StringBuilder(GetWhereCondition(fleF010_PAT_MSTR.ElementOwner("PAT_I_KEY"), W_CH16.Value.PadRight(16, ' ').Substring(0, 1), ref blnAddWhere));                      
                        m_strWhere.Append(GetWhereCondition(fleF010_PAT_MSTR.ElementOwner("PAT_CON_NBR"), W_CH16.Value.PadRight(16, ' ').Substring(1, 2), ref blnAddWhere));                      
                        m_strWhere.Append(GetWhereCondition(fleF010_PAT_MSTR.ElementOwner("PAT_I_NBR"), W_CH16.Value.PadRight(16, ' ').Substring(3, 12), ref blnAddWhere));                       
                        m_strWhere.Append(GetWhereCondition(fleF010_PAT_MSTR.ElementOwner("FILLER4"), W_CH16.Value.PadRight(16, ' ').Substring(15, 1), ref blnAddWhere));
                        fleF010_PAT_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
                        break;
                    case 3:
                        m_strWhere = new StringBuilder(GetWhereCondition(fleF010_PAT_MSTR.ElementOwner("PAT_HEALTH_NBR"), fleF010_PAT_MSTR.GetDecimalValue("PAT_HEALTH_NBR"), ref blnAddWhere));    
                        fleF010_PAT_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
                        break;
                    case 4:
                        m_strWhere = new StringBuilder(GetWhereCondition(fleF010_PAT_MSTR.ElementOwner("PAT_DIRECT_ALPHA"), T_PAT_OHIP_MMYY.Value.PadRight(15, ' ').Substring(0, 3), ref blnAddWhere));
                        m_strWhere.Append(GetWhereCondition(fleF010_PAT_MSTR.ElementOwner("PAT_DIRECT_YY"), QDesign.NConvert( T_PAT_OHIP_MMYY.Value.PadRight(15, ' ').Substring(3, 2)), ref blnAddWhere));
                        m_strWhere.Append(GetWhereCondition(fleF010_PAT_MSTR.ElementOwner("PAT_DIRECT_MM"), QDesign.NConvert(T_PAT_OHIP_MMYY.Value.PadRight(15, ' ').Substring(5, 2)), ref blnAddWhere));
                        m_strWhere.Append(GetWhereCondition(fleF010_PAT_MSTR.ElementOwner("PAT_DIRECT_DD"), QDesign.NConvert(T_PAT_OHIP_MMYY.Value.PadRight(15, ' ').Substring(7, 2)), ref blnAddWhere));
                        m_strWhere.Append(GetWhereCondition(fleF010_PAT_MSTR.ElementOwner("PAT_DIRECT_LAST_6"), T_PAT_OHIP_MMYY.Value.PadRight(15, ' ').Substring(9), ref blnAddWhere));
                        fleF010_PAT_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
                        break;
                    case 5:
                        m_strWhere = new StringBuilder(GetWhereCondition(fleF010_PAT_MSTR.ElementOwner("PAT_CHART_NBR_5"), T_PAT_CHART_NBR_5.Value, ref blnAddWhere));                       
                        fleF010_PAT_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
                        break;
                    case 6:
                        m_strWhere = new StringBuilder(GetWhereCondition(fleF010_PAT_MSTR.ElementOwner("PAT_CHART_NBR"), T_PAT_CHART_NBR.Value, ref blnAddWhere));                      
                        fleF010_PAT_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
                        break;
                    case 7:
                        m_strWhere = new StringBuilder(GetWhereCondition(fleF010_PAT_MSTR.ElementOwner("PAT_CHART_NBR_2"), T_PAT_CHART_NBR_2.Value, ref blnAddWhere));                      
                        fleF010_PAT_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
                        break;
                    case 8:
                        m_strWhere = new StringBuilder(GetWhereCondition(fleF010_PAT_MSTR.ElementOwner("PAT_CHART_NBR_3"), T_PAT_CHART_NBR_3.Value, ref blnAddWhere));
                         fleF010_PAT_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
                        break;
                    case 9:
                        m_strWhere = new StringBuilder(GetWhereCondition(fleF010_PAT_MSTR.ElementOwner("PAT_CHART_NBR_4"), T_PAT_CHART_NBR_4.Value, ref blnAddWhere));
                        fleF010_PAT_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
                        break;
                }


                return true;


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }




        public override void PagePostProcess(PageArgs e)
        {

            try
            {
                Page.PageTitle = "PATIENT MASTER MAINTENANCE";



            }
            catch (CustomApplicationException ex)
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
        //# Entry Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 6/2/2017 12:49:11 PM
        //#-----------------------------------------
        protected override bool Entry()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 6/2/2017 12:49:11 PM
                Accept(ref fldF010_PAT_MSTR_PAT_PROV_CD);
                Display(ref fldF010_PAT_MSTR_PAT_ACRONYM);
                Accept(ref fldF010_PAT_MSTR_PAT_HEALTH_NBR);
                Accept(ref fldT_PAT_OHIP_MMYY);
                Accept(ref fldT_PAT_CHART_NBR_5);
                Display(ref fldT_PAT_CHART_NBR);
                Display(ref fldT_PAT_CHART_NBR_2);
                Display(ref fldT_PAT_CHART_NBR_3);
                Display(ref fldT_PAT_CHART_NBR_4);
                Accept(ref fldF010_PAT_MSTR_PAT_SURNAME);
                Accept(ref fldF010_PAT_MSTR_PAT_GIVEN_NAME);
                Accept(ref fldF010_PAT_MSTR_PAT_INIT);
                Accept(ref fldF010_PAT_MSTR_PAT_BIRTH_DATE);
                Display(ref fldF010_PAT_MSTR_PAT_LAST_BIRTH_DATE);
                Accept(ref fldF010_PAT_MSTR_PAT_SEX);
                Accept(ref fldF010_PAT_MSTR_PAT_HEALTH_65_IND);
                Accept(ref fldF010_PAT_MSTR_PAT_VERSION_CD);
                Display(ref fldF010_PAT_MSTR_PAT_LAST_VERSION_CD);
                Accept(ref fldF010_PAT_MSTR_PAT_EXPIRY_DATE);
                Accept(ref fldF010_PAT_MSTR_PAT_PHONE_NBR);
                Accept(ref fldF010_PAT_MSTR_SUBSCR_ADDR1);
                Accept(ref fldF010_PAT_MSTR_SUBSCR_ADDR2);
                Accept(ref fldF010_PAT_MSTR_SUBSCR_ADDR3);
                if (QDesign.NULL(W_SKIP_SUBSCR_PROV_FIELD.Value) == QDesign.NULL("N"))
                {
                    Accept(ref fldF010_PAT_MSTR_SUBSCR_PROV_CD);
                }
                else
                {
                    Display(ref fldF010_PAT_MSTR_SUBSCR_PROV_CD);
                }
                Accept(ref fldF010_PAT_MSTR_SUBSCR_POSTAL_CD);
                Accept(ref fldF010_PAT_MSTR_SUBSCR_MSG_NBR);
                if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("SUBSCR_MSG_NBR")) != QDesign.NULL("00"))
                {
                    Accept(ref fldF010_PAT_MSTR_SUBSCR_DATE_MSG_NBR_EFFECTIVE_TO);
                }
                else
                {
                    Display(ref fldF010_PAT_MSTR_SUBSCR_DATE_MSG_NBR_EFFECTIVE_TO);
                }
                Accept(ref fldF010_PAT_MSTR_SUBSCR_AUTO_UPDATE);
                Accept(ref fldF010_PAT_MSTR_PAT_DIALYSIS);
                Display(ref fldF010_PAT_MSTR_PAT_OHIP_VALIDATION_STATUS);
                Display(ref fldF010_PAT_MSTR_PAT_LOCATION_FIELD);
                Display(ref fldF010_PAT_MSTR_PAT_LAST_DOC_NBR_SEEN);
                Display(ref fldF010_PAT_MSTR_PAT_IN_OUT);
                Display(ref fldF010_PAT_MSTR_PAT_DATE_LAST_VISIT);
                Display(ref fldF010_PAT_MSTR_PAT_DATE_LAST_ADMIT);
                Display(ref fldF010_PAT_MSTR_PAT_DATE_LAST_MAINT);
                Display(ref fldF010_PAT_MSTR_PAT_DATE_LAST_ELIG_MAILING);
                Display(ref fldF010_PAT_MSTR_PAT_DATE_LAST_ELIG_MAINT);
                Display(ref fldF010_PAT_MSTR_PAT_MESS_CODE);
                Display(ref fldF010_PAT_MSTR_PAT_NO_OF_LETTER_SENT);
                Display(ref fldF010_PAT_MSTR_PAT_TOTAL_NBR_VISITS);
                Display(ref fldF010_PAT_MSTR_PAT_TOTAL_NBR_CLAIMS);
                Display(ref fldF010_PAT_MSTR_PAT_NBR_OUTSTANDING_CLAIMS);
                Display(ref fldF010_PAT_MSTR_KEY_PAT_MSTR);
                Display(ref fldW_PASSWORD);
                //#END STANDARD PROCEDURE CONTENT
                return true;

            }
            catch (CustomApplicationException ex)
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
        //# Update Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 6/2/2017 12:49:11 PM
        //#-----------------------------------------
        protected override bool Update()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 6/2/2017 12:49:11 PM
                fleF010_PAT_MSTR.PutData(false, PutTypes.New);
                fleF010_PAT_MSTR.PutData();
                fleCONSTANTS_MSTR_REC_5.PutData();
                //#END STANDARD PROCEDURE CONTENT
                return true;

            }
            catch (CustomApplicationException ex)
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
        //# Delete Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 6/2/2017 12:49:11 PM
        //#-----------------------------------------
        protected override bool Delete()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 6/2/2017 12:49:11 PM
                fleF010_PAT_MSTR.DeletedRecord = true;
                //#END STANDARD PROCEDURE CONTENT
                return true;

            }
            catch (CustomApplicationException ex)
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
        //# dsrDesigner_09_Click Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 6/2/2017 12:49:12 PM
        //#-----------------------------------------
        private void dsrDesigner_09_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 6/2/2017 12:49:12 PM
                Accept(ref fldF010_PAT_MSTR_PAT_BIRTH_DATE);
                Display(ref fldF010_PAT_MSTR_PAT_LAST_BIRTH_DATE);
                Accept(ref fldF010_PAT_MSTR_PAT_SEX);
                //#END STANDARD PROCEDURE CONTENT

            }
            catch (CustomApplicationException ex)
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
        //# dsrDesigner_22_Click Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 6/2/2017 12:49:12 PM
        //#-----------------------------------------
        private void dsrDesigner_22_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 6/2/2017 12:49:12 PM
                Display(ref fldF010_PAT_MSTR_PAT_TOTAL_NBR_VISITS);
                Display(ref fldF010_PAT_MSTR_PAT_TOTAL_NBR_CLAIMS);
                //#END STANDARD PROCEDURE CONTENT

            }
            catch (CustomApplicationException ex)
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
        //# dsrDesigner_13_Click Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 6/2/2017 12:49:12 PM
        //#-----------------------------------------
        private void dsrDesigner_13_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 6/2/2017 12:49:12 PM
                Accept(ref fldF010_PAT_MSTR_SUBSCR_MSG_NBR);
                Accept(ref fldF010_PAT_MSTR_SUBSCR_DATE_MSG_NBR_EFFECTIVE_TO);
                //#END STANDARD PROCEDURE CONTENT

            }
            catch (CustomApplicationException ex)
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
        //# dsrDesigner_10_Click Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 6/2/2017 12:49:12 PM
        //#-----------------------------------------
        private void dsrDesigner_10_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 6/2/2017 12:49:12 PM
                Accept(ref fldF010_PAT_MSTR_PAT_HEALTH_65_IND);
                Accept(ref fldF010_PAT_MSTR_PAT_VERSION_CD);
                Display(ref fldF010_PAT_MSTR_PAT_LAST_VERSION_CD);
                Accept(ref fldF010_PAT_MSTR_PAT_EXPIRY_DATE);
                //#END STANDARD PROCEDURE CONTENT

            }
            catch (CustomApplicationException ex)
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
        //# dsrDesigner_24_Click Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 6/2/2017 12:49:12 PM
        //#-----------------------------------------
        private void dsrDesigner_24_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 6/2/2017 12:49:12 PM
                Display(ref fldF010_PAT_MSTR_KEY_PAT_MSTR);
                Display(ref fldW_PASSWORD);
                //#END STANDARD PROCEDURE CONTENT

            }
            catch (CustomApplicationException ex)
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
        //# dsrDesigner_20_Click Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 6/2/2017 12:49:12 PM
        //#-----------------------------------------
        private void dsrDesigner_20_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 6/2/2017 12:49:12 PM
                Display(ref fldF010_PAT_MSTR_PAT_DATE_LAST_ELIG_MAILING);
                Display(ref fldF010_PAT_MSTR_PAT_DATE_LAST_ELIG_MAINT);
                //#END STANDARD PROCEDURE CONTENT

            }
            catch (CustomApplicationException ex)
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
        //# dsrDesigner_17_Click Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 6/2/2017 12:49:12 PM
        //#-----------------------------------------
        private void dsrDesigner_17_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 6/2/2017 12:49:12 PM
                Display(ref fldF010_PAT_MSTR_PAT_LOCATION_FIELD);
                Display(ref fldF010_PAT_MSTR_PAT_LAST_DOC_NBR_SEEN);
                Display(ref fldF010_PAT_MSTR_PAT_IN_OUT);
                //#END STANDARD PROCEDURE CONTENT

            }
            catch (CustomApplicationException ex)
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
        //# dsrDesigner_18_Click Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 6/2/2017 12:49:12 PM
        //#-----------------------------------------
        private void dsrDesigner_18_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 6/2/2017 12:49:12 PM
                Display(ref fldF010_PAT_MSTR_PAT_DATE_LAST_VISIT);
                Display(ref fldF010_PAT_MSTR_PAT_DATE_LAST_ADMIT);
                //#END STANDARD PROCEDURE CONTENT

            }
            catch (CustomApplicationException ex)
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
        //# dsrDesigner_21_Click Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 6/2/2017 12:49:12 PM
        //#-----------------------------------------
        private void dsrDesigner_21_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 6/2/2017 12:49:12 PM
                Display(ref fldF010_PAT_MSTR_PAT_MESS_CODE);
                Display(ref fldF010_PAT_MSTR_PAT_NO_OF_LETTER_SENT);
                //#END STANDARD PROCEDURE CONTENT

            }
            catch (CustomApplicationException ex)
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
        //# dsrDesigner_05_Click Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 6/2/2017 12:49:12 PM
        //#-----------------------------------------
        private void dsrDesigner_05_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 6/2/2017 12:49:12 PM
                Accept(ref fldT_PAT_CHART_NBR_5);
                Accept(ref fldT_PAT_CHART_NBR);
                Accept(ref fldT_PAT_CHART_NBR_2);
                Accept(ref fldT_PAT_CHART_NBR_3);
                Accept(ref fldT_PAT_CHART_NBR_4);
                //#END STANDARD PROCEDURE CONTENT

            }
            catch (CustomApplicationException ex)
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

    }


}
