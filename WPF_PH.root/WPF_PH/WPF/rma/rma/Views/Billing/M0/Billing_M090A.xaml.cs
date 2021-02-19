
#region "Screen Comments"

// #> program-id.     m090a.qks
// ((C)) Dyad Technologies
// PROGRAM PURPOSE : allow user to create and/or modify the clinic record
// MODIFICATION HISTORY
// DATE   WHO     DESCRIPTION
// 03/may/14 M.C.     - original 

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

    partial class Billing_M090A : BasePage
    {

        #region " Form Designer Generated Code "





        public Billing_M090A()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "M090A";

            //# Set the ACTIVITIES for the screen.
            this.ChangeActivity = true;
            this.FindActivity = true;
            this.DeleteActivity = false;
            this.EntryActivity = true;
            this.UseAcceptProcessing = true;








        }

        #endregion

        private void Page_Load(object sender, RoutedEventArgs e)
        {
            SetVariables();
            dsrDesigner_02.Click += dsrDesigner_02_Click;
            dsrDesigner_03.Click += dsrDesigner_03_Click;
            dsrDesigner_01.Click += dsrDesigner_01_Click;
            fldICONST_MSTR_REC_ICONST_CLINIC_NBR_1_2.LookupNotOn += fldICONST_MSTR_REC_ICONST_CLINIC_NBR_1_2_LookupNotOn;
            base.Page_Load();

            // TODO: The following FIELD(S) on the form are redefine elements.  Manual steps may be required:
            //       ICONST_MSTR_REC.ICONST_DATE_PERIOD_END


        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            fleICONST_MSTR_REC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "ICONST_MSTR_REC", "", false, false, false, 0, "m_trnTRANS_UPDATE");

           
            fleICONST_MSTR_REC.SelectIf += fleICONST_MSTR_REC_SelectIf;
        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;
            fldICONST_MSTR_REC_ICONST_CLINIC_NBR_1_2.LookupNotOn -= fldICONST_MSTR_REC_ICONST_CLINIC_NBR_1_2_LookupNotOn;
            fleICONST_MSTR_REC.SelectIf -= fleICONST_MSTR_REC_SelectIf;

            dsrDesigner_02.Click -= dsrDesigner_02_Click;
            dsrDesigner_03.Click -= dsrDesigner_03_Click;
            dsrDesigner_01.Click -= dsrDesigner_01_Click;


        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private SqlConnection m_cnnQUERY = new SqlConnection();
        private SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
        private SqlTransaction m_trnTRANS_UPDATE;
        private SqlFileObject fleICONST_MSTR_REC;

        private void fleICONST_MSTR_REC_SelectIf(ref string SelectIfClause)
        {


            try
            {
                StringBuilder strSQL = new StringBuilder("");

                strSQL.Append(" (    ").Append(fleICONST_MSTR_REC.ElementOwner("ICONST_CLINIC_NBR_1_2")).Append(" >=  22)");
                

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


        #endregion

        #region "Standard Generated Procedures"

        #region "Grid Field Declarations"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:14:23 AM

        //# No code was generated or needed for this region.

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:14:23 AM

        //# No code was generated or needed for this region.

        #endregion

        #region "Transaction Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:14:23 AM

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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:14:23 AM

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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:14:23 AM
        //#-----------------------------------------
        protected override void DisplayFormatting()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:14:23 AM
                Display(ref fldICONST_MSTR_REC_ICONST_CLINIC_NBR_1_2);
                Display(ref fldICONST_MSTR_REC_ICONST_CLINIC_NBR);
                Display(ref fldICONST_MSTR_REC_ICONST_CLINIC_NAME);
                Display(ref fldICONST_MSTR_REC_ICONST_CLINIC_CYCLE_NBR);
                Display(ref fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END);
                Display(ref fldICONST_MSTR_REC_ICONST_CLINIC_CARD_COLOUR);
                Display(ref fldICONST_MSTR_REC_ICONST_CLINIC_ADDR_L1);
                Display(ref fldICONST_MSTR_REC_ICONST_CLINIC_ADDR_L2);
                Display(ref fldICONST_MSTR_REC_ICONST_CLINIC_ADDR_L3);
                Display(ref fldICONST_MSTR_REC_ICONST_CLINIC_OVER_LIM1);
                Display(ref fldICONST_MSTR_REC_ICONST_CLINIC_UNDER_LIM2);
                Display(ref fldICONST_MSTR_REC_ICONST_CLINIC_UNDER_LIM3);
                Display(ref fldICONST_MSTR_REC_ICONST_CLINIC_OVER_LIM4);
                Display(ref fldICONST_MSTR_REC_ICONST_CLINIC_BATCH_NBR);
                Display(ref fldICONST_MSTR_REC_ICONST_REDUCTION_FACTOR);
                Display(ref fldICONST_MSTR_REC_ICONST_OVERPAY_FACTOR);
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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:14:23 AM

        //#-----------------------------------------
        //# BindFields Procedure.
        //#-----------------------------------------

        public override void BindFields()
        {
            try
            {
                fldICONST_MSTR_REC_ICONST_CLINIC_NBR_1_2.Bind(fleICONST_MSTR_REC);
                fldICONST_MSTR_REC_ICONST_CLINIC_NBR.Bind(fleICONST_MSTR_REC);
                fldICONST_MSTR_REC_ICONST_CLINIC_NAME.Bind(fleICONST_MSTR_REC);
                fldICONST_MSTR_REC_ICONST_CLINIC_CYCLE_NBR.Bind(fleICONST_MSTR_REC);
                fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END.Bind(fleICONST_MSTR_REC);
                fldICONST_MSTR_REC_ICONST_CLINIC_CARD_COLOUR.Bind(fleICONST_MSTR_REC);
                fldICONST_MSTR_REC_ICONST_CLINIC_ADDR_L1.Bind(fleICONST_MSTR_REC);
                fldICONST_MSTR_REC_ICONST_CLINIC_ADDR_L2.Bind(fleICONST_MSTR_REC);
                fldICONST_MSTR_REC_ICONST_CLINIC_ADDR_L3.Bind(fleICONST_MSTR_REC);
                fldICONST_MSTR_REC_ICONST_CLINIC_OVER_LIM1.Bind(fleICONST_MSTR_REC);
                fldICONST_MSTR_REC_ICONST_CLINIC_UNDER_LIM2.Bind(fleICONST_MSTR_REC);
                fldICONST_MSTR_REC_ICONST_CLINIC_UNDER_LIM3.Bind(fleICONST_MSTR_REC);
                fldICONST_MSTR_REC_ICONST_CLINIC_OVER_LIM4.Bind(fleICONST_MSTR_REC);
                fldICONST_MSTR_REC_ICONST_CLINIC_BATCH_NBR.Bind(fleICONST_MSTR_REC);
                fldICONST_MSTR_REC_ICONST_REDUCTION_FACTOR.Bind(fleICONST_MSTR_REC);
                fldICONST_MSTR_REC_ICONST_OVERPAY_FACTOR.Bind(fleICONST_MSTR_REC);

            }
            catch (CustomApplicationException ex)
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



        private void fldICONST_MSTR_REC_ICONST_CLINIC_NBR_1_2_LookupNotOn(ref bool LookupNotOnExecuted)
        {

            try
            {
                bool blnAlreadyExists = false;
                StringBuilder strSQL = new StringBuilder("SELECT ").Append(fleICONST_MSTR_REC.ElementOwner("ICONST_CLINIC_NBR_1_2"));
                strSQL.Append(" FROM ");
                strSQL.Append(fleICONST_MSTR_REC.TableNameWithAlias());
                strSQL.Append(" WHERE ");
                strSQL.Append("     ").Append(fleICONST_MSTR_REC.ElementOwner("ICONST_CLINIC_NBR_1_2")).Append(" = ").Append((FieldValue));

                if (!LookupNotOn(strSQL, fleICONST_MSTR_REC, "ICONST_CLINIC_NBR_1_2", FieldValue.ToString()))
                {
                    blnAlreadyExists = true;
                }

                if (blnAlreadyExists)
                {
                    ErrorMessage("Record exists in lookup table.");
                    
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


        #endregion

        #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"


        protected override bool Find()
        {


            try
            {
                bool blnAddWhere = true;
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
                Page.PageTitle = "Constants Master Clinic Maintenance";



            }
            catch (CustomApplicationException ex)
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:14:23 AM
        //#-----------------------------------------
        protected override bool Entry()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:14:23 AM
                Accept(ref fldICONST_MSTR_REC_ICONST_CLINIC_NBR_1_2);
                Accept(ref fldICONST_MSTR_REC_ICONST_CLINIC_NBR);
                Accept(ref fldICONST_MSTR_REC_ICONST_CLINIC_NAME);
                Accept(ref fldICONST_MSTR_REC_ICONST_CLINIC_CYCLE_NBR);
                Accept(ref fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END);
                Accept(ref fldICONST_MSTR_REC_ICONST_CLINIC_CARD_COLOUR);
                Accept(ref fldICONST_MSTR_REC_ICONST_CLINIC_ADDR_L1);
                Accept(ref fldICONST_MSTR_REC_ICONST_CLINIC_ADDR_L2);
                Accept(ref fldICONST_MSTR_REC_ICONST_CLINIC_ADDR_L3);
                Accept(ref fldICONST_MSTR_REC_ICONST_CLINIC_OVER_LIM1);
                Accept(ref fldICONST_MSTR_REC_ICONST_CLINIC_UNDER_LIM2);
                Accept(ref fldICONST_MSTR_REC_ICONST_CLINIC_UNDER_LIM3);
                Accept(ref fldICONST_MSTR_REC_ICONST_CLINIC_OVER_LIM4);
                Accept(ref fldICONST_MSTR_REC_ICONST_CLINIC_BATCH_NBR);
                Accept(ref fldICONST_MSTR_REC_ICONST_REDUCTION_FACTOR);
                Accept(ref fldICONST_MSTR_REC_ICONST_OVERPAY_FACTOR);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:14:23 AM
        //#-----------------------------------------
        protected override bool Update()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:14:23 AM
                fleICONST_MSTR_REC.PutData(false, PutTypes.New);
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
        //# dsrDesigner_02_Click Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:14:23 AM
        //#-----------------------------------------
        private void dsrDesigner_02_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:14:23 AM
                Accept(ref fldICONST_MSTR_REC_ICONST_CLINIC_ADDR_L1);
                Accept(ref fldICONST_MSTR_REC_ICONST_CLINIC_ADDR_L2);
                Accept(ref fldICONST_MSTR_REC_ICONST_CLINIC_ADDR_L3);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:14:23 AM
        //#-----------------------------------------
        private void dsrDesigner_03_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:14:23 AM
                Accept(ref fldICONST_MSTR_REC_ICONST_CLINIC_OVER_LIM1);
                Accept(ref fldICONST_MSTR_REC_ICONST_CLINIC_UNDER_LIM2);
                Accept(ref fldICONST_MSTR_REC_ICONST_CLINIC_UNDER_LIM3);
                Accept(ref fldICONST_MSTR_REC_ICONST_CLINIC_OVER_LIM4);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:14:23 AM
        //#-----------------------------------------
        private void dsrDesigner_01_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:14:23 AM
                if (!fleICONST_MSTR_REC.NewRecord)
                {
                    Display(ref fldICONST_MSTR_REC_ICONST_CLINIC_NBR_1_2);
                }
                else
                {
                    Accept(ref fldICONST_MSTR_REC_ICONST_CLINIC_NBR_1_2);
                }
                Accept(ref fldICONST_MSTR_REC_ICONST_CLINIC_NBR);
                Accept(ref fldICONST_MSTR_REC_ICONST_CLINIC_NAME);
                Accept(ref fldICONST_MSTR_REC_ICONST_CLINIC_CYCLE_NBR);
                Accept(ref fldICONST_MSTR_REC_ICONST_DATE_PERIOD_END);
                Accept(ref fldICONST_MSTR_REC_ICONST_CLINIC_CARD_COLOUR);
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
