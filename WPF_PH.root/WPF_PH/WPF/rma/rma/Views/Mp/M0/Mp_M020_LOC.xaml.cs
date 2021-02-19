
#region "Screen Comments"

// #> PROGRAM-ID.     M020B.QKS
// ((C)) Dyad Technologies
// PROGRAM PURPOSE : MAINTENANCE OF DOCTOR REPORTS REQUEST
// MODIFICATION HISTORY
// DATE   WHO          DESCRIPTION
// 2013/Feb/28  MC         - ORIGINAL 

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

    partial class Mp_M020_LOC : BasePage
    {

        #region " Form Designer Generated Code "





        public Mp_M020_LOC()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "M020_LOC";

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
            dtlF020L_DOC_LOCATIONS.EditClick += dtlF020L_DOC_LOCATIONS_EditClick;
            base.Page_Load();

            // TODO: If any DESIGNER procedures function on occurring FILES or TEMPORARIES, set the grid's AllowSelectRowButton property to TRUE.



        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Master, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF020L_DOC_LOCATIONS = new SqlFileObject(this, FileTypes.Detail, 10, "INDEXED", "F020L_DOC_LOCATIONS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF030_LOCATIONS_MSTR = new SqlFileObject(this, FileTypes.Reference, 0, "[101C].INDEXED", "F030_LOCATIONS_MSTR", "", false, false, false, 0, "m_cnnQUERY");
            W_LOC_NBR = new CoreCharacter("W_LOC_NBR", 4, this, Common.cEmptyString);
           

            fleF030_LOCATIONS_MSTR.Access += fleF030_LOCATIONS_MSTR_Access;
        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;

            dsrDesigner_01.Click -= dsrDesigner_01_Click;
            fleF030_LOCATIONS_MSTR.Access -= fleF030_LOCATIONS_MSTR_Access;

        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private SqlConnection m_cnnQUERY = new SqlConnection();
        private SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
        private SqlTransaction m_trnTRANS_UPDATE;
        private SqlFileObject fleF020_DOCTOR_MSTR;
        private SqlFileObject fleF020L_DOC_LOCATIONS;

        private SqlFileObject fleF030_LOCATIONS_MSTR;

        private void fleF030_LOCATIONS_MSTR_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleF030_LOCATIONS_MSTR.ElementOwner("LOC_NBR")).Append(" = ").Append(Common.StringToField(W_LOC_NBR.Value));

                strText.Append(" ORDER BY ").Append(fleF030_LOCATIONS_MSTR.ElementOwner("LOC_NBR"));
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
        private CoreCharacter W_LOC_NBR;

        #endregion

        #region "Standard Generated Procedures"

        #region "Grid Field Declarations"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:13:05 AM

        protected TextBox fldF020L_DOC_LOCATIONS_DOC_LOC;

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:13:05 AM

        //#-----------------------------------------
        //# GetGridFieldObject Procedure.
        //#-----------------------------------------

        protected override void GetGridFieldObject(object DataListField, ref object CoreField, string Name)
        {

            try
            {
                switch (Name.ToUpper())
                {
                    case "FLDGRDF020L_DOC_LOCATIONS_DOC_LOC":
                        fldF020L_DOC_LOCATIONS_DOC_LOC = (TextBox)DataListField;
                        CoreField = fldF020L_DOC_LOCATIONS_DOC_LOC;
                        fldF020L_DOC_LOCATIONS_DOC_LOC.Bind(fleF020L_DOC_LOCATIONS);
                        fldF020L_DOC_LOCATIONS_DOC_LOC.Edit -= FldF020L_DOC_LOCATIONS_DOC_LOC_Edit;
                        fldF020L_DOC_LOCATIONS_DOC_LOC.Edit += FldF020L_DOC_LOCATIONS_DOC_LOC_Edit;
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
                dtlF020L_DOC_LOCATIONS.OccursWithFile = fleF020L_DOC_LOCATIONS;

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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:13:05 AM

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
            fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
            fleF020L_DOC_LOCATIONS.Transaction = m_trnTRANS_UPDATE;


           

        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:13:05 AM

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
                fleF020_DOCTOR_MSTR.Dispose();
                fleF020L_DOC_LOCATIONS.Dispose();


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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:13:05 AM



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
                SaveReceivingParams(fleF020_DOCTOR_MSTR);


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
                Receiving(fleF020_DOCTOR_MSTR);


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
                while (fleF020L_DOC_LOCATIONS.ForMissing())
                {
                    m_strWhere = new StringBuilder(GetWhereCondition(fleF020L_DOC_LOCATIONS.ElementOwner("DOC_NBR"), fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR"), ref blnAddWhere));
                    fleF020L_DOC_LOCATIONS.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
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

        private void FldF020L_DOC_LOCATIONS_DOC_LOC_Edit()
        {

            try
            {

                W_LOC_NBR.Value = fleF020L_DOC_LOCATIONS.GetStringValue("DOC_LOC");
                Internal_CHECK_LOCATION();


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

        private bool Internal_CHECK_LOCATION()
        {


            try
            {

                if (QDesign.NULL(W_LOC_NBR.Value) != QDesign.NULL(" "))
                {
                    // --> GET F030_LOCATIONS_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF030_LOCATIONS_MSTR.ElementOwner("LOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(W_LOC_NBR.Value));

                    fleF030_LOCATIONS_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F030_LOCATIONS_MSTR <--
                    if (!AccessOk)
                    {
                        ErrorMessage("LOCATION IS NOT ON LOCATIONS MASTER, PLEASE REENTER");
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
                Page.PageTitle = "Doctor Location";



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
                 Accept(ref fldF020L_DOC_LOCATIONS_DOC_LOC);
                
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:13:05 AM
        //#-----------------------------------------
        protected override bool Update()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:13:05 AM
                while (fleF020L_DOC_LOCATIONS.For())
                {
                    fleF020L_DOC_LOCATIONS.PutData(false, PutTypes.Deleted);
                }
                while (fleF020L_DOC_LOCATIONS.For())
                {
                    fleF020L_DOC_LOCATIONS.PutData();
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:13:05 AM
        //#-----------------------------------------
        protected override bool Delete()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:13:05 AM
                fleF020L_DOC_LOCATIONS.DeletedRecord = true;
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
        //# dtlF020_RPT_EditClick Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:13:05 AM
        //#-----------------------------------------
        private void dtlF020L_DOC_LOCATIONS_EditClick(DataList source, GridButtonEventArgs GridButtonEventArgs)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:13:05 AM
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

        
        private void dsrDesigner_01_Click(object sender, System.EventArgs e)
        {
            try
            {
                Accept(ref fldF020L_DOC_LOCATIONS_DOC_LOC);

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

