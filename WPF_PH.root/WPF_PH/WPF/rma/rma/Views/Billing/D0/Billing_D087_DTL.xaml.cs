
#region "Screen Comments"

// PROGRAM: d087_dtl.qks
// PURPOSE:
// allow the entry of claims that have been submittedly rejected by the
// local OHIP office. No electronic file can be obtained from OHIP so the
// claims must be entered by hand from the hard copy report.
// Note that originally only the doctor number was entered (when this database
// was kep in LOTUS 123.  Therefore the claim number entry is optional
// but the doctor number must be entered. If a claim number is entered
// the doctor number is extracted and the doctor nbr field defaulted.
// The PED is defaulted from the Constants master but can be changed since
// some entry is done after month end.
// MODIFICATION HISTORY
// DATE        WHO WHY
// 2003/oct/10 b.e. - original
// 2003/oct/10 b.e. - alpha doctor number
// 2007/oct/15 M.C.      - show diag code, replace with last modify date

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

    partial class Billing_D087_DTL : BasePage
    {

        #region " Form Designer Generated Code "





        public Billing_D087_DTL()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "D087_DTL";

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
            dtlF087SUBMITTEDREJECTEDCLAIMSDTL.EditClick += dtlF087SUBMITTEDREJECTEDCLAIMSDTL_EditClick;
           
            base.Page_Load();

            // TODO: If any DESIGNER procedures function on occurring FILES or TEMPORARIES, set the grid's AllowSelectRowButton property to TRUE.



        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            W_CLAIM_ID = new CoreCharacter("W_CLAIM_ID", 11, this, Common.cEmptyString);
            W_PED = new CoreDate("W_PED", this);
            W_EDT_PROCESS_DATE = new CoreDate("W_EDT_PROCESS_DATE", this);
            fleF087SUBMITTEDREJECTEDCLAIMSDTL = new SqlFileObject(this, FileTypes.Primary, 5, "INDEXED", "F087_SUBMITTED_REJECTED_CLAIMS_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF087SUBMITTEDREJECTEDCLAIMSHDR = new SqlFileObject(this, FileTypes.Master, 0, "INDEXED", "F087_SUBMITTED_REJECTED_CLAIMS_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            FOUND = new CoreCharacter("FOUND", 1, this, Common.cEmptyString);
            W_DATE = new CoreDate("W_DATE", this);
            W_DATE.GetInitialValue += W_DATE_GetInitialValue;
        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;

            dsrDesigner_01.Click -= dsrDesigner_01_Click;
            dtlF087SUBMITTEDREJECTEDCLAIMSDTL.EditClick += dtlF087SUBMITTEDREJECTEDCLAIMSDTL_EditClick;
            W_DATE.GetInitialValue -= W_DATE_GetInitialValue;
        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private SqlConnection m_cnnQUERY = new SqlConnection();
        private SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
        private SqlTransaction m_trnTRANS_UPDATE;
        private CoreCharacter W_CLAIM_ID;
        private CoreDate W_PED;
        private CoreDate W_EDT_PROCESS_DATE;
        private SqlFileObject fleF087SUBMITTEDREJECTEDCLAIMSDTL;
        private SqlFileObject fleF087SUBMITTEDREJECTEDCLAIMSHDR;
        private CoreCharacter FOUND;
        private CoreDate W_DATE;
        private void W_DATE_GetInitialValue()
        {
            W_DATE.InitialValue = QDesign.SysDate(ref m_cnnQUERY);
        }

        #endregion

        #region "Standard Generated Procedures"

        #region "Grid Field Declarations"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 9:56:20 AM

        protected TextBox fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_OMA_SERVICE_CD_AND_SUFFIX;
        protected DateControl fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_SERVICE_DATE;
        protected TextBox fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_NBR_SERV;
        protected TextBox fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_AMOUNT_SUBMITTED;
        protected TextBox fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_DTL_ERR_EXPLAN_CD;
        protected TextBox fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_DTL_ERR_CD_1;
        protected TextBox fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_DTL_ERR_CD_2;
        protected TextBox fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_DTL_ERR_CD_3;
        protected TextBox fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_DTL_ERR_CD_4;
        protected TextBox fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_DTL_ERR_CD_5;
        protected TextBox fldF087SUBMITTEDREJECTEDCLAIMSDTL_LAST_MOD_USER_ID;
        protected TextBox fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_DTL_ERR_8_EXPLAN_CD;
        protected TextBox fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_DTL_ERR_8_EXPLAN_DESC;

        protected TextBox fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_DTL_DIAG_CD;

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 9:56:20 AM

        //#-----------------------------------------
        //# GetGridFieldObject Procedure.
        //#-----------------------------------------

        protected override void GetGridFieldObject(object DataListField, ref object CoreField, string Name)
        {

            try
            {
                switch (Name.ToUpper())
                {
                    case "FLDGRDF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_OMA_SERVICE_CD_AND_SUFFIX":
                        fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_OMA_SERVICE_CD_AND_SUFFIX = (TextBox)DataListField;
                        CoreField = fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_OMA_SERVICE_CD_AND_SUFFIX;
                        fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_OMA_SERVICE_CD_AND_SUFFIX.Bind(fleF087SUBMITTEDREJECTEDCLAIMSDTL);
                        break;
                    case "FLDGRDF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_SERVICE_DATE":
                        fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_SERVICE_DATE = (DateControl)DataListField;
                        CoreField = fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_SERVICE_DATE;
                        fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_SERVICE_DATE.Bind(fleF087SUBMITTEDREJECTEDCLAIMSDTL);
                        break;
                    case "FLDGRDF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_NBR_SERV":
                        fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_NBR_SERV = (TextBox)DataListField;
                        CoreField = fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_NBR_SERV;
                        fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_NBR_SERV.Bind(fleF087SUBMITTEDREJECTEDCLAIMSDTL);
                        break;
                    case "FLDGRDF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_AMOUNT_SUBMITTED":
                        fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_AMOUNT_SUBMITTED = (TextBox)DataListField;
                        CoreField = fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_AMOUNT_SUBMITTED;
                        fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_AMOUNT_SUBMITTED.Bind(fleF087SUBMITTEDREJECTEDCLAIMSDTL);
                        break;
                    case "FLDGRDF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_DTL_ERR_EXPLAN_CD":
                        fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_DTL_ERR_EXPLAN_CD = (TextBox)DataListField;
                        CoreField = fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_DTL_ERR_EXPLAN_CD;
                        fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_DTL_ERR_EXPLAN_CD.Bind(fleF087SUBMITTEDREJECTEDCLAIMSDTL);
                        break;
                    case "FLDGRDF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_DTL_ERR_CD_1":
                        fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_DTL_ERR_CD_1 = (TextBox)DataListField;
                        CoreField = fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_DTL_ERR_CD_1;
                        fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_DTL_ERR_CD_1.Bind(fleF087SUBMITTEDREJECTEDCLAIMSDTL);
                        break;
                    case "FLDGRDF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_DTL_ERR_CD_2":
                        fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_DTL_ERR_CD_2 = (TextBox)DataListField;
                        CoreField = fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_DTL_ERR_CD_2;
                        fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_DTL_ERR_CD_2.Bind(fleF087SUBMITTEDREJECTEDCLAIMSDTL);
                        break;
                    case "FLDGRDF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_DTL_ERR_CD_3":
                        fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_DTL_ERR_CD_3 = (TextBox)DataListField;
                        CoreField = fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_DTL_ERR_CD_3;
                        fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_DTL_ERR_CD_3.Bind(fleF087SUBMITTEDREJECTEDCLAIMSDTL);
                        break;
                    case "FLDGRDF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_DTL_ERR_CD_4":
                        fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_DTL_ERR_CD_4 = (TextBox)DataListField;
                        CoreField = fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_DTL_ERR_CD_4;
                        fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_DTL_ERR_CD_4.Bind(fleF087SUBMITTEDREJECTEDCLAIMSDTL);
                        break;
                    case "FLDGRDF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_DTL_ERR_CD_5":
                        fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_DTL_ERR_CD_5 = (TextBox)DataListField;
                        CoreField = fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_DTL_ERR_CD_5;
                        fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_DTL_ERR_CD_5.Bind(fleF087SUBMITTEDREJECTEDCLAIMSDTL);
                        break;
                    case "FLDGRDF087SUBMITTEDREJECTEDCLAIMSDTL_LAST_MOD_USER_ID":
                        fldF087SUBMITTEDREJECTEDCLAIMSDTL_LAST_MOD_USER_ID = (TextBox)DataListField;
                        CoreField = fldF087SUBMITTEDREJECTEDCLAIMSDTL_LAST_MOD_USER_ID;
                        fldF087SUBMITTEDREJECTEDCLAIMSDTL_LAST_MOD_USER_ID.Bind(fleF087SUBMITTEDREJECTEDCLAIMSDTL);
                        break;
                    case "FLDGRDF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_DTL_ERR_8_EXPLAN_CD":
                        fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_DTL_ERR_8_EXPLAN_CD = (TextBox)DataListField;
                        CoreField = fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_DTL_ERR_8_EXPLAN_CD;
                        fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_DTL_ERR_8_EXPLAN_CD.Bind(fleF087SUBMITTEDREJECTEDCLAIMSDTL);
                        break;
                    case "FLDGRDF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_DTL_ERR_8_EXPLAN_DESC":
                        fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_DTL_ERR_8_EXPLAN_DESC = (TextBox)DataListField;
                        CoreField = fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_DTL_ERR_8_EXPLAN_DESC;
                        fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_DTL_ERR_8_EXPLAN_DESC.Bind(fleF087SUBMITTEDREJECTEDCLAIMSDTL);
                        break;
                    case "FLDGRDF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_DTL_DIAG_CD":
                        fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_DTL_DIAG_CD = (TextBox)DataListField;
                        CoreField = fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_DTL_DIAG_CD;
                        fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_DTL_DIAG_CD.Bind(fleF087SUBMITTEDREJECTEDCLAIMSDTL);
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
                dtlF087SUBMITTEDREJECTEDCLAIMSDTL.OccursWithFile = fleF087SUBMITTEDREJECTEDCLAIMSDTL;

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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 9:56:20 AM

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
            fleF087SUBMITTEDREJECTEDCLAIMSDTL.Transaction = m_trnTRANS_UPDATE;
            fleF087SUBMITTEDREJECTEDCLAIMSHDR.Transaction = m_trnTRANS_UPDATE;


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 9:56:20 AM

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
                fleF087SUBMITTEDREJECTEDCLAIMSDTL.Dispose();
                fleF087SUBMITTEDREJECTEDCLAIMSHDR.Dispose();


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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 9:56:19 AM
        //#-----------------------------------------
        protected override void DisplayFormatting()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 9:56:19 AM
              
                Display(ref fldF087SUBMITTEDREJECTEDCLAIMSDTL_CLMHDR_BATCH_NBR);
                Display(ref fldF087SUBMITTEDREJECTEDCLAIMSDTL_CLMHDR_CLAIM_NBR);
                Display(ref fldF087SUBMITTEDREJECTEDCLAIMSHDR_EDT_ERR_H_CD_1);
                Display(ref fldF087SUBMITTEDREJECTEDCLAIMSHDR_EDT_ERR_H_CD_2);
                Display(ref fldF087SUBMITTEDREJECTEDCLAIMSHDR_EDT_ERR_H_CD_3);
                Display(ref fldF087SUBMITTEDREJECTEDCLAIMSHDR_EDT_ERR_H_CD_4);
                Display(ref fldF087SUBMITTEDREJECTEDCLAIMSHDR_EDT_ERR_H_CD_5);
                Display(ref fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_PROCESS_DATE);
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
        //# PreDisplayFormatting Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 9:56:19 AM
        //#-----------------------------------------
        protected override void PreDisplayFormatting()
        {
            try
            {
                

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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 9:56:20 AM

        //#-----------------------------------------
        //# BindFields Procedure.
        //#-----------------------------------------

        public override void BindFields()
        {
            try
            {
                
                fldF087SUBMITTEDREJECTEDCLAIMSDTL_CLMHDR_BATCH_NBR.Bind(fleF087SUBMITTEDREJECTEDCLAIMSDTL);
                fldF087SUBMITTEDREJECTEDCLAIMSDTL_CLMHDR_CLAIM_NBR.Bind(fleF087SUBMITTEDREJECTEDCLAIMSDTL);
                fldF087SUBMITTEDREJECTEDCLAIMSHDR_EDT_ERR_H_CD_1.Bind(fleF087SUBMITTEDREJECTEDCLAIMSHDR);
                fldF087SUBMITTEDREJECTEDCLAIMSHDR_EDT_ERR_H_CD_2.Bind(fleF087SUBMITTEDREJECTEDCLAIMSHDR);
                fldF087SUBMITTEDREJECTEDCLAIMSHDR_EDT_ERR_H_CD_3.Bind(fleF087SUBMITTEDREJECTEDCLAIMSHDR);
                fldF087SUBMITTEDREJECTEDCLAIMSHDR_EDT_ERR_H_CD_4.Bind(fleF087SUBMITTEDREJECTEDCLAIMSHDR);
                fldF087SUBMITTEDREJECTEDCLAIMSHDR_EDT_ERR_H_CD_5.Bind(fleF087SUBMITTEDREJECTEDCLAIMSHDR);
                fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_PROCESS_DATE.Bind(fleF087SUBMITTEDREJECTEDCLAIMSDTL);

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



        protected override void SaveParamsReceived()
        {

            try
            {
                SaveReceivingParams(W_CLAIM_ID, W_PED, W_EDT_PROCESS_DATE, fleF087SUBMITTEDREJECTEDCLAIMSHDR);


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
                Receiving(W_CLAIM_ID, W_PED, W_EDT_PROCESS_DATE, fleF087SUBMITTEDREJECTEDCLAIMSHDR);


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
                while (fleF087SUBMITTEDREJECTEDCLAIMSDTL.ForMissing())
                {
                    m_strWhere = new StringBuilder(GetWhereCondition(fleF087SUBMITTEDREJECTEDCLAIMSDTL.ElementOwner("CLMHDR_BATCH_NBR"), (W_CLAIM_ID.Value).PadRight(10).Substring(0, 8), ref blnAddWhere));
                    //Parent:SUBMITTED_REJECTED_CLAIM
                    m_strWhere.Append(GetWhereCondition(fleF087SUBMITTEDREJECTEDCLAIMSDTL.ElementOwner("CLMHDR_CLAIM_NBR"), (W_CLAIM_ID.Value).PadRight(10).Substring(8, 2), ref blnAddWhere));
                    //Parent:SUBMITTED_REJECTED_CLAIM
                    m_strWhere.Append(GetWhereCondition(fleF087SUBMITTEDREJECTEDCLAIMSDTL.ElementOwner("PED"), W_PED.Value, ref blnAddWhere));
                    m_strWhere.Append(GetWhereCondition(fleF087SUBMITTEDREJECTEDCLAIMSDTL.ElementOwner("EDT_PROCESS_DATE"), W_EDT_PROCESS_DATE.Value, ref blnAddWhere));
                    fleF087SUBMITTEDREJECTEDCLAIMSDTL.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
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
                Page.PageTitle = "SUBMISSION Time rejected Claim - Details";



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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 9:56:19 AM
        //#-----------------------------------------
        protected override bool Append()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 9:56:19 AM
                Accept(ref fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_OMA_SERVICE_CD_AND_SUFFIX);
                Accept(ref fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_SERVICE_DATE);
                Accept(ref fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_NBR_SERV);
                Accept(ref fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_AMOUNT_SUBMITTED);
                Accept(ref fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_DTL_ERR_EXPLAN_CD);
                Accept(ref fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_DTL_ERR_CD_1);
                Accept(ref fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_DTL_ERR_CD_2);
                Accept(ref fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_DTL_ERR_CD_3);
                Accept(ref fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_DTL_ERR_CD_4);
                Accept(ref fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_DTL_ERR_CD_5);
                Display(ref fldF087SUBMITTEDREJECTEDCLAIMSDTL_LAST_MOD_USER_ID);
                Accept(ref fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_DTL_ERR_8_EXPLAN_CD);
                Accept(ref fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_DTL_ERR_8_EXPLAN_DESC);
                Accept(ref fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_DTL_DIAG_CD);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 9:56:19 AM
        //#-----------------------------------------
        protected override bool Entry()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 9:56:19 AM
                
                Display(ref fldF087SUBMITTEDREJECTEDCLAIMSDTL_CLMHDR_BATCH_NBR);
                Display(ref fldF087SUBMITTEDREJECTEDCLAIMSDTL_CLMHDR_CLAIM_NBR);
                Display(ref fldF087SUBMITTEDREJECTEDCLAIMSHDR_EDT_ERR_H_CD_1);
                Display(ref fldF087SUBMITTEDREJECTEDCLAIMSHDR_EDT_ERR_H_CD_2);
                Display(ref fldF087SUBMITTEDREJECTEDCLAIMSHDR_EDT_ERR_H_CD_3);
                Display(ref fldF087SUBMITTEDREJECTEDCLAIMSHDR_EDT_ERR_H_CD_4);
                Display(ref fldF087SUBMITTEDREJECTEDCLAIMSHDR_EDT_ERR_H_CD_5);
                Display(ref fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_PROCESS_DATE);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 9:56:20 AM
        //#-----------------------------------------
        protected override bool Update()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 9:56:20 AM
                fleF087SUBMITTEDREJECTEDCLAIMSHDR.PutData(false, PutTypes.New);
                while (fleF087SUBMITTEDREJECTEDCLAIMSDTL.For())
                {
                    fleF087SUBMITTEDREJECTEDCLAIMSDTL.PutData(false, PutTypes.Deleted);
                }
                while (fleF087SUBMITTEDREJECTEDCLAIMSDTL.For())
                {
                    fleF087SUBMITTEDREJECTEDCLAIMSDTL.PutData();
                }
                fleF087SUBMITTEDREJECTEDCLAIMSHDR.PutData();
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 9:56:20 AM
        //#-----------------------------------------
        protected override bool Delete()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 9:56:20 AM
                fleF087SUBMITTEDREJECTEDCLAIMSDTL.DeletedRecord = true;
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
        //# dtlF087SUBMITTEDREJECTEDCLAIMSDTL_EditClick Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 9:56:20 AM
        //#-----------------------------------------
        private void dtlF087SUBMITTEDREJECTEDCLAIMSDTL_EditClick(DataList source, GridButtonEventArgs GridButtonEventArgs)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 9:56:20 AM
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 9:56:20 AM
        //#-----------------------------------------
        private void dsrDesigner_01_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 9:56:20 AM
                Accept(ref fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_OMA_SERVICE_CD_AND_SUFFIX);
                Accept(ref fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_SERVICE_DATE);
                Accept(ref fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_NBR_SERV);
                Accept(ref fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_AMOUNT_SUBMITTED);
                Accept(ref fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_DTL_ERR_EXPLAN_CD);
                Accept(ref fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_DTL_ERR_CD_1);
                Accept(ref fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_DTL_ERR_CD_2);
                Accept(ref fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_DTL_ERR_CD_3);
                Accept(ref fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_DTL_ERR_CD_4);
                Accept(ref fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_DTL_ERR_CD_5);
                Display(ref fldF087SUBMITTEDREJECTEDCLAIMSDTL_LAST_MOD_USER_ID);
                Accept(ref fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_DTL_ERR_8_EXPLAN_CD);
                Accept(ref fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_DTL_ERR_8_EXPLAN_DESC);
                Accept(ref fldF087SUBMITTEDREJECTEDCLAIMSDTL_EDT_DTL_DIAG_CD);
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
