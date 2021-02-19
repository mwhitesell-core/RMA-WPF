
#region "Screen Comments"

// #> PROGRAM-ID.     M020.QKS
// ((C)) Dyad Technologies
// PROGRAM PURPOSE : MAINTENANCE OF F020-DOCTOR-MSTR
// MODIFICATION HISTORY
// DATE   WHO          DESCRIPTION
// 91/JAN/09 D.B.         - ORIGINAL (SMS 137)
// 91/JAN/25 M.C.      - CEILING DATE1 MUST BE WITHIN THE YEAREND
// DATE (IE AFTER JUNE 31)
// 91/MAR/19 D.B.         - ALLOW TO ENTER 0 INTO CEILING DATE2 & 3
// 91/MAY/23 D.B.         - EXPENSE-1 REQUIRED ONLY IN ENTRYMODE
// 91/JUN/11 D.B.         - CHANGE CHECK OF DOC-OHIP-NBR
// 91/JAN/14 D.B.         - ALLOW TO CHANGE DOC-OHIP-NBR
// 91/JUL/18 K.Z.      - ADD  ITEM...INITIAL... s FOR F060 CHQ REG
// 92/JUL/06 B.E.      - REMOVED PAYROLL INFORMATION - NOW IN D020
// 92/APR/07 M.C.      - ALLOW USER TO ACCESS DOCTOR MSTR BY
// DOCTOR NAME SOUNDEX USING DOCTOR NAME
// 92/JUN/10 M.C.      - SMS 139 - ADD 5 MORE CLINICS AND 2 MORE
// SPECIALTY CODES
// 92/SEP/14 M.C.      - PDR 557 - USE F002-CLAIMS-MSTR-M020
// INSTEAD OF F002-CLAIMS-MSTR
// 95/APR/26 M.C.      - PDR 612 - WHEN A DOCTOR IS DELETED, ADD A
// RECORD TO F022-DELETED-DOC-MSTR
// & F021-AVAIL-DOCTOR-MSTR.
// - PDR 605 - IF DOC OHIP NBR IS DOES NOT
// PASS MOD 10 CHECK, DISPLAY AS
// WARNING INSTEAD OF ERROR
// 95/NOV/09 M.C.      - DO NOT ALLOW USER TO CHANGE ITEMS ON ID
// 2,3,4 & 6 BUT ALLOW TO CHANGE VIA LIN2,
// LIN3, LIN4 & LIN6 DESIGNER PROCEDURES
// 97/May/27 K. M.        - Added two fields: GROUP-REGULAR-SERVICE
// and GROUP-OVER-SERVICED and 3 specialty
// fields per location
// 98/aug/18 B.E.       - added `using 4` for const mstr read of rec #4
// 1999/jan/15 B.E.  - y2k - 
// 1999/Jan/18 S.B.      - Fixed the `start` and `terminate` dates for
// Y2K compliance.
// 1999/Apr/22 S.B.      - Commented out the w-year, w-mth, and
// w-comp-date defines because the are not used.
// 1999/Oct/20 M.C.      - change BATCH_UPDATE_F050_F051_F060 into
// $cmd/batch_update_f050_f051_f060
// 2000/jan/18 B.E. - changed activities to not allow delete
// - if termination date set, then f021 added to
// 2000/feb/16 M.C. - comment any codes related to  f022-deleted-doc-mstr 
// because file f022-deleted-doc-mstr is no longer used
// 2000/mar/03 M.C. - prompt for w-start-date when user makes dept change
// in preupdate procedure
// 2000/apr/19 B.A. - added extra hsc code with conditional compiles
// 2000/may/30 M.C. - Only allow System Administrator can change doctor department
// 2000/oct/20 B.E. - added EXPort/IMPort functions to allow some of the doctor
// information to be transferred into another system. Data
// is transferred via files into the 
// /temp/transfer_area/rmabill directory
// 2000/nov/09 B.E. - added close of transfer-file after data read so that if
// user does another import the program re-reads file 
// from the beginning
// 2000/nov/20 B.E. - added warning msg if not running in the current `live`
// or `production` directory
// 2001/sep/18 B.E. - added call to OPTions designer routine to maintain doctor
// options files
// 2002/jul/16 M.C. - added 5 more doc-nx-avail-batch for the additional clinics
// so that there will be unique set of batch number for each
// clinic for each doctor       
// 03/nov/05 b.e. - alpha doctor nbr
// - forced 3 charcter doctor number by padding with lj zero`s
// - restriced doctor number to not be `000` or contain `*`
// 03/nov/20 b.e. - forced UPSHIFT on doc-nbr field to ensure doctor `nbr` has
// has no lowercase letters
// 2004/mar/03 M.C. - include doc-afp-paym-group on the screen
// 2004/apr/29 M.C. - Yas requested to add lin8 designer procedure
// 2004/jul/08 M.C. - validation on doc-afp-paym-group from f074-afp-group-mstr
// 2013/Sep/25 MC1  - modify to check clinic nbr edit properly by each individual clinic
// 2014/sep/25 MC2  - add f020-doctor-audit to capture before change records
// - save f020-doctor-mstr & f020-doctor-extra records in f020-doctor-audit in postfind in case
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
using System.Configuration;
using System.IO;
using rma.PS;

namespace rma.Views
{

    partial class Mp_M020 : BasePage
    {

        #region " Form Designer Generated Code "





        public Mp_M020()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "M020";

            //# Set the ACTIVITIES for the screen.
            this.ChangeActivity = true;
            this.FindActivity = true;
            this.DeleteActivity = false;
            this.EntryActivity = true;
            this.UseAcceptProcessing = true;



            this.HasPathRequestFields = true;



            



        }

        #endregion

