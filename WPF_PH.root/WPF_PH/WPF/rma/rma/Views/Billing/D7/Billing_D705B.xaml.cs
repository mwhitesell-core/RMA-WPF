
#region "Screen Comments"

// #> PROGRAM-ID.     D705B.QKS
// ((C)) Dyad Technologies
// PROGRAM PURPOSE: TO ALLOW QUERY/CORRECTIONS TO
// SUSPENDED ** ADDRESS ** RECORDS
// MODIFICATION HISTORY
// DATE   WHO          DESCRIPTION
// 91/FEB/15 D.B.         - ORIGINAL
// 93/07/14  M.C.      - SMS 142
// - INCLUDE THE PHONE NBR
// 1999/jan/31 B.E.      - y2k

#endregion



using System;
using System.IO;
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

    partial class Billing_D705B : BasePage
    {

        #region " Form Designer Generated Code "





        public Billing_D705B()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "D705B";

            //# Set the ACTIVITIES for the screen.
            this.ChangeActivity = true;
            this.FindActivity = true;
            this.DeleteActivity = false;
            this.EntryActivity = false;
            this.UseAcceptProcessing = true;








        }

        #endregion


        private void Page_Load(object sender, RoutedEventArgs e)
        {
            SetVariables();
            dsrDesigner_01.Click += dsrDesigner_01_Click;

            base.Page_Load();

        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            W_CLMHDR_DOC_OHIP_NBR = new CoreDecimal("W_CLMHDR_DOC_OHIP_NBR", 6, this);
            W_CLMHDR_ACCOUNTING_NBR = new CoreCharacter("W_CLMHDR_ACCOUNTING_NBR", 8, this, Common.cEmptyString);
            fleF002_SUSPEND_ADDRESS = new SqlFileObject(this, FileTypes.Primary, 0, Environment.GetEnvironmentVariable("VS_DIRECTORY"), "F002_SUSPEND_ADDRESS", "", false, false, false, 0, "m_trnTRANS_UPDATE");


        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;

            dsrDesigner_01.Click -= dsrDesigner_01_Click;

            Core.Framework.Core.Windows.Framework.ApplicationState.Current.CurrentConnectionStrings = Environment.GetEnvironmentVariable("LastConnectionString");
        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private SqlConnection m_cnnQUERY = new SqlConnection();
        private SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
        private SqlTransaction m_trnTRANS_UPDATE;
        private CoreDecimal W_CLMHDR_DOC_OHIP_NBR;
        private CoreCharacter W_CLMHDR_ACCOUNTING_NBR;
        private SqlFileObject fleF002_SUSPEND_ADDRESS;
        #endregion

        #region "Standard Generated Procedures"

        #region "Grid Field Declarations"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:08:32 AM

        //# No code was generated or needed for this region.

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:08:32 AM

        //# No code was generated or needed for this region.

        #endregion

        #region "Transaction Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:08:32 AM

        //#-----------------------------------------
        //# InitializeTransactionObjects Procedure.
        //#-----------------------------------------

        protected override void InitializeTransactionObjects()
        {

            try
            {
                m_cnnTRANS_UPDATE = new SqlConnection(Common.ConnectionStringDecrypt(System.Configuration.ConfigurationManager.AppSettings["ConnectionString10"]));
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
            fleF002_SUSPEND_ADDRESS.Transaction = m_trnTRANS_UPDATE;


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:08:32 AM

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
                fleF002_SUSPEND_ADDRESS.Dispose();


            }
            catch (CustomApplicationException ex)
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:08:32 AM
        //#-----------------------------------------
        protected override void DisplayFormatting()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:08:32 AM
                Display(ref fldF002_SUSPEND_ADDRESS_ADD_DOC_OHIP_NBR);
                Display(ref fldF002_SUSPEND_ADDRESS_ADD_ACCOUNTING_NBR);
                Display(ref fldF002_SUSPEND_ADDRESS_ADD_ADDRESS_LINE_1);
                Display(ref fldF002_SUSPEND_ADDRESS_ADD_ADDRESS_LINE_2);
                Display(ref fldF002_SUSPEND_ADDRESS_ADD_ADDRESS_LINE_3);
                Display(ref fldF002_SUSPEND_ADDRESS_ADD_POSTAL_CODE);
                Display(ref fldF002_SUSPEND_ADDRESS_ADD_SURNAME);
                Display(ref fldF002_SUSPEND_ADDRESS_ADD_FIRST_NAME);
                Display(ref fldF002_SUSPEND_ADDRESS_ADD_BIRTH_DATE);
                Display(ref fldF002_SUSPEND_ADDRESS_ADD_SEX);
                Display(ref fldF002_SUSPEND_ADDRESS_ADD_PHONE_NO);
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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:08:32 AM

        //#-----------------------------------------
        //# BindFields Procedure.
        //#-----------------------------------------

        public override void BindFields()
        {
            try
            {
                fldF002_SUSPEND_ADDRESS_ADD_DOC_OHIP_NBR.Bind(fleF002_SUSPEND_ADDRESS);
                fldF002_SUSPEND_ADDRESS_ADD_ACCOUNTING_NBR.Bind(fleF002_SUSPEND_ADDRESS);
                fldF002_SUSPEND_ADDRESS_ADD_ADDRESS_LINE_1.Bind(fleF002_SUSPEND_ADDRESS);
                fldF002_SUSPEND_ADDRESS_ADD_ADDRESS_LINE_2.Bind(fleF002_SUSPEND_ADDRESS);
                fldF002_SUSPEND_ADDRESS_ADD_ADDRESS_LINE_3.Bind(fleF002_SUSPEND_ADDRESS);
                fldF002_SUSPEND_ADDRESS_ADD_POSTAL_CODE.Bind(fleF002_SUSPEND_ADDRESS);
                fldF002_SUSPEND_ADDRESS_ADD_SURNAME.Bind(fleF002_SUSPEND_ADDRESS);
                fldF002_SUSPEND_ADDRESS_ADD_FIRST_NAME.Bind(fleF002_SUSPEND_ADDRESS);
                fldF002_SUSPEND_ADDRESS_ADD_BIRTH_DATE.Bind(fleF002_SUSPEND_ADDRESS);
                fldF002_SUSPEND_ADDRESS_ADD_SEX.Bind(fleF002_SUSPEND_ADDRESS);
                fldF002_SUSPEND_ADDRESS_ADD_PHONE_NO.Bind(fleF002_SUSPEND_ADDRESS);

            }
            catch (CustomApplicationException ex)
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
                SaveReceivingParams(W_CLMHDR_DOC_OHIP_NBR, W_CLMHDR_ACCOUNTING_NBR);


            }
            catch (CustomApplicationException ex)
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
                Receiving(W_CLMHDR_DOC_OHIP_NBR, W_CLMHDR_ACCOUNTING_NBR);


            }
            catch (CustomApplicationException ex)
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
                Environment.SetEnvironmentVariable("LastConnectionString", Core.Framework.Core.Windows.Framework.ApplicationState.Current.CurrentConnectionStrings.ToString());
                Core.Framework.Core.Windows.Framework.ApplicationState.Current.CurrentConnectionStrings = "ConnectionString10";

                bool blnAddWhere = true;
                m_strWhere = new StringBuilder(GetWhereCondition(fleF002_SUSPEND_ADDRESS.ElementOwner("ADD_DOC_OHIP_NBR"), W_CLMHDR_DOC_OHIP_NBR.Value, ref blnAddWhere));
                m_strWhere.Append(GetWhereCondition(fleF002_SUSPEND_ADDRESS.ElementOwner("ADD_ACCOUNTING_NBR"), W_CLMHDR_ACCOUNTING_NBR.Value, ref blnAddWhere));
                fleF002_SUSPEND_ADDRESS.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);

                Core.Framework.Core.Windows.Framework.ApplicationState.Current.CurrentConnectionStrings = Environment.GetEnvironmentVariable("LastConnectionString");

                return true;


            }
            catch (CustomApplicationException ex)
            {
                Core.Framework.Core.Windows.Framework.ApplicationState.Current.CurrentConnectionStrings = Environment.GetEnvironmentVariable("LastConnectionString");
                throw ex;


            }
            catch (Exception ex)
            {
                Core.Framework.Core.Windows.Framework.ApplicationState.Current.CurrentConnectionStrings = Environment.GetEnvironmentVariable("LastConnectionString");
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
                Page.PageTitle = "SUSPENDED ** ADDRESS **";



            }
            catch (CustomApplicationException ex)
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:08:32 AM
        //#-----------------------------------------
        protected override bool Update()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:08:32 AM
                fleF002_SUSPEND_ADDRESS.PutData();
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
        //# dsrDesigner_01_Click Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:08:32 AM
        //#-----------------------------------------
        private void dsrDesigner_01_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:08:32 AM
                if (!fleF002_SUSPEND_ADDRESS.NewRecord)
                {
                    Display(ref fldF002_SUSPEND_ADDRESS_ADD_DOC_OHIP_NBR);
                }
                else
                {
                    Accept(ref fldF002_SUSPEND_ADDRESS_ADD_DOC_OHIP_NBR);
                }
                if (!fleF002_SUSPEND_ADDRESS.NewRecord)
                {
                    Display(ref fldF002_SUSPEND_ADDRESS_ADD_ACCOUNTING_NBR);
                }
                else
                {
                    Accept(ref fldF002_SUSPEND_ADDRESS_ADD_ACCOUNTING_NBR);
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

        #endregion

        #endregion

    }


}
