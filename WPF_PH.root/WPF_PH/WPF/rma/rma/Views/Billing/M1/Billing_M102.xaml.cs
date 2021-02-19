
#region "Screen Comments"

// #> PROGRAM-ID.     M102.QKS
// ((C)) Dyad Technologies
// PROGRAM PURPOSE : CLIENT DOCTOR MAINTENANCE
// MODIFICATION HISTORY
// DATE   WHO     DESCRIPTION
// 93/JUL/12 B.M.L.  - ORIGINAL (SMS 142)
// 1999/jan/31 B.E. - y2k
// 2002/jul/22 M.C. - display more doctors on the screen at once 
// 2003/dec/10 A.A. - alpha doctor nbr

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

    partial class Billing_M102 : BasePage
    {

        #region " Form Designer Generated Code "





        public Billing_M102()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "M102";

            //# Set the ACTIVITIES for the screen.
            this.ChangeActivity = true;
            this.FindActivity = true;
            this.DeleteActivity = true;
            this.EntryActivity = true;
            this.UseAcceptProcessing = true;








            this.GridDesigner = "dsrDesigner_04";
            this.ScreenType = ScreenTypes.Composite;


            dsrDesigner_04.DefaultFirstRowInGrid = true;

        }

        #endregion

        private void Page_Load(object sender, RoutedEventArgs e)
        {
            SetVariables();
            dsrDesigner_04.Click += dsrDesigner_04_Click;
            dsrDesigner_03.Click += dsrDesigner_03_Click;
            dsrDesigner_02.Click += dsrDesigner_02_Click;
            dsrDesigner_01.Click += dsrDesigner_01_Click;

            fldF072_CLIENT_MSTR_CLIENT_ID.LookupNotOn += fldF072_CLIENT_MSTR_CLIENT_ID_LookupNotOn;
            dtlF073_CLIENT_DOC_MSTR.EditClick += dtlF073_CLIENT_DOC_MSTR_EditClick;
            base.Page_Load();

            // TODO: If any DESIGNER procedures function on occurring FILES or TEMPORARIES, set the grid's AllowSelectRowButton property to TRUE.



        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            fleF072_CLIENT_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F072_CLIENT_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF073_CLIENT_DOC_MSTR = new SqlFileObject(this, FileTypes.Detail, 15, "INDEXED", "F073_CLIENT_DOC_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Reference, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_cnnQUERY");

           
            fleF020_DOCTOR_MSTR.Access += fleF020_DOCTOR_MSTR_Access;
            fleF073_CLIENT_DOC_MSTR.InitializeItems += fleF073_CLIENT_DOC_MSTR_InitializeItems;
        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;
            fleF020_DOCTOR_MSTR.Access -= fleF020_DOCTOR_MSTR_Access;
            fldF073_CLIENT_DOC_MSTR_DOC_NBR.LookupNotOn -= fldF073_CLIENT_DOC_MSTR_DOC_NBR_LookupNotOn;
            fldF073_CLIENT_DOC_MSTR_DOC_NBR.LookupOn -= fldF073_CLIENT_DOC_MSTR_DOC_NBR_LookupOn;
            fldF072_CLIENT_MSTR_CLIENT_ID.LookupNotOn -= fldF072_CLIENT_MSTR_CLIENT_ID_LookupNotOn;
            fleF073_CLIENT_DOC_MSTR.InitializeItems -= fleF073_CLIENT_DOC_MSTR_InitializeItems;
            dsrDesigner_04.Click -= dsrDesigner_04_Click;
            dsrDesigner_03.Click -= dsrDesigner_03_Click;
            dsrDesigner_02.Click -= dsrDesigner_02_Click;
            dsrDesigner_01.Click -= dsrDesigner_01_Click;
            dtlF073_CLIENT_DOC_MSTR.EditClick -= dtlF073_CLIENT_DOC_MSTR_EditClick;

        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private SqlConnection m_cnnQUERY = new SqlConnection();
        private SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
        private SqlTransaction m_trnTRANS_UPDATE;
        private SqlFileObject fleF072_CLIENT_MSTR;

        private void fleF073_CLIENT_DOC_MSTR_InitializeItems(bool Fixed)
        {

            try
            {
                fleF073_CLIENT_DOC_MSTR.set_SetValue("CLIENT_ID", !Fixed, fleF072_CLIENT_MSTR.GetStringValue("CLIENT_ID"));


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

        private SqlFileObject fleF073_CLIENT_DOC_MSTR;
        private SqlFileObject fleF020_DOCTOR_MSTR;

        private void fleF020_DOCTOR_MSTR_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE  ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ").Append(Common.StringToField(fleF073_CLIENT_DOC_MSTR.GetStringValue("DOC_NBR")));


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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:15:46 AM

        protected TextBox fldF073_CLIENT_DOC_MSTR_DOC_NBR;

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:15:46 AM

        //#-----------------------------------------
        //# GetGridFieldObject Procedure.
        //#-----------------------------------------

        protected override void GetGridFieldObject(object DataListField, ref object CoreField, string Name)
        {

            try
            {
                switch (Name.ToUpper())
                {
                    case "FLDGRDF073_CLIENT_DOC_MSTR_DOC_NBR":
                        fldF073_CLIENT_DOC_MSTR_DOC_NBR = (TextBox)DataListField;

                        fldF073_CLIENT_DOC_MSTR_DOC_NBR.LookupNotOn -= fldF073_CLIENT_DOC_MSTR_DOC_NBR_LookupNotOn;
                        fldF073_CLIENT_DOC_MSTR_DOC_NBR.LookupNotOn += fldF073_CLIENT_DOC_MSTR_DOC_NBR_LookupNotOn;

                        fldF073_CLIENT_DOC_MSTR_DOC_NBR.LookupOn -= fldF073_CLIENT_DOC_MSTR_DOC_NBR_LookupOn;
                        fldF073_CLIENT_DOC_MSTR_DOC_NBR.LookupOn += fldF073_CLIENT_DOC_MSTR_DOC_NBR_LookupOn;
                        CoreField = fldF073_CLIENT_DOC_MSTR_DOC_NBR;
                        fldF073_CLIENT_DOC_MSTR_DOC_NBR.Bind(fleF073_CLIENT_DOC_MSTR);
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
                dtlF073_CLIENT_DOC_MSTR.OccursWithFile = fleF073_CLIENT_DOC_MSTR;

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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:15:46 AM

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
            fleF072_CLIENT_MSTR.Transaction = m_trnTRANS_UPDATE;
            fleF073_CLIENT_DOC_MSTR.Transaction = m_trnTRANS_UPDATE;


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:15:46 AM

        //#-----------------------------------------
        //# InitializeFiles Procedure.
        //#-----------------------------------------

        protected override void InitializeFiles()
        {

            try
            {
                Initialize_TRANS_UPDATE();
                fleF020_DOCTOR_MSTR.Connection = m_cnnQUERY;


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
                fleF072_CLIENT_MSTR.Dispose();
                fleF073_CLIENT_DOC_MSTR.Dispose();
                fleF020_DOCTOR_MSTR.Dispose();


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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:15:46 AM
        //#-----------------------------------------
        protected override void DisplayFormatting()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:15:46 AM
                Display(ref fldF072_CLIENT_MSTR_CLIENT_ID);
                Display(ref fldF072_CLIENT_MSTR_OPERATOR_NBR);
                Display(ref fldF072_CLIENT_MSTR_DESCRIPTION);
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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:15:46 AM

        //#-----------------------------------------
        //# BindFields Procedure.
        //#-----------------------------------------

        public override void BindFields()
        {
            try
            {
                fldF072_CLIENT_MSTR_CLIENT_ID.Bind(fleF072_CLIENT_MSTR);
                fldF072_CLIENT_MSTR_OPERATOR_NBR.Bind(fleF072_CLIENT_MSTR);
                fldF072_CLIENT_MSTR_DESCRIPTION.Bind(fleF072_CLIENT_MSTR);

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



        private void fldF073_CLIENT_DOC_MSTR_DOC_NBR_LookupNotOn(ref bool LookupNotOnExecuted)
        {

            try
            {
                bool blnAlreadyExists = false;
                StringBuilder strSQL = new StringBuilder("SELECT ").Append(fleF073_CLIENT_DOC_MSTR.ElementOwner("DOC_NBR"));
                strSQL.Append(" FROM ");
                strSQL.Append(fleF073_CLIENT_DOC_MSTR.TableNameWithAlias());
                strSQL.Append(" WHERE ");
                strSQL.Append("     ").Append(fleF073_CLIENT_DOC_MSTR.ElementOwner("DOC_NBR")).Append(" = ").Append(Common.StringToField(FieldText));

                if (!LookupNotOn(strSQL, fleF073_CLIENT_DOC_MSTR, "DOC_NBR", FieldText))
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




        private void fldF073_CLIENT_DOC_MSTR_DOC_NBR_LookupOn()
        {

            try
            {
                StringBuilder strSQL = new StringBuilder(" WHERE ");
                strSQL.Append("     ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ").Append(Common.StringToField(FieldText));

                fleF020_DOCTOR_MSTR.GetData(strSQL.ToString(), GetDataOptions.IsOptional);
                if (!AccessOk)
                {
                    ErrorMessage("Record not found on lookup table");
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




        private void fldF072_CLIENT_MSTR_CLIENT_ID_LookupNotOn(ref bool LookupNotOnExecuted)
        {

            try
            {
                bool blnAlreadyExists = false;
                StringBuilder strSQL = new StringBuilder("SELECT ").Append(fleF072_CLIENT_MSTR.ElementOwner("CLIENT_ID"));
                strSQL.Append(" FROM ");
                strSQL.Append(fleF072_CLIENT_MSTR.TableNameWithAlias());
                strSQL.Append(" WHERE ");
                strSQL.Append("     ").Append(fleF072_CLIENT_MSTR.ElementOwner("CLIENT_ID")).Append(" = ").Append(Common.StringToField(FieldText));

                if (!LookupNotOn(strSQL, fleF072_CLIENT_MSTR, "CLIENT_ID", FieldText))
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


        protected override bool DetailFind()
        {


            try
            {
                m_strOrderBy = new StringBuilder(" ORDER BY ").Append(fleF073_CLIENT_DOC_MSTR.ElementOwner("DOC_NBR"));

                bool blnAddWhere = true;
                m_strWhere = new StringBuilder(GetWhereCondition(fleF073_CLIENT_DOC_MSTR.ElementOwner("CLIENT_ID"), fleF072_CLIENT_MSTR.GetStringValue("CLIENT_ID"), ref blnAddWhere));
                while (fleF073_CLIENT_DOC_MSTR.ForMissing())
                {
                    fleF073_CLIENT_DOC_MSTR.GetData(m_strWhere.ToString(), m_strOrderBy.ToString(), GetDataOptions.CreateSubSelect | GetDataOptions.IsOptional);
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
                m_strOrderBy = new StringBuilder(" ORDER BY ").Append(fleF072_CLIENT_MSTR.ElementOwner("CLIENT_ID"));
                bool blnAddWhere = true;
                switch (m_intPath)
                {
                    case 1:
                        m_strWhere = new StringBuilder(GetWhereCondition(fleF072_CLIENT_MSTR.ElementOwner("CLIENT_ID"), fleF072_CLIENT_MSTR.GetStringValue("CLIENT_ID"), ref blnAddWhere));
                        fleF072_CLIENT_MSTR.GetData(m_strWhere.ToString(), m_strOrderBy.ToString(), GetDataOptions.CreateSubSelect);
                        break;
                    default:
                        fleF072_CLIENT_MSTR.GetData("", m_strOrderBy.ToString(), GetDataOptions.Sequential | GetDataOptions.CreateSubSelect);
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

                RequestPrompt(ref fldF072_CLIENT_MSTR_CLIENT_ID);
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
                Page.PageTitle = "CLIENT/DOC MSTR MAINTENANCE";



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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:15:46 AM
        //#-----------------------------------------
        protected override bool Append()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:15:46 AM
                Accept(ref fldF073_CLIENT_DOC_MSTR_DOC_NBR);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:15:46 AM
        //#-----------------------------------------
        protected override bool Entry()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:15:46 AM
                Accept(ref fldF072_CLIENT_MSTR_CLIENT_ID);
                Accept(ref fldF072_CLIENT_MSTR_OPERATOR_NBR);
                Accept(ref fldF072_CLIENT_MSTR_DESCRIPTION);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:15:46 AM
        //#-----------------------------------------
        protected override bool Update()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:15:46 AM
                fleF072_CLIENT_MSTR.PutData(false, PutTypes.New);
                while (fleF073_CLIENT_DOC_MSTR.For())
                {
                    fleF073_CLIENT_DOC_MSTR.PutData(false, PutTypes.Deleted);
                }
                while (fleF073_CLIENT_DOC_MSTR.For())
                {
                    fleF073_CLIENT_DOC_MSTR.PutData();
                }
                fleF072_CLIENT_MSTR.PutData();
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:15:46 AM
        //#-----------------------------------------
        protected override bool Delete()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:15:46 AM
                fleF072_CLIENT_MSTR.DeletedRecord = true;
                while (fleF073_CLIENT_DOC_MSTR.For())
                {
                    fleF073_CLIENT_DOC_MSTR.DeletedRecord = true;
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
        //# DetailDelete Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:15:46 AM
        //#-----------------------------------------
        protected override bool DetailDelete()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:15:46 AM
                fleF073_CLIENT_DOC_MSTR.DeletedRecord = true;
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
        //# dtlF073_CLIENT_DOC_MSTR_EditClick Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:15:46 AM
        //#-----------------------------------------
        private void dtlF073_CLIENT_DOC_MSTR_EditClick(DataList source, GridButtonEventArgs GridButtonEventArgs)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:15:46 AM
                dsrDesigner_04_Click(null, null);
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
        //# dsrDesigner_04_Click Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:15:46 AM
        //#-----------------------------------------
        private void dsrDesigner_04_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:15:46 AM
                if (!fleF073_CLIENT_DOC_MSTR.NewRecord)
                {
                    Display(ref fldF073_CLIENT_DOC_MSTR_DOC_NBR);
                }
                else
                {
                    Accept(ref fldF073_CLIENT_DOC_MSTR_DOC_NBR);
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

        //#-----------------------------------------
        //# dsrDesigner_03_Click Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:15:46 AM
        //#-----------------------------------------
        private void dsrDesigner_03_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:15:46 AM
                Accept(ref fldF072_CLIENT_MSTR_DESCRIPTION);
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
        //# dsrDesigner_02_Click Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:15:46 AM
        //#-----------------------------------------
        private void dsrDesigner_02_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:15:46 AM
                Accept(ref fldF072_CLIENT_MSTR_OPERATOR_NBR);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:15:46 AM
        //#-----------------------------------------
        private void dsrDesigner_01_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:15:46 AM
                if (!fleF072_CLIENT_MSTR.NewRecord)
                {
                    Display(ref fldF072_CLIENT_MSTR_CLIENT_ID);
                }
                else
                {
                    Accept(ref fldF072_CLIENT_MSTR_CLIENT_ID);
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

