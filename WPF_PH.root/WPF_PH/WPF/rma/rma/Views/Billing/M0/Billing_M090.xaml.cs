
#region "Screen Comments"

// #> program-id.     m090.qks
// ((C)) Dyad Technologies
// PROGRAM PURPOSE : alternative constants master maintenance written
// in powerhouse rather than cobol - shows the 13
// period end dates for each clinic
// MODIFICATION HISTORY
// DATE   WHO     DESCRIPTION
// 00/jul/26 B.E.     - original 
// 14/jul/24 MC1      - include the new field iconst-monthend to indicate which monthend that
// the clinic should be run, include the display of cycle nbr
// 15/Jan/06 MC2 - correct the internal procedure reset-display-flag  for if else

#endregion



using System;
using System.Text;
using System.Windows;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.ExceptionManagement;
using Core.Windows.UI.Core.Windows;
using Core.Windows.UI.Core.Windows.UI;
using System.Data.SqlClient;

namespace rma.Views
{

    partial class Billing_M090 : BasePage
    {

        #region " Form Designer Generated Code "





        public Billing_M090()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "M090";

            //# Set the ACTIVITIES for the screen.
            this.ChangeActivity = true;
            this.FindActivity = true;
            this.DeleteActivity = false;
            this.EntryActivity = false;
            this.UseAcceptProcessing = true;



            this.HasPathRequestFields = true;







        }

        #endregion

