
#region "Screen Comments"

// ---------------------------------------------------------------;
// ;
// SYSTEM;       H P B  Booking system                         ;
// ;
// PROGRAM;      BOOK0300                                      ;
// ;
// TASK;      WRITES PROVISIONAL BOOKING AWAITING CONFIRMATION ;
// ;
// FILES:        BOOKINGS                                      ;
// BOOKING-LETTERS                               ;
// CHARGES                                       ;
// COLOUR-RATES                                  ;
// BOOKING-PERIODS                               ;
// LOCATIONS                                     ;
// ;
// ;
// SCREENS:                                                    ;
// CALLED BY:    BOOK0200    RESORT SELECT PROPERTY SCREEN     ;
// CALLING:      BOOK0400    PURCHASE POINTS SCREEN            ;
// ;
// SUBSCREENS:   BOOKDETS                                      ;
// SHORTFAL                                      ;
// SELECTOD                                      :
// ;
// SUBPROGRAMS;  <<NONE>>                                      ;
// ;
// ---------------------------------------------------------------;
// *A*     TEMPORARY CODE TO APPLY DISCOUNT TO USER CHARGE FOR   ;
// SPECIFIC LOCATIONS                                    ;
// RJC     19/04/93                                              ;
// ~~~~~~~~~~~~~~~~                                 ;
// ;
// WJC    01/11/93            REPLACED WARNING MESSAGE WITH      ;
// NEW FIELD, `d-due-now-message` AS  ;
// REQUESTED...                       ;
// ;
// WJC    17/12/93            MAJOR CHANGES TO HANDLE THE        ;
// USER CHARGE CALCULATION.           ;
// TWO MAIN CALCULATIONS DEPENDING   ;
// ON THE FOLLOWING CONDITIONS :-     ;
// I) FOR BOOKING of MORE THAN      ;
// 6 DAYS.                       ;
// II) FOR BOOKING of LESS THAN      ;
// 6 DAYS.                       ;
// ;
// WJC    13/01/94            RECORRECTED D-UNDER-A-WEEK.        ;
// INCREASED STORAGE SIZE FOR T-CHARGE;
// AND T-WEEKLY-RATE.                 ;
// ADDED INPUT PROC. FOR T-END-DATE   ;
// BECAUSE TEMP ITEMS WERE NOT RESET  ;
// TO 0 WHEN USER DECIDED TO CORRECT  ;
// THE DATES.                         ;
// ;
// ---------------------------------------------------------------;
// 14/09/94 - ADD `CLOSE` TO ALL FILE STATEMENTS                  ;
// ----------------------------------------------------------------
// 09/02/95 - ALLWAYS CREATE A BOOKING DETAIL RECORD
// ----------------------------------------------------------------
// /03/95 - NEVER CREATE A BOOKING DETAIL RECORD IN THIS SCREEN !!
// ----------------------------------------------------------------
// 27/07/95 - Silver bondholders FORF-ACCOUNT now contains their oldge
// BF-BAL * 1.5  so adjustments to points no longer have to
// made and the user-charge payable is calculated using the
// percentage of FORF-ACCOUNT points used.
// ----------------------------------------------------------------
// 15/08/95 - Call the new rma Flights screen FLIGHTAV if there are
// flights going to the booking Location on that date.
// -----------------------------------------------------------------
// 30/08/95 - Changed USER-SEC-FILE form DESIGNER to MASTER and
// removed code that got it.
// ------------------------------------------------------------------
// 10/10/95 - Pass new temp field T-NEW-BOOKING( Y ) to BOOKDETS.qkc
// -------------------------------------------------------------------
// 24/10/95 - Split week BOOKINGS charge 55% points 65% user-charge.
// -------------------------------------------------------------------
// 24/10/95 - removed procedure CHARGE-BY-DATE which was really just a
// copy of CALC-UCHARGE-POINTS that also called PART-CHARGE.
// PART-CHARGE is now called by CALC-UCHARGE-POINTS.
// --------------------------------------------------------------------
// 21/11/95 - before calling new screen FLIGHTAV, check to see if
// there is a flight to that location for that date.
// --------------------------------------------------------------------
// 23/11/95 - Narrow Boats - multiply points by 220% for Silver.
// --------------------------------------------------------------------
// 27/11/96 - display COLOUR on screen.
// --------------------------------------------------------------------
// 04/03/96 - Split-week fishing BOOKINGS charged at 1/7th per day
// --------------------------------------------------------------------
// 22/05/96 - Removed field ENT-YEAR as it has never displayed correctly.
// --------------------------------------------------------------------
// 15/07/96 - Siver bondholders to pay full user-charge for tennancies
// regardless of wether Forf-Account points are used.
// ---------------------------------------------------------------------
// 22/09/96 - Create BOOKING-DEBTS record and set exchange-rate.
// ---------------------------------------------------------------------
// 30/09/96 - Added field LONG-STAY
// ---------------------------------------------------------------------
// 20/10/96 - Improved layout of the screen
// ---------------------------------------------------------------------
// 26/11/96 - NEEDS SOMTHING LIKE THIS TO WORK !!
// Following the year2000 changes, this sceen had problems with Silver
// Bondholders. Trying to change any fields such as Purchase-Points or
// Long-Stay-Flag gave the error  THERE IS NO DATA  , when there obviously
// is data !!!    THIS MUST BE A POWERHOUSE BUG.   It is somehow loosing
// track of its file pointers/buffers. Setting a field in BOOKINGS seems
// to kick it up the arse and make it remember what its supposed to be
// doing !!  So I set location of BOOKINGS again solely for this purpose.
// --------------------------------------------------------------------
// 02/12/96 - Added `OPEN` statements to CURRENT-ENTS and BOOKING-DEBTS,
// because you sometimes get problems like the one above.
// ----------------------------------------------------------------------
// 11/12/96 - Overdraft for year 3 was subtracting any negative values in
// ent-overdraft, hence adding it !
// ----------------------------------------------------------------------
// 16/12/96 - Set BK-BF-EOY to BF-BAL of CURRENT-ENTS (not BF-FROM-EOY)
// ----------------------------------------------------------------------
// 13/01/97 - Moved code for flight requests to BOOK0500
// ----------------------------------------------------------------------
// 02/02/97 - Don`t allow holidays to start on christmas,boxing day etc.
// ----------------------------------------------------------------------
// 04/02/97 - This screen is now to be used for Royal Court BOOKINGS.
// Don`t update the property calendar for royal court.
// ----------------------------------------------------------------------
// 12/02/97 - NEEDS SOMTHING LIKE THIS TO WORK !!   AGAIN !!!!!!
// Following the Royal court changes,this sceen had problems various
// Bondholders. Trying to change any fields such as Purchase-Points or
// Long-Stay-Flag gave the error  THERE IS NO DATA  , when there obviously
// is data !!!    THIS MUST BE A POWERHOUSE BUG.   It is somehow loosing
// track of its file pointers/buffers. Setting a field in BOOKINGS seems
// to kick it up the arse and make it remember what its supposed to be
// doing !!  So I set location of BOOKINGS again solely for this purpose.
// --------------------------------------------------------------------
// 12/02/97 - don`t display `USER CHARGE DUE  message if charge = 0
// --------------------------------------------------------------------
// 18/02/97 - change CONFIRM-DATE to be 7, 14 or 5 days (re Nick)
// --------------------------------------------------------------------
// 22/04/97 - don`t update calendars for Guards Hotel or Royal Court.
// --------------------------------------------------------------------
// 28/04/97 - changed `3101` to `3112` for `FLORIDA HOLIDAYS CANNOT
// START ON THIS DATE` restriction
// -----------------------------------------------------------------
// 15/05/97 - Moved screen postioning to start at line 25 (was 49)
// -----------------------------------------------------------------
// 13/06/97 - Location  RH  BOOKINGS are allways to be zero points
// -----------------------------------------------------------------
// 04/07/97 - Change hardcoded references to RC and GH to GROUPING  HOTL 
// --------------------------------------------------------------------
// 04/07/97 - ROUND D-PART-POINTS (was floored)
// --------------------------------------------------------------------
// 08/07/97 - Location HK  charge 1/7 points and user-change
// --------------------------------------------------------------------
// 14/07/97 - Display investors 70-day points
// --------------------------------------------------------------------
// 26/08/97 - Allo BOOKINGS for status  T  if user =  theme 
// --------------------------------------------------------------------
// 07/10/97 - Added fields QUALIFY-28DAY and TERM-SURCHARGEPER
// Added info statement for cost of Term points and SURCHARGEPER
// --------------------------------------------------------------------
// 05/11/97 - Added file SPLIT-WEEKS to replace hardcoded split-weeks
// --------------------------------------------------------------------
// 25/11/97 - Removed t-bking-letter , Provisional letters allways required
// except for 28 day BOOKINGS
// --------------------------------------------------------------------
// 01/12/97 - Put back t-bking-letter, but initial value now  Y 
// --------------------------------------------------------------------
// 12/12/97 - Added MARGIE to MANAGER and NICK as user who can book
// `on request` properties
// --------------------------------------------------------------------
// 22/12/97 - Allow BOOKINGS to start on 24/12/97 for location FL
// --------------------------------------------------------------------
// 09/02/98 - Allow BOOKINGS to start 25Dec for HOTLs
// --------------------------------------------------------------------
// 17/03/98 - Corrected ommission of T-POINTS-7 when booking for 7 wks
// --------------------------------------------------------------------
// 17/03/98 - Allow BOOKINGS to start 25Dec for locatin  EP 
// --------------------------------------------------------------------
// 18/04/98 - Added coding to handle the new Term Top-Up surcharges
// --------------------------------------------------------------------
// 07/05/98 - Double BOOKINGS could be made if the user ignored the
// error message when entering the END-WEEK. Changed to
// SEVERE to stop this happening.
// --------------------------------------------------------------------
// 19/05/98 - Call screen UCHARGE2 by entering 99 in action box
// --------------------------------------------------------------------
// 05/08/98 - Dont display term top-up cost if les than �300
// --------------------------------------------------------------------
// 17/12/98 - Dont multiply silver top-up amount by 1.5
// --------------------------------------------------------------------
// 10/08/99 - FIND removed from ativities. No sense in it !
// --------------------------------------------------------------------
// 14/01/99 - setting VAT of booking-debts
// --------------------------------------------------------------------
// 29/09/00 - CHARGES is now accessed via PBK-YEAR-KEY
// --------------------------------------------------------------------
// 06/11/00 - Allow BOOKINGS to start 25Dec for location  MC 
// -------------------------------------------------------------------
// 13/8/02  - Kevin Fuller: Include additional User Charge Bands.
// User-Charge-A to J.
// -----------------------------------------------------------------
// 21/10/02 - remove 10% discount for investor 999SH
// -----------------------------------------------------------------
// 30/12/02 - Removed all but Nick/Manager as those who can book `on
// request` properties - per Nick - IM
// -----------------------------------------------------------------
// 22/01/03 - Added IH to sites where daily rate = 1/7th of week rate
// -----------------------------------------------------------------
// 12/03/03 - only let managers book past dates
// -----------------------------------------------------------------
// 10/04/03 - Sandy no longer temporary  on request  admin - IM
// -----------------------------------------------------------------
// 23.06.03 - add booking-ym  && start-ym to BOOKINGS - ME
// -----------------------------------------------------------------
// 02.07.03 - line 2622.1 added and line 2622 amended again - IM
// -----------------------------------------------------------------
// 15.10.03 - Phil Jackson: Include additional User Charge Bands.
// User-Charge-K to Z.
// -----------------------------------------------------------------
// 30.10.03 - IH   TO HAVE SAME RESTRICTIONS AS  KA  - IM
// -----------------------------------------------------------------
// 31/10/03 - make sure the minimum top-up cost is �250
// -----------------------------------------------------------------
// 06.11.03 - ME   added  sandra  to check list
// -----------------------------------------------------------------
// 13/11/03 - ROB  removed t-bking-letter as it didn`t work!
// (and hence presumably was never used)
// -----------------------------------------------------------------
// 27/11/03 - ROB  set spare-8 of BOOKINGS to grouping of properties
// -----------------------------------------------------------------
// 12/01/04 - ROB  sel <>  S  instead of =  G  because of Diamond
// -----------------------------------------------------------------
// 05.02.04 - ME   add payment check for 90 days for tenancy sites
// -----------------------------------------------------------------
// 25/02/04 - Rob  Changes for SHHL && SHHT type BOOKINGS.
// -----------------------------------------------------------------
// 11/03/04 - Rob  Grouped the code between non-SHHT and SHHT to hopefully
// make it easier to understand. No change in logic.
// -----------------------------------------------------------------
// 11/03/04 - Rob  NB code removed - No longer have any Narrow Boats
// -----------------------------------------------------------------
// 12/03/04 - Rob  Fishing holidays are charged at 1/6th
// -----------------------------------------------------------------
// 12/03/04 - Rob  Removed DESIGNER 02 as there seems no need for it
// -----------------------------------------------------------------
// 17/03/04 - Rob  For SHH part week BOOKINGS, error if not allowed user
// -----------------------------------------------------------------
// 06/04/04 - Rob  Allow sueshhl and deborah to do split weeks and
// on-request BOOKINGS.
// -----------------------------------------------------------------
// 08.04.04 - ME   Add code for Gold to pay �1.10 per point for top-ups
// -----------------------------------------------------------------
// 21.04.04 - ME  Changes top-up  info  to  error  when top-up < �250
// -----------------------------------------------------------------
// 26.04.04 - ME  Stop Silver bond holders user-charge for split weeks
// -----------------------------------------------------------------
// 18/05/04 Stop foreign properties charging VAT by adding extra checks
// on vat-flag of properties
// -----------------------------------------------------------------
// 17/06/03 - d-2-years changed from 731 to 730 as now passed 29th Feb
// -----------------------------------------------------------------
// 24/06/04 - Changed the way the screen sets user-charges re Silver
// bondholders.
// -----------------------------------------------------------------
// 07/07/04 - Added extra checks on d-pay-user-charge, to stop silver
// being charged for split/part weeks during update
// -----------------------------------------------------------------
// 29/07/04 - Display d-due-now (deposit) in proc process booking-charge
// -----------------------------------------------------------------
// 04/08/04 - d-top-up-cost = ceiling((d-top-up-debtx * 1.1)/100) * 100
// -----------------------------------------------------------------
// 06/08/04 - silver were being charged for split-week 70 day BOOKINGS.
// This is because t-use-forf-bal hasn`t been requested yet.
// -----------------------------------------------------------------
// 01.09.04 - Allow numeric part of booking-ref to be over 5 characters.
// -----------------------------------------------------------------
// 15/09/04 - `do internal set-dates` was in both entry-procedure
// and the entry procedure. So removed from entry.
// -----------------------------------------------------------------
// 23.09.04 - Changes to add deposit on selected sites.
// -----------------------------------------------------------------
// 12.10.04 - change spare-8 of bookings to grouping of bookings
// -----------------------------------------------------------------
// 01.11.04 - ME set payment-type of BOOKING-DEBTS (new item)
// -----------------------------------------------------------------
// 09.11.04 - ME fix for missing user charge on SHHT for silver bonds.
// also make new deposit per week (not per booking).
// -----------------------------------------------------------------
// 08.12.04 - ME fix missing vat on booking-debts records.
// -----------------------------------------------------------------
// 19/01/05 - 25% discount if within 21 days
// -----------------------------------------------------------------
// 21/01/05 - book0400 wasn`t being called! So forced get prop-bk-comments
// -----------------------------------------------------------------
// 24/01/01 - Nick requested that checking SHH partweek no longer required
// -----------------------------------------------------------------
// 27.01.05  ME  removed  ,2,near  from vat calculation - as the  ,2 
// was truncating the vat amount and stopping it rounding.
//  ,near  is default anyway. To match rest of system.
// -----------------------------------------------------------------
// 23.03.05  ME  changed list of staff allowed to book  on request 
// properties as per Nick`s request.
// -----------------------------------------------------------------
// 29.03.05  ME  Add Hazel,Sandy && Sandra for all  on request  TR bookings
// Add Hazel for all  on request  VB bookings
// -----------------------------------------------------------------
// 02.06.05  ME  initialise payment-type to  F  for UCHARGE-DEBTS
// as it was not entered if booking-charge = 0
// to allow owner bookings to be made under 999??
// -----------------------------------------------------------------
// 08.06.05  ME  fix for incorrect payment-type= D  when there is no
// balance record (due to closeness of booking date) on
// shht sites - so payment-type should be  F  in this case.
// -----------------------------------------------------------------
// 10/06/05  RC  changed minimum top-up from 250 to 100
// -----------------------------------------------------------------
// 23.08.05  ME  Allow christmas booking for  MR 
// -----------------------------------------------------------------
// 13.09.05  ME  Removed discount code for 999SH as obsolete in this
// program. All 999SH bookings are done in bookshhl.qks.
// -----------------------------------------------------------------
// 30.09.05  ME  Add code to allow use of DEPOSITPER of PROPERTIES.
// -----------------------------------------------------------------
// 07/10/05  RC  Also call book0400 if bk-comment-1 <>    .
// (was just checking bk-comment-2, which seems daft!)
// -----------------------------------------------------------------
// 10/10/05  RC  From 01/01/2006, 21-day-rule bookings only get 15%
// discount, and only applies to non-UK sites
// -----------------------------------------------------------------
// 11/10/05  RC  Added `get locations` to entry procedure. 
// -----------------------------------------------------------------
// 12.10.05  ME  Changed minimum top-up bach to �250 from �100
// -----------------------------------------------------------------
// 15/11/05  RC  Changed the way split-weeks validation is performed.
// Designer procedure SW calls splitwk.qks
// -----------------------------------------------------------------
// 29.11.05  ME  don`t ask for deposit when booking-charge = 0 and
// make sure booking charge is not less than deposit.
// -----------------------------------------------------------------
// 19.12.05  ME  21 day discount scrapped from 16/01/2005 - Nick Beamish
// -----------------------------------------------------------------
// 11.01.06  IM  Allow christmas booking for  GM 
// ----------------------------------------------------------------
// 16/01/06  RC  Added d-uk, to include CTY as part of UK in the 56 day
// points free defintion
// ----------------------------------------------------------------
// 20/02/06  RC  Removed activities CHANGE && DELETE as they seemed to be
// allowing the FIND procedure to work (even though it has
// been commented out for years!) Also, there is no point
// in having change or delete.
// ----------------------------------------------------------------
// 11/04/06 RC  Various changes re vat inclusive pricing (Notional VAT).
// ----------------------------------------------------------------
// 18.04.06 ME  put back SET-DATES into entry procedure as required 
// to display property comments.
// ----------------------------------------------------------------
// 01.06.06 ME  Add new fields for totals on BOOKING-DEBTS
// ----------------------------------------------------------------
// 22/06/06 RC  top-up-cost define changed from ceiling to floor
// ----------------------------------------------------------------
// 14.07.06 ME  add vat to purchase points record. 
// ----------------------------------------------------------------
// 26.07.06 ME  allow long-stay to be set to  S  for Special rates.
// ----------------------------------------------------------------
// 27.07.06 ME  allow entry of fixed-debt flag.
// ----------------------------------------------------------------
// 15.09.06 ME  warn managers booking past dates.
// ----------------------------------------------------------------
// 02.10.06 ME  replace Sandra with Sandy for ON-REQUEST days.
// ----------------------------------------------------------------
// 03.01.07 ME  Allow Wendy to do split weeks and
// ----------------------------------------------------------------
// 29.01.07 ME  Ensure that SHHT && SHHL properties are treated the 
// same now SHHL properties are bookable by bondholders.
// ----------------------------------------------------------------
// 10/04/07 RC  Don`t allow non-diamond to top-up from 30th april
// ----------------------------------------------------------------
// 04.05.07 ME  replace deborah with lesley for ON-REQUEST days.
// ----------------------------------------------------------------
// 10/05/07 RC  Warning for non-diamond top-ups from 30th april
// ----------------------------------------------------------------
// 10/05/07 - Only diamond can top-up, so always �1 per point.
// Removed the old define and replaced with simpler one.
// ----------------------------------------------------------------
// 15/06/07 - DMD designer procedure calling Diamond Conversion Calc
// ----------------------------------------------------------------
// 15/06/07 - added t-holiday to parms passed to ucharge2 in designer UC      
// ----------------------------------------------------------------
// 15/06/07 - display top-up warnings and costs for Diamond conversions       
// ----------------------------------------------------------------
// 27.11.07 IM Zero user charges for `999` (ie Owners) bookings
// ----------------------------------------------------------------
// 14.01.08 ME  VI is charged at 1/7th weekly rate/night for odd nights.
// ----------------------------------------------------------------
// 03.03.08 IM  Change to d-2-years re leap year passed
// -----------------------------------------------------------
// 06.03.08 ME  Add time-stamp to booking-debts records.
// -----------------------------------------------------------
// 27.03.08 ME  Hard coded %rates for location DL. (Sorry).
// -------------------------------------------------------------------
// 03.06.08 ME  Add code to update website data files
// -------------------------------------------------------------------
// 12.09.08 ME  Hold WEB DETAILS to stop website jumping-in while booking.
// -------------------------------------------------------------------
// 10.11.08 ME  Fix to release held property at all times.
// -------------------------------------------------------------------
// 21.11.08 ME  Fix to stop Data expression error when last week of year
// is selected by specific dates.
// -------------------------------------------------------------------
// 27.11.08 PJ  Changed diamond conversion rate from 5.7% to 4.8%
// -------------------------------------------------------------------
// 28.11.08 PJ  VAT20081201 Rate change from 17.5% to 15%
// -----------------------------------------------------------------
// 02.12.08 IM  Julie added to those able to book request-only props
// -----------------------------------------------------------------
// 19.12.08 ME  Deposits are now always requested if start date is more
// than 90 days away, (if less full amount required) for 
// all propeties - Nick Beamish.
// -----------------------------------------------------------------
// 20/01/09 RC  Added starting and closing brackets to make the define
// work correctly.
// -----------------------------------------------------------------
// 21/01/09 RC  Only show forf message if d-forf-points > 0
// -----------------------------------------------------------------
// 27/01/09 RC  Set user charge for silver points free bookings
// Note: we are just about to start a promotion whereby
// various location/property type/weeks are points free.
// -----------------------------------------------------------------
// 30/01/09 ??  There is no longer a bonus for converting to diamond
// -----------------------------------------------------------------
// 10.02.09 ME  Allow Owners to book points && user-charge free.
// -----------------------------------------------------------------
// 11.02.09 ME  Make provision to hold Long Term booking requests.
// ---------------------------------------------------------------------
// 18.02.09 ME  fix check for Silver BH`s booking zero points promo props.
// ---------------------------------------------------------------------
// 14.05.09 me  Allow  GL  (Glen Eagles) to book on 26th Dec.
// ---------------------------------------------------------------------
// 08/07/09 RC  Call the Flights screens bookflts.qkc
// ---------------------------------------------------------------------
// 17.07.09 ME  Fix for problem of silver bonds getting zero charge with
// zero points bookings.
// ---------------------------------------------------------------------
// 28.09.09 ME  Separate Discount version written - book0300.discounts.
// ---------------------------------------------------------------------
// 07.10.09 ME  Get split charges direct from charges file when available.
// ---------------------------------------------------------------------
// 03.11.09 ME  Fix for split weeks not using standard start-dates.
// ---------------------------------------------------------------------
// 17.12.09 ME  temp change: Allow christmas day bookings for Henleys (HL)
// ---------------------------------------------------------------------
// 30.12.09 PJ  VAT20100101 Rate change from 15% to 17.5%
// -----------------------------------------------------------------
// 18/03/10 RC  Don`t INFO or WARN with RESPONSE to avoid problems ***NOT YET
// using QKIN for live web bookings
// -----------------------------------------------------------------
// 05.05.10 ME  Set web-booking flag when a Booking request is booked.
// -----------------------------------------------------------------
// 29.07.10 ME  Stop term surcharge on bookings with no points.
// -----------------------------------------------------------------
// 26/10/10 RC  Call screen booklink.qkc to check linked properties
// -----------------------------------------------------------------
// 16.11.10 ME  Change Long term booking request letter from  L  to  Q 
// -------------------------------------------------------------------
// 17.12.10 PJ  VAT20110104 Rate change from 17.5% to 20%
// -------------------------------------------------------------------
// 17.01.11 RM  Change `Suspense` to `Special Reserve`
// -------------------------------------------------------------------
// 25.05.11 RC  Changed messages for bk-addon top-ups to suit new
// Gold/Diamond rules.
// Made input/edit of bk-addon more logical.
// -------------------------------------------------------------------
// 17.08.11 ME  Send booking ref to webtots.qkc 
// -------------------------------------------------------------------
// 11.10.11 ME  Change to points allocation for Dec 2011. To use brought
// forward points before entitlement bal for year 1 bookings.
// -------------------------------------------------------------------
// 14.12.11 RC  Info warning if long-stay =  S                           
// -------------------------------------------------------------------
// 15.12.11 RC  Don`t override whatever has been entered in fixed-debt
// with an item statement.
// -------------------------------------------------------------------
// 25.01.12 ME  Changed for customer-type  I  (Interval International).
// -------------------------------------------------------------------
// 06.02.12 ME  Allow Lesley Gaugh to book on-request in Sandy`s absence.
// -------------------------------------------------------------------
// 08.02.12 ME  Charge �30 deposit for BOGOF deal - points free when 
// adjustment made.
// -------------------------------------------------------------------
// 06.03.12 ME  Charge �30 deposit for points-free in advance bookings.
// -------------------------------------------------------------------
// 11.04.12 ME  Start and end year added to LOCATION-CURR file.
// -------------------------------------------------------------------
// 11.07.12 ME  Set total-charge on BOOKING-DEBTS records.
// -------------------------------------------------------------------
// 18.09.12 ME  Allow jenny to book on-request hols in sandy`s absence.
// -------------------------------------------------------------------
// 18.09.12 RM  Add scrnvst to record visit to this screen
// -------------------------------------------------------------------
// 23.10.12 RM  Remove scrnvst here, too many visits
// -------------------------------------------------------------------
// 24.10.12 IM  Remove Jenny`s `on-request` capability - per Twink/Jenny
// -------------------------------------------------------------------
// 20.11.12 ME  The new percentages for 27th Nov 2012: 
// 21 day rule formula:   30% for 1 night becomes   20%
// 45% for 2 nights          35%
// 60% for 3 nights          50%
// 70% for 4 nights          65%
// 80% for 5 nights stays at 80%
// 90% for 6 nights          90%
// -------------------------------------------------------------------
// 03.12.12 IM  Replace sueshhl with sally
// -------------------------------------------------------------------
// 05.12.12 ME  Allow specific LY and TT bookings on Boxing day.
// -------------------------------------------------------------------
// 05.12.12 ME  New dates for �30 BOGOF (points-free) deposit. Nick.
// -------------------------------------------------------------------
// 17.12.12 ME  Don`t allow Lesley Gough to book on-request properties.
// also take  Sandy  out, as she has retired.
// -------------------------------------------------------------------
// 17.12.12 ME  Lesley wants previus change reversed.
// -------------------------------------------------------------------
// 19.02.13 PJ  Marina to book on-request properties
// -------------------------------------------------------------------
// ;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;  FIND,  10/08/99
// ;;;20/02/06                           CHANGE,  &
// ;;;20/02/06                           DELETE &
// WHY IS THIS SCREEN AUTORETURN ???????
// Because they usually just UPDATE  not  UPDATE RETURN.

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

    partial class BOOK0300 : BasePage
    {

        #region " Form Designer Generated Code "





        public BOOK0300()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "BOOK0300";

            //# Set the ACTIVITIES for the screen.
            this.ChangeActivity = false;
            this.FindActivity = false;
            this.DeleteActivity = false;
            this.EntryActivity = true;
            this.AutoReturn = true;
            this.UseAcceptProcessing = true;



        }

        #endregion

        private void Page_Load(object sender, RoutedEventArgs e)
        {
            SetVariables();
            dsrDesigner_09.Click += dsrDesigner_09_Click;
            dsrDesigner_01.Click += dsrDesigner_01_Click;
            dsrDesigner_INV.Click += dsrDesigner_INV_Click;
            dsrDesigner_PROP.Click += dsrDesigner_PROP_Click;
            dsrDesigner_COMM.Click += dsrDesigner_COMM_Click;
            dsrDesigner_LD.Click += dsrDesigner_LD_Click;
            dsrDesigner_SW.Click += dsrDesigner_SW_Click;
            dsrDesigner_DMD.Click += dsrDesigner_DMD_Click;
            dsrDesigner_UC.Click += dsrDesigner_UC_Click;
            dsrDesigner_FLIGHTS.Click += dsrDesigner_FLIGHTS_Click;
            dsrDesigner_06.Click += dsrDesigner_06_Click;
            dsrDesigner_07.Click += dsrDesigner_07_Click;
            dsrDesigner_03.Click += dsrDesigner_03_Click;
            dsrDesigner_04.Click += dsrDesigner_04_Click;
            dsrDesigner_05.Click += dsrDesigner_05_Click;
            dsrDesigner_08.Click += dsrDesigner_08_Click;
            dsrDesigner_11.Click += dsrDesigner_11_Click;
            fldT_START_DATE.Input += fldT_START_DATE_Input;
            fldBOOKINGS_BK_ADDON.Input += fldBOOKINGS_BK_ADDON_Input;
            fldBOOKINGS_BK_ADDON.Edit += fldBOOKINGS_BK_ADDON_Edit;
            fldT_START_WEEK.Edit += fldT_START_WEEK_Edit;
            fldT_END_WEEK.Input += fldT_END_WEEK_Input;
            fldT_END_WEEK.Edit += fldT_END_WEEK_Edit;
            fldT_START_DATE.Edit += fldT_START_DATE_Edit;
            fldT_END_DATE.Input += fldT_END_DATE_Input;
            fldT_END_DATE.Edit += fldT_END_DATE_Edit;
            fldBOOKINGS_BK_SUSPENSE.Process += fldBOOKINGS_BK_SUSPENSE_Process;
            fldBOOKINGS_BK_PURCHASE.Process += fldBOOKINGS_BK_PURCHASE_Process;
            fldBOOKINGS_BK_OVERDRAFT.Process += fldBOOKINGS_BK_OVERDRAFT_Process;
            fldT_START_DATE.Process += fldT_START_DATE_Process;
            fldBOOKINGS_BOOKING_CHARGE.Process += fldBOOKINGS_BOOKING_CHARGE_Process;
            fldBOOKINGS_POINTS_ADJUST.Process += fldBOOKINGS_POINTS_ADJUST_Process;
            fldBOOKINGS_LONG_STAY.Process += fldBOOKINGS_LONG_STAY_Process;
            fleBOOKINGS.InitializeItems += fleBOOKINGS_InitializeItems;

            Page_Load();

            // TODO: The following elements have Input/Output Scaling defined in the Dictionary or Screen.  Manual steps may be required:
            //       ANNUAL_ENT.PP1_CHARGE InputScale: 2 OutputScale: 0
            //       ANNUAL_ENT.PP1_SURCHARGEPER InputScale: 2 OutputScale: 0
            //       ANNUAL_ENT.PP2_CHARGE InputScale: 2 OutputScale: 0
            //       ANNUAL_ENT.PP2_SURCHARGEPER InputScale: 2 OutputScale: 0
            //       BALANCE_DEBTS.CC_SURCHARGE InputScale: 2 OutputScale: 0
            //       BALANCE_DEBTS.CC_VAT InputScale: 2 OutputScale: 0
            //       BALANCE_DEBTS.DEBT_AMOUNT InputScale: 2 OutputScale: 0
            //       BALANCE_DEBTS.EXCHANGE_RATE InputScale: 4 OutputScale: 0
            //       BALANCE_DEBTS.NOTIONAL_VAT InputScale: 2 OutputScale: 0
            //       BALANCE_DEBTS.PP1_SURCHARGE InputScale: 2 OutputScale: 0
            //       BALANCE_DEBTS.PP1_VAT InputScale: 2 OutputScale: 0
            //       BALANCE_DEBTS.PP2_SURCHARGE InputScale: 2 OutputScale: 0
            //       BALANCE_DEBTS.PP2_VAT InputScale: 2 OutputScale: 0
            //       BALANCE_DEBTS.TERM_SURCHARGE InputScale: 2 OutputScale: 0
            //       BALANCE_DEBTS.TERM_VAT InputScale: 2 OutputScale: 0
            //       BALANCE_DEBTS.TOTAL_CHARGE InputScale: 2 OutputScale: 0
            //       BALANCE_DEBTS.TOTAL_DEBT InputScale: 2 OutputScale: 0
            //       BALANCE_DEBTS.TOTAL_VAT InputScale: 2 OutputScale: 0
            //       BALANCE_DEBTS.VAT InputScale: 2 OutputScale: 0
            //       BOOKINGS.BOOKING_CHARGE InputScale: 2 OutputScale: 0
            //       BOOKINGS.DEPOSIT InputScale: 2 OutputScale: 0
            //       BOOKINGS.PP1_SURCHARGEPER InputScale: 2 OutputScale: 0
            //       BOOKINGS.PP2_SURCHARGEPER InputScale: 2 OutputScale: 0
            //       BOOKINGS.TERM_SURCHARGEPER InputScale: 2 OutputScale: 0
            //       BOOKINGS.VAT InputScale: 2 OutputScale: 0
            //       CHARGES.NOTIONAL_VAT InputScale: 2 OutputScale: 0
            //       CHARGES.SPLIT_CHARGE1_A InputScale: 2 OutputScale: 0
            //       CHARGES.SPLIT_CHARGE1_B InputScale: 2 OutputScale: 0
            //       CHARGES.SPLIT_CHARGE1_C InputScale: 2 OutputScale: 0
            //       CHARGES.SPLIT_CHARGE1_D InputScale: 2 OutputScale: 0
            //       CHARGES.SPLIT_CHARGE1_E InputScale: 2 OutputScale: 0
            //       CHARGES.SPLIT_CHARGE1_F InputScale: 2 OutputScale: 0
            //       CHARGES.SPLIT_CHARGE1_G InputScale: 2 OutputScale: 0
            //       CHARGES.SPLIT_CHARGE1_H InputScale: 2 OutputScale: 0
            //       CHARGES.SPLIT_CHARGE1_I InputScale: 2 OutputScale: 0
            //       CHARGES.SPLIT_CHARGE1_J InputScale: 2 OutputScale: 0
            //       CHARGES.SPLIT_CHARGE1_K InputScale: 2 OutputScale: 0
            //       CHARGES.SPLIT_CHARGE1_L InputScale: 2 OutputScale: 0
            //       CHARGES.SPLIT_CHARGE1_M InputScale: 2 OutputScale: 0
            //       CHARGES.SPLIT_CHARGE1_N InputScale: 2 OutputScale: 0
            //       CHARGES.SPLIT_CHARGE1_O InputScale: 2 OutputScale: 0
            //       CHARGES.SPLIT_CHARGE1_P InputScale: 2 OutputScale: 0
            //       CHARGES.SPLIT_CHARGE1_Q InputScale: 2 OutputScale: 0
            //       CHARGES.SPLIT_CHARGE1_R InputScale: 2 OutputScale: 0
            //       CHARGES.SPLIT_CHARGE1_S InputScale: 2 OutputScale: 0
            //       CHARGES.SPLIT_CHARGE1_T InputScale: 2 OutputScale: 0
            //       CHARGES.SPLIT_CHARGE1_U InputScale: 2 OutputScale: 0
            //       CHARGES.SPLIT_CHARGE1_V InputScale: 2 OutputScale: 0
            //       CHARGES.SPLIT_CHARGE1_W InputScale: 2 OutputScale: 0
            //       CHARGES.SPLIT_CHARGE1_X InputScale: 2 OutputScale: 0
            //       CHARGES.SPLIT_CHARGE1_Y InputScale: 2 OutputScale: 0
            //       CHARGES.SPLIT_CHARGE1_Z InputScale: 2 OutputScale: 0
            //       CHARGES.SPLIT_CHARGE2_A InputScale: 2 OutputScale: 0
            //       CHARGES.SPLIT_CHARGE2_B InputScale: 2 OutputScale: 0
            //       CHARGES.SPLIT_CHARGE2_C InputScale: 2 OutputScale: 0
            //       CHARGES.SPLIT_CHARGE2_D InputScale: 2 OutputScale: 0
            //       CHARGES.SPLIT_CHARGE2_E InputScale: 2 OutputScale: 0
            //       CHARGES.SPLIT_CHARGE2_F InputScale: 2 OutputScale: 0
            //       CHARGES.SPLIT_CHARGE2_G InputScale: 2 OutputScale: 0
            //       CHARGES.SPLIT_CHARGE2_H InputScale: 2 OutputScale: 0
            //       CHARGES.SPLIT_CHARGE2_I InputScale: 2 OutputScale: 0
            //       CHARGES.SPLIT_CHARGE2_J InputScale: 2 OutputScale: 0
            //       CHARGES.SPLIT_CHARGE2_K InputScale: 2 OutputScale: 0
            //       CHARGES.SPLIT_CHARGE2_L InputScale: 2 OutputScale: 0
            //       CHARGES.SPLIT_CHARGE2_M InputScale: 2 OutputScale: 0
            //       CHARGES.SPLIT_CHARGE2_N InputScale: 2 OutputScale: 0
            //       CHARGES.SPLIT_CHARGE2_O InputScale: 2 OutputScale: 0
            //       CHARGES.SPLIT_CHARGE2_P InputScale: 2 OutputScale: 0
            //       CHARGES.SPLIT_CHARGE2_Q InputScale: 2 OutputScale: 0
            //       CHARGES.SPLIT_CHARGE2_R InputScale: 2 OutputScale: 0
            //       CHARGES.SPLIT_CHARGE2_S InputScale: 2 OutputScale: 0
            //       CHARGES.SPLIT_CHARGE2_T InputScale: 2 OutputScale: 0
            //       CHARGES.SPLIT_CHARGE2_U InputScale: 2 OutputScale: 0
            //       CHARGES.SPLIT_CHARGE2_V InputScale: 2 OutputScale: 0
            //       CHARGES.SPLIT_CHARGE2_W InputScale: 2 OutputScale: 0
            //       CHARGES.SPLIT_CHARGE2_X InputScale: 2 OutputScale: 0
            //       CHARGES.SPLIT_CHARGE2_Y InputScale: 2 OutputScale: 0
            //       CHARGES.SPLIT_CHARGE2_Z InputScale: 2 OutputScale: 0
            //       CHARGES.USER_CHARGE_A InputScale: 2 OutputScale: 0
            //       CHARGES.USER_CHARGE_B InputScale: 2 OutputScale: 0
            //       CHARGES.USER_CHARGE_C InputScale: 2 OutputScale: 0
            //       CHARGES.USER_CHARGE_D InputScale: 2 OutputScale: 0
            //       CHARGES.USER_CHARGE_E InputScale: 2 OutputScale: 0
            //       CHARGES.USER_CHARGE_F InputScale: 2 OutputScale: 0
            //       CHARGES.USER_CHARGE_G InputScale: 2 OutputScale: 0
            //       CHARGES.USER_CHARGE_H InputScale: 2 OutputScale: 0
            //       CHARGES.USER_CHARGE_I InputScale: 2 OutputScale: 0
            //       CHARGES.USER_CHARGE_J InputScale: 2 OutputScale: 0
            //       CHARGES.USER_CHARGE_K InputScale: 2 OutputScale: 0
            //       CHARGES.USER_CHARGE_L InputScale: 2 OutputScale: 0
            //       CHARGES.USER_CHARGE_M InputScale: 2 OutputScale: 0
            //       CHARGES.USER_CHARGE_N InputScale: 2 OutputScale: 0
            //       CHARGES.USER_CHARGE_O InputScale: 2 OutputScale: 0
            //       CHARGES.USER_CHARGE_P InputScale: 2 OutputScale: 0
            //       CHARGES.USER_CHARGE_Q InputScale: 2 OutputScale: 0
            //       CHARGES.USER_CHARGE_R InputScale: 2 OutputScale: 0
            //       CHARGES.USER_CHARGE_S InputScale: 2 OutputScale: 0
            //       CHARGES.USER_CHARGE_T InputScale: 2 OutputScale: 0
            //       CHARGES.USER_CHARGE_U InputScale: 2 OutputScale: 0
            //       CHARGES.USER_CHARGE_V InputScale: 2 OutputScale: 0
            //       CHARGES.USER_CHARGE_W InputScale: 2 OutputScale: 0
            //       CHARGES.USER_CHARGE_X InputScale: 2 OutputScale: 0
            //       CHARGES.USER_CHARGE_Y InputScale: 2 OutputScale: 0
            //       CHARGES.USER_CHARGE_Z InputScale: 2 OutputScale: 0
            //       COLOUR_RATES.COLOUR_RATE InputScale: 4 OutputScale: 0
            //       CURRENCY_RATE.EXCHANGE_RATE InputScale: 4 OutputScale: 0
            //       INVESTMENTS.TERM_SURCHARGEPER InputScale: 2 OutputScale: 0
            //       PROPERTIES.DEPOSIT InputScale: 2 OutputScale: 0
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
            //       UCHARGE_DEBTS.EXCHANGE_RATE InputScale: 4 OutputScale: 0
            //       UCHARGE_DEBTS.NOTIONAL_VAT InputScale: 2 OutputScale: 0
            //       UCHARGE_DEBTS.PP1_SURCHARGE InputScale: 2 OutputScale: 0
            //       UCHARGE_DEBTS.PP1_VAT InputScale: 2 OutputScale: 0
            //       UCHARGE_DEBTS.PP2_SURCHARGE InputScale: 2 OutputScale: 0
            //       UCHARGE_DEBTS.PP2_VAT InputScale: 2 OutputScale: 0
            //       UCHARGE_DEBTS.TERM_SURCHARGE InputScale: 2 OutputScale: 0
            //       UCHARGE_DEBTS.TERM_VAT InputScale: 2 OutputScale: 0
            //       UCHARGE_DEBTS.TOTAL_CHARGE InputScale: 2 OutputScale: 0
            //       UCHARGE_DEBTS.TOTAL_DEBT InputScale: 2 OutputScale: 0
            //       UCHARGE_DEBTS.TOTAL_VAT InputScale: 2 OutputScale: 0
            //       UCHARGE_DEBTS.VAT InputScale: 2 OutputScale: 0
            // TODO: The following FIELD(S) on the form are redefine elements.  Manual steps may be required:
            //       SCREEN_PROPERTY.PROPERTY_CODE


        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            fleM_INVESTORS = new OracleFileObject(this, FileTypes.Master, 0, "INDEXED", "M_INVESTORS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleUSER_SEC_FILE = new OracleFileObject(this, FileTypes.Master, 0, "INDEXED", "USER_SEC_FILE", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            flePROPERTY_YEARS = new OracleFileObject(this, FileTypes.Master, 0, "INDEXED", "PROPERTY_YEARS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            flePROPERTY_YEARS_DTL = new OracleFileObject(this, FileTypes.Detail, 53, "INDEXED", "PROPERTY_YEARS_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleSCREEN_PROPERTY = new OracleFileObject(this, FileTypes.Master, 0, "SEQUENTIAL", "SCREEN_PROPERTY", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            flePROPERTIES = new OracleFileObject(this, FileTypes.Master, 0, "INDEXED", "PROPERTIES", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            flePROP_COMMENTS = new OracleFileObject(this, FileTypes.Master, 0, "INDEXED", "PROP_COMMENTS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleBOOK0100_COMM = new OracleFileObject(this, FileTypes.Master, 0, "INDEXED", "LOCN_BK_COMMENTS", "BOOK0100_COMM", false, false, false, 0, "m_trnTRANS_UPDATE");
            M_START_PERIOD = new CoreDecimal("M_START_PERIOD", 2, this);
            M_END_PERIOD = new CoreDecimal("M_END_PERIOD", 2, this);
            M_START_DATE = new CoreDate("M_START_DATE", this);
            M_END_DATE = new CoreDate("M_END_DATE", this);
            M_BOOKED = new CoreCharacter("M_BOOKED", 1, this, Common.cEmptyString);
            T_START_DATE = new CoreDate("T_START_DATE", this, ResetTypes.ResetAtMode);
            T_END_DATE = new CoreDate("T_END_DATE", this, ResetTypes.ResetAtMode);
            T_START_WEEK = new CoreDecimal("T_START_WEEK", 2, this, ResetTypes.ResetAtMode);
            T_END_WEEK = new CoreDecimal("T_END_WEEK", 2, this, ResetTypes.ResetAtMode);
            T_BOOKING_REF = new CoreCharacter("T_BOOKING_REF", 8, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
            X_BOOKING_REF = new CoreCharacter("X_BOOKING_REF", 8, this, Common.cEmptyString);
            T_TERM_SURCHARGE = new CoreInteger("T_TERM_SURCHARGE", 8, this, 0m);
            T_FIXED_DEBT = new CoreCharacter("T_FIXED_DEBT", 1, this, " ");
            T_BOGOF_DEPOSIT = new CoreCharacter("T_BOGOF_DEPOSIT", 1, this, "N");
            T_PFIA_DEPOSIT = new CoreCharacter("T_PFIA_DEPOSIT", 1, this, "N");
            fleBOOKINGS = new OracleFileObject(this, FileTypes.Primary, 0, "INDEXED", "BOOKINGS", "", true, false, false, 0, "m_trnTRANS_UPDATE");
            T_HOLIDAY_YEAR = new CoreCharacter("T_HOLIDAY_YEAR", 4, this, Common.cEmptyString);
            T_PREVIOUS_YEAR = new CoreCharacter("T_PREVIOUS_YEAR", 4, this, Common.cEmptyString);
            T_FOLLOWING_YEAR = new CoreCharacter("T_FOLLOWING_YEAR", 4, this, Common.cEmptyString);
            fleCURRENT_ENTS = new OracleFileObject(this, FileTypes.Designer, 0, "INDEXED", "CURRENT_ENTS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            flePREVIOUS_ENT = new OracleFileObject(this, FileTypes.Designer, 0, "INDEXED", "CURRENT_ENTS", "PREVIOUS_ENT", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleFOLLOWING_ENT = new OracleFileObject(this, FileTypes.Designer, 0, "INDEXED", "CURRENT_ENTS", "FOLLOWING_ENT", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleSUSP_ACCOUNT = new OracleFileObject(this, FileTypes.Designer, 0, "INDEXED", "SUSP_ACCOUNT", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleFORF_ACCOUNT = new OracleFileObject(this, FileTypes.Designer, 0, "INDEXED", "FORF_ACCOUNT", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleANNUAL_ENT = new OracleFileObject(this, FileTypes.Designer, 0, "INDEXED", "ANNUAL_ENT", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleINVESTMENTS = new OracleFileObject(this, FileTypes.Designer, 0, "INDEXED", "INVESTMENTS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleCOLOUR_RATES = new OracleFileObject(this, FileTypes.Designer, 0, "INDEXED", "COLOUR_RATES", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleCHARGES = new OracleFileObject(this, FileTypes.Reference, 0, "INDEXED", "CHARGES", "", true, false, false, 0, "m_cnnQUERY");
            fleCHARGES_DTL = new OracleFileObject(this, FileTypes.Detail, 53, "INDEXED", "CHARGES_DTL", "", true, false, false, 0, "m_cnnQUERY");
            flePURCHASE_DEBTS = new OracleFileObject(this, FileTypes.Secondary, 0, "INDEXED", "BOOKING_DEBTS", "PURCHASE_DEBTS", true, false, false, 0, "m_trnTRANS_UPDATE");
            T_POINTS_1 = new CoreInteger("T_POINTS_1", 9, this);
            T_POINTS_2 = new CoreInteger("T_POINTS_2", 9, this);
            T_POINTS_3 = new CoreInteger("T_POINTS_3", 9, this);
            T_POINTS_4 = new CoreInteger("T_POINTS_4", 9, this);
            T_POINTS_5 = new CoreInteger("T_POINTS_5", 9, this);
            T_POINTS_6 = new CoreInteger("T_POINTS_6", 9, this);
            T_POINTS_7 = new CoreInteger("T_POINTS_7", 9, this);
            fleUCHARGE_DEBTS = new OracleFileObject(this, FileTypes.Secondary, 0, "INDEXED", "BOOKING_DEBTS", "UCHARGE_DEBTS", true, false, false, 0, "m_trnTRANS_UPDATE");
            fleBALANCE_DEBTS = new OracleFileObject(this, FileTypes.Secondary, 0, "INDEXED", "BOOKING_DEBTS", "BALANCE_DEBTS", true, false, false, 0, "m_trnTRANS_UPDATE");
            fleSPLIT_WEEKS = new OracleFileObject(this, FileTypes.Reference, 0, "INDEXED", "SPLIT_WEEKS", "", true, false, false, 0, "m_cnnQUERY");
            fleBOOKING_PERIODS = new OracleFileObject(this, FileTypes.Designer, 0, "INDEXED", "BOOKING_PERIODS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleBOOKING_PERIODS_DTL = new OracleFileObject(this, FileTypes.Detail, 53, "INDEXED", "BOOKING_PERIOD_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleLOCATIONS = new OracleFileObject(this, FileTypes.Designer, 0, "INDEXED", "LOCATIONS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleLOCATION_CURR = new OracleFileObject(this, FileTypes.Designer, 0, "INDEXED", "LOCATION_CURR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleCURRENCY_CODE = new OracleFileObject(this, FileTypes.Designer, 0, "INDEXED", "CURRENCY_CODE", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleCURRENCY_RATE = new OracleFileObject(this, FileTypes.Designer, 0, "INDEXED", "CURRENCY_RATE", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            flePROP_BK_COMMENTS = new OracleFileObject(this, FileTypes.Reference, 0, "INDEXED", "PROP_BK_COMMENTS", "", false, false, false, 0, "m_cnnQUERY");
            fleLOCN_BK_COMMENTS = new OracleFileObject(this, FileTypes.Reference, 0, "INDEXED", "LOCN_BK_COMMENTS", "", false, false, false, 0, "m_cnnQUERY");
            T_DUE_NOW = new CoreCharacter("T_DUE_NOW", 1, this, "N");
            T_OVERDRAFT = new CoreInteger("T_OVERDRAFT", 9, this);
            T_USE_FORF_BAL = new CoreCharacter("T_USE_FORF_BAL", 1, this, "Y");
            T_REQUEST = new CoreCharacter("T_REQUEST", 1, this, Common.cEmptyString);
            T_COMMENTS = new CoreCharacter("T_COMMENTS", 1, this, Common.cEmptyString);
            T_NEW_BOOKING = new CoreCharacter("T_NEW_BOOKING", 1, this, "Y");
            T_ALLOW = new CoreCharacter("T_ALLOW", 1, this, Common.cEmptyString);
            T_CONTINUE = new CoreCharacter("T_CONTINUE", 1, this, Common.cEmptyString);
            T_AREA = new CoreCharacter("T_AREA", 4, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
            T_INVESTOR = new CoreCharacter("T_INVESTOR", 8, this, Common.cEmptyString);
            T_LOCATION = new CoreCharacter("T_LOCATION", 2, this, Common.cEmptyString);
            T_PROPERTY_ID = new CoreCharacter("T_PROPERTY_ID", 4, this, Common.cEmptyString);
            T_PROPERTY_CODE = new CoreCharacter("T_PROPERTY_CODE", 10, this, Common.cEmptyString);
            T_BALANCE = new CoreInteger("T_BALANCE", 8, this);
            T_TEN_SHH_SPLIT = new CoreCharacter("T_TEN_SHH_SPLIT", 1, this, Common.cEmptyString);
            T_SPLIT_CHARGE = new CoreInteger("T_SPLIT_CHARGE", 8, this);
            T_USER_CHARGE_TOT = new CoreDecimal("T_USER_CHARGE_TOT", 8, this, ResetTypes.ResetAtMode, 0m);
            T_ERROR_FLAG = new CoreCharacter("T_ERROR_FLAG", 1, this, Common.cEmptyString);
            T_UPDATE_LINKED = new CoreCharacter("T_UPDATE_LINKED", 1, this, "N");
            T_CALLING_SCREEN = new CoreCharacter("T_CALLING_SCREEN", 8, this, "BOOKING");
            T_WEEK_STATUS = new CoreCharacter("T_WEEK_STATUS", 7, this, Common.cEmptyString);
            T_COUNT = new CoreInteger("T_COUNT", 2, this);
            T_PROPERTY_DATE = new CoreDate("T_PROPERTY_DATE", this);
            T_WEB_BOOKING = new CoreCharacter("T_WEB_BOOKING", 1, this, ResetTypes.ResetAtStartup, "N");
            T_LT_INVESTOR = new CoreCharacter("T_LT_INVESTOR", 8, this, " ");
            T_SILVER_POINTS_FREE = new CoreCharacter("T_SILVER_POINTS_FREE", 1, this, Common.cEmptyString);
            T_CHARGE = new CoreInteger("T_CHARGE", 12, this);
            T_WEEK = new CoreDecimal("T_WEEK", 1, this, ResetTypes.ResetAtMode, 0m);
            T_TOTAL_WEEKLY_RATE = new CoreInteger("T_TOTAL_WEEKLY_RATE", 12, this, ResetTypes.ResetAtMode, 0m);
            T_TOTAL_DAYS = new CoreDecimal("T_TOTAL_DAYS", 1, this, ResetTypes.ResetAtMode, 0m);
            T_START_DAYS = new CoreDecimal("T_START_DAYS", 8, this);
            T_END_DAYS = new CoreDecimal("T_END_DAYS", 8, this);
            T_BOOK_DAYS = new CoreDecimal("T_BOOK_DAYS", 8, this);
            T_PROP_CODE = new CoreCharacter("T_PROP_CODE", 4, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
            T_WEB_YEAR = new CoreCharacter("T_WEB_YEAR", 4, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
            T_WEB_START_WEEK = new CoreCharacter("T_WEB_START_WEEK", 2, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
            T_WEB_END_WEEK = new CoreCharacter("T_WEB_END_WEEK", 2, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
            T_OLD_START_WEEK = new CoreCharacter("T_OLD_START_WEEK", 2, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
            T_OLD_END_WEEK = new CoreCharacter("T_OLD_END_WEEK", 2, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
            T_WEB_LOCATION = new CoreCharacter("T_WEB_LOCATION", 2, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
            T_WEB_PROP_ID = new CoreCharacter("T_WEB_PROP_ID", 4, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
            T_WEB_START_DATE = new CoreCharacter("T_WEB_START_DATE", 8, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
            T_WEB_END_DATE = new CoreCharacter("T_WEB_END_DATE", 8, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
            T_WEB_UPDATED = new CoreCharacter("T_WEB_UPDATED", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
            T_BOOKING_NOW = new CoreCharacter("T_BOOKING_NOW", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
            T_WEB_BOOKED = new CoreCharacter("T_WEB_BOOKED", 1, this, ResetTypes.ResetAtStartup, " ");
            T_PICTURE_IN = new CoreCharacter("T_PICTURE_IN", 70, this, "");
            T_PICTURE_OUT = new CoreCharacter("T_PICTURE_OUT", 70, this, "");
            SCREEN_PROPERTY_PROPERTY_CODE = new CoreCharacter("SCREEN_PROPERTY_PROPERTY_CODE", 10, this, fleSCREEN_PROPERTY, Common.cEmptyString);

            D_DEPOSIT.GetValue += D_DEPOSIT_GetValue;
            D_BRITISH.GetValue += D_BRITISH_GetValue;
            D_CONF_BY.GetValue += D_CONF_BY_GetValue;
            D_CONFIRM_DATE.GetValue += D_CONFIRM_DATE_GetValue;
            D_HOLIDAY_YEAR.GetValue += D_HOLIDAY_YEAR_GetValue;
            D_PREVIOUS_YEAR.GetValue += D_PREVIOUS_YEAR_GetValue;
            D_FOLLOWING_YEAR.GetValue += D_FOLLOWING_YEAR_GetValue;
            fleCURRENT_ENTS.Access += fleCURRENT_ENTS_Access;
            flePREVIOUS_ENT.Access += flePREVIOUS_ENT_Access;
            fleFOLLOWING_ENT.Access += fleFOLLOWING_ENT_Access;
            fleSUSP_ACCOUNT.Access += fleSUSP_ACCOUNT_Access;
            fleFORF_ACCOUNT.Access += fleFORF_ACCOUNT_Access;
            fleANNUAL_ENT.Access += fleANNUAL_ENT_Access;
            fleINVESTMENTS.Access += fleINVESTMENTS_Access;
            fleCHARGES.Access += fleCHARGES_Access;
            fleCHARGES_DTL.Access += fleCHARGES_DTL_Access;
            flePURCHASE_DEBTS.Access += flePURCHASE_DEBTS_Access;
            D_USE_FIRST.GetValue += D_USE_FIRST_GetValue;
            D_SILVER_SURCHARGE.GetValue += D_SILVER_SURCHARGE_GetValue;
            D_POINTS.GetValue += D_POINTS_GetValue;
            D_NET_POINTS.GetValue += D_NET_POINTS_GetValue;
            D_PP1_SURCHARGE.GetValue += D_PP1_SURCHARGE_GetValue;
            D_PP2_SURCHARGE.GetValue += D_PP2_SURCHARGE_GetValue;
            D_PP_SURCHARGE.GetValue += D_PP_SURCHARGE_GetValue;
            D_PP_FLAG.GetValue += D_PP_FLAG_GetValue;
            D_NIGHTS.GetValue += D_NIGHTS_GetValue;
            D_NOTIONAL_VAT.GetValue += D_NOTIONAL_VAT_GetValue;
            fleUCHARGE_DEBTS.Access += fleUCHARGE_DEBTS_Access;
            fleBALANCE_DEBTS.Access += fleBALANCE_DEBTS_Access;
            fleSPLIT_WEEKS.Access += fleSPLIT_WEEKS_Access;
            flePROP_BK_COMMENTS.Access += flePROP_BK_COMMENTS_Access;
            fleLOCN_BK_COMMENTS.Access += fleLOCN_BK_COMMENTS_Access;
            D_START_DOW.GetValue += D_START_DOW_GetValue;
            D_END_DOW.GetValue += D_END_DOW_GetValue;
            D_PROP_COMM.GetValue += D_PROP_COMM_GetValue;
            D_CONVERT_FIELD.GetValue += D_CONVERT_FIELD_GetValue;
            D_FULL_CHARGE.GetValue += D_FULL_CHARGE_GetValue;
            D_DAYS_DIFF.GetValue += D_DAYS_DIFF_GetValue;
            D_PAY_TIME.GetValue += D_PAY_TIME_GetValue;
            D_DUE_NOW_MESSAGE.GetValue += D_DUE_NOW_MESSAGE_GetValue;
            D_BF_BAL.GetValue += D_BF_BAL_GetValue;
            D_FORF_QUALIFIED.GetValue += D_FORF_QUALIFIED_GetValue;
            D_USE_FORF_BAL.GetValue += D_USE_FORF_BAL_GetValue;
            D_FORF_BAL.GetValue += D_FORF_BAL_GetValue;
            D_FORF_POINTS.GetValue += D_FORF_POINTS_GetValue;
            D_FORF_MESSAGE.GetValue += D_FORF_MESSAGE_GetValue;
            D_AVAILABLE.GetValue += D_AVAILABLE_GetValue;
            D_SUBTOTAL.GetValue += D_SUBTOTAL_GetValue;
            D_SUSP_MAX.GetValue += D_SUSP_MAX_GetValue;
            D_PURC_MAX.GetValue += D_PURC_MAX_GetValue;
            D_TOP_UP_COST1.GetValue += D_TOP_UP_COST1_GetValue;
            D_TOP_UP_COST.GetValue += D_TOP_UP_COST_GetValue;
            D_PURCHASE.GetValue += D_PURCHASE_GetValue;
            D_DPC1.GetValue += D_DPC1_GetValue;
            D_DPC2.GetValue += D_DPC2_GetValue;
            D_PURCHASE_COST.GetValue += D_PURCHASE_COST_GetValue;
            D_POINTS_BALANCE.GetValue += D_POINTS_BALANCE_GetValue;
            D_ANN_CURR_ENT.GetValue += D_ANN_CURR_ENT_GetValue;
            D_BOOK_OD.GetValue += D_BOOK_OD_GetValue;
            D_PLUS_28.GetValue += D_PLUS_28_GetValue;
            D_WITHIN_28.GetValue += D_WITHIN_28_GetValue;
            D_OD_MAX.GetValue += D_OD_MAX_GetValue;
            D_NET_POINTS_ENT.GetValue += D_NET_POINTS_ENT_GetValue;
            D_PROP_DATE_1.GetValue += D_PROP_DATE_1_GetValue;
            D_PROP_DATE_2.GetValue += D_PROP_DATE_2_GetValue;
            D_PROP_DATE_3.GetValue += D_PROP_DATE_3_GetValue;
            D_PROP_DATE_4.GetValue += D_PROP_DATE_4_GetValue;
            D_PROP_DATE_5.GetValue += D_PROP_DATE_5_GetValue;
            D_PROP_DATE_6.GetValue += D_PROP_DATE_6_GetValue;
            D_PROP_DATE_7.GetValue += D_PROP_DATE_7_GetValue;
            D_PROP_DATE_8.GetValue += D_PROP_DATE_8_GetValue;
            D_PROP_DATE_9.GetValue += D_PROP_DATE_9_GetValue;
            D_PROP_DATE_10.GetValue += D_PROP_DATE_10_GetValue;
            D_PROP_DATE_1X.GetValue += D_PROP_DATE_1X_GetValue;
            D_PROP_DATE_2X.GetValue += D_PROP_DATE_2X_GetValue;
            D_PROP_DATE_3X.GetValue += D_PROP_DATE_3X_GetValue;
            D_PROP_DATE_4X.GetValue += D_PROP_DATE_4X_GetValue;
            D_PROP_DATE_5X.GetValue += D_PROP_DATE_5X_GetValue;
            D_PROP_DATE_6X.GetValue += D_PROP_DATE_6X_GetValue;
            D_PROP_DATE_7X.GetValue += D_PROP_DATE_7X_GetValue;
            D_PROP_DATE_8X.GetValue += D_PROP_DATE_8X_GetValue;
            D_PROP_DATE_9X.GetValue += D_PROP_DATE_9X_GetValue;
            D_PROP_DATE_10X.GetValue += D_PROP_DATE_10X_GetValue;
            D_STATUS_1.GetValue += D_STATUS_1_GetValue;
            D_STATUS_2.GetValue += D_STATUS_2_GetValue;
            D_STATUS_3.GetValue += D_STATUS_3_GetValue;
            D_STATUS_4.GetValue += D_STATUS_4_GetValue;
            D_STATUS_5.GetValue += D_STATUS_5_GetValue;
            D_STATUS_6.GetValue += D_STATUS_6_GetValue;
            D_STATUS_7.GetValue += D_STATUS_7_GetValue;
            D_WEEK_END_DATE.GetValue += D_WEEK_END_DATE_GetValue;
            D_DAY_1.GetValue += D_DAY_1_GetValue;
            D_DAY_2.GetValue += D_DAY_2_GetValue;
            D_DAY_3.GetValue += D_DAY_3_GetValue;
            D_DAY_4.GetValue += D_DAY_4_GetValue;
            D_DAY_5.GetValue += D_DAY_5_GetValue;
            D_DAY_6.GetValue += D_DAY_6_GetValue;
            D_DAY_7.GetValue += D_DAY_7_GetValue;
            D_PRP_1.GetValue += D_PRP_1_GetValue;
            D_PRP_2.GetValue += D_PRP_2_GetValue;
            D_PRP_3.GetValue += D_PRP_3_GetValue;
            D_PRP_4.GetValue += D_PRP_4_GetValue;
            D_PRP_5.GetValue += D_PRP_5_GetValue;
            D_PRP_6.GetValue += D_PRP_6_GetValue;
            D_PRP_7.GetValue += D_PRP_7_GetValue;
            D_PART_POINTS.GetValue += D_PART_POINTS_GetValue;
            D_DAY_STATUS_1.GetValue += D_DAY_STATUS_1_GetValue;
            D_DAY_STATUS_2.GetValue += D_DAY_STATUS_2_GetValue;
            D_DAY_STATUS_3.GetValue += D_DAY_STATUS_3_GetValue;
            D_DAY_STATUS_4.GetValue += D_DAY_STATUS_4_GetValue;
            D_DAY_STATUS_5.GetValue += D_DAY_STATUS_5_GetValue;
            D_DAY_STATUS_6.GetValue += D_DAY_STATUS_6_GetValue;
            D_DAY_STATUS_7.GetValue += D_DAY_STATUS_7_GetValue;
            D_LAST_PERIOD.GetValue += D_LAST_PERIOD_GetValue;
            D_SCREEN_END.GetValue += D_SCREEN_END_GetValue;
            D_SCREEN_START.GetValue += D_SCREEN_START_GetValue;
            D_UNDER_A_WEEK.GetValue += D_UNDER_A_WEEK_GetValue;
            D_BOOKDATE_28.GetValue += D_BOOKDATE_28_GetValue;
            D_BOOKDATE_21.GetValue += D_BOOKDATE_21_GetValue;
            D_BOOKDATE_42.GetValue += D_BOOKDATE_42_GetValue;
            D_BOOKDATE_56.GetValue += D_BOOKDATE_56_GetValue;
            D_BOOKDATE_14.GetValue += D_BOOKDATE_14_GetValue;
            D_START_DATE.GetValue += D_START_DATE_GetValue;
            D_UK.GetValue += D_UK_GetValue;
            D_POINTS_FREE.GetValue += D_POINTS_FREE_GetValue;
            D_WITHIN_21_DAYS.GetValue += D_WITHIN_21_DAYS_GetValue;
            D_PAY_USER_CHARGE.GetValue += D_PAY_USER_CHARGE_GetValue;
            D_SET_USER_CHARGE.GetValue += D_SET_USER_CHARGE_GetValue;
            D_USER_CHARGES.GetValue += D_USER_CHARGES_GetValue;
            D_USER_CHARGE.GetValue += D_USER_CHARGE_GetValue;
            D_SPLIT_CHARGE.GetValue += D_SPLIT_CHARGE_GetValue;
            D_CHARGE_7TH.GetValue += D_CHARGE_7TH_GetValue;
            D_RATE.GetValue += D_RATE_GetValue;
            D_EXTRADAYS_CHARGE.GetValue += D_EXTRADAYS_CHARGE_GetValue;
            D_TERM_SURCHARGEPER.GetValue += D_TERM_SURCHARGEPER_GetValue;
            D_2_YEARS.GetValue += D_2_YEARS_GetValue;
            D_IN_RANGE.GetValue += D_IN_RANGE_GetValue;
            D_DAY_1_OK.GetValue += D_DAY_1_OK_GetValue;
            D_DAY_2_OK.GetValue += D_DAY_2_OK_GetValue;
            D_DAY_3_OK.GetValue += D_DAY_3_OK_GetValue;
            D_DAY_4_OK.GetValue += D_DAY_4_OK_GetValue;
            D_DAY_5_OK.GetValue += D_DAY_5_OK_GetValue;
            D_DAY_6_OK.GetValue += D_DAY_6_OK_GetValue;
            D_DAY_7_OK.GetValue += D_DAY_7_OK_GetValue;
            D_SPLIT_VALID.GetValue += D_SPLIT_VALID_GetValue;
            D_SPLIT_CHARGE_PER.GetValue += D_SPLIT_CHARGE_PER_GetValue;
            D_SPLIT_POINTS_PER.GetValue += D_SPLIT_POINTS_PER_GetValue;
            D_SILVER_CHARGE.GetValue += D_SILVER_CHARGE_GetValue;
            D_ON_REQUEST_DATE.GetValue += D_ON_REQUEST_DATE_GetValue;
            D_ON_REQUEST.GetValue += D_ON_REQUEST_GetValue;
            D_VAT.GetValue += D_VAT_GetValue;
            D_WEEKS.GetValue += D_WEEKS_GetValue;
            D_POINTS_WEEKS.GetValue += D_POINTS_WEEKS_GetValue;
            D_PFIA_WEEKS.GetValue += D_PFIA_WEEKS_GetValue;
            D_DEPOSIT_AMT.GetValue += D_DEPOSIT_AMT_GetValue;
            D_OFFER_DEPOSIT.GetValue += D_OFFER_DEPOSIT_GetValue;
            D_DUE_NOW.GetValue += D_DUE_NOW_GetValue;
            D_VAT_NOW.GetValue += D_VAT_NOW_GetValue;
            D_VAT_BALANCE.GetValue += D_VAT_BALANCE_GetValue;
            D_SHHL_BALANCE.GetValue += D_SHHL_BALANCE_GetValue;
            D_DEPOSITPER.GetValue += D_DEPOSITPER_GetValue;
            D_DUE_NOW_TEXT.GetValue += D_DUE_NOW_TEXT_GetValue;
            D_BOOKING_NO.GetValue += D_BOOKING_NO_GetValue;
            D_PROP_CODE.GetValue += D_PROP_CODE_GetValue;
            fleBOOKINGS.SetItemFinals += fleBOOKINGS_SetItemFinals;
            flePURCHASE_DEBTS.SetItemFinals += flePURCHASE_DEBTS_SetItemFinals;
            fleUCHARGE_DEBTS.SetItemFinals += fleUCHARGE_DEBTS_SetItemFinals;
            fleBALANCE_DEBTS.SetItemFinals += fleBALANCE_DEBTS_SetItemFinals;

            T_START_DATE.GetInitialValue += T_START_DATE_GetInitialValue;
            T_END_DATE.GetInitialValue += T_END_DATE_GetInitialValue;
            T_START_WEEK.GetInitialValue += T_START_WEEK_GetInitialValue;
            T_END_WEEK.GetInitialValue += T_END_WEEK_GetInitialValue;


            flePURCHASE_DEBTS.AccessIsOptional = true;
            fleUCHARGE_DEBTS.AccessIsOptional = true;
            fleBALANCE_DEBTS.AccessIsOptional = true;
            flePROP_BK_COMMENTS.AccessIsOptional = true;
            fleLOCN_BK_COMMENTS.AccessIsOptional = true;
        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;
            D_DEPOSIT.GetValue -= D_DEPOSIT_GetValue;
            D_BRITISH.GetValue -= D_BRITISH_GetValue;
            D_CONF_BY.GetValue -= D_CONF_BY_GetValue;
            D_CONFIRM_DATE.GetValue -= D_CONFIRM_DATE_GetValue;
            D_HOLIDAY_YEAR.GetValue -= D_HOLIDAY_YEAR_GetValue;
            D_PREVIOUS_YEAR.GetValue -= D_PREVIOUS_YEAR_GetValue;
            D_FOLLOWING_YEAR.GetValue -= D_FOLLOWING_YEAR_GetValue;
            fleCURRENT_ENTS.Access -= fleCURRENT_ENTS_Access;
            flePREVIOUS_ENT.Access -= flePREVIOUS_ENT_Access;
            fleFOLLOWING_ENT.Access -= fleFOLLOWING_ENT_Access;
            fleSUSP_ACCOUNT.Access -= fleSUSP_ACCOUNT_Access;
            fleFORF_ACCOUNT.Access -= fleFORF_ACCOUNT_Access;
            fleANNUAL_ENT.Access -= fleANNUAL_ENT_Access;
            fleINVESTMENTS.Access -= fleINVESTMENTS_Access;
            fleCHARGES.Access -= fleCHARGES_Access;
            fleCHARGES_DTL.Access -= fleCHARGES_DTL_Access;
            flePURCHASE_DEBTS.Access -= flePURCHASE_DEBTS_Access;
            D_USE_FIRST.GetValue -= D_USE_FIRST_GetValue;
            D_SILVER_SURCHARGE.GetValue -= D_SILVER_SURCHARGE_GetValue;
            D_POINTS.GetValue -= D_POINTS_GetValue;
            D_NET_POINTS.GetValue -= D_NET_POINTS_GetValue;
            D_PP1_SURCHARGE.GetValue -= D_PP1_SURCHARGE_GetValue;
            D_PP2_SURCHARGE.GetValue -= D_PP2_SURCHARGE_GetValue;
            D_PP_SURCHARGE.GetValue -= D_PP_SURCHARGE_GetValue;
            D_PP_FLAG.GetValue -= D_PP_FLAG_GetValue;
            D_NIGHTS.GetValue -= D_NIGHTS_GetValue;
            D_NOTIONAL_VAT.GetValue -= D_NOTIONAL_VAT_GetValue;
            fleUCHARGE_DEBTS.Access -= fleUCHARGE_DEBTS_Access;
            fleBALANCE_DEBTS.Access -= fleBALANCE_DEBTS_Access;
            fleSPLIT_WEEKS.Access -= fleSPLIT_WEEKS_Access;
            flePROP_BK_COMMENTS.Access -= flePROP_BK_COMMENTS_Access;
            fleLOCN_BK_COMMENTS.Access -= fleLOCN_BK_COMMENTS_Access;
            D_START_DOW.GetValue -= D_START_DOW_GetValue;
            D_END_DOW.GetValue -= D_END_DOW_GetValue;
            D_PROP_COMM.GetValue -= D_PROP_COMM_GetValue;
            D_CONVERT_FIELD.GetValue -= D_CONVERT_FIELD_GetValue;
            D_FULL_CHARGE.GetValue -= D_FULL_CHARGE_GetValue;
            D_DAYS_DIFF.GetValue -= D_DAYS_DIFF_GetValue;
            D_PAY_TIME.GetValue -= D_PAY_TIME_GetValue;
            D_DUE_NOW_MESSAGE.GetValue -= D_DUE_NOW_MESSAGE_GetValue;
            D_BF_BAL.GetValue -= D_BF_BAL_GetValue;
            D_FORF_QUALIFIED.GetValue -= D_FORF_QUALIFIED_GetValue;
            D_USE_FORF_BAL.GetValue -= D_USE_FORF_BAL_GetValue;
            D_FORF_BAL.GetValue -= D_FORF_BAL_GetValue;
            D_FORF_POINTS.GetValue -= D_FORF_POINTS_GetValue;
            D_FORF_MESSAGE.GetValue -= D_FORF_MESSAGE_GetValue;
            D_AVAILABLE.GetValue -= D_AVAILABLE_GetValue;
            D_SUBTOTAL.GetValue -= D_SUBTOTAL_GetValue;
            D_SUSP_MAX.GetValue -= D_SUSP_MAX_GetValue;
            D_PURC_MAX.GetValue -= D_PURC_MAX_GetValue;
            D_TOP_UP_COST1.GetValue -= D_TOP_UP_COST1_GetValue;
            D_TOP_UP_COST.GetValue -= D_TOP_UP_COST_GetValue;
            D_PURCHASE.GetValue -= D_PURCHASE_GetValue;
            D_DPC1.GetValue -= D_DPC1_GetValue;
            D_DPC2.GetValue -= D_DPC2_GetValue;
            D_PURCHASE_COST.GetValue -= D_PURCHASE_COST_GetValue;
            D_POINTS_BALANCE.GetValue -= D_POINTS_BALANCE_GetValue;
            D_ANN_CURR_ENT.GetValue -= D_ANN_CURR_ENT_GetValue;
            D_BOOK_OD.GetValue -= D_BOOK_OD_GetValue;
            D_PLUS_28.GetValue -= D_PLUS_28_GetValue;
            D_WITHIN_28.GetValue -= D_WITHIN_28_GetValue;
            D_OD_MAX.GetValue -= D_OD_MAX_GetValue;
            D_NET_POINTS_ENT.GetValue -= D_NET_POINTS_ENT_GetValue;
            D_PROP_DATE_1.GetValue -= D_PROP_DATE_1_GetValue;
            D_PROP_DATE_2.GetValue -= D_PROP_DATE_2_GetValue;
            D_PROP_DATE_3.GetValue -= D_PROP_DATE_3_GetValue;
            D_PROP_DATE_4.GetValue -= D_PROP_DATE_4_GetValue;
            D_PROP_DATE_5.GetValue -= D_PROP_DATE_5_GetValue;
            D_PROP_DATE_6.GetValue -= D_PROP_DATE_6_GetValue;
            D_PROP_DATE_7.GetValue -= D_PROP_DATE_7_GetValue;
            D_PROP_DATE_8.GetValue -= D_PROP_DATE_8_GetValue;
            D_PROP_DATE_9.GetValue -= D_PROP_DATE_9_GetValue;
            D_PROP_DATE_10.GetValue -= D_PROP_DATE_10_GetValue;
            D_PROP_DATE_1X.GetValue -= D_PROP_DATE_1X_GetValue;
            D_PROP_DATE_2X.GetValue -= D_PROP_DATE_2X_GetValue;
            D_PROP_DATE_3X.GetValue -= D_PROP_DATE_3X_GetValue;
            D_PROP_DATE_4X.GetValue -= D_PROP_DATE_4X_GetValue;
            D_PROP_DATE_5X.GetValue -= D_PROP_DATE_5X_GetValue;
            D_PROP_DATE_6X.GetValue -= D_PROP_DATE_6X_GetValue;
            D_PROP_DATE_7X.GetValue -= D_PROP_DATE_7X_GetValue;
            D_PROP_DATE_8X.GetValue -= D_PROP_DATE_8X_GetValue;
            D_PROP_DATE_9X.GetValue -= D_PROP_DATE_9X_GetValue;
            D_PROP_DATE_10X.GetValue -= D_PROP_DATE_10X_GetValue;
            D_STATUS_1.GetValue -= D_STATUS_1_GetValue;
            D_STATUS_2.GetValue -= D_STATUS_2_GetValue;
            D_STATUS_3.GetValue -= D_STATUS_3_GetValue;
            D_STATUS_4.GetValue -= D_STATUS_4_GetValue;
            D_STATUS_5.GetValue -= D_STATUS_5_GetValue;
            D_STATUS_6.GetValue -= D_STATUS_6_GetValue;
            D_STATUS_7.GetValue -= D_STATUS_7_GetValue;
            D_WEEK_END_DATE.GetValue -= D_WEEK_END_DATE_GetValue;
            D_DAY_1.GetValue -= D_DAY_1_GetValue;
            D_DAY_2.GetValue -= D_DAY_2_GetValue;
            D_DAY_3.GetValue -= D_DAY_3_GetValue;
            D_DAY_4.GetValue -= D_DAY_4_GetValue;
            D_DAY_5.GetValue -= D_DAY_5_GetValue;
            D_DAY_6.GetValue -= D_DAY_6_GetValue;
            D_DAY_7.GetValue -= D_DAY_7_GetValue;
            D_PRP_1.GetValue -= D_PRP_1_GetValue;
            D_PRP_2.GetValue -= D_PRP_2_GetValue;
            D_PRP_3.GetValue -= D_PRP_3_GetValue;
            D_PRP_4.GetValue -= D_PRP_4_GetValue;
            D_PRP_5.GetValue -= D_PRP_5_GetValue;
            D_PRP_6.GetValue -= D_PRP_6_GetValue;
            D_PRP_7.GetValue -= D_PRP_7_GetValue;
            D_PART_POINTS.GetValue -= D_PART_POINTS_GetValue;
            D_DAY_STATUS_1.GetValue -= D_DAY_STATUS_1_GetValue;
            D_DAY_STATUS_2.GetValue -= D_DAY_STATUS_2_GetValue;
            D_DAY_STATUS_3.GetValue -= D_DAY_STATUS_3_GetValue;
            D_DAY_STATUS_4.GetValue -= D_DAY_STATUS_4_GetValue;
            D_DAY_STATUS_5.GetValue -= D_DAY_STATUS_5_GetValue;
            D_DAY_STATUS_6.GetValue -= D_DAY_STATUS_6_GetValue;
            D_DAY_STATUS_7.GetValue -= D_DAY_STATUS_7_GetValue;
            D_LAST_PERIOD.GetValue -= D_LAST_PERIOD_GetValue;
            D_SCREEN_END.GetValue -= D_SCREEN_END_GetValue;
            D_SCREEN_START.GetValue -= D_SCREEN_START_GetValue;
            D_UNDER_A_WEEK.GetValue -= D_UNDER_A_WEEK_GetValue;
            D_BOOKDATE_28.GetValue -= D_BOOKDATE_28_GetValue;
            D_BOOKDATE_21.GetValue -= D_BOOKDATE_21_GetValue;
            D_BOOKDATE_42.GetValue -= D_BOOKDATE_42_GetValue;
            D_BOOKDATE_56.GetValue -= D_BOOKDATE_56_GetValue;
            D_BOOKDATE_14.GetValue -= D_BOOKDATE_14_GetValue;
            D_START_DATE.GetValue -= D_START_DATE_GetValue;
            D_UK.GetValue -= D_UK_GetValue;
            D_POINTS_FREE.GetValue -= D_POINTS_FREE_GetValue;
            D_WITHIN_21_DAYS.GetValue -= D_WITHIN_21_DAYS_GetValue;
            D_PAY_USER_CHARGE.GetValue -= D_PAY_USER_CHARGE_GetValue;
            D_SET_USER_CHARGE.GetValue -= D_SET_USER_CHARGE_GetValue;
            D_USER_CHARGES.GetValue -= D_USER_CHARGES_GetValue;
            D_USER_CHARGE.GetValue -= D_USER_CHARGE_GetValue;
            D_SPLIT_CHARGE.GetValue -= D_SPLIT_CHARGE_GetValue;
            D_CHARGE_7TH.GetValue -= D_CHARGE_7TH_GetValue;
            D_RATE.GetValue -= D_RATE_GetValue;
            D_EXTRADAYS_CHARGE.GetValue -= D_EXTRADAYS_CHARGE_GetValue;
            D_TERM_SURCHARGEPER.GetValue -= D_TERM_SURCHARGEPER_GetValue;
            D_2_YEARS.GetValue -= D_2_YEARS_GetValue;
            D_IN_RANGE.GetValue -= D_IN_RANGE_GetValue;
            D_DAY_1_OK.GetValue -= D_DAY_1_OK_GetValue;
            D_DAY_2_OK.GetValue -= D_DAY_2_OK_GetValue;
            D_DAY_3_OK.GetValue -= D_DAY_3_OK_GetValue;
            D_DAY_4_OK.GetValue -= D_DAY_4_OK_GetValue;
            D_DAY_5_OK.GetValue -= D_DAY_5_OK_GetValue;
            D_DAY_6_OK.GetValue -= D_DAY_6_OK_GetValue;
            D_DAY_7_OK.GetValue -= D_DAY_7_OK_GetValue;
            D_SPLIT_VALID.GetValue -= D_SPLIT_VALID_GetValue;
            D_SPLIT_CHARGE_PER.GetValue -= D_SPLIT_CHARGE_PER_GetValue;
            D_SPLIT_POINTS_PER.GetValue -= D_SPLIT_POINTS_PER_GetValue;
            D_SILVER_CHARGE.GetValue -= D_SILVER_CHARGE_GetValue;
            D_ON_REQUEST_DATE.GetValue -= D_ON_REQUEST_DATE_GetValue;
            D_ON_REQUEST.GetValue -= D_ON_REQUEST_GetValue;
            D_VAT.GetValue -= D_VAT_GetValue;
            D_WEEKS.GetValue -= D_WEEKS_GetValue;
            D_POINTS_WEEKS.GetValue -= D_POINTS_WEEKS_GetValue;
            D_PFIA_WEEKS.GetValue -= D_PFIA_WEEKS_GetValue;
            D_DEPOSIT_AMT.GetValue -= D_DEPOSIT_AMT_GetValue;
            D_OFFER_DEPOSIT.GetValue -= D_OFFER_DEPOSIT_GetValue;
            D_DUE_NOW.GetValue -= D_DUE_NOW_GetValue;
            D_VAT_NOW.GetValue -= D_VAT_NOW_GetValue;
            D_VAT_BALANCE.GetValue -= D_VAT_BALANCE_GetValue;
            D_SHHL_BALANCE.GetValue -= D_SHHL_BALANCE_GetValue;
            D_DEPOSITPER.GetValue -= D_DEPOSITPER_GetValue;
            D_DUE_NOW_TEXT.GetValue -= D_DUE_NOW_TEXT_GetValue;
            D_BOOKING_NO.GetValue -= D_BOOKING_NO_GetValue;
            D_PROP_CODE.GetValue -= D_PROP_CODE_GetValue;
            fldT_START_DATE.Input -= fldT_START_DATE_Input;
            fldBOOKINGS_BK_ADDON.Input -= fldBOOKINGS_BK_ADDON_Input;
            fldBOOKINGS_BK_ADDON.Edit -= fldBOOKINGS_BK_ADDON_Edit;
            fldT_START_WEEK.Edit -= fldT_START_WEEK_Edit;
            fldT_END_WEEK.Input -= fldT_END_WEEK_Input;
            fldT_END_WEEK.Edit -= fldT_END_WEEK_Edit;
            fldT_START_DATE.Edit -= fldT_START_DATE_Edit;
            fldT_END_DATE.Input -= fldT_END_DATE_Input;
            fldT_END_DATE.Edit -= fldT_END_DATE_Edit;
            T_START_DATE.GetInitialValue -= T_START_DATE_GetInitialValue;
            T_END_DATE.GetInitialValue -= T_END_DATE_GetInitialValue;
            T_START_WEEK.GetInitialValue -= T_START_WEEK_GetInitialValue;
            T_END_WEEK.GetInitialValue -= T_END_WEEK_GetInitialValue;
            fldBOOKINGS_BK_SUSPENSE.Process -= fldBOOKINGS_BK_SUSPENSE_Process;
            fldBOOKINGS_BK_PURCHASE.Process -= fldBOOKINGS_BK_PURCHASE_Process;
            fldBOOKINGS_BK_OVERDRAFT.Process -= fldBOOKINGS_BK_OVERDRAFT_Process;
            fldT_START_DATE.Process -= fldT_START_DATE_Process;
            fldBOOKINGS_BOOKING_CHARGE.Process -= fldBOOKINGS_BOOKING_CHARGE_Process;
            fldBOOKINGS_POINTS_ADJUST.Process -= fldBOOKINGS_POINTS_ADJUST_Process;
            fldBOOKINGS_LONG_STAY.Process -= fldBOOKINGS_LONG_STAY_Process;
            fleBOOKINGS.SetItemFinals -= fleBOOKINGS_SetItemFinals;
            flePURCHASE_DEBTS.SetItemFinals -= flePURCHASE_DEBTS_SetItemFinals;
            fleUCHARGE_DEBTS.SetItemFinals -= fleUCHARGE_DEBTS_SetItemFinals;
            fleBALANCE_DEBTS.SetItemFinals -= fleBALANCE_DEBTS_SetItemFinals;
            fldBOOKINGS_BK_SUSPENSE.Process -= fldBOOKINGS_BK_SUSPENSE_Process;
            fldBOOKINGS_BK_PURCHASE.Process -= fldBOOKINGS_BK_PURCHASE_Process;
            fldBOOKINGS_BK_OVERDRAFT.Process -= fldBOOKINGS_BK_OVERDRAFT_Process;
            fldT_START_DATE.Process -= fldT_START_DATE_Process;
            fldBOOKINGS_BOOKING_CHARGE.Process -= fldBOOKINGS_BOOKING_CHARGE_Process;
            fldBOOKINGS_POINTS_ADJUST.Process -= fldBOOKINGS_POINTS_ADJUST_Process;
            fldBOOKINGS_LONG_STAY.Process -= fldBOOKINGS_LONG_STAY_Process;
            fleBOOKINGS.InitializeItems -= fleBOOKINGS_InitializeItems;
            dsrDesigner_09.Click -= dsrDesigner_09_Click;
            dsrDesigner_01.Click -= dsrDesigner_01_Click;
            dsrDesigner_INV.Click -= dsrDesigner_INV_Click;
            dsrDesigner_PROP.Click -= dsrDesigner_PROP_Click;
            dsrDesigner_COMM.Click -= dsrDesigner_COMM_Click;
            dsrDesigner_LD.Click -= dsrDesigner_LD_Click;
            dsrDesigner_SW.Click -= dsrDesigner_SW_Click;
            dsrDesigner_DMD.Click -= dsrDesigner_DMD_Click;
            dsrDesigner_UC.Click -= dsrDesigner_UC_Click;
            dsrDesigner_FLIGHTS.Click -= dsrDesigner_FLIGHTS_Click;
            dsrDesigner_06.Click -= dsrDesigner_06_Click;
            dsrDesigner_07.Click -= dsrDesigner_07_Click;
            dsrDesigner_03.Click -= dsrDesigner_03_Click;
            dsrDesigner_04.Click -= dsrDesigner_04_Click;
            dsrDesigner_05.Click -= dsrDesigner_05_Click;
            dsrDesigner_08.Click -= dsrDesigner_08_Click;
            dsrDesigner_11.Click -= dsrDesigner_11_Click;


        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private OracleConnection m_cnnQUERY = new OracleConnection();
        private OracleConnection m_cnnTRANS_UPDATE = new OracleConnection();
        private OracleTransaction m_trnTRANS_UPDATE;
        private OracleFileObject fleM_INVESTORS;
        private OracleFileObject fleUSER_SEC_FILE;
        private OracleFileObject flePROPERTY_YEARS;
        private OracleFileObject flePROPERTY_YEARS_DTL;
        private OracleFileObject fleSCREEN_PROPERTY;
        private OracleFileObject flePROPERTIES;
        private OracleFileObject flePROP_COMMENTS;
        private OracleFileObject fleBOOK0100_COMM;
        private CoreDecimal M_START_PERIOD;
        private CoreDecimal M_END_PERIOD;
        private CoreDate M_START_DATE;
        private CoreDate M_END_DATE;
        private CoreCharacter M_BOOKED;
        private CoreDate T_START_DATE;
        private void T_START_DATE_GetInitialValue()
        {
            T_START_DATE.InitialValue = M_START_DATE.Value;
        }
        private CoreDate T_END_DATE;
        private void T_END_DATE_GetInitialValue()
        {
            T_END_DATE.InitialValue = M_END_DATE.Value;
        }
        private CoreDecimal T_START_WEEK;
        private void T_START_WEEK_GetInitialValue()
        {
            T_START_WEEK.InitialValue = M_START_PERIOD.Value;
        }
        private CoreDecimal T_END_WEEK;
        private void T_END_WEEK_GetInitialValue()
        {
            T_END_WEEK.InitialValue = M_END_PERIOD.Value;
        }
        private CoreCharacter SCREEN_PROPERTY_PROPERTY_CODE;
        private CoreCharacter T_BOOKING_REF;
        private CoreCharacter X_BOOKING_REF;
        private CoreInteger T_TERM_SURCHARGE;
        private CoreCharacter T_FIXED_DEBT;
        private CoreCharacter T_BOGOF_DEPOSIT;
        private CoreCharacter T_PFIA_DEPOSIT;
        private DCharacter D_DEPOSIT = new DCharacter(1);
        private void D_DEPOSIT_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if ((90 < QDesign.NULL((QDesign.Days(T_START_DATE.Value) - QDesign.Days(QDesign.SysDate(ref m_cnnQUERY)))) && QDesign.NULL(flePROPERTIES.GetStringValue("DEPOSIT_REQUIRED")) == "Y") || QDesign.NULL(T_BOGOF_DEPOSIT.Value) == "Y" || QDesign.NULL(T_BOGOF_DEPOSIT.Value) == "1" || QDesign.NULL(T_PFIA_DEPOSIT.Value) == "Y")
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
        private OracleFileObject fleBOOKINGS;

        private void fleBOOKINGS_InitializeItems(bool Fixed)
        {

            try
            {
                if (!Fixed)
                    fleBOOKINGS.set_SetValue("BOOKING_REF", true, T_BOOKING_REF.Value);
                if (!Fixed)
                    fleBOOKINGS.set_SetValue("USER_LOGON", true, UserID);
                if (!Fixed)
                    fleBOOKINGS.set_SetValue("BOOKING_STATUS", true, "RS");
                if (!Fixed)
                    fleBOOKINGS.set_SetValue("LONG_STAY", true, "N");
                if (!Fixed)
                    fleBOOKINGS.set_SetValue("DEPOSIT", true, 0);
                if (!Fixed)
                    fleBOOKINGS.set_SetValue("CONFIRM_DATE", true, QDesign.PhDate(QDesign.Days(QDesign.SysDate(ref m_cnnQUERY)) + 14));


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fleBOOKINGS_SetItemFinals()
        {

            try
            {
                if (QDesign.NULL(fleBOOKINGS.GetDecimalValue("BOOKING_CHARGE")) == 0)
                {
                    fleBOOKINGS.set_SetValue("VAT", 0);
                }
                fleBOOKINGS.set_SetValue("LOCATION", flePROPERTY_YEARS.GetStringValue("LOCATION"));
                fleBOOKINGS.set_SetValue("BEDS", flePROPERTY_YEARS.GetStringValue("BEDS"));
                fleBOOKINGS.set_SetValue("PROPERTY_STYLE", flePROPERTY_YEARS.GetStringValue("PROPERTY_STYLE"));
                fleBOOKINGS.set_SetValue("BATHROOMS", flePROPERTY_YEARS.GetStringValue("BATHROOMS"));
                fleBOOKINGS.set_SetValue("PROPERTY_ID", flePROPERTY_YEARS.GetStringValue("PROPERTY_ID"));
                fleBOOKINGS.set_SetValue("YEAR", flePROPERTY_YEARS.GetStringValue("YEAR"));

                fleBOOKINGS.set_SetValue("INVESTOR", fleM_INVESTORS.GetStringValue("INVESTOR"));
                fleBOOKINGS.set_SetValue("LOC_KEY", fleBOOKINGS.GetStringValue("LOCATION"));
                fleBOOKINGS.set_SetValue("BOOKING_DATE", QDesign.SysDate(ref m_cnnQUERY));
                fleBOOKINGS.set_SetValue("BOOKING_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);
                fleBOOKINGS.set_SetValue("BOOKING_YM", QDesign.Substring(QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8), 1, 6));
                if (QDesign.NULL(T_START_WEEK.Value) != 0)
                {
                    fleBOOKINGS.set_SetValue("START_WEEK", T_START_WEEK.Value);
                }
                else
                {
                    fleBOOKINGS.set_SetValue("START_WEEK", T_END_WEEK.Value);
                }
                fleBOOKINGS.set_SetValue("END_WEEK", T_END_WEEK.Value);
                fleBOOKINGS.set_SetValue("GROUPING", flePROPERTIES.GetStringValue("GROUPING"));
                fleBOOKINGS.set_SetValue("CONFIRM_DATE", D_CONFIRM_DATE.Value);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }

        private DCharacter D_BRITISH = new DCharacter(1);
        private void D_BRITISH_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(QDesign.Substring(fleM_INVESTORS.GetStringValue("POST_CODE_AREA"), 1, 1)) != "X" || (QDesign.NULL(QDesign.Substring(fleM_INVESTORS.GetStringValue("POST_CODE_AREA"), 3, 3)) == "IOM" || QDesign.NULL(QDesign.Substring(fleM_INVESTORS.GetStringValue("POST_CODE_AREA"), 3, 3)) == "GCI"))
                {
                    CurrentValue = "Y";
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
        private DDecimal D_CONF_BY = new DDecimal();
        private void D_CONF_BY_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0m;
                if (QDesign.NULL(D_BRITISH.Value) == "Y" && QDesign.NULL(fleBOOKING_PERIODS_DTL.GetDecimalValue("START_DATE")) > QDesign.NULL(QDesign.PhDate(QDesign.Days(QDesign.SysDate(ref m_cnnQUERY)) + 70)))
                {
                    CurrentValue = QDesign.PhDate(QDesign.Days(QDesign.SysDate(ref m_cnnQUERY)) + 7);
                }
                else
                {
                    CurrentValue = QDesign.PhDate(QDesign.Days(QDesign.SysDate(ref m_cnnQUERY)) + 14);
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
        private DDecimal D_CONFIRM_DATE = new DDecimal();
        private void D_CONFIRM_DATE_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0m;
                if (QDesign.NULL(fleBOOKINGS.GetDecimalValue("BOOKING_POINTS")) > 0 || 28 < QDesign.NULL((QDesign.Days(T_START_DATE.Value) - QDesign.Days(QDesign.SysDate(ref m_cnnQUERY)))))
                {
                    CurrentValue = D_CONF_BY.Value;
                }
                else
                {
                    CurrentValue = QDesign.PhDate(QDesign.Days(QDesign.SysDate(ref m_cnnQUERY)) + 5);
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
        private CoreCharacter T_HOLIDAY_YEAR;
        private CoreCharacter T_PREVIOUS_YEAR;
        private CoreCharacter T_FOLLOWING_YEAR;
        private DCharacter D_HOLIDAY_YEAR = new DCharacter(4);
        private void D_HOLIDAY_YEAR_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (fleM_INVESTORS.GetDecimalValue("HY1_DATE") >= T_START_DATE.Value)
                {
                    CurrentValue = fleM_INVESTORS.GetStringValue("HY1_YEAR");
                }
                else if (fleM_INVESTORS.GetDecimalValue("HY2_DATE") >= T_START_DATE.Value)
                {
                    CurrentValue = fleM_INVESTORS.GetStringValue("HY2_YEAR");
                }
                else if (fleM_INVESTORS.GetDecimalValue("HY3_DATE") >= T_START_DATE.Value)
                {
                    CurrentValue = fleM_INVESTORS.GetStringValue("HY3_YEAR");
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
        private DCharacter D_PREVIOUS_YEAR = new DCharacter(4);
        private void D_PREVIOUS_YEAR_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(T_HOLIDAY_YEAR.Value) == QDesign.NULL(fleM_INVESTORS.GetStringValue("HY1_YEAR")))
                {
                    CurrentValue = "  ";
                }
                else if (QDesign.NULL(T_HOLIDAY_YEAR.Value) == QDesign.NULL(fleM_INVESTORS.GetStringValue("HY2_YEAR")))
                {
                    CurrentValue = fleM_INVESTORS.GetStringValue("HY1_YEAR");
                }
                else if (QDesign.NULL(T_HOLIDAY_YEAR.Value) == QDesign.NULL(fleM_INVESTORS.GetStringValue("HY3_YEAR")))
                {
                    CurrentValue = fleM_INVESTORS.GetStringValue("HY2_YEAR");
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
        private DCharacter D_FOLLOWING_YEAR = new DCharacter(4);
        private void D_FOLLOWING_YEAR_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(T_HOLIDAY_YEAR.Value) == QDesign.NULL(fleM_INVESTORS.GetStringValue("HY3_YEAR")))
                {
                    CurrentValue = "  ";
                }
                else if (QDesign.NULL(T_HOLIDAY_YEAR.Value) == QDesign.NULL(fleM_INVESTORS.GetStringValue("HY1_YEAR")))
                {
                    CurrentValue = fleM_INVESTORS.GetStringValue("HY2_YEAR");
                }
                else if (QDesign.NULL(T_HOLIDAY_YEAR.Value) == QDesign.NULL(fleM_INVESTORS.GetStringValue("HY2_YEAR")))
                {
                    CurrentValue = fleM_INVESTORS.GetStringValue("HY3_YEAR");
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
        private OracleFileObject fleCURRENT_ENTS;

        private void fleCURRENT_ENTS_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleCURRENT_ENTS.ElementOwner("FILL_8")).Append(" = ").Append(Common.StringToField(fleM_INVESTORS.GetStringValue("INVESTOR")));
                strText.Append(" AND ").Append(fleCURRENT_ENTS.ElementOwner("YEAR")).Append(" = ").Append(Common.StringToField(T_HOLIDAY_YEAR.Value));

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

        private OracleFileObject flePREVIOUS_ENT;

        private void flePREVIOUS_ENT_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(flePREVIOUS_ENT.ElementOwner("FILL_8")).Append(" = ").Append(Common.StringToField(fleM_INVESTORS.GetStringValue("INVESTOR")));
                strText.Append(" AND ").Append(flePREVIOUS_ENT.ElementOwner("YEAR")).Append(" = ").Append(Common.StringToField(T_PREVIOUS_YEAR.Value));

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

        private OracleFileObject fleFOLLOWING_ENT;

        private void fleFOLLOWING_ENT_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleFOLLOWING_ENT.ElementOwner("FILL_8")).Append(" = ").Append(Common.StringToField(fleM_INVESTORS.GetStringValue("INVESTOR")));
                strText.Append(" AND ").Append(fleFOLLOWING_ENT.ElementOwner("YEAR")).Append(" = ").Append(Common.StringToField(T_FOLLOWING_YEAR.Value));

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

                strText.Append(" WHERE ").Append(fleSUSP_ACCOUNT.ElementOwner("INVESTOR")).Append(" = ").Append(Common.StringToField(fleM_INVESTORS.GetStringValue("INVESTOR")));

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

                strText.Append(" WHERE ").Append(fleFORF_ACCOUNT.ElementOwner("INVESTOR")).Append(" = ").Append(Common.StringToField(fleM_INVESTORS.GetStringValue("INVESTOR")));

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

                strText.Append(" WHERE ").Append(fleANNUAL_ENT.ElementOwner("INVESTOR")).Append(" = ").Append(Common.StringToField(fleM_INVESTORS.GetStringValue("INVESTOR")));

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

        private OracleFileObject fleINVESTMENTS;

        private void fleINVESTMENTS_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleINVESTMENTS.ElementOwner("INVESTOR")).Append(" = ").Append(Common.StringToField(fleM_INVESTORS.GetStringValue("INVESTOR")));

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
        private OracleFileObject fleCHARGES;
        private OracleFileObject fleCHARGES_DTL;

        private void fleCHARGES_DTL_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleCHARGES_DTL.ElementOwner("LOCATION")).Append(" = ").Append(Common.StringToField(fleCHARGES.GetStringValue("LOCATION")));
                strText.Append(" AND ").Append(fleCHARGES_DTL.ElementOwner("BEDS")).Append(" = ").Append(Common.StringToField(fleCHARGES.GetStringValue("BEDS")));
                strText.Append(" AND ").Append(fleCHARGES_DTL.ElementOwner("PROPERTY_STYLE")).Append(" = ").Append(Common.StringToField(fleCHARGES.GetStringValue("PROPERTY_STYLE")));
                strText.Append(" AND ").Append(fleCHARGES_DTL.ElementOwner("BATHROOMS")).Append(" = ").Append(Common.StringToField(fleCHARGES.GetStringValue("BATHROOMS")));
                strText.Append(" AND ").Append(fleCHARGES_DTL.ElementOwner("YEAR")).Append(" = ").Append(Common.StringToField(fleCHARGES.GetStringValue("YEAR")));

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

        private void fleCHARGES_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleCHARGES.ElementOwner("LOCATION")).Append(" = ").Append(Common.StringToField(fleSCREEN_PROPERTY.GetStringValue("LOCATION")));
                strText.Append(" AND ").Append(fleCHARGES.ElementOwner("BEDS")).Append(" = ").Append(Common.StringToField(fleSCREEN_PROPERTY.GetStringValue("BEDS")));
                strText.Append(" AND ").Append(fleCHARGES.ElementOwner("PROPERTY_STYLE")).Append(" = ").Append(Common.StringToField(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_STYLE")));
                strText.Append(" AND ").Append(fleCHARGES.ElementOwner("BATHROOMS")).Append(" = ").Append(Common.StringToField(fleSCREEN_PROPERTY.GetStringValue("BATHROOMS")));
                strText.Append(" AND ").Append(fleCHARGES.ElementOwner("YEAR")).Append(" = ").Append(Common.StringToField(fleSCREEN_PROPERTY.GetStringValue("YEAR")));

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



        private void flePURCHASE_DEBTS_SetItemFinals()
        {

            try
            {
                flePURCHASE_DEBTS.set_SetValue("INVESTOR", fleM_INVESTORS.GetStringValue("INVESTOR"));
                flePURCHASE_DEBTS.set_SetValue("BOOKING_REF", fleBOOKINGS.GetStringValue("BOOKING_REF"));
                flePURCHASE_DEBTS.set_SetValue("CREATE_DATE", QDesign.SysDate(ref m_cnnQUERY));
                flePURCHASE_DEBTS.set_SetValue("TIME_STAMP", QDesign.SysTime(ref m_cnnQUERY) / 10000);
                flePURCHASE_DEBTS.set_SetValue("DEBT_TYPE", "PU");
                flePURCHASE_DEBTS.set_SetValue("PAYMENT_TYPE", "F");
                if (QDesign.NULL(flePROPERTIES.GetStringValue("VAT_FLAG")) == "Y")
                {
                    flePURCHASE_DEBTS.set_SetValue("VAT", QDesign.Round(flePURCHASE_DEBTS.GetDecimalValue("DEBT_AMOUNT") / (fleCOLOUR_RATES.GetDecimalValue("COLOUR_RATE") + 1000000) * fleCOLOUR_RATES.GetDecimalValue("COLOUR_RATE"), 0, RoundOptionTypes.Near));
                }
                else
                {
                    flePURCHASE_DEBTS.set_SetValue("VAT", 0);
                }
                flePURCHASE_DEBTS.set_SetValue("PP1_VAT", 0);
                flePURCHASE_DEBTS.set_SetValue("PP2_VAT", 0);
                flePURCHASE_DEBTS.set_SetValue("CC_VAT", 0);
                flePURCHASE_DEBTS.set_SetValue("TERM_VAT", 0);
                flePURCHASE_DEBTS.set_SetValue("NOTIONAL_VAT", 0);
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

        private DInteger D_USE_FIRST = new DInteger(8);
        private void D_USE_FIRST_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0;
                if (QDesign.NULL(fleCURRENT_ENTS.GetStringValue("YEAR_123")) == "01")
                {
                    CurrentValue = fleCURRENT_ENTS.GetDecimalValue("BF_BAL");
                }
                else
                {
                    CurrentValue = fleCURRENT_ENTS.GetDecimalValue("ENTITLEMENT_BAL");
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
        private DDecimal D_SILVER_SURCHARGE = new DDecimal(8);
        private void D_SILVER_SURCHARGE_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0m;
                if (QDesign.NULL(fleM_INVESTORS.GetStringValue("COLOUR")) != "S")
                {
                    CurrentValue = 1;
                }
                else if (QDesign.NULL(fleM_INVESTORS.GetStringValue("COLOUR")) == "S" && (QDesign.NULL(flePROPERTY_YEARS.GetStringValue("LOCATION")) == "KA" || QDesign.NULL(flePROPERTY_YEARS.GetStringValue("LOCATION")) == "IH"))
                {
                    CurrentValue = (decimal)1.5;
                }
                else
                {
                    CurrentValue = 1;
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
        private CoreInteger T_POINTS_1;
        private CoreInteger T_POINTS_2;
        private CoreInteger T_POINTS_3;
        private CoreInteger T_POINTS_4;
        private CoreInteger T_POINTS_5;
        private CoreInteger T_POINTS_6;
        private CoreInteger T_POINTS_7;
        private DInteger D_POINTS = new DInteger(9);
        private void D_POINTS_GetValue(ref decimal Value)
        {

            try
            {
                Value = (T_POINTS_1.Value + T_POINTS_2.Value + T_POINTS_3.Value + T_POINTS_4.Value + T_POINTS_5.Value + T_POINTS_6.Value + T_POINTS_7.Value) * D_SILVER_SURCHARGE.Value;


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DInteger D_NET_POINTS = new DInteger(9);
        private void D_NET_POINTS_GetValue(ref decimal Value)
        {

            try
            {
                Value = D_POINTS.Value - fleBOOKINGS.GetDecimalValue("POINTS_ADJUST");


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DInteger D_PP1_SURCHARGE = new DInteger(8);
        private void D_PP1_SURCHARGE_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0;

                // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

                if (QDesign.NULL(fleANNUAL_ENT.GetDecimalValue("PP1_SURCHARGEPER")) > 0)
                {
                    CurrentValue = ((D_NET_POINTS.Value * fleANNUAL_ENT.GetDecimalValue("PP1_SURCHARGEPER")) * fleANNUAL_ENT.GetDecimalValue("PP1_CHARGE")) / 1000000;
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
        private DInteger D_PP2_SURCHARGE = new DInteger(8);
        private void D_PP2_SURCHARGE_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0;

                // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

                if (QDesign.NULL(fleANNUAL_ENT.GetDecimalValue("PP2_SURCHARGEPER")) > 0)
                {
                    CurrentValue = ((D_NET_POINTS.Value * fleANNUAL_ENT.GetDecimalValue("PP2_SURCHARGEPER")) * fleANNUAL_ENT.GetDecimalValue("PP2_CHARGE")) / 1000000;
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
        private DInteger D_PP_SURCHARGE = new DInteger(8);
        private void D_PP_SURCHARGE_GetValue(ref decimal Value)
        {

            try
            {
                Value = D_PP1_SURCHARGE.Value + D_PP2_SURCHARGE.Value;


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DCharacter D_PP_FLAG = new DCharacter(1);
        private void D_PP_FLAG_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(D_PP_SURCHARGE.Value) > 0)
                {
                    CurrentValue = "*";
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
        private DInteger D_NIGHTS = new DInteger(4);
        private void D_NIGHTS_GetValue(ref decimal Value)
        {

            try
            {
                Value = (QDesign.Days(T_END_DATE.Value) - QDesign.Days(T_START_DATE.Value)) + 1;


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DInteger D_NOTIONAL_VAT = new DInteger(9);
        private void D_NOTIONAL_VAT_GetValue(ref decimal Value)
        {

            try
            {
                Value = fleCHARGES.GetDecimalValue("NOTIONAL_VAT") * D_NIGHTS.Value;


            }
            catch (CustomApplicationException ex)
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



        private void fleUCHARGE_DEBTS_InitializeItems(bool Fixed)
        {

            try
            {
                fleUCHARGE_DEBTS.set_SetValue("DEBT_TYPE", !Fixed, "RS");
                if (!Fixed)
                    fleUCHARGE_DEBTS.set_SetValue("PAYMENT_TYPE", true, "F");


            }
            catch (CustomApplicationException ex)
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
                fleUCHARGE_DEBTS.set_SetValue("BOOKING_REF", fleBOOKINGS.GetStringValue("BOOKING_REF"));
                fleUCHARGE_DEBTS.set_SetValue("INVESTOR", fleM_INVESTORS.GetStringValue("INVESTOR"));
                fleUCHARGE_DEBTS.set_SetValue("CREATE_DATE", QDesign.SysDate(ref m_cnnQUERY));
                fleUCHARGE_DEBTS.set_SetValue("TIME_STAMP", QDesign.SysTime(ref m_cnnQUERY) / 10000);
                fleUCHARGE_DEBTS.set_SetValue("USER_LOGON", UserID);
                if (QDesign.NULL(fleUCHARGE_DEBTS.GetDecimalValue("DEBT_AMOUNT")) > 0 && QDesign.NULL(D_DEPOSIT.Value) == "N")
                {
                    fleUCHARGE_DEBTS.set_SetValue("NOTIONAL_VAT", D_NOTIONAL_VAT.Value);
                }
                else
                {
                    fleUCHARGE_DEBTS.set_SetValue("NOTIONAL_VAT", 0);
                }
                if (QDesign.NULL(D_DEPOSIT.Value) == "N")
                {
                    fleUCHARGE_DEBTS.set_SetValue("TERM_SURCHARGE", T_TERM_SURCHARGE.Value);
                }
                else
                {
                    fleUCHARGE_DEBTS.set_SetValue("TERM_SURCHARGE", 0);
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
                if (QDesign.NULL(fleUCHARGE_DEBTS.GetDecimalValue("DEBT_AMOUNT")) == 0)
                {
                    fleUCHARGE_DEBTS.set_SetValue("VAT", 0);
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



        private void fleBALANCE_DEBTS_InitializeItems(bool Fixed)
        {

            try
            {
                fleBALANCE_DEBTS.set_SetValue("DEBT_TYPE", !Fixed, "BL");


            }
            catch (CustomApplicationException ex)
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
                if ((QDesign.NULL(QDesign.Substring(fleBOOKINGS.GetStringValue("GROUPING"), 1, 3)) == "SHH" || QDesign.NULL(fleBOOKINGS.GetStringValue("LONG_STAY")) == "S"))
                {
                    fleBALANCE_DEBTS.set_SetValue("FIXED_DEBT", "Y");
                }
                else
                {
                    fleBALANCE_DEBTS.set_SetValue("FIXED_DEBT", T_FIXED_DEBT.Value);
                }
                fleBALANCE_DEBTS.set_SetValue("BOOKING_REF", fleBOOKINGS.GetStringValue("BOOKING_REF"));
                fleBALANCE_DEBTS.set_SetValue("INVESTOR", fleM_INVESTORS.GetStringValue("INVESTOR"));
                fleBALANCE_DEBTS.set_SetValue("CREATE_DATE", QDesign.SysDate(ref m_cnnQUERY));
                fleBALANCE_DEBTS.set_SetValue("TIME_STAMP", QDesign.SysTime(ref m_cnnQUERY) / 10000);
                fleBALANCE_DEBTS.set_SetValue("USER_LOGON", UserID);
                fleBALANCE_DEBTS.set_SetValue("PAYMENT_TYPE", "B");
                if (QDesign.NULL(fleBALANCE_DEBTS.GetDecimalValue("DEBT_AMOUNT")) > 0 && QDesign.NULL(D_DEPOSIT.Value) == "Y")
                {
                    fleBALANCE_DEBTS.set_SetValue("NOTIONAL_VAT", D_NOTIONAL_VAT.Value);
                }
                else
                {
                    fleBALANCE_DEBTS.set_SetValue("NOTIONAL_VAT", 0);
                }
                if (QDesign.NULL(D_DEPOSIT.Value) == "Y")
                {
                    fleBALANCE_DEBTS.set_SetValue("TERM_SURCHARGE", T_TERM_SURCHARGE.Value);
                }
                else
                {
                    fleBALANCE_DEBTS.set_SetValue("TERM_SURCHARGE", 0);
                }
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
                if (QDesign.NULL(fleBALANCE_DEBTS.GetDecimalValue("DEBT_AMOUNT")) == 0)
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

        private OracleFileObject fleSPLIT_WEEKS;

        private void fleSPLIT_WEEKS_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleSPLIT_WEEKS.ElementOwner("LOCATION")).Append(" = ").Append(Common.StringToField(fleSCREEN_PROPERTY.GetStringValue("LOCATION")));

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



        private void fleSPLIT_WEEKS_SelectIf(ref string SelectIfClause)
        {


            try
            {
                StringBuilder strSQL = new StringBuilder("");

                strSQL.Append(" (  T_START_DATE.Value  >=   ").Append(fleSPLIT_WEEKS.ElementOwner("FROM_DATE")).Append(" AND ");
                strSQL.Append("  T_START_DATE.Value  <=   ").Append(fleSPLIT_WEEKS.ElementOwner("TO_DATE")).Append(")");
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

        private OracleFileObject fleBOOKING_PERIODS;
        private OracleFileObject fleBOOKING_PERIODS_DTL;
        private OracleFileObject fleLOCATIONS;
        private OracleFileObject fleLOCATION_CURR;

        private void fleLOCATION_CURR_SelectIf(ref string SelectIfClause)
        {


            try
            {
                StringBuilder strSQL = new StringBuilder("");

                strSQL.Append(" (  ").Append(Common.StringToField(flePROPERTY_YEARS.GetStringValue("YEAR"))).Append(" >=   ").Append(fleLOCATION_CURR.ElementOwner("START_YEAR")).Append(" AND ");
                strSQL.Append("  ").Append(Common.StringToField(flePROPERTY_YEARS.GetStringValue("YEAR"))).Append(" <=   ").Append(fleLOCATION_CURR.ElementOwner("END_YEAR")).Append(")");
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

        private OracleFileObject fleCURRENCY_CODE;
        private OracleFileObject fleCURRENCY_RATE;
        private OracleFileObject flePROP_BK_COMMENTS;

        private void flePROP_BK_COMMENTS_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(flePROP_BK_COMMENTS.ElementOwner("PROPERTY_CODE")).Append(" = ").Append(Common.StringToField(flePROPERTY_YEARS.GetStringValue("LOCATION") + flePROPERTY_YEARS.GetStringValue("BEDS") + flePROPERTY_YEARS.GetStringValue("PROPERTY_STYLE") + flePROPERTY_YEARS.GetStringValue("BATHROOMS") + flePROPERTY_YEARS.GetStringValue("PROPERTY_ID")));
                //Parent:PROPERTY_CODE

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



        private void flePROP_BK_COMMENTS_SelectIf(ref string SelectIfClause)
        {


            try
            {
                StringBuilder strSQL = new StringBuilder("");

                strSQL.Append(" ( (  T_START_DATE.Value  <=   ").Append(flePROP_BK_COMMENTS.ElementOwner("COMM_END_DATE")).Append(" AND ");
                strSQL.Append("  T_END_DATE.Value  >=   ").Append(flePROP_BK_COMMENTS.ElementOwner("COMM_STRT_DATE")).Append(" ))");
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

        private OracleFileObject fleLOCN_BK_COMMENTS;

        private void fleLOCN_BK_COMMENTS_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleLOCN_BK_COMMENTS.ElementOwner("LOCATION")).Append(" = ").Append(Common.StringToField(flePROPERTY_YEARS.GetStringValue("LOCATION")));

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



        private void fleLOCN_BK_COMMENTS_SelectIf(ref string SelectIfClause)
        {


            try
            {
                StringBuilder strSQL = new StringBuilder("");

                strSQL.Append(" ( (  T_START_DATE.Value  <=   ").Append(fleLOCN_BK_COMMENTS.ElementOwner("COMM_END_DATE")).Append(" AND ");
                strSQL.Append("  T_END_DATE.Value  >=   ").Append(fleLOCN_BK_COMMENTS.ElementOwner("COMM_STRT_DATE")).Append(" ))");
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

        private DCharacter D_START_DOW = new DCharacter(3);
        private void D_START_DOW_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (1 == QDesign.NULL((QDesign.PHMod(QDesign.Days(T_START_DATE.Value), 7))))
                {
                    CurrentValue = "MON";
                }
                else if (2 == QDesign.NULL((QDesign.PHMod(QDesign.Days(T_START_DATE.Value), 7))))
                {
                    CurrentValue = "TUE";
                }
                else if (3 == QDesign.NULL((QDesign.PHMod(QDesign.Days(T_START_DATE.Value), 7))))
                {
                    CurrentValue = "WED";
                }
                else if (4 == QDesign.NULL((QDesign.PHMod(QDesign.Days(T_START_DATE.Value), 7))))
                {
                    CurrentValue = "THU";
                }
                else if (5 == QDesign.NULL((QDesign.PHMod(QDesign.Days(T_START_DATE.Value), 7))))
                {
                    CurrentValue = "FRI";
                }
                else if (6 == QDesign.NULL((QDesign.PHMod(QDesign.Days(T_START_DATE.Value), 7))))
                {
                    CurrentValue = "SAT";
                }
                else if (0 == QDesign.NULL((QDesign.PHMod(QDesign.Days(T_START_DATE.Value), 7))))
                {
                    CurrentValue = "SUN";
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
        private DCharacter D_END_DOW = new DCharacter(3);
        private void D_END_DOW_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (1 == QDesign.NULL((QDesign.PHMod(QDesign.Days(T_END_DATE.Value), 7))))
                {
                    CurrentValue = "MON";
                }
                else if (2 == QDesign.NULL((QDesign.PHMod(QDesign.Days(T_END_DATE.Value), 7))))
                {
                    CurrentValue = "TUE";
                }
                else if (3 == QDesign.NULL((QDesign.PHMod(QDesign.Days(T_END_DATE.Value), 7))))
                {
                    CurrentValue = "WED";
                }
                else if (4 == QDesign.NULL((QDesign.PHMod(QDesign.Days(T_END_DATE.Value), 7))))
                {
                    CurrentValue = "THU";
                }
                else if (5 == QDesign.NULL((QDesign.PHMod(QDesign.Days(T_END_DATE.Value), 7))))
                {
                    CurrentValue = "FRI";
                }
                else if (6 == QDesign.NULL((QDesign.PHMod(QDesign.Days(T_END_DATE.Value), 7))))
                {
                    CurrentValue = "SAT";
                }
                else if (0 == QDesign.NULL((QDesign.PHMod(QDesign.Days(T_END_DATE.Value), 7))))
                {
                    CurrentValue = "SUN";
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
        private DCharacter D_PROP_COMM = new DCharacter(60);
        private void D_PROP_COMM_GetValue(ref string Value)
        {

            try
            {
                Value = flePROP_BK_COMMENTS.GetStringValue("BK_COMMENT_1");


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DInteger D_CONVERT_FIELD = new DInteger(3);
        private void D_CONVERT_FIELD_GetValue(ref decimal Value)
        {

            try
            {
                Value = QDesign.NConvert(FieldText);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DInteger D_FULL_CHARGE = new DInteger(9);
        private void D_FULL_CHARGE_GetValue(ref decimal Value)
        {

            try
            {
                Value = fleBOOKINGS.GetDecimalValue("BOOKING_CHARGE") + D_PP_SURCHARGE.Value + T_TERM_SURCHARGE.Value;


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DDecimal D_DAYS_DIFF = new DDecimal(2);
        private void D_DAYS_DIFF_GetValue(ref decimal Value)
        {

            try
            {
                Value = QDesign.Days(T_START_DATE.Value) - QDesign.Days(QDesign.SysDate(ref m_cnnQUERY));


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DDecimal D_PAY_TIME = new DDecimal(2);
        private void D_PAY_TIME_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0m;
                if (QDesign.NULL(QDesign.Substring(flePROPERTIES.GetStringValue("GROUPING"), 1, 3)) == "TEN")
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
        private CoreCharacter T_DUE_NOW;
        private DCharacter D_DUE_NOW_MESSAGE = new DCharacter(31);
        private void D_DUE_NOW_MESSAGE_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(T_DUE_NOW.Value) == "Y")
                {
                    CurrentValue = "*** USER CHARGE IS NOW DUE ***";
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
        private CoreInteger T_OVERDRAFT;
        private CoreCharacter T_USE_FORF_BAL;
        private CoreCharacter T_REQUEST;
        private CoreCharacter T_COMMENTS;
        private CoreCharacter T_NEW_BOOKING;
        private CoreCharacter T_ALLOW;
        private CoreCharacter T_CONTINUE;
        private CoreCharacter T_AREA;
        private CoreCharacter T_INVESTOR;
        private CoreCharacter T_LOCATION;
        private CoreCharacter T_PROPERTY_ID;
        private CoreCharacter T_PROPERTY_CODE;
        private CoreInteger T_BALANCE;
        private CoreCharacter T_TEN_SHH_SPLIT;
        private CoreInteger T_SPLIT_CHARGE;
        private DInteger D_BF_BAL = new DInteger(8);
        private void D_BF_BAL_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0;
                if (QDesign.NULL(fleCURRENT_ENTS.GetStringValue("YEAR_123")) == "01")
                {
                    CurrentValue = fleCURRENT_ENTS.GetDecimalValue("BF_BAL");
                }
                else
                {
                    CurrentValue = flePREVIOUS_ENT.GetDecimalValue("ENTITLEMENT_BAL");
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
        private DCharacter D_FORF_QUALIFIED = new DCharacter(1);
        private void D_FORF_QUALIFIED_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (((28 <= (QDesign.Days(T_START_DATE.Value) - QDesign.Days(QDesign.SysDate(ref m_cnnQUERY))) && 70 >= (QDesign.Days(T_START_DATE.Value) - QDesign.Days(QDesign.SysDate(ref m_cnnQUERY)))) || (70 >= (QDesign.Days(T_START_DATE.Value) - QDesign.Days(QDesign.SysDate(ref m_cnnQUERY))) && QDesign.NULL(fleINVESTMENTS.GetStringValue("QUALIFY_28DAY")) != "Y")) && QDesign.NULL(fleFORF_ACCOUNT.GetDecimalValue("FORF_BAL")) > 0)
                {
                    CurrentValue = "Y";
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
        private DCharacter D_USE_FORF_BAL = new DCharacter(1);
        private void D_USE_FORF_BAL_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(D_FORF_QUALIFIED.Value) == "Y" && QDesign.NULL(T_USE_FORF_BAL.Value) == "Y")
                {
                    CurrentValue = "Y";
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
        private DInteger D_FORF_BAL = new DInteger(8);
        private void D_FORF_BAL_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0;
                if (QDesign.NULL(D_USE_FORF_BAL.Value) == "Y")
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
        private DInteger D_FORF_POINTS = new DInteger(8);
        private void D_FORF_POINTS_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0;
                if (D_FORF_BAL.Value <= D_NET_POINTS.Value)
                {
                    CurrentValue = D_FORF_BAL.Value;
                }
                else if (QDesign.NULL(D_FORF_BAL.Value) > QDesign.NULL(D_NET_POINTS.Value))
                {
                    CurrentValue = D_NET_POINTS.Value;
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
        private DCharacter D_FORF_MESSAGE = new DCharacter(78);
        private void D_FORF_MESSAGE_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(D_FORF_POINTS.Value) > 0)
                {
                    CurrentValue = QDesign.Pack("THIS BOOKING WILL USE " + QDesign.ASCII(D_FORF_POINTS.Value) + " 70-DAY ACCOUNT POINTS");
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
        private DInteger D_AVAILABLE = new DInteger(8);
        private void D_AVAILABLE_GetValue(ref decimal Value)
        {

            try
            {
                Value = fleCURRENT_ENTS.GetDecimalValue("ENTITLEMENT_BAL") + D_BF_BAL.Value;


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DInteger D_SUBTOTAL = new DInteger(8);
        private void D_SUBTOTAL_GetValue(ref decimal Value)
        {

            try
            {
                Value = (D_AVAILABLE.Value - D_NET_POINTS.Value) + D_FORF_BAL.Value;


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DInteger D_SUSP_MAX = new DInteger(8);
        private void D_SUSP_MAX_GetValue(ref decimal Value)
        {

            try
            {
                Value = fleSUSP_ACCOUNT.GetDecimalValue("SUSP_BAL");


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DInteger D_PURC_MAX = new DInteger(8);
        private void D_PURC_MAX_GetValue(ref decimal Value)
        {

            try
            {

                // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

                Value = D_NET_POINTS.Value * (fleUSER_SEC_FILE.GetDecimalValue("PURC_PERCENT") / 100);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DInteger D_TOP_UP_COST1 = new DInteger(8);
        private void D_TOP_UP_COST1_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0;

                // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

                if (QDesign.NULL(fleCURRENT_ENTS.GetStringValue("YEAR_123")) == "01")
                {
                    CurrentValue = fleBOOKINGS.GetDecimalValue("BK_ADDON") * 100;
                }
                else if ((QDesign.NULL(fleCURRENT_ENTS.GetStringValue("YEAR_123")) == "02" || QDesign.NULL(fleCURRENT_ENTS.GetStringValue("YEAR_123")) == "03"))
                {
                    CurrentValue = (fleBOOKINGS.GetDecimalValue("BK_ADDON") / 2) * 100;
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
        private DInteger D_TOP_UP_COST = new DInteger(8);
        private void D_TOP_UP_COST_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0;
                if (QDesign.NULL(D_TOP_UP_COST1.Value) < 25000 && QDesign.NULL(D_TOP_UP_COST1.Value) > 0 && QDesign.NULL(fleBOOKINGS.GetDecimalValue("BK_ADDON")) > 0 && QDesign.NULL(fleM_INVESTORS.GetStringValue("COLOUR")) == "D" || QDesign.NULL(fleM_INVESTORS.GetStringValue("SILVER_GOLD")) == "SD")
                {
                    CurrentValue = 25000;
                }
                else if (QDesign.NULL(D_TOP_UP_COST1.Value) < 100000 && QDesign.NULL(D_TOP_UP_COST1.Value) > 0 && QDesign.NULL(fleBOOKINGS.GetDecimalValue("BK_ADDON")) > 0 && (QDesign.NULL(fleM_INVESTORS.GetStringValue("COLOUR")) == "G" || (QDesign.NULL(fleM_INVESTORS.GetStringValue("COLOUR")) == "S" && QDesign.NULL(fleM_INVESTORS.GetStringValue("SILVER_GOLD")) != "SD")))
                {
                    CurrentValue = 100000;
                }
                else if (QDesign.NULL(D_TOP_UP_COST1.Value) < 0)
                {
                    CurrentValue = 0;
                }
                else
                {
                    CurrentValue = D_TOP_UP_COST1.Value;
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
        private DInteger D_PURCHASE = new DInteger(8);
        private void D_PURCHASE_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0;
                if (QDesign.NULL(fleINVESTMENTS.GetStringValue("QUALIFY_28DAY")) != "Y")
                {
                    CurrentValue = fleBOOKINGS.GetDecimalValue("BK_PURCHASE") * 14;
                }
                else
                {
                    CurrentValue = fleBOOKINGS.GetDecimalValue("BK_PURCHASE") * 7;
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
        private DInteger D_DPC1 = new DInteger(8);
        private void D_DPC1_GetValue(ref decimal Value)
        {

            try
            {

                // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

                Value = D_PURCHASE.Value / 100;


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DInteger D_DPC2 = new DInteger(8);
        private void D_DPC2_GetValue(ref decimal Value)
        {

            try
            {
                Value = D_PURCHASE.Value - (D_DPC1.Value * 100);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DCharacter D_PURCHASE_COST = new DCharacter(10);
        private void D_PURCHASE_COST_GetValue(ref string Value)
        {

            try
            {
                Value = QDesign.Pack(QDesign.ASCII(D_DPC1.Value) + "." + QDesign.ASCII(D_DPC2.Value, 2));


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private CoreDecimal T_USER_CHARGE_TOT;
        private DInteger D_POINTS_BALANCE = new DInteger(8);
        private void D_POINTS_BALANCE_GetValue(ref decimal Value)
        {

            try
            {
                Value = D_AVAILABLE.Value - D_NET_POINTS.Value + fleBOOKINGS.GetDecimalValue("BK_SUSPENSE") + fleBOOKINGS.GetDecimalValue("BK_PURCHASE") + fleBOOKINGS.GetDecimalValue("BK_ADDON") + fleBOOKINGS.GetDecimalValue("BK_OVERDRAFT") + D_FORF_BAL.Value;


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DInteger D_ANN_CURR_ENT = new DInteger(8);
        private void D_ANN_CURR_ENT_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0;
                if (QDesign.NULL(fleCURRENT_ENTS.GetStringValue("YEAR_123")) == "03")
                {
                    CurrentValue = (fleANNUAL_ENT.GetDecimalValue("ANN_CURR_ENT") + fleCURRENT_ENTS.GetDecimalValue("ENT_OVERDRAFT"));
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
        private DInteger D_BOOK_OD = new DInteger(8);
        private void D_BOOK_OD_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0;

                // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

                if ((QDesign.NULL(fleCURRENT_ENTS.GetStringValue("YEAR_123")) == "01" || QDesign.NULL(fleCURRENT_ENTS.GetStringValue("YEAR_123")) == "02"))
                {
                    CurrentValue = (fleUSER_SEC_FILE.GetDecimalValue("OD_PERCENT") / 100) * fleFOLLOWING_ENT.GetDecimalValue("ENTITLEMENT_BAL");
                }
                else if (QDesign.NULL(fleCURRENT_ENTS.GetStringValue("YEAR_123")) == "03")
                {
                    CurrentValue = (fleUSER_SEC_FILE.GetDecimalValue("OD_PERCENT") / 100) * D_ANN_CURR_ENT.Value;
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
        private DInteger D_PLUS_28 = new DInteger(8);
        private void D_PLUS_28_GetValue(ref decimal Value)
        {

            try
            {
                Value = (QDesign.Days(T_END_DATE.Value) + 28);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DCharacter D_WITHIN_28 = new DCharacter(1);
        private void D_WITHIN_28_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(D_PLUS_28.Value) > QDesign.NULL((QDesign.Days(fleCURRENT_ENTS.GetDecimalValue("YEAR_END_DATE")))))
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
        private DInteger D_OD_MAX = new DInteger(8);
        private void D_OD_MAX_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0;
                if (QDesign.NULL(D_WITHIN_28.Value) == "N")
                {
                    CurrentValue = D_BOOK_OD.Value;
                }
                else if ((QDesign.NULL(fleCURRENT_ENTS.GetStringValue("YEAR_123")) == "01" || QDesign.NULL(fleCURRENT_ENTS.GetStringValue("YEAR_123")) == "02"))
                {
                    CurrentValue = fleFOLLOWING_ENT.GetDecimalValue("ENTITLEMENT_BAL");
                }
                else if (QDesign.NULL(fleCURRENT_ENTS.GetStringValue("YEAR_123")) == "03")
                {
                    CurrentValue = D_ANN_CURR_ENT.Value;
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
        private DInteger D_NET_POINTS_ENT = new DInteger(8);
        private void D_NET_POINTS_ENT_GetValue(ref decimal Value)
        {

            try
            {
                Value = D_POINTS.Value - fleBOOKINGS.GetDecimalValue("POINTS_ADJUST") - fleBOOKINGS.GetDecimalValue("BK_PURCHASE") - fleBOOKINGS.GetDecimalValue("BK_SUSPENSE") - fleBOOKINGS.GetDecimalValue("BK_FORF_POINTS");


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DDecimal D_PROP_DATE_1 = new DDecimal();
        private void D_PROP_DATE_1_GetValue(ref decimal Value)
        {

            try
            {
                Value = QDesign.NConvert(fleSCREEN_PROPERTY.GetStringValue("PRPTY_YR_1") + QDesign.Substring(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_DATE_1"), 4, 2) + QDesign.Substring(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_DATE_1"), 1, 2));


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DDecimal D_PROP_DATE_2 = new DDecimal();
        private void D_PROP_DATE_2_GetValue(ref decimal Value)
        {

            try
            {
                Value = QDesign.NConvert(fleSCREEN_PROPERTY.GetStringValue("PRPTY_YR_2") + QDesign.Substring(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_DATE_2"), 4, 2) + QDesign.Substring(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_DATE_2"), 1, 2));


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DDecimal D_PROP_DATE_3 = new DDecimal();
        private void D_PROP_DATE_3_GetValue(ref decimal Value)
        {

            try
            {
                Value = QDesign.NConvert(fleSCREEN_PROPERTY.GetStringValue("PRPTY_YR_3") + QDesign.Substring(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_DATE_3"), 4, 2) + QDesign.Substring(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_DATE_3"), 1, 2));


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DDecimal D_PROP_DATE_4 = new DDecimal();
        private void D_PROP_DATE_4_GetValue(ref decimal Value)
        {

            try
            {
                Value = QDesign.NConvert(fleSCREEN_PROPERTY.GetStringValue("PRPTY_YR_4") + QDesign.Substring(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_DATE_4"), 4, 2) + QDesign.Substring(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_DATE_4"), 1, 2));


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DDecimal D_PROP_DATE_5 = new DDecimal();
        private void D_PROP_DATE_5_GetValue(ref decimal Value)
        {

            try
            {
                Value = QDesign.NConvert(fleSCREEN_PROPERTY.GetStringValue("PRPTY_YR_5") + QDesign.Substring(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_DATE_5"), 4, 2) + QDesign.Substring(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_DATE_5"), 1, 2));


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DDecimal D_PROP_DATE_6 = new DDecimal();
        private void D_PROP_DATE_6_GetValue(ref decimal Value)
        {

            try
            {
                Value = QDesign.NConvert(fleSCREEN_PROPERTY.GetStringValue("PRPTY_YR_6") + QDesign.Substring(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_DATE_6"), 4, 2) + QDesign.Substring(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_DATE_6"), 1, 2));


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DDecimal D_PROP_DATE_7 = new DDecimal();
        private void D_PROP_DATE_7_GetValue(ref decimal Value)
        {

            try
            {
                Value = QDesign.NConvert(fleSCREEN_PROPERTY.GetStringValue("PRPTY_YR_7") + QDesign.Substring(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_DATE_7"), 4, 2) + QDesign.Substring(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_DATE_7"), 1, 2));


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DDecimal D_PROP_DATE_8 = new DDecimal();
        private void D_PROP_DATE_8_GetValue(ref decimal Value)
        {

            try
            {
                Value = QDesign.NConvert(fleSCREEN_PROPERTY.GetStringValue("PRPTY_YR_8") + QDesign.Substring(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_DATE_8"), 4, 2) + QDesign.Substring(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_DATE_8"), 1, 2));


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DDecimal D_PROP_DATE_9 = new DDecimal();
        private void D_PROP_DATE_9_GetValue(ref decimal Value)
        {

            try
            {
                Value = QDesign.NConvert(fleSCREEN_PROPERTY.GetStringValue("PRPTY_YR_9") + QDesign.Substring(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_DATE_9"), 4, 2) + QDesign.Substring(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_DATE_9"), 1, 2));


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DDecimal D_PROP_DATE_10 = new DDecimal();
        private void D_PROP_DATE_10_GetValue(ref decimal Value)
        {

            try
            {
                Value = QDesign.NConvert(fleSCREEN_PROPERTY.GetStringValue("PRPTY_YR_10") + QDesign.Substring(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_DATE_10"), 4, 2) + QDesign.Substring(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_DATE_10"), 1, 2));


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DDecimal D_PROP_DATE_1X = new DDecimal();
        private void D_PROP_DATE_1X_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0m;
                if (QDesign.NULL(D_PROP_DATE_1.Value) != 0)
                {
                    CurrentValue = D_PROP_DATE_1.Value;
                }
                else
                {
                    CurrentValue = 30010101;
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
        private DDecimal D_PROP_DATE_2X = new DDecimal();
        private void D_PROP_DATE_2X_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0m;
                if (QDesign.NULL(D_PROP_DATE_2.Value) != 0)
                {
                    CurrentValue = D_PROP_DATE_2.Value;
                }
                else
                {
                    CurrentValue = 30010101;
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
        private DDecimal D_PROP_DATE_3X = new DDecimal();
        private void D_PROP_DATE_3X_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0m;
                if (QDesign.NULL(D_PROP_DATE_3.Value) != 0)
                {
                    CurrentValue = D_PROP_DATE_3.Value;
                }
                else
                {
                    CurrentValue = 30010101;
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
        private DDecimal D_PROP_DATE_4X = new DDecimal();
        private void D_PROP_DATE_4X_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0m;
                if (QDesign.NULL(D_PROP_DATE_4.Value) != 0)
                {
                    CurrentValue = D_PROP_DATE_4.Value;
                }
                else
                {
                    CurrentValue = 30010101;
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
        private DDecimal D_PROP_DATE_5X = new DDecimal();
        private void D_PROP_DATE_5X_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0m;
                if (QDesign.NULL(D_PROP_DATE_5.Value) != 0)
                {
                    CurrentValue = D_PROP_DATE_5.Value;
                }
                else
                {
                    CurrentValue = 30010101;
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
        private DDecimal D_PROP_DATE_6X = new DDecimal();
        private void D_PROP_DATE_6X_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0m;
                if (QDesign.NULL(D_PROP_DATE_6.Value) != 0)
                {
                    CurrentValue = D_PROP_DATE_6.Value;
                }
                else
                {
                    CurrentValue = 30010101;
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
        private DDecimal D_PROP_DATE_7X = new DDecimal();
        private void D_PROP_DATE_7X_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0m;
                if (QDesign.NULL(D_PROP_DATE_7.Value) != 0)
                {
                    CurrentValue = D_PROP_DATE_7.Value;
                }
                else
                {
                    CurrentValue = 30010101;
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
        private DDecimal D_PROP_DATE_8X = new DDecimal();
        private void D_PROP_DATE_8X_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0m;
                if (QDesign.NULL(D_PROP_DATE_8.Value) != 0)
                {
                    CurrentValue = D_PROP_DATE_8.Value;
                }
                else
                {
                    CurrentValue = 30010101;
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
        private DDecimal D_PROP_DATE_9X = new DDecimal();
        private void D_PROP_DATE_9X_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0m;
                if (QDesign.NULL(D_PROP_DATE_9.Value) != 0)
                {
                    CurrentValue = D_PROP_DATE_9.Value;
                }
                else
                {
                    CurrentValue = 30010101;
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
        private DDecimal D_PROP_DATE_10X = new DDecimal();
        private void D_PROP_DATE_10X_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0m;
                if (QDesign.NULL(D_PROP_DATE_10.Value) != 0)
                {
                    CurrentValue = D_PROP_DATE_10.Value;
                }
                else
                {
                    CurrentValue = 30010101;
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
        private CoreCharacter T_ERROR_FLAG;
        private CoreCharacter T_UPDATE_LINKED;
        private CoreCharacter T_CALLING_SCREEN;
        private CoreCharacter T_WEEK_STATUS;
        private CoreInteger T_COUNT;
        private CoreDate T_PROPERTY_DATE;
        private CoreCharacter T_WEB_BOOKING;
        private CoreCharacter T_LT_INVESTOR;
        private DCharacter D_STATUS_1 = new DCharacter(1);
        private void D_STATUS_1_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(QDesign.Substring(T_WEEK_STATUS.Value, 1, 1)) == "Q")
                {
                    CurrentValue = ".";
                }
                else
                {
                    CurrentValue = QDesign.Substring(T_WEEK_STATUS.Value, 1, 1);
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
        private DCharacter D_STATUS_2 = new DCharacter(1);
        private void D_STATUS_2_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(QDesign.Substring(T_WEEK_STATUS.Value, 2, 1)) == "Q")
                {
                    CurrentValue = ".";
                }
                else
                {
                    CurrentValue = QDesign.Substring(T_WEEK_STATUS.Value, 2, 1);
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
        private DCharacter D_STATUS_3 = new DCharacter(1);
        private void D_STATUS_3_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(QDesign.Substring(T_WEEK_STATUS.Value, 3, 1)) == "Q")
                {
                    CurrentValue = ".";
                }
                else
                {
                    CurrentValue = QDesign.Substring(T_WEEK_STATUS.Value, 3, 1);
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
        private DCharacter D_STATUS_4 = new DCharacter(1);
        private void D_STATUS_4_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(QDesign.Substring(T_WEEK_STATUS.Value, 4, 1)) == "Q")
                {
                    CurrentValue = ".";
                }
                else
                {
                    CurrentValue = QDesign.Substring(T_WEEK_STATUS.Value, 4, 1);
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
        private DCharacter D_STATUS_5 = new DCharacter(1);
        private void D_STATUS_5_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(QDesign.Substring(T_WEEK_STATUS.Value, 5, 1)) == "Q")
                {
                    CurrentValue = ".";
                }
                else
                {
                    CurrentValue = QDesign.Substring(T_WEEK_STATUS.Value, 5, 1);
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
        private DCharacter D_STATUS_6 = new DCharacter(1);
        private void D_STATUS_6_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(QDesign.Substring(T_WEEK_STATUS.Value, 6, 1)) == "Q")
                {
                    CurrentValue = ".";
                }
                else
                {
                    CurrentValue = QDesign.Substring(T_WEEK_STATUS.Value, 6, 1);
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
        private DCharacter D_STATUS_7 = new DCharacter(1);
        private void D_STATUS_7_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(QDesign.Substring(T_WEEK_STATUS.Value, 7, 1)) == "Q")
                {
                    CurrentValue = ".";
                }
                else
                {
                    CurrentValue = QDesign.Substring(T_WEEK_STATUS.Value, 7, 1);
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
        private DDecimal D_WEEK_END_DATE = new DDecimal();
        private void D_WEEK_END_DATE_GetValue(ref decimal Value)
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
        private DDecimal D_DAY_1 = new DDecimal();
        private void D_DAY_1_GetValue(ref decimal Value)
        {

            try
            {
                Value = fleBOOKING_PERIODS_DTL.GetDecimalValue("START_DATE");


            }
            catch (CustomApplicationException ex)
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
        private DDecimal D_PRP_1 = new DDecimal();
        private void D_PRP_1_GetValue(ref decimal Value)
        {

            try
            {
                Value = T_PROPERTY_DATE.Value;


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DDecimal D_PRP_2 = new DDecimal();
        private void D_PRP_2_GetValue(ref decimal Value)
        {

            try
            {
                Value = QDesign.PhDate(QDesign.Days(T_PROPERTY_DATE.Value) + 1);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DDecimal D_PRP_3 = new DDecimal();
        private void D_PRP_3_GetValue(ref decimal Value)
        {

            try
            {
                Value = QDesign.PhDate(QDesign.Days(T_PROPERTY_DATE.Value) + 2);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DDecimal D_PRP_4 = new DDecimal();
        private void D_PRP_4_GetValue(ref decimal Value)
        {

            try
            {
                Value = QDesign.PhDate(QDesign.Days(T_PROPERTY_DATE.Value) + 3);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DDecimal D_PRP_5 = new DDecimal();
        private void D_PRP_5_GetValue(ref decimal Value)
        {

            try
            {
                Value = QDesign.PhDate(QDesign.Days(T_PROPERTY_DATE.Value) + 4);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DDecimal D_PRP_6 = new DDecimal();
        private void D_PRP_6_GetValue(ref decimal Value)
        {

            try
            {
                Value = QDesign.PhDate(QDesign.Days(T_PROPERTY_DATE.Value) + 5);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DDecimal D_PRP_7 = new DDecimal();
        private void D_PRP_7_GetValue(ref decimal Value)
        {

            try
            {
                Value = QDesign.PhDate(QDesign.Days(T_PROPERTY_DATE.Value) + 6);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DInteger D_PART_POINTS = new DInteger(9);
        private void D_PART_POINTS_GetValue(ref decimal Value)
        {

            try
            {

                // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

                Value = (QDesign.Round((fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE") / 7) * T_COUNT.Value, 0, RoundOptionTypes.Near));
                // TODO: POINTS_CHARGE occurs 53.  Manual steps may be required.' TODO: POINTS_CHARGE occurs 53.  Manual steps may be required.


            }
            catch (CustomApplicationException ex)
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
                if (T_START_DATE.Value <= fleBOOKING_PERIODS_DTL.GetDecimalValue("START_DATE") && T_END_DATE.Value >= fleBOOKING_PERIODS_DTL.GetDecimalValue("START_DATE"))
                {
                    CurrentValue = "R";
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
                if (T_START_DATE.Value <= D_DAY_2.Value && T_END_DATE.Value >= D_DAY_2.Value)
                {
                    CurrentValue = "R";
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
                if (T_START_DATE.Value <= D_DAY_3.Value && T_END_DATE.Value >= D_DAY_3.Value)
                {
                    CurrentValue = "R";
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
                if (T_START_DATE.Value <= D_DAY_4.Value && T_END_DATE.Value >= D_DAY_4.Value)
                {
                    CurrentValue = "R";
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
                if (T_START_DATE.Value <= D_DAY_5.Value && T_END_DATE.Value >= D_DAY_5.Value)
                {
                    CurrentValue = "R";
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
                if (T_START_DATE.Value <= D_DAY_6.Value && T_END_DATE.Value >= D_DAY_6.Value)
                {
                    CurrentValue = "R";
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
                if (T_START_DATE.Value <= D_DAY_7.Value && T_END_DATE.Value >= D_DAY_7.Value)
                {
                    CurrentValue = "R";
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
        private DInteger D_LAST_PERIOD = new DInteger(2);
        private void D_LAST_PERIOD_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0;
                if (QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_10")) != 0)
                {
                    CurrentValue = fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_10");
                }
                else if (QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_9")) != 0)
                {
                    CurrentValue = fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_9");
                }
                else if (QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_8")) != 0)
                {
                    CurrentValue = fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_8");
                }
                else if (QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_7")) != 0)
                {
                    CurrentValue = fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_7");
                }
                else if (QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_6")) != 0)
                {
                    CurrentValue = fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_6");
                }
                else if (QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_5")) != 0)
                {
                    CurrentValue = fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_5");
                }
                else if (QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_4")) != 0)
                {
                    CurrentValue = fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_4");
                }
                else if (QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_3")) != 0)
                {
                    CurrentValue = fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_3");
                }
                else if (QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_2")) != 0)
                {
                    CurrentValue = fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_2");
                }
                else
                {
                    CurrentValue = fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_1");
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
        private DDecimal D_SCREEN_END = new DDecimal();
        private void D_SCREEN_END_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0m;
                if (QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_10")) != 0)
                {
                    CurrentValue = QDesign.PhDate((QDesign.Days(QDesign.NConvert(fleSCREEN_PROPERTY.GetStringValue("PRPTY_YR_10") + QDesign.Substring(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_DATE_10"), 4, 2) + QDesign.Substring(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_DATE_10"), 1, 2)))) + 6);
                }
                else if (QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_9")) != 0)
                {
                    CurrentValue = QDesign.PhDate((QDesign.Days(QDesign.NConvert(fleSCREEN_PROPERTY.GetStringValue("PRPTY_YR_9") + QDesign.Substring(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_DATE_9"), 4, 2) + QDesign.Substring(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_DATE_9"), 1, 2)))) + 6);
                }
                else if (QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_8")) != 0)
                {
                    CurrentValue = QDesign.PhDate((QDesign.Days(QDesign.NConvert(fleSCREEN_PROPERTY.GetStringValue("PRPTY_YR_8") + QDesign.Substring(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_DATE_8"), 4, 2) + QDesign.Substring(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_DATE_8"), 1, 2)))) + 6);
                }
                else if (QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_7")) != 0)
                {
                    CurrentValue = QDesign.PhDate((QDesign.Days(QDesign.NConvert(fleSCREEN_PROPERTY.GetStringValue("PRPTY_YR_7") + QDesign.Substring(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_DATE_7"), 4, 2) + QDesign.Substring(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_DATE_7"), 1, 2)))) + 6);
                }
                else if (QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_6")) != 0)
                {
                    CurrentValue = QDesign.PhDate((QDesign.Days(QDesign.NConvert(fleSCREEN_PROPERTY.GetStringValue("PRPTY_YR_6") + QDesign.Substring(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_DATE_6"), 4, 2) + QDesign.Substring(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_DATE_6"), 1, 2)))) + 6);
                }
                else if (QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_5")) != 0)
                {
                    CurrentValue = QDesign.PhDate((QDesign.Days(QDesign.NConvert(fleSCREEN_PROPERTY.GetStringValue("PRPTY_YR_5") + QDesign.Substring(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_DATE_5"), 4, 2) + QDesign.Substring(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_DATE_5"), 1, 2)))) + 6);
                }
                else if (QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_4")) != 0)
                {
                    CurrentValue = QDesign.PhDate((QDesign.Days(QDesign.NConvert(fleSCREEN_PROPERTY.GetStringValue("PRPTY_YR_4") + QDesign.Substring(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_DATE_4"), 4, 2) + QDesign.Substring(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_DATE_4"), 1, 2)))) + 6);
                }
                else if (QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_3")) != 0)
                {
                    CurrentValue = QDesign.PhDate((QDesign.Days(QDesign.NConvert(fleSCREEN_PROPERTY.GetStringValue("PRPTY_YR_3") + QDesign.Substring(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_DATE_3"), 4, 2) + QDesign.Substring(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_DATE_3"), 1, 2)))) + 6);
                }
                else if (QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_2")) != 0)
                {
                    CurrentValue = QDesign.PhDate((QDesign.Days(QDesign.NConvert(fleSCREEN_PROPERTY.GetStringValue("PRPTY_YR_2") + QDesign.Substring(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_DATE_2"), 4, 2) + QDesign.Substring(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_DATE_2"), 1, 2)))) + 6);
                }
                else
                {
                    CurrentValue = QDesign.PhDate((QDesign.Days(QDesign.NConvert(fleSCREEN_PROPERTY.GetStringValue("PRPTY_YR_1") + QDesign.Substring(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_DATE_1"), 4, 2) + QDesign.Substring(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_DATE_1"), 1, 2)))) + 6);
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
        private DDecimal D_SCREEN_START = new DDecimal();
        private void D_SCREEN_START_GetValue(ref decimal Value)
        {

            try
            {
                Value = QDesign.PhDate((QDesign.Days(QDesign.NConvert(fleSCREEN_PROPERTY.GetStringValue("PRPTY_YR_1") + QDesign.Substring(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_DATE_1"), 4, 2) + QDesign.Substring(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_DATE_1"), 1, 2)))) + 0);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DCharacter D_UNDER_A_WEEK = new DCharacter(1);
        private void D_UNDER_A_WEEK_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (6 >= (1 + (QDesign.Days(T_END_DATE.Value) - QDesign.Days(T_START_DATE.Value))))
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
        private DInteger D_BOOKDATE_28 = new DInteger(8);
        private void D_BOOKDATE_28_GetValue(ref decimal Value)
        {

            try
            {
                Value = (QDesign.Days(QDesign.SysDate(ref m_cnnQUERY)) + 28);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DInteger D_BOOKDATE_21 = new DInteger(8);
        private void D_BOOKDATE_21_GetValue(ref decimal Value)
        {

            try
            {
                Value = (QDesign.Days(QDesign.SysDate(ref m_cnnQUERY)) + 21);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DInteger D_BOOKDATE_42 = new DInteger(8);
        private void D_BOOKDATE_42_GetValue(ref decimal Value)
        {

            try
            {
                Value = (QDesign.Days(QDesign.SysDate(ref m_cnnQUERY)) + 42);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DInteger D_BOOKDATE_56 = new DInteger(8);
        private void D_BOOKDATE_56_GetValue(ref decimal Value)
        {

            try
            {
                Value = (QDesign.Days(QDesign.SysDate(ref m_cnnQUERY)) + 56);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DInteger D_BOOKDATE_14 = new DInteger(8);
        private void D_BOOKDATE_14_GetValue(ref decimal Value)
        {

            try
            {
                Value = (QDesign.Days(QDesign.SysDate(ref m_cnnQUERY)) + 14);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DInteger D_START_DATE = new DInteger(8);
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
        private DCharacter D_UK = new DCharacter(1);
        private void D_UK_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(fleLOCATIONS.GetStringValue("AREA")) == "UKL" || QDesign.NULL(fleLOCATIONS.GetStringValue("AREA")) == "CTY")
                {
                    CurrentValue = "Y";
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
        private DCharacter D_POINTS_FREE = new DCharacter(1);
        private void D_POINTS_FREE_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if ((((D_BOOKDATE_21.Value >= D_START_DATE.Value) || (D_BOOKDATE_28.Value >= D_START_DATE.Value && QDesign.NULL(fleINVESTMENTS.GetStringValue("QUALIFY_28DAY")) == "Y" && QDesign.NULL(D_UK.Value) == "Y") || (D_BOOKDATE_56.Value >= D_START_DATE.Value && QDesign.NULL(fleINVESTMENTS.GetStringValue("QUALIFY_28DAY")) == "Y" && QDesign.NULL(D_UK.Value) != "Y") || (D_BOOKDATE_42.Value >= D_START_DATE.Value && QDesign.NULL(fleINVESTMENTS.GetStringValue("QUALIFY_28DAY")) != "Y" && QDesign.NULL(D_UK.Value) != "Y")) && QDesign.SysDate(ref m_cnnQUERY) >= 20060115))
                {
                    CurrentValue = "Y";
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
        private DCharacter D_WITHIN_21_DAYS = new DCharacter(1);
        private void D_WITHIN_21_DAYS_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if ((D_BOOKDATE_21.Value >= D_START_DATE.Value) && QDesign.NULL(flePROPERTIES.GetStringValue("GROUPING")) == "BOND" && D_NIGHTS.Value >= 7)
                {
                    CurrentValue = "Y";
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
        private CoreCharacter T_SILVER_POINTS_FREE;
        private DCharacter D_PAY_USER_CHARGE = new DCharacter(1);
        private void D_PAY_USER_CHARGE_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(fleM_INVESTORS.GetStringValue("COLOUR")) != "S" || (QDesign.NULL(fleM_INVESTORS.GetStringValue("COLOUR")) == "S" && QDesign.NULL(D_FORF_QUALIFIED.Value) == "Y" && QDesign.NULL(T_USE_FORF_BAL.Value) == "Y") || QDesign.NULL(QDesign.Substring(flePROPERTIES.GetStringValue("GROUPING"), 1, 3)) == "TEN" || QDesign.NULL(QDesign.Substring(flePROPERTIES.GetStringValue("GROUPING"), 1, 3)) == "SHH" || QDesign.NULL(D_POINTS_FREE.Value) == "Y" || QDesign.NULL(T_SILVER_POINTS_FREE.Value) == "Y")
                {
                    CurrentValue = "Y";
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
        private DCharacter D_SET_USER_CHARGE = new DCharacter(1);
        private void D_SET_USER_CHARGE_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(fleM_INVESTORS.GetStringValue("COLOUR")) != "S" || (QDesign.NULL(fleM_INVESTORS.GetStringValue("COLOUR")) == "S" && QDesign.NULL(D_FORF_QUALIFIED.Value) == "Y" && QDesign.NULL(T_USE_FORF_BAL.Value) == "Y") || QDesign.NULL(QDesign.Substring(flePROPERTIES.GetStringValue("GROUPING"), 1, 3)) == "TEN" || QDesign.NULL(QDesign.Substring(flePROPERTIES.GetStringValue("GROUPING"), 1, 3)) == "SHH" || QDesign.NULL(D_POINTS_FREE.Value) == "Y" || (QDesign.NULL(fleM_INVESTORS.GetStringValue("COLOUR")) == "S" && QDesign.NULL(fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE")) == 0))
                {
                    CurrentValue = "Y";
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
        private DInteger D_USER_CHARGES = new DInteger(12);
        private void D_USER_CHARGES_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0;
                if (QDesign.NULL(fleCHARGES_DTL.GetStringValue("USER_CHARGE")) == "A")
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("USER_CHARGE_A");
                }
                else if (QDesign.NULL(fleCHARGES_DTL.GetStringValue("USER_CHARGE")) == "B")
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("USER_CHARGE_B");
                }
                else if (QDesign.NULL(fleCHARGES_DTL.GetStringValue("USER_CHARGE")) == "C")
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("USER_CHARGE_C");
                }
                else if (QDesign.NULL(fleCHARGES_DTL.GetStringValue("USER_CHARGE")) == "D")
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("USER_CHARGE_D");
                }
                else if (QDesign.NULL(fleCHARGES_DTL.GetStringValue("USER_CHARGE")) == "E")
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("USER_CHARGE_E");
                }
                else if (QDesign.NULL(fleCHARGES_DTL.GetStringValue("USER_CHARGE")) == "F")
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("USER_CHARGE_F");
                }
                else if (QDesign.NULL(fleCHARGES_DTL.GetStringValue("USER_CHARGE")) == "G")
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("USER_CHARGE_G");
                }
                else if (QDesign.NULL(fleCHARGES_DTL.GetStringValue("USER_CHARGE")) == "H")
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("USER_CHARGE_H");
                }
                else if (QDesign.NULL(fleCHARGES_DTL.GetStringValue("USER_CHARGE")) == "I")
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("USER_CHARGE_I");
                }
                else if (QDesign.NULL(fleCHARGES_DTL.GetStringValue("USER_CHARGE")) == "J")
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("USER_CHARGE_J");
                }
                else if (QDesign.NULL(fleCHARGES_DTL.GetStringValue("USER_CHARGE")) == "K")
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("USER_CHARGE_K");
                }
                else if (QDesign.NULL(fleCHARGES_DTL.GetStringValue("USER_CHARGE")) == "L")
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("USER_CHARGE_L");
                }
                else if (QDesign.NULL(fleCHARGES_DTL.GetStringValue("USER_CHARGE")) == "M")
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("USER_CHARGE_M");
                }
                else if (QDesign.NULL(fleCHARGES_DTL.GetStringValue("USER_CHARGE")) == "N")
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("USER_CHARGE_N");
                }
                else if (QDesign.NULL(fleCHARGES_DTL.GetStringValue("USER_CHARGE")) == "O")
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("USER_CHARGE_O");
                }
                else if (QDesign.NULL(fleCHARGES_DTL.GetStringValue("USER_CHARGE")) == "P")
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("USER_CHARGE_P");
                }
                else if (QDesign.NULL(fleCHARGES_DTL.GetStringValue("USER_CHARGE")) == "Q")
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("USER_CHARGE_Q");
                }
                else if (QDesign.NULL(fleCHARGES_DTL.GetStringValue("USER_CHARGE")) == "R")
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("USER_CHARGE_R");
                }
                else if (QDesign.NULL(fleCHARGES_DTL.GetStringValue("USER_CHARGE")) == "S")
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("USER_CHARGE_S");
                }
                else if (QDesign.NULL(fleCHARGES_DTL.GetStringValue("USER_CHARGE")) == "T")
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("USER_CHARGE_T");
                }
                else if (QDesign.NULL(fleCHARGES_DTL.GetStringValue("USER_CHARGE")) == "U")
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("USER_CHARGE_U");
                }
                else if (QDesign.NULL(fleCHARGES_DTL.GetStringValue("USER_CHARGE")) == "V")
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("USER_CHARGE_V");
                }
                else if (QDesign.NULL(fleCHARGES_DTL.GetStringValue("USER_CHARGE")) == "W")
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("USER_CHARGE_W");
                }
                else if (QDesign.NULL(fleCHARGES_DTL.GetStringValue("USER_CHARGE")) == "X")
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("USER_CHARGE_X");
                }
                else if (QDesign.NULL(fleCHARGES_DTL.GetStringValue("USER_CHARGE")) == "Y")
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("USER_CHARGE_Y");
                }
                else if (QDesign.NULL(fleCHARGES_DTL.GetStringValue("USER_CHARGE")) == "Z")
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("USER_CHARGE_Z");
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
        private DInteger D_USER_CHARGE = new DInteger(12);
        private void D_USER_CHARGE_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0;
                if (QDesign.NULL(D_PAY_USER_CHARGE.Value) == "Y")
                {
                    CurrentValue = D_USER_CHARGES.Value;
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
        private DInteger D_SPLIT_CHARGE = new DInteger(12);
        private void D_SPLIT_CHARGE_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0;
                if (QDesign.NULL(fleCHARGES.GetStringValue("USER_CHARGE")) == "A" && QDesign.NULL(fleSPLIT_WEEKS.GetStringValue("START_DAY_1")) == QDesign.NULL(D_START_DOW.Value))
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("SPLIT_CHARGE1_A");
                }
                else if (QDesign.NULL(fleCHARGES.GetStringValue("USER_CHARGE")) == "A" && QDesign.NULL(fleSPLIT_WEEKS.GetStringValue("START_DAY_2")) == QDesign.NULL(D_START_DOW.Value))
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("SPLIT_CHARGE2_A");
                }
                else if (QDesign.NULL(fleCHARGES.GetStringValue("USER_CHARGE")) == "B" && QDesign.NULL(fleSPLIT_WEEKS.GetStringValue("START_DAY_1")) == QDesign.NULL(D_START_DOW.Value))
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("SPLIT_CHARGE1_B");
                }
                else if (QDesign.NULL(fleCHARGES.GetStringValue("USER_CHARGE")) == "B" && QDesign.NULL(fleSPLIT_WEEKS.GetStringValue("START_DAY_2")) == QDesign.NULL(D_START_DOW.Value))
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("SPLIT_CHARGE2_B");
                }
                else if (QDesign.NULL(fleCHARGES.GetStringValue("USER_CHARGE")) == "C" && QDesign.NULL(fleSPLIT_WEEKS.GetStringValue("START_DAY_1")) == QDesign.NULL(D_START_DOW.Value))
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("SPLIT_CHARGE1_C");
                }
                else if (QDesign.NULL(fleCHARGES.GetStringValue("USER_CHARGE")) == "C" && QDesign.NULL(fleSPLIT_WEEKS.GetStringValue("START_DAY_2")) == QDesign.NULL(D_START_DOW.Value))
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("SPLIT_CHARGE2_C");
                }
                else if (QDesign.NULL(fleCHARGES.GetStringValue("USER_CHARGE")) == "D" && QDesign.NULL(fleSPLIT_WEEKS.GetStringValue("START_DAY_1")) == QDesign.NULL(D_START_DOW.Value))
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("SPLIT_CHARGE1_D");
                }
                else if (QDesign.NULL(fleCHARGES.GetStringValue("USER_CHARGE")) == "D" && QDesign.NULL(fleSPLIT_WEEKS.GetStringValue("START_DAY_2")) == QDesign.NULL(D_START_DOW.Value))
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("SPLIT_CHARGE2_D");
                }
                else if (QDesign.NULL(fleCHARGES.GetStringValue("USER_CHARGE")) == "E" && QDesign.NULL(fleSPLIT_WEEKS.GetStringValue("START_DAY_1")) == QDesign.NULL(D_START_DOW.Value))
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("SPLIT_CHARGE1_E");
                }
                else if (QDesign.NULL(fleCHARGES.GetStringValue("USER_CHARGE")) == "E" && QDesign.NULL(fleSPLIT_WEEKS.GetStringValue("START_DAY_2")) == QDesign.NULL(D_START_DOW.Value))
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("SPLIT_CHARGE2_E");
                }
                else if (QDesign.NULL(fleCHARGES.GetStringValue("USER_CHARGE")) == "F" && QDesign.NULL(fleSPLIT_WEEKS.GetStringValue("START_DAY_1")) == QDesign.NULL(D_START_DOW.Value))
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("SPLIT_CHARGE1_F");
                }
                else if (QDesign.NULL(fleCHARGES.GetStringValue("USER_CHARGE")) == "F" && QDesign.NULL(fleSPLIT_WEEKS.GetStringValue("START_DAY_2")) == QDesign.NULL(D_START_DOW.Value))
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("SPLIT_CHARGE2_F");
                }
                else if (QDesign.NULL(fleCHARGES.GetStringValue("USER_CHARGE")) == "G" && QDesign.NULL(fleSPLIT_WEEKS.GetStringValue("START_DAY_1")) == QDesign.NULL(D_START_DOW.Value))
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("SPLIT_CHARGE1_G");
                }
                else if (QDesign.NULL(fleCHARGES.GetStringValue("USER_CHARGE")) == "G" && QDesign.NULL(fleSPLIT_WEEKS.GetStringValue("START_DAY_2")) == QDesign.NULL(D_START_DOW.Value))
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("SPLIT_CHARGE2_G");
                }
                else if (QDesign.NULL(fleCHARGES.GetStringValue("USER_CHARGE")) == "H" && QDesign.NULL(fleSPLIT_WEEKS.GetStringValue("START_DAY_1")) == QDesign.NULL(D_START_DOW.Value))
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("SPLIT_CHARGE1_H");
                }
                else if (QDesign.NULL(fleCHARGES.GetStringValue("USER_CHARGE")) == "H" && QDesign.NULL(fleSPLIT_WEEKS.GetStringValue("START_DAY_2")) == QDesign.NULL(D_START_DOW.Value))
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("SPLIT_CHARGE2_H");
                }
                else if (QDesign.NULL(fleCHARGES.GetStringValue("USER_CHARGE")) == "I" && QDesign.NULL(fleSPLIT_WEEKS.GetStringValue("START_DAY_1")) == QDesign.NULL(D_START_DOW.Value))
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("SPLIT_CHARGE1_I");
                }
                else if (QDesign.NULL(fleCHARGES.GetStringValue("USER_CHARGE")) == "I" && QDesign.NULL(fleSPLIT_WEEKS.GetStringValue("START_DAY_2")) == QDesign.NULL(D_START_DOW.Value))
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("SPLIT_CHARGE2_I");
                }
                else if (QDesign.NULL(fleCHARGES.GetStringValue("USER_CHARGE")) == "J" && QDesign.NULL(fleSPLIT_WEEKS.GetStringValue("START_DAY_1")) == QDesign.NULL(D_START_DOW.Value))
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("SPLIT_CHARGE1_J");
                }
                else if (QDesign.NULL(fleCHARGES.GetStringValue("USER_CHARGE")) == "J" && QDesign.NULL(fleSPLIT_WEEKS.GetStringValue("START_DAY_2")) == QDesign.NULL(D_START_DOW.Value))
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("SPLIT_CHARGE2_J");
                }
                else if (QDesign.NULL(fleCHARGES.GetStringValue("USER_CHARGE")) == "K" && QDesign.NULL(fleSPLIT_WEEKS.GetStringValue("START_DAY_1")) == QDesign.NULL(D_START_DOW.Value))
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("SPLIT_CHARGE1_K");
                }
                else if (QDesign.NULL(fleCHARGES.GetStringValue("USER_CHARGE")) == "K" && QDesign.NULL(fleSPLIT_WEEKS.GetStringValue("START_DAY_2")) == QDesign.NULL(D_START_DOW.Value))
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("SPLIT_CHARGE2_K");
                }
                else if (QDesign.NULL(fleCHARGES.GetStringValue("USER_CHARGE")) == "L" && QDesign.NULL(fleSPLIT_WEEKS.GetStringValue("START_DAY_1")) == QDesign.NULL(D_START_DOW.Value))
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("SPLIT_CHARGE1_L");
                }
                else if (QDesign.NULL(fleCHARGES.GetStringValue("USER_CHARGE")) == "L" && QDesign.NULL(fleSPLIT_WEEKS.GetStringValue("START_DAY_2")) == QDesign.NULL(D_START_DOW.Value))
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("SPLIT_CHARGE2_L");
                }
                else if (QDesign.NULL(fleCHARGES.GetStringValue("USER_CHARGE")) == "M" && QDesign.NULL(fleSPLIT_WEEKS.GetStringValue("START_DAY_1")) == QDesign.NULL(D_START_DOW.Value))
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("SPLIT_CHARGE1_M");
                }
                else if (QDesign.NULL(fleCHARGES.GetStringValue("USER_CHARGE")) == "M" && QDesign.NULL(fleSPLIT_WEEKS.GetStringValue("START_DAY_2")) == QDesign.NULL(D_START_DOW.Value))
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("SPLIT_CHARGE2_M");
                }
                else if (QDesign.NULL(fleCHARGES.GetStringValue("USER_CHARGE")) == "N" && QDesign.NULL(fleSPLIT_WEEKS.GetStringValue("START_DAY_1")) == QDesign.NULL(D_START_DOW.Value))
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("SPLIT_CHARGE1_N");
                }
                else if (QDesign.NULL(fleCHARGES.GetStringValue("USER_CHARGE")) == "N" && QDesign.NULL(fleSPLIT_WEEKS.GetStringValue("START_DAY_2")) == QDesign.NULL(D_START_DOW.Value))
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("SPLIT_CHARGE2_N");
                }
                else if (QDesign.NULL(fleCHARGES.GetStringValue("USER_CHARGE")) == "O" && QDesign.NULL(fleSPLIT_WEEKS.GetStringValue("START_DAY_1")) == QDesign.NULL(D_START_DOW.Value))
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("SPLIT_CHARGE1_O");
                }
                else if (QDesign.NULL(fleCHARGES.GetStringValue("USER_CHARGE")) == "O" && QDesign.NULL(fleSPLIT_WEEKS.GetStringValue("START_DAY_2")) == QDesign.NULL(D_START_DOW.Value))
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("SPLIT_CHARGE2_O");
                }
                else if (QDesign.NULL(fleCHARGES.GetStringValue("USER_CHARGE")) == "P" && QDesign.NULL(fleSPLIT_WEEKS.GetStringValue("START_DAY_1")) == QDesign.NULL(D_START_DOW.Value))
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("SPLIT_CHARGE1_P");
                }
                else if (QDesign.NULL(fleCHARGES.GetStringValue("USER_CHARGE")) == "P" && QDesign.NULL(fleSPLIT_WEEKS.GetStringValue("START_DAY_2")) == QDesign.NULL(D_START_DOW.Value))
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("SPLIT_CHARGE2_P");
                }
                else if (QDesign.NULL(fleCHARGES.GetStringValue("USER_CHARGE")) == "Q" && QDesign.NULL(fleSPLIT_WEEKS.GetStringValue("START_DAY_1")) == QDesign.NULL(D_START_DOW.Value))
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("SPLIT_CHARGE1_Q");
                }
                else if (QDesign.NULL(fleCHARGES.GetStringValue("USER_CHARGE")) == "Q" && QDesign.NULL(fleSPLIT_WEEKS.GetStringValue("START_DAY_2")) == QDesign.NULL(D_START_DOW.Value))
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("SPLIT_CHARGE2_Q");
                }
                else if (QDesign.NULL(fleCHARGES.GetStringValue("USER_CHARGE")) == "R" && QDesign.NULL(fleSPLIT_WEEKS.GetStringValue("START_DAY_1")) == QDesign.NULL(D_START_DOW.Value))
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("SPLIT_CHARGE1_R");
                }
                else if (QDesign.NULL(fleCHARGES.GetStringValue("USER_CHARGE")) == "R" && QDesign.NULL(fleSPLIT_WEEKS.GetStringValue("START_DAY_2")) == QDesign.NULL(D_START_DOW.Value))
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("SPLIT_CHARGE2_R");
                }
                else if (QDesign.NULL(fleCHARGES.GetStringValue("USER_CHARGE")) == "S" && QDesign.NULL(fleSPLIT_WEEKS.GetStringValue("START_DAY_1")) == QDesign.NULL(D_START_DOW.Value))
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("SPLIT_CHARGE1_S");
                }
                else if (QDesign.NULL(fleCHARGES.GetStringValue("USER_CHARGE")) == "S" && QDesign.NULL(fleSPLIT_WEEKS.GetStringValue("START_DAY_2")) == QDesign.NULL(D_START_DOW.Value))
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("SPLIT_CHARGE2_S");
                }
                else if (QDesign.NULL(fleCHARGES.GetStringValue("USER_CHARGE")) == "T" && QDesign.NULL(fleSPLIT_WEEKS.GetStringValue("START_DAY_1")) == QDesign.NULL(D_START_DOW.Value))
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("SPLIT_CHARGE1_T");
                }
                else if (QDesign.NULL(fleCHARGES.GetStringValue("USER_CHARGE")) == "T" && QDesign.NULL(fleSPLIT_WEEKS.GetStringValue("START_DAY_2")) == QDesign.NULL(D_START_DOW.Value))
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("SPLIT_CHARGE2_T");
                }
                else if (QDesign.NULL(fleCHARGES.GetStringValue("USER_CHARGE")) == "U" && QDesign.NULL(fleSPLIT_WEEKS.GetStringValue("START_DAY_1")) == QDesign.NULL(D_START_DOW.Value))
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("SPLIT_CHARGE1_U");
                }
                else if (QDesign.NULL(fleCHARGES.GetStringValue("USER_CHARGE")) == "U" && QDesign.NULL(fleSPLIT_WEEKS.GetStringValue("START_DAY_2")) == QDesign.NULL(D_START_DOW.Value))
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("SPLIT_CHARGE2_U");
                }
                else if (QDesign.NULL(fleCHARGES.GetStringValue("USER_CHARGE")) == "V" && QDesign.NULL(fleSPLIT_WEEKS.GetStringValue("START_DAY_1")) == QDesign.NULL(D_START_DOW.Value))
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("SPLIT_CHARGE1_V");
                }
                else if (QDesign.NULL(fleCHARGES.GetStringValue("USER_CHARGE")) == "V" && QDesign.NULL(fleSPLIT_WEEKS.GetStringValue("START_DAY_2")) == QDesign.NULL(D_START_DOW.Value))
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("SPLIT_CHARGE2_V");
                }
                else if (QDesign.NULL(fleCHARGES.GetStringValue("USER_CHARGE")) == "W" && QDesign.NULL(fleSPLIT_WEEKS.GetStringValue("START_DAY_1")) == QDesign.NULL(D_START_DOW.Value))
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("SPLIT_CHARGE1_W");
                }
                else if (QDesign.NULL(fleCHARGES.GetStringValue("USER_CHARGE")) == "W" && QDesign.NULL(fleSPLIT_WEEKS.GetStringValue("START_DAY_2")) == QDesign.NULL(D_START_DOW.Value))
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("SPLIT_CHARGE2_W");
                }
                else if (QDesign.NULL(fleCHARGES.GetStringValue("USER_CHARGE")) == "X" && QDesign.NULL(fleSPLIT_WEEKS.GetStringValue("START_DAY_1")) == QDesign.NULL(D_START_DOW.Value))
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("SPLIT_CHARGE1_X");
                }
                else if (QDesign.NULL(fleCHARGES.GetStringValue("USER_CHARGE")) == "X" && QDesign.NULL(fleSPLIT_WEEKS.GetStringValue("START_DAY_2")) == QDesign.NULL(D_START_DOW.Value))
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("SPLIT_CHARGE2_X");
                }
                else if (QDesign.NULL(fleCHARGES.GetStringValue("USER_CHARGE")) == "Y" && QDesign.NULL(fleSPLIT_WEEKS.GetStringValue("START_DAY_1")) == QDesign.NULL(D_START_DOW.Value))
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("SPLIT_CHARGE1_Y");
                }
                else if (QDesign.NULL(fleCHARGES.GetStringValue("USER_CHARGE")) == "Y" && QDesign.NULL(fleSPLIT_WEEKS.GetStringValue("START_DAY_2")) == QDesign.NULL(D_START_DOW.Value))
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("SPLIT_CHARGE2_Y");
                }
                else if (QDesign.NULL(fleCHARGES.GetStringValue("USER_CHARGE")) == "Z" && QDesign.NULL(fleSPLIT_WEEKS.GetStringValue("START_DAY_1")) == QDesign.NULL(D_START_DOW.Value))
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("SPLIT_CHARGE1_Z");
                }
                else if (QDesign.NULL(fleCHARGES.GetStringValue("USER_CHARGE")) == "Z" && QDesign.NULL(fleSPLIT_WEEKS.GetStringValue("START_DAY_2")) == QDesign.NULL(D_START_DOW.Value))
                {
                    CurrentValue = fleCHARGES.GetDecimalValue("SPLIT_CHARGE2_Z");
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
        private CoreInteger T_CHARGE;
        private CoreDecimal T_WEEK;
        private CoreInteger T_TOTAL_WEEKLY_RATE;
        private CoreDecimal T_TOTAL_DAYS;
        private DCharacter D_CHARGE_7TH = new DCharacter(1);
        private void D_CHARGE_7TH_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;

                if (QDesign.NULL(flePROPERTIES.GetStringValue("GROUPING")) == "HOTL" || QDesign.NULL(fleSCREEN_PROPERTY.GetStringValue("LOCATION")) == "HK" || QDesign.NULL(fleSCREEN_PROPERTY.GetStringValue("LOCATION")) == "KA" || QDesign.NULL(fleSCREEN_PROPERTY.GetStringValue("LOCATION")) == "IH" || QDesign.NULL(fleSCREEN_PROPERTY.GetStringValue("LOCATION")) == "VI")
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
        private DDecimal D_RATE = new DDecimal(2);
        private void D_RATE_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0m;

                // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

                if (QDesign.NULL(flePROPERTIES.GetStringValue("LOCATION")) == "DL" && QDesign.NULL(T_TOTAL_DAYS.Value) == 4 && (QDesign.NULL(D_START_DOW.Value) == "THU" || QDesign.NULL(D_START_DOW.Value) == "FRI" || QDesign.NULL(D_START_DOW.Value) == "SAT"))
                {
                    CurrentValue = 75;
                }
                else if (QDesign.NULL(flePROPERTIES.GetStringValue("LOCATION")) == "DL" && QDesign.NULL(T_TOTAL_DAYS.Value) == 3 && (QDesign.NULL(D_START_DOW.Value) == "FRI" || QDesign.NULL(D_START_DOW.Value) == "SAT"))
                {
                    CurrentValue = 70;
                }
                else if (QDesign.NULL(flePROPERTIES.GetStringValue("LOCATION")) == "DL" && QDesign.NULL(T_TOTAL_DAYS.Value) == 4 && QDesign.NULL(D_START_DOW.Value) == "MON")
                {
                    CurrentValue = 65;
                }
                else if (QDesign.NULL(T_TOTAL_DAYS.Value) == 1 && QDesign.NULL(fleSCREEN_PROPERTY.GetStringValue("LOCATION")) == "ER")
                {
                    CurrentValue = (100 / 6);
                }
                else if (QDesign.NULL(T_TOTAL_DAYS.Value) == 2 && QDesign.NULL(fleSCREEN_PROPERTY.GetStringValue("LOCATION")) == "ER")
                {
                    CurrentValue = (200 / 6);
                }
                else if (QDesign.NULL(T_TOTAL_DAYS.Value) == 3 && QDesign.NULL(fleSCREEN_PROPERTY.GetStringValue("LOCATION")) == "ER")
                {
                    CurrentValue = (300 / 6);
                }
                else if (QDesign.NULL(T_TOTAL_DAYS.Value) == 4 && QDesign.NULL(fleSCREEN_PROPERTY.GetStringValue("LOCATION")) == "ER")
                {
                    CurrentValue = (400 / 6);
                }
                else if (QDesign.NULL(T_TOTAL_DAYS.Value) == 5 && QDesign.NULL(fleSCREEN_PROPERTY.GetStringValue("LOCATION")) == "ER")
                {
                    CurrentValue = (500 / 6);
                }
                else if (QDesign.NULL(T_TOTAL_DAYS.Value) == 6 && QDesign.NULL(fleSCREEN_PROPERTY.GetStringValue("LOCATION")) == "ER")
                {
                    CurrentValue = (600 / 6);
                }
                else if (QDesign.NULL(T_TOTAL_DAYS.Value) == 1 && QDesign.NULL(D_CHARGE_7TH.Value) == "N")
                {
                    CurrentValue = 20;
                }
                else if (QDesign.NULL(T_TOTAL_DAYS.Value) == 2 && QDesign.NULL(D_CHARGE_7TH.Value) == "N")
                {
                    CurrentValue = 35;
                }
                else if (QDesign.NULL(T_TOTAL_DAYS.Value) == 3 && QDesign.NULL(D_CHARGE_7TH.Value) == "N")
                {
                    CurrentValue = 50;
                }
                else if (QDesign.NULL(T_TOTAL_DAYS.Value) == 4 && QDesign.NULL(D_CHARGE_7TH.Value) == "N")
                {
                    CurrentValue = 65;
                }
                else if (QDesign.NULL(T_TOTAL_DAYS.Value) == 5 && QDesign.NULL(D_CHARGE_7TH.Value) == "N")
                {
                    CurrentValue = 80;
                }
                else if (QDesign.NULL(T_TOTAL_DAYS.Value) == 6 && QDesign.NULL(D_CHARGE_7TH.Value) == "N")
                {
                    CurrentValue = 90;
                }
                else if (QDesign.NULL(T_TOTAL_DAYS.Value) == 1 && QDesign.NULL(D_CHARGE_7TH.Value) == "Y")
                {
                    CurrentValue = (100 / 7);
                }
                else if (QDesign.NULL(T_TOTAL_DAYS.Value) == 2 && QDesign.NULL(D_CHARGE_7TH.Value) == "Y")
                {
                    CurrentValue = (200 / 7);
                }
                else if (QDesign.NULL(T_TOTAL_DAYS.Value) == 3 && QDesign.NULL(D_CHARGE_7TH.Value) == "Y")
                {
                    CurrentValue = (300 / 7);
                }
                else if (QDesign.NULL(T_TOTAL_DAYS.Value) == 4 && QDesign.NULL(D_CHARGE_7TH.Value) == "Y")
                {
                    CurrentValue = (400 / 7);
                }
                else if (QDesign.NULL(T_TOTAL_DAYS.Value) == 5 && QDesign.NULL(D_CHARGE_7TH.Value) == "Y")
                {
                    CurrentValue = (500 / 7);
                }
                else if (QDesign.NULL(T_TOTAL_DAYS.Value) == 6 && QDesign.NULL(D_CHARGE_7TH.Value) == "Y")
                {
                    CurrentValue = (600 / 7);
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
        private DDecimal D_EXTRADAYS_CHARGE = new DDecimal(8);
        private void D_EXTRADAYS_CHARGE_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0m;

                // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

                if (QDesign.NULL(D_UNDER_A_WEEK.Value) == "N" && QDesign.NULL(D_PAY_USER_CHARGE.Value) == "Y")
                {
                    CurrentValue = ((D_USER_CHARGE.Value * T_COUNT.Value) / 7);
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
        private DInteger D_TERM_SURCHARGEPER = new DInteger(8);
        private void D_TERM_SURCHARGEPER_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0;
                if (QDesign.NULL(D_NET_POINTS.Value) > 0)
                {
                    CurrentValue = fleINVESTMENTS.GetDecimalValue("TERM_SURCHARGEPER");
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
        private DInteger D_2_YEARS = new DInteger(6);
        private void D_2_YEARS_GetValue(ref decimal Value)
        {

            try
            {
                Value = QDesign.PhDate(QDesign.Days(QDesign.SysDate(ref m_cnnQUERY)) + 730);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private CoreDecimal T_START_DAYS;
        private CoreDecimal T_END_DAYS;
        private CoreDecimal T_BOOK_DAYS;
        private DCharacter D_IN_RANGE = new DCharacter(1);
        private void D_IN_RANGE_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(T_END_DATE.Value) < QDesign.NULL(fleBOOKING_PERIODS_DTL.GetDecimalValue("START_DATE")))
                {
                    CurrentValue = "N";
                }
                else if (QDesign.NULL(T_START_DATE.Value) > QDesign.NULL(fleBOOKING_PERIODS_DTL.GetDecimalValue("END_DATE")))
                {
                    CurrentValue = "N";
                }
                else
                {
                    CurrentValue = "Y";
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
        private DCharacter D_DAY_1_OK = new DCharacter(1);
        private void D_DAY_1_OK_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(flePROPERTY_YEARS_DTL.GetStringValue("DAY_1")) == QDesign.NULL(" ") || (QDesign.NULL(flePROPERTY_YEARS_DTL.GetStringValue("DAY_1")) == "T" && QDesign.NULL(UserID) == "theme"))
                {
                    CurrentValue = "Y";
                }
                else if (QDesign.NULL(flePROPERTY_YEARS_DTL.GetStringValue("DAY_1")) != QDesign.NULL(" ") && (QDesign.NULL(T_START_DAYS.Value) > QDesign.NULL((T_BOOK_DAYS.Value + 0)) || QDesign.NULL(T_END_DAYS.Value) < QDesign.NULL((T_BOOK_DAYS.Value + 0))))
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
        private DCharacter D_DAY_2_OK = new DCharacter(1);
        private void D_DAY_2_OK_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(flePROPERTY_YEARS_DTL.GetStringValue("DAY_2")) == QDesign.NULL(" ") || (QDesign.NULL(flePROPERTY_YEARS_DTL.GetStringValue("DAY_2")) == "T" && QDesign.NULL(UserID) == "theme"))
                {
                    CurrentValue = "Y";
                }
                else if (QDesign.NULL(flePROPERTY_YEARS_DTL.GetStringValue("DAY_2")) != QDesign.NULL(" ") && (QDesign.NULL(T_START_DAYS.Value) > QDesign.NULL((T_BOOK_DAYS.Value + 1)) || QDesign.NULL(T_END_DAYS.Value) < QDesign.NULL((T_BOOK_DAYS.Value + 1))))
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
        private DCharacter D_DAY_3_OK = new DCharacter(1);
        private void D_DAY_3_OK_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(flePROPERTY_YEARS_DTL.GetStringValue("DAY_3")) == QDesign.NULL(" ") || (QDesign.NULL(flePROPERTY_YEARS_DTL.GetStringValue("DAY_3")) == "T" && QDesign.NULL(UserID) == "theme"))
                {
                    CurrentValue = "Y";
                }
                else if (QDesign.NULL(flePROPERTY_YEARS_DTL.GetStringValue("DAY_3")) != QDesign.NULL(" ") && (QDesign.NULL(T_START_DAYS.Value) > QDesign.NULL((T_BOOK_DAYS.Value + 2)) || QDesign.NULL(T_END_DAYS.Value) < QDesign.NULL((T_BOOK_DAYS.Value + 2))))
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
        private DCharacter D_DAY_4_OK = new DCharacter(1);
        private void D_DAY_4_OK_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(flePROPERTY_YEARS_DTL.GetStringValue("DAY_4")) == QDesign.NULL(" ") || (QDesign.NULL(flePROPERTY_YEARS_DTL.GetStringValue("DAY_4")) == "T" && QDesign.NULL(UserID) == "theme"))
                {
                    CurrentValue = "Y";
                }
                else if (QDesign.NULL(flePROPERTY_YEARS_DTL.GetStringValue("DAY_4")) != QDesign.NULL(" ") && (QDesign.NULL(T_START_DAYS.Value) > QDesign.NULL((T_BOOK_DAYS.Value + 3)) || QDesign.NULL(T_END_DAYS.Value) < QDesign.NULL((T_BOOK_DAYS.Value + 3))))
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
        private DCharacter D_DAY_5_OK = new DCharacter(1);
        private void D_DAY_5_OK_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(flePROPERTY_YEARS_DTL.GetStringValue("DAY_5")) == QDesign.NULL(" ") || (QDesign.NULL(flePROPERTY_YEARS_DTL.GetStringValue("DAY_5")) == "T" && QDesign.NULL(UserID) == "theme"))
                {
                    CurrentValue = "Y";
                }
                else if (QDesign.NULL(flePROPERTY_YEARS_DTL.GetStringValue("DAY_5")) != QDesign.NULL(" ") && (QDesign.NULL(T_START_DAYS.Value) > QDesign.NULL((T_BOOK_DAYS.Value + 4)) || QDesign.NULL(T_END_DAYS.Value) < QDesign.NULL((T_BOOK_DAYS.Value + 4))))
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
        private DCharacter D_DAY_6_OK = new DCharacter(1);
        private void D_DAY_6_OK_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(flePROPERTY_YEARS_DTL.GetStringValue("DAY_6")) == QDesign.NULL(" ") || (QDesign.NULL(flePROPERTY_YEARS_DTL.GetStringValue("DAY_6")) == "T" && QDesign.NULL(UserID) == "theme"))
                {
                    CurrentValue = "Y";
                }
                else if (QDesign.NULL(flePROPERTY_YEARS_DTL.GetStringValue("DAY_6")) != QDesign.NULL(" ") && (QDesign.NULL(T_START_DAYS.Value) > QDesign.NULL((T_BOOK_DAYS.Value + 5)) || QDesign.NULL(T_END_DAYS.Value) < QDesign.NULL((T_BOOK_DAYS.Value + 5))))
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
        private DCharacter D_DAY_7_OK = new DCharacter(1);
        private void D_DAY_7_OK_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(flePROPERTY_YEARS_DTL.GetStringValue("DAY_7")) == QDesign.NULL(" ") || (QDesign.NULL(flePROPERTY_YEARS_DTL.GetStringValue("DAY_7")) == "T" && QDesign.NULL(UserID) == "theme"))
                {
                    CurrentValue = "Y";
                }
                else if (QDesign.NULL(flePROPERTY_YEARS_DTL.GetStringValue("DAY_7")) != QDesign.NULL(" ") && (QDesign.NULL(T_START_DAYS.Value) > QDesign.NULL((T_BOOK_DAYS.Value + 6)) || QDesign.NULL(T_END_DAYS.Value) < QDesign.NULL((T_BOOK_DAYS.Value + 6))))
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
        private DCharacter D_SPLIT_VALID = new DCharacter(1);
        private void D_SPLIT_VALID_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(flePROPERTIES.GetStringValue("SPLIT_WEEKS")) == "Y" && (T_START_DATE.Value >= fleSPLIT_WEEKS.GetDecimalValue("FROM_DATE") && T_START_DATE.Value <= fleSPLIT_WEEKS.GetDecimalValue("TO_DATE")) && QDesign.NULL(D_NIGHTS.Value) < 7 && ((QDesign.NULL(D_START_DOW.Value) == QDesign.NULL(fleSPLIT_WEEKS.GetStringValue("START_DAY_1")) && QDesign.NULL(D_END_DOW.Value) == QDesign.NULL(fleSPLIT_WEEKS.GetStringValue("END_DAY_1"))) || (QDesign.NULL(D_START_DOW.Value) == QDesign.NULL(fleSPLIT_WEEKS.GetStringValue("START_DAY_2")) && QDesign.NULL(D_END_DOW.Value) == QDesign.NULL(fleSPLIT_WEEKS.GetStringValue("END_DAY_2")))))
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
        private DInteger D_SPLIT_CHARGE_PER = new DInteger(8);
        private void D_SPLIT_CHARGE_PER_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0;
                if (QDesign.NULL(D_SPLIT_VALID.Value) == "Y" && QDesign.NULL(D_START_DOW.Value) == QDesign.NULL(fleSPLIT_WEEKS.GetStringValue("START_DAY_1")))
                {
                    CurrentValue = fleSPLIT_WEEKS.GetDecimalValue("SPLIT_CHARGE%_1");
                }
                else if (QDesign.NULL(D_SPLIT_VALID.Value) == "Y" && QDesign.NULL(D_START_DOW.Value) == QDesign.NULL(fleSPLIT_WEEKS.GetStringValue("START_DAY_2")))
                {
                    CurrentValue = fleSPLIT_WEEKS.GetDecimalValue("SPLIT_CHARGE%_2");
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
        private DInteger D_SPLIT_POINTS_PER = new DInteger(8);
        private void D_SPLIT_POINTS_PER_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0;
                if (QDesign.NULL(D_SPLIT_VALID.Value) == "Y" && QDesign.NULL(D_START_DOW.Value) == QDesign.NULL(fleSPLIT_WEEKS.GetStringValue("START_DAY_1")))
                {
                    CurrentValue = fleSPLIT_WEEKS.GetDecimalValue("SPLIT_POINTS%_1");
                }
                else if (QDesign.NULL(D_SPLIT_VALID.Value) == "Y" && QDesign.NULL(D_START_DOW.Value) == QDesign.NULL(fleSPLIT_WEEKS.GetStringValue("START_DAY_2")))
                {
                    CurrentValue = fleSPLIT_WEEKS.GetDecimalValue("SPLIT_POINTS%_2");
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
        private DCharacter D_SILVER_CHARGE = new DCharacter(24);
        private void D_SILVER_CHARGE_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(D_SILVER_SURCHARGE.Value) == QDesign.NULL(2.2))
                {
                    CurrentValue = "(Silver 220% surcharge)";
                }
                else if (QDesign.NULL(D_SILVER_SURCHARGE.Value) == QDesign.NULL(1.5))
                {
                    CurrentValue = "(Silver 50% surcharge)";
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
        private DDecimal D_ON_REQUEST_DATE = new DDecimal();
        private void D_ON_REQUEST_DATE_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0m;
                if (QDesign.NULL(flePROPERTIES.GetDecimalValue("ON_REQUEST_DAYS")) > 0)
                {
                    CurrentValue = QDesign.PhDate(QDesign.Days(QDesign.SysDate(ref m_cnnQUERY)) + flePROPERTIES.GetDecimalValue("ON_REQUEST_DAYS"));
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
        private DCharacter D_ON_REQUEST = new DCharacter(8);
        private void D_ON_REQUEST_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(flePROPERTIES.GetDecimalValue("ON_REQUEST_DAYS")) > 0)
                {
                    CurrentValue = "Request";
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
        private DInteger D_VAT = new DInteger(9);
        private void D_VAT_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0;

                // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

                if (QDesign.NULL(flePROPERTIES.GetStringValue("VAT_FLAG")) == "Y")
                {
                    CurrentValue = QDesign.Round((fleBOOKINGS.GetDecimalValue("BOOKING_CHARGE") - D_NOTIONAL_VAT.Value) / (fleCOLOUR_RATES.GetDecimalValue("COLOUR_RATE") + 1000000) * fleCOLOUR_RATES.GetDecimalValue("COLOUR_RATE"), 0, RoundOptionTypes.Near);
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
        private DInteger D_WEEKS = new DInteger(8);
        private void D_WEEKS_GetValue(ref decimal Value)
        {

            try
            {

                // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

                Value = ((QDesign.Days(T_END_DATE.Value) - QDesign.Days(T_START_DATE.Value)) / 7) + 1;


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DInteger D_POINTS_WEEKS = new DInteger(4);
        private void D_POINTS_WEEKS_GetValue(ref decimal Value)
        {

            try
            {
                int CurrentValue = 0;
                if (QDesign.NULL(T_POINTS_7.Value) != 0)
                {
                    CurrentValue = 7;
                }
                else if (QDesign.NULL(T_POINTS_6.Value) != 0)
                {
                    CurrentValue = 6;
                }
                else if (QDesign.NULL(T_POINTS_5.Value) != 0)
                {
                    CurrentValue = 5;
                }
                else if (QDesign.NULL(T_POINTS_4.Value) != 0)
                {
                    CurrentValue = 4;
                }
                else if (QDesign.NULL(T_POINTS_3.Value) != 0)
                {
                    CurrentValue = 3;
                }
                else if (QDesign.NULL(T_POINTS_2.Value) != 0)
                {
                    CurrentValue = 2;
                }
                else if (QDesign.NULL(T_POINTS_1.Value) != 0)
                {
                    CurrentValue = 1;
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
        private DInteger D_PFIA_WEEKS = new DInteger(4);
        private void D_PFIA_WEEKS_GetValue(ref decimal Value)
        {

            try
            {
                Value = D_WEEKS.Value - D_POINTS_WEEKS.Value;


            }
            catch (CustomApplicationException ex)
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
                if (QDesign.NULL(flePROPERTIES.GetDecimalValue("DEPOSIT")) < QDesign.NULL((fleBOOKINGS.GetDecimalValue("BOOKING_CHARGE"))))
                {
                    CurrentValue = flePROPERTIES.GetDecimalValue("DEPOSIT");
                }
                else
                {
                    CurrentValue = (fleBOOKINGS.GetDecimalValue("BOOKING_CHARGE"));
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
        private DInteger D_OFFER_DEPOSIT = new DInteger(8);
        private void D_OFFER_DEPOSIT_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0;
                if (QDesign.NULL(T_PFIA_DEPOSIT.Value) == "Y" && QDesign.NULL(T_BOGOF_DEPOSIT.Value) == "Y")
                {
                    CurrentValue = (3000 * D_PFIA_WEEKS.Value) + (3000 * (D_WEEKS.Value - D_PFIA_WEEKS.Value));
                }
                else if (QDesign.NULL(T_PFIA_DEPOSIT.Value) == "Y" && QDesign.NULL(T_BOGOF_DEPOSIT.Value) == "1")
                {
                    CurrentValue = (3000 * D_PFIA_WEEKS.Value) + 3000;
                }
                else if (QDesign.NULL(T_PFIA_DEPOSIT.Value) == "Y")
                {
                    CurrentValue = (3000 * D_PFIA_WEEKS.Value);
                }
                else if (QDesign.NULL(T_BOGOF_DEPOSIT.Value) == "Y")
                {
                    CurrentValue = (3000 * D_WEEKS.Value);
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
        private DInteger D_DUE_NOW = new DInteger(8);
        private void D_DUE_NOW_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0;

                // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

                if ((QDesign.NULL(T_PFIA_DEPOSIT.Value) == "Y" || QDesign.NULL(T_BOGOF_DEPOSIT.Value) == "Y"))
                {
                    CurrentValue = D_OFFER_DEPOSIT.Value;
                }
                else if (QDesign.NULL(T_BOGOF_DEPOSIT.Value) == "1")
                {
                    CurrentValue = 3000;
                }
                else if (QDesign.NULL(D_DEPOSIT.Value) == "N" && QDesign.NULL(flePROPERTIES.GetStringValue("DEPOSIT_REQUIRED")) == "Y")
                {
                    CurrentValue = fleBOOKINGS.GetDecimalValue("BOOKING_CHARGE");
                }
                else if (QDesign.NULL(flePROPERTIES.GetStringValue("DEPOSIT_REQUIRED")) == "Y" && QDesign.NULL(flePROPERTIES.GetDecimalValue("DEPOSIT")) > 0)
                {
                    CurrentValue = D_DEPOSIT_AMT.Value * D_WEEKS.Value;
                }
                else if (QDesign.NULL(flePROPERTIES.GetStringValue("DEPOSIT_REQUIRED")) == "Y" && QDesign.NULL(flePROPERTIES.GetDecimalValue("DEPOSITPER")) > 0)
                {
                    CurrentValue = fleBOOKINGS.GetDecimalValue("BOOKING_CHARGE") * (flePROPERTIES.GetDecimalValue("DEPOSITPER") / 1000);
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
        private DInteger D_VAT_NOW = new DInteger(9);
        private void D_VAT_NOW_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0;

                // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

                if (QDesign.NULL(flePROPERTIES.GetStringValue("VAT_FLAG")) == "Y")
                {
                    CurrentValue = D_DUE_NOW.Value - QDesign.Round(D_DUE_NOW.Value / (decimal)1.2, 0, RoundOptionTypes.Near);
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
        private DInteger D_VAT_BALANCE = new DInteger(8);
        private void D_VAT_BALANCE_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0;
                if (QDesign.NULL(D_DEPOSIT.Value) == "Y" && QDesign.NULL(flePROPERTIES.GetStringValue("VAT_FLAG")) == "Y")
                {
                    CurrentValue = (fleBOOKINGS.GetDecimalValue("VAT") - D_VAT_NOW.Value);
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
        private DInteger D_SHHL_BALANCE = new DInteger(8);
        private void D_SHHL_BALANCE_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0;
                if (QDesign.NULL(D_DEPOSIT.Value) == "Y")
                {
                    CurrentValue = fleBOOKINGS.GetDecimalValue("BOOKING_CHARGE") - D_DUE_NOW.Value;
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
        private DCharacter D_DEPOSITPER = new DCharacter(5);
        private void D_DEPOSITPER_GetValue(ref string Value)
        {

            try
            {
                Value = QDesign.Substring(QDesign.ASCII(flePROPERTIES.GetDecimalValue("DEPOSITPER"), 3), 1, 2) + "." + QDesign.Substring(QDesign.ASCII(flePROPERTIES.GetDecimalValue("DEPOSITPER"), 3), 3, 1) + "%";


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DCharacter D_DUE_NOW_TEXT = new DCharacter(40);
        private void D_DUE_NOW_TEXT_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(fleM_INVESTORS.GetStringValue("CUSTOMER_TYPE")) == "I")
                {
                    CurrentValue = "Payment is deferred for this customer";
                }
                else if (QDesign.NULL(D_DEPOSIT.Value) == "N")
                {
                    CurrentValue = "Full payment Due Now";
                }
                else if ((QDesign.NULL(flePROPERTIES.GetStringValue("DEPOSIT_REQUIRED")) == "Y" && QDesign.NULL(flePROPERTIES.GetDecimalValue("DEPOSIT")) > 0 && QDesign.NULL(fleBOOKINGS.GetDecimalValue("BOOKING_CHARGE")) > 0))
                {
                    CurrentValue = "Fixed Deposit Due Now";
                }
                else if ((QDesign.NULL(flePROPERTIES.GetStringValue("DEPOSIT_REQUIRED")) == "Y" && QDesign.NULL(flePROPERTIES.GetDecimalValue("DEPOSITPER")) > 0 && QDesign.NULL(fleBOOKINGS.GetDecimalValue("BOOKING_CHARGE")) > 0))
                {
                    CurrentValue = D_DEPOSITPER.Value + " Deposit Due Now";
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
        private DCharacter D_BOOKING_NO = new DCharacter(8);
        private void D_BOOKING_NO_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (fleLOCATIONS.GetDecimalValue("BOOKING_NO") <= 99999)
                {
                    CurrentValue = QDesign.ASCII(fleLOCATIONS.GetDecimalValue("BOOKING_NO"), 5);
                }
                else
                {
                    CurrentValue = QDesign.ASCII(fleLOCATIONS.GetDecimalValue("BOOKING_NO"), 6);
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
        private DCharacter D_PROP_CODE = new DCharacter(4);
        private void D_PROP_CODE_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(QDesign.Substring(flePROPERTY_YEARS.GetStringValue("LOCATION") + flePROPERTY_YEARS.GetStringValue("BEDS") + flePROPERTY_YEARS.GetStringValue("PROPERTY_STYLE") + flePROPERTY_YEARS.GetStringValue("BATHROOMS") + flePROPERTY_YEARS.GetStringValue("PROPERTY_ID"), 4, 1)) != "S")
                {
                    CurrentValue = QDesign.Substring(flePROPERTY_YEARS.GetStringValue("LOCATION") + flePROPERTY_YEARS.GetStringValue("BEDS") + flePROPERTY_YEARS.GetStringValue("PROPERTY_STYLE") + flePROPERTY_YEARS.GetStringValue("BATHROOMS") + flePROPERTY_YEARS.GetStringValue("PROPERTY_ID"), 1, 3) + " ";
                    //Parent:PROPERTY_CODE
                }
                else
                {
                    CurrentValue = QDesign.Substring(flePROPERTY_YEARS.GetStringValue("LOCATION") + flePROPERTY_YEARS.GetStringValue("BEDS") + flePROPERTY_YEARS.GetStringValue("PROPERTY_STYLE") + flePROPERTY_YEARS.GetStringValue("BATHROOMS") + flePROPERTY_YEARS.GetStringValue("PROPERTY_ID"), 1, 4);
                    //Parent:PROPERTY_CODE
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
        private CoreCharacter T_PROP_CODE;
        private CoreCharacter T_WEB_YEAR;
        private CoreCharacter T_WEB_START_WEEK;
        private CoreCharacter T_WEB_END_WEEK;
        private CoreCharacter T_OLD_START_WEEK;
        private CoreCharacter T_OLD_END_WEEK;
        private CoreCharacter T_WEB_LOCATION;
        private CoreCharacter T_WEB_PROP_ID;
        private CoreCharacter T_WEB_START_DATE;
        private CoreCharacter T_WEB_END_DATE;
        private CoreCharacter T_WEB_UPDATED;
        private CoreCharacter T_BOOKING_NOW;
        private CoreCharacter T_WEB_BOOKED;
        private CoreCharacter T_PICTURE_IN;

        private CoreCharacter T_PICTURE_OUT;
        #endregion

        #region "Standard Generated Procedures"

        #region "Grid Field Declarations"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 07/12/2013 1:49:49 PM

        //# No code was generated or needed for this region.

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 07/12/2013 1:49:49 PM

        //# No code was generated or needed for this region.

        #endregion

        #region "Transaction Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 07/12/2013 1:49:50 PM

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
            fleM_INVESTORS.Transaction = m_trnTRANS_UPDATE;
            fleUSER_SEC_FILE.Transaction = m_trnTRANS_UPDATE;
            flePROPERTY_YEARS.Transaction = m_trnTRANS_UPDATE;
            flePROPERTY_YEARS_DTL.Transaction = m_trnTRANS_UPDATE;
            fleSCREEN_PROPERTY.Transaction = m_trnTRANS_UPDATE;
            flePROPERTIES.Transaction = m_trnTRANS_UPDATE;
            flePROP_COMMENTS.Transaction = m_trnTRANS_UPDATE;
            fleBOOK0100_COMM.Transaction = m_trnTRANS_UPDATE;
            fleBOOKINGS.Transaction = m_trnTRANS_UPDATE;
            fleCURRENT_ENTS.Transaction = m_trnTRANS_UPDATE;
            flePREVIOUS_ENT.Transaction = m_trnTRANS_UPDATE;
            fleFOLLOWING_ENT.Transaction = m_trnTRANS_UPDATE;
            fleSUSP_ACCOUNT.Transaction = m_trnTRANS_UPDATE;
            fleFORF_ACCOUNT.Transaction = m_trnTRANS_UPDATE;
            fleANNUAL_ENT.Transaction = m_trnTRANS_UPDATE;
            fleINVESTMENTS.Transaction = m_trnTRANS_UPDATE;
            fleCOLOUR_RATES.Transaction = m_trnTRANS_UPDATE;
            flePURCHASE_DEBTS.Transaction = m_trnTRANS_UPDATE;
            fleUCHARGE_DEBTS.Transaction = m_trnTRANS_UPDATE;
            fleBALANCE_DEBTS.Transaction = m_trnTRANS_UPDATE;
            fleBOOKING_PERIODS.Transaction = m_trnTRANS_UPDATE;
            fleBOOKING_PERIODS_DTL.Transaction = m_trnTRANS_UPDATE;
            fleLOCATIONS.Transaction = m_trnTRANS_UPDATE;
            fleLOCATION_CURR.Transaction = m_trnTRANS_UPDATE;
            fleCURRENCY_CODE.Transaction = m_trnTRANS_UPDATE;
            fleCURRENCY_RATE.Transaction = m_trnTRANS_UPDATE;


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 07/12/2013 1:49:50 PM

        //#-----------------------------------------
        //# InitializeFiles Procedure.
        //#-----------------------------------------

        protected override void InitializeFiles()
        {

            try
            {
                Initialize_TRANS_UPDATE();
                fleCHARGES.Connection = m_cnnQUERY;
                fleCHARGES_DTL.Connection = m_cnnQUERY;
                fleSPLIT_WEEKS.Connection = m_cnnQUERY;
                flePROP_BK_COMMENTS.Connection = m_cnnQUERY;
                fleLOCN_BK_COMMENTS.Connection = m_cnnQUERY;


            }
            catch (CustomApplicationException ex)
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
                fleM_INVESTORS.Dispose();
                fleUSER_SEC_FILE.Dispose();
                flePROPERTY_YEARS.Dispose();
                flePROPERTY_YEARS_DTL.Dispose();
                fleSCREEN_PROPERTY.Dispose();
                flePROPERTIES.Dispose();
                flePROP_COMMENTS.Dispose();
                fleBOOK0100_COMM.Dispose();
                fleBOOKINGS.Dispose();
                fleCURRENT_ENTS.Dispose();
                flePREVIOUS_ENT.Dispose();
                fleFOLLOWING_ENT.Dispose();
                fleSUSP_ACCOUNT.Dispose();
                fleFORF_ACCOUNT.Dispose();
                fleANNUAL_ENT.Dispose();
                fleINVESTMENTS.Dispose();
                fleCOLOUR_RATES.Dispose();
                fleCHARGES.Dispose();
                fleCHARGES_DTL.Dispose();
                flePURCHASE_DEBTS.Dispose();
                fleUCHARGE_DEBTS.Dispose();
                fleBALANCE_DEBTS.Dispose();
                fleSPLIT_WEEKS.Dispose();
                fleBOOKING_PERIODS.Dispose();
                fleBOOKING_PERIODS_DTL.Dispose();
                fleLOCATIONS.Dispose();
                fleLOCATION_CURR.Dispose();
                fleCURRENCY_CODE.Dispose();
                fleCURRENCY_RATE.Dispose();
                flePROP_BK_COMMENTS.Dispose();
                fleLOCN_BK_COMMENTS.Dispose();


            }
            catch (CustomApplicationException ex)
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
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 06/19/2013 8:54:20 AM
        //#-----------------------------------------
        protected override void DisplayFormatting()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:49:48 PM
                Display(ref fldM_INVESTORS_COLOUR);
                Display(ref fldD_ON_REQUEST);
                Display(ref fldD_ON_REQUEST_DATE);
                Display(ref fldD_PROP_COMM);
                Display(ref fldLOCN_BK_COMMENTS_BK_COMMENT_1);
                Display(ref fldM_INVESTORS_INVESTOR);
                Display(ref fldM_INVESTORS_INVESTOR_NAME);
                Display(ref fldSCREEN_PROPERTY_PROPERTY_CODE);
                Display(ref fldM_INVESTORS_HOLIDAY_ANNIV);
                Display(ref fldBOOKINGS_BOOKING_REF);
                Display(ref fldT_USE_FORF_BAL);
                Display(ref fldD_DUE_NOW_MESSAGE);
                Display(ref fldT_START_WEEK);
                Display(ref fldT_END_WEEK);
                Display(ref fldT_START_DATE);
                Display(ref fldT_END_DATE);
                Display(ref fldBOOKINGS_CONFIRM_DATE);
                Display(ref fldBOOKINGS_BOOKING_CHARGE);
                Display(ref fldD_FULL_CHARGE);
                Display(ref fldD_PP_FLAG);
                Display(ref fldSCREEN_PROPERTY_PROPERTY_DATE_1);
                Display(ref fldSCREEN_PROPERTY_PROPERTY_DATE_2);
                Display(ref fldSCREEN_PROPERTY_PROPERTY_DATE_3);
                Display(ref fldSCREEN_PROPERTY_PROPERTY_DATE_4);
                Display(ref fldSCREEN_PROPERTY_PROPERTY_DATE_5);
                Display(ref fldSCREEN_PROPERTY_PROPERTY_DATE_6);
                Display(ref fldSCREEN_PROPERTY_PROPERTY_DATE_7);
                Display(ref fldSCREEN_PROPERTY_PROPERTY_DATE_8);
                Display(ref fldSCREEN_PROPERTY_PROPERTY_DATE_9);
                Display(ref fldSCREEN_PROPERTY_PROPERTY_DATE_10);
                Display(ref fldSCREEN_PROPERTY_PERIOD_1);
                Display(ref fldSCREEN_PROPERTY_PERIOD_2);
                Display(ref fldSCREEN_PROPERTY_PERIOD_3);
                Display(ref fldSCREEN_PROPERTY_PERIOD_4);
                Display(ref fldSCREEN_PROPERTY_PERIOD_5);
                Display(ref fldSCREEN_PROPERTY_PERIOD_6);
                Display(ref fldSCREEN_PROPERTY_PERIOD_7);
                Display(ref fldSCREEN_PROPERTY_PERIOD_8);
                Display(ref fldSCREEN_PROPERTY_PERIOD_9);
                Display(ref fldSCREEN_PROPERTY_PERIOD_10);
                Display(ref fldSCREEN_PROPERTY_WEEK_STATUS_1);
                Display(ref fldSCREEN_PROPERTY_WEEK_STATUS_2);
                Display(ref fldSCREEN_PROPERTY_WEEK_STATUS_3);
                Display(ref fldSCREEN_PROPERTY_WEEK_STATUS_4);
                Display(ref fldSCREEN_PROPERTY_WEEK_STATUS_5);
                Display(ref fldSCREEN_PROPERTY_WEEK_STATUS_6);
                Display(ref fldSCREEN_PROPERTY_WEEK_STATUS_7);
                Display(ref fldSCREEN_PROPERTY_WEEK_STATUS_8);
                Display(ref fldSCREEN_PROPERTY_WEEK_STATUS_9);
                Display(ref fldSCREEN_PROPERTY_WEEK_STATUS_10);
                Display(ref fldD_FORF_BAL);
                Display(ref fldT_POINTS_1);
                Display(ref fldD_AVAILABLE);
                Display(ref fldT_POINTS_2);
                Display(ref fldD_NET_POINTS);
                Display(ref fldT_POINTS_3);
                Display(ref fldBOOKINGS_POINTS_ADJUST);
                Display(ref fldT_POINTS_4);
                Display(ref fldD_SUBTOTAL);
                Display(ref fldT_POINTS_5);
                Display(ref fldBOOKINGS_BK_SUSPENSE);
                Display(ref fldD_SUSP_MAX);
                Display(ref fldT_POINTS_6);
                Display(ref fldBOOKINGS_BK_PURCHASE);
                Display(ref fldD_PURC_MAX);
                Display(ref fldT_POINTS_7);
                Display(ref fldBOOKINGS_BK_ADDON);
                Display(ref fldD_TOP_UP_COST);
                Display(ref fldFORF_ACCOUNT_FORF_BAL);
                Display(ref fldBOOKINGS_BK_OVERDRAFT);
                Display(ref fldD_OD_MAX);
                Display(ref fldD_SILVER_CHARGE);
                Display(ref fldD_POINTS_BALANCE);
                Display(ref fldD_DUE_NOW);
                Display(ref fldBOOKINGS_LONG_STAY);
                Display(ref fldT_FIXED_DEBT);
                Display(ref fldD_PP_SURCHARGE);
                Display(ref fldT_TERM_SURCHARGE);
                Display(ref fldINVESTMENTS_QUALIFY_28DAY);
                Display(ref fldT_ALLOW);
                Display(ref fldT_CONTINUE);
                Display(ref fldT_BOGOF_DEPOSIT);
                Display(ref fldT_PFIA_DEPOSIT);
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
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 06/19/2013 8:54:20 AM
        //#-----------------------------------------
        protected override void PreDisplayFormatting()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:49:49 PM
                Display(ref fldM_INVESTORS_COLOUR);
                Display(ref fldM_INVESTORS_INVESTOR);
                Display(ref fldM_INVESTORS_INVESTOR_NAME);
                Display(ref fldSCREEN_PROPERTY_PROPERTY_CODE);
                Display(ref fldM_INVESTORS_HOLIDAY_ANNIV);
                Display(ref fldBOOKINGS_BOOKING_REF);
                Display(ref fldT_START_WEEK);
                Display(ref fldT_END_WEEK);
                Display(ref fldT_START_DATE);
                Display(ref fldT_END_DATE);
                Display(ref fldBOOKINGS_CONFIRM_DATE);
                Display(ref fldSCREEN_PROPERTY_PROPERTY_DATE_1);
                Display(ref fldSCREEN_PROPERTY_PROPERTY_DATE_2);
                Display(ref fldSCREEN_PROPERTY_PROPERTY_DATE_3);
                Display(ref fldSCREEN_PROPERTY_PROPERTY_DATE_4);
                Display(ref fldSCREEN_PROPERTY_PROPERTY_DATE_5);
                Display(ref fldSCREEN_PROPERTY_PROPERTY_DATE_6);
                Display(ref fldSCREEN_PROPERTY_PROPERTY_DATE_7);
                Display(ref fldSCREEN_PROPERTY_PROPERTY_DATE_8);
                Display(ref fldSCREEN_PROPERTY_PROPERTY_DATE_9);
                Display(ref fldSCREEN_PROPERTY_PROPERTY_DATE_10);
                Display(ref fldSCREEN_PROPERTY_PERIOD_1);
                Display(ref fldSCREEN_PROPERTY_PERIOD_2);
                Display(ref fldSCREEN_PROPERTY_PERIOD_3);
                Display(ref fldSCREEN_PROPERTY_PERIOD_4);
                Display(ref fldSCREEN_PROPERTY_PERIOD_5);
                Display(ref fldSCREEN_PROPERTY_PERIOD_6);
                Display(ref fldSCREEN_PROPERTY_PERIOD_7);
                Display(ref fldSCREEN_PROPERTY_PERIOD_8);
                Display(ref fldSCREEN_PROPERTY_PERIOD_9);
                Display(ref fldSCREEN_PROPERTY_PERIOD_10);
                Display(ref fldSCREEN_PROPERTY_WEEK_STATUS_1);
                Display(ref fldSCREEN_PROPERTY_WEEK_STATUS_2);
                Display(ref fldSCREEN_PROPERTY_WEEK_STATUS_3);
                Display(ref fldSCREEN_PROPERTY_WEEK_STATUS_4);
                Display(ref fldSCREEN_PROPERTY_WEEK_STATUS_5);
                Display(ref fldSCREEN_PROPERTY_WEEK_STATUS_6);
                Display(ref fldSCREEN_PROPERTY_WEEK_STATUS_7);
                Display(ref fldSCREEN_PROPERTY_WEEK_STATUS_8);
                Display(ref fldSCREEN_PROPERTY_WEEK_STATUS_9);
                Display(ref fldSCREEN_PROPERTY_WEEK_STATUS_10);
                Display(ref fldD_FORF_BAL);
                Display(ref fldD_AVAILABLE);
                Display(ref fldD_SILVER_CHARGE);
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
        //# Do not delete, modify or move it.  Updated: 07/12/2013 1:49:50 PM

        //#-----------------------------------------
        //# BindFields Procedure.
        //#-----------------------------------------

        public override void BindFields()
        {
            try
            {
                fldM_INVESTORS_COLOUR.Bind(fleM_INVESTORS);
                fldD_ON_REQUEST.Bind(D_ON_REQUEST);
                fldD_ON_REQUEST_DATE.Bind(D_ON_REQUEST_DATE);
                fldD_PROP_COMM.Bind(D_PROP_COMM);
                fldLOCN_BK_COMMENTS_BK_COMMENT_1.Bind(fleLOCN_BK_COMMENTS);
                fldM_INVESTORS_INVESTOR.Bind(fleM_INVESTORS);
                fldM_INVESTORS_INVESTOR_NAME.Bind(fleM_INVESTORS);
                fldSCREEN_PROPERTY_PROPERTY_CODE.Bind(SCREEN_PROPERTY_PROPERTY_CODE);
                fldM_INVESTORS_HOLIDAY_ANNIV.Bind(fleM_INVESTORS);
                fldBOOKINGS_BOOKING_REF.Bind(fleBOOKINGS);
                fldT_USE_FORF_BAL.Bind(T_USE_FORF_BAL);
                fldD_DUE_NOW_MESSAGE.Bind(D_DUE_NOW_MESSAGE);
                fldT_START_WEEK.Bind(T_START_WEEK);
                fldT_END_WEEK.Bind(T_END_WEEK);
                fldT_START_DATE.Bind(T_START_DATE);
                fldT_END_DATE.Bind(T_END_DATE);
                fldBOOKINGS_CONFIRM_DATE.Bind(fleBOOKINGS);
                fldBOOKINGS_BOOKING_CHARGE.Bind(fleBOOKINGS);
                fldD_FULL_CHARGE.Bind(D_FULL_CHARGE);
                fldD_PP_FLAG.Bind(D_PP_FLAG);
                fldSCREEN_PROPERTY_PROPERTY_DATE_1.Bind(fleSCREEN_PROPERTY);
                fldSCREEN_PROPERTY_PROPERTY_DATE_2.Bind(fleSCREEN_PROPERTY);
                fldSCREEN_PROPERTY_PROPERTY_DATE_3.Bind(fleSCREEN_PROPERTY);
                fldSCREEN_PROPERTY_PROPERTY_DATE_4.Bind(fleSCREEN_PROPERTY);
                fldSCREEN_PROPERTY_PROPERTY_DATE_5.Bind(fleSCREEN_PROPERTY);
                fldSCREEN_PROPERTY_PROPERTY_DATE_6.Bind(fleSCREEN_PROPERTY);
                fldSCREEN_PROPERTY_PROPERTY_DATE_7.Bind(fleSCREEN_PROPERTY);
                fldSCREEN_PROPERTY_PROPERTY_DATE_8.Bind(fleSCREEN_PROPERTY);
                fldSCREEN_PROPERTY_PROPERTY_DATE_9.Bind(fleSCREEN_PROPERTY);
                fldSCREEN_PROPERTY_PROPERTY_DATE_10.Bind(fleSCREEN_PROPERTY);
                fldSCREEN_PROPERTY_PERIOD_1.Bind(fleSCREEN_PROPERTY);
                fldSCREEN_PROPERTY_PERIOD_2.Bind(fleSCREEN_PROPERTY);
                fldSCREEN_PROPERTY_PERIOD_3.Bind(fleSCREEN_PROPERTY);
                fldSCREEN_PROPERTY_PERIOD_4.Bind(fleSCREEN_PROPERTY);
                fldSCREEN_PROPERTY_PERIOD_5.Bind(fleSCREEN_PROPERTY);
                fldSCREEN_PROPERTY_PERIOD_6.Bind(fleSCREEN_PROPERTY);
                fldSCREEN_PROPERTY_PERIOD_7.Bind(fleSCREEN_PROPERTY);
                fldSCREEN_PROPERTY_PERIOD_8.Bind(fleSCREEN_PROPERTY);
                fldSCREEN_PROPERTY_PERIOD_9.Bind(fleSCREEN_PROPERTY);
                fldSCREEN_PROPERTY_PERIOD_10.Bind(fleSCREEN_PROPERTY);
                fldSCREEN_PROPERTY_WEEK_STATUS_1.Bind(fleSCREEN_PROPERTY);
                fldSCREEN_PROPERTY_WEEK_STATUS_2.Bind(fleSCREEN_PROPERTY);
                fldSCREEN_PROPERTY_WEEK_STATUS_3.Bind(fleSCREEN_PROPERTY);
                fldSCREEN_PROPERTY_WEEK_STATUS_4.Bind(fleSCREEN_PROPERTY);
                fldSCREEN_PROPERTY_WEEK_STATUS_5.Bind(fleSCREEN_PROPERTY);
                fldSCREEN_PROPERTY_WEEK_STATUS_6.Bind(fleSCREEN_PROPERTY);
                fldSCREEN_PROPERTY_WEEK_STATUS_7.Bind(fleSCREEN_PROPERTY);
                fldSCREEN_PROPERTY_WEEK_STATUS_8.Bind(fleSCREEN_PROPERTY);
                fldSCREEN_PROPERTY_WEEK_STATUS_9.Bind(fleSCREEN_PROPERTY);
                fldSCREEN_PROPERTY_WEEK_STATUS_10.Bind(fleSCREEN_PROPERTY);
                fldD_FORF_BAL.Bind(D_FORF_BAL);
                fldT_POINTS_1.Bind(T_POINTS_1);
                fldD_AVAILABLE.Bind(D_AVAILABLE);
                fldT_POINTS_2.Bind(T_POINTS_2);
                fldD_NET_POINTS.Bind(D_NET_POINTS);
                fldT_POINTS_3.Bind(T_POINTS_3);
                fldBOOKINGS_POINTS_ADJUST.Bind(fleBOOKINGS);
                fldT_POINTS_4.Bind(T_POINTS_4);
                fldD_SUBTOTAL.Bind(D_SUBTOTAL);
                fldT_POINTS_5.Bind(T_POINTS_5);
                fldBOOKINGS_BK_SUSPENSE.Bind(fleBOOKINGS);
                fldD_SUSP_MAX.Bind(D_SUSP_MAX);
                fldT_POINTS_6.Bind(T_POINTS_6);
                fldBOOKINGS_BK_PURCHASE.Bind(fleBOOKINGS);
                fldD_PURC_MAX.Bind(D_PURC_MAX);
                fldT_POINTS_7.Bind(T_POINTS_7);
                fldBOOKINGS_BK_ADDON.Bind(fleBOOKINGS);
                fldD_TOP_UP_COST.Bind(D_TOP_UP_COST);
                fldFORF_ACCOUNT_FORF_BAL.Bind(fleFORF_ACCOUNT);
                fldBOOKINGS_BK_OVERDRAFT.Bind(fleBOOKINGS);
                fldD_OD_MAX.Bind(D_OD_MAX);
                fldD_SILVER_CHARGE.Bind(D_SILVER_CHARGE);
                fldD_POINTS_BALANCE.Bind(D_POINTS_BALANCE);
                fldD_DUE_NOW.Bind(D_DUE_NOW);
                fldBOOKINGS_LONG_STAY.Bind(fleBOOKINGS);
                fldT_FIXED_DEBT.Bind(T_FIXED_DEBT);
                fldD_PP_SURCHARGE.Bind(D_PP_SURCHARGE);
                fldT_TERM_SURCHARGE.Bind(T_TERM_SURCHARGE);
                fldINVESTMENTS_QUALIFY_28DAY.Bind(fleINVESTMENTS);
                fldT_ALLOW.Bind(T_ALLOW);
                fldT_CONTINUE.Bind(T_CONTINUE);
                fldT_BOGOF_DEPOSIT.Bind(T_BOGOF_DEPOSIT);
                fldT_PFIA_DEPOSIT.Bind(T_PFIA_DEPOSIT);

            }
            catch (CustomApplicationException ex)
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
                    case "T_USE_FORF_BAL":
                        return "Y";
                    case "T_ALLOW":
                        return "N";
                    case "T_CONTINUE":
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
                SaveReceivingParams(fleM_INVESTORS, fleUSER_SEC_FILE, flePROPERTY_YEARS, fleSCREEN_PROPERTY, flePROPERTIES, flePROP_COMMENTS, fleBOOK0100_COMM, M_START_PERIOD, M_END_PERIOD, M_START_DATE,
                M_END_DATE, M_BOOKED, X_BOOKING_REF, T_BALANCE);


            }
            catch (CustomApplicationException ex)
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
                Receiving(fleM_INVESTORS, fleUSER_SEC_FILE, flePROPERTY_YEARS, fleSCREEN_PROPERTY, flePROPERTIES, flePROP_COMMENTS, fleBOOK0100_COMM, M_START_PERIOD, M_END_PERIOD, M_START_DATE,
                M_END_DATE, M_BOOKED, X_BOOKING_REF, T_BALANCE);

               

            }
            catch (CustomApplicationException ex)
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


        private void fldT_START_DATE_Input()
        {

            try
            {

                if (6 == FieldText.Length)
                {
                    if (string.Compare(QDesign.NULL(QDesign.Substring(FieldText, 5, 2)), "69") < 0)
                    {
                        FieldText = QDesign.Substring(FieldText, 1, 4) + "20" + QDesign.Substring(FieldText, 5, 2);
                    }
                    else
                    {
                        FieldText = QDesign.Substring(FieldText, 1, 4) + "19" + QDesign.Substring(FieldText, 5, 2);
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



        private void fldBOOKINGS_BK_SUSPENSE_Process()
        {

            try
            {

                if (QDesign.NULL(D_POINTS_BALANCE.Value) > 0)
                {
                    fleBOOKINGS.set_SetValue("BK_SUSPENSE", 0);
                    ErrorMessage("52014");
                }
                if (QDesign.NULL(FieldValue) > QDesign.NULL(D_SUSP_MAX.Value))
                {
                    fleBOOKINGS.set_SetValue("BK_SUSPENSE", 0);
                    ErrorMessage("52015");
                }
                Display(ref fldD_POINTS_BALANCE);
                Display(ref fldD_SUBTOTAL);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldBOOKINGS_BK_PURCHASE_Process()
        {

            try
            {

                if (QDesign.NULL(D_POINTS_BALANCE.Value) > 0)
                {
                    fleBOOKINGS.set_SetValue("BK_PURCHASE", 0);
                    ErrorMessage("52016");
                }
                if (QDesign.NULL(fleBOOKINGS.GetDecimalValue("BK_PURCHASE")) > QDesign.NULL(D_PURC_MAX.Value))
                {
                    fleBOOKINGS.set_SetValue("BK_PURCHASE", 0);
                    ErrorMessage("52017");
                }
                Display(ref fldD_POINTS_BALANCE);
                Display(ref fldD_SUBTOTAL);
                Information("PURCHASE POINTS COST : � " + D_PURCHASE_COST.Value);
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



        private void fldBOOKINGS_BK_OVERDRAFT_Process()
        {

            try
            {

                if (QDesign.NULL(D_POINTS_BALANCE.Value) > 0)
                {
                    fleBOOKINGS.set_SetValue("BK_OVERDRAFT", 0);
                    ErrorMessage("52018");
                }
                if (QDesign.NULL(fleBOOKINGS.GetDecimalValue("BK_OVERDRAFT")) > QDesign.NULL(D_OD_MAX.Value))
                {
                    fleBOOKINGS.set_SetValue("BK_OVERDRAFT", 0);
                    ErrorMessage("52019");
                }
                Display(ref fldD_POINTS_BALANCE);
                Display(ref fldD_SUBTOTAL);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldBOOKINGS_BK_ADDON_Input()
        {

            try
            {

                if (QDesign.NULL(fleM_INVESTORS.GetStringValue("COLOUR")) != "D" && QDesign.NULL(fleM_INVESTORS.GetStringValue("SILVER_GOLD")) != "SD")
                {
                    Information("** WARNING - AS OF 30/APR/2007 ONLY DIAMOND BONDS CAN TOP-UP **");
                    // TODO: May need to fix manually
                    Information("A separate linked Diamond policy can be started - minimum �1000");
                    // TODO: May need to fix manually
                    Information("Only enter top-up points if Bondholder definately " + "will convert/top-up to Diamond");
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



        private void fldBOOKINGS_BK_ADDON_Edit()
        {

            try
            {

                if (QDesign.NULL(fleCURRENT_ENTS.GetStringValue("YEAR_123")) == "01" && QDesign.NULL(fleBOOKINGS.GetDecimalValue("BK_ADDON")) < 250 || (QDesign.NULL(fleCURRENT_ENTS.GetStringValue("YEAR_123")) == "02" || QDesign.NULL(fleCURRENT_ENTS.GetStringValue("YEAR_123")) == "03") && QDesign.NULL(fleBOOKINGS.GetDecimalValue("BK_ADDON")) < 500 && QDesign.NULL(fleM_INVESTORS.GetStringValue("COLOUR")) == "D")
                {
                    Information("42001");
                }
                if (QDesign.NULL(fleCURRENT_ENTS.GetStringValue("YEAR_123")) == "01" && QDesign.NULL(fleBOOKINGS.GetDecimalValue("BK_ADDON")) < 1000 || (QDesign.NULL(fleCURRENT_ENTS.GetStringValue("YEAR_123")) == "02" || QDesign.NULL(fleCURRENT_ENTS.GetStringValue("YEAR_123")) == "03") && QDesign.NULL(fleBOOKINGS.GetDecimalValue("BK_ADDON")) < 2000 && QDesign.NULL(fleM_INVESTORS.GetStringValue("COLOUR")) == "G")
                {
                    Information("42002");
                }
                if (QDesign.NULL(D_POINTS_BALANCE.Value) > 0)
                {
                    fleBOOKINGS.set_SetValue("BK_ADDON", 0);
                    Information("42003");
                }
                Display(ref fldD_POINTS_BALANCE);
                Display(ref fldD_SUBTOTAL);
                Display(ref fldD_TOP_UP_COST);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }


        private bool Internal_CHECK_WEB_BOOKING()
        {


            try
            {

                if (QDesign.NULL(QDesign.Substring(T_WEEK_STATUS.Value, 1, 1)) == "Q" || QDesign.NULL(QDesign.Substring(T_WEEK_STATUS.Value, 2, 1)) == "Q" || QDesign.NULL(QDesign.Substring(T_WEEK_STATUS.Value, 3, 1)) == "Q" || QDesign.NULL(QDesign.Substring(T_WEEK_STATUS.Value, 4, 1)) == "Q" || QDesign.NULL(QDesign.Substring(T_WEEK_STATUS.Value, 5, 1)) == "Q" || QDesign.NULL(QDesign.Substring(T_WEEK_STATUS.Value, 6, 1)) == "Q" || QDesign.NULL(QDesign.Substring(T_WEEK_STATUS.Value, 7, 1)) == "Q")
                {
                    T_WEB_BOOKING.Value = "Y";
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


        private bool Internal_GET_WEB_WEEKNOS()
        {


            try
            {

                if (T_START_DATE.Value >= D_PROP_DATE_1X.Value && QDesign.NULL(T_START_DATE.Value) < QDesign.NULL(D_PROP_DATE_2X.Value))
                {
                    T_WEB_START_WEEK.Value = QDesign.ASCII(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_1"), 2);
                }
                else
                {
                    if (T_START_DATE.Value >= D_PROP_DATE_2X.Value && QDesign.NULL(T_START_DATE.Value) < QDesign.NULL(D_PROP_DATE_3X.Value))
                    {
                        T_WEB_START_WEEK.Value = QDesign.ASCII(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_2"), 2);
                    }
                    else
                    {
                        if (T_START_DATE.Value >= D_PROP_DATE_3X.Value && QDesign.NULL(T_START_DATE.Value) < QDesign.NULL(D_PROP_DATE_4X.Value))
                        {
                            T_WEB_START_WEEK.Value = QDesign.ASCII(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_3"), 2);
                        }
                        else
                        {
                            if (T_START_DATE.Value >= D_PROP_DATE_4X.Value && QDesign.NULL(T_START_DATE.Value) < QDesign.NULL(D_PROP_DATE_5X.Value))
                            {
                                T_WEB_START_WEEK.Value = QDesign.ASCII(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_4"), 2);
                            }
                            else
                            {
                                if (T_START_DATE.Value >= D_PROP_DATE_5X.Value && QDesign.NULL(T_START_DATE.Value) < QDesign.NULL(D_PROP_DATE_6X.Value))
                                {
                                    T_WEB_START_WEEK.Value = QDesign.ASCII(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_5"), 2);
                                }
                                else
                                {
                                    if (T_START_DATE.Value >= D_PROP_DATE_6X.Value && QDesign.NULL(T_START_DATE.Value) < QDesign.NULL(D_PROP_DATE_7X.Value))
                                    {
                                        T_WEB_START_WEEK.Value = QDesign.ASCII(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_6"), 2);
                                    }
                                    else
                                    {
                                        if (T_START_DATE.Value >= D_PROP_DATE_7X.Value && QDesign.NULL(T_START_DATE.Value) < QDesign.NULL(D_PROP_DATE_8X.Value))
                                        {
                                            T_WEB_START_WEEK.Value = QDesign.ASCII(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_7"), 2);
                                        }
                                        else
                                        {
                                            if (T_START_DATE.Value >= D_PROP_DATE_8X.Value && QDesign.NULL(T_START_DATE.Value) < QDesign.NULL(D_PROP_DATE_9X.Value))
                                            {
                                                T_WEB_START_WEEK.Value = QDesign.ASCII(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_8"), 2);
                                            }
                                            else
                                            {
                                                if (T_START_DATE.Value >= D_PROP_DATE_9X.Value && QDesign.NULL(T_START_DATE.Value) < QDesign.NULL(D_PROP_DATE_10X.Value))
                                                {
                                                    T_WEB_START_WEEK.Value = QDesign.ASCII(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_9"), 2);
                                                }
                                                else
                                                {
                                                    if (T_START_DATE.Value >= D_PROP_DATE_10X.Value && QDesign.NULL(T_START_DATE.Value) < QDesign.NULL(QDesign.PhDate(QDesign.Days(D_PROP_DATE_10X.Value + 7))))
                                                    {
                                                        T_WEB_START_WEEK.Value = QDesign.ASCII(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_10"), 2);
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
                if (T_END_DATE.Value >= D_PROP_DATE_1X.Value && QDesign.NULL(T_END_DATE.Value) < QDesign.NULL(D_PROP_DATE_2X.Value))
                {
                    T_WEB_END_WEEK.Value = QDesign.ASCII(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_1"), 2);
                }
                else
                {
                    if (T_END_DATE.Value >= D_PROP_DATE_2X.Value && QDesign.NULL(T_END_DATE.Value) < QDesign.NULL(D_PROP_DATE_3X.Value))
                    {
                        T_WEB_END_WEEK.Value = QDesign.ASCII(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_2"), 2);
                    }
                    else
                    {
                        if (T_END_DATE.Value >= D_PROP_DATE_3X.Value && QDesign.NULL(T_END_DATE.Value) < QDesign.NULL(D_PROP_DATE_4X.Value))
                        {
                            T_WEB_END_WEEK.Value = QDesign.ASCII(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_3"), 2);
                        }
                        else
                        {
                            if (T_END_DATE.Value >= D_PROP_DATE_4X.Value && QDesign.NULL(T_END_DATE.Value) < QDesign.NULL(D_PROP_DATE_5X.Value))
                            {
                                T_WEB_END_WEEK.Value = QDesign.ASCII(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_4"), 2);
                            }
                            else
                            {
                                if (T_END_DATE.Value >= D_PROP_DATE_5X.Value && QDesign.NULL(T_END_DATE.Value) < QDesign.NULL(D_PROP_DATE_6X.Value))
                                {
                                    T_WEB_END_WEEK.Value = QDesign.ASCII(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_5"), 2);
                                }
                                else
                                {
                                    if (T_END_DATE.Value >= D_PROP_DATE_6X.Value && QDesign.NULL(T_END_DATE.Value) < QDesign.NULL(D_PROP_DATE_7X.Value))
                                    {
                                        T_WEB_END_WEEK.Value = QDesign.ASCII(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_6"), 2);
                                    }
                                    else
                                    {
                                        if (T_END_DATE.Value >= D_PROP_DATE_7X.Value && QDesign.NULL(T_END_DATE.Value) < QDesign.NULL(D_PROP_DATE_8X.Value))
                                        {
                                            T_WEB_END_WEEK.Value = QDesign.ASCII(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_7"), 2);
                                        }
                                        else
                                        {
                                            if (T_END_DATE.Value >= D_PROP_DATE_8X.Value && QDesign.NULL(T_END_DATE.Value) < QDesign.NULL(D_PROP_DATE_9X.Value))
                                            {
                                                T_WEB_END_WEEK.Value = QDesign.ASCII(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_8"), 2);
                                            }
                                            else
                                            {
                                                if (T_END_DATE.Value >= D_PROP_DATE_9X.Value && QDesign.NULL(T_END_DATE.Value) < QDesign.NULL(D_PROP_DATE_10X.Value))
                                                {
                                                    T_WEB_END_WEEK.Value = QDesign.ASCII(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_9"), 2);
                                                }
                                                else
                                                {
                                                    if (T_END_DATE.Value >= D_PROP_DATE_10X.Value && QDesign.NULL(T_END_DATE.Value) < QDesign.NULL(QDesign.PhDate(QDesign.Days(D_PROP_DATE_10X.Value + 7))))
                                                    {
                                                        T_WEB_END_WEEK.Value = QDesign.ASCII(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_10"), 2);
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


        private bool Internal_CHECK_SPLIT_WEEKS()
        {


            try
            {

                if ((QDesign.NULL(flePROPERTIES.GetStringValue("SPLIT_WEEKS")) == "Y" && QDesign.NULL(D_NIGHTS.Value) < 7 && QDesign.NULL(D_SPLIT_VALID.Value) == "N") || QDesign.NULL(T_TEN_SHH_SPLIT.Value) == "N")
                {
                    if (QDesign.NULL(fleBOOKINGS.GetStringValue("USER_LOGON")) == "sally" || QDesign.NULL(fleBOOKINGS.GetStringValue("USER_LOGON")) == "suec" || QDesign.NULL(fleBOOKINGS.GetStringValue("USER_LOGON")) == "hayleyd" || QDesign.NULL(fleBOOKINGS.GetStringValue("USER_LOGON")) == "manger" || QDesign.NULL(fleBOOKINGS.GetStringValue("USER_LOGON")) == "wendy")
                    {
                        Information("** " + D_START_DOW.Value + "/" + D_END_DOW.Value + "  Nts " + QDesign.ASCII(D_NIGHTS.Value) + " SPLIT-WEEK PROPERTY - INVALID DATES **");
                        // TODO: May need to fix manually
                    }
                    else
                    {
                        ErrorMessage("** " + D_START_DOW.Value + "/" + D_END_DOW.Value + "  Nts " + QDesign.ASCII(D_NIGHTS.Value) + " SPLIT-WEEK PROPERTY - INVALID DATES **");
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


        private bool Internal_CHECK_DATES_FREE()
        {


            try
            {

                T_TEN_SHH_SPLIT.Value = " ";
                Internal_CHECK_SPLIT_WEEKS();
                //#CORE_BEGIN_INCLUDE: USEB0300.USE"

                //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
                //# Do not delete, modify or move it.  Updated: 07/12/2013 1:49:47 PM

                T_ERROR_FLAG.Value = "N";
                if (T_START_DATE.Value >= D_PROP_DATE_1.Value)
                {
                    T_WEEK_STATUS.Value = fleSCREEN_PROPERTY.GetStringValue("WEEK_STATUS_1");
                    T_PROPERTY_DATE.Value = D_PROP_DATE_1.Value;
                    Internal_CHECK_WEB_BOOKING();
                    if (D_PRP_1.Value >= T_START_DATE.Value && D_PRP_1.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_1.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                    if (D_PRP_2.Value >= T_START_DATE.Value && D_PRP_2.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_2.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                    if (D_PRP_3.Value >= T_START_DATE.Value && D_PRP_3.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_3.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                    if (D_PRP_4.Value >= T_START_DATE.Value && D_PRP_4.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_4.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                    if (D_PRP_5.Value >= T_START_DATE.Value && D_PRP_5.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_5.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                    if (D_PRP_6.Value >= T_START_DATE.Value && D_PRP_6.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_6.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                    if (D_PRP_7.Value >= T_START_DATE.Value && D_PRP_7.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_7.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                }
                if (T_START_DATE.Value >= D_PROP_DATE_2.Value || (QDesign.NULL(T_START_DATE.Value) < QDesign.NULL(D_PROP_DATE_2.Value) && T_END_DATE.Value >= D_PROP_DATE_2.Value))
                {
                    T_WEEK_STATUS.Value = fleSCREEN_PROPERTY.GetStringValue("WEEK_STATUS_2");
                    T_PROPERTY_DATE.Value = D_PROP_DATE_2.Value;
                    Internal_CHECK_WEB_BOOKING();
                    if (D_PRP_1.Value >= T_START_DATE.Value && D_PRP_1.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_1.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                    if (D_PRP_2.Value >= T_START_DATE.Value && D_PRP_2.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_2.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                    if (D_PRP_3.Value >= T_START_DATE.Value && D_PRP_3.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_3.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                    if (D_PRP_4.Value >= T_START_DATE.Value && D_PRP_4.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_4.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                    if (D_PRP_5.Value >= T_START_DATE.Value && D_PRP_5.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_5.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                    if (D_PRP_6.Value >= T_START_DATE.Value && D_PRP_6.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_6.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                    if (D_PRP_7.Value >= T_START_DATE.Value && D_PRP_7.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_7.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                }
                if (T_START_DATE.Value >= D_PROP_DATE_3.Value || (QDesign.NULL(T_START_DATE.Value) < QDesign.NULL(D_PROP_DATE_3.Value) && T_END_DATE.Value >= D_PROP_DATE_3.Value))
                {
                    T_WEEK_STATUS.Value = fleSCREEN_PROPERTY.GetStringValue("WEEK_STATUS_3");
                    T_PROPERTY_DATE.Value = D_PROP_DATE_3.Value;
                    Internal_CHECK_WEB_BOOKING();
                    if (D_PRP_1.Value >= T_START_DATE.Value && D_PRP_1.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_1.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                    if (D_PRP_2.Value >= T_START_DATE.Value && D_PRP_2.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_2.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                    if (D_PRP_3.Value >= T_START_DATE.Value && D_PRP_3.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_3.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                    if (D_PRP_4.Value >= T_START_DATE.Value && D_PRP_4.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_4.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                    if (D_PRP_5.Value >= T_START_DATE.Value && D_PRP_5.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_5.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                    if (D_PRP_6.Value >= T_START_DATE.Value && D_PRP_6.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_6.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                    if (D_PRP_7.Value >= T_START_DATE.Value && D_PRP_7.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_7.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                }
                if (T_START_DATE.Value >= D_PROP_DATE_4.Value || (QDesign.NULL(T_START_DATE.Value) < QDesign.NULL(D_PROP_DATE_4.Value) && T_END_DATE.Value >= D_PROP_DATE_4.Value))
                {
                    T_WEEK_STATUS.Value = fleSCREEN_PROPERTY.GetStringValue("WEEK_STATUS_4");
                    T_PROPERTY_DATE.Value = D_PROP_DATE_4.Value;
                    Internal_CHECK_WEB_BOOKING();
                    if (D_PRP_1.Value >= T_START_DATE.Value && D_PRP_1.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_1.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                    if (D_PRP_2.Value >= T_START_DATE.Value && D_PRP_2.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_2.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                    if (D_PRP_3.Value >= T_START_DATE.Value && D_PRP_3.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_3.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                    if (D_PRP_4.Value >= T_START_DATE.Value && D_PRP_4.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_4.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                    if (D_PRP_5.Value >= T_START_DATE.Value && D_PRP_5.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_5.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                    if (D_PRP_6.Value >= T_START_DATE.Value && D_PRP_6.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_6.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                    if (D_PRP_7.Value >= T_START_DATE.Value && D_PRP_7.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_7.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                }
                if (T_START_DATE.Value >= D_PROP_DATE_5.Value || (QDesign.NULL(T_START_DATE.Value) < QDesign.NULL(D_PROP_DATE_5.Value) && T_END_DATE.Value >= D_PROP_DATE_5.Value))
                {
                    T_WEEK_STATUS.Value = fleSCREEN_PROPERTY.GetStringValue("WEEK_STATUS_5");
                    T_PROPERTY_DATE.Value = D_PROP_DATE_5.Value;
                    Internal_CHECK_WEB_BOOKING();
                    if (D_PRP_1.Value >= T_START_DATE.Value && D_PRP_1.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_1.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                    if (D_PRP_2.Value >= T_START_DATE.Value && D_PRP_2.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_2.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                    if (D_PRP_3.Value >= T_START_DATE.Value && D_PRP_3.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_3.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                    if (D_PRP_4.Value >= T_START_DATE.Value && D_PRP_4.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_4.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                    if (D_PRP_5.Value >= T_START_DATE.Value && D_PRP_5.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_5.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                    if (D_PRP_6.Value >= T_START_DATE.Value && D_PRP_6.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_6.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                    if (D_PRP_7.Value >= T_START_DATE.Value && D_PRP_7.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_7.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                }
                if (T_START_DATE.Value >= D_PROP_DATE_6.Value || (QDesign.NULL(T_START_DATE.Value) < QDesign.NULL(D_PROP_DATE_6.Value) && T_END_DATE.Value >= D_PROP_DATE_6.Value))
                {
                    T_WEEK_STATUS.Value = fleSCREEN_PROPERTY.GetStringValue("WEEK_STATUS_6");
                    T_PROPERTY_DATE.Value = D_PROP_DATE_6.Value;
                    Internal_CHECK_WEB_BOOKING();
                    if (D_PRP_1.Value >= T_START_DATE.Value && D_PRP_1.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_1.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                    if (D_PRP_2.Value >= T_START_DATE.Value && D_PRP_2.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_2.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                    if (D_PRP_3.Value >= T_START_DATE.Value && D_PRP_3.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_3.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                    if (D_PRP_4.Value >= T_START_DATE.Value && D_PRP_4.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_4.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                    if (D_PRP_5.Value >= T_START_DATE.Value && D_PRP_5.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_5.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                    if (D_PRP_6.Value >= T_START_DATE.Value && D_PRP_6.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_6.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                    if (D_PRP_7.Value >= T_START_DATE.Value && D_PRP_7.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_7.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                }
                if (T_START_DATE.Value >= D_PROP_DATE_7.Value || (QDesign.NULL(T_START_DATE.Value) < QDesign.NULL(D_PROP_DATE_7.Value) && T_END_DATE.Value >= D_PROP_DATE_7.Value))
                {
                    T_WEEK_STATUS.Value = fleSCREEN_PROPERTY.GetStringValue("WEEK_STATUS_7");
                    T_PROPERTY_DATE.Value = D_PROP_DATE_7.Value;
                    Internal_CHECK_WEB_BOOKING();
                    if (D_PRP_1.Value >= T_START_DATE.Value && D_PRP_1.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_1.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                    if (D_PRP_2.Value >= T_START_DATE.Value && D_PRP_2.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_2.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                    if (D_PRP_3.Value >= T_START_DATE.Value && D_PRP_3.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_3.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                    if (D_PRP_4.Value >= T_START_DATE.Value && D_PRP_4.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_4.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                    if (D_PRP_5.Value >= T_START_DATE.Value && D_PRP_5.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_5.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                    if (D_PRP_6.Value >= T_START_DATE.Value && D_PRP_6.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_6.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                    if (D_PRP_7.Value >= T_START_DATE.Value && D_PRP_7.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_7.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                }
                if (T_START_DATE.Value >= D_PROP_DATE_8.Value || (QDesign.NULL(T_START_DATE.Value) < QDesign.NULL(D_PROP_DATE_8.Value) && T_END_DATE.Value >= D_PROP_DATE_8.Value))
                {
                    T_WEEK_STATUS.Value = fleSCREEN_PROPERTY.GetStringValue("WEEK_STATUS_8");
                    T_PROPERTY_DATE.Value = D_PROP_DATE_8.Value;
                    Internal_CHECK_WEB_BOOKING();
                    if (D_PRP_1.Value >= T_START_DATE.Value && D_PRP_1.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_1.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                    if (D_PRP_2.Value >= T_START_DATE.Value && D_PRP_2.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_2.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                    if (D_PRP_3.Value >= T_START_DATE.Value && D_PRP_3.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_3.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                    if (D_PRP_4.Value >= T_START_DATE.Value && D_PRP_4.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_4.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                    if (D_PRP_5.Value >= T_START_DATE.Value && D_PRP_5.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_5.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                    if (D_PRP_6.Value >= T_START_DATE.Value && D_PRP_6.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_6.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                    if (D_PRP_7.Value >= T_START_DATE.Value && D_PRP_7.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_7.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                }
                if (T_START_DATE.Value >= D_PROP_DATE_9.Value || (QDesign.NULL(T_START_DATE.Value) < QDesign.NULL(D_PROP_DATE_9.Value) && T_END_DATE.Value >= D_PROP_DATE_9.Value))
                {
                    T_WEEK_STATUS.Value = fleSCREEN_PROPERTY.GetStringValue("WEEK_STATUS_9");
                    T_PROPERTY_DATE.Value = D_PROP_DATE_9.Value;
                    Internal_CHECK_WEB_BOOKING();
                    if (D_PRP_1.Value >= T_START_DATE.Value && D_PRP_1.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_1.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                    if (D_PRP_2.Value >= T_START_DATE.Value && D_PRP_2.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_2.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                    if (D_PRP_3.Value >= T_START_DATE.Value && D_PRP_3.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_3.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                    if (D_PRP_4.Value >= T_START_DATE.Value && D_PRP_4.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_4.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                    if (D_PRP_5.Value >= T_START_DATE.Value && D_PRP_5.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_5.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                    if (D_PRP_6.Value >= T_START_DATE.Value && D_PRP_6.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_6.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                    if (D_PRP_7.Value >= T_START_DATE.Value && D_PRP_7.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_7.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                }
                if (T_START_DATE.Value >= D_PROP_DATE_10.Value || (QDesign.NULL(T_START_DATE.Value) < QDesign.NULL(D_PROP_DATE_10.Value) && T_END_DATE.Value >= D_PROP_DATE_10.Value))
                {
                    T_WEEK_STATUS.Value = fleSCREEN_PROPERTY.GetStringValue("WEEK_STATUS_10");
                    T_PROPERTY_DATE.Value = D_PROP_DATE_10.Value;
                    Internal_CHECK_WEB_BOOKING();
                    if (D_PRP_1.Value >= T_START_DATE.Value && D_PRP_1.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_1.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                    if (D_PRP_2.Value >= T_START_DATE.Value && D_PRP_2.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_2.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                    if (D_PRP_3.Value >= T_START_DATE.Value && D_PRP_3.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_3.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                    if (D_PRP_4.Value >= T_START_DATE.Value && D_PRP_4.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_4.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                    if (D_PRP_5.Value >= T_START_DATE.Value && D_PRP_5.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_5.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                    if (D_PRP_6.Value >= T_START_DATE.Value && D_PRP_6.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_6.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }
                    if (D_PRP_7.Value >= T_START_DATE.Value && D_PRP_7.Value <= T_END_DATE.Value)
                    {
                        if (QDesign.NULL(D_STATUS_7.Value) != QDesign.NULL("."))
                        {
                            T_ERROR_FLAG.Value = "Y";
                        }
                    }

                    //#CORE_END_INCLUDE: USEB0300.USE"


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


        private bool Internal_GET_CHARGES_BPERIODS()
        {


            try
            {

                // --> GET CHARGES <--
                m_strWhere = new StringBuilder(" WHERE ");
                m_strWhere.Append(" ").Append(fleCHARGES.ElementOwner("LOCATION")).Append(" = ");
                m_strWhere.Append(Common.StringToField(fleSCREEN_PROPERTY.GetStringValue("LOCATION")));
                m_strWhere.Append(" AND ").Append(" ").Append(fleCHARGES.ElementOwner("BEDS")).Append(" = ");
                m_strWhere.Append(Common.StringToField(fleSCREEN_PROPERTY.GetStringValue("BEDS")));
                m_strWhere.Append(" AND ").Append(" ").Append(fleCHARGES.ElementOwner("PROPERTY_STYLE")).Append(" = ");
                m_strWhere.Append(Common.StringToField(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_STYLE")));
                m_strWhere.Append(" AND ").Append(" ").Append(fleCHARGES.ElementOwner("BATHROOMS")).Append(" = ");
                m_strWhere.Append(Common.StringToField(fleSCREEN_PROPERTY.GetStringValue("BATHROOMS")));
                m_strWhere.Append(" AND ").Append(" ").Append(fleCHARGES.ElementOwner("YEAR")).Append(" = ");
                m_strWhere.Append(Common.StringToField(fleSCREEN_PROPERTY.GetStringValue("YEAR")));

                fleCHARGES.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                // --> End GET CHARGES <--
                if (!AccessOk)
                {
                    Severe("52021");
                }

                fleCHARGES_DTL.GetData("", GetDataOptions.ForOccurence);

                // --> GET BOOKING_PERIODS <--
                m_strWhere = new StringBuilder(" WHERE ");
                m_strWhere.Append(" ").Append(fleBOOKING_PERIODS.ElementOwner("LOCATION")).Append(" = ");
                m_strWhere.Append(Common.StringToField(fleSCREEN_PROPERTY.GetStringValue("LOCATION")));
                m_strWhere.Append(" AND ").Append(" ").Append(fleBOOKING_PERIODS.ElementOwner("CHANGEOVER_DAY")).Append(" = ");
                m_strWhere.Append(Common.StringToField(flePROPERTIES.GetStringValue("CHANGEOVER_DAY")));
                m_strWhere.Append(" AND ").Append(" ").Append(fleBOOKING_PERIODS.ElementOwner("YEAR")).Append(" = ");
                m_strWhere.Append(Common.StringToField(fleSCREEN_PROPERTY.GetStringValue("YEAR")));


                fleBOOKING_PERIODS.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                // --> End GET BOOKING_PERIODS <--
                if (!AccessOk)
                {
                    Severe("52022");
                }

                m_strWhere = new StringBuilder(" WHERE ");
                m_strWhere.Append(" ").Append(fleBOOKING_PERIODS_DTL.ElementOwner("LOCATION")).Append(" = ");
                m_strWhere.Append(Common.StringToField(fleBOOKING_PERIODS.GetStringValue("LOCATION")));
                m_strWhere.Append(" AND ").Append(" ").Append(fleBOOKING_PERIODS_DTL.ElementOwner("CHANGEOVER_DAY")).Append(" = ");
                m_strWhere.Append(Common.StringToField(fleBOOKING_PERIODS.GetStringValue("CHANGEOVER_DAY")));
                m_strWhere.Append(" AND ").Append(" ").Append(fleBOOKING_PERIODS_DTL.ElementOwner("YEAR")).Append(" = ");
                m_strWhere.Append(Common.StringToField(fleBOOKING_PERIODS.GetStringValue("YEAR")));


                fleBOOKING_PERIODS_DTL.GetData(m_strWhere.ToString(), GetDataOptions.ForOccurence);

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


        private bool Internal_PART_CHARGE()
        {


            try
            {

                T_COUNT.Value = 0;
                if (D_DAY_1.Value >= T_START_DATE.Value && D_DAY_1.Value <= T_END_DATE.Value)
                {
                    T_COUNT.Value = T_COUNT.Value + 1;
                }
                if (D_DAY_2.Value >= T_START_DATE.Value && D_DAY_2.Value <= T_END_DATE.Value)
                {
                    T_COUNT.Value = T_COUNT.Value + 1;
                }
                if (D_DAY_3.Value >= T_START_DATE.Value && D_DAY_3.Value <= T_END_DATE.Value)
                {
                    T_COUNT.Value = T_COUNT.Value + 1;
                }
                if (D_DAY_4.Value >= T_START_DATE.Value && D_DAY_4.Value <= T_END_DATE.Value)
                {
                    T_COUNT.Value = T_COUNT.Value + 1;
                }
                if (D_DAY_5.Value >= T_START_DATE.Value && D_DAY_5.Value <= T_END_DATE.Value)
                {
                    T_COUNT.Value = T_COUNT.Value + 1;
                }
                if (D_DAY_6.Value >= T_START_DATE.Value && D_DAY_6.Value <= T_END_DATE.Value)
                {
                    T_COUNT.Value = T_COUNT.Value + 1;
                }
                if (D_DAY_7.Value >= T_START_DATE.Value && D_DAY_7.Value <= T_END_DATE.Value)
                {
                    T_COUNT.Value = T_COUNT.Value + 1;
                }
                if (QDesign.NULL(T_POINTS_1.Value) == 0)
                {
                    T_POINTS_1.Value = D_PART_POINTS.Value;
                }
                else
                {
                    if (QDesign.NULL(T_POINTS_2.Value) == 0)
                    {
                        T_POINTS_2.Value = D_PART_POINTS.Value;
                    }
                    else
                    {
                        if (QDesign.NULL(T_POINTS_3.Value) == 0)
                        {
                            T_POINTS_3.Value = D_PART_POINTS.Value;
                        }
                        else
                        {
                            if (QDesign.NULL(T_POINTS_4.Value) == 0)
                            {
                                T_POINTS_4.Value = D_PART_POINTS.Value;
                            }
                            else
                            {
                                if (QDesign.NULL(T_POINTS_5.Value) == 0)
                                {
                                    T_POINTS_5.Value = D_PART_POINTS.Value;
                                }
                                else
                                {
                                    if (QDesign.NULL(T_POINTS_6.Value) == 0)
                                    {
                                        T_POINTS_6.Value = D_PART_POINTS.Value;
                                    }
                                    else
                                    {
                                        if (QDesign.NULL(T_POINTS_7.Value) == 0)
                                        {
                                            T_POINTS_7.Value = D_PART_POINTS.Value;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if (QDesign.NULL(D_UNDER_A_WEEK.Value) == "Y")
                {
                    T_CHARGE.Value = D_USER_CHARGE.Value;
                    while (this.For(6))
                    {
                        if (Occurrence == QDesign.NULL(T_COUNT.Value))
                        {
                            T_TOTAL_DAYS.Value = T_TOTAL_DAYS.Value + T_COUNT.Value;
                            T_WEEK.Value = T_WEEK.Value + 1;
                            T_TOTAL_WEEKLY_RATE.Value = T_TOTAL_WEEKLY_RATE.Value + T_CHARGE.Value;
                        }
                    }
                }
                else
                {
                    T_USER_CHARGE_TOT.Value = T_USER_CHARGE_TOT.Value + D_EXTRADAYS_CHARGE.Value;
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


        private bool Internal_ZERO_T_POINTS()
        {


            try
            {

                T_POINTS_1.Value = 0;
                T_POINTS_2.Value = 0;
                T_POINTS_3.Value = 0;
                T_POINTS_4.Value = 0;
                T_POINTS_5.Value = 0;
                T_POINTS_6.Value = 0;
                T_POINTS_7.Value = 0;

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


        private bool Internal_CHARGE_BY_DATE()
        {


            try
            {

                T_SPLIT_CHARGE.Value = 0;
                while (fleCHARGES_DTL.For())
                {
                    if (QDesign.NULL(D_WEEK_END_DATE.Value) < QDesign.NULL(T_START_DATE.Value))
                    {
                        // QDesign.NULL
                    }
                    else
                    {
                        if (QDesign.NULL(fleBOOKING_PERIODS_DTL.GetDecimalValue("START_DATE")) > QDesign.NULL(T_END_DATE.Value))
                        {
                            // QDesign.NULL
                        }
                        else
                        {
                            if (fleBOOKING_PERIODS_DTL.GetDecimalValue("START_DATE") >= T_START_DATE.Value && D_WEEK_END_DATE.Value <= T_END_DATE.Value)
                            {
                                T_USER_CHARGE_TOT.Value = T_USER_CHARGE_TOT.Value + D_USER_CHARGE.Value;
                                if (QDesign.NULL(T_POINTS_1.Value) == 0)
                                {
                                    T_POINTS_1.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                                    // TODO: POINTS_CHARGE occurs 53.  Manual steps may be required.
                                }
                                else
                                {
                                    if (QDesign.NULL(T_POINTS_2.Value) == 0)
                                    {
                                        T_POINTS_2.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                                        // TODO: POINTS_CHARGE occurs 53.  Manual steps may be required.
                                    }
                                    else
                                    {
                                        if (QDesign.NULL(T_POINTS_3.Value) == 0)
                                        {
                                            T_POINTS_3.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                                            // TODO: POINTS_CHARGE occurs 53.  Manual steps may be required.
                                        }
                                        else
                                        {
                                            if (QDesign.NULL(T_POINTS_4.Value) == 0)
                                            {
                                                T_POINTS_4.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                                                // TODO: POINTS_CHARGE occurs 53.  Manual steps may be required.
                                            }
                                            else
                                            {
                                                if (QDesign.NULL(T_POINTS_5.Value) == 0)
                                                {
                                                    T_POINTS_5.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                                                    // TODO: POINTS_CHARGE occurs 53.  Manual steps may be required.
                                                }
                                                else
                                                {
                                                    if (QDesign.NULL(T_POINTS_6.Value) == 0)
                                                    {
                                                        T_POINTS_6.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                                                        // TODO: POINTS_CHARGE occurs 53.  Manual steps may be required.
                                                    }
                                                    else
                                                    {
                                                        if (QDesign.NULL(T_POINTS_7.Value) == 0)
                                                        {
                                                            T_POINTS_7.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                                                            // TODO: POINTS_CHARGE occurs 53.  Manual steps may be required.
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (QDesign.NULL(D_SPLIT_VALID.Value) != "Y")
                                {
                                    Internal_PART_CHARGE();
                                }
                                else
                                {
                                    // TODO: POINTS_CHARGE occurs 53.  Manual steps may be required.
                                    if (QDesign.NULL(fleM_INVESTORS.GetStringValue("COLOUR")) == "S" && QDesign.NULL(fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE")) == 0)
                                    {
                                        T_SILVER_POINTS_FREE.Value = "Y";
                                    }
                                    if (QDesign.NULL(D_PAY_USER_CHARGE.Value) == "Y")
                                    {
                                        if (QDesign.NULL(QDesign.Substring(flePROPERTIES.GetStringValue("GROUPING"), 1, 3)) == "TEN" || QDesign.NULL(QDesign.Substring(flePROPERTIES.GetStringValue("GROUPING"), 1, 3)) == "SHH")
                                        {
                                            if (QDesign.NULL(D_SPLIT_CHARGE.Value) == 0)
                                            {
                                                T_TEN_SHH_SPLIT.Value = "N";
                                                Internal_CHECK_SPLIT_WEEKS();
                                            }
                                            else
                                            {
                                                if (QDesign.NULL(T_SPLIT_CHARGE.Value) == 0)
                                                {
                                                    T_SPLIT_CHARGE.Value = D_SPLIT_CHARGE.Value;
                                                    T_USER_CHARGE_TOT.Value = D_SPLIT_CHARGE.Value;
                                                }
                                                else
                                                {
                                                    Warning("32000");
                                                    T_USER_CHARGE_TOT.Value = 0;
                                                    Display(ref fldD_DUE_NOW);
                                                }
                                                T_TEN_SHH_SPLIT.Value = "Y";
                                            }
                                        }
                                        else
                                        {
                                            T_USER_CHARGE_TOT.Value = D_USER_CHARGE.Value * (D_SPLIT_CHARGE_PER.Value / 100);
                                        }
                                    }
                                    if (fleBOOKING_PERIODS_DTL.GetDecimalValue("START_DATE") <= T_START_DATE.Value && fleBOOKING_PERIODS_DTL.GetDecimalValue("END_DATE") >= T_START_DATE.Value)
                                    {
                                        T_POINTS_1.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE") * (D_SPLIT_POINTS_PER.Value / 100);
                                        // TODO: POINTS_CHARGE occurs 53.  Manual steps may be required.
                                    }
                                }
                            }
                        }
                    }
                }
                if (QDesign.NULL(D_POINTS_FREE.Value) == "Y")
                {
                    Internal_ZERO_T_POINTS();
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


        private bool Internal_DISPLAY_CHARGES()
        {


            try
            {

                Display(ref fldT_POINTS_1);
                Display(ref fldT_POINTS_2);
                Display(ref fldT_POINTS_3);
                Display(ref fldT_POINTS_4);
                Display(ref fldT_POINTS_5);
                Display(ref fldT_POINTS_6);
                Display(ref fldT_POINTS_7);
                Display(ref fldFORF_ACCOUNT_FORF_BAL);
                Display(ref fldD_AVAILABLE);
                Display(ref fldD_SUSP_MAX);
                Display(ref fldD_PURC_MAX);
                Display(ref fldD_OD_MAX);
                Display(ref fldD_NET_POINTS);
                Display(ref fldD_POINTS_BALANCE);
                Display(ref fldD_SUBTOTAL);
                fleBOOKINGS.set_SetValue("CONFIRM_DATE", D_CONFIRM_DATE.Value);
                Display(ref fldBOOKINGS_CONFIRM_DATE);
                fleBOOKINGS.set_SetValue("BK_FORF_POINTS", D_FORF_POINTS.Value);
                Display(ref fldD_FORF_BAL);
                Display(ref fldD_AVAILABLE);
                Display(ref fldD_PP_SURCHARGE);
                Display(ref fldD_PP_FLAG);
                if (QDesign.NULL(D_FORF_BAL.Value) > 0 && QDesign.NULL(D_FORF_POINTS.Value) > 0)
                {
                    Warning(D_FORF_MESSAGE.Value);
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


        private bool Internal_CALC_UCHARGE_POINTS()
        {


            try
            {

                Internal_ZERO_T_POINTS();
                T_USER_CHARGE_TOT.Value = 0;
                while (fleCHARGES_DTL.For())
                {
                    if (QDesign.NULL(T_POINTS_1.Value) == 0 && Occurrence >= T_START_WEEK.Value && Occurrence <= T_END_WEEK.Value)
                    {
                        T_POINTS_1.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                        // TODO: POINTS_CHARGE occurs 53.  Manual steps may be required.
                        // TODO: POINTS_CHARGE occurs 53.  Manual steps may be required.
                        if (QDesign.NULL(fleM_INVESTORS.GetStringValue("COLOUR")) == "S" && QDesign.NULL(fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE")) == 0)
                        {
                            T_SILVER_POINTS_FREE.Value = "Y";
                        }
                        if (QDesign.NULL(D_SET_USER_CHARGE.Value) == "Y")
                        {
                            T_USER_CHARGE_TOT.Value = T_USER_CHARGE_TOT.Value + D_USER_CHARGE.Value;
                        }
                    }
                    else
                    {
                        if (QDesign.NULL(T_POINTS_2.Value) == 0 && Occurrence >= T_START_WEEK.Value && Occurrence <= T_END_WEEK.Value)
                        {
                            T_POINTS_2.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                            // TODO: POINTS_CHARGE occurs 53.  Manual steps may be required.
                            // TODO: POINTS_CHARGE occurs 53.  Manual steps may be required.
                            if (QDesign.NULL(fleM_INVESTORS.GetStringValue("COLOUR")) == "S" && QDesign.NULL(fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE")) == 0)
                            {
                                T_SILVER_POINTS_FREE.Value = "Y";
                            }
                            if (QDesign.NULL(D_SET_USER_CHARGE.Value) == "Y")
                            {
                                T_USER_CHARGE_TOT.Value = T_USER_CHARGE_TOT.Value + D_USER_CHARGE.Value;
                            }
                        }
                        else
                        {
                            if (QDesign.NULL(T_POINTS_3.Value) == 0 && Occurrence >= T_START_WEEK.Value && Occurrence <= T_END_WEEK.Value)
                            {
                                T_POINTS_3.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                                // TODO: POINTS_CHARGE occurs 53.  Manual steps may be required.
                                // TODO: POINTS_CHARGE occurs 53.  Manual steps may be required.
                                if (QDesign.NULL(fleM_INVESTORS.GetStringValue("COLOUR")) == "S" && QDesign.NULL(fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE")) == 0)
                                {
                                    T_SILVER_POINTS_FREE.Value = "Y";
                                }
                                if (QDesign.NULL(D_SET_USER_CHARGE.Value) == "Y")
                                {
                                    T_USER_CHARGE_TOT.Value = T_USER_CHARGE_TOT.Value + D_USER_CHARGE.Value;
                                }
                            }
                            else
                            {
                                if (QDesign.NULL(T_POINTS_4.Value) == 0 && Occurrence >= T_START_WEEK.Value && Occurrence <= T_END_WEEK.Value)
                                {
                                    T_POINTS_4.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                                    // TODO: POINTS_CHARGE occurs 53.  Manual steps may be required.
                                    // TODO: POINTS_CHARGE occurs 53.  Manual steps may be required.
                                    if (QDesign.NULL(fleM_INVESTORS.GetStringValue("COLOUR")) == "S" && QDesign.NULL(fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE")) == 0)
                                    {
                                        T_SILVER_POINTS_FREE.Value = "Y";
                                    }
                                    if (QDesign.NULL(D_SET_USER_CHARGE.Value) == "Y")
                                    {
                                        T_USER_CHARGE_TOT.Value = T_USER_CHARGE_TOT.Value + D_USER_CHARGE.Value;
                                    }
                                }
                                else
                                {
                                    if (QDesign.NULL(T_POINTS_5.Value) == 0 && Occurrence >= T_START_WEEK.Value && Occurrence <= T_END_WEEK.Value)
                                    {
                                        T_POINTS_5.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                                        // TODO: POINTS_CHARGE occurs 53.  Manual steps may be required.
                                        // TODO: POINTS_CHARGE occurs 53.  Manual steps may be required.
                                        if (QDesign.NULL(fleM_INVESTORS.GetStringValue("COLOUR")) == "S" && QDesign.NULL(fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE")) == 0)
                                        {
                                            T_SILVER_POINTS_FREE.Value = "Y";
                                        }
                                        if (QDesign.NULL(D_SET_USER_CHARGE.Value) == "Y")
                                        {
                                            T_USER_CHARGE_TOT.Value = T_USER_CHARGE_TOT.Value + D_USER_CHARGE.Value;
                                        }
                                    }
                                    else
                                    {
                                        if (QDesign.NULL(T_POINTS_6.Value) == 0 && Occurrence >= T_START_WEEK.Value && Occurrence <= T_END_WEEK.Value)
                                        {
                                            T_POINTS_6.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                                            // TODO: POINTS_CHARGE occurs 53.  Manual steps may be required.
                                            // TODO: POINTS_CHARGE occurs 53.  Manual steps may be required.
                                            if (QDesign.NULL(fleM_INVESTORS.GetStringValue("COLOUR")) == "S" && QDesign.NULL(fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE")) == 0)
                                            {
                                                T_SILVER_POINTS_FREE.Value = "Y";
                                            }
                                            if (QDesign.NULL(D_SET_USER_CHARGE.Value) == "Y")
                                            {
                                                T_USER_CHARGE_TOT.Value = T_USER_CHARGE_TOT.Value + D_USER_CHARGE.Value;
                                            }
                                        }
                                        else
                                        {
                                            if (QDesign.NULL(T_POINTS_7.Value) == 0 && Occurrence >= T_START_WEEK.Value && Occurrence <= T_END_WEEK.Value)
                                            {
                                                T_POINTS_7.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                                                // TODO: POINTS_CHARGE occurs 53.  Manual steps may be required.
                                                // TODO: POINTS_CHARGE occurs 53.  Manual steps may be required.
                                                if (QDesign.NULL(fleM_INVESTORS.GetStringValue("COLOUR")) == "S" && QDesign.NULL(fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE")) == 0)
                                                {
                                                    T_SILVER_POINTS_FREE.Value = "Y";
                                                }
                                                if (QDesign.NULL(D_SET_USER_CHARGE.Value) == "Y")
                                                {
                                                    T_USER_CHARGE_TOT.Value = T_USER_CHARGE_TOT.Value + D_USER_CHARGE.Value;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (fleBOOKING_PERIODS_DTL.GetDecimalValue("START_DATE") >= T_START_DATE.Value && D_WEEK_END_DATE.Value <= T_END_DATE.Value)
                    {
                        // QDesign.NULL
                    }
                }
                if (QDesign.NULL(D_POINTS_FREE.Value) == "Y" || QDesign.NULL(flePROPERTIES.GetStringValue("LOCATION")) == "RH")
                {
                    Internal_ZERO_T_POINTS();
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


        private bool Internal_CHECK_WEEKS_FREE()
        {


            try
            {

                if (QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_1")) == QDesign.NULL(T_START_WEEK.Value) && QDesign.NULL(fleSCREEN_PROPERTY.GetStringValue("WEEK_STATUS_1")) != "......." && QDesign.NULL(fleSCREEN_PROPERTY.GetStringValue("WEEK_STATUS_1")) != "QQQQQQQ")
                {
                    Severe("52023");
                }
                if ((QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_2")) == QDesign.NULL(QDesign.NConvert(FieldText)) || QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_2")) == QDesign.NULL(T_START_WEEK.Value) || (QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_2")) > QDesign.NULL(T_START_WEEK.Value) && QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_2")) < QDesign.NULL(QDesign.NConvert(FieldText)))) && (QDesign.NULL(fleSCREEN_PROPERTY.GetStringValue("WEEK_STATUS_2")) != ".......") && QDesign.NULL(fleSCREEN_PROPERTY.GetStringValue("WEEK_STATUS_2")) != "QQQQQQQ")
                {
                    Severe("52023");
                }
                if ((QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_3")) == QDesign.NULL(QDesign.NConvert(FieldText)) || QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_3")) == QDesign.NULL(T_START_WEEK.Value) || (QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_3")) > QDesign.NULL(T_START_WEEK.Value) && QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_3")) < QDesign.NULL(QDesign.NConvert(FieldText)))) && (QDesign.NULL(fleSCREEN_PROPERTY.GetStringValue("WEEK_STATUS_3")) != ".......") && QDesign.NULL(fleSCREEN_PROPERTY.GetStringValue("WEEK_STATUS_3")) != "QQQQQQQ")
                {
                    Severe("52023");
                }
                if ((QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_4")) == QDesign.NULL(QDesign.NConvert(FieldText)) || QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_4")) == QDesign.NULL(T_START_WEEK.Value) || (QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_4")) > QDesign.NULL(T_START_WEEK.Value) && QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_4")) < QDesign.NULL(QDesign.NConvert(FieldText)))) && (QDesign.NULL(fleSCREEN_PROPERTY.GetStringValue("WEEK_STATUS_4")) != ".......") && QDesign.NULL(fleSCREEN_PROPERTY.GetStringValue("WEEK_STATUS_4")) != "QQQQQQQ")
                {
                    Severe("52023");
                }
                if ((QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_5")) == QDesign.NULL(QDesign.NConvert(FieldText)) || QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_5")) == QDesign.NULL(T_START_WEEK.Value) || (QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_5")) > QDesign.NULL(T_START_WEEK.Value) && QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_5")) < QDesign.NULL(QDesign.NConvert(FieldText)))) && (QDesign.NULL(fleSCREEN_PROPERTY.GetStringValue("WEEK_STATUS_5")) != ".......") && QDesign.NULL(fleSCREEN_PROPERTY.GetStringValue("WEEK_STATUS_5")) != "QQQQQQQ")
                {
                    Severe("52023");
                }
                if ((QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_6")) == QDesign.NULL(QDesign.NConvert(FieldText)) || QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_6")) == QDesign.NULL(T_START_WEEK.Value) || (QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_6")) > QDesign.NULL(T_START_WEEK.Value) && QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_6")) < QDesign.NULL(QDesign.NConvert(FieldText)))) && (QDesign.NULL(fleSCREEN_PROPERTY.GetStringValue("WEEK_STATUS_6")) != ".......") && QDesign.NULL(fleSCREEN_PROPERTY.GetStringValue("WEEK_STATUS_6")) != "QQQQQQQ")
                {
                    Severe("52023");
                }
                if ((QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_7")) == QDesign.NULL(QDesign.NConvert(FieldText)) || QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_7")) == QDesign.NULL(T_START_WEEK.Value) || (QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_7")) > QDesign.NULL(T_START_WEEK.Value) && QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_7")) < QDesign.NULL(QDesign.NConvert(FieldText)))) && (QDesign.NULL(fleSCREEN_PROPERTY.GetStringValue("WEEK_STATUS_7")) != ".......") && QDesign.NULL(fleSCREEN_PROPERTY.GetStringValue("WEEK_STATUS_7")) != "QQQQQQQ")
                {
                    Severe("52023");
                }
                if ((QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_8")) == QDesign.NULL(QDesign.NConvert(FieldText)) || QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_8")) == QDesign.NULL(T_START_WEEK.Value) || (QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_8")) > QDesign.NULL(T_START_WEEK.Value) && QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_8")) < QDesign.NULL(QDesign.NConvert(FieldText)))) && (QDesign.NULL(fleSCREEN_PROPERTY.GetStringValue("WEEK_STATUS_8")) != ".......") && QDesign.NULL(fleSCREEN_PROPERTY.GetStringValue("WEEK_STATUS_8")) != "QQQQQQQ")
                {
                    Severe("52023");
                }
                if ((QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_9")) == QDesign.NULL(QDesign.NConvert(FieldText)) || QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_9")) == QDesign.NULL(T_START_WEEK.Value) || (QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_9")) > QDesign.NULL(T_START_WEEK.Value) && QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_9")) < QDesign.NULL(QDesign.NConvert(FieldText)))) && (QDesign.NULL(fleSCREEN_PROPERTY.GetStringValue("WEEK_STATUS_9")) != ".......") && QDesign.NULL(fleSCREEN_PROPERTY.GetStringValue("WEEK_STATUS_9")) != "QQQQQQQ")
                {
                    Severe("52023");
                }
                if ((QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_10")) == QDesign.NULL(QDesign.NConvert(FieldText)) || QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_10")) == QDesign.NULL(T_START_WEEK.Value) || (QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_10")) > QDesign.NULL(T_START_WEEK.Value) && QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_10")) < QDesign.NULL(QDesign.NConvert(FieldText)))) && (QDesign.NULL(fleSCREEN_PROPERTY.GetStringValue("WEEK_STATUS_10")) != ".......") && QDesign.NULL(fleSCREEN_PROPERTY.GetStringValue("WEEK_STATUS_10")) != "QQQQQQQ")
                {
                    Severe("52023");
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


        private bool Internal_CHECK_WEB_DATA()
        {


            try
            {

                if (QDesign.NULL(T_START_WEEK.Value) == 0)
                {
                    Internal_GET_WEB_WEEKNOS();
                }
                else
                {
                    T_WEB_START_WEEK.Value = QDesign.ASCII(T_START_WEEK.Value, 2);
                    T_WEB_END_WEEK.Value = QDesign.ASCII(T_END_WEEK.Value, 2);
                }
                if ((QDesign.NULL(T_WEB_START_WEEK.Value) != QDesign.NULL(T_OLD_START_WEEK.Value) || QDesign.NULL(T_WEB_END_WEEK.Value) != QDesign.NULL(T_OLD_END_WEEK.Value)))
                {
                    T_BOOKING_NOW.Value = "Y";
                    T_WEB_YEAR.Value = flePROPERTY_YEARS.GetStringValue("YEAR");
                    T_WEB_LOCATION.Value = flePROPERTY_YEARS.GetStringValue("LOCATION");
                    T_WEB_PROP_ID.Value = flePROPERTIES.GetStringValue("PROPERTY_ID");
                    T_LT_INVESTOR.Value = fleM_INVESTORS.GetStringValue("INVESTOR");
                    T_PICTURE_IN.Value = "";
                    T_PICTURE_OUT.Value = "";
                }
                T_OLD_START_WEEK.Value = T_WEB_START_WEEK.Value;
                T_OLD_END_WEEK.Value = T_WEB_END_WEEK.Value;

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


        private bool Internal_SET_DATES()
        {


            try
            {

                if (QDesign.NULL(T_START_WEEK.Value) != 0)
                {
                    if (QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_1")) == QDesign.NULL(T_START_WEEK.Value))
                    {
                        T_START_DATE.Value = D_PROP_DATE_1.Value;
                    }
                    if (QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_1")) == QDesign.NULL(T_END_WEEK.Value))
                    {
                        T_END_DATE.Value = QDesign.PhDate(QDesign.Days(D_PROP_DATE_1.Value) + 6);
                    }
                    if (QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_2")) == QDesign.NULL(T_START_WEEK.Value))
                    {
                        T_START_DATE.Value = D_PROP_DATE_2.Value;
                    }
                    if (QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_2")) == QDesign.NULL(T_END_WEEK.Value))
                    {
                        T_END_DATE.Value = QDesign.PhDate(QDesign.Days(D_PROP_DATE_2.Value) + 6);
                    }
                    if (QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_3")) == QDesign.NULL(T_START_WEEK.Value))
                    {
                        T_START_DATE.Value = D_PROP_DATE_3.Value;
                    }
                    if (QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_3")) == QDesign.NULL(T_END_WEEK.Value))
                    {
                        T_END_DATE.Value = QDesign.PhDate(QDesign.Days(D_PROP_DATE_3.Value) + 6);
                    }
                    if (QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_4")) == QDesign.NULL(T_START_WEEK.Value))
                    {
                        T_START_DATE.Value = D_PROP_DATE_4.Value;
                    }
                    if (QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_4")) == QDesign.NULL(T_END_WEEK.Value))
                    {
                        T_END_DATE.Value = QDesign.PhDate(QDesign.Days(D_PROP_DATE_4.Value) + 6);
                    }
                    if (QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_5")) == QDesign.NULL(T_START_WEEK.Value))
                    {
                        T_START_DATE.Value = D_PROP_DATE_5.Value;
                    }
                    if (QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_5")) == QDesign.NULL(T_END_WEEK.Value))
                    {
                        T_END_DATE.Value = QDesign.PhDate(QDesign.Days(D_PROP_DATE_5.Value) + 6);
                    }
                    if (QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_6")) == QDesign.NULL(T_START_WEEK.Value))
                    {
                        T_START_DATE.Value = D_PROP_DATE_6.Value;
                    }
                    if (QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_6")) == QDesign.NULL(T_END_WEEK.Value))
                    {
                        T_END_DATE.Value = QDesign.PhDate(QDesign.Days(D_PROP_DATE_6.Value) + 6);
                    }
                    if (QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_7")) == QDesign.NULL(T_START_WEEK.Value))
                    {
                        T_START_DATE.Value = D_PROP_DATE_7.Value;
                    }
                    if (QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_7")) == QDesign.NULL(T_END_WEEK.Value))
                    {
                        T_END_DATE.Value = QDesign.PhDate(QDesign.Days(D_PROP_DATE_7.Value) + 6);
                    }
                    if (QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_8")) == QDesign.NULL(T_START_WEEK.Value))
                    {
                        T_START_DATE.Value = D_PROP_DATE_8.Value;
                    }
                    if (QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_8")) == QDesign.NULL(T_END_WEEK.Value))
                    {
                        T_END_DATE.Value = QDesign.PhDate(QDesign.Days(D_PROP_DATE_8.Value) + 6);
                    }
                    if (QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_9")) == QDesign.NULL(T_START_WEEK.Value))
                    {
                        T_START_DATE.Value = D_PROP_DATE_9.Value;
                    }
                    if (QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_9")) == QDesign.NULL(T_END_WEEK.Value))
                    {
                        T_END_DATE.Value = QDesign.PhDate(QDesign.Days(D_PROP_DATE_9.Value) + 6);
                    }
                    if (QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_10")) == QDesign.NULL(T_START_WEEK.Value))
                    {
                        T_START_DATE.Value = D_PROP_DATE_10.Value;
                    }
                    if (QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_10")) == QDesign.NULL(T_END_WEEK.Value))
                    {
                        T_END_DATE.Value = QDesign.PhDate(QDesign.Days(D_PROP_DATE_10.Value) + 6);
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


        private bool Internal_CALC_VAT()
        {


            try
            {

                if (QDesign.NULL(flePROPERTIES.GetStringValue("VAT_FLAG")) == "Y")
                {
                    // --> GET COLOUR_RATES <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleCOLOUR_RATES.ElementOwner("COLOUR_SCHEME")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("V "));

                    fleCOLOUR_RATES.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // TODO: Add BACKWARDS code
                    // --> End GET COLOUR_RATES <--
                    if (!AccessOk)
                    {
                        Severe("52024");
                    }
                    fleBOOKINGS.set_SetValue("VAT", D_VAT.Value);
                    if (QDesign.NULL(D_DEPOSIT.Value) == "Y" && (QDesign.NULL(D_VAT_NOW.Value) > 0 || QDesign.NULL(fleUCHARGE_DEBTS.GetDecimalValue("VAT")) > 0))
                    {
                        fleUCHARGE_DEBTS.set_SetValue("VAT", D_VAT_NOW.Value);
                    }
                    else
                    {
                        if ((QDesign.NULL(D_VAT.Value) > 0 || QDesign.NULL(fleUCHARGE_DEBTS.GetDecimalValue("VAT")) > 0))
                        {
                            fleUCHARGE_DEBTS.set_SetValue("VAT", D_VAT.Value);
                        }
                    }
                }
                Display(ref fldD_FULL_CHARGE);

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


        private bool Internal_SET_USER_CHARGE()
        {


            try
            {

                // --> GET LOCATION_CURR <--
                m_strWhere = new StringBuilder(" WHERE ");
                m_strWhere.Append(" ").Append(fleLOCATION_CURR.ElementOwner("LOCATION")).Append(" = ");
                m_strWhere.Append(Common.StringToField(QDesign.Substring(T_BOOKING_REF.Value, 1, 2)));

                fleLOCATION_CURR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                // --> End GET LOCATION_CURR <--
                if (!AccessOk)
                {
                    Severe("52025");
                }
                // --> GET CURRENCY_RATE <--
                m_strWhere = new StringBuilder(" WHERE ");
                m_strWhere.Append(" ").Append(fleCURRENCY_RATE.ElementOwner("CURRENCY")).Append(" = ");
                m_strWhere.Append(Common.StringToField(fleLOCATION_CURR.GetStringValue("CURRENCY")));

                fleCURRENCY_RATE.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                // --> End GET CURRENCY_RATE <--
                if (!AccessOk)
                {
                    Severe("52026");
                }
                if (QDesign.NULL(fleM_INVESTORS.GetStringValue("INVESTOR")) != "00007" && QDesign.NULL(QDesign.Substring(fleM_INVESTORS.GetStringValue("INVESTOR"), 1, 3)) != "999" && QDesign.NULL(D_PAY_USER_CHARGE.Value) == "Y")
                {
                    fleBOOKINGS.set_SetValue("BOOKING_CHARGE", T_USER_CHARGE_TOT.Value);
                    fleBOOKINGS.set_SetValue("BOOKING_CHARGE", ((fleBOOKINGS.GetDecimalValue("BOOKING_CHARGE") / (fleCURRENCY_RATE.GetDecimalValue("EXCHANGE_RATE") / 10000)) + (decimal)0.5));
                }
                if (QDesign.NULL(fleM_INVESTORS.GetStringValue("COLOUR")) == "S" && QDesign.NULL(D_USE_FORF_BAL.Value) == "Y" && QDesign.NULL(flePROPERTIES.GetStringValue("RENTED_Y_N")) != "Y")
                {
                    fleBOOKINGS.set_SetValue("BOOKING_CHARGE", QDesign.Floor(fleBOOKINGS.GetDecimalValue("BOOKING_CHARGE") * (D_FORF_POINTS.Value / D_NET_POINTS.Value)));
                }
                if (QDesign.NULL(D_WITHIN_21_DAYS.Value) == "Y" && QDesign.NULL(QDesign.SysDate(ref m_cnnQUERY)) < 20060116)
                {
                    fleBOOKINGS.set_SetValue("BOOKING_CHARGE", fleBOOKINGS.GetDecimalValue("BOOKING_CHARGE") * (decimal)0.75);
                    Information("21 day rule - User charge discounted by 25%");
                    // TODO: May need to fix manually
                }
                if (QDesign.NULL(fleINVESTMENTS.GetDecimalValue("TERM_SURCHARGEPER")) > 0 && QDesign.NULL(D_NET_POINTS.Value) > 0)
                {
                    T_TERM_SURCHARGE.Value = QDesign.Round(fleBOOKINGS.GetDecimalValue("BOOKING_CHARGE") * (D_TERM_SURCHARGEPER.Value / 10000), 0, RoundOptionTypes.Near);
                    Display(ref fldT_TERM_SURCHARGE);
                }
                else
                {
                    T_TERM_SURCHARGE.Value = 0;
                    Display(ref fldT_TERM_SURCHARGE);
                }
                Display(ref fldBOOKINGS_BOOKING_CHARGE);
                Internal_CALC_VAT();

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

                if (QDesign.NULL(flePROPERTIES.GetStringValue("GROUPING")) != "HOTL")
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


        private bool Internal_RECHECK_AVAILABILITY()
        {


            try
            {

                //FileSystem.Lock(flePROPERTY_YEARS);
                // --> GET PROPERTY_YEARS <--
                m_strWhere = new StringBuilder(" WHERE ");
                m_strWhere.Append(" ").Append(flePROPERTY_YEARS.ElementOwner("LOCATION")).Append(" = ");
                m_strWhere.Append(Common.StringToField(flePROPERTIES.GetStringValue("LOCATION")));
                m_strWhere.Append(" AND ").Append(" ").Append(flePROPERTY_YEARS.ElementOwner("BEDS")).Append(" = ");
                m_strWhere.Append(Common.StringToField(flePROPERTIES.GetStringValue("BEDS")));
                m_strWhere.Append(" AND ").Append(" ").Append(flePROPERTY_YEARS.ElementOwner("PROPERTY_STYLE")).Append(" = ");
                m_strWhere.Append(Common.StringToField(flePROPERTIES.GetStringValue("PROPERTY_STYLE")));
                m_strWhere.Append(" AND ").Append(" ").Append(flePROPERTY_YEARS.ElementOwner("BATHROOMS")).Append(" = ");
                m_strWhere.Append(Common.StringToField(flePROPERTIES.GetStringValue("BATHROOMS")));
                m_strWhere.Append(" AND ").Append(" ").Append(flePROPERTY_YEARS.ElementOwner("PROPERTY_ID")).Append(" = ");
                m_strWhere.Append(Common.StringToField(flePROPERTIES.GetStringValue("PROPERTY_ID")));
                m_strWhere.Append(" AND ").Append(" ").Append(flePROPERTY_YEARS.ElementOwner("YEAR")).Append(" = ");
                m_strWhere.Append(Common.StringToField(fleBOOKING_PERIODS.GetStringValue("YEAR")));


                flePROPERTY_YEARS.GetData(m_strWhere.ToString());

                m_strWhere = new StringBuilder(" WHERE ");
                m_strWhere.Append(" ").Append(flePROPERTY_YEARS_DTL.ElementOwner("LOCATION")).Append(" = ");
                m_strWhere.Append(Common.StringToField(flePROPERTY_YEARS.GetStringValue("LOCATION")));
                m_strWhere.Append(" AND ").Append(" ").Append(flePROPERTY_YEARS_DTL.ElementOwner("BEDS")).Append(" = ");
                m_strWhere.Append(Common.StringToField(flePROPERTY_YEARS.GetStringValue("BEDS")));
                m_strWhere.Append(" AND ").Append(" ").Append(flePROPERTY_YEARS_DTL.ElementOwner("PROPERTY_STYLE")).Append(" = ");
                m_strWhere.Append(Common.StringToField(flePROPERTY_YEARS.GetStringValue("PROPERTY_STYLE")));
                m_strWhere.Append(" AND ").Append(" ").Append(flePROPERTY_YEARS_DTL.ElementOwner("BATHROOMS")).Append(" = ");
                m_strWhere.Append(Common.StringToField(flePROPERTY_YEARS.GetStringValue("BATHROOMS")));
                m_strWhere.Append(" AND ").Append(" ").Append(flePROPERTY_YEARS_DTL.ElementOwner("PROPERTY_ID")).Append(" = ");
                m_strWhere.Append(Common.StringToField(flePROPERTY_YEARS.GetStringValue("PROPERTY_ID")));
                m_strWhere.Append(" AND ").Append(" ").Append(flePROPERTY_YEARS_DTL.ElementOwner("YEAR")).Append(" = ");
                m_strWhere.Append(Common.StringToField(flePROPERTY_YEARS.GetStringValue("YEAR")));
                flePROPERTY_YEARS_DTL.GetData(m_strWhere.ToString(), GetDataOptions.ForOccurence);

                // --> End GET PROPERTY_YEARS <--
                T_START_DAYS.Value = QDesign.Days(T_START_DATE.Value);
                T_END_DAYS.Value = QDesign.Days(T_END_DATE.Value);





                while (this.For(53))
                {


                    if (QDesign.NULL(D_IN_RANGE.Value) == "Y")
                    {
                        T_BOOK_DAYS.Value = QDesign.Days(fleBOOKING_PERIODS_DTL.GetDecimalValue("START_DATE"));
                        if (QDesign.NULL(D_DAY_1_OK.Value) != "Y")
                        {
                            //FileSystem.Unlock(flePROPERTY_YEARS);
                            Severe("52027");
                        }
                        if (QDesign.NULL(D_DAY_2_OK.Value) != "Y")
                        {
                            //FileSystem.Unlock(flePROPERTY_YEARS);
                            Severe("52028");
                        }
                        if (QDesign.NULL(D_DAY_3_OK.Value) != "Y")
                        {
                            //FileSystem.Unlock(flePROPERTY_YEARS);
                            Severe("52029");
                        }
                        if (QDesign.NULL(D_DAY_4_OK.Value) != "Y")
                        {
                            //FileSystem.Unlock(flePROPERTY_YEARS);
                            Severe("52030");
                        }
                        if (QDesign.NULL(D_DAY_5_OK.Value) != "Y")
                        {
                            //FileSystem.Unlock(flePROPERTY_YEARS);
                            Severe("52031");
                        }
                        if (QDesign.NULL(D_DAY_6_OK.Value) != "Y")
                        {
                            //FileSystem.Unlock(flePROPERTY_YEARS);
                            Severe("52032");
                        }
                        if (QDesign.NULL(D_DAY_7_OK.Value) != "Y")
                        {
                            //FileSystem.Unlock(flePROPERTY_YEARS);
                            Severe("52033");
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


        private bool Internal_CHECK_SET_LINKED()
        {


            try
            {

                object[] arrRunscreen = { flePROPERTY_YEARS, fleBOOKING_PERIODS, T_START_DATE, T_END_DATE, T_ERROR_FLAG, T_UPDATE_LINKED, T_CALLING_SCREEN };
                RunScreen(new BOOKLINK(), RunScreenModes.NoneSelected, ref arrRunscreen);
                if (QDesign.NULL(T_ERROR_FLAG.Value) == "Y")
                {
                    Severe("52034");
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


        private bool Internal_SET_PFIA_OFFER()
        {


            try
            {

                T_PFIA_DEPOSIT.Value = "N";
                if (QDesign.NULL(T_DUE_NOW.Value) != "Y" && QDesign.NULL(D_POINTS_WEEKS.Value) < QDesign.NULL(D_WEEKS.Value) && (QDesign.NULL(flePROPERTIES.GetStringValue("GROUPING")) == "BOND" || QDesign.NULL(flePROPERTIES.GetStringValue("GROUPING")) == "FISH") && QDesign.NULL(fleM_INVESTORS.GetStringValue("INVESTOR")) != "00006" && QDesign.NULL(fleM_INVESTORS.GetStringValue("INVESTOR")) != "00007" && QDesign.NULL(fleM_INVESTORS.GetStringValue("INVESTOR")) != "00012" && QDesign.NULL(fleM_INVESTORS.GetStringValue("INVESTOR")) != "00015" && QDesign.NULL(fleM_INVESTORS.GetStringValue("INVESTOR")) != "00038")
                {
                    if (QDesign.NULL(UserID) == "nick" || QDesign.NULL(UserID) == "manger" || QDesign.NULL(UserID) == "martin")
                    {
                        Warning("32002");
                        Accept(ref fldT_PFIA_DEPOSIT);
                    }
                    else
                    {
                        T_PFIA_DEPOSIT.Value = "Y";
                        Information("POINTS-FREE IN ADVANCE - A �30 p/w deposit will be required");
                        // TODO: May need to fix manually
                    }
                }
                Display(ref fldD_DUE_NOW);

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


        private bool Internal_SET_BOGOF_OFFER()
        {


            try
            {

                T_BOGOF_DEPOSIT.Value = "N";
                if (QDesign.NULL(T_DUE_NOW.Value) != "Y" && QDesign.NULL(fleBOOKINGS.GetStringValue("LONG_STAY")) != "Y" && (QDesign.NULL(flePROPERTIES.GetStringValue("GROUPING")) == "BOND" || QDesign.NULL(flePROPERTIES.GetStringValue("GROUPING")) == "FISH") && QDesign.NULL(fleM_INVESTORS.GetStringValue("INVESTOR")) != "00006" && QDesign.NULL(fleM_INVESTORS.GetStringValue("INVESTOR")) != "00007" && QDesign.NULL(fleM_INVESTORS.GetStringValue("INVESTOR")) != "00012" && QDesign.NULL(fleM_INVESTORS.GetStringValue("INVESTOR")) != "00015" && QDesign.NULL(fleM_INVESTORS.GetStringValue("INVESTOR")) != "00038" && (((QDesign.NULL(flePROPERTY_YEARS.GetStringValue("LOCATION")) == "BB" || QDesign.NULL(flePROPERTY_YEARS.GetStringValue("LOCATION")) == "BC" || QDesign.NULL(flePROPERTY_YEARS.GetStringValue("LOCATION")) == "DM" || QDesign.NULL(flePROPERTY_YEARS.GetStringValue("LOCATION")) == "HL" || QDesign.NULL(flePROPERTY_YEARS.GetStringValue("LOCATION")) == "LH" || QDesign.NULL(flePROPERTY_YEARS.GetStringValue("LOCATION")) == "LY" || QDesign.NULL(flePROPERTY_YEARS.GetStringValue("LOCATION")) == "MD" || QDesign.NULL(flePROPERTY_YEARS.GetStringValue("LOCATION")) == "SB" || QDesign.NULL(flePROPERTY_YEARS.GetStringValue("LOCATION")) == "SK" || QDesign.NULL(flePROPERTY_YEARS.GetStringValue("LOCATION")) == "TT") && ((T_START_DATE.Value >= 20121119 && T_START_DATE.Value <= 20121216) || (T_START_DATE.Value >= 20130102 && T_START_DATE.Value <= 20130210) || (T_START_DATE.Value >= 20131118 && T_START_DATE.Value <= 20131215) || (T_START_DATE.Value >= 20140102 && T_START_DATE.Value <= 20140209))) || (QDesign.NULL(flePROPERTY_YEARS.GetStringValue("LOCATION")) == "GM" && ((T_START_DATE.Value >= 20121105 && T_START_DATE.Value <= 20121216) || (T_START_DATE.Value >= 20121231 && T_START_DATE.Value <= 20130224))) || ((QDesign.NULL(flePROPERTY_YEARS.GetStringValue("LOCATION")) == "CO" || QDesign.NULL(flePROPERTY_YEARS.GetStringValue("LOCATION")) == "SS" || QDesign.NULL(flePROPERTY_YEARS.GetStringValue("LOCATION")) == "ST" || QDesign.NULL(flePROPERTY_YEARS.GetStringValue("LOCATION")) == "MR" || QDesign.NULL(flePROPERTY_YEARS.GetStringValue("LOCATION")) == "RB" || QDesign.NULL(flePROPERTY_YEARS.GetStringValue("LOCATION")) == "AL" || QDesign.NULL(flePROPERTY_YEARS.GetStringValue("LOCATION")) == "BN" || QDesign.NULL(flePROPERTY_YEARS.GetStringValue("LOCATION")) == "PV") && T_START_DATE.Value >= 20121105 && T_START_DATE.Value <= 20130224) || ((QDesign.NULL(flePROPERTY_YEARS.GetStringValue("LOCATION")) == "SS" || QDesign.NULL(flePROPERTY_YEARS.GetStringValue("LOCATION")) == "MR" || QDesign.NULL(flePROPERTY_YEARS.GetStringValue("LOCATION")) == "RB" || QDesign.NULL(flePROPERTY_YEARS.GetStringValue("LOCATION")) == "AL" || QDesign.NULL(flePROPERTY_YEARS.GetStringValue("LOCATION")) == "BN") && T_START_DATE.Value >= 20131104 && T_START_DATE.Value <= 20140223) || (QDesign.NULL(flePROPERTY_YEARS.GetStringValue("LOCATION")) == "PV" && T_START_DATE.Value >= 20131104 && T_START_DATE.Value <= 20131110) || (QDesign.NULL(flePROPERTY_YEARS.GetStringValue("LOCATION")) == "ST" && T_START_DATE.Value >= 20131104 && T_START_DATE.Value <= 20131127) || (QDesign.NULL(flePROPERTY_YEARS.GetStringValue("LOCATION")) == "GM" && QDesign.NULL(D_START_DOW.Value) == "TUE" && ((T_START_DATE.Value >= 20130504 && T_START_DATE.Value <= 20130625) || (T_START_DATE.Value >= 20131105 && T_START_DATE.Value <= 20131215) || (T_START_DATE.Value >= 20140506 && T_START_DATE.Value <= 20140624)))))
                {
                    if (QDesign.NULL(fleBOOKINGS.GetDecimalValue("POINTS_ADJUST")) > 0 && QDesign.NULL(fleBOOKINGS.GetDecimalValue("POINTS_ADJUST")) == QDesign.NULL(D_POINTS.Value) && QDesign.NULL(D_NET_POINTS.Value) == 0)
                    {
                        if (QDesign.NULL(UserID) == "nick" || QDesign.NULL(UserID) == "manger" || QDesign.NULL(UserID) == "martin")
                        {
                            Warning("32003");
                            Accept(ref fldT_BOGOF_DEPOSIT);
                        }
                        else
                        {
                            T_BOGOF_DEPOSIT.Value = "Y";
                            Information("42004");
                        }
                    }
                    if (QDesign.NULL(fleBOOKINGS.GetDecimalValue("POINTS_ADJUST")) > 0 && QDesign.NULL(D_NET_POINTS.Value) > 0)
                    {
                        Warning("32004");
                        Accept(ref fldT_BOGOF_DEPOSIT);
                        if (QDesign.NULL(T_BOGOF_DEPOSIT.Value) == "Y")
                        {
                            T_BOGOF_DEPOSIT.Value = "1";
                            Warning("32005");
                        }
                    }
                }
                Display(ref fldD_DUE_NOW);

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



        private void fldT_START_WEEK_Edit()
        {

            try
            {

                if (QDesign.NULL(T_START_WEEK.Value) < QDesign.NULL(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_1")) && QDesign.NULL(T_START_WEEK.Value) != 0)
                {
                    ErrorMessage("52035");
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



        private void fldT_END_WEEK_Input()
        {

            try
            {

                if (0 == FieldText.Length)
                {
                    FieldText = QDesign.ASCII(M_END_PERIOD.Value, 2);
                }
                if (2 != FieldText.Length)
                {
                    FieldText = QDesign.ASCII(QDesign.NConvert(FieldText), 2);
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



        private void fldT_END_WEEK_Edit()
        {

            try
            {

                if (QDesign.NULL(D_CONVERT_FIELD.Value) < QDesign.NULL(T_START_WEEK.Value))
                {
                    ErrorMessage("52036");
                }
                if (QDesign.NULL(D_CONVERT_FIELD.Value) > QDesign.NULL(T_START_WEEK.Value + 6))
                {
                    ErrorMessage("52037");
                }
                if (QDesign.NULL(T_END_WEEK.Value) > QDesign.NULL(D_LAST_PERIOD.Value))
                {
                    ErrorMessage("52038");
                }
                Internal_CHECK_WEEKS_FREE();
                // --> GET LOCN_BK_COMMENTS <--
                fleLOCN_BK_COMMENTS.GetData();
                // --> End GET LOCN_BK_COMMENTS <--
                Display(ref fldLOCN_BK_COMMENTS_BK_COMMENT_1);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldT_START_DATE_Edit()
        {

            try
            {

                if (QDesign.NULL(T_START_DATE.Value) < QDesign.NULL(D_SCREEN_START.Value))
                {
                    ErrorMessage("52039");
                }
                if (QDesign.NULL(T_START_DATE.Value) > QDesign.NULL(D_SCREEN_END.Value))
                {
                    ErrorMessage("52040");
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



        private void fldT_START_DATE_Process()
        {

            try
            {

                if (QDesign.NULL(fleSCREEN_PROPERTY.GetStringValue("LOCATION")) == "KA" && 0 == QDesign.NULL(QDesign.PHMod(QDesign.Days(T_START_DATE.Value), 7)))
                {
                    ErrorMessage("52041");
                }
                if (QDesign.NULL(fleSCREEN_PROPERTY.GetStringValue("LOCATION")) == "IH" && 0 == QDesign.NULL(QDesign.PHMod(QDesign.Days(T_START_DATE.Value), 7)))
                {
                    ErrorMessage("52042");
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



        private void fldT_END_DATE_Input()
        {

            try
            {

                T_USER_CHARGE_TOT.Value = 0;
                T_TOTAL_DAYS.Value = 0;
                T_WEEK.Value = 0;
                T_TOTAL_WEEKLY_RATE.Value = 0;
                T_POINTS_1.Value = 0;
                T_POINTS_2.Value = 0;
                T_POINTS_3.Value = 0;
                T_POINTS_4.Value = 0;
                T_POINTS_5.Value = 0;
                T_POINTS_6.Value = 0;
                T_POINTS_7.Value = 0;
                //#CORE_BEGIN_INCLUDE: DATECENT.USE"

                //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
                //# Do not delete, modify or move it.  Updated: 07/12/2013 1:49:48 PM

                if (6 == FieldText.Length)
                {
                    if (string.Compare(QDesign.NULL(QDesign.Substring(FieldText, 5, 2)), QDesign.NULL("69")) < 0)
                    {
                        FieldText = QDesign.Substring(FieldText, 1, 4) + "20" + QDesign.Substring(FieldText, 5, 2);
                    }
                    else
                    {
                        FieldText = QDesign.Substring(FieldText, 1, 4) + "19" + QDesign.Substring(FieldText, 5, 2);
                    }
                }

                //#CORE_END_INCLUDE: DATECENT.USE"




            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldT_END_DATE_Edit()
        {

            try
            {

                if (QDesign.NULL(T_END_DATE.Value) < QDesign.NULL(T_START_DATE.Value))
                {
                    ErrorMessage("52043");
                }
                if (QDesign.NULL(T_END_DATE.Value) > QDesign.NULL(QDesign.PhDate(QDesign.Days(T_START_DATE.Value) + 41)))
                {
                    ErrorMessage("52044");
                }
                if (QDesign.NULL(T_END_DATE.Value) > QDesign.NULL(D_SCREEN_END.Value))
                {
                    ErrorMessage("52045");
                }
                Internal_RECHECK_AVAILABILITY();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldBOOKINGS_BOOKING_CHARGE_Process()
        {

            try
            {

                Internal_CALC_VAT();
                Display(ref fldD_DUE_NOW);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldBOOKINGS_POINTS_ADJUST_Process()
        {

            try
            {

                Display(ref fldD_NET_POINTS);
                Display(ref fldD_POINTS_BALANCE);
                Display(ref fldD_SUBTOTAL);
                Display(ref fldD_PURC_MAX);
                Display(ref fldD_OD_MAX);
                fleBOOKINGS.set_SetValue("BK_FORF_POINTS", D_FORF_POINTS.Value);
                Display(ref fldD_FORF_BAL);
                Display(ref fldD_AVAILABLE);
                Display(ref fldD_PP_SURCHARGE);
                if (QDesign.NULL(D_FORF_BAL.Value) > 0 && QDesign.NULL(D_FORF_POINTS.Value) > 0)
                {
                    Warning(D_FORF_MESSAGE.Value);
                    // TODO: May need to fix manually
                }
                Internal_SET_BOGOF_OFFER();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_09_Click(object sender, System.EventArgs e)
        {

            try
            {

                Information("42005");
                Accept(ref fldBOOKINGS_LONG_STAY);
                if (QDesign.NULL(fleBOOKINGS.GetStringValue("LONG_STAY")) == "Y")
                {
                    Information("42006");
                }
                if (QDesign.NULL(fleBOOKINGS.GetStringValue("LONG_STAY")) == "S")
                {
                    Information("42007");
                }
                Internal_SET_BOGOF_OFFER();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldBOOKINGS_LONG_STAY_Process()
        {

            try
            {

                if (QDesign.NULL(fleBOOKINGS.GetStringValue("LONG_STAY")) == "S")
                {
                    T_FIXED_DEBT.Value = "Y";
                    Display(ref fldT_FIXED_DEBT);
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


        private bool Internal_GET_ENTITLEMENTS()
        {


            try
            {

                T_HOLIDAY_YEAR.Value = D_HOLIDAY_YEAR.Value;
                T_PREVIOUS_YEAR.Value = D_PREVIOUS_YEAR.Value;
                T_FOLLOWING_YEAR.Value = D_FOLLOWING_YEAR.Value;
                // --> GET CURRENT_ENTS <--

                fleCURRENT_ENTS.GetData(GetDataOptions.IsOptional);
                // --> End GET CURRENT_ENTS <--
                if (!AccessOk)
                {
                    ErrorMessage("Missing record on CURRENT-ENTS " + QDesign.NULL(fleM_INVESTORS.GetStringValue("INVESTOR")) + T_HOLIDAY_YEAR.Value);
                    // TODO: May need to fix manually
                }
                if (QDesign.NULL(fleCURRENT_ENTS.GetStringValue("YEAR_123")) != "01")
                {
                    // --> GET PREVIOUS_ENT <--

                    flePREVIOUS_ENT.GetData(GetDataOptions.IsOptional);
                    // --> End GET PREVIOUS_ENT <--
                    if (!AccessOk)
                    {
                        ErrorMessage("Missing record on PREVIOUS-ENT " + QDesign.NULL(fleM_INVESTORS.GetStringValue("INVESTOR")) + T_PREVIOUS_YEAR.Value);
                        // TODO: May need to fix manually
                    }
                }
                if (QDesign.NULL(fleCURRENT_ENTS.GetStringValue("YEAR_123")) != "03")
                {
                    // --> GET FOLLOWING_ENT <--

                    fleFOLLOWING_ENT.GetData(GetDataOptions.IsOptional);
                    // --> End GET FOLLOWING_ENT <--
                    if (!AccessOk)
                    {
                        ErrorMessage("Missing record on FOLLOWING-ENT " + QDesign.NULL(fleM_INVESTORS.GetStringValue("INVESTOR")) + T_HOLIDAY_YEAR.Value);
                        // TODO: May need to fix manually
                    }
                }
                // --> GET SUSP_ACCOUNT <--

                fleSUSP_ACCOUNT.GetData(GetDataOptions.IsOptional);
                // --> End GET SUSP_ACCOUNT <--
                // --> GET FORF_ACCOUNT <--
                m_strWhere = new StringBuilder(" WHERE ");
                m_strWhere.Append(" ").Append(fleFORF_ACCOUNT.ElementOwner("INVESTOR")).Append(" = ");
                m_strWhere.Append(Common.StringToField(fleM_INVESTORS.GetStringValue("INVESTOR")));

                fleFORF_ACCOUNT.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                // --> End GET FORF_ACCOUNT <--

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


        private bool Internal_ASSIGN_POINTS()
        {


            try
            {

                if (D_USE_FIRST.Value >= D_NET_POINTS_ENT.Value)
                {
                    if (QDesign.NULL(fleCURRENT_ENTS.GetStringValue("YEAR_123")) == "01" && fleCURRENT_ENTS.GetDecimalValue("BF_BAL") >= D_NET_POINTS_ENT.Value)
                    {
                        fleBOOKINGS.set_SetValue("BK_BF_EOY", D_NET_POINTS_ENT.Value);
                    }
                    if (QDesign.NULL(fleCURRENT_ENTS.GetStringValue("YEAR_123")) != "01" && fleCURRENT_ENTS.GetDecimalValue("ENTITLEMENT_BAL") >= D_NET_POINTS_ENT.Value)
                    {
                        fleBOOKINGS.set_SetValue("BK_ENTITLEMENT", D_NET_POINTS_ENT.Value);
                    }
                }
                else
                {
                    if (D_AVAILABLE.Value >= D_NET_POINTS_ENT.Value)
                    {
                        if (QDesign.NULL(fleCURRENT_ENTS.GetStringValue("YEAR_123")) == "01")
                        {
                            fleBOOKINGS.set_SetValue("BK_BF_EOY", fleCURRENT_ENTS.GetDecimalValue("BF_BAL"));
                            fleBOOKINGS.set_SetValue("BK_ENTITLEMENT", D_NET_POINTS.Value - fleBOOKINGS.GetDecimalValue("BK_BF_EOY"));
                        }
                        else
                        {
                            fleBOOKINGS.set_SetValue("BK_ENTITLEMENT", fleCURRENT_ENTS.GetDecimalValue("ENTITLEMENT_BAL"));
                            fleBOOKINGS.set_SetValue("BK_BF_TRANSFER", D_NET_POINTS_ENT.Value - fleCURRENT_ENTS.GetDecimalValue("ENTITLEMENT_BAL"));
                        }
                    }
                    else
                    {
                        if (QDesign.NULL(D_AVAILABLE.Value) < QDesign.NULL(D_NET_POINTS_ENT.Value))
                        {
                            fleBOOKINGS.set_SetValue("BK_ENTITLEMENT", fleCURRENT_ENTS.GetDecimalValue("ENTITLEMENT_BAL"));
                            if (QDesign.NULL(fleCURRENT_ENTS.GetStringValue("YEAR_123")) == "01")
                            {
                                fleBOOKINGS.set_SetValue("BK_BF_EOY", fleCURRENT_ENTS.GetDecimalValue("BF_BAL"));
                            }
                            else
                            {
                                fleBOOKINGS.set_SetValue("BK_BF_TRANSFER", flePREVIOUS_ENT.GetDecimalValue("ENTITLEMENT_BAL"));
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


        private bool Internal_ENTRY_PROCEDURE()
        {


            try
            {

                Accept(ref fldT_START_WEEK);
                fleBOOKINGS.set_SetValue("CONFIRM_DATE", D_CONFIRM_DATE.Value);
                Internal_GET_ENTITLEMENTS();
                if (QDesign.NULL(T_START_WEEK.Value) != 0)
                {
                    Accept(ref fldT_END_WEEK);
                    if (QDesign.NULL(T_START_DATE.Value) < QDesign.NULL(QDesign.SysDate(ref m_cnnQUERY)) && QDesign.NULL(fleUSER_SEC_FILE.GetStringValue("USER_LEVEL")) == "01")
                    {
                        Information("42008");
                    }
                    Internal_SET_DATES();
                    Internal_CHECK_WEB_DATA();
                    Display(ref fldT_START_DATE);
                    Display(ref fldT_END_DATE);
                    Display(ref fldD_PROP_COMM);
                    Display(ref fldD_ON_REQUEST);
                    Display(ref fldD_ON_REQUEST_DATE);
                    T_HOLIDAY_YEAR.Value = D_HOLIDAY_YEAR.Value;
                    T_PREVIOUS_YEAR.Value = D_PREVIOUS_YEAR.Value;
                    T_FOLLOWING_YEAR.Value = D_FOLLOWING_YEAR.Value;
                    Internal_GET_CHARGES_BPERIODS();
                    Internal_CALC_UCHARGE_POINTS();
                    Internal_DISPLAY_CHARGES();
                }
                if (QDesign.NULL(T_START_WEEK.Value) == 0)
                {
                    Accept(ref fldT_START_DATE);
                    Accept(ref fldT_END_DATE);
                    if (QDesign.NULL(T_START_DATE.Value) < QDesign.NULL(QDesign.SysDate(ref m_cnnQUERY)) && QDesign.NULL(fleUSER_SEC_FILE.GetStringValue("USER_LEVEL")) == "01")
                    {
                        Information("42009");
                    }
                    Internal_CHECK_DATES_FREE();
                    if (QDesign.NULL(T_ERROR_FLAG.Value) == "Y")
                    {
                        Severe("52046");
                    }
                    Internal_CHECK_WEB_DATA();
                    T_HOLIDAY_YEAR.Value = D_HOLIDAY_YEAR.Value;
                    T_FOLLOWING_YEAR.Value = D_FOLLOWING_YEAR.Value;
                    Internal_GET_CHARGES_BPERIODS();
                    Internal_CHARGE_BY_DATE();
                    if (QDesign.NULL(D_UNDER_A_WEEK.Value) == "Y" && QDesign.NULL(T_WEEK.Value) == 2)
                    {
                        T_USER_CHARGE_TOT.Value = T_USER_CHARGE_TOT.Value + ((D_RATE.Value * (T_TOTAL_WEEKLY_RATE.Value / 2)) / 100);
                    }
                    else
                    {
                        if (QDesign.NULL(D_UNDER_A_WEEK.Value) == "Y" && QDesign.NULL(T_WEEK.Value) == 1)
                        {
                            T_USER_CHARGE_TOT.Value = T_USER_CHARGE_TOT.Value + ((D_RATE.Value * T_TOTAL_WEEKLY_RATE.Value) / 100);
                        }
                    }
                }
                // --> GET LOCN_BK_COMMENTS <--

                fleLOCN_BK_COMMENTS.GetData(GetDataOptions.IsOptional);
                // --> End GET LOCN_BK_COMMENTS <--
                Display(ref fldLOCN_BK_COMMENTS_BK_COMMENT_1);
                // --> GET PROP_BK_COMMENTS <--
                flePROP_BK_COMMENTS.GetData();
                // --> End GET PROP_BK_COMMENTS <--
                if ((QDesign.NULL(flePROP_BK_COMMENTS.GetStringValue("BK_COMMENT_2")) != QDesign.NULL(" ") || QDesign.NULL(flePROP_BK_COMMENTS.GetStringValue("BK_COMMENT_1")) != QDesign.NULL(" ") || (QDesign.NULL(fleLOCN_BK_COMMENTS.GetStringValue("BK_COMMENT_2")) != QDesign.NULL(" ") && (QDesign.NULL(fleLOCN_BK_COMMENTS.GetStringValue("BK_COMMENT_2")) != QDesign.NULL(fleBOOK0100_COMM.GetStringValue("BK_COMMENT_2")) || QDesign.NULL(fleLOCN_BK_COMMENTS.GetStringValue("BK_COMMENT_3")) != QDesign.NULL(fleBOOK0100_COMM.GetStringValue("BK_COMMENT_3"))))))
                {
                    //RunScreen("BOOK0400.QKC", RunScreenModes.Find, T_BOOKING_REF, T_START_DATE, T_END_DATE, flePROP_BK_COMMENTS, fleLOCN_BK_COMMENTS);

                }
                Internal_GET_ENTITLEMENTS();
                if (QDesign.NULL(D_FORF_QUALIFIED.Value) == "Y" && QDesign.NULL(fleM_INVESTORS.GetStringValue("COLOUR")) == "S" && QDesign.NULL(D_FORF_POINTS.Value) > 0)
                {
                    Information("** Enter `Y` to use 70-day account points, or `N` to not use them **");
                    // TODO: May need to fix manually
                    Accept(ref fldT_USE_FORF_BAL);
                }
                if (QDesign.NULL(D_FORF_QUALIFIED.Value) == "Y" && QDesign.NULL(fleM_INVESTORS.GetStringValue("COLOUR")) == "S" && QDesign.NULL(D_FORF_POINTS.Value) == 0)
                {
                    T_USE_FORF_BAL.Value = "N";
                }
                if (QDesign.NULL(fleM_INVESTORS.GetStringValue("COLOUR")) == "S" && QDesign.NULL(D_POINTS_FREE.Value) != "Y" && QDesign.NULL(flePROPERTIES.GetStringValue("RENTED_Y_N")) == "Y")
                {
                    fleBOOKINGS.set_SetValue("POINTS_ADJUST", ((D_NET_POINTS.Value - fleBOOKINGS.GetDecimalValue("BK_FORF_POINTS")) / 3));
                    Display(ref fldBOOKINGS_POINTS_ADJUST);
                }
                Internal_DISPLAY_CHARGES();
                if (QDesign.NULL(fleM_INVESTORS.GetStringValue("COLOUR")) != "S")
                {
                    Internal_SET_USER_CHARGE();
                    Internal_CALC_VAT();
                }
                if (QDesign.NULL(fleM_INVESTORS.GetStringValue("COLOUR")) != QDesign.NULL(" "))
                {
                    fleBOOKINGS.set_SetValue("LOCATION", flePROPERTY_YEARS.GetStringValue("LOCATION"));
                }
                if (QDesign.NULL(fleM_INVESTORS.GetStringValue("COLOUR")) == "S" && (QDesign.NULL(D_POINTS_FREE.Value) == "Y" || QDesign.NULL(flePROPERTIES.GetStringValue("RENTED_Y_N")) == "Y" || QDesign.NULL(fleBOOKINGS.GetDecimalValue("BOOKING_POINTS")) == 0 || QDesign.NULL(D_USE_FORF_BAL.Value) == "Y"))
                {
                    Internal_SET_USER_CHARGE();
                }
                if (QDesign.NULL(T_START_WEEK.Value) != 0)
                {
                    Display(ref fldT_START_DATE);
                    Display(ref fldT_END_DATE);
                }
                if ((QDesign.NULL(flePROPERTIES.GetStringValue("GROUPING")) == "SHHT" || QDesign.NULL(flePROPERTIES.GetStringValue("GROUPING")) == "SHHL" || QDesign.NULL(flePROPERTIES.GetStringValue("DEPOSIT_REQUIRED")) == "Y") && QDesign.NULL(fleBOOKINGS.GetDecimalValue("BOOKING_CHARGE")) > 0)
                {
                    Display(ref fldD_DUE_NOW);
                    Information(D_DUE_NOW_TEXT.Value);
                    // TODO: May need to fix manually
                }
                if (D_DAYS_DIFF.Value <= D_PAY_TIME.Value && QDesign.NULL(fleBOOKINGS.GetDecimalValue("BOOKING_CHARGE")) > 0)
                {
                    T_DUE_NOW.Value = "Y";
                    Display(ref fldD_DUE_NOW_MESSAGE);
                }
                else
                {
                    T_DUE_NOW.Value = "N";
                    Display(ref fldD_DUE_NOW_MESSAGE);
                }
                Internal_SET_PFIA_OFFER();
                Internal_SET_BOGOF_OFFER();

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


        private bool Internal_CREATE_PURCHASE()
        {


            try
            {

                flePURCHASE_DEBTS.set_SetValue("DEBT_POINTS", fleBOOKINGS.GetDecimalValue("BK_PURCHASE"));
                flePURCHASE_DEBTS.set_SetValue("DEBT_AMOUNT", D_PURCHASE.Value);

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

                //FileSystem.Lock(fleLOCATIONS);
                // --> GET LOCATIONS <--
                m_strWhere = new StringBuilder(" WHERE ");
                m_strWhere.Append(" ").Append(fleLOCATIONS.ElementOwner("LOCATION")).Append(" = ");
                m_strWhere.Append(Common.StringToField(flePROPERTY_YEARS.GetStringValue("LOCATION")));

                fleLOCATIONS.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                // --> End GET LOCATIONS <--
                if (!AccessOk)
                {
                    Severe("52047");
                }
                fleLOCATIONS.set_SetValue("BOOKING_NO", fleLOCATIONS.GetDecimalValue("BOOKING_NO") + 1);
                fleBOOKINGS.set_SetValue("BOOKING_REF", fleLOCATIONS.GetStringValue("LOCATION") + D_BOOKING_NO.Value);
                T_BOOKING_REF.Value = fleBOOKINGS.GetStringValue("BOOKING_REF");
                X_BOOKING_REF.Value = fleBOOKINGS.GetStringValue("BOOKING_REF");
                T_AREA.Value = fleLOCATIONS.GetStringValue("AREA");
                fleLOCATIONS.PutData();
                //FileSystem.Unlock(fleLOCATIONS);

                SCREEN_PROPERTY_PROPERTY_CODE.Value = fleSCREEN_PROPERTY.GetStringValue("LOCATION") + fleSCREEN_PROPERTY.GetStringValue("BEDS") + fleSCREEN_PROPERTY.GetStringValue("PROPERTY_STYLE").PadRight(2, ' ') +
                  fleSCREEN_PROPERTY.GetStringValue("BATHROOMS") + "-" + fleSCREEN_PROPERTY.GetStringValue("PROPERTY_ID");

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


        protected override bool Entry()
        {


            try
            {

                // --> GET LOCATIONS <--
                m_strWhere = new StringBuilder(" WHERE ");
                m_strWhere.Append(" ").Append(fleLOCATIONS.ElementOwner("LOCATION")).Append(" = ");
                m_strWhere.Append(Common.StringToField(flePROPERTY_YEARS.GetStringValue("LOCATION")));

                fleLOCATIONS.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                // --> End GET LOCATIONS <--
                // --> GET ANNUAL_ENT <--
                m_strWhere = new StringBuilder(" WHERE ");
                m_strWhere.Append(" ").Append(fleANNUAL_ENT.ElementOwner("INVESTOR")).Append(" = ");
                m_strWhere.Append(Common.StringToField(fleM_INVESTORS.GetStringValue("INVESTOR")));

                fleANNUAL_ENT.GetData(m_strWhere.ToString());
                // --> End GET ANNUAL_ENT <--
                // --> GET INVESTMENTS <--
                m_strWhere = new StringBuilder(" WHERE ");
                m_strWhere.Append(" ").Append(fleINVESTMENTS.ElementOwner("INVESTOR")).Append(" = ");
                m_strWhere.Append(Common.StringToField(fleM_INVESTORS.GetStringValue("INVESTOR")));

                fleINVESTMENTS.GetData(m_strWhere.ToString());
                // --> End GET INVESTMENTS <--
                Display(ref fldINVESTMENTS_QUALIFY_28DAY);
                Internal_SET_DATES();
                if (QDesign.NULL(D_PROP_COMM.Value) != QDesign.NULL(" "))
                {
                    Display(ref fldD_PROP_COMM);
                }
                Display(ref fldLOCN_BK_COMMENTS_BK_COMMENT_1);

                Internal_ENTRY_PROCEDURE();
                Display(ref fldD_PP_SURCHARGE);
                Display(ref fldD_PP_FLAG);
                if (QDesign.NULL(QDesign.Substring(flePROPERTIES.GetStringValue("GROUPING"), 1, 3)) == "SHH")
                {
                    T_FIXED_DEBT.Value = "Y";
                    Display(ref fldT_FIXED_DEBT);
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

                if (QDesign.NULL(fleM_INVESTORS.GetStringValue("COLOUR")) == "S" && QDesign.NULL(D_NET_POINTS.Value) == 0 && QDesign.NULL(fleBOOKINGS.GetDecimalValue("BOOKING_CHARGE")) == 0 && QDesign.NULL(fleBOOKINGS.GetStringValue("USER_LOGON")) != "nick" && QDesign.NULL(fleBOOKINGS.GetStringValue("USER_LOGON")) != "manger" && QDesign.NULL(QDesign.Substring(fleM_INVESTORS.GetStringValue("INVESTOR"), 1, 3)) != "999")
                {
                    ErrorMessage("52048");
                }
                if (QDesign.NULL(T_START_DATE.Value) < QDesign.NULL(QDesign.SysDate(ref m_cnnQUERY)) && QDesign.NULL(fleUSER_SEC_FILE.GetStringValue("USER_LEVEL")) != "01")
                {
                    ErrorMessage("52049");
                }
                Internal_CHECK_DATES_FREE();
                if (QDesign.NULL(T_ERROR_FLAG.Value) == "Y")
                {
                    Severe("52050");
                }
                Internal_CHECK_SET_LINKED();


                while (this.For(53))
                {


                    if ((T_START_DATE.Value >= fleBOOKING_PERIODS_DTL.GetDecimalValue("START_DATE") && T_START_DATE.Value <= fleBOOKING_PERIODS_DTL.GetDecimalValue("END_DATE")))
                    {
                        T_START_WEEK.Value = Occurrence;
                    }
                    if ((T_END_DATE.Value >= fleBOOKING_PERIODS_DTL.GetDecimalValue("START_DATE") && T_END_DATE.Value <= fleBOOKING_PERIODS_DTL.GetDecimalValue("END_DATE")))
                    {
                        T_END_WEEK.Value = Occurrence;
                    }
                }
                if (((QDesign.NULL(fleBOOKINGS.GetStringValue("LOCATION")) != "TR" && QDesign.NULL(fleBOOKINGS.GetStringValue("LOCATION")) != "VB" && QDesign.NULL(fleBOOKINGS.GetStringValue("LOCATION")) != "RG" && QDesign.NULL(fleBOOKINGS.GetStringValue("USER_LOGON")) != "manger" && QDesign.NULL(fleBOOKINGS.GetStringValue("USER_LOGON")) != "nick" && QDesign.NULL(fleBOOKINGS.GetStringValue("USER_LOGON")) != "rob" && QDesign.NULL(fleBOOKINGS.GetStringValue("USER_LOGON")) != "martin" && QDesign.NULL(fleBOOKINGS.GetStringValue("USER_LOGON")) != "pippa" && QDesign.NULL(fleBOOKINGS.GetStringValue("USER_LOGON")) != "ingrid" && QDesign.NULL(fleBOOKINGS.GetStringValue("USER_LOGON")) != "marina" && QDesign.NULL(fleBOOKINGS.GetStringValue("USER_LOGON")) != "lesley" && QDesign.NULL(fleBOOKINGS.GetStringValue("USER_LOGON")) != "sally" && QDesign.NULL(fleBOOKINGS.GetStringValue("USER_LOGON")) != "theme" && QDesign.NULL(fleBOOKINGS.GetStringValue("USER_LOGON")) != "hayleyd" && QDesign.NULL(fleBOOKINGS.GetStringValue("USER_LOGON")) != "wendy" && QDesign.NULL(fleBOOKINGS.GetStringValue("USER_LOGON")) != "suec") || (QDesign.NULL(fleBOOKINGS.GetStringValue("LOCATION")) == "TR" && QDesign.NULL(fleBOOKINGS.GetStringValue("USER_LOGON")) != "hazel" && QDesign.NULL(fleBOOKINGS.GetStringValue("USER_LOGON")) != "theme" && QDesign.NULL(fleBOOKINGS.GetStringValue("USER_LOGON")) != "manger" && QDesign.NULL(fleBOOKINGS.GetStringValue("USER_LOGON")) != "nick" && QDesign.NULL(fleBOOKINGS.GetStringValue("USER_LOGON")) != "rob" && QDesign.NULL(fleBOOKINGS.GetStringValue("USER_LOGON")) != "martin" && QDesign.NULL(fleBOOKINGS.GetStringValue("USER_LOGON")) != "pippa" && QDesign.NULL(fleBOOKINGS.GetStringValue("USER_LOGON")) != "ingrid" && QDesign.NULL(fleBOOKINGS.GetStringValue("USER_LOGON")) != "sally" && QDesign.NULL(fleBOOKINGS.GetStringValue("USER_LOGON")) != "suec" && QDesign.NULL(fleBOOKINGS.GetStringValue("USER_LOGON")) != "hayleyd" && QDesign.NULL(fleBOOKINGS.GetStringValue("USER_LOGON")) != "wendy" && QDesign.NULL(fleBOOKINGS.GetStringValue("USER_LOGON")) != "marina" && QDesign.NULL(fleBOOKINGS.GetStringValue("USER_LOGON")) != "lesley") || (QDesign.NULL(fleBOOKINGS.GetStringValue("LOCATION")) == "RG" && QDesign.NULL(fleBOOKINGS.GetStringValue("USER_LOGON")) != "manger" && QDesign.NULL(fleBOOKINGS.GetStringValue("USER_LOGON")) != "nick" && QDesign.NULL(fleBOOKINGS.GetStringValue("USER_LOGON")) != "rob" && QDesign.NULL(fleBOOKINGS.GetStringValue("USER_LOGON")) != "martin" && QDesign.NULL(fleBOOKINGS.GetStringValue("USER_LOGON")) != "pippa" && QDesign.NULL(fleBOOKINGS.GetStringValue("USER_LOGON")) != "ingrid" && QDesign.NULL(fleBOOKINGS.GetStringValue("USER_LOGON")) != "julie" && QDesign.NULL(fleBOOKINGS.GetStringValue("USER_LOGON")) != "marina" && QDesign.NULL(fleBOOKINGS.GetStringValue("USER_LOGON")) != "lesley") || (QDesign.NULL(fleBOOKINGS.GetStringValue("LOCATION")) == "VB" && QDesign.NULL(fleBOOKINGS.GetStringValue("USER_LOGON")) != "hazel" && QDesign.NULL(fleBOOKINGS.GetStringValue("USER_LOGON")) != "manger" && QDesign.NULL(fleBOOKINGS.GetStringValue("USER_LOGON")) != "nick" && QDesign.NULL(fleBOOKINGS.GetStringValue("USER_LOGON")) != "rob" && QDesign.NULL(fleBOOKINGS.GetStringValue("USER_LOGON")) != "martin" && QDesign.NULL(fleBOOKINGS.GetStringValue("USER_LOGON")) != "pippa" && QDesign.NULL(fleBOOKINGS.GetStringValue("USER_LOGON")) != "ingrid" && QDesign.NULL(fleBOOKINGS.GetStringValue("USER_LOGON")) != "sally" && QDesign.NULL(fleBOOKINGS.GetStringValue("USER_LOGON")) != "suec" && QDesign.NULL(fleBOOKINGS.GetStringValue("USER_LOGON")) != "hayleyd" && QDesign.NULL(fleBOOKINGS.GetStringValue("USER_LOGON")) != "marina" && QDesign.NULL(fleBOOKINGS.GetStringValue("USER_LOGON")) != "lesley" && QDesign.NULL(fleBOOKINGS.GetStringValue("USER_LOGON")) != "wendy")) && QDesign.NULL(flePROPERTIES.GetDecimalValue("ON_REQUEST_DAYS")) > 0 && QDesign.NULL(T_START_DATE.Value) < QDesign.NULL(QDesign.PhDate(QDesign.Days(QDesign.SysDate(ref m_cnnQUERY)) + flePROPERTIES.GetDecimalValue("ON_REQUEST_DAYS"))))
                {
                    ErrorMessage("** THIS PROPERTY IS NOW ON REQUEST ONLY " + "- CHECK AVAILABILITY WITH NICK **");
                    // TODO: May need to fix manually
                }
                if (QDesign.NULL(fleBOOKINGS.GetStringValue("USER_LOGON")) == "lesley" && QDesign.NULL(fleBOOKINGS.GetStringValue("LOCATION")) == "MR" && QDesign.NULL(flePROPERTIES.GetDecimalValue("ON_REQUEST_DAYS")) > 0 && QDesign.NULL(T_START_DATE.Value) < QDesign.NULL((QDesign.PhDate(QDesign.Days(QDesign.SysDate(ref m_cnnQUERY)) + flePROPERTIES.GetDecimalValue("ON_REQUEST_DAYS")))))
                {
                    ErrorMessage("** THIS PROPERTY IS ON REQUEST ONLY - CHECK WITH NICK **");
                    // TODO: May need to fix manually
                }
                if ("1225" == QDesign.NULL(QDesign.Substring(QDesign.ASCII(T_START_DATE.Value), 5, 4)) && (QDesign.NULL(flePROPERTIES.GetStringValue("GROUPING")) != "HOTL" && QDesign.NULL(flePROPERTIES.GetStringValue("LOCATION")) != "MD" && QDesign.NULL(flePROPERTIES.GetStringValue("LOCATION")) != "MR" && QDesign.NULL(flePROPERTIES.GetStringValue("LOCATION")) != "MC" && QDesign.NULL(flePROPERTIES.GetStringValue("LOCATION")) != "GM" && QDesign.NULL(flePROPERTIES.GetStringValue("LOCATION")) != "KH" && QDesign.NULL(flePROPERTIES.GetStringValue("LOCATION")) != "KL" && QDesign.NULL(flePROPERTIES.GetStringValue("LOCATION")) != "SA" && QDesign.NULL(flePROPERTIES.GetStringValue("LOCATION")) != "BN" && QDesign.NULL(flePROPERTIES.GetStringValue("LOCATION")) != "EP"))
                {
                    ErrorMessage("52051");
                }
                if ("0101" == QDesign.NULL(QDesign.Substring(QDesign.ASCII(T_START_DATE.Value), 5, 4)))
                {
                    Information("42010");
                    Accept(ref fldT_CONTINUE);
                    if (QDesign.NULL(T_CONTINUE.Value) != "Y")
                    {
                        ErrorMessage("52052");
                    }
                }
                if ("1231" == QDesign.NULL(QDesign.Substring(QDesign.ASCII(T_START_DATE.Value), 5, 4)) && QDesign.NULL(flePROPERTY_YEARS.GetStringValue("LOCATION")) == "FL")
                {
                    ErrorMessage("52053");
                }
                if (("1224" == QDesign.NULL(QDesign.Substring(QDesign.ASCII(T_START_DATE.Value), 5, 4)) || "1231" == QDesign.NULL(QDesign.Substring(QDesign.ASCII(T_START_DATE.Value), 5, 4))) && (QDesign.NULL(flePROPERTY_YEARS.GetStringValue("LOCATION")) == "CP" || QDesign.NULL(flePROPERTY_YEARS.GetStringValue("LOCATION")) == "CM") && QDesign.NULL(fleUSER_SEC_FILE.GetStringValue("USER_LEVEL")) != "01")
                {
                    ErrorMessage("52054");
                }
                if ("1226" == QDesign.NULL(QDesign.Substring(QDesign.ASCII(T_START_DATE.Value), 5, 4)) && QDesign.NULL(T_AREA.Value) == "UKL" && !((QDesign.NULL(flePROPERTY_YEARS.GetStringValue("LOCATION")) == "LY" && QDesign.NULL(flePROPERTY_YEARS.GetStringValue("PROPERTY_ID")) == "25" && QDesign.NULL(T_START_DATE.Value) == 20121226) || (QDesign.NULL(flePROPERTY_YEARS.GetStringValue("LOCATION")) == "TT" && QDesign.NULL(flePROPERTY_YEARS.GetStringValue("PROPERTY_ID")) == "E6" && QDesign.NULL(T_START_DATE.Value) == 20121226) || (QDesign.NULL(flePROPERTY_YEARS.GetStringValue("LOCATION")) == "SB" && QDesign.NULL(flePROPERTY_YEARS.GetStringValue("PROPERTY_ID")) == "21" && QDesign.NULL(T_START_DATE.Value) == 20121226) || (QDesign.NULL(flePROPERTY_YEARS.GetStringValue("LOCATION")) == "HL" && QDesign.NULL(flePROPERTY_YEARS.GetStringValue("PROPERTY_ID")) == "HM17" && QDesign.NULL(T_START_DATE.Value) == 20121226)))
                {
                    ErrorMessage("52055");
                }
                if (QDesign.NULL(T_START_DATE.Value) > QDesign.NULL(D_2_YEARS.Value))
                {
                    ErrorMessage("52056");
                }
                if (QDesign.NULL(D_POINTS_BALANCE.Value) < 0)
                {
                    Warning("INVESTOR IS " + QDesign.ASCII(D_POINTS_BALANCE.Value) + "POINTS SHORT - ARE YOU SURE YOU WANT TO ALLOW THIS BOOKING?");
                    // TODO: May need to fix manually
                    Accept(ref fldT_ALLOW);
                    if (QDesign.NULL(T_ALLOW.Value) != "Y")
                    {
                        ErrorMessage("52057");
                    }
                }
                fleBOOKINGS.set_SetValue("BOOKING_POINTS", D_POINTS.Value);
                if (QDesign.NULL(flePROPERTIES.GetStringValue("SPLIT_WEEKS")) == "Y")
                {
                    Internal_CHECK_SPLIT_WEEKS();
                }
                if (QDesign.NULL(fleBOOKINGS.GetDecimalValue("BOOKING_CHARGE")) > 0)
                {
                    if ((QDesign.NULL(flePROPERTIES.GetStringValue("GROUPING")) != "SHHT" && QDesign.NULL(flePROPERTIES.GetStringValue("GROUPING")) != "SHHL" && QDesign.NULL(D_DEPOSIT.Value) == "N"))
                    {
                        fleUCHARGE_DEBTS.set_SetValue("PAYMENT_TYPE", "F");
                        fleUCHARGE_DEBTS.set_SetValue("DEBT_AMOUNT", fleBOOKINGS.GetDecimalValue("BOOKING_CHARGE"));
                        fleUCHARGE_DEBTS.set_SetValue("VAT", fleBOOKINGS.GetDecimalValue("VAT"));
                        fleUCHARGE_DEBTS.set_SetValue("TOTAL_CHARGE", T_USER_CHARGE_TOT.Value);
                        fleUCHARGE_DEBTS.set_SetValue("EXCHANGE_RATE", fleCURRENCY_RATE.GetDecimalValue("EXCHANGE_RATE"));
                        if (QDesign.NULL(fleANNUAL_ENT.GetDecimalValue("PP1_SURCHARGEPER")) > 0)
                        {
                            fleUCHARGE_DEBTS.set_SetValue("PP1_SURCHARGE", D_PP1_SURCHARGE.Value);
                        }
                        if (QDesign.NULL(fleANNUAL_ENT.GetDecimalValue("PP2_SURCHARGEPER")) > 0)
                        {
                            fleUCHARGE_DEBTS.set_SetValue("PP2_SURCHARGE", D_PP2_SURCHARGE.Value);
                        }
                    }
                    if ((QDesign.NULL(flePROPERTIES.GetStringValue("GROUPING")) == "SHHT" || QDesign.NULL(flePROPERTIES.GetStringValue("GROUPING")) == "SHHL" || QDesign.NULL(D_DEPOSIT.Value) == "Y"))
                    {
                        if (QDesign.NULL(D_SHHL_BALANCE.Value) > 0)
                        {
                            fleUCHARGE_DEBTS.set_SetValue("PAYMENT_TYPE", "D");
                        }
                        else
                        {
                            fleUCHARGE_DEBTS.set_SetValue("PAYMENT_TYPE", "F");
                        }
                        fleUCHARGE_DEBTS.set_SetValue("DEBT_AMOUNT", D_DUE_NOW.Value);
                        fleUCHARGE_DEBTS.set_SetValue("VAT", D_VAT_NOW.Value);
                        fleUCHARGE_DEBTS.set_SetValue("TOTAL_CHARGE", ((fleUCHARGE_DEBTS.GetDecimalValue("DEBT_AMOUNT") * (fleCURRENCY_RATE.GetDecimalValue("EXCHANGE_RATE") / 10000)) + (decimal)0.5));
                        fleUCHARGE_DEBTS.set_SetValue("EXCHANGE_RATE", fleCURRENCY_RATE.GetDecimalValue("EXCHANGE_RATE"));
                        if (QDesign.NULL(D_SHHL_BALANCE.Value) > 0)
                        {
                            fleBALANCE_DEBTS.set_SetValue("DEBT_AMOUNT", D_SHHL_BALANCE.Value);
                            fleBALANCE_DEBTS.set_SetValue("TOTAL_CHARGE", ((fleBALANCE_DEBTS.GetDecimalValue("DEBT_AMOUNT") * (fleCURRENCY_RATE.GetDecimalValue("EXCHANGE_RATE") / 10000)) + (decimal)0.5));
                            fleBALANCE_DEBTS.set_SetValue("EXCHANGE_RATE", fleCURRENCY_RATE.GetDecimalValue("EXCHANGE_RATE"));
                            fleBALANCE_DEBTS.set_SetValue("VAT", D_VAT_BALANCE.Value);
                            if (QDesign.NULL(fleANNUAL_ENT.GetDecimalValue("PP1_SURCHARGEPER")) > 0)
                            {
                                fleBALANCE_DEBTS.set_SetValue("PP1_SURCHARGE", D_PP1_SURCHARGE.Value);
                            }
                            if (QDesign.NULL(fleANNUAL_ENT.GetDecimalValue("PP2_SURCHARGEPER")) > 0)
                            {
                                fleBALANCE_DEBTS.set_SetValue("PP2_SURCHARGE", D_PP2_SURCHARGE.Value);
                            }
                            fleBALANCE_DEBTS.set_SetValue("EXCHANGE_RATE", fleCURRENCY_RATE.GetDecimalValue("EXCHANGE_RATE"));
                            fleUCHARGE_DEBTS.set_SetValue("PP1_SURCHARGE", 0);
                            fleUCHARGE_DEBTS.set_SetValue("PP2_SURCHARGE", 0);
                        }
                        else
                        {
                            if (QDesign.NULL(fleANNUAL_ENT.GetDecimalValue("PP1_SURCHARGEPER")) > 0)
                            {
                                fleUCHARGE_DEBTS.set_SetValue("PP1_SURCHARGE", D_PP1_SURCHARGE.Value);
                            }
                            if (QDesign.NULL(fleANNUAL_ENT.GetDecimalValue("PP2_SURCHARGEPER")) > 0)
                            {
                                fleUCHARGE_DEBTS.set_SetValue("PP2_SURCHARGE", D_PP2_SURCHARGE.Value);
                            }
                        }
                    }
                    fleUCHARGE_DEBTS.set_SetValue("EXCHANGE_RATE", fleCURRENCY_RATE.GetDecimalValue("EXCHANGE_RATE"));
                    Internal_CALC_VAT();
                }
                fleBOOKINGS.set_SetValue("START_DATE", T_START_DATE.Value);
                fleBOOKINGS.set_SetValue("START_YM", QDesign.Substring(QDesign.ASCII(T_START_DATE.Value, 8), 1, 6));
                fleBOOKINGS.set_SetValue("END_DATE", T_END_DATE.Value);
                fleBOOKINGS.set_SetValue("PP1_SURCHARGEPER", fleANNUAL_ENT.GetDecimalValue("PP1_SURCHARGEPER"));
                fleBOOKINGS.set_SetValue("PP2_SURCHARGEPER", fleANNUAL_ENT.GetDecimalValue("PP2_SURCHARGEPER"));
                if (QDesign.NULL(D_DEPOSIT.Value) == "Y")
                {
                    fleBOOKINGS.set_SetValue("DEPOSIT", D_DUE_NOW.Value);
                }
                fleBOOKINGS.set_SetValue("ENT_YEAR", fleCURRENT_ENTS.GetStringValue("YEAR"));
                if (QDesign.NULL(D_POINTS.Value) > 0)
                {
                    fleBOOKINGS.set_SetValue("TERM_SURCHARGEPER", fleINVESTMENTS.GetDecimalValue("TERM_SURCHARGEPER"));
                }
                Internal_RECHECK_AVAILABILITY();
                Internal_MARK_CALENDAR();
                Internal_ASSIGN_POINTS();
                if (QDesign.NULL(fleBOOKINGS.GetDecimalValue("BK_PURCHASE")) > 0)
                {
                    Internal_CREATE_PURCHASE();
                }
                T_UPDATE_LINKED.Value = "Y";
                Internal_CHECK_SET_LINKED();

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


        protected override bool PostUpdate()
        {


            try
            {

                if (fleBOOKINGS.GetDecimalValue("START_DATE") <= QDesign.PhDate(QDesign.Days(QDesign.SysDate(ref m_cnnQUERY)) + 5))
                {
                    Information("** REMEMBER TO GIVE BONDHOLDER COMBINATION CODE AND INSTRUCTIONS **");
                    // TODO: May need to fix manually
                }
                if (QDesign.NULL(fleBOOKINGS.GetDecimalValue("START_DATE")) == QDesign.NULL(QDesign.PhDate(QDesign.Days(QDesign.SysDate(ref m_cnnQUERY)) + 1)))
                {
                    Information("** NEXT DAY BOOKING - REMEMBER TO INFORM SITE MANAGER **");
                    // TODO: May need to fix manually
                    Information("** PLEASE PHONE OR EMAIL THEM NOW **");
                    // TODO: May need to fix manually
                }
                //FileSystem.Unlock(flePROPERTY_YEARS);
                T_BALANCE.Value = D_POINTS_BALANCE.Value;
                M_BOOKED.Value = "Y";
                T_NEW_BOOKING.Value = "Y";
                object[] arrRunscreen = { flePROPERTIES, T_NEW_BOOKING, T_BOOKING_REF, T_START_DATE,
                T_ALLOW, T_ALLOW, T_WEB_BOOKING, T_WEB_BOOKING };
                RunScreen(new BOOKDETS(), RunScreenModes.Entry, ref arrRunscreen);
                T_BALANCE.Value = D_POINTS_BALANCE.Value;
                object[] arrRunscreen2 = { T_BOOKING_REF, T_BALANCE };
                RunScreen(new BOOK0500(), RunScreenModes.Find, ref arrRunscreen2);

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



        private void dsrDesigner_01_Click(object sender, System.EventArgs e)
        {

            try
            {

                Internal_ENTRY_PROCEDURE();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_INV_Click(object sender, System.EventArgs e)
        {

            try
            {

                T_INVESTOR.Value = fleM_INVESTORS.GetStringValue("INVESTOR");
                //RunScreen("IVST0200.QKC", RunScreenModes.Find, T_INVESTOR);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_PROP_Click(object sender, System.EventArgs e)
        {

            try
            {

                T_LOCATION.Value = flePROPERTIES.GetStringValue("LOCATION");
                T_PROPERTY_ID.Value = flePROPERTIES.GetStringValue("PROPERTY_ID");
                //RunScreen("PROPDETS.QKC", RunScreenModes.Find, T_LOCATION, T_PROPERTY_ID);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_COMM_Click(object sender, System.EventArgs e)
        {

            try
            {

                T_PROPERTY_CODE.Value = flePROPERTIES.GetStringValue("LOCATION") + flePROPERTIES.GetStringValue("BEDS") + flePROPERTIES.GetStringValue("PROPERTY_STYLE") + flePROPERTIES.GetStringValue("BATHROOMS") + flePROPERTIES.GetStringValue("PROPERTY_ID");
                //Parent:PROPERTY_CODE
                //RunScreen("DISPCOMM.QKC", RunScreenModes.Find, T_PROPERTY_CODE);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_LD_Click(object sender, System.EventArgs e)
        {

            try
            {

                T_LOCATION.Value = flePROPERTIES.GetStringValue("LOCATION");
                T_PROPERTY_ID.Value = flePROPERTIES.GetStringValue("PROPERTY_ID");
                //RunScreen("LOCDETS.QKC", RunScreenModes.Find, T_LOCATION, T_PROPERTY_ID);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_SW_Click(object sender, System.EventArgs e)
        {

            try
            {

                //RunScreen("SPLITWK.QKC", RunScreenModes.Find, fleLOCATIONS);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_DMD_Click(object sender, System.EventArgs e)
        {

            try
            {

                T_INVESTOR.Value = fleM_INVESTORS.GetStringValue("INVESTOR");
                //RunScreen("DMDCONV1", RunScreenModes.Find, T_INVESTOR);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_UC_Click(object sender, System.EventArgs e)
        {

            try
            {

                // --> GET LOCATIONS <--
                m_strWhere = new StringBuilder(" WHERE ");
                m_strWhere.Append(" ").Append(fleLOCATIONS.ElementOwner("LOCATION")).Append(" = ");
                m_strWhere.Append(Common.StringToField(flePROPERTIES.GetStringValue("LOCATION")));

                fleLOCATIONS.GetData(m_strWhere.ToString());
                // --> End GET LOCATIONS <--
                //RunScreen("UCHARGE2.QKC", RunScreenModes.Find, fleLOCATIONS, T_HOLIDAY_YEAR);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_FLIGHTS_Click(object sender, System.EventArgs e)
        {

            try
            {

                T_INVESTOR.Value = fleM_INVESTORS.GetStringValue("INVESTOR");
                //RunScreen("CHEKFLTS.QKC", RunScreenModes.Entry, T_INVESTOR);


            }
            catch (CustomApplicationException ex)
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
                m_strWhere = new StringBuilder(GetWhereCondition(fleBOOKINGS.ElementOwner("INVESTOR"), fleM_INVESTORS.GetStringValue("INVESTOR"), ref blnAddWhere));
                fleBOOKINGS.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);

                fleBALANCE_DEBTS.GetData();

                fleUCHARGE_DEBTS.GetData();

                flePURCHASE_DEBTS.GetData();

                SCREEN_PROPERTY_PROPERTY_CODE.Value = fleSCREEN_PROPERTY.GetStringValue("LOCATION") + fleSCREEN_PROPERTY.GetStringValue("BEDS") + fleSCREEN_PROPERTY.GetStringValue("PROPERTY_STYLE").PadRight(2, ' ') +
                    fleSCREEN_PROPERTY.GetStringValue("BATHROOMS") + "-" + fleSCREEN_PROPERTY.GetStringValue("PROPERTY_ID");

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
                Page.PageTitle = "P R O V I S I O N A L  B O O K I N G";




            }
            catch (CustomApplicationException ex)
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
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 06/19/2013 8:54:20 AM
        //#-----------------------------------------
        protected override bool Update()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 06/19/2013 8:54:20 AM
                fleM_INVESTORS.PutData(false, PutTypes.New);
                fleUSER_SEC_FILE.PutData(false, PutTypes.New);
                flePROPERTY_YEARS.PutData(false, PutTypes.New);
                fleSCREEN_PROPERTY.PutData(false, PutTypes.New);
                flePROPERTIES.PutData(false, PutTypes.New);
                flePROP_COMMENTS.PutData(false, PutTypes.New);
                fleBOOK0100_COMM.PutData(false, PutTypes.New);
                fleBOOKINGS.PutData(false, PutTypes.New);
                flePURCHASE_DEBTS.PutData();
                fleUCHARGE_DEBTS.PutData();
                fleBALANCE_DEBTS.PutData();
                fleBOOKINGS.PutData();
                fleBOOK0100_COMM.PutData();
                flePROP_COMMENTS.PutData();
                flePROPERTIES.PutData();
                fleSCREEN_PROPERTY.PutData();
                flePROPERTY_YEARS.PutData();

                while (For(53))
                {
                    flePROPERTY_YEARS_DTL.PutData();
                }
                fleUSER_SEC_FILE.PutData();
                fleM_INVESTORS.PutData();
                while (For(53))
                {
                    fleBOOKING_PERIODS_DTL.PutData();
                }
                while (For(53))
                {
                    fleCHARGES_DTL.PutData();
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
        //# dsrDesigner_06_Click Procedure
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 06/19/2013 8:54:20 AM
        //#-----------------------------------------
        private void dsrDesigner_06_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:49:49 PM
                Accept(ref fldBOOKINGS_BK_SUSPENSE);
                Display(ref fldD_SUSP_MAX);
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
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 06/19/2013 8:54:20 AM
        //#-----------------------------------------
        private void dsrDesigner_07_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:49:49 PM
                Accept(ref fldBOOKINGS_BK_PURCHASE);
                Display(ref fldD_PURC_MAX);
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
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 06/19/2013 8:54:20 AM
        //#-----------------------------------------
        private void dsrDesigner_03_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:49:49 PM
                Accept(ref fldBOOKINGS_BOOKING_CHARGE);
                Display(ref fldD_FULL_CHARGE);
                Display(ref fldD_PP_FLAG);
                Display(ref fldSCREEN_PROPERTY_PROPERTY_DATE_1);
                Display(ref fldSCREEN_PROPERTY_PROPERTY_DATE_2);
                Display(ref fldSCREEN_PROPERTY_PROPERTY_DATE_3);
                Display(ref fldSCREEN_PROPERTY_PROPERTY_DATE_4);
                Display(ref fldSCREEN_PROPERTY_PROPERTY_DATE_5);
                Display(ref fldSCREEN_PROPERTY_PROPERTY_DATE_6);
                Display(ref fldSCREEN_PROPERTY_PROPERTY_DATE_7);
                Display(ref fldSCREEN_PROPERTY_PROPERTY_DATE_8);
                Display(ref fldSCREEN_PROPERTY_PROPERTY_DATE_9);
                Display(ref fldSCREEN_PROPERTY_PROPERTY_DATE_10);
                Display(ref fldSCREEN_PROPERTY_PERIOD_1);
                Display(ref fldSCREEN_PROPERTY_PERIOD_2);
                Display(ref fldSCREEN_PROPERTY_PERIOD_3);
                Display(ref fldSCREEN_PROPERTY_PERIOD_4);
                Display(ref fldSCREEN_PROPERTY_PERIOD_5);
                Display(ref fldSCREEN_PROPERTY_PERIOD_6);
                Display(ref fldSCREEN_PROPERTY_PERIOD_7);
                Display(ref fldSCREEN_PROPERTY_PERIOD_8);
                Display(ref fldSCREEN_PROPERTY_PERIOD_9);
                Display(ref fldSCREEN_PROPERTY_PERIOD_10);
                Display(ref fldSCREEN_PROPERTY_WEEK_STATUS_1);
                Display(ref fldSCREEN_PROPERTY_WEEK_STATUS_2);
                Display(ref fldSCREEN_PROPERTY_WEEK_STATUS_3);
                Display(ref fldSCREEN_PROPERTY_WEEK_STATUS_4);
                Display(ref fldSCREEN_PROPERTY_WEEK_STATUS_5);
                Display(ref fldSCREEN_PROPERTY_WEEK_STATUS_6);
                Display(ref fldSCREEN_PROPERTY_WEEK_STATUS_7);
                Display(ref fldSCREEN_PROPERTY_WEEK_STATUS_8);
                Display(ref fldSCREEN_PROPERTY_WEEK_STATUS_9);
                Display(ref fldSCREEN_PROPERTY_WEEK_STATUS_10);
                Display(ref fldT_POINTS_1);
                Display(ref fldT_POINTS_2);
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
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 06/19/2013 8:54:20 AM
        //#-----------------------------------------
        private void dsrDesigner_04_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:49:49 PM
                Display(ref fldD_NET_POINTS);
                Display(ref fldT_POINTS_3);
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
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 06/19/2013 8:54:21 AM
        //#-----------------------------------------
        private void dsrDesigner_05_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:49:49 PM
                Accept(ref fldBOOKINGS_POINTS_ADJUST);
                Display(ref fldT_POINTS_4);
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
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 06/19/2013 8:54:21 AM
        //#-----------------------------------------
        private void dsrDesigner_08_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:49:49 PM
                Accept(ref fldBOOKINGS_BK_ADDON);
                Display(ref fldD_TOP_UP_COST);
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
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 06/19/2013 8:54:21 AM
        //#-----------------------------------------
        private void dsrDesigner_11_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:49:49 PM
                Accept(ref fldT_FIXED_DEBT);
                Display(ref fldD_PP_SURCHARGE);
                Display(ref fldT_TERM_SURCHARGE);
                Display(ref fldINVESTMENTS_QUALIFY_28DAY);
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
