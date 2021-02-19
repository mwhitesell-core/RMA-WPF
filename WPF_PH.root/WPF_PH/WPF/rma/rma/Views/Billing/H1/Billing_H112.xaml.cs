
#region "Screen Comments"

// #> PROGRAM-ID.     H112.QKS
// ((C)) Dyad Technologies
// PURPOSE: Query/modifications to Physician PAYCODES / CEILINGS
// MODIFICATION HISTORY
// DATE    SAF #  WHO      DESCRIPTION
// 95/JUN/29  ____   B.M.L.   - original COPIED FROM D112.QKS
// 1999/Apr/9  S.B.  - FIX DISPLAYS AND ALIGNMENST FOR Y2K. 
// - Changed t-ep-nbr-yy to use the full year.
// 1999/Jun/07         S.B.     - Altered the call to scrtitle.use and
// stdhilite.use to be called from $use
// instead of src.
// - Removed the call to secfile.use because
// it was not doing anything.
// 2003/nov/10 b.e.      - alpha doctor nbr
// 2004/sep/02 b.e.      - made all fields display so that data can`t be
// accidently changed
// - added new designer procedcure FIX to allow change
// of each field only after a `secret` password has
// been entered
// 2006/apr/17 b.e.      - adjust display of 3 ceiling fields to allow 1M $

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

    partial class Billing_H112 : BasePage
    {

        #region " Form Designer Generated Code "





        public Billing_H112()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "H112";

            //# Set the ACTIVITIES for the screen.
            this.ChangeActivity = true;
            this.FindActivity = true;
            this.DeleteActivity = false;
            this.EntryActivity = false;
            this.DisableAppend = true;
            this.UseAcceptProcessing = true;
         

            this.GridDesigner = "dsrDesigner_01";


            dsrDesigner_01.DefaultFirstRowInGrid = true;

        }

        #endregion

        private void Page_Load(object sender, RoutedEventArgs e)
        {
            SetVariables();
            dsrDesigner_FIX.Click += dsrDesigner_FIX_Click;
            dsrDesigner_01.Click += dsrDesigner_01_Click;
            dtlF112_PYCDCEILINGS_HISTORY.EditClick += dtlF112_PYCDCEILINGS_HISTORY_EditClick;
            base.Page_Load();

            // TODO: If any DESIGNER procedures function on occurring FILES or TEMPORARIES, set the grid's AllowSelectRowButton property to TRUE.



            // TODO: The following elements have Input/Output Scaling defined in the Dictionary or Screen.  Manual steps may be required:
            //       F112_PYCDCEILINGS_HISTORY.FACTOR InputScale: 4 OutputScale: 0


        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            W_DOC_NBR = new CoreCharacter("W_DOC_NBR", 3, this, Common.cEmptyString);
            W_EP_NBR_YY = new CoreDecimal("W_EP_NBR_YY", 6, this);
            W_PASSWORD = new CoreDate("W_PASSWORD", this);
            T_EP_NBR_YY = new CoreCharacter("T_EP_NBR_YY", 4, this, ResetTypes.ResetAtStartup);
            W_SYSDATE = new CoreDate("W_SYSDATE", this, ResetTypes.ResetAtStartup);
            fleF112_PYCDCEILINGS_HISTORY = new SqlFileObject(this, FileTypes.Primary, 12, "INDEXED", "F112_PYCDCEILINGS_HISTORY", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Master, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleCONSTANTS_MSTR_REC_6 = new SqlFileObject(this, FileTypes.Designer, 0, "INDEXED", "CONSTANTS_MSTR_REC_6", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF191_EARNINGS_PERIOD = new SqlFileObject(this, FileTypes.Reference, 0, "INDEXED", "F191_EARNINGS_PERIOD", "", false, false, false, 0, "m_cnnQUERY");

           

            fleF191_EARNINGS_PERIOD.Access += fleF191_EARNINGS_PERIOD_Access;
            X_SCREEN_NAME.GetValue += X_SCREEN_NAME_GetValue;
            X_SCR_NAME.GetValue += X_SCR_NAME_GetValue;
            fleF112_PYCDCEILINGS_HISTORY.SelectIf += fleF112_PYCDCEILINGS_HISTORY_SelectIf;
            T_EP_NBR_YY.GetInitialValue += T_EP_NBR_YY_GetInitialValue;
            W_SYSDATE.GetInitialValue += W_SYSDATE_GetInitialValue;
        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;
            fleF191_EARNINGS_PERIOD.Access -= fleF191_EARNINGS_PERIOD_Access;
            X_SCREEN_NAME.GetValue -= X_SCREEN_NAME_GetValue;
            X_SCR_NAME.GetValue -= X_SCR_NAME_GetValue;
            fldF112_PYCDCEILINGS_HISTORY_FACTOR.Edit -= fldF112_PYCDCEILINGS_HISTORY_FACTOR_Edit;
            fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_CEILING.Edit -= fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_CEILING_Edit;
            fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_CEILING_ADJUSTED.Edit -= fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_CEILING_ADJUSTED_Edit;
            fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_CEILING_GUAR_PERC.Edit -= fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_CEILING_GUAR_PERC_Edit;
            fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_CEIL_GUAR.Edit -= fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_CEIL_GUAR_Edit;
            fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_EXPENSE.Edit -= fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_EXPENSE_Edit;
            fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_EXPENSE_ADJUSTED.Edit -= fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_EXPENSE_ADJUSTED_Edit;
            fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_EXPN_ALLOC_PERS.Edit -= fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_EXPN_ALLOC_PERS_Edit;
            fldF112_PYCDCEILINGS_HISTORY_RETRO_TO_EP_NBR.Edit -= fldF112_PYCDCEILINGS_HISTORY_RETRO_TO_EP_NBR_Edit;
            fleF112_PYCDCEILINGS_HISTORY.SelectIf -= fleF112_PYCDCEILINGS_HISTORY_SelectIf;
            T_EP_NBR_YY.GetInitialValue -= T_EP_NBR_YY_GetInitialValue;
            dsrDesigner_FIX.Click -= dsrDesigner_FIX_Click;
            dsrDesigner_01.Click -= dsrDesigner_01_Click;
            W_SYSDATE.GetInitialValue -= W_SYSDATE_GetInitialValue;
            dtlF112_PYCDCEILINGS_HISTORY.EditClick -= dtlF112_PYCDCEILINGS_HISTORY_EditClick;

        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private SqlConnection m_cnnQUERY = new SqlConnection();
        private SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
        private SqlTransaction m_trnTRANS_UPDATE;
        private CoreCharacter W_DOC_NBR;
        private CoreDecimal W_EP_NBR_YY;
        private CoreDate W_PASSWORD;
        private CoreCharacter T_EP_NBR_YY;
        private void T_EP_NBR_YY_GetInitialValue()
        {
            T_EP_NBR_YY.InitialValue = QDesign.ASCII(W_EP_NBR_YY.Value, 4);
        }
        private CoreDate W_SYSDATE;
        private void W_SYSDATE_GetInitialValue()
        {
            W_SYSDATE.InitialValue = QDesign.SysDate(ref m_cnnQUERY);
        }
        private SqlFileObject fleF112_PYCDCEILINGS_HISTORY;

        private void fleF112_PYCDCEILINGS_HISTORY_SelectIf(ref string SelectIfClause)
        {


            try
            {
                StringBuilder strSQL = new StringBuilder("");

                strSQL.Append(" (   ").Append(Common.StringToField(T_EP_NBR_YY.Value)).Append("  = ( Substring ( CAST (   ").Append(fleF112_PYCDCEILINGS_HISTORY.ElementOwner("EP_NBR")).Append(" as varchar(6) ) ,  1 ,  4 ) ))");



                SelectIfClause = strSQL.ToString();


            }
            catch (CustomApplicationException ex)
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
        private SqlFileObject fleCONSTANTS_MSTR_REC_6;
        private SqlFileObject fleF191_EARNINGS_PERIOD;

        private void fleF191_EARNINGS_PERIOD_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleF191_EARNINGS_PERIOD.ElementOwner("EP_NBR")).Append(" = ").Append((fleF112_PYCDCEILINGS_HISTORY.GetDecimalValue("EP_NBR")));

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

        private DCharacter X_SCREEN_NAME = new DCharacter(55);
        private void X_SCREEN_NAME_GetValue(ref string Value)
        {

            try
            {
                Value = "PAY CODES, CEILINGS, GUARANTEES";


            }
            catch (CustomApplicationException ex)
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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:10:07 AM

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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:10:08 AM

        protected TextBox fldF112_PYCDCEILINGS_HISTORY_EP_NBR;
        protected DateControl fldF191_EARNINGS_PERIOD_ICONST_DATE_PERIOD_END;
        protected TextBox fldF112_PYCDCEILINGS_HISTORY_DOC_PAY_CODE;
        protected TextBox fldF112_PYCDCEILINGS_HISTORY_DOC_PAY_SUB_CODE;
        protected TextBox fldF112_PYCDCEILINGS_HISTORY_FACTOR;
        protected TextBox fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_CEILING;
        protected TextBox fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_CEILING_ADJUSTED;
        protected TextBox fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_CEILING_GUAR_PERC;
        protected TextBox fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_CEIL_GUAR;
        protected TextBox fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_EXPENSE;
        protected TextBox fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_EXPENSE_ADJUSTED;
        protected TextBox fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_EXPN_ALLOC_PERS;
        protected TextBox fldF112_PYCDCEILINGS_HISTORY_RETRO_TO_EP_NBR;

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:10:08 AM

        //#-----------------------------------------
        //# GetGridFieldObject Procedure.
        //#-----------------------------------------

        protected override void GetGridFieldObject(object DataListField, ref object CoreField, string Name)
        {

            try
            {
                switch (Name.ToUpper())
                {
                    case "FLDGRDF112_PYCDCEILINGS_HISTORY_EP_NBR":
                        fldF112_PYCDCEILINGS_HISTORY_EP_NBR = (TextBox)DataListField;
                        CoreField = fldF112_PYCDCEILINGS_HISTORY_EP_NBR;
                        fldF112_PYCDCEILINGS_HISTORY_EP_NBR.Bind(fleF112_PYCDCEILINGS_HISTORY);
                        break;
                    case "FLDGRDF191_EARNINGS_PERIOD_ICONST_DATE_PERIOD_END":
                        fldF191_EARNINGS_PERIOD_ICONST_DATE_PERIOD_END = (DateControl)DataListField;
                        CoreField = fldF191_EARNINGS_PERIOD_ICONST_DATE_PERIOD_END;
                        fldF191_EARNINGS_PERIOD_ICONST_DATE_PERIOD_END.Bind(fleF191_EARNINGS_PERIOD);
                        break;
                    case "FLDGRDF112_PYCDCEILINGS_HISTORY_DOC_PAY_CODE":
                        fldF112_PYCDCEILINGS_HISTORY_DOC_PAY_CODE = (TextBox)DataListField;
                        CoreField = fldF112_PYCDCEILINGS_HISTORY_DOC_PAY_CODE;
                        fldF112_PYCDCEILINGS_HISTORY_DOC_PAY_CODE.Bind(fleF112_PYCDCEILINGS_HISTORY);
                        break;
                    case "FLDGRDF112_PYCDCEILINGS_HISTORY_DOC_PAY_SUB_CODE":
                        fldF112_PYCDCEILINGS_HISTORY_DOC_PAY_SUB_CODE = (TextBox)DataListField;
                        CoreField = fldF112_PYCDCEILINGS_HISTORY_DOC_PAY_SUB_CODE;
                        fldF112_PYCDCEILINGS_HISTORY_DOC_PAY_SUB_CODE.Bind(fleF112_PYCDCEILINGS_HISTORY);
                        break;
                    case "FLDGRDF112_PYCDCEILINGS_HISTORY_FACTOR":
                        fldF112_PYCDCEILINGS_HISTORY_FACTOR = (TextBox)DataListField;

                        fldF112_PYCDCEILINGS_HISTORY_FACTOR.Edit -= fldF112_PYCDCEILINGS_HISTORY_FACTOR_Edit;
                        fldF112_PYCDCEILINGS_HISTORY_FACTOR.Edit += fldF112_PYCDCEILINGS_HISTORY_FACTOR_Edit;
                        CoreField = fldF112_PYCDCEILINGS_HISTORY_FACTOR;
                        fldF112_PYCDCEILINGS_HISTORY_FACTOR.Bind(fleF112_PYCDCEILINGS_HISTORY);
                        break;
                    case "FLDGRDF112_PYCDCEILINGS_HISTORY_DOC_YRLY_CEILING":
                        fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_CEILING = (TextBox)DataListField;

                        fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_CEILING.Edit -= fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_CEILING_Edit;
                        fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_CEILING.Edit += fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_CEILING_Edit;
                        CoreField = fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_CEILING;
                        fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_CEILING.Bind(fleF112_PYCDCEILINGS_HISTORY);
                        break;
                    case "FLDGRDF112_PYCDCEILINGS_HISTORY_DOC_YRLY_CEILING_ADJUSTED":
                        fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_CEILING_ADJUSTED = (TextBox)DataListField;

                        fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_CEILING_ADJUSTED.Edit -= fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_CEILING_ADJUSTED_Edit;
                        fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_CEILING_ADJUSTED.Edit += fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_CEILING_ADJUSTED_Edit;
                        CoreField = fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_CEILING_ADJUSTED;
                        fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_CEILING_ADJUSTED.Bind(fleF112_PYCDCEILINGS_HISTORY);
                        break;
                    case "FLDGRDF112_PYCDCEILINGS_HISTORY_DOC_YRLY_CEILING_GUAR_PERC":
                        fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_CEILING_GUAR_PERC = (TextBox)DataListField;

                        fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_CEILING_GUAR_PERC.Edit -= fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_CEILING_GUAR_PERC_Edit;
                        fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_CEILING_GUAR_PERC.Edit += fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_CEILING_GUAR_PERC_Edit;
                        CoreField = fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_CEILING_GUAR_PERC;
                        fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_CEILING_GUAR_PERC.Bind(fleF112_PYCDCEILINGS_HISTORY);
                        break;
                    case "FLDGRDF112_PYCDCEILINGS_HISTORY_DOC_YRLY_CEIL_GUAR":
                        fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_CEIL_GUAR = (TextBox)DataListField;

                        fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_CEIL_GUAR.Edit -= fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_CEIL_GUAR_Edit;
                        fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_CEIL_GUAR.Edit += fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_CEIL_GUAR_Edit;
                        CoreField = fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_CEIL_GUAR;
                        fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_CEIL_GUAR.Bind(fleF112_PYCDCEILINGS_HISTORY);
                        break;
                    case "FLDGRDF112_PYCDCEILINGS_HISTORY_DOC_YRLY_EXPENSE":
                        fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_EXPENSE = (TextBox)DataListField;

                        fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_EXPENSE.Edit -= fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_EXPENSE_Edit;
                        fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_EXPENSE.Edit += fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_EXPENSE_Edit;
                        CoreField = fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_EXPENSE;
                        fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_EXPENSE.Bind(fleF112_PYCDCEILINGS_HISTORY);
                        break;
                    case "FLDGRDF112_PYCDCEILINGS_HISTORY_DOC_YRLY_EXPENSE_ADJUSTED":
                        fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_EXPENSE_ADJUSTED = (TextBox)DataListField;

                        fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_EXPENSE_ADJUSTED.Edit -= fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_EXPENSE_ADJUSTED_Edit;
                        fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_EXPENSE_ADJUSTED.Edit += fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_EXPENSE_ADJUSTED_Edit;
                        CoreField = fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_EXPENSE_ADJUSTED;
                        fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_EXPENSE_ADJUSTED.Bind(fleF112_PYCDCEILINGS_HISTORY);
                        break;
                    case "FLDGRDF112_PYCDCEILINGS_HISTORY_DOC_YRLY_EXPN_ALLOC_PERS":
                        fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_EXPN_ALLOC_PERS = (TextBox)DataListField;

                        fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_EXPN_ALLOC_PERS.Edit -= fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_EXPN_ALLOC_PERS_Edit;
                        fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_EXPN_ALLOC_PERS.Edit += fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_EXPN_ALLOC_PERS_Edit;
                        CoreField = fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_EXPN_ALLOC_PERS;
                        fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_EXPN_ALLOC_PERS.Bind(fleF112_PYCDCEILINGS_HISTORY);
                        break;
                    case "FLDGRDF112_PYCDCEILINGS_HISTORY_RETRO_TO_EP_NBR":
                        fldF112_PYCDCEILINGS_HISTORY_RETRO_TO_EP_NBR = (TextBox)DataListField;

                        fldF112_PYCDCEILINGS_HISTORY_RETRO_TO_EP_NBR.Edit -= fldF112_PYCDCEILINGS_HISTORY_RETRO_TO_EP_NBR_Edit;
                        fldF112_PYCDCEILINGS_HISTORY_RETRO_TO_EP_NBR.Edit += fldF112_PYCDCEILINGS_HISTORY_RETRO_TO_EP_NBR_Edit;
                        CoreField = fldF112_PYCDCEILINGS_HISTORY_RETRO_TO_EP_NBR;
                        fldF112_PYCDCEILINGS_HISTORY_RETRO_TO_EP_NBR.Bind(fleF112_PYCDCEILINGS_HISTORY);
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
                dtlF112_PYCDCEILINGS_HISTORY.OccursWithFile = fleF112_PYCDCEILINGS_HISTORY;

            }
            catch (CustomApplicationException ex)
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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:10:08 AM

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
            fleF112_PYCDCEILINGS_HISTORY.Transaction = m_trnTRANS_UPDATE;
            fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
            fleCONSTANTS_MSTR_REC_6.Transaction = m_trnTRANS_UPDATE;


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:10:08 AM

        //#-----------------------------------------
        //# InitializeFiles Procedure.
        //#-----------------------------------------

        protected override void InitializeFiles()
        {

            try
            {
                Initialize_TRANS_UPDATE();
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
                fleF112_PYCDCEILINGS_HISTORY.Dispose();
                fleF020_DOCTOR_MSTR.Dispose();
                fleCONSTANTS_MSTR_REC_6.Dispose();
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

        //#-----------------------------------------
        //# DisplayFormatting Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:10:08 AM
        //#-----------------------------------------
        protected override void DisplayFormatting()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:10:08 AM
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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:10:08 AM

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
                SaveReceivingParams(W_DOC_NBR, W_EP_NBR_YY, fleCONSTANTS_MSTR_REC_6, fleF020_DOCTOR_MSTR);


            }
            catch (CustomApplicationException ex)
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
                Receiving(W_DOC_NBR, W_EP_NBR_YY, fleCONSTANTS_MSTR_REC_6, fleF020_DOCTOR_MSTR);


            }
            catch (CustomApplicationException ex)
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

                Accept(ref fldW_PASSWORD);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldF112_PYCDCEILINGS_HISTORY_FACTOR_Edit()
        {

            try
            {

                if (QDesign.NULL(W_PASSWORD.Value) != QDesign.NULL(W_SYSDATE.Value))
                {
                    FieldValue = OldValue(fleF112_PYCDCEILINGS_HISTORY.ElementOwner("FACTOR"), fleF112_PYCDCEILINGS_HISTORY.GetDecimalValue("FACTOR"));
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



        private void fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_CEILING_Edit()
        {

            try
            {

                if (QDesign.NULL(W_PASSWORD.Value) != QDesign.NULL(W_SYSDATE.Value))
                {
                    FieldValue = OldValue(fleF112_PYCDCEILINGS_HISTORY.ElementOwner("DOC_YRLY_CEILING"), fleF112_PYCDCEILINGS_HISTORY.GetDecimalValue("DOC_YRLY_CEILING"));
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



        private void fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_CEILING_ADJUSTED_Edit()
        {

            try
            {

                if (QDesign.NULL(W_PASSWORD.Value) != QDesign.NULL(W_SYSDATE.Value))
                {
                    FieldValue = OldValue(fleF112_PYCDCEILINGS_HISTORY.ElementOwner("DOC_YRLY_CEILING_ADJUSTED"), fleF112_PYCDCEILINGS_HISTORY.GetDecimalValue("DOC_YRLY_CEILING_ADJUSTED"));
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



        private void fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_CEILING_GUAR_PERC_Edit()
        {

            try
            {

                if (QDesign.NULL(W_PASSWORD.Value) != QDesign.NULL(W_SYSDATE.Value))
                {
                    FieldValue = OldValue(fleF112_PYCDCEILINGS_HISTORY.ElementOwner("DOC_YRLY_CEILING_GUAR_PERC"), fleF112_PYCDCEILINGS_HISTORY.GetDecimalValue("DOC_YRLY_CEILING_GUAR_PERC"));
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



        private void fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_CEIL_GUAR_Edit()
        {

            try
            {

                if (QDesign.NULL(W_PASSWORD.Value) != QDesign.NULL(W_SYSDATE.Value))
                {
                    FieldValue = OldValue(fleF112_PYCDCEILINGS_HISTORY.ElementOwner("DOC_YRLY_CEIL_GUAR"), fleF112_PYCDCEILINGS_HISTORY.GetDecimalValue("DOC_YRLY_CEIL_GUAR"));
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



        private void fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_EXPENSE_Edit()
        {

            try
            {

                if (QDesign.NULL(W_PASSWORD.Value) != QDesign.NULL(W_SYSDATE.Value))
                {
                    FieldValue = OldValue(fleF112_PYCDCEILINGS_HISTORY.ElementOwner("DOC_YRLY_EXPENSE"), fleF112_PYCDCEILINGS_HISTORY.GetDecimalValue("DOC_YRLY_EXPENSE"));
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



        private void fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_EXPENSE_ADJUSTED_Edit()
        {

            try
            {

                if (QDesign.NULL(W_PASSWORD.Value) != QDesign.NULL(W_SYSDATE.Value))
                {
                    FieldValue = OldValue(fleF112_PYCDCEILINGS_HISTORY.ElementOwner("DOC_YRLY_EXPENSE_ADJUSTED"), fleF112_PYCDCEILINGS_HISTORY.GetDecimalValue("DOC_YRLY_EXPENSE_ADJUSTED"));
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



        private void fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_EXPN_ALLOC_PERS_Edit()
        {

            try
            {

                if (QDesign.NULL(W_PASSWORD.Value) != QDesign.NULL(W_SYSDATE.Value))
                {
                    FieldValue = OldValue(fleF112_PYCDCEILINGS_HISTORY.ElementOwner("DOC_YRLY_EXPN_ALLOC_PERS"), fleF112_PYCDCEILINGS_HISTORY.GetDecimalValue("DOC_YRLY_EXPN_ALLOC_PERS"));
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



        private void fldF112_PYCDCEILINGS_HISTORY_RETRO_TO_EP_NBR_Edit()
        {

            try
            {

                if (QDesign.NULL(W_PASSWORD.Value) != QDesign.NULL(W_SYSDATE.Value))
                {
                    FieldValue = OldValue(fleF112_PYCDCEILINGS_HISTORY.ElementOwner("RETRO_TO_EP_NBR"), fleF112_PYCDCEILINGS_HISTORY.GetDecimalValue("RETRO_TO_EP_NBR"));
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
                m_strWhere = new StringBuilder(GetWhereCondition(fleF112_PYCDCEILINGS_HISTORY.ElementOwner("DOC_NBR"), W_DOC_NBR.Value, ref blnAddWhere));
                fleF112_PYCDCEILINGS_HISTORY.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);



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
        //# Append Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:10:08 AM
        //#-----------------------------------------
        protected override bool Append()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:10:08 AM
                Display(ref fldF112_PYCDCEILINGS_HISTORY_EP_NBR);
                Display(ref fldF191_EARNINGS_PERIOD_ICONST_DATE_PERIOD_END);
                Display(ref fldF112_PYCDCEILINGS_HISTORY_DOC_PAY_CODE);
                Display(ref fldF112_PYCDCEILINGS_HISTORY_DOC_PAY_SUB_CODE);
                Accept(ref fldF112_PYCDCEILINGS_HISTORY_FACTOR);
                Accept(ref fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_CEILING);
                Accept(ref fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_CEILING_ADJUSTED);
                Accept(ref fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_CEILING_GUAR_PERC);
                Accept(ref fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_CEIL_GUAR);
                Accept(ref fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_EXPENSE);
                Accept(ref fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_EXPENSE_ADJUSTED);
                Accept(ref fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_EXPN_ALLOC_PERS);
                Accept(ref fldF112_PYCDCEILINGS_HISTORY_RETRO_TO_EP_NBR);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:10:08 AM
        //#-----------------------------------------
        protected override bool Update()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:10:08 AM
                fleF020_DOCTOR_MSTR.PutData();
                while (fleF112_PYCDCEILINGS_HISTORY.For())
                {
                    fleF112_PYCDCEILINGS_HISTORY.PutData();
                }
                fleF020_DOCTOR_MSTR.PutData();
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
        //# dtlF112_PYCDCEILINGS_HISTORY_EditClick Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:10:08 AM
        //#-----------------------------------------
        private void dtlF112_PYCDCEILINGS_HISTORY_EditClick(DataList source, GridButtonEventArgs GridButtonEventArgs)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:10:08 AM
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:10:08 AM
        //#-----------------------------------------
        private void dsrDesigner_01_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:10:08 AM
                Display(ref fldF112_PYCDCEILINGS_HISTORY_EP_NBR);
                Display(ref fldF191_EARNINGS_PERIOD_ICONST_DATE_PERIOD_END);
                Display(ref fldF112_PYCDCEILINGS_HISTORY_DOC_PAY_CODE);
                Display(ref fldF112_PYCDCEILINGS_HISTORY_DOC_PAY_SUB_CODE);
                Accept(ref fldF112_PYCDCEILINGS_HISTORY_FACTOR);
                Accept(ref fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_CEILING);
                Accept(ref fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_CEILING_ADJUSTED);
                Accept(ref fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_CEILING_GUAR_PERC);
                Accept(ref fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_CEIL_GUAR);
                Accept(ref fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_EXPENSE);
                Accept(ref fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_EXPENSE_ADJUSTED);
                Accept(ref fldF112_PYCDCEILINGS_HISTORY_DOC_YRLY_EXPN_ALLOC_PERS);
                Accept(ref fldF112_PYCDCEILINGS_HISTORY_RETRO_TO_EP_NBR);
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