        private void Page_Load(object sender, RoutedEventArgs e)
        {
            SetVariables();
            T_DOC_INITS = new CoreCharacter("T_DOC_INITS", 3, this, Common.cEmptyString);
            T_DOC_SIN_NBR = new CoreDecimal("T_DOC_SIN_NBR", 9, this);
            T_DOC_DATE_FAC_START = new CoreDecimal("T_DOC_SIN_NBR", 8, this);
            T_DOC_DATE_FAC_TERM = new CoreDecimal("T_DOC_SIN_NBR", 8, this);
            dsrDesigner_PASS.Click += dsrDesigner_PASS_Click;
            dsrDesigner_ALT.Click += dsrDesigner_ALT_Click;
            dsrDesigner_02.Click += dsrDesigner_02_Click;
            dsrDesigner_03.Click += dsrDesigner_03_Click;
            dsrDesigner_04.Click += dsrDesigner_04_Click;
            dsrDesigner_05.Click += dsrDesigner_05_Click;
            dsrDesigner_06.Click += dsrDesigner_06_Click;
            dsrDesigner_07.Click += dsrDesigner_07_Click;
            dsrDesigner_08.Click += dsrDesigner_08_Click;
            dsrDesigner_LIN8.Click += dsrDesigner_LIN8_Click;
            dsrDesigner_LIN2.Click += dsrDesigner_LIN2_Click;
            dsrDesigner_LIN3.Click += dsrDesigner_LIN3_Click;
            dsrDesigner_LIN4.Click += dsrDesigner_LIN4_Click;
            dsrDesigner_LIN5.Click += dsrDesigner_LIN5_Click;
            dsrDesigner_LIN6.Click += dsrDesigner_LIN6_Click;
            dsrDesigner_TRAN.Click += dsrDesigner_TRAN_Click;
            dsrDesigner_EXP.Click += dsrDesigner_EXP_Click;
            dsrDesigner_IMP.Click += dsrDesigner_IMP_Click;
            dsrDesigner_OPT.Click += dsrDesigner_OPT_Click;
            dsrDesigner_09.Click += dsrDesigner_09_Click;
            dsrDesigner_01.Click += dsrDesigner_01_Click;
            dsrDesigner_LOCA.Click += DsrDesigner_LOCA_Click;
            dsrDesigner_100.Click += DsrDesigner_100_Click;
            fldF020_DOCTOR_MSTR_DOC_AFP_PAYM_GROUP.LookupOn += fldF020_DOCTOR_MSTR_DOC_AFP_PAYM_GROUP_LookupOn;
            fldF020_DOCTOR_MSTR_DOC_DEPT.LookupOn += fldF020_DOCTOR_MSTR_DOC_DEPT_LookupOn;
            fldF020_DOCTOR_MSTR_DOC_NBR.LookupNotOn += fldF020_DOCTOR_MSTR_DOC_NBR_LookupNotOn;
            fldF020_DOCTOR_MSTR_DOC_NBR.Edit += fldF020_DOCTOR_MSTR_DOC_NBR_Edit;
            fldF020_DOCTOR_MSTR_DOC_BANK_BRANCH.Edit += fldF020_DOCTOR_MSTR_DOC_BANK_BRANCH_Edit;
            fldF020_DOCTOR_MSTR_DOC_DEPT.Edit += fldF020_DOCTOR_MSTR_DOC_DEPT_Edit;
            fleF020_DOCTOR_MSTR.SetItemFinals -= FleF020_DOCTOR_MSTR_SetItemFinals;
            dtlF020C_DOC_CLINIC_NEXT_BATCH_NBR.EditClick += DtlF020C_DOC_CLINIC_NEXT_BATCH_NBR_EditClick;
            fldF020_DOCTOR_MSTR_DOC_BANK_NBR.Process += fldF020_DOCTOR_MSTR_DOC_BANK_NBR_Process;
            fldF020_DOCTOR_MSTR_DOC_NAME.Process += fldF020_DOCTOR_MSTR_DOC_NAME_Process;
            fldF020_DOCTOR_MSTR_DOC_OHIP_NBR.Process += fldF020_DOCTOR_MSTR_DOC_OHIP_NBR_Process;
            fldF020_DOCTOR_MSTR_DOC_FULL_PART_IND.Process += fldF020_DOCTOR_MSTR_DOC_FULL_PART_IND_Process;
            base.Page_Load();

            // TODO: The following elements have Input/Output Scaling defined in the Dictionary or Screen.  Manual steps may be required:
            //       F020_DOCTOR_AUDIT.DOC_YRLY_CEILING_COMPUTED InputScale: 2 OutputScale: 0
            //       F020_DOCTOR_AUDIT.DOC_YRLY_EXPENSE_COMPUTED InputScale: 2 OutputScale: 0
            //       F020_DOCTOR_AUDIT.DOC_YTDINC_G InputScale: 2 OutputScale: 0
            //       F020_DOCTOR_MSTR.DOC_YRLY_CEILING_COMPUTED InputScale: 2 OutputScale: 0
            //       F020_DOCTOR_MSTR.DOC_YRLY_EXPENSE_COMPUTED InputScale: 2 OutputScale: 0
            //       F020_DOCTOR_MSTR.DOC_YTDINC_G InputScale: 2 OutputScale: 0
            // TODO: The following FIELD(S) on the form are redefine elements.  Manual steps may be required:
            //       F020_DOCTOR_MSTR.DOC_INITS
            //       F020_DOCTOR_MSTR.DOC_SIN_NBR
            //       F020_DOCTOR_MSTR.DOC_ADDR_HOME_PC
            //       F020_DOCTOR_MSTR.DOC_DATE_FAC_START
            //       F020_DOCTOR_MSTR.DOC_DATE_FAC_TERM
            //       F020_DOCTOR_MSTR.DOC_ADDR_OFFICE_PC


        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            T_DOC_INITS = new CoreCharacter("T_DOC_INITS", 3, this, Common.cEmptyString);
            T_DOC_ADDR_HOME_PC = new CoreCharacter("T_DOC_ADDR_HOME_PC", 6, this, Common.cEmptyString);
            T_DOC_ADDR_OFFICE_PC = new CoreCharacter("T_DOC_ADDR_OFFICE_PC", 6, this, Common.cEmptyString);
            T_DOC_SIN_NBR = new CoreDecimal("T_DOC_SIN_NBR", 9, this);
            T_DOC_DATE_FAC_START = new CoreDecimal("T_DOC_SIN_NBR", 8, this);
            T_DOC_DATE_FAC_TERM = new CoreDecimal("T_DOC_SIN_NBR", 8, this);
            X_DOC_NBR = new CoreCharacter("X_DOC_NBR", 3, this, Common.cEmptyString);
            X_DOC_NBR_LENGTH = new CoreDecimal("X_DOC_NBR_LENGTH", 6, this);
            X_DOC_DEPT = new CoreDecimal("X_DOC_DEPT", 6, this);
            X_DOC_CLINIC_NBR = new CoreDecimal("X_DOC_CLINIC_NBR", 6, this);
            X_DOC_NAME = new CoreCharacter("X_DOC_NAME", 30, this, Common.cEmptyString);
            X_DOC_INITS = new CoreCharacter("X_DOC_INITS", 30, this, Common.cEmptyString);
            X_DOC_SIN_NBR = new CoreDecimal("X_DOC_SIN_NBR", 6, this);
            X_DOC_SUB_SPECIALTY = new CoreCharacter("X_DOC_SUB_SPECIALTY", 30, this, Common.cEmptyString);
            X_DOC_FULL_PART_IND = new CoreCharacter("X_DOC_FULL_PART_IND", 30, this, Common.cEmptyString);
            X_DOC_ADDR_HOME_1 = new CoreCharacter("X_DOC_ADDR_HOME_1", 30, this, Common.cEmptyString);
            X_DOC_ADDR_HOME_2 = new CoreCharacter("X_DOC_ADDR_HOME_2", 30, this, Common.cEmptyString);
            X_DOC_ADDR_HOME_3 = new CoreCharacter("X_DOC_ADDR_HOME_3", 30, this, Common.cEmptyString);
            X_DOC_ADDR_HOME_PC = new CoreCharacter("X_DOC_ADDR_HOME_PC", 30, this, Common.cEmptyString);
            X_DOC_ADDR_OFFICE_1 = new CoreCharacter("X_DOC_ADDR_OFFICE_1", 30, this, Common.cEmptyString);
            X_DOC_ADDR_OFFICE_2 = new CoreCharacter("X_DOC_ADDR_OFFICE_2", 30, this, Common.cEmptyString);
            X_DOC_ADDR_OFFICE_3 = new CoreCharacter("X_DOC_ADDR_OFFICE_3", 30, this, Common.cEmptyString);
            X_DOC_ADDR_OFFICE_PC = new CoreCharacter("X_DOC_ADDR_OFFICE_PC", 30, this, Common.cEmptyString);
            X_DOC_BANK_NBR = new CoreDecimal("X_DOC_BANK_NBR", 6, this);
            X_DOC_BANK_BRANCH = new CoreDecimal("X_DOC_BANK_BRANCH", 6, this);
            X_DOC_BANK_ACCT = new CoreCharacter("X_DOC_BANK_ACCT", 30, this, Common.cEmptyString);
            X_DOC_DATE_FAC_START = new CoreDate("X_DOC_DATE_FAC_START", this);
            X_DOC_DATE_FAC_TERM = new CoreDate("X_DOC_DATE_FAC_TERM", this);
            COMLINE = new CoreCharacter("COMLINE", 256, this, Common.cEmptyString);
            X_REC_COUNT = new CoreDecimal("X_REC_COUNT", 6, this);
            TMP_NBR = new CoreDecimal("TMP_NBR", 6, this);
            X_DOC_TERMINATED_FLAG = new CoreCharacter("X_DOC_TERMINATED_FLAG", 1, this, Common.cEmptyString);
            W_DELETE_FLAG = new CoreCharacter("W_DELETE_FLAG", 1, this, Common.cEmptyString);
            X_DOC_DEPT_FLAG = new CoreCharacter("X_DOC_DEPT_FLAG", 1, this, Common.cEmptyString);
            W_COUNT = new CoreDecimal("W_COUNT", 6, this);
            W_PASSWORD = new CoreCharacter("W_PASSWORD", 7, this, Common.cEmptyString);
            W_LOC_NBR = new CoreCharacter("W_LOC_NBR", 4, this, Common.cEmptyString);
            X_DOC_OHIP_NBR = new CoreDecimal("X_DOC_OHIP_NBR", 6, this);
            X_DOC_OHIP_NBR_1 = new CoreDecimal("X_DOC_OHIP_NBR_1", 6, this);
            X_DOC_OHIP_NBR_2 = new CoreDecimal("X_DOC_OHIP_NBR_2", 6, this);
            X_DOC_OHIP_NBR_3 = new CoreDecimal("X_DOC_OHIP_NBR_3", 6, this);
            X_DOC_OHIP_NBR_4 = new CoreDecimal("X_DOC_OHIP_NBR_4", 6, this);
            X_DOC_OHIP_NBR_5 = new CoreDecimal("X_DOC_OHIP_NBR_5", 6, this);
            X_DOC_OHIP_NBR_6 = new CoreDecimal("X_DOC_OHIP_NBR_6", 6, this);
            X_CLINIC_NBR = new CoreDecimal("X_CLINIC_NBR", 2, this);
            fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF020C_DOC_CLINIC_NEXT_BATCH_NBR = new SqlFileObject(this, FileTypes.Detail, 6, "INDEXED", "F020C_DOC_CLINIC_NEXT_BATCH_NBR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF074_AFP_GROUP_MSTR = new SqlFileObject(this, FileTypes.Reference, 0, "[101C].INDEXED", "F074_AFP_GROUP_MSTR", "", false, false, false, 0, "m_cnnQUERY");
            fleF030_LOCATIONS_MSTR = new SqlFileObject(this, FileTypes.Reference, 0, "[101C].INDEXED", "F030_LOCATIONS_MSTR", "", false, false, false, 0, "m_cnnQUERY");
            fleF002_CLAIMS_MSTR_M020 = new SqlFileObject(this, FileTypes.Designer, 0, "INDEXED", "F002_CLAIMS_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF070_DEPT_MSTR = new SqlFileObject(this, FileTypes.Reference, 0, "[101C].INDEXED", "F070_DEPT_MSTR", "", false, false, false, 0, "m_cnnQUERY");
            fleF080_BANK_MSTR = new SqlFileObject(this, FileTypes.Reference, 0, "[101C].INDEXED", "F080_BANK_MSTR", "", false, false, false, 0, "m_cnnQUERY");
            fleCONSTANTS_MSTR_REC_4 = new SqlFileObject(this, FileTypes.Designer, 0, "INDEXED", "CONSTANTS_MSTR_REC_4", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleICONST_MSTR_REC = new SqlFileObject(this, FileTypes.Reference, 0, "INDEXED", "ICONST_MSTR_REC", "", false, false, false, 0, "m_cnnQUERY");
            fleTRANSFER_FILE = new SqlFileObject(this, FileTypes.Designer, 0, "SEQUENTIAL", "/TEMP/TRANSFER_AREA/RMABILL/TRANSFER", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SequentialDataBase);
            fleF021_AVAIL_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Designer, 0, "INDEXED", "F021_AVAIL_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
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
            W_DATE = new CoreDate("W_DATE", this);
            W_START_DATE = new CoreDate("W_START_DATE", this);
            APP_VERSION = new CoreCharacter("APP_VERSION", 10, this, Common.cEmptyString);
            APP_MSG = new CoreCharacter("APP_MSG", 15, this, Common.cEmptyString);

           
            VERSION_LIVE.GetValue += VERSION_LIVE_GetValue;
            fleF074_AFP_GROUP_MSTR.Access += fleF074_AFP_GROUP_MSTR_Access;
            fleF030_LOCATIONS_MSTR.Access += fleF030_LOCATIONS_MSTR_Access;
            fleF002_CLAIMS_MSTR_M020.Access += fleF002_CLAIMS_MSTR_M020_Access;
            fleF070_DEPT_MSTR.Access += fleF070_DEPT_MSTR_Access;
            fleF080_BANK_MSTR.Access += fleF080_BANK_MSTR_Access;
            fleICONST_MSTR_REC.Access += fleICONST_MSTR_REC_Access;
            fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.Access += fleF020C_DOC_CLINIC_NEXT_BATCH_NBR_Access;
            fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.InitializeItems += FleF020C_DOC_CLINIC_NEXT_BATCH_NBR_InitializeItems;
            W_DATE.GetInitialValue += W_DATE_GetInitialValue;

        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;
            VERSION_LIVE.GetValue -= VERSION_LIVE_GetValue;
            fleF074_AFP_GROUP_MSTR.Access -= fleF074_AFP_GROUP_MSTR_Access;
            fleF030_LOCATIONS_MSTR.Access -= fleF030_LOCATIONS_MSTR_Access;
            fleF002_CLAIMS_MSTR_M020.Access -= fleF002_CLAIMS_MSTR_M020_Access;
            fleF070_DEPT_MSTR.Access -= fleF070_DEPT_MSTR_Access;
            fleF080_BANK_MSTR.Access -= fleF080_BANK_MSTR_Access;
            fleICONST_MSTR_REC.Access -= fleICONST_MSTR_REC_Access;
            fldF020_DOCTOR_MSTR_DOC_AFP_PAYM_GROUP.LookupOn -= fldF020_DOCTOR_MSTR_DOC_AFP_PAYM_GROUP_LookupOn;
            fldF020_DOCTOR_MSTR_DOC_DEPT.LookupOn -= fldF020_DOCTOR_MSTR_DOC_DEPT_LookupOn;
            fldF020_DOCTOR_MSTR_DOC_NBR.LookupNotOn -= fldF020_DOCTOR_MSTR_DOC_NBR_LookupNotOn;
            fldF020_DOCTOR_MSTR_DOC_NBR.Edit -= fldF020_DOCTOR_MSTR_DOC_NBR_Edit;
            fldF020_DOCTOR_MSTR_DOC_BANK_BRANCH.Edit -= fldF020_DOCTOR_MSTR_DOC_BANK_BRANCH_Edit;
            fldF020_DOCTOR_MSTR_DOC_DEPT.Edit -= fldF020_DOCTOR_MSTR_DOC_DEPT_Edit;
            fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.Access -= fleF020C_DOC_CLINIC_NEXT_BATCH_NBR_Access;

            dsrDesigner_PASS.Click -= dsrDesigner_PASS_Click;
            dsrDesigner_ALT.Click -= dsrDesigner_ALT_Click;
            dsrDesigner_02.Click -= dsrDesigner_02_Click;
            dsrDesigner_03.Click -= dsrDesigner_03_Click;
            dsrDesigner_04.Click -= dsrDesigner_04_Click;
            dsrDesigner_05.Click -= dsrDesigner_05_Click;
            dsrDesigner_06.Click -= dsrDesigner_06_Click;
            dsrDesigner_07.Click -= dsrDesigner_07_Click;
            dsrDesigner_08.Click -= dsrDesigner_08_Click;
            dsrDesigner_LIN8.Click -= dsrDesigner_LIN8_Click;
            dsrDesigner_LIN2.Click -= dsrDesigner_LIN2_Click;
            dsrDesigner_LIN3.Click -= dsrDesigner_LIN3_Click;
            dsrDesigner_LIN4.Click -= dsrDesigner_LIN4_Click;
            dsrDesigner_LIN5.Click -= dsrDesigner_LIN5_Click;
            dsrDesigner_LIN6.Click -= dsrDesigner_LIN6_Click;
            dsrDesigner_TRAN.Click -= dsrDesigner_TRAN_Click;
            dsrDesigner_EXP.Click -= dsrDesigner_EXP_Click;
            dsrDesigner_IMP.Click -= dsrDesigner_IMP_Click;
            dsrDesigner_OPT.Click -= dsrDesigner_OPT_Click;
            dsrDesigner_09.Click -= dsrDesigner_09_Click;
            dsrDesigner_01.Click -= dsrDesigner_01_Click;
            fleF020_DOCTOR_MSTR.SetItemFinals -= FleF020_DOCTOR_MSTR_SetItemFinals;
            dsrDesigner_100.Click -= DsrDesigner_100_Click;
            dtlF020C_DOC_CLINIC_NEXT_BATCH_NBR.EditClick -= DtlF020C_DOC_CLINIC_NEXT_BATCH_NBR_EditClick;
            fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.InitializeItems -= FleF020C_DOC_CLINIC_NEXT_BATCH_NBR_InitializeItems;
            W_DATE.GetInitialValue -= W_DATE_GetInitialValue;
            fldF020_DOCTOR_MSTR_DOC_BANK_NBR.Process -= fldF020_DOCTOR_MSTR_DOC_BANK_NBR_Process;
            fldF020_DOCTOR_MSTR_DOC_NAME.Process -= fldF020_DOCTOR_MSTR_DOC_NAME_Process;
            fldF020_DOCTOR_MSTR_DOC_OHIP_NBR.Process -= fldF020_DOCTOR_MSTR_DOC_OHIP_NBR_Process;
            fldF020_DOCTOR_MSTR_DOC_FULL_PART_IND.Process -= fldF020_DOCTOR_MSTR_DOC_FULL_PART_IND_Process;
        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private SqlConnection m_cnnQUERY = new SqlConnection();
        private SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
        private SqlTransaction m_trnTRANS_UPDATE;
        private DCharacter VERSION_LIVE = new DCharacter(10);
        private void VERSION_LIVE_GetValue(ref string Value)
        {

            try
            {
                Value = "101c";


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private CoreCharacter T_DOC_INITS;
        private CoreDecimal T_DOC_SIN_NBR;
        private CoreDecimal T_DOC_DATE_FAC_START;
        private CoreDecimal T_DOC_DATE_FAC_TERM;
        private CoreCharacter T_DOC_ADDR_HOME_PC;
        private CoreCharacter T_DOC_ADDR_OFFICE_PC;

        private CoreCharacter X_DOC_NBR;
        private CoreDecimal X_DOC_NBR_LENGTH;
        private CoreDecimal X_DOC_DEPT;
        private CoreDecimal X_DOC_CLINIC_NBR;
        private CoreCharacter X_DOC_NAME;
        private CoreCharacter X_DOC_INITS;
        private CoreDecimal X_DOC_SIN_NBR;
        private CoreCharacter X_DOC_SUB_SPECIALTY;
        private CoreCharacter X_DOC_FULL_PART_IND;
        private CoreCharacter X_DOC_ADDR_HOME_1;
        private CoreCharacter X_DOC_ADDR_HOME_2;
        private CoreCharacter X_DOC_ADDR_HOME_3;
        private CoreCharacter X_DOC_ADDR_HOME_PC;
        private CoreCharacter X_DOC_ADDR_OFFICE_1;
        private CoreCharacter X_DOC_ADDR_OFFICE_2;
        private CoreCharacter X_DOC_ADDR_OFFICE_3;
        private CoreCharacter X_DOC_ADDR_OFFICE_PC;
        private CoreDecimal X_DOC_BANK_NBR;
        private CoreDecimal X_DOC_BANK_BRANCH;
        private CoreCharacter X_DOC_BANK_ACCT;
        private CoreDate X_DOC_DATE_FAC_START;
        private CoreDate X_DOC_DATE_FAC_TERM;
        private CoreCharacter COMLINE;
        private CoreDecimal X_REC_COUNT;
        private CoreDecimal TMP_NBR;
        private CoreCharacter X_DOC_TERMINATED_FLAG;
        private CoreCharacter W_DELETE_FLAG;
        private CoreCharacter X_DOC_DEPT_FLAG;
        private CoreDecimal W_COUNT;
        private CoreCharacter W_PASSWORD;
        private CoreCharacter W_LOC_NBR;
        private CoreDecimal X_DOC_OHIP_NBR;
        private CoreDecimal X_DOC_OHIP_NBR_1;
        private CoreDecimal X_DOC_OHIP_NBR_2;
        private CoreDecimal X_DOC_OHIP_NBR_3;
        private CoreDecimal X_DOC_OHIP_NBR_4;
        private CoreDecimal X_DOC_OHIP_NBR_5;
        private CoreDecimal X_DOC_OHIP_NBR_6;
        private CoreDecimal X_CLINIC_NBR;

        private SqlFileObject fleF020C_DOC_CLINIC_NEXT_BATCH_NBR;
        private void FleF020C_DOC_CLINIC_NEXT_BATCH_NBR_InitializeItems(bool Fixed)
        {
            try
            {
                fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.set_SetValue("DOC_NBR", true, fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR"));

            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }
        }
        private void fleF020C_DOC_CLINIC_NEXT_BATCH_NBR_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.ElementOwner("DOC_NBR")).Append(" = ").Append(Common.StringToField(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")));

                strText.Append(" ORDER BY ").Append(fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.ElementOwner("DOC_NBR"));
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

        private SqlFileObject fleF020_DOCTOR_MSTR;
        private void FleF020_DOCTOR_MSTR_SetItemFinals()
        {
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_INIT1", T_DOC_INITS.Value.PadRight(3, ' ').Substring(0, 1));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_INIT2", T_DOC_INITS.Value.PadRight(3, ' ').Substring(1, 1));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_INIT3", T_DOC_INITS.Value.PadRight(3, ' ').Substring(2, 1));
            if (T_DOC_SIN_NBR.Value != 0)
            {
                fleF020_DOCTOR_MSTR.set_SetValue("DOC_SIN_123", Convert.ToInt32(T_DOC_SIN_NBR.Value.ToString().PadLeft(9, '0').Substring(0, 3)));
                fleF020_DOCTOR_MSTR.set_SetValue("DOC_SIN_456", Convert.ToInt32(T_DOC_SIN_NBR.Value.ToString().PadLeft(9, '0').Substring(3, 3)));
                fleF020_DOCTOR_MSTR.set_SetValue("DOC_SIN_789", Convert.ToInt32(T_DOC_SIN_NBR.Value.ToString().PadLeft(9, '0').Substring(6, 3)));
            }
            if (T_DOC_DATE_FAC_START.Value != 0)
            {
                fleF020_DOCTOR_MSTR.set_SetValue("DOC_DATE_FAC_START_YY", T_DOC_DATE_FAC_START.Value.ToString().PadRight(8, ' ').Substring(0, 4));
                fleF020_DOCTOR_MSTR.set_SetValue("DOC_DATE_FAC_START_MM", T_DOC_DATE_FAC_START.Value.ToString().PadRight(8, ' ').Substring(4, 2));
                fleF020_DOCTOR_MSTR.set_SetValue("DOC_DATE_FAC_START_DD", T_DOC_DATE_FAC_START.Value.ToString().PadRight(8, ' ').Substring(6, 2));
                fleF020_DOCTOR_MSTR.set_SetValue("DOC_DATE_FAC_TERM_YY", T_DOC_DATE_FAC_TERM.Value.ToString().PadRight(8, ' ').Substring(0, 4));
                fleF020_DOCTOR_MSTR.set_SetValue("DOC_DATE_FAC_TERM_MM", T_DOC_DATE_FAC_TERM.Value.ToString().PadRight(8, ' ').Substring(4, 2));
                fleF020_DOCTOR_MSTR.set_SetValue("DOC_DATE_FAC_TERM_DD", T_DOC_DATE_FAC_TERM.Value.ToString().PadRight(8, ' ').Substring(6, 2));
            }
            if (T_DOC_ADDR_HOME_PC.Value != "")
            {
                fleF020_DOCTOR_MSTR.set_SetValue("DOC_ADDR_HOME_PC1", T_DOC_ADDR_HOME_PC.Value.PadRight(6, ' ').Substring(0, 1));
                fleF020_DOCTOR_MSTR.set_SetValue("DOC_ADDR_HOME_PC2", T_DOC_ADDR_HOME_PC.Value.PadRight(6, ' ').Substring(1, 1));
                fleF020_DOCTOR_MSTR.set_SetValue("DOC_ADDR_HOME_PC3", T_DOC_ADDR_HOME_PC.Value.PadRight(6, ' ').Substring(2, 1));
                fleF020_DOCTOR_MSTR.set_SetValue("DOC_ADDR_HOME_PC4", T_DOC_ADDR_HOME_PC.Value.PadRight(6, ' ').Substring(3, 1));
                fleF020_DOCTOR_MSTR.set_SetValue("DOC_ADDR_HOME_PC5", T_DOC_ADDR_HOME_PC.Value.PadRight(6, ' ').Substring(4, 1));
                fleF020_DOCTOR_MSTR.set_SetValue("DOC_ADDR_HOME_PC6", T_DOC_ADDR_HOME_PC.Value.PadRight(6, ' ').Substring(5, 1));
            }
            if (T_DOC_ADDR_OFFICE_PC.Value != "")
            {
                fleF020_DOCTOR_MSTR.set_SetValue("DOC_ADDR_OFFICE_PC1", T_DOC_ADDR_OFFICE_PC.Value.PadRight(6, ' ').Substring(0, 1));
                fleF020_DOCTOR_MSTR.set_SetValue("DOC_ADDR_OFFICE_PC2", T_DOC_ADDR_OFFICE_PC.Value.PadRight(6, ' ').Substring(1, 1));
                fleF020_DOCTOR_MSTR.set_SetValue("DOC_ADDR_OFFICE_PC3", T_DOC_ADDR_OFFICE_PC.Value.PadRight(6, ' ').Substring(2, 1));
                fleF020_DOCTOR_MSTR.set_SetValue("DOC_ADDR_OFFICE_PC4", T_DOC_ADDR_OFFICE_PC.Value.PadRight(6, ' ').Substring(3, 1));
                fleF020_DOCTOR_MSTR.set_SetValue("DOC_ADDR_OFFICE_PC5", T_DOC_ADDR_OFFICE_PC.Value.PadRight(6, ' ').Substring(4, 1));
                fleF020_DOCTOR_MSTR.set_SetValue("DOC_ADDR_OFFICE_PC6", T_DOC_ADDR_OFFICE_PC.Value.PadRight(6, ' ').Substring(5, 1));
            }



        }
        private SqlFileObject fleF074_AFP_GROUP_MSTR;

        private void fleF074_AFP_GROUP_MSTR_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleF074_AFP_GROUP_MSTR.ElementOwner("DOC_AFP_PAYM_GROUP")).Append(" = ").Append(Common.StringToField(fleF020_DOCTOR_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP")));

                strText.Append(" ORDER BY ").Append(fleF074_AFP_GROUP_MSTR.ElementOwner("DOC_AFP_PAYM_GROUP"));
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

        private SqlFileObject fleF030_LOCATIONS_MSTR;

        private void fleF030_LOCATIONS_MSTR_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleF030_LOCATIONS_MSTR.ElementOwner("LOC_NBR")).Append(" = ").Append(Common.StringToField(W_LOC_NBR.Value));

                strText.Append(" ORDER BY ").Append(fleF030_LOCATIONS_MSTR.ElementOwner("LOC_NBR"));
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

        private SqlFileObject fleF002_CLAIMS_MSTR_M020;

        private void fleF002_CLAIMS_MSTR_M020_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleF002_CLAIMS_MSTR_M020.ElementOwner("KEY_CLM_TYPE")).Append(" = ").Append(Common.StringToField(("B")));
                strText.Append(" AND ").Append(fleF002_CLAIMS_MSTR_M020.ElementOwner("KEY_CLM_BATCH_NBR_RED")).Append(" = ").Append(Common.StringToField((QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CLINIC_NBR"), 2) + fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR") + "@")));

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

        private SqlFileObject fleCONSTANTS_MSTR_REC_4;
        private SqlFileObject fleICONST_MSTR_REC;

        private void fleICONST_MSTR_REC_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleICONST_MSTR_REC.ElementOwner("ICONST_CLINIC_NBR_1_2")).Append(" = ").Append((X_CLINIC_NBR.Value));

                strText.Append(" ORDER BY ").Append(fleICONST_MSTR_REC.ElementOwner("ICONST_CLINIC_NBR_1_2"));
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

        private SqlFileObject fleTRANSFER_FILE;
        private SqlFileObject fleF021_AVAIL_DOCTOR_MSTR;
        //#CORE_BEGIN_INCLUDE: SAVEF020AUDIT_VAR"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/26/2017 10:18:32 AM

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
        private CoreDate W_DATE;
        private void W_DATE_GetInitialValue()
        {
            W_DATE.InitialValue = QDesign.SysDate(ref m_cnnQUERY);
        }
        private CoreDate W_START_DATE;
        private CoreCharacter APP_VERSION;

        private CoreCharacter APP_MSG;
        #endregion

        #region "Standard Generated Procedures"

        #region "Grid Field Declarations"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:10:39 AM

        protected TextBox fldF020C_DOC_CLINIC_NEXT_BATCH_NBR_DOC_NX_AVAIL_BATCH;
        protected ComboBox fldF020C_DOC_CLINIC_NEXT_BATCH_NBR_DOC_CLINIC_NBR_STATUS;
        protected TextBox fldF020C_DOC_CLINIC_NEXT_BATCH_NBR_DOC_CLINIC_NBR;

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:10:39 AM
        //#-----------------------------------------
        //# GetGridFieldObject Procedure.
        //#-----------------------------------------

        protected override void GetGridFieldObject(object DataListField, ref object CoreField, string Name)
        {

            try
            {
                switch (Name.ToUpper())
                {
                    case "FLDGRDF020C_DOC_CLINIC_NEXT_BATCH_NBR_DOC_NX_AVAIL_BATCH":
                        fldF020C_DOC_CLINIC_NEXT_BATCH_NBR_DOC_NX_AVAIL_BATCH = (TextBox)DataListField;
                        CoreField = fldF020C_DOC_CLINIC_NEXT_BATCH_NBR_DOC_NX_AVAIL_BATCH;
                        fldF020C_DOC_CLINIC_NEXT_BATCH_NBR_DOC_NX_AVAIL_BATCH.Bind(fleF020C_DOC_CLINIC_NEXT_BATCH_NBR);
                      
                        break;
                    case "FLDGRDF020C_DOC_CLINIC_NEXT_BATCH_NBR_DOC_CLINIC_NBR_STATUS":
                        fldF020C_DOC_CLINIC_NEXT_BATCH_NBR_DOC_CLINIC_NBR_STATUS = (ComboBox)DataListField;
                        CoreField = fldF020C_DOC_CLINIC_NEXT_BATCH_NBR_DOC_CLINIC_NBR_STATUS;
                        fldF020C_DOC_CLINIC_NEXT_BATCH_NBR_DOC_CLINIC_NBR_STATUS.Bind(fleF020C_DOC_CLINIC_NEXT_BATCH_NBR);
                        break;
                    case "FLDGRDF020C_DOC_CLINIC_NEXT_BATCH_NBR_DOC_CLINIC_NBR":
                        fldF020C_DOC_CLINIC_NEXT_BATCH_NBR_DOC_CLINIC_NBR = (TextBox)DataListField;
                        CoreField = fldF020C_DOC_CLINIC_NEXT_BATCH_NBR_DOC_CLINIC_NBR;
                        fldF020C_DOC_CLINIC_NEXT_BATCH_NBR_DOC_CLINIC_NBR.Bind(fleF020C_DOC_CLINIC_NEXT_BATCH_NBR);
                        fldF020C_DOC_CLINIC_NEXT_BATCH_NBR_DOC_CLINIC_NBR.Edit -= fldF020_DOCTOR_MSTR_DOC_CLINIC_NBR_Edit;
                        fldF020C_DOC_CLINIC_NEXT_BATCH_NBR_DOC_CLINIC_NBR.Edit += fldF020_DOCTOR_MSTR_DOC_CLINIC_NBR_Edit;
                        fldF020C_DOC_CLINIC_NEXT_BATCH_NBR_DOC_CLINIC_NBR.LookupNotOn -= fldF020C_DOC_CLINIC_NEXT_BATCH_NBR_DOC_CLINIC_NBR_LookupNotOn;
                        fldF020C_DOC_CLINIC_NEXT_BATCH_NBR_DOC_CLINIC_NBR.LookupNotOn += fldF020C_DOC_CLINIC_NEXT_BATCH_NBR_DOC_CLINIC_NBR_LookupNotOn;
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

        private void fldF020C_DOC_CLINIC_NEXT_BATCH_NBR_DOC_CLINIC_NBR_LookupNotOn(ref bool LookupNotOnExecuted)
        {
            try
            {
                bool blnAlreadyExists = false;
                StringBuilder strSQL = new StringBuilder("SELECT ").Append(fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.ElementOwner("DOC_CLINIC_NBR"));
                strSQL.Append(" FROM ");
                strSQL.Append(fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.TableNameWithAlias());
                strSQL.Append(" WHERE ").Append(fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.ElementOwner("DOC_CLINIC_NBR")).Append(" = ").Append(Common.StringToField(FieldText));
                strSQL.Append(" AND  ").Append(fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.ElementOwner("DOC_NBR")).Append(" = ").Append(Common.StringToField(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")));

                if (!LookupNotOn(strSQL, fleF020C_DOC_CLINIC_NEXT_BATCH_NBR, "DOC_CLINIC_NBR", FieldText))
                {
                    blnAlreadyExists = true;
                }

                if (blnAlreadyExists)
                {
                    ErrorMessage("Record exists in lookup table.");
                    
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
        //#-----------------------------------------
        //# SetRelations Procedure.
        //#-----------------------------------------

        public override void SetRelations()
        {

            try
            {
                dtlF020C_DOC_CLINIC_NEXT_BATCH_NBR.OccursWithFile = fleF020C_DOC_CLINIC_NEXT_BATCH_NBR;

            }
            catch (CustomApplicationException ex)
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
        //# Do not delete, modify or move it.  Updated: 5/26/2017 10:18:35 AM

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
            fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.Transaction = m_trnTRANS_UPDATE;
            fleF002_CLAIMS_MSTR_M020.Transaction = m_trnTRANS_UPDATE;
            fleCONSTANTS_MSTR_REC_4.Transaction = m_trnTRANS_UPDATE;
            fleTRANSFER_FILE.Transaction = m_trnTRANS_UPDATE;
            fleF021_AVAIL_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
            fleF020_DOCTOR_AUDIT.Transaction = m_trnTRANS_UPDATE;


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/26/2017 10:18:35 AM

        //#-----------------------------------------
        //# InitializeFiles Procedure.
        //#-----------------------------------------

        protected override void InitializeFiles()
        {

            try
            {
                Initialize_TRANS_UPDATE();
                fleF074_AFP_GROUP_MSTR.Connection = m_cnnQUERY;
                fleF030_LOCATIONS_MSTR.Connection = m_cnnQUERY;
                fleF070_DEPT_MSTR.Connection = m_cnnQUERY;
                fleF080_BANK_MSTR.Connection = m_cnnQUERY;
                fleICONST_MSTR_REC.Connection = m_cnnQUERY;


            }
            catch (CustomApplicationException ex)
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
                fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.Dispose();
                fleF074_AFP_GROUP_MSTR.Dispose();
                fleF030_LOCATIONS_MSTR.Dispose();
                fleF002_CLAIMS_MSTR_M020.Dispose();
                fleF070_DEPT_MSTR.Dispose();
                fleF080_BANK_MSTR.Dispose();
                fleCONSTANTS_MSTR_REC_4.Dispose();
                fleICONST_MSTR_REC.Dispose();
                fleTRANSFER_FILE.Dispose();
                fleF021_AVAIL_DOCTOR_MSTR.Dispose();
                fleF020_DOCTOR_AUDIT.Dispose();


            }
            catch (CustomApplicationException ex)
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/26/2017 10:18:33 AM
        //#-----------------------------------------
        protected override void DisplayFormatting()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/26/2017 10:18:33 AM
                Display(ref fldF020_DOCTOR_MSTR_DOC_NBR);
                Display(ref fldAPP_MSG);
                Display(ref fldF020_DOCTOR_MSTR_DOC_NAME);
                Display(ref fldF020_DOCTOR_MSTR_DOC_INITS);
                Display(ref fldF020_DOCTOR_MSTR_DOC_OHIP_NBR);
                Display(ref fldF020_DOCTOR_MSTR_DOC_SIN_NBR);
                Display(ref fldF020_DOCTOR_MSTR_DOC_SUB_SPECIALTY);
                Display(ref fldF020_DOCTOR_MSTR_DOC_DEPT);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_CLINIC_NBR);
                Display(ref fldF020_DOCTOR_MSTR_DOC_FULL_PART_IND);
                Display(ref fldF020_DOCTOR_MSTR_DOC_AFP_PAYM_GROUP);
                Display(ref fldF020_DOCTOR_MSTR_DOC_ADDR_HOME_1);
                Display(ref fldF020_DOCTOR_MSTR_DOC_ADDR_HOME_2);
                Display(ref fldF020_DOCTOR_MSTR_DOC_ADDR_HOME_3);
                Display(ref fldF020_DOCTOR_MSTR_DOC_ADDR_HOME_PC);
                Display(ref fldF020_DOCTOR_MSTR_DOC_ADDR_OFFICE_1);
                Display(ref fldF020_DOCTOR_MSTR_DOC_ADDR_OFFICE_2);
                Display(ref fldF020_DOCTOR_MSTR_DOC_ADDR_OFFICE_3);
                Display(ref fldF020_DOCTOR_MSTR_DOC_ADDR_OFFICE_PC);
                Display(ref fldF020_DOCTOR_MSTR_DOC_BANK_NBR);
                Display(ref fldF020_DOCTOR_MSTR_DOC_BANK_BRANCH);
                Display(ref fldF020_DOCTOR_MSTR_DOC_BANK_ACCT);
                Display(ref fldF020_DOCTOR_MSTR_DOC_DATE_FAC_START);
                Display(ref fldF020_DOCTOR_MSTR_DOC_DATE_FAC_TERM);
                Display(ref fldF020_DOCTOR_MSTR_GROUP_REGULAR_SERVICE);
                Display(ref fldF020_DOCTOR_MSTR_GROUP_OVER_SERVICED);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_1);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_1_S1);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_1_S2);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_1_S3);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_2);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_2_S1);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_2_S2);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_2_S3);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_3);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_3_S1);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_3_S2);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_3_S3);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_4);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_4_S1);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_4_S2);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_4_S3);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_5);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_5_S1);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_5_S2);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_5_S3);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_6);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_6_S1);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_6_S2);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_6_S3);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_7);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_7_S1);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_7_S2);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_7_S3);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_8);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_8_S1);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_8_S2);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_8_S3);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_9);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_9_S1);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_9_S2);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_9_S3);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_10);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_10_S1);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_10_S2);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_10_S3);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_11);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_11_S1);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_11_S2);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_11_S3);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_12);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_12_S1);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_12_S2);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_12_S3);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_13);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_13_S1);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_13_S2);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_13_S3);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_14);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_14_S1);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_14_S2);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_14_S3);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_15);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_15_S1);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_15_S2);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_15_S3);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_16);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_16_S1);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_16_S2);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_16_S3);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_17);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_17_S1);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_17_S2);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_17_S3);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_18);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_18_S1);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_18_S2);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_18_S3);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_19);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_19_S1);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_19_S2);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_19_S3);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_20);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_20_S1);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_20_S2);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_20_S3);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_21);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_21_S1);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_21_S2);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_21_S3);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_22);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_22_S1);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_22_S2);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_22_S3);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_23);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_23_S1);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_23_S2);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_23_S3);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_24);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_24_S1);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_24_S2);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_24_S3);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_25);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_25_S1);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_25_S2);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_25_S3);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_26);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_26_S1);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_26_S2);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_26_S3);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_27);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_27_S1);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_27_S2);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_27_S3);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_28);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_28_S1);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_28_S2);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_28_S3);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_29);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_29_S1);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_29_S2);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_29_S3);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_30);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_30_S1);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_30_S2);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_30_S3);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_CLINIC_NBR_2);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_NX_AVAIL_BATCH_2);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_CLINIC_NBR_3);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_NX_AVAIL_BATCH_3);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_CLINIC_NBR_4);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_NX_AVAIL_BATCH_4);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_CLINIC_NBR_5);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_NX_AVAIL_BATCH_5);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_CLINIC_NBR_6);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_NX_AVAIL_BATCH_6);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_NX_AVAIL_BATCH);
                Display(ref fldF020_DOCTOR_MSTR_DOC_SPEC_CD);
                Display(ref fldF020_DOCTOR_MSTR_DOC_SPEC_CD_2);
                Display(ref fldF020_DOCTOR_MSTR_DOC_SPEC_CD_3);
                Display(ref fldW_PASSWORD);
                Display(ref fldW_START_DATE);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/26/2017 10:18:33 AM
        //#-----------------------------------------
        protected override void PreDisplayFormatting()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/26/2017 10:18:33 AM
                Display(ref fldAPP_MSG);
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
        //# Do not delete, modify or move it.  Updated: 5/26/2017 10:18:35 AM

        //#-----------------------------------------
        //# BindFields Procedure.
        //#-----------------------------------------

        public override void BindFields()
        {
            try
            {
                fldF020_DOCTOR_MSTR_DOC_NBR.Bind(fleF020_DOCTOR_MSTR);
                fldAPP_MSG.Bind(APP_MSG);
                fldF020_DOCTOR_MSTR_DOC_NAME.Bind(fleF020_DOCTOR_MSTR);
                fldF020_DOCTOR_MSTR_DOC_NAME_SOUNDEX.Bind(fleF020_DOCTOR_MSTR);
                fldF020_DOCTOR_MSTR_DOC_INITS.Bind(T_DOC_INITS);
                fldF020_DOCTOR_MSTR_DOC_OHIP_NBR.Bind(fleF020_DOCTOR_MSTR);
                fldF020_DOCTOR_MSTR_DOC_SIN_NBR.Bind(T_DOC_SIN_NBR);
                fldF020_DOCTOR_MSTR_DOC_SUB_SPECIALTY.Bind(fleF020_DOCTOR_MSTR);
                fldF020_DOCTOR_MSTR_DOC_DEPT.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_CLINIC_NBR.Bind(fleF020_DOCTOR_MSTR);
                fldF020_DOCTOR_MSTR_DOC_FULL_PART_IND.Bind(fleF020_DOCTOR_MSTR);
                fldF020_DOCTOR_MSTR_DOC_AFP_PAYM_GROUP.Bind(fleF020_DOCTOR_MSTR);
                fldF020_DOCTOR_MSTR_DOC_ADDR_HOME_1.Bind(fleF020_DOCTOR_MSTR);
                fldF020_DOCTOR_MSTR_DOC_ADDR_HOME_2.Bind(fleF020_DOCTOR_MSTR);
                fldF020_DOCTOR_MSTR_DOC_ADDR_HOME_3.Bind(fleF020_DOCTOR_MSTR);
                fldF020_DOCTOR_MSTR_DOC_ADDR_HOME_PC.Bind(T_DOC_ADDR_HOME_PC);
                fldF020_DOCTOR_MSTR_DOC_ADDR_OFFICE_1.Bind(fleF020_DOCTOR_MSTR);
                fldF020_DOCTOR_MSTR_DOC_ADDR_OFFICE_2.Bind(fleF020_DOCTOR_MSTR);
                fldF020_DOCTOR_MSTR_DOC_ADDR_OFFICE_3.Bind(fleF020_DOCTOR_MSTR);
                fldF020_DOCTOR_MSTR_DOC_ADDR_OFFICE_PC.Bind(T_DOC_ADDR_OFFICE_PC);
                fldF020_DOCTOR_MSTR_DOC_BANK_NBR.Bind(fleF020_DOCTOR_MSTR);
                fldF020_DOCTOR_MSTR_DOC_BANK_BRANCH.Bind(fleF020_DOCTOR_MSTR);
                fldF020_DOCTOR_MSTR_DOC_BANK_ACCT.Bind(fleF020_DOCTOR_MSTR);
                fldF020_DOCTOR_MSTR_DOC_DATE_FAC_START.Bind(T_DOC_DATE_FAC_START);
                fldF020_DOCTOR_MSTR_DOC_DATE_FAC_TERM.Bind(T_DOC_DATE_FAC_TERM);
                fldF020_DOCTOR_MSTR_GROUP_REGULAR_SERVICE.Bind(fleF020_DOCTOR_MSTR);
                fldF020_DOCTOR_MSTR_GROUP_OVER_SERVICED.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_1.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_1_S1.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_1_S2.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_1_S3.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_2.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_2_S1.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_2_S2.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_2_S3.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_3.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_3_S1.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_3_S2.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_3_S3.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_4.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_4_S1.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_4_S2.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_4_S3.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_5.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_5_S1.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_5_S2.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_5_S3.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_6.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_6_S1.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_6_S2.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_6_S3.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_7.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_7_S1.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_7_S2.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_7_S3.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_8.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_8_S1.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_8_S2.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_8_S3.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_9.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_9_S1.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_9_S2.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_9_S3.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_10.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_10_S1.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_10_S2.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_10_S3.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_11.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_11_S1.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_11_S2.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_11_S3.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_12.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_12_S1.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_12_S2.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_12_S3.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_13.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_13_S1.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_13_S2.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_13_S3.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_14.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_14_S1.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_14_S2.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_14_S3.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_15.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_15_S1.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_15_S2.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_15_S3.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_16.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_16_S1.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_16_S2.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_16_S3.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_17.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_17_S1.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_17_S2.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_17_S3.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_18.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_18_S1.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_18_S2.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_18_S3.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_19.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_19_S1.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_19_S2.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_19_S3.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_20.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_20_S1.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_20_S2.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_20_S3.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_21.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_21_S1.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_21_S2.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_21_S3.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_22.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_22_S1.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_22_S2.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_22_S3.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_23.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_23_S1.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_23_S2.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_23_S3.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_24.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_24_S1.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_24_S2.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_24_S3.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_25.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_25_S1.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_25_S2.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_25_S3.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_26.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_26_S1.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_26_S2.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_26_S3.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_27.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_27_S1.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_27_S2.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_27_S3.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_28.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_28_S1.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_28_S2.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_28_S3.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_29.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_29_S1.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_29_S2.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_29_S3.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_30.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_30_S1.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_30_S2.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_LOC_30_S3.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_CLINIC_NBR_2.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_NX_AVAIL_BATCH_2.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_CLINIC_NBR_3.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_NX_AVAIL_BATCH_3.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_CLINIC_NBR_4.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_NX_AVAIL_BATCH_4.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_CLINIC_NBR_5.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_NX_AVAIL_BATCH_5.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_CLINIC_NBR_6.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_NX_AVAIL_BATCH_6.Bind(fleF020_DOCTOR_MSTR);
                //fldF020_DOCTOR_MSTR_DOC_NX_AVAIL_BATCH.Bind(fleF020_DOCTOR_MSTR);
                fldF020_DOCTOR_MSTR_DOC_SPEC_CD.Bind(fleF020_DOCTOR_MSTR);
                fldF020_DOCTOR_MSTR_DOC_SPEC_CD_2.Bind(fleF020_DOCTOR_MSTR);
                fldF020_DOCTOR_MSTR_DOC_SPEC_CD_3.Bind(fleF020_DOCTOR_MSTR);
                fldW_PASSWORD.Bind(W_PASSWORD);
                fldW_START_DATE.Bind(W_START_DATE);

            }
            catch (CustomApplicationException ex)
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



        private void fldF020_DOCTOR_MSTR_DOC_AFP_PAYM_GROUP_LookupOn()
        {

            try
            {
                StringBuilder strSQL = new StringBuilder(" WHERE ");
                strSQL.Append("     ").Append(fleF074_AFP_GROUP_MSTR.ElementOwner("DOC_AFP_PAYM_GROUP")).Append(" = ").Append(Common.StringToField(FieldText));

                fleF074_AFP_GROUP_MSTR.GetData(strSQL.ToString(), GetDataOptions.IsOptional);
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




        private void fldF020_DOCTOR_MSTR_DOC_NBR_LookupNotOn(ref bool LookupNotOnExecuted)
        {

            try
            {
                bool blnAlreadyExists = false;
                StringBuilder strSQL = new StringBuilder("SELECT ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR"));
                strSQL.Append(" FROM ");
                strSQL.Append(fleF020_DOCTOR_MSTR.TableNameWithAlias());
                strSQL.Append(" WHERE ");
                strSQL.Append("     ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ").Append(Common.StringToField(FieldText));

                if (!LookupNotOn(strSQL, fleF020_DOCTOR_MSTR, "DOC_NBR", FieldText))
                {
                    blnAlreadyExists = true;
                }

                if (blnAlreadyExists)
                {
                    ErrorMessage("Record exists in lookup table.");
                    
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



        private void fldF020_DOCTOR_MSTR_DOC_NBR_Edit()
        {

            try
            {

                //#CORE_BEGIN_INCLUDE: PAD_DOC_NBR"

                //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
                //# Do not delete, modify or move it.  Updated: 5/26/2017 10:18:32 AM

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
                TMP_NBR.Value = QDesign.Index(FieldText, "*");
                if (QDesign.NULL(FieldText) == QDesign.NULL("000") | QDesign.NULL(TMP_NBR.Value) > 0)
                {
                    ErrorMessage("INVALID Doctor Number - can`t be `000` or contain `*`");
                }
                FieldText = QDesign.UCase(FieldText);


            }
            catch (CustomApplicationException ex)
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

                fleF080_BANK_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                // --> End GET F080_BANK_MSTR <--
                if (!AccessOk)
                {
                    ErrorMessage("INVALID BANK NBR");
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



        private void fldF020_DOCTOR_MSTR_DOC_DEPT_Edit()
        {

            try
            {

                if (QDesign.NULL(OldValue(fleF020_DOCTOR_MSTR.ElementOwner("DOC_DEPT"), fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT"))) != QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT")) & QDesign.NULL(OldValue(fleF020_DOCTOR_MSTR.ElementOwner("DOC_DEPT"), fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT"))) != 0)
                {
                    X_DOC_DEPT_FLAG.Value = "Y";
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



        private void fldF020_DOCTOR_MSTR_DOC_NAME_Process()
        {

            try
            {

                fleF020_DOCTOR_MSTR.set_SetValue("DOC_NAME_SOUNDEX", QDesign.Soundex(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NAME")));


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldF020_DOCTOR_MSTR_DOC_OHIP_NBR_Process()
        {

            try
            {

                if (QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR")) != 0)
                {
                    X_DOC_OHIP_NBR.Value = (QDesign.Floor(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR") / 100000) * 2);
                    if (X_DOC_OHIP_NBR.Value >= 10)
                    {
                        X_DOC_OHIP_NBR_1.Value = QDesign.Floor(X_DOC_OHIP_NBR.Value / 10) + QDesign.PHMod(X_DOC_OHIP_NBR.Value, 10);
                    }
                    else
                    {
                        X_DOC_OHIP_NBR_1.Value = X_DOC_OHIP_NBR.Value;
                    }
                    X_DOC_OHIP_NBR.Value = (QDesign.Floor(QDesign.PHMod(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR"), 10000) / 1000) * 2);
                    if (X_DOC_OHIP_NBR.Value >= 10)
                    {
                        X_DOC_OHIP_NBR_3.Value = QDesign.Floor(X_DOC_OHIP_NBR.Value / 10) + QDesign.PHMod(X_DOC_OHIP_NBR.Value, 10);
                    }
                    else
                    {
                        X_DOC_OHIP_NBR_3.Value = X_DOC_OHIP_NBR.Value;
                    }
                    X_DOC_OHIP_NBR.Value = (QDesign.Floor(QDesign.PHMod(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR"), 100) / 10) * 2);
                    if (X_DOC_OHIP_NBR.Value >= 10)
                    {
                        X_DOC_OHIP_NBR_5.Value = QDesign.Floor(X_DOC_OHIP_NBR.Value / 10) + QDesign.PHMod(X_DOC_OHIP_NBR.Value, 10);
                    }
                    else
                    {
                        X_DOC_OHIP_NBR_5.Value = X_DOC_OHIP_NBR.Value;
                    }
                    X_DOC_OHIP_NBR_6.Value = X_DOC_OHIP_NBR_1.Value + (QDesign.Floor(QDesign.PHMod(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR"), 100000) / 10000)) + X_DOC_OHIP_NBR_3.Value + (QDesign.Floor(QDesign.PHMod(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR"), 1000) / 100)) + X_DOC_OHIP_NBR_5.Value;
                    if (QDesign.NULL(X_DOC_OHIP_NBR_6.Value) > 10)
                    {
                        X_DOC_OHIP_NBR.Value = QDesign.PHMod(X_DOC_OHIP_NBR_6.Value, 10);
                    }
                    else
                    {
                        X_DOC_OHIP_NBR.Value = X_DOC_OHIP_NBR_6.Value;
                    }
                    X_DOC_OHIP_NBR.Value = 10 - X_DOC_OHIP_NBR.Value;
                    if (X_DOC_OHIP_NBR.Value >= 10)
                    {
                        X_DOC_OHIP_NBR.Value = QDesign.PHMod(X_DOC_OHIP_NBR.Value, 10);
                    }
                    if (QDesign.NULL(X_DOC_OHIP_NBR.Value) != QDesign.NULL((QDesign.PHMod(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR"), 10))))
                    {
                        X_DOC_OHIP_NBR_1.Value = (QDesign.PHMod(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR"), 10));
                        if (QDesign.NULL(X_DOC_OHIP_NBR_1.Value) == 1 | QDesign.NULL(X_DOC_OHIP_NBR_1.Value) == 2)
                        {
                            X_DOC_OHIP_NBR.Value = Math.Abs(10 - X_DOC_OHIP_NBR_6.Value);
                            if (QDesign.NULL(X_DOC_OHIP_NBR_1.Value) != QDesign.NULL(QDesign.PHMod(X_DOC_OHIP_NBR.Value, 10)))
                            {
                                Warning("INVALID DOCTOR OHIP NUMBER");
                            }
                        }
                        else
                        {
                            Warning("INVALID DOCTOR OHIP NUMBER");
                        }
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



        private void fldF020_DOCTOR_MSTR_DOC_FULL_PART_IND_Process()
        {

            try
            {

                // --> GET CONSTANTS_MSTR_REC_4 <--
                m_strWhere = new StringBuilder(" WHERE ");
                m_strWhere.Append(" ").Append(fleCONSTANTS_MSTR_REC_4.ElementOwner("CONST_REC_NBR")).Append(" = ");
                m_strWhere.Append((4));

                fleCONSTANTS_MSTR_REC_4.GetData(m_strWhere.ToString());
                // --> End GET CONSTANTS_MSTR_REC_4 <--
                if (!AccessOk)
                {
                    ErrorMessage("SERIOUS ERROR! - Can`t read Const Mstr Rec #4");
                }
                X_DOC_FULL_PART_IND.Value = "N";
                if (QDesign.NULL(fleCONSTANTS_MSTR_REC_4.GetStringValue("CONST_CLASS_LTR1")) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_FULL_PART_IND")))
                {
                    X_DOC_FULL_PART_IND.Value = "Y";
                }
                if (QDesign.NULL(fleCONSTANTS_MSTR_REC_4.GetStringValue("CONST_CLASS_LTR2")) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_FULL_PART_IND")))
                {
                    X_DOC_FULL_PART_IND.Value = "Y";
                }
                if (QDesign.NULL(fleCONSTANTS_MSTR_REC_4.GetStringValue("CONST_CLASS_LTR3")) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_FULL_PART_IND")))
                {
                    X_DOC_FULL_PART_IND.Value = "Y";
                }
                if (QDesign.NULL(fleCONSTANTS_MSTR_REC_4.GetStringValue("CONST_CLASS_LTR4")) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_FULL_PART_IND")))
                {
                    X_DOC_FULL_PART_IND.Value = "Y";
                }
                if (QDesign.NULL(fleCONSTANTS_MSTR_REC_4.GetStringValue("CONST_CLASS_LTR5")) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_FULL_PART_IND")))
                {
                    X_DOC_FULL_PART_IND.Value = "Y";
                }
                if (QDesign.NULL(fleCONSTANTS_MSTR_REC_4.GetStringValue("CONST_CLASS_LTR6")) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_FULL_PART_IND")))
                {
                    X_DOC_FULL_PART_IND.Value = "Y";
                }
                if (QDesign.NULL(fleCONSTANTS_MSTR_REC_4.GetStringValue("CONST_CLASS_LTR7")) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_FULL_PART_IND")))
                {
                    X_DOC_FULL_PART_IND.Value = "Y";
                }
                if (QDesign.NULL(fleCONSTANTS_MSTR_REC_4.GetStringValue("CONST_CLASS_LTR8")) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_FULL_PART_IND")))
                {
                    X_DOC_FULL_PART_IND.Value = "Y";
                }
                if (QDesign.NULL(fleCONSTANTS_MSTR_REC_4.GetStringValue("CONST_CLASS_LTR9")) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_FULL_PART_IND")))
                {
                    X_DOC_FULL_PART_IND.Value = "Y";
                }
                if (QDesign.NULL(fleCONSTANTS_MSTR_REC_4.GetStringValue("CONST_CLASS_LTR10")) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_FULL_PART_IND")))
                {
                    X_DOC_FULL_PART_IND.Value = "Y";
                }
                if (QDesign.NULL(fleCONSTANTS_MSTR_REC_4.GetStringValue("CONST_CLASS_LTR11")) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_FULL_PART_IND")))
                {
                    X_DOC_FULL_PART_IND.Value = "Y";
                }
                if (QDesign.NULL(fleCONSTANTS_MSTR_REC_4.GetStringValue("CONST_CLASS_LTR12")) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_FULL_PART_IND")))
                {
                    X_DOC_FULL_PART_IND.Value = "Y";
                }
                if (QDesign.NULL(fleCONSTANTS_MSTR_REC_4.GetStringValue("CONST_CLASS_LTR13")) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_FULL_PART_IND")))
                {
                    X_DOC_FULL_PART_IND.Value = "Y";
                }
                if (QDesign.NULL(fleCONSTANTS_MSTR_REC_4.GetStringValue("CONST_CLASS_LTR14")) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_FULL_PART_IND")))
                {
                    X_DOC_FULL_PART_IND.Value = "Y";
                }
                if (QDesign.NULL(fleCONSTANTS_MSTR_REC_4.GetStringValue("CONST_CLASS_LTR15")) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_FULL_PART_IND")))
                {
                    X_DOC_FULL_PART_IND.Value = "Y";
                }
                if (QDesign.NULL(X_DOC_FULL_PART_IND.Value) != QDesign.NULL("Y"))
                {
                    ErrorMessage("WRONG CLASS CODE, PLEASE REENTER");
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


        private bool Internal_CHECK_CLINIC()
        {


            try
            {

                if (QDesign.NULL(X_CLINIC_NBR.Value) != 0)
                {
                    // --> GET ICONST_MSTR_REC <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleICONST_MSTR_REC.ElementOwner("ICONST_CLINIC_NBR_1_2")).Append(" = ");
                    m_strWhere.Append((X_CLINIC_NBR.Value));

                    fleICONST_MSTR_REC.GetData(m_strWhere.ToString());
                    // --> End GET ICONST_MSTR_REC <--
                    if (!AccessOk)
                    {
                        ErrorMessage("CLINIC NBR NOT DEFINED,  PLEASE RE-ENTER");
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



        private void fldF020_DOCTOR_MSTR_DOC_CLINIC_NBR_Edit()
        {

            try
            {

                X_CLINIC_NBR.Value = fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetDecimalValue("DOC_CLINIC_NBR");
                Internal_CHECK_CLINIC();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }





        private bool Internal_CHECK_LOCATION()
        {


            try
            {

                if (QDesign.NULL(W_LOC_NBR.Value) != QDesign.NULL(" "))
                {
                    // --> GET F030_LOCATIONS_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF030_LOCATIONS_MSTR.ElementOwner("LOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(W_LOC_NBR.Value));

                    fleF030_LOCATIONS_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F030_LOCATIONS_MSTR <--
                    if (!AccessOk)
                    {
                        ErrorMessage("LOCATION IS NOT ON LOCATIONS MASTER, PLEASE REENTER");
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



        private void fldF020_DOCTOR_MSTR_DOC_LOC_1_Edit()
        {

            try
            {

                W_LOC_NBR.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_1");
                Internal_CHECK_LOCATION();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldF020_DOCTOR_MSTR_DOC_LOC_2_Edit()
        {

            try
            {

                W_LOC_NBR.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_2");
                Internal_CHECK_LOCATION();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldF020_DOCTOR_MSTR_DOC_LOC_3_Edit()
        {

            try
            {

                W_LOC_NBR.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_3");
                Internal_CHECK_LOCATION();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldF020_DOCTOR_MSTR_DOC_LOC_4_Edit()
        {

            try
            {

                W_LOC_NBR.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_4");
                Internal_CHECK_LOCATION();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldF020_DOCTOR_MSTR_DOC_LOC_5_Edit()
        {

            try
            {

                W_LOC_NBR.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_5");
                Internal_CHECK_LOCATION();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldF020_DOCTOR_MSTR_DOC_LOC_6_Edit()
        {

            try
            {

                W_LOC_NBR.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_6");
                Internal_CHECK_LOCATION();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldF020_DOCTOR_MSTR_DOC_LOC_7_Edit()
        {

            try
            {

                W_LOC_NBR.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_7");
                Internal_CHECK_LOCATION();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldF020_DOCTOR_MSTR_DOC_LOC_8_Edit()
        {

            try
            {

                W_LOC_NBR.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_8");
                Internal_CHECK_LOCATION();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldF020_DOCTOR_MSTR_DOC_LOC_9_Edit()
        {

            try
            {

                W_LOC_NBR.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_9");
                Internal_CHECK_LOCATION();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldF020_DOCTOR_MSTR_DOC_LOC_10_Edit()
        {

            try
            {

                W_LOC_NBR.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_10");
                Internal_CHECK_LOCATION();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldF020_DOCTOR_MSTR_DOC_LOC_11_Edit()
        {

            try
            {

                W_LOC_NBR.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_11");
                Internal_CHECK_LOCATION();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldF020_DOCTOR_MSTR_DOC_LOC_12_Edit()
        {

            try
            {

                W_LOC_NBR.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_12");
                Internal_CHECK_LOCATION();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldF020_DOCTOR_MSTR_DOC_LOC_13_Edit()
        {

            try
            {

                W_LOC_NBR.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_13");
                Internal_CHECK_LOCATION();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldF020_DOCTOR_MSTR_DOC_LOC_14_Edit()
        {

            try
            {

                W_LOC_NBR.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_14");
                Internal_CHECK_LOCATION();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldF020_DOCTOR_MSTR_DOC_LOC_15_Edit()
        {

            try
            {

                W_LOC_NBR.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_15");
                Internal_CHECK_LOCATION();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldF020_DOCTOR_MSTR_DOC_LOC_16_Edit()
        {

            try
            {

                W_LOC_NBR.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_16");
                Internal_CHECK_LOCATION();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldF020_DOCTOR_MSTR_DOC_LOC_17_Edit()
        {

            try
            {

                W_LOC_NBR.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_17");
                Internal_CHECK_LOCATION();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldF020_DOCTOR_MSTR_DOC_LOC_18_Edit()
        {

            try
            {

                W_LOC_NBR.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_18");
                Internal_CHECK_LOCATION();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldF020_DOCTOR_MSTR_DOC_LOC_19_Edit()
        {

            try
            {

                W_LOC_NBR.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_19");
                Internal_CHECK_LOCATION();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldF020_DOCTOR_MSTR_DOC_LOC_20_Edit()
        {

            try
            {

                W_LOC_NBR.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_20");
                Internal_CHECK_LOCATION();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldF020_DOCTOR_MSTR_DOC_LOC_21_Edit()
        {

            try
            {

                W_LOC_NBR.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_21");
                Internal_CHECK_LOCATION();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldF020_DOCTOR_MSTR_DOC_LOC_22_Edit()
        {

            try
            {

                W_LOC_NBR.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_22");
                Internal_CHECK_LOCATION();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldF020_DOCTOR_MSTR_DOC_LOC_23_Edit()
        {

            try
            {

                W_LOC_NBR.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_23");
                Internal_CHECK_LOCATION();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldF020_DOCTOR_MSTR_DOC_LOC_24_Edit()
        {

            try
            {

                W_LOC_NBR.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_24");
                Internal_CHECK_LOCATION();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldF020_DOCTOR_MSTR_DOC_LOC_25_Edit()
        {

            try
            {

                W_LOC_NBR.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_25");
                Internal_CHECK_LOCATION();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldF020_DOCTOR_MSTR_DOC_LOC_26_Edit()
        {

            try
            {

                W_LOC_NBR.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_26");
                Internal_CHECK_LOCATION();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldF020_DOCTOR_MSTR_DOC_LOC_27_Edit()
        {

            try
            {

                W_LOC_NBR.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_27");
                Internal_CHECK_LOCATION();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldF020_DOCTOR_MSTR_DOC_LOC_28_Edit()
        {

            try
            {

                W_LOC_NBR.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_28");
                Internal_CHECK_LOCATION();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldF020_DOCTOR_MSTR_DOC_LOC_29_Edit()
        {

            try
            {

                W_LOC_NBR.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_29");
                Internal_CHECK_LOCATION();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldF020_DOCTOR_MSTR_DOC_LOC_30_Edit()
        {

            try
            {

                W_LOC_NBR.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_30");
                Internal_CHECK_LOCATION();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_PASS_Click(object sender, System.EventArgs e)
        {

            try
            {

                Accept(ref fldW_PASSWORD);
                if (QDesign.NULL(W_PASSWORD.Value) == QDesign.NULL("RMAPR"))
                {
                    //Accept(ref fldF020_DOCTOR_MSTR_DOC_NX_AVAIL_BATCH);
                    //Display(ref fldF020_DOCTOR_MSTR_DOC_NX_AVAIL_BATCH);
                    //Accept(ref fldF020_DOCTOR_MSTR_DOC_NX_AVAIL_BATCH_2);
                    //Display(ref fldF020_DOCTOR_MSTR_DOC_NX_AVAIL_BATCH_2);
                    //Accept(ref fldF020_DOCTOR_MSTR_DOC_NX_AVAIL_BATCH_3);
                    //Display(ref fldF020_DOCTOR_MSTR_DOC_NX_AVAIL_BATCH_3);
                    //Accept(ref fldF020_DOCTOR_MSTR_DOC_NX_AVAIL_BATCH_4);
                    //Display(ref fldF020_DOCTOR_MSTR_DOC_NX_AVAIL_BATCH_4);
                    //Accept(ref fldF020_DOCTOR_MSTR_DOC_NX_AVAIL_BATCH_5);
                    //Display(ref fldF020_DOCTOR_MSTR_DOC_NX_AVAIL_BATCH_5);
                    //Accept(ref fldF020_DOCTOR_MSTR_DOC_NX_AVAIL_BATCH_6);
                    //Display(ref fldF020_DOCTOR_MSTR_DOC_NX_AVAIL_BATCH_6);
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



        private void dsrDesigner_ALT_Click(object sender, System.EventArgs e)
        {

            try
            {

                X_DOC_NBR.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR");
                X_DOC_DEPT.Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT");
                object[] arrRunscreen = { X_DOC_NBR, X_DOC_DEPT };
                RunScreen(new Billing_M021(), RunScreenModes.Null, ref arrRunscreen);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_02_Click(object sender, System.EventArgs e)
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



        private void dsrDesigner_03_Click(object sender, System.EventArgs e)
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



        private void dsrDesigner_04_Click(object sender, System.EventArgs e)
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



        private void dsrDesigner_05_Click(object sender, System.EventArgs e)
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



        private void dsrDesigner_06_Click(object sender, System.EventArgs e)
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



        private void dsrDesigner_07_Click(object sender, System.EventArgs e)
        {

            try
            {

                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_1);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_1_S1);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_1_S2);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_1_S3);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_2);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_2_S1);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_2_S2);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_2_S3);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_3);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_3_S1);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_3_S2);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_3_S3);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_4);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_4_S1);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_4_S2);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_4_S3);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_5);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_5_S1);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_5_S2);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_5_S3);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_6);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_6_S1);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_6_S2);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_6_S3);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_7);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_7_S1);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_7_S2);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_7_S3);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_8);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_8_S1);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_8_S2);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_8_S3);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_9);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_9_S1);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_9_S2);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_9_S3);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_10);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_10_S1);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_10_S2);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_10_S3);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_11);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_11_S1);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_11_S2);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_11_S3);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_12);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_12_S1);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_12_S2);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_12_S3);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_13);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_13_S1);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_13_S2);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_13_S3);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_14);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_14_S1);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_14_S2);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_14_S3);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_15);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_15_S1);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_15_S2);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_15_S3);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_16);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_16_S1);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_16_S2);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_16_S3);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_17);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_17_S1);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_17_S2);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_17_S3);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_18);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_18_S1);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_18_S2);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_18_S3);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_19);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_19_S1);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_19_S2);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_19_S3);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_20);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_20_S1);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_20_S2);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_20_S3);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_21);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_21_S1);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_21_S2);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_21_S3);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_22);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_22_S1);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_22_S2);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_22_S3);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_23);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_23_S1);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_23_S2);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_23_S3);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_24);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_24_S1);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_24_S2);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_24_S3);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_25);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_25_S1);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_25_S2);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_25_S3);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_26);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_26_S1);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_26_S2);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_26_S3);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_27);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_27_S1);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_27_S2);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_27_S3);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_28);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_28_S1);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_28_S2);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_28_S3);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_29);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_29_S1);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_29_S2);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_29_S3);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_30);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_30_S1);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_30_S2);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_30_S3);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_08_Click(object sender, System.EventArgs e)
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



        private void dsrDesigner_LIN8_Click(object sender, System.EventArgs e)
        {

            try
            {

                //Accept(ref fldF020_DOCTOR_MSTR_DOC_CLINIC_NBR_2);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_CLINIC_NBR_3);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_CLINIC_NBR_4);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_CLINIC_NBR_5);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_CLINIC_NBR_6);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_LIN2_Click(object sender, System.EventArgs e)
        {

            try
            {

                Accept(ref fldF020_DOCTOR_MSTR_DOC_NAME);
                Accept(ref fldF020_DOCTOR_MSTR_DOC_INITS);
                Accept(ref fldF020_DOCTOR_MSTR_DOC_OHIP_NBR);
                Accept(ref fldF020_DOCTOR_MSTR_DOC_SIN_NBR);
                Accept(ref fldF020_DOCTOR_MSTR_DOC_SUB_SPECIALTY);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_LIN3_Click(object sender, System.EventArgs e)
        {

            try
            {

                Accept(ref fldF020_DOCTOR_MSTR_DOC_DEPT);
                // --> GET F070_DEPT_MSTR <--

                fleF070_DEPT_MSTR.GetData(GetDataOptions.IsOptional);
                // --> End GET F070_DEPT_MSTR <--
                if (!AccessOk)
                {
                    ErrorMessage(QDesign.NULL("DEPT NOT DEFINED\a"));
                    // TODO: May need to fix manually
                }
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_CLINIC_NBR);
                Accept(ref fldF020_DOCTOR_MSTR_DOC_FULL_PART_IND);
                Accept(ref fldF020_DOCTOR_MSTR_DOC_AFP_PAYM_GROUP);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_LIN4_Click(object sender, System.EventArgs e)
        {

            try
            {

                Accept(ref fldF020_DOCTOR_MSTR_DOC_ADDR_HOME_1);
                Accept(ref fldF020_DOCTOR_MSTR_DOC_ADDR_HOME_2);
                Accept(ref fldF020_DOCTOR_MSTR_DOC_ADDR_HOME_3);
                Accept(ref fldF020_DOCTOR_MSTR_DOC_ADDR_HOME_PC);
                Accept(ref fldF020_DOCTOR_MSTR_DOC_ADDR_OFFICE_1);
                Accept(ref fldF020_DOCTOR_MSTR_DOC_ADDR_OFFICE_2);
                Accept(ref fldF020_DOCTOR_MSTR_DOC_ADDR_OFFICE_3);
                Accept(ref fldF020_DOCTOR_MSTR_DOC_ADDR_OFFICE_PC);
                Accept(ref fldF020_DOCTOR_MSTR_DOC_BANK_NBR);
                if (QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_BANK_NBR")) != 0)
                {
                    Accept(ref fldF020_DOCTOR_MSTR_DOC_BANK_BRANCH);
                    Accept(ref fldF020_DOCTOR_MSTR_DOC_BANK_ACCT);
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



        private void dsrDesigner_LIN5_Click(object sender, System.EventArgs e)
        {

            try
            {

                Accept(ref fldF020_DOCTOR_MSTR_DOC_DATE_FAC_START);
                Accept(ref fldF020_DOCTOR_MSTR_DOC_DATE_FAC_TERM);
                if (QDesign.NULL(T_DOC_DATE_FAC_TERM.Value) == 0) 
                {
                    // --> GET F021_AVAIL_DOCTOR_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF021_AVAIL_DOCTOR_MSTR.ElementOwner("DOC_NO")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")));

                    fleF021_AVAIL_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F021_AVAIL_DOCTOR_MSTR <--
                    if (AccessOk)
                    {
                        Warning("Doctor had been reactived-s/he will be deleted from Available Doctor Nbr file");
                        X_DOC_TERMINATED_FLAG.Value = "Y";
                    }
                }
                else
                {
                    X_DOC_TERMINATED_FLAG.Value = "N";
                }
                if (QDesign.NULL(T_DOC_DATE_FAC_TERM.Value) != 0)
                {
                    // --> GET F021_AVAIL_DOCTOR_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF021_AVAIL_DOCTOR_MSTR.ElementOwner("DOC_NO")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")));

                    fleF021_AVAIL_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F021_AVAIL_DOCTOR_MSTR <--
                    if (AccessOk)
                    {
                        fleF021_AVAIL_DOCTOR_MSTR.set_SetValue("DATE_AVAILABLE", T_DOC_DATE_FAC_TERM.Value);
                        fleF021_AVAIL_DOCTOR_MSTR.PutData();
                    }
                    else
                    {
                        fleF021_AVAIL_DOCTOR_MSTR.set_SetValue("DOC_NO", fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR"));
                        fleF021_AVAIL_DOCTOR_MSTR.set_SetValue("DATE_AVAILABLE", T_DOC_DATE_FAC_TERM.Value);
                        fleF021_AVAIL_DOCTOR_MSTR.PutData();
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



        private void dsrDesigner_LIN6_Click(object sender, System.EventArgs e)
        {

            try
            {

                Accept(ref fldF020_DOCTOR_MSTR_GROUP_REGULAR_SERVICE);
                Accept(ref fldF020_DOCTOR_MSTR_GROUP_OVER_SERVICED);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }

        private void DsrDesigner_LOCA_Click(object sender, EventArgs e)
        {
            try
            {
                object[] arrRunscreen = { fleF020_DOCTOR_MSTR };
                RunScreen(new Mp_M020_LOC(), RunScreenModes.Same, ref arrRunscreen);

            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }
        }

        private void DsrDesigner_100_Click(object sender, EventArgs e)
        {
            try
            {
                Display(ref fldF020C_DOC_CLINIC_NEXT_BATCH_NBR_DOC_CLINIC_NBR);
                Display(ref fldF020C_DOC_CLINIC_NEXT_BATCH_NBR_DOC_NX_AVAIL_BATCH);
                Accept(ref fldF020C_DOC_CLINIC_NEXT_BATCH_NBR_DOC_CLINIC_NBR_STATUS);

            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }
        }

        private void DtlF020C_DOC_CLINIC_NEXT_BATCH_NBR_EditClick(DataList source, GridButtonEventArgs GridButtonEventArgs)
        {
            try
            {
                DsrDesigner_100_Click(null, null);

            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }
        }

        private void dsrDesigner_TRAN_Click(object sender, System.EventArgs e)
        {

            try
            {

                COMLINE.Value = "$cmd/f020_info_export.com >> f020_info_export.log";
                m_blnCommandOK = RunCommand(COMLINE.Value);
                // TODO: Check source code.  Manual process may be required.
                Information(QDesign.NULL("Basic doctor information has now been TRANSERRED to Payroll`A` system"));
                // TODO: May need to fix manually


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_EXP_Click(object sender, System.EventArgs e)
        {

            try
            {

                if (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NAME")) == QDesign.NULL(" "))
                {
                    X_DOC_NAME.Value = "|";
                }
                else
                {
                    X_DOC_NAME.Value = QDesign.RTrim(QDesign.LeftJustify(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NAME")));
                }
                //Parent:DOC_INITS
                if (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT3")) == QDesign.NULL(" "))
                {
                    X_DOC_INITS.Value = "|";
                }
                else
                {
                    X_DOC_INITS.Value = QDesign.RTrim(QDesign.LeftJustify(fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT3")));
                    //Parent:DOC_INITS
                }
                if (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_SUB_SPECIALTY")) == QDesign.NULL(" "))
                {
                    X_DOC_SUB_SPECIALTY.Value = "|";
                }
                else
                {
                    X_DOC_SUB_SPECIALTY.Value = QDesign.RTrim(QDesign.LeftJustify(fleF020_DOCTOR_MSTR.GetStringValue("DOC_SUB_SPECIALTY")));
                }
                if (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_FULL_PART_IND")) == QDesign.NULL(" "))
                {
                    X_DOC_FULL_PART_IND.Value = "|";
                }
                else
                {
                    X_DOC_FULL_PART_IND.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_FULL_PART_IND");
                }
                if (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_1")) == QDesign.NULL(" "))
                {
                    X_DOC_ADDR_HOME_1.Value = "|";
                }
                else
                {
                    X_DOC_ADDR_HOME_1.Value = QDesign.RTrim(QDesign.LeftJustify(fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_1")));
                }
                if (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_2")) == QDesign.NULL(" "))
                {
                    X_DOC_ADDR_HOME_2.Value = "|";
                }
                else
                {
                    X_DOC_ADDR_HOME_2.Value = QDesign.RTrim(QDesign.LeftJustify(fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_2")));
                }
                if (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_3")) == QDesign.NULL(" "))
                {
                    X_DOC_ADDR_HOME_3.Value = "|";
                }
                else
                {
                    X_DOC_ADDR_HOME_3.Value = QDesign.RTrim(QDesign.LeftJustify(fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_3")));
                }
                //Parent:DOC_ADDR_HOME_PC
                if (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_PC1") + QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_HOME_PC2"), 1) + fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_PC3") + QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_HOME_PC4"), 1) + fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_PC5") + QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_HOME_PC6"), 1)) == QDesign.NULL(" "))
                {
                    X_DOC_ADDR_HOME_PC.Value = "|";
                }
                else
                {
                    X_DOC_ADDR_HOME_PC.Value = QDesign.RTrim(QDesign.LeftJustify(fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_PC1") + QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_HOME_PC2"), 1) + fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_PC3") + QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_HOME_PC4"), 1) + fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_PC5") + QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_HOME_PC6"), 1)));
                    //Parent:DOC_ADDR_HOME_PC
                }
                if (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_1")) == QDesign.NULL(" "))
                {
                    X_DOC_ADDR_OFFICE_1.Value = "|";
                }
                else
                {
                    X_DOC_ADDR_OFFICE_1.Value = QDesign.RTrim(QDesign.LeftJustify(fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_1")));
                }
                if (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_2")) == QDesign.NULL(" "))
                {
                    X_DOC_ADDR_OFFICE_2.Value = "|";
                }
                else
                {
                    X_DOC_ADDR_OFFICE_2.Value = QDesign.RTrim(QDesign.LeftJustify(fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_2")));
                }
                if (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_3")) == QDesign.NULL(" "))
                {
                    X_DOC_ADDR_OFFICE_3.Value = "|";
                }
                else
                {
                    X_DOC_ADDR_OFFICE_3.Value = QDesign.RTrim(QDesign.LeftJustify(fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_3")));
                }
                //Parent:DOC_ADDR_OFFICE_PC
                if (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_PC1") + QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_OFFICE_PC2"), 1) + fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_PC3") + QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_OFFICE_PC4"), 1) + fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_PC5") + QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_OFFICE_PC6"), 1)) == QDesign.NULL(" "))
                {
                    X_DOC_ADDR_OFFICE_PC.Value = "|";
                }
                else
                {
                    X_DOC_ADDR_OFFICE_PC.Value = QDesign.RTrim(QDesign.LeftJustify(fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_PC1") + QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_OFFICE_PC2"), 1) + fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_PC3") + QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_OFFICE_PC4"), 1) + fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_PC5") + QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_OFFICE_PC6"), 1)));
                    //Parent:DOC_ADDR_OFFICE_PC
                }
                if (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_BANK_ACCT")) == QDesign.NULL(" "))
                {
                    X_DOC_BANK_ACCT.Value = "|";
                }
                else
                {
                    X_DOC_BANK_ACCT.Value = QDesign.RTrim(QDesign.LeftJustify(fleF020_DOCTOR_MSTR.GetStringValue("DOC_BANK_ACCT")));
                }

                object[] arrPS = { QDesign.RTrim(QDesign.LeftJustify(UserID)) , "f020" ,  fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR") ,
                    "'" + QDesign.RTrim(QDesign.LeftJustify(X_DOC_NAME.Value)) + "'" ,
                    "'" + QDesign.RTrim(QDesign.LeftJustify(X_DOC_INITS.Value)) + "'" ,
                    QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR"), 6) ,
                    QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SIN_123"), 3) + QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SIN_456"), 3) + QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SIN_789"), 3) ,
                    "'" + QDesign.RTrim(QDesign.LeftJustify(X_DOC_SUB_SPECIALTY.Value)) + "'" ,
                    QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT"), 2) ,
                    "" ,
                    "'" + QDesign.RTrim(QDesign.LeftJustify(X_DOC_FULL_PART_IND.Value)) + "'" ,
                    "'" + QDesign.RTrim(QDesign.LeftJustify(X_DOC_ADDR_HOME_1.Value)) + "'" ,
                    "'" + QDesign.RTrim(QDesign.LeftJustify(X_DOC_ADDR_HOME_2.Value)) + "'" ,
                    "'" + QDesign.RTrim(QDesign.LeftJustify(X_DOC_ADDR_HOME_3.Value)) + "'" ,
                    "'" + QDesign.RTrim(X_DOC_ADDR_HOME_PC.Value) + "'" ,
                    "'" + QDesign.RTrim(QDesign.LeftJustify(X_DOC_ADDR_OFFICE_1.Value)) + "'" ,
                    "'" + QDesign.RTrim(QDesign.LeftJustify(X_DOC_ADDR_OFFICE_2.Value)) + "'" ,
                    "'" + QDesign.RTrim(QDesign.LeftJustify(X_DOC_ADDR_OFFICE_3.Value)) + "'"  ,
                    "'" + QDesign.RTrim(X_DOC_ADDR_OFFICE_PC.Value) + "'" ,
                    QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_BANK_NBR"), 4) ,
                    QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_BANK_BRANCH"), 5) ,
                    "'" + QDesign.RTrim(QDesign.LeftJustify(X_DOC_BANK_ACCT.Value)) + "'" ,
                    "'" + QDesign.ASCII(Convert.ToDecimal(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_START_YY").ToString().PadLeft(4, '0') + fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_START_MM").ToString().PadLeft(2, '0') + fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_START_DD").ToString().PadLeft(2, '0')), 8) + "'" ,
                    "'" + QDesign.ASCII(Convert.ToDecimal(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_YY").ToString().PadLeft(4, '0') + fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_MM").ToString().PadLeft(2, '0') + fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_DD").ToString().PadLeft(2, '0')), 8) + "'" };
                string ps = System.Configuration.ConfigurationManager.AppSettings["JobScriptPath"] + @"batch_copy_bank_info_out.ps1";
                string psServer = System.Configuration.ConfigurationManager.AppSettings["psServer"].ToString();
                PowerShellEngine pse = new PowerShellEngine();
                pse.ExecuteScriptFile(ps, arrPS, psServer);
                pse.Dispose();
                // TODO: Check source code.  Manual process may be required.
                Information(QDesign.NULL("Payroll information has now been EXPORTED into Transfer Area"));
                // TODO: May need to fix manually


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_IMP_Click(object sender, System.EventArgs e)
        {

            try
            {

                if (!File.Exists(ConfigurationManager.AppSettings["FlatFilePath"].Replace("UserID", Environment.UserName) + "\\temp\\transfer_area\\rmabill\\transfer.dat"))
                {
                    ErrorMessage("Can`t find the transfer file - Re-EXPort!");
                }

                X_REC_COUNT.Value = 0;
                var sr = new StreamReader(ConfigurationManager.AppSettings["FlatFilePath"].Replace("UserID", Environment.UserName) + "\\temp\\transfer_area\\rmabill\\transfer.dat");
                var record = sr.ReadLine();
                while (record != null)
                {
                    if (record.StartsWith("'"))
                        record = record.Substring(1);
                    if (record.EndsWith("'"))
                        record = record.Substring(0, record.Length - 1);
                    X_REC_COUNT.Value = X_REC_COUNT.Value + 1;
                    if (QDesign.NULL(X_REC_COUNT.Value) == 2)
                    {
                        if (QDesign.NULL(record) != QDesign.NULL("f020"))
                        {
                            ErrorMessage("\aThe transfer file doesn`t contain doctor(f020) info - re-EXPort!");
                        }
                    }
                    if (QDesign.NULL(X_REC_COUNT.Value) == 3)
                    {
                        X_DOC_NBR.Value = record;
                        if (QDesign.NULL(X_DOC_NBR.Value) != QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")))
                        {
                            ErrorMessage("\aThe data in the import transfer area DOESN`T BELONG to the Current doctor!");
                        }
                    }
                    if (QDesign.NULL(X_REC_COUNT.Value) == 4)
                    {
                        X_DOC_NAME.Value = QDesign.RTrim(QDesign.LeftJustify(record));
                        if (QDesign.NULL(X_DOC_NAME.Value) == QDesign.NULL("|"))
                        {
                            X_DOC_NAME.Value = " ";
                        }
                    }
                    if (QDesign.NULL(X_REC_COUNT.Value) == 5)
                    {
                        X_DOC_INITS.Value = QDesign.RTrim(QDesign.LeftJustify(record));
                        if (QDesign.NULL(X_DOC_INITS.Value) == QDesign.NULL("|"))
                        {
                            X_DOC_INITS.Value = " ";
                        }
                    }
                    if (QDesign.NULL(X_REC_COUNT.Value) == 6)
                    {
                        X_DOC_OHIP_NBR.Value = QDesign.NConvert(record);
                    }
                    if (QDesign.NULL(X_REC_COUNT.Value) == 7)
                    {
                        X_DOC_SIN_NBR.Value = QDesign.NConvert(record);
                    }
                    if (QDesign.NULL(X_REC_COUNT.Value) == 8)
                    {
                        X_DOC_SUB_SPECIALTY.Value = QDesign.RTrim(QDesign.LeftJustify(record));
                        if (QDesign.NULL(X_DOC_SUB_SPECIALTY.Value) == QDesign.NULL("|"))
                        {
                            X_DOC_SUB_SPECIALTY.Value = " ";
                        }
                    }
                    if (QDesign.NULL(X_REC_COUNT.Value) == 9)
                    {
                        X_DOC_DEPT.Value = QDesign.NConvert(record);
                    }
                    //if (QDesign.NULL(X_REC_COUNT.Value) == 10)
                    //{
                    //    X_DOC_CLINIC_NBR.Value = QDesign.NConvert(record);
                    //}
                    if (QDesign.NULL(X_REC_COUNT.Value) == 11)
                    {
                        X_DOC_FULL_PART_IND.Value = QDesign.RTrim(QDesign.LeftJustify(record));
                        if (QDesign.NULL(X_DOC_FULL_PART_IND.Value) == QDesign.NULL("|"))
                        {
                            X_DOC_FULL_PART_IND.Value = " ";
                        }
                    }
                    if (QDesign.NULL(X_REC_COUNT.Value) == 12)
                    {
                        X_DOC_ADDR_HOME_1.Value = QDesign.RTrim(QDesign.LeftJustify(record));
                        if (QDesign.NULL(X_DOC_ADDR_HOME_1.Value) == QDesign.NULL("|"))
                        {
                            X_DOC_ADDR_HOME_1.Value = " ";
                        }
                    }
                    if (QDesign.NULL(X_REC_COUNT.Value) == 13)
                    {
                        X_DOC_ADDR_HOME_2.Value = QDesign.RTrim(QDesign.LeftJustify(record));
                        if (QDesign.NULL(X_DOC_ADDR_HOME_2.Value) == QDesign.NULL("|"))
                        {
                            X_DOC_ADDR_HOME_2.Value = " ";
                        }
                    }
                    if (QDesign.NULL(X_REC_COUNT.Value) == 14)
                    {
                        X_DOC_ADDR_HOME_3.Value = QDesign.RTrim(QDesign.LeftJustify(record));
                        if (QDesign.NULL(X_DOC_ADDR_HOME_3.Value) == QDesign.NULL("|"))
                        {
                            X_DOC_ADDR_HOME_3.Value = " ";
                        }
                    }
                    if (QDesign.NULL(X_REC_COUNT.Value) == 15)
                    {
                        X_DOC_ADDR_HOME_PC.Value = QDesign.RTrim((record));
                        if (QDesign.NULL(X_DOC_ADDR_HOME_PC.Value) == QDesign.NULL("|"))
                        {
                            X_DOC_ADDR_HOME_PC.Value = " ";
                        }
                    }
                    if (QDesign.NULL(X_REC_COUNT.Value) == 16)
                    {
                        X_DOC_ADDR_OFFICE_1.Value = QDesign.RTrim(QDesign.LeftJustify(record));
                        if (QDesign.NULL(X_DOC_ADDR_OFFICE_1.Value) == QDesign.NULL("|"))
                        {
                            X_DOC_ADDR_OFFICE_1.Value = " ";
                        }
                    }
                    if (QDesign.NULL(X_REC_COUNT.Value) == 17)
                    {
                        X_DOC_ADDR_OFFICE_2.Value = QDesign.RTrim(QDesign.LeftJustify(record));
                        if (QDesign.NULL(X_DOC_ADDR_OFFICE_2.Value) == QDesign.NULL("|"))
                        {
                            X_DOC_ADDR_OFFICE_2.Value = " ";
                        }
                    }
                    if (QDesign.NULL(X_REC_COUNT.Value) == 18)
                    {
                        X_DOC_ADDR_OFFICE_3.Value = QDesign.RTrim(QDesign.LeftJustify(record));
                        if (QDesign.NULL(X_DOC_ADDR_OFFICE_3.Value) == QDesign.NULL("|"))
                        {
                            X_DOC_ADDR_OFFICE_3.Value = " ";
                        }
                    }
                    if (QDesign.NULL(X_REC_COUNT.Value) == 19)
                    {
                        X_DOC_ADDR_OFFICE_PC.Value = QDesign.RTrim((record));
                        if (QDesign.NULL(X_DOC_ADDR_OFFICE_PC.Value) == QDesign.NULL("|"))
                        {
                            X_DOC_ADDR_OFFICE_PC.Value = " ";
                        }
                    }
                    if (QDesign.NULL(X_REC_COUNT.Value) == 20)
                    {
                        X_DOC_BANK_NBR.Value = QDesign.NConvert(record);
                    }
                    if (QDesign.NULL(X_REC_COUNT.Value) == 21)
                    {
                        X_DOC_BANK_BRANCH.Value = QDesign.NConvert(record);
                    }
                    if (QDesign.NULL(X_REC_COUNT.Value) == 22)
                    {
                        X_DOC_BANK_ACCT.Value = QDesign.RTrim(QDesign.LeftJustify(record));
                        if (QDesign.NULL(X_DOC_BANK_ACCT.Value) == QDesign.NULL("|"))
                        {
                            X_DOC_BANK_ACCT.Value = " ";
                        }
                    }
                    if (QDesign.NULL(X_REC_COUNT.Value) == 23)
                    {
                        X_DOC_DATE_FAC_START.Value = QDesign.NConvert(record);
                    }
                    if (QDesign.NULL(X_REC_COUNT.Value) == 24)
                    {
                        X_DOC_DATE_FAC_TERM.Value = QDesign.NConvert(record);
                    }

                    record = sr.ReadLine();
                }
                // Close fleTRANSFER_FILE
                if (QDesign.NULL(X_REC_COUNT.Value) < 1)
                {
                    ErrorMessage("\aCan`t find the transfer file - Re-EXPort!");
                }
                fleF020_DOCTOR_MSTR.set_SetValue("DOC_NAME", X_DOC_NAME.Value);
                fleF020_DOCTOR_MSTR.set_SetValue("DOC_INIT1", (X_DOC_INITS.Value).PadRight(3).Substring(0, 1));
                //Parent:DOC_INITS
                fleF020_DOCTOR_MSTR.set_SetValue("DOC_INIT2", (X_DOC_INITS.Value).PadRight(3).Substring(1, 1));
                //Parent:DOC_INITS
                fleF020_DOCTOR_MSTR.set_SetValue("DOC_INIT3", (X_DOC_INITS.Value).PadRight(3).Substring(2, 1));
                //Parent:DOC_INITS

                fleF020_DOCTOR_MSTR.set_SetValue("DOC_SIN_123", (X_DOC_SIN_NBR.Value).ToString().PadRight(9, '0').Substring(0, 3));
                //Parent:DOC_SIN_NBR
                fleF020_DOCTOR_MSTR.set_SetValue("DOC_SIN_456", (X_DOC_SIN_NBR.Value).ToString().PadRight(9, '0').Substring(3, 3));
                //Parent:DOC_SIN_NBR
                fleF020_DOCTOR_MSTR.set_SetValue("DOC_SIN_789", (X_DOC_SIN_NBR.Value).ToString().PadRight(9, '0').Substring(6, 3));
                //Parent:DOC_SIN_NBR

                fleF020_DOCTOR_MSTR.set_SetValue("DOC_OHIP_NBR", X_DOC_OHIP_NBR.Value);
                fleF020_DOCTOR_MSTR.set_SetValue("DOC_SUB_SPECIALTY", X_DOC_SUB_SPECIALTY.Value);
                fleF020_DOCTOR_MSTR.set_SetValue("DOC_DEPT", X_DOC_DEPT.Value);
                //fleF020_DOCTOR_MSTR.set_SetValue("DOC_CLINIC_NBR", X_DOC_CLINIC_NBR.Value);
                fleF020_DOCTOR_MSTR.set_SetValue("DOC_FULL_PART_IND", X_DOC_FULL_PART_IND.Value);
                fleF020_DOCTOR_MSTR.set_SetValue("DOC_ADDR_HOME_1", X_DOC_ADDR_HOME_1.Value);
                fleF020_DOCTOR_MSTR.set_SetValue("DOC_ADDR_HOME_2", X_DOC_ADDR_HOME_2.Value);
                fleF020_DOCTOR_MSTR.set_SetValue("DOC_ADDR_HOME_3", X_DOC_ADDR_HOME_3.Value);

                fleF020_DOCTOR_MSTR.set_SetValue("DOC_ADDR_HOME_PC1", (X_DOC_ADDR_HOME_PC.Value).PadRight(6).Substring(0, 1));
                //Parent:DOC_ADDR_HOME_PC
                fleF020_DOCTOR_MSTR.set_SetValue("DOC_ADDR_HOME_PC2", (X_DOC_ADDR_HOME_PC.Value).PadRight(6).Substring(1, 1));
                //Parent:DOC_ADDR_HOME_PC
                fleF020_DOCTOR_MSTR.set_SetValue("DOC_ADDR_HOME_PC3", (X_DOC_ADDR_HOME_PC.Value).PadRight(6).Substring(2, 1));
                //Parent:DOC_ADDR_HOME_PC
                fleF020_DOCTOR_MSTR.set_SetValue("DOC_ADDR_HOME_PC4", (X_DOC_ADDR_HOME_PC.Value).PadRight(6).Substring(3, 1));
                //Parent:DOC_ADDR_HOME_PC
                fleF020_DOCTOR_MSTR.set_SetValue("DOC_ADDR_HOME_PC5", (X_DOC_ADDR_HOME_PC.Value).PadRight(6).Substring(4, 1));
                //Parent:DOC_ADDR_HOME_PC
                fleF020_DOCTOR_MSTR.set_SetValue("DOC_ADDR_HOME_PC6", (X_DOC_ADDR_HOME_PC.Value).PadRight(6).Substring(5, 1));
                //Parent:DOC_ADDR_HOME_PC
                fleF020_DOCTOR_MSTR.set_SetValue("DOC_ADDR_OFFICE_1", X_DOC_ADDR_OFFICE_1.Value);
                fleF020_DOCTOR_MSTR.set_SetValue("DOC_ADDR_OFFICE_2", X_DOC_ADDR_OFFICE_2.Value);
                fleF020_DOCTOR_MSTR.set_SetValue("DOC_ADDR_OFFICE_3", X_DOC_ADDR_OFFICE_3.Value);
                fleF020_DOCTOR_MSTR.set_SetValue("DOC_ADDR_OFFICE_PC1", (X_DOC_ADDR_OFFICE_PC.Value).PadRight(6).Substring(0, 1));
                //Parent:DOC_ADDR_OFFICE_PC
                fleF020_DOCTOR_MSTR.set_SetValue("DOC_ADDR_OFFICE_PC2", (X_DOC_ADDR_OFFICE_PC.Value).PadRight(6).Substring(1, 1));
                //Parent:DOC_ADDR_OFFICE_PC
                fleF020_DOCTOR_MSTR.set_SetValue("DOC_ADDR_OFFICE_PC3", (X_DOC_ADDR_OFFICE_PC.Value).PadRight(6).Substring(2, 1));
                //Parent:DOC_ADDR_OFFICE_PC
                fleF020_DOCTOR_MSTR.set_SetValue("DOC_ADDR_OFFICE_PC4", (X_DOC_ADDR_OFFICE_PC.Value).PadRight(6).Substring(3, 1));
                //Parent:DOC_ADDR_OFFICE_PC
                fleF020_DOCTOR_MSTR.set_SetValue("DOC_ADDR_OFFICE_PC5", (X_DOC_ADDR_OFFICE_PC.Value).PadRight(6).Substring(4, 1));
                //Parent:DOC_ADDR_OFFICE_PC
                fleF020_DOCTOR_MSTR.set_SetValue("DOC_ADDR_OFFICE_PC6", (X_DOC_ADDR_OFFICE_PC.Value).PadRight(6).Substring(5, 1));
                //Parent:DOC_ADDR_OFFICE_PC
                fleF020_DOCTOR_MSTR.set_SetValue("DOC_BANK_NBR", X_DOC_BANK_NBR.Value);
                fleF020_DOCTOR_MSTR.set_SetValue("DOC_BANK_BRANCH", X_DOC_BANK_BRANCH.Value);
                fleF020_DOCTOR_MSTR.set_SetValue("DOC_BANK_ACCT", X_DOC_BANK_ACCT.Value);
                fleF020_DOCTOR_MSTR.set_SetValue("DOC_DATE_FAC_START_YY", (X_DOC_DATE_FAC_START.Value).ToString().PadRight(8, '0').Substring(0, 4));
                //Parent:DOC_DATE_FAC_START
                fleF020_DOCTOR_MSTR.set_SetValue("DOC_DATE_FAC_START_MM", (X_DOC_DATE_FAC_START.Value).ToString().PadRight(8, '0').Substring(4, 2));
                //Parent:DOC_DATE_FAC_START
                fleF020_DOCTOR_MSTR.set_SetValue("DOC_DATE_FAC_START_DD", (X_DOC_DATE_FAC_START.Value).ToString().PadRight(8, '0').Substring(6, 2));
                //Parent:DOC_DATE_FAC_START
                fleF020_DOCTOR_MSTR.set_SetValue("DOC_DATE_FAC_TERM_YY", (X_DOC_DATE_FAC_TERM.Value).ToString().PadRight(8, '0').Substring(0, 4));
                //Parent:DOC_DATE_FAC_TERM
                fleF020_DOCTOR_MSTR.set_SetValue("DOC_DATE_FAC_TERM_MM", (X_DOC_DATE_FAC_TERM.Value).ToString().PadRight(8, '0').Substring(4, 2));
                //Parent:DOC_DATE_FAC_TERM
                fleF020_DOCTOR_MSTR.set_SetValue("DOC_DATE_FAC_TERM_DD", (X_DOC_DATE_FAC_TERM.Value).ToString().PadRight(8, '0').Substring(6, 2));
                //Parent:DOC_DATE_FAC_TERM
                m_blnCommandOK = RunCommand(COMLINE.Value);
                // TODO: Check source code.  Manual process may be required.
                Display(ref fldF020_DOCTOR_MSTR_DOC_NAME);
                Display(ref fldF020_DOCTOR_MSTR_DOC_INITS);
                Display(ref fldF020_DOCTOR_MSTR_DOC_SIN_NBR);
                Display(ref fldF020_DOCTOR_MSTR_DOC_OHIP_NBR);
                Display(ref fldF020_DOCTOR_MSTR_DOC_SUB_SPECIALTY);
                Display(ref fldF020_DOCTOR_MSTR_DOC_DEPT);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_CLINIC_NBR);
                Display(ref fldF020_DOCTOR_MSTR_DOC_FULL_PART_IND);
                Display(ref fldF020_DOCTOR_MSTR_DOC_BANK_NBR);
                Display(ref fldF020_DOCTOR_MSTR_DOC_BANK_BRANCH);
                Display(ref fldF020_DOCTOR_MSTR_DOC_BANK_ACCT);
                Display(ref fldF020_DOCTOR_MSTR_DOC_DATE_FAC_START);
                Display(ref fldF020_DOCTOR_MSTR_DOC_DATE_FAC_TERM);
                Information(QDesign.NULL("Payroll information has now been IMPORTED from the Transfer Area"));
                // TODO: May need to fix manually


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_OPT_Click(object sender, System.EventArgs e)
        {

            try
            {

                X_DOC_NBR.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR");
                object[] arrRunscreen = { X_DOC_NBR };
                RunScreen(new Billing_M920(), RunScreenModes.Find, ref arrRunscreen);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }

        //#CORE_BEGIN_INCLUDE: SAVEF020AUDIT_MP_M020"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/26/2017 10:18:32 AM

        private bool Internal_SAVEF020AUDIT()
        {


            try
            {

                A_DOC_NBR.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR");
                A_DOC_DEPT.Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT");
                A_DOC_OHIP_NBR.Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR");
                A_DOC_SIN_NBR.Value = Convert.ToDecimal(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SIN_123").ToString().PadLeft(3, '0') + fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SIN_456").ToString().PadLeft(3, '0') + fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SIN_789").ToString().PadLeft(3, '0'));

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
                A_DOC_EP_DATE_DEPOSIT.Value = fleF020_DOCTOR_MSTR.GetNumericDateValue("DOC_EP_DATE_DEPOSIT");
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
                A_DOC_IND_HOLDBACK_ACTIVE.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_IND_HOLDBACK_ACTIVE");
                A_GROUP_REGULAR_SERVICE.Value = fleF020_DOCTOR_MSTR.GetStringValue("GROUP_REGULAR_SERVICE");
                A_GROUP_OVER_SERVICED.Value = fleF020_DOCTOR_MSTR.GetStringValue("GROUP_OVER_SERVICED");
                //A_DOC_SPECIALTIES.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_1_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_1_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_1_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_2_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_2_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_2_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_3_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_3_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_3_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_4_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_4_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_4_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_5_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_5_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_5_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_6_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_6_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_6_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_7_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_7_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_7_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_8_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_8_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_8_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_9_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_9_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_9_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_10_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_10_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_10_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_11_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_11_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_11_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_12_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_12_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_12_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_13_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_13_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_13_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_14_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_14_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_14_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_15_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_15_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_15_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_16_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_16_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_16_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_17_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_17_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_17_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_18_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_18_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_18_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_19_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_19_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_19_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_20_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_20_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_20_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_21_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_21_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_21_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_22_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_22_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_22_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_23_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_23_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_23_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_24_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_24_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_24_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_25_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_25_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_25_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_26_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_26_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_26_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_27_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_27_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_27_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_28_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_28_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_28_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_29_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_29_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_29_S3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_30_S1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_30_S2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_30_S3");
                //Parent:DOC_SPECIALTIES

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

        //#CORE_END_INCLUDE: SAVEF020AUDIT_MP_M020"


        //#CORE_BEGIN_INCLUDE: CREATEF020AUDIT_MP_M020"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/26/2017 10:18:32 AM

        private bool Internal_CREATEF020AUDIT_BEFORE()
        {


            try
            {

                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_NBR", A_DOC_NBR.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_DEPT", A_DOC_DEPT.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_OHIP_NBR", A_DOC_OHIP_NBR.Value);
                //fleF020_DOCTOR_AUDIT.set_SetValue("DOC_SIN_NBR", A_DOC_SIN_NBR.Value);
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
                //fleF020_DOCTOR_AUDIT.set_SetValue("DOC_CLINIC_NBR_2", A_DOC_CLINIC_NBR_2.Value);
                //fleF020_DOCTOR_AUDIT.set_SetValue("DOC_CLINIC_NBR_3", A_DOC_CLINIC_NBR_3.Value);
                //fleF020_DOCTOR_AUDIT.set_SetValue("DOC_CLINIC_NBR_4", A_DOC_CLINIC_NBR_4.Value);
                //fleF020_DOCTOR_AUDIT.set_SetValue("DOC_CLINIC_NBR_5", A_DOC_CLINIC_NBR_5.Value);
                //fleF020_DOCTOR_AUDIT.set_SetValue("DOC_CLINIC_NBR_6", A_DOC_CLINIC_NBR_6.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_SPEC_CD_2", A_DOC_SPEC_CD_2.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_SPEC_CD_3", A_DOC_SPEC_CD_3.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_YTDINC_G", A_DOC_YTDINC_G.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_LOCATIONS", A_DOC_LOCATIONS.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_RMA_EXPENSE_PERCENT_MISC", A_DOC_RMA_EXPENSE_PERCENT_MISC.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_AFP_PAYM_GROUP", A_DOC_AFP_PAYM_GROUP.Value);
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_IND_PAYS_GST", A_DOC_IND_PAYS_GST.Value);
                //fleF020_DOCTOR_AUDIT.set_SetValue("DOC_NX_AVAIL_BATCH", A_DOC_NX_AVAIL_BATCH.Value);
                //fleF020_DOCTOR_AUDIT.set_SetValue("DOC_NX_AVAIL_BATCH_2", A_DOC_NX_AVAIL_BATCH_2.Value);
                //fleF020_DOCTOR_AUDIT.set_SetValue("DOC_NX_AVAIL_BATCH_3", A_DOC_NX_AVAIL_BATCH_3.Value);
                //fleF020_DOCTOR_AUDIT.set_SetValue("DOC_NX_AVAIL_BATCH_4", A_DOC_NX_AVAIL_BATCH_4.Value);
                //fleF020_DOCTOR_AUDIT.set_SetValue("DOC_NX_AVAIL_BATCH_5", A_DOC_NX_AVAIL_BATCH_5.Value);
                //fleF020_DOCTOR_AUDIT.set_SetValue("DOC_NX_AVAIL_BATCH_6", A_DOC_NX_AVAIL_BATCH_6.Value);
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
                //fleF020_DOCTOR_AUDIT.set_SetValue("DOC_SIN_NBR", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SIN_NBR"));
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

                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_DATE_FAC_START", Convert.ToDecimal(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_START_YY").ToString().PadLeft(4, '0') + fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_START_MM").ToString().PadLeft(2, '0') + fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_START_DD").ToString().PadLeft(2, '0')));
                fleF020_DOCTOR_AUDIT.set_SetValue("DOC_DATE_FAC_TERM", Convert.ToDecimal(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_YY").ToString().PadLeft(4, '0') + fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_MM").ToString().PadLeft(2, '0') + fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_DD").ToString().PadLeft(2, '0')));


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
                //fleF020_DOCTOR_AUDIT.set_SetValue("DOC_NX_AVAIL_BATCH", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH"));
                //fleF020_DOCTOR_AUDIT.set_SetValue("DOC_NX_AVAIL_BATCH_2", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_2"));
                //fleF020_DOCTOR_AUDIT.set_SetValue("DOC_NX_AVAIL_BATCH_3", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_3"));
                //fleF020_DOCTOR_AUDIT.set_SetValue("DOC_NX_AVAIL_BATCH_4", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_4"));
                //fleF020_DOCTOR_AUDIT.set_SetValue("DOC_NX_AVAIL_BATCH_5", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_5"));
                //fleF020_DOCTOR_AUDIT.set_SetValue("DOC_NX_AVAIL_BATCH_6", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_6"));
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

        //#CORE_END_INCLUDE: CREATEF020AUDIT_MP_M020"



        protected override bool PreUpdate()
        {


            try
            {

                if (fleF020_DOCTOR_MSTR.NewRecord)
                {
                    Internal_CREATEF020AUDIT_AFTER();
                    fleF020_DOCTOR_AUDIT.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));
                    fleF020_DOCTOR_AUDIT.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);
                    fleF020_DOCTOR_AUDIT.set_SetValue("LAST_MOD_USER_ID", QDesign.RTrim(UserID) + "-m020-A");
                    fleF020_DOCTOR_AUDIT.set_SetValue("LAST_MOD_FLAG", "A");
                    fleF020_DOCTOR_AUDIT.PutData();
                }
                if (fleF020_DOCTOR_MSTR.AlteredRecord)
                {
                    Internal_CREATEF020AUDIT_BEFORE();
                    fleF020_DOCTOR_AUDIT.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));
                    fleF020_DOCTOR_AUDIT.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);
                    fleF020_DOCTOR_AUDIT.set_SetValue("LAST_MOD_USER_ID", QDesign.RTrim(UserID) + "-m020-1");
                    fleF020_DOCTOR_AUDIT.set_SetValue("LAST_MOD_FLAG", "C");
                    fleF020_DOCTOR_AUDIT.PutData(true);
                    Internal_CREATEF020AUDIT_AFTER();
                    fleF020_DOCTOR_AUDIT.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));
                    fleF020_DOCTOR_AUDIT.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);
                    fleF020_DOCTOR_AUDIT.set_SetValue("LAST_MOD_USER_ID", QDesign.RTrim(UserID) + "-m020-2");
                    fleF020_DOCTOR_AUDIT.set_SetValue("LAST_MOD_FLAG", "C");
                    fleF020_DOCTOR_AUDIT.PutData(true);
                }
                if (QDesign.NULL(X_DOC_TERMINATED_FLAG.Value) == QDesign.NULL("Y"))
                {
                    fleF021_AVAIL_DOCTOR_MSTR.DeletedRecord = true;
                    fleF021_AVAIL_DOCTOR_MSTR.PutData();
                }
                if (QDesign.NULL(X_DOC_DEPT_FLAG.Value) == QDesign.NULL("Y"))
                {
                    if (QDesign.NULL(UserID) != QDesign.NULL("yas"))
                    {
                        ErrorMessage("\aOnly System Administrator can change doctor department");
                    }
                    else
                    {
                        Accept(ref fldW_START_DATE);
                        COMLINE.Value = "$cmd/batch_update_f050_f051_f060 " + fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR") + " " + QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT"), 2) + " " + QDesign.ASCII(W_START_DATE.Value, 8);
                        m_blnCommandOK = RunCommand(COMLINE.Value);
                        // TODO: Check source code.  Manual process may be required.
                        Information(QDesign.NULL("F050/F051 WILL BE UPDATED IN BATCH AT NIGHT"));
                        // TODO: May need to fix manually
                    }
                }
                if (fleF020_DOCTOR_MSTR.DeletedRecord)
                {
                    if (QDesign.NULL(T_DOC_DATE_FAC_TERM.Value) == 0)
                    {
                        ErrorMessage("FACULTY TERMINATE DATE CAN`T BE ZERO");
                    }
                    // --> GET F002_CLAIMS_MSTR_M020 <--

                    fleF002_CLAIMS_MSTR_M020.GetData(GetDataOptions.IsOptional);
                    // --> End GET F002_CLAIMS_MSTR_M020 <--
                    if (AccessOk)
                    {
                        ErrorMessage("This doctor has claims, can`t be deleted");
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


        protected override bool PostFind()
        {


            try
            {

                Internal_SAVEF020AUDIT();
                //APP_VERSION.Value = GetSystemVal("RMABILL_VERSION");
                if (QDesign.NULL(APP_VERSION.Value) == QDesign.NULL(VERSION_LIVE.Value))
                {
                    APP_MSG.Value = " ";
                }
                else
                {
                    APP_MSG.Value = QDesign.RightJustify(QDesign.RTrim(QDesign.LeftJustify(APP_VERSION.Value)) + " VERSION!");
                }
                Display(ref fldAPP_MSG);

                T_DOC_INITS.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT3");
                T_DOC_SIN_NBR.Value = Convert.ToDecimal(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SIN_123").ToString().PadLeft(3, '0') + fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SIN_456").ToString().PadLeft(3, '0') + fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SIN_789").ToString().PadLeft(3, '0'));
                T_DOC_DATE_FAC_START.Value = Convert.ToDecimal(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_START_YY").ToString().PadLeft(4, '0') + fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_START_MM").ToString().PadLeft(2, '0') + fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_START_DD").ToString().PadLeft(2, '0'));
                T_DOC_DATE_FAC_TERM.Value = Convert.ToDecimal(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_YY").ToString().PadLeft(4, '0') + fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_MM").ToString().PadLeft(2, '0') + fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_DD").ToString().PadLeft(2, '0'));
                T_DOC_ADDR_HOME_PC.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_PC1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_PC2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_PC3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_PC4") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_PC5") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_PC6");
                T_DOC_ADDR_OFFICE_PC.Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_PC1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_PC2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_PC3") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_PC4") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_PC5") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_PC6");
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
                        m_strWhere = new StringBuilder(GetWhereCondition(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR"), (fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")), ref blnAddWhere));
                        fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
                        break;
                    case 2:
                        m_strWhere = new StringBuilder(GetWhereCondition(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NAME"), (fleF020_DOCTOR_MSTR.GetStringValue("DOC_NAME")), ref blnAddWhere));
                        fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
                        break;
                    case 3:
                        m_strWhere = new StringBuilder(GetWhereCondition(fleF020_DOCTOR_MSTR.ElementOwner("DOC_OHIP_NBR"), (fleF020_DOCTOR_MSTR.GetStringValue("DOC_OHIP_NBR")), ref blnAddWhere));
                        fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
                        break;
                    case 0:
                        fleF020_DOCTOR_MSTR.GetData(GetDataOptions.Sequential | GetDataOptions.CreateSubSelect);
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


        protected override bool DetailFind()
        {


            try
            {

                while (fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.ForMissing())
                {
                    fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetData(GetDataOptions.IsOptional);
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

                if (m_intPath == 0)
                {
                    RequestPrompt(ref fldF020_DOCTOR_MSTR_DOC_NBR);
                    if (m_blnPromptOK)
                    {
                        m_intPath = 1;
                    }
                }
                if (m_intPath == 0)
                {
                    RequestPrompt(ref fldF020_DOCTOR_MSTR_DOC_NAME);
                    if (m_blnPromptOK)
                    {
                        m_intPath = 2;
                    }
                }
                if (m_intPath == 0)
                {
                    RequestPrompt(ref fldF020_DOCTOR_MSTR_DOC_OHIP_NBR);
                    if (m_blnPromptOK)
                    {
                        m_intPath = 3;
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
                Page.PageTitle = "M020 DOCTOR MASTER MAINTENANCE";



            }
            catch (CustomApplicationException ex)
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/26/2017 10:18:33 AM
        //#-----------------------------------------
        protected override bool Entry()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/26/2017 10:18:33 AM
                Accept(ref fldF020_DOCTOR_MSTR_DOC_NBR);
                Display(ref fldAPP_MSG);
                Accept(ref fldF020_DOCTOR_MSTR_DOC_NAME);
                Edit(ref fldF020_DOCTOR_MSTR_DOC_NAME_SOUNDEX);
                Accept(ref fldF020_DOCTOR_MSTR_DOC_INITS);
                Accept(ref fldF020_DOCTOR_MSTR_DOC_OHIP_NBR);
                Accept(ref fldF020_DOCTOR_MSTR_DOC_SIN_NBR);
                Accept(ref fldF020_DOCTOR_MSTR_DOC_SUB_SPECIALTY);
                Accept(ref fldF020_DOCTOR_MSTR_DOC_DEPT);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_CLINIC_NBR);
                Accept(ref fldF020_DOCTOR_MSTR_DOC_FULL_PART_IND);
                Accept(ref fldF020_DOCTOR_MSTR_DOC_AFP_PAYM_GROUP);
                Accept(ref fldF020_DOCTOR_MSTR_DOC_ADDR_HOME_1);
                Accept(ref fldF020_DOCTOR_MSTR_DOC_ADDR_HOME_2);
                Accept(ref fldF020_DOCTOR_MSTR_DOC_ADDR_HOME_3);
                Accept(ref fldF020_DOCTOR_MSTR_DOC_ADDR_HOME_PC);
                Accept(ref fldF020_DOCTOR_MSTR_DOC_ADDR_OFFICE_1);
                Accept(ref fldF020_DOCTOR_MSTR_DOC_ADDR_OFFICE_2);
                Accept(ref fldF020_DOCTOR_MSTR_DOC_ADDR_OFFICE_3);
                Accept(ref fldF020_DOCTOR_MSTR_DOC_ADDR_OFFICE_PC);
                Accept(ref fldF020_DOCTOR_MSTR_DOC_BANK_NBR);
                if (fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_BANK_NBR") != 0)
                {
                    Accept(ref fldF020_DOCTOR_MSTR_DOC_BANK_BRANCH);
                }
                else
                {
                    Display(ref fldF020_DOCTOR_MSTR_DOC_BANK_BRANCH);
                }
                if (fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_BANK_NBR") != 0)
                {
                    Accept(ref fldF020_DOCTOR_MSTR_DOC_BANK_ACCT);
                }
                else
                {
                    Display(ref fldF020_DOCTOR_MSTR_DOC_BANK_ACCT);
                }
                Accept(ref fldF020_DOCTOR_MSTR_DOC_DATE_FAC_START);
                Accept(ref fldF020_DOCTOR_MSTR_DOC_DATE_FAC_TERM);
                Accept(ref fldF020_DOCTOR_MSTR_GROUP_REGULAR_SERVICE);
                Accept(ref fldF020_DOCTOR_MSTR_GROUP_OVER_SERVICED);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_1);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_1_S1);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_1_S2);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_1_S3);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_2);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_2_S1);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_2_S2);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_2_S3);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_3);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_3_S1);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_3_S2);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_3_S3);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_4);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_4_S1);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_4_S2);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_4_S3);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_5);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_5_S1);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_5_S2);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_5_S3);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_6);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_6_S1);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_6_S2);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_6_S3);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_7);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_7_S1);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_7_S2);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_7_S3);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_8);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_8_S1);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_8_S2);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_8_S3);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_9);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_9_S1);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_9_S2);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_9_S3);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_10);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_10_S1);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_10_S2);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_10_S3);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_11);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_11_S1);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_11_S2);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_11_S3);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_12);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_12_S1);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_12_S2);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_12_S3);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_13);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_13_S1);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_13_S2);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_13_S3);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_14);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_14_S1);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_14_S2);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_14_S3);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_15);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_15_S1);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_15_S2);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_15_S3);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_16);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_16_S1);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_16_S2);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_16_S3);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_17);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_17_S1);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_17_S2);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_17_S3);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_18);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_18_S1);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_18_S2);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_18_S3);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_19);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_19_S1);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_19_S2);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_19_S3);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_20);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_20_S1);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_20_S2);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_20_S3);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_21);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_21_S1);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_21_S2);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_21_S3);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_22);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_22_S1);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_22_S2);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_22_S3);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_23);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_23_S1);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_23_S2);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_23_S3);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_24);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_24_S1);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_24_S2);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_24_S3);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_25);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_25_S1);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_25_S2);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_25_S3);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_26);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_26_S1);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_26_S2);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_26_S3);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_27);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_27_S1);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_27_S2);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_27_S3);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_28);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_28_S1);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_28_S2);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_28_S3);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_29);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_29_S1);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_29_S2);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_LOC_29_S3);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_30);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_30_S1);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_30_S2);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_LOC_30_S3);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_CLINIC_NBR_2);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_NX_AVAIL_BATCH_2);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_CLINIC_NBR_3);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_NX_AVAIL_BATCH_3);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_CLINIC_NBR_4);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_NX_AVAIL_BATCH_4);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_CLINIC_NBR_5);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_NX_AVAIL_BATCH_5);
                //Accept(ref fldF020_DOCTOR_MSTR_DOC_CLINIC_NBR_6);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_NX_AVAIL_BATCH_6);
                //Display(ref fldF020_DOCTOR_MSTR_DOC_NX_AVAIL_BATCH);
                Accept(ref fldF020_DOCTOR_MSTR_DOC_SPEC_CD);
                Accept(ref fldF020_DOCTOR_MSTR_DOC_SPEC_CD_2);
                Accept(ref fldF020_DOCTOR_MSTR_DOC_SPEC_CD_3);
                Display(ref fldW_PASSWORD);
                Display(ref fldW_START_DATE);
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


        protected override bool Append()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 9:56:26 AM
                Accept(ref fldF020C_DOC_CLINIC_NEXT_BATCH_NBR_DOC_CLINIC_NBR);
                Display(ref fldF020C_DOC_CLINIC_NEXT_BATCH_NBR_DOC_NX_AVAIL_BATCH);
                Accept(ref fldF020C_DOC_CLINIC_NEXT_BATCH_NBR_DOC_CLINIC_NBR_STATUS);



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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/26/2017 10:18:33 AM
        //#-----------------------------------------
        protected override bool Update()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/26/2017 10:18:33 AM
                fleF020_DOCTOR_MSTR.PutData(false, PutTypes.New);
                fleF020_DOCTOR_MSTR.PutData();

                while (fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.For())
                {
                    fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.PutData(false, PutTypes.Deleted);
                }
                while (fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.For())
                {
                    fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.PutData();
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
        //# dsrDesigner_09_Click Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/26/2017 10:18:34 AM
        //#-----------------------------------------
        private void dsrDesigner_09_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/26/2017 10:18:34 AM
                Accept(ref fldF020_DOCTOR_MSTR_DOC_SPEC_CD);
                Accept(ref fldF020_DOCTOR_MSTR_DOC_SPEC_CD_2);
                Accept(ref fldF020_DOCTOR_MSTR_DOC_SPEC_CD_3);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/26/2017 10:18:34 AM
        //#-----------------------------------------
        private void dsrDesigner_01_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/26/2017 10:18:34 AM
                if (!fleF020_DOCTOR_MSTR.NewRecord)
                {
                    Display(ref fldF020_DOCTOR_MSTR_DOC_NBR);
                }
                else
                {
                    Accept(ref fldF020_DOCTOR_MSTR_DOC_NBR);
                }
                Display(ref fldAPP_MSG);
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
