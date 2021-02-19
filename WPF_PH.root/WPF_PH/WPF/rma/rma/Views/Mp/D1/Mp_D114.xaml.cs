
#region "Screen Comments"


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

    partial class Mp_D114 : BasePage
    {

        #region " Form Designer Generated Code "





        public Mp_D114()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "D114";

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
            dtlF114_SPECIAL_PAYMENTS.EditClick += dtlF114_SPECIAL_PAYMENTS_EditClick;
         
            base.Page_Load();

            // TODO: If any DESIGNER procedures function on occurring FILES or TEMPORARIES, set the grid's AllowSelectRowButton property to TRUE.



            // TODO: The following elements have Input/Output Scaling defined in the Dictionary or Screen.  Manual steps may be required:
            //       F114_SPECIAL_PAYMENTS.AMT_GROSS InputScale: 2 OutputScale: 0
            //       F114_SPECIAL_PAYMENTS.AMT_NET InputScale: 2 OutputScale: 0


        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            fleF114_SPECIAL_PAYMENTS = new SqlFileObject(this, FileTypes.Primary, 18, "INDEXED", "F114_SPECIAL_PAYMENTS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Reference, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_cnnQUERY");
            fleF191_EARNINGS_PERIOD = new SqlFileObject(this, FileTypes.Reference, 0, "INDEXED", "F191_EARNINGS_PERIOD", "", false, false, false, 0, "m_cnnQUERY");
            fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Reference, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_cnnQUERY");
            COMLINE = new CoreCharacter("COMLINE", 256, this, Common.cEmptyString);

           
            fleF020_DOCTOR_MSTR.Access += fleF020_DOCTOR_MSTR_Access;
            fleF191_EARNINGS_PERIOD.Access += fleF191_EARNINGS_PERIOD_Access;
            fleF190_COMP_CODES.Access += fleF190_COMP_CODES_Access;
            X_SCREEN_NAME.GetValue += X_SCREEN_NAME_GetValue;
            X_SCR_NAME.GetValue += X_SCR_NAME_GetValue;
            fleF114_SPECIAL_PAYMENTS.InitializeItems += fleF114_SPECIAL_PAYMENTS_InitializeItems;
        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;
            fleF020_DOCTOR_MSTR.Access -= fleF020_DOCTOR_MSTR_Access;
            fleF191_EARNINGS_PERIOD.Access -= fleF191_EARNINGS_PERIOD_Access;
            fleF190_COMP_CODES.Access -= fleF190_COMP_CODES_Access;
            X_SCREEN_NAME.GetValue -= X_SCREEN_NAME_GetValue;
            X_SCR_NAME.GetValue -= X_SCR_NAME_GetValue;
            fldF114_SPECIAL_PAYMENTS_EP_NBR_FROM.LookupOn -= fldF114_SPECIAL_PAYMENTS_EP_NBR_FROM_LookupOn;
            fldF114_SPECIAL_PAYMENTS_COMP_CODE.LookupOn -= fldF114_SPECIAL_PAYMENTS_COMP_CODE_LookupOn;
            fldF114_SPECIAL_PAYMENTS_DOC_NBR.LookupOn -= fldF114_SPECIAL_PAYMENTS_DOC_NBR_LookupOn;

            dsrDesigner_01.Click -= dsrDesigner_01_Click;
            dtlF114_SPECIAL_PAYMENTS.EditClick -= dtlF114_SPECIAL_PAYMENTS_EditClick;
            fleF114_SPECIAL_PAYMENTS.InitializeItems -= fleF114_SPECIAL_PAYMENTS_InitializeItems;
            fldF114_SPECIAL_PAYMENTS_AMT_GROSS.Process -= fldF114_SPECIAL_PAYMENTS_AMT_GROSS_Process;
            fldF114_SPECIAL_PAYMENTS_EP_NBR_FROM.Process -= fldF114_SPECIAL_PAYMENTS_EP_NBR_FROM_Process;
        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private SqlConnection m_cnnQUERY = new SqlConnection();
        private SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
        private SqlTransaction m_trnTRANS_UPDATE;
        private SqlFileObject fleF114_SPECIAL_PAYMENTS;

        private void fleF114_SPECIAL_PAYMENTS_InitializeItems(bool Fixed)
        {

            try
            {
                if (!Fixed)
                    fleF114_SPECIAL_PAYMENTS.set_SetValue("LAST_MOD_DATE", true, QDesign.SysDate(ref m_cnnQUERY));
                if (!Fixed)
                    fleF114_SPECIAL_PAYMENTS.set_SetValue("LAST_MOD_USER_ID", true, UserID);


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

                strText.Append(" WHERE ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ").Append(Common.StringToField(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")));

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

        private SqlFileObject fleF191_EARNINGS_PERIOD;

        private void fleF191_EARNINGS_PERIOD_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");



                strText.Append(" ORDER BY ").Append(fleF191_EARNINGS_PERIOD.ElementOwner("EP_NBR"));
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

        private SqlFileObject fleF190_COMP_CODES;

        private void fleF190_COMP_CODES_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE  ").Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ").Append(Common.StringToField(fleF190_COMP_CODES.GetStringValue("COMP_CODE")));


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

        private CoreCharacter COMLINE;
        private DCharacter X_SCREEN_NAME = new DCharacter(55);
        private void X_SCREEN_NAME_GetValue(ref string Value)
        {

            try
            {
                Value = "Special Payments";


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
        //# Do not delete, modify or move it.  Updated: 5/26/2017 10:17:58 AM

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
        //# Do not delete, modify or move it.  Updated: 5/26/2017 10:17:58 AM

        protected TextBox fldF114_SPECIAL_PAYMENTS_DOC_NBR;
        protected TextBox fldF114_SPECIAL_PAYMENTS_COMP_CODE;
        protected TextBox fldF114_SPECIAL_PAYMENTS_EP_NBR_FROM;
        protected TextBox fldF114_SPECIAL_PAYMENTS_EP_NBR_TO;
        protected TextBox fldF114_SPECIAL_PAYMENTS_COMP_UNITS;
        protected TextBox fldF114_SPECIAL_PAYMENTS_AMT_GROSS;

        protected TextBox fldF114_SPECIAL_PAYMENTS_AMT_NET;

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/26/2017 10:17:58 AM

        //#-----------------------------------------
        //# GetGridFieldObject Procedure.
        //#-----------------------------------------

        protected override void GetGridFieldObject(object DataListField, ref object CoreField, string Name)
        {

            try
            {
                switch (Name.ToUpper())
                {
                    case "FLDGRDF114_SPECIAL_PAYMENTS_DOC_NBR":
                        fldF114_SPECIAL_PAYMENTS_DOC_NBR = (TextBox)DataListField;

                        fldF114_SPECIAL_PAYMENTS_DOC_NBR.LookupOn -= fldF114_SPECIAL_PAYMENTS_DOC_NBR_LookupOn;
                        fldF114_SPECIAL_PAYMENTS_DOC_NBR.LookupOn += fldF114_SPECIAL_PAYMENTS_DOC_NBR_LookupOn;
                        CoreField = fldF114_SPECIAL_PAYMENTS_DOC_NBR;
                        fldF114_SPECIAL_PAYMENTS_DOC_NBR.Bind(fleF114_SPECIAL_PAYMENTS);
                        break;
                    case "FLDGRDF114_SPECIAL_PAYMENTS_COMP_CODE":
                        fldF114_SPECIAL_PAYMENTS_COMP_CODE = (TextBox)DataListField;

                        fldF114_SPECIAL_PAYMENTS_COMP_CODE.LookupOn -= fldF114_SPECIAL_PAYMENTS_COMP_CODE_LookupOn;
                        fldF114_SPECIAL_PAYMENTS_COMP_CODE.LookupOn += fldF114_SPECIAL_PAYMENTS_COMP_CODE_LookupOn;
                        CoreField = fldF114_SPECIAL_PAYMENTS_COMP_CODE;
                        fldF114_SPECIAL_PAYMENTS_COMP_CODE.Bind(fleF114_SPECIAL_PAYMENTS);
                        break;
                    case "FLDGRDF114_SPECIAL_PAYMENTS_EP_NBR_FROM":
                        fldF114_SPECIAL_PAYMENTS_EP_NBR_FROM = (TextBox)DataListField;

                        fldF114_SPECIAL_PAYMENTS_EP_NBR_FROM.LookupOn -= fldF114_SPECIAL_PAYMENTS_EP_NBR_FROM_LookupOn;
                        fldF114_SPECIAL_PAYMENTS_EP_NBR_FROM.LookupOn += fldF114_SPECIAL_PAYMENTS_EP_NBR_FROM_LookupOn;
                        fldF114_SPECIAL_PAYMENTS_EP_NBR_FROM.Process -= fldF114_SPECIAL_PAYMENTS_EP_NBR_FROM_Process;
                        fldF114_SPECIAL_PAYMENTS_EP_NBR_FROM.Process += fldF114_SPECIAL_PAYMENTS_EP_NBR_FROM_Process;
                        CoreField = fldF114_SPECIAL_PAYMENTS_EP_NBR_FROM;
                        fldF114_SPECIAL_PAYMENTS_EP_NBR_FROM.Bind(fleF114_SPECIAL_PAYMENTS);
                        break;
                    case "FLDGRDF114_SPECIAL_PAYMENTS_EP_NBR_TO":
                        fldF114_SPECIAL_PAYMENTS_EP_NBR_TO = (TextBox)DataListField;
                        CoreField = fldF114_SPECIAL_PAYMENTS_EP_NBR_TO;
                        fldF114_SPECIAL_PAYMENTS_EP_NBR_TO.Bind(fleF114_SPECIAL_PAYMENTS);
                        break;
                    case "FLDGRDF114_SPECIAL_PAYMENTS_COMP_UNITS":
                        fldF114_SPECIAL_PAYMENTS_COMP_UNITS = (TextBox)DataListField;
                        CoreField = fldF114_SPECIAL_PAYMENTS_COMP_UNITS;
                        fldF114_SPECIAL_PAYMENTS_COMP_UNITS.Bind(fleF114_SPECIAL_PAYMENTS);
                        break;
                    case "FLDGRDF114_SPECIAL_PAYMENTS_AMT_GROSS":
                        fldF114_SPECIAL_PAYMENTS_AMT_GROSS = (TextBox)DataListField;

                        fldF114_SPECIAL_PAYMENTS_AMT_GROSS.Process -= fldF114_SPECIAL_PAYMENTS_AMT_GROSS_Process;
                        fldF114_SPECIAL_PAYMENTS_AMT_GROSS.Process += fldF114_SPECIAL_PAYMENTS_AMT_GROSS_Process;
                      
                        CoreField = fldF114_SPECIAL_PAYMENTS_AMT_GROSS;
                        fldF114_SPECIAL_PAYMENTS_AMT_GROSS.Bind(fleF114_SPECIAL_PAYMENTS);
                        break;
                    case "FLDGRDF114_SPECIAL_PAYMENTS_AMT_NET":
                        fldF114_SPECIAL_PAYMENTS_AMT_NET = (TextBox)DataListField;
                        CoreField = fldF114_SPECIAL_PAYMENTS_AMT_NET;
                        fldF114_SPECIAL_PAYMENTS_AMT_NET.Bind(fleF114_SPECIAL_PAYMENTS);
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
                dtlF114_SPECIAL_PAYMENTS.OccursWithFile = fleF114_SPECIAL_PAYMENTS;

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
        //# Do not delete, modify or move it.  Updated: 5/26/2017 10:17:58 AM

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
            fleF114_SPECIAL_PAYMENTS.Transaction = m_trnTRANS_UPDATE;


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/26/2017 10:17:58 AM

        //#-----------------------------------------
        //# InitializeFiles Procedure.
        //#-----------------------------------------

        protected override void InitializeFiles()
        {

            try
            {
                Initialize_TRANS_UPDATE();
                fleF020_DOCTOR_MSTR.Connection = m_cnnQUERY;
                fleF191_EARNINGS_PERIOD.Connection = m_cnnQUERY;
                fleF190_COMP_CODES.Connection = m_cnnQUERY;


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
                fleF114_SPECIAL_PAYMENTS.Dispose();
                fleF020_DOCTOR_MSTR.Dispose();
                fleF191_EARNINGS_PERIOD.Dispose();
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

        #endregion

        #region "Update Validation"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.

        #endregion


        #region "RecordBuffer Events"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/26/2017 10:17:58 AM



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



        private void fldF114_SPECIAL_PAYMENTS_EP_NBR_FROM_LookupOn()
        {

            try
            {
                StringBuilder strSQL = new StringBuilder(string.Empty);
                strSQL.Append(" WHERE EP_NBR = ").Append(FieldValue);

                fleF191_EARNINGS_PERIOD.GetData(strSQL.ToString(), GetDataOptions.IsOptional);
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




        private void fldF114_SPECIAL_PAYMENTS_COMP_CODE_LookupOn()
        {

            try
            {
                StringBuilder strSQL = new StringBuilder(" WHERE ");
                strSQL.Append("     ").Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ").Append(Common.StringToField(FieldText));

                fleF190_COMP_CODES.GetData(strSQL.ToString(), GetDataOptions.IsOptional);
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




        private void fldF114_SPECIAL_PAYMENTS_DOC_NBR_LookupOn()
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


        #endregion

        #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"



        private void fldF114_SPECIAL_PAYMENTS_AMT_GROSS_Process()
        {

            try
            {

                fleF114_SPECIAL_PAYMENTS.set_SetValue("AMT_NET", fleF114_SPECIAL_PAYMENTS.GetDecimalValue("AMT_GROSS"));
                Display(ref fldF114_SPECIAL_PAYMENTS_AMT_NET);


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



        private void fldF114_SPECIAL_PAYMENTS_EP_NBR_FROM_Process()
        {

            try
            {

                fleF114_SPECIAL_PAYMENTS.set_SetValue("EP_NBR_TO", fleF114_SPECIAL_PAYMENTS.GetDecimalValue("EP_NBR_FROM"));
                Display(ref fldF114_SPECIAL_PAYMENTS_EP_NBR_TO);


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
                        m_strWhere = new StringBuilder(GetWhereCondition(fleF114_SPECIAL_PAYMENTS.ElementOwner("DOC_NBR"), fleF114_SPECIAL_PAYMENTS.GetStringValue("DOC_NBR"), ref blnAddWhere));
                        m_strWhere.Append(GetWhereCondition(fleF114_SPECIAL_PAYMENTS.ElementOwner("COMP_CODE"), fleF114_SPECIAL_PAYMENTS.GetStringValue("COMP_CODE"), ref blnAddWhere));
                        m_strWhere.Append(GetWhereCondition(fleF114_SPECIAL_PAYMENTS.ElementOwner("EP_NBR_FROM"), fleF114_SPECIAL_PAYMENTS.GetDecimalValue("EP_NBR_FROM"), ref blnAddWhere));
                        fleF114_SPECIAL_PAYMENTS.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
                        break;
                    default:
                        fleF114_SPECIAL_PAYMENTS.GetData(GetDataOptions.Sequential | GetDataOptions.CreateSubSelect);
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

                RequestPrompt(ref fldF114_SPECIAL_PAYMENTS_DOC_NBR);
                if (m_blnPromptOK)
                {
                    RequestPrompt(ref fldF114_SPECIAL_PAYMENTS_COMP_CODE);
                    if (m_blnPromptOK)
                    {
                        RequestPrompt(ref fldF114_SPECIAL_PAYMENTS_EP_NBR_FROM);
                        if (m_blnPromptOK)
                        {
                            m_intPath = 1;
                        }
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
        //# Append Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/26/2017 10:17:58 AM
        //#-----------------------------------------
        protected override bool Append()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/26/2017 10:17:58 AM
                Accept(ref fldF114_SPECIAL_PAYMENTS_DOC_NBR);
                Accept(ref fldF114_SPECIAL_PAYMENTS_COMP_CODE);
                Accept(ref fldF114_SPECIAL_PAYMENTS_EP_NBR_FROM);
                Display(ref fldF114_SPECIAL_PAYMENTS_EP_NBR_TO);
                Display(ref fldF114_SPECIAL_PAYMENTS_COMP_UNITS);
                Accept(ref fldF114_SPECIAL_PAYMENTS_AMT_GROSS);
                Display(ref fldF114_SPECIAL_PAYMENTS_AMT_NET);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/26/2017 10:17:58 AM
        //#-----------------------------------------
        protected override bool Update()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/26/2017 10:17:58 AM
                while (fleF114_SPECIAL_PAYMENTS.For())
                {
                    fleF114_SPECIAL_PAYMENTS.PutData(false, PutTypes.Deleted);
                }
                while (fleF114_SPECIAL_PAYMENTS.For())
                {
                    fleF114_SPECIAL_PAYMENTS.PutData();
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/26/2017 10:17:58 AM
        //#-----------------------------------------
        protected override bool Delete()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/26/2017 10:17:58 AM
                fleF114_SPECIAL_PAYMENTS.DeletedRecord = true;
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
        //# dtlF114_SPECIAL_PAYMENTS_EditClick Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/26/2017 10:17:58 AM
        //#-----------------------------------------
        private void dtlF114_SPECIAL_PAYMENTS_EditClick(DataList source, GridButtonEventArgs GridButtonEventArgs)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/26/2017 10:17:58 AM
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/26/2017 10:17:58 AM
        //#-----------------------------------------
        private void dsrDesigner_01_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/26/2017 10:17:58 AM
                if (!fleF114_SPECIAL_PAYMENTS.NewRecord)
                {
                    Display(ref fldF114_SPECIAL_PAYMENTS_DOC_NBR);
                }
                else
                {
                    Accept(ref fldF114_SPECIAL_PAYMENTS_DOC_NBR);
                }
                if (!fleF114_SPECIAL_PAYMENTS.NewRecord)
                {
                    Display(ref fldF114_SPECIAL_PAYMENTS_COMP_CODE);
                }
                else
                {
                    Accept(ref fldF114_SPECIAL_PAYMENTS_COMP_CODE);
                }
                if (!fleF114_SPECIAL_PAYMENTS.NewRecord)
                {
                    Display(ref fldF114_SPECIAL_PAYMENTS_EP_NBR_FROM);
                }
                else
                {
                    Accept(ref fldF114_SPECIAL_PAYMENTS_EP_NBR_FROM);
                }
                Display(ref fldF114_SPECIAL_PAYMENTS_EP_NBR_TO);
                Display(ref fldF114_SPECIAL_PAYMENTS_COMP_UNITS);
                Accept(ref fldF114_SPECIAL_PAYMENTS_AMT_GROSS);
                Display(ref fldF114_SPECIAL_PAYMENTS_AMT_NET);
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

