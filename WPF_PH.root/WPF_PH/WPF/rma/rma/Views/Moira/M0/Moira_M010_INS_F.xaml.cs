
#region "Screen Comments"

// #>  PROGRAM-ID.      M010_INS_F.QKS
// ((C)) DYAD TECHNOLOGIES
// PROGRAM PURPOSE : LOOKUP TABLE FOR M010_INS.QKS
// MODIFICATION HISTORY
// DATE          WHO           DESCRIPTION
// 2013/May/30    M.C.     - original

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

    partial class Moira_M010_INS_F : BasePage
    {

        #region " Form Designer Generated Code "





        public Moira_M010_INS_F()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "M010_INS_F";

            //# Set the ACTIVITIES for the screen.
            this.ChangeActivity = false;
            this.FindActivity = true;
            this.DeleteActivity = false;
            this.EntryActivity = false;
            this.DisableAppend = true;
            this.UseAcceptProcessing = true;




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
            W_INS_ACRONYM = new CoreCharacter("W_INS_ACRONYM", 5, this, Common.cEmptyString);
            fleF076_INSURANCE_MSTR = new SqlFileObject(this, FileTypes.Primary, 4, "INDEXED", "F076_INSURANCE_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
          

        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;

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
        private CoreCharacter W_INS_ACRONYM;
        private SqlFileObject fleF076_INSURANCE_MSTR;
        #endregion

        #region "Standard Generated Procedures"

        #region "Grid Field Declarations"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:39:55 AM

        protected TextBox fldF076_INSURANCE_MSTR_INS_ACRONYM;
        protected TextBox fldF076_INSURANCE_MSTR_INS_FULL_NAME;
        protected TextBox fldF076_INSURANCE_MSTR_ADDR_LINE_1;
        protected TextBox fldF076_INSURANCE_MSTR_ADDR_LINE_2;
        protected TextBox fldF076_INSURANCE_MSTR_ADDR_LINE_3;

        protected TextBox fldF076_INSURANCE_MSTR_ADDR_POSTAL_CD;

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:39:55 AM

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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:39:55 AM

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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:39:55 AM

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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:39:55 AM



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



        protected override void SaveParamsReceived()
        {

            try
            {
                SaveReceivingParams(W_INS_ACRONYM);


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
                Receiving(W_INS_ACRONYM);


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



        private void dsrDesigner_01_Click(object sender, System.EventArgs e)
        {

            try
            {

                W_INS_ACRONYM.Value = fleF076_INSURANCE_MSTR.GetStringValue("INS_ACRONYM");
                ReturnAndClose();
                // RETURN


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
                while (fleF076_INSURANCE_MSTR.ForMissing())
                {
                    fleF076_INSURANCE_MSTR.GetData(GetDataOptions.Sequential | GetDataOptions.CreateSubSelect);
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
                Page.PageTitle = "Insurance Company Master Lookup";



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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:39:55 AM
        //#-----------------------------------------
        private void dtlF076_INSURANCE_MSTR_EditClick(DataList source, GridButtonEventArgs GridButtonEventArgs)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:39:55 AM
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

        #endregion

        #endregion

    }


}