        private void Page_Load(object sender, RoutedEventArgs e)
        {
            SetVariables();
            dsrDesigner_09.Click += dsrDesigner_09_Click;
            dsrDesigner_15.Click += dsrDesigner_15_Click;
            dsrDesigner_13.Click += dsrDesigner_13_Click;
            dsrDesigner_11.Click += dsrDesigner_11_Click;
            dsrDesigner_03.Click += dsrDesigner_03_Click;
            dsrDesigner_04.Click += dsrDesigner_04_Click;
            dsrDesigner_10.Click += dsrDesigner_10_Click;
            dsrDesigner_07.Click += dsrDesigner_07_Click;
            dsrDesigner_08.Click += dsrDesigner_08_Click;
            dsrDesigner_14.Click += dsrDesigner_14_Click;
            dsrDesigner_01.Click += dsrDesigner_01_Click;
            dsrDesigner_06.Click += dsrDesigner_06_Click;
            dsrDesigner_12.Click += dsrDesigner_12_Click;
            dsrDesigner_02.Click += dsrDesigner_02_Click;
            dsrDesigner_05.Click += dsrDesigner_05_Click;
            fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END.Process += fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_Process;
            fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_1.Process += fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_1_Process;
            fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_2.Process += fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_2_Process;
            fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_3.Process += fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_3_Process;
            fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_4.Process += fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_4_Process;
            fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_5.Process += fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_5_Process;
            fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_6.Process += fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_6_Process;
            fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_7.Process += fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_7_Process;
            fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_8.Process += fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_8_Process;
            fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_9.Process += fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_9_Process;
            fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_10.Process += fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_10_Process;
            fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_11.Process += fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_11_Process;
            fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_12.Process += fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_12_Process;
            fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_13.Process += fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_13_Process;
            base.Page_Load();

            // TODO: The following FIELD(S) on the form are redefine elements.  Manual steps may be required:
            //       ICONST_MSTR_REC.ICONST_DATE_PERIOD_END


        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            fleICONST_MSTR_REC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "ICONST_MSTR_REC", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            X_FLAG_1 = new CoreCharacter("X_FLAG_1", 15, this, Common.cEmptyString);
            X_FLAG_2 = new CoreCharacter("X_FLAG_2", 15, this, Common.cEmptyString);
            X_FLAG_3 = new CoreCharacter("X_FLAG_3", 15, this, Common.cEmptyString);
            X_FLAG_4 = new CoreCharacter("X_FLAG_4", 15, this, Common.cEmptyString);
            X_FLAG_5 = new CoreCharacter("X_FLAG_5", 15, this, Common.cEmptyString);
            X_FLAG_6 = new CoreCharacter("X_FLAG_6", 15, this, Common.cEmptyString);
            X_FLAG_7 = new CoreCharacter("X_FLAG_7", 15, this, Common.cEmptyString);
            X_FLAG_8 = new CoreCharacter("X_FLAG_8", 15, this, Common.cEmptyString);
            X_FLAG_9 = new CoreCharacter("X_FLAG_9", 15, this, Common.cEmptyString);
            X_FLAG_10 = new CoreCharacter("X_FLAG_10", 15, this, Common.cEmptyString);
            X_FLAG_11 = new CoreCharacter("X_FLAG_11", 15, this, Common.cEmptyString);
            X_FLAG_12 = new CoreCharacter("X_FLAG_12", 15, this, Common.cEmptyString);
            X_FLAG_13 = new CoreCharacter("X_FLAG_13", 15, this, Common.cEmptyString);
            ICONST_DATE_PERIOD_END = new CoreDecimal("ICONST_DATE_PERIOD_END", 8, this);

            fleICONST_MSTR_REC.SetItemFinals += fleICONST_MSTR_REC_SetItemFinals;

        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;

            dsrDesigner_09.Click -= dsrDesigner_09_Click;
            dsrDesigner_15.Click -= dsrDesigner_15_Click;
            dsrDesigner_13.Click -= dsrDesigner_13_Click;
            dsrDesigner_11.Click -= dsrDesigner_11_Click;
            dsrDesigner_03.Click -= dsrDesigner_03_Click;
            dsrDesigner_04.Click -= dsrDesigner_04_Click;
            dsrDesigner_10.Click -= dsrDesigner_10_Click;
            dsrDesigner_07.Click -= dsrDesigner_07_Click;
            dsrDesigner_08.Click -= dsrDesigner_08_Click;
            dsrDesigner_14.Click -= dsrDesigner_14_Click;
            dsrDesigner_01.Click -= dsrDesigner_01_Click;
            dsrDesigner_06.Click -= dsrDesigner_06_Click;
            dsrDesigner_12.Click -= dsrDesigner_12_Click;
            dsrDesigner_02.Click -= dsrDesigner_02_Click;
            dsrDesigner_05.Click -= dsrDesigner_05_Click;
            fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END.Process -= fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_Process;
            fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_1.Process -= fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_1_Process;
            fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_2.Process -= fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_2_Process;
            fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_3.Process -= fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_3_Process;
            fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_4.Process -= fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_4_Process;
            fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_5.Process -= fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_5_Process;
            fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_6.Process -= fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_6_Process;
            fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_7.Process -= fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_7_Process;
            fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_8.Process -= fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_8_Process;
            fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_9.Process -= fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_9_Process;
            fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_10.Process -= fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_10_Process;
            fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_11.Process -= fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_11_Process;
            fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_12.Process -= fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_12_Process;
            fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_13.Process -= fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_13_Process;
            fleICONST_MSTR_REC.SetItemFinals -= fleICONST_MSTR_REC_SetItemFinals;

        }



        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private SqlConnection m_cnnQUERY = new SqlConnection();
        private SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
        private SqlTransaction m_trnTRANS_UPDATE;
        private SqlFileObject fleICONST_MSTR_REC;
        private void fleICONST_MSTR_REC_SetItemFinals()
        {
            try
            {
                fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_YY", ICONST_DATE_PERIOD_END.Value.ToString().PadLeft(8, '0').Substring(0, 4));
                fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_MM", ICONST_DATE_PERIOD_END.Value.ToString().PadLeft(8, '0').Substring(4, 2));
                fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_DD", ICONST_DATE_PERIOD_END.Value.ToString().PadLeft(8, '0').Substring(6, 2));

            }
            catch (CustomApplicationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;
            }
        }
        private CoreCharacter X_FLAG_1;
        private CoreCharacter X_FLAG_2;
        private CoreCharacter X_FLAG_3;
        private CoreCharacter X_FLAG_4;
        private CoreCharacter X_FLAG_5;
        private CoreCharacter X_FLAG_6;
        private CoreCharacter X_FLAG_7;
        private CoreCharacter X_FLAG_8;
        private CoreCharacter X_FLAG_9;
        private CoreCharacter X_FLAG_10;
        private CoreCharacter X_FLAG_11;
        private CoreCharacter X_FLAG_12;

