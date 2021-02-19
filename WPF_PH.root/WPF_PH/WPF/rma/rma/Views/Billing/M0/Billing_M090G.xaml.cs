
#region "Screen Comments"

// #> PROGRAM-ID.     m090g
// ((C)) Dyad Technologies
// PROGRAM PURPOSE : MAINTENANCE of values in Constants Mstr Rec #7
// MODIFICATION HISTORY
// DATE   WHO          DESCRIPTION
// 2000/jan/07 B.E.         - ORIGINAL
// 2011/jan/17 MC1      - include ohip-run-date as bi-date
// 2013/sep/25 MC2      - item 5 (current-costing-ped) should be yyyy/06/30 because this date
// is used in costing3/4.qts to select 13th monthend data from f050-history file

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

    partial class Billing_M090G : BasePage
    {

        #region " Form Designer Generated Code "





        public Billing_M090G()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "M090G";

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
            dsrDesigner_02.Click += dsrDesigner_02_Click;
            dsrDesigner_01.Click += dsrDesigner_01_Click;
            base.Page_Load();

        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            fleCONSTANTS_MSTR_REC_7 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "CONSTANTS_MSTR_REC_7", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            CURRENTDATE = new CoreDecimal("CURRENTDATE", 6, this);
           

            CURRENTDATE.GetInitialValue += CURRENTDATE_GetInitialValue;
        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;

            dsrDesigner_02.Click -= dsrDesigner_02_Click;
            dsrDesigner_01.Click -= dsrDesigner_01_Click;
            CURRENTDATE.GetInitialValue -= CURRENTDATE_GetInitialValue;

        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private SqlConnection m_cnnQUERY = new SqlConnection();
        private SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
        private SqlTransaction m_trnTRANS_UPDATE;
        private SqlFileObject fleCONSTANTS_MSTR_REC_7;
        private CoreDecimal CURRENTDATE;
        private void CURRENTDATE_GetInitialValue()
        {
            CURRENTDATE.InitialValue = QDesign.SysDate(ref m_cnnQUERY);
        }

        #endregion

        #region "Standard Generated Procedures"

        #region "Grid Field Declarations"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:14:05 AM

        //# No code was generated or needed for this region.

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:14:05 AM

        //# No code was generated or needed for this region.

        #endregion

        #region "Transaction Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:14:05 AM

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
            fleCONSTANTS_MSTR_REC_7.Transaction = m_trnTRANS_UPDATE;


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:14:05 AM

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
                fleCONSTANTS_MSTR_REC_7.Dispose();


            }
            catch (CustomApplicationException ex)
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:14:05 AM
        //#-----------------------------------------
        protected override void DisplayFormatting()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:14:05 AM
               
                Display(ref fldCONSTANTS_MSTR_REC_7_PREVIOUS_FISCAL_START_YYMMDD);
                Display(ref fldCONSTANTS_MSTR_REC_7_PREVIOUS_FISCAL_END_YYMMDD);
                Display(ref fldCONSTANTS_MSTR_REC_7_CURRENT_FISCAL_START_YYMMDD);
                Display(ref fldCONSTANTS_MSTR_REC_7_CURRENT_FISCAL_END_YYMMDD);
                Display(ref fldCONSTANTS_MSTR_REC_7_EP_YR);
                Display(ref fldCONSTANTS_MSTR_REC_7_CURRENT_COSTING_CUTOFF_YYMMDD);
                Display(ref fldCONSTANTS_MSTR_REC_7_CURRENT_COSTING_PED);
                Display(ref fldCONSTANTS_MSTR_REC_7_OHIP_RUN_DATE);
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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:14:05 AM

        //#-----------------------------------------
        //# BindFields Procedure.
        //#-----------------------------------------

        public override void BindFields()
        {
            try
            {
                
                fldCONSTANTS_MSTR_REC_7_PREVIOUS_FISCAL_START_YYMMDD.Bind(fleCONSTANTS_MSTR_REC_7);
                fldCONSTANTS_MSTR_REC_7_PREVIOUS_FISCAL_END_YYMMDD.Bind(fleCONSTANTS_MSTR_REC_7);
                fldCONSTANTS_MSTR_REC_7_CURRENT_FISCAL_START_YYMMDD.Bind(fleCONSTANTS_MSTR_REC_7);
                fldCONSTANTS_MSTR_REC_7_CURRENT_FISCAL_END_YYMMDD.Bind(fleCONSTANTS_MSTR_REC_7);
                fldCONSTANTS_MSTR_REC_7_EP_YR.Bind(fleCONSTANTS_MSTR_REC_7);
                fldCONSTANTS_MSTR_REC_7_CURRENT_COSTING_CUTOFF_YYMMDD.Bind(fleCONSTANTS_MSTR_REC_7);
                fldCONSTANTS_MSTR_REC_7_CURRENT_COSTING_PED.Bind(fleCONSTANTS_MSTR_REC_7);
                fldCONSTANTS_MSTR_REC_7_OHIP_RUN_DATE.Bind(fleCONSTANTS_MSTR_REC_7);

            }
            catch (CustomApplicationException ex)
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


        protected override bool Find()
        {


            try
            {
                bool blnAddWhere = true;
                m_strWhere = new StringBuilder(" WHERE ");
                m_strWhere.Append(" ").Append(fleCONSTANTS_MSTR_REC_7.ElementOwner("CONST_REC_NBR")).Append(" = ");
                m_strWhere.Append("7");

                fleCONSTANTS_MSTR_REC_7.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);


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
                Page.PageTitle = "COSTING Subsystem Maintenance";



            }
            catch (CustomApplicationException ex)
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:14:05 AM
        //#-----------------------------------------
        protected override bool Entry()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:14:05 AM
               
                Accept(ref fldCONSTANTS_MSTR_REC_7_PREVIOUS_FISCAL_START_YYMMDD);
                Accept(ref fldCONSTANTS_MSTR_REC_7_PREVIOUS_FISCAL_END_YYMMDD);
                Accept(ref fldCONSTANTS_MSTR_REC_7_CURRENT_FISCAL_START_YYMMDD);
                Accept(ref fldCONSTANTS_MSTR_REC_7_CURRENT_FISCAL_END_YYMMDD);
                Accept(ref fldCONSTANTS_MSTR_REC_7_EP_YR);
                Accept(ref fldCONSTANTS_MSTR_REC_7_CURRENT_COSTING_CUTOFF_YYMMDD);
                Accept(ref fldCONSTANTS_MSTR_REC_7_CURRENT_COSTING_PED);
                Accept(ref fldCONSTANTS_MSTR_REC_7_OHIP_RUN_DATE);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:14:05 AM
        //#-----------------------------------------
        protected override bool Update()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:14:05 AM
                fleCONSTANTS_MSTR_REC_7.PutData(false, PutTypes.New);
                fleCONSTANTS_MSTR_REC_7.PutData();
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
        //# Delete Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:14:05 AM
        //#-----------------------------------------
        protected override bool Delete()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:14:05 AM
                fleCONSTANTS_MSTR_REC_7.DeletedRecord = true;
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:14:05 AM
        //#-----------------------------------------
        private void dsrDesigner_02_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:14:05 AM
                Accept(ref fldCONSTANTS_MSTR_REC_7_CURRENT_FISCAL_START_YYMMDD);
                Accept(ref fldCONSTANTS_MSTR_REC_7_CURRENT_FISCAL_END_YYMMDD);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:14:05 AM
        //#-----------------------------------------
        private void dsrDesigner_01_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:14:05 AM
                Accept(ref fldCONSTANTS_MSTR_REC_7_PREVIOUS_FISCAL_START_YYMMDD);
                Accept(ref fldCONSTANTS_MSTR_REC_7_PREVIOUS_FISCAL_END_YYMMDD);
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
