
#region "Screen Comments"

// #> PROGRAM-ID.     M021.QKS
// ((C)) Dyad Technologies
// PROGRAM PURPOSE : ENTRY OF ALTERNATIVE DOCTOR NUMBER
// MODIFICATION HISTORY
// DATE   WHO     DESCRIPTION
// 91/JAN/21 D.B.     - ORIGINAL (SMS 137)
// 91/APR/19 M.C.     - SMS 138 - CHANGE THE FILE NAME
// 1999/jan/31 B.E. - y2k
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

    partial class Billing_M021 : BasePage
    {

        #region " Form Designer Generated Code "





        public Billing_M021()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "M021";

            //# Set the ACTIVITIES for the screen.
            this.ChangeActivity = true;
            this.FindActivity = true;
            this.DeleteActivity = true;
            this.EntryActivity = true;
            this.UseAcceptProcessing = true;






            this.GridDesigner = "dsrDesigner_01";


            dsrDesigner_01.DefaultFirstRowInGrid = true;



        }

        #endregion

        private void Page_Load(object sender, RoutedEventArgs e)
        {
            SetVariables();
            dsrDesigner_01.Click += dsrDesigner_01_Click;
            dtlF023_ALTERNATIVE_DOCTOR_NBR.EditClick += dtlF023_ALTERNATIVE_DOCTOR_NBR_EditClick;
            base.Page_Load();

            // TODO: If any DESIGNER procedures function on occurring FILES or TEMPORARIES, set the grid's AllowSelectRowButton property to TRUE.



        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            W_DOC_NBR = new CoreCharacter("W_DOC_NBR", 3, this, Common.cEmptyString);
            W_DOC_DEPT = new CoreDecimal("W_DOC_DEPT", 2, this);
            fleF023_ALTERNATIVE_DOCTOR_NBR = new SqlFileObject(this, FileTypes.Primary, 5, "INDEXED", "F023_ALTERNATIVE_DOCTOR_NBR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Reference, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_cnnQUERY");

          
           
            fleF020_DOCTOR_MSTR.Access += fleF020_DOCTOR_MSTR_Access;
            fleF023_ALTERNATIVE_DOCTOR_NBR.InitializeItems += fleF023_ALTERNATIVE_DOCTOR_NBR_InitializeItems;
        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;
            fleF020_DOCTOR_MSTR.Access -= fleF020_DOCTOR_MSTR_Access;
          
            dsrDesigner_01.Click -= dsrDesigner_01_Click;
            dtlF023_ALTERNATIVE_DOCTOR_NBR.EditClick -= dtlF023_ALTERNATIVE_DOCTOR_NBR_EditClick;
            fleF023_ALTERNATIVE_DOCTOR_NBR.InitializeItems -= fleF023_ALTERNATIVE_DOCTOR_NBR_InitializeItems;
           

        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private SqlConnection m_cnnQUERY = new SqlConnection();
        private SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
        private SqlTransaction m_trnTRANS_UPDATE;
        private CoreCharacter W_DOC_NBR;
        private CoreDecimal W_DOC_DEPT;
        private SqlFileObject fleF023_ALTERNATIVE_DOCTOR_NBR;

        private void fleF023_ALTERNATIVE_DOCTOR_NBR_InitializeItems(bool Fixed)
        {

            try
            {
                if (!Fixed)
                    fleF023_ALTERNATIVE_DOCTOR_NBR.set_SetValue("DOC_NBR", true, W_DOC_NBR.Value);
                if (!Fixed)
                    fleF023_ALTERNATIVE_DOCTOR_NBR.set_SetValue("DOC_DEPT", true, W_DOC_DEPT.Value);


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

        private SqlFileObject fleF020_DOCTOR_MSTR;

        private void fleF020_DOCTOR_MSTR_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ").Append(Common.StringToField(fleF023_ALTERNATIVE_DOCTOR_NBR.GetStringValue("ALTERNATIVE_DOC_NBR")));

                strText.Append(" ORDER BY ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR"));
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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:12:33 AM

        protected TextBox fldF023_ALTERNATIVE_DOCTOR_NBR_ALTERNATIVE_DOC_NBR;

        protected TextBox fldF023_ALTERNATIVE_DOCTOR_NBR_ALTERNATIVE_DOC_DEPT;

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:12:33 AM

        //#-----------------------------------------
        //# GetGridFieldObject Procedure.
        //#-----------------------------------------

        protected override void GetGridFieldObject(object DataListField, ref object CoreField, string Name)
        {

            try
            {
                switch (Name.ToUpper())
                {
                    case "FLDGRDF023_ALTERNATIVE_DOCTOR_NBR_ALTERNATIVE_DOC_NBR":
                        fldF023_ALTERNATIVE_DOCTOR_NBR_ALTERNATIVE_DOC_NBR = (TextBox)DataListField;

                        fldF023_ALTERNATIVE_DOCTOR_NBR_ALTERNATIVE_DOC_NBR.LookupOn -= fldF023_ALTERNATIVE_DOCTOR_NBR_ALTERNATIVE_DOC_NBR_LookupOn;
                        fldF023_ALTERNATIVE_DOCTOR_NBR_ALTERNATIVE_DOC_NBR.LookupOn += fldF023_ALTERNATIVE_DOCTOR_NBR_ALTERNATIVE_DOC_NBR_LookupOn;
                        fldF023_ALTERNATIVE_DOCTOR_NBR_ALTERNATIVE_DOC_NBR.Process -= fldF023_ALTERNATIVE_DOCTOR_NBR_ALTERNATIVE_DOC_NBR_Process;
                        fldF023_ALTERNATIVE_DOCTOR_NBR_ALTERNATIVE_DOC_NBR.Process += fldF023_ALTERNATIVE_DOCTOR_NBR_ALTERNATIVE_DOC_NBR_Process;
                        CoreField = fldF023_ALTERNATIVE_DOCTOR_NBR_ALTERNATIVE_DOC_NBR;
                        fldF023_ALTERNATIVE_DOCTOR_NBR_ALTERNATIVE_DOC_NBR.Bind(fleF023_ALTERNATIVE_DOCTOR_NBR);
                        break;
                    case "FLDGRDF023_ALTERNATIVE_DOCTOR_NBR_ALTERNATIVE_DOC_DEPT":
                        fldF023_ALTERNATIVE_DOCTOR_NBR_ALTERNATIVE_DOC_DEPT = (TextBox)DataListField;
                        CoreField = fldF023_ALTERNATIVE_DOCTOR_NBR_ALTERNATIVE_DOC_DEPT;
                        fldF023_ALTERNATIVE_DOCTOR_NBR_ALTERNATIVE_DOC_DEPT.Bind(fleF023_ALTERNATIVE_DOCTOR_NBR);
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
                dtlF023_ALTERNATIVE_DOCTOR_NBR.OccursWithFile = fleF023_ALTERNATIVE_DOCTOR_NBR;

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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:12:33 AM

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
            fleF023_ALTERNATIVE_DOCTOR_NBR.Transaction = m_trnTRANS_UPDATE;


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:12:33 AM

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
                fleF023_ALTERNATIVE_DOCTOR_NBR.Dispose();
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

        #endregion

        #region "Update Validation"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.

        #endregion


        #region "RecordBuffer Events"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:12:33 AM



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



        private void fldF023_ALTERNATIVE_DOCTOR_NBR_ALTERNATIVE_DOC_NBR_LookupOn()
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




        protected override void SaveParamsReceived()
        {

            try
            {
                SaveReceivingParams(W_DOC_NBR, W_DOC_DEPT);


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
                Receiving(W_DOC_NBR, W_DOC_DEPT);


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



        private void fldF023_ALTERNATIVE_DOCTOR_NBR_ALTERNATIVE_DOC_NBR_Process()
        {

            try
            {

                fleF023_ALTERNATIVE_DOCTOR_NBR.set_SetValue("ALTERNATIVE_DOC_DEPT", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT"));
                Display(ref fldF023_ALTERNATIVE_DOCTOR_NBR_ALTERNATIVE_DOC_DEPT);


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
                while (fleF023_ALTERNATIVE_DOCTOR_NBR.ForMissing())
                {
                    m_strWhere = new StringBuilder(GetWhereCondition(fleF023_ALTERNATIVE_DOCTOR_NBR.ElementOwner("DOC_DEPT"), W_DOC_DEPT.Value, ref blnAddWhere));
                    m_strWhere.Append(GetWhereCondition(fleF023_ALTERNATIVE_DOCTOR_NBR.ElementOwner("DOC_NBR"), W_DOC_NBR.Value, ref blnAddWhere));
                    fleF023_ALTERNATIVE_DOCTOR_NBR.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
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
                Page.PageTitle = "ALTERNATIVE";



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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:12:21 AM
        //#-----------------------------------------
        protected override bool Append()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:12:21 AM
                Accept(ref fldF023_ALTERNATIVE_DOCTOR_NBR_ALTERNATIVE_DOC_NBR);
                Display(ref fldF023_ALTERNATIVE_DOCTOR_NBR_ALTERNATIVE_DOC_DEPT);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:12:21 AM
        //#-----------------------------------------
        protected override bool Update()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:12:21 AM
                while (fleF023_ALTERNATIVE_DOCTOR_NBR.For())
                {
                    fleF023_ALTERNATIVE_DOCTOR_NBR.PutData(false, PutTypes.Deleted);
                }
                while (fleF023_ALTERNATIVE_DOCTOR_NBR.For())
                {
                    fleF023_ALTERNATIVE_DOCTOR_NBR.PutData();
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:12:21 AM
        //#-----------------------------------------
        protected override bool Delete()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:12:21 AM
                fleF023_ALTERNATIVE_DOCTOR_NBR.DeletedRecord = true;
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
        //# dtlF023_ALTERNATIVE_DOCTOR_NBR_EditClick Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:12:21 AM
        //#-----------------------------------------
        private void dtlF023_ALTERNATIVE_DOCTOR_NBR_EditClick(DataList source, GridButtonEventArgs GridButtonEventArgs)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:12:33 AM
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:12:21 AM
        //#-----------------------------------------
        private void dsrDesigner_01_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:12:33 AM
                Accept(ref fldF023_ALTERNATIVE_DOCTOR_NBR_ALTERNATIVE_DOC_NBR);
                Display(ref fldF023_ALTERNATIVE_DOCTOR_NBR_ALTERNATIVE_DOC_DEPT);
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

