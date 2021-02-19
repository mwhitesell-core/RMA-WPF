
#region "Screen Comments"

// ---------------------------------------------------------------;
// system;       H P B  Booking system                         ;
// ;
// program;      BOOK0200                                      ;
// ;
// task;         display those properties that qualify from    ;
// selection criteria from previous screen       ;
// files:        SCREEN-PROPERTY     Build and displayed       ;
// PROPERTY-YR-PRDS    Designer                  ;
// ;
// screens                                                     ;
// called by;    BOOK0100    Investor selection screen         ;
// calling;      BOOK0300    The provisional booking screen    ;
// ;
// subprograms;  <<none>>                                      ;
// ;
// ---------------------------------------------------------------;
// F  -  DH 20/01/90  Allow access by complete property id  
// ---------------------------------------------------------------;
// 30/08/95 - Receive USER-SEC-FILE and check security level before
// calling BOOK0300.qkc.
// --------------------------------------------------------------------
// 12/09/95 - Only display properties that have at least one day free,
// or the flag t-show-all (passed from prop0100) =  Y 
// --------------------------------------------------------------------
// 12/09/95 - Build SCREEN-PROPERTY to 200 records.
// --------------------------------------------------------------------
// 12/02/96 - Stop screen getting stuck in `More` box.
// --------------------------------------------------------------------
// 12/02/96 - Allow call of screen WAITLIST.
// --------------------------------------------------------------------
// 18/03/97 - Add Fax facility
// --------------------------------------------------------------------
// 15/05/97 - Move screen postioning to line 25 from 49
// --------------------------------------------------------------------
// 21/05/97 - build SCREEN-PRPTY to 400 Rrecords
// --------------------------------------------------------------------
// 23/05/97 - build SCREEN-PRPTY to 1100 Records (as there over 1000
// properties on the system)
// --------------------------------------------------------------------
// 28/08/97 - If user = theme then set T`s  to  . 
// --------------------------------------------------------------------
// 20/05/98 - Call screen UCHARGE2.qkc by entering 99 in action box
// --------------------------------------------------------------------
// 03/07/00 - Major changes to the Files and the way this program works.
// KSAM files PROPERTIES and BOOKING-PERIODS changed to IMAGE.
// Access is now via either LOCATION or AREA keys, instead of
// a generic search down property-bk-key.
// ---------------------------------------------------------------------
// 10/09/02 - copied version from qksnew dated Jan 2002, because the
// qks version was somehow out of date.
// ---------------------------------------------------------------------
// 24/10/02 - either run BOOK0300 or BOOKSHHL
// ---------------------------------------------------------------------
// 23/05/03 - Added noid to fields so they wont be `searched` on
// ---------------------------------------------------------------------
// 26/11/03 - Call BOOKSHHL.QKC if grouping[1:3] =  SHH  , so that both
// SHHL and SHHT are selected.
// ---------------------------------------------------------------------
// 05/04/04 - added field m-year to top of screen.
// ---------------------------------------------------------------------
// 21/11/05 - Added prop-comm4 and 5. Now just displays 2 properties
// ---------------------------------------------------------------------
// 07.12.06 ME  SHHL properties can now be booked by bondholders.
// ---------------------------------------------------------------------
// 15.02.08 ME  Mark closed properies  CCCCCCC  so they cannot be booked.
// ---------------------------------------------------------------------
// 27.08.08 ME  Add code to check for in progress web bookings.
// ---------------------------------------------------------------------
// 27/10/08 RC  Don`t allow the public to book Bond properties
// ---------------------------------------------------------------------
// 03.02.09 ME  Display points charge under each period available.
// ---------------------------------------------------------------------
// 11.02.09 ME  Make provision to hold Long Term booking requests.
// ---------------------------------------------------------------------
// 26/06/09 RC  Call the Flights screens
// ---------------------------------------------------------------------
// 19.10.10 RM  Allow Lookup using Location and Property ID only
// ---------------------------------------------------------------------
// 16.11.10 ME  Change Long term booking request letter from  L  to  Q 
// ---------------------------------------------------------------------
// 25.03.11 RM  Make space to show all of property-name
// ---------------------------------------------------------------------
// 27.04.12 ME  Retire rentout.qks.
// ---------------------------------------------------------------------
// 05.12.12 ME Changed for Signature Villas (customer-type = V).
// ---------------------------------------------------------------------
// 08/09/95  was 55
// M-START-DATE, &
// M-END-DATE, &
// 28/07/09

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

    partial class BOOK0200 : BasePage
    {

        #region " Form Designer Generated Code "





        public BOOK0200()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "BOOK0200";

            //# Set the ACTIVITIES for the screen.
            this.ChangeActivity = true;
            this.FindActivity = true;
            this.DeleteActivity = false;
            this.EntryActivity = false;
            this.UseAcceptProcessing = true;
            DisableAppend = true;
            this.GridDesigner = "dsrDesigner_01";
            dsrDesigner_01.DefaultFirstRowInGrid = true;

            
        }

        #endregion

        private void Page_Load(object sender, RoutedEventArgs e)
        {
            SetVariables();
            dsrDesigner_01.Click += dsrDesigner_01_Click;
            dsrDesigner_COMM.Click += dsrDesigner_COMM_Click;
            dsrDesigner_PROP.Click += dsrDesigner_PROP_Click;
            dsrDesigner_LD.Click += dsrDesigner_LD_Click;
            dsrDesigner_WAIT.Click += dsrDesigner_WAIT_Click;
            dsrDesigner_OWN.Click += dsrDesigner_OWN_Click;
            dsrDesigner_99.Click += dsrDesigner_99_Click;
            dsrDesigner_WEB.Click += dsrDesigner_WEB_Click;
            dsrDesigner_FLIGHTS.Click += dsrDesigner_FLIGHTS_Click;
            dtlSCREEN_PROPERTY.EditClick += dtl_EditClick;

            Page_Load();

           
            // TODO: If any DESIGNER procedures function on occurring FILES or TEMPORARIES, set the grid's AllowSelectRowButton property to TRUE.



            // TODO: The following FIELD(S) on the form are redefine elements.  Manual steps may be required:
            //       SCREEN_PROPERTY.PROPERTY_CODE


        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            fleM_INVESTORS = new OracleFileObject(this, FileTypes.Master, 0, "INDEXED", "M_INVESTORS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleUSER_SEC_FILE = new OracleFileObject(this, FileTypes.Master, 0, "INDEXED", "USER_SEC_FILE", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleLOCN_BK_COMMENTS = new OracleFileObject(this, FileTypes.Master, 0, "INDEXED", "D_LOCN_BK_COMM", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            M_PETS = new CoreCharacter("M_PETS", 1, this, Common.cEmptyString);
            M_YEAR = new CoreCharacter("M_YEAR", 4, this, Common.cEmptyString);
            M_START_WEEK = new CoreDecimal("M_START_WEEK", 2, this);
            M_END_WEEK = new CoreDecimal("M_END_WEEK", 2, this);
            M_INDEX_KEY = new CoreCharacter("M_INDEX_KEY", 15, this, Common.cEmptyString);
            M_START_DATE = new CoreDate("M_START_DATE", this);
            M_END_DATE = new CoreDate("M_END_DATE", this);
            M_BOOKED = new CoreCharacter("M_BOOKED", 1, this, Common.cEmptyString);
            M_PROPERTY_TYPE = new CoreCharacter("M_PROPERTY_TYPE", 6, this, Common.cEmptyString);
            M_PROPERTY_CODE = new CoreCharacter("M_PROPERTY_CODE", 4, this, Common.cEmptyString);
            M_RENTOUT = new CoreCharacter("M_RENTOUT", 1, this, Common.cEmptyString);
            T_SHOW_ALL = new CoreCharacter("T_SHOW_ALL", 1, this, Common.cEmptyString);
            T_SPECIFIC_WEEKS = new CoreCharacter("T_SPECIFIC_WEEKS", 1, this, Common.cEmptyString);
            T_AREA = new CoreCharacter("T_AREA", 4, this, Common.cEmptyString);
            T_INDEX_KEY = new CoreCharacter("T_INDEX_KEY", 15, this, Common.cEmptyString);
            M_SPLIT_WEEKS = new CoreCharacter("M_SPLIT_WEEKS", 2, this, Common.cEmptyString);
            M_DISABLED = new CoreCharacter("M_DISABLED", 2, this, Common.cEmptyString);
            M_CHANGEOVER = new CoreCharacter("M_CHANGEOVER", 2, this, Common.cEmptyString);
            X_BOOKING_REF = new CoreCharacter("X_BOOKING_REF", 8, this, Common.cEmptyString);
            T_BALANCE = new CoreInteger("T_BALANCE", 8, this);
            fleSCREEN_PROPERTY = new OracleFileObject(this, FileTypes.Primary, 2, "SEQUENTIAL", "SCREEN_PROPERTY", "", true, false, false, 0, "m_trnTRANS_UPDATE", FileType.TempFile);
            flePROPERTIES = new OracleFileObject(this, FileTypes.Reference, fleSCREEN_PROPERTY, "INDEXED", "PROPERTIES", "", true, false, false, 0, "m_cnnQUERY");
            flePROP_COMMENTS = new OracleFileObject(this, FileTypes.Reference, fleSCREEN_PROPERTY, "INDEXED", "PROP_COMMENTS", "", true, false, false, 0, "m_cnnQUERY");
            flePROPERTY_YEARS = new OracleFileObject(this, FileTypes.Designer, 0, "INDEXED", "PROPERTY_YEARS", "", true, false, false, 0, "m_trnTRANS_UPDATE");
            flePROPERTY_YEARS_DTL = new OracleFileObject(this, FileTypes.Detail, 53, "INDEXED", "PROPERTY_YEARS_DTL", "", true, false, false, 0, "m_trnTRANS_UPDATE");
            flePASSING_PROPERTY = new OracleFileObject(this, FileTypes.Designer, 0, "INDEXED", "PROPERTY_YEARS", "PASSING_PROPERTY", false, false, false, 0, "m_trnTRANS_UPDATE");
            flePUT_PROP = new OracleFileObject(this, FileTypes.Designer, 0, "SEQUENTIAL", "SCREEN_PROPERTY", "PUT_PROP", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.TempFile);
            fleBOOKING_PERIODS = new OracleFileObject(this, FileTypes.Designer, 0, "INDEXED", "BOOKING_PERIODS", "", true, false, false, 0, "m_trnTRANS_UPDATE");
            fleBOOKING_PERIODS_DTL = new OracleFileObject(this, FileTypes.Detail, 53, "INDEXED", "BOOKING_PERIOD_DTL", "", true, false, false, 0, "m_trnTRANS_UPDATE");
            fleREF_PROPS = new OracleFileObject(this, FileTypes.Designer, 0, "INDEXED", "PROPERTIES", "REF_PROPS", true, false, false, 0, "m_trnTRANS_UPDATE");
            fleLOCATIONS = new OracleFileObject(this, FileTypes.Reference, 0, "INDEXED", "LOCATIONS", "", false, false, false, 0, "m_cnnQUERY");
            T_OCCURRENCE = new CoreDecimal("T_OCCURRENCE", 2, this);
            T_QUALIFY = new CoreInteger("T_QUALIFY", 2, this);
            T_COUNT = new CoreInteger("T_COUNT", 2, this);
            T_START_WEEK = new CoreInteger("T_START_WEEK", 2, this);
            T_END_WEEK = new CoreInteger("T_END_WEEK", 2, this);
            T_SET_PERIODS = new CoreCharacter("T_SET_PERIODS", 1, this, "N");
            T_PASS_LOCATION = new CoreCharacter("T_PASS_LOCATION", 2, this, Common.cEmptyString);
            T_PASS_INVESTOR = new CoreCharacter("T_PASS_INVESTOR", 8, this, Common.cEmptyString);
            T_PASS_SCREEN = new CoreCharacter("T_PASS_SCREEN", 4, this, Common.cEmptyString);
            T_START_DATE = new CoreDate("T_START_DATE", this);
            T_END_DATE = new CoreDate("T_END_DATE", this);
            T_MORE = new CoreCharacter("T_MORE", 1, this, Common.cEmptyString);
            T_PUT_PROP = new CoreCharacter("T_PUT_PROP", 1, this, Common.cEmptyString);
            T_CALENDER_EXISTS = new CoreCharacter("T_CALENDER_EXISTS", 1, this, Common.cEmptyString);
            T_WAIT_DATE_FROM = new CoreDate("T_WAIT_DATE_FROM", this, ResetTypes.ResetAtMode);
            T_WAIT_DATE_TO = new CoreDate("T_WAIT_DATE_TO", this, ResetTypes.ResetAtMode);
            T_COMMAND = new CoreCharacter("T_COMMAND", 80, this, Common.cEmptyString);
            T_FAX_NO = new CoreCharacter("T_FAX_NO", 16, this, Common.cEmptyString);
            T_LOCATION = new CoreCharacter("T_LOCATION", 2, this, Common.cEmptyString);
            T_PROPERTY_ID = new CoreCharacter("T_PROPERTY_ID", 4, this, Common.cEmptyString);
            T_PROPERTY_CODE = new CoreCharacter("T_PROPERTY_CODE", 10, this, Common.cEmptyString);
            T_WEB_YEAR = new CoreCharacter("T_WEB_YEAR", 4, this, Common.cEmptyString);
            T_WEB_START_WEEK = new CoreCharacter("T_WEB_START_WEEK", 2, this, Common.cEmptyString);
            T_WEB_END_WEEK = new CoreCharacter("T_WEB_END_WEEK", 2, this, Common.cEmptyString);
            T_WEB_LOCATION = new CoreCharacter("T_WEB_LOCATION", 2, this, Common.cEmptyString);
            T_WEB_PROP_ID = new CoreCharacter("T_WEB_PROP_ID", 4, this, Common.cEmptyString);
            T_BOOKING_NOW = new CoreCharacter("T_BOOKING_NOW", 1, this, "N");
            T_WEB_BOOKED = new CoreCharacter("T_WEB_BOOKED", 1, this, Common.cEmptyString);
            T_PBK_YEAR = new CoreCharacter("T_PBK_YEAR", 10, this, fleSCREEN_PROPERTY, Common.cEmptyString);
            T_PERIOD_1 = new CoreInteger("T_PERIOD_1", 2, this, fleSCREEN_PROPERTY, 0m);
            T_POINTS_1 = new CoreInteger("T_POINTS_1", 8, this, fleSCREEN_PROPERTY, 0m);
            T_POINTS_2 = new CoreInteger("T_POINTS_2", 8, this, fleSCREEN_PROPERTY, 0m);
            T_POINTS_3 = new CoreInteger("T_POINTS_3", 8, this, fleSCREEN_PROPERTY, 0m);
            T_POINTS_4 = new CoreInteger("T_POINTS_4", 8, this, fleSCREEN_PROPERTY, 0m);
            T_POINTS_5 = new CoreInteger("T_POINTS_5", 8, this, fleSCREEN_PROPERTY, 0m);
            T_POINTS_6 = new CoreInteger("T_POINTS_6", 8, this, fleSCREEN_PROPERTY, 0m);
            T_POINTS_7 = new CoreInteger("T_POINTS_7", 8, this, fleSCREEN_PROPERTY, 0m);
            T_POINTS_8 = new CoreInteger("T_POINTS_8", 8, this, fleSCREEN_PROPERTY, 0m);
            T_POINTS_9 = new CoreInteger("T_POINTS_9", 8, this, fleSCREEN_PROPERTY, 0m);
            T_POINTS_10 = new CoreInteger("T_POINTS_10", 8, this, fleSCREEN_PROPERTY, 0m);
            T_POINTS_1A = new CoreCharacter("T_POINTS_1A", 6, this, fleSCREEN_PROPERTY, Common.cEmptyString);
            T_POINTS_2A = new CoreCharacter("T_POINTS_2A", 6, this, fleSCREEN_PROPERTY, Common.cEmptyString);
            T_POINTS_3A = new CoreCharacter("T_POINTS_3A", 6, this, fleSCREEN_PROPERTY, Common.cEmptyString);
            T_POINTS_4A = new CoreCharacter("T_POINTS_4A", 6, this, fleSCREEN_PROPERTY, Common.cEmptyString);
            T_POINTS_5A = new CoreCharacter("T_POINTS_5A", 6, this, fleSCREEN_PROPERTY, Common.cEmptyString);
            T_POINTS_6A = new CoreCharacter("T_POINTS_6A", 6, this, fleSCREEN_PROPERTY, Common.cEmptyString);
            T_POINTS_7A = new CoreCharacter("T_POINTS_7A", 6, this, fleSCREEN_PROPERTY, Common.cEmptyString);
            T_POINTS_8A = new CoreCharacter("T_POINTS_8A", 6, this, fleSCREEN_PROPERTY, Common.cEmptyString);
            T_POINTS_9A = new CoreCharacter("T_POINTS_9A", 6, this, fleSCREEN_PROPERTY, Common.cEmptyString);
            T_POINTS_10A = new CoreCharacter("T_POINTS_10A", 6, this, fleSCREEN_PROPERTY, Common.cEmptyString);
            T_LT_INVESTOR = new CoreCharacter("T_LT_INVESTOR", 8, this, " ");
            T_INVESTOR = new CoreCharacter("T_INVESTOR", 8, this, Common.cEmptyString);
            SCREEN_PROPERTY_PROPERTY_CODE = new CoreCharacter("SCREEN_PROPERTY_PROPERTY_CODE", 10, this, fleSCREEN_PROPERTY, Common.cEmptyString);

            D_YEAR_KEY.GetValue += D_YEAR_KEY_GetValue;
            flePROPERTIES.Access += flePROPERTIES_Access;
            fleBOOKING_PERIODS_DTL.SelectIf += fleBOOKING_PERIODS_DTL_SelectIf;
            flePROP_COMMENTS.Access += flePROP_COMMENTS_Access;
            flePASSING_PROPERTY.Access += flePASSING_PROPERTY_Access;
            fleREF_PROPS.Access += fleREF_PROPS_Access;
            flePUT_PROP.SetItemFinals += flePUT_PROP_SetItemFinals;
            D_CHANGEOVER_DAY.GetValue += D_CHANGEOVER_DAY_GetValue;
            D_SCREEN_PROPERTY.GetValue += D_SCREEN_PROPERTY_GetValue;
            D_PURGE_PROPERTY.GetValue += D_PURGE_PROPERTY_GetValue;
            D_MID_POINT.GetValue += D_MID_POINT_GetValue;
            D_START.GetValue += D_START_GetValue;
            D_END.GetValue += D_END_GetValue;
            D_DATE.GetValue += D_DATE_GetValue;
            D_INFO_LINE.GetValue += D_INFO_LINE_GetValue;
            D_DAY_1.GetValue += D_DAY_1_GetValue;
            D_DAY_2.GetValue += D_DAY_2_GetValue;
            D_DAY_3.GetValue += D_DAY_3_GetValue;
            D_DAY_4.GetValue += D_DAY_4_GetValue;
            D_DAY_5.GetValue += D_DAY_5_GetValue;
            D_DAY_6.GetValue += D_DAY_6_GetValue;
            D_DAY_7.GetValue += D_DAY_7_GetValue;
            D_WEEK_STATUS.GetValue += D_WEEK_STATUS_GetValue;
            D_DAYS_FREE.GetValue += D_DAYS_FREE_GetValue;
            D_ON_REQUEST_DATE.GetValue += D_ON_REQUEST_DATE_GetValue;
            D_ON_REQUEST.GetValue += D_ON_REQUEST_GetValue;
            D_GUARANTEE.GetValue += D_GUARANTEE_GetValue;
            D_LOC_LINK.GetValue += D_LOC_LINK_GetValue;
            D_YEAR_CLOSED.GetValue += D_YEAR_CLOSED_GetValue;
            D_MMDD_CLOSED.GetValue += D_MMDD_CLOSED_GetValue;
            D_MMDD_1.GetValue += D_MMDD_1_GetValue;
            D_MMDD_2.GetValue += D_MMDD_2_GetValue;
            D_MMDD_3.GetValue += D_MMDD_3_GetValue;
            D_MMDD_4.GetValue += D_MMDD_4_GetValue;
            D_MMDD_5.GetValue += D_MMDD_5_GetValue;
            D_MMDD_6.GetValue += D_MMDD_6_GetValue;
            D_MMDD_7.GetValue += D_MMDD_7_GetValue;
            D_MMDD_8.GetValue += D_MMDD_8_GetValue;
            D_MMDD_9.GetValue += D_MMDD_9_GetValue;
            D_MMDD_10.GetValue += D_MMDD_10_GetValue;
            D_PUBLIC_BOND.GetValue += D_PUBLIC_BOND_GetValue;

        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;
            fleBOOKING_PERIODS_DTL.SelectIf -= fleBOOKING_PERIODS_DTL_SelectIf;
            D_YEAR_KEY.GetValue -= D_YEAR_KEY_GetValue;
            flePROPERTIES.Access -= flePROPERTIES_Access;
            flePROP_COMMENTS.Access -= flePROP_COMMENTS_Access;
            flePASSING_PROPERTY.Access -= flePASSING_PROPERTY_Access;
            fleREF_PROPS.Access -= fleREF_PROPS_Access;
            flePUT_PROP.SetItemFinals -= flePUT_PROP_SetItemFinals;
            D_CHANGEOVER_DAY.GetValue -= D_CHANGEOVER_DAY_GetValue;
            D_SCREEN_PROPERTY.GetValue -= D_SCREEN_PROPERTY_GetValue;
            D_PURGE_PROPERTY.GetValue -= D_PURGE_PROPERTY_GetValue;
            D_MID_POINT.GetValue -= D_MID_POINT_GetValue;
            D_START.GetValue -= D_START_GetValue;
            D_END.GetValue -= D_END_GetValue;
            D_DATE.GetValue -= D_DATE_GetValue;
            D_INFO_LINE.GetValue -= D_INFO_LINE_GetValue;
            D_DAY_1.GetValue -= D_DAY_1_GetValue;
            D_DAY_2.GetValue -= D_DAY_2_GetValue;
            D_DAY_3.GetValue -= D_DAY_3_GetValue;
            D_DAY_4.GetValue -= D_DAY_4_GetValue;
            D_DAY_5.GetValue -= D_DAY_5_GetValue;
            D_DAY_6.GetValue -= D_DAY_6_GetValue;
            D_DAY_7.GetValue -= D_DAY_7_GetValue;
            D_WEEK_STATUS.GetValue -= D_WEEK_STATUS_GetValue;
            D_DAYS_FREE.GetValue -= D_DAYS_FREE_GetValue;
            D_ON_REQUEST_DATE.GetValue -= D_ON_REQUEST_DATE_GetValue;
            D_ON_REQUEST.GetValue -= D_ON_REQUEST_GetValue;
            D_GUARANTEE.GetValue -= D_GUARANTEE_GetValue;
            D_LOC_LINK.GetValue -= D_LOC_LINK_GetValue;
            D_YEAR_CLOSED.GetValue -= D_YEAR_CLOSED_GetValue;
            D_MMDD_CLOSED.GetValue -= D_MMDD_CLOSED_GetValue;
            D_MMDD_1.GetValue -= D_MMDD_1_GetValue;
            D_MMDD_2.GetValue -= D_MMDD_2_GetValue;
            D_MMDD_3.GetValue -= D_MMDD_3_GetValue;
            D_MMDD_4.GetValue -= D_MMDD_4_GetValue;
            D_MMDD_5.GetValue -= D_MMDD_5_GetValue;
            D_MMDD_6.GetValue -= D_MMDD_6_GetValue;
            D_MMDD_7.GetValue -= D_MMDD_7_GetValue;
            D_MMDD_8.GetValue -= D_MMDD_8_GetValue;
            D_MMDD_9.GetValue -= D_MMDD_9_GetValue;
            D_MMDD_10.GetValue -= D_MMDD_10_GetValue;
            D_PUBLIC_BOND.GetValue -= D_PUBLIC_BOND_GetValue;

            dsrDesigner_01.Click -= dsrDesigner_01_Click;
            dsrDesigner_COMM.Click -= dsrDesigner_COMM_Click;
            dsrDesigner_PROP.Click -= dsrDesigner_PROP_Click;
            dsrDesigner_LD.Click -= dsrDesigner_LD_Click;
            dsrDesigner_WAIT.Click -= dsrDesigner_WAIT_Click;
            dsrDesigner_OWN.Click -= dsrDesigner_OWN_Click;
            dsrDesigner_99.Click -= dsrDesigner_99_Click;
            dsrDesigner_WEB.Click -= dsrDesigner_WEB_Click;
            dsrDesigner_FLIGHTS.Click -= dsrDesigner_FLIGHTS_Click;
            dtlSCREEN_PROPERTY.EditClick -= dtl_EditClick;


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
        private OracleFileObject fleLOCN_BK_COMMENTS;
        private CoreCharacter M_PETS;
        private CoreCharacter M_YEAR;
        private CoreDecimal M_START_WEEK;
        private CoreDecimal M_END_WEEK;
        private CoreCharacter M_INDEX_KEY;
        private CoreDate M_START_DATE;
        private CoreDate M_END_DATE;
        private CoreCharacter M_BOOKED;
        private CoreCharacter M_PROPERTY_TYPE;
        private CoreCharacter M_PROPERTY_CODE;
        private CoreCharacter M_RENTOUT;
        private CoreCharacter T_SHOW_ALL;
        private CoreCharacter T_SPECIFIC_WEEKS;
        private CoreCharacter T_AREA;
        private CoreCharacter T_INDEX_KEY;
        private CoreCharacter M_SPLIT_WEEKS;
        private CoreCharacter M_DISABLED;
        private CoreCharacter M_CHANGEOVER;
        private CoreCharacter X_BOOKING_REF;
        private CoreInteger T_BALANCE;
        private DCharacter D_YEAR_KEY = new DCharacter(14);
        private void D_YEAR_KEY_GetValue(ref string Value)
        {

            try
            {
                Value = M_PROPERTY_TYPE.Value + M_PROPERTY_CODE.Value + M_YEAR.Value;


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private OracleFileObject fleSCREEN_PROPERTY;
        private OracleFileObject flePROPERTIES;

        private void flePROPERTIES_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(flePROPERTIES.ElementOwner("LOCATION")).Append(" = ").Append(Common.StringToField(fleSCREEN_PROPERTY.GetStringValue("LOCATION")));
                strText.Append(" AND ").Append(flePROPERTIES.ElementOwner("BEDS")).Append(" = ").Append(Common.StringToField(fleSCREEN_PROPERTY.GetStringValue("BEDS")));
                strText.Append(" AND ").Append(flePROPERTIES.ElementOwner("PROPERTY_STYLE")).Append(" = ").Append(Common.StringToField(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_STYLE")));
                strText.Append(" AND ").Append(flePROPERTIES.ElementOwner("BATHROOMS")).Append(" = ").Append(Common.StringToField(fleSCREEN_PROPERTY.GetStringValue("BATHROOMS")));
                strText.Append(" AND ").Append(flePROPERTIES.ElementOwner("PROPERTY_ID")).Append(" = ").Append(Common.StringToField(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_ID")));
                
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

        private OracleFileObject flePROP_COMMENTS;

        private void flePROP_COMMENTS_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(flePROP_COMMENTS.ElementOwner("PROP_COMM_KEY")).Append(" = ").Append(Common.StringToField(fleSCREEN_PROPERTY.GetStringValue("LOCATION") + fleSCREEN_PROPERTY.GetStringValue("BEDS") + fleSCREEN_PROPERTY.GetStringValue("PROPERTY_STYLE") + fleSCREEN_PROPERTY.GetStringValue("BATHROOMS") + fleSCREEN_PROPERTY.GetStringValue("PROPERTY_ID")));
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

        private OracleFileObject flePROPERTY_YEARS;
        private OracleFileObject flePROPERTY_YEARS_DTL;

        private void flePROPERTY_YEARS_SelectIf(ref string SelectIfClause)
        {


            try
            {
                StringBuilder strSQL = new StringBuilder("");

                strSQL.Append(" (    ").Append(flePROPERTY_YEARS.ElementOwner("YEAR")).Append(" =  ").Append(Common.StringToField(M_YEAR.Value)).Append("  AND ");
                strSQL.Append(" (    ").Append(flePROPERTY_YEARS.ElementOwner("BEDS")).Append(" = Substring (  ").Append(Common.StringToField(M_PROPERTY_TYPE.Value)).Append("  ,  3 ,  1 ) OR ");
                strSQL.Append("  Substring (  ").Append(Common.StringToField(M_PROPERTY_TYPE.Value)).Append("  ,  3 ,  1 ) =  ' ' ) AND ");
                strSQL.Append(" (    ").Append(flePROPERTY_YEARS.ElementOwner("PROPERTY_STYLE")).Append(" = Substring (  ").Append(Common.StringToField(M_PROPERTY_TYPE.Value)).Append("  ,  4 ,  2 ) OR ");
                strSQL.Append("  Substring (  ").Append(Common.StringToField(M_PROPERTY_TYPE.Value)).Append("  ,  4 ,  2 ) =  '  ' ) AND ");
                strSQL.Append(" (    ").Append(flePROPERTY_YEARS.ElementOwner("BATHROOMS")).Append(" = Substring (  ").Append(Common.StringToField(M_PROPERTY_TYPE.Value)).Append("  ,  6 ,  1 ) OR ");
                strSQL.Append("  Substring (  ").Append(Common.StringToField(M_PROPERTY_TYPE.Value)).Append("  ,  6 ,  1 ) =  ' ' ) AND ");
                strSQL.Append(" (    ").Append(flePROPERTY_YEARS.ElementOwner("PROPERTY_ID")).Append(" =  ").Append(Common.StringToField(M_PROPERTY_CODE.Value)).Append("  OR ");
                strSQL.Append("   ").Append(Common.StringToField(M_PROPERTY_CODE.Value)).Append("  =  ' ' ))");
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

        private OracleFileObject flePASSING_PROPERTY;

        private void flePASSING_PROPERTY_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(flePASSING_PROPERTY.ElementOwner("LOCATION")).Append(" = ").Append(Common.StringToField(fleSCREEN_PROPERTY.GetStringValue("LOCATION")));
                //Parent:PROPERTY_YEAR    'Parent:PROPERTY_YEAR
                strText.Append(" AND ").Append(flePASSING_PROPERTY.ElementOwner("BEDS")).Append(" = ").Append(Common.StringToField(fleSCREEN_PROPERTY.GetStringValue("BEDS")));
                //Parent:PROPERTY_YEAR    'Parent:PROPERTY_YEAR
                strText.Append(" AND ").Append(flePASSING_PROPERTY.ElementOwner("PROPERTY_STYLE")).Append(" = ").Append(Common.StringToField(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_STYLE")));
                //Parent:PROPERTY_YEAR    'Parent:PROPERTY_YEAR
                strText.Append(" AND ").Append(flePASSING_PROPERTY.ElementOwner("BATHROOMS")).Append(" = ").Append(Common.StringToField(fleSCREEN_PROPERTY.GetStringValue("BATHROOMS")));
                //Parent:PROPERTY_YEAR    'Parent:PROPERTY_YEAR
                strText.Append(" AND ").Append(flePASSING_PROPERTY.ElementOwner("PROPERTY_ID")).Append(" = ").Append(Common.StringToField(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_ID")));
                //Parent:PROPERTY_YEAR    'Parent:PROPERTY_YEAR
                strText.Append(" AND ").Append(flePASSING_PROPERTY.ElementOwner("YEAR")).Append(" = ").Append(Common.StringToField(fleSCREEN_PROPERTY.GetStringValue("YEAR")));
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

        private OracleFileObject flePUT_PROP;

        private void flePUT_PROP_SetItemFinals()
        {

            try
            {
                flePUT_PROP.set_SetValue("LOCATION", flePROPERTY_YEARS.GetStringValue("LOCATION"));
                //Parent:PROPERTY_YEAR
                flePUT_PROP.set_SetValue("BEDS", flePROPERTY_YEARS.GetStringValue("BEDS"));
                //Parent:PROPERTY_YEAR
                flePUT_PROP.set_SetValue("PROPERTY_STYLE", flePROPERTY_YEARS.GetStringValue("PROPERTY_STYLE"));
                //Parent:PROPERTY_YEAR
                flePUT_PROP.set_SetValue("BATHROOMS", flePROPERTY_YEARS.GetStringValue("BATHROOMS"));
                //Parent:PROPERTY_YEAR
                flePUT_PROP.set_SetValue("PROPERTY_ID", flePROPERTY_YEARS.GetStringValue("PROPERTY_ID"));
                //Parent:PROPERTY_YEAR
                flePUT_PROP.set_SetValue("YEAR", flePROPERTY_YEARS.GetStringValue("YEAR"));
                //Parent:PROPERTY_YEAR


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }

        private OracleFileObject fleBOOKING_PERIODS_DTL;
        private void fleBOOKING_PERIODS_DTL_SelectIf(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append("  ").Append(fleBOOKING_PERIODS_DTL.ElementOwner("LOCATION")).Append(" = ").Append(Common.StringToField(fleBOOKING_PERIODS.GetStringValue("LOCATION")));
                strText.Append(" AND ").Append(fleBOOKING_PERIODS_DTL.ElementOwner("CHANGEOVER_DAY")).Append(" = ").Append(Common.StringToField(fleBOOKING_PERIODS.GetStringValue("CHANGEOVER_DAY")));
                strText.Append(" AND ").Append(fleBOOKING_PERIODS_DTL.ElementOwner("YEAR")).Append(" = ").Append(Common.StringToField(fleBOOKING_PERIODS.GetStringValue("YEAR")));
              
                
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
        private OracleFileObject fleREF_PROPS;

        private void fleREF_PROPS_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleREF_PROPS.ElementOwner("LOCATION")).Append(" = ").Append(Common.StringToField(flePROPERTY_YEARS.GetStringValue("LOCATION")));
                //Parent:PROPERTY_CODE    'Parent:PROPERTY_CODE
                strText.Append(" AND ").Append(fleREF_PROPS.ElementOwner("BEDS")).Append(" = ").Append(Common.StringToField(flePROPERTY_YEARS.GetStringValue("BEDS")));
                //Parent:PROPERTY_CODE    'Parent:PROPERTY_CODE
                strText.Append(" AND ").Append(fleREF_PROPS.ElementOwner("PROPERTY_STYLE")).Append(" = ").Append(Common.StringToField(flePROPERTY_YEARS.GetStringValue("PROPERTY_STYLE")));
                //Parent:PROPERTY_CODE    'Parent:PROPERTY_CODE
                strText.Append(" AND ").Append(fleREF_PROPS.ElementOwner("BATHROOMS")).Append(" = ").Append(Common.StringToField(flePROPERTY_YEARS.GetStringValue("BATHROOMS")));
                //Parent:PROPERTY_CODE    'Parent:PROPERTY_CODE
                strText.Append(" AND ").Append(fleREF_PROPS.ElementOwner("PROPERTY_ID")).Append(" = ").Append(Common.StringToField(flePROPERTY_YEARS.GetStringValue("PROPERTY_ID")));
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

        private OracleFileObject fleLOCATIONS;
        private CoreDecimal T_OCCURRENCE;
        private CoreInteger T_QUALIFY;
        private CoreInteger T_COUNT;
        private CoreInteger T_START_WEEK;
        private CoreInteger T_END_WEEK;
        private CoreCharacter T_SET_PERIODS;
        private CoreCharacter T_PASS_LOCATION;
        private CoreCharacter T_PASS_INVESTOR;
        private CoreCharacter T_PASS_SCREEN;
        private CoreDate T_START_DATE;
        private CoreDate T_END_DATE;
        private CoreCharacter T_MORE;
        private CoreCharacter T_PUT_PROP;
        private CoreCharacter T_CALENDER_EXISTS;
        private CoreDate T_WAIT_DATE_FROM;
        private CoreDate T_WAIT_DATE_TO;
        private CoreCharacter T_COMMAND;
        private CoreCharacter T_FAX_NO;
        private CoreCharacter T_LOCATION;
        private CoreCharacter T_PROPERTY_ID;
        private CoreCharacter T_PROPERTY_CODE;
        private CoreCharacter T_WEB_YEAR;
        private CoreCharacter T_WEB_START_WEEK;
        private CoreCharacter T_WEB_END_WEEK;
        private CoreCharacter T_WEB_LOCATION;
        private CoreCharacter T_WEB_PROP_ID;
        private CoreCharacter T_BOOKING_NOW;
        private CoreCharacter T_WEB_BOOKED;
        private CoreCharacter T_PBK_YEAR;
        private CoreInteger T_PERIOD_1;
        private CoreInteger T_POINTS_1;
        private CoreInteger T_POINTS_2;
        private CoreInteger T_POINTS_3;
        private CoreInteger T_POINTS_4;
        private CoreInteger T_POINTS_5;
        private CoreInteger T_POINTS_6;
        private CoreInteger T_POINTS_7;
        private CoreInteger T_POINTS_8;
        private CoreInteger T_POINTS_9;
        private CoreInteger T_POINTS_10;
        private CoreCharacter T_POINTS_1A;
        private CoreCharacter T_POINTS_2A;
        private CoreCharacter T_POINTS_3A;
        private CoreCharacter T_POINTS_4A;
        private CoreCharacter T_POINTS_5A;
        private CoreCharacter T_POINTS_6A;
        private CoreCharacter T_POINTS_7A;
        private CoreCharacter T_POINTS_8A;
        private CoreCharacter T_POINTS_9A;
        private CoreCharacter T_POINTS_10A;
        private CoreCharacter T_LT_INVESTOR;
        private CoreCharacter T_INVESTOR;
        private CoreCharacter SCREEN_PROPERTY_PROPERTY_CODE;
        private DCharacter D_CHANGEOVER_DAY = new DCharacter(2);
        private void D_CHANGEOVER_DAY_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if ((QDesign.NULL(fleREF_PROPS.GetStringValue("CHANGEOVER_DAY")) == "MO" || QDesign.NULL(fleREF_PROPS.GetStringValue("CHANGEOVER_DAY")) == "01"))
                {
                    CurrentValue = "MO";
                }
                else if ((QDesign.NULL(fleREF_PROPS.GetStringValue("CHANGEOVER_DAY")) == "TU" || QDesign.NULL(fleREF_PROPS.GetStringValue("CHANGEOVER_DAY")) == "02"))
                {
                    CurrentValue = "TU";
                }
                else if ((QDesign.NULL(fleREF_PROPS.GetStringValue("CHANGEOVER_DAY")) == "WD" || QDesign.NULL(fleREF_PROPS.GetStringValue("CHANGEOVER_DAY")) == "03"))
                {
                    CurrentValue = "WD";
                }
                else if ((QDesign.NULL(fleREF_PROPS.GetStringValue("CHANGEOVER_DAY")) == "TH" || QDesign.NULL(fleREF_PROPS.GetStringValue("CHANGEOVER_DAY")) == "04"))
                {
                    CurrentValue = "TH";
                }
                else if ((QDesign.NULL(fleREF_PROPS.GetStringValue("CHANGEOVER_DAY")) == "FR" || QDesign.NULL(fleREF_PROPS.GetStringValue("CHANGEOVER_DAY")) == "05"))
                {
                    CurrentValue = "FR";
                }
                else if ((QDesign.NULL(fleREF_PROPS.GetStringValue("CHANGEOVER_DAY")) == "ST" || QDesign.NULL(fleREF_PROPS.GetStringValue("CHANGEOVER_DAY")) == "06"))
                {
                    CurrentValue = "ST";
                }
                else if ((QDesign.NULL(fleREF_PROPS.GetStringValue("CHANGEOVER_DAY")) == "SU" || QDesign.NULL(fleREF_PROPS.GetStringValue("CHANGEOVER_DAY")) == "07"))
                {
                    CurrentValue = "SU";
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
        private DCharacter D_SCREEN_PROPERTY = new DCharacter(80);
        private void D_SCREEN_PROPERTY_GetValue(ref string Value)
        {

            try
            {

                // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

                Value = "echo `\\c` > $PHTEMP/SCPRPTY.dat";


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DCharacter D_PURGE_PROPERTY = new DCharacter(80);
        private void D_PURGE_PROPERTY_GetValue(ref string Value)
        {

            try
            {

                // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

                Value = "rm $PHTEMP/SCPRPTY.dat 2>/dev/null";


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DDecimal D_MID_POINT = new DDecimal(2);
        private void D_MID_POINT_GetValue(ref decimal Value)
        {

            try
            {

                // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

                Value = T_START_WEEK.Value + QDesign.Floor((T_END_WEEK.Value - T_START_WEEK.Value) / 2);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DDecimal D_START = new DDecimal(2);
        private void D_START_GetValue(ref decimal Value)
        {

            try
            {
                Value = D_MID_POINT.Value - 4;


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DDecimal D_END = new DDecimal(2);
        private void D_END_GetValue(ref decimal Value)
        {

            try
            {
                Value = D_MID_POINT.Value + 5;


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DCharacter D_DATE = new DCharacter(9);
        private void D_DATE_GetValue(ref string Value)
        {

            try
            {

                Value = QDesign.Substring(QDesign.ASCII(fleBOOKING_PERIODS_DTL.GetDecimalValue("START_DATE"), 8), 7, 2) + "/" + QDesign.Substring(QDesign.ASCII(fleBOOKING_PERIODS_DTL.GetDecimalValue("START_DATE"), 8), 5, 2) + QDesign.Substring(QDesign.ASCII(fleBOOKING_PERIODS_DTL.GetDecimalValue("START_DATE"), 8), 1, 4);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DCharacter D_INFO_LINE = new DCharacter(50);
        private void D_INFO_LINE_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(T_QUALIFY.Value) > 1)
                {
                    CurrentValue = QDesign.ASCII(T_QUALIFY.Value) + " PROPERTIES HAVE QUALIFIED";
                }
                else
                {
                    CurrentValue = "1 PROPERTY HAS QUALIFIED";
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
        private DCharacter D_DAY_1 = new DCharacter(1);
        private void D_DAY_1_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(flePROPERTY_YEARS_DTL.GetStringValue("DAY_1")) == QDesign.NULL(" ") || (QDesign.NULL(flePROPERTY_YEARS_DTL.GetStringValue("DAY_1")) == "T" && QDesign.NULL(UserID) == "theme"))
                {
                    CurrentValue = ".";
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
        private DCharacter D_DAY_2 = new DCharacter(1);
        private void D_DAY_2_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(flePROPERTY_YEARS_DTL.GetStringValue("DAY_2")) == QDesign.NULL(" ") || (QDesign.NULL(flePROPERTY_YEARS_DTL.GetStringValue("DAY_2")) == "T" && QDesign.NULL(UserID) == "theme"))
                {
                    CurrentValue = ".";
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
        private DCharacter D_DAY_3 = new DCharacter(1);
        private void D_DAY_3_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(flePROPERTY_YEARS_DTL.GetStringValue("DAY_3")) == QDesign.NULL(" ") || (QDesign.NULL(flePROPERTY_YEARS_DTL.GetStringValue("DAY_3")) == "T" && QDesign.NULL(UserID) == "theme"))
                {
                    CurrentValue = ".";
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
        private DCharacter D_DAY_4 = new DCharacter(1);
        private void D_DAY_4_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(flePROPERTY_YEARS_DTL.GetStringValue("DAY_4")) == QDesign.NULL(" ") || (QDesign.NULL(flePROPERTY_YEARS_DTL.GetStringValue("DAY_4")) == "T" && QDesign.NULL(UserID) == "theme"))
                {
                    CurrentValue = ".";
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
        private DCharacter D_DAY_5 = new DCharacter(1);
        private void D_DAY_5_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(flePROPERTY_YEARS_DTL.GetStringValue("DAY_5")) == QDesign.NULL(" ") || (QDesign.NULL(flePROPERTY_YEARS_DTL.GetStringValue("DAY_5")) == "T" && QDesign.NULL(UserID) == "theme"))
                {
                    CurrentValue = ".";
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
        private DCharacter D_DAY_6 = new DCharacter(1);
        private void D_DAY_6_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(flePROPERTY_YEARS_DTL.GetStringValue("DAY_6")) == QDesign.NULL(" ") || (QDesign.NULL(flePROPERTY_YEARS_DTL.GetStringValue("DAY_6")) == "T" && QDesign.NULL(UserID) == "theme"))
                {
                    CurrentValue = ".";
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
        private DCharacter D_DAY_7 = new DCharacter(1);
        private void D_DAY_7_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(flePROPERTY_YEARS_DTL.GetStringValue("DAY_7")) == QDesign.NULL(" ") || (QDesign.NULL(flePROPERTY_YEARS_DTL.GetStringValue("DAY_7")) == "T" && QDesign.NULL(UserID) == "theme"))
                {
                    CurrentValue = ".";
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
        private DCharacter D_WEEK_STATUS = new DCharacter(7);
        private void D_WEEK_STATUS_GetValue(ref string Value)
        {

            try
            {
                Value = D_DAY_1.Value + D_DAY_2.Value + D_DAY_3.Value + D_DAY_4.Value + D_DAY_5.Value + D_DAY_6.Value + D_DAY_7.Value;


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DCharacter D_DAYS_FREE = new DCharacter(1);
        private void D_DAYS_FREE_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(D_DAY_1.Value) == "." || QDesign.NULL(D_DAY_2.Value) == "." || QDesign.NULL(D_DAY_3.Value) == "." || QDesign.NULL(D_DAY_4.Value) == "." || QDesign.NULL(D_DAY_5.Value) == "." || QDesign.NULL(D_DAY_6.Value) == "." || QDesign.NULL(D_DAY_7.Value) == "." || QDesign.NULL(T_SHOW_ALL.Value) == "Y")
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
        private DDecimal D_ON_REQUEST_DATE = new DDecimal();
        private void D_ON_REQUEST_DATE_GetValue(ref decimal Value)
        {

            try
            {
                Value = QDesign.PhDate(QDesign.Days(QDesign.SysDate(ref m_cnnQUERY)) + flePROPERTIES.GetDecimalValue("ON_REQUEST_DAYS"));


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DCharacter D_ON_REQUEST = new DCharacter(15);
        private void D_ON_REQUEST_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;

                // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

                if (QDesign.NULL(flePROPERTIES.GetDecimalValue("ON_REQUEST_DAYS")) != 0)
                {
                    CurrentValue = "On Req " + QDesign.Substring(QDesign.ASCII(D_ON_REQUEST_DATE.Value), 7, 2) + "/" + QDesign.Substring(QDesign.ASCII(D_ON_REQUEST_DATE.Value), 5, 2) + "/" + QDesign.Substring(QDesign.ASCII(D_ON_REQUEST_DATE.Value), 3, 2);
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
        private DCharacter D_GUARANTEE = new DCharacter(3);
        private void D_GUARANTEE_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(flePROPERTIES.GetStringValue("GROUPING")) == "TENC")
                {
                    CurrentValue = "*G*";
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
        private DCharacter D_LOC_LINK = new DCharacter(70);
        private void D_LOC_LINK_GetValue(ref string Value)
        {

            try
            {

                // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

                Value = "http://ntserver/hpb/cgi-bin/proplinks.asp?prop=" + QDesign.Substring(M_PROPERTY_TYPE.Value, 1, 2);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DCharacter D_YEAR_CLOSED = new DCharacter(4);
        private void D_YEAR_CLOSED_GetValue(ref string Value)
        {

            try
            {
                Value = QDesign.Substring(QDesign.ASCII(QDesign.PhDate(QDesign.Days(flePROPERTIES.GetDecimalValue("DATE_CLOSED")) - 6), 8), 1, 4);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DCharacter D_MMDD_CLOSED = new DCharacter(4);
        private void D_MMDD_CLOSED_GetValue(ref string Value)
        {

            try
            {
                Value = QDesign.Substring(QDesign.ASCII(QDesign.PhDate(QDesign.Days(flePROPERTIES.GetDecimalValue("DATE_CLOSED")) - 6), 8), 5, 2) + QDesign.Substring(QDesign.ASCII(QDesign.PhDate(QDesign.Days(flePROPERTIES.GetDecimalValue("DATE_CLOSED")) - 6), 8), 7, 2);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DCharacter D_MMDD_1 = new DCharacter(4);
        private void D_MMDD_1_GetValue(ref string Value)
        {

            try
            {
                Value = QDesign.Substring(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_DATE_1"), 4, 2) + QDesign.Substring(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_DATE_1"), 1, 2);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DCharacter D_MMDD_2 = new DCharacter(4);
        private void D_MMDD_2_GetValue(ref string Value)
        {

            try
            {
                Value = QDesign.Substring(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_DATE_2"), 4, 2) + QDesign.Substring(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_DATE_2"), 1, 2);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DCharacter D_MMDD_3 = new DCharacter(4);
        private void D_MMDD_3_GetValue(ref string Value)
        {

            try
            {
                Value = QDesign.Substring(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_DATE_3"), 4, 2) + QDesign.Substring(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_DATE_3"), 1, 2);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DCharacter D_MMDD_4 = new DCharacter(4);
        private void D_MMDD_4_GetValue(ref string Value)
        {

            try
            {
                Value = QDesign.Substring(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_DATE_4"), 4, 2) + QDesign.Substring(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_DATE_4"), 1, 2);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DCharacter D_MMDD_5 = new DCharacter(4);
        private void D_MMDD_5_GetValue(ref string Value)
        {

            try
            {
                Value = QDesign.Substring(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_DATE_5"), 4, 2) + QDesign.Substring(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_DATE_5"), 1, 2);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DCharacter D_MMDD_6 = new DCharacter(4);
        private void D_MMDD_6_GetValue(ref string Value)
        {

            try
            {
                Value = QDesign.Substring(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_DATE_6"), 4, 2) + QDesign.Substring(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_DATE_6"), 1, 2);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DCharacter D_MMDD_7 = new DCharacter(4);
        private void D_MMDD_7_GetValue(ref string Value)
        {

            try
            {
                Value = QDesign.Substring(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_DATE_7"), 4, 2) + QDesign.Substring(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_DATE_7"), 1, 2);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DCharacter D_MMDD_8 = new DCharacter(4);
        private void D_MMDD_8_GetValue(ref string Value)
        {

            try
            {
                Value = QDesign.Substring(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_DATE_8"), 4, 2) + QDesign.Substring(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_DATE_8"), 1, 2);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DCharacter D_MMDD_9 = new DCharacter(4);
        private void D_MMDD_9_GetValue(ref string Value)
        {

            try
            {
                Value = QDesign.Substring(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_DATE_9"), 4, 2) + QDesign.Substring(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_DATE_9"), 1, 2);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DCharacter D_MMDD_10 = new DCharacter(4);
        private void D_MMDD_10_GetValue(ref string Value)
        {

            try
            {
                Value = QDesign.Substring(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_DATE_10"), 4, 2) + QDesign.Substring(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_DATE_10"), 1, 2);


            }
            catch (CustomApplicationException ex)
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
                if (QDesign.NULL(fleM_INVESTORS.GetStringValue("CUSTOMER_TYPE")) == "T" || QDesign.NULL(fleM_INVESTORS.GetStringValue("CUSTOMER_TYPE")) == "V" || QDesign.NULL(fleM_INVESTORS.GetStringValue("CUSTOMER_TYPE")) == "S")
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
        //# Do not delete, modify or move it.  Updated: 07/12/2013 1:49:40 PM

        protected TextBox fldSCREEN_PROPERTY_PROPERTY_CODE;
        protected TextBox fldPROPERTIES_CHANGEOVER_DAY;
        protected TextBox fldD_GUARANTEE;
        protected TextBox fldD_ON_REQUEST;
        protected TextBox fldPROPERTIES_PROPERTY_NAME;
        protected TextBox fldPROP_COMMENTS_PROP_COMM1;
        protected TextBox fldPROP_COMMENTS_PROP_COMM2;
        protected TextBox fldPROP_COMMENTS_PROP_COMM3;
        protected TextBox fldPROP_COMMENTS_PROP_COMM4;
        protected TextBox fldPROP_COMMENTS_PROP_COMM5;
        protected TextBox fldSCREEN_PROPERTY_PROPERTY_DATE_1;
        protected TextBox fldSCREEN_PROPERTY_PROPERTY_DATE_2;
        protected TextBox fldSCREEN_PROPERTY_PROPERTY_DATE_3;
        protected TextBox fldSCREEN_PROPERTY_PROPERTY_DATE_4;
        protected TextBox fldSCREEN_PROPERTY_PROPERTY_DATE_5;
        protected TextBox fldSCREEN_PROPERTY_PROPERTY_DATE_6;
        protected TextBox fldSCREEN_PROPERTY_PROPERTY_DATE_7;
        protected TextBox fldSCREEN_PROPERTY_PROPERTY_DATE_8;
        protected TextBox fldSCREEN_PROPERTY_PROPERTY_DATE_9;
        protected TextBox fldSCREEN_PROPERTY_PROPERTY_DATE_10;
        protected TextBox fldSCREEN_PROPERTY_PERIOD_1;
        protected TextBox fldSCREEN_PROPERTY_PERIOD_2;
        protected TextBox fldSCREEN_PROPERTY_PERIOD_3;
        protected TextBox fldSCREEN_PROPERTY_PERIOD_4;
        protected TextBox fldSCREEN_PROPERTY_PERIOD_5;
        protected TextBox fldSCREEN_PROPERTY_PERIOD_6;
        protected TextBox fldSCREEN_PROPERTY_PERIOD_7;
        protected TextBox fldSCREEN_PROPERTY_PERIOD_8;
        protected TextBox fldSCREEN_PROPERTY_PERIOD_9;
        protected TextBox fldSCREEN_PROPERTY_PERIOD_10;
        protected TextBox fldSCREEN_PROPERTY_WEEK_STATUS_1;
        protected TextBox fldSCREEN_PROPERTY_WEEK_STATUS_2;
        protected TextBox fldSCREEN_PROPERTY_WEEK_STATUS_3;
        protected TextBox fldSCREEN_PROPERTY_WEEK_STATUS_4;
        protected TextBox fldSCREEN_PROPERTY_WEEK_STATUS_5;
        protected TextBox fldSCREEN_PROPERTY_WEEK_STATUS_6;
        protected TextBox fldSCREEN_PROPERTY_WEEK_STATUS_7;
        protected TextBox fldSCREEN_PROPERTY_WEEK_STATUS_8;
        protected TextBox fldSCREEN_PROPERTY_WEEK_STATUS_9;
        protected TextBox fldSCREEN_PROPERTY_WEEK_STATUS_10;
        protected TextBox fldT_POINTS_1A;
        protected TextBox fldT_POINTS_2A;
        protected TextBox fldT_POINTS_3A;
        protected TextBox fldT_POINTS_4A;
        protected TextBox fldT_POINTS_5A;
        protected TextBox fldT_POINTS_6A;
        protected TextBox fldT_POINTS_7A;
        protected TextBox fldT_POINTS_8A;
        protected TextBox fldT_POINTS_9A;

        protected TextBox fldT_POINTS_10A;

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 07/12/2013 1:49:40 PM

        //#-----------------------------------------
        //# GetGridFieldObject Procedure.
        //#-----------------------------------------

        protected override void GetGridFieldObject(object DataListField, ref object CoreField, string Name)
        {

            try
            {
                switch (Name.ToUpper())
                {
                    case "FLDGRDSCREEN_PROPERTY_PROPERTY_CODE":
                        fldSCREEN_PROPERTY_PROPERTY_CODE = (TextBox)DataListField;
                        CoreField = fldSCREEN_PROPERTY_PROPERTY_CODE;
                        fldSCREEN_PROPERTY_PROPERTY_CODE.Bind(SCREEN_PROPERTY_PROPERTY_CODE);
                        break;
                    case "FLDGRDPROPERTIES_CHANGEOVER_DAY":
                        fldPROPERTIES_CHANGEOVER_DAY = (TextBox)DataListField;
                        CoreField = fldPROPERTIES_CHANGEOVER_DAY;
                        fldPROPERTIES_CHANGEOVER_DAY.Bind(flePROPERTIES);
                        break;
                    case "FLDGRDD_GUARANTEE":
                        fldD_GUARANTEE = (TextBox)DataListField;
                        CoreField = fldD_GUARANTEE;
                        fldD_GUARANTEE.Bind(D_GUARANTEE);
                        break;
                    case "FLDGRDD_ON_REQUEST":
                        fldD_ON_REQUEST = (TextBox)DataListField;
                        CoreField = fldD_ON_REQUEST;
                        fldD_ON_REQUEST.Bind(D_ON_REQUEST);
                        break;
                    case "FLDGRDPROPERTIES_PROPERTY_NAME":
                        fldPROPERTIES_PROPERTY_NAME = (TextBox)DataListField;
                        CoreField = fldPROPERTIES_PROPERTY_NAME;
                        fldPROPERTIES_PROPERTY_NAME.Bind(flePROPERTIES);
                        break;
                    case "FLDGRDPROP_COMMENTS_PROP_COMM1":
                        fldPROP_COMMENTS_PROP_COMM1 = (TextBox)DataListField;
                        CoreField = fldPROP_COMMENTS_PROP_COMM1;
                        fldPROP_COMMENTS_PROP_COMM1.Bind(flePROP_COMMENTS);
                        break;
                    case "FLDGRDPROP_COMMENTS_PROP_COMM2":
                        fldPROP_COMMENTS_PROP_COMM2 = (TextBox)DataListField;
                        CoreField = fldPROP_COMMENTS_PROP_COMM2;
                        fldPROP_COMMENTS_PROP_COMM2.Bind(flePROP_COMMENTS);
                        break;
                    case "FLDGRDPROP_COMMENTS_PROP_COMM3":
                        fldPROP_COMMENTS_PROP_COMM3 = (TextBox)DataListField;
                        CoreField = fldPROP_COMMENTS_PROP_COMM3;
                        fldPROP_COMMENTS_PROP_COMM3.Bind(flePROP_COMMENTS);
                        break;
                    case "FLDGRDPROP_COMMENTS_PROP_COMM4":
                        fldPROP_COMMENTS_PROP_COMM4 = (TextBox)DataListField;
                        CoreField = fldPROP_COMMENTS_PROP_COMM4;
                        fldPROP_COMMENTS_PROP_COMM4.Bind(flePROP_COMMENTS);
                        break;
                    case "FLDGRDPROP_COMMENTS_PROP_COMM5":
                        fldPROP_COMMENTS_PROP_COMM5 = (TextBox)DataListField;
                        CoreField = fldPROP_COMMENTS_PROP_COMM5;
                        fldPROP_COMMENTS_PROP_COMM5.Bind(flePROP_COMMENTS);
                        break;
                    case "FLDGRDSCREEN_PROPERTY_PROPERTY_DATE_1":
                        fldSCREEN_PROPERTY_PROPERTY_DATE_1 = (TextBox)DataListField;
                        CoreField = fldSCREEN_PROPERTY_PROPERTY_DATE_1;
                        fldSCREEN_PROPERTY_PROPERTY_DATE_1.Bind(fleSCREEN_PROPERTY);
                        break;
                    case "FLDGRDSCREEN_PROPERTY_PROPERTY_DATE_2":
                        fldSCREEN_PROPERTY_PROPERTY_DATE_2 = (TextBox)DataListField;
                        CoreField = fldSCREEN_PROPERTY_PROPERTY_DATE_2;
                        fldSCREEN_PROPERTY_PROPERTY_DATE_2.Bind(fleSCREEN_PROPERTY);
                        break;
                    case "FLDGRDSCREEN_PROPERTY_PROPERTY_DATE_3":
                        fldSCREEN_PROPERTY_PROPERTY_DATE_3 = (TextBox)DataListField;
                        CoreField = fldSCREEN_PROPERTY_PROPERTY_DATE_3;
                        fldSCREEN_PROPERTY_PROPERTY_DATE_3.Bind(fleSCREEN_PROPERTY);
                        break;
                    case "FLDGRDSCREEN_PROPERTY_PROPERTY_DATE_4":
                        fldSCREEN_PROPERTY_PROPERTY_DATE_4 = (TextBox)DataListField;
                        CoreField = fldSCREEN_PROPERTY_PROPERTY_DATE_4;
                        fldSCREEN_PROPERTY_PROPERTY_DATE_4.Bind(fleSCREEN_PROPERTY);
                        break;
                    case "FLDGRDSCREEN_PROPERTY_PROPERTY_DATE_5":
                        fldSCREEN_PROPERTY_PROPERTY_DATE_5 = (TextBox)DataListField;
                        CoreField = fldSCREEN_PROPERTY_PROPERTY_DATE_5;
                        fldSCREEN_PROPERTY_PROPERTY_DATE_5.Bind(fleSCREEN_PROPERTY);
                        break;
                    case "FLDGRDSCREEN_PROPERTY_PROPERTY_DATE_6":
                        fldSCREEN_PROPERTY_PROPERTY_DATE_6 = (TextBox)DataListField;
                        CoreField = fldSCREEN_PROPERTY_PROPERTY_DATE_6;
                        fldSCREEN_PROPERTY_PROPERTY_DATE_6.Bind(fleSCREEN_PROPERTY);
                        break;
                    case "FLDGRDSCREEN_PROPERTY_PROPERTY_DATE_7":
                        fldSCREEN_PROPERTY_PROPERTY_DATE_7 = (TextBox)DataListField;
                        CoreField = fldSCREEN_PROPERTY_PROPERTY_DATE_7;
                        fldSCREEN_PROPERTY_PROPERTY_DATE_7.Bind(fleSCREEN_PROPERTY);
                        break;
                    case "FLDGRDSCREEN_PROPERTY_PROPERTY_DATE_8":
                        fldSCREEN_PROPERTY_PROPERTY_DATE_8 = (TextBox)DataListField;
                        CoreField = fldSCREEN_PROPERTY_PROPERTY_DATE_8;
                        fldSCREEN_PROPERTY_PROPERTY_DATE_8.Bind(fleSCREEN_PROPERTY);
                        break;
                    case "FLDGRDSCREEN_PROPERTY_PROPERTY_DATE_9":
                        fldSCREEN_PROPERTY_PROPERTY_DATE_9 = (TextBox)DataListField;
                        CoreField = fldSCREEN_PROPERTY_PROPERTY_DATE_9;
                        fldSCREEN_PROPERTY_PROPERTY_DATE_9.Bind(fleSCREEN_PROPERTY);
                        break;
                    case "FLDGRDSCREEN_PROPERTY_PROPERTY_DATE_10":
                        fldSCREEN_PROPERTY_PROPERTY_DATE_10 = (TextBox)DataListField;
                        CoreField = fldSCREEN_PROPERTY_PROPERTY_DATE_10;
                        fldSCREEN_PROPERTY_PROPERTY_DATE_10.Bind(fleSCREEN_PROPERTY);
                        break;
                    case "FLDGRDSCREEN_PROPERTY_PERIOD_1":
                        fldSCREEN_PROPERTY_PERIOD_1 = (TextBox)DataListField;
                        CoreField = fldSCREEN_PROPERTY_PERIOD_1;
                        fldSCREEN_PROPERTY_PERIOD_1.Bind(fleSCREEN_PROPERTY);
                        break;
                    case "FLDGRDSCREEN_PROPERTY_PERIOD_2":
                        fldSCREEN_PROPERTY_PERIOD_2 = (TextBox)DataListField;
                        CoreField = fldSCREEN_PROPERTY_PERIOD_2;
                        fldSCREEN_PROPERTY_PERIOD_2.Bind(fleSCREEN_PROPERTY);
                        break;
                    case "FLDGRDSCREEN_PROPERTY_PERIOD_3":
                        fldSCREEN_PROPERTY_PERIOD_3 = (TextBox)DataListField;
                        CoreField = fldSCREEN_PROPERTY_PERIOD_3;
                        fldSCREEN_PROPERTY_PERIOD_3.Bind(fleSCREEN_PROPERTY);
                        break;
                    case "FLDGRDSCREEN_PROPERTY_PERIOD_4":
                        fldSCREEN_PROPERTY_PERIOD_4 = (TextBox)DataListField;
                        CoreField = fldSCREEN_PROPERTY_PERIOD_4;
                        fldSCREEN_PROPERTY_PERIOD_4.Bind(fleSCREEN_PROPERTY);
                        break;
                    case "FLDGRDSCREEN_PROPERTY_PERIOD_5":
                        fldSCREEN_PROPERTY_PERIOD_5 = (TextBox)DataListField;
                        CoreField = fldSCREEN_PROPERTY_PERIOD_5;
                        fldSCREEN_PROPERTY_PERIOD_5.Bind(fleSCREEN_PROPERTY);
                        break;
                    case "FLDGRDSCREEN_PROPERTY_PERIOD_6":
                        fldSCREEN_PROPERTY_PERIOD_6 = (TextBox)DataListField;
                        CoreField = fldSCREEN_PROPERTY_PERIOD_6;
                        fldSCREEN_PROPERTY_PERIOD_6.Bind(fleSCREEN_PROPERTY);
                        break;
                    case "FLDGRDSCREEN_PROPERTY_PERIOD_7":
                        fldSCREEN_PROPERTY_PERIOD_7 = (TextBox)DataListField;
                        CoreField = fldSCREEN_PROPERTY_PERIOD_7;
                        fldSCREEN_PROPERTY_PERIOD_7.Bind(fleSCREEN_PROPERTY);
                        break;
                    case "FLDGRDSCREEN_PROPERTY_PERIOD_8":
                        fldSCREEN_PROPERTY_PERIOD_8 = (TextBox)DataListField;
                        CoreField = fldSCREEN_PROPERTY_PERIOD_8;
                        fldSCREEN_PROPERTY_PERIOD_8.Bind(fleSCREEN_PROPERTY);
                        break;
                    case "FLDGRDSCREEN_PROPERTY_PERIOD_9":
                        fldSCREEN_PROPERTY_PERIOD_9 = (TextBox)DataListField;
                        CoreField = fldSCREEN_PROPERTY_PERIOD_9;
                        fldSCREEN_PROPERTY_PERIOD_9.Bind(fleSCREEN_PROPERTY);
                        break;
                    case "FLDGRDSCREEN_PROPERTY_PERIOD_10":
                        fldSCREEN_PROPERTY_PERIOD_10 = (TextBox)DataListField;
                        CoreField = fldSCREEN_PROPERTY_PERIOD_10;
                        fldSCREEN_PROPERTY_PERIOD_10.Bind(fleSCREEN_PROPERTY);
                        break;
                    case "FLDGRDSCREEN_PROPERTY_WEEK_STATUS_1":
                        fldSCREEN_PROPERTY_WEEK_STATUS_1 = (TextBox)DataListField;
                        CoreField = fldSCREEN_PROPERTY_WEEK_STATUS_1;
                        fldSCREEN_PROPERTY_WEEK_STATUS_1.Bind(fleSCREEN_PROPERTY);
                        break;
                    case "FLDGRDSCREEN_PROPERTY_WEEK_STATUS_2":
                        fldSCREEN_PROPERTY_WEEK_STATUS_2 = (TextBox)DataListField;
                        CoreField = fldSCREEN_PROPERTY_WEEK_STATUS_2;
                        fldSCREEN_PROPERTY_WEEK_STATUS_2.Bind(fleSCREEN_PROPERTY);
                        break;
                    case "FLDGRDSCREEN_PROPERTY_WEEK_STATUS_3":
                        fldSCREEN_PROPERTY_WEEK_STATUS_3 = (TextBox)DataListField;
                        CoreField = fldSCREEN_PROPERTY_WEEK_STATUS_3;
                        fldSCREEN_PROPERTY_WEEK_STATUS_3.Bind(fleSCREEN_PROPERTY);
                        break;
                    case "FLDGRDSCREEN_PROPERTY_WEEK_STATUS_4":
                        fldSCREEN_PROPERTY_WEEK_STATUS_4 = (TextBox)DataListField;
                        CoreField = fldSCREEN_PROPERTY_WEEK_STATUS_4;
                        fldSCREEN_PROPERTY_WEEK_STATUS_4.Bind(fleSCREEN_PROPERTY);
                        break;
                    case "FLDGRDSCREEN_PROPERTY_WEEK_STATUS_5":
                        fldSCREEN_PROPERTY_WEEK_STATUS_5 = (TextBox)DataListField;
                        CoreField = fldSCREEN_PROPERTY_WEEK_STATUS_5;
                        fldSCREEN_PROPERTY_WEEK_STATUS_5.Bind(fleSCREEN_PROPERTY);
                        break;
                    case "FLDGRDSCREEN_PROPERTY_WEEK_STATUS_6":
                        fldSCREEN_PROPERTY_WEEK_STATUS_6 = (TextBox)DataListField;
                        CoreField = fldSCREEN_PROPERTY_WEEK_STATUS_6;
                        fldSCREEN_PROPERTY_WEEK_STATUS_6.Bind(fleSCREEN_PROPERTY);
                        break;
                    case "FLDGRDSCREEN_PROPERTY_WEEK_STATUS_7":
                        fldSCREEN_PROPERTY_WEEK_STATUS_7 = (TextBox)DataListField;
                        CoreField = fldSCREEN_PROPERTY_WEEK_STATUS_7;
                        fldSCREEN_PROPERTY_WEEK_STATUS_7.Bind(fleSCREEN_PROPERTY);
                        break;
                    case "FLDGRDSCREEN_PROPERTY_WEEK_STATUS_8":
                        fldSCREEN_PROPERTY_WEEK_STATUS_8 = (TextBox)DataListField;
                        CoreField = fldSCREEN_PROPERTY_WEEK_STATUS_8;
                        fldSCREEN_PROPERTY_WEEK_STATUS_8.Bind(fleSCREEN_PROPERTY);
                        break;
                    case "FLDGRDSCREEN_PROPERTY_WEEK_STATUS_9":
                        fldSCREEN_PROPERTY_WEEK_STATUS_9 = (TextBox)DataListField;
                        CoreField = fldSCREEN_PROPERTY_WEEK_STATUS_9;
                        fldSCREEN_PROPERTY_WEEK_STATUS_9.Bind(fleSCREEN_PROPERTY);
                        break;
                    case "FLDGRDSCREEN_PROPERTY_WEEK_STATUS_10":
                        fldSCREEN_PROPERTY_WEEK_STATUS_10 = (TextBox)DataListField;
                        CoreField = fldSCREEN_PROPERTY_WEEK_STATUS_10;
                        fldSCREEN_PROPERTY_WEEK_STATUS_10.Bind(fleSCREEN_PROPERTY);
                        break;
                    case "FLDGRDT_POINTS_1A":
                        fldT_POINTS_1A = (TextBox)DataListField;
                        CoreField = fldT_POINTS_1A;
                        fldT_POINTS_1A.Bind(T_POINTS_1A);
                        break;
                    case "FLDGRDT_POINTS_2A":
                        fldT_POINTS_2A = (TextBox)DataListField;
                        CoreField = fldT_POINTS_2A;
                        fldT_POINTS_2A.Bind(T_POINTS_2A);
                        break;
                    case "FLDGRDT_POINTS_3A":
                        fldT_POINTS_3A = (TextBox)DataListField;
                        CoreField = fldT_POINTS_3A;
                        fldT_POINTS_3A.Bind(T_POINTS_3A);
                        break;
                    case "FLDGRDT_POINTS_4A":
                        fldT_POINTS_4A = (TextBox)DataListField;
                        CoreField = fldT_POINTS_4A;
                        fldT_POINTS_4A.Bind(T_POINTS_4A);
                        break;
                    case "FLDGRDT_POINTS_5A":
                        fldT_POINTS_5A = (TextBox)DataListField;
                        CoreField = fldT_POINTS_5A;
                        fldT_POINTS_5A.Bind(T_POINTS_5A);
                        break;
                    case "FLDGRDT_POINTS_6A":
                        fldT_POINTS_6A = (TextBox)DataListField;
                        CoreField = fldT_POINTS_6A;
                        fldT_POINTS_6A.Bind(T_POINTS_6A);
                        break;
                    case "FLDGRDT_POINTS_7A":
                        fldT_POINTS_7A = (TextBox)DataListField;
                        CoreField = fldT_POINTS_7A;
                        fldT_POINTS_7A.Bind(T_POINTS_7A);
                        break;
                    case "FLDGRDT_POINTS_8A":
                        fldT_POINTS_8A = (TextBox)DataListField;
                        CoreField = fldT_POINTS_8A;
                        fldT_POINTS_8A.Bind(T_POINTS_8A);
                        break;
                    case "FLDGRDT_POINTS_9A":
                        fldT_POINTS_9A = (TextBox)DataListField;
                        CoreField = fldT_POINTS_9A;
                        fldT_POINTS_9A.Bind(T_POINTS_9A);
                        break;
                    case "FLDGRDT_POINTS_10A":
                        fldT_POINTS_10A = (TextBox)DataListField;
                        CoreField = fldT_POINTS_10A;
                        fldT_POINTS_10A.Bind(T_POINTS_10A);
                        break;
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
        //#-----------------------------------------
        //# SetRelations Procedure.
        //#-----------------------------------------

        public override void SetRelations()
        {

            try
            {
                dtlSCREEN_PROPERTY.OccursWithFile = fleSCREEN_PROPERTY;
            }
            catch (CustomApplicationException ex)
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
        //# Do not delete, modify or move it.  Updated: 07/12/2013 1:49:40 PM

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
            fleLOCN_BK_COMMENTS.Transaction = m_trnTRANS_UPDATE;
            fleSCREEN_PROPERTY.Transaction = m_trnTRANS_UPDATE;
            flePROPERTY_YEARS.Transaction = m_trnTRANS_UPDATE;
            flePROPERTY_YEARS_DTL.Transaction = m_trnTRANS_UPDATE;
            flePASSING_PROPERTY.Transaction = m_trnTRANS_UPDATE;
            flePUT_PROP.Transaction = m_trnTRANS_UPDATE;
            fleBOOKING_PERIODS.Transaction = m_trnTRANS_UPDATE;
            fleBOOKING_PERIODS_DTL.Transaction = m_trnTRANS_UPDATE;
            fleREF_PROPS.Transaction = m_trnTRANS_UPDATE;


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 07/12/2013 1:49:40 PM

        //#-----------------------------------------
        //# InitializeFiles Procedure.
        //#-----------------------------------------

        protected override void InitializeFiles()
        {

            try
            {
                Initialize_TRANS_UPDATE();
                flePROPERTIES.Connection = m_cnnQUERY;
                flePROP_COMMENTS.Connection = m_cnnQUERY;
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
                fleM_INVESTORS.Dispose();
                fleUSER_SEC_FILE.Dispose();
                fleLOCN_BK_COMMENTS.Dispose();
                fleSCREEN_PROPERTY.Dispose();
                flePROPERTIES.Dispose();
                flePROP_COMMENTS.Dispose();
                flePROPERTY_YEARS.Dispose();
                flePROPERTY_YEARS_DTL.Dispose();
                flePASSING_PROPERTY.Dispose();
                flePUT_PROP.Dispose();
                fleBOOKING_PERIODS.Dispose();
                fleBOOKING_PERIODS_DTL.Dispose();
                fleREF_PROPS.Dispose();
                fleLOCATIONS.Dispose();


            }
            catch (CustomApplicationException ex)
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
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 07/12/2013 1:49:40 PM
        //#-----------------------------------------
        protected override void DisplayFormatting()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:49:40 PM
                Display(ref fldM_INVESTORS_INVESTOR_NAME);
                Display(ref fldM_YEAR);
                Display(ref fldT_MORE);
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
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 07/12/2013 1:49:40 PM
        //#-----------------------------------------
        protected override void PreDisplayFormatting()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:49:40 PM
                Display(ref fldM_INVESTORS_INVESTOR_NAME);
                Display(ref fldM_YEAR);
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
        //# Do not delete, modify or move it.  Updated: 07/12/2013 1:49:40 PM

        //#-----------------------------------------
        //# BindFields Procedure.
        //#-----------------------------------------

        public override void BindFields()
        {
            try
            {
                fldM_INVESTORS_INVESTOR_NAME.Bind(fleM_INVESTORS);
                fldM_YEAR.Bind(M_YEAR);
                fldT_MORE.Bind(T_MORE);

            }
            catch (CustomApplicationException ex)
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
                SaveReceivingParams(fleM_INVESTORS, fleUSER_SEC_FILE, fleLOCN_BK_COMMENTS, T_SHOW_ALL, T_SPECIFIC_WEEKS, T_AREA, M_YEAR, M_START_WEEK, M_END_WEEK, M_INDEX_KEY,
                M_PROPERTY_TYPE, M_PROPERTY_CODE, M_SPLIT_WEEKS, M_DISABLED, M_CHANGEOVER, M_BOOKED, M_PETS);


            }
            catch (CustomApplicationException ex)
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
                Receiving(fleM_INVESTORS, fleUSER_SEC_FILE, fleLOCN_BK_COMMENTS, T_SHOW_ALL, T_SPECIFIC_WEEKS, T_AREA, M_YEAR, M_START_WEEK, M_END_WEEK, M_INDEX_KEY,
                M_PROPERTY_TYPE, M_PROPERTY_CODE, M_SPLIT_WEEKS, M_DISABLED, M_CHANGEOVER, M_BOOKED, M_PETS);


            }
            catch (CustomApplicationException ex)
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

        private bool Internal_CHECK_WEB_DATA()
        {


            try
            {

                T_WEB_YEAR.Value = fleSCREEN_PROPERTY.GetStringValue("YEAR");
                T_WEB_LOCATION.Value = fleSCREEN_PROPERTY.GetStringValue("LOCATION");
                T_WEB_PROP_ID.Value = fleSCREEN_PROPERTY.GetStringValue("PROPERTY_ID");
                T_WEB_BOOKED.Value = "S";
                T_LT_INVESTOR.Value = fleM_INVESTORS.GetStringValue("INVESTOR");

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


        private bool Internal_GET_POINTS()
        {


            try
            {

                if (QDesign.NULL(QDesign.Substring(flePROPERTIES.GetStringValue("GROUPING"), 1, 3)) != "SHH" && QDesign.NULL(QDesign.Substring(flePROPERTIES.GetStringValue("GROUPING"), 1, 3)) != "TEN")
                {
                    T_PERIOD_1.Value = fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_1");
                    T_PBK_YEAR.Value = fleSCREEN_PROPERTY.GetStringValue("LOCATION") + fleSCREEN_PROPERTY.GetStringValue("BEDS") + fleSCREEN_PROPERTY.GetStringValue("PROPERTY_STYLE") + fleSCREEN_PROPERTY.GetStringValue("BATHROOMS") + fleSCREEN_PROPERTY.GetStringValue("YEAR");
                   


                    object[] arrRunscreen = { T_PBK_YEAR, T_PERIOD_1, T_POINTS_1, T_POINTS_2, T_POINTS_3, T_POINTS_4, T_POINTS_5, T_POINTS_6,
                    T_POINTS_7, T_POINTS_8, T_POINTS_9, T_POINTS_10 };
                    RunScreen(new B0200PTS(), RunScreenModes.Same, ref arrRunscreen);

                    T_POINTS_1A.Value = QDesign.ASCII(T_POINTS_1.Value);
                    T_POINTS_2A.Value = QDesign.ASCII(T_POINTS_2.Value);
                    T_POINTS_3A.Value = QDesign.ASCII(T_POINTS_3.Value);
                    T_POINTS_4A.Value = QDesign.ASCII(T_POINTS_4.Value);
                    T_POINTS_5A.Value = QDesign.ASCII(T_POINTS_5.Value);
                    T_POINTS_6A.Value = QDesign.ASCII(T_POINTS_6.Value);
                    T_POINTS_7A.Value = QDesign.ASCII(T_POINTS_7.Value);
                    T_POINTS_8A.Value = QDesign.ASCII(T_POINTS_8.Value);
                    T_POINTS_9A.Value = QDesign.ASCII(T_POINTS_9.Value);
                    T_POINTS_10A.Value = QDesign.ASCII(T_POINTS_10.Value);
                   
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


        protected override bool PostFind()
        {


            try
            {

                while (fleSCREEN_PROPERTY.For())
                {
                                       
                    SCREEN_PROPERTY_PROPERTY_CODE.Value = fleSCREEN_PROPERTY.GetStringValue("LOCATION") + fleSCREEN_PROPERTY.GetStringValue("BEDS") + fleSCREEN_PROPERTY.GetStringValue("PROPERTY_STYLE").PadRight(2, ' ') +
                    fleSCREEN_PROPERTY.GetStringValue("BATHROOMS") + "-" + fleSCREEN_PROPERTY.GetStringValue("PROPERTY_ID");
                   
                    if (QDesign.NULL(flePROPERTIES.GetDecimalValue("DATE_CLOSED")) != 0 && string.Compare(D_YEAR_CLOSED.Value, M_YEAR.Value) <= 0)
                    {
                        if (string.Compare(D_MMDD_CLOSED.Value, D_MMDD_1.Value) <= 0)
                        {
                            fleSCREEN_PROPERTY.set_SetValue("WEEK_STATUS_1", "CCCCCCC");
                        }
                        if (string.Compare(D_MMDD_CLOSED.Value, D_MMDD_2.Value) <= 0)
                        {
                            fleSCREEN_PROPERTY.set_SetValue("WEEK_STATUS_2", "CCCCCCC");
                        }
                        if (string.Compare(D_MMDD_CLOSED.Value, D_MMDD_3.Value) <= 0)
                        {
                            fleSCREEN_PROPERTY.set_SetValue("WEEK_STATUS_3", "CCCCCCC");
                        }
                        if (string.Compare(D_MMDD_CLOSED.Value, D_MMDD_4.Value) <= 0)
                        {
                            fleSCREEN_PROPERTY.set_SetValue("WEEK_STATUS_4", "CCCCCCC");
                        }
                        if (string.Compare(D_MMDD_CLOSED.Value, D_MMDD_5.Value) <= 0)
                        {
                            fleSCREEN_PROPERTY.set_SetValue("WEEK_STATUS_5", "CCCCCCC");
                        }
                        if (string.Compare(D_MMDD_CLOSED.Value, D_MMDD_6.Value) <= 0)
                        {
                            fleSCREEN_PROPERTY.set_SetValue("WEEK_STATUS_6", "CCCCCCC");
                        }
                        if (string.Compare(D_MMDD_CLOSED.Value, D_MMDD_7.Value) <= 0)
                        {
                            fleSCREEN_PROPERTY.set_SetValue("WEEK_STATUS_7", "CCCCCCC");
                        }
                        if (string.Compare(D_MMDD_CLOSED.Value, D_MMDD_8.Value) <= 0)
                        {
                            fleSCREEN_PROPERTY.set_SetValue("WEEK_STATUS_8", "CCCCCCC");
                        }
                        if (string.Compare(D_MMDD_CLOSED.Value, D_MMDD_9.Value) <= 0)
                        {
                            fleSCREEN_PROPERTY.set_SetValue("WEEK_STATUS_9", "CCCCCCC");
                        }
                        if (string.Compare(D_MMDD_CLOSED.Value, D_MMDD_10.Value) <= 0)
                        {
                            fleSCREEN_PROPERTY.set_SetValue("WEEK_STATUS_10", "CCCCCCC");
                        }
                    }
                    Internal_GET_POINTS();
                    if (QDesign.NULL(fleSCREEN_PROPERTY.GetStringValue("WEEK_STATUS_1")) == ".......")
                    {
                        T_WEB_START_WEEK.Value = QDesign.ASCII(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_1"), 2);
                        T_WEB_END_WEEK.Value = QDesign.ASCII(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_1"), 2);
                        if (QDesign.NULL(T_WEB_BOOKED.Value) == "Y")
                        {
                            fleSCREEN_PROPERTY.set_SetValue("WEEK_STATUS_1", "BBBBBBB");
                        }
                        else
                        {
                            if (QDesign.NULL(T_WEB_BOOKED.Value) == "Q")
                            {
                                fleSCREEN_PROPERTY.set_SetValue("WEEK_STATUS_1", "QQQQQQQ");
                            }
                        }
                    }
                    if (QDesign.NULL(fleSCREEN_PROPERTY.GetStringValue("WEEK_STATUS_2")) == ".......")
                    {
                        T_WEB_START_WEEK.Value = QDesign.ASCII(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_2"), 2);
                        T_WEB_END_WEEK.Value = QDesign.ASCII(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_2"), 2);
                        Internal_CHECK_WEB_DATA();
                        if (QDesign.NULL(T_WEB_BOOKED.Value) == "Y")
                        {
                            fleSCREEN_PROPERTY.set_SetValue("WEEK_STATUS_2", "BBBBBBB");
                        }
                        else
                        {
                            if (QDesign.NULL(T_WEB_BOOKED.Value) == "Q")
                            {
                                fleSCREEN_PROPERTY.set_SetValue("WEEK_STATUS_2", "QQQQQQQ");
                            }
                        }
                    }
                    if (QDesign.NULL(fleSCREEN_PROPERTY.GetStringValue("WEEK_STATUS_3")) == ".......")
                    {
                        T_WEB_START_WEEK.Value = QDesign.ASCII(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_3"), 2);
                        T_WEB_END_WEEK.Value = QDesign.ASCII(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_3"), 2);
                        Internal_CHECK_WEB_DATA();
                        if (QDesign.NULL(T_WEB_BOOKED.Value) == "Y")
                        {
                            fleSCREEN_PROPERTY.set_SetValue("WEEK_STATUS_3", "BBBBBBB");
                        }
                        else
                        {
                            if (QDesign.NULL(T_WEB_BOOKED.Value) == "Q")
                            {
                                fleSCREEN_PROPERTY.set_SetValue("WEEK_STATUS_3", "QQQQQQQ");
                            }
                        }
                    }
                    if (QDesign.NULL(fleSCREEN_PROPERTY.GetStringValue("WEEK_STATUS_4")) == ".......")
                    {
                        T_WEB_START_WEEK.Value = QDesign.ASCII(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_4"), 2);
                        T_WEB_END_WEEK.Value = QDesign.ASCII(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_4"), 2);
                        Internal_CHECK_WEB_DATA();
                        if (QDesign.NULL(T_WEB_BOOKED.Value) == "Y")
                        {
                            fleSCREEN_PROPERTY.set_SetValue("WEEK_STATUS_4", "BBBBBBB");
                        }
                        else
                        {
                            if (QDesign.NULL(T_WEB_BOOKED.Value) == "Q")
                            {
                                fleSCREEN_PROPERTY.set_SetValue("WEEK_STATUS_4", "QQQQQQQ");
                            }
                        }
                    }
                    if (QDesign.NULL(fleSCREEN_PROPERTY.GetStringValue("WEEK_STATUS_5")) == ".......")
                    {
                        T_WEB_START_WEEK.Value = QDesign.ASCII(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_5"), 2);
                        T_WEB_END_WEEK.Value = QDesign.ASCII(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_5"), 2);
                        Internal_CHECK_WEB_DATA();
                        if (QDesign.NULL(T_WEB_BOOKED.Value) == "Y")
                        {
                            fleSCREEN_PROPERTY.set_SetValue("WEEK_STATUS_5", "BBBBBBB");
                        }
                        else
                        {
                            if (QDesign.NULL(T_WEB_BOOKED.Value) == "Q")
                            {
                                fleSCREEN_PROPERTY.set_SetValue("WEEK_STATUS_5", "QQQQQQQ");
                            }
                        }
                    }
                    if (QDesign.NULL(fleSCREEN_PROPERTY.GetStringValue("WEEK_STATUS_6")) == ".......")
                    {
                        T_WEB_START_WEEK.Value = QDesign.ASCII(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_6"), 2);
                        T_WEB_END_WEEK.Value = QDesign.ASCII(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_6"), 2);
                        Internal_CHECK_WEB_DATA();
                        if (QDesign.NULL(T_WEB_BOOKED.Value) == "Y")
                        {
                            fleSCREEN_PROPERTY.set_SetValue("WEEK_STATUS_6", "BBBBBBB");
                        }
                        else
                        {
                            if (QDesign.NULL(T_WEB_BOOKED.Value) == "Q")
                            {
                                fleSCREEN_PROPERTY.set_SetValue("WEEK_STATUS_6", "QQQQQQQ");
                            }
                        }
                    }
                    if (QDesign.NULL(fleSCREEN_PROPERTY.GetStringValue("WEEK_STATUS_7")) == ".......")
                    {
                        T_WEB_START_WEEK.Value = QDesign.ASCII(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_7"), 2);
                        T_WEB_END_WEEK.Value = QDesign.ASCII(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_7"), 2);
                        Internal_CHECK_WEB_DATA();
                        if (QDesign.NULL(T_WEB_BOOKED.Value) == "Y")
                        {
                            fleSCREEN_PROPERTY.set_SetValue("WEEK_STATUS_7", "BBBBBBB");
                        }
                        else
                        {
                            if (QDesign.NULL(T_WEB_BOOKED.Value) == "Q")
                            {
                                fleSCREEN_PROPERTY.set_SetValue("WEEK_STATUS_7", "QQQQQQQ");
                            }
                        }
                    }
                    if (QDesign.NULL(fleSCREEN_PROPERTY.GetStringValue("WEEK_STATUS_8")) == ".......")
                    {
                        T_WEB_START_WEEK.Value = QDesign.ASCII(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_8"), 2);
                        T_WEB_END_WEEK.Value = QDesign.ASCII(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_8"), 2);
                        Internal_CHECK_WEB_DATA();
                        if (QDesign.NULL(T_WEB_BOOKED.Value) == "Y")
                        {
                            fleSCREEN_PROPERTY.set_SetValue("WEEK_STATUS_8", "BBBBBBB");
                        }
                        else
                        {
                            if (QDesign.NULL(T_WEB_BOOKED.Value) == "Q")
                            {
                                fleSCREEN_PROPERTY.set_SetValue("WEEK_STATUS_8", "QQQQQQQ");
                            }
                        }
                    }
                    if (QDesign.NULL(fleSCREEN_PROPERTY.GetStringValue("WEEK_STATUS_9")) == ".......")
                    {
                        T_WEB_START_WEEK.Value = QDesign.ASCII(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_9"), 2);
                        T_WEB_END_WEEK.Value = QDesign.ASCII(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_9"), 2);
                        Internal_CHECK_WEB_DATA();
                        if (QDesign.NULL(T_WEB_BOOKED.Value) == "Y")
                        {
                            fleSCREEN_PROPERTY.set_SetValue("WEEK_STATUS_9", "BBBBBBB");
                        }
                        else
                        {
                            if (QDesign.NULL(T_WEB_BOOKED.Value) == "Q")
                            {
                                fleSCREEN_PROPERTY.set_SetValue("WEEK_STATUS_9", "QQQQQQQ");
                            }
                        }
                    }
                    if (QDesign.NULL(fleSCREEN_PROPERTY.GetStringValue("WEEK_STATUS_10")) == ".......")
                    {
                        T_WEB_START_WEEK.Value = QDesign.ASCII(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_10"), 2);
                        T_WEB_END_WEEK.Value = QDesign.ASCII(fleSCREEN_PROPERTY.GetDecimalValue("PERIOD_10"), 2);
                        Internal_CHECK_WEB_DATA();
                        if (QDesign.NULL(T_WEB_BOOKED.Value) == "Y")
                        {
                            fleSCREEN_PROPERTY.set_SetValue("WEEK_STATUS_10", "BBBBBBB");
                        }
                        else
                        {
                            if (QDesign.NULL(T_WEB_BOOKED.Value) == "Q")
                            {
                                fleSCREEN_PROPERTY.set_SetValue("WEEK_STATUS_10", "QQQQQQQ");
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


        private bool Internal_CHECK_BOOK()
        {


            try
            {

                // --> GET BOOKING_PERIODS <--
                m_strWhere = new StringBuilder(" WHERE ");
                m_strWhere.Append(" ").Append(fleBOOKING_PERIODS.ElementOwner("LOCATION")).Append(" = ");
                m_strWhere.Append(Common.StringToField(flePROPERTY_YEARS.GetStringValue("LOCATION")));
                //Parent:BOOKING_PERIOD
                m_strWhere.Append(" AND ").Append(" ").Append(fleBOOKING_PERIODS.ElementOwner("CHANGEOVER_DAY")).Append(" = ");
                m_strWhere.Append(Common.StringToField(fleREF_PROPS.GetStringValue("CHANGEOVER_DAY")));
                //Parent:BOOKING_PERIOD
                m_strWhere.Append(" AND ").Append(" ").Append(fleBOOKING_PERIODS.ElementOwner("YEAR")).Append(" = ");
                m_strWhere.Append(Common.StringToField(M_YEAR.Value));
                //Parent:BOOKING_PERIOD

                fleBOOKING_PERIODS.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);

                fleBOOKING_PERIODS_DTL.GetData("", GetDataOptions.IsOptional | GetDataOptions.ForOccurence);

                
                // --> End GET BOOKING_PERIODS <--
                if (!AccessOk)
                {
                    Information(QDesign.NULL(flePROPERTY_YEARS.GetStringValue("LOCATION")) + " : " + QDesign.NULL(fleREF_PROPS.GetStringValue("CHANGEOVER_DAY")) + " : " + M_YEAR.Value);
                    // TODO: May need to fix manually
                    Severe("52010");
                }
                flePUT_PROP.set_SetValue("PERIOD_1", 0);
                flePUT_PROP.set_SetValue("PERIOD_2", 0);
                flePUT_PROP.set_SetValue("PERIOD_3", 0);
                flePUT_PROP.set_SetValue("PERIOD_4", 0);
                flePUT_PROP.set_SetValue("PERIOD_5", 0);
                flePUT_PROP.set_SetValue("PERIOD_6", 0);
                flePUT_PROP.set_SetValue("PERIOD_7", 0);
                flePUT_PROP.set_SetValue("PERIOD_8", 0);
                flePUT_PROP.set_SetValue("PERIOD_9", 0);
                flePUT_PROP.set_SetValue("PERIOD_10", 0);

                

                while (this.For(53))
                {                   

                    if ((Occurrence >= D_START.Value && Occurrence <= D_END.Value && QDesign.NULL(T_SPECIFIC_WEEKS.Value) != "Y") || (Occurrence >= M_START_WEEK.Value && Occurrence <= M_END_WEEK.Value && QDesign.NULL(T_SPECIFIC_WEEKS.Value) == "Y"))
                    {
                        

                        if (53 == Occurrence && QDesign.NULL(fleBOOKING_PERIODS_DTL.GetDecimalValue("START_DATE")) == 0)
                        {
                            // QDesign.NULL
                        }
                        else
                        {
                            if (QDesign.NULL(flePUT_PROP.GetDecimalValue("PERIOD_1")) == 0)
                            {
                                flePUT_PROP.set_SetValue("PERIOD_1", Occurrence);
                                flePUT_PROP.set_SetValue("WEEK_STATUS_1", D_WEEK_STATUS.Value);
                                flePUT_PROP.set_SetValue("PROPERTY_DATE_1", (D_DATE.Value).PadRight(9).Substring(0, 5));
                                //Parent:PRPTY_YR_DATE_1
                                flePUT_PROP.set_SetValue("PRPTY_YR_1", (D_DATE.Value).PadRight(9).Substring(5, 4));
                                //Parent:PRPTY_YR_DATE_1
                                T_WAIT_DATE_FROM.Value = fleBOOKING_PERIODS_DTL.GetDecimalValue("START_DATE");
                                if (QDesign.NULL(D_DAYS_FREE.Value) == "Y" || QDesign.NULL(T_SHOW_ALL.Value) == "Y")
                                {
                                    T_PUT_PROP.Value = "Y";
                                }
                            }
                            else
                            {
                                if (QDesign.NULL(flePUT_PROP.GetDecimalValue("PERIOD_2")) == 0)
                                {
                                    flePUT_PROP.set_SetValue("PERIOD_2", Occurrence);
                                    flePUT_PROP.set_SetValue("WEEK_STATUS_2", D_WEEK_STATUS.Value);
                                    flePUT_PROP.set_SetValue("PROPERTY_DATE_2", (D_DATE.Value).PadRight(9).Substring(0, 5));
                                    //Parent:PRPTY_YR_DATE_2
                                    flePUT_PROP.set_SetValue("PRPTY_YR_2", (D_DATE.Value).PadRight(9).Substring(5, 4));
                                    //Parent:PRPTY_YR_DATE_2
                                    if (QDesign.NULL(T_PUT_PROP.Value) != "Y")
                                    {
                                        if (QDesign.NULL(D_DAYS_FREE.Value) == "Y" || QDesign.NULL(T_SHOW_ALL.Value) == "Y")
                                        {
                                            T_PUT_PROP.Value = "Y";
                                        }
                                    }
                                }
                                else
                                {
                                    if (QDesign.NULL(flePUT_PROP.GetDecimalValue("PERIOD_3")) == 0)
                                    {
                                        flePUT_PROP.set_SetValue("PERIOD_3", Occurrence);
                                        flePUT_PROP.set_SetValue("WEEK_STATUS_3", D_WEEK_STATUS.Value);
                                        flePUT_PROP.set_SetValue("PROPERTY_DATE_3", (D_DATE.Value).PadRight(9).Substring(0, 5));
                                        //Parent:PRPTY_YR_DATE_3
                                        flePUT_PROP.set_SetValue("PRPTY_YR_3", (D_DATE.Value).PadRight(9).Substring(5, 4));
                                        //Parent:PRPTY_YR_DATE_3
                                        if (QDesign.NULL(T_PUT_PROP.Value) != "Y")
                                        {
                                            if (QDesign.NULL(D_DAYS_FREE.Value) == "Y" || QDesign.NULL(T_SHOW_ALL.Value) == "Y")
                                            {
                                                T_PUT_PROP.Value = "Y";
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (QDesign.NULL(flePUT_PROP.GetDecimalValue("PERIOD_4")) == 0)
                                        {
                                            flePUT_PROP.set_SetValue("PERIOD_4", Occurrence);
                                            flePUT_PROP.set_SetValue("WEEK_STATUS_4", D_WEEK_STATUS.Value);
                                            flePUT_PROP.set_SetValue("PROPERTY_DATE_4", (D_DATE.Value).PadRight(9).Substring(0, 5));
                                            //Parent:PRPTY_YR_DATE_4
                                            flePUT_PROP.set_SetValue("PRPTY_YR_4", (D_DATE.Value).PadRight(9).Substring(5, 4));
                                            //Parent:PRPTY_YR_DATE_4
                                            if (QDesign.NULL(T_PUT_PROP.Value) != "Y")
                                            {
                                                if (QDesign.NULL(D_DAYS_FREE.Value) == "Y" || QDesign.NULL(T_SHOW_ALL.Value) == "Y")
                                                {
                                                    T_PUT_PROP.Value = "Y";
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (QDesign.NULL(flePUT_PROP.GetDecimalValue("PERIOD_5")) == 0)
                                            {
                                                flePUT_PROP.set_SetValue("PERIOD_5", Occurrence);
                                                flePUT_PROP.set_SetValue("WEEK_STATUS_5", D_WEEK_STATUS.Value);
                                                flePUT_PROP.set_SetValue("PROPERTY_DATE_5", (D_DATE.Value).PadRight(9).Substring(0, 5));
                                                //Parent:PRPTY_YR_DATE_5
                                                flePUT_PROP.set_SetValue("PRPTY_YR_5", (D_DATE.Value).PadRight(9).Substring(5, 4));
                                                //Parent:PRPTY_YR_DATE_5
                                                if (QDesign.NULL(T_PUT_PROP.Value) != "Y")
                                                {
                                                    if (QDesign.NULL(D_DAYS_FREE.Value) == "Y" || QDesign.NULL(T_SHOW_ALL.Value) == "Y")
                                                    {
                                                        T_PUT_PROP.Value = "Y";
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                if (QDesign.NULL(flePUT_PROP.GetDecimalValue("PERIOD_6")) == 0)
                                                {
                                                    flePUT_PROP.set_SetValue("PERIOD_6", Occurrence);
                                                    flePUT_PROP.set_SetValue("WEEK_STATUS_6", D_WEEK_STATUS.Value);
                                                    flePUT_PROP.set_SetValue("PROPERTY_DATE_6", (D_DATE.Value).PadRight(9).Substring(0, 5));
                                                    //Parent:PRPTY_YR_DATE_6
                                                    flePUT_PROP.set_SetValue("PRPTY_YR_6", (D_DATE.Value).PadRight(9).Substring(5, 4));
                                                    //Parent:PRPTY_YR_DATE_6
                                                    if (QDesign.NULL(T_PUT_PROP.Value) != "Y")
                                                    {
                                                        if (QDesign.NULL(D_DAYS_FREE.Value) == "Y" || QDesign.NULL(T_SHOW_ALL.Value) == "Y")
                                                        {
                                                            T_PUT_PROP.Value = "Y";
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (QDesign.NULL(flePUT_PROP.GetDecimalValue("PERIOD_7")) == 0)
                                                    {
                                                        flePUT_PROP.set_SetValue("PERIOD_7", Occurrence);
                                                        flePUT_PROP.set_SetValue("WEEK_STATUS_7", D_WEEK_STATUS.Value);
                                                        flePUT_PROP.set_SetValue("PROPERTY_DATE_7", (D_DATE.Value).PadRight(9).Substring(0, 5));
                                                        //Parent:PRPTY_YR_DATE_7
                                                        flePUT_PROP.set_SetValue("PRPTY_YR_7", (D_DATE.Value).PadRight(9).Substring(5, 4));
                                                        //Parent:PRPTY_YR_DATE_7
                                                        if (QDesign.NULL(T_PUT_PROP.Value) != "Y")
                                                        {
                                                            if (QDesign.NULL(D_DAYS_FREE.Value) == "Y" || QDesign.NULL(T_SHOW_ALL.Value) == "Y")
                                                            {
                                                                T_PUT_PROP.Value = "Y";
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (QDesign.NULL(flePUT_PROP.GetDecimalValue("PERIOD_8")) == 0)
                                                        {
                                                            flePUT_PROP.set_SetValue("PERIOD_8", Occurrence);
                                                            flePUT_PROP.set_SetValue("WEEK_STATUS_8", D_WEEK_STATUS.Value);
                                                            flePUT_PROP.set_SetValue("PROPERTY_DATE_8", (D_DATE.Value).PadRight(9).Substring(0, 5));
                                                            //Parent:PRPTY_YR_DATE_8
                                                            flePUT_PROP.set_SetValue("PRPTY_YR_8", (D_DATE.Value).PadRight(9).Substring(5, 4));
                                                            //Parent:PRPTY_YR_DATE_8
                                                            if (QDesign.NULL(T_PUT_PROP.Value) != "Y")
                                                            {
                                                                if (QDesign.NULL(D_DAYS_FREE.Value) == "Y" || QDesign.NULL(T_SHOW_ALL.Value) == "Y")
                                                                {
                                                                    T_PUT_PROP.Value = "Y";
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (QDesign.NULL(flePUT_PROP.GetDecimalValue("PERIOD_9")) == 0)
                                                            {
                                                                flePUT_PROP.set_SetValue("PERIOD_9", Occurrence);
                                                                flePUT_PROP.set_SetValue("WEEK_STATUS_9", D_WEEK_STATUS.Value);
                                                                flePUT_PROP.set_SetValue("PROPERTY_DATE_9", (D_DATE.Value).PadRight(9).Substring(0, 5));
                                                                //Parent:PRPTY_YR_DATE_9
                                                                flePUT_PROP.set_SetValue("PRPTY_YR_9", (D_DATE.Value).PadRight(9).Substring(5, 4));
                                                                //Parent:PRPTY_YR_DATE_9
                                                                if (QDesign.NULL(T_PUT_PROP.Value) != "Y")
                                                                {
                                                                    if (QDesign.NULL(D_DAYS_FREE.Value) == "Y" || QDesign.NULL(T_SHOW_ALL.Value) == "Y")
                                                                    {
                                                                        T_PUT_PROP.Value = "Y";
                                                                    }
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (QDesign.NULL(flePUT_PROP.GetDecimalValue("PERIOD_10")) == 0)
                                                                {
                                                                    flePUT_PROP.set_SetValue("PERIOD_10", Occurrence);
                                                                    flePUT_PROP.set_SetValue("WEEK_STATUS_10", D_WEEK_STATUS.Value);
                                                                    flePUT_PROP.set_SetValue("PROPERTY_DATE_10", (D_DATE.Value).PadRight(9).Substring(0, 5));
                                                                    //Parent:PRPTY_YR_DATE_10
                                                                    flePUT_PROP.set_SetValue("PRPTY_YR_10", (D_DATE.Value).PadRight(9).Substring(5, 4));
                                                                    //Parent:PRPTY_YR_DATE_10
                                                                    T_WAIT_DATE_TO.Value = fleBOOKING_PERIODS_DTL.GetDecimalValue("START_DATE");
                                                                    if (QDesign.NULL(T_PUT_PROP.Value) != "Y")
                                                                    {
                                                                        if (QDesign.NULL(D_DAYS_FREE.Value) == "Y" || QDesign.NULL(T_SHOW_ALL.Value) == "Y")
                                                                        {
                                                                            T_PUT_PROP.Value = "Y";
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


        private bool Internal_GET_PROP_YEARS()
        {


            try
            {

                T_PUT_PROP.Value = "N";
                // --> GET REF_PROPS <--
                m_strWhere = new StringBuilder(" WHERE ");
                m_strWhere.Append(" ").Append(fleREF_PROPS.ElementOwner("LOCATION")).Append(" = ");
                m_strWhere.Append(Common.StringToField(flePROPERTY_YEARS.GetStringValue("LOCATION")));
                m_strWhere.Append(" AND ").Append(" ").Append(fleREF_PROPS.ElementOwner("BEDS")).Append(" = ");
                m_strWhere.Append(Common.StringToField(flePROPERTY_YEARS.GetStringValue("BEDS")));
                m_strWhere.Append(" AND ").Append(" ").Append(fleREF_PROPS.ElementOwner("PROPERTY_STYLE")).Append(" = ");
                m_strWhere.Append(Common.StringToField(flePROPERTY_YEARS.GetStringValue("PROPERTY_STYLE")));
                m_strWhere.Append(" AND ").Append(" ").Append(fleREF_PROPS.ElementOwner("BATHROOMS")).Append(" = ");
                m_strWhere.Append(Common.StringToField(flePROPERTY_YEARS.GetStringValue("BATHROOMS")));
                m_strWhere.Append(" AND ").Append(" ").Append(fleREF_PROPS.ElementOwner("PROPERTY_ID")).Append(" = ");
                m_strWhere.Append(Common.StringToField(flePROPERTY_YEARS.GetStringValue("PROPERTY_ID")));
                
                fleREF_PROPS.GetData(m_strWhere.ToString());
                // --> End GET REF_PROPS <--
                if ((QDesign.NULL(M_SPLIT_WEEKS.Value) != "Y" || (QDesign.NULL(M_SPLIT_WEEKS.Value) == "Y" && QDesign.NULL(fleREF_PROPS.GetStringValue("SPLIT_WEEKS")) == "Y")) && (QDesign.NULL(M_DISABLED.Value) != "Y" || (QDesign.NULL(M_DISABLED.Value) == "Y" && QDesign.NULL(fleREF_PROPS.GetStringValue("DISABLED")) == "Y")) && (QDesign.NULL(M_CHANGEOVER.Value) == QDesign.NULL(" ") || (QDesign.NULL(M_CHANGEOVER.Value) == QDesign.NULL(fleREF_PROPS.GetStringValue("CHANGEOVER_DAY")))) && (QDesign.NULL(D_PUBLIC_BOND.Value) == "B" || (QDesign.NULL(D_PUBLIC_BOND.Value) == "P" && (QDesign.NULL(QDesign.Substring(fleREF_PROPS.GetStringValue("GROUPING"), 1, 3)) == "TEN" || QDesign.NULL(QDesign.Substring(fleREF_PROPS.GetStringValue("GROUPING"), 1, 3)) == "SHH"))) && (QDesign.NULL(M_PETS.Value) == QDesign.NULL(" ") || ((QDesign.NULL(M_PETS.Value) == "Y" && QDesign.NULL(fleREF_PROPS.GetStringValue("PETS_YN")) == "Y") || (QDesign.NULL(M_PETS.Value) == "N" && QDesign.NULL(fleREF_PROPS.GetStringValue("PETS_YN")) == "N"))))
                {
                    Internal_CHECK_BOOK();
                    if (QDesign.NULL(T_PUT_PROP.Value) == "Y")
                    {
                        fleSCREEN_PROPERTY.set_SetValue("PROPERTY_DATE_1", flePUT_PROP.GetStringValue("PROPERTY_DATE_1"));
                        fleSCREEN_PROPERTY.set_SetValue("PERIOD_1", flePUT_PROP.GetDecimalValue("PERIOD_1"));
                        fleSCREEN_PROPERTY.set_SetValue("WEEK_STATUS_1", flePUT_PROP.GetStringValue("WEEK_STATUS_1"));
                        fleSCREEN_PROPERTY.set_SetValue("PROPERTY_DATE_2", flePUT_PROP.GetStringValue("PROPERTY_DATE_2"));
                        fleSCREEN_PROPERTY.set_SetValue("PERIOD_2", flePUT_PROP.GetDecimalValue("PERIOD_2"));
                        fleSCREEN_PROPERTY.set_SetValue("WEEK_STATUS_2", flePUT_PROP.GetStringValue("WEEK_STATUS_2"));
                        fleSCREEN_PROPERTY.set_SetValue("PROPERTY_DATE_3", flePUT_PROP.GetStringValue("PROPERTY_DATE_3"));
                        fleSCREEN_PROPERTY.set_SetValue("PERIOD_3", flePUT_PROP.GetDecimalValue("PERIOD_3"));
                        fleSCREEN_PROPERTY.set_SetValue("WEEK_STATUS_3", flePUT_PROP.GetStringValue("WEEK_STATUS_3"));
                        fleSCREEN_PROPERTY.set_SetValue("PROPERTY_DATE_4", flePUT_PROP.GetStringValue("PROPERTY_DATE_4"));
                        fleSCREEN_PROPERTY.set_SetValue("PERIOD_4", flePUT_PROP.GetDecimalValue("PERIOD_4"));
                        fleSCREEN_PROPERTY.set_SetValue("WEEK_STATUS_4", flePUT_PROP.GetStringValue("WEEK_STATUS_4"));
                        fleSCREEN_PROPERTY.set_SetValue("PROPERTY_DATE_5", flePUT_PROP.GetStringValue("PROPERTY_DATE_5"));
                        fleSCREEN_PROPERTY.set_SetValue("PERIOD_5", flePUT_PROP.GetDecimalValue("PERIOD_5"));
                        fleSCREEN_PROPERTY.set_SetValue("WEEK_STATUS_5", flePUT_PROP.GetStringValue("WEEK_STATUS_5"));
                        fleSCREEN_PROPERTY.set_SetValue("PROPERTY_DATE_6", flePUT_PROP.GetStringValue("PROPERTY_DATE_6"));
                        fleSCREEN_PROPERTY.set_SetValue("PERIOD_6", flePUT_PROP.GetDecimalValue("PERIOD_6"));
                        fleSCREEN_PROPERTY.set_SetValue("WEEK_STATUS_6", flePUT_PROP.GetStringValue("WEEK_STATUS_6"));
                        fleSCREEN_PROPERTY.set_SetValue("PROPERTY_DATE_7", flePUT_PROP.GetStringValue("PROPERTY_DATE_7"));
                        fleSCREEN_PROPERTY.set_SetValue("PERIOD_7", flePUT_PROP.GetDecimalValue("PERIOD_7"));
                        fleSCREEN_PROPERTY.set_SetValue("WEEK_STATUS_7", flePUT_PROP.GetStringValue("WEEK_STATUS_7"));
                        fleSCREEN_PROPERTY.set_SetValue("PROPERTY_DATE_8", flePUT_PROP.GetStringValue("PROPERTY_DATE_8"));
                        fleSCREEN_PROPERTY.set_SetValue("PERIOD_8", flePUT_PROP.GetDecimalValue("PERIOD_8"));
                        fleSCREEN_PROPERTY.set_SetValue("WEEK_STATUS_8", flePUT_PROP.GetStringValue("WEEK_STATUS_8"));
                        fleSCREEN_PROPERTY.set_SetValue("PROPERTY_DATE_9", flePUT_PROP.GetStringValue("PROPERTY_DATE_9"));
                        fleSCREEN_PROPERTY.set_SetValue("PERIOD_9", flePUT_PROP.GetDecimalValue("PERIOD_9"));
                        fleSCREEN_PROPERTY.set_SetValue("WEEK_STATUS_9", flePUT_PROP.GetStringValue("WEEK_STATUS_9"));
                        fleSCREEN_PROPERTY.set_SetValue("PROPERTY_DATE_10", flePUT_PROP.GetStringValue("PROPERTY_DATE_10"));
                        fleSCREEN_PROPERTY.set_SetValue("PERIOD_10", flePUT_PROP.GetDecimalValue("PERIOD_10"));
                        fleSCREEN_PROPERTY.set_SetValue("WEEK_STATUS_10", flePUT_PROP.GetStringValue("WEEK_STATUS_10"));
                        fleSCREEN_PROPERTY.set_SetValue("LOCATION", fleLOCATIONS.GetStringValue("LOCATION"));
                        //Parent:PROPERTY_YEAR
                        fleSCREEN_PROPERTY.set_SetValue("BEDS", flePROPERTY_YEARS.GetStringValue("BEDS"));
                        //Parent:PROPERTY_YEAR
                        fleSCREEN_PROPERTY.set_SetValue("PROPERTY_STYLE", flePROPERTY_YEARS.GetStringValue("PROPERTY_STYLE"));
                        //Parent:PROPERTY_YEAR
                        fleSCREEN_PROPERTY.set_SetValue("BATHROOMS", flePROPERTY_YEARS.GetStringValue("BATHROOMS"));
                        //Parent:PROPERTY_YEAR
                        fleSCREEN_PROPERTY.set_SetValue("PROPERTY_ID", flePROPERTY_YEARS.GetStringValue("PROPERTY_ID"));
                        //Parent:PROPERTY_YEAR
                        fleSCREEN_PROPERTY.set_SetValue("YEAR", flePROPERTY_YEARS.GetStringValue("YEAR"));
                        //Parent:PROPERTY_YEAR
                        flePUT_PROP.PutData(true);
                       
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


        protected override bool Initialize()
        {


            try
            {

                //m_blnCommandOK = RunCommand(D_SCREEN_PROPERTY.ToString(), OnErrorOptions.Continue, false);
                //// TODO: Check source code.  Manual process may be required.
                //if (!m_blnCommandOK)
                //{
                //    // Close fleSCREEN_PROPERTY
                //    // Close flePUT_PROP
                //    m_blnCommandOK = RunCommand(D_PURGE_PROPERTY.ToString(), OnErrorOptions.Continue, false);
                //    // TODO: Check source code.  Manual process may be required.
                //    m_blnCommandOK = RunCommand(D_SCREEN_PROPERTY.ToString(), OnErrorOptions.Continue, false);
                //    // TODO: Check source code.  Manual process may be required.
                //}

                flePUT_PROP.Purge();
                fleSCREEN_PROPERTY.Purge();

                T_START_WEEK.Value = M_START_WEEK.Value;
                T_END_WEEK.Value = M_END_WEEK.Value;
                if (QDesign.NULL(M_PROPERTY_CODE.Value) != QDesign.NULL(" "))
                {
                    m_strOrderBy = new StringBuilder(" ORDER BY ").Append(flePROPERTY_YEARS.ElementOwner("PROPERTY_SORT"));
                    // --> GET PROPERTY_YEARS <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(flePROPERTY_YEARS.ElementOwner("LOC_KEY")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(QDesign.Substring(D_YEAR_KEY.Value, 1, 2)));
                    m_strWhere.Append(" AND ").Append(flePROPERTY_YEARS.ElementOwner("YEAR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(QDesign.Substring(D_YEAR_KEY.Value, 11, 4)));

                    flePROPERTY_YEARS.GetData(m_strWhere.ToString(), m_strOrderBy.ToString());

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
                    // --> GET REF_PROPS <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleREF_PROPS.ElementOwner("LOCATION")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(flePROPERTY_YEARS.GetStringValue("LOCATION")));
                    m_strWhere.Append(" AND ").Append(" ").Append(fleREF_PROPS.ElementOwner("BEDS")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(flePROPERTY_YEARS.GetStringValue("BEDS")));
                    m_strWhere.Append(" AND ").Append(" ").Append(fleREF_PROPS.ElementOwner("PROPERTY_STYLE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(flePROPERTY_YEARS.GetStringValue("PROPERTY_STYLE")));
                    m_strWhere.Append(" AND ").Append(" ").Append(fleREF_PROPS.ElementOwner("BATHROOMS")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(flePROPERTY_YEARS.GetStringValue("BATHROOMS")));
                    m_strWhere.Append(" AND ").Append(" ").Append(fleREF_PROPS.ElementOwner("PROPERTY_ID")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(flePROPERTY_YEARS.GetStringValue("PROPERTY_ID")));
                    

                    fleREF_PROPS.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET REF_PROPS <--
                    if (!AccessOk)
                    {
                        ErrorMessage("52011");
                    }
                    Internal_CHECK_BOOK();
                    flePUT_PROP.PutData(true);
                }
                else
                {
                    if (QDesign.NULL(QDesign.Substring(M_PROPERTY_TYPE.Value, 1, 2)) != QDesign.NULL("  "))
                    {
                        m_strOrderBy = new StringBuilder(" ORDER BY ").Append(flePROPERTY_YEARS.ElementOwner("PROPERTY_SORT"));
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(flePROPERTY_YEARS.ElementOwner("LOC_KEY")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(QDesign.Substring(D_YEAR_KEY.Value, 1, 2)));
                        m_strWhere.Append(" AND ").Append(flePROPERTY_YEARS.ElementOwner("YEAR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(QDesign.Substring(D_YEAR_KEY.Value, 11, 4)));

                        while (flePROPERTY_YEARS.WhileRetrieving(m_strWhere.ToString(), m_strOrderBy.ToString()))
                        {
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

                            Internal_GET_PROP_YEARS();
                        }
                    }
                    else
                    {
                        m_strOrderBy = new StringBuilder(" ORDER BY ").Append(flePROPERTY_YEARS.ElementOwner("PROPERTY_SORT"));
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(flePROPERTY_YEARS.ElementOwner("LOC_KEY")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(QDesign.Substring(D_YEAR_KEY.Value, 1, 2)));
                        m_strWhere.Append(" AND ").Append(flePROPERTY_YEARS.ElementOwner("YEAR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(QDesign.Substring(D_YEAR_KEY.Value, 11, 4)));

                        while (flePROPERTY_YEARS.WhileRetrieving(m_strWhere.ToString(), m_strOrderBy.ToString()))
                        {
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

                            Internal_GET_PROP_YEARS();
                        }
                        if (QDesign.NULL(T_AREA.Value) == "UKL")
                        {
                            m_strOrderBy = new StringBuilder(" ORDER BY ").Append(flePROPERTY_YEARS.ElementOwner("PROPERTY_SORT"));
                        
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append("").Append(flePROPERTY_YEARS.ElementOwner("AREA")).Append(" = 'SHHT')");

                            while (flePROPERTY_YEARS.WhileRetrieving(m_strWhere.ToString(), m_strOrderBy.ToString()))
                            {
                                Internal_GET_PROP_YEARS();
                            }
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append("").Append(flePROPERTY_YEARS.ElementOwner("AREA")).Append(" = 'SHHL')");

                            m_strOrderBy = new StringBuilder(" ORDER BY ").Append(flePROPERTY_YEARS.ElementOwner("PROPERTY_SORT"));

                            while (flePROPERTY_YEARS.WhileRetrieving(m_strWhere.ToString()))
                            {
                                
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
                                flePROPERTY_YEARS_DTL.GetData(m_strWhere.ToString(), m_strOrderBy.ToString(), GetDataOptions.ForOccurence);

                                Internal_GET_PROP_YEARS();
                            }
                        }
                    }
                    if (QDesign.NULL(T_QUALIFY.Value) == 0 && QDesign.NULL(T_CALENDER_EXISTS.Value) == "Y")
                    {
                        Information("** All properties for this period are fully booked\a\a **");
                        // TODO: May need to fix manually
                    }
                }
                // Close flePUT_PROP
                // Close fleSCREEN_PROPERTY

               

               
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

                if (string.Compare(QDesign.NULL(fleUSER_SEC_FILE.GetStringValue("USER_LEVEL")), "05") > 0)
                {
                    ErrorMessage("52012");
                }
                M_RENTOUT.Value = "N";
                T_OCCURRENCE.Value = Occurrence;
                while (fleSCREEN_PROPERTY.For())
                {
                    if (QDesign.NULL(D_PUBLIC_BOND.Value) == "P" && (QDesign.NULL(QDesign.Substring(flePROPERTIES.GetStringValue("GROUPING"), 1, 3)) != "TEN" && QDesign.NULL(QDesign.Substring(flePROPERTIES.GetStringValue("GROUPING"), 1, 3)) != "SHH"))
                    {
                        ErrorMessage("52013");
                    }
                    if (Occurrence == QDesign.NULL(T_OCCURRENCE.Value))
                    {
                        // --> GET PASSING_PROPERTY <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(flePASSING_PROPERTY.ElementOwner("LOCATION")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleSCREEN_PROPERTY.GetStringValue("LOCATION")));
                        //Parent:PROPERTY_YEAR    'Parent:PROPERTY_YEAR
                        m_strWhere.Append(" AND ").Append(" ").Append(flePASSING_PROPERTY.ElementOwner("BEDS")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleSCREEN_PROPERTY.GetStringValue("BEDS")));
                        //Parent:PROPERTY_YEAR    'Parent:PROPERTY_YEAR
                        m_strWhere.Append(" AND ").Append(" ").Append(flePASSING_PROPERTY.ElementOwner("PROPERTY_STYLE")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_STYLE")));
                        //Parent:PROPERTY_YEAR    'Parent:PROPERTY_YEAR
                        m_strWhere.Append(" AND ").Append(" ").Append(flePASSING_PROPERTY.ElementOwner("BATHROOMS")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleSCREEN_PROPERTY.GetStringValue("BATHROOMS")));
                        //Parent:PROPERTY_YEAR    'Parent:PROPERTY_YEAR
                        m_strWhere.Append(" AND ").Append(" ").Append(flePASSING_PROPERTY.ElementOwner("PROPERTY_ID")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleSCREEN_PROPERTY.GetStringValue("PROPERTY_ID")));
                        //Parent:PROPERTY_YEAR    'Parent:PROPERTY_YEAR
                        m_strWhere.Append(" AND ").Append(" ").Append(flePASSING_PROPERTY.ElementOwner("YEAR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleSCREEN_PROPERTY.GetStringValue("YEAR")));
                        //Parent:PROPERTY_YEAR    'Parent:PROPERTY_YEAR

                        flePASSING_PROPERTY.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET PASSING_PROPERTY <--
                        if (!AccessOk)
                        {
                            Information("**Error - Phone IT dept.  Screen-property : " + QDesign.NULL(fleSCREEN_PROPERTY.GetStringValue("LOCATION") + fleSCREEN_PROPERTY.GetStringValue("BEDS") + fleSCREEN_PROPERTY.GetStringValue("PROPERTY_STYLE") + fleSCREEN_PROPERTY.GetStringValue("BATHROOMS") + fleSCREEN_PROPERTY.GetStringValue("PROPERTY_ID") + fleSCREEN_PROPERTY.GetStringValue("YEAR")));
                            // TODO: May need to fix manually    'Parent:PROPERTY_YEAR
                        }
                        if (QDesign.NULL(fleM_INVESTORS.GetStringValue("INVESTOR")) == "999SH")
                        {
                            //RunScreen("BOOKSHHL.QKC", RunScreenModes.Entry, fleM_INVESTORS, fleUSER_SEC_FILE, flePASSING_PROPERTY, fleSCREEN_PROPERTY, flePROPERTIES, flePROP_COMMENTS, fleLOCN_BK_COMMENTS, M_START_WEEK,
                            //M_END_WEEK, M_START_DATE, M_END_DATE, M_BOOKED, X_BOOKING_REF, T_BALANCE);
                        }
                        else
                        {
                            if (QDesign.NULL(D_PUBLIC_BOND.Value) == "P")
                            {
                                //RunScreen("TEN0300.QKC", RunScreenModes.Entry, fleM_INVESTORS, fleUSER_SEC_FILE, flePASSING_PROPERTY, fleSCREEN_PROPERTY, flePROPERTIES, flePROP_COMMENTS, fleLOCN_BK_COMMENTS, M_START_WEEK,
                                //M_END_WEEK, M_START_DATE, M_END_DATE, M_BOOKED, X_BOOKING_REF, T_BALANCE);
                            }
                            else
                            {
                                object[] arrRunscreen = { fleM_INVESTORS, fleUSER_SEC_FILE, flePASSING_PROPERTY, fleSCREEN_PROPERTY, flePROPERTIES, flePROP_COMMENTS, fleLOCN_BK_COMMENTS, M_START_WEEK,
                                M_END_WEEK, M_START_DATE, M_END_DATE, M_BOOKED, X_BOOKING_REF, T_BALANCE };
                                RunScreen(new BOOK0300(), RunScreenModes.Entry, ref arrRunscreen);
                            }
                        }
                        ReturnAndClose();
                        // RETURN
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



        private void dsrDesigner_COMM_Click(object sender, System.EventArgs e)
        {

            try
            {

                T_OCCURRENCE.Value = Occurrence;
                while (fleSCREEN_PROPERTY.For())
                {
                    if (Occurrence == QDesign.NULL(T_OCCURRENCE.Value))
                    {
                        T_PROPERTY_CODE.Value = fleSCREEN_PROPERTY.GetStringValue("LOCATION") + fleSCREEN_PROPERTY.GetStringValue("BEDS") + fleSCREEN_PROPERTY.GetStringValue("PROPERTY_STYLE") + fleSCREEN_PROPERTY.GetStringValue("BATHROOMS") + fleSCREEN_PROPERTY.GetStringValue("PROPERTY_ID");
                        //Parent:PROPERTY_CODE
                        //RunScreen("DISPCOMM.QKC", RunScreenModes.Find, T_PROPERTY_CODE);
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



        private void dsrDesigner_PROP_Click(object sender, System.EventArgs e)
        {

            try
            {

                T_OCCURRENCE.Value = Occurrence;
                while (fleSCREEN_PROPERTY.For())
                {
                    if (Occurrence == QDesign.NULL(T_OCCURRENCE.Value))
                    {
                        T_LOCATION.Value = fleSCREEN_PROPERTY.GetStringValue("LOCATION");
                        T_PROPERTY_ID.Value = fleSCREEN_PROPERTY.GetStringValue("PROPERTY_ID");
                        //RunScreen("PROPDETS.QKC", RunScreenModes.Find, T_LOCATION, T_PROPERTY_ID);
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



        private void dsrDesigner_LD_Click(object sender, System.EventArgs e)
        {

            try
            {

                T_LOCATION.Value = fleSCREEN_PROPERTY.GetStringValue("LOCATION");
                T_PROPERTY_ID.Value = fleSCREEN_PROPERTY.GetStringValue("PROPERTY_ID");
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



        private void dsrDesigner_WAIT_Click(object sender, System.EventArgs e)
        {

            try
            {

                T_PASS_LOCATION.Value = QDesign.Substring(M_INDEX_KEY.Value, 9, 2);
                T_PASS_INVESTOR.Value = fleM_INVESTORS.GetStringValue("INVESTOR");
                T_PASS_SCREEN.Value = "BOOK";
                //RunScreen("WAITLIST.QKC", RunScreenModes.Find, T_PASS_LOCATION, T_PASS_INVESTOR, T_PASS_SCREEN, T_WAIT_DATE_FROM, T_WAIT_DATE_TO);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_OWN_Click(object sender, System.EventArgs e)
        {

            try
            {

                //RunScreen("VIEWARIV.QKC", RunScreenModes.Find, flePROPERTIES);


            }
            catch (CustomApplicationException ex)
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

                // Close fleSCREEN_PROPERTY
                // Close flePUT_PROP

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



        private void dsrDesigner_99_Click(object sender, System.EventArgs e)
        {

            try
            {

                // --> GET LOCATIONS <--
                m_strWhere = new StringBuilder(" WHERE ");
                m_strWhere.Append(" ").Append(fleLOCATIONS.ElementOwner("LOCATION")).Append(" = ");
                m_strWhere.Append(Common.StringToField(QDesign.Substring(M_PROPERTY_TYPE.Value, 1, 2)));

                fleLOCATIONS.GetData(m_strWhere.ToString());
                // --> End GET LOCATIONS <--
                //RunScreen("UCHARGE2.QKC", RunScreenModes.Find, fleLOCATIONS, M_YEAR);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_WEB_Click(object sender, System.EventArgs e)
        {

            try
            {

                Information(D_LOC_LINK.Value);
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


        protected override bool Update()
        {


            try
            {

                while (fleSCREEN_PROPERTY.For())
                {
                    fleSCREEN_PROPERTY.PutData();
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



        protected override bool Find()
        {


            try
            {
                bool blnAddWhere = true;
               
                while (fleSCREEN_PROPERTY.ForMissing())
                {
                    fleSCREEN_PROPERTY.GetData(GetDataOptions.CreateSubSelect);

                }
                               

                return true;


            }
            catch (CustomApplicationException ex)
            {
                if (ex.Message == "IM.NoRecords")
                    M_BOOKED.Value = "Y";
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
                Page.PageTitle = "";
                // TODO: Replace ???? with proper resource number.



            }
            catch (CustomApplicationException ex)
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
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 07/12/2013 1:49:40 PM
        //#-----------------------------------------
        protected override bool Append()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:49:40 PM
                Accept(ref fldSCREEN_PROPERTY_PROPERTY_CODE);
                Accept(ref fldPROPERTIES_CHANGEOVER_DAY);
                Accept(ref fldD_GUARANTEE);
                Accept(ref fldD_ON_REQUEST);
                Accept(ref fldPROPERTIES_PROPERTY_NAME);
                Accept(ref fldPROP_COMMENTS_PROP_COMM1);
                Accept(ref fldPROP_COMMENTS_PROP_COMM2);
                Accept(ref fldPROP_COMMENTS_PROP_COMM3);
                Accept(ref fldPROP_COMMENTS_PROP_COMM4);
                Accept(ref fldPROP_COMMENTS_PROP_COMM5);
                Accept(ref fldSCREEN_PROPERTY_PROPERTY_DATE_1);
                Accept(ref fldSCREEN_PROPERTY_PROPERTY_DATE_2);
                Accept(ref fldSCREEN_PROPERTY_PROPERTY_DATE_3);
                Accept(ref fldSCREEN_PROPERTY_PROPERTY_DATE_4);
                Accept(ref fldSCREEN_PROPERTY_PROPERTY_DATE_5);
                Accept(ref fldSCREEN_PROPERTY_PROPERTY_DATE_6);
                Accept(ref fldSCREEN_PROPERTY_PROPERTY_DATE_7);
                Accept(ref fldSCREEN_PROPERTY_PROPERTY_DATE_8);
                Accept(ref fldSCREEN_PROPERTY_PROPERTY_DATE_9);
                Accept(ref fldSCREEN_PROPERTY_PROPERTY_DATE_10);
                Accept(ref fldSCREEN_PROPERTY_PERIOD_1);
                Accept(ref fldSCREEN_PROPERTY_PERIOD_2);
                Accept(ref fldSCREEN_PROPERTY_PERIOD_3);
                Accept(ref fldSCREEN_PROPERTY_PERIOD_4);
                Accept(ref fldSCREEN_PROPERTY_PERIOD_5);
                Accept(ref fldSCREEN_PROPERTY_PERIOD_6);
                Accept(ref fldSCREEN_PROPERTY_PERIOD_7);
                Accept(ref fldSCREEN_PROPERTY_PERIOD_8);
                Accept(ref fldSCREEN_PROPERTY_PERIOD_9);
                Accept(ref fldSCREEN_PROPERTY_PERIOD_10);
                Accept(ref fldSCREEN_PROPERTY_WEEK_STATUS_1);
                Accept(ref fldSCREEN_PROPERTY_WEEK_STATUS_2);
                Accept(ref fldSCREEN_PROPERTY_WEEK_STATUS_3);
                Accept(ref fldSCREEN_PROPERTY_WEEK_STATUS_4);
                Accept(ref fldSCREEN_PROPERTY_WEEK_STATUS_5);
                Accept(ref fldSCREEN_PROPERTY_WEEK_STATUS_6);
                Accept(ref fldSCREEN_PROPERTY_WEEK_STATUS_7);
                Accept(ref fldSCREEN_PROPERTY_WEEK_STATUS_8);
                Accept(ref fldSCREEN_PROPERTY_WEEK_STATUS_9);
                Accept(ref fldSCREEN_PROPERTY_WEEK_STATUS_10);
                Accept(ref fldT_POINTS_1A);
                Accept(ref fldT_POINTS_2A);
                Accept(ref fldT_POINTS_3A);
                Accept(ref fldT_POINTS_4A);
                Accept(ref fldT_POINTS_5A);
                Accept(ref fldT_POINTS_6A);
                Accept(ref fldT_POINTS_7A);
                Accept(ref fldT_POINTS_8A);
                Accept(ref fldT_POINTS_9A);
                Accept(ref fldT_POINTS_10A);
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
        //# dtl_EditClick Procedure
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 07/12/2013 1:49:40 PM
        //#-----------------------------------------
        private void dtl_EditClick(DataList source, GridButtonEventArgs GridButtonEventArgs)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:49:40 PM
                dsrDesigner_01_Click(null, null);
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
