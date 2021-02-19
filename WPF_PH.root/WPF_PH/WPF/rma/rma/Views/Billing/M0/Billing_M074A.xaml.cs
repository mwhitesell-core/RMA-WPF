
#region "Screen Comments"

// Program: m074a
// Purpose: F074-afp-group-sequence-mstr  - assign the reporting sequence for the afp groups
// in order to print the sequence that the dept manager wanted for r140_a_summ.txt
// 2009/jun/10 M.C. - original  

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

    partial class Billing_M074A : BasePage
    {

        #region " Form Designer Generated Code "





        public Billing_M074A()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "M074A";

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
            dtlF074_AFP_GROUP_SEQUENCE_MSTR.EditClick += dtlF074_AFP_GROUP_SEQUENCE_MSTR_EditClick;
            base.Page_Load();

            // TODO: If any DESIGNER procedures function on occurring FILES or TEMPORARIES, set the grid's AllowSelectRowButton property to TRUE.



        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            fleF074_AFP_GROUP_SEQUENCE_MSTR = new SqlFileObject(this, FileTypes.Primary, 18, "INDEXED", "F074_AFP_GROUP_SEQUENCE_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF074_AFP_GROUP_MSTR = new SqlFileObject(this, FileTypes.Reference, 0, "[101C].INDEXED", "F074_AFP_GROUP_MSTR", "", false, false, false, 0, "m_cnnQUERY");

         
            fleF074_AFP_GROUP_MSTR.Access += fleF074_AFP_GROUP_MSTR_Access;
        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;
            fleF074_AFP_GROUP_MSTR.Access -= fleF074_AFP_GROUP_MSTR_Access;
            fldF074_AFP_GROUP_SEQUENCE_MSTR_DOC_AFP_PAYM_GROUP.LookupNotOn -= fldF074_AFP_GROUP_SEQUENCE_MSTR_DOC_AFP_PAYM_GROUP_LookupNotOn;
            fldF074_AFP_GROUP_SEQUENCE_MSTR_DOC_AFP_PAYM_GROUP.LookupOn -= fldF074_AFP_GROUP_SEQUENCE_MSTR_DOC_AFP_PAYM_GROUP_LookupOn;

            dsrDesigner_01.Click -= dsrDesigner_01_Click;
            dtlF074_AFP_GROUP_SEQUENCE_MSTR.EditClick -= dtlF074_AFP_GROUP_SEQUENCE_MSTR_EditClick;

        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private SqlConnection m_cnnQUERY = new SqlConnection();
        private SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
        private SqlTransaction m_trnTRANS_UPDATE;
        private SqlFileObject fleF074_AFP_GROUP_SEQUENCE_MSTR;
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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:11:44 AM

        protected TextBox fldF074_AFP_GROUP_SEQUENCE_MSTR_DOC_AFP_PAYM_GROUP;
        protected TextBox fldF074_AFP_GROUP_SEQUENCE_MSTR_CONST_SECTION;
        protected TextBox fldF074_AFP_GROUP_SEQUENCE_MSTR_REPORTING_SEQ;
        protected ComboBox fldF074_AFP_GROUP_SEQUENCE_MSTR_TOTAL_FLAG;
        protected ComboBox fldF074_AFP_GROUP_SEQUENCE_MSTR_NONRBP_FLAG;

        protected ComboBox fldF074_AFP_GROUP_SEQUENCE_MSTR_SOLO_FLAG;

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:11:44 AM

        //#-----------------------------------------
        //# GetGridFieldObject Procedure.
        //#-----------------------------------------

        protected override void GetGridFieldObject(object DataListField, ref object CoreField, string Name)
        {

            try
            {
                switch (Name.ToUpper())
                {
                    case "FLDGRDF074_AFP_GROUP_SEQUENCE_MSTR_DOC_AFP_PAYM_GROUP":
                        fldF074_AFP_GROUP_SEQUENCE_MSTR_DOC_AFP_PAYM_GROUP = (TextBox)DataListField;

                        fldF074_AFP_GROUP_SEQUENCE_MSTR_DOC_AFP_PAYM_GROUP.LookupNotOn -= fldF074_AFP_GROUP_SEQUENCE_MSTR_DOC_AFP_PAYM_GROUP_LookupNotOn;
                        fldF074_AFP_GROUP_SEQUENCE_MSTR_DOC_AFP_PAYM_GROUP.LookupNotOn += fldF074_AFP_GROUP_SEQUENCE_MSTR_DOC_AFP_PAYM_GROUP_LookupNotOn;

                        fldF074_AFP_GROUP_SEQUENCE_MSTR_DOC_AFP_PAYM_GROUP.LookupOn -= fldF074_AFP_GROUP_SEQUENCE_MSTR_DOC_AFP_PAYM_GROUP_LookupOn;
                        fldF074_AFP_GROUP_SEQUENCE_MSTR_DOC_AFP_PAYM_GROUP.LookupOn += fldF074_AFP_GROUP_SEQUENCE_MSTR_DOC_AFP_PAYM_GROUP_LookupOn;
                        CoreField = fldF074_AFP_GROUP_SEQUENCE_MSTR_DOC_AFP_PAYM_GROUP;
                        fldF074_AFP_GROUP_SEQUENCE_MSTR_DOC_AFP_PAYM_GROUP.Bind(fleF074_AFP_GROUP_SEQUENCE_MSTR);
                        break;
                    case "FLDGRDF074_AFP_GROUP_SEQUENCE_MSTR_CONST_SECTION":
                        fldF074_AFP_GROUP_SEQUENCE_MSTR_CONST_SECTION = (TextBox)DataListField;
                        CoreField = fldF074_AFP_GROUP_SEQUENCE_MSTR_CONST_SECTION;
                        fldF074_AFP_GROUP_SEQUENCE_MSTR_CONST_SECTION.Bind(fleF074_AFP_GROUP_SEQUENCE_MSTR);
                        break;
                    case "FLDGRDF074_AFP_GROUP_SEQUENCE_MSTR_REPORTING_SEQ":
                        fldF074_AFP_GROUP_SEQUENCE_MSTR_REPORTING_SEQ = (TextBox)DataListField;
                        CoreField = fldF074_AFP_GROUP_SEQUENCE_MSTR_REPORTING_SEQ;
                        fldF074_AFP_GROUP_SEQUENCE_MSTR_REPORTING_SEQ.Bind(fleF074_AFP_GROUP_SEQUENCE_MSTR);
                        break;
                    case "FLDGRDF074_AFP_GROUP_SEQUENCE_MSTR_TOTAL_FLAG":
                        fldF074_AFP_GROUP_SEQUENCE_MSTR_TOTAL_FLAG = (ComboBox)DataListField;
                        CoreField = fldF074_AFP_GROUP_SEQUENCE_MSTR_TOTAL_FLAG;
                        fldF074_AFP_GROUP_SEQUENCE_MSTR_TOTAL_FLAG.Bind(fleF074_AFP_GROUP_SEQUENCE_MSTR);
                        break;
                    case "FLDGRDF074_AFP_GROUP_SEQUENCE_MSTR_NONRBP_FLAG":
                        fldF074_AFP_GROUP_SEQUENCE_MSTR_NONRBP_FLAG = (ComboBox)DataListField;
                        CoreField = fldF074_AFP_GROUP_SEQUENCE_MSTR_NONRBP_FLAG;
                        fldF074_AFP_GROUP_SEQUENCE_MSTR_NONRBP_FLAG.Bind(fleF074_AFP_GROUP_SEQUENCE_MSTR);
                        break;
                    case "FLDGRDF074_AFP_GROUP_SEQUENCE_MSTR_SOLO_FLAG":
                        fldF074_AFP_GROUP_SEQUENCE_MSTR_SOLO_FLAG = (ComboBox)DataListField;
                        CoreField = fldF074_AFP_GROUP_SEQUENCE_MSTR_SOLO_FLAG;
                        fldF074_AFP_GROUP_SEQUENCE_MSTR_SOLO_FLAG.Bind(fleF074_AFP_GROUP_SEQUENCE_MSTR);
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
                dtlF074_AFP_GROUP_SEQUENCE_MSTR.OccursWithFile = fleF074_AFP_GROUP_SEQUENCE_MSTR;

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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:11:44 AM

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
            fleF074_AFP_GROUP_SEQUENCE_MSTR.Transaction = m_trnTRANS_UPDATE;


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:11:44 AM

        //#-----------------------------------------
        //# InitializeFiles Procedure.
        //#-----------------------------------------

        protected override void InitializeFiles()
        {

            try
            {
                Initialize_TRANS_UPDATE();
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
                fleF074_AFP_GROUP_SEQUENCE_MSTR.Dispose();
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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:11:44 AM



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



        private void fldF074_AFP_GROUP_SEQUENCE_MSTR_DOC_AFP_PAYM_GROUP_LookupNotOn(ref bool LookupNotOnExecuted)
        {

            try
            {
                bool blnAlreadyExists = false;
                StringBuilder strSQL = new StringBuilder("SELECT ").Append(fleF074_AFP_GROUP_SEQUENCE_MSTR.ElementOwner("DOC_AFP_PAYM_GROUP"));
                strSQL.Append(" FROM ");
                strSQL.Append(fleF074_AFP_GROUP_SEQUENCE_MSTR.TableNameWithAlias());
                strSQL.Append(" WHERE ");
                strSQL.Append("     ").Append(fleF074_AFP_GROUP_SEQUENCE_MSTR.ElementOwner("DOC_AFP_PAYM_GROUP")).Append(" = ").Append(Common.StringToField(FieldText));

                if (!LookupNotOn(strSQL, fleF074_AFP_GROUP_SEQUENCE_MSTR, "DOC_AFP_PAYM_GROUP", FieldText))
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




        private void fldF074_AFP_GROUP_SEQUENCE_MSTR_DOC_AFP_PAYM_GROUP_LookupOn()
        {

            try
            {
                StringBuilder strSQL = new StringBuilder(" WHERE ");
                strSQL.Append("     ").Append(fleF074_AFP_GROUP_MSTR.ElementOwner("DOC_AFP_PAYM_GROUP")).Append(" = ").Append(Common.StringToField(FieldText));

                fleF074_AFP_GROUP_MSTR.GetData(strSQL.ToString(), GetDataOptions.IsOptional);
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


        #endregion

        #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"


        protected override bool Find()
        {


            try
            {
                bool blnAddWhere = true;
                while (fleF074_AFP_GROUP_SEQUENCE_MSTR.ForMissing())
                {
                    switch (m_intPath)
                    {
                        case 1:
                            m_strWhere = new StringBuilder(GetWhereCondition(fleF074_AFP_GROUP_SEQUENCE_MSTR.ElementOwner("DOC_AFP_PAYM_GROUP"), fleF074_AFP_GROUP_SEQUENCE_MSTR.GetStringValue("CONST_SECTION"), ref blnAddWhere));
                            fleF074_AFP_GROUP_SEQUENCE_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
                            break;
                        case 2:
                            fleF074_AFP_GROUP_SEQUENCE_MSTR.GetData(GetDataOptions.Sequential | GetDataOptions.CreateSubSelect);
                            break;
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



        protected override bool Path()
        {


            try
            {
                RequestPrompt(ref fldF074_AFP_GROUP_SEQUENCE_MSTR_CONST_SECTION);
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
                Page.PageTitle = "AFP Group / Section / Reporting Sequence";



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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:11:44 AM
        //#-----------------------------------------
        protected override bool Append()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:11:44 AM
                Accept(ref fldF074_AFP_GROUP_SEQUENCE_MSTR_DOC_AFP_PAYM_GROUP);
                Accept(ref fldF074_AFP_GROUP_SEQUENCE_MSTR_CONST_SECTION);
                Accept(ref fldF074_AFP_GROUP_SEQUENCE_MSTR_REPORTING_SEQ);
                Accept(ref fldF074_AFP_GROUP_SEQUENCE_MSTR_TOTAL_FLAG);
                Accept(ref fldF074_AFP_GROUP_SEQUENCE_MSTR_NONRBP_FLAG);
                Accept(ref fldF074_AFP_GROUP_SEQUENCE_MSTR_SOLO_FLAG);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:11:44 AM
        //#-----------------------------------------
        protected override bool Update()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:11:44 AM
                while (fleF074_AFP_GROUP_SEQUENCE_MSTR.For())
                {
                    fleF074_AFP_GROUP_SEQUENCE_MSTR.PutData(false, PutTypes.Deleted);
                }
                while (fleF074_AFP_GROUP_SEQUENCE_MSTR.For())
                {
                    fleF074_AFP_GROUP_SEQUENCE_MSTR.PutData();
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:11:44 AM
        //#-----------------------------------------
        protected override bool Delete()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:11:44 AM
                fleF074_AFP_GROUP_SEQUENCE_MSTR.DeletedRecord = true;
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
        //# dtlF074_AFP_GROUP_SEQUENCE_MSTR_EditClick Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:11:44 AM
        //#-----------------------------------------
        private void dtlF074_AFP_GROUP_SEQUENCE_MSTR_EditClick(DataList source, GridButtonEventArgs GridButtonEventArgs)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:11:44 AM
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:11:44 AM
        //#-----------------------------------------
        private void dsrDesigner_01_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:11:44 AM
                if (!fleF074_AFP_GROUP_SEQUENCE_MSTR.NewRecord)
                {
                    Display(ref fldF074_AFP_GROUP_SEQUENCE_MSTR_DOC_AFP_PAYM_GROUP);
                }
                else
                {
                    Accept(ref fldF074_AFP_GROUP_SEQUENCE_MSTR_DOC_AFP_PAYM_GROUP);
                }
                Accept(ref fldF074_AFP_GROUP_SEQUENCE_MSTR_CONST_SECTION);
                Accept(ref fldF074_AFP_GROUP_SEQUENCE_MSTR_REPORTING_SEQ);
                Accept(ref fldF074_AFP_GROUP_SEQUENCE_MSTR_TOTAL_FLAG);
                Accept(ref fldF074_AFP_GROUP_SEQUENCE_MSTR_NONRBP_FLAG);
                Accept(ref fldF074_AFP_GROUP_SEQUENCE_MSTR_SOLO_FLAG);
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

