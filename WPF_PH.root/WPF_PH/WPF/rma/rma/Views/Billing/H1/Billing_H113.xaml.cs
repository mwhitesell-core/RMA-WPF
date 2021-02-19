
#region "Screen Comments"

// #> PROGRAM-ID.     H113.QKS
// ((C)) Dyad Technologies
// PURPOSE: Query DEFAULT Physician Earning Compensation
// transcations
// MODIFICATION HISTORY
// DATE    SAF #  WHO      DESCRIPTION
// 95/JUN/29  ____   B.M.L    - original COPIED FROM D113.QKS
// 1999/Apr/21  S.B.   - Fixed sizes of dates and alignment of
// fields for Y2K.  Shortened the description
// field to make space.
// 1999/Jun/07         S.B.     - Altered the call to scrtitle.use and
// stdhilite.use to be called from $use
// instead of src.
// - Removed the call to secfile.use because
// it was not doing anything.
// 2004/sep/02 b.e.      - made all fields display so that data can`t be
// accidently changed
// - added new designer procedcure FIX to allow change
// of each field only after a `secret` password has
// been entered

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

    partial class Billing_H113 : BasePage
    {

        #region " Form Designer Generated Code "





        public Billing_H113()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "H113";

            //# Set the ACTIVITIES for the screen.
            this.ChangeActivity = false;
            this.FindActivity = true;
            this.DeleteActivity = false;
            this.EntryActivity = false;
            this.DisableAppend = true;
            this.GridDesigner = "dsrDesigner_01";
            dsrDesigner_01.DefaultFirstRowInGrid = true;
        }

        #endregion

        private void Page_Load(object sender, RoutedEventArgs e)
        {
            SetVariables();
            dsrDesigner_FIX.Click += dsrDesigner_FIX_Click;
            dsrDesigner_01.Click += dsrDesigner_01_Click;
            dtlF113_DEFAULT_COMP_HISTORY.EditClick += dtlF113_DEFAULT_COMP_HISTORY_EditClick;
            base.Page_Load();

            // TODO: If any DESIGNER procedures function on occurring FILES or TEMPORARIES, set the grid's AllowSelectRowButton property to TRUE.



            // TODO: The following elements have Input/Output Scaling defined in the Dictionary or Screen.  Manual steps may be required:
            //       F113_DEFAULT_COMP_HISTORY.AMT_GROSS InputScale: 2 OutputScale: 0
            //       F113_DEFAULT_COMP_HISTORY.AMT_NET InputScale: 2 OutputScale: 0
            //       F113_DEFAULT_COMP_HISTORY.FACTOR InputScale: 4 OutputScale: 0
            // TODO: The following FIELD(S) on the form are redefine elements.  Manual steps may be required:
            //       F113_DEFAULT_COMP_HISTORY.EP_NBR_FROM


        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            W_DOC_NBR = new CoreCharacter("W_DOC_NBR", 3, this, Common.cEmptyString);           
            W_EP_YR = new CoreDecimal("W_EP_YR", 6, this);
            X_SRCH_CODE = new CoreCharacter("X_SRCH_CODE", 6, this, Common.cEmptyString);
            W_PASSWORD = new CoreDate("W_PASSWORD", this);
            W_SYSDATE = new CoreDate("W_SYSDATE", this);
            fleF113_DEFAULT_COMP_HISTORY = new SqlFileObject(this, FileTypes.Primary, 12, "INDEXED", "F113_DEFAULT_COMP_HISTORY", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Master, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Reference, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_cnnQUERY");
            fleCONSTANTS_MSTR_REC_6 = new SqlFileObject(this, FileTypes.Designer, 0, "INDEXED", "CONSTANTS_MSTR_REC_6", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            T_EP_NBR_FROM = new CoreCharacter("T_EP_NBR_FROM", 6, this, fleF113_DEFAULT_COMP_HISTORY, ResetTypes.ResetAtStartup);
           
            fleF190_COMP_CODES.Access += fleF190_COMP_CODES_Access;
            X_SCREEN_NAME.GetValue += X_SCREEN_NAME_GetValue;
            X_SCR_NAME.GetValue += X_SCR_NAME_GetValue;
            fleF190_COMP_CODES.SetItemFinals += FleF190_COMP_CODES_SetItemFinals;
        }



        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;
            fleF190_COMP_CODES.Access -= fleF190_COMP_CODES_Access;
            X_SCREEN_NAME.GetValue -= X_SCREEN_NAME_GetValue;
            X_SCR_NAME.GetValue -= X_SCR_NAME_GetValue;

            dsrDesigner_FIX.Click -= dsrDesigner_FIX_Click;
            dsrDesigner_01.Click -= dsrDesigner_01_Click;
            dtlF113_DEFAULT_COMP_HISTORY.EditClick -= dtlF113_DEFAULT_COMP_HISTORY_EditClick;
            fleF190_COMP_CODES.SetItemFinals -= FleF190_COMP_CODES_SetItemFinals;
        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private SqlConnection m_cnnQUERY = new SqlConnection();
        private SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
        private SqlTransaction m_trnTRANS_UPDATE;
        private CoreCharacter W_DOC_NBR;
        private CoreCharacter T_EP_NBR_FROM;
        private CoreDecimal W_EP_YR;
        private CoreCharacter X_SRCH_CODE;
        private CoreDate W_PASSWORD;
        private CoreDate W_SYSDATE;
        private SqlFileObject fleF113_DEFAULT_COMP_HISTORY;
        private SqlFileObject fleF020_DOCTOR_MSTR;
        private SqlFileObject fleF190_COMP_CODES;


        private void FleF190_COMP_CODES_SetItemFinals()
        {
            try
            {
                if (T_EP_NBR_FROM.Value != "0")
                {
                    fleF113_DEFAULT_COMP_HISTORY.set_SetValue("EP_YR", T_EP_NBR_FROM.Value.Substring(0, 4));
                    fleF113_DEFAULT_COMP_HISTORY.set_SetValue("EP_YR", T_EP_NBR_FROM.Value.Substring(4, 2));
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
        private void fleF190_COMP_CODES_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ").Append(Common.StringToField(fleF113_DEFAULT_COMP_HISTORY.GetStringValue("COMP_CODE")));

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

        private SqlFileObject fleCONSTANTS_MSTR_REC_6;
        private DCharacter X_SCREEN_NAME = new DCharacter(55);
        private void X_SCREEN_NAME_GetValue(ref string Value)
        {

            try
            {
                Value = "DEFAULT COMPENSATION HISTORY";


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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:09:41 AM

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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:09:41 AM

        protected TextBox fldF113_DEFAULT_COMP_HISTORY_EP_NBR_FROM;
        protected TextBox fldF113_DEFAULT_COMP_HISTORY_EP_NBR_TO;
        protected TextBox fldF113_DEFAULT_COMP_HISTORY_COMP_CODE;
        protected TextBox fldF190_COMP_CODES_DESC_SHORT;
        protected TextBox fldF113_DEFAULT_COMP_HISTORY_FACTOR;
        protected TextBox fldF113_DEFAULT_COMP_HISTORY_COMP_UNITS;
        protected TextBox fldF113_DEFAULT_COMP_HISTORY_AMT_GROSS;
        protected TextBox fldF113_DEFAULT_COMP_HISTORY_AMT_NET;

        protected TextBox fldF113_DEFAULT_COMP_HISTORY_EP_NBR_ENTRY;

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:09:41 AM

        //#-----------------------------------------
        //# GetGridFieldObject Procedure.
        //#-----------------------------------------

        protected override void GetGridFieldObject(object DataListField, ref object CoreField, string Name)
        {

            try
            {
                switch (Name.ToUpper())
                {
                    case "FLDGRDF113_DEFAULT_COMP_HISTORY_EP_NBR_FROM":
                        fldF113_DEFAULT_COMP_HISTORY_EP_NBR_FROM = (TextBox)DataListField;
                        CoreField = fldF113_DEFAULT_COMP_HISTORY_EP_NBR_FROM;
                        fldF113_DEFAULT_COMP_HISTORY_EP_NBR_FROM.Bind(T_EP_NBR_FROM);
                        break;
                    case "FLDGRDF113_DEFAULT_COMP_HISTORY_EP_NBR_TO":
                        fldF113_DEFAULT_COMP_HISTORY_EP_NBR_TO = (TextBox)DataListField;
                        CoreField = fldF113_DEFAULT_COMP_HISTORY_EP_NBR_TO;
                        fldF113_DEFAULT_COMP_HISTORY_EP_NBR_TO.Bind(fleF113_DEFAULT_COMP_HISTORY);
                        break;
                    case "FLDGRDF113_DEFAULT_COMP_HISTORY_COMP_CODE":
                        fldF113_DEFAULT_COMP_HISTORY_COMP_CODE = (TextBox)DataListField;
                        CoreField = fldF113_DEFAULT_COMP_HISTORY_COMP_CODE;
                        fldF113_DEFAULT_COMP_HISTORY_COMP_CODE.Bind(fleF113_DEFAULT_COMP_HISTORY);
                        break;
                    case "FLDGRDF190_COMP_CODES_DESC_SHORT":
                        fldF190_COMP_CODES_DESC_SHORT = (TextBox)DataListField;
                        CoreField = fldF190_COMP_CODES_DESC_SHORT;
                        fldF190_COMP_CODES_DESC_SHORT.Bind(fleF190_COMP_CODES);
                        break;
                    case "FLDGRDF113_DEFAULT_COMP_HISTORY_FACTOR":
                        fldF113_DEFAULT_COMP_HISTORY_FACTOR = (TextBox)DataListField;
                        CoreField = fldF113_DEFAULT_COMP_HISTORY_FACTOR;
                        fldF113_DEFAULT_COMP_HISTORY_FACTOR.Bind(fleF113_DEFAULT_COMP_HISTORY);
                        break;
                    case "FLDGRDF113_DEFAULT_COMP_HISTORY_COMP_UNITS":
                        fldF113_DEFAULT_COMP_HISTORY_COMP_UNITS = (TextBox)DataListField;
                        CoreField = fldF113_DEFAULT_COMP_HISTORY_COMP_UNITS;
                        fldF113_DEFAULT_COMP_HISTORY_COMP_UNITS.Bind(fleF113_DEFAULT_COMP_HISTORY);
                        break;
                    case "FLDGRDF113_DEFAULT_COMP_HISTORY_AMT_GROSS":
                        fldF113_DEFAULT_COMP_HISTORY_AMT_GROSS = (TextBox)DataListField;
                        CoreField = fldF113_DEFAULT_COMP_HISTORY_AMT_GROSS;
                        fldF113_DEFAULT_COMP_HISTORY_AMT_GROSS.Bind(fleF113_DEFAULT_COMP_HISTORY);
                        break;
                    case "FLDGRDF113_DEFAULT_COMP_HISTORY_AMT_NET":
                        fldF113_DEFAULT_COMP_HISTORY_AMT_NET = (TextBox)DataListField;
                        CoreField = fldF113_DEFAULT_COMP_HISTORY_AMT_NET;
                        fldF113_DEFAULT_COMP_HISTORY_AMT_NET.Bind(fleF113_DEFAULT_COMP_HISTORY);
                        break;
                    case "FLDGRDF113_DEFAULT_COMP_HISTORY_EP_NBR_ENTRY":
                        fldF113_DEFAULT_COMP_HISTORY_EP_NBR_ENTRY = (TextBox)DataListField;
                        CoreField = fldF113_DEFAULT_COMP_HISTORY_EP_NBR_ENTRY;
                        fldF113_DEFAULT_COMP_HISTORY_EP_NBR_ENTRY.Bind(fleF113_DEFAULT_COMP_HISTORY);
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
                dtlF113_DEFAULT_COMP_HISTORY.OccursWithFile = fleF113_DEFAULT_COMP_HISTORY;

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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:09:41 AM

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
            fleF113_DEFAULT_COMP_HISTORY.Transaction = m_trnTRANS_UPDATE;
            fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
            fleCONSTANTS_MSTR_REC_6.Transaction = m_trnTRANS_UPDATE;


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:09:41 AM

        //#-----------------------------------------
        //# InitializeFiles Procedure.
        //#-----------------------------------------

        protected override void InitializeFiles()
        {

            try
            {
                Initialize_TRANS_UPDATE();
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
                fleF113_DEFAULT_COMP_HISTORY.Dispose();
                fleF020_DOCTOR_MSTR.Dispose();
                fleF190_COMP_CODES.Dispose();
                fleCONSTANTS_MSTR_REC_6.Dispose();


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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:09:41 AM
        //#-----------------------------------------
        protected override void DisplayFormatting()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:09:41 AM
                Display(ref fldW_PASSWORD);
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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:09:41 AM

        //#-----------------------------------------
        //# BindFields Procedure.
        //#-----------------------------------------

        public override void BindFields()
        {
            try
            {
                fldW_PASSWORD.Bind(W_PASSWORD);

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
                SaveReceivingParams(W_DOC_NBR, W_EP_YR, fleCONSTANTS_MSTR_REC_6, fleF020_DOCTOR_MSTR);


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
                Receiving(W_DOC_NBR, W_EP_YR, fleCONSTANTS_MSTR_REC_6, fleF020_DOCTOR_MSTR);


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



        private void dsrDesigner_FIX_Click(object sender, System.EventArgs e)
        {

            try
            {

                W_SYSDATE.Value = QDesign.SysDate(ref m_cnnQUERY);
                Accept(ref fldW_PASSWORD);
                if (QDesign.NULL(W_PASSWORD.Value) == QDesign.NULL(W_SYSDATE.Value))
                {
                    Accept(ref fldF113_DEFAULT_COMP_HISTORY_EP_NBR_FROM);
                    Accept(ref fldF113_DEFAULT_COMP_HISTORY_EP_NBR_TO);
                    Accept(ref fldF113_DEFAULT_COMP_HISTORY_COMP_CODE);
                    Accept(ref fldF190_COMP_CODES_DESC_SHORT);
                    Accept(ref fldF113_DEFAULT_COMP_HISTORY_FACTOR);
                    Accept(ref fldF113_DEFAULT_COMP_HISTORY_COMP_UNITS);
                    Accept(ref fldF113_DEFAULT_COMP_HISTORY_AMT_GROSS);
                    Accept(ref fldF113_DEFAULT_COMP_HISTORY_AMT_NET);
                    Accept(ref fldF113_DEFAULT_COMP_HISTORY_EP_NBR_ENTRY);
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




        protected override bool Find()
        {


            try
            {
                bool blnAddWhere = true;
                while (fleF113_DEFAULT_COMP_HISTORY.ForMissing())
                {
                    m_strWhere = new StringBuilder(GetWhereCondition(fleF113_DEFAULT_COMP_HISTORY.ElementOwner("DOC_NBR"), W_DOC_NBR.Value, ref blnAddWhere));
                    m_strWhere.Append(GetWhereCondition(fleF113_DEFAULT_COMP_HISTORY.ElementOwner("EP_YR"), W_EP_YR.Value, ref blnAddWhere));
                    fleF113_DEFAULT_COMP_HISTORY.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);

                    T_EP_NBR_FROM.Value = fleF113_DEFAULT_COMP_HISTORY.GetStringValue("EP_YR").Trim() + fleF113_DEFAULT_COMP_HISTORY.GetStringValue("EP_MM").Trim().PadLeft(2,'0');
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
        //# dtlF113_DEFAULT_COMP_HISTORY_EditClick Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:09:41 AM
        //#-----------------------------------------
        private void dtlF113_DEFAULT_COMP_HISTORY_EditClick(DataList source, GridButtonEventArgs GridButtonEventArgs)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:09:41 AM
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:09:41 AM
        //#-----------------------------------------
        private void dsrDesigner_01_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:09:41 AM
                Display(ref fldF113_DEFAULT_COMP_HISTORY_EP_NBR_FROM);
                Display(ref fldF113_DEFAULT_COMP_HISTORY_EP_NBR_TO);
                Display(ref fldF113_DEFAULT_COMP_HISTORY_COMP_CODE);
                Display(ref fldF190_COMP_CODES_DESC_SHORT);
                Display(ref fldF113_DEFAULT_COMP_HISTORY_FACTOR);
                Display(ref fldF113_DEFAULT_COMP_HISTORY_COMP_UNITS);
                Display(ref fldF113_DEFAULT_COMP_HISTORY_AMT_GROSS);
                Display(ref fldF113_DEFAULT_COMP_HISTORY_AMT_NET);
                Display(ref fldF113_DEFAULT_COMP_HISTORY_EP_NBR_ENTRY);
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
