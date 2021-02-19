
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

    partial class Billing_M020B : BasePage
    {

        #region " Form Designer Generated Code "





        public Billing_M020B()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "M020B";

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
            dtlF020_RPT.EditClick += dtlF020_RPT_EditClick;
            base.Page_Load();

            // TODO: If any DESIGNER procedures function on occurring FILES or TEMPORARIES, set the grid's AllowSelectRowButton property to TRUE.



        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            X_DOC_NBR = new CoreCharacter("X_DOC_NBR", 3, this, Common.cEmptyString);
            fleF020_RPT = new SqlFileObject(this, FileTypes.Primary, 18, "INDEXED", "F020_RPT", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF020_RPT_MSTR = new SqlFileObject(this, FileTypes.Reference, 0, "INDEXED", "F020_RPT_MSTR", "", false, false, false, 0, "m_cnnQUERY");

           
            fleF020_RPT_MSTR.Access += fleF020_RPT_MSTR_Access;
            fleF020_RPT.InitializeItems += fleF020_RPT_InitializeItems;
        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;
            fleF020_RPT_MSTR.Access -= fleF020_RPT_MSTR_Access;
            fldF020_RPT_REPORT_ID.LookupOn -= fldF020_RPT_REPORT_ID_LookupOn;
            fldF020_RPT_REPORT_ID.LookupNotOn -= fldF020_RPT_REPORT_ID_LookupNotOn;

            dsrDesigner_01.Click -= dsrDesigner_01_Click;
            dtlF020_RPT.EditClick -= dtlF020_RPT_EditClick;
            fleF020_RPT.InitializeItems -= fleF020_RPT_InitializeItems;

        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private SqlConnection m_cnnQUERY = new SqlConnection();
        private SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
        private SqlTransaction m_trnTRANS_UPDATE;
        private CoreCharacter X_DOC_NBR;
        private SqlFileObject fleF020_RPT;

        private void fleF020_RPT_InitializeItems(bool Fixed)
        {

            try
            {
                if (!Fixed)
                    fleF020_RPT.set_SetValue("DOC_NBR", true, X_DOC_NBR.Value);


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

        private SqlFileObject fleF020_RPT_MSTR;

        private void fleF020_RPT_MSTR_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleF020_RPT_MSTR.ElementOwner("REPORT_ID")).Append(" = ").Append((fleF020_RPT.GetDecimalValue("REPORT_ID")));

                strText.Append(" ORDER BY ").Append(fleF020_RPT_MSTR.ElementOwner("REPORT_ID"));
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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:13:05 AM

        protected TextBox fldF020_RPT_DOC_NBR;
        protected TextBox fldF020_RPT_REPORT_ID;
        protected TextBox fldF020_RPT_MSTR_REPORT_SHORT_NAME;

        protected ComboBox fldF020_RPT_REPORT_FLAG;

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
                    case "FLDGRDF020_RPT_DOC_NBR":
                        fldF020_RPT_DOC_NBR = (TextBox)DataListField;
                        CoreField = fldF020_RPT_DOC_NBR;
                        fldF020_RPT_DOC_NBR.Bind(fleF020_RPT);
                        break;
                    case "FLDGRDF020_RPT_REPORT_ID":
                        fldF020_RPT_REPORT_ID = (TextBox)DataListField;

                        fldF020_RPT_REPORT_ID.LookupOn -= fldF020_RPT_REPORT_ID_LookupOn;
                        fldF020_RPT_REPORT_ID.LookupOn += fldF020_RPT_REPORT_ID_LookupOn;

                        fldF020_RPT_REPORT_ID.LookupNotOn -= fldF020_RPT_REPORT_ID_LookupNotOn;
                        fldF020_RPT_REPORT_ID.LookupNotOn += fldF020_RPT_REPORT_ID_LookupNotOn;
                        CoreField = fldF020_RPT_REPORT_ID;
                        fldF020_RPT_REPORT_ID.Bind(fleF020_RPT);
                        break;
                    case "FLDGRDF020_RPT_MSTR_REPORT_SHORT_NAME":
                        fldF020_RPT_MSTR_REPORT_SHORT_NAME = (TextBox)DataListField;
                        CoreField = fldF020_RPT_MSTR_REPORT_SHORT_NAME;
                        fldF020_RPT_MSTR_REPORT_SHORT_NAME.Bind(fleF020_RPT_MSTR);
                        break;
                    case "FLDGRDF020_RPT_REPORT_FLAG":
                        fldF020_RPT_REPORT_FLAG = (ComboBox)DataListField;
                        CoreField = fldF020_RPT_REPORT_FLAG;
                        fldF020_RPT_REPORT_FLAG.Bind(fleF020_RPT);
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
                dtlF020_RPT.OccursWithFile = fleF020_RPT;

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
            fleF020_RPT.Transaction = m_trnTRANS_UPDATE;


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
                fleF020_RPT_MSTR.Connection = m_cnnQUERY;


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
                fleF020_RPT.Dispose();
                fleF020_RPT_MSTR.Dispose();


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



        private void fldF020_RPT_REPORT_ID_LookupOn()
        {

            try
            {
                StringBuilder strSQL = new StringBuilder(" WHERE ");
                strSQL.Append("     ").Append(fleF020_RPT_MSTR.ElementOwner("REPORT_ID")).Append(" = ").Append((FieldText));

                fleF020_RPT_MSTR.GetData(strSQL.ToString(), GetDataOptions.IsOptional);
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




        private void fldF020_RPT_REPORT_ID_LookupNotOn(ref bool LookupNotOnExecuted)
        {

            try
            {
                bool blnAlreadyExists = false;
                StringBuilder strSQL = new StringBuilder("SELECT ").Append(fleF020_RPT.ElementOwner("DOC_NBR"));
                strSQL.Append(" FROM ");
                strSQL.Append(fleF020_RPT.TableNameWithAlias());
                strSQL.Append(" WHERE ");
                strSQL.Append("     ").Append(fleF020_RPT.ElementOwner("DOC_NBR")).Append(" = ").Append(Common.StringToField(fleF020_RPT.GetStringValue("DOC_NBR")));
                strSQL.Append(" And ").Append(fleF020_RPT.ElementOwner("REPORT_ID")).Append(" = ").Append((FieldValue));

                if (!LookupNotOn(strSQL, fleF020_RPT, new string[] { "DOC_NBR", "REPORT_ID" }, new Object[] { fleF020_RPT.GetStringValue("DOC_NBR"), FieldValue }))
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




        protected override void SaveParamsReceived()
        {

            try
            {
                SaveReceivingParams(X_DOC_NBR);


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
                Receiving(X_DOC_NBR);


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
                while (fleF020_RPT.ForMissing())
                {
                    m_strWhere = new StringBuilder(GetWhereCondition(fleF020_RPT.ElementOwner("DOC_NBR"), X_DOC_NBR.Value, ref blnAddWhere));
                    fleF020_RPT.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
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
                Page.PageTitle = "Doctor report generation exception";



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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:13:05 AM
        //#-----------------------------------------
        protected override bool Append()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:13:05 AM
                Display(ref fldF020_RPT_DOC_NBR);
                Accept(ref fldF020_RPT_REPORT_ID);
                Display(ref fldF020_RPT_MSTR_REPORT_SHORT_NAME);
                Accept(ref fldF020_RPT_REPORT_FLAG);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:13:05 AM
        //#-----------------------------------------
        protected override bool Update()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:13:05 AM
                while (fleF020_RPT.For())
                {
                    fleF020_RPT.PutData(false, PutTypes.Deleted);
                }
                while (fleF020_RPT.For())
                {
                    fleF020_RPT.PutData();
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
                fleF020_RPT.DeletedRecord = true;
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
        private void dtlF020_RPT_EditClick(DataList source, GridButtonEventArgs GridButtonEventArgs)
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

        //#-----------------------------------------
        //# dsrDesigner_01_Click Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:13:05 AM
        //#-----------------------------------------
        private void dsrDesigner_01_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:13:05 AM
                Display(ref fldF020_RPT_DOC_NBR);
                if (!fleF020_RPT.NewRecord)
                {
                    Display(ref fldF020_RPT_REPORT_ID);
                }
                else
                {
                    Accept(ref fldF020_RPT_REPORT_ID);
                }
                Display(ref fldF020_RPT_MSTR_REPORT_SHORT_NAME);
                Accept(ref fldF020_RPT_REPORT_FLAG);
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

