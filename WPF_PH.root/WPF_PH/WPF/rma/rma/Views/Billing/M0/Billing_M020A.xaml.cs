
#region "Screen Comments"

// #> program-id.     m020a.qks
// program purpose : additional information about doctor  
// modification history
// date   who     description
// 2005/jan/26   M.C. - original
// 2005/mar/30   M.C.    - pass doc dept, open 2 files f070 & f123
// - display company on the screen
// 2005/mar/30   b.e. - added billing-via-rma-data-entry and 
// date-start-rma-data-entry
// 2005/jul/20   b.e. - added yellow pages and replace-by-doc-nbr
// 2006/oct/16   b.e.  - cosmetic change - remove  Mcmaster  label
// 2006/oct/18   b.e. - added prior-doc-nbr
// 2007/aug/21   b.e. - added cop-nbr
// 2008/may/22   M.C.    - added doc-flag-primary
// 2013/sep/30   MC1     - added doc-fiscal-yr-start-month, has-valid-current-payroll-record, pay-this-doctor-ohip-premium
// 2005/03/30 - MC
// screen $pb_obj/m020a receiving x-doc-nbr, x-doc-name  

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

    partial class Billing_M020A : BasePage
    {

        #region " Form Designer Generated Code "





        public Billing_M020A()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "M020A";

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
            dsrDesigner_03.Click += dsrDesigner_03_Click;
            dsrDesigner_04.Click += dsrDesigner_04_Click;
            dsrDesigner_01.Click += dsrDesigner_01_Click;
            dsrDesigner_23.Click += dsrDesigner_23_Click;
            dsrDesigner_02.Click += dsrDesigner_02_Click;
            dsrDesigner_05.Click += dsrDesigner_05_Click;
            base.Page_Load();

        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            X_DOC_DEPT = new CoreDecimal("X_DOC_DEPT", 2, this);
            X_DOC_NBR = new CoreCharacter("X_DOC_NBR", 3, this, Common.cEmptyString);
            X_DOC_NAME = new CoreCharacter("X_DOC_NAME", 30, this, Common.cEmptyString);
            fleF020_DOCTOR_EXTRA = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_EXTRA", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF070_DEPT_MSTR = new SqlFileObject(this, FileTypes.Reference, 0, "[101C].INDEXED", "F070_DEPT_MSTR", "", false, false, false, 0, "m_cnnQUERY");
            fleF123_COMPANY_MSTR = new SqlFileObject(this, FileTypes.Reference, 0, "[101C].INDEXED", "F123_COMPANY_MSTR", "", false, false, false, 0, "m_cnnQUERY");

          
            fleF070_DEPT_MSTR.Access += fleF070_DEPT_MSTR_Access;
            fleF123_COMPANY_MSTR.Access += fleF123_COMPANY_MSTR_Access;
            fleF020_DOCTOR_EXTRA.InitializeItems += fleF020_DOCTOR_EXTRA_InitializeItems;
        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;
            fleF070_DEPT_MSTR.Access -= fleF070_DEPT_MSTR_Access;
            fleF123_COMPANY_MSTR.Access -= fleF123_COMPANY_MSTR_Access;
            fleF020_DOCTOR_EXTRA.InitializeItems -= fleF020_DOCTOR_EXTRA_InitializeItems;
            dsrDesigner_03.Click -= dsrDesigner_03_Click;
            dsrDesigner_04.Click -= dsrDesigner_04_Click;
            dsrDesigner_01.Click -= dsrDesigner_01_Click;
            dsrDesigner_23.Click -= dsrDesigner_23_Click;
            dsrDesigner_02.Click -= dsrDesigner_02_Click;
            dsrDesigner_05.Click -= dsrDesigner_05_Click;


        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private SqlConnection m_cnnQUERY = new SqlConnection();
        private SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
        private SqlTransaction m_trnTRANS_UPDATE;
        private CoreDecimal X_DOC_DEPT;
        private CoreCharacter X_DOC_NBR;
        private CoreCharacter X_DOC_NAME;
        private SqlFileObject fleF020_DOCTOR_EXTRA;

        private void fleF020_DOCTOR_EXTRA_InitializeItems(bool Fixed)
        {

            try
            {
                if (!Fixed)
                    fleF020_DOCTOR_EXTRA.set_SetValue("DOC_NBR", true, X_DOC_NBR.Value);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }

        private SqlFileObject fleF070_DEPT_MSTR;

        private void fleF070_DEPT_MSTR_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleF070_DEPT_MSTR.ElementOwner("DEPT_NBR")).Append(" = ").Append((X_DOC_DEPT.Value));

                strText.Append(" ORDER BY ").Append(fleF070_DEPT_MSTR.ElementOwner("DEPT_NBR"));
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

        private SqlFileObject fleF123_COMPANY_MSTR;

        private void fleF123_COMPANY_MSTR_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleF123_COMPANY_MSTR.ElementOwner("COMPANY_NBR")).Append(" = ").Append((fleF070_DEPT_MSTR.GetDecimalValue("DEPT_COMPANY").ToString()));

                strText.Append(" ORDER BY ").Append(fleF123_COMPANY_MSTR.ElementOwner("COMPANY_NBR"));
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


        #endregion

        #region "Standard Generated Procedures"

        #region "Grid Field Declarations"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:13:10 AM

        //# No code was generated or needed for this region.

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:13:10 AM

        //# No code was generated or needed for this region.

        #endregion

        #region "Transaction Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:13:10 AM

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
            fleF020_DOCTOR_EXTRA.Transaction = m_trnTRANS_UPDATE;


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:13:10 AM

        //#-----------------------------------------
        //# InitializeFiles Procedure.
        //#-----------------------------------------

        protected override void InitializeFiles()
        {

            try
            {
                Initialize_TRANS_UPDATE();
                fleF070_DEPT_MSTR.Connection = m_cnnQUERY;
                fleF123_COMPANY_MSTR.Connection = m_cnnQUERY;


            }
            catch (CustomApplicationException ex)
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
                fleF020_DOCTOR_EXTRA.Dispose();
                fleF070_DEPT_MSTR.Dispose();
                fleF123_COMPANY_MSTR.Dispose();


            }
            catch (CustomApplicationException ex)
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:13:10 AM
        //#-----------------------------------------
        protected override void DisplayFormatting()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:13:10 AM
               Display(ref fldF020_DOCTOR_EXTRA_BILLING_VIA_WEB_TEST_FLAG);
                Display(ref fldF020_DOCTOR_EXTRA_DATE_START_WEB_TEST);
                Display(ref fldF020_DOCTOR_EXTRA_BILLING_VIA_WEB_LIVE_FLAG);
                Display(ref fldF020_DOCTOR_EXTRA_DATE_START_WEB_LIVE);
                Display(ref fldF020_DOCTOR_EXTRA_BILLING_VIA_RMA_DATA_ENTRY);
                Display(ref fldF020_DOCTOR_EXTRA_DATE_START_RMA_DATA_ENTRY);
                Display(ref fldF020_DOCTOR_EXTRA_BILLING_VIA_PAPER_FLAG);
                Display(ref fldF020_DOCTOR_EXTRA_DATE_START_PAPER);
                Display(ref fldF020_DOCTOR_EXTRA_BILLING_VIA_DISKETTE_FLAG);
                Display(ref fldF020_DOCTOR_EXTRA_DATE_START_DISKETTE);
                Display(ref fldF020_DOCTOR_EXTRA_WEB_USER_REVENUE_ONLY_FLAG);
                Display(ref fldF123_COMPANY_MSTR_COMPANY_NAME);
                Display(ref fldF020_DOCTOR_EXTRA_DOC_MED_PROF_CORP);
                Display(ref fldF020_DOCTOR_EXTRA_CHAIR_FLAG);
                Display(ref fldF020_DOCTOR_EXTRA_ABE_USER_FLAG);
                Display(ref fldF020_DOCTOR_EXTRA_YELLOW_PAGES_FLAG);
                Display(ref fldF020_DOCTOR_EXTRA_HAS_VALID_CURRENT_PAYROLL_RECORD);
                Display(ref fldF020_DOCTOR_EXTRA_PAY_THIS_DOCTOR_OHIP_PREMIUM);
                Display(ref fldF020_DOCTOR_EXTRA_CPSO_NBR);
                Display(ref fldF020_DOCTOR_EXTRA_CMPA_NBR);
                Display(ref fldF020_DOCTOR_EXTRA_OMA_NBR);
                Display(ref fldF020_DOCTOR_EXTRA_CFPC_NBR);
                Display(ref fldF020_DOCTOR_EXTRA_RCPSC_NBR);
                Display(ref fldF020_DOCTOR_EXTRA_COP_NBR);
                Display(ref fldF020_DOCTOR_EXTRA_MCMASTER_EMPLOYEE_ID);
                Display(ref fldF020_DOCTOR_EXTRA_PRIOR_DOC_NBR);
                Display(ref fldF020_DOCTOR_EXTRA_REPLACED_BY_DOC_NBR);
                Display(ref fldF020_DOCTOR_EXTRA_LEAVE_DESCRIPTION);
                Display(ref fldF020_DOCTOR_EXTRA_LEAVE_DATE_START);
                Display(ref fldF020_DOCTOR_EXTRA_LEAVE_DATE_END);
                Display(ref fldF020_DOCTOR_EXTRA_DOC_FLAG_PRIMARY);
                Display(ref fldF020_DOCTOR_EXTRA_DOC_FISCAL_YR_START_MONTH);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:13:10 AM
        //#-----------------------------------------
        protected override void PreDisplayFormatting()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:13:10 AM
              
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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:13:10 AM

        //#-----------------------------------------
        //# BindFields Procedure.
        //#-----------------------------------------

        public override void BindFields()
        {
            try
            {
               
                fldF020_DOCTOR_EXTRA_BILLING_VIA_WEB_TEST_FLAG.Bind(fleF020_DOCTOR_EXTRA);
                fldF020_DOCTOR_EXTRA_DATE_START_WEB_TEST.Bind(fleF020_DOCTOR_EXTRA);
                fldF020_DOCTOR_EXTRA_BILLING_VIA_WEB_LIVE_FLAG.Bind(fleF020_DOCTOR_EXTRA);
                fldF020_DOCTOR_EXTRA_DATE_START_WEB_LIVE.Bind(fleF020_DOCTOR_EXTRA);
                fldF020_DOCTOR_EXTRA_BILLING_VIA_RMA_DATA_ENTRY.Bind(fleF020_DOCTOR_EXTRA);
                fldF020_DOCTOR_EXTRA_DATE_START_RMA_DATA_ENTRY.Bind(fleF020_DOCTOR_EXTRA);
                fldF020_DOCTOR_EXTRA_BILLING_VIA_PAPER_FLAG.Bind(fleF020_DOCTOR_EXTRA);
                fldF020_DOCTOR_EXTRA_DATE_START_PAPER.Bind(fleF020_DOCTOR_EXTRA);
                fldF020_DOCTOR_EXTRA_BILLING_VIA_DISKETTE_FLAG.Bind(fleF020_DOCTOR_EXTRA);
                fldF020_DOCTOR_EXTRA_DATE_START_DISKETTE.Bind(fleF020_DOCTOR_EXTRA);
                fldF020_DOCTOR_EXTRA_WEB_USER_REVENUE_ONLY_FLAG.Bind(fleF020_DOCTOR_EXTRA);
                fldF123_COMPANY_MSTR_COMPANY_NAME.Bind(fleF123_COMPANY_MSTR);
                fldF020_DOCTOR_EXTRA_DOC_MED_PROF_CORP.Bind(fleF020_DOCTOR_EXTRA);
                fldF020_DOCTOR_EXTRA_CHAIR_FLAG.Bind(fleF020_DOCTOR_EXTRA);
                fldF020_DOCTOR_EXTRA_ABE_USER_FLAG.Bind(fleF020_DOCTOR_EXTRA);
                fldF020_DOCTOR_EXTRA_YELLOW_PAGES_FLAG.Bind(fleF020_DOCTOR_EXTRA);
                fldF020_DOCTOR_EXTRA_HAS_VALID_CURRENT_PAYROLL_RECORD.Bind(fleF020_DOCTOR_EXTRA);
                fldF020_DOCTOR_EXTRA_PAY_THIS_DOCTOR_OHIP_PREMIUM.Bind(fleF020_DOCTOR_EXTRA);
                fldF020_DOCTOR_EXTRA_CPSO_NBR.Bind(fleF020_DOCTOR_EXTRA);
                fldF020_DOCTOR_EXTRA_CMPA_NBR.Bind(fleF020_DOCTOR_EXTRA);
                fldF020_DOCTOR_EXTRA_OMA_NBR.Bind(fleF020_DOCTOR_EXTRA);
                fldF020_DOCTOR_EXTRA_CFPC_NBR.Bind(fleF020_DOCTOR_EXTRA);
                fldF020_DOCTOR_EXTRA_RCPSC_NBR.Bind(fleF020_DOCTOR_EXTRA);
                fldF020_DOCTOR_EXTRA_COP_NBR.Bind(fleF020_DOCTOR_EXTRA);
                fldF020_DOCTOR_EXTRA_MCMASTER_EMPLOYEE_ID.Bind(fleF020_DOCTOR_EXTRA);
                fldF020_DOCTOR_EXTRA_PRIOR_DOC_NBR.Bind(fleF020_DOCTOR_EXTRA);
                fldF020_DOCTOR_EXTRA_REPLACED_BY_DOC_NBR.Bind(fleF020_DOCTOR_EXTRA);
                fldF020_DOCTOR_EXTRA_LEAVE_DESCRIPTION.Bind(fleF020_DOCTOR_EXTRA);
                fldF020_DOCTOR_EXTRA_LEAVE_DATE_START.Bind(fleF020_DOCTOR_EXTRA);
                fldF020_DOCTOR_EXTRA_LEAVE_DATE_END.Bind(fleF020_DOCTOR_EXTRA);
                fldF020_DOCTOR_EXTRA_DOC_FLAG_PRIMARY.Bind(fleF020_DOCTOR_EXTRA);
                fldF020_DOCTOR_EXTRA_DOC_FISCAL_YR_START_MONTH.Bind(fleF020_DOCTOR_EXTRA);

            }
            catch (CustomApplicationException ex)
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
                SaveReceivingParams(X_DOC_NBR, X_DOC_NAME, X_DOC_DEPT);


            }
            catch (CustomApplicationException ex)
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
                Receiving(X_DOC_NBR, X_DOC_NAME, X_DOC_DEPT);


            }
            catch (CustomApplicationException ex)
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
                m_strWhere = new StringBuilder(GetWhereCondition(fleF020_DOCTOR_EXTRA.ElementOwner("DOC_NBR"), X_DOC_NBR.Value, ref blnAddWhere));
                fleF020_DOCTOR_EXTRA.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);


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
                Page.PageTitle = "More info Doc:" + X_DOC_NBR.Value + " / " + X_DOC_NAME.Value;



            }
            catch (CustomApplicationException ex)
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:13:10 AM
        //#-----------------------------------------
        protected override bool Entry()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:13:10 AM
              
                Accept(ref fldF020_DOCTOR_EXTRA_BILLING_VIA_WEB_TEST_FLAG);
                Accept(ref fldF020_DOCTOR_EXTRA_DATE_START_WEB_TEST);
                Accept(ref fldF020_DOCTOR_EXTRA_BILLING_VIA_WEB_LIVE_FLAG);
                Accept(ref fldF020_DOCTOR_EXTRA_DATE_START_WEB_LIVE);
                Accept(ref fldF020_DOCTOR_EXTRA_BILLING_VIA_RMA_DATA_ENTRY);
                Accept(ref fldF020_DOCTOR_EXTRA_DATE_START_RMA_DATA_ENTRY);
                Accept(ref fldF020_DOCTOR_EXTRA_BILLING_VIA_PAPER_FLAG);
                Accept(ref fldF020_DOCTOR_EXTRA_DATE_START_PAPER);
                Accept(ref fldF020_DOCTOR_EXTRA_BILLING_VIA_DISKETTE_FLAG);
                Accept(ref fldF020_DOCTOR_EXTRA_DATE_START_DISKETTE);
                Accept(ref fldF020_DOCTOR_EXTRA_WEB_USER_REVENUE_ONLY_FLAG);
                Display(ref fldF123_COMPANY_MSTR_COMPANY_NAME);
                Accept(ref fldF020_DOCTOR_EXTRA_DOC_MED_PROF_CORP);
                Accept(ref fldF020_DOCTOR_EXTRA_CHAIR_FLAG);
                Accept(ref fldF020_DOCTOR_EXTRA_ABE_USER_FLAG);
                Accept(ref fldF020_DOCTOR_EXTRA_YELLOW_PAGES_FLAG);
                Accept(ref fldF020_DOCTOR_EXTRA_HAS_VALID_CURRENT_PAYROLL_RECORD);
                Accept(ref fldF020_DOCTOR_EXTRA_PAY_THIS_DOCTOR_OHIP_PREMIUM);
                Accept(ref fldF020_DOCTOR_EXTRA_CPSO_NBR);
                Accept(ref fldF020_DOCTOR_EXTRA_CMPA_NBR);
                Accept(ref fldF020_DOCTOR_EXTRA_OMA_NBR);
                Accept(ref fldF020_DOCTOR_EXTRA_CFPC_NBR);
                Accept(ref fldF020_DOCTOR_EXTRA_RCPSC_NBR);
                Accept(ref fldF020_DOCTOR_EXTRA_COP_NBR);
                Accept(ref fldF020_DOCTOR_EXTRA_MCMASTER_EMPLOYEE_ID);
                Display(ref fldF020_DOCTOR_EXTRA_PRIOR_DOC_NBR);
                Display(ref fldF020_DOCTOR_EXTRA_REPLACED_BY_DOC_NBR);
                Accept(ref fldF020_DOCTOR_EXTRA_LEAVE_DESCRIPTION);
                Accept(ref fldF020_DOCTOR_EXTRA_LEAVE_DATE_START);
                Accept(ref fldF020_DOCTOR_EXTRA_LEAVE_DATE_END);
                Accept(ref fldF020_DOCTOR_EXTRA_DOC_FLAG_PRIMARY);
                Accept(ref fldF020_DOCTOR_EXTRA_DOC_FISCAL_YR_START_MONTH);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:13:10 AM
        //#-----------------------------------------
        protected override bool Update()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:13:10 AM
                fleF020_DOCTOR_EXTRA.PutData(false, PutTypes.New);
                fleF020_DOCTOR_EXTRA.PutData();
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:13:10 AM
        //#-----------------------------------------
        protected override bool Delete()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:13:10 AM
                fleF020_DOCTOR_EXTRA.DeletedRecord = true;
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
        //# dsrDesigner_03_Click Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:13:10 AM
        //#-----------------------------------------
        private void dsrDesigner_03_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:13:10 AM
                Accept(ref fldF020_DOCTOR_EXTRA_BILLING_VIA_RMA_DATA_ENTRY);
                Accept(ref fldF020_DOCTOR_EXTRA_DATE_START_RMA_DATA_ENTRY);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:13:10 AM
        //#-----------------------------------------
        private void dsrDesigner_04_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:13:10 AM
                Accept(ref fldF020_DOCTOR_EXTRA_BILLING_VIA_PAPER_FLAG);
                Accept(ref fldF020_DOCTOR_EXTRA_DATE_START_PAPER);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:13:10 AM
        //#-----------------------------------------
        private void dsrDesigner_01_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:13:10 AM
                Accept(ref fldF020_DOCTOR_EXTRA_BILLING_VIA_WEB_TEST_FLAG);
                Accept(ref fldF020_DOCTOR_EXTRA_DATE_START_WEB_TEST);
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
        //# dsrDesigner_23_Click Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:13:10 AM
        //#-----------------------------------------
        private void dsrDesigner_23_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:13:10 AM
                Accept(ref fldF020_DOCTOR_EXTRA_LEAVE_DESCRIPTION);
                Accept(ref fldF020_DOCTOR_EXTRA_LEAVE_DATE_START);
                Accept(ref fldF020_DOCTOR_EXTRA_LEAVE_DATE_END);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:13:10 AM
        //#-----------------------------------------
        private void dsrDesigner_02_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:13:10 AM
                Accept(ref fldF020_DOCTOR_EXTRA_BILLING_VIA_WEB_LIVE_FLAG);
                Accept(ref fldF020_DOCTOR_EXTRA_DATE_START_WEB_LIVE);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:13:10 AM
        //#-----------------------------------------
        private void dsrDesigner_05_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:13:10 AM
                Accept(ref fldF020_DOCTOR_EXTRA_BILLING_VIA_DISKETTE_FLAG);
                Accept(ref fldF020_DOCTOR_EXTRA_DATE_START_DISKETTE);
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
