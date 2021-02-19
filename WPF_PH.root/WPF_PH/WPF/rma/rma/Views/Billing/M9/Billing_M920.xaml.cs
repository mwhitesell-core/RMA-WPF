
#region "Screen Comments"

// #> program-id.     m920.qks
// ((C)) Dyad Systems
// program purpose : Maintain settings of doctor options
// MODIFICATION HISTORY
// DATE    WHO      DESCRIPTION
// 2001/sep/18  D.B. - original
// 2003/dec/10  A.A. - alpha doctor nbr

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

    partial class Billing_M920 : BasePage
    {

        #region " Form Designer Generated Code "





        public Billing_M920()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "M920";

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
            dtlF920_DOCTOR_OPTIONS.EditClick += dtlF920_DOCTOR_OPTIONS_EditClick;
            base.Page_Load();

            // TODO: If any DESIGNER procedures function on occurring FILES or TEMPORARIES, set the grid's AllowSelectRowButton property to TRUE.



        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            W_DOC_NBR = new CoreCharacter("W_DOC_NBR", 3, this, Common.cEmptyString);
            fleF920_DOCTOR_OPTIONS = new SqlFileObject(this, FileTypes.Primary, 11, "INDEXED", "F920_DOCTOR_OPTIONS", "", false, false, false, 0, "m_trnTRANS_UPDATE");

           

            fleF920_DOCTOR_OPTIONS.InitializeItems += fleF920_DOCTOR_OPTIONS_InitializeItems;
        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;


            dtlF920_DOCTOR_OPTIONS.EditClick -= dtlF920_DOCTOR_OPTIONS_EditClick;
            dsrDesigner_01.Click -= dsrDesigner_01_Click;
            fleF920_DOCTOR_OPTIONS.InitializeItems -= fleF920_DOCTOR_OPTIONS_InitializeItems;


        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private SqlConnection m_cnnQUERY = new SqlConnection();
        private SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
        private SqlTransaction m_trnTRANS_UPDATE;
        private CoreCharacter W_DOC_NBR;
        private SqlFileObject fleF920_DOCTOR_OPTIONS;

        private void fleF920_DOCTOR_OPTIONS_InitializeItems(bool Fixed)
        {

            try
            {
                if (!Fixed)
                    fleF920_DOCTOR_OPTIONS.set_SetValue("DOC_NBR", true, W_DOC_NBR.Value);


            }
            catch (CustomApplicationException ex)
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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:17:08 AM

        protected TextBox fldF920_DOCTOR_OPTIONS_DOC_OPTION_CATEGORY;
        protected TextBox fldF920_DOCTOR_OPTIONS_DOC_OPTION_SUBCATEGORY;
        private DateControl fldF920_DOCTOR_OPTIONS_DOC_OPTION_DATE_ACTIVE_FROM;
        private DateControl fldF920_DOCTOR_OPTIONS_DOC_OPTION_DATE_ACTIVE_TO;

        protected TextBox fldF920_DOCTOR_OPTIONS_DOC_OPTION_VALUE;

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:17:08 AM

        //#-----------------------------------------
        //# GetGridFieldObject Procedure.
        //#-----------------------------------------

        protected override void GetGridFieldObject(object DataListField, ref object CoreField, string Name)
        {

            try
            {
                switch (Name.ToUpper())
                {
                    case "FLDGRDF920_DOCTOR_OPTIONS_DOC_OPTION_CATEGORY":
                        fldF920_DOCTOR_OPTIONS_DOC_OPTION_CATEGORY = (TextBox)DataListField;
                        CoreField = fldF920_DOCTOR_OPTIONS_DOC_OPTION_CATEGORY;
                        fldF920_DOCTOR_OPTIONS_DOC_OPTION_CATEGORY.Bind(fleF920_DOCTOR_OPTIONS);
                        break;
                    case "FLDGRDF920_DOCTOR_OPTIONS_DOC_OPTION_SUBCATEGORY":
                        fldF920_DOCTOR_OPTIONS_DOC_OPTION_SUBCATEGORY = (TextBox)DataListField;
                        CoreField = fldF920_DOCTOR_OPTIONS_DOC_OPTION_SUBCATEGORY;
                        fldF920_DOCTOR_OPTIONS_DOC_OPTION_SUBCATEGORY.Bind(fleF920_DOCTOR_OPTIONS);
                        break;
                    case "FLDGRDF920_DOCTOR_OPTIONS_DOC_OPTION_DATE_ACTIVE_FROM":
                        fldF920_DOCTOR_OPTIONS_DOC_OPTION_DATE_ACTIVE_FROM = (DateControl)DataListField;
                        CoreField = fldF920_DOCTOR_OPTIONS_DOC_OPTION_DATE_ACTIVE_FROM;
                        fldF920_DOCTOR_OPTIONS_DOC_OPTION_DATE_ACTIVE_FROM.Bind(fleF920_DOCTOR_OPTIONS);
                        fldF920_DOCTOR_OPTIONS_DOC_OPTION_DATE_ACTIVE_FROM.LookupNotOn -= fldF920_DOCTOR_OPTIONS_DOC_OPTION_DATE_ACTIVE_FROM_LookupNotOn;
                        fldF920_DOCTOR_OPTIONS_DOC_OPTION_DATE_ACTIVE_FROM.Edit -= fldF920_DOCTOR_OPTIONS_DOC_OPTION_DATE_ACTIVE_FROM_Edit;
                        fldF920_DOCTOR_OPTIONS_DOC_OPTION_DATE_ACTIVE_FROM.LookupNotOn += fldF920_DOCTOR_OPTIONS_DOC_OPTION_DATE_ACTIVE_FROM_LookupNotOn;
                        fldF920_DOCTOR_OPTIONS_DOC_OPTION_DATE_ACTIVE_FROM.Edit += fldF920_DOCTOR_OPTIONS_DOC_OPTION_DATE_ACTIVE_FROM_Edit;
                        break;
                    case "FLDGRDF920_DOCTOR_OPTIONS_DOC_OPTION_DATE_ACTIVE_TO":
                        fldF920_DOCTOR_OPTIONS_DOC_OPTION_DATE_ACTIVE_TO = (DateControl)DataListField;
                        CoreField = fldF920_DOCTOR_OPTIONS_DOC_OPTION_DATE_ACTIVE_TO;
                        fldF920_DOCTOR_OPTIONS_DOC_OPTION_DATE_ACTIVE_TO.Bind(fleF920_DOCTOR_OPTIONS);
                        fldF920_DOCTOR_OPTIONS_DOC_OPTION_DATE_ACTIVE_TO.Edit -= fldF920_DOCTOR_OPTIONS_DOC_OPTION_DATE_ACTIVE_TO_Edit;
                        fldF920_DOCTOR_OPTIONS_DOC_OPTION_DATE_ACTIVE_TO.Edit += fldF920_DOCTOR_OPTIONS_DOC_OPTION_DATE_ACTIVE_TO_Edit;
                        break;
                    case "FLDGRDF920_DOCTOR_OPTIONS_DOC_OPTION_VALUE":
                        fldF920_DOCTOR_OPTIONS_DOC_OPTION_VALUE = (TextBox)DataListField;
                        CoreField = fldF920_DOCTOR_OPTIONS_DOC_OPTION_VALUE;
                        fldF920_DOCTOR_OPTIONS_DOC_OPTION_VALUE.Bind(fleF920_DOCTOR_OPTIONS);
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
                dtlF920_DOCTOR_OPTIONS.OccursWithFile = fleF920_DOCTOR_OPTIONS;

            }
            catch (CustomApplicationException ex)
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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:17:08 AM

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
            fleF920_DOCTOR_OPTIONS.Transaction = m_trnTRANS_UPDATE;


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:17:08 AM

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
                fleF920_DOCTOR_OPTIONS.Dispose();


            }
            catch (CustomApplicationException ex)
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

        #endregion

        #region "Update Validation"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.

        #endregion


        #region "RecordBuffer Events"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:17:08 AM



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



        private void fldF920_DOCTOR_OPTIONS_DOC_OPTION_DATE_ACTIVE_FROM_LookupNotOn(ref bool LookupNotOnExecuted)
        {

            try
            {
                bool blnAlreadyExists = false;
                StringBuilder strSQL = new StringBuilder("SELECT ").Append(fleF920_DOCTOR_OPTIONS.ElementOwner("DOC_NBR"));
                strSQL.Append(" FROM ");
                strSQL.Append(fleF920_DOCTOR_OPTIONS.TableNameWithAlias());
                strSQL.Append(" WHERE ");
                strSQL.Append("     ").Append(fleF920_DOCTOR_OPTIONS.ElementOwner("DOC_NBR")).Append(" = ").Append(Common.StringToField(fleF920_DOCTOR_OPTIONS.GetStringValue("DOC_NBR")));
                strSQL.Append(" And ").Append(fleF920_DOCTOR_OPTIONS.ElementOwner("DOC_OPTION_CATEGORY")).Append(" = ").Append(Common.StringToField(fleF920_DOCTOR_OPTIONS.GetStringValue("DOC_OPTION_CATEGORY")));
                strSQL.Append(" And ").Append(fleF920_DOCTOR_OPTIONS.ElementOwner("DOC_OPTION_SUBCATEGORY")).Append(" = ").Append(Common.StringToField(fleF920_DOCTOR_OPTIONS.GetStringValue("DOC_OPTION_SUBCATEGORY")));
                strSQL.Append(" And ").Append(fleF920_DOCTOR_OPTIONS.ElementOwner("DOC_OPTION_DATE_ACTIVE_FROM")).Append(" = ").Append(FieldValue);

                if (!LookupNotOn(strSQL, fleF920_DOCTOR_OPTIONS, new string[] { "DOC_NBR", "DOC_OPTION_CATEGORY", "DOC_OPTION_SUBCATEGORY", "DOC_OPTION_DATE_ACTIVE_FROM" }, new Object[] { fleF920_DOCTOR_OPTIONS.GetStringValue("DOC_NBR"), fleF920_DOCTOR_OPTIONS.GetStringValue("DOC_OPTION_CATEGORY"), fleF920_DOCTOR_OPTIONS.GetStringValue("DOC_OPTION_SUBCATEGORY"), FieldValue }))
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




        protected override void SaveParamsReceived()
        {

            try
            {
                SaveReceivingParams(W_DOC_NBR);


            }
            catch (CustomApplicationException ex)
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
                Receiving(W_DOC_NBR);


            }
            catch (CustomApplicationException ex)
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



        private void fldF920_DOCTOR_OPTIONS_DOC_OPTION_DATE_ACTIVE_FROM_Edit()
        {

            try
            {

                if (QDesign.NULL(fleF920_DOCTOR_OPTIONS.GetNumericDateValue("DOC_OPTION_DATE_ACTIVE_TO")) != 0 & fleF920_DOCTOR_OPTIONS.GetNumericDateValue("DOC_OPTION_DATE_ACTIVE_FROM") >= fleF920_DOCTOR_OPTIONS.GetNumericDateValue("DOC_OPTION_DATE_ACTIVE_TO"))
                {
                    ErrorMessage("\a`From` date must be < `To` date`");
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



        private void fldF920_DOCTOR_OPTIONS_DOC_OPTION_DATE_ACTIVE_TO_Edit()
        {

            try
            {

                if (fleF920_DOCTOR_OPTIONS.GetNumericDateValue("DOC_OPTION_DATE_ACTIVE_FROM") >= fleF920_DOCTOR_OPTIONS.GetNumericDateValue("DOC_OPTION_DATE_ACTIVE_TO"))
                {
                    ErrorMessage("\a`To` date must be > `From` date`");
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




        protected override bool Find()
        {


            try
            {
                bool blnAddWhere = true;
                while (fleF920_DOCTOR_OPTIONS.ForMissing())
                {
                    m_strWhere = new StringBuilder(GetWhereCondition(fleF920_DOCTOR_OPTIONS.ElementOwner("DOC_NBR"), W_DOC_NBR.Value, ref blnAddWhere));
                    fleF920_DOCTOR_OPTIONS.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
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
                Page.PageTitle = "Maintain Doctor OPTIONS";



            }
            catch (CustomApplicationException ex)
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:17:07 AM
        //#-----------------------------------------
        protected override bool Append()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:17:07 AM
                Accept(ref fldF920_DOCTOR_OPTIONS_DOC_OPTION_CATEGORY);
                Accept(ref fldF920_DOCTOR_OPTIONS_DOC_OPTION_SUBCATEGORY);
                Accept(ref fldF920_DOCTOR_OPTIONS_DOC_OPTION_DATE_ACTIVE_FROM);
                Accept(ref fldF920_DOCTOR_OPTIONS_DOC_OPTION_DATE_ACTIVE_TO);
                Accept(ref fldF920_DOCTOR_OPTIONS_DOC_OPTION_VALUE);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:17:07 AM
        //#-----------------------------------------
        protected override bool Update()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:17:07 AM
                while (fleF920_DOCTOR_OPTIONS.For())
                {
                    fleF920_DOCTOR_OPTIONS.PutData(false, PutTypes.Deleted);
                }
                while (fleF920_DOCTOR_OPTIONS.For())
                {
                    fleF920_DOCTOR_OPTIONS.PutData();
                }
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:17:07 AM
        //#-----------------------------------------
        protected override bool Delete()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:17:07 AM
                fleF920_DOCTOR_OPTIONS.DeletedRecord = true;
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
        //# dtlF920_DOCTOR_OPTIONS_EditClick Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:17:07 AM
        //#-----------------------------------------
        private void dtlF920_DOCTOR_OPTIONS_EditClick(DataList source, GridButtonEventArgs GridButtonEventArgs)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:17:07 AM
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:17:08 AM
        //#-----------------------------------------
        private void dsrDesigner_01_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:17:08 AM
                Accept(ref fldF920_DOCTOR_OPTIONS_DOC_OPTION_CATEGORY);
                Accept(ref fldF920_DOCTOR_OPTIONS_DOC_OPTION_SUBCATEGORY);
                Accept(ref fldF920_DOCTOR_OPTIONS_DOC_OPTION_DATE_ACTIVE_FROM);
                Accept(ref fldF920_DOCTOR_OPTIONS_DOC_OPTION_DATE_ACTIVE_TO);
                Accept(ref fldF920_DOCTOR_OPTIONS_DOC_OPTION_VALUE);
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