        private CoreCharacter X_FLAG_13;

        private CoreDecimal ICONST_DATE_PERIOD_END;


        #endregion

        #region "Standard Generated Procedures"

        #region "Grid Field Declarations"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:14:37 AM

        //# No code was generated or needed for this region.

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:14:37 AM

        //# No code was generated or needed for this region.

        #endregion

        #region "Transaction Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:14:37 AM

        //#-----------------------------------------
        //# InitializeTransactionObjects Procedure.
        //#-----------------------------------------

        protected override void InitializeTransactionObjects()
        {

            try
            {
                m_cnnTRANS_UPDATE = new SqlConnection(Common.GetSqlConnectionString());
                m_cnnTRANS_UPDATE.Open();
                m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
                m_cnnQUERY = new SqlConnection(Common.GetSqlConnectionString());


            }
            catch (CustomApplicationException ex)
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
            fleICONST_MSTR_REC.Transaction = m_trnTRANS_UPDATE;


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:14:37 AM

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
                fleICONST_MSTR_REC.Dispose();


            }
            catch (CustomApplicationException ex)
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:14:36 AM
        //#-----------------------------------------
        protected override void DisplayFormatting()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:14:36 AM
                Display(ref fldICONST_MSTR_REC_ICONST_CLINIC_NBR_1_2);
                Display(ref fldICONST_MSTR_REC_ICONST_CLINIC_NAME);
                Display(ref fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END);
                Display(ref fldICONST_MSTR_REC_ICONSTPEDNUMBERWITHINFISCALYEAR);
                Display(ref fldICONST_MSTR_REC_ICONST_MONTHEND);
                Display(ref fldICONST_MSTR_REC_ICONST_CLINIC_CYCLE_NBR);
                Display(ref fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_1);
                Display(ref fldX_FLAG_1);
                Display(ref fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_2);
                Display(ref fldX_FLAG_2);
                Display(ref fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_3);
                Display(ref fldX_FLAG_3);
                Display(ref fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_4);
                Display(ref fldX_FLAG_4);
                Display(ref fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_5);
                Display(ref fldX_FLAG_5);
                Display(ref fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_6);
                Display(ref fldX_FLAG_6);
                Display(ref fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_7);
                Display(ref fldX_FLAG_7);
                Display(ref fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_8);
                Display(ref fldX_FLAG_8);
                Display(ref fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_9);
                Display(ref fldX_FLAG_9);
                Display(ref fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_10);
                Display(ref fldX_FLAG_10);
                Display(ref fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_11);
                Display(ref fldX_FLAG_11);
                Display(ref fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_12);
                Display(ref fldX_FLAG_12);
                Display(ref fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_13);
                Display(ref fldX_FLAG_13);
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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:14:37 AM

        //#-----------------------------------------
        //# BindFields Procedure.
        //#-----------------------------------------

