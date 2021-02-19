
#region "Screen Comments"

// Program: m088_1a.qks
// Purpose: display and maintain rat rejection records in f088-hdr/dtl
// This program is called from d003.cbl
// Mod Hist
// 2002/nov/13 M.C. - original clone from m088.qks
// 2003/dec/10 A.A.      - alpha doctor nbr 

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

    partial class Billing_M088_1A : BasePage
    {

        #region " Form Designer Generated Code "





        public Billing_M088_1A()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "M088_1A";

            //# Set the ACTIVITIES for the screen.
            this.ChangeActivity = true;
            this.FindActivity = true;
            this.DeleteActivity = false;
            this.EntryActivity = false;
            this.DisableAppend = true;
            this.UseAcceptProcessing = true;

            this.GridDesigner = "dsrDesigner_06";
            this.ScreenType = ScreenTypes.Composite;


            dsrDesigner_06.DefaultFirstRowInGrid = true;

        }

        #endregion

        private void Page_Load(object sender, RoutedEventArgs e)
        {
            SetVariables();
            dsrDesigner_02.Click += dsrDesigner_02_Click;
            dsrDesigner_03.Click += dsrDesigner_03_Click;
            dsrDesigner_05.Click += dsrDesigner_05_Click;
            dsrDesigner_04.Click += dsrDesigner_04_Click;
            dsrDesigner_06.Click += dsrDesigner_06_Click;
            dsrDesigner_01.Click += dsrDesigner_01_Click;
            dtlDTL.EditClick += dtlDTL_EditClick;
            base.Page_Load();

            // TODO: If any DESIGNER procedures function on occurring FILES or TEMPORARIES, set the grid's AllowSelectRowButton property to TRUE.



            // TODO: The following elements have Input/Output Scaling defined in the Dictionary or Screen.  Manual steps may be required:
            //       DTL.PART_DTL_AMT_BILL InputScale: 2 OutputScale: 0
            //       DTL.PART_DTL_AMT_PAID InputScale: 2 OutputScale: 0
            //       HDR.PART_HDR_AMT_BILL InputScale: 2 OutputScale: 0
            //       HDR.PART_HDR_AMT_PAID InputScale: 2 OutputScale: 0


        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            X_CLMHDR_BATCH_NBR = new CoreCharacter("X_CLMHDR_BATCH_NBR", 8, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
            X_PED = new CoreDecimal("X_PED", 8, this);
            X_BALANCE_DUE = new CoreDecimal("X_BALANCE_DUE", 7, this);
            X_CLMHDR_MANUAL_AND_TAPE_PAYMENTS = new CoreDecimal("X_CLMHDR_MANUAL_AND_TAPE_PAYMENTS", 7, this);
            fleHDR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F088_RAT_REJECTED_CLAIMS_HIST_HDR", "HDR", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Reference, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_cnnQUERY");
            fleDTL = new SqlFileObject(this, FileTypes.Detail, 9, "INDEXED", "F088_RAT_REJECTED_CLAIMS_HIST_DTL", "DTL", false, false, false, 0, "m_trnTRANS_UPDATE");

           

            fleF002_CLAIMS_MSTR.Access += fleF002_CLAIMS_MSTR_Access;
            fleDTL.Access += fleDTL_Access;
        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;
            fleF002_CLAIMS_MSTR.Access -= fleF002_CLAIMS_MSTR_Access;
            fleDTL.Access -= fleDTL_Access;

            dsrDesigner_02.Click -= dsrDesigner_02_Click;
            dsrDesigner_03.Click -= dsrDesigner_03_Click;
            dsrDesigner_05.Click -= dsrDesigner_05_Click;
            dsrDesigner_04.Click -= dsrDesigner_04_Click;
            dsrDesigner_06.Click -= dsrDesigner_06_Click;
            dsrDesigner_01.Click -= dsrDesigner_01_Click;
            dtlDTL.EditClick += dtlDTL_EditClick;

        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private SqlConnection m_cnnQUERY = new SqlConnection();
        private SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
        private SqlTransaction m_trnTRANS_UPDATE;
        private CoreCharacter X_CLMHDR_BATCH_NBR;
        private CoreDecimal X_PED;
        private CoreDecimal X_BALANCE_DUE;
        private CoreDecimal X_CLMHDR_MANUAL_AND_TAPE_PAYMENTS;
        private SqlFileObject fleHDR;

        private void fleHDR_SetItemFinals()
        {

            try
            {
                fleHDR.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));
                fleHDR.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);
                fleHDR.set_SetValue("LAST_MOD_USER_ID", UserID);
                fleHDR.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));
                fleHDR.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);
                fleHDR.set_SetValue("LAST_MOD_USER_ID", UserID);


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

        private SqlFileObject fleF002_CLAIMS_MSTR;

        private void fleF002_CLAIMS_MSTR_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_TYPE")).Append(" = ").Append(Common.StringToField(("B")));
                strText.Append(" AND ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ").Append(Common.StringToField(fleHDR.GetStringValue("CLMHDR_BATCH_NBR")));
                strText.Append(" AND ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ").Append((fleHDR.GetDecimalValue("CLMHDR_CLAIM_NBR")));
                strText.Append(" AND ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_SERV_CODE")).Append(" = ").Append(Common.StringToField("00000"));
                strText.Append(" AND ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_ADJ_NBR")).Append(" = ").Append(Common.StringToField("0"));

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

        private SqlFileObject fleDTL;

        private void fleDTL_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleDTL.ElementOwner("CLMHDR_BATCH_NBR")).Append(" = ").Append(Common.StringToField(fleHDR.GetStringValue("CLMHDR_BATCH_NBR")));
                strText.Append(" AND ").Append(fleDTL.ElementOwner("CLMHDR_CLAIM_NBR")).Append(" = ").Append((fleHDR.GetDecimalValue("CLMHDR_CLAIM_NBR")));
                strText.Append(" AND ").Append(fleDTL.ElementOwner("CLMHDR_ADJ_OMA_CD")).Append(" LIKE ").Append(Common.StringToField("%"));
                //Parent:CLMHDR_OMA_SUFF_ADJ
                strText.Append(" AND ").Append(fleDTL.ElementOwner("CLMHDR_ADJ_OMA_SUFF")).Append(" LIKE ").Append(Common.StringToField("%"));
                //Parent:CLMHDR_OMA_SUFF_ADJ
                strText.Append(" AND ").Append(fleDTL.ElementOwner("CLMHDR_ADJ_ADJ_NBR")).Append(" LIKE ").Append(Common.StringToField("%"));
                //Parent:CLMHDR_OMA_SUFF_ADJ
                strText.Append(" AND ").Append(fleDTL.ElementOwner("PED")).Append(" = ").Append((fleHDR.GetNumericDateValue("PED")));

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

        string CLAIM_ID;

        #endregion

        #region "Standard Generated Procedures"

        #region "Grid Field Declarations"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:14:48 AM

        protected TextBox fldDTL_CLMDTL_SV_DATE;
        protected TextBox fldDTL_CLMHDR_ADJ_OMA_CD;
        protected TextBox fldDTL_CLMHDR_ADJ_OMA_SUFF;
        protected TextBox fldDTL_OHIP_ERR_CODE;
        protected TextBox fldDTL_PART_DTL_AMT_BILL;
        protected TextBox fldDTL_PART_DTL_AMT_PAID;
        protected TextBox fldDTL_CLMHDR_DOC_NBR;

        protected TextBox fldDTL_PED;

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:14:48 AM

        //#-----------------------------------------
        //# GetGridFieldObject Procedure.
        //#-----------------------------------------

        protected override void GetGridFieldObject(object DataListField, ref object CoreField, string Name)
        {

            try
            {
                switch (Name.ToUpper())
                {
                    case "FLDGRDDTL_CLMDTL_SV_DATE":
                        fldDTL_CLMDTL_SV_DATE = (TextBox)DataListField;
                        CoreField = fldDTL_CLMDTL_SV_DATE;
                        fldDTL_CLMDTL_SV_DATE.Bind(fleDTL);
                        break;
                    case "FLDGRDDTL_CLMHDR_ADJ_OMA_CD":
                        fldDTL_CLMHDR_ADJ_OMA_CD = (TextBox)DataListField;
                        CoreField = fldDTL_CLMHDR_ADJ_OMA_CD;
                        fldDTL_CLMHDR_ADJ_OMA_CD.Bind(fleDTL);
                        break;
                    case "FLDGRDDTL_CLMHDR_ADJ_OMA_SUFF":
                        fldDTL_CLMHDR_ADJ_OMA_SUFF = (TextBox)DataListField;
                        CoreField = fldDTL_CLMHDR_ADJ_OMA_SUFF;
                        fldDTL_CLMHDR_ADJ_OMA_SUFF.Bind(fleDTL);
                        break;
                    case "FLDGRDDTL_OHIP_ERR_CODE":
                        fldDTL_OHIP_ERR_CODE = (TextBox)DataListField;
                        CoreField = fldDTL_OHIP_ERR_CODE;
                        fldDTL_OHIP_ERR_CODE.Bind(fleDTL);
                        break;
                    case "FLDGRDDTL_PART_DTL_AMT_BILL":
                        fldDTL_PART_DTL_AMT_BILL = (TextBox)DataListField;
                        CoreField = fldDTL_PART_DTL_AMT_BILL;
                        fldDTL_PART_DTL_AMT_BILL.Bind(fleDTL);
                        break;
                    case "FLDGRDDTL_PART_DTL_AMT_PAID":
                        fldDTL_PART_DTL_AMT_PAID = (TextBox)DataListField;
                        CoreField = fldDTL_PART_DTL_AMT_PAID;
                        fldDTL_PART_DTL_AMT_PAID.Bind(fleDTL);
                        break;
                    case "FLDGRDDTL_CLMHDR_DOC_NBR":
                        fldDTL_CLMHDR_DOC_NBR = (TextBox)DataListField;
                        CoreField = fldDTL_CLMHDR_DOC_NBR;
                        fldDTL_CLMHDR_DOC_NBR.Bind(fleDTL);
                        break;
                    case "FLDGRDDTL_PED":
                        fldDTL_PED = (TextBox)DataListField;
                        CoreField = fldDTL_PED;
                        fldDTL_PED.Bind(fleDTL);
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
                dtlDTL.OccursWithFile = fleDTL;

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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:14:48 AM

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
            fleHDR.Transaction = m_trnTRANS_UPDATE;
            fleDTL.Transaction = m_trnTRANS_UPDATE;


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:14:48 AM

        //#-----------------------------------------
        //# InitializeFiles Procedure.
        //#-----------------------------------------

        protected override void InitializeFiles()
        {

            try
            {
                Initialize_TRANS_UPDATE();
                fleF002_CLAIMS_MSTR.Connection = m_cnnQUERY;


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
                fleHDR.Dispose();
                fleF002_CLAIMS_MSTR.Dispose();
                fleDTL.Dispose();


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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:14:48 AM
        //#-----------------------------------------
        protected override void DisplayFormatting()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:14:48 AM
                Display(ref fldX_CLMHDR_BATCH_NBR);
                Display(ref fldHDR_CLMHDR_CLAIM_NBR);
                Display(ref fldHDR_CLMHDR_DOC_NBR);
                Display(ref fldHDR_PED);
                Display(ref fldHDR_OHIP_ERR_CODE);
                Display(ref fldHDR_CHARGE_STATUS);
                Display(ref fldX_BALANCE_DUE);
                Display(ref fldF002_CLAIMS_MSTR_CLMHDR_TOT_CLAIM_AR_OHIP);
                Display(ref fldX_CLMHDR_MANUAL_AND_TAPE_PAYMENTS);
                Display(ref fldF002_CLAIMS_MSTR_CLMHDR_DATE_PERIOD_END);
                Display(ref fldF002_CLAIMS_MSTR_CLMHDR_CYCLE_NBR);
                Display(ref fldHDR_PART_HDR_AMT_BILL);
                Display(ref fldHDR_PART_HDR_AMT_PAID);
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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:14:48 AM

        //#-----------------------------------------
        //# BindFields Procedure.
        //#-----------------------------------------

        public override void BindFields()
        {
            try
            {
                fldX_CLMHDR_BATCH_NBR.Bind(X_CLMHDR_BATCH_NBR);
                fldHDR_CLMHDR_CLAIM_NBR.Bind(fleHDR);
                fldHDR_CLMHDR_DOC_NBR.Bind(fleHDR);
                fldHDR_PED.Bind(fleHDR);
                fldHDR_OHIP_ERR_CODE.Bind(fleHDR);
                fldHDR_CHARGE_STATUS.Bind(fleHDR);
                fldX_BALANCE_DUE.Bind(X_BALANCE_DUE);
                fldF002_CLAIMS_MSTR_CLMHDR_TOT_CLAIM_AR_OHIP.Bind(fleF002_CLAIMS_MSTR);
                fldX_CLMHDR_MANUAL_AND_TAPE_PAYMENTS.Bind(X_CLMHDR_MANUAL_AND_TAPE_PAYMENTS);
                fldF002_CLAIMS_MSTR_CLMHDR_DATE_PERIOD_END.Bind(fleF002_CLAIMS_MSTR);
                fldF002_CLAIMS_MSTR_CLMHDR_CYCLE_NBR.Bind(fleF002_CLAIMS_MSTR);
                fldHDR_PART_HDR_AMT_BILL.Bind(fleHDR);
                fldHDR_PART_HDR_AMT_PAID.Bind(fleHDR);

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

        #endregion

        #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"

        protected override bool Find()
        {


            try
            {

                CLAIM_ID = ApplicationState.Current.Session["CLAIM_ID"].ToString();

                bool blnAddWhere = true;
                m_strWhere = new StringBuilder(GetWhereCondition(fleHDR.ElementOwner("CLMHDR_BATCH_NBR"), QDesign.Substring(CLAIM_ID, 2, 8), ref blnAddWhere));
                //Parent:RAT_REJECTED_CLAIM
                m_strWhere.Append(GetWhereCondition(fleHDR.ElementOwner("CLMHDR_CLAIM_NBR"), QDesign.Substring(CLAIM_ID, 10, 2), ref blnAddWhere));
                //Parent:RAT_REJECTED_CLAIM
                fleHDR.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);


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


        protected override bool DetailFind()
        {


            try
            {

                while (fleDTL.ForMissing())
                {
                    // --> GET DTL <--

                    fleDTL.GetData(GetDataOptions.IsOptional | GetDataOptions.CreateSubSelect);
                    // --> End GET DTL <--
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
                while (fleF002_CLAIMS_MSTR.ForMissing())
                {
                    fleF002_CLAIMS_MSTR.GetData(GetDataOptions.IsOptional | GetDataOptions.CreateSubSelect);
                }

                X_CLMHDR_BATCH_NBR.Value = QDesign.Substring(CLAIM_ID, 1, 2) + QDesign.Substring(CLAIM_ID, 4, 6);
                X_CLMHDR_MANUAL_AND_TAPE_PAYMENTS.Value = 0 - fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_MANUAL_AND_TAPE_PAYMENTS");
                X_BALANCE_DUE.Value = fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP") + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_MANUAL_AND_TAPE_PAYMENTS");

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
                Page.PageTitle = "RAT Errors Costing Maintenance Screen";



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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:14:48 AM
        //#-----------------------------------------
        protected override bool Append()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:14:48 AM
                Accept(ref fldDTL_CLMDTL_SV_DATE);
                Accept(ref fldDTL_CLMHDR_ADJ_OMA_CD);
                Accept(ref fldDTL_CLMHDR_ADJ_OMA_SUFF);
                Accept(ref fldDTL_OHIP_ERR_CODE);
                Accept(ref fldDTL_PART_DTL_AMT_BILL);
                Accept(ref fldDTL_PART_DTL_AMT_PAID);
                Accept(ref fldDTL_CLMHDR_DOC_NBR);
                Accept(ref fldDTL_PED);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:14:48 AM
        //#-----------------------------------------
        protected override bool Update()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:14:48 AM
                while (fleDTL.For())
                {
                    fleDTL.PutData();
                }
                fleHDR.PutData();
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:14:48 AM
        //#-----------------------------------------
        protected override bool DetailDelete()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:14:48 AM
                fleDTL.DeletedRecord = true;
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
        //# dtlDTL_EditClick Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:14:48 AM
        //#-----------------------------------------
        private void dtlDTL_EditClick(DataList source, GridButtonEventArgs GridButtonEventArgs)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:14:48 AM
                dsrDesigner_06_Click(null, null);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:14:48 AM
        //#-----------------------------------------
        private void dsrDesigner_02_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:14:48 AM
                if (!fleHDR.NewRecord)
                {
                    Display(ref fldHDR_CLMHDR_DOC_NBR);
                }
                else
                {
                    Accept(ref fldHDR_CLMHDR_DOC_NBR);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:14:48 AM
        //#-----------------------------------------
        private void dsrDesigner_03_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:14:48 AM
                if (!fleHDR.NewRecord)
                {
                    Display(ref fldHDR_PED);
                }
                else
                {
                    Accept(ref fldHDR_PED);
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
        //# dsrDesigner_05_Click Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:14:48 AM
        //#-----------------------------------------
        private void dsrDesigner_05_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:14:48 AM
                Accept(ref fldHDR_CHARGE_STATUS);
                Display(ref fldX_BALANCE_DUE);
                Display(ref fldF002_CLAIMS_MSTR_CLMHDR_TOT_CLAIM_AR_OHIP);
                Display(ref fldX_CLMHDR_MANUAL_AND_TAPE_PAYMENTS);
                Display(ref fldF002_CLAIMS_MSTR_CLMHDR_DATE_PERIOD_END);
                Display(ref fldF002_CLAIMS_MSTR_CLMHDR_CYCLE_NBR);
                if (!fleHDR.NewRecord)
                {
                    Display(ref fldHDR_PART_HDR_AMT_BILL);
                }
                else
                {
                    Accept(ref fldHDR_PART_HDR_AMT_BILL);
                }
                if (!fleHDR.NewRecord)
                {
                    Display(ref fldHDR_PART_HDR_AMT_PAID);
                }
                else
                {
                    Accept(ref fldHDR_PART_HDR_AMT_PAID);
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
        //# dsrDesigner_04_Click Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:14:48 AM
        //#-----------------------------------------
        private void dsrDesigner_04_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:14:48 AM
                if (!fleHDR.NewRecord)
                {
                    Display(ref fldHDR_OHIP_ERR_CODE);
                }
                else
                {
                    Accept(ref fldHDR_OHIP_ERR_CODE);
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
        //# dsrDesigner_06_Click Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:14:48 AM
        //#-----------------------------------------
        private void dsrDesigner_06_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:14:48 AM
                Accept(ref fldDTL_CLMDTL_SV_DATE);
                Accept(ref fldDTL_CLMHDR_ADJ_OMA_CD);
                Accept(ref fldDTL_CLMHDR_ADJ_OMA_SUFF);
                Accept(ref fldDTL_OHIP_ERR_CODE);
                Accept(ref fldDTL_PART_DTL_AMT_BILL);
                Accept(ref fldDTL_PART_DTL_AMT_PAID);
                Accept(ref fldDTL_CLMHDR_DOC_NBR);
                Accept(ref fldDTL_PED);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:14:48 AM
        //#-----------------------------------------
        private void dsrDesigner_01_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:14:48 AM
                if (FindMode)
                {
                    Display(ref fldX_CLMHDR_BATCH_NBR);
                }
                else
                {
                    Accept(ref fldX_CLMHDR_BATCH_NBR);
                }
                if (!fleHDR.NewRecord)
                {
                    Display(ref fldHDR_CLMHDR_CLAIM_NBR);
                }
                else
                {
                    Accept(ref fldHDR_CLMHDR_CLAIM_NBR);
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
