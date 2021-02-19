
#region "Screen Comments"

// ---------------------------------------------------------------:
// :
// system:       Holiday Property Bond                         :
// :
// program:      BOOKDETS                                      :
// :
// task:         Additional details about booking              :
// :
// screens                                                     :
// called by:    BOOK0300    Main booking screen               :
// VIEWBOOK    View booking details              :
// :
// Rob Coe    23/03/95                                         :
// ---------------------------------------------------------------:
// 14/07/95 - Make NUMBER-IN-PARTY required.
// ----------------------------------------------------------------
// 15/08/95 - Check that the number of adults + children is not more
// than the number in party.
// ------------------------------------------------------------------
// 08/09/95 - removed field line-NO of BOOKING-COMMENTS
// --------------------------------------------------------------------
// 06/10/96 - set number-in-party of BOOK-DTL-CHANGE.
// - set COMMENTS-CHANGED if BOOKING-COMMENTS are changed.
// --------------------------------------------------------------------
// 10/10/95 - create BOOK-DTL-CHANGE records if new records are
// created, not just if existing ones are altered.
// --------------------------------------------------------------------
// 04/02/97 - check that an internal comment has been entered if the
// booking was allowed with insufficient points (t-ok =  y )
// --------------------------------------------------------------------
// 21/08/00 - put BOOKING-DETAIL regardless if anything entered
// --------------------------------------------------------------------
// 04/12/00 - setting AMEND-TIME was causing errors. Needs dictionary
// to int*8   or divide by 10000 or something !!
// --------------------------------------------------------------------
// 10.06.03 - added EDIT check for no-extra-beds
// --------------------------------------------------------------------
// 09.05.03 - changed number-in-party max value from 20 to 12
// removed data blinking from comments
// --------------------------------------------------------------------
// 15.06.05 - Add booking-letter rec for Taxi Confirmation Letter.
// --------------------------------------------------------------------
// 25.01.06 ME  change  Food parcels  message when location =  JV 
// --------------------------------------------------------------------
// 23.02.07 ME  change club-membership to transfers (renamed item).
// and add new data items of travel data.
// --------------------------------------------------------------------
// 22.03.07 ME  ferries replaces maid-service and airport-hotel not used.
// --------------------------------------------------------------------
// 26.04.07 ME  change Y/N flags on booking-detail to dates booked.
// --------------------------------------------------------------------
// 01.05.07 ME  Add flights-booked to screen.
// --------------------------------------------------------------------
// 14.09.07 ME  Allow Tracey and IT staff to cancel taxis-booked.
// --------------------------------------------------------------------
// 24.09.07 ME  Stop book-dtl-change records when nothing has changed.
// --------------------------------------------------------------------
// 03/10/08 PJ  Added insurance 
// --------------------------------------------------------------------
// 05/01/09 RC  Arrival-time labeled  ETA (flight) 
// --------------------------------------------------------------------
// 24.02.09 ME  Display  web booking  on screen.
// --------------------------------------------------------------------
// 29.04.09 ME  Add flag for BCC members holidays.
// --------------------------------------------------------------------
// 18/03/10 RC  Don`t INFO or WARN with RESPONSE for signonuser weblive
// --------------------------------------------------------------------
// 05.05.10 ME  Set web-booking flag when a Booking request is booked.
// -----------------------------------------------------------------
// 10.05.10 ME  Add designer procesure  who  to show who made the booking.
// -----------------------------------------------------------------
// 23.08.10 ME  Run ghost screen to add record to web_bookings file.
// -----------------------------------------------------------------
// 05.11.10 ME  Small change to stop duplicated temp names.
// --------------------------------------------------------------------
// 11.11.10 RM  Add Week number next to Booking Ref
// -------------------------------------------------------------------
// 14.12.10 ME  Do not run webbkngs.qkc for  TN  customers.
// -------------------------------------------------------------------
// 20.01.11 RM  Add check for scheme to allow for SING insurance
// -------------------------------------------------------------------
// 30.03.11 ME  Take out stuff about Taxi confirmation letter as we
// stopped printing them in 2007 - and it confuses people.
// -------------------------------------------------------------------
// 23.07.11 RC  For bookings at overseas locations starting with 90 days
// with no flight number or arrival time, info to request
// user to ask Bondholder.
// -------------------------------------------------------------------
// 11.10.11 RC  **URGENT** message for Tenancies with no arrival time   
// -------------------------------------------------------------------
// 25.10.11 ME  small change to check for flight number.
// -------------------------------------------------------------------
// 03.01.12 ME  Check to make sure details are not being changed online
// at the same time as editing on HP system.
// -------------------------------------------------------------------
// 18.01.12 ME  Always ask for internal comments for long-stay holidays.
// -------------------------------------------------------------------
// 14.02.12 ME  Add offer-code and look-up screen.
// -------------------------------------------------------------------
// 19.02.12 ME  Update eta details on web_bookings if changed 
// within 8 days of travel.
// -------------------------------------------------------------------
// 18.09.12 RM  Add scrnvst to record visit to this screen
// -------------------------------------------------------------------
// 05.12.12 ME  Get booking company for Signature Villas etc.
// -------------------------------------------------------------------
// 09.01.13 ME  Futher enhancements for Signature Villas.
// -------------------------------------------------------------------
// 10.01.13 ME  Owners booking for signature villas properties are 
// always designated as tenancy bookings :- 
// ie. booking-company =  T .
// -------------------------------------------------------------------
// 17.01.13 ME  Hapimag bookings for signature villas properties are 
// always designated as tenancy bookings :- 
// ie. booking-company =  T .
// -------------------------------------------------------------------
// 21.01.13 ME  Add extra info to  who  command - for IT use mainly.
// -------------------------------------------------------------------
// 29.01.13 ME  Add date selection to offer-codes.
// -------------------------------------------------------------------
// 15.05.13 ME  Check start-date before asking for arrival-time etc.
// -------------------------------------------------------------------

#endregion



using System;
using System.Text;
using System.Windows;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.ExceptionManagement;
using Core.Windows.UI.Core.Windows;
using Core.Windows.UI.Core.Windows.UI;
using System.Data.OracleClient;

namespace rma.Views
{

    partial class BOOKDETS : BasePage
    {

        #region " Form Designer Generated Code "





        public BOOKDETS()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "BOOKDETS";

            //# Set the ACTIVITIES for the screen.
            this.ChangeActivity = true;
            this.FindActivity = true;
            this.DeleteActivity = true;
            this.EntryActivity = true;
            this.AutoReturn = true;
            this.UseAcceptProcessing = true;

            

            this.GridDesigner = "dsrDesigner_20";
            this.ScreenType = ScreenTypes.Composite;


            dsrDesigner_20.DefaultFirstRowInGrid = true;

        }

        #endregion

