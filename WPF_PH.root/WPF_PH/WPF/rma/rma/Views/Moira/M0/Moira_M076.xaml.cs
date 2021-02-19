
#region "Screen Comments"

// #> program-id.     m076.qks
// program purpose : patient insurance company for the claims
// modification history
// date   who     description
// 2013/May/29   M.C. - original

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

    partial class Moira_M076 : BasePage
    {

        #region " Form Designer Generated Code "





        public Moira_M076()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "M076";

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
            dtlF076_INSURANCE_MSTR.EditClick += dtlF076_INSURANCE_MSTR_EditClick;
            base.Page_Load();

            // TODO: If any DESIGNER procedures function on occurring FILES or TEMPORARIES, set the grid's AllowSelectRowButton property to TRUE.



        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            fleF076_INSURANCE_MSTR = new SqlFileObject(this, FileTypes.Primary, 4, "INDEXED", "F076_INSURANCE_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
           

        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;
            fldF076_INSURANCE_MSTR_INS_ACRONYM.LookupNotOn -= fldF076_INSURANCE_MSTR_INS_ACRONYM_LookupNotOn;

            dsrDesigner_01.Click -= dsrDesigner_01_Click;
            dtlF076_INSURANCE_MSTR.EditClick -= dtlF076_INSURANCE_MSTR_EditClick;

        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private SqlConnection m_cnnQUERY = new SqlConnection();
        private SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
        private SqlTransaction m_trnTRANS_UPDATE;
        private SqlFileObject fleF076_INSURANCE_MSTR;
        #endregion

        #region "Standard Generated Procedures"

        #region "Grid Field Declarations"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:40:00 AM

        protected TextBox fldF076_INSURANCE_MSTR_INS_ACRONYM;
        protected TextBox fldF076_INSURANCE_MSTR_INS_FULL_NAME;
        protected TextBox fldF076_INSURANCE_MSTR_ADDR_LINE_1;
        protected TextBox fldF076_INSURANCE_MSTR_ADDR_LINE_2;
        protected TextBox fldF076_INSURANCE_MSTR_ADDR_LINE_3;

        protected TextBox fldF076_INSURANCE_MSTR_ADDR_POSTAL_CD;

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:40:00 AM

        //#-----------------------------------------
        //# GetGridFieldObject Procedure.
        //#-----------------------------------------

        protected override void GetGridFieldObject(object DataListField, ref object CoreField, string Name)
        {

            try
            {
                switch (Name.ToUpper())
                {
                    case "FLDGRDF076_INSURANCE_MSTR_INS_ACRONYM":
                        fldF076_INSURANCE_MSTR_INS_ACRONYM = (TextBox)DataListField;

                        fldF076_INSURANCE_MSTR_INS_ACRONYM.LookupNotOn -= fldF076_INSURANCE_MSTR_INS_ACRONYM_LookupNotOn;
                        fldF076_INSURANCE_MSTR_INS_ACRONYM.LookupNotOn += fldF076_INSURANCE_MSTR_INS_ACRONYM_LookupNotOn;
                        CoreField = fldF076_INSURANCE_MSTR_INS_ACRONYM;
                        fldF076_INSURANCE_MSTR_INS_ACRONYM.Bind(fleF076_INSURANCE_MSTR);
                        break;
                    case "FLDGRDF076_INSURANCE_MSTR_INS_FULL_NAME":
                        fldF076_INSURANCE_MSTR_INS_FULL_NAME = (TextBox)DataListField;
                        CoreField = fldF076_INSURANCE_MSTR_INS_FULL_NAME;
                        fldF076_INSURANCE_MSTR_INS_FULL_NAME.Bind(fleF076_INSURANCE_MSTR);
                        break;
                    case "FLDGRDF076_INSURANCE_MSTR_ADDR_LINE_1":
                        fldF076_INSURANCE_MSTR_ADDR_LINE_1 = (TextBox)DataListField;
                        CoreField = fldF076_INSURANCE_MSTR_ADDR_LINE_1;
                        fldF076_INSURANCE_MSTR_ADDR_LINE_1.Bind(fleF076_INSURANCE_MSTR);
                        break;
                    case "FLDGRDF076_INSURANCE_MSTR_ADDR_LINE_2":
                        fldF076_INSURANCE_MSTR_ADDR_LINE_2 = (TextBox)DataListField;
                        CoreField = fldF076_INSURANCE_MSTR_ADDR_LINE_2;
                        fldF076_INSURANCE_MSTR_ADDR_LINE_2.Bind(fleF076_INSURANCE_MSTR);
                        break;
                    case "FLDGRDF076_INSURANCE_MSTR_ADDR_LINE_3":
                        fldF076_INSURANCE_MSTR_ADDR_LINE_3 = (TextBox)DataListField;
                        CoreField = fldF076_INSURANCE_MSTR_ADDR_LINE_3;
                        fldF076_INSURANCE_MSTR_ADDR_LINE_3.Bind(fleF076_INSURANCE_MSTR);
                        break;
                    case "FLDGRDF076_INSURANCE_MSTR_ADDR_POSTAL_CD":
                        fldF076_INSURANCE_MSTR_ADDR_POSTAL_CD = (TextBox)DataListField;
                        CoreField = fldF076_INSURANCE_MSTR_ADDR_POSTAL_CD;
                        fldF076_INSURANCE_MSTR_ADDR_POSTAL_CD.Bind(fleF076_INSURANCE_MSTR);
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
                dtlF076_INSURANCE_MSTR.OccursWithFile = fleF076_INSURANCE_MSTR;

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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:40:00 AM

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
            fleF076_INSURANCE_MSTR.Transaction = m_trnTRANS_UPDATE;


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:40:00 AM

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
                fleF076_INSURANCE_MSTR.Dispose();


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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:40:00 AM



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



        private void fldF076_INSURANCE_MSTR_INS_ACRONYM_LookupNotOn(ref bool LookupNotOnExecuted)
        {

            try
            {
                bool blnAlreadyExists = false;
                StringBuilder strSQL = new StringBuilder("SELECT ").Append(fleF076_INSURANCE_MSTR.ElementOwner("INS_ACRONYM"));
                strSQL.Append(" FROM ");
                strSQL.Append(fleF076_INSURANCE_MSTR.TableNameWithAlias());
                strSQL.Append(" WHERE ");
                strSQL.Append("     ").Append(fleF076_INSURANCE_MSTR.ElementOwner("INS_ACRONYM")).Append(" = ").Append(Common.StringToField(FieldText));

                if (!LookupNotOn(strSQL, fleF076_INSURANCE_MSTR, "INS_ACRONYM", FieldText))
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
                while (fleF076_INSURANCE_MSTR.ForMissing())
                {
                    switch (m_intPath)
                    {
                        case 1:
                            m_strWhere = new StringBuilder(GetWhereCondition(fleF076_INSURANCE_MSTR.ElementOwner("INS_ACRONYM"), fleF076_INSURANCE_MSTR.GetStringValue("INS_ACRONYM"), ref blnAddWhere));
                            fleF076_INSURANCE_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
                            break;
                        case 2:
                            fleF076_INSURANCE_MSTR.GetData(GetDataOptions.Sequential | GetDataOptions.CreateSubSelect);
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
                RequestPrompt(ref fldF076_INSURANCE_MSTR_INS_ACRONYM);
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
                Page.PageTitle = "Insurance Company Master";



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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:40:00 AM
        //#-----------------------------------------
        protected override bool Append()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:40:00 AM
                Accept(ref fldF076_INSURANCE_MSTR_INS_ACRONYM);
                Accept(ref fldF076_INSURANCE_MSTR_INS_FULL_NAME);
                Accept(ref fldF076_INSURANCE_MSTR_ADDR_LINE_1);
                Accept(ref fldF076_INSURANCE_MSTR_ADDR_LINE_2);
                Accept(ref fldF076_INSURANCE_MSTR_ADDR_LINE_3);
                Accept(ref fldF076_INSURANCE_MSTR_ADDR_POSTAL_CD);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:40:00 AM
        //#-----------------------------------------
        protected override bool Update()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:40:00 AM
                while (fleF076_INSURANCE_MSTR.For())
                {
                    fleF076_INSURANCE_MSTR.PutData(false, PutTypes.Deleted);
                }
                while (fleF076_INSURANCE_MSTR.For())
                {
                    fleF076_INSURANCE_MSTR.PutData();
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:40:00 AM
        //#-----------------------------------------
        protected override bool Delete()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:40:00 AM
                fleF076_INSURANCE_MSTR.DeletedRecord = true;
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
        //# dtlF076_INSURANCE_MSTR_EditClick Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:40:00 AM
        //#-----------------------------------------
        private void dtlF076_INSURANCE_MSTR_EditClick(DataList source, GridButtonEventArgs GridButtonEventArgs)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:40:00 AM
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:40:00 AM
        //#-----------------------------------------
        private void dsrDesigner_01_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:40:00 AM
                if (!fleF076_INSURANCE_MSTR.NewRecord)
                {
                    Display(ref fldF076_INSURANCE_MSTR_INS_ACRONYM);
                }
                else
                {
                    Accept(ref fldF076_INSURANCE_MSTR_INS_ACRONYM);
                }
                Accept(ref fldF076_INSURANCE_MSTR_INS_FULL_NAME);
                Accept(ref fldF076_INSURANCE_MSTR_ADDR_LINE_1);
                Accept(ref fldF076_INSURANCE_MSTR_ADDR_LINE_2);
                Accept(ref fldF076_INSURANCE_MSTR_ADDR_LINE_3);
                Accept(ref fldF076_INSURANCE_MSTR_ADDR_POSTAL_CD);
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

