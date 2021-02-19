
#region "Screen Comments"

// #> PROGRAM-ID.     m092.qks
// ((C)) Dyad Technologies
// PROGRAM PURPOSE : Maintenance of OHIP error message Categories
// MODIFICATION HISTORY
// DATE          WHO     DESCRIPTION
// 1999/12/13  B.E. -original

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

    partial class Billing_M092 : BasePage
    {

        #region " Form Designer Generated Code "





        public Billing_M092()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "M092";

            //# Set the ACTIVITIES for the screen.
            this.ChangeActivity = true;
            this.FindActivity = true;
            this.DeleteActivity = true;
            this.EntryActivity = true;
            this.UseAcceptProcessing = true;



            this.HasPathRequestFields = true;



            this.GridDesigner = "dsrDesigner_01";


            dsrDesigner_01.DefaultFirstRowInGrid = true;



        }

        #endregion

        private void Page_Load(object sender, RoutedEventArgs e)
        {
            SetVariables();
            dsrDesigner_01.Click += dsrDesigner_01_Click;
            dtlF092_OHIP_ERROR_CAT_MSTR.EditClick += dtlF092_OHIP_ERROR_CAT_MSTR_EditClick;
            base.Page_Load();

            // TODO: If any DESIGNER procedures function on occurring FILES or TEMPORARIES, set the grid's AllowSelectRowButton property to TRUE.



        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            fleF092_OHIP_ERROR_CAT_MSTR = new SqlFileObject(this, FileTypes.Primary, 15, "INDEXED", "F092_OHIP_ERROR_CAT_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            W_DATE = new CoreDate("W_DATE", this);


        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;
            fldF092_OHIP_ERROR_CAT_MSTR_OHIP_ERR_CAT_CODE.LookupNotOn -= fldF092_OHIP_ERROR_CAT_MSTR_OHIP_ERR_CAT_CODE_LookupNotOn;

            dsrDesigner_01.Click -= dsrDesigner_01_Click;


        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private SqlConnection m_cnnQUERY = new SqlConnection();
        private SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
        private SqlTransaction m_trnTRANS_UPDATE;
        private SqlFileObject fleF092_OHIP_ERROR_CAT_MSTR;

        private void fleF092_OHIP_ERROR_CAT_MSTR_InitializeItems(bool Fixed)
        {

            try
            {
                if (!Fixed)
                    fleF092_OHIP_ERROR_CAT_MSTR.set_SetValue("ENTRY_DATE", true, QDesign.SysDate(ref m_cnnQUERY));
                if (!Fixed)
                    fleF092_OHIP_ERROR_CAT_MSTR.set_SetValue("ENTRY_TIME", true, QDesign.SysTime(ref m_cnnQUERY) / 10000);
                if (!Fixed)
                    fleF092_OHIP_ERROR_CAT_MSTR.set_SetValue("ENTRY_USER_ID", true, UserID);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fleF092_OHIP_ERROR_CAT_MSTR_SetItemFinals()
        {

            try
            {
                fleF092_OHIP_ERROR_CAT_MSTR.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));
                fleF092_OHIP_ERROR_CAT_MSTR.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);
                fleF092_OHIP_ERROR_CAT_MSTR.set_SetValue("LAST_MOD_USER_ID", UserID);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }

        private CoreDate W_DATE;
        private void W_DATE_GetInitialValue()
        {
            W_DATE.InitialValue = QDesign.SysDate(ref m_cnnQUERY);
        }

        #endregion

        #region "Standard Generated Procedures"

        #region "Grid Field Declarations"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 8/29/2017 10:04:16 AM

        protected TextBox fldF092_OHIP_ERROR_CAT_MSTR_OHIP_ERR_CAT_CODE;

        protected TextBox fldF092_OHIP_ERROR_CAT_MSTR_OHIP_ERR_CAT_DESCRIPTION;

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 8/29/2017 10:04:16 AM

        //#-----------------------------------------
        //# GetGridFieldObject Procedure.
        //#-----------------------------------------

        protected override void GetGridFieldObject(object DataListField, ref object CoreField, string Name)
        {

            try
            {
                switch (Name.ToUpper())
                {
                    case "FLDGRDF092_OHIP_ERROR_CAT_MSTR_OHIP_ERR_CAT_CODE":
                        fldF092_OHIP_ERROR_CAT_MSTR_OHIP_ERR_CAT_CODE = (TextBox)DataListField;

                        fldF092_OHIP_ERROR_CAT_MSTR_OHIP_ERR_CAT_CODE.LookupNotOn -= fldF092_OHIP_ERROR_CAT_MSTR_OHIP_ERR_CAT_CODE_LookupNotOn;
                        fldF092_OHIP_ERROR_CAT_MSTR_OHIP_ERR_CAT_CODE.LookupNotOn += fldF092_OHIP_ERROR_CAT_MSTR_OHIP_ERR_CAT_CODE_LookupNotOn;
                        CoreField = fldF092_OHIP_ERROR_CAT_MSTR_OHIP_ERR_CAT_CODE;
                        fldF092_OHIP_ERROR_CAT_MSTR_OHIP_ERR_CAT_CODE.Bind(fleF092_OHIP_ERROR_CAT_MSTR);
                        break;
                    case "FLDGRDF092_OHIP_ERROR_CAT_MSTR_OHIP_ERR_CAT_DESCRIPTION":
                        fldF092_OHIP_ERROR_CAT_MSTR_OHIP_ERR_CAT_DESCRIPTION = (TextBox)DataListField;
                        CoreField = fldF092_OHIP_ERROR_CAT_MSTR_OHIP_ERR_CAT_DESCRIPTION;
                        fldF092_OHIP_ERROR_CAT_MSTR_OHIP_ERR_CAT_DESCRIPTION.Bind(fleF092_OHIP_ERROR_CAT_MSTR);
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
                dtlF092_OHIP_ERROR_CAT_MSTR.OccursWithFile = fleF092_OHIP_ERROR_CAT_MSTR;

            }
            catch (CustomApplicationException ex)
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
        //# Do not delete, modify or move it.  Updated: 8/29/2017 10:04:16 AM

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
            fleF092_OHIP_ERROR_CAT_MSTR.Transaction = m_trnTRANS_UPDATE;


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 8/29/2017 10:04:16 AM

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
                fleF092_OHIP_ERROR_CAT_MSTR.Dispose();


            }
            catch (CustomApplicationException ex)
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
        //# Precompiler Ver.: 1.0.6407.16120  Generated on: 8/29/2017 9:31:20 AM
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

        //#-----------------------------------------
        //# PreDisplayFormatting Procedure
        //# Precompiler Ver.: 1.0.6407.16120  Generated on: 8/29/2017 9:31:20 AM
        //#-----------------------------------------
        protected override void PreDisplayFormatting()
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
        //# Do not delete, modify or move it.  Updated: 8/29/2017 10:04:16 AM

        //#-----------------------------------------
        //# BindFields Procedure.
        //#-----------------------------------------

        public override void BindFields()
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



        private void fldF092_OHIP_ERROR_CAT_MSTR_OHIP_ERR_CAT_CODE_LookupNotOn(ref bool LookupNotOnExecuted)
        {

            try
            {
                bool blnAlreadyExists = false;
                StringBuilder strSQL = new StringBuilder("SELECT ").Append(fleF092_OHIP_ERROR_CAT_MSTR.ElementOwner("OHIP_ERR_CAT_CODE"));
                strSQL.Append(" FROM ");
                strSQL.Append(fleF092_OHIP_ERROR_CAT_MSTR.TableNameWithAlias());
                strSQL.Append(" WHERE ");
                strSQL.Append("     ").Append(fleF092_OHIP_ERROR_CAT_MSTR.ElementOwner("OHIP_ERR_CAT_CODE")).Append(" = ").Append(Common.StringToField(FieldText));

                if (!LookupNotOn(strSQL, fleF092_OHIP_ERROR_CAT_MSTR, "OHIP_ERR_CAT_CODE", FieldText))
                {
                    blnAlreadyExists = true;
                }

                if (blnAlreadyExists)
                {
                    ErrorMessage("Value already exists ({0}).");
                    // Record exists in lookup table.
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
                switch (m_intPath)
                {
                    case 1:
                        m_strWhere = new StringBuilder(GetWhereCondition(fleF092_OHIP_ERROR_CAT_MSTR.ElementOwner("OHIP_ERR_CAT_CODE"), fleF092_OHIP_ERROR_CAT_MSTR.GetStringValue("OHIP_ERR_CAT_CODE"), ref blnAddWhere));
                        fleF092_OHIP_ERROR_CAT_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
                        break;
                    case 2:
                        m_strWhere = new StringBuilder(GetWhereCondition(fleF092_OHIP_ERROR_CAT_MSTR.ElementOwner("OHIP_ERR_CAT_DESCRIPTION"), fleF092_OHIP_ERROR_CAT_MSTR.GetStringValue("OHIP_ERR_CAT_DESCRIPTION"), ref blnAddWhere));
                        fleF092_OHIP_ERROR_CAT_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
                        break;
                    default:
                        fleF092_OHIP_ERROR_CAT_MSTR.GetData(GetDataOptions.Sequential | GetDataOptions.CreateSubSelect);
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

                RequestPrompt(ref fldF092_OHIP_ERROR_CAT_MSTR_OHIP_ERR_CAT_CODE);
                if (m_blnPromptOK)
                {
                    m_intPath = 1;
                }
                if (m_intPath == 0)
                {
                    RequestPrompt(ref fldF092_OHIP_ERROR_CAT_MSTR_OHIP_ERR_CAT_DESCRIPTION);
                    if (m_blnPromptOK)
                    {
                        m_intPath = 2;
                    }
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
                Page.PageTitle = "OHIP R.A. Error Code Category Maintenance";



            }
            catch (CustomApplicationException ex)
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
        //# Precompiler Ver.: 1.0.6407.16120  Generated on: 8/29/2017 9:31:20 AM
        //#-----------------------------------------
        protected override bool Append()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6407.16120 Generated on: 8/29/2017 9:31:20 AM
                Accept(ref fldF092_OHIP_ERROR_CAT_MSTR_OHIP_ERR_CAT_CODE);
                Accept(ref fldF092_OHIP_ERROR_CAT_MSTR_OHIP_ERR_CAT_DESCRIPTION);
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
        //# Precompiler Ver.: 1.0.6407.16120  Generated on: 8/29/2017 9:31:20 AM
        //#-----------------------------------------
        protected override bool Entry()
        {
            try
            {
               
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
        //# Precompiler Ver.: 1.0.6407.16120  Generated on: 8/29/2017 9:31:20 AM
        //#-----------------------------------------
        protected override bool Update()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6407.16120 Generated on: 8/29/2017 9:31:20 AM
                while (fleF092_OHIP_ERROR_CAT_MSTR.For())
                {
                    fleF092_OHIP_ERROR_CAT_MSTR.PutData(false, PutTypes.Deleted);
                }
                while (fleF092_OHIP_ERROR_CAT_MSTR.For())
                {
                    fleF092_OHIP_ERROR_CAT_MSTR.PutData();
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
        //# Precompiler Ver.: 1.0.6407.16120  Generated on: 8/29/2017 9:31:20 AM
        //#-----------------------------------------
        protected override bool Delete()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6407.16120 Generated on: 8/29/2017 9:31:20 AM
                fleF092_OHIP_ERROR_CAT_MSTR.DeletedRecord = true;
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
        //# dtlF092_OHIP_ERROR_CAT_MSTR_EditClick Procedure
        //# Precompiler Ver.: 1.0.6407.16120  Generated on: 8/29/2017 9:31:20 AM
        //#-----------------------------------------
        private void dtlF092_OHIP_ERROR_CAT_MSTR_EditClick(DataList source, GridButtonEventArgs GridButtonEventArgs)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6407.16120 Generated on: 8/29/2017 10:04:16 AM
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
        //# Precompiler Ver.: 1.0.6407.16120  Generated on: 8/29/2017 9:31:20 AM
        //#-----------------------------------------
        private void dsrDesigner_01_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6407.16120 Generated on: 8/29/2017 10:04:16 AM
                Accept(ref fldF092_OHIP_ERROR_CAT_MSTR_OHIP_ERR_CAT_CODE);
                Accept(ref fldF092_OHIP_ERROR_CAT_MSTR_OHIP_ERR_CAT_DESCRIPTION);
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

