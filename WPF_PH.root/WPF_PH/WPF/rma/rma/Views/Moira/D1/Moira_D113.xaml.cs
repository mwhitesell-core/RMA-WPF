
#region "Screen Comments"

// #> PROGRAM-ID.     D113.QKS
// ((C)) Dyad Technologies
// PURPOSE: Query/modifications to DEFAULT Physician Earning Compensation
// transcations
// MODIFICATION HISTORY
// DATE    SAF #  WHO      DESCRIPTION
// 92/JAN/01  ____   B.E.     - original
// 92/JAN/01  ____   B.E.     - added routine ACCEPT-VALUES
// 95/NOV/07  ____   M.C.     - DO NOT REQUIRE TO RECEIVE EP NBR
// - NO SELECTION IS REQUIRED TO F113 FILE
// 1999/Jan/21  S.B.  - Fixed sizes of dates and alignment of 
// fields for Y2K.  Shortened the description 
// field to make space.
// 1999/Jun/07 S.B.        - Altered the call to scrtitle.use and
// stdhilite.use to be called from $use
// instead of src.
// - Removed the call to secfile.use because
// it was not doing anything.
// 2002/Jul/25  M.C.  - define the index to be read when lookup
// on f191-earnings-period
// 2003/nov/10 b.e.      - alpha doctor nbr
// 2006/apr/10 b.e.      - allow for 9 digit amt-gross and amt-net
// 2013/Jan/09 MC1       - set date/time/userid when creating the new records
// 2016/Apr/26 MC2  - do not allow user to enter comp code payeft with non-zero amount
// - do not allow enter from ep nbr which was already exist with the comp code

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

    partial class Moira_D113 : BasePage
    {

        #region " Form Designer Generated Code "





        public Moira_D113()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "D113";

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
            dtlF113_DEFAULT_COMP.EditClick += dtlF113_DEFAULT_COMP_EditClick;
            base.Page_Load();

            // TODO: If any DESIGNER procedures function on occurring FILES or TEMPORARIES, set the grid's AllowSelectRowButton property to TRUE.



            // TODO: The following elements have Input/Output Scaling defined in the Dictionary or Screen.  Manual steps may be required:
            //       F113_DEFAULT_COMP.AMT_GROSS InputScale: 2 OutputScale: 0
            //       F113_DEFAULT_COMP.AMT_NET InputScale: 2 OutputScale: 0
            //       F113_DEFAULT_COMP.FACTOR InputScale: 4 OutputScale: 0


        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            W_DOC_NBR = new CoreCharacter("W_DOC_NBR", 3, this, Common.cEmptyString);
            X_SRCH_CODE = new CoreCharacter("X_SRCH_CODE", 6, this, Common.cEmptyString);
            fleF113_DEFAULT_COMP = new SqlFileObject(this, FileTypes.Primary, 12, "INDEXED", "F113_DEFAULT_COMP", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF113_CHECK = new SqlFileObject(this, FileTypes.Designer, 0, "INDEXED", "F113_DEFAULT_COMP", "F113_CHECK", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Master, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Reference, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_cnnQUERY");
            fleF191_EARNINGS_PERIOD = new SqlFileObject(this, FileTypes.Reference, 0, "INDEXED", "F191_EARNINGS_PERIOD", "", false, false, false, 0, "m_cnnQUERY");
            fleCONSTANTS_MSTR_REC_6 = new SqlFileObject(this, FileTypes.Designer, 0, "INDEXED", "CONSTANTS_MSTR_REC_6", "", false, false, false, 0, "m_trnTRANS_UPDATE");

          
          
            fleF190_COMP_CODES.Access += fleF190_COMP_CODES_Access;
            fleF191_EARNINGS_PERIOD.Access += fleF191_EARNINGS_PERIOD_Access;
            X_SCREEN_NAME.GetValue += X_SCREEN_NAME_GetValue;
            X_SCR_NAME.GetValue += X_SCR_NAME_GetValue;
            fleF113_DEFAULT_COMP.InitializeItems += fleF113_DEFAULT_COMP_InitializeItems;
        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;
            fleF190_COMP_CODES.Access -= fleF190_COMP_CODES_Access;
            fleF191_EARNINGS_PERIOD.Access -= fleF191_EARNINGS_PERIOD_Access;
            X_SCREEN_NAME.GetValue -= X_SCREEN_NAME_GetValue;
            X_SCR_NAME.GetValue -= X_SCR_NAME_GetValue;
            fldF113_DEFAULT_COMP_EP_NBR_TO.LookupOn -= fldF113_DEFAULT_COMP_EP_NBR_TO_LookupOn;
           fldF113_DEFAULT_COMP_EP_NBR_TO.Input -= fldF113_DEFAULT_COMP_EP_NBR_TO_Input;
            fldF113_DEFAULT_COMP_EP_NBR_TO.Edit -= fldF113_DEFAULT_COMP_EP_NBR_TO_Edit;
             fldF113_DEFAULT_COMP_AMT_GROSS.Edit -= fldF113_DEFAULT_COMP_AMT_GROSS_Edit;

            dsrDesigner_01.Click -= dsrDesigner_01_Click;
            dtlF113_DEFAULT_COMP.EditClick -= dtlF113_DEFAULT_COMP_EditClick;
            fleF113_DEFAULT_COMP.InitializeItems -= fleF113_DEFAULT_COMP_InitializeItems;
           

           
        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private SqlConnection m_cnnQUERY = new SqlConnection();
        private SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
        private SqlTransaction m_trnTRANS_UPDATE;
        private CoreCharacter W_DOC_NBR;
        private CoreCharacter X_SRCH_CODE;
        private SqlFileObject fleF113_DEFAULT_COMP;

        private void fleF113_DEFAULT_COMP_InitializeItems(bool Fixed)
        {

            try
            {
                if (!Fixed)
                    fleF113_DEFAULT_COMP.set_SetValue("LAST_MOD_DATE", true, QDesign.SysDate(ref m_cnnQUERY));
                if (!Fixed)
                    fleF113_DEFAULT_COMP.set_SetValue("LAST_MOD_TIME", true, QDesign.SysTime(ref m_cnnQUERY) / 10000);
                if (!Fixed)
                    fleF113_DEFAULT_COMP.set_SetValue("LAST_MOD_USER_ID", true, UserID);


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

        private SqlFileObject fleF113_CHECK;
        private SqlFileObject fleF020_DOCTOR_MSTR;
        private SqlFileObject fleF190_COMP_CODES;

        private void fleF190_COMP_CODES_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE  ").Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ").Append(Common.StringToField(fleF113_DEFAULT_COMP.GetStringValue("COMP_CODE")));


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

                strText.Append(" WHERE  ").Append(fleF191_EARNINGS_PERIOD.ElementOwner("")).Append(" = ").Append(Common.StringToField(fleF113_DEFAULT_COMP.GetStringValue("EP_NBR_FROM")));


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
                Value = "DEFAULT COMPENSATION";


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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:39:23 AM

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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:39:24 AM

        protected TextBox fldF113_DEFAULT_COMP_EP_NBR_FROM;
        protected TextBox fldF113_DEFAULT_COMP_EP_NBR_TO;
        protected TextBox fldF113_DEFAULT_COMP_COMP_CODE;
        protected TextBox fldF190_COMP_CODES_DESC_SHORT;
        protected TextBox fldF113_DEFAULT_COMP_FACTOR;
        protected TextBox fldF113_DEFAULT_COMP_COMP_UNITS;
        protected TextBox fldF113_DEFAULT_COMP_AMT_GROSS;
        protected TextBox fldF113_DEFAULT_COMP_AMT_NET;

        protected TextBox fldF113_DEFAULT_COMP_EP_NBR_ENTRY;

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:39:24 AM

        //#-----------------------------------------
        //# GetGridFieldObject Procedure.
        //#-----------------------------------------

        protected override void GetGridFieldObject(object DataListField, ref object CoreField, string Name)
        {

            try
            {
                switch (Name.ToUpper())
                {
                    case "FLDGRDF113_DEFAULT_COMP_EP_NBR_FROM":
                        fldF113_DEFAULT_COMP_EP_NBR_FROM = (TextBox)DataListField;

                        fldF113_DEFAULT_COMP_EP_NBR_FROM.LookupOn -= fldF113_DEFAULT_COMP_EP_NBR_FROM_LookupOn;
                        fldF113_DEFAULT_COMP_EP_NBR_FROM.LookupOn += fldF113_DEFAULT_COMP_EP_NBR_FROM_LookupOn;

                        fldF113_DEFAULT_COMP_EP_NBR_FROM.Input -= fldF113_DEFAULT_COMP_EP_NBR_FROM_Input;
                        fldF113_DEFAULT_COMP_EP_NBR_FROM.Input += fldF113_DEFAULT_COMP_EP_NBR_FROM_Input;

                        fldF113_DEFAULT_COMP_EP_NBR_FROM.Edit -= fldF113_DEFAULT_COMP_EP_NBR_FROM_Edit;
                        fldF113_DEFAULT_COMP_EP_NBR_FROM.Edit += fldF113_DEFAULT_COMP_EP_NBR_FROM_Edit;
                        fldF113_DEFAULT_COMP_EP_NBR_FROM.Process -= fldF113_DEFAULT_COMP_EP_NBR_FROM_Process;
                        fldF113_DEFAULT_COMP_EP_NBR_FROM.Process += fldF113_DEFAULT_COMP_EP_NBR_FROM_Process;
                        CoreField = fldF113_DEFAULT_COMP_EP_NBR_FROM;
                        fldF113_DEFAULT_COMP_EP_NBR_FROM.Bind(fleF113_DEFAULT_COMP);
                        break;
                    case "FLDGRDF113_DEFAULT_COMP_EP_NBR_TO":
                        fldF113_DEFAULT_COMP_EP_NBR_TO = (TextBox)DataListField;

                        fldF113_DEFAULT_COMP_EP_NBR_TO.LookupOn -= fldF113_DEFAULT_COMP_EP_NBR_TO_LookupOn;
                        fldF113_DEFAULT_COMP_EP_NBR_TO.LookupOn += fldF113_DEFAULT_COMP_EP_NBR_TO_LookupOn;

                        fldF113_DEFAULT_COMP_EP_NBR_TO.Input -= fldF113_DEFAULT_COMP_EP_NBR_TO_Input;
                        fldF113_DEFAULT_COMP_EP_NBR_TO.Input += fldF113_DEFAULT_COMP_EP_NBR_TO_Input;

                        fldF113_DEFAULT_COMP_EP_NBR_TO.Edit -= fldF113_DEFAULT_COMP_EP_NBR_TO_Edit;
                        fldF113_DEFAULT_COMP_EP_NBR_TO.Edit += fldF113_DEFAULT_COMP_EP_NBR_TO_Edit;
                        CoreField = fldF113_DEFAULT_COMP_EP_NBR_TO;
                        fldF113_DEFAULT_COMP_EP_NBR_TO.Bind(fleF113_DEFAULT_COMP);
                        break;
                    case "FLDGRDF113_DEFAULT_COMP_COMP_CODE":
                        fldF113_DEFAULT_COMP_COMP_CODE = (TextBox)DataListField;

                        fldF113_DEFAULT_COMP_COMP_CODE.LookupNotOn -= fldF113_DEFAULT_COMP_COMP_CODE_LookupNotOn;
                        fldF113_DEFAULT_COMP_COMP_CODE.LookupNotOn += fldF113_DEFAULT_COMP_COMP_CODE_LookupNotOn;

                        fldF113_DEFAULT_COMP_COMP_CODE.LookupOn -= fldF113_DEFAULT_COMP_COMP_CODE_LookupOn;
                        fldF113_DEFAULT_COMP_COMP_CODE.LookupOn += fldF113_DEFAULT_COMP_COMP_CODE_LookupOn;

                        fldF113_DEFAULT_COMP_COMP_CODE.Input -= fldF113_DEFAULT_COMP_COMP_CODE_Input;
                        fldF113_DEFAULT_COMP_COMP_CODE.Input += fldF113_DEFAULT_COMP_COMP_CODE_Input;

                        fldF113_DEFAULT_COMP_COMP_CODE.Edit -= fldF113_DEFAULT_COMP_COMP_CODE_Edit;
                        fldF113_DEFAULT_COMP_COMP_CODE.Edit += fldF113_DEFAULT_COMP_COMP_CODE_Edit;
                        fldF113_DEFAULT_COMP_COMP_CODE.Process -= fldF113_DEFAULT_COMP_COMP_CODE_Process;
                        fldF113_DEFAULT_COMP_COMP_CODE.Process += fldF113_DEFAULT_COMP_COMP_CODE_Process;
                        CoreField = fldF113_DEFAULT_COMP_COMP_CODE;
                        fldF113_DEFAULT_COMP_COMP_CODE.Bind(fleF113_DEFAULT_COMP);
                        break;
                    case "FLDGRDF190_COMP_CODES_DESC_SHORT":
                        fldF190_COMP_CODES_DESC_SHORT = (TextBox)DataListField;
                        CoreField = fldF190_COMP_CODES_DESC_SHORT;
                        fldF190_COMP_CODES_DESC_SHORT.Bind(fleF190_COMP_CODES);
                        break;
                    case "FLDGRDF113_DEFAULT_COMP_FACTOR":
                        fldF113_DEFAULT_COMP_FACTOR = (TextBox)DataListField;
                        CoreField = fldF113_DEFAULT_COMP_FACTOR;
                        fldF113_DEFAULT_COMP_FACTOR.Bind(fleF113_DEFAULT_COMP);
                        break;
                    case "FLDGRDF113_DEFAULT_COMP_COMP_UNITS":
                        fldF113_DEFAULT_COMP_COMP_UNITS = (TextBox)DataListField;
                        CoreField = fldF113_DEFAULT_COMP_COMP_UNITS;
                        fldF113_DEFAULT_COMP_COMP_UNITS.Bind(fleF113_DEFAULT_COMP);
                        break;
                    case "FLDGRDF113_DEFAULT_COMP_AMT_GROSS":
                        fldF113_DEFAULT_COMP_AMT_GROSS = (TextBox)DataListField;

                        fldF113_DEFAULT_COMP_AMT_GROSS.Edit -= fldF113_DEFAULT_COMP_AMT_GROSS_Edit;
                        fldF113_DEFAULT_COMP_AMT_GROSS.Edit += fldF113_DEFAULT_COMP_AMT_GROSS_Edit;
                        CoreField = fldF113_DEFAULT_COMP_AMT_GROSS;
                        fldF113_DEFAULT_COMP_AMT_GROSS.Bind(fleF113_DEFAULT_COMP);
                        break;
                    case "FLDGRDF113_DEFAULT_COMP_AMT_NET":
                        fldF113_DEFAULT_COMP_AMT_NET = (TextBox)DataListField;
                        CoreField = fldF113_DEFAULT_COMP_AMT_NET;
                        fldF113_DEFAULT_COMP_AMT_NET.Bind(fleF113_DEFAULT_COMP);
                        break;
                    case "FLDGRDF113_DEFAULT_COMP_EP_NBR_ENTRY":
                        fldF113_DEFAULT_COMP_EP_NBR_ENTRY = (TextBox)DataListField;
                        CoreField = fldF113_DEFAULT_COMP_EP_NBR_ENTRY;
                        fldF113_DEFAULT_COMP_EP_NBR_ENTRY.Bind(fleF113_DEFAULT_COMP);
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
                dtlF113_DEFAULT_COMP.OccursWithFile = fleF113_DEFAULT_COMP;

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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:39:24 AM

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
            fleF113_DEFAULT_COMP.Transaction = m_trnTRANS_UPDATE;
            fleF113_CHECK.Transaction = m_trnTRANS_UPDATE;
            fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
            fleCONSTANTS_MSTR_REC_6.Transaction = m_trnTRANS_UPDATE;


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:39:24 AM

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
                fleF113_DEFAULT_COMP.Dispose();
                fleF113_CHECK.Dispose();
                fleF020_DOCTOR_MSTR.Dispose();
                fleF190_COMP_CODES.Dispose();
                fleF191_EARNINGS_PERIOD.Dispose();
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

        #endregion

        #region "Update Validation"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.

        #endregion


        #region "RecordBuffer Events"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:39:24 AM



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



        private void fldF113_DEFAULT_COMP_COMP_CODE_LookupNotOn(ref bool LookupNotOnExecuted)
        {

            try
            {
                bool blnAlreadyExists = false;
                StringBuilder strSQL = new StringBuilder("SELECT ").Append(fleF113_DEFAULT_COMP.ElementOwner("DOC_NBR"));
                strSQL.Append(" FROM ");
                strSQL.Append(fleF113_DEFAULT_COMP.TableNameWithAlias());
                strSQL.Append(" WHERE ");
                strSQL.Append("     ").Append(fleF113_DEFAULT_COMP.ElementOwner("DOC_NBR")).Append(" = ").Append(Common.StringToField(fleF113_DEFAULT_COMP.GetStringValue("DOC_NBR")));
                strSQL.Append(" And ").Append(fleF113_DEFAULT_COMP.ElementOwner("EP_NBR_FROM")).Append(" = ").Append((fleF113_DEFAULT_COMP.GetDecimalValue("EP_NBR_FROM")));
                strSQL.Append(" And ").Append(fleF113_DEFAULT_COMP.ElementOwner("COMP_CODE")).Append(" = ").Append(Common.StringToField(FieldText));

                if (!LookupNotOn(strSQL, fleF113_DEFAULT_COMP, new string[] { "DOC_NBR", "EP_NBR_FROM", "COMP_CODE" }, new Object[] { fleF113_DEFAULT_COMP.GetStringValue("DOC_NBR"), fleF113_DEFAULT_COMP.GetDecimalValue("EP_NBR_FROM"), FieldText }))
                {
                    blnAlreadyExists = true;
                }

                if (blnAlreadyExists)
                {
                    ErrorMessage("Error - ep nbr and comp code already exist.\a");
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




        private void fldF113_DEFAULT_COMP_COMP_CODE_LookupOn()
        {

            try
            {
                StringBuilder strSQL = new StringBuilder(" WHERE ");
                strSQL.Append("     ").Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ").Append(Common.StringToField(FieldText));

                fleF190_COMP_CODES.GetData(strSQL.ToString(), GetDataOptions.IsOptional);
                if (!AccessOk)
                {
                    ErrorMessage("Error - Invalid COMPENSATION Code.\a");
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




        private void fldF113_DEFAULT_COMP_EP_NBR_TO_LookupOn()
        {

            try
            {
                StringBuilder strSQL = new StringBuilder(" WHERE ");
                strSQL.Append("     ").Append(fleF191_EARNINGS_PERIOD.ElementOwner("EP_NBR")).Append(" = ").Append((FieldValue));

                fleF191_EARNINGS_PERIOD.GetData(strSQL.ToString(), GetDataOptions.IsOptional);
                if (!AccessOk)
                {
                    ErrorMessage("Error - Invalid Earnings Period.\a");
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




        private void fldF113_DEFAULT_COMP_EP_NBR_FROM_LookupOn()
        {

            try
            {
                StringBuilder strSQL = new StringBuilder(" WHERE ");
                strSQL.Append("     ").Append(fleF191_EARNINGS_PERIOD.ElementOwner("EP_NBR")).Append(" = ").Append((FieldValue));

                fleF191_EARNINGS_PERIOD.GetData(strSQL.ToString(), GetDataOptions.IsOptional);
                if (!AccessOk)
                {
                    ErrorMessage("Error - Invalid Earnings Period.\a");
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
                SaveReceivingParams(W_DOC_NBR, fleCONSTANTS_MSTR_REC_6, fleF020_DOCTOR_MSTR);


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
                Receiving(W_DOC_NBR, fleCONSTANTS_MSTR_REC_6, fleF020_DOCTOR_MSTR);


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



        private void fldF113_DEFAULT_COMP_EP_NBR_FROM_Input()
        {

            try
            {

                if (QDesign.NULL(FieldText) == QDesign.NULL("."))
                {

                    object[] arrRunscreen = { };
                    RunScreen(new Billing_M191(), RunScreenModes.Null, ref arrRunscreen);
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



        private void fldF113_DEFAULT_COMP_EP_NBR_FROM_Edit()
        {

            try
            {

                if (QDesign.NULL(fleF113_DEFAULT_COMP.GetDecimalValue("EP_NBR_FROM")) > QDesign.NULL(fleCONSTANTS_MSTR_REC_6.GetDecimalValue("LAST_EP_NBR_OF_FISCAL_YR")))
                {
                    ErrorMessage("Error - This Earnings Period is NOT within the Current Fiscal Year.\a");
                }
                if (QDesign.NULL(fleF113_DEFAULT_COMP.GetDecimalValue("EP_NBR_FROM")) < QDesign.NULL(fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR")))
                {
                    ErrorMessage("Error - This Earnings Period is PRIOR to the Current Earnings Period.\a");
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



        private void fldF113_DEFAULT_COMP_EP_NBR_TO_Input()
        {

            try
            {

                if (QDesign.NULL(FieldText) == QDesign.NULL("."))
                {
                    object[] arrRunscreen = { };
                    RunScreen(new Billing_M191(), RunScreenModes.Null, ref arrRunscreen);
                 
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



        private void fldF113_DEFAULT_COMP_EP_NBR_TO_Edit()
        {

            try
            {

                if (QDesign.NULL(fleF113_DEFAULT_COMP.GetDecimalValue("EP_NBR_TO")) > QDesign.NULL(fleCONSTANTS_MSTR_REC_6.GetDecimalValue("LAST_EP_NBR_OF_FISCAL_YR")))
                {
                    ErrorMessage("Error - This Earnings Period is NOT within the Current Fiscal Year.\a");
                }
                if (QDesign.NULL(fleF113_DEFAULT_COMP.GetDecimalValue("EP_NBR_TO")) < QDesign.NULL(fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR")))
                {
                    Warning("*W* This Earnings Period is PRIOR to the Current Earnings Period.\a");
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



        private void fldF113_DEFAULT_COMP_EP_NBR_FROM_Process()
        {

            try
            {

                fleF113_DEFAULT_COMP.set_SetValue("DOC_NBR", W_DOC_NBR.Value);


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



        private void fldF113_DEFAULT_COMP_COMP_CODE_Input()
        {

            try
            {

                if (QDesign.NULL(FieldText) == QDesign.NULL("."))
                {
                    X_SRCH_CODE.Value = " ";
                    object[] arrRunscreen = { X_SRCH_CODE };
                    RunScreen(new Billing_SY033(), RunScreenModes.Find, ref arrRunscreen);
                    if (QDesign.NULL(X_SRCH_CODE.Value) != QDesign.NULL(" "))
                    {
                        FieldText = X_SRCH_CODE.Value;
                    }
                    else
                    {
                        ErrorMessage("Error - A Compensation Code is required.\a");
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



        private void fldF113_DEFAULT_COMP_COMP_CODE_Edit()
        {

            try
            {

                if (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("COMP_OWNER")) != QDesign.NULL("U"))
                {
                    ErrorMessage("Error - This Compensation Code can`t be input by the User.\a");
                }
                m_strWhere = new StringBuilder(" WHERE ");
                m_strWhere.Append("").Append(fleF113_CHECK.ElementOwner("DOC_NBR")).Append(" = ").Append(Common.StringToField(fleF113_DEFAULT_COMP.GetStringValue("DOC_NBR")));

                while (fleF113_CHECK.WhileRetrieving(m_strWhere.ToString()))
                {
                    if (QDesign.NULL(fleF113_DEFAULT_COMP.GetStringValue("COMP_CODE")) == QDesign.NULL(fleF113_CHECK.GetStringValue("COMP_CODE")) & fleF113_DEFAULT_COMP.GetDecimalValue("EP_NBR_FROM") <= fleF113_CHECK.GetDecimalValue("EP_NBR_TO"))
                    {
                        ErrorMessage("Error - From Ep Nbr already exist .....please check. \a");
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



        private void fldF113_DEFAULT_COMP_COMP_CODE_Process()
        {

            try
            {

                fleF113_DEFAULT_COMP.set_SetValue("DOC_NBR", W_DOC_NBR.Value);
                Display(ref fldF190_COMP_CODES_DESC_SHORT);
                Display(ref fldF113_DEFAULT_COMP_FACTOR);
                fleF113_DEFAULT_COMP.set_SetValue("EP_NBR_ENTRY", fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR"));
                Display(ref fldF113_DEFAULT_COMP_EP_NBR_ENTRY);


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



        private void fldF113_DEFAULT_COMP_AMT_GROSS_Edit()
        {

            try
            {

                if (QDesign.NULL(fleF113_DEFAULT_COMP.GetStringValue("COMP_CODE")) == QDesign.NULL("PAYEFT") & QDesign.NULL(fleF113_DEFAULT_COMP.GetDecimalValue("AMT_GROSS")) != 0)
                {
                    ErrorMessage("Error - Entered Amount for PAYEFT is not allowed. \a");
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


        private bool Internal_CALC_DISPLAY()
        {


            try
            {

                fleF113_DEFAULT_COMP.set_SetValue("AMT_NET", (fleF113_DEFAULT_COMP.GetDecimalValue("AMT_GROSS") * fleF113_DEFAULT_COMP.GetDecimalValue("FACTOR")) / 10000);
                Display(ref fldF113_DEFAULT_COMP_AMT_NET);
                Display(ref fldF113_DEFAULT_COMP_EP_NBR_ENTRY);

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


        private bool Internal_ACCEPT_VALUES()
        {


            try
            {

                Accept(ref fldF113_DEFAULT_COMP_EP_NBR_FROM);
                Accept(ref fldF113_DEFAULT_COMP_EP_NBR_TO);
                Accept(ref fldF113_DEFAULT_COMP_COMP_CODE);
                Display(ref fldF113_DEFAULT_COMP_FACTOR);
                Accept(ref fldF113_DEFAULT_COMP_FACTOR);
                if (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("UNITS_DOLLARS_FLAG")) == QDesign.NULL("U"))
                {
                    Accept(ref fldF113_DEFAULT_COMP_COMP_UNITS);
                }
                else
                {
                    fleF113_DEFAULT_COMP.set_SetValue("COMP_UNITS", 0);
                    Display(ref fldF113_DEFAULT_COMP_COMP_UNITS);
                }
                if (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("UNITS_DOLLARS_FLAG")) == QDesign.NULL("D"))
                {
                    Accept(ref fldF113_DEFAULT_COMP_AMT_GROSS);
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


        protected override bool Update()
        {


            try
            {

                while (fleF113_DEFAULT_COMP.For())
                {
                    fleF113_DEFAULT_COMP.PutData();
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
                while (fleF113_DEFAULT_COMP.ForMissing())
                {
                    m_strWhere = new StringBuilder(GetWhereCondition(fleF113_DEFAULT_COMP.ElementOwner("DOC_NBR"), W_DOC_NBR.Value, ref blnAddWhere));
                    fleF113_DEFAULT_COMP.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
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
        //# Delete Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:39:23 AM
        //#-----------------------------------------
        protected override bool Delete()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:39:23 AM
                fleF113_DEFAULT_COMP.DeletedRecord = true;
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
        //# dtlF113_DEFAULT_COMP_EditClick Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:39:23 AM
        //#-----------------------------------------
        private void dtlF113_DEFAULT_COMP_EditClick(DataList source, GridButtonEventArgs GridButtonEventArgs)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:39:23 AM
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

