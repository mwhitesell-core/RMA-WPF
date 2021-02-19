
#region "Screen Comments"

// #> PROGRAM-ID.     M199.QKS
// ((C)) Dyad Technologies
// PURPOSE: MAINTENANCE OF THE DESCRIPTIONS FOR USER DEFINED FIELDS
// MODIFICATION HISTORY
// DATE    SAF #  WHO      DESCRIPTION
// 92/JAN/01  ____   R.A.     - original
// 1999/Apr/22  S.B.   - Recheck for Y2K.
// 1999/Jun/07         S.B.     - Altered the call to scrtitle.use and
// stdhilite.use to be called from $use
// instead of src.
// - Removed the call to secfile.use because
// it was not doing anything.

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

    partial class Billing_M199 : BasePage
    {

        #region " Form Designer Generated Code "





        public Billing_M199()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "M199";

            //# Set the ACTIVITIES for the screen.
            this.ChangeActivity = true;
            this.FindActivity = true;
            this.DeleteActivity = true;
            this.EntryActivity = true;
            this.UseAcceptProcessing = true;



            this.HasPathRequestFields = true;







        }

        #endregion

        private void Page_Load(object sender, RoutedEventArgs e)
        {
            SetVariables();
            base.Page_Load();

            // TODO: The following FIELD(S) on the form are array elements.  Manual steps may be required:
            //       F199_USER_DEFINED_FIELDS.FIELD_DESC Occurs: 10


        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            fleF199_USER_DEFINED_FIELDS = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F199_USER_DEFINED_FIELDS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
           

         
            X_SCREEN_NAME.GetValue += X_SCREEN_NAME_GetValue;
            X_SCR_NAME.GetValue += X_SCR_NAME_GetValue;
        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;
            X_SCREEN_NAME.GetValue -= X_SCREEN_NAME_GetValue;
            X_SCR_NAME.GetValue -= X_SCR_NAME_GetValue;


        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private SqlConnection m_cnnQUERY = new SqlConnection();
        private SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
        private SqlTransaction m_trnTRANS_UPDATE;
        private SqlFileObject fleF199_USER_DEFINED_FIELDS;

   





      
        private DCharacter X_SCREEN_NAME = new DCharacter(55);
        private void X_SCREEN_NAME_GetValue(ref string Value)
        {

            try
            {
                Value = "USER DEFINED FIELDS Description Maintenance";


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        //#CORE_BEGIN_INCLUDE: SCRTITLE"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:15:23 AM

        private DCharacter X_SCR_NAME = new DCharacter(55);
        private void X_SCR_NAME_GetValue(ref string Value)
        {

            try
            {
                Value = QDesign.RightJustify(X_SCREEN_NAME.Value);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }

        //#CORE_END_INCLUDE: SCRTITLE"


        #endregion

        #region "Standard Generated Procedures"

        #region "Grid Field Declarations"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:15:23 AM

        //# No code was generated or needed for this region.

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:15:23 AM

        //# No code was generated or needed for this region.

        #endregion

        #region "Transaction Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:15:23 AM

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
            fleF199_USER_DEFINED_FIELDS.Transaction = m_trnTRANS_UPDATE;


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:15:23 AM

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
                fleF199_USER_DEFINED_FIELDS.Dispose();


            }
            catch (CustomApplicationException ex)
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:15:23 AM
        //#-----------------------------------------
        protected override void DisplayFormatting()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:15:23 AM
                Display(ref fldF199_USER_DEFINED_FIELDS_RECORD_ID);
                Display(ref fldF199_USER_DEFINED_FIELDS_INTERPRETATION_DESC);
                Display(ref fldF199_USER_DEFINED_FIELDS_FIELD_DESC1);
                Display(ref fldF199_USER_DEFINED_FIELDS_FIELD_DESC2);
                Display(ref fldF199_USER_DEFINED_FIELDS_FIELD_DESC3);
                Display(ref fldF199_USER_DEFINED_FIELDS_FIELD_DESC4);
                Display(ref fldF199_USER_DEFINED_FIELDS_FIELD_DESC5);
                Display(ref fldF199_USER_DEFINED_FIELDS_FIELD_DESC6);
                Display(ref fldF199_USER_DEFINED_FIELDS_FIELD_DESC7);
                Display(ref fldF199_USER_DEFINED_FIELDS_FIELD_DESC8);
                Display(ref fldF199_USER_DEFINED_FIELDS_FIELD_DESC9);
                Display(ref fldF199_USER_DEFINED_FIELDS_FIELD_DESC10);
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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:15:23 AM

        //#-----------------------------------------
        //# BindFields Procedure.
        //#-----------------------------------------

        public override void BindFields()
        {
            try
            {
                fldF199_USER_DEFINED_FIELDS_RECORD_ID.Bind(fleF199_USER_DEFINED_FIELDS);
                fldF199_USER_DEFINED_FIELDS_INTERPRETATION_DESC.Bind(fleF199_USER_DEFINED_FIELDS);
                fldF199_USER_DEFINED_FIELDS_FIELD_DESC1.Bind(fleF199_USER_DEFINED_FIELDS);
                fldF199_USER_DEFINED_FIELDS_FIELD_DESC2.Bind(fleF199_USER_DEFINED_FIELDS);
                fldF199_USER_DEFINED_FIELDS_FIELD_DESC3.Bind(fleF199_USER_DEFINED_FIELDS);
                fldF199_USER_DEFINED_FIELDS_FIELD_DESC4.Bind(fleF199_USER_DEFINED_FIELDS);
                fldF199_USER_DEFINED_FIELDS_FIELD_DESC5.Bind(fleF199_USER_DEFINED_FIELDS);
                fldF199_USER_DEFINED_FIELDS_FIELD_DESC6.Bind(fleF199_USER_DEFINED_FIELDS);
                fldF199_USER_DEFINED_FIELDS_FIELD_DESC7.Bind(fleF199_USER_DEFINED_FIELDS);
                fldF199_USER_DEFINED_FIELDS_FIELD_DESC8.Bind(fleF199_USER_DEFINED_FIELDS);
                fldF199_USER_DEFINED_FIELDS_FIELD_DESC9.Bind(fleF199_USER_DEFINED_FIELDS);
                fldF199_USER_DEFINED_FIELDS_FIELD_DESC10.Bind(fleF199_USER_DEFINED_FIELDS);

            }
            catch (CustomApplicationException ex)
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
                switch (m_intPath)
                {
                    case 1:
                        m_strWhere = new StringBuilder(GetWhereCondition(fleF199_USER_DEFINED_FIELDS.ElementOwner("RECORD_ID"), fleF199_USER_DEFINED_FIELDS.GetStringValue("RECORD_ID"), ref blnAddWhere));
                        fleF199_USER_DEFINED_FIELDS.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
                        break;
                    default:
                        fleF199_USER_DEFINED_FIELDS.GetData(GetDataOptions.Sequential | GetDataOptions.CreateSubSelect);
                        break;
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
                m_intPath = 0;

                RequestPrompt(ref fldF199_USER_DEFINED_FIELDS_RECORD_ID);
                if (m_blnPromptOK)
                {
                    m_intPath = 1;
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
                Page.PageTitle = X_SCR_NAME.Value;


            }
            catch (CustomApplicationException ex)
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:15:23 AM
        //#-----------------------------------------
        protected override bool Entry()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:15:23 AM
                Accept(ref fldF199_USER_DEFINED_FIELDS_RECORD_ID);
                Accept(ref fldF199_USER_DEFINED_FIELDS_INTERPRETATION_DESC);
                Accept(ref fldF199_USER_DEFINED_FIELDS_FIELD_DESC1);
                Accept(ref fldF199_USER_DEFINED_FIELDS_FIELD_DESC2);
                Accept(ref fldF199_USER_DEFINED_FIELDS_FIELD_DESC3);
                Accept(ref fldF199_USER_DEFINED_FIELDS_FIELD_DESC4);
                Accept(ref fldF199_USER_DEFINED_FIELDS_FIELD_DESC5);
                Accept(ref fldF199_USER_DEFINED_FIELDS_FIELD_DESC6);
                Accept(ref fldF199_USER_DEFINED_FIELDS_FIELD_DESC7);
                Accept(ref fldF199_USER_DEFINED_FIELDS_FIELD_DESC8);
                Accept(ref fldF199_USER_DEFINED_FIELDS_FIELD_DESC9);
                Accept(ref fldF199_USER_DEFINED_FIELDS_FIELD_DESC10);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:15:23 AM
        //#-----------------------------------------
        protected override bool Update()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:15:23 AM
                fleF199_USER_DEFINED_FIELDS.PutData(false, PutTypes.New);
                fleF199_USER_DEFINED_FIELDS.PutData();
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:15:23 AM
        //#-----------------------------------------
        protected override bool Delete()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:15:23 AM
                fleF199_USER_DEFINED_FIELDS.DeletedRecord = true;
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

        #endregion

        #endregion

    }


}
