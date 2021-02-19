
#region "Screen Comments"

// #> program-id.     m028.qks
// program purpose : entry of a contact`s address/phone etc
// modification historY
// date   who     description
// 2005/jan/19   b.e. - original
// 2005/dec/06   M.C. - allow user to blank out postal code
// 2006/apr/10   M.C. - move email address after the phone numbers because
// field size has extended from x(30) to x(50)
// 2006/08/08    M.C.    - receiving x-doc-ohip-nbr 
// - add designer procedure `dupa` & `dupe` for the other doctor records that
// share the same doc ohip nbr
// 2006/10/19    M.C. - add f027-contacts-mstr to check on contacts name to be the same
// in order to allow duplicate on email address or address and phone numbers
// 2006/10/26    M.C.    - receiving the f027-contacts-mstr in the parameter 
// 2007/07/10    M.C.    - create audit records for before and after when user changes email address
// 2006/08/08 - MC
// 2006/08/08 - end
// 2006/10/26 - MC
// x-contacts-name

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

    partial class Billing_M028 : BasePage
    {

        #region " Form Designer Generated Code "





        public Billing_M028()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "M028";

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
            dsrDesigner_DUPE.Click += dsrDesigner_DUPE_Click;
            dsrDesigner_DUPA.Click += dsrDesigner_DUPA_Click;
            dsrDesigner_01.Click += dsrDesigner_01_Click;
            dtlF028_CONTACTS_INFO_MSTR.EditClick += dtlF028_CONTACTS_INFO_MSTR_EditClick;
            base.Page_Load();

            // TODO: If any DESIGNER procedures function on occurring FILES or TEMPORARIES, set the grid's AllowSelectRowButton property to TRUE.



        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            X_DOC_OHIP_NBR = new CoreDecimal("X_DOC_OHIP_NBR", 6, this);
            X_DOC_NBR = new CoreCharacter("X_DOC_NBR", 3, this, Common.cEmptyString);
            X_CONTACTS_TYPE = new CoreCharacter("X_CONTACTS_TYPE", 1, this, Common.cEmptyString);
            X_CONTACTS_NAME = new CoreCharacter("X_CONTACTS_NAME", 60, this, Common.cEmptyString);
            X_DUP_CONTACTS_NAME = new CoreCharacter("X_DUP_CONTACTS_NAME", 60, this, Common.cEmptyString);
            fleF027_CONTACTS_MSTR = new SqlFileObject(this, FileTypes.Master, 0, "INDEXED", "F027_CONTACTS_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF028_CONTACTS_INFO_MSTR = new SqlFileObject(this, FileTypes.Primary, 2, "INDEXED", "F028_CONTACTS_INFO_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Designer, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF028_DUP = new SqlFileObject(this, FileTypes.Designer, 0, "INDEXED", "F028_CONTACTS_INFO_MSTR", "F028_DUP", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF027_DESIGNER = new SqlFileObject(this, FileTypes.Designer, 0, "INDEXED", "F027_CONTACTS_MSTR", "F027_DESIGNER", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF028_AUDIT_FILE = new SqlFileObject(this, FileTypes.Designer, 0, "INDEXED", "F028_AUDIT_FILE", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            X_EMAIL_ADDR = new CoreCharacter("X_EMAIL_ADDR", 50, this, fleF028_CONTACTS_INFO_MSTR, Common.cEmptyString);
            X_EMAIL_ADDR_FLAG = new CoreCharacter("X_EMAIL_ADDR_FLAG", 1, this, fleF028_CONTACTS_INFO_MSTR, Common.cEmptyString);

           
            fleF020_DOCTOR_MSTR.Access += fleF020_DOCTOR_MSTR_Access;
            fleF028_DUP.Access += fleF028_DUP_Access;
            fleF027_DESIGNER.Access += fleF027_DESIGNER_Access;
            fleF028_CONTACTS_INFO_MSTR.InitializeItems += fleF028_CONTACTS_INFO_MSTR_InitializeItems;
        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;
            fleF020_DOCTOR_MSTR.Access -= fleF020_DOCTOR_MSTR_Access;
            fleF028_DUP.Access -= fleF028_DUP_Access;
            fleF027_DESIGNER.Access -= fleF027_DESIGNER_Access;
            fldF028_CONTACTS_INFO_MSTR_CONTACTS_LOCATION.LookupNotOn -= fldF028_CONTACTS_INFO_MSTR_CONTACTS_LOCATION_LookupNotOn;
            fldF028_CONTACTS_INFO_MSTR_CONTACTS_EMAIL_ADDR.Edit -= fldF028_CONTACTS_INFO_MSTR_CONTACTS_EMAIL_ADDR_Edit;

            dsrDesigner_DUPE.Click -= dsrDesigner_DUPE_Click;
            dsrDesigner_DUPA.Click -= dsrDesigner_DUPA_Click;
            dsrDesigner_01.Click -= dsrDesigner_01_Click;
            dtlF028_CONTACTS_INFO_MSTR.EditClick -= dtlF028_CONTACTS_INFO_MSTR_EditClick;
            fleF028_CONTACTS_INFO_MSTR.InitializeItems -= fleF028_CONTACTS_INFO_MSTR_InitializeItems;
        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private SqlConnection m_cnnQUERY = new SqlConnection();
        private SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
        private SqlTransaction m_trnTRANS_UPDATE;
        private CoreDecimal X_DOC_OHIP_NBR;
        private CoreCharacter X_DOC_NBR;
        private CoreCharacter X_CONTACTS_TYPE;
        private CoreCharacter X_CONTACTS_NAME;
        private CoreCharacter X_DUP_CONTACTS_NAME;
        private SqlFileObject fleF027_CONTACTS_MSTR;
        private SqlFileObject fleF028_CONTACTS_INFO_MSTR;

        private void fleF028_CONTACTS_INFO_MSTR_InitializeItems(bool Fixed)
        {

            try
            {
                if (!Fixed)
                    fleF028_CONTACTS_INFO_MSTR.set_SetValue("FILLER", true, " ");
                if (!Fixed)
                    fleF028_CONTACTS_INFO_MSTR.set_SetValue("DOC_NBR", true, X_DOC_NBR.Value);
                if (!Fixed)
                    fleF028_CONTACTS_INFO_MSTR.set_SetValue("CONTACTS_TYPE", true, X_CONTACTS_TYPE.Value);


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

        private SqlFileObject fleF020_DOCTOR_MSTR;

        private void fleF020_DOCTOR_MSTR_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ").Append(Common.StringToField(X_DOC_OHIP_NBR.Value.ToString()));

                strText.Append(" ORDER BY ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_OHIP_NBR"));
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

        private SqlFileObject fleF028_DUP;

        private void fleF028_DUP_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleF028_DUP.ElementOwner("FILLER")).Append(" = ").Append(Common.StringToField(" "));
                strText.Append(" AND ").Append(fleF028_DUP.ElementOwner("DOC_NBR")).Append(" = ").Append(Common.StringToField(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")));
                strText.Append(" AND ").Append(fleF028_DUP.ElementOwner("CONTACTS_TYPE")).Append(" = ").Append(Common.StringToField(X_CONTACTS_TYPE.Value));
                strText.Append(" AND ").Append(fleF028_DUP.ElementOwner("CONTACTS_LOCATION")).Append(" = ").Append(Common.StringToField(fleF028_CONTACTS_INFO_MSTR.GetStringValue("CONTACTS_LOCATION")));

                strText.Append(" ORDER BY ").Append(fleF028_DUP.ElementOwner("FILLER"));
                strText.Append(", ").Append(fleF028_DUP.ElementOwner("DOC_NBR"));
                strText.Append(", ").Append(fleF028_DUP.ElementOwner("CONTACTS_TYPE"));
                strText.Append(", ").Append(fleF028_DUP.ElementOwner("CONTACTS_LOCATION"));
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

        private SqlFileObject fleF027_DESIGNER;

        private void fleF027_DESIGNER_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleF027_DESIGNER.ElementOwner("FILLER")).Append(" = ").Append(Common.StringToField(" "));
                strText.Append(" AND ").Append(fleF027_DESIGNER.ElementOwner("DOC_NBR")).Append(" = ").Append(Common.StringToField(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")));
                strText.Append(" AND ").Append(fleF027_DESIGNER.ElementOwner("CONTACTS_TYPE")).Append(" = ").Append(Common.StringToField(X_CONTACTS_TYPE.Value));

                strText.Append(" ORDER BY ").Append(fleF027_DESIGNER.ElementOwner("FILLER"));
                strText.Append(", ").Append(fleF027_DESIGNER.ElementOwner("DOC_NBR"));
                strText.Append(", ").Append(fleF027_DESIGNER.ElementOwner("CONTACTS_TYPE"));
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

        private SqlFileObject fleF028_AUDIT_FILE;
        private CoreCharacter X_EMAIL_ADDR;

        private CoreCharacter X_EMAIL_ADDR_FLAG;
        #endregion

        #region "Standard Generated Procedures"

        #region "Grid Field Declarations"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:12:02 AM

        protected ComboBox fldF028_CONTACTS_INFO_MSTR_CONTACTS_LOCATION;
        protected TextBox fldF028_CONTACTS_INFO_MSTR_CONTACTS_PHONE_NBR;
        protected TextBox fldF028_CONTACTS_INFO_MSTR_CONTACTS_PHONE_EXT;
        protected TextBox fldF028_CONTACTS_INFO_MSTR_CONTACTS_ADDR_1;
        protected TextBox fldF028_CONTACTS_INFO_MSTR_CONTACTS_FAX_NBR;
        protected TextBox fldF028_CONTACTS_INFO_MSTR_CONTACTS_ADDR_2;
        protected TextBox fldF028_CONTACTS_INFO_MSTR_CONTACTS_PAGER_NBR;
        protected TextBox fldF028_CONTACTS_INFO_MSTR_CONTACTS_ADDR_3;
        protected TextBox fldF028_CONTACTS_INFO_MSTR_CONTACTS_CELL_NBR;
        protected TextBox fldF028_CONTACTS_INFO_MSTR_POSTAL_CODE;
        protected TextBox fldF028_CONTACTS_INFO_MSTR_CONTACTS_EMAIL_ADDR;

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:12:03 AM

        //#-----------------------------------------
        //# GetGridFieldObject Procedure.
        //#-----------------------------------------

        protected override void GetGridFieldObject(object DataListField, ref object CoreField, string Name)
        {

            try
            {
                switch (Name.ToUpper())
                {
                    case "FLDGRDF028_CONTACTS_INFO_MSTR_CONTACTS_LOCATION":
                        fldF028_CONTACTS_INFO_MSTR_CONTACTS_LOCATION = (ComboBox)DataListField;

                        fldF028_CONTACTS_INFO_MSTR_CONTACTS_LOCATION.LookupNotOn -= fldF028_CONTACTS_INFO_MSTR_CONTACTS_LOCATION_LookupNotOn;
                        fldF028_CONTACTS_INFO_MSTR_CONTACTS_LOCATION.LookupNotOn += fldF028_CONTACTS_INFO_MSTR_CONTACTS_LOCATION_LookupNotOn;
                        CoreField = fldF028_CONTACTS_INFO_MSTR_CONTACTS_LOCATION;
                        fldF028_CONTACTS_INFO_MSTR_CONTACTS_LOCATION.Bind(fleF028_CONTACTS_INFO_MSTR);
                        break;
                    case "FLDGRDF028_CONTACTS_INFO_MSTR_CONTACTS_PHONE_NBR":
                        fldF028_CONTACTS_INFO_MSTR_CONTACTS_PHONE_NBR = (TextBox)DataListField;
                        CoreField = fldF028_CONTACTS_INFO_MSTR_CONTACTS_PHONE_NBR;
                        fldF028_CONTACTS_INFO_MSTR_CONTACTS_PHONE_NBR.Bind(fleF028_CONTACTS_INFO_MSTR);
                        break;
                    case "FLDGRDF028_CONTACTS_INFO_MSTR_CONTACTS_PHONE_EXT":
                        fldF028_CONTACTS_INFO_MSTR_CONTACTS_PHONE_EXT = (TextBox)DataListField;
                        CoreField = fldF028_CONTACTS_INFO_MSTR_CONTACTS_PHONE_EXT;
                        fldF028_CONTACTS_INFO_MSTR_CONTACTS_PHONE_EXT.Bind(fleF028_CONTACTS_INFO_MSTR);
                        break;
                    case "FLDGRDF028_CONTACTS_INFO_MSTR_CONTACTS_ADDR_1":
                        fldF028_CONTACTS_INFO_MSTR_CONTACTS_ADDR_1 = (TextBox)DataListField;
                        CoreField = fldF028_CONTACTS_INFO_MSTR_CONTACTS_ADDR_1;
                        fldF028_CONTACTS_INFO_MSTR_CONTACTS_ADDR_1.Bind(fleF028_CONTACTS_INFO_MSTR);
                        break;
                    case "FLDGRDF028_CONTACTS_INFO_MSTR_CONTACTS_FAX_NBR":
                        fldF028_CONTACTS_INFO_MSTR_CONTACTS_FAX_NBR = (TextBox)DataListField;
                        CoreField = fldF028_CONTACTS_INFO_MSTR_CONTACTS_FAX_NBR;
                        fldF028_CONTACTS_INFO_MSTR_CONTACTS_FAX_NBR.Bind(fleF028_CONTACTS_INFO_MSTR);
                        break;
                    case "FLDGRDF028_CONTACTS_INFO_MSTR_CONTACTS_ADDR_2":
                        fldF028_CONTACTS_INFO_MSTR_CONTACTS_ADDR_2 = (TextBox)DataListField;
                        CoreField = fldF028_CONTACTS_INFO_MSTR_CONTACTS_ADDR_2;
                        fldF028_CONTACTS_INFO_MSTR_CONTACTS_ADDR_2.Bind(fleF028_CONTACTS_INFO_MSTR);
                        break;
                    case "FLDGRDF028_CONTACTS_INFO_MSTR_CONTACTS_PAGER_NBR":
                        fldF028_CONTACTS_INFO_MSTR_CONTACTS_PAGER_NBR = (TextBox)DataListField;
                        CoreField = fldF028_CONTACTS_INFO_MSTR_CONTACTS_PAGER_NBR;
                        fldF028_CONTACTS_INFO_MSTR_CONTACTS_PAGER_NBR.Bind(fleF028_CONTACTS_INFO_MSTR);
                        break;
                    case "FLDGRDF028_CONTACTS_INFO_MSTR_CONTACTS_ADDR_3":
                        fldF028_CONTACTS_INFO_MSTR_CONTACTS_ADDR_3 = (TextBox)DataListField;
                        CoreField = fldF028_CONTACTS_INFO_MSTR_CONTACTS_ADDR_3;
                        fldF028_CONTACTS_INFO_MSTR_CONTACTS_ADDR_3.Bind(fleF028_CONTACTS_INFO_MSTR);
                        break;
                    case "FLDGRDF028_CONTACTS_INFO_MSTR_CONTACTS_CELL_NBR":
                        fldF028_CONTACTS_INFO_MSTR_CONTACTS_CELL_NBR = (TextBox)DataListField;
                        CoreField = fldF028_CONTACTS_INFO_MSTR_CONTACTS_CELL_NBR;
                        fldF028_CONTACTS_INFO_MSTR_CONTACTS_CELL_NBR.Bind(fleF028_CONTACTS_INFO_MSTR);
                        break;
                    case "FLDGRDF028_CONTACTS_INFO_MSTR_POSTAL_CODE":
                        fldF028_CONTACTS_INFO_MSTR_POSTAL_CODE = (TextBox)DataListField;
                        CoreField = fldF028_CONTACTS_INFO_MSTR_POSTAL_CODE;
                        fldF028_CONTACTS_INFO_MSTR_POSTAL_CODE.Bind(fleF028_CONTACTS_INFO_MSTR);
                        break;
                    case "FLDGRDF028_CONTACTS_INFO_MSTR_CONTACTS_EMAIL_ADDR":
                        fldF028_CONTACTS_INFO_MSTR_CONTACTS_EMAIL_ADDR = (TextBox)DataListField;

                        fldF028_CONTACTS_INFO_MSTR_CONTACTS_EMAIL_ADDR.Edit -= fldF028_CONTACTS_INFO_MSTR_CONTACTS_EMAIL_ADDR_Edit;
                        fldF028_CONTACTS_INFO_MSTR_CONTACTS_EMAIL_ADDR.Edit += fldF028_CONTACTS_INFO_MSTR_CONTACTS_EMAIL_ADDR_Edit;
                        CoreField = fldF028_CONTACTS_INFO_MSTR_CONTACTS_EMAIL_ADDR;
                        fldF028_CONTACTS_INFO_MSTR_CONTACTS_EMAIL_ADDR.Bind(fleF028_CONTACTS_INFO_MSTR);
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
                dtlF028_CONTACTS_INFO_MSTR.OccursWithFile = fleF028_CONTACTS_INFO_MSTR;

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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:12:03 AM

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
            fleF027_CONTACTS_MSTR.Transaction = m_trnTRANS_UPDATE;
            fleF028_CONTACTS_INFO_MSTR.Transaction = m_trnTRANS_UPDATE;
            fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
            fleF028_DUP.Transaction = m_trnTRANS_UPDATE;
            fleF027_DESIGNER.Transaction = m_trnTRANS_UPDATE;
            fleF028_AUDIT_FILE.Transaction = m_trnTRANS_UPDATE;


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:12:03 AM

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
                fleF027_CONTACTS_MSTR.Dispose();
                fleF028_CONTACTS_INFO_MSTR.Dispose();
                fleF020_DOCTOR_MSTR.Dispose();
                fleF028_DUP.Dispose();
                fleF027_DESIGNER.Dispose();
                fleF028_AUDIT_FILE.Dispose();


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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:12:02 AM
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:12:02 AM
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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:12:03 AM

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



        private void fldF028_CONTACTS_INFO_MSTR_CONTACTS_LOCATION_LookupNotOn(ref bool LookupNotOnExecuted)
        {

            try
            {
                bool blnAlreadyExists = false;
                StringBuilder strSQL = new StringBuilder("SELECT ").Append(fleF028_CONTACTS_INFO_MSTR.ElementOwner("FILLER"));
                strSQL.Append(" FROM ");
                strSQL.Append(fleF028_CONTACTS_INFO_MSTR.TableNameWithAlias());
                strSQL.Append(" WHERE ");
                strSQL.Append("     ").Append(fleF028_CONTACTS_INFO_MSTR.ElementOwner("FILLER")).Append(" = ").Append(Common.StringToField(fleF028_CONTACTS_INFO_MSTR.GetStringValue("FILLER")));
                strSQL.Append(" And ").Append(fleF028_CONTACTS_INFO_MSTR.ElementOwner("DOC_NBR")).Append(" = ").Append(Common.StringToField(fleF028_CONTACTS_INFO_MSTR.GetStringValue("DOC_NBR")));
                strSQL.Append(" And ").Append(fleF028_CONTACTS_INFO_MSTR.ElementOwner("CONTACTS_TYPE")).Append(" = ").Append(Common.StringToField(fleF028_CONTACTS_INFO_MSTR.GetStringValue("CONTACTS_TYPE")));
                strSQL.Append(" And ").Append(fleF028_CONTACTS_INFO_MSTR.ElementOwner("CONTACTS_LOCATION")).Append(" = ").Append(Common.StringToField(FieldText));

                if (!LookupNotOn(strSQL, fleF028_CONTACTS_INFO_MSTR, new string[] { "FILLER", "DOC_NBR", "CONTACTS_TYPE", "CONTACTS_LOCATION" }, new Object[] { fleF028_CONTACTS_INFO_MSTR.GetStringValue("FILLER"), fleF028_CONTACTS_INFO_MSTR.GetStringValue("DOC_NBR"), fleF028_CONTACTS_INFO_MSTR.GetStringValue("CONTACTS_TYPE"), FieldText }))
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
                SaveReceivingParams(X_DOC_NBR, X_DOC_OHIP_NBR, X_CONTACTS_TYPE, X_CONTACTS_NAME, fleF027_CONTACTS_MSTR);


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
                Receiving(X_DOC_NBR, X_DOC_OHIP_NBR, X_CONTACTS_TYPE, X_CONTACTS_NAME, fleF027_CONTACTS_MSTR);


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


        private void fldF028_CONTACTS_INFO_MSTR_CONTACTS_EMAIL_ADDR_Edit()
        {

            try
            {

                if (QDesign.NULL(FieldText) != QDesign.NULL(OldValue(fleF028_CONTACTS_INFO_MSTR.ElementOwner("CONTACTS_EMAIL_ADDR"), fleF028_CONTACTS_INFO_MSTR.GetStringValue("CONTACTS_EMAIL_ADDR"))))
                {
                    X_EMAIL_ADDR_FLAG.Value = "Y";
                    X_EMAIL_ADDR.Value = OldValue(fleF028_CONTACTS_INFO_MSTR.ElementOwner("CONTACTS_EMAIL_ADDR"), fleF028_CONTACTS_INFO_MSTR.GetStringValue("CONTACTS_EMAIL_ADDR"));
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

                while (fleF028_CONTACTS_INFO_MSTR.For())
                {
                    if (QDesign.NULL(X_EMAIL_ADDR_FLAG.Value) == QDesign.NULL("Y"))
                    {
                        fleF028_AUDIT_FILE.set_SetValue("DOC_NBR", fleF028_CONTACTS_INFO_MSTR.GetStringValue("DOC_NBR"));
                        fleF028_AUDIT_FILE.set_SetValue("CONTACTS_TYPE", fleF028_CONTACTS_INFO_MSTR.GetStringValue("CONTACTS_TYPE"));
                        fleF028_AUDIT_FILE.set_SetValue("CONTACTS_LOCATION", fleF028_CONTACTS_INFO_MSTR.GetStringValue("CONTACTS_LOCATION"));
                        fleF028_AUDIT_FILE.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));
                        fleF028_AUDIT_FILE.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);
                        fleF028_AUDIT_FILE.set_SetValue("LAST_MOD_USER_ID", UserID + " - before");
                        fleF028_AUDIT_FILE.set_SetValue("CONTACTS_EMAIL_ADDR", X_EMAIL_ADDR.Value);
                        fleF028_AUDIT_FILE.PutData(true);
                        fleF028_AUDIT_FILE.set_SetValue("DOC_NBR", fleF028_CONTACTS_INFO_MSTR.GetStringValue("DOC_NBR"));
                        fleF028_AUDIT_FILE.set_SetValue("CONTACTS_TYPE", fleF028_CONTACTS_INFO_MSTR.GetStringValue("CONTACTS_TYPE"));
                        fleF028_AUDIT_FILE.set_SetValue("CONTACTS_LOCATION", fleF028_CONTACTS_INFO_MSTR.GetStringValue("CONTACTS_LOCATION"));
                        fleF028_AUDIT_FILE.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));
                        fleF028_AUDIT_FILE.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);
                        fleF028_AUDIT_FILE.set_SetValue("LAST_MOD_USER_ID", UserID + " - after ");
                        fleF028_AUDIT_FILE.set_SetValue("CONTACTS_EMAIL_ADDR", fleF028_CONTACTS_INFO_MSTR.GetStringValue("CONTACTS_EMAIL_ADDR"));
                        fleF028_AUDIT_FILE.PutData();
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


        private bool Internal_DUPLICATE_EMAIL()
        {


            try
            {

                // --> GET F027_DESIGNER <--

                fleF027_DESIGNER.GetData(GetDataOptions.IsOptional);
                // --> End GET F027_DESIGNER <--
                if (AccessOk)
                {
                    X_DUP_CONTACTS_NAME.Value = QDesign.UCase(QDesign.RTrim(QDesign.LeftJustify(fleF027_DESIGNER.GetStringValue("CONTACTS_SURNAME"))) + "," + QDesign.RTrim(QDesign.LeftJustify(fleF027_DESIGNER.GetStringValue("CONTACTS_GIVEN_NAMES"))));
                    if (QDesign.NULL(X_DUP_CONTACTS_NAME.Value) == QDesign.NULL(X_CONTACTS_NAME.Value))
                    {
                        while (fleF028_DUP.WhileRetrieving())
                        {
                            fleF028_DUP.set_SetValue("CONTACTS_EMAIL_ADDR", fleF028_CONTACTS_INFO_MSTR.GetStringValue("CONTACTS_EMAIL_ADDR"));
                            fleF028_DUP.PutData();
                        }
                    }
                }
                else
                {
                    fleF027_DESIGNER.set_SetValue("DOC_NBR", fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR"));
                    fleF027_DESIGNER.set_SetValue("CONTACTS_TYPE", X_CONTACTS_TYPE.Value);
                    fleF027_DESIGNER.set_SetValue("CONTACTS_SURNAME", fleF027_CONTACTS_MSTR.GetStringValue("CONTACTS_SURNAME"));
                    fleF027_DESIGNER.set_SetValue("CONTACTS_GIVEN_NAMES", fleF027_CONTACTS_MSTR.GetStringValue("CONTACTS_GIVEN_NAMES"));
                    fleF027_DESIGNER.set_SetValue("CONTACTS_INIT_S1", fleF027_CONTACTS_MSTR.GetStringValue("CONTACTS_INIT_S1"));
                    //Parent:CONTACTS_INITS
                    fleF027_DESIGNER.set_SetValue("CONTACTS_INIT_S2", fleF027_CONTACTS_MSTR.GetStringValue("CONTACTS_INIT_S2"));
                    //Parent:CONTACTS_INITS
                    fleF027_DESIGNER.set_SetValue("CONTACTS_INIT_S3", fleF027_CONTACTS_MSTR.GetStringValue("CONTACTS_INIT_S3"));
                    //Parent:CONTACTS_INITS    'Parent:CONTACTS_INITS
                    fleF027_DESIGNER.set_SetValue("CONTACTS_TITLE", fleF027_CONTACTS_MSTR.GetStringValue("CONTACTS_TITLE"));
                    fleF027_DESIGNER.set_SetValue("CONTACTS_SEX", fleF027_CONTACTS_MSTR.GetStringValue("CONTACTS_SEX"));
                    fleF027_DESIGNER.set_SetValue("BILLING_ENTRY_FLAG", fleF027_CONTACTS_MSTR.GetStringValue("BILLING_ENTRY_FLAG"));
                    fleF027_DESIGNER.set_SetValue("LOGON_USERNAME", fleF027_CONTACTS_MSTR.GetStringValue("LOGON_USERNAME"));
                    fleF027_DESIGNER.PutData();
                    fleF028_DUP.set_SetValue("DOC_NBR", fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR"));
                    fleF028_DUP.set_SetValue("CONTACTS_TYPE", X_CONTACTS_TYPE.Value);
                    fleF028_DUP.set_SetValue("CONTACTS_LOCATION", fleF028_CONTACTS_INFO_MSTR.GetStringValue("CONTACTS_LOCATION"));
                    fleF028_DUP.set_SetValue("CONTACTS_EMAIL_ADDR", fleF028_CONTACTS_INFO_MSTR.GetStringValue("CONTACTS_EMAIL_ADDR"));
                    fleF028_DUP.PutData();
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


        private bool Internal_DUPLICATE_ADDRESS()
        {


            try
            {

                // --> GET F027_DESIGNER <--

                fleF027_DESIGNER.GetData(GetDataOptions.IsOptional);
                // --> End GET F027_DESIGNER <--
                if (AccessOk)
                {
                    X_DUP_CONTACTS_NAME.Value = QDesign.UCase(QDesign.RTrim(QDesign.LeftJustify(fleF027_DESIGNER.GetStringValue("CONTACTS_SURNAME"))) + "," + QDesign.RTrim(QDesign.LeftJustify(fleF027_DESIGNER.GetStringValue("CONTACTS_GIVEN_NAMES"))));
                    if (QDesign.NULL(X_DUP_CONTACTS_NAME.Value) == QDesign.NULL(X_CONTACTS_NAME.Value))
                    {
                        while (fleF028_DUP.WhileRetrieving())
                        {
                            fleF028_DUP.set_SetValue("CONTACTS_ADDR_1", fleF028_CONTACTS_INFO_MSTR.GetStringValue("CONTACTS_ADDR_1"));
                            fleF028_DUP.set_SetValue("CONTACTS_ADDR_2", fleF028_CONTACTS_INFO_MSTR.GetStringValue("CONTACTS_ADDR_2"));
                            fleF028_DUP.set_SetValue("CONTACTS_ADDR_3", fleF028_CONTACTS_INFO_MSTR.GetStringValue("CONTACTS_ADDR_3"));
                            fleF028_DUP.set_SetValue("POSTAL_CODE", fleF028_CONTACTS_INFO_MSTR.GetStringValue("POSTAL_CODE"));
                            fleF028_DUP.set_SetValue("CONTACTS_PHONE_NBR", fleF028_CONTACTS_INFO_MSTR.GetDecimalValue("CONTACTS_PHONE_NBR"));
                            fleF028_DUP.set_SetValue("CONTACTS_PHONE_EXT", fleF028_CONTACTS_INFO_MSTR.GetDecimalValue("CONTACTS_PHONE_EXT"));
                            fleF028_DUP.set_SetValue("CONTACTS_PAGER_NBR", fleF028_CONTACTS_INFO_MSTR.GetDecimalValue("CONTACTS_PAGER_NBR"));
                            fleF028_DUP.set_SetValue("CONTACTS_CELL_NBR", fleF028_CONTACTS_INFO_MSTR.GetDecimalValue("CONTACTS_CELL_NBR"));
                            fleF028_DUP.set_SetValue("CONTACTS_FAX_NBR", fleF028_CONTACTS_INFO_MSTR.GetDecimalValue("CONTACTS_FAX_NBR"));
                            fleF028_DUP.PutData();
                        }
                    }
                }
                else
                {
                    fleF027_DESIGNER.set_SetValue("DOC_NBR", fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR"));
                    fleF027_DESIGNER.set_SetValue("CONTACTS_TYPE", X_CONTACTS_TYPE.Value);
                    fleF027_DESIGNER.set_SetValue("CONTACTS_SURNAME", fleF027_CONTACTS_MSTR.GetStringValue("CONTACTS_SURNAME"));
                    fleF027_DESIGNER.set_SetValue("CONTACTS_GIVEN_NAMES", fleF027_CONTACTS_MSTR.GetStringValue("CONTACTS_GIVEN_NAMES"));
                    fleF027_DESIGNER.set_SetValue("CONTACTS_INIT_S1", fleF027_CONTACTS_MSTR.GetStringValue("CONTACTS_INIT_S1"));
                    //Parent:CONTACTS_INITS
                    fleF027_DESIGNER.set_SetValue("CONTACTS_INIT_S2", fleF027_CONTACTS_MSTR.GetStringValue("CONTACTS_INIT_S2"));
                    //Parent:CONTACTS_INITS
                    fleF027_DESIGNER.set_SetValue("CONTACTS_INIT_S3", fleF027_CONTACTS_MSTR.GetStringValue("CONTACTS_INIT_S3"));
                    //Parent:CONTACTS_INITS    'Parent:CONTACTS_INITS
                    fleF027_DESIGNER.set_SetValue("CONTACTS_TITLE", fleF027_CONTACTS_MSTR.GetStringValue("CONTACTS_TITLE"));
                    fleF027_DESIGNER.set_SetValue("CONTACTS_SEX", fleF027_CONTACTS_MSTR.GetStringValue("CONTACTS_SEX"));
                    fleF027_DESIGNER.set_SetValue("BILLING_ENTRY_FLAG", fleF027_CONTACTS_MSTR.GetStringValue("BILLING_ENTRY_FLAG"));
                    fleF027_DESIGNER.set_SetValue("LOGON_USERNAME", fleF027_CONTACTS_MSTR.GetStringValue("LOGON_USERNAME"));
                    fleF027_DESIGNER.PutData();
                    fleF028_DUP.set_SetValue("DOC_NBR", fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR"));
                    fleF028_DUP.set_SetValue("CONTACTS_TYPE", X_CONTACTS_TYPE.Value);
                    fleF028_DUP.set_SetValue("CONTACTS_LOCATION", fleF028_CONTACTS_INFO_MSTR.GetStringValue("CONTACTS_LOCATION"));
                    fleF028_DUP.set_SetValue("CONTACTS_ADDR_1", fleF028_CONTACTS_INFO_MSTR.GetStringValue("CONTACTS_ADDR_1"));
                    fleF028_DUP.set_SetValue("CONTACTS_ADDR_2", fleF028_CONTACTS_INFO_MSTR.GetStringValue("CONTACTS_ADDR_2"));
                    fleF028_DUP.set_SetValue("CONTACTS_ADDR_3", fleF028_CONTACTS_INFO_MSTR.GetStringValue("CONTACTS_ADDR_3"));
                    fleF028_DUP.set_SetValue("POSTAL_CODE", fleF028_CONTACTS_INFO_MSTR.GetStringValue("POSTAL_CODE"));
                    fleF028_DUP.set_SetValue("CONTACTS_PHONE_NBR", fleF028_CONTACTS_INFO_MSTR.GetDecimalValue("CONTACTS_PHONE_NBR"));
                    fleF028_DUP.set_SetValue("CONTACTS_PHONE_EXT", fleF028_CONTACTS_INFO_MSTR.GetDecimalValue("CONTACTS_PHONE_EXT"));
                    fleF028_DUP.set_SetValue("CONTACTS_PAGER_NBR", fleF028_CONTACTS_INFO_MSTR.GetDecimalValue("CONTACTS_PAGER_NBR"));
                    fleF028_DUP.set_SetValue("CONTACTS_CELL_NBR", fleF028_CONTACTS_INFO_MSTR.GetDecimalValue("CONTACTS_CELL_NBR"));
                    fleF028_DUP.set_SetValue("CONTACTS_FAX_NBR", fleF028_CONTACTS_INFO_MSTR.GetDecimalValue("CONTACTS_FAX_NBR"));
                    fleF028_DUP.PutData();
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



        private void dsrDesigner_DUPE_Click(object sender, System.EventArgs e)
        {

            try
            {

                while (fleF020_DOCTOR_MSTR.WhileRetrieving())
                {
                    if (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")) != QDesign.NULL(X_DOC_NBR.Value) & QDesign.NULL(fleF020_DOCTOR_MSTR.GetNumericDateValue("DOC_DATE_FAC_TERM")) == 0)
                    {
                        Internal_DUPLICATE_EMAIL();
                    }
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



        private void dsrDesigner_DUPA_Click(object sender, System.EventArgs e)
        {

            try
            {

                while (fleF020_DOCTOR_MSTR.WhileRetrieving())
                {
                    if (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")) != QDesign.NULL(X_DOC_NBR.Value) & QDesign.NULL(fleF020_DOCTOR_MSTR.GetNumericDateValue("DOC_DATE_FAC_TERM")) == 0)
                    {
                        Internal_DUPLICATE_ADDRESS();
                    }
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
                while (fleF028_CONTACTS_INFO_MSTR.ForMissing())
                {
                    m_strWhere = new StringBuilder(GetWhereCondition(fleF028_CONTACTS_INFO_MSTR.ElementOwner("FILLER"), fleF028_CONTACTS_INFO_MSTR.GetStringValue("FILLER"), ref blnAddWhere));
                    m_strWhere.Append(GetWhereCondition(fleF028_CONTACTS_INFO_MSTR.ElementOwner("DOC_NBR"), X_DOC_NBR.Value, ref blnAddWhere));
                    m_strWhere.Append(GetWhereCondition(fleF028_CONTACTS_INFO_MSTR.ElementOwner("CONTACTS_TYPE"), X_CONTACTS_TYPE.Value, ref blnAddWhere));
                    fleF028_CONTACTS_INFO_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
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
                Page.PageTitle = "Info for:" + X_CONTACTS_NAME.Value;



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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:12:02 AM
        //#-----------------------------------------
        protected override bool Append()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:12:02 AM
                Accept(ref fldF028_CONTACTS_INFO_MSTR_CONTACTS_LOCATION);
                Accept(ref fldF028_CONTACTS_INFO_MSTR_CONTACTS_PHONE_NBR);
                Accept(ref fldF028_CONTACTS_INFO_MSTR_CONTACTS_PHONE_EXT);
                Accept(ref fldF028_CONTACTS_INFO_MSTR_CONTACTS_ADDR_1);
                Accept(ref fldF028_CONTACTS_INFO_MSTR_CONTACTS_FAX_NBR);
                Accept(ref fldF028_CONTACTS_INFO_MSTR_CONTACTS_ADDR_2);
                Accept(ref fldF028_CONTACTS_INFO_MSTR_CONTACTS_PAGER_NBR);
                Accept(ref fldF028_CONTACTS_INFO_MSTR_CONTACTS_ADDR_3);
                Accept(ref fldF028_CONTACTS_INFO_MSTR_CONTACTS_CELL_NBR);
                Accept(ref fldF028_CONTACTS_INFO_MSTR_POSTAL_CODE);
                Accept(ref fldF028_CONTACTS_INFO_MSTR_CONTACTS_EMAIL_ADDR);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:12:02 AM
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:12:02 AM
        //#-----------------------------------------
        protected override bool Update()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:12:02 AM
                fleF027_CONTACTS_MSTR.PutData(false, PutTypes.New);
                while (fleF028_CONTACTS_INFO_MSTR.For())
                {
                    fleF028_CONTACTS_INFO_MSTR.PutData(false, PutTypes.Deleted);
                }
                while (fleF028_CONTACTS_INFO_MSTR.For())
                {
                    fleF028_CONTACTS_INFO_MSTR.PutData();
                }
                fleF027_CONTACTS_MSTR.PutData();
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:12:02 AM
        //#-----------------------------------------
        protected override bool Delete()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:12:02 AM
                fleF028_CONTACTS_INFO_MSTR.DeletedRecord = true;
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
        //# dtlF028_CONTACTS_INFO_MSTR_EditClick Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:12:02 AM
        //#-----------------------------------------
        private void dtlF028_CONTACTS_INFO_MSTR_EditClick(DataList source, GridButtonEventArgs GridButtonEventArgs)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:12:02 AM
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:12:02 AM
        //#-----------------------------------------
        private void dsrDesigner_01_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:12:02 AM
                if (!fleF028_CONTACTS_INFO_MSTR.NewRecord)
                {
                    Display(ref fldF028_CONTACTS_INFO_MSTR_CONTACTS_LOCATION);
                }
                else
                {
                    Accept(ref fldF028_CONTACTS_INFO_MSTR_CONTACTS_LOCATION);
                }
                Accept(ref fldF028_CONTACTS_INFO_MSTR_CONTACTS_PHONE_NBR);
                Accept(ref fldF028_CONTACTS_INFO_MSTR_CONTACTS_PHONE_EXT);
                Accept(ref fldF028_CONTACTS_INFO_MSTR_CONTACTS_ADDR_1);
                Accept(ref fldF028_CONTACTS_INFO_MSTR_CONTACTS_FAX_NBR);
                Accept(ref fldF028_CONTACTS_INFO_MSTR_CONTACTS_ADDR_2);
                Accept(ref fldF028_CONTACTS_INFO_MSTR_CONTACTS_PAGER_NBR);
                Accept(ref fldF028_CONTACTS_INFO_MSTR_CONTACTS_ADDR_3);
                Accept(ref fldF028_CONTACTS_INFO_MSTR_CONTACTS_CELL_NBR);
                Accept(ref fldF028_CONTACTS_INFO_MSTR_POSTAL_CODE);
                Accept(ref fldF028_CONTACTS_INFO_MSTR_CONTACTS_EMAIL_ADDR);
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

