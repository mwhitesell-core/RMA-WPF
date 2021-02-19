
#region "Screen Comments"

// Program: m088.qks
// Purpose: display and maintain rat rejection records in f088-hdr/dtl
// Mod Hist
// 2000/jan/20 B.A. - original
// 2000/jan/29 B.E. - added ability to change records(charge/err cd fields)
// 2000/apr/10 M.C. - correct the access statements
// 2000/jul/10 M.C. - correct the access statements for f088-dtl file
// 2000/aug/09 B.E. - added automatic update of audit fields in f088
// 2002/nov/15 M.C. - access f088 in decending order by  ped date       
// 2003/dec/10 A.A. - alpha doctor nbr 
// 2013/Sep/19 MC1  - show clmhdr-date-period-end of f088-hdr
// 2013/Dec/10 MC2 - allow negative amount to be displayed  

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

    partial class Billing_M088 : BasePage
    {

        #region " Form Designer Generated Code "





        public Billing_M088()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "M088";

            //# Set the ACTIVITIES for the screen.
            this.ChangeActivity = true;
            this.FindActivity = true;
            this.DeleteActivity = false;
            this.EntryActivity = false;
            this.DisableAppend = true;
            this.UseAcceptProcessing = true;
            this.HasPathRequestFields = true;

            this.GridDesigner = "dsrDesigner_07";
            this.ScreenType = ScreenTypes.Composite;


            dsrDesigner_07.DefaultFirstRowInGrid = true;

        }

        #endregion

        private void Page_Load(object sender, RoutedEventArgs e)
        {
            SetVariables();
            dsrDesigner_02.Click += dsrDesigner_02_Click;
            dsrDesigner_03.Click += dsrDesigner_03_Click;
            dsrDesigner_05.Click += dsrDesigner_05_Click;
            dsrDesigner_07.Click += dsrDesigner_07_Click;
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
            X_RAT_REJECTED_CLAIM = new CoreCharacter("X_RAT_REJECTED_CLAIM", 10, this, Common.cEmptyString);
            X_CLMHDR_BATCH_NBR = new CoreCharacter("X_CLMHDR_BATCH_NBR", 8, this, Common.cEmptyString);
            X_CLMHDR_CLAIM_NBR = new CoreCharacter("X_CLMHDR_CLAIM_NBR", 2, this, Common.cEmptyString);
            X_PED = new CoreDecimal("X_PED", 8, this);
            X_BALANCE_DUE = new CoreDecimal("X_BALANCE_DUE", 7, this);
            X_CLMHDR_MANUAL_AND_TAPE_PAYMENTS = new CoreDecimal("X_CLMHDR_MANUAL_AND_TAPE_PAYMENTS", 7, this);
            fleHDR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F088_RAT_REJECTED_CLAIMS_HIST_HDR", "HDR", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF002_CLAIMS_MSTR_HDR = new SqlFileObject(this, FileTypes.Reference, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_cnnQUERY");
            fleDTL = new SqlFileObject(this, FileTypes.Detail, 9, "INDEXED", "F088_RAT_REJECTED_CLAIMS_HIST_DTL", "DTL", false, false, false, 0, "m_trnTRANS_UPDATE");

            
            fleF002_CLAIMS_MSTR_HDR.Access += fleF002_CLAIMS_MSTR_HDR_Access;
            fleDTL.Access += fleDTL_Access;
            fleHDR.InitializeItems += fleHDR_InitializeItems;
        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;
            fleF002_CLAIMS_MSTR_HDR.Access -= fleF002_CLAIMS_MSTR_HDR_Access;
            fleDTL.Access -= fleDTL_Access;

            dsrDesigner_02.Click -= dsrDesigner_02_Click;
            dsrDesigner_03.Click -= dsrDesigner_03_Click;
            dsrDesigner_05.Click -= dsrDesigner_05_Click;
            dsrDesigner_07.Click -= dsrDesigner_07_Click;
            dsrDesigner_04.Click -= dsrDesigner_04_Click;
            dsrDesigner_06.Click -= dsrDesigner_06_Click;
            dsrDesigner_01.Click -= dsrDesigner_01_Click;
            dtlDTL.EditClick -= dtlDTL_EditClick;
            fleHDR.InitializeItems -= fleHDR_InitializeItems;

        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private SqlConnection m_cnnQUERY = new SqlConnection();
        private SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
        private SqlTransaction m_trnTRANS_UPDATE;
        private CoreCharacter X_RAT_REJECTED_CLAIM;
        private CoreCharacter X_CLMHDR_BATCH_NBR;
        private CoreCharacter X_CLMHDR_CLAIM_NBR;
        private CoreDecimal X_PED;
        private CoreDecimal X_BALANCE_DUE;
        private CoreDecimal X_CLMHDR_MANUAL_AND_TAPE_PAYMENTS;
        private SqlFileObject fleHDR;

        private void fleHDR_InitializeItems(bool Fixed)
        {

            try
            {
                if (!Fixed)
                    fleHDR.set_SetValue("ENTRY_DATE", true, QDesign.SysDate(ref m_cnnQUERY));
                if (!Fixed)
                    fleHDR.set_SetValue("ENTRY_TIME_LONG", true, QDesign.SysTime(ref m_cnnQUERY));
                if (!Fixed)
                    fleHDR.set_SetValue("ENTRY_USER_ID", true, UserID);
                if (!Fixed)
                    fleHDR.set_SetValue("ENTRY_DATE", true, QDesign.SysDate(ref m_cnnQUERY));
                if (!Fixed)
                    fleHDR.set_SetValue("ENTRY_TIME_LONG", true, QDesign.SysTime(ref m_cnnQUERY));
                if (!Fixed)
                    fleHDR.set_SetValue("ENTRY_USER_ID", true, UserID);


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

        private SqlFileObject fleF002_CLAIMS_MSTR_HDR;

        private void fleF002_CLAIMS_MSTR_HDR_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleF002_CLAIMS_MSTR_HDR.ElementOwner("KEY_CLM_TYPE")).Append(" = ").Append(Common.StringToField(("B")));
                strText.Append(" AND ").Append(fleF002_CLAIMS_MSTR_HDR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ").Append(Common.StringToField(fleHDR.GetStringValue("CLMHDR_BATCH_NBR")));
                strText.Append(" AND ").Append(fleF002_CLAIMS_MSTR_HDR.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ").Append((fleHDR.GetDecimalValue("CLMHDR_CLAIM_NBR")));
                strText.Append(" AND ").Append(fleF002_CLAIMS_MSTR_HDR.ElementOwner("KEY_CLM_SERV_CODE")).Append(" = ").Append(Common.StringToField("00000"));
                strText.Append(" AND ").Append(fleF002_CLAIMS_MSTR_HDR.ElementOwner("KEY_CLM_ADJ_NBR")).Append(" = ").Append(Common.StringToField("0"));

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

        #endregion

        #region "Standard Generated Procedures"

        #region "Grid Field Declarations"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:14:56 AM

        protected TextBox fldDTL_CLMDTL_SV_DATE;
        protected TextBox fldDTL_CLMHDR_ADJ_OMA_CD;
        protected TextBox fldDTL_CLMHDR_ADJ_OMA_SUFF;
        protected TextBox fldDTL_OHIP_ERR_CODE;
        protected TextBox fldDTL_PART_DTL_AMT_BILL;
        protected TextBox fldDTL_PART_DTL_AMT_PAID;
        protected TextBox fldDTL_CLMHDR_DOC_NBR;
        protected DateControl fldDTL_PED;

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:14:56 AM

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
                        fldDTL_PED = (DateControl)DataListField;
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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:14:56 AM

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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:14:56 AM

        //#-----------------------------------------
        //# InitializeFiles Procedure.
        //#-----------------------------------------

        protected override void InitializeFiles()
        {

            try
            {
                Initialize_TRANS_UPDATE();
                fleF002_CLAIMS_MSTR_HDR.Connection = m_cnnQUERY;


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
                fleF002_CLAIMS_MSTR_HDR.Dispose();
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:14:56 AM
        //#-----------------------------------------
        protected override void DisplayFormatting()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:14:56 AM
                Display(ref fldX_CLMHDR_BATCH_NBR);
                Display(ref fldHDR_CLMHDR_CLAIM_NBR);
                Display(ref fldHDR_CLMHDR_DOC_NBR);
                Display(ref fldHDR_PED);
                Display(ref fldHDR_CLMHDR_DATE_PERIOD_END);
                Display(ref fldHDR_OHIP_ERR_CODE);
                Display(ref fldHDR_CHARGE_STATUS);
                Display(ref fldX_BALANCE_DUE);
                Display(ref fldF002_CLAIMS_MSTR_HDR_CLMHDR_TOT_CLAIM_AR_OHIP);
                Display(ref fldX_CLMHDR_MANUAL_AND_TAPE_PAYMENTS);
                Display(ref fldF002_CLAIMS_MSTR_HDR_CLMHDR_DATE_PERIOD_END);
                Display(ref fldF002_CLAIMS_MSTR_HDR_CLMHDR_CYCLE_NBR);
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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:14:56 AM

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
                fldHDR_CLMHDR_DATE_PERIOD_END.Bind(fleHDR);
                fldHDR_OHIP_ERR_CODE.Bind(fleHDR);
                fldHDR_CHARGE_STATUS.Bind(fleHDR);
                fldX_BALANCE_DUE.Bind(X_BALANCE_DUE);
                fldF002_CLAIMS_MSTR_HDR_CLMHDR_TOT_CLAIM_AR_OHIP.Bind(fleF002_CLAIMS_MSTR_HDR);
                fldX_CLMHDR_MANUAL_AND_TAPE_PAYMENTS.Bind(X_CLMHDR_MANUAL_AND_TAPE_PAYMENTS);
                fldF002_CLAIMS_MSTR_HDR_CLMHDR_DATE_PERIOD_END.Bind(fleF002_CLAIMS_MSTR_HDR);
                fldF002_CLAIMS_MSTR_HDR_CLMHDR_CYCLE_NBR.Bind(fleF002_CLAIMS_MSTR_HDR);
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


        protected override bool PostFind()
        {


            try
            {

                X_CLMHDR_MANUAL_AND_TAPE_PAYMENTS.Value = 0 - fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_MANUAL_AND_TAPE_PAYMENTS");
                X_BALANCE_DUE.Value = fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP") + fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_MANUAL_AND_TAPE_PAYMENTS");

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
                    fleDTL.GetData(GetDataOptions.CreateSubSelect | GetDataOptions.IsOptional);
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
                bool blnAddWhere = true;
                m_strWhere = new StringBuilder(GetWhereCondition(fleHDR.ElementOwner("CLMHDR_BATCH_NBR"), X_CLMHDR_BATCH_NBR.Value, ref blnAddWhere));
                m_strWhere.Append(GetWhereCondition(fleHDR.ElementOwner("CLMHDR_CLAIM_NBR"), fleHDR.GetDecimalValue("CLMHDR_CLAIM_NBR"), ref blnAddWhere));
              
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



        protected override bool Path()
        {


            try
            {
                RequestPrompt(ref fldX_CLMHDR_BATCH_NBR);
                if (m_blnPromptOK)
                {
                    RequestPrompt(ref fldHDR_CLMHDR_CLAIM_NBR);
                    if (m_blnPromptOK)
                    {
                        m_intPath = 1;
                    }
                }

                if (m_intPath != 1)
                {
                    ErrorMessage("Key/Index required.");
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:14:56 AM
        //#-----------------------------------------
        protected override bool Append()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:14:56 AM
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:14:56 AM
        //#-----------------------------------------
        protected override bool Update()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:14:56 AM
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:14:56 AM
        //#-----------------------------------------
        protected override bool DetailDelete()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:14:56 AM
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:14:56 AM
        //#-----------------------------------------
        private void dtlDTL_EditClick(DataList source, GridButtonEventArgs GridButtonEventArgs)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:14:56 AM
                dsrDesigner_07_Click(null, null);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:14:56 AM
        //#-----------------------------------------
        private void dsrDesigner_02_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:14:56 AM
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:14:56 AM
        //#-----------------------------------------
        private void dsrDesigner_03_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:14:56 AM
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:14:56 AM
        //#-----------------------------------------
        private void dsrDesigner_05_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:14:56 AM
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
        //# dsrDesigner_07_Click Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:14:56 AM
        //#-----------------------------------------
        private void dsrDesigner_07_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:14:56 AM
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
        //# dsrDesigner_04_Click Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:14:56 AM
        //#-----------------------------------------
        private void dsrDesigner_04_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:14:56 AM
                if (!fleHDR.NewRecord)
                {
                    Display(ref fldHDR_CLMHDR_DATE_PERIOD_END);
                }
                else
                {
                    Accept(ref fldHDR_CLMHDR_DATE_PERIOD_END);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:14:56 AM
        //#-----------------------------------------
        private void dsrDesigner_06_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:14:56 AM
                Accept(ref fldHDR_CHARGE_STATUS);
                Display(ref fldX_BALANCE_DUE);
                Display(ref fldF002_CLAIMS_MSTR_HDR_CLMHDR_TOT_CLAIM_AR_OHIP);
                Display(ref fldX_CLMHDR_MANUAL_AND_TAPE_PAYMENTS);
                Display(ref fldF002_CLAIMS_MSTR_HDR_CLMHDR_DATE_PERIOD_END);
                Display(ref fldF002_CLAIMS_MSTR_HDR_CLMHDR_CYCLE_NBR);
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
        //# dsrDesigner_01_Click Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:14:56 AM
        //#-----------------------------------------
        private void dsrDesigner_01_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:14:56 AM
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
