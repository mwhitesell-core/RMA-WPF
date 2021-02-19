
#region "Screen Comments"

// #> PROGRAM-ID.     D110.QKS
// ((C)) Dyad Technologies
// PURPOSE: Query/modifications to Physician NOTES
// MODIFICATION HISTORY
// DATE    SAF #  WHO      DESCRIPTION
// 1999/Jan/21  ____   S.B.     - Fixed date sizes and alignment for Y2K
// compliance.  
// - Removed the display field `process-seq` 
// to create space.
// 1999/Jun/07 S.B.      - Altered the call to scrtitle.use and
// stdhilite.use to be called from $use
// instead of src.
// - Removed the call to secfile.use because
// it was not doing anything.
// 2003/nov/10 b.e.      - alpha doctor nbr
// 2006/apr/10 b.e.      - allow for 9 digit amt-gross and amt-net
// 2007/nov/20 M.C.  - Brad requested not allow changes on amt-net
// - reactivate process `amt-gross` and `factor`                      
// 2014/aug/12 MC1       - add f110-compensation-audit to capture before change records
// - save f110-compensation records in f110-compensation-audit in postfind in case
// user may change the records

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

    partial class D110 : BasePage
    {

        #region " Form Designer Generated Code "





        public D110()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "D110";

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
            dsrDesigner_FIX.Click += dsrDesigner_FIX_Click;
            dtlF110_COMPENSATION.EditClick += dtlF110_COMPENSATION_EditClick;
            base.Page_Load();

            // TODO: If any DESIGNER procedures function on occurring FILES or TEMPORARIES, set the grid's AllowSelectRowButton property to TRUE.



            // TODO: The following elements have Input/Output Scaling defined in the Dictionary or Screen.  Manual steps may be required:
            //       F110_COMPENSATION.AMT_GROSS InputScale: 2 OutputScale: 0
            //       F110_COMPENSATION.AMT_NET InputScale: 2 OutputScale: 0
            //       F110_COMPENSATION.FACTOR InputScale: 4 OutputScale: 0
            //       F110_COMPENSATION_AUDIT.AMT_GROSS InputScale: 2 OutputScale: 0
            //       F110_COMPENSATION_AUDIT.AMT_NET InputScale: 2 OutputScale: 0
            //       F110_COMPENSATION_AUDIT.FACTOR InputScale: 4 OutputScale: 0
            //       F190_COMP_CODES.FACTOR InputScale: 4 OutputScale: 0


        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Master, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleCONSTANTS_MSTR_REC_6 = new SqlFileObject(this, FileTypes.Master, 0, "INDEXED", "F090_CONSTANTS_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            W_DOC_NBR = new CoreCharacter("W_DOC_NBR", 3, this, Common.cEmptyString);
            W_EP_NBR_FROM = new CoreDecimal("W_EP_NBR_FROM", 6, this);
            W_EP_NBR_TO = new CoreDecimal("W_EP_NBR_TO", 6, this);
            X_SRCH_CODE = new CoreCharacter("X_SRCH_CODE", 6, this, Common.cEmptyString);
            fleF110_COMPENSATION = new SqlFileObject(this, FileTypes.Primary, 15, "INDEXED", "F110_COMPENSATION", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF110_COMPENSATION_AUDIT = new SqlFileObject(this, FileTypes.Designer, fleF110_COMPENSATION, "SEQUENTIAL", "F110_COMPENSATION_AUDIT", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Reference, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_cnnQUERY");
            fleF191_EARNINGS_PERIOD = new SqlFileObject(this, FileTypes.Reference, 0, "INDEXED", "F191_EARNINGS_PERIOD", "", false, false, false, 0, "m_cnnQUERY");
            A_DOC_NBR = new CoreCharacter("A_DOC_NBR", 3, this, fleF110_COMPENSATION, Common.cEmptyString);
            A_EP_NBR = new CoreDecimal("A_EP_NBR", 6, this, fleF110_COMPENSATION, 0m);
            A_PROCESS_SEQ = new CoreDecimal("A_PROCESS_SEQ", 2, this, fleF110_COMPENSATION, 0m);
            A_COMP_CODE = new CoreCharacter("A_COMP_CODE", 6, this, fleF110_COMPENSATION, Common.cEmptyString);
            A_COMP_TYPE = new CoreCharacter("A_COMP_TYPE", 1, this, fleF110_COMPENSATION, Common.cEmptyString);
            A_FACTOR = new CoreDecimal("A_FACTOR", 6, this, fleF110_COMPENSATION, 0m);
            A_FACTOR_OVERRIDE = new CoreCharacter("A_FACTOR_OVERRIDE", 1, this, fleF110_COMPENSATION, Common.cEmptyString);
            A_COMP_UNITS = new CoreDecimal("A_COMP_UNITS", 6, this, fleF110_COMPENSATION, 0m);
            A_AMT_GROSS = new CoreDecimal("A_AMT_GROSS", 9, this, fleF110_COMPENSATION, 0m);
            A_AMT_NET = new CoreDecimal("A_AMT_NET", 9, this, fleF110_COMPENSATION, 0m);
            A_EP_NBR_ENTRY = new CoreDecimal("A_EP_NBR_ENTRY", 6, this, fleF110_COMPENSATION, 0m);
            A_COMPENSATION_STATUS = new CoreCharacter("A_COMPENSATION_STATUS", 1, this, fleF110_COMPENSATION, Common.cEmptyString);

            fleF190_COMP_CODES.Access += fleF190_COMP_CODES_Access;
            fleF191_EARNINGS_PERIOD.Access += fleF191_EARNINGS_PERIOD_Access;
            X_SCREEN_NAME.GetValue += X_SCREEN_NAME_GetValue;
            X_SCR_NAME.GetValue += X_SCR_NAME_GetValue;

        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;
            fleF190_COMP_CODES.Access -= fleF190_COMP_CODES_Access;
            fleF191_EARNINGS_PERIOD.Access -= fleF191_EARNINGS_PERIOD_Access;
            X_SCREEN_NAME.GetValue -= X_SCREEN_NAME_GetValue;
            X_SCR_NAME.GetValue -= X_SCR_NAME_GetValue;
            fldF110_COMPENSATION_COMP_CODE.LookupOn -= fldF110_COMPENSATION_COMP_CODE_LookupOn;
            fldF110_COMPENSATION_EP_NBR.LookupOn -= fldF110_COMPENSATION_EP_NBR_LookupOn;
            fldF110_COMPENSATION_EP_NBR.Edit -= fldF110_COMPENSATION_EP_NBR_Edit;
            fldF110_COMPENSATION_COMP_CODE.Input -= fldF110_COMPENSATION_COMP_CODE_Input;
            fldF110_COMPENSATION_COMP_CODE.Edit -= fldF110_COMPENSATION_COMP_CODE_Edit;

            dsrDesigner_01.Click -= dsrDesigner_01_Click;
            dsrDesigner_FIX.Click -= dsrDesigner_FIX_Click;


        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private SqlConnection m_cnnQUERY = new SqlConnection();
        private SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
        private SqlTransaction m_trnTRANS_UPDATE;
        private SqlFileObject fleF020_DOCTOR_MSTR;
        private SqlFileObject fleCONSTANTS_MSTR_REC_6;
        private CoreCharacter W_DOC_NBR;
        private CoreDecimal W_EP_NBR_FROM;
        private CoreDecimal W_EP_NBR_TO;
        private CoreCharacter X_SRCH_CODE;
        private SqlFileObject fleF110_COMPENSATION;
        private SqlFileObject fleF110_COMPENSATION_AUDIT;
        private SqlFileObject fleF190_COMP_CODES;

        private void fleF190_COMP_CODES_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ").Append(Common.StringToField(fleF110_COMPENSATION.GetStringValue("COMP_CODE")));

                strText.Append(" ORDER BY ").Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE"));
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

                strText.Append(" WHERE ").Append(fleF191_EARNINGS_PERIOD.ElementOwner("PED_YYYYMM")).Append(" = ").Append((fleF110_COMPENSATION.GetDecimalValue("EP_NBR")));

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

        //#CORE_BEGIN_INCLUDE: SAVEF110AUDIT_VAR"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/24/2017 11:14:22 AM

        private CoreCharacter A_DOC_NBR;
        private CoreDecimal A_EP_NBR;
        private CoreDecimal A_PROCESS_SEQ;
        private CoreCharacter A_COMP_CODE;
        private CoreCharacter A_COMP_TYPE;
        private CoreDecimal A_FACTOR;
        private CoreCharacter A_FACTOR_OVERRIDE;
        private CoreDecimal A_COMP_UNITS;
        private CoreDecimal A_AMT_GROSS;
        private CoreDecimal A_AMT_NET;
        private CoreDecimal A_EP_NBR_ENTRY;

        private CoreCharacter A_COMPENSATION_STATUS;
        //#CORE_END_INCLUDE: SAVEF110AUDIT_VAR"

        private DCharacter X_SCREEN_NAME = new DCharacter(55);
        private void X_SCREEN_NAME_GetValue(ref string Value)
        {

            try
            {
                Value = "EARNINGS - PAY PERIOD";


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
        //# Do not delete, modify or move it.  Updated: 5/24/2017 11:14:22 AM

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
        //# Do not delete, modify or move it.  Updated: 5/24/2017 11:14:22 AM

        protected TextBox fldF110_COMPENSATION_EP_NBR;
        protected TextBox fldF110_COMPENSATION_COMP_TYPE;
        protected TextBox fldF110_COMPENSATION_COMP_CODE;
        protected TextBox fldF190_COMP_CODES_DESC_SHORT;
        protected TextBox fldF110_COMPENSATION_FACTOR;
        protected TextBox fldF110_COMPENSATION_FACTOR_OVERRIDE;
        protected TextBox fldF110_COMPENSATION_COMP_UNITS;
        protected TextBox fldF110_COMPENSATION_AMT_GROSS;
        protected TextBox fldF110_COMPENSATION_AMT_NET;
        protected TextBox fldF110_COMPENSATION_COMPENSATION_STATUS;

        protected TextBox fldF110_COMPENSATION_EP_NBR_ENTRY;

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/24/2017 11:14:22 AM

        //#-----------------------------------------
        //# GetGridFieldObject Procedure.
        //#-----------------------------------------

        protected override void GetGridFieldObject(object DataListField, ref object CoreField, string Name)
        {

            try
            {
                switch (Name.ToUpper())
                {
                    case "FLDGRDF110_COMPENSATION_EP_NBR":
                        fldF110_COMPENSATION_EP_NBR = (TextBox)DataListField;

                        fldF110_COMPENSATION_EP_NBR.LookupOn -= fldF110_COMPENSATION_EP_NBR_LookupOn;
                        fldF110_COMPENSATION_EP_NBR.LookupOn += fldF110_COMPENSATION_EP_NBR_LookupOn;

                        fldF110_COMPENSATION_EP_NBR.Edit -= fldF110_COMPENSATION_EP_NBR_Edit;
                        fldF110_COMPENSATION_EP_NBR.Edit += fldF110_COMPENSATION_EP_NBR_Edit;
                        CoreField = fldF110_COMPENSATION_EP_NBR;
                        fldF110_COMPENSATION_EP_NBR.Bind(fleF110_COMPENSATION);
                        break;
                    case "FLDGRDF110_COMPENSATION_COMP_TYPE":
                        fldF110_COMPENSATION_COMP_TYPE = (TextBox)DataListField;
                        CoreField = fldF110_COMPENSATION_COMP_TYPE;
                        fldF110_COMPENSATION_COMP_TYPE.Bind(fleF110_COMPENSATION);
                        break;
                    case "FLDGRDF110_COMPENSATION_COMP_CODE":
                        fldF110_COMPENSATION_COMP_CODE = (TextBox)DataListField;

                        fldF110_COMPENSATION_COMP_CODE.LookupOn -= fldF110_COMPENSATION_COMP_CODE_LookupOn;
                        fldF110_COMPENSATION_COMP_CODE.LookupOn += fldF110_COMPENSATION_COMP_CODE_LookupOn;

                        fldF110_COMPENSATION_COMP_CODE.Input -= fldF110_COMPENSATION_COMP_CODE_Input;
                        fldF110_COMPENSATION_COMP_CODE.Input += fldF110_COMPENSATION_COMP_CODE_Input;

                        fldF110_COMPENSATION_COMP_CODE.Edit -= fldF110_COMPENSATION_COMP_CODE_Edit;
                        fldF110_COMPENSATION_COMP_CODE.Edit += fldF110_COMPENSATION_COMP_CODE_Edit;
                        CoreField = fldF110_COMPENSATION_COMP_CODE;
                        fldF110_COMPENSATION_COMP_CODE.Bind(fleF110_COMPENSATION);
                        break;
                    case "FLDGRDF190_COMP_CODES_DESC_SHORT":
                        fldF190_COMP_CODES_DESC_SHORT = (TextBox)DataListField;
                        CoreField = fldF190_COMP_CODES_DESC_SHORT;
                        fldF190_COMP_CODES_DESC_SHORT.Bind(fleF190_COMP_CODES);
                        break;
                    case "FLDGRDF110_COMPENSATION_FACTOR":
                        fldF110_COMPENSATION_FACTOR = (TextBox)DataListField;
                        CoreField = fldF110_COMPENSATION_FACTOR;
                        fldF110_COMPENSATION_FACTOR.Bind(fleF110_COMPENSATION);
                        break;
                    case "FLDGRDF110_COMPENSATION_FACTOR_OVERRIDE":
                        fldF110_COMPENSATION_FACTOR_OVERRIDE = (TextBox)DataListField;
                        CoreField = fldF110_COMPENSATION_FACTOR_OVERRIDE;
                        fldF110_COMPENSATION_FACTOR_OVERRIDE.Bind(fleF110_COMPENSATION);
                        break;
                    case "FLDGRDF110_COMPENSATION_COMP_UNITS":
                        fldF110_COMPENSATION_COMP_UNITS = (TextBox)DataListField;
                        CoreField = fldF110_COMPENSATION_COMP_UNITS;
                        fldF110_COMPENSATION_COMP_UNITS.Bind(fleF110_COMPENSATION);
                        break;
                    case "FLDGRDF110_COMPENSATION_AMT_GROSS":
                        fldF110_COMPENSATION_AMT_GROSS = (TextBox)DataListField;
                        CoreField = fldF110_COMPENSATION_AMT_GROSS;
                        fldF110_COMPENSATION_AMT_GROSS.Bind(fleF110_COMPENSATION);
                        break;
                    case "FLDGRDF110_COMPENSATION_AMT_NET":
                        fldF110_COMPENSATION_AMT_NET = (TextBox)DataListField;
                        CoreField = fldF110_COMPENSATION_AMT_NET;
                        fldF110_COMPENSATION_AMT_NET.Bind(fleF110_COMPENSATION);
                        break;
                    case "FLDGRDF110_COMPENSATION_COMPENSATION_STATUS":
                        fldF110_COMPENSATION_COMPENSATION_STATUS = (TextBox)DataListField;
                        CoreField = fldF110_COMPENSATION_COMPENSATION_STATUS;
                        fldF110_COMPENSATION_COMPENSATION_STATUS.Bind(fleF110_COMPENSATION);
                        break;
                    case "FLDGRDF110_COMPENSATION_EP_NBR_ENTRY":
                        fldF110_COMPENSATION_EP_NBR_ENTRY = (TextBox)DataListField;
                        CoreField = fldF110_COMPENSATION_EP_NBR_ENTRY;
                        fldF110_COMPENSATION_EP_NBR_ENTRY.Bind(fleF110_COMPENSATION);
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
                dtlF110_COMPENSATION.OccursWithFile = fleF110_COMPENSATION;

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
        //# Do not delete, modify or move it.  Updated: 5/24/2017 11:14:22 AM

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
            fleCONSTANTS_MSTR_REC_6.Transaction = m_trnTRANS_UPDATE;
            fleF110_COMPENSATION.Transaction = m_trnTRANS_UPDATE;
            fleF110_COMPENSATION_AUDIT.Transaction = m_trnTRANS_UPDATE;


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/24/2017 11:14:22 AM

        //#-----------------------------------------
        //# InitializeFiles Procedure.
        //#-----------------------------------------

        protected override void InitializeFiles()
        {

            try
            {
                Initialize_TRANS_UPDATE();
                fleF190_COMP_CODES.Connection = m_cnnQUERY;
                fleF191_EARNINGS_PERIOD.Connection = m_cnnQUERY;


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
                fleCONSTANTS_MSTR_REC_6.Dispose();
                fleF110_COMPENSATION.Dispose();
                fleF110_COMPENSATION_AUDIT.Dispose();
                fleF190_COMP_CODES.Dispose();
                fleF191_EARNINGS_PERIOD.Dispose();


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

        protected override void DisplayFormatting()
        {

            //#BEGIN STANDARD PROCEDURE CONTENT
            //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/24/2017 11:14:12 AM
            Display(ref fldX_SCR_NAME);


        }

        #endregion

        #region "Update Validation"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.

        #endregion


        #region "RecordBuffer Events"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/24/2017 11:14:22 AM



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



        private void fldF110_COMPENSATION_COMP_CODE_LookupOn()
        {

            try
            {
                StringBuilder strSQL = new StringBuilder(" WHERE ");
                strSQL.Append("     ").Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ").Append(Common.StringToField(fleF190_COMP_CODES.GetStringValue("COMP_CODE")));

                fleF190_COMP_CODES.GetData(strSQL.ToString(), GetDataOptions.IsOptional);
                if (!AccessOk)
                {
                    ErrorMessage("0");
                    // "Invalid COMPENSATION Code."
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




        private void fldF110_COMPENSATION_EP_NBR_LookupOn()
        {

            try
            {
                StringBuilder strSQL = new StringBuilder(" WHERE ");
                strSQL.Append("     ").Append(fleF191_EARNINGS_PERIOD.ElementOwner("EP_NBR")).Append(" = ").Append((fleF191_EARNINGS_PERIOD.GetDecimalValue("EP_NBR")));

                fleF191_EARNINGS_PERIOD.GetData(strSQL.ToString(), GetDataOptions.IsOptional);
                if (!AccessOk)
                {
                    ErrorMessage("0");
                    // "Invalid Earnings Period."
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



        protected override string SetFieldDefaults(string Name)
        {


            try
            {
                switch (Name)
                {
                    case "F110_COMPENSATION_EP_NBR":
                        return fleCONSTANTS_MSTR_REC_6.GetStringValue("CURRENT_EP_NBR");
                    default:
                        return "";
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
                SaveReceivingParams(W_DOC_NBR, W_EP_NBR_FROM, W_EP_NBR_TO, fleCONSTANTS_MSTR_REC_6, fleF020_DOCTOR_MSTR);


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
                Receiving(W_DOC_NBR, W_EP_NBR_FROM, W_EP_NBR_TO, fleCONSTANTS_MSTR_REC_6, fleF020_DOCTOR_MSTR);


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


        private bool Internal_CALC_DISPLAY()
        {


            try
            {

                if (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("UNITS_DOLLARS_FLAG")) == QDesign.NULL("D"))
                {
                    fleF110_COMPENSATION.set_SetValue("AMT_NET", QDesign.Round((fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS") * fleF110_COMPENSATION.GetDecimalValue("FACTOR")) / 10000, 0, RoundOptionTypes.Near));
                }
                else
                {
                    fleF110_COMPENSATION.set_SetValue("AMT_GROSS", QDesign.Round((fleF110_COMPENSATION.GetDecimalValue("COMP_UNITS") * fleF190_COMP_CODES.GetDecimalValue("AMT_PER_UNIT")) / 100, 0, RoundOptionTypes.Near));
                    fleF110_COMPENSATION.set_SetValue("AMT_NET", QDesign.Round((fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS") * fleF110_COMPENSATION.GetDecimalValue("FACTOR")) / 10000, 0, RoundOptionTypes.Near));
                }
                Display(ref fldF110_COMPENSATION_AMT_GROSS);
                Display(ref fldF110_COMPENSATION_AMT_NET);
                Display(ref fldF110_COMPENSATION_EP_NBR_ENTRY);

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



        private void fldF110_COMPENSATION_EP_NBR_Edit()
        {

            try
            {

                if (QDesign.NULL(fleF110_COMPENSATION.GetDecimalValue("EP_NBR")) > QDesign.NULL(fleCONSTANTS_MSTR_REC_6.GetDecimalValue("LAST_EP_NBR_OF_FISCAL_YR")))
                {
                    Warning("32100");
                }
                if (QDesign.NULL(fleF110_COMPENSATION.GetDecimalValue("EP_NBR")) < QDesign.NULL(fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR")))
                {
                    ErrorMessage("52453");
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



        private void fldF110_COMPENSATION_COMP_CODE_Input()
        {

            try
            {

                if (QDesign.NULL(FieldText) == QDesign.NULL("."))
                {
                    X_SRCH_CODE.Value = " ";
                    //object[] arrRunscreen = { X_SRCH_CODE };
                    //RunScreen(newSY033(),  RunScreenModes.Find, ref arrRunscreen);
                    if (QDesign.NULL(X_SRCH_CODE.Value) != QDesign.NULL(" "))
                    {
                        FieldText = X_SRCH_CODE.Value;
                    }
                    else
                    {
                        ErrorMessage("52454");
                    }
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



        private void fldF110_COMPENSATION_COMP_CODE_Edit()
        {

            try
            {

                if (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("COMP_OWNER")) != QDesign.NULL("U"))
                {
                    ErrorMessage("52455");
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



        private void fldF110_COMPENSATION_COMP_CODE_Process()
        {

            try
            {

                fleF110_COMPENSATION.set_SetValue("DOC_NBR", W_DOC_NBR.Value);
                fleF110_COMPENSATION.set_SetValue("PROCESS_SEQ", fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ"));
                fleF110_COMPENSATION.set_SetValue("COMP_TYPE", fleF190_COMP_CODES.GetStringValue("COMP_TYPE"));
                Display(ref fldF110_COMPENSATION_COMP_TYPE);
                Display(ref fldF190_COMP_CODES_DESC_SHORT);
                fleF110_COMPENSATION.set_SetValue("FACTOR", fleF190_COMP_CODES.GetDecimalValue("FACTOR"));
                Display(ref fldF110_COMPENSATION_FACTOR);
                fleF110_COMPENSATION.set_SetValue("EP_NBR_ENTRY", fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR"));
                Display(ref fldF110_COMPENSATION_EP_NBR_ENTRY);


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



        private void fldF110_COMPENSATION_FACTOR_Process()
        {

            try
            {

                Internal_CALC_DISPLAY();


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



        private void fldF110_COMPENSATION_AMT_GROSS_Process()
        {

            try
            {

                Internal_CALC_DISPLAY();


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


        private bool Internal_ACCEPT_VALUES()
        {


            try
            {

                Accept(ref fldF110_COMPENSATION_EP_NBR);
                Accept(ref fldF110_COMPENSATION_COMP_CODE);
                Accept(ref fldF110_COMPENSATION_FACTOR);
                if (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("UNITS_DOLLARS_FLAG")) == QDesign.NULL("U"))
                {
                    Accept(ref fldF110_COMPENSATION_COMP_UNITS);
                }
                else
                {
                    fleF110_COMPENSATION.set_SetValue("COMP_UNITS", 0);
                    Display(ref fldF110_COMPENSATION_COMP_UNITS);
                }
                if (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("UNITS_DOLLARS_FLAG")) == QDesign.NULL("D"))
                {
                    Accept(ref fldF110_COMPENSATION_AMT_GROSS);
                }
                Internal_CALC_DISPLAY();

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

        //#CORE_BEGIN_INCLUDE: SAVEF110AUDIT"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/24/2017 11:14:22 AM


        private bool Internal_SAVEF110AUDIT()
        {


            try
            {

                A_DOC_NBR.Value = fleF110_COMPENSATION.GetStringValue("DOC_NBR");
                A_EP_NBR.Value = fleF110_COMPENSATION.GetDecimalValue("EP_NBR");
                A_PROCESS_SEQ.Value = fleF110_COMPENSATION.GetDecimalValue("PROCESS_SEQ");
                A_COMP_CODE.Value = fleF110_COMPENSATION.GetStringValue("COMP_CODE");
                A_COMP_TYPE.Value = fleF110_COMPENSATION.GetStringValue("COMP_TYPE");
                A_FACTOR.Value = fleF110_COMPENSATION.GetDecimalValue("FACTOR");
                A_FACTOR_OVERRIDE.Value = fleF110_COMPENSATION.GetStringValue("FACTOR_OVERRIDE");
                A_COMP_UNITS.Value = fleF110_COMPENSATION.GetDecimalValue("COMP_UNITS");
                A_AMT_GROSS.Value = fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS");
                A_AMT_NET.Value = fleF110_COMPENSATION.GetDecimalValue("AMT_NET");
                A_EP_NBR_ENTRY.Value = fleF110_COMPENSATION.GetDecimalValue("EP_NBR_ENTRY");
                A_COMPENSATION_STATUS.Value = fleF110_COMPENSATION.GetStringValue("COMPENSATION_STATUS");

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

        //#CORE_END_INCLUDE: SAVEF110AUDIT"


        //#CORE_BEGIN_INCLUDE: CREATEF110AUDIT"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/24/2017 11:14:22 AM


        private bool Internal_CREATEF110AUDIT()
        {


            try
            {

                fleF110_COMPENSATION_AUDIT.set_SetValue("DOC_NBR", A_DOC_NBR.Value);
                fleF110_COMPENSATION_AUDIT.set_SetValue("EP_NBR", A_EP_NBR.Value);
                fleF110_COMPENSATION_AUDIT.set_SetValue("PROCESS_SEQ", A_PROCESS_SEQ.Value);
                fleF110_COMPENSATION_AUDIT.set_SetValue("COMP_CODE", A_COMP_CODE.Value);
                fleF110_COMPENSATION_AUDIT.set_SetValue("COMP_TYPE", A_COMP_TYPE.Value);
                fleF110_COMPENSATION_AUDIT.set_SetValue("FACTOR", A_FACTOR.Value);
                fleF110_COMPENSATION_AUDIT.set_SetValue("FACTOR_OVERRIDE", A_FACTOR_OVERRIDE.Value);
                fleF110_COMPENSATION_AUDIT.set_SetValue("COMP_UNITS", A_COMP_UNITS.Value);
                fleF110_COMPENSATION_AUDIT.set_SetValue("AMT_GROSS", A_AMT_GROSS.Value);
                fleF110_COMPENSATION_AUDIT.set_SetValue("AMT_NET", A_AMT_NET.Value);
                fleF110_COMPENSATION_AUDIT.set_SetValue("EP_NBR_ENTRY", A_EP_NBR_ENTRY.Value);
                fleF110_COMPENSATION_AUDIT.set_SetValue("COMPENSATION_STATUS", A_COMPENSATION_STATUS.Value);

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


        private bool Internal_CREATEF110AUDIT_ADD()
        {


            try
            {

                fleF110_COMPENSATION_AUDIT.set_SetValue("DOC_NBR", fleF110_COMPENSATION.GetStringValue("DOC_NBR"));
                fleF110_COMPENSATION_AUDIT.set_SetValue("EP_NBR", fleF110_COMPENSATION.GetDecimalValue("EP_NBR"));
                fleF110_COMPENSATION_AUDIT.set_SetValue("PROCESS_SEQ", fleF110_COMPENSATION.GetDecimalValue("PROCESS_SEQ"));
                fleF110_COMPENSATION_AUDIT.set_SetValue("COMP_CODE", fleF110_COMPENSATION.GetStringValue("COMP_CODE"));
                fleF110_COMPENSATION_AUDIT.set_SetValue("COMP_TYPE", fleF110_COMPENSATION.GetStringValue("COMP_TYPE"));
                fleF110_COMPENSATION_AUDIT.set_SetValue("FACTOR", fleF110_COMPENSATION.GetDecimalValue("FACTOR"));
                fleF110_COMPENSATION_AUDIT.set_SetValue("FACTOR_OVERRIDE", fleF110_COMPENSATION.GetStringValue("FACTOR_OVERRIDE"));
                fleF110_COMPENSATION_AUDIT.set_SetValue("COMP_UNITS", fleF110_COMPENSATION.GetDecimalValue("COMP_UNITS"));
                fleF110_COMPENSATION_AUDIT.set_SetValue("AMT_GROSS", fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS"));
                fleF110_COMPENSATION_AUDIT.set_SetValue("AMT_NET", fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                fleF110_COMPENSATION_AUDIT.set_SetValue("EP_NBR_ENTRY", fleF110_COMPENSATION.GetDecimalValue("EP_NBR_ENTRY"));
                fleF110_COMPENSATION_AUDIT.set_SetValue("COMPENSATION_STATUS", fleF110_COMPENSATION.GetStringValue("COMPENSATION_STATUS"));

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

        //#CORE_END_INCLUDE: CREATEF110AUDIT"



        protected override bool PostFind()
        {


            try
            {

                while (fleF110_COMPENSATION.For())
                {
                    Internal_SAVEF110AUDIT();
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


        protected override bool Append()
        {


            try
            {

                Internal_ACCEPT_VALUES();

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



        private void dsrDesigner_01_Click(object sender, System.EventArgs e)
        {

            try
            {

                Internal_ACCEPT_VALUES();


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



        private void dsrDesigner_FIX_Click(object sender, System.EventArgs e)
        {

            try
            {

                Internal_ACCEPT_VALUES();
                Accept(ref fldF110_COMPENSATION_AMT_NET);


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

                while (fleF110_COMPENSATION.For())
                {
                    Append();
                    // TODO: May need to remove code.  APPEND is handled by the framework.
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


        protected override bool PreUpdate()
        {


            try
            {

                while (fleF110_COMPENSATION.For())
                {
                    if (fleF110_COMPENSATION.NewRecord)
                    {
                        Internal_CREATEF110AUDIT_ADD();
                        fleF110_COMPENSATION_AUDIT.set_SetValue("LAST_MOD_FLAG", "A");
                        fleF110_COMPENSATION_AUDIT.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));
                        fleF110_COMPENSATION_AUDIT.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);
                        fleF110_COMPENSATION_AUDIT.set_SetValue("LAST_MOD_USER_ID", QDesign.RTrim(UserID) + "-d110-A");
                        fleF110_COMPENSATION_AUDIT.PutData();
                    }
                    else
                    {
                        if (ChangeMode & fleF110_COMPENSATION.DeletedRecord)
                        {
                            Internal_CREATEF110AUDIT();
                            fleF110_COMPENSATION_AUDIT.set_SetValue("LAST_MOD_FLAG", "D");
                            fleF110_COMPENSATION_AUDIT.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));
                            fleF110_COMPENSATION_AUDIT.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);
                            fleF110_COMPENSATION_AUDIT.set_SetValue("LAST_MOD_USER_ID", QDesign.RTrim(UserID) + "-d110-D");
                            fleF110_COMPENSATION_AUDIT.PutData();
                        }
                        else
                        {
                            if (ChangeMode & fleF110_COMPENSATION.AlteredRecord)
                            {
                                Internal_CREATEF110AUDIT();
                                fleF110_COMPENSATION_AUDIT.set_SetValue("LAST_MOD_FLAG", "C");
                                fleF110_COMPENSATION_AUDIT.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));
                                fleF110_COMPENSATION_AUDIT.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);
                                fleF110_COMPENSATION_AUDIT.set_SetValue("LAST_MOD_USER_ID", QDesign.RTrim(UserID) + "-d110-1");
                                fleF110_COMPENSATION_AUDIT.PutData(true);
                                Internal_CREATEF110AUDIT_ADD();
                                fleF110_COMPENSATION_AUDIT.set_SetValue("LAST_MOD_FLAG", "C");
                                fleF110_COMPENSATION_AUDIT.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));
                                fleF110_COMPENSATION_AUDIT.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);
                                fleF110_COMPENSATION_AUDIT.set_SetValue("LAST_MOD_USER_ID", QDesign.RTrim(UserID) + "-d110-2");
                                fleF110_COMPENSATION_AUDIT.PutData();
                            }
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


        protected override bool Update()
        {


            try
            {

                while (fleF110_COMPENSATION.For())
                {
                    fleF110_COMPENSATION.PutData();
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


        protected override bool Find()
        {
            W_EP_NBR_FROM.Value = 201601;
            W_DOC_NBR.Value = "004";

            try
            {

                while (fleF110_COMPENSATION.For())
                {
                    bool blnAddWhere = true;
                    m_strWhere = new StringBuilder(GetWhereCondition(fleF110_COMPENSATION.ElementOwner("EP_NBR"), W_EP_NBR_FROM.Value, ref blnAddWhere));
                    m_strWhere.Append(GetWhereCondition(fleF110_COMPENSATION.ElementOwner("DOC_NBR"), W_DOC_NBR.Value, ref blnAddWhere));
                    fleF110_COMPENSATION.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);

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


        protected override bool Delete()
        {


            try
            {
                //TODO: May need to remove loop construct that sets "DeletedRecord" for occuring files

                fleF110_COMPENSATION.DeletedRecord = true;

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
        //# dtlF110_COMPENSATION_EditClick Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/24/2017 11:14:22 AM
        //#-----------------------------------------
        private void dtlF110_COMPENSATION_EditClick(DataList source, GridButtonEventArgs GridButtonEventArgs)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/24/2017 11:14:22 AM
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

