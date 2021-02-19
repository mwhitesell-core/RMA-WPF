
#region "Screen Comments"

// #> PROGRAM-ID.     M190.QKS
// ((C)) Dyad Technologies
// PURPOSE: Maintenance of the COMPENSATION CODES MASTER
// MODIFICATION HISTORY
// DATE    SAF #  WHO      DESCRIPTION
// 92/JAN/01  ____   B.E.     - original
// 93/DEC/03  ____   B.E.     - removed associated YTD-COMP-CODE
// 98/JAN/14  ____   J.C.     - replaced index name short-desc to desc-short
// 1999/Apr/22  S.B.  - Y2K checked.
// 1999/Jun/07         S.B.     - Altered the call to scrtitle.use and
// stdhilite.use to be called from $use
// instead of src.
// - Removed the call to secfile.use because
// it was not doing anything.
// 2002/Aug/28  M.C.  - include 4 new flags on the screen
// 2008/May/21  M.C.  - include designer `dtl` call screen
// 2017/Mar/02         MC1      - disable the designer DTL as Brad agreed 
// because f190-dtl-dept-comp-codes does not exist    
// according to rmabill.pdl, it has replaced by f116-dtl    

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

    partial class Billing_M190 : BasePage
    {

        #region " Form Designer Generated Code "





        public Billing_M190()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "M190";

            //# Set the ACTIVITIES for the screen.
            this.ChangeActivity = true;
            this.FindActivity = true;
            this.DeleteActivity = true;
            this.EntryActivity = true;
            this.UseAcceptProcessing = true;



            this.HasPathRequestFields = true;







        }

        #endregion

        private void Page_Load(object sender, RoutedEventArgs e)
        {
            SetVariables();
            dsrDesigner_GROS.Click += dsrDesigner_GROS_Click;
            dsrDesigner_09.Click += dsrDesigner_09_Click;
            dsrDesigner_13.Click += dsrDesigner_13_Click;
            dsrDesigner_11.Click += dsrDesigner_11_Click;
            dsrDesigner_04.Click += dsrDesigner_04_Click;
            dsrDesigner_10.Click += dsrDesigner_10_Click;
            dsrDesigner_08.Click += dsrDesigner_08_Click;
            dsrDesigner_12.Click += dsrDesigner_12_Click;
            dsrDesigner_02.Click += dsrDesigner_02_Click;
            fldF190_COMP_CODES_DESC_SHORT.LookupNotOn += fldF190_COMP_CODES_DESC_SHORT_LookupNotOn;
            fldF190_COMP_CODES_COMP_CODE.LookupNotOn += fldF190_COMP_CODES_COMP_CODE_LookupNotOn;
            base.Page_Load();

            // TODO: The following elements have Input/Output Scaling defined in the Dictionary or Screen.  Manual steps may be required:
            //       F190_COMP_CODES.FACTOR InputScale: 4 OutputScale: 0


        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

           

            X_SCREEN_NAME.GetValue += X_SCREEN_NAME_GetValue;
            X_SCR_NAME.GetValue += X_SCR_NAME_GetValue;
        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;
            X_SCREEN_NAME.GetValue -= X_SCREEN_NAME_GetValue;
            X_SCR_NAME.GetValue -= X_SCR_NAME_GetValue;
            fldF190_COMP_CODES_DESC_SHORT.LookupNotOn -= fldF190_COMP_CODES_DESC_SHORT_LookupNotOn;
            fldF190_COMP_CODES_COMP_CODE.LookupNotOn -= fldF190_COMP_CODES_COMP_CODE_LookupNotOn;

            dsrDesigner_GROS.Click -= dsrDesigner_GROS_Click;
            dsrDesigner_09.Click -= dsrDesigner_09_Click;
            dsrDesigner_13.Click -= dsrDesigner_13_Click;
            dsrDesigner_11.Click -= dsrDesigner_11_Click;
            dsrDesigner_04.Click -= dsrDesigner_04_Click;
            dsrDesigner_10.Click -= dsrDesigner_10_Click;
            dsrDesigner_08.Click -= dsrDesigner_08_Click;
            dsrDesigner_12.Click -= dsrDesigner_12_Click;
            dsrDesigner_02.Click -= dsrDesigner_02_Click;


        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private SqlConnection m_cnnQUERY = new SqlConnection();
        private SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
        private SqlTransaction m_trnTRANS_UPDATE;
        private SqlFileObject fleF190_COMP_CODES;
        private DCharacter X_SCREEN_NAME = new DCharacter(55);
        private void X_SCREEN_NAME_GetValue(ref string Value)
        {

            try
            {
                Value = "COMPENSATION CODES Maintenance";


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
        //#CORE_BEGIN_INCLUDE: SCRTITLE"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 6/2/2017 12:43:44 PM

        private DCharacter X_SCR_NAME = new DCharacter(55);
        private void X_SCR_NAME_GetValue(ref string Value)
        {

            try
            {
                Value = QDesign.RightJustify(X_SCREEN_NAME.Value);


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

        //#CORE_END_INCLUDE: SCRTITLE"


        #endregion

        #region "Standard Generated Procedures"

        #region "Grid Field Declarations"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 6/2/2017 12:43:45 PM

        //# No code was generated or needed for this region.

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 6/2/2017 12:43:45 PM

        //# No code was generated or needed for this region.

        #endregion

        #region "Transaction Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 6/2/2017 12:43:45 PM

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
            fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 6/2/2017 12:43:45 PM

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
                fleF190_COMP_CODES.Dispose();


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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 6/2/2017 12:43:45 PM
        //#-----------------------------------------
        protected override void DisplayFormatting()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 6/2/2017 12:43:45 PM
                Display(ref fldF190_COMP_CODES_COMP_CODE);
                Display(ref fldF190_COMP_CODES_COMP_TYPE);
                Display(ref fldF190_COMP_CODES_COMP_SUB_TYPE);
                Display(ref fldF190_COMP_CODES_COMP_OWNER);
                Display(ref fldF190_COMP_CODES_DESC_LONG);
                Display(ref fldF190_COMP_CODES_DESC_SHORT);
                Display(ref fldF190_COMP_CODES_PROCESS_SEQ);
                Display(ref fldF190_COMP_CODES_COMP_CODE_GROUP);
                Display(ref fldF190_COMP_CODES_REPORTING_SEQ);
                Display(ref fldF190_COMP_CODES_UNITS_DOLLARS_FLAG);
                Display(ref fldF190_COMP_CODES_FACTOR);
                Display(ref fldF190_COMP_CODES_AMT_PER_UNIT);
                Display(ref fldF190_COMP_CODES_PERCENT_GST);
                Display(ref fldF190_COMP_CODES_AMT_TAXABLE);
                Display(ref fldF190_COMP_CODES_DOC_TAX_RPT_FLAG);
                Display(ref fldF190_COMP_CODES_T4_NET_PAY_FLAG);
                Display(ref fldF190_COMP_CODES_T4_NET_TAX_FLAG);
                Display(ref fldF190_COMP_CODES_T4_NET_DEDUC_FLAG);
                Display(ref fldF190_COMP_CODES_PROCESS_MIN);
                Display(ref fldF190_COMP_CODES_PROCESS_MAX);
                Display(ref fldF190_COMP_CODES_FISCAL_MAX);
                Display(ref fldF190_COMP_CODES_CALENDAR_MAX);
                Display(ref fldF190_COMP_CODES_LTD_MAX);
               
                Display(ref fldF190_COMP_CODES_AFFECT_GROSS1);
                Display(ref fldF190_COMP_CODES_AFFECT_GROSS2);
                Display(ref fldF190_COMP_CODES_AFFECT_GROSS3);
                Display(ref fldF190_COMP_CODES_AFFECT_GROSS4);
                Display(ref fldF190_COMP_CODES_AFFECT_GROSS5);
                Display(ref fldF190_COMP_CODES_AFFECT_GROSS6);
                Display(ref fldF190_COMP_CODES_AFFECT_GROSS7);
                Display(ref fldF190_COMP_CODES_AFFECT_GROSS8);
                Display(ref fldF190_COMP_CODES_AFFECT_GROSS9);
                Display(ref fldF190_COMP_CODES_AFFECT_GROSS10);
                Display(ref fldF190_COMP_CODES_AFFECT_GROSS11);
                Display(ref fldF190_COMP_CODES_AFFECT_GROSS12);
                Display(ref fldF190_COMP_CODES_AFFECT_GROSS13);
                Display(ref fldF190_COMP_CODES_AFFECT_GROSS14);
                Display(ref fldF190_COMP_CODES_AFFECT_GROSS15);
                Display(ref fldF190_COMP_CODES_AFFECT_GROSS16);
                Display(ref fldF190_COMP_CODES_AFFECT_GROSS17);
                Display(ref fldF190_COMP_CODES_AFFECT_GROSS18);
                Display(ref fldF190_COMP_CODES_AFFECT_GROSS19);
                Display(ref fldF190_COMP_CODES_AFFECT_GROSS20);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 6/2/2017 12:43:45 PM
        //#-----------------------------------------
        protected override void PreDisplayFormatting()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 6/2/2017 12:43:45 PM
                Display(ref fldF190_COMP_CODES_FACTOR);
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
        //# Do not delete, modify or move it.  Updated: 6/2/2017 12:43:45 PM

        //#-----------------------------------------
        //# BindFields Procedure.
        //#-----------------------------------------

        public override void BindFields()
        {
            try
            {
                fldF190_COMP_CODES_COMP_CODE.Bind(fleF190_COMP_CODES);
                fldF190_COMP_CODES_COMP_TYPE.Bind(fleF190_COMP_CODES);
                fldF190_COMP_CODES_COMP_SUB_TYPE.Bind(fleF190_COMP_CODES);
                fldF190_COMP_CODES_COMP_OWNER.Bind(fleF190_COMP_CODES);
                fldF190_COMP_CODES_DESC_LONG.Bind(fleF190_COMP_CODES);
                fldF190_COMP_CODES_DESC_SHORT.Bind(fleF190_COMP_CODES);
                fldF190_COMP_CODES_PROCESS_SEQ.Bind(fleF190_COMP_CODES);
                fldF190_COMP_CODES_COMP_CODE_GROUP.Bind(fleF190_COMP_CODES);
                fldF190_COMP_CODES_REPORTING_SEQ.Bind(fleF190_COMP_CODES);
                fldF190_COMP_CODES_UNITS_DOLLARS_FLAG.Bind(fleF190_COMP_CODES);
                fldF190_COMP_CODES_FACTOR.Bind(fleF190_COMP_CODES);
                fldF190_COMP_CODES_AMT_PER_UNIT.Bind(fleF190_COMP_CODES);
                fldF190_COMP_CODES_PERCENT_GST.Bind(fleF190_COMP_CODES);
                fldF190_COMP_CODES_AMT_TAXABLE.Bind(fleF190_COMP_CODES);
                fldF190_COMP_CODES_DOC_TAX_RPT_FLAG.Bind(fleF190_COMP_CODES);
                fldF190_COMP_CODES_T4_NET_PAY_FLAG.Bind(fleF190_COMP_CODES);
                fldF190_COMP_CODES_T4_NET_TAX_FLAG.Bind(fleF190_COMP_CODES);
                fldF190_COMP_CODES_T4_NET_DEDUC_FLAG.Bind(fleF190_COMP_CODES);
                fldF190_COMP_CODES_PROCESS_MIN.Bind(fleF190_COMP_CODES);
                fldF190_COMP_CODES_PROCESS_MAX.Bind(fleF190_COMP_CODES);
                fldF190_COMP_CODES_FISCAL_MAX.Bind(fleF190_COMP_CODES);
                fldF190_COMP_CODES_CALENDAR_MAX.Bind(fleF190_COMP_CODES);
                fldF190_COMP_CODES_LTD_MAX.Bind(fleF190_COMP_CODES);
               
                fldF190_COMP_CODES_AFFECT_GROSS1.Bind(fleF190_COMP_CODES);
                fldF190_COMP_CODES_AFFECT_GROSS2.Bind(fleF190_COMP_CODES);
                fldF190_COMP_CODES_AFFECT_GROSS3.Bind(fleF190_COMP_CODES);
                fldF190_COMP_CODES_AFFECT_GROSS4.Bind(fleF190_COMP_CODES);
                fldF190_COMP_CODES_AFFECT_GROSS5.Bind(fleF190_COMP_CODES);
                fldF190_COMP_CODES_AFFECT_GROSS6.Bind(fleF190_COMP_CODES);
                fldF190_COMP_CODES_AFFECT_GROSS7.Bind(fleF190_COMP_CODES);
                fldF190_COMP_CODES_AFFECT_GROSS8.Bind(fleF190_COMP_CODES);
                fldF190_COMP_CODES_AFFECT_GROSS9.Bind(fleF190_COMP_CODES);
                fldF190_COMP_CODES_AFFECT_GROSS10.Bind(fleF190_COMP_CODES);
                fldF190_COMP_CODES_AFFECT_GROSS11.Bind(fleF190_COMP_CODES);
                fldF190_COMP_CODES_AFFECT_GROSS12.Bind(fleF190_COMP_CODES);
                fldF190_COMP_CODES_AFFECT_GROSS13.Bind(fleF190_COMP_CODES);
                fldF190_COMP_CODES_AFFECT_GROSS14.Bind(fleF190_COMP_CODES);
                fldF190_COMP_CODES_AFFECT_GROSS15.Bind(fleF190_COMP_CODES);
                fldF190_COMP_CODES_AFFECT_GROSS16.Bind(fleF190_COMP_CODES);
                fldF190_COMP_CODES_AFFECT_GROSS17.Bind(fleF190_COMP_CODES);
                fldF190_COMP_CODES_AFFECT_GROSS18.Bind(fleF190_COMP_CODES);
                fldF190_COMP_CODES_AFFECT_GROSS19.Bind(fleF190_COMP_CODES);
                fldF190_COMP_CODES_AFFECT_GROSS20.Bind(fleF190_COMP_CODES);

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



        private void fldF190_COMP_CODES_DESC_SHORT_LookupNotOn(ref bool LookupNotOnExecuted)
        {

            try
            {
                bool blnAlreadyExists = false;
                StringBuilder strSQL = new StringBuilder("SELECT ").Append(fleF190_COMP_CODES.ElementOwner("DESC_SHORT"));
                strSQL.Append(" FROM ");
                strSQL.Append(fleF190_COMP_CODES.TableNameWithAlias());
                strSQL.Append(" WHERE ");
                strSQL.Append("     ").Append(fleF190_COMP_CODES.ElementOwner("DESC_SHORT")).Append(" = ").Append(Common.StringToField(FieldText));

                if (!LookupNotOn(strSQL, fleF190_COMP_CODES, "DESC_SHORT", FieldText))
                {
                    blnAlreadyExists = true;
                }

                if (blnAlreadyExists)
                {
                    ErrorMessage("Error - The 1st 15 characters (`short` description) are NOT UNIQUE.\a");
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




        private void fldF190_COMP_CODES_COMP_CODE_LookupNotOn(ref bool LookupNotOnExecuted)
        {

            try
            {
                bool blnAlreadyExists = false;
                StringBuilder strSQL = new StringBuilder("SELECT ").Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE"));
                strSQL.Append(" FROM ");
                strSQL.Append(fleF190_COMP_CODES.TableNameWithAlias());
                strSQL.Append(" WHERE ");
                strSQL.Append("     ").Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ").Append(Common.StringToField(FieldText));

                if (!LookupNotOn(strSQL, fleF190_COMP_CODES, "COMP_CODE", FieldText))
                {
                    blnAlreadyExists = true;
                }

                if (blnAlreadyExists)
                {
                    ErrorMessage("Error -  This COMPENSATION CODE has already been defined.\a");
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



        private void dsrDesigner_GROS_Click(object sender, System.EventArgs e)
        {

            try
            {

                object[] arrRunscreen = { fleF190_COMP_CODES };
                RunScreen(new Billing_M190A(), RunScreenModes.Find, ref arrRunscreen);


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
                switch (m_intPath)
                {
                    case 1:
                        m_strWhere = new StringBuilder(GetWhereCondition(fleF190_COMP_CODES.ElementOwner("COMP_CODE"), fleF190_COMP_CODES.GetStringValue("COMP_CODE"), ref blnAddWhere));
                        fleF190_COMP_CODES.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
                        break;
                    case 2:
                        m_strWhere = new StringBuilder(GetWhereCondition(fleF190_COMP_CODES.ElementOwner("DESC_SHORT"), fleF190_COMP_CODES.GetStringValue("DESC_SHORT"), ref blnAddWhere));
                        fleF190_COMP_CODES.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
                        break;
                    default:
                        fleF190_COMP_CODES.GetData(GetDataOptions.Sequential | GetDataOptions.CreateSubSelect);
                        break;
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
                m_intPath = 0;

                RequestPrompt(ref fldF190_COMP_CODES_COMP_CODE);
                if (m_blnPromptOK)
                {
                    m_intPath = 1;
                }
                if (m_intPath == 0)
                {
                    RequestPrompt(ref fldF190_COMP_CODES_DESC_SHORT);
                    if (m_blnPromptOK)
                    {
                        m_intPath = 2;
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
                Page.PageTitle = X_SCR_NAME.Value;



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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 6/2/2017 12:43:45 PM
        //#-----------------------------------------
        protected override bool Entry()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 6/2/2017 12:43:45 PM
                Accept(ref fldF190_COMP_CODES_COMP_CODE);
                Accept(ref fldF190_COMP_CODES_COMP_TYPE);
                if (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("COMP_TYPE")) == QDesign.NULL("I"))
                {
                    Accept(ref fldF190_COMP_CODES_COMP_SUB_TYPE);
                }
                else
                {
                    Display(ref fldF190_COMP_CODES_COMP_SUB_TYPE);
                }
                Accept(ref fldF190_COMP_CODES_COMP_OWNER);
                Accept(ref fldF190_COMP_CODES_DESC_LONG);
                Accept(ref fldF190_COMP_CODES_DESC_SHORT);
                Accept(ref fldF190_COMP_CODES_PROCESS_SEQ);
                Accept(ref fldF190_COMP_CODES_COMP_CODE_GROUP);
                Accept(ref fldF190_COMP_CODES_REPORTING_SEQ);
                Accept(ref fldF190_COMP_CODES_UNITS_DOLLARS_FLAG);
                Accept(ref fldF190_COMP_CODES_FACTOR);
                Accept(ref fldF190_COMP_CODES_AMT_PER_UNIT);
                Accept(ref fldF190_COMP_CODES_PERCENT_GST);
                Accept(ref fldF190_COMP_CODES_AMT_TAXABLE);
                Accept(ref fldF190_COMP_CODES_DOC_TAX_RPT_FLAG);
                Accept(ref fldF190_COMP_CODES_T4_NET_PAY_FLAG);
                Accept(ref fldF190_COMP_CODES_T4_NET_TAX_FLAG);
                Accept(ref fldF190_COMP_CODES_T4_NET_DEDUC_FLAG);
                Accept(ref fldF190_COMP_CODES_PROCESS_MIN);
                Accept(ref fldF190_COMP_CODES_PROCESS_MAX);
                Accept(ref fldF190_COMP_CODES_FISCAL_MAX);
                Accept(ref fldF190_COMP_CODES_CALENDAR_MAX);
                Accept(ref fldF190_COMP_CODES_LTD_MAX);
            
                Accept(ref fldF190_COMP_CODES_AFFECT_GROSS1);
                Accept(ref fldF190_COMP_CODES_AFFECT_GROSS2);
                Accept(ref fldF190_COMP_CODES_AFFECT_GROSS3);
                Accept(ref fldF190_COMP_CODES_AFFECT_GROSS4);
                Accept(ref fldF190_COMP_CODES_AFFECT_GROSS5);
                Accept(ref fldF190_COMP_CODES_AFFECT_GROSS6);
                Accept(ref fldF190_COMP_CODES_AFFECT_GROSS7);
                Accept(ref fldF190_COMP_CODES_AFFECT_GROSS8);
                Accept(ref fldF190_COMP_CODES_AFFECT_GROSS9);
                Accept(ref fldF190_COMP_CODES_AFFECT_GROSS10);
                Accept(ref fldF190_COMP_CODES_AFFECT_GROSS11);
                Accept(ref fldF190_COMP_CODES_AFFECT_GROSS12);
                Accept(ref fldF190_COMP_CODES_AFFECT_GROSS13);
                Accept(ref fldF190_COMP_CODES_AFFECT_GROSS14);
                Accept(ref fldF190_COMP_CODES_AFFECT_GROSS15);
                Accept(ref fldF190_COMP_CODES_AFFECT_GROSS16);
                Accept(ref fldF190_COMP_CODES_AFFECT_GROSS17);
                Accept(ref fldF190_COMP_CODES_AFFECT_GROSS18);
                Accept(ref fldF190_COMP_CODES_AFFECT_GROSS19);
                Accept(ref fldF190_COMP_CODES_AFFECT_GROSS20);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 6/2/2017 12:43:45 PM
        //#-----------------------------------------
        protected override bool Update()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 6/2/2017 12:43:45 PM
                fleF190_COMP_CODES.PutData();
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 6/2/2017 12:43:45 PM
        //#-----------------------------------------
        protected override bool Delete()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 6/2/2017 12:43:45 PM
                fleF190_COMP_CODES.DeletedRecord = true;
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
        //# dsrDesigner_09_Click Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 6/2/2017 12:43:45 PM
        //#-----------------------------------------
        private void dsrDesigner_09_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 6/2/2017 12:43:45 PM
                Accept(ref fldF190_COMP_CODES_DOC_TAX_RPT_FLAG);
                Accept(ref fldF190_COMP_CODES_T4_NET_PAY_FLAG);
                Accept(ref fldF190_COMP_CODES_T4_NET_TAX_FLAG);
                Accept(ref fldF190_COMP_CODES_T4_NET_DEDUC_FLAG);
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
        //# dsrDesigner_13_Click Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 6/2/2017 12:43:45 PM
        //#-----------------------------------------
        private void dsrDesigner_13_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 6/2/2017 12:43:45 PM
              
                Accept(ref fldF190_COMP_CODES_AFFECT_GROSS11);
                Accept(ref fldF190_COMP_CODES_AFFECT_GROSS12);
                Accept(ref fldF190_COMP_CODES_AFFECT_GROSS13);
                Accept(ref fldF190_COMP_CODES_AFFECT_GROSS14);
                Accept(ref fldF190_COMP_CODES_AFFECT_GROSS15);
                Accept(ref fldF190_COMP_CODES_AFFECT_GROSS16);
                Accept(ref fldF190_COMP_CODES_AFFECT_GROSS17);
                Accept(ref fldF190_COMP_CODES_AFFECT_GROSS18);
                Accept(ref fldF190_COMP_CODES_AFFECT_GROSS19);
                Accept(ref fldF190_COMP_CODES_AFFECT_GROSS20);
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
        //# dsrDesigner_11_Click Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 6/2/2017 12:43:45 PM
        //#-----------------------------------------
        private void dsrDesigner_11_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 6/2/2017 12:43:45 PM
                Accept(ref fldF190_COMP_CODES_FISCAL_MAX);
                Accept(ref fldF190_COMP_CODES_CALENDAR_MAX);
                Accept(ref fldF190_COMP_CODES_LTD_MAX);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 6/2/2017 12:43:45 PM
        //#-----------------------------------------
        private void dsrDesigner_04_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 6/2/2017 12:43:45 PM
                Accept(ref fldF190_COMP_CODES_DESC_LONG);
                Accept(ref fldF190_COMP_CODES_DESC_SHORT);
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
        //# dsrDesigner_10_Click Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 6/2/2017 12:43:45 PM
        //#-----------------------------------------
        private void dsrDesigner_10_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 6/2/2017 12:43:45 PM
                Accept(ref fldF190_COMP_CODES_PROCESS_MIN);
                Accept(ref fldF190_COMP_CODES_PROCESS_MAX);
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
        //# dsrDesigner_08_Click Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 6/2/2017 12:43:45 PM
        //#-----------------------------------------
        private void dsrDesigner_08_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 6/2/2017 12:43:45 PM
                Accept(ref fldF190_COMP_CODES_UNITS_DOLLARS_FLAG);
                Accept(ref fldF190_COMP_CODES_FACTOR);
                Accept(ref fldF190_COMP_CODES_AMT_PER_UNIT);
                Accept(ref fldF190_COMP_CODES_PERCENT_GST);
                Accept(ref fldF190_COMP_CODES_AMT_TAXABLE);
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
        //# dsrDesigner_12_Click Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 6/2/2017 12:43:45 PM
        //#-----------------------------------------
        private void dsrDesigner_12_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 6/2/2017 12:43:45 PM
              
                Accept(ref fldF190_COMP_CODES_AFFECT_GROSS1);
                Accept(ref fldF190_COMP_CODES_AFFECT_GROSS2);
                Accept(ref fldF190_COMP_CODES_AFFECT_GROSS3);
                Accept(ref fldF190_COMP_CODES_AFFECT_GROSS4);
                Accept(ref fldF190_COMP_CODES_AFFECT_GROSS5);
                Accept(ref fldF190_COMP_CODES_AFFECT_GROSS6);
                Accept(ref fldF190_COMP_CODES_AFFECT_GROSS7);
                Accept(ref fldF190_COMP_CODES_AFFECT_GROSS8);
                Accept(ref fldF190_COMP_CODES_AFFECT_GROSS9);
                Accept(ref fldF190_COMP_CODES_AFFECT_GROSS10);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 6/2/2017 12:43:45 PM
        //#-----------------------------------------
        private void dsrDesigner_02_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 6/2/2017 12:43:45 PM
                Accept(ref fldF190_COMP_CODES_COMP_TYPE);
                Accept(ref fldF190_COMP_CODES_COMP_SUB_TYPE);
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
