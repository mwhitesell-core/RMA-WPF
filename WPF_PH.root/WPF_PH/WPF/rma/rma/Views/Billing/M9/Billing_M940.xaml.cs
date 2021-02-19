
#region "Screen Comments"

// 94/AUG/03 M.CHAN  - SMS 146 (ORIGINAL)
// - SOCIAL CONTRACT FACTOR RANGES FOR
// EACH CLINIC
// 1999/Apr/23   S.Bachmann - Y2K changes. (recompiled)

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

    partial class Billing_M940 : BasePage
    {

        #region " Form Designer Generated Code "





        public Billing_M940()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "M940";

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
            dtlSOCIAL_CONTRACT_FACTOR.EditClick += dtlSOCIAL_CONTRACT_FACTOR_EditClick;
            base.Page_Load();

            // TODO: If any DESIGNER procedures function on occurring FILES or TEMPORARIES, set the grid's AllowSelectRowButton property to TRUE.



        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            fleSOCIAL_CONTRACT_FACTOR = new SqlFileObject(this, FileTypes.Primary, 15, "INDEXED", "SOCIAL_CONTRACT_FACTOR", "", false, false, false, 0, "m_trnTRANS_UPDATE");


        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;
            fldSOCIAL_CONTRACT_FACTOR_CONST_SERV_DATE_TO.Edit -= fldSOCIAL_CONTRACT_FACTOR_CONST_SERV_DATE_TO_Edit;

            dsrDesigner_01.Click -= dsrDesigner_01_Click;
            dtlSOCIAL_CONTRACT_FACTOR.EditClick -= dtlSOCIAL_CONTRACT_FACTOR_EditClick;

        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private SqlConnection m_cnnQUERY = new SqlConnection();
        private SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
        private SqlTransaction m_trnTRANS_UPDATE;
        private SqlFileObject fleSOCIAL_CONTRACT_FACTOR;
        #endregion

        #region "Standard Generated Procedures"

        #region "Grid Field Declarations"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:16:51 AM

        protected TextBox fldSOCIAL_CONTRACT_FACTOR_CONST_REC_NBR;
        protected DateControl fldSOCIAL_CONTRACT_FACTOR_CONST_SERV_DATE_FROM;
        private DateControl fldSOCIAL_CONTRACT_FACTOR_CONST_SERV_DATE_TO;
        protected TextBox fldSOCIAL_CONTRACT_FACTOR_CONST_REDUCTION_FACTOR;

        protected TextBox fldSOCIAL_CONTRACT_FACTOR_CONST_OVERPAY_FACTOR;

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:16:51 AM

        //#-----------------------------------------
        //# GetGridFieldObject Procedure.
        //#-----------------------------------------

        protected override void GetGridFieldObject(object DataListField, ref object CoreField, string Name)
        {

            try
            {
                switch (Name.ToUpper())
                {
                    case "FLDGRDSOCIAL_CONTRACT_FACTOR_CONST_REC_NBR":
                        fldSOCIAL_CONTRACT_FACTOR_CONST_REC_NBR = (TextBox)DataListField;
                        CoreField = fldSOCIAL_CONTRACT_FACTOR_CONST_REC_NBR;
                        fldSOCIAL_CONTRACT_FACTOR_CONST_REC_NBR.Bind(fleSOCIAL_CONTRACT_FACTOR);
                        break;
                    case "FLDGRDSOCIAL_CONTRACT_FACTOR_CONST_SERV_DATE_FROM":
                        fldSOCIAL_CONTRACT_FACTOR_CONST_SERV_DATE_FROM = (DateControl)DataListField;
                        CoreField = fldSOCIAL_CONTRACT_FACTOR_CONST_SERV_DATE_FROM;
                        fldSOCIAL_CONTRACT_FACTOR_CONST_SERV_DATE_FROM.Bind(fleSOCIAL_CONTRACT_FACTOR);
                        break;
                    case "FLDGRDSOCIAL_CONTRACT_FACTOR_CONST_SERV_DATE_TO":
                        fldSOCIAL_CONTRACT_FACTOR_CONST_SERV_DATE_TO = (DateControl)DataListField;
                        CoreField = fldSOCIAL_CONTRACT_FACTOR_CONST_SERV_DATE_TO;
                        fldSOCIAL_CONTRACT_FACTOR_CONST_SERV_DATE_TO.Edit -= fldSOCIAL_CONTRACT_FACTOR_CONST_SERV_DATE_TO_Edit;
                        fldSOCIAL_CONTRACT_FACTOR_CONST_SERV_DATE_TO.Edit += fldSOCIAL_CONTRACT_FACTOR_CONST_SERV_DATE_TO_Edit;

                        fldSOCIAL_CONTRACT_FACTOR_CONST_SERV_DATE_TO.Bind(fleSOCIAL_CONTRACT_FACTOR);
                        break;
                    case "FLDGRDSOCIAL_CONTRACT_FACTOR_CONST_REDUCTION_FACTOR":
                        fldSOCIAL_CONTRACT_FACTOR_CONST_REDUCTION_FACTOR = (TextBox)DataListField;
                        CoreField = fldSOCIAL_CONTRACT_FACTOR_CONST_REDUCTION_FACTOR;
                        fldSOCIAL_CONTRACT_FACTOR_CONST_REDUCTION_FACTOR.Bind(fleSOCIAL_CONTRACT_FACTOR);
                        break;
                    case "FLDGRDSOCIAL_CONTRACT_FACTOR_CONST_OVERPAY_FACTOR":
                        fldSOCIAL_CONTRACT_FACTOR_CONST_OVERPAY_FACTOR = (TextBox)DataListField;
                        CoreField = fldSOCIAL_CONTRACT_FACTOR_CONST_OVERPAY_FACTOR;
                        fldSOCIAL_CONTRACT_FACTOR_CONST_OVERPAY_FACTOR.Bind(fleSOCIAL_CONTRACT_FACTOR);
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
                dtlSOCIAL_CONTRACT_FACTOR.OccursWithFile = fleSOCIAL_CONTRACT_FACTOR;

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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:16:51 AM

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
            fleSOCIAL_CONTRACT_FACTOR.Transaction = m_trnTRANS_UPDATE;


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:16:51 AM

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
                fleSOCIAL_CONTRACT_FACTOR.Dispose();


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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:16:51 AM



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



        private void fldSOCIAL_CONTRACT_FACTOR_CONST_SERV_DATE_TO_Edit()
        {

            try
            {

                if (QDesign.NULL(fleSOCIAL_CONTRACT_FACTOR.GetNumericDateValue("CONST_SERV_DATE_TO")) < QDesign.NULL(fleSOCIAL_CONTRACT_FACTOR.GetNumericDateValue("CONST_SERV_DATE_FROM")))
                {
                    ErrorMessage("SERVICE DATE TO CANNOT BE EARLIER THAN SERVICE DATE FROM\a");
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

                    case 1:
                        m_strWhere = new StringBuilder(GetWhereCondition(fleSOCIAL_CONTRACT_FACTOR.ElementOwner("CONST_REC_NBR"), fleSOCIAL_CONTRACT_FACTOR.GetDecimalValue("CONST_REC_NBR"), ref blnAddWhere));
                        m_strOrderBy = new StringBuilder("ORDER BY ");
                        m_strOrderBy.Append(fleSOCIAL_CONTRACT_FACTOR.ElementOwner("CONST_REC_NBR"));
                        fleSOCIAL_CONTRACT_FACTOR.GetData(m_strWhere.ToString(), m_strOrderBy.ToString(), GetDataOptions.CreateSubSelect);
                        break;
                    default:
                        m_strOrderBy = new StringBuilder("ORDER BY ");
                        m_strOrderBy.Append(fleSOCIAL_CONTRACT_FACTOR.ElementOwner("CONST_REC_NBR"));
                        fleSOCIAL_CONTRACT_FACTOR.GetData("", m_strOrderBy.ToString(), GetDataOptions.Sequential | GetDataOptions.CreateSubSelect);
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

                RequestPrompt(ref fldSOCIAL_CONTRACT_FACTOR_CONST_REC_NBR);
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
                Page.PageTitle = "SOCIAL CONTRACT FACTOR RANGES";



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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:16:51 AM
        //#-----------------------------------------
        protected override bool Append()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:16:51 AM
                Accept(ref fldSOCIAL_CONTRACT_FACTOR_CONST_REC_NBR);
                Accept(ref fldSOCIAL_CONTRACT_FACTOR_CONST_SERV_DATE_FROM);
                Accept(ref fldSOCIAL_CONTRACT_FACTOR_CONST_SERV_DATE_TO);
                Accept(ref fldSOCIAL_CONTRACT_FACTOR_CONST_REDUCTION_FACTOR);
                Accept(ref fldSOCIAL_CONTRACT_FACTOR_CONST_OVERPAY_FACTOR);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:16:51 AM
        //#-----------------------------------------
        protected override bool Update()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:16:51 AM
                while (fleSOCIAL_CONTRACT_FACTOR.For())
                {
                    fleSOCIAL_CONTRACT_FACTOR.PutData(false, PutTypes.Deleted);
                }
                while (fleSOCIAL_CONTRACT_FACTOR.For())
                {
                    fleSOCIAL_CONTRACT_FACTOR.PutData();
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:16:51 AM
        //#-----------------------------------------
        protected override bool Delete()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:16:51 AM
                fleSOCIAL_CONTRACT_FACTOR.DeletedRecord = true;
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
        //# dtlSOCIAL_CONTRACT_FACTOR_EditClick Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:16:51 AM
        //#-----------------------------------------
        private void dtlSOCIAL_CONTRACT_FACTOR_EditClick(DataList source, GridButtonEventArgs GridButtonEventArgs)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:16:51 AM
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:16:51 AM
        //#-----------------------------------------
        private void dsrDesigner_01_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:16:51 AM
                if (!fleSOCIAL_CONTRACT_FACTOR.NewRecord)
                {
                    Display(ref fldSOCIAL_CONTRACT_FACTOR_CONST_REC_NBR);
                }
                else
                {
                    Accept(ref fldSOCIAL_CONTRACT_FACTOR_CONST_REC_NBR);
                }
                Accept(ref fldSOCIAL_CONTRACT_FACTOR_CONST_SERV_DATE_FROM);
                Accept(ref fldSOCIAL_CONTRACT_FACTOR_CONST_SERV_DATE_TO);
                Accept(ref fldSOCIAL_CONTRACT_FACTOR_CONST_REDUCTION_FACTOR);
                Accept(ref fldSOCIAL_CONTRACT_FACTOR_CONST_OVERPAY_FACTOR);
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
