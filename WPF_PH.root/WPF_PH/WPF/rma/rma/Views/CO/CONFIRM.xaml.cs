
#region "Screen Comments"

// ---------------------------------------------------------------:
// SYSTEM:       Holiday Property Bond                         :
// :
// PROGRAM:      CONFIRM.QKS                                   :
// :
// TASK:         CONFIRMS PROVISIONAL BOOKINGS                 :
// :
// FILES:        BOOKINGS            primary                   :
// :
// CALLED BY:    MENU0000    MAIN SYSTEM MENU                  :
// :
// ---------------------------------------------------------------:
// CSS    22.05.88           DEFERRED PAYMENTS HPB/001          :
// ---------------------------------------------------------------:
// MCPG   31.08.89           6 MTHS REDUCED to 2 MTHS.          :
// USER CHARGE change (C. MANN) REFERS:
// ---------------------------------------------------------------:
// ROB 25/02/95 : NEW CODES for PAYMENT METHOD  VO  and  CN ,    ;
// WHICH ARE CREDIT CARD PAYMENTS WITHOUT 1.2% LEVY.
// ----------------------------------------------------------------
// 12/09/95 - gadd optional to get PROVE-LETTERS in delete procedure.
// --------------------------------------------------------------------
// 28/11/95 - warning message if HPB flight option/bookings are held.
// --------------------------------------------------------------------
// 12/03/96 - BK-ENTITLEMENT was being set incorrectly if 70-day points
// were used.
// --------------------------------------------------------------------
// 24/07/96 - change layout of screen.
// - Removed ID numbers from items that can`t be changed.
// - Don`t allow confirming purchase points if bk-purchase = 0
// --------------------------------------------------------------------
// 08/04/97 - Replace some lines that went missing ! SCREEN statements
// --------------------------------------------------------------------
// 08/04/97 - display info messages for bookings that have allready
// been confirmed or cancelled.
// --------------------------------------------------------------------
// 30/04/97 - Correction to wording of above message
// ------------------------------------------------------------------
// 14/01/00 - Set VAT of BOOKING-DEBTS to VAT of BOOKINGS
// ------------------------------------------------------------------
// 14/07/00 - Only allow NICK,JOAN,MANAGER,MARGIE to cancel bookings with
// something in FLIGHT-NUMBER
// ------------------------------------------------------------------
// 27/01/03 - Set PRINTED to  N  on new BOOKING-LETTERS record
// ------------------------------------------------------------------
// 10/04/03 -  beverly  replaced with  juliette  - IM
// ------------------------------------------------------------------
// 23.06.03 - add trans-ym to trans-header, investor-trans
// ------------------------------------------------------------------
// 29/10/03 - don`t allow payment type VO
// ------------------------------------------------------------------
// 01/12/03 - SHH bookings allways have a payment due (deposit or balance)
// ------------------------------------------------------------------
// 04/12/03 - Increase UCHARGE-DEBTS values by 1.012
// 04/12/03 - Set SHHT balance debt-type from BL to DB
// 04/12/03 - Show deposit amount on the screen
// ------------------------------------------------------------------
// 10/12/03 - Dont allow bookings if investor =  999SH   (SHHL)
// ------------------------------------------------------------------
// 11.12.03 - Phil Increase booking values by 1.012 only if not SHH
// ------------------------------------------------------------------
// 15.12.03 - Phil put out a message for SHH
// ------------------------------------------------------------------
// 06.02.04 - MGE  Add 90 day payment check for tenancy sites.
// ------------------------------------------------------------------
// 09.02.04 - MGE  Add valid-from of BOOKING-DEBTS (alias UCHARGE-DEBTS)
// also add warning if card already expired.
// ------------------------------------------------------------------
// 03.03.04 - MGE  Add flag to stop Credit Card charge being added twice.
// ------------------------------------------------------------------
// 23.09.04 - MGE  Add code for deposit payments.
// also spare-8 of bookings changed to grouping of bookings
// ------------------------------------------------------------------
// 27.09.04 - IM  Add confirm-time stamp
// -----------------------------------------------------------------
// 18/10/04 - Don`t allow deferment of deposits
// -----------------------------------------------------------------
// 16.12.04 - ME  get charge && vat on BOOKINGS from BOOKING-DEBTS
// after recalculation for Credit Charge payment.
// also delete balance-debts record when deleting
// UCHARGE-DEBTS record for Cancelled Reserved bookings.
// also add COLOUR-RATES file to get vat percentage.
// also removed file BOOKINGS alias CANCEL-BOOK as not
// used and now reached 30 file limit.
// -----------------------------------------------------------------
// 20.01.05 - ME  Set debt-paid-date on all payments
// for Stately Hoiday Homes (SHHL && SHHT)
// (even when PDQD =  N  and payment-method =  CC ).
// -----------------------------------------------------------------
// 21.04.05 - ME  Add code to put  O `s into Owner`s booking dates.
// -----------------------------------------------------------------
// 17.05.05 - ME  Add  hayleyd  to do instant confirm.
// -----------------------------------------------------------------
// 02.06.05 - ME  Change UCHARGE-DEBTS && BALANCE-DEBTS to designer files
// (were secondary) as not always updated when charge = 0
// Also qualify error message - only when charge > 0.
// to allow for entry of owner bookings with no value.
// -----------------------------------------------------------------
// 28.06.05 - ME  Do not allow Tenancies to defer payment within 3 months.
// -----------------------------------------------------------------
// 24/08/05 - RC  Set first-holiday-date for confirmed BOND bookings
// -----------------------------------------------------------------
// 21/10/05 - RC  Allow automatic `deletion` from VIEWBOOK, which now
// passes flags t-instant-conf and t-instant-delete
// -----------------------------------------------------------------
// 22.02.06 - ME  put signonuser into trans-spare of trans-header.
// -----------------------------------------------------------------
// 25.04.06 - ME  changes for Notional VAT.
// -----------------------------------------------------------------
// 28/04/06 -     was checking first-holiday-date < end-date of bookings  
// so changed to >
// -----------------------------------------------------------------
// 25.05.06 - ME  changes to separate out credit card charges.
// -----------------------------------------------------------------
// 26.06.06 - ME  fix SHH credit charge message amount displayed.
// -----------------------------------------------------------------
// 28.06.06 - ME  Allow issue-number = 0, and give warning message.
// -----------------------------------------------------------------
// 25.07.06 - ME  remove  PO  &&  CN  from payment-method options 
// and set debt-paid-date when paid by credit note  CR .
// -----------------------------------------------------------------
// 13.09.06 - ME  Changes to take online payments.
// -----------------------------------------------------------------
// 07.12.06   ME  Allow B`holders SHHL bookings to be confirmed.
// -----------------------------------------------------------------
// 03.01.07   ME  Allow  wendy  login the same facilities as  sueshhl 
// -----------------------------------------------------------------
// 08.01.07   ME  Stop SHH properties always updating debt-paid-date
// when payment is taken by PDQD machine.
// -----------------------------------------------------------------
// 15.02.07   ME  Allow Theme Weeks to defer payment on 3 month bookings.
// -----------------------------------------------------------------
// 07.06.07   ME  More changes for online payment collection.
// -----------------------------------------------------------------
// 20.08.07 - ME  Change CC surcharge from 1.2% to 1.4% from 1st Sep 07.
// -----------------------------------------------------------------
// 20.08.07 - ME  Check entitlement before taking payment.
// -----------------------------------------------------------------
// 21.08.07 - ME  Changes to screen handling.
// -----------------------------------------------------------------
// 24/08/07 - RC  setting t-pay-user-chg checks t-charge-paid <>  D 
// -----------------------------------------------------------------
// 29.08.07 - ME  Now add cc-surcharge in card collection screen (cardpay)
// - just in case of credit or discount amounts.
// -----------------------------------------------------------------
// 03.09.07 - ME  Fix problen of booking-debts changeing to CP when 
// they should be DP.
// -----------------------------------------------------------------
// 04.10.07 - ME  Add code to allow user to defer payment and take
// purchase points payment on its own.
// -----------------------------------------------------------------
// 19.10.07 - ME  Allow confirmation when there is nothing to pay.
// -----------------------------------------------------------------
// 26.10.07 - ME  Add extra checks before taking payment by card and
// also allocate points before taking card payments.
// -----------------------------------------------------------------
// 02.01.08 - ME  Set t-instant-delete to t-delete just before return
// -ing to viewbook etc so the delete can be confirmed.
// -----------------------------------------------------------------
// 04.01.08 ME  Moved info message after successful card payment 
// to try and prevent sparodic confirmation problem. 
// -----------------------------------------------------------------
// 11.01.08 ME  Add message if incorrect status returned from cardpay.qks
// -----------------------------------------------------------------
// 17.01.08 ME  Add extra check for t-instant-delete flag
// -----------------------------------------------------------------
// 19.02.08 ME  Add code to charge CC surcharge on Purchase points
// and use new payment screen takepay.qks
// -----------------------------------------------------------------
// 09.04.08 ME  Change cc-surcharge from 1.4% to 2.25%
// -----------------------------------------------------------------
// 17.09.08 ME  Do not confirm Prov Booking for New Investors (00011)
// -----------------------------------------------------------------
// 07.11.08 ME  Add code to re-create web_details record when a 
// reserved booking is deleted.
// -----------------------------------------------------------------
// 25.11.08 PJ  Changed invoice date to avoid BHs on 17.5%/15% VAT cusp
// -----------------------------------------------------------------
// 04.12.08 PJ  Allow cancelling of new investor bookings (CX _or_ RX status)
// -----------------------------------------------------------------
// 19.12.08 ME  Deposits are now always requested if start date is more
// than 90 days away, (if less full amount required) for
// all propeties - Nick Beamish.
// -----------------------------------------------------------------
// 23.12.08 PJ  Changed logic behind above as all properties were 90 days
// whereas should be tenancy and SHH properties at 90 days and
// others are 70
// -----------------------------------------------------------------
// 02.02.09 ME  Stop user being able to defer Tenancy && SHH user charges.
// -----------------------------------------------------------------
// 30.03.09 ME  Send a line of info to /exstore on every update.
// -----------------------------------------------------------------
// 16.04.09 ME  flight-header file no longer in use.
// -----------------------------------------------------------------
// 22.05.09 ME  Fix to stop #27 error when exstore file already in use.
// -------------------------------------------------------------------
// 20.07.09 IM  Juliette to be able to cancel provs with attached
// flights etc
// ----------------------------------------------------------------
// 11.11.09 ME  Stop sending data direct to /exstore - use /hpb/trans/..
// ----------------------------------------------------------------
// 25.11.09 ME  run webpoint.qkc to update web olpst rec after conf.
// ----------------------------------------------------------------
// 04.01.10 ME  Add extra booking-letter for email confirmations 
// when made from main menu.
// -------------------------------------------------------------------
// 05.05.10 ME  Send web-booking flag to bookdets.qkc
// -------------------------------------------------------------------
// 11.06.10 IM  Expanded fields due HWH gazillion points
// -------------------------------------------------------------------
// 27.08.10 ME  Run webbkngs.qks to update  My Points  web info.
// -------------------------------------------------------------------
// 09.11.10 RC  call screen booklink for cancellations to reset
// availability of linked property
// -------------------------------------------------------------------
// 11.11.10 ME  Now pass t-confirm-ref into this screen instead of
// t-booking-ref so that temps do not overlap.
// -------------------------------------------------------------------
// 02.12.10 ME  Only set up  CF  booking-letter record for posted confs.
// -------------------------------------------------------------------
// 18.01.11 RC  Set calling screen to CONFIRM for confirmed bookings
// and to CANCEL for deleted bookings so that booklink sets
// the linked property correctly.  
// -------------------------------------------------------------------
// 05.05.11 RC  Removed the code that was stopping the calendar being
// set for location RC. RC used to be Royal Court where we
// didn`t maintain availability, but RC was recently 
// re-used for Royal Crescent where we do!
// -------------------------------------------------------------------
// 11.10.11 ME  Change to points allocation for Dec 2011. To use brought
// forward points before entitlement bal for year 1 bookings.
// -------------------------------------------------------------------
// 19.12.11 ME  Use takepay2.qks instead for takepay.qks for specicied 
// users - for PCI complience.
// -------------------------------------------------------------------
// 25.01.12 ME  Changed for customer-type  I  (Interval International).
// -------------------------------------------------------------------
// 20.03.12 ME  Further changes for new PCI complient web interface.
// -------------------------------------------------------------------
// 25.05.12 RC  Create transaction records for special reserve
// Added investor-trans alias susp-trans but
// have hit the 31 file limit !!!!    ERROR !!!!!!
// Can probably get rid of ferry-request and flight-request
// as they are only there to delete (this could be done in
// QTP)  There may be other we can get rid of too such as
// prov-letters, ucharge-debts, balance-debts. For now I 
// am removing ferry-request as there aren`t many of them.
// -------------------------------------------------------------------
// 18.09.12 RM  Add scrnvst to record visit to this screen
// -------------------------------------------------------------------
// 24.10.12 PJ  Added new payment type PE for PED.  To replace CC and SW
// eventually? Added subscreen for PE user phil
// -------------------------------------------------------------------
// 19.12.12 PJ  Removed changes dated 24.10.12.
// -------------------------------------------------------------------
// 07.02.13 PJ  Added marina, removed sandy and sandra
// -------------------------------------------------------------------
// ON line 25  &
// for       23 lines &
// window    25 &
// message   48 &
// unix conv                  noautoupdate &
// 21/10/05

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

    partial class CONFIRM : BasePage
    {

        #region " Form Designer Generated Code "





        public CONFIRM()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "CONFIRM";

            //# Set the ACTIVITIES for the screen.
            this.ChangeActivity = true;
            this.FindActivity = true;
            this.DeleteActivity = true;
            this.EntryActivity = false;
            this.UseAcceptProcessing = true;
        }

        #endregion

        private void Page_Load(object sender, RoutedEventArgs e)
        {
            SetVariables();
            dsrDesigner_01.Click += dsrDesigner_01_Click;
            dsrDesigner_X.Click += dsrDesigner_X_Click;
            dsrDesigner_WAIT.Click += dsrDesigner_WAIT_Click;
            dsrDesigner_CF.Click += dsrDesigner_CF_Click;
            dsrDesigner_02.Click += dsrDesigner_02_Click;
            dsrDesigner_CORE_USER.Click += dsrDesigner_CORE_USER_Click;
            fldBOOKINGS_LOCATION.LookupOn += fldBOOKINGS_LOCATION_LookupOn;
            fldBOOKINGS_INVESTOR.Input += fldBOOKINGS_INVESTOR_Input;
            fldBOOKINGS_BOOKING_STATUS.Edit += fldBOOKINGS_BOOKING_STATUS_Edit;
            fldT_CHARGE_PAID.Input += fldT_CHARGE_PAID_Input;
            fldT_CHARGE_PAID.Edit += fldT_CHARGE_PAID_Edit;
            fldT_PAYMENT_METHOD.Input += fldT_PAYMENT_METHOD_Input;
            

            Page_Load();

            // TODO: The following elements have Input/Output Scaling defined in the Dictionary or Screen.  Manual steps may be required:
            //       BALANCE_DEBTS.CC_SURCHARGE InputScale: 2 OutputScale: 0
            //       BALANCE_DEBTS.CC_VAT InputScale: 2 OutputScale: 0
            //       BALANCE_DEBTS.DEBT_AMOUNT InputScale: 2 OutputScale: 0
            //       BALANCE_DEBTS.NOTIONAL_VAT InputScale: 2 OutputScale: 0
            //       BALANCE_DEBTS.PP1_SURCHARGE InputScale: 2 OutputScale: 0
            //       BALANCE_DEBTS.PP1_VAT InputScale: 2 OutputScale: 0
            //       BALANCE_DEBTS.PP2_SURCHARGE InputScale: 2 OutputScale: 0
            //       BALANCE_DEBTS.PP2_VAT InputScale: 2 OutputScale: 0
            //       BALANCE_DEBTS.TERM_SURCHARGE InputScale: 2 OutputScale: 0
            //       BALANCE_DEBTS.TERM_VAT InputScale: 2 OutputScale: 0
            //       BALANCE_DEBTS.TOTAL_DEBT InputScale: 2 OutputScale: 0
            //       BALANCE_DEBTS.TOTAL_VAT InputScale: 2 OutputScale: 0
            //       BALANCE_DEBTS.VAT InputScale: 2 OutputScale: 0
            //       BOOKINGS.BOOKING_CHARGE InputScale: 2 OutputScale: 0
            //       BOOKINGS.DEPOSIT InputScale: 2 OutputScale: 0
            //       BOOKINGS.TERM_SURCHARGEPER InputScale: 2 OutputScale: 0
            //       BOOKINGS.VAT InputScale: 2 OutputScale: 0
            //       COLOUR_RATES.COLOUR_RATE InputScale: 4 OutputScale: 0
            //       INVESTMENTS.TERM_SURCHARGEPER InputScale: 2 OutputScale: 0
            //       PURCHASE_DEBTS.CC_SURCHARGE InputScale: 2 OutputScale: 0
            //       PURCHASE_DEBTS.CC_VAT InputScale: 2 OutputScale: 0
            //       PURCHASE_DEBTS.DEBT_AMOUNT InputScale: 2 OutputScale: 0
            //       PURCHASE_DEBTS.NOTIONAL_VAT InputScale: 2 OutputScale: 0
            //       PURCHASE_DEBTS.PP1_SURCHARGE InputScale: 2 OutputScale: 0
            //       PURCHASE_DEBTS.PP1_VAT InputScale: 2 OutputScale: 0
            //       PURCHASE_DEBTS.PP2_SURCHARGE InputScale: 2 OutputScale: 0
            //       PURCHASE_DEBTS.PP2_VAT InputScale: 2 OutputScale: 0
            //       PURCHASE_DEBTS.TERM_SURCHARGE InputScale: 2 OutputScale: 0
            //       PURCHASE_DEBTS.TERM_VAT InputScale: 2 OutputScale: 0
            //       PURCHASE_DEBTS.TOTAL_DEBT InputScale: 2 OutputScale: 0
            //       PURCHASE_DEBTS.TOTAL_VAT InputScale: 2 OutputScale: 0
            //       PURCHASE_DEBTS.VAT InputScale: 2 OutputScale: 0
            //       UCHARGE_DEBTS.CC_SURCHARGE InputScale: 2 OutputScale: 0
            //       UCHARGE_DEBTS.CC_VAT InputScale: 2 OutputScale: 0
            //       UCHARGE_DEBTS.DEBT_AMOUNT InputScale: 2 OutputScale: 0
            //       UCHARGE_DEBTS.NOTIONAL_VAT InputScale: 2 OutputScale: 0
            //       UCHARGE_DEBTS.PP1_SURCHARGE InputScale: 2 OutputScale: 0
            //       UCHARGE_DEBTS.PP1_VAT InputScale: 2 OutputScale: 0
            //       UCHARGE_DEBTS.PP2_SURCHARGE InputScale: 2 OutputScale: 0
            //       UCHARGE_DEBTS.PP2_VAT InputScale: 2 OutputScale: 0
            //       UCHARGE_DEBTS.TERM_SURCHARGE InputScale: 2 OutputScale: 0
            //       UCHARGE_DEBTS.TERM_VAT InputScale: 2 OutputScale: 0
            //       UCHARGE_DEBTS.TOTAL_DEBT InputScale: 2 OutputScale: 0
            //       UCHARGE_DEBTS.TOTAL_VAT InputScale: 2 OutputScale: 0
            //       UCHARGE_DEBTS.VAT InputScale: 2 OutputScale: 0


        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            T_SCREEN_NAME = new CoreCharacter("T_SCREEN_NAME", 20, this, ResetTypes.ResetAtStartup, "confirm.qks");
            T_CONFIRM_REF = new CoreCharacter("T_CONFIRM_REF", 8, this, Common.cEmptyString);
            T_INSTANT_CONF = new CoreCharacter("T_INSTANT_CONF", 1, this, Common.cEmptyString);
            T_INSTANT_DELETE = new CoreCharacter("T_INSTANT_DELETE", 1, this, Common.cEmptyString);
            T_BOOKING_REF = new CoreCharacter("T_BOOKING_REF", 8, this, Common.cEmptyString);
            T_WEBBKNGS_REF = new CoreCharacter("T_WEBBKNGS_REF", 8, this, Common.cEmptyString);
            fleBOOKINGS = new OracleFileObject(this, FileTypes.Primary, 0, "INDEXED", "BOOKINGS", "", true, false, false, 1, "m_trnTRANS_UPDATE");
            flePROPERTIES = new OracleFileObject(this, FileTypes.Secondary, 0, "INDEXED", "PROPERTIES", "", true, false, true, 0, "m_trnTRANS_UPDATE");
            fleCOLOUR_RATES = new OracleFileObject(this, FileTypes.Reference, 0, "INDEXED", "COLOUR_RATES", "", false, false, false, 0, "m_cnnQUERY");
            fleINVESTMENTS = new OracleFileObject(this, FileTypes.Secondary, 0, "INDEXED", "INVESTMENTS", "", true, false, true, 0, "m_trnTRANS_UPDATE");
            fleLOCATIONS = new OracleFileObject(this, FileTypes.Reference, 0, "INDEXED", "LOCATIONS", "", false, false, false, 0, "m_cnnQUERY");
            fleCURRENT_ENTS = new OracleFileObject(this, FileTypes.Secondary, 0, "INDEXED", "CURRENT_ENTS", "", true, false, false, 0, "m_trnTRANS_UPDATE");
            flePREVIOUS_ENT = new OracleFileObject(this, FileTypes.Secondary, 0, "INDEXED", "CURRENT_ENTS", "PREVIOUS_ENT", true, false, false, 0, "m_trnTRANS_UPDATE");
            fleFOLLOWING_ENT = new OracleFileObject(this, FileTypes.Secondary, 0, "INDEXED", "CURRENT_ENTS", "FOLLOWING_ENT", true, false, false, 0, "m_trnTRANS_UPDATE");
            fleSUSP_ACCOUNT = new OracleFileObject(this, FileTypes.Secondary, 0, "INDEXED", "SUSP_ACCOUNT", "", true, false, false, 0, "m_trnTRANS_UPDATE");
            fleFORF_ACCOUNT = new OracleFileObject(this, FileTypes.Secondary, 0, "INDEXED", "FORF_ACCOUNT", "", true, false, false, 0, "m_trnTRANS_UPDATE");
            fleANNUAL_ENT = new OracleFileObject(this, FileTypes.Secondary, 0, "INDEXED", "ANNUAL_ENT", "", true, false, false, 0, "m_trnTRANS_UPDATE");
            fleM_INVESTORS = new OracleFileObject(this, FileTypes.Secondary, 0, "INDEXED", "M_INVESTORS", "", true, false, false, 0, "m_trnTRANS_UPDATE");
            fleUCHARGE_DEBTS = new OracleFileObject(this, FileTypes.Designer, 0, "INDEXED", "BOOKING_DEBTS", "UCHARGE_DEBTS", true, false, false, 0, "m_trnTRANS_UPDATE");
            flePURCHASE_DEBTS = new OracleFileObject(this, FileTypes.Designer, 0, "INDEXED", "BOOKING_DEBTS", "PURCHASE_DEBTS", true, false, false, 0, "m_trnTRANS_UPDATE");
            fleBALANCE_DEBTS = new OracleFileObject(this, FileTypes.Designer, 0, "INDEXED", "BOOKING_DEBTS", "BALANCE_DEBTS", true, false, false, 0, "m_trnTRANS_UPDATE");
            fleBOOKING_DETAIL = new OracleFileObject(this, FileTypes.Secondary, 0, "INDEXED", "BOOKING_DETAIL", "", true, false, false, 0, "m_trnTRANS_UPDATE");
            fleEMAILS = new OracleFileObject(this, FileTypes.Reference, 0, "INDEXED", "EMAILS", "", false, false, false, 0, "m_cnnQUERY");
            fleCORR_ADDRESS = new OracleFileObject(this, FileTypes.Reference, 0, "INDEXED", "CORR_ADDRESS", "", false, false, false, 0, "m_cnnQUERY");
            T_PURC_AMT = new CoreInteger("T_PURC_AMT", 9, this, 0m);
            T_DEP_AMT = new CoreInteger("T_DEP_AMT", 9, this, 0m);
            T_UCHG_AMT = new CoreInteger("T_UCHG_AMT", 9, this, 0m);
            T_PURC_CC_SUR = new CoreInteger("T_PURC_CC_SUR", 9, this, 0m);
            T_DEP_CC_SUR = new CoreInteger("T_DEP_CC_SUR", 9, this, 0m);
            T_UCHG_CC_SUR = new CoreInteger("T_UCHG_CC_SUR", 9, this, 0m);
            T_CARD_CC_SURPER = new CoreDecimal("T_CARD_CC_SURPER", 9, this, 0m);
            T_PAID_OK = new CoreCharacter("T_PAID_OK", 1, this, "N");
            T_HPB_CODE = new CoreCharacter("T_HPB_CODE", 4, this, "UCHG");
            T_PAY_PURC_PTS = new CoreCharacter("T_PAY_PURC_PTS", 1, this, "N");
            T_PAY_DEPOSIT = new CoreCharacter("T_PAY_DEPOSIT", 1, this, "N");
            T_PAY_USER_CHG = new CoreCharacter("T_PAY_USER_CHG", 1, this, "N");
            T_PAYMENT_METHOD = new CoreCharacter("T_PAYMENT_METHOD", 2, this, " ");
            T_BOOK_REF = new CoreCharacter("T_BOOK_REF", 8, this, " ");
            T_REASON = new CoreCharacter("T_REASON", 60, this, " ");
            T_TAKE_PAYMENT = new CoreCharacter("T_TAKE_PAYMENT", 1, this, " ");
            T_PAYMENT_TYPE = new CoreCharacter("T_PAYMENT_TYPE", 2, this, " ");
            T_BALANCE_DEBTS = new CoreCharacter("T_BALANCE_DEBTS", 1, this, "N");
            T_START_PERIOD = new CoreDecimal("T_START_PERIOD", 2, this);
            T_END_PERIOD = new CoreDecimal("T_END_PERIOD", 2, this);
            T_MAX_ENT_ERROR = new CoreCharacter("T_MAX_ENT_ERROR", 1, this, "N");
            T_POINTS_ALLOCATED = new CoreCharacter("T_POINTS_ALLOCATED", 1, this, "N");
            T_FINAL_CHECKS_DONE = new CoreCharacter("T_FINAL_CHECKS_DONE", 1, this, "N");
            T_PASS_NAME = new CoreCharacter("T_PASS_NAME", 30, this, " ");
            T_PASS_CARDNO = new CoreCharacter("T_PASS_CARDNO", 20, this, " ");
            T_PASS_ISSUE = new CoreCharacter("T_PASS_ISSUE", 2, this, " ");
            T_PASS_VFROM = new CoreCharacter("T_PASS_VFROM", 8, this, " ");
            T_PASS_EXPDATE = new CoreCharacter("T_PASS_EXPDATE", 8, this, " ");
            T_PASS_SEC = new CoreCharacter("T_PASS_SEC", 3, this, " ");
            T_START_WEEK = new CoreCharacter("T_START_WEEK", 2, this, Common.cEmptyString);
            T_END_WEEK = new CoreCharacter("T_END_WEEK", 2, this, Common.cEmptyString);
            T_PROPERTY_YEAR = new CoreCharacter("T_PROPERTY_YEAR", 14, this, Common.cEmptyString);
            T_ERROR_FLAG = new CoreCharacter("T_ERROR_FLAG", 1, this, Common.cEmptyString);
            T_UPDATE_LINKED = new CoreCharacter("T_UPDATE_LINKED", 1, this, "Y");
            T_CALLING_SCREEN = new CoreCharacter("T_CALLING_SCREEN", 8, this, Common.cEmptyString);
            T_EMAIL = new CoreCharacter("T_EMAIL", 1, this, "N");
            T_CORR_EXISTS = new CoreCharacter("T_CORR_EXISTS", 1, this, " ");
            T_CORR_EMAIL = new CoreCharacter("T_CORR_EMAIL", 1, this, "N");
            T_RECORD_STATUS = new CoreCharacter("T_RECORD_STATUS", 2, this, "CF");
            fleTRANS_HEADER = new OracleFileObject(this, FileTypes.Designer, 0, "INDEXED", "TRANS_HEADER", "", true, false, false, 0, "m_trnTRANS_UPDATE");
            fleBOOKING_TRANS = new OracleFileObject(this, FileTypes.Designer, 0, "INDEXED", "INVESTOR_TRANS", "BOOKING_TRANS", true, false, false, 0, "m_trnTRANS_UPDATE");
            fleFORFACCT_TRANS = new OracleFileObject(this, FileTypes.Designer, 0, "INDEXED", "INVESTOR_TRANS", "FORFACCT_TRANS", true, false, false, 0, "m_trnTRANS_UPDATE");
            fleSUSP_TRANS = new OracleFileObject(this, FileTypes.Designer, 0, "INDEXED", "INVESTOR_TRANS", "SUSP_TRANS", true, false, false, 0, "m_trnTRANS_UPDATE");
            flePREVIOUS_TRANS = new OracleFileObject(this, FileTypes.Designer, 0, "INDEXED", "INVESTOR_TRANS", "PREVIOUS_TRANS", true, false, false, 0, "m_trnTRANS_UPDATE");
            fleFOLLOWING_TRANS = new OracleFileObject(this, FileTypes.Designer, 0, "INDEXED", "INVESTOR_TRANS", "FOLLOWING_TRANS", true, false, false, 0, "m_trnTRANS_UPDATE");
            fleBOOKING_LETTERS = new OracleFileObject(this, FileTypes.Designer, 0, "INDEXED", "BOOKING_LETTERS", "", true, false, false,0, "m_trnTRANS_UPDATE");
            flePROV_LETTERS = new OracleFileObject(this, FileTypes.Designer, 0, "INDEXED", "BOOKING_LETTERS", "PROV_LETTERS", true, false, false, 0, "m_trnTRANS_UPDATE");
            fleBOOKING_PERIODS = new OracleFileObject(this, FileTypes.Secondary, 0, "INDEXED", "BOOKING_PERIODS", "", true, false, true, 0, "m_trnTRANS_UPDATE");
            fleBOOKING_PERIODS_DTL = new OracleFileObject(this, FileTypes.Designer, 53, "INDEXED", "BOOKING_PERIOD_DTL", "", true, false, true, 0, "m_trnTRANS_UPDATE");
            flePROPERTY_YEARS = new OracleFileObject(this, FileTypes.Secondary, 0, "INDEXED", "PROPERTY_YEARS", "", true, false, true, 0, "m_trnTRANS_UPDATE");
            flePROPERTY_YEARS_DTL = new OracleFileObject(this, FileTypes.Designer, 53, "INDEXED", "PROPERTY_YEARS_DTL", "", true, false, true, 0, "m_trnTRANS_UPDATE");
            fleUSER_SEC_FILE = new OracleFileObject(this, FileTypes.Secondary, 0, "INDEXED", "USER_SEC_FILE", "", true, false, false, 0, "m_trnTRANS_UPDATE");
            fleCANCEL_BOOKING = new OracleFileObject(this, FileTypes.Designer, 0, "INDEXED", "D_CANCEL_BOOKING", "", true, false, false, 0, "m_trnTRANS_UPDATE");
            fleFLIGHT_REQUEST = new OracleFileObject(this, FileTypes.Designer, 0, "INDEXED", "FLIGHT_REQUEST", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            T_CHARGE_PAID = new CoreCharacter("T_CHARGE_PAID", 1, this, "N");
            T_OLD_CHARGE_PAID = new CoreCharacter("T_OLD_CHARGE_PAID", 1, this, "N");
            T_PDQD = new CoreCharacter("T_PDQD", 1, this, "N");
            T_BOOK_BAL = new CoreInteger("T_BOOK_BAL", 8, this);
            T_EXTRA_POINTS = new CoreCharacter("T_EXTRA_POINTS", 1, this, Common.cEmptyString);
            T_ADDON_POINTS = new CoreCharacter("T_ADDON_POINTS", 1, this, Common.cEmptyString);
            T_PURCH_POINTS = new CoreCharacter("T_PURCH_POINTS", 1, this, Common.cEmptyString);
            T_INITIAL_STATUS = new CoreCharacter("T_INITIAL_STATUS", 2, this, Common.cEmptyString);
            T_INVESTOR = new CoreCharacter("T_INVESTOR", 8, this, Common.cEmptyString);
            T_UPDATE_FLAG = new CoreCharacter("T_UPDATE_FLAG", 1, this, Common.cEmptyString);
            T_DEFERRED_FLAG = new CoreCharacter("T_DEFERRED_FLAG", 1, this, "N");
            T_START_DATE = new CoreDate("T_START_DATE", this);
            T_START_DAYS = new CoreInteger("T_START_DAYS", 8, this);
            T_PASS_LOCATION = new CoreCharacter("T_PASS_LOCATION", 2, this, Common.cEmptyString);
            T_PASS_INVESTOR = new CoreCharacter("T_PASS_INVESTOR", 8, this, Common.cEmptyString);
            T_PASS_SCREEN = new CoreCharacter("T_PASS_SCREEN", 4, this, Common.cEmptyString);
            T_PASS_DATE = new CoreDate("T_PASS_DATE", this);
            T_END_DATE = new CoreDate("T_END_DATE", this);
            T_SET_BALS = new CoreInteger("T_SET_BALS", 8, this);
            T_DELETE = new CoreCharacter("T_DELETE", 1, this, Common.cEmptyString);
            T_NEW_BOOKING = new CoreCharacter("T_NEW_BOOKING", 1, this, Common.cEmptyString);
            T_OK = new CoreCharacter("T_OK", 1, this, Common.cEmptyString);
            T_WEB_BOOKING = new CoreCharacter("T_WEB_BOOKING", 1, this, Common.cEmptyString);
            T_CC_CHARGED = new CoreCharacter("T_CC_CHARGED", 1, this, "N");

            flePROPERTIES.Access += flePROPERTIES_Access;
            fleCOLOUR_RATES.Access += fleCOLOUR_RATES_Access;
            fleINVESTMENTS.Access += fleINVESTMENTS_Access;
            fleLOCATIONS.Access += fleLOCATIONS_Access;
            fleCURRENT_ENTS.Access += fleCURRENT_ENTS_Access;
            D_PREV_YEAR.GetValue += D_PREV_YEAR_GetValue;
            flePREVIOUS_ENT.Access += flePREVIOUS_ENT_Access;
            D_FOLLOWING_YEAR.GetValue += D_FOLLOWING_YEAR_GetValue;
            fleFOLLOWING_ENT.Access += fleFOLLOWING_ENT_Access;
            fleSUSP_ACCOUNT.Access += fleSUSP_ACCOUNT_Access;
            fleFORF_ACCOUNT.Access += fleFORF_ACCOUNT_Access;
            fleANNUAL_ENT.Access += fleANNUAL_ENT_Access;
            fleM_INVESTORS.Access += fleM_INVESTORS_Access;
            fleUCHARGE_DEBTS.Access += fleUCHARGE_DEBTS_Access;
            flePURCHASE_DEBTS.Access += flePURCHASE_DEBTS_Access;
            fleBALANCE_DEBTS.Access += fleBALANCE_DEBTS_Access;
            fleBOOKING_DETAIL.Access += fleBOOKING_DETAIL_Access;
            fleEMAILS.Access += fleEMAILS_Access;
            fleCORR_ADDRESS.Access += fleCORR_ADDRESS_Access;
            D_BOOKING_START.GetValue += D_BOOKING_START_GetValue;
            D_BOOKING_END.GetValue += D_BOOKING_END_GetValue;
            D_LOCATION.GetValue += D_LOCATION_GetValue;
            D_LINE_DESCRIPTION.GetValue += D_LINE_DESCRIPTION_GetValue;
            D_PURCHASE_DESC.GetValue += D_PURCHASE_DESC_GetValue;
            D_LINE_LOCATION.GetValue += D_LINE_LOCATION_GetValue;
            D_LINE_DURATION.GetValue += D_LINE_DURATION_GetValue;
            D_BOOKING_LINE.GetValue += D_BOOKING_LINE_GetValue;
            D_CURR_TRANS_LINE.GetValue += D_CURR_TRANS_LINE_GetValue;
            D_TRANS_LINE.GetValue += D_TRANS_LINE_GetValue;
            D_NET_BOOKING.GetValue += D_NET_BOOKING_GetValue;
            D_FULL_CHARGE.GetValue += D_FULL_CHARGE_GetValue;
            D_DEPOSIT.GetValue += D_DEPOSIT_GetValue;
            flePROV_LETTERS.Access += flePROV_LETTERS_Access;
            fleBOOKING_PERIODS.Access += fleBOOKING_PERIODS_Access;
            flePROPERTY_YEARS.Access += flePROPERTY_YEARS_Access;
            fleUSER_SEC_FILE.Access += fleUSER_SEC_FILE_Access;
            fleFLIGHT_REQUEST.Access += fleFLIGHT_REQUEST_Access;
            D_PP_CHARGES.GetValue += D_PP_CHARGES_GetValue;
            D_TOTAL_CHARGE.GetValue += D_TOTAL_CHARGE_GetValue;
            D_DAY_2.GetValue += D_DAY_2_GetValue;
            D_DAY_3.GetValue += D_DAY_3_GetValue;
            D_DAY_4.GetValue += D_DAY_4_GetValue;
            D_DAY_5.GetValue += D_DAY_5_GetValue;
            D_DAY_6.GetValue += D_DAY_6_GetValue;
            D_DAY_7.GetValue += D_DAY_7_GetValue;
            D_DAY_STATUS_1.GetValue += D_DAY_STATUS_1_GetValue;
            D_DAY_STATUS_2.GetValue += D_DAY_STATUS_2_GetValue;
            D_DAY_STATUS_3.GetValue += D_DAY_STATUS_3_GetValue;
            D_DAY_STATUS_4.GetValue += D_DAY_STATUS_4_GetValue;
            D_DAY_STATUS_5.GetValue += D_DAY_STATUS_5_GetValue;
            D_DAY_STATUS_6.GetValue += D_DAY_STATUS_6_GetValue;
            D_DAY_STATUS_7.GetValue += D_DAY_STATUS_7_GetValue;
            D_DEL_STATUS_1.GetValue += D_DEL_STATUS_1_GetValue;
            D_DEL_STATUS_2.GetValue += D_DEL_STATUS_2_GetValue;
            D_DEL_STATUS_3.GetValue += D_DEL_STATUS_3_GetValue;
            D_DEL_STATUS_4.GetValue += D_DEL_STATUS_4_GetValue;
            D_DEL_STATUS_5.GetValue += D_DEL_STATUS_5_GetValue;
            D_DEL_STATUS_6.GetValue += D_DEL_STATUS_6_GetValue;
            D_DEL_STATUS_7.GetValue += D_DEL_STATUS_7_GetValue;
            D_BK_ENT.GetValue += D_BK_ENT_GetValue;
            D_BK_ENT_TOT.GetValue += D_BK_ENT_TOT_GetValue;
            D_BK_ENT_DISP.GetValue += D_BK_ENT_DISP_GetValue;
            D_ENT_TOT.GetValue += D_ENT_TOT_GetValue;
            D_OD_1OR2.GetValue += D_OD_1OR2_GetValue;
            D_OD_3.GetValue += D_OD_3_GetValue;
            D_ALLOWED_OD.GetValue += D_ALLOWED_OD_GetValue;
            D_FORF_MAX.GetValue += D_FORF_MAX_GetValue;
            D_ENT_MAX_TOT.GetValue += D_ENT_MAX_TOT_GetValue;
            D_BK_FORF_ALLOC.GetValue += D_BK_FORF_ALLOC_GetValue;
            D_BK_SUSPENSE_ALLOC.GetValue += D_BK_SUSPENSE_ALLOC_GetValue;
            D_ENT_ALLOC_TOT.GetValue += D_ENT_ALLOC_TOT_GetValue;
            D_PAY_TIME.GetValue += D_PAY_TIME_GetValue;
            D_CURRENT_DATE.GetValue += D_CURRENT_DATE_GetValue;
            D_USER_CHARGE.GetValue += D_USER_CHARGE_GetValue;
            D_USER_CHG_AMT.GetValue += D_USER_CHG_AMT_GetValue;
            D_PURC_AMT.GetValue += D_PURC_AMT_GetValue;
            D_DEPOSIT_AMT.GetValue += D_DEPOSIT_AMT_GetValue;
            D_TOT_CARD_AMT.GetValue += D_TOT_CARD_AMT_GetValue;
            D_PASS_PURC.GetValue += D_PASS_PURC_GetValue;
            D_PASS_DEPOSIT.GetValue += D_PASS_DEPOSIT_GetValue;
            D_PASS_USER_CHG.GetValue += D_PASS_USER_CHG_GetValue;
            D_PURC_REASON.GetValue += D_PURC_REASON_GetValue;
            D_DEP_REASON.GetValue += D_DEP_REASON_GetValue;
            D_UCHG_REASON.GetValue += D_UCHG_REASON_GetValue;
            D_PAYMENT_TYPE.GetValue += D_PAYMENT_TYPE_GetValue;
            D_CC_SURCHARGEPER.GetValue += D_CC_SURCHARGEPER_GetValue;
            D_CC_SURCHARGE_INFO.GetValue += D_CC_SURCHARGE_INFO_GetValue;
            D_SENDTO.GetValue += D_SENDTO_GetValue;
            D_SENDTOSTORE.GetValue += D_SENDTOSTORE_GetValue;
            flePURCHASE_DEBTS.SelectIf += flePURCHASE_DEBTS_SelectIf;
            fleBOOKINGS.SetItemFinals += fleBOOKINGS_SetItemFinals;
            fleM_INVESTORS.SetItemFinals += fleM_INVESTORS_SetItemFinals;
            fleUCHARGE_DEBTS.SetItemFinals += fleUCHARGE_DEBTS_SetItemFinals;
            flePURCHASE_DEBTS.SetItemFinals += flePURCHASE_DEBTS_SetItemFinals;
            fleBALANCE_DEBTS.SetItemFinals += fleBALANCE_DEBTS_SetItemFinals;
            fleBOOKING_DETAIL.SetItemFinals += fleBOOKING_DETAIL_SetItemFinals;
            fleTRANS_HEADER.SetItemFinals += fleTRANS_HEADER_SetItemFinals;
            fleBOOKING_TRANS.SetItemFinals += fleBOOKING_TRANS_SetItemFinals;
            fleFORFACCT_TRANS.SetItemFinals += fleFORFACCT_TRANS_SetItemFinals;
            fleSUSP_TRANS.SetItemFinals += fleSUSP_TRANS_SetItemFinals;
            flePREVIOUS_TRANS.SetItemFinals += flePREVIOUS_TRANS_SetItemFinals;
            fleFOLLOWING_TRANS.SetItemFinals += fleFOLLOWING_TRANS_SetItemFinals;
            fleBOOKING_LETTERS.SetItemFinals += fleBOOKING_LETTERS_SetItemFinals;
            flePREVIOUS_ENT.AccessIsOptional = true;
            fleFOLLOWING_ENT.AccessIsOptional = true;
            fleSUSP_ACCOUNT.AccessIsOptional = true;
            fleFORF_ACCOUNT.AccessIsOptional = true;
            fleUCHARGE_DEBTS.AccessIsOptional = true;
            flePURCHASE_DEBTS.AccessIsOptional = true;
            fleBALANCE_DEBTS.AccessIsOptional = true;
            fleBOOKING_DETAIL.AccessIsOptional = true;
            fleEMAILS.AccessIsOptional = true;
            fleCORR_ADDRESS.AccessIsOptional = true;
            fleFLIGHT_REQUEST.AccessIsOptional = true;
            

        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;
            flePROPERTIES.Access -= flePROPERTIES_Access;
            fleCOLOUR_RATES.Access -= fleCOLOUR_RATES_Access;
            fleINVESTMENTS.Access -= fleINVESTMENTS_Access;
            fleLOCATIONS.Access -= fleLOCATIONS_Access;
            fleCURRENT_ENTS.Access -= fleCURRENT_ENTS_Access;
            D_PREV_YEAR.GetValue -= D_PREV_YEAR_GetValue;
            flePREVIOUS_ENT.Access -= flePREVIOUS_ENT_Access;
            D_FOLLOWING_YEAR.GetValue -= D_FOLLOWING_YEAR_GetValue;
            fleFOLLOWING_ENT.Access -= fleFOLLOWING_ENT_Access;
            fleSUSP_ACCOUNT.Access -= fleSUSP_ACCOUNT_Access;
            fleFORF_ACCOUNT.Access -= fleFORF_ACCOUNT_Access;
            fleANNUAL_ENT.Access -= fleANNUAL_ENT_Access;
            fleM_INVESTORS.Access -= fleM_INVESTORS_Access;
            fleUCHARGE_DEBTS.Access -= fleUCHARGE_DEBTS_Access;
            flePURCHASE_DEBTS.Access -= flePURCHASE_DEBTS_Access;
            fleBALANCE_DEBTS.Access -= fleBALANCE_DEBTS_Access;
            fleBOOKING_DETAIL.Access -= fleBOOKING_DETAIL_Access;
            fleEMAILS.Access -= fleEMAILS_Access;
            fleCORR_ADDRESS.Access -= fleCORR_ADDRESS_Access;
            D_BOOKING_START.GetValue -= D_BOOKING_START_GetValue;
            D_BOOKING_END.GetValue -= D_BOOKING_END_GetValue;
            D_LOCATION.GetValue -= D_LOCATION_GetValue;
            D_LINE_DESCRIPTION.GetValue -= D_LINE_DESCRIPTION_GetValue;
            D_PURCHASE_DESC.GetValue -= D_PURCHASE_DESC_GetValue;
            D_LINE_LOCATION.GetValue -= D_LINE_LOCATION_GetValue;
            D_LINE_DURATION.GetValue -= D_LINE_DURATION_GetValue;
            D_BOOKING_LINE.GetValue -= D_BOOKING_LINE_GetValue;
            D_CURR_TRANS_LINE.GetValue -= D_CURR_TRANS_LINE_GetValue;
            D_TRANS_LINE.GetValue -= D_TRANS_LINE_GetValue;
            D_NET_BOOKING.GetValue -= D_NET_BOOKING_GetValue;
            D_FULL_CHARGE.GetValue -= D_FULL_CHARGE_GetValue;
            D_DEPOSIT.GetValue -= D_DEPOSIT_GetValue;
            flePROV_LETTERS.Access -= flePROV_LETTERS_Access;
            fleBOOKING_PERIODS.Access -= fleBOOKING_PERIODS_Access;
            flePROPERTY_YEARS.Access -= flePROPERTY_YEARS_Access;
            fleUSER_SEC_FILE.Access -= fleUSER_SEC_FILE_Access;
            fleFLIGHT_REQUEST.Access -= fleFLIGHT_REQUEST_Access;
            D_PP_CHARGES.GetValue -= D_PP_CHARGES_GetValue;
            D_TOTAL_CHARGE.GetValue -= D_TOTAL_CHARGE_GetValue;
            D_DAY_2.GetValue -= D_DAY_2_GetValue;
            D_DAY_3.GetValue -= D_DAY_3_GetValue;
            D_DAY_4.GetValue -= D_DAY_4_GetValue;
            D_DAY_5.GetValue -= D_DAY_5_GetValue;
            D_DAY_6.GetValue -= D_DAY_6_GetValue;
            D_DAY_7.GetValue -= D_DAY_7_GetValue;
            D_DAY_STATUS_1.GetValue -= D_DAY_STATUS_1_GetValue;
            D_DAY_STATUS_2.GetValue -= D_DAY_STATUS_2_GetValue;
            D_DAY_STATUS_3.GetValue -= D_DAY_STATUS_3_GetValue;
            D_DAY_STATUS_4.GetValue -= D_DAY_STATUS_4_GetValue;
            D_DAY_STATUS_5.GetValue -= D_DAY_STATUS_5_GetValue;
            D_DAY_STATUS_6.GetValue -= D_DAY_STATUS_6_GetValue;
            D_DAY_STATUS_7.GetValue -= D_DAY_STATUS_7_GetValue;
            D_DEL_STATUS_1.GetValue -= D_DEL_STATUS_1_GetValue;
            D_DEL_STATUS_2.GetValue -= D_DEL_STATUS_2_GetValue;
            D_DEL_STATUS_3.GetValue -= D_DEL_STATUS_3_GetValue;
            D_DEL_STATUS_4.GetValue -= D_DEL_STATUS_4_GetValue;
            D_DEL_STATUS_5.GetValue -= D_DEL_STATUS_5_GetValue;
            D_DEL_STATUS_6.GetValue -= D_DEL_STATUS_6_GetValue;
            D_DEL_STATUS_7.GetValue -= D_DEL_STATUS_7_GetValue;
            D_BK_ENT.GetValue -= D_BK_ENT_GetValue;
            D_BK_ENT_TOT.GetValue -= D_BK_ENT_TOT_GetValue;
            D_BK_ENT_DISP.GetValue -= D_BK_ENT_DISP_GetValue;
            D_ENT_TOT.GetValue -= D_ENT_TOT_GetValue;
            D_OD_1OR2.GetValue -= D_OD_1OR2_GetValue;
            D_OD_3.GetValue -= D_OD_3_GetValue;
            D_ALLOWED_OD.GetValue -= D_ALLOWED_OD_GetValue;
            D_FORF_MAX.GetValue -= D_FORF_MAX_GetValue;
            D_ENT_MAX_TOT.GetValue -= D_ENT_MAX_TOT_GetValue;
            D_BK_FORF_ALLOC.GetValue -= D_BK_FORF_ALLOC_GetValue;
            D_BK_SUSPENSE_ALLOC.GetValue -= D_BK_SUSPENSE_ALLOC_GetValue;
            D_ENT_ALLOC_TOT.GetValue -= D_ENT_ALLOC_TOT_GetValue;
            D_PAY_TIME.GetValue -= D_PAY_TIME_GetValue;
            D_CURRENT_DATE.GetValue -= D_CURRENT_DATE_GetValue;
            D_USER_CHARGE.GetValue -= D_USER_CHARGE_GetValue;
            D_USER_CHG_AMT.GetValue -= D_USER_CHG_AMT_GetValue;
            D_PURC_AMT.GetValue -= D_PURC_AMT_GetValue;
            D_DEPOSIT_AMT.GetValue -= D_DEPOSIT_AMT_GetValue;
            D_TOT_CARD_AMT.GetValue -= D_TOT_CARD_AMT_GetValue;
            D_PASS_PURC.GetValue -= D_PASS_PURC_GetValue;
            D_PASS_DEPOSIT.GetValue -= D_PASS_DEPOSIT_GetValue;
            D_PASS_USER_CHG.GetValue -= D_PASS_USER_CHG_GetValue;
            D_PURC_REASON.GetValue -= D_PURC_REASON_GetValue;
            D_DEP_REASON.GetValue -= D_DEP_REASON_GetValue;
            D_UCHG_REASON.GetValue -= D_UCHG_REASON_GetValue;
            D_PAYMENT_TYPE.GetValue -= D_PAYMENT_TYPE_GetValue;
            D_CC_SURCHARGEPER.GetValue -= D_CC_SURCHARGEPER_GetValue;
            D_CC_SURCHARGE_INFO.GetValue -= D_CC_SURCHARGE_INFO_GetValue;
            D_SENDTO.GetValue -= D_SENDTO_GetValue;
            D_SENDTOSTORE.GetValue -= D_SENDTOSTORE_GetValue;
            fldBOOKINGS_LOCATION.LookupOn -= fldBOOKINGS_LOCATION_LookupOn;
            fldBOOKINGS_INVESTOR.Input -= fldBOOKINGS_INVESTOR_Input;
            fldBOOKINGS_BOOKING_STATUS.Edit -= fldBOOKINGS_BOOKING_STATUS_Edit;
            fldT_CHARGE_PAID.Input -= fldT_CHARGE_PAID_Input;
            fldT_CHARGE_PAID.Edit -= fldT_CHARGE_PAID_Edit;
            fldT_PAYMENT_METHOD.Input -= fldT_PAYMENT_METHOD_Input;
            flePURCHASE_DEBTS.SelectIf -= flePURCHASE_DEBTS_SelectIf;
            dsrDesigner_01.Click -= dsrDesigner_01_Click;
            dsrDesigner_X.Click -= dsrDesigner_X_Click;
            dsrDesigner_WAIT.Click -= dsrDesigner_WAIT_Click;
            dsrDesigner_CF.Click -= dsrDesigner_CF_Click;
            dsrDesigner_02.Click -= dsrDesigner_02_Click;
            dsrDesigner_CORE_USER.Click -= dsrDesigner_CORE_USER_Click;
            fleBOOKINGS.SetItemFinals += fleBOOKINGS_SetItemFinals;
            fleM_INVESTORS.SetItemFinals += fleM_INVESTORS_SetItemFinals;
            fleUCHARGE_DEBTS.SetItemFinals += fleUCHARGE_DEBTS_SetItemFinals;
            flePURCHASE_DEBTS.SetItemFinals += flePURCHASE_DEBTS_SetItemFinals;
            fleBALANCE_DEBTS.SetItemFinals += fleBALANCE_DEBTS_SetItemFinals;
            fleBOOKING_DETAIL.SetItemFinals += fleBOOKING_DETAIL_SetItemFinals;
            fleTRANS_HEADER.SetItemFinals += fleTRANS_HEADER_SetItemFinals;
            fleBOOKING_TRANS.SetItemFinals += fleBOOKING_TRANS_SetItemFinals;
            fleFORFACCT_TRANS.SetItemFinals += fleFORFACCT_TRANS_SetItemFinals;
            fleSUSP_TRANS.SetItemFinals += fleSUSP_TRANS_SetItemFinals;
            flePREVIOUS_TRANS.SetItemFinals += flePREVIOUS_TRANS_SetItemFinals;
            fleFOLLOWING_TRANS.SetItemFinals += fleFOLLOWING_TRANS_SetItemFinals;
            fleBOOKING_LETTERS.SetItemFinals += fleBOOKING_LETTERS_SetItemFinals;

        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private OracleConnection m_cnnQUERY = new OracleConnection();
        private OracleConnection m_cnnTRANS_UPDATE = new OracleConnection();
        private OracleTransaction m_trnTRANS_UPDATE;
        private CoreCharacter T_SCREEN_NAME;
        private CoreCharacter T_CONFIRM_REF;
        private CoreCharacter T_INSTANT_CONF;
        private CoreCharacter T_INSTANT_DELETE;
        private CoreCharacter T_BOOKING_REF;
        private CoreCharacter T_WEBBKNGS_REF;
        private OracleFileObject fleBOOKINGS;

        private void fleBOOKINGS_SetItemFinals()
        {

           
                fleBOOKINGS.set_SetValue("CONFIRM_DATE", QDesign.SysDate(ref m_cnnQUERY));
                fleBOOKINGS.set_SetValue("CONFIRM_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);


          

        }

        private OracleFileObject flePROPERTIES;

        private void flePROPERTIES_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(flePROPERTIES.ElementOwner("LOCATION")).Append(" = ").Append(Common.StringToField((fleBOOKINGS.GetStringValue("LOCATION") + fleBOOKINGS.GetStringValue("BEDS") + fleBOOKINGS.GetStringValue("PROPERTY_STYLE") + fleBOOKINGS.GetStringValue("BATHROOMS") + fleBOOKINGS.GetStringValue("PROPERTY_ID")).PadRight(10).Substring(0, 2)));
                //Parent:PROPERTY_CODE    'Parent:PROPERTY_CODE
                strText.Append(" AND ").Append(flePROPERTIES.ElementOwner("BEDS")).Append(" = ").Append(Common.StringToField((fleBOOKINGS.GetStringValue("LOCATION") + fleBOOKINGS.GetStringValue("BEDS") + fleBOOKINGS.GetStringValue("PROPERTY_STYLE") + fleBOOKINGS.GetStringValue("BATHROOMS") + fleBOOKINGS.GetStringValue("PROPERTY_ID")).PadRight(10).Substring(2, 1)));
                //Parent:PROPERTY_CODE    'Parent:PROPERTY_CODE
                strText.Append(" AND ").Append(flePROPERTIES.ElementOwner("PROPERTY_STYLE")).Append(" = ").Append(Common.StringToField((fleBOOKINGS.GetStringValue("LOCATION") + fleBOOKINGS.GetStringValue("BEDS") + fleBOOKINGS.GetStringValue("PROPERTY_STYLE") + fleBOOKINGS.GetStringValue("BATHROOMS") + fleBOOKINGS.GetStringValue("PROPERTY_ID")).PadRight(10).Substring(3, 2)));
                //Parent:PROPERTY_CODE    'Parent:PROPERTY_CODE
                strText.Append(" AND ").Append(flePROPERTIES.ElementOwner("BATHROOMS")).Append(" = ").Append(Common.StringToField((fleBOOKINGS.GetStringValue("LOCATION") + fleBOOKINGS.GetStringValue("BEDS") + fleBOOKINGS.GetStringValue("PROPERTY_STYLE") + fleBOOKINGS.GetStringValue("BATHROOMS") + fleBOOKINGS.GetStringValue("PROPERTY_ID")).PadRight(10).Substring(5, 1)));
                //Parent:PROPERTY_CODE    'Parent:PROPERTY_CODE
                strText.Append(" AND ").Append(flePROPERTIES.ElementOwner("PROPERTY_ID")).Append(" = ").Append(Common.StringToField((fleBOOKINGS.GetStringValue("LOCATION") + fleBOOKINGS.GetStringValue("BEDS") + fleBOOKINGS.GetStringValue("PROPERTY_STYLE") + fleBOOKINGS.GetStringValue("BATHROOMS") + fleBOOKINGS.GetStringValue("PROPERTY_ID")).PadRight(10).Substring(6, 4)));
                //Parent:PROPERTY_CODE    'Parent:PROPERTY_CODE

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

        private OracleFileObject fleCOLOUR_RATES;

        private void fleCOLOUR_RATES_Access(ref string AccessClause)
        {


           
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleCOLOUR_RATES.ElementOwner("COLOUR_SCHEME")).Append(" = ").Append(Common.StringToField("V"));
                // TODO: Add BACKWARDS code

                AccessClause = strText.ToString();


           
        }

        private OracleFileObject fleINVESTMENTS;

        private void fleINVESTMENTS_Access(ref string AccessClause)
        {


           
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleINVESTMENTS.ElementOwner("INVESTOR")).Append(" = ").Append(Common.StringToField(fleBOOKINGS.GetStringValue("INVESTOR")));

                AccessClause = strText.ToString();


           

        }

        private OracleFileObject fleLOCATIONS;

        private void fleLOCATIONS_Access(ref string AccessClause)
        {


           
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleLOCATIONS.ElementOwner("LOCATION")).Append(" = ").Append(Common.StringToField(fleBOOKINGS.GetStringValue("LOCATION")));

                AccessClause = strText.ToString();


            

        }

        private OracleFileObject fleCURRENT_ENTS;

        private void fleCURRENT_ENTS_Access(ref string AccessClause)
        {


           
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleCURRENT_ENTS.ElementOwner("FILLER_8")).Append(" = ").Append(Common.StringToField(((fleBOOKINGS.GetStringValue("INVESTOR") + fleBOOKINGS.GetStringValue("ENT_YEAR"))).PadRight(12).Substring(0, 8)));
                //Parent:INVESTOR_YEAR
                strText.Append(" AND ").Append(fleCURRENT_ENTS.ElementOwner("YEAR")).Append(" = ").Append(Common.StringToField(((fleBOOKINGS.GetStringValue("INVESTOR") + fleBOOKINGS.GetStringValue("ENT_YEAR"))).PadRight(12).Substring(8, 4)));
                //Parent:INVESTOR_YEAR

                AccessClause = strText.ToString();


           

        }

        private DCharacter D_PREV_YEAR = new DCharacter(4);
        private void D_PREV_YEAR_GetValue(ref string Value)
        {

            try
            {
                Value = QDesign.ASCII(QDesign.NConvert(fleBOOKINGS.GetStringValue("ENT_YEAR")) - 1);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private OracleFileObject flePREVIOUS_ENT;

        private void flePREVIOUS_ENT_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(flePREVIOUS_ENT.ElementOwner("FILLER_8")).Append(" = ").Append(Common.StringToField(((fleBOOKINGS.GetStringValue("INVESTOR") + D_PREV_YEAR.Value)).PadRight(12).Substring(0, 8)));
                //Parent:INVESTOR_YEAR
                strText.Append(" AND ").Append(flePREVIOUS_ENT.ElementOwner("YEAR")).Append(" = ").Append(Common.StringToField(((fleBOOKINGS.GetStringValue("INVESTOR") + D_PREV_YEAR.Value)).PadRight(12).Substring(8, 4)));
                //Parent:INVESTOR_YEAR

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



        private void flePREVIOUS_ENT_SelectIf(ref string SelectIfClause)
        {


            try
            {
                StringBuilder strSQL = new StringBuilder("");

                strSQL.Append(" (    ").Append(flePREVIOUS_ENT.ElementOwner("YEAR_123")).Append(" <>  '00')");
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

        private DCharacter D_FOLLOWING_YEAR = new DCharacter(4);
        private void D_FOLLOWING_YEAR_GetValue(ref string Value)
        {

            try
            {
                Value = QDesign.ASCII(QDesign.NConvert(fleBOOKINGS.GetStringValue("ENT_YEAR")) + 1);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private OracleFileObject fleFOLLOWING_ENT;

        private void fleFOLLOWING_ENT_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleFOLLOWING_ENT.ElementOwner("FILLER_8")).Append(" = ").Append(Common.StringToField(((fleBOOKINGS.GetStringValue("INVESTOR") + D_FOLLOWING_YEAR.Value)).PadRight(12).Substring(0, 8)));
                //Parent:INVESTOR_YEAR
                strText.Append(" AND ").Append(fleFOLLOWING_ENT.ElementOwner("YEAR")).Append(" = ").Append(Common.StringToField(((fleBOOKINGS.GetStringValue("INVESTOR") + D_FOLLOWING_YEAR.Value)).PadRight(12).Substring(8, 4)));
                //Parent:INVESTOR_YEAR

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

        private OracleFileObject fleSUSP_ACCOUNT;

        private void fleSUSP_ACCOUNT_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleSUSP_ACCOUNT.ElementOwner("INVESTOR")).Append(" = ").Append(Common.StringToField(fleBOOKINGS.GetStringValue("INVESTOR")));

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

        private OracleFileObject fleFORF_ACCOUNT;

        private void fleFORF_ACCOUNT_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleFORF_ACCOUNT.ElementOwner("INVESTOR")).Append(" = ").Append(Common.StringToField(fleBOOKINGS.GetStringValue("INVESTOR")));

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

        private OracleFileObject fleANNUAL_ENT;

        private void fleANNUAL_ENT_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleANNUAL_ENT.ElementOwner("INVESTOR")).Append(" = ").Append(Common.StringToField(fleBOOKINGS.GetStringValue("INVESTOR")));

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



        private void fleM_INVESTORS_SetItemFinals()
        {

            try
            {
                if (QDesign.NULL(fleBOOKINGS.GetStringValue("BOOKING_STATUS")) == "CF" && QDesign.NULL(flePROPERTIES.GetStringValue("GROUPING")) == "BOND" && QDesign.NULL(fleM_INVESTORS.GetDecimalValue("GUARANTEE_END_DATE")) != 0 && (QDesign.NULL(fleM_INVESTORS.GetDecimalValue("FIRST_HOLIDAY_DATE")) == 0 || QDesign.NULL(fleM_INVESTORS.GetDecimalValue("FIRST_HOLIDAY_DATE")) > QDesign.NULL(fleBOOKINGS.GetDecimalValue("END_DATE"))))
                {
                    fleM_INVESTORS.set_SetValue("FIRST_HOLIDAY_DATE", fleBOOKINGS.GetDecimalValue("END_DATE"));
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

        private OracleFileObject fleUCHARGE_DEBTS;

        private void fleUCHARGE_DEBTS_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleUCHARGE_DEBTS.ElementOwner("BOOKING_REF")).Append(" = ").Append(Common.StringToField(fleBOOKINGS.GetStringValue("BOOKING_REF")));

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



        private void fleUCHARGE_DEBTS_SelectIf(ref string SelectIfClause)
        {


            try
            {
                StringBuilder strSQL = new StringBuilder("");

                strSQL.Append(" (    ").Append(fleUCHARGE_DEBTS.ElementOwner("DEBT_TYPE")).Append(" =  'RS')");
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



        private void fleUCHARGE_DEBTS_SetItemFinals()
        {

            try
            {
                if (QDesign.NULL(QDesign.Substring(fleBOOKINGS.GetStringValue("GROUPING"), 1, 3)) != "SHH" && QDesign.NULL(fleBOOKINGS.GetDecimalValue("DEPOSIT")) == 0)
                {
                    fleUCHARGE_DEBTS.set_SetValue("DEBT_AMOUNT", fleBOOKINGS.GetDecimalValue("BOOKING_CHARGE"));
                }
                if (QDesign.NULL(QDesign.Substring(fleBOOKINGS.GetStringValue("GROUPING"), 1, 3)) != "SHH" && QDesign.NULL(fleBOOKINGS.GetDecimalValue("DEPOSIT")) == 0)
                {
                    fleUCHARGE_DEBTS.set_SetValue("VAT", fleBOOKINGS.GetDecimalValue("VAT"));
                }
                if (QDesign.NULL(flePROPERTIES.GetStringValue("VAT_FLAG")) == "Y")
                {
                    fleUCHARGE_DEBTS.set_SetValue("PP1_VAT", QDesign.Round(fleUCHARGE_DEBTS.GetDecimalValue("PP1_SURCHARGE") / (fleCOLOUR_RATES.GetDecimalValue("COLOUR_RATE") + 1000000) * fleCOLOUR_RATES.GetDecimalValue("COLOUR_RATE"), 0, RoundOptionTypes.Near));
                }
                else
                {
                    fleUCHARGE_DEBTS.set_SetValue("PP1_VAT", 0);
                }
                if (QDesign.NULL(flePROPERTIES.GetStringValue("VAT_FLAG")) == "Y")
                {
                    fleUCHARGE_DEBTS.set_SetValue("PP2_VAT", QDesign.Round(fleUCHARGE_DEBTS.GetDecimalValue("PP2_SURCHARGE") / (fleCOLOUR_RATES.GetDecimalValue("COLOUR_RATE") + 1000000) * fleCOLOUR_RATES.GetDecimalValue("COLOUR_RATE"), 0, RoundOptionTypes.Near));
                }
                else
                {
                    fleUCHARGE_DEBTS.set_SetValue("PP2_VAT", 0);
                }
                if (QDesign.NULL(flePROPERTIES.GetStringValue("VAT_FLAG")) == "Y")
                {
                    fleUCHARGE_DEBTS.set_SetValue("CC_VAT", QDesign.Round(fleUCHARGE_DEBTS.GetDecimalValue("CC_SURCHARGE") / (fleCOLOUR_RATES.GetDecimalValue("COLOUR_RATE") + 1000000) * fleCOLOUR_RATES.GetDecimalValue("COLOUR_RATE"), 0, RoundOptionTypes.Near));
                }
                else
                {
                    fleUCHARGE_DEBTS.set_SetValue("CC_VAT", 0);
                }
                if (QDesign.NULL(flePROPERTIES.GetStringValue("VAT_FLAG")) == "Y")
                {
                    fleUCHARGE_DEBTS.set_SetValue("TERM_VAT", QDesign.Round(fleUCHARGE_DEBTS.GetDecimalValue("TERM_SURCHARGE") / (fleCOLOUR_RATES.GetDecimalValue("COLOUR_RATE") + 1000000) * fleCOLOUR_RATES.GetDecimalValue("COLOUR_RATE"), 0, RoundOptionTypes.Near));
                }
                else
                {
                    fleUCHARGE_DEBTS.set_SetValue("TERM_VAT", 0);
                }
                fleUCHARGE_DEBTS.set_SetValue("TOTAL_DEBT", fleUCHARGE_DEBTS.GetDecimalValue("DEBT_AMOUNT") + fleUCHARGE_DEBTS.GetDecimalValue("PP1_SURCHARGE") + fleUCHARGE_DEBTS.GetDecimalValue("PP2_SURCHARGE") + fleUCHARGE_DEBTS.GetDecimalValue("TERM_SURCHARGE") + fleUCHARGE_DEBTS.GetDecimalValue("CC_SURCHARGE"));
                fleUCHARGE_DEBTS.set_SetValue("TOTAL_VAT", fleUCHARGE_DEBTS.GetDecimalValue("VAT") + fleUCHARGE_DEBTS.GetDecimalValue("NOTIONAL_VAT") + fleUCHARGE_DEBTS.GetDecimalValue("PP1_VAT") + fleUCHARGE_DEBTS.GetDecimalValue("PP2_VAT") + fleUCHARGE_DEBTS.GetDecimalValue("TERM_VAT") + fleUCHARGE_DEBTS.GetDecimalValue("CC_VAT"));


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }

        private OracleFileObject flePURCHASE_DEBTS;

        private void flePURCHASE_DEBTS_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(flePURCHASE_DEBTS.ElementOwner("BOOKING_REF")).Append(" = ").Append(Common.StringToField(fleBOOKINGS.GetStringValue("BOOKING_REF")));

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



        private void flePURCHASE_DEBTS_SelectIf(ref string SelectIfClause)
        {


            try
            {
                StringBuilder strSQL = new StringBuilder("");

                strSQL.Append(" (    ").Append(flePURCHASE_DEBTS.ElementOwner("DEBT_TYPE")).Append(" =  'PU')");
                
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



        private void flePURCHASE_DEBTS_SetItemFinals()
        {

            try
            {
                flePURCHASE_DEBTS.set_SetValue("TOTAL_DEBT", flePURCHASE_DEBTS.GetDecimalValue("DEBT_AMOUNT") + flePURCHASE_DEBTS.GetDecimalValue("PP1_SURCHARGE") + flePURCHASE_DEBTS.GetDecimalValue("PP2_SURCHARGE") + flePURCHASE_DEBTS.GetDecimalValue("TERM_SURCHARGE") + flePURCHASE_DEBTS.GetDecimalValue("CC_SURCHARGE"));
                flePURCHASE_DEBTS.set_SetValue("TOTAL_VAT", flePURCHASE_DEBTS.GetDecimalValue("VAT") + flePURCHASE_DEBTS.GetDecimalValue("NOTIONAL_VAT") + flePURCHASE_DEBTS.GetDecimalValue("PP1_VAT") + flePURCHASE_DEBTS.GetDecimalValue("PP2_VAT") + flePURCHASE_DEBTS.GetDecimalValue("TERM_VAT") + flePURCHASE_DEBTS.GetDecimalValue("CC_VAT"));


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }

        private OracleFileObject fleBALANCE_DEBTS;

        private void fleBALANCE_DEBTS_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleBALANCE_DEBTS.ElementOwner("BOOKING_REF")).Append(" = ").Append(Common.StringToField(fleBOOKINGS.GetStringValue("BOOKING_REF")));

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



        private void fleBALANCE_DEBTS_SelectIf(ref string SelectIfClause)
        {


            try
            {
                StringBuilder strSQL = new StringBuilder("");

                strSQL.Append(" (    ").Append(fleBALANCE_DEBTS.ElementOwner("DEBT_TYPE")).Append(" =  'BL')");
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



        private void fleBALANCE_DEBTS_SetItemFinals()
        {

            try
            {
                fleBALANCE_DEBTS.set_SetValue("DEBT_TYPE", "DB");
                if (QDesign.NULL(flePROPERTIES.GetStringValue("VAT_FLAG")) == "Y")
                {
                    fleBALANCE_DEBTS.set_SetValue("PP1_VAT", QDesign.Round(fleBALANCE_DEBTS.GetDecimalValue("PP1_SURCHARGE") / (fleCOLOUR_RATES.GetDecimalValue("COLOUR_RATE") + 1000000) * fleCOLOUR_RATES.GetDecimalValue("COLOUR_RATE"), 0, RoundOptionTypes.Near));
                }
                else
                {
                    fleBALANCE_DEBTS.set_SetValue("PP1_VAT", 0);
                }
                if (QDesign.NULL(flePROPERTIES.GetStringValue("VAT_FLAG")) == "Y")
                {
                    fleBALANCE_DEBTS.set_SetValue("PP2_VAT", QDesign.Round(fleBALANCE_DEBTS.GetDecimalValue("PP2_SURCHARGE") / (fleCOLOUR_RATES.GetDecimalValue("COLOUR_RATE") + 1000000) * fleCOLOUR_RATES.GetDecimalValue("COLOUR_RATE"), 0, RoundOptionTypes.Near));
                }
                else
                {
                    fleBALANCE_DEBTS.set_SetValue("PP2_VAT", 0);
                }
                if (QDesign.NULL(flePROPERTIES.GetStringValue("VAT_FLAG")) == "Y")
                {
                    fleBALANCE_DEBTS.set_SetValue("CC_VAT", QDesign.Round(fleBALANCE_DEBTS.GetDecimalValue("CC_SURCHARGE") / (fleCOLOUR_RATES.GetDecimalValue("COLOUR_RATE") + 1000000) * fleCOLOUR_RATES.GetDecimalValue("COLOUR_RATE"), 0, RoundOptionTypes.Near));
                }
                else
                {
                    fleBALANCE_DEBTS.set_SetValue("CC_VAT", 0);
                }
                if (QDesign.NULL(flePROPERTIES.GetStringValue("VAT_FLAG")) == "Y")
                {
                    fleBALANCE_DEBTS.set_SetValue("TERM_VAT", QDesign.Round(fleBALANCE_DEBTS.GetDecimalValue("TERM_SURCHARGE") / (fleCOLOUR_RATES.GetDecimalValue("COLOUR_RATE") + 1000000) * fleCOLOUR_RATES.GetDecimalValue("COLOUR_RATE"), 0, RoundOptionTypes.Near));
                }
                else
                {
                    fleBALANCE_DEBTS.set_SetValue("TERM_VAT", 0);
                }
                if (QDesign.NULL(flePROPERTIES.GetStringValue("VAT_FLAG")) == "Y")
                {
                    fleBALANCE_DEBTS.set_SetValue("VAT", fleBOOKINGS.GetDecimalValue("VAT") - fleUCHARGE_DEBTS.GetDecimalValue("VAT"));
                }
                else
                {
                    fleBALANCE_DEBTS.set_SetValue("VAT", 0);
                }
                fleBALANCE_DEBTS.set_SetValue("TOTAL_DEBT", fleBALANCE_DEBTS.GetDecimalValue("DEBT_AMOUNT") + fleBALANCE_DEBTS.GetDecimalValue("PP1_SURCHARGE") + fleBALANCE_DEBTS.GetDecimalValue("PP2_SURCHARGE") + fleBALANCE_DEBTS.GetDecimalValue("TERM_SURCHARGE") + fleBALANCE_DEBTS.GetDecimalValue("CC_SURCHARGE"));
                fleBALANCE_DEBTS.set_SetValue("TOTAL_VAT", fleBALANCE_DEBTS.GetDecimalValue("VAT") + fleBALANCE_DEBTS.GetDecimalValue("NOTIONAL_VAT") + fleBALANCE_DEBTS.GetDecimalValue("PP1_VAT") + fleBALANCE_DEBTS.GetDecimalValue("PP2_VAT") + fleBALANCE_DEBTS.GetDecimalValue("TERM_VAT") + fleBALANCE_DEBTS.GetDecimalValue("CC_VAT"));


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }

        private OracleFileObject fleBOOKING_DETAIL;

        private void fleBOOKING_DETAIL_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleBOOKING_DETAIL.ElementOwner("BOOKING_REF")).Append(" = ").Append(Common.StringToField(fleBOOKINGS.GetStringValue("BOOKING_REF")));

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



        private void fleBOOKING_DETAIL_SetItemFinals()
        {

            try
            {
                fleBOOKING_DETAIL.set_SetValue("AMEND_DATE", QDesign.SysDate(ref m_cnnQUERY));


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }

        private OracleFileObject fleEMAILS;

        private void fleEMAILS_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleEMAILS.ElementOwner("INVESTOR")).Append(" = ").Append(Common.StringToField(fleBOOKINGS.GetStringValue("INVESTOR")));

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



        private void fleEMAILS_SelectIf(ref string SelectIfClause)
        {


            try
            {
                StringBuilder strSQL = new StringBuilder("");

                strSQL.Append(" (    ").Append(fleEMAILS.ElementOwner("EMAIL")).Append(" <>  ' ' AND ");
                strSQL.Append("    ").Append(fleEMAILS.ElementOwner("VALID_YN")).Append(" =  'Y')");
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

        private OracleFileObject fleCORR_ADDRESS;

        private void fleCORR_ADDRESS_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleCORR_ADDRESS.ElementOwner("BOOKING_REF")).Append(" = ").Append(Common.StringToField(fleBOOKINGS.GetStringValue("BOOKING_REF")));

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

        private CoreInteger T_PURC_AMT;
        private CoreInteger T_DEP_AMT;
        private CoreInteger T_UCHG_AMT;
        private CoreInteger T_PURC_CC_SUR;
        private CoreInteger T_DEP_CC_SUR;
        private CoreInteger T_UCHG_CC_SUR;
        private CoreDecimal T_CARD_CC_SURPER;
        private CoreCharacter T_PAID_OK;
        private CoreCharacter T_HPB_CODE;
        private CoreCharacter T_PAY_PURC_PTS;
        private CoreCharacter T_PAY_DEPOSIT;
        private CoreCharacter T_PAY_USER_CHG;
        private CoreCharacter T_PAYMENT_METHOD;
        private CoreCharacter T_BOOK_REF;
        private CoreCharacter T_REASON;
        private CoreCharacter T_TAKE_PAYMENT;
        private CoreCharacter T_PAYMENT_TYPE;
        private CoreCharacter T_BALANCE_DEBTS;
        private CoreDecimal T_START_PERIOD;
        private CoreDecimal T_END_PERIOD;
        private CoreCharacter T_MAX_ENT_ERROR;
        private CoreCharacter T_POINTS_ALLOCATED;
        private CoreCharacter T_FINAL_CHECKS_DONE;
        private CoreCharacter T_PASS_NAME;
        private CoreCharacter T_PASS_CARDNO;
        private CoreCharacter T_PASS_ISSUE;
        private CoreCharacter T_PASS_VFROM;
        private CoreCharacter T_PASS_EXPDATE;
        private CoreCharacter T_PASS_SEC;
        private CoreCharacter T_START_WEEK;
        private CoreCharacter T_END_WEEK;
        private CoreCharacter T_PROPERTY_YEAR;
        private CoreCharacter T_ERROR_FLAG;
        private CoreCharacter T_UPDATE_LINKED;
        private CoreCharacter T_CALLING_SCREEN;
        private CoreCharacter T_EMAIL;
        private CoreCharacter T_CORR_EXISTS;
        private CoreCharacter T_CORR_EMAIL;
        private CoreCharacter T_RECORD_STATUS;
        private DCharacter D_BOOKING_START = new DCharacter(6);
        private void D_BOOKING_START_GetValue(ref string Value)
        {

            try
            {
                Value = QDesign.Substring(QDesign.ASCII(fleBOOKINGS.GetDecimalValue("START_DATE"), 6), 5, 2) + QDesign.Substring(QDesign.ASCII(fleBOOKINGS.GetDecimalValue("START_DATE"), 6), 3, 2) + QDesign.Substring(QDesign.ASCII(fleBOOKINGS.GetDecimalValue("START_DATE"), 6), 1, 2);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DCharacter D_BOOKING_END = new DCharacter(6);
        private void D_BOOKING_END_GetValue(ref string Value)
        {

            try
            {
                Value = QDesign.Substring(QDesign.ASCII(fleBOOKINGS.GetDecimalValue("END_DATE"), 6), 5, 2) + QDesign.Substring(QDesign.ASCII(fleBOOKINGS.GetDecimalValue("END_DATE"), 6), 3, 2) + QDesign.Substring(QDesign.ASCII(fleBOOKINGS.GetDecimalValue("END_DATE"), 6), 1, 2);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DCharacter D_LOCATION = new DCharacter(25);
        private void D_LOCATION_GetValue(ref string Value)
        {

            try
            {
                Value = (QDesign.Substring(fleLOCATIONS.GetStringValue("LOCATION_DESC"), 1, 17)).TrimEnd() + ": " + fleCORR_ADDRESS.GetStringValue("BOOKING_REF");


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DCharacter D_LINE_DESCRIPTION = new DCharacter(40);
        private void D_LINE_DESCRIPTION_GetValue(ref string Value)
        {

            try
            {

                // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

                Value = QDesign.Pack(D_LOCATION.Value + D_BOOKING_START.Value + "/" + D_BOOKING_END.Value);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DCharacter D_PURCHASE_DESC = new DCharacter(40);
        private void D_PURCHASE_DESC_GetValue(ref string Value)
        {

            try
            {
                Value = "PURCHASE for BOOKING " + fleCORR_ADDRESS.GetStringValue("BOOKING_REF");


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DCharacter D_LINE_LOCATION = new DCharacter(20);
        private void D_LINE_LOCATION_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(T_START_PERIOD.Value) == QDesign.NULL(T_END_PERIOD.Value))
                {
                    CurrentValue = QDesign.Substring(fleLOCATIONS.GetStringValue("LOCATION_DESC"), 1, 20);
                }
                else
                {
                    CurrentValue = QDesign.Substring(fleLOCATIONS.GetStringValue("LOCATION_DESC"), 1, 13);
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
        private DCharacter D_LINE_DURATION = new DCharacter(15);
        private void D_LINE_DURATION_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;

                // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

                if (QDesign.NULL(T_START_PERIOD.Value) == QDesign.NULL(T_END_PERIOD.Value))
                {
                    CurrentValue = "WK " + QDesign.ASCII(T_START_PERIOD.Value) + "/" + fleBOOKINGS.GetStringValue("YEAR");
                }
                else
                {
                    CurrentValue = "WKS " + QDesign.ASCII(T_START_PERIOD.Value) + "-" + QDesign.ASCII(T_END_PERIOD.Value) + "/" + fleBOOKINGS.GetStringValue("YEAR");
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
        private DCharacter D_BOOKING_LINE = new DCharacter(40);
        private void D_BOOKING_LINE_GetValue(ref string Value)
        {

            try
            {
                Value = QDesign.Pack(D_LINE_LOCATION.Value + " " + fleBOOKINGS.GetStringValue("PROPERTY_ID") + " " + D_LINE_DURATION.Value + " (" + fleBOOKINGS.GetStringValue("BOOKING_REF") + ")");


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DCharacter D_CURR_TRANS_LINE = new DCharacter(40);
        private void D_CURR_TRANS_LINE_GetValue(ref string Value)
        {

            try
            {
                Value = QDesign.Pack(D_LINE_LOCATION.Value + " " + fleBOOKINGS.GetStringValue("PROPERTY_ID") + " " + D_LINE_DURATION.Value + " (" + fleBOOKINGS.GetStringValue("BOOKING_REF") + ")");


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DCharacter D_TRANS_LINE = new DCharacter(40);
        private void D_TRANS_LINE_GetValue(ref string Value)
        {

            try
            {
                Value = QDesign.Pack(D_LINE_LOCATION.Value + " " + fleBOOKINGS.GetStringValue("PROPERTY_ID") + " " + D_LINE_DURATION.Value + " (" + fleBOOKINGS.GetStringValue("BOOKING_REF") + ")");


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DInteger D_NET_BOOKING = new DInteger(8);
        private void D_NET_BOOKING_GetValue(ref decimal Value)
        {

            try
            {
                Value = fleBOOKINGS.GetDecimalValue("BOOKING_POINTS") - fleBOOKINGS.GetDecimalValue("POINTS_ADJUST");


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DInteger D_FULL_CHARGE = new DInteger(8);
        private void D_FULL_CHARGE_GetValue(ref decimal Value)
        {

            try
            {
                Value = fleBOOKINGS.GetDecimalValue("BOOKING_CHARGE") + fleUCHARGE_DEBTS.GetDecimalValue("TERM_SURCHARGE") + fleBALANCE_DEBTS.GetDecimalValue("TERM_SURCHARGE");


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DInteger D_DEPOSIT = new DInteger(8);
        private void D_DEPOSIT_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0;
                if (QDesign.NULL(fleBALANCE_DEBTS.GetDecimalValue("DEBT_AMOUNT")) > 0)
                {
                    CurrentValue = fleUCHARGE_DEBTS.GetDecimalValue("DEBT_AMOUNT") + fleUCHARGE_DEBTS.GetDecimalValue("CC_SURCHARGE");
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
        private OracleFileObject fleTRANS_HEADER;

        private void fleTRANS_HEADER_SetItemFinals()
        {

            try
            {
                fleTRANS_HEADER.set_SetValue("BOOKING_REF", fleBOOKINGS.GetStringValue("BOOKING_REF"));
                fleTRANS_HEADER.set_SetValue("INVESTOR", fleM_INVESTORS.GetStringValue("INVESTOR"));
                fleTRANS_HEADER.set_SetValue("TRANS_TYPE", "BK");
                fleTRANS_HEADER.set_SetValue("TRANS_STATUS", "WP");
                fleTRANS_HEADER.set_SetValue("ON_STATEMENT", "Y");
                fleTRANS_HEADER.set_SetValue("LINE_DESCRIPTION", D_BOOKING_LINE.Value);
                fleTRANS_HEADER.set_SetValue("TRANSACT_DATE", QDesign.SysDate(ref m_cnnQUERY));
                fleTRANS_HEADER.set_SetValue("TRANS_YM", QDesign.Substring(QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8), 1, 6));
                fleTRANS_HEADER.set_SetValue("TRANS_SPARE", UserID);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }

        private OracleFileObject fleBOOKING_TRANS;

        private void fleBOOKING_TRANS_SetItemFinals()
        {

            try
            {
                fleBOOKING_TRANS.set_SetValue("INVESTOR", fleBOOKINGS.GetStringValue("INVESTOR"));
                fleBOOKING_TRANS.set_SetValue("FILLER_8", (fleCURRENT_ENTS.GetStringValue("FILLER_8") + fleCURRENT_ENTS.GetStringValue("YEAR")).PadRight(12).Substring(0, 8));
                //Parent:INVESTOR_YEAR    'Parent:INVESTOR_YEAR
                fleBOOKING_TRANS.set_SetValue("YEAR", (fleCURRENT_ENTS.GetStringValue("FILLER_8") + fleCURRENT_ENTS.GetStringValue("YEAR")).PadRight(12).Substring(8, 4));
                //Parent:INVESTOR_YEAR    'Parent:INVESTOR_YEAR
                fleBOOKING_TRANS.set_SetValue("TRANSACT_DATE", QDesign.SysDate(ref m_cnnQUERY));
                fleBOOKING_TRANS.set_SetValue("TRANSACT_TIME", QDesign.SysTime(ref m_cnnQUERY));
                fleBOOKING_TRANS.set_SetValue("TRANS_YM", QDesign.Substring(QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8), 1, 6));
                fleBOOKING_TRANS.set_SetValue("FILLER_81", fleTRANS_HEADER.GetStringValue("FILLER"));
                //Parent:TRANS_ID
                fleBOOKING_TRANS.set_SetValue("TRANS_NO", fleTRANS_HEADER.GetStringValue("TRANS_NO"));
                //Parent:TRANS_ID    'Parent:TRANS_ID
                fleBOOKING_TRANS.set_SetValue("TRANS_YEAR_ID", fleBOOKING_TRANS.GetStringValue("FILLER_8") + fleBOOKING_TRANS.GetStringValue("YEAR") + QDesign.Substring(fleTRANS_HEADER.GetStringValue("FILLER") + fleTRANS_HEADER.GetStringValue("TRANS_NO"), 9, 6));
                //Parent:TRANS_ID    'Parent:INVESTOR_YEAR
                fleBOOKING_TRANS.set_SetValue("LINE_DESCRIPTION", D_BOOKING_LINE.Value);
                fleBOOKING_TRANS.set_SetValue("TRANSACT_VALUE", fleBOOKING_TRANS.GetDecimalValue("ENT_VAL") + fleBOOKING_TRANS.GetDecimalValue("BF_VAL") + fleBOOKING_TRANS.GetDecimalValue("OD_VAL"));
                fleBOOKING_TRANS.set_SetValue("HOLIDAY_ANNIV", fleM_INVESTORS.GetStringValue("HOLIDAY_ANNIV"));
                fleBOOKING_TRANS.set_SetValue("TRANSACT_TYPE", "BKND");


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }

        private OracleFileObject fleFORFACCT_TRANS;

        private void fleFORFACCT_TRANS_SetItemFinals()
        {

            try
            {
                fleFORFACCT_TRANS.set_SetValue("INVESTOR", fleBOOKINGS.GetStringValue("INVESTOR"));
                fleFORFACCT_TRANS.set_SetValue("FILLER_8", fleBOOKINGS.GetStringValue("INVESTOR") + "1970");
                //Parent:INVESTOR_YEAR
                fleFORFACCT_TRANS.set_SetValue("YEAR", (fleBOOKINGS.GetStringValue("INVESTOR") + "1970").PadRight(12).Substring(8, 4));
                //Parent:INVESTOR_YEAR
                fleFORFACCT_TRANS.set_SetValue("TRANSACT_DATE", QDesign.SysDate(ref m_cnnQUERY));
                fleFORFACCT_TRANS.set_SetValue("TRANSACT_TIME", QDesign.SysTime(ref m_cnnQUERY));
                fleFORFACCT_TRANS.set_SetValue("TRANS_YM", QDesign.Substring(QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8), 1, 6));
                fleFORFACCT_TRANS.set_SetValue("FILLER_81", fleTRANS_HEADER.GetStringValue("FILLER"));
                //Parent:TRANS_ID
                fleFORFACCT_TRANS.set_SetValue("TRANS_NO", fleTRANS_HEADER.GetStringValue("TRANS_NO"));
                //Parent:TRANS_ID    'Parent:TRANS_ID
                fleFORFACCT_TRANS.set_SetValue("TRANS_YEAR_ID", fleFORFACCT_TRANS.GetStringValue("FILLER_8") + fleFORFACCT_TRANS.GetStringValue("YEAR") + QDesign.Substring(fleTRANS_HEADER.GetStringValue("FILLER") + fleTRANS_HEADER.GetStringValue("TRANS_NO"), 9, 6));
                //Parent:TRANS_ID    'Parent:INVESTOR_YEAR
                fleFORFACCT_TRANS.set_SetValue("LINE_DESCRIPTION", D_BOOKING_LINE.Value);
                fleFORFACCT_TRANS.set_SetValue("HOLIDAY_ANNIV", fleM_INVESTORS.GetStringValue("HOLIDAY_ANNIV"));
                fleFORFACCT_TRANS.set_SetValue("TRANSACT_TYPE", "BKNG");


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }

        private OracleFileObject fleSUSP_TRANS;

        private void fleSUSP_TRANS_SetItemFinals()
        {

            try
            {
                fleSUSP_TRANS.set_SetValue("INVESTOR", fleBOOKINGS.GetStringValue("INVESTOR"));
                fleSUSP_TRANS.set_SetValue("FILLER_8", fleBOOKINGS.GetStringValue("INVESTOR") + "RESV");
                //Parent:INVESTOR_YEAR
                fleSUSP_TRANS.set_SetValue("YEAR", (fleBOOKINGS.GetStringValue("INVESTOR") + "RESV").PadRight(12).Substring(8, 4));
                //Parent:INVESTOR_YEAR
                fleSUSP_TRANS.set_SetValue("TRANSACT_DATE", QDesign.SysDate(ref m_cnnQUERY));
                fleSUSP_TRANS.set_SetValue("TRANSACT_TIME", QDesign.SysTime(ref m_cnnQUERY));
                fleSUSP_TRANS.set_SetValue("TRANS_YM", QDesign.Substring(QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8), 1, 6));
                fleSUSP_TRANS.set_SetValue("FILLER_81", fleTRANS_HEADER.GetStringValue("FILLER"));
                //Parent:TRANS_ID
                fleSUSP_TRANS.set_SetValue("TRANS_NO", fleTRANS_HEADER.GetStringValue("TRANS_NO"));
                //Parent:TRANS_ID    'Parent:TRANS_ID
                fleSUSP_TRANS.set_SetValue("TRANS_YEAR_ID", fleSUSP_TRANS.GetStringValue("INVESTOR") + "RESV" + QDesign.Substring(fleTRANS_HEADER.GetStringValue("FILLER") + fleTRANS_HEADER.GetStringValue("TRANS_NO"), 9, 6));
                //Parent:TRANS_ID
                fleSUSP_TRANS.set_SetValue("LINE_DESCRIPTION", D_BOOKING_LINE.Value);
                fleSUSP_TRANS.set_SetValue("HOLIDAY_ANNIV", fleM_INVESTORS.GetStringValue("HOLIDAY_ANNIV"));
                fleSUSP_TRANS.set_SetValue("TRANSACT_TYPE", "BKNG");


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }

        private OracleFileObject flePREVIOUS_TRANS;

        private void flePREVIOUS_TRANS_InitializeItems(bool Fixed)
        {

            try
            {
                if (!Fixed)
                    flePREVIOUS_TRANS.set_SetValue("BF_RBAL", true, flePREVIOUS_ENT.GetDecimalValue("BF_BAL"));
                if (!Fixed)
                    flePREVIOUS_TRANS.set_SetValue("OD_RBAL", true, flePREVIOUS_ENT.GetDecimalValue("ENT_OVERDRAFT"));


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void flePREVIOUS_TRANS_SetItemFinals()
        {

            try
            {
                flePREVIOUS_TRANS.set_SetValue("INVESTOR", fleBOOKINGS.GetStringValue("INVESTOR"));
                flePREVIOUS_TRANS.set_SetValue("FILLER_8", (flePREVIOUS_ENT.GetStringValue("FILLER_8") + flePREVIOUS_ENT.GetStringValue("YEAR")).PadRight(12).Substring(0, 8));
                //Parent:INVESTOR_YEAR    'Parent:INVESTOR_YEAR
                flePREVIOUS_TRANS.set_SetValue("YEAR", (flePREVIOUS_ENT.GetStringValue("FILLER_8") + flePREVIOUS_ENT.GetStringValue("YEAR")).PadRight(12).Substring(8, 4));
                //Parent:INVESTOR_YEAR    'Parent:INVESTOR_YEAR
                flePREVIOUS_TRANS.set_SetValue("TRANSACT_DATE", QDesign.SysDate(ref m_cnnQUERY));
                flePREVIOUS_TRANS.set_SetValue("TRANSACT_TIME", QDesign.SysTime(ref m_cnnQUERY));
                flePREVIOUS_TRANS.set_SetValue("TRANS_YM", QDesign.Substring(QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8), 1, 6));
                flePREVIOUS_TRANS.set_SetValue("FILLER_81", (fleTRANS_HEADER.GetStringValue("FILLER") + fleTRANS_HEADER.GetStringValue("TRANS_NO")).PadRight(14).Substring(0, 8));
                //Parent:TRANS_ID    'Parent:TRANS_ID
                flePREVIOUS_TRANS.set_SetValue("TRANS_NO", (fleTRANS_HEADER.GetStringValue("FILLER") + fleTRANS_HEADER.GetStringValue("TRANS_NO")).PadRight(14).Substring(8, 6));
                //Parent:TRANS_ID    'Parent:TRANS_ID
                flePREVIOUS_TRANS.set_SetValue("TRANS_YEAR_ID", flePREVIOUS_TRANS.GetStringValue("FILLER_8") + flePREVIOUS_TRANS.GetStringValue("YEAR") + QDesign.Substring(fleTRANS_HEADER.GetStringValue("FILLER") + fleTRANS_HEADER.GetStringValue("TRANS_NO"), 9, 6));
                //Parent:TRANS_ID    'Parent:INVESTOR_YEAR
                flePREVIOUS_TRANS.set_SetValue("LINE_DESCRIPTION", D_TRANS_LINE.Value);
                flePREVIOUS_TRANS.set_SetValue("TRANSACT_VALUE", flePREVIOUS_TRANS.GetDecimalValue("ENT_VAL"));
                flePREVIOUS_TRANS.set_SetValue("HOLIDAY_ANNIV", fleM_INVESTORS.GetStringValue("HOLIDAY_ANNIV"));
                flePREVIOUS_TRANS.set_SetValue("TRANSACT_TYPE", "TRAN");
                flePREVIOUS_TRANS.set_SetValue("ENT_RBAL", flePREVIOUS_ENT.GetDecimalValue("ENTITLEMENT_BAL"));
                flePREVIOUS_TRANS.set_SetValue("RUNNING_BALANCE", flePREVIOUS_TRANS.GetDecimalValue("ENT_RBAL") + flePREVIOUS_TRANS.GetDecimalValue("BF_RBAL") + flePREVIOUS_TRANS.GetDecimalValue("OD_RBAL"));


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }

        private OracleFileObject fleFOLLOWING_TRANS;

        private void fleFOLLOWING_TRANS_InitializeItems(bool Fixed)
        {

            try
            {
                if (!Fixed)
                    fleFOLLOWING_TRANS.set_SetValue("BF_RBAL", true, fleFOLLOWING_ENT.GetDecimalValue("BF_BAL"));
                if (!Fixed)
                    fleFOLLOWING_TRANS.set_SetValue("OD_RBAL", true, fleFOLLOWING_ENT.GetDecimalValue("ENT_OVERDRAFT"));


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fleFOLLOWING_TRANS_SetItemFinals()
        {

            try
            {
                fleFOLLOWING_TRANS.set_SetValue("INVESTOR", fleBOOKINGS.GetStringValue("INVESTOR"));
                fleFOLLOWING_TRANS.set_SetValue("FILLER_8", (fleFOLLOWING_ENT.GetStringValue("FILLER_8") + fleFOLLOWING_ENT.GetStringValue("YEAR")).PadRight(12).Substring(0, 8));
                //Parent:INVESTOR_YEAR    'Parent:INVESTOR_YEAR
                fleFOLLOWING_TRANS.set_SetValue("YEAR", (fleFOLLOWING_ENT.GetStringValue("FILLER_8") + fleFOLLOWING_ENT.GetStringValue("YEAR")).PadRight(12).Substring(8, 4));
                //Parent:INVESTOR_YEAR    'Parent:INVESTOR_YEAR
                fleFOLLOWING_TRANS.set_SetValue("TRANSACT_DATE", QDesign.SysDate(ref m_cnnQUERY));
                fleFOLLOWING_TRANS.set_SetValue("TRANSACT_TIME", QDesign.SysTime(ref m_cnnQUERY));
                fleFOLLOWING_TRANS.set_SetValue("TRANS_YM", QDesign.Substring(QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8), 1, 6));
                fleFOLLOWING_TRANS.set_SetValue("FILLER_81", fleTRANS_HEADER.GetStringValue("FILLER"));
                //Parent:TRANS_ID
                fleFOLLOWING_TRANS.set_SetValue("TRANS_NO", fleTRANS_HEADER.GetStringValue("TRANS_NO"));
                //Parent:TRANS_ID    'Parent:TRANS_ID
                fleFOLLOWING_TRANS.set_SetValue("TRANS_YEAR_ID", fleFOLLOWING_TRANS.GetStringValue("FILLER_8") + fleFOLLOWING_TRANS.GetStringValue("YEAR") + QDesign.Substring(fleTRANS_HEADER.GetStringValue("FILLER") + fleTRANS_HEADER.GetStringValue("TRANS_NO"), 9, 6));
                //Parent:TRANS_ID    'Parent:INVESTOR_YEAR
                fleFOLLOWING_TRANS.set_SetValue("LINE_DESCRIPTION", D_TRANS_LINE.Value);
                fleFOLLOWING_TRANS.set_SetValue("TRANSACT_VALUE", fleFOLLOWING_TRANS.GetDecimalValue("ENT_VAL"));
                fleFOLLOWING_TRANS.set_SetValue("HOLIDAY_ANNIV", fleM_INVESTORS.GetStringValue("HOLIDAY_ANNIV"));
                fleFOLLOWING_TRANS.set_SetValue("TRANSACT_TYPE", "TRAN");
                fleFOLLOWING_TRANS.set_SetValue("RUNNING_BALANCE", fleFOLLOWING_TRANS.GetDecimalValue("ENT_RBAL") + fleFOLLOWING_TRANS.GetDecimalValue("BF_RBAL") + fleFOLLOWING_TRANS.GetDecimalValue("OD_RBAL"));


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }

        private OracleFileObject fleBOOKING_LETTERS;

        private void fleBOOKING_LETTERS_SetItemFinals()
        {

            try
            {
                fleBOOKING_LETTERS.set_SetValue("BOOKING_REF", fleBOOKINGS.GetStringValue("BOOKING_REF"));
                fleBOOKING_LETTERS.set_SetValue("RECORD_STATUS", T_RECORD_STATUS.Value);
                fleBOOKING_LETTERS.set_SetValue("PRINTED", "N");


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }

        private OracleFileObject flePROV_LETTERS;

        private void flePROV_LETTERS_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(flePROV_LETTERS.ElementOwner("BOOKING_REF")).Append(" = ").Append(Common.StringToField(fleBOOKINGS.GetStringValue("BOOKING_REF")));

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

        private OracleFileObject fleBOOKING_PERIODS;
        private OracleFileObject fleBOOKING_PERIODS_DTL;
        

        private void fleBOOKING_PERIODS_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleBOOKING_PERIODS.ElementOwner("LOCATION")).Append(" = ").Append(Common.StringToField(fleBOOKINGS.GetStringValue("LOCATION") + flePROPERTIES.GetStringValue("CHANGEOVER_DAY") + fleBOOKINGS.GetStringValue("YEAR")));
                //Parent:BOOKING_PERIOD
                strText.Append(" AND ").Append(fleBOOKING_PERIODS.ElementOwner("CHANGEOVER_DAY")).Append(" = ").Append(Common.StringToField((fleBOOKINGS.GetStringValue("LOCATION") + flePROPERTIES.GetStringValue("CHANGEOVER_DAY") + fleBOOKINGS.GetStringValue("YEAR")).PadRight(8).Substring(2, 2)));
                //Parent:BOOKING_PERIOD
                strText.Append(" AND ").Append(fleBOOKING_PERIODS.ElementOwner("YEAR")).Append(" = ").Append(Common.StringToField((fleBOOKINGS.GetStringValue("LOCATION") + flePROPERTIES.GetStringValue("CHANGEOVER_DAY") + fleBOOKINGS.GetStringValue("YEAR")).PadRight(8).Substring(4, 4)));
                //Parent:BOOKING_PERIOD

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

        private OracleFileObject flePROPERTY_YEARS;
        private OracleFileObject flePROPERTY_YEARS_DTL;

        private void flePROPERTY_YEARS_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(flePROPERTY_YEARS.ElementOwner("LOCATION")).Append(" = ").Append(Common.StringToField(fleBOOKINGS.GetStringValue("LOCATION")));
                //Parent:PROPERTY_YEAR    'Parent:PROPERTY_YEAR
                strText.Append(" AND ").Append(flePROPERTY_YEARS.ElementOwner("BEDS")).Append(" = ").Append(Common.StringToField(fleBOOKINGS.GetStringValue("BEDS")));
                //Parent:PROPERTY_YEAR    'Parent:PROPERTY_YEAR
                strText.Append(" AND ").Append(flePROPERTY_YEARS.ElementOwner("PROPERTY_STYLE")).Append(" = ").Append(Common.StringToField(fleBOOKINGS.GetStringValue("PROPERTY_STYLE")));
                //Parent:PROPERTY_YEAR    'Parent:PROPERTY_YEAR
                strText.Append(" AND ").Append(flePROPERTY_YEARS.ElementOwner("BATHROOMS")).Append(" = ").Append(Common.StringToField(fleBOOKINGS.GetStringValue("BATHROOMS")));
                //Parent:PROPERTY_YEAR    'Parent:PROPERTY_YEAR
                strText.Append(" AND ").Append(flePROPERTY_YEARS.ElementOwner("PROPERTY_ID")).Append(" = ").Append(Common.StringToField(fleBOOKINGS.GetStringValue("PROPERTY_ID")));
                //Parent:PROPERTY_YEAR    'Parent:PROPERTY_YEAR
                strText.Append(" AND ").Append(flePROPERTY_YEARS.ElementOwner("YEAR")).Append(" = ").Append(Common.StringToField(fleBOOKINGS.GetStringValue("YEAR")));
                //Parent:PROPERTY_YEAR    'Parent:PROPERTY_YEAR

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

        private OracleFileObject fleUSER_SEC_FILE;

        private void fleUSER_SEC_FILE_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleUSER_SEC_FILE.ElementOwner("USER_LOGON")).Append(" = ").Append(Common.StringToField(UserID));

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
        private OracleFileObject fleFLIGHT_REQUEST;

        private void fleFLIGHT_REQUEST_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleFLIGHT_REQUEST.ElementOwner("BOOKING_REF")).Append(" = ").Append(Common.StringToField(fleBOOKINGS.GetStringValue("BOOKING_REF")));

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

        private CoreCharacter T_CHARGE_PAID;
        private CoreCharacter T_OLD_CHARGE_PAID;
        private CoreCharacter T_PDQD;
        private CoreInteger T_BOOK_BAL;
        private CoreCharacter T_EXTRA_POINTS;
        private CoreCharacter T_ADDON_POINTS;
        private CoreCharacter T_PURCH_POINTS;
        private CoreCharacter T_INITIAL_STATUS;
        private CoreCharacter T_INVESTOR;
        private CoreCharacter T_UPDATE_FLAG;
        private CoreCharacter T_DEFERRED_FLAG;
        private CoreDate T_START_DATE;
        private CoreInteger T_START_DAYS;
        private CoreCharacter T_PASS_LOCATION;
        private CoreCharacter T_PASS_INVESTOR;
        private CoreCharacter T_PASS_SCREEN;
        private CoreDate T_PASS_DATE;
        private CoreDate T_END_DATE;
        private CoreInteger T_SET_BALS;
        private CoreCharacter T_DELETE;
        private CoreCharacter T_NEW_BOOKING;
        private CoreCharacter T_OK;
        private CoreCharacter T_WEB_BOOKING;
        private CoreCharacter T_CC_CHARGED;
        private DInteger D_PP_CHARGES = new DInteger(8);
        private void D_PP_CHARGES_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0;
                if (QDesign.NULL(T_BALANCE_DEBTS.Value) == "N")
                {
                    CurrentValue = fleUCHARGE_DEBTS.GetDecimalValue("PP1_SURCHARGE") + fleUCHARGE_DEBTS.GetDecimalValue("PP2_SURCHARGE");
                }
                else
                {
                    CurrentValue = fleBALANCE_DEBTS.GetDecimalValue("PP1_SURCHARGE") + fleBALANCE_DEBTS.GetDecimalValue("PP2_SURCHARGE");
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
        private DInteger D_TOTAL_CHARGE = new DInteger(8);
        private void D_TOTAL_CHARGE_GetValue(ref decimal Value)
        {

            try
            {
                Value = fleBOOKINGS.GetDecimalValue("BOOKING_CHARGE") + fleUCHARGE_DEBTS.GetDecimalValue("PP1_SURCHARGE") + fleUCHARGE_DEBTS.GetDecimalValue("PP2_SURCHARGE") + fleUCHARGE_DEBTS.GetDecimalValue("CC_SURCHARGE") + fleUCHARGE_DEBTS.GetDecimalValue("TERM_SURCHARGE") + fleBALANCE_DEBTS.GetDecimalValue("PP1_SURCHARGE") + fleBALANCE_DEBTS.GetDecimalValue("PP2_SURCHARGE") + fleBALANCE_DEBTS.GetDecimalValue("CC_SURCHARGE") + fleBALANCE_DEBTS.GetDecimalValue("TERM_SURCHARGE");


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DDecimal D_DAY_2 = new DDecimal();
        private void D_DAY_2_GetValue(ref decimal Value)
        {

            try
            {
                Value = QDesign.PhDate(QDesign.Days(fleBOOKING_PERIODS_DTL.GetDecimalValue("START_DATE")) + 1);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DDecimal D_DAY_3 = new DDecimal();
        private void D_DAY_3_GetValue(ref decimal Value)
        {

            try
            {
                Value = QDesign.PhDate(QDesign.Days(fleBOOKING_PERIODS_DTL.GetDecimalValue("START_DATE")) + 2);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DDecimal D_DAY_4 = new DDecimal();
        private void D_DAY_4_GetValue(ref decimal Value)
        {

            try
            {
                Value = QDesign.PhDate(QDesign.Days(fleBOOKING_PERIODS_DTL.GetDecimalValue("START_DATE")) + 3);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DDecimal D_DAY_5 = new DDecimal();
        private void D_DAY_5_GetValue(ref decimal Value)
        {

            try
            {
                Value = QDesign.PhDate(QDesign.Days(fleBOOKING_PERIODS_DTL.GetDecimalValue("START_DATE")) + 4);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DDecimal D_DAY_6 = new DDecimal();
        private void D_DAY_6_GetValue(ref decimal Value)
        {

            try
            {
                Value = QDesign.PhDate(QDesign.Days(fleBOOKING_PERIODS_DTL.GetDecimalValue("START_DATE")) + 5);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DDecimal D_DAY_7 = new DDecimal();
        private void D_DAY_7_GetValue(ref decimal Value)
        {

            try
            {
                Value = QDesign.PhDate(QDesign.Days(fleBOOKING_PERIODS_DTL.GetDecimalValue("START_DATE")) + 6);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DCharacter D_DAY_STATUS_1 = new DCharacter(1);
        private void D_DAY_STATUS_1_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(QDesign.Substring(fleBOOKINGS.GetStringValue("INVESTOR"), 1, 3)) == "999" && QDesign.NULL(QDesign.Substring(fleBOOKINGS.GetStringValue("INVESTOR"), 4, 2)) == QDesign.NULL(fleBOOKINGS.GetStringValue("LOCATION")) && fleBOOKINGS.GetDecimalValue("START_DATE") <= fleBOOKING_PERIODS_DTL.GetDecimalValue("START_DATE") && fleBOOKINGS.GetDecimalValue("END_DATE") >= fleBOOKING_PERIODS_DTL.GetDecimalValue("START_DATE"))
                {
                    CurrentValue = "O";
                }
                else if (fleBOOKINGS.GetDecimalValue("START_DATE") <= fleBOOKING_PERIODS_DTL.GetDecimalValue("START_DATE") && fleBOOKINGS.GetDecimalValue("END_DATE") >= fleBOOKING_PERIODS_DTL.GetDecimalValue("START_DATE"))
                {
                    CurrentValue = "X";
                }
                else
                {
                    CurrentValue = flePROPERTY_YEARS_DTL.GetStringValue("DAY_1");
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
        private DCharacter D_DAY_STATUS_2 = new DCharacter(1);
        private void D_DAY_STATUS_2_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(QDesign.Substring(fleBOOKINGS.GetStringValue("INVESTOR"), 1, 3)) == "999" && QDesign.NULL(QDesign.Substring(fleBOOKINGS.GetStringValue("INVESTOR"), 4, 2)) == QDesign.NULL(fleBOOKINGS.GetStringValue("LOCATION")) && fleBOOKINGS.GetDecimalValue("START_DATE") <= D_DAY_2.Value && fleBOOKINGS.GetDecimalValue("END_DATE") >= D_DAY_2.Value)
                {
                    CurrentValue = "O";
                }
                else if (fleBOOKINGS.GetDecimalValue("START_DATE") <= D_DAY_2.Value && fleBOOKINGS.GetDecimalValue("END_DATE") >= D_DAY_2.Value)
                {
                    CurrentValue = "X";
                }
                else
                {
                    CurrentValue = flePROPERTY_YEARS_DTL.GetStringValue("DAY_2");
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
        private DCharacter D_DAY_STATUS_3 = new DCharacter(1);
        private void D_DAY_STATUS_3_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(QDesign.Substring(fleBOOKINGS.GetStringValue("INVESTOR"), 1, 3)) == "999" && QDesign.NULL(QDesign.Substring(fleBOOKINGS.GetStringValue("INVESTOR"), 4, 2)) == QDesign.NULL(fleBOOKINGS.GetStringValue("LOCATION")) && fleBOOKINGS.GetDecimalValue("START_DATE") <= D_DAY_3.Value && fleBOOKINGS.GetDecimalValue("END_DATE") >= D_DAY_3.Value)
                {
                    CurrentValue = "O";
                }
                else if (fleBOOKINGS.GetDecimalValue("START_DATE") <= D_DAY_3.Value && fleBOOKINGS.GetDecimalValue("END_DATE") >= D_DAY_3.Value)
                {
                    CurrentValue = "X";
                }
                else
                {
                    CurrentValue = flePROPERTY_YEARS_DTL.GetStringValue("DAY_3");
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
        private DCharacter D_DAY_STATUS_4 = new DCharacter(1);
        private void D_DAY_STATUS_4_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(QDesign.Substring(fleBOOKINGS.GetStringValue("INVESTOR"), 1, 3)) == "999" && QDesign.NULL(QDesign.Substring(fleBOOKINGS.GetStringValue("INVESTOR"), 4, 2)) == QDesign.NULL(fleBOOKINGS.GetStringValue("LOCATION")) && fleBOOKINGS.GetDecimalValue("START_DATE") <= D_DAY_4.Value && fleBOOKINGS.GetDecimalValue("END_DATE") >= D_DAY_4.Value)
                {
                    CurrentValue = "O";
                }
                else if (fleBOOKINGS.GetDecimalValue("START_DATE") <= D_DAY_4.Value && fleBOOKINGS.GetDecimalValue("END_DATE") >= D_DAY_4.Value)
                {
                    CurrentValue = "X";
                }
                else
                {
                    CurrentValue = flePROPERTY_YEARS_DTL.GetStringValue("DAY_4");
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
        private DCharacter D_DAY_STATUS_5 = new DCharacter(1);
        private void D_DAY_STATUS_5_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(QDesign.Substring(fleBOOKINGS.GetStringValue("INVESTOR"), 1, 3)) == "999" && QDesign.NULL(QDesign.Substring(fleBOOKINGS.GetStringValue("INVESTOR"), 4, 2)) == QDesign.NULL(fleBOOKINGS.GetStringValue("LOCATION")) && fleBOOKINGS.GetDecimalValue("START_DATE") <= D_DAY_5.Value && fleBOOKINGS.GetDecimalValue("END_DATE") >= D_DAY_5.Value)
                {
                    CurrentValue = "O";
                }
                else if (fleBOOKINGS.GetDecimalValue("START_DATE") <= D_DAY_5.Value && fleBOOKINGS.GetDecimalValue("END_DATE") >= D_DAY_5.Value)
                {
                    CurrentValue = "X";
                }
                else
                {
                    CurrentValue = flePROPERTY_YEARS_DTL.GetStringValue("DAY_5");
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
        private DCharacter D_DAY_STATUS_6 = new DCharacter(1);
        private void D_DAY_STATUS_6_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(QDesign.Substring(fleBOOKINGS.GetStringValue("INVESTOR"), 1, 3)) == "999" && QDesign.NULL(QDesign.Substring(fleBOOKINGS.GetStringValue("INVESTOR"), 4, 2)) == QDesign.NULL(fleBOOKINGS.GetStringValue("LOCATION")) && fleBOOKINGS.GetDecimalValue("START_DATE") <= D_DAY_6.Value && fleBOOKINGS.GetDecimalValue("END_DATE") >= D_DAY_6.Value)
                {
                    CurrentValue = "O";
                }
                else if (fleBOOKINGS.GetDecimalValue("START_DATE") <= D_DAY_6.Value && fleBOOKINGS.GetDecimalValue("END_DATE") >= D_DAY_6.Value)
                {
                    CurrentValue = "X";
                }
                else
                {
                    CurrentValue = flePROPERTY_YEARS_DTL.GetStringValue("DAY_6");
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
        private DCharacter D_DAY_STATUS_7 = new DCharacter(1);
        private void D_DAY_STATUS_7_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(QDesign.Substring(fleBOOKINGS.GetStringValue("INVESTOR"), 1, 3)) == "999" && QDesign.NULL(QDesign.Substring(fleBOOKINGS.GetStringValue("INVESTOR"), 4, 2)) == QDesign.NULL(fleBOOKINGS.GetStringValue("LOCATION")) && fleBOOKINGS.GetDecimalValue("START_DATE") <= D_DAY_7.Value && fleBOOKINGS.GetDecimalValue("END_DATE") >= D_DAY_7.Value)
                {
                    CurrentValue = "O";
                }
                else if (fleBOOKINGS.GetDecimalValue("START_DATE") <= D_DAY_7.Value && fleBOOKINGS.GetDecimalValue("END_DATE") >= D_DAY_7.Value)
                {
                    CurrentValue = "X";
                }
                else
                {
                    CurrentValue = flePROPERTY_YEARS_DTL.GetStringValue("DAY_7");
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
        private DCharacter D_DEL_STATUS_1 = new DCharacter(1);
        private void D_DEL_STATUS_1_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (fleBOOKINGS.GetDecimalValue("START_DATE") <= fleBOOKING_PERIODS_DTL.GetDecimalValue("START_DATE") && fleBOOKINGS.GetDecimalValue("END_DATE") >= fleBOOKING_PERIODS_DTL.GetDecimalValue("START_DATE"))
                {
                    CurrentValue = " ";
                }
                else
                {
                    CurrentValue = flePROPERTY_YEARS_DTL.GetStringValue("DAY_1");
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
        private DCharacter D_DEL_STATUS_2 = new DCharacter(1);
        private void D_DEL_STATUS_2_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (fleBOOKINGS.GetDecimalValue("START_DATE") <= D_DAY_2.Value && fleBOOKINGS.GetDecimalValue("END_DATE") >= D_DAY_2.Value)
                {
                    CurrentValue = " ";
                }
                else
                {
                    CurrentValue = flePROPERTY_YEARS_DTL.GetStringValue("DAY_2");
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
        private DCharacter D_DEL_STATUS_3 = new DCharacter(1);
        private void D_DEL_STATUS_3_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (fleBOOKINGS.GetDecimalValue("START_DATE") <= D_DAY_3.Value && fleBOOKINGS.GetDecimalValue("END_DATE") >= D_DAY_3.Value)
                {
                    CurrentValue = " ";
                }
                else
                {
                    CurrentValue = flePROPERTY_YEARS_DTL.GetStringValue("DAY_3");
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
        private DCharacter D_DEL_STATUS_4 = new DCharacter(1);
        private void D_DEL_STATUS_4_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (fleBOOKINGS.GetDecimalValue("START_DATE") <= D_DAY_4.Value && fleBOOKINGS.GetDecimalValue("END_DATE") >= D_DAY_4.Value)
                {
                    CurrentValue = " ";
                }
                else
                {
                    CurrentValue = flePROPERTY_YEARS_DTL.GetStringValue("DAY_4");
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
        private DCharacter D_DEL_STATUS_5 = new DCharacter(1);
        private void D_DEL_STATUS_5_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (fleBOOKINGS.GetDecimalValue("START_DATE") <= D_DAY_5.Value && fleBOOKINGS.GetDecimalValue("END_DATE") >= D_DAY_5.Value)
                {
                    CurrentValue = " ";
                }
                else
                {
                    CurrentValue = flePROPERTY_YEARS_DTL.GetStringValue("DAY_5");
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
        private DCharacter D_DEL_STATUS_6 = new DCharacter(1);
        private void D_DEL_STATUS_6_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (fleBOOKINGS.GetDecimalValue("START_DATE") <= D_DAY_6.Value && fleBOOKINGS.GetDecimalValue("END_DATE") >= D_DAY_6.Value)
                {
                    CurrentValue = " ";
                }
                else
                {
                    CurrentValue = flePROPERTY_YEARS_DTL.GetStringValue("DAY_6");
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
        private DCharacter D_DEL_STATUS_7 = new DCharacter(1);
        private void D_DEL_STATUS_7_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (fleBOOKINGS.GetDecimalValue("START_DATE") <= D_DAY_7.Value && fleBOOKINGS.GetDecimalValue("END_DATE") >= D_DAY_7.Value)
                {
                    CurrentValue = " ";
                }
                else
                {
                    CurrentValue = flePROPERTY_YEARS_DTL.GetStringValue("DAY_7");
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
        private DInteger D_BK_ENT = new DInteger(8);
        private void D_BK_ENT_GetValue(ref decimal Value)
        {

            try
            {
                Value = D_NET_BOOKING.Value - fleBOOKINGS.GetDecimalValue("BK_SUSPENSE") - fleBOOKINGS.GetDecimalValue("BK_PURCHASE") - fleBOOKINGS.GetDecimalValue("BK_FORF_POINTS");


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DInteger D_BK_ENT_TOT = new DInteger(8);
        private void D_BK_ENT_TOT_GetValue(ref decimal Value)
        {

            try
            {
                Value = D_NET_BOOKING.Value - fleBOOKINGS.GetDecimalValue("BK_PURCHASE");


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DInteger D_BK_ENT_DISP = new DInteger(8);
        private void D_BK_ENT_DISP_GetValue(ref decimal Value)
        {

            try
            {
                Value = D_NET_BOOKING.Value - fleBOOKINGS.GetDecimalValue("BK_SUSPENSE") - fleBOOKINGS.GetDecimalValue("BK_PURCHASE") - fleBOOKINGS.GetDecimalValue("BK_FORF_POINTS");


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DInteger D_ENT_TOT = new DInteger(8);
        private void D_ENT_TOT_GetValue(ref decimal Value)
        {

            try
            {
                Value = fleCURRENT_ENTS.GetDecimalValue("ENTITLEMENT_BAL") + fleCURRENT_ENTS.GetDecimalValue("BF_BAL") + flePREVIOUS_ENT.GetDecimalValue("ENTITLEMENT_BAL");


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DInteger D_OD_1OR2 = new DInteger(8);
        private void D_OD_1OR2_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0;
                if ((fleBOOKINGS.GetDecimalValue("BK_OVERDRAFT") <= fleFOLLOWING_ENT.GetDecimalValue("ENTITLEMENT_BAL") && (QDesign.NULL(fleCURRENT_ENTS.GetStringValue("YEAR_123")) == "01" || QDesign.NULL(fleCURRENT_ENTS.GetStringValue("YEAR_123")) == "02")))
                {
                    CurrentValue = fleBOOKINGS.GetDecimalValue("BK_OVERDRAFT");
                }
                else if ((QDesign.NULL(fleBOOKINGS.GetDecimalValue("BK_OVERDRAFT")) > QDesign.NULL(fleFOLLOWING_ENT.GetDecimalValue("ENTITLEMENT_BAL")) && (QDesign.NULL(fleCURRENT_ENTS.GetStringValue("YEAR_123")) == "01" || QDesign.NULL(fleCURRENT_ENTS.GetStringValue("YEAR_123")) == "02")))
                {
                    CurrentValue = fleFOLLOWING_ENT.GetDecimalValue("ENTITLEMENT_BAL");
                }
                else
                {
                    CurrentValue = 0;
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
        private DInteger D_OD_3 = new DInteger(8);
        private void D_OD_3_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0;
                if ((fleBOOKINGS.GetDecimalValue("BK_OVERDRAFT") <= fleANNUAL_ENT.GetDecimalValue("ANN_CURR_ENT") && QDesign.NULL(fleCURRENT_ENTS.GetStringValue("YEAR_123")) == "03"))
                {
                    CurrentValue = fleBOOKINGS.GetDecimalValue("BK_OVERDRAFT");
                }
                else if ((QDesign.NULL(fleBOOKINGS.GetDecimalValue("BK_OVERDRAFT")) > QDesign.NULL(fleANNUAL_ENT.GetDecimalValue("ANN_CURR_ENT")) && QDesign.NULL(fleCURRENT_ENTS.GetStringValue("YEAR_123")) == "03"))
                {
                    CurrentValue = fleANNUAL_ENT.GetDecimalValue("ANN_CURR_ENT");
                }
                else
                {
                    CurrentValue = 0;
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
        private DInteger D_ALLOWED_OD = new DInteger(8);
        private void D_ALLOWED_OD_GetValue(ref decimal Value)
        {

            try
            {
                Value = D_OD_1OR2.Value + D_OD_3.Value;


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DInteger D_FORF_MAX = new DInteger(8);
        private void D_FORF_MAX_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0;
                if (QDesign.NULL(fleBOOKINGS.GetDecimalValue("BK_FORF_POINTS")) > 0)
                {
                    CurrentValue = fleFORF_ACCOUNT.GetDecimalValue("FORF_BAL");
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
        private DInteger D_ENT_MAX_TOT = new DInteger(8);
        private void D_ENT_MAX_TOT_GetValue(ref decimal Value)
        {

            try
            {
                Value = D_ENT_TOT.Value + D_ALLOWED_OD.Value + fleSUSP_ACCOUNT.GetDecimalValue("SUSP_BAL") + D_FORF_MAX.Value;


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DInteger D_BK_FORF_ALLOC = new DInteger(8);
        private void D_BK_FORF_ALLOC_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0;
                if (fleBOOKINGS.GetDecimalValue("BK_FORF_POINTS") <= fleFORF_ACCOUNT.GetDecimalValue("FORF_BAL"))
                {
                    CurrentValue = fleBOOKINGS.GetDecimalValue("BK_FORF_POINTS");
                }
                else
                {
                    CurrentValue = fleFORF_ACCOUNT.GetDecimalValue("FORF_BAL");
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
        private DInteger D_BK_SUSPENSE_ALLOC = new DInteger(8);
        private void D_BK_SUSPENSE_ALLOC_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0;
                if (fleBOOKINGS.GetDecimalValue("BK_SUSPENSE") <= fleSUSP_ACCOUNT.GetDecimalValue("SUSP_BAL"))
                {
                    CurrentValue = fleBOOKINGS.GetDecimalValue("BK_SUSPENSE");
                }
                else
                {
                    CurrentValue = fleSUSP_ACCOUNT.GetDecimalValue("SUSP_BAL");
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
        private DInteger D_ENT_ALLOC_TOT = new DInteger(8);
        private void D_ENT_ALLOC_TOT_GetValue(ref decimal Value)
        {

            try
            {
                Value = D_ENT_TOT.Value + D_ALLOWED_OD.Value + D_BK_FORF_ALLOC.Value + D_BK_SUSPENSE_ALLOC.Value;


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DInteger D_PAY_TIME = new DInteger(8);
        private void D_PAY_TIME_GetValue(ref decimal Value)
        {

            try
            {
                int CurrentValue = 0;
                if (QDesign.NULL(QDesign.Substring(flePROPERTIES.GetStringValue("GROUPING"), 1, 3)) == "TEN" || QDesign.NULL(QDesign.Substring(flePROPERTIES.GetStringValue("GROUPING"), 1, 3)) == "SHH")
                {
                    CurrentValue = 93;
                }
                else
                {
                    CurrentValue = 70;
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
        private DInteger D_CURRENT_DATE = new DInteger(8);
        private void D_CURRENT_DATE_GetValue(ref decimal Value)
        {

            try
            {
                Value = QDesign.NConvert(QDesign.Substring(QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8), 1, 6) + "00");


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DInteger D_USER_CHARGE = new DInteger(8);
        private void D_USER_CHARGE_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0;
                if (QDesign.NULL(T_BALANCE_DEBTS.Value) == "N")
                {
                    CurrentValue = fleUCHARGE_DEBTS.GetDecimalValue("DEBT_AMOUNT") + fleUCHARGE_DEBTS.GetDecimalValue("PP1_SURCHARGE") + fleUCHARGE_DEBTS.GetDecimalValue("PP2_SURCHARGE") + fleUCHARGE_DEBTS.GetDecimalValue("CC_SURCHARGE") + fleUCHARGE_DEBTS.GetDecimalValue("TERM_SURCHARGE");
                }
                else
                {
                    CurrentValue = fleBALANCE_DEBTS.GetDecimalValue("DEBT_AMOUNT") + fleBALANCE_DEBTS.GetDecimalValue("PP1_SURCHARGE") + fleBALANCE_DEBTS.GetDecimalValue("PP2_SURCHARGE") + fleBALANCE_DEBTS.GetDecimalValue("CC_SURCHARGE") + fleBALANCE_DEBTS.GetDecimalValue("TERM_SURCHARGE");
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
        private DInteger D_USER_CHG_AMT = new DInteger(8);
        private void D_USER_CHG_AMT_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0;
                if (QDesign.NULL(T_PAY_USER_CHG.Value) == "Y")
                {
                    CurrentValue = D_USER_CHARGE.Value;
                }
                else
                {
                    CurrentValue = 0;
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
        private DInteger D_PURC_AMT = new DInteger(8);
        private void D_PURC_AMT_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0;
                if (QDesign.NULL(T_PAY_PURC_PTS.Value) == "Y")
                {
                    CurrentValue = flePURCHASE_DEBTS.GetDecimalValue("DEBT_AMOUNT") + flePURCHASE_DEBTS.GetDecimalValue("PP1_SURCHARGE") + flePURCHASE_DEBTS.GetDecimalValue("PP2_SURCHARGE") + flePURCHASE_DEBTS.GetDecimalValue("CC_SURCHARGE") + flePURCHASE_DEBTS.GetDecimalValue("TERM_SURCHARGE");
                }
                else
                {
                    CurrentValue = 0;
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
        private DInteger D_DEPOSIT_AMT = new DInteger(8);
        private void D_DEPOSIT_AMT_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0;
                if (QDesign.NULL(T_PAY_DEPOSIT.Value) == "Y")
                {
                    CurrentValue = D_DEPOSIT.Value;
                }
                else
                {
                    CurrentValue = 0;
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
        private DInteger D_TOT_CARD_AMT = new DInteger(8);
        private void D_TOT_CARD_AMT_GetValue(ref decimal Value)
        {

            try
            {
                Value = D_USER_CHG_AMT.Value + D_DEPOSIT_AMT.Value + D_PURC_AMT.Value;


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DInteger D_PASS_PURC = new DInteger(8);
        private void D_PASS_PURC_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0;
                if (QDesign.NULL(T_PAY_PURC_PTS.Value) == "Y")
                {
                    CurrentValue = flePURCHASE_DEBTS.GetDecimalValue("DEBT_AMOUNT") + flePURCHASE_DEBTS.GetDecimalValue("PP1_SURCHARGE") + flePURCHASE_DEBTS.GetDecimalValue("PP2_SURCHARGE") + flePURCHASE_DEBTS.GetDecimalValue("TERM_SURCHARGE");
                }
                else
                {
                    CurrentValue = 0;
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
        private DInteger D_PASS_DEPOSIT = new DInteger(8);
        private void D_PASS_DEPOSIT_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0;
                if (QDesign.NULL(fleBALANCE_DEBTS.GetDecimalValue("DEBT_AMOUNT")) > 0 && QDesign.NULL(T_PAY_DEPOSIT.Value) == "Y")
                {
                    CurrentValue = fleUCHARGE_DEBTS.GetDecimalValue("DEBT_AMOUNT");
                }
                else
                {
                    CurrentValue = 0;
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
        private DInteger D_PASS_USER_CHG = new DInteger(8);
        private void D_PASS_USER_CHG_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0;
                if (QDesign.NULL(T_BALANCE_DEBTS.Value) == "N" && QDesign.NULL(T_PAY_USER_CHG.Value) == "Y")
                {
                    CurrentValue = fleUCHARGE_DEBTS.GetDecimalValue("DEBT_AMOUNT") + fleUCHARGE_DEBTS.GetDecimalValue("PP1_SURCHARGE") + fleUCHARGE_DEBTS.GetDecimalValue("PP2_SURCHARGE") + fleUCHARGE_DEBTS.GetDecimalValue("TERM_SURCHARGE");
                }
                else if (QDesign.NULL(T_PAY_USER_CHG.Value) == "Y")
                {
                    CurrentValue = fleBALANCE_DEBTS.GetDecimalValue("DEBT_AMOUNT") + fleBALANCE_DEBTS.GetDecimalValue("PP1_SURCHARGE") + fleBALANCE_DEBTS.GetDecimalValue("PP2_SURCHARGE") + fleBALANCE_DEBTS.GetDecimalValue("TERM_SURCHARGE");
                }
                else
                {
                    CurrentValue = 0;
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
        private DCharacter D_PURC_REASON = new DCharacter(24);
        private void D_PURC_REASON_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(T_PAY_PURC_PTS.Value) == "Y")
                {
                    CurrentValue = "Purchase points payment,";
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
        private DCharacter D_DEP_REASON = new DCharacter(16);
        private void D_DEP_REASON_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(T_PAY_DEPOSIT.Value) == "Y")
                {
                    CurrentValue = "Deposit payment,";
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
        private DCharacter D_UCHG_REASON = new DCharacter(24);
        private void D_UCHG_REASON_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;

                // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

                if (QDesign.NULL(T_PAY_USER_CHG.Value) == "Y" && QDesign.NULL(fleUCHARGE_DEBTS.GetStringValue("PAYMENT_TYPE")) == "F")
                {
                    CurrentValue = "User charge payment";
                }
                else if (QDesign.NULL(T_PAY_USER_CHG.Value) == "Y" && QDesign.NULL(fleBALANCE_DEBTS.GetStringValue("PAYMENT_TYPE")) == "B")
                {
                    CurrentValue = "U/charge Balance payment";
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
        private DCharacter D_PAYMENT_TYPE = new DCharacter(2);
        private void D_PAYMENT_TYPE_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(T_PAY_DEPOSIT.Value) == "Y" && QDesign.NULL(T_PAY_USER_CHG.Value) == "Y")
                {
                    CurrentValue = "DB";
                }
                else if (QDesign.NULL(T_PAY_PURC_PTS.Value) == "Y" && QDesign.NULL(T_PAY_DEPOSIT.Value) == "Y")
                {
                    CurrentValue = "PD";
                }
                else if (QDesign.NULL(T_PAY_PURC_PTS.Value) == "Y" && QDesign.NULL(T_PAY_USER_CHG.Value) == "Y")
                {
                    CurrentValue = "PF";
                }
                else if (QDesign.NULL(T_PAY_DEPOSIT.Value) == "Y")
                {
                    CurrentValue = "D";
                }
                else if (QDesign.NULL(T_PAY_USER_CHG.Value) == "Y" && QDesign.NULL(fleUCHARGE_DEBTS.GetStringValue("PAYMENT_TYPE")) == "F")
                {
                    CurrentValue = "F";
                }
                else if (QDesign.NULL(T_PAY_USER_CHG.Value) == "Y" && QDesign.NULL(fleBALANCE_DEBTS.GetStringValue("PAYMENT_TYPE")) == "B")
                {
                    CurrentValue = "B";
                }
                else if (QDesign.NULL(T_PAY_PURC_PTS.Value) == "Y")
                {
                    CurrentValue = "P";
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
        private DDecimal D_CC_SURCHARGEPER = new DDecimal(9);
        private void D_CC_SURCHARGEPER_GetValue(ref decimal Value)
        {

            try
            {
                Value = (decimal)0.0225;


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DCharacter D_CC_SURCHARGE_INFO = new DCharacter(50);
        private void D_CC_SURCHARGE_INFO_GetValue(ref string Value)
        {

            try
            {
                Value = "                INCLUDES 2.25% SURCHARGE";


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DCharacter D_SENDTO = new DCharacter(60);
        private void D_SENDTO_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;

                // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

                //if ("unixlive" == QDesign.NULL(GetSystemVal("HPSUSAN"))) {
                //    CurrentValue = " >>/hpb/trans/confirmed/" + (fleFLIGHT_REQUEST.GetStringValue("BOOKING_REF")).TrimEnd() + ".rec";
                //} else {
                //    CurrentValue = " >>$DATAX/confirmed-" + (fleFLIGHT_REQUEST.GetStringValue("BOOKING_REF")).TrimEnd() + ".rec";
                //}

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
        private DCharacter D_SENDTOSTORE = new DCharacter(200);
        private void D_SENDTOSTORE_GetValue(ref string Value)
        {

            try
            {

                // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

                Value = QDesign.Pack("echo " + QDesign.Substring(QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8), 7, 2) + "/" + QDesign.Substring(QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8), 5, 2) + "/" + QDesign.Substring(QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8), 1, 4) + "," + QDesign.Substring(QDesign.ASCII(QDesign.SysTime(ref m_cnnQUERY), 8), 1, 2) + "." + QDesign.Substring(QDesign.ASCII(QDesign.SysTime(ref m_cnnQUERY), 8), 3, 2) + "," + UserID + "," + fleFLIGHT_REQUEST.GetStringValue("BOOKING_REF") + "," + fleBOOKINGS.GetStringValue("PROPERTY_ID") + "," + fleFLIGHT_REQUEST.GetStringValue("INVESTOR") + "," + QDesign.Substring(QDesign.ASCII(fleBOOKINGS.GetDecimalValue("START_DATE"), 8), 7, 2) + "/" + QDesign.Substring(QDesign.ASCII(fleBOOKINGS.GetDecimalValue("START_DATE"), 8), 5, 2) + "/" + QDesign.Substring(QDesign.ASCII(fleBOOKINGS.GetDecimalValue("START_DATE"), 8), 1, 4) + "," + QDesign.Substring(QDesign.ASCII(fleBOOKINGS.GetDecimalValue("END_DATE"), 8), 7, 2) + "/" + QDesign.Substring(QDesign.ASCII(fleBOOKINGS.GetDecimalValue("END_DATE"), 8), 5, 2) + "/" + QDesign.Substring(QDesign.ASCII(fleBOOKINGS.GetDecimalValue("END_DATE"), 8), 1, 4) + "," + fleFLIGHT_REQUEST.GetStringValue("BOOKING_STATUS") + ",confirm.qks" + D_SENDTO.Value);


            }
            catch (CustomApplicationException ex)
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
        //# Do not delete, modify or move it.  Updated: 07/12/2013 1:48:27 PM

        //# No code was generated or needed for this region.

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 07/12/2013 1:48:27 PM

        //# No code was generated or needed for this region.

        #endregion

        #region "Transaction Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 07/12/2013 1:48:27 PM

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
            fleBOOKINGS.Transaction = m_trnTRANS_UPDATE;
            flePROPERTIES.Transaction = m_trnTRANS_UPDATE;
            fleINVESTMENTS.Transaction = m_trnTRANS_UPDATE;
            fleCURRENT_ENTS.Transaction = m_trnTRANS_UPDATE;
            flePREVIOUS_ENT.Transaction = m_trnTRANS_UPDATE;
            fleFOLLOWING_ENT.Transaction = m_trnTRANS_UPDATE;
            fleSUSP_ACCOUNT.Transaction = m_trnTRANS_UPDATE;
            fleFORF_ACCOUNT.Transaction = m_trnTRANS_UPDATE;
            fleANNUAL_ENT.Transaction = m_trnTRANS_UPDATE;
            fleM_INVESTORS.Transaction = m_trnTRANS_UPDATE;
            fleUCHARGE_DEBTS.Transaction = m_trnTRANS_UPDATE;
            flePURCHASE_DEBTS.Transaction = m_trnTRANS_UPDATE;
            fleBALANCE_DEBTS.Transaction = m_trnTRANS_UPDATE;
            fleBOOKING_DETAIL.Transaction = m_trnTRANS_UPDATE;
            fleTRANS_HEADER.Transaction = m_trnTRANS_UPDATE;
            fleBOOKING_TRANS.Transaction = m_trnTRANS_UPDATE;
            fleFORFACCT_TRANS.Transaction = m_trnTRANS_UPDATE;
            fleSUSP_TRANS.Transaction = m_trnTRANS_UPDATE;
            flePREVIOUS_TRANS.Transaction = m_trnTRANS_UPDATE;
            fleFOLLOWING_TRANS.Transaction = m_trnTRANS_UPDATE;
            fleBOOKING_LETTERS.Transaction = m_trnTRANS_UPDATE;
            flePROV_LETTERS.Transaction = m_trnTRANS_UPDATE;
            fleBOOKING_PERIODS.Transaction = m_trnTRANS_UPDATE;
            fleBOOKING_PERIODS_DTL.Transaction = m_trnTRANS_UPDATE;
            flePROPERTY_YEARS.Transaction = m_trnTRANS_UPDATE;
            flePROPERTY_YEARS_DTL.Transaction = m_trnTRANS_UPDATE;
            fleUSER_SEC_FILE.Transaction = m_trnTRANS_UPDATE;
            fleCANCEL_BOOKING.Transaction = m_trnTRANS_UPDATE;
            fleFLIGHT_REQUEST.Transaction = m_trnTRANS_UPDATE;


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 07/12/2013 1:48:27 PM

        //#-----------------------------------------
        //# InitializeFiles Procedure.
        //#-----------------------------------------

        protected override void InitializeFiles()
        {

            try
            {
                Initialize_TRANS_UPDATE();
                fleCOLOUR_RATES.Connection = m_cnnQUERY;
                fleLOCATIONS.Connection = m_cnnQUERY;
                fleEMAILS.Connection = m_cnnQUERY;
                fleCORR_ADDRESS.Connection = m_cnnQUERY;


            }
            catch (CustomApplicationException ex)
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
                fleBOOKINGS.Dispose();
                flePROPERTIES.Dispose();
                fleCOLOUR_RATES.Dispose();
                fleINVESTMENTS.Dispose();
                fleLOCATIONS.Dispose();
                fleCURRENT_ENTS.Dispose();
                flePREVIOUS_ENT.Dispose();
                fleFOLLOWING_ENT.Dispose();
                fleSUSP_ACCOUNT.Dispose();
                fleFORF_ACCOUNT.Dispose();
                fleANNUAL_ENT.Dispose();
                fleM_INVESTORS.Dispose();
                fleUCHARGE_DEBTS.Dispose();
                flePURCHASE_DEBTS.Dispose();
                fleBALANCE_DEBTS.Dispose();
                fleBOOKING_DETAIL.Dispose();
                fleEMAILS.Dispose();
                fleCORR_ADDRESS.Dispose();
                fleTRANS_HEADER.Dispose();
                fleBOOKING_TRANS.Dispose();
                fleFORFACCT_TRANS.Dispose();
                fleSUSP_TRANS.Dispose();
                flePREVIOUS_TRANS.Dispose();
                fleFOLLOWING_TRANS.Dispose();
                fleBOOKING_LETTERS.Dispose();
                flePROV_LETTERS.Dispose();
                fleBOOKING_PERIODS.Dispose();
                fleBOOKING_PERIODS_DTL.Dispose();
                flePROPERTY_YEARS.Dispose();
                flePROPERTY_YEARS_DTL.Dispose();
                fleUSER_SEC_FILE.Dispose();
                fleCANCEL_BOOKING.Dispose();
                fleFLIGHT_REQUEST.Dispose();


            }
            catch (CustomApplicationException ex)
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
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 07/12/2013 1:48:27 PM
        //#-----------------------------------------
        protected override void DisplayFormatting()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:48:27 PM
                Display(ref fldBOOKINGS_BOOKING_REF);
                Display(ref fldBOOKINGS_INVESTOR);
                Display(ref fldM_INVESTORS_INVESTOR_NAME);
                Display(ref fldBOOKINGS_LOCATION);
                Display(ref fldBOOKINGS_BEDS);
                Display(ref fldBOOKINGS_PROPERTY_STYLE);
                Display(ref fldBOOKINGS_BATHROOMS);
                Display(ref fldBOOKINGS_PROPERTY_ID);
                Display(ref fldBOOKINGS_YEAR);
                Display(ref fldT_START_PERIOD);
                Display(ref fldT_END_PERIOD);
                Display(ref fldBOOKINGS_START_DATE);
                Display(ref fldBOOKINGS_END_DATE);
                Display(ref fldBOOKINGS_ENT_YEAR);
                Display(ref fldBOOKINGS_LONG_STAY);
                Display(ref fldBOOKINGS_BOOKING_DATE);
                Display(ref fldBOOKINGS_CONFIRM_DATE);
                Display(ref fldBOOKINGS_BOOKING_STATUS);
                Display(ref fldBOOKINGS_CORE_OPTION);
                Display(ref fldBOOKINGS_BOOKING_POINTS);
                Display(ref fldBOOKINGS_POINTS_ADJUST);
                Display(ref fldD_NET_BOOKING);
                Display(ref fldD_FULL_CHARGE);
                Display(ref fldD_PP_CHARGES);
                Display(ref fldD_TOTAL_CHARGE);
                Display(ref fldT_CHARGE_PAID);
                Display(ref fldT_PAYMENT_METHOD);
                Display(ref fldT_PAY_PURC_PTS);
                Display(ref fldD_PURC_AMT);
                Display(ref fldT_PAY_DEPOSIT);
                Display(ref fldD_DEPOSIT_AMT);
                Display(ref fldT_PAY_USER_CHG);
                Display(ref fldD_USER_CHG_AMT);
                Display(ref fldD_TOT_CARD_AMT);
                Display(ref fldT_TAKE_PAYMENT);
                Display(ref fldBOOKINGS_BK_SUSPENSE);
                Display(ref fldD_BK_ENT_DISP);
                Display(ref fldBOOKINGS_BK_FORF_POINTS);
                Display(ref fldD_BK_ENT_TOT);
                Display(ref fldSUSP_ACCOUNT_SUSP_BAL);
                Display(ref fldD_ENT_TOT);
                Display(ref fldFORF_ACCOUNT_FORF_BAL);
                Display(ref fldD_ALLOWED_OD);
                Display(ref fldD_ENT_MAX_TOT);
                Display(ref fldBOOKINGS_BK_PURCHASE);
                Display(ref fldPURCHASE_DEBTS_DEBT_AMOUNT);
                Display(ref fldD_DEPOSIT);
                Display(ref fldT_DELETE);
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
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 07/12/2013 1:48:27 PM
        //#-----------------------------------------
        protected override void PreDisplayFormatting()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:48:27 PM
                Display(ref fldBOOKINGS_BOOKING_STATUS);
                Display(ref fldBOOKINGS_CORE_OPTION);
                Display(ref fldT_CHARGE_PAID);
                Display(ref fldT_PAY_PURC_PTS);
                Display(ref fldT_PAY_DEPOSIT);
                Display(ref fldT_PAY_USER_CHG);
                Display(ref fldT_TAKE_PAYMENT);
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
        //# Do not delete, modify or move it.  Updated: 07/12/2013 1:48:27 PM

        //#-----------------------------------------
        //# BindFields Procedure.
        //#-----------------------------------------

        public override void BindFields()
        {
            try
            {
                fldBOOKINGS_BOOKING_REF.Bind(fleBOOKINGS);
                fldBOOKINGS_INVESTOR.Bind(fleBOOKINGS);
                fldM_INVESTORS_INVESTOR_NAME.Bind(fleM_INVESTORS);
                fldBOOKINGS_LOCATION.Bind(fleBOOKINGS);
                fldBOOKINGS_BEDS.Bind(fleBOOKINGS);
                fldBOOKINGS_PROPERTY_STYLE.Bind(fleBOOKINGS);
                fldBOOKINGS_BATHROOMS.Bind(fleBOOKINGS);
                fldBOOKINGS_PROPERTY_ID.Bind(fleBOOKINGS);
                fldBOOKINGS_YEAR.Bind(fleBOOKINGS);
                fldT_START_PERIOD.Bind(T_START_PERIOD);
                fldT_END_PERIOD.Bind(T_END_PERIOD);
                fldBOOKINGS_START_DATE.Bind(fleBOOKINGS);
                fldBOOKINGS_END_DATE.Bind(fleBOOKINGS);
                fldBOOKINGS_ENT_YEAR.Bind(fleBOOKINGS);
                fldBOOKINGS_LONG_STAY.Bind(fleBOOKINGS);
                fldBOOKINGS_BOOKING_DATE.Bind(fleBOOKINGS);
                fldBOOKINGS_CONFIRM_DATE.Bind(fleBOOKINGS);
                fldBOOKINGS_BOOKING_STATUS.Bind(fleBOOKINGS);
                fldBOOKINGS_CORE_OPTION.Bind(fleBOOKINGS);
                fldBOOKINGS_BOOKING_POINTS.Bind(fleBOOKINGS);
                fldBOOKINGS_POINTS_ADJUST.Bind(fleBOOKINGS);
                fldD_NET_BOOKING.Bind(D_NET_BOOKING);
                fldD_FULL_CHARGE.Bind(D_FULL_CHARGE);
                fldD_PP_CHARGES.Bind(D_PP_CHARGES);
                fldD_TOTAL_CHARGE.Bind(D_TOTAL_CHARGE);
                fldT_CHARGE_PAID.Bind(T_CHARGE_PAID);
                fldT_PAYMENT_METHOD.Bind(T_PAYMENT_METHOD);
                fldT_PAY_PURC_PTS.Bind(T_PAY_PURC_PTS);
                fldD_PURC_AMT.Bind(D_PURC_AMT);
                fldT_PAY_DEPOSIT.Bind(T_PAY_DEPOSIT);
                fldD_DEPOSIT_AMT.Bind(D_DEPOSIT_AMT);
                fldT_PAY_USER_CHG.Bind(T_PAY_USER_CHG);
                fldD_USER_CHG_AMT.Bind(D_USER_CHG_AMT);
                fldD_TOT_CARD_AMT.Bind(D_TOT_CARD_AMT);
                fldT_TAKE_PAYMENT.Bind(T_TAKE_PAYMENT);
                fldBOOKINGS_BK_SUSPENSE.Bind(fleBOOKINGS);
                fldD_BK_ENT_DISP.Bind(D_BK_ENT_DISP);
                fldBOOKINGS_BK_FORF_POINTS.Bind(fleBOOKINGS);
                fldD_BK_ENT_TOT.Bind(D_BK_ENT_TOT);
                fldSUSP_ACCOUNT_SUSP_BAL.Bind(fleSUSP_ACCOUNT);
                fldD_ENT_TOT.Bind(D_ENT_TOT);
                fldFORF_ACCOUNT_FORF_BAL.Bind(fleFORF_ACCOUNT);
                fldD_ALLOWED_OD.Bind(D_ALLOWED_OD);
                fldD_ENT_MAX_TOT.Bind(D_ENT_MAX_TOT);
                fldBOOKINGS_BK_PURCHASE.Bind(fleBOOKINGS);
                fldPURCHASE_DEBTS_DEBT_AMOUNT.Bind(flePURCHASE_DEBTS);
                fldD_DEPOSIT.Bind(D_DEPOSIT);
                fldT_DELETE.Bind(T_DELETE);

            }
            catch (CustomApplicationException ex)
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



        private void fldBOOKINGS_LOCATION_LookupOn()
        {

            try
            {
                StringBuilder strSQL = new StringBuilder(" WHERE ");
                strSQL.Append("     ").Append(fleLOCATIONS.ElementOwner("LOCATION")).Append(" = ").Append(Common.StringToField(fleLOCATIONS.GetStringValue("LOCATION")));

                fleLOCATIONS.GetData(strSQL.ToString(), GetDataOptions.IsOptional);
                if (!AccessOk)
                {
                    ErrorMessage("0");
                    // "THIS IS NOT A VALID LOCATION"
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



        protected override object SetFieldDefaults(string Name)
        {


            try
            {
                switch (Name)
                {
                    case "T_CHARGE_PAID":
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




        protected override void SaveParamsReceived()
        {

            try
            {
                SaveReceivingParams(T_CONFIRM_REF, T_INSTANT_CONF, T_INSTANT_DELETE);


            }
            catch (CustomApplicationException ex)
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
                Receiving(T_CONFIRM_REF, T_INSTANT_CONF, T_INSTANT_DELETE);


            }
            catch (CustomApplicationException ex)
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


        private void fldBOOKINGS_INVESTOR_Input()
        {

            try
            {

                if (QDesign.NULL(QDesign.Substring(FieldText, 1, 1)) == "Q" || QDesign.NULL(QDesign.Substring(FieldText, 1, 1)) == "Q")
                {
                    //RunScreen("INDEXINV.QKC", RunScreenModes.Find, T_INVESTOR);
                    FieldText = T_INVESTOR.Value;
                }
                if (1 <= FieldText.Length && 4 >= FieldText.Length)
                {
                    FieldText = QDesign.ASCII(QDesign.NConvert(FieldText), 5);
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



        private void dsrDesigner_01_Click(object sender, System.EventArgs e)
        {

            try
            {

                if (QDesign.NULL(fleBOOKINGS.GetStringValue("INVESTOR")) == "00011")
                {
                    ErrorMessage("52070");
                }
                if (QDesign.NULL(fleM_INVESTORS.GetDecimalValue("STATUS")) == 99)
                {
                    ErrorMessage("52071");
                }
                if (QDesign.NULL(T_MAX_ENT_ERROR.Value) == "Y")
                {
                    ErrorMessage("52072");
                }
                Accept(ref fldBOOKINGS_BOOKING_STATUS);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldBOOKINGS_BOOKING_STATUS_Edit()
        {

            try
            {

                if (QDesign.NULL(FieldText) == "CF" && QDesign.NULL(T_INITIAL_STATUS.Value) == "OR")
                {
                    FieldText = "OC";
                    Information("CORRECT STATUS for CONFIRMED RENTED NON HPB" + " PROPERTY IS OC");
                    // TODO: May need to fix manually
                }
                if (QDesign.NULL(FieldText) == "OR" && QDesign.NULL(T_INITIAL_STATUS.Value) == "RS")
                {
                    FieldText = "CF";
                    Information("CORRECT STATUS for CONFIRMED BOOKING IN HPB" + " PROPERTY IS CF");
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



        private void fldT_CHARGE_PAID_Input()
        {

            try
            {

                if (QDesign.NULL(FieldText) == "D" && QDesign.NULL(fleBALANCE_DEBTS.GetDecimalValue("DEBT_AMOUNT")) > 0 && QDesign.NULL(fleM_INVESTORS.GetStringValue("CUSTOMER_TYPE")) != "I")
                {
                    FieldText = "N";
                    Warning("32006");
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



        private void fldT_CHARGE_PAID_Edit()
        {

            try
            {

                if (QDesign.NULL(QDesign.Substring(flePROPERTIES.GetStringValue("GROUPING"), 1, 3)) == "TEN" && QDesign.NULL(T_CHARGE_PAID.Value) == "D" && QDesign.NULL(fleFLIGHT_REQUEST.GetStringValue("INVESTOR")) != "00015" && QDesign.NULL(fleM_INVESTORS.GetStringValue("CUSTOMER_TYPE")) != "I")
                {
                    if (92 > QDesign.NULL(QDesign.Days(fleBOOKINGS.GetDecimalValue("START_DATE")) - QDesign.Days(QDesign.SysDate(ref m_cnnQUERY))))
                    {
                        ErrorMessage("52073");
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



        private void fldT_PAYMENT_METHOD_Input()
        {

            try
            {

                if (QDesign.NULL(T_INSTANT_CONF.Value) == "Y" && (QDesign.NULL(FieldText) != "CC" && QDesign.NULL(T_PAYMENT_METHOD.Value) != "CC" && QDesign.NULL(FieldText) != "SW" && QDesign.NULL(T_PAYMENT_METHOD.Value) != "SW") && QDesign.NULL(fleM_INVESTORS.GetStringValue("CUSTOMER_TYPE")) != "I")
                {
                    ErrorMessage("52074");
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


        private bool Internal_TAKE_PAYMENT_METHOD()
        {


            try
            {

                if (QDesign.NULL(fleBOOKINGS.GetDecimalValue("TERM_SURCHARGEPER")) != QDesign.NULL(fleINVESTMENTS.GetDecimalValue("TERM_SURCHARGEPER")))
                {
                    Warning("32007");
                }
                if (QDesign.NULL(T_PAYMENT_METHOD.Value) == QDesign.NULL(" ") && QDesign.NULL(T_CHARGE_PAID.Value) == "Y")
                {
                    ErrorMessage("52075");
                }
                if (QDesign.NULL(T_PAYMENT_METHOD.Value) == "CC")
                {
                    if (QDesign.NULL(T_CC_CHARGED.Value) == "N")
                    {
                        T_CC_CHARGED.Value = "Y";
                        if (QDesign.NULL(T_PAY_DEPOSIT.Value) == "Y" || QDesign.NULL(T_PAY_USER_CHG.Value) == "Y")
                        {
                            fleUCHARGE_DEBTS.set_SetValue("CC_SURCHARGE", QDesign.Round((fleUCHARGE_DEBTS.GetDecimalValue("DEBT_AMOUNT") + fleUCHARGE_DEBTS.GetDecimalValue("PP1_SURCHARGE") + fleUCHARGE_DEBTS.GetDecimalValue("PP2_SURCHARGE") + fleUCHARGE_DEBTS.GetDecimalValue("TERM_SURCHARGE")) * D_CC_SURCHARGEPER.Value, 0, RoundOptionTypes.Near));
                            if (QDesign.NULL(fleBALANCE_DEBTS.GetDecimalValue("DEBT_AMOUNT")) > 0 && QDesign.NULL(T_PAY_USER_CHG.Value) == "Y")
                            {
                                fleBALANCE_DEBTS.set_SetValue("CC_SURCHARGE", QDesign.Round((fleBALANCE_DEBTS.GetDecimalValue("DEBT_AMOUNT") + fleBALANCE_DEBTS.GetDecimalValue("PP1_SURCHARGE") + fleBALANCE_DEBTS.GetDecimalValue("PP2_SURCHARGE") + fleBALANCE_DEBTS.GetDecimalValue("TERM_SURCHARGE")) * D_CC_SURCHARGEPER.Value, 0, RoundOptionTypes.Near));
                            }
                        }
                        if (QDesign.NULL(T_PAY_PURC_PTS.Value) == "Y")
                        {
                            flePURCHASE_DEBTS.set_SetValue("CC_SURCHARGE", QDesign.Round((flePURCHASE_DEBTS.GetDecimalValue("DEBT_AMOUNT") + flePURCHASE_DEBTS.GetDecimalValue("PP1_SURCHARGE") + flePURCHASE_DEBTS.GetDecimalValue("PP2_SURCHARGE") + flePURCHASE_DEBTS.GetDecimalValue("TERM_SURCHARGE")) * D_CC_SURCHARGEPER.Value, 0, RoundOptionTypes.Near));
                        }
                    }
                    Information(D_CC_SURCHARGE_INFO.Value);
                    // TODO: May need to fix manually
                }
                if (QDesign.NULL(flePROPERTIES.GetStringValue("VAT_FLAG")) == "Y")
                {
                    fleUCHARGE_DEBTS.set_SetValue("VAT", QDesign.Round((fleUCHARGE_DEBTS.GetDecimalValue("DEBT_AMOUNT") - fleUCHARGE_DEBTS.GetDecimalValue("NOTIONAL_VAT")) / (fleCOLOUR_RATES.GetDecimalValue("COLOUR_RATE") + 1000000) * (fleCOLOUR_RATES.GetDecimalValue("COLOUR_RATE")), 0, RoundOptionTypes.Near));
                    if (QDesign.NULL(fleBALANCE_DEBTS.GetDecimalValue("DEBT_AMOUNT")) > 0)
                    {
                        fleBALANCE_DEBTS.set_SetValue("VAT", QDesign.Round((fleBALANCE_DEBTS.GetDecimalValue("DEBT_AMOUNT") - fleBALANCE_DEBTS.GetDecimalValue("NOTIONAL_VAT")) / (fleCOLOUR_RATES.GetDecimalValue("COLOUR_RATE") + 1000000) * (fleCOLOUR_RATES.GetDecimalValue("COLOUR_RATE")), 0, RoundOptionTypes.Near));
                    }
                }
                else
                {
                    fleUCHARGE_DEBTS.set_SetValue("VAT", 0);
                    if (QDesign.NULL(fleBALANCE_DEBTS.GetDecimalValue("DEBT_AMOUNT")) > 0)
                    {
                        fleBALANCE_DEBTS.set_SetValue("VAT", 0);
                    }
                }
                if ("SHH" != QDesign.NULL(QDesign.Substring(fleBOOKINGS.GetStringValue("GROUPING"), 1, 3)) && QDesign.NULL(fleBOOKINGS.GetDecimalValue("DEPOSIT")) == 0)
                {
                    fleBOOKINGS.set_SetValue("BOOKING_CHARGE", fleUCHARGE_DEBTS.GetDecimalValue("DEBT_AMOUNT"));
                    fleBOOKINGS.set_SetValue("VAT", fleUCHARGE_DEBTS.GetDecimalValue("VAT"));
                }
                else
                {
                    fleBOOKINGS.set_SetValue("BOOKING_CHARGE", fleUCHARGE_DEBTS.GetDecimalValue("DEBT_AMOUNT") + fleBALANCE_DEBTS.GetDecimalValue("DEBT_AMOUNT"));
                    fleBOOKINGS.set_SetValue("VAT", fleUCHARGE_DEBTS.GetDecimalValue("VAT") + fleBALANCE_DEBTS.GetDecimalValue("VAT"));
                }
                if (QDesign.NULL(T_PAYMENT_METHOD.Value) != "CC")
                {
                    if (QDesign.NULL(T_CC_CHARGED.Value) == "Y")
                    {
                        T_CC_CHARGED.Value = "N";
                        fleUCHARGE_DEBTS.set_SetValue("CC_SURCHARGE", 0);
                        if (QDesign.NULL(fleBALANCE_DEBTS.GetDecimalValue("DEBT_AMOUNT")) > 0)
                        {
                            fleBALANCE_DEBTS.set_SetValue("CC_SURCHARGE", 0);
                        }
                        if (QDesign.NULL(flePURCHASE_DEBTS.GetDecimalValue("DEBT_AMOUNT")) > 0)
                        {
                            flePURCHASE_DEBTS.set_SetValue("CC_SURCHARGE", 0);
                        }
                    }
                }
                Display(ref fldD_FULL_CHARGE);
                Display(ref fldD_PP_CHARGES);
                Display(ref fldD_TOTAL_CHARGE);
                Display(ref fldD_DEPOSIT);
                Display(ref fldT_PAYMENT_METHOD);
                Display(ref fldT_PAY_PURC_PTS);
                Display(ref fldT_PAY_DEPOSIT);
                Display(ref fldT_PAY_USER_CHG);
                Display(ref fldD_PURC_AMT);
                Display(ref fldD_DEPOSIT_AMT);
                Display(ref fldD_USER_CHG_AMT);
                Display(ref fldD_TOT_CARD_AMT);
                if (QDesign.NULL(T_PAYMENT_METHOD.Value) == "SW" || QDesign.NULL(T_PAYMENT_METHOD.Value) == "CN")
                {
                    Information("42013");
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


        private bool Internal_START_END_CALC()
        {


            try
            {

                T_START_PERIOD.Value = fleBOOKINGS.GetDecimalValue("START_WEEK");
                T_END_PERIOD.Value = fleBOOKINGS.GetDecimalValue("END_WEEK");

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


        private bool Internal_MARK_CALENDAR()
        {


            try
            {

                m_strWhere = new StringBuilder(" WHERE ");
                m_strWhere.Append(" ").Append(fleBOOKING_PERIODS_DTL.ElementOwner("LOCATION")).Append(" = ");
                m_strWhere.Append(Common.StringToField(fleBOOKINGS.GetStringValue("LOCATION")));
                m_strWhere.Append(" AND ").Append(" ").Append(fleBOOKING_PERIODS_DTL.ElementOwner("CHANGEOVER_DAY")).Append(" = ");
                m_strWhere.Append(Common.StringToField(flePROPERTIES.GetStringValue("CHANGEOVER_DAY")));
                m_strWhere.Append(" AND ").Append(" ").Append(fleBOOKING_PERIODS_DTL.ElementOwner("YEAR")).Append(" = ");
                m_strWhere.Append(Common.StringToField(fleBOOKINGS.GetStringValue("YEAR")));
                fleBOOKING_PERIODS_DTL.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional | GetDataOptions.CreateRecordsForOccurs);

                m_strWhere = new StringBuilder(" WHERE ");
                m_strWhere.Append(" ").Append(flePROPERTY_YEARS_DTL.ElementOwner("LOCATION")).Append(" = ");
                m_strWhere.Append(Common.StringToField(fleBOOKINGS.GetStringValue("LOCATION")));
                m_strWhere.Append(" AND ").Append(" ").Append(flePROPERTY_YEARS_DTL.ElementOwner("BEDS")).Append(" = ");
                m_strWhere.Append(Common.StringToField(fleBOOKINGS.GetStringValue("BEDS")));
                m_strWhere.Append(" AND ").Append(" ").Append(flePROPERTY_YEARS_DTL.ElementOwner("PROPERTY_STYLE")).Append(" = ");
                m_strWhere.Append(Common.StringToField(fleBOOKINGS.GetStringValue("PROPERTY_STYLE")));
                m_strWhere.Append(" AND ").Append(" ").Append(flePROPERTY_YEARS_DTL.ElementOwner("BATHROOMS")).Append(" = ");
                m_strWhere.Append(Common.StringToField(fleBOOKINGS.GetStringValue("BATHROOMS")));
                m_strWhere.Append(" AND ").Append(" ").Append(flePROPERTY_YEARS_DTL.ElementOwner("PROPERTY_ID")).Append(" = ");
                m_strWhere.Append(Common.StringToField(fleBOOKINGS.GetStringValue("PROPERTY_ID")));
                m_strWhere.Append(" AND ").Append(" ").Append(flePROPERTY_YEARS_DTL.ElementOwner("YEAR")).Append(" = ");
                m_strWhere.Append(Common.StringToField(fleBOOKINGS.GetStringValue("YEAR")));

                flePROPERTY_YEARS_DTL.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional | GetDataOptions.CreateRecordsForOccurs);

                if (QDesign.NULL(fleBOOKINGS.GetStringValue("LOCATION")) != "GH" && QDesign.NULL(fleBOOKINGS.GetStringValue("LOCATION")) != "DS" && QDesign.NULL(fleBOOKINGS.GetStringValue("LOCATION")) != "HK")
                {
                    while (this.For(53))
                    {
                        flePROPERTY_YEARS_DTL.set_SetValue("DAY_1", D_DAY_STATUS_1.Value);
                        flePROPERTY_YEARS_DTL.set_SetValue("DAY_2", D_DAY_STATUS_2.Value);
                        flePROPERTY_YEARS_DTL.set_SetValue("DAY_3", D_DAY_STATUS_3.Value);
                        flePROPERTY_YEARS_DTL.set_SetValue("DAY_4", D_DAY_STATUS_4.Value);
                        flePROPERTY_YEARS_DTL.set_SetValue("DAY_5", D_DAY_STATUS_5.Value);
                        flePROPERTY_YEARS_DTL.set_SetValue("DAY_6", D_DAY_STATUS_6.Value);
                        flePROPERTY_YEARS_DTL.set_SetValue("DAY_7", D_DAY_STATUS_7.Value);
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


        private bool Internal_UNMARK_CALENDAR()
        {


            try
            {

                // --> GET BOOKING_PERIODS <--
                m_strWhere = new StringBuilder(" WHERE ");
                m_strWhere.Append(" ").Append(fleBOOKING_PERIODS.ElementOwner("LOCATION")).Append(" = ");
                m_strWhere.Append(Common.StringToField(fleBOOKINGS.GetStringValue("LOCATION")));
                m_strWhere.Append(" AND ").Append(" ").Append(fleBOOKING_PERIODS.ElementOwner("CHANGEOVER_DAY")).Append(" = ");
                m_strWhere.Append(Common.StringToField(flePROPERTIES.GetStringValue("CHANGEOVER_DAY")));
                m_strWhere.Append(" AND ").Append(" ").Append(fleBOOKING_PERIODS.ElementOwner("YEAR")).Append(" = ");
                m_strWhere.Append(Common.StringToField(fleBOOKINGS.GetStringValue("YEAR")));
                

                fleBOOKING_PERIODS.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                // --> End GET BOOKING_PERIODS <--
                if (!AccessOk)
                {
                    Severe("52076");
                }

                m_strWhere = new StringBuilder(" WHERE ");
                m_strWhere.Append(" ").Append(fleBOOKING_PERIODS_DTL.ElementOwner("LOCATION")).Append(" = ");
                m_strWhere.Append(Common.StringToField(fleBOOKINGS.GetStringValue("LOCATION")));
                m_strWhere.Append(" AND ").Append(" ").Append(fleBOOKING_PERIODS_DTL.ElementOwner("CHANGEOVER_DAY")).Append(" = ");
                m_strWhere.Append(Common.StringToField(flePROPERTIES.GetStringValue("CHANGEOVER_DAY")));
                m_strWhere.Append(" AND ").Append(" ").Append(fleBOOKING_PERIODS_DTL.ElementOwner("YEAR")).Append(" = ");
                m_strWhere.Append(Common.StringToField(fleBOOKINGS.GetStringValue("YEAR")));
                fleBOOKING_PERIODS_DTL.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);

                if (QDesign.NULL(T_INITIAL_STATUS.Value) != "OR")
                {
                    // --> GET PROPERTY_YEARS <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(flePROPERTY_YEARS.ElementOwner("LOCATION")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleBOOKINGS.GetStringValue("LOCATION")));
                    //Parent:PROPERTY_YEAR    'Parent:PROPERTY_YEAR
                    m_strWhere.Append(" AND ").Append(" ").Append(flePROPERTY_YEARS.ElementOwner("BEDS")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleBOOKINGS.GetStringValue("BEDS")));
                    //Parent:PROPERTY_YEAR    'Parent:PROPERTY_YEAR
                    m_strWhere.Append(" AND ").Append(" ").Append(flePROPERTY_YEARS.ElementOwner("PROPERTY_STYLE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleBOOKINGS.GetStringValue("PROPERTY_STYLE")));
                    //Parent:PROPERTY_YEAR    'Parent:PROPERTY_YEAR
                    m_strWhere.Append(" AND ").Append(" ").Append(flePROPERTY_YEARS.ElementOwner("BATHROOMS")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleBOOKINGS.GetStringValue("BATHROOMS")));
                    //Parent:PROPERTY_YEAR    'Parent:PROPERTY_YEAR
                    m_strWhere.Append(" AND ").Append(" ").Append(flePROPERTY_YEARS.ElementOwner("PROPERTY_ID")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleBOOKINGS.GetStringValue("PROPERTY_ID")));
                    //Parent:PROPERTY_YEAR    'Parent:PROPERTY_YEAR
                    m_strWhere.Append(" AND ").Append(" ").Append(flePROPERTY_YEARS.ElementOwner("YEAR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleBOOKINGS.GetStringValue("YEAR")));
                    //Parent:PROPERTY_YEAR    'Parent:PROPERTY_YEAR

                    flePROPERTY_YEARS.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional | GetDataOptions.CreateRecordsForOccurs);
                    // --> End GET PROPERTY_YEARS <--
                    if (!AccessOk)
                    {
                        Severe("52077");
                    }

                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(flePROPERTY_YEARS_DTL.ElementOwner("LOCATION")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleBOOKINGS.GetStringValue("LOCATION")));
                    m_strWhere.Append(" AND ").Append(" ").Append(flePROPERTY_YEARS_DTL.ElementOwner("BEDS")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleBOOKINGS.GetStringValue("BEDS")));
                    m_strWhere.Append(" AND ").Append(" ").Append(flePROPERTY_YEARS_DTL.ElementOwner("PROPERTY_STYLE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleBOOKINGS.GetStringValue("PROPERTY_STYLE")));
                    m_strWhere.Append(" AND ").Append(" ").Append(flePROPERTY_YEARS_DTL.ElementOwner("BATHROOMS")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleBOOKINGS.GetStringValue("BATHROOMS")));
                    m_strWhere.Append(" AND ").Append(" ").Append(flePROPERTY_YEARS_DTL.ElementOwner("PROPERTY_ID")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleBOOKINGS.GetStringValue("PROPERTY_ID")));
                    m_strWhere.Append(" AND ").Append(" ").Append(flePROPERTY_YEARS_DTL.ElementOwner("YEAR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleBOOKINGS.GetStringValue("YEAR")));
                    
                    flePROPERTY_YEARS_DTL.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional | GetDataOptions.CreateRecordsForOccurs);

                    while (this.For(53))
                    {
                        flePROPERTY_YEARS_DTL.set_SetValue("DAY_1", D_DEL_STATUS_1.Value);
                        flePROPERTY_YEARS_DTL.set_SetValue("DAY_2", D_DEL_STATUS_2.Value);
                        flePROPERTY_YEARS_DTL.set_SetValue("DAY_3", D_DEL_STATUS_3.Value);
                        flePROPERTY_YEARS_DTL.set_SetValue("DAY_4", D_DEL_STATUS_4.Value);
                        flePROPERTY_YEARS_DTL.set_SetValue("DAY_5", D_DEL_STATUS_5.Value);
                        flePROPERTY_YEARS_DTL.set_SetValue("DAY_6", D_DEL_STATUS_6.Value);
                        flePROPERTY_YEARS_DTL.set_SetValue("DAY_7", D_DEL_STATUS_7.Value);
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


        private bool Internal_ALLOCATE_POINTS()
        {


            try
            {

                T_POINTS_ALLOCATED.Value = "Y";
                if (QDesign.NULL(fleBOOKINGS.GetDecimalValue("BK_FORF_POINTS")) > 0)
                {
                    fleFORF_ACCOUNT.set_SetValue("FORF_BAL", fleFORF_ACCOUNT.GetDecimalValue("FORF_BAL") - fleBOOKINGS.GetDecimalValue("BK_FORF_POINTS"));
                    fleFORF_ACCOUNT.set_SetValue("FORF_USED", fleFORF_ACCOUNT.GetDecimalValue("FORF_USED") + fleBOOKINGS.GetDecimalValue("BK_FORF_POINTS"));
                    fleFORFACCT_TRANS.set_SetValue("TRANSACT_VALUE", fleBOOKINGS.GetDecimalValue("BK_FORF_POINTS") * -1);
                    fleFORFACCT_TRANS.set_SetValue("RUNNING_BALANCE", fleFORF_ACCOUNT.GetDecimalValue("FORF_BAL"));
                }
                if (QDesign.NULL(fleBOOKINGS.GetDecimalValue("BK_SUSPENSE")) > 0)
                {
                    fleSUSP_ACCOUNT.set_SetValue("SUSP_BAL", fleSUSP_ACCOUNT.GetDecimalValue("SUSP_BAL") - fleBOOKINGS.GetDecimalValue("BK_SUSPENSE"));
                    fleSUSP_ACCOUNT.set_SetValue("SUSP_BOOKING_BAL", fleSUSP_ACCOUNT.GetDecimalValue("SUSP_BOOKING_BAL") + fleBOOKINGS.GetDecimalValue("BK_SUSPENSE"));
                    fleSUSP_TRANS.set_SetValue("TRANSACT_VALUE", fleBOOKINGS.GetDecimalValue("BK_SUSPENSE") * -1);
                    fleSUSP_TRANS.set_SetValue("RUNNING_BALANCE", fleSUSP_ACCOUNT.GetDecimalValue("SUSP_BAL"));
                }
                if (QDesign.NULL(D_BK_ENT.Value) > 0)
                {
                    T_BOOK_BAL.Value = D_BK_ENT.Value;
                    if (QDesign.NULL(fleCURRENT_ENTS.GetStringValue("YEAR_123")) == "01" && QDesign.NULL(fleCURRENT_ENTS.GetDecimalValue("BF_BAL")) > 0)
                    {
                        if (T_BOOK_BAL.Value <= fleCURRENT_ENTS.GetDecimalValue("BF_BAL"))
                        {
                            fleCURRENT_ENTS.set_SetValue("BF_BAL", fleCURRENT_ENTS.GetDecimalValue("BF_BAL") - T_BOOK_BAL.Value);
                            fleCURRENT_ENTS.set_SetValue("BF_BOOKING_BAL", fleCURRENT_ENTS.GetDecimalValue("BF_BOOKING_BAL") + (T_BOOK_BAL.Value * -1));
                            fleBOOKING_TRANS.set_SetValue("BF_VAL", T_BOOK_BAL.Value * -1);
                            fleBOOKING_TRANS.set_SetValue("BF_RBAL", fleCURRENT_ENTS.GetDecimalValue("BF_BAL"));
                            fleBOOKING_TRANS.set_SetValue("ENT_RBAL", fleCURRENT_ENTS.GetDecimalValue("ENTITLEMENT_BAL"));
                            fleBOOKING_TRANS.set_SetValue("RUNNING_BALANCE", fleCURRENT_ENTS.GetDecimalValue("ENTITLEMENT_BAL") + fleCURRENT_ENTS.GetDecimalValue("BF_BAL") + fleCURRENT_ENTS.GetDecimalValue("ENT_OVERDRAFT"));
                            fleBOOKINGS.set_SetValue("BK_BF_EOY", T_BOOK_BAL.Value);
                            T_BOOK_BAL.Value = 0;
                        }
                        else
                        {
                            T_BOOK_BAL.Value = T_BOOK_BAL.Value - fleCURRENT_ENTS.GetDecimalValue("BF_BAL");
                            fleBOOKING_TRANS.set_SetValue("BF_VAL", fleCURRENT_ENTS.GetDecimalValue("BF_BAL") * -1);
                            fleBOOKING_TRANS.set_SetValue("BF_RBAL", 0);
                            fleCURRENT_ENTS.set_SetValue("BF_BOOKING_BAL", fleCURRENT_ENTS.GetDecimalValue("BF_BOOKING_BAL") + (fleCURRENT_ENTS.GetDecimalValue("BF_BAL") * -1));
                            fleBOOKINGS.set_SetValue("BK_BF_EOY", fleCURRENT_ENTS.GetDecimalValue("BF_BAL"));
                            fleCURRENT_ENTS.set_SetValue("BF_BAL", 0);
                            fleBOOKING_TRANS.set_SetValue("RUNNING_BALANCE", fleCURRENT_ENTS.GetDecimalValue("BF_BAL") + fleCURRENT_ENTS.GetDecimalValue("ENT_OVERDRAFT"));
                        }
                    }
                    if (QDesign.NULL(T_BOOK_BAL.Value) > 0)
                    {
                        if (T_BOOK_BAL.Value <= fleCURRENT_ENTS.GetDecimalValue("ENTITLEMENT_BAL"))
                        {
                            fleCURRENT_ENTS.set_SetValue("ENTITLEMENT_BAL", fleCURRENT_ENTS.GetDecimalValue("ENTITLEMENT_BAL") - T_BOOK_BAL.Value);
                            fleCURRENT_ENTS.set_SetValue("ENT_BOOKING_BAL", fleCURRENT_ENTS.GetDecimalValue("ENT_BOOKING_BAL") + T_BOOK_BAL.Value * -1);
                            fleBOOKING_TRANS.set_SetValue("ENT_VAL", T_BOOK_BAL.Value * -1);
                            fleBOOKING_TRANS.set_SetValue("ENT_RBAL", fleCURRENT_ENTS.GetDecimalValue("ENTITLEMENT_BAL"));
                            fleBOOKING_TRANS.set_SetValue("RUNNING_BALANCE", fleCURRENT_ENTS.GetDecimalValue("ENTITLEMENT_BAL") + fleCURRENT_ENTS.GetDecimalValue("BF_BAL") + fleCURRENT_ENTS.GetDecimalValue("ENT_OVERDRAFT"));
                            fleBOOKINGS.set_SetValue("BK_ENTITLEMENT", T_BOOK_BAL.Value);
                            T_BOOK_BAL.Value = 0;
                        }
                        else
                        {
                            T_BOOK_BAL.Value = T_BOOK_BAL.Value - fleCURRENT_ENTS.GetDecimalValue("ENTITLEMENT_BAL");
                            fleBOOKING_TRANS.set_SetValue("ENT_VAL", fleCURRENT_ENTS.GetDecimalValue("ENTITLEMENT_BAL") * -1);
                            fleBOOKING_TRANS.set_SetValue("ENT_RBAL", 0);
                            fleBOOKING_TRANS.set_SetValue("RUNNING_BALANCE", fleCURRENT_ENTS.GetDecimalValue("BF_BAL") + fleCURRENT_ENTS.GetDecimalValue("ENT_OVERDRAFT"));
                            fleCURRENT_ENTS.set_SetValue("ENT_BOOKING_BAL", fleCURRENT_ENTS.GetDecimalValue("ENT_BOOKING_BAL") + fleCURRENT_ENTS.GetDecimalValue("ENTITLEMENT_BAL") * -1);
                            fleBOOKINGS.set_SetValue("BK_ENTITLEMENT", fleCURRENT_ENTS.GetDecimalValue("ENTITLEMENT_BAL"));
                            fleCURRENT_ENTS.set_SetValue("ENTITLEMENT_BAL", 0);
                        }
                    }
                    if (QDesign.NULL(T_BOOK_BAL.Value) > 0 && (QDesign.NULL(fleCURRENT_ENTS.GetStringValue("YEAR_123")) == "02" || QDesign.NULL(fleCURRENT_ENTS.GetStringValue("YEAR_123")) == "03") && QDesign.NULL(flePREVIOUS_ENT.GetDecimalValue("ENTITLEMENT_BAL")) > 0)
                    {
                        if (T_BOOK_BAL.Value <= flePREVIOUS_ENT.GetDecimalValue("ENTITLEMENT_BAL"))
                        {
                            flePREVIOUS_ENT.set_SetValue("ENTITLEMENT_BAL", flePREVIOUS_ENT.GetDecimalValue("ENTITLEMENT_BAL") - T_BOOK_BAL.Value);
                            flePREVIOUS_TRANS.set_SetValue("ENT_VAL", T_BOOK_BAL.Value * -1);
                            fleBOOKINGS.set_SetValue("BK_BF_TRANSFER", T_BOOK_BAL.Value);
                            T_BOOK_BAL.Value = 0;
                        }
                        else
                        {
                            flePREVIOUS_TRANS.set_SetValue("ENT_VAL", flePREVIOUS_ENT.GetDecimalValue("ENTITLEMENT_BAL") * -1);
                            T_BOOK_BAL.Value = T_BOOK_BAL.Value - flePREVIOUS_ENT.GetDecimalValue("ENTITLEMENT_BAL");
                            fleBOOKINGS.set_SetValue("BK_BF_TRANSFER", flePREVIOUS_ENT.GetDecimalValue("ENTITLEMENT_BAL"));
                            flePREVIOUS_ENT.set_SetValue("ENTITLEMENT_BAL", 0);
                        }
                    }
                    if (QDesign.NULL(T_BOOK_BAL.Value) > 0)
                    {
                        if (QDesign.NULL(T_BOOK_BAL.Value) > QDesign.NULL(D_ALLOWED_OD.Value))
                        {
                            ErrorMessage("52078");
                        }
                        else
                        {
                            if (QDesign.NULL(fleCURRENT_ENTS.GetStringValue("YEAR_123")) == "01" || QDesign.NULL(fleCURRENT_ENTS.GetStringValue("YEAR_123")) == "02")
                            {
                                fleFOLLOWING_ENT.set_SetValue("ENTITLEMENT_BAL", fleFOLLOWING_ENT.GetDecimalValue("ENTITLEMENT_BAL") - T_BOOK_BAL.Value);
                                fleFOLLOWING_TRANS.set_SetValue("ENT_RBAL", fleFOLLOWING_ENT.GetDecimalValue("ENTITLEMENT_BAL"));
                                fleFOLLOWING_ENT.set_SetValue("CB_TRANSFER", fleFOLLOWING_ENT.GetDecimalValue("CB_TRANSFER") + (T_BOOK_BAL.Value * -1));
                                fleFOLLOWING_TRANS.set_SetValue("ENT_VAL", T_BOOK_BAL.Value * -1);
                                fleBOOKINGS.set_SetValue("BK_OVERDRAFT", T_BOOK_BAL.Value);
                            }
                            if (QDesign.NULL(fleCURRENT_ENTS.GetStringValue("YEAR_123")) == "03")
                            {
                                fleCURRENT_ENTS.set_SetValue("ENT_BOOKING_BAL", fleCURRENT_ENTS.GetDecimalValue("ENT_BOOKING_BAL") + (T_BOOK_BAL.Value * -1));
                                fleCURRENT_ENTS.set_SetValue("ENT_OVERDRAFT", fleCURRENT_ENTS.GetDecimalValue("ENT_OVERDRAFT") + (T_BOOK_BAL.Value * -1));
                                fleBOOKING_TRANS.set_SetValue("OD_VAL", (T_BOOK_BAL.Value * -1));
                                fleBOOKING_TRANS.set_SetValue("OD_RBAL", fleBOOKING_TRANS.GetDecimalValue("OD_RBAL") + (T_BOOK_BAL.Value * -1));
                                fleBOOKING_TRANS.set_SetValue("RUNNING_BALANCE", fleBOOKING_TRANS.GetDecimalValue("RUNNING_BALANCE") + (T_BOOK_BAL.Value * -1));
                                fleBOOKINGS.set_SetValue("BK_OVERDRAFT", T_BOOK_BAL.Value);
                            }
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


        private bool Internal_CLEAR_CC_CHARGES()
        {


            try
            {

                if (QDesign.NULL(flePURCHASE_DEBTS.GetDecimalValue("DEBT_AMOUNT")) != 0)
                {
                    T_PAY_PURC_PTS.Value = "Y";
                }
                else
                {
                    T_PAY_PURC_PTS.Value = "N";
                }
                T_PAYMENT_METHOD.Value = " ";
                T_TAKE_PAYMENT.Value = " ";
                T_CC_CHARGED.Value = "N";
                fleUCHARGE_DEBTS.set_SetValue("CC_SURCHARGE", 0);
                fleBOOKINGS.set_SetValue("BOOKING_STATUS", T_INITIAL_STATUS.Value);
                if (QDesign.NULL(fleBALANCE_DEBTS.GetDecimalValue("DEBT_AMOUNT")) > 0)
                {
                    fleBALANCE_DEBTS.set_SetValue("CC_SURCHARGE", 0);
                }
                if (QDesign.NULL(T_DEFERRED_FLAG.Value) == "Y")
                {
                    T_CHARGE_PAID.Value = "D";
                }
                else
                {
                    T_CHARGE_PAID.Value = " ";
                }
                Display(ref fldD_FULL_CHARGE);
                Display(ref fldD_PP_CHARGES);
                Display(ref fldD_TOTAL_CHARGE);
                Display(ref fldD_DEPOSIT);
                Display(ref fldT_PAYMENT_METHOD);
                Display(ref fldT_PAY_PURC_PTS);
                Display(ref fldT_PAY_DEPOSIT);
                Display(ref fldT_PAY_USER_CHG);
                Display(ref fldD_PURC_AMT);
                Display(ref fldD_DEPOSIT_AMT);
                Display(ref fldD_USER_CHG_AMT);
                Display(ref fldD_TOT_CARD_AMT);
                Display(ref fldT_TAKE_PAYMENT);
                Display(ref fldBOOKINGS_BOOKING_STATUS);
                Display(ref fldT_CHARGE_PAID);

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


        protected override bool PostFind()
        {


            try
            {

                if (QDesign.NULL(fleM_INVESTORS.GetDecimalValue("STATUS")) == 99)
                {
                    Information("** THIS INVESTOR IS CANCELLED - DO NOT CONFIRM BOOKING **");
                    // TODO: May need to fix manually
                }
                if (QDesign.NULL(fleBOOKINGS.GetStringValue("INVESTOR")) == "999SH")
                {
                    Information("** SHHL (999SH) Booking - use  Confirm SHHL Booking  screen **");
                    // TODO: May need to fix manually
                }
                if (QDesign.NULL(D_BK_ENT_TOT.Value) > QDesign.NULL(D_ENT_ALLOC_TOT.Value) && QDesign.NULL(D_NET_BOOKING.Value) > 0)
                {
                    Warning("32008");
                    T_MAX_ENT_ERROR.Value = "Y";
                    if (QDesign.NULL(fleBOOKINGS.GetDecimalValue("BK_ADDON")) > 0)
                    {
                        Warning("** ADDON POINTS WERE USED.CHECK TOP-UP HAS BEEN MADE.");
                        // TODO: May need to fix manually
                    }
                }
                if (QDesign.NULL(fleBOOKINGS.GetDecimalValue("BK_SUSPENSE")) > QDesign.NULL(fleSUSP_ACCOUNT.GetDecimalValue("SUSP_BAL")))
                {
                    Warning("32009");
                }
                if (QDesign.NULL(fleBOOKINGS.GetDecimalValue("BK_FORF_POINTS")) > QDesign.NULL(fleFORF_ACCOUNT.GetDecimalValue("FORF_BAL")))
                {
                    Warning("32010");
                }
                while (this.For(53))
                {
                    Internal_START_END_CALC();
                }
                // --> GET PURCHASE_DEBTS <--
                flePURCHASE_DEBTS.GetData();
                // --> End GET PURCHASE_DEBTS <--
                if (!AccessOk)
                {
                    T_EXTRA_POINTS.Value = "N";
                    if (QDesign.NULL(fleUCHARGE_DEBTS.GetStringValue("PAYMENT_TYPE")) == "D")
                    {
                        T_PAY_DEPOSIT.Value = "Y";
                        Display(ref fldT_PAY_DEPOSIT);
                    }
                }
                else
                {
                    T_EXTRA_POINTS.Value = "Y";
                    Warning("THERE IS A PURCHASE TO CONFIRM FOR THIS BOOKING");
                    // TODO: May need to fix manually
                    T_PAY_PURC_PTS.Value = "Y";
                    Display(ref fldT_PAY_PURC_PTS);
                }
                T_INITIAL_STATUS.Value = fleBOOKINGS.GetStringValue("BOOKING_STATUS");
                T_UPDATE_FLAG.Value = "N";
                T_START_DAYS.Value = QDesign.Days(fleBOOKINGS.GetDecimalValue("START_DATE"));
                if (QDesign.NULL(fleUCHARGE_DEBTS.GetDecimalValue("DEBT_AMOUNT")) > 0 && QDesign.NULL(T_INSTANT_DELETE.Value) != "Y")
                {
                    if (D_PAY_TIME.Value >= (T_START_DAYS.Value - (QDesign.Days(fleBOOKINGS.GetDecimalValue("BOOKING_DATE")))) || QDesign.NULL(QDesign.Substring(fleBOOKINGS.GetStringValue("GROUPING"), 1, 3)) == "SHH" || QDesign.NULL(fleBOOKINGS.GetDecimalValue("DEPOSIT")) > 0)
                    {
                        T_DEFERRED_FLAG.Value = "N";
                        if (QDesign.NULL(fleUCHARGE_DEBTS.GetDecimalValue("DEBT_AMOUNT")) > 0)
                        {
                            if (QDesign.NULL(fleBALANCE_DEBTS.GetDecimalValue("DEBT_AMOUNT")) == 0)
                            {
                                Warning("32011");
                            }
                            else
                            {
                                Warning("32012");
                            }
                        }
                    }
                    else
                    {
                        T_CHARGE_PAID.Value = "D";
                        T_DEFERRED_FLAG.Value = "Y";
                        Information("42014");
                    }
                }
                if (QDesign.NULL(fleUCHARGE_DEBTS.GetDecimalValue("DEBT_AMOUNT")) > 0 && QDesign.NULL(fleBALANCE_DEBTS.GetDecimalValue("DEBT_AMOUNT")) == 0 && QDesign.NULL(T_CHARGE_PAID.Value) != "D")
                {
                    T_PAY_USER_CHG.Value = "Y";
                }
                if (QDesign.NULL(T_INSTANT_CONF.Value) == "Y" && QDesign.NULL(T_PAY_PURC_PTS.Value) != "Y")
                {
                    dsrDesigner_CF_Click(null,null);
                    PreUpdate();
                    Update();
                    ReturnAndClose();
                }
                if (QDesign.NULL(T_INSTANT_DELETE.Value) == "Y")
                {
                    Delete();
                    Update();
                    ReturnAndClose();
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


        private bool Internal_FINAL_CHECKS()
        {


            try
            {

                if (QDesign.NULL(fleM_INVESTORS.GetDecimalValue("STATUS")) == 99)
                {
                    ErrorMessage("52079");
                }
                if (QDesign.NULL(fleM_INVESTORS.GetStringValue("INVESTOR")) == "999SH")
                {
                    ErrorMessage("52080");
                }
                if (QDesign.NULL(fleM_INVESTORS.GetStringValue("INVESTOR")) == "00011" && QDesign.NULL(fleBOOKINGS.GetStringValue("BOOKING_STATUS")) != "CX" && QDesign.NULL(fleBOOKINGS.GetStringValue("BOOKING_STATUS")) != "RX")
                {
                    ErrorMessage("52081");
                }
                if ((QDesign.NULL(UserID) != "manger" && QDesign.NULL(UserID) != "lesley" && QDesign.NULL(UserID) != "nick" && QDesign.NULL(UserID) != "margie" && QDesign.NULL(UserID) != "juliette" && QDesign.NULL(UserID) != "joan") && QDesign.NULL(QDesign.Substring(fleBOOKINGS.GetStringValue("BOOKING_STATUS"), 2, 1)) == "X" && (QDesign.NULL(fleBOOKING_DETAIL.GetStringValue("FLIGHT_NUMBER")) != QDesign.NULL(" ") || QDesign.NULL(fleBOOKING_DETAIL.GetDecimalValue("FLIGHTS_BOOKED")) != 0))
                {
                    ErrorMessage("52082");
                }
                if (QDesign.NULL(fleBOOKINGS.GetStringValue("BOOKING_STATUS")) != "RS" && QDesign.NULL(fleBOOKINGS.GetStringValue("BOOKING_STATUS")) != "RX")
                {
                    if (QDesign.NULL(D_BK_ENT_TOT.Value) > QDesign.NULL(D_ENT_ALLOC_TOT.Value) && !(QDesign.NULL(T_PAY_PURC_PTS.Value) == "Y" && QDesign.NULL(T_PAY_USER_CHG.Value) == "N" && QDesign.NULL(T_PAY_DEPOSIT.Value) == "N"))
                    {
                        ErrorMessage("52083");
                    }
                    if (QDesign.NULL(fleBOOKINGS.GetDecimalValue("BK_FORF_POINTS")) > QDesign.NULL(fleFORF_ACCOUNT.GetDecimalValue("FORF_BAL")))
                    {
                        ErrorMessage("52084");
                    }
                    if (QDesign.NULL(fleBOOKINGS.GetDecimalValue("BK_SUSPENSE")) > QDesign.NULL(fleSUSP_ACCOUNT.GetDecimalValue("SUSP_BAL")))
                    {
                        ErrorMessage("52085");
                    }
                }
                T_FINAL_CHECKS_DONE.Value = "Y";

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

                if (QDesign.NULL(T_FINAL_CHECKS_DONE.Value) == "N")
                {
                    Internal_FINAL_CHECKS();
                }
                if (QDesign.NULL(fleBOOKINGS.GetStringValue("BOOKING_STATUS")) != "CF" && QDesign.NULL(fleBOOKINGS.GetStringValue("BOOKING_STATUS")) != "OC" && QDesign.NULL(T_DELETE.Value) != "Y")
                {
                    ErrorMessage("52086");
                }
                if (QDesign.NULL(T_TAKE_PAYMENT.Value) != "Y" && QDesign.NULL(T_CHARGE_PAID.Value) != "D" && QDesign.NULL(T_DELETE.Value) != "Y" && QDesign.NULL(D_TOT_CARD_AMT.Value) > 0)
                {
                    if (QDesign.NULL(fleM_INVESTORS.GetStringValue("CUSTOMER_TYPE")) == "I")
                    {
                        ErrorMessage("52087");
                    }
                    else
                    {
                        ErrorMessage("52088");
                    }
                }
                if ((QDesign.NULL(T_PAYMENT_METHOD.Value) == "CC" || QDesign.NULL(T_PAYMENT_METHOD.Value) == "SW") && QDesign.NULL(T_PAID_OK.Value) != "Y")
                {
                    ErrorMessage("52089");
                }
                if (QDesign.NULL(T_CHARGE_PAID.Value) == "Y" && QDesign.NULL(T_PAYMENT_METHOD.Value) == QDesign.NULL(" "))
                {
                    ErrorMessage("52090");
                }
                if (QDesign.NULL(T_CHARGE_PAID.Value) != "Y" && QDesign.NULL(T_PAYMENT_METHOD.Value) != QDesign.NULL(" ") && !(QDesign.NULL(T_OLD_CHARGE_PAID.Value) == "D" && QDesign.NULL(T_CHARGE_PAID.Value) == "D"))
                {
                    ErrorMessage("52091");
                }
                if (QDesign.NULL(T_UPDATE_FLAG.Value) == "Y")
                {
                    ErrorMessage("52092");
                }
                if (QDesign.NULL(fleBOOKINGS.GetStringValue("BOOKING_STATUS")) != "RS" && QDesign.NULL(fleBOOKINGS.GetStringValue("BOOKING_STATUS")) != "RX")
                {
                    if (QDesign.NULL(fleBOOKINGS.GetDecimalValue("BOOKING_CHARGE")) != 0 && QDesign.NULL(T_CHARGE_PAID.Value) != "Y" && QDesign.NULL(T_CHARGE_PAID.Value) != "D")
                    {
                        if (QDesign.NULL(T_EXTRA_POINTS.Value) == "Y")
                        {
                            ErrorMessage("52093");
                        }
                        else
                        {
                            if (QDesign.NULL(fleUCHARGE_DEBTS.GetStringValue("PAYMENT_TYPE")) == "F")
                            {
                                ErrorMessage("52094");
                            }
                            else
                            {
                                ErrorMessage("52095");
                            }
                        }
                    }
                }
                if (QDesign.NULL(fleBOOKINGS.GetStringValue("BOOKING_STATUS")) != "RS" && QDesign.NULL(fleBOOKINGS.GetStringValue("BOOKING_STATUS")) != "RX")
                {
                    // --> GET BOOKING_DETAIL <--

                    fleBOOKING_DETAIL.GetData(GetDataOptions.IsOptional);
                    // --> End GET BOOKING_DETAIL <--
                    fleBOOKING_DETAIL.set_SetValue("AMEND_DATE", QDesign.SysDate(ref m_cnnQUERY));
                    Internal_MARK_CALENDAR();
                    if (QDesign.NULL(T_POINTS_ALLOCATED.Value) == "N")
                    {
                        Internal_ALLOCATE_POINTS();
                    }
                    if ((QDesign.NULL(T_PAID_OK.Value) == "Y" || (QDesign.NULL(T_PAYMENT_METHOD.Value) == "C") || (QDesign.NULL(T_PAYMENT_METHOD.Value) == "CR")))
                    {
                        if (QDesign.NULL(T_PAY_PURC_PTS.Value) == "Y")
                        {
                            flePURCHASE_DEBTS.set_SetValue("DEBT_PAID_DATE", QDesign.SysDate(ref m_cnnQUERY));
                            flePURCHASE_DEBTS.set_SetValue("PAYMENT_METHOD", T_PAYMENT_METHOD.Value);
                        }
                        if (QDesign.NULL(fleBALANCE_DEBTS.GetDecimalValue("DEBT_AMOUNT")) > 0)
                        {
                            if (QDesign.NULL(T_PAY_DEPOSIT.Value) == "Y")
                            {
                                fleUCHARGE_DEBTS.set_SetValue("DEBT_PAID_DATE", QDesign.SysDate(ref m_cnnQUERY));
                                fleUCHARGE_DEBTS.set_SetValue("PAYMENT_METHOD", T_PAYMENT_METHOD.Value);
                                fleBOOKINGS.set_SetValue("DEPOSIT_PAID_DATE", QDesign.SysDate(ref m_cnnQUERY));
                            }
                            if (QDesign.NULL(T_PAY_USER_CHG.Value) == "Y")
                            {
                                fleBALANCE_DEBTS.set_SetValue("DEBT_PAID_DATE", QDesign.SysDate(ref m_cnnQUERY));
                                fleBALANCE_DEBTS.set_SetValue("PAYMENT_METHOD", T_PAYMENT_METHOD.Value);
                            }
                        }
                        else
                        {
                            if (QDesign.NULL(T_PAY_USER_CHG.Value) == "Y")
                            {
                                fleUCHARGE_DEBTS.set_SetValue("DEBT_PAID_DATE", QDesign.SysDate(ref m_cnnQUERY));
                                fleUCHARGE_DEBTS.set_SetValue("PAYMENT_METHOD", T_PAYMENT_METHOD.Value);
                            }
                        }
                    }
                    fleM_INVESTORS.set_SetValue("TRANSACTION_NO", fleM_INVESTORS.GetDecimalValue("TRANSACTION_NO") + 1);
                    fleTRANS_HEADER.set_SetValue("FILLER", fleM_INVESTORS.GetStringValue("INVESTOR") + QDesign.ASCII(fleM_INVESTORS.GetDecimalValue("TRANSACTION_NO"), 6));
                    //Parent:TRANS_ID
                    fleTRANS_HEADER.set_SetValue("TRANS_NO", (fleM_INVESTORS.GetStringValue("INVESTOR") + QDesign.ASCII(fleM_INVESTORS.GetDecimalValue("TRANSACTION_NO"), 6)).PadRight(14).Substring(8, 6));
                    //Parent:TRANS_ID
                    if (QDesign.NULL(fleBOOKINGS.GetDecimalValue("BOOKING_CHARGE")) > 0)
                    {
                        fleBOOKINGS.set_SetValue("TERM_SURCHARGEPER", fleINVESTMENTS.GetDecimalValue("TERM_SURCHARGEPER"));
                        if (QDesign.NULL(T_CHARGE_PAID.Value) == "D")
                        {
                            fleUCHARGE_DEBTS.set_SetValue("DEBT_TYPE", "DP");
                        }
                        else
                        {
                            fleUCHARGE_DEBTS.set_SetValue("DEBT_TYPE", "CP");
                        }
                    }
                    if (QDesign.NULL(T_EXTRA_POINTS.Value) == "Y" && QDesign.NULL(flePURCHASE_DEBTS.GetDecimalValue("DEBT_PAID_DATE")) == 0)
                    {
                        ErrorMessage("52096");
                    }
                }
                else
                {
                    if (QDesign.NULL(fleBOOKINGS.GetStringValue("BOOKING_STATUS")) == "RX")
                    {
                        Internal_UNMARK_CALENDAR();
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

                if (QDesign.NULL(fleBOOKINGS.GetStringValue("BOOKING_STATUS")) != "RS" && QDesign.NULL(fleBOOKINGS.GetStringValue("BOOKING_STATUS")) != "RX")
                {
                    fleM_INVESTORS.PutData();
                    fleBOOKINGS.PutData();
                    fleBOOKING_DETAIL.PutData();
                    fleTRANS_HEADER.PutData();
                    flePREVIOUS_TRANS.PutData();
                    fleFOLLOWING_TRANS.PutData();
                    fleFORFACCT_TRANS.PutData();
                    fleFORF_ACCOUNT.PutData();
                    fleSUSP_TRANS.PutData();
                    fleBOOKING_TRANS.PutData();
                    if (QDesign.NULL(T_EMAIL.Value) == "Y" || QDesign.NULL(fleM_INVESTORS.GetStringValue("CUSTOMER_TYPE")) == "I")
                    {
                        T_RECORD_STATUS.Value = "EC";
                    }
                    else
                    {
                        T_RECORD_STATUS.Value = "CF";
                    }
                    fleBOOKING_LETTERS.PutData(true);
                    if (QDesign.NULL(T_CORR_EXISTS.Value) == "Y" && QDesign.NULL(T_CORR_EMAIL.Value) != QDesign.NULL(T_EMAIL.Value) && QDesign.NULL(fleM_INVESTORS.GetStringValue("CUSTOMER_TYPE")) != "I")
                    {
                        if (QDesign.NULL(T_CORR_EMAIL.Value) == "Y")
                        {
                            T_RECORD_STATUS.Value = "EC";
                        }
                        else
                        {
                            T_RECORD_STATUS.Value = "CF";
                        }
                        fleBOOKING_LETTERS.PutData(true);
                    }
                    fleCURRENT_ENTS.PutData();
                    flePREVIOUS_ENT.PutData();
                    fleFOLLOWING_ENT.PutData();
                    fleSUSP_ACCOUNT.PutData();
                    flePURCHASE_DEBTS.PutData();
                    if (QDesign.NULL(fleBOOKINGS.GetDecimalValue("BOOKING_CHARGE")) > 0)
                    {
                        fleUCHARGE_DEBTS.PutData();
                    }
                    else if (QDesign.NULL(fleBALANCE_DEBTS.GetDecimalValue("DEBT_AMOUNT")) > 0)
                    {
                        fleBALANCE_DEBTS.PutData();
                    }
                    flePROPERTY_YEARS.PutData();
                    while (For(53))
                    {
                        flePROPERTY_YEARS_DTL.PutData();
                    }
                    T_CALLING_SCREEN.Value = "CONFIRM";
                }
                else
                {
                    fleBOOKINGS.PutData();
                    fleCANCEL_BOOKING.PutData();
                    flePROPERTY_YEARS.PutData();
                    while (For(53))
                    {
                        flePROPERTY_YEARS_DTL.PutData();
                    }
                    fleBOOKING_DETAIL.PutData();
                    fleUCHARGE_DEBTS.PutData(false, PutTypes.Deleted);
                    fleBALANCE_DEBTS.PutData(false, PutTypes.Deleted);
                    flePROV_LETTERS.PutData(false, PutTypes.Deleted);
                    fleFLIGHT_REQUEST.PutData(false, PutTypes.Deleted);
                    T_CALLING_SCREEN.Value = "CANCEL";
                }
                T_START_DATE.Value = fleBOOKINGS.GetDecimalValue("START_DATE");
                T_END_DATE.Value = fleBOOKINGS.GetDecimalValue("END_DATE");
                object[] arrRunscreen = { flePROPERTY_YEARS, fleBOOKING_PERIODS, T_START_DATE, T_END_DATE, T_ERROR_FLAG, T_UPDATE_LINKED, T_CALLING_SCREEN };
                RunScreen(new BOOKLINK(), RunScreenModes.NoneSelected, ref arrRunscreen);
                if (QDesign.NULL(T_ERROR_FLAG.Value) == "Y")
                {
                    Severe("52097");
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


        protected override bool Delete()
        {


            try
            {
                //TODO: May need to remove loop construct that sets "DeletedRecord" for occuring files

                Warning("32013");
                Accept(ref fldT_DELETE);
                if (QDesign.NULL(T_DELETE.Value) != "Y")
                {
                    T_INSTANT_DELETE.Value = T_DELETE.Value;
                    Severe("52098");
                }
                if (QDesign.NULL(fleBOOKINGS.GetStringValue("BOOKING_STATUS")) == "CF" || QDesign.NULL(fleBOOKINGS.GetStringValue("BOOKING_STATUS")) == "IC")
                {
                    ErrorMessage("52099");
                }
                if ((QDesign.NULL(UserID) != "manger" && QDesign.NULL(UserID) != "nick" && QDesign.NULL(UserID) != "margie" && QDesign.NULL(UserID) != "lesley" && QDesign.NULL(UserID) != "marina" && QDesign.NULL(UserID) != "juliette" && QDesign.NULL(UserID) != "joan"))
                {
                    if (QDesign.NULL(fleBOOKING_DETAIL.GetStringValue("FLIGHT_NUMBER")) != QDesign.NULL(" ") || QDesign.NULL(fleBOOKING_DETAIL.GetDecimalValue("FLIGHTS_BOOKED")) != 0)
                    {
                        ErrorMessage("52100");
                    }
                    if (QDesign.NULL(fleBOOKINGS.GetDecimalValue("BK_ADDON")) > 0)
                    {
                        ErrorMessage("52101");
                    }
                }
                fleBOOKING_DETAIL.set_SetValue("AMEND_DATE", QDesign.SysDate(ref m_cnnQUERY));
                fleBOOKINGS.set_SetValue("BOOKING_STATUS", "RX");
                fleCANCEL_BOOKING.set_SetValue("BOOKING_REF", fleBOOKINGS.GetStringValue("BOOKING_REF"));
                fleCANCEL_BOOKING.set_SetValue("CANCEL_DATE", QDesign.SysDate(ref m_cnnQUERY));
                fleCANCEL_BOOKING.set_SetValue("CANCEL_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);
                fleCANCEL_BOOKING.set_SetValue("USER_ID", fleUSER_SEC_FILE.GetDecimalValue("USER_ID"));
                fleCANCEL_BOOKING.set_SetValue("USER_LOGON", UserID);
                fleCANCEL_BOOKING.set_SetValue("RECORD_STATUS", "RX");
                Display(ref fldBOOKINGS_BOOKING_STATUS);
                // --> GET PROV_LETTERS <--

                flePROV_LETTERS.GetData(GetDataOptions.IsOptional);
                // --> End GET PROV_LETTERS <--
                flePROV_LETTERS.DeletedRecord = true;
                fleUCHARGE_DEBTS.DeletedRecord = true;
                fleBALANCE_DEBTS.DeletedRecord = true;
                // --> GET FLIGHT_REQUEST <--

                fleFLIGHT_REQUEST.GetData(GetDataOptions.IsOptional);
                // --> End GET FLIGHT_REQUEST <--
                fleFLIGHT_REQUEST.DeletedRecord = true;
                Information("42015");

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



        private void dsrDesigner_X_Click(object sender, System.EventArgs e)
        {

            try
            {

                T_BOOKING_REF.Value = fleBOOKINGS.GetStringValue("BOOKING_REF");
                T_START_DATE.Value = fleBOOKINGS.GetDecimalValue("START_DATE");
                T_NEW_BOOKING.Value = "N";
                //RunScreen("BOOKDETS.QKC", RunScreenModes.Find, flePROPERTIES, T_NEW_BOOKING, T_BOOKING_REF, T_START_DATE, T_OK, T_WEB_BOOKING);
                T_BOOKING_REF.Value = " ";


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_WAIT_Click(object sender, System.EventArgs e)
        {

            try
            {

                T_PASS_LOCATION.Value = fleBOOKINGS.GetStringValue("LOCATION");
                T_PASS_INVESTOR.Value = fleBOOKINGS.GetStringValue("INVESTOR");
                T_PASS_SCREEN.Value = "CANX";
                T_PASS_DATE.Value = fleBOOKINGS.GetDecimalValue("START_DATE");
                T_END_DATE.Value = fleBOOKINGS.GetDecimalValue("END_DATE");
                //RunScreen("WAITLIST.QKC", RunScreenModes.Find, T_PASS_LOCATION, T_PASS_INVESTOR, T_PASS_SCREEN, T_PASS_DATE, T_END_DATE);
                Information("42016");


            }
            catch (CustomApplicationException ex)
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

                if (QDesign.NULL(T_CONFIRM_REF.Value) != QDesign.NULL(" "))
                {
                    m_intPath = 1;
                }
                if (m_intPath == 0)
                {
                    RequestPrompt(ref fldBOOKINGS_BOOKING_REF);
                    if (m_blnPromptOK)
                    {
                        m_intPath = 2;
                    }
                }
                if (m_intPath == 0)
                {
                    RequestPrompt(ref fldBOOKINGS_INVESTOR);
                    if (m_blnPromptOK)
                    {
                        m_intPath = 3;
                    }
                }
                if (m_intPath == 0)
                {
                    m_intPath = 4;
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

                if (m_intPath == 1)
                {
                    bool blnAddWhere = true;
                    m_strWhere = new StringBuilder(GetWhereCondition("BOOKINGS.BOOKING_REF", T_CONFIRM_REF.Value, ref blnAddWhere));
                    fleBOOKINGS.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);

                }
                if (m_intPath == 2)
                {
                    bool blnAddWhere = true;
                    m_strWhere = new StringBuilder(GetWhereCondition("BOOKINGS.BOOKING_REF", fleBOOKINGS.GetStringValue("BOOKING_REF"), ref blnAddWhere));
                    fleBOOKINGS.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);

                }
                if (m_intPath == 3)
                {
                    bool blnAddWhere = true;
                    m_strWhere = new StringBuilder(GetWhereCondition("BOOKINGS.INVESTOR", fleBOOKINGS.GetStringValue("INVESTOR"), ref blnAddWhere));
                    fleBOOKINGS.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);

                }
                if (m_intPath == 4)
                {
                    fleBOOKINGS.GetData(GetDataOptions.CreateSubSelect | GetDataOptions.Sequential);

                }

                if (QDesign.NULL(fleBOOKINGS.GetStringValue("BOOKING_STATUS")) == "CX" || QDesign.NULL(fleBOOKINGS.GetStringValue("BOOKING_STATUS")) == "CP" || QDesign.NULL(fleBOOKINGS.GetStringValue("BOOKING_STATUS")) == "OX")
                {
                    ErrorMessage("52102");
                }
                if (QDesign.NULL(fleBOOKINGS.GetStringValue("BOOKING_STATUS")) == "CF" || QDesign.NULL(fleBOOKINGS.GetStringValue("BOOKING_STATUS")) == "OC")
                {
                    ErrorMessage("52103");
                }
                if (QDesign.NULL(fleBOOKINGS.GetStringValue("BOOKING_STATUS")) != "RS" && QDesign.NULL(fleBOOKINGS.GetStringValue("BOOKING_STATUS")) != "OR")
                {
                    ErrorMessage("52104");
                }

                fleBOOKING_DETAIL.GetData(GetDataOptions.IsOptional);

                flePROPERTIES.GetData(GetDataOptions.IsOptional);

                fleCOLOUR_RATES.GetData(GetDataOptions.IsOptional);

                fleINVESTMENTS.GetData(GetDataOptions.IsOptional);

                fleCURRENT_ENTS.GetData(GetDataOptions.IsOptional);

                flePREVIOUS_ENT.GetData(GetDataOptions.IsOptional);

                fleFOLLOWING_ENT.GetData(GetDataOptions.IsOptional);

                fleSUSP_ACCOUNT.GetData(GetDataOptions.IsOptional);

                fleFORF_ACCOUNT.GetData(GetDataOptions.IsOptional);

                fleANNUAL_ENT.GetData(GetDataOptions.IsOptional);

                fleM_INVESTORS.GetData(GetDataOptions.IsOptional);

                fleUCHARGE_DEBTS.GetData(GetDataOptions.IsOptional);

                fleBALANCE_DEBTS.GetData(GetDataOptions.IsOptional);

                if (AccessOk)
                {
                    T_BALANCE_DEBTS.Value = "Y";
                }
                else
                {
                    T_BALANCE_DEBTS.Value = "N";
                }
                fleBOOKING_PERIODS.GetData(GetDataOptions.IsOptional);

                m_strWhere = new StringBuilder(" WHERE ");
                m_strWhere.Append(" ").Append(fleBOOKING_PERIODS_DTL.ElementOwner("LOCATION")).Append(" = ");
                m_strWhere.Append(Common.StringToField(fleBOOKINGS.GetStringValue("LOCATION")));
                m_strWhere.Append(" AND ").Append(" ").Append(fleBOOKING_PERIODS_DTL.ElementOwner("CHANGEOVER_DAY")).Append(" = ");
                m_strWhere.Append(Common.StringToField(flePROPERTIES.GetStringValue("CHANGEOVER_DAY")));
                m_strWhere.Append(" AND ").Append(" ").Append(fleBOOKING_PERIODS_DTL.ElementOwner("YEAR")).Append(" = ");
                m_strWhere.Append(Common.StringToField(fleBOOKINGS.GetStringValue("YEAR")));
                fleBOOKING_PERIODS_DTL.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);

                flePROPERTY_YEARS.GetData(GetDataOptions.IsOptional);

                m_strWhere = new StringBuilder(" WHERE ");
                m_strWhere.Append(" ").Append(flePROPERTY_YEARS_DTL.ElementOwner("LOCATION")).Append(" = ");
                m_strWhere.Append(Common.StringToField(fleBOOKINGS.GetStringValue("LOCATION")));
                m_strWhere.Append(" AND ").Append(" ").Append(flePROPERTY_YEARS_DTL.ElementOwner("BEDS")).Append(" = ");
                m_strWhere.Append(Common.StringToField(fleBOOKINGS.GetStringValue("BEDS")));
                m_strWhere.Append(" AND ").Append(" ").Append(flePROPERTY_YEARS_DTL.ElementOwner("PROPERTY_STYLE")).Append(" = ");
                m_strWhere.Append(Common.StringToField(fleBOOKINGS.GetStringValue("PROPERTY_STYLE")));
                m_strWhere.Append(" AND ").Append(" ").Append(flePROPERTY_YEARS_DTL.ElementOwner("BATHROOMS")).Append(" = ");
                m_strWhere.Append(Common.StringToField(fleBOOKINGS.GetStringValue("BATHROOMS")));
                m_strWhere.Append(" AND ").Append(" ").Append(flePROPERTY_YEARS_DTL.ElementOwner("PROPERTY_ID")).Append(" = ");
                m_strWhere.Append(Common.StringToField(fleBOOKINGS.GetStringValue("PROPERTY_ID")));
                m_strWhere.Append(" AND ").Append(" ").Append(flePROPERTY_YEARS_DTL.ElementOwner("YEAR")).Append(" = ");
                m_strWhere.Append(Common.StringToField(fleBOOKINGS.GetStringValue("YEAR")));

                flePROPERTY_YEARS_DTL.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional | GetDataOptions.CreateRecordsForOccurs);

                fleUSER_SEC_FILE.GetData(GetDataOptions.IsOptional);

                fleEMAILS.GetData(GetDataOptions.IsOptional);

                if (AccessOk)
                {
                    T_EMAIL.Value = "Y";
                }
                else
                {
                    T_EMAIL.Value = "N";
                }
                fleCORR_ADDRESS.GetData(GetDataOptions.IsOptional);

                if (AccessOk)
                {
                    T_CORR_EXISTS.Value = "Y";
                    if (QDesign.NULL(fleCORR_ADDRESS.GetStringValue("EMAIL")) == QDesign.NULL(" "))
                    {
                        T_CORR_EMAIL.Value = "N";
                    }
                    else
                    {
                        T_CORR_EMAIL.Value = "Y";
                    }
                }
                else
                {
                    T_CORR_EXISTS.Value = "N";
                    T_CORR_EMAIL.Value = "N";
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



        private void dsrDesigner_CF_Click(object sender, System.EventArgs e)
        {

            try
            {

                fleBOOKINGS.set_SetValue("BOOKING_STATUS", "CF");


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }


        private bool Internal_RESET_CC_SURCHARGE_ETC()
        {


            try
            {

                if (QDesign.NULL(fleUCHARGE_DEBTS.GetDecimalValue("DEBT_AMOUNT")) > 0)
                {
                    fleUCHARGE_DEBTS.set_SetValue("CC_SURCHARGE", 0);
                }
                if (QDesign.NULL(fleBALANCE_DEBTS.GetDecimalValue("DEBT_AMOUNT")) > 0)
                {
                    fleBALANCE_DEBTS.set_SetValue("CC_SURCHARGE", 0);
                }
                if (QDesign.NULL(flePURCHASE_DEBTS.GetDecimalValue("DEBT_AMOUNT")) > 0)
                {
                    flePURCHASE_DEBTS.set_SetValue("CC_SURCHARGE", 0);
                }
                if (QDesign.NULL(T_PAY_PURC_PTS.Value) == "Y")
                {
                    flePURCHASE_DEBTS.set_SetValue("CC_SURCHARGE", T_PURC_CC_SUR.Value);
                }
                if (QDesign.NULL(T_PAY_DEPOSIT.Value) == "Y")
                {
                    fleUCHARGE_DEBTS.set_SetValue("CC_SURCHARGE", T_DEP_CC_SUR.Value);
                }
                if (QDesign.NULL(T_PAY_USER_CHG.Value) == "Y")
                {
                    if (QDesign.NULL(T_BALANCE_DEBTS.Value) == "N")
                    {
                        fleUCHARGE_DEBTS.set_SetValue("CC_SURCHARGE", T_UCHG_CC_SUR.Value);
                    }
                    else
                    {
                        fleBALANCE_DEBTS.set_SetValue("CC_SURCHARGE", T_UCHG_CC_SUR.Value);
                    }
                }
                Display(ref fldT_PAYMENT_METHOD);
                Display(ref fldD_PURC_AMT);
                Display(ref fldD_DEPOSIT_AMT);
                Display(ref fldD_USER_CHG_AMT);
                Display(ref fldD_TOT_CARD_AMT);

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



        private void dsrDesigner_02_Click(object sender, System.EventArgs e)
        {

            try
            {

                Internal_FINAL_CHECKS();
                if (QDesign.NULL(T_MAX_ENT_ERROR.Value) == "Y")
                {
                    ErrorMessage("52105");
                }
                if (QDesign.NULL(T_POINTS_ALLOCATED.Value) == "N")
                {
                    Internal_ALLOCATE_POINTS();
                }
                if (QDesign.NULL(T_CHARGE_PAID.Value) == "D")
                {
                    T_OLD_CHARGE_PAID.Value = "D";
                }
                Accept(ref fldT_CHARGE_PAID);
                if (QDesign.NULL(fleM_INVESTORS.GetStringValue("CUSTOMER_TYPE")) == "I" && QDesign.NULL(T_CHARGE_PAID.Value) != "D")
                {
                    ErrorMessage("52106");
                }
                if (QDesign.NULL(T_CHARGE_PAID.Value) == "D" && QDesign.NULL(T_OLD_CHARGE_PAID.Value) != "D")
                {
                    if ((QDesign.NULL(QDesign.Substring(flePROPERTIES.GetStringValue("GROUPING"), 1, 3)) == "TEN" || QDesign.NULL(QDesign.Substring(flePROPERTIES.GetStringValue("GROUPING"), 1, 3)) == "SHH") && QDesign.NULL(fleM_INVESTORS.GetStringValue("CUSTOMER_TYPE")) != "I")
                    {
                        ErrorMessage("52107");
                    }
                    T_PAY_USER_CHG.Value = "N";
                    Display(ref fldT_PAY_USER_CHG);
                    Display(ref fldT_PAY_USER_CHG);
                    Display(ref fldD_USER_CHG_AMT);
                    Display(ref fldD_TOT_CARD_AMT);
                    T_OLD_CHARGE_PAID.Value = "D";
                    Information("42017");
                }
                if (QDesign.NULL(T_CHARGE_PAID.Value) == "Y" && QDesign.NULL(D_TOT_CARD_AMT.Value) > 0)
                {
                    Accept(ref fldT_PAYMENT_METHOD);
                    if (QDesign.NULL(flePURCHASE_DEBTS.GetDecimalValue("DEBT_AMOUNT")) != 0)
                    {
                        if (QDesign.NULL(T_PAY_PURC_PTS.Value) != "Y")
                        {
                            T_PAY_PURC_PTS.Value = "Y";
                            Display(ref fldT_PAY_PURC_PTS);
                        }
                        if (QDesign.NULL(fleBALANCE_DEBTS.GetDecimalValue("DEBT_AMOUNT")) > 0)
                        {
                            Accept(ref fldT_PAY_DEPOSIT);
                        }
                    }
                    if (QDesign.NULL(fleBALANCE_DEBTS.GetDecimalValue("DEBT_AMOUNT")) > 0 && QDesign.NULL(flePURCHASE_DEBTS.GetDecimalValue("DEBT_AMOUNT")) == 0)
                    {
                        T_PAY_DEPOSIT.Value = "Y";
                        Display(ref fldT_PAY_DEPOSIT);
                    }
                    if (QDesign.NULL(T_DEFERRED_FLAG.Value) == "N")
                    {
                        if (QDesign.NULL(T_PAY_PURC_PTS.Value) == "N" && QDesign.NULL(T_PAY_DEPOSIT.Value) == "N" && QDesign.NULL(T_PAY_USER_CHG.Value) == "N")
                        {
                            T_CHARGE_PAID.Value = "N";
                            Internal_CLEAR_CC_CHARGES();
                        }
                    }
                    if ((QDesign.NULL(T_PAID_OK.Value) == "N" || QDesign.NULL(T_INSTANT_CONF.Value) == "Y") && (QDesign.NULL(T_PAY_DEPOSIT.Value) == "Y" || QDesign.NULL(T_PAY_USER_CHG.Value) == "Y" || QDesign.NULL(T_PAY_PURC_PTS.Value) == "Y"))
                    {
                        Internal_TAKE_PAYMENT_METHOD();
                        T_INVESTOR.Value = fleBOOKINGS.GetStringValue("INVESTOR");
                        T_BOOK_REF.Value = fleBOOKINGS.GetStringValue("BOOKING_REF");
                        Display(ref fldD_DEPOSIT_AMT);
                        Display(ref fldD_USER_CHG_AMT);
                        Display(ref fldD_TOT_CARD_AMT);
                        Accept(ref fldT_TAKE_PAYMENT);
                        if (QDesign.NULL(T_TAKE_PAYMENT.Value) == "Y")
                        {
                            if (QDesign.NULL(D_TOT_CARD_AMT.Value) == 0)
                            {
                                T_CHARGE_PAID.Value = "N";
                                Internal_CLEAR_CC_CHARGES();
                                ErrorMessage("52108");
                            }
                            if (QDesign.NULL(fleBALANCE_DEBTS.GetDecimalValue("DEBT_AMOUNT")) > 0 && QDesign.NULL(T_PAY_DEPOSIT.Value) == "N")
                            {
                                ErrorMessage("52109");
                            }
                            T_CARD_CC_SURPER.Value = D_CC_SURCHARGEPER.Value;
                            T_PAID_OK.Value = "N";
                            T_REASON.Value = (D_PURC_REASON.Value).TrimEnd() + D_DEP_REASON.Value.TrimEnd() + D_UCHG_REASON.Value;
                            T_PURC_AMT.Value = D_PASS_PURC.Value;
                            T_DEP_AMT.Value = D_PASS_DEPOSIT.Value;
                            T_UCHG_AMT.Value = D_PASS_USER_CHG.Value;
                            T_PURC_CC_SUR.Value = 0;
                            T_DEP_CC_SUR.Value = 0;
                            T_UCHG_CC_SUR.Value = 0;
                            T_PAYMENT_TYPE.Value = D_PAYMENT_TYPE.Value;
                            //RunScreen("TAKEPAY.QKC", RunScreenModes.Entry, T_INVESTOR, T_BOOK_REF, T_HPB_CODE, T_CARD_CC_SURPER, T_REASON, T_PAYMENT_METHOD, T_PAYMENT_TYPE, T_PURC_AMT,
                            //T_DEP_AMT, T_UCHG_AMT, T_PURC_CC_SUR, T_DEP_CC_SUR, T_UCHG_CC_SUR, T_PAID_OK, T_PASS_NAME, T_PASS_CARDNO, T_PASS_ISSUE, T_PASS_VFROM,
                            //T_PASS_EXPDATE, T_PASS_SEC);
                            if (QDesign.NULL(T_PAID_OK.Value) != "Y" && QDesign.NULL(T_PAID_OK.Value) != "N")
                            {
                                Information("Incorrect card status returned (" + T_PAID_OK.Value + ") - Please inform IT immediately");
                                // TODO: May need to fix manually
                            }
                            if (QDesign.NULL(T_PAID_OK.Value) == "Y")
                            {
                                Internal_RESET_CC_SURCHARGE_ETC();
                                fleBOOKINGS.set_SetValue("BOOKING_STATUS", "CF");
                                Display(ref fldBOOKINGS_BOOKING_STATUS);
                                Push(PushTypes.Update);
                                // TODO: May require manual processes (PUSH verb).
                                T_UPDATE_FLAG.Value = "N";
                                Information("42018");
                            }
                            else
                            {
                                Information("42019");
                                T_CHARGE_PAID.Value = "N";
                                Internal_CLEAR_CC_CHARGES();
                            }
                        }
                        else
                        {
                            T_CHARGE_PAID.Value = "N";
                            Internal_CLEAR_CC_CHARGES();
                        }
                    }
                    if (QDesign.NULL(T_OLD_CHARGE_PAID.Value) == "D")
                    {
                        T_CHARGE_PAID.Value = "D";
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



        private void dsrDesigner_CORE_USER_Click(object sender, System.EventArgs e)
        {

            try
            {

                if (QDesign.NULL(T_PAY_USER_CHG.Value) == "Y")
                {
                    T_PAY_USER_CHG.Value = "N";
                }
                else
                {
                    T_PAY_USER_CHG.Value = "Y";
                }
                Display(ref fldT_PAY_USER_CHG);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }

        //#CORE_BEGIN_INCLUDE: SCRNVSTU.USE"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 07/12/2013 1:48:25 PM


        protected override bool Initialize()
        {
            
            
                
                object[] arrRunscreen = { T_SCREEN_NAME };
                RunScreen(new SCRNVST(), RunScreenModes.Entry, ref arrRunscreen);

                return true;

           

        }

        //#CORE_END_INCLUDE: SCRNVSTU.USE"




        public override void PagePostProcess(PageArgs e)
        {

           
                Page.PageTitle = "C O N F I R M    B O O K I N G";



            

        }


        #endregion

        #endregion

    }

}
