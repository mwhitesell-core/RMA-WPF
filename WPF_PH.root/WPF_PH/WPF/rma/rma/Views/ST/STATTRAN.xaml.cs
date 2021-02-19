
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


namespace rma.Views
{
    partial class STATTRAN : BasePage
    {

        #region " Form Designer Generated Code "





        public STATTRAN()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "STATTRAN";

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
            base.Page_Load();
        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here

            TRANS_NO = new CoreCharacter("TRANS_NO", 14, this);
            POST_OR_EMAIL = new CoreCharacter("POST_OR_EMAIL", 1, this);
            BONUS_MAIL = new CoreCharacter("BONUS_MAIL", 1, this);
            REQUESTED_BY = new CoreCharacter("REQUESTED_BY", 26, this);
           
        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;
            
        }


        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private OracleConnection m_cnnQUERY = new OracleConnection();
        private OracleConnection m_cnnTRANS_UPDATE = new OracleConnection();
        private OracleTransaction m_trnTRANS_UPDATE;

        private CoreCharacter TRANS_NO;
        private CoreCharacter POST_OR_EMAIL;
        private CoreCharacter BONUS_MAIL;
        private CoreCharacter REQUESTED_BY;



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

            }
            catch (CustomApplicationException ex)
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

            }
            catch (CustomApplicationException ex)
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


            }
            catch (CustomApplicationException ex)
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
                fldTRANS_NO.Bind(TRANS_NO);
                fldPOST_OR_EMAIL.Bind(POST_OR_EMAIL);
                fldBONUS_MAIL.Bind(BONUS_MAIL);
                fldREQUESTED_BY.Bind(REQUESTED_BY);


            }
            catch (CustomApplicationException ex)
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

        protected override bool Entry()
        {


            try
            {
                Accept(ref fldTRANS_NO);
                Accept(ref fldPOST_OR_EMAIL);
                Accept(ref fldBONUS_MAIL);
                Accept(ref fldREQUESTED_BY);

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
                StartJobScript();
                WriteToJobScript("STATTRAN", "WEBPASS", JobScriptType.QTP, "rma~");
                WriteToJobScript("STATTRAN", "STATTRAN", JobScriptType.QTP, "rma~" + TRANS_NO.Value.Trim() + "," + POST_OR_EMAIL.Value.Trim() + "," + BONUS_MAIL.Value.Trim());
                WriteToJobScript("STATTRAN", "STATTRAN_QUIZ", JobScriptType.QUIZ, "rma~" + TRANS_NO.Value.Trim() + ",\"\"," + REQUESTED_BY.Value.Trim());
                EndJobScript();


                RunJob("STATTRAN");

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

        protected override void SaveParamsReceived()
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




        protected override void RetrieveParamsReceived()
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

        #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"






        public override void PagePostProcess(PageArgs e)
        {

            try
            {
                Page.PageTitle = "STATTRAN";

            }
            catch (CustomApplicationException ex)
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
