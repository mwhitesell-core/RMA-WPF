
#region "Screen Comments"

// ---------------------------------------------------------------:
// :
// SYSTEM:       Holiday Property Bond                         :
// :
// PROGRAM:      TOPUPS                                        :
// :
// TASK:         MAINTAIN TOP UPS FOR INVESTOR
// :
// FILES:        TOP-UPS            PRIMARY                    :
// ENTITLEMENTS (2)    DESIGNER                  :
// INVESTOR-TRANS (2)  DESIGNER                  ;
// ANNUAL-TRANS (2)    DESIGNER                  ;
// COLOUR-RATES        REFERENCE                 ;
// :
// SCREENS                                                     :
// CALLED BY:    IVST0100   MAIN INVESTMENT SCREEN             :
// CALLING:      IVST0200   TOP UP HANDLING SCREEN             :
// XXXXXXXX    XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX  :
// :
// SUBPROGRAMS:  XXXXXXXX                                      :
// :
// ---------------------------------------------------------------;
// AMENDMENT                                                      ;
// A --     WRITE RECORD TO INVESTOR-LETTERS                      ;
// ---------------------------------------------------------------;
// 08/11/95 - change security-level to  03 
// --------------------------------------------------------------------
// 02/04/96 - the Transaction number was beeing inceased by the number
// of previous top-ups. Changed so that it is only
// incremented for new top-ups.
// --------------------------------------------------------------------
// 20/05/96 - YEAR2000 changes
// --------------------------------------------------------------------
// 26/09/97 - TERM Top-Up changes
// --------------------------------------------------------------------
// 27/08/98 - Dont allow update of cancelled investors (status 99)
// --------------------------------------------------------------------
// 03/09/98 if year 03 and overdrawn, add points to overdraft first
// --------------------------------------------------------------------
// 19/04/99 - code for new Points Plus Top-ups
// --------------------------------------------------------------------
// 18/04/02 - CHANGED POINTS TO ROUND UP (TO MATCH FIG FROM SALES
// --------------------------------------------------------------------
// 23.06.03 - add trans-ym to investor-trans,trans-header,annual-trans
// --------------------------------------------------------------------
// 07/04/04 - gold now pay ?1.10 per point.
// --------------------------------------------------------------------
// 07/04/04 - display colour of m-investors
// --------------------------------------------------------------------
// 15/07/04 - temp hardcoded d-min-inv = 9045 if investor > 69633
// --------------------------------------------------------------------
// 20.06.05 - ME - remove hard code, use new field min-9000-inv
// --------------------------------------------------------------------
// 16/04/07 - RC - From 1st May only Diamond Bonds can be topped up
// --------------------------------------------------------------------
// 12.05.08 IM Moved things around a bit to accommodate largest trans amounts
// and running balances (principally for Bond 75885)
// ---------------------------------------------------------------
// 11.06.10 IM  Expanded fields due HWH gazillion points
// ----------------------------------------------------------------
// 18.09.12 RM  Add scrnvst to record visit to this screen
// ----------------------------------------------------------------
// 04.01.13 RC  Changed label from  Invested  to  Initial  re RDR
// ----------------------------------------------------------------
// SCREEN POSITIONING
// PROCESSING
// unix conv ...              NOAUTOUPDATE                        &

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

    partial class TOPUPS : BasePage
    {

        #region " Form Designer Generated Code "





        public TOPUPS()
        {
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "TOPUPS";

            //# Set the ACTIVITIES for the screen.
            this.ChangeActivity = true;
            this.FindActivity = true;
            this.DeleteActivity = true;
            this.EntryActivity = true;
            this.UseAcceptProcessing = true;

            this.GridDesigner = "dsrDesigner_01";
            dsrDesigner_01.DefaultFirstRowInGrid = true;
        }

        #endregion

        private void Page_Load(object sender, RoutedEventArgs e)
        {
            SetVariables();
            dsrDesigner_01.Click += dsrDesigner_01_Click;
            
            fldTOP_UPS_INVESTMENT_DATE.Input += fldTOP_UPS_INVESTMENT_DATE_Input;
            fldTOP_UPS_TOP_UP_AMOUNT.Process += fldTOP_UPS_TOP_UP_AMOUNT_Process;
            fldTOP_UPS_TOP_UP_TYPE.Process += fldTOP_UPS_TOP_UP_TYPE_Process;
            Page_Load();

            // TODO: If any DESIGNER procedures function on occurring FILES or TEMPORARIES, set the grid's AllowSelectRowButton property to TRUE.



            // TODO: The following elements have Input/Output Scaling defined in the Dictionary or Screen.  Manual steps may be required:
            //       ANNUAL_ENT.PP1_CHARGE InputScale: 2 OutputScale: 0
            //       ANNUAL_ENT.PP1_SURCHARGEPER InputScale: 2 OutputScale: 0
            //       ANNUAL_ENT.PP2_CHARGE InputScale: 2 OutputScale: 0
            //       ANNUAL_ENT.PP2_SURCHARGEPER InputScale: 2 OutputScale: 0
            //       INVESTMENTS.TERM_SURCHARGEPER InputScale: 2 OutputScale: 0
            //       PP_MASTER.PP_CHARGE InputScale: 2 OutputScale: 0
            //       TERM_TOP_UPS.TERM_SURCHARGEPER InputScale: 2 OutputScale: 0
            //       TOP_UPS.PP_CHARGE InputScale: 2 OutputScale: 0


        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            T_SCREEN_NAME = new CoreCharacter("T_SCREEN_NAME", 20, this, ResetTypes.ResetAtStartup, "topups.qks");
            fleM_INVESTORS = new OracleFileObject(this, FileTypes.Master, 0, "INDEXED", "M_INVESTORS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleINVESTMENTS = new OracleFileObject(this, FileTypes.Master, 0, "INDEXED", "INVESTMENTS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleUSER_SEC_FILE = new OracleFileObject(this, FileTypes.Master, 0, "INDEXED", "USER_SEC_FILE", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            T_PP1_POINTS = new CoreInteger("T_PP1_POINTS", 8, this);
            T_PP2_POINTS = new CoreInteger("T_PP2_POINTS", 8, this);
            T_TERM_POINTS = new CoreInteger("T_TERM_POINTS", 8, this);
            T_PP1_AMOUNT = new CoreInteger("T_PP1_AMOUNT", 8, this);
            T_PP2_AMOUNT = new CoreInteger("T_PP2_AMOUNT", 8, this);
            fleTOP_UPS = new OracleFileObject(this, FileTypes.Primary, 10, "INDEXED", "TOP_UPS", "", true, false, false, 0, "m_trnTRANS_UPDATE");
            fleANNUAL_ENT = new OracleFileObject(this, FileTypes.Master, 0, "INDEXED", "ANNUAL_ENT", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleTERM_TOP_UPS = new OracleFileObject(this, FileTypes.Designer, fleTOP_UPS, "INDEXED", "TERM_TOP_UPS", "", true, false, false, 0, "m_trnTRANS_UPDATE");
            flePP_MASTER = new OracleFileObject(this, FileTypes.Reference, 0, "INDEXED", "PP_MASTER", "", false, false, false, 0, "m_cnnQUERY");
            fleCURRENT_ENTS_1 = new OracleFileObject(this, FileTypes.Designer, 0, "INDEXED", "CURRENT_ENTS", "CURRENT_ENTS_1", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleCURRENT_ENTS_2 = new OracleFileObject(this, FileTypes.Designer, 0, "INDEXED", "CURRENT_ENTS", "CURRENT_ENTS_2", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleCURRENT_ENTS_3 = new OracleFileObject(this, FileTypes.Designer, 0, "INDEXED", "CURRENT_ENTS", "CURRENT_ENTS_3", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleTRANS_HEADER = new OracleFileObject(this, FileTypes.Designer, 0, "INDEXED", "TRANS_HEADER", "", true, false, false, 0, "m_trnTRANS_UPDATE");
            fleINVESTOR_TRANS_1 = new OracleFileObject(this, FileTypes.Designer, fleTOP_UPS, "INDEXED", "INVESTOR_TRANS", "INVESTOR_TRANS_1", true, false, false, 0, "m_trnTRANS_UPDATE");
            fleINVESTOR_TRANS_2 = new OracleFileObject(this, FileTypes.Designer, fleTOP_UPS, "INDEXED", "INVESTOR_TRANS", "INVESTOR_TRANS_2", true, false, false, 0, "m_trnTRANS_UPDATE");
            fleINVESTOR_TRANS_3 = new OracleFileObject(this, FileTypes.Designer, fleTOP_UPS, "INDEXED", "INVESTOR_TRANS", "INVESTOR_TRANS_3", true, false, false, 0, "m_trnTRANS_UPDATE");
            fleANNUAL_TRANS = new OracleFileObject(this, FileTypes.Designer, fleTOP_UPS, "INDEXED", "ANNUAL_TRANS", "", true, false, false, 0, "m_trnTRANS_UPDATE");
            fleINVESTOR_LETTERS = new OracleFileObject(this, FileTypes.Designer, fleTOP_UPS, "INDEXED", "INVESTOR_LETTERS", "", true, false, false, 0, "m_trnTRANS_UPDATE");
            T_ANNUAL_BALANCE = new CoreInteger("T_ANNUAL_BALANCE", 9, this);
            T_RUNNING_BALANCE = new CoreInteger("T_RUNNING_BALANCE", 9, this);
            T_BAL_C_F = new CoreInteger("T_BAL_C_F", 9, this);
            T_ANN_C_F = new CoreInteger("T_ANN_C_F", 9, this);
            T_CURRENT_TOP_BAL = new CoreInteger("T_CURRENT_TOP_BAL", 9, this);
            T_ANNUAL_TOP_BAL = new CoreInteger("T_ANNUAL_TOP_BAL", 9, this);
            T_CURRENT_WINDOW = new CoreCharacter("T_CURRENT_WINDOW", 1, this, Common.cEmptyString);
            T_UPDATED = new CoreCharacter("T_UPDATED", 1, this, Common.cEmptyString);
            T_NEW_TOP_UPS = new CoreCharacter("T_NEW_TOP_UPS", 1, this, fleTOP_UPS, Common.cEmptyString);
            T_YEAR1_ENT = new CoreInteger("T_YEAR1_ENT", 8, this);
            T_TOT_TOP_UPS = new CoreInteger("T_TOT_TOP_UPS", 8, this);
            T_TOT_AMOUNT = new CoreInteger("T_TOT_AMOUNT", 8, this);
            T_TOP_UP_POINTS = new CoreInteger("T_TOP_UP_POINTS", 8, this);
            T_TOP_UP_AMOUNT = new CoreInteger("T_TOP_UP_AMOUNT", 8, this);
            T_BOND_POINTS = new CoreInteger("T_BOND_POINTS", 8, this);
            T_BOND_AMOUNT = new CoreInteger("T_BOND_AMOUNT", 8, this);

            fleTERM_TOP_UPS.Access += fleTERM_TOP_UPS_Access;
            fleCURRENT_ENTS_1.Access += fleCURRENT_ENTS_1_Access;
            fleCURRENT_ENTS_2.Access += fleCURRENT_ENTS_2_Access;
            fleCURRENT_ENTS_3.Access += fleCURRENT_ENTS_3_Access;
            D_COLOUR.GetValue += D_COLOUR_GetValue;
            D_INVEST_POINTS.GetValue += D_INVEST_POINTS_GetValue;
            D_TOTAL_AMOUNT.GetValue += D_TOTAL_AMOUNT_GetValue;
            D_TOTAL_POINTS.GetValue += D_TOTAL_POINTS_GetValue;
            D_INVEST_MONTH.GetValue += D_INVEST_MONTH_GetValue;
            D_ANNIV_1.GetValue += D_ANNIV_1_GetValue;
            D_ANNIV.GetValue += D_ANNIV_GetValue;
            D_END_YEAR.GetValue += D_END_YEAR_GetValue;
            D_MIN_INV.GetValue += D_MIN_INV_GetValue;
            D_QUALIFY_28DAY.GetValue += D_QUALIFY_28DAY_GetValue;
            D_LINE_DESC.GetValue += D_LINE_DESC_GetValue;
            D_MONTH.GetValue += D_MONTH_GetValue;
            fleTOP_UPS.SetItemFinals += fleTOP_UPS_SetItemFinals;
            fleTERM_TOP_UPS.SetItemFinals += fleTERM_TOP_UPS_SetItemFinals;
            fleTRANS_HEADER.SetItemFinals += fleTRANS_HEADER_SetItemFinals;
            fleINVESTOR_TRANS_1.SetItemFinals += fleINVESTOR_TRANS_1_SetItemFinals;
            fleINVESTOR_TRANS_2.SetItemFinals += fleINVESTOR_TRANS_2_SetItemFinals;
            fleINVESTOR_TRANS_3.SetItemFinals += fleINVESTOR_TRANS_3_SetItemFinals;
            fleANNUAL_TRANS.SetItemFinals += fleANNUAL_TRANS_SetItemFinals;
            fleINVESTOR_LETTERS.SetItemFinals += fleINVESTOR_LETTERS_SetItemFinals;

        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;
            fleTERM_TOP_UPS.Access -= fleTERM_TOP_UPS_Access;
            fleCURRENT_ENTS_1.Access -= fleCURRENT_ENTS_1_Access;
            fleCURRENT_ENTS_2.Access -= fleCURRENT_ENTS_2_Access;
            fleCURRENT_ENTS_3.Access -= fleCURRENT_ENTS_3_Access;
            D_COLOUR.GetValue -= D_COLOUR_GetValue;
            D_INVEST_POINTS.GetValue -= D_INVEST_POINTS_GetValue;
            D_TOTAL_AMOUNT.GetValue -= D_TOTAL_AMOUNT_GetValue;
            D_TOTAL_POINTS.GetValue -= D_TOTAL_POINTS_GetValue;
            D_INVEST_MONTH.GetValue -= D_INVEST_MONTH_GetValue;
            D_ANNIV_1.GetValue -= D_ANNIV_1_GetValue;
            D_ANNIV.GetValue -= D_ANNIV_GetValue;
            D_END_YEAR.GetValue -= D_END_YEAR_GetValue;
            D_MIN_INV.GetValue -= D_MIN_INV_GetValue;
            D_QUALIFY_28DAY.GetValue -= D_QUALIFY_28DAY_GetValue;
            D_LINE_DESC.GetValue -= D_LINE_DESC_GetValue;
            D_MONTH.GetValue -= D_MONTH_GetValue;
            fldTOP_UPS_INVESTMENT_DATE.Input -= fldTOP_UPS_INVESTMENT_DATE_Input;
            fldTOP_UPS_TOP_UP_AMOUNT.Process -= fldTOP_UPS_TOP_UP_AMOUNT_Process;
            fldTOP_UPS_TOP_UP_TYPE.Process -= fldTOP_UPS_TOP_UP_TYPE_Process;
            dsrDesigner_01.Click -= dsrDesigner_01_Click;
            fleTERM_TOP_UPS.SetItemFinals -= fleTERM_TOP_UPS_SetItemFinals;
            fleTRANS_HEADER.SetItemFinals -= fleTRANS_HEADER_SetItemFinals;
            fleINVESTOR_TRANS_1.SetItemFinals -= fleINVESTOR_TRANS_1_SetItemFinals;
            fleINVESTOR_TRANS_2.SetItemFinals -= fleINVESTOR_TRANS_2_SetItemFinals;
            fleINVESTOR_TRANS_3.SetItemFinals -= fleINVESTOR_TRANS_3_SetItemFinals;
            fleANNUAL_TRANS.SetItemFinals -= fleANNUAL_TRANS_SetItemFinals;
            fleINVESTOR_LETTERS.SetItemFinals -= fleINVESTOR_LETTERS_SetItemFinals;


        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private OracleConnection m_cnnQUERY = new OracleConnection();
        private OracleConnection m_cnnTRANS_UPDATE = new OracleConnection();
        private OracleTransaction m_trnTRANS_UPDATE;
        private CoreCharacter T_SCREEN_NAME;
        private OracleFileObject fleM_INVESTORS;
        private OracleFileObject fleINVESTMENTS;
        private OracleFileObject fleUSER_SEC_FILE;
        private CoreInteger T_PP1_POINTS;
        private CoreInteger T_PP2_POINTS;
        private CoreInteger T_TERM_POINTS;
        private CoreInteger T_PP1_AMOUNT;
        private CoreInteger T_PP2_AMOUNT;
        private OracleFileObject fleTOP_UPS;

        private void fleTOP_UPS_SetItemFinals()
        {

            try
            {
                fleTOP_UPS.set_SetValue("INVESTOR", fleM_INVESTORS.GetStringValue("INVESTOR"));
                fleTOP_UPS.set_SetValue("HOLIDAY_ANNIV", fleINVESTMENTS.GetStringValue("HOLIDAY_ANNIV"));


            }
            catch (CustomApplicationException ex)
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
        private OracleFileObject fleTERM_TOP_UPS;

        private void fleTERM_TOP_UPS_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleTERM_TOP_UPS.ElementOwner("INVESTOR")).Append(" = ").Append(Common.StringToField(fleM_INVESTORS.GetStringValue("INVESTOR")));

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



        private void fleTERM_TOP_UPS_SetItemFinals()
        {

            try
            {
                fleTERM_TOP_UPS.set_SetValue("INVESTOR", fleM_INVESTORS.GetStringValue("INVESTOR"));
                fleTERM_TOP_UPS.set_SetValue("INVESTMENT_DATE", fleTOP_UPS.GetDecimalValue("INVESTMENT_DATE"));
                fleTERM_TOP_UPS.set_SetValue("TERM_AMOUNT", fleTOP_UPS.GetDecimalValue("TOP_UP_AMOUNT"));
                fleTERM_TOP_UPS.set_SetValue("INITIAL_ENT", fleTOP_UPS.GetDecimalValue("TOP_UP_POINTS"));
                fleTERM_TOP_UPS.set_SetValue("CURRENT_ENT", fleTOP_UPS.GetDecimalValue("TOP_UP_POINTS"));
                fleTERM_TOP_UPS.set_SetValue("TERM_BALANCE", fleANNUAL_ENT.GetDecimalValue("TERM_TOP_UP_ENT"));
                fleTERM_TOP_UPS.set_SetValue("TERM_SURCHARGEPER", fleINVESTMENTS.GetDecimalValue("TERM_SURCHARGEPER"));


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }

        private OracleFileObject flePP_MASTER;
        private OracleFileObject fleCURRENT_ENTS_1;

        private void fleCURRENT_ENTS_1_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleCURRENT_ENTS_1.ElementOwner("FILL_8")).Append(" = ").Append(Common.StringToField(fleM_INVESTORS.GetStringValue("INVESTOR") + "01"));
                //Parent:INVESTOR_123
                strText.Append(" AND ").Append(fleCURRENT_ENTS_1.ElementOwner("YEAR_123")).Append(" = ").Append(Common.StringToField((fleM_INVESTORS.GetStringValue("INVESTOR") + "01").PadRight(10).Substring(8, 2)));
                //Parent:INVESTOR_123

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

        private OracleFileObject fleCURRENT_ENTS_2;

        private void fleCURRENT_ENTS_2_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleCURRENT_ENTS_2.ElementOwner("FILL_8")).Append(" = ").Append(Common.StringToField(fleM_INVESTORS.GetStringValue("INVESTOR") + "02"));
                //Parent:INVESTOR_123
                strText.Append(" AND ").Append(fleCURRENT_ENTS_2.ElementOwner("YEAR_123")).Append(" = ").Append(Common.StringToField((fleM_INVESTORS.GetStringValue("INVESTOR") + "02").PadRight(10).Substring(8, 2)));
                //Parent:INVESTOR_123

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

        private OracleFileObject fleCURRENT_ENTS_3;

        private void fleCURRENT_ENTS_3_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleCURRENT_ENTS_3.ElementOwner("FILL_8")).Append(" = ").Append(Common.StringToField(fleM_INVESTORS.GetStringValue("INVESTOR") + "03"));
                //Parent:INVESTOR_123
                strText.Append(" AND ").Append(fleCURRENT_ENTS_3.ElementOwner("YEAR_123")).Append(" = ").Append(Common.StringToField((fleM_INVESTORS.GetStringValue("INVESTOR") + "03").PadRight(10).Substring(8, 2)));
                //Parent:INVESTOR_123

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

        private OracleFileObject fleTRANS_HEADER;

        private void fleTRANS_HEADER_SetItemFinals()
        {

            try
            {
                fleTRANS_HEADER.set_SetValue("INVESTOR", fleM_INVESTORS.GetStringValue("INVESTOR"));
                fleTRANS_HEADER.set_SetValue("TRANS_TYPE", "TU");
                fleTRANS_HEADER.set_SetValue("TRANS_STATUS", "WP");
                fleTRANS_HEADER.set_SetValue("ON_STATEMENT", "Y");
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

        private OracleFileObject fleINVESTOR_TRANS_1;

        private void fleINVESTOR_TRANS_1_SetItemFinals()
        {

            try
            {
                fleINVESTOR_TRANS_1.set_SetValue("INVESTOR", fleM_INVESTORS.GetStringValue("INVESTOR"));
                fleINVESTOR_TRANS_1.set_SetValue("FILLER_8", fleCURRENT_ENTS_1.GetStringValue("FILLER_8"));
                //Parent:INVESTOR_YEAR
                fleINVESTOR_TRANS_1.set_SetValue("YEAR", fleCURRENT_ENTS_1.GetStringValue("YEAR"));
                //Parent:INVESTOR_YEAR    'Parent:INVESTOR_YEAR
                fleINVESTOR_TRANS_1.set_SetValue("FILLER_81", fleTRANS_HEADER.GetStringValue("FILLER"));
                //Parent:TRANS_ID
                fleINVESTOR_TRANS_1.set_SetValue("TRANS_NO", fleTRANS_HEADER.GetStringValue("TRANS_NO"));
                //Parent:TRANS_ID    'Parent:TRANS_ID
                fleINVESTOR_TRANS_1.set_SetValue("TRANS_YEAR_ID", fleINVESTOR_TRANS_1.GetStringValue("FILLER_8") + fleINVESTOR_TRANS_1.GetStringValue("YEAR") + fleTRANS_HEADER.GetStringValue("TRANS_NO"));
                //Parent:INVESTOR_YEAR
                fleINVESTOR_TRANS_1.set_SetValue("TRANSACT_TYPE", "ADD");
                fleINVESTOR_TRANS_1.set_SetValue("TRANSACT_VALUE", fleTOP_UPS.GetDecimalValue("TOP_UP_POINTS"));
                fleINVESTOR_TRANS_1.set_SetValue("ENT_VAL", fleTOP_UPS.GetDecimalValue("TOP_UP_POINTS"));
                fleINVESTOR_TRANS_1.set_SetValue("ENT_RBAL", fleCURRENT_ENTS_1.GetDecimalValue("ENTITLEMENT_BAL"));
                fleINVESTOR_TRANS_1.set_SetValue("HOLIDAY_ANNIV", fleINVESTMENTS.GetStringValue("HOLIDAY_ANNIV"));
                fleINVESTOR_TRANS_1.set_SetValue("TRANSACT_DATE", QDesign.SysDate(ref m_cnnQUERY));
                fleINVESTOR_TRANS_1.set_SetValue("TRANSACT_TIME", QDesign.SysTime(ref m_cnnQUERY));
                fleINVESTOR_TRANS_1.set_SetValue("TRANS_YM", QDesign.Substring(QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8), 1, 6));


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }

        private OracleFileObject fleINVESTOR_TRANS_2;

        private void fleINVESTOR_TRANS_2_SetItemFinals()
        {

            try
            {
                fleINVESTOR_TRANS_2.set_SetValue("INVESTOR", fleM_INVESTORS.GetStringValue("INVESTOR"));
                fleINVESTOR_TRANS_2.set_SetValue("FILLER_8", fleCURRENT_ENTS_2.GetStringValue("FILLER_8"));
                //Parent:INVESTOR_YEAR
                fleINVESTOR_TRANS_2.set_SetValue("YEAR", fleCURRENT_ENTS_2.GetStringValue("YEAR"));
                //Parent:INVESTOR_YEAR    'Parent:INVESTOR_YEAR
                fleINVESTOR_TRANS_2.set_SetValue("FILLER_81", fleTRANS_HEADER.GetStringValue("FILLER"));
                //Parent:TRANS_ID
                fleINVESTOR_TRANS_2.set_SetValue("TRANS_NO", fleTRANS_HEADER.GetStringValue("TRANS_NO"));
                //Parent:TRANS_ID    'Parent:TRANS_ID
                fleINVESTOR_TRANS_2.set_SetValue("TRANS_YEAR_ID", fleINVESTOR_TRANS_2.GetStringValue("FILLER_8") + fleINVESTOR_TRANS_2.GetStringValue("YEAR") + fleTRANS_HEADER.GetStringValue("TRANS_NO"));
                //Parent:INVESTOR_YEAR
                fleINVESTOR_TRANS_2.set_SetValue("TRANSACT_TYPE", "ADD");
                fleINVESTOR_TRANS_2.set_SetValue("TRANSACT_VALUE", fleTOP_UPS.GetDecimalValue("TOP_UP_POINTS"));
                fleINVESTOR_TRANS_2.set_SetValue("ENT_VAL", fleTOP_UPS.GetDecimalValue("TOP_UP_POINTS"));
                fleINVESTOR_TRANS_2.set_SetValue("ENT_RBAL", fleCURRENT_ENTS_2.GetDecimalValue("ENTITLEMENT_BAL"));
                fleINVESTOR_TRANS_2.set_SetValue("HOLIDAY_ANNIV", fleINVESTMENTS.GetStringValue("HOLIDAY_ANNIV"));
                fleINVESTOR_TRANS_2.set_SetValue("TRANSACT_DATE", QDesign.SysDate(ref m_cnnQUERY));
                fleINVESTOR_TRANS_2.set_SetValue("TRANSACT_TIME", QDesign.SysTime(ref m_cnnQUERY));
                fleINVESTOR_TRANS_2.set_SetValue("TRANS_YM", QDesign.Substring(QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8), 1, 6));


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }

        private OracleFileObject fleINVESTOR_TRANS_3;

        private void fleINVESTOR_TRANS_3_SetItemFinals()
        {

            try
            {
                fleINVESTOR_TRANS_3.set_SetValue("INVESTOR", fleM_INVESTORS.GetStringValue("INVESTOR"));
                fleINVESTOR_TRANS_3.set_SetValue("FILLER_8", fleCURRENT_ENTS_3.GetStringValue("FILLER_8"));
                //Parent:INVESTOR_YEAR
                fleINVESTOR_TRANS_3.set_SetValue("YEAR", fleCURRENT_ENTS_3.GetStringValue("YEAR"));
                //Parent:INVESTOR_YEAR    'Parent:INVESTOR_YEAR
                fleINVESTOR_TRANS_3.set_SetValue("FILLER_81", fleTRANS_HEADER.GetStringValue("FILLER"));
                //Parent:TRANS_ID
                fleINVESTOR_TRANS_3.set_SetValue("TRANS_NO", fleTRANS_HEADER.GetStringValue("TRANS_NO"));
                //Parent:TRANS_ID    'Parent:TRANS_ID
                fleINVESTOR_TRANS_3.set_SetValue("TRANS_YEAR_ID", fleINVESTOR_TRANS_3.GetStringValue("FILLER_8") + fleINVESTOR_TRANS_3.GetStringValue("YEAR") + fleTRANS_HEADER.GetStringValue("TRANS_NO"));
                //Parent:INVESTOR_YEAR
                fleINVESTOR_TRANS_3.set_SetValue("TRANSACT_TYPE", "ADD");
                fleINVESTOR_TRANS_3.set_SetValue("TRANSACT_VALUE", fleTOP_UPS.GetDecimalValue("TOP_UP_POINTS"));
                fleINVESTOR_TRANS_3.set_SetValue("ENT_VAL", fleTOP_UPS.GetDecimalValue("TOP_UP_POINTS"));
                fleINVESTOR_TRANS_3.set_SetValue("ENT_RBAL", fleCURRENT_ENTS_3.GetDecimalValue("ENTITLEMENT_BAL"));
                fleINVESTOR_TRANS_3.set_SetValue("HOLIDAY_ANNIV", fleINVESTMENTS.GetStringValue("HOLIDAY_ANNIV"));
                fleINVESTOR_TRANS_3.set_SetValue("TRANSACT_DATE", QDesign.SysDate(ref m_cnnQUERY));
                fleINVESTOR_TRANS_3.set_SetValue("TRANSACT_TIME", QDesign.SysTime(ref m_cnnQUERY));
                fleINVESTOR_TRANS_3.set_SetValue("TRANS_YM", QDesign.Substring(QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8), 1, 6));


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }

        private OracleFileObject fleANNUAL_TRANS;

        private void fleANNUAL_TRANS_SetItemFinals()
        {

            try
            {
                fleANNUAL_TRANS.set_SetValue("INVESTOR", fleM_INVESTORS.GetStringValue("INVESTOR"));
                fleANNUAL_TRANS.set_SetValue("HOLIDAY_ANNIV", fleINVESTMENTS.GetStringValue("HOLIDAY_ANNIV"));
                fleANNUAL_TRANS.set_SetValue("TRANSACT_TYPE", "ADD");
                fleANNUAL_TRANS.set_SetValue("TRANSACT_VALUE", fleTOP_UPS.GetDecimalValue("TOP_UP_POINTS"));
                fleANNUAL_TRANS.set_SetValue("TRANSACT_DATE", QDesign.SysDate(ref m_cnnQUERY));
                fleANNUAL_TRANS.set_SetValue("TRANSACT_TIME", QDesign.SysTime(ref m_cnnQUERY));
                fleANNUAL_TRANS.set_SetValue("TRANS_YM", QDesign.Substring(QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8), 1, 6));
                fleANNUAL_TRANS.set_SetValue("RECORD_STATUS", "OP");


            }
            catch (CustomApplicationException ex)
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

        private void fleINVESTOR_LETTERS_SetItemFinals()
        {

            try
            {
                fleINVESTOR_LETTERS.set_SetValue("RECORD_STATUS", "TU");
                fleINVESTOR_LETTERS.set_SetValue("HOLIDAY_ANNIV", fleINVESTMENTS.GetStringValue("HOLIDAY_ANNIV"));


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }

        private CoreInteger T_ANNUAL_BALANCE;
        private CoreInteger T_RUNNING_BALANCE;
        private CoreInteger T_BAL_C_F;
        private CoreInteger T_ANN_C_F;
        private CoreInteger T_CURRENT_TOP_BAL;
        private CoreInteger T_ANNUAL_TOP_BAL;
        private CoreCharacter T_CURRENT_WINDOW;
        private CoreCharacter T_UPDATED;
        private CoreCharacter T_NEW_TOP_UPS;
        private CoreInteger T_YEAR1_ENT;
        private CoreInteger T_TOT_TOP_UPS;
        private CoreInteger T_TOT_AMOUNT;
        private CoreInteger T_TOP_UP_POINTS;
        private CoreInteger T_TOP_UP_AMOUNT;
        private CoreInteger T_BOND_POINTS;
        private CoreInteger T_BOND_AMOUNT;
        private DCharacter D_COLOUR = new DCharacter(2);
        private void D_COLOUR_GetValue(ref string Value)
        {

            try
            {
                Value = fleM_INVESTORS.GetStringValue("COLOUR") + " ";


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DInteger D_INVEST_POINTS = new DInteger(9);
        private void D_INVEST_POINTS_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0;

                // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

                if (((QDesign.NULL(fleTOP_UPS.GetStringValue("TOP_UP_TYPE")) == "B" || QDesign.NULL(fleTOP_UPS.GetStringValue("TOP_UP_TYPE")) == QDesign.NULL(" ")) && QDesign.NULL(fleM_INVESTORS.GetStringValue("COLOUR")) == "D"))
                {
                    CurrentValue = fleTOP_UPS.GetDecimalValue("TOP_UP_AMOUNT");
                }
                else if (((QDesign.NULL(fleTOP_UPS.GetStringValue("TOP_UP_TYPE")) == "B" || QDesign.NULL(fleTOP_UPS.GetStringValue("TOP_UP_TYPE")) == QDesign.NULL(" ")) && QDesign.NULL(fleM_INVESTORS.GetStringValue("COLOUR")) != "D"))
                {
                    CurrentValue = (fleTOP_UPS.GetDecimalValue("TOP_UP_AMOUNT") / (decimal)1.1);
                }
                else
                {
                    CurrentValue = QDesign.Round(fleTOP_UPS.GetDecimalValue("TOP_UP_AMOUNT") * (10 / 6), 0, RoundOptionTypes.Up);
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
        private DInteger D_TOTAL_AMOUNT = new DInteger(9);
        private void D_TOTAL_AMOUNT_GetValue(ref decimal Value)
        {

            try
            {
                Value = fleINVESTMENTS.GetDecimalValue("INVEST_AMOUNT") + fleINVESTMENTS.GetDecimalValue("TOP_UP_AMOUNT");


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DInteger D_TOTAL_POINTS = new DInteger(9);
        private void D_TOTAL_POINTS_GetValue(ref decimal Value)
        {

            try
            {
                Value = fleINVESTMENTS.GetDecimalValue("INVEST_POINTS") + fleINVESTMENTS.GetDecimalValue("TOP_UP_POINTS");


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DInteger D_INVEST_MONTH = new DInteger(8);
        private void D_INVEST_MONTH_GetValue(ref decimal Value)
        {

            try
            {
                Value = QDesign.NConvert(QDesign.Substring(QDesign.ASCII(fleTOP_UPS.GetDecimalValue("INVESTMENT_DATE")), 5, 2));


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DCharacter D_ANNIV_1 = new DCharacter(2);
        private void D_ANNIV_1_GetValue(ref string Value)
        {

            try
            {
                Value = QDesign.Substring(QDesign.ASCII(fleTOP_UPS.GetDecimalValue("INVESTMENT_DATE") + 100), 5, 2);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DCharacter D_ANNIV = new DCharacter(2);
        private void D_ANNIV_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(D_ANNIV_1.Value) == "13")
                {
                    CurrentValue = "01";
                }
                else
                {
                    CurrentValue = D_ANNIV_1.Value;
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
        private DCharacter D_END_YEAR = new DCharacter(4);
        private void D_END_YEAR_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(D_ANNIV.Value) != QDesign.NULL(fleM_INVESTORS.GetStringValue("HOLIDAY_ANNIV")))
                {
                    CurrentValue = QDesign.ASCII(QDesign.NConvert(fleCURRENT_ENTS_1.GetStringValue("YEAR")) + 21);
                }
                else
                {
                    CurrentValue = QDesign.ASCII(QDesign.NConvert(fleCURRENT_ENTS_1.GetStringValue("YEAR")) + 14);
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
        private DInteger D_MIN_INV = new DInteger(8);
        private void D_MIN_INV_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0;
                if (string.Compare(fleM_INVESTORS.GetStringValue("INVESTOR"), "48917") <= 0)
                {
                    CurrentValue = fleUSER_SEC_FILE.GetDecimalValue("MIN_GOLD_INV");
                }
                else if (string.Compare(fleM_INVESTORS.GetStringValue("INVESTOR"), "69633") <= 0)
                {
                    CurrentValue = fleUSER_SEC_FILE.GetDecimalValue("MIN_7000_INV");
                }
                else
                {
                    CurrentValue = fleUSER_SEC_FILE.GetDecimalValue("MIN_9000_INV");
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
        private DCharacter D_QUALIFY_28DAY = new DCharacter(1);
        private void D_QUALIFY_28DAY_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (D_MIN_INV.Value <= ((fleANNUAL_ENT.GetDecimalValue("ANN_CURR_ENT") - fleANNUAL_ENT.GetDecimalValue("TERM_TOP_UP_ENT") - fleANNUAL_ENT.GetDecimalValue("PP1_TOP_UP_ENT") - fleANNUAL_ENT.GetDecimalValue("PP2_TOP_UP_ENT")) + ((fleANNUAL_ENT.GetDecimalValue("TERM_TOP_UP_ENT") * (decimal)0.6 + (fleANNUAL_ENT.GetDecimalValue("PP1_TOP_UP_ENT") * (decimal)0.6) + (fleANNUAL_ENT.GetDecimalValue("PP1_TOP_UP_ENT") * (decimal)0.6)))))
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
        private DCharacter D_LINE_DESC = new DCharacter(40);
        private void D_LINE_DESC_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(fleTOP_UPS.GetStringValue("TOP_UP_TYPE")) == "B")
                {
                    CurrentValue = "Top-up Investment ?" + QDesign.ASCII(fleTOP_UPS.GetDecimalValue("TOP_UP_AMOUNT"));
                }
                else if (QDesign.NULL(QDesign.Substring(fleTOP_UPS.GetStringValue("TOP_UP_TYPE"), 1, 1)) == "P")
                {
                    CurrentValue = "Points Plus Investment ?" + QDesign.ASCII(fleTOP_UPS.GetDecimalValue("TOP_UP_AMOUNT"));
                }
                else if (QDesign.NULL(fleTOP_UPS.GetStringValue("TOP_UP_TYPE")) == "T")
                {
                    CurrentValue = "Term Investment ?" + QDesign.ASCII(fleTOP_UPS.GetDecimalValue("TOP_UP_AMOUNT"));
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
        private DDecimal D_MONTH = new DDecimal(8);
        private void D_MONTH_GetValue(ref decimal Value)
        {

            try
            {
                Value = QDesign.NConvert(QDesign.Substring(QDesign.ASCII(fleTOP_UPS.GetDecimalValue("INVESTMENT_DATE")), 5, 2));


            }
            catch (CustomApplicationException ex)
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
        //# Do not delete, modify or move it.  Updated: 07/12/2013 1:49:10 PM

        protected DateControl fldTOP_UPS_INVESTMENT_DATE;
        protected TextBox fldTOP_UPS_TOP_UP_AMOUNT;
        protected TextBox fldTOP_UPS_TOP_UP_TYPE;

        protected TextBox fldTOP_UPS_TOP_UP_POINTS;

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 07/12/2013 1:49:10 PM

        //#-----------------------------------------
        //# GetGridFieldObject Procedure.
        //#-----------------------------------------

        protected override void GetGridFieldObject(object DataListField, ref object CoreField, string Name)
        {

            try
            {
                switch (Name.ToUpper())
                {
                    case "FLDGRDTOP_UPS_INVESTMENT_DATE":
                        fldTOP_UPS_INVESTMENT_DATE = (DateControl)DataListField;
                        CoreField = fldTOP_UPS_INVESTMENT_DATE;
                        fldTOP_UPS_INVESTMENT_DATE.Bind(fleTOP_UPS);
                        break;
                    case "FLDGRDTOP_UPS_TOP_UP_AMOUNT":
                        fldTOP_UPS_TOP_UP_AMOUNT = (TextBox)DataListField;
                        CoreField = fldTOP_UPS_TOP_UP_AMOUNT;
                        fldTOP_UPS_TOP_UP_AMOUNT.Bind(fleTOP_UPS);
                        break;
                    case "FLDGRDTOP_UPS_TOP_UP_TYPE":
                        fldTOP_UPS_TOP_UP_TYPE = (TextBox)DataListField;
                        CoreField = fldTOP_UPS_TOP_UP_TYPE;
                        fldTOP_UPS_TOP_UP_TYPE.Bind(fleTOP_UPS);
                        break;
                    case "FLDGRDTOP_UPS_TOP_UP_POINTS":
                        fldTOP_UPS_TOP_UP_POINTS = (TextBox)DataListField;
                        CoreField = fldTOP_UPS_TOP_UP_POINTS;
                        fldTOP_UPS_TOP_UP_POINTS.Bind(fleTOP_UPS);
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
                dtlTOP_UPS.OccursWithFile = fleTOP_UPS;

            }
            catch (CustomApplicationException ex)
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
        //# Do not delete, modify or move it.  Updated: 07/12/2013 1:49:10 PM

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
            fleINVESTMENTS.Transaction = m_trnTRANS_UPDATE;
            fleUSER_SEC_FILE.Transaction = m_trnTRANS_UPDATE;
            fleTOP_UPS.Transaction = m_trnTRANS_UPDATE;
            fleANNUAL_ENT.Transaction = m_trnTRANS_UPDATE;
            fleTERM_TOP_UPS.Transaction = m_trnTRANS_UPDATE;
            fleCURRENT_ENTS_1.Transaction = m_trnTRANS_UPDATE;
            fleCURRENT_ENTS_2.Transaction = m_trnTRANS_UPDATE;
            fleCURRENT_ENTS_3.Transaction = m_trnTRANS_UPDATE;
            fleTRANS_HEADER.Transaction = m_trnTRANS_UPDATE;
            fleINVESTOR_TRANS_1.Transaction = m_trnTRANS_UPDATE;
            fleINVESTOR_TRANS_2.Transaction = m_trnTRANS_UPDATE;
            fleINVESTOR_TRANS_3.Transaction = m_trnTRANS_UPDATE;
            fleANNUAL_TRANS.Transaction = m_trnTRANS_UPDATE;
            fleINVESTOR_LETTERS.Transaction = m_trnTRANS_UPDATE;


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 07/12/2013 1:49:10 PM

        //#-----------------------------------------
        //# InitializeFiles Procedure.
        //#-----------------------------------------

        protected override void InitializeFiles()
        {

            try
            {
                Initialize_TRANS_UPDATE();
                flePP_MASTER.Connection = m_cnnQUERY;


            }
            catch (CustomApplicationException ex)
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
                fleINVESTMENTS.Dispose();
                fleUSER_SEC_FILE.Dispose();
                fleTOP_UPS.Dispose();
                fleANNUAL_ENT.Dispose();
                fleTERM_TOP_UPS.Dispose();
                flePP_MASTER.Dispose();
                fleCURRENT_ENTS_1.Dispose();
                fleCURRENT_ENTS_2.Dispose();
                fleCURRENT_ENTS_3.Dispose();
                fleTRANS_HEADER.Dispose();
                fleINVESTOR_TRANS_1.Dispose();
                fleINVESTOR_TRANS_2.Dispose();
                fleINVESTOR_TRANS_3.Dispose();
                fleANNUAL_TRANS.Dispose();
                fleINVESTOR_LETTERS.Dispose();


            }
            catch (CustomApplicationException ex)
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
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 07/12/2013 1:49:10 PM
        //#-----------------------------------------
        protected override void DisplayFormatting()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:49:10 PM
                Display(ref fldINVESTMENTS_HOLIDAY_ANNIV);
                Display(ref fldINVESTMENTS_INVESTMENT_DATE);
                Display(ref fldINVESTMENTS_INVEST_AMOUNT);
                Display(ref fldINVESTMENTS_INVEST_POINTS);
                Display(ref fldINVESTMENTS_TOP_UP_AMOUNT);
                Display(ref fldINVESTMENTS_TOP_UP_POINTS);
                Display(ref fldD_TOTAL_AMOUNT);
                Display(ref fldD_TOTAL_POINTS);
                Display(ref fldM_INVESTORS_COLOUR);
                Display(ref fldINVESTMENTS_PP1_AMOUNT);
                Display(ref fldINVESTMENTS_PP1_POINTS);
                Display(ref fldANNUAL_ENT_PP1_SURCHARGEPER);
                Display(ref fldINVESTMENTS_PP2_AMOUNT);
                Display(ref fldINVESTMENTS_PP2_POINTS);
                Display(ref fldANNUAL_ENT_PP2_SURCHARGEPER);
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
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 07/12/2013 1:49:10 PM
        //#-----------------------------------------
        protected override void PreDisplayFormatting()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:49:10 PM
                Display(ref fldINVESTMENTS_HOLIDAY_ANNIV);
                Display(ref fldINVESTMENTS_INVESTMENT_DATE);
                Display(ref fldINVESTMENTS_INVEST_AMOUNT);
                Display(ref fldINVESTMENTS_INVEST_POINTS);
                Display(ref fldINVESTMENTS_TOP_UP_AMOUNT);
                Display(ref fldINVESTMENTS_TOP_UP_POINTS);
                Display(ref fldD_TOTAL_AMOUNT);
                Display(ref fldD_TOTAL_POINTS);
                Display(ref fldM_INVESTORS_COLOUR);
                Display(ref fldINVESTMENTS_PP1_AMOUNT);
                Display(ref fldINVESTMENTS_PP1_POINTS);
                Display(ref fldANNUAL_ENT_PP1_SURCHARGEPER);
                Display(ref fldINVESTMENTS_PP2_AMOUNT);
                Display(ref fldINVESTMENTS_PP2_POINTS);
                Display(ref fldANNUAL_ENT_PP2_SURCHARGEPER);
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
        //# Do not delete, modify or move it.  Updated: 07/12/2013 1:49:10 PM

        //#-----------------------------------------
        //# BindFields Procedure.
        //#-----------------------------------------

        public override void BindFields()
        {
            try
            {
                fldINVESTMENTS_HOLIDAY_ANNIV.Bind(fleINVESTMENTS);
                fldINVESTMENTS_INVESTMENT_DATE.Bind(fleINVESTMENTS);
                fldINVESTMENTS_INVEST_AMOUNT.Bind(fleINVESTMENTS);
                fldINVESTMENTS_INVEST_POINTS.Bind(fleINVESTMENTS);
                fldINVESTMENTS_TOP_UP_AMOUNT.Bind(fleINVESTMENTS);
                fldINVESTMENTS_TOP_UP_POINTS.Bind(fleINVESTMENTS);
                fldD_TOTAL_AMOUNT.Bind(D_TOTAL_AMOUNT);
                fldD_TOTAL_POINTS.Bind(D_TOTAL_POINTS);
                fldM_INVESTORS_COLOUR.Bind(fleM_INVESTORS);
                fldINVESTMENTS_PP1_AMOUNT.Bind(fleINVESTMENTS);
                fldINVESTMENTS_PP1_POINTS.Bind(fleINVESTMENTS);
                fldANNUAL_ENT_PP1_SURCHARGEPER.Bind(fleANNUAL_ENT);
                fldINVESTMENTS_PP2_AMOUNT.Bind(fleINVESTMENTS);
                fldINVESTMENTS_PP2_POINTS.Bind(fleINVESTMENTS);
                fldANNUAL_ENT_PP2_SURCHARGEPER.Bind(fleANNUAL_ENT);

            }
            catch (CustomApplicationException ex)
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
                SaveReceivingParams(fleM_INVESTORS, fleINVESTMENTS, fleANNUAL_ENT, fleUSER_SEC_FILE);


            }
            catch (CustomApplicationException ex)
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
                Receiving(fleM_INVESTORS, fleINVESTMENTS, fleANNUAL_ENT, fleUSER_SEC_FILE);


            }
            catch (CustomApplicationException ex)
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


        private void fldTOP_UPS_INVESTMENT_DATE_Input()
        {

            try
            {

                //#CORE_BEGIN_INCLUDE: DATECENT.USE"

                //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
                //# Do not delete, modify or move it.  Updated: 07/12/2013 1:49:09 PM

                if (6 == FieldText.Length)
                {
                    if (string.Compare(QDesign.NULL(QDesign.Substring(FieldText, 5, 2)) , QDesign.NULL("69")) < 0)
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



        private void fldTOP_UPS_TOP_UP_AMOUNT_Process()
        {

            try
            {

                if (QDesign.NULL(fleM_INVESTORS.GetStringValue("COLOUR")) != "D")
                {
                    Information("* Since 1st May only Diamond Bonds can be topped up *");
                    // TODO: May need to fix manually
                }
                if (EntryMode || CorrectMode || ChangeMode)
                {
                    fleTOP_UPS.set_SetValue("TOP_UP_POINTS", D_INVEST_POINTS.Value);
                    Display(ref fldINVESTMENTS_TOP_UP_POINTS);
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



        private void fldTOP_UPS_TOP_UP_TYPE_Process()
        {

            try
            {

                if (QDesign.NULL(fleM_INVESTORS.GetStringValue("COLOUR")) != "D")
                {
                    Information("* Since 1st May only Diamond Bonds can be topped up *");
                    // TODO: May need to fix manually
                }
                fleTOP_UPS.set_SetValue("TOP_UP_POINTS", D_INVEST_POINTS.Value);
                Display(ref fldINVESTMENTS_TOP_UP_POINTS);


            }
            catch (CustomApplicationException ex)
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

                if (QDesign.NULL(fleM_INVESTORS.GetStringValue("COLOUR")) != "D")
                {
                    Information("42024");
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


		try {

			if (QDesign.NULL(fleM_INVESTORS.GetDecimalValue("STATUS")) == 99) {
				Severe("52122");
			}
			if (string.Compare(QDesign.NULL(fleUSER_SEC_FILE.GetStringValue("USER_LEVEL")) , "03")>0) {
				Severe("52123");
			}
			if (QDesign.NULL(T_UPDATED.Value) == "Y") {
				ErrorMessage("52124");
			} else {
				T_UPDATED.Value = "Y";
			}
			// --> GET CURRENT_ENTS_1 <--
			fleCURRENT_ENTS_1.GetData();
			// --> End GET CURRENT_ENTS_1 <--
			// --> GET CURRENT_ENTS_2 <--
			fleCURRENT_ENTS_2.GetData();
			// --> End GET CURRENT_ENTS_2 <--
			// --> GET CURRENT_ENTS_3 <--
			fleCURRENT_ENTS_3.GetData();
			// --> End GET CURRENT_ENTS_3 <--
			while (fleTOP_UPS.For()) {
				if (fleTOP_UPS.NewRecord) {
					T_NEW_TOP_UPS.Value = "Y";
					fleINVESTOR_TRANS_1.set_SetValue("LINE_DESCRIPTION", D_LINE_DESC.Value);
					fleINVESTOR_TRANS_2.set_SetValue("LINE_DESCRIPTION", D_LINE_DESC.Value);
					fleINVESTOR_TRANS_3.set_SetValue("LINE_DESCRIPTION", D_LINE_DESC.Value);
					fleANNUAL_TRANS.set_SetValue("LINE_DESCRIPTION", D_LINE_DESC.Value);
					fleINVESTOR_LETTERS.set_SetValue("INVESTOR", fleINVESTMENTS.GetStringValue("INVESTOR"));
					T_TOT_TOP_UPS.Value = T_TOT_TOP_UPS.Value + fleTOP_UPS.GetDecimalValue("TOP_UP_POINTS");
					T_TOT_AMOUNT.Value = T_TOT_AMOUNT.Value + fleTOP_UPS.GetDecimalValue("TOP_UP_AMOUNT");
					if (QDesign.NULL(fleTOP_UPS.GetStringValue("TOP_UP_TYPE")) == "B") {
						T_BOND_POINTS.Value = T_BOND_POINTS.Value + fleTOP_UPS.GetDecimalValue("TOP_UP_POINTS");
						T_BOND_AMOUNT.Value = T_BOND_AMOUNT.Value + fleTOP_UPS.GetDecimalValue("TOP_UP_AMOUNT");
					}
					if (QDesign.NULL(fleTOP_UPS.GetStringValue("TOP_UP_TYPE")) == "P1") {
						T_PP1_POINTS.Value = T_PP1_POINTS.Value + fleTOP_UPS.GetDecimalValue("TOP_UP_POINTS");
						T_PP1_AMOUNT.Value = T_PP1_AMOUNT.Value + fleTOP_UPS.GetDecimalValue("TOP_UP_AMOUNT");
						// --> GET PP_MASTER <--
						m_strWhere = new StringBuilder(" WHERE ");
						m_strWhere.Append(" ").Append(flePP_MASTER.ElementOwner("PP_KEY")).Append(" = ");
						m_strWhere.Append(Common.StringToField(fleTOP_UPS.GetStringValue("TOP_UP_TYPE")));

						flePP_MASTER.GetData(m_strWhere.ToString());
						// --> End GET PP_MASTER <--
						fleTOP_UPS.set_SetValue("PP_CHARGE", flePP_MASTER.GetDecimalValue("PP_CHARGE"));
						fleANNUAL_ENT.set_SetValue("PP1_CHARGE", flePP_MASTER.GetDecimalValue("PP_CHARGE"));
						fleTOP_UPS.set_SetValue("PP1_CURRENT_ENT", fleTOP_UPS.GetDecimalValue("TOP_UP_POINTS"));
					}
					if (QDesign.NULL(fleTOP_UPS.GetStringValue("TOP_UP_TYPE")) == "P2") {
						T_PP2_POINTS.Value = T_PP2_POINTS.Value + fleTOP_UPS.GetDecimalValue("TOP_UP_POINTS");
						T_PP2_AMOUNT.Value = T_PP2_AMOUNT.Value + fleTOP_UPS.GetDecimalValue("TOP_UP_AMOUNT");
						// --> GET PP_MASTER <--
						m_strWhere = new StringBuilder(" WHERE ");
						m_strWhere.Append(" ").Append(flePP_MASTER.ElementOwner("PP_KEY")).Append(" = ");
						m_strWhere.Append(Common.StringToField(fleTOP_UPS.GetStringValue("TOP_UP_TYPE")));

						flePP_MASTER.GetData(m_strWhere.ToString());
						// --> End GET PP_MASTER <--
						fleTOP_UPS.set_SetValue("PP_CHARGE", flePP_MASTER.GetDecimalValue("PP_CHARGE"));
						fleANNUAL_ENT.set_SetValue("PP2_CHARGE", flePP_MASTER.GetDecimalValue("PP_CHARGE"));
						fleTOP_UPS.set_SetValue("PP2_CURRENT_ENT", fleTOP_UPS.GetDecimalValue("TOP_UP_POINTS"));
					}
					fleINVESTOR_TRANS_1.set_SetValue("RUNNING_BALANCE", fleCURRENT_ENTS_1.GetDecimalValue("BF_BAL") + fleCURRENT_ENTS_1.GetDecimalValue("ENTITLEMENT_BAL") + (T_TOT_TOP_UPS.Value));
					fleINVESTOR_TRANS_2.set_SetValue("RUNNING_BALANCE", fleCURRENT_ENTS_2.GetDecimalValue("BF_BAL") + fleCURRENT_ENTS_2.GetDecimalValue("ENTITLEMENT_BAL") + T_TOT_TOP_UPS.Value);
					fleINVESTOR_TRANS_3.set_SetValue("RUNNING_BALANCE", fleCURRENT_ENTS_3.GetDecimalValue("ENT_OVERDRAFT") + fleCURRENT_ENTS_3.GetDecimalValue("ENTITLEMENT_BAL") + T_TOT_TOP_UPS.Value);
					fleANNUAL_TRANS.set_SetValue("RUNNING_BALANCE", fleANNUAL_ENT.GetDecimalValue("ANN_CURR_ENT") + T_TOT_TOP_UPS.Value);
					fleM_INVESTORS.set_SetValue("TRANSACTION_NO", fleM_INVESTORS.GetDecimalValue("TRANSACTION_NO") + 1);
                    fleTRANS_HEADER.set_SetValue("FILLER", fleM_INVESTORS.GetStringValue("INVESTOR") + QDesign.ASCII(fleM_INVESTORS.GetDecimalValue("TRANSACTION_NO"), 6));
					//Parent:TRANS_ID
                    fleTRANS_HEADER.set_SetValue("TRANS_NO", (fleM_INVESTORS.GetStringValue("INVESTOR") + QDesign.ASCII(fleM_INVESTORS.GetDecimalValue("TRANSACTION_NO"), 6)).PadRight(14).Substring(8, 6));
					//Parent:TRANS_ID
                    fleTOP_UPS.set_SetValue("TRANS_ID", fleM_INVESTORS.GetStringValue("INVESTOR") + QDesign.ASCII(fleM_INVESTORS.GetDecimalValue("TRANSACTION_NO"), 6));
					fleTRANS_HEADER.set_SetValue("LINE_DESCRIPTION", D_LINE_DESC.Value);
				}
			}
			fleCURRENT_ENTS_1.set_SetValue("TOP_UP_BAL", fleCURRENT_ENTS_1.GetDecimalValue("TOP_UP_BAL") + (T_TOT_TOP_UPS.Value));
			fleCURRENT_ENTS_2.set_SetValue("TOP_UP_BAL", fleCURRENT_ENTS_2.GetDecimalValue("TOP_UP_BAL") + T_TOT_TOP_UPS.Value);
			fleCURRENT_ENTS_3.set_SetValue("TOP_UP_BAL", fleCURRENT_ENTS_3.GetDecimalValue("TOP_UP_BAL") + T_TOT_TOP_UPS.Value);
			fleCURRENT_ENTS_1.set_SetValue("ENTITLEMENT_BAL", fleCURRENT_ENTS_1.GetDecimalValue("ENTITLEMENT_BAL") + (T_TOT_TOP_UPS.Value));
			fleCURRENT_ENTS_2.set_SetValue("ENTITLEMENT_BAL", fleCURRENT_ENTS_2.GetDecimalValue("ENTITLEMENT_BAL") + T_TOT_TOP_UPS.Value);
			if (QDesign.NULL(fleCURRENT_ENTS_3.GetStringValue("YEAR_123")) == "03") {
				if (0 >= (T_TOT_TOP_UPS.Value + fleCURRENT_ENTS_3.GetDecimalValue("ENT_OVERDRAFT"))) {
					fleCURRENT_ENTS_3.set_SetValue("ENT_OVERDRAFT", fleCURRENT_ENTS_3.GetDecimalValue("ENT_OVERDRAFT") + T_TOT_TOP_UPS.Value);
				} else {
					fleCURRENT_ENTS_3.set_SetValue("ENTITLEMENT_BAL", fleCURRENT_ENTS_3.GetDecimalValue("ENTITLEMENT_BAL") + (fleCURRENT_ENTS_3.GetDecimalValue("ENT_OVERDRAFT") + T_TOT_TOP_UPS.Value));
					fleCURRENT_ENTS_3.set_SetValue("ENT_OVERDRAFT", 0);
				}
			}
			fleANNUAL_ENT.set_SetValue("ANN_CURR_ENT", fleANNUAL_ENT.GetDecimalValue("ANN_CURR_ENT") + T_TOT_TOP_UPS.Value);
			fleANNUAL_ENT.set_SetValue("ANN_TOP_UP_ENT", fleANNUAL_ENT.GetDecimalValue("ANN_TOP_UP_ENT") + T_TOT_TOP_UPS.Value);
			fleANNUAL_ENT.set_SetValue("PP1_TOP_UP_ENT", fleANNUAL_ENT.GetDecimalValue("PP1_TOP_UP_ENT") + T_PP1_POINTS.Value);
			fleANNUAL_ENT.set_SetValue("PP1_SURCHARGEPER", (fleANNUAL_ENT.GetDecimalValue("PP1_TOP_UP_ENT") / fleANNUAL_ENT.GetDecimalValue("ANN_CURR_ENT")) * 10000);
			fleANNUAL_ENT.set_SetValue("PP2_TOP_UP_ENT", fleANNUAL_ENT.GetDecimalValue("PP2_TOP_UP_ENT") + T_PP2_POINTS.Value);
			fleANNUAL_ENT.set_SetValue("PP2_SURCHARGEPER", (fleANNUAL_ENT.GetDecimalValue("PP2_TOP_UP_ENT") / fleANNUAL_ENT.GetDecimalValue("ANN_CURR_ENT")) * 10000);
			fleANNUAL_ENT.set_SetValue("TERM_TOP_UP_ENT", fleANNUAL_ENT.GetDecimalValue("TERM_TOP_UP_ENT") + T_TERM_POINTS.Value);
			fleANNUAL_ENT.set_SetValue("BOND_TOP_UP_ENT", fleANNUAL_ENT.GetDecimalValue("BOND_TOP_UP_ENT") + T_BOND_POINTS.Value);
			if (QDesign.NULL(fleANNUAL_ENT.GetDecimalValue("TERM_TOP_UP_ENT")) > 0) {
                fleINVESTMENTS.set_SetValue("TERM_SURCHARGEPER", QDesign.Round((fleANNUAL_ENT.GetDecimalValue("TERM_TOP_UP_ENT") / fleANNUAL_ENT.GetDecimalValue("ANN_CURR_ENT")) * 2500, 0, RoundOptionTypes.Near));
			}
			if (QDesign.NULL(fleANNUAL_ENT.GetDecimalValue("TERM_TOP_UP_ENT")) > 0) {
				fleTERM_TOP_UPS.set_SetValue("TERM_SURCHARGEPER", QDesign.Round((fleANNUAL_ENT.GetDecimalValue("TERM_TOP_UP_ENT") / fleANNUAL_ENT.GetDecimalValue("ANN_CURR_ENT")) * 2500, 0, RoundOptionTypes.Near));
			}
			fleINVESTMENTS.set_SetValue("QUALIFY_28DAY", D_QUALIFY_28DAY.Value);
			fleINVESTMENTS.set_SetValue("TOP_UP_POINTS", fleINVESTMENTS.GetDecimalValue("TOP_UP_POINTS") + T_BOND_POINTS.Value + T_TERM_POINTS.Value + T_PP1_POINTS.Value + T_PP2_POINTS.Value);
			fleINVESTMENTS.set_SetValue("TOP_UP_AMOUNT", fleINVESTMENTS.GetDecimalValue("TOP_UP_AMOUNT") + T_BOND_AMOUNT.Value + T_TERM_POINTS.Value + T_PP1_AMOUNT.Value + T_PP2_AMOUNT.Value);
			fleINVESTMENTS.set_SetValue("PP1_POINTS", fleINVESTMENTS.GetDecimalValue("PP1_POINTS") + T_PP1_POINTS.Value);
			fleINVESTMENTS.set_SetValue("PP1_AMOUNT", fleINVESTMENTS.GetDecimalValue("PP1_AMOUNT") + T_PP1_AMOUNT.Value);
			fleINVESTMENTS.set_SetValue("PP2_POINTS", fleINVESTMENTS.GetDecimalValue("PP2_POINTS") + T_PP2_POINTS.Value);
			fleINVESTMENTS.set_SetValue("PP2_AMOUNT", fleINVESTMENTS.GetDecimalValue("PP2_AMOUNT") + T_PP2_AMOUNT.Value);

			return true;


		} catch (CustomApplicationException ex) {
			throw ex;


		} catch (Exception ex) {
			ExceptionManager.Publish(ex);
			throw ex;

		}

	}


        protected override bool PostUpdate()
        {


            try
            {

                while (fleTOP_UPS.For())
                {
                    if (QDesign.NULL(T_NEW_TOP_UPS.Value) == "Y")
                    {
                        fleTRANS_HEADER.PutData();
                        fleINVESTOR_TRANS_1.PutData();
                        fleINVESTOR_TRANS_2.PutData();
                        fleINVESTOR_TRANS_3.PutData();
                        fleANNUAL_TRANS.PutData();
                        fleINVESTOR_LETTERS.PutData();
                        if (QDesign.NULL(fleTOP_UPS.GetStringValue("TOP_UP_TYPE")) == "T")
                        {
                            fleTERM_TOP_UPS.PutData();
                        }
                    }
                }
                fleCURRENT_ENTS_1.PutData();
                fleCURRENT_ENTS_2.PutData();
                fleCURRENT_ENTS_3.PutData();

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

                // QDesign.NULL

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

        //#CORE_BEGIN_INCLUDE: SCRNVSTU.USE"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 07/12/2013 1:49:09 PM


        protected override bool Initialize()
        {


            try
            {

                object[] arrRunscreen = { T_SCREEN_NAME };
                RunScreen(new SCRNVST(), RunScreenModes.Entry, ref arrRunscreen);

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

        //#CORE_END_INCLUDE: SCRNVSTU.USE"



        protected override bool Find()
        {


            try
            {
                bool blnAddWhere = true;
                while (fleTOP_UPS.ForMissing())
                {
                    m_strWhere = new StringBuilder(GetWhereCondition(fleTOP_UPS.ElementOwner("INVESTOR"), fleM_INVESTORS.GetStringValue("INVESTOR"), ref blnAddWhere));
                    fleTOP_UPS.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
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
                Page.PageTitle = "T O P   U P S";



            }
            catch (CustomApplicationException ex)
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
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 07/12/2013 1:49:10 PM
        //#-----------------------------------------
        protected override bool Append()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:49:10 PM
                Accept(ref fldTOP_UPS_INVESTMENT_DATE);
                Accept(ref fldTOP_UPS_TOP_UP_AMOUNT);
                Accept(ref fldTOP_UPS_TOP_UP_TYPE);
                Accept(ref fldTOP_UPS_TOP_UP_POINTS);
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
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 07/12/2013 1:49:10 PM
        //#-----------------------------------------
        protected override bool Entry()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:49:10 PM
                Display(ref fldINVESTMENTS_HOLIDAY_ANNIV);
                Display(ref fldINVESTMENTS_INVESTMENT_DATE);
                Display(ref fldINVESTMENTS_INVEST_AMOUNT);
                Display(ref fldINVESTMENTS_INVEST_POINTS);
                Display(ref fldINVESTMENTS_TOP_UP_AMOUNT);
                Display(ref fldINVESTMENTS_TOP_UP_POINTS);
                Display(ref fldD_TOTAL_AMOUNT);
                Display(ref fldD_TOTAL_POINTS);
                Display(ref fldM_INVESTORS_COLOUR);
                Display(ref fldINVESTMENTS_PP1_AMOUNT);
                Display(ref fldINVESTMENTS_PP1_POINTS);
                Display(ref fldANNUAL_ENT_PP1_SURCHARGEPER);
                Display(ref fldINVESTMENTS_PP2_AMOUNT);
                Display(ref fldINVESTMENTS_PP2_POINTS);
                Display(ref fldANNUAL_ENT_PP2_SURCHARGEPER);
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
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 07/12/2013 1:49:10 PM
        //#-----------------------------------------
        protected override bool Update()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:49:10 PM
                fleM_INVESTORS.PutData(false, PutTypes.New);
                fleINVESTMENTS.PutData(false, PutTypes.New);
                fleUSER_SEC_FILE.PutData(false, PutTypes.New);
                fleANNUAL_ENT.PutData(false, PutTypes.New);
                while (fleTOP_UPS.For())
                {
                    fleTOP_UPS.PutData(false, PutTypes.Deleted);
                }
                while (fleTOP_UPS.For())
                {
                    fleTOP_UPS.PutData();
                }
                fleANNUAL_ENT.PutData();
                fleUSER_SEC_FILE.PutData();
                fleINVESTMENTS.PutData();
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
        //# dtlTOP_UPS_EditClick Procedure
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 07/12/2013 1:49:10 PM
        //#-----------------------------------------
        private void dtlTOP_UPS_EditClick(DataList source, GridButtonEventArgs GridButtonEventArgs)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:49:10 PM
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

        //#-----------------------------------------
        //# dsrDesigner_01_Click Procedure
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 07/12/2013 1:49:10 PM
        //#-----------------------------------------
        private void dsrDesigner_01_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:49:10 PM
                Accept(ref fldTOP_UPS_INVESTMENT_DATE);
                if (!fleTOP_UPS.NewRecord)
                {
                    Display(ref fldTOP_UPS_TOP_UP_AMOUNT);
                }
                else
                {
                    Accept(ref fldTOP_UPS_TOP_UP_AMOUNT);
                }
                if (!fleTOP_UPS.NewRecord)
                {
                    Display(ref fldTOP_UPS_TOP_UP_TYPE);
                }
                else
                {
                    Accept(ref fldTOP_UPS_TOP_UP_TYPE);
                }
                Accept(ref fldTOP_UPS_TOP_UP_POINTS);
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
