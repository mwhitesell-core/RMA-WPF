
#region "Screen Comments"

// ---------------------------------------------------------------:
// :
// system:       Holiday Property Bond                         :
// :
// program:      CHRG0000                                      :
// :
// task:         Maintain CHARGES for locations                :
// :
// files:        CHARGES             Primary                   :
// LOCATIONS           Reference                 :
// GRAPHS              Reference                 :
// :
// screens                                                     :
// called by:    MENU0000    Main system menu                  :
// calling:      xxxxxxxx    xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  :
// xxxxxxxx    xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  :
// :
// subprograms:  xxxxxxxx                                      :
// :
// ---------------------------------------------------------------:
// E   -  Change user charge field to allow for picture and     ;
// value range different to that in the dictionary to    ;
// allow for different currencies being held.            ;
// DH     20/01/90                                              ;
// ---------------------------------------------------------------;
// WJC   14/12/93            Added 4 new items (user-charge-a,  ;
// -b,-c,-d) instead of having a      ;
// single charge to be applied        ;
// throughout the year.               ;
// The user-charge are placed in the ;
// cluster, so that each week will be ;
// marked with the rate..             ;
// Modified Entry proc. Added        ;
// Preupdate Proc. for validation     ;
// purposes..                         ;
// ---------------------------------------------------------------;
// ;
// WJC   05/01/94            Commented-out (see preupdate proc) ;
// so that the user can enter zero    ;
// user charges...                    ;
// ---------------------------------------------------------------;
// 13/07/02 - set keys LOC-KEY && PROPERTY-BK-KEY OF CHARGES
// ---------------------------------------------------------------;
// 13/8/02 Kevin Fuller: Include additional User Charge Bands.
// User-Charge-A to J.
// -----------------------------------------------------------------
// 22/10/02 Kevin Fuller: Allow `read only` access for Mike Drury
// ---------------------------------------------------------------
// 16/10/03 Phil Jackson: Include additional User Charge Bands.
// User-Charge-K to Z.
// -----------------------------------------------------------------
// 26/10/04 -Rob: changed to preupdate from update
// Also removed commented out code re checking that
// usercharges have been entered.
// -----------------------------------------------------------------
// 18.01.05 ME  Add facility to spread valuse over next 2 years.
// -----------------------------------------------------------------
// 25.01.05 ME  Also transfer syndicated-value with points transfer.
// -----------------------------------------------------------------
// 04.11.05 ME  Correct charges2-charges and charges3-charges as 
// both procedures were sending  band D  to  band B 
// the following years.
// -----------------------------------------------------------------
// 28.03.06 ME  Add fields total-points and notional vat
// NOTE: VAT IS SET AT 0.175% AND WILL NEED TO BE ALTERED IF IT CHANGES
// -----------------------------------------------------------------
// 06.06.06 ME  Mike Drury no lingr at rma - so code removed.
// -----------------------------------------------------------------
// 12/06/06 RC  Addedd audit file CHARGES-AUDIT
// -----------------------------------------------------------------
// 28.11.08 PJ  VAT20081201 Rate change from 17.5% to 15%
// -----------------------------------------------------------------
// 18.11.09 ME  Check it`s a Bond property before continuing.
// -----------------------------------------------------------------
// 30.12.09 PJ  VAT20100101 Rate change from 15% to 17.5%
// -----------------------------------------------------------------
// 01.07.10 ME  Add link to Second Week Discounts screen.
// -----------------------------------------------------------------
// 17.12.10 PJ  VAT20110104 Rate change from 17.5% to 20%
// -----------------------------------------------------------------
// 27.01.11 RC  removed d-notional-vat -was not used and causing confusion
// -----------------------------------------------------------------
// 07.02.11 RC  Added security check to update procedure
// 18.09.12 RM  Add scrnvst to record visit to this screen
// -----------------------------------------------------------------
// ***********
// PLEASE NOTE: THIS SCREEN DOES NOT RECALCULATE NOTIONAL VAT.
// Notional VAT and total-points is now calculated
// by running the chargeup qtp/job
// ***********

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

    partial class CHRG0000 : BasePage
    {

        #region " Form Designer Generated Code "





        public CHRG0000()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "CHRG0000";

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
            dsrDesigner_SWDISC.Click += dsrDesigner_SWDISC_Click;
            dsrDesigner_93.Click += dsrDesigner_93_Click;
            dsrDesigner_01.Click += dsrDesigner_01_Click;
            dsrDesigner_91.Click += dsrDesigner_91_Click;
            dsrDesigner_90.Click += dsrDesigner_90_Click;
            dsrDesigner_02.Click += dsrDesigner_02_Click;
            
            fldCHARGES_GRAPH_TYPE.LookupOn += fldCHARGES_GRAPH_TYPE_LookupOn;
            fldCHARGES_PBK_YEAR.LookupNotOn += fldCHARGES_PBK_YEAR_LookupNotOn;
            fldCHARGES_LOCATION.LookupOn += fldCHARGES_LOCATION_LookupOn;
            
            //fldCHARGES_POINTS_CHARGE.Process += fldCHARGES_POINTS_CHARGE_Process;
            fldCHARGES_SYNDICATED_VALUE.Process += fldCHARGES_SYNDICATED_VALUE_Process;
            fldCHARGES_NO_OF_PROPERTIES.Process -= fldCHARGES_NO_OF_PROPERTIES_Process;
            fldCHARGES_GRAPH_TYPE.Process += fldCHARGES_GRAPH_TYPE_Process;

            Page_Load();

            // TODO: The following elements have Input/Output Scaling defined in the Dictionary or Screen.  Manual steps may be required:
            //       CHARGES.NOTIONAL_VAT InputScale: 2 OutputScale: 0
            //       CHARGES.SYNDICATED_VALUE InputScale: 2 OutputScale: 0
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
            //       CHARGES2.SYNDICATED_VALUE InputScale: 2 OutputScale: 0
            //       CHARGES2.USER_CHARGE_A InputScale: 2 OutputScale: 0
            //       CHARGES2.USER_CHARGE_B InputScale: 2 OutputScale: 0
            //       CHARGES2.USER_CHARGE_C InputScale: 2 OutputScale: 0
            //       CHARGES2.USER_CHARGE_D InputScale: 2 OutputScale: 0
            //       CHARGES2.USER_CHARGE_E InputScale: 2 OutputScale: 0
            //       CHARGES2.USER_CHARGE_F InputScale: 2 OutputScale: 0
            //       CHARGES2.USER_CHARGE_G InputScale: 2 OutputScale: 0
            //       CHARGES2.USER_CHARGE_H InputScale: 2 OutputScale: 0
            //       CHARGES2.USER_CHARGE_I InputScale: 2 OutputScale: 0
            //       CHARGES2.USER_CHARGE_J InputScale: 2 OutputScale: 0
            //       CHARGES2.USER_CHARGE_K InputScale: 2 OutputScale: 0
            //       CHARGES2.USER_CHARGE_L InputScale: 2 OutputScale: 0
            //       CHARGES2.USER_CHARGE_M InputScale: 2 OutputScale: 0
            //       CHARGES2.USER_CHARGE_N InputScale: 2 OutputScale: 0
            //       CHARGES2.USER_CHARGE_O InputScale: 2 OutputScale: 0
            //       CHARGES2.USER_CHARGE_P InputScale: 2 OutputScale: 0
            //       CHARGES2.USER_CHARGE_Q InputScale: 2 OutputScale: 0
            //       CHARGES2.USER_CHARGE_R InputScale: 2 OutputScale: 0
            //       CHARGES2.USER_CHARGE_S InputScale: 2 OutputScale: 0
            //       CHARGES2.USER_CHARGE_T InputScale: 2 OutputScale: 0
            //       CHARGES2.USER_CHARGE_U InputScale: 2 OutputScale: 0
            //       CHARGES2.USER_CHARGE_V InputScale: 2 OutputScale: 0
            //       CHARGES2.USER_CHARGE_W InputScale: 2 OutputScale: 0
            //       CHARGES2.USER_CHARGE_X InputScale: 2 OutputScale: 0
            //       CHARGES2.USER_CHARGE_Y InputScale: 2 OutputScale: 0
            //       CHARGES2.USER_CHARGE_Z InputScale: 2 OutputScale: 0
            //       CHARGES3.SYNDICATED_VALUE InputScale: 2 OutputScale: 0
            //       CHARGES3.USER_CHARGE_A InputScale: 2 OutputScale: 0
            //       CHARGES3.USER_CHARGE_B InputScale: 2 OutputScale: 0
            //       CHARGES3.USER_CHARGE_C InputScale: 2 OutputScale: 0
            //       CHARGES3.USER_CHARGE_D InputScale: 2 OutputScale: 0
            //       CHARGES3.USER_CHARGE_E InputScale: 2 OutputScale: 0
            //       CHARGES3.USER_CHARGE_F InputScale: 2 OutputScale: 0
            //       CHARGES3.USER_CHARGE_G InputScale: 2 OutputScale: 0
            //       CHARGES3.USER_CHARGE_H InputScale: 2 OutputScale: 0
            //       CHARGES3.USER_CHARGE_I InputScale: 2 OutputScale: 0
            //       CHARGES3.USER_CHARGE_J InputScale: 2 OutputScale: 0
            //       CHARGES3.USER_CHARGE_K InputScale: 2 OutputScale: 0
            //       CHARGES3.USER_CHARGE_L InputScale: 2 OutputScale: 0
            //       CHARGES3.USER_CHARGE_M InputScale: 2 OutputScale: 0
            //       CHARGES3.USER_CHARGE_N InputScale: 2 OutputScale: 0
            //       CHARGES3.USER_CHARGE_O InputScale: 2 OutputScale: 0
            //       CHARGES3.USER_CHARGE_P InputScale: 2 OutputScale: 0
            //       CHARGES3.USER_CHARGE_Q InputScale: 2 OutputScale: 0
            //       CHARGES3.USER_CHARGE_R InputScale: 2 OutputScale: 0
            //       CHARGES3.USER_CHARGE_S InputScale: 2 OutputScale: 0
            //       CHARGES3.USER_CHARGE_T InputScale: 2 OutputScale: 0
            //       CHARGES3.USER_CHARGE_U InputScale: 2 OutputScale: 0
            //       CHARGES3.USER_CHARGE_V InputScale: 2 OutputScale: 0
            //       CHARGES3.USER_CHARGE_W InputScale: 2 OutputScale: 0
            //       CHARGES3.USER_CHARGE_X InputScale: 2 OutputScale: 0
            //       CHARGES3.USER_CHARGE_Y InputScale: 2 OutputScale: 0
            //       CHARGES3.USER_CHARGE_Z InputScale: 2 OutputScale: 0
            //       GRAPHS.GRAPH_PERCENT InputScale: 4 OutputScale: 0
            // TODO: The following FIELD(S) on the form are array elements.  Manual steps may be required:
            //       CHARGES.POINTS_CHARGE Occurs: 53
            //       CHARGES.USER_CHARGE Occurs: 53
            // TODO: The following FIELD(S) on the form are redefine elements.  Manual steps may be required:
            //       CHARGES.PBK_YEAR


        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            T_SCREEN_NAME = new CoreCharacter("T_SCREEN_NAME", 20, this, ResetTypes.ResetAtStartup, "chrg0000.qks ");
            fleCHARGES = new OracleFileObject(this, FileTypes.Primary, 0, "INDEXED", "CHARGES", "", true, false, false, 0, "m_trnTRANS_UPDATE");
            fleCHARGES_DTL = new OracleFileObject(this, FileTypes.Detail, 53, "INDEXED", "CHARGES_DTL", "", true, false, false, 0, "m_trnTRANS_UPDATE");

            fleCHARGES2 = new OracleFileObject(this, FileTypes.Designer, 0, "INDEXED", "CHARGES", "CHARGES2", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleCHARGES3 = new OracleFileObject(this, FileTypes.Designer, 0, "INDEXED", "CHARGES", "CHARGES3", false, false, false, 0, "m_trnTRANS_UPDATE");
            T_TOTAL_POINTS = new CoreInteger("T_TOTAL_POINTS", 8, this);
            T_NOTIONAL_VAT = new CoreInteger("T_NOTIONAL_VAT", 8, this);
            fleLOCATIONS = new OracleFileObject(this, FileTypes.Reference, 0, "INDEXED", "LOCATIONS", "", false, false, false, 0, "m_cnnQUERY");
            fleGRAPHS = new OracleFileObject(this, FileTypes.Designer, 0, "INDEXED", "GRAPHS", "", false, false, false, 0, "m_cnnQUERY");
            fleGRAPHS_DTL = new OracleFileObject(this, FileTypes.Detail, 53, "INDEXED", "GRAPH_DTL", "", false, false, false, 0, "m_cnnQUERY");
            flePROPERTIES = new OracleFileObject(this, FileTypes.Reference, 0, "INDEXED", "PROPERTIES", "", false, false, false, 0, "m_cnnQUERY");
            fleUSER_SEC_FILE = new OracleFileObject(this, FileTypes.Designer, 0, "INDEXED", "USER_SEC_FILE", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleLOC_INFO = new OracleFileObject(this, FileTypes.Reference, 0, "INDEXED", "LOC_INFO", "", false, false, false, 0, "m_cnnQUERY");
            T_TOTAL_PERCENT = new CoreDecimal("T_TOTAL_PERCENT", 7, this, 0m);
            T_BALANCE = new CoreDecimal("T_BALANCE", 7, this, 0m);
            T_MAX_OCCURRENCE = new CoreInteger("T_MAX_OCCURRENCE", 3, this);
            T_UPD_NEXT_CHARGE = new CoreCharacter("T_UPD_NEXT_CHARGE", 1, this, "N");
            T_UPD_NEXT_POINTS = new CoreCharacter("T_UPD_NEXT_POINTS", 1, this, "N");
            T_LAST_WEEK = new CoreInteger("T_LAST_WEEK", 2, this, 0m);
            T_UPDATE_DESC = new CoreCharacter("T_UPDATE_DESC", 37, this, " ");
            T_UPDATE_NVAT = new CoreCharacter("T_UPDATE_NVAT", 1, this, " ");
            T_POINTS_CHANGED = new CoreCharacter("T_POINTS_CHANGED", 1, this, " ");
            T_PBK_YEAR = new CoreCharacter("T_PBK_YEAR", 10, this, " ");

            POINTSCHARGE1 = new CoreDecimal("POINTSCHARGE1", 4, this);
            POINTSCHARGE2 = new CoreDecimal("POINTSCHARGE2", 4, this);
            POINTSCHARGE3 = new CoreDecimal("POINTSCHARGE3", 4, this);
            POINTSCHARGE4 = new CoreDecimal("POINTSCHARGE4", 4, this);
            POINTSCHARGE5 = new CoreDecimal("POINTSCHARGE5", 4, this);
            POINTSCHARGE6 = new CoreDecimal("POINTSCHARGE6", 4, this);
            POINTSCHARGE7 = new CoreDecimal("POINTSCHARGE7", 4, this);
            POINTSCHARGE8 = new CoreDecimal("POINTSCHARGE8", 4, this);
            POINTSCHARGE9 = new CoreDecimal("POINTSCHARGE9", 4, this);
            POINTSCHARGE10 = new CoreDecimal("POINTSCHARGE10", 4, this);
            POINTSCHARGE11 = new CoreDecimal("POINTSCHARGE11", 4, this);
            POINTSCHARGE12 = new CoreDecimal("POINTSCHARGE12", 4, this);
            POINTSCHARGE13 = new CoreDecimal("POINTSCHARGE13", 4, this);
            POINTSCHARGE14 = new CoreDecimal("POINTSCHARGE14", 4, this);
            POINTSCHARGE15 = new CoreDecimal("POINTSCHARGE15", 4, this);
            POINTSCHARGE16 = new CoreDecimal("POINTSCHARGE16", 4, this);
            POINTSCHARGE17 = new CoreDecimal("POINTSCHARGE17", 4, this);
            POINTSCHARGE18 = new CoreDecimal("POINTSCHARGE18", 4, this);
            POINTSCHARGE19 = new CoreDecimal("POINTSCHARGE19", 4, this);
            POINTSCHARGE20 = new CoreDecimal("POINTSCHARGE20", 4, this);
            POINTSCHARGE21 = new CoreDecimal("POINTSCHARGE21", 4, this);
            POINTSCHARGE22 = new CoreDecimal("POINTSCHARGE22", 4, this);
            POINTSCHARGE23 = new CoreDecimal("POINTSCHARGE23", 4, this);
            POINTSCHARGE24 = new CoreDecimal("POINTSCHARGE24", 4, this);
            POINTSCHARGE25 = new CoreDecimal("POINTSCHARGE25", 4, this);
            POINTSCHARGE26 = new CoreDecimal("POINTSCHARGE26", 4, this);
            POINTSCHARGE27 = new CoreDecimal("POINTSCHARGE27", 4, this);
            POINTSCHARGE28 = new CoreDecimal("POINTSCHARGE28", 4, this);
            POINTSCHARGE29 = new CoreDecimal("POINTSCHARGE29", 4, this);
            POINTSCHARGE30 = new CoreDecimal("POINTSCHARGE30", 4, this);
            POINTSCHARGE31 = new CoreDecimal("POINTSCHARGE31", 4, this);
            POINTSCHARGE32 = new CoreDecimal("POINTSCHARGE32", 4, this);
            POINTSCHARGE33 = new CoreDecimal("POINTSCHARGE33", 4, this);
            POINTSCHARGE34 = new CoreDecimal("POINTSCHARGE34", 4, this);
            POINTSCHARGE35 = new CoreDecimal("POINTSCHARGE35", 4, this);
            POINTSCHARGE36 = new CoreDecimal("POINTSCHARGE36", 4, this);
            POINTSCHARGE37 = new CoreDecimal("POINTSCHARGE37", 4, this);
            POINTSCHARGE38 = new CoreDecimal("POINTSCHARGE38", 4, this);
            POINTSCHARGE39 = new CoreDecimal("POINTSCHARGE39", 4, this);
            POINTSCHARGE40 = new CoreDecimal("POINTSCHARGE40", 4, this);
            POINTSCHARGE41 = new CoreDecimal("POINTSCHARGE41", 4, this);
            POINTSCHARGE42 = new CoreDecimal("POINTSCHARGE42", 4, this);
            POINTSCHARGE43 = new CoreDecimal("POINTSCHARGE43", 4, this);
            POINTSCHARGE44 = new CoreDecimal("POINTSCHARGE44", 4, this);
            POINTSCHARGE45 = new CoreDecimal("POINTSCHARGE45", 4, this);
            POINTSCHARGE46 = new CoreDecimal("POINTSCHARGE46", 4, this);
            POINTSCHARGE47 = new CoreDecimal("POINTSCHARGE47", 4, this);
            POINTSCHARGE48 = new CoreDecimal("POINTSCHARGE48", 4, this);
            POINTSCHARGE49 = new CoreDecimal("POINTSCHARGE49", 4, this);
            POINTSCHARGE50 = new CoreDecimal("POINTSCHARGE50", 4, this);
            POINTSCHARGE51 = new CoreDecimal("POINTSCHARGE51", 4, this);
            POINTSCHARGE52 = new CoreDecimal("POINTSCHARGE52", 4, this);
            POINTSCHARGE53 = new CoreDecimal("POINTSCHARGE53", 4, this);
            USERCHARGE1 = new CoreVarChar("USERCHARGE1", 2, this);
            USERCHARGE2 = new CoreVarChar("USERCHARGE2", 2, this);
            USERCHARGE3 = new CoreVarChar("USERCHARGE3", 2, this);
            USERCHARGE4 = new CoreVarChar("USERCHARGE4", 2, this);
            USERCHARGE5 = new CoreVarChar("USERCHARGE5", 2, this);
            USERCHARGE6 = new CoreVarChar("USERCHARGE6", 2, this);
            USERCHARGE7 = new CoreVarChar("USERCHARGE7", 2, this);
            USERCHARGE8 = new CoreVarChar("USERCHARGE8", 2, this);
            USERCHARGE9 = new CoreVarChar("USERCHARGE9", 2, this);
            USERCHARGE10 = new CoreVarChar("USERCHARGE10", 2, this);
            USERCHARGE11 = new CoreVarChar("USERCHARGE11", 2, this);
            USERCHARGE12 = new CoreVarChar("USERCHARGE12", 2, this);
            USERCHARGE13 = new CoreVarChar("USERCHARGE13", 2, this);
            USERCHARGE14 = new CoreVarChar("USERCHARGE14", 2, this);
            USERCHARGE15 = new CoreVarChar("USERCHARGE15", 2, this);
            USERCHARGE16 = new CoreVarChar("USERCHARGE16", 2, this);
            USERCHARGE17 = new CoreVarChar("USERCHARGE17", 2, this);
            USERCHARGE18 = new CoreVarChar("USERCHARGE18", 2, this);
            USERCHARGE19 = new CoreVarChar("USERCHARGE19", 2, this);
            USERCHARGE20 = new CoreVarChar("USERCHARGE20", 2, this);
            USERCHARGE21 = new CoreVarChar("USERCHARGE21", 2, this);
            USERCHARGE22 = new CoreVarChar("USERCHARGE22", 2, this);
            USERCHARGE23 = new CoreVarChar("USERCHARGE23", 2, this);
            USERCHARGE24 = new CoreVarChar("USERCHARGE24", 2, this);
            USERCHARGE25 = new CoreVarChar("USERCHARGE25", 2, this);
            USERCHARGE26 = new CoreVarChar("USERCHARGE26", 2, this);
            USERCHARGE27 = new CoreVarChar("USERCHARGE27", 2, this);
            USERCHARGE28 = new CoreVarChar("USERCHARGE28", 2, this);
            USERCHARGE29 = new CoreVarChar("USERCHARGE29", 2, this);
            USERCHARGE30 = new CoreVarChar("USERCHARGE30", 2, this);
            USERCHARGE31 = new CoreVarChar("USERCHARGE31", 2, this);
            USERCHARGE32 = new CoreVarChar("USERCHARGE32", 2, this);
            USERCHARGE33 = new CoreVarChar("USERCHARGE33", 2, this);
            USERCHARGE34 = new CoreVarChar("USERCHARGE34", 2, this);
            USERCHARGE35 = new CoreVarChar("USERCHARGE35", 2, this);
            USERCHARGE36 = new CoreVarChar("USERCHARGE36", 2, this);
            USERCHARGE37 = new CoreVarChar("USERCHARGE37", 2, this);
            USERCHARGE38 = new CoreVarChar("USERCHARGE38", 2, this);
            USERCHARGE39 = new CoreVarChar("USERCHARGE39", 2, this);
            USERCHARGE40 = new CoreVarChar("USERCHARGE40", 2, this);
            USERCHARGE41 = new CoreVarChar("USERCHARGE41", 2, this);
            USERCHARGE42 = new CoreVarChar("USERCHARGE42", 2, this);
            USERCHARGE43 = new CoreVarChar("USERCHARGE43", 2, this);
            USERCHARGE44 = new CoreVarChar("USERCHARGE44", 2, this);
            USERCHARGE45 = new CoreVarChar("USERCHARGE45", 2, this);
            USERCHARGE46 = new CoreVarChar("USERCHARGE46", 2, this);
            USERCHARGE47 = new CoreVarChar("USERCHARGE47", 2, this);
            USERCHARGE48 = new CoreVarChar("USERCHARGE48", 2, this);
            USERCHARGE49 = new CoreVarChar("USERCHARGE49", 2, this);
            USERCHARGE50 = new CoreVarChar("USERCHARGE50", 2, this);
            USERCHARGE51 = new CoreVarChar("USERCHARGE51", 2, this);
            USERCHARGE52 = new CoreVarChar("USERCHARGE52", 2, this);
            USERCHARGE53 = new CoreVarChar("USERCHARGE53", 2, this);

            fleCHARGES_DTL.Access += fleCHARGES_DTL_Access;
            fleCHARGES2.Access += fleCHARGES2_Access;
            fleCHARGES3.Access += fleCHARGES3_Access;
            fleLOCATIONS.Access += fleLOCATIONS_Access;
            fleGRAPHS.Access += fleGRAPHS_Access;
            flePROPERTIES.Access += flePROPERTIES_Access;
            fleUSER_SEC_FILE.Access += fleUSER_SEC_FILE_Access;
            fleLOC_INFO.Access += fleLOC_INFO_Access;
            D_VALUE_PER_PROP.GetValue += D_VALUE_PER_PROP_GetValue;
            D_INTEGER_VALUE.GetValue += D_INTEGER_VALUE_GetValue;
            D_POINTS_CHARGE.GetValue += D_POINTS_CHARGE_GetValue;
            D_UK_BOND_PROP.GetValue += D_UK_BOND_PROP_GetValue;
            D_53_WEEK_YEAR.GetValue += D_53_WEEK_YEAR_GetValue;
            fleCHARGES_DTL.SetItemFinals += fleCHARGES_DTL_SetItemFinals;
            fleCHARGES.SetItemFinals += fleCHARGES_SetItemFinals;

        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;
            fleCHARGES2.Access -= fleCHARGES2_Access;
            fleCHARGES3.Access -= fleCHARGES3_Access;
            fleLOCATIONS.Access -= fleLOCATIONS_Access;
            fleGRAPHS.Access -= fleGRAPHS_Access;
            flePROPERTIES.Access -= flePROPERTIES_Access;
            fleUSER_SEC_FILE.Access -= fleUSER_SEC_FILE_Access;
            fleLOC_INFO.Access -= fleLOC_INFO_Access;
            D_VALUE_PER_PROP.GetValue -= D_VALUE_PER_PROP_GetValue;
            D_INTEGER_VALUE.GetValue -= D_INTEGER_VALUE_GetValue;
            D_POINTS_CHARGE.GetValue -= D_POINTS_CHARGE_GetValue;
            D_UK_BOND_PROP.GetValue -= D_UK_BOND_PROP_GetValue;
            D_53_WEEK_YEAR.GetValue -= D_53_WEEK_YEAR_GetValue;
            fldCHARGES_GRAPH_TYPE.LookupOn -= fldCHARGES_GRAPH_TYPE_LookupOn;
            fldCHARGES_PBK_YEAR.LookupNotOn -= fldCHARGES_PBK_YEAR_LookupNotOn;
            fldCHARGES_LOCATION.LookupOn -= fldCHARGES_LOCATION_LookupOn;
            fleCHARGES_DTL.SetItemFinals -= fleCHARGES_DTL_SetItemFinals;
            //fldCHARGES_POINTS_CHARGE.Process -= fldCHARGES_POINTS_CHARGE_Process;
            fldCHARGES_SYNDICATED_VALUE.Process -= fldCHARGES_SYNDICATED_VALUE_Process;
            fldCHARGES_NO_OF_PROPERTIES.Process -= fldCHARGES_NO_OF_PROPERTIES_Process;
            fldCHARGES_GRAPH_TYPE.Process -= fldCHARGES_GRAPH_TYPE_Process;
            fleCHARGES.SetItemFinals -= fleCHARGES_SetItemFinals;
            dsrDesigner_SWDISC.Click -= dsrDesigner_SWDISC_Click;
            dsrDesigner_93.Click -= dsrDesigner_93_Click;
            dsrDesigner_01.Click -= dsrDesigner_01_Click;
            dsrDesigner_91.Click -= dsrDesigner_91_Click;
            dsrDesigner_90.Click -= dsrDesigner_90_Click;
            dsrDesigner_02.Click -= dsrDesigner_02_Click;


        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private OracleConnection m_cnnQUERY = new OracleConnection();
        private OracleConnection m_cnnTRANS_UPDATE = new OracleConnection();
        private OracleTransaction m_trnTRANS_UPDATE;
        private CoreCharacter T_SCREEN_NAME;
        private OracleFileObject fleCHARGES;
        private OracleFileObject fleCHARGES_DTL;

      

        private void fleCHARGES_SetItemFinals()
        {

            try
            {
                fleCHARGES.set_SetValue("LOC_KEY", fleCHARGES.GetStringValue("LOCATION"));
                fleCHARGES.set_SetValue("PROPERTY_BK_KEY", QDesign.Substring(fleCHARGES.GetStringValue("LOCATION") + fleCHARGES.GetStringValue("BEDS") + fleCHARGES.GetStringValue("PROPERTY_STYLE") + fleCHARGES.GetStringValue("BATHROOMS") + fleCHARGES.GetStringValue("YEAR"), 1, 6));
                //Parent:PBK_YEAR


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }

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

        private void fleCHARGES_DTL_SetItemFinals()
        {

            try
            {
                fleCHARGES_DTL.set_SetValue("LOCATION", fleCHARGES.GetStringValue("LOCATION"));
                fleCHARGES_DTL.set_SetValue("BEDS", fleCHARGES.GetStringValue("BEDS"));
                fleCHARGES_DTL.set_SetValue("PROPERTY_STYLE", fleCHARGES.GetStringValue("PROPERTY_STYLE"));
                fleCHARGES_DTL.set_SetValue("BATHROOMS", fleCHARGES.GetStringValue("BATHROOMS"));
                fleCHARGES_DTL.set_SetValue("YEAR", fleCHARGES.GetStringValue("YEAR"));



            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }

        private OracleFileObject fleCHARGES2;

        private void fleCHARGES2_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleCHARGES2.ElementOwner("LOCATION")).Append(" = ").Append(Common.StringToField(fleCHARGES.GetStringValue("LOCATION")));
                //Parent:PBK_YEAR    'Parent:PBK_YEAR
                strText.Append(" AND ").Append(fleCHARGES2.ElementOwner("BEDS")).Append(" = ").Append(Common.StringToField(fleCHARGES.GetStringValue("BEDS")));
                //Parent:PBK_YEAR    'Parent:PBK_YEAR
                strText.Append(" AND ").Append(fleCHARGES2.ElementOwner("PROPERTY_STYLE")).Append(" = ").Append(Common.StringToField(fleCHARGES.GetStringValue("PROPERTY_STYLE")));
                //Parent:PBK_YEAR    'Parent:PBK_YEAR
                strText.Append(" AND ").Append(fleCHARGES2.ElementOwner("BATHROOMS")).Append(" = ").Append(Common.StringToField(fleCHARGES.GetStringValue("BATHROOMS")));
                //Parent:PBK_YEAR    'Parent:PBK_YEAR
                strText.Append(" AND ").Append(fleCHARGES2.ElementOwner("YEAR")).Append(" = ").Append(Common.StringToField(fleCHARGES.GetStringValue("YEAR")));
                //Parent:PBK_YEAR    'Parent:PBK_YEAR

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



        private void fleCHARGES2_SetItemFinals()
        {

            try
            {
                fleCHARGES2.set_SetValue("LOC_KEY", fleCHARGES2.GetStringValue("LOCATION"));
                fleCHARGES2.set_SetValue("PROPERTY_BK_KEY", QDesign.Substring(fleCHARGES2.GetStringValue("LOCATION") + fleCHARGES2.GetStringValue("BEDS") + fleCHARGES2.GetStringValue("PROPERTY_STYLE") + fleCHARGES2.GetStringValue("BATHROOMS") + fleCHARGES2.GetStringValue("YEAR"), 1, 6));
                //Parent:PBK_YEAR


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }

        private OracleFileObject fleCHARGES3;

        private void fleCHARGES3_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleCHARGES3.ElementOwner("LOCATION")).Append(" = ").Append(Common.StringToField(fleCHARGES.GetStringValue("LOCATION")));
                //Parent:PBK_YEAR    'Parent:PBK_YEAR
                strText.Append(" AND ").Append(fleCHARGES3.ElementOwner("BEDS")).Append(" = ").Append(Common.StringToField(fleCHARGES.GetStringValue("BEDS")));
                //Parent:PBK_YEAR    'Parent:PBK_YEAR
                strText.Append(" AND ").Append(fleCHARGES3.ElementOwner("PROPERTY_STYLE")).Append(" = ").Append(Common.StringToField(fleCHARGES.GetStringValue("PROPERTY_STYLE")));
                //Parent:PBK_YEAR    'Parent:PBK_YEAR
                strText.Append(" AND ").Append(fleCHARGES3.ElementOwner("BATHROOMS")).Append(" = ").Append(Common.StringToField(fleCHARGES.GetStringValue("BATHROOMS")));
                //Parent:PBK_YEAR    'Parent:PBK_YEAR
                strText.Append(" AND ").Append(fleCHARGES3.ElementOwner("YEAR")).Append(" = ").Append(Common.StringToField(fleCHARGES.GetStringValue("YEAR")));
                //Parent:PBK_YEAR    'Parent:PBK_YEAR

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



        private void fleCHARGES3_SetItemFinals()
        {

            try
            {
                fleCHARGES3.set_SetValue("LOC_KEY", fleCHARGES3.GetStringValue("LOCATION"));
                fleCHARGES3.set_SetValue("PROPERTY_BK_KEY", QDesign.Substring(fleCHARGES3.GetStringValue("LOCATION") + fleCHARGES3.GetStringValue("BEDS") + fleCHARGES3.GetStringValue("PROPERTY_STYLE") + fleCHARGES3.GetStringValue("BATHROOMS") + fleCHARGES3.GetStringValue("YEAR"), 1, 6));
                //Parent:PBK_YEAR


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }

        private CoreInteger T_TOTAL_POINTS;
        private CoreInteger T_NOTIONAL_VAT;
        private OracleFileObject fleLOCATIONS;

        private void fleLOCATIONS_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleLOCATIONS.ElementOwner("LOCATION")).Append(" = ").Append(Common.StringToField(fleCHARGES.GetStringValue("LOCATION")));

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

        private OracleFileObject fleGRAPHS_DTL;
        private OracleFileObject fleGRAPHS;

        private void fleGRAPHS_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleGRAPHS.ElementOwner("GRAPH_TYPE")).Append(" = ").Append(Common.StringToField(fleCHARGES.GetStringValue("GRAPH_TYPE")));

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

                strText.Append(" WHERE ").Append(flePROPERTIES.ElementOwner("LOCATION")).Append(" = ").Append(Common.StringToField(fleCHARGES.GetStringValue("LOCATION")));

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



        private void flePROPERTIES_SelectIf(ref string SelectIfClause)
        {


            try
            {
                StringBuilder strSQL = new StringBuilder("");

                strSQL.Append(" (    ").Append(flePROPERTIES.ElementOwner("LOCATION")).Append(" = ").Append(Common.StringToField(fleCHARGES.GetStringValue("PROPERTY_BK_KEY").PadRight(6).Substring(0, 2)));
                //Parent:PROPERTY_BK_KEY
                strSQL.Append(" AND ").Append(" (    ").Append(flePROPERTIES.ElementOwner("BEDS")).Append(" = ").Append(Common.StringToField(fleCHARGES.GetStringValue("PROPERTY_BK_KEY").PadRight(6).Substring(2, 1)));
                //Parent:PROPERTY_BK_KEY
                strSQL.Append(" AND ").Append(" (    ").Append(flePROPERTIES.ElementOwner("PROPERTY_STYLE")).Append(" = ").Append(Common.StringToField(fleCHARGES.GetStringValue("PROPERTY_BK_KEY").PadRight(6).Substring(3, 2)));
                //Parent:PROPERTY_BK_KEY
                strSQL.Append(" AND ").Append(" (    ").Append(flePROPERTIES.ElementOwner("BATHROOMS")).Append(" = ").Append(Common.StringToField(fleCHARGES.GetStringValue("PROPERTY_BK_KEY").PadRight(6).Substring(5, 1)));
                //Parent:PROPERTY_BK_KEY
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

        private OracleFileObject fleLOC_INFO;

        private void fleLOC_INFO_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleLOC_INFO.ElementOwner("LOCATION")).Append(" = ").Append(Common.StringToField(fleCHARGES.GetStringValue("LOCATION")));

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

        private CoreDecimal POINTSCHARGE1;
        private CoreDecimal POINTSCHARGE2;
        private CoreDecimal POINTSCHARGE3;
        private CoreDecimal POINTSCHARGE4;
        private CoreDecimal POINTSCHARGE5;
        private CoreDecimal POINTSCHARGE6;
        private CoreDecimal POINTSCHARGE7;
        private CoreDecimal POINTSCHARGE8;
        private CoreDecimal POINTSCHARGE9;
        private CoreDecimal POINTSCHARGE10;
        private CoreDecimal POINTSCHARGE11;
        private CoreDecimal POINTSCHARGE12;
        private CoreDecimal POINTSCHARGE13;
        private CoreDecimal POINTSCHARGE14;
        private CoreDecimal POINTSCHARGE15;
        private CoreDecimal POINTSCHARGE16;
        private CoreDecimal POINTSCHARGE17;
        private CoreDecimal POINTSCHARGE18;
        private CoreDecimal POINTSCHARGE19;
        private CoreDecimal POINTSCHARGE20;
        private CoreDecimal POINTSCHARGE21;
        private CoreDecimal POINTSCHARGE22;
        private CoreDecimal POINTSCHARGE23;
        private CoreDecimal POINTSCHARGE24;
        private CoreDecimal POINTSCHARGE25;
        private CoreDecimal POINTSCHARGE26;
        private CoreDecimal POINTSCHARGE27;
        private CoreDecimal POINTSCHARGE28;
        private CoreDecimal POINTSCHARGE29;
        private CoreDecimal POINTSCHARGE30;
        private CoreDecimal POINTSCHARGE31;
        private CoreDecimal POINTSCHARGE32;
        private CoreDecimal POINTSCHARGE33;
        private CoreDecimal POINTSCHARGE34;
        private CoreDecimal POINTSCHARGE35;
        private CoreDecimal POINTSCHARGE36;
        private CoreDecimal POINTSCHARGE37;
        private CoreDecimal POINTSCHARGE38;
        private CoreDecimal POINTSCHARGE39;
        private CoreDecimal POINTSCHARGE40;
        private CoreDecimal POINTSCHARGE41;
        private CoreDecimal POINTSCHARGE42;
        private CoreDecimal POINTSCHARGE43;
        private CoreDecimal POINTSCHARGE44;
        private CoreDecimal POINTSCHARGE45;
        private CoreDecimal POINTSCHARGE46;
        private CoreDecimal POINTSCHARGE47;
        private CoreDecimal POINTSCHARGE48;
        private CoreDecimal POINTSCHARGE49;
        private CoreDecimal POINTSCHARGE50;
        private CoreDecimal POINTSCHARGE51;
        private CoreDecimal POINTSCHARGE52;
        private CoreDecimal POINTSCHARGE53;
        private CoreVarChar USERCHARGE1;
        private CoreVarChar USERCHARGE2;
        private CoreVarChar USERCHARGE3;
        private CoreVarChar USERCHARGE4;
        private CoreVarChar USERCHARGE5;
        private CoreVarChar USERCHARGE6;
        private CoreVarChar USERCHARGE7;
        private CoreVarChar USERCHARGE8;
        private CoreVarChar USERCHARGE9;
        private CoreVarChar USERCHARGE10;
        private CoreVarChar USERCHARGE11;
        private CoreVarChar USERCHARGE12;
        private CoreVarChar USERCHARGE13;
        private CoreVarChar USERCHARGE14;
        private CoreVarChar USERCHARGE15;
        private CoreVarChar USERCHARGE16;
        private CoreVarChar USERCHARGE17;
        private CoreVarChar USERCHARGE18;
        private CoreVarChar USERCHARGE19;
        private CoreVarChar USERCHARGE20;
        private CoreVarChar USERCHARGE21;
        private CoreVarChar USERCHARGE22;
        private CoreVarChar USERCHARGE23;
        private CoreVarChar USERCHARGE24;
        private CoreVarChar USERCHARGE25;
        private CoreVarChar USERCHARGE26;
        private CoreVarChar USERCHARGE27;
        private CoreVarChar USERCHARGE28;
        private CoreVarChar USERCHARGE29;
        private CoreVarChar USERCHARGE30;
        private CoreVarChar USERCHARGE31;
        private CoreVarChar USERCHARGE32;
        private CoreVarChar USERCHARGE33;
        private CoreVarChar USERCHARGE34;
        private CoreVarChar USERCHARGE35;
        private CoreVarChar USERCHARGE36;
        private CoreVarChar USERCHARGE37;
        private CoreVarChar USERCHARGE38;
        private CoreVarChar USERCHARGE39;
        private CoreVarChar USERCHARGE40;
        private CoreVarChar USERCHARGE41;
        private CoreVarChar USERCHARGE42;
        private CoreVarChar USERCHARGE43;
        private CoreVarChar USERCHARGE44;
        private CoreVarChar USERCHARGE45;
        private CoreVarChar USERCHARGE46;
        private CoreVarChar USERCHARGE47;
        private CoreVarChar USERCHARGE48;
        private CoreVarChar USERCHARGE49;
        private CoreVarChar USERCHARGE50;
        private CoreVarChar USERCHARGE51;
        private CoreVarChar USERCHARGE52;
        private CoreVarChar USERCHARGE53;

        private CoreDecimal T_TOTAL_PERCENT;
        private CoreDecimal T_BALANCE;
        private CoreInteger T_MAX_OCCURRENCE;
        private CoreCharacter T_UPD_NEXT_CHARGE;
        private CoreCharacter T_UPD_NEXT_POINTS;
        private CoreInteger T_LAST_WEEK;
        private CoreCharacter T_UPDATE_DESC;
        private CoreCharacter T_UPDATE_NVAT;
        private CoreCharacter T_POINTS_CHANGED;
        private CoreCharacter T_PBK_YEAR;
        private DDecimal D_VALUE_PER_PROP = new DDecimal(8);
        private void D_VALUE_PER_PROP_GetValue(ref decimal Value)
        {

            try
            {

                Value = ((fleCHARGES.GetDecimalValue("SYNDICATED_VALUE") / fleCHARGES.GetDecimalValue("NO_OF_PROPERTIES") / 10000)) * (fleGRAPHS_DTL.GetDecimalValue("GRAPH_PERCENT") / 10000);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DDecimal D_INTEGER_VALUE = new DDecimal(8);
        private void D_INTEGER_VALUE_GetValue(ref decimal Value)
        {

            try
            {
                Value = QDesign.Floor(D_VALUE_PER_PROP.Value);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DDecimal D_POINTS_CHARGE = new DDecimal(8);
        private void D_POINTS_CHARGE_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0m;
                if (5 > QDesign.NULL(QDesign.PHMod(D_INTEGER_VALUE.Value, 10)))
                {
                    CurrentValue = D_INTEGER_VALUE.Value - QDesign.PHMod(D_INTEGER_VALUE.Value, 10);
                }
                else
                {
                    CurrentValue = D_INTEGER_VALUE.Value + (10 - (QDesign.PHMod(D_INTEGER_VALUE.Value, 10)));
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
        private DCharacter D_UK_BOND_PROP = new DCharacter(1);
        private void D_UK_BOND_PROP_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if ((QDesign.NULL(flePROPERTIES.GetStringValue("GROUPING")) == "BOND" || QDesign.NULL(flePROPERTIES.GetStringValue("GROUPING")) == "FISH") && QDesign.NULL(flePROPERTIES.GetStringValue("VAT_FLAG")) == "Y")
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
        private DCharacter D_53_WEEK_YEAR = new DCharacter(1);
        private void D_53_WEEK_YEAR_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(fleCHARGES2.GetStringValue("YEAR")) == "2009" || QDesign.NULL(fleCHARGES2.GetStringValue("YEAR")) == "2015" || QDesign.NULL(fleCHARGES2.GetStringValue("YEAR")) == "2020")
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

        #endregion

        #region "Standard Generated Procedures"

        #region "Grid Field Declarations"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 07/12/2013 1:48:10 PM

        //# No code was generated or needed for this region.

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 07/12/2013 1:48:10 PM

        //# No code was generated or needed for this region.

        #endregion

        #region "Transaction Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 07/12/2013 1:48:10 PM

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
            fleCHARGES.Transaction = m_trnTRANS_UPDATE;
            fleCHARGES2.Transaction = m_trnTRANS_UPDATE;
            fleCHARGES3.Transaction = m_trnTRANS_UPDATE;
            fleUSER_SEC_FILE.Transaction = m_trnTRANS_UPDATE;
            fleCHARGES_DTL.Transaction = m_trnTRANS_UPDATE;

        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 07/12/2013 1:48:10 PM

        //#-----------------------------------------
        //# InitializeFiles Procedure.
        //#-----------------------------------------

        protected override void InitializeFiles()
        {

            try
            {
                Initialize_TRANS_UPDATE();
                fleLOCATIONS.Connection = m_cnnQUERY;
                fleGRAPHS.Connection = m_cnnQUERY;
                fleGRAPHS_DTL.Connection = m_cnnQUERY;
                flePROPERTIES.Connection = m_cnnQUERY;
                fleLOC_INFO.Connection = m_cnnQUERY;


            }
            catch (CustomApplicationException ex)
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
                fleCHARGES.Dispose();
                fleCHARGES2.Dispose();
                fleCHARGES3.Dispose();
                fleLOCATIONS.Dispose();
                fleGRAPHS.Dispose();
                fleGRAPHS_DTL.Dispose();
                flePROPERTIES.Dispose();
                fleUSER_SEC_FILE.Dispose();
                fleLOC_INFO.Dispose();
                fleCHARGES_DTL.Dispose();


            }
            catch (CustomApplicationException ex)
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
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 07/12/2013 1:48:10 PM
        //#-----------------------------------------
        protected override void DisplayFormatting()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:48:10 PM
                Display(ref fldPOINTS_CHARGE1);
                Display(ref fldPOINTS_CHARGE2);
                Display(ref fldPOINTS_CHARGE3);
                Display(ref fldPOINTS_CHARGE4);
                Display(ref fldPOINTS_CHARGE5);
                Display(ref fldPOINTS_CHARGE6);
                Display(ref fldPOINTS_CHARGE7);
                Display(ref fldPOINTS_CHARGE8);
                Display(ref fldPOINTS_CHARGE9);
                Display(ref fldPOINTS_CHARGE10);
                Display(ref fldPOINTS_CHARGE11);
                Display(ref fldPOINTS_CHARGE12);
                Display(ref fldPOINTS_CHARGE13);
                Display(ref fldPOINTS_CHARGE14);
                Display(ref fldPOINTS_CHARGE15);
                Display(ref fldPOINTS_CHARGE16);
                Display(ref fldPOINTS_CHARGE17);
                Display(ref fldPOINTS_CHARGE18);
                Display(ref fldPOINTS_CHARGE19);
                Display(ref fldPOINTS_CHARGE20);
                Display(ref fldPOINTS_CHARGE21);
                Display(ref fldPOINTS_CHARGE22);
                Display(ref fldPOINTS_CHARGE23);
                Display(ref fldPOINTS_CHARGE24);
                Display(ref fldPOINTS_CHARGE25);
                Display(ref fldPOINTS_CHARGE26);
                Display(ref fldPOINTS_CHARGE27);
                Display(ref fldPOINTS_CHARGE28);
                Display(ref fldPOINTS_CHARGE29);
                Display(ref fldPOINTS_CHARGE30);
                Display(ref fldPOINTS_CHARGE31);
                Display(ref fldPOINTS_CHARGE32);
                Display(ref fldPOINTS_CHARGE33);
                Display(ref fldPOINTS_CHARGE34);
                Display(ref fldPOINTS_CHARGE35);
                Display(ref fldPOINTS_CHARGE36);
                Display(ref fldPOINTS_CHARGE37);
                Display(ref fldPOINTS_CHARGE38);
                Display(ref fldPOINTS_CHARGE39);
                Display(ref fldPOINTS_CHARGE40);
                Display(ref fldPOINTS_CHARGE41);
                Display(ref fldPOINTS_CHARGE42);
                Display(ref fldPOINTS_CHARGE43);
                Display(ref fldPOINTS_CHARGE44);
                Display(ref fldPOINTS_CHARGE45);
                Display(ref fldPOINTS_CHARGE46);
                Display(ref fldPOINTS_CHARGE47);
                Display(ref fldPOINTS_CHARGE48);
                Display(ref fldPOINTS_CHARGE49);
                Display(ref fldPOINTS_CHARGE50);
                Display(ref fldPOINTS_CHARGE51);
                Display(ref fldPOINTS_CHARGE52);
                Display(ref fldPOINTS_CHARGE53);
                Display(ref fldUSER_CHARGE1);
                Display(ref fldUSER_CHARGE2);
                Display(ref fldUSER_CHARGE3);
                Display(ref fldUSER_CHARGE4);
                Display(ref fldUSER_CHARGE5);
                Display(ref fldUSER_CHARGE6);
                Display(ref fldUSER_CHARGE7);
                Display(ref fldUSER_CHARGE8);
                Display(ref fldUSER_CHARGE9);
                Display(ref fldUSER_CHARGE10);
                Display(ref fldUSER_CHARGE11);
                Display(ref fldUSER_CHARGE12);
                Display(ref fldUSER_CHARGE13);
                Display(ref fldUSER_CHARGE14);
                Display(ref fldUSER_CHARGE15);
                Display(ref fldUSER_CHARGE16);
                Display(ref fldUSER_CHARGE17);
                Display(ref fldUSER_CHARGE18);
                Display(ref fldUSER_CHARGE19);
                Display(ref fldUSER_CHARGE20);
                Display(ref fldUSER_CHARGE21);
                Display(ref fldUSER_CHARGE22);
                Display(ref fldUSER_CHARGE23);
                Display(ref fldUSER_CHARGE24);
                Display(ref fldUSER_CHARGE25);
                Display(ref fldUSER_CHARGE26);
                Display(ref fldUSER_CHARGE27);
                Display(ref fldUSER_CHARGE28);
                Display(ref fldUSER_CHARGE29);
                Display(ref fldUSER_CHARGE30);
                Display(ref fldUSER_CHARGE31);
                Display(ref fldUSER_CHARGE32);
                Display(ref fldUSER_CHARGE33);
                Display(ref fldUSER_CHARGE34);
                Display(ref fldUSER_CHARGE35);
                Display(ref fldUSER_CHARGE36);
                Display(ref fldUSER_CHARGE37);
                Display(ref fldUSER_CHARGE38);
                Display(ref fldUSER_CHARGE39);
                Display(ref fldUSER_CHARGE40);
                Display(ref fldUSER_CHARGE41);
                Display(ref fldUSER_CHARGE42);
                Display(ref fldUSER_CHARGE43);
                Display(ref fldUSER_CHARGE44);
                Display(ref fldUSER_CHARGE45);
                Display(ref fldUSER_CHARGE46);
                Display(ref fldUSER_CHARGE47);
                Display(ref fldUSER_CHARGE48);
                Display(ref fldUSER_CHARGE49);
                Display(ref fldUSER_CHARGE50);
                Display(ref fldUSER_CHARGE51);
                Display(ref fldUSER_CHARGE52);
                Display(ref fldUSER_CHARGE53);
                Display(ref fldT_UPDATE_DESC);
                Display(ref fldT_UPDATE_NVAT);
                Display(ref fldCHARGES_USER_CHARGE_A);
                Display(ref fldCHARGES_USER_CHARGE_B);
                Display(ref fldCHARGES_USER_CHARGE_C);
                Display(ref fldCHARGES_USER_CHARGE_D);
                Display(ref fldCHARGES_USER_CHARGE_E);
                Display(ref fldCHARGES_USER_CHARGE_F);
                Display(ref fldCHARGES_USER_CHARGE_G);
                Display(ref fldCHARGES_USER_CHARGE_H);
                Display(ref fldCHARGES_USER_CHARGE_I);
                Display(ref fldCHARGES_USER_CHARGE_J);
                Display(ref fldCHARGES_USER_CHARGE_K);
                Display(ref fldCHARGES_USER_CHARGE_L);
                Display(ref fldCHARGES_USER_CHARGE_M);
                Display(ref fldCHARGES_USER_CHARGE_N);
                Display(ref fldCHARGES_USER_CHARGE_O);
                Display(ref fldCHARGES_USER_CHARGE_P);
                Display(ref fldCHARGES_USER_CHARGE_Q);
                Display(ref fldCHARGES_USER_CHARGE_R);
                Display(ref fldCHARGES_USER_CHARGE_S);
                Display(ref fldCHARGES_USER_CHARGE_T);
                Display(ref fldCHARGES_USER_CHARGE_U);
                Display(ref fldCHARGES_USER_CHARGE_V);
                Display(ref fldCHARGES_USER_CHARGE_W);
                Display(ref fldCHARGES_USER_CHARGE_X);
                Display(ref fldCHARGES_USER_CHARGE_Y);
                Display(ref fldCHARGES_USER_CHARGE_Z);
                Display(ref fldCHARGES_LOCATION);
                Display(ref fldCHARGES_BEDS);
                Display(ref fldCHARGES_PROPERTY_STYLE);
                Display(ref fldCHARGES_BATHROOMS);
                Display(ref fldCHARGES_YEAR);
                Display(ref fldCHARGES_SYNDICATED_VALUE);
                Display(ref fldCHARGES_NO_OF_PROPERTIES);
                Display(ref fldCHARGES_TOTAL_POINTS);
                Display(ref fldCHARGES_GRAPH_TYPE);
                Display(ref fldGRAPHS_GRAPH_NAME);
                Display(ref fldCHARGES_NOTIONAL_VAT);
                Display(ref fldT_UPD_NEXT_CHARGE);
                Display(ref fldT_UPD_NEXT_POINTS);
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
        //# Do not delete, modify or move it.  Updated: 07/12/2013 1:48:10 PM

        //#-----------------------------------------
        //# BindFields Procedure.
        //#-----------------------------------------

        public override void BindFields()
        {
            try
            {
                fldPOINTS_CHARGE1.Bind(POINTSCHARGE1);
                fldPOINTS_CHARGE2.Bind(POINTSCHARGE2);
                fldPOINTS_CHARGE3.Bind(POINTSCHARGE3);
                fldPOINTS_CHARGE4.Bind(POINTSCHARGE4);
                fldPOINTS_CHARGE5.Bind(POINTSCHARGE5);
                fldPOINTS_CHARGE6.Bind(POINTSCHARGE6);
                fldPOINTS_CHARGE7.Bind(POINTSCHARGE7);
                fldPOINTS_CHARGE8.Bind(POINTSCHARGE8);
                fldPOINTS_CHARGE9.Bind(POINTSCHARGE9);
                fldPOINTS_CHARGE10.Bind(POINTSCHARGE10);
                fldPOINTS_CHARGE11.Bind(POINTSCHARGE11);
                fldPOINTS_CHARGE12.Bind(POINTSCHARGE12);
                fldPOINTS_CHARGE13.Bind(POINTSCHARGE13);
                fldPOINTS_CHARGE14.Bind(POINTSCHARGE14);
                fldPOINTS_CHARGE15.Bind(POINTSCHARGE15);
                fldPOINTS_CHARGE16.Bind(POINTSCHARGE16);
                fldPOINTS_CHARGE17.Bind(POINTSCHARGE17);
                fldPOINTS_CHARGE18.Bind(POINTSCHARGE18);
                fldPOINTS_CHARGE19.Bind(POINTSCHARGE19);
                fldPOINTS_CHARGE20.Bind(POINTSCHARGE20);
                fldPOINTS_CHARGE21.Bind(POINTSCHARGE21);
                fldPOINTS_CHARGE22.Bind(POINTSCHARGE22);
                fldPOINTS_CHARGE23.Bind(POINTSCHARGE23);
                fldPOINTS_CHARGE24.Bind(POINTSCHARGE24);
                fldPOINTS_CHARGE25.Bind(POINTSCHARGE25);
                fldPOINTS_CHARGE26.Bind(POINTSCHARGE26);
                fldPOINTS_CHARGE27.Bind(POINTSCHARGE27);
                fldPOINTS_CHARGE28.Bind(POINTSCHARGE28);
                fldPOINTS_CHARGE29.Bind(POINTSCHARGE29);
                fldPOINTS_CHARGE30.Bind(POINTSCHARGE30);
                fldPOINTS_CHARGE31.Bind(POINTSCHARGE31);
                fldPOINTS_CHARGE32.Bind(POINTSCHARGE32);
                fldPOINTS_CHARGE33.Bind(POINTSCHARGE33);
                fldPOINTS_CHARGE34.Bind(POINTSCHARGE34);
                fldPOINTS_CHARGE35.Bind(POINTSCHARGE35);
                fldPOINTS_CHARGE36.Bind(POINTSCHARGE36);
                fldPOINTS_CHARGE37.Bind(POINTSCHARGE37);
                fldPOINTS_CHARGE38.Bind(POINTSCHARGE38);
                fldPOINTS_CHARGE39.Bind(POINTSCHARGE39);
                fldPOINTS_CHARGE40.Bind(POINTSCHARGE40);
                fldPOINTS_CHARGE41.Bind(POINTSCHARGE41);
                fldPOINTS_CHARGE42.Bind(POINTSCHARGE42);
                fldPOINTS_CHARGE43.Bind(POINTSCHARGE43);
                fldPOINTS_CHARGE44.Bind(POINTSCHARGE44);
                fldPOINTS_CHARGE45.Bind(POINTSCHARGE45);
                fldPOINTS_CHARGE46.Bind(POINTSCHARGE46);
                fldPOINTS_CHARGE47.Bind(POINTSCHARGE47);
                fldPOINTS_CHARGE48.Bind(POINTSCHARGE48);
                fldPOINTS_CHARGE49.Bind(POINTSCHARGE49);
                fldPOINTS_CHARGE50.Bind(POINTSCHARGE50);
                fldPOINTS_CHARGE51.Bind(POINTSCHARGE51);
                fldPOINTS_CHARGE52.Bind(POINTSCHARGE52);
                fldPOINTS_CHARGE53.Bind(POINTSCHARGE53);
                fldUSER_CHARGE1.Bind(USERCHARGE1);
                fldUSER_CHARGE2.Bind(USERCHARGE2);
                fldUSER_CHARGE3.Bind(USERCHARGE3);
                fldUSER_CHARGE4.Bind(USERCHARGE4);
                fldUSER_CHARGE5.Bind(USERCHARGE5);
                fldUSER_CHARGE6.Bind(USERCHARGE6);
                fldUSER_CHARGE7.Bind(USERCHARGE7);
                fldUSER_CHARGE8.Bind(USERCHARGE8);
                fldUSER_CHARGE9.Bind(USERCHARGE9);
                fldUSER_CHARGE10.Bind(USERCHARGE10);
                fldUSER_CHARGE11.Bind(USERCHARGE11);
                fldUSER_CHARGE12.Bind(USERCHARGE12);
                fldUSER_CHARGE13.Bind(USERCHARGE13);
                fldUSER_CHARGE14.Bind(USERCHARGE14);
                fldUSER_CHARGE15.Bind(USERCHARGE15);
                fldUSER_CHARGE16.Bind(USERCHARGE16);
                fldUSER_CHARGE17.Bind(USERCHARGE17);
                fldUSER_CHARGE18.Bind(USERCHARGE18);
                fldUSER_CHARGE19.Bind(USERCHARGE19);
                fldUSER_CHARGE20.Bind(USERCHARGE20);
                fldUSER_CHARGE21.Bind(USERCHARGE21);
                fldUSER_CHARGE22.Bind(USERCHARGE22);
                fldUSER_CHARGE23.Bind(USERCHARGE23);
                fldUSER_CHARGE24.Bind(USERCHARGE24);
                fldUSER_CHARGE25.Bind(USERCHARGE25);
                fldUSER_CHARGE26.Bind(USERCHARGE26);
                fldUSER_CHARGE27.Bind(USERCHARGE27);
                fldUSER_CHARGE28.Bind(USERCHARGE28);
                fldUSER_CHARGE29.Bind(USERCHARGE29);
                fldUSER_CHARGE30.Bind(USERCHARGE30);
                fldUSER_CHARGE31.Bind(USERCHARGE31);
                fldUSER_CHARGE32.Bind(USERCHARGE32);
                fldUSER_CHARGE33.Bind(USERCHARGE33);
                fldUSER_CHARGE34.Bind(USERCHARGE34);
                fldUSER_CHARGE35.Bind(USERCHARGE35);
                fldUSER_CHARGE36.Bind(USERCHARGE36);
                fldUSER_CHARGE37.Bind(USERCHARGE37);
                fldUSER_CHARGE38.Bind(USERCHARGE38);
                fldUSER_CHARGE39.Bind(USERCHARGE39);
                fldUSER_CHARGE40.Bind(USERCHARGE40);
                fldUSER_CHARGE41.Bind(USERCHARGE41);
                fldUSER_CHARGE42.Bind(USERCHARGE42);
                fldUSER_CHARGE43.Bind(USERCHARGE43);
                fldUSER_CHARGE44.Bind(USERCHARGE44);
                fldUSER_CHARGE45.Bind(USERCHARGE45);
                fldUSER_CHARGE46.Bind(USERCHARGE46);
                fldUSER_CHARGE47.Bind(USERCHARGE47);
                fldUSER_CHARGE48.Bind(USERCHARGE48);
                fldUSER_CHARGE49.Bind(USERCHARGE49);
                fldUSER_CHARGE50.Bind(USERCHARGE50);
                fldUSER_CHARGE51.Bind(USERCHARGE51);
                fldUSER_CHARGE52.Bind(USERCHARGE52);
                fldUSER_CHARGE53.Bind(USERCHARGE53);

                fldT_UPDATE_DESC.Bind(T_UPDATE_DESC);
                fldT_UPDATE_NVAT.Bind(T_UPDATE_NVAT);
                fldCHARGES_USER_CHARGE_A.Bind(fleCHARGES);
                fldCHARGES_USER_CHARGE_B.Bind(fleCHARGES);
                fldCHARGES_USER_CHARGE_C.Bind(fleCHARGES);
                fldCHARGES_USER_CHARGE_D.Bind(fleCHARGES);
                fldCHARGES_USER_CHARGE_E.Bind(fleCHARGES);
                fldCHARGES_USER_CHARGE_F.Bind(fleCHARGES);
                fldCHARGES_USER_CHARGE_G.Bind(fleCHARGES);
                fldCHARGES_USER_CHARGE_H.Bind(fleCHARGES);
                fldCHARGES_USER_CHARGE_I.Bind(fleCHARGES);
                fldCHARGES_USER_CHARGE_J.Bind(fleCHARGES);
                fldCHARGES_USER_CHARGE_K.Bind(fleCHARGES);
                fldCHARGES_USER_CHARGE_L.Bind(fleCHARGES);
                fldCHARGES_USER_CHARGE_M.Bind(fleCHARGES);
                fldCHARGES_USER_CHARGE_N.Bind(fleCHARGES);
                fldCHARGES_USER_CHARGE_O.Bind(fleCHARGES);
                fldCHARGES_USER_CHARGE_P.Bind(fleCHARGES);
                fldCHARGES_USER_CHARGE_Q.Bind(fleCHARGES);
                fldCHARGES_USER_CHARGE_R.Bind(fleCHARGES);
                fldCHARGES_USER_CHARGE_S.Bind(fleCHARGES);
                fldCHARGES_USER_CHARGE_T.Bind(fleCHARGES);
                fldCHARGES_USER_CHARGE_U.Bind(fleCHARGES);
                fldCHARGES_USER_CHARGE_V.Bind(fleCHARGES);
                fldCHARGES_USER_CHARGE_W.Bind(fleCHARGES);
                fldCHARGES_USER_CHARGE_X.Bind(fleCHARGES);
                fldCHARGES_USER_CHARGE_Y.Bind(fleCHARGES);
                fldCHARGES_USER_CHARGE_Z.Bind(fleCHARGES);
                fldCHARGES_LOCATION.Bind(fleCHARGES);
                fldCHARGES_BEDS.Bind(fleCHARGES);
                fldCHARGES_PROPERTY_STYLE.Bind(fleCHARGES);
                fldCHARGES_BATHROOMS.Bind(fleCHARGES);
                fldCHARGES_YEAR.Bind(fleCHARGES);
                fldCHARGES_PBK_YEAR.Bind(fleCHARGES);
                fldCHARGES_SYNDICATED_VALUE.Bind(fleCHARGES);
                fldCHARGES_NO_OF_PROPERTIES.Bind(fleCHARGES);
                fldCHARGES_TOTAL_POINTS.Bind(fleCHARGES);
                fldCHARGES_GRAPH_TYPE.Bind(fleCHARGES);
                fldGRAPHS_GRAPH_NAME.Bind(fleGRAPHS);
                fldCHARGES_NOTIONAL_VAT.Bind(fleCHARGES);
                fldT_UPD_NEXT_CHARGE.Bind(T_UPD_NEXT_CHARGE);
                fldT_UPD_NEXT_POINTS.Bind(T_UPD_NEXT_POINTS);

            }
            catch (CustomApplicationException ex)
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



        private void fldCHARGES_GRAPH_TYPE_LookupOn()
        {

            try
            {
                StringBuilder strSQL = new StringBuilder(" WHERE ");
                strSQL.Append("     ").Append(fleGRAPHS.ElementOwner("GRAPH_TYPE")).Append(" = ").Append(Common.StringToField(FieldText));

                fleGRAPHS.GetData(strSQL.ToString(), GetDataOptions.IsOptional);
                if (!AccessOk)
                {
                    ErrorMessage("IM.RecordNotFound");
                    // Record not found on lookup table.
                }

                strSQL = new StringBuilder(" WHERE ");
                strSQL.Append("     ").Append(fleGRAPHS_DTL.ElementOwner("GRAPH_TYPE")).Append(" = ").Append(Common.StringToField(fleGRAPHS.GetStringValue("GRAPH_TYPE")));
                strSQL.Append(" AND    ").Append(fleGRAPHS_DTL.ElementOwner("GRAPH_NAME")).Append(" = ").Append(Common.StringToField(fleGRAPHS.GetStringValue("GRAPH_NAME")));

                fleGRAPHS_DTL.GetData(strSQL.ToString(), GetDataOptions.CreateRecordsForOccurs);

            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }




        private void fldCHARGES_PBK_YEAR_LookupNotOn(ref bool LookupNotOnExecuted)
        {

            try
            {
                bool blnAlreadyExists = false;
                StringBuilder strSQL = new StringBuilder("SELECT ").Append(fleCHARGES.ElementOwner("LOCATION"));
                //Parent:PBK_YEAR
                strSQL.Append(",  ").Append("  ").Append(fleCHARGES.ElementOwner("BEDS"));
                //Parent:PBK_YEAR
                strSQL.Append(",  ").Append("  ").Append(fleCHARGES.ElementOwner("PROPERTY_STYLE"));
                //Parent:PBK_YEAR
                strSQL.Append(",  ").Append("  ").Append(fleCHARGES.ElementOwner("BATHROOMS"));
                //Parent:PBK_YEAR
                strSQL.Append(",  ").Append("  ").Append(fleCHARGES.ElementOwner("YEAR"));
                //Parent:PBK_YEAR
                strSQL.Append(" FROM ");
                strSQL.Append(fleCHARGES.TableNameWithAlias());
                strSQL.Append(" WHERE ");
                strSQL.Append("     ").Append(fleCHARGES.ElementOwner("LOCATION")).Append(" = ").Append(Common.StringToField(fleCHARGES.GetStringValue("LOCATION")));
                //Parent:PBK_YEAR
                strSQL.Append(" AND ").Append("     ").Append(fleCHARGES.ElementOwner("BEDS")).Append(" = ").Append(Common.StringToField(fleCHARGES.GetStringValue("BEDS")));
                //Parent:PBK_YEAR
                strSQL.Append(" AND ").Append("     ").Append(fleCHARGES.ElementOwner("PROPERTY_STYLE")).Append(" = ").Append(Common.StringToField(fleCHARGES.GetStringValue("PROPERTY_STYLE")));
                //Parent:PBK_YEAR
                strSQL.Append(" AND ").Append("     ").Append(fleCHARGES.ElementOwner("BATHROOMS")).Append(" = ").Append(Common.StringToField(fleCHARGES.GetStringValue("BATHROOMS")));
                //Parent:PBK_YEAR
                strSQL.Append(" AND ").Append("     ").Append(fleCHARGES.ElementOwner("YEAR")).Append(" = ").Append(Common.StringToField(fleCHARGES.GetStringValue("YEAR")));
                //Parent:PBK_YEAR

                if (!LookupNotOn(strSQL, fleCHARGES, "PBK_YEAR", FieldText))
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




        private void fldCHARGES_LOCATION_LookupOn()
        {

            try
            {
                StringBuilder strSQL = new StringBuilder(" WHERE ");
                strSQL.Append("     ").Append(fleLOCATIONS.ElementOwner("LOCATION")).Append(" = ").Append(Common.StringToField(fleLOCATIONS.GetStringValue("LOCATION")));

                fleLOCATIONS.GetData(strSQL.ToString(), GetDataOptions.IsOptional);
                if (!AccessOk)
                {
                    ErrorMessage("IM.RecordNotFound");
                    // Record not found on lookup table.
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


        private void dsrDesigner_SWDISC_Click(object sender, System.EventArgs e)
        {

            try
            {

                T_PBK_YEAR.Value = fleCHARGES.GetStringValue("LOCATION") + fleCHARGES.GetStringValue("BEDS") + fleCHARGES.GetStringValue("PROPERTY_STYLE") + fleCHARGES.GetStringValue("BATHROOMS") + fleCHARGES.GetStringValue("YEAR");
                //Parent:PBK_YEAR
                //RunScreen("SWDISCNT.QKC", RunScreenModes.Find, T_PBK_YEAR);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldCHARGES_POINTS_CHARGE_Process()
        {

            try
            {

                if (QDesign.NULL(D_UK_BOND_PROP.Value) == "Y")
                {
                    T_POINTS_CHANGED.Value = "Y";
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



        private void fldCHARGES_SYNDICATED_VALUE_Process()
        {

            try
            {

                if (ChangeMode || CorrectMode)
                {
                    while (this.For(53))
                    {
                        fleCHARGES.set_SetValue("POINTS_CHARGE", D_POINTS_CHARGE.Value);
                        // TODO: POINTS_CHARGE occurs 53.  Manual steps may be required.
                        //Display(ref fldCHARGES_POINTS_CHARGE);
                    }
                    T_POINTS_CHANGED.Value = "Y";
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



        private void fldCHARGES_NO_OF_PROPERTIES_Process()
        {

            try
            {

                if (ChangeMode || CorrectMode)
                {
                    while (this.For(53))
                    {
                        fleCHARGES.set_SetValue("POINTS_CHARGE", D_POINTS_CHARGE.Value);
                        // TODO: POINTS_CHARGE occurs 53.  Manual steps may be required.
                        //Display(ref fldCHARGES_POINTS_CHARGE);
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



        private void fldCHARGES_GRAPH_TYPE_Process()
        {

            try
            {

                while (this.For(53))
                {                    
                    fleCHARGES_DTL.set_SetValue("POINTS_CHARGE", D_POINTS_CHARGE.Value);
                    // TODO: POINTS_CHARGE occurs 53.  Manual steps may be required.
                    //Display(ref fldCHARGES_POINTS_CHARGE);
                    fleCHARGES_DTL.set_SetValue("USER_CHARGE", "A");
                    // TODO: USER_CHARGE occurs 53.  Manual steps may be required.
                    if (QDesign.NULL(D_53_WEEK_YEAR.Value) != "Y" && Occurrence == 53)
                    {
                        fleCHARGES_DTL.set_SetValue("USER_CHARGE", " ");
                        // TODO: USER_CHARGE occurs 53.  Manual steps may be required.
                    }
                    //Display(ref fldCHARGES_USER_CHARGE);
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


        protected override bool Initialize()
        {


            try
            {
                object[] arrRunscreen = { T_SCREEN_NAME };
                RunScreen(new SCRNVST(), RunScreenModes.Entry, ref arrRunscreen);
                // --> GET USER_SEC_FILE <--
                fleUSER_SEC_FILE.GetData();
                // --> End GET USER_SEC_FILE <--
                if (QDesign.NULL(fleUSER_SEC_FILE.GetStringValue("USER_LEVEL")) != "01")
                {
                    Severe("52066");
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


        protected override bool Entry()
        {


            try
            {

                Accept(ref fldCHARGES_LOCATION);
                // --> GET LOC_INFO <--

                fleLOC_INFO.GetData(GetDataOptions.IsOptional);
                // --> End GET LOC_INFO <--
                if (QDesign.NULL(fleLOC_INFO.GetStringValue("TENANCY_FLAG")) == "Y")
                {
                    ErrorMessage("52067");
                }
                Accept(ref fldCHARGES_BEDS);
                Accept(ref fldCHARGES_PROPERTY_STYLE);
                Accept(ref fldCHARGES_BATHROOMS);
                Accept(ref fldCHARGES_YEAR);
                Edit(ref fldCHARGES_PBK_YEAR);

                while (fleCHARGES_DTL.ForMissing())
                {
                    fleCHARGES_DTL.GetData(GetDataOptions.CreateRecordsForOccurs | GetDataOptions.IsOptional);
                }
                Accept(ref fldCHARGES_SYNDICATED_VALUE);
                Accept(ref fldCHARGES_NO_OF_PROPERTIES);
                Accept(ref fldCHARGES_GRAPH_TYPE);
                Display(ref fldGRAPHS_GRAPH_NAME);
                while (fleCHARGES.For())
                {
                    //Accept(ref fldCHARGES_POINTS_CHARGE);
                    //Accept(ref fldCHARGES_USER_CHARGE);
                }
                Accept(ref fldCHARGES_USER_CHARGE_A);
                Accept(ref fldCHARGES_USER_CHARGE_B);
                Accept(ref fldCHARGES_USER_CHARGE_C);
                Accept(ref fldCHARGES_USER_CHARGE_D);
                Accept(ref fldCHARGES_USER_CHARGE_E);
                Accept(ref fldCHARGES_USER_CHARGE_F);
                Accept(ref fldCHARGES_USER_CHARGE_G);
                Accept(ref fldCHARGES_USER_CHARGE_H);
                Accept(ref fldCHARGES_USER_CHARGE_I);
                Accept(ref fldCHARGES_USER_CHARGE_J);
                Accept(ref fldCHARGES_USER_CHARGE_K);
                Accept(ref fldCHARGES_USER_CHARGE_L);
                Accept(ref fldCHARGES_USER_CHARGE_M);
                Accept(ref fldCHARGES_USER_CHARGE_N);
                Accept(ref fldCHARGES_USER_CHARGE_O);
                Accept(ref fldCHARGES_USER_CHARGE_P);
                Accept(ref fldCHARGES_USER_CHARGE_Q);
                Accept(ref fldCHARGES_USER_CHARGE_R);
                Accept(ref fldCHARGES_USER_CHARGE_S);
                Accept(ref fldCHARGES_USER_CHARGE_T);
                Accept(ref fldCHARGES_USER_CHARGE_U);
                Accept(ref fldCHARGES_USER_CHARGE_V);
                Accept(ref fldCHARGES_USER_CHARGE_W);
                Accept(ref fldCHARGES_USER_CHARGE_X);
                Accept(ref fldCHARGES_USER_CHARGE_Y);
                Accept(ref fldCHARGES_USER_CHARGE_Z);
                Accept(ref fldT_UPD_NEXT_CHARGE);
                Accept(ref fldT_UPD_NEXT_POINTS);

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
                m_intPath = 0;

                RequestPrompt(ref fldCHARGES_LOCATION);
                if (m_blnPromptOK)
                {
                    m_intPath = 1;
                    RequestPrompt(ref fldCHARGES_BEDS);

                    if (m_blnPromptOK)
                    {
                        m_intPath = 2;
                        RequestPrompt(ref fldCHARGES_PROPERTY_STYLE);

                        if (m_blnPromptOK)
                        {
                            m_intPath = 3;
                            RequestPrompt(ref fldCHARGES_BATHROOMS);

                            if (m_blnPromptOK)
                            {
                                m_intPath = 4;
                                RequestPrompt(ref fldCHARGES_YEAR);
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


        protected override bool Find()
        {


            try
            {

                if (m_intPath == 1)
                {
                    bool blnAddWhere = true;
                    m_strWhere = new StringBuilder(GetWhereCondition("LOCATION", fleCHARGES.GetStringValue("LOCATION"), ref blnAddWhere));
                    fleCHARGES.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);

                }
                else if (m_intPath == 2)
                {
                    bool blnAddWhere = true;
                    m_strWhere = new StringBuilder(GetWhereCondition("LOCATION", fleCHARGES.GetStringValue("LOCATION"), ref blnAddWhere));
                    m_strWhere.Append(GetWhereCondition("BEDS", fleCHARGES.GetStringValue("BEDS"), ref blnAddWhere));
                    fleCHARGES.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);

                }
                else if (m_intPath == 3)
                {
                    bool blnAddWhere = true;
                    m_strWhere = new StringBuilder(GetWhereCondition("LOCATION", fleCHARGES.GetStringValue("LOCATION"), ref blnAddWhere));
                    m_strWhere.Append(GetWhereCondition("BEDS", fleCHARGES.GetStringValue("BEDS"), ref blnAddWhere));
                    m_strWhere.Append(GetWhereCondition("PROPERTY_STYLE", fleCHARGES.GetStringValue("PROPERTY_STYLE"), ref blnAddWhere));
                    fleCHARGES.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);

                }
                else if (m_intPath == 4)
                {
                    bool blnAddWhere = true;
                    m_strWhere = new StringBuilder(GetWhereCondition("LOCATION", fleCHARGES.GetStringValue("LOCATION"), ref blnAddWhere));
                    m_strWhere.Append(GetWhereCondition("BEDS", fleCHARGES.GetStringValue("BEDS"), ref blnAddWhere));
                    m_strWhere.Append(GetWhereCondition("PROPERTY_STYLE", fleCHARGES.GetStringValue("PROPERTY_STYLE"), ref blnAddWhere));
                    m_strWhere.Append(GetWhereCondition("BATHROOMS", fleCHARGES.GetStringValue("BATHROOMS"), ref blnAddWhere));
                    fleCHARGES.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);

                }
                else if (m_intPath == 5)
                {
                    bool blnAddWhere = true;
                    m_strWhere = new StringBuilder(GetWhereCondition("LOCATION", fleCHARGES.GetStringValue("LOCATION"), ref blnAddWhere));
                    m_strWhere.Append(GetWhereCondition("BEDS", fleCHARGES.GetStringValue("BEDS"), ref blnAddWhere));
                    m_strWhere.Append(GetWhereCondition("PROPERTY_STYLE", fleCHARGES.GetStringValue("PROPERTY_STYLE"), ref blnAddWhere));
                    m_strWhere.Append(GetWhereCondition("BATHROOMS", fleCHARGES.GetStringValue("BATHROOMS"), ref blnAddWhere));
                    m_strWhere.Append(GetWhereCondition("YEAR", fleCHARGES.GetStringValue("YEAR"), ref blnAddWhere));
                    fleCHARGES.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);

                }
                if (m_intPath == 0)
                {
                    fleCHARGES.GetData(GetDataOptions.CreateSubSelect | GetDataOptions.Sequential);

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

                if (QDesign.NULL(fleLOC_INFO.GetStringValue("TENANCY_FLAG")) == "Y")
                {
                    ErrorMessage("52068");
                }
                Information("42012");

                while (fleCHARGES_DTL.ForMissing())
                {
                        fleCHARGES_DTL.GetData(GetDataOptions.CreateRecordsForOccurs | GetDataOptions.IsOptional);
                    switch (Occurrence)
                    {
                        case 1:
                            POINTSCHARGE1.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                            USERCHARGE1.Value = fleCHARGES_DTL.GetStringValue("USER_CHARGE");
                            break;
                        case 2:
                            POINTSCHARGE2.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                            USERCHARGE2.Value = fleCHARGES_DTL.GetStringValue("USER_CHARGE");
                            break;
                        case 3:
                            POINTSCHARGE3.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                            USERCHARGE3.Value = fleCHARGES_DTL.GetStringValue("USER_CHARGE");
                            break;
                        case 4:
                            POINTSCHARGE4.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                            USERCHARGE4.Value = fleCHARGES_DTL.GetStringValue("USER_CHARGE");
                            break;
                        case 5:
                            POINTSCHARGE5.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                            USERCHARGE5.Value = fleCHARGES_DTL.GetStringValue("USER_CHARGE");
                            break;
                        case 6:
                            POINTSCHARGE6.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                            USERCHARGE6.Value = fleCHARGES_DTL.GetStringValue("USER_CHARGE");
                            break;
                        case 7:
                            POINTSCHARGE7.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                            USERCHARGE7.Value = fleCHARGES_DTL.GetStringValue("USER_CHARGE");
                            break;
                        case 8:
                            POINTSCHARGE8.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                            USERCHARGE8.Value = fleCHARGES_DTL.GetStringValue("USER_CHARGE");
                            break;
                        case 9:
                            POINTSCHARGE9.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                            USERCHARGE9.Value = fleCHARGES_DTL.GetStringValue("USER_CHARGE");
                            break;
                        case 10:
                            POINTSCHARGE10.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                            USERCHARGE10.Value = fleCHARGES_DTL.GetStringValue("USER_CHARGE");
                            break;
                        case 11:
                            POINTSCHARGE11.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                            USERCHARGE11.Value = fleCHARGES_DTL.GetStringValue("USER_CHARGE");
                            break;
                        case 12:
                            POINTSCHARGE12.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                            USERCHARGE12.Value = fleCHARGES_DTL.GetStringValue("USER_CHARGE");
                            break;
                        case 13:
                            POINTSCHARGE13.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                            USERCHARGE13.Value = fleCHARGES_DTL.GetStringValue("USER_CHARGE");
                            break;
                        case 14:
                            POINTSCHARGE14.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                            USERCHARGE14.Value = fleCHARGES_DTL.GetStringValue("USER_CHARGE");
                            break;
                        case 15:
                            POINTSCHARGE15.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                            USERCHARGE15.Value = fleCHARGES_DTL.GetStringValue("USER_CHARGE");
                            break;
                        case 16:
                            POINTSCHARGE16.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                            USERCHARGE16.Value = fleCHARGES_DTL.GetStringValue("USER_CHARGE");
                            break;
                        case 17:
                            POINTSCHARGE17.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                            USERCHARGE17.Value = fleCHARGES_DTL.GetStringValue("USER_CHARGE");
                            break;
                        case 18:
                            POINTSCHARGE18.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                            USERCHARGE18.Value = fleCHARGES_DTL.GetStringValue("USER_CHARGE");
                            break;
                        case 19:
                            POINTSCHARGE19.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                            USERCHARGE19.Value = fleCHARGES_DTL.GetStringValue("USER_CHARGE");
                            break;
                        case 20:
                            POINTSCHARGE20.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                            USERCHARGE20.Value = fleCHARGES_DTL.GetStringValue("USER_CHARGE");
                            break;
                        case 21:
                            POINTSCHARGE21.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                            USERCHARGE21.Value = fleCHARGES_DTL.GetStringValue("USER_CHARGE");
                            break;
                        case 22:
                            POINTSCHARGE22.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                            USERCHARGE22.Value = fleCHARGES_DTL.GetStringValue("USER_CHARGE");
                            break;
                        case 23:
                            POINTSCHARGE23.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                            USERCHARGE23.Value = fleCHARGES_DTL.GetStringValue("USER_CHARGE");
                            break;
                        case 24:
                            POINTSCHARGE24.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                            USERCHARGE24.Value = fleCHARGES_DTL.GetStringValue("USER_CHARGE");
                            break;
                        case 25:
                            POINTSCHARGE25.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                            USERCHARGE25.Value = fleCHARGES_DTL.GetStringValue("USER_CHARGE");
                            break;
                        case 26:
                            POINTSCHARGE26.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                            USERCHARGE26.Value = fleCHARGES_DTL.GetStringValue("USER_CHARGE");
                            break;
                        case 27:
                            POINTSCHARGE27.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                            USERCHARGE27.Value = fleCHARGES_DTL.GetStringValue("USER_CHARGE");
                            break;
                        case 28:
                            POINTSCHARGE28.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                            USERCHARGE28.Value = fleCHARGES_DTL.GetStringValue("USER_CHARGE");
                            break;
                        case 29:
                            POINTSCHARGE29.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                            USERCHARGE29.Value = fleCHARGES_DTL.GetStringValue("USER_CHARGE");
                            break;
                        case 30:
                            POINTSCHARGE30.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                            USERCHARGE30.Value = fleCHARGES_DTL.GetStringValue("USER_CHARGE");
                            break;
                        case 31:
                            POINTSCHARGE31.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                            USERCHARGE31.Value = fleCHARGES_DTL.GetStringValue("USER_CHARGE");
                            break;
                        case 32:
                            POINTSCHARGE32.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                            USERCHARGE32.Value = fleCHARGES_DTL.GetStringValue("USER_CHARGE");
                            break;
                        case 33:
                            POINTSCHARGE33.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                            USERCHARGE33.Value = fleCHARGES_DTL.GetStringValue("USER_CHARGE");
                            break;
                        case 34:
                            POINTSCHARGE34.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                            USERCHARGE34.Value = fleCHARGES_DTL.GetStringValue("USER_CHARGE");
                            break;
                        case 35:
                            POINTSCHARGE35.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                            USERCHARGE35.Value = fleCHARGES_DTL.GetStringValue("USER_CHARGE");
                            break;
                        case 36:
                            POINTSCHARGE36.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                            USERCHARGE36.Value = fleCHARGES_DTL.GetStringValue("USER_CHARGE");
                            break;
                        case 37:
                            POINTSCHARGE37.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                            USERCHARGE37.Value = fleCHARGES_DTL.GetStringValue("USER_CHARGE");
                            break;
                        case 38:
                            POINTSCHARGE38.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                            USERCHARGE38.Value = fleCHARGES_DTL.GetStringValue("USER_CHARGE");
                            break;
                        case 39:
                            POINTSCHARGE39.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                            USERCHARGE39.Value = fleCHARGES_DTL.GetStringValue("USER_CHARGE");
                            break;
                        case 40:
                            POINTSCHARGE40.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                            USERCHARGE40.Value = fleCHARGES_DTL.GetStringValue("USER_CHARGE");
                            break;
                        case 41:
                            POINTSCHARGE41.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                            USERCHARGE41.Value = fleCHARGES_DTL.GetStringValue("USER_CHARGE");
                            break;
                        case 42:
                            POINTSCHARGE42.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                            USERCHARGE42.Value = fleCHARGES_DTL.GetStringValue("USER_CHARGE");
                            break;
                        case 43:
                            POINTSCHARGE43.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                            USERCHARGE43.Value = fleCHARGES_DTL.GetStringValue("USER_CHARGE");
                            break;
                        case 44:
                            POINTSCHARGE44.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                            USERCHARGE44.Value = fleCHARGES_DTL.GetStringValue("USER_CHARGE");
                            break;
                        case 45:
                            POINTSCHARGE45.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                            USERCHARGE45.Value = fleCHARGES_DTL.GetStringValue("USER_CHARGE");
                            break;
                        case 46:
                            POINTSCHARGE46.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                            USERCHARGE46.Value = fleCHARGES_DTL.GetStringValue("USER_CHARGE");
                            break;
                        case 47:
                            POINTSCHARGE47.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                            USERCHARGE47.Value = fleCHARGES_DTL.GetStringValue("USER_CHARGE");
                            break;
                        case 48:
                            POINTSCHARGE48.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                            USERCHARGE48.Value = fleCHARGES_DTL.GetStringValue("USER_CHARGE");
                            break;
                        case 49:
                            POINTSCHARGE49.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                            USERCHARGE49.Value = fleCHARGES_DTL.GetStringValue("USER_CHARGE");
                            break;
                        case 50:
                            POINTSCHARGE50.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                            USERCHARGE50.Value = fleCHARGES_DTL.GetStringValue("USER_CHARGE");
                            break;
                        case 51:
                            POINTSCHARGE51.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                            USERCHARGE51.Value = fleCHARGES_DTL.GetStringValue("USER_CHARGE");
                            break;
                        case 52:
                            POINTSCHARGE52.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                            USERCHARGE52.Value = fleCHARGES_DTL.GetStringValue("USER_CHARGE");
                            break;
                        case 53:
                            POINTSCHARGE53.Value = fleCHARGES_DTL.GetDecimalValue("POINTS_CHARGE");
                            USERCHARGE53.Value = fleCHARGES_DTL.GetStringValue("USER_CHARGE");
                            break;
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


        private bool Internal_CHARGES2_CHARGES()
        {


            try
            {

                fleCHARGES2.set_SetValue("USER_CHARGE_A", fleCHARGES.GetDecimalValue("USER_CHARGE_A"));
                fleCHARGES2.set_SetValue("USER_CHARGE_B", fleCHARGES.GetDecimalValue("USER_CHARGE_B"));
                fleCHARGES2.set_SetValue("USER_CHARGE_C", fleCHARGES.GetDecimalValue("USER_CHARGE_C"));
                fleCHARGES2.set_SetValue("USER_CHARGE_D", fleCHARGES.GetDecimalValue("USER_CHARGE_D"));
                fleCHARGES2.set_SetValue("USER_CHARGE_E", fleCHARGES.GetDecimalValue("USER_CHARGE_E"));
                fleCHARGES2.set_SetValue("USER_CHARGE_F", fleCHARGES.GetDecimalValue("USER_CHARGE_F"));
                fleCHARGES2.set_SetValue("USER_CHARGE_G", fleCHARGES.GetDecimalValue("USER_CHARGE_G"));
                fleCHARGES2.set_SetValue("USER_CHARGE_H", fleCHARGES.GetDecimalValue("USER_CHARGE_H"));
                fleCHARGES2.set_SetValue("USER_CHARGE_I", fleCHARGES.GetDecimalValue("USER_CHARGE_I"));
                fleCHARGES2.set_SetValue("USER_CHARGE_J", fleCHARGES.GetDecimalValue("USER_CHARGE_J"));
                fleCHARGES2.set_SetValue("USER_CHARGE_K", fleCHARGES.GetDecimalValue("USER_CHARGE_K"));
                fleCHARGES2.set_SetValue("USER_CHARGE_L", fleCHARGES.GetDecimalValue("USER_CHARGE_L"));
                fleCHARGES2.set_SetValue("USER_CHARGE_M", fleCHARGES.GetDecimalValue("USER_CHARGE_M"));
                fleCHARGES2.set_SetValue("USER_CHARGE_N", fleCHARGES.GetDecimalValue("USER_CHARGE_N"));
                fleCHARGES2.set_SetValue("USER_CHARGE_O", fleCHARGES.GetDecimalValue("USER_CHARGE_O"));
                fleCHARGES2.set_SetValue("USER_CHARGE_P", fleCHARGES.GetDecimalValue("USER_CHARGE_P"));
                fleCHARGES2.set_SetValue("USER_CHARGE_Q", fleCHARGES.GetDecimalValue("USER_CHARGE_Q"));
                fleCHARGES2.set_SetValue("USER_CHARGE_R", fleCHARGES.GetDecimalValue("USER_CHARGE_R"));
                fleCHARGES2.set_SetValue("USER_CHARGE_S", fleCHARGES.GetDecimalValue("USER_CHARGE_S"));
                fleCHARGES2.set_SetValue("USER_CHARGE_T", fleCHARGES.GetDecimalValue("USER_CHARGE_T"));
                fleCHARGES2.set_SetValue("USER_CHARGE_U", fleCHARGES.GetDecimalValue("USER_CHARGE_U"));
                fleCHARGES2.set_SetValue("USER_CHARGE_V", fleCHARGES.GetDecimalValue("USER_CHARGE_V"));
                fleCHARGES2.set_SetValue("USER_CHARGE_W", fleCHARGES.GetDecimalValue("USER_CHARGE_W"));
                fleCHARGES2.set_SetValue("USER_CHARGE_X", fleCHARGES.GetDecimalValue("USER_CHARGE_X"));
                fleCHARGES2.set_SetValue("USER_CHARGE_Y", fleCHARGES.GetDecimalValue("USER_CHARGE_Y"));
                fleCHARGES2.set_SetValue("USER_CHARGE_Z", fleCHARGES.GetDecimalValue("USER_CHARGE_Z"));

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


        private bool Internal_CHARGES3_CHARGES()
        {


            try
            {

                fleCHARGES3.set_SetValue("USER_CHARGE_A", fleCHARGES.GetDecimalValue("USER_CHARGE_A"));
                fleCHARGES3.set_SetValue("USER_CHARGE_B", fleCHARGES.GetDecimalValue("USER_CHARGE_B"));
                fleCHARGES3.set_SetValue("USER_CHARGE_C", fleCHARGES.GetDecimalValue("USER_CHARGE_C"));
                fleCHARGES3.set_SetValue("USER_CHARGE_D", fleCHARGES.GetDecimalValue("USER_CHARGE_D"));
                fleCHARGES3.set_SetValue("USER_CHARGE_E", fleCHARGES.GetDecimalValue("USER_CHARGE_E"));
                fleCHARGES3.set_SetValue("USER_CHARGE_F", fleCHARGES.GetDecimalValue("USER_CHARGE_F"));
                fleCHARGES3.set_SetValue("USER_CHARGE_G", fleCHARGES.GetDecimalValue("USER_CHARGE_G"));
                fleCHARGES3.set_SetValue("USER_CHARGE_H", fleCHARGES.GetDecimalValue("USER_CHARGE_H"));
                fleCHARGES3.set_SetValue("USER_CHARGE_I", fleCHARGES.GetDecimalValue("USER_CHARGE_I"));
                fleCHARGES3.set_SetValue("USER_CHARGE_J", fleCHARGES.GetDecimalValue("USER_CHARGE_J"));
                fleCHARGES3.set_SetValue("USER_CHARGE_K", fleCHARGES.GetDecimalValue("USER_CHARGE_K"));
                fleCHARGES3.set_SetValue("USER_CHARGE_L", fleCHARGES.GetDecimalValue("USER_CHARGE_L"));
                fleCHARGES3.set_SetValue("USER_CHARGE_M", fleCHARGES.GetDecimalValue("USER_CHARGE_M"));
                fleCHARGES3.set_SetValue("USER_CHARGE_N", fleCHARGES.GetDecimalValue("USER_CHARGE_N"));
                fleCHARGES3.set_SetValue("USER_CHARGE_O", fleCHARGES.GetDecimalValue("USER_CHARGE_O"));
                fleCHARGES3.set_SetValue("USER_CHARGE_P", fleCHARGES.GetDecimalValue("USER_CHARGE_P"));
                fleCHARGES3.set_SetValue("USER_CHARGE_Q", fleCHARGES.GetDecimalValue("USER_CHARGE_Q"));
                fleCHARGES3.set_SetValue("USER_CHARGE_R", fleCHARGES.GetDecimalValue("USER_CHARGE_R"));
                fleCHARGES3.set_SetValue("USER_CHARGE_S", fleCHARGES.GetDecimalValue("USER_CHARGE_S"));
                fleCHARGES3.set_SetValue("USER_CHARGE_T", fleCHARGES.GetDecimalValue("USER_CHARGE_T"));
                fleCHARGES3.set_SetValue("USER_CHARGE_U", fleCHARGES.GetDecimalValue("USER_CHARGE_U"));
                fleCHARGES3.set_SetValue("USER_CHARGE_V", fleCHARGES.GetDecimalValue("USER_CHARGE_V"));
                fleCHARGES3.set_SetValue("USER_CHARGE_W", fleCHARGES.GetDecimalValue("USER_CHARGE_W"));
                fleCHARGES3.set_SetValue("USER_CHARGE_X", fleCHARGES.GetDecimalValue("USER_CHARGE_X"));
                fleCHARGES3.set_SetValue("USER_CHARGE_Y", fleCHARGES.GetDecimalValue("USER_CHARGE_Y"));
                fleCHARGES3.set_SetValue("USER_CHARGE_Z", fleCHARGES.GetDecimalValue("USER_CHARGE_Z"));

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


        private bool Internal_CHARGES2_POINTS()
        {


            try
            {

                while (fleCHARGES.For())
                {
                    fleCHARGES2.set_SetValue("POINTS_CHARGE", fleCHARGES.GetDecimalValue("POINTS_CHARGE"));
                    // TODO: POINTS_CHARGE occurs 53.  Manual steps may be required.' TODO: POINTS_CHARGE occurs 53.  Manual steps may be required.
                }
                while (fleCHARGES.For())
                {
                    fleCHARGES2.set_SetValue("USER_CHARGE", fleCHARGES.GetStringValue("USER_CHARGE"));
                    // TODO: USER_CHARGE occurs 53.  Manual steps may be required.' TODO: USER_CHARGE occurs 53.  Manual steps may be required.
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


        private bool Internal_CHARGES3_POINTS()
        {


            try
            {

                while (fleCHARGES.For())
                {
                    fleCHARGES3.set_SetValue("POINTS_CHARGE", fleCHARGES.GetDecimalValue("POINTS_CHARGE"));
                    // TODO: POINTS_CHARGE occurs 53.  Manual steps may be required.' TODO: POINTS_CHARGE occurs 53.  Manual steps may be required.
                }
                while (fleCHARGES.For())
                {
                    fleCHARGES3.set_SetValue("USER_CHARGE", fleCHARGES.GetStringValue("USER_CHARGE"));
                    // TODO: USER_CHARGE occurs 53.  Manual steps may be required.' TODO: USER_CHARGE occurs 53.  Manual steps may be required.
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

                if (QDesign.NULL(UserID) != "nick" && QDesign.NULL(UserID) != "rob" && QDesign.NULL(UserID) != "martin" && QDesign.NULL(UserID) != "ingrid" && QDesign.NULL(UserID) != "philip" && QDesign.NULL(UserID) != "pippa" && QDesign.NULL(UserID) != "manager" && QDesign.NULL(UserID) != "rudi")
                {
                    Severe("52069");
                }
                if (QDesign.NULL(T_POINTS_CHANGED.Value) == "Y" && QDesign.NULL(D_UK_BOND_PROP.Value) == "Y")
                {
                    Information("THE TOTAL POINTS && NOTIONAL VAT ARE NOT RECALCULATED BY THIS SCREEN" + " - CONTACT IT");
                    // TODO: May need to fix manually
                }
                if (QDesign.NULL(T_UPD_NEXT_POINTS.Value) == "Y" || QDesign.NULL(T_UPD_NEXT_CHARGE.Value) == "Y")
                {
                    // --> GET CHARGES2 <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleCHARGES2.ElementOwner("LOCATION")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleCHARGES.GetStringValue("LOCATION")));
                    //Parent:PBK_YEAR
                    m_strWhere.Append(" AND ").Append(" ").Append(fleCHARGES2.ElementOwner("BEDS")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleCHARGES.GetStringValue("BEDS")));
                    //Parent:PBK_YEAR
                    m_strWhere.Append(" AND ").Append(" ").Append(fleCHARGES2.ElementOwner("PROPERTY_STYLE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleCHARGES.GetStringValue("PROPERTY_STYLE")));
                    //Parent:PBK_YEAR
                    m_strWhere.Append(" AND ").Append(" ").Append(fleCHARGES2.ElementOwner("BATHROOMS")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleCHARGES.GetStringValue("BATHROOMS")));
                    //Parent:PBK_YEAR
                    m_strWhere.Append(" AND ").Append(" ").Append(fleCHARGES2.ElementOwner("YEAR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleCHARGES.GetStringValue("YEAR")));
                    //Parent:PBK_YEAR

                    fleCHARGES2.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET CHARGES2 <--
                    if (!AccessOk)
                    {
                        fleCHARGES2.set_SetValue("LOCATION", fleCHARGES.GetStringValue("LOCATION"));
                        fleCHARGES2.set_SetValue("BEDS", fleCHARGES.GetStringValue("BEDS"));
                        fleCHARGES2.set_SetValue("PROPERTY_STYLE", fleCHARGES.GetStringValue("PROPERTY_STYLE"));
                        fleCHARGES2.set_SetValue("BATHROOMS", fleCHARGES.GetStringValue("BATHROOMS"));
                        fleCHARGES2.set_SetValue("YEAR", QDesign.ASCII(QDesign.NConvert(fleCHARGES.GetStringValue("YEAR")) + 1, 4));
                        fleCHARGES2.set_SetValue("PROPERTY_BK_KEY", fleCHARGES.GetStringValue("PROPERTY_BK_KEY"));
                        fleCHARGES2.set_SetValue("LOC_KEY", fleCHARGES.GetStringValue("LOC_KEY"));
                        fleCHARGES2.set_SetValue("SYNDICATED_VALUE", fleCHARGES.GetDecimalValue("SYNDICATED_VALUE"));
                        fleCHARGES2.set_SetValue("NO_OF_PROPERTIES", fleCHARGES.GetDecimalValue("NO_OF_PROPERTIES"));
                        fleCHARGES2.set_SetValue("GRAPH_TYPE", fleCHARGES.GetStringValue("GRAPH_TYPE"));
                        fleCHARGES2.set_SetValue("OCCUPANCY_%", fleCHARGES.GetDecimalValue("OCCUPANCY_%"));
                        fleCHARGES2.set_SetValue("SPARE_8", fleCHARGES.GetStringValue("SPARE_8"));
                        if (QDesign.NULL(T_UPD_NEXT_CHARGE.Value) == "N")
                        {
                            Internal_CHARGES2_CHARGES();
                        }
                        if (QDesign.NULL(T_UPD_NEXT_POINTS.Value) == "N")
                        {
                            Internal_CHARGES2_POINTS();
                        }
                    }
                    // --> GET CHARGES3 <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleCHARGES3.ElementOwner("LOCATION")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleCHARGES.GetStringValue("LOCATION")));
                    //Parent:PBK_YEAR
                    m_strWhere.Append(" AND ").Append(" ").Append(fleCHARGES3.ElementOwner("BEDS")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleCHARGES.GetStringValue("BEDS")));
                    //Parent:PBK_YEAR
                    m_strWhere.Append(" AND ").Append(" ").Append(fleCHARGES3.ElementOwner("PROPERTY_STYLE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleCHARGES.GetStringValue("PROPERTY_STYLE")));
                    //Parent:PBK_YEAR
                    m_strWhere.Append(" AND ").Append(" ").Append(fleCHARGES3.ElementOwner("BATHROOMS")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleCHARGES.GetStringValue("BATHROOMS")));
                    //Parent:PBK_YEAR
                    m_strWhere.Append(" AND ").Append(" ").Append(fleCHARGES3.ElementOwner("YEAR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleCHARGES.GetStringValue("YEAR")));
                    //Parent:PBK_YEAR

                    fleCHARGES3.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET CHARGES3 <--
                    if (!AccessOk)
                    {
                        fleCHARGES3.set_SetValue("LOCATION", fleCHARGES.GetStringValue("LOCATION"));
                        fleCHARGES3.set_SetValue("BEDS", fleCHARGES.GetStringValue("BEDS"));
                        fleCHARGES3.set_SetValue("PROPERTY_STYLE", fleCHARGES.GetStringValue("PROPERTY_STYLE"));
                        fleCHARGES3.set_SetValue("BATHROOMS", fleCHARGES.GetStringValue("BATHROOMS"));
                        fleCHARGES3.set_SetValue("YEAR", QDesign.ASCII(QDesign.NConvert(fleCHARGES.GetStringValue("YEAR")) + 2, 4));
                        fleCHARGES3.set_SetValue("PROPERTY_BK_KEY", fleCHARGES.GetStringValue("PROPERTY_BK_KEY"));
                        fleCHARGES3.set_SetValue("LOC_KEY", fleCHARGES.GetStringValue("LOC_KEY"));
                        fleCHARGES3.set_SetValue("SYNDICATED_VALUE", fleCHARGES.GetDecimalValue("SYNDICATED_VALUE"));
                        fleCHARGES3.set_SetValue("NO_OF_PROPERTIES", fleCHARGES.GetDecimalValue("NO_OF_PROPERTIES"));
                        fleCHARGES3.set_SetValue("GRAPH_TYPE", fleCHARGES.GetStringValue("GRAPH_TYPE"));
                        fleCHARGES3.set_SetValue("OCCUPANCY_%", fleCHARGES.GetDecimalValue("OCCUPANCY_%"));
                        fleCHARGES3.set_SetValue("SPARE_8", fleCHARGES.GetStringValue("SPARE_8"));
                        if (QDesign.NULL(T_UPD_NEXT_CHARGE.Value) == "N")
                        {
                            Internal_CHARGES3_CHARGES();
                        }
                        if (QDesign.NULL(T_UPD_NEXT_POINTS.Value) == "N")
                        {
                            Internal_CHARGES3_POINTS();
                        }
                    }
                }
                if (QDesign.NULL(T_UPD_NEXT_POINTS.Value) == "Y")
                {
                    Internal_CHARGES2_POINTS();
                    fleCHARGES2.set_SetValue("SYNDICATED_VALUE", fleCHARGES.GetDecimalValue("SYNDICATED_VALUE"));
                    Internal_CHARGES3_POINTS();
                    fleCHARGES3.set_SetValue("SYNDICATED_VALUE", fleCHARGES.GetDecimalValue("SYNDICATED_VALUE"));
                }
                if (QDesign.NULL(T_UPD_NEXT_CHARGE.Value) == "Y")
                {
                    Internal_CHARGES2_CHARGES();
                    Internal_CHARGES3_CHARGES();
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

                if (QDesign.NULL(T_UPD_NEXT_POINTS.Value) == "Y" || QDesign.NULL(T_UPD_NEXT_CHARGE.Value) == "Y")
                {
                    fleCHARGES2.PutData();
                    fleCHARGES3.PutData();
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
                Page.PageTitle = "Charge Maintenance";



            }
            catch (CustomApplicationException ex)
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
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 07/12/2013 1:48:10 PM
        //#-----------------------------------------
        protected override bool Update()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:48:10 PM
                fleCHARGES.PutData(false, PutTypes.New);
                fleCHARGES.PutData();
                //#END STANDARD PROCEDURE CONTENT


                while (this.For(53))
                {
                    fleCHARGES_DTL.set_SetValue("WEEK", Occurrence);
                    switch (Occurrence)
                    {
                        case 1:
                            fleCHARGES_DTL.set_SetValue("POINTS_CHARGE", POINTSCHARGE1.Value);
                            fleCHARGES_DTL.set_SetValue("USER_CHARGE", USERCHARGE1.Value);
                            break;
                        case 2:
                            fleCHARGES_DTL.set_SetValue("POINTS_CHARGE", POINTSCHARGE2.Value);
                            fleCHARGES_DTL.set_SetValue("USER_CHARGE", USERCHARGE2.Value);
                            break;
                        case 3:
                            fleCHARGES_DTL.set_SetValue("POINTS_CHARGE", POINTSCHARGE3.Value);
                            fleCHARGES_DTL.set_SetValue("USER_CHARGE", USERCHARGE3.Value);
                            break;
                        case 4:
                            fleCHARGES_DTL.set_SetValue("POINTS_CHARGE", POINTSCHARGE4.Value);
                            fleCHARGES_DTL.set_SetValue("USER_CHARGE", USERCHARGE4.Value);
                            break;
                        case 5:
                            fleCHARGES_DTL.set_SetValue("POINTS_CHARGE", POINTSCHARGE5.Value);
                            fleCHARGES_DTL.set_SetValue("USER_CHARGE", USERCHARGE5.Value);
                            break;
                        case 6:
                            fleCHARGES_DTL.set_SetValue("POINTS_CHARGE", POINTSCHARGE6.Value);
                            fleCHARGES_DTL.set_SetValue("USER_CHARGE", USERCHARGE6.Value);
                            break;
                        case 7:
                            fleCHARGES_DTL.set_SetValue("POINTS_CHARGE", POINTSCHARGE7.Value);
                            fleCHARGES_DTL.set_SetValue("USER_CHARGE", USERCHARGE7.Value);
                            break;
                        case 8:
                            fleCHARGES_DTL.set_SetValue("POINTS_CHARGE", POINTSCHARGE8.Value);
                            fleCHARGES_DTL.set_SetValue("USER_CHARGE", USERCHARGE8.Value);
                            break;
                        case 9:
                            fleCHARGES_DTL.set_SetValue("POINTS_CHARGE", POINTSCHARGE9.Value);
                            fleCHARGES_DTL.set_SetValue("USER_CHARGE", USERCHARGE9.Value);
                            break;
                        case 10:
                            fleCHARGES_DTL.set_SetValue("POINTS_CHARGE", POINTSCHARGE10.Value);
                            fleCHARGES_DTL.set_SetValue("USER_CHARGE", USERCHARGE10.Value);
                            break;
                        case 11:
                            fleCHARGES_DTL.set_SetValue("POINTS_CHARGE", POINTSCHARGE11.Value);
                            fleCHARGES_DTL.set_SetValue("USER_CHARGE", USERCHARGE11.Value);
                            break;
                        case 12:
                            fleCHARGES_DTL.set_SetValue("POINTS_CHARGE", POINTSCHARGE12.Value);
                            fleCHARGES_DTL.set_SetValue("USER_CHARGE", USERCHARGE12.Value);
                            break;
                        case 13:
                            fleCHARGES_DTL.set_SetValue("POINTS_CHARGE", POINTSCHARGE13.Value);
                            fleCHARGES_DTL.set_SetValue("USER_CHARGE", USERCHARGE13.Value);
                            break;
                        case 14:
                            fleCHARGES_DTL.set_SetValue("POINTS_CHARGE", POINTSCHARGE14.Value);
                            fleCHARGES_DTL.set_SetValue("USER_CHARGE", USERCHARGE14.Value);
                            break;
                        case 15:
                            fleCHARGES_DTL.set_SetValue("POINTS_CHARGE", POINTSCHARGE15.Value);
                            fleCHARGES_DTL.set_SetValue("USER_CHARGE", USERCHARGE15.Value);
                            break;
                        case 16:
                            fleCHARGES_DTL.set_SetValue("POINTS_CHARGE", POINTSCHARGE16.Value);
                            fleCHARGES_DTL.set_SetValue("USER_CHARGE", USERCHARGE16.Value);
                            break;
                        case 17:
                            fleCHARGES_DTL.set_SetValue("POINTS_CHARGE", POINTSCHARGE17.Value);
                            fleCHARGES_DTL.set_SetValue("USER_CHARGE", USERCHARGE17.Value);
                            break;
                        case 18:
                            fleCHARGES_DTL.set_SetValue("POINTS_CHARGE", POINTSCHARGE18.Value);
                            fleCHARGES_DTL.set_SetValue("USER_CHARGE", USERCHARGE18.Value);
                            break;
                        case 19:
                            fleCHARGES_DTL.set_SetValue("POINTS_CHARGE", POINTSCHARGE19.Value);
                            fleCHARGES_DTL.set_SetValue("USER_CHARGE", USERCHARGE19.Value);
                            break;
                        case 20:
                            fleCHARGES_DTL.set_SetValue("POINTS_CHARGE", POINTSCHARGE20.Value);
                            fleCHARGES_DTL.set_SetValue("USER_CHARGE", USERCHARGE20.Value);
                            break;
                        case 21:
                            fleCHARGES_DTL.set_SetValue("POINTS_CHARGE", POINTSCHARGE21.Value);
                            fleCHARGES_DTL.set_SetValue("USER_CHARGE", USERCHARGE21.Value);
                            break;
                        case 22:
                            fleCHARGES_DTL.set_SetValue("POINTS_CHARGE", POINTSCHARGE22.Value);
                            fleCHARGES_DTL.set_SetValue("USER_CHARGE", USERCHARGE22.Value);
                            break;
                        case 23:
                            fleCHARGES_DTL.set_SetValue("POINTS_CHARGE", POINTSCHARGE23.Value);
                            fleCHARGES_DTL.set_SetValue("USER_CHARGE", USERCHARGE23.Value);
                            break;
                        case 24:
                            fleCHARGES_DTL.set_SetValue("POINTS_CHARGE", POINTSCHARGE24.Value);
                            fleCHARGES_DTL.set_SetValue("USER_CHARGE", USERCHARGE24.Value);
                            break;
                        case 25:
                            fleCHARGES_DTL.set_SetValue("POINTS_CHARGE", POINTSCHARGE25.Value);
                            fleCHARGES_DTL.set_SetValue("USER_CHARGE", USERCHARGE25.Value);
                            break;
                        case 26:
                            fleCHARGES_DTL.set_SetValue("POINTS_CHARGE", POINTSCHARGE26.Value);
                            fleCHARGES_DTL.set_SetValue("USER_CHARGE", USERCHARGE26.Value);
                            break;
                        case 27:
                            fleCHARGES_DTL.set_SetValue("POINTS_CHARGE", POINTSCHARGE27.Value);
                            fleCHARGES_DTL.set_SetValue("USER_CHARGE", USERCHARGE27.Value);
                            break;
                        case 28:
                            fleCHARGES_DTL.set_SetValue("POINTS_CHARGE", POINTSCHARGE28.Value);
                            fleCHARGES_DTL.set_SetValue("USER_CHARGE", USERCHARGE28.Value);
                            break;
                        case 29:
                            fleCHARGES_DTL.set_SetValue("POINTS_CHARGE", POINTSCHARGE29.Value);
                            fleCHARGES_DTL.set_SetValue("USER_CHARGE", USERCHARGE29.Value);
                            break;
                        case 30:
                            fleCHARGES_DTL.set_SetValue("POINTS_CHARGE", POINTSCHARGE30.Value);
                            fleCHARGES_DTL.set_SetValue("USER_CHARGE", USERCHARGE30.Value);
                            break;
                        case 31:
                            fleCHARGES_DTL.set_SetValue("POINTS_CHARGE", POINTSCHARGE31.Value);
                            fleCHARGES_DTL.set_SetValue("USER_CHARGE", USERCHARGE31.Value);
                            break;
                        case 32:
                            fleCHARGES_DTL.set_SetValue("POINTS_CHARGE", POINTSCHARGE32.Value);
                            fleCHARGES_DTL.set_SetValue("USER_CHARGE", USERCHARGE32.Value);
                            break;
                        case 33:
                            fleCHARGES_DTL.set_SetValue("POINTS_CHARGE", POINTSCHARGE33.Value);
                            fleCHARGES_DTL.set_SetValue("USER_CHARGE", USERCHARGE33.Value);
                            break;
                        case 34:
                            fleCHARGES_DTL.set_SetValue("POINTS_CHARGE", POINTSCHARGE34.Value);
                            fleCHARGES_DTL.set_SetValue("USER_CHARGE", USERCHARGE34.Value);
                            break;
                        case 35:
                            fleCHARGES_DTL.set_SetValue("POINTS_CHARGE", POINTSCHARGE35.Value);
                            fleCHARGES_DTL.set_SetValue("USER_CHARGE", USERCHARGE35.Value);
                            break;
                        case 36:
                            fleCHARGES_DTL.set_SetValue("POINTS_CHARGE", POINTSCHARGE36.Value);
                            fleCHARGES_DTL.set_SetValue("USER_CHARGE", USERCHARGE36.Value);
                            break;
                        case 37:
                            fleCHARGES_DTL.set_SetValue("POINTS_CHARGE", POINTSCHARGE37.Value);
                            fleCHARGES_DTL.set_SetValue("USER_CHARGE", USERCHARGE37.Value);
                            break;
                        case 38:
                            fleCHARGES_DTL.set_SetValue("POINTS_CHARGE", POINTSCHARGE38.Value);
                            fleCHARGES_DTL.set_SetValue("USER_CHARGE", USERCHARGE38.Value);
                            break;
                        case 39:
                            fleCHARGES_DTL.set_SetValue("POINTS_CHARGE", POINTSCHARGE39.Value);
                            fleCHARGES_DTL.set_SetValue("USER_CHARGE", USERCHARGE39.Value);
                            break;
                        case 40:
                            fleCHARGES_DTL.set_SetValue("POINTS_CHARGE", POINTSCHARGE40.Value);
                            fleCHARGES_DTL.set_SetValue("USER_CHARGE", USERCHARGE40.Value);
                            break;
                        case 41:
                            fleCHARGES_DTL.set_SetValue("POINTS_CHARGE", POINTSCHARGE41.Value);
                            fleCHARGES_DTL.set_SetValue("USER_CHARGE", USERCHARGE41.Value);
                            break;
                        case 42:
                            fleCHARGES_DTL.set_SetValue("POINTS_CHARGE", POINTSCHARGE42.Value);
                            fleCHARGES_DTL.set_SetValue("USER_CHARGE", USERCHARGE42.Value);
                            break;
                        case 43:
                            fleCHARGES_DTL.set_SetValue("POINTS_CHARGE", POINTSCHARGE43.Value);
                            fleCHARGES_DTL.set_SetValue("USER_CHARGE", USERCHARGE43.Value);
                            break;
                        case 44:
                            fleCHARGES_DTL.set_SetValue("POINTS_CHARGE", POINTSCHARGE44.Value);
                            fleCHARGES_DTL.set_SetValue("USER_CHARGE", USERCHARGE44.Value);
                            break;
                        case 45:
                            fleCHARGES_DTL.set_SetValue("POINTS_CHARGE", POINTSCHARGE45.Value);
                            fleCHARGES_DTL.set_SetValue("USER_CHARGE", USERCHARGE45.Value);
                            break;
                        case 46:
                            fleCHARGES_DTL.set_SetValue("POINTS_CHARGE", POINTSCHARGE46.Value);
                            fleCHARGES_DTL.set_SetValue("USER_CHARGE", USERCHARGE46.Value);
                            break;
                        case 47:
                            fleCHARGES_DTL.set_SetValue("POINTS_CHARGE", POINTSCHARGE47.Value);
                            fleCHARGES_DTL.set_SetValue("USER_CHARGE", USERCHARGE47.Value);
                            break;
                        case 48:
                            fleCHARGES_DTL.set_SetValue("POINTS_CHARGE", POINTSCHARGE48.Value);
                            fleCHARGES_DTL.set_SetValue("USER_CHARGE", USERCHARGE48.Value);
                            break;
                        case 49:
                            fleCHARGES_DTL.set_SetValue("POINTS_CHARGE", POINTSCHARGE49.Value);
                            fleCHARGES_DTL.set_SetValue("USER_CHARGE", USERCHARGE49.Value);
                            break;
                        case 50:
                            fleCHARGES_DTL.set_SetValue("POINTS_CHARGE", POINTSCHARGE50.Value);
                            fleCHARGES_DTL.set_SetValue("USER_CHARGE", USERCHARGE50.Value);
                            break;
                        case 51:
                            fleCHARGES_DTL.set_SetValue("POINTS_CHARGE", POINTSCHARGE51.Value);
                            fleCHARGES_DTL.set_SetValue("USER_CHARGE", USERCHARGE51.Value);
                            break;
                        case 52:
                            fleCHARGES_DTL.set_SetValue("POINTS_CHARGE", POINTSCHARGE52.Value);
                            fleCHARGES_DTL.set_SetValue("USER_CHARGE", USERCHARGE52.Value);
                            break;
                        case 53:
                            fleCHARGES_DTL.set_SetValue("POINTS_CHARGE", POINTSCHARGE53.Value);
                            fleCHARGES_DTL.set_SetValue("USER_CHARGE", USERCHARGE53.Value);
                            break;
                    }

                    fleCHARGES_DTL.PutData();
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

        //#-----------------------------------------
        //# Delete Procedure
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 07/12/2013 1:48:10 PM
        //#-----------------------------------------
        protected override bool Delete()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:48:10 PM
                fleCHARGES.DeletedRecord = true;
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
        //# dsrDesigner_93_Click Procedure
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 07/12/2013 1:48:10 PM
        //#-----------------------------------------
        private void dsrDesigner_93_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:48:10 PM
                Accept(ref fldT_UPD_NEXT_CHARGE);
                Accept(ref fldT_UPD_NEXT_POINTS);
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
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 07/12/2013 1:48:10 PM
        //#-----------------------------------------
        private void dsrDesigner_01_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:48:10 PM
                Accept(ref fldPOINTS_CHARGE1); Accept(ref fldUSER_CHARGE1);
                Accept(ref fldPOINTS_CHARGE2); Accept(ref fldUSER_CHARGE2);
                Accept(ref fldPOINTS_CHARGE3); Accept(ref fldUSER_CHARGE3);
                Accept(ref fldPOINTS_CHARGE4); Accept(ref fldUSER_CHARGE4);
                Accept(ref fldPOINTS_CHARGE5); Accept(ref fldUSER_CHARGE5);
                Accept(ref fldPOINTS_CHARGE6); Accept(ref fldUSER_CHARGE6);
                Accept(ref fldPOINTS_CHARGE7); Accept(ref fldUSER_CHARGE7);
                Accept(ref fldPOINTS_CHARGE8); Accept(ref fldUSER_CHARGE8);
                Accept(ref fldPOINTS_CHARGE9); Accept(ref fldUSER_CHARGE9);
                Accept(ref fldPOINTS_CHARGE10); Accept(ref fldUSER_CHARGE10);
                Accept(ref fldPOINTS_CHARGE11); Accept(ref fldUSER_CHARGE11);
                Accept(ref fldPOINTS_CHARGE12); Accept(ref fldUSER_CHARGE12);
                Accept(ref fldPOINTS_CHARGE13); Accept(ref fldUSER_CHARGE13);
                Accept(ref fldPOINTS_CHARGE14); Accept(ref fldUSER_CHARGE14);
                Accept(ref fldPOINTS_CHARGE15); Accept(ref fldUSER_CHARGE15);
                Accept(ref fldPOINTS_CHARGE16); Accept(ref fldUSER_CHARGE16);
                Accept(ref fldPOINTS_CHARGE17); Accept(ref fldUSER_CHARGE17);
                Accept(ref fldPOINTS_CHARGE18); Accept(ref fldUSER_CHARGE18);
                Accept(ref fldPOINTS_CHARGE19); Accept(ref fldUSER_CHARGE19);
                Accept(ref fldPOINTS_CHARGE20); Accept(ref fldUSER_CHARGE20);
                Accept(ref fldPOINTS_CHARGE21); Accept(ref fldUSER_CHARGE21);
                Accept(ref fldPOINTS_CHARGE22); Accept(ref fldUSER_CHARGE22);
                Accept(ref fldPOINTS_CHARGE23); Accept(ref fldUSER_CHARGE23);
                Accept(ref fldPOINTS_CHARGE24); Accept(ref fldUSER_CHARGE24);
                Accept(ref fldPOINTS_CHARGE25); Accept(ref fldUSER_CHARGE25);
                Accept(ref fldPOINTS_CHARGE26); Accept(ref fldUSER_CHARGE26);
                Accept(ref fldPOINTS_CHARGE27); Accept(ref fldUSER_CHARGE27);
                Accept(ref fldPOINTS_CHARGE28); Accept(ref fldUSER_CHARGE28);
                Accept(ref fldPOINTS_CHARGE29); Accept(ref fldUSER_CHARGE29);
                Accept(ref fldPOINTS_CHARGE30); Accept(ref fldUSER_CHARGE30);
                Accept(ref fldPOINTS_CHARGE31); Accept(ref fldUSER_CHARGE31);
                Accept(ref fldPOINTS_CHARGE32); Accept(ref fldUSER_CHARGE32);
                Accept(ref fldPOINTS_CHARGE33); Accept(ref fldUSER_CHARGE33);
                Accept(ref fldPOINTS_CHARGE34); Accept(ref fldUSER_CHARGE34);
                Accept(ref fldPOINTS_CHARGE35); Accept(ref fldUSER_CHARGE35);
                Accept(ref fldPOINTS_CHARGE36); Accept(ref fldUSER_CHARGE36);
                Accept(ref fldPOINTS_CHARGE37); Accept(ref fldUSER_CHARGE37);
                Accept(ref fldPOINTS_CHARGE38); Accept(ref fldUSER_CHARGE38);
                Accept(ref fldPOINTS_CHARGE39); Accept(ref fldUSER_CHARGE39);
                Accept(ref fldPOINTS_CHARGE40); Accept(ref fldUSER_CHARGE40);
                Accept(ref fldPOINTS_CHARGE41); Accept(ref fldUSER_CHARGE41);
                Accept(ref fldPOINTS_CHARGE42); Accept(ref fldUSER_CHARGE42);
                Accept(ref fldPOINTS_CHARGE43); Accept(ref fldUSER_CHARGE43);
                Accept(ref fldPOINTS_CHARGE44); Accept(ref fldUSER_CHARGE44);
                Accept(ref fldPOINTS_CHARGE45); Accept(ref fldUSER_CHARGE45);
                Accept(ref fldPOINTS_CHARGE46); Accept(ref fldUSER_CHARGE46);
                Accept(ref fldPOINTS_CHARGE47); Accept(ref fldUSER_CHARGE47);
                Accept(ref fldPOINTS_CHARGE48); Accept(ref fldUSER_CHARGE48);
                Accept(ref fldPOINTS_CHARGE49); Accept(ref fldUSER_CHARGE49);
                Accept(ref fldPOINTS_CHARGE50); Accept(ref fldUSER_CHARGE50);
                Accept(ref fldPOINTS_CHARGE51); Accept(ref fldUSER_CHARGE51);
                Accept(ref fldPOINTS_CHARGE52); Accept(ref fldUSER_CHARGE52);
                Accept(ref fldPOINTS_CHARGE53); Accept(ref fldUSER_CHARGE53);

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
        //# dsrDesigner_91_Click Procedure
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 07/12/2013 1:48:10 PM
        //#-----------------------------------------
        private void dsrDesigner_91_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:48:10 PM
                Accept(ref fldCHARGES_SYNDICATED_VALUE);
                Accept(ref fldCHARGES_NO_OF_PROPERTIES);
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
        //# dsrDesigner_90_Click Procedure
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 07/12/2013 1:48:10 PM
        //#-----------------------------------------
        private void dsrDesigner_90_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:48:10 PM
                if (!fleCHARGES.NewRecord)
                {
                    Display(ref fldCHARGES_LOCATION);
                }
                else
                {
                    Accept(ref fldCHARGES_LOCATION);
                }
                if (!fleCHARGES.NewRecord)
                {
                    Display(ref fldCHARGES_BEDS);
                }
                else
                {
                    Accept(ref fldCHARGES_BEDS);
                }
                if (!fleCHARGES.NewRecord)
                {
                    Display(ref fldCHARGES_PROPERTY_STYLE);
                }
                else
                {
                    Accept(ref fldCHARGES_PROPERTY_STYLE);
                }
                if (!fleCHARGES.NewRecord)
                {
                    Display(ref fldCHARGES_BATHROOMS);
                }
                else
                {
                    Accept(ref fldCHARGES_BATHROOMS);
                }
                if (!fleCHARGES.NewRecord)
                {
                    Display(ref fldCHARGES_YEAR);
                }
                else
                {
                    Accept(ref fldCHARGES_YEAR);
                }
                Edit(ref fldCHARGES_PBK_YEAR);
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
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 07/12/2013 1:48:10 PM
        //#-----------------------------------------
        private void dsrDesigner_02_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:48:10 PM
                Accept(ref fldCHARGES_USER_CHARGE_A);
                Accept(ref fldCHARGES_USER_CHARGE_B);
                Accept(ref fldCHARGES_USER_CHARGE_C);
                Accept(ref fldCHARGES_USER_CHARGE_D);
                Accept(ref fldCHARGES_USER_CHARGE_E);
                Accept(ref fldCHARGES_USER_CHARGE_F);
                Accept(ref fldCHARGES_USER_CHARGE_G);
                Accept(ref fldCHARGES_USER_CHARGE_H);
                Accept(ref fldCHARGES_USER_CHARGE_I);
                Accept(ref fldCHARGES_USER_CHARGE_J);
                Accept(ref fldCHARGES_USER_CHARGE_K);
                Accept(ref fldCHARGES_USER_CHARGE_L);
                Accept(ref fldCHARGES_USER_CHARGE_M);
                Accept(ref fldCHARGES_USER_CHARGE_N);
                Accept(ref fldCHARGES_USER_CHARGE_O);
                Accept(ref fldCHARGES_USER_CHARGE_P);
                Accept(ref fldCHARGES_USER_CHARGE_Q);
                Accept(ref fldCHARGES_USER_CHARGE_R);
                Accept(ref fldCHARGES_USER_CHARGE_S);
                Accept(ref fldCHARGES_USER_CHARGE_T);
                Accept(ref fldCHARGES_USER_CHARGE_U);
                Accept(ref fldCHARGES_USER_CHARGE_V);
                Accept(ref fldCHARGES_USER_CHARGE_W);
                Accept(ref fldCHARGES_USER_CHARGE_X);
                Accept(ref fldCHARGES_USER_CHARGE_Y);
                Accept(ref fldCHARGES_USER_CHARGE_Z);
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
