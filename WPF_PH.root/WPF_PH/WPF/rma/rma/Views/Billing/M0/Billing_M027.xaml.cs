
#region "Screen Comments"

// #> program-id.     m027.qks
// program purpose : entry of a doctor`s contacts including their own address/phone etc
// modification historY
// date   who     description
// 2005/jan/19   b.e. - original
// 2005/mar/17   M.C.    - include web user name
// 2006/apr/04   M.C. - if user update contacts-surname for doctor type in f027, also update doc-name in f020
// - include f020-doctor-mstr 
// 2006/aug/08   M.C.    - define & pass x-doc-ohip-nbr when calling to m028
// 2006/oct/19   M.C. - extend the size of x-contacts-name from 40 to 60   
// 2006/oct/23   M.C. - Upshift x-contacts-name 
// 2006/oct/26   M.C. - passing f027-contacts-mstr when calling m028 
// 2016/Apr/18   MC1 - do not update  f020-doctor-mstr here so that it forces the update in the higher screen,
// this will update audit file correctly in the higher screen
// 2006/06/06 - MC
// screen $pb_obj/m027 receiving x-doc-nbr, x-doc-name  

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

    partial class Billing_M027 : BasePage
    {

        #region " Form Designer Generated Code "





        public Billing_M027()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "M027";

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
            dsrDesigner_MORE.Click += dsrDesigner_MORE_Click;
            dsrDesigner_01.Click += dsrDesigner_01_Click;
            dtlF027_CONTACTS_MSTR.EditClick += DtlF027_CONTACTS_MSTR_EditClick;
            base.Page_Load();

            // TODO: If any DESIGNER procedures function on occurring FILES or TEMPORARIES, set the grid's AllowSelectRowButton property to TRUE.



            // TODO: The following FIELD(S) on the form are redefine elements.  Manual steps may be required:
            //       F027_CONTACTS_MSTR.CONTACTS_INITS


        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            T_CONTACTS_INITS = new CoreCharacter("T_CONTACTS_INITS", 3, this, Common.cEmptyString);

            X_DOC_OHIP_NBR = new CoreDecimal("X_DOC_OHIP_NBR", 6, this);
            X_DOC_NBR = new CoreCharacter("X_DOC_NBR", 3, this, Common.cEmptyString);
            X_CONTACTS_TYPE = new CoreCharacter("X_CONTACTS_TYPE", 1, this, Common.cEmptyString);
            X_DOC_NAME = new CoreCharacter("X_DOC_NAME", 30, this, Common.cEmptyString);
            X_CONTACTS_NAME = new CoreCharacter("X_CONTACTS_NAME", 60, this, Common.cEmptyString);
            fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Master, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF027_CONTACTS_MSTR = new SqlFileObject(this, FileTypes.Primary, 4, "INDEXED", "F027_CONTACTS_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
           

            fleF027_CONTACTS_MSTR.SetItemFinals += fleF027_CONTACTS_MSTR_SetItemFinals;
            fleF027_CONTACTS_MSTR.InitializeItems += fleF027_CONTACTS_MSTR_InitializeItems;
        }

      

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;
            fldF027_CONTACTS_MSTR_CONTACTS_TYPE.LookupNotOn -= fldF027_CONTACTS_MSTR_CONTACTS_TYPE_LookupNotOn;

            dsrDesigner_MORE.Click -= dsrDesigner_MORE_Click;
            dsrDesigner_01.Click -= dsrDesigner_01_Click;
            fleF027_CONTACTS_MSTR.SetItemFinals -= fleF027_CONTACTS_MSTR_SetItemFinals;
            dtlF027_CONTACTS_MSTR.EditClick -= DtlF027_CONTACTS_MSTR_EditClick;
            fleF027_CONTACTS_MSTR.InitializeItems -= fleF027_CONTACTS_MSTR_InitializeItems;
        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.

        private CoreCharacter T_CONTACTS_INITS;  

        private SqlConnection m_cnnQUERY = new SqlConnection();
        private SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
        private SqlTransaction m_trnTRANS_UPDATE;
        private CoreDecimal X_DOC_OHIP_NBR;
        private CoreCharacter X_DOC_NBR;
        private CoreCharacter X_CONTACTS_TYPE;
        private CoreCharacter X_DOC_NAME;
        private CoreCharacter X_CONTACTS_NAME;
        private SqlFileObject fleF020_DOCTOR_MSTR;
        private SqlFileObject fleF027_CONTACTS_MSTR;

        private void fleF027_CONTACTS_MSTR_SetItemFinals()
        {

            fleF027_CONTACTS_MSTR.set_SetValue("CONTACTS_INIT_S1", T_CONTACTS_INITS.Value.PadRight(3, ' ').Substring(0, 1));
            fleF027_CONTACTS_MSTR.set_SetValue("CONTACTS_INIT_S2", T_CONTACTS_INITS.Value.PadRight(3, ' ').Substring(1, 1));
            fleF027_CONTACTS_MSTR.set_SetValue("CONTACTS_INIT_S3", T_CONTACTS_INITS.Value.PadRight(3, ' ').Substring(2, 1));

        }

        private void fleF027_CONTACTS_MSTR_InitializeItems(bool Fixed)
        {

            try
            {
                if (!Fixed)
                    fleF027_CONTACTS_MSTR.set_SetValue("FILLER", true, " ");
                if (!Fixed)
                    fleF027_CONTACTS_MSTR.set_SetValue("DOC_NBR", true, X_DOC_NBR.Value);


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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:12:09 AM

        protected ComboBox fldF027_CONTACTS_MSTR_CONTACTS_TYPE;
        protected TextBox fldF027_CONTACTS_MSTR_CONTACTS_SURNAME;
        protected TextBox fldF027_CONTACTS_MSTR_CONTACTS_GIVEN_NAMES;
        protected TextBox fldF027_CONTACTS_MSTR_CONTACTS_INITS;
        protected ComboBox fldF027_CONTACTS_MSTR_CONTACTS_SEX;
        protected TextBox fldF027_CONTACTS_MSTR_CONTACTS_TITLE;
        protected ComboBox fldF027_CONTACTS_MSTR_BILLING_ENTRY_FLAG;

        protected TextBox fldF027_CONTACTS_MSTR_LOGON_USERNAME;

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:12:09 AM

        //#-----------------------------------------
        //# GetGridFieldObject Procedure.
        //#-----------------------------------------

        protected override void GetGridFieldObject(object DataListField, ref object CoreField, string Name)
        {

            try
            {
                switch (Name.ToUpper())
                {
                    case "FLDGRDF027_CONTACTS_MSTR_CONTACTS_TYPE":
                        fldF027_CONTACTS_MSTR_CONTACTS_TYPE = (ComboBox)DataListField;

                        fldF027_CONTACTS_MSTR_CONTACTS_TYPE.LookupNotOn -= fldF027_CONTACTS_MSTR_CONTACTS_TYPE_LookupNotOn;
                        fldF027_CONTACTS_MSTR_CONTACTS_TYPE.LookupNotOn += fldF027_CONTACTS_MSTR_CONTACTS_TYPE_LookupNotOn;
                        CoreField = fldF027_CONTACTS_MSTR_CONTACTS_TYPE;
                        fldF027_CONTACTS_MSTR_CONTACTS_TYPE.Bind(fleF027_CONTACTS_MSTR);
                        break;
                    case "FLDGRDF027_CONTACTS_MSTR_CONTACTS_SURNAME":
                        fldF027_CONTACTS_MSTR_CONTACTS_SURNAME = (TextBox)DataListField;
                        CoreField = fldF027_CONTACTS_MSTR_CONTACTS_SURNAME;
                        fldF027_CONTACTS_MSTR_CONTACTS_SURNAME.Bind(fleF027_CONTACTS_MSTR);
                        break;
                    case "FLDGRDF027_CONTACTS_MSTR_CONTACTS_GIVEN_NAMES":
                        fldF027_CONTACTS_MSTR_CONTACTS_GIVEN_NAMES = (TextBox)DataListField;
                        CoreField = fldF027_CONTACTS_MSTR_CONTACTS_GIVEN_NAMES;
                        fldF027_CONTACTS_MSTR_CONTACTS_GIVEN_NAMES.Bind(fleF027_CONTACTS_MSTR);
                        break;
                    case "FLDGRDF027_CONTACTS_MSTR_CONTACTS_INITS":
                        fldF027_CONTACTS_MSTR_CONTACTS_INITS = (TextBox)DataListField;
                        CoreField = fldF027_CONTACTS_MSTR_CONTACTS_INITS;
                        fldF027_CONTACTS_MSTR_CONTACTS_INITS.Bind(fleF027_CONTACTS_MSTR);
                        break;
                    case "FLDGRDF027_CONTACTS_MSTR_CONTACTS_SEX":
                        fldF027_CONTACTS_MSTR_CONTACTS_SEX = (ComboBox)DataListField;
                        CoreField = fldF027_CONTACTS_MSTR_CONTACTS_SEX;
                        fldF027_CONTACTS_MSTR_CONTACTS_SEX.Bind(fleF027_CONTACTS_MSTR);
                        break;
                    case "FLDGRDF027_CONTACTS_MSTR_CONTACTS_TITLE":
                        fldF027_CONTACTS_MSTR_CONTACTS_TITLE = (TextBox)DataListField;
                        CoreField = fldF027_CONTACTS_MSTR_CONTACTS_TITLE;
                        fldF027_CONTACTS_MSTR_CONTACTS_TITLE.Bind(fleF027_CONTACTS_MSTR);
                        break;
                    case "FLDGRDF027_CONTACTS_MSTR_BILLING_ENTRY_FLAG":
                        fldF027_CONTACTS_MSTR_BILLING_ENTRY_FLAG = (ComboBox)DataListField;
                        CoreField = fldF027_CONTACTS_MSTR_BILLING_ENTRY_FLAG;
                        fldF027_CONTACTS_MSTR_BILLING_ENTRY_FLAG.Bind(fleF027_CONTACTS_MSTR);
                        break;
                    case "FLDGRDF027_CONTACTS_MSTR_LOGON_USERNAME":
                        fldF027_CONTACTS_MSTR_LOGON_USERNAME = (TextBox)DataListField;
                        CoreField = fldF027_CONTACTS_MSTR_LOGON_USERNAME;
                        fldF027_CONTACTS_MSTR_LOGON_USERNAME.Bind(fleF027_CONTACTS_MSTR);
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
                dtlF027_CONTACTS_MSTR.OccursWithFile = fleF027_CONTACTS_MSTR;

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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:12:09 AM

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
            fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
            fleF027_CONTACTS_MSTR.Transaction = m_trnTRANS_UPDATE;


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:12:09 AM

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
                fleF020_DOCTOR_MSTR.Dispose();
                fleF027_CONTACTS_MSTR.Dispose();


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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:12:09 AM
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:12:09 AM
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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:12:09 AM

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



        private void fldF027_CONTACTS_MSTR_CONTACTS_TYPE_LookupNotOn(ref bool LookupNotOnExecuted)
        {

            try
            {
                bool blnAlreadyExists = false;
                StringBuilder strSQL = new StringBuilder("SELECT ").Append(fleF027_CONTACTS_MSTR.ElementOwner("FILLER"));
                strSQL.Append(" FROM ");
                strSQL.Append(fleF027_CONTACTS_MSTR.TableNameWithAlias());
                strSQL.Append(" WHERE ");
                strSQL.Append("     ").Append(fleF027_CONTACTS_MSTR.ElementOwner("FILLER")).Append(" = ").Append(Common.StringToField(fleF027_CONTACTS_MSTR.GetStringValue("FILLER")));
                strSQL.Append(" And ").Append(fleF027_CONTACTS_MSTR.ElementOwner("DOC_NBR")).Append(" = ").Append(Common.StringToField(fleF027_CONTACTS_MSTR.GetStringValue("DOC_NBR")));
                strSQL.Append(" And ").Append(fleF027_CONTACTS_MSTR.ElementOwner("CONTACTS_TYPE")).Append(" = ").Append(Common.StringToField(FieldText));

                if (!LookupNotOn(strSQL, fleF027_CONTACTS_MSTR, new string[] { "FILLER", "DOC_NBR", "CONTACTS_TYPE" }, new Object[] { fleF027_CONTACTS_MSTR.GetStringValue("FILLER"), fleF027_CONTACTS_MSTR.GetStringValue("DOC_NBR"), FieldText }))
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
                SaveReceivingParams(fleF020_DOCTOR_MSTR, X_DOC_NBR, X_DOC_NAME);


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
                Receiving(fleF020_DOCTOR_MSTR, X_DOC_NBR, X_DOC_NAME);


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


        private void dsrDesigner_MORE_Click(object sender, System.EventArgs e)
        {

            try
            {

                X_DOC_OHIP_NBR.Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR");
                X_CONTACTS_TYPE.Value = fleF027_CONTACTS_MSTR.GetStringValue("CONTACTS_TYPE");
                X_CONTACTS_NAME.Value = QDesign.UCase(QDesign.RTrim(QDesign.LeftJustify(fleF027_CONTACTS_MSTR.GetStringValue("CONTACTS_SURNAME"))) + "," + QDesign.RTrim(QDesign.LeftJustify(fleF027_CONTACTS_MSTR.GetStringValue("CONTACTS_GIVEN_NAMES"))));
                object[] arrRunscreen = { X_DOC_NBR, X_DOC_OHIP_NBR, X_CONTACTS_TYPE, X_CONTACTS_NAME, fleF027_CONTACTS_MSTR };
                RunScreen(new Billing_M028(), RunScreenModes.Same, ref arrRunscreen);


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

                if (AlteredRecord())
                {
                    while (fleF027_CONTACTS_MSTR.For())
                    {
                        X_CONTACTS_NAME.Value = fleF027_CONTACTS_MSTR.GetStringValue("CONTACTS_SURNAME") + "," + fleF027_CONTACTS_MSTR.GetStringValue("CONTACTS_INIT_S1") + fleF027_CONTACTS_MSTR.GetStringValue("CONTACTS_INIT_S2") + fleF027_CONTACTS_MSTR.GetStringValue("CONTACTS_INIT_S3");
                        //Parent:CONTACTS_INITS
                        if (QDesign.NULL(X_DOC_NAME.Value) != QDesign.NULL(X_CONTACTS_NAME.Value) & QDesign.NULL(fleF027_CONTACTS_MSTR.GetStringValue("CONTACTS_TYPE")) == QDesign.NULL("D"))
                        {
                            fleF020_DOCTOR_MSTR.set_SetValue("DOC_NAME", fleF027_CONTACTS_MSTR.GetStringValue("CONTACTS_SURNAME"));
                            fleF020_DOCTOR_MSTR.set_SetValue("DOC_INIT1", (fleF027_CONTACTS_MSTR.GetStringValue("CONTACTS_INIT_S1") + fleF027_CONTACTS_MSTR.GetStringValue("CONTACTS_INIT_S2") + fleF027_CONTACTS_MSTR.GetStringValue("CONTACTS_INIT_S3")).PadRight(3).Substring(0, 1));
                            //Parent:DOC_INITS    'Parent:CONTACTS_INITS
                            fleF020_DOCTOR_MSTR.set_SetValue("DOC_INIT2", (fleF027_CONTACTS_MSTR.GetStringValue("CONTACTS_INIT_S1") + fleF027_CONTACTS_MSTR.GetStringValue("CONTACTS_INIT_S2") + fleF027_CONTACTS_MSTR.GetStringValue("CONTACTS_INIT_S3")).PadRight(3).Substring(1, 1));
                            //Parent:DOC_INITS    'Parent:CONTACTS_INITS
                            fleF020_DOCTOR_MSTR.set_SetValue("DOC_INIT3", (fleF027_CONTACTS_MSTR.GetStringValue("CONTACTS_INIT_S1") + fleF027_CONTACTS_MSTR.GetStringValue("CONTACTS_INIT_S2") + fleF027_CONTACTS_MSTR.GetStringValue("CONTACTS_INIT_S3")).PadRight(3).Substring(2, 1));
                            //Parent:DOC_INITS    'Parent:CONTACTS_INITS
                            fleF020_DOCTOR_MSTR.set_SetValue("DOC_NAME_SOUNDEX", QDesign.Soundex(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NAME")));
                        }
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


        protected override bool Update()
        {


            try
            {

                while (fleF027_CONTACTS_MSTR.For())
                {
                    fleF027_CONTACTS_MSTR.PutData();
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



        protected override bool Find()
        {


            try
            {
                bool blnAddWhere = true;
                while (fleF027_CONTACTS_MSTR.ForMissing())
                {
                    m_strWhere = new StringBuilder(GetWhereCondition(fleF027_CONTACTS_MSTR.ElementOwner("FILLER"), fleF027_CONTACTS_MSTR.GetStringValue("FILLER"), ref blnAddWhere));
                    m_strWhere.Append(GetWhereCondition(fleF027_CONTACTS_MSTR.ElementOwner("DOC_NBR"), X_DOC_NBR.Value, ref blnAddWhere));
                    fleF027_CONTACTS_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
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

        protected override bool PostFind()
        {


            try
            {
                T_CONTACTS_INITS.Value = fleF027_CONTACTS_MSTR.GetStringValue("CONTACTS_INIT_S1").PadRight(1,' ') + fleF027_CONTACTS_MSTR.GetStringValue("CONTACTS_INIT_S3").PadRight(1, ' ') + fleF027_CONTACTS_MSTR.GetStringValue("CONTACTS_INIT_S3").PadRight(1, ' ');

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
                Page.PageTitle = "Contacts for:" + X_DOC_NAME.Value;



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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:12:09 AM
        //#-----------------------------------------
        protected override bool Append()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:12:09 AM
                Accept(ref fldF027_CONTACTS_MSTR_CONTACTS_TYPE);
                Accept(ref fldF027_CONTACTS_MSTR_CONTACTS_SURNAME);
                Accept(ref fldF027_CONTACTS_MSTR_CONTACTS_GIVEN_NAMES);
                Accept(ref fldF027_CONTACTS_MSTR_CONTACTS_INITS);
                Accept(ref fldF027_CONTACTS_MSTR_CONTACTS_SEX);
                Accept(ref fldF027_CONTACTS_MSTR_CONTACTS_TITLE);
                Accept(ref fldF027_CONTACTS_MSTR_BILLING_ENTRY_FLAG);
                Accept(ref fldF027_CONTACTS_MSTR_LOGON_USERNAME);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:12:09 AM
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
        //# Delete Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:12:09 AM
        //#-----------------------------------------
        protected override bool Delete()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:12:09 AM
                fleF027_CONTACTS_MSTR.DeletedRecord = true;
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
        //# dtlF027_CONTACTS_MSTR_EditClick Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:12:09 AM
        //#-----------------------------------------
        private void DtlF027_CONTACTS_MSTR_EditClick(DataList source, GridButtonEventArgs GridButtonEventArgs)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:12:09 AM
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:12:09 AM
        //#-----------------------------------------
        private void dsrDesigner_01_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:12:09 AM
                if (!fleF027_CONTACTS_MSTR.NewRecord)
                {
                    Display(ref fldF027_CONTACTS_MSTR_CONTACTS_TYPE);
                }
                else
                {
                    Accept(ref fldF027_CONTACTS_MSTR_CONTACTS_TYPE);
                }
                Accept(ref fldF027_CONTACTS_MSTR_CONTACTS_SURNAME);
                Accept(ref fldF027_CONTACTS_MSTR_CONTACTS_GIVEN_NAMES);
                Accept(ref fldF027_CONTACTS_MSTR_CONTACTS_INITS);
                Accept(ref fldF027_CONTACTS_MSTR_CONTACTS_SEX);
                Accept(ref fldF027_CONTACTS_MSTR_CONTACTS_TITLE);
                Accept(ref fldF027_CONTACTS_MSTR_BILLING_ENTRY_FLAG);
                Accept(ref fldF027_CONTACTS_MSTR_LOGON_USERNAME);
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

