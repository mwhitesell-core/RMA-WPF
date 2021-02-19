
#region "Screen Comments"

// 2013/Oct/07 MC1  - include the new field process-agent-n-flag where n= 0 to 9

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

    partial class Billing_M200 : BasePage
    {

        #region " Form Designer Generated Code "





        public Billing_M200()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "M200";

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
            fldF200_OSCAR_PROVIDER_OSCAR_PROVIDER_NO.LookupNotOn += fldF200_OSCAR_PROVIDER_OSCAR_PROVIDER_NO_LookupNotOn;
            dtlF200C_OSCAR_PROVIDER_NEXT_BATCH_NBR.EditClick += dtlF200C_OSCAR_PROVIDER_NEXT_BATCH_NBR_EditClick;
            base.Page_Load();



        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            fleF200_OSCAR_PROVIDER = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F200_OSCAR_PROVIDER", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF200C_OSCAR_PROVIDER_NEXT_BATCH_NBR = new SqlFileObject(this, FileTypes.Detail, 6, "INDEXED", "F200C_OSCAR_PROVIDER_NEXT_BATCH_NBR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF200C_OSCAR_PROVIDER_NEXT_BATCH_NBR.Access += fleF200C_OSCAR_PROVIDER_NEXT_BATCH_NBR_Access;
            fleF200C_OSCAR_PROVIDER_NEXT_BATCH_NBR.InitializeItems += fleF200C_OSCAR_PROVIDER_NEXT_BATCH_NBR_InitializeItems;
            dsrDesigner_100.Click += DsrDesigner_100_Click;

        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;
            fldF200_OSCAR_PROVIDER_OSCAR_PROVIDER_NO.LookupNotOn -= fldF200_OSCAR_PROVIDER_OSCAR_PROVIDER_NO_LookupNotOn;
            dtlF200C_OSCAR_PROVIDER_NEXT_BATCH_NBR.EditClick -= dtlF200C_OSCAR_PROVIDER_NEXT_BATCH_NBR_EditClick;
            fleF200C_OSCAR_PROVIDER_NEXT_BATCH_NBR.Access -= fleF200C_OSCAR_PROVIDER_NEXT_BATCH_NBR_Access;
            fleF200C_OSCAR_PROVIDER_NEXT_BATCH_NBR.InitializeItems -= fleF200C_OSCAR_PROVIDER_NEXT_BATCH_NBR_InitializeItems;
            dsrDesigner_100.Click += DsrDesigner_100_Click;

        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private SqlConnection m_cnnQUERY = new SqlConnection();
        private SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
        private SqlTransaction m_trnTRANS_UPDATE;
        private SqlFileObject fleF200_OSCAR_PROVIDER;
        private SqlFileObject fleF200C_OSCAR_PROVIDER_NEXT_BATCH_NBR;

        private void fleF200C_OSCAR_PROVIDER_NEXT_BATCH_NBR_InitializeItems(bool Fixed)
        {
            try
            {
                fleF200C_OSCAR_PROVIDER_NEXT_BATCH_NBR.set_SetValue("OSCAR_PROVIDER_NO", true, fleF200_OSCAR_PROVIDER.GetStringValue("OSCAR_PROVIDER_NO"));
                fleF200C_OSCAR_PROVIDER_NEXT_BATCH_NBR.set_SetValue("DOC_NBR", true, fleF200_OSCAR_PROVIDER.GetStringValue("DOC_NBR"));

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

        private void fleF200C_OSCAR_PROVIDER_NEXT_BATCH_NBR_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleF200C_OSCAR_PROVIDER_NEXT_BATCH_NBR.ElementOwner("OSCAR_PROVIDER_NO")).Append(" = ").Append(Common.StringToField(fleF200_OSCAR_PROVIDER.GetStringValue("OSCAR_PROVIDER_NO")));
                strText.Append(" AND ").Append(fleF200C_OSCAR_PROVIDER_NEXT_BATCH_NBR.ElementOwner("DOC_NBR")).Append(" = ").Append(Common.StringToField(fleF200_OSCAR_PROVIDER.GetStringValue("DOC_NBR")));


                strText.Append(" ORDER BY ").Append(fleF200C_OSCAR_PROVIDER_NEXT_BATCH_NBR.ElementOwner("DOC_CLINIC_NBR"));
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

        protected TextBox fldF200C_OSCAR_PROVIDER_NEXT_BATCH_NBR_DOC_CLINIC_NBR;

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:16:30 AM

        //# No code was generated or needed for this region.

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:16:30 AM

        protected override void GetGridFieldObject(object DataListField, ref object CoreField, string Name)
        {

            try
            {
                switch (Name.ToUpper())
                {

                    case "FLDGRDF200C_OSCAR_PROVIDER_NEXT_BATCH_NBR_DOC_CLINIC_NBR":
                        fldF200C_OSCAR_PROVIDER_NEXT_BATCH_NBR_DOC_CLINIC_NBR = (TextBox)DataListField;
                        CoreField = fldF200C_OSCAR_PROVIDER_NEXT_BATCH_NBR_DOC_CLINIC_NBR;
                        fldF200C_OSCAR_PROVIDER_NEXT_BATCH_NBR_DOC_CLINIC_NBR.Bind(fleF200C_OSCAR_PROVIDER_NEXT_BATCH_NBR);
                        fldF200C_OSCAR_PROVIDER_NEXT_BATCH_NBR_DOC_CLINIC_NBR.LookupNotOn -= fldF200C_OSCAR_PROVIDER_NEXT_BATCH_NBR_DOC_CLINIC_NBR_LookupNotOn;
                        fldF200C_OSCAR_PROVIDER_NEXT_BATCH_NBR_DOC_CLINIC_NBR.LookupNotOn += fldF200C_OSCAR_PROVIDER_NEXT_BATCH_NBR_DOC_CLINIC_NBR_LookupNotOn;
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

        private void fldF200C_OSCAR_PROVIDER_NEXT_BATCH_NBR_DOC_CLINIC_NBR_LookupNotOn(ref bool LookupNotOnExecuted)
        {
            try
            {
                bool blnAlreadyExists = false;
                StringBuilder strSQL = new StringBuilder("SELECT ").Append(fleF200C_OSCAR_PROVIDER_NEXT_BATCH_NBR.ElementOwner("DOC_CLINIC_NBR"));
                strSQL.Append(" FROM ");
                strSQL.Append(fleF200C_OSCAR_PROVIDER_NEXT_BATCH_NBR.TableNameWithAlias());
                strSQL.Append(" WHERE ").Append(fleF200C_OSCAR_PROVIDER_NEXT_BATCH_NBR.ElementOwner("DOC_CLINIC_NBR")).Append(" = ").Append(Common.StringToField(FieldText));
                strSQL.Append(" AND  ").Append(fleF200C_OSCAR_PROVIDER_NEXT_BATCH_NBR.ElementOwner("DOC_NBR")).Append(" = ").Append(Common.StringToField(fleF200_OSCAR_PROVIDER.GetStringValue("DOC_NBR")));

                if (!LookupNotOn(strSQL, fleF200C_OSCAR_PROVIDER_NEXT_BATCH_NBR, "DOC_CLINIC_NBR", FieldText))
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

        //#-----------------------------------------
        //# SetRelations Procedure.
        //#-----------------------------------------

        public override void SetRelations()
        {

            try
            {
                dtlF200C_OSCAR_PROVIDER_NEXT_BATCH_NBR.OccursWithFile = fleF200C_OSCAR_PROVIDER_NEXT_BATCH_NBR;

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

        #region "Transaction Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:16:30 AM

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
            fleF200_OSCAR_PROVIDER.Transaction = m_trnTRANS_UPDATE;
            fleF200C_OSCAR_PROVIDER_NEXT_BATCH_NBR.Transaction = m_trnTRANS_UPDATE;

        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:16:30 AM

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
                fleF200_OSCAR_PROVIDER.Dispose();
                fleF200C_OSCAR_PROVIDER_NEXT_BATCH_NBR.Dispose();


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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:16:30 AM
        //#-----------------------------------------
        protected override void DisplayFormatting()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:16:30 AM
                Display(ref fldF200_OSCAR_PROVIDER_OSCAR_PROVIDER_NO);
                Display(ref fldF200_OSCAR_PROVIDER_DOC_NBR);
                Display(ref fldF200_OSCAR_PROVIDER_DOC_SPEC_CD);

                Display(ref fldF200_OSCAR_PROVIDER_PROCESS_AGENT_0_FLAG);
                Display(ref fldF200_OSCAR_PROVIDER_PROCESS_AGENT_1_FLAG);
                Display(ref fldF200_OSCAR_PROVIDER_PROCESS_AGENT_2_FLAG);
                Display(ref fldF200_OSCAR_PROVIDER_PROCESS_AGENT_3_FLAG);
                Display(ref fldF200_OSCAR_PROVIDER_PROCESS_AGENT_4_FLAG);
                Display(ref fldF200_OSCAR_PROVIDER_PROCESS_AGENT_5_FLAG);
                Display(ref fldF200_OSCAR_PROVIDER_PROCESS_AGENT_6_FLAG);
                Display(ref fldF200_OSCAR_PROVIDER_PROCESS_AGENT_7_FLAG);
                Display(ref fldF200_OSCAR_PROVIDER_PROCESS_AGENT_8_FLAG);
                Display(ref fldF200_OSCAR_PROVIDER_PROCESS_AGENT_9_FLAG);
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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:16:30 AM

        //#-----------------------------------------
        //# BindFields Procedure.
        //#-----------------------------------------

        public override void BindFields()
        {
            try
            {
                fldF200_OSCAR_PROVIDER_OSCAR_PROVIDER_NO.Bind(fleF200_OSCAR_PROVIDER);
                fldF200_OSCAR_PROVIDER_DOC_NBR.Bind(fleF200_OSCAR_PROVIDER);
                fldF200_OSCAR_PROVIDER_DOC_SPEC_CD.Bind(fleF200_OSCAR_PROVIDER);
                fldF200_OSCAR_PROVIDER_PROCESS_AGENT_0_FLAG.Bind(fleF200_OSCAR_PROVIDER);
                fldF200_OSCAR_PROVIDER_PROCESS_AGENT_1_FLAG.Bind(fleF200_OSCAR_PROVIDER);
                fldF200_OSCAR_PROVIDER_PROCESS_AGENT_2_FLAG.Bind(fleF200_OSCAR_PROVIDER);
                fldF200_OSCAR_PROVIDER_PROCESS_AGENT_3_FLAG.Bind(fleF200_OSCAR_PROVIDER);
                fldF200_OSCAR_PROVIDER_PROCESS_AGENT_4_FLAG.Bind(fleF200_OSCAR_PROVIDER);
                fldF200_OSCAR_PROVIDER_PROCESS_AGENT_5_FLAG.Bind(fleF200_OSCAR_PROVIDER);
                fldF200_OSCAR_PROVIDER_PROCESS_AGENT_6_FLAG.Bind(fleF200_OSCAR_PROVIDER);
                fldF200_OSCAR_PROVIDER_PROCESS_AGENT_7_FLAG.Bind(fleF200_OSCAR_PROVIDER);
                fldF200_OSCAR_PROVIDER_PROCESS_AGENT_8_FLAG.Bind(fleF200_OSCAR_PROVIDER);
                fldF200_OSCAR_PROVIDER_PROCESS_AGENT_9_FLAG.Bind(fleF200_OSCAR_PROVIDER);

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



        private void fldF200_OSCAR_PROVIDER_OSCAR_PROVIDER_NO_LookupNotOn(ref bool LookupNotOnExecuted)
        {

            try
            {
                bool blnAlreadyExists = false;
                StringBuilder strSQL = new StringBuilder("SELECT ").Append(fleF200_OSCAR_PROVIDER.ElementOwner("OSCAR_PROVIDER_NO"));
                strSQL.Append(" FROM ");
                strSQL.Append(fleF200_OSCAR_PROVIDER.TableNameWithAlias());
                strSQL.Append(" WHERE ");
                strSQL.Append("     ").Append(fleF200_OSCAR_PROVIDER.ElementOwner("OSCAR_PROVIDER_NO")).Append(" = ").Append(Common.StringToField(FieldText));

                if (!LookupNotOn(strSQL, fleF200_OSCAR_PROVIDER, "OSCAR_PROVIDER_NO", FieldText))
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
                    case 2:
                        m_strWhere = new StringBuilder(GetWhereCondition(fleF200_OSCAR_PROVIDER.ElementOwner("DOC_NBR"), fleF200_OSCAR_PROVIDER.GetStringValue("DOC_NBR"), ref blnAddWhere));
                        fleF200_OSCAR_PROVIDER.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
                        break;
                    case 1:
                        m_strWhere = new StringBuilder(GetWhereCondition(fleF200_OSCAR_PROVIDER.ElementOwner("OSCAR_PROVIDER_NO"), fleF200_OSCAR_PROVIDER.GetStringValue("OSCAR_PROVIDER_NO"), ref blnAddWhere));
                        fleF200_OSCAR_PROVIDER.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
                        break;
                    default:
                        fleF200_OSCAR_PROVIDER.GetData(GetDataOptions.Sequential | GetDataOptions.CreateSubSelect);
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


        protected override bool DetailFind()
        {


            try
            {

                while (fleF200C_OSCAR_PROVIDER_NEXT_BATCH_NBR.ForMissing())
                {
                    fleF200C_OSCAR_PROVIDER_NEXT_BATCH_NBR.GetData(GetDataOptions.CreateSubSelect | GetDataOptions.IsOptional);
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

                RequestPrompt(ref fldF200_OSCAR_PROVIDER_OSCAR_PROVIDER_NO);
                if (m_blnPromptOK)
                {
                    m_intPath = 1;
                }
                if (m_intPath == 0)
                {
                    RequestPrompt(ref fldF200_OSCAR_PROVIDER_DOC_NBR);
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
                Page.PageTitle = "Oscar Provider";



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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:16:30 AM
        //#-----------------------------------------
        protected override bool Entry()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:16:30 AM
                Accept(ref fldF200_OSCAR_PROVIDER_OSCAR_PROVIDER_NO);
                Accept(ref fldF200_OSCAR_PROVIDER_DOC_NBR);
                Accept(ref fldF200_OSCAR_PROVIDER_DOC_SPEC_CD);
                Accept(ref fldF200_OSCAR_PROVIDER_PROCESS_AGENT_0_FLAG);
                Accept(ref fldF200_OSCAR_PROVIDER_PROCESS_AGENT_1_FLAG);
                Accept(ref fldF200_OSCAR_PROVIDER_PROCESS_AGENT_2_FLAG);
                Accept(ref fldF200_OSCAR_PROVIDER_PROCESS_AGENT_3_FLAG);
                Accept(ref fldF200_OSCAR_PROVIDER_PROCESS_AGENT_4_FLAG);
                Accept(ref fldF200_OSCAR_PROVIDER_PROCESS_AGENT_5_FLAG);
                Accept(ref fldF200_OSCAR_PROVIDER_PROCESS_AGENT_6_FLAG);
                Accept(ref fldF200_OSCAR_PROVIDER_PROCESS_AGENT_7_FLAG);
                Accept(ref fldF200_OSCAR_PROVIDER_PROCESS_AGENT_8_FLAG);
                Accept(ref fldF200_OSCAR_PROVIDER_PROCESS_AGENT_9_FLAG);
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

        protected override bool Append()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 9:56:26 AM
                Accept(ref fldF200C_OSCAR_PROVIDER_NEXT_BATCH_NBR_DOC_CLINIC_NBR);



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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:16:30 AM
        //#-----------------------------------------
        protected override bool Update()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:16:30 AM
                fleF200_OSCAR_PROVIDER.PutData(false, PutTypes.New);
                fleF200_OSCAR_PROVIDER.PutData();

                while (fleF200C_OSCAR_PROVIDER_NEXT_BATCH_NBR.For())
                {
                    fleF200C_OSCAR_PROVIDER_NEXT_BATCH_NBR.PutData();
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:16:30 AM
        //#-----------------------------------------
        protected override bool Delete()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:16:30 AM
                fleF200_OSCAR_PROVIDER.DeletedRecord = true;

                while (fleF200C_OSCAR_PROVIDER_NEXT_BATCH_NBR.For())
                {
                    DetailDelete();
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

        private void DsrDesigner_100_Click(object sender, EventArgs e)
        {
            try
            {
                Accept(ref fldF200C_OSCAR_PROVIDER_NEXT_BATCH_NBR_DOC_CLINIC_NBR);

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

        private void dtlF200C_OSCAR_PROVIDER_NEXT_BATCH_NBR_EditClick(DataList source, GridButtonEventArgs GridButtonEventArgs)
        {
            try
            {
                DsrDesigner_100_Click(null, null);

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


        protected override bool DetailDelete()
        {
            try
            {
                 fleF200C_OSCAR_PROVIDER_NEXT_BATCH_NBR.DeletedRecord = true;
            
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
