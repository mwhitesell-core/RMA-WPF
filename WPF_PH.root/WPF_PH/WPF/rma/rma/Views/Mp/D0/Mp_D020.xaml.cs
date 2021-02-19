
#region "Screen Comments"

// #> program-id.     d020.qks
// note: 1) some programming remains to pass ep-minus-1
// to sub-screens. should defaut ep to  E  mode
// and ep-1 to find mode
// ((c)) dyad technologies
// program purpose : maintenance of doctor - payroll data
// modification history
// date   who         description
// 92/jan/02 b.e.        - original
// 92/oct/13 b.e.        - default from-ep-nbr for sub-screens using
// previous ep not current ep.
// 93/jul/02 y.b.        - change column clinic to class
// 93/jul/30 m.c.        - changed doc-dept-expense-percent from noid ti
// id same
// 93/sep/21 b.e.        - added rma/dept reg/misc billing percents
// 95/jun/29 b.m.l. - added designer procs. h110,hi12,hi13 & hi19
// 95/nov/07 m.c. - for 91 & 98 screens, do not prompt for ep-nbr
// - for 94 history screen, prompt for ep nbr
// 95/nov/15 m.c. - add f020-doctor-extra as secondary and pass
// it to the tot screen (d020a)
// 96/jan/22 m.c. - sms 147 - include new screen option 92 for
// require & target revenue entry
// 98/jan/06 j.c. - sms 148 - include for 1,col in last two cluster
// statements otherwise error compilation 
// 1999/Jan/18 S.B.      - Fixed `start` and `term` dates for 
// Y2K compliance.
// 1999/Jun/07 S.B. - Altered the call to scrtitle.use and
// stdhilite.use to be called from $use
// instead of src.
// - Removed the call to secfile.use because
// it was not doing anything.
// 99/sep/20 B.E. - added UPSHIFT to gst flag
// 2003/nov/10 b.e.      - alpha doctor nbr
// 2004/jul/20 b.e. - added field doc-afp-paym-group
// 2014/aug/18 MC1       - read f112 file backwards did not work, use w-current-ep-nbr-minus-1 instead,
// change to the same as 101c version as Brad requested
// 2014/sep/15 MC2       - add f020-doctor-audit to capture before change records
// - specify the file on the field statements
// - save f020-doctor-mstr & f020-doctor-extra records in f020-doctor-audit in postfind in case
// user may change the records
// on 1 for 23

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

    partial class Mp_D020 : BasePage
    {

        #region " Form Designer Generated Code "





        public Mp_D020()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "D020";

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
            dsrDesigner_91.Click += dsrDesigner_91_Click;
            dsrDesigner_HI91.Click += dsrDesigner_HI91_Click;
            dsrDesigner_92.Click += dsrDesigner_92_Click;
            dsrDesigner_HI92.Click += dsrDesigner_HI92_Click;
            dsrDesigner_93.Click += dsrDesigner_93_Click;
            dsrDesigner_HI93.Click += dsrDesigner_HI93_Click;
            dsrDesigner_94.Click += dsrDesigner_94_Click;
            dsrDesigner_HI94.Click += dsrDesigner_HI94_Click;
            dsrDesigner_95.Click += dsrDesigner_95_Click;
            dsrDesigner_98.Click += dsrDesigner_98_Click;
            dsrDesigner_HI98.Click += dsrDesigner_HI98_Click;
            dsrDesigner_99.Click += dsrDesigner_99_Click;
            dsrDesigner_TOT.Click += dsrDesigner_TOT_Click;
            dsrDesigner_HTOT.Click += dsrDesigner_HTOT_Click;
            dsrDesigner_ADJ.Click += dsrDesigner_ADJ_Click;
            dsrDesigner_03.Click += dsrDesigner_03_Click;
            dsrDesigner_04.Click += dsrDesigner_04_Click;
            fldF020_DOCTOR_MSTR_DOC_DEPT.LookupOn += fldF020_DOCTOR_MSTR_DOC_DEPT_LookupOn;
            fldF020_DOCTOR_MSTR_DOC_NBR.Edit += fldF020_DOCTOR_MSTR_DOC_NBR_Edit;
            fldF020_DOCTOR_MSTR_DOC_BANK_BRANCH.Edit += fldF020_DOCTOR_MSTR_DOC_BANK_BRANCH_Edit;
            fldF020_DOCTOR_MSTR_DOC_BANK_NBR.Process += fldF020_DOCTOR_MSTR_DOC_BANK_NBR_Process;
            fldF020_DOCTOR_MSTR_DOC_DATE_FAC_TERM.Process += fldF020_DOCTOR_MSTR_DOC_DATE_FAC_TERM_Process;
            base.Page_Load();

            // TODO: The following elements have Input/Output Scaling defined in the Dictionary or Screen.  Manual steps may be required:
            //       F020_DOCTOR_AUDIT.DOC_YRLY_CEILING_COMPUTED InputScale: 2 OutputScale: 0
            //       F020_DOCTOR_AUDIT.DOC_YRLY_EXPENSE_COMPUTED InputScale: 2 OutputScale: 0
            //       F020_DOCTOR_AUDIT.DOC_YTDINC_G InputScale: 2 OutputScale: 0
            //       F020_DOCTOR_MSTR.DOC_YRLY_CEILING_COMPUTED InputScale: 2 OutputScale: 0
            //       F020_DOCTOR_MSTR.DOC_YRLY_EXPENSE_COMPUTED InputScale: 2 OutputScale: 0
            //       F020_DOCTOR_MSTR.DOC_YTDINC_G InputScale: 2 OutputScale: 0
            // TODO: The following FIELD(S) on the form are array elements.  Manual steps may be required:
            //       F199_USER_DEFINED_FIELDS.FIELD_DESC Occurs: 10
            //       F198_2ND_REC.USER_TOTAL Occurs: 10
            //       F198_USER_DEFINED_TOTALS.USER_TOTAL Occurs: 10
            //       F199_2ND_REC.FIELD_DESC Occurs: 10
            // TODO: The following FIELD(S) on the form are redefine elements.  Manual steps may be required:
            //       F020_DOCTOR_MSTR.DOC_INITS
            //       F020_DOCTOR_MSTR.DOC_DATE_FAC_START
            //       F020_DOCTOR_MSTR.DOC_DATE_FAC_TERM


        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF020_DOCTOR_EXTRA = new SqlFileObject(this, FileTypes.Secondary, 0, "INDEXED", "F020_DOCTOR_EXTRA", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF199_USER_DEFINED_FIELDS = new SqlFileObject(this, FileTypes.Designer, 0, "INDEXED", "F199_USER_DEFINED_FIELDS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF199_2ND_REC = new SqlFileObject(this, FileTypes.Designer, 0, "INDEXED", "F199_USER_DEFINED_FIELDS", "F199_2ND_REC", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF198_USER_DEFINED_TOTALS = new SqlFileObject(this, FileTypes.Designer, 0, "INDEXED", "F198_USER_DEFINED_TOTALS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF198_2ND_REC = new SqlFileObject(this, FileTypes.Designer, 0, "INDEXED", "F198_USER_DEFINED_TOTALS", "F198_2ND_REC", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF070_DEPT_MSTR = new SqlFileObject(this, FileTypes.Reference, 0, "[101C].INDEXED", "F070_DEPT_MSTR", "", false, false, false, 0, "m_cnnQUERY");
            fleF112_PYCDCEILINGS = new SqlFileObject(this, FileTypes.Designer, 0, "INDEXED", "F112_PYCDCEILINGS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleCONSTANTS_MSTR_REC_6 = new SqlFileObject(this, FileTypes.Designer, 0, "INDEXED", "CONSTANTS_MSTR_REC_6", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            A_DOC_NBR = new CoreCharacter("A_DOC_NBR", 3, this, Common.cEmptyString);
            A_DOC_DEPT = new CoreDecimal("A_DOC_DEPT", 2, this);
            A_DOC_OHIP_NBR = new CoreDecimal("A_DOC_OHIP_NBR", 6, this);
            A_DOC_SIN_NBR = new CoreDecimal("A_DOC_SIN_NBR", 9, this);
            A_DOC_CLINIC_NBR = new CoreDecimal("A_DOC_CLINIC_NBR", 2, this);
            A_DOC_SPEC_CD = new CoreDecimal("A_DOC_SPEC_CD", 2, this);
            A_DOC_HOSP_NBR = new CoreCharacter("A_DOC_HOSP_NBR", 4, this, Common.cEmptyString);
            A_DOC_NAME = new CoreCharacter("A_DOC_NAME", 24, this, Common.cEmptyString);
            A_DOC_NAME_SOUNDEX = new CoreCharacter("A_DOC_NAME_SOUNDEX", 4, this, Common.cEmptyString);
            A_DOC_INITS = new CoreCharacter("A_DOC_INITS", 3, this, Common.cEmptyString);
            A_DOC_FULL_PART_IND = new CoreCharacter("A_DOC_FULL_PART_IND", 1, this, Common.cEmptyString);
            A_DOC_BANK_NBR = new CoreDecimal("A_DOC_BANK_NBR", 4, this);
            A_DOC_BANK_BRANCH = new CoreDecimal("A_DOC_BANK_BRANCH", 5, this);
            A_DOC_BANK_ACCT = new CoreCharacter("A_DOC_BANK_ACCT", 12, this, Common.cEmptyString);
            A_DOC_DATE_FAC_START = new CoreDecimal("A_DOC_DATE_FAC_START", 8, this);
            A_DOC_DATE_FAC_TERM = new CoreDecimal("A_DOC_DATE_FAC_TERM", 8, this);
            A_DOC_YTDGUA = new CoreDecimal("A_DOC_YTDGUA", 9, this);
            A_DOC_YTDGUB = new CoreDecimal("A_DOC_YTDGUB", 9, this);
            A_DOC_YTDGUC = new CoreDecimal("A_DOC_YTDGUC", 9, this);
            A_DOC_YTDGUD = new CoreDecimal("A_DOC_YTDGUD", 9, this);
            A_DOC_YTDCEA = new CoreDecimal("A_DOC_YTDCEA", 9, this);
            A_DOC_YTDCEX = new CoreDecimal("A_DOC_YTDCEX", 9, this);
            A_DOC_YTDEAR = new CoreDecimal("A_DOC_YTDEAR", 9, this);
            A_DOC_YTDINC = new CoreDecimal("A_DOC_YTDINC", 9, this);
            A_DOC_YTDEFT = new CoreDecimal("A_DOC_YTDEFT", 9, this);
            A_DOC_TOTINC_G = new CoreDecimal("A_DOC_TOTINC_G", 9, this);
            A_DOC_EP_DATE_DEPOSIT = new CoreDecimal("A_DOC_EP_DATE_DEPOSIT", 8, this);
            A_DOC_TOTINC = new CoreDecimal("A_DOC_TOTINC", 9, this);
            A_DOC_EP_CEIEXP = new CoreDecimal("A_DOC_EP_CEIEXP", 9, this);
            A_DOC_ADJCEA = new CoreDecimal("A_DOC_ADJCEA", 9, this);
            A_DOC_ADJCEX = new CoreDecimal("A_DOC_ADJCEX", 9, this);
            A_DOC_CEICEA = new CoreDecimal("A_DOC_CEICEA", 9, this);
            A_DOC_CEICEX = new CoreDecimal("A_DOC_CEICEX", 9, this);
            A_DOC_CLINIC_NBR_2 = new CoreDecimal("A_DOC_CLINIC_NBR_2", 2, this);
            A_DOC_CLINIC_NBR_3 = new CoreDecimal("A_DOC_CLINIC_NBR_3", 2, this);
            A_DOC_CLINIC_NBR_4 = new CoreDecimal("A_DOC_CLINIC_NBR_4", 2, this);
            A_DOC_CLINIC_NBR_5 = new CoreDecimal("A_DOC_CLINIC_NBR_5", 2, this);
            A_DOC_CLINIC_NBR_6 = new CoreDecimal("A_DOC_CLINIC_NBR_6", 2, this);
            A_DOC_SPEC_CD_2 = new CoreDecimal("A_DOC_SPEC_CD_2", 2, this);
            A_DOC_SPEC_CD_3 = new CoreDecimal("A_DOC_SPEC_CD_3", 2, this);
            A_DOC_YTDINC_G = new CoreDecimal("A_DOC_YTDINC_G", 9, this);
            A_DOC_LOCATIONS = new CoreCharacter("A_DOC_LOCATIONS", 120, this, Common.cEmptyString);
            A_DOC_RMA_EXPENSE_PERCENT_MISC = new CoreInteger("A_DOC_RMA_EXPENSE_PERCENT_MISC", 9, this);
            A_DOC_AFP_PAYM_GROUP = new CoreCharacter("A_DOC_AFP_PAYM_GROUP", 4, this, Common.cEmptyString);
            A_DOC_DEPT_2 = new CoreDecimal("A_DOC_DEPT_2", 2, this);
            A_DOC_IND_PAYS_GST = new CoreCharacter("A_DOC_IND_PAYS_GST", 1, this, Common.cEmptyString);
            A_DOC_NX_AVAIL_BATCH = new CoreDecimal("A_DOC_NX_AVAIL_BATCH", 3, this);
            A_DOC_NX_AVAIL_BATCH_2 = new CoreDecimal("A_DOC_NX_AVAIL_BATCH_2", 3, this);
            A_DOC_NX_AVAIL_BATCH_3 = new CoreDecimal("A_DOC_NX_AVAIL_BATCH_3", 3, this);
            A_DOC_NX_AVAIL_BATCH_4 = new CoreDecimal("A_DOC_NX_AVAIL_BATCH_4", 3, this);
            A_DOC_NX_AVAIL_BATCH_5 = new CoreDecimal("A_DOC_NX_AVAIL_BATCH_5", 3, this);
            A_DOC_NX_AVAIL_BATCH_6 = new CoreDecimal("A_DOC_NX_AVAIL_BATCH_6", 3, this);
            A_DOC_YRLY_CEILING_COMPUTED = new CoreDecimal("A_DOC_YRLY_CEILING_COMPUTED", 9, this);
            A_DOC_YRLY_EXPENSE_COMPUTED = new CoreDecimal("A_DOC_YRLY_EXPENSE_COMPUTED", 9, this);
            A_DOC_RMA_EXPENSE_PERCENT_REG = new CoreInteger("A_DOC_RMA_EXPENSE_PERCENT_REG", 9, this);
            A_DOC_SUB_SPECIALTY = new CoreCharacter("A_DOC_SUB_SPECIALTY", 15, this, Common.cEmptyString);
            A_DOC_PAYEFT = new CoreDecimal("A_DOC_PAYEFT", 9, this);
            A_DOC_YTDDED = new CoreDecimal("A_DOC_YTDDED", 9, this);
            A_DOC_DEPT_EXPENSE_PERCENT_MISC = new CoreInteger("A_DOC_DEPT_EXPENSE_PERCENT_MISC", 9, this);
            A_DOC_DEPT_EXPENSE_PERCENT_REG = new CoreInteger("A_DOC_DEPT_EXPENSE_PERCENT_REG", 9, this);
            A_DOC_EP_PED = new CoreInteger("A_DOC_EP_PED", 9, this);
            A_DOC_EP_PAY_CODE = new CoreCharacter("A_DOC_EP_PAY_CODE", 1, this, Common.cEmptyString);
            A_DOC_EP_PAY_SUB_CODE = new CoreCharacter("A_DOC_EP_PAY_SUB_CODE", 1, this, Common.cEmptyString);
            A_DOC_PARTNERSHIP = new CoreCharacter("A_DOC_PARTNERSHIP", 1, this, Common.cEmptyString);
            A_DOC_IND_HOLDBACK_ACTIVE = new CoreCharacter("A_DOC_IND_HOLDBACK_ACTIVE", 1, this, Common.cEmptyString);
            A_GROUP_REGULAR_SERVICE = new CoreCharacter("A_GROUP_REGULAR_SERVICE", 4, this, Common.cEmptyString);
            A_GROUP_OVER_SERVICED = new CoreCharacter("A_GROUP_OVER_SERVICED", 4, this, Common.cEmptyString);
            A_DOC_SPECIALTIES = new CoreCharacter("A_DOC_SPECIALTIES", 90, this, Common.cEmptyString);
            A_DOC_YRLY_REQUIRE_REVENUE = new CoreDecimal("A_DOC_YRLY_REQUIRE_REVENUE", 9, this);
            A_DOC_YRLY_TARGET_REVENUE = new CoreDecimal("A_DOC_YRLY_TARGET_REVENUE", 9, this);
            A_DOC_CEIREQ = new CoreDecimal("A_DOC_CEIREQ", 9, this);
            A_DOC_YTDREQ = new CoreDecimal("A_DOC_YTDREQ", 9, this);
            A_DOC_CEITAR = new CoreDecimal("A_DOC_CEITAR", 9, this);
            A_DOC_YTDTAR = new CoreDecimal("A_DOC_YTDTAR", 9, this);
            A_BILLING_VIA_PAPER_FLAG = new CoreCharacter("A_BILLING_VIA_PAPER_FLAG", 1, this, Common.cEmptyString);
            A_BILLING_VIA_DISKETTE_FLAG = new CoreCharacter("A_BILLING_VIA_DISKETTE_FLAG", 1, this, Common.cEmptyString);
            A_BILLING_VIA_WEB_TEST_FLAG = new CoreCharacter("A_BILLING_VIA_WEB_TEST_FLAG", 1, this, Common.cEmptyString);
            A_BILLING_VIA_WEB_LIVE_FLAG = new CoreCharacter("A_BILLING_VIA_WEB_LIVE_FLAG", 1, this, Common.cEmptyString);
            A_BILLING_VIA_RMA_DATA_ENTRY = new CoreCharacter("A_BILLING_VIA_RMA_DATA_ENTRY", 1, this, Common.cEmptyString);
            A_DATE_START_RMA_DATA_ENTRY = new CoreDecimal("A_DATE_START_RMA_DATA_ENTRY", 8, this);
            A_DATE_START_DISKETTE = new CoreDecimal("A_DATE_START_DISKETTE", 8, this);
            A_DATE_START_PAPER = new CoreDecimal("A_DATE_START_PAPER", 8, this);
            A_DATE_START_WEB_LIVE = new CoreDecimal("A_DATE_START_WEB_LIVE", 8, this);
            A_DATE_START_WEB_TEST = new CoreDecimal("A_DATE_START_WEB_TEST", 8, this);
            A_LEAVE_DESCRIPTION = new CoreCharacter("A_LEAVE_DESCRIPTION", 30, this, Common.cEmptyString);
            A_LEAVE_DATE_START = new CoreDecimal("A_LEAVE_DATE_START", 8, this);
            A_LEAVE_DATE_END = new CoreDecimal("A_LEAVE_DATE_END", 8, this);
            A_WEB_USER_REVENUE_ONLY_FLAG = new CoreCharacter("A_WEB_USER_REVENUE_ONLY_FLAG", 1, this, Common.cEmptyString);
            A_MANAGER_FLAG = new CoreCharacter("A_MANAGER_FLAG", 1, this, Common.cEmptyString);
            A_CHAIR_FLAG = new CoreCharacter("A_CHAIR_FLAG", 1, this, Common.cEmptyString);
            A_ABE_USER_FLAG = new CoreCharacter("A_ABE_USER_FLAG", 1, this, Common.cEmptyString);
            A_CPSO_NBR = new CoreCharacter("A_CPSO_NBR", 6, this, Common.cEmptyString);
            A_CMPA_NBR = new CoreCharacter("A_CMPA_NBR", 9, this, Common.cEmptyString);
            A_OMA_NBR = new CoreCharacter("A_OMA_NBR", 10, this, Common.cEmptyString);
            A_CFPC_NBR = new CoreCharacter("A_CFPC_NBR", 7, this, Common.cEmptyString);
            A_RCPSC_NBR = new CoreCharacter("A_RCPSC_NBR", 7, this, Common.cEmptyString);
            A_DOC_MED_PROF_CORP = new CoreCharacter("A_DOC_MED_PROF_CORP", 1, this, Common.cEmptyString);
            A_MCMASTER_EMPLOYEE_ID = new CoreDecimal("A_MCMASTER_EMPLOYEE_ID", 7, this);
            A_DOC_SPEC_CD_EFF_DATE = new CoreDecimal("A_DOC_SPEC_CD_EFF_DATE", 8, this);
            A_DOC_SPEC_CD_2_EFF_DATE = new CoreDecimal("A_DOC_SPEC_CD_2_EFF_DATE", 8, this);
            A_DOC_SPEC_CD_3_EFF_DATE = new CoreDecimal("A_DOC_SPEC_CD_3_EFF_DATE", 8, this);
            A_DOC_CLINIC_NBR_STATUS = new CoreCharacter("A_DOC_CLINIC_NBR_STATUS", 1, this, Common.cEmptyString);
            A_DOC_CLINIC_NBR_2_STATUS = new CoreCharacter("A_DOC_CLINIC_NBR_2_STATUS", 1, this, Common.cEmptyString);
            A_DOC_CLINIC_NBR_3_STATUS = new CoreCharacter("A_DOC_CLINIC_NBR_3_STATUS", 1, this, Common.cEmptyString);
            A_DOC_CLINIC_NBR_4_STATUS = new CoreCharacter("A_DOC_CLINIC_NBR_4_STATUS", 1, this, Common.cEmptyString);
            A_DOC_CLINIC_NBR_5_STATUS = new CoreCharacter("A_DOC_CLINIC_NBR_5_STATUS", 1, this, Common.cEmptyString);
            A_DOC_CLINIC_NBR_6_STATUS = new CoreCharacter("A_DOC_CLINIC_NBR_6_STATUS", 1, this, Common.cEmptyString);
            A_FACTOR_GST_INCOME_REG = new CoreDecimal("A_FACTOR_GST_INCOME_REG", 5, this);
            A_FACTOR_GST_INCOME_MISC = new CoreDecimal("A_FACTOR_GST_INCOME_MISC", 5, this);
            A_YELLOW_PAGES_FLAG = new CoreCharacter("A_YELLOW_PAGES_FLAG", 1, this, Common.cEmptyString);
            A_REPLACED_BY_DOC_NBR = new CoreCharacter("A_REPLACED_BY_DOC_NBR", 3, this, Common.cEmptyString);
            A_PRIOR_DOC_NBR = new CoreCharacter("A_PRIOR_DOC_NBR", 3, this, Common.cEmptyString);
            A_COP_NBR = new CoreCharacter("A_COP_NBR", 8, this, Common.cEmptyString);
            A_DOC_FLAG_PRIMARY = new CoreCharacter("A_DOC_FLAG_PRIMARY", 1, this, Common.cEmptyString);
            A_HAS_VALID_CURRENT_PAYROLL_RECORD = new CoreCharacter("A_HAS_VALID_CURRENT_PAYROLL_RECORD", 1, this, Common.cEmptyString);
            A_PAY_THIS_DOCTOR_OHIP_PREMIUM = new CoreCharacter("A_PAY_THIS_DOCTOR_OHIP_PREMIUM", 1, this, Common.cEmptyString);
            A_DOC_FISCAL_YR_START_MONTH = new CoreDecimal("A_DOC_FISCAL_YR_START_MONTH", 2, this);
            fleF020_DOCTOR_AUDIT = new SqlFileObject(this, FileTypes.Designer, 0, "SEQUENTIAL", "F020_DOCTOR_AUDIT", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SequentialDataBase);
            X_DOC_NBR_LENGTH = new CoreDecimal("X_DOC_NBR_LENGTH", 6, this);
            W_CURRENT_PYCODE = new CoreCharacter("W_CURRENT_PYCODE", 1, this, Common.cEmptyString);
            W_CURRENT_PYSUBCODE = new CoreCharacter("W_CURRENT_PYSUBCODE", 1, this, Common.cEmptyString);
            W_CURR_CEIL_EARN = new CoreDecimal("W_CURR_CEIL_EARN", 6, this);
            W_CURR_CEIL_EXPN = new CoreDecimal("W_CURR_CEIL_EXPN", 6, this);
            W_PASSWORD = new CoreCharacter("W_PASSWORD", 5, this, Common.cEmptyString);
            W_DELETE_FLAG = new CoreCharacter("W_DELETE_FLAG", 1, this, Common.cEmptyString);
            W_OLD_PAY_CODE = new CoreCharacter("W_OLD_PAY_CODE", 1, this, Common.cEmptyString);
            W_DOC_NBR = new CoreCharacter("W_DOC_NBR", 3, this, Common.cEmptyString);
            W_EP_NBR_FROM = new CoreDecimal("W_EP_NBR_FROM", 4, this, ResetTypes.ResetAtStartup);
            W_EP_NBR_TO = new CoreDecimal("W_EP_NBR_TO", 4, this, ResetTypes.ResetAtStartup);
            W_EP_NBR_YY = new CoreDecimal("W_EP_NBR_YY", 6, this);
            fleF080_BANK_MSTR = new SqlFileObject(this, FileTypes.Reference, 0, "[101C].INDEXED", "F080_BANK_MSTR", "", false, false, false, 0, "m_cnnQUERY");
            W_DATE = new CoreDate("W_DATE", this);

           
            fleF020_DOCTOR_EXTRA.Access += fleF020_DOCTOR_EXTRA_Access;
            fleF070_DEPT_MSTR.Access += fleF070_DEPT_MSTR_Access;
            W_YEAR.GetValue += W_YEAR_GetValue;
            W_MTH.GetValue += W_MTH_GetValue;
            W_COMP_DATE.GetValue += W_COMP_DATE_GetValue;
            W_NOTE_TYPE.GetValue += W_NOTE_TYPE_GetValue;
            W_CURRENT_EP_NBR_MINUS_1.GetValue += W_CURRENT_EP_NBR_MINUS_1_GetValue;
            fleF080_BANK_MSTR.Access += fleF080_BANK_MSTR_Access;
            X_SCREEN_NAME.GetValue += X_SCREEN_NAME_GetValue;
            X_SCR_NAME.GetValue += X_SCR_NAME_GetValue;
            W_DATE.GetInitialValue += W_DATE_GetInitialValue;
            fleF020_DOCTOR_EXTRA.InitializeItems += fleF020_DOCTOR_EXTRA_AutomaticItemInitialization;
        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;
            fleF020_DOCTOR_EXTRA.Access -= fleF020_DOCTOR_EXTRA_Access;
            fleF070_DEPT_MSTR.Access -= fleF070_DEPT_MSTR_Access;
            W_YEAR.GetValue -= W_YEAR_GetValue;
            W_MTH.GetValue -= W_MTH_GetValue;
            W_COMP_DATE.GetValue -= W_COMP_DATE_GetValue;
            W_NOTE_TYPE.GetValue -= W_NOTE_TYPE_GetValue;
            W_CURRENT_EP_NBR_MINUS_1.GetValue -= W_CURRENT_EP_NBR_MINUS_1_GetValue;
            fleF080_BANK_MSTR.Access -= fleF080_BANK_MSTR_Access;
            X_SCREEN_NAME.GetValue -= X_SCREEN_NAME_GetValue;
            X_SCR_NAME.GetValue -= X_SCR_NAME_GetValue;
            fldF020_DOCTOR_MSTR_DOC_DEPT.LookupOn -= fldF020_DOCTOR_MSTR_DOC_DEPT_LookupOn;
            fldF020_DOCTOR_MSTR_DOC_NBR.Edit -= fldF020_DOCTOR_MSTR_DOC_NBR_Edit;
            fldF020_DOCTOR_MSTR_DOC_BANK_BRANCH.Edit -= fldF020_DOCTOR_MSTR_DOC_BANK_BRANCH_Edit;
            W_DATE.GetInitialValue -= W_DATE_GetInitialValue;
            dsrDesigner_91.Click -= dsrDesigner_91_Click;
            dsrDesigner_HI91.Click -= dsrDesigner_HI91_Click;
            dsrDesigner_92.Click -= dsrDesigner_92_Click;
            dsrDesigner_HI92.Click -= dsrDesigner_HI92_Click;
            dsrDesigner_93.Click -= dsrDesigner_93_Click;
            dsrDesigner_HI93.Click -= dsrDesigner_HI93_Click;
            dsrDesigner_94.Click -= dsrDesigner_94_Click;
            dsrDesigner_HI94.Click -= dsrDesigner_HI94_Click;
            dsrDesigner_95.Click -= dsrDesigner_95_Click;
            dsrDesigner_98.Click -= dsrDesigner_98_Click;
            dsrDesigner_HI98.Click -= dsrDesigner_HI98_Click;
            dsrDesigner_99.Click -= dsrDesigner_99_Click;
            dsrDesigner_TOT.Click -= dsrDesigner_TOT_Click;
            dsrDesigner_HTOT.Click -= dsrDesigner_HTOT_Click;
            dsrDesigner_ADJ.Click -= dsrDesigner_ADJ_Click;
            dsrDesigner_03.Click -= dsrDesigner_03_Click;
            dsrDesigner_04.Click -= dsrDesigner_04_Click;
            fldF020_DOCTOR_MSTR_DOC_BANK_NBR.Process -= fldF020_DOCTOR_MSTR_DOC_BANK_NBR_Process;
            fldF020_DOCTOR_MSTR_DOC_DATE_FAC_TERM.Process -= fldF020_DOCTOR_MSTR_DOC_DATE_FAC_TERM_Process;
            fleF020_DOCTOR_EXTRA.InitializeItems -= fleF020_DOCTOR_EXTRA_AutomaticItemInitialization;
        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private SqlConnection m_cnnQUERY = new SqlConnection();
        private SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
        private SqlTransaction m_trnTRANS_UPDATE;
        private SqlFileObject fleF020_DOCTOR_MSTR;
        private SqlFileObject fleF020_DOCTOR_EXTRA;
        //#-----------------------------------------
        //# fleF020_DOCTOR_EXTRA_Access Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/26/2017 10:17:26 AM
        //#-----------------------------------------
        private void fleF020_DOCTOR_EXTRA_Access(ref string AccessClause)
        {
            try
            {
                //TODO: Manual steps may be required.
                StringBuilder strText = new StringBuilder("");

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

        private SqlFileObject fleF199_USER_DEFINED_FIELDS;
        private SqlFileObject fleF199_2ND_REC;
        private SqlFileObject fleF198_USER_DEFINED_TOTALS;
        private SqlFileObject fleF198_2ND_REC;
        private SqlFileObject fleF070_DEPT_MSTR;

        private void fleF070_DEPT_MSTR_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleF070_DEPT_MSTR.ElementOwner("DEPT_NBR")).Append(" = ").Append((fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT")));

                strText.Append(" ORDER BY ").Append(fleF070_DEPT_MSTR.ElementOwner("DEPT_NBR"));
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

        private SqlFileObject fleF112_PYCDCEILINGS;
        private SqlFileObject fleCONSTANTS_MSTR_REC_6;
        //#CORE_BEGIN_INCLUDE: SAVEF020AUDIT_VAR"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/26/2017 10:17:25 AM

        private CoreCharacter A_DOC_NBR;
        private CoreDecimal A_DOC_DEPT;
        private CoreDecimal A_DOC_OHIP_NBR;
        private CoreDecimal A_DOC_SIN_NBR;
        private CoreDecimal A_DOC_CLINIC_NBR;
        private CoreDecimal A_DOC_SPEC_CD;
        private CoreCharacter A_DOC_HOSP_NBR;
        private CoreCharacter A_DOC_NAME;
        private CoreCharacter A_DOC_NAME_SOUNDEX;
        private CoreCharacter A_DOC_INITS;
        private CoreCharacter A_DOC_FULL_PART_IND;
        private CoreDecimal A_DOC_BANK_NBR;
        private CoreDecimal A_DOC_BANK_BRANCH;
        private CoreCharacter A_DOC_BANK_ACCT;
        private CoreDecimal A_DOC_DATE_FAC_START;
        private CoreDecimal A_DOC_DATE_FAC_TERM;
        private CoreDecimal A_DOC_YTDGUA;
        private CoreDecimal A_DOC_YTDGUB;
        private CoreDecimal A_DOC_YTDGUC;
        private CoreDecimal A_DOC_YTDGUD;
        private CoreDecimal A_DOC_YTDCEA;
        private CoreDecimal A_DOC_YTDCEX;
        private CoreDecimal A_DOC_YTDEAR;
        private CoreDecimal A_DOC_YTDINC;
        private CoreDecimal A_DOC_YTDEFT;
        private CoreDecimal A_DOC_TOTINC_G;
        private CoreDecimal A_DOC_EP_DATE_DEPOSIT;
        private CoreDecimal A_DOC_TOTINC;
        private CoreDecimal A_DOC_EP_CEIEXP;
        private CoreDecimal A_DOC_ADJCEA;
        private CoreDecimal A_DOC_ADJCEX;
        private CoreDecimal A_DOC_CEICEA;
        private CoreDecimal A_DOC_CEICEX;
        private CoreDecimal A_DOC_CLINIC_NBR_2;
        private CoreDecimal A_DOC_CLINIC_NBR_3;
        private CoreDecimal A_DOC_CLINIC_NBR_4;
        private CoreDecimal A_DOC_CLINIC_NBR_5;
        private CoreDecimal A_DOC_CLINIC_NBR_6;
        private CoreDecimal A_DOC_SPEC_CD_2;
        private CoreDecimal A_DOC_SPEC_CD_3;
        private CoreDecimal A_DOC_YTDINC_G;
        private CoreCharacter A_DOC_LOCATIONS;
        private CoreInteger A_DOC_RMA_EXPENSE_PERCENT_MISC;
        private CoreCharacter A_DOC_AFP_PAYM_GROUP;
        private CoreDecimal A_DOC_DEPT_2;
        private CoreCharacter A_DOC_IND_PAYS_GST;
        private CoreDecimal A_DOC_NX_AVAIL_BATCH;
        private CoreDecimal A_DOC_NX_AVAIL_BATCH_2;
        private CoreDecimal A_DOC_NX_AVAIL_BATCH_3;
        private CoreDecimal A_DOC_NX_AVAIL_BATCH_4;
        private CoreDecimal A_DOC_NX_AVAIL_BATCH_5;
        private CoreDecimal A_DOC_NX_AVAIL_BATCH_6;
        private CoreDecimal A_DOC_YRLY_CEILING_COMPUTED;
        private CoreDecimal A_DOC_YRLY_EXPENSE_COMPUTED;
        private CoreInteger A_DOC_RMA_EXPENSE_PERCENT_REG;
        private CoreCharacter A_DOC_SUB_SPECIALTY;
        private CoreDecimal A_DOC_PAYEFT;
        private CoreDecimal A_DOC_YTDDED;
        private CoreInteger A_DOC_DEPT_EXPENSE_PERCENT_MISC;
        private CoreInteger A_DOC_DEPT_EXPENSE_PERCENT_REG;
        private CoreInteger A_DOC_EP_PED;
        private CoreCharacter A_DOC_EP_PAY_CODE;
        private CoreCharacter A_DOC_EP_PAY_SUB_CODE;
        private CoreCharacter A_DOC_PARTNERSHIP;
        private CoreCharacter A_DOC_IND_HOLDBACK_ACTIVE;
        private CoreCharacter A_GROUP_REGULAR_SERVICE;
        private CoreCharacter A_GROUP_OVER_SERVICED;
        private CoreCharacter A_DOC_SPECIALTIES;
        private CoreDecimal A_DOC_YRLY_REQUIRE_REVENUE;
        private CoreDecimal A_DOC_YRLY_TARGET_REVENUE;
        private CoreDecimal A_DOC_CEIREQ;
        private CoreDecimal A_DOC_YTDREQ;
        private CoreDecimal A_DOC_CEITAR;
        private CoreDecimal A_DOC_YTDTAR;
        private CoreCharacter A_BILLING_VIA_PAPER_FLAG;
        private CoreCharacter A_BILLING_VIA_DISKETTE_FLAG;
        private CoreCharacter A_BILLING_VIA_WEB_TEST_FLAG;
        private CoreCharacter A_BILLING_VIA_WEB_LIVE_FLAG;
        private CoreCharacter A_BILLING_VIA_RMA_DATA_ENTRY;
        private CoreDecimal A_DATE_START_RMA_DATA_ENTRY;
        private CoreDecimal A_DATE_START_DISKETTE;
        private CoreDecimal A_DATE_START_PAPER;
        private CoreDecimal A_DATE_START_WEB_LIVE;
        private CoreDecimal A_DATE_START_WEB_TEST;
        private CoreCharacter A_LEAVE_DESCRIPTION;
        private CoreDecimal A_LEAVE_DATE_START;
        private CoreDecimal A_LEAVE_DATE_END;
        private CoreCharacter A_WEB_USER_REVENUE_ONLY_FLAG;
        private CoreCharacter A_MANAGER_FLAG;
        private CoreCharacter A_CHAIR_FLAG;
        private CoreCharacter A_ABE_USER_FLAG;
        private CoreCharacter A_CPSO_NBR;
        private CoreCharacter A_CMPA_NBR;
        private CoreCharacter A_OMA_NBR;
        private CoreCharacter A_CFPC_NBR;
        private CoreCharacter A_RCPSC_NBR;
        private CoreCharacter A_DOC_MED_PROF_CORP;
        private CoreDecimal A_MCMASTER_EMPLOYEE_ID;
        private CoreDecimal A_DOC_SPEC_CD_EFF_DATE;
        private CoreDecimal A_DOC_SPEC_CD_2_EFF_DATE;
        private CoreDecimal A_DOC_SPEC_CD_3_EFF_DATE;
        private CoreCharacter A_DOC_CLINIC_NBR_STATUS;
        private CoreCharacter A_DOC_CLINIC_NBR_2_STATUS;
        private CoreCharacter A_DOC_CLINIC_NBR_3_STATUS;
        private CoreCharacter A_DOC_CLINIC_NBR_4_STATUS;
        private CoreCharacter A_DOC_CLINIC_NBR_5_STATUS;
        private CoreCharacter A_DOC_CLINIC_NBR_6_STATUS;
        private CoreDecimal A_FACTOR_GST_INCOME_REG;
        private CoreDecimal A_FACTOR_GST_INCOME_MISC;
        private CoreCharacter A_YELLOW_PAGES_FLAG;
        private CoreCharacter A_REPLACED_BY_DOC_NBR;
        private CoreCharacter A_PRIOR_DOC_NBR;
        private CoreCharacter A_COP_NBR;
        private CoreCharacter A_DOC_FLAG_PRIMARY;
        private CoreCharacter A_HAS_VALID_CURRENT_PAYROLL_RECORD;
        private CoreCharacter A_PAY_THIS_DOCTOR_OHIP_PREMIUM;

        private CoreDecimal A_DOC_FISCAL_YR_START_MONTH;
        //#CORE_END_INCLUDE: SAVEF020AUDIT_VAR"

        private SqlFileObject fleF020_DOCTOR_AUDIT;
        private DDecimal W_YEAR = new DDecimal(6);
        private void W_YEAR_GetValue(ref decimal Value)
        {

            try
            {
                Value = QDesign.NConvert(QDesign.Substring(QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 6), 1, 2));


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DDecimal W_MTH = new DDecimal(6);
        private void W_MTH_GetValue(ref decimal Value)
        {

            try
            {
                Value = QDesign.NConvert(QDesign.Substring(QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 6), 3, 2));


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DDecimal W_COMP_DATE = new DDecimal(6);
        private void W_COMP_DATE_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0m;
                if (QDesign.NULL(W_MTH.Value) < 7)
                {
                    CurrentValue = QDesign.NConvert(QDesign.ASCII((W_YEAR.Value - 1), 2) + "0701");
                }
                else
                {
                    CurrentValue = QDesign.NConvert(QDesign.ASCII(W_YEAR.Value, 2) + "0701");
                }

                Value = CurrentValue;

            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DCharacter W_NOTE_TYPE = new DCharacter(1);
        private void W_NOTE_TYPE_GetValue(ref string Value)
        {

            try
            {
                Value = "A";


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private CoreDecimal X_DOC_NBR_LENGTH;
        private CoreCharacter W_CURRENT_PYCODE;
        private CoreCharacter W_CURRENT_PYSUBCODE;
        private CoreDecimal W_CURR_CEIL_EARN;
        private CoreDecimal W_CURR_CEIL_EXPN;
        private CoreCharacter W_PASSWORD;
        private CoreCharacter W_DELETE_FLAG;
        private CoreCharacter W_OLD_PAY_CODE;
        private CoreCharacter W_DOC_NBR;
        private CoreDecimal W_EP_NBR_FROM;
        private CoreDecimal W_EP_NBR_TO;
        private CoreDecimal W_EP_NBR_YY;
        private DDecimal W_CURRENT_EP_NBR_MINUS_1 = new DDecimal(6);
        private void W_CURRENT_EP_NBR_MINUS_1_GetValue(ref decimal Value)
        {

            try
            {
                Value = fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR") - 1;


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private SqlFileObject fleF080_BANK_MSTR;

        private void fleF080_BANK_MSTR_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleF080_BANK_MSTR.ElementOwner("BANK_CD")).Append(" = ").Append(Common.StringToField((QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_BANK_NBR"), 4) + QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_BANK_BRANCH"), 5))));

                strText.Append(" ORDER BY ").Append(fleF080_BANK_MSTR.ElementOwner("BANK_CD"));
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

        private CoreDate W_DATE;
        private void W_DATE_GetInitialValue()
        {
            W_DATE.InitialValue = QDesign.SysDate(ref m_cnnQUERY);
        }
        private DCharacter X_SCREEN_NAME = new DCharacter(55);
        private void X_SCREEN_NAME_GetValue(ref string Value)
        {

            try
            {
                Value = "PHYSICIAN EARNINGS Info";


            }
            catch (CustomApplicationException ex)
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
        //# Do not delete, modify or move it.  Updated: 5/26/2017 10:17:25 AM

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
        //# Do not delete, modify or move it.  Updated: 5/26/2017 10:17:26 AM

        //# No code was generated or needed for this region.

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/26/2017 10:17:26 AM

        //# No code was generated or needed for this region.

        #endregion

        #region "Transaction Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/26/2017 10:17:26 AM

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
            fleF020_DOCTOR_EXTRA.Transaction = m_trnTRANS_UPDATE;
            fleF199_USER_DEFINED_FIELDS.Transaction = m_trnTRANS_UPDATE;
            fleF199_2ND_REC.Transaction = m_trnTRANS_UPDATE;
            fleF198_USER_DEFINED_TOTALS.Transaction = m_trnTRANS_UPDATE;
            fleF198_2ND_REC.Transaction = m_trnTRANS_UPDATE;
            fleF112_PYCDCEILINGS.Transaction = m_trnTRANS_UPDATE;
            fleCONSTANTS_MSTR_REC_6.Transaction = m_trnTRANS_UPDATE;
            fleF020_DOCTOR_AUDIT.Transaction = m_trnTRANS_UPDATE;


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/26/2017 10:17:26 AM

        //#-----------------------------------------
        //# InitializeFiles Procedure.
        //#-----------------------------------------

        protected override void InitializeFiles()
        {

            try
            {
                Initialize_TRANS_UPDATE();
                fleF070_DEPT_MSTR.Connection = m_cnnQUERY;
                fleF080_BANK_MSTR.Connection = m_cnnQUERY;


            }
            catch (CustomApplicationException ex)
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
                fleF020_DOCTOR_EXTRA.Dispose();
                fleF199_USER_DEFINED_FIELDS.Dispose();
                fleF199_2ND_REC.Dispose();
                fleF198_USER_DEFINED_TOTALS.Dispose();
                fleF198_2ND_REC.Dispose();
                fleF070_DEPT_MSTR.Dispose();
                fleF112_PYCDCEILINGS.Dispose();
                fleCONSTANTS_MSTR_REC_6.Dispose();
                fleF020_DOCTOR_AUDIT.Dispose();
                fleF080_BANK_MSTR.Dispose();


            }
            catch (CustomApplicationException ex)
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/26/2017 10:17:26 AM
        //#-----------------------------------------
        protected override void DisplayFormatting()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/26/2017 10:17:26 AM
                Display(ref fldF020_DOCTOR_MSTR_DOC_NBR);
                Display(ref fldF020_DOCTOR_MSTR_DOC_NAME);
                Display(ref fldF020_DOCTOR_MSTR_DOC_INITS);
                Display(ref fldF020_DOCTOR_MSTR_DOC_OHIP_NBR);
                Display(ref fldF020_DOCTOR_MSTR_DOC_DEPT);
                Display(ref fldF070_DEPT_MSTR_DEPT_NAME);
                Display(ref fldF020_DOCTOR_MSTR_DOC_FULL_PART_IND);
                Display(ref fldF020_DOCTOR_MSTR_DOC_DATE_FAC_START);
                Display(ref fldF020_DOCTOR_MSTR_DOC_DATE_FAC_TERM);
                Display(ref fldW_CURRENT_PYCODE);
                Display(ref fldW_CURRENT_PYSUBCODE);
                Display(ref fldW_CURR_CEIL_EARN);
                Display(ref fldW_CURR_CEIL_EXPN);
                Display(ref fldF020_DOCTOR_MSTR_DOC_BANK_NBR);
                Display(ref fldF020_DOCTOR_MSTR_DOC_YRLY_CEILING_COMPUTED);
                Display(ref fldF020_DOCTOR_MSTR_DOC_YRLY_EXPENSE_COMPUTED);
                Display(ref fldF020_DOCTOR_MSTR_DOC_BANK_BRANCH);
                Display(ref fldF020_DOCTOR_MSTR_DOC_RMA_EXPENSE_PERCENT_REG);
                Display(ref fldF020_DOCTOR_MSTR_DOC_RMA_EXPENSE_PERCENT_MISC);
                Display(ref fldF020_DOCTOR_MSTR_DOC_BANK_ACCT);
                Display(ref fldF020_DOCTOR_MSTR_DOC_DEPT_EXPENSE_PERCENT_REG);
                Display(ref fldF020_DOCTOR_MSTR_DOC_DEPT_EXPENSE_PERCENT_MISC);
                Display(ref fldF020_DOCTOR_MSTR_DOC_IND_PAYS_GST);
                Display(ref fldF020_DOCTOR_MSTR_DOC_IND_HOLDBACK_ACTIVE);
                Display(ref fldF020_DOCTOR_MSTR_DOC_AFP_PAYM_GROUP);
                Display(ref fldW_EP_NBR_FROM);
                Display(ref fldW_EP_NBR_YY);
                Display(ref fldF199_USER_DEFINED_FIELDS_FIELD_DESC1);
                Display(ref fldF198_USER_DEFINED_TOTALS_USER_TOTAL1);
                Display(ref fldF199_2ND_REC_FIELD_DESC1);
                Display(ref fldF198_2ND_REC_USER_TOTAL1);
                Display(ref fldF199_USER_DEFINED_FIELDS_FIELD_DESC2);
                Display(ref fldF198_USER_DEFINED_TOTALS_USER_TOTAL2);
                Display(ref fldF199_2ND_REC_FIELD_DESC2);
                Display(ref fldF198_2ND_REC_USER_TOTAL2);
                Display(ref fldF199_USER_DEFINED_FIELDS_FIELD_DESC3);
                Display(ref fldF198_USER_DEFINED_TOTALS_USER_TOTAL3);
                Display(ref fldF199_2ND_REC_FIELD_DESC3);
                Display(ref fldF198_2ND_REC_USER_TOTAL3);
                Display(ref fldF199_USER_DEFINED_FIELDS_FIELD_DESC4);
                Display(ref fldF198_USER_DEFINED_TOTALS_USER_TOTAL4);
                Display(ref fldF199_2ND_REC_FIELD_DESC4);
                Display(ref fldF198_2ND_REC_USER_TOTAL4);
                Display(ref fldF199_USER_DEFINED_FIELDS_FIELD_DESC5);
                Display(ref fldF198_USER_DEFINED_TOTALS_USER_TOTAL5);
                Display(ref fldF199_2ND_REC_FIELD_DESC5);
                Display(ref fldF198_2ND_REC_USER_TOTAL5);
                Display(ref fldF199_USER_DEFINED_FIELDS_FIELD_DESC6);
                Display(ref fldF198_USER_DEFINED_TOTALS_USER_TOTAL6);
                Display(ref fldF199_2ND_REC_FIELD_DESC6);
                Display(ref fldF198_2ND_REC_USER_TOTAL6);
                Display(ref fldF199_USER_DEFINED_FIELDS_FIELD_DESC7);
                Display(ref fldF198_USER_DEFINED_TOTALS_USER_TOTAL7);
                Display(ref fldF199_2ND_REC_FIELD_DESC7);
                Display(ref fldF198_2ND_REC_USER_TOTAL7);
                Display(ref fldF199_USER_DEFINED_FIELDS_FIELD_DESC8);
                Display(ref fldF198_USER_DEFINED_TOTALS_USER_TOTAL8);
                Display(ref fldF199_2ND_REC_FIELD_DESC8);
                Display(ref fldF198_2ND_REC_USER_TOTAL8);
                Display(ref fldF199_USER_DEFINED_FIELDS_FIELD_DESC9);
                Display(ref fldF198_USER_DEFINED_TOTALS_USER_TOTAL9);
                Display(ref fldF199_2ND_REC_FIELD_DESC9);
                Display(ref fldF198_2ND_REC_USER_TOTAL9);
                Display(ref fldF199_USER_DEFINED_FIELDS_FIELD_DESC10);
                Display(ref fldF198_USER_DEFINED_TOTALS_USER_TOTAL10);
                Display(ref fldF199_2ND_REC_FIELD_DESC10);
                Display(ref fldF198_2ND_REC_USER_TOTAL10);
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
        //# Do not delete, modify or move it.  Updated: 5/26/2017 10:17:26 AM

        //#-----------------------------------------
        //# BindFields Procedure.
        //#-----------------------------------------

        public override void BindFields()
        {
            try
            {
                fldF020_DOCTOR_MSTR_DOC_NBR.Bind(fleF020_DOCTOR_MSTR);
                fldF020_DOCTOR_MSTR_DOC_NAME.Bind(fleF020_DOCTOR_MSTR);
                fldF020_DOCTOR_MSTR_DOC_INITS.Bind(fleF020_DOCTOR_MSTR);
                fldF020_DOCTOR_MSTR_DOC_OHIP_NBR.Bind(fleF020_DOCTOR_MSTR);
                fldF020_DOCTOR_MSTR_DOC_DEPT.Bind(fleF020_DOCTOR_MSTR);
                fldF070_DEPT_MSTR_DEPT_NAME.Bind(fleF070_DEPT_MSTR);
                fldF020_DOCTOR_MSTR_DOC_FULL_PART_IND.Bind(fleF020_DOCTOR_MSTR);
                fldF020_DOCTOR_MSTR_DOC_DATE_FAC_START.Bind(fleF020_DOCTOR_MSTR);
                fldF020_DOCTOR_MSTR_DOC_DATE_FAC_TERM.Bind(fleF020_DOCTOR_MSTR);
                fldW_CURRENT_PYCODE.Bind(W_CURRENT_PYCODE);
                fldW_CURRENT_PYSUBCODE.Bind(W_CURRENT_PYSUBCODE);
                fldW_CURR_CEIL_EARN.Bind(W_CURR_CEIL_EARN);
                fldW_CURR_CEIL_EXPN.Bind(W_CURR_CEIL_EXPN);
                fldF020_DOCTOR_MSTR_DOC_BANK_NBR.Bind(fleF020_DOCTOR_MSTR);
                fldF020_DOCTOR_MSTR_DOC_YRLY_CEILING_COMPUTED.Bind(fleF020_DOCTOR_MSTR);
                fldF020_DOCTOR_MSTR_DOC_YRLY_EXPENSE_COMPUTED.Bind(fleF020_DOCTOR_MSTR);
                fldF020_DOCTOR_MSTR_DOC_BANK_BRANCH.Bind(fleF020_DOCTOR_MSTR);
                fldF020_DOCTOR_MSTR_DOC_RMA_EXPENSE_PERCENT_REG.Bind(fleF020_DOCTOR_MSTR);
                fldF020_DOCTOR_MSTR_DOC_RMA_EXPENSE_PERCENT_MISC.Bind(fleF020_DOCTOR_MSTR);
                fldF020_DOCTOR_MSTR_DOC_BANK_ACCT.Bind(fleF020_DOCTOR_MSTR);
                fldF020_DOCTOR_MSTR_DOC_DEPT_EXPENSE_PERCENT_REG.Bind(fleF020_DOCTOR_MSTR);
                fldF020_DOCTOR_MSTR_DOC_DEPT_EXPENSE_PERCENT_MISC.Bind(fleF020_DOCTOR_MSTR);
                fldF020_DOCTOR_MSTR_DOC_IND_PAYS_GST.Bind(fleF020_DOCTOR_MSTR);
                fldF020_DOCTOR_MSTR_DOC_IND_HOLDBACK_ACTIVE.Bind(fleF020_DOCTOR_MSTR);
                fldF020_DOCTOR_MSTR_DOC_AFP_PAYM_GROUP.Bind(fleF020_DOCTOR_MSTR);
                fldW_EP_NBR_FROM.Bind(W_EP_NBR_FROM);
                fldW_EP_NBR_YY.Bind(W_EP_NBR_YY);
                fldF199_USER_DEFINED_FIELDS_FIELD_DESC1.Bind(fleF199_USER_DEFINED_FIELDS);
                fldF198_USER_DEFINED_TOTALS_USER_TOTAL1.Bind(fleF198_USER_DEFINED_TOTALS);
                fldF199_2ND_REC_FIELD_DESC1.Bind(fleF199_2ND_REC);
                fldF198_2ND_REC_USER_TOTAL1.Bind(fleF198_2ND_REC);
                fldF199_USER_DEFINED_FIELDS_FIELD_DESC2.Bind(fleF199_USER_DEFINED_FIELDS);
                fldF198_USER_DEFINED_TOTALS_USER_TOTAL2.Bind(fleF198_USER_DEFINED_TOTALS);
                fldF199_2ND_REC_FIELD_DESC2.Bind(fleF199_2ND_REC);
                fldF198_2ND_REC_USER_TOTAL2.Bind(fleF198_2ND_REC);
                fldF199_USER_DEFINED_FIELDS_FIELD_DESC3.Bind(fleF199_USER_DEFINED_FIELDS);
                fldF198_USER_DEFINED_TOTALS_USER_TOTAL3.Bind(fleF198_USER_DEFINED_TOTALS);
                fldF199_2ND_REC_FIELD_DESC3.Bind(fleF199_2ND_REC);
                fldF198_2ND_REC_USER_TOTAL3.Bind(fleF198_2ND_REC);
                fldF199_USER_DEFINED_FIELDS_FIELD_DESC4.Bind(fleF199_USER_DEFINED_FIELDS);
                fldF198_USER_DEFINED_TOTALS_USER_TOTAL4.Bind(fleF198_USER_DEFINED_TOTALS);
                fldF199_2ND_REC_FIELD_DESC4.Bind(fleF199_2ND_REC);
                fldF198_2ND_REC_USER_TOTAL4.Bind(fleF198_2ND_REC);
                fldF199_USER_DEFINED_FIELDS_FIELD_DESC5.Bind(fleF199_USER_DEFINED_FIELDS);
                fldF198_USER_DEFINED_TOTALS_USER_TOTAL5.Bind(fleF198_USER_DEFINED_TOTALS);
                fldF199_2ND_REC_FIELD_DESC5.Bind(fleF199_2ND_REC);
                fldF198_2ND_REC_USER_TOTAL5.Bind(fleF198_2ND_REC);
                fldF199_USER_DEFINED_FIELDS_FIELD_DESC6.Bind(fleF199_USER_DEFINED_FIELDS);
                fldF198_USER_DEFINED_TOTALS_USER_TOTAL6.Bind(fleF198_USER_DEFINED_TOTALS);
                fldF199_2ND_REC_FIELD_DESC6.Bind(fleF199_2ND_REC);
                fldF198_2ND_REC_USER_TOTAL6.Bind(fleF198_2ND_REC);
                fldF199_USER_DEFINED_FIELDS_FIELD_DESC7.Bind(fleF199_USER_DEFINED_FIELDS);
                fldF198_USER_DEFINED_TOTALS_USER_TOTAL7.Bind(fleF198_USER_DEFINED_TOTALS);
                fldF199_2ND_REC_FIELD_DESC7.Bind(fleF199_2ND_REC);
                fldF198_2ND_REC_USER_TOTAL7.Bind(fleF198_2ND_REC);
                fldF199_USER_DEFINED_FIELDS_FIELD_DESC8.Bind(fleF199_USER_DEFINED_FIELDS);
                fldF198_USER_DEFINED_TOTALS_USER_TOTAL8.Bind(fleF198_USER_DEFINED_TOTALS);
                fldF199_2ND_REC_FIELD_DESC8.Bind(fleF199_2ND_REC);
                fldF198_2ND_REC_USER_TOTAL8.Bind(fleF198_2ND_REC);
                fldF199_USER_DEFINED_FIELDS_FIELD_DESC9.Bind(fleF199_USER_DEFINED_FIELDS);
                fldF198_USER_DEFINED_TOTALS_USER_TOTAL9.Bind(fleF198_USER_DEFINED_TOTALS);
                fldF199_2ND_REC_FIELD_DESC9.Bind(fleF199_2ND_REC);
                fldF198_2ND_REC_USER_TOTAL9.Bind(fleF198_2ND_REC);
                fldF199_USER_DEFINED_FIELDS_FIELD_DESC10.Bind(fleF199_USER_DEFINED_FIELDS);
                fldF198_USER_DEFINED_TOTALS_USER_TOTAL10.Bind(fleF198_USER_DEFINED_TOTALS);
                fldF199_2ND_REC_FIELD_DESC10.Bind(fleF199_2ND_REC);
                fldF198_2ND_REC_USER_TOTAL10.Bind(fleF198_2ND_REC);

            }
            catch (CustomApplicationException ex)
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

        private void fleF020_DOCTOR_EXTRA_AutomaticItemInitialization(bool Fixed)
        {
            try
            {
                //TODO: Manual steps may be required.
                fleF020_DOCTOR_EXTRA.set_SetValue("DOC_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR"));

            }
            catch (CustomApplicationException ex)
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

        #region "Renaissance Architect Generated 4GL Procedures"



        private void fldF020_DOCTOR_MSTR_DOC_DEPT_LookupOn()
        {

            try
            {
                StringBuilder strSQL = new StringBuilder(" WHERE ");
                strSQL.Append("     ").Append(fleF070_DEPT_MSTR.ElementOwner("DEPT_NBR")).Append(" = ").Append((FieldValue));

                fleF070_DEPT_MSTR.GetData(strSQL.ToString(), GetDataOptions.IsOptional);
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

        //#CORE_BEGIN_INCLUDE: SAVEF020AUDIT_MP"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/26/2017 10:17:25 AM

        private bool Internal_SAVEF020AUDIT()
        {


            try
            {

                A_DOC_NBR.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR");
                A_DOC_DEPT.Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT");
                A_DOC_OHIP_NBR.Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR");
                A_DOC_SIN_NBR.Value = Convert.ToDecimal(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SIN_123").ToString() + fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SIN_456").ToString() + fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SIN_789").ToString());
                //A_DOC_CLINIC_NBR.Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CLINIC_NBR");
                A_DOC_SPEC_CD.Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD");
                A_DOC_HOSP_NBR.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_HOSP_NBR");
                A_DOC_NAME.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_NAME");
                A_DOC_NAME_SOUNDEX.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_NAME_SOUNDEX");
                A_DOC_INITS.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT3");
                //Parent:DOC_INITS
                A_DOC_FULL_PART_IND.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_FULL_PART_IND");
                A_DOC_BANK_NBR.Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_BANK_NBR");
                A_DOC_BANK_BRANCH.Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_BANK_BRANCH");
                A_DOC_BANK_ACCT.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_BANK_ACCT");
                A_DOC_DATE_FAC_START.Value = Convert.ToDecimal(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_START_YY").ToString().PadLeft(4, '0') + fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_START_MM").ToString().PadLeft(2, '0') + fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_START_DD").ToString().PadLeft(2, '0'));
                A_DOC_DATE_FAC_TERM.Value = Convert.ToDecimal(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_YY").ToString().PadLeft(4, '0') + fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_MM").ToString().PadLeft(2, '0') + fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_DD").ToString().PadLeft(2, '0'));
                A_DOC_YTDGUA.Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUA");
                A_DOC_YTDGUB.Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUB");
                A_DOC_YTDGUC.Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUC");
                A_DOC_YTDGUD.Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUD");
                A_DOC_YTDCEA.Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDCEA");
                A_DOC_YTDCEX.Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDCEX");
                A_DOC_YTDEAR.Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDEAR");
                A_DOC_YTDINC.Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDINC");
                A_DOC_YTDEFT.Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDEFT");
                A_DOC_TOTINC_G.Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_TOTINC_G");
                A_DOC_EP_DATE_DEPOSIT.Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_EP_DATE_DEPOSIT");
                A_DOC_TOTINC.Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_TOTINC");
                A_DOC_EP_CEIEXP.Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_EP_CEIEXP");
                A_DOC_ADJCEA.Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADJCEA");
                A_DOC_ADJCEX.Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADJCEX");
                A_DOC_CEICEA.Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CEICEA");
                A_DOC_CEICEX.Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CEICEX");
                //A_DOC_CLINIC_NBR_2.Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CLINIC_NBR_2");
                //A_DOC_CLINIC_NBR_3.Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CLINIC_NBR_3");
                //A_DOC_CLINIC_NBR_4.Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CLINIC_NBR_4");
                //A_DOC_CLINIC_NBR_5.Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CLINIC_NBR_5");
                //A_DOC_CLINIC_NBR_6.Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CLINIC_NBR_6");
                A_DOC_SPEC_CD_2.Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2");
                A_DOC_SPEC_CD_3.Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3");
                A_DOC_YTDINC_G.Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDINC_G");
                //A_DOC_LOCATIONS.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_4") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_5") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_6") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_7") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_8") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_9") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_10") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_11") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_12") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_13") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_14") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_15") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_16") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_17") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_18") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_19") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_20") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_21") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_22") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_23") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_24") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_25") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_26") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_27") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_28") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_29") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_30");
                //Parent:DOC_LOCATIONS
                A_DOC_RMA_EXPENSE_PERCENT_MISC.Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_MISC");
                A_DOC_AFP_PAYM_GROUP.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP");
                A_DOC_DEPT_2.Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT_2");
                A_DOC_IND_PAYS_GST.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_IND_PAYS_GST");
                A_DOC_NX_AVAIL_BATCH.Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH");
                A_DOC_NX_AVAIL_BATCH_2.Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_2");
                A_DOC_NX_AVAIL_BATCH_3.Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_3");
                A_DOC_NX_AVAIL_BATCH_4.Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_4");
                A_DOC_NX_AVAIL_BATCH_5.Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_5");
                A_DOC_NX_AVAIL_BATCH_6.Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_6");
                A_DOC_YRLY_CEILING_COMPUTED.Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YRLY_CEILING_COMPUTED");
                A_DOC_YRLY_EXPENSE_COMPUTED.Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YRLY_EXPENSE_COMPUTED");
                A_DOC_RMA_EXPENSE_PERCENT_REG.Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_REG");
                A_DOC_SUB_SPECIALTY.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_SUB_SPECIALTY");
                A_DOC_PAYEFT.Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_PAYEFT");
                A_DOC_YTDDED.Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDDED");
                A_DOC_DEPT_EXPENSE_PERCENT_MISC.Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_MISC");
                A_DOC_DEPT_EXPENSE_PERCENT_REG.Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_REG");
                A_DOC_EP_PED.Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_EP_PED");
                A_DOC_EP_PAY_CODE.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_EP_PAY_CODE");
                A_DOC_EP_PAY_SUB_CODE.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_EP_PAY_SUB_CODE");
                A_DOC_PARTNERSHIP.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_PARTNERSHIP");
                A_DOC_IND_HOLDBACK_ACTIVE.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_IND_HOLDBACK_ACTIVE");
                A_GROUP_REGULAR_SERVICE.Value = fleF020_DOCTOR_MSTR.GetStringValue("GROUP_REGULAR_SERVICE");
                A_GROUP_OVER_SERVICED.Value = fleF020_DOCTOR_MSTR.GetStringValue("GROUP_OVER_SERVICED");
                //A_DOC_SPECIALTIES.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_1_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_1_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_1_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_2_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_2_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_2_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_3_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_3_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_3_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_4_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_4_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_4_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_5_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_5_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_5_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_6_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_6_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_6_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_7_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_7_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_7_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_8_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_8_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_8_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_9_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_9_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_9_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_10_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_10_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_10_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_11_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_11_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_11_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_12_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_12_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_12_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_13_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_13_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_13_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_14_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_14_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_14_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_15_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_15_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_15_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_16_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_16_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_16_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_17_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_17_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_17_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_18_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_18_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_18_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_19_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_19_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_19_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_20_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_20_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_20_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_21_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_21_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_21_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_22_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_22_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_22_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_23_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_23_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_23_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_24_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_24_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_24_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_25_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_25_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_25_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_26_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_26_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_26_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_27_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_27_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_27_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_28_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_28_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_28_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_29_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_29_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_29_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_30_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_30_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_30_S3");
                //Parent:DOC_SPECIALTIES
                A_DOC_YRLY_REQUIRE_REVENUE.Value = fleF020_DOCTOR_EXTRA.GetDecimalValue("DOC_YRLY_REQUIRE_REVENUE");
                A_DOC_YRLY_TARGET_REVENUE.Value = fleF020_DOCTOR_EXTRA.GetDecimalValue("DOC_YRLY_TARGET_REVENUE");
                A_DOC_CEIREQ.Value = fleF020_DOCTOR_EXTRA.GetDecimalValue("DOC_CEIREQ");
                A_DOC_YTDREQ.Value = fleF020_DOCTOR_EXTRA.GetDecimalValue("DOC_YTDREQ");
                A_DOC_CEITAR.Value = fleF020_DOCTOR_EXTRA.GetDecimalValue("DOC_CEITAR");
                A_DOC_YTDTAR.Value = fleF020_DOCTOR_EXTRA.GetDecimalValue("DOC_YTDTAR");
                A_BILLING_VIA_PAPER_FLAG.Value = fleF020_DOCTOR_EXTRA.GetStringValue("BILLING_VIA_PAPER_FLAG");
                A_BILLING_VIA_DISKETTE_FLAG.Value = fleF020_DOCTOR_EXTRA.GetStringValue("BILLING_VIA_DISKETTE_FLAG");
                A_BILLING_VIA_WEB_TEST_FLAG.Value = fleF020_DOCTOR_EXTRA.GetStringValue("BILLING_VIA_WEB_TEST_FLAG");
                A_BILLING_VIA_WEB_LIVE_FLAG.Value = fleF020_DOCTOR_EXTRA.GetStringValue("BILLING_VIA_WEB_LIVE_FLAG");
                A_BILLING_VIA_RMA_DATA_ENTRY.Value = fleF020_DOCTOR_EXTRA.GetStringValue("BILLING_VIA_RMA_DATA_ENTRY");
                A_DATE_START_RMA_DATA_ENTRY.Value = fleF020_DOCTOR_EXTRA.GetDecimalValue("DATE_START_RMA_DATA_ENTRY");
                A_DATE_START_DISKETTE.Value = fleF020_DOCTOR_EXTRA.GetDecimalValue("DATE_START_DISKETTE");
                A_DATE_START_PAPER.Value = fleF020_DOCTOR_EXTRA.GetDecimalValue("DATE_START_PAPER");
                A_DATE_START_WEB_LIVE.Value = fleF020_DOCTOR_EXTRA.GetDecimalValue("DATE_START_WEB_LIVE");
                A_DATE_START_WEB_TEST.Value = fleF020_DOCTOR_EXTRA.GetDecimalValue("DATE_START_WEB_TEST");
                A_LEAVE_DESCRIPTION.Value = fleF020_DOCTOR_EXTRA.GetStringValue("LEAVE_DESCRIPTION");
                A_LEAVE_DATE_START.Value = fleF020_DOCTOR_EXTRA.GetDecimalValue("LEAVE_DATE_START");
                A_LEAVE_DATE_END.Value = fleF020_DOCTOR_EXTRA.GetDecimalValue("LEAVE_DATE_END");
                A_WEB_USER_REVENUE_ONLY_FLAG.Value = fleF020_DOCTOR_EXTRA.GetStringValue("WEB_USER_REVENUE_ONLY_FLAG");
                A_MANAGER_FLAG.Value = fleF020_DOCTOR_EXTRA.GetStringValue("MANAGER_FLAG");
                A_CHAIR_FLAG.Value = fleF020_DOCTOR_EXTRA.GetStringValue("CHAIR_FLAG");
                A_ABE_USER_FLAG.Value = fleF020_DOCTOR_EXTRA.GetStringValue("ABE_USER_FLAG");
                A_CPSO_NBR.Value = fleF020_DOCTOR_EXTRA.GetStringValue("CPSO_NBR");
                A_CMPA_NBR.Value = fleF020_DOCTOR_EXTRA.GetStringValue("CMPA_NBR");
                A_OMA_NBR.Value = fleF020_DOCTOR_EXTRA.GetStringValue("OMA_NBR");
                A_CFPC_NBR.Value = fleF020_DOCTOR_EXTRA.GetStringValue("CFPC_NBR");
                A_RCPSC_NBR.Value = fleF020_DOCTOR_EXTRA.GetStringValue("RCPSC_NBR");
                A_DOC_MED_PROF_CORP.Value = fleF020_DOCTOR_EXTRA.GetStringValue("DOC_MED_PROF_CORP");
                A_MCMASTER_EMPLOYEE_ID.Value = fleF020_DOCTOR_EXTRA.GetDecimalValue("MCMASTER_EMPLOYEE_ID");
                A_DOC_SPEC_CD_EFF_DATE.Value = fleF020_DOCTOR_EXTRA.GetDecimalValue("DOC_SPEC_CD_EFF_DATE");
                A_DOC_SPEC_CD_2_EFF_DATE.Value = fleF020_DOCTOR_EXTRA.GetDecimalValue("DOC_SPEC_CD_2_EFF_DATE");
                A_DOC_SPEC_CD_3_EFF_DATE.Value = fleF020_DOCTOR_EXTRA.GetDecimalValue("DOC_SPEC_CD_3_EFF_DATE");
                //A_DOC_CLINIC_NBR_STATUS.Value = fleF020_DOCTOR_EXTRA.GetStringValue("DOC_CLINIC_NBR_STATUS");
                //A_DOC_CLINIC_NBR_2_STATUS.Value = fleF020_DOCTOR_EXTRA.GetStringValue("DOC_CLINIC_NBR_2_STATUS");
                //A_DOC_CLINIC_NBR_3_STATUS.Value = fleF020_DOCTOR_EXTRA.GetStringValue("DOC_CLINIC_NBR_3_STATUS");
                //A_DOC_CLINIC_NBR_4_STATUS.Value = fleF020_DOCTOR_EXTRA.GetStringValue("DOC_CLINIC_NBR_4_STATUS");
                //A_DOC_CLINIC_NBR_5_STATUS.Value = fleF020_DOCTOR_EXTRA.GetStringValue("DOC_CLINIC_NBR_5_STATUS");
                //A_DOC_CLINIC_NBR_6_STATUS.Value = fleF020_DOCTOR_EXTRA.GetStringValue("DOC_CLINIC_NBR_6_STATUS");
                A_FACTOR_GST_INCOME_REG.Value = fleF020_DOCTOR_EXTRA.GetDecimalValue("FACTOR_GST_INCOME_REG");
                A_FACTOR_GST_INCOME_MISC.Value = fleF020_DOCTOR_EXTRA.GetDecimalValue("FACTOR_GST_INCOME_MISC");
                A_YELLOW_PAGES_FLAG.Value = fleF020_DOCTOR_EXTRA.GetStringValue("YELLOW_PAGES_FLAG");
                A_REPLACED_BY_DOC_NBR.Value = fleF020_DOCTOR_EXTRA.GetStringValue("REPLACED_BY_DOC_NBR");
                A_PRIOR_DOC_NBR.Value = fleF020_DOCTOR_EXTRA.GetStringValue("PRIOR_DOC_NBR");
                A_COP_NBR.Value = fleF020_DOCTOR_EXTRA.GetStringValue("COP_NBR");
                A_DOC_FLAG_PRIMARY.Value = fleF020_DOCTOR_EXTRA.GetStringValue("DOC_FLAG_PRIMARY");
                A_HAS_VALID_CURRENT_PAYROLL_RECORD.Value = fleF020_DOCTOR_EXTRA.GetStringValue("HAS_VALID_CURRENT_PAYROLL_RECORD");
                A_PAY_THIS_DOCTOR_OHIP_PREMIUM.Value = fleF020_DOCTOR_EXTRA.GetStringValue("PAY_THIS_DOCTOR_OHIP_PREMIUM");
                A_DOC_FISCAL_YR_START_MONTH.Value = fleF020_DOCTOR_EXTRA.GetDecimalValue("DOC_FISCAL_YR_START_MONTH");

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

        //#CORE_END_INCLUDE: SAVEF020AUDIT_MP"


        //#CORE_BEGIN_INCLUDE: CREATEF020AUDIT_MP"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/26/2017 10:17:25 AM

        private bool Internal_CREATEF020AUDIT_BEFORE()
        {


            try
            {

                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_NBR", A_DOC_NBR.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_DEPT", A_DOC_DEPT.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_OHIP_NBR", A_DOC_OHIP_NBR.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_SIN_NBR", A_DOC_SIN_NBR.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_CLINIC_NBR", A_DOC_CLINIC_NBR.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_SPEC_CD", A_DOC_SPEC_CD.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_HOSP_NBR", A_DOC_HOSP_NBR.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_NAME", A_DOC_NAME.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_NAME_SOUNDEX", A_DOC_NAME_SOUNDEX.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_INITS", A_DOC_INITS.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_FULL_PART_IND", A_DOC_FULL_PART_IND.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_BANK_NBR", A_DOC_BANK_NBR.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_BANK_BRANCH", A_DOC_BANK_BRANCH.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_BANK_ACCT", A_DOC_BANK_ACCT.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_DATE_FAC_START", A_DOC_DATE_FAC_START.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_DATE_FAC_TERM", A_DOC_DATE_FAC_TERM.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_YTDGUA", A_DOC_YTDGUA.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_YTDGUB", A_DOC_YTDGUB.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_YTDGUC", A_DOC_YTDGUC.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_YTDGUD", A_DOC_YTDGUD.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_YTDCEA", A_DOC_YTDCEA.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_YTDCEX", A_DOC_YTDCEX.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_YTDEAR", A_DOC_YTDEAR.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_YTDINC", A_DOC_YTDINC.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_YTDEFT", A_DOC_YTDEFT.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_TOTINC_G", A_DOC_TOTINC_G.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_EP_DATE_DEPOSIT", A_DOC_EP_DATE_DEPOSIT.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_TOTINC", A_DOC_TOTINC.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_EP_CEIEXP", A_DOC_EP_CEIEXP.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_ADJCEA", A_DOC_ADJCEA.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_ADJCEX", A_DOC_ADJCEX.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_CEICEA", A_DOC_CEICEA.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_CEICEX", A_DOC_CEICEX.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_CLINIC_NBR_2", A_DOC_CLINIC_NBR_2.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_CLINIC_NBR_3", A_DOC_CLINIC_NBR_3.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_CLINIC_NBR_4", A_DOC_CLINIC_NBR_4.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_CLINIC_NBR_5", A_DOC_CLINIC_NBR_5.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_CLINIC_NBR_6", A_DOC_CLINIC_NBR_6.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_SPEC_CD_2", A_DOC_SPEC_CD_2.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_SPEC_CD_3", A_DOC_SPEC_CD_3.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_YTDINC_G", A_DOC_YTDINC_G.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_LOCATIONS", A_DOC_LOCATIONS.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_RMA_EXPENSE_PERCENT_MISC", A_DOC_RMA_EXPENSE_PERCENT_MISC.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_AFP_PAYM_GROUP", A_DOC_AFP_PAYM_GROUP.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_IND_PAYS_GST", A_DOC_IND_PAYS_GST.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_NX_AVAIL_BATCH", A_DOC_NX_AVAIL_BATCH.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_NX_AVAIL_BATCH_2", A_DOC_NX_AVAIL_BATCH_2.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_NX_AVAIL_BATCH_3", A_DOC_NX_AVAIL_BATCH_3.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_NX_AVAIL_BATCH_4", A_DOC_NX_AVAIL_BATCH_4.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_NX_AVAIL_BATCH_5", A_DOC_NX_AVAIL_BATCH_5.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_NX_AVAIL_BATCH_6", A_DOC_NX_AVAIL_BATCH_6.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_YRLY_CEILING_COMPUTED", A_DOC_YRLY_CEILING_COMPUTED.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_YRLY_EXPENSE_COMPUTED", A_DOC_YRLY_EXPENSE_COMPUTED.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_RMA_EXPENSE_PERCENT_REG", A_DOC_RMA_EXPENSE_PERCENT_REG.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_SUB_SPECIALTY", A_DOC_SUB_SPECIALTY.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_PAYEFT", A_DOC_PAYEFT.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_YTDDED", A_DOC_YTDDED.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_MISC", A_DOC_DEPT_EXPENSE_PERCENT_MISC.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_REG", A_DOC_DEPT_EXPENSE_PERCENT_REG.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_EP_PED", A_DOC_EP_PED.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_EP_PAY_CODE", A_DOC_EP_PAY_CODE.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_EP_PAY_SUB_CODE", A_DOC_EP_PAY_SUB_CODE.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_IND_HOLDBACK_ACTIVE", A_DOC_IND_HOLDBACK_ACTIVE.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("GROUP_REGULAR_SERVICE", A_GROUP_REGULAR_SERVICE.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("GROUP_OVER_SERVICED", A_GROUP_OVER_SERVICED.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_SPECIALTIES", A_DOC_SPECIALTIES.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_YRLY_REQUIRE_REVENUE", A_DOC_YRLY_REQUIRE_REVENUE.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_YRLY_TARGET_REVENUE", A_DOC_YRLY_TARGET_REVENUE.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_CEIREQ", A_DOC_CEIREQ.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_YTDREQ", A_DOC_YTDREQ.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_CEITAR", A_DOC_CEITAR.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_YTDTAR", A_DOC_YTDTAR.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("BILLING_VIA_PAPER_FLAG", A_BILLING_VIA_PAPER_FLAG.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("BILLING_VIA_DISKETTE_FLAG", A_BILLING_VIA_DISKETTE_FLAG.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("BILLING_VIA_WEB_TEST_FLAG", A_BILLING_VIA_WEB_TEST_FLAG.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("BILLING_VIA_WEB_LIVE_FLAG", A_BILLING_VIA_WEB_LIVE_FLAG.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("BILLING_VIA_RMA_DATA_ENTRY", A_BILLING_VIA_RMA_DATA_ENTRY.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DATE_START_RMA_DATA_ENTRY", A_DATE_START_RMA_DATA_ENTRY.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DATE_START_DISKETTE", A_DATE_START_DISKETTE.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DATE_START_PAPER", A_DATE_START_PAPER.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DATE_START_WEB_LIVE", A_DATE_START_WEB_LIVE.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DATE_START_WEB_TEST", A_DATE_START_WEB_TEST.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("LEAVE_DESCRIPTION", A_LEAVE_DESCRIPTION.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("LEAVE_DATE_START", A_LEAVE_DATE_START.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("LEAVE_DATE_END", A_LEAVE_DATE_END.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("WEB_USER_REVENUE_ONLY_FLAG", A_WEB_USER_REVENUE_ONLY_FLAG.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("MANAGER_FLAG", A_MANAGER_FLAG.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("CHAIR_FLAG", A_CHAIR_FLAG.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("ABE_USER_FLAG", A_ABE_USER_FLAG.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("CPSO_NBR", A_CPSO_NBR.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("CMPA_NBR", A_CMPA_NBR.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("OMA_NBR", A_OMA_NBR.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("CFPC_NBR", A_CFPC_NBR.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("RCPSC_NBR", A_RCPSC_NBR.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_MED_PROF_CORP", A_DOC_MED_PROF_CORP.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("MCMASTER_EMPLOYEE_ID", A_MCMASTER_EMPLOYEE_ID.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_SPEC_CD_EFF_DATE", A_DOC_SPEC_CD_EFF_DATE.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_SPEC_CD_2_EFF_DATE", A_DOC_SPEC_CD_2_EFF_DATE.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_SPEC_CD_3_EFF_DATE", A_DOC_SPEC_CD_3_EFF_DATE.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_CLINIC_NBR_STATUS", A_DOC_CLINIC_NBR_STATUS.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_CLINIC_NBR_2_STATUS", A_DOC_CLINIC_NBR_2_STATUS.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_CLINIC_NBR_3_STATUS", A_DOC_CLINIC_NBR_3_STATUS.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_CLINIC_NBR_4_STATUS", A_DOC_CLINIC_NBR_4_STATUS.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_CLINIC_NBR_5_STATUS", A_DOC_CLINIC_NBR_5_STATUS.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_CLINIC_NBR_6_STATUS", A_DOC_CLINIC_NBR_6_STATUS.Value);

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


        private bool Internal_CREATEF020AUDIT_AFTER()
        {


            try
            {

                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_NBR", fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_DEPT", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_OHIP_NBR", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_SIN_NBR", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SIN_NBR"));
                //fleF020_DOCTOR_AUDIT.set_SetValue("DOC_CLINIC_NBR", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CLINIC_NBR"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_SPEC_CD", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_HOSP_NBR", fleF020_DOCTOR_MSTR.GetStringValue("DOC_HOSP_NBR"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_NAME", fleF020_DOCTOR_MSTR.GetStringValue("DOC_NAME"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_NAME_SOUNDEX", fleF020_DOCTOR_MSTR.GetStringValue("DOC_NAME_SOUNDEX"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_INITS", fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT3"));
                //Parent:DOC_INITS
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_FULL_PART_IND", fleF020_DOCTOR_MSTR.GetStringValue("DOC_FULL_PART_IND"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_BANK_NBR", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_BANK_NBR"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_BANK_BRANCH", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_BANK_BRANCH"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_BANK_ACCT", fleF020_DOCTOR_MSTR.GetStringValue("DOC_BANK_ACCT"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_DATE_FAC_START", fleF020_DOCTOR_MSTR.GetNumericDateValue("DOC_DATE_FAC_START"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_DATE_FAC_TERM", fleF020_DOCTOR_MSTR.GetNumericDateValue("DOC_DATE_FAC_TERM"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_YTDGUA", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUA"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_YTDGUB", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUB"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_YTDGUC", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUC"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_YTDGUD", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUD"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_YTDCEA", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDCEA"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_YTDCEX", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDCEX"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_YTDEAR", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDEAR"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_YTDINC", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDINC"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_YTDEFT", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDEFT"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_TOTINC_G", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_TOTINC_G"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_EP_DATE_DEPOSIT", fleF020_DOCTOR_MSTR.GetNumericDateValue("DOC_EP_DATE_DEPOSIT"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_TOTINC", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_TOTINC"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_EP_CEIEXP", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_EP_CEIEXP"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_ADJCEA", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADJCEA"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_ADJCEX", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADJCEX"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_CEICEA", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CEICEA"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_CEICEX", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CEICEX"));
                //fleF020_DOCTOR_AUDIT.set_SetValue("DOC_CLINIC_NBR_2", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CLINIC_NBR_2"));
                //fleF020_DOCTOR_AUDIT.set_SetValue("DOC_CLINIC_NBR_3", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CLINIC_NBR_3"));
                //fleF020_DOCTOR_AUDIT.set_SetValue("DOC_CLINIC_NBR_4", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CLINIC_NBR_4"));
                //fleF020_DOCTOR_AUDIT.set_SetValue("DOC_CLINIC_NBR_5", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CLINIC_NBR_5"));
                //fleF020_DOCTOR_AUDIT.set_SetValue("DOC_CLINIC_NBR_6", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CLINIC_NBR_6"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_SPEC_CD_2", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_SPEC_CD_3", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_YTDINC_G", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDINC_G"));
                //fleF020_DOCTOR_AUDIT.set_SetValue("DOC_LOCATIONS", fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_4") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_5") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_6") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_7") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_8") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_9") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_10") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_11") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_12") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_13") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_14") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_15") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_16") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_17") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_18") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_19") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_20") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_21") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_22") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_23") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_24") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_25") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_26") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_27") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_28") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_29") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_30"));
                //Parent:DOC_LOCATIONS
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_RMA_EXPENSE_PERCENT_MISC", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_MISC"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_AFP_PAYM_GROUP", fleF020_DOCTOR_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_IND_PAYS_GST", fleF020_DOCTOR_MSTR.GetStringValue("DOC_IND_PAYS_GST"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_NX_AVAIL_BATCH", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_NX_AVAIL_BATCH_2", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_2"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_NX_AVAIL_BATCH_3", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_3"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_NX_AVAIL_BATCH_4", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_4"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_NX_AVAIL_BATCH_5", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_5"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_NX_AVAIL_BATCH_6", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_6"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_YRLY_CEILING_COMPUTED", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YRLY_CEILING_COMPUTED"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_YRLY_EXPENSE_COMPUTED", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YRLY_EXPENSE_COMPUTED"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_RMA_EXPENSE_PERCENT_REG", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_REG"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_SUB_SPECIALTY", fleF020_DOCTOR_MSTR.GetStringValue("DOC_SUB_SPECIALTY"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_PAYEFT", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_PAYEFT"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_YTDDED", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDDED"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_MISC", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_MISC"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_REG", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_REG"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_EP_PED", fleF020_DOCTOR_MSTR.GetNumericDateValue("DOC_EP_PED"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_EP_PAY_CODE", fleF020_DOCTOR_MSTR.GetStringValue("DOC_EP_PAY_CODE"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_EP_PAY_SUB_CODE", fleF020_DOCTOR_MSTR.GetStringValue("DOC_EP_PAY_SUB_CODE"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_IND_HOLDBACK_ACTIVE", fleF020_DOCTOR_MSTR.GetStringValue("DOC_IND_HOLDBACK_ACTIVE"));
                fleF020_DOCTOR_AUDIT.set_SetValue("GROUP_REGULAR_SERVICE", fleF020_DOCTOR_MSTR.GetStringValue("GROUP_REGULAR_SERVICE"));
                fleF020_DOCTOR_AUDIT.set_SetValue("GROUP_OVER_SERVICED", fleF020_DOCTOR_MSTR.GetStringValue("GROUP_OVER_SERVICED"));
                //fleF020_DOCTOR_AUDIT.set_SetValue("DOC_SPECIALTIES", fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_1_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_1_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_1_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_2_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_2_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_2_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_3_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_3_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_3_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_4_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_4_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_4_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_5_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_5_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_5_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_6_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_6_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_6_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_7_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_7_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_7_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_8_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_8_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_8_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_9_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_9_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_9_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_10_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_10_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_10_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_11_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_11_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_11_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_12_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_12_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_12_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_13_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_13_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_13_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_14_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_14_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_14_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_15_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_15_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_15_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_16_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_16_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_16_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_17_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_17_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_17_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_18_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_18_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_18_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_19_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_19_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_19_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_20_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_20_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_20_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_21_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_21_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_21_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_22_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_22_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_22_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_23_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_23_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_23_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_24_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_24_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_24_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_25_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_25_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_25_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_26_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_26_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_26_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_27_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_27_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_27_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_28_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_28_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_28_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_29_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_29_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_29_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_30_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_30_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_30_S3"));
                //Parent:DOC_SPECIALTIES
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_YRLY_REQUIRE_REVENUE", fleF020_DOCTOR_EXTRA.GetDecimalValue("DOC_YRLY_REQUIRE_REVENUE"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_YRLY_TARGET_REVENUE", fleF020_DOCTOR_EXTRA.GetDecimalValue("DOC_YRLY_TARGET_REVENUE"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_CEIREQ", fleF020_DOCTOR_EXTRA.GetDecimalValue("DOC_CEIREQ"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_YTDREQ", fleF020_DOCTOR_EXTRA.GetDecimalValue("DOC_YTDREQ"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_CEITAR", fleF020_DOCTOR_EXTRA.GetDecimalValue("DOC_CEITAR"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_YTDTAR", fleF020_DOCTOR_EXTRA.GetDecimalValue("DOC_YTDTAR"));
                fleF020_DOCTOR_AUDIT.set_SetValue("BILLING_VIA_PAPER_FLAG", fleF020_DOCTOR_EXTRA.GetStringValue("BILLING_VIA_PAPER_FLAG"));
                fleF020_DOCTOR_AUDIT.set_SetValue("BILLING_VIA_DISKETTE_FLAG", fleF020_DOCTOR_EXTRA.GetStringValue("BILLING_VIA_DISKETTE_FLAG"));
                fleF020_DOCTOR_AUDIT.set_SetValue("BILLING_VIA_WEB_TEST_FLAG", fleF020_DOCTOR_EXTRA.GetStringValue("BILLING_VIA_WEB_TEST_FLAG"));
                fleF020_DOCTOR_AUDIT.set_SetValue("BILLING_VIA_WEB_LIVE_FLAG", fleF020_DOCTOR_EXTRA.GetStringValue("BILLING_VIA_WEB_LIVE_FLAG"));
                fleF020_DOCTOR_AUDIT.set_SetValue("BILLING_VIA_RMA_DATA_ENTRY", fleF020_DOCTOR_EXTRA.GetStringValue("BILLING_VIA_RMA_DATA_ENTRY"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DATE_START_RMA_DATA_ENTRY", fleF020_DOCTOR_EXTRA.GetNumericDateValue("DATE_START_RMA_DATA_ENTRY"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DATE_START_DISKETTE", fleF020_DOCTOR_EXTRA.GetNumericDateValue("DATE_START_DISKETTE"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DATE_START_PAPER", fleF020_DOCTOR_EXTRA.GetNumericDateValue("DATE_START_PAPER"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DATE_START_WEB_LIVE", fleF020_DOCTOR_EXTRA.GetNumericDateValue("DATE_START_WEB_LIVE"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DATE_START_WEB_TEST", fleF020_DOCTOR_EXTRA.GetNumericDateValue("DATE_START_WEB_TEST"));
                fleF020_DOCTOR_AUDIT.set_SetValue("LEAVE_DESCRIPTION", fleF020_DOCTOR_EXTRA.GetStringValue("LEAVE_DESCRIPTION"));
                fleF020_DOCTOR_AUDIT.set_SetValue("LEAVE_DATE_START", fleF020_DOCTOR_EXTRA.GetNumericDateValue("LEAVE_DATE_START"));
                fleF020_DOCTOR_AUDIT.set_SetValue("LEAVE_DATE_END", fleF020_DOCTOR_EXTRA.GetNumericDateValue("LEAVE_DATE_END"));
                fleF020_DOCTOR_AUDIT.set_SetValue("WEB_USER_REVENUE_ONLY_FLAG", fleF020_DOCTOR_EXTRA.GetStringValue("WEB_USER_REVENUE_ONLY_FLAG"));
                fleF020_DOCTOR_AUDIT.set_SetValue("MANAGER_FLAG", fleF020_DOCTOR_EXTRA.GetStringValue("MANAGER_FLAG"));
                fleF020_DOCTOR_AUDIT.set_SetValue("CHAIR_FLAG", fleF020_DOCTOR_EXTRA.GetStringValue("CHAIR_FLAG"));
                fleF020_DOCTOR_AUDIT.set_SetValue("ABE_USER_FLAG", fleF020_DOCTOR_EXTRA.GetStringValue("ABE_USER_FLAG"));
                fleF020_DOCTOR_AUDIT.set_SetValue("CPSO_NBR", fleF020_DOCTOR_EXTRA.GetStringValue("CPSO_NBR"));
                fleF020_DOCTOR_AUDIT.set_SetValue("CMPA_NBR", fleF020_DOCTOR_EXTRA.GetStringValue("CMPA_NBR"));
                fleF020_DOCTOR_AUDIT.set_SetValue("OMA_NBR", fleF020_DOCTOR_EXTRA.GetStringValue("OMA_NBR"));
                fleF020_DOCTOR_AUDIT.set_SetValue("CFPC_NBR", fleF020_DOCTOR_EXTRA.GetStringValue("CFPC_NBR"));
                fleF020_DOCTOR_AUDIT.set_SetValue("RCPSC_NBR", fleF020_DOCTOR_EXTRA.GetStringValue("RCPSC_NBR"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_MED_PROF_CORP", fleF020_DOCTOR_EXTRA.GetStringValue("DOC_MED_PROF_CORP"));
                fleF020_DOCTOR_AUDIT.set_SetValue("MCMASTER_EMPLOYEE_ID", fleF020_DOCTOR_EXTRA.GetDecimalValue("MCMASTER_EMPLOYEE_ID"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_SPEC_CD_EFF_DATE", fleF020_DOCTOR_EXTRA.GetNumericDateValue("DOC_SPEC_CD_EFF_DATE"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_SPEC_CD_2_EFF_DATE", fleF020_DOCTOR_EXTRA.GetNumericDateValue("DOC_SPEC_CD_2_EFF_DATE"));
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_SPEC_CD_3_EFF_DATE", fleF020_DOCTOR_EXTRA.GetNumericDateValue("DOC_SPEC_CD_3_EFF_DATE"));
                //fleF020_DOCTOR_AUDIT.set_SetValue("DOC_CLINIC_NBR_STATUS", fleF020_DOCTOR_EXTRA.GetStringValue("DOC_CLINIC_NBR_STATUS"));
                //fleF020_DOCTOR_AUDIT.set_SetValue("DOC_CLINIC_NBR_2_STATUS", fleF020_DOCTOR_EXTRA.GetStringValue("DOC_CLINIC_NBR_2_STATUS"));
                //fleF020_DOCTOR_AUDIT.set_SetValue("DOC_CLINIC_NBR_3_STATUS", fleF020_DOCTOR_EXTRA.GetStringValue("DOC_CLINIC_NBR_3_STATUS"));
                //fleF020_DOCTOR_AUDIT.set_SetValue("DOC_CLINIC_NBR_4_STATUS", fleF020_DOCTOR_EXTRA.GetStringValue("DOC_CLINIC_NBR_4_STATUS"));
                //fleF020_DOCTOR_AUDIT.set_SetValue("DOC_CLINIC_NBR_5_STATUS", fleF020_DOCTOR_EXTRA.GetStringValue("DOC_CLINIC_NBR_5_STATUS"));
                //fleF020_DOCTOR_AUDIT.set_SetValue("DOC_CLINIC_NBR_6_STATUS", fleF020_DOCTOR_EXTRA.GetStringValue("DOC_CLINIC_NBR_6_STATUS"));

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

        //#CORE_END_INCLUDE: CREATEF020AUDIT_MP"



        protected override bool Initialize()
        {


            try
            {

                // --> GET CONSTANTS_MSTR_REC_6 <--
                m_strWhere = new StringBuilder(" WHERE ");
                m_strWhere.Append(" ").Append(fleCONSTANTS_MSTR_REC_6.ElementOwner("CONST_REC_NBR")).Append(" = ");
                m_strWhere.Append((6));

                fleCONSTANTS_MSTR_REC_6.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                // --> End GET CONSTANTS_MSTR_REC_6 <--
                if (!AccessOk)
                {
                    ErrorMessage("Error - Can`t read Constants Master record #6!");
                }
                W_EP_NBR_FROM.Value = W_CURRENT_EP_NBR_MINUS_1.Value;
                W_EP_NBR_TO.Value = W_CURRENT_EP_NBR_MINUS_1.Value;

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

                Internal_SAVEF020AUDIT();
                W_OLD_PAY_CODE.Value = fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_CODE");
                Display(ref fldW_EP_NBR_FROM);
                // --> GET F199_USER_DEFINED_FIELDS <--
                m_strWhere = new StringBuilder(" WHERE ");
                m_strWhere.Append(" ").Append(fleF199_USER_DEFINED_FIELDS.ElementOwner("RECORD_ID")).Append(" = ");
                m_strWhere.Append(Common.StringToField("A"));

                fleF199_USER_DEFINED_FIELDS.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                // --> End GET F199_USER_DEFINED_FIELDS <--
                while (fleF199_USER_DEFINED_FIELDS.For())
                {
                    Display(ref fldF199_USER_DEFINED_FIELDS_FIELD_DESC1);
                    Display(ref fldF199_USER_DEFINED_FIELDS_FIELD_DESC2);
                    Display(ref fldF199_USER_DEFINED_FIELDS_FIELD_DESC3);
                    Display(ref fldF199_USER_DEFINED_FIELDS_FIELD_DESC4);
                    Display(ref fldF199_USER_DEFINED_FIELDS_FIELD_DESC5);
                    Display(ref fldF199_USER_DEFINED_FIELDS_FIELD_DESC6);
                    Display(ref fldF199_USER_DEFINED_FIELDS_FIELD_DESC7);
                    Display(ref fldF199_USER_DEFINED_FIELDS_FIELD_DESC8);
                    Display(ref fldF199_USER_DEFINED_FIELDS_FIELD_DESC9);
                    Display(ref fldF199_USER_DEFINED_FIELDS_FIELD_DESC10);
                }
                // --> GET F199_2ND_REC <--
                m_strWhere = new StringBuilder(" WHERE ");
                m_strWhere.Append(" ").Append(fleF199_2ND_REC.ElementOwner("RECORD_ID")).Append(" = ");
                m_strWhere.Append(Common.StringToField("B"));

                fleF199_2ND_REC.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                // --> End GET F199_2ND_REC <--
                while (fleF199_2ND_REC.For())
                {
                    Display(ref fldF199_USER_DEFINED_FIELDS_FIELD_DESC1);
                    Display(ref fldF199_USER_DEFINED_FIELDS_FIELD_DESC2);
                    Display(ref fldF199_USER_DEFINED_FIELDS_FIELD_DESC3);
                    Display(ref fldF199_USER_DEFINED_FIELDS_FIELD_DESC4);
                    Display(ref fldF199_USER_DEFINED_FIELDS_FIELD_DESC5);
                    Display(ref fldF199_USER_DEFINED_FIELDS_FIELD_DESC6);
                    Display(ref fldF199_USER_DEFINED_FIELDS_FIELD_DESC7);
                    Display(ref fldF199_USER_DEFINED_FIELDS_FIELD_DESC8);
                    Display(ref fldF199_USER_DEFINED_FIELDS_FIELD_DESC9);
                    Display(ref fldF199_USER_DEFINED_FIELDS_FIELD_DESC10);
                }
                // --> GET F198_2ND_REC <--
                m_strWhere = new StringBuilder(" WHERE ");
                m_strWhere.Append(" ").Append(fleF198_2ND_REC.ElementOwner("RECORD_ID")).Append(" = ");
                m_strWhere.Append(Common.StringToField("B"));
                m_strWhere.Append(" And ").Append(fleF198_2ND_REC.ElementOwner("UDT_KEY")).Append(" = ");
                m_strWhere.Append(Common.StringToField(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")));

                fleF198_2ND_REC.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                // --> End GET F198_2ND_REC <--
                while (fleF198_2ND_REC.For())
                {
                    Display(ref fldF198_USER_DEFINED_TOTALS_USER_TOTAL1);
                    Display(ref fldF198_USER_DEFINED_TOTALS_USER_TOTAL2);
                    Display(ref fldF198_USER_DEFINED_TOTALS_USER_TOTAL3);
                    Display(ref fldF198_USER_DEFINED_TOTALS_USER_TOTAL4);
                    Display(ref fldF198_USER_DEFINED_TOTALS_USER_TOTAL5);
                    Display(ref fldF198_USER_DEFINED_TOTALS_USER_TOTAL6);
                    Display(ref fldF198_USER_DEFINED_TOTALS_USER_TOTAL7);
                    Display(ref fldF198_USER_DEFINED_TOTALS_USER_TOTAL8);
                    Display(ref fldF198_USER_DEFINED_TOTALS_USER_TOTAL9);
                    Display(ref fldF198_USER_DEFINED_TOTALS_USER_TOTAL10);
                }
                // --> GET CONSTANTS_MSTR_REC_6 <--
                m_strWhere = new StringBuilder(" WHERE ");
                m_strWhere.Append(" ").Append(fleCONSTANTS_MSTR_REC_6.ElementOwner("CONST_REC_NBR")).Append(" = ");
                m_strWhere.Append((6));

                fleCONSTANTS_MSTR_REC_6.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                // --> End GET CONSTANTS_MSTR_REC_6 <--
                // --> GET F112_PYCDCEILINGS <--
                m_strWhere = new StringBuilder(" WHERE ");
                m_strWhere.Append(" ").Append(fleF112_PYCDCEILINGS.ElementOwner("DOC_NBR")).Append(" = ");
                m_strWhere.Append(Common.StringToField(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")));
                m_strWhere.Append(" And ").Append(fleF112_PYCDCEILINGS.ElementOwner("EP_NBR")).Append(" = ");
                m_strWhere.Append((fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR")));

                fleF112_PYCDCEILINGS.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                // --> End GET F112_PYCDCEILINGS <--
                if (!AccessOk)
                {
                    // --> GET F112_PYCDCEILINGS <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF112_PYCDCEILINGS.ElementOwner("DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")));
                    m_strWhere.Append(" And ").Append(fleF112_PYCDCEILINGS.ElementOwner("EP_NBR")).Append(" = ");
                    m_strWhere.Append((W_CURRENT_EP_NBR_MINUS_1.Value));

                    fleF112_PYCDCEILINGS.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F112_PYCDCEILINGS <--
                }
                if (AccessOk & QDesign.NULL(fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR")) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")))
                {
                    W_CURRENT_PYCODE.Value = fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_CODE");
                    W_CURRENT_PYSUBCODE.Value = fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_SUB_CODE");
                    W_CURR_CEIL_EARN.Value = fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEILING");
                    W_CURR_CEIL_EXPN.Value = fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_EXPENSE");
                }
                else
                {
                    W_CURRENT_PYCODE.Value = "?";
                    W_CURRENT_PYSUBCODE.Value = " ";
                }
                Display(ref fldW_CURRENT_PYCODE);
                Display(ref fldW_CURRENT_PYSUBCODE);
                Display(ref fldF020_DOCTOR_MSTR_DOC_YRLY_CEILING_COMPUTED);
                Display(ref fldF020_DOCTOR_MSTR_DOC_YRLY_EXPENSE_COMPUTED);

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



        private void fldF020_DOCTOR_MSTR_DOC_NBR_Edit()
        {

            try
            {

                //#CORE_BEGIN_INCLUDE: PAD_DOC_NBR"

                //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
                //# Do not delete, modify or move it.  Updated: 5/26/2017 10:17:25 AM

                X_DOC_NBR_LENGTH.Value = FieldText.Length;
                if (QDesign.NULL(X_DOC_NBR_LENGTH.Value) == 1)
                {
                    FieldText = "00" + FieldText;
                }
                else
                {
                    if (QDesign.NULL(X_DOC_NBR_LENGTH.Value) == 2)
                    {
                        FieldText = "0" + FieldText;

                        //#CORE_END_INCLUDE: PAD_DOC_NBR"


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



        private void fldF020_DOCTOR_MSTR_DOC_BANK_NBR_Process()
        {

            try
            {

                if (QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_BANK_NBR")) == 0)
                {
                    fleF020_DOCTOR_MSTR.set_SetValue("DOC_BANK_BRANCH", 0);
                    fleF020_DOCTOR_MSTR.set_SetValue("DOC_BANK_ACCT", " ");
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



        private void fldF020_DOCTOR_MSTR_DOC_BANK_BRANCH_Edit()
        {

            try
            {

                // --> GET F080_BANK_MSTR <--
                m_strWhere = new StringBuilder(" WHERE ");
                m_strWhere.Append(" ").Append(fleF080_BANK_MSTR.ElementOwner("BANK_CD")).Append(" = ");
                m_strWhere.Append(Common.StringToField((QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_BANK_NBR"), 4) + QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_BANK_BRANCH"), 5))));

                fleF080_BANK_MSTR.GetData(m_strWhere.ToString());
                // --> End GET F080_BANK_MSTR <--
                if (!AccessOk)
                {
                    ErrorMessage("Error - Invalid BANK/BRANCH.");
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



        private void fldF020_DOCTOR_MSTR_DOC_DATE_FAC_TERM_Process()
        {

            try
            {

                if (QDesign.NULL(fleF020_DOCTOR_MSTR.GetNumericDateValue("DOC_DATE_FAC_START")) > QDesign.NULL(fleF020_DOCTOR_MSTR.GetNumericDateValue("DOC_DATE_FAC_TERM")) & QDesign.NULL(fleF020_DOCTOR_MSTR.GetNumericDateValue("DOC_DATE_FAC_TERM")) != 0)
                {
                    ErrorMessage("INVALID DATE");
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



        private void dsrDesigner_91_Click(object sender, System.EventArgs e)
        {

            try
            {

                W_DOC_NBR.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR");
                object[] arrRunscreen = { W_DOC_NBR, fleCONSTANTS_MSTR_REC_6, fleF020_DOCTOR_MSTR };
                RunScreen(new Billing_D112(), RunScreenModes.Same, ref arrRunscreen);
                Display(ref fldF020_DOCTOR_MSTR_DOC_YRLY_CEILING_COMPUTED);
                Display(ref fldF020_DOCTOR_MSTR_DOC_YRLY_EXPENSE_COMPUTED);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_HI91_Click(object sender, System.EventArgs e)
        {

            try
            {

                Accept(ref fldW_EP_NBR_YY);
                W_DOC_NBR.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR");
                object[] arrRunscreen = { W_DOC_NBR, W_EP_NBR_YY, fleCONSTANTS_MSTR_REC_6, fleF020_DOCTOR_MSTR };
                RunScreen(new Billing_H112(), RunScreenModes.Same, ref arrRunscreen);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_92_Click(object sender, System.EventArgs e)
        {

            try
            {

                W_DOC_NBR.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR");
                object[] arrRunscreen = { W_DOC_NBR, fleCONSTANTS_MSTR_REC_6, fleF020_DOCTOR_MSTR };
                if (ApplicationState.Current.Selected == 1)
                    RunScreen(new Mp_D112A(), RunScreenModes.Same, ref arrRunscreen);
                else
                    RunScreen(new Billing_D112A(), RunScreenModes.Same, ref arrRunscreen);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_HI92_Click(object sender, System.EventArgs e)
        {

            try
            {

                Accept(ref fldW_EP_NBR_YY);
                W_DOC_NBR.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR");
                object[] arrRunscreen = { W_DOC_NBR, W_EP_NBR_YY, fleCONSTANTS_MSTR_REC_6, fleF020_DOCTOR_MSTR };
                RunScreen(new Billing_H112A(), RunScreenModes.Same, ref arrRunscreen);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_93_Click(object sender, System.EventArgs e)
        {

            try
            {

                W_PASSWORD.Value = "EARN";
                if (QDesign.NULL(W_PASSWORD.Value) == QDesign.NULL("EARN"))
                {
                    Accept(ref fldW_EP_NBR_FROM);
                    W_EP_NBR_TO.Value = W_EP_NBR_FROM.Value;
                    W_DOC_NBR.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR");
                    object[] arrRunscreen = { W_DOC_NBR, W_EP_NBR_FROM, W_EP_NBR_TO, fleCONSTANTS_MSTR_REC_6, fleF020_DOCTOR_MSTR };
                    RunScreen(new Billing_D110(), RunScreenModes.Same, ref arrRunscreen);
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



        private void dsrDesigner_HI93_Click(object sender, System.EventArgs e)
        {

            try
            {

                Accept(ref fldW_EP_NBR_FROM);
                W_DOC_NBR.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR");
                object[] arrRunscreen = { W_DOC_NBR, W_EP_NBR_FROM, fleCONSTANTS_MSTR_REC_6, fleF020_DOCTOR_MSTR };
                RunScreen(new Billing_H110(), RunScreenModes.Same, ref arrRunscreen);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_94_Click(object sender, System.EventArgs e)
        {

            try
            {

                W_DOC_NBR.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR");
                object[] arrRunscreen = { W_DOC_NBR, fleCONSTANTS_MSTR_REC_6, fleF020_DOCTOR_MSTR };
                RunScreen(new Billing_D119(), RunScreenModes.Same, ref arrRunscreen);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_HI94_Click(object sender, System.EventArgs e)
        {

            try
            {

                W_DOC_NBR.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR");
                Accept(ref fldW_EP_NBR_FROM);
                object[] arrRunscreen = { W_DOC_NBR, W_EP_NBR_FROM, fleCONSTANTS_MSTR_REC_6, fleF020_DOCTOR_MSTR };               
                if (ApplicationState.Current.Selected == 1)
                    RunScreen(new Mp_H119(), RunScreenModes.Same, ref arrRunscreen);
                else
                    RunScreen(new Billing_H119(), RunScreenModes.Same, ref arrRunscreen);

            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_95_Click(object sender, System.EventArgs e)
        {

            try
            {

                W_DOC_NBR.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR");
                object[] arrRunscreen = { W_DOC_NBR, W_EP_NBR_FROM, W_EP_NBR_TO, fleF020_DOCTOR_MSTR };
                RunScreen(new Billing_D118(), RunScreenModes.Same, ref arrRunscreen);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_98_Click(object sender, System.EventArgs e)
        {

            try
            {

                W_DOC_NBR.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR");
                object[] arrRunscreen = { W_DOC_NBR, fleCONSTANTS_MSTR_REC_6, fleF020_DOCTOR_MSTR };
                if (ApplicationState.Current.Selected == 1)
                    RunScreen(new Mp_D113(), RunScreenModes.Same, ref arrRunscreen);
                else
                    RunScreen(new Moira_D113(), RunScreenModes.Same, ref arrRunscreen);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_HI98_Click(object sender, System.EventArgs e)
        {

            try
            {

                W_DOC_NBR.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR");
                Accept(ref fldW_EP_NBR_YY);
                object[] arrRunscreen = { W_DOC_NBR, W_EP_NBR_YY, fleCONSTANTS_MSTR_REC_6, fleF020_DOCTOR_MSTR };
                RunScreen(new Billing_H113(), RunScreenModes.Same, ref arrRunscreen);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_99_Click(object sender, System.EventArgs e)
        {

            try
            {

                W_DOC_NBR.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR");
                object[] arrRunscreen = { W_DOC_NBR };
                RunScreen(new Billing_D199(), RunScreenModes.Find, ref arrRunscreen);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_TOT_Click(object sender, System.EventArgs e)
        {

            try
            {

                object[] arrRunscreen = { fleF020_DOCTOR_MSTR, fleF020_DOCTOR_EXTRA };
                if (ApplicationState.Current.Selected == 1)
                    RunScreen(new Mp_D020A(), RunScreenModes.Find, ref arrRunscreen);
                else
                    RunScreen(new Billing_D020A(), RunScreenModes.Find, ref arrRunscreen);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_HTOT_Click(object sender, System.EventArgs e)
        {

            try
            {

                W_DOC_NBR.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR");
                Accept(ref fldW_EP_NBR_FROM);
                object[] arrRunscreen = { W_DOC_NBR, W_EP_NBR_FROM };
                RunScreen(new Billing_H020A(), RunScreenModes.Find, ref arrRunscreen);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_ADJ_Click(object sender, System.EventArgs e)
        {

            try
            {

                object[] arrRunscreen = { fleF020_DOCTOR_MSTR };
                RunScreen(new Billing_D020B(), RunScreenModes.Find, ref arrRunscreen);


            }
            catch (CustomApplicationException ex)
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

                if (fleF020_DOCTOR_MSTR.AlteredRecord | fleF020_DOCTOR_EXTRA.AlteredRecord)
                {
                    Internal_CREATEF020AUDIT_BEFORE();
                    fleF020_DOCTOR_AUDIT.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));
                    fleF020_DOCTOR_AUDIT.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);
                    fleF020_DOCTOR_AUDIT.set_SetValue("LAST_MOD_USER_ID", QDesign.RTrim(UserID) + "-d020-1");
                    fleF020_DOCTOR_AUDIT.set_SetValue("LAST_MOD_FLAG", "C");
                    fleF020_DOCTOR_AUDIT.PutData(true);
                    Internal_CREATEF020AUDIT_AFTER();
                    fleF020_DOCTOR_AUDIT.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));
                    fleF020_DOCTOR_AUDIT.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);
                    fleF020_DOCTOR_AUDIT.set_SetValue("LAST_MOD_USER_ID", QDesign.RTrim(UserID) + "-d020-2");
                    fleF020_DOCTOR_AUDIT.set_SetValue("LAST_MOD_FLAG", "C");
                    fleF020_DOCTOR_AUDIT.PutData(true);
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
                switch (m_intPath)
                {
                    case 1:
                        m_strWhere = new StringBuilder(GetWhereCondition(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR"), fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR"), ref blnAddWhere));
                        fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
                        break;
                    case 2:
                        m_strWhere = new StringBuilder(GetWhereCondition(fleF020_DOCTOR_MSTR.ElementOwner("DOC_OHIP_NBR"), fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR"), ref blnAddWhere));
                        fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
                        break;
                    default:
                        fleF020_DOCTOR_MSTR.GetData(GetDataOptions.Sequential | GetDataOptions.CreateSubSelect);
                        break;
                }

                m_strWhere = new StringBuilder(" WHERE ");
                m_strWhere.Append("  ").Append(fleF020_DOCTOR_EXTRA.ElementOwner("DOC_NBR")).Append(" = ").Append(Common.StringToField(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")));
                fleF020_DOCTOR_EXTRA.GetData(m_strWhere.ToString());


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

                RequestPrompt(ref fldF020_DOCTOR_MSTR_DOC_NBR);
                if (m_blnPromptOK)
                {
                    m_intPath = 1;
                }
                if (m_intPath == 0)
                {
                    RequestPrompt(ref fldF020_DOCTOR_MSTR_DOC_OHIP_NBR);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/26/2017 10:17:26 AM
        //#-----------------------------------------
        protected override bool Entry()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/26/2017 10:17:26 AM
                Display(ref fldF020_DOCTOR_MSTR_DOC_NBR);
                Display(ref fldF020_DOCTOR_MSTR_DOC_NAME);
                Display(ref fldF020_DOCTOR_MSTR_DOC_INITS);
                Display(ref fldF020_DOCTOR_MSTR_DOC_OHIP_NBR);
                Display(ref fldF020_DOCTOR_MSTR_DOC_DEPT);
                Display(ref fldF070_DEPT_MSTR_DEPT_NAME);
                Display(ref fldF020_DOCTOR_MSTR_DOC_FULL_PART_IND);
                Accept(ref fldF020_DOCTOR_MSTR_DOC_DATE_FAC_START);
                Accept(ref fldF020_DOCTOR_MSTR_DOC_DATE_FAC_TERM);
                Accept(ref fldW_CURRENT_PYCODE);
                Accept(ref fldW_CURRENT_PYSUBCODE);
                Accept(ref fldW_CURR_CEIL_EARN);
                Accept(ref fldW_CURR_CEIL_EXPN);
                Display(ref fldF020_DOCTOR_MSTR_DOC_BANK_NBR);
                Accept(ref fldF020_DOCTOR_MSTR_DOC_YRLY_CEILING_COMPUTED);
                Accept(ref fldF020_DOCTOR_MSTR_DOC_YRLY_EXPENSE_COMPUTED);
                Display(ref fldF020_DOCTOR_MSTR_DOC_BANK_BRANCH);
                Accept(ref fldF020_DOCTOR_MSTR_DOC_RMA_EXPENSE_PERCENT_REG);
                Accept(ref fldF020_DOCTOR_MSTR_DOC_RMA_EXPENSE_PERCENT_MISC);
                Display(ref fldF020_DOCTOR_MSTR_DOC_BANK_ACCT);
                Accept(ref fldF020_DOCTOR_MSTR_DOC_DEPT_EXPENSE_PERCENT_REG);
                Accept(ref fldF020_DOCTOR_MSTR_DOC_DEPT_EXPENSE_PERCENT_MISC);
                Accept(ref fldF020_DOCTOR_MSTR_DOC_IND_PAYS_GST);
                Accept(ref fldF020_DOCTOR_MSTR_DOC_IND_HOLDBACK_ACTIVE);
                Display(ref fldF020_DOCTOR_MSTR_DOC_AFP_PAYM_GROUP);
                Accept(ref fldW_EP_NBR_FROM);
                Accept(ref fldW_EP_NBR_YY);
                Display(ref fldF199_USER_DEFINED_FIELDS_FIELD_DESC1);
                Display(ref fldF198_USER_DEFINED_TOTALS_USER_TOTAL1);
                Display(ref fldF199_2ND_REC_FIELD_DESC1);
                Display(ref fldF198_2ND_REC_USER_TOTAL1);
                Display(ref fldF199_USER_DEFINED_FIELDS_FIELD_DESC2);
                Display(ref fldF198_USER_DEFINED_TOTALS_USER_TOTAL2);
                Display(ref fldF199_2ND_REC_FIELD_DESC2);
                Display(ref fldF198_2ND_REC_USER_TOTAL2);
                Display(ref fldF199_USER_DEFINED_FIELDS_FIELD_DESC3);
                Display(ref fldF198_USER_DEFINED_TOTALS_USER_TOTAL3);
                Display(ref fldF199_2ND_REC_FIELD_DESC3);
                Display(ref fldF198_2ND_REC_USER_TOTAL3);
                Display(ref fldF199_USER_DEFINED_FIELDS_FIELD_DESC4);
                Display(ref fldF198_USER_DEFINED_TOTALS_USER_TOTAL4);
                Display(ref fldF199_2ND_REC_FIELD_DESC4);
                Display(ref fldF198_2ND_REC_USER_TOTAL4);
                Display(ref fldF199_USER_DEFINED_FIELDS_FIELD_DESC5);
                Display(ref fldF198_USER_DEFINED_TOTALS_USER_TOTAL5);
                Display(ref fldF199_2ND_REC_FIELD_DESC5);
                Display(ref fldF198_2ND_REC_USER_TOTAL5);
                Display(ref fldF199_USER_DEFINED_FIELDS_FIELD_DESC6);
                Display(ref fldF198_USER_DEFINED_TOTALS_USER_TOTAL6);
                Display(ref fldF199_2ND_REC_FIELD_DESC6);
                Display(ref fldF198_2ND_REC_USER_TOTAL6);
                Display(ref fldF199_USER_DEFINED_FIELDS_FIELD_DESC7);
                Display(ref fldF198_USER_DEFINED_TOTALS_USER_TOTAL7);
                Display(ref fldF199_2ND_REC_FIELD_DESC7);
                Display(ref fldF198_2ND_REC_USER_TOTAL7);
                Display(ref fldF199_USER_DEFINED_FIELDS_FIELD_DESC8);
                Display(ref fldF198_USER_DEFINED_TOTALS_USER_TOTAL8);
                Display(ref fldF199_2ND_REC_FIELD_DESC8);
                Display(ref fldF198_2ND_REC_USER_TOTAL8);
                Display(ref fldF199_USER_DEFINED_FIELDS_FIELD_DESC9);
                Display(ref fldF198_USER_DEFINED_TOTALS_USER_TOTAL9);
                Display(ref fldF199_2ND_REC_FIELD_DESC9);
                Display(ref fldF198_2ND_REC_USER_TOTAL9);
                Display(ref fldF199_USER_DEFINED_FIELDS_FIELD_DESC10);
                Display(ref fldF198_USER_DEFINED_TOTALS_USER_TOTAL10);
                Display(ref fldF199_2ND_REC_FIELD_DESC10);
                Display(ref fldF198_2ND_REC_USER_TOTAL10);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/26/2017 10:17:26 AM
        //#-----------------------------------------
        protected override bool Update()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/26/2017 10:17:26 AM
                fleF020_DOCTOR_MSTR.PutData(false, PutTypes.New);
                fleF020_DOCTOR_EXTRA.PutData();
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/26/2017 10:17:26 AM
        //#-----------------------------------------
        protected override bool Delete()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/26/2017 10:17:26 AM
                fleF020_DOCTOR_MSTR.DeletedRecord = true;
                fleF020_DOCTOR_EXTRA.DeletedRecord = true;
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
        //# dsrDesigner_03_Click Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/26/2017 10:17:26 AM
        //#-----------------------------------------
        private void dsrDesigner_03_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/26/2017 10:17:26 AM
                Accept(ref fldF020_DOCTOR_MSTR_DOC_RMA_EXPENSE_PERCENT_REG);
                Accept(ref fldF020_DOCTOR_MSTR_DOC_RMA_EXPENSE_PERCENT_MISC);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/26/2017 10:17:26 AM
        //#-----------------------------------------
        private void dsrDesigner_04_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/26/2017 10:17:26 AM
                Accept(ref fldF020_DOCTOR_MSTR_DOC_DEPT_EXPENSE_PERCENT_REG);
                Accept(ref fldF020_DOCTOR_MSTR_DOC_DEPT_EXPENSE_PERCENT_MISC);
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
