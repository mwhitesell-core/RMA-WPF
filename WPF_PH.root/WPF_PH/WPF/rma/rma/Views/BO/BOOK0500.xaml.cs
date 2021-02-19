
#region "Screen Comments"

// -------------------------------------------------------------------
// BOOK0500.qks  Display booking details
// -------------------------------------------------------------------
// 13/12/96 - Flight request screen now called from this program
// instead of BOOK0300.
// -------------------------------------------------------------------
// 28/09/99 - Allow CONFIRM.qkc to be called if the investor has
// enough points entitlement agreed for the booking
// -------------------------------------------------------------------
// 18/01/00 - Don`t create BOOKING-LETTERS if inside 28 days
// -------------------------------------------------------------------
// 21/01/03 - Set PRINTED of booking-letters to  N 
// -------------------------------------------------------------------
// 29/01/03 - set SPARE-NUM in bookings so that the screen errors with
//  record not updated  if the user doesn`t update!
// -------------------------------------------------------------------
// 05/03/03 - Removed item statement for SPARE-8 of BOOKINGS
// as this was overwriting SHHL set by BOOKSHHL.qkc
// and there doesn`t appear to be any reason for it anway.
// -------------------------------------------------------------------
// 23.06.03 - add item for start-ym && booking-ym of bookings
// -------------------------------------------------------------------
// 01.12.03 - create booking-letters if grouping[1:3] =  SHH 
// -------------------------------------------------------------------
// 14.01.04 - Always call Flight Request screen on update - not opt.2
// Also add locations file to check area code.
// -------------------------------------------------------------------
// 17/03/04 - We need to get both RS and BL (balance) debts for SHHL.
// (The PP surcharges are held in the balance debts record)
// -------------------------------------------------------------------
// 23.09.04 - Changes to allow fixed deposit charge.
// -------------------------------------------------------------------
// 25.10.05 - ensure reserved bookings for SHH properties are marked  R 
// which creates a prov booking letter (not  O  option).
// -------------------------------------------------------------------
// 07/11/05     pass new field t-instant-conf to confirm.qkc
// (also pass t-instant-delete)
// -------------------------------------------------------------------
// 08.11.05     check t-confirm =    , happens when user UR`s without
// setting t-confirm which was not writing booking-letters.
// -------------------------------------------------------------------
// 24.03.06 ME  set confirm-time of BOOKINGS in postfind to force  
//  data has changed  message and procedure backout to run,
// set back to 0 in preupdate - if they do am update.
// -------------------------------------------------------------------
// 25.04.06 ME  changes for Notional VAT.
// -------------------------------------------------------------------
// 21/08/07 RC  Allow confirmation with purchased points  
// -------------------------------------------------------------------
// 13/12/07 RC  Don`t call flightrq.qkc for locations MH and SS
// or for holidays starting more than 11 months away
// -------------------------------------------------------------------
// 28.12.07 ME  Stop owner bookings being asked for flight quotes.  
// -------------------------------------------------------------------
// 07.07.08 ME  Change 330 day quote check to 337 days.
// -------------------------------------------------------------------
// 30.03.09 ME  Output booking details to flat file on /exstore.
// -------------------------------------------------------------------
// 24/04/09 RC  Call screen bookflts.qks to show flight prices
// -------------------------------------------------------------------
// 21.05.09 ME  Fix to stop #27 error when exstore file already in use.
// -------------------------------------------------------------------
// 11.11.09 ME  Drop exstore and sent to /rma/trans/.. instead.
// -------------------------------------------------------------------
// 04.01.10 ME  write email conf booking-letteer rec if not existing.
// -------------------------------------------------------------------
// 15.02.10 ME  Do not send flight quotes etc to  99ADM  -Admin Inv.
// -------------------------------------------------------------------
// 25.10.10 ME  Check email address is ok - part of My Bookings.
// -------------------------------------------------------------------
// 11.11.10 ME  Now pass t-confirm-ref to confirm.qkc instead of
// t-booking-ref so that temps do not overlap.
// -------------------------------------------------------------------
// 02.12.10 ME  No longer sending confs by post if we have an email
// address - booking-letter already created if required.
// -------------------------------------------------------------------
// 13.01.11 ME  make lookup on emails opional and error of not found.
// -------------------------------------------------------------------
// 25.01.12 ME  Changes for customer-type  I  (Interval International).
// Create  EC  booking-letter rec if customer-type =  I 
// to make sure emailed confirmation is sent at  RS  stage.
// -------------------------------------------------------------------
// 25.04.12 ME  travelrq.qks replaces flightrq.qks.
// -------------------------------------------------------------------
// 18.09.12 RM  Add scrnvst to record visit to this screen
// -------------------------------------------------------------------
// 23.10.12 RM  Remove scrnvst here, too many visits
// -------------------------------------------------------------------
// 05.12.12 ME Changed for Signature Villas (customer-type = V).
// ---------------------------------------------------------------------

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
using System.Threading;

namespace rma.Views
{

    partial class BOOK0500 : BasePage
    {

        #region " Form Designer Generated Code "





        public BOOK0500()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "BOOK0500";

            //# Set the ACTIVITIES for the screen.
            this.ChangeActivity = true;
            this.FindActivity = true;
            this.DeleteActivity = false;
            this.EntryActivity = false;
            this.AutoReturn = true;
            this.UseAcceptProcessing = true;         

            this.HasBackoutProcedure = true;


        }

        #endregion

