
#region "Screen Comments"

// 2013/may/02 MC m010_crm.qks
// - allow user to create notes for different action
// - this program can be called from m010.qks from designer `note`
// or d003.cbl from option `B`

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

    partial class Moira_M010_CRM : BasePage
    {

        #region " Form Designer Generated Code "





        public Moira_M010_CRM()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "M010_CRM";

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
            dtlF010_CRM.EditClick += dtlF010_CRM_EditClick;
            base.Page_Load();

            // TODO: If any DESIGNER procedures function on occurring FILES or TEMPORARIES, set the grid's AllowSelectRowButton property to TRUE.



        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            W_PAT_IKEY = new CoreCharacter("W_PAT_IKEY", 15, this, Common.cEmptyString);
            W_BATCH_NBR = new CoreCharacter("W_BATCH_NBR", 8, this, Common.cEmptyString);
            W_CLAIM_NBR = new CoreDecimal("W_CLAIM_NBR", 2, this);
            W_CALL_PGM = new CoreCharacter("W_CALL_PGM", 4, this, Common.cEmptyString);
            W_PAT_NAME = new CoreCharacter("W_PAT_NAME", 25, this, Common.cEmptyString);
            DTL_SEQ_NBR = new CoreDecimal("DTL_SEQ_NBR", 8, this, 0m);
            W_TIME = new CoreDecimal("W_TIME", 6, this);
            fleF010_PAT_MSTR = new SqlFileObject(this, FileTypes.Designer, 0, "INDEXED", "F010_PAT_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF010_CRM = new SqlFileObject(this, FileTypes.Primary, 15, "INDEXED", "F010_CRM", "", false, false, false, 0, "m_trnTRANS_UPDATE");

          
            fleF010_PAT_MSTR.Access += fleF010_PAT_MSTR_Access;
            fleF010_CRM.InitializeItems += fleF010_CRM_InitializeItems;
        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;
            fleF010_PAT_MSTR.Access -= fleF010_PAT_MSTR_Access;
            fldF010_CRM_KEY_DTL_SEQ_NBR.LookupNotOn -= fldF010_CRM_KEY_DTL_SEQ_NBR_LookupNotOn;

            dsrDesigner_01.Click -= dsrDesigner_01_Click;
            dtlF010_CRM.EditClick -= dtlF010_CRM_EditClick;
            fleF010_CRM.InitializeItems -= fleF010_CRM_InitializeItems;
        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private SqlConnection m_cnnQUERY = new SqlConnection();
        private SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
        private SqlTransaction m_trnTRANS_UPDATE;
        private CoreCharacter W_PAT_IKEY;
        private CoreCharacter W_BATCH_NBR;
        private CoreDecimal W_CLAIM_NBR;
        private CoreCharacter W_CALL_PGM;
        private CoreCharacter W_PAT_NAME;
        private CoreDecimal DTL_SEQ_NBR;
        private CoreDecimal W_TIME;
        private SqlFileObject fleF010_PAT_MSTR;

        private void fleF010_PAT_MSTR_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleF010_PAT_MSTR.ElementOwner("KEY_PAT_MSTR")).Append(" = ").Append(Common.StringToField(W_PAT_IKEY.Value));

                strText.Append(" ORDER BY ").Append(fleF010_PAT_MSTR.ElementOwner("KEY_PAT_MSTR"));
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

        private SqlFileObject fleF010_CRM;

        private void fleF010_CRM_InitializeItems(bool Fixed)
        {

            try
            {
                if (!Fixed)
                    fleF010_CRM.set_SetValue("KEY_PAT_MSTR", true, W_PAT_IKEY.Value);
                if (!Fixed)
                    fleF010_CRM.set_SetValue("CLMHDR_BATCH_NBR", true, W_BATCH_NBR.Value);
                if (!Fixed)
                    fleF010_CRM.set_SetValue("CLMHDR_CLAIM_NBR", true, W_CLAIM_NBR.Value);
                if (!Fixed)
                    fleF010_CRM.set_SetValue("GHOST_DATE_DESCENDING", true, (20991231 - QDesign.SysDate(ref m_cnnQUERY)));
                if (!Fixed)
                    fleF010_CRM.set_SetValue("DATE_ASSIGNED", true, QDesign.SysDate(ref m_cnnQUERY));
                if (!Fixed)
                    fleF010_CRM.set_SetValue("TIME_ASSIGNED", true, (1000000 - (QDesign.SysTime(ref m_cnnQUERY) / 100)));


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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:39:45 AM

        protected DateControl fldF010_CRM_DATE_ASSIGNED;
        protected TextBox fldF010_CRM_CLMHDR_BATCH_NBR;
        protected TextBox fldF010_CRM_CLMHDR_CLAIM_NBR;
        protected ComboBox fldF010_CRM_ACTION_CODE;
        protected TextBox fldF010_CRM_KEY_DTL_SEQ_NBR;

        protected TextBox fldF010_CRM_FOLLOWUP_ACTION;

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:39:45 AM

        //#-----------------------------------------
        //# GetGridFieldObject Procedure.
        //#-----------------------------------------

        protected override void GetGridFieldObject(object DataListField, ref object CoreField, string Name)
        {

            try
            {
                switch (Name.ToUpper())
                {
                    case "FLDGRDF010_CRM_DATE_ASSIGNED":
                        fldF010_CRM_DATE_ASSIGNED = (DateControl)DataListField;
                        CoreField = fldF010_CRM_DATE_ASSIGNED;
                        fldF010_CRM_DATE_ASSIGNED.Bind(fleF010_CRM);
                        break;
                    case "FLDGRDF010_CRM_CLMHDR_BATCH_NBR":
                        fldF010_CRM_CLMHDR_BATCH_NBR = (TextBox)DataListField;
                        CoreField = fldF010_CRM_CLMHDR_BATCH_NBR;
                        fldF010_CRM_CLMHDR_BATCH_NBR.Bind(fleF010_CRM);
                        break;
                    case "FLDGRDF010_CRM_CLMHDR_CLAIM_NBR":
                        fldF010_CRM_CLMHDR_CLAIM_NBR = (TextBox)DataListField;
                        CoreField = fldF010_CRM_CLMHDR_CLAIM_NBR;
                        fldF010_CRM_CLMHDR_CLAIM_NBR.Bind(fleF010_CRM);
                        break;
                    case "FLDGRDF010_CRM_ACTION_CODE":
                        fldF010_CRM_ACTION_CODE = (ComboBox)DataListField;
                        CoreField = fldF010_CRM_ACTION_CODE;
                        fldF010_CRM_ACTION_CODE.Bind(fleF010_CRM);
                        break;
                    case "FLDGRDF010_CRM_KEY_DTL_SEQ_NBR":
                        fldF010_CRM_KEY_DTL_SEQ_NBR = (TextBox)DataListField;

                        fldF010_CRM_KEY_DTL_SEQ_NBR.LookupNotOn -= fldF010_CRM_KEY_DTL_SEQ_NBR_LookupNotOn;
                        fldF010_CRM_KEY_DTL_SEQ_NBR.LookupNotOn += fldF010_CRM_KEY_DTL_SEQ_NBR_LookupNotOn;
                        CoreField = fldF010_CRM_KEY_DTL_SEQ_NBR;
                        fldF010_CRM_KEY_DTL_SEQ_NBR.Bind(fleF010_CRM);
                        break;
                    case "FLDGRDF010_CRM_FOLLOWUP_ACTION":
                        fldF010_CRM_FOLLOWUP_ACTION = (TextBox)DataListField;
                        CoreField = fldF010_CRM_FOLLOWUP_ACTION;
                        fldF010_CRM_FOLLOWUP_ACTION.Bind(fleF010_CRM);
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
                dtlF010_CRM.OccursWithFile = fleF010_CRM;

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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:39:45 AM

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
            fleF010_PAT_MSTR.Transaction = m_trnTRANS_UPDATE;
            fleF010_CRM.Transaction = m_trnTRANS_UPDATE;


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:39:45 AM

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
                fleF010_PAT_MSTR.Dispose();
                fleF010_CRM.Dispose();


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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:39:45 AM
        //#-----------------------------------------
        protected override void DisplayFormatting()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:39:45 AM
                Display(ref fldW_PAT_IKEY);
                Display(ref fldW_PAT_NAME);
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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:39:45 AM

        //#-----------------------------------------
        //# BindFields Procedure.
        //#-----------------------------------------

        public override void BindFields()
        {
            try
            {
                fldW_PAT_IKEY.Bind(W_PAT_IKEY);
                fldW_PAT_NAME.Bind(W_PAT_NAME);

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



        private void fldF010_CRM_KEY_DTL_SEQ_NBR_LookupNotOn(ref bool LookupNotOnExecuted)
        {

            try
            {
                bool blnAlreadyExists = false;
                StringBuilder strSQL = new StringBuilder("SELECT ").Append(fleF010_CRM.ElementOwner("KEY_PAT_MSTR"));
                strSQL.Append(" FROM ");
                strSQL.Append(fleF010_CRM.TableNameWithAlias());
                strSQL.Append(" WHERE ");
                strSQL.Append("     ").Append(fleF010_CRM.ElementOwner("KEY_PAT_MSTR")).Append(" = ").Append(Common.StringToField(fleF010_CRM.GetStringValue("KEY_PAT_MSTR")));
                strSQL.Append(" And ").Append(fleF010_CRM.ElementOwner("CLMHDR_BATCH_NBR")).Append(" = ").Append(Common.StringToField(fleF010_CRM.GetStringValue("CLMHDR_BATCH_NBR")));
                strSQL.Append(" And ").Append(fleF010_CRM.ElementOwner("CLMHDR_CLAIM_NBR")).Append(" = ").Append((fleF010_CRM.GetDecimalValue("CLMHDR_CLAIM_NBR")));
                strSQL.Append(" And ").Append(fleF010_CRM.ElementOwner("GHOST_DATE_DESCENDING")).Append(" = ").Append((fleF010_CRM.GetDecimalValue("GHOST_DATE_DESCENDING")));
                strSQL.Append(" And ").Append(fleF010_CRM.ElementOwner("DATE_ASSIGNED")).Append(" = ").Append(fleF010_CRM.GetNumericDateValue("DATE_ASSIGNED"));
                strSQL.Append(" And ").Append(fleF010_CRM.ElementOwner("TIME_ASSIGNED")).Append(" = ").Append((fleF010_CRM.GetDecimalValue("TIME_ASSIGNED")));
                strSQL.Append(" And ").Append(fleF010_CRM.ElementOwner("KEY_DTL_SEQ_NBR")).Append(" = ").Append((FieldValue));

                if (!LookupNotOn(strSQL, fleF010_CRM, new string[] { "KEY_PAT_MSTR", "CLMHDR_BATCH_NBR", "CLMHDR_CLAIM_NBR", "GHOST_DATE_DESCENDING", "DATE_ASSIGNED", "TIME_ASSIGNED", "KEY_DTL_SEQ_NBR" }, new Object[] { fleF010_CRM.GetStringValue("KEY_PAT_MSTR"), fleF010_CRM.GetStringValue("CLMHDR_BATCH_NBR"), fleF010_CRM.GetDecimalValue("CLMHDR_CLAIM_NBR"), fleF010_CRM.GetDecimalValue("GHOST_DATE_DESCENDING"), fleF010_CRM.GetNumericDateValue("DATE_ASSIGNED"), fleF010_CRM.GetDecimalValue("TIME_ASSIGNED"), FieldValue }))
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
                SaveReceivingParams(W_PAT_IKEY, W_BATCH_NBR, W_CLAIM_NBR, W_CALL_PGM);


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
                Receiving(W_PAT_IKEY, W_BATCH_NBR, W_CLAIM_NBR, W_CALL_PGM);


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

        protected override bool Append()
        {


            try
            {

                Display(ref fldF010_CRM_DATE_ASSIGNED);
                Display(ref fldF010_CRM_CLMHDR_BATCH_NBR);
                Display(ref fldF010_CRM_CLMHDR_CLAIM_NBR);
                Accept(ref fldF010_CRM_ACTION_CODE);
                DTL_SEQ_NBR.Value = DTL_SEQ_NBR.Value + 1;
                fleF010_CRM.set_SetValue("KEY_DTL_SEQ_NBR", DTL_SEQ_NBR.Value);
                Display(ref fldF010_CRM_KEY_DTL_SEQ_NBR);
                Accept(ref fldF010_CRM_FOLLOWUP_ACTION);

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


        protected override bool Entry()
        {


            try
            {

              

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


        private bool Internal_GET_NAME()
        {


            try
            {

                // --> GET F010_PAT_MSTR <--
                fleF010_PAT_MSTR.GetData();
                // --> End GET F010_PAT_MSTR <--
                W_PAT_NAME.Value = QDesign.Pack(QDesign.LeftJustify(QDesign.RTrim(fleF010_PAT_MSTR.GetStringValue("PAT_GIVEN_NAME_FIRST3") + fleF010_PAT_MSTR.GetStringValue("PAT_GIVEN_NAME_LAST14")))) + " " + QDesign.Pack(QDesign.LeftJustify(QDesign.RTrim(fleF010_PAT_MSTR.GetStringValue("PAT_SURNAME_FIRST6") + fleF010_PAT_MSTR.GetStringValue("PAT_SURNAME_LAST19"))));
                //Parent:PAT_GIVEN_NAME    'Parent:PAT_SURNAME
                Display(ref fldW_PAT_NAME);
                Display(ref fldW_PAT_IKEY);

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

                if (QDesign.NULL(W_CALL_PGM.Value) == QDesign.NULL("M010"))
                {
                    while (fleF010_CRM.ForMissing())
                    {
                        bool blnAddWhere = true;
                        m_strWhere = new StringBuilder(GetWhereCondition(fleF010_CRM.ElementOwner("KEY_PAT_MSTR"), W_PAT_IKEY.Value, ref blnAddWhere));
                        fleF010_CRM.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);

                    }
                }
                if (QDesign.NULL(W_CALL_PGM.Value) == QDesign.NULL("D003"))
                {
                    while (fleF010_CRM.ForMissing())
                    {
                        bool blnAddWhere = true;
                        m_strWhere = new StringBuilder(GetWhereCondition(fleF010_CRM.ElementOwner("KEY_PAT_MSTR"), W_PAT_IKEY.Value, ref blnAddWhere));
                        m_strWhere.Append(GetWhereCondition(fleF010_CRM.ElementOwner("CLMHDR_CLAIM_NBR"), W_CLAIM_NBR.Value, ref blnAddWhere));
                        m_strWhere.Append(GetWhereCondition(fleF010_CRM.ElementOwner("CLMHDR_BATCH_NBR"), W_BATCH_NBR.Value, ref blnAddWhere));
                        fleF010_CRM.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);

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


        protected override bool PostFind()
        {


            try
            {

                Internal_GET_NAME();

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


        protected override bool PreEntry()
        {


            try
            {

                Internal_GET_NAME();

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


        protected override bool PreUpdate()
        {


            try
            {

                W_TIME.Value = QDesign.SysTime(ref m_cnnQUERY) / 100;
                while (fleF010_CRM.For())
                {
                    if (NewRecord())
                    {
                        fleF010_CRM.set_SetValue("TIME_ASSIGNED", (1000000 - W_TIME.Value));
                        fleF010_CRM.set_SetValue("GHOST_DATE_DESCENDING", (20991231 - QDesign.SysDate(ref m_cnnQUERY)));
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
                Page.PageTitle = "????";
                // TODO: Replace ???? with proper title.



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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:39:45 AM
        //#-----------------------------------------
        protected override bool Update()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:39:45 AM
                while (fleF010_CRM.For())
                {
                    fleF010_CRM.PutData(false, PutTypes.Deleted);
                }
                while (fleF010_CRM.For())
                {
                    fleF010_CRM.PutData();
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:39:45 AM
        //#-----------------------------------------
        protected override bool Delete()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:39:45 AM
                fleF010_CRM.DeletedRecord = true;
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
        //# dtlF010_CRM_EditClick Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:39:45 AM
        //#-----------------------------------------
        private void dtlF010_CRM_EditClick(DataList source, GridButtonEventArgs GridButtonEventArgs)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:39:45 AM
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:39:45 AM
        //#-----------------------------------------
        private void dsrDesigner_01_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:39:45 AM
                if (!fleF010_CRM.NewRecord)
                {
                    Display(ref fldF010_CRM_DATE_ASSIGNED);
                }
                else
                {
                    Accept(ref fldF010_CRM_DATE_ASSIGNED);
                }
                if (!fleF010_CRM.NewRecord)
                {
                    Display(ref fldF010_CRM_CLMHDR_BATCH_NBR);
                }
                else
                {
                    Accept(ref fldF010_CRM_CLMHDR_BATCH_NBR);
                }
                if (!fleF010_CRM.NewRecord)
                {
                    Display(ref fldF010_CRM_CLMHDR_CLAIM_NBR);
                }
                else
                {
                    Accept(ref fldF010_CRM_CLMHDR_CLAIM_NBR);
                }
                if (!fleF010_CRM.NewRecord)
                {
                    Display(ref fldF010_CRM_ACTION_CODE);
                }
                else
                {
                    Accept(ref fldF010_CRM_ACTION_CODE);
                }
                if (!fleF010_CRM.NewRecord)
                {
                    Display(ref fldF010_CRM_KEY_DTL_SEQ_NBR);
                }
                else
                {
                    Accept(ref fldF010_CRM_KEY_DTL_SEQ_NBR);
                }
                Accept(ref fldF010_CRM_FOLLOWUP_ACTION);
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

