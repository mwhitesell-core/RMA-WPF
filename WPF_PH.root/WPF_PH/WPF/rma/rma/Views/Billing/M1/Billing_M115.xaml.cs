
#region "Screen Comments"

// #> PROGRAM-ID.     m115.qks
// ((C)) Dyad Technologies
// PROGRAM PURPOSE : maintenance of f115-dept-expense-calc-codes               
// MODIFICATION HISTORY
// DATE   WHO DESCRIPTION
// 2008/jun/04 M.C. - original

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

    partial class Billing_M115 : BasePage
    {

        #region " Form Designer Generated Code "





        public Billing_M115()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "M115";

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
            dtlF115_DEPT_EXPENSE_CALC_CODES.EditClick += dtlF115_DEPT_EXPENSE_CALC_CODES_EditClick;
            base.Page_Load();

            // TODO: If any DESIGNER procedures function on occurring FILES or TEMPORARIES, set the grid's AllowSelectRowButton property to TRUE.



        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            fleF115_DEPT_EXPENSE_CALC_CODES = new SqlFileObject(this, FileTypes.Primary, 15, "[101C].INDEXED", "F115_DEPT_EXPENSE_CALC_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");
           

        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;
            fldF115_DEPT_EXPENSE_CALC_CODES_DEPT_EXPENSE_CALC_CODE.LookupNotOn -= fldF115_DEPT_EXPENSE_CALC_CODES_DEPT_EXPENSE_CALC_CODE_LookupNotOn;
            dtlF115_DEPT_EXPENSE_CALC_CODES.EditClick -= dtlF115_DEPT_EXPENSE_CALC_CODES_EditClick;
            dsrDesigner_01.Click -= dsrDesigner_01_Click;


        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private SqlConnection m_cnnQUERY = new SqlConnection();
        private SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
        private SqlTransaction m_trnTRANS_UPDATE;
        private SqlFileObject fleF115_DEPT_EXPENSE_CALC_CODES;
        #endregion

        #region "Standard Generated Procedures"

        #region "Grid Field Declarations"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 7/10/2017 3:57:48 PM

        protected TextBox fldF115_DEPT_EXPENSE_CALC_CODES_DEPT_EXPENSE_CALC_CODE;

        protected TextBox fldF115_DEPT_EXPENSE_CALC_CODES_DEPT_EXPENSE_CALC_CODE_DESC;

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 7/10/2017 3:57:48 PM

        //#-----------------------------------------
        //# GetGridFieldObject Procedure.
        //#-----------------------------------------

        protected override void GetGridFieldObject(object DataListField, ref object CoreField, string Name)
        {

            try
            {
                switch (Name.ToUpper())
                {
                    case "FLDGRDF115_DEPT_EXPENSE_CALC_CODES_DEPT_EXPENSE_CALC_CODE":
                        fldF115_DEPT_EXPENSE_CALC_CODES_DEPT_EXPENSE_CALC_CODE = (TextBox)DataListField;

                        fldF115_DEPT_EXPENSE_CALC_CODES_DEPT_EXPENSE_CALC_CODE.LookupNotOn -= fldF115_DEPT_EXPENSE_CALC_CODES_DEPT_EXPENSE_CALC_CODE_LookupNotOn;
                        fldF115_DEPT_EXPENSE_CALC_CODES_DEPT_EXPENSE_CALC_CODE.LookupNotOn += fldF115_DEPT_EXPENSE_CALC_CODES_DEPT_EXPENSE_CALC_CODE_LookupNotOn;
                        CoreField = fldF115_DEPT_EXPENSE_CALC_CODES_DEPT_EXPENSE_CALC_CODE;
                        fldF115_DEPT_EXPENSE_CALC_CODES_DEPT_EXPENSE_CALC_CODE.Bind(fleF115_DEPT_EXPENSE_CALC_CODES);
                        break;
                    case "FLDGRDF115_DEPT_EXPENSE_CALC_CODES_DEPT_EXPENSE_CALC_CODE_DESC":
                        fldF115_DEPT_EXPENSE_CALC_CODES_DEPT_EXPENSE_CALC_CODE_DESC = (TextBox)DataListField;
                        CoreField = fldF115_DEPT_EXPENSE_CALC_CODES_DEPT_EXPENSE_CALC_CODE_DESC;
                        fldF115_DEPT_EXPENSE_CALC_CODES_DEPT_EXPENSE_CALC_CODE_DESC.Bind(fleF115_DEPT_EXPENSE_CALC_CODES);
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
                dtlF115_DEPT_EXPENSE_CALC_CODES.OccursWithFile = fleF115_DEPT_EXPENSE_CALC_CODES;

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
        //# Do not delete, modify or move it.  Updated: 7/10/2017 3:57:48 PM

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
            fleF115_DEPT_EXPENSE_CALC_CODES.Transaction = m_trnTRANS_UPDATE;


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 7/10/2017 3:57:48 PM

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
                fleF115_DEPT_EXPENSE_CALC_CODES.Dispose();


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
        //# Do not delete, modify or move it.  Updated: 7/10/2017 3:57:48 PM



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



        private void fldF115_DEPT_EXPENSE_CALC_CODES_DEPT_EXPENSE_CALC_CODE_LookupNotOn(ref bool LookupNotOnExecuted)
        {

            try
            {
                bool blnAlreadyExists = false;
                StringBuilder strSQL = new StringBuilder("SELECT ").Append(fleF115_DEPT_EXPENSE_CALC_CODES.ElementOwner("DEPT_EXPENSE_CALC_CODE"));
                strSQL.Append(" FROM ");
                strSQL.Append(fleF115_DEPT_EXPENSE_CALC_CODES.TableNameWithAlias());
                strSQL.Append(" WHERE ");
                strSQL.Append("     ").Append(fleF115_DEPT_EXPENSE_CALC_CODES.ElementOwner("DEPT_EXPENSE_CALC_CODE")).Append(" = ").Append(Common.StringToField(FieldText));

                if (!LookupNotOn(strSQL, fleF115_DEPT_EXPENSE_CALC_CODES, "DEPT_EXPENSE_CALC_CODE", FieldText))
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
                        m_strWhere = new StringBuilder(GetWhereCondition(fleF115_DEPT_EXPENSE_CALC_CODES.ElementOwner("DEPT_EXPENSE_CALC_CODE"), fleF115_DEPT_EXPENSE_CALC_CODES.GetStringValue("DEPT_EXPENSE_CALC_CODE"), ref blnAddWhere));
                        fleF115_DEPT_EXPENSE_CALC_CODES.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
                        break;
                    default:
                        fleF115_DEPT_EXPENSE_CALC_CODES.GetData(GetDataOptions.Sequential | GetDataOptions.CreateSubSelect);
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

                RequestPrompt(ref fldF115_DEPT_EXPENSE_CALC_CODES_DEPT_EXPENSE_CALC_CODE);
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
                Page.PageTitle = "Dept Expense Calc Codes";



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
        //# Precompiler Ver.: 1.0.6387.27217  Generated on: 7/10/2017 3:57:48 PM
        //#-----------------------------------------
        protected override bool Append()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6387.27217 Generated on: 7/10/2017 3:57:48 PM
                Accept(ref fldF115_DEPT_EXPENSE_CALC_CODES_DEPT_EXPENSE_CALC_CODE);
                Accept(ref fldF115_DEPT_EXPENSE_CALC_CODES_DEPT_EXPENSE_CALC_CODE_DESC);
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
        //# Precompiler Ver.: 1.0.6387.27217  Generated on: 7/10/2017 3:57:48 PM
        //#-----------------------------------------
        protected override bool Update()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6387.27217 Generated on: 7/10/2017 3:57:48 PM
                while (fleF115_DEPT_EXPENSE_CALC_CODES.For())
                {
                    fleF115_DEPT_EXPENSE_CALC_CODES.PutData(false, PutTypes.Deleted);
                }
                while (fleF115_DEPT_EXPENSE_CALC_CODES.For())
                {
                    fleF115_DEPT_EXPENSE_CALC_CODES.PutData();
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
        //# Precompiler Ver.: 1.0.6387.27217  Generated on: 7/10/2017 3:57:48 PM
        //#-----------------------------------------
        protected override bool Delete()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6387.27217 Generated on: 7/10/2017 3:57:48 PM
                fleF115_DEPT_EXPENSE_CALC_CODES.DeletedRecord = true;
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
        //# dtlF115_DEPT_EXPENSE_CALC_CODES_EditClick Procedure
        //# Precompiler Ver.: 1.0.6387.27217  Generated on: 7/10/2017 3:57:48 PM
        //#-----------------------------------------
        private void dtlF115_DEPT_EXPENSE_CALC_CODES_EditClick(DataList source, GridButtonEventArgs GridButtonEventArgs)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6387.27217 Generated on: 7/10/2017 3:57:48 PM
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
        //# Precompiler Ver.: 1.0.6387.27217  Generated on: 7/10/2017 3:57:48 PM
        //#-----------------------------------------
        private void dsrDesigner_01_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6387.27217 Generated on: 7/10/2017 3:57:48 PM
                if (!fleF115_DEPT_EXPENSE_CALC_CODES.NewRecord)
                {
                    Display(ref fldF115_DEPT_EXPENSE_CALC_CODES_DEPT_EXPENSE_CALC_CODE);
                }
                else
                {
                    Accept(ref fldF115_DEPT_EXPENSE_CALC_CODES_DEPT_EXPENSE_CALC_CODE);
                }
                Accept(ref fldF115_DEPT_EXPENSE_CALC_CODES_DEPT_EXPENSE_CALC_CODE_DESC);
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

