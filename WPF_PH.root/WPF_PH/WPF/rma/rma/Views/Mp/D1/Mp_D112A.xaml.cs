
#region "Screen Comments"

// #> PROGRAM-ID.     D112A.QKS
// ((C)) Dyad Technologies
// PURPOSE: Query/modifications to Physician PAYCODES / REVENUES
// MODIFICATION HISTORY
// DATE    SAF #  WHO      DESCRIPTION
// 96/JAN/19  ____   M.C.     - original (CLONE FROM D112.QKS)
// 1999/Jan/20  S.B.  - Fixed size and alignments for Y2K.
// 1999/Apr/20  S.B.  - Altered t-yy-ep, t-yy-retro, and
// t-yy-fiscal to use century. 
// 1999/Jun/07  S.B.     - Altered the call to scrtitle.use and
// stdhilite.use to be called from $use
// instead of src.
// - Removed the call to secfile.use because
// it was not doing anything.
// 2003/nov/10 b.e.      - alpha doctor nbr
// 2014/sep/15 MC1       - add f112-pycdceilings-audit to capture before change records
// - save f112-pycdceilings records in f112-pycdceilings-audit in postfind in case
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

    partial class Mp_D112A : BasePage
    {

        #region " Form Designer Generated Code "





        public Mp_D112A()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "D112A";

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
            dsrDesigner_01.Click += dsrDesigner_01_Click;
            dtlF112_PYCDCEILINGS.EditClick += dtlF112_PYCDCEILINGS_EditClick;
            fldT_SILENT_REVENUE.Process += fldT_SILENT_REVENUE_Process;
            base.Page_Load();

            // TODO: If any DESIGNER procedures function on occurring FILES or TEMPORARIES, set the grid's AllowSelectRowButton property to TRUE.



            // TODO: The following elements have Input/Output Scaling defined in the Dictionary or Screen.  Manual steps may be required:
            //       F112_PYCDCEILINGS.DOC_YRLY_CEILING_COMPUTED InputScale: 2 OutputScale: 0
            //       F112_PYCDCEILINGS.DOC_YRLY_EXPENSE_COMPUTED InputScale: 2 OutputScale: 0
            //       F112_PYCDCEILINGS.FACTOR InputScale: 4 OutputScale: 0
            //       F112_PYCDCEILINGS_AUDIT.DOC_YRLY_CEILING_COMPUTED InputScale: 2 OutputScale: 0
            //       F112_PYCDCEILINGS_AUDIT.DOC_YRLY_EXPENSE_COMPUTED InputScale: 2 OutputScale: 0
            //       F112_PYCDCEILINGS_AUDIT.FACTOR InputScale: 4 OutputScale: 0


        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            W_DOC_NBR = new CoreCharacter("W_DOC_NBR", 3, this, Common.cEmptyString);
            T_YY_EP = new CoreCharacter("T_YY_EP", 4, this, Common.cEmptyString);
            T_YY_FISCAL = new CoreCharacter("T_YY_FISCAL", 4, this, Common.cEmptyString);
            T_YY_RETRO = new CoreCharacter("T_YY_RETRO", 4, this, Common.cEmptyString);
            T_ADJUSTMENT = new CoreDecimal("T_ADJUSTMENT", 6, this);
            T_COUNTER_RECS_F112 = new CoreDecimal("T_COUNTER_RECS_F112", 6, this);
            T_LAST_REVENUE_REQ = new CoreDecimal("T_LAST_REVENUE_REQ", 6, this);
            T_LAST_REVENUE_TAR = new CoreDecimal("T_LAST_REVENUE_TAR", 6, this);
            H_DOC_YRLY_REQREV = new CoreDecimal("H_DOC_YRLY_REQREV", 6, this);
            H_DOC_YRLY_TARREV = new CoreDecimal("H_DOC_YRLY_TARREV", 6, this);
            H_RETRO_TO_EP_NBR_REQ = new CoreDecimal("H_RETRO_TO_EP_NBR_REQ", 6, this);
            H_RETRO_TO_EP_NBR_TAR = new CoreDecimal("H_RETRO_TO_EP_NBR_TAR", 6, this);
            H_CURRENT_OCCURENCE = new CoreDecimal("H_CURRENT_OCCURENCE", 6, this);
            H_CURRENT_EP = new CoreDecimal("H_CURRENT_EP", 6, this);
            H_REVENUE_TYPE = new CoreCharacter("H_REVENUE_TYPE", 3, this, Common.cEmptyString);
            T_DOC_YRLY_REVENUE_COMP1 = new CoreDecimal("T_DOC_YRLY_REVENUE_COMP1", 6, this);
            T_DOC_YRLY_REVENUE_COMP2 = new CoreDecimal("T_DOC_YRLY_REVENUE_COMP2", 6, this);
            T_DOC_YRLY_REVENUE_ERR = new CoreDecimal("T_DOC_YRLY_REVENUE_ERR", 6, this);
            T_DOC_YRLY_REQREV_COMPUTED = new CoreDecimal("T_DOC_YRLY_REQREV_COMPUTED", 6, this);
            T_DOC_YRLY_TARREV_COMPUTED = new CoreDecimal("T_DOC_YRLY_TARREV_COMPUTED", 6, this);
            T_YEARLY_REVENUE = new CoreDecimal("T_YEARLY_REVENUE", 6, this);
            T_REVENUE_COMPUTED = new CoreDecimal("T_REVENUE_COMPUTED", 6, this);
            T_RETRO_TO_FLAG = new CoreCharacter("T_RETRO_TO_FLAG", 1, this, Common.cEmptyString);
            T_LAST_EP_NBR = new CoreDecimal("T_LAST_EP_NBR", 6, this);
            T_SILENT_REVENUE = new CoreDecimal("T_SILENT_REVENUE", 6, this);
            fleF112_PYCDCEILINGS = new SqlFileObject(this, FileTypes.Primary, 13, "INDEXED", "F112_PYCDCEILINGS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Master, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleCONSTANTS_MSTR_REC_6 = new SqlFileObject(this, FileTypes.Designer, 0, "INDEXED", "CONSTANTS_MSTR_REC_6", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF191_EARNINGS_PERIOD = new SqlFileObject(this, FileTypes.Reference, 0, "INDEXED", "F191_EARNINGS_PERIOD", "", false, false, false, 0, "m_cnnQUERY");
            fleF020_DOCTOR_EXTRA = new SqlFileObject(this, FileTypes.Designer, 0, "INDEXED", "F020_DOCTOR_EXTRA", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF112_PYCDCEILINGS_AUDIT = new SqlFileObject(this, FileTypes.Designer, fleF112_PYCDCEILINGS, "SEQUENTIAL", "F112_PYCDCEILINGS_AUDIT", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SequentialDataBase);
            A_DOC_NBR = new CoreCharacter("A_DOC_NBR", 3, this, fleF112_PYCDCEILINGS, Common.cEmptyString);
            A_EP_NBR = new CoreDecimal("A_EP_NBR", 6, this, fleF112_PYCDCEILINGS, 0m);
            A_FACTOR = new CoreDecimal("A_FACTOR", 6, this, fleF112_PYCDCEILINGS, 0m);
            A_DOC_PAY_CODE = new CoreCharacter("A_DOC_PAY_CODE", 1, this, fleF112_PYCDCEILINGS, Common.cEmptyString);
            A_DOC_PAY_SUB_CODE = new CoreCharacter("A_DOC_PAY_SUB_CODE", 1, this, fleF112_PYCDCEILINGS, Common.cEmptyString);
            A_RETRO_TO_EP_NBR = new CoreDecimal("A_RETRO_TO_EP_NBR", 6, this, fleF112_PYCDCEILINGS, 0m);
            A_DOC_YRLY_CEILING = new CoreDecimal("A_DOC_YRLY_CEILING", 7, this, fleF112_PYCDCEILINGS, 0m);
            A_DOC_YRLY_CEILING_ADJUSTED = new CoreDecimal("A_DOC_YRLY_CEILING_ADJUSTED", 7, this, fleF112_PYCDCEILINGS, 0m);
            A_DOC_YRLY_CEILING_COMPUTED = new CoreDecimal("A_DOC_YRLY_CEILING_COMPUTED", 9, this, fleF112_PYCDCEILINGS, 0m);
            A_DOC_YRLY_EXPENSE = new CoreDecimal("A_DOC_YRLY_EXPENSE", 7, this, fleF112_PYCDCEILINGS, 0m);
            A_DOC_YRLY_EXPENSE_ADJUSTED = new CoreDecimal("A_DOC_YRLY_EXPENSE_ADJUSTED", 7, this, fleF112_PYCDCEILINGS, 0m);
            A_DOC_YRLY_EXPENSE_COMPUTED = new CoreDecimal("A_DOC_YRLY_EXPENSE_COMPUTED", 9, this, fleF112_PYCDCEILINGS, 0m);
            A_DOC_YRLY_EXPN_ALLOC_PERS = new CoreDecimal("A_DOC_YRLY_EXPN_ALLOC_PERS", 2, this, fleF112_PYCDCEILINGS, 0m);
            A_DOC_YRLY_CEIL_GUAR = new CoreDecimal("A_DOC_YRLY_CEIL_GUAR", 9, this, fleF112_PYCDCEILINGS, 0m);
            A_DOC_YRLY_CEILING_GUAR_PERC = new CoreDecimal("A_DOC_YRLY_CEILING_GUAR_PERC", 3, this, fleF112_PYCDCEILINGS, 0m);
            A_DOC_RMA_EXPENSE_PERCENT_REG = new CoreInteger("A_DOC_RMA_EXPENSE_PERCENT_REG", 9, this, fleF112_PYCDCEILINGS, 0m);
            A_DOC_RMA_EXPENSE_PERCENT_MISC = new CoreInteger("A_DOC_RMA_EXPENSE_PERCENT_MISC", 9, this, fleF112_PYCDCEILINGS, 0m);
            A_DOC_DEPT_EXPENSE_PERCENT_REG = new CoreInteger("A_DOC_DEPT_EXPENSE_PERCENT_REG", 9, this, fleF112_PYCDCEILINGS, 0m);
            A_DOC_DEPT_EXPENSE_PERCENT_MISC = new CoreInteger("A_DOC_DEPT_EXPENSE_PERCENT_MISC", 9, this, fleF112_PYCDCEILINGS, 0m);
            A_DOC_YRLY_REQREV = new CoreInteger("A_DOC_YRLY_REQREV", 9, this, fleF112_PYCDCEILINGS, 0m);
            A_DOC_YRLY_REQREV_ADJUSTED = new CoreInteger("A_DOC_YRLY_REQREV_ADJUSTED", 9, this, fleF112_PYCDCEILINGS, 0m);
            A_DOC_YRLY_REQREV_COMPUTED = new CoreDecimal("A_DOC_YRLY_REQREV_COMPUTED", 9, this, fleF112_PYCDCEILINGS, 0m);
            A_DOC_YRLY_TARREV = new CoreInteger("A_DOC_YRLY_TARREV", 9, this, fleF112_PYCDCEILINGS, 0m);
            A_DOC_YRLY_TARREV_ADJUSTED = new CoreInteger("A_DOC_YRLY_TARREV_ADJUSTED", 9, this, fleF112_PYCDCEILINGS, 0m);
            A_DOC_YRLY_TARREV_COMPUTED = new CoreInteger("A_DOC_YRLY_TARREV_COMPUTED", 4, this, fleF112_PYCDCEILINGS, 0m);
            A_RETRO_TO_EP_NBR_REQ = new CoreDecimal("A_RETRO_TO_EP_NBR_REQ", 6, this, fleF112_PYCDCEILINGS, 0m);
            A_RETRO_TO_EP_NBR_TAR = new CoreDecimal("A_RETRO_TO_EP_NBR_TAR", 6, this, fleF112_PYCDCEILINGS, 0m);

           
            fleF191_EARNINGS_PERIOD.Access += fleF191_EARNINGS_PERIOD_Access;
            X_SCREEN_NAME.GetValue += X_SCREEN_NAME_GetValue;
            X_SCR_NAME.GetValue += X_SCR_NAME_GetValue;
        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;
            fleF191_EARNINGS_PERIOD.Access -= fleF191_EARNINGS_PERIOD_Access;
            X_SCREEN_NAME.GetValue -= X_SCREEN_NAME_GetValue;
            X_SCR_NAME.GetValue -= X_SCR_NAME_GetValue;
            fldF112_PYCDCEILINGS_RETRO_TO_EP_NBR_TAR.LookupOn -= fldF112_PYCDCEILINGS_RETRO_TO_EP_NBR_TAR_LookupOn;
            fldF112_PYCDCEILINGS_RETRO_TO_EP_NBR_REQ.LookupOn -= fldF112_PYCDCEILINGS_RETRO_TO_EP_NBR_REQ_LookupOn;
            fldF112_PYCDCEILINGS_DOC_YRLY_REQREV.Edit -= fldF112_PYCDCEILINGS_DOC_YRLY_REQREV_Edit;
            fldF112_PYCDCEILINGS_DOC_YRLY_TARREV.Edit -= fldF112_PYCDCEILINGS_DOC_YRLY_TARREV_Edit;
            fldF112_PYCDCEILINGS_RETRO_TO_EP_NBR_REQ.Edit -= fldF112_PYCDCEILINGS_RETRO_TO_EP_NBR_REQ_Edit;
            fldF112_PYCDCEILINGS_RETRO_TO_EP_NBR_TAR.Edit -= fldF112_PYCDCEILINGS_RETRO_TO_EP_NBR_TAR_Edit;

            dsrDesigner_01.Click -= dsrDesigner_01_Click;
            dtlF112_PYCDCEILINGS.EditClick -= dtlF112_PYCDCEILINGS_EditClick;
            fldT_SILENT_REVENUE.Process -= fldT_SILENT_REVENUE_Process;
        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private SqlConnection m_cnnQUERY = new SqlConnection();
        private SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
        private SqlTransaction m_trnTRANS_UPDATE;
        private CoreCharacter W_DOC_NBR;
        private CoreCharacter T_YY_EP;
        private CoreCharacter T_YY_FISCAL;
        private CoreCharacter T_YY_RETRO;
        private CoreDecimal T_ADJUSTMENT;
        private CoreDecimal T_COUNTER_RECS_F112;
        private CoreDecimal T_LAST_REVENUE_REQ;
        private CoreDecimal T_LAST_REVENUE_TAR;
        private CoreDecimal H_DOC_YRLY_REQREV;
        private CoreDecimal H_DOC_YRLY_TARREV;
        private CoreDecimal H_RETRO_TO_EP_NBR_REQ;
        private CoreDecimal H_RETRO_TO_EP_NBR_TAR;
        private CoreDecimal H_CURRENT_OCCURENCE;
        private CoreDecimal H_CURRENT_EP;
        private CoreCharacter H_REVENUE_TYPE;
        private CoreDecimal T_DOC_YRLY_REVENUE_COMP1;
        private CoreDecimal T_DOC_YRLY_REVENUE_COMP2;
        private CoreDecimal T_DOC_YRLY_REVENUE_ERR;
        private CoreDecimal T_DOC_YRLY_REQREV_COMPUTED;
        private CoreDecimal T_DOC_YRLY_TARREV_COMPUTED;
        private CoreDecimal T_YEARLY_REVENUE;
        private CoreDecimal T_REVENUE_COMPUTED;
        private CoreCharacter T_RETRO_TO_FLAG;
        private CoreDecimal T_LAST_EP_NBR;
        private CoreDecimal T_SILENT_REVENUE;
        private SqlFileObject fleF112_PYCDCEILINGS;
        private SqlFileObject fleF020_DOCTOR_MSTR;
        private SqlFileObject fleCONSTANTS_MSTR_REC_6;
        private SqlFileObject fleF191_EARNINGS_PERIOD;

        private void fleF191_EARNINGS_PERIOD_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleF191_EARNINGS_PERIOD.ElementOwner("EP_NBR")).Append(" = ").Append((fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR")));

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

        private SqlFileObject fleF020_DOCTOR_EXTRA;
        private SqlFileObject fleF112_PYCDCEILINGS_AUDIT;
        //#CORE_BEGIN_INCLUDE: SAVEF112AUDIT_VAR"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/26/2017 10:17:39 AM

        private CoreCharacter A_DOC_NBR;
        private CoreDecimal A_EP_NBR;
        private CoreDecimal A_FACTOR;
        private CoreCharacter A_DOC_PAY_CODE;
        private CoreCharacter A_DOC_PAY_SUB_CODE;
        private CoreDecimal A_RETRO_TO_EP_NBR;
        private CoreDecimal A_DOC_YRLY_CEILING;
        private CoreDecimal A_DOC_YRLY_CEILING_ADJUSTED;
        private CoreDecimal A_DOC_YRLY_CEILING_COMPUTED;
        private CoreDecimal A_DOC_YRLY_EXPENSE;
        private CoreDecimal A_DOC_YRLY_EXPENSE_ADJUSTED;
        private CoreDecimal A_DOC_YRLY_EXPENSE_COMPUTED;
        private CoreDecimal A_DOC_YRLY_EXPN_ALLOC_PERS;
        private CoreDecimal A_DOC_YRLY_CEIL_GUAR;
        private CoreDecimal A_DOC_YRLY_CEILING_GUAR_PERC;
        private CoreInteger A_DOC_RMA_EXPENSE_PERCENT_REG;
        private CoreInteger A_DOC_RMA_EXPENSE_PERCENT_MISC;
        private CoreInteger A_DOC_DEPT_EXPENSE_PERCENT_REG;
        private CoreInteger A_DOC_DEPT_EXPENSE_PERCENT_MISC;
        private CoreInteger A_DOC_YRLY_REQREV;
        private CoreInteger A_DOC_YRLY_REQREV_ADJUSTED;
        private CoreDecimal A_DOC_YRLY_REQREV_COMPUTED;
        private CoreInteger A_DOC_YRLY_TARREV;
        private CoreInteger A_DOC_YRLY_TARREV_ADJUSTED;
        private CoreInteger A_DOC_YRLY_TARREV_COMPUTED;
        private CoreDecimal A_RETRO_TO_EP_NBR_REQ;

        private CoreDecimal A_RETRO_TO_EP_NBR_TAR;
        //#CORE_END_INCLUDE: SAVEF112AUDIT_VAR"

        private DCharacter X_SCREEN_NAME = new DCharacter(55);
        private void X_SCREEN_NAME_GetValue(ref string Value)
        {

            try
            {

                // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

                Value = "PAY CODES, REQUIRE/TARGET REVENUE";


            }
            catch (CustomApplicationException ex)
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
        //# Do not delete, modify or move it.  Updated: 5/26/2017 10:17:39 AM

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
        //# Do not delete, modify or move it.  Updated: 5/26/2017 10:17:39 AM

        protected TextBox fldF112_PYCDCEILINGS_EP_NBR;
        protected DateControl fldF191_EARNINGS_PERIOD_ICONST_DATE_PERIOD_END;
        protected TextBox fldF112_PYCDCEILINGS_DOC_PAY_CODE;
        protected TextBox fldF112_PYCDCEILINGS_DOC_PAY_SUB_CODE;
        protected TextBox fldF112_PYCDCEILINGS_DOC_YRLY_REQREV;
        protected TextBox fldF112_PYCDCEILINGS_DOC_YRLY_REQREV_ADJUSTED;
        protected TextBox fldF112_PYCDCEILINGS_RETRO_TO_EP_NBR_REQ;
        protected TextBox fldF112_PYCDCEILINGS_DOC_YRLY_TARREV;
        protected TextBox fldF112_PYCDCEILINGS_DOC_YRLY_TARREV_ADJUSTED;
        protected TextBox fldF112_PYCDCEILINGS_RETRO_TO_EP_NBR_TAR;
        protected TextBox fldT_SILENT_REVENUE;

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/26/2017 10:17:39 AM

        //#-----------------------------------------
        //# GetGridFieldObject Procedure.
        //#-----------------------------------------

        protected override void GetGridFieldObject(object DataListField, ref object CoreField, string Name)
        {

            try
            {
                switch (Name.ToUpper())
                {
                    case "FLDGRDF112_PYCDCEILINGS_EP_NBR":
                        fldF112_PYCDCEILINGS_EP_NBR = (TextBox)DataListField;
                        CoreField = fldF112_PYCDCEILINGS_EP_NBR;
                        fldF112_PYCDCEILINGS_EP_NBR.Bind(fleF112_PYCDCEILINGS);
                        break;
                    case "FLDGRDF191_EARNINGS_PERIOD_ICONST_DATE_PERIOD_END":
                        fldF191_EARNINGS_PERIOD_ICONST_DATE_PERIOD_END = (DateControl)DataListField;
                        CoreField = fldF191_EARNINGS_PERIOD_ICONST_DATE_PERIOD_END;
                        fldF191_EARNINGS_PERIOD_ICONST_DATE_PERIOD_END.Bind(fleF191_EARNINGS_PERIOD);
                        break;
                    case "FLDGRDF112_PYCDCEILINGS_DOC_PAY_CODE":
                        fldF112_PYCDCEILINGS_DOC_PAY_CODE = (TextBox)DataListField;
                        CoreField = fldF112_PYCDCEILINGS_DOC_PAY_CODE;
                        fldF112_PYCDCEILINGS_DOC_PAY_CODE.Bind(fleF112_PYCDCEILINGS);
                        break;
                    case "FLDGRDF112_PYCDCEILINGS_DOC_PAY_SUB_CODE":
                        fldF112_PYCDCEILINGS_DOC_PAY_SUB_CODE = (TextBox)DataListField;
                        CoreField = fldF112_PYCDCEILINGS_DOC_PAY_SUB_CODE;
                        fldF112_PYCDCEILINGS_DOC_PAY_SUB_CODE.Bind(fleF112_PYCDCEILINGS);
                        break;
                    case "FLDGRDF112_PYCDCEILINGS_DOC_YRLY_REQREV":
                        fldF112_PYCDCEILINGS_DOC_YRLY_REQREV = (TextBox)DataListField;

                        fldF112_PYCDCEILINGS_DOC_YRLY_REQREV.Edit -= fldF112_PYCDCEILINGS_DOC_YRLY_REQREV_Edit;
                        fldF112_PYCDCEILINGS_DOC_YRLY_REQREV.Edit += fldF112_PYCDCEILINGS_DOC_YRLY_REQREV_Edit;
                        CoreField = fldF112_PYCDCEILINGS_DOC_YRLY_REQREV;
                        fldF112_PYCDCEILINGS_DOC_YRLY_REQREV.Bind(fleF112_PYCDCEILINGS);
                        break;
                    case "FLDGRDF112_PYCDCEILINGS_DOC_YRLY_REQREV_ADJUSTED":
                        fldF112_PYCDCEILINGS_DOC_YRLY_REQREV_ADJUSTED = (TextBox)DataListField;
                        CoreField = fldF112_PYCDCEILINGS_DOC_YRLY_REQREV_ADJUSTED;
                        fldF112_PYCDCEILINGS_DOC_YRLY_REQREV_ADJUSTED.Bind(fleF112_PYCDCEILINGS);
                        break;
                    case "FLDGRDF112_PYCDCEILINGS_RETRO_TO_EP_NBR_REQ":
                        fldF112_PYCDCEILINGS_RETRO_TO_EP_NBR_REQ = (TextBox)DataListField;

                        fldF112_PYCDCEILINGS_RETRO_TO_EP_NBR_REQ.LookupOn -= fldF112_PYCDCEILINGS_RETRO_TO_EP_NBR_REQ_LookupOn;
                        fldF112_PYCDCEILINGS_RETRO_TO_EP_NBR_REQ.LookupOn += fldF112_PYCDCEILINGS_RETRO_TO_EP_NBR_REQ_LookupOn;

                        fldF112_PYCDCEILINGS_RETRO_TO_EP_NBR_REQ.Edit -= fldF112_PYCDCEILINGS_RETRO_TO_EP_NBR_REQ_Edit;
                        fldF112_PYCDCEILINGS_RETRO_TO_EP_NBR_REQ.Edit += fldF112_PYCDCEILINGS_RETRO_TO_EP_NBR_REQ_Edit;
                        CoreField = fldF112_PYCDCEILINGS_RETRO_TO_EP_NBR_REQ;
                        fldF112_PYCDCEILINGS_RETRO_TO_EP_NBR_REQ.Bind(fleF112_PYCDCEILINGS);
                        break;
                    case "FLDGRDF112_PYCDCEILINGS_DOC_YRLY_TARREV":
                        fldF112_PYCDCEILINGS_DOC_YRLY_TARREV = (TextBox)DataListField;

                        fldF112_PYCDCEILINGS_DOC_YRLY_TARREV.Edit -= fldF112_PYCDCEILINGS_DOC_YRLY_TARREV_Edit;
                        fldF112_PYCDCEILINGS_DOC_YRLY_TARREV.Edit += fldF112_PYCDCEILINGS_DOC_YRLY_TARREV_Edit;
                        CoreField = fldF112_PYCDCEILINGS_DOC_YRLY_TARREV;
                        fldF112_PYCDCEILINGS_DOC_YRLY_TARREV.Bind(fleF112_PYCDCEILINGS);
                        break;
                    case "FLDGRDF112_PYCDCEILINGS_DOC_YRLY_TARREV_ADJUSTED":
                        fldF112_PYCDCEILINGS_DOC_YRLY_TARREV_ADJUSTED = (TextBox)DataListField;
                        CoreField = fldF112_PYCDCEILINGS_DOC_YRLY_TARREV_ADJUSTED;
                        fldF112_PYCDCEILINGS_DOC_YRLY_TARREV_ADJUSTED.Bind(fleF112_PYCDCEILINGS);
                        break;
                    case "FLDGRDF112_PYCDCEILINGS_RETRO_TO_EP_NBR_TAR":
                        fldF112_PYCDCEILINGS_RETRO_TO_EP_NBR_TAR = (TextBox)DataListField;

                        fldF112_PYCDCEILINGS_RETRO_TO_EP_NBR_TAR.LookupOn -= fldF112_PYCDCEILINGS_RETRO_TO_EP_NBR_TAR_LookupOn;
                        fldF112_PYCDCEILINGS_RETRO_TO_EP_NBR_TAR.LookupOn += fldF112_PYCDCEILINGS_RETRO_TO_EP_NBR_TAR_LookupOn;

                        fldF112_PYCDCEILINGS_RETRO_TO_EP_NBR_TAR.Edit -= fldF112_PYCDCEILINGS_RETRO_TO_EP_NBR_TAR_Edit;
                        fldF112_PYCDCEILINGS_RETRO_TO_EP_NBR_TAR.Edit += fldF112_PYCDCEILINGS_RETRO_TO_EP_NBR_TAR_Edit;
                        CoreField = fldF112_PYCDCEILINGS_RETRO_TO_EP_NBR_TAR;
                        fldF112_PYCDCEILINGS_RETRO_TO_EP_NBR_TAR.Bind(fleF112_PYCDCEILINGS);
                        break;
                    case "FLDGRDT_SILENT_REVENUE":
                        fldT_SILENT_REVENUE = (TextBox)DataListField;
                        CoreField = fldT_SILENT_REVENUE;
                        fldT_SILENT_REVENUE.Bind(T_SILENT_REVENUE);
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
                dtlF112_PYCDCEILINGS.OccursWithFile = fleF112_PYCDCEILINGS;

            }
            catch (CustomApplicationException ex)
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
        //# Do not delete, modify or move it.  Updated: 5/26/2017 10:17:39 AM

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
            fleF112_PYCDCEILINGS.Transaction = m_trnTRANS_UPDATE;
            fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
            fleCONSTANTS_MSTR_REC_6.Transaction = m_trnTRANS_UPDATE;
            fleF020_DOCTOR_EXTRA.Transaction = m_trnTRANS_UPDATE;
            fleF112_PYCDCEILINGS_AUDIT.Transaction = m_trnTRANS_UPDATE;


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/26/2017 10:17:39 AM

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
                fleF112_PYCDCEILINGS.Dispose();
                fleF020_DOCTOR_MSTR.Dispose();
                fleCONSTANTS_MSTR_REC_6.Dispose();
                fleF191_EARNINGS_PERIOD.Dispose();
                fleF020_DOCTOR_EXTRA.Dispose();
                fleF112_PYCDCEILINGS_AUDIT.Dispose();


            }
            catch (CustomApplicationException ex)
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
        //# Do not delete, modify or move it.  Updated: 5/26/2017 10:17:39 AM



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



        private void fldF112_PYCDCEILINGS_RETRO_TO_EP_NBR_TAR_LookupOn()
        {

            try
            {
                StringBuilder strSQL = new StringBuilder(" WHERE ");
                strSQL.Append("     ").Append(fleF191_EARNINGS_PERIOD.ElementOwner("EP_NBR")).Append(" = ").Append((FieldText));

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




        private void fldF112_PYCDCEILINGS_RETRO_TO_EP_NBR_REQ_LookupOn()
        {

            try
            {
                StringBuilder strSQL = new StringBuilder(" WHERE ");
                strSQL.Append("     ").Append(fleF191_EARNINGS_PERIOD.ElementOwner("EP_NBR")).Append(" = ").Append((FieldText));

                fleF191_EARNINGS_PERIOD.GetData(strSQL.ToString(), GetDataOptions.IsOptional);
                if (!AccessOk)
                {
                    ErrorMessage("Error - Invalide Earnings Period.\a");
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


        private bool Internal_CALC_FINAL_COMPUTED_REVENUE()
        {


            try
            {

                T_DOC_YRLY_REVENUE_COMP1.Value = T_REVENUE_COMPUTED.Value + (QDesign.Round(T_YEARLY_REVENUE.Value / 12, 0, RoundOptionTypes.Near) * (12 - T_COUNTER_RECS_F112.Value + T_ADJUSTMENT.Value));
                T_DOC_YRLY_REVENUE_COMP2.Value = QDesign.PHMod(T_DOC_YRLY_REVENUE_COMP1.Value, 100);
                if (T_DOC_YRLY_REVENUE_COMP2.Value >= 50)
                {
                    T_DOC_YRLY_REVENUE_ERR.Value = 1;
                }
                else
                {
                    T_DOC_YRLY_REVENUE_ERR.Value = 0;
                }
                T_REVENUE_COMPUTED.Value = (QDesign.Floor(T_DOC_YRLY_REVENUE_COMP1.Value / 100) + T_DOC_YRLY_REVENUE_ERR.Value) * 100;

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


        private bool Internal_BUILD_COMPUTED_REVENUE()
        {


            try
            {

                T_DOC_YRLY_REVENUE_COMP1.Value = T_REVENUE_COMPUTED.Value + QDesign.Round(T_YEARLY_REVENUE.Value / 12, 0, RoundOptionTypes.Near);
                T_DOC_YRLY_REVENUE_COMP2.Value = QDesign.PHMod(T_DOC_YRLY_REVENUE_COMP1.Value, 100);
                if (T_DOC_YRLY_REVENUE_COMP2.Value >= 50)
                {
                    T_DOC_YRLY_REVENUE_ERR.Value = 1;
                }
                else
                {
                    T_DOC_YRLY_REVENUE_ERR.Value = 0;
                }
                T_REVENUE_COMPUTED.Value = (T_DOC_YRLY_REVENUE_COMP1.Value + T_DOC_YRLY_REVENUE_ERR.Value);

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


        private bool Internal_FINISH_COMP_REVENUE_TO_YEAREND()
        {


            try
            {

                if (QDesign.NULL(T_RETRO_TO_FLAG.Value) == QDesign.NULL("R") | QDesign.NULL(T_RETRO_TO_FLAG.Value) == QDesign.NULL("B"))
                {
                    T_YEARLY_REVENUE.Value = T_LAST_REVENUE_REQ.Value;
                    T_REVENUE_COMPUTED.Value = T_DOC_YRLY_REQREV_COMPUTED.Value;
                    H_REVENUE_TYPE.Value = "REQ";
                    Internal_CALC_FINAL_COMPUTED_REVENUE();
                    fleF020_DOCTOR_EXTRA.set_SetValue("DOC_YRLY_REQUIRE_REVENUE", T_REVENUE_COMPUTED.Value);
                }
                if (QDesign.NULL(T_RETRO_TO_FLAG.Value) == QDesign.NULL("T") | QDesign.NULL(T_RETRO_TO_FLAG.Value) == QDesign.NULL("B"))
                {
                    T_YEARLY_REVENUE.Value = T_LAST_REVENUE_TAR.Value;
                    T_REVENUE_COMPUTED.Value = T_DOC_YRLY_TARREV_COMPUTED.Value;
                    H_REVENUE_TYPE.Value = "TAR";
                    Internal_CALC_FINAL_COMPUTED_REVENUE();
                    fleF020_DOCTOR_EXTRA.set_SetValue("DOC_YRLY_TARGET_REVENUE", T_REVENUE_COMPUTED.Value);
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


        private bool Internal_RETRO_REVENUE()
        {


            try
            {

                if (QDesign.NULL(T_RETRO_TO_FLAG.Value) == QDesign.NULL("R") | QDesign.NULL(T_RETRO_TO_FLAG.Value) == QDesign.NULL("B"))
                {
                    fleF020_DOCTOR_EXTRA.set_SetValue("DOC_YRLY_REQUIRE_REVENUE", 0);
                }
                if (QDesign.NULL(T_RETRO_TO_FLAG.Value) == QDesign.NULL("T") | QDesign.NULL(T_RETRO_TO_FLAG.Value) == QDesign.NULL("B"))
                {
                    fleF020_DOCTOR_EXTRA.set_SetValue("DOC_YRLY_TARGET_REVENUE", 0);
                }
                T_DOC_YRLY_REQREV_COMPUTED.Value = 0;
                T_DOC_YRLY_TARREV_COMPUTED.Value = 0;
                while (fleF112_PYCDCEILINGS.For())
                {
                    if (QDesign.NULL(fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR")) != 0)
                    {
                        T_COUNTER_RECS_F112.Value = QDesign.PHMod(fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR"), 100);
                    }
                    if ((fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR") >= H_RETRO_TO_EP_NBR_REQ.Value | fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR") >= H_RETRO_TO_EP_NBR_TAR.Value) & Occurrence < QDesign.NULL(H_CURRENT_OCCURENCE.Value) & T_COUNTER_RECS_F112.Value <= 12)
                    {
                        if (QDesign.NULL(T_RETRO_TO_FLAG.Value) == QDesign.NULL("R") | QDesign.NULL(T_RETRO_TO_FLAG.Value) == QDesign.NULL("B"))
                        {
                            fleF112_PYCDCEILINGS.set_SetValue("DOC_YRLY_REQREV_ADJUSTED", fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_REQREV"));
                            fleF112_PYCDCEILINGS.set_SetValue("DOC_YRLY_REQREV", H_DOC_YRLY_REQREV.Value);
                            Display(ref fldF112_PYCDCEILINGS_DOC_YRLY_REQREV);
                            Display(ref fldF112_PYCDCEILINGS_DOC_YRLY_REQREV_ADJUSTED);
                        }
                        if (QDesign.NULL(T_RETRO_TO_FLAG.Value) == QDesign.NULL("T") | QDesign.NULL(T_RETRO_TO_FLAG.Value) == QDesign.NULL("B"))
                        {
                            fleF112_PYCDCEILINGS.set_SetValue("DOC_YRLY_TARREV_ADJUSTED", fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_TARREV"));
                            fleF112_PYCDCEILINGS.set_SetValue("DOC_YRLY_TARREV", H_DOC_YRLY_TARREV.Value);
                            Display(ref fldF112_PYCDCEILINGS_DOC_YRLY_TARREV);
                            Display(ref fldF112_PYCDCEILINGS_DOC_YRLY_TARREV_ADJUSTED);
                        }
                    }
                    if ((QDesign.NULL(T_RETRO_TO_FLAG.Value) == QDesign.NULL("R") | QDesign.NULL(T_RETRO_TO_FLAG.Value) == QDesign.NULL("B")) & (QDesign.NULL(fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR")) < QDesign.NULL(fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR"))) & (QDesign.NULL(fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR")) != 0))
                    {
                        T_REVENUE_COMPUTED.Value = T_DOC_YRLY_REQREV_COMPUTED.Value;
                        T_YEARLY_REVENUE.Value = fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_REQREV") * 100;
                        H_REVENUE_TYPE.Value = "REQ";
                        Internal_BUILD_COMPUTED_REVENUE();
                        T_DOC_YRLY_REQREV_COMPUTED.Value = T_REVENUE_COMPUTED.Value;
                        T_ADJUSTMENT.Value = 0;
                        Internal_CALC_FINAL_COMPUTED_REVENUE();
                        fleF112_PYCDCEILINGS.set_SetValue("DOC_YRLY_REQREV_COMPUTED", T_REVENUE_COMPUTED.Value);
                    }
                    if ((QDesign.NULL(T_RETRO_TO_FLAG.Value) == QDesign.NULL("T") | QDesign.NULL(T_RETRO_TO_FLAG.Value) == QDesign.NULL("B")) & (QDesign.NULL(fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR")) < QDesign.NULL(fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR"))) & (QDesign.NULL(fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR")) != 0))
                    {
                        T_REVENUE_COMPUTED.Value = T_DOC_YRLY_TARREV_COMPUTED.Value;
                        T_YEARLY_REVENUE.Value = fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_TARREV") * 100;
                        H_REVENUE_TYPE.Value = "TAR";
                        Internal_BUILD_COMPUTED_REVENUE();
                        T_DOC_YRLY_TARREV_COMPUTED.Value = T_REVENUE_COMPUTED.Value;
                        T_ADJUSTMENT.Value = 0;
                        Internal_CALC_FINAL_COMPUTED_REVENUE();
                        fleF112_PYCDCEILINGS.set_SetValue("DOC_YRLY_TARREV_COMPUTED", T_REVENUE_COMPUTED.Value);
                    }
                    if (QDesign.NULL(fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR")) == QDesign.NULL(fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR")))
                    {
                        if (QDesign.NULL(T_RETRO_TO_FLAG.Value) == QDesign.NULL("R") | QDesign.NULL(T_RETRO_TO_FLAG.Value) == QDesign.NULL("B"))
                        {
                            fleF020_DOCTOR_EXTRA.set_SetValue("DOC_YTDREQ", T_DOC_YRLY_REQREV_COMPUTED.Value);
                            H_REVENUE_TYPE.Value = "REQ";
                            T_ADJUSTMENT.Value = 0;
                            T_REVENUE_COMPUTED.Value = T_DOC_YRLY_REQREV_COMPUTED.Value;
                            T_YEARLY_REVENUE.Value = fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_REQREV") * 100;
                            Internal_CALC_FINAL_COMPUTED_REVENUE();
                            fleF112_PYCDCEILINGS.set_SetValue("DOC_YRLY_REQREV_COMPUTED", T_REVENUE_COMPUTED.Value);
                            T_REVENUE_COMPUTED.Value = T_DOC_YRLY_REQREV_COMPUTED.Value;
                        }
                        if (QDesign.NULL(T_RETRO_TO_FLAG.Value) == QDesign.NULL("T") | QDesign.NULL(T_RETRO_TO_FLAG.Value) == QDesign.NULL("B"))
                        {
                            fleF020_DOCTOR_EXTRA.set_SetValue("DOC_YTDTAR", T_DOC_YRLY_TARREV_COMPUTED.Value);
                            H_REVENUE_TYPE.Value = "TAR";
                            T_ADJUSTMENT.Value = 0;
                            T_REVENUE_COMPUTED.Value = T_DOC_YRLY_TARREV_COMPUTED.Value;
                            T_YEARLY_REVENUE.Value = fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_TARREV") * 100;
                            Internal_CALC_FINAL_COMPUTED_REVENUE();
                            fleF112_PYCDCEILINGS.set_SetValue("DOC_YRLY_TARREV_COMPUTED", T_REVENUE_COMPUTED.Value);
                            T_REVENUE_COMPUTED.Value = T_DOC_YRLY_TARREV_COMPUTED.Value;
                        }
                    }
                    if (QDesign.NULL(fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR")) != 0)
                    {
                        T_COUNTER_RECS_F112.Value = QDesign.PHMod(fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR"), 100);
                        T_LAST_REVENUE_REQ.Value = fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_REQREV") * 100;
                        T_LAST_REVENUE_TAR.Value = fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_TARREV") * 100;
                    }
                }
                T_ADJUSTMENT.Value = 1;
                Internal_FINISH_COMP_REVENUE_TO_YEAREND();

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


        private bool Internal_CALC_TRUE_REVENUE()
        {


            try
            {

                T_DOC_YRLY_REQREV_COMPUTED.Value = 0;
                T_DOC_YRLY_TARREV_COMPUTED.Value = 0;
                T_LAST_EP_NBR.Value = 1;
                T_LAST_REVENUE_REQ.Value = 0;
                T_LAST_REVENUE_TAR.Value = 0;
                while (fleF112_PYCDCEILINGS.For())
                {
                    T_COUNTER_RECS_F112.Value = QDesign.PHMod(fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR"), 100);
                    if (0 < QDesign.NULL((T_COUNTER_RECS_F112.Value - T_LAST_EP_NBR.Value)))
                    {
                        T_DOC_YRLY_REQREV_COMPUTED.Value = T_DOC_YRLY_REQREV_COMPUTED.Value + ((T_LAST_REVENUE_REQ.Value / 12) * (T_COUNTER_RECS_F112.Value - T_LAST_EP_NBR.Value));
                        T_DOC_YRLY_TARREV_COMPUTED.Value = T_DOC_YRLY_TARREV_COMPUTED.Value + ((T_LAST_REVENUE_TAR.Value / 12) * (T_COUNTER_RECS_F112.Value - T_LAST_EP_NBR.Value));
                    }
                    T_LAST_REVENUE_REQ.Value = fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_REQREV") * 100;
                    T_LAST_REVENUE_TAR.Value = fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_TARREV") * 100;
                    T_LAST_EP_NBR.Value = T_COUNTER_RECS_F112.Value;
                }
                T_DOC_YRLY_REQREV_COMPUTED.Value = T_DOC_YRLY_REQREV_COMPUTED.Value + QDesign.Round((12 - T_LAST_EP_NBR.Value + 1) * (T_LAST_REVENUE_REQ.Value / 12), 0, RoundOptionTypes.Near);
                fleF020_DOCTOR_EXTRA.set_SetValue("DOC_YRLY_REQUIRE_REVENUE", T_DOC_YRLY_REQREV_COMPUTED.Value);
                T_DOC_YRLY_TARREV_COMPUTED.Value = T_DOC_YRLY_TARREV_COMPUTED.Value + QDesign.Round((12 - T_LAST_EP_NBR.Value + 1) * (T_LAST_REVENUE_TAR.Value / 12), 0, RoundOptionTypes.Near);
                fleF020_DOCTOR_EXTRA.set_SetValue("DOC_YRLY_TARGET_REVENUE", T_DOC_YRLY_TARREV_COMPUTED.Value);

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

        //#CORE_BEGIN_INCLUDE: SAVEF112AUDIT"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/26/2017 10:17:39 AM


        private bool Internal_SAVEF112AUDIT()
        {


            try
            {

                A_DOC_NBR.Value = fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR");
                A_EP_NBR.Value = fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR");
                A_FACTOR.Value = fleF112_PYCDCEILINGS.GetDecimalValue("FACTOR");
                A_DOC_PAY_CODE.Value = fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_CODE");
                A_DOC_PAY_SUB_CODE.Value = fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_SUB_CODE");
                A_RETRO_TO_EP_NBR.Value = fleF112_PYCDCEILINGS.GetDecimalValue("RETRO_TO_EP_NBR");
                A_DOC_YRLY_CEILING.Value = fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEILING");
                A_DOC_YRLY_CEILING_ADJUSTED.Value = fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEILING_ADJUSTED");
                A_DOC_YRLY_CEILING_COMPUTED.Value = fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEILING_COMPUTED");
                A_DOC_YRLY_EXPENSE.Value = fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_EXPENSE");
                A_DOC_YRLY_EXPENSE_ADJUSTED.Value = fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_EXPENSE_ADJUSTED");
                A_DOC_YRLY_EXPENSE_COMPUTED.Value = fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_EXPENSE_COMPUTED");
                A_DOC_YRLY_EXPN_ALLOC_PERS.Value = fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_EXPN_ALLOC_PERS");
                A_DOC_YRLY_CEIL_GUAR.Value = fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEIL_GUAR");
                A_DOC_YRLY_CEILING_GUAR_PERC.Value = fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEILING_GUAR_PERC");
                A_DOC_RMA_EXPENSE_PERCENT_REG.Value = fleF112_PYCDCEILINGS.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_REG");
                A_DOC_RMA_EXPENSE_PERCENT_MISC.Value = fleF112_PYCDCEILINGS.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_MISC");
                A_DOC_DEPT_EXPENSE_PERCENT_REG.Value = fleF112_PYCDCEILINGS.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_REG");
                A_DOC_DEPT_EXPENSE_PERCENT_MISC.Value = fleF112_PYCDCEILINGS.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_MISC");
                A_DOC_YRLY_REQREV.Value = fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_REQREV");
                A_DOC_YRLY_REQREV_ADJUSTED.Value = fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_REQREV_ADJUSTED");
                A_DOC_YRLY_REQREV_COMPUTED.Value = fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_REQREV_COMPUTED");
                A_DOC_YRLY_TARREV.Value = fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_TARREV");
                A_DOC_YRLY_TARREV_ADJUSTED.Value = fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_TARREV_ADJUSTED");
                A_DOC_YRLY_TARREV_COMPUTED.Value = fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_TARREV_COMPUTED");
                A_RETRO_TO_EP_NBR_REQ.Value = fleF112_PYCDCEILINGS.GetDecimalValue("RETRO_TO_EP_NBR_REQ");
                A_RETRO_TO_EP_NBR_TAR.Value = fleF112_PYCDCEILINGS.GetDecimalValue("RETRO_TO_EP_NBR_TAR");

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

        //#CORE_END_INCLUDE: SAVEF112AUDIT"


        //#CORE_BEGIN_INCLUDE: CREATEF112AUDIT"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/26/2017 10:17:39 AM


        private bool Internal_CREATEF112AUDIT()
        {


            try
            {

                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("DOC_NBR", A_DOC_NBR.Value);
                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("EP_NBR", A_EP_NBR.Value);
                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("FACTOR", A_FACTOR.Value);
                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("DOC_PAY_CODE", A_DOC_PAY_CODE.Value);
                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("DOC_PAY_SUB_CODE", A_DOC_PAY_SUB_CODE.Value);
                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("RETRO_TO_EP_NBR", A_RETRO_TO_EP_NBR.Value);
                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("DOC_YRLY_CEILING", A_DOC_YRLY_CEILING.Value);
                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("DOC_YRLY_CEILING_ADJUSTED", A_DOC_YRLY_CEILING_ADJUSTED.Value);
                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("DOC_YRLY_CEILING_COMPUTED", A_DOC_YRLY_CEILING_COMPUTED.Value);
                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("DOC_YRLY_EXPENSE", A_DOC_YRLY_EXPENSE.Value);
                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("DOC_YRLY_EXPENSE_ADJUSTED", A_DOC_YRLY_EXPENSE_ADJUSTED.Value);
                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("DOC_YRLY_EXPENSE_COMPUTED", A_DOC_YRLY_EXPENSE_COMPUTED.Value);
                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("DOC_YRLY_EXPN_ALLOC_PERS", A_DOC_YRLY_EXPN_ALLOC_PERS.Value);
                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("DOC_YRLY_CEIL_GUAR", A_DOC_YRLY_CEIL_GUAR.Value);
                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("DOC_YRLY_CEILING_GUAR_PERC", A_DOC_YRLY_CEILING_GUAR_PERC.Value);
                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("DOC_RMA_EXPENSE_PERCENT_REG", A_DOC_RMA_EXPENSE_PERCENT_REG.Value);
                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("DOC_RMA_EXPENSE_PERCENT_MISC", A_DOC_RMA_EXPENSE_PERCENT_MISC.Value);
                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_REG", A_DOC_DEPT_EXPENSE_PERCENT_REG.Value);
                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_MISC", A_DOC_DEPT_EXPENSE_PERCENT_MISC.Value);
                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("DOC_YRLY_REQREV", A_DOC_YRLY_REQREV.Value);
                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("DOC_YRLY_REQREV_ADJUSTED", A_DOC_YRLY_REQREV_ADJUSTED.Value);
                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("DOC_YRLY_REQREV_COMPUTED", A_DOC_YRLY_REQREV_COMPUTED.Value);
                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("DOC_YRLY_TARREV", A_DOC_YRLY_TARREV.Value);
                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("DOC_YRLY_TARREV_ADJUSTED", A_DOC_YRLY_TARREV_ADJUSTED.Value);
                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("DOC_YRLY_TARREV_COMPUTED", A_DOC_YRLY_TARREV_COMPUTED.Value);
                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("RETRO_TO_EP_NBR_REQ", A_RETRO_TO_EP_NBR_REQ.Value);
                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("RETRO_TO_EP_NBR_TAR", A_RETRO_TO_EP_NBR_TAR.Value);

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


        private bool Internal_CREATEF112AUDIT_ADD()
        {


            try
            {

                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("DOC_NBR", fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));
                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("EP_NBR", fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR"));
                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("FACTOR", fleF112_PYCDCEILINGS.GetDecimalValue("FACTOR"));
                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("DOC_PAY_CODE", fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_CODE"));
                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("DOC_PAY_SUB_CODE", fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_SUB_CODE"));
                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("RETRO_TO_EP_NBR", fleF112_PYCDCEILINGS.GetDecimalValue("RETRO_TO_EP_NBR"));
                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("DOC_YRLY_CEILING", fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEILING"));
                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("DOC_YRLY_CEILING_ADJUSTED", fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEILING_ADJUSTED"));
                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("DOC_YRLY_CEILING_COMPUTED", fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEILING_COMPUTED"));
                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("DOC_YRLY_EXPENSE", fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_EXPENSE"));
                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("DOC_YRLY_EXPENSE_ADJUSTED", fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_EXPENSE_ADJUSTED"));
                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("DOC_YRLY_EXPENSE_COMPUTED", fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_EXPENSE_COMPUTED"));
                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("DOC_YRLY_EXPN_ALLOC_PERS", fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_EXPN_ALLOC_PERS"));
                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("DOC_YRLY_CEIL_GUAR", fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEIL_GUAR"));
                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("DOC_YRLY_CEILING_GUAR_PERC", fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEILING_GUAR_PERC"));
                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("DOC_RMA_EXPENSE_PERCENT_REG", fleF112_PYCDCEILINGS.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_REG"));
                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("DOC_RMA_EXPENSE_PERCENT_MISC", fleF112_PYCDCEILINGS.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_MISC"));
                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_REG", fleF112_PYCDCEILINGS.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_REG"));
                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_MISC", fleF112_PYCDCEILINGS.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_MISC"));
                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("DOC_YRLY_REQREV", fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_REQREV"));
                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("DOC_YRLY_REQREV_ADJUSTED", fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_REQREV_ADJUSTED"));
                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("DOC_YRLY_REQREV_COMPUTED", fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_REQREV_COMPUTED"));
                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("DOC_YRLY_TARREV", fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_TARREV"));
                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("DOC_YRLY_TARREV_ADJUSTED", fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_TARREV_ADJUSTED"));
                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("DOC_YRLY_TARREV_COMPUTED", fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_TARREV_COMPUTED"));
                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("RETRO_TO_EP_NBR_REQ", fleF112_PYCDCEILINGS.GetDecimalValue("RETRO_TO_EP_NBR_REQ"));
                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("RETRO_TO_EP_NBR_TAR", fleF112_PYCDCEILINGS.GetDecimalValue("RETRO_TO_EP_NBR_TAR"));

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

        //#CORE_END_INCLUDE: CREATEF112AUDIT"



        protected override bool PostFind()
        {


            try
            {

                // --> GET F020_DOCTOR_EXTRA <--
                m_strWhere = new StringBuilder(" WHERE ");
                m_strWhere.Append(" ").Append(fleF020_DOCTOR_EXTRA.ElementOwner("DOC_NBR")).Append(" = ");
                m_strWhere.Append(Common.StringToField(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")));

                fleF020_DOCTOR_EXTRA.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                // --> End GET F020_DOCTOR_EXTRA <--
                T_RETRO_TO_FLAG.Value = " ";
                while (fleF112_PYCDCEILINGS.For())
                {
                    Internal_SAVEF112AUDIT();
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



        private void fldF112_PYCDCEILINGS_DOC_YRLY_REQREV_Edit()
        {

            try
            {

                if (QDesign.NULL(OldValue(fleF112_PYCDCEILINGS.ElementOwner("DOC_YRLY_REQREV"), fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_REQREV"))) != QDesign.NULL(fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_REQREV")) | (NewRecord() & QDesign.NULL(fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_REQREV")) == 0))
                {
                    T_RETRO_TO_FLAG.Value = "R";
                    fleF112_PYCDCEILINGS.set_SetValue("DOC_YRLY_REQREV_ADJUSTED", OldValue(fleF112_PYCDCEILINGS.ElementOwner("DOC_YRLY_REQREV"), fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_REQREV")));
                    Display(ref fldF112_PYCDCEILINGS_DOC_YRLY_REQREV_ADJUSTED);
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



        private void fldF112_PYCDCEILINGS_DOC_YRLY_TARREV_Edit()
        {

            try
            {

                if (QDesign.NULL(OldValue(fleF112_PYCDCEILINGS.ElementOwner("DOC_YRLY_TARREV"), fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_TARREV"))) != QDesign.NULL(fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_TARREV")) | (NewRecord() & QDesign.NULL(fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_TARREV")) == 0))
                {
                    if (QDesign.NULL(T_RETRO_TO_FLAG.Value) == QDesign.NULL(" "))
                    {
                        T_RETRO_TO_FLAG.Value = "T";
                    }
                    else
                    {
                        T_RETRO_TO_FLAG.Value = "B";
                    }
                    fleF112_PYCDCEILINGS.set_SetValue("DOC_YRLY_TARREV_ADJUSTED", OldValue(fleF112_PYCDCEILINGS.ElementOwner("DOC_YRLY_TARREV"), fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_TARREV")));
                    Display(ref fldF112_PYCDCEILINGS_DOC_YRLY_TARREV_ADJUSTED);
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



        private void fldF112_PYCDCEILINGS_RETRO_TO_EP_NBR_REQ_Edit()
        {

            try
            {

                if (QDesign.NULL(fleF112_PYCDCEILINGS.GetDecimalValue("RETRO_TO_EP_NBR_REQ")) > QDesign.NULL(fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR")))
                {
                    ErrorMessage("Error - Can`t be Retroactive to FUTURE E/P.\a");
                }
                if (QDesign.NULL(fleF112_PYCDCEILINGS.GetDecimalValue("RETRO_TO_EP_NBR_REQ")) < QDesign.NULL(fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR")))
                {
                    Warning("*W* Must be Retroactive from CURRENT EP.\a");
                }
                T_YY_RETRO.Value = (QDesign.Substring(QDesign.ASCII(fleF112_PYCDCEILINGS.GetDecimalValue("RETRO_TO_EP_NBR_REQ"), 6), 1, 4));
                T_YY_FISCAL.Value = (QDesign.Substring(QDesign.ASCII(fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR"), 6), 1, 4));
                if (QDesign.NULL(T_YY_RETRO.Value) != QDesign.NULL(T_YY_FISCAL.Value))
                {
                    ErrorMessage("Error - Must be Retroactive within CURRENT YEAR.\a");
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



        private void fldF112_PYCDCEILINGS_RETRO_TO_EP_NBR_TAR_Edit()
        {

            try
            {

                if (QDesign.NULL(fleF112_PYCDCEILINGS.GetDecimalValue("RETRO_TO_EP_NBR_TAR")) > QDesign.NULL(fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR")))
                {
                    ErrorMessage("Error - Can`t be Retroactive to FUTURE E/P.\a");
                }
                if (QDesign.NULL(fleF112_PYCDCEILINGS.GetDecimalValue("RETRO_TO_EP_NBR_TAR")) < QDesign.NULL(fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR")))
                {
                    Warning("*W* Must be Retroactive from CURRENT EP.\a");
                }
                T_YY_RETRO.Value = (QDesign.Substring(QDesign.ASCII(fleF112_PYCDCEILINGS.GetDecimalValue("RETRO_TO_EP_NBR_TAR"), 6), 1, 4));
                T_YY_FISCAL.Value = (QDesign.Substring(QDesign.ASCII(fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR"), 6), 1, 4));
                if (QDesign.NULL(T_YY_RETRO.Value) != QDesign.NULL(T_YY_FISCAL.Value))
                {
                    ErrorMessage("Error - Must be Retroactive within CURRENT YEAR.\a");
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



        private void fldT_SILENT_REVENUE_Process()
        {

            try
            {

                if (QDesign.NULL(fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR")) != 0)
                {
                    H_DOC_YRLY_REQREV.Value = fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_REQREV");
                    H_DOC_YRLY_TARREV.Value = fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_TARREV");
                    H_CURRENT_EP.Value = fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR");
                    H_CURRENT_OCCURENCE.Value = Occurrence;
                    if (QDesign.NULL(fleF112_PYCDCEILINGS.GetDecimalValue("RETRO_TO_EP_NBR_REQ")) != 0)
                    {
                        H_RETRO_TO_EP_NBR_REQ.Value = fleF112_PYCDCEILINGS.GetDecimalValue("RETRO_TO_EP_NBR_REQ");
                    }
                    else
                    {
                        H_RETRO_TO_EP_NBR_REQ.Value = fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR");
                    }
                    if (QDesign.NULL(fleF112_PYCDCEILINGS.GetDecimalValue("RETRO_TO_EP_NBR_TAR")) != 0)
                    {
                        H_RETRO_TO_EP_NBR_TAR.Value = fleF112_PYCDCEILINGS.GetDecimalValue("RETRO_TO_EP_NBR_TAR");
                    }
                    else
                    {
                        H_RETRO_TO_EP_NBR_TAR.Value = fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR");
                    }
                    Internal_RETRO_REVENUE();
                    Internal_CALC_TRUE_REVENUE();
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


        protected override bool PreUpdate()
        {


            try
            {

                fleF020_DOCTOR_EXTRA.set_SetValue("DOC_NBR", fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR"));
                fleF020_DOCTOR_EXTRA.PutData();
                while (fleF112_PYCDCEILINGS.For())
                {
                    if (fleF112_PYCDCEILINGS.NewRecord)
                    {
                        Internal_CREATEF112AUDIT_ADD();
                        fleF112_PYCDCEILINGS_AUDIT.set_SetValue("LAST_MOD_FLAG", "A");
                        fleF112_PYCDCEILINGS_AUDIT.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));
                        fleF112_PYCDCEILINGS_AUDIT.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);
                        fleF112_PYCDCEILINGS_AUDIT.set_SetValue("LAST_MOD_USER_ID", QDesign.RTrim(UserID) + "-d112a-A");
                        fleF112_PYCDCEILINGS_AUDIT.PutData();
                    }
                    else
                    {
                        if (ChangeMode & fleF112_PYCDCEILINGS.DeletedRecord)
                        {
                            Internal_CREATEF112AUDIT();
                            fleF112_PYCDCEILINGS_AUDIT.set_SetValue("LAST_MOD_FLAG", "D");
                            fleF112_PYCDCEILINGS_AUDIT.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));
                            fleF112_PYCDCEILINGS_AUDIT.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);
                            fleF112_PYCDCEILINGS_AUDIT.set_SetValue("LAST_MOD_USER_ID", QDesign.RTrim(UserID) + "-d112a-D");
                            fleF112_PYCDCEILINGS_AUDIT.PutData();
                        }
                        else
                        {
                            if (ChangeMode & fleF112_PYCDCEILINGS.AlteredRecord)
                            {
                                Internal_CREATEF112AUDIT();
                                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("LAST_MOD_FLAG", "C");
                                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));
                                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);
                                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("LAST_MOD_USER_ID", QDesign.RTrim(UserID) + "-d112a-1");
                                fleF112_PYCDCEILINGS_AUDIT.PutData(true);
                                Internal_CREATEF112AUDIT_ADD();
                                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("LAST_MOD_FLAG", "C");
                                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));
                                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);
                                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("LAST_MOD_USER_ID", QDesign.RTrim(UserID) + "-d112a-2");
                                fleF112_PYCDCEILINGS_AUDIT.PutData();
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




        protected override bool Find()
        {


            try
            {
                bool blnAddWhere = true;
                while (fleF112_PYCDCEILINGS.ForMissing())
                {
                    m_strWhere = new StringBuilder(GetWhereCondition(fleF112_PYCDCEILINGS.ElementOwner("DOC_NBR"), W_DOC_NBR.Value, ref blnAddWhere));
                    fleF112_PYCDCEILINGS.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
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
        //# Append Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/26/2017 10:17:39 AM
        //#-----------------------------------------
        protected override bool Append()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/26/2017 10:17:39 AM
                Display(ref fldF112_PYCDCEILINGS_EP_NBR);
                Display(ref fldF191_EARNINGS_PERIOD_ICONST_DATE_PERIOD_END);
                Display(ref fldF112_PYCDCEILINGS_DOC_PAY_CODE);
                Display(ref fldF112_PYCDCEILINGS_DOC_PAY_SUB_CODE);
                Accept(ref fldF112_PYCDCEILINGS_DOC_YRLY_REQREV);
                Display(ref fldF112_PYCDCEILINGS_DOC_YRLY_REQREV_ADJUSTED);
                Accept(ref fldF112_PYCDCEILINGS_RETRO_TO_EP_NBR_REQ);
                Accept(ref fldF112_PYCDCEILINGS_DOC_YRLY_TARREV);
                Display(ref fldF112_PYCDCEILINGS_DOC_YRLY_TARREV_ADJUSTED);
                Accept(ref fldF112_PYCDCEILINGS_RETRO_TO_EP_NBR_TAR);
                Edit(ref fldT_SILENT_REVENUE);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/26/2017 10:17:39 AM
        //#-----------------------------------------
        protected override bool Update()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/26/2017 10:17:39 AM
                fleF020_DOCTOR_MSTR.PutData();
                while (fleF112_PYCDCEILINGS.For())
                {
                    fleF112_PYCDCEILINGS.PutData();
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
        //# dtlF112_PYCDCEILINGS_EditClick Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/26/2017 10:17:39 AM
        //#-----------------------------------------
        private void dtlF112_PYCDCEILINGS_EditClick(DataList source, GridButtonEventArgs GridButtonEventArgs)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/26/2017 10:17:39 AM
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/26/2017 10:17:39 AM
        //#-----------------------------------------
        private void dsrDesigner_01_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/26/2017 10:17:39 AM
                Display(ref fldF112_PYCDCEILINGS_EP_NBR);
                Display(ref fldF191_EARNINGS_PERIOD_ICONST_DATE_PERIOD_END);
                Display(ref fldF112_PYCDCEILINGS_DOC_PAY_CODE);
                Display(ref fldF112_PYCDCEILINGS_DOC_PAY_SUB_CODE);
                Accept(ref fldF112_PYCDCEILINGS_DOC_YRLY_REQREV);
                Display(ref fldF112_PYCDCEILINGS_DOC_YRLY_REQREV_ADJUSTED);
                Accept(ref fldF112_PYCDCEILINGS_RETRO_TO_EP_NBR_REQ);
                Accept(ref fldF112_PYCDCEILINGS_DOC_YRLY_TARREV);
                Display(ref fldF112_PYCDCEILINGS_DOC_YRLY_TARREV_ADJUSTED);
                Accept(ref fldF112_PYCDCEILINGS_RETRO_TO_EP_NBR_TAR);
                Edit(ref fldT_SILENT_REVENUE);
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