        public override void BindFields()
        {
            try
            {
                fldICONST_MSTR_REC_ICONST_CLINIC_NBR_1_2.Bind(fleICONST_MSTR_REC);
                fldICONST_MSTR_REC_ICONST_CLINIC_NAME.Bind(fleICONST_MSTR_REC);
                fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END.Bind(ICONST_DATE_PERIOD_END);
                fldICONST_MSTR_REC_ICONSTPEDNUMBERWITHINFISCALYEAR.Bind(fleICONST_MSTR_REC);
                fldICONST_MSTR_REC_ICONST_MONTHEND.Bind(fleICONST_MSTR_REC);
                fldICONST_MSTR_REC_ICONST_CLINIC_CYCLE_NBR.Bind(fleICONST_MSTR_REC);
                fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_1.Bind(fleICONST_MSTR_REC);
                fldX_FLAG_1.Bind(X_FLAG_1);
                fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_2.Bind(fleICONST_MSTR_REC);
                fldX_FLAG_2.Bind(X_FLAG_2);
                fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_3.Bind(fleICONST_MSTR_REC);
                fldX_FLAG_3.Bind(X_FLAG_3);
                fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_4.Bind(fleICONST_MSTR_REC);
                fldX_FLAG_4.Bind(X_FLAG_4);
                fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_5.Bind(fleICONST_MSTR_REC);
                fldX_FLAG_5.Bind(X_FLAG_5);
                fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_6.Bind(fleICONST_MSTR_REC);
                fldX_FLAG_6.Bind(X_FLAG_6);
                fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_7.Bind(fleICONST_MSTR_REC);
                fldX_FLAG_7.Bind(X_FLAG_7);
                fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_8.Bind(fleICONST_MSTR_REC);
                fldX_FLAG_8.Bind(X_FLAG_8);
                fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_9.Bind(fleICONST_MSTR_REC);
                fldX_FLAG_9.Bind(X_FLAG_9);
                fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_10.Bind(fleICONST_MSTR_REC);
                fldX_FLAG_10.Bind(X_FLAG_10);
                fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_11.Bind(fleICONST_MSTR_REC);
                fldX_FLAG_11.Bind(X_FLAG_11);
                fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_12.Bind(fleICONST_MSTR_REC);
                fldX_FLAG_12.Bind(X_FLAG_12);
                fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_13.Bind(fleICONST_MSTR_REC);
                fldX_FLAG_13.Bind(X_FLAG_13);

            }
            catch (CustomApplicationException ex)
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

        #endregion

        #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"


        private bool Internal_RESET_DISPLAY_FLAG()
        {


            try
            {
                X_FLAG_1.Value = " ";
                X_FLAG_2.Value = " ";
                X_FLAG_3.Value = " ";
                X_FLAG_4.Value = " ";
                X_FLAG_5.Value = " ";
                X_FLAG_6.Value = " ";
                X_FLAG_7.Value = " ";
                X_FLAG_8.Value = " ";
                X_FLAG_9.Value = " ";
                X_FLAG_10.Value = " ";
                X_FLAG_11.Value = " ";
                X_FLAG_12.Value = " ";
                X_FLAG_13.Value = " ";



                if (QDesign.NULL(fleICONST_MSTR_REC.GetDecimalValue("ICONST_DATE_PERIOD_END_1")) == ICONST_DATE_PERIOD_END.Value)
                {
                    X_FLAG_1.Value = "<-- current PED";
                    fleICONST_MSTR_REC.set_SetValue("ICONSTPEDNUMBERWITHINFISCALYEAR", 1);
                }
                else
                {
                    if (QDesign.NULL(fleICONST_MSTR_REC.GetDecimalValue("ICONST_DATE_PERIOD_END_2")) == ICONST_DATE_PERIOD_END.Value)
                    {
                        X_FLAG_2.Value = "<-- current PED";
                        fleICONST_MSTR_REC.set_SetValue("ICONSTPEDNUMBERWITHINFISCALYEAR", 2);
                    }
                    else
                    {
                        if (QDesign.NULL(fleICONST_MSTR_REC.GetDecimalValue("ICONST_DATE_PERIOD_END_3")) == ICONST_DATE_PERIOD_END.Value)
                        {
                            X_FLAG_3.Value = "<-- current PED";
                            fleICONST_MSTR_REC.set_SetValue("ICONSTPEDNUMBERWITHINFISCALYEAR", 3);
                        }
                        else
                        {
                            if (QDesign.NULL(fleICONST_MSTR_REC.GetDecimalValue("ICONST_DATE_PERIOD_END_4")) == ICONST_DATE_PERIOD_END.Value)
                            {
                                X_FLAG_4.Value = "<-- current PED";
                                fleICONST_MSTR_REC.set_SetValue("ICONSTPEDNUMBERWITHINFISCALYEAR", 4);
                            }
                            else
                            {
                                if (QDesign.NULL(fleICONST_MSTR_REC.GetDecimalValue("ICONST_DATE_PERIOD_END_5")) == ICONST_DATE_PERIOD_END.Value)
                                {
                                    X_FLAG_5.Value = "<-- current PED";
                                    fleICONST_MSTR_REC.set_SetValue("ICONSTPEDNUMBERWITHINFISCALYEAR", 5);
                                }
                                else
                                {
                                    if (QDesign.NULL(fleICONST_MSTR_REC.GetDecimalValue("ICONST_DATE_PERIOD_END_6")) == ICONST_DATE_PERIOD_END.Value)
                                    {
                                        X_FLAG_6.Value = "<-- current PED";
                                        fleICONST_MSTR_REC.set_SetValue("ICONSTPEDNUMBERWITHINFISCALYEAR", 6);
                                    }
                                    else
                                    {
                                        if (QDesign.NULL(fleICONST_MSTR_REC.GetDecimalValue("ICONST_DATE_PERIOD_END_7")) == ICONST_DATE_PERIOD_END.Value)
                                        {
                                            X_FLAG_7.Value = "<-- current PED";
                                            fleICONST_MSTR_REC.set_SetValue("ICONSTPEDNUMBERWITHINFISCALYEAR", 7);
                                        }
                                        else
                                        {
                                            if (QDesign.NULL(fleICONST_MSTR_REC.GetDecimalValue("ICONST_DATE_PERIOD_END_8")) == ICONST_DATE_PERIOD_END.Value)
                                            {
                                                X_FLAG_8.Value = "<-- current PED";
                                                fleICONST_MSTR_REC.set_SetValue("ICONSTPEDNUMBERWITHINFISCALYEAR", 8);
                                            }
                                            else
                                            {
                                                if (QDesign.NULL(fleICONST_MSTR_REC.GetDecimalValue("ICONST_DATE_PERIOD_END_9")) == ICONST_DATE_PERIOD_END.Value)
                                                {
                                                    X_FLAG_9.Value = "<-- current PED";
                                                    fleICONST_MSTR_REC.set_SetValue("ICONSTPEDNUMBERWITHINFISCALYEAR", 9);
                                                }
                                                else
                                                {
                                                    if (QDesign.NULL(fleICONST_MSTR_REC.GetDecimalValue("ICONST_DATE_PERIOD_END_10")) == ICONST_DATE_PERIOD_END.Value)
                                                    {
                                                        X_FLAG_10.Value = "<-- current PED";
                                                        fleICONST_MSTR_REC.set_SetValue("ICONSTPEDNUMBERWITHINFISCALYEAR", 10);
                                                    }
                                                    else
                                                    {
                                                        if (QDesign.NULL(fleICONST_MSTR_REC.GetDecimalValue("ICONST_DATE_PERIOD_END_11")) == ICONST_DATE_PERIOD_END.Value)
                                                        {
                                                            X_FLAG_11.Value = "<-- current PED";
                                                            fleICONST_MSTR_REC.set_SetValue("ICONSTPEDNUMBERWITHINFISCALYEAR", 11);
                                                        }
                                                        else
                                                        {
                                                            if (QDesign.NULL(fleICONST_MSTR_REC.GetDecimalValue("ICONST_DATE_PERIOD_END_12")) == ICONST_DATE_PERIOD_END.Value)
                                                            {
                                                                X_FLAG_12.Value = "<-- current PED";
                                                                fleICONST_MSTR_REC.set_SetValue("ICONSTPEDNUMBERWITHINFISCALYEAR", 12);
                                                            }
                                                            else
                                                            {
                                                                if (QDesign.NULL(fleICONST_MSTR_REC.GetDecimalValue("ICONST_DATE_PERIOD_END_13")) == ICONST_DATE_PERIOD_END.Value)
                                                                {
                                                                    X_FLAG_13.Value = "<-- current PED";
                                                                    fleICONST_MSTR_REC.set_SetValue("ICONSTPEDNUMBERWITHINFISCALYEAR", 13);
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
                Display(ref fldICONST_MSTR_REC_ICONSTPEDNUMBERWITHINFISCALYEAR);
                Display(ref fldX_FLAG_1);
                Display(ref fldX_FLAG_2);
                Display(ref fldX_FLAG_3);
                Display(ref fldX_FLAG_4);
                Display(ref fldX_FLAG_5);
                Display(ref fldX_FLAG_6);
                Display(ref fldX_FLAG_7);
                Display(ref fldX_FLAG_8);
                Display(ref fldX_FLAG_9);
                Display(ref fldX_FLAG_10);
                Display(ref fldX_FLAG_11);
                Display(ref fldX_FLAG_12);
                Display(ref fldX_FLAG_13);
                if (QDesign.NULL(X_FLAG_1.Value) == QDesign.NULL(" ") & QDesign.NULL(X_FLAG_2.Value) == QDesign.NULL(" ") & QDesign.NULL(X_FLAG_3.Value) == QDesign.NULL(" ") & QDesign.NULL(X_FLAG_4.Value) == QDesign.NULL(" ") & QDesign.NULL(X_FLAG_5.Value) == QDesign.NULL(" ") & QDesign.NULL(X_FLAG_6.Value) == QDesign.NULL(" ") & QDesign.NULL(X_FLAG_7.Value) == QDesign.NULL(" ") & QDesign.NULL(X_FLAG_8.Value) == QDesign.NULL(" ") & QDesign.NULL(X_FLAG_9.Value) == QDesign.NULL(" ") & QDesign.NULL(X_FLAG_10.Value) == QDesign.NULL(" ") & QDesign.NULL(X_FLAG_11.Value) == QDesign.NULL(" ") & QDesign.NULL(X_FLAG_12.Value) == QDesign.NULL(" ") & QDesign.NULL(X_FLAG_13.Value) == QDesign.NULL(" "))
                {
                    Information("\a\a\aWARNING - the PED you entered is not in the list of possible PEDs!!");
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



        private void fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_Process()
        {

            try
            {
                ICONST_DATE_PERIOD_END.Value = FieldValue;
                Internal_RESET_DISPLAY_FLAG();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_1_Process()
        {

            try
            {

                Internal_RESET_DISPLAY_FLAG();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_2_Process()
        {

            try
            {

                Internal_RESET_DISPLAY_FLAG();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_3_Process()
        {

            try
            {

                Internal_RESET_DISPLAY_FLAG();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_4_Process()
        {

            try
            {

                Internal_RESET_DISPLAY_FLAG();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_5_Process()
        {

            try
            {

                Internal_RESET_DISPLAY_FLAG();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_6_Process()
        {

            try
            {

                Internal_RESET_DISPLAY_FLAG();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_7_Process()
        {

            try
            {

                Internal_RESET_DISPLAY_FLAG();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_8_Process()
        {

            try
            {

                Internal_RESET_DISPLAY_FLAG();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_9_Process()
        {

            try
            {

                Internal_RESET_DISPLAY_FLAG();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_10_Process()
        {

            try
            {

                Internal_RESET_DISPLAY_FLAG();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_11_Process()
        {

            try
            {

                Internal_RESET_DISPLAY_FLAG();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_12_Process()
        {

            try
            {

                Internal_RESET_DISPLAY_FLAG();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_13_Process()
        {

            try
            {

                Internal_RESET_DISPLAY_FLAG();


            }
            catch (CustomApplicationException ex)
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

                ICONST_DATE_PERIOD_END.Value = Convert.ToDecimal(fleICONST_MSTR_REC.GetDecimalValue("ICONST_DATE_PERIOD_END_YY").ToString().PadLeft(4, '0') + fleICONST_MSTR_REC.GetDecimalValue("ICONST_DATE_PERIOD_END_MM").ToString().PadLeft(2, '0') + fleICONST_MSTR_REC.GetDecimalValue("ICONST_DATE_PERIOD_END_DD").ToString().PadLeft(2, '0'));
                Internal_RESET_DISPLAY_FLAG();

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
                m_strWhere = new StringBuilder(GetWhereCondition(fleICONST_MSTR_REC.ElementOwner("ICONST_CLINIC_NBR_1_2"), fleICONST_MSTR_REC.GetDecimalValue("ICONST_CLINIC_NBR_1_2"), ref blnAddWhere));
                fleICONST_MSTR_REC.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);


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
                RequestPrompt(ref fldICONST_MSTR_REC_ICONST_CLINIC_NBR_1_2);
                if (m_blnPromptOK)
                {
                    m_intPath = 1;
                }
                else
                {
                    ErrorMessage("Key/Index required.");
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
                Page.PageTitle = "";



            }
            catch (CustomApplicationException ex)
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:14:36 AM
        //#-----------------------------------------
        protected override bool Update()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:14:36 AM
                fleICONST_MSTR_REC.PutData();
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
        //# dsrDesigner_09_Click Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:14:36 AM
        //#-----------------------------------------
        private void dsrDesigner_09_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:14:36 AM
                Accept(ref fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_7);
                Display(ref fldX_FLAG_7);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:14:36 AM
        //#-----------------------------------------
        private void dsrDesigner_15_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:14:36 AM
                Accept(ref fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_13);
                Display(ref fldX_FLAG_13);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:14:36 AM
        //#-----------------------------------------
        private void dsrDesigner_13_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:14:36 AM
                Accept(ref fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_11);
                Display(ref fldX_FLAG_11);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:14:36 AM
        //#-----------------------------------------
        private void dsrDesigner_11_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:14:36 AM
                Accept(ref fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_9);
                Display(ref fldX_FLAG_9);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:14:36 AM
        //#-----------------------------------------
        private void dsrDesigner_03_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:14:36 AM
                Accept(ref fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_1);
                Display(ref fldX_FLAG_1);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:14:36 AM
        //#-----------------------------------------
        private void dsrDesigner_04_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:14:36 AM
                Accept(ref fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_2);
                Display(ref fldX_FLAG_2);
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
        //# dsrDesigner_10_Click Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:14:36 AM
        //#-----------------------------------------
        private void dsrDesigner_10_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:14:36 AM
                Accept(ref fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_8);
                Display(ref fldX_FLAG_8);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:14:36 AM
        //#-----------------------------------------
        private void dsrDesigner_07_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:14:36 AM
                Accept(ref fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_5);
                Display(ref fldX_FLAG_5);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:14:36 AM
        //#-----------------------------------------
        private void dsrDesigner_08_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:14:36 AM
                Accept(ref fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_6);
                Display(ref fldX_FLAG_6);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:14:37 AM
        //#-----------------------------------------
        private void dsrDesigner_14_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:14:37 AM
                Accept(ref fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_12);
                Display(ref fldX_FLAG_12);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:14:37 AM
        //#-----------------------------------------
        private void dsrDesigner_01_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:14:37 AM
                Accept(ref fldICONST_MSTR_REC_ICONST_CLINIC_NBR_1_2);
                Display(ref fldICONST_MSTR_REC_ICONST_CLINIC_NAME);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:14:37 AM
        //#-----------------------------------------
        private void dsrDesigner_06_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:14:37 AM
                Accept(ref fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_4);
                Display(ref fldX_FLAG_4);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:14:37 AM
        //#-----------------------------------------
        private void dsrDesigner_12_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:14:37 AM
                Accept(ref fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_10);
                Display(ref fldX_FLAG_10);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:14:37 AM
        //#-----------------------------------------
        private void dsrDesigner_02_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:14:37 AM
                Accept(ref fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END);
                Display(ref fldICONST_MSTR_REC_ICONSTPEDNUMBERWITHINFISCALYEAR);
                Accept(ref fldICONST_MSTR_REC_ICONST_MONTHEND);
                Accept(ref fldICONST_MSTR_REC_ICONST_CLINIC_CYCLE_NBR);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:14:37 AM
        //#-----------------------------------------
        private void dsrDesigner_05_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:14:37 AM
                Accept(ref fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END_3);
                Display(ref fldX_FLAG_3);
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
