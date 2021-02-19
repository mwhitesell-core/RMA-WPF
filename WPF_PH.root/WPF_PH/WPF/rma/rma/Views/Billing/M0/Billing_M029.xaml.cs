
#region "Screen Comments"

// #> program-id.     m029.qks
// program purpose : doctor`s follow up events/date/person responsible 
// modification history
// date   who     description
// 2005/feb/02   b.e. - original
// on 3 

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

    partial class Billing_M029 : BasePage
    {

        #region " Form Designer Generated Code "





        public Billing_M029()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "M029";

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
            dtlF029_FOLLOWUP_EVENTS.EditClick += dtlF029_FOLLOWUP_EVENTS_EditClick;
            base.Page_Load();

            // TODO: If any DESIGNER procedures function on occurring FILES or TEMPORARIES, set the grid's AllowSelectRowButton property to TRUE.



        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            X_DOC_NBR = new CoreCharacter("X_DOC_NBR", 3, this, Common.cEmptyString);
            X_DOC_NAME = new CoreCharacter("X_DOC_NAME", 30, this, Common.cEmptyString);
            fleF029_FOLLOWUP_EVENTS = new SqlFileObject(this, FileTypes.Primary, 6, "INDEXED", "F029_FOLLOWUP_EVENTS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
           
            fleF029_FOLLOWUP_EVENTS.InitializeItems += fleF029_FOLLOWUP_EVENTS_InitializeItems;
        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;

            dsrDesigner_01.Click -= dsrDesigner_01_Click;
            dtlF029_FOLLOWUP_EVENTS.EditClick -= dtlF029_FOLLOWUP_EVENTS_EditClick;
            fleF029_FOLLOWUP_EVENTS.InitializeItems -= fleF029_FOLLOWUP_EVENTS_InitializeItems;
        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private SqlConnection m_cnnQUERY = new SqlConnection();
        private SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
        private SqlTransaction m_trnTRANS_UPDATE;
        private CoreCharacter X_DOC_NBR;
        private CoreCharacter X_DOC_NAME;
        private SqlFileObject fleF029_FOLLOWUP_EVENTS;

        private void fleF029_FOLLOWUP_EVENTS_InitializeItems(bool Fixed)
        {

            try
            {
                if (!Fixed)
                    fleF029_FOLLOWUP_EVENTS.set_SetValue("FILLER", true, " ");
                if (!Fixed)
                    fleF029_FOLLOWUP_EVENTS.set_SetValue("DOC_NBR", true, X_DOC_NBR.Value);


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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:11:56 AM

        protected DateControl fldF029_FOLLOWUP_EVENTS_FOLLOWUP_DATE;
        protected TextBox fldF029_FOLLOWUP_EVENTS_FOLLOWUP_ACTION;
        protected ComboBox fldF029_FOLLOWUP_EVENTS_FOLLOWUP_STATUS;

        protected TextBox fldF029_FOLLOWUP_EVENTS_CONTACTS_EMAIL_ADDR;

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:11:56 AM

        //#-----------------------------------------
        //# GetGridFieldObject Procedure.
        //#-----------------------------------------

        protected override void GetGridFieldObject(object DataListField, ref object CoreField, string Name)
        {

            try
            {
                switch (Name.ToUpper())
                {
                    case "FLDGRDF029_FOLLOWUP_EVENTS_FOLLOWUP_DATE":
                        fldF029_FOLLOWUP_EVENTS_FOLLOWUP_DATE = (DateControl)DataListField;
                        CoreField = fldF029_FOLLOWUP_EVENTS_FOLLOWUP_DATE;
                        fldF029_FOLLOWUP_EVENTS_FOLLOWUP_DATE.Bind(fleF029_FOLLOWUP_EVENTS);
                        break;
                    case "FLDGRDF029_FOLLOWUP_EVENTS_FOLLOWUP_ACTION":
                        fldF029_FOLLOWUP_EVENTS_FOLLOWUP_ACTION = (TextBox)DataListField;
                        CoreField = fldF029_FOLLOWUP_EVENTS_FOLLOWUP_ACTION;
                        fldF029_FOLLOWUP_EVENTS_FOLLOWUP_ACTION.Bind(fleF029_FOLLOWUP_EVENTS);
                        break;
                    case "FLDGRDF029_FOLLOWUP_EVENTS_FOLLOWUP_STATUS":
                        fldF029_FOLLOWUP_EVENTS_FOLLOWUP_STATUS = (ComboBox)DataListField;
                        CoreField = fldF029_FOLLOWUP_EVENTS_FOLLOWUP_STATUS;
                        fldF029_FOLLOWUP_EVENTS_FOLLOWUP_STATUS.Bind(fleF029_FOLLOWUP_EVENTS);
                        break;
                    case "FLDGRDF029_FOLLOWUP_EVENTS_CONTACTS_EMAIL_ADDR":
                        fldF029_FOLLOWUP_EVENTS_CONTACTS_EMAIL_ADDR = (TextBox)DataListField;
                        CoreField = fldF029_FOLLOWUP_EVENTS_CONTACTS_EMAIL_ADDR;
                        fldF029_FOLLOWUP_EVENTS_CONTACTS_EMAIL_ADDR.Bind(fleF029_FOLLOWUP_EVENTS);
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
                dtlF029_FOLLOWUP_EVENTS.OccursWithFile = fleF029_FOLLOWUP_EVENTS;

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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:11:56 AM

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
            fleF029_FOLLOWUP_EVENTS.Transaction = m_trnTRANS_UPDATE;


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:11:56 AM

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
                fleF029_FOLLOWUP_EVENTS.Dispose();


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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:11:56 AM
        //#-----------------------------------------
        protected override void DisplayFormatting()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:11:56 AM

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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:11:56 AM
        //#-----------------------------------------
        protected override void PreDisplayFormatting()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:11:56 AM

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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:11:56 AM

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


        protected override object SetFieldDefaults(string Name)
        {


            try
            {
                switch (Name)
                {
                    case "F029_FOLLOWUP_EVENTS_FOLLOWUP_STATUS":
                        return "O";
                    default:
                        return "";
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




        protected override void SaveParamsReceived()
        {

            try
            {
                SaveReceivingParams(X_DOC_NBR, X_DOC_NAME);


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
                Receiving(X_DOC_NBR, X_DOC_NAME);


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
                while (fleF029_FOLLOWUP_EVENTS.ForMissing())
                {
                    m_strWhere = new StringBuilder(GetWhereCondition(fleF029_FOLLOWUP_EVENTS.ElementOwner("FILLER"), fleF029_FOLLOWUP_EVENTS.GetStringValue("FILLER"), ref blnAddWhere));
                    m_strWhere.Append(GetWhereCondition(fleF029_FOLLOWUP_EVENTS.ElementOwner("DOC_NBR"), X_DOC_NBR.Value, ref blnAddWhere));
                    fleF029_FOLLOWUP_EVENTS.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
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
                Page.PageTitle = "Followups for:" + X_DOC_NAME.Value;



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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:11:56 AM
        //#-----------------------------------------
        protected override bool Append()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:11:56 AM
                Accept(ref fldF029_FOLLOWUP_EVENTS_FOLLOWUP_DATE);
                Accept(ref fldF029_FOLLOWUP_EVENTS_FOLLOWUP_ACTION);
                Accept(ref fldF029_FOLLOWUP_EVENTS_FOLLOWUP_STATUS);
                Accept(ref fldF029_FOLLOWUP_EVENTS_CONTACTS_EMAIL_ADDR);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:11:56 AM
        //#-----------------------------------------
        protected override bool Entry()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:11:56 AM

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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:11:56 AM
        //#-----------------------------------------
        protected override bool Update()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:11:56 AM
                while (fleF029_FOLLOWUP_EVENTS.For())
                {
                    fleF029_FOLLOWUP_EVENTS.PutData(false, PutTypes.Deleted);
                }
                while (fleF029_FOLLOWUP_EVENTS.For())
                {
                    fleF029_FOLLOWUP_EVENTS.PutData();
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:11:56 AM
        //#-----------------------------------------
        protected override bool Delete()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:11:56 AM
                fleF029_FOLLOWUP_EVENTS.DeletedRecord = true;
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
        //# dtlF029_FOLLOWUP_EVENTS_EditClick Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:11:56 AM
        //#-----------------------------------------
        private void dtlF029_FOLLOWUP_EVENTS_EditClick(DataList source, GridButtonEventArgs GridButtonEventArgs)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:11:56 AM
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:11:56 AM
        //#-----------------------------------------
        private void dsrDesigner_01_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:11:56 AM
                Accept(ref fldF029_FOLLOWUP_EVENTS_FOLLOWUP_DATE);
                Accept(ref fldF029_FOLLOWUP_EVENTS_FOLLOWUP_ACTION);
                Accept(ref fldF029_FOLLOWUP_EVENTS_FOLLOWUP_STATUS);
                Accept(ref fldF029_FOLLOWUP_EVENTS_CONTACTS_EMAIL_ADDR);
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
