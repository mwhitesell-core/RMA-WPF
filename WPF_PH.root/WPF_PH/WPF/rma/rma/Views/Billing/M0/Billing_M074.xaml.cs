
#region "Screen Comments"

// Program: m074
// Purpose: Maintain values in f074-afg-group-mstr
// The  governance  file contains payments for doctors based
// upon their afp group number and their 6 digit ohip number.
// This file has parameters for the afg group number and contains
// monthly calculations used in distributing payments made
// against a doctor`s 6 digit ohip number among the doctor`s
// various RMA numbers(if they have more than 1 RMA number)
// 2005/03/07  M.C. - substitute afp-payment-percentage with
// afp-multi-doc-ra-percentage
// 2007/feb/21 b.e. - added afp-group-process-flag
// 2007/aug/16   M.C. - Brad suggested to display warning message when
// user changes afp-group-process-flag

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

    partial class Billing_M074 : BasePage
    {

        #region " Form Designer Generated Code "





        public Billing_M074()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "M074";

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
            dtlF074_AFP_GROUP_MSTR.EditClick += dtlF074_AFP_GROUP_MSTR_EditClick;
            base.Page_Load();

            // TODO: If any DESIGNER procedures function on occurring FILES or TEMPORARIES, set the grid's AllowSelectRowButton property to TRUE.



        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            fleF074_AFP_GROUP_MSTR = new SqlFileObject(this, FileTypes.Primary, 5, "[101C].INDEXED", "F074_AFP_GROUP_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");


           
        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;
          

            dsrDesigner_01.Click -= dsrDesigner_01_Click;


        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private SqlConnection m_cnnQUERY = new SqlConnection();
        private SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
        private SqlTransaction m_trnTRANS_UPDATE;
        private SqlFileObject fleF074_AFP_GROUP_MSTR;
        #endregion

        #region "Standard Generated Procedures"

        #region "Grid Field Declarations"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 8/29/2017 10:04:01 AM

        protected TextBox fldF074_AFP_GROUP_MSTR_AFP_GOVERNANCE_GROUP;
        protected TextBox fldF074_AFP_GROUP_MSTR_DOC_AFP_PAYM_GROUP;
        private ComboBox fldF074_AFP_GROUP_MSTR_AFP_GROUP_PROCESS_FLAG;
        protected TextBox fldF074_AFP_GROUP_MSTR_BATCTRL_PAYROLL;
        protected TextBox fldF074_AFP_GROUP_MSTR_AFP_REPORTING_MTH;
        protected TextBox fldF074_AFP_GROUP_MSTR_AFP_MULTI_DOC_RA_PERCENTAGE;
        protected TextBox fldF074_AFP_GROUP_MSTR_AFP_PAYMENT_AMT;
        protected TextBox fldF074_AFP_GROUP_MSTR_AFP_PAYMENT_AMT_TOTAL;

        protected TextBox fldF074_AFP_GROUP_MSTR_AFP_GROUP_NAME;

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 8/29/2017 10:04:01 AM

        //#-----------------------------------------
        //# GetGridFieldObject Procedure.
        //#-----------------------------------------

        protected override void GetGridFieldObject(object DataListField, ref object CoreField, string Name)
        {

            try
            {
                switch (Name.ToUpper())
                {
                    case "FLDGRDF074_AFP_GROUP_MSTR_AFP_GOVERNANCE_GROUP":
                        fldF074_AFP_GROUP_MSTR_AFP_GOVERNANCE_GROUP = (TextBox)DataListField;
                        CoreField = fldF074_AFP_GROUP_MSTR_AFP_GOVERNANCE_GROUP;
                        fldF074_AFP_GROUP_MSTR_AFP_GOVERNANCE_GROUP.Bind(fleF074_AFP_GROUP_MSTR);
                        break;
                    case "FLDGRDF074_AFP_GROUP_MSTR_DOC_AFP_PAYM_GROUP":
                        fldF074_AFP_GROUP_MSTR_DOC_AFP_PAYM_GROUP = (TextBox)DataListField;

                        fldF074_AFP_GROUP_MSTR_DOC_AFP_PAYM_GROUP.LookupNotOn -= fldF074_AFP_GROUP_MSTR_DOC_AFP_PAYM_GROUP_LookupNotOn;
                        fldF074_AFP_GROUP_MSTR_DOC_AFP_PAYM_GROUP.LookupNotOn += fldF074_AFP_GROUP_MSTR_DOC_AFP_PAYM_GROUP_LookupNotOn;
                        CoreField = fldF074_AFP_GROUP_MSTR_DOC_AFP_PAYM_GROUP;
                        fldF074_AFP_GROUP_MSTR_DOC_AFP_PAYM_GROUP.Bind(fleF074_AFP_GROUP_MSTR);
                        break;
                    case "FLDGRDF074_AFP_GROUP_MSTR_AFP_GROUP_PROCESS_FLAG":
                        fldF074_AFP_GROUP_MSTR_AFP_GROUP_PROCESS_FLAG = (ComboBox)DataListField;
                        CoreField = fldF074_AFP_GROUP_MSTR_AFP_GROUP_PROCESS_FLAG;
                        fldF074_AFP_GROUP_MSTR_AFP_GROUP_PROCESS_FLAG.Edit -= fldF074_AFP_GROUP_MSTR_AFP_GROUP_PROCESS_FLAG_Edit;
                        fldF074_AFP_GROUP_MSTR_AFP_GROUP_PROCESS_FLAG.Edit += fldF074_AFP_GROUP_MSTR_AFP_GROUP_PROCESS_FLAG_Edit;
                        fldF074_AFP_GROUP_MSTR_AFP_GROUP_PROCESS_FLAG.Bind(fleF074_AFP_GROUP_MSTR);
                        break;
                    case "FLDGRDF074_AFP_GROUP_MSTR_BATCTRL_PAYROLL":
                        fldF074_AFP_GROUP_MSTR_BATCTRL_PAYROLL = (TextBox)DataListField;
                        CoreField = fldF074_AFP_GROUP_MSTR_BATCTRL_PAYROLL;
                        fldF074_AFP_GROUP_MSTR_BATCTRL_PAYROLL.Bind(fleF074_AFP_GROUP_MSTR);
                        break;
                    case "FLDGRDF074_AFP_GROUP_MSTR_AFP_REPORTING_MTH":
                        fldF074_AFP_GROUP_MSTR_AFP_REPORTING_MTH = (TextBox)DataListField;
                        CoreField = fldF074_AFP_GROUP_MSTR_AFP_REPORTING_MTH;
                        fldF074_AFP_GROUP_MSTR_AFP_REPORTING_MTH.Bind(fleF074_AFP_GROUP_MSTR);
                        break;
                    case "FLDGRDF074_AFP_GROUP_MSTR_AFP_MULTI_DOC_RA_PERCENTAGE":
                        fldF074_AFP_GROUP_MSTR_AFP_MULTI_DOC_RA_PERCENTAGE = (TextBox)DataListField;
                        CoreField = fldF074_AFP_GROUP_MSTR_AFP_MULTI_DOC_RA_PERCENTAGE;
                        fldF074_AFP_GROUP_MSTR_AFP_MULTI_DOC_RA_PERCENTAGE.Bind(fleF074_AFP_GROUP_MSTR);
                        break;
                    case "FLDGRDF074_AFP_GROUP_MSTR_AFP_PAYMENT_AMT":
                        fldF074_AFP_GROUP_MSTR_AFP_PAYMENT_AMT = (TextBox)DataListField;
                        CoreField = fldF074_AFP_GROUP_MSTR_AFP_PAYMENT_AMT;
                        fldF074_AFP_GROUP_MSTR_AFP_PAYMENT_AMT.Bind(fleF074_AFP_GROUP_MSTR);
                        break;
                    case "FLDGRDF074_AFP_GROUP_MSTR_AFP_PAYMENT_AMT_TOTAL":
                        fldF074_AFP_GROUP_MSTR_AFP_PAYMENT_AMT_TOTAL = (TextBox)DataListField;
                        CoreField = fldF074_AFP_GROUP_MSTR_AFP_PAYMENT_AMT_TOTAL;
                        fldF074_AFP_GROUP_MSTR_AFP_PAYMENT_AMT_TOTAL.Bind(fleF074_AFP_GROUP_MSTR);
                        break;
                    case "FLDGRDF074_AFP_GROUP_MSTR_AFP_GROUP_NAME":
                        fldF074_AFP_GROUP_MSTR_AFP_GROUP_NAME = (TextBox)DataListField;
                        CoreField = fldF074_AFP_GROUP_MSTR_AFP_GROUP_NAME;
                        fldF074_AFP_GROUP_MSTR_AFP_GROUP_NAME.Bind(fleF074_AFP_GROUP_MSTR);
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
                dtlF074_AFP_GROUP_MSTR.OccursWithFile = fleF074_AFP_GROUP_MSTR;

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
        //# Do not delete, modify or move it.  Updated: 8/29/2017 10:04:01 AM

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
            fleF074_AFP_GROUP_MSTR.Transaction = m_trnTRANS_UPDATE;


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 8/29/2017 10:04:01 AM

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
                fleF074_AFP_GROUP_MSTR.Dispose();


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
        //# Do not delete, modify or move it.  Updated: 8/29/2017 10:04:01 AM



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



        private void fldF074_AFP_GROUP_MSTR_DOC_AFP_PAYM_GROUP_LookupNotOn(ref bool LookupNotOnExecuted)
        {

            try
            {
                bool blnAlreadyExists = false;
                StringBuilder strSQL = new StringBuilder("SELECT ").Append(fleF074_AFP_GROUP_MSTR.ElementOwner("DOC_AFP_PAYM_GROUP"));
                strSQL.Append(" FROM ");
                strSQL.Append(fleF074_AFP_GROUP_MSTR.TableNameWithAlias());
                strSQL.Append(" WHERE ");
                strSQL.Append("     ").Append(fleF074_AFP_GROUP_MSTR.ElementOwner("DOC_AFP_PAYM_GROUP")).Append(" = ").Append(Common.StringToField(FieldText));

                if (!LookupNotOn(strSQL, fleF074_AFP_GROUP_MSTR, "DOC_AFP_PAYM_GROUP", FieldText))
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



        private void fldF074_AFP_GROUP_MSTR_AFP_GROUP_PROCESS_FLAG_Edit()
        {

            try
            {

                if (fleF074_AFP_GROUP_MSTR.NewRecord || QDesign.NULL(fleF074_AFP_GROUP_MSTR.GetStringValue("AFP_GROUP_PROCESS_FLAG")) != QDesign.NULL(OldValue(fleF074_AFP_GROUP_MSTR.ElementOwner("AFP_GROUP_PROCESS_FLAG"), fleF074_AFP_GROUP_MSTR.GetStringValue("AFP_GROUP_PROCESS_FLAG"))))
                {
                    Warning("Ensure you change the r140_reports script to reflect group of this clinic!");
                    // TODO: May need to fix manually
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
                switch (m_intPath)
                {
                    case 2:
                        m_strWhere = new StringBuilder(GetWhereCondition(fleF074_AFP_GROUP_MSTR.ElementOwner("AFP_GOVERNANCE_GROUP"), fleF074_AFP_GROUP_MSTR.GetStringValue("AFP_GOVERNANCE_GROUP"), ref blnAddWhere));
                        fleF074_AFP_GROUP_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
                        break;
                    case 1:
                        m_strWhere = new StringBuilder(GetWhereCondition(fleF074_AFP_GROUP_MSTR.ElementOwner("DOC_AFP_PAYM_GROUP"), fleF074_AFP_GROUP_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP"), ref blnAddWhere));
                        fleF074_AFP_GROUP_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
                        break;
                    default:
                        fleF074_AFP_GROUP_MSTR.GetData(GetDataOptions.Sequential | GetDataOptions.CreateSubSelect);
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

                RequestPrompt(ref fldF074_AFP_GROUP_MSTR_DOC_AFP_PAYM_GROUP);
                if (m_blnPromptOK)
                {
                    m_intPath = 1;
                }
                if (m_intPath == 0)
                {
                    RequestPrompt(ref fldF074_AFP_GROUP_MSTR_AFP_GOVERNANCE_GROUP);
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
                Page.PageTitle = "AFP Group Codes / Summary Last Month`s Calculations";



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
        //# Precompiler Ver.: 1.0.6407.16120  Generated on: 8/29/2017 8:52:03 AM
        //#-----------------------------------------
        protected override bool Append()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6407.16120 Generated on: 8/29/2017 8:52:03 AM
                Accept(ref fldF074_AFP_GROUP_MSTR_AFP_GOVERNANCE_GROUP);
                Accept(ref fldF074_AFP_GROUP_MSTR_DOC_AFP_PAYM_GROUP);
                Accept(ref fldF074_AFP_GROUP_MSTR_AFP_GROUP_PROCESS_FLAG);
                Accept(ref fldF074_AFP_GROUP_MSTR_BATCTRL_PAYROLL);
                Accept(ref fldF074_AFP_GROUP_MSTR_AFP_REPORTING_MTH);
                Accept(ref fldF074_AFP_GROUP_MSTR_AFP_MULTI_DOC_RA_PERCENTAGE);
                Accept(ref fldF074_AFP_GROUP_MSTR_AFP_PAYMENT_AMT);
                Accept(ref fldF074_AFP_GROUP_MSTR_AFP_PAYMENT_AMT_TOTAL);
                Accept(ref fldF074_AFP_GROUP_MSTR_AFP_GROUP_NAME);
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
        //# Precompiler Ver.: 1.0.6407.16120  Generated on: 8/29/2017 8:52:03 AM
        //#-----------------------------------------
        protected override bool Update()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6407.16120 Generated on: 8/29/2017 8:52:03 AM
                while (fleF074_AFP_GROUP_MSTR.For())
                {
                    fleF074_AFP_GROUP_MSTR.PutData(false, PutTypes.Deleted);
                }
                while (fleF074_AFP_GROUP_MSTR.For())
                {
                    fleF074_AFP_GROUP_MSTR.PutData();
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
        //# Precompiler Ver.: 1.0.6407.16120  Generated on: 8/29/2017 8:52:04 AM
        //#-----------------------------------------
        protected override bool Delete()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6407.16120 Generated on: 8/29/2017 8:52:04 AM
                fleF074_AFP_GROUP_MSTR.DeletedRecord = true;
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
        //# dtlF074_AFP_GROUP_MSTR_EditClick Procedure
        //# Precompiler Ver.: 1.0.6407.16120  Generated on: 8/29/2017 8:52:04 AM
        //#-----------------------------------------
        private void dtlF074_AFP_GROUP_MSTR_EditClick(DataList source, GridButtonEventArgs GridButtonEventArgs)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6407.16120 Generated on: 8/29/2017 10:04:01 AM
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
        //# Precompiler Ver.: 1.0.6407.16120  Generated on: 8/29/2017 8:52:04 AM
        //#-----------------------------------------
        private void dsrDesigner_01_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6407.16120 Generated on: 8/29/2017 10:04:01 AM
                Accept(ref fldF074_AFP_GROUP_MSTR_AFP_GOVERNANCE_GROUP);
                if (!fleF074_AFP_GROUP_MSTR.NewRecord)
                {
                    Display(ref fldF074_AFP_GROUP_MSTR_DOC_AFP_PAYM_GROUP);
                }
                else
                {
                    Accept(ref fldF074_AFP_GROUP_MSTR_DOC_AFP_PAYM_GROUP);
                }
                Accept(ref fldF074_AFP_GROUP_MSTR_AFP_GROUP_PROCESS_FLAG);
                Accept(ref fldF074_AFP_GROUP_MSTR_BATCTRL_PAYROLL);
                Accept(ref fldF074_AFP_GROUP_MSTR_AFP_REPORTING_MTH);
                Accept(ref fldF074_AFP_GROUP_MSTR_AFP_MULTI_DOC_RA_PERCENTAGE);
                Accept(ref fldF074_AFP_GROUP_MSTR_AFP_PAYMENT_AMT);
                Accept(ref fldF074_AFP_GROUP_MSTR_AFP_PAYMENT_AMT_TOTAL);
                Accept(ref fldF074_AFP_GROUP_MSTR_AFP_GROUP_NAME);
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

