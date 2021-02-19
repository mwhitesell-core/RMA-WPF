
#region "Screen Comments"

// Program: m923.qkc
// Purpose: maintain doctor payroll/revenue translation codes
// Logic: Doctors are normally paid via revenue tranferred from f002_claims
// into f050_revenue that eventually goes into f110_compensation (other
// than `mp` (manual payment) payroll in which case the compensation
// is entered directly into f110).
// The `regular` payroll is for claims/adjustments entered into 
// clinic 22.  If a 2nd clinic is used this revenue can be transferred
// to f050 under that clinic and then into a special f110 payroll
// subssystem (like the original clinic 81 or 81y2k ICU payroll)
// However in order to allow claims to go into a clinic but have then
// separated out from that clinic`s payroll we allow the f923 translation
// file to specify by doctor, by clinic, by payroll code a DIFFERENT
// clinic. This different or translatted clinic is used to create the
// f050_revenue transactions that then feed a different F110 payroll..
// Payroll  A  feeds clinic 22 and the regular-22 payroll.
// Payroll  B  was initially setup to change clinic 22 / payroll  B 
// claims into clinic 85 revenue records that then 
// were passed into the ICU payroll
// modification history
// 2001/oct/20 M.C. - original
// 2001/nov/08 B.E. - changed agent-cd field to clmhdr-payroll
// and religned layout of code

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

    partial class Billing_M923 : BasePage
    {

        #region " Form Designer Generated Code "





        public Billing_M923()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "M923";

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
            dtlF923_DOC_REVENUE_TRANSLATION.EditClick += dtlF923_DOC_REVENUE_TRANSLATION_EditClick;
            base.Page_Load();

            // TODO: If any DESIGNER procedures function on occurring FILES or TEMPORARIES, set the grid's AllowSelectRowButton property to TRUE.



        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            fleF923_DOC_REVENUE_TRANSLATION = new SqlFileObject(this, FileTypes.Primary, 15, "INDEXED", "F923_DOC_REVENUE_TRANSLATION", "", false, false, false, 0, "m_trnTRANS_UPDATE");


        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;
            fldF923_DOC_REVENUE_TRANSLATION_CLINIC_NBR_TRANSLATED.LookupNotOn -= fldF923_DOC_REVENUE_TRANSLATION_CLINIC_NBR_TRANSLATED_LookupNotOn;
            fldF923_DOC_REVENUE_TRANSLATION_CLMHDR_PAYROLL.LookupNotOn -= fldF923_DOC_REVENUE_TRANSLATION_CLMHDR_PAYROLL_LookupNotOn;

            dsrDesigner_01.Click -= dsrDesigner_01_Click;
            dtlF923_DOC_REVENUE_TRANSLATION.EditClick -= dtlF923_DOC_REVENUE_TRANSLATION_EditClick;

        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private SqlConnection m_cnnQUERY = new SqlConnection();
        private SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
        private SqlTransaction m_trnTRANS_UPDATE;
        private SqlFileObject fleF923_DOC_REVENUE_TRANSLATION;
        #endregion

        #region "Standard Generated Procedures"

        #region "Grid Field Declarations"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:17:13 AM

        protected TextBox fldF923_DOC_REVENUE_TRANSLATION_DOC_NBR;
        protected TextBox fldF923_DOC_REVENUE_TRANSLATION_CLINIC_NBR;
        protected TextBox fldF923_DOC_REVENUE_TRANSLATION_CLMHDR_PAYROLL;
        protected TextBox fldF923_DOC_REVENUE_TRANSLATION_CLINIC_NBR_TRANSLATED;

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:17:13 AM

        //#-----------------------------------------
        //# GetGridFieldObject Procedure.
        //#-----------------------------------------

        protected override void GetGridFieldObject(object DataListField, ref object CoreField, string Name)
        {

            try
            {
                switch (Name.ToUpper())
                {
                    case "FLDGRDF923_DOC_REVENUE_TRANSLATION_DOC_NBR":
                        fldF923_DOC_REVENUE_TRANSLATION_DOC_NBR = (TextBox)DataListField;
                        CoreField = fldF923_DOC_REVENUE_TRANSLATION_DOC_NBR;
                        fldF923_DOC_REVENUE_TRANSLATION_DOC_NBR.Bind(fleF923_DOC_REVENUE_TRANSLATION);
                        break;
                    case "FLDGRDF923_DOC_REVENUE_TRANSLATION_CLINIC_NBR":
                        fldF923_DOC_REVENUE_TRANSLATION_CLINIC_NBR = (TextBox)DataListField;
                        CoreField = fldF923_DOC_REVENUE_TRANSLATION_CLINIC_NBR;
                        fldF923_DOC_REVENUE_TRANSLATION_CLINIC_NBR.Bind(fleF923_DOC_REVENUE_TRANSLATION);
                        break;
                    case "FLDGRDF923_DOC_REVENUE_TRANSLATION_CLMHDR_PAYROLL":
                        fldF923_DOC_REVENUE_TRANSLATION_CLMHDR_PAYROLL = (TextBox)DataListField;

                        fldF923_DOC_REVENUE_TRANSLATION_CLMHDR_PAYROLL.LookupNotOn -= fldF923_DOC_REVENUE_TRANSLATION_CLMHDR_PAYROLL_LookupNotOn;
                        fldF923_DOC_REVENUE_TRANSLATION_CLMHDR_PAYROLL.LookupNotOn += fldF923_DOC_REVENUE_TRANSLATION_CLMHDR_PAYROLL_LookupNotOn;
                        CoreField = fldF923_DOC_REVENUE_TRANSLATION_CLMHDR_PAYROLL;
                        fldF923_DOC_REVENUE_TRANSLATION_CLMHDR_PAYROLL.Bind(fleF923_DOC_REVENUE_TRANSLATION);
                        break;
                    case "FLDGRDF923_DOC_REVENUE_TRANSLATION_CLINIC_NBR_TRANSLATED":
                        fldF923_DOC_REVENUE_TRANSLATION_CLINIC_NBR_TRANSLATED = (TextBox)DataListField;

                        fldF923_DOC_REVENUE_TRANSLATION_CLINIC_NBR_TRANSLATED.LookupNotOn -= fldF923_DOC_REVENUE_TRANSLATION_CLINIC_NBR_TRANSLATED_LookupNotOn;
                        fldF923_DOC_REVENUE_TRANSLATION_CLINIC_NBR_TRANSLATED.LookupNotOn += fldF923_DOC_REVENUE_TRANSLATION_CLINIC_NBR_TRANSLATED_LookupNotOn;
                        CoreField = fldF923_DOC_REVENUE_TRANSLATION_CLINIC_NBR_TRANSLATED;
                        fldF923_DOC_REVENUE_TRANSLATION_CLINIC_NBR_TRANSLATED.Bind(fleF923_DOC_REVENUE_TRANSLATION);
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
                dtlF923_DOC_REVENUE_TRANSLATION.OccursWithFile = fleF923_DOC_REVENUE_TRANSLATION;

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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:17:13 AM

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
            fleF923_DOC_REVENUE_TRANSLATION.Transaction = m_trnTRANS_UPDATE;


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:17:13 AM

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
                fleF923_DOC_REVENUE_TRANSLATION.Dispose();


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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:17:13 AM



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



        private void fldF923_DOC_REVENUE_TRANSLATION_CLINIC_NBR_TRANSLATED_LookupNotOn(ref bool LookupNotOnExecuted)
        {

            try
            {
                bool blnAlreadyExists = false;
                StringBuilder strSQL = new StringBuilder("SELECT ").Append(fleF923_DOC_REVENUE_TRANSLATION.ElementOwner("DOC_NBR"));
                strSQL.Append(" FROM ");
                strSQL.Append(fleF923_DOC_REVENUE_TRANSLATION.TableNameWithAlias());
                strSQL.Append(" WHERE ");
                strSQL.Append("     ").Append(fleF923_DOC_REVENUE_TRANSLATION.ElementOwner("DOC_NBR")).Append(" = ").Append(Common.StringToField(fleF923_DOC_REVENUE_TRANSLATION.GetStringValue("DOC_NBR")));
                strSQL.Append(" And ").Append(fleF923_DOC_REVENUE_TRANSLATION.ElementOwner("CLINIC_NBR_TRANSLATED")).Append(" = ").Append((FieldValue));

                if (!LookupNotOn(strSQL, fleF923_DOC_REVENUE_TRANSLATION, new string[] { "DOC_NBR", "CLINIC_NBR_TRANSLATED" }, new Object[] { fleF923_DOC_REVENUE_TRANSLATION.GetStringValue("DOC_NBR"), FieldValue }))
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




        private void fldF923_DOC_REVENUE_TRANSLATION_CLMHDR_PAYROLL_LookupNotOn(ref bool LookupNotOnExecuted)
        {

            try
            {
                bool blnAlreadyExists = false;
                StringBuilder strSQL = new StringBuilder("SELECT ").Append(fleF923_DOC_REVENUE_TRANSLATION.ElementOwner("DOC_NBR"));
                strSQL.Append(" FROM ");
                strSQL.Append(fleF923_DOC_REVENUE_TRANSLATION.TableNameWithAlias());
                strSQL.Append(" WHERE ");
                strSQL.Append("     ").Append(fleF923_DOC_REVENUE_TRANSLATION.ElementOwner("DOC_NBR")).Append(" = ").Append(Common.StringToField(fleF923_DOC_REVENUE_TRANSLATION.GetStringValue("DOC_NBR")));
                strSQL.Append(" And ").Append(fleF923_DOC_REVENUE_TRANSLATION.ElementOwner("CLINIC_NBR")).Append(" = ").Append((fleF923_DOC_REVENUE_TRANSLATION.GetDecimalValue("CLINIC_NBR")));
                strSQL.Append(" And ").Append(fleF923_DOC_REVENUE_TRANSLATION.ElementOwner("CLMHDR_PAYROLL")).Append(" = ").Append(Common.StringToField(FieldText));

                if (!LookupNotOn(strSQL, fleF923_DOC_REVENUE_TRANSLATION, new string[] { "DOC_NBR", "CLINIC_NBR", "CLMHDR_PAYROLL" }, new Object[] { fleF923_DOC_REVENUE_TRANSLATION.GetStringValue("DOC_NBR"), fleF923_DOC_REVENUE_TRANSLATION.GetDecimalValue("CLINIC_NBR"), FieldText }))
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
                m_strOrderBy = new StringBuilder("ORDER BY ");
                m_strOrderBy.Append(fleF923_DOC_REVENUE_TRANSLATION.ElementOwner("DOC_NBR"));
                switch (m_intPath)
                {
                    case 1:
                        m_strWhere = new StringBuilder(GetWhereCondition(fleF923_DOC_REVENUE_TRANSLATION.ElementOwner("DOC_NBR"), fleF923_DOC_REVENUE_TRANSLATION.GetStringValue("DOC_NBR"), ref blnAddWhere));
                        fleF923_DOC_REVENUE_TRANSLATION.GetData(m_strWhere.ToString(), m_strOrderBy.ToString(), GetDataOptions.CreateSubSelect);
                        break;
                    case 2:
                        fleF923_DOC_REVENUE_TRANSLATION.GetData("", m_strOrderBy.ToString(), GetDataOptions.Sequential | GetDataOptions.CreateSubSelect);
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
                RequestPrompt(ref fldF923_DOC_REVENUE_TRANSLATION_DOC_NBR);
                if (m_blnPromptOK)
                {
                    m_intPath = 1;
                }
                if (m_intPath == 0)
                {
                    m_intPath = 2;
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
                Page.PageTitle = "Payroll Revenue-Clinic Translation Maintenance";



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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:16:56 AM
        //#-----------------------------------------
        protected override bool Append()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:16:56 AM
                Accept(ref fldF923_DOC_REVENUE_TRANSLATION_DOC_NBR);
                Accept(ref fldF923_DOC_REVENUE_TRANSLATION_CLINIC_NBR);
                Accept(ref fldF923_DOC_REVENUE_TRANSLATION_CLMHDR_PAYROLL);
                Accept(ref fldF923_DOC_REVENUE_TRANSLATION_CLINIC_NBR_TRANSLATED);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:16:56 AM
        //#-----------------------------------------
        protected override bool Update()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:16:56 AM
                while (fleF923_DOC_REVENUE_TRANSLATION.For())
                {
                    fleF923_DOC_REVENUE_TRANSLATION.PutData(false, PutTypes.Deleted);
                }
                while (fleF923_DOC_REVENUE_TRANSLATION.For())
                {
                    fleF923_DOC_REVENUE_TRANSLATION.PutData();
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:16:57 AM
        //#-----------------------------------------
        protected override bool Delete()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:16:57 AM
                fleF923_DOC_REVENUE_TRANSLATION.DeletedRecord = true;
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
        //# dtlF923_DOC_REVENUE_TRANSLATION_EditClick Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:16:57 AM
        //#-----------------------------------------
        private void dtlF923_DOC_REVENUE_TRANSLATION_EditClick(DataList source, GridButtonEventArgs GridButtonEventArgs)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:17:12 AM
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:16:57 AM
        //#-----------------------------------------
        private void dsrDesigner_01_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:17:13 AM
                if (!fleF923_DOC_REVENUE_TRANSLATION.NewRecord)
                {
                    Display(ref fldF923_DOC_REVENUE_TRANSLATION_DOC_NBR);
                }
                else
                {
                    Accept(ref fldF923_DOC_REVENUE_TRANSLATION_DOC_NBR);
                }
                if (!fleF923_DOC_REVENUE_TRANSLATION.NewRecord)
                {
                    Display(ref fldF923_DOC_REVENUE_TRANSLATION_CLINIC_NBR);
                }
                else
                {
                    Accept(ref fldF923_DOC_REVENUE_TRANSLATION_CLINIC_NBR);
                }
                if (!fleF923_DOC_REVENUE_TRANSLATION.NewRecord)
                {
                    Display(ref fldF923_DOC_REVENUE_TRANSLATION_CLMHDR_PAYROLL);
                }
                else
                {
                    Accept(ref fldF923_DOC_REVENUE_TRANSLATION_CLMHDR_PAYROLL);
                }
                if (!fleF923_DOC_REVENUE_TRANSLATION.NewRecord)
                {
                    Display(ref fldF923_DOC_REVENUE_TRANSLATION_CLINIC_NBR_TRANSLATED);
                }
                else
                {
                    Accept(ref fldF923_DOC_REVENUE_TRANSLATION_CLINIC_NBR_TRANSLATED);
                }
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

