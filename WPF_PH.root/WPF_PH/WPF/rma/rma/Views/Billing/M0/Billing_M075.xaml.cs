
#region "Screen Comments"

// 2005/03/07  M.C. substitute afp-payment-percentage with
// afp-multi-doc-ra-percentage

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

    partial class Billing_M075 : BasePage
    {

        #region " Form Designer Generated Code "





        public Billing_M075()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "M075";

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

            base.Page_Load();

            // TODO: If any DESIGNER procedures function on occurring FILES or TEMPORARIES, set the grid's AllowSelectRowButton property to TRUE.



        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            fleF075_AFP_DOC_MSTR = new SqlFileObject(this, FileTypes.Primary, 8, "INDEXED", "F075_AFP_DOC_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Reference, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_cnnQUERY");
            fleF074_AFP_GROUP_MSTR = new SqlFileObject(this, FileTypes.Reference, 0, "[101C].INDEXED", "F074_AFP_GROUP_MSTR", "", false, false, false, 0, "m_cnnQUERY");

            fleF020_DOCTOR_MSTR.Access += fleF020_DOCTOR_MSTR_Access;
            fleF074_AFP_GROUP_MSTR.Access += fleF074_AFP_GROUP_MSTR_Access;
            dtlF075_AFP_DOC_MSTR.EditClick += dtlF075_AFP_DOC_MSTR_EditClick;

        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;
            fleF020_DOCTOR_MSTR.Access -= fleF020_DOCTOR_MSTR_Access;
            fleF074_AFP_GROUP_MSTR.Access -= fleF074_AFP_GROUP_MSTR_Access;
            fldF075_AFP_DOC_MSTR_DOC_AFP_PAYM_GROUP.LookupOn -= fldF075_AFP_DOC_MSTR_DOC_AFP_PAYM_GROUP_LookupOn;
            fldF075_AFP_DOC_MSTR_DOC_NBR.LookupOn -= fldF075_AFP_DOC_MSTR_DOC_NBR_LookupOn;
            fldF075_AFP_DOC_MSTR_DOC_OHIP_NBR.LookupOn -= fldF075_AFP_DOC_MSTR_DOC_OHIP_NBR_LookupOn;
            dtlF075_AFP_DOC_MSTR.EditClick -= dtlF075_AFP_DOC_MSTR_EditClick;
            dsrDesigner_01.Click -= dsrDesigner_01_Click;


        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private SqlConnection m_cnnQUERY = new SqlConnection();
        private SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
        private SqlTransaction m_trnTRANS_UPDATE;
        private SqlFileObject fleF075_AFP_DOC_MSTR;
        private SqlFileObject fleF020_DOCTOR_MSTR;

        private void fleF020_DOCTOR_MSTR_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE  ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_OHIP_NBR")).Append(" = ").Append(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR"));


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

        private SqlFileObject fleF074_AFP_GROUP_MSTR;

        private void fleF074_AFP_GROUP_MSTR_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE  ").Append(fleF074_AFP_GROUP_MSTR.ElementOwner("DOC_AFP_PAYM_GROUP")).Append(" = ").Append(Common.StringToField(fleF074_AFP_GROUP_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP")));


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


        #endregion

        #region "Standard Generated Procedures"

        #region "Grid Field Declarations"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 8/29/2017 10:03:48 AM

        protected TextBox fldF075_AFP_DOC_MSTR_DOC_OHIP_NBR;
        protected TextBox fldF075_AFP_DOC_MSTR_DOC_NBR;
        protected TextBox fldF075_AFP_DOC_MSTR_DOC_AFP_PAYM_GROUP;
        protected TextBox fldF075_AFP_DOC_MSTR_AFP_DUPLICATE_DOC_COUNT;
        protected TextBox fldF075_AFP_DOC_MSTR_AFP_REPORTING_MTH;
        protected TextBox fldF075_AFP_DOC_MSTR_AFP_MULTI_DOC_RA_PERCENTAGE;
        protected TextBox fldF075_AFP_DOC_MSTR_RA_PAYMENT_AMT;
        protected TextBox fldF075_AFP_DOC_MSTR_RA_PAYMENT_AMT_TOTAL;
        protected TextBox fldF075_AFP_DOC_MSTR_AFP_SUBMISSION_AMT;
        protected TextBox fldF075_AFP_DOC_MSTR_AFP_PAYMENT_AMT;

        protected TextBox fldF075_AFP_DOC_MSTR_AFP_PAYMENT_AMT_TOTAL;

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 8/29/2017 10:03:48 AM

        //#-----------------------------------------
        //# GetGridFieldObject Procedure.
        //#-----------------------------------------

        protected override void GetGridFieldObject(object DataListField, ref object CoreField, string Name)
        {

            try
            {
                switch (Name.ToUpper())
                {
                    case "FLDGRDF075_AFP_DOC_MSTR_DOC_OHIP_NBR":
                        fldF075_AFP_DOC_MSTR_DOC_OHIP_NBR = (TextBox)DataListField;

                        fldF075_AFP_DOC_MSTR_DOC_OHIP_NBR.LookupOn -= fldF075_AFP_DOC_MSTR_DOC_OHIP_NBR_LookupOn;
                        fldF075_AFP_DOC_MSTR_DOC_OHIP_NBR.LookupOn += fldF075_AFP_DOC_MSTR_DOC_OHIP_NBR_LookupOn;
                        CoreField = fldF075_AFP_DOC_MSTR_DOC_OHIP_NBR;
                        fldF075_AFP_DOC_MSTR_DOC_OHIP_NBR.Bind(fleF075_AFP_DOC_MSTR);
                        break;
                    case "FLDGRDF075_AFP_DOC_MSTR_DOC_NBR":
                        fldF075_AFP_DOC_MSTR_DOC_NBR = (TextBox)DataListField;

                        fldF075_AFP_DOC_MSTR_DOC_NBR.LookupOn -= fldF075_AFP_DOC_MSTR_DOC_NBR_LookupOn;
                        fldF075_AFP_DOC_MSTR_DOC_NBR.LookupOn += fldF075_AFP_DOC_MSTR_DOC_NBR_LookupOn;
                        CoreField = fldF075_AFP_DOC_MSTR_DOC_NBR;
                        fldF075_AFP_DOC_MSTR_DOC_NBR.Bind(fleF075_AFP_DOC_MSTR);
                        break;
                    case "FLDGRDF075_AFP_DOC_MSTR_DOC_AFP_PAYM_GROUP":
                        fldF075_AFP_DOC_MSTR_DOC_AFP_PAYM_GROUP = (TextBox)DataListField;

                        fldF075_AFP_DOC_MSTR_DOC_AFP_PAYM_GROUP.LookupOn -= fldF075_AFP_DOC_MSTR_DOC_AFP_PAYM_GROUP_LookupOn;
                        fldF075_AFP_DOC_MSTR_DOC_AFP_PAYM_GROUP.LookupOn += fldF075_AFP_DOC_MSTR_DOC_AFP_PAYM_GROUP_LookupOn;
                        CoreField = fldF075_AFP_DOC_MSTR_DOC_AFP_PAYM_GROUP;
                        fldF075_AFP_DOC_MSTR_DOC_AFP_PAYM_GROUP.Bind(fleF075_AFP_DOC_MSTR);
                        break;
                    case "FLDGRDF075_AFP_DOC_MSTR_AFP_DUPLICATE_DOC_COUNT":
                        fldF075_AFP_DOC_MSTR_AFP_DUPLICATE_DOC_COUNT = (TextBox)DataListField;
                        CoreField = fldF075_AFP_DOC_MSTR_AFP_DUPLICATE_DOC_COUNT;
                        fldF075_AFP_DOC_MSTR_AFP_DUPLICATE_DOC_COUNT.Bind(fleF075_AFP_DOC_MSTR);
                        break;
                    case "FLDGRDF075_AFP_DOC_MSTR_AFP_REPORTING_MTH":
                        fldF075_AFP_DOC_MSTR_AFP_REPORTING_MTH = (TextBox)DataListField;
                        CoreField = fldF075_AFP_DOC_MSTR_AFP_REPORTING_MTH;
                        fldF075_AFP_DOC_MSTR_AFP_REPORTING_MTH.Bind(fleF075_AFP_DOC_MSTR);
                        break;
                    case "FLDGRDF075_AFP_DOC_MSTR_AFP_MULTI_DOC_RA_PERCENTAGE":
                        fldF075_AFP_DOC_MSTR_AFP_MULTI_DOC_RA_PERCENTAGE = (TextBox)DataListField;
                        CoreField = fldF075_AFP_DOC_MSTR_AFP_MULTI_DOC_RA_PERCENTAGE;
                        fldF075_AFP_DOC_MSTR_AFP_MULTI_DOC_RA_PERCENTAGE.Bind(fleF075_AFP_DOC_MSTR);
                        break;
                    case "FLDGRDF075_AFP_DOC_MSTR_RA_PAYMENT_AMT":
                        fldF075_AFP_DOC_MSTR_RA_PAYMENT_AMT = (TextBox)DataListField;
                        CoreField = fldF075_AFP_DOC_MSTR_RA_PAYMENT_AMT;
                        fldF075_AFP_DOC_MSTR_RA_PAYMENT_AMT.Bind(fleF075_AFP_DOC_MSTR);
                        break;
                    case "FLDGRDF075_AFP_DOC_MSTR_RA_PAYMENT_AMT_TOTAL":
                        fldF075_AFP_DOC_MSTR_RA_PAYMENT_AMT_TOTAL = (TextBox)DataListField;
                        CoreField = fldF075_AFP_DOC_MSTR_RA_PAYMENT_AMT_TOTAL;
                        fldF075_AFP_DOC_MSTR_RA_PAYMENT_AMT_TOTAL.Bind(fleF075_AFP_DOC_MSTR);
                        break;
                    case "FLDGRDF075_AFP_DOC_MSTR_AFP_SUBMISSION_AMT":
                        fldF075_AFP_DOC_MSTR_AFP_SUBMISSION_AMT = (TextBox)DataListField;
                        CoreField = fldF075_AFP_DOC_MSTR_AFP_SUBMISSION_AMT;
                        fldF075_AFP_DOC_MSTR_AFP_SUBMISSION_AMT.Bind(fleF075_AFP_DOC_MSTR);
                        break;
                    case "FLDGRDF075_AFP_DOC_MSTR_AFP_PAYMENT_AMT":
                        fldF075_AFP_DOC_MSTR_AFP_PAYMENT_AMT = (TextBox)DataListField;
                        CoreField = fldF075_AFP_DOC_MSTR_AFP_PAYMENT_AMT;
                        fldF075_AFP_DOC_MSTR_AFP_PAYMENT_AMT.Bind(fleF075_AFP_DOC_MSTR);
                        break;
                    case "FLDGRDF075_AFP_DOC_MSTR_AFP_PAYMENT_AMT_TOTAL":
                        fldF075_AFP_DOC_MSTR_AFP_PAYMENT_AMT_TOTAL = (TextBox)DataListField;
                        CoreField = fldF075_AFP_DOC_MSTR_AFP_PAYMENT_AMT_TOTAL;
                        fldF075_AFP_DOC_MSTR_AFP_PAYMENT_AMT_TOTAL.Bind(fleF075_AFP_DOC_MSTR);
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
                dtlF075_AFP_DOC_MSTR.OccursWithFile = fleF075_AFP_DOC_MSTR;

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
        //# Do not delete, modify or move it.  Updated: 8/29/2017 10:03:48 AM

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
            fleF075_AFP_DOC_MSTR.Transaction = m_trnTRANS_UPDATE;


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 8/29/2017 10:03:48 AM

        //#-----------------------------------------
        //# InitializeFiles Procedure.
        //#-----------------------------------------

        protected override void InitializeFiles()
        {

            try
            {
                Initialize_TRANS_UPDATE();
                fleF020_DOCTOR_MSTR.Connection = m_cnnQUERY;
                fleF074_AFP_GROUP_MSTR.Connection = m_cnnQUERY;


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
                fleF075_AFP_DOC_MSTR.Dispose();
                fleF020_DOCTOR_MSTR.Dispose();
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
        //# Do not delete, modify or move it.  Updated: 8/29/2017 10:03:48 AM



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



        private void fldF075_AFP_DOC_MSTR_DOC_AFP_PAYM_GROUP_LookupOn()
        {

            try
            {
                StringBuilder strSQL = new StringBuilder(" WHERE ");
                strSQL.Append("     ").Append(fleF074_AFP_GROUP_MSTR.ElementOwner("DOC_AFP_PAYM_GROUP")).Append(" = ").Append(Common.StringToField(FieldText));

                fleF074_AFP_GROUP_MSTR.GetData(strSQL.ToString(), GetDataOptions.IsOptional);
                if (!AccessOk)
                {
                    ErrorMessage("Record not found in lookup table ({0}).");
                    // Record not found on lookup table.
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




        private void fldF075_AFP_DOC_MSTR_DOC_NBR_LookupOn()
        {

            try
            {
                StringBuilder strSQL = new StringBuilder(" WHERE ");
                strSQL.Append("     ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ").Append(Common.StringToField(FieldText));

                fleF020_DOCTOR_MSTR.GetData(strSQL.ToString(), GetDataOptions.IsOptional);
                if (!AccessOk)
                {
                    ErrorMessage("Record not found in lookup table ({0}).");
                    // Record not found on lookup table.
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




        private void fldF075_AFP_DOC_MSTR_DOC_OHIP_NBR_LookupOn()
        {

            try
            {
                StringBuilder strSQL = new StringBuilder(" WHERE ");
                strSQL.Append("     ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_OHIP_NBR")).Append(" = ").Append((FieldText));

                fleF020_DOCTOR_MSTR.GetData(strSQL.ToString(), GetDataOptions.IsOptional);
                if (!AccessOk)
                {
                    ErrorMessage("Record not found in lookup table ({0}).");
                    // Record not found on lookup table.
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
                        m_strWhere = new StringBuilder(GetWhereCondition(fleF075_AFP_DOC_MSTR.ElementOwner("DOC_OHIP_NBR"), fleF075_AFP_DOC_MSTR.GetDecimalValue("DOC_OHIP_NBR"), ref blnAddWhere));
                        fleF075_AFP_DOC_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
                        break;
                    case 2:
                        m_strWhere = new StringBuilder(GetWhereCondition(fleF075_AFP_DOC_MSTR.ElementOwner("DOC_OHIP_NBR"), fleF075_AFP_DOC_MSTR.GetDecimalValue("DOC_OHIP_NBR"), ref blnAddWhere));
                        m_strWhere.Append(GetWhereCondition(fleF075_AFP_DOC_MSTR.ElementOwner("DOC_NBR"), fleF075_AFP_DOC_MSTR.GetStringValue("DOC_NBR"), ref blnAddWhere));
                        fleF075_AFP_DOC_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
                        break;
                    case 3:
                        m_strWhere = new StringBuilder(GetWhereCondition(fleF075_AFP_DOC_MSTR.ElementOwner("DOC_OHIP_NBR"), fleF075_AFP_DOC_MSTR.GetDecimalValue("DOC_OHIP_NBR"), ref blnAddWhere));
                        m_strWhere.Append(GetWhereCondition(fleF075_AFP_DOC_MSTR.ElementOwner("DOC_NBR"), fleF075_AFP_DOC_MSTR.GetStringValue("DOC_NBR"), ref blnAddWhere));
                        m_strWhere.Append(GetWhereCondition(fleF075_AFP_DOC_MSTR.ElementOwner("DOC_AFP_PAYM_GROUP"), fleF075_AFP_DOC_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP"), ref blnAddWhere));
                        fleF075_AFP_DOC_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
                        break;
                    case 4:
                        m_strWhere = new StringBuilder(GetWhereCondition(fleF075_AFP_DOC_MSTR.ElementOwner("DOC_NBR"), fleF075_AFP_DOC_MSTR.GetStringValue("DOC_NBR"), ref blnAddWhere));
                        fleF075_AFP_DOC_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
                        break;
                    case 5:
                        m_strWhere = new StringBuilder(GetWhereCondition(fleF075_AFP_DOC_MSTR.ElementOwner("DOC_NBR"), fleF075_AFP_DOC_MSTR.GetStringValue("DOC_NBR"), ref blnAddWhere));
                        m_strWhere.Append(GetWhereCondition(fleF075_AFP_DOC_MSTR.ElementOwner("DOC_AFP_PAYM_GROUP"), fleF075_AFP_DOC_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP"), ref blnAddWhere));
                        fleF075_AFP_DOC_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
                        break;
                    default:
                        fleF075_AFP_DOC_MSTR.GetData(GetDataOptions.Sequential | GetDataOptions.CreateSubSelect);
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

                RequestPrompt(ref fldF075_AFP_DOC_MSTR_DOC_OHIP_NBR);
                if (m_blnPromptOK)
                {
                    m_intPath = 1;
                    RequestPrompt(ref fldF075_AFP_DOC_MSTR_DOC_NBR);
                    if (m_blnPromptOK)
                    {
                        m_intPath = 2;
                        RequestPrompt(ref fldF075_AFP_DOC_MSTR_DOC_AFP_PAYM_GROUP);
                        if (m_blnPromptOK)
                        {
                            m_intPath = 3;
                        }
                    }
                }
                if (m_intPath == 0)
                {
                    RequestPrompt(ref fldF075_AFP_DOC_MSTR_DOC_NBR);
                    if (m_blnPromptOK)
                    {
                        m_intPath = 4;
                        RequestPrompt(ref fldF075_AFP_DOC_MSTR_DOC_AFP_PAYM_GROUP);
                        if (m_blnPromptOK)
                        {
                            m_intPath = 5;
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




        public override void PagePostProcess(PageArgs e)
        {

            try
            {
                Page.PageTitle = "AFP Percentage Payments - Multiple Doctor Nbr";



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
        //# Precompiler Ver.: 1.0.6407.16120  Generated on: 8/29/2017 9:29:56 AM
        //#-----------------------------------------
        protected override bool Append()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6407.16120 Generated on: 8/29/2017 9:29:56 AM
                Accept(ref fldF075_AFP_DOC_MSTR_DOC_OHIP_NBR);
                Accept(ref fldF075_AFP_DOC_MSTR_DOC_NBR);
                Accept(ref fldF075_AFP_DOC_MSTR_DOC_AFP_PAYM_GROUP);
                Accept(ref fldF075_AFP_DOC_MSTR_AFP_DUPLICATE_DOC_COUNT);
                Accept(ref fldF075_AFP_DOC_MSTR_AFP_REPORTING_MTH);
                Accept(ref fldF075_AFP_DOC_MSTR_AFP_MULTI_DOC_RA_PERCENTAGE);
                Accept(ref fldF075_AFP_DOC_MSTR_RA_PAYMENT_AMT);
                Accept(ref fldF075_AFP_DOC_MSTR_RA_PAYMENT_AMT_TOTAL);
                Accept(ref fldF075_AFP_DOC_MSTR_AFP_SUBMISSION_AMT);
                Accept(ref fldF075_AFP_DOC_MSTR_AFP_PAYMENT_AMT);
                Accept(ref fldF075_AFP_DOC_MSTR_AFP_PAYMENT_AMT_TOTAL);
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
        //# Precompiler Ver.: 1.0.6407.16120  Generated on: 8/29/2017 9:29:56 AM
        //#-----------------------------------------
        protected override bool Update()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6407.16120 Generated on: 8/29/2017 9:29:56 AM
                while (fleF075_AFP_DOC_MSTR.For())
                {
                    fleF075_AFP_DOC_MSTR.PutData(false, PutTypes.Deleted);
                }
                while (fleF075_AFP_DOC_MSTR.For())
                {
                    fleF075_AFP_DOC_MSTR.PutData();
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
        //# Precompiler Ver.: 1.0.6407.16120  Generated on: 8/29/2017 9:29:56 AM
        //#-----------------------------------------
        protected override bool Delete()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6407.16120 Generated on: 8/29/2017 9:29:56 AM
                fleF075_AFP_DOC_MSTR.DeletedRecord = true;
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
        //# dtlF075_AFP_DOC_MSTR_EditClick Procedure
        //# Precompiler Ver.: 1.0.6407.16120  Generated on: 8/29/2017 9:29:56 AM
        //#-----------------------------------------
        private void dtlF075_AFP_DOC_MSTR_EditClick(DataList source, GridButtonEventArgs GridButtonEventArgs)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6407.16120 Generated on: 8/29/2017 10:03:48 AM
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
        //# Precompiler Ver.: 1.0.6407.16120  Generated on: 8/29/2017 9:29:56 AM
        //#-----------------------------------------
        private void dsrDesigner_01_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6407.16120 Generated on: 8/29/2017 10:03:48 AM
                if (!fleF075_AFP_DOC_MSTR.NewRecord)
                {
                    Display(ref fldF075_AFP_DOC_MSTR_DOC_OHIP_NBR);
                }
                else
                {
                    Accept(ref fldF075_AFP_DOC_MSTR_DOC_OHIP_NBR);
                }
                if (!fleF075_AFP_DOC_MSTR.NewRecord)
                {
                    Display(ref fldF075_AFP_DOC_MSTR_DOC_NBR);
                }
                else
                {
                    Accept(ref fldF075_AFP_DOC_MSTR_DOC_NBR);
                }
                if (!fleF075_AFP_DOC_MSTR.NewRecord)
                {
                    Display(ref fldF075_AFP_DOC_MSTR_DOC_AFP_PAYM_GROUP);
                }
                else
                {
                    Accept(ref fldF075_AFP_DOC_MSTR_DOC_AFP_PAYM_GROUP);
                }
                if (!fleF075_AFP_DOC_MSTR.NewRecord)
                {
                    Display(ref fldF075_AFP_DOC_MSTR_AFP_DUPLICATE_DOC_COUNT);
                }
                else
                {
                    Accept(ref fldF075_AFP_DOC_MSTR_AFP_DUPLICATE_DOC_COUNT);
                }
                Accept(ref fldF075_AFP_DOC_MSTR_AFP_REPORTING_MTH);
                Accept(ref fldF075_AFP_DOC_MSTR_AFP_MULTI_DOC_RA_PERCENTAGE);
                Accept(ref fldF075_AFP_DOC_MSTR_RA_PAYMENT_AMT);
                Accept(ref fldF075_AFP_DOC_MSTR_RA_PAYMENT_AMT_TOTAL);
                Accept(ref fldF075_AFP_DOC_MSTR_AFP_SUBMISSION_AMT);
                Accept(ref fldF075_AFP_DOC_MSTR_AFP_PAYMENT_AMT);
                Accept(ref fldF075_AFP_DOC_MSTR_AFP_PAYMENT_AMT_TOTAL);
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

