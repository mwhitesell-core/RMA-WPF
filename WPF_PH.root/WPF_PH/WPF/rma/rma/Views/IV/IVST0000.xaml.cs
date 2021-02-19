
#region "Screen Comments"

// ---------------------------------------------------------------;
// :
// system:    Holiday Property Bond                            :
// :
// program:   IVST0000                                         :
// : 
// task:      Get Investor and drive other screens             :
// :
// files:     M-INVESTORS      Primary                         :
// INDEX-INVESTORS  Secondary                             :
// :
// screens                                                     :
// called by:    MENU0000    Main system menu                  :
// calling:   IVST0100    Additional investment screen         :
// ACCTMOVE    View movements on the account              :
// :
// subprograms:  xxxxxxxx                                      :
// :
// ---------------------------------------------------------------:
// ---------------------------------------------------------------:
// Amendments  Date     Desc....                                 :
// WJMC   2/2/94      Investor QDesign.Index file not written          :
// (Call #8074) so added postcommands                :
// update stay for all design. Procs.                :
// ---------------------------------------------------------------:
// 14/09/94 - add `close` to all files
// ---------------------------------------------------------------
// 29/09/94 - removed all postcommand update stays because they
// don`t work and are cocking things up !!
// ---------------------------------------------------------------
// 01/09/95 - get USER-SEC-FILE in postfind
// --------------------------------------------------------------------
// 07/11/95 - User level 04 and above only to change data (was 02).
// --------------------------------------------------------------------
// 08/11/95 - make POST-CODE-AREA required.
// --------------------------------------------------------------------
// 03/01/96 - designer procedures FON and FOFF to change QKLIST
// --------------------------------------------------------------------
// 15/04/96 - Warn if investment-date is within 28 days.
// --------------------------------------------------------------------
// 16/04/96 - Make get on INVESTMENTS optional (00006 etc)
// --------------------------------------------------------------------
// 16/04/96 - removed DELETE from screen activities statement.
// --------------------------------------------------------------------
// 13/05/96 - User level 03 and above only to change data (was 04).
// --------------------------------------------------------------------
// 24/05/96 - Year 2000 changes.
// --------------------------------------------------------------------
// 06/11/96 - Warn if within 33 days since New Investor Letter was sent.
// --------------------------------------------------------------------
// 19/06/97 - Automatically call comments screen INVCOMM.qkc if comments
// exist for the investor.
// -------------------------------------------------------------------
// 27/06/97 - changed from INPUT to PROCESS T-COMMENTS
// -------------------------------------------------------------------
// 26/04/99 - moved the option titles up one line to make space
// -------------------------------------------------------------------
// 05/10/99 - new-investor check changed from 33 to 28 days
// --------------------------------------------------------------------
// 01/06/01 - run screen $QKC/CREDITS.qkc no mode - option 35
// --------------------------------------------------------------------
// 06/06/01 - Add EMAIL field to screen
// --------------------------------------------------------------------
// 18/06/02 - CHANGE FROM USING SHARINDX.SUBSAVE TO SHARE-INDEX
// --------------------------------------------------------------------
// 30/07/2002 Kevin Fuller: T-start-date && t-end-date items
// with revised initial values.
// ----------------------------------------------------------------
// 01/12/02 Kevin Fuller: Prompt user when address change made
// to apply to PRB and/or Shareholder files
// -----------------------------------------------------------------
// 11/02/03 - Alternative printers added for some users - IM
// -----------------------------------------------------------------
// 19/02/03 - ADD MENU ITEM FOR SHAREHOLDER QUOTE
// -------------------------------------------------------------------
// 08/03/03 - mge - Unix conversion
// -------------------------------------------------------------------
// 25/03/03 - Changed title from  Fax  to Fax/Mob 
// -------------------------------------------------------------------
// 10/10/03 - warn user and stop bookings if dd-failed-date <> 0
// -------------------------------------------------------------------
// 26/11/03 - removed t-email as it is now in repdefs.use
// -------------------------------------------------------------------
// 26/11/03 - amend-date was not being set if corr-title or initials
// were changed.
// -------------------------------------------------------------------
// 10.12.03 - Phil - replaced Cancel Investor with dddirect
// -------------------------------------------------------------------
// 11.12.03 - Phil - replaced dddirect with ddpaymnt
// -------------------------------------------------------------------
// 15.12.03 - Phil - Added DMD Diamond Calculator
// -------------------------------------------------------------------
// 07/01/04 - Rob - added field silver-gold to the screen
// -------------------------------------------------------------------
// 12/03/04 - ROB - DD-FAILED-DATE <> 0 Allow to continue after warnings!
// -------------------------------------------------------------------
// 25/06/04 - Ingrid - Added `D` to acceptable colours
// -------------------------------------------------------------------
// 06.10.04 - ME - change 28 day cooling-off period to 30 days.
// -------------------------------------------------------------------
// 28.10.04 - ME - check allow-booking of dd-details - warn if set to  N 
// -------------------------------------------------------------------
// 05.01.05 - ME - Add check to ensure correct screen is used for booking.
// -------------------------------------------------------------------
// 25.01.05 - ME - Removed warning on dd-failed-date of M-INVESTORS as
// it does not get reset when dd has resumed ok.
// -------------------------------------------------------------------
// 07.06.05 - ME - For owners bookings, allow 999 codes which are not
// for owners ie. 999SH, 999HU, 999RF etc.
// -------------------------------------------------------------------
// 24/08/05 - RC added check for bondholders under satisfaction guarantee
// -------------------------------------------------------------------
// 28.09.05 - ME   Add new parameter for ddpaymnt.qkc
// -------------------------------------------------------------------
// 17/01/06 - RC  Added nochange to guarantee-end-date / under-guarantee
// -------------------------------------------------------------------
// 13/07/06 - RC  Dont set investor to `00000` if left blank.
// This now allows `searches` to work.
// -------------------------------------------------------------------
// 20.09.06 - ME  Display  SAGA MEMBERSHIP  if saga-flag set.
// -------------------------------------------------------------------
// 22.09.06 - ME  Display message when incorrect email addr is shown.
// -------------------------------------------------------------------
// 13.10.06 - PJ  Ignore cancelled share details
// -------------------------------------------------------------------
// 07.12.06   ME  Accept only 999SH booking from Stately Holiday Homes
// menu - all owner bookings now done from main menu.
// -------------------------------------------------------------------
// 03/05/07 RC  Removed PROCEDURE DESIGNER FAX, must be very old code!
// -------------------------------------------------------------------
// 03/05/07 RC  Added Designer Procedure CH to call carhirev.qkc
// -------------------------------------------------------------------
// 14/11/07 PJ  Added check of error-flag - P = Policies not operational
// -------------------------------------------------------------------
// 20/11/07 PJ  Removed check of error-flag P - other issues need sorting first
// -------------------------------------------------------------------
// 03/12/07 PJ  Allow changes to email address and added t-top-message
// -------------------------------------------------------------------
// 04/01/08 PJ  re-Added check of error-flag - P = Policies not operational
// -------------------------------------------------------------------
// 07/01/08 PJ  AA flag added, and saga changed to look for S rather than Y
// -------------------------------------------------------------------
// 10.03.08 ME  pass t-investor to partrfnd.qkc rather than m-investors  
// file and then push find on return to avoid duplicate key.
// -------------------------------------------------------------------
// 12.05.08 IM Increased pics to accommodate largest trans amounts
// and running balances (principally for Bond 75885)
// ---------------------------------------------------------------
// 04.08.08 ME  Add check for Annual insurance.
// ---------------------------------------------------------------
// 03.10.08 PJ  Reformatting the Annual Insurance stuff
// ---------------------------------------------------------------
// 16.02.09 IM  Error flag if change attempted in silver-gold field
// ----------------------------------------------------------------
// 11.06.09 PJ  Call subscreen for change of address processing when
// doing ID 4 or 5.  No longer allow change of email address
// as it no longer works.
// ----------------------------------------------------------------
// 22.06.09 ME  Add screen to show Investor Airports (designer airports).
// ----------------------------------------------------------------
// 26/06/09 RC  Call the Flights screens
// ----------------------------------------------------------------
// 09/07/09 PJ  Added id 37 insurance subscreen, and relabeled insurance
// ----------------------------------------------------------------
// 17/07/09 PJ  Added check of error-flag when looking for new investors
// ----------------------------------------------------------------
// 26.08.09 ME  Change selection on insurance to check if cancelled.
// ----------------------------------------------------------------
// 26.08.09 ME  Give Linda access to look at PRB Investor info.
// ----------------------------------------------------------------
// 18/03/10 RC  Don`t INFO or WARN with RESPONSE or call screens for
// signonuser weblive (to avoid errors using QKIN)
// ----------------------------------------------------------------
// 03.06.10 PJ  Give Angela Sewell access to change other address info 
// ----------------------------------------------------------------
// 15.10.10 ME  Re-get email address after booking for  My Bookings . 
// ----------------------------------------------------------------
// 12/11/10 PJ  remove check of error-flag when looking for new investors
// as per conversation with JCB/PC/SC today
// ----------------------------------------------------------------
// 17.01.11 RM  Change No 26 `Suspense Account` to `Special Reserve`
// ----------------------------------------------------------------
// 04.04.11 RM  Add shortcut to SNLOCS screen
// ----------------------------------------------------------------
// 25.05.11 PJ  Change dmd screen to dmdpol.qkc
// ----------------------------------------------------------------
// 07.11.12 ME  Add selection for dd-details file to make sure
// the correct record is picked up.
// ----------------------------------------------------------------
// 04.01.13 RC  Changed label from 10 Investments to 10 Initial Entitlement
// ----------------------------------------------------------------
// 16.01.13 ME  Stop investor defaulting to bond  00000 .                  
// ----------------------------------------------------------------
// 22.03.13 ME  Change label  fax/mob  to  Mobile .
// ----------------------------------------------------------------

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

    partial class IVST0000 : BasePage
    {

        #region " Form Designer Generated Code "





        public IVST0000()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "IVST0000";

            //# Set the ACTIVITIES for the screen.
            this.ChangeActivity = true;
            this.FindActivity = true;
            this.DeleteActivity = false;
            this.EntryActivity = true;
            this.StopScreen = true;
            this.UseAcceptProcessing = true;
            this.HasPathRequestFields = true;
           
        }

        #endregion

        private void Page_Load(object sender, RoutedEventArgs e)
        {
            SetVariables();
            dsrDesigner_AIRPORTS.Click += dsrDesigner_AIRPORTS_Click;
            dsrDesigner_SN.Click += dsrDesigner_SN_Click;
            dsrDesigner_ADJ3.Click += dsrDesigner_ADJ3_Click;
            dsrDesigner_OADDR.Click += dsrDesigner_OADDR_Click;
            dsrDesigner_PRB.Click += dsrDesigner_PRB_Click;
            dsrDesigner_04.Click += dsrDesigner_04_Click;
            dsrDesigner_05.Click += dsrDesigner_05_Click;
            dsrDesigner_09.Click += dsrDesigner_09_Click;
            dsrDesigner_10.Click += dsrDesigner_10_Click;
            dsrDesigner_11.Click += dsrDesigner_11_Click;
            dsrDesigner_12.Click += dsrDesigner_12_Click;
            dsrDesigner_13.Click += dsrDesigner_13_Click;
            dsrDesigner_14.Click += dsrDesigner_14_Click;
            dsrDesigner_15.Click += dsrDesigner_15_Click;
            dsrDesigner_16.Click += dsrDesigner_16_Click;
            dsrDesigner_17.Click += dsrDesigner_17_Click;
            dsrDesigner_18.Click += dsrDesigner_18_Click;
            dsrDesigner_19.Click += dsrDesigner_19_Click;
            dsrDesigner_20.Click += dsrDesigner_20_Click;
            dsrDesigner_21.Click += dsrDesigner_21_Click;
            dsrDesigner_22.Click += dsrDesigner_22_Click;
            dsrDesigner_23.Click += dsrDesigner_23_Click;
            dsrDesigner_24.Click += dsrDesigner_24_Click;
            dsrDesigner_25.Click += dsrDesigner_25_Click;
            dsrDesigner_27.Click += dsrDesigner_27_Click;
            dsrDesigner_26.Click += dsrDesigner_26_Click;
            dsrDesigner_28.Click += dsrDesigner_28_Click;
            dsrDesigner_29.Click += dsrDesigner_29_Click;
            dsrDesigner_30.Click += dsrDesigner_30_Click;
            dsrDesigner_31.Click += dsrDesigner_31_Click;
            dsrDesigner_32.Click += dsrDesigner_32_Click;
            dsrDesigner_LD.Click += dsrDesigner_LD_Click;
            dsrDesigner_33.Click += dsrDesigner_33_Click;
            dsrDesigner_34.Click += dsrDesigner_34_Click;
            dsrDesigner_35.Click += dsrDesigner_35_Click;
            dsrDesigner_36.Click += dsrDesigner_36_Click;
            dsrDesigner_37.Click += dsrDesigner_37_Click;
            dsrDesigner_LOG.Click += dsrDesigner_LOG_Click;
            dsrDesigner_TEMP.Click += dsrDesigner_TEMP_Click;
            dsrDesigner_PRNT.Click += dsrDesigner_PRNT_Click;
            dsrDesigner_CORE_CHECK.Click += dsrDesigner_CORE_CHECK_Click;
            dsrDesigner_DMD.Click += dsrDesigner_DMD_Click;
            dsrDesigner_CH.Click += dsrDesigner_CH_Click;
            dsrDesigner_FLIGHTS.Click += dsrDesigner_FLIGHTS_Click;
            dsrDesigner_06.Click += dsrDesigner_06_Click;
            dsrDesigner_07.Click += dsrDesigner_07_Click;
            dsrDesigner_02.Click += dsrDesigner_02_Click;
            dsrDesigner_03.Click += dsrDesigner_03_Click;
            dsrDesigner_08.Click += dsrDesigner_08_Click;
            
            fldM_INVESTORS_INVESTOR.LookupNotOn += fldM_INVESTORS_INVESTOR_LookupNotOn;
            fldM_INVESTORS_INVESTOR.Input += fldM_INVESTORS_INVESTOR_Input;
            fldM_INVESTORS_CORR_TITLE.Input += fldM_INVESTORS_CORR_TITLE_Input;
            fldM_INVESTORS_CORR_NAME.Input += fldM_INVESTORS_CORR_NAME_Input;
            fldM_INVESTORS_COLOUR.Input += fldM_INVESTORS_COLOUR_Input;
            fldM_INVESTORS_SILVER_GOLD.Input += fldM_INVESTORS_SILVER_GOLD_Input;
            fldM_INVESTORS_DOB.Input += fldM_INVESTORS_DOB_Input;
            fldM_INVESTORS_INVESTOR.Process += fldM_INVESTORS_INVESTOR_Process;
            fldM_INVESTORS_INITIAL_1.Process += fldM_INVESTORS_INITIAL_1_Process;
            fldM_INVESTORS_INITIAL_2.Process += fldM_INVESTORS_INITIAL_2_Process;
            fldM_INVESTORS_CORR_TITLE.Process += fldM_INVESTORS_CORR_TITLE_Process;
            fldM_INVESTORS_CORR_NAME.Process += fldM_INVESTORS_CORR_NAME_Process;
            fldM_INVESTORS_ADDRESS_1.Process += fldM_INVESTORS_ADDRESS_1_Process;
            fldM_INVESTORS_ADDRESS_2.Process += fldM_INVESTORS_ADDRESS_2_Process;
            fldM_INVESTORS_ADDRESS_3.Process += fldM_INVESTORS_ADDRESS_3_Process;
            fldM_INVESTORS_ADDRESS_4.Process += fldM_INVESTORS_ADDRESS_4_Process;
            fldM_INVESTORS_POST_CODE_AREA.Process += fldM_INVESTORS_POST_CODE_AREA_Process;
            fldM_INVESTORS_COLOUR.Process += fldM_INVESTORS_COLOUR_Process;
            fldT_COMMENTS.Process += fldT_COMMENTS_Process;
           

            Page_Load();

            // TODO: The following elements have Input/Output Scaling defined in the Dictionary or Screen.  Manual steps may be required:
            //       INVESTMENTS.TERM_SURCHARGEPER InputScale: 2 OutputScale: 0


        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            T_SHHL_INV = new CoreCharacter("T_SHHL_INV", 8, this, Common.cEmptyString);
            fleM_INVESTORS = new OracleFileObject(this, FileTypes.Primary, 0, "INDEXED", "M_INVESTORS", "", true, false, true, 0, "m_trnTRANS_UPDATE");
            fleINDEX_INVESTORS = new OracleFileObject(this, FileTypes.Secondary, 0, "INDEXED", "INDEX_INVESTORS", "", true, false, true, 0, "m_trnTRANS_UPDATE");
            fleEMAILS = new OracleFileObject(this, FileTypes.Secondary, 0, "INDEXED", "EMAILS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleCURRENT_ENT1 = new OracleFileObject(this, FileTypes.Reference, 0, "INDEXED", "CURRENT_ENTS", "CURRENT_ENT1", false, false, false, 0, "m_cnnQUERY");
            fleCURRENT_ENT2 = new OracleFileObject(this, FileTypes.Reference, 0, "INDEXED", "CURRENT_ENTS", "CURRENT_ENT2", false, false, false, 0, "m_cnnQUERY");
            fleCURRENT_ENT3 = new OracleFileObject(this, FileTypes.Reference, 0, "INDEXED", "CURRENT_ENTS", "CURRENT_ENT3", false, false, false, 0, "m_cnnQUERY");
            fleINVESTMENTS = new OracleFileObject(this, FileTypes.Reference, 0, "INDEXED", "INVESTMENTS", "", false, false, false, 0, "m_cnnQUERY");
            fleINVESTOR_LETTERS = new OracleFileObject(this, FileTypes.Designer, 0, "INDEXED", "INVESTOR_LETTERS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleBOOKING_COMMENTS = new OracleFileObject(this, FileTypes.Reference, 0, "INDEXED", "BOOKING_COMMENTS", "", false, false, false, 0, "m_cnnQUERY");
            fleSHARE_INDEX = new OracleFileObject(this, FileTypes.Reference, 0, "INDEXED", "SHARE_INDEX", "", false, false, false, 0, "m_cnnQUERY");
            T_SHRUPD = new CoreCharacter("T_SHRUPD", 1, this, Common.cEmptyString);
            flePRB_INVESTORS = new OracleFileObject(this, FileTypes.Designer, 0, "INDEXED", "PRB_INVESTORS", "", false, false, true, 0, "m_trnTRANS_UPDATE");
            T_PRBUPD = new CoreCharacter("T_PRBUPD", 1, this, Common.cEmptyString);
            fleWORKFILE = new OracleFileObject(this, FileTypes.Designer, 0, "DIRECT", "CORE_WORK", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleUSER_SEC_FILE = new OracleFileObject(this, FileTypes.Designer, 0, "INDEXED", "USER_SEC_FILE", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleDD_DETAILS = new OracleFileObject(this, FileTypes.Designer, 0, "INDEXED", "DD_DETAILS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleLOCATIONS = new OracleFileObject(this, FileTypes.Designer, 0, "INDEXED", "LOCATIONS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleCANCEL_INVEST = new OracleFileObject(this, FileTypes.Reference, 0, "INDEXED", "CANCEL_INVEST", "", false, false, false, 0, "m_cnnQUERY");
            fleINSURANCE = new OracleFileObject(this, FileTypes.Reference, 0, "INDEXED", "INSURANCE", "", false, false, false, 0, "m_cnnQUERY");
            T_INVESTOR = new CoreCharacter("T_INVESTOR", 8, this, Common.cEmptyString);
            T_BOOKING_REF = new CoreCharacter("T_BOOKING_REF", 8, this, Common.cEmptyString);
            T_TYPE = new CoreCharacter("T_TYPE", 1, this, Common.cEmptyString);
            T_ADDRESS_1 = new CoreCharacter("T_ADDRESS_1", 30, this, Common.cEmptyString);
            T_ADDRESS_2 = new CoreCharacter("T_ADDRESS_2", 30, this, Common.cEmptyString);
            T_ADDRESS_3 = new CoreCharacter("T_ADDRESS_3", 30, this, Common.cEmptyString);
            T_ADDRESS_4 = new CoreCharacter("T_ADDRESS_4", 30, this, Common.cEmptyString);
            T_INVESTOR_NAME = new CoreCharacter("T_INVESTOR_NAME", 30, this, Common.cEmptyString);
            T_POST_CODE_AREA = new CoreCharacter("T_POST_CODE_AREA", 4, this, Common.cEmptyString);
            T_POST_CODE_ZONE = new CoreCharacter("T_POST_CODE_ZONE", 4, this, Common.cEmptyString);
            T_JOBSTREAM = new CoreCharacter("T_JOBSTREAM", 80, this, Common.cEmptyString);
            T_COMMAND = new CoreCharacter("T_COMMAND", 80, this, Common.cEmptyString);
            T_FAX_NO = new CoreCharacter("T_FAX_NO", 16, this, Common.cEmptyString);
            T_COMMENTS = new CoreCharacter("T_COMMENTS", 1, this, Common.cEmptyString);
            T_PASS_INVESTOR = new CoreCharacter("T_PASS_INVESTOR", 8, this);
            T_PASS_LOCATION = new CoreCharacter("T_PASS_LOCATION", 2, this, Common.cEmptyString);
            T_PASS_SCREEN = new CoreCharacter("T_PASS_SCREEN", 4, this, ResetTypes.ResetAtStartup, "INVS");
            T_START_DATE = new CoreDate("T_START_DATE", this, ResetTypes.ResetAtStartup);
            T_END_DATE = new CoreDate("T_END_DATE", this, ResetTypes.ResetAtStartup);
            T_LOCATION = new CoreCharacter("T_LOCATION", 2, this, Common.cEmptyString);
            T_PROPERTY_ID = new CoreCharacter("T_PROPERTY_ID", 4, this, Common.cEmptyString);
            T_ADDR_CHANGED = new CoreCharacter("T_ADDR_CHANGED", 1, this, Common.cEmptyString);
            T_SHARE_NO = new CoreCharacter("T_SHARE_NO", 8, this, Common.cEmptyString);
            T_DD_TYPE = new CoreCharacter("T_DD_TYPE", 2, this, " ");
            T_DATE = new CoreDate("T_DATE", this);
            T_HIRE_LOCATION = new CoreCharacter("T_HIRE_LOCATION", 4, this, Common.cEmptyString);
            T_TOP_MESSAGE = new CoreCharacter("T_TOP_MESSAGE", 55, this, Common.cEmptyString);
            T_CUSTOMER_TYPE = new CoreCharacter("T_CUSTOMER_TYPE", 1, this, "B");
            T_ADDRESS_CHANGED = new CoreCharacter("T_ADDRESS_CHANGED", 1, this, Common.cEmptyString);
            T_PRB_ACCESS = new CoreCharacter("T_PRB_ACCESS", 20, this, " ");
            T_NEW_EMAIL_OK = new CoreCharacter("T_NEW_EMAIL_OK", 1, this, "N");
            T_JOBNO = new CoreCharacter("T_JOBNO", 9, this, Common.cEmptyString);
            T_JOBFIL = new CoreCharacter("T_JOBFIL", 11, this, Common.cEmptyString);
            T_JOBJNO = new CoreCharacter("T_JOBJNO", 11, this, Common.cEmptyString);
            T_JOBNUM = new CoreCharacter("T_JOBNUM", 11, this, Common.cEmptyString);
            T_JOBOWN = new CoreCharacter("T_JOBOWN", 11, this, Common.cEmptyString);
            T_REPNAME = new CoreCharacter("T_REPNAME", 8, this, " ");
            T_REPNAME2 = new CoreCharacter("T_REPNAME2", 8, this, " ");
            T_REPNAME3 = new CoreCharacter("T_REPNAME3", 8, this, " ");
            T_REPNAME4 = new CoreCharacter("T_REPNAME4", 8, this, " ");
            T_REPNAME5 = new CoreCharacter("T_REPNAME5", 8, this, " ");
            T_REPNAME6 = new CoreCharacter("T_REPNAME6", 8, this, " ");
            T_PROGNAME = new CoreCharacter("T_PROGNAME", 8, this, " ");
            T_PRINTER = new CoreCharacter("T_PRINTER", 12, this, " ");
            T_COPIES = new CoreCharacter("T_COPIES", 2, this, "1");
            T_RUNTIME = new CoreCharacter("T_RUNTIME", 4, this, " ");
            T_DEL_TEMPS = new CoreCharacter("T_DEL_TEMPS", 1, this, ResetTypes.ResetAtMode, "Y");
            T_DEL_JOBFILE = new CoreCharacter("T_DEL_JOBFILE", 1, this, ResetTypes.ResetAtMode, "N");
            T_DEL_REPORT = new CoreCharacter("T_DEL_REPORT", 1, this, ResetTypes.ResetAtMode, "N");
            T_PRINT_REPORT = new CoreCharacter("T_PRINT_REPORT", 1, this, ResetTypes.ResetAtMode, "Y");
            T_EMAIL_REPORT = new CoreCharacter("T_EMAIL_REPORT", 1, this, ResetTypes.ResetAtMode, "N");
            T_EMAIL = new CoreCharacter("T_EMAIL", 50, this, Common.cEmptyString);
            T_EMAIL_SUBJECT = new CoreCharacter("T_EMAIL_SUBJECT", 50, this, "rma Arrivals");

            fleINDEX_INVESTORS.Access += fleINDEX_INVESTORS_Access;
            fleEMAILS.Access += fleEMAILS_Access;
            D_UPDATE_EMAIL_WEB.GetValue += D_UPDATE_EMAIL_WEB_GetValue;
            fleCURRENT_ENT1.Access += fleCURRENT_ENT1_Access;
            fleCURRENT_ENT2.Access += fleCURRENT_ENT2_Access;
            fleCURRENT_ENT3.Access += fleCURRENT_ENT3_Access;
            fleINVESTMENTS.Access += fleINVESTMENTS_Access;
            fleINVESTOR_LETTERS.Access += fleINVESTOR_LETTERS_Access;
            fleBOOKING_COMMENTS.Access += fleBOOKING_COMMENTS_Access;
            fleSHARE_INDEX.Access += fleSHARE_INDEX_Access;
            flePRB_INVESTORS.Access += flePRB_INVESTORS_Access;
            fleUSER_SEC_FILE.Access += fleUSER_SEC_FILE_Access;
            fleCANCEL_INVEST.Access += fleCANCEL_INVEST_Access;
            fleINSURANCE.Access += fleINSURANCE_Access;
            D_CHECK_ADDRESS.GetValue += D_CHECK_ADDRESS_GetValue;
            D_HOURS.GetValue += D_HOURS_GetValue;
            D_MINS.GetValue += D_MINS_GetValue;
            D_DAY.GetValue += D_DAY_GetValue;
            D_RUNTIME.GetValue += D_RUNTIME_GetValue;
            D_JOBDATE.GetValue += D_JOBDATE_GetValue;
            D_JOBOWN.GetValue += D_JOBOWN_GetValue;
            D_MAKEOWN.GetValue += D_MAKEOWN_GetValue;
            D_MAKE_WORK.GetValue += D_MAKE_WORK_GetValue;
            D_JOBNO.GetValue += D_JOBNO_GetValue;
            D_MAKEJNO.GetValue += D_MAKEJNO_GetValue;
            D_PROG_USER.GetValue += D_PROG_USER_GetValue;
            D_MAKELOG.GetValue += D_MAKELOG_GetValue;
            D_SHOWJNO.GetValue += D_SHOWJNO_GetValue;
            D_QUEUE.GetValue += D_QUEUE_GetValue;
            D_RUNJOB.GetValue += D_RUNJOB_GetValue;
            D_STRIPJOB.GetValue += D_STRIPJOB_GetValue;
            D_CATJOB.GetValue += D_CATJOB_GetValue;
            D_QUTIL_START.GetValue += D_QUTIL_START_GetValue;
            D_QTP_START.GetValue += D_QTP_START_GetValue;
            D_QUIZ_START.GetValue += D_QUIZ_START_GetValue;
            D_REPNAME.GetValue += D_REPNAME_GetValue;
            D_REPNAME2.GetValue += D_REPNAME2_GetValue;
            D_REPNAME3.GetValue += D_REPNAME3_GetValue;
            D_REPNAME4.GetValue += D_REPNAME4_GetValue;
            D_REPNAME5.GetValue += D_REPNAME5_GetValue;
            D_REPNAME6.GetValue += D_REPNAME6_GetValue;
            D_PRINT_REPORT.GetValue += D_PRINT_REPORT_GetValue;
            D_PRINT_REPORT_TRAY3.GetValue += D_PRINT_REPORT_TRAY3_GetValue;
            D_PRINT_REPORT_TRAY1.GetValue += D_PRINT_REPORT_TRAY1_GetValue;
            D_PRINT_REPORT_TRAY2.GetValue += D_PRINT_REPORT_TRAY2_GetValue;
            D_PRINT_DUPLEX.GetValue += D_PRINT_DUPLEX_GetValue;
            D_DEL_REPORT.GetValue += D_DEL_REPORT_GetValue;
            D_DEL_JOBFILE.GetValue += D_DEL_JOBFILE_GetValue;
            D_DEL_LOGFILE.GetValue += D_DEL_LOGFILE_GetValue;
            D_DEL_TEMPS.GetValue += D_DEL_TEMPS_GetValue;
            D_DEL_PHTMP.GetValue += D_DEL_PHTMP_GetValue;
            D_JOBLOG.GetValue += D_JOBLOG_GetValue;
            D_UNDER_GUARANTEE.GetValue += D_UNDER_GUARANTEE_GetValue;
            D_ENT_BAL1.GetValue += D_ENT_BAL1_GetValue;
            D_ENT_BAL2.GetValue += D_ENT_BAL2_GetValue;
            D_ENT_BAL3.GetValue += D_ENT_BAL3_GetValue;
            D_BF_BAL1.GetValue += D_BF_BAL1_GetValue;
            D_BF_BAL2.GetValue += D_BF_BAL2_GetValue;
            D_BF_BAL3.GetValue += D_BF_BAL3_GetValue;
            D_TOT_BAL1.GetValue += D_TOT_BAL1_GetValue;
            D_TOT_BAL2.GetValue += D_TOT_BAL2_GetValue;
            D_TOT_BAL3.GetValue += D_TOT_BAL3_GetValue;
            D_HY1_TITLE.GetValue += D_HY1_TITLE_GetValue;
            D_HY2_TITLE.GetValue += D_HY2_TITLE_GetValue;
            D_HY3_TITLE.GetValue += D_HY3_TITLE_GetValue;
            D_FROM_DATE.GetValue += D_FROM_DATE_GetValue;
            D_TO_DATE.GetValue += D_TO_DATE_GetValue;
            D_NEW_INVESTOR.GetValue += D_NEW_INVESTOR_GetValue;
            D_SHAREHOLDER.GetValue += D_SHAREHOLDER_GetValue;
            D_INSURANCE.GetValue += D_INSURANCE_GetValue;

        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;
            fleINDEX_INVESTORS.Access -= fleINDEX_INVESTORS_Access;
            fleEMAILS.Access -= fleEMAILS_Access;
            D_UPDATE_EMAIL_WEB.GetValue -= D_UPDATE_EMAIL_WEB_GetValue;
            fleCURRENT_ENT1.Access -= fleCURRENT_ENT1_Access;
            fleCURRENT_ENT2.Access -= fleCURRENT_ENT2_Access;
            fleCURRENT_ENT3.Access -= fleCURRENT_ENT3_Access;
            fleINVESTMENTS.Access -= fleINVESTMENTS_Access;
            fleINVESTOR_LETTERS.Access -= fleINVESTOR_LETTERS_Access;
            fleBOOKING_COMMENTS.Access -= fleBOOKING_COMMENTS_Access;
            fleSHARE_INDEX.Access -= fleSHARE_INDEX_Access;
            flePRB_INVESTORS.Access -= flePRB_INVESTORS_Access;
            fleUSER_SEC_FILE.Access -= fleUSER_SEC_FILE_Access;
            fleCANCEL_INVEST.Access -= fleCANCEL_INVEST_Access;
            fleINSURANCE.Access -= fleINSURANCE_Access;
            D_CHECK_ADDRESS.GetValue -= D_CHECK_ADDRESS_GetValue;
            D_HOURS.GetValue -= D_HOURS_GetValue;
            D_MINS.GetValue -= D_MINS_GetValue;
            D_DAY.GetValue -= D_DAY_GetValue;
            D_RUNTIME.GetValue -= D_RUNTIME_GetValue;
            D_JOBDATE.GetValue -= D_JOBDATE_GetValue;
            D_JOBOWN.GetValue -= D_JOBOWN_GetValue;
            D_MAKEOWN.GetValue -= D_MAKEOWN_GetValue;
            D_MAKE_WORK.GetValue -= D_MAKE_WORK_GetValue;
            D_JOBNO.GetValue -= D_JOBNO_GetValue;
            D_MAKEJNO.GetValue -= D_MAKEJNO_GetValue;
            D_PROG_USER.GetValue -= D_PROG_USER_GetValue;
            D_MAKELOG.GetValue -= D_MAKELOG_GetValue;
            D_SHOWJNO.GetValue -= D_SHOWJNO_GetValue;
            D_QUEUE.GetValue -= D_QUEUE_GetValue;
            D_RUNJOB.GetValue -= D_RUNJOB_GetValue;
            D_STRIPJOB.GetValue -= D_STRIPJOB_GetValue;
            D_CATJOB.GetValue -= D_CATJOB_GetValue;
            D_QUTIL_START.GetValue -= D_QUTIL_START_GetValue;
            D_QTP_START.GetValue -= D_QTP_START_GetValue;
            D_QUIZ_START.GetValue -= D_QUIZ_START_GetValue;
            D_REPNAME.GetValue -= D_REPNAME_GetValue;
            D_REPNAME2.GetValue -= D_REPNAME2_GetValue;
            D_REPNAME3.GetValue -= D_REPNAME3_GetValue;
            D_REPNAME4.GetValue -= D_REPNAME4_GetValue;
            D_REPNAME5.GetValue -= D_REPNAME5_GetValue;
            D_REPNAME6.GetValue -= D_REPNAME6_GetValue;
            D_PRINT_REPORT.GetValue -= D_PRINT_REPORT_GetValue;
            D_PRINT_REPORT_TRAY3.GetValue -= D_PRINT_REPORT_TRAY3_GetValue;
            D_PRINT_REPORT_TRAY1.GetValue -= D_PRINT_REPORT_TRAY1_GetValue;
            D_PRINT_REPORT_TRAY2.GetValue -= D_PRINT_REPORT_TRAY2_GetValue;
            D_PRINT_DUPLEX.GetValue -= D_PRINT_DUPLEX_GetValue;
            D_DEL_REPORT.GetValue -= D_DEL_REPORT_GetValue;
            D_DEL_JOBFILE.GetValue -= D_DEL_JOBFILE_GetValue;
            D_DEL_LOGFILE.GetValue -= D_DEL_LOGFILE_GetValue;
            D_DEL_TEMPS.GetValue -= D_DEL_TEMPS_GetValue;
            D_DEL_PHTMP.GetValue -= D_DEL_PHTMP_GetValue;
            D_JOBLOG.GetValue -= D_JOBLOG_GetValue;
            D_UNDER_GUARANTEE.GetValue -= D_UNDER_GUARANTEE_GetValue;
            D_ENT_BAL1.GetValue -= D_ENT_BAL1_GetValue;
            D_ENT_BAL2.GetValue -= D_ENT_BAL2_GetValue;
            D_ENT_BAL3.GetValue -= D_ENT_BAL3_GetValue;
            D_BF_BAL1.GetValue -= D_BF_BAL1_GetValue;
            D_BF_BAL2.GetValue -= D_BF_BAL2_GetValue;
            D_BF_BAL3.GetValue -= D_BF_BAL3_GetValue;
            D_TOT_BAL1.GetValue -= D_TOT_BAL1_GetValue;
            D_TOT_BAL2.GetValue -= D_TOT_BAL2_GetValue;
            D_TOT_BAL3.GetValue -= D_TOT_BAL3_GetValue;
            D_HY1_TITLE.GetValue -= D_HY1_TITLE_GetValue;
            D_HY2_TITLE.GetValue -= D_HY2_TITLE_GetValue;
            D_HY3_TITLE.GetValue -= D_HY3_TITLE_GetValue;
            D_FROM_DATE.GetValue -= D_FROM_DATE_GetValue;
            D_TO_DATE.GetValue -= D_TO_DATE_GetValue;
            D_NEW_INVESTOR.GetValue -= D_NEW_INVESTOR_GetValue;
            D_SHAREHOLDER.GetValue -= D_SHAREHOLDER_GetValue;
            D_INSURANCE.GetValue -= D_INSURANCE_GetValue;
            fldM_INVESTORS_INVESTOR.LookupNotOn -= fldM_INVESTORS_INVESTOR_LookupNotOn;
            fldM_INVESTORS_INVESTOR.Input -= fldM_INVESTORS_INVESTOR_Input;
            fldM_INVESTORS_CORR_TITLE.Input -= fldM_INVESTORS_CORR_TITLE_Input;
            fldM_INVESTORS_CORR_NAME.Input -= fldM_INVESTORS_CORR_NAME_Input;
            fldM_INVESTORS_COLOUR.Input -= fldM_INVESTORS_COLOUR_Input;
            fldM_INVESTORS_SILVER_GOLD.Input -= fldM_INVESTORS_SILVER_GOLD_Input;
            fldM_INVESTORS_DOB.Input -= fldM_INVESTORS_DOB_Input;
            fldM_INVESTORS_INVESTOR.Process -= fldM_INVESTORS_INVESTOR_Process;
            fldM_INVESTORS_INITIAL_1.Process -= fldM_INVESTORS_INITIAL_1_Process;
            fldM_INVESTORS_INITIAL_2.Process -= fldM_INVESTORS_INITIAL_2_Process;
            fldM_INVESTORS_CORR_TITLE.Process -= fldM_INVESTORS_CORR_TITLE_Process;
            fldM_INVESTORS_CORR_NAME.Process -= fldM_INVESTORS_CORR_NAME_Process;
            fldM_INVESTORS_ADDRESS_1.Process -= fldM_INVESTORS_ADDRESS_1_Process;
            fldM_INVESTORS_ADDRESS_2.Process -= fldM_INVESTORS_ADDRESS_2_Process;
            fldM_INVESTORS_ADDRESS_3.Process -= fldM_INVESTORS_ADDRESS_3_Process;
            fldM_INVESTORS_ADDRESS_4.Process -= fldM_INVESTORS_ADDRESS_4_Process;
            fldM_INVESTORS_POST_CODE_AREA.Process -= fldM_INVESTORS_POST_CODE_AREA_Process;
            fldM_INVESTORS_COLOUR.Process -= fldM_INVESTORS_COLOUR_Process;
            fldT_COMMENTS.Process -= fldT_COMMENTS_Process;

            dsrDesigner_AIRPORTS.Click -= dsrDesigner_AIRPORTS_Click;
            dsrDesigner_SN.Click -= dsrDesigner_SN_Click;
            dsrDesigner_ADJ3.Click -= dsrDesigner_ADJ3_Click;
            dsrDesigner_OADDR.Click -= dsrDesigner_OADDR_Click;
            dsrDesigner_PRB.Click -= dsrDesigner_PRB_Click;
            dsrDesigner_04.Click -= dsrDesigner_04_Click;
            dsrDesigner_05.Click -= dsrDesigner_05_Click;
            dsrDesigner_09.Click -= dsrDesigner_09_Click;
            dsrDesigner_10.Click -= dsrDesigner_10_Click;
            dsrDesigner_11.Click -= dsrDesigner_11_Click;
            dsrDesigner_12.Click -= dsrDesigner_12_Click;
            dsrDesigner_13.Click -= dsrDesigner_13_Click;
            dsrDesigner_14.Click -= dsrDesigner_14_Click;
            dsrDesigner_15.Click -= dsrDesigner_15_Click;
            dsrDesigner_16.Click -= dsrDesigner_16_Click;
            dsrDesigner_17.Click -= dsrDesigner_17_Click;
            dsrDesigner_18.Click -= dsrDesigner_18_Click;
            dsrDesigner_19.Click -= dsrDesigner_19_Click;
            dsrDesigner_20.Click -= dsrDesigner_20_Click;
            dsrDesigner_21.Click -= dsrDesigner_21_Click;
            dsrDesigner_22.Click -= dsrDesigner_22_Click;
            dsrDesigner_23.Click -= dsrDesigner_23_Click;
            dsrDesigner_24.Click -= dsrDesigner_24_Click;
            dsrDesigner_25.Click -= dsrDesigner_25_Click;
            dsrDesigner_27.Click -= dsrDesigner_27_Click;
            dsrDesigner_26.Click -= dsrDesigner_26_Click;
            dsrDesigner_28.Click -= dsrDesigner_28_Click;
            dsrDesigner_29.Click -= dsrDesigner_29_Click;
            dsrDesigner_30.Click -= dsrDesigner_30_Click;
            dsrDesigner_31.Click -= dsrDesigner_31_Click;
            dsrDesigner_32.Click -= dsrDesigner_32_Click;
            dsrDesigner_LD.Click -= dsrDesigner_LD_Click;
            dsrDesigner_33.Click -= dsrDesigner_33_Click;
            dsrDesigner_34.Click -= dsrDesigner_34_Click;
            dsrDesigner_35.Click -= dsrDesigner_35_Click;
            dsrDesigner_36.Click -= dsrDesigner_36_Click;
            dsrDesigner_37.Click -= dsrDesigner_37_Click;
            dsrDesigner_LOG.Click -= dsrDesigner_LOG_Click;
            dsrDesigner_TEMP.Click -= dsrDesigner_TEMP_Click;
            dsrDesigner_PRNT.Click -= dsrDesigner_PRNT_Click;
            dsrDesigner_CORE_CHECK.Click -= dsrDesigner_CORE_CHECK_Click;
            dsrDesigner_DMD.Click -= dsrDesigner_DMD_Click;
            dsrDesigner_CH.Click -= dsrDesigner_CH_Click;
            dsrDesigner_FLIGHTS.Click -= dsrDesigner_FLIGHTS_Click;
            dsrDesigner_06.Click -= dsrDesigner_06_Click;
            dsrDesigner_07.Click -= dsrDesigner_07_Click;
            dsrDesigner_02.Click -= dsrDesigner_02_Click;
            dsrDesigner_03.Click -= dsrDesigner_03_Click;
            dsrDesigner_08.Click -= dsrDesigner_08_Click;


        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private OracleConnection m_cnnQUERY = new OracleConnection();
        private OracleConnection m_cnnTRANS_UPDATE = new OracleConnection();
        private OracleTransaction m_trnTRANS_UPDATE;
        private CoreCharacter T_SHHL_INV;
        private OracleFileObject fleM_INVESTORS;

        private void fleM_INVESTORS_InitializeItems(bool Fixed)
        {

            try
            {
                if (!Fixed)
                    fleM_INVESTORS.set_SetValue("CREATE_DATE", true, QDesign.SysDate(ref m_cnnQUERY));


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }

        private OracleFileObject fleINDEX_INVESTORS;

        private void fleINDEX_INVESTORS_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleINDEX_INVESTORS.ElementOwner("INVESTOR")).Append(" = ").Append(Common.StringToField(fleM_INVESTORS.GetStringValue("INVESTOR")));

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



        private void fleINDEX_INVESTORS_SetItemFinals()
        {

            try
            {
                fleINDEX_INVESTORS.set_SetValue("TELEPHONE", fleM_INVESTORS.GetStringValue("TELEPHONE"));
                fleINDEX_INVESTORS.set_SetValue("POST_CODE_AREA", fleM_INVESTORS.GetStringValue("POST_CODE_AREA"));
                fleINDEX_INVESTORS.set_SetValue("POST_CODE_KEY", QDesign.Pack(fleM_INVESTORS.GetStringValue("POST_CODE_AREA") + fleM_INVESTORS.GetStringValue("POST_CODE_ZONE")));
                fleINDEX_INVESTORS.set_SetValue("CORR_NAME", fleM_INVESTORS.GetStringValue("CORR_NAME").ToUpper());
                fleINDEX_INVESTORS.set_SetValue("ADDRESS_1", fleM_INVESTORS.GetStringValue("ADDRESS_1").ToUpper());
                fleINDEX_INVESTORS.set_SetValue("SOUNDEX_NAME", QDesign.Soundex(fleM_INVESTORS.GetStringValue("CORR_NAME")));


            }
            catch (CustomApplicationException ex)
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

                strText.Append(" WHERE ").Append(fleEMAILS.ElementOwner("INVESTOR")).Append(" = ").Append(Common.StringToField(fleM_INVESTORS.GetStringValue("INVESTOR")));

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



        private void fleEMAILS_SetItemFinals()
        {

            try
            {
                fleEMAILS.set_SetValue("INVESTOR", fleM_INVESTORS.GetStringValue("INVESTOR"));
                fleEMAILS.set_SetValue("SURNAME", fleM_INVESTORS.GetStringValue("CORR_NAME"));
                fleEMAILS.set_SetValue("DATE_STAMP", QDesign.SysDate(ref m_cnnQUERY));


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }

        private DCharacter D_UPDATE_EMAIL_WEB = new DCharacter(160);
        private void D_UPDATE_EMAIL_WEB_GetValue(ref string Value)
        {

            try
            {

                // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

                Value = "java -cp $CLASSPATH:/usr/local/soap/rma " + "editemail " + fleM_INVESTORS.GetStringValue("INVESTOR") + " " + fleEMAILS.GetStringValue("EMAIL");


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private OracleFileObject fleCURRENT_ENT1;

        private void fleCURRENT_ENT1_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleCURRENT_ENT1.ElementOwner("FILL_8")).Append(" = ").Append(Common.StringToField(fleM_INVESTORS.GetStringValue("INVESTOR")));
                strText.Append(" AND ").Append(fleCURRENT_ENT1.ElementOwner("YEAR_123")).Append(" = ").Append(Common.StringToField("01"));
               

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

        private OracleFileObject fleCURRENT_ENT2;

        private void fleCURRENT_ENT2_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleCURRENT_ENT2.ElementOwner("FILL_8")).Append(" = ").Append(Common.StringToField(fleM_INVESTORS.GetStringValue("INVESTOR")));
                strText.Append(" AND ").Append(fleCURRENT_ENT2.ElementOwner("YEAR_123")).Append(" = ").Append(Common.StringToField("02"));
                

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

        private OracleFileObject fleCURRENT_ENT3;

        private void fleCURRENT_ENT3_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleCURRENT_ENT3.ElementOwner("FILL_8")).Append(" = ").Append(Common.StringToField(fleM_INVESTORS.GetStringValue("INVESTOR")));
                strText.Append(" AND ").Append(fleCURRENT_ENT3.ElementOwner("YEAR_123")).Append(" = ").Append(Common.StringToField("03"));
                

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

        private OracleFileObject fleINVESTOR_LETTERS;

        private void fleINVESTOR_LETTERS_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleINVESTOR_LETTERS.ElementOwner("INVESTOR")).Append(" = ").Append(Common.StringToField(fleM_INVESTORS.GetStringValue("INVESTOR")));

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



        private void fleINVESTOR_LETTERS_SelectIf(ref string SelectIfClause)
        {


            try
            {
                StringBuilder strSQL = new StringBuilder("");

                strSQL.Append(" (    ").Append(fleINVESTOR_LETTERS.ElementOwner("RECORD_STATUS")).Append(" =  'NI')");
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

        private OracleFileObject fleBOOKING_COMMENTS;

        private void fleBOOKING_COMMENTS_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleBOOKING_COMMENTS.ElementOwner("BOOKING_REF")).Append(" = ").Append(Common.StringToField(fleM_INVESTORS.GetStringValue("INVESTOR")));

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

        private OracleFileObject fleSHARE_INDEX;

        private void fleSHARE_INDEX_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleSHARE_INDEX.ElementOwner("INVESTOR")).Append(" = ").Append(Common.StringToField(fleM_INVESTORS.GetStringValue("INVESTOR")));

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



        private void fleSHARE_INDEX_SelectIf(ref string SelectIfClause)
        {


            try
            {
                StringBuilder strSQL = new StringBuilder("");

                strSQL.Append(" (    ").Append(fleSHARE_INDEX.ElementOwner("BONDHOLDER")).Append(" =  'Y' AND ");
                strSQL.Append("    ").Append(fleSHARE_INDEX.ElementOwner("TERMINATED_DATE")).Append(" =  0)");
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

        private CoreCharacter T_SHRUPD;
        private OracleFileObject flePRB_INVESTORS;

        private void flePRB_INVESTORS_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(flePRB_INVESTORS.ElementOwner("rma_NUMBER")).Append(" = ").Append(Common.StringToField(fleM_INVESTORS.GetStringValue("INVESTOR")));

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

        private CoreCharacter T_PRBUPD;
        private OracleFileObject fleWORKFILE;

        private void fleWORKFILE_InitializeItems(bool Fixed)
        {

            try
            {
                if (!Fixed)
                    fleWORKFILE.set_SetValue("EOL_NUM", true, 10);


            }
            catch (CustomApplicationException ex)
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

        private OracleFileObject fleDD_DETAILS;

        private void fleDD_DETAILS_SelectIf(ref string SelectIfClause)
        {


            try
            {
                StringBuilder strSQL = new StringBuilder("");

                strSQL.Append(" (    ").Append(fleDD_DETAILS.ElementOwner("DD_TYPE")).Append(" =  'DM' AND ");
                strSQL.Append("    ").Append(fleDD_DETAILS.ElementOwner("CANCEL_DATE")).Append(" =  0)");
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

        private OracleFileObject fleLOCATIONS;
        private OracleFileObject fleCANCEL_INVEST;

        private void fleCANCEL_INVEST_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleCANCEL_INVEST.ElementOwner("INVESTOR")).Append(" = ").Append(Common.StringToField(fleM_INVESTORS.GetStringValue("INVESTOR")));

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

                strText.Append(" WHERE ").Append(fleINSURANCE.ElementOwner("INVESTOR")).Append(" = ").Append(Common.StringToField(fleM_INVESTORS.GetStringValue("INVESTOR")));

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

                strSQL.Append(" (    ").Append(fleINSURANCE.ElementOwner("CORE_TYPE")).Append(" =  'A' AND ");
                strSQL.Append("    ").Append(fleINSURANCE.ElementOwner("BOOKING_REF")).Append(" =  'ANNUAL' AND ");
                strSQL.Append("    ").Append(fleINSURANCE.ElementOwner("FINISH_DATE")).Append(" >  QDesign.SysDate(ref m_cnnQUERY) AND ");
                strSQL.Append("    ").Append(fleINSURANCE.ElementOwner("COMMENCE_DATE")).Append(" <   ").Append(fleINSURANCE.ElementOwner("FINISH_DATE")).Append(")");
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

        private CoreCharacter T_INVESTOR;
        private CoreCharacter T_BOOKING_REF;
        private CoreCharacter T_TYPE;
        private CoreCharacter T_ADDRESS_1;
        private CoreCharacter T_ADDRESS_2;
        private CoreCharacter T_ADDRESS_3;
        private CoreCharacter T_ADDRESS_4;
        private CoreCharacter T_INVESTOR_NAME;
        private CoreCharacter T_POST_CODE_AREA;
        private CoreCharacter T_POST_CODE_ZONE;
        private CoreCharacter T_JOBSTREAM;
        private CoreCharacter T_COMMAND;
        private CoreCharacter T_FAX_NO;
        private CoreCharacter T_COMMENTS;
        private CoreCharacter T_PASS_INVESTOR;
        private void T_PASS_INVESTOR_GetInitialValue()
        {
            T_PASS_INVESTOR.InitialValue = fleM_INVESTORS.GetStringValue("INVESTOR");
        }
        private CoreCharacter T_PASS_LOCATION;
        private CoreCharacter T_PASS_SCREEN;
        private CoreDate T_START_DATE;
        private void T_START_DATE_GetInitialValue()
        {
            T_START_DATE.InitialValue = QDesign.SysDate(ref m_cnnQUERY);
        }
        private CoreDate T_END_DATE;
        private void T_END_DATE_GetInitialValue()
        {
            T_END_DATE.InitialValue = 20991231;
        }
        private CoreCharacter T_LOCATION;
        private CoreCharacter T_PROPERTY_ID;
        private CoreCharacter T_ADDR_CHANGED;
        private CoreCharacter T_SHARE_NO;
        private CoreCharacter T_DD_TYPE;
        private CoreDate T_DATE;
        private CoreCharacter T_HIRE_LOCATION;
        private CoreCharacter T_TOP_MESSAGE;
        private CoreCharacter T_CUSTOMER_TYPE;
        private CoreCharacter T_ADDRESS_CHANGED;
        private CoreCharacter T_PRB_ACCESS;
        private CoreCharacter T_NEW_EMAIL_OK;
        private DCharacter D_CHECK_ADDRESS = new DCharacter(8);
        private void D_CHECK_ADDRESS_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(fleM_INVESTORS.GetStringValue("CHECK_ADDRESS")) == QDesign.NULL("Y"))
                {
                    CurrentValue = "Check?";
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
        //#CORE_BEGIN_INCLUDE: REPDEFS.USE"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 07/12/2013 1:48:43 PM

        private CoreCharacter T_JOBNO;
        private CoreCharacter T_JOBFIL;
        private CoreCharacter T_JOBJNO;
        private CoreCharacter T_JOBNUM;
        private CoreCharacter T_JOBOWN;
        private CoreCharacter T_REPNAME;
        private CoreCharacter T_REPNAME2;
        private CoreCharacter T_REPNAME3;
        private CoreCharacter T_REPNAME4;
        private CoreCharacter T_REPNAME5;
        private CoreCharacter T_REPNAME6;
        private CoreCharacter T_PROGNAME;
        private CoreCharacter T_PRINTER;
        private CoreCharacter T_COPIES;
        private CoreCharacter T_RUNTIME;
        private CoreCharacter T_DEL_TEMPS;
        private CoreCharacter T_DEL_JOBFILE;
        private CoreCharacter T_DEL_REPORT;
        private CoreCharacter T_PRINT_REPORT;
        private CoreCharacter T_EMAIL_REPORT;
        private CoreCharacter T_EMAIL;
        private CoreCharacter T_EMAIL_SUBJECT;
        private DDecimal D_HOURS = new DDecimal(2);
        private void D_HOURS_GetValue(ref decimal Value)
        {

            try
            {
                Value = QDesign.NConvert(QDesign.Substring(QDesign.ASCII(QDesign.SysTime(ref m_cnnQUERY), 8), 1, 2));


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }

        private DDecimal D_MINS = new DDecimal(2);
        private void D_MINS_GetValue(ref decimal Value)
        {

            try
            {
                Value = QDesign.NConvert(QDesign.Substring(QDesign.ASCII(QDesign.SysTime(ref m_cnnQUERY), 8), 3, 2));


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }

        private DDecimal D_DAY = new DDecimal(2);
        private void D_DAY_GetValue(ref decimal Value)
        {

            try
            {
                Value = QDesign.NConvert(QDesign.Substring(QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8), 7, 2));


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }

        private DCharacter D_RUNTIME = new DCharacter(4);
        private void D_RUNTIME_GetValue(ref string Value)
        {

            try
            {
                Value = QDesign.ASCII(D_HOURS.Value, 2) + QDesign.ASCII(D_MINS.Value, 2);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }

        private DCharacter D_JOBDATE = new DCharacter(10);
        private void D_JOBDATE_GetValue(ref string Value)
        {

            try
            {

                // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

                Value = QDesign.Substring(QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8), 7, 2) + "/" + QDesign.Substring(QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8), 5, 2) + "/" + QDesign.Substring(QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY)), 1, 4);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }

        private DCharacter D_JOBOWN = new DCharacter(52);
        private void D_JOBOWN_GetValue(ref string Value)
        {

            try
            {
                Value = "job created by user: " + UserID.TrimEnd() + " at " + QDesign.Substring(QDesign.ASCII(QDesign.SysTime(ref m_cnnQUERY), 8), 1, 2) + ":" + QDesign.Substring(QDesign.ASCII(QDesign.SysTime(ref m_cnnQUERY), 8), 3, 2) + " on " + D_JOBDATE.Value;


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }

        private DCharacter D_MAKEOWN = new DCharacter(120);
        private void D_MAKEOWN_GetValue(ref string Value)
        {

            try
            {

                // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

                Value = "echo " + D_JOBOWN.Value + " > $PHTEMP/" + T_JOBOWN.Value + " 2>/dev/QDesign.NULL";


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }

        private DCharacter D_MAKE_WORK = new DCharacter(28);
        private void D_MAKE_WORK_GetValue(ref string Value)
        {

            try
            {

                // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

                Value = "echo `\\c` > $PHTEMP/WORK.dat";


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }

        private DCharacter D_JOBNO = new DCharacter(9);
        private void D_JOBNO_GetValue(ref string Value)
        {

            try
            {
                Value = "j" + QDesign.ASCII(QDesign.SysTime(ref m_cnnQUERY), 8);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }

        private DCharacter D_MAKEJNO = new DCharacter(50);
        private void D_MAKEJNO_GetValue(ref string Value)
        {

            try
            {

                // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

                Value = "echo " + T_JOBNO.Value + " > $PHTEMP/" + T_JOBJNO.Value + " 2>/dev/QDesign.NULL";


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }

        private DCharacter D_PROG_USER = new DCharacter(20);
        private void D_PROG_USER_GetValue(ref string Value)
        {

            try
            {
                Value = "`" + T_PROGNAME.Value + " " + UserID + "`";


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }

        private DCharacter D_MAKELOG = new DCharacter(150);
        private void D_MAKELOG_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;

                // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

                if (D_DAY.Value > 9)
                {
                    CurrentValue = "echo `cat $PHTEMP/" + T_JOBNUM.Value + "` " + T_JOBNO.Value + " " + D_PROG_USER.Value + " >> $LOG/" + T_PROGNAME.Value.TrimEnd() + ".l" + QDesign.Substring(T_JOBNO.Value, 2, 8) + " 2>/dev/NULL";
                }
                else
                {
                    CurrentValue = "echo `cat $PHTEMP/" + T_JOBNUM.Value + "` " + "` `" + T_JOBNO.Value + " " + D_PROG_USER.Value + " >> $LOG/" + T_PROGNAME.Value.TrimEnd() + ".l" + QDesign.Substring(T_JOBNO.Value, 2, 8) + " 2>/dev/NULL";
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

        private DCharacter D_SHOWJNO = new DCharacter(80);
        private void D_SHOWJNO_GetValue(ref string Value)
        {

            try
            {

                // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

                Value = "cat $PHTEMP/" + T_JOBJNO.Value;


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }

        private DCharacter D_QUEUE = new DCharacter(7);
        private void D_QUEUE_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(QDesign.Substring(T_REPNAME.Value, 1, 3)) == QDesign.NULL("web"))
                {
                    CurrentValue = "at -qd ";
                }
                else if (QDesign.NULL(QDesign.Substring(T_REPNAME.Value, 1, 2)) == QDesign.NULL("fq"))
                {
                    CurrentValue = "at -qf ";
                }
                else
                {
                    CurrentValue = "at -qa ";
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

        private DCharacter D_RUNJOB = new DCharacter(64);
        private void D_RUNJOB_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;

                // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

                if (string.Compare(T_RUNTIME.Value, QDesign.Substring(QDesign.ASCII(QDesign.SysTime(ref m_cnnQUERY), 8), 1, 4)) <= 0)
                {
                    CurrentValue = D_QUEUE.Value + "-f $PHTEMP/" + T_JOBFIL.Value + " now 2>$PHTEMP/" + T_JOBNUM.Value;
                }
                else
                {
                    CurrentValue = D_QUEUE.Value + "-f $PHTEMP/" + T_JOBFIL.Value + " " + T_RUNTIME.Value + " 2>$PHTEMP/" + T_JOBNUM.Value;
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

        private DCharacter D_STRIPJOB = new DCharacter(60);
        private void D_STRIPJOB_GetValue(ref string Value)
        {

            try
            {

                // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

                Value = "sed `s/ *$//` $PHTEMP/WORK.dat > $PHTEMP/" + T_JOBFIL.Value;


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }

        private DCharacter D_CATJOB = new DCharacter(170);
        private void D_CATJOB_GetValue(ref string Value)
        {

            try
            {

                // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

                Value = "cat $PHTEMP/" + T_JOBNUM.Value + " $PHTEMP/" + T_JOBOWN.Value + " $PHTEMP/" + T_JOBFIL.Value + " >> $LOG/" + T_PROGNAME.Value.TrimEnd() + "." + T_JOBNO.Value + " 2>>$LOG/" + T_PROGNAME.Value.TrimEnd() + "." + T_JOBNO.Value;


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }

        private DCharacter D_QUTIL_START = new DCharacter(80);
        private void D_QUTIL_START_GetValue(ref string Value)
        {

            try
            {

                // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

                Value = "qutil <<END >>$LOG/" + T_PROGNAME.Value.TrimEnd() + "." + T_JOBNO.Value + " 2>>$LOG/" + T_PROGNAME.Value.TrimEnd() + "." + T_JOBNO.Value;


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }

        private DCharacter D_QTP_START = new DCharacter(80);
        private void D_QTP_START_GetValue(ref string Value)
        {

            try
            {

                // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

                Value = "qtp procloc=$QTC <<EXIT >> $LOG/" + T_PROGNAME.Value.TrimEnd() + "." + T_JOBNO.Value + " 2>/dev/QDesign.NULL";


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }

        private DCharacter D_QUIZ_START = new DCharacter(80);
        private void D_QUIZ_START_GetValue(ref string Value)
        {

            try
            {

                // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

                Value = "quiz procloc=$QZC <<EXIT >> $LOG/" + T_PROGNAME.Value.TrimEnd() + "." + T_JOBNO.Value + " 2>/dev/QDesign.NULL";


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }

        private DCharacter D_REPNAME = new DCharacter(21);
        private void D_REPNAME_GetValue(ref string Value)
        {

            try
            {

                // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

                Value = "$REPORTS/" + T_REPNAME.Value.TrimEnd() + ".txt";


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }

        private DCharacter D_REPNAME2 = new DCharacter(21);
        private void D_REPNAME2_GetValue(ref string Value)
        {

            try
            {

                // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

                Value = "$REPORTS/" + T_REPNAME2.Value.TrimEnd() + ".txt";


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }

        private DCharacter D_REPNAME3 = new DCharacter(21);
        private void D_REPNAME3_GetValue(ref string Value)
        {

            try
            {

                // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

                Value = "$REPORTS/" + T_REPNAME3.Value.TrimEnd() + ".txt";


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }

        private DCharacter D_REPNAME4 = new DCharacter(21);
        private void D_REPNAME4_GetValue(ref string Value)
        {

            try
            {

                // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

                Value = "$REPORTS/" + T_REPNAME4.Value.TrimEnd() + ".txt";


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }

        private DCharacter D_REPNAME5 = new DCharacter(21);
        private void D_REPNAME5_GetValue(ref string Value)
        {

            try
            {

                // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

                Value = "$REPORTS/" + T_REPNAME5.Value.TrimEnd() + ".txt";


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }

        private DCharacter D_REPNAME6 = new DCharacter(21);
        private void D_REPNAME6_GetValue(ref string Value)
        {

            try
            {

                // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

                Value = "$REPORTS/" + T_REPNAME6.Value.TrimEnd() + ".txt";


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }

        private DCharacter D_PRINT_REPORT = new DCharacter(120);
        private void D_PRINT_REPORT_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;

                // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

                if (QDesign.NULL(T_EMAIL_REPORT.Value) == QDesign.NULL("Y"))
                {
                    CurrentValue = "/rma/scripts/.htmlrep.sh " + D_REPNAME.Value.TrimEnd() + " `" + T_EMAIL_SUBJECT.Value.TrimEnd() + "`" + " " + T_EMAIL.Value.TrimEnd();
                }
                else if (QDesign.NULL(T_PRINTER.Value) != QDesign.NULL(" "))
                {
                    CurrentValue = "lpgbp -d" + T_PRINTER.Value.TrimEnd() + " -c -s -n" + T_COPIES.Value.TrimEnd() + " " + D_REPNAME.Value.TrimEnd() + " 2>>$LOG/" + T_PROGNAME.Value.TrimEnd() + "." + T_JOBNO.Value;
                }
                else
                {
                    CurrentValue = "### Printer number not supplied by user ### ";
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

        private DCharacter D_PRINT_REPORT_TRAY3 = new DCharacter(120);
        private void D_PRINT_REPORT_TRAY3_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;

                // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

                if (QDesign.NULL(T_EMAIL_REPORT.Value) == QDesign.NULL("Y"))
                {
                    CurrentValue = "/rma/scripts/.emdoc.sh " + D_REPNAME.Value.TrimEnd() + " `rma`" + " " + T_EMAIL.Value.TrimEnd();
                }
                else if (QDesign.NULL(T_PRINTER.Value) != QDesign.NULL(" "))
                {
                    CurrentValue = "lpgbp -d" + T_PRINTER.Value.TrimEnd() + " -otray3  -c -s -n" + T_COPIES.Value.TrimEnd() + " " + D_REPNAME.Value.TrimEnd() + " 2>>$LOG/" + T_PROGNAME.Value.TrimEnd() + "." + T_JOBNO.Value;
                }
                else
                {
                    CurrentValue = "### Printer number not supplied by user ### ";
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

        private DCharacter D_PRINT_REPORT_TRAY1 = new DCharacter(120);
        private void D_PRINT_REPORT_TRAY1_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;

                // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

                if (QDesign.NULL(T_EMAIL_REPORT.Value) == QDesign.NULL("Y"))
                {
                    CurrentValue = "/rma/scripts/.emdoc.sh " + D_REPNAME.Value.TrimEnd() + " `rma`" + " " + T_EMAIL.Value.TrimEnd();
                }
                else if (QDesign.NULL(T_PRINTER.Value) != QDesign.NULL(" "))
                {
                    CurrentValue = "lpgbp -d" + T_PRINTER.Value.TrimEnd() + " -otray1  -c -s -n" + T_COPIES.Value.TrimEnd() + " " + D_REPNAME.Value.TrimEnd() + " 2>>$LOG/" + T_PROGNAME.Value.TrimEnd() + "." + T_JOBNO.Value;
                }
                else
                {
                    CurrentValue = "### Printer number not supplied by user ### ";
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

        private DCharacter D_PRINT_REPORT_TRAY2 = new DCharacter(120);
        private void D_PRINT_REPORT_TRAY2_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;

                // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

                if (QDesign.NULL(T_EMAIL_REPORT.Value) == QDesign.NULL("Y"))
                {
                    CurrentValue = "/rma/scripts/.emdoc.sh " + D_REPNAME.Value.TrimEnd() + " `rma`" + " " + T_EMAIL.Value.TrimEnd();
                }
                else if (QDesign.NULL(T_PRINTER.Value) != QDesign.NULL(" "))
                {
                    CurrentValue = "lpgbp -d" + T_PRINTER.Value.TrimEnd() + " -otray2  -c -s -n" + T_COPIES.Value.TrimEnd() + " " + D_REPNAME.Value.TrimEnd() + " 2>>$LOG/" + T_PROGNAME.Value.TrimEnd() + "." + T_JOBNO.Value;
                }
                else
                {
                    CurrentValue = "### Printer number not supplied by user ### ";
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

        private DCharacter D_PRINT_DUPLEX = new DCharacter(120);
        private void D_PRINT_DUPLEX_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;

                // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

                if (QDesign.NULL(T_PRINTER.Value) != QDesign.NULL(" "))
                {
                    CurrentValue = "lpgbp -d" + T_PRINTER.Value.TrimEnd() + " -oduplex -c -s -n" + T_COPIES.Value.TrimEnd() + " " + D_REPNAME.Value.TrimEnd() + " 2>>$LOG/" + T_PROGNAME.Value.TrimEnd() + "." + T_JOBNO.Value;
                }
                else
                {
                    CurrentValue = "### Printer number not supplied by user ### ";
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

        private DCharacter D_DEL_REPORT = new DCharacter(50);
        private void D_DEL_REPORT_GetValue(ref string Value)
        {

            try
            {
                Value = "rm -f " + D_REPNAME.Value.TrimEnd();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }

        private DCharacter D_DEL_JOBFILE = new DCharacter(30);
        private void D_DEL_JOBFILE_GetValue(ref string Value)
        {

            try
            {

                // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

                Value = "rm -f $LOG/" + T_PROGNAME.Value.TrimEnd() + "." + T_JOBNO.Value;


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }

        private DCharacter D_DEL_LOGFILE = new DCharacter(30);
        private void D_DEL_LOGFILE_GetValue(ref string Value)
        {

            try
            {

                // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

                Value = "rm -f $LOG/" + T_PROGNAME.Value.TrimEnd() + ".l" + QDesign.Substring(T_JOBNO.Value, 2, 8);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }

        private DCharacter D_DEL_TEMPS = new DCharacter(25);
        private void D_DEL_TEMPS_GetValue(ref string Value)
        {

            try
            {

                // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

                Value = "rm -f $PHTEMP/" + T_JOBNO.Value + ".*";


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }

        private DCharacter D_DEL_PHTMP = new DCharacter(30);
        private void D_DEL_PHTMP_GetValue(ref string Value)
        {

            try
            {

                // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

                Value = "rmdir $PHTEMP 2>/dev/QDesign.NULL";


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }

        private DCharacter D_JOBLOG = new DCharacter(23);
        private void D_JOBLOG_GetValue(ref string Value)
        {

            try
            {

                // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

                Value = "$LOG/" + T_PROGNAME.Value.TrimEnd() + "." + T_JOBNO.Value;


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }

        //#CORE_END_INCLUDE: REPDEFS.USE"

        private DCharacter D_UNDER_GUARANTEE = new DCharacter(1);
        private void D_UNDER_GUARANTEE_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(fleM_INVESTORS.GetStringValue("UNDER_GUARANTEE")) == QDesign.NULL("Y"))
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
        private DInteger D_ENT_BAL1 = new DInteger(8);
        private void D_ENT_BAL1_GetValue(ref decimal Value)
        {

            try
            {
                Value = fleCURRENT_ENT1.GetDecimalValue("ENTITLEMENT_BAL");


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DInteger D_ENT_BAL2 = new DInteger(8);
        private void D_ENT_BAL2_GetValue(ref decimal Value)
        {

            try
            {
                Value = fleCURRENT_ENT2.GetDecimalValue("ENTITLEMENT_BAL");


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DInteger D_ENT_BAL3 = new DInteger(8);
        private void D_ENT_BAL3_GetValue(ref decimal Value)
        {

            try
            {
                Value = fleCURRENT_ENT3.GetDecimalValue("ENTITLEMENT_BAL") + fleCURRENT_ENT3.GetDecimalValue("ENT_OVERDRAFT");


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DInteger D_BF_BAL1 = new DInteger(8);
        private void D_BF_BAL1_GetValue(ref decimal Value)
        {

            try
            {
                Value = fleCURRENT_ENT1.GetDecimalValue("BF_BAL");


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DInteger D_BF_BAL2 = new DInteger(8);
        private void D_BF_BAL2_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0;
                if (QDesign.NULL(fleCURRENT_ENT1.GetDecimalValue("ENTITLEMENT_BAL")) > 0)
                {
                    CurrentValue = fleCURRENT_ENT1.GetDecimalValue("ENTITLEMENT_BAL");
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
        private DInteger D_BF_BAL3 = new DInteger(8);
        private void D_BF_BAL3_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0;
                if (QDesign.NULL(fleCURRENT_ENT2.GetDecimalValue("ENTITLEMENT_BAL")) > 0)
                {
                    CurrentValue = fleCURRENT_ENT2.GetDecimalValue("ENTITLEMENT_BAL");
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
        private DInteger D_TOT_BAL1 = new DInteger(8);
        private void D_TOT_BAL1_GetValue(ref decimal Value)
        {

            try
            {
                Value = fleCURRENT_ENT1.GetDecimalValue("ENTITLEMENT_BAL") + fleCURRENT_ENT1.GetDecimalValue("BF_BAL");


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DInteger D_TOT_BAL2 = new DInteger(8);
        private void D_TOT_BAL2_GetValue(ref decimal Value)
        {

            try
            {
                Value = fleCURRENT_ENT2.GetDecimalValue("ENTITLEMENT_BAL") + D_BF_BAL2.Value;


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DInteger D_TOT_BAL3 = new DInteger(8);
        private void D_TOT_BAL3_GetValue(ref decimal Value)
        {

            try
            {
                Value = fleCURRENT_ENT3.GetDecimalValue("ENTITLEMENT_BAL") + fleCURRENT_ENT3.GetDecimalValue("ENT_OVERDRAFT") + D_BF_BAL3.Value;


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DCharacter D_HY1_TITLE = new DCharacter(7);
        private void D_HY1_TITLE_GetValue(ref string Value)
        {

            try
            {

                // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

                Value = " " + fleM_INVESTORS.GetStringValue("HOLIDAY_ANNIV") + "/" + QDesign.Substring(fleCURRENT_ENT1.GetStringValue("YEAR"), 3, 2) + " ";


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DCharacter D_HY2_TITLE = new DCharacter(7);
        private void D_HY2_TITLE_GetValue(ref string Value)
        {

            try
            {

                // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

                Value = " " + fleM_INVESTORS.GetStringValue("HOLIDAY_ANNIV") + "/" + QDesign.Substring(fleCURRENT_ENT2.GetStringValue("YEAR"), 3, 2) + " ";


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DCharacter D_HY3_TITLE = new DCharacter(7);
        private void D_HY3_TITLE_GetValue(ref string Value)
        {

            try
            {

                // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

                Value = " " + fleM_INVESTORS.GetStringValue("HOLIDAY_ANNIV") + "/" + QDesign.Substring(fleCURRENT_ENT3.GetStringValue("YEAR"), 3, 2) + " ";


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DCharacter D_FROM_DATE = new DCharacter(8);
        private void D_FROM_DATE_GetValue(ref string Value)
        {

            try
            {
                Value = QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY) - 30000);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DCharacter D_TO_DATE = new DCharacter(8);
        private void D_TO_DATE_GetValue(ref string Value)
        {

            try
            {
                Value = QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY) + 30000);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DCharacter D_NEW_INVESTOR = new DCharacter(1);
        private void D_NEW_INVESTOR_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if ((QDesign.SysDate(ref m_cnnQUERY) <= QDesign.PhDate(QDesign.Days(fleINVESTOR_LETTERS.GetDecimalValue("DATE_PRINTED")) + 30) || (QDesign.NULL(fleINVESTOR_LETTERS.GetDecimalValue("DATE_PRINTED")) == 0 && QDesign.NULL(fleINVESTOR_LETTERS.GetStringValue("INVESTOR")) != QDesign.NULL(" "))) && QDesign.NULL(fleM_INVESTORS.GetStringValue("YORKSHIRE_BANK")) != QDesign.NULL("Y"))
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
        private DCharacter D_SHAREHOLDER = new DCharacter(25);
        private void D_SHAREHOLDER_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (string.Compare(fleSHARE_INDEX.GetStringValue("SHARE_NO"), "0001") >= 0 && QDesign.NULL(fleM_INVESTORS.GetStringValue("SAGA_FLAG")) == QDesign.NULL("S"))
                {
                    CurrentValue = QDesign.Pack("SHAREHOLDER " + fleSHARE_INDEX.GetStringValue("SHARE_NO") + " SAGA");
                }
                else if (string.Compare(fleSHARE_INDEX.GetStringValue("SHARE_NO"), "0001") >= 0)
                {
                    CurrentValue = "  SHAREHOLDER " + fleSHARE_INDEX.GetStringValue("SHARE_NO");
                }
                else if (QDesign.NULL(fleM_INVESTORS.GetStringValue("SAGA_FLAG")) == QDesign.NULL("S"))
                {
                    CurrentValue = "  SAGA MEMBERSHIP";
                }
                else if (QDesign.NULL(fleM_INVESTORS.GetStringValue("SAGA_FLAG")) == QDesign.NULL("A"))
                {
                    CurrentValue = "    AA MEMBERSHIP";
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
        private DCharacter D_INSURANCE = new DCharacter(13);
        private void D_INSURANCE_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL("P") == QDesign.NULL(QDesign.Substring(fleINSURANCE.GetStringValue("SCHEME"), 1, 1)) && !fleINSURANCE.NewRecord)
                {
                    CurrentValue = "37 Pts Ins: Y";
                }
                else if (QDesign.NULL("P") != QDesign.NULL(QDesign.Substring(fleINSURANCE.GetStringValue("SCHEME"), 1, 1)) && !fleINSURANCE.NewRecord)
                {
                    CurrentValue = "37 Ann Ins: Y";
                }
                else
                {
                    CurrentValue = "37 No Ins";
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
        //# Do not delete, modify or move it.  Updated: 07/12/2013 1:48:46 PM

        //# No code was generated or needed for this region.

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 07/12/2013 1:48:46 PM

        //# No code was generated or needed for this region.

        #endregion

        #region "Transaction Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 07/12/2013 1:48:46 PM

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
            fleINDEX_INVESTORS.Transaction = m_trnTRANS_UPDATE;
            fleEMAILS.Transaction = m_trnTRANS_UPDATE;
            fleINVESTOR_LETTERS.Transaction = m_trnTRANS_UPDATE;
            flePRB_INVESTORS.Transaction = m_trnTRANS_UPDATE;
            fleWORKFILE.Transaction = m_trnTRANS_UPDATE;
            fleUSER_SEC_FILE.Transaction = m_trnTRANS_UPDATE;
            fleDD_DETAILS.Transaction = m_trnTRANS_UPDATE;
            fleLOCATIONS.Transaction = m_trnTRANS_UPDATE;


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 07/12/2013 1:48:46 PM

        //#-----------------------------------------
        //# InitializeFiles Procedure.
        //#-----------------------------------------

        protected override void InitializeFiles()
        {

            try
            {
                Initialize_TRANS_UPDATE();
                fleCURRENT_ENT1.Connection = m_cnnQUERY;
                fleCURRENT_ENT2.Connection = m_cnnQUERY;
                fleCURRENT_ENT3.Connection = m_cnnQUERY;
                fleINVESTMENTS.Connection = m_cnnQUERY;
                fleBOOKING_COMMENTS.Connection = m_cnnQUERY;
                fleSHARE_INDEX.Connection = m_cnnQUERY;
                fleCANCEL_INVEST.Connection = m_cnnQUERY;
                fleINSURANCE.Connection = m_cnnQUERY;


            }
            catch (CustomApplicationException ex)
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
                fleINDEX_INVESTORS.Dispose();
                fleEMAILS.Dispose();
                fleCURRENT_ENT1.Dispose();
                fleCURRENT_ENT2.Dispose();
                fleCURRENT_ENT3.Dispose();
                fleINVESTMENTS.Dispose();
                fleINVESTOR_LETTERS.Dispose();
                fleBOOKING_COMMENTS.Dispose();
                fleSHARE_INDEX.Dispose();
                flePRB_INVESTORS.Dispose();
                fleWORKFILE.Dispose();
                fleUSER_SEC_FILE.Dispose();
                fleDD_DETAILS.Dispose();
                fleLOCATIONS.Dispose();
                fleCANCEL_INVEST.Dispose();
                fleINSURANCE.Dispose();


            }
            catch (CustomApplicationException ex)
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
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 07/12/2013 1:48:45 PM
        //#-----------------------------------------
        protected override void DisplayFormatting()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:48:45 PM
                Display(ref fldM_INVESTORS_INVESTOR);
                Display(ref fldM_INVESTORS_CORR_TITLE);
                Display(ref fldM_INVESTORS_INITIAL_1);
                Display(ref fldM_INVESTORS_INITIAL_2);
                Display(ref fldM_INVESTORS_CORR_NAME);
                Display(ref fldM_INVESTORS_INVESTOR_NAME);
                Display(ref fldD_INSURANCE);
                Display(ref fldINSURANCE_FINISH_DATE);
                Display(ref fldD_CHECK_ADDRESS);
                Display(ref fldM_INVESTORS_CHECK_ADDRESS);
                Display(ref fldM_INVESTORS_ADDRESS_1);
                Display(ref fldM_INVESTORS_ADDRESS_2);
                Display(ref fldM_INVESTORS_ADDRESS_3);
                Display(ref fldM_INVESTORS_ADDRESS_4);
                Display(ref fldM_INVESTORS_POST_CODE_AREA);
                Display(ref fldM_INVESTORS_POST_CODE_ZONE);
                Display(ref fldINVESTMENTS_TERM_SURCHARGEPER);
                Display(ref fldM_INVESTORS_TELEPHONE);
                Display(ref fldM_INVESTORS_TEL_OFFICE);
                Display(ref fldM_INVESTORS_TELEX);
                Display(ref fldM_INVESTORS_DOB);
                Display(ref fldM_INVESTORS_DISABLED);
                Display(ref fldM_INVESTORS_GUARANTEE_END_DATE);
                Display(ref fldM_INVESTORS_UNDER_GUARANTEE);
                Display(ref fldM_INVESTORS_COLOUR);
                Display(ref fldM_INVESTORS_SILVER_GOLD);
                Display(ref fldINVESTMENTS_QUALIFY_28DAY);
                Display(ref fldT_COMMENTS);
                Display(ref fldEMAILS_EMAIL);
                Display(ref fldD_SHAREHOLDER);
                Display(ref fldD_HY1_TITLE);
                Display(ref fldD_HY2_TITLE);
                Display(ref fldD_HY3_TITLE);
                Display(ref fldD_ENT_BAL1);
                Display(ref fldD_BF_BAL1);
                Display(ref fldD_TOT_BAL1);
                Display(ref fldD_ENT_BAL2);
                Display(ref fldD_BF_BAL2);
                Display(ref fldD_TOT_BAL2);
                Display(ref fldD_ENT_BAL3);
                Display(ref fldD_BF_BAL3);
                Display(ref fldD_TOT_BAL3);
                Display(ref fldT_TOP_MESSAGE);
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
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 07/12/2013 1:48:45 PM
        //#-----------------------------------------
        protected override void PreDisplayFormatting()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:48:45 PM
                Display(ref fldT_COMMENTS);
                Display(ref fldEMAILS_EMAIL);
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
        //# Do not delete, modify or move it.  Updated: 07/12/2013 1:48:46 PM

        //#-----------------------------------------
        //# BindFields Procedure.
        //#-----------------------------------------

        public override void BindFields()
        {
            try
            {
                fldM_INVESTORS_INVESTOR.Bind(fleM_INVESTORS);
                fldM_INVESTORS_CORR_TITLE.Bind(fleM_INVESTORS);
                fldM_INVESTORS_INITIAL_1.Bind(fleM_INVESTORS);
                fldM_INVESTORS_INITIAL_2.Bind(fleM_INVESTORS);
                fldM_INVESTORS_CORR_NAME.Bind(fleM_INVESTORS);
                fldM_INVESTORS_INVESTOR_NAME.Bind(fleM_INVESTORS);
                fldD_INSURANCE.Bind(D_INSURANCE);
                fldINSURANCE_FINISH_DATE.Bind(fleINSURANCE);
                fldD_CHECK_ADDRESS.Bind(D_CHECK_ADDRESS);
                fldM_INVESTORS_CHECK_ADDRESS.Bind(fleM_INVESTORS);
                fldM_INVESTORS_ADDRESS_1.Bind(fleM_INVESTORS);
                fldM_INVESTORS_ADDRESS_2.Bind(fleM_INVESTORS);
                fldM_INVESTORS_ADDRESS_3.Bind(fleM_INVESTORS);
                fldM_INVESTORS_ADDRESS_4.Bind(fleM_INVESTORS);
                fldM_INVESTORS_POST_CODE_AREA.Bind(fleM_INVESTORS);
                fldM_INVESTORS_POST_CODE_ZONE.Bind(fleM_INVESTORS);
                fldINVESTMENTS_TERM_SURCHARGEPER.Bind(fleINVESTMENTS);
                fldM_INVESTORS_TELEPHONE.Bind(fleM_INVESTORS);
                fldM_INVESTORS_TEL_OFFICE.Bind(fleM_INVESTORS);
                fldM_INVESTORS_TELEX.Bind(fleM_INVESTORS);
                fldM_INVESTORS_DOB.Bind(fleM_INVESTORS);
                fldM_INVESTORS_DISABLED.Bind(fleM_INVESTORS);
                fldM_INVESTORS_GUARANTEE_END_DATE.Bind(fleM_INVESTORS);
                fldM_INVESTORS_UNDER_GUARANTEE.Bind(fleM_INVESTORS);
                fldM_INVESTORS_COLOUR.Bind(fleM_INVESTORS);
                fldM_INVESTORS_SILVER_GOLD.Bind(fleM_INVESTORS);
                fldINVESTMENTS_QUALIFY_28DAY.Bind(fleINVESTMENTS);
                fldT_COMMENTS.Bind(T_COMMENTS);
                fldEMAILS_EMAIL.Bind(fleEMAILS);
                fldD_SHAREHOLDER.Bind(D_SHAREHOLDER);
                fldD_HY1_TITLE.Bind(D_HY1_TITLE);
                fldD_HY2_TITLE.Bind(D_HY2_TITLE);
                fldD_HY3_TITLE.Bind(D_HY3_TITLE);
                fldD_ENT_BAL1.Bind(D_ENT_BAL1);
                fldD_BF_BAL1.Bind(D_BF_BAL1);
                fldD_TOT_BAL1.Bind(D_TOT_BAL1);
                fldD_ENT_BAL2.Bind(D_ENT_BAL2);
                fldD_BF_BAL2.Bind(D_BF_BAL2);
                fldD_TOT_BAL2.Bind(D_TOT_BAL2);
                fldD_ENT_BAL3.Bind(D_ENT_BAL3);
                fldD_BF_BAL3.Bind(D_BF_BAL3);
                fldD_TOT_BAL3.Bind(D_TOT_BAL3);
                fldT_TOP_MESSAGE.Bind(T_TOP_MESSAGE);

            }
            catch (CustomApplicationException ex)
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



        private void fldM_INVESTORS_INVESTOR_LookupNotOn(ref bool LookupNotOnExecuted)
        {

            try
            {
                bool blnAlreadyExists = false;
                StringBuilder strSQL = new StringBuilder("SELECT ").Append(fleM_INVESTORS.ElementOwner("INVESTOR"));
                strSQL.Append(" FROM ");
                strSQL.Append(fleM_INVESTORS.TableNameWithAlias());
                strSQL.Append(" WHERE ");
                strSQL.Append("     ").Append(fleM_INVESTORS.ElementOwner("INVESTOR")).Append(" = ").Append(Common.StringToField(FieldText));

                if (!LookupNotOn(strSQL, fleM_INVESTORS, "INVESTOR", FieldText))
                {
                    blnAlreadyExists = true;
                }

                if (blnAlreadyExists)
                {
                    ErrorMessage("IM.ValueExists");
                    // Record exists in lookup table.
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
                SaveReceivingParams(T_SHHL_INV);


            }
            catch (CustomApplicationException ex)
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
                Receiving(T_SHHL_INV);


            }
            catch (CustomApplicationException ex)
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



        private void dsrDesigner_AIRPORTS_Click(object sender, System.EventArgs e)
        {

            try
            {

                T_INVESTOR.Value = fleM_INVESTORS.GetStringValue("INVESTOR");
                //RunScreen("INVAIRP.QKC", RunScreenModes.Find, T_INVESTOR);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_SN_Click(object sender, System.EventArgs e)
        {

            try
            {

                T_INVESTOR.Value = fleM_INVESTORS.GetStringValue("INVESTOR");
                //RunScreen("SNLOCS.QKC", RunScreenModes.Find, T_INVESTOR);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_ADJ3_Click(object sender, System.EventArgs e)
        {

            try
            {

                //RunScreen("3YEARADJ.QKC", RunScreenModes.Find, fleM_INVESTORS);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldM_INVESTORS_INVESTOR_Input()
        {

            try
            {

                if (QDesign.NULL(QDesign.Substring(FieldText, 1, 2)) == "TN")
                {
                    ErrorMessage("52110");
                }
                if (QDesign.NULL(FieldText) == "999SH" && QDesign.NULL(T_SHHL_INV.Value) != "999SH")
                {
                    ErrorMessage("52111");
                }
                if (QDesign.NULL(FieldText) != "999SH" && QDesign.NULL(T_SHHL_INV.Value) == "999SH")
                {
                    ErrorMessage("52112");
                }
                if (QDesign.NULL(QDesign.Substring(FieldText, 1, 3)) == "999" && (QDesign.NULL(QDesign.Substring(FieldText, 4, 2)) != "AD" && QDesign.NULL(QDesign.Substring(FieldText, 4, 2)) != "ED" && QDesign.NULL(QDesign.Substring(FieldText, 4, 2)) != "HU" && QDesign.NULL(QDesign.Substring(FieldText, 4, 2)) != "RF" && QDesign.NULL(QDesign.Substring(FieldText, 4, 2)) != "SH"))
                {
                    // --> GET LOCATIONS <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleLOCATIONS.ElementOwner("LOCATION")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(QDesign.Substring(FieldText, 4, 2)));

                    fleLOCATIONS.GetData(m_strWhere.ToString());
                    // --> End GET LOCATIONS <--
                    if (QDesign.NULL(T_SHHL_INV.Value) == "999SH")
                    {
                        ErrorMessage("52113");
                    }
                }
                // --> GET USER_SEC_FILE <--
                m_strWhere = new StringBuilder(" WHERE ");
                m_strWhere.Append(" ").Append(fleUSER_SEC_FILE.ElementOwner("USER_LOGON")).Append(" = ");
                m_strWhere.Append(Common.StringToField(UserID));

                fleUSER_SEC_FILE.GetData(m_strWhere.ToString());
                 //--> End GET USER_SEC_FILE <--
                if (EntryMode && string.Compare((fleUSER_SEC_FILE.GetStringValue("USER_LEVEL")), "03") > 0)
                {
                    Severe("52114");
                }
                if (QDesign.NULL(QDesign.Substring(FieldText, 1, 1)) == "Q" || QDesign.NULL(QDesign.Substring(FieldText, 1, 1)) == "q")
                {
                    //RunScreen("INDEXINV.QKC", RunScreenModes.Find, T_INVESTOR, T_CUSTOMER_TYPE);
                    FieldText = T_INVESTOR.Value;
                }
                if (!SelectMode && 0 == FieldText.Length)
                {
                    ErrorMessage("Please enter an Invester number");
                    // TODO: May need to fix manually
                }
                else
                {
                    if (5 > FieldText.Length && QDesign.NULL(FieldText) != QDesign.NULL(" "))
                    {
                        FieldText = QDesign.RightJustify(FieldText);
                        FieldText = QDesign.ASCII(QDesign.NConvert(FieldText), 5);
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



        private void fldM_INVESTORS_INVESTOR_Process()
        {

            try
            {

                if (EntryMode || ChangeMode)
                {
                    fleINDEX_INVESTORS.set_SetValue("INVESTOR", fleM_INVESTORS.GetStringValue("INVESTOR"));
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



        private void fldM_INVESTORS_CORR_TITLE_Input()
        {

            try
            {

                if (0 != FieldText.Length)
                {
                    FieldText = QDesign.Substring(FieldText.ToUpper(), 1, 1) + QDesign.Substring((FieldText), 2, 9);
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



        private void fldM_INVESTORS_CORR_NAME_Input()
        {

            try
            {

                if (0 != FieldText.Length)
                {
                    FieldText = QDesign.Substring(FieldText.ToUpper(), 1, 1) + QDesign.Substring((FieldText), 2, 19);
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


        private bool Internal_ADDRESS_CHANGED()
        {


            try
            {

                T_ADDR_CHANGED.Value = "Y";
                fleM_INVESTORS.set_SetValue("ADDR_CHANGED", "Y");
                fleM_INVESTORS.set_SetValue("AMEND_DATE", QDesign.SysDate(ref m_cnnQUERY));

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



        private void fldM_INVESTORS_INITIAL_1_Process()
        {

            try
            {

                if (ChangeMode)
                {
                    Internal_ADDRESS_CHANGED();
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



        private void fldM_INVESTORS_INITIAL_2_Process()
        {

            try
            {

                if (ChangeMode)
                {
                    Internal_ADDRESS_CHANGED();
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



        private void fldM_INVESTORS_CORR_TITLE_Process()
        {

            try
            {

                if (ChangeMode)
                {
                    Internal_ADDRESS_CHANGED();
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



        private void fldM_INVESTORS_CORR_NAME_Process()
        {

            try
            {

                if (ChangeMode)
                {
                    Internal_ADDRESS_CHANGED();
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



        private void fldM_INVESTORS_ADDRESS_1_Process()
        {

            try
            {

                if (ChangeMode)
                {
                    Internal_ADDRESS_CHANGED();
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



        private void fldM_INVESTORS_ADDRESS_2_Process()
        {

            try
            {

                if (ChangeMode)
                {
                    Internal_ADDRESS_CHANGED();
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



        private void fldM_INVESTORS_ADDRESS_3_Process()
        {

            try
            {

                if (ChangeMode)
                {
                    Internal_ADDRESS_CHANGED();
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



        private void fldM_INVESTORS_ADDRESS_4_Process()
        {

            try
            {

                if (ChangeMode)
                {
                    Internal_ADDRESS_CHANGED();
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



        private void fldM_INVESTORS_POST_CODE_AREA_Process()
        {

            try
            {

                if (ChangeMode)
                {
                    Internal_ADDRESS_CHANGED();
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



        private void fldM_INVESTORS_COLOUR_Input()
        {

            try
            {

                if (FindMode || ChangeMode)
                {
                    if (0 != FieldText.Length && QDesign.NULL(OldValue(fleM_INVESTORS.ElementOwner("COLOUR"), fleM_INVESTORS.GetStringValue("COLOUR"))) != QDesign.NULL(" "))
                    {
                        ErrorMessage("52115");
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



        private void fldM_INVESTORS_COLOUR_Process()
        {

            try
            {

                if (EntryMode)
                {
                    //RunScreen("INVESTEX.QKC", RunScreenModes.Same, fleM_INVESTORS, fleM_INVESTORS);
                    object[] arrRunscreen = { fleM_INVESTORS, fleUSER_SEC_FILE };
                    RunScreen(new IVST0100(), RunScreenModes.Same, ref arrRunscreen);
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



        private void fldM_INVESTORS_SILVER_GOLD_Input()
        {

            try
            {

                if (FindMode || ChangeMode)
                {
                    if (0 != FieldText.Length)
                    {
                        ErrorMessage("52115");
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



        private void fldM_INVESTORS_DOB_Input()
        {

            try
            {

                if (6 == FieldText.Length)
                {
                    FieldText = QDesign.Substring(FieldText, 1, 4) + "19" + QDesign.Substring(FieldText, 5, 2);
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



        private void fldT_COMMENTS_Process()
        {

            try
            {

                if (QDesign.NULL(T_COMMENTS.Value) == QDesign.NULL("*") || QDesign.NULL(T_COMMENTS.Value) == QDesign.NULL("Y"))
                {
                    T_INVESTOR.Value = fleM_INVESTORS.GetStringValue("INVESTOR");
                    //RunScreen("INVCOMMS.QKC", RunScreenModes.Same, T_INVESTOR);
                }
                if (QDesign.NULL(FieldText) == QDesign.NULL(""))
                {
                    FieldText = OldValue("T_COMMENTS", T_COMMENTS.Value);
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

                if (QDesign.NULL(fleEMAILS.GetStringValue("VALID_YN")) == QDesign.NULL("N") && QDesign.NULL(fleEMAILS.GetStringValue("EMAIL")) != QDesign.NULL(" ") && QDesign.NULL(UserID) != QDesign.NULL("weblive"))
                {
                    Information("42020");
                }
                T_EMAIL.Value = fleEMAILS.GetStringValue("EMAIL");
                Display(ref fldEMAILS_EMAIL);
                // --> GET INVESTOR_LETTERS <--

                fleINVESTOR_LETTERS.GetData(GetDataOptions.IsOptional);
                // --> End GET INVESTOR_LETTERS <--
                if (QDesign.NULL(D_NEW_INVESTOR.Value) == QDesign.NULL("Y") && QDesign.NULL(UserID) != QDesign.NULL("weblive"))
                {
                    Warning(QDesign.NULL("** CAUTION - NEW INVESTOR - REFER TO SALES DEPT \a**"));
                    // TODO: May need to fix manually
                    if (QDesign.NULL(T_TOP_MESSAGE.Value) == QDesign.NULL(""))
                    {
                        T_TOP_MESSAGE.Value = QDesign.Center(QDesign.Substring("NEW INVESTOR - REFER TO SALES", 1, 50));
                    }
                }
                if (QDesign.NULL(D_UNDER_GUARANTEE.Value) == QDesign.NULL("Y") && QDesign.NULL(UserID) != QDesign.NULL("weblive"))
                {
                    Warning("32014");
                }
                // --> GET USER_SEC_FILE <--
                m_strWhere = new StringBuilder(" WHERE ");
                m_strWhere.Append(" ").Append(fleUSER_SEC_FILE.ElementOwner("USER_LOGON")).Append(" = ");
                m_strWhere.Append(Common.StringToField(UserID));

                fleUSER_SEC_FILE.GetData(m_strWhere.ToString());
                // --> End GET USER_SEC_FILE <--
                if (QDesign.NULL(fleM_INVESTORS.GetDecimalValue("STATUS")) == 99)
                {
                    Warning("32015");
                    T_TOP_MESSAGE.Value = "CANCELLED - " + fleCANCEL_INVEST.GetStringValue("CANCEL_CODE");
                    if ((QDesign.NULL(fleUSER_SEC_FILE.GetStringValue("USER_LEVEL")) == QDesign.NULL("01") || QDesign.NULL(UserID) == QDesign.NULL("paulc") || QDesign.NULL(fleCANCEL_INVEST.GetStringValue("CANCEL_CODE")) == QDesign.NULL("COMB")) && QDesign.NULL(fleCANCEL_INVEST.GetStringValue("CANCEL_REASON")) != QDesign.NULL(""))
                    {
                        T_TOP_MESSAGE.Value = T_TOP_MESSAGE.Value.TrimEnd() + " (" + fleCANCEL_INVEST.GetStringValue("CANCEL_REASON").TrimEnd() + ")";
                    }
                    T_TOP_MESSAGE.Value = QDesign.Center(T_TOP_MESSAGE.Value);
                }
                if (QDesign.NULL(fleM_INVESTORS.GetStringValue("CHECK_ADDRESS")) == QDesign.NULL("Y") && QDesign.NULL(UserID) != QDesign.NULL("weblive"))
                {
                    Warning("32016");
                    if (QDesign.NULL(T_TOP_MESSAGE.Value) == QDesign.NULL(""))
                    {
                        T_TOP_MESSAGE.Value = QDesign.Center(QDesign.Substring("ADDRESS INCORRECT - CHECK WITH BONDHOLDER", 1, 50));
                    }
                }
                if (QDesign.NULL(fleM_INVESTORS.GetStringValue("ERROR_FLAG")) == QDesign.NULL("Y"))
                {
                    Severe("52116");
                }
                if (QDesign.NULL(fleM_INVESTORS.GetStringValue("ERROR_FLAG")) == QDesign.NULL("P") && QDesign.NULL(fleM_INVESTORS.GetDecimalValue("STATUS")) == 0)
                {
                    if (QDesign.NULL(T_TOP_MESSAGE.Value) == QDesign.NULL(""))
                    {
                        T_TOP_MESSAGE.Value = QDesign.Center(QDesign.Substring("{No active rmaA policies}", 1, 50));
                    }
                }
                // --> GET DD_DETAILS <--
                m_strWhere = new StringBuilder(" WHERE ");
                m_strWhere.Append(" ").Append(fleDD_DETAILS.ElementOwner("INVESTOR")).Append(" = ");
                m_strWhere.Append(Common.StringToField(fleM_INVESTORS.GetStringValue("INVESTOR")));

                fleDD_DETAILS.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                // --> End GET DD_DETAILS <--
                if (AccessOk)
                {
                    if (QDesign.NULL(fleDD_DETAILS.GetStringValue("ALLOW_BOOKING")) == QDesign.NULL("N"))
                    {
                        Information("42021");
                        if (QDesign.NULL(T_TOP_MESSAGE.Value) == QDesign.NULL(""))
                        {
                            T_TOP_MESSAGE.Value = QDesign.Center(QDesign.Substring("CONTACT ACCOUNTS BEFORE MAKING A NEW BOOKING", 1, 50));
                        }
                    }
                }
                // --> GET BOOKING_COMMENTS <--

                fleBOOKING_COMMENTS.GetData(GetDataOptions.IsOptional);
                // --> End GET BOOKING_COMMENTS <--
                if (AccessOk && QDesign.NULL(UserID) != QDesign.NULL("weblive"))
                {
                    T_INVESTOR.Value = fleM_INVESTORS.GetStringValue("INVESTOR");
                    //RunScreen("INVCOMMS.QKC", RunScreenModes.Find, T_INVESTOR);
                    T_COMMENTS.Value = "*";
                    Display(ref fldT_COMMENTS);
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

                // --> GET USER_SEC_FILE <--
                fleUSER_SEC_FILE.GetData();
                // --> End GET USER_SEC_FILE <--
                if (string.Compare(QDesign.NULL(fleUSER_SEC_FILE.GetStringValue("USER_LEVEL")), QDesign.NULL("03")) > 0)
                {
                    Severe("52114");
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


        private bool Internal_CHECKOTHERADDR()
        {


            try
            {

                if (QDesign.NULL(UserID) != QDesign.NULL("weblive"))
                {
                    if (QDesign.NULL(T_ADDRESS_CHANGED.Value) == QDesign.NULL("Y"))
                    {
                        if (QDesign.NULL(fleSHARE_INDEX.GetStringValue("BOND_ADDRESS")) == QDesign.NULL("Y"))
                        {
                            Information(QDesign.NULL("Shareholder Address details may need changing"));
                            // TODO: May need to fix manually
                            //RunScreen("SHARADDR.QKC", , fleM_INVESTORS);
                        }
                        // --> GET PRB_INVESTORS <--

                        flePRB_INVESTORS.GetData(GetDataOptions.IsOptional);
                        // --> End GET PRB_INVESTORS <--
                        if (AccessOk)
                        {
                            Information(QDesign.NULL("PRB Address details may need changing....."));
                            // TODO: May need to fix manually
                            T_PRB_ACCESS.Value = "all";
                            //RunScreen("PRB0000.QKC", , T_PRB_ACCESS);
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



        private void dsrDesigner_OADDR_Click(object sender, System.EventArgs e)
        {

            try
            {

                if (QDesign.NULL(UserID) == QDesign.NULL("angelas"))
                {
                    if (QDesign.NULL(fleSHARE_INDEX.GetStringValue("BOND_ADDRESS")) == QDesign.NULL("Y"))
                    {
                        Information(QDesign.NULL("Shareholder Address details may need changing"));
                        // TODO: May need to fix manually
                        //RunScreen("SHARADDR.QKC", , fleM_INVESTORS);
                    }
                    // --> GET PRB_INVESTORS <--

                    flePRB_INVESTORS.GetData(GetDataOptions.IsOptional);
                    // --> End GET PRB_INVESTORS <--
                    if (AccessOk)
                    {
                        Information(QDesign.NULL("PRB Address details may need changing....."));
                        // TODO: May need to fix manually
                        T_PRB_ACCESS.Value = "all";
                        //RunScreen("PRB0000.QKC", , T_PRB_ACCESS);
                    }
                }
                else
                {
                    ErrorMessage("52117");
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



        private void dsrDesigner_PRB_Click(object sender, System.EventArgs e)
        {

            try
            {

                if (QDesign.NULL(UserID) != QDesign.NULL("manger") && QDesign.NULL(UserID) != QDesign.NULL("linda"))
                {
                    ErrorMessage("52118");
                }
                // --> GET PRB_INVESTORS <--

                flePRB_INVESTORS.GetData(GetDataOptions.IsOptional);
                // --> End GET PRB_INVESTORS <--
                if (AccessOk)
                {
                    T_PRB_ACCESS.Value = "find";
                    //RunScreen("PRB0000.QKC", , T_PRB_ACCESS);
                }
                else
                {
                    Information("42022");
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


        protected override bool PostUpdate()
        {


            try
            {

                Internal_CHECKOTHERADDR();

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



        private void dsrDesigner_04_Click(object sender, System.EventArgs e)
        {

            try
            {

                T_ADDRESS_CHANGED.Value = "4";
                //RunScreen("IVSTCOA.QKC", RunScreenModes.Find, fleM_INVESTORS, fleEMAILS, T_ADDRESS_CHANGED);
                // --> GET INDEX_INVESTORS <--
                fleINDEX_INVESTORS.GetData();
                // --> End GET INDEX_INVESTORS <--
                Internal_CHECKOTHERADDR();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_05_Click(object sender, System.EventArgs e)
        {

            try
            {

                T_ADDRESS_CHANGED.Value = "5";
                //RunScreen("IVSTCOA.QKC", RunScreenModes.Find, fleM_INVESTORS, fleEMAILS, T_ADDRESS_CHANGED);
                // --> GET INDEX_INVESTORS <--
                fleINDEX_INVESTORS.GetData();
                // --> End GET INDEX_INVESTORS <--
                Internal_CHECKOTHERADDR();


            }
            catch (CustomApplicationException ex)
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

                T_INVESTOR.Value = fleM_INVESTORS.GetStringValue("INVESTOR");
                T_NEW_EMAIL_OK.Value = "N";
                //RunScreen("BONDEMAL.QKC", RunScreenModes.Find, T_NEW_EMAIL_OK, T_INVESTOR);
                // --> GET EMAILS <--

                fleEMAILS.GetData(GetDataOptions.IsOptional);
                // --> End GET EMAILS <--
                Display(ref fldEMAILS_EMAIL);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_10_Click(object sender, System.EventArgs e)
        {

            try
            {

                object[] arrRunscreen = { fleM_INVESTORS, fleUSER_SEC_FILE };
                RunScreen(new IVST0100(), RunScreenModes.Same, ref arrRunscreen);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_11_Click(object sender, System.EventArgs e)
        {

            try
            {

                if (QDesign.NULL(fleM_INVESTORS.GetDecimalValue("STATUS")) != 99)
                {
                    //RunScreen("IVST0110.QKC", RunScreenModes.Find, fleM_INVESTORS);
                }
                else
                {
                    if (QDesign.NULL(fleM_INVESTORS.GetDecimalValue("STATUS")) == 99)
                    {
                        Severe(QDesign.NULL("****** THIS FUNCTION NOT AVAILABLE FOR ") + QDesign.NULL("CANCELLED INVESTORS ******"));
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



        private void dsrDesigner_12_Click(object sender, System.EventArgs e)
        {

            try
            {
                object[] arrRunscreen = { fleM_INVESTORS };
                //RunScreen(new ACCTMOVE(), RunScreenModes.Find, ref arrRunscreen);
               


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_13_Click(object sender, System.EventArgs e)
        {

            try
            {

                if (QDesign.NULL(fleM_INVESTORS.GetDecimalValue("STATUS")) == 99)
                {
                    Severe(QDesign.NULL("****** THIS FUNCTION NOT AVAILABLE FOR ") + QDesign.NULL("CANCELLED INVESTORS ******"));
                    // TODO: May need to fix manually
                }
                if (QDesign.NULL(D_NEW_INVESTOR.Value) == QDesign.NULL("Y") && QDesign.NULL(UserID) != QDesign.NULL("martin"))
                {
                    Severe("52120");
                }
                object[] arrRunscreen = { fleM_INVESTORS, fleUSER_SEC_FILE };
                RunScreen(new BOOK0100(), RunScreenModes.Entry, ref arrRunscreen);
                // --> GET EMAILS <--

                fleEMAILS.GetData(GetDataOptions.IsOptional);
                // --> End GET EMAILS <--
                Display(ref fldEMAILS_EMAIL);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_14_Click(object sender, System.EventArgs e)
        {

            try
            {

                if (QDesign.NULL(fleM_INVESTORS.GetDecimalValue("STATUS")) != 99)
                {
                    T_INVESTOR.Value = fleM_INVESTORS.GetStringValue("INVESTOR");
                    //RunScreen("CURRENTI.QKC", RunScreenModes.Find, T_INVESTOR);
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



        private void dsrDesigner_15_Click(object sender, System.EventArgs e)
        {

            try
            {

                if (QDesign.NULL(fleM_INVESTORS.GetDecimalValue("STATUS")) != 99)
                {
                    Push(PushTypes.Update);
                    // TODO: May require manual processes (PUSH verb).
                    T_INVESTOR.Value = fleM_INVESTORS.GetStringValue("INVESTOR");
                    //RunScreen("PARTRFND.QKC", RunScreenModes.Find, T_INVESTOR);
                }
                else
                {
                    if (QDesign.NULL(fleM_INVESTORS.GetDecimalValue("STATUS")) == 99)
                    {
                        Severe(QDesign.NULL("****** THIS FUNCTION NOT AVAILABLE FOR ") + QDesign.NULL("CANCELLED INVESTORS ******"));
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



        private void dsrDesigner_16_Click(object sender, System.EventArgs e)
        {

            try
            {
                object[] arrRunscreen = { fleM_INVESTORS };
                RunScreen(new VIEWBOOK(), RunScreenModes.Find, ref arrRunscreen);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_17_Click(object sender, System.EventArgs e)
        {

            try
            {

                //RunScreen("TOPUHIST.QKC", RunScreenModes.Find, fleM_INVESTORS, fleUSER_SEC_FILE);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_18_Click(object sender, System.EventArgs e)
        {

            try
            {

                //RunScreen("UCHARGES.QKC", RunScreenModes.Find);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_19_Click(object sender, System.EventArgs e)
        {

            try
            {

                if (QDesign.NULL(fleM_INVESTORS.GetDecimalValue("STATUS")) != 99)
                {
                    //RunScreen("HYOPTION.QKC", RunScreenModes.Find, fleM_INVESTORS);
                }
                else
                {
                    if (QDesign.NULL(fleM_INVESTORS.GetDecimalValue("STATUS")) == 99)
                    {
                        Severe(QDesign.NULL("****** THIS FUNCTION NOT AVAILABLE FOR ") + QDesign.NULL("CANCELLED INVESTORS ******"));
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



        private void dsrDesigner_20_Click(object sender, System.EventArgs e)
        {

            try
            {

                //RunScreen("INVESTEX.QKC", RunScreenModes.Same, fleM_INVESTORS);


            }
            catch (CustomApplicationException ex)
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

                if (QDesign.NULL(fleM_INVESTORS.GetDecimalValue("STATUS")) != 99)
                {
                    //RunScreen("ADJCURMS.QKC", RunScreenModes.Find, fleM_INVESTORS);
                }
                else
                {
                    if (QDesign.NULL(fleM_INVESTORS.GetDecimalValue("STATUS")) == 99)
                    {
                        Severe(QDesign.NULL("****** THIS FUNCTION NOT AVAILABLE FOR ") + QDesign.NULL("CANCELLED INVESTORS ******"));
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



        private void dsrDesigner_22_Click(object sender, System.EventArgs e)
        {

            try
            {

                T_INVESTOR.Value = fleM_INVESTORS.GetStringValue("INVESTOR");
                //RunScreen("DDPAYMNT.QKC", RunScreenModes.Same, T_INVESTOR, T_DD_TYPE);


            }
            catch (CustomApplicationException ex)
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

                //RunScreen("WAITLIST.QKC", RunScreenModes.Find, T_PASS_LOCATION, T_PASS_INVESTOR, T_PASS_SCREEN, T_START_DATE, T_END_DATE);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }

        //#CORE_BEGIN_INCLUDE: REPRUNJ.USE"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 07/12/2013 1:48:43 PM


        private bool Internal_RUN_JOB()
        {


            try
            {

                m_blnCommandOK = RunCommand(D_STRIPJOB.ToString());
                // TODO: Check source code.  Manual process may be required.
                m_blnCommandOK = RunCommand(D_MAKEOWN.ToString());
                // TODO: Check source code.  Manual process may be required.
                m_blnCommandOK = RunCommand(D_RUNJOB.ToString());
                // TODO: Check source code.  Manual process may be required.
                m_blnCommandOK = RunCommand(D_MAKELOG.ToString());
                // TODO: Check source code.  Manual process may be required.
                m_blnCommandOK = RunCommand(D_CATJOB.ToString());
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

        //#CORE_END_INCLUDE: REPRUNJ.USE"




        private void dsrDesigner_24_Click(object sender, System.EventArgs e)
        {

            try
            {

                T_INVESTOR.Value = fleM_INVESTORS.GetStringValue("INVESTOR");
                //RunScreen("TRANSACT.QKC", RunScreenModes.Entry, T_INVESTOR);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_25_Click(object sender, System.EventArgs e)
        {

            try
            {

                //RunScreen("DFRPYMNT.QKC", RunScreenModes.Find, fleM_INVESTORS);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_27_Click(object sender, System.EventArgs e)
        {

            try
            {

                //RunScreen("BOOKPNTS.QKC", RunScreenModes.Find, T_PASS_INVESTOR);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_26_Click(object sender, System.EventArgs e)
        {

            try
            {

                if (QDesign.NULL(fleM_INVESTORS.GetDecimalValue("STATUS")) != 99)
                {
                    T_INVESTOR.Value = fleM_INVESTORS.GetStringValue("INVESTOR");
                    T_INVESTOR_NAME.Value = fleM_INVESTORS.GetStringValue("INVESTOR_NAME");
                    T_ADDRESS_1.Value = fleM_INVESTORS.GetStringValue("ADDRESS_1");
                    T_ADDRESS_2.Value = fleM_INVESTORS.GetStringValue("ADDRESS_2");
                    T_ADDRESS_3.Value = fleM_INVESTORS.GetStringValue("ADDRESS_3");
                    T_ADDRESS_4.Value = fleM_INVESTORS.GetStringValue("ADDRESS_4");
                    T_POST_CODE_AREA.Value = fleM_INVESTORS.GetStringValue("POST_CODE_AREA");
                    T_POST_CODE_ZONE.Value = fleM_INVESTORS.GetStringValue("POST_CODE_ZONE");
                    //RunScreen("AVAIL1.QKC", RunScreenModes.Entry, T_INVESTOR, T_INVESTOR_NAME, T_ADDRESS_1, T_ADDRESS_2, T_ADDRESS_3, T_ADDRESS_4, T_POST_CODE_AREA, T_POST_CODE_ZONE);
                }
                else
                {
                    if (QDesign.NULL(fleM_INVESTORS.GetDecimalValue("STATUS")) == 99)
                    {
                        Severe(QDesign.NULL("****** THIS FUNCTION NOT AVAILABLE FOR ") + QDesign.NULL("CANCELLED INVESTORS ******"));
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



        private void dsrDesigner_28_Click(object sender, System.EventArgs e)
        {

            try
            {

                //RunScreen("ADJRESV.QKC", RunScreenModes.Find, fleM_INVESTORS);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_29_Click(object sender, System.EventArgs e)
        {

            try
            {

                //RunScreen("ADJ70DAY.QKC", RunScreenModes.Find, fleM_INVESTORS);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_30_Click(object sender, System.EventArgs e)
        {

            try
            {

                //RunScreen("TRANSIDS.QKC", RunScreenModes.Find, fleM_INVESTORS);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_31_Click(object sender, System.EventArgs e)
        {

            try
            {

                //RunScreen("STATPNOW.QKC", RunScreenModes.Find, fleM_INVESTORS);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_32_Click(object sender, System.EventArgs e)
        {

            try
            {

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



        private void dsrDesigner_LD_Click(object sender, System.EventArgs e)
        {

            try
            {

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



        private void dsrDesigner_33_Click(object sender, System.EventArgs e)
        {

            try
            {

                T_INVESTOR.Value = fleM_INVESTORS.GetStringValue("INVESTOR");
                //RunScreen("LIMIT28D.QKC", RunScreenModes.Find, fleUSER_SEC_FILE, fleM_INVESTORS);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_34_Click(object sender, System.EventArgs e)
        {

            try
            {

                //RunScreen("PPCHARGE.QKC", RunScreenModes.Find, fleM_INVESTORS);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_35_Click(object sender, System.EventArgs e)
        {

            try
            {

                T_INVESTOR.Value = fleM_INVESTORS.GetStringValue("INVESTOR");
                //RunScreen("CREDITS.QKC", , T_INVESTOR, fleUSER_SEC_FILE);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_36_Click(object sender, System.EventArgs e)
        {

            try
            {

                T_INVESTOR.Value = fleM_INVESTORS.GetStringValue("INVESTOR");
                T_INVESTOR_NAME.Value = fleM_INVESTORS.GetStringValue("INVESTOR_NAME");
                T_SHARE_NO.Value = fleSHARE_INDEX.GetStringValue("SHARE_NO");
                //RunScreen("CALCMENU.QKC", , T_INVESTOR, T_INVESTOR_NAME, T_SHARE_NO);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_37_Click(object sender, System.EventArgs e)
        {

            try
            {

                T_BOOKING_REF.Value = "ANNUAL";
                T_INVESTOR.Value = fleM_INVESTORS.GetStringValue("INVESTOR");
                T_TYPE.Value = "A";
                //RunScreen("INSUR.QKC", RunScreenModes.Find, T_BOOKING_REF, T_INVESTOR, T_TYPE);
                // --> GET INSURANCE <--

                fleINSURANCE.GetData(GetDataOptions.IsOptional);
                // --> End GET INSURANCE <--
                Display(ref fldD_INSURANCE);
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

        //#CORE_BEGIN_INCLUDE: REPKEEP.USE"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 07/12/2013 1:48:44 PM



        private void dsrDesigner_LOG_Click(object sender, System.EventArgs e)
        {

            try
            {

                if (QDesign.NULL(T_DEL_JOBFILE.Value) == QDesign.NULL("N"))
                {
                    T_DEL_JOBFILE.Value = "Y";
                    Information(QDesign.NULL("The job file will be deleted afer use"));
                    // TODO: May need to fix manually
                }
                else
                {
                    T_DEL_JOBFILE.Value = "N";
                    Information(QDesign.NULL("The Job file will remain in the $LOG directory after use"));
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



        private void dsrDesigner_TEMP_Click(object sender, System.EventArgs e)
        {

            try
            {

                if (QDesign.NULL(T_DEL_TEMPS.Value) == QDesign.NULL("N"))
                {
                    T_DEL_TEMPS.Value = "Y";
                    Information(QDesign.NULL("temp work files will be deleted afer use"));
                    // TODO: May need to fix manually
                }
                else
                {
                    T_DEL_TEMPS.Value = "N";
                    Information(QDesign.NULL("temp work files will remain in the $LOG directory"));
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



        private void dsrDesigner_PRNT_Click(object sender, System.EventArgs e)
        {

            try
            {

                if (QDesign.NULL(T_PRINT_REPORT.Value) == QDesign.NULL("N"))
                {
                    T_PRINT_REPORT.Value = "Y";
                    T_DEL_REPORT.Value = "Y";
                    Information(QDesign.NULL("Report will be printed"));
                    // TODO: May need to fix manually
                }
                else
                {
                    T_PRINT_REPORT.Value = "N";
                    T_DEL_REPORT.Value = "N";
                    Information(QDesign.NULL("Report will not be printed - will keep in $REPORTS dir"));
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

        //#CORE_END_INCLUDE: REPKEEP.USE"




        private void dsrDesigner_CORE_CHECK_Click(object sender, System.EventArgs e)
        {

            try
            {

                Accept(ref fldM_INVESTORS_CHECK_ADDRESS);


            }
            catch (CustomApplicationException ex)
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
                //RunScreen("DMDPOL", RunScreenModes.Find, T_INVESTOR);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_CH_Click(object sender, System.EventArgs e)
        {

            try
            {

                //RunScreen("CARHIREV.QKC", RunScreenModes.Find, T_HIRE_LOCATION, T_DATE);


            }
            catch (CustomApplicationException ex)
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
                switch (m_intPath)
                {
                    case 1:
                        m_strWhere = new StringBuilder(GetWhereCondition(fleM_INVESTORS.ElementOwner("INVESTOR"), fleM_INVESTORS.GetStringValue("INVESTOR"), ref blnAddWhere));
                        fleM_INVESTORS.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
                        break;
                    case 2:
                        fleM_INVESTORS.GetData(GetDataOptions.Sequential | GetDataOptions.CreateSubSelect);
                        break;
                }

                fleEMAILS.GetData();

                fleINDEX_INVESTORS.GetData();


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
                RequestPrompt(ref fldM_INVESTORS_INVESTOR);
                if (m_blnPromptOK)
                {
                    m_intPath = 1;
                }
                if (m_intPath == 0)
                {
                    m_intPath = 2;
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
                Page.PageTitle = "Maintain Investors";



            }
            catch (CustomApplicationException ex)
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
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 07/12/2013 1:48:45 PM
        //#-----------------------------------------
        protected override bool Entry()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:48:45 PM
                Accept(ref fldM_INVESTORS_INVESTOR);
                Accept(ref fldM_INVESTORS_CORR_TITLE);
                Accept(ref fldM_INVESTORS_INITIAL_1);
                Accept(ref fldM_INVESTORS_INITIAL_2);
                Accept(ref fldM_INVESTORS_CORR_NAME);
                Accept(ref fldM_INVESTORS_INVESTOR_NAME);
                Display(ref fldD_INSURANCE);
                Display(ref fldINSURANCE_FINISH_DATE);
                Display(ref fldD_CHECK_ADDRESS);
                Accept(ref fldM_INVESTORS_CHECK_ADDRESS);
                Accept(ref fldM_INVESTORS_ADDRESS_1);
                Accept(ref fldM_INVESTORS_ADDRESS_2);
                Accept(ref fldM_INVESTORS_ADDRESS_3);
                Accept(ref fldM_INVESTORS_ADDRESS_4);
                Accept(ref fldM_INVESTORS_POST_CODE_AREA);
                Accept(ref fldM_INVESTORS_POST_CODE_ZONE);
                Display(ref fldINVESTMENTS_TERM_SURCHARGEPER);
                Accept(ref fldM_INVESTORS_TELEPHONE);
                Accept(ref fldM_INVESTORS_TEL_OFFICE);
                Accept(ref fldM_INVESTORS_TELEX);
                Accept(ref fldM_INVESTORS_DOB);
                Accept(ref fldM_INVESTORS_DISABLED);
                Accept(ref fldM_INVESTORS_GUARANTEE_END_DATE);
                Accept(ref fldM_INVESTORS_UNDER_GUARANTEE);
                Accept(ref fldM_INVESTORS_COLOUR);
                Accept(ref fldM_INVESTORS_SILVER_GOLD);
                Display(ref fldINVESTMENTS_QUALIFY_28DAY);
                Accept(ref fldD_SHAREHOLDER);
                Accept(ref fldD_HY1_TITLE);
                Accept(ref fldD_HY2_TITLE);
                Accept(ref fldD_HY3_TITLE);
                Display(ref fldD_ENT_BAL1);
                Display(ref fldD_BF_BAL1);
                Display(ref fldD_TOT_BAL1);
                Display(ref fldD_ENT_BAL2);
                Display(ref fldD_BF_BAL2);
                Display(ref fldD_TOT_BAL2);
                Display(ref fldD_ENT_BAL3);
                Display(ref fldD_BF_BAL3);
                Display(ref fldD_TOT_BAL3);
                Display(ref fldT_TOP_MESSAGE);
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
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 07/12/2013 1:48:45 PM
        //#-----------------------------------------
        protected override bool Update()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:48:45 PM
                fleM_INVESTORS.PutData(false, PutTypes.New);
                fleINDEX_INVESTORS.PutData();
                fleEMAILS.PutData();
                fleM_INVESTORS.PutData();
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
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 07/12/2013 1:48:46 PM
        //#-----------------------------------------
        private void dsrDesigner_06_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:48:46 PM
                Accept(ref fldM_INVESTORS_TELEPHONE);
                Accept(ref fldM_INVESTORS_TEL_OFFICE);
                Accept(ref fldM_INVESTORS_TELEX);
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
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 07/12/2013 1:48:46 PM
        //#-----------------------------------------
        private void dsrDesigner_07_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:48:46 PM
                Accept(ref fldM_INVESTORS_DOB);
                Accept(ref fldM_INVESTORS_DISABLED);
                if (!fleM_INVESTORS.NewRecord)
                {
                    Display(ref fldM_INVESTORS_GUARANTEE_END_DATE);
                }
                else
                {
                    Accept(ref fldM_INVESTORS_GUARANTEE_END_DATE);
                }
                if (!fleM_INVESTORS.NewRecord)
                {
                    Display(ref fldM_INVESTORS_UNDER_GUARANTEE);
                }
                else
                {
                    Accept(ref fldM_INVESTORS_UNDER_GUARANTEE);
                }
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
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 07/12/2013 1:48:46 PM
        //#-----------------------------------------
        private void dsrDesigner_02_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:48:46 PM
                Accept(ref fldM_INVESTORS_CORR_TITLE);
                Accept(ref fldM_INVESTORS_INITIAL_1);
                Accept(ref fldM_INVESTORS_INITIAL_2);
                Accept(ref fldM_INVESTORS_CORR_NAME);
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
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 07/12/2013 1:48:46 PM
        //#-----------------------------------------
        private void dsrDesigner_03_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:48:46 PM
                Accept(ref fldM_INVESTORS_INVESTOR_NAME);
                Display(ref fldD_INSURANCE);
                Display(ref fldINSURANCE_FINISH_DATE);
                Display(ref fldD_CHECK_ADDRESS);
                Accept(ref fldM_INVESTORS_CHECK_ADDRESS);
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
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 07/12/2013 1:48:46 PM
        //#-----------------------------------------
        private void dsrDesigner_08_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:48:46 PM
                Accept(ref fldM_INVESTORS_COLOUR);
                Accept(ref fldM_INVESTORS_SILVER_GOLD);
                Display(ref fldINVESTMENTS_QUALIFY_28DAY);
                Accept(ref fldT_COMMENTS);
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
