
#region "Screen Comments"

// ---------------------------------------------------------------:
// :
// SYSTEM:       Holiday Property Bond                         :
// :
// PROGRAM:      IVST0100                                      :
// :
// TASK:         MAINTAIN INVESTMENTS FOR INVESTOR
// :
// FILES:        INVESTMENTS        PRIMARY                    :
// ANNUAL-ENT         SECONDARY                  :
// CURRENT-ENTS (3)    DESIGNER                  :
// INVESTOR-TRANS (2)  DESIGNER                  ;
// ANNUAL-TRANS (2)    DESIGNER                  ;
// :
// SCREENS                                                     :
// CALLED BY:    IVST0000   MAIN INVESTMENT SCREEN             :
// ---------------------------------------------------------------:
// *01 17/10/94 : Create TRANS-HEADER records etc. for new Statement
// ----------------------------------------------------------------
// rob 20/05/96 - Year200 changes:
// - D-ANNIV-1 = date [5:2]
// - TRANS-YEAR-ID = INVESTOR-YEAR + TRANS-NO
// -------------------------------------------------------------------
// 24/05/96 - Charged d-year definitions to char*4
// -------------------------------------------------------------------
// 26/09/97 - Set TERM-SURCHARGEPER AND QUALIFY-28DAY
// Recieve file USER-SEC-FILE
// -------------------------------------------------------------------
// 23.06.03 - add trans-ym to investor-trans, trans-header, annual-trans
// -------------------------------------------------------------------
// 16.12.03 - phil - add cancellation screen
// -------------------------------------------------------------------
// 25/06/04 - Ingrid - d-invest-points = invest-amount + allowance for
// colour  D  as well as  G 
// ----------------------------------------------------------------
// 15/07/04 - temp hardcoded d-min-inv = 9045 if investor >= 69633
// ----------------------------------------------------------------
// 20.06.05 - ME - Unhard coded above, now use new field min-9000-inv.
// ----------------------------------------------------------------
// 22.02.06 - ME - put signonuser into trans-spare of trans-header
// ----------------------------------------------------------------
// 12.05.08 IM Increased pics to accommodate largest trans amounts
// and running balances (principally for Bond 75885)
// 18.09.12 RM  Add scrnvst to record visit to this screen
// ---------------------------------------------------------------
// 04.01.13 RC Changed heading from  INVESTED  to  INITIAL 
// ---------------------------------------------------------------
// ;NOAUTOUPDATE                        &;unix conv

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

    partial class IVST0100 : BasePage
    {

        #region " Form Designer Generated Code "





        public IVST0100()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "IVST0100";

            //# Set the ACTIVITIES for the screen.
            this.ChangeActivity = false;
            this.FindActivity = true;
            this.DeleteActivity = false;
            this.EntryActivity = true;
            this.UseAcceptProcessing = true;



        }

        #endregion

        private void Page_Load(object sender, RoutedEventArgs e)
        {
            SetVariables();
            
            fldINVESTMENTS_HOLIDAY_ANNIV.LookupNotOn += fldINVESTMENTS_HOLIDAY_ANNIV_LookupNotOn;
            fldINVESTMENTS_INVESTMENT_DATE.Input += fldINVESTMENTS_INVESTMENT_DATE_Input;
            fldINVESTMENTS_INVESTMENT_DATE.Process += fldINVESTMENTS_INVESTMENT_DATE_Process;
            fldINVESTMENTS_INVEST_AMOUNT.Process += fldINVESTMENTS_INVEST_AMOUNT_Process;
            fldINVESTMENTS_rma_ALLOWANCE.Process += fldINVESTMENTS_rma_ALLOWANCE_Process;
            dsrDesigner_01.Click += dsrDesigner_01_Click;

            Page_Load();

        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            T_SCREEN_NAME = new CoreCharacter("T_SCREEN_NAME", 20, this, ResetTypes.ResetAtStartup, "ivst0100.qks");
            fleM_INVESTORS = new OracleFileObject(this, FileTypes.Master, 0, "INDEXED", "M_INVESTORS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleUSER_SEC_FILE = new OracleFileObject(this, FileTypes.Master, 0, "INDEXED", "USER_SEC_FILE", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleINVESTMENTS = new OracleFileObject(this, FileTypes.Primary, 0, "INDEXED", "INVESTMENTS", "", true, false, false, 0, "m_trnTRANS_UPDATE");
            fleINVESTOR_LETTERS = new OracleFileObject(this, FileTypes.Designer, 0, "INDEXED", "INVESTOR_LETTERS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleANNUAL_ENT = new OracleFileObject(this, FileTypes.Secondary, 0, "INDEXED", "ANNUAL_ENT", "", true, false, false, 0, "m_trnTRANS_UPDATE");
            fleCANCEL_INVEST = new OracleFileObject(this, FileTypes.Reference, 0, "INDEXED", "CANCEL_INVEST", "", false, false, false, 0, "m_cnnQUERY");
            fleCURRENT_ENTS_1 = new OracleFileObject(this, FileTypes.Secondary, 0, "INDEXED", "CURRENT_ENTS", "CURRENT_ENTS_1", true, false, false, 0, "m_trnTRANS_UPDATE");
            fleCURRENT_ENTS_2 = new OracleFileObject(this, FileTypes.Secondary, 0, "INDEXED", "CURRENT_ENTS", "CURRENT_ENTS_2", true, false, false, 0, "m_trnTRANS_UPDATE");
            fleCURRENT_ENTS_3 = new OracleFileObject(this, FileTypes.Secondary, 0, "INDEXED", "CURRENT_ENTS", "CURRENT_ENTS_3", true, false, false, 0, "m_trnTRANS_UPDATE");
            fleTRANS_HEADER = new OracleFileObject(this, FileTypes.Designer, 0, "INDEXED", "TRANS_HEADER", "", true, false, false, 0, "m_trnTRANS_UPDATE");
            fleINVESTOR_TRANS_1 = new OracleFileObject(this, FileTypes.Audit, 0, "INDEXED", "INVESTOR_TRANS", "INVESTOR_TRANS_1", true, false, false, 0, "m_trnTRANS_UPDATE");
            fleINVESTOR_TRANS_2 = new OracleFileObject(this, FileTypes.Audit, 0, "INDEXED", "INVESTOR_TRANS", "INVESTOR_TRANS_2", true, false, false, 0, "m_trnTRANS_UPDATE");
            fleINVESTOR_TRANS_3 = new OracleFileObject(this, FileTypes.Audit, 0, "INDEXED", "INVESTOR_TRANS", "INVESTOR_TRANS_3", true, false, false, 0, "m_trnTRANS_UPDATE");
            fleANNUAL_TRANS = new OracleFileObject(this, FileTypes.Designer, 0, "INDEXED", "ANNUAL_TRANS", "", true, false, false, 0, "m_trnTRANS_UPDATE");
            T_ANNUAL_BALANCE = new CoreInteger("T_ANNUAL_BALANCE", 9, this);
            T_RUNNING_BALANCE = new CoreInteger("T_RUNNING_BALANCE", 9, this);
            T_INVEST_YEAR = new CoreDecimal("T_INVEST_YEAR", 2, this);
            T_INVEST_MONTH = new CoreDecimal("T_INVEST_MONTH", 2, this);
            T_BALANCE_FORWARD = new CoreDate("T_BALANCE_FORWARD", this);
            T_TOTAL_AMOUNT = new CoreInteger("T_TOTAL_AMOUNT", 9, this);
            T_SUBSCREEN = new CoreCharacter("T_SUBSCREEN", 1, this, Common.cEmptyString);
            T_YEAR = new CoreDecimal("T_YEAR", 2, this);
            T_ENTRY_MODE = new CoreCharacter("T_ENTRY_MODE", 1, this, Common.cEmptyString);

            fleANNUAL_ENT.Access += fleANNUAL_ENT_Access;
            fleCANCEL_INVEST.Access += fleCANCEL_INVEST_Access;
            D_YEAR.GetValue += D_YEAR_GetValue;
            D_YEAR_1.GetValue += D_YEAR_1_GetValue;
            D_YEAR_2.GetValue += D_YEAR_2_GetValue;
            D_YEAR_3.GetValue += D_YEAR_3_GetValue;
            D_END_1.GetValue += D_END_1_GetValue;
            D_YEAR_END_1.GetValue += D_YEAR_END_1_GetValue;
            D_END_2.GetValue += D_END_2_GetValue;
            D_YEAR_END_2.GetValue += D_YEAR_END_2_GetValue;
            D_END_3.GetValue += D_END_3_GetValue;
            D_YEAR_END_3.GetValue += D_YEAR_END_3_GetValue;
            D_ANNIV_1.GetValue += D_ANNIV_1_GetValue;
            D_ANNIV.GetValue += D_ANNIV_GetValue;
            fleCURRENT_ENTS_1.Access += fleCURRENT_ENTS_1_Access;
            fleCURRENT_ENTS_2.Access += fleCURRENT_ENTS_2_Access;
            fleCURRENT_ENTS_3.Access += fleCURRENT_ENTS_3_Access;
            D_COLOUR.GetValue += D_COLOUR_GetValue;
            D_INVEST_POINTS.GetValue += D_INVEST_POINTS_GetValue;
            D_TOTAL_AMOUNT.GetValue += D_TOTAL_AMOUNT_GetValue;
            D_RUNNING_BALANCE.GetValue += D_RUNNING_BALANCE_GetValue;
            D_ANNUAL_BALANCE.GetValue += D_ANNUAL_BALANCE_GetValue;
            D_LINE_DESCRIPTION.GetValue += D_LINE_DESCRIPTION_GetValue;
            D_MIN_INV.GetValue += D_MIN_INV_GetValue;
            D_CANCEL_DATE.GetValue += D_CANCEL_DATE_GetValue;
            fleINVESTMENTS.SetItemFinals += fleINVESTMENTS_SetItemFinals;
            fleINVESTOR_LETTERS.SetItemFinals += fleINVESTOR_LETTERS_SetItemFinals;
            fleANNUAL_ENT.SetItemFinals += fleANNUAL_ENT_SetItemFinals;
            fleCURRENT_ENTS_1.SetItemFinals += fleCURRENT_ENTS_1_SetItemFinals;
            fleCURRENT_ENTS_2.SetItemFinals += fleCURRENT_ENTS_2_SetItemFinals;
            fleCURRENT_ENTS_3.SetItemFinals += fleCURRENT_ENTS_3_SetItemFinals;
            fleTRANS_HEADER.SetItemFinals += fleTRANS_HEADER_SetItemFinals;
            fleINVESTOR_TRANS_1.SetItemFinals += fleINVESTOR_TRANS_1_SetItemFinals;
            fleINVESTOR_TRANS_2.SetItemFinals += fleINVESTOR_TRANS_2_SetItemFinals;
            fleINVESTOR_TRANS_3.SetItemFinals += fleINVESTOR_TRANS_3_SetItemFinals;
            fleANNUAL_TRANS.SetItemFinals += fleANNUAL_TRANS_SetItemFinals;
        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;
            fleANNUAL_ENT.Access -= fleANNUAL_ENT_Access;
            fleCANCEL_INVEST.Access -= fleCANCEL_INVEST_Access;
            D_YEAR.GetValue -= D_YEAR_GetValue;
            D_YEAR_1.GetValue -= D_YEAR_1_GetValue;
            D_YEAR_2.GetValue -= D_YEAR_2_GetValue;
            D_YEAR_3.GetValue -= D_YEAR_3_GetValue;
            D_END_1.GetValue -= D_END_1_GetValue;
            D_YEAR_END_1.GetValue -= D_YEAR_END_1_GetValue;
            D_END_2.GetValue -= D_END_2_GetValue;
            D_YEAR_END_2.GetValue -= D_YEAR_END_2_GetValue;
            D_END_3.GetValue -= D_END_3_GetValue;
            D_YEAR_END_3.GetValue -= D_YEAR_END_3_GetValue;
            D_ANNIV_1.GetValue -= D_ANNIV_1_GetValue;
            D_ANNIV.GetValue -= D_ANNIV_GetValue;
            fleCURRENT_ENTS_1.Access -= fleCURRENT_ENTS_1_Access;
            fleCURRENT_ENTS_2.Access -= fleCURRENT_ENTS_2_Access;
            fleCURRENT_ENTS_3.Access -= fleCURRENT_ENTS_3_Access;
            D_COLOUR.GetValue -= D_COLOUR_GetValue;
            D_INVEST_POINTS.GetValue -= D_INVEST_POINTS_GetValue;
            D_TOTAL_AMOUNT.GetValue -= D_TOTAL_AMOUNT_GetValue;
            D_RUNNING_BALANCE.GetValue -= D_RUNNING_BALANCE_GetValue;
            D_ANNUAL_BALANCE.GetValue -= D_ANNUAL_BALANCE_GetValue;
            D_LINE_DESCRIPTION.GetValue -= D_LINE_DESCRIPTION_GetValue;
            D_MIN_INV.GetValue -= D_MIN_INV_GetValue;
            D_CANCEL_DATE.GetValue -= D_CANCEL_DATE_GetValue;
            fldINVESTMENTS_HOLIDAY_ANNIV.LookupNotOn -= fldINVESTMENTS_HOLIDAY_ANNIV_LookupNotOn;
            fldINVESTMENTS_INVESTMENT_DATE.Input -= fldINVESTMENTS_INVESTMENT_DATE_Input;
            fldINVESTMENTS_INVESTMENT_DATE.Process -= fldINVESTMENTS_INVESTMENT_DATE_Process;
            fldINVESTMENTS_INVEST_AMOUNT.Process -= fldINVESTMENTS_INVEST_AMOUNT_Process;
            fldINVESTMENTS_rma_ALLOWANCE.Process -= fldINVESTMENTS_rma_ALLOWANCE_Process;
            dsrDesigner_01.Click -= dsrDesigner_01_Click;
            fleANNUAL_ENT.SetItemFinals += fleANNUAL_ENT_SetItemFinals;
            fleCURRENT_ENTS_1.SetItemFinals += fleCURRENT_ENTS_1_SetItemFinals;
            fleCURRENT_ENTS_2.SetItemFinals += fleCURRENT_ENTS_2_SetItemFinals;
            fleCURRENT_ENTS_3.SetItemFinals += fleCURRENT_ENTS_3_SetItemFinals;
            fleTRANS_HEADER.SetItemFinals += fleTRANS_HEADER_SetItemFinals;
            fleINVESTOR_TRANS_1.SetItemFinals += fleINVESTOR_TRANS_1_SetItemFinals;
            fleINVESTOR_TRANS_2.SetItemFinals += fleINVESTOR_TRANS_2_SetItemFinals;
            fleINVESTOR_TRANS_3.SetItemFinals += fleINVESTOR_TRANS_3_SetItemFinals;
            fleANNUAL_TRANS.SetItemFinals += fleANNUAL_TRANS_SetItemFinals;


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
        private OracleFileObject fleUSER_SEC_FILE;
        private OracleFileObject fleINVESTMENTS;

        private void fleINVESTMENTS_SetItemFinals()
        {

            try
            {
                fleINVESTMENTS.set_SetValue("INVESTOR", fleM_INVESTORS.GetStringValue("INVESTOR"));


            }
            catch (CustomApplicationException ex)
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
                fleINVESTOR_LETTERS.set_SetValue("INVESTOR", fleM_INVESTORS.GetStringValue("INVESTOR"));
                fleINVESTOR_LETTERS.set_SetValue("RECORD_STATUS", "NI");


            }
            catch (CustomApplicationException ex)
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



        private void fleANNUAL_ENT_SetItemFinals()
        {

            try
            {
                fleANNUAL_ENT.set_SetValue("HOLIDAY_ANNIV", fleINVESTMENTS.GetStringValue("HOLIDAY_ANNIV"));
                fleANNUAL_ENT.set_SetValue("INVESTOR", fleM_INVESTORS.GetStringValue("INVESTOR"));


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }

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

        private DCharacter D_YEAR = new DCharacter(4);
        private void D_YEAR_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;

                // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

                if (QDesign.NULL(fleINVESTMENTS.GetStringValue("HOLIDAY_ANNIV")) != QDesign.NULL("01"))
                {
                    CurrentValue = QDesign.ASCII(fleINVESTMENTS.GetDecimalValue("INVESTMENT_DATE") / 1000);
                }
                else if (QDesign.NULL(fleINVESTMENTS.GetStringValue("HOLIDAY_ANNIV")) == QDesign.NULL("01"))
                {
                    CurrentValue = QDesign.ASCII((fleINVESTMENTS.GetDecimalValue("INVESTMENT_DATE") + 10000) / 1000);
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
        private DCharacter D_YEAR_1 = new DCharacter(4);
        private void D_YEAR_1_GetValue(ref string Value)
        {

            try
            {
                Value = D_YEAR.Value;


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DCharacter D_YEAR_2 = new DCharacter(4);
        private void D_YEAR_2_GetValue(ref string Value)
        {

            try
            {
                Value = QDesign.ASCII(QDesign.NConvert(D_YEAR.Value) + 1);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DCharacter D_YEAR_3 = new DCharacter(4);
        private void D_YEAR_3_GetValue(ref string Value)
        {

            try
            {
                Value = QDesign.ASCII(QDesign.NConvert(D_YEAR.Value) + 2);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DDecimal D_END_1 = new DDecimal();
        private void D_END_1_GetValue(ref decimal Value)
        {

            try
            {
                Value = QDesign.NConvert(QDesign.ASCII(QDesign.NConvert(D_YEAR_1.Value) + 1) + fleINVESTMENTS.GetStringValue("HOLIDAY_ANNIV") + "01");


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DDecimal D_YEAR_END_1 = new DDecimal();
        private void D_YEAR_END_1_GetValue(ref decimal Value)
        {

            try
            {
                Value = QDesign.PhDate(QDesign.Days(D_END_1.Value) - 1);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DDecimal D_END_2 = new DDecimal();
        private void D_END_2_GetValue(ref decimal Value)
        {

            try
            {
                Value = QDesign.NConvert(QDesign.ASCII(QDesign.NConvert(D_YEAR_2.Value) + 1) + fleINVESTMENTS.GetStringValue("HOLIDAY_ANNIV") + "01");


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DDecimal D_YEAR_END_2 = new DDecimal();
        private void D_YEAR_END_2_GetValue(ref decimal Value)
        {

            try
            {
                Value = QDesign.PhDate(QDesign.Days(D_END_2.Value) - 1);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DDecimal D_END_3 = new DDecimal();
        private void D_END_3_GetValue(ref decimal Value)
        {

            try
            {
                Value = QDesign.NConvert(QDesign.ASCII(QDesign.NConvert(D_YEAR_3.Value) + 1) + fleINVESTMENTS.GetStringValue("HOLIDAY_ANNIV") + "01");


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DDecimal D_YEAR_END_3 = new DDecimal();
        private void D_YEAR_END_3_GetValue(ref decimal Value)
        {

            try
            {
                Value = QDesign.PhDate(QDesign.Days(D_END_3.Value) - 1);


            }
            catch (CustomApplicationException ex)
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
                Value = QDesign.Substring(QDesign.ASCII(fleINVESTMENTS.GetDecimalValue("INVESTMENT_DATE") + 100), 5, 2);


            }
            catch (CustomApplicationException ex)
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
                if (QDesign.NULL(D_ANNIV_1.Value) == QDesign.NULL("13"))
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



        private void fleCURRENT_ENTS_1_SetItemFinals()
        {

            try
            {
                fleCURRENT_ENTS_1.set_SetValue("FILLER_8", fleM_INVESTORS.GetStringValue("INVESTOR") + D_YEAR_1.Value);
                //Parent:INVESTOR_YEAR
                fleCURRENT_ENTS_1.set_SetValue("YEAR", (fleM_INVESTORS.GetStringValue("INVESTOR") + D_YEAR_1.Value).PadRight(12).Substring(8, 4));
                //Parent:INVESTOR_YEAR
                fleCURRENT_ENTS_1.set_SetValue("FILL_8", fleM_INVESTORS.GetStringValue("INVESTOR") + "01");
                //Parent:INVESTOR_123
                fleCURRENT_ENTS_1.set_SetValue("YEAR_123", (fleM_INVESTORS.GetStringValue("INVESTOR") + "01").PadRight(10).Substring(8, 2));
                //Parent:INVESTOR_123
                fleCURRENT_ENTS_1.set_SetValue("INVESTOR", fleM_INVESTORS.GetStringValue("INVESTOR"));
                fleCURRENT_ENTS_1.set_SetValue("HOLIDAY_ANNIV", fleINVESTMENTS.GetStringValue("HOLIDAY_ANNIV"));
                fleCURRENT_ENTS_1.set_SetValue("YEAR_END_DATE", D_YEAR_END_1.Value);
                fleCURRENT_ENTS_1.set_SetValue("ENT_INITIAL", fleINVESTMENTS.GetDecimalValue("INVEST_POINTS"));


            }
            catch (CustomApplicationException ex)
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



        private void fleCURRENT_ENTS_2_SetItemFinals()
        {

            try
            {
                fleCURRENT_ENTS_2.set_SetValue("FILLER_8", fleM_INVESTORS.GetStringValue("INVESTOR") + D_YEAR_2.Value);
                //Parent:INVESTOR_YEAR
                fleCURRENT_ENTS_2.set_SetValue("YEAR", (fleM_INVESTORS.GetStringValue("INVESTOR") + D_YEAR_2.Value).PadRight(12).Substring(8, 4));
                //Parent:INVESTOR_YEAR
                fleCURRENT_ENTS_2.set_SetValue("FILL_8", fleM_INVESTORS.GetStringValue("INVESTOR") + "02");
                //Parent:INVESTOR_123
                fleCURRENT_ENTS_2.set_SetValue("YEAR_123", (fleM_INVESTORS.GetStringValue("INVESTOR") + "02").PadRight(10).Substring(8, 2));
                //Parent:INVESTOR_123
                fleCURRENT_ENTS_2.set_SetValue("INVESTOR", fleM_INVESTORS.GetStringValue("INVESTOR"));
                fleCURRENT_ENTS_2.set_SetValue("HOLIDAY_ANNIV", fleINVESTMENTS.GetStringValue("HOLIDAY_ANNIV"));
                fleCURRENT_ENTS_2.set_SetValue("YEAR_END_DATE", D_YEAR_END_2.Value);
                fleCURRENT_ENTS_2.set_SetValue("ENT_INITIAL", fleINVESTMENTS.GetDecimalValue("INVEST_POINTS"));


            }
            catch (CustomApplicationException ex)
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



        private void fleCURRENT_ENTS_3_SetItemFinals()
        {

            try
            {
                fleCURRENT_ENTS_3.set_SetValue("FILLER_8", fleM_INVESTORS.GetStringValue("INVESTOR") + D_YEAR_3.Value);
                //Parent:INVESTOR_YEAR
                fleCURRENT_ENTS_3.set_SetValue("YEAR", (fleM_INVESTORS.GetStringValue("INVESTOR") + D_YEAR_3.Value).PadRight(12).Substring(8, 4));
                //Parent:INVESTOR_YEAR
                fleCURRENT_ENTS_3.set_SetValue("FILL_8", fleM_INVESTORS.GetStringValue("INVESTOR") + "03");
                //Parent:INVESTOR_123
                fleCURRENT_ENTS_3.set_SetValue("YEAR_123", (fleM_INVESTORS.GetStringValue("INVESTOR") + "03").PadRight(10).Substring(8, 2));
                //Parent:INVESTOR_123
                fleCURRENT_ENTS_3.set_SetValue("INVESTOR", fleM_INVESTORS.GetStringValue("INVESTOR"));
                fleCURRENT_ENTS_3.set_SetValue("HOLIDAY_ANNIV", fleINVESTMENTS.GetStringValue("HOLIDAY_ANNIV"));
                fleCURRENT_ENTS_3.set_SetValue("YEAR_END_DATE", D_YEAR_END_3.Value);
                fleCURRENT_ENTS_3.set_SetValue("ENT_INITIAL", fleINVESTMENTS.GetDecimalValue("INVEST_POINTS"));


            }
            catch (CustomApplicationException ex)
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
                fleTRANS_HEADER.set_SetValue("TRANS_TYPE", "IV");
                fleTRANS_HEADER.set_SetValue("TRANS_STATUS", "WP");
                fleTRANS_HEADER.set_SetValue("ON_STATEMENT", "Y");
                fleTRANS_HEADER.set_SetValue("TRANSACT_DATE", QDesign.SysDate(ref m_cnnQUERY));
                fleTRANS_HEADER.set_SetValue("TRANS_YM", QDesign.Substring(QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8), 1, 6));
                fleTRANS_HEADER.set_SetValue("TRANS_SPARE", UserID);
                fleTRANS_HEADER.set_SetValue("LINE_DESCRIPTION", "Initial Entitlement");


            }
            catch (CustomApplicationException ex)
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
                fleINVESTOR_TRANS_1.set_SetValue("FILLER_8", fleM_INVESTORS.GetStringValue("INVESTOR") + D_YEAR_1.Value);
                //Parent:INVESTOR_YEAR
                fleINVESTOR_TRANS_1.set_SetValue("YEAR", (fleM_INVESTORS.GetStringValue("INVESTOR") + D_YEAR_1.Value).PadRight(12).Substring(8, 4));
                //Parent:INVESTOR_YEAR
                fleINVESTOR_TRANS_1.set_SetValue("FILLER_81", fleTRANS_HEADER.GetStringValue("FILLER"));
                //Parent:TRANS_ID
                fleINVESTOR_TRANS_1.set_SetValue("TRANS_NO", fleTRANS_HEADER.GetStringValue("TRANS_NO"));
                //Parent:TRANS_ID    'Parent:TRANS_ID
                fleINVESTOR_TRANS_1.set_SetValue("TRANS_YEAR_ID", fleINVESTOR_TRANS_1.GetStringValue("FILLER_8") + fleINVESTOR_TRANS_1.GetStringValue("YEAR") + fleTRANS_HEADER.GetStringValue("TRANS_NO"));
                //Parent:INVESTOR_YEAR
                fleINVESTOR_TRANS_1.set_SetValue("TRANSACT_TYPE", "ENT");
                fleINVESTOR_TRANS_1.set_SetValue("TRANSACT_VALUE", fleINVESTMENTS.GetDecimalValue("INVEST_POINTS"));
                fleINVESTOR_TRANS_1.set_SetValue("RUNNING_BALANCE", fleINVESTMENTS.GetDecimalValue("INVEST_POINTS"));
                fleINVESTOR_TRANS_1.set_SetValue("ENT_VAL", fleINVESTMENTS.GetDecimalValue("INVEST_POINTS"));
                fleINVESTOR_TRANS_1.set_SetValue("ENT_RBAL", fleINVESTMENTS.GetDecimalValue("INVEST_POINTS"));
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
                fleINVESTOR_TRANS_2.set_SetValue("FILLER_8", fleM_INVESTORS.GetStringValue("INVESTOR") + D_YEAR_2.Value);
                //Parent:INVESTOR_YEAR
                fleINVESTOR_TRANS_2.set_SetValue("YEAR", (fleM_INVESTORS.GetStringValue("INVESTOR") + D_YEAR_2.Value).PadRight(12).Substring(8, 4));
                //Parent:INVESTOR_YEAR
                fleINVESTOR_TRANS_2.set_SetValue("FILLER_81", fleTRANS_HEADER.GetStringValue("FILLER"));
                //Parent:TRANS_ID
                fleINVESTOR_TRANS_2.set_SetValue("TRANS_NO", fleTRANS_HEADER.GetStringValue("TRANS_NO"));
                //Parent:TRANS_ID    'Parent:TRANS_ID
                fleINVESTOR_TRANS_2.set_SetValue("TRANS_YEAR_ID", fleINVESTOR_TRANS_2.GetStringValue("FILLER_8") + fleINVESTOR_TRANS_2.GetStringValue("YEAR") + fleTRANS_HEADER.GetStringValue("TRANS_NO"));
                //Parent:INVESTOR_YEAR
                fleINVESTOR_TRANS_2.set_SetValue("TRANSACT_TYPE", "ENT");
                fleINVESTOR_TRANS_2.set_SetValue("TRANSACT_VALUE", fleINVESTMENTS.GetDecimalValue("INVEST_POINTS"));
                fleINVESTOR_TRANS_2.set_SetValue("RUNNING_BALANCE", fleINVESTMENTS.GetDecimalValue("INVEST_POINTS"));
                fleINVESTOR_TRANS_2.set_SetValue("ENT_VAL", fleINVESTMENTS.GetDecimalValue("INVEST_POINTS"));
                fleINVESTOR_TRANS_2.set_SetValue("ENT_RBAL", fleINVESTMENTS.GetDecimalValue("INVEST_POINTS"));
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
                fleINVESTOR_TRANS_3.set_SetValue("FILLER_8", fleM_INVESTORS.GetStringValue("INVESTOR") + D_YEAR_3.Value);
                //Parent:INVESTOR_YEAR
                fleINVESTOR_TRANS_3.set_SetValue("YEAR", (fleM_INVESTORS.GetStringValue("INVESTOR") + D_YEAR_3.Value).PadRight(12).Substring(8, 4));
                //Parent:INVESTOR_YEAR
                fleINVESTOR_TRANS_3.set_SetValue("FILLER_81", fleTRANS_HEADER.GetStringValue("FILLER"));
                //Parent:TRANS_ID
                fleINVESTOR_TRANS_3.set_SetValue("TRANS_NO", fleTRANS_HEADER.GetStringValue("TRANS_NO"));
                //Parent:TRANS_ID    'Parent:TRANS_ID
                fleINVESTOR_TRANS_3.set_SetValue("TRANS_YEAR_ID", fleINVESTOR_TRANS_3.GetStringValue("FILLER_8") + fleINVESTOR_TRANS_3.GetStringValue("YEAR") + fleTRANS_HEADER.GetStringValue("TRANS_NO"));
                //Parent:INVESTOR_YEAR
                fleINVESTOR_TRANS_3.set_SetValue("TRANSACT_TYPE", "ENT");
                fleINVESTOR_TRANS_3.set_SetValue("TRANSACT_VALUE", fleINVESTMENTS.GetDecimalValue("INVEST_POINTS"));
                fleINVESTOR_TRANS_3.set_SetValue("RUNNING_BALANCE", fleINVESTMENTS.GetDecimalValue("INVEST_POINTS"));
                fleINVESTOR_TRANS_3.set_SetValue("ENT_VAL", fleINVESTMENTS.GetDecimalValue("INVEST_POINTS"));
                fleINVESTOR_TRANS_3.set_SetValue("ENT_RBAL", fleINVESTMENTS.GetDecimalValue("INVEST_POINTS"));
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
                fleANNUAL_TRANS.set_SetValue("TRANSACT_TYPE", "ENT");
                fleANNUAL_TRANS.set_SetValue("TRANSACT_VALUE", fleINVESTMENTS.GetDecimalValue("INVEST_POINTS"));
                fleANNUAL_TRANS.set_SetValue("RUNNING_BALANCE", fleINVESTMENTS.GetDecimalValue("INVEST_POINTS"));
                fleANNUAL_TRANS.set_SetValue("HOLIDAY_ANNIV", fleINVESTMENTS.GetStringValue("HOLIDAY_ANNIV"));
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

        private CoreInteger T_ANNUAL_BALANCE;
        private CoreInteger T_RUNNING_BALANCE;
        private CoreDecimal T_INVEST_YEAR;
        private CoreDecimal T_INVEST_MONTH;
        private CoreDate T_BALANCE_FORWARD;
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

                if ((QDesign.NULL(fleM_INVESTORS.GetStringValue("COLOUR")) == QDesign.NULL("G") || QDesign.NULL(fleM_INVESTORS.GetStringValue("COLOUR")) == QDesign.NULL("D")))
                {
                    CurrentValue = fleINVESTMENTS.GetDecimalValue("INVEST_AMOUNT") + fleINVESTMENTS.GetDecimalValue("rma_ALLOWANCE");
                }
                else
                {
                    CurrentValue = QDesign.Floor((((fleINVESTMENTS.GetDecimalValue("INVEST_AMOUNT") + fleINVESTMENTS.GetDecimalValue("rma_ALLOWANCE")) * (decimal)2) / (decimal)3) + (decimal)0.5);
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
        private DInteger D_RUNNING_BALANCE = new DInteger(9);
        private void D_RUNNING_BALANCE_GetValue(ref decimal Value)
        {

            try
            {
                Value = T_RUNNING_BALANCE.Value + fleINVESTMENTS.GetDecimalValue("INVEST_POINTS");


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DInteger D_ANNUAL_BALANCE = new DInteger(9);
        private void D_ANNUAL_BALANCE_GetValue(ref decimal Value)
        {

            try
            {
                Value = T_ANNUAL_BALANCE.Value + fleINVESTMENTS.GetDecimalValue("INVEST_POINTS");


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DCharacter D_LINE_DESCRIPTION = new DCharacter(30);
        private void D_LINE_DESCRIPTION_GetValue(ref string Value)
        {

            try
            {
                Value = "Initial Entitlement";


            }
            catch (CustomApplicationException ex)
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
        private DCharacter D_CANCEL_DATE = new DCharacter(10);
        private void D_CANCEL_DATE_GetValue(ref string Value)
        {

            try
            {

                // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

                Value = QDesign.ASCII(QDesign.DateExtract(fleCANCEL_INVEST.GetDecimalValue("CANCEL_DATE"), "0002"), 2) + "/" + QDesign.ASCII(QDesign.DateExtract(fleCANCEL_INVEST.GetDecimalValue("CANCEL_DATE"), "0005"), 2) + "/" + QDesign.ASCII(QDesign.DateExtract(fleCANCEL_INVEST.GetDecimalValue("CANCEL_DATE"), "0008"), 4);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private CoreInteger T_TOTAL_AMOUNT;
        private CoreCharacter T_SUBSCREEN;
        private CoreDecimal T_YEAR;

        private CoreCharacter T_ENTRY_MODE;
        #endregion

        #region "Standard Generated Procedures"

        #region "Grid Field Declarations"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 07/12/2013 1:48:57 PM

        //# No code was generated or needed for this region.

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 07/12/2013 1:48:57 PM

        //# No code was generated or needed for this region.

        #endregion

        #region "Transaction Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 07/12/2013 1:48:57 PM

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
            fleINVESTMENTS.Transaction = m_trnTRANS_UPDATE;
            fleINVESTOR_LETTERS.Transaction = m_trnTRANS_UPDATE;
            fleANNUAL_ENT.Transaction = m_trnTRANS_UPDATE;
            fleCURRENT_ENTS_1.Transaction = m_trnTRANS_UPDATE;
            fleCURRENT_ENTS_2.Transaction = m_trnTRANS_UPDATE;
            fleCURRENT_ENTS_3.Transaction = m_trnTRANS_UPDATE;
            fleTRANS_HEADER.Transaction = m_trnTRANS_UPDATE;
            fleINVESTOR_TRANS_1.Transaction = m_trnTRANS_UPDATE;
            fleINVESTOR_TRANS_2.Transaction = m_trnTRANS_UPDATE;
            fleINVESTOR_TRANS_3.Transaction = m_trnTRANS_UPDATE;
            fleANNUAL_TRANS.Transaction = m_trnTRANS_UPDATE;


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 07/12/2013 1:48:57 PM

        //#-----------------------------------------
        //# InitializeFiles Procedure.
        //#-----------------------------------------

        protected override void InitializeFiles()
        {

            try
            {
                Initialize_TRANS_UPDATE();
                fleCANCEL_INVEST.Connection = m_cnnQUERY;


            }
            catch (CustomApplicationException ex)
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
                fleINVESTMENTS.Dispose();
                fleINVESTOR_LETTERS.Dispose();
                fleANNUAL_ENT.Dispose();
                fleCANCEL_INVEST.Dispose();
                fleCURRENT_ENTS_1.Dispose();
                fleCURRENT_ENTS_2.Dispose();
                fleCURRENT_ENTS_3.Dispose();
                fleTRANS_HEADER.Dispose();
                fleINVESTOR_TRANS_1.Dispose();
                fleINVESTOR_TRANS_2.Dispose();
                fleINVESTOR_TRANS_3.Dispose();
                fleANNUAL_TRANS.Dispose();


            }
            catch (CustomApplicationException ex)
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
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 07/12/2013 1:48:57 PM
        //#-----------------------------------------
        protected override void DisplayFormatting()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:48:57 PM
                Display(ref fldINVESTMENTS_HOLIDAY_ANNIV);
                Display(ref fldINVESTMENTS_INVESTMENT_DATE);
                Display(ref fldINVESTMENTS_METHOD);
                Display(ref fldINVESTMENTS_INVEST_AMOUNT);
                Display(ref fldINVESTMENTS_rma_ALLOWANCE);
                Display(ref fldINVESTMENTS_INVEST_POINTS);
                Display(ref fldINVESTMENTS_TOP_UP_AMOUNT);
                Display(ref fldINVESTMENTS_TOP_UP_POINTS);
                Display(ref fldD_TOTAL_AMOUNT);
                Display(ref fldT_SUBSCREEN);
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
        //# Do not delete, modify or move it.  Updated: 07/12/2013 1:48:57 PM

        //#-----------------------------------------
        //# BindFields Procedure.
        //#-----------------------------------------

        public override void BindFields()
        {
            try
            {
                fldINVESTMENTS_HOLIDAY_ANNIV.Bind(fleINVESTMENTS);
                fldINVESTMENTS_INVESTMENT_DATE.Bind(fleINVESTMENTS);
                fldINVESTMENTS_METHOD.Bind(fleINVESTMENTS);
                fldINVESTMENTS_INVEST_AMOUNT.Bind(fleINVESTMENTS);
                fldINVESTMENTS_rma_ALLOWANCE.Bind(fleINVESTMENTS);
                fldINVESTMENTS_INVEST_POINTS.Bind(fleINVESTMENTS);
                fldINVESTMENTS_TOP_UP_AMOUNT.Bind(fleINVESTMENTS);
                fldINVESTMENTS_TOP_UP_POINTS.Bind(fleINVESTMENTS);
                fldD_TOTAL_AMOUNT.Bind(D_TOTAL_AMOUNT);
                fldT_SUBSCREEN.Bind(T_SUBSCREEN);

            }
            catch (CustomApplicationException ex)
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



        private void fldINVESTMENTS_HOLIDAY_ANNIV_LookupNotOn(ref bool LookupNotOnExecuted)
        {

            try
            {
                bool blnAlreadyExists = false;
                StringBuilder strSQL = new StringBuilder("SELECT ").Append(fleINVESTMENTS.ElementOwner("INVESTOR"));
                strSQL.Append(" FROM ");
                strSQL.Append(fleINVESTMENTS.TableNameWithAlias());
                strSQL.Append(" WHERE ");
                strSQL.Append("     ").Append(fleINVESTMENTS.ElementOwner("INVESTOR")).Append(" = ").Append(Common.StringToField(fleM_INVESTORS.GetStringValue("INVESTOR")));

                if (!LookupNotOn(strSQL, fleINVESTMENTS, "INVESTOR", fleM_INVESTORS.GetStringValue("INVESTOR")))
                {
                    blnAlreadyExists = true;
                }

                if (blnAlreadyExists)
                {
                    ErrorMessage("0");
                    // "Main investment exists - use top-up screen"
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
                SaveReceivingParams(fleM_INVESTORS, fleUSER_SEC_FILE);


            }
            catch (CustomApplicationException ex)
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
                Receiving(fleM_INVESTORS, fleUSER_SEC_FILE);


            }
            catch (CustomApplicationException ex)
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


        private void fldINVESTMENTS_INVESTMENT_DATE_Input()
        {

            try
            {

                //#CORE_BEGIN_INCLUDE: DATECENT.USE"

                //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
                //# Do not delete, modify or move it.  Updated: 07/12/2013 1:48:55 PM

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


        private void fldINVESTMENTS_INVESTMENT_DATE_Process()
        {

            try
            {

                if (QDesign.NULL(fleINVESTMENTS.GetStringValue("HOLIDAY_ANNIV")) != QDesign.NULL(D_ANNIV.Value))
                {
                    Severe("52121");
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



        private void fldINVESTMENTS_INVEST_AMOUNT_Process()
        {

            try
            {

                if (EntryMode || CorrectMode || ChangeMode)
                {
                    fleINVESTMENTS.set_SetValue("INVEST_POINTS", D_INVEST_POINTS.Value);
                    Display(ref fldINVESTMENTS_INVEST_POINTS);
                    Display(ref fldD_TOTAL_AMOUNT);
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



        private void fldINVESTMENTS_rma_ALLOWANCE_Process()
        {

            try
            {

                if (EntryMode || CorrectMode || ChangeMode)
                {
                    fleINVESTMENTS.set_SetValue("INVEST_POINTS", D_INVEST_POINTS.Value);
                    Display(ref fldINVESTMENTS_INVEST_POINTS);
                    Display(ref fldD_TOTAL_AMOUNT);
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

                if (QDesign.NULL(fleINVESTMENTS.GetStringValue("HOLIDAY_ANNIV")) != QDesign.NULL(D_ANNIV.Value))
                {
                    Severe("52121");
                }
                if (QDesign.NULL(T_ENTRY_MODE.Value) == "Y")
                {
                    fleANNUAL_TRANS.set_SetValue("LINE_DESCRIPTION", D_LINE_DESCRIPTION.Value);
                    fleINVESTOR_TRANS_1.set_SetValue("LINE_DESCRIPTION", D_LINE_DESCRIPTION.Value);
                    fleINVESTOR_TRANS_2.set_SetValue("LINE_DESCRIPTION", D_LINE_DESCRIPTION.Value);
                    fleINVESTOR_TRANS_3.set_SetValue("LINE_DESCRIPTION", D_LINE_DESCRIPTION.Value);
                    fleANNUAL_ENT.set_SetValue("ANN_CURR_ENT", fleINVESTMENTS.GetDecimalValue("INVEST_POINTS"));
                    if (fleANNUAL_ENT.GetDecimalValue("ANN_CURR_ENT") >= D_MIN_INV.Value)
                    {
                        fleINVESTMENTS.set_SetValue("QUALIFY_28DAY", "Y");
                    }
                    else
                    {
                        fleINVESTMENTS.set_SetValue("QUALIFY_28DAY", "N");
                    }
                    fleM_INVESTORS.set_SetValue("TRANSACTION_NO", fleM_INVESTORS.GetDecimalValue("TRANSACTION_NO") + 1);
                    fleTRANS_HEADER.set_SetValue("FILLER", fleM_INVESTORS.GetStringValue("INVESTOR") + QDesign.ASCII(fleM_INVESTORS.GetDecimalValue("TRANSACTION_NO"), 6));
                    //Parent:TRANS_ID
                    fleTRANS_HEADER.set_SetValue("TRANS_NO", (fleM_INVESTORS.GetStringValue("INVESTOR") + QDesign.ASCII(fleM_INVESTORS.GetDecimalValue("TRANSACTION_NO"), 6)).PadRight(14).Substring(8, 6));
                    //Parent:TRANS_ID
                    fleCURRENT_ENTS_1.set_SetValue("ENTITLEMENT_BAL", fleINVESTMENTS.GetDecimalValue("INVEST_POINTS"));
                    fleCURRENT_ENTS_2.set_SetValue("ENTITLEMENT_BAL", fleINVESTMENTS.GetDecimalValue("INVEST_POINTS"));
                    fleCURRENT_ENTS_3.set_SetValue("ENTITLEMENT_BAL", fleINVESTMENTS.GetDecimalValue("INVEST_POINTS"));
                    fleINVESTOR_LETTERS.set_SetValue("HOLIDAY_ANNIV", fleINVESTMENTS.GetStringValue("HOLIDAY_ANNIV"));
                    fleM_INVESTORS.set_SetValue("HOLIDAY_ANNIV", fleINVESTMENTS.GetStringValue("HOLIDAY_ANNIV"));
                    fleM_INVESTORS.set_SetValue("HY1_DATE", D_YEAR_END_1.Value);
                    fleM_INVESTORS.set_SetValue("HY2_DATE", D_YEAR_END_2.Value);
                    fleM_INVESTORS.set_SetValue("HY3_DATE", D_YEAR_END_3.Value);
                    fleM_INVESTORS.set_SetValue("HY1_YEAR", D_YEAR_1.Value);
                    fleM_INVESTORS.set_SetValue("HY2_YEAR", D_YEAR_2.Value);
                    fleM_INVESTORS.set_SetValue("HY3_YEAR", D_YEAR_3.Value);
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



        private void dsrDesigner_01_Click(object sender, System.EventArgs e)
        {

            try
            {

                Accept(ref fldT_SUBSCREEN);
                if (QDesign.NULL(T_SUBSCREEN.Value) == "C")
                {
                    //RunScreen("INVESTCX.QKC", RunScreenModes.Find, fleM_INVESTORS);
                }
                if (QDesign.NULL(T_SUBSCREEN.Value) == "Y")
                {
                    //object[] arrRunscreen = { fleM_INVESTORS, fleINVESTMENTS, fleANNUAL_ENT, fleUSER_SEC_FILE };
                    //RunScreen(new TOPUPS(), RunScreenModes.Same, ref arrRunscreen);
                }
                Display(ref fldINVESTMENTS_TOP_UP_AMOUNT);
                Display(ref fldINVESTMENTS_TOP_UP_POINTS);
                T_TOTAL_AMOUNT.Value = D_TOTAL_AMOUNT.Value;
                Display(ref fldD_TOTAL_AMOUNT);


            }
            catch (CustomApplicationException ex)
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

                Accept(ref fldINVESTMENTS_HOLIDAY_ANNIV);
                Accept(ref fldINVESTMENTS_INVESTMENT_DATE);
                Accept(ref fldINVESTMENTS_METHOD);
                Accept(ref fldINVESTMENTS_INVEST_AMOUNT);
                T_ENTRY_MODE.Value = "Y";
                Accept(ref fldINVESTMENTS_rma_ALLOWANCE);
                Display(ref fldINVESTMENTS_INVEST_POINTS);
                Display(ref fldINVESTMENTS_TOP_UP_AMOUNT);
                Display(ref fldINVESTMENTS_TOP_UP_POINTS);
                Display(ref fldD_TOTAL_AMOUNT);

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

                if (QDesign.NULL(T_ENTRY_MODE.Value) == "Y")
                {
                    fleANNUAL_TRANS.PutData();
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


        protected override bool Find()
        {


            try
            {

                bool blnAddWhere = true;
                m_strWhere = new StringBuilder(GetWhereCondition("INVESTMENTS.INVESTOR", fleM_INVESTORS.GetStringValue("INVESTOR"), ref blnAddWhere));
                fleINVESTMENTS.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);

                fleANNUAL_ENT.GetData(GetDataOptions.IsOptional);

                fleCURRENT_ENTS_1.GetData(GetDataOptions.IsOptional);

                fleCURRENT_ENTS_2.GetData(GetDataOptions.IsOptional);

                fleCURRENT_ENTS_3.GetData(GetDataOptions.IsOptional);


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

                if (QDesign.NULL(T_ENTRY_MODE.Value) == "Y")
                {
                    fleM_INVESTORS.PutData(false, PutTypes.New);
                    fleINVESTMENTS.PutData(false, PutTypes.Deleted);
                    fleANNUAL_ENT.PutData();
                    fleTRANS_HEADER.PutData();
                    fleCURRENT_ENTS_1.PutData();
                    fleCURRENT_ENTS_2.PutData();
                    fleCURRENT_ENTS_3.PutData();
                    fleINVESTMENTS.PutData();
                    fleM_INVESTORS.PutData();
                    fleINVESTOR_LETTERS.PutData();
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

                Information("42023");

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
                    // --> GET CANCEL_INVEST <--

                    fleCANCEL_INVEST.GetData(GetDataOptions.IsOptional);
                    // --> End GET CANCEL_INVEST <--
                    Warning("** This investor was cancelled on " + D_CANCEL_DATE.Value);
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

        //#CORE_BEGIN_INCLUDE: SCRNVSTU.USE"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 07/12/2013 1:48:55 PM


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


        #endregion

        #endregion

    }

}
