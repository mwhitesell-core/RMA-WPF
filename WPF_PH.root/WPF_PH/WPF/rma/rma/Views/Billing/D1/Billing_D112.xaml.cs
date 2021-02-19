
#region "Screen Comments"

// #field and auto gen of ADJCEA trans. ;
// 92/JUL/08  ____   B.E.     - COMPUTED Ceilings now allow decimals - don`t divide calc by 100
// 94/JAN/20         M.C.     - Modify the selection criteria just
// to pick up records that have the same
// year
// - DOC-PAY-SUB-CODE is required if DOC-
// PAY-CODE is `4`
// 94/DEC/16          B.E.     - changed calculation of YTDCEA to NOT
// include the CURRENT EP in the YTD calculation.
// 95/MAY/25  M.C.  - MODIFY EDIT PROCEDURE OF DOC-YRLY-CEILING
// AND DOC-YRLY-EXPENSE FOR 0 VALUE
// 95/MAY/29  M.C.  - MODIFY THE FORMULA OF T-CEILING-
// COMPUTED IN CALC-FINAL-COMPUTED-
// CEILING PROCEDURE  FOR DOLLAR VALUE
// ONLY AND ROUNDING
// 95/MAY/30  M.C.  - IF EXPENSE AMOUNT HAS CHANGED, CHANGE
// THE TRANSACTION `CEIEXP`, `TOTEXP`,
// `INCEXP` IN F119-DOCTOR-YTD
// 95/JUN/08  M.C.     - ADD THE SILENT FIELD `T-SILENT-CEILING`
// AS PART OF THE CLUSTER.  IT WILL
// PERFORM THE CALCULATION OF BOTH
// EARNINGS/EXPENSE CEILINGS EITHER THE
// RETRO TO EP NBR HAS ENTERED OR NOT
// - CALCULATE THE MONTHLY COMPUTED ANNUAL
// EARNINGS/EXPENSE CEILINGS OF F112
// - CALCULATE/DISPLAY THE CURRENT ANNUAL
// EARNINGS/EXPENSE CEILINGS IN F020
// PROPERLY
// - CHANGE FROM 14 TO 13 FOR THE CLUSTER
// ON F112 FILE
// 95/AUG/04  M.C.  - CALCULATE THE ANNUAL EARNINGS/EXPENSE
// PROPERLY FOR ADVANCE CEILING ENTRIES
// 95/NOV/07          M.C.     - DO NOT REQUIRE TO RECEIVE EP-NBR
// NO SELECTION IS REQUIRED TO F112 FILE
// 96/JAN/23  M.C.  - TAKE OUT MORE DESIGNER PROCEDURE
// 1999/Jan/20  S.B.  - FIX DISPLAYS AND ALIGNMENTS FOR Y2K.
// 1999/Apr/20  S.B.  - Altered t-yy-ep, t-yy-fiscal, and
// t-yy-retro to use the centuary.
// 1999/Jun/07   S.B.     - Altered the call to scrtitle.use and
// stdhilite.use to be called from $use
// instead of src.
// - Removed the call to secfile.use because
// it was not doing anything.
// 2003/nov/10 b.e.      - alpha doctor nbr
// 2006/apr/17 b.e. - adjust display of 3 ceiling fields to allow 1M $
// 2014/jun/10 MC1       - add f112-pycdceilings-audit to capture before change records
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

    partial class Billing_D112 : BasePage
    {

        #region " Form Designer Generated Code "





        public Billing_D112()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "D112";

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
           
            dtlF112_PYCDCEILINGS.EditClick += dtlF112_PYCDCEILINGS_EditClick;
            base.Page_Load();

            // TODO: If any DESIGNER procedures function on occurring FILES or TEMPORARIES, set the grid's AllowSelectRowButton property to TRUE.



            // TODO: The following elements have Input/Output Scaling defined in the Dictionary or Screen.  Manual steps may be required:
            //       F020_DOCTOR_MSTR.DOC_YRLY_CEILING_COMPUTED InputScale: 2 OutputScale: 0
            //       F020_DOCTOR_MSTR.DOC_YRLY_EXPENSE_COMPUTED InputScale: 2 OutputScale: 0
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
            T_YY_EP = new CoreCharacter("T_YY_EP", 4, this, Common.cEmptyString);
            T_YY_FISCAL = new CoreCharacter("T_YY_FISCAL", 4, this, Common.cEmptyString);
            T_YY_RETRO = new CoreCharacter("T_YY_RETRO", 4, this, Common.cEmptyString);
            T_ADJUSTMENT = new CoreDecimal("T_ADJUSTMENT", 6, this);
            T_COUNTER_RECS_F112 = new CoreDecimal("T_COUNTER_RECS_F112", 6, this);
            T_LAST_CEILING_EAR = new CoreDecimal("T_LAST_CEILING_EAR", 6, this);
            T_LAST_CEILING_EXP = new CoreDecimal("T_LAST_CEILING_EXP", 6, this);
            H_DOC_YRLY_CEILING = new CoreDecimal("H_DOC_YRLY_CEILING", 6, this);
            H_DOC_YRLY_EXPENSE = new CoreDecimal("H_DOC_YRLY_EXPENSE", 6, this);
            H_RETRO_TO_EP_NBR = new CoreDecimal("H_RETRO_TO_EP_NBR", 6, this);
            H_CURRENT_OCCURENCE = new CoreDecimal("H_CURRENT_OCCURENCE", 6, this);
            H_CURRENT_EP = new CoreDecimal("H_CURRENT_EP", 6, this);
            H_CEILING_TYPE = new CoreCharacter("H_CEILING_TYPE", 3, this, Common.cEmptyString);
            H_ALLOCATION_PERIODS = new CoreDecimal("H_ALLOCATION_PERIODS", 6, this);
            T_ALLOC_PERS = new CoreDecimal("T_ALLOC_PERS", 6, this);
            W_DOC_NBR = new CoreCharacter("W_DOC_NBR", 3, this, Common.cEmptyString);
            X_SRCH_CODE = new CoreCharacter("X_SRCH_CODE", 6, this, Common.cEmptyString);
            T_DOC_YRLY_CEILING_COMP1 = new CoreDecimal("T_DOC_YRLY_CEILING_COMP1", 6, this);
            T_DOC_YRLY_CEILING_COMP2 = new CoreDecimal("T_DOC_YRLY_CEILING_COMP2", 6, this);
            T_DOC_YRLY_CEILING_ERR = new CoreDecimal("T_DOC_YRLY_CEILING_ERR", 6, this);
            T_DOC_YRLY_CEILING_COMPUTED = new CoreDecimal("T_DOC_YRLY_CEILING_COMPUTED", 6, this);
            T_DOC_YRLY_EXPENSE_COMPUTED = new CoreDecimal("T_DOC_YRLY_EXPENSE_COMPUTED", 6, this);
            T_YEARLY_CEILING = new CoreDecimal("T_YEARLY_CEILING", 6, this);
            T_CEILING_COMPUTED = new CoreDecimal("T_CEILING_COMPUTED", 6, this);
            T_RETRO_TO_FLAG = new CoreCharacter("T_RETRO_TO_FLAG", 1, this, Common.cEmptyString);
            T_LAST_EP_NBR = new CoreDecimal("T_LAST_EP_NBR", 6, this);
            T_SILENT_CEILING = new CoreDecimal("T_SILENT_CEILING", 6, this);
            T_YTDCEX_DIFF = new CoreDecimal("T_YTDCEX_DIFF", 6, this);
            fleF112_PYCDCEILINGS = new SqlFileObject(this, FileTypes.Primary, 13, "INDEXED", "F112_PYCDCEILINGS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF112_PYCDCEILINGS_AUDIT = new SqlFileObject(this, FileTypes.Designer, fleF112_PYCDCEILINGS, "SEQUENTIAL", "F112_PYCDCEILINGS_AUDIT", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SequentialDataBase);
            fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Master, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleCONSTANTS_MSTR_REC_6 = new SqlFileObject(this, FileTypes.Designer, 0, "INDEXED", "CONSTANTS_MSTR_REC_6", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF191_EARNINGS_PERIOD = new SqlFileObject(this, FileTypes.Reference, 0, "INDEXED", "F191_EARNINGS_PERIOD", "", false, false, false, 0, "m_cnnQUERY");
            fleF119_DOCTOR_YTD = new SqlFileObject(this, FileTypes.Designer, 0, "INDEXED", "F119_DOCTOR_YTD", "", false, false, false, 0, "m_trnTRANS_UPDATE");
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
            dsrDesigner_01.Click -= dsrDesigner_01_Click;
            dtlF112_PYCDCEILINGS.EditClick -= dtlF112_PYCDCEILINGS_EditClick;
           


        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private SqlConnection m_cnnQUERY = new SqlConnection();
        private SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
        private SqlTransaction m_trnTRANS_UPDATE;
        private CoreCharacter T_YY_EP;
        private CoreCharacter T_YY_FISCAL;
        private CoreCharacter T_YY_RETRO;
        private CoreDecimal T_ADJUSTMENT;
        private CoreDecimal T_COUNTER_RECS_F112;
        private CoreDecimal T_LAST_CEILING_EAR;
        private CoreDecimal T_LAST_CEILING_EXP;
        private CoreDecimal H_DOC_YRLY_CEILING;
        private CoreDecimal H_DOC_YRLY_EXPENSE;
        private CoreDecimal H_RETRO_TO_EP_NBR;
        private CoreDecimal H_CURRENT_OCCURENCE;
        private CoreDecimal H_CURRENT_EP;
        private CoreCharacter H_CEILING_TYPE;
        private CoreDecimal H_ALLOCATION_PERIODS;
        private CoreDecimal T_ALLOC_PERS;
        private CoreCharacter W_DOC_NBR;
        private CoreCharacter X_SRCH_CODE;
        private CoreDecimal T_DOC_YRLY_CEILING_COMP1;
        private CoreDecimal T_DOC_YRLY_CEILING_COMP2;
        private CoreDecimal T_DOC_YRLY_CEILING_ERR;
        private CoreDecimal T_DOC_YRLY_CEILING_COMPUTED;
        private CoreDecimal T_DOC_YRLY_EXPENSE_COMPUTED;
        private CoreDecimal T_YEARLY_CEILING;
        private CoreDecimal T_CEILING_COMPUTED;
        private CoreCharacter T_RETRO_TO_FLAG;
        private CoreDecimal T_LAST_EP_NBR;
        private CoreDecimal T_SILENT_CEILING;
        private CoreDecimal T_YTDCEX_DIFF;
        private SqlFileObject fleF112_PYCDCEILINGS;
        private SqlFileObject fleF112_PYCDCEILINGS_AUDIT;
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

        private SqlFileObject fleF119_DOCTOR_YTD;
        //#CORE_BEGIN_INCLUDE: SAVEF112AUDIT_VAR"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:06:30 AM

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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:06:30 AM

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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:06:31 AM

        protected TextBox fldF112_PYCDCEILINGS_EP_NBR;
        protected DateControl fldF191_EARNINGS_PERIOD_ICONST_DATE_PERIOD_END;
        protected TextBox fldF112_PYCDCEILINGS_DOC_PAY_CODE;
        protected TextBox fldF112_PYCDCEILINGS_DOC_PAY_SUB_CODE;
        protected TextBox fldF112_PYCDCEILINGS_FACTOR;
        protected TextBox fldF112_PYCDCEILINGS_DOC_YRLY_CEILING;
        protected TextBox fldF112_PYCDCEILINGS_DOC_YRLY_CEILING_ADJUSTED;
        protected TextBox fldF112_PYCDCEILINGS_DOC_YRLY_CEILING_GUAR_PERC;
        protected TextBox fldF112_PYCDCEILINGS_DOC_YRLY_CEIL_GUAR;
        protected TextBox fldF112_PYCDCEILINGS_DOC_YRLY_EXPENSE;
        protected TextBox fldF112_PYCDCEILINGS_DOC_YRLY_EXPENSE_ADJUSTED;
        protected TextBox fldF112_PYCDCEILINGS_DOC_YRLY_EXPN_ALLOC_PERS;
        protected TextBox fldF112_PYCDCEILINGS_RETRO_TO_EP_NBR;
        protected TextBox fldT_SILENT_CEILING;

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:06:31 AM

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

                        fldF112_PYCDCEILINGS_EP_NBR.LookupOn -= fldF112_PYCDCEILINGS_EP_NBR_LookupOn;
                        fldF112_PYCDCEILINGS_EP_NBR.LookupOn += fldF112_PYCDCEILINGS_EP_NBR_LookupOn;

                        fldF112_PYCDCEILINGS_EP_NBR.Input -= fldF112_PYCDCEILINGS_EP_NBR_Input;
                        fldF112_PYCDCEILINGS_EP_NBR.Input += fldF112_PYCDCEILINGS_EP_NBR_Input;

                        fldF112_PYCDCEILINGS_EP_NBR.Edit -= fldF112_PYCDCEILINGS_EP_NBR_Edit;
                        fldF112_PYCDCEILINGS_EP_NBR.Edit += fldF112_PYCDCEILINGS_EP_NBR_Edit;
                        fldF112_PYCDCEILINGS_EP_NBR.Process -= fldF112_PYCDCEILINGS_EP_NBR_Process;
                        fldF112_PYCDCEILINGS_EP_NBR.Process += fldF112_PYCDCEILINGS_EP_NBR_Process;
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
                    case "FLDGRDF112_PYCDCEILINGS_FACTOR":
                        fldF112_PYCDCEILINGS_FACTOR = (TextBox)DataListField;
                        CoreField = fldF112_PYCDCEILINGS_FACTOR;
                        fldF112_PYCDCEILINGS_FACTOR.Bind(fleF112_PYCDCEILINGS);
                        break;
                    case "FLDGRDF112_PYCDCEILINGS_DOC_YRLY_CEILING":
                        fldF112_PYCDCEILINGS_DOC_YRLY_CEILING = (TextBox)DataListField;

                        fldF112_PYCDCEILINGS_DOC_YRLY_CEILING.Edit -= fldF112_PYCDCEILINGS_DOC_YRLY_CEILING_Edit;
                        fldF112_PYCDCEILINGS_DOC_YRLY_CEILING.Edit += fldF112_PYCDCEILINGS_DOC_YRLY_CEILING_Edit;
                        CoreField = fldF112_PYCDCEILINGS_DOC_YRLY_CEILING;
                        fldF112_PYCDCEILINGS_DOC_YRLY_CEILING.Bind(fleF112_PYCDCEILINGS);
                        break;
                    case "FLDGRDF112_PYCDCEILINGS_DOC_YRLY_CEILING_ADJUSTED":
                        fldF112_PYCDCEILINGS_DOC_YRLY_CEILING_ADJUSTED = (TextBox)DataListField;
                        CoreField = fldF112_PYCDCEILINGS_DOC_YRLY_CEILING_ADJUSTED;
                        fldF112_PYCDCEILINGS_DOC_YRLY_CEILING_ADJUSTED.Bind(fleF112_PYCDCEILINGS);
                        break;
                    case "FLDGRDF112_PYCDCEILINGS_DOC_YRLY_CEILING_GUAR_PERC":
                        fldF112_PYCDCEILINGS_DOC_YRLY_CEILING_GUAR_PERC = (TextBox)DataListField;
                        CoreField = fldF112_PYCDCEILINGS_DOC_YRLY_CEILING_GUAR_PERC;
                        fldF112_PYCDCEILINGS_DOC_YRLY_CEILING_GUAR_PERC.Bind(fleF112_PYCDCEILINGS);
                        break;
                    case "FLDGRDF112_PYCDCEILINGS_DOC_YRLY_CEIL_GUAR":
                        fldF112_PYCDCEILINGS_DOC_YRLY_CEIL_GUAR = (TextBox)DataListField;
                        CoreField = fldF112_PYCDCEILINGS_DOC_YRLY_CEIL_GUAR;
                        fldF112_PYCDCEILINGS_DOC_YRLY_CEIL_GUAR.Bind(fleF112_PYCDCEILINGS);
                        break;
                    case "FLDGRDF112_PYCDCEILINGS_DOC_YRLY_EXPENSE":
                        fldF112_PYCDCEILINGS_DOC_YRLY_EXPENSE = (TextBox)DataListField;

                        fldF112_PYCDCEILINGS_DOC_YRLY_EXPENSE.Edit -= fldF112_PYCDCEILINGS_DOC_YRLY_EXPENSE_Edit;
                        fldF112_PYCDCEILINGS_DOC_YRLY_EXPENSE.Edit += fldF112_PYCDCEILINGS_DOC_YRLY_EXPENSE_Edit;
                        CoreField = fldF112_PYCDCEILINGS_DOC_YRLY_EXPENSE;
                        fldF112_PYCDCEILINGS_DOC_YRLY_EXPENSE.Bind(fleF112_PYCDCEILINGS);
                        break;
                    case "FLDGRDF112_PYCDCEILINGS_DOC_YRLY_EXPENSE_ADJUSTED":
                        fldF112_PYCDCEILINGS_DOC_YRLY_EXPENSE_ADJUSTED = (TextBox)DataListField;
                        CoreField = fldF112_PYCDCEILINGS_DOC_YRLY_EXPENSE_ADJUSTED;
                        fldF112_PYCDCEILINGS_DOC_YRLY_EXPENSE_ADJUSTED.Bind(fleF112_PYCDCEILINGS);
                        break;
                    case "FLDGRDF112_PYCDCEILINGS_DOC_YRLY_EXPN_ALLOC_PERS":
                        fldF112_PYCDCEILINGS_DOC_YRLY_EXPN_ALLOC_PERS = (TextBox)DataListField;
                        CoreField = fldF112_PYCDCEILINGS_DOC_YRLY_EXPN_ALLOC_PERS;
                        fldF112_PYCDCEILINGS_DOC_YRLY_EXPN_ALLOC_PERS.Bind(fleF112_PYCDCEILINGS);
                        break;
                    case "FLDGRDF112_PYCDCEILINGS_RETRO_TO_EP_NBR":
                        fldF112_PYCDCEILINGS_RETRO_TO_EP_NBR = (TextBox)DataListField;

                        fldF112_PYCDCEILINGS_RETRO_TO_EP_NBR.LookupOn -= fldF112_PYCDCEILINGS_RETRO_TO_EP_NBR_LookupOn;
                        fldF112_PYCDCEILINGS_RETRO_TO_EP_NBR.LookupOn += fldF112_PYCDCEILINGS_RETRO_TO_EP_NBR_LookupOn;

                        fldF112_PYCDCEILINGS_RETRO_TO_EP_NBR.Edit -= fldF112_PYCDCEILINGS_RETRO_TO_EP_NBR_Edit;
                        fldF112_PYCDCEILINGS_RETRO_TO_EP_NBR.Edit += fldF112_PYCDCEILINGS_RETRO_TO_EP_NBR_Edit;
                        CoreField = fldF112_PYCDCEILINGS_RETRO_TO_EP_NBR;
                        fldF112_PYCDCEILINGS_RETRO_TO_EP_NBR.Bind(fleF112_PYCDCEILINGS);
                        break;
                    case "FLDGRDT_SILENT_CEILING":
                        fldT_SILENT_CEILING = (TextBox)DataListField;

                        fldT_SILENT_CEILING.Process -= fldT_SILENT_CEILING_Process;
                        fldT_SILENT_CEILING.Process += fldT_SILENT_CEILING_Process;
                        CoreField = fldT_SILENT_CEILING;
                        fldT_SILENT_CEILING.Bind(T_SILENT_CEILING);
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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:06:31 AM

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
            fleF112_PYCDCEILINGS_AUDIT.Transaction = m_trnTRANS_UPDATE;
            fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
            fleCONSTANTS_MSTR_REC_6.Transaction = m_trnTRANS_UPDATE;
            fleF119_DOCTOR_YTD.Transaction = m_trnTRANS_UPDATE;


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:06:31 AM

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
                fleF112_PYCDCEILINGS_AUDIT.Dispose();
                fleF020_DOCTOR_MSTR.Dispose();
                fleCONSTANTS_MSTR_REC_6.Dispose();
                fleF191_EARNINGS_PERIOD.Dispose();
                fleF119_DOCTOR_YTD.Dispose();


            }
            catch (CustomApplicationException ex)
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:06:30 AM
        //#-----------------------------------------
        protected override void DisplayFormatting()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:06:30 AM
                
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:06:30 AM
        //#-----------------------------------------
        protected override void PreDisplayFormatting()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:06:30 AM
                
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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:06:31 AM

        //#-----------------------------------------
        //# BindFields Procedure.
        //#-----------------------------------------

        public override void BindFields()
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



        private void fldF112_PYCDCEILINGS_RETRO_TO_EP_NBR_LookupOn()
        {

            try
            {
                StringBuilder strSQL = new StringBuilder(" WHERE ");
                strSQL.Append("     ").Append(fleF191_EARNINGS_PERIOD.ElementOwner("EP_NBR")).Append(" = ").Append((FieldText));

                fleF191_EARNINGS_PERIOD.GetData(strSQL.ToString(), GetDataOptions.IsOptional);
                if (!AccessOk)
                {
                    ErrorMessage("Invalid Earnings Period.\a");
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




        private void fldF112_PYCDCEILINGS_EP_NBR_LookupOn()
        {

            try
            {
                StringBuilder strSQL = new StringBuilder(" WHERE ");
                strSQL.Append("     ").Append(fleF191_EARNINGS_PERIOD.ElementOwner("EP_NBR")).Append(" = ").Append((FieldText));

                fleF191_EARNINGS_PERIOD.GetData(strSQL.ToString(), GetDataOptions.IsOptional);
                if (!AccessOk)
                {
                    ErrorMessage("Invalid Earnings Period.\a");
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



        protected override object SetFieldDefaults(string Name)
        {


            try
            {
                switch (Name)
                {
                    case "F112_PYCDCEILINGS_FACTOR":
                        return 10000;
                    case "F112_PYCDCEILINGS_DOC_YRLY_CEILING_GUAR_PERC":
                        return 100;
                    case "F112_PYCDCEILINGS_DOC_PAY_CODE":
                        return 0;

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


        private bool Internal_CALC_FINAL_COMPUTED_CEILING()
        {


            try
            {

                if (QDesign.NULL(H_CEILING_TYPE.Value) == QDesign.NULL("EAR"))
                {
                    T_ALLOC_PERS.Value = 12;
                }
                else
                {
                    T_ALLOC_PERS.Value = H_ALLOCATION_PERIODS.Value;
                }
                T_DOC_YRLY_CEILING_COMP1.Value = T_CEILING_COMPUTED.Value + (QDesign.Round(T_YEARLY_CEILING.Value / T_ALLOC_PERS.Value, 0, RoundOptionTypes.Near) * (12 - T_COUNTER_RECS_F112.Value + T_ADJUSTMENT.Value));
                T_DOC_YRLY_CEILING_COMP2.Value = QDesign.PHMod(T_DOC_YRLY_CEILING_COMP1.Value, 100);
                if (T_DOC_YRLY_CEILING_COMP2.Value >= 50)
                {
                    T_DOC_YRLY_CEILING_ERR.Value = 1;
                }
                else
                {
                    T_DOC_YRLY_CEILING_ERR.Value = 0;
                }
                T_CEILING_COMPUTED.Value = (QDesign.Floor(T_DOC_YRLY_CEILING_COMP1.Value / 100) + T_DOC_YRLY_CEILING_ERR.Value) * 100;

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


        private bool Internal_BUILD_COMPUTED_CEILING()
        {


            try
            {

                if (QDesign.NULL(H_CEILING_TYPE.Value) == QDesign.NULL("EAR"))
                {
                    T_ALLOC_PERS.Value = 12;
                }
                else
                {
                    T_ALLOC_PERS.Value = H_ALLOCATION_PERIODS.Value;
                }
                T_DOC_YRLY_CEILING_COMP1.Value = T_CEILING_COMPUTED.Value + QDesign.Round(T_YEARLY_CEILING.Value / T_ALLOC_PERS.Value, 0, RoundOptionTypes.Near);
                T_DOC_YRLY_CEILING_COMP2.Value = QDesign.PHMod(T_DOC_YRLY_CEILING_COMP1.Value, 100);
                if (T_DOC_YRLY_CEILING_COMP2.Value >= 50)
                {
                    T_DOC_YRLY_CEILING_ERR.Value = 1;
                }
                else
                {
                    T_DOC_YRLY_CEILING_ERR.Value = 0;
                }
                T_CEILING_COMPUTED.Value = (T_DOC_YRLY_CEILING_COMP1.Value + T_DOC_YRLY_CEILING_ERR.Value);

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


        private bool Internal_FINISH_COMP_CEILING_TO_YEAREND()
        {


            try
            {

                if (QDesign.NULL(T_RETRO_TO_FLAG.Value) == QDesign.NULL("C") | QDesign.NULL(T_RETRO_TO_FLAG.Value) == QDesign.NULL("B"))
                {
                    T_YEARLY_CEILING.Value = T_LAST_CEILING_EAR.Value;
                    T_CEILING_COMPUTED.Value = T_DOC_YRLY_CEILING_COMPUTED.Value;
                    H_CEILING_TYPE.Value = "EAR";
                    Internal_CALC_FINAL_COMPUTED_CEILING();
                    fleF020_DOCTOR_MSTR.set_SetValue("DOC_YRLY_CEILING_COMPUTED", T_CEILING_COMPUTED.Value);
                }
                if (QDesign.NULL(T_RETRO_TO_FLAG.Value) == QDesign.NULL("E") | QDesign.NULL(T_RETRO_TO_FLAG.Value) == QDesign.NULL("B"))
                {
                    T_YEARLY_CEILING.Value = T_LAST_CEILING_EXP.Value;
                    T_CEILING_COMPUTED.Value = T_DOC_YRLY_EXPENSE_COMPUTED.Value;
                    H_CEILING_TYPE.Value = "EXP";
                    Internal_CALC_FINAL_COMPUTED_CEILING();
                    fleF020_DOCTOR_MSTR.set_SetValue("DOC_YRLY_EXPENSE_COMPUTED", T_CEILING_COMPUTED.Value);
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


        private bool Internal_RETRO_CEILING()
        {


            try
            {

                if (QDesign.NULL(T_RETRO_TO_FLAG.Value) == QDesign.NULL("C") | QDesign.NULL(T_RETRO_TO_FLAG.Value) == QDesign.NULL("B"))
                {
                    fleF020_DOCTOR_MSTR.set_SetValue("DOC_YRLY_CEILING_COMPUTED", 0);
                }
                if (QDesign.NULL(T_RETRO_TO_FLAG.Value) == QDesign.NULL("E") | QDesign.NULL(T_RETRO_TO_FLAG.Value) == QDesign.NULL("B"))
                {
                    fleF020_DOCTOR_MSTR.set_SetValue("DOC_YRLY_EXPENSE_COMPUTED", 0);
                }
                T_DOC_YRLY_CEILING_COMPUTED.Value = 0;
                T_DOC_YRLY_EXPENSE_COMPUTED.Value = 0;
                while (fleF112_PYCDCEILINGS.For())
                {
                    if (QDesign.NULL(fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR")) != 0)
                    {
                        T_COUNTER_RECS_F112.Value = QDesign.PHMod(fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR"), 100);
                    }
                    if (fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR") >= H_RETRO_TO_EP_NBR.Value & Occurrence < QDesign.NULL(H_CURRENT_OCCURENCE.Value) & T_COUNTER_RECS_F112.Value <= 12)
                    {
                        if (QDesign.NULL(T_RETRO_TO_FLAG.Value) == QDesign.NULL("C") | QDesign.NULL(T_RETRO_TO_FLAG.Value) == QDesign.NULL("B"))
                        {
                            fleF112_PYCDCEILINGS.set_SetValue("DOC_YRLY_CEILING_ADJUSTED", fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEILING"));
                            fleF112_PYCDCEILINGS.set_SetValue("DOC_YRLY_CEILING", H_DOC_YRLY_CEILING.Value);
                            Display(ref fldF112_PYCDCEILINGS_DOC_YRLY_CEILING);
                            Display(ref fldF112_PYCDCEILINGS_DOC_YRLY_CEILING_ADJUSTED);
                        }
                        if (QDesign.NULL(T_RETRO_TO_FLAG.Value) == QDesign.NULL("E") | QDesign.NULL(T_RETRO_TO_FLAG.Value) == QDesign.NULL("B"))
                        {
                            fleF112_PYCDCEILINGS.set_SetValue("DOC_YRLY_EXPENSE_ADJUSTED", fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_EXPENSE"));
                            fleF112_PYCDCEILINGS.set_SetValue("DOC_YRLY_EXPENSE", H_DOC_YRLY_EXPENSE.Value);
                            Display(ref fldF112_PYCDCEILINGS_DOC_YRLY_EXPENSE);
                            Display(ref fldF112_PYCDCEILINGS_DOC_YRLY_EXPENSE_ADJUSTED);
                            fleF112_PYCDCEILINGS.set_SetValue("DOC_YRLY_EXPN_ALLOC_PERS", H_ALLOCATION_PERIODS.Value);
                            Display(ref fldF112_PYCDCEILINGS_DOC_YRLY_EXPN_ALLOC_PERS);
                        }
                    }
                    if ((QDesign.NULL(T_RETRO_TO_FLAG.Value) == QDesign.NULL("C") | QDesign.NULL(T_RETRO_TO_FLAG.Value) == QDesign.NULL("B")) & (QDesign.NULL(fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR")) < QDesign.NULL(fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR"))) & (QDesign.NULL(fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR")) != 0))
                    {
                        T_CEILING_COMPUTED.Value = T_DOC_YRLY_CEILING_COMPUTED.Value;
                        T_YEARLY_CEILING.Value = fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEILING") * 100;
                        H_CEILING_TYPE.Value = "EAR";
                        Internal_BUILD_COMPUTED_CEILING();
                        T_DOC_YRLY_CEILING_COMPUTED.Value = T_CEILING_COMPUTED.Value;
                        T_ADJUSTMENT.Value = 0;
                        Internal_CALC_FINAL_COMPUTED_CEILING();
                        fleF112_PYCDCEILINGS.set_SetValue("DOC_YRLY_CEILING_COMPUTED", T_CEILING_COMPUTED.Value);
                    }
                    if ((QDesign.NULL(T_RETRO_TO_FLAG.Value) == QDesign.NULL("E") | QDesign.NULL(T_RETRO_TO_FLAG.Value) == QDesign.NULL("B")) & (QDesign.NULL(fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR")) < QDesign.NULL(fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR"))) & (QDesign.NULL(fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR")) != 0))
                    {
                        T_CEILING_COMPUTED.Value = T_DOC_YRLY_EXPENSE_COMPUTED.Value;
                        T_YEARLY_CEILING.Value = fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_EXPENSE") * 100;
                        H_CEILING_TYPE.Value = "EXP";
                        Internal_BUILD_COMPUTED_CEILING();
                        T_DOC_YRLY_EXPENSE_COMPUTED.Value = T_CEILING_COMPUTED.Value;
                        T_ADJUSTMENT.Value = 0;
                        Internal_CALC_FINAL_COMPUTED_CEILING();
                        fleF112_PYCDCEILINGS.set_SetValue("DOC_YRLY_EXPENSE_COMPUTED", T_CEILING_COMPUTED.Value);
                    }
                    if (QDesign.NULL(fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR")) == QDesign.NULL(fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR")))
                    {
                        if (QDesign.NULL(T_RETRO_TO_FLAG.Value) == QDesign.NULL("C") | QDesign.NULL(T_RETRO_TO_FLAG.Value) == QDesign.NULL("B"))
                        {
                            fleF020_DOCTOR_MSTR.set_SetValue("DOC_YTDCEA", T_DOC_YRLY_CEILING_COMPUTED.Value);
                            H_CEILING_TYPE.Value = "EAR";
                            T_ADJUSTMENT.Value = 0;
                            T_CEILING_COMPUTED.Value = T_DOC_YRLY_CEILING_COMPUTED.Value;
                            T_YEARLY_CEILING.Value = fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEILING") * 100;
                            Internal_CALC_FINAL_COMPUTED_CEILING();
                            fleF112_PYCDCEILINGS.set_SetValue("DOC_YRLY_CEILING_COMPUTED", T_CEILING_COMPUTED.Value);
                            T_CEILING_COMPUTED.Value = T_DOC_YRLY_CEILING_COMPUTED.Value;
                        }
                        if (QDesign.NULL(T_RETRO_TO_FLAG.Value) == QDesign.NULL("E") | QDesign.NULL(T_RETRO_TO_FLAG.Value) == QDesign.NULL("B"))
                        {
                            T_YTDCEX_DIFF.Value = T_DOC_YRLY_EXPENSE_COMPUTED.Value - fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDCEX");
                            fleF020_DOCTOR_MSTR.set_SetValue("DOC_YTDCEX", T_DOC_YRLY_EXPENSE_COMPUTED.Value);
                            H_CEILING_TYPE.Value = "EXP";
                            T_ADJUSTMENT.Value = 0;
                            T_CEILING_COMPUTED.Value = T_DOC_YRLY_EXPENSE_COMPUTED.Value;
                            T_YEARLY_CEILING.Value = fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_EXPENSE") * 100;
                            Internal_CALC_FINAL_COMPUTED_CEILING();
                            fleF112_PYCDCEILINGS.set_SetValue("DOC_YRLY_EXPENSE_COMPUTED", T_CEILING_COMPUTED.Value);
                            T_CEILING_COMPUTED.Value = T_DOC_YRLY_EXPENSE_COMPUTED.Value;
                        }
                    }
                    if (QDesign.NULL(fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR")) != 0)
                    {
                        T_COUNTER_RECS_F112.Value = QDesign.PHMod(fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR"), 100);
                        T_LAST_CEILING_EAR.Value = fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEILING") * 100;
                        T_LAST_CEILING_EXP.Value = fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_EXPENSE") * 100;
                    }
                }
                T_ADJUSTMENT.Value = 1;
                Internal_FINISH_COMP_CEILING_TO_YEAREND();

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


        private bool Internal_CALC_TRUE_CEILING()
        {


            try
            {

                T_DOC_YRLY_CEILING_COMPUTED.Value = 0;
                T_DOC_YRLY_EXPENSE_COMPUTED.Value = 0;
                T_LAST_EP_NBR.Value = 1;
                T_LAST_CEILING_EAR.Value = 0;
                T_LAST_CEILING_EXP.Value = 0;
                T_ALLOC_PERS.Value = 0;
                while (fleF112_PYCDCEILINGS.For())
                {
                    T_COUNTER_RECS_F112.Value = QDesign.PHMod(fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR"), 100);
                    if (0 < QDesign.NULL((T_COUNTER_RECS_F112.Value - T_LAST_EP_NBR.Value)))
                    {
                        T_DOC_YRLY_CEILING_COMPUTED.Value = T_DOC_YRLY_CEILING_COMPUTED.Value + ((T_LAST_CEILING_EAR.Value / 12) * (T_COUNTER_RECS_F112.Value - T_LAST_EP_NBR.Value));
                        T_DOC_YRLY_EXPENSE_COMPUTED.Value = T_DOC_YRLY_EXPENSE_COMPUTED.Value + ((T_LAST_CEILING_EXP.Value / T_ALLOC_PERS.Value) * (T_COUNTER_RECS_F112.Value - T_LAST_EP_NBR.Value));
                    }
                    T_LAST_CEILING_EAR.Value = fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEILING") * 100;
                    T_LAST_CEILING_EXP.Value = fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_EXPENSE") * 100;
                    T_LAST_EP_NBR.Value = T_COUNTER_RECS_F112.Value;
                    T_ALLOC_PERS.Value = fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_EXPN_ALLOC_PERS");
                }
                T_DOC_YRLY_CEILING_COMPUTED.Value = T_DOC_YRLY_CEILING_COMPUTED.Value + QDesign.Round((12 - T_LAST_EP_NBR.Value + 1) * (T_LAST_CEILING_EAR.Value / 12), 0, RoundOptionTypes.Near);
                fleF020_DOCTOR_MSTR.set_SetValue("DOC_YRLY_CEILING_COMPUTED", T_DOC_YRLY_CEILING_COMPUTED.Value);
                T_DOC_YRLY_EXPENSE_COMPUTED.Value = T_DOC_YRLY_EXPENSE_COMPUTED.Value + QDesign.Round((12 - T_LAST_EP_NBR.Value + 1) * (T_LAST_CEILING_EXP.Value / T_ALLOC_PERS.Value), 0, RoundOptionTypes.Near);
                fleF020_DOCTOR_MSTR.set_SetValue("DOC_YRLY_EXPENSE_COMPUTED", T_DOC_YRLY_EXPENSE_COMPUTED.Value);

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



        private void fldF112_PYCDCEILINGS_EP_NBR_Input()
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



        private void fldF112_PYCDCEILINGS_EP_NBR_Edit()
        {

            try
            {

                if (QDesign.NULL(fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR")) > QDesign.NULL(fleCONSTANTS_MSTR_REC_6.GetDecimalValue("LAST_EP_NBR_OF_FISCAL_YR")))
                {
                    Warning("*W* This Earnings Period is NOT within the CURRENT FISCAL Year.");
                }
                if (QDesign.NULL(fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR")) < QDesign.NULL(fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR")))
                {
                    ErrorMessage("Error - This Earnings Period is PRIOR to the CURRENT Earnings Period.");
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



        private void fldF112_PYCDCEILINGS_EP_NBR_Process()
        {

            try
            {

                T_RETRO_TO_FLAG.Value = " ";
                fleF112_PYCDCEILINGS.set_SetValue("DOC_NBR", W_DOC_NBR.Value);
                Display(ref fldF191_EARNINGS_PERIOD_ICONST_DATE_PERIOD_END);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldF112_PYCDCEILINGS_DOC_YRLY_CEILING_Edit()
        {

            try
            {

                if (QDesign.NULL(OldValue(fleF112_PYCDCEILINGS.ElementOwner("DOC_YRLY_CEILING"), fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEILING"))) != QDesign.NULL(fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEILING")) | (NewRecord() & QDesign.NULL(fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEILING")) == 0))
                {
                    T_RETRO_TO_FLAG.Value = "C";
                    fleF112_PYCDCEILINGS.set_SetValue("DOC_YRLY_CEILING_ADJUSTED", OldValue(fleF112_PYCDCEILINGS.ElementOwner("DOC_YRLY_CEILING"), fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEILING")));
                    Display(ref fldF112_PYCDCEILINGS_DOC_YRLY_CEILING_ADJUSTED);
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



        private void fldF112_PYCDCEILINGS_DOC_YRLY_EXPENSE_Edit()
        {

            try
            {

                if (QDesign.NULL(OldValue(fleF112_PYCDCEILINGS.ElementOwner("DOC_YRLY_EXPENSE"), fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_EXPENSE"))) != QDesign.NULL(fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_EXPENSE")) | (NewRecord() & QDesign.NULL(fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_EXPENSE")) == 0))
                {
                    if (QDesign.NULL(T_RETRO_TO_FLAG.Value) == QDesign.NULL(" "))
                    {
                        T_RETRO_TO_FLAG.Value = "E";
                    }
                    else
                    {
                        T_RETRO_TO_FLAG.Value = "B";
                    }
                    fleF112_PYCDCEILINGS.set_SetValue("DOC_YRLY_EXPENSE_ADJUSTED", OldValue(fleF112_PYCDCEILINGS.ElementOwner("DOC_YRLY_EXPENSE"), fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_EXPENSE")));
                    Display(ref fldF112_PYCDCEILINGS_DOC_YRLY_EXPENSE_ADJUSTED);
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



        private void fldF112_PYCDCEILINGS_RETRO_TO_EP_NBR_Edit()
        {

            try
            {

                if (QDesign.NULL(fleF112_PYCDCEILINGS.GetDecimalValue("RETRO_TO_EP_NBR")) > QDesign.NULL(fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR")))
                {
                    ErrorMessage("Error -  Can`t be Retroactive to FUTURE E/P.\a");
                }
                if (QDesign.NULL(fleF112_PYCDCEILINGS.GetDecimalValue("RETRO_TO_EP_NBR")) < QDesign.NULL(fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR")))
                {
                    Warning("*W* Must be Retroactive from CURRENT EP.\a");
                }
                T_YY_RETRO.Value = QDesign.Substring(QDesign.ASCII(fleF112_PYCDCEILINGS.GetDecimalValue("RETRO_TO_EP_NBR"), 6), 1, 4);
                T_YY_FISCAL.Value = QDesign.Substring(QDesign.ASCII(fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR"), 6), 1, 4);
                if (QDesign.NULL(T_YY_RETRO.Value) != QDesign.NULL(T_YY_FISCAL.Value))
                {
                    ErrorMessage("Error -  Must be Retroactive within CURRENT YEAR.\a");
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



        private void fldT_SILENT_CEILING_Process()
        {

            try
            {

                if (QDesign.NULL(fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR")) != 0)
                {
                    H_DOC_YRLY_CEILING.Value = fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEILING");
                    H_DOC_YRLY_EXPENSE.Value = fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_EXPENSE");
                    H_ALLOCATION_PERIODS.Value = fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_EXPN_ALLOC_PERS");
                    H_CURRENT_EP.Value = fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR");
                    H_CURRENT_OCCURENCE.Value = Occurrence;
                    if (QDesign.NULL(fleF112_PYCDCEILINGS.GetDecimalValue("RETRO_TO_EP_NBR")) != 0)
                    {
                        H_RETRO_TO_EP_NBR.Value = fleF112_PYCDCEILINGS.GetDecimalValue("RETRO_TO_EP_NBR");
                    }
                    else
                    {
                        H_RETRO_TO_EP_NBR.Value = fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR");
                    }
                    Internal_RETRO_CEILING();
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

        //#CORE_BEGIN_INCLUDE: SAVEF112AUDIT"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:06:30 AM


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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:06:30 AM


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


        protected override bool PreUpdate()
        {


            try
            {

                if (QDesign.NULL(T_YTDCEX_DIFF.Value) != 0)
                {
                    // --> GET F119_DOCTOR_YTD <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF119_DOCTOR_YTD.ElementOwner("DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")));
                    m_strWhere.Append(" And ").Append(fleF119_DOCTOR_YTD.ElementOwner("COMP_CODE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("CEIEXP"));

                    fleF119_DOCTOR_YTD.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F119_DOCTOR_YTD <--
                    if (AccessOk)
                    {
                        fleF119_DOCTOR_YTD.set_SetValue("AMT_YTD", fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") + T_YTDCEX_DIFF.Value);
                        fleF119_DOCTOR_YTD.PutData();
                    }
                    // --> GET F119_DOCTOR_YTD <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF119_DOCTOR_YTD.ElementOwner("DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")));
                    m_strWhere.Append(" And ").Append(fleF119_DOCTOR_YTD.ElementOwner("COMP_CODE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("TOTEXP"));

                    fleF119_DOCTOR_YTD.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F119_DOCTOR_YTD <--
                    if (AccessOk)
                    {
                        fleF119_DOCTOR_YTD.set_SetValue("AMT_YTD", fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") + T_YTDCEX_DIFF.Value);
                        fleF119_DOCTOR_YTD.PutData();
                    }
                    // --> GET F119_DOCTOR_YTD <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF119_DOCTOR_YTD.ElementOwner("DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")));
                    m_strWhere.Append(" And ").Append(fleF119_DOCTOR_YTD.ElementOwner("COMP_CODE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("INCEXP"));

                    fleF119_DOCTOR_YTD.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F119_DOCTOR_YTD <--
                    if (AccessOk)
                    {
                        fleF119_DOCTOR_YTD.set_SetValue("AMT_YTD", fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") - T_YTDCEX_DIFF.Value);
                        fleF119_DOCTOR_YTD.PutData();
                    }
                }
                while (fleF112_PYCDCEILINGS.For())
                {
                    if (fleF112_PYCDCEILINGS.NewRecord)
                    {
                        Internal_CREATEF112AUDIT_ADD();
                        fleF112_PYCDCEILINGS_AUDIT.set_SetValue("LAST_MOD_FLAG", "A");
                        fleF112_PYCDCEILINGS_AUDIT.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));
                        fleF112_PYCDCEILINGS_AUDIT.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);
                        fleF112_PYCDCEILINGS_AUDIT.set_SetValue("LAST_MOD_USER_ID", QDesign.RTrim(UserID) + "-d112-A");
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
                            fleF112_PYCDCEILINGS_AUDIT.set_SetValue("LAST_MOD_USER_ID", QDesign.RTrim(UserID) + "-d112-D");
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
                                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("LAST_MOD_USER_ID", QDesign.RTrim(UserID) + "-d112-1");
                                fleF112_PYCDCEILINGS_AUDIT.PutData(true);
                                Internal_CREATEF112AUDIT_ADD();
                                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("LAST_MOD_FLAG", "C");
                                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));
                                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);
                                fleF112_PYCDCEILINGS_AUDIT.set_SetValue("LAST_MOD_USER_ID", QDesign.RTrim(UserID) + "-d112-2");
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:05:01 AM
        //#-----------------------------------------
        protected override bool Append()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:05:01 AM
                Accept(ref fldF112_PYCDCEILINGS_EP_NBR);
                Display(ref fldF191_EARNINGS_PERIOD_ICONST_DATE_PERIOD_END);
                Accept(ref fldF112_PYCDCEILINGS_DOC_PAY_CODE);
                if (QDesign.NULL(fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_CODE")) == QDesign.NULL("1") | QDesign.NULL(fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_CODE")) == QDesign.NULL("4"))
                {
                    Accept(ref fldF112_PYCDCEILINGS_DOC_PAY_SUB_CODE);
                }
                else
                {
                    Display(ref fldF112_PYCDCEILINGS_DOC_PAY_SUB_CODE);
                }
                Accept(ref fldF112_PYCDCEILINGS_FACTOR);
                if ((QDesign.NULL(fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_CODE")) != QDesign.NULL("0") & QDesign.NULL(fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_CODE")) != QDesign.NULL("2")))
                {
                    Accept(ref fldF112_PYCDCEILINGS_DOC_YRLY_CEILING);
                }
                else
                {
                    Display(ref fldF112_PYCDCEILINGS_DOC_YRLY_CEILING);
                }
                Display(ref fldF112_PYCDCEILINGS_DOC_YRLY_CEILING_ADJUSTED);
                if (QDesign.NULL(fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_CODE")) == QDesign.NULL("1"))
                {
                    Accept(ref fldF112_PYCDCEILINGS_DOC_YRLY_CEILING_GUAR_PERC);
                }
                else
                {
                    Display(ref fldF112_PYCDCEILINGS_DOC_YRLY_CEILING_GUAR_PERC);
                }
                if (QDesign.NULL(fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_CODE")) == QDesign.NULL("1"))
                {
                    Accept(ref fldF112_PYCDCEILINGS_DOC_YRLY_CEIL_GUAR);
                }
                else
                {
                    Display(ref fldF112_PYCDCEILINGS_DOC_YRLY_CEIL_GUAR);
                }
                if (QDesign.NULL(fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_CODE")) == QDesign.NULL("4"))
                {
                    Accept(ref fldF112_PYCDCEILINGS_DOC_YRLY_EXPENSE);
                }
                else
                {
                    Display(ref fldF112_PYCDCEILINGS_DOC_YRLY_EXPENSE);
                }
                Display(ref fldF112_PYCDCEILINGS_DOC_YRLY_EXPENSE_ADJUSTED);
                if (fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_EXPENSE") > 0)
                {
                    Accept(ref fldF112_PYCDCEILINGS_DOC_YRLY_EXPN_ALLOC_PERS);
                }
                else
                {
                    Display(ref fldF112_PYCDCEILINGS_DOC_YRLY_EXPN_ALLOC_PERS);
                }
                Accept(ref fldF112_PYCDCEILINGS_RETRO_TO_EP_NBR);
                Edit(ref fldT_SILENT_CEILING);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:05:01 AM
        //#-----------------------------------------
        protected override bool Update()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:05:01 AM
                fleF020_DOCTOR_MSTR.PutData(false, PutTypes.New);
                while (fleF112_PYCDCEILINGS.For())
                {
                    fleF112_PYCDCEILINGS.PutData(false, PutTypes.Deleted);
                }
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
        //# Delete Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:05:01 AM
        //#-----------------------------------------
        protected override bool Delete()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:05:01 AM
                fleF112_PYCDCEILINGS.DeletedRecord = true;
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:05:01 AM
        //#-----------------------------------------
        private void dtlF112_PYCDCEILINGS_EditClick(DataList source, GridButtonEventArgs GridButtonEventArgs)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:06:30 AM
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:05:01 AM
        //#-----------------------------------------
        private void dsrDesigner_01_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:06:31 AM
                Accept(ref fldF112_PYCDCEILINGS_EP_NBR);
                Display(ref fldF191_EARNINGS_PERIOD_ICONST_DATE_PERIOD_END);
                Accept(ref fldF112_PYCDCEILINGS_DOC_PAY_CODE);
                Accept(ref fldF112_PYCDCEILINGS_DOC_PAY_SUB_CODE);
                Accept(ref fldF112_PYCDCEILINGS_FACTOR);
                Accept(ref fldF112_PYCDCEILINGS_DOC_YRLY_CEILING);
                Display(ref fldF112_PYCDCEILINGS_DOC_YRLY_CEILING_ADJUSTED);
                Accept(ref fldF112_PYCDCEILINGS_DOC_YRLY_CEILING_GUAR_PERC);
                Accept(ref fldF112_PYCDCEILINGS_DOC_YRLY_CEIL_GUAR);
                Accept(ref fldF112_PYCDCEILINGS_DOC_YRLY_EXPENSE);
                Display(ref fldF112_PYCDCEILINGS_DOC_YRLY_EXPENSE_ADJUSTED);
                Accept(ref fldF112_PYCDCEILINGS_DOC_YRLY_EXPN_ALLOC_PERS);
                Accept(ref fldF112_PYCDCEILINGS_RETRO_TO_EP_NBR);
                Edit(ref fldT_SILENT_CEILING);
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