        private void Page_Load(object sender, RoutedEventArgs e)
        {
            SetVariables();
            dsrDesigner_01.Click += dsrDesigner_01_Click;
            dsrDesigner_CONF.Click += dsrDesigner_CONF_Click;
            dsrDesigner_FLIGHTS.Click += dsrDesigner_FLIGHTS_Click;
            dsrDesigner_POST.Click += dsrDesigner_POST_Click;

            fldT_EMAIL_OK.Edit += fldT_EMAIL_OK_Edit;
            fldT_CONFIRM.Input += fldT_CONFIRM_Input;
            fldT_CONFIRM.Edit += fldT_CONFIRM_Edit;
            fldT_EMAIL_OK.Process += fldT_EMAIL_OK_Process;
            fldT_CONFIRM.Process += fldT_CONFIRM_Process;
            

            fleBOOKING_DEBTS.AccessIsOptional = true;
            fleBALANCE_DEBTS.AccessIsOptional = true;
            fleCORR_ADDRESS.AccessIsOptional = true;

            Page_Load();

            // TODO: The following elements have Input/Output Scaling defined in the Dictionary or Screen.  Manual steps may be required:
            //       BALANCE_DEBTS.PP1_SURCHARGE InputScale: 2 OutputScale: 0
            //       BALANCE_DEBTS.PP2_SURCHARGE InputScale: 2 OutputScale: 0
            //       BALANCE_DEBTS.TERM_SURCHARGE InputScale: 2 OutputScale: 0
            //       BOOKINGS.BOOKING_CHARGE InputScale: 2 OutputScale: 0
            //       BOOKINGS.TERM_SURCHARGEPER InputScale: 2 OutputScale: 0
            //       BOOKING_DEBTS.DEBT_AMOUNT InputScale: 2 OutputScale: 0
            //       BOOKING_DEBTS.PP1_SURCHARGE InputScale: 2 OutputScale: 0
            //       BOOKING_DEBTS.PP2_SURCHARGE InputScale: 2 OutputScale: 0
            //       BOOKING_DEBTS.TERM_SURCHARGE InputScale: 2 OutputScale: 0
            // TODO: The following FIELD(S) on the form are redefine elements.  Manual steps may be required:
            //       BOOKINGS.PROPERTY_CODE


        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            BOOKINGS_PROPERTY_CODE = new CoreCharacter("BOOKINGS_PROPERTY_CODE", 10, this, Common.cEmptyString);
            T_BOOKING_REF = new CoreCharacter("T_BOOKING_REF", 8, this, Common.cEmptyString);
            T_CONFIRM = new CoreCharacter("T_CONFIRM", 1, this, Common.cEmptyString);
            T_START_DATE = new CoreDate("T_START_DATE", this);
            T_END_DATE = new CoreDate("T_END_DATE", this);
            T_INVESTOR = new CoreCharacter("T_INVESTOR", 8, this, Common.cEmptyString);
            T_LOCATION = new CoreCharacter("T_LOCATION", 2, this, Common.cEmptyString);
            T_BALANCE = new CoreInteger("T_BALANCE", 8, this);
            T_FIRST_TIME = new CoreCharacter("T_FIRST_TIME", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
            T_CONFIRM_DATE = new CoreDate("T_CONFIRM_DATE", this, ResetTypes.ResetAtStartup);
            T_EMAIL_OK = new CoreCharacter("T_EMAIL_OK", 1, this, " ");
            T_NEW_EMAIL_OK = new CoreCharacter("T_NEW_EMAIL_OK", 1, this, " ");
            T_POST = new CoreCharacter("T_POST", 1, this, "N");
            T_AUTOPOST = new CoreCharacter("T_AUTOPOST", 1, this, "N");
            T_EMAIL_MSG = new CoreCharacter("T_EMAIL_MSG", 54, this, " ");
            T_CONFIRM_REF = new CoreCharacter("T_CONFIRM_REF", 8, this, " ");
            T_PREV_PROG = new CoreCharacter("T_PREV_PROG", 8, this, "book0500");
            fleBOOKINGS = new OracleFileObject(this, FileTypes.Primary, 0, "INDEXED", "BOOKINGS", "", true, false, false, 0, "m_trnTRANS_UPDATE");
            fleBOOKING_DEBTS = new OracleFileObject(this, FileTypes.Reference, 0, "INDEXED", "BOOKING_DEBTS", "", false, false, false, 0, "m_cnnQUERY");
            fleBALANCE_DEBTS = new OracleFileObject(this, FileTypes.Reference, 0, "INDEXED", "BOOKING_DEBTS", "BALANCE_DEBTS", false, false, false, 0, "m_cnnQUERY");
            fleM_INVESTORS = new OracleFileObject(this, FileTypes.Reference, 0, "INDEXED", "M_INVESTORS", "", true, false, false, 0, "m_cnnQUERY");
            flePROPERTIES = new OracleFileObject(this, FileTypes.Reference, 0, "INDEXED", "PROPERTIES", "", false, false, false, 0, "m_cnnQUERY");
            fleBOOKING_LETTERS = new OracleFileObject(this, FileTypes.Designer, 0, "INDEXED", "BOOKING_LETTERS", "", true, false, false, 0, "m_trnTRANS_UPDATE");
            fleCORR_ADDRESS = new OracleFileObject(this, FileTypes.Reference, 0, "INDEXED", "CORR_ADDRESS", "", false, false, false, 0, "m_cnnQUERY");
            fleLOCATIONS = new OracleFileObject(this, FileTypes.Reference, 0, "INDEXED", "LOCATIONS", "", false, false, false, 0, "m_cnnQUERY");
            fleEMAILS = new OracleFileObject(this, FileTypes.Designer, 0, "INDEXED", "EMAILS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            T_UPDATE_OK = new CoreCharacter("T_UPDATE_OK", 1, this, Common.cEmptyString);
            T_INSTANT_CONF = new CoreCharacter("T_INSTANT_CONF", 1, this, Common.cEmptyString);
            T_INSTANT_DELETE = new CoreCharacter("T_INSTANT_DELETE", 1, this, Common.cEmptyString);

            fleBOOKING_DEBTS.Access += fleBOOKING_DEBTS_Access;
            fleBALANCE_DEBTS.Access += fleBALANCE_DEBTS_Access;
            fleM_INVESTORS.Access += fleM_INVESTORS_Access;
            flePROPERTIES.Access += flePROPERTIES_Access;
            fleCORR_ADDRESS.Access += fleCORR_ADDRESS_Access;
            fleLOCATIONS.Access += fleLOCATIONS_Access;
            fleEMAILS.Access += fleEMAILS_Access;
            D_PP1_SURCHARGE.GetValue += D_PP1_SURCHARGE_GetValue;
            D_PP2_SURCHARGE.GetValue += D_PP2_SURCHARGE_GetValue;
            D_TERM_SURCHARGE.GetValue += D_TERM_SURCHARGE_GetValue;
            D_TOTAL.GetValue += D_TOTAL_GetValue;
            D_DOW.GetValue += D_DOW_GetValue;
            D_OPTION_DATE.GetValue += D_OPTION_DATE_GetValue;
            D_BOOKDATE_28.GetValue += D_BOOKDATE_28_GetValue;
            D_BOOKDATE_14.GetValue += D_BOOKDATE_14_GetValue;
            D_START_DATE.GetValue += D_START_DATE_GetValue;
            D_DAYS_AHEAD.GetValue += D_DAYS_AHEAD_GetValue;
            D_OWNER_BOOKING.GetValue += D_OWNER_BOOKING_GetValue;
            D_TRAVEL_MESSAGE.GetValue += D_TRAVEL_MESSAGE_GetValue;
            D_WITHIN_28DAYS.GetValue += D_WITHIN_28DAYS_GetValue;
            D_DUE_NOW_TEXT.GetValue += D_DUE_NOW_TEXT_GetValue;
            D_DUE_NOW.GetValue += D_DUE_NOW_GetValue;
            D_BACKOUT.GetValue += D_BACKOUT_GetValue;
            D_SENDTO.GetValue += D_SENDTO_GetValue;
            D_SENDTOSTORE.GetValue += D_SENDTOSTORE_GetValue;
            D_PUBLIC_BOND.GetValue += D_PUBLIC_BOND_GetValue;
            
        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;
            fleBOOKING_DEBTS.Access -= fleBOOKING_DEBTS_Access;
            fleBALANCE_DEBTS.Access -= fleBALANCE_DEBTS_Access;
            fleM_INVESTORS.Access -= fleM_INVESTORS_Access;
            flePROPERTIES.Access -= flePROPERTIES_Access;
            fleCORR_ADDRESS.Access -= fleCORR_ADDRESS_Access;
            fleLOCATIONS.Access -= fleLOCATIONS_Access;
            fleEMAILS.Access -= fleEMAILS_Access;
            D_PP1_SURCHARGE.GetValue -= D_PP1_SURCHARGE_GetValue;
            D_PP2_SURCHARGE.GetValue -= D_PP2_SURCHARGE_GetValue;
            D_TERM_SURCHARGE.GetValue -= D_TERM_SURCHARGE_GetValue;
            D_TOTAL.GetValue -= D_TOTAL_GetValue;
            D_DOW.GetValue -= D_DOW_GetValue;
            D_OPTION_DATE.GetValue -= D_OPTION_DATE_GetValue;
            D_BOOKDATE_28.GetValue -= D_BOOKDATE_28_GetValue;
            D_BOOKDATE_14.GetValue -= D_BOOKDATE_14_GetValue;
            D_START_DATE.GetValue -= D_START_DATE_GetValue;
            D_DAYS_AHEAD.GetValue -= D_DAYS_AHEAD_GetValue;
            D_OWNER_BOOKING.GetValue -= D_OWNER_BOOKING_GetValue;
            D_TRAVEL_MESSAGE.GetValue -= D_TRAVEL_MESSAGE_GetValue;
            D_WITHIN_28DAYS.GetValue -= D_WITHIN_28DAYS_GetValue;
            D_DUE_NOW_TEXT.GetValue -= D_DUE_NOW_TEXT_GetValue;
            D_DUE_NOW.GetValue -= D_DUE_NOW_GetValue;
            D_BACKOUT.GetValue -= D_BACKOUT_GetValue;
            D_SENDTO.GetValue -= D_SENDTO_GetValue;
            D_SENDTOSTORE.GetValue -= D_SENDTOSTORE_GetValue;
            D_PUBLIC_BOND.GetValue -= D_PUBLIC_BOND_GetValue;
            fldT_EMAIL_OK.Edit -= fldT_EMAIL_OK_Edit;
            fldT_CONFIRM.Input -= fldT_CONFIRM_Input;
            fldT_CONFIRM.Edit -= fldT_CONFIRM_Edit;
            fldT_EMAIL_OK.Process -= fldT_EMAIL_OK_Process;
            fldT_CONFIRM.Process -= fldT_CONFIRM_Process;

            dsrDesigner_01.Click -= dsrDesigner_01_Click;
            dsrDesigner_CONF.Click -= dsrDesigner_CONF_Click;
            dsrDesigner_FLIGHTS.Click -= dsrDesigner_FLIGHTS_Click;
            dsrDesigner_POST.Click -= dsrDesigner_POST_Click;


        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private OracleConnection m_cnnQUERY = new OracleConnection();
        private OracleConnection m_cnnTRANS_UPDATE = new OracleConnection();
        private OracleTransaction m_trnTRANS_UPDATE;
        private CoreCharacter T_BOOKING_REF;
        private CoreCharacter BOOKINGS_PROPERTY_CODE;
        private CoreCharacter T_CONFIRM;
        private CoreDate T_START_DATE;
        private CoreDate T_END_DATE;
        private CoreCharacter T_INVESTOR;
        private CoreCharacter T_LOCATION;
        private CoreInteger T_BALANCE;
        private CoreCharacter T_FIRST_TIME;
        private CoreDate T_CONFIRM_DATE;
        private CoreCharacter T_EMAIL_OK;
        private CoreCharacter T_NEW_EMAIL_OK;
        private CoreCharacter T_POST;
        private CoreCharacter T_AUTOPOST;
        private CoreCharacter T_EMAIL_MSG;
        private CoreCharacter T_CONFIRM_REF;
        private CoreCharacter T_PREV_PROG;
        private OracleFileObject fleBOOKINGS;

        private void fleBOOKINGS_SetItemFinals()
        {

            try
            {
                fleBOOKINGS.set_SetValue("START_YM", QDesign.Substring(QDesign.ASCII(fleBOOKINGS.GetDecimalValue("START_DATE"), 8), 1, 6));
                fleBOOKINGS.set_SetValue("BOOKING_YM", QDesign.Substring(QDesign.ASCII(fleBOOKINGS.GetDecimalValue("BOOKING_DATE"), 8), 1, 6));


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }

        private OracleFileObject fleBOOKING_DEBTS;

        private void fleBOOKING_DEBTS_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleBOOKING_DEBTS.ElementOwner("BOOKING_REF")).Append(" = ").Append(Common.StringToField(fleBOOKINGS.GetStringValue("BOOKING_REF")));

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



        private void fleBOOKING_DEBTS_SelectIf(ref string SelectIfClause)
        {


            try
            {
                StringBuilder strSQL = new StringBuilder("");

                strSQL.Append(" (    ").Append(fleBOOKING_DEBTS.ElementOwner("DEBT_TYPE")).Append(" =  'RS')");
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

        private OracleFileObject flePROPERTIES;

        private void flePROPERTIES_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(flePROPERTIES.ElementOwner("LOCATION")).Append(" = ").Append(Common.StringToField(fleBOOKINGS.GetStringValue("LOCATION")));
                //Parent:PROPERTY_CODE    'Parent:PROPERTY_CODE
                strText.Append(" AND ").Append(flePROPERTIES.ElementOwner("BEDS")).Append(" = ").Append(Common.StringToField(fleBOOKINGS.GetStringValue("BEDS")));
                //Parent:PROPERTY_CODE    'Parent:PROPERTY_CODE
                strText.Append(" AND ").Append(flePROPERTIES.ElementOwner("PROPERTY_STYLE")).Append(" = ").Append(Common.StringToField(fleBOOKINGS.GetStringValue("PROPERTY_STYLE")));
                //Parent:PROPERTY_CODE    'Parent:PROPERTY_CODE
                strText.Append(" AND ").Append(flePROPERTIES.ElementOwner("BATHROOMS")).Append(" = ").Append(Common.StringToField(fleBOOKINGS.GetStringValue("BATHROOMS")));
                //Parent:PROPERTY_CODE    'Parent:PROPERTY_CODE
                strText.Append(" AND ").Append(flePROPERTIES.ElementOwner("PROPERTY_ID")).Append(" = ").Append(Common.StringToField(fleBOOKINGS.GetStringValue("PROPERTY_ID")));
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

        private OracleFileObject fleBOOKING_LETTERS;
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

        private OracleFileObject fleLOCATIONS;

        private void fleLOCATIONS_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleLOCATIONS.ElementOwner("LOCATION")).Append(" = ").Append(Common.StringToField(fleBOOKINGS.GetStringValue("LOCATION")));

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

        private DInteger D_PP1_SURCHARGE = new DInteger(8);
        private void D_PP1_SURCHARGE_GetValue(ref decimal Value)
        {

            try
            {
                Value = fleBOOKING_DEBTS.GetDecimalValue("PP1_SURCHARGE") + fleBALANCE_DEBTS.GetDecimalValue("PP1_SURCHARGE");


            }
            catch (CustomApplicationException ex)
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
                Value = fleBOOKING_DEBTS.GetDecimalValue("PP2_SURCHARGE") + fleBALANCE_DEBTS.GetDecimalValue("PP2_SURCHARGE");


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DInteger D_TERM_SURCHARGE = new DInteger(8);
        private void D_TERM_SURCHARGE_GetValue(ref decimal Value)
        {

            try
            {
                Value = fleBOOKING_DEBTS.GetDecimalValue("TERM_SURCHARGE") + fleBALANCE_DEBTS.GetDecimalValue("TERM_SURCHARGE");


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DInteger D_TOTAL = new DInteger(8);
        private void D_TOTAL_GetValue(ref decimal Value)
        {

            try
            {
                Value = fleBOOKINGS.GetDecimalValue("BOOKING_CHARGE") + D_PP1_SURCHARGE.Value + D_PP2_SURCHARGE.Value + D_TERM_SURCHARGE.Value;


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DCharacter D_DOW = new DCharacter(3);
        private void D_DOW_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (1 == QDesign.NULL(QDesign.PHMod(QDesign.Days(fleBOOKINGS.GetDecimalValue("BOOKING_DATE")), 7)))
                {
                    CurrentValue = "MON";
                }
                else if (2 == QDesign.NULL(QDesign.PHMod(QDesign.Days(fleBOOKINGS.GetDecimalValue("BOOKING_DATE")), 7)))
                {
                    CurrentValue = "TUE";
                }
                else if (3 == QDesign.NULL(QDesign.PHMod(QDesign.Days(fleBOOKINGS.GetDecimalValue("BOOKING_DATE")), 7)))
                {
                    CurrentValue = "WED";
                }
                else if (4 == QDesign.NULL(QDesign.PHMod(QDesign.Days(fleBOOKINGS.GetDecimalValue("BOOKING_DATE")), 7)))
                {
                    CurrentValue = "THU";
                }
                else if (5 == QDesign.NULL(QDesign.PHMod(QDesign.Days(fleBOOKINGS.GetDecimalValue("BOOKING_DATE")), 7)))
                {
                    CurrentValue = "FRI";
                }
                else if (6 == QDesign.NULL(QDesign.PHMod(QDesign.Days(fleBOOKINGS.GetDecimalValue("BOOKING_DATE")), 7)))
                {
                    CurrentValue = "SAT";
                }
                else if (0 == QDesign.NULL(QDesign.PHMod(QDesign.Days(fleBOOKINGS.GetDecimalValue("BOOKING_DATE")), 7)))
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
        private DDecimal D_OPTION_DATE = new DDecimal();
        private void D_OPTION_DATE_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0m;
                if ((QDesign.NULL(D_DOW.Value) == QDesign.NULL("MON") || QDesign.NULL(D_DOW.Value) == QDesign.NULL("TUE") || QDesign.NULL(D_DOW.Value) == QDesign.NULL("WED") || QDesign.NULL(D_DOW.Value) == QDesign.NULL("THU")))
                {
                    CurrentValue = QDesign.PhDate(QDesign.Days(fleBOOKINGS.GetDecimalValue("BOOKING_DATE")) + 1);
                }
                else if (QDesign.NULL(D_DOW.Value) == QDesign.NULL("SAT"))
                {
                    CurrentValue = QDesign.PhDate(QDesign.Days(fleBOOKINGS.GetDecimalValue("BOOKING_DATE")) + 2);
                }
                else if (QDesign.NULL(D_DOW.Value) == QDesign.NULL("FRI"))
                {
                    CurrentValue = QDesign.PhDate(QDesign.Days(fleBOOKINGS.GetDecimalValue("BOOKING_DATE")) + 3);
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
        private DInteger D_DAYS_AHEAD = new DInteger(8);
        private void D_DAYS_AHEAD_GetValue(ref decimal Value)
        {

            try
            {
                Value = (QDesign.Days(fleBOOKINGS.GetDecimalValue("START_DATE")) - QDesign.Days(QDesign.SysDate(ref m_cnnQUERY)));


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DCharacter D_OWNER_BOOKING = new DCharacter(1);
        private void D_OWNER_BOOKING_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if ((QDesign.NULL(QDesign.Substring(fleBOOKINGS.GetStringValue("INVESTOR"), 1, 3)) == QDesign.NULL("999") || QDesign.NULL(fleBOOKINGS.GetStringValue("INVESTOR")) == QDesign.NULL("99ADM")) && QDesign.NULL(fleBOOKINGS.GetStringValue("INVESTOR")) != QDesign.NULL("999SH"))
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
        private DCharacter D_TRAVEL_MESSAGE = new DCharacter(78);
        private void D_TRAVEL_MESSAGE_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if ((QDesign.NULL(fleLOCATIONS.GetStringValue("LOCATION")) != QDesign.NULL("SS") && QDesign.NULL(fleLOCATIONS.GetStringValue("LOCATION")) != QDesign.NULL("MH")) && D_DAYS_AHEAD.Value <= 337)
                {
                    CurrentValue = "REMINDER - ASK IF WE CAN HELP WITH TRAVEL SERVICES?";
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
        private DCharacter D_WITHIN_28DAYS = new DCharacter(1);
        private void D_WITHIN_28DAYS_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if ((D_BOOKDATE_14.Value >= D_START_DATE.Value) || (D_BOOKDATE_28.Value >= D_START_DATE.Value))
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
        private DCharacter D_DUE_NOW_TEXT = new DCharacter(8);
        private void D_DUE_NOW_TEXT_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(flePROPERTIES.GetStringValue("GROUPING")) == QDesign.NULL("SHHL") || QDesign.NULL(flePROPERTIES.GetStringValue("DEPOSIT_REQUIRED")) == QDesign.NULL("Y"))
                {
                    CurrentValue = "Due Now";
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
                if (QDesign.NULL(flePROPERTIES.GetStringValue("GROUPING")) == QDesign.NULL("SHHL") || QDesign.NULL(flePROPERTIES.GetStringValue("DEPOSIT_REQUIRED")) == QDesign.NULL("Y"))
                {
                    CurrentValue = fleBOOKING_DEBTS.GetDecimalValue("DEBT_AMOUNT");
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
        private CoreCharacter T_UPDATE_OK;
        private CoreCharacter T_INSTANT_CONF;
        private CoreCharacter T_INSTANT_DELETE;
        private DCharacter D_BACKOUT = new DCharacter(120);
        private void D_BACKOUT_GetValue(ref string Value)
        {

            try
            {

                // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

                Value = "echo `Backout of book0500.qks by `" + UserID + "Ref:" + T_BOOKING_REF.Value + " on `date` >> $LOG/backout.book0500";


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DCharacter D_SENDTO = new DCharacter(45);
        private void D_SENDTO_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;

                // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

                //if (QDesign.NULL("unixlive") == QDesign.NULL(GETSYSTEMVAL("HPSUSAN"))) {
                //    CurrentValue = " >>/rma/trans/bookings/" + fleBOOKINGS.GetStringValue("BOOKING_REF") + ".rec";
                //} else {
                //    CurrentValue = " >>$DATAX/bookings-" + fleBOOKINGS.GetStringValue("BOOKING_REF") + ".rec";
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

                Value = QDesign.Pack("echo " + QDesign.Substring(QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8), 7, 2) + "/" + QDesign.Substring(QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8), 5, 2) + "/" + QDesign.Substring(QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8), 1, 4) + "," + QDesign.Substring(QDesign.ASCII(QDesign.SysTime(ref m_cnnQUERY), 8), 1, 2) + "." + QDesign.Substring(QDesign.ASCII(QDesign.SysTime(ref m_cnnQUERY), 8), 3, 2) + "," + UserID + "," + fleEMAILS.GetStringValue("INVESTOR") + "," + T_BOOKING_REF.Value + "," + fleBOOKINGS.GetStringValue("PROPERTY_ID") + "," + QDesign.Substring(QDesign.ASCII(fleBOOKINGS.GetDecimalValue("BOOKING_CHARGE"), 8), 1, 6) + "." + QDesign.Substring(QDesign.ASCII(fleBOOKINGS.GetDecimalValue("BOOKING_CHARGE"), 8), 7, 2) + "," + QDesign.ASCII(fleBOOKINGS.GetDecimalValue("BOOKING_POINTS"), 8) + "," + QDesign.Substring(QDesign.ASCII(fleBOOKINGS.GetDecimalValue("START_DATE"), 8), 7, 2) + "/" + QDesign.Substring(QDesign.ASCII(fleBOOKINGS.GetDecimalValue("START_DATE"), 8), 5, 2) + "/" + QDesign.Substring(QDesign.ASCII(fleBOOKINGS.GetDecimalValue("START_DATE"), 8), 1, 4) + "," + QDesign.Substring(QDesign.ASCII(fleBOOKINGS.GetDecimalValue("END_DATE"), 8), 7, 2) + "/" + QDesign.Substring(QDesign.ASCII(fleBOOKINGS.GetDecimalValue("END_DATE"), 8), 5, 2) + "/" + QDesign.Substring(QDesign.ASCII(fleBOOKINGS.GetDecimalValue("END_DATE"), 8), 1, 4) + "book0500.qks" + D_SENDTO.Value);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DCharacter D_PUBLIC_BOND = new DCharacter(1);
        private void D_PUBLIC_BOND_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(fleM_INVESTORS.GetStringValue("CUSTOMER_TYPE")) == QDesign.NULL("T") || QDesign.NULL(fleM_INVESTORS.GetStringValue("CUSTOMER_TYPE")) == QDesign.NULL("V") || QDesign.NULL(fleM_INVESTORS.GetStringValue("CUSTOMER_TYPE")) == QDesign.NULL("S"))
                {
                    CurrentValue = "P";
                }
                else
                {
                    CurrentValue = "B";
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

        #endregion

        #region "Standard Generated Procedures"

        #region "Grid Field Declarations"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 07/12/2013 1:50:15 PM

        //# No code was generated or needed for this region.

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 07/12/2013 1:50:15 PM

        //# No code was generated or needed for this region.

        #endregion

        #region "Transaction Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 07/12/2013 1:50:15 PM

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
            fleBOOKING_LETTERS.Transaction = m_trnTRANS_UPDATE;
            fleEMAILS.Transaction = m_trnTRANS_UPDATE;


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 07/12/2013 1:50:15 PM

        //#-----------------------------------------
        //# InitializeFiles Procedure.
        //#-----------------------------------------

        protected override void InitializeFiles()
        {

            try
            {
                Initialize_TRANS_UPDATE();
                fleBOOKING_DEBTS.Connection = m_cnnQUERY;
                fleBALANCE_DEBTS.Connection = m_cnnQUERY;
                fleM_INVESTORS.Connection = m_cnnQUERY;
                flePROPERTIES.Connection = m_cnnQUERY;
                fleCORR_ADDRESS.Connection = m_cnnQUERY;
                fleLOCATIONS.Connection = m_cnnQUERY;


            }
            catch (CustomApplicationException ex)
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
                fleBOOKING_DEBTS.Dispose();
                fleBALANCE_DEBTS.Dispose();
                fleM_INVESTORS.Dispose();
                flePROPERTIES.Dispose();
                fleBOOKING_LETTERS.Dispose();
                fleCORR_ADDRESS.Dispose();
                fleLOCATIONS.Dispose();
                fleEMAILS.Dispose();


            }
            catch (CustomApplicationException ex)
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
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 07/12/2013 1:50:15 PM
        //#-----------------------------------------
        protected override void DisplayFormatting()
        {
            try
            {
                Thread.Sleep(200);
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:50:15 PM
                Display(ref fldBOOKINGS_INVESTOR);
                Display(ref fldM_INVESTORS_CORR_NAME);
                Display(ref fldBOOKINGS_BOOKING_REF);
                Display(ref fldBOOKINGS_PROPERTY_CODE);
                Display(ref fldBOOKINGS_START_DATE);
                Display(ref fldBOOKINGS_END_DATE);
                Display(ref fldBOOKINGS_START_WEEK);
                Display(ref fldBOOKINGS_END_WEEK);
                Display(ref fldBOOKINGS_BOOKING_DATE);
                Display(ref fldBOOKINGS_CONFIRM_DATE);
                Display(ref fldBOOKINGS_BOOKING_POINTS);
                Display(ref fldBOOKINGS_BOOKING_CHARGE);
                Display(ref fldBOOKINGS_POINTS_ADJUST);
                Display(ref fldD_TERM_SURCHARGE);
                Display(ref fldBOOKINGS_USER_LOGON);
                Display(ref fldD_PP1_SURCHARGE);
                Display(ref fldBOOKINGS_BOOKING_STATUS);
                Display(ref fldD_PP2_SURCHARGE);
                Display(ref fldBOOKINGS_ENT_YEAR);
                Display(ref fldD_TOTAL);
                Display(ref fldBOOKINGS_LONG_STAY);
                Display(ref fldBOOKINGS_TERM_SURCHARGEPER);
                Display(ref fldD_DUE_NOW_TEXT);
                Display(ref fldD_DUE_NOW);
                Display(ref fldBOOKINGS_BK_ENTITLEMENT);
                Display(ref fldBOOKINGS_BK_BF_TRANSFER);
                Display(ref fldBOOKINGS_BK_BF_EOY);
                Display(ref fldBOOKINGS_BK_OVERDRAFT);
                Display(ref fldBOOKINGS_BK_ADDON);
                Display(ref fldBOOKINGS_BK_PURCHASE);
                Display(ref fldBOOKINGS_BK_SUSPENSE);
                Display(ref fldBOOKINGS_BK_FORF_POINTS);
                Display(ref fldT_EMAIL_MSG);
                Display(ref fldT_EMAIL_OK);
                Display(ref fldEMAILS_EMAIL);
                Display(ref fldT_CONFIRM);
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
        //# Do not delete, modify or move it.  Updated: 07/12/2013 1:50:15 PM

        //#-----------------------------------------
        //# BindFields Procedure.
        //#-----------------------------------------

        public override void BindFields()
        {
            try
            {
                fldBOOKINGS_INVESTOR.Bind(fleBOOKINGS);
                fldM_INVESTORS_CORR_NAME.Bind(fleM_INVESTORS);
                fldBOOKINGS_BOOKING_REF.Bind(fleBOOKINGS);
                fldBOOKINGS_PROPERTY_CODE.Bind(BOOKINGS_PROPERTY_CODE);
                fldBOOKINGS_START_DATE.Bind(fleBOOKINGS);
                fldBOOKINGS_END_DATE.Bind(fleBOOKINGS);
                fldBOOKINGS_START_WEEK.Bind(fleBOOKINGS);
                fldBOOKINGS_END_WEEK.Bind(fleBOOKINGS);
                fldBOOKINGS_BOOKING_DATE.Bind(fleBOOKINGS);
                fldBOOKINGS_CONFIRM_DATE.Bind(fleBOOKINGS);
                fldBOOKINGS_BOOKING_POINTS.Bind(fleBOOKINGS);
                fldBOOKINGS_BOOKING_CHARGE.Bind(fleBOOKINGS);
                fldBOOKINGS_POINTS_ADJUST.Bind(fleBOOKINGS);
                fldD_TERM_SURCHARGE.Bind(D_TERM_SURCHARGE);
                fldBOOKINGS_USER_LOGON.Bind(fleBOOKINGS);
                fldD_PP1_SURCHARGE.Bind(D_PP1_SURCHARGE);
                fldBOOKINGS_BOOKING_STATUS.Bind(fleBOOKINGS);
                fldD_PP2_SURCHARGE.Bind(D_PP2_SURCHARGE);
                fldBOOKINGS_ENT_YEAR.Bind(fleBOOKINGS);
                fldD_TOTAL.Bind(D_TOTAL);
                fldBOOKINGS_LONG_STAY.Bind(fleBOOKINGS);
                fldBOOKINGS_TERM_SURCHARGEPER.Bind(fleBOOKINGS);
                fldD_DUE_NOW_TEXT.Bind(D_DUE_NOW_TEXT);
                fldD_DUE_NOW.Bind(D_DUE_NOW);
                fldBOOKINGS_BK_ENTITLEMENT.Bind(fleBOOKINGS);
                fldBOOKINGS_BK_BF_TRANSFER.Bind(fleBOOKINGS);
                fldBOOKINGS_BK_BF_EOY.Bind(fleBOOKINGS);
                fldBOOKINGS_BK_OVERDRAFT.Bind(fleBOOKINGS);
                fldBOOKINGS_BK_ADDON.Bind(fleBOOKINGS);
                fldBOOKINGS_BK_PURCHASE.Bind(fleBOOKINGS);
                fldBOOKINGS_BK_SUSPENSE.Bind(fleBOOKINGS);
                fldBOOKINGS_BK_FORF_POINTS.Bind(fleBOOKINGS);
                fldT_EMAIL_MSG.Bind(T_EMAIL_MSG);
                fldT_EMAIL_OK.Bind(T_EMAIL_OK);
                fldEMAILS_EMAIL.Bind(fleEMAILS);
                fldT_CONFIRM.Bind(T_CONFIRM);

            }
            catch (CustomApplicationException ex)
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



        protected override void SaveParamsReceived()
        {

            try
            {
                SaveReceivingParams(T_BOOKING_REF, T_BALANCE);


            }
            catch (CustomApplicationException ex)
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
                Receiving(T_BOOKING_REF, T_BALANCE);


            }
            catch (CustomApplicationException ex)
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



        private void fldT_EMAIL_OK_Edit()
        {

            try
            {

                if (QDesign.NULL(T_EMAIL_OK.Value) == QDesign.NULL("N"))
                {
                    T_INVESTOR.Value = fleBOOKINGS.GetStringValue("INVESTOR");
                    T_NEW_EMAIL_OK.Value = "N";
                    //RunScreen("BONDEMAL.QKC", RunScreenModes.Find, T_NEW_EMAIL_OK, T_INVESTOR);
                    T_EMAIL_OK.Value = T_NEW_EMAIL_OK.Value;
                    Display(ref fldT_EMAIL_OK);
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



        private void fldT_EMAIL_OK_Process()
        {

            try
            {

                if (QDesign.NULL(T_NEW_EMAIL_OK.Value) == QDesign.NULL("Y"))
                {
                    T_EMAIL_OK.Value = T_NEW_EMAIL_OK.Value;
                    Display(ref fldT_EMAIL_OK);
                    // --> GET EMAILS <--

                    fleEMAILS.GetData(GetDataOptions.IsOptional);
                    // --> End GET EMAILS <--
                    Display(ref fldEMAILS_EMAIL);
                }
                if (QDesign.NULL(T_EMAIL_OK.Value) != QDesign.NULL("Y"))
                {
                    Information(QDesign.NULL("The above bondholder email address will been marked as invalid"));
                    // TODO: May need to fix manually
                }
                T_EMAIL_MSG.Value = " ";
                Display(ref fldT_EMAIL_MSG);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldT_CONFIRM_Input()
        {

            try
            {

                // --> GET BOOKINGS <--
                m_strWhere = new StringBuilder(" WHERE ");
                m_strWhere.Append(" ").Append(fleBOOKINGS.ElementOwner("BOOKING_REF")).Append(" = ");
                m_strWhere.Append(Common.StringToField(T_BOOKING_REF.Value));

                fleBOOKINGS.GetData(m_strWhere.ToString());
                // --> End GET BOOKINGS <--
                if (QDesign.NULL(fleBOOKINGS.GetStringValue("BOOKING_STATUS")) == QDesign.NULL("CF"))
                {
                    Severe("52058");
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



        private void fldT_CONFIRM_Edit()
        {

            try
            {

                if (QDesign.NULL(T_CONFIRM.Value) == QDesign.NULL("R") && QDesign.NULL(D_PUBLIC_BOND.Value) == QDesign.NULL("P"))
                {
                    ErrorMessage("52059");
                }
                if (QDesign.NULL(T_CONFIRM.Value) != QDesign.NULL("C") && QDesign.NULL(fleM_INVESTORS.GetStringValue("CUSTOMER_TYPE")) == QDesign.NULL("I"))
                {
                    ErrorMessage("52060");
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



        private void fldT_CONFIRM_Process()
        {

            try
            {

                fleBOOKINGS.set_SetValue("SPARE_NUM", 999);
                if (QDesign.NULL(T_CONFIRM.Value) == QDesign.NULL("C"))
                {
                    if (QDesign.NULL(T_BALANCE.Value) < 0)
                    {
                        ErrorMessage("52061");
                    }
                    else
                    {
                        fleBOOKINGS.set_SetValue("CORE_OPTION", " ");
                        fleBOOKINGS.set_SetValue("CONFIRM_DATE", T_CONFIRM_DATE.Value);
                    }
                }
                if (QDesign.NULL(T_CONFIRM.Value) == QDesign.NULL("O"))
                {
                    fleBOOKINGS.set_SetValue("BOOKING_STATUS", "RS");
                    fleBOOKINGS.set_SetValue("CORE_OPTION", "O");
                    fleBOOKINGS.set_SetValue("CONFIRM_DATE", D_OPTION_DATE.Value);
                }
                if (QDesign.NULL(T_CONFIRM.Value) == QDesign.NULL("R"))
                {
                    fleBOOKINGS.set_SetValue("BOOKING_STATUS", "RS");
                    fleBOOKINGS.set_SetValue("CORE_OPTION", " ");
                    fleBOOKINGS.set_SetValue("CONFIRM_DATE", T_CONFIRM_DATE.Value);
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

                if (QDesign.NULL(fleM_INVESTORS.GetStringValue("CUSTOMER_TYPE")) == QDesign.NULL("I") && QDesign.NULL(T_CONFIRM.Value) != QDesign.NULL("C"))
                {
                    ErrorMessage("52062");
                }
                if (QDesign.NULL(T_CONFIRM.Value) == QDesign.NULL("R") && QDesign.NULL(D_PUBLIC_BOND.Value) == QDesign.NULL("P"))
                {
                    ErrorMessage("52063");
                }
                fleBOOKINGS.set_SetValue("CONFIRM_TIME", 0);
                if (QDesign.NULL(fleBOOKINGS.GetStringValue("INVESTOR")) == QDesign.NULL("999SH") || QDesign.NULL(fleM_INVESTORS.GetStringValue("CUSTOMER_TYPE")) == QDesign.NULL("I"))
                {
                    // --> GET CORR_ADDRESS <--
                    fleCORR_ADDRESS.GetData();
                    // --> End GET CORR_ADDRESS <--
                    if (!AccessOk)
                    {
                        ErrorMessage("52064");
                    }
                }
                if ((QDesign.NULL(T_CONFIRM.Value) == QDesign.NULL("R") || QDesign.NULL(T_CONFIRM.Value) == QDesign.NULL(" ")) && (QDesign.NULL(D_WITHIN_28DAYS.Value) != QDesign.NULL("Y") || QDesign.NULL(QDesign.Substring(flePROPERTIES.GetStringValue("GROUPING"), 1, 3)) == QDesign.NULL("SHH") || QDesign.NULL(flePROPERTIES.GetStringValue("DEPOSIT_REQUIRED")) == QDesign.NULL("Y")))
                {
                    fleBOOKING_LETTERS.set_SetValue("BOOKING_REF", T_BOOKING_REF.Value);
                    fleBOOKING_LETTERS.set_SetValue("PRINTED", "N");
                    fleBOOKING_LETTERS.set_SetValue("RECORD_STATUS", "RS");
                    fleBOOKING_LETTERS.PutData();
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


        protected override bool PostUpdate()
        {


            try
            {

                T_UPDATE_OK.Value = "Y";
                m_blnCommandOK = RunCommand(D_SENDTOSTORE.ToString());
                // TODO: Check source code.  Manual process may be required.
                if (QDesign.NULL(T_EMAIL_OK.Value) != QDesign.NULL(fleEMAILS.GetStringValue("VALID_YN")))
                {
                    // --> GET EMAILS <--

                    fleEMAILS.GetData(GetDataOptions.IsOptional);
                    // --> End GET EMAILS <--
                    if (AccessOk)
                    {
                        if (QDesign.NULL(fleEMAILS.GetStringValue("EMAIL")) == QDesign.NULL(" "))
                        {
                            fleEMAILS.set_SetValue("VALID_YN", " ");
                        }
                        else
                        {
                            fleEMAILS.set_SetValue("VALID_YN", T_EMAIL_OK.Value);
                        }
                        fleEMAILS.PutData(true);
                    }
                }
                if (QDesign.NULL(T_CONFIRM.Value) == QDesign.NULL("C"))
                {
                    T_INSTANT_CONF.Value = "Y";
                    if (QDesign.NULL(QDesign.Substring(fleBOOKINGS.GetStringValue("INVESTOR"), 1, 2)) != QDesign.NULL("TN") && QDesign.NULL(fleBOOKINGS.GetStringValue("INVESTOR")) != QDesign.NULL("999SH"))
                    {
                        T_CONFIRM_REF.Value = fleBOOKINGS.GetStringValue("BOOKING_REF");
                        //RunScreen("CONFIRM.QKC", RunScreenModes.Find, T_CONFIRM_REF, T_INSTANT_CONF, T_INSTANT_DELETE);
                        object[] arrRunscreen = { T_CONFIRM_REF, T_INSTANT_CONF, T_INSTANT_DELETE };
                        RunScreen(new CONFIRM(), RunScreenModes.Find, ref arrRunscreen);
                        T_CONFIRM_REF.Value = " ";
                    }
                    else
                    {
                        if (QDesign.NULL(QDesign.Substring(fleBOOKINGS.GetStringValue("INVESTOR"), 1, 2)) == QDesign.NULL("TN"))
                        {
                            //RunScreen("CONFTEN.QKC", RunScreenModes.Find, T_BOOKING_REF, T_INSTANT_CONF, T_INSTANT_DELETE);
                        }
                        else
                        {
                            //RunScreen("CONFSHHL.QKC", RunScreenModes.Find, T_BOOKING_REF);
                        }
                    }
                }
                if (QDesign.NULL(T_POST.Value) == QDesign.NULL("Y") && QDesign.NULL(T_CONFIRM.Value) == QDesign.NULL("C"))
                {
                    T_AUTOPOST.Value = "Y";
                    //RunScreen("POSTCONF.QKC", RunScreenModes.Entry, T_AUTOPOST, T_BOOKING_REF);
                }

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


        protected override bool PostFind()
        {


            try
            {

                fleBOOKINGS.set_SetValue("CONFIRM_TIME", 9999);
                T_CONFIRM_DATE.Value = fleBOOKINGS.GetDecimalValue("CONFIRM_DATE");
                T_START_DATE.Value = fleBOOKINGS.GetDecimalValue("START_DATE");
                if (QDesign.NULL(T_BALANCE.Value) < 0)
                {
                    T_CONFIRM.Value = "R";
                }
                if (QDesign.NULL(T_FIRST_TIME.Value) == QDesign.NULL(" "))
                {
                    if (QDesign.NULL(fleBOOKINGS.GetStringValue("INVESTOR")) == QDesign.NULL("999SH"))
                    {
                        //RunScreen("BOOKADDR.QKC", RunScreenModes.Entry, T_BOOKING_REF);
                    }
                    Push(dsrDesigner_CONF);
                    // TODO: May require manual processes (PUSH verb).
                    T_FIRST_TIME.Value = "N";
                }
                // --> GET EMAILS <--

                fleEMAILS.GetData(GetDataOptions.IsOptional);
                // --> End GET EMAILS <--
                if (!AccessOk)
                {
                    Severe("52065");
                }
                Display(ref fldEMAILS_EMAIL);

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


        private bool Internal_ACCEPT_CONFIRM()
        {


            try
            {

                Accept(ref fldT_CONFIRM);

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


        private bool Internal_EMAIL_MESSAGE()
        {


            try
            {

                T_EMAIL_MSG.Value = "Please check the current bond email address is correct";
                Display(ref fldT_EMAIL_MSG);

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

                Internal_EMAIL_MESSAGE();
                Accept(ref fldT_EMAIL_OK);
                Internal_ACCEPT_CONFIRM();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_CONF_Click(object sender, System.EventArgs e)
        {

            try
            {

                Internal_EMAIL_MESSAGE();
                Accept(ref fldT_EMAIL_OK);
                Internal_ACCEPT_CONFIRM();


            }
            catch (CustomApplicationException ex)
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

                T_INVESTOR.Value = fleBOOKINGS.GetStringValue("INVESTOR");
                T_START_DATE.Value = fleBOOKINGS.GetDecimalValue("START_DATE");
                T_END_DATE.Value = fleBOOKINGS.GetDecimalValue("END_DATE");
                T_LOCATION.Value = fleBOOKINGS.GetStringValue("LOCATION");
                //RunScreen("BOOKFLTS.QKC", RunScreenModes.Find, T_INVESTOR, T_LOCATION, T_START_DATE, T_END_DATE);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_POST_Click(object sender, System.EventArgs e)
        {

            try
            {

                T_POST.Value = "Y";
                Information("42011");


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }


        protected override bool Backout()
        {


            try
            {

                m_blnCommandOK = RunCommand(D_BACKOUT.ToString());
                // TODO: Check source code.  Manual process may be required.
                m_blnCommandOK = RunCommand(D_SENDTOSTORE.ToString());
                // TODO: Check source code.  Manual process may be required.

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
                m_strWhere = new StringBuilder(GetWhereCondition(fleBOOKINGS.ElementOwner("BOOKING_REF"), T_BOOKING_REF.Value, ref blnAddWhere));
                fleBOOKINGS.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);

                BOOKINGS_PROPERTY_CODE.Value = fleBOOKINGS.GetStringValue("LOCATION") + fleBOOKINGS.GetStringValue("BEDS") + fleBOOKINGS.GetStringValue("PROPERTY_STYLE").PadRight(2, ' ') +
                    fleBOOKINGS.GetStringValue("BATHROOMS") + "-" + fleBOOKINGS.GetStringValue("PROPERTY_ID");




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
                Page.PageTitle = "BOOKING RECORD DETAILS";
                



            }
            catch (CustomApplicationException ex)
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
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 07/12/2013 1:50:15 PM
        //#-----------------------------------------
        protected override bool Update()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:50:15 PM
                fleBOOKINGS.PutData();
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

        #endregion

        #endregion

    }

}