        private void Page_Load(object sender, RoutedEventArgs e)
        {
            SetVariables();
            dsrDesigner_WHO.Click += dsrDesigner_WHO_Click;
            dsrDesigner_21.Click += dsrDesigner_21_Click;
            dsrDesigner_22.Click += dsrDesigner_22_Click;
            dsrDesigner_23.Click += dsrDesigner_23_Click;
            dsrDesigner_15.Click += dsrDesigner_15_Click;
            dsrDesigner_17.Click += dsrDesigner_17_Click;
            dsrDesigner_16.Click += dsrDesigner_16_Click;
            dsrDesigner_07.Click += dsrDesigner_07_Click;
            dsrDesigner_13.Click += dsrDesigner_13_Click;
            dsrDesigner_19.Click += dsrDesigner_19_Click;
            dsrDesigner_14.Click += dsrDesigner_14_Click;
            dsrDesigner_02.Click += dsrDesigner_02_Click;
            dsrDesigner_08.Click += dsrDesigner_08_Click;
            dsrDesigner_04.Click += dsrDesigner_04_Click;
            dsrDesigner_20.Click += dsrDesigner_20_Click;
            dsrDesigner_05.Click += dsrDesigner_05_Click;
            dsrDesigner_01.Click += dsrDesigner_01_Click;
            dsrDesigner_11.Click += dsrDesigner_11_Click;
            dsrDesigner_06.Click += dsrDesigner_06_Click;
            dsrDesigner_12.Click += dsrDesigner_12_Click;
            dsrDesigner_18.Click += dsrDesigner_18_Click;
            dsrDesigner_03.Click += dsrDesigner_03_Click;
            dsrDesigner_09.Click += dsrDesigner_09_Click;
            
            fldT_STOP_DUPS.LookupNotOn += fldT_STOP_DUPS_LookupNotOn;
            fldBOOKING_DETAIL_OFFER_CODE.Edit += fldBOOKING_DETAIL_OFFER_CODE_Edit;
            fldBOOKING_DETAIL_ARRIVAL_TIME.Edit += fldBOOKING_DETAIL_ARRIVAL_TIME_Edit;
            fldBOOKING_DETAIL_NUMBER_IN_PARTY.Edit += fldBOOKING_DETAIL_NUMBER_IN_PARTY_Edit;
            fldT_SILENT.Edit += fldT_SILENT_Edit;
            fldBOOKING_DETAIL_ADULTS.Edit += fldBOOKING_DETAIL_ADULTS_Edit;
            fldBOOKING_DETAIL_CHILDREN.Edit += fldBOOKING_DETAIL_CHILDREN_Edit;
            fldBOOKING_DETAIL_FOOD_PARCELS.Edit += fldBOOKING_DETAIL_FOOD_PARCELS_Edit;
            fldBOOKING_DETAIL_HIGH_CHAIRS.Edit += fldBOOKING_DETAIL_HIGH_CHAIRS_Edit;
            fldBOOKING_DETAIL_COTS.Edit += fldBOOKING_DETAIL_COTS_Edit;
            fldBOOKING_DETAIL_PETS.Edit += fldBOOKING_DETAIL_PETS_Edit;
            fldBOOKING_DETAIL_NO_EXTRA_BEDS.Edit += fldBOOKING_DETAIL_NO_EXTRA_BEDS_Edit;
            fldT_SILENT_2.Edit += fldT_SILENT_2_Edit;
            fldT_BOOKING_COMPANY.Input += fldT_BOOKING_COMPANY_Input;
            fldBOOKING_DETAIL_OFFER_CODE.Process += fldBOOKING_DETAIL_OFFER_CODE_Process;
                        
            Page_Load();

            // TODO: If any DESIGNER procedures function on occurring FILES or TEMPORARIES, set the grid's AllowSelectRowButton property to TRUE.



            // TODO: The following elements have Input/Output Scaling defined in the Dictionary or Screen.  Manual steps may be required:
            //       BOOKINGS.DEPOSIT InputScale: 2 OutputScale: 0


        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            BOOKING_COMMENTS_COMMENT_LINE1 = new CoreCharacter("BOOKING_COMMENTS_COMMENT_LINE1", 50, this, ResetTypes.ResetAtMode);
            BOOKING_COMMENTS_COMMENT_LINE2 = new CoreCharacter("BOOKING_COMMENTS_COMMENT_LINE2", 50, this, ResetTypes.ResetAtMode);
            BOOKING_COMMENTS_COMMENT_LINE3 = new CoreCharacter("BOOKING_COMMENTS_COMMENT_LINE3", 50, this, ResetTypes.ResetAtMode);
            BOOKING_COMMENTS_COMMENT_LINE4 = new CoreCharacter("BOOKING_COMMENTS_COMMENT_LINE4", 50, this, ResetTypes.ResetAtMode);
            INTERNAL_COMMENTS_COMMENT_LINE1 = new CoreCharacter("INTERNAL_COMMENTS_COMMENT_LINE1", 50, this, ResetTypes.ResetAtMode);
            INTERNAL_COMMENTS_COMMENT_LINE2 = new CoreCharacter("INTERNAL_COMMENTS_COMMENT_LINE2", 50, this, ResetTypes.ResetAtMode);
            INTERNAL_COMMENTS_COMMENT_LINE3 = new CoreCharacter("INTERNAL_COMMENTS_COMMENT_LINE3", 50, this, ResetTypes.ResetAtMode);
            INTERNAL_COMMENTS_COMMENT_LINE4 = new CoreCharacter("INTERNAL_COMMENTS_COMMENT_LINE4", 50, this, ResetTypes.ResetAtMode);
            T_SCREEN_NAME = new CoreCharacter("T_SCREEN_NAME", 20, this, ResetTypes.ResetAtStartup, "bookdets.qks");
            flePROPERTIES = new OracleFileObject(this, FileTypes.Master, 0, "INDEXED", "PROPERTIES", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            T_BOOKING_REF = new CoreCharacter("T_BOOKING_REF", 8, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
            T_INVESTOR = new CoreCharacter("T_INVESTOR", 8, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
            T_START_DATE = new CoreDate("T_START_DATE", this, ResetTypes.ResetAtStartup);
            T_NUMBER_SLEPT = new CoreInteger("T_NUMBER_SLEPT", 2, this, ResetTypes.ResetAtStartup);
            T_NEW_BOOKING = new CoreCharacter("T_NEW_BOOKING", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
            T_STOP_DUPS = new CoreCharacter("T_STOP_DUPS", 1, this, Common.cEmptyString);
            T_OK = new CoreCharacter("T_OK", 1, this, Common.cEmptyString);
            T_WEB_BOOKING = new CoreCharacter("T_WEB_BOOKING", 1, this, Common.cEmptyString);
            T_ENTERED = new CoreCharacter("T_ENTERED", 1, this, Common.cEmptyString);
            T_TYPE = new CoreCharacter("T_TYPE", 1, this, Common.cEmptyString);
            fleBOOKING_DETAIL = new OracleFileObject(this, FileTypes.Primary, 0, "INDEXED", "BOOKING_DETAIL", "", true, false, false, 1, "m_trnTRANS_UPDATE");
            fleBOOKING_COMMENTS = new OracleFileObject(this, FileTypes.Secondary, 4, "INDEXED", "BOOKING_COMMENTS", "", true, false, false, 0, "m_trnTRANS_UPDATE");
            fleINTERNAL_COMMENTS = new OracleFileObject(this, FileTypes.Secondary, 4, "INDEXED", "BOOKING_COMMENTS", "INTERNAL_COMMENTS", true, false, false, 0, "m_trnTRANS_UPDATE");
            fleBOOK_DTL_CHANGE = new OracleFileObject(this, FileTypes.Secondary, 0, "INDEXED", "BOOKING_DETAIL", "", true, false, false, 0, "m_trnTRANS_UPDATE");
            fleBD_EXISTS = new OracleFileObject(this, FileTypes.Reference, 0, "INDEXED", "BOOKING_DETAIL", "BD_EXISTS", false, false, false, 0, "m_cnnQUERY");
            fleCANCEL_BOOKING = new OracleFileObject(this, FileTypes.Reference, 0, "INDEXED", "CANCEL_BOOKING", "", false, false, false, 0, "m_cnnQUERY");
            fleLOCATIONS = new OracleFileObject(this, FileTypes.Reference, 0, "INDEXED", "LOCATIONS", "", false, false, false, 0, "m_cnnQUERY");
            fleCORR_ADDRESS = new OracleFileObject(this, FileTypes.Designer, 0, "INDEXED", "CORR_ADDRESS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleBOOKINGS = new OracleFileObject(this, FileTypes.Reference, 0, "INDEXED", "BOOKINGS", "", false, false, false, 0, "m_cnnQUERY");
            fleINSURANCE = new OracleFileObject(this, FileTypes.Reference, 0, "INDEXED", "INSURANCE", "", false, false, false, 0, "m_cnnQUERY");
            fleBOND_COMP_CLUB = new OracleFileObject(this, FileTypes.Reference, 0, "INDEXED", "BOND_COMP_CLUB", "", false, false, false, 0, "m_cnnQUERY");
            fleOFFER_CODES = new OracleFileObject(this, FileTypes.Reference, 0, "INDEXED", "OFFER_CODES", "", false, false, false, 0, "m_cnnQUERY");
            fleM_INVESTORS = new OracleFileObject(this, FileTypes.Reference, 0, "INDEXED", "M_INVESTORS", "", false, false, false, 0, "m_cnnQUERY");
            T_SILENT = new CoreCharacter("T_SILENT", 1, this, Common.cEmptyString);
            T_SILENT_2 = new CoreCharacter("T_SILENT_2", 1, this, Common.cEmptyString);
            T_BCC_MEMBER = new CoreCharacter("T_BCC_MEMBER", 1, this, " ");
            T_WEBBKNGS_REF = new CoreCharacter("T_WEBBKNGS_REF", 8, this, Common.cEmptyString);
            T_WEB_CHANGED = new CoreCharacter("T_WEB_CHANGED", 1, this, " ");
            T_OFFER = new CoreCharacter("T_OFFER", 1, this, " ");
            T_OFFER_CODE = new CoreCharacter("T_OFFER_CODE", 4, this, " ");
            T_INT_COMM = new CoreCharacter("T_INT_COMM", 50, this, Common.cEmptyString);
            T_INT_COMM_1 = new CoreCharacter("T_INT_COMM_1", 50, this, Common.cEmptyString);
            T_INT_COMM_2 = new CoreCharacter("T_INT_COMM_2", 50, this, Common.cEmptyString);
            T_INT_COMM_3 = new CoreCharacter("T_INT_COMM_3", 50, this, Common.cEmptyString);
            T_INT_COMM_4 = new CoreCharacter("T_INT_COMM_4", 50, this, Common.cEmptyString);
            T_OLD_ARRIVAL = new CoreInteger("T_OLD_ARRIVAL", 4, this);
            T_OLD_FLIGHT = new CoreCharacter("T_OLD_FLIGHT", 9, this, Common.cEmptyString);
            T_BOOKING_COMPANY = new CoreCharacter("T_BOOKING_COMPANY", 1, this, " ");
            T_CORR_ADDRESS = new CoreCharacter("T_CORR_ADDRESS", 1, this, Common.cEmptyString);
            T_BCOMMENT = new CoreCharacter("T_BCOMMENT", 1, this, "N");

            fleBOOKING_COMMENTS.Access += fleBOOKING_COMMENTS_Access;
            fleINTERNAL_COMMENTS.Access += fleINTERNAL_COMMENTS_Access;
            fleBOOK_DTL_CHANGE.Access += fleBOOK_DTL_CHANGE_Access;
            fleBD_EXISTS.Access += fleBD_EXISTS_Access;
            fleCANCEL_BOOKING.Access += fleCANCEL_BOOKING_Access;
            fleLOCATIONS.Access += fleLOCATIONS_Access;
            fleCORR_ADDRESS.Access += fleCORR_ADDRESS_Access;
            fleBOOKINGS.Access += fleBOOKINGS_Access;
            fleINSURANCE.Access += fleINSURANCE_Access;
            fleBOND_COMP_CLUB.Access += fleBOND_COMP_CLUB_Access;
            fleOFFER_CODES.Access += fleOFFER_CODES_Access;
            fleM_INVESTORS.Access += fleM_INVESTORS_Access;
            D_WEB_BOOKING.GetValue += D_WEB_BOOKING_GetValue;
            D_SYSDATE_PLUS8.GetValue += D_SYSDATE_PLUS8_GetValue;
            D_START_DATE.GetValue += D_START_DATE_GetValue;
            D_TOT_IN_PARTY.GetValue += D_TOT_IN_PARTY_GetValue;
            D_INSURANCE.GetValue += D_INSURANCE_GetValue;
            D_BCC_PROMPT.GetValue += D_BCC_PROMPT_GetValue;
            D_WEEK_WORD.GetValue += D_WEEK_WORD_GetValue;
            D_DAYS_AWAY.GetValue += D_DAYS_AWAY_GetValue;
            D_BOOKING_COMPANY.GetValue += D_BOOKING_COMPANY_GetValue;
            D_BOOKING_DATE.GetValue += D_BOOKING_DATE_GetValue;
            D_BOOKING_TIME.GetValue += D_BOOKING_TIME_GetValue;
            D_REF.GetValue += D_REF_GetValue;
            fleBOOKING_DETAIL.SetItemFinals += fleBOOKING_DETAIL_SetItemFinals;
            fleBOOKING_DETAIL.InitializeItems += fleBOOKING_DETAIL_InitializeItems;
            fleBOOK_DTL_CHANGE.SetItemFinals += fleBOOK_DTL_CHANGE_SetItemFinals;
            fleINTERNAL_COMMENTS.SetItemFinals += fleINTERNAL_COMMENTS_SetItemFinals;
            fleBOOKING_COMMENTS.SetItemFinals += fleBOOKING_COMMENTS_SetItemFinals;

            fleBOOKING_COMMENTS.AccessIsOptional = true;
            fleINTERNAL_COMMENTS.AccessIsOptional = true;
            fleCORR_ADDRESS.AccessIsOptional = true;

        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;
            fleBOOKING_COMMENTS.Access -= fleBOOKING_COMMENTS_Access;
            fleINTERNAL_COMMENTS.Access -= fleINTERNAL_COMMENTS_Access;
            fleBOOK_DTL_CHANGE.Access -= fleBOOK_DTL_CHANGE_Access;
            fleBD_EXISTS.Access -= fleBD_EXISTS_Access;
            fleCANCEL_BOOKING.Access -= fleCANCEL_BOOKING_Access;
            fleLOCATIONS.Access -= fleLOCATIONS_Access;
            fleCORR_ADDRESS.Access -= fleCORR_ADDRESS_Access;
            fleBOOKINGS.Access -= fleBOOKINGS_Access;
            fleINSURANCE.Access -= fleINSURANCE_Access;
            fleBOND_COMP_CLUB.Access -= fleBOND_COMP_CLUB_Access;
            fleOFFER_CODES.Access -= fleOFFER_CODES_Access;
            fleM_INVESTORS.Access -= fleM_INVESTORS_Access;
            D_WEB_BOOKING.GetValue -= D_WEB_BOOKING_GetValue;
            D_SYSDATE_PLUS8.GetValue -= D_SYSDATE_PLUS8_GetValue;
            D_START_DATE.GetValue -= D_START_DATE_GetValue;
            D_TOT_IN_PARTY.GetValue -= D_TOT_IN_PARTY_GetValue;
            D_INSURANCE.GetValue -= D_INSURANCE_GetValue;
            D_BCC_PROMPT.GetValue -= D_BCC_PROMPT_GetValue;
            D_WEEK_WORD.GetValue -= D_WEEK_WORD_GetValue;
            D_DAYS_AWAY.GetValue -= D_DAYS_AWAY_GetValue;
            D_BOOKING_COMPANY.GetValue -= D_BOOKING_COMPANY_GetValue;
            D_BOOKING_DATE.GetValue -= D_BOOKING_DATE_GetValue;
            D_BOOKING_TIME.GetValue -= D_BOOKING_TIME_GetValue;
            D_REF.GetValue -= D_REF_GetValue;
            fldT_STOP_DUPS.LookupNotOn -= fldT_STOP_DUPS_LookupNotOn;
            fldBOOKING_DETAIL_OFFER_CODE.Edit -= fldBOOKING_DETAIL_OFFER_CODE_Edit;
            fldBOOKING_DETAIL_ARRIVAL_TIME.Edit -= fldBOOKING_DETAIL_ARRIVAL_TIME_Edit;
            fldBOOKING_DETAIL_NUMBER_IN_PARTY.Edit -= fldBOOKING_DETAIL_NUMBER_IN_PARTY_Edit;
            fldT_SILENT.Edit -= fldT_SILENT_Edit;
            fldBOOKING_DETAIL_ADULTS.Edit -= fldBOOKING_DETAIL_ADULTS_Edit;
            fldBOOKING_DETAIL_CHILDREN.Edit -= fldBOOKING_DETAIL_CHILDREN_Edit;
            fldBOOKING_DETAIL_FOOD_PARCELS.Edit -= fldBOOKING_DETAIL_FOOD_PARCELS_Edit;
            fldBOOKING_DETAIL_HIGH_CHAIRS.Edit -= fldBOOKING_DETAIL_HIGH_CHAIRS_Edit;
            fldBOOKING_DETAIL_COTS.Edit -= fldBOOKING_DETAIL_COTS_Edit;
            fldBOOKING_DETAIL_PETS.Edit -= fldBOOKING_DETAIL_PETS_Edit;
            fldBOOKING_DETAIL_NO_EXTRA_BEDS.Edit -= fldBOOKING_DETAIL_NO_EXTRA_BEDS_Edit;
            fldT_SILENT_2.Edit -= fldT_SILENT_2_Edit;
            fldT_BOOKING_COMPANY.Input -= fldT_BOOKING_COMPANY_Input;
            fldBOOKING_DETAIL_OFFER_CODE.Process -= fldBOOKING_DETAIL_OFFER_CODE_Process;
            fleBOOKING_DETAIL.SetItemFinals -= fleBOOKING_DETAIL_SetItemFinals;
            fleBOOKING_DETAIL.InitializeItems -= fleBOOKING_DETAIL_InitializeItems;
            fleBOOK_DTL_CHANGE.SetItemFinals -= fleBOOK_DTL_CHANGE_SetItemFinals;
            fleINTERNAL_COMMENTS.SetItemFinals -= fleINTERNAL_COMMENTS_SetItemFinals;
            fleBOOKING_COMMENTS.SetItemFinals -= fleBOOKING_COMMENTS_SetItemFinals;
            dsrDesigner_WHO.Click -= dsrDesigner_WHO_Click;
            dsrDesigner_21.Click -= dsrDesigner_21_Click;
            dsrDesigner_22.Click -= dsrDesigner_22_Click;
            dsrDesigner_23.Click -= dsrDesigner_23_Click;
            dsrDesigner_15.Click -= dsrDesigner_15_Click;
            dsrDesigner_17.Click -= dsrDesigner_17_Click;
            dsrDesigner_16.Click -= dsrDesigner_16_Click;
            dsrDesigner_07.Click -= dsrDesigner_07_Click;
            dsrDesigner_13.Click -= dsrDesigner_13_Click;
            dsrDesigner_19.Click -= dsrDesigner_19_Click;
            dsrDesigner_14.Click -= dsrDesigner_14_Click;
            dsrDesigner_02.Click -= dsrDesigner_02_Click;
            dsrDesigner_08.Click -= dsrDesigner_08_Click;
            dsrDesigner_04.Click -= dsrDesigner_04_Click;
            dsrDesigner_20.Click -= dsrDesigner_20_Click;
            dsrDesigner_05.Click -= dsrDesigner_05_Click;
            dsrDesigner_01.Click -= dsrDesigner_01_Click;
            dsrDesigner_11.Click -= dsrDesigner_11_Click;
            dsrDesigner_06.Click -= dsrDesigner_06_Click;
            dsrDesigner_12.Click -= dsrDesigner_12_Click;
            dsrDesigner_18.Click -= dsrDesigner_18_Click;
            dsrDesigner_03.Click -= dsrDesigner_03_Click;
            dsrDesigner_09.Click -= dsrDesigner_09_Click;


        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private OracleConnection m_cnnQUERY = new OracleConnection();
        private OracleConnection m_cnnTRANS_UPDATE = new OracleConnection();
        private OracleTransaction m_trnTRANS_UPDATE;

        private CoreCharacter BOOKING_COMMENTS_COMMENT_LINE1;
        private CoreCharacter BOOKING_COMMENTS_COMMENT_LINE2;
        private CoreCharacter BOOKING_COMMENTS_COMMENT_LINE3;
        private CoreCharacter BOOKING_COMMENTS_COMMENT_LINE4;
        private CoreCharacter INTERNAL_COMMENTS_COMMENT_LINE1;
        private CoreCharacter INTERNAL_COMMENTS_COMMENT_LINE2;
        private CoreCharacter INTERNAL_COMMENTS_COMMENT_LINE3;
        private CoreCharacter INTERNAL_COMMENTS_COMMENT_LINE4;

        private CoreCharacter T_SCREEN_NAME;
        private OracleFileObject flePROPERTIES;
        private CoreCharacter T_BOOKING_REF;
        private CoreCharacter T_INVESTOR;
        private CoreDate T_START_DATE;
        private CoreInteger T_NUMBER_SLEPT;
        private CoreCharacter T_NEW_BOOKING;
        private CoreCharacter T_STOP_DUPS;
        private CoreCharacter T_OK;
        private CoreCharacter T_WEB_BOOKING;
        private CoreCharacter T_ENTERED;
        private CoreCharacter T_TYPE;
        private OracleFileObject fleBOOKING_DETAIL;

        private void fleBOOKING_DETAIL_InitializeItems(bool Fixed)
        {

            try
            {
                if (!Fixed)
                    fleBOOKING_DETAIL.set_SetValue("WEB_BOOKING", true, T_WEB_BOOKING.Value);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fleBOOKING_DETAIL_SetItemFinals()
        {

            try
            {
                fleBOOKING_DETAIL.set_SetValue("BOOKING_REF", T_BOOKING_REF.Value);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }

        private OracleFileObject fleBOOKING_COMMENTS;

        private void fleBOOKING_COMMENTS_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleBOOKING_COMMENTS.ElementOwner("BOOKING_REF")).Append(" = ").Append(Common.StringToField(T_BOOKING_REF.Value));

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



        private void fleBOOKING_COMMENTS_SelectIf(ref string SelectIfClause)
        {


            try
            {
                StringBuilder strSQL = new StringBuilder("");

                strSQL.Append(" (    ").Append(fleBOOKING_COMMENTS.ElementOwner("RECORD_STATUS")).Append(" =  'PM')");
                strSQL.Append(")");

                SelectIfClause = strSQL.ToString();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fleBOOKING_COMMENTS_SetItemFinals()
        {

            try
            {
                fleBOOKING_COMMENTS.set_SetValue("BOOKING_REF", T_BOOKING_REF.Value);
                fleBOOKING_COMMENTS.set_SetValue("RECORD_STATUS", "PM");


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }

        private OracleFileObject fleINTERNAL_COMMENTS;

        private void fleINTERNAL_COMMENTS_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleINTERNAL_COMMENTS.ElementOwner("BOOKING_REF")).Append(" = ").Append(Common.StringToField(T_BOOKING_REF.Value));

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



        private void fleINTERNAL_COMMENTS_SelectIf(ref string SelectIfClause)
        {


            try
            {
                StringBuilder strSQL = new StringBuilder("");

                strSQL.Append(" (    ").Append(fleINTERNAL_COMMENTS.ElementOwner("RECORD_STATUS")).Append(" =  'IN')");
                strSQL.Append(")");

                SelectIfClause = strSQL.ToString();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fleINTERNAL_COMMENTS_SetItemFinals()
        {

            try
            {
                fleINTERNAL_COMMENTS.set_SetValue("BOOKING_REF", T_BOOKING_REF.Value);
                fleINTERNAL_COMMENTS.set_SetValue("RECORD_STATUS", "IN");


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }

        private OracleFileObject fleBOOK_DTL_CHANGE;

        private void fleBOOK_DTL_CHANGE_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleBOOK_DTL_CHANGE.ElementOwner("BOOKING_REF")).Append(" = ").Append(Common.StringToField(T_BOOKING_REF.Value));

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



        private void fleBOOK_DTL_CHANGE_SetItemFinals()
        {

            try
            {
                fleBOOK_DTL_CHANGE.set_SetValue("FOOD_PARCELS", fleBOOKING_DETAIL.GetStringValue("FOOD_PARCELS"));
                fleBOOK_DTL_CHANGE.set_SetValue("NUMBER_IN_PARTY", fleBOOKING_DETAIL.GetDecimalValue("NUMBER_IN_PARTY"));
                fleBOOK_DTL_CHANGE.set_SetValue("HIGH_CHAIRS", fleBOOKING_DETAIL.GetDecimalValue("HIGH_CHAIRS"));
                fleBOOK_DTL_CHANGE.set_SetValue("COTS", fleBOOKING_DETAIL.GetDecimalValue("COTS"));
                fleBOOK_DTL_CHANGE.set_SetValue("FLIGHT_NUMBER", fleBOOKING_DETAIL.GetStringValue("FLIGHT_NUMBER"));
                fleBOOK_DTL_CHANGE.set_SetValue("ARRIVAL_TIME", fleBOOKING_DETAIL.GetDecimalValue("ARRIVAL_TIME"));
                fleBOOK_DTL_CHANGE.set_SetValue("NO_EXTRA_BEDS", fleBOOKING_DETAIL.GetDecimalValue("NO_EXTRA_BEDS"));
                fleBOOK_DTL_CHANGE.set_SetValue("PETS", fleBOOKING_DETAIL.GetDecimalValue("PETS"));
                fleBOOK_DTL_CHANGE.set_SetValue("SITE_ARRIVAL_TIME", fleBOOKING_DETAIL.GetDecimalValue("SITE_ARRIVAL_TIME"));
                if (QDesign.NULL(fleBOOKING_DETAIL.GetDecimalValue("CAR_HIRE_BOOKED")) != 0)
                {
                    fleBOOK_DTL_CHANGE.set_SetValue("CAR_HIRE", "Y");
                }
                else
                {
                    fleBOOK_DTL_CHANGE.set_SetValue("CAR_HIRE", "N");
                }
                if (QDesign.NULL(fleBOOKING_DETAIL.GetDecimalValue("TAXIS_BOOKED")) != 0)
                {
                    fleBOOK_DTL_CHANGE.set_SetValue("BOOK_TAXIS", "Y");
                }
                else
                {
                    fleBOOK_DTL_CHANGE.set_SetValue("BOOK_TAXIS", "N");
                }
                if (QDesign.NULL(fleBOOKING_DETAIL.GetDecimalValue("EXCURSIONS_BOOKED")) != 0)
                {
                    fleBOOK_DTL_CHANGE.set_SetValue("EXCURSIONS", "Y");
                }
                else
                {
                    fleBOOK_DTL_CHANGE.set_SetValue("EXCURSIONS", "N");
                }
                if (QDesign.NULL(fleBOOKING_DETAIL.GetDecimalValue("TRANSFERS_BOOKED")) != 0)
                {
                    fleBOOK_DTL_CHANGE.set_SetValue("TRANSFERS", "Y");
                }
                else
                {
                    fleBOOK_DTL_CHANGE.set_SetValue("TRANSFERS", "N");
                }
                if (QDesign.NULL(fleBOOKING_DETAIL.GetDecimalValue("FERRIES_BOOKED")) != 0)
                {
                    fleBOOK_DTL_CHANGE.set_SetValue("FERRIES", "Y");
                }
                else
                {
                    fleBOOK_DTL_CHANGE.set_SetValue("FERRIES", "N");
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

        private OracleFileObject fleBD_EXISTS;

        private void fleBD_EXISTS_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleBD_EXISTS.ElementOwner("BOOKING_REF")).Append(" = ").Append(Common.StringToField(T_BOOKING_REF.Value));

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

        private OracleFileObject fleCANCEL_BOOKING;

        private void fleCANCEL_BOOKING_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleCANCEL_BOOKING.ElementOwner("BOOKING_REF")).Append(" = ").Append(Common.StringToField(T_BOOKING_REF.Value));

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

        private OracleFileObject fleLOCATIONS;

        private void fleLOCATIONS_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleLOCATIONS.ElementOwner("LOCATION")).Append(" = ").Append(Common.StringToField(QDesign.Substring(T_BOOKING_REF.Value, 1, 2)));

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

        private OracleFileObject fleCORR_ADDRESS;

        private void fleCORR_ADDRESS_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleCORR_ADDRESS.ElementOwner("BOOKING_REF")).Append(" = ").Append(Common.StringToField(T_BOOKING_REF.Value));

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

        private OracleFileObject fleBOOKINGS;

        private void fleBOOKINGS_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleBOOKINGS.ElementOwner("BOOKING_REF")).Append(" = ").Append(Common.StringToField(T_BOOKING_REF.Value));

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

        private OracleFileObject fleINSURANCE;

        private void fleINSURANCE_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleINSURANCE.ElementOwner("BOOKING_REF")).Append(" = ").Append(Common.StringToField(T_BOOKING_REF.Value));

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



        private void fleINSURANCE_SelectIf(ref string SelectIfClause)
        {


            try
            {
                StringBuilder strSQL = new StringBuilder("");

                strSQL.Append(" (    ").Append(fleINSURANCE.ElementOwner("CORE_TYPE")).Append(" =  'S')");
                strSQL.Append(")");

                SelectIfClause = strSQL.ToString();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }

        private OracleFileObject fleBOND_COMP_CLUB;

        private void fleBOND_COMP_CLUB_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleBOND_COMP_CLUB.ElementOwner("INVESTOR")).Append(" = ").Append(Common.StringToField(fleBOOKINGS.GetStringValue("INVESTOR")));

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



        private void fleBOND_COMP_CLUB_SelectIf(ref string SelectIfClause)
        {


            try
            {
                StringBuilder strSQL = new StringBuilder("");

                strSQL.Append(" (    ").Append(fleBOND_COMP_CLUB.ElementOwner("CANCEL_DATE")).Append(" =  0)");
                strSQL.Append(")");

                SelectIfClause = strSQL.ToString();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }

        private OracleFileObject fleOFFER_CODES;

        private void fleOFFER_CODES_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleOFFER_CODES.ElementOwner("OFFER_CODE")).Append(" = ").Append(Common.StringToField(fleBOOKING_DETAIL.GetStringValue("OFFER_CODE")));

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



        private void fleOFFER_CODES_SelectIf(ref string SelectIfClause)
        {


            try
            {
                StringBuilder strSQL = new StringBuilder("");

                strSQL.Append(" (   QDesign.SysDate(ref m_cnnQUERY) >=   ").Append(fleOFFER_CODES.ElementOwner("FROM_DATE")).Append(" AND ");
                strSQL.Append("   QDesign.SysDate(ref m_cnnQUERY) <=   ").Append(fleOFFER_CODES.ElementOwner("TO_DATE")).Append(")");
                strSQL.Append(")");

                SelectIfClause = strSQL.ToString();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }

        private OracleFileObject fleM_INVESTORS;

        private void fleM_INVESTORS_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleM_INVESTORS.ElementOwner("INVESTOR")).Append(" = ").Append(Common.StringToField(fleBOOKINGS.GetStringValue("INVESTOR")));

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

        private CoreCharacter T_SILENT;
        private CoreCharacter T_SILENT_2;
        private CoreCharacter T_BCC_MEMBER;
        private CoreCharacter T_WEBBKNGS_REF;
        private CoreCharacter T_WEB_CHANGED;
        private CoreCharacter T_OFFER;
        private CoreCharacter T_OFFER_CODE;
        private CoreCharacter T_INT_COMM;
        private CoreCharacter T_INT_COMM_1;
        private CoreCharacter T_INT_COMM_2;
        private CoreCharacter T_INT_COMM_3;
        private CoreCharacter T_INT_COMM_4;
        private CoreInteger T_OLD_ARRIVAL;
        private CoreCharacter T_OLD_FLIGHT;
        private CoreCharacter T_BOOKING_COMPANY;
        private DCharacter D_WEB_BOOKING = new DCharacter(16);
        private void D_WEB_BOOKING_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(QDesign.Substring(fleBOOKINGS.GetStringValue("USER_LOGON"), 1, 3)) == QDesign.NULL("web") && QDesign.NULL(fleBOOKING_DETAIL.GetStringValue("WEB_BOOKING")) == QDesign.NULL("Y"))
                {
                    CurrentValue = "Booked online";
                }
                else if (QDesign.NULL(QDesign.Substring(fleBOOKINGS.GetStringValue("USER_LOGON"), 1, 3)) != QDesign.NULL("web") && QDesign.NULL(fleBOOKING_DETAIL.GetStringValue("WEB_BOOKING")) == QDesign.NULL("Y"))
                {
                    CurrentValue = "Requested online";
                }
                else
                {
                    CurrentValue = " ";
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
        private DDecimal D_SYSDATE_PLUS8 = new DDecimal(9);
        private void D_SYSDATE_PLUS8_GetValue(ref decimal Value)
        {

            try
            {
                Value = QDesign.Days(QDesign.SysDate(ref m_cnnQUERY)) + 8;


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DDecimal D_START_DATE = new DDecimal(9);
        private void D_START_DATE_GetValue(ref decimal Value)
        {

            try
            {
                Value = QDesign.Days(T_START_DATE.Value);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DInteger D_TOT_IN_PARTY = new DInteger(2);
        private void D_TOT_IN_PARTY_GetValue(ref decimal Value)
        {

            try
            {
                Value = fleBOOKING_DETAIL.GetDecimalValue("ADULTS") + fleBOOKING_DETAIL.GetDecimalValue("CHILDREN");


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private CoreCharacter T_CORR_ADDRESS;
        private CoreCharacter T_BCOMMENT;
        private DCharacter D_INSURANCE = new DCharacter(1);
        private void D_INSURANCE_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(fleINSURANCE.GetDecimalValue("FINISH_DATE")) > QDesign.NULL(QDesign.SysDate(ref m_cnnQUERY)) || QDesign.NULL(fleINSURANCE.GetStringValue("SCHEME")) == QDesign.NULL("SING"))
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
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DCharacter D_BCC_PROMPT = new DCharacter(14);
        private void D_BCC_PROMPT_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(T_BCC_MEMBER.Value) == QDesign.NULL("Y"))
                {
                    CurrentValue = "23 BCC Holiday";
                }
                else
                {
                    CurrentValue = " ";
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
        private DCharacter D_WEEK_WORD = new DCharacter(8);
        private void D_WEEK_WORD_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(fleBOOKINGS.GetDecimalValue("START_WEEK")) == QDesign.NULL(fleBOOKINGS.GetDecimalValue("END_WEEK")))
                {
                    CurrentValue = "Wk " + QDesign.ASCII(fleBOOKINGS.GetDecimalValue("START_WEEK"));
                }
                else
                {
                    CurrentValue = "Wk " + QDesign.ASCII(fleBOOKINGS.GetDecimalValue("START_WEEK")) + "-" + QDesign.ASCII(fleBOOKINGS.GetDecimalValue("END_WEEK"));
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
        private DInteger D_DAYS_AWAY = new DInteger(8);
        private void D_DAYS_AWAY_GetValue(ref decimal Value)
        {

            try
            {
                Value = QDesign.Days(fleBOOKINGS.GetDecimalValue("START_DATE")) - QDesign.Days(QDesign.SysDate(ref m_cnnQUERY));


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DCharacter D_BOOKING_COMPANY = new DCharacter(2);
        private void D_BOOKING_COMPANY_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(fleM_INVESTORS.GetStringValue("CUSTOMER_TYPE")) == QDesign.NULL("B"))
                {
                    CurrentValue = "B";
                }
                else if (QDesign.NULL(flePROPERTIES.GetStringValue("PROPERTY_COMPANY")) == QDesign.NULL("S"))
                {
                    CurrentValue = "S";
                }
                else if (QDesign.NULL(flePROPERTIES.GetStringValue("PROPERTY_COMPANY")) == QDesign.NULL("T") || (QDesign.NULL(flePROPERTIES.GetStringValue("PROPERTY_COMPANY")) == QDesign.NULL("V") && (QDesign.NULL(QDesign.Substring(fleM_INVESTORS.GetStringValue("INVESTOR"), 1, 3)) == QDesign.NULL("999") || QDesign.NULL(fleM_INVESTORS.GetStringValue("INVESTOR")) == QDesign.NULL("00038"))))
                {
                    CurrentValue = "T";
                }
                else
                {
                    CurrentValue = T_BOOKING_COMPANY.Value;
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
        private DCharacter D_BOOKING_DATE = new DCharacter(10);
        private void D_BOOKING_DATE_GetValue(ref string Value)
        {

            try
            {

                // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

                Value = QDesign.Substring(QDesign.ASCII(fleBOOKINGS.GetDecimalValue("BOOKING_DATE"), 8), 7, 2) + "/" + QDesign.Substring(QDesign.ASCII(fleBOOKINGS.GetDecimalValue("BOOKING_DATE"), 8), 5, 2) + "/" + QDesign.Substring(QDesign.ASCII(fleBOOKINGS.GetDecimalValue("BOOKING_DATE"), 8), 1, 4);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DCharacter D_BOOKING_TIME = new DCharacter(5);
        private void D_BOOKING_TIME_GetValue(ref string Value)
        {

            try
            {
                Value = QDesign.Substring(QDesign.ASCII(fleBOOKINGS.GetDecimalValue("BOOKING_TIME"), 4), 1, 2) + ":" + QDesign.Substring(QDesign.ASCII(fleBOOKINGS.GetDecimalValue("BOOKING_TIME"), 4), 3, 2);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DCharacter D_REF = new DCharacter(17);
        private void D_REF_GetValue(ref string Value)
        {

            try
            {

                // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

                Value = QDesign.Pack(fleBOOKINGS.GetStringValue("INVESTOR") + "/" + fleBOOKINGS.GetStringValue("BOOKING_REF"));


            }
            catch (CustomApplicationException ex)
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

        #region "Standard Generated Procedures"

        #region "Grid Field Declarations"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 07/12/2013 1:50:26 PM

       

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 07/12/2013 1:50:26 PM

        //#-----------------------------------------
        //# GetGridFieldObject Procedure.
        //#-----------------------------------------

       
        //#-----------------------------------------
        //# SetRelations Procedure.
        //#-----------------------------------------

        public override void SetRelations()
        {

            try
            {
                

            }
            catch (CustomApplicationException ex)
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

        #region "Transaction Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 07/12/2013 1:50:26 PM

        //#-----------------------------------------
        //# InitializeTransactionObjects Procedure.
        //#-----------------------------------------

        protected override void InitializeTransactionObjects()
        {

            try
            {
                m_cnnTRANS_UPDATE = new OracleConnection(Common.GetConnectionString());
                m_cnnTRANS_UPDATE.Open();
                m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
                m_cnnQUERY = new OracleConnection(Common.GetConnectionString());


            }
            catch (CustomApplicationException ex)
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
            flePROPERTIES.Transaction = m_trnTRANS_UPDATE;
            fleBOOKING_DETAIL.Transaction = m_trnTRANS_UPDATE;
            fleBOOKING_COMMENTS.Transaction = m_trnTRANS_UPDATE;
            fleINTERNAL_COMMENTS.Transaction = m_trnTRANS_UPDATE;
            fleBOOK_DTL_CHANGE.Transaction = m_trnTRANS_UPDATE;
            fleCORR_ADDRESS.Transaction = m_trnTRANS_UPDATE;


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 07/12/2013 1:50:26 PM

        //#-----------------------------------------
        //# InitializeFiles Procedure.
        //#-----------------------------------------

        protected override void InitializeFiles()
        {

            try
            {
                Initialize_TRANS_UPDATE();
                fleBD_EXISTS.Connection = m_cnnQUERY;
                fleCANCEL_BOOKING.Connection = m_cnnQUERY;
                fleLOCATIONS.Connection = m_cnnQUERY;
                fleBOOKINGS.Connection = m_cnnQUERY;
                fleINSURANCE.Connection = m_cnnQUERY;
                fleBOND_COMP_CLUB.Connection = m_cnnQUERY;
                fleOFFER_CODES.Connection = m_cnnQUERY;
                fleM_INVESTORS.Connection = m_cnnQUERY;


            }
            catch (CustomApplicationException ex)
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
                flePROPERTIES.Dispose();
                fleBOOKING_DETAIL.Dispose();
                fleBOOKING_COMMENTS.Dispose();
                fleINTERNAL_COMMENTS.Dispose();
                fleBOOK_DTL_CHANGE.Dispose();
                fleBD_EXISTS.Dispose();
                fleCANCEL_BOOKING.Dispose();
                fleLOCATIONS.Dispose();
                fleCORR_ADDRESS.Dispose();
                fleBOOKINGS.Dispose();
                fleINSURANCE.Dispose();
                fleBOND_COMP_CLUB.Dispose();
                fleOFFER_CODES.Dispose();
                fleM_INVESTORS.Dispose();


            }
            catch (CustomApplicationException ex)
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
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 07/12/2013 1:50:26 PM
        //#-----------------------------------------
        protected override void DisplayFormatting()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:50:26 PM
                Display(ref fldD_WEEK_WORD);
                Display(ref fldT_BOOKING_REF);
                Display(ref fldBOOKING_DETAIL_NUMBER_IN_PARTY);
                Display(ref fldBOOKING_DETAIL_ADULTS);
                Display(ref fldBOOKING_DETAIL_CHILDREN);
                Display(ref fldBOOKING_DETAIL_INFANTS);
                Display(ref fldBOOKING_DETAIL_FOOD_PARCELS);
                Display(ref fldBOOKING_DETAIL_COTS);
                Display(ref fldBOOKING_DETAIL_HIGH_CHAIRS);
                Display(ref fldD_WEB_BOOKING);
                Display(ref fldBOOKING_DETAIL_NO_EXTRA_BEDS);
                Display(ref fldBOOKING_DETAIL_PETS);
                Display(ref fldT_CORR_ADDRESS);
                Display(ref fldBOOKING_DETAIL_OFFER_CODE);
                Display(ref fldBOOKING_DETAIL_POWERSOFT_NUMBER);
                Display(ref fldBOOKING_DETAIL_FLIGHT_NUMBER);
                Display(ref fldBOOKING_DETAIL_ARRIVAL_TIME);
                Display(ref fldBOOKING_DETAIL_FLIGHTS_BOOKED);
                Display(ref fldBOOKING_DETAIL_CAR_HIRE_BOOKED);
                Display(ref fldBOOKING_DETAIL_FERRIES_BOOKED);
                Display(ref fldBOOKING_DETAIL_TRANSFERS_BOOKED);
                Display(ref fldBOOKING_DETAIL_TAXIS_BOOKED);
                Display(ref fldBOOKING_DETAIL_CAR_PARK_BOOKED);
                Display(ref fldCANCEL_BOOKING_REASON);
                Display(ref fldD_INSURANCE);
                Display(ref fldINSURANCE_COMMENCE_DATE);
                Display(ref fldINSURANCE_FINISH_DATE);
                Display(ref fldD_BCC_PROMPT);
                Display(ref fldBOOKING_DETAIL_BCC_HOLIDAY);
                Display(ref fldT_BOOKING_COMPANY);
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
        //# Do not delete, modify or move it.  Updated: 07/12/2013 1:50:26 PM

        //#-----------------------------------------
        //# BindFields Procedure.
        //#-----------------------------------------

        public override void BindFields()
        {
            try
            {
                fldD_WEEK_WORD.Bind(D_WEEK_WORD);
                fldT_BOOKING_REF.Bind(T_BOOKING_REF);
                fldT_SILENT.Bind(T_SILENT);
                fldT_STOP_DUPS.Bind(T_STOP_DUPS);
                fldBOOKING_DETAIL_NUMBER_IN_PARTY.Bind(fleBOOKING_DETAIL);
                fldBOOKING_DETAIL_ADULTS.Bind(fleBOOKING_DETAIL);
                fldBOOKING_DETAIL_CHILDREN.Bind(fleBOOKING_DETAIL);
                fldBOOKING_DETAIL_INFANTS.Bind(fleBOOKING_DETAIL);
                fldBOOKING_DETAIL_FOOD_PARCELS.Bind(fleBOOKING_DETAIL);
                fldBOOKING_DETAIL_COTS.Bind(fleBOOKING_DETAIL);
                fldBOOKING_DETAIL_HIGH_CHAIRS.Bind(fleBOOKING_DETAIL);
                fldD_WEB_BOOKING.Bind(D_WEB_BOOKING);
                fldBOOKING_DETAIL_NO_EXTRA_BEDS.Bind(fleBOOKING_DETAIL);
                fldBOOKING_DETAIL_PETS.Bind(fleBOOKING_DETAIL);
                fldT_CORR_ADDRESS.Bind(T_CORR_ADDRESS);
                fldBOOKING_DETAIL_OFFER_CODE.Bind(fleBOOKING_DETAIL);
                fldBOOKING_DETAIL_POWERSOFT_NUMBER.Bind(fleBOOKING_DETAIL);
                fldBOOKING_DETAIL_FLIGHT_NUMBER.Bind(fleBOOKING_DETAIL);
                fldBOOKING_DETAIL_ARRIVAL_TIME.Bind(fleBOOKING_DETAIL);
                fldBOOKING_DETAIL_FLIGHTS_BOOKED.Bind(fleBOOKING_DETAIL);
                fldBOOKING_DETAIL_CAR_HIRE_BOOKED.Bind(fleBOOKING_DETAIL);
                fldBOOKING_DETAIL_FERRIES_BOOKED.Bind(fleBOOKING_DETAIL);
                fldBOOKING_DETAIL_TRANSFERS_BOOKED.Bind(fleBOOKING_DETAIL);
                fldBOOKING_DETAIL_TAXIS_BOOKED.Bind(fleBOOKING_DETAIL);
                fldBOOKING_DETAIL_CAR_PARK_BOOKED.Bind(fleBOOKING_DETAIL);
                fldCANCEL_BOOKING_REASON.Bind(fleCANCEL_BOOKING);
                fldD_INSURANCE.Bind(D_INSURANCE);
                fldINSURANCE_COMMENCE_DATE.Bind(fleINSURANCE);
                fldINSURANCE_FINISH_DATE.Bind(fleINSURANCE);
                fldD_BCC_PROMPT.Bind(D_BCC_PROMPT);
                fldBOOKING_DETAIL_BCC_HOLIDAY.Bind(fleBOOKING_DETAIL);
                fldT_SILENT_2.Bind(T_SILENT_2);
                fldT_BOOKING_COMPANY.Bind(T_BOOKING_COMPANY);
                fldINTERNAL_COMMENTS_COMMENT_LINE1.Bind(INTERNAL_COMMENTS_COMMENT_LINE1);
                fldINTERNAL_COMMENTS_COMMENT_LINE2.Bind(INTERNAL_COMMENTS_COMMENT_LINE2);
                fldINTERNAL_COMMENTS_COMMENT_LINE3.Bind(INTERNAL_COMMENTS_COMMENT_LINE3);
                fldINTERNAL_COMMENTS_COMMENT_LINE4.Bind(INTERNAL_COMMENTS_COMMENT_LINE4);
                fldBOOKING_COMMENTS_COMMENT_LINE1.Bind(BOOKING_COMMENTS_COMMENT_LINE1);
                fldBOOKING_COMMENTS_COMMENT_LINE2.Bind(BOOKING_COMMENTS_COMMENT_LINE2);
                fldBOOKING_COMMENTS_COMMENT_LINE3.Bind(BOOKING_COMMENTS_COMMENT_LINE3);
                fldBOOKING_COMMENTS_COMMENT_LINE4.Bind(BOOKING_COMMENTS_COMMENT_LINE4);

            }
            catch (CustomApplicationException ex)
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



        private void fldT_STOP_DUPS_LookupNotOn(ref bool LookupNotOnExecuted)
        {

            try
            {
                bool blnAlreadyExists = false;
                StringBuilder strSQL = new StringBuilder("SELECT ").Append(fleBD_EXISTS.ElementOwner("BOOKING_REF"));
                strSQL.Append(" FROM ");
                strSQL.Append(fleBD_EXISTS.TableNameWithAlias());
                strSQL.Append(" WHERE ");
                strSQL.Append("     ").Append(fleBD_EXISTS.ElementOwner("BOOKING_REF")).Append(" = ").Append(Common.StringToField(T_BOOKING_REF.Value));

                if (!LookupNotOn(strSQL, fleBD_EXISTS, "BOOKING_REF", T_BOOKING_REF.Value))
                {
                    blnAlreadyExists = true;
                }

                if (blnAlreadyExists)
                {
                    ErrorMessage("0");
                    // "Extra details exist - use find mode"
                }
                LookupNotOnExecuted = true;

            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }




        protected override void SaveParamsReceived()
        {

            try
            {
                SaveReceivingParams(flePROPERTIES, T_NEW_BOOKING, T_BOOKING_REF, T_START_DATE, T_OK, T_WEB_BOOKING);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }




        protected override void RetrieveParamsReceived()
        {

            try
            {
                Receiving(flePROPERTIES, T_NEW_BOOKING, T_BOOKING_REF, T_START_DATE, T_OK, T_WEB_BOOKING);


            }
            catch (CustomApplicationException ex)
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



        private void dsrDesigner_WHO_Click(object sender, System.EventArgs e)
        {

            try
            {

                Information(D_REF.Value + QDesign.NULL(" Booked by ") + QDesign.NULL(fleBOOKINGS.GetStringValue("USER_LOGON")) + QDesign.NULL(" on ") + D_BOOKING_DATE.Value + QDesign.NULL(" at ") + D_BOOKING_TIME.Value + QDesign.NULL(" Booking company ") + QDesign.NULL(fleBOOKING_DETAIL.GetStringValue("BOOKING_COMPANY")));
                // TODO: May need to fix manually


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }


        protected override bool PreEntry()
        {


            try
            {

                if (QDesign.NULL(fleBOOKINGS.GetStringValue("INVESTOR")) != QDesign.NULL("00006") && QDesign.NULL(fleBOOKINGS.GetStringValue("INVESTOR")) != QDesign.NULL("00007") && QDesign.NULL(fleBOOKINGS.GetStringValue("INVESTOR")) != QDesign.NULL("00012") && QDesign.NULL(fleBOOKINGS.GetStringValue("INVESTOR")) != QDesign.NULL("00015") && QDesign.NULL(fleBOOKINGS.GetStringValue("INVESTOR")) != QDesign.NULL("00038") && QDesign.NULL(fleBOOKINGS.GetStringValue("LONG_STAY")) != QDesign.NULL("Y") && fleBOOKINGS.GetDecimalValue("BOOKING_DATE") >= 20120222 && (QDesign.NULL(fleBOOKINGS.GetStringValue("GROUPING")) == QDesign.NULL("BOND") || QDesign.NULL(fleBOOKINGS.GetStringValue("GROUPING")) == QDesign.NULL("FISH")) && (QDesign.NULL(fleBOOKINGS.GetStringValue("LONG_STAY")) == QDesign.NULL("S") || QDesign.NULL(fleBOOKINGS.GetDecimalValue("DEPOSIT")) > 0 || (QDesign.NULL(fleBOOKINGS.GetDecimalValue("BOOKING_POINTS")) > 0 && 0 == QDesign.NULL((fleBOOKINGS.GetDecimalValue("BOOKING_POINTS") - fleBOOKINGS.GetDecimalValue("POINTS_ADJUST")))) && D_DAYS_AWAY.Value <= 70))
                {
                    T_OFFER.Value = "Y";
                }
                else
                {
                    T_OFFER.Value = "N";
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


        private bool Internal_SET_INTERNAL_COMMENTS()
        {


            try
            {

                while (fleINTERNAL_COMMENTS.For())
                {
                    if (QDesign.NULL(fleINTERNAL_COMMENTS.GetStringValue("COMMENT_LINE")) == QDesign.NULL(" "))
                    {
                        fleINTERNAL_COMMENTS.set_SetValue("COMMENT_LINE", T_INT_COMM.Value);
                        fleINTERNAL_COMMENTS.Break();
                        break; // TODO: might not be correct. Was : Exit Do
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


        private bool Internal_SHUFFLE_INTERNAL_COMMENTS()
        {


            try
            {

                while (fleINTERNAL_COMMENTS.For())
                {
                    if (QDesign.NULL(fleINTERNAL_COMMENTS.GetStringValue("COMMENT_LINE")) != QDesign.NULL(" "))
                    {
                        if (QDesign.NULL(T_INT_COMM_1.Value) == QDesign.NULL(" "))
                        {
                            T_INT_COMM_1.Value = fleINTERNAL_COMMENTS.GetStringValue("COMMENT_LINE");
                        }
                        else
                        {
                            if (QDesign.NULL(T_INT_COMM_2.Value) == QDesign.NULL(" "))
                            {
                                T_INT_COMM_2.Value = fleINTERNAL_COMMENTS.GetStringValue("COMMENT_LINE");
                            }
                            else
                            {
                                if (QDesign.NULL(T_INT_COMM_3.Value) == QDesign.NULL(" "))
                                {
                                    T_INT_COMM_3.Value = fleINTERNAL_COMMENTS.GetStringValue("COMMENT_LINE");
                                }
                                else
                                {
                                    if (QDesign.NULL(T_INT_COMM_4.Value) == QDesign.NULL(" "))
                                    {
                                        T_INT_COMM_4.Value = fleINTERNAL_COMMENTS.GetStringValue("COMMENT_LINE");
                                    }
                                }
                            }
                        }
                        fleINTERNAL_COMMENTS.set_SetValue("COMMENT_LINE", " ");
                    }
                }
                T_INT_COMM.Value = T_INT_COMM_1.Value;
                Internal_SET_INTERNAL_COMMENTS();
                T_INT_COMM.Value = T_INT_COMM_2.Value;
                Internal_SET_INTERNAL_COMMENTS();
                T_INT_COMM.Value = T_INT_COMM_3.Value;
                Internal_SET_INTERNAL_COMMENTS();
                T_INT_COMM.Value = T_INT_COMM_4.Value;
                Internal_SET_INTERNAL_COMMENTS();

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



        private void fldBOOKING_DETAIL_OFFER_CODE_Edit()
        {

            try
            {

                if (QDesign.NULL(fleBOOKING_DETAIL.GetStringValue("OFFER_CODE")) == QDesign.NULL("Q"))
                {
                    T_OFFER_CODE.Value = " ";
                    //RunScreen("OFFERCOD.QKC", RunScreenModes.Find, T_OFFER_CODE);
                    fleBOOKING_DETAIL.set_SetValue("OFFER_CODE", T_OFFER_CODE.Value);
                    Display(ref fldBOOKING_DETAIL_OFFER_CODE);
                }
                else
                {
                    if (QDesign.NULL(fleBOOKING_DETAIL.GetStringValue("OFFER_CODE")) != QDesign.NULL(" "))
                    {
                        // --> GET OFFER_CODES <--

                        fleOFFER_CODES.GetData(GetDataOptions.IsOptional);
                        // --> End GET OFFER_CODES <--
                        if (!AccessOk)
                        {
                            ErrorMessage("52125");
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



        private void fldBOOKING_DETAIL_OFFER_CODE_Process()
        {

            try
            {

                if (QDesign.NULL(fleBOOKING_DETAIL.GetStringValue("OFFER_CODE")) == QDesign.NULL(" "))
                {
                    while (fleINTERNAL_COMMENTS.For())
                    {
                        if (QDesign.NULL(QDesign.Substring(fleINTERNAL_COMMENTS.GetStringValue("COMMENT_LINE"), 1, 6)) == QDesign.NULL("Offer:"))
                        {
                            fleINTERNAL_COMMENTS.set_SetValue("COMMENT_LINE", " ");
                            //Display(ref fldBOOKING_COMMENTS_COMMENT_LINE)
                        }
                    }
                }
                else
                {
                    // --> GET OFFER_CODES <--

                    fleOFFER_CODES.GetData(GetDataOptions.IsOptional);
                    // --> End GET OFFER_CODES <--
                    if (!AccessOk)
                    {
                        Warning("32017");
                    }
                    else
                    {
                        while (fleINTERNAL_COMMENTS.For())
                        {
                            if (QDesign.NULL(fleINTERNAL_COMMENTS.GetStringValue("COMMENT_LINE")) == QDesign.NULL(" ") || QDesign.NULL(QDesign.Substring(fleINTERNAL_COMMENTS.GetStringValue("COMMENT_LINE"), 1, 6)) == QDesign.NULL("Offer:"))
                            {
                                fleINTERNAL_COMMENTS.set_SetValue("COMMENT_LINE", "Offer: " + fleOFFER_CODES.GetStringValue("OFFER_DESC"));
                                //Display(ref fldBOOKING_COMMENTS_COMMENT_LINE)
                                Warning(QDesign.NULL("Please do not overwrite the offer details"));
                                // TODO: May need to fix manually
                                fleINTERNAL_COMMENTS.Break();
                                break; // TODO: might not be correct. Was : Exit Do
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



        private void dsrDesigner_21_Click(object sender, System.EventArgs e)
        {

            try
            {

                while (fleINTERNAL_COMMENTS.For())
                {
                    if (QDesign.NULL(QDesign.Substring(fleINTERNAL_COMMENTS.GetStringValue("COMMENT_LINE"), 1, 6)) != QDesign.NULL("Offer:"))
                    {
                        if (Occurrence == 1)
                            Accept(ref fldINTERNAL_COMMENTS_COMMENT_LINE1);
                        else if (Occurrence == 2)
                            Accept(ref fldINTERNAL_COMMENTS_COMMENT_LINE2);
                        else if (Occurrence == 3)
                            Accept(ref fldINTERNAL_COMMENTS_COMMENT_LINE3);
                        else if (Occurrence == 4)
                            Accept(ref fldINTERNAL_COMMENTS_COMMENT_LINE4);
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



        private void fldBOOKING_DETAIL_ARRIVAL_TIME_Edit()
        {

            try
            {

                if (QDesign.NULL(UserID) != QDesign.NULL("weblive"))
                {
                    Information(QDesign.NULL("Only enter FLIGHT ETA") + QDesign.NULL("  (For any other arrival times use Property Managers Notes)"));
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



        private void fldBOOKING_DETAIL_NUMBER_IN_PARTY_Edit()
        {

            try
            {
                T_NUMBER_SLEPT.Value = flePROPERTIES.GetDecimalValue("NUMBER_SLEPT");

                object[] arrRunscreen = { T_SCREEN_NAME };
                RunScreen(new SCRNVST(), RunScreenModes.Entry, ref arrRunscreen);
                if (QDesign.NULL(FieldValue) > QDesign.NULL(T_NUMBER_SLEPT.Value))
                {
                    ErrorMessage(QDesign.NULL("Maximum number in party is ") + QDesign.ASCII(T_NUMBER_SLEPT.Value));
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



        private void fldT_SILENT_Edit()
        {

            try
            {

                // --> GET BOOKINGS <--
                fleBOOKINGS.GetData();
                // --> End GET BOOKINGS <--
                // --> GET M_INVESTORS <--
                fleM_INVESTORS.GetData();
                // --> End GET M_INVESTORS <--
                // --> GET BOND_COMP_CLUB <--

                fleBOND_COMP_CLUB.GetData(GetDataOptions.IsOptional);
                // --> End GET BOND_COMP_CLUB <--
                if (AccessOk)
                {
                    T_BCC_MEMBER.Value = "Y";
                }
                else
                {
                    T_BCC_MEMBER.Value = "N";
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



        private void fldBOOKING_DETAIL_ADULTS_Edit()
        {

            try
            {

                if (QDesign.NULL(fleBOOKING_DETAIL.GetDecimalValue("NUMBER_IN_PARTY")) < QDesign.NULL((FieldValue + fleBOOKING_DETAIL.GetDecimalValue("CHILDREN"))))
                {
                    ErrorMessage(QDesign.NULL("** The number of Adults + Children is greater than Number in Party."));
                    // TODO: May need to fix manually
                }
                if (QDesign.NULL(flePROPERTIES.GetDecimalValue("NUMBER_SLEPT")) < QDesign.NULL((FieldValue + fleBOOKING_DETAIL.GetDecimalValue("CHILDREN"))))
                {
                    ErrorMessage(QDesign.NULL("** The number of Adults + Children is too large for the property \a**"));
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



        private void fldBOOKING_DETAIL_CHILDREN_Edit()
        {

            try
            {

                if (QDesign.NULL(fleBOOKING_DETAIL.GetDecimalValue("NUMBER_IN_PARTY")) < QDesign.NULL((fleBOOKING_DETAIL.GetDecimalValue("ADULTS") + FieldValue)))
                {
                    ErrorMessage(QDesign.NULL("** The number of Adults + Children is greater than Number in Party."));
                    // TODO: May need to fix manually
                }
                if (QDesign.NULL(flePROPERTIES.GetDecimalValue("NUMBER_SLEPT")) < QDesign.NULL((fleBOOKING_DETAIL.GetDecimalValue("ADULTS") + FieldValue)))
                {
                    ErrorMessage(QDesign.NULL("** The number of Adults + Children is too large for the property \a**"));
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



        private void fldBOOKING_DETAIL_FOOD_PARCELS_Edit()
        {

            try
            {

                if (QDesign.NULL(flePROPERTIES.GetStringValue("FOODPACKS_YN")) == QDesign.NULL("N"))
                {
                    if (QDesign.NULL(flePROPERTIES.GetStringValue("LOCATION")) == QDesign.NULL("JV"))
                    {
                        ErrorMessage("52126");
                    }
                    else
                    {
                        ErrorMessage("52127");
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



        private void fldBOOKING_DETAIL_HIGH_CHAIRS_Edit()
        {

            try
            {

                if (QDesign.NULL(flePROPERTIES.GetStringValue("HIGH_CHAIRS_YN")) == QDesign.NULL("N"))
                {
                    ErrorMessage("52128");
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



        private void fldBOOKING_DETAIL_COTS_Edit()
        {

            try
            {

                if (QDesign.NULL(flePROPERTIES.GetStringValue("COTS_YN")) == QDesign.NULL("N"))
                {
                    ErrorMessage("52129");
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



        private void fldBOOKING_DETAIL_PETS_Edit()
        {

            try
            {

                if (QDesign.NULL(flePROPERTIES.GetStringValue("PETS_YN")) == QDesign.NULL("N"))
                {
                    ErrorMessage("52130");
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



        private void fldBOOKING_DETAIL_NO_EXTRA_BEDS_Edit()
        {

            try
            {

                if (QDesign.NULL(flePROPERTIES.GetStringValue("ZBEDS_YN")) == QDesign.NULL("N"))
                {
                    ErrorMessage("52131");
                }
                if (QDesign.NULL(fleBOOKING_DETAIL.GetDecimalValue("NO_EXTRA_BEDS")) > 0)
                {
                    Warning("32018");
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



        private void dsrDesigner_22_Click(object sender, System.EventArgs e)
        {

            try
            {
                if (fleBOOKING_DETAIL.GetStringValue("BOOKING_REF").Trim() != "")
                    T_BOOKING_REF.Value = fleBOOKING_DETAIL.GetStringValue("BOOKING_REF");
                T_INVESTOR.Value = fleBOOKINGS.GetStringValue("INVESTOR");
                T_TYPE.Value = "S";
                //RunScreen("INSUR.QKC", RunScreenModes.Find, T_BOOKING_REF, T_INVESTOR, T_TYPE);
                // --> GET INSURANCE <--

                fleINSURANCE.GetData(GetDataOptions.IsOptional);
                // --> End GET INSURANCE <--
                Display(ref fldD_INSURANCE);
                Display(ref fldINSURANCE_COMMENCE_DATE);
                Display(ref fldINSURANCE_FINISH_DATE);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_23_Click(object sender, System.EventArgs e)
        {

            try
            {

                if (QDesign.NULL(T_BCC_MEMBER.Value) == QDesign.NULL("Y"))
                {
                    Accept(ref fldBOOKING_DETAIL_BCC_HOLIDAY);
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


        protected override bool PostFind()
        {


            try
            {

                while (fleINTERNAL_COMMENTS.For())
                {
                    switch (Occurrence)
                    {
                        case 1:
                            INTERNAL_COMMENTS_COMMENT_LINE1.Value = fleINTERNAL_COMMENTS.GetStringValue("COMMENT_LINE");
                            break;
                        case 2:
                            INTERNAL_COMMENTS_COMMENT_LINE2.Value = fleINTERNAL_COMMENTS.GetStringValue("COMMENT_LINE");
                            break;
                        case 3:
                            INTERNAL_COMMENTS_COMMENT_LINE3.Value = fleINTERNAL_COMMENTS.GetStringValue("COMMENT_LINE");
                            break;
                        case 4:
                            INTERNAL_COMMENTS_COMMENT_LINE4.Value = fleINTERNAL_COMMENTS.GetStringValue("COMMENT_LINE");
                            break;
                    }

                }

                 while (fleBOOKING_COMMENTS.For())
                {
                    switch (Occurrence)
                    {
                        case 1:
                            BOOKING_COMMENTS_COMMENT_LINE1.Value = fleBOOKING_COMMENTS.GetStringValue("COMMENT_LINE");
                            break;
                        case 2:
                            BOOKING_COMMENTS_COMMENT_LINE2.Value = fleBOOKING_COMMENTS.GetStringValue("COMMENT_LINE");
                            break;
                        case 3:
                            BOOKING_COMMENTS_COMMENT_LINE3.Value = fleBOOKING_COMMENTS.GetStringValue("COMMENT_LINE");
                            break;
                        case 4:
                            BOOKING_COMMENTS_COMMENT_LINE4.Value = fleBOOKING_COMMENTS.GetStringValue("COMMENT_LINE");
                            break;
                    }

                }

                // --> GET CORR_ADDRESS <--

                fleCORR_ADDRESS.GetData(GetDataOptions.IsOptional);
                // --> End GET CORR_ADDRESS <--
                if (AccessOk)
                {
                    T_CORR_ADDRESS.Value = "*";
                    Display(ref fldT_CORR_ADDRESS);
                }
                if ((QDesign.NULL(fleBOOKING_DETAIL.GetDecimalValue("ARRIVAL_TIME")) == 0 || QDesign.NULL(fleBOOKING_DETAIL.GetStringValue("FLIGHT_NUMBER")) == QDesign.NULL(" ")) && 90 >= (QDesign.Days(fleBOOKINGS.GetDecimalValue("START_DATE")) - QDesign.Days(QDesign.SysDate(ref m_cnnQUERY))) && fleBOOKINGS.GetDecimalValue("START_DATE") >= QDesign.SysDate(ref m_cnnQUERY) && QDesign.NULL(fleLOCATIONS.GetStringValue("AREA")) != QDesign.NULL("UKL ") && QDesign.NULL(fleLOCATIONS.GetStringValue("AREA")) != QDesign.NULL("CTY ") && QDesign.NULL(fleLOCATIONS.GetStringValue("AREA")) != QDesign.NULL("SHHL") && QDesign.NULL(fleLOCATIONS.GetStringValue("AREA")) != QDesign.NULL("SHHT") && QDesign.NULL(fleLOCATIONS.GetStringValue("LOCATION")) != QDesign.NULL("SS") && QDesign.NULL(fleLOCATIONS.GetStringValue("LOCATION")) != QDesign.NULL("MH"))
                {
                    if (QDesign.NULL(QDesign.Substring(fleBOOKINGS.GetStringValue("GROUPING"), 1, 3)) == QDesign.NULL("TEN"))
                    {
                        Information(QDesign.NULL("**URGENT** We must have the arrival time (and flight number) **URGENT**"));
                        // TODO: May need to fix manually
                    }
                    else
                    {
                        Information(QDesign.NULL("Please ask Bondholder for their flight number and arrival time"));
                        // TODO: May need to fix manually
                    }
                }
                // --> GET BOOKINGS <--
                fleBOOKINGS.GetData();
                // --> End GET BOOKINGS <--
                // --> GET M_INVESTORS <--
                fleM_INVESTORS.GetData();
                // --> End GET M_INVESTORS <--
                // --> GET BOND_COMP_CLUB <--

                fleBOND_COMP_CLUB.GetData(GetDataOptions.IsOptional);
                // --> End GET BOND_COMP_CLUB <--
                if (AccessOk)
                {
                    T_BCC_MEMBER.Value = "Y";
                }
                else
                {
                    T_BCC_MEMBER.Value = "N";
                }
                Display(ref fldBOOKING_DETAIL_TAXIS_BOOKED);
                T_OLD_FLIGHT.Value = fleBOOKING_DETAIL.GetStringValue("FLIGHT_NUMBER");
                T_OLD_ARRIVAL.Value = fleBOOKING_DETAIL.GetDecimalValue("ARRIVAL_TIME");

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



        private void fldT_SILENT_2_Edit()
        {

            try
            {

                if (QDesign.NULL(D_BOOKING_COMPANY.Value) == QDesign.NULL(" "))
                {
                    Warning("32019");
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



        private void fldT_BOOKING_COMPANY_Input()
        {

            try
            {

                if (QDesign.NULL(FieldText) == QDesign.NULL(" "))
                {
                    ErrorMessage("52132");
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


        protected override bool PreUpdate()
        {


            try
            {

                 while (fleINTERNAL_COMMENTS.For())
                {
                    switch (Occurrence)
                    {
                        case 1:
                            fleINTERNAL_COMMENTS.set_SetValue("COMMENT_LINE", INTERNAL_COMMENTS_COMMENT_LINE1.Value);
                            break;
                        case 2:
                            fleINTERNAL_COMMENTS.set_SetValue("COMMENT_LINE", INTERNAL_COMMENTS_COMMENT_LINE2.Value);
                            break;
                        case 3:
                            fleINTERNAL_COMMENTS.set_SetValue("COMMENT_LINE", INTERNAL_COMMENTS_COMMENT_LINE3.Value);
                            break;
                        case 4:
                           fleINTERNAL_COMMENTS.set_SetValue("COMMENT_LINE", INTERNAL_COMMENTS_COMMENT_LINE4.Value);
                            break;
                    }

                }

                 while (fleBOOKING_COMMENTS.For())
                {
                    switch (Occurrence)
                    {
                        case 1:
                           fleBOOKING_COMMENTS.set_SetValue("COMMENT_LINE", BOOKING_COMMENTS_COMMENT_LINE1.Value);
                            break;
                        case 2:
                           fleBOOKING_COMMENTS.set_SetValue("COMMENT_LINE", BOOKING_COMMENTS_COMMENT_LINE2.Value);
                            break;
                        case 3:
                            fleBOOKING_COMMENTS.set_SetValue("COMMENT_LINE", BOOKING_COMMENTS_COMMENT_LINE3.Value);
                            break;
                        case 4:
                            fleBOOKING_COMMENTS.set_SetValue("COMMENT_LINE", BOOKING_COMMENTS_COMMENT_LINE4.Value);
                            break;
                    }

                }

                if (QDesign.NULL(fleBOOKING_DETAIL.GetStringValue("OFFER_CODE")) == QDesign.NULL(" ") && QDesign.NULL(fleBOOKINGS.GetStringValue("INVESTOR")) != QDesign.NULL("00006") && QDesign.NULL(fleBOOKINGS.GetStringValue("INVESTOR")) != QDesign.NULL("00007") && QDesign.NULL(fleBOOKINGS.GetStringValue("INVESTOR")) != QDesign.NULL("00012") && QDesign.NULL(fleBOOKINGS.GetStringValue("INVESTOR")) != QDesign.NULL("00015") && QDesign.NULL(fleBOOKINGS.GetStringValue("INVESTOR")) != QDesign.NULL("00038") && QDesign.NULL(fleBOOKINGS.GetStringValue("LONG_STAY")) != QDesign.NULL("Y") && fleBOOKINGS.GetDecimalValue("BOOKING_DATE") >= 20120222 && (QDesign.NULL(fleBOOKINGS.GetStringValue("GROUPING")) == QDesign.NULL("BOND") || QDesign.NULL(fleBOOKINGS.GetStringValue("GROUPING")) == QDesign.NULL("FISH")) && (QDesign.NULL(fleBOOKINGS.GetStringValue("LONG_STAY")) == QDesign.NULL("S") || QDesign.NULL(fleBOOKINGS.GetDecimalValue("DEPOSIT")) > 0 || (QDesign.NULL(fleBOOKINGS.GetDecimalValue("BOOKING_POINTS")) > 0 && 0 == QDesign.NULL((fleBOOKINGS.GetDecimalValue("BOOKING_POINTS") - fleBOOKINGS.GetDecimalValue("POINTS_ADJUST")))) && D_DAYS_AWAY.Value <= 70))
                {
                    ErrorMessage("52133");
                }
                if (QDesign.NULL(D_TOT_IN_PARTY.Value) > QDesign.NULL(fleBOOKING_DETAIL.GetDecimalValue("NUMBER_IN_PARTY")))
                {
                    ErrorMessage(QDesign.NULL("** The number of Adults + Children is greater than Number in Party."));
                    // TODO: May need to fix manually
                }
                if (QDesign.NULL(D_TOT_IN_PARTY.Value) > QDesign.NULL(flePROPERTIES.GetDecimalValue("NUMBER_SLEPT")))
                {
                    ErrorMessage(QDesign.NULL("** The number of Adults + Children is too large for the property \a**"));
                    // TODO: May need to fix manually
                }
                if (QDesign.NULL(fleBOOKING_DETAIL.GetDecimalValue("NO_EXTRA_BEDS")) > 0)
                {
                    T_BCOMMENT.Value = "N";
                    while (fleBOOKING_COMMENTS.For())
                    {
                        if (QDesign.NULL(fleBOOKING_COMMENTS.GetStringValue("COMMENT_LINE")) != QDesign.NULL(" "))
                        {
                            T_BCOMMENT.Value = "Y";
                        }
                    }
                    if (QDesign.NULL(T_BCOMMENT.Value) == QDesign.NULL("N"))
                    {
                        ErrorMessage("52134");
                    }
                }
                if (QDesign.NULL(T_OK.Value) == QDesign.NULL("Y") || QDesign.NULL(fleBOOKINGS.GetStringValue("LONG_STAY")) != QDesign.NULL("N"))
                {
                    while (fleINTERNAL_COMMENTS.For())
                    {
                        if (QDesign.NULL(fleINTERNAL_COMMENTS.GetStringValue("COMMENT_LINE")) != QDesign.NULL(" "))
                        {
                            T_ENTERED.Value = "Y";
                        }
                    }
                    if (QDesign.NULL(T_ENTERED.Value) != QDesign.NULL("Y") && QDesign.NULL(T_OK.Value) == QDesign.NULL("Y"))
                    {
                        ErrorMessage("52135");
                    }
                    if (QDesign.NULL(T_ENTERED.Value) != QDesign.NULL("Y") && QDesign.NULL(fleBOOKINGS.GetStringValue("LONG_STAY")) != QDesign.NULL("N"))
                    {
                        ErrorMessage("52136");
                    }
                }
                while (fleBOOKING_COMMENTS.For())
                {
                    if (fleBOOKING_COMMENTS.AlteredRecord && QDesign.NULL(T_NEW_BOOKING.Value) != QDesign.NULL("Y"))
                    {
                        fleBOOKING_DETAIL.set_SetValue("AMEND_DATE", QDesign.SysDate(ref m_cnnQUERY));
                        fleBOOKING_DETAIL.set_SetValue("AMEND_TIME", QDesign.NConvert(QDesign.Substring(QDesign.ASCII(QDesign.SysTime(ref m_cnnQUERY), 8), 1, 4)));
                        if (QDesign.NULL(D_SYSDATE_PLUS8.Value) > QDesign.NULL(D_START_DATE.Value))
                        {
                            fleBOOK_DTL_CHANGE.set_SetValue("COMMENTS_CHANGED", "Y");
                            fleBOOK_DTL_CHANGE.set_SetValue("BOOKING_REF", T_BOOKING_REF.Value);
                        }
                    }
                }
                if (QDesign.NULL(T_BCC_MEMBER.Value) == QDesign.NULL("Y") && QDesign.NULL(fleBOOKING_DETAIL.GetStringValue("BCC_HOLIDAY")) == QDesign.NULL(" "))
                {
                    ErrorMessage("52137");
                }
                if ((fleBOOKING_DETAIL.AlteredRecord || fleBOOKING_DETAIL.NewRecord) && QDesign.NULL(T_NEW_BOOKING.Value) != QDesign.NULL("Y"))
                {
                    fleBOOKING_DETAIL.set_SetValue("AMEND_DATE", QDesign.SysDate(ref m_cnnQUERY));
                    fleBOOKING_DETAIL.set_SetValue("AMEND_TIME", QDesign.NConvert(QDesign.Substring(QDesign.ASCII(QDesign.SysTime(ref m_cnnQUERY), 8), 1, 4)));
                }
                if ((fleBOOKING_DETAIL.AlteredRecord || fleBOOKING_COMMENTS.AlteredRecord) && QDesign.NULL(D_SYSDATE_PLUS8.Value) > QDesign.NULL(D_START_DATE.Value) && QDesign.NULL(T_NEW_BOOKING.Value) != QDesign.NULL("Y"))
                {
                    fleBOOK_DTL_CHANGE.set_SetValue("BOOKING_REF", T_BOOKING_REF.Value);
                }
                Internal_SHUFFLE_INTERNAL_COMMENTS();
                if (QDesign.NULL(D_BOOKING_COMPANY.Value) == QDesign.NULL(" ") && QDesign.NULL(fleBOOKING_DETAIL.GetStringValue("BOOKING_COMPANY")) == QDesign.NULL(" "))
                {
                    Information("42025");
                    Accept(ref fldT_BOOKING_COMPANY);
                    fleBOOKING_DETAIL.set_SetValue("BOOKING_COMPANY", T_BOOKING_COMPANY.Value);
                }
                else
                {
                    fleBOOKING_DETAIL.set_SetValue("PROPERTY_COMPANY", D_BOOKING_COMPANY.Value);
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


        protected override bool Initialize()
        {


            try
            {

                

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


        protected override bool Exit()
        {


            try
            {

                // --> GET BOOKING_DETAIL <--
                m_strWhere = new StringBuilder(" WHERE ");
                m_strWhere.Append(" ").Append(fleBOOKING_DETAIL.ElementOwner("BOOKING_REF")).Append(" = ");
                m_strWhere.Append(Common.StringToField(T_BOOKING_REF.Value));

                fleBOOKING_DETAIL.GetData(m_strWhere.ToString());
                // --> End GET BOOKING_DETAIL <--
                if (!AccessOk)
                {
                    fleBOOKING_DETAIL.set_SetValue("BOOKING_REF", T_BOOKING_REF.Value);
                    fleBOOKING_DETAIL.PutData();
                }
                if (QDesign.NULL(T_OK.Value) == QDesign.NULL("Y"))
                {
                    while (fleINTERNAL_COMMENTS.For())
                    {
                        if (QDesign.NULL(fleINTERNAL_COMMENTS.GetStringValue("COMMENT_LINE")) != QDesign.NULL(" "))
                        {
                            T_ENTERED.Value = "Y";
                        }
                    }
                    if (QDesign.NULL(T_ENTERED.Value) != QDesign.NULL("Y") && QDesign.NULL(UserID) != QDesign.NULL("weblive"))
                    {
                        Information(QDesign.NULL("** You haven`t entered an internal comment for the points shortage"));
                        // TODO: May need to fix manually
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


        protected override bool Update()
        {


            try
            {

                while (fleBOOKING_COMMENTS.For())
                {
                    fleBOOKING_COMMENTS.PutData();
                    fleINTERNAL_COMMENTS.PutData();
                }
                if ((fleBOOKING_DETAIL.NewRecord || fleBOOKING_DETAIL.AlteredRecord) && QDesign.NULL(D_SYSDATE_PLUS8.Value) > QDesign.NULL(D_START_DATE.Value))
                {
                    fleBOOK_DTL_CHANGE.set_SetValue("BOOKING_REF", fleBOOKING_DETAIL.GetStringValue("BOOKING_REF"));
                    fleBOOK_DTL_CHANGE.PutData();
                }
                fleBOOKING_DETAIL.set_SetValue("BOOKING_COMPANY", D_BOOKING_COMPANY.Value);
                fleBOOKING_DETAIL.set_SetValue("PROPERTY_COMPANY", flePROPERTIES.GetStringValue("PROPERTY_COMPANY"));
                fleBOOKING_DETAIL.PutData();
                flePROPERTIES.PutData();

                ReturnAndClose();
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
                m_strWhere = new StringBuilder(GetWhereCondition(fleBOOKING_DETAIL.ElementOwner("BOOKING_REF"), T_BOOKING_REF.Value, ref blnAddWhere));
                fleBOOKING_DETAIL.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);

                fleBOOK_DTL_CHANGE.GetData();

                fleINTERNAL_COMMENTS.GetData();

                fleBOOKING_COMMENTS.GetData();


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



        protected override bool Path()
        {


            try
            {
                m_intPath = 1;


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
                Page.PageTitle = "B o o k i n g   D e t a i l s";



            }
            catch (CustomApplicationException ex)
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
        //# Append Procedure
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 07/12/2013 1:50:26 PM
        //#-----------------------------------------
        protected override bool Append()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:50:26 PM
                
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
        //# Entry Procedure
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 07/12/2013 1:50:26 PM
        //#-----------------------------------------
        protected override bool Entry()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:50:26 PM
                Display(ref fldD_WEEK_WORD);
                Display(ref fldT_BOOKING_REF);
                Edit(ref fldT_SILENT);
                Edit(ref fldT_STOP_DUPS);
                Accept(ref fldBOOKING_DETAIL_NUMBER_IN_PARTY);
                Accept(ref fldBOOKING_DETAIL_ADULTS);
                Accept(ref fldBOOKING_DETAIL_CHILDREN);
                Accept(ref fldBOOKING_DETAIL_INFANTS);
                if (QDesign.NULL(flePROPERTIES.GetStringValue("FOODPACKS_YN")) != QDesign.NULL("N"))
                {
                    Accept(ref fldBOOKING_DETAIL_FOOD_PARCELS);
                }
                else
                {
                    Display(ref fldBOOKING_DETAIL_FOOD_PARCELS);
                }
                if (QDesign.NULL(flePROPERTIES.GetStringValue("COTS_YN")) != QDesign.NULL("N"))
                {
                    Accept(ref fldBOOKING_DETAIL_COTS);
                }
                else
                {
                    Display(ref fldBOOKING_DETAIL_COTS);
                }
                if (QDesign.NULL(flePROPERTIES.GetStringValue("HIGH_CHAIRS_YN")) != QDesign.NULL("N"))
                {
                    Accept(ref fldBOOKING_DETAIL_HIGH_CHAIRS);
                }
                else
                {
                    Display(ref fldBOOKING_DETAIL_HIGH_CHAIRS);
                }
                Display(ref fldD_WEB_BOOKING);
                Accept(ref fldBOOKING_DETAIL_NO_EXTRA_BEDS);
                if (QDesign.NULL(flePROPERTIES.GetStringValue("PETS_YN")) != QDesign.NULL("N"))
                {
                    Accept(ref fldBOOKING_DETAIL_PETS);
                }
                else
                {
                    Display(ref fldBOOKING_DETAIL_PETS);
                }
                Display(ref fldT_CORR_ADDRESS);
                if (QDesign.NULL(T_OFFER.Value) == QDesign.NULL("Y"))
                {
                    Accept(ref fldBOOKING_DETAIL_OFFER_CODE);
                }
                else
                {
                    Display(ref fldBOOKING_DETAIL_OFFER_CODE);
                }
                Accept(ref fldBOOKING_DETAIL_POWERSOFT_NUMBER);
                Accept(ref fldBOOKING_DETAIL_FLIGHT_NUMBER);
                Accept(ref fldBOOKING_DETAIL_ARRIVAL_TIME);
                Accept(ref fldBOOKING_DETAIL_FLIGHTS_BOOKED);
                Accept(ref fldBOOKING_DETAIL_CAR_HIRE_BOOKED);
                Accept(ref fldBOOKING_DETAIL_FERRIES_BOOKED);
                Accept(ref fldBOOKING_DETAIL_TRANSFERS_BOOKED);
                Accept(ref fldBOOKING_DETAIL_TAXIS_BOOKED);
                Accept(ref fldBOOKING_DETAIL_CAR_PARK_BOOKED);
                Display(ref fldCANCEL_BOOKING_REASON);
                Display(ref fldD_INSURANCE);
                Display(ref fldINSURANCE_COMMENCE_DATE);
                Display(ref fldINSURANCE_FINISH_DATE);
                Display(ref fldD_BCC_PROMPT);
                if (QDesign.NULL(T_BCC_MEMBER.Value) == QDesign.NULL("Y"))
                {
                    Accept(ref fldBOOKING_DETAIL_BCC_HOLIDAY);
                }
                else
                {
                    Display(ref fldBOOKING_DETAIL_BCC_HOLIDAY);
                }
                Edit(ref fldT_SILENT_2);
                if (QDesign.NULL(D_BOOKING_COMPANY.Value) == QDesign.NULL(" "))
                {
                    Accept(ref fldT_BOOKING_COMPANY);
                }
                else
                {
                    Display(ref fldT_BOOKING_COMPANY);
                }
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
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 07/12/2013 1:50:26 PM
        //#-----------------------------------------
        protected override bool Delete()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:50:26 PM
                fleBOOKING_DETAIL.DeletedRecord = true;
                fleINTERNAL_COMMENTS.DeletedRecord = true;
                fleBOOK_DTL_CHANGE.DeletedRecord = true;
                while (fleBOOKING_COMMENTS.For())
                {
                    fleBOOKING_COMMENTS.DeletedRecord = true;
                }
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
        //# dtlINTERNAL_COMMENTS_EditClick Procedure
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 07/12/2013 1:50:26 PM
        //#-----------------------------------------
        private void dtlINTERNAL_COMMENTS_EditClick(DataList source, GridButtonEventArgs GridButtonEventArgs)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:50:26 PM
                dsrDesigner_20_Click(null, null);
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
        //# dsrDesigner_15_Click Procedure
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 07/12/2013 1:50:26 PM
        //#-----------------------------------------
        private void dsrDesigner_15_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:50:26 PM
                Accept(ref fldBOOKING_DETAIL_FLIGHTS_BOOKED);
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
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 07/12/2013 1:50:26 PM
        //#-----------------------------------------
        private void dsrDesigner_17_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:50:26 PM
                Accept(ref fldBOOKING_DETAIL_FERRIES_BOOKED);
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
        //# dsrDesigner_16_Click Procedure
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 07/12/2013 1:50:26 PM
        //#-----------------------------------------
        private void dsrDesigner_16_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:50:26 PM
                Accept(ref fldBOOKING_DETAIL_CAR_HIRE_BOOKED);
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
        //# dsrDesigner_07_Click Procedure
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 07/12/2013 1:50:26 PM
        //#-----------------------------------------
        private void dsrDesigner_07_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:50:26 PM
                Accept(ref fldBOOKING_DETAIL_HIGH_CHAIRS);
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
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 07/12/2013 1:50:26 PM
        //#-----------------------------------------
        private void dsrDesigner_13_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:50:26 PM
                Accept(ref fldBOOKING_DETAIL_FLIGHT_NUMBER);
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
        //# dsrDesigner_19_Click Procedure
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 07/12/2013 1:50:26 PM
        //#-----------------------------------------
        private void dsrDesigner_19_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:50:26 PM
                Accept(ref fldBOOKING_DETAIL_TAXIS_BOOKED);
                Accept(ref fldBOOKING_DETAIL_CAR_PARK_BOOKED);
                Accept(ref fldBOOKING_COMMENTS_COMMENT_LINE1);
                Accept(ref fldBOOKING_COMMENTS_COMMENT_LINE2);
                Accept(ref fldBOOKING_COMMENTS_COMMENT_LINE3);
                Accept(ref fldBOOKING_COMMENTS_COMMENT_LINE4);
                Display(ref fldCANCEL_BOOKING_REASON);
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
        //# dsrDesigner_14_Click Procedure
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 07/12/2013 1:50:26 PM
        //#-----------------------------------------
        private void dsrDesigner_14_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:50:26 PM
                Accept(ref fldBOOKING_DETAIL_ARRIVAL_TIME);
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
        //# dsrDesigner_02_Click Procedure
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 07/12/2013 1:50:26 PM
        //#-----------------------------------------
        private void dsrDesigner_02_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:50:26 PM
                Accept(ref fldBOOKING_DETAIL_ADULTS);
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
        //# dsrDesigner_08_Click Procedure
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 07/12/2013 1:50:26 PM
        //#-----------------------------------------
        private void dsrDesigner_08_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:50:26 PM
                Accept(ref fldBOOKING_DETAIL_NO_EXTRA_BEDS);
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
        //# dsrDesigner_04_Click Procedure
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 07/12/2013 1:50:26 PM
        //#-----------------------------------------
        private void dsrDesigner_04_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:50:26 PM
                Accept(ref fldBOOKING_DETAIL_INFANTS);
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
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 07/12/2013 1:50:26 PM
        //#-----------------------------------------
        private void dsrDesigner_20_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:50:26 PM
                Accept(ref fldINTERNAL_COMMENTS_COMMENT_LINE1);
                Accept(ref fldINTERNAL_COMMENTS_COMMENT_LINE2);
                Accept(ref fldINTERNAL_COMMENTS_COMMENT_LINE3);
                Accept(ref fldINTERNAL_COMMENTS_COMMENT_LINE4);
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
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 07/12/2013 1:50:26 PM
        //#-----------------------------------------
        private void dsrDesigner_05_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:50:26 PM
                Accept(ref fldBOOKING_DETAIL_FOOD_PARCELS);
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
        //# dsrDesigner_01_Click Procedure
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 07/12/2013 1:50:26 PM
        //#-----------------------------------------
        private void dsrDesigner_01_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:50:26 PM
                Accept(ref fldBOOKING_DETAIL_NUMBER_IN_PARTY);
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
        //# dsrDesigner_11_Click Procedure
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 07/12/2013 1:50:26 PM
        //#-----------------------------------------
        private void dsrDesigner_11_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:50:26 PM
                Accept(ref fldBOOKING_DETAIL_OFFER_CODE);
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
        //# dsrDesigner_06_Click Procedure
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 07/12/2013 1:50:26 PM
        //#-----------------------------------------
        private void dsrDesigner_06_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:50:26 PM
                Accept(ref fldBOOKING_DETAIL_COTS);
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
        //# dsrDesigner_12_Click Procedure
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 07/12/2013 1:50:26 PM
        //#-----------------------------------------
        private void dsrDesigner_12_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:50:26 PM
                Accept(ref fldBOOKING_DETAIL_POWERSOFT_NUMBER);
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
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 07/12/2013 1:50:26 PM
        //#-----------------------------------------
        private void dsrDesigner_18_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:50:26 PM
                Accept(ref fldBOOKING_DETAIL_TRANSFERS_BOOKED);
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
        //# dsrDesigner_03_Click Procedure
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 07/12/2013 1:50:26 PM
        //#-----------------------------------------
        private void dsrDesigner_03_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:50:26 PM
                Accept(ref fldBOOKING_DETAIL_CHILDREN);
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
        //# dsrDesigner_09_Click Procedure
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 07/12/2013 1:50:26 PM
        //#-----------------------------------------
        private void dsrDesigner_09_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:50:26 PM
                Accept(ref fldBOOKING_DETAIL_PETS);
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
